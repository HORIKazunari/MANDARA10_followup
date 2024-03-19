Public Class frmMain_MarkViewSettings
    Dim attData As clsAttrData
    Dim MarkMode As enmSoloMode_Number
    Dim LayerNum As Integer
    Dim DataNum As Integer
    Dim LayerShape As enmShape
    Dim DDType As enmAttDataType
    ''' <summary>
    ''' データ項目の階級区分モードの初期値をコントロールに設定
    ''' </summary>
    ''' <param name="_attData"></param>
    ''' <remarks></remarks>
    Public Sub SetData(ByRef _attData As clsAttrData)
        Me.Tag = "OFF"
        attData = _attData
        LayerNum = attData.TotalData.LV1.SelectedLayer
        DataNum = attData.LayerData(LayerNum).atrData.SelectedIndex
        LayerShape = attData.LayerData(LayerNum).Shape
        MarkMode = attData.LayerData(LayerNum).atrData.Data(DataNum).ModeData
        DDType = attData.LayerData(LayerNum).atrData.Data(DataNum).DataType
        Dim MinusF As Boolean = (attData.LayerData(LayerNum).atrData.Data(DataNum).Statistics.Min < 0)
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            If MinusF = True And (MarkMode = enmSoloMode_Number.MarkSizeMode Or MarkMode = enmSoloMode_Number.MarkBlockMode) Then
                gbMinusData.Visible = True
                Select Case LayerShape
                    Case enmShape.LineShape
                        picMinus.BackColor = .MarkCommon.MinusLineColor.getColor
                    Case Else
                        attData.Draw_Sample_TileBox(picMinus, .MarkCommon.MinusTile)
                End Select
                txtPlusValue.Text = .MarkCommon.LegendPlusWord
                txtMinusValue.Text = .MarkCommon.LegendMinusWord
            Else
                gbMinusData.Visible = False
            End If

            pnlMarkSize.Visible = False
            pnlMarkBlock.Visible = False
            pnlMarkTurn.Visible = False
            pnlMarkBar.Visible = False
            pnlString.Visible = False
            gbLineShape.Visible = False
            gbLineShape.Visible = False
            gbMarkSize.Visible = True
            gbLineShape.Visible = False
            gbMarkSet.Visible = True
            btnInnerData.Top = gbMarkSet.Top + gbMarkSet.Height + 10
            Select Case MarkMode
                Case enmSoloMode_Number.MarkSizeMode
                    Me.Text = "記号の大きさモード"
                    pnlMarkSize.Visible = True
                    With .MarkSizeMD
                        txtMarkSizeLegend0.Text = .Value(0)
                        txtMarkSizeLegend1.Text = .Value(1)
                        txtMarkSizeLegend2.Text = .Value(2)
                        txtMarkSizeLegend3.Text = .Value(3)
                        txtMarkSizeLegend4.Text = .Value(4)
                        txtMarkSizeMaxValue.Text = .MaxValue
                        If .MaxValueMode = clsAttrData.enmMarkSizeValueMode.inDataItem Then
                            rbMarkSize_inDataItem.Checked = True
                            txtMarkSizeMaxValue.Enabled = False
                        Else
                            rbMarkSize_UserSetting.Checked = True
                            txtMarkSizeMaxValue.Enabled = True
                        End If
                        If LayerShape = enmShape.LineShape Then
                            gbLineShape.Visible = True
                            With .LineShape
                                cboLineShapeSize.Text = .LineWidth
                                picLineShapeColor.BackColor = .Color.getColor
                            End With
                        Else
                            attData.Draw_Sample_Mark_Box(picMark, .Mark)
                        End If
                    End With
                Case enmSoloMode_Number.MarkBlockMode
                    Me.Text = "記号の数モード"
                    If LayerShape = enmShape.PolygonShape Then
                        rbRandamArrange.Enabled = True
                    Else
                        rbRandamArrange.Enabled = False
                    End If
                    pnlMarkBlock.Visible = True
                    With .MarkBlockMD
                        Select Case .ArrangeB
                            Case clsAttrData.enmMarkBlockArrange.Block
                                rbBlockArrange.Checked = True
                            Case clsAttrData.enmMarkBlockArrange.PolygonRandom
                                rbRandamArrange.Checked = True
                            Case clsAttrData.enmMarkBlockArrange.Vertical
                                rbVerticalArrange.Checked = True
                            Case clsAttrData.enmMarkBlockArrange.Horizontal
                                rbHorizontalArrange.Checked = True
                        End Select
                        txtBlockValue.Text = .Value
                        chkBlockHasu.Checked = .HasuVisible
                        cboBlockOverlap.SelectedIndex = .Overlap
                        attData.Draw_Sample_Mark_Box(picMark, .Mark)
                    End With
                Case enmSoloMode_Number.MarkTurnMode
                    Me.Text = "記号の回転モード"
                    pnlMarkTurn.Visible = True
                    With .MarkTurnMD
                        If .Dirction = clsAttrData.enmMarkTurnDirection.AntiClockwise Then
                            rbAnticlockwise.Checked = True
                        Else
                            rbClockwise.Checked = True
                        End If
                        txtOneTurnValue.Text = .DegreeLap
                        attData.Draw_Sample_Mark_Box(picMark, .Mark)
                    End With
                Case enmSoloMode_Number.MarkBarMode
                    Me.Text = "棒の高さモード"
                    pnlMarkBar.Visible = True
                    gbMarkSet.Visible = False
                    btnInnerData.Top = pnlMarkBar.Top + pnlMarkBar.Height + 10
                    With .MarkBarMD
                        cboMarkBarMaxHeight.Text = .MaxHeight
                        cboMarkBarWidth.Text = .Width
                        If .MaxValueMode = clsAttrData.enmMarkSizeValueMode.inDataItem Then
                            rbMarkBar_inDataItem.Checked = True
                            txtMarkBarMaxValue.Enabled = False
                        Else
                            rbMarkBar_UserSetting.Checked = True
                            txtMarkBarMaxValue.Enabled = True
                        End If
                        txtMarkBarMaxValue.Text = .MaxValue
                        attData.Draw_Sample_TileBox(picMarkBarInnerColor, .InnerTile)
                        attData.Draw_Sample_LineBox(picMarkBarFrameLinePat, .FrameLinePat)
                        cbScaleLineVisible.Checked = .ScaleLineVisible
                        txtScaleLineInterval.Text = .ScaleLineInterval
                        attData.Draw_Sample_LineBox(picScaleLine, .scaleLinePat)
                        chkMarkBarThreeD.Checked = .ThreeD
                        If .BarShape = clsAttrData.MarkBarShape.bar Then
                            rbBarShapeBar.Checked = True
                            gbBarShapeBarSetting.Enabled = True
                        Else
                            rbBarShapeTriangle.Checked = True
                            gbBarShapeBarSetting.Enabled = False
                        End If
                    End With
                Case enmSoloMode_Number.StringMode
                    Me.Text = "文字モード"
                    pnlString.Visible = True
                    gbMarkSet.Visible = False
                    btnInnerData.Top = pnlString.Top + pnlString.Height + 10
                    cboMaxWidthReturn.Checked = .StringMD.WordTurnF
                    txtMaxWidth.Text = .StringMD.maxWidth
            End Select
        End With
        Me.Tag = ""
    End Sub

    Private Sub frmMain_MarkViewSettings_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim frm As frmMain
            frm = CType(Me.Owner, frmMain)
            frm.btnDraw.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub



    Private Sub frmMain_MarkViewSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Tag = "OFF"
        With cboBlockOverlap.Items
            .Clear()
            .Add("少し離す")
            .Add("ぴったり")
            .Add("1/4重ねる")
            .Add("1/2重ねる")
            .Add("3/4重ねる")
        End With
        With cboLineShapeSize.Items
            .Clear()
            For si As Single = 0.5 To 5 Step 0.5
                .Add(si)
            Next
            For i As Integer = 6 To 20
                .Add(i)
            Next
        End With

        With cboMarkBarMaxHeight.Items
            .Clear()
            For si As Single = 0.5 To 5 Step 0.5
                .Add(si)
            Next
            For i As Integer = 6 To 20
                .Add(i)
            Next
        End With

        With cboMarkBarWidth.Items
            .Clear()
            For si As Single = 0.5 To 5 Step 0.5
                .Add(si)
            Next
            For i As Integer = 6 To 20
                .Add(i)
            Next
        End With
        pnlMarkTurn.Location = pnlMarkSize.Location
        pnlMarkBlock.Location = pnlMarkSize.Location
        gbLineShape.Location = gbMarkSet.Location
        pnlMarkBar.Location = gbMarkSet.Location
        pnlString.Location = gbMarkSet.Location
        Me.Width = pnlMarkSize.Left + pnlMarkSize.Width + 20
        Me.Tag = ""
    End Sub

    Private Sub picMark_Click(sender As Object, e As EventArgs) Handles picMark.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            Dim mk As Mark_Property
            Select Case MarkMode
                Case enmSoloMode_Number.MarkSizeMode
                    mk = .MarkSizeMD.Mark
                Case enmSoloMode_Number.MarkBlockMode
                    mk = .MarkBlockMD.Mark
                Case enmSoloMode_Number.MarkTurnMode
                    mk = .MarkTurnMD.Mark
            End Select
            If clsGeneric.Mark_Set(mk, attData) = True Then
                attData.Draw_Sample_Mark_Box(picMark, mk)
                Select Case MarkMode
                    Case enmSoloMode_Number.MarkSizeMode
                        .MarkSizeMD.Mark = mk
                    Case enmSoloMode_Number.MarkBlockMode
                        .MarkBlockMD.Mark = mk
                    Case enmSoloMode_Number.MarkTurnMode
                        .MarkTurnMD.Mark = mk
                End Select
            End If

        End With

    End Sub

    Private Sub picMinusTile_Click(sender As Object, e As EventArgs) Handles picMinus.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon
            Select Case LayerShape
                Case enmShape.LineShape
                    attData.Select_Color(picMinus, .MinusLineColor)
                Case Else
                    attData.Select_Tile(picMinus, .MinusTile)
            End Select
        End With

    End Sub

    Private Sub picLineShapeColor_Click(sender As Object, e As EventArgs) Handles picLineShapeColor.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD.LineShape
            attData.Select_Color(picLineShapeColor, .Color)
        End With
    End Sub

    Private Sub picLineShapeMinusColor_Click(sender As Object, e As EventArgs)
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon
            attData.Select_Color(picLineShapeColor, .MinusLineColor)
        End With
    End Sub

    Private Sub btnLineShapeEdgePattern_Click(sender As Object, e As EventArgs) Handles btnLineShapeEdgePattern.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD.LineShape
            clsGeneric.LineEdgePattern_Set(.LineEdge)

        End With

    End Sub

    Private Sub rbMarkSize_inDataItem_CheckedChanged(sender As Object, e As EventArgs) Handles rbMarkSize_inDataItem.CheckedChanged, rbMarkSize_UserSetting.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD
            If rbMarkSize_inDataItem.Checked = True Then
                .MaxValueMode = clsAttrData.enmMarkSizeValueMode.inDataItem
                txtMarkSizeMaxValue.Enabled = False
            Else
                .MaxValueMode = clsAttrData.enmMarkSizeValueMode.UserDefinition
                txtMarkSizeMaxValue.Enabled = True
            End If
        End With
    End Sub

    Private Sub rbBlockArrange_CheckedChanged(sender As Object, e As EventArgs) Handles rbVerticalArrange.CheckedChanged, rbHorizontalArrange.CheckedChanged, rbBlockArrange.CheckedChanged, rbRandamArrange.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBlockMD
            Select Case True
                Case rbBlockArrange.Checked
                    .ArrangeB = clsAttrData.enmMarkBlockArrange.Block
                Case rbRandamArrange.Checked
                    .ArrangeB = clsAttrData.enmMarkBlockArrange.PolygonRandom
                Case rbVerticalArrange.Checked
                    .ArrangeB = clsAttrData.enmMarkBlockArrange.Vertical
                Case rbHorizontalArrange.Checked
                    .ArrangeB = clsAttrData.enmMarkBlockArrange.Horizontal
            End Select
        End With
    End Sub

    Private Sub chkBlockHasu_CheckedChanged(sender As Object, e As EventArgs) Handles chkBlockHasu.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBlockMD.HasuVisible = chkBlockHasu.Checked
    End Sub

    Private Sub cboBlockOverlap_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBlockOverlap.SelectedIndexChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBlockMD.Overlap = cboBlockOverlap.SelectedIndex
    End Sub

    Private Sub rbAnticlockwise_CheckedChanged(sender As Object, e As EventArgs) Handles rbAnticlockwise.CheckedChanged, rbClockwise.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        If rbAnticlockwise.Checked = True Then
            attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkTurnMD.Dirction = clsAttrData.enmMarkTurnDirection.AntiClockwise
        Else
            attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkTurnMD.Dirction = clsAttrData.enmMarkTurnDirection.Clockwise
        End If

    End Sub

    Private Sub txtMarkSizeLegend0_LostFocus(sender As Object, e As EventArgs) Handles txtMarkSizeLegend0.LostFocus,
                        txtMarkSizeLegend1.LostFocus, txtMarkSizeLegend2.LostFocus, txtMarkSizeLegend3.LostFocus, txtMarkSizeLegend4.LostFocus
        Dim v As Integer = Val(sender.tag)
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD
            .Value(v) = Val(sender.text)
            sender.text = .Value(v)
        End With

    End Sub

    Private Sub txtMarkSizeMaxValue_LostFocus(sender As Object, e As EventArgs) Handles txtMarkSizeMaxValue.LostFocus
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD
            .MaxValue = Val(txtMarkSizeMaxValue.Text)
            txtMarkSizeMaxValue.Text = .MaxValue
        End With
    End Sub

    Private Sub txtBlockValue_TextChanged(sender As Object, e As EventArgs) Handles txtBlockValue.LostFocus
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBlockMD
            .Value = Math.Abs(Val(txtBlockValue.Text))
            txtBlockValue.Text = .Value
        End With
    End Sub

    Private Sub txtOneTurnValue_TextChanged(sender As Object, e As EventArgs) Handles txtOneTurnValue.LostFocus
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkTurnMD
            .DegreeLap = Val(txtOneTurnValue.Text)
            txtOneTurnValue.Text = .DegreeLap
        End With
    End Sub

    Private Sub cboLineShapeSize_LostFocus(sender As Object, e As EventArgs) Handles cboLineShapeSize.LostFocus
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD.LineShape
            .LineWidth = Val(cboLineShapeSize.Text)
        End With
    End Sub

    Private Sub btnInnerData_Click(sender As Object, e As EventArgs) Handles btnInnerData.Click

        Dim form As New frmInnerData
        If form.ShowDialog(Me, attData) = Windows.Forms.DialogResult.OK Then
            attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon.Inner_Data = form.getResults
        End If
        form.Dispose()

    End Sub


    Private Sub txtPlusValue_TextChanged(sender As Object, e As EventArgs) Handles txtPlusValue.LostFocus
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon
            .LegendPlusWord = txtPlusValue.Text
        End With
    End Sub

    Private Sub txtMinusValue_TextChanged(sender As Object, e As EventArgs) Handles txtMinusValue.LostFocus
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon
            .LegendMinusWord = txtMinusValue.Text
        End With
    End Sub

    Private Sub txtBlockLegendWord_TextChanged(sender As Object, e As EventArgs) Handles txtBlockLegendWord.LostFocus
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBlockMD
            .LegendBlockModeWord = txtBlockLegendWord.Text
        End With
    End Sub


    Private Sub txtMarkBarMaxValue_LostFocus(sender As Object, e As EventArgs) Handles txtMarkBarMaxValue.LostFocus
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
            .MaxValue = Val(txtMarkBarMaxValue.Text)
            txtMarkBarMaxValue.Text = .MaxValue
        End With
    End Sub

    Private Sub picMarkBarInnerColor_Click(sender As Object, e As EventArgs) Handles picMarkBarInnerColor.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
            attData.Select_Tile(picMarkBarInnerColor, .InnerTile)
        End With
    End Sub

    Private Sub rbMarkBar_inDataItem_CheckedChanged(sender As Object, e As EventArgs) Handles rbMarkBar_inDataItem.CheckedChanged, rbMarkBar_UserSetting.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
            If rbMarkBar_inDataItem.Checked = True Then
                .MaxValueMode = clsAttrData.enmMarkSizeValueMode.inDataItem
                txtMarkBarMaxValue.Enabled = False
            Else
                .MaxValueMode = clsAttrData.enmMarkSizeValueMode.UserDefinition
                txtMarkBarMaxValue.Enabled = True
            End If
        End With
    End Sub

    Private Sub picMarkBarFrameLinePat_Click(sender As Object, e As EventArgs) Handles picMarkBarFrameLinePat.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
            attData.Select_Line_Pattern(picMarkBarFrameLinePat, .FrameLinePat, True)
        End With
    End Sub

    Private Sub cboMarkBarMaxHeight_LostFocus(sender As Object, e As EventArgs) Handles cboMarkBarMaxHeight.LostFocus
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
            .MaxHeight = Val(cboMarkBarMaxHeight.Text)
        End With
    End Sub

    Private Sub cboMarkBarWidth_LostFocus(sender As Object, e As EventArgs) Handles cboMarkBarWidth.LostFocus
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
            .Width = Val(cboMarkBarWidth.Text)
        End With
    End Sub
    Private Sub txtScaleLineInterval_LostFocus(sender As Object, e As EventArgs) Handles txtScaleLineInterval.LostFocus
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
            .ScaleLineInterval = Val(txtScaleLineInterval.Text)
            txtScaleLineInterval.Text = .ScaleLineInterval
        End With
    End Sub

    Private Sub picScaleLine_Click(sender As Object, e As EventArgs) Handles picScaleLine.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
            attData.Select_Line_Pattern(picScaleLine, .scaleLinePat, True)
        End With
    End Sub

    Private Sub cbScaleLineVisible_CheckedChanged(sender As Object, e As EventArgs) Handles cbScaleLineVisible.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD.ScaleLineVisible = cbScaleLineVisible.Checked
    End Sub



    Private Sub chkMarkBarThreeD_CheckedChanged(sender As Object, e As EventArgs) Handles chkMarkBarThreeD.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
            .ThreeD = chkMarkBarThreeD.Checked
        End With
    End Sub

    Private Sub txtMaxWidth_TextChanged(sender As Object, e As EventArgs) Handles txtMaxWidth.LostFocus
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.StringMD
            .maxWidth = Val(txtMaxWidth.Text)
            txtMaxWidth.Text = .maxWidth
        End With
    End Sub

    Private Sub cboMaxWidthReturn_CheckedChanged(sender As Object, e As EventArgs) Handles cboMaxWidthReturn.CheckedChanged
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.StringMD
            .WordTurnF = cboMaxWidthReturn.Checked
        End With
    End Sub

    Private Sub btnObjectNameFont_Click(sender As Object, e As EventArgs) Handles btnObjectNameFont.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.StringMD
            attData.Select_Font(.Font)
        End With
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Dim tx As String = ""
        Select Case MarkMode
            Case enmSoloMode_Number.MarkSizeMode
                tx = "markSizeMode"
            Case enmSoloMode_Number.MarkBlockMode
                tx = "markBlockMode"
            Case enmSoloMode_Number.MarkTurnMode
                tx = "markTurnMode"
            Case enmSoloMode_Number.MarkBarMode
                tx = "barMode"
            Case enmSoloMode_Number.StringMode
                tx = "stringMode"
        End Select
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, tx)
    End Sub

 

    Private Sub rbBarShapeBar_CheckedChanged(sender As Object, e As EventArgs) Handles rbBarShapeBar.CheckedChanged, rbBarShapeTriangle.CheckedChanged
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
            If rbBarShapeBar.Checked = True Then
                .BarShape = clsAttrData.MarkBarShape.bar
                gbBarShapeBarSetting.Enabled = True
            Else
                .BarShape = clsAttrData.MarkBarShape.triangle
                gbBarShapeBarSetting.Enabled = False
            End If
        End With
    End Sub
End Class