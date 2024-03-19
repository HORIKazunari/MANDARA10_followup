Public Class frmMain_Autocorrelation
    Private Structure objNeighbour_Info
        Public ObjectNumber As Integer
        Public wValue As Single
    End Structure

    Dim attrData As clsAttrData
    Dim LayerNum As Integer
    Public Overloads Sub ShowDialog(ByRef _attrData As clsAttrData)
        attrData = _attrData
        LayerNum = attrData.TotalData.LV1.SelectedLayer
        attrData.Set_DataTitle_to_ListBox(ListBoxEx, LayerNum, True, True, False, False)
        ListBoxEx.SelectedIndex = attrData.LayerData(LayerNum).atrData.SelectedIndex
        Me.ShowDialog()
    End Sub

    Private Sub ListBoxEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxEx.SelectedIndexChanged
        culcuAutocorrelations()
    End Sub
    Private Sub culcuAutocorrelations()

        Dim n As Integer = ListBoxEx.SelectedIndices.Count
        Dim o_n As Integer = attrData.Get_ObjectNum(LayerNum)
        Dim objNeighbour_origin() As List(Of objNeighbour_Info) = getObjNeighbour()
        Dim ListData As New List(Of String)
        ListData.Add("データ項目" + vbTab + "モランのI統計量")
        For data As Integer = 0 To n - 1
            Dim data_num = ListBoxEx.SelectedIndices(data)
            Dim mesF() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, data_num)
            Dim objNeighbour(o_n - 1) As List(Of objNeighbour_Info)

            For i As Integer = 0 To o_n - 1
                objNeighbour(i) = New List(Of objNeighbour_Info)
                objNeighbour(i).AddRange(objNeighbour_origin(i))
            Next

            '欠損値のチェック
            For i As Integer = 0 To o_n - 1
                If mesF(i) = True Then
                    For j As Integer = objNeighbour(i).Count - 1 To 0 Step -1
                        If objNeighbour(i)(j).ObjectNumber = i Then
                            objNeighbour(i).RemoveAt(j)
                        End If
                    Next
                End If
            Next

            Dim W As Double = 0

            Dim sumValue As Double = 0
            Dim xAve As Double = attrData.LayerData(LayerNum).atrData.Data(data_num).Statistics.Ave
            Dim dataValue() = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, data_num)
            Dim hhw As Double = 0
            Dim noMisn As Integer = 0
            For i As Integer = 0 To o_n - 1
                If mesF(i) = False Then
                    Dim x As Double = dataValue(i)
                    Dim sumData As Double = 0
                    For j As Integer = 0 To objNeighbour(i).Count - 1
                        Dim ao As Integer = objNeighbour(i)(j).ObjectNumber
                        sumData += (x - xAve) * (dataValue(ao) - xAve) * objNeighbour(i)(j).wValue
                        W += objNeighbour(i)(j).wValue
                    Next
                    sumValue += sumData
                    hhw += (x - xAve) ^ 2
                    noMisn += 1
                End If
            Next
            If sumValue <> 0 Then
                Dim MoranI As Single = (noMisn * sumValue) / (W * hhw)
                ListData.Add(attrData.Get_DataTitle(LayerNum, data_num, False) + vbTab + MoranI.ToString())
            Else
                ListData.Add(attrData.Get_DataTitle(LayerNum, data_num, False) + vbTab + "数値エラー")
            End If
        Next

        Dim VariType() As VariantType = {VariantType.String, VariantType.Single}
        ListViewEX.SetData(ListData, VariType, {False, False}, False)
    End Sub

    Private Function getObjNeighbour() As List(Of objNeighbour_Info)()
        Dim alin As Integer = attrData.LayerData(LayerNum).MapFileData.Map.ALIN
        Dim lineUse(alin - 1) As List(Of Integer)
        Dim o_n = attrData.Get_ObjectNum(LayerNum)
        For i As Integer = 0 To o_n - 1
            With attrData.LayerData(LayerNum)
                Dim ELine() As clsMapData.EnableMPLine_Data
                Dim NL As Integer = attrData.Get_Enable_KenCode_MPLine(ELine, LayerNum, i)

                For j As Integer = 0 To NL - 1
                    Dim c As Integer = ELine(j).LineCode
                    If lineUse(c) Is Nothing = True Then
                        lineUse(c) = New List(Of Integer)
                    End If
                    lineUse(c).Add(i)
                Next
            End With
        Next

        Dim objNeighbour(o_n - 1) As List(Of objNeighbour_Info)

        For i As Integer = 0 To alin - 1
            If lineUse(i) Is Nothing = False Then
                For j As Integer = 0 To lineUse(i).Count - 1
                    Dim oCode1 As Integer = lineUse(i).Item(j)
                    If objNeighbour(oCode1) Is Nothing = True Then
                        objNeighbour(oCode1) = New List(Of objNeighbour_Info)
                    End If
                    For k As Integer = 0 To lineUse(i).Count - 1
                        If k <> j Then
                            Dim objNb As objNeighbour_Info
                            objNb.ObjectNumber = lineUse(i).Item(k)
                            objNb.wValue = 1
                            Dim f As Boolean = True
                            For k2 As Integer = 0 To objNeighbour(oCode1).Count - 1
                                Dim d As objNeighbour_Info = objNeighbour(oCode1).Item(k2)
                                If d.ObjectNumber = objNb.ObjectNumber Then
                                    f = False
                                    Exit For
                                End If
                            Next
                            If f = True Then
                                objNeighbour(oCode1).Add(objNb)
                            End If
                        End If
                    Next
                Next
            End If
        Next
        Return objNeighbour
    End Function

    Private Sub btnGetNeighboutObj_Click(sender As Object, e As EventArgs) Handles btnGetNeighboutObj.Click
        Dim objNeighbour() As List(Of objNeighbour_Info) = getObjNeighbour()
        Dim o_n = attrData.Get_ObjectNum(LayerNum)
        Dim strData(o_n) As String
        For i As Integer = 0 To o_n - 1
            If objNeighbour(i) Is Nothing = False Then
                For j As Integer = 0 To objNeighbour(i).Count - 1
                    Dim neicode As Integer = objNeighbour(i).Item(j).ObjectNumber
                    Dim name As String = attrData.LayerData(LayerNum).atrObject.atrObjectData(neicode).Name
                    If strData(i) <> "" Then
                        strData(i) += "|"
                    End If
                    strData(i) += name
                Next
            End If
        Next
        Dim Title As String = "隣接オブジェクト"
        Dim note As String = ""
        Dim form As New frmTitleSettingsAddingData
        Dim unit = "STR"
        If form.ShowDialog(Title, unit, note, True) = Windows.Forms.DialogResult.OK Then
            form.getResult(Title, unit, note)
            attrData.Add_One_Data_Value(LayerNum, Title, "STR", note, strData, False)
        End If

    End Sub

    Private Sub btnTextCopy_Click(sender As Object, e As EventArgs) Handles btnTextCopy.Click
        ListViewEX.copyData()
    End Sub

    Private Sub frmMain_Autocorrelation_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_Autocorrelation", Me)

    End Sub
End Class