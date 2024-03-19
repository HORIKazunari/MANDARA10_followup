Public Class frmPrint_SearchObjects
    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData
    Public Structure selobj_Info
        Public LayerNum As Integer
        Public ObjPosition As Integer
        Public Name As String
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Structure
    Private Sub frmFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.None
                If CloseCancelF = True Then
                    CloseCancelF = False
                    e.Cancel = True
                Else
                    e.Cancel = False
                End If
            Case Else
        End Select
    End Sub
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData, ByVal MultiSelectFlag As Boolean) As Windows.Forms.DialogResult
        attrData = _attrData
        If MultiSelectFlag = True Then
            lbList.SelectionMode = SelectionMode.MultiExtended
        Else
            lbList.SelectionMode = SelectionMode.One
        End If
        Return Me.ShowDialog

    End Function
    Public Function GetResults() As List(Of selobj_Info)
        Dim selObj As New List(Of selobj_Info)
        For Each obj As selobj_Info In lbList.SelectedItems
            selObj.Add(obj)
        Next
        Return selObj
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        lbList.Items.Clear()
        Dim tx As String = txtName.Text
        Dim layerCheck(attrData.TotalData.LV1.Lay_Maxn - 1) As Boolean
        Select Case attrData.TotalData.LV1.Print_Mode_Total
            Case enmTotalMode_Number.DataViewMode
                layerCheck(attrData.TotalData.LV1.SelectedLayer) = True
            Case enmTotalMode_Number.OverLayMode
                With attrData.TotalData.TotalMode.OverLay
                    For i As Integer = 0 To .DataSet(.SelectedIndex).DataItem.Count - 1
                        Dim Lay As Integer = .DataSet(.SelectedIndex).DataItem(i).Layer
                        If Lay > 0 Then
                            layerCheck(Lay) = True
                        End If
                    Next
                End With
            Case enmTotalMode_Number.SeriesMode
                Dim ix As Integer = attrData.TotalData.TotalMode.Series.SelectedIndex
                With attrData.TotalData.TotalMode.Series.DataSet(ix)
                    If .DataItem.Count > 0 Then
                        With .DataItem(attrData.TempData.Series_temp.Koma)
                            Select Case .Print_Mode_Total
                                Case enmTotalMode_Number.DataViewMode
                                    layerCheck(.Layer) = True
                                Case enmTotalMode_Number.OverLayMode
                                    Dim dt As Integer = .Data
                                    With attrData.TotalData.TotalMode.OverLay
                                        For i As Integer = 0 To .DataSet(dt).DataItem.Count - 1
                                            Dim Lay As Integer = .DataSet(dt).DataItem(i).Layer
                                            If Lay > 0 Then
                                                layerCheck(Lay) = True
                                            End If
                                        Next
                                    End With
                            End Select

                        End With
                    End If
                End With
        End Select

        For i As Integer = 0 To attrData.TotalData.LV1.Lay_Maxn - 1
            If attrData.LayerData(i).Type = clsAttrData.enmLayerType.Trip Or attrData.LayerData(i).Type = clsAttrData.enmLayerType.Trip_Definition Then
            Else
                If layerCheck(i) = True Then
                    For j As Integer = 0 To attrData.Get_ObjectNum(i) - 1
                        Dim okf As Boolean = False
                        If attrData.Check_Condition(i, j) = True = True Then
                            Dim name As String = attrData.LayerData(i).atrObject.atrObjectData(j).Name
                            If (name.IndexOf(tx, StringComparison.OrdinalIgnoreCase)) <> -1 Then
                                Dim data As selobj_Info
                                data.LayerNum = i
                                data.ObjPosition = j
                                data.Name = name
                                lbList.Items.Add(data)
                            End If
                        End If
                    Next
                End If
            End If
        Next
        If lbList.Items.Count = 1 Then
            lbList.SetSelected(0, True)
        End If
    End Sub
    Private Sub lbList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbList.DoubleClick
        btnOK.PerformClick()
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If lbList.SelectedIndices.Count = 0 Then
            MsgBox("オブジェクトが選択されていません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
    End Sub
End Class