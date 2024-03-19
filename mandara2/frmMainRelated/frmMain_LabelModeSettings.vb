Public Class frmMain_LabelModeSettings
    Dim attData As clsAttrData
    Dim LayerNum As Integer
    Dim ScrData As Screen_info
    Dim basePic As BasePicture_Info



    Public Sub SetData(ByRef _attData As clsAttrData)

        attData = _attData
        LayerNum = attData.TotalData.LV1.SelectedLayer
        AddDataSetToCboBox()

    End Sub
    Private Sub AddDataSetToCboBox()
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            cboLabelDataSet.Items.Clear()
            For i As Integer = 0 To .Count - 1
                Dim tx As String = .DataSet(i).title
                If tx = "" Then
                    tx = "データセット" + (i + 1).ToString
                End If
                cboLabelDataSet.Items.Add(tx)
            Next
            cboLabelDataSet.SelectedIndex = .SelectedIndex
        End With

    End Sub
    Private Sub SetControlsValue()
        Me.Tag = "OFF"
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                txtDataSetTitle.Text = .title
                cbObjectName.Checked = .ObjectName_Print_Flag
                cbObjectNameMaxWidthReturn.Checked = .ObjectName_Turn_Flag
                ListBox.Items.Clear()
                For i As Integer = 0 To .CountOfDataItem - 1
                    ListBox.Items.Add(attData.Get_DataTitle(LayerNum, .DataItem(i), True))
                Next
                cbDataTitle.Checked = .DataName_Print_Flag
                cbDataUnit.Checked = .DataValue_Unit_Flag
                cbDataItemMaxWidthReturn.Checked = .DataValue_TurnFlag
                cbDummyObjectName.Checked = .Dummy_Object_Flag
                cbDummyObjectGroupName.Checked = .Dummy_Object_Group_Flag
                cbObjectName1.Checked = .Dummy_Object_Group_Name1priority
                txtMaxWidth.Text = .Width
                cbMark.Checked = .Location_Mark_Flag
                attData.Draw_Sample_LineBox(picBorderLinePattern, .BorderLine)
                attData.Draw_Sample_TileBox(picObjectNameBack, .BorderObjectTile)
                attData.Draw_Sample_TileBox(picDataItemBack, .BorderDataTile)
            End With
        End With
        Me.Tag = ""
    End Sub

    Private Sub cboLabelDataSet_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboLabelDataSet.SelectedIndexChanged

        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            .SelectedIndex = cboLabelDataSet.SelectedIndex
        End With

        SetControlsValue()
    End Sub
    Private Sub ChangeCheckedValue(sender As Object, e As EventArgs) Handles cbObjectName.CheckedChanged,
                    cbObjectNameMaxWidthReturn.CheckedChanged, cbDataTitle.CheckedChanged, cbDataUnit.CheckedChanged,
                    cbDataItemMaxWidthReturn.CheckedChanged, cbDummyObjectName.CheckedChanged, cbDummyObjectGroupName.CheckedChanged,
                    cbObjectName1.CheckedChanged, cbMark.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                .ObjectName_Print_Flag = cbObjectName.Checked
                .ObjectName_Turn_Flag = cbObjectNameMaxWidthReturn.Checked
                .DataName_Print_Flag = cbDataTitle.Checked
                .DataValue_Unit_Flag = cbDataUnit.Checked
                .DataValue_TurnFlag = cbDataItemMaxWidthReturn.Checked
                .Dummy_Object_Flag = cbDummyObjectName.Checked
                .Dummy_Object_Group_Flag = cbDummyObjectGroupName.Checked
                .Dummy_Object_Group_Name1priority = cbObjectName1.Checked
                .Location_Mark_Flag = cbMark.Checked
            End With
        End With

    End Sub
    Private Sub txtDataSetTitle_LostFocus(sender As Object, e As EventArgs) Handles txtDataSetTitle.LostFocus

        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            Dim i As Integer = cboLabelDataSet.SelectedIndex
            With .DataSet(i)
                If .title <> txtDataSetTitle.Text Then
                    .title = txtDataSetTitle.Text
                    cboLabelDataSet.Items(i) = .title
                End If
            End With
        End With
    End Sub
    Private Sub txtMaxwidth_LostFocus(sender As Object, e As EventArgs) Handles txtMaxWidth.LostFocus
        If Me.Tag = "" Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
                With .DataSet(.SelectedIndex)
                    .Width = Val(txtMaxWidth.Text)
                    txtMaxWidth.Text = .Width
                End With
            End With
        End If
    End Sub

    Private Sub btnAddDataSet_Click(sender As Object, e As EventArgs) Handles btnAddDataSet.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            Dim i As Integer = .Count
            .AddDataSet()
            cboLabelDataSet.Items.Add("データセット" + (i + 1).ToString)
            Me.Tag = "OFF"
            cboLabelDataSet.SelectedIndex = i
            Me.Tag = ""
        End With
    End Sub

    Private Sub btnDeleteDataSet_Click(sender As Object, e As EventArgs) Handles btnDeleteDataSet.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            If .Count = 1 Then
                MsgBox("これ以上削除できません。", MsgBoxStyle.Exclamation)
                Return
            Else
                .RemoveDataSet(.SelectedIndex)
                'Call Remove_OverLay_Data_Item(1, EditedGraphDataStac)
                'Call Remove_Series_Data_Item(0, 1, EditedGraphDataStac)
                .SelectedIndex = Math.Min(.SelectedIndex, .Count - 1)
                AddDataSetToCboBox()
            End If
        End With
    End Sub


    Private Sub btnDataUpward_Click(sender As Object, e As EventArgs) Handles btnDataUpward.Click, btnDataDownward.Click
        Dim os As Integer = ListBox.SelectedIndex
        If os = -1 Then
            Return
        End If
        Dim news As Integer
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                If sender.name = "btnDataUpward" Then
                    If os = 0 Then
                        news = .CountOfDataItem - 1
                    Else
                        news = os - 1
                    End If
                Else
                    If os = .CountOfDataItem - 1 Then
                        news = 0
                    Else
                        news = os + 1
                    End If
                End If
                clsGeneric.SWAP(.DataItem(os), .DataItem(news))
                Dim s As String = ListBox.Items.Item(os)
                ListBox.Items.Item(os) = ListBox.Items.Item(news)
                ListBox.Items.Item(news) = s
                ListBox.SelectedIndex = news
            End With
        End With
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim n As Integer = attData.Get_DataSelect_fromComboBoxForm(LayerNum, True, True, True, True)
        If n = -1 Then
            Return
        Else
            With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
                With .DataSet(.SelectedIndex)
                    For i As Integer = 0 To .CountOfDataItem - 1
                        If .DataItem(i) = n Then
                            MsgBox("選択済みです。", MsgBoxStyle.Exclamation)
                            Return
                        End If
                    Next
                    ReDim Preserve .DataItem(.CountOfDataItem)
                    .DataItem(.CountOfDataItem) = n
                    ListBox.Items.Add(attData.Get_DataTitle(LayerNum, n, True))
                    ListBox.SelectedIndex = .CountOfDataItem
                    .CountOfDataItem += 1
                End With
            End With
        End If
    End Sub

    Private Sub btnAddRange_Click(sender As Object, e As EventArgs) Handles btnAddRange.Click
        Dim n As Integer = attData.Get_DataNum(LayerNum)
        Dim selected(n - 1) As Boolean
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                For i As Integer = 0 To .CountOfDataItem - 1
                    selected(.DataItem(i)) = True
                Next
                If attData.Get_DataSelect_from_ListBoxSelectForm(LayerNum, selected, True, True, True, True) = True Then
                    .CountOfDataItem = clsGeneric.Count_Specified_Value_Array(selected, True)
                    ReDim .DataItem(Math.Max(.CountOfDataItem - 1, 0))
                    Dim j As Integer = 0
                    For i As Integer = 0 To n - 1
                        If selected(i) = True Then
                            .DataItem(j) = i
                            j += 1
                        End If
                    Next
                    ListBox.Items.Clear()
                    For i As Integer = 0 To .CountOfDataItem - 1
                        ListBox.Items.Add(attData.Get_DataTitle(LayerNum, .DataItem(i), True))
                    Next
                End If
            End With
        End With

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim os As Integer = ListBox.SelectedIndex
        If os = -1 Then
            Return
        End If
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                If .CountOfDataItem = 0 Then
                    MsgBox("これ以上削除できません。", MsgBoxStyle.Exclamation)
                    Return
                End If
                For i As Integer = os To .CountOfDataItem - 2
                    .DataItem(i) = .DataItem(i + 1)
                Next
                ListBox.Items.RemoveAt(os)
                If os <> 0 Then
                    os -= 1
                End If
                .CountOfDataItem -= 1
                If .CountOfDataItem = 0 Then
                    Erase .DataItem
                Else
                    ListBox.SelectedIndex = os
                    ReDim Preserve .DataItem(.CountOfDataItem - 1)
                End If
            End With
        End With
    End Sub

    Private Sub btnAllClear_Click(sender As Object, e As EventArgs) Handles btnAllClear.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                If .CountOfDataItem = 0 Then
                    MsgBox("これ以上削除できません。", MsgBoxStyle.Exclamation)
                    Return
                End If
                .CountOfDataItem = 0
                Erase .DataItem
            End With
            ListBox.Items.Clear()
        End With
    End Sub


    Private Sub btnObjectNameFont_Click(sender As Object, e As EventArgs) Handles btnObjectNameFont.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                attData.Select_Font(.ObjectName_Font)
            End With
        End With
    End Sub


    Private Sub btnDataItemFont_Click(sender As Object, e As EventArgs) Handles btnDataItemFont.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                attData.Select_Font(.DataValue_Font)
            End With
        End With
    End Sub

    Private Sub btnDummyObject_Click(sender As Object, e As EventArgs) Handles btnDummyObject.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                attData.Select_Font(.Dummy_Object_Font)
            End With
        End With
    End Sub

    Private Sub btnDummyObjectGroup_Click(sender As Object, e As EventArgs) Handles btnDummyObjectGroup.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                attData.Select_Font(.Dummy_Object_Group_Font)
            End With
        End With
    End Sub

    Private Sub picBorderLinePattern_Click(sender As Object, e As EventArgs) Handles picBorderLinePattern.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                attData.Select_Line_Pattern(picBorderLinePattern, .BorderLine, True)
            End With
        End With
    End Sub

    Private Sub picObjectNameBack_Click(sender As Object, e As EventArgs) Handles picObjectNameBack.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                attData.Select_Tile(picObjectNameBack, .BorderObjectTile)
            End With
        End With
    End Sub



    Private Sub picDataItemBack_Click(sender As Object, e As EventArgs) Handles picDataItemBack.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                attData.Select_Tile(picDataItemBack, .BorderDataTile)
            End With
        End With
    End Sub

    Private Sub frmMain_LabelModeSettings_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim frm As frmMain
            frm = CType(Me.Owner, frmMain)
            frm.btnDraw.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "labelMode", Me)
    End Sub

    Private Sub btnMarkSetting_Click(sender As Object, e As EventArgs) Handles btnMarkSetting.Click

        With attData.LayerData(LayerNum).LayerModeViewSettings.LabelMode
            With .DataSet(.SelectedIndex)
                attData.Select_Mark(.Location_Mark)
            End With
        End With
    End Sub
End Class