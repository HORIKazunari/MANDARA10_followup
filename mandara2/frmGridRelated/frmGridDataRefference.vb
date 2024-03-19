Public Class frmGridDataRefference
    Dim newAttr As clsAttrData
    Dim oldAttr As clsAttrData
    Dim R_Conv As List(Of frmGrid.Layer_Data_Info())
    Dim ListLayData() As frmGrid.Layer_Data_Info
    Dim CloseCancelF As Boolean
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
    Public Overloads Function ShowDialog(ByRef _Conv As List(Of frmGrid.Layer_Data_Info()), ByRef _newattrData As clsAttrData, ByRef _oldattrData As clsAttrData) As Windows.Forms.DialogResult
        newAttr = _newattrData
        oldAttr = _oldattrData
        R_Conv = _Conv

        Dim nd As Integer = 0
        For i As Integer = 0 To newAttr.TotalData.LV1.Lay_Maxn - 1
            nd += newAttr.LayerData(i).atrData.Count
        Next
        ReDim ListLayData(nd - 1)
        With ListDataRef
            For Each ch As ColumnHeader In .Columns
                ch.Width = (.Width - SystemInformation.VerticalScrollBarWidth) \ 4 - 1
            Next
            .Items.Clear()
            Dim n As Integer = 0
            For i As Integer = 0 To newAttr.TotalData.LV1.Lay_Maxn - 1
                For j As Integer = 0 To newAttr.LayerData(i).atrData.Count - 1
                    Dim itmListItem As New ListViewItem
                    itmListItem.Text = newAttr.LayerData(i).Name
                    itmListItem.SubItems.Add(newAttr.Get_DataTitle(i, j, True))
                    If R_Conv(i)(j).Layer = -1 Then
                        itmListItem.SubItems.Add("新規")
                    Else
                        itmListItem.SubItems.Add(oldAttr.LayerData(R_Conv(i)(j).Layer).Name)
                    End If
                    If R_Conv(i)(j).Data = -1 Then
                        itmListItem.SubItems.Add("新規")
                    Else
                        itmListItem.SubItems.Add(oldAttr.Get_DataTitle(R_Conv(i)(j).Layer, R_Conv(i)(j).Data, True))
                    End If
                    ListLayData(n).Layer = i
                    ListLayData(n).Data = j
                    n += 1
                    .Items.Add(itmListItem)
                Next
            Next
        End With

        Return Me.ShowDialog()
    End Function
    Public Overloads Function getResult() As List(Of frmGrid.Layer_Data_Info())
        Return R_Conv
    End Function


    Private Sub ListDataRef_Click(sender As Object, e As EventArgs) Handles ListDataRef.Click
        If ListDataRef.SelectedItems.Count = 0 Then
            Return
        End If
        Dim n As Integer = ListDataRef.SelectedItems(0).Index
        Dim Layernum As Integer
        Dim DataNum As Integer
        Dim DT As enmAttDataType
        With ListLayData(n)
            Layernum = R_Conv(.Layer)(.Data).Layer
            DataNum = R_Conv(.Layer)(.Data).Data
            DT = newAttr.LayerData(.Layer).atrData.Data(.Data).DataType
        End With
        Dim DataList As New List(Of String())
        Dim LayName() As String = oldAttr.Get_LayerName()
        Dim Ldrray As New List(Of String)
        Ldrray.AddRange(LayName)
        Ldrray.Insert(0, "新規")
        DataList.Add({"新規"})
        LayName = Ldrray.ToArray
        For i As Integer = 0 To oldAttr.TotalData.LV1.Lay_Maxn - 1
            Dim d() As String = oldAttr.Get_DataTitle(i, True)
            For j As Integer = 0 To oldAttr.LayerData(i).atrData.Count - 1
                With oldAttr.LayerData(i).atrData.Data(j)
                    If DT <> .DataType Then
                        d(j) = "*" + d(j)
                    End If
                End With
            Next
            Dim dList As New List(Of String)
            dList.AddRange(d)
            dList.Insert(0, "新規")
            DataList.Add(dList.ToArray)
        Next

        Layernum += 1
        DataNum += 1
        If clsGeneric.Show_TwoCombobox_and_GetResult("対応データ選択", "旧レイヤ", "旧データ",
                                LayName, DataList, Layernum, DataNum) = True Then
            Layernum -= 1
            DataNum -= 1
            If Layernum = -1 Or DataNum = -1 Then
                Layernum = -1
                DataNum = -1
            End If
            With ListDataRef.Items(n)
                If Layernum = -1 Then
                    .SubItems(2).Text = "新規"
                Else
                    .SubItems(2).Text = oldAttr.LayerData(Layernum).Name
                End If
                If DataNum = -1 Then
                    .SubItems(3).Text = "新規"
                Else
                    .SubItems(3).Text = oldAttr.Get_DataTitle(Layernum, DataNum, True)
                End If
            End With
            With ListLayData(n)
                Dim d As frmGrid.Layer_Data_Info() = R_Conv(.Layer)
                d(.Data).Layer = Layernum
                d(.Data).Data = DataNum
                R_Conv(.Layer) = d
            End With
        End If
    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim mxdata As Integer = 0
        For i As Integer = 0 To oldAttr.TotalData.LV1.Lay_Maxn - 1
            mxdata = Math.Max(mxdata, oldAttr.LayerData(i).atrData.Count)
        Next
        Dim Check(oldAttr.TotalData.LV1.Lay_Maxn - 1, mxdata - 1) As Boolean
        Dim ef As String = ""
        For i As Integer = 0 To newAttr.TotalData.LV1.Lay_Maxn - 1
            For j As Integer = 0 To newAttr.LayerData(i).atrData.Count - 1
                If R_Conv(i)(j).Data <> -1 Then
                    If Check(R_Conv(i)(j).Layer, R_Conv(i)(j).Data) = True Then
                        ef += oldAttr.LayerData(R_Conv(i)(j).Layer).Name + ":" + oldAttr.Get_DataTitle(R_Conv(i)(j).Layer, R_Conv(i)(j).Data, False) + vbCrLf
                    Else
                        Check(R_Conv(i)(j).Layer, R_Conv(i)(j).Data) = True
                    End If
                End If
            Next
        Next
        If ef <> "" Then
            MsgBox("旧データ項目が複数の新データ項目に対応しています。" & vbCrLf & ef, MsgBoxStyle.Exclamation)
            CloseCancelF = True
        End If
    End Sub
End Class