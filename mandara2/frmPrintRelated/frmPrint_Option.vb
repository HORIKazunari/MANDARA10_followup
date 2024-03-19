Public Class frmPrint_Option
    Dim CloseCancelF As Boolean
    Dim ViewStyle As clsAttrData.strViewStyle_Info
    Dim attrData As clsAttrData
    Dim TileLicenceFont As Font_Property
    Private Sub frmPrint_Option_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData, ByRef tabIndex As Integer) As Windows.Forms.DialogResult
        With clbAccGroupBoxItem
            .Items.Clear()
            .Items.Add("凡例")
            .Items.Add("タイトル")
            .Items.Add("方位")
            .Items.Add("スケール")
            .Items.Add("注")
            .Items.Add("線種凡例")
            .Items.Add("オブジェクトグループ凡例")
        End With
        attrData = _attrData
        ViewStyle = attrData.TotalData.ViewStyle
        TileLicenceFont = ViewStyle.TileLicenceFont
        tabAll.SelectedIndex = tabIndex
        tabAll.SizeMode = TabSizeMode.Fixed
        tabAll.ItemSize = New Size(tabAll.Width \ tabAll.TabCount - 5, 21)
        tbLegend.SizeMode = TabSizeMode.Fixed
        tbLegend.ItemSize = New Size(tbLegend.Width \ tbLegend.TabCount - 5, 21)

        With ViewStyle
            '全般タブ－－－－－－－－－－－－－－－－－－－－－－－－－
            If .ScrData.Accessory_Base = enmBasePosition.Screen Then
                rbAccBaseOnScreen.Checked = True
            Else
                rbAccBaseOnMap.Checked = True
            End If
            Select Case .PointPaint_Order
                Case clsAttrData.enmPointOnjectDrawOrder.ObjectOrder
                    rbPointPaintOrder_byObjectOrder.Checked = True
                Case clsAttrData.enmPointOnjectDrawOrder.LowerToUpperCategory
                    rbPointPaintOrder_fromBottomCategory.Checked = True
                Case clsAttrData.enmPointOnjectDrawOrder.UpperToLowerCategory
                    rbPointPaintOrder_fromTopCategory.Checked = True
            End Select
            chkMapShow.Checked = .MapPrint_Flag
            chkTitleVisible.Checked = .MapTitle.Visible
            chkNoteVisible.Checked = .DataNote.Visible
            txtTitleMaxWidth.Text = .MapTitle.MaxWidth
            txtNoteMaxWidth.Text = .DataNote.MaxWidth
            chkCompassVisible.Checked = .AttMapCompass.Visible
            chkFigureVisible.Checked = .FigureVisible
            chkSymbolLine.Checked = .SymbolLine.Visible
            clsDrawLine.Draw_Sample_LineBox(picSymbolLine, ViewStyle.SymbolLine.Line, ViewStyle.ScrData, attrData.TotalData.BasePicture)
            With .AccessoryGroupBox
                chkAccGroupBox.Checked = .Visible
                clbAccGroupBoxItem.SetItemChecked(0, .Legend)
                clbAccGroupBoxItem.SetItemChecked(1, .Title)
                clbAccGroupBoxItem.SetItemChecked(2, .Comapss)
                clbAccGroupBoxItem.SetItemChecked(3, .Scale)
                clbAccGroupBoxItem.SetItemChecked(4, .Note)
                clbAccGroupBoxItem.SetItemChecked(5, .LinePattern)
                clbAccGroupBoxItem.SetItemChecked(6, .ObjectGroup)
                clsDrawTile.Darw_Sample_BackGroundBox(picAccGroupBoxBack, .Back, ViewStyle.ScrData, attrData.TotalData.BasePicture)
            End With
            chkObjSpline.Checked = .SouByou.Spline_F
            chkSoubyouAuto.Checked = .SouByou.Auto
            cboSoubyouAutoDegree.SelectedIndex = .SouByou.AutoDegree - 1
            With cboMinimumLineWidth
                .Items.Clear()
                .Items.Add("0ピクセル")
                .Items.Add("1ピクセル")
                .Items.Add("0.05％")
                .Items.Add("0.075％")
                .Items.Add("0.1％")
                .SelectedIndex = clsSettings.Data.MinimumLineWidth
            End With
            With cboMaxAutoDrawTime
                .Items.Clear()
                For i As Integer = 1 To 5
                    .Items.Add(i.ToString)
                Next
                .Text = clsSettings.Data.Printing_Time_Limit
            End With

            '背景タブ－－－－－－－－－－－－
            With .ScrData.Screen_Margin
                txtUpperMargin.Text = .Top
                txtBottomMargin.Text = .Bottom
                txtLeftMargin.Text = .Left
                txtRightMargin.Text = .Right
                chkMarginClip.Checked = .ClipF
            End With
            With .Screen_Back
                clsDrawLine.Draw_Sample_LineBox(picMapFrameLine, .MapAreaFrameLine, ViewStyle.ScrData, attrData.TotalData.BasePicture)
                clsDrawLine.Draw_Sample_LineBox(picScreenFrameLine, .ScreenFrameLine, ViewStyle.ScrData, attrData.TotalData.BasePicture)
                clsDrawTile.Draw_Sample_TileBox(picMapAreaTile, .MapAreaBack, ViewStyle.ScrData, attrData.TotalData.BasePicture)
                clsDrawTile.Draw_Sample_TileBox(picScreenAreaTile, .ScreenAreaBack, ViewStyle.ScrData, attrData.TotalData.BasePicture)
                clsDrawTile.Draw_Sample_TileBox(picObjectInnerTile, .ObjectInner, ViewStyle.ScrData, attrData.TotalData.BasePicture)
            End With
            If attrData.TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                gbLatLonLine.Enabled = True
                With .LatLonLine_Print
                    chkLatLonPrint.Checked = .Visible
                    Dim PStr As strPointStrings = clsGeneric.Get_LatLon_Strings(New strLatLon(.Lat_Interval, .Lon_Interval), False)
                    lblLatLineInterval.Text = PStr.y
                    lblLonLineInterval.Text = PStr.x
                    If .Order = clsAttrData.enmLatLonLine_Order.Back Then
                        rbLatLonLineBack.Checked = True
                    Else
                        rbLatLonLineFront.Checked = True
                    End If
                    clsDrawLine.Draw_Sample_LineBox(picLatLonLine, .LPat, ViewStyle.ScrData, attrData.TotalData.BasePicture)
                    clsDrawLine.Draw_Sample_LineBox(picLatLonOuterLine, .OuterPat, ViewStyle.ScrData, attrData.TotalData.BasePicture)
                    clsDrawLine.Draw_Sample_LineBox(picLatLonEqLine, .Equator, ViewStyle.ScrData, attrData.TotalData.BasePicture)
                End With
            Else
                gbLatLonLine.Enabled = False
            End If


            '凡例設定タブ－－－－－－－－－－－－
            With .MapLegend
                chkLegendVisible.Checked = .Base.Visible
                chkLegendComma.Checked = .Base.Comma_f
                chkModeValueInScreenFlag.Checked = .Base.ModeValueInScreenFlag
                '凡例の背景・フォント
                clsDrawTile.Darw_Sample_BackGroundBox(picLegendBack, .Base.Back, ViewStyle.ScrData, attrData.TotalData.BasePicture)
                chkOverlayTitleVisible.Checked = .OverLay_Legend_Title.Print_f
                txtOverlayTitleWidth.Text = .OverLay_Legend_Title.MaxWidth
                '階級区分
                With cboClassPaintWidth
                    .Items.Clear()
                    .Items.AddRange({"0.8", "1.0", "1.2", "1.5", "2.0"})
                End With
                With cboSeparateGapSize
                    .Items.Clear()
                    .Items.AddRange({"0.1", "0.2", "0.3", "0.4"})
                End With
                With .ClassMD
                    clsDrawLine.Draw_Sample_LineBox(picPaintFrame, .PaintMode_Line, ViewStyle.ScrData, attrData.TotalData.BasePicture)
                    If .PaintMode_Method = enmClassMode_Meshod.Noral Then
                        rbPaintLegend_Normal.Checked = True
                    Else
                        rbPaintLegend_Separated.Checked = True
                    End If
                    If .SeparateClassWords = enmSeparateClassWords.Japanese Then
                        rbSeparateClassWords_Japanese.Checked = True
                    Else
                        rbSeparateClassWords_English.Checked = True
                    End If
                    cbCategorySeparated.Checked = .CategorySeparate_f
                    cboClassPaintWidth.Text = .PaintMode_Width
                    cboSeparateGapSize.Text = .SeparateGapSize
                    chkClassMarkFrame.Checked = .ClassMarkFrame_Visible
                    chkClassBoundary.Checked = .ClassBoundaryLine.Visible
                    clsDrawLine.Draw_Sample_LineBox(picClassBoundary, .ClassBoundaryLine.LPat, ViewStyle.ScrData, attrData.TotalData.BasePicture)
                    chkFreq.Checked = .FrequencyPrint
                End With
                '記号・円グラフ
                With .MarkMD
                    chkMark_Circle_Mini.Checked = .CircleMD_CircleMini_F
                    attrData.Draw_Sample_LineBox(picMultiEnLine, .MultiEnMode_Line)
                End With
                If .En_Graph_Pattern = enmMultiEnGraphPattern.multiCircle Then
                    rbMuliFan.Checked = True
                Else
                    rbOneCircle.Checked = True
                End If
                With clsSettings.Data
                    txtBlockLegendWord.Text = .LegendBlockmodeWord
                    txtMinusValue.Text = .LegendMinusWord
                    txtPlusValue.Text = .LegendPlusWord
                End With
                '線種・点ダミーの表示
                With .Line_DummyKind
                    chkLineKindLegend.Checked = .Line_Visible
                    chkPointDummy.Checked = .Dummy_Point_Visible
                    attrData.Draw_Sample_BackgroundBox(picLineKindLegendBack, .Back)
                    If .Line_Pattern = clsAttrData.enmCircleMDLegendLine.Zigzag Then
                        rbLineKindZigzag.Checked = True
                    Else
                        rbLineKindStraight.Checked = True
                    End If
                    Dim LKName As String() = attrData.GetAllMapLineKindName()
                    With clbLineKindLegendShow
                        .Items.Clear()
                        .Items.AddRange(LKName)
                    End With
                    For i As Integer = 0 To Math.Min(Len(.Line_Visible_Number_STR), LKName.Length) - 1
                        clbLineKindLegendShow.SetItemChecked(i, Mid(.Line_Visible_Number_STR, i + 1, 1) = "1")
                    Next
                End With
            End With

            '欠損値の凡例タブ－－－－－－－－－－－－
            With .Missing_Data
                chkMissingPrintFlag.Checked = .Print_Flag
                txtMissingWord.Text = .Text
                attrData.Draw_Sample_TileBox(picClassPaintMissingValue, .PaintTile)
                attrData.Draw_Sample_TileBox(picClassHatchMissingValue, .HatchTile)
                attrData.Draw_Sample_Mark_Box(picClassMarkMissingValue, .ClassMark)
                attrData.Draw_Sample_Mark_Box(picMarkSizeMissingValue, .Mark)
                attrData.Draw_Sample_Mark_Box(picMarkBlockMissingValue, .BlockMark)
                attrData.Draw_Sample_Mark_Box(picMarkTurnMissingValue, .TurnMark)
                attrData.Draw_Sample_Mark_Box(picMarkBarMissingValue, .MarkBar)
                txtLabelModeMissingValue.Text = .Label
                attrData.Draw_Sample_LineBox(picLineShapeMissingValue, .LineShape)
            End With

            'スケールの設定タブ－－－－－－－－－－－－
            With .MapScale
                chkScaleShow.Checked = .Visible
                clsGeneric.SetScaleUnit_to_Cbobox(cboScaleUnit)
                cboScaleUnit.Text = clsGeneric.getScaleUnitStrings(.Unit)
                chkScaleBarAuto.Checked = .BarAuto
                attrData.Draw_Sample_BackgroundBox(picScaleBack, .Back)
                txtScaleBarDistance.Text = .BarDistance
                txtScaleBarKugiri.Text = .BarKugiriNum
                Select Case .BarPattern
                    Case clsAttrData.enmScaleBarPattern.Thin
                        rbScalebar1.Checked = True
                    Case clsAttrData.enmScaleBarPattern.Bold
                        rbScalebar2.Checked = True
                    Case clsAttrData.enmScaleBarPattern.Slim
                        rbScaleBar3.Checked = True
                End Select
            End With

            '移動データタブ－－－－－－－－－－－－

            With .Trip_Line
                attrData.Draw_Sample_LineBox(picTripMoveLine, .Trip_Line)
                attrData.Draw_Sample_LineBox(picTripStayLine, .Stay_Line)
                chkTripStart_End_Print.Checked = .Start_End_Print
                attrData.Draw_Sample_Mark_Box(picStartPointMark, .StartPoint_Mark)
                attrData.Draw_Sample_Mark_Box(picEndPointMark, .EndPoint_Mark)
                txtTripPathHeight.Text = .Height
                chkTripFrame.Checked = .Frame_Print
                Select Case .TimeLegend_Position
                    Case 0
                        rbTripZLegendUpperLeft.Checked = True
                    Case 1
                        rbTripZLegendUpperRight.Checked = True
                    Case 2
                        rbTripZLegendLowerRight.Checked = True
                    Case 3
                        rbTripZLegendLowerLeft.Checked = True
                    Case 4
                        rbTripZLegendNo.Checked = True
                End Select
                chkTripZeroPoint.Checked = .ZeroPointF
                chkTripZeroLine.Checked = .ZeroLineF
                chkTripVerticalLine.Checked = .VerticalLineF
                chkTripOverLap.Checked = .Overlap_Mode
                attrData.Draw_Sample_Mark_Box(picTripZeroPointMark, .ZeroPoint_Mark)
                attrData.Draw_Sample_LineBox(picTripZeroLine, .ZeroLine)
                attrData.Draw_Sample_LineBox(picTripVerticalLine, .VerticalLine)
            End With
        End With
        Return Me.ShowDialog()
    End Function
    Public Function getResult() As clsAttrData.strViewStyle_Info
        With ViewStyle
            '全般タブ－－－－－－－－－－－－－－－－－－－－－－－－－

            If rbAccBaseOnScreen.Checked = True Then
                .ScrData.Accessory_Base = enmBasePosition.Screen
            Else
                .ScrData.Accessory_Base = enmBasePosition.Map
            End If
            Select Case (True)
                Case rbPointPaintOrder_byObjectOrder.Checked
                    .PointPaint_Order = clsAttrData.enmPointOnjectDrawOrder.ObjectOrder
                Case rbPointPaintOrder_fromBottomCategory.Checked
                    .PointPaint_Order = clsAttrData.enmPointOnjectDrawOrder.LowerToUpperCategory
                Case rbPointPaintOrder_fromTopCategory.Checked
                    .PointPaint_Order = clsAttrData.enmPointOnjectDrawOrder.UpperToLowerCategory
            End Select
            .MapPrint_Flag = chkMapShow.Checked
            .MapTitle.Visible = chkTitleVisible.Checked
            .MapTitle.MaxWidth = Val(txtTitleMaxWidth.Text)
            .DataNote.Visible = chkNoteVisible.Checked
            .DataNote.MaxWidth = Val(txtNoteMaxWidth.Text)
            .AttMapCompass.Visible = chkCompassVisible.Checked
            .FigureVisible = chkFigureVisible.Checked
            .SymbolLine.Visible = chkSymbolLine.Checked
            With .AccessoryGroupBox
                .Visible = chkAccGroupBox.Checked
                .Legend = clbAccGroupBoxItem.GetItemChecked(0)
                .Title = clbAccGroupBoxItem.GetItemChecked(1)
                .Comapss = clbAccGroupBoxItem.GetItemChecked(2)
                .Scale = clbAccGroupBoxItem.GetItemChecked(3)
                .Note = clbAccGroupBoxItem.GetItemChecked(4)
                .LinePattern = clbAccGroupBoxItem.GetItemChecked(5)
                .ObjectGroup = clbAccGroupBoxItem.GetItemChecked(6)
            End With
            .SouByou.Spline_F = chkObjSpline.Checked
            .SouByou.Auto = chkSoubyouAuto.Checked
            .SouByou.AutoDegree = cboSoubyouAutoDegree.SelectedIndex + 1
            clsSettings.Data.Printing_Time_Limit = Val(cboMaxAutoDrawTime.Text)
            clsSettings.Data.MinimumLineWidth = cboMinimumLineWidth.SelectedIndex

            '背景タブ－－－－－－－－－－－－
            With .ScrData.Screen_Margin
                .Top = Val(txtUpperMargin.Text)
                .Bottom = Val(txtBottomMargin.Text)
                .Left = Val(txtLeftMargin.Text)
                .Right = Val(txtRightMargin.Text)
                .ClipF = chkMarginClip.Checked
            End With
            If ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                With .LatLonLine_Print
                    .Visible = chkLatLonPrint.Checked
                    If rbLatLonLineBack.Checked = True Then
                        .Order = clsAttrData.enmLatLonLine_Order.Back
                    Else
                        .Order = clsAttrData.enmLatLonLine_Order.Front
                    End If
                End With
            End If

            '凡例設定タブ－－－－－－－－－－－－
            With .MapLegend
                .Base.Visible = chkLegendVisible.Checked
                .Base.Comma_f = chkLegendComma.Checked
                .Base.ModeValueInScreenFlag = chkModeValueInScreenFlag.Checked
                '凡例の背景・フォント
                .OverLay_Legend_Title.Print_f = chkOverlayTitleVisible.Checked
                .OverLay_Legend_Title.MaxWidth = Val(txtOverlayTitleWidth.Text)
                '階級区分
                With .ClassMD
                    If rbPaintLegend_Normal.Checked = True Then
                        .PaintMode_Method = enmClassMode_Meshod.Noral
                    Else
                        .PaintMode_Method = enmClassMode_Meshod.Separated
                    End If
                    If rbSeparateClassWords_Japanese.Checked = True Then
                        .SeparateClassWords = enmSeparateClassWords.Japanese
                    Else
                        .SeparateClassWords = enmSeparateClassWords.English
                    End If
                    .PaintMode_Width = Val(cboClassPaintWidth.Text)
                    .SeparateGapSize = Val(cboSeparateGapSize.Text)
                    .ClassMarkFrame_Visible = chkClassMarkFrame.Checked
                    .ClassBoundaryLine.Visible = chkClassBoundary.Checked
                    .FrequencyPrint = chkFreq.Checked
                    .CategorySeparate_f = cbCategorySeparated.Checked
                End With
                '記号・円グラフ
                With .MarkMD
                    .CircleMD_CircleMini_F = chkMark_Circle_Mini.Checked
                End With
                If rbMuliFan.Checked = True Then
                    .En_Graph_Pattern = enmMultiEnGraphPattern.multiCircle
                Else
                    .En_Graph_Pattern = enmMultiEnGraphPattern.oneCircle
                End If
                With clsSettings.Data
                    .LegendBlockmodeWord = txtBlockLegendWord.Text
                    .LegendMinusWord = txtMinusValue.Text
                    .LegendPlusWord = txtPlusValue.Text
                End With
                '線種・点ダミーの表示
                With .Line_DummyKind
                    .Line_Visible = chkLineKindLegend.Checked
                    .Dummy_Point_Visible = chkPointDummy.Checked
                    If rbLineKindZigzag.Checked = True Then
                        .Line_Pattern = clsAttrData.enmCircleMDLegendLine.Zigzag
                    Else
                        .Line_Pattern = clsAttrData.enmCircleMDLegendLine.Straight
                    End If

                    .Line_Visible_Number_STR = ""
                    For i As Integer = 0 To clbLineKindLegendShow.Items.Count - 1
                        If clbLineKindLegendShow.GetItemChecked(i) = True Then
                            .Line_Visible_Number_STR += "1"
                        Else
                            .Line_Visible_Number_STR += "0"
                        End If
                    Next
                End With
            End With
            '欠損値の凡例タブ－－－－－－－－－－－－
            With .Missing_Data
                .Print_Flag = chkMissingPrintFlag.Checked
                .Text = txtMissingWord.Text
                .Label = txtLabelModeMissingValue.Text
            End With
            'スケールの設定タブ－－－－－－－－－－－－
            With .MapScale
                .Visible = chkScaleShow.Checked
                .Unit = clsGeneric.getScaleUnit_from_Strings(cboScaleUnit.Text)
                .BarAuto = chkScaleBarAuto.Checked
                .BarDistance = Val(txtScaleBarDistance.Text)
                .BarKugiriNum = Val(txtScaleBarKugiri.Text)
                Select Case True
                    Case rbScalebar1.Checked
                        .BarPattern = clsAttrData.enmScaleBarPattern.Thin
                    Case rbScalebar2.Checked
                        .BarPattern = clsAttrData.enmScaleBarPattern.Bold
                    Case rbScaleBar3.Checked
                        .BarPattern = clsAttrData.enmScaleBarPattern.Slim
                End Select
            End With
            '移動データタブ－－－－－－－－－－－－
            With .Trip_Line
                .Start_End_Print = chkTripStart_End_Print.Checked
                .Height = txtTripPathHeight.Text
                .Frame_Print = chkTripFrame.Checked
                Select Case True
                    Case rbTripZLegendUpperLeft.Checked
                        .TimeLegend_Position = 0
                    Case rbTripZLegendUpperRight.Checked
                        .TimeLegend_Position = 1
                    Case rbTripZLegendLowerRight.Checked
                        .TimeLegend_Position = 2
                    Case rbTripZLegendLowerLeft.Checked
                        .TimeLegend_Position = 3
                    Case rbTripZLegendNo.Checked
                        .TimeLegend_Position = 4
                End Select
                .ZeroPointF = chkTripZeroPoint.Checked
                .ZeroLineF = chkTripZeroLine.Checked
                .VerticalLineF = chkTripVerticalLine.Checked
                .Overlap_Mode = chkTripOverLap.Checked
            End With
            .TileLicenceFont = TileLicenceFont
        End With
        Return ViewStyle
    End Function

    Private Sub picBack_Click(sender As Object, e As EventArgs) Handles picAccGroupBoxBack.Click
        attrData.Select_Background(picAccGroupBoxBack, ViewStyle.AccessoryGroupBox.Back)
    End Sub

    Private Sub picSymbolLine_Click(sender As Object, e As EventArgs) Handles picSymbolLine.Click
        attrData.Select_Line_Pattern(picSymbolLine, ViewStyle.SymbolLine.Line, True)
    End Sub

    Private Sub btnTitleFont_Click(sender As Object, e As EventArgs) Handles btnTitleFont.Click
        attrData.Select_Font(ViewStyle.MapTitle.Font)
    End Sub
    Private Sub btnNoteFont_Click(sender As Object, e As EventArgs) Handles btnNoteFont.Click
        attrData.Select_Font(ViewStyle.DataNote.Font)
    End Sub
    Private Sub btnCompassSetting_Click(sender As Object, e As EventArgs) Handles btnCompassSetting.Click
        Dim form = New frmCompassSetting
        If form.ShowDialog(Me, ViewStyle.AttMapCompass, ViewStyle.ScrData) = DialogResult.OK Then
            ViewStyle.AttMapCompass = form.getResult
        End If
        form.Dispose()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

    End Sub

    Private Sub rbAccBaseOnScreen_CheckedChanged(sender As Object, e As EventArgs) Handles rbAccBaseOnScreen.CheckedChanged

    End Sub

    Private Sub btnThiningPoint_Click(sender As Object, e As EventArgs) Handles btnThiningPoint.Click
        Dim form = New frmSmootingLineIn
        With ViewStyle.SouByou
            Dim LoopSize As Single = .LoopSize
            If form.ShowDialog(Me, .ThinningPrint_F, .PointInterval, .LoopAreaF, .LoopSize, False, ViewStyle.MapScale.Unit) = DialogResult.OK Then
                form.getResult(.ThinningPrint_F, .PointInterval, .LoopAreaF, .LoopSize)
                If .ThinningPrint_F = True Then
                    .Auto = False
                    chkSoubyouAuto.Checked = False
                End If
            End If
        End With
    End Sub


    Private Sub picMapFrameLine_Click(sender As Object, e As EventArgs) Handles picMapFrameLine.Click
        attrData.Select_Line_Pattern(picMapFrameLine, ViewStyle.Screen_Back.MapAreaFrameLine, True)
    End Sub

    Private Sub picScreenFrameLine_Click(sender As Object, e As EventArgs) Handles picScreenFrameLine.Click
        attrData.Select_Line_Pattern(picScreenFrameLine, ViewStyle.Screen_Back.ScreenFrameLine, True)
    End Sub

    Private Sub picScreenAreaTile_Click(sender As Object, e As EventArgs) Handles picScreenAreaTile.Click
        attrData.Select_Tile(picScreenAreaTile, ViewStyle.Screen_Back.ScreenAreaBack)
    End Sub

    Private Sub picMapAreaTile_Click(sender As Object, e As EventArgs) Handles picMapAreaTile.Click
        attrData.Select_Tile(picMapAreaTile, ViewStyle.Screen_Back.MapAreaBack)
    End Sub

    Private Sub picObjectInnerTile_Click(sender As Object, e As EventArgs) Handles picObjectInnerTile.Click
        attrData.Select_Tile(picObjectInnerTile, ViewStyle.Screen_Back.ObjectInner)
    End Sub


    Private Sub btnLatLonLineInterval_Click(sender As Object, e As EventArgs) Handles btnLatLonLineInterval.Click
        With ViewStyle.LatLonLine_Print
            Dim LInterval As strLatLon = New strLatLon(.Lat_Interval, .Lon_Interval)
            If clsGeneric.Get_LatLon(LInterval, clsSettings.Data.Ido_Kedo_Print_Pattern, False) = True Then
                .Lat_Interval = LInterval.Latitude
                .Lon_Interval = LInterval.Longitude
                Dim PStr As strPointStrings = clsGeneric.Get_LatLon_Strings(LInterval, False)
                lblLatLineInterval.Text = PStr.y
                lblLonLineInterval.Text = PStr.x
                chkLatLonPrint.Checked = True
            End If
        End With
    End Sub

    Private Sub picLatLonLine_Click(sender As Object, e As EventArgs) Handles picLatLonLine.Click
        attrData.Select_Line_Pattern(picLatLonLine, ViewStyle.LatLonLine_Print.LPat, True)
    End Sub

    Private Sub btnLegendFontSetting_Click(sender As Object, e As EventArgs) Handles btnLegendFontSetting.Click
        attrData.Select_Font(ViewStyle.MapLegend.Base.Font)
    End Sub

    Private Sub picLegendBack_Click(sender As Object, e As EventArgs) Handles picLegendBack.Click
        attrData.Select_Background(picLegendBack, ViewStyle.MapLegend.Base.Back)
    End Sub

    Private Sub picPaintFrame_Click(sender As Object, e As EventArgs) Handles picPaintFrame.Click
        attrData.Select_Line_Pattern(picPaintFrame, ViewStyle.MapLegend.ClassMD.PaintMode_Line, True)

    End Sub

    Private Sub picClassBoundary_Click(sender As Object, e As EventArgs) Handles picClassBoundary.Click
        attrData.Select_Line_Pattern(picClassBoundary, ViewStyle.MapLegend.ClassMD.ClassBoundaryLine.LPat, True)

    End Sub

    Private Sub picLineKindLegendBack_Click(sender As Object, e As EventArgs) Handles picLineKindLegendBack.Click
        attrData.Select_Background(picLineKindLegendBack, ViewStyle.MapLegend.Line_DummyKind.Back)

    End Sub


    Private Sub picClassPaintMissingValue_Click(sender As Object, e As EventArgs) Handles picClassPaintMissingValue.Click
        attrData.Select_Tile(picClassPaintMissingValue, ViewStyle.Missing_Data.PaintTile)
    End Sub

    Private Sub picClassHatchMissingValue_Click(sender As Object, e As EventArgs) Handles picClassHatchMissingValue.Click
        attrData.Select_Tile(picClassHatchMissingValue, ViewStyle.Missing_Data.HatchTile)
    End Sub

    Private Sub picClassMarkMissingValue_Click(sender As Object, e As EventArgs) Handles picClassMarkMissingValue.Click
        attrData.Select_Mark(picClassMarkMissingValue, ViewStyle.Missing_Data.ClassMark)

    End Sub

    Private Sub picMarkSizeMissingValue_Click(sender As Object, e As EventArgs) Handles picMarkSizeMissingValue.Click
        attrData.Select_Mark(picMarkSizeMissingValue, ViewStyle.Missing_Data.Mark)

    End Sub

    Private Sub picMarkBlockMissingValue_Click(sender As Object, e As EventArgs) Handles picMarkBlockMissingValue.Click
        attrData.Select_Mark(picMarkBlockMissingValue, ViewStyle.Missing_Data.BlockMark)

    End Sub

    Private Sub picMarkTurnMissingValue_Click(sender As Object, e As EventArgs) Handles picMarkTurnMissingValue.Click
        attrData.Select_Mark(picMarkTurnMissingValue, ViewStyle.Missing_Data.TurnMark)

    End Sub

    Private Sub picLineShapeMissingValue_Click(sender As Object, e As EventArgs) Handles picLineShapeMissingValue.Click
        attrData.Select_Line_Pattern(picLineShapeMissingValue, ViewStyle.Missing_Data.LineShape, True)
    End Sub

    Private Sub btScaleFont_Click(sender As Object, e As EventArgs) Handles btScaleFont.Click
        attrData.Select_Font(ViewStyle.MapScale.Font)
    End Sub

    Private Sub picScaleBack_Click(sender As Object, e As EventArgs) Handles picScaleBack.Click
        attrData.Select_Background(picScaleBack, ViewStyle.MapScale.Back)
    End Sub

    Private Sub txtScaleBarDistance_TextChanged(sender As Object, e As EventArgs) Handles txtScaleBarDistance.Enter, txtScaleBarKugiri.Enter
        chkScaleBarAuto.Checked = False
    End Sub


    Private Sub btnTIleLicenceFont_Click(sender As Object, e As EventArgs) Handles btnTIleLicenceFont.Click
        clsGeneric.Font_select(TileLicenceFont, attrData)
    End Sub


    Private Sub picMarkBarMissingValue_Click(sender As Object, e As EventArgs) Handles picMarkBarMissingValue.Click
        attrData.Select_Mark(picMarkBarMissingValue, ViewStyle.Missing_Data.MarkBar)
    End Sub

    Private Sub picTripMoveLine_Click(sender As Object, e As EventArgs) Handles picTripMoveLine.Click
        attrData.Select_Line_Pattern(picTripMoveLine, ViewStyle.Trip_Line.Trip_Line, True)
    End Sub

    Private Sub picTripStayLine_Click(sender As Object, e As EventArgs) Handles picTripStayLine.Click
        attrData.Select_Line_Pattern(picTripStayLine, ViewStyle.Trip_Line.Stay_Line, True)

    End Sub

    Private Sub picStartPointMark_Click(sender As Object, e As EventArgs) Handles picStartPointMark.Click
        attrData.Select_Mark(picStartPointMark, ViewStyle.Trip_Line.StartPoint_Mark)
    End Sub

    Private Sub picEndPointMark_Click(sender As Object, e As EventArgs) Handles picEndPointMark.Click
        attrData.Select_Mark(picEndPointMark, ViewStyle.Trip_Line.EndPoint_Mark)
    End Sub

    Private Sub picTripFrameLine_Click(sender As Object, e As EventArgs) Handles picTripFrameLine.Click
        attrData.Select_Line_Pattern(picTripFrameLine, ViewStyle.Trip_Line.Frame_Line, True)
    End Sub

    Private Sub picTripZeroPointMark_Click(sender As Object, e As EventArgs) Handles picTripZeroPointMark.Click
        attrData.Select_Mark(picTripZeroPointMark, ViewStyle.Trip_Line.ZeroPoint_Mark)
    End Sub

    Private Sub picTripZeroLine_Click(sender As Object, e As EventArgs) Handles picTripZeroLine.Click
        attrData.Select_Line_Pattern(picTripZeroLine, ViewStyle.Trip_Line.ZeroLine, True)
    End Sub

    Private Sub picTripVerticalLine_Click(sender As Object, e As EventArgs) Handles picTripVerticalLine.Click
        attrData.Select_Line_Pattern(picTripVerticalLine, ViewStyle.Trip_Line.VerticalLine, True)
    End Sub
    Private Sub Help_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        Dim ref As String = ""
        Select Case tabAll.SelectedIndex
            Case 0
                ref = "frmPrint_OptionGeneral"
            Case 1
                ref = "frmPrint_OptionBack"
            Case 2
                ref = "frmPrint_OptionLegend"
            Case 3
                ref = "frmPrint_OptionMissing"
            Case 4
                ref = "frmPrint_OptionScale"
            Case 5
                ref = "frmPrint_OptionTrip"
        End Select
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, ref, Me)
    End Sub

    Private Sub picLatLonOuterLine_Click(sender As Object, e As EventArgs) Handles picLatLonOuterLine.Click
        attrData.Select_Line_Pattern(picLatLonOuterLine, ViewStyle.LatLonLine_Print.OuterPat, True)

    End Sub

    Private Sub picLatLonEqLine_Click(sender As Object, e As EventArgs) Handles picLatLonEqLine.Click
        attrData.Select_Line_Pattern(picLatLonEqLine, ViewStyle.LatLonLine_Print.Equator, True)

    End Sub

    Private Sub chkOverlayTitleVisible_CheckedChanged(sender As Object, e As EventArgs) Handles chkOverlayTitleVisible.CheckedChanged

    End Sub

    Private Sub chkModeValueInScreenFlag_CheckedChanged(sender As Object, e As EventArgs) Handles chkModeValueInScreenFlag.CheckedChanged

    End Sub

    Private Sub chkFreq_CheckedChanged(sender As Object, e As EventArgs) Handles chkFreq.CheckedChanged

    End Sub

    Private Sub frmPrint_Option_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub chkSoubyouAuto_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoubyouAuto.CheckedChanged

    End Sub
End Class