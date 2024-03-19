Public Class frmMain_TripModeSettings
    Dim attData As clsAttrData
    Dim LayerNum As Integer
    Dim ScrData As Screen_info
    Dim basePic As BasePicture_Info
    Dim Trip_Definition_Layer_Number As Integer


    Public Sub SetData(ByRef _attData As clsAttrData)

        Me.Tag = "OFF"
        attData = _attData
        LayerNum = attData.TotalData.LV1.SelectedLayer
        Me.Width = gbDataSet.Left + gbDataSet.Width + 20

        attData.Set_DataTitle_to_cboBox(cboStayData, LayerNum, 0)
        cboStayData.Items.Insert(0, "表示しない")
        cboStayData.Items.Insert(1, "既定のライン")

        attData.Set_DataTitle_to_cboBox(cboTripData, LayerNum, 0)
        cboTripData.Items.Insert(0, "表示しない")
        cboTripData.Items.Insert(1, "既定のライン")

        attData.Set_DataTitle_to_cboBox(cboZData, LayerNum, 0, True, True, False, False)
        cboZData.Items.Insert(0, "時間")

        Trip_Definition_Layer_Number = attData.Get_Trip_Definition_Layer_Number
        If Trip_Definition_Layer_Number = -1 Then
            rbTripGraphDefinitionLayer.Enabled = False
        Else
            rbTripGraphDefinitionLayer.Enabled = True
            attData.Set_DataTitle_to_cboBox(cboTripDefinitionData, Trip_Definition_Layer_Number, -1)
        End If
        AddDataSetToCboBox()
        SetGroupBoxVisible()
        Me.Tag = ""

    End Sub
    Private Sub AddDataSetToCboBox()
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            cboTripDataSet.Items.Clear()
            For i As Integer = 0 To .Count - 1
                Dim tx As String = .DataSet(i).title
                If tx = "" Then
                    tx = "データセット" + (i + 1).ToString
                End If
                cboTripDataSet.Items.Add(tx)
            Next
            cboTripDataSet.SelectedIndex = .SelectedIndex
        End With

    End Sub
    Private Sub frmMain_TripModeSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        gbTripDefinitionLayerDataMode.Location = gbTripLayerDataMode.Location
    End Sub

    Private Sub cboTripDataSet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTripDataSet.SelectedIndexChanged
        Me.Tag = "OFF"
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            .SelectedIndex = cboTripDataSet.SelectedIndex
            With .DataSet(.SelectedIndex)
                txtDataSetTitle.Text = .title
                Select Case .Mode
                    Case clsAttrData.enmTripMode.Blanc
                        rbTripGraphBlanc.Checked = True
                    Case clsAttrData.enmTripMode.TripDefinitionLayerDataMode
                        rbTripGraphDefinitionLayer.Checked = True
                    Case clsAttrData.enmTripMode.TripLayerDataMode
                        rbTripGraphTripLayer.Checked = True
                End Select

                DateTimePickerStart.Value = .StartTime
                DateTimePickerEnd.Value = .EndTime
                gbTripLayerDataMode.Visible = (.Mode = clsAttrData.enmTripMode.TripDefinitionLayerDataMode)
                gbTripDefinitionLayerDataMode.Visible = (.Mode = clsAttrData.enmTripMode.TripLayerDataMode)
            End With
        End With
        Me.Tag = ""
        SetControlValue()
        SetGroupBoxVisible()
    End Sub

    Private Sub rbTripGraphBlanc_CheckedChanged(sender As Object, e As EventArgs) Handles rbTripGraphBlanc.CheckedChanged,
        rbTripGraphDefinitionLayer.CheckedChanged, rbTripGraphTripLayer.CheckedChanged

        If Me.Tag = "OFF" Then
            Return
        End If
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            With .DataSet(.SelectedIndex)
                Select Case True
                    Case rbTripGraphBlanc.Checked
                        .Mode = clsAttrData.enmTripMode.Blanc
                    Case rbTripGraphDefinitionLayer.Checked
                        .Mode = clsAttrData.enmTripMode.TripDefinitionLayerDataMode
                    Case rbTripGraphTripLayer.Checked
                        .Mode = clsAttrData.enmTripMode.TripLayerDataMode
                End Select
            End With
            SetGroupBoxVisible()
        End With
    End Sub
    Private Sub SetGroupBoxVisible()
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            Dim f1 As Boolean = False
            Dim f2 As Boolean = False
            With .DataSet(.SelectedIndex)
                Select Case .Mode
                    Case clsAttrData.enmTripMode.Blanc
                        gbTripLayerDataMode.Visible = False
                        gbTripDefinitionLayerDataMode.Visible = False
                    Case clsAttrData.enmTripMode.TripDefinitionLayerDataMode
                        gbTripLayerDataMode.Visible = False
                        gbTripDefinitionLayerDataMode.Visible = True
                    Case clsAttrData.enmTripMode.TripLayerDataMode
                        gbTripLayerDataMode.Visible = True
                        gbTripDefinitionLayerDataMode.Visible = False
                End Select
            End With
        End With

    End Sub
    Private Sub SetControlValue()
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            With .DataSet(.SelectedIndex)
                cboStayData.SelectedIndex = .Stay_Data
                cboTripData.SelectedIndex = .Move_Data
                cboZData.SelectedIndex = .ZData
                If Trip_Definition_Layer_Number <> -1 Then
                    cboTripDefinitionData.SelectedIndex = .Definition_Layer_Data
                    If .Definition_Layer_Data_Mode = clsAttrData.enmTripDrawType.PaintMode Then
                        rbTripDefinitionDataPaint.Checked = True
                    Else
                        rbTripDefinitionDataOD.Checked = True
                    End If
                End If
                If .Stay_Data_Mode = clsAttrData.enmTripDrawType.PaintMode Then
                    rbStayDataPaint.Checked = True
                Else
                    rbStayDataOD.Checked = True
                End If
                If .Move_Data_Mode = clsAttrData.enmTripDrawType.PaintMode Then
                    rbTripDataPaint.Checked = True
                Else
                    rbTripDataOD.Checked = True
                End If
            End With
        End With
    End Sub

    Private Sub cboStayData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStayData.SelectedIndexChanged

        If Me.Tag = "OFF" Then
            Return
        End If
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            With .DataSet(.SelectedIndex)
                .Stay_Data = cboStayData.SelectedIndex
            End With
        End With
    End Sub

    Private Sub cboTripData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTripData.SelectedIndexChanged

        If Me.Tag = "OFF" Then
            Return
        End If
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            With .DataSet(.SelectedIndex)
                .Move_Data = cboTripData.SelectedIndex
            End With
        End With

    End Sub

    Private Sub cboTripDefinitionData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTripDefinitionData.SelectedIndexChanged

        If Me.Tag = "OFF" Then
            Return
        End If
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            With .DataSet(.SelectedIndex)
                .Definition_Layer_Data = cboTripDefinitionData.SelectedIndex
            End With
        End With
    End Sub

    Private Sub rbStayDataPaint_CheckedChanged(sender As Object, e As EventArgs) Handles rbStayDataPaint.CheckedChanged, rbStayDataOD.CheckedChanged
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            With .DataSet(.SelectedIndex)
                If rbStayDataPaint.Checked = True Then
                    .Stay_Data_Mode = clsAttrData.enmTripDrawType.PaintMode
                Else
                    .Stay_Data_Mode = clsAttrData.enmTripDrawType.OdMode
                End If
            End With
        End With
    End Sub

    Private Sub rbTripDataPaint_CheckedChanged(sender As Object, e As EventArgs) Handles rbTripDataPaint.CheckedChanged, rbTripDataOD.CheckedChanged
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            With .DataSet(.SelectedIndex)
                If rbTripDataPaint.Checked = True Then
                    .Move_Data_Mode = clsAttrData.enmTripDrawType.PaintMode
                Else
                    .Move_Data_Mode = clsAttrData.enmTripDrawType.OdMode
                End If
            End With
        End With
    End Sub

    Private Sub rbTripDefinitionDataPaint_CheckedChanged(sender As Object, e As EventArgs) Handles rbTripDefinitionDataPaint.CheckedChanged, rbTripDefinitionDataOD.CheckedChanged
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            With .DataSet(.SelectedIndex)
                If rbTripDefinitionDataPaint.Checked = True Then
                    .Definition_Layer_Data_Mode = clsAttrData.enmTripDrawType.PaintMode
                Else
                    .Definition_Layer_Data_Mode = clsAttrData.enmTripDrawType.OdMode
                End If
            End With
        End With
    End Sub

    Private Sub DateTimePickerStart_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerStart.ValueChanged
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            With .DataSet(.SelectedIndex)
                .StartTime = DateTimePickerStart.Value
            End With
        End With
        CType(Me.Owner, frmMain).Check_Print_err()
    End Sub

    Private Sub DateTimePickerEnd_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerEnd.ValueChanged
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            With .DataSet(.SelectedIndex)
                .EndTime = DateTimePickerEnd.Value
            End With
        End With
        CType(Me.Owner, frmMain).Check_Print_err()
    End Sub

    Private Sub txtDataSetTitle_LostFocus(sender As Object, e As EventArgs) Handles txtDataSetTitle.LostFocus

        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            Dim i As Integer = .SelectedIndex
            With .DataSet(i)
                If .title <> txtDataSetTitle.Text Then
                    .title = txtDataSetTitle.Text
                    cboTripDataSet.Items(i) = .title
                End If
            End With
        End With
    End Sub

    Private Sub btnAddDataSet_Click(sender As Object, e As EventArgs) Handles btnAddDataSet.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            Dim Min As DateTime = attData.LayerData(LayerNum).TripTimeSpan.StartTime
            Dim Max As DateTime = attData.LayerData(LayerNum).TripTimeSpan.EndTime

            Dim i As Integer = .Count
            .AddDataSet(Min, Max)
            cboTripDataSet.Items.Add("データセット" + (i + 1).ToString)
            Me.Tag = "OFF"
            cboTripDataSet.SelectedIndex = i
            Me.Tag = ""
        End With
    End Sub

    Private Sub btnDefaultDuration_Click(sender As Object, e As EventArgs) Handles btnDefaultDuration.Click
        DateTimePickerStart.Value = attData.LayerData(LayerNum).TripTimeSpan.StartTime
        DateTimePickerEnd.Value = attData.LayerData(LayerNum).TripTimeSpan.EndTime
    End Sub

    Private Sub btnDeleteDataSet_Click(sender As Object, e As EventArgs) Handles btnDeleteDataSet.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            If .Count = 1 Then
                MsgBox("これ以上削除できません。", MsgBoxStyle.Exclamation)
                Return
            Else
                .RemoveDataSet(.SelectedIndex)
                .SelectedIndex = Math.Min(.SelectedIndex, .Count - 1)
                AddDataSetToCboBox()
            End If
        End With
    End Sub

    Private Sub cboZData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboZData.SelectedIndexChanged

        If Me.Tag = "OFF" Then
            Return
        End If
        With attData.LayerData(LayerNum).LayerModeViewSettings.TripMode
            With .DataSet(.SelectedIndex)
                .ZData = cboZData.SelectedIndex
            End With
        End With
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "tripMode")
    End Sub

    Private Sub btnOption_Click(sender As Object, e As EventArgs) Handles btnOption.Click
        With attData.TotalData.ViewStyle
            Dim form As New frmPrint_Option
            Dim oldAccessory_Base As enmBasePosition = .ScrData.Accessory_Base
            If form.ShowDialog(attData, 5) = Windows.Forms.DialogResult.OK Then
                attData.TotalData.ViewStyle = form.getResult()
                If .ScrData.Accessory_Base = enmBasePosition.Screen Then
                    If oldAccessory_Base = enmBasePosition.Map Then
                        attData.Change_Acc_Position_by_Accessory_Base_Set_Screen()
                    End If
                Else
                    If oldAccessory_Base = enmBasePosition.Screen Then
                        .AttMapCompass.Position = attData.SetMapFile("").Map.MapCompass.Position
                        attData.Set_Acc_First_Position()
                        .ScrData.ScrView = .ScrData.MapRectangle
                    End If
                End If
            End If
            form.Dispose()
        End With

    End Sub
End Class