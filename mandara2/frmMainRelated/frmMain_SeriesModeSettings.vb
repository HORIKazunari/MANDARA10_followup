Public Class frmMain_SeriesModeSettings
    Dim attData As clsAttrData
    Public Sub SetData(ByRef _attData As clsAttrData)
        Me.Tag = "OFF"
        attData = _attData
        AddDataSetToCboBox()
        Me.Tag = ""

    End Sub
    Private Sub AddDataSetToCboBox()
        With attData.TotalData.TotalMode.Series
            cboSeriesDataSet.Items.Clear()
            For i As Integer = 0 To .DataSet.Count - 1
                Dim tx As String = .DataSet(i).title
                If tx = "" Then
                    tx = "データセット" + (i + 1).ToString
                End If
                cboSeriesDataSet.Items.Add(tx)
            Next
            cboSeriesDataSet.SelectedIndex = .SelectedIndex
        End With

    End Sub
    Private Sub cboSeriesDataSet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSeriesDataSet.SelectedIndexChanged
        If cboSeriesDataSet.Tag = "OFF" Then
            Return
        End If
        Dim ovn As Integer = cboSeriesDataSet.SelectedIndex
        attData.TotalData.TotalMode.Series.SelectedIndex = ovn
        Set_cboSeriesDataSetList(0)
        With attData.TotalData.TotalMode.Series
            txtDataSetTitle.Text = .DataSet(ovn).title
        End With
    End Sub

    Private Sub Set_cboSeriesDataSetList(ByVal selectIndex As Integer)

        Dim sen As Integer = cboSeriesDataSet.SelectedIndex

        clsGeneric.SeriesMode_to_ListViewData(ListViewSeries, attData, attData.TotalData.TotalMode.Series.DataSet(sen).DataItem)
        If attData.TotalData.TotalMode.Series.DataSet(sen).DataItem.Count = 0 Then
            gbItemData.Visible = False
        Else
            gbItemData.Visible = True
            ListViewSeries.Items(selectIndex).Selected = True
        End If


    End Sub
    Private Sub btnPositionUp_Click(sender As Object, e As EventArgs) Handles btnPositionUp.Click
        If ListViewSeries.SelectedItems.Count = 0 Or ListViewSeries.Items.Count = 1 Then
            Return
        End If
        Dim Index As Integer = ListViewSeries.SelectedItems(0).Index
        Dim ovn As Integer = cboSeriesDataSet.SelectedIndex
        With attData.TotalData.TotalMode.Series.DataSet(ovn)
            Dim swapIndex As Integer = Index - 1
            If swapIndex = -1 Then
                swapIndex = .DataItem.Count - 1
            End If
            Dim popData As clsAttrData.strSeries_DataSet_Item_Info = .DataItem(Index)
            .DataItem(Index) = .DataItem(swapIndex)
            .DataItem(swapIndex) = popData
            Set_cboSeriesDataSetList(swapIndex)
        End With
    End Sub

    Private Sub btnPositionDown_Click(sender As Object, e As EventArgs) Handles btnPositionDown.Click
        If ListViewSeries.SelectedItems.Count = 0 Or ListViewSeries.Items.Count = 1 Then
            Return
        End If
        Dim Index As Integer = ListViewSeries.SelectedItems(0).Index
        Dim ovn As Integer = cboSeriesDataSet.SelectedIndex
        With attData.TotalData.TotalMode.Series.DataSet(ovn)
            Dim swapIndex As Integer = Index + 1
            If swapIndex = .DataItem.Count Then
                swapIndex = 0
            End If
            Dim popData As clsAttrData.strSeries_DataSet_Item_Info = .DataItem(Index)
            .DataItem(Index) = .DataItem(swapIndex)
            .DataItem(swapIndex) = popData
            Set_cboSeriesDataSetList(swapIndex)
        End With
    End Sub

    Private Sub btnDeleteDataSet_Click(sender As Object, e As EventArgs) Handles btnDeleteDataSet.Click
        With attData.TotalData.TotalMode.Series
            If .DataSet.Count = 1 Then
                MsgBox("これ以上削除できません。", MsgBoxStyle.Exclamation)
                Return
            End If
            .DataSet.RemoveAt(.SelectedIndex)
            .SelectedIndex = Math.Min(.SelectedIndex, .DataSet.Count - 1)
            AddDataSetToCboBox()
        End With

    End Sub

    Private Sub btnAddDataSet_Click(sender As Object, e As EventArgs) Handles btnAddDataSet.Click
        With attData.TotalData.TotalMode.Series
            Dim i As Integer = .DataSet.Count
            .AddDataSet()
            cboSeriesDataSet.Items.Add("データセット" + (i + 1).ToString)
            cboSeriesDataSet.SelectedIndex = i

        End With
    End Sub

    Private Sub btnAllClear_Click(sender As Object, e As EventArgs) Handles btnAllClear.Click
        If MsgBox("現在のデータセットの項目を全てクリアします。", MsgBoxStyle.YesNo, "MANDARA") = MsgBoxResult.Yes Then
            CType(Me.Owner, frmMain).Frm_Print.Visible = False
            With attData.TotalData.TotalMode.Series
                With .DataSet(.SelectedIndex)
                    .DataItem.Clear()
                End With
                Set_cboSeriesDataSetList(-1)
                CType(Me.Owner, frmMain).Check_Print_err()
            End With
        End If
    End Sub

    Private Sub txtDataSetTitle_LostFocus(sender As Object, e As EventArgs) Handles txtDataSetTitle.LostFocus
        With attData.TotalData.TotalMode.Series
            Dim i As Integer = cboSeriesDataSet.SelectedIndex
            Dim d As clsAttrData.strSeries_Dataset_Info = .DataSet(i)
            With d
                If .title <> txtDataSetTitle.Text Then
                    .title = txtDataSetTitle.Text
                    cboSeriesDataSet.Tag = "OFF"
                    cboSeriesDataSet.Items(i) = .title
                    cboSeriesDataSet.Tag = ""
                End If
            End With
            .DataSet(i) = d
        End With
    End Sub

    Private Sub btnErase_Click(sender As Object, e As EventArgs) Handles btnErase.Click
        If ListViewSeries.SelectedItems.Count = 0 Then
            Return
        End If
        If MsgBox("選択した項目をクリアします。", MsgBoxStyle.YesNo, "MANDARA") = MsgBoxResult.Yes Then
            CType(Me.Owner, frmMain).Frm_Print.Visible = False
            Dim Index As Integer = ListViewSeries.SelectedItems(0).Index
            Dim n As Integer = cboSeriesDataSet.SelectedIndex
            attData.TotalData.TotalMode.Series.DataSet(n).DataItem.RemoveAt(Index)
            Dim seln As Integer = -1
            CType(Me.Owner, frmMain).Check_Print_err()
            If ListViewSeries.Items.Count <> 1 Then
                If Index = ListViewSeries.Items.Count - 1 Then
                    seln = Index - 1
                Else
                    seln = Index
                End If
            End If
            Set_cboSeriesDataSetList(seln)
            ListViewSeries.Select()
        End If
    End Sub

    Private Sub frmMain_SeriesModeSettings_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim frm As frmMain
            frm = CType(Me.Owner, frmMain)
            frm.btnDraw.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ListViewSeries_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewSeries.KeyDown
        Select Case e.KeyData
            Case Keys.Delete
                btnErase.PerformClick()
            Case Keys.Up
                btnPositionUp.PerformClick()
            Case Keys.Down
                btnPositionDown.PerformClick()
        End Select
        e.Handled = True
    End Sub


    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "seriesMode")
    End Sub

    Private Sub txtDataSetTitle_TextChanged(sender As Object, e As EventArgs) Handles txtDataSetTitle.TextChanged

    End Sub

    Private Sub btnReverse_Click(sender As Object, e As EventArgs) Handles btnReverse.Click
        If ListViewSeries.SelectedItems.Count = 0 Or ListViewSeries.Items.Count = 1 Then
            Return
        End If
        Dim Index As Integer = ListViewSeries.SelectedItems(0).Index
        Dim ovn As Integer = cboSeriesDataSet.SelectedIndex
        With attData.TotalData.TotalMode.Series.DataSet(ovn)
            For i As Integer = 0 To .DataItem.Count \ 2 - 1
                Dim popData As clsAttrData.strSeries_DataSet_Item_Info = .DataItem(i)
                .DataItem(i) = .DataItem(.DataItem.Count - 1 - i)
                .DataItem(.DataItem.Count - 1 - i) = popData
            Next
            For i As Integer = 0 To .DataItem.Count - 1
                Set_cboSeriesDataSetList(i)
            Next
        End With
    End Sub
End Class