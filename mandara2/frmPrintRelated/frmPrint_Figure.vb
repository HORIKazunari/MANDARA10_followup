Public Class frmPrint_Figure
    Dim frmOwner As frmPrint
    Dim PresentMode As frmPrint.enmFigureMode
    Public Enum enmLineDragMode
        noDrag = -1
        PointDrag = 0
        LineDrag = 1
    End Enum
    Public Enum enmRectangleDragMode
        noDrag = -1
        PointDrag = 0
        RectDrag = 1
    End Enum

    Public Structure strLineModeData
        Public EditingPoint As Integer
        Public EditingLine As Integer
        Public DragMode As enmLineDragMode
        Public OriginPoint As PointF
        Public OriginLinePoints As PointF()
        Public LoopDragF As Boolean
    End Structure
    Public Structure strRectangleModeData
        Public SelPointIndex As Integer
        Public DragMode As enmRectangleDragMode
        Public OriginPoint0 As PointF
        Public OriginPoint1 As PointF
    End Structure
    Public Enum enmCircleDragMode
        noDrag = -1
        CircleDrag = 0
        PointDrag = 1
    End Enum
    Public Structure strCircleModeData
        Public DragMode As enmCircleDragMode
        Public SelPointIndex As Integer
        Public OriginCenterP As PointF
        Public OriginXr As Single
        Public OriginYr As Single
        Public OriginAngle As Single
    End Structure
    Public Structure strObjectCircle
        Public LayerNum As Integer
        Public SelObject() As Boolean
        Public Circle As clsAttrData.strFig_Circle_data
    End Structure
    Public Enum enmPointDragMode
        noDrag = -1
        PointDrag = 0
        PointLegendDrag = 1
    End Enum
    Public Structure strPointModeData
        Public DragMode As enmPointDragMode
        Public OriginPoint As PointF
        Public SelPointIndex As Integer
    End Structure
    Public Enum enmGazoDragMode
        noDrag = -1
        GazoDrag = 0
        VartexDrag = 1
    End Enum
    Public Structure strGazoModeData
        Public DragMode As enmGazoDragMode
        Public SelectPoint As Integer
        Public OriginPoint As PointF
        Public OriginSize As Single
        Public OriginAngle As Single
    End Structure
    Public Structure strEditingData
        Public Word As clsAttrData.strFig_Word_Data
        Public Line As clsAttrData.strFig_Line_Data
        Public LineModeInfo As strLineModeData
        Public Rectangle As clsAttrData.strFig_Rectangle_Data
        Public RectangleModeInfo As strRectangleModeData
        Public Circle As clsAttrData.strFig_Circle_data
        Public CircleModeInfo As strCircleModeData
        Public ObjectCircle As strObjectCircle
        Public Point As clsAttrData.strFig_Point_Data
        Public PointModeInfo As strPointModeData
        Public Gazo As clsAttrData.strFig_gazo_data
        Public GazoModeInfo As strGazoModeData
    End Structure
    Dim attrData As clsAttrData
    Public EditingFig As strEditingData
    Dim EditingIndex As Integer
    Dim firstEditingIndex As Integer
    Dim OneFigureEndF As Boolean
    Private Structure strDefaultData
        Public set_f As Boolean
        Public WordFont As Font_Property
        Public LinePattern As Line_Property
        Public Circle As clsAttrData.strFig_Circle_data
        Public PointMark As Mark_Property
    End Structure
    Dim defaultData As strDefaultData
    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmPrint_Figure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = pnlFigMode.Left + pnlFigMode.Width + 20
        Dim locleft As Integer = Me.Owner.Left - Me.Width * 0.7
        Dim loctop As Integer = Me.Owner.Top + Me.Owner.Height * 0.1
        Me.Location = New Point(locleft, loctop)
        Dim ppos As Point = New Point(pnlFigMode.Left, pnlTargetData.Top + pnlTargetData.Height + 10)
        pnlPointting.Location = ppos
        pnlPointting.Width = pnlFigMode.Width
        pnlWord.Location = ppos
        pnlWord.Width = pnlFigMode.Width
        pnlLine.Location = ppos
        pnlLine.Width = pnlFigMode.Width

        pnlRectangle.Location = ppos
        pnlRectangle.Width = pnlFigMode.Width

        pnlCircle.Location = ppos
        pnlCircle.Width = pnlFigMode.Width

        pnlObjectCircle.Location = ppos
        pnlObjectCircle.Width = pnlFigMode.Width

        pnlPoints.Location = ppos
        pnlPoints.Width = pnlFigMode.Width

        pnlImage.Location = ppos
        pnlImage.Width = pnlFigMode.Width


    End Sub
    Private Sub setdefaultData()
        With defaultData
            .set_f = True
            .WordFont = clsBase.Font
            .LinePattern = clsBase.Line
            With .Circle
                .Angle = 0
                .LinePat = clsBase.Line
                .Printcenter = True
                .Tile = clsBase.BlancTile
                .Printcenter = True
                .Mark = clsBase.Mark
            End With
            .PointMark = clsBase.Mark
        End With
    End Sub
    Private Sub picFigSelect_Click(sender As Object, e As EventArgs) Handles picFigSelect.Click, picFigCircle.Click,
                                        picFigImage.Click, picFigLine.Click,
                                            picFigLine.Click, picFigRectangle.Click,
                                            picFigWord.Click, picFigObjectCircle.Click,
                                            picFigRectangle.Click, picFigPoint.Click
        Clear_PicButton()
        Dim pic As PictureBox = CType(sender, PictureBox)
        pic.BorderStyle = BorderStyle.Fixed3D

        Select Case pic.Name
            Case "picFigSelect"
                PresentMode = frmPrint.enmFigureMode.Pointing
            Case "picFigLine"
                PresentMode = frmPrint.enmFigureMode.Line
            Case "picFigWord"
                PresentMode = frmPrint.enmFigureMode.Word
            Case "picFigRectangle"
                PresentMode = frmPrint.enmFigureMode.Rectangle
            Case "picFigCircle"
                PresentMode = frmPrint.enmFigureMode.Circle
            Case "picFigObjectCircle"
                Dim f As Boolean = True
                Select Case attrData.TotalData.LV1.Print_Mode_Total
                    Case enmTotalMode_Number.OverLayMode, enmTotalMode_Number.SeriesMode
                        f = False
                    Case enmTotalMode_Number.DataViewMode
                        Select Case attrData.LayerData(attrData.TotalData.LV1.SelectedLayer).Print_Mode_Layer
                            Case enmLayerMode_Number.TripMode
                                f = False
                        End Select
                End Select
                If f = False Then
                    MsgBox("現在の表示モードではオブジェクト円は選択できません。", MsgBoxStyle.Exclamation)
                    Return
                End If
                PresentMode = frmPrint.enmFigureMode.Object_Circle
            Case "picFigPoint"
                PresentMode = frmPrint.enmFigureMode.Point
            Case "picFigImage"
                PresentMode = frmPrint.enmFigureMode.Image
        End Select
        frmOwner.SetFigureMouseMode(PresentMode)
        EditingIndex = -1
        initMode()
        SetFormPanel()
    End Sub
    Private Sub initMode()
        With EditingFig
            Dim CenterP As PointF
            Dim ScrSize As SizeF
            With attrData.TotalData.ViewStyle.ScrData.ScrRectangle
                CenterP = New PointF((.Right + .Left) / 2, (.Bottom + .Top) / 2)
                ScrSize = New SizeF(.Right - .Left, .Bottom - .Top)
            End With
            With .Word
                .Caption = ""
                .Data.Data = 0
                .Data.Layer = 0
                .Font = defaultData.WordFont
                .Scattered_Mode_F = False
                .Screen_Setf = False
                ReDim .StringPos(0)
                .StringPos(0).X = (attrData.TotalData.ViewStyle.ScrData.ScrRectangle.Left + attrData.TotalData.ViewStyle.ScrData.ScrRectangle.Right) / 2
                .StringPos(0).Y = (attrData.TotalData.ViewStyle.ScrData.ScrRectangle.Top + attrData.TotalData.ViewStyle.ScrData.ScrRectangle.Bottom) / 2
            End With
            With .Line
                .Arrow = clsBase.Arrow
                .FillFlag = False
                .NumOfPoint = 2
                .Spline = False
                .Tile = clsBase.PaintTile(New colorARGB(Color.White))
                .Patttern = defaultData.LinePattern
                ReDim .Points(1)
                .Points(0) = New PointF(CenterP.X - ScrSize.Width / 15, CenterP.Y)
                .Points(1) = New PointF(CenterP.X + ScrSize.Width / 15, CenterP.Y)
                .Circumscribed_Rectangle = spatial.Get_Circumscribed_Rectangle(.Points, 0, 2)
                .Data.Data = 0
                .Data.Layer = 0
            End With
            With .LineModeInfo
                .EditingLine = -1
                .EditingPoint = -1
            End With

            With .Rectangle
                .Back = clsBase.BlankBackground
                .Back.Padding = 0
                .Back.Line = defaultData.LinePattern
                .Back.Tile.Line.BasicLine.SolidLine.Color = clsBase.ColorWhite
                .Point0 = New PointF(CenterP.X - ScrSize.Width / 15, CenterP.Y - ScrSize.Height / 15)
                .Point1 = New PointF(CenterP.X + ScrSize.Width / 15, CenterP.Y + ScrSize.Height / 15)
                .Data.Data = 0
                .Data.Layer = 0
            End With
            With .RectangleModeInfo
                .DragMode = enmRectangleDragMode.noDrag
                .SelPointIndex = -1
            End With

            .Circle = defaultData.Circle
            With .Circle
                .Position = CenterP
                Dim P_Scl As clsAttrData.strScale_Attri = attrData.TotalData.ViewStyle.MapScale
                Dim xw As Single = attrData.TotalData.ViewStyle.ScrData.ScrView.Right - attrData.TotalData.ViewStyle.ScrData.ScrView.Left
                Dim MapScaleBairitu As Single = spatial.Get_Scale_Baititu_IdoKedo(P_Scl.Position, attrData.SetMapFile("").Map.Zahyo)
                MapScaleBairitu /= clsGeneric.Convert_ScaleUnit(enmScaleUnit.kilometer, P_Scl.Unit)
                Dim st As Single
                clsGeneric.WIC(10, xw, 0, st)
                .XR = st
                .YR = st
                .Data.Data = 0
                .Data.Layer = 0
                .Angle = 0
            End With
            With .CircleModeInfo
                .SelPointIndex = -1
                .DragMode = enmRectangleDragMode.noDrag
            End With
            With .ObjectCircle
                .LayerNum = attrData.TotalData.LV1.SelectedLayer
                .Circle = EditingFig.Circle
                ReDim .SelObject(attrData.LayerData(.LayerNum).atrObject.ObjectNum - 1)
                .Circle.Data.Data = 0
                .Circle.Data.Layer = attrData.TotalData.LV1.SelectedLayer + 1
            End With
            With .Point
                .NumOfPoint = 0
                ReDim .Points(0)
                .Mark = defaultData.PointMark
                .Font = defaultData.WordFont
                .Caption_F = False
                .Caption = ""
                .CaptionPosition = New PointF(CenterP.X + ScrSize.Width / 3, CenterP.Y - ScrSize.Height / 3)
                .Data.Data = 0
                .Data.Layer = 0
            End With
            With .PointModeInfo
                .DragMode = enmPointDragMode.noDrag
                .SelPointIndex = -1
            End With

            With .Gazo
                .AlphaValue = 255
                .Angle = 0
                .InnerCol_F = False
                .Inner_Color = clsBase.ColorWhite
                .Back = False
                .LinePat = clsBase.Line
                .PictureNumber = -1
                .Position = CenterP
                .Size = 20
                .Data.Data = 0
                .Data.Layer = 0
            End With
            With .GazoModeInfo
                .DragMode = enmGazoDragMode.noDrag
                .SelectPoint = -1
            End With
        End With
    End Sub
    ''' <summary>
    ''' フォーム内のパネルをモードに応じて表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetFormPanel()

        pnlPointting.Visible = False
        pnlCommon.Visible = False
        pnlTargetData.Visible = False
        pnlWord.Visible = False
        pnlLine.Visible = False
        pnlRectangle.Visible = False
        pnlCircle.Visible = False
        pnlObjectCircle.Visible = False
        pnlPoints.Visible = False
        pnlImage.Visible = False
        Select Case PresentMode
            Case frmPrint.enmFigureMode.Pointing
                pnlPointting.Visible = True
            Case frmPrint.enmFigureMode.Word
                pnlCommon.Visible = True
                pnlTargetData.Visible = True
                pnlWord.Visible = True
                With EditingFig.Word
                    Me.Tag = "OFF"
                    txtWord.Text = .Caption
                    chkScattered_Mode_F.Checked = .Scattered_Mode_F
                    chkWordScreenSetF.Checked = .Screen_Setf
                    Me.Tag = ""
                    btnWordLineUp.Enabled = .Scattered_Mode_F
                    cboLayer.SelectedIndex = .Data.Layer
                    cboData.SelectedIndex = .Data.Data
                End With
            Case frmPrint.enmFigureMode.Line
                pnlCommon.Visible = True
                pnlTargetData.Visible = True
                pnlLine.Visible = True
                With EditingFig.Line
                    Me.Tag = "OFF"
                    chkLineClose.Checked = .Points(0).Equals(.Points(.NumOfPoint - 1))
                    chkLineSpline.Checked = .Spline
                    chkLineInnerPaint.Checked = .FillFlag
                    Me.Tag = ""
                    attrData.Draw_Sample_TileBox(picLineInnerPaint, .Tile)
                    If attrData.TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                        btnLineGet.Enabled = True
                    Else
                        btnLineGet.Enabled = False
                    End If
                    cboLayer.SelectedIndex = .Data.Layer
                    cboData.SelectedIndex = .Data.Data
                End With
            Case frmPrint.enmFigureMode.Rectangle
                pnlCommon.Visible = True
                pnlTargetData.Visible = True
                pnlRectangle.Visible = True
                With EditingFig.Rectangle
                    attrData.Draw_Sample_BackgroundBox(picRectangleBox, .Back)
                    cboLayer.SelectedIndex = .Data.Layer
                    cboData.SelectedIndex = .Data.Data
                End With
            Case frmPrint.enmFigureMode.Circle
                pnlCommon.Visible = True
                pnlTargetData.Visible = True
                pnlCircle.Visible = True
                With EditingFig.Circle
                    attrData.Draw_Sample_LineBox(picCircleLinePat, .LinePat)
                    attrData.Draw_Sample_TileBox(picCircleInnerPat, .Tile)
                    attrData.Draw_Sample_Mark_Box(picCircleCenterMark, .Mark)
                    Me.Tag = "OFF"
                    chkCircleCenterMark.Checked = .Printcenter
                    Me.Tag = ""
                    cboLayer.SelectedIndex = .Data.Layer
                    cboData.SelectedIndex = .Data.Data
                    lblCircleScaleUnit0.Text = clsGeneric.getScaleUnitStrings(attrData.TotalData.ViewStyle.MapScale.Unit)
                    lblCircleScaleUnit1.Text = lblCircleScaleUnit0.Text
                    set_FigCircleValue_to_Panel()
                End With
            Case frmPrint.enmFigureMode.Object_Circle
                pnlCommon.Visible = True
                pnlTargetData.Visible = True
                pnlObjectCircle.Visible = True
                With EditingFig.ObjectCircle
                    lblObjCircleScaleUnit.Text = clsGeneric.getScaleUnitStrings(attrData.TotalData.ViewStyle.MapScale.Unit)
                    With .Circle
                        attrData.Draw_Sample_LineBox(picObjCircleLinePat, .LinePat)
                        attrData.Draw_Sample_TileBox(picObjCircleInnerPat, .Tile)
                        attrData.Draw_Sample_Mark_Box(picObjCircleCenterMark, .Mark)
                        Me.Tag = "OFF"
                        chkObjCircleCenterMark.Checked = .Printcenter
                        txtObjCircleRadius.Text = .XR
                        Me.Tag = ""
                        cboLayer.SelectedIndex = .Data.Layer
                        cboData.SelectedIndex = .Data.Data
                        lblObjCircleScaleUnit.Text = clsGeneric.getScaleUnitStrings(attrData.TotalData.ViewStyle.MapScale.Unit)
                    End With
                    attrData.Set_ObjectName_to_ListBoxEx(lbObjCircleObject, attrData.TotalData.LV1.SelectedLayer)
                End With
            Case frmPrint.enmFigureMode.Point
                pnlCommon.Visible = True
                pnlTargetData.Visible = True
                pnlPoints.Visible = True
                If attrData.TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                    btnPointGet.Enabled = True
                Else
                    btnPointGet.Enabled = False
                End If
                With EditingFig.Point
                    attrData.Draw_Sample_Mark_Box(picPointMark, .Mark)
                    chkPointLegend.Checked = .Caption_F
                    txtPointLegend.Text = .Caption
                    lblPointNumberSet()
                    cboLayer.SelectedIndex = .Data.Layer
                    cboData.SelectedIndex = .Data.Data
                End With
            Case frmPrint.enmFigureMode.Image
                pnlCommon.Visible = True
                pnlTargetData.Visible = True
                pnlImage.Visible = True
                With EditingFig.Gazo
                    Me.Tag = "OFF"
                    chkImageChangeInnerColor.Checked = .InnerCol_F
                    txtImageAngle.Text = .Angle
                    Me.Tag = ""
                    attrData.Draw_Sample_LineBox(picImageFrameLine, .LinePat)
                    picImageInnerColor.BackColor = .Inner_Color.getColor
                    chkImageMapBack.Checked = .Back
                    cboLayer.SelectedIndex = .Data.Layer
                    cboData.SelectedIndex = .Data.Data
                End With
        End Select
        If EditingIndex = -1 Then
            btnDelete.Enabled = False
            btnAhead.Enabled = False
            btnBack.Enabled = False
        Else
            btnDelete.Enabled = True
            btnAhead.Enabled = True
            btnBack.Enabled = True
        End If
        Print_Fig()
    End Sub
    ''' <summary>
    ''' 編集中の図形を画面に表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Print_Fig()
        frmOwner.picMap.Refresh()
        Dim g As Graphics = frmOwner.picMap.CreateGraphics
        Select Case PresentMode
            Case frmPrint.enmFigureMode.Word
                Dim P_Word As clsAttrData.strFig_Word_Data = EditingFig.Word
                P_Word.Font.Back.Tile.Line.BasicLine.SolidLine.Color = New colorARGB(&HD0, &HFF, &HAA, &HAA)
                P_Word.Font.Back.Tile.TileCode = enmTilePattern.Paint
                clsAccessory.Fig_PrintWords(g, attrData, P_Word)
            Case frmPrint.enmFigureMode.Line
                clsAccessory.Fig_PrintLine(g, attrData, EditingFig.Line)
                With EditingFig.Line
                    .Circumscribed_Rectangle = spatial.Get_Circumscribed_Rectangle(.Points, 0, .NumOfPoint)
                    Dim pxy As Point() = attrData.TotalData.ViewStyle.ScrData.getSxSy(.NumOfPoint, .Points, False, False)
                    If EditingFig.Line.Spline = True Then
                        attrData.Draw_Line(g, .Patttern, EditingFig.Line.NumOfPoint, pxy)
                    End If
                    Dim PointBrush = New SolidBrush(Color.Red)
                    For i As Integer = 1 To pxy.Length - 2
                        If pxy(i).Equals(pxy(i - 1)) = False Then
                            If attrData.Check_Screen_In(pxy(i), 4) = True Then
                                clsDraw.Ellipse(g, pxy(i), 4, PointBrush, Pens.Black)
                            End If
                        End If
                    Next

                    '両末端
                    Dim EndPointBrush = New SolidBrush(Color.FromArgb(255, 255, 150, 255))
                    clsDraw.Ellipse(g, pxy(0), 6, EndPointBrush, Pens.Black)
                    clsDraw.Ellipse(g, pxy(pxy.GetUpperBound(0)), 6, EndPointBrush, Pens.Black)
                    Dim Font As New Font("MS UI Gothic", 10, GraphicsUnit.Pixel)
                    clsDraw.print(g, "S", pxy(0), Font, New SolidBrush(Color.Black), StringAlignment.Center, StringAlignment.Center)
                    clsDraw.print(g, "E", pxy(pxy.GetUpperBound(0)), Font, New SolidBrush(Color.Black), StringAlignment.Center, StringAlignment.Center)

                    With EditingFig.LineModeInfo
                        If .EditingPoint <> -1 Then
                            clsDraw.Ellipse(g, pxy(.EditingPoint), 6, New SolidBrush(Color.Yellow), New Pen(Color.Black, 2))
                        End If
                        If .EditingLine <> -1 Then
                            g.DrawLine(New Pen(Color.Black, 4), pxy(.EditingLine), pxy(.EditingLine + 1))
                            g.DrawLine(New Pen(Color.Yellow, 2), pxy(.EditingLine), pxy(.EditingLine + 1))
                        End If
                    End With

                End With
            Case frmPrint.enmFigureMode.Rectangle
                clsAccessory.Fig_PrintRectangle(g, attrData, EditingFig.Rectangle)
                Dim P0 As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(EditingFig.Rectangle.Point0)
                Dim P1 As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(EditingFig.Rectangle.Point1)
                Dim srect As Rectangle = spatial.Get_Circumscribed_Rectangle(P0, P1)
                Dim pxy() As Point = spatial.Get_PolyLine_from_Recatngle(srect)
                Dim PointBrush = New SolidBrush(Color.Red)
                clsDraw.Ellipse(g, P0, 4, PointBrush, Pens.Black)
                clsDraw.Ellipse(g, P1, 4, PointBrush, Pens.Black)
                With EditingFig.RectangleModeInfo
                    If .SelPointIndex <> -1 Then
                        Dim P As Point = P0
                        If .SelPointIndex = 1 Then
                            P = P1
                        End If
                        clsDraw.Ellipse(g, P, 6, New SolidBrush(Color.Yellow), New Pen(Color.Black, 2))
                    End If
                End With
            Case frmPrint.enmFigureMode.Circle
                clsAccessory.Fig_PrintCircle(g, attrData, EditingFig.Circle)
                Dim Map As clsMapData.strMap_data = attrData.SetMapFile("").Map
                With EditingFig
                    Dim Pt() As Point = Get_CircleR_FourPoints(.Circle, Map)
                    Dim PointBrush = New SolidBrush(Color.Red)
                    For i As Integer = 0 To 1
                        Dim col As colorARGB
                        Select Case i
                            Case 1
                                col = New colorARGB(Color.Blue)
                            Case 0
                                col = New colorARGB(Color.Red)
                        End Select
                        Dim Lpat As Line_Property = clsBase.Line
                        Lpat.BasicLine.SolidLine.Color = col
                        attrData.Draw_Line(g, Lpat, Pt(i * 2), Pt(i * 2 + 1))
                        clsDraw.Ellipse(g, Pt(i * 2), 4, PointBrush, Pens.Black)
                        clsDraw.Ellipse(g, Pt(i * 2 + 1), 4, PointBrush, Pens.Black)
                    Next
                    If .CircleModeInfo.SelPointIndex <> -1 Then
                        clsDraw.Ellipse(g, Pt(.CircleModeInfo.SelPointIndex), 6, New SolidBrush(Color.Yellow), New Pen(Color.Black, 2))
                    End If
                End With
            Case frmPrint.enmFigureMode.Object_Circle
                With EditingFig.ObjectCircle
                    For i As Integer = 0 To .SelObject.Count - 1
                        If .SelObject(i) = True Then
                            Dim ccl As clsAttrData.strFig_Circle_data = .Circle
                            ccl.Position = attrData.LayerData(.LayerNum).atrObject.atrObjectData(i).CenterPoint
                            ccl.YR = ccl.XR
                            clsAccessory.Fig_PrintCircle(g, attrData, ccl)
                        End If
                    Next
                End With
            Case frmPrint.enmFigureMode.Point
                With EditingFig
                    Dim r As Integer = attrData.TotalData.ViewStyle.ScrData.Radius(.Point.Mark.WordFont.Body.Size, 1, 1) + 4
                    For i As Integer = 0 To .Point.NumOfPoint - 1
                        Dim pos As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(.Point.Points(i))
                        Dim Lpat As Line_Property = clsBase.Line
                        Lpat.Set_Same_Color_to_LinePat(New colorARGB(Color.Red))
                        attrData.Draw_Line(g, Lpat, New Point(pos.X - r, pos.Y), New Point(pos.X + r, pos.Y))
                        attrData.Draw_Line(g, Lpat, New Point(pos.X, pos.Y - r), New Point(pos.X, pos.Y + r))
                        clsAccessory.Fig_PrintPoint(g, attrData, .Point)
                        If .PointModeInfo.SelPointIndex = i Then
                            Dim mk As Mark_Property = .Point.Mark
                            attrData.Draw_Mark(g, pos, r, mk)
                        End If
                    Next
                End With
            Case frmPrint.enmFigureMode.Image
                With EditingFig
                    If .Gazo.PictureNumber <> -1 Then
                        clsAccessory.Fig_PrintGazo(g, attrData, .Gazo)
                        Dim cp As Point
                        Dim rad As Integer
                        Dim rect As Rectangle
                        clsAccessory.Get_Fig_ImageRect(attrData, .Gazo, cp, rect, rad)

                        Dim p() As Point = spatial.Get_TurnedRectangle(rect, .Gazo.Angle)
                        For i As Integer = 0 To 3
                            Select Case i
                                Case 1, 3
                                    clsDraw.Ellipse(g, p(i), 4, New SolidBrush(Color.Purple), Pens.Black)
                                Case 0, 2
                                    Dim prect As Rectangle = New Rectangle(p(i), New Size(0, 0))
                                    prect.Inflate(4, 4)
                                    g.FillRectangle(New SolidBrush(Color.Red), prect)
                                    g.DrawRectangle(Pens.Black, prect)
                            End Select
                        Next
                        Select Case .GazoModeInfo.SelectPoint
                            Case 1, 3
                                clsDraw.Ellipse(g, p(.GazoModeInfo.SelectPoint), 6, New SolidBrush(Color.Yellow), Pens.Black)
                            Case 0, 2
                                Dim prect As Rectangle = New Rectangle(p(.GazoModeInfo.SelectPoint), New Size(0, 0))
                                prect.Inflate(6, 6)
                                g.FillRectangle(New SolidBrush(Color.Yellow), prect)
                                g.DrawRectangle(Pens.Black, prect)
                        End Select
                    End If
                End With
        End Select
        g.Dispose()
    End Sub

    ''' <summary>
    ''' 選択ボタンをクリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Clear_PicButton()
        For Each picB As PictureBox In TableLayoutPanelFigMode.Controls
            '以前の選択をクリア
            If picB.BorderStyle = BorderStyle.Fixed3D Then
                picB.BorderStyle = BorderStyle.None
            End If
        Next

    End Sub
    ''' <summary>
    ''' 出力画面のメニューからShow
    ''' </summary>
    ''' <param name="_attrData"></param>
    ''' <remarks></remarks>
    Public Overloads Sub Show(ByRef _attrData As clsAttrData)
        OneFigureEndF = False
        If defaultData.set_f = False Then
            setdefaultData()
        End If
        frmOwner = CType(Me.Owner, frmPrint)
        Clear_PicButton()
        attrData = _attrData
        picFigSelect.BorderStyle = BorderStyle.Fixed3D
        PresentMode = frmPrint.enmFigureMode.Pointing
        frmOwner.SetFigureMouseMode(PresentMode)
        SetFormPanel()

        attrData.Set_LayerName_to(cboLayer, -1)
        cboLayer.Items.Insert(0, "全レイヤ")
        Me.Show()
    End Sub
    ''' <summary>
    ''' 出力画面からデフォルト図形付きでShow。一度登録したら図形モード終了する。
    ''' </summary>
    ''' <param name="_attrData"></param>
    ''' <remarks></remarks>
    Public Overloads Sub Show(ByRef _attrData As clsAttrData, ByRef Fig As Object)
        OneFigureEndF = True
        If defaultData.set_f = False Then
            setdefaultData()
        End If
        frmOwner = CType(Me.Owner, frmPrint)
        attrData = _attrData
        picFigSelect.BorderStyle = BorderStyle.Fixed3D

        attrData.Set_LayerName_to(cboLayer, -1)
        cboLayer.Items.Insert(0, "全レイヤ")
        Select Case True
            Case TypeOf Fig Is clsAttrData.strFig_Word_Data
                Dim cdt As clsAttrData.strFig_Word_Data = DirectCast(Fig, clsAttrData.strFig_Word_Data)
                cdt.Font = defaultData.WordFont
                Fig = cdt
        End Select
        SetFigureMode(Fig, -1)
        Me.Show()
    End Sub

    ''' <summary>
    ''' FormClosingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmPrint_Figure_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            frmOwner.mnuFigureMode.Checked = False
        End If
    End Sub

    ''' <summary>
    ''' 図形モード終了ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        frmOwner.mnuFigureMode.Checked = False
    End Sub
    ''' <summary>
    ''' 図形モードの編集図形を設定（図形選択クリックから、frmPrintから使われる）
    ''' </summary>
    ''' <param name="FigObj"></param>
    ''' <param name="Index"></param>
    ''' <remarks></remarks>
    Public Sub SetFigureMode(ByRef FigStac As Object, ByVal Index As Integer)
        Clear_PicButton()
        initMode()
        Select Case True
            Case TypeOf FigStac Is clsAttrData.strFig_Word_Data
                Dim cdt As clsAttrData.strFig_Word_Data = DirectCast(FigStac, clsAttrData.strFig_Word_Data)
                With EditingFig.Word
                    .Caption = cdt.Caption
                    .Data = cdt.Data
                    .Font = cdt.Font
                    .Scattered_Mode_F = cdt.Scattered_Mode_F
                    .Screen_Setf = cdt.Screen_Setf
                    .StringPos = cdt.StringPos.Clone
                End With
                PresentMode = frmPrint.enmFigureMode.Word
                picFigWord.BorderStyle = BorderStyle.Fixed3D
            Case TypeOf FigStac Is clsAttrData.strFig_Line_Data
                Dim cdt As clsAttrData.strFig_Line_Data = DirectCast(FigStac, clsAttrData.strFig_Line_Data)
                With EditingFig.Line
                    .FillFlag = cdt.FillFlag
                    .NumOfPoint = cdt.NumOfPoint
                    .Patttern = cdt.Patttern
                    .Points = cdt.Points.Clone
                    .Spline = cdt.Spline
                    .Arrow = cdt.Arrow
                    .Tile = cdt.Tile
                    .Data = cdt.Data
                    .Circumscribed_Rectangle = cdt.Circumscribed_Rectangle
                End With
                PresentMode = frmPrint.enmFigureMode.Line
                picFigLine.BorderStyle = BorderStyle.Fixed3D
            Case TypeOf FigStac Is clsAttrData.strFig_Rectangle_Data
                EditingFig.Rectangle = DirectCast(FigStac, clsAttrData.strFig_Rectangle_Data)
                PresentMode = frmPrint.enmFigureMode.Rectangle
                picFigRectangle.BorderStyle = BorderStyle.Fixed3D
            Case TypeOf FigStac Is clsAttrData.strFig_Circle_data
                EditingFig.Circle = DirectCast(FigStac, clsAttrData.strFig_Circle_data)
                PresentMode = frmPrint.enmFigureMode.Circle
                picFigCircle.BorderStyle = BorderStyle.Fixed3D
            Case TypeOf FigStac Is clsAttrData.strFig_Point_Data
                Dim cdt As clsAttrData.strFig_Point_Data = DirectCast(FigStac, clsAttrData.strFig_Point_Data)
                With EditingFig.Point
                    .Caption = cdt.Caption
                    .Caption_F = cdt.Caption_F
                    .CaptionPosition = cdt.CaptionPosition
                    .Data = cdt.Data
                    .Font = cdt.Font
                    .Mark = cdt.Mark
                    .NumOfPoint = cdt.NumOfPoint
                    .Points = cdt.Points.Clone
                End With
                PresentMode = frmPrint.enmFigureMode.Point
                picFigPoint.BorderStyle = BorderStyle.Fixed3D
            Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                EditingFig.Gazo = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                PresentMode = frmPrint.enmFigureMode.Image
                picFigImage.BorderStyle = BorderStyle.Fixed3D
                With EditingFig.Gazo
                    chkImageChangeInnerColor.Checked = .InnerCol_F
                    chkImageMapBack.Checked = .Back
                End With
        End Select
        frmOwner.SetFigureMouseMode(PresentMode)
        EditingIndex = Index
        firstEditingIndex = Index
        SetFormPanel()
    End Sub
    ''' <summary>
    ''' 登録ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegist_Click(sender As Object, e As EventArgs) Handles btnRegist.Click
        Select Case PresentMode
            Case frmPrint.enmFigureMode.Word
                If EditingFig.Word.Caption = "" Then
                    MsgBox("文字が設定されていません。", MsgBoxStyle.Exclamation)
                    Return
                End If
                EditingFig.Word.Data.Layer = cboLayer.SelectedIndex
                EditingFig.Word.Data.Data = cboData.SelectedIndex
            Case frmPrint.enmFigureMode.Line
                EditingFig.Line.Data.Layer = cboLayer.SelectedIndex
                EditingFig.Line.Data.Data = cboData.SelectedIndex
            Case frmPrint.enmFigureMode.Rectangle
                EditingFig.Rectangle.Data.Layer = cboLayer.SelectedIndex
                EditingFig.Rectangle.Data.Data = cboData.SelectedIndex
            Case frmPrint.enmFigureMode.Circle
                EditingFig.Circle.Data.Layer = cboLayer.SelectedIndex
                EditingFig.Circle.Data.Data = cboData.SelectedIndex
            Case frmPrint.enmFigureMode.Object_Circle
            Case frmPrint.enmFigureMode.Point
                If EditingFig.Point.NumOfPoint = 0 Then
                    MsgBox("点が設定されていません。", MsgBoxStyle.Exclamation)
                    Return
                End If
                EditingFig.Point.Data.Layer = cboLayer.SelectedIndex
                EditingFig.Point.Data.Data = cboData.SelectedIndex
            Case frmPrint.enmFigureMode.Image
                If EditingFig.Gazo.PictureNumber = -1 Then
                    MsgBox("画像を選択して下さい。", MsgBoxStyle.Exclamation)
                    Return
                End If
                EditingFig.Gazo.Data.Layer = cboLayer.SelectedIndex
                EditingFig.Gazo.Data.Data = cboData.SelectedIndex
        End Select
        If EditingIndex = -1 Then
            Select Case PresentMode
                Case frmPrint.enmFigureMode.Word
                    attrData.TotalData.FigureStac.Add(EditingFig.Word)
                    defaultData.WordFont = EditingFig.Word.Font
                Case frmPrint.enmFigureMode.Line
                    attrData.TotalData.FigureStac.Add(EditingFig.Line)
                    defaultData.LinePattern = EditingFig.Line.Patttern
                Case frmPrint.enmFigureMode.Rectangle
                    attrData.TotalData.FigureStac.Add(EditingFig.Rectangle)
                    defaultData.LinePattern = EditingFig.Rectangle.Back.Line
                Case frmPrint.enmFigureMode.Circle
                    attrData.TotalData.FigureStac.Add(EditingFig.Circle)
                    defaultData.Circle = EditingFig.Circle
                Case frmPrint.enmFigureMode.Object_Circle
                    With EditingFig.ObjectCircle
                        Dim ccl As clsAttrData.strFig_Circle_data = .Circle
                        ccl.Data.Layer = cboLayer.SelectedIndex
                        ccl.Data.Data = cboData.SelectedIndex
                        ccl.YR = ccl.XR
                        For i As Integer = 0 To .SelObject.Count - 1
                            If .SelObject(i) = True Then
                                ccl.Position = attrData.LayerData(.LayerNum).atrObject.atrObjectData(i).CenterPoint
                                attrData.TotalData.FigureStac.Add(ccl)
                            End If
                        Next
                        defaultData.Circle = EditingFig.ObjectCircle.Circle
                    End With
                Case frmPrint.enmFigureMode.Point
                    attrData.TotalData.FigureStac.Add(EditingFig.Point)
                Case frmPrint.enmFigureMode.Image
                    attrData.TotalData.FigureStac.Add(EditingFig.Gazo)
            End Select
        Else
            attrData.TotalData.FigureStac.RemoveAt(firstEditingIndex)
            Select Case PresentMode
                Case frmPrint.enmFigureMode.Word
                    attrData.TotalData.FigureStac.Insert(EditingIndex, EditingFig.Word)
                    defaultData.WordFont = EditingFig.Word.Font
                Case frmPrint.enmFigureMode.Line
                    attrData.TotalData.FigureStac.Insert(EditingIndex, EditingFig.Line)
                Case frmPrint.enmFigureMode.Rectangle
                    attrData.TotalData.FigureStac.Insert(EditingIndex, EditingFig.Rectangle)
                Case frmPrint.enmFigureMode.Circle
                    attrData.TotalData.FigureStac.Insert(EditingIndex, EditingFig.Circle)
                Case frmPrint.enmFigureMode.Object_Circle
                    'オブジェクト円は必要なし
                Case frmPrint.enmFigureMode.Point
                    attrData.TotalData.FigureStac.Insert(EditingIndex, EditingFig.Point)
                Case frmPrint.enmFigureMode.Image
                    attrData.TotalData.FigureStac.Insert(EditingIndex, EditingFig.Gazo)
            End Select
        End If
        frmOwner.printMapScreen(True)
        If OneFigureEndF = False Then
            EditingIndex = -1
            initMode()
            SetFormPanel()
        Else
            frmOwner.mnuFigureMode.Checked = False
        End If
    End Sub
    ''' <summary>
    ''' 前へボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAhead_Click(sender As Object, e As EventArgs) Handles btnAhead.Click
        EditingIndex += 1
        If EditingIndex = attrData.TotalData.FigureStac.Count Then
            EditingIndex = attrData.TotalData.FigureStac.Count - 1
        End If
    End Sub
    ''' <summary>
    ''' 後ろへボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        EditingIndex -= 1
        If EditingIndex = -1 Then
            EditingIndex = 0
        End If

    End Sub
    ''' <summary>
    ''' キャンセルボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEdirCancel_Click(sender As Object, e As EventArgs) Handles btnEdirCancel.Click
        If OneFigureEndF = False Then
            EditingIndex = -1
            initMode()
            SetFormPanel()
        Else
            frmOwner.mnuFigureMode.Checked = False
        End If
    End Sub
    ''' <summary>
    ''' 図形削除ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        attrData.TotalData.FigureStac.RemoveAt(firstEditingIndex)
        frmOwner.printMapScreen(True)
        EditingIndex = -1
        initMode()
        SetFormPanel()
    End Sub
    ''' <summary>
    ''' レイヤが変更されてデータ項目を変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayer.SelectedIndexChanged
        Dim LayerNum As Integer = cboLayer.SelectedIndex - 1

        If LayerNum = -1 Then
            cboData.Items.Clear()
            cboData.Items.Add("全データ")
        Else
            attrData.Set_DataTitle_to_cboBox(cboData, LayerNum, 0)
            cboData.Items.Insert(0, "全データ")
        End If
        cboData.SelectedIndex = 0
    End Sub
    ''' <summary>
    ''' 文字モード／入力テキストボックス
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtWord_TextChanged(sender As Object, e As EventArgs) Handles txtWord.TextChanged
        If Me.Tag = "" Then
            With EditingFig.Word
                .Caption = txtWord.Text
                If .Scattered_Mode_F = True Then
                    resetWordLine()
                End If
            End With
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 文字モード／整列
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub resetWordLine()
        With EditingFig.Word
            Dim g As Graphics = frmOwner.picMap.CreateGraphics
            Dim PN As Integer = Len(.Caption)
            ReDim Preserve .StringPos(Math.Max(PN - 1, 0))
            Dim H As Integer = attrData.Get_Length_On_Screen(.Font.Body.Size)
            Dim hnfont As Font = New Font(.Font.Body.Name, H, GraphicsUnit.Pixel)
            Dim sx As Integer = attrData.TotalData.ViewStyle.ScrData.getSx(.StringPos(0).X)
            For i As Integer = 1 To PN - 1
                Dim accumX = g.MeasureString(Mid(.Caption, 1, i), hnfont).Width
                .StringPos(i).Y = .StringPos(0).Y
                .StringPos(i).X = attrData.TotalData.ViewStyle.ScrData.getSRX(sx + accumX)
            Next
            hnfont.Dispose()
            g.Dispose()

        End With
    End Sub
    ''' <summary>
    ''' 文字モード／画面に固定チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkWordScreenSetF_CheckedChanged(sender As Object, e As EventArgs) Handles chkWordScreenSetF.CheckedChanged
        If Me.Tag = "" Then
            With EditingFig.Word
                .Screen_Setf = chkWordScreenSetF.Checked
                If .Screen_Setf = True Then
                    .Scattered_Mode_F = False
                    chkScattered_Mode_F.Checked = False
                    chkScattered_Mode_F.Enabled = False
                    btnWordLineUp.Enabled = False
                    .StringPos(0) = attrData.TotalData.ViewStyle.ScrData.getRatioPfromSrxSry(.StringPos(0))
                Else
                    chkScattered_Mode_F.Enabled = True
                    btnWordLineUp.Enabled = True
                    .StringPos(0) = attrData.TotalData.ViewStyle.ScrData.getSRXYfromRatio(.StringPos(0))
                End If
                Print_Fig()
            End With
        End If
    End Sub
    ''' <summary>
    ''' 文字モード／個別位置指定チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkScattered_Mode_F_CheckedChanged(sender As Object, e As EventArgs) Handles chkScattered_Mode_F.CheckedChanged
        If Me.Tag = "" Then
            With EditingFig.Word
                .Scattered_Mode_F = chkScattered_Mode_F.Checked
                If .Scattered_Mode_F = True Then
                    resetWordLine()
                    btnWordLineUp.Enabled = True
                Else
                    btnWordLineUp.Enabled = False
                End If
                Print_Fig()
            End With
        End If
    End Sub
    ''' <summary>
    ''' 文字モード／フォントボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnWordFont_Click(sender As Object, e As EventArgs) Handles btnWordFont.Click
        With EditingFig.Word
            If clsGeneric.Font_select(.Font, attrData) = True Then
                Print_Fig()
            End If
        End With
    End Sub
    ''' <summary>
    ''' 文字モード／整列ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnWordLineUp_Click(sender As Object, e As EventArgs) Handles btnWordLineUp.Click
        With EditingFig.Word
            Dim PN As Integer = Len(.Caption)
            If PN < 3 Then
                MsgBox("３文字以上必要です。", MsgBoxStyle.Exclamation)
                Return
            End If
            Dim w As Single = (.StringPos(PN - 1).X - .StringPos(0).X) / (PN - 1)
            Dim H As Single = (.StringPos(PN - 1).Y - .StringPos(0).Y) / (PN - 1)
            For i As Integer = 1 To PN - 2
                .StringPos(i).X = .StringPos(0).X + w * i
                .StringPos(i).Y = .StringPos(0).Y + H * i
            Next
            Print_Fig()
        End With
    End Sub

    ''' <summary>
    ''' ラインモード／曲線近似
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkLineSpline_CheckedChanged(sender As Object, e As EventArgs) Handles chkLineSpline.CheckedChanged
        If Me.Tag = "" Then
            EditingFig.Line.Spline = chkLineSpline.Checked
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' ラインモード/塗りつぶし
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chlLineInnerPaint_CheckedChanged(sender As Object, e As EventArgs) Handles chkLineInnerPaint.CheckedChanged
        If Me.Tag = "" Then
            EditingFig.Line.FillFlag = chkLineInnerPaint.Checked
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' ラインモード／閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkLineClose_CheckedChanged(sender As Object, e As EventArgs) Handles chkLineClose.CheckedChanged
        If Me.Tag = "" Then
            With EditingFig.Line
                If chkLineClose.Checked = True Then
                    If .NumOfPoint < 3 Then
                        MsgBox("３点以上必要です。", MsgBoxStyle.Exclamation)
                        Me.Tag = "OFF"
                        chkLineClose.Checked = False
                        Me.Tag = ""
                    Else
                        ReDim Preserve .Points(.NumOfPoint)
                        .Points(.NumOfPoint) = .Points(0)
                        .NumOfPoint += 1
                    End If
                    Print_Fig()
                Else
                    .Points(.NumOfPoint - 1).X = (.Points(.NumOfPoint - 1).X + .Points(.NumOfPoint - 2).X) / 2
                    .Points(.NumOfPoint - 1).Y = (.Points(.NumOfPoint - 1).Y + .Points(.NumOfPoint - 2).Y) / 2
                    Print_Fig()
                End If
            End With
        End If
    End Sub
    ''' <summary>
    ''' ラインモード／内部色指定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picLineInnerPaint_Click(sender As Object, e As EventArgs) Handles picLineInnerPaint.Click
        If attrData.Select_Tile(EditingFig.Line.Tile) = True Then
            attrData.Draw_Sample_TileBox(picLineInnerPaint, EditingFig.Line.Tile)
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' ラインモード／線種設定ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLinePattern_Click(sender As Object, e As EventArgs) Handles btnLinePattern.Click
        If attrData.Select_Line_Pattern(EditingFig.Line.Patttern, True) = True Then
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' ラインモード／線の取り込み
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLineGet_Click(sender As Object, e As EventArgs) Handles btnLineGet.Click
        Dim n As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("線取り込み", {"緯度経度", "GPXファイル"})
        Select Case n
            Case -1
            Case 0
                Dim form As New frmPrint_PointLineAdd
                If form.ShowDialog("線の取り込み", attrData.TotalData.ViewStyle.Zahyo.System) = Windows.Forms.DialogResult.OK Then
                    Dim P() As PointF = form.getResult
                    With EditingFig.Line
                        ReDim .Points(P.Length - 1)
                        For i As Integer = 0 To P.Length - 1
                            .Points(i) = spatial.Get_Converted_XY(P(i), attrData.TotalData.ViewStyle.Zahyo)
                        Next
                        .NumOfPoint = P.Length
                        Print_Fig()
                    End With
                End If
            Case 1
                Dim ofd As New OpenFileDialog
                If clsSettings.Data.Directory.DataFile = "" Then
                    clsSettings.Data.Directory.DataFile = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                End If
                ofd.InitialDirectory = clsSettings.Data.Directory.GPX
                ofd.Filter = "GPXファイル(*.gpx)|*.gpx"
                If ofd.ShowDialog() = DialogResult.OK Then
                    Dim gpx As New clsGPX
                    Dim gpxdata As New List(Of clsGPX.GPX_Info)
                    If gpx.Get_GPXFile(ofd.FileName, gpxdata) = True Then
                        With EditingFig.Line
                            ReDim .Points(gpxdata.Count - 1)
                            For i As Integer = 0 To gpxdata.Count - 1
                                .Points(i) = spatial.Get_Converted_XY(gpxdata(i).Position.toPointF, attrData.TotalData.ViewStyle.Zahyo)
                            Next
                            .NumOfPoint = gpxdata.Count
                            Print_Fig()
                            clsSettings.Data.Directory.GPX = System.IO.Path.GetDirectoryName(ofd.FileName)
                        End With

                    End If
                End If
        End Select
    End Sub
    ''' <summary>
    ''' ラインモード／矢印ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLineArrow_Click(sender As Object, e As EventArgs) Handles btnLineArrow.Click
        If clsGeneric.Arrow_Set(EditingFig.Line.Arrow, "始点側", "終点側") = True Then
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 四角形モード／内部picturebox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picRectangleBox_Click(sender As Object, e As EventArgs) Handles picRectangleBox.Click
        If attrData.Select_Background(picRectangleBox, EditingFig.Rectangle.Back) = True Then
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 円モード／ラインパターン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picCircleLinePat_Click(sender As Object, e As EventArgs) Handles picCircleLinePat.Click
        If attrData.Select_Line_Pattern(picCircleLinePat, EditingFig.Circle.LinePat, True) = True Then
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 円モード／内部パターン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picCircleInnerPat_Click(sender As Object, e As EventArgs) Handles picCircleInnerPat.Click
        If attrData.Select_Tile(picCircleInnerPat, EditingFig.Circle.Tile) = True Then
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 円モード／中心点
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picCircleCenterMark_Click(sender As Object, e As EventArgs) Handles picCircleCenterMark.Click
        If attrData.Select_Mark(picCircleCenterMark, EditingFig.Circle.Mark) = True Then
            If chkCircleCenterMark.Checked = False Then
                chkCircleCenterMark.Checked = True
            Else
                Print_Fig()
            End If
        End If
    End Sub
    ''' <summary>
    ''' 円モード／中心点チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkCircleCenterMark_CheckedChanged(sender As Object, e As EventArgs) Handles chkCircleCenterMark.CheckedChanged
        If Me.Tag = "" Then
            EditingFig.Circle.Printcenter = chkCircleCenterMark.Checked
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 円モード／回転角度
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtCircleAngle_TextChanged(sender As Object, e As EventArgs) Handles txtCircleAngle.TextChanged
        If Me.Tag = "" Then
            EditingFig.Circle.Angle = Val(txtCircleAngle.Text)
            Print_Fig()
        End If
    End Sub

    ''' <summary>
    ''' 円モード/X軸半径txt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtCircleAxisDistance0_TextChanged(sender As Object, e As EventArgs) Handles txtCircleAxisDistance0.TextChanged
        If Me.Tag = "" Then
            EditingFig.Circle.XR = Val(txtCircleAxisDistance0.Text)
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 円モード/Y軸半径txt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtCircleAxisDistance1_TextChanged(sender As Object, e As EventArgs) Handles txtCircleAxisDistance1.TextChanged
        If Me.Tag = "" Then
            EditingFig.Circle.YR = Val(txtCircleAxisDistance1.Text)
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 円のXY軸4点の座標を返す。0、1はX軸、2、3はY軸。
    ''' </summary>
    ''' <param name="Cricle"></param>
    ''' <param name="Map"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_CircleR_FourPoints(ByRef Circle As clsAttrData.strFig_Circle_data, ByRef Map As clsMapData.strMap_data) As Point()
        Dim Pt(4) As Point
        Dim n As Integer = 0
        With Circle
            Dim MapScaleBairitu As Single
            If Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
                MapScaleBairitu = Map.SCL
            Else
                MapScaleBairitu = spatial.Get_Scale_Baititu_IdoKedo(.Position, Map.Zahyo)
            End If
            For i As Integer = 0 To 1
                Dim x1r As Single = .XR * MapScaleBairitu
                Dim y1r As Single = .YR * MapScaleBairitu
                Dim col As colorARGB
                Select Case i
                    Case 0
                        y1r = 0
                    Case 1
                        x1r = 0
                End Select
                spatial.Trans2D(x1r, y1r, .Angle)
                Dim P1 As PointF = .Position
                Dim P2 As PointF = .Position
                spatial.PointF_offset(P1, -x1r, y1r)
                spatial.PointF_offset(P2, x1r, -y1r)
                Pt(n) = attrData.TotalData.ViewStyle.ScrData.getSxSy(P1)
                Pt(n + 1) = attrData.TotalData.ViewStyle.ScrData.getSxSy(P2)
                n += 2
            Next
        End With
        Return Pt

    End Function
    ''' <summary>
    ''' 円モードの半径、角度をテキストボックスに
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub set_FigCircleValue_to_Panel()
        Me.Tag = "OFF"
        Dim P_Scl As clsAttrData.strScale_Attri = attrData.TotalData.ViewStyle.MapScale
        With EditingFig.Circle

            txtCircleAngle.Text = .Angle
            txtCircleAxisDistance0.Text = .XR * clsGeneric.Convert_ScaleUnit(enmScaleUnit.kilometer, P_Scl.Unit)
            txtCircleAxisDistance1.Text = .YR * clsGeneric.Convert_ScaleUnit(enmScaleUnit.kilometer, P_Scl.Unit)
        End With

        Me.Tag = ""
    End Sub


    ''' <summary>
    ''' オブジェクト円／オブジェクト選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbObjCircleObject_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lbObjCircleObject.SelectedIndexChanged
        With EditingFig.ObjectCircle
            For i As Integer = 0 To .SelObject.Count - 1
                .SelObject(i) = lbObjCircleObject.GetSelected(i)
            Next
        End With
        Print_Fig()
    End Sub
    ''' <summary>
    ''' オブジェクト円／ラインパターン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picObjCircleLinePat_Click(sender As Object, e As EventArgs) Handles picObjCircleLinePat.Click
        If attrData.Select_Line_Pattern(picObjCircleLinePat, EditingFig.ObjectCircle.Circle.LinePat, True) = True Then
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' オブジェクト円／内部パターン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picObjCircleInnerPat_Click(sender As Object, e As EventArgs) Handles picObjCircleInnerPat.Click
        If attrData.Select_Tile(picObjCircleInnerPat, EditingFig.ObjectCircle.Circle.Tile) = True Then
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' オブジェクト円／半径
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtObjCircleRadius_TextChanged(sender As Object, e As EventArgs) Handles txtObjCircleRadius.Leave
        If Me.Tag = "" Then
            EditingFig.ObjectCircle.Circle.XR = Val(txtObjCircleRadius.Text)
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' オブジェクト円／中心点チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkObjCircleCenterMark_CheckedChanged(sender As Object, e As EventArgs) Handles chkObjCircleCenterMark.CheckedChanged
        If Me.Tag = "" Then
            EditingFig.ObjectCircle.Circle.Printcenter = chkObjCircleCenterMark.Checked
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' オブジェクト円／中心記号
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picObjCircleCenterMark_Click(sender As Object, e As EventArgs) Handles picObjCircleCenterMark.Click
        If attrData.Select_Mark(picObjCircleCenterMark, EditingFig.ObjectCircle.Circle.Mark) = True Then
            If chkObjCircleCenterMark.Checked = False Then
                chkObjCircleCenterMark.Checked = True
            Else
                Print_Fig()
            End If
        End If
    End Sub
    ''' <summary>
    ''' 点／点記号
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picPointMark_Click(sender As Object, e As EventArgs) Handles picPointMark.Click
        If attrData.Select_Mark(picPointMark, EditingFig.Point.Mark) = True Then
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 点／点取り込み
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPointGet_Click(sender As Object, e As EventArgs) Handles btnPointGet.Click
        Dim form As New frmPrint_PointLineAdd
        If form.ShowDialog("点の取り込み", attrData.TotalData.ViewStyle.Zahyo.System) = Windows.Forms.DialogResult.OK Then
            Dim P() As PointF = form.getResult
            With EditingFig.Point
                ReDim Preserve .Points(.NumOfPoint + P.Length - 1)
                For i As Integer = 0 To P.Length - 1
                    .Points(.NumOfPoint + i) = spatial.Get_Converted_XY(P(i), attrData.TotalData.ViewStyle.Zahyo)
                Next
                .NumOfPoint += P.Length
                Print_Fig()
            End With
        End If
    End Sub
    ''' <summary>
    ''' 点／凡例表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkPointLegend_CheckedChanged(sender As Object, e As EventArgs) Handles chkPointLegend.CheckedChanged
        If Me.Tag = "" Then
            EditingFig.Point.Caption_F = chkPointLegend.Checked
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 点／凡例文字
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtPointLegend_TextChanged(sender As Object, e As EventArgs) Handles txtPointLegend.Leave
        If Me.Tag = "" Then
            EditingFig.Point.Caption = txtPointLegend.Text
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 点／凡例フォント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPointLegendFont_Click(sender As Object, e As EventArgs) Handles btnPointLegendFont.Click
        If attrData.Select_Font(EditingFig.Point.Font) = True Then
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 点／点の追加
    ''' </summary>
    ''' <param name="AddPoint"></param>
    ''' <remarks></remarks>
    Public Sub AddPoint(ByVal AddPoint As PointF)
        With EditingFig.Point
            ReDim Preserve .Points(.NumOfPoint)
            .Points(.NumOfPoint) = AddPoint
            .NumOfPoint += 1
            Print_Fig()
            lblPointNumberSet()
        End With
    End Sub
    ''' <summary>
    ''' 点／ポイント数ラベル
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub lblPointNumberSet()
        lblPointNumber.Text = "ポイント数：" + EditingFig.Point.NumOfPoint.ToString
    End Sub
    ''' <summary>
    ''' 点／点の削除
    ''' </summary>
    ''' <param name="RemPoint"></param>
    ''' <remarks></remarks>
    Public Sub RemovePoint(ByVal RemPoint As Integer)
        With EditingFig.Point
            If .NumOfPoint <> 1 Then
                clsGeneric.Remove_Point_Array(RemPoint, .Points)
            End If
            .NumOfPoint -= 1
            If .NumOfPoint <> 0 Then
                ReDim Preserve .Points(.NumOfPoint - 1)
            End If
            Print_Fig()
            lblPointNumberSet()
        End With
    End Sub

    ''' <summary>
    ''' 画像／地図の背景チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkImageMapBack_CheckedChanged(sender As Object, e As EventArgs) Handles chkImageMapBack.CheckedChanged
        EditingFig.Gazo.Back = chkImageMapBack.Checked
    End Sub

    ''' <summary>
    ''' 画像／枠線
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picImageFrameLine_Click(sender As Object, e As EventArgs) Handles picImageFrameLine.Click
        If attrData.Select_Line_Pattern(picImageFrameLine, EditingFig.Gazo.LinePat, True) = True Then
            Print_Fig()
        End If
    End Sub

    ''' <summary>
    ''' 画像／回転角度
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtImageAngle_TextChanged(sender As Object, e As EventArgs) Handles txtImageAngle.TextChanged
        If Me.Tag = "" Then
            EditingFig.Gazo.Angle = Val(txtImageAngle.Text)
            Print_Fig()
        End If
    End Sub

    ''' <summary>
    ''' 画像／内部色
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picImageInnerColor_Click(sender As Object, e As EventArgs) Handles picImageInnerColor.Click
        If attrData.Select_Color(picImageInnerColor, EditingFig.Gazo.Inner_Color) = True Then
            Print_Fig()
        End If
    End Sub

    ''' <summary>
    ''' 画像／内部色変更チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkImageChangeInnerColor_CheckedChanged(sender As Object, e As EventArgs) Handles chkImageChangeInnerColor.CheckedChanged
        If Me.Tag = "" Then
            EditingFig.Gazo.InnerCol_F = chkImageChangeInnerColor.Checked
        End If
    End Sub
    ''' <summary>
    ''' 画像／画像選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnImageSelect_Click(sender As Object, e As EventArgs) Handles btnImageSelect.Click

        Dim n As Integer = clsGeneric.Select_Picture(attrData, EditingFig.Gazo.PictureNumber)
        If n <> -1 Then
            EditingFig.Gazo.PictureNumber = n
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 画像／透過度指定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnImageAlphaValue_Click(sender As Object, e As EventArgs) Handles btnImageAlphaValue.Click
        If clsGeneric.Set_AlphaValueForm(EditingFig.Gazo.AlphaValue) = True Then
            Print_Fig()
        End If
    End Sub
    ''' <summary>
    ''' 画像／角度をテキストボックスに
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub set_FigGazoValue_to_Panel()
        Me.Tag = "OFF"
        With EditingFig.Gazo
            txtImageAngle.Text = .Angle
        End With
        Me.Tag = ""
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "frmPrint_Figure", Me)
    End Sub


End Class