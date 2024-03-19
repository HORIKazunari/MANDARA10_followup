Public Class frmMain_SetSeriesMode
    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData
    Dim DataItem As List(Of clsAttrData.strSeries_DataSet_Item_Info)
    Private Sub MeFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData, ByVal LayerNum As Integer) As DialogResult
        DataItem = New List(Of clsAttrData.strSeries_DataSet_Item_Info)
        attrData = _attrData
        attrData.Set_LayerName_to(cboLayerSolo, LayerNum)
        attrData.Set_LayerName_to(cboLayerGraph, LayerNum)
        attrData.Set_LayerName_to(cboLayerLabel, LayerNum)
        attrData.Set_LayerName_to(cboLayerTrip, LayerNum)
        With attrData.TotalData.TotalMode.Series
            cboExsistingDataSet.Items.Clear()
            For i As Integer = 0 To .DataSet.Count - 1
                Dim tx As String = .DataSet(i).title
                If tx = "" Then
                    tx = "データセット" + (i + 1).ToString
                End If
                cboExsistingDataSet.Items.Add(tx)
            Next
            cboExsistingDataSet.SelectedIndex = 0
        End With
        rbExsistingDataSet.Checked = True
        txtNewDataSet.Enabled = False
        cboExsistingDataSet.Enabled = True

        lbOverLayDataSet.Items.Clear()
        With attrData.TotalData.TotalMode.OverLay
            For i As Integer = 0 To .DataSet.Count - 1
                Dim tx As String = .DataSet(i).title
                If tx = "" Then
                    tx = "データセット" + (i + 1).ToString
                End If
                lbOverLayDataSet.Items.Add(tx)
            Next
        End With
        Return Me.ShowDialog()
    End Function
    Public Function getResults(ByRef _attrData As clsAttrData)
        Dim sel As Integer
        With _attrData.TotalData.TotalMode.Series
            If rbNewDataSet.Checked = True Then
                Dim dt As clsAttrData.strSeries_Dataset_Info
                sel = .DataSet.Count
                dt.title = txtNewDataSet.Text
                dt.SelectedIndex = 0
                dt.DataItem = DataItem
                .DataSet.Add(dt)
            Else
                sel = cboExsistingDataSet.SelectedIndex
                Dim dt As clsAttrData.strSeries_Dataset_Info = _attrData.TotalData.TotalMode.Series.DataSet(sel)
                dt.SelectedIndex = 0
                dt.DataItem.Clear()
                dt.DataItem = DataItem
                _attrData.TotalData.TotalMode.Series.DataSet(sel) = dt
            End If
        End With
        Return sel
    End Function
    Private Sub cboLayerSolo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayerSolo.SelectedIndexChanged
        attrData.Set_DataTitle_to_ListBox(lbSoloDataItem, cboLayerSolo.SelectedIndex, True)

    End Sub

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        Dim LayerNum As Integer

        Dim emes As String = ""
        Select Case tabData.SelectedIndex
            Case 0
                Dim seln As Integer = lbSoloDataItem.SelectedIndices.Count
                If seln = 0 Then
                    Return
                End If
                LayerNum = cboLayerSolo.SelectedIndex
                For i As Integer = 0 To lbSoloDataItem.Items.Count - 1
                    If lbSoloDataItem.GetSelected(i) = True Then
                        Dim dt As clsAttrData.strSeries_DataSet_Item_Info
                        dt.Data = i
                        dt.Layer = LayerNum
                        dt.Print_Mode_Layer = enmLayerMode_Number.SoloMode
                        dt.Print_Mode_Total = enmTotalMode_Number.DataViewMode
                        Select Case True
                            Case rbPaint.Checked
                                dt.SoloMode = enmSoloMode_Number.ClassPaintMode
                            Case rbHarch.Checked
                                dt.SoloMode = enmSoloMode_Number.ClassHatchMode
                            Case rbClassMark.Checked
                                dt.SoloMode = enmSoloMode_Number.ClassMarkMode
                            Case rbOD.Checked
                                dt.SoloMode = enmSoloMode_Number.ClassODMode
                            Case rbSize.Checked
                                dt.SoloMode = enmSoloMode_Number.MarkSizeMode
                            Case rbBlock.Checked
                                dt.SoloMode = enmSoloMode_Number.MarkBlockMode
                            Case rbTurn.Checked
                                dt.SoloMode = enmSoloMode_Number.MarkTurnMode
                            Case rbBar.Checked
                                dt.SoloMode = enmSoloMode_Number.MarkBarMode
                            Case rbContour.Checked
                                dt.SoloMode = enmSoloMode_Number.ContourMode
                            Case rbString.Checked
                                dt.SoloMode = enmSoloMode_Number.StringMode
                        End Select
                        If attrData.Check_Enable_SoloMode(dt.SoloMode, LayerNum, i) = True Then
                            DataItem.Add(dt)
                        Else
                            emes += lbSoloDataItem.Items(i) & "は" & clsGeneric.getSolomodeStrings(dt.SoloMode) & "モードで表示できません。" + vbCrLf
                        End If
                    End If
                Next
            Case 1
                Dim seln As Integer = lbGraphDataSet.SelectedIndices.Count
                If seln = 0 Then
                    Return
                End If
                LayerNum = cboLayerGraph.SelectedIndex
                For i As Integer = 0 To lbGraphDataSet.Items.Count - 1
                    Dim dt As clsAttrData.strSeries_DataSet_Item_Info
                    dt.Data = i
                    dt.Layer = LayerNum
                    dt.Print_Mode_Total = enmTotalMode_Number.DataViewMode
                    dt.Print_Mode_Layer = enmLayerMode_Number.GraphMode
                    DataItem.Add(dt)
                Next
            Case 2
                Dim seln As Integer = lbLabelDataSet.SelectedIndices.Count
                If seln = 0 Then
                    Return
                End If
                LayerNum = cboLayerLabel.SelectedIndex
                For i As Integer = 0 To lbLabelDataSet.Items.Count - 1
                    Dim dt As clsAttrData.strSeries_DataSet_Item_Info
                    dt.Data = i
                    dt.Layer = LayerNum
                    dt.Print_Mode_Total = enmTotalMode_Number.DataViewMode
                    dt.Print_Mode_Layer = enmLayerMode_Number.LabelMode
                    DataItem.Add(dt)
                Next
            Case 3
                Dim seln As Integer = lbTripDataSet.SelectedIndices.Count
                If seln = 0 Then
                    Return
                End If
                LayerNum = cboLayerTrip.SelectedIndex
                For i As Integer = 0 To lbTripDataSet.Items.Count - 1
                    Dim dt As clsAttrData.strSeries_DataSet_Item_Info
                    dt.Data = i
                    dt.Layer = LayerNum
                    dt.Print_Mode_Total = enmTotalMode_Number.DataViewMode
                    dt.Print_Mode_Layer = enmLayerMode_Number.TripMode
                    DataItem.Add(dt)
                Next
            Case 4
                Dim seln As Integer = lbOverLayDataSet.SelectedIndices.Count
                If seln = 0 Then
                    Return
                End If
                For i As Integer = 0 To lbOverLayDataSet.Items.Count - 1
                    Dim dt As clsAttrData.strSeries_DataSet_Item_Info
                    dt.Data = i
                    dt.Print_Mode_Total = enmTotalMode_Number.OverLayMode
                    DataItem.Add(dt)
                Next
        End Select
        SetListView()
        If emes <> "" Then
            clsGeneric.Message(Me, "エラー", emes, True, True)
        End If
    End Sub

    Private Sub rbNewDataSet_CheckedChanged(sender As Object, e As EventArgs) Handles rbNewDataSet.CheckedChanged
        If rbNewDataSet.Checked = True Then
            txtNewDataSet.Enabled = True
            cboExsistingDataSet.Enabled = False
            DataItem.Clear()
            SetListView()
        Else
            txtNewDataSet.Enabled = False
            cboExsistingDataSet.Enabled = True
            copyExsistAttrDataItem
        End If
    End Sub
    Private Sub copyExsistAttrDataItem()
        DataItem.Clear()
        Dim n As Integer = cboExsistingDataSet.SelectedIndex
        With attrData.TotalData.TotalMode.Series.DataSet(n)
            For i As Integer = 0 To .DataItem.Count - 1
                Dim dt As clsAttrData.strSeries_DataSet_Item_Info = .DataItem(i)
                DataItem.Add(dt)
            Next

        End With
        SetListView()
    End Sub
    Private Sub SetListView()
        clsGeneric.SeriesMode_to_ListViewData(ListViewSeries, attrData, DataItem)
    End Sub

    Private Sub cboExsistingDataSet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboExsistingDataSet.SelectedIndexChanged
        copyExsistAttrDataItem()
    End Sub

    ''' <summary>
    ''' 選択した項目を削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If ListViewSeries.SelectedIndices.Count = 0 Then
            Return
        End If
        Dim del(DataItem.Count - 1) As Boolean
        For i As Integer = 0 To ListViewSeries.SelectedIndices.Count - 1
            del(ListViewSeries.SelectedIndices(i)) = True
        Next
        For i As Integer = DataItem.Count - 1 To 0 Step -1
            If del(i) = True Then
                DataItem.RemoveAt(i)
            End If
        Next
        SetListView()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If DataItem.Count = 0 Then
            MsgBox("連続表示モードに設定するデータが選択されていません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
        End If
    End Sub

    Private Sub cboLayerGraph_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayerGraph.SelectedIndexChanged
        With attrData.LayerData(cboLayerGraph.SelectedIndex).LayerModeViewSettings.GraphMode
            lbGraphDataSet.Items.Clear()
            For i As Integer = 0 To .Count - 1
                Dim tx As String = .DataSet(i).title
                If tx = "" Then
                    tx = "データセット" + (i + 1).ToString
                End If
                lbGraphDataSet.Items.Add(tx)
            Next
        End With

    End Sub

    Private Sub cboLayerLabel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayerLabel.SelectedIndexChanged
        With attrData.LayerData(cboLayerLabel.SelectedIndex).LayerModeViewSettings.LabelMode
            lbLabelDataSet.Items.Clear()
            For i As Integer = 0 To .Count - 1
                Dim tx As String = .DataSet(i).title
                If tx = "" Then
                    tx = "データセット" + (i + 1).ToString
                End If
                lbLabelDataSet.Items.Add(tx)
            Next
        End With

    End Sub

    Private Sub cboLayerTrip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayerTrip.SelectedIndexChanged
        With attrData.LayerData(cboLayerTrip.SelectedIndex).LayerModeViewSettings.TripMode
            lbTripDataSet.Items.Clear()
            For i As Integer = 0 To .Count - 1
                Dim tx As String = .DataSet(i).title
                If tx = "" Then
                    tx = "データセット" + (i + 1).ToString
                End If
                lbTripDataSet.Items.Add(tx)
            Next
        End With
    End Sub

    Private Sub frmMain_SetSeriesMode_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_SetSeriesMode", Me)

    End Sub
End Class