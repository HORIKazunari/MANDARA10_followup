Public Class frmMain_OverLayModeSettings
    Dim attData As clsAttrData
    Public Sub SetData(ByRef _attData As clsAttrData)
        Me.Tag = "OFF"
        attData = _attData
        AddDataSetToCboBox()
        If _attData.SetMapFile("").Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
            btnAddTile.Enabled = True
        Else
            btnAddTile.Enabled = False
        End If
        chkMarkModePosFixFlag.Checked = attData.TotalData.TotalMode.OverLay.MarkModePosFixFlag

        Me.Tag = ""

    End Sub
    Private Sub AddDataSetToCboBox()
        With attData.TotalData.TotalMode.OverLay
            cboOverlayDataSet.Items.Clear()
            For i As Integer = 0 To .DataSet.Count - 1
                Dim tx As String = .DataSet(i).title
                If tx = "" Then
                    tx = "データセット" + (i + 1).ToString
                End If
                cboOverlayDataSet.Items.Add(tx)
            Next
            cboOverlayDataSet.SelectedIndex = .SelectedIndex
        End With

    End Sub

    Private Sub cboOverlayDataSet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOverlayDataSet.SelectedIndexChanged
        If cboOverlayDataSet.Tag = "OFF" Then
            Return
        End If
        Dim ovn As Integer = cboOverlayDataSet.SelectedIndex
        attData.TotalData.TotalMode.OverLay.SelectedIndex = ovn
        Set_OverLayDataSet(0)
        With attData.TotalData.TotalMode.OverLay
            txtDataSetTitle.Text = .DataSet(ovn).title
            Me.Tag = "OFF"
            chkAlwaysOver.Checked = (ovn = .Always_Overlay_Index)
            Me.Tag = ""
        End With
    End Sub
    Private Sub Set_OverLayDataSet(ByVal selectIndex As Integer)

        Dim ovn As Integer = cboOverlayDataSet.SelectedIndex

        With attData.TotalData.TotalMode.OverLay.DataSet(ovn)
            Dim OverData(.DataItem.Count) As String
            OverData(0) = "レイヤ" + vbTab + "データ" + vbTab + "表示モード" + vbTab + " 凡例 "
            For i As Integer = 0 To .DataItem.Count - 1
                With .DataItem(i)
                    Dim tx As String = ""
                    If .TileMapf = True Then
                        tx += "" + vbTab + "タイル画像" + vbTab + .TileData.TileMapDataSet.Name + vbTab + "" + vbTab
                    Else
                        tx += attData.LayerData(.Layer).Name + vbTab
                        Select Case .Print_Mode_Layer
                            Case enmLayerMode_Number.SoloMode
                                tx += attData.Get_DataTitle(.Layer, .DataNumber, False) + vbTab
                                tx += clsGeneric.getSolomodeStrings(.Mode) + vbTab
                            Case enmLayerMode_Number.GraphMode
                                tx += "グラフ表示" + vbTab
                                Dim T As String = attData.LayerData(.Layer).LayerModeViewSettings.GraphMode.DataSet(.DataNumber).title
                                If T = "" Then
                                    T = "データセット" & CStr(.DataNumber + 1)
                                End If
                                tx += T + vbTab
                            Case enmLayerMode_Number.LabelMode
                                tx += "ラベル表示" + vbTab
                                Dim T As String = attData.LayerData(.Layer).LayerModeViewSettings.LabelMode.DataSet(.DataNumber).title
                                If T = "" Then
                                    T = "データセット" & CStr(.DataNumber + 1)
                                End If
                                tx += T + vbTab
                            Case enmLayerMode_Number.TripMode
                                tx += "移動表示" + vbTab
                                Dim T As String = attData.LayerData(.Layer).LayerModeViewSettings.TripMode.DataSet(.DataNumber).title
                                If T = "" Then
                                    T = "データセット" & CStr(.DataNumber + 1)
                                End If
                                tx += T + vbTab
                        End Select
                        If .Legend_Print_Flag = False Then
                            tx += "非表示"
                        Else
                            tx += "表示"
                        End If
                    End If
                    OverData(i + 1) = tx
                End With
            Next
            ListViewOverLay.SetData(OverData, {VariantType.String, VariantType.String, VariantType.String, VariantType.String}, {False, False, False, False}, False)
            If .DataItem.Count = 0 Then
                gbItemData.Visible = False
            Else
                gbItemData.Visible = True
                ListViewOverLay.Items(selectIndex).Selected = True
            End If
            ListViewOverLay.Select()
        End With
    End Sub
    Private Sub Show_OverLay_Dataset_Property(ByVal n As Integer)

        Dim ovn As Integer = cboOverlayDataSet.SelectedIndex
        With attData.TotalData.TotalMode.OverLay.DataSet(ovn).DataItem(n)
            If .TileMapf = False Then
                chkOverLayLegend.Visible = True
                btnTileChange.Visible = False
                Dim f As Boolean = .Legend_Print_Flag
                With chkOverLayLegend
                    .Tag = "OFF"
                    .Checked = f
                    .Tag = ""
                End With
            Else
                btnTileChange.Visible = True
                chkOverLayLegend.Visible = False
            End If

        End With
    End Sub

    Private Sub chkOverLayLegend_CheckedChanged(sender As Object, e As EventArgs) Handles chkOverLayLegend.CheckedChanged

        Dim s As Integer = attData.TotalData.TotalMode.OverLay.SelectedIndex
        With chkOverLayLegend
            If .Tag <> "OFF" Then
                Dim Index As Integer = ListViewOverLay.SelectedItems(0).Index
                Dim f As Boolean = chkOverLayLegend.Checked
                Dim d As clsAttrData.strOverLay_DataSet_Item_Info = attData.TotalData.TotalMode.OverLay.DataSet(s).DataItem(Index)
                d.Legend_Print_Flag = f
                attData.TotalData.TotalMode.OverLay.DataSet(s).DataItem(Index) = d
                With ListViewOverLay.SelectedItems(0)
                    If f = True Then
                        .SubItems(3).Text = "表示"
                    Else
                        .SubItems(3).Text = "非表示"
                    End If
                End With
            End If
        End With
        ListViewOverLay.Focus()
    End Sub

    Private Sub ListViewOverLay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewOverLay.SelectedIndexChanged
        If ListViewOverLay.SelectedItems.Count = 0 Then
            gbItemData.Visible = False
            Return
        End If
        gbItemData.Visible = True
        Dim Index As Integer = ListViewOverLay.SelectedItems(0).Index
        Show_OverLay_Dataset_Property(Index)
    End Sub

    Private Sub btnAllClear_Click(sender As Object, e As EventArgs) Handles btnAllClear.Click
        If MsgBox("現在のデータセットの重ね合わせ項目を全てクリアします。", MsgBoxStyle.YesNo, "MANDARA") = MsgBoxResult.Yes Then
            With attData.TotalData.TotalMode.OverLay
                Dim d As clsAttrData.strOverLay_Dataset_Info = .DataSet(.SelectedIndex)
                With d
                    .DataItem.Clear()
                End With
                .DataSet(.SelectedIndex) = d
                Set_OverLayDataSet(-1)
                CType(Me.Owner, frmMain).Check_Print_err()
            End With
        End If
    End Sub

    Private Sub btnErase_Click(sender As Object, e As EventArgs) Handles btnErase.Click
        If ListViewOverLay.SelectedItems.Count = 0 Then
            Return
        End If
        If MsgBox("選択した重ね合わせ項目をクリアします。", MsgBoxStyle.YesNo, "MANDARA") = MsgBoxResult.Yes Then
            Dim Index As Integer = ListViewOverLay.SelectedItems(0).Index
            Dim ovn As Integer = cboOverlayDataSet.SelectedIndex
            attData.TotalData.TotalMode.OverLay.DataSet(ovn).DataItem.RemoveAt(Index)
            ListViewOverLay.Items.RemoveAt(Index)
            If ListViewOverLay.Items.Count = 0 Then
                Return
            Else
                If Index = ListViewOverLay.Items.Count Then
                    ListViewOverLay.Items(Index - 1).Selected = True
                Else
                    ListViewOverLay.Items(Index).Selected = True
                End If
            End If
            ListViewOverLay.Select()
        End If
    End Sub

    Private Sub btnPositionUp_Click(sender As Object, e As EventArgs) Handles btnPositionUp.Click
        If ListViewOverLay.SelectedItems.Count = 0 Or ListViewOverLay.Items.Count = 1 Then
            Return
        End If
        Dim Index As Integer = ListViewOverLay.SelectedItems(0).Index
        Dim ovn As Integer = cboOverlayDataSet.SelectedIndex
        With attData.TotalData.TotalMode.OverLay.DataSet(ovn)
            Dim swapIndex As Integer = Index - 1
            If swapIndex = -1 Then
                swapIndex = .DataItem.Count - 1
            End If
            Dim popData As clsAttrData.strOverLay_DataSet_Item_Info = .DataItem(Index)
            .DataItem(Index) = .DataItem(swapIndex)
            .DataItem(swapIndex) = popData
            Set_OverLayDataSet(swapIndex)
        End With
    End Sub

    Private Sub btnPositionDown_Click(sender As Object, e As EventArgs) Handles btnPositionDown.Click
        If ListViewOverLay.SelectedItems.Count = 0 Or ListViewOverLay.Items.Count = 1 Then
            Return
        End If
        Dim Index As Integer = ListViewOverLay.SelectedItems(0).Index
        Dim ovn As Integer = cboOverlayDataSet.SelectedIndex
        With attData.TotalData.TotalMode.OverLay.DataSet(ovn)
            Dim swapIndex As Integer = Index + 1
            If swapIndex = .DataItem.Count Then
                swapIndex = 0
            End If
            Dim popData As clsAttrData.strOverLay_DataSet_Item_Info = .DataItem(Index)
            .DataItem(Index) = .DataItem(swapIndex)
            .DataItem(swapIndex) = popData
            Set_OverLayDataSet(swapIndex)
        End With
    End Sub

    Private Sub btnDeleteDataSet_Click(sender As Object, e As EventArgs) Handles btnDeleteDataSet.Click
        With attData.TotalData.TotalMode.OverLay
            If .DataSet.Count = 1 Then
                MsgBox("これ以上削除できません。", MsgBoxStyle.Exclamation)
                Return
            End If
            attData.TotalData.TotalMode.OverLay.DataSet.RemoveAt(.SelectedIndex)
            .SelectedIndex = Math.Min(.SelectedIndex, .DataSet.Count - 1)
            AddDataSetToCboBox()
            Dim aoi As Integer = attData.TotalData.TotalMode.OverLay.Always_Overlay_Index
            If aoi = .SelectedIndex Then
                aoi = -1
            Else
                If aoi > .SelectedIndex Then
                    aoi -= 1
                End If
            End If
            attData.TotalData.TotalMode.OverLay.Always_Overlay_Index = aoi
        End With

    End Sub

    Private Sub btnAddDataSet_Click(sender As Object, e As EventArgs) Handles btnAddDataSet.Click
        With attData.TotalData.TotalMode.OverLay
            Dim i As Integer = .DataSet.Count
            .AddDataSet()
            cboOverlayDataSet.Items.Add("データセット" + (i + 1).ToString)
            cboOverlayDataSet.SelectedIndex = i

        End With
    End Sub

    Private Sub chkAlwaysOver_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlwaysOver.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim f As Boolean = chkAlwaysOver.Checked
        Dim ovn As Integer = cboOverlayDataSet.SelectedIndex
        If f = False Then
            attData.TotalData.TotalMode.OverLay.Always_Overlay_Index = -1
        Else
            attData.TotalData.TotalMode.OverLay.Always_Overlay_Index = ovn
        End If
    End Sub
    Private Sub txtDataSetTitle_LostFocus(sender As Object, e As EventArgs) Handles txtDataSetTitle.LostFocus

        With attData.TotalData.TotalMode.OverLay
            Dim i As Integer = cboOverlayDataSet.SelectedIndex
            Dim d As clsAttrData.strOverLay_Dataset_Info = .DataSet(i)
            With d
                If .title <> txtDataSetTitle.Text Then
                    .title = txtDataSetTitle.Text
                    cboOverlayDataSet.Tag = "OFF"
                    cboOverlayDataSet.Items(i) = .title
                    cboOverlayDataSet.Tag = ""
                End If
            End With
            .DataSet(i) = d
        End With
    End Sub


    Private Sub frmMain_OverLayModeSettings_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim frm As frmMain
            frm = CType(Me.Owner, frmMain)
            frm.btnDraw.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btnAddTile_Click(sender As Object, e As EventArgs) Handles btnAddTile.Click
        Dim ovn As Integer = cboOverlayDataSet.SelectedIndex
        Dim tdata As clsAttrData.strOverLay_DataSet_Item_Info
        tdata.TileMapf = True
        With tdata.TileData
            .TileMapDataSet = attData.TileMap.getTileMap_by_Name("地理院地図（標準地図）")
            .AlphaValue = 255
            .LastUserFolder = ""
            .LastWorldFileFolder = ""
            .TransparentF = False
        End With
        Dim form = New frmTileMapServiceSelect
        If form.ShowDialog(Me, tdata.TileData, attData.TileMap) = DialogResult.OK Then
            form.getResult(tdata.TileData)
            attData.TotalData.TotalMode.OverLay.DataSet(ovn).DataItem.Add(tdata)
            Set_OverLayDataSet(attData.TotalData.TotalMode.OverLay.DataSet(ovn).DataItem.Count - 1)
        End If
        form.Dispose()

    End Sub

    Private Sub btnTileChange_Click(sender As Object, e As EventArgs) Handles btnTileChange.Click
        Dim s As Integer = attData.TotalData.TotalMode.OverLay.SelectedIndex
        Dim Index As Integer = ListViewOverLay.SelectedItems(0).Index
        With attData.TotalData.TotalMode.OverLay.DataSet(s)
            Dim dt As clsAttrData.strOverLay_DataSet_Item_Info = .DataItem(Index)
            Dim form = New frmTileMapServiceSelect
            If form.ShowDialog(Me, dt.TileData, attData.TileMap) = DialogResult.OK Then
                form.getResult(dt.TileData)
                .DataItem(Index) = dt
                Set_OverLayDataSet(Index)
            End If
            form.Dispose()
        End With
    End Sub

    Private Sub btnNote_Click(sender As Object, e As EventArgs) Handles btnNote.Click
        With attData.TotalData.TotalMode.OverLay
            Dim s As Integer = .SelectedIndex
            Dim d As clsAttrData.strOverLay_Dataset_Info = .DataSet(s)
            Dim tx As String = d.Note
            clsGeneric.Message(Me, "注", tx, False, True)
            d.Note = tx
            .DataSet(s) = d
        End With
    End Sub
    Private Sub ListViewSeries_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewOverLay.KeyDown
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
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "overlayMode")
    End Sub

    Private Sub chkMarkModePosFixFlag_CheckedChanged(sender As Object, e As EventArgs) Handles chkMarkModePosFixFlag.CheckedChanged
        attData.TotalData.TotalMode.OverLay.MarkModePosFixFlag = chkMarkModePosFixFlag.Checked
    End Sub
End Class