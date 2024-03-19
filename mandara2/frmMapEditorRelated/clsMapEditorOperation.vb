Public Class clsMapEditorOperation
 
    Private Structure strLineDivideData_info
        Public OriginalLineCode As Integer
        Public AddedLineCode As Integer
    End Structure


    Public ScrData As Screen_info
    Public Structure strDefAttVisible
        Public Visible As Boolean
        Public ObjectKind As Integer
        Public DataItem As Integer
    End Structure
    Private Structure strTileMapViewInfo
        Public visible As Boolean
        Public ViewData As strTileMapViewDataInfo
    End Structure
    Private DefAttVisibleData As strDefAttVisible

    Dim AggregationObjectFlag As Boolean
    Dim objectEnabled() As Boolean
    Dim lineEnabled() As Boolean
    Dim MapData As clsMapData
    Dim picMap As PictureBox

    Dim TileMapView As strTileMapViewInfo

    Dim LineIndex As New clsSpatialIndexSearch
    Dim PointIndex As New clsSpatialIndexSearch


    Dim EditingObject As clsMapData.strObj_Data
    Dim EditingLine As clsMapData.strLine_Data

    Dim EditingMultiObject As New List(Of Integer)
    Dim EditingMultiLine As New List(Of Integer)

    Dim LastSavedLineKind As Integer
    Dim LastSavedObjectKind As Integer

    Dim CutPointOfPolygon As PointF
    ''' <summary>
    ''' オブジェクト編集時の代表点ドラッグのスタック位置
    ''' </summary>
    ''' <remarks></remarks>
    Dim EditedObjectDragCoreNumer As Integer

    ''' <summary>
    ''' ライン編集時の点ドラッグのスタック位置
    ''' </summary>
    ''' <remarks></remarks>
    Dim EditedLineDragPointNumber As Integer
    ''' <summary>
    ''' 方位ドラッグモードの前のモード
    ''' </summary>
    ''' <remarks></remarks>
    Dim oldEditingMode_before_CompassDragMode As frmMapEditor.editingModes

    Dim MapEditorUndo As clsMED_Undo
    Dim TileMap As clsTileMapService

    Dim picMapImageOperation As clsPictureBoxDragOrWheelImageChange

    Dim _MapEditor As frmMapEditor
    Public Sub New(ByRef frmMEditor As frmMapEditor, ByRef _tilemap As clsTileMapService)
        _MapEditor = frmMEditor
        TileMap = _tilemap
    End Sub
    Public Sub initScrData(ByRef OriginalMapData As clsMapData, ByRef picturebox As PictureBox)
        MapData = OriginalMapData
        picMap = picturebox
        If MapData.NoDataFlag = True Then
            Return
        End If
        MapEditorUndo = New clsMED_Undo(_MapEditor, OriginalMapData)
        picMapImageOperation = New clsPictureBoxDragOrWheelImageChange(picMap)
        With DefAttVisibleData
            .Visible = False
            .ObjectKind = -1
            .DataItem = -1
        End With
        With ScrData
            .init(picMap, New ScreenMargin(3, 3, 3, 3, False), MapData.Map.Circumscribed_Rectangle, enmBasePosition.Screen, True)
        End With
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            If MapData.ObjectKind(i).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                Me.AggregationObjectFlag = True
            End If
        Next
        ReDim objectEnabled(MapData.Map.Kend - 1)
        ReDim lineEnabled(MapData.Map.ALIN - 1)
        clsGeneric.FillArray(objectEnabled, True)
        clsGeneric.FillArray(lineEnabled, True)
        With TileMapView
            .visible = False
            With .ViewData
                .TileMapDataSet = TileMap.getTileMap_by_Name("地理院地図（標準地図）")
                .AlphaValue = 255
                .LastUserFolder = ""
                .LastWorldFileFolder = ""
                .TransparentF = False
            End With
        End With
    End Sub
    Public Sub EditMapping(ByVal VisibleCheck As Boolean)
        If MapData Is Nothing Then
            Return
        End If
        If MapData.NoDataFlag = False Then

            ScrData.Set_PictureBox_and_CulculateMul(picMap)
            If VisibleCheck = True Then
                MapData.countNumOfLineUse()
                CheckObjectEdit()
            End If
            Dim sw As New Stopwatch
            sw.Start()
            LineIndexMake()
            sw.Restart()
            PointIndexMake()
            sw.Stop()

            '描画先とするImageオブジェクトを作成する
            Dim canvas As New Bitmap(picMap.Width, picMap.Height)
            'ImageオブジェクトのGraphicsオブジェクトを作成する
            Dim g As Graphics = Graphics.FromImage(canvas)
            g.FillRectangle(New SolidBrush(clsSettings.Data.MapEditor.Backcolor.getColor), 0, 0, picMap.Width, picMap.Height)

            If TileMapView.visible = True Then
                With TileMapView.ViewData

                    TileMap.PrintTMS(g, .TileMapDataSet, .TransparentF, .AlphaValue, clsSettings.Data.BackImageSpeed, MapData, ScrData)
                End With
            End If

            'まず編集対象以外のラインを描画
            If _MapEditor.EditList.unEditableVisible = True Then
                Dim discol As Color = clsSettings.Data.MapEditor.LineColorDisabled.getColor
                For i As Integer = 0 To MapData.Map.ALIN - 1
                    If lineEnabled(i) = False Then
                        printOneLine(g, MapData.MPLine(i), discol, 1, False)
                    End If
                Next
            End If
            sw.Restart()
            '編集対象のラインを描画
            Dim col As Color = clsSettings.Data.MapEditor.LineColor.getColor
            For i As Integer = 0 To MapData.Map.ALIN - 1
                If lineEnabled(i) = True Then
                    printOneLine(g, MapData.MPLine(i), col, 1)
                End If
            Next
            sw.Stop()

            '代表点をグループごとに描く
            For i As Integer = 0 To MapData.Map.OBKNum - 1
                printCoreByObjectkind(g, i)
            Next

            'オブジェクト名・初期属性の表示
            If clsSettings.Data.MapEditor.ObjectNameVisibleFlag = True Or DefAttVisibleData.Visible = True Then
                Dim objInF(MapData.Map.Kend - 1) As Boolean
                Dim defAttPrintF(MapData.Map.Kend - 1) As Boolean
                Dim in_n As Integer = 0
                Dim defaP_n As Integer = 0
                For i As Integer = 0 To MapData.Map.Kend - 1
                    With MapData.MPObj(i)
                        If objectEnabled(i) = True Then
                            If clsGeneric.Check_Point_in_screen(.CenterPSTC(.NumOfCenterP - 1).Position, ScrData, 0) = True Then
                                If clsSettings.Data.MapEditor.ObjectNameVisibleFlag = True Then
                                    objInF(i) = True
                                    in_n += 1
                                End If
                                If DefAttVisibleData.Visible = True And DefAttVisibleData.DataItem < MapData.ObjectKind(.Kind).DefTimeAttDataNum _
                                        And .Kind = DefAttVisibleData.ObjectKind Then
                                    defAttPrintF(i) = True
                                    defaP_n += 1
                                End If
                            End If
                        End If
                    End With
                Next
                Dim ObjName_Print_F As Boolean = True
                Dim defAtt_Print_F As Boolean = True
                '既定の数を上回った場合は表示しない
                If in_n >= clsSettings.Data.MapEditor.ObjectNamePrinting_Maxmun Then
                    ObjName_Print_F = False
                    ReDim objInF(MapData.Map.Kend - 1)
                End If
                If defaP_n >= clsSettings.Data.MapEditor.ObjectNamePrinting_Maxmun Then
                    defAtt_Print_F = False
                    ReDim defAttPrintF(MapData.Map.Kend - 1)
                End If
                'オブジェクト名・初期属性の表示
                If ObjName_Print_F = True Or defAtt_Print_F = True Then
                    Call PrtObjectName(g, objInF, defAttPrintF)
                End If
            End If

            Select Case _MapEditor.EditingMode
                Case frmMapEditor.editingModes.ObjectEditingMode
                    '編集中のオブジェクトを描く
                    prtEditingObject(EditingObject, g)
                Case frmMapEditor.editingModes.LineEditingMode
                    '編集中のラインを描く
                    prtEditingLine(g)
                Case frmMapEditor.editingModes.MultiObjectsEditingMode
                    '複数オブジェクト編集
                    prtEditingMultiObject(g)
                Case frmMapEditor.editingModes.MultiLinesEditingMode
                    '複数ライン編集
                    prtEditingMultiLine(g)
                Case frmMapEditor.editingModes.Set_ClickObjectName
                    'オブジェクト名のクリック割り当て
                    If EditingObject.Number <> -1 Then
                        prtEditingObject(EditingObject, g)
                    End If
            End Select

            CompassShow(g, MapData.Map.MapCompass)

            'リソースを解放する
            g.Dispose()
            If picMap.Image Is Nothing = False Then
                picMap.Image.Dispose()
            End If
            picMap.Image = canvas
            picMap.Refresh()

        End If
    End Sub
    ''' <summary>
    ''' 方位記号表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="MapCompass"></param>
    ''' <remarks></remarks>
    Private Sub CompassShow(ByRef g As Graphics, ByRef MapCompass As clsMapData.strCompass_Attri)

        With MapCompass
            If .Visible = False Then
                Return
            End If

            Dim r As Integer = ScrData.Get_Length_On_Screen(.Mark.WordFont.Body.Size / 2)
            Dim centerP As Point = ScrData.getSxSy(.Position)
            Dim ltp As Point = centerP
            ltp.Offset(-r, -r)
            Dim rect As Rectangle = New Rectangle(ltp, New Size(r * 2, r * 2))

            If spatial.Compare_Two_Rectangle_Position(rect, ScrData.MapScreen_Scale) <> cstRectangle_Cross.cstOuter Then
                Dim CompD As Integer = .Mark.WordFont.Body.Kakudo
                clsDrawMarkFan.Mark_Print(g, centerP, r, .Mark, ScrData, clsBase.PictureNoUse)
                Dim ww As Integer = ScrData.Get_Length_On_Screen(.Font.Body.Size) * 0.7
                Dim PlusFont As Font_Property = .Font
                PlusFont.Body.Kakudo += .Mark.WordFont.Body.Kakudo
                For i As Integer = 0 To 3
                    Dim wpos As Point = centerP
                    wpos.Offset(Math.Cos((i * 90 + 90 + CompD) * Math.PI / 180) * (r + ww),
                                -Math.Sin((i * 90 + 90 + CompD) * Math.PI / 180) * (r + ww))
                    Dim CmpassWord As String
                    With .dirWord
                        Select Case i
                            Case 0
                                CmpassWord = .North
                            Case 1
                                CmpassWord = .West
                            Case 2
                                CmpassWord = .South
                            Case 3
                                CmpassWord = .East
                        End Select
                    End With
                    clsDraw.print(g, CmpassWord, wpos, PlusFont, enmHorizontalAlignment.Center, enmVerticalAlignment.Center, ScrData, clsBase.PictureNoUse)
                Next

            End If
        End With

    End Sub
    ''' <summary>
    ''' 複数ライン選択モードで選択ライン表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <remarks></remarks>
    Private Sub prtEditingMultiLine(ByRef g As Graphics)
        For Each i As Integer In EditingMultiLine
            Dim xy() As Point
            With MapData.MPLine(i)
                xy = ScrData.getSxSy(.NumOfPoint, .PointSTC, False, True)
            End With
            g.DrawLines(New Pen(clsSettings.Data.MapEditor.LineColorSelected.getColor, 2), xy)
        Next
    End Sub
    ''' <summary>
    ''' 単独編集中のラインを描く
    ''' </summary>
    ''' <param name="g">グラフィックス</param>
    ''' <remarks></remarks>
    Private Sub prtEditingLine(ByRef g As Graphics)
        Dim xy() As Point
        Dim PointBrush = New SolidBrush(clsSettings.Data.MapEditor.LineColorPoints.getColor)
        With EditingLine
            xy = ScrData.getSxSy(.NumOfPoint, .PointSTC, False, True)
        End With
        Dim pen As New Pen(clsSettings.Data.MapEditor.LineColorSelected.getColor, 2)
        pen.LineJoin = Drawing2D.LineCap.Round
        g.DrawLines(pen, xy)
        pen.Dispose()
        For i As Integer = 1 To xy.GetUpperBound(0) - 1
            clsDraw.Ellipse(g, xy(i), 3, PointBrush, Pens.Black)
        Next

        '両末端
        Dim EndPointBrush = New SolidBrush(Color.FromArgb(255, 255, 150, 255))
        clsDraw.Ellipse(g, xy(0), 6, EndPointBrush, Pens.Black)
        clsDraw.Ellipse(g, xy(xy.GetUpperBound(0)), 6, EndPointBrush, Pens.Black)
        Dim Font As New Font("MS UI Gothic", 10, GraphicsUnit.Pixel)
        clsDraw.print(g, "S", xy(0), Font, New SolidBrush(Color.Black), StringAlignment.Center, StringAlignment.Center)
        clsDraw.print(g, "E", xy(xy.GetUpperBound(0)), Font, New SolidBrush(Color.Black), StringAlignment.Center, StringAlignment.Center)
    End Sub
    ''' <summary>
    ''' 複数オブジェクト選択モードの選択オブジェクトを描く
    ''' </summary>
    ''' <param name="g"></param>
    ''' <remarks></remarks>
    Private Sub prtEditingMultiObject(ByRef g As Graphics)
        For i As Integer = 0 To EditingMultiObject.Count - 1
            prtEditingObject(MapData.MPObj(EditingMultiObject.Item(i)), g)
        Next
    End Sub
    ''' <summary>
    ''' 単独編集中のオブジェクトを描く
    ''' </summary>
    ''' <param name="Obj">オブジェクト</param>
    ''' <param name="g">グラフィックス</param>
    ''' <remarks></remarks>
    Private Sub prtEditingObject(ByRef Obj As clsMapData.strObj_Data, ByRef g As Graphics)

        With Obj
            Dim otype = MapData.ObjectKind(.Kind).ObjectType
            Select Case otype
                Case clsMapData.enmObjectGoupType_Data.NormalObject

                    For i As Integer = 0 To .NumOfLine - 1
                        Dim LineCol As Color = clsSettings.Data.MapEditor.ObjectLineColor.getColor
                        If lineEnabled(.LineCodeSTC(i).LineCode) = False Then
                            LineCol = clsSettings.Data.MapEditor.ObjectLineColorDisabled.getColor
                        Else
                            If MapData.Map.Time_Mode = True And .LineCodeSTC(i).NumOfTime >= 1 Then
                                LineCol = clsSettings.Data.MapEditor.ObjectTimeLineColor.getColor
                            End If
                        End If
                        printOneLine(g, MapData.MPLine(.LineCodeSTC(i).LineCode), LineCol, 2)

                    Next
                Case clsMapData.enmObjectGoupType_Data.AggregationObject
                    PrtAggrObject(g, Obj)
            End Select
            Dim CoreCol As Color = Color.Red
            Dim PenColorBlack = New Pen(Color.FromArgb(255, 0, 0, 0), 2)
            Dim brush As New SolidBrush(CoreCol)

            For i As Integer = 0 To .NumOfCenterP - 1
                printOneCore(g, .CenterPSTC(i).Position, .Shape, brush, PenColorBlack, enmSize.Large, True, i)
            Next

            If .Shape = enmShape.LineShape And MapData.ObjectKind(.Kind).Shape = enmShape.PolygonShape Then
                'オブジェクトの形状が線で、オブジェクトグループが面の場合は、切れ目に○を付ける
                Dim rect As Rectangle
                Dim cp As Point = ScrData.getSxSy(CutPointOfPolygon)
                Dim CoreSize = 9
                cp.Offset(-CoreSize \ 2, -CoreSize \ 2)
                rect = New Rectangle(cp, New Size(CoreSize, CoreSize))
                g.DrawEllipse(New Pen(clsSettings.Data.MapEditor.CutPointOfPolygonColor.getColor, 2), rect)
            End If
        End With

    End Sub
    ''' <summary>
    ''' 集成オブジェクトの輪郭線と構成オブジェクトの代表点の描画
    ''' </summary>
    ''' <param name="g">グラフィックス</param>
    ''' <param name="ObjData">オブジェクト</param>
    ''' <remarks></remarks>
    Private Sub PrtAggrObject(ByRef g As Graphics, ByRef ObjData As clsMapData.strObj_Data)

        Dim colL As Color = clsSettings.Data.MapEditor.ObjectLineColor.getColor
        Dim AggrLineNumber() As Integer
        Dim ELN As Integer = MapData.Get_AggrOuterLine_AllTime(ObjData, AggrLineNumber)

        For i As Integer = 0 To ELN - 1
            printOneLine(g, MapData.MPLine(AggrLineNumber(i)), colL, 2)
        Next

        Dim CoreCol As Color = Color.Red
        Dim PenColor = New Pen(Color.FromArgb(255, 0, 0, 0), 2)
        Dim brush As New SolidBrush(CoreCol)
        With ObjData
            For i As Integer = 0 To .NumOfLine - 1
                printOneCore(g, MapData.MPObj(.LineCodeSTC(i).LineCode).CenterPSTC(0).Position, _
                        MapData.MPObj(.LineCodeSTC(i).LineCode).Shape, brush, PenColor, enmSize.Small)
            Next
        End With


    End Sub
    ''' <summary>
    ''' オブジェクト名と初期属性の表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="ObjName_Print_F">オブジェクトごとにオブジェクト名を表示する場合true</param>
    ''' <param name="defAtt_Print_F">オブジェクトごとに初期属性を表示する場合true</param>
    ''' <remarks></remarks>
    Private Sub PrtObjectName(ByRef g As Graphics, ByVal ObjName_Print_F() As Boolean, ByVal defAtt_Print_F() As Boolean)

        Dim fntObjName As New Font(clsSettings.Data.SetFont, clsSettings.Data.MapEditor.ObjectNameSize, GraphicsUnit.Pixel)
        Dim brushObjName As New SolidBrush(clsSettings.Data.MapEditor.ObjectNameColor.getColor)
        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Near

        Dim fntDefAtt As New Font(clsSettings.Data.SetFont, clsSettings.Data.MapEditor.DefAttrSize, GraphicsUnit.Pixel)
        Dim brushDefAtt As New SolidBrush(clsSettings.Data.MapEditor.DefAttrColor.getColor)

        For i As Integer = 0 To MapData.Map.Kend - 1
            With MapData.MPObj(i)
                Dim centerP As Point = ScrData.getSxSy(.CenterPSTC(.NumOfCenterP - 1).Position)
                If ObjName_Print_F(i) = True Then
                    Dim NameStr As String
                    MapData.Get_Enable_ObjectName(MapData.MPObj(i), _MapEditor.EditList.EditTime, True, NameStr)
                    centerP.Y += clsSettings.Data.MapEditor.ObjectNameSize \ 2 + 2
                    g.DrawString(NameStr, fntObjName, brushObjName, centerP, stringFormat)
                    centerP.Y += clsSettings.Data.MapEditor.ObjectNameSize
                End If
                If defAtt_Print_F(i) = True Then
                    centerP.Y += clsSettings.Data.MapEditor.DefAttrSize \ 2 + 2
                    Dim vstr As String
                    MapData.Get_DefTimeAttrValue(i, DefAttVisibleData.DataItem, _MapEditor.EditList.EditTime, vstr)
                    g.DrawString(vstr, fntDefAtt, brushDefAtt, centerP, stringFormat)
                End If
            End With
        Next
        fntObjName.Dispose()
        brushObjName.Dispose()
        fntDefAtt.Dispose()
        brushDefAtt.Dispose()
    End Sub
    ''' <summary>
    ''' 指定した色・幅でラインを描く
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="MpLine">ライン</param>
    ''' <param name="col">色</param>
    ''' <param name="width">幅</param>
    ''' <param name="EndPointFlag">端点を設定にかかわらず非表示にしたい場合はfalse</param>
    ''' <remarks></remarks>
    Private Sub printOneLine(ByRef g As Graphics, ByRef MpLine As clsMapData.strLine_Data, ByVal col As Color,
                             ByVal width As Integer, Optional ByVal EndPointFlag As Boolean = True)
        '
        Dim xy() As Point
        With MpLine
            If spatial.Compare_Two_Rectangle_Position(MpLine.Circumscribed_Rectangle, ScrData.ScrRectangle) <> cstRectangle_Cross.cstOuter Then
                If MpLine.NumOfTime > 1 Or .LineTimeSTC(0).SETime.StartTime.nullFlag = False Or .LineTimeSTC(0).SETime.EndTime.nullFlag = False Then
                    '時間設定のあるラインは幅を広げる
                    width += 1
                End If
                xy = ScrData.getSxSy(.NumOfPoint, .PointSTC, False, True)
                If xy.Length < 2 Then
                    Return
                End If
                Dim pen As New Pen(col, width)
                pen.LineJoin = Drawing2D.LineCap.Round
                g.DrawLines(New Pen(col, width), xy)
                pen.Dispose()
                If clsSettings.Data.MapEditor.LineEndPointVisible = True And EndPointFlag = True Then
                    Dim EndP As Point = xy(0)
                    EndP.Offset(-2, -2)
                    g.FillRectangle(New SolidBrush(Color.Red), New Rectangle(EndP, New Size(4, 4)))
                    EndP = xy(xy.GetUpperBound(0))
                    EndP.Offset(-2, -2)
                    g.FillRectangle(New SolidBrush(Color.Red), New Rectangle(EndP, New Size(4, 4)))
                End If
            End If
        End With

    End Sub
    ''' <summary>
    ''' オブジェクトグループごとに代表点を描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="Obknum">オブジェクトグループ</param>
    ''' <remarks></remarks>
    Private Sub printCoreByObjectkind(ByRef g As Graphics, ByVal Obknum As Integer)

        Dim col As Color = MapData.ObjectKind(Obknum).Color.getColor
        Dim colTrans = Color.FromArgb(100, col.R, col.G, col.B)
        Dim PenColorBlack = New Pen(Color.FromArgb(255, 0, 0, 0), 1)
        Dim PenColorBlackTrans = New Pen(Color.FromArgb(50, 0, 0, 0), 1)
        Dim brush As New SolidBrush(col)
        Dim brushTrans As New SolidBrush(colTrans)

        For i As Integer = 0 To MapData.Map.Kend - 1
            With MapData.MPObj(i)
                Dim Pen As Pen = PenColorBlack
                If .Kind = Obknum And (objectEnabled(i) = True Or _MapEditor.EditList.unEditableVisible = True) Then
                    Dim b2 As Brush
                    If objectEnabled(i) = True Then
                        b2 = brush
                    Else
                        '編集対象から外れている場合は透過して表示
                        b2 = brushTrans
                        Pen = PenColorBlackTrans
                    End If
                    If spatial.Compare_Two_Rectangle_Position(.Circumscribed_Rectangle, ScrData.ScrRectangle) <> cstRectangle_Cross.cstOuter Then
                        For j As Integer = 0 To .NumOfCenterP - 1
                            Dim size As enmSize
                            If objectEnabled(i) = True Then
                                size = enmSize.Medium
                            Else
                                size = enmSize.Small
                            End If
                            If MapData.ObjectKind(.Kind).ObjectType <> _MapEditor.EditList.ObjectType Then
                                size = enmSize.VerySmall
                            End If
                            printOneCore(g, .CenterPSTC(j).Position, .Shape, b2, Pen, size, False)
                        Next
                    End If
                End If
            End With
        Next

    End Sub
    ''' <summary>
    ''' マウス座標の二時点から地図座標移動量を求める
    ''' </summary>
    ''' <param name="CurrentP">現在の画面座標</param>
    ''' <param name="MouseDownP">ダウン時の画面座標</param>
    ''' <returns>地図座標の移動量</returns>
    ''' <remarks></remarks>
    Private Function Get_srxy_Difference_between_MouseDownPosition_and_CurrentPosition(ByVal CurrentP As Point, ByVal MouseDownP As Point) As SizeF
        Dim CorsorPR As PointF = ScrData.getSRXY(CurrentP)
        Dim MouseDownPR As PointF = ScrData.getSRXY(MouseDownP)
        Return New SizeF(CorsorPR.X - MouseDownPR.X, CorsorPR.Y - MouseDownPR.Y)

    End Function
    ''' <summary>
    ''' オブジェクト編集モードでオブジェクト・ラインドラッグ中の代表点とラインを描く
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="CursorP"></param>
    ''' <param name="MouseDownP"></param>
    ''' <remarks></remarks>
    Private Sub printDraggingObjectLine(ByRef g As Graphics, ByRef CursorP As Point, ByRef MouseDownP As Point)
        For i As Integer = 0 To EditingObject.NumOfCenterP - 1
            printDraggingObjectCore(g, CursorP, MouseDownP, EditingObject, i)
        Next
        Dim dif As SizeF = Get_srxy_Difference_between_MouseDownPosition_and_CurrentPosition(CursorP, MouseDownP)
        For i As Integer = 0 To EditingObject.NumOfLine - 1
            Dim ELineMove As clsMapData.strLine_Data = MapData.MPLine(EditingObject.LineCodeSTC(i).LineCode).Clone
            With ELineMove
                For j As Integer = 0 To .NumOfPoint - 1
                    .PointSTC(j) = PointF.Add(.PointSTC(j), dif)
                Next
            End With
            printOneLine(g, ELineMove, clsSettings.Data.MapEditor.ObjectLineColor.getColor, 2)
        Next
    End Sub
    ''' <summary>
    ''' オブジェクト編集モードで代表点ドラッグ中の代表点を描く
    ''' </summary>
    ''' <param name="g">Graphicsオブジェクト</param>
    ''' <param name="CursorP">カーソルの画面座標</param>
    ''' <param name="MouseDownP">マウスを押した時点の画面座標</param>
    ''' <remarks></remarks>
    Private Sub printDraggingObjectCore(ByRef g As Graphics, ByRef CursorP As Point, ByRef MouseDownP As Point,
                                        ByRef MPobj As clsMapData.strObj_Data, ByVal EditedObjectDragCoreNumer As Integer)
        Dim dif As SizeF = Get_srxy_Difference_between_MouseDownPosition_and_CurrentPosition(CursorP, MouseDownP)
        Dim CP As PointF = MPobj.CenterPSTC(EditedObjectDragCoreNumer).Position

        Dim cpmove As PointF = PointF.Add(CP, dif)

        Dim CoreCol As Color = Color.Red
        Dim PenColorBlack = New Pen(Color.FromArgb(255, 0, 0, 0), 2)
        Dim brush As New SolidBrush(CoreCol)

        printOneCore(g, cpmove, MPobj.Shape, brush, PenColorBlack, enmSize.Large, True, EditedObjectDragCoreNumer)
    End Sub

    ''' <summary>
    ''' 代表点を一つ描く。時空間モードで指定した場合は代表点番号を下に表示
    ''' </summary>
    ''' <param name="g">Graphicsオブジェクト</param>
    ''' <param name="CenterP">地図座標</param>
    ''' <param name="shape">形状</param>
    ''' <param name="Brush">ブラシ</param>
    ''' <param name="Pen">ペン</param>
    ''' <param name="size">enmSizeによるサイズ</param>
    ''' <param name="PrintCenterPNumberF">代表点の番号を表示する場合true（オプションただし時空間モードのみ）</param>
    ''' <param name="CenterPNumber">代表点番号（オプション）</param>
    ''' <remarks></remarks>
    Public Sub printOneCore(ByRef g As Graphics, ByVal CenterP As PointF, ByVal shape As enmShape, _
                             ByVal Brush As Brush, ByVal Pen As Pen, ByVal size As enmSize, _
                                   Optional ByVal PrintCenterPNumberF As Boolean = False, Optional ByVal CenterPNumber As Integer = -1)
        '
        Dim CoreSize As Integer
        Dim cp As Point = ScrData.getSxSy(CenterP)

        Select Case shape
            Case enmShape.PointShape
                CoreSize = 8
                Select Case size
                    Case enmSize.Large
                        CoreSize += 2
                    Case enmSize.Small
                        CoreSize -= 2
                    Case enmSize.VerySmall
                        CoreSize -= 4
                End Select
            Case enmShape.PolygonShape
                CoreSize = 6
                Select Case size
                    Case enmSize.Large
                        CoreSize += 2
                    Case enmSize.Small
                        CoreSize -= 2
                    Case enmSize.VerySmall
                        CoreSize -= 4
                End Select
            Case enmShape.LineShape
                CoreSize = 5
                Select Case size
                    Case enmSize.Large
                        CoreSize += 1
                    Case enmSize.Small
                        CoreSize -= 1
                    Case enmSize.VerySmall
                        CoreSize -= 3
                End Select
        End Select


        Select Case shape
            Case enmShape.PointShape
                Dim rectEllipse As Rectangle
                cp.Offset(-CoreSize \ 2, -CoreSize \ 2)
                rectEllipse = New Rectangle(cp, New Size(CoreSize, CoreSize))
                g.FillEllipse(Brush, rectEllipse)
                g.DrawEllipse(Pen, rectEllipse)
            Case enmShape.PolygonShape
                Dim rect As Rectangle
                cp.Offset(-CoreSize \ 2, -CoreSize \ 2)
                rect = New Rectangle(cp, New Size(CoreSize, CoreSize))
                g.FillRectangle(Brush, rect)
                g.DrawRectangle(Pen, rect)
            Case enmShape.LineShape
                Dim ps As Point() = {New Point(cp.X, cp.Y - CoreSize), _
                        New Point(cp.X + CoreSize, cp.Y + CoreSize), _
                        New Point(cp.X - CoreSize, cp.Y + CoreSize)}
                g.FillPolygon(Brush, ps)
                g.DrawPolygon(Pen, ps)
        End Select
        If MapData.Map.Time_Mode = True And PrintCenterPNumberF = True Then
            '時空間モードで代表点番号を描く場合（編集中のオブジェクト）
            Dim fnt As New Font("MS UI Gothic", clsSettings.Data.MapEditor.ObjectNameSize, GraphicsUnit.Pixel)
            Dim brush2 As New SolidBrush(clsSettings.Data.MapEditor.ObjectNameColor.getColor)
            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Near
            Dim cp2 As Point = cp
            cp2.Offset(0, CoreSize)
            g.DrawString(CenterPNumber, fnt, brush2, cp2, stringFormat)
        End If
    End Sub
    ''' <summary>
    ''' 地図全体表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub showAllMapArea()
        '
        ScrData.init(picMap, New ScreenMargin(3, 3, 3, 3, False), MapData.Map.Circumscribed_Rectangle, enmBasePosition.Screen, True)

        EditMapping(False)
    End Sub
    ''' <summary>
    ''' 集成オブジェクト編集モードで左クリックし、オブジェクトの構成要素となるオブジェクトを選択
    ''' </summary>
    ''' <param name="P">クリックした画面座標</param>
    ''' <remarks></remarks>
    Public Sub selectAggrObjectComponentObject(ByVal P As Point)
        Dim ObjCode() As Integer
        Dim ObjN As Integer = getNearestObject(P, False, ObjCode)
        If ObjN > 0 Then
            '最寄りオブジェクトから、集成オブジェクトで使用されているオブジェクトと、選択可能なオブジェクトを抜き出す
            Dim ObjCode2(ObjN - 1) As Integer
            Dim n As Integer = 0
            For i As Integer = 0 To ObjN - 1
                If checkAggrObjectEnableObject(ObjCode(i)) = True Then
                    ObjCode2(n) = ObjCode(i)
                    n += 1
                End If
            Next
            If n > 0 Then
                ReDim Preserve ObjCode2(n - 1)
                Select Case n
                    Case 1
                        selectAggrObjectComponentObjectSub(ObjCode2(0))
                    Case Else
                        Dim Names(n - 1) As String
                        For i As Integer = 0 To n - 1
                            MapData.Get_Enable_ObjectName(MapData.MPObj(ObjCode2(i)), _MapEditor.EditList.EditTime, True, Names(i))
                        Next
                        Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("構成オブジェクト選択", Names)
                        If sel <> -1 Then
                            selectAggrObjectComponentObjectSub(ObjCode2(sel))
                        End If
                End Select
            End If
        End If
    End Sub
    Private Sub selectAggrObjectComponentObjectSub(ByVal ObjCode As Integer)
        With EditingObject
            Dim f As Boolean = True
            For i As Integer = 0 To .NumOfLine - 1
                If .LineCodeSTC(i).LineCode = ObjCode Then
                    '使用中のオブジェクトをクリックした
                    If MapData.Map.Time_Mode = True Then
                        '時空間モードの場合で使用している場合は、メニューを表示してラインの色を緑色に変える
                        Dim Items As New List(Of String)
                        Items.Add("構成からはずす")
                        Items.Add("構成期間の設定")
                        Dim StacPosition As Integer = i
                        Dim Name As String
                        MapData.Get_Enable_ObjectName(MapData.MPObj(ObjCode), _MapEditor.EditList.EditTime, True, Name)
                        Dim title As String = "構成オブジェクトの設定:" + Name
                        Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult(title, Items)
                        Select Case sel
                            Case 0
                                '時空間モードでオブジェクトの使用しているラインをクリックした際のメニュー表示で「使用しない」
                                For j As Integer = i To .NumOfLine - 2
                                    .LineCodeSTC(j) = .LineCodeSTC(j + 1)
                                Next
                                .NumOfLine -= 1
                                ReDim Preserve .LineCodeSTC(Math.Max(.NumOfLine - 1, 0))
                            Case 1
                                '時空間モードでオブジェクトの使用しているラインをクリックした際のメニュー表示で「構成期間の設定」
                                Dim form As New frmMED_AggrObjUseTime

                                If form.ShowDialog(_MapEditor, StacPosition, EditingObject, MapData) = Windows.Forms.DialogResult.OK Then
                                    EditingObject = form.getResult()
                                    EditMapping(True)
                                    setPropertyOfEditingObject()
                                End If
                                form.Dispose()
                            Case Else
                        End Select
                        f = False
                        Exit For
                    Else
                        '同じラインコードを使用している場合は、使用をやめる
                        For j As Integer = i To .NumOfLine - 2
                            .LineCodeSTC(j) = .LineCodeSTC(j + 1)
                        Next
                        .NumOfLine -= 1
                        ReDim Preserve .LineCodeSTC(Math.Max(.NumOfLine - 1, 0))
                        f = False
                        Exit For
                    End If
                End If
            Next
            If f = True Then
                '未使用ラインの場合、ラインコードスタックを追加する
                ReDim Preserve .LineCodeSTC(.NumOfLine)
                .LineCodeSTC(.NumOfLine).LineCode = ObjCode
                .LineCodeSTC(.NumOfLine).NumOfTime = 0
                ReDim .LineCodeSTC(.NumOfLine).Times(0)
                .NumOfLine += 1
            End If
            .Shape = MapData.Check_Obj_Shape_AllTime(EditingObject)
            'Dim CutPoint As PointF
            ''ポリゴンのオブジェクトグループで、線形状の場合は切れ目座標を設定
            'If .Shape = enmShape.LineShape And MapData.ObjectKind(EditingObject.Kind).Shape = enmShape.PolygonShape Then
            '    CutPointOfPolygon = CutPoint
            'Else
            '    CutPointOfPolygon = Nothing
            'End If
            setPropertyOfEditingObject()
            EditMapping(False)
        End With

    End Sub
    ''' <summary>
    ''' オブジェクト編集モードで左クリックし、オブジェクトの使用するラインを選択
    ''' </summary>
    ''' <param name="P">クリックした画面座標</param>
    ''' <remarks></remarks>
    Public Sub selectObjectLine(ByVal P As Point)
        Dim mline() As Integer
        Dim n As Integer = NearMPLine(P, mline)
        Dim mlineCheck2(n) As Integer
        Dim n2 As Integer = 0
        For i As Integer = 0 To n - 1
            If checkObjectEnableLine(mline(i)) = True Then
                mlineCheck2(n2) = mline(i)
                n2 += 1
            End If
        Next
        If n2 > 0 Then
            ReDim Preserve mlineCheck2(n2 - 1)
            Select Case n2
                Case 1
                    selectObjectLineSub(mlineCheck2(0))
                Case Else
                    Dim Items As New List(Of String)
                    'ラインを選択するメニュー項目を追加()
                    For i As Integer = 0 To n - 1
                        Dim f As Boolean = True
                        With EditingObject
                            For j As Integer = 0 To .NumOfLine - 1
                                If mlineCheck2(i) = .LineCodeSTC(j).LineCode Then
                                    f = False
                                    Exit For
                                End If
                            Next
                        End With
                        Dim tx As String
                        If f = True Then
                            tx = "ライン番号:" + mlineCheck2(i).ToString
                        Else
                            tx = "ライン番号:" + mlineCheck2(i).ToString + "(使用中)"
                        End If
                        Items.Add(tx)
                    Next
                    Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("ライン選択", Items)
                    If sel <> -1 Then
                        selectObjectLineSub(mlineCheck2(sel))
                    End If
            End Select
        End If
    End Sub

    ''' <summary>
    ''' 集成オブジェクトにて、指定したオブジェクト番号が、編集中のオブジェクトで使用されている、または編集中のオブジェクトグループから利用可能か調べ、該当すればtrue
    ''' </summary>
    ''' <param name="ObjCode">オブジェクト番号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkAggrObjectEnableObject(ByVal ObjCode As Integer) As Boolean
        With EditingObject
            For i As Integer = 0 To .NumOfLine - 1
                If .LineCodeSTC(i).LineCode = ObjCode Then
                    '使用中のラインの場合
                    Return True
                End If
            Next
            If MapData.ObjectKind(.Kind).UseObjectGroup(MapData.MPObj(ObjCode).Kind) = True Then
                '編集対象で利用可能の場合
                Return True
            End If
        End With
        Return False
    End Function
    ''' <summary>
    ''' 指定したライン番号のラインが、編集中のオブジェクトで使用されている、または編集中のオブジェクトグループから利用可能か調べ、該当すればtrue
    ''' </summary>
    ''' <param name="LineCode">ライン番号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkObjectEnableLine(ByVal LineCode As Integer) As Boolean
        With EditingObject
            For i As Integer = 0 To .NumOfLine - 1
                If .LineCodeSTC(i).LineCode = LineCode Then
                    '使用中のラインの場合
                    Return True
                End If
            Next
            For i = 0 To MapData.MPLine(LineCode).NumOfTime - 1
                If MapData.ObjectKind(.Kind).UseLineType(MapData.MPLine(LineCode).LineTimeSTC(i).Kind) = True Then
                    '編集対象で利用可能の場合
                    Return True
                    Exit For
                End If
            Next
        End With
        Return False
    End Function


    ''' <summary>
    ''' オブジェクト編集モードでのライン選択サブ
    ''' </summary>
    ''' <param name="LineCode">ライン番号</param>
    ''' <remarks></remarks>
    Private Sub selectObjectLineSub(ByVal LineCode As Integer)

        With EditingObject
            Dim f As Boolean = True
            For i As Integer = 0 To .NumOfLine - 1
                If .LineCodeSTC(i).LineCode = LineCode Then
                    '使用中のラインをクリックした
                    If MapData.Map.Time_Mode = True Then
                        '時空間モードの場合で使用している場合は、メニューを表示してラインの色を緑色に変える
                        Dim canvas As New Bitmap(picMap.Width, picMap.Height)
                        Dim g As Graphics = Graphics.FromImage(canvas)
                        g.DrawImage(picMap.Image, 0, 0)
                        printOneLine(g, MapData.MPLine(LineCode), Color.GreenYellow, 2)
                        picMap.Image = canvas
                        picMap.Refresh()
                        g.Dispose()
                        'canvas.Dispose()
                        Dim Items As New List(Of String)
                        Items.Add("使用しない")
                        Items.Add("使用期間の設定")
                        Dim StacPosition As Integer = i
                        Dim title As String = "使用ラインの設定:" + LineCode.ToString
                        Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult(title, Items)
                        Select Case sel
                            Case 0
                                '時空間モードでオブジェクトの使用しているラインをクリックした際のメニュー表示で「使用しない」
                                For j As Integer = i To .NumOfLine - 2
                                    .LineCodeSTC(j) = .LineCodeSTC(j + 1)
                                Next
                                .NumOfLine -= 1
                                ReDim Preserve .LineCodeSTC(Math.Max(.NumOfLine - 1, 0))
                            Case 1
                                '時空間モードでオブジェクトの使用しているラインをクリックした際のメニュー表示で「使用期間の設定」
                                Dim form As New frmMED_LineCodeTime

                                If form.ShowDialog(_MapEditor, StacPosition, EditingObject, MapData) = Windows.Forms.DialogResult.OK Then
                                    EditingObject = form.getResult()
                                    EditMapping(True)
                                    setPropertyOfEditingObject()
                                End If
                                form.Dispose()
                            Case Else
                        End Select
                        f = False
                        Exit For
                    Else
                        '同じラインコードを使用している場合は、使用をやめる
                        For j As Integer = i To .NumOfLine - 2
                            .LineCodeSTC(j) = .LineCodeSTC(j + 1)
                        Next
                        .NumOfLine -= 1
                        ReDim Preserve .LineCodeSTC(Math.Max(.NumOfLine - 1, 0))
                        f = False
                        Exit For
                    End If
                End If
            Next
            If f = True Then
                '未使用ラインの場合、ラインコードスタックを追加する
                ReDim Preserve .LineCodeSTC(.NumOfLine)
                .LineCodeSTC(.NumOfLine).LineCode = LineCode
                .LineCodeSTC(.NumOfLine).NumOfTime = 0
                ReDim .LineCodeSTC(.NumOfLine).Times(0)
                .NumOfLine += 1
            End If
            Dim CutPoint As PointF
            .Shape = MapData.Check_Obj_Shape_AllTime(EditingObject, CutPoint)
            'ポリゴンのオブジェクトグループで、線形状の場合は切れ目座標を設定
            If .Shape = enmShape.LineShape And MapData.ObjectKind(.Kind).Shape = enmShape.PolygonShape Then
                CutPointOfPolygon = CutPoint
            Else
                CutPointOfPolygon = Nothing
            End If
            setPropertyOfEditingObject()
            EditMapping(False)
        End With
    End Sub

    ''' <summary>
    ''' オブジェクト編集時に代表点またはラインを選択可能になった場合等のラベル表示。通常／修正療法を含む
    ''' </summary>
    ''' <param name="P">画面座標</param>
    ''' <remarks></remarks>
    Public Sub LabelOfObjectEditingMode(ByVal P As Point)
        Dim CenterPP As Integer
        Dim ObjLineDragModeF As Boolean
        Dim coreN As Boolean = selectEditingObjectCore(P, False, CenterPP, ObjLineDragModeF)
        If coreN = True Then
            If ObjLineDragModeF = True Then
                picMap.Cursor = Cursors.SizeAll
            Else
                picMap.Cursor = Cursors.Default
                    Dim tx As String = "代表点"
                    If EditingObject.NumOfCenterP > 1 Then
                        tx += CenterPP.ToString()
                    End If
                    setlblPicMapText(P, tx)
            End If
            Return
        Else
            picMap.Cursor = Cursors.Default
        End If

        Select Case _MapEditor.EditList.ObjectType
            Case clsMapData.enmObjectGoupType_Data.NormalObject
                '通常オブジェクトのラベル表示()
                If EditingObject.Shape = enmShape.LineShape And MapData.ObjectKind(EditingObject.Kind).Shape = enmShape.PolygonShape Then
                    '面オブジェクトのラインの切れ目にマウスカーソルが来た場合にラベルを表示する
                    Dim cp As Point = ScrData.getSxSy(CutPointOfPolygon)
                    Dim d As Single = spatial.get_Distance(P, cp)
                    If d < 5 Then
                        picMap.Cursor = Cursors.Default
                        setlblPicMapText(P, "ラインが途切れています")
                        Exit Sub
                    End If
                End If

                'ラインの上の場合はライン番号を表示する
                Dim mline() As Integer
                Dim n As Integer = NearMPLine(P, mline)
                Dim NearLine(n) As Integer
                Dim n2 As Integer = 0
                For i As Integer = 0 To n - 1
                    If checkObjectEnableLine(mline(i)) = True Then
                        NearLine(n2) = mline(i)
                        n2 += 1
                    End If
                Next
                If n2 > 0 Then
                    ReDim Preserve NearLine(n2 - 1)
                    setlblPicMapText(P, String.Join(vbCrLf, NearLine))
                    Return
                End If
            Case clsMapData.enmObjectGoupType_Data.AggregationObject
                '集成オブジェクトのラベル表示()
                Dim ObjCode() As Integer
                Dim ObjN As Integer = getNearestObject(P, False, ObjCode)
                If ObjN > 0 Then
                    '最寄りオブジェクトから、集成オブジェクトで使用されているオブジェクトと、選択可能なオブジェクトを抜き出す
                    Dim ObjCode2(ObjN - 1) As Integer
                    Dim n As Integer = 0
                    For i As Integer = 0 To ObjN - 1
                        If checkAggrObjectEnableObject(ObjCode(i)) = True Then
                            ObjCode2(n) = ObjCode(i)
                            n += 1
                        End If
                    Next
                    If n > 0 Then
                        'オブジェクト名をラベルに表示する
                        Dim Names(n - 1) As String
                        For i As Integer = 0 To n - 1
                            MapData.Get_Enable_ObjectName(MapData.MPObj(ObjCode2(i)), _MapEditor.EditList.EditTime, True, Names(i))
                        Next
                        setlblPicMapText(P, String.Join(vbCrLf, Names))
                        Exit Sub
                    End If
                End If
        End Select
        _MapEditor.lblPicMap.Visible = False
    End Sub
    ''' <summary>
    ''' 地図上のラベルにテキスト設定と表示
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Private Sub setlblPicMapText(ByVal P As Point, ByVal text As String)
        With _MapEditor
            .lblPicMap.Text = text
            .lblPicMap.Left = P.X + 10
            .lblPicMap.Top = P.Y - .lblPicMap.Height * 1.5
            .lblPicMap.Visible = True
        End With
    End Sub
    ''' <summary>
    ''' オブジェクト選択モード時に、代表点をクリックしたか調べ、そのスタック位置を記録、代表点ドラッグモードに入る
    ''' </summary>
    ''' <param name="P">画面座標</param>
    ''' <param name="CenterDrag_F">trueの場合、そのまま代表点ドラッグモードに入る</param>
    ''' <param name="CenterPPosition">代表点の番号</param>
    ''' <remarks></remarks>
    Public Function selectEditingObjectCore(ByVal P As Point, ByVal CenterDrag_F As Boolean,
                                            Optional ByRef CenterPPosition As Integer = 0, Optional ByRef ObjLineDragModeF As Boolean = False) As Boolean

        Dim minD As Single = 10
        Dim minDLineDrag As Single = 20
        Dim n As Integer = -1

        With EditingObject
            For i As Integer = 0 To .NumOfCenterP - 1
                With .CenterPSTC(i)
                    Dim mp As PointF = ScrData.getSxSy(.Position)
                    Dim d As Single = spatial.get_Distance(P, mp)
                    If d <= minDLineDrag Then
                        minDLineDrag = d
                        n = i
                    End If
                End With
            Next
        End With
        Dim f As Boolean
        If _MapEditor.EditList.Object_and_Line_DragEnabled = True And n <> -1 And minD < minDLineDrag Then
            ObjLineDragModeF = True
            If CenterDrag_F = True Then
                _MapEditor.EditingMode_ObjectSub = _MapEditor.EditingModes_ObjectSub.Object_and_Line_DragMode
            End If
            f = True
        Else
            Select Case n
                Case -1
                    f = False
                Case Else
                    If CenterDrag_F = True Then
                        _MapEditor.EditingMode_ObjectSub = _MapEditor.EditingModes_ObjectSub.ObjectCoreDragMode
                        EditedObjectDragCoreNumer = n
                    Else
                        CenterPPosition = n
                    End If
                    f = True
            End Select
        End If
        Return f
    End Function


    ''' <summary>
    ''' 編集対象のオブジェクトタイプと異なるオブジェクトを削除して戻す
    ''' </summary>
    ''' <param name="n">元の数</param>
    ''' <param name="ObjCode">オブジェクト番号（入力値および戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Overloads Function removeDifferentObjectType(ByVal n As Integer, ByRef ObjCode() As Integer) As Integer
        Dim i As Integer = 0
        Do
            If MapData.ObjectKind(MapData.MPObj(ObjCode(i)).Kind).ObjectType <> _MapEditor.EditList.ObjectType Then
                For j As Integer = i + 1 To n - 1
                    ObjCode(j - 1) = ObjCode(j)
                Next
                n -= 1
                i -= 1
            End If
            i += 1
        Loop While i < n
        ReDim Preserve ObjCode(Math.Max(n - 1, 0))
        Return n
    End Function
    ''' <summary>
    ''' 編集対象のオブジェクトタイプと異なるオブジェクトを削除して戻す
    ''' </summary>
    ''' <param name="ObjCode">オブジェクト番号List（入力値および戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Overloads Function removeDifferentObjectType(ByRef ObjCode As List(Of Integer))

        For i As Integer = ObjCode.Count - 1 To 0 Step -1
            If MapData.ObjectKind(MapData.MPObj(ObjCode.Item(i)).Kind).ObjectType <> _MapEditor.EditList.ObjectType Then
                ObjCode.RemoveAt(i)
            End If
        Next
    End Function
    ''' <summary>
    ''' ライン検索モードで左クリックし、オブジェクトを選択
    ''' </summary>
    ''' <param name="P">クリックした画面座標</param>
    ''' <remarks></remarks>
    Public Sub selectLine(ByVal P As Point)

        Dim NearLine() As Integer
        Dim n As Integer = NearMPLine(P, NearLine)
        Select Case n
            Case 0
                '見つからず
            Case 1
                '一つ見つかった場合はそのまま編集モードに
                Select Case _MapEditor.EditingMode
                    Case frmMapEditor.editingModes.LineSearchingMode
                        setEditingLine(MapData.MPLine(NearLine(0)))
                    Case frmMapEditor.editingModes.MultiLinesEditingMode
                        setEditingMultiLine(NearLine(0))
                End Select
            Case Else
                '二つ以上の場合はメニューを出して選択させる
                Dim Items As New List(Of String)
                For i As Integer = 0 To n - 1
                    Dim tx As String
                    Items.Add("ライン番号：" + NearLine(i).ToString)
                Next
                Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("ライン選択", Items)
                If sel <> -1 Then
                    Select Case _MapEditor.EditingMode
                        Case frmMapEditor.editingModes.LineSearchingMode
                            setEditingLine(MapData.MPLine(NearLine(sel)))
                        Case frmMapEditor.editingModes.MultiLinesEditingMode
                            setEditingMultiLine(NearLine(sel))
                    End Select
                End If
        End Select

    End Sub


    ''' <summary>
    ''' オブジェクト検索モード、複数オブジェクト編集モードで左クリックし、オブジェクトを選択
    ''' </summary>
    ''' <param name="P">クリックした画面座標</param>
    ''' <remarks></remarks>
    Public Sub selectObject(ByVal P As Point)

        Dim objs() As Integer
        Dim n As Integer = getNearestObjectWithLine(P, True, objs)

        If 0 < n Then
            n = removeDifferentObjectType(n, objs)
        End If

        Select Case n
            Case 0
                '見つからず
            Case 1
                '一つ見つかった場合はそのまま編集モードに
                Select Case _MapEditor.EditingMode
                    Case frmMapEditor.editingModes.ObjectSearchingMode
                        setEditingObject(MapData.MPObj(objs(0)))
                    Case frmMapEditor.editingModes.MultiObjectsEditingMode
                        setEditingMultiObject(objs(0))
                    Case frmMapEditor.editingModes.Set_ClickObjectName
                        Set_ClickObjectNameSelObj(MapData.MPObj(objs(0)))
                End Select
            Case Else
                '二つ以上の場合はメニューを出して選択させる
                Dim Items As New List(Of String)
                For i As Integer = 0 To n - 1
                    Dim tx As String
                    MapData.Get_Enable_ObjectName(MapData.MPObj(objs(i)), _MapEditor.EditList.EditTime, True, tx)
                    Items.Add(tx)
                Next
                Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("オブジェクト選択", Items)
                If sel <> -1 Then
                    Select Case _MapEditor.EditingMode
                        Case frmMapEditor.editingModes.ObjectSearchingMode
                            setEditingObject(MapData.MPObj(objs(sel)))
                        Case frmMapEditor.editingModes.MultiObjectsEditingMode
                            setEditingMultiObject(objs(sel))
                        Case frmMapEditor.editingModes.Set_ClickObjectName
                            Set_ClickObjectNameSelObj(MapData.MPObj(objs(sel)))
                    End Select
                End If
        End Select
    End Sub
    ''' <summary>
    ''' オブジェクト名検索
    ''' </summary>
    ''' <param name="ObjCodes"></param>
    ''' <remarks></remarks>
    Public Sub SearchObjectSelect(ByVal ObjCodes() As Integer)

        Dim n As Integer = ObjCodes.GetUpperBound(0) + 1
        If n = 1 Then
            If objectEnabled(ObjCodes(0)) = False Then
                Dim msgText As String = "指定したオブジェクトは選択対象から外れています。"
                MsgBox(msgText, MsgBoxStyle.Exclamation)
            Else
                Search_Object_Show(ObjCodes(0))
            End If
        ElseIf n > 1 Then
            SearchMultiObjectSelect(ObjCodes)
        End If

    End Sub
    ''' <summary>
    ''' 検索した1つのオブジェクトを表示
    ''' </summary>
    ''' <param name="code"></param>
    ''' <remarks></remarks>
    Private Sub Search_Object_Show(ByVal code As Integer)
        Dim w As Single, H As Single, cx As Single, cy As Single

        With MapData.MPObj(code)
            Select Case .Shape
                Case enmShape.PointShape
                    With ScrData.ScrView
                        w = .Width
                        H = .Height
                    End With
                    With .Circumscribed_Rectangle
                        cx = (.Right + .Left) / 2
                        cy = (.Bottom + .Top) / 2
                    End With
                    ScrData.ScrView = New RectangleF(cx - w / 2, cy - H / 2, w, H)
                Case enmShape.LineShape, enmShape.PolygonShape
                    With .Circumscribed_Rectangle
                        w = .Width
                        H = .Height
                        If w = 0 And H = 0 Then
                            w = ScrData.ScrView.Width
                            H = ScrData.ScrView.Height
                        ElseIf w = 0 Then
                            w = H
                        ElseIf H = 0 Then
                            H = w
                        End If
                        ScrData.ScrView = New RectangleF(.Left - w, .Top - H, w * 3, H * 3)
                    End With
            End Select
        End With
        setEditingObject(MapData.MPObj(code))

    End Sub
    ''' <summary>
    ''' オブジェクト名複数検索
    ''' </summary>
    ''' <param name="ObjCodes"></param>
    ''' <remarks></remarks>
    Private Sub SearchMultiObjectSelect(ByVal ObjCodes() As Integer)
        Dim n As Integer = ObjCodes.GetUpperBound(0) + 1
        Dim tx As String = ""
        Dim CodesArrray As New List(Of Integer)
        For i As Integer = 0 To n - 1
            If objectEnabled(ObjCodes(i)) = False Then
                Dim name As String
                MapData.Get_Enable_ObjectName(MapData.MPObj(ObjCodes(i)), _MapEditor.EditList.EditTime, True, name)
                tx += vbCrLf + name
            Else
                CodesArrray.Add(ObjCodes(i))
            End If
        Next
        If tx <> "" Then
            Dim msgText As String = "以下のオブジェクトは選択対象から外れています。" + tx
            MsgBox(msgText, MsgBoxStyle.Exclamation)
        End If
        If CodesArrray.Count > 0 Then
            _MapEditor.tsbMultiSelect.Checked = True
            setEditingMultiObject(CodesArrray)
        End If

    End Sub

    ''' <summary>
    ''' 複数ライン編集モードで画面クリックでライン追加・削除
    ''' </summary>
    ''' <param name="Code">ライン番号</param>
    ''' <remarks></remarks>
    Private Sub setEditingMultiLine(ByVal Code As Integer)
        If EditingMultiLine.Contains(Code) = True Then
            EditingMultiLine.RemoveAt(EditingMultiLine.IndexOf(Code))
        Else
            EditingMultiLine.Add(Code)
        End If
        SetMultiLineInformation()
        EditMapping(False)
    End Sub
    Private Sub setEditingMultiLine(ByVal Codes As List(Of Integer))
        For i As Integer = 0 To Codes.Count - 1
            If EditingMultiLine.Contains(Codes.Item(i)) = True Then
                EditingMultiLine.RemoveAt(EditingMultiLine.IndexOf(Codes.Item(i)))
            Else
                EditingMultiLine.Add(Codes.Item(i))
            End If
        Next
        SetMultiLineInformation()
        EditMapping(False)
    End Sub
    ''' <summary>
    ''' 複数オブジェクト編集モードで画面クリックでオフジェクト追加・削除
    ''' </summary>
    ''' <param name="Code">オブジェクト番号</param>
    ''' <remarks></remarks>
    Private Sub setEditingMultiObject(ByVal Code As Integer)
        If EditingMultiObject.Contains(Code) = True Then
            EditingMultiObject.RemoveAt(EditingMultiObject.IndexOf(Code))
        Else
            EditingMultiObject.Add(Code)
        End If
        SetMultiObJInformation()
        EditMapping(False)
    End Sub
    Private Sub setEditingMultiObject(ByVal Codes As List(Of Integer))
        For i As Integer = 0 To Codes.Count - 1
            If EditingMultiObject.Contains(Codes.Item(i)) = True Then
                EditingMultiObject.RemoveAt(EditingMultiObject.IndexOf(Codes.Item(i)))
            Else
                EditingMultiObject.Add(Codes.Item(i))
            End If
        Next
        SetMultiObJInformation()
        EditMapping(False)
    End Sub
    ''' <summary>
    ''' ラインを選択して編集モードに
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <remarks></remarks>
    Public Sub setEditingLine(ByVal Line As clsMapData.strLine_Data)
        EditingLine = Line.Clone

        With _MapEditor

            If MapData.Map.Time_Mode = False Then
                '非時空間モードの地図
                .pnlLineTimekindSet.Visible = False
                .pnlLineKind.Visible = True
                .cboLineKind.Items.Clear()
                .cboLineKind.Items.AddRange(MapData.Get_LineKindNameList)
                .cboLineKind.SelectedIndex = EditingLine.LineTimeSTC(0).Kind
            Else
                '時空間モードの地図
                .pnlLineKind.Visible = False
                .pnlLineTimekindSet.Visible = True
                Dim tx As String = ""
                For i As Integer = 0 To EditingLine.NumOfTime - 1
                    tx += clsGeneric.getTimeList(EditingLine.LineTimeSTC(i), MapData, vbCrLf + " ")
                    If i <> EditingLine.NumOfTime - 1 Then
                        tx += vbCrLf
                    End If
                Next
                .tbLineKindTime.Text = tx
            End If
            LastSavedLineKind = EditingLine.LineTimeSTC(0).Kind
            .EditingMode = frmMapEditor.editingModes.LineEditingMode
            .EditingMode_LineSub = frmMapEditor.EditingModes_LineSub.SearchMode
            setRightPanelVisible()
            setPropertyOfEditingLine()

            setTabstripButtonAndMenuEnabled()
            .scPropertyAndDefAttribute.SplitterDistance = .scPropertyAndDefAttribute.Height
            If EditingLine.Number = -1 Then
                .btnLineDelete.Enabled = False
            Else
                .btnLineDelete.Enabled = True
            End If
        End With
        EditMapping(True)
    End Sub
    ''' <summary>
    ''' オブジェクトを選択して編集モードに
    ''' </summary>
    ''' <param name="Obj">オブジェクト</param>
    ''' <remarks></remarks>
    Private Sub setEditingObject(ByVal Obj As clsMapData.strObj_Data)

        EditingObject = Obj.Clone()
        With _MapEditor
            .EditingMode = frmMapEditor.editingModes.ObjectEditingMode
            setTabstripButtonAndMenuEnabled()
            If .EditList.ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                .EditingMode_ObjectSub = frmMapEditor.EditingModes_ObjectSub.AggregationObjectSelectMode
            Else
                .EditingMode_ObjectSub = frmMapEditor.EditingModes_ObjectSub.LineSelectMode
            End If
            setRightPanelVisible()
            If MapData.Map.Time_Mode = False Then
                '非時空間モードの地図
                clsGeneric.setObjectNameToKTGrid(_MapEditor.ktObjectName, MapData.ObjectKind, EditingObject.Kind, EditingObject.NameTimeSTC(0).NamesList)
                .cboObjectKind.Items.Clear()
                .cboObjectKind.Items.AddRange(MapData.Get_ObjectGroupNameList)
                .cboObjectKind.SelectedIndex = EditingObject.Kind
                If MapData.ObjectKind(Obj.Kind).Shape = enmShape.PolygonShape Then
                    .btnAutoBoundary.Enabled = True
                    .btnCenterGrabityPoint.Enabled = True
                Else
                    .btnAutoBoundary.Enabled = False
                    .btnCenterGrabityPoint.Enabled = False
                End If
                If .EditList.ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                    .btnAutoBoundary.Enabled = False
                End If
                If EditingObject.Number = -1 Then
                    .btnObjectDelete.Enabled = False
                Else
                    .btnObjectDelete.Enabled = True
                End If
            Else
                '時空間モードの地図
                .pnlObjectTimeEdit.Visible = True
                Dim tx As String = ""
                For i As Integer = 0 To EditingObject.NumOfNameTime - 1
                    tx += clsGeneric.getTimeList(EditingObject.NameTimeSTC(i), vbCrLf + " ")
                    If i <> EditingObject.NumOfNameTime - 1 Then
                        tx += vbCrLf
                    End If
                Next
                .tbObjectNameTime.Text = tx
                .cbObjectGroupTime.Items.Clear()
                For i As Integer = 0 To MapData.Map.OBKNum - 1
                    .cbObjectGroupTime.Items.Add(MapData.ObjectKind(i).Name)
                Next
                .cbObjectGroupTime.SelectedIndex = EditingObject.Kind
                If EditingObject.Number = -1 Then
                    .btnObjectDeleteTime.Enabled = False
                Else
                    .btnObjectDeleteTime.Enabled = True
                End If
            End If
            Dim CutPoint As PointF
            EditingObject.Shape = MapData.Check_Obj_Shape_AllTime(EditingObject, CutPoint)
            If EditingObject.Shape = enmShape.LineShape And MapData.ObjectKind(EditingObject.Kind).Shape = enmShape.PolygonShape Then
                CutPointOfPolygon = CutPoint
            Else
                CutPointOfPolygon = Nothing
            End If
            setPropertyOfEditingObject()
            If MapData.ObjectKind(Obj.Kind).DefTimeAttDataNum > 0 Then
                setDefAttributeOfEditingObject()
            End If
            .gbObjTypeEdit.Enabled = False
        End With
        EditMapping(False)
    End Sub
    ''' <summary>
    ''' 編集中ラインのプロパティをマップエディタのプロパティウィンドウに入れる
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setPropertyOfEditingLine()

        Dim lvData As New List(Of String)
        lvData.Add("項目" + vbTab + "値" + vbTab + "値")
        With EditingLine
            If .Number = -1 Then
                lvData.Add("ライン番号" + vbTab + "新規")
            Else
                lvData.Add("ライン番号" + vbTab + .Number.ToString)
            End If
            lvData.Add("両端" + vbTab + clsGeneric.getLineConnectStrings(.Connect))
            lvData.Add("ポイント数" + vbTab + .NumOfPoint.ToString)
            Dim OCode() As Integer
            Dim lunum = MapData.Get_Object_UsingLine(.Number, OCode)
            lvData.Add("オブジェクトによる使用回数" + vbTab + lunum.ToString)
            For i As Integer = 0 To lunum - 1
                With MapData.MPObj(OCode(i))
                    Dim name As String
                    MapData.Get_Enable_ObjectName(MapData.MPObj(OCode(i)), _MapEditor.EditList.EditTime, True, name)
                    lvData.Add("使用オブジェクト番号:" + OCode(i).ToString + vbTab + name)
                End With
            Next

        End With
        _MapEditor.lvtPropertyWindow.SetData(lvData, {VariantType.String, VariantType.String, VariantType.String}, {True, False, False}, False)

    End Sub
    ''' <summary>
    ''' 複数ライン選択の選択オブジェクトの情報をプロパティウィンドウに入れる
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMultiLineInformation()
        Dim lvData As New List(Of String)
        lvData.Add("ライン番号" + vbTab + "線種")
        lvData.Add("選択ライン数" + vbTab + EditingMultiLine.Count.ToString)
        For Each i As Integer In EditingMultiLine
            Dim LK As String = ""
            For j As Integer = 0 To MapData.MPLine(i).NumOfTime - 1
                LK += MapData.LineKind(MapData.MPLine(i).LineTimeSTC(j).Kind).Name
                If j <> MapData.MPLine(i).NumOfTime - 1 Then
                    LK += "/"
                End If
            Next
            lvData.Add(i.ToString + vbTab + LK)
        Next
        _MapEditor.lvtPropertyWindow.SetData(lvData, {VariantType.String, VariantType.String}, {False, False}, False)

    End Sub
    ''' <summary>
    ''' 複数オブジェクト選択の選択オブジェクトの情報をプロパティウィンドウに入れる
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMultiObJInformation()
        Dim lvData As New List(Of String)
        lvData.Add("オブジェクト番号" + vbTab + "オブジェクト名" + vbTab + "形状")
        lvData.Add("選択オブジェクト数" + vbTab + EditingMultiObject.Count.ToString + vbTab)
        Dim Ar As New List(Of clsMapData.strObj_Data)
        For i As Integer = 0 To EditingMultiObject.Count - 1
            Dim Name As String
            Ar.Add(MapData.MPObj(EditingMultiObject.Item(i)))
            MapData.Get_Enable_ObjectName(MapData.MPObj(EditingMultiObject.Item(i)), _MapEditor.EditList.EditTime, True, Name)
            lvData.Add(EditingMultiObject.Item(i).ToString + vbTab + Name + vbTab + clsGeneric.ConvertShapeEnumString(MapData.MPObj(EditingMultiObject.Item(i)).Shape))
        Next
        _MapEditor.EditList.Object_and_Line_DragEnabled = MapData.Check_ObjectUseLine_UsedOtherObject(Ar)

        _MapEditor.lvtPropertyWindow.SetData(lvData, {VariantType.String, VariantType.String, VariantType.String}, {False, False, False}, False)

    End Sub
    ''' <summary>
    ''' 編集中オブジェクトのプロパティをマップエディタのプロパティウィンドウに入れる
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setPropertyOfEditingObject()
        Dim lvData As New List(Of String)
        lvData.Add("項目" + vbTab + "値" + vbTab + "値")
        With EditingObject
            If .Number = -1 Then
                lvData.Add("オブジェクト番号" + vbTab + "新規")
            Else
                lvData.Add("オブジェクト番号" + vbTab + .Number.ToString)
            End If
            lvData.Add("形状" + vbTab + clsGeneric.ConvertShapeEnumString(.Shape))
            _MapEditor.EditList.Object_and_Line_DragEnabled = False
            If MapData.Map.Time_Mode = False Then
                Dim cp As PointF = .CenterPSTC(0).Position
                Dim cp2 = spatial.Get_Reverse_XY(cp, MapData.Map.Zahyo)
                lvData.Add("代表点" +
                           "(" + clsGeneric.getZahyoModeYString(MapData.Map.Zahyo.Mode) + "/" + clsGeneric.getZahyoModeXString(MapData.Map.Zahyo.Mode) + ")" +
                            vbTab + cp2.Y.ToString + vbTab + cp2.X.ToString)
            Else
                lvData.Add("オブジェクト名の設定数" + vbTab + .NumOfNameTime.ToString)
                lvData.Add("代表点の設定数" + vbTab + .NumOfCenterP.ToString)
                For i As Integer = 0 To .NumOfCenterP - 1
                    Dim cp As PointF = .CenterPSTC(i).Position
                    Dim cp2 = spatial.Get_Reverse_XY(cp, MapData.Map.Zahyo)
                    lvData.Add("代表点" + Chr(Asc("A") + i) +
                               "(" + clsGeneric.getZahyoModeYString(MapData.Map.Zahyo.Mode) + "/" + clsGeneric.getZahyoModeXString(MapData.Map.Zahyo.Mode) + ")" +
                                vbTab + cp2.Y.ToString + vbTab + cp2.X.ToString)
                Next
            End If
            Select Case MapData.ObjectKind(.Kind).ObjectType
                Case clsMapData.enmObjectGoupType_Data.NormalObject
                    lvData.Add("ライン数" + vbTab + .NumOfLine.ToString)
                    For i As Integer = 0 To EditingObject.NumOfLine - 1
                        lvData.Add("使用ライン番号" + vbTab + .LineCodeSTC(i).LineCode.ToString)
                    Next
                    Dim Ar As New List(Of clsMapData.strObj_Data)
                    Ar.Add(EditingObject)
                    _MapEditor.EditList.Object_and_Line_DragEnabled = MapData.Check_ObjectUseLine_UsedOtherObject(Ar)
                Case clsMapData.enmObjectGoupType_Data.AggregationObject
                    lvData.Add("構成オブジェクト数" + vbTab + .NumOfLine.ToString)
                    For i As Integer = 0 To EditingObject.NumOfLine - 1
                        Dim name As String()
                        MapData.Get_Enable_ObjectName(MapData.MPObj(.LineCodeSTC(i).LineCode), _MapEditor.EditList.EditTime, True, name)
                        lvData.Add("構成オブジェクト" + vbTab + Join(name, "/"))
                    Next
            End Select
            If MapData.Map.Time_Mode = True Then
                lvData.Add("継承先オブジェクト数" + vbTab + .NumOfSuc.ToString)
                For i As Integer = 0 To .NumOfSuc - 1
                    Dim n12 As String = ""
                    MapData.Get_Enable_ObjectName(MapData.MPObj(.SucSTC(i).ObjectCode), .SucSTC(i).Time, False, n12)
                    lvData.Add("継承先" + vbTab + n12 + vbTab + clsTime.YMDtoString(.SucSTC(i).Time))
                Next
                Dim hen_obj() As clsMapData.Hennyu_Data
                Dim hen_n As Integer = MapData.Get_Hennyu_Object(EditingObject, hen_obj)
                lvData.Add("オブジェクトの編入数  " + vbTab + hen_n.ToString)
                For i As Integer = 0 To hen_n - 1
                    With hen_obj(i)
                        Dim tx As String = "編入オブジェクト" + vbTab
                        tx += .Name
                        If .Part = True Then
                            tx += "の一部"
                        End If
                        tx += vbTab + clsTime.YMDtoString(.Time)
                        lvData.Add(tx)
                    End With
                Next
            End If
            Dim Aggr_Object_Used As List(Of Integer) = MapData.Get_Aggregation_Object(EditingObject.Number)
            If Aggr_Object_Used.Count > 0 Then
                lvData.Add("集成オブジェクトの構成要素" + vbTab + Aggr_Object_Used.Count.ToString)
                For Each i As Integer In Aggr_Object_Used
                    Dim n12 As String = ""
                    MapData.Get_Enable_ObjectName(MapData.MPObj(i), _MapEditor.EditList.EditTime, True, n12)
                    lvData.Add("使用されているオブジェクト" + vbTab + n12 + vbTab)
                Next
            End If
        End With
        _MapEditor.lvtPropertyWindow.SetData(lvData, {VariantType.String, VariantType.String, VariantType.String}, {True, False, False}, False)

    End Sub

    ''' <summary>
    ''' 選択したオブジェクトの初期属性をデータグリッドビューに設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setDefAttributeOfEditingObject()
        Dim kind As Integer = EditingObject.Kind
        If MapData.Map.Time_Mode = False Then
            Dim n As Integer = MapData.ObjectKind(kind).DefTimeAttDataNum
            If n = 0 Then
                Return
            End If
            With _MapEditor.ktGridDefAttValue
                .init("データ", "初期属性データ", "値", 2, 0, 1, 0, True, True, True, False, False, False, False, False, False, False)
                .AddLayer("", 0, 1, n)
                For i As Integer = 0 To n - 1
                    .FixedXSData(0, 0, i) = MapData.ObjectKind(kind).DefTimeAttSTC(i).attData.Title
                    .FixedXSData(0, 1, i) = MapData.ObjectKind(kind).DefTimeAttSTC(i).attData.Unit
                    .GridData(0, 0, i) = EditingObject.DefTimeAttValue(i).Data(0).Value
                Next
                .FixedXSWidth(0, 0) = 100
                .FixedXSWidth(0, 1) = 50
                .FixedXSAllignment(0, 0) = HorizontalAlignment.Left
                .FixedXSAllignment(0, 1) = HorizontalAlignment.Left
                .GridWidth(0, 0) = 100
                .GridAlligntment(0, 0) = HorizontalAlignment.Left
                .FixedUpperLeftData(0, 0, 0) = "データ項目"
                .FixedUpperLeftData(0, 1, 0) = "単位"
                .FixedYSData(0, 0, 0) = "値"
                .Show()
            End With
        Else
            setSetDefTimeAttrDataValue()
        End If
    End Sub
    ''' <summary>
    ''' 初期時間属性をプロパティにセット
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setSetDefTimeAttrDataValue()
        Dim kind As Integer = EditingObject.Kind
        Dim n As Integer = 0
        Dim tx As New List(Of String)
        Dim num As New List(Of Integer)
        With MapData.ObjectKind(kind)
            For i As Integer = 0 To .DefTimeAttDataNum - 1
                Dim un As String = .DefTimeAttSTC(i).attData.Unit
                If un <> "" Then
                    un = "（" + un + "）"
                End If
                tx.Add(.DefTimeAttSTC(i).attData.Title + un)
                num.Add(i * 1000)
                If EditingObject.DefTimeAttValue(i).Data Is Nothing = False Then
                    Dim dt() As clsMapData.strDefTimeAttDataEach_Info = EditingObject.DefTimeAttValue(i).Data
                    For j As Integer = 0 To EditingObject.DefTimeAttValue(i).Data.Length - 1
                        Dim timetx As String = ""
                        Select Case .DefTimeAttSTC(i).Type
                            Case clsMapData.enmDefTimeAttDataType.PointData
                                timetx = clsTime.YMDtoString(dt(j).Span.StartTime)
                            Case clsMapData.enmDefTimeAttDataType.SpanData
                                timetx = clsTime.StartEndtoString(dt(j).Span)
                        End Select
                        timetx = dt(j).Value + "【" + timetx + "】"
                        tx.Add(timetx)
                        num.Add(i * 1000 + 1)
                    Next
                End If
                tx.Add("")
                num.Add(i * 1000 + 1)
            Next
        End With
        With _MapEditor.ktGridDefAttValue
            .init("データ", "初期属性データ", "", 1, 0, 1, 0, False, True, False, False, False, False, False, False, False, False)
            .AddLayer("", 0, 1, num.Count)
            .GridAlligntment(0, 0) = HorizontalAlignment.Left
            .FixedXSWidth(0, 0) = 10
            .GridWidth(0, 0) = .Width - 30
            .GridColorReset(0)
            For i As Integer = 0 To num.Count - 1
                .GridData(0, 0, i) = tx(i)
                .FixedXSData(0, 0, i) = num(i).ToString
                If num(i) Mod 1000 = 0 Then
                    .GridColor(0, 0, i) = Color.Yellow
                End If
            Next
            .Show()
        End With

    End Sub
    ''' <summary>
    ''' 時空間モードで初期属性がクリックさりた場合は編集画面へ
    ''' </summary>
    ''' <param name="y"></param>
    ''' <remarks></remarks>
    Public Sub SetDefTimeAttrData(ByVal y As Integer)
        Dim p As Integer = Val(_MapEditor.ktGridDefAttValue.FixedXSData(0, 0, y)) \ 1000
        Dim form As New frmMED_DefTimeAttDataObjectEdit
        If form.ShowDialog(_MapEditor, MapData, EditingObject, MapData.ObjectKind(EditingObject.Kind).DefTimeAttSTC(p),
                           EditingObject.DefTimeAttValue(p).Data) = Windows.Forms.DialogResult.OK Then
            EditingObject.DefTimeAttValue(p).Data = form.getResult
            setSetDefTimeAttrDataValue()
        End If
        form.Dispose()

    End Sub
    ''' <summary>
    ''' 編集中のEditingObjectオブジェクトを削除する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub deleteEditingObject()
        If EditingObject.Number <> -1 Then
            Dim n12 As String = ""
            MapData.Get_Enable_ObjectName(EditingObject, _MapEditor.EditList.EditTime, True, n12)
            MapEditorUndo.SetUndo_EraseObject(MapData.MPObj(EditingObject.Number), MapData.Map.Circumscribed_Rectangle)
            MapData.EraseObject(EditingObject.Number, True)
            cancelEditingObject()
        End If
    End Sub
    ''' <summary>
    ''' 編集中のEditingLineラインを削除する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub deleteEditingLine()
        If EditingLine.Number <> -1 Then
            Dim n12 As String = ""
            MapData.Get_Enable_ObjectName(EditingObject, _MapEditor.EditList.EditTime, True, n12)
            MapEditorUndo.SetUndo_EraseLine(MapData.MPLine(EditingLine.Number), MapData.Map.Circumscribed_Rectangle)
            MapData.Erase_Line(EditingLine.Number, True)
            cancelEditingLine()
        End If
    End Sub
    ''' <summary>
    ''' オブジェクトを登録してオブジェクト選択モードに
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub registEditingObject()
        If Check_Regist_object() = True Then
            With _MapEditor
                If MapData.Map.Time_Mode = False Then
                    EditingObject.Kind = .cboObjectKind.SelectedIndex

                Else
                    EditingObject.Kind = .cbObjectGroupTime.SelectedIndex
                End If
                Dim n As Integer = MapData.ObjectKind(EditingObject.Kind).DefTimeAttDataNum
                If MapData.Map.Time_Mode = False Then
                    For i As Integer = 0 To n - 1
                        EditingObject.DefTimeAttValue(i).Data(0).Value = .ktGridDefAttValue.GridData(0, 0, i)
                    Next
                End If
                LastSavedObjectKind = EditingObject.Kind
            End With
            If EditingObject.Number = -1 Then
                ReDim Preserve objectEnabled(MapData.Map.Kend)
                objectEnabled(MapData.Map.Kend) = True
                MapEditorUndo.SetUndo_AddObject("オブジェクトの新規登録", MapData.Map.Kend, MapData.Map.Circumscribed_Rectangle)
            Else
                MapEditorUndo.SetUndo_SaveObject("オブジェクトの登録", MapData.MPObj(EditingObject.Number), MapData.Map.Circumscribed_Rectangle)
            End If
            MapData.Save_Object(EditingObject, True)

            cancelEditingObject()
        End If
    End Sub
    ''' <summary>
    ''' ラインを登録してライン選択モードに
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub registEditingLine()

        With _MapEditor
            If MapData.Map.Time_Mode = False Then
                EditingLine.LineTimeSTC(0).Kind = .cboLineKind.SelectedIndex
                LastSavedLineKind = .cboLineKind.SelectedIndex
            End If
        End With
        If EditingLine.Number = -1 Then
            ReDim Preserve lineEnabled(MapData.Map.ALIN)
            lineEnabled(MapData.Map.ALIN) = True
            MapEditorUndo.SetUndo_AddLine(MapData.Map.ALIN, MapData.Map.Circumscribed_Rectangle)
        Else
            MapEditorUndo.SetUndo_SaveLine(MapData.MPLine(EditingLine.Number), MapData.Map.Circumscribed_Rectangle)
        End If
        MapData.Save_Line(EditingLine, True, True, True)

        cancelEditingLine()
    End Sub
    ''' <summary>
    ''' オブジェクトグループコンボボックスが変更された場合にチェックする
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub checkCboObjectKindChange(ByRef sender As System.Object)

        Dim newK As Integer = sender.SelectedIndex
        If EditingObject.Kind = newK Then
            Return
        End If

        Dim EditObk As clsMapData.strObjectGroup_Data = MapData.ObjectKind(EditingObject.Kind)
        Dim NewObk As clsMapData.strObjectGroup_Data = MapData.ObjectKind(newK)

        If NewObk.ObjectType <> EditObk.ObjectType Then
            Dim msgText As String = "オブジェクトグループタイプが異なるので変更できません。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            sender.SelectedIndex = EditingObject.Kind
            Return
        End If

        If NewObk.Shape <> EditObk.Shape Then
            Dim msgText As String = "オブジェクトグループの形状が異なりますが、変更しますか?"
            If MsgBox(msgText, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                sender.SelectedIndex = EditingObject.Kind
                Return
            End If
        End If

        If NewObk.ObjectNameNum <> EditObk.ObjectNameNum Then
            Dim msgText As String = "オブジェクト名リスト数が異なるオブジェクトグループが選択されていますが、変更しますか?"
            If MsgBox(msgText, vbYesNo) = MsgBoxResult.No Then
                sender.SelectedIndex = EditingObject.Kind
                Return
            Else
                For i As Integer = 0 To EditingObject.NumOfNameTime - 1
                    ReDim Preserve EditingObject.NameTimeSTC(i).NamesList(NewObk.ObjectNameNum - 1)
                Next
            End If
        End If
        If NewObk.DefTimeAttDataNum <> EditObk.DefTimeAttDataNum Then
            Dim msgText As String = "初期属性数が異なるオブジェクトグループが選択されていますが、変更しますか?"
            If MsgBox(msgText, vbYesNo) = MsgBoxResult.No Then
                sender.SelectedIndex = EditingObject.Kind
                Return
            Else
                Dim atn = NewObk.DefTimeAttDataNum
                If atn = 0 Then
                    Erase EditingObject.DefTimeAttValue
                Else
                    ReDim EditingObject.DefTimeAttValue(atn - 1)
                    For i As Integer = 0 To atn - 1
                        ReDim EditingObject.DefTimeAttValue(i).Data(0)
                    Next
                End If
            End If
        End If
        EditingObject.Kind = newK
        EditingObject.Shape = MapData.Check_Obj_Shape_AllTime(EditingObject)
        setEditingObject(EditingObject)
    End Sub
    ''' <summary>
    ''' オブジェクト登録時のチェック、登録しない場合はFalseを返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_Regist_object() As Boolean


        If MapData.Map.Time_Mode = False Then
            EditingObject.NumOfNameTime = 1
            If clsGeneric.getObjectNameFromKtgrid(_MapEditor.ktObjectName, EditingObject.NameTimeSTC(0).NamesList) = False Then
                MsgBox("オブジェクト名を指定して下さい。", MsgBoxStyle.Exclamation)
                Return False
            End If

        End If

        Dim nameex As Boolean = False
        For i As Integer = 0 To EditingObject.NumOfNameTime - 1
            With EditingObject.NameTimeSTC(i)
                For j As Integer = 0 To .NamesList.Length - 1
                    If .NamesList(j) <> "" Then
                        nameex = True
                        Dim nameuse As Integer = MapData.Check_ObjectName_OverLap_In_MapFile(EditingObject.Number, .NamesList(j), .SETime)
                        If nameuse <> -1 Then
                            Dim msgText As String = .NamesList(j) & "が他のオブジェクトでも使用されています。" & vbCrLf & "このままオブジェクトを登録しますか？"
                            If MsgBox(msgText, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                Return False
                            End If
                        End If
                    End If
                Next
            End With
        Next
        If nameex = False Then
            MsgBox("オブジェクト名を指定して下さい。", MsgBoxStyle.Exclamation)
            Return False
        End If

        Dim Emes$
        Dim elc$
        Dim NormalObj_F As Boolean
        Dim LKF As Boolean = True
        If MapData.ObjectKind(EditingObject.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
            NormalObj_F = True
        End If
        If NormalObj_F = True Then
            elc$ = "線種に問題のあるライン番号" & vbCrLf
        Else
            elc$ = "使用グループに問題のあるオブジェクト番号" & vbCrLf
        End If
        For i As Integer = 0 To EditingObject.NumOfLine - 1
            With EditingObject.LineCodeSTC(i)
                Dim lc As Integer = .LineCode
                If NormalObj_F = True Then
                    If MapData.MPLine(lc).NumOfTime = 1 Then
                        If MapData.ObjectKind(EditingObject.Kind).UseLineType(MapData.MPLine(lc).LineTimeSTC(0).Kind) = False Then
                            elc$ = elc$ & lc & vbCrLf
                            LKF = False
                        End If
                    Else
                        Dim f As Boolean = False
                        If .NumOfTime = 0 Then
                            For k = 0 To MapData.MPLine(lc).NumOfTime - 1
                                With MapData.MPLine(lc).LineTimeSTC(k)
                                    If MapData.ObjectKind(EditingObject.Kind).UseLineType(.Kind) = True Then
                                        f = True
                                        k = MapData.MPLine(lc).NumOfTime
                                    End If
                                End With
                            Next
                        Else
                            For j = 0 To .NumOfTime - 1
                                Dim set1 As Start_End_Time_data = .Times(j)
                                For k = 0 To MapData.MPLine(lc).NumOfTime - 1
                                    With MapData.MPLine(lc).LineTimeSTC(k)
                                        If MapData.ObjectKind(EditingObject.Kind).UseLineType(.Kind) = True Then
                                            If clsTime.Check_Duration_OK(set1, .SETime) = True Then
                                                f = True
                                                k = MapData.MPLine(lc).NumOfTime
                                            End If
                                        End If
                                    End With
                                Next
                            Next
                        End If
                        If f = False Then
                            LKF = False
                            elc$ = elc$ & lc & vbCrLf
                        End If
                    End If
                Else
                    If MapData.ObjectKind(EditingObject.Kind).UseObjectGroup(MapData.MPObj(lc).Kind) = False Then
                        elc$ = elc$ & lc & vbCrLf
                        LKF = False
                    End If
                End If
            End With
        Next
        If LKF = False Then
            Emes$ = "オブジェクトグループ「" & MapData.ObjectKind(EditingObject.Kind).Name & "」で使用しない"
            If NormalObj_F = True Then
                Emes$ = Emes$ & "線種"
            Else
                Emes$ = Emes$ & "オブジェクトグループ"
            End If
            Emes$ = Emes$ & "が含まれています。" & vbCrLf & elc$ & vbCrLf & "このままオブジェクトを登録しますか？"
            If MsgBox(Emes$, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return False
            End If
        End If

        With EditingObject
            .Shape = MapData.Check_Obj_Shape_AllTime(EditingObject)
            If .Shape <> MapData.ObjectKind(.Kind).Shape And MapData.ObjectKind(.Kind).Shape <> -1 Then
                Dim msgText As String = "オブジェクトグループで設定した形状と、オブジェクトの形状が異なっています。" & vbCrLf & _
                    "このままオブジェクトを登録しますか？"
                If MsgBox(msgText, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Return False
                End If
            End If

            If MapData.check_Line_or_Aggrobj_DoubleUse(EditingObject) = False Then
                If NormalObj_F = True Then
                    Dim msgText As String = "重複して使用していたラインはまとめました。"
                    MsgBox(msgText, MsgBoxStyle.MsgBoxRight)
                Else
                    Dim msgText As String = "重複して使用していたオブジェクトはまとめました。"
                    MsgBox(msgText, MsgBoxStyle.MsgBoxRight)
                End If
            End If
        End With
        Return True
    End Function
    Public Sub cancelEditingObject()
        'オブジェクト編集をキャンセルしてオブジェクト選択モードに

        With _MapEditor
            .EditingMode = frmMapEditor.editingModes.ObjectSearchingMode
            setTabstripButtonAndMenuEnabled()
            setRightPanelVisible()
            .gbObjTypeEdit.Enabled = True
        End With
        EditMapping(True)

    End Sub

    Public Sub cancelEditingLine()
        'ライン編集をキャンセルしてライン選択モードに
        _MapEditor.EditingMode = frmMapEditor.editingModes.LineSearchingMode
        With _MapEditor
            setTabstripButtonAndMenuEnabled()
            setRightPanelVisible()
        End With
        EditMapping(True)

    End Sub

    ''' <summary>
    ''' マウスホイールによる拡大縮小、中心点と拡大率を指定して描画
    ''' </summary>
    ''' <param name="centerPoint">ホイールの回転した位置の座標（pictureboxの座標）</param>
    ''' <param name="WheelDelta">ホイールの回転方向</param>
    ''' <remarks></remarks>
    Public Sub changeViewScale(ByRef centerPoint As Point, ByVal WheelDelta As Integer)

        picMapImageOperation.pictureBoxMouseWheel(centerPoint, WheelDelta, ScrData)
        EditMapping(False)

    End Sub
    Private Sub CheckObjectEdit()
        'オブジェクトまたはラインが編集対象に含まれるかチェック

        ReDim objectEnabled(MapData.Map.Kend - 1)
        For i As Integer = 0 To MapData.Map.Kend - 1
            With MapData.MPObj(i)
                Dim v As Boolean = _MapEditor.EditList.ObjectKind(.Kind)
                Select Case .Shape
                    Case enmShape.PolygonShape
                        If _MapEditor.EditList.PolygonShape = False Then
                            v = False
                        End If
                    Case enmShape.LineShape
                        If _MapEditor.EditList.LineShape = False Then
                            v = False
                        End If
                    Case enmShape.PointShape
                        If _MapEditor.EditList.PointShape = False Then
                            v = False
                        End If
                End Select

                If _MapEditor.EditList.EditTime.nullFlag = False Then
                    If MapData.CheckEnableObject(MapData.MPObj(i), _MapEditor.EditList.EditTime) = False Then
                        v = False
                    End If
                End If
                objectEnabled(i) = v
            End With
        Next

        ReDim lineEnabled(MapData.Map.ALIN - 1)
        For i As Integer = 0 To MapData.Map.ALIN - 1
            lineEnabled(i) = EditedLineCheckOne(MapData.MPLine(i))
        Next
        If _MapEditor.EditList.EditedLineTime_Flag = True And _MapEditor.EditList.EditTime.nullFlag = False Then
            '設定時期にラインがオブジェクトに使われているかチェック
            Dim LF(MapData.Map.ALIN) As Boolean
            For i = 0 To MapData.Map.Kend - 1
                With MapData.MPObj(i)
                    If objectEnabled(i) = True And MapData.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                        For j = 0 To .NumOfLine - 1
                            Dim k As Integer = MapData.Check_Enable_LineCode(.LineCodeSTC(j), _MapEditor.EditList.EditTime)
                            If k <> -1 Then
                                LF(k) = True
                            End If
                        Next
                    End If
                End With
            Next

            For i = 0 To MapData.Map.ALIN - 1
                If lineEnabled(i) = True Then
                    If LF(i) = False Then
                        If MapData.MPLine(i).NumOfLineUse = 0 And _MapEditor.EditList.LineObjectNoUsed = True Then
                        Else
                            lineEnabled(i) = False
                        End If
                    Else
                        If MapData.Check_Enable_Line(MapData.MPLine(i), _MapEditor.EditList.EditTime) = -1 Then
                            lineEnabled(i) = False
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Private Function EditedLineCheckOne(ByVal Mpline As clsMapData.strLine_Data) As Boolean
        'ラインが編集対象に入るかチェック
        Dim f As Boolean
        Dim f2 As Boolean, f3 As Boolean

        With Mpline
            f = False
            '線種のチェック
            For i As Integer = 0 To .NumOfTime - 1
                If _MapEditor.EditList.LineKind(.LineTimeSTC(i).Kind) = True Then
                    f = True
                    Exit For
                End If
            Next
            If f = True Then
                '結節数のチェック
                Select Case .Connect
                    Case enmLineConnect.no
                        f2 = _MapEditor.EditList.LineNonConnected
                    Case enmLineConnect.both
                        f2 = _MapEditor.EditList.LineBothConnected
                    Case enmLineConnect.one
                        f2 = _MapEditor.EditList.LineOneConnected
                    Case enmLineConnect.loopen
                        f2 = _MapEditor.EditList.LineLoop
                End Select
                If f2 = True Then
                    'オブジェクト使用回数のチェック
                    Select Case .NumOfLineUse
                        Case 0
                            f3 = _MapEditor.EditList.LineObjectNoUsed
                        Case 1
                            f3 = _MapEditor.EditList.LineObjectOneUsed
                        Case 2
                            f3 = _MapEditor.EditList.LineObjectSecondUsed
                        Case Else
                            f3 = _MapEditor.EditList.LineObjectThirdUsed
                    End Select
                    If f3 = True Then
                        Return True
                    End If
                End If
            End If
        End With
        Return False
    End Function
    Private Sub LineIndexMake()
        Dim eRange As Single
        eRange = 25

        LineIndex = New clsSpatialIndexSearch
        With ScrData.MapScreen_Scale
            LineIndex.Init(SpatialPointType.SPILine, True, .Left, .Top, .Right, .Bottom, eRange)
        End With

        For i As Integer = 0 To MapData.Map.ALIN - 1
            If lineEnabled(i) = True Then
                If spatial.Compare_Two_Rectangle_Position(MapData.MPLine(i).Circumscribed_Rectangle, ScrData.ScrRectangle) <> cstRectangle_Cross.cstOuter Then
                    With MapData.MPLine(i)
                        Dim dxy() As Point = ScrData.getSxSy(.NumOfPoint, .PointSTC, False, True)
                        Dim newn As Integer = dxy.Length
                        Dim dxy2(newn - 1) As PointF
                        For j As Integer = 0 To newn - 1
                            dxy2(j) = dxy(j)
                        Next
                        LineIndex.AddLine(dxy.Length, dxy2, i)
                    End With
                End If
            ElseIf _MapEditor.EditList.unEditableVisible = True Then
            End If
        Next
        LineIndex.AddEnd()

    End Sub
    Private Function getLineSearchIndex(ByRef BoundingBox As RectangleF) As clsSpatialIndexSearch
        Dim eRange As Single
        eRange = ScrData.Get_MapDataSize_from_ScreenPixcel(25)

        Dim LineSearchIndex As New clsSpatialIndexSearch
        With MapData.Map.Circumscribed_Rectangle

            LineIndex.Init(SpatialPointType.SPILine, True, .Left, .Top, .Right, .Bottom, eRange)
        End With

        For i As Integer = 0 To MapData.Map.ALIN - 1
            If lineEnabled(i) = True Then
                If spatial.Compare_Two_Rectangle_Position(MapData.MPLine(i).Circumscribed_Rectangle, BoundingBox) <> cstRectangle_Cross.cstOuter Then
                    LineIndex.AddLine(MapData.MPLine(i).NumOfPoint, MapData.MPLine(i).PointSTC, i)
                End If
            ElseIf _MapEditor.EditList.unEditableVisible = True Then
            End If
        Next
        LineIndex.AddEnd()
        Return LineIndex
    End Function
    Private Sub PointIndexMake()
        'オブジェクトの代表点を空間インデックスに
        Dim eRange As Single = 10

        PointIndex = New clsSpatialIndexSearch

        With ScrData.MapScreen_Scale
            PointIndex.Init(SpatialPointType.SinglePoint, True, .Left, .Top, .Right, .Bottom, eRange)
        End With

        For i As Integer = 0 To MapData.Map.Kend - 1
            If objectEnabled(i) = True Then
                With MapData.MPObj(i)
                    If spatial.Compare_Two_Rectangle_Position(MapData.MPObj(i).Circumscribed_Rectangle, ScrData.ScrRectangle) <> cstRectangle_Cross.cstOuter Then
                        Dim XY(.NumOfCenterP - 1) As PointF
                        For j As Integer = 0 To .NumOfCenterP - 1
                            XY(j) = ScrData.getSxSy(.CenterPSTC(j).Position)
                        Next
                        PointIndex.AddMultiPoint(.NumOfCenterP, XY, i)
                    End If
                End With
            End If
        Next
        PointIndex.AddEnd()
    End Sub
    ''' <summary>
    ''' 最寄りラインを検索して線種名を返す
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="LineKindNames">線種名配列（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getNearestLineKineName(ByVal P As Point, ByRef NearLineCode() As Integer, ByRef LineKindNames() As String,
                                Optional ByVal DragZoneCheckF As Boolean = False, Optional ByRef DragZoneFlag As Boolean = False) As String
        Dim Names() As String

        Dim n As Integer = NearMPLine(P, NearLineCode, DragZoneCheckF, DragZoneFlag)
        If n > 0 Then
            ReDim Names(n - 1)
            For i As Integer = 0 To n - 1
                Dim lk As Integer = getLineKindbyTime(MapData.MPLine(NearLineCode(i)), _MapEditor.EditList.EditTime)
                Names(i) = NearLineCode(i).ToString + ":" + MapData.LineKind(lk).Name
            Next
        End If
        LineKindNames = Names
        Return n
    End Function
    Private Function getLineKindbyTime(ByRef Line As clsMapData.strLine_Data, ByVal time As strYMD) As Integer
        '指定した時期のラインの線種番号を取得
        Dim n As Integer
        With Line
            If time.nullFlag = True Then
                '時期指定がない場合は最後の線種
                n = .NumOfTime - 1
            Else
                For i As Integer = 0 To .NumOfTime - 1
                    If clsTime.checkDurationIn(.LineTimeSTC(i).SETime, time) = True Then
                        n = i
                        Exit For
                    End If
                Next
            End If
            With .LineTimeSTC(n)
                Return .Kind
            End With
        End With
    End Function

    ''' <summary>
    ''' 最寄りオブジェクトのオブジェクト名を取得して数を返す
    ''' </summary>
    ''' <param name="P">画面座標</param>
    ''' <param name="Check_ObjKindType">オブジェクトのタイプが現在の編集対象と同じ者を取得する場合true</param>
    ''' <param name="ObjName">取得したオブジェクト名配列（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getNearestObjectName(ByVal P As Point, ByVal Check_ObjKindType As Boolean, _
                                         ByRef ObjName() As String,
                                Optional ByVal DragZoneCheckF As Boolean = False, Optional ByRef DragZoneFlag As Boolean = False) As Integer

        Dim Names() As String
        Dim ObjCodes() As Integer
        Dim n = getNearestObjectWithLine(P, Check_ObjKindType, ObjCodes, DragZoneCheckF, DragZoneFlag)
        If n > 0 Then
            ReDim Names(n - 1)
            For i As Integer = 0 To n - 1
                MapData.Get_Enable_ObjectName(MapData.MPObj(ObjCodes(i)), _MapEditor.EditList.EditTime, True, Names(i))
            Next
            ObjName = Names
        End If
        Return n
    End Function
    ''' <summary>
    ''' 最寄りオブジェクトのを代表点と使用するラインから検索して数を返す。集成オブジェクトの場合はラインからの検索は行わない。
    ''' </summary>
    ''' <param name="P">画面座標</param>
    ''' <param name="Check_ObjKindType">オブジェクトのタイプが現在の編集対象と同じ者を取得する場合true</param>
    ''' <param name="ObjCodes">取得したオブジェクト番号配列（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getNearestObjectWithLine(ByVal P As Point, ByVal Check_ObjKindType As Boolean,
                                ByRef ObjCodes() As Integer,
                                Optional ByVal DragZoneCheckF As Boolean = False, Optional ByRef DragZoneFlag As Boolean = False) As Integer
        '

        Dim n As Integer = getNearestObject(P, Check_ObjKindType, ObjCodes, DragZoneCheckF, DragZoneFlag)

        If n = 0 And _MapEditor.EditList.ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
            '代表点がない場合で、通常のオブジェクトの選択モードの場合は、ラインを調べて使用するオブジェクトを求める
            Dim mline() As Integer
            Dim lineN As Integer = NearMPLine(P, mline, DragZoneCheckF, DragZoneFlag)
            If lineN > 0 Then
                Dim useNLine As Integer = 0
                For i As Integer = 0 To lineN - 1
                    Dim objLineCode() As Integer
                    Dim useN As Integer = getObjectUsingLine(mline(i), objLineCode)
                    If useN > 0 Then
                        ReDim Preserve ObjCodes(useNLine + useN - 1)
                        For j As Integer = 0 To useN - 1
                            ObjCodes(useNLine + j) = objLineCode(j)
                        Next
                        useNLine += useN
                    End If
                Next
                n = useNLine
            End If
        End If
        Return n
    End Function
    ''' <summary>
    ''' 指定したライン番号を使用しているオブジェクトを求めて数を返す
    ''' </summary>
    ''' <param name="Linenum">ライン番号</param>
    ''' <param name="MpObjectCodes">オブジェクト番号配列（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getObjectUsingLine(ByVal Linenum As Integer, ByRef MpObjectCodes() As Integer) As Integer

        ReDim MpObjectCodes(0)
        Dim n As Integer
        For i As Integer = 0 To MapData.Map.Kend - 1
            If objectEnabled(i) = True Then
                If MapData.ObjectKind(MapData.MPObj(i).Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                    For j As Integer = 0 To MapData.MPObj(i).NumOfLine - 1
                        If MapData.MPObj(i).LineCodeSTC(j).LineCode = Linenum Then
                            ReDim Preserve MpObjectCodes(n)
                            MpObjectCodes(n) = i
                            n += 1
                            Exit For
                        End If
                    Next
                End If

            End If
        Next
        Return n
    End Function
    ''' <summary>
    ''' ある地点から最も近いオブジェクトの代表点を空間インデックスから検索してオブジェクト番号を返す
    ''' </summary>
    ''' <param name="P">画面座標</param>
    ''' <param name="Check_ObjKindType">オブジェクトタイプをチェックする場合true</param>
    ''' <param name="MpObjectCodes">オブジェクト番号の配列（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getNearestObject(ByVal P As Point, ByVal Check_ObjKindType As Boolean, _
                                      ByRef MpObjectCodes() As Integer,
                                Optional ByVal DragZoneCheckF As Boolean = False, Optional ByRef DragZoneFlag As Boolean = False) As Integer

        Dim ObStac() As Integer
        Dim PStac() As Integer
        Dim ObCodeNumber() As Integer
        Dim same_N As Integer

        Dim BaseDistance As Single
        Dim BaseDistance2 As Single
        If DragZoneCheckF = True Then
            BaseDistance = 25 'ScrData.Get_MapDataSize_from_ScreenPixcel(25)
            BaseDistance2 = 8 'ScrData.Get_MapDataSize_from_ScreenPixcel(8)
        Else
            BaseDistance = 8 'ScrData.Get_MapDataSize_from_ScreenPixcel(8)
        End If
        Dim minD As Single
        same_N = PointIndex.GetNearestPointNumber(P.X, P.Y, BaseDistance, ObStac, PStac, ObCodeNumber, minD)
        If DragZoneCheckF = True And same_N > 0 Then
            If BaseDistance2 < minD Then
                DragZoneFlag = True
            Else
                DragZoneFlag = False
            End If
        End If
        If Check_ObjKindType = True And same_N > 0 Then
            same_N = removeDifferentObjectType(same_N, ObCodeNumber)
        End If

        If same_N > 0 Then
            MpObjectCodes = ObCodeNumber
        End If
        Return same_N
    End Function
    ''' <summary>
    ''' ある地点から最も近いラインの番号とそのポイントを取得
    ''' </summary>
    ''' <param name="P">地図座標</param>
    ''' <param name="MpLineCode">取得したラインコード配列（戻り値）</param>
    ''' <param name="NearPointStac">ライン上の最も近い地点の前の点スタック位置（戻り値）</param>
    ''' <param name="NearestPoint">ライン上の最も近い地点の座標（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function NearMPLine_with_Point(ByVal P As PointF, _
               ByRef MpLineCode() As Integer, ByRef NearPointStac() As Integer, ByRef NearestPoint() As PointF) As Integer

        Dim ObStac() As Integer
        Dim D As Single
        Dim BaseDistance As Single = ScrData.Get_MapDataSize_from_ScreenPixcel(25)
        Dim same_N As Integer = LineIndex.GetNearestLineNumber(P.X, P.Y, BaseDistance, ObStac, NearPointStac, MpLineCode, D, NearestPoint)


        Return same_N

    End Function

    ''' <summary>
    ''' ある地点から最も近いラインの番号を取得
    ''' </summary>
    ''' <param name="P">画面座標</param>
    ''' <param name="MpLineCode">取得したラインコード配列（戻り値）</param>
    ''' <param name="DragZoneCheckF">ドラッグ可能ゾーンをチェックする場合true（オプション）</param>
    ''' <param name="DragZoneFlag">ドラッグ可能ゾーンの場合true（戻り値・オプション）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function NearMPLine(ByVal P As Point, ByRef MpLineCode() As Integer,
                                Optional ByVal DragZoneCheckF As Boolean = False, Optional ByRef DragZoneFlag As Boolean = False) As Integer

        Dim ObStac() As Integer
        Dim PStac() As Integer
        Dim NearestPoint() As PointF
        Dim D As Single
        Dim BaseDistance As Single
        Dim BaseDistance2 As Single
        If DragZoneCheckF = True Then
            BaseDistance = 25
            BaseDistance2 = 8
        Else
            BaseDistance = 8
        End If
        Dim same_N As Integer = LineIndex.GetNearestLineNumber(P.X, P.Y, BaseDistance, ObStac, PStac, MpLineCode, D, NearestPoint)
        If DragZoneCheckF = True And same_N > 0 Then
            If BaseDistance2 < D Then
                DragZoneFlag = True
            Else
                DragZoneFlag = False
            End If
        End If

        Return same_N

    End Function



    Sub Check_ALl_Line_Connect()


        Dim PointIndex As New clsSpatialIndexSearch
        Dim PNumber() As Integer, Tags() As Integer, LNumber() As Integer


        'ProgressLabel.Start(1, "ライン結合チェック")

        PointIndex.Init(SpatialPointType.SinglePoint, False)
        For i As Integer = 0 To MapData.Map.ALIN - 1
            With MapData.MPLine(i)
                If .NumOfPoint > 0 Then
                    PointIndex.AddDoublePoint(.PointSTC(0), .PointSTC(.NumOfPoint - 1), i)
                End If
            End With
        Next
        PointIndex.AddEnd()
        For i As Integer = 0 To MapData.Map.ALIN - 1
            With MapData.MPLine(i)
                If .NumOfPoint > 0 Then
                    If .PointSTC(0).Equals(.PointSTC(.NumOfPoint - 1)) = True Then
                        .Connect = 3
                    Else
                        .Connect = 0
                        For j As Integer = 0 To 1
                            Dim n As Integer = PointIndex.GetSamePointNumberAlley(.PointSTC(j * (.NumOfPoint - 1)).X, .PointSTC(j * (.NumOfPoint - 1)).Y, _
                                     LNumber, PNumber, Tags)
                            For k As Integer = 0 To n - 1
                                If LNumber(k) <> i Then
                                    .Connect += 1
                                    Exit For
                                End If
                            Next
                        Next
                    End If
                End If
            End With
        Next


        'ProgressLabel.Visible = False

    End Sub
    Private Structure ConnectedLine_Info
        Public LineCode As Integer
        Public DIR As Integer
        Public NextP As PointF
        Public XXYY As PointF
    End Structure
    ''' <summary>
    ''' 編集中オブジェクトの代表点を重心に設定する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub centerPointGravity()

        If EditingObject.Shape <> enmShape.PolygonShape Then
            MsgBox("オブジェクトの形状が面になっていません。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim f As Boolean = MapData.GetObjGraviityXY(EditingObject, EditingObject.CenterPSTC(0).Position, clsTime.GetNullYMD)
        If f = False Then
            Dim msgText = "重心を取得できませんでした。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
        Else
            EditMapping(True)
        End If
    End Sub
    ''' <summary>
    ''' 編集中のオブジェクトに対して境界線自動設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Boundary_Auto()

        If MapData.Check_PolyShape_PolygonNum(EditingObject, clsTime.GetNullYMD) > 1 Then
            Dim msgText As String = "複数のポリゴンから構成されていますが、よろしいですか？"
            If MsgBox(msgText, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Dim LinePointIndex As New clsSpatialIndexSearch

        With MapData.Map.Circumscribed_Rectangle
            LinePointIndex.Init(SpatialPointType.SinglePoint, False, .Left, .Top, .Right, .Bottom, 0)
        End With
        For i As Integer = 0 To MapData.Map.ALIN - 1
            With MapData.MPLine(i)
                If lineEnabled(i) = True And MapData.ObjectKind(EditingObject.Kind).UseLineType(.LineTimeSTC(0).Kind) = True And .NumOfPoint > 0 Then
                    LinePointIndex.AddDoublePoint(.PointSTC(0), .PointSTC(.NumOfPoint - 1), i)
                End If
            End With
        Next
        LinePointIndex.AddEnd()
        Dim PLine() As Integer
        Dim ln As Integer = 0

        If Peripheri(EditingObject.CenterPSTC(0).Position, ln, PLine, EditingObject.Kind, LinePointIndex) = False Then
            Dim msgText = "境界線を確定できませんでした。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            With EditingObject
                ReDim .LineCodeSTC(ln - 1)
                For i As Integer = 0 To ln - 1
                    .LineCodeSTC(i).LineCode = PLine(i)
                    .LineCodeSTC(i).NumOfTime = 0
                Next
                .NumOfLine = ln
                .Shape = enmShape.PolygonShape
            End With
            EditMapping(True)
            setPropertyOfEditingObject()
        End If

    End Sub
    ''' <summary>
    ''' 調査地点を囲むように境界線自動設定、できなかった場合はFalse
    ''' </summary>
    ''' <param name="checkPoint">調査地点の地図座標</param>
    ''' <param name="lcN">取得ライン数（戻り値）</param>
    ''' <param name="PLine">取得ライン（戻り値）</param>
    ''' <param name="Object_Kind">オブジェクトグループ</param>
    ''' <param name="LinePointIndex">調査対象ラインの起終点を入れた空間インデックス</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Peripheri(ByVal checkPoint As PointF, ByRef lcN As Integer, ByRef PLine() As Integer, _
                       ByVal Object_Kind As Integer, ByRef LinePointIndex As clsSpatialIndexSearch) As Boolean
        '

        Dim SYMX As Single = checkPoint.X
        Dim SYMY As Single = checkPoint.Y
        Dim XY1 As PointF, XY2 As PointF, endxy As PointF
        Dim L_Code As Integer, L_CodePoint As Integer

        Dim Connect_Line(5) As ConnectedLine_Info
        ReDim PLine(30)

        '調査地点のすぐ上のライン番号を取得
        Dim pf As Boolean = Peripheri_preparation(SYMX, SYMY, L_Code, L_CodePoint, Object_Kind)
        If pf = False Then
            Return False
        End If

        Dim lineCode As Integer

        With MapData.MPLine(L_Code)
            If .PointSTC(L_CodePoint + 1).X > .PointSTC(L_CodePoint).X Then
                endxy = .PointSTC(.NumOfPoint - 1)
                XY1 = .PointSTC(1)
                XY2 = .PointSTC(0)
            Else
                endxy = .PointSTC(0)
                XY1 = .PointSTC(.NumOfPoint - 2)
                XY2 = .PointSTC(.NumOfPoint - 1)
            End If
            lineCode = L_Code
            lcN = 1
            PLine(0) = L_Code
        End With
        If XY2.Equals(endxy) = True Then
            Return True 'ループの場合
        End If

        Dim PeripheriF As Boolean = True
        Do
            Dim connectPointNum As Integer = 0
            Dim Objn() As Integer, Pnum() As Integer, Tags() As Integer
            Dim SPN As Integer = LinePointIndex.GetSamePointNumberAlley(XY2.X, XY2.Y, Objn, Pnum, Tags)
            If SPN <> -1 Then
                ReDim Connect_Line(SPN)
                connectPointNum = 0
                For i As Integer = 0 To SPN - 1
                    Dim f As Boolean = False
                    If Tags(i) <> lineCode And MapData.ObjectKind(Object_Kind).UseLineType(MapData.MPLine(Tags(i)).LineTimeSTC(0).Kind) = True Then
                        f = True
                        For j As Integer = 0 To lcN - 1
                            If Tags(i) = PLine(j) Then
                                f = False '二度同じラインは使用しない
                                Exit For
                            End If
                        Next
                    End If

                    If f = True Then
                        With Connect_Line(connectPointNum)
                            .LineCode = Tags(i)
                            If Pnum(i) = 0 Then
                                .DIR = 1
                                .NextP = MapData.MPLine(Tags(i)).PointSTC(1)
                            Else
                                .DIR = -1
                                .NextP = MapData.MPLine(Tags(i)).PointSTC(MapData.MPLine(Tags(i)).NumOfPoint - 2)
                            End If
                        End With
                        connectPointNum += 1
                    End If
                Next
            End If


            Dim br As Integer

            Select Case connectPointNum
                Case 0  '接続なし
                    PeripheriF = False
                    Exit Do
                Case 1 '一本だけ接続
                    br = 0
                Case Else '複数が接続する場合は、一本を選択する
                    Dim n As Integer = connectPointNum
                    XY2.Y = XY2.Y - XY1.Y
                    XY2.X = XY2.X - XY1.X
                    For i As Integer = 0 To n - 1
                        With Connect_Line(i).NextP
                            .X = .X - XY1.X
                            .Y = .Y - XY1.Y
                        End With
                    Next
                    Dim D As Single, COA As Single, SIA As Single, X2D As Single, Y2D As Single
                    With XY2
                        D = Math.Sqrt(.X * .X + .Y * .Y)
                        COA = -.X / D
                        SIA = .Y / D
                        X2D = COA * .X - SIA * .Y
                        Y2D = SIA * .X + COA * .Y 'Y2Dは常に0
                    End With
                    For i As Integer = 0 To n - 1
                        With Connect_Line(i)
                            .XXYY.X = COA * .NextP.X - SIA * .NextP.Y
                            .XXYY.Y = SIA * .NextP.X + COA * .NextP.Y
                            .XXYY.X = .XXYY.X - X2D
                        End With
                    Next


                    Dim AG1 As Single = 361
                    For i As Integer = 0 To n - 1
                        With Connect_Line(i).XXYY
                            D = Math.Sqrt(.X ^ 2 + .Y ^ 2)
                            If D <> 0 Then
                                Dim mc1 As Single = .X / D
                                Dim s As Single = .Y / D
                                Dim AG2 As Single = clsGeneric.Angle(s, mc1)
                                If AG2 < AG1 Then
                                    AG1 = AG2
                                    br = i
                                End If
                            End If
                        End With
                    Next
            End Select

            If PLine.GetUpperBound(0) < lcN Then
                ReDim Preserve PLine(lcN + 10)
            End If
            lineCode = Connect_Line(br).LineCode
            PLine(lcN) = lineCode
            If lcN > 2 Then
                If lineCode = PLine(lcN - 2) Then
                    PeripheriF = False
                    Exit Do
                End If
            End If
            lcN += 1
            If Connect_Line(br).DIR = -1 Then
                With MapData.MPLine(lineCode)
                    XY2 = .PointSTC(0)
                    XY1 = .PointSTC(1)
                End With
            Else
                With MapData.MPLine(lineCode)
                    XY2 = .PointSTC(.NumOfPoint - 1)
                    XY1 = .PointSTC(.NumOfPoint - 2)
                End With
            End If
        Loop Until XY2.Equals(endxy) = True
        Return PeripheriF

    End Function
    ''' <summary>
    ''' 調査地点からの垂線を引き、最も近い上側のライン番号を取得する、取得できなかった場合はfalseを返す
    ''' </summary>
    ''' <param name="SYMX">調査地点の地図座標X</param>
    ''' <param name="SYMY">調査地点の地図座標Y</param>
    ''' <param name="L_Code">上側のライン番号（戻り値）</param>
    ''' <param name="L_CodePoint">ライン中のポイント位置（戻り値）</param>
    ''' <param name="Object_Kind">オブジェクトグループ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Peripheri_preparation(ByVal SYMX As Single, ByVal SYMY As Single, ByRef L_Code As Integer, _
                                           ByRef L_CodePoint As Integer, ByVal Object_Kind As Integer) As Boolean
        '

        Dim AH(50) As Single, IE(50) As Integer, IE2(50) As Integer

        Dim Peripheri_preparation_f As Boolean
        Dim c As Integer = 0
        Do
            For i As Integer = 0 To MapData.Map.ALIN - 1
                With MapData.MPLine(i)
                    Dim k As Integer = .LineTimeSTC(0).Kind
                    If .Circumscribed_Rectangle.Right < SYMX Or .Circumscribed_Rectangle.Left > SYMX Or .Circumscribed_Rectangle.Top > SYMY Or _
                        lineEnabled(i) = False Or MapData.ObjectKind(Object_Kind).UseLineType(k) = False Then
                        'ラインが調査地点の上方ではない場合はチェックしない
                    Else
                        Dim f As Boolean = False
                        Dim nj As Integer
                        Dim m As Single
                        For j As Integer = 0 To .NumOfPoint - 2
                            If Math.Min(.PointSTC(j).X, .PointSTC(j + 1).X) > SYMX Or Math.Max(.PointSTC(j).X, .PointSTC(j + 1).X) < SYMX Then
                                'ラインのポイント間のX座標が調査地点のX座標を挟まない場合はチェックしない
                            Else
                                Dim xs As Single = .PointSTC(j + 1).X - .PointSTC(j).X
                                Dim Ys As Single = .PointSTC(j + 1).Y - .PointSTC(j).Y
                                If xs <> 0 And .PointSTC(j + 1).X <> SYMX Then
                                    If .PointSTC(j).X = SYMX And j <> 0 Then
                                        If (.PointSTC(j - 1).X - SYMX) * (.PointSTC(j + 1).X - SYMX) < 0 Then
                                            '頂点のX=SYMXの場合は、前後のポイントがSYMXをまたぐ場合に採用
                                            If f = False Then
                                                f = True
                                                m = .PointSTC(j).Y
                                                nj = j
                                            Else
                                                If m <= .PointSTC(j).Y Then
                                                    m = .PointSTC(j).Y
                                                    nj = j
                                                End If
                                            End If
                                        End If
                                    Else
                                        Dim a As Single = Ys / xs
                                        Dim b As Single = .PointSTC(j).Y - a * .PointSTC(j).X
                                        Dim yy As Single = a * SYMX + b
                                        If yy <= SYMY Then
                                            If f = False Then
                                                f = True
                                                m = yy
                                                nj = j
                                            Else
                                                '最もSYMYに近いY座標の位置
                                                If m <= yy Then
                                                    m = yy
                                                    nj = j
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        If f = True Then
                            If AH.GetUpperBound(0) < c Then
                                ReDim Preserve AH(c + 20), IE(c + 20), IE2(c + 20)
                            End If
                            AH(c) = m
                            IE(c) = i
                            IE2(c) = nj
                            c += 1
                        End If
                    End If
                End With
            Next

            If c = 0 Then
                Peripheri_preparation_f = False
            Else
                Peripheri_preparation_f = True
            End If

            For i As Integer = 0 To c - 2
                For j As Integer = i + 1 To c - 1
                    If AH(i) < AH(j) Then
                        clsGeneric.SWAP(AH(i), AH(j))
                        clsGeneric.SWAP(IE(i), IE(j))
                        clsGeneric.SWAP(IE2(i), IE2(j))
                    End If
                Next
            Next
            'たまたま結節点=SYMXの場合があるので
            SYMX = SYMX + 0.0001 '(TotalData.ScrData.ScrView.right - TotalData.ScrData.ScrView.left) / 2000
        Loop While AH(0) = AH(1) And c >= 2
        L_Code = IE(0)
        L_CodePoint = IE2(0)
        Return Peripheri_preparation_f
    End Function






















    Private Sub YReverse()
        'Y座標を反転
        Dim i As Integer, j As Integer

        For i = 0 To MapData.Map.ALIN - 1
            With MapData.MPLine(i)
                For j = 0 To .NumOfPoint - 1
                    With .PointSTC(j)
                        .Y = -.Y
                    End With
                Next
                .Circumscribed_Rectangle = Rectangle.FromLTRB(.Circumscribed_Rectangle.Left, -.Circumscribed_Rectangle.Top, .Circumscribed_Rectangle.Right, -.Circumscribed_Rectangle.Bottom)
            End With
        Next

        For i = 0 To MapData.Map.Kend - 1
            With MapData.MPObj(i)
                For j = 0 To .NumOfCenterP - 1
                    With .CenterPSTC(j).Position
                        .Y = -.Y
                    End With
                Next
                .Circumscribed_Rectangle = Rectangle.FromLTRB(.Circumscribed_Rectangle.Left, -.Circumscribed_Rectangle.Top, .Circumscribed_Rectangle.Right, -.Circumscribed_Rectangle.Bottom)
            End With
        Next

    End Sub

    ''' <summary>
    ''' 新規ライン作成
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New_Line_DataSet()

        If LastSavedLineKind >= MapData.Map.LpNum Then
            LastSavedLineKind = 0
        End If

        EditingLine = MapData.Init_One_Line(LastSavedLineKind)

        With EditingLine
            .NumOfPoint = 2
            ReDim .PointSTC(.NumOfPoint - 1)
        End With
        With ScrData.ScrRectangle
            EditingLine.PointSTC(0).X = (.Right + .Left) / 2 - (.Right - .Left) / 15
            EditingLine.PointSTC(0).Y = (.Bottom + .Top) / 2
            EditingLine.PointSTC(1).X = (.Right + .Left) / 2 + (.Right - .Left) / 15
            EditingLine.PointSTC(1).Y = (.Bottom + .Top) / 2
        End With
        setEditingLine(EditingLine)


    End Sub
    ''' <summary>
    ''' 新規オブジェクト作成
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New_Object_DataSet()

        Dim newObj As clsMapData.strObj_Data
        If LastSavedObjectKind >= MapData.Map.OBKNum Then
            LastSavedObjectKind = 0
        End If
        If _MapEditor.EditList.ObjectType <> MapData.ObjectKind(LastSavedObjectKind).ObjectType Then
            Dim i As Integer = 0
            Do Until _MapEditor.EditList.ObjectType = MapData.ObjectKind(i).ObjectType
                i += 1
            Loop
            LastSavedObjectKind = i
        End If

        newObj = MapData.Init_One_Object(LastSavedObjectKind)

        With newObj.CenterPSTC(0).Position
            .X = (ScrData.ScrRectangle.Right + ScrData.ScrRectangle.Left) / 2
            .Y = (ScrData.ScrRectangle.Top + ScrData.ScrRectangle.Bottom) / 2
        End With

        setEditingObject(newObj)
    End Sub
    ''' <summary>
    ''' 地図上をカーソルが移動した場合に位置情報を表示
    ''' </summary>
    ''' <param name="MousePosition">画面座標</param>
    ''' <remarks></remarks>
    Public Sub picMapMouseMovePointInformation(ByVal MousePosition As Point)
        Dim originalP As PointF = ScrData.getSRXY(New Point(MousePosition))
        Dim P As PointF = spatial.Get_Reverse_XY(originalP, MapData.Map.Zahyo)
        Dim PSt As strPointStrings = clsGeneric.Get_PositionCoordinate_Strings(P, MapData.Map.Zahyo)
        _MapEditor.tsslblX.Text = PSt.x
        _MapEditor.tsslblY.Text = PSt.y
        picMap.Focus()
    End Sub
    ''' <summary>
    ''' ライン編集モード時に、ラインの点をクリックしたか調べ、そのスタック位置を記録、点ドラッグモードに入る
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub selectEditingLinePoint(ByVal MousePosition As Point)
        Dim EditedLinePoint As Integer
        Dim InsertLinePoint As Integer
        Dim NpXY As PointF
        Dim DragZoneF As Boolean
        NearLinePointOrLineSegment(MousePosition, EditedLinePoint, InsertLinePoint, NpXY, DragZoneF)

        If EditedLinePoint <> -1 Then
            _MapEditor.EditingMode_LineSub = frmMapEditor.EditingModes_LineSub.PointDragMode
            EditedLineDragPointNumber = EditedLinePoint
        ElseIf DragZoneF = True Then
            _MapEditor.EditingMode_LineSub = frmMapEditor.EditingModes_LineSub.LineDragMode
        End If

    End Sub
    ''' <summary>
    ''' 複数オブジェクト編集モードでオブジェクト・ラインのドラッグ
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="CursorP"></param>
    ''' <param name="MouseDownP"></param>
    ''' <remarks></remarks> 
    Public Sub printDraggingMultiObject(ByRef g As Graphics, ByRef CursorP As Point, ByRef MouseDownP As Point)

        Dim dif As SizeF = Get_srxy_Difference_between_MouseDownPosition_and_CurrentPosition(CursorP, MouseDownP)
        Dim PrintedLine(MapData.Map.ALIN - 1) As Boolean
        For Each i As Integer In EditingMultiObject
            With MapData.MPObj(i)
                For j As Integer = 0 To .NumOfCenterP - 1
                    printDraggingObjectCore(g, CursorP, MouseDownP, MapData.MPObj(i), j)
                Next
                For j As Integer = 0 To .NumOfLine - 1
                    Dim Lcode As Integer = .LineCodeSTC(j).LineCode
                    If PrintedLine(Lcode) = False Then
                        Dim ELineMove As clsMapData.strLine_Data = MapData.MPLine(Lcode).Clone
                        Dim LineCol As Color = clsSettings.Data.MapEditor.ObjectLineColor.getColor
                        If lineEnabled(Lcode) = False Then
                            LineCol = clsSettings.Data.MapEditor.ObjectLineColorDisabled.getColor
                        Else
                            If MapData.Map.Time_Mode = True And .LineCodeSTC(j).NumOfTime >= 1 Then
                                LineCol = clsSettings.Data.MapEditor.ObjectTimeLineColor.getColor
                            End If
                        End If
                        With ELineMove
                            For k As Integer = 0 To .NumOfPoint - 1
                                .PointSTC(k) = PointF.Add(.PointSTC(k), dif)
                            Next
                        End With
                        printOneLine(g, ELineMove, LineCol, 2)
                        PrintedLine(Lcode) = True
                    End If
                Next
            End With
        Next
    End Sub
    ''' <summary>
    ''' 複数ライン編集モードでラインのドラッグ
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="CursorP"></param>
    ''' <param name="MouseDownP"></param>
    ''' <remarks></remarks>
    Public Sub printDraggingMultiLine(ByRef g As Graphics, ByRef CursorP As Point, ByRef MouseDownP As Point)
        Dim dif As SizeF = Get_srxy_Difference_between_MouseDownPosition_and_CurrentPosition(CursorP, MouseDownP)
        For Each i As Integer In EditingMultiLine
            Dim ELineMove As clsMapData.strLine_Data = MapData.MPLine(i).Clone
            With ELineMove
                For j As Integer = 0 To .NumOfPoint - 1
                    .PointSTC(j) = PointF.Add(.PointSTC(j), dif)
                Next
            End With
            printOneLine(g, ELineMove, clsSettings.Data.MapEditor.LineColorSelected.getColor, 2)
        Next
    End Sub

    ''' <summary>
    ''' ライン編集モードでラインのドラッグ
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="CursorP"></param>
    ''' <param name="MouseDownP"></param>
    ''' <remarks></remarks>
    Public Sub printDraggingLine(ByRef g As Graphics, ByRef CursorP As Point, ByRef MouseDownP As Point)

        Dim dif As SizeF = Get_srxy_Difference_between_MouseDownPosition_and_CurrentPosition(CursorP, MouseDownP)
        Dim ELineMove As clsMapData.strLine_Data = EditingLine.Clone
        For i As Integer = 0 To ELineMove.NumOfPoint - 1
            ELineMove.PointSTC(i) = PointF.Add(ELineMove.PointSTC(i), dif)
        Next
        printOneLine(g, ELineMove, clsSettings.Data.MapEditor.LineColorSelected.getColor, 2)
    End Sub

    ''' <summary>
    ''' ライン編集モードで点ドラッグ中の点を描く
    ''' </summary>
    ''' <param name="g">Graphicsオブジェクト</param>
    ''' <param name="CursorP">カーソルの画面座標</param>
    ''' <param name="MouseDownP">マウスを押した時点の画面座標</param>
    ''' <remarks></remarks>
    Public Sub printDraggingLinePoint(ByRef g As Graphics, ByRef CursorP As Point, ByRef MouseDownP As Point)
        Dim dif As SizeF = Get_srxy_Difference_between_MouseDownPosition_and_CurrentPosition(CursorP, MouseDownP)

        Dim r As Integer = 4
        With EditingLine
            Dim CP As PointF = .PointSTC(EditedLineDragPointNumber)
            Dim cpmove As PointF = PointF.Add(CP, dif)
            If EditedLineDragPointNumber = 0 Or EditedLineDragPointNumber = .NumOfPoint - 1 Then
                r += 2
            End If
            Dim P As Point = ScrData.getSxSy(cpmove)
            Dim LineP() As Point

            If .PointSTC(.NumOfPoint - 1).Equals(.PointSTC(0)) = True And (EditedLineDragPointNumber = 0 Or EditedLineDragPointNumber = .NumOfPoint - 1) Then
                'ループの場合は始点と終点と一緒に移動
                ReDim LineP(2)
                LineP(0) = ScrData.getSxSy(.PointSTC(.NumOfPoint - 2))
                LineP(1) = P
                LineP(2) = ScrData.getSxSy(.PointSTC(1))
            Else
                Select Case EditedLineDragPointNumber
                    Case 0
                        '始点の場合
                        ReDim LineP(1)
                        LineP(0) = P
                        LineP(1) = ScrData.getSxSy(.PointSTC(1))
                    Case .NumOfPoint - 1
                        '終点の場合
                        ReDim LineP(1)
                        LineP(0) = P
                        LineP(1) = ScrData.getSxSy(.PointSTC(.NumOfPoint - 2))
                    Case Else
                        '中間点の場合
                        ReDim LineP(2)
                        LineP(0) = ScrData.getSxSy(.PointSTC(EditedLineDragPointNumber - 1))
                        LineP(1) = P
                        LineP(2) = ScrData.getSxSy(.PointSTC(EditedLineDragPointNumber + 1))
                End Select
            End If

            Dim pen As New Pen(Color.Red, 3)
            pen.LineJoin = Drawing2D.LineCap.Round
            g.DrawLines(pen, LineP)
            pen.Dispose()
            clsDraw.Ellipse(g, P, r, New SolidBrush(Color.Yellow), Pens.Black)
        End With
    End Sub
    ''' <summary>
    ''' ライン編集モードでサーチモードの場合で、線分が近い場合はマウスダウンで点を生成する
    ''' </summary>
    ''' <param name="MousePosition"></param>
    ''' <remarks></remarks>
    Public Sub picMapMouseDownLineEditingMode(ByVal MousePosition As Point)
        Dim EditedLinePoint As Integer
        Dim InsertLinePoint As Integer
        Dim NpXY As PointF
        Dim DragZoneF As Boolean
        NearLinePointOrLineSegment(MousePosition, EditedLinePoint, InsertLinePoint, NpXY, DragZoneF)
        If InsertLinePoint <> -1 Then
            With EditingLine
                clsGeneric.Insert_Point_Array(InsertLinePoint + 1, NpXY, .PointSTC)
                .NumOfPoint += 1
                setPropertyOfEditingLine()
            End With
            EditMapping(True)
        End If
    End Sub
    ''' <summary>
    ''' マウスから最寄りのライン上の点または線分の位置を求める
    ''' </summary>
    ''' <param name="MousePosition"></param>
    ''' <param name="EditedLinePoint">最寄りの点スタック位置（戻り値）</param>
    ''' <param name="InsertLinePoint">最寄りの線分の開始点スタック位置（戻り値）</param>
    ''' <param name="NearLineSegmentPoint">最寄りの線分の最近隣ポイント座標（戻り値）</param>
    ''' <param name="DragZoneFlag">ドラッグ可能ゾーンの場合true（戻り値）</param>
    ''' <remarks></remarks>
    Private Sub NearLinePointOrLineSegment(ByVal MousePosition As Point, ByRef EditedLinePoint As Integer,
                                           ByRef InsertLinePoint As Integer,
                                           ByRef NearLineSegmentPoint As PointF, ByRef DragZoneFlag As Boolean)

        Dim pxy() As Point = ScrData.getSxSy(EditingLine.NumOfPoint, EditingLine.PointSTC, False, False)
        Dim NearestP As Point
        spatial.NearLinePointOrLineSegment(MousePosition, pxy, 8, 25, EditedLinePoint, InsertLinePoint, NearestP, DragZoneFlag)
        NearLineSegmentPoint = ScrData.getSRXY(NearestP)
    End Sub
    ''' <summary>
    ''' ライン編集モード時に、MouseMoveイベントで移動した場合にポイント・線分の強調表示
    ''' </summary>
    ''' <param name="MousePosition"></param>
    ''' <remarks></remarks>
    Public Sub picMapMouseMoveLineEditingMode(ByVal MousePosition As Point)

        Static OldP As Integer = -1 '強調表示したポイント番号（または線分の前のポイント番号）
        Static OldPF As Boolean '強調表示した後にtrue
        Static OldBack As Integer '強調表示が点だった場合0、線だった場合1

        Dim r As Integer = 4
        Dim EditedLinePoint As Integer
        Dim InsertLinePoint As Integer
        Dim NpXY As PointF
        Dim DragZoneF As Boolean
        NearLinePointOrLineSegment(MousePosition, EditedLinePoint, InsertLinePoint, NpXY, DragZoneF)


        If DragZoneF = True And EditedLinePoint = -1 And InsertLinePoint = -1 Then
            picMap.Cursor = Cursors.Hand
        Else
            picMap.Cursor = Cursors.Default
        End If

        With EditingLine
            If EditedLinePoint = -1 And InsertLinePoint = -1 Then
                '点・線分ともに最寄り無し
                If OldPF = True Then
                    '強調表示していた場合はクリア。RefreshメソッドでGraphicsが消える
                    picMap.Refresh()
                    OldP = -1
                    OldPF = False
                End If
            Else
                If EditedLinePoint <> -1 Then
                    '点が最寄り
                    Dim g As Graphics = picMap.CreateGraphics
                    Dim P As Point = ScrData.getSxSy(.PointSTC(EditedLinePoint))
                    If EditedLinePoint <> OldP Or OldBack = 1 Then
                        If OldPF = True Then
                            picMap.Refresh()
                        End If
                        Dim r2 As Integer = r
                        If EditedLinePoint = 0 Or EditedLinePoint = .NumOfPoint - 1 Then
                            r2 += 2
                        End If
                        clsDraw.Ellipse(g, P, r2, New SolidBrush(Color.Yellow), Pens.Black)
                        OldP = EditedLinePoint
                        OldPF = True
                        OldBack = 0
                    End If
                End If
                If InsertLinePoint <> -1 Then
                    '線分が最寄り
                    Dim g As Graphics = picMap.CreateGraphics
                    Dim P As Point = ScrData.getSxSy(.PointSTC(InsertLinePoint))
                    Dim P2 As Point = ScrData.getSxSy(.PointSTC(InsertLinePoint + 1))
                    If InsertLinePoint <> OldP Or OldBack = 0 Then
                        If OldPF = True Then
                            picMap.Refresh()
                        End If
                        g.DrawLine(New Pen(Color.Red, 3), P, P2)
                        OldP = InsertLinePoint
                        OldPF = True
                        OldBack = 1
                    End If
                End If
            End If
        End With
    End Sub

    ''' <summary>
    ''' 編集モードがライン検索モードの際の地図上をカーソルが移動した場合にライン番号と線種を表示
    ''' </summary>
    ''' <param name="MousePosition"></param>
    ''' <remarks></remarks>
    Public Sub picMapMouseMoveLineSearchMode(ByVal MousePosition As Point)
        Dim NearLineKind() As String
        Dim NearLineCode() As Integer
        Dim DragZoneCheckF As Boolean = False
        Dim DragZoneFlag As Boolean = False
        If _MapEditor.EditingMode = frmMapEditor.editingModes.MultiLinesEditingMode And
            _MapEditor.EditingMode_MultiLineSub = frmMapEditor.EditingModes_MultiLineSub.Pointing Then
            DragZoneCheckF = True
        End If
        Dim nearLineN As Integer = getNearestLineKineName(MousePosition, NearLineCode, NearLineKind, DragZoneCheckF, DragZoneFlag)
        If nearLineN > 0 And DragZoneFlag = False Then
            setlblPicMapText(MousePosition, String.Join(vbCrLf, NearLineKind))
        Else
            _MapEditor.lblPicMap.Visible = False
        End If
        Select Case _MapEditor.EditingMode
            Case frmMapEditor.editingModes.MultiLinesEditingMode
                If _MapEditor.EditingMode_MultiLineSub = frmMapEditor.EditingModes_MultiLineSub.Pointing And DragZoneFlag = True Then
                    If EditingMultiLine.IndexOf(NearLineCode(0)) <> -1 Then
                        picMap.Cursor = Cursors.Hand
                    Else
                        picMap.Cursor = Cursors.Default
                    End If
                Else
                    picMap.Cursor = Cursors.Default
                End If
            Case frmMapEditor.editingModes.LineSearchingMode
                If CheckCompassPosition(MousePosition) = True Then
                    picMap.Cursor = Cursors.Hand
                Else
                    picMap.Cursor = Cursors.Default
                End If
        End Select

    End Sub

    ''' <summary>
    ''' 編集モードがオブジェクト検索モード、複数オブジェクト選択モードの際の地図上をカーソルが移動した場合にオブジェクト名を表示
    ''' </summary>
    ''' <param name="MousePosition">画面座標</param>
    ''' <remarks></remarks>
    Public Sub picMapMouseMoveObjectSearchMode(ByVal MousePosition As Point)

        Dim NearObjctName() As String
        If _MapEditor.EditingMode = frmMapEditor.editingModes.MultiObjectsEditingMode And
            _MapEditor.EditingMode_MultiObjectSub = frmMapEditor.EditingModes_MultiObjectSub.Pointing And
            _MapEditor.EditList.Object_and_Line_DragEnabled = True Then
            Dim DragZoneCheckF As Boolean = True
            Dim DragZoneFlag As Boolean
            Dim nearObjN As Integer = getNearestObjectName(MousePosition, True, NearObjctName, DragZoneCheckF, DragZoneFlag)

            If nearObjN > 0 Then
                If DragZoneFlag = True Then
                    picMap.Cursor = Cursors.Hand
                    _MapEditor.lblPicMap.Visible = False
                Else
                    picMap.Cursor = Cursors.Default
                    setlblPicMapText(MousePosition, String.Join(vbCrLf, NearObjctName))
                End If
            Else
                picMap.Cursor = Cursors.Default
                _MapEditor.lblPicMap.Visible = False
            End If
        Else
            Dim nearObjN As Integer = getNearestObjectName(MousePosition, True, NearObjctName)
            If nearObjN > 0 Then
                setlblPicMapText(MousePosition, String.Join(vbCrLf, NearObjctName))
            Else
                _MapEditor.lblPicMap.Visible = False
            End If
        End If
        If _MapEditor.EditingMode = frmMapEditor.editingModes.ObjectSearchingMode Then
            If CheckCompassPosition(MousePosition) = True Then
                picMap.Cursor = Cursors.Hand
            Else
                picMap.Cursor = Cursors.Default
            End If

        End If
    End Sub
    ''' <summary>
    ''' 指定画面座標が方位上にある場合true
    ''' </summary>
    ''' <param name="MousePosition">画面座標</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckCompassPosition(ByVal MousePosition As Point) As Boolean
        If MapData.Map.MapCompass.Visible = False Then
            Return False
        End If
        Dim r As Integer = ScrData.Get_Length_On_Screen(MapData.Map.MapCompass.Mark.WordFont.Body.Size / 2)
        Dim p As Point = ScrData.getSxSy(MapData.Map.MapCompass.Position)
        p.Offset(-r, -r)
        Dim comprect As Rectangle = New Rectangle(p, New Size(r * 2, r * 2))
        Return comprect.Contains(MousePosition) = True

    End Function


    ''' <summary>
    ''' ドラッグ用に、現在の地図画面をbackCanvasに待避、オブジェクト編集モードの場合は、代表点の位置をチェック
    ''' </summary>
    ''' <param name="MousePosition"></param>
    ''' <remarks></remarks>
    Public Sub picMapMouseDownAndReservePicMap(ByVal MousePosition As Point)
        '前の座標から移動した場合
        picMapImageOperation.getPictureImage()
        With _MapEditor
            .tsslblX.Text = ""
            .tsslblY.Text = ""
            'ドラッグ開始
            .lblPicMap.Visible = False
            .mousePointingSituation = mousePointingSituations.downAndMove
            Select Case .EditingMode
                Case frmMapEditor.editingModes.ObjectSearchingMode, frmMapEditor.editingModes.LineSearchingMode
                    If CheckCompassPosition(MousePosition) = True Then
                        oldEditingMode_before_CompassDragMode = .EditingMode
                        .EditingMode = frmMapEditor.editingModes.CompassDragMode
                    End If
                Case frmMapEditor.editingModes.ObjectEditingMode
                    'オブジェクト編集モードの場合は、代表点の位置をチェック
                    selectEditingObjectCore(MousePosition, True)
                Case frmMapEditor.editingModes.LineEditingMode
                    'ライン編集モードでは、点の位置をチェック
                    selectEditingLinePoint(MousePosition)
                Case frmMapEditor.editingModes.MultiLinesEditingMode
                    '複数ライン編集モードで、クリック選択の場合、ドラッグして移動できるようにする
                    If .EditingMode_MultiLineSub = frmMapEditor.EditingModes_MultiLineSub.Pointing Then
                        Dim MpLineCode() As Integer
                        Dim DragZoneFlag As Boolean
                        Dim n As Integer = NearMPLine(MousePosition, MpLineCode, True, DragZoneFlag)
                        If n > 0 And DragZoneFlag = True Then
                            .EditingMode_MultiLineSub = frmMapEditor.EditingModes_MultiLineSub.LineDragMode
                        End If
                    End If
                Case frmMapEditor.editingModes.MultiObjectsEditingMode
                    If .EditingMode_MultiObjectSub = frmMapEditor.EditingModes_MultiObjectSub.Pointing Then
                        '複数オブジェクト編集モードで、クリック選択の場合、ドラッグして移動できるようにする
                        If _MapEditor.EditList.Object_and_Line_DragEnabled = True Then
                            Dim DragZoneCheckF As Boolean = True
                            Dim DragZoneFlag As Boolean
                            Dim NearObjctName() As String
                            Dim nearObjN As Integer = getNearestObjectName(MousePosition, True, NearObjctName, DragZoneCheckF, DragZoneFlag)

                            If nearObjN > 0 And DragZoneFlag = True Then
                                .EditingMode_MultiObjectSub = frmMapEditor.EditingModes_MultiObjectSub.ObjectLineDragMode
                            End If
                        End If
                    End If
            End Select
        End With
    End Sub
    ''' <summary>
    ''' 地図上をドラッグして移動する
    ''' </summary>
    ''' <param name="MousePosition">ドラッグ中の画面座標</param>
    ''' <param name="mouseDownPosition">マウスをクリックした画面座標</param>
    ''' <remarks></remarks>
    Public Sub picMapMouseDownAndMove(ByVal MousePosition As Point, ByVal mouseDownPosition As Point)
        '前の座標から移動した場合
        With _MapEditor
            If .EditingMode = frmMapEditor.editingModes.CompassDragMode Then
                '方位移動モード
                Dim g As Graphics = picMap.CreateGraphics
                Dim dif As SizeF = Get_srxy_Difference_between_MouseDownPosition_and_CurrentPosition(MousePosition, mouseDownPosition)
                Dim MCP As clsMapData.strCompass_Attri = MapData.Map.MapCompass
                MCP.Position = PointF.Add(MCP.Position, dif)
                picMap.Refresh()
                CompassShow(g, MCP)
                g.Dispose()
            ElseIf .EditingMode = frmMapEditor.editingModes.ObjectEditingMode And _
                    .EditingMode_ObjectSub = frmMapEditor.EditingModes_ObjectSub.ObjectCoreDragMode Then
                'オブジェクト編集で代表点ドラッグモード
                Dim g As Graphics = picMap.CreateGraphics
                picMap.Refresh()
                printDraggingObjectCore(g, MousePosition, mouseDownPosition, EditingObject, EditedObjectDragCoreNumer)
                g.Dispose()
            ElseIf .EditingMode = frmMapEditor.editingModes.ObjectEditingMode And _
                    .EditingMode_ObjectSub = frmMapEditor.EditingModes_ObjectSub.Object_and_Line_DragMode Then
                'オブジェクト編集でオブジェクト・ラインドラッグモード
                Dim g As Graphics = picMap.CreateGraphics
                picMap.Refresh()
                printDraggingObjectLine(g, MousePosition, mouseDownPosition)
                g.Dispose()
            ElseIf .EditingMode = frmMapEditor.editingModes.LineEditingMode And _
                     .EditingMode_LineSub = frmMapEditor.EditingModes_LineSub.PointDragMode Then
                'ライン編集時で点ドラッグモード
                Dim g As Graphics = picMap.CreateGraphics
                picMap.Refresh()
                printDraggingLinePoint(g, MousePosition, mouseDownPosition)
                g.Dispose()
            ElseIf .EditingMode = frmMapEditor.editingModes.LineEditingMode And _
                    .EditingMode_LineSub = frmMapEditor.EditingModes_LineSub.LineDragMode Then
                ' ライン編集時でラインドラッグモード
                Dim g As Graphics = picMap.CreateGraphics
                picMap.Refresh()
                printDraggingLine(g, MousePosition, mouseDownPosition)
                g.Dispose()
            ElseIf .EditingMode = frmMapEditor.editingModes.MultiLinesEditingMode And
                    .EditingMode_MultiLineSub = frmMapEditor.EditingModes_MultiLineSub.LineDragMode Then
                ' 複数ライン編集時でラインドラッグモード
                Dim g As Graphics = picMap.CreateGraphics
                picMap.Refresh()
                printDraggingMultiLine(g, MousePosition, mouseDownPosition)
                g.Dispose()
            ElseIf .EditingMode = frmMapEditor.editingModes.MultiObjectsEditingMode And
                    .EditingMode_MultiObjectSub = frmMapEditor.EditingModes_MultiObjectSub.ObjectLineDragMode Then
                ' 複数オブジェクト編集時でオブジェクトラインドラッグモード
                Dim g As Graphics = picMap.CreateGraphics
                picMap.Refresh()
                printDraggingMultiObject(g, MousePosition, mouseDownPosition)
                g.Dispose()
            Else
                '待避した地図画面をドラッグに合わせて表示（地図のドラッグ）
                picMapImageOperation.DragPicture(MousePosition, mouseDownPosition)
                picMap.Cursor = Cursors.Hand
            End If
        End With

    End Sub
    ''' <summary>
    ''' ドラッグ後のマウスアップ
    ''' </summary>
    ''' <param name="MouseUpPosition">マウスアップした画面座標</param>
    ''' <param name="mouseDownPosition">マウスをクリックした画面座標</param>
    ''' <remarks></remarks>
    Public Sub picMapMouseUpDragAndMove(ByVal MouseUpPosition As Point, ByVal mouseDownPosition As Point, ByVal CancelFlag As Boolean)
        'ドラッグの場合
        '待避した画像のBitmapを破棄
        picMapImageOperation.DisposeBackCanvasPictureImage()
        Dim dif As SizeF = Get_srxy_Difference_between_MouseDownPosition_and_CurrentPosition(MouseUpPosition, mouseDownPosition)
        With _MapEditor
            If .EditingMode = frmMapEditor.editingModes.CompassDragMode Then
                '方位移動モード
                If CancelFlag = False Then
                    MapEditorUndo.SetUndo_Compass("方位の移動")
                    MapData.Map.MapCompass.Position = PointF.Add(MapData.Map.MapCompass.Position, dif)
                End If
                EditMapping(False)
                .EditingMode = oldEditingMode_before_CompassDragMode
            ElseIf .EditingMode = frmMapEditor.editingModes.ObjectEditingMode And _
                .EditingMode_ObjectSub = frmMapEditor.EditingModes_ObjectSub.ObjectCoreDragMode Then
                'オブジェクト編集で代表点ドラッグモード
                If CancelFlag = False Then
                    Dim CP As PointF = EditingObject.CenterPSTC(EditedObjectDragCoreNumer).Position
                    EditingObject.CenterPSTC(EditedObjectDragCoreNumer).Position = PointF.Add(CP, dif)
                End If
                EditMapping(True)
                If MapData.ObjectKind(EditingObject.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                    _MapEditor.EditingMode_ObjectSub = frmMapEditor.EditingModes_ObjectSub.AggregationObjectSelectMode
                Else
                    _MapEditor.EditingMode_ObjectSub = frmMapEditor.EditingModes_ObjectSub.LineSelectMode
                End If
            ElseIf .EditingMode = frmMapEditor.editingModes.ObjectEditingMode And _
                .EditingMode_ObjectSub = frmMapEditor.EditingModes_ObjectSub.Object_and_Line_DragMode Then
                'オブジェクト編集でオブジェクト・ラインドラッグモード
                If CancelFlag = False Then
                    Dim AObj As New List(Of Integer)
                    AObj.Add(EditingObject.Number)
                    Dim ALine As New List(Of Integer)
                    For i As Integer = 0 To EditingObject.NumOfLine - 1
                        ALine.Add(EditingObject.LineCodeSTC(i).LineCode)
                    Next
                    MapEditorUndo.Set_UndoSettingObject_andLine_Drag("オブジェクトとラインの移動", ALine, AObj, MapData.Map.Circumscribed_Rectangle)
                    If EditingObject.Number = -1 Then
                        MapData.Save_Object(EditingObject, True)
                    End If
                    For i As Integer = 0 To EditingObject.NumOfCenterP - 1
                        Dim CP As PointF = EditingObject.CenterPSTC(i).Position
                        EditingObject.CenterPSTC(i).Position = PointF.Add(CP, dif)
                    Next
                    For i As Integer = 0 To EditingObject.NumOfLine - 1
                        Dim ELineMove As clsMapData.strLine_Data = MapData.MPLine(EditingObject.LineCodeSTC(i).LineCode).Clone
                        With ELineMove
                            For j As Integer = 0 To .NumOfPoint - 1
                                .PointSTC(j) = PointF.Add(.PointSTC(j), dif)
                            Next
                            .Circumscribed_Rectangle.Offset(dif.Width, dif.Height)
                        End With
                        MapData.Save_Line(ELineMove, True, False, False)
                    Next
                End If
                EditMapping(True)
                _MapEditor.EditingMode_ObjectSub = frmMapEditor.EditingModes_ObjectSub.LineSelectMode
                ElseIf .EditingMode = frmMapEditor.editingModes.LineEditingMode And _
                    .EditingMode_LineSub = frmMapEditor.EditingModes_LineSub.PointDragMode Then
                    'ライン編集時で点ドラッグモード
                    If CancelFlag = False Then
                        Dim CP As PointF = EditingLine.PointSTC(EditedLineDragPointNumber)
                        With EditingLine
                            If EditedLineDragPointNumber = 0 Or EditedLineDragPointNumber = .NumOfPoint - 1 Then
                                If .PointSTC(.NumOfPoint - 1).Equals(.PointSTC(0)) = True Then
                                    .PointSTC(.NumOfPoint - 1) = PointF.Add(CP, dif)
                                    .PointSTC(0) = PointF.Add(CP, dif)
                                Else
                                    Dim oc As enmLineConnect = EditingLine.Connect
                                    .PointSTC(EditedLineDragPointNumber) = PointF.Add(CP, dif)
                                    .Connect = MapData.Check_Line_Connect(EditingLine)
                                    If oc <> .Connect Then
                                        setPropertyOfEditingLine()
                                    End If
                                End If
                            Else
                                .PointSTC(EditedLineDragPointNumber) = PointF.Add(CP, dif)
                            End If
                        End With
                    End If
                    EditMapping(True)
                    _MapEditor.EditingMode_LineSub = frmMapEditor.EditingModes_LineSub.SearchMode
                ElseIf .EditingMode = frmMapEditor.editingModes.LineEditingMode And _
                        .EditingMode_LineSub = frmMapEditor.EditingModes_LineSub.LineDragMode Then
                    'ライン編集時でラインドラッグモード
                    If CancelFlag = False Then
                        For i As Integer = 0 To EditingLine.NumOfPoint - 1
                            EditingLine.PointSTC(i) = PointF.Add(EditingLine.PointSTC(i), dif)
                        Next
                    End If
                    EditMapping(True)
                    _MapEditor.EditingMode_LineSub = frmMapEditor.EditingModes_LineSub.SearchMode
                ElseIf .EditingMode = frmMapEditor.editingModes.MultiLinesEditingMode And
                        .EditingMode_MultiLineSub = frmMapEditor.EditingModes_MultiLineSub.LineDragMode Then
                    '複数ライン編集時でラインドラッグモード
                    If CancelFlag = False Then
                        MapEditorUndo.SetUndo_SaveLine("複数ラインのドラッグ", EditingMultiLine, MapData.Map.Circumscribed_Rectangle)
                        For Each i As Integer In EditingMultiLine
                            Dim EMoveLine As clsMapData.strLine_Data = MapData.MPLine(i).Clone
                            With EMoveLine
                                For j As Integer = 0 To .NumOfPoint - 1
                                    .PointSTC(j) = PointF.Add(.PointSTC(j), dif)
                                Next
                                .Circumscribed_Rectangle.Offset(dif.Width, dif.Height)
                            End With
                            MapData.Save_Line(EMoveLine, True, True, False)
                        Next
                    End If
                    EditMapping(True)
                    _MapEditor.EditingMode_MultiLineSub = frmMapEditor.EditingModes_MultiLineSub.Pointing
                ElseIf .EditingMode = frmMapEditor.editingModes.MultiObjectsEditingMode And
                       .EditingMode_MultiObjectSub = frmMapEditor.EditingModes_MultiObjectSub.ObjectLineDragMode Then
                    '複数オブジェクト編集時でオブジェクトラインドラッグモード
                    If CancelFlag = False Then

                        Dim PrintedLine(MapData.Map.ALIN - 1) As Boolean

                        For Each i As Integer In EditingMultiObject
                            With MapData.MPObj(i)
                                For j As Integer = 0 To .NumOfLine - 1
                                    PrintedLine(.LineCodeSTC(j).LineCode) = True
                                Next
                            End With
                        Next
                        Dim ELine As List(Of Integer) = clsGeneric.Get_Specified_Value_Array(PrintedLine, MapData.Map.ALIN, True)

                        MapEditorUndo.Set_UndoSettingObject_andLine_Drag("複数オブジェクトとラインの移動", ELine, EditingMultiObject, MapData.Map.Circumscribed_Rectangle)
                        For Each i As Integer In ELine
                            With MapData.MPLine(i)
                                For j As Integer = 0 To .NumOfPoint - 1
                                    .PointSTC(j) = PointF.Add(.PointSTC(j), dif)
                                Next
                                .Circumscribed_Rectangle.Offset(dif.Width, dif.Height)
                            End With
                            MapData.Save_Line(MapData.MPLine(i), True, False, False)
                        Next
                        For Each i As Integer In EditingMultiObject
                            With MapData.MPObj(i)
                                For j As Integer = 0 To .NumOfCenterP - 1
                                    Dim CP As PointF = .CenterPSTC(j).Position
                                    .CenterPSTC(j).Position = PointF.Add(CP, dif)
                                Next
                            End With
                            MapData.Save_Object(MapData.MPObj(i), True)
                        Next
                    End If
                    EditMapping(True)
                    .EditingMode_MultiObjectSub = frmMapEditor.EditingModes_MultiObjectSub.Pointing
                Else
                    Dim StartP As PointF = ScrData.getSRXY(mouseDownPosition)
                    Dim EndP As PointF = ScrData.getSRXY(MouseUpPosition)
                    ScrData.ScrView.Offset(StartP.X - EndP.X, StartP.Y - EndP.Y)
                    EditMapping(False)
                    picMap.Cursor = Cursors.Default
                End If
        End With
    End Sub
    ''' <summary>
    ''' picMapで右クリック時の処理
    ''' </summary>
    ''' <param name="MouseUpPosition"></param>
    ''' <remarks></remarks>
    Public Sub picMapClickRightButton(ByVal MouseUpPosition As Point)
        With _MapEditor
            If .EditingMode = frmMapEditor.editingModes.LineSearchingMode Or .EditingMode = frmMapEditor.editingModes.ObjectSearchingMode Then
                If CheckCompassPosition(MouseUpPosition) = True Then
                    SettingCompass()
                End If
            ElseIf .EditingMode = frmMapEditor.editingModes.LineEditingMode Then
                If .EditingMode_LineSub = frmMapEditor.EditingModes_LineSub.SearchMode Then
                    'ライン編集でライン選択時に右クリックでメニュー表示
                    EditingLinePointRightButtonMenu(MouseUpPosition)
                End If
            ElseIf .EditingMode = frmMapEditor.editingModes.MultiObjectsEditingMode Then
                Select Case .EditingMode_MultiObjectSub
                    Case frmMapEditor.EditingModes_MultiObjectSub.Rectangle, frmMapEditor.EditingModes_MultiObjectSub.Circle, frmMapEditor.EditingModes_MultiObjectSub.Polygon
                        picMapMouseMoveMultiObjectSelect_Shape(MouseUpPosition, True, True)
                End Select
            ElseIf .EditingMode = frmMapEditor.editingModes.MultiLinesEditingMode Then
                Select Case .EditingMode_MultiLineSub
                    Case frmMapEditor.EditingModes_MultiLineSub.Rectangle, frmMapEditor.EditingModes_MultiLineSub.Circle, frmMapEditor.EditingModes_MultiLineSub.Polygon
                        picMapMouseMoveMultiLineSelect_Shape(MouseUpPosition, True, True)
                End Select

            End If

        End With

    End Sub
    ''' <summary>
    ''' ライン編集の結節点化ボタン
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub nodarize()
        Connect_Point(0)
        Connect_Point(EditingLine.NumOfPoint - 1)
        EditingLine.Connect = MapData.Check_Line_Connect(EditingLine)
        setPropertyOfEditingLine()
        EditMapping(True)
    End Sub

    ''' <summary>
    ''' ライン編集でライン選択時に右クリックでメニュー表示
    ''' </summary>
    ''' <param name="MousePosition"></param>
    ''' <remarks></remarks>
    Private Sub EditingLinePointRightButtonMenu(ByVal MousePosition As Point)
        Dim EditedLinePoint As Integer
        Dim InsertLinePoint As Integer
        Dim NpXY As PointF
        Dim DragZoneF As Boolean
        NearLinePointOrLineSegment(MousePosition, EditedLinePoint, InsertLinePoint, NpXY, DragZoneF)

        If EditedLinePoint <> -1 Then
            Dim Items As New List(Of String)
            If EditedLinePoint = 0 Or EditedLinePoint = EditingLine.NumOfPoint - 1 Then
                Dim LineConnect As Integer = MapData.Check_Line_Connect_Detail(EditingLine)
                If (EditedLinePoint = 0 And (LineConnect And 1) = 0) Or _
                     (EditedLinePoint = EditingLine.NumOfPoint - 1 And (LineConnect And 2) = 0) Then
                    Items.Add("結節点化")
                End If
                If LineConnect = 4 Then
                    Items.Add("ループ解除")
                Else
                    Items.Add("ループ化")
                End If
            Else
                Items.Add("ポイント削除")
                Items.Add("ライン分割")
            End If

            Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("ポイント操作", Items)
            If sel <> -1 Then
                Select Case Items.Item(sel)
                    Case "ポイント削除"
                        With EditingLine
                            clsGeneric.Remove_Point_Array(EditedLinePoint, .PointSTC)
                            .NumOfPoint -= 1
                        End With
                        setPropertyOfEditingLine()
                        EditMapping(True)
                    Case "ライン分割"
                        Dim msgText As String = "分割後のラインが登録され、関係するオブジェクトも変更されます。" & vbCrLf & "よろしいですか？"
                        If MsgBox(msgText, MsgBoxStyle.YesNo) = vbYes Then
                            MapEditorUndo.SetUndo_LineDivide_and_Node("ライン分割")
                            If MapData.Map.Time_Mode = False Then
                                EditingLine.LineTimeSTC(0).Kind = _MapEditor.cboLineKind.SelectedIndex
                            End If
                            MapData.Div_Line(EditingLine, EditedLinePoint)
                            setEditingLine(MapData.MPLine(MapData.Map.ALIN - 1))
                        End If
                    Case "結節点化"
                        Connect_Point(EditedLinePoint)
                        EditingLine.Connect = MapData.Check_Line_Connect(EditingLine)
                        setPropertyOfEditingLine()
                        EditMapping(True)
                    Case "ループ解除"
                        With EditingLine
                            .PointSTC(0).X = (.PointSTC(0).X + .PointSTC(1).X) / 2
                            .PointSTC(0).Y = (.PointSTC(0).Y + .PointSTC(1).Y) / 2
                        End With
                        EditingLine.Connect = MapData.Check_Line_Connect(EditingLine)
                        setPropertyOfEditingLine()
                        EditMapping(True)
                    Case "ループ化"
                        Dim P2 As Integer
                        With EditingLine
                            If EditedLinePoint = 0 Then
                                P2 = .NumOfPoint - 1
                            Else
                                P2 = 0
                            End If
                            .PointSTC(EditedLinePoint) = .PointSTC(P2)
                        End With
                        EditingLine.Connect = MapData.Check_Line_Connect(EditingLine)
                        setPropertyOfEditingLine()
                        EditMapping(True)
                End Select
            End If
        End If
    End Sub

    ''' <summary>
    ''' 結節点化
    ''' </summary>
    ''' <param name="EditedLinePoint"></param>
    ''' <remarks></remarks>
    Private Sub Connect_Point(ByVal EditedLinePoint As Integer)

        Dim XY1 As PointF, XY2 As PointF, XY3 As PointF

        Dim P2 As Integer
        With EditingLine
            If EditedLinePoint = 0 Then
                P2 = .NumOfPoint - 1
            Else
                P2 = 0
            End If
            XY1 = .PointSTC(EditedLinePoint)
            XY2 = .PointSTC(P2)
        End With

        Dim md As Single = ScrData.ScrRectangle.Right - ScrData.ScrRectangle.Left
        Dim ML As Integer = -1
        For i As Integer = 0 To MapData.Map.ALIN - 1
            If i <> EditingLine.Number And lineEnabled(i) = True Then
                With MapData.MPLine(i)
                    If .NumOfPoint > 0 Then
                        Dim D As Single = spatial.get_Distance(XY1, .PointSTC(0))
                        Dim d2 As Single = spatial.get_Distance(XY1, .PointSTC(.NumOfPoint - 1))
                        If md >= D Then
                            ML = i
                            XY3 = .PointSTC(0)
                            md = D
                        End If
                        If md >= d2 Then
                            ML = i
                            XY3 = .PointSTC(.NumOfPoint - 1)
                            md = d2
                        End If
                    End If
                End With
            End If
        Next
        If ML <> -1 Then
            With EditingLine
                If XY1.Equals(XY2) = True Then
                    .PointSTC(EditedLinePoint) = XY3
                    .PointSTC(P2) = XY3
                Else
                    .PointSTC(EditedLinePoint) = XY3
                End If
            End With
        Else
            Dim msgText = "付近に結節点がありません。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
        End If

    End Sub

    ''' <summary>
    ''' オブジェクト名期間設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetObjNameTime()
        Dim form As New frmMED_ObjectNameTimeSet
        If form.ShowDialog(_MapEditor, MapData.ObjectKind, EditingObject.Kind, EditingObject.NumOfNameTime, EditingObject.NameTimeSTC) = Windows.Forms.DialogResult.OK Then
            EditingObject.NumOfNameTime = form.GetNameTimeStac(EditingObject.NameTimeSTC)
            EditMapping(True)
            setEditingObject(EditingObject)
            setPropertyOfEditingObject()
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' オブジェクト継承設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetObjectSuccession()
        Dim form As New frmMED_ObjectSuccession

        If form.ShowDialog(_MapEditor, EditingObject, MapData) = Windows.Forms.DialogResult.OK Then
            EditingObject = form.getResult()
            setPropertyOfEditingObject()
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 代表点の期間設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetObjectCenterPointTime()
        Dim form As New frmMED_ObjectCPTimeSet
        Dim shift_V As Single = 8 / ScrData.ScreenMG.Mul
        If form.ShowDialog(_MapEditor, EditingObject.NumOfCenterP, EditingObject.CenterPSTC, shift_V) = Windows.Forms.DialogResult.OK Then
            EditingObject.NumOfCenterP = form.getResult(EditingObject.CenterPSTC)
            EditMapping(True)
            setPropertyOfEditingObject()
        End If
        form.Dispose()

    End Sub
    ''' <summary>
    ''' 時空間モードの「時間表示」ボタン
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowObjectTimeSeries()
        MapData.Check_Obj_Maxmin(EditingObject, False)
        Dim form As New frmMED_Show_Object_Time_Series
        form.ShowDialog(_MapEditor, EditingObject, MapData)
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 分割and結節点ボタンがクリック
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LineDivide_and_Nodarize()
        If MapData.Map.Time_Mode = False Then
            EditingLine.LineTimeSTC(0).Kind = _MapEditor.cboLineKind.SelectedIndex
        End If
        MapEditorUndo.SetUndo_LineDivide_and_Node("ラインの分割&結節点")
        Dim LineSearchIndex As clsSpatialIndexSearch = getLineSearchIndex(ScrData.ScrRectangle)
        LineDivide_and_Node(EditingLine, LineSearchIndex)

        setPropertyOfEditingLine()
        EditMapping(True)
    End Sub
    ''' <summary>
    ''' 分割and結節点
    ''' </summary>
    ''' <param name="ConnectLine"></param>
    ''' <remarks></remarks>
    Private Function LineDivide_and_Node(ByRef ConnectLine As clsMapData.strLine_Data, ByRef LineSearchIndex As clsSpatialIndexSearch) As strLineDivideData_info()

        Dim ck As Integer = MapData.Check_Line_Connect_Detail(ConnectLine)
        If ck = 4 Then
            Return Nothing
        End If

        Dim LineDivideData() As strLineDivideData_info
        Dim LineDivideData_num As Integer = 0
        If ConnectLine.Number = -1 Then
            MapData.Save_Line(ConnectLine, True, True, True)
            MapData.Check_Line_Maxmin(ConnectLine.Number, True)
        Else
            LineSearchIndex.RemoveObject_byTag(ConnectLine.Number)
        End If

        For PLP As Integer = 0 To 1
            If (PLP = 0 And (ck And 1) = 0) Or (PLP = 1 And (ck And 2) = 0) Then
                Dim P0 As PointF, P1 As PointF, P2 As PointF
                Dim PA0 As PointF, PB0 As PointF
                Dim PA1 As PointF
                Dim p As Integer
                With ConnectLine
                    If PLP = 0 Then
                        p = 0
                        P0 = .PointSTC(0)
                        If .NumOfPoint = 2 Then
                            P1.X = (.PointSTC(1).X + .PointSTC(0).X) / 2
                            P1.Y = (.PointSTC(1).Y + .PointSTC(0).Y) / 2
                            P2 = .PointSTC(1)
                        Else
                            P1 = .PointSTC(1)
                            P2 = .PointSTC(2)
                        End If
                    Else
                        p = .NumOfPoint - 1
                        P0 = .PointSTC(p)
                        If .NumOfPoint = 2 Then
                            P1.X = (.PointSTC(p - 1).X + .PointSTC(p).X) / 2
                            P1.Y = (.PointSTC(p - 1).Y + .PointSTC(p).Y) / 2
                            P2 = .PointSTC(p - 1)
                        Else
                            P1 = .PointSTC(p - 1)
                            P2 = .PointSTC(p - 2)
                        End If
                    End If
                End With
                PA0.X = P0.X - P1.X
                PA0.Y = P0.Y - P1.Y
                PA1.X = P2.X - P1.X
                PA1.Y = P2.Y - P1.Y
                Dim anglA As Single = clsGeneric.Get_Angle_from_Two_Vector(PA0, PA1)

                Dim NpXY() As PointF
                Dim NearPStacPosition() As Integer
                Dim mline() As Integer
                Dim ObStac() As Integer
                Dim D As Single
                Dim BaseDistance As Single = ScrData.Get_MapDataSize_from_ScreenPixcel(25)
                Dim NearLineNum As Integer = LineIndex.GetNearestLineNumber(ConnectLine.PointSTC(p).X, ConnectLine.PointSTC(p).Y,
                                                                       BaseDistance, ObStac, NearPStacPosition,
                                                                       mline, D, NpXY)

                'Dim NearLineNum As Integer = NearMPLine_with_Point(ConnectLine.PointSTC(p), mline, NearPStacPosition, NpXY)
                If NearLineNum > 0 Then
                    '同距離のラインが複数あった場合も最初の一つに絞ってしまう
                    Dim NearPoint As PointF = NpXY(0)
                    PB0.X = NearPoint.X - P1.X
                    PB0.Y = NearPoint.Y - P1.Y
                    Dim anglB As Single = clsGeneric.Get_Angle_from_Two_Vector(PB0, PA1)
                    Dim angleAB As Single = Math.Abs(anglA - anglB)
                    If angleAB < 100 Then
                        '反対方向のラインには伸びないようにする
                        Dim L As Integer = mline(0)
                        Dim np As Integer = NearPStacPosition(0)
                        Dim PushLine As clsMapData.strLine_Data = MapData.MPLine(L).Clone
                        With PushLine
                            If (np = 0 And .PointSTC(np).Equals(NearPoint) = True) Or _
                                (np = .NumOfPoint - 2 And .PointSTC(np + 1).Equals(NearPoint) = True) Then
                                '相手のラインの最も近い地点が起終点だった場合は分割しない
                            Else
                                LineIndex.RemoveObject_byTag(L)
                                ReDim Preserve LineDivideData(LineDivideData_num)
                                LineDivideData(LineDivideData_num).OriginalLineCode = PushLine.Number
                                LineDivideData(LineDivideData_num).AddedLineCode = MapData.Map.ALIN
                                LineDivideData_num += 1
                                If (.PointSTC(np).Equals(NearPoint) = True) Then
                                    MapData.Div_Line(PushLine, np)
                                ElseIf (.PointSTC(np + 1).Equals(NearPoint) = True) Then
                                    MapData.Div_Line(PushLine, np + 1)
                                Else
                                    '最も近い地点が線分上だった場合
                                    .NumOfPoint += 1
                                    ReDim Preserve .PointSTC(.NumOfPoint - 1)
                                    For i = .NumOfPoint - 1 To np + 1 Step -1
                                        .PointSTC(i) = .PointSTC(i - 1)
                                    Next
                                    .PointSTC(np + 1) = NearPoint
                                    MapData.Div_Line(PushLine, np + 1)
                                End If
                                LineIndex.AddLine(MapData.MPLine(L).NumOfPoint, MapData.MPLine(L).PointSTC, L)
                                Dim ALIN As Integer = MapData.Map.ALIN
                                LineIndex.AddLine(MapData.MPLine(ALIN - 1).NumOfPoint, MapData.MPLine(ALIN - 1).PointSTC, ALIN - 1)
                            End If
                        End With
                        ConnectLine.PointSTC(p) = NearPoint
                    End If
                End If
            End If
        Next
        LineIndex.AddLine(ConnectLine.NumOfPoint, ConnectLine.PointSTC, ConnectLine.Number)
        MapData.Check_Line_Maxmin(ConnectLine.Number, True)
        MapData.Save_Line(ConnectLine, True, True, True)
        MapData.Check_Line_Connect(ConnectLine)
        Return LineDivideData
    End Function
    ''' <summary>
    ''' タブストリップボタンとメニューのEnabledプロパティを設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setTabstripButtonAndMenuEnabled()
        Dim tsbObjectEditModeF As Boolean
        Dim tsbLineEditModeF As Boolean
        Dim tsbMultiSelectF As Boolean
        Dim mnuEditF As Boolean
        Dim btnNewObjectAndLine As Boolean

        With _MapEditor
            Select Case .EditingMode
                Case frmMapEditor.editingModes.ObjectSearchingMode, frmMapEditor.editingModes.LineSearchingMode
                    tsbObjectEditModeF = True
                    tsbLineEditModeF = True
                    tsbMultiSelectF = True
                    mnuEditF = True
                    btnNewObjectAndLine = True
                Case frmMapEditor.editingModes.ObjectEditingMode, frmMapEditor.editingModes.LineEditingMode
                    tsbObjectEditModeF = False
                    tsbLineEditModeF = False
                    mnuEditF = False
                    btnNewObjectAndLine = False
                Case frmMapEditor.editingModes.MultiObjectsEditingMode, frmMapEditor.editingModes.MultiLinesEditingMode
                    tsbObjectEditModeF = False
                    tsbLineEditModeF = False
                    tsbMultiSelectF = True
                    mnuEditF = False
                    btnNewObjectAndLine = False
                Case frmMapEditor.editingModes.Set_ClickObjectName
                    tsbObjectEditModeF = False
                    tsbLineEditModeF = False
                    tsbMultiSelectF = False
                    mnuEditF = False
                    btnNewObjectAndLine = False
            End Select
            .tsbObjectEditMode.Enabled = tsbObjectEditModeF
            .tsbLineEditMode.Enabled = tsbLineEditModeF
            .tsbMultiSelect.Enabled = tsbMultiSelectF
            .mnuEdit.Enabled = mnuEditF
            .btnNewObjectAndLine.Enabled = btnNewObjectAndLine
        End With
    End Sub
    ''' <summary>
    ''' マップエディタ右側パネルの表示非表示設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setRightPanelVisible()
        Dim ObjectEditF As Boolean
        Dim ObjectTimeEditF As Boolean
        Dim LineEditF As Boolean
        Dim PropertyWindowF As Boolean
        Dim DefAttributeF As Boolean
        Dim MultiObjectsF As Boolean
        Dim MulitLinesF As Boolean

        With _MapEditor
            .scPropertyAndDefAttribute.SplitterDistance = .scPropertyAndDefAttribute.Height
            Select Case .EditingMode
                Case frmMapEditor.editingModes.ObjectSearchingMode
                    ObjectEditF = False
                    ObjectTimeEditF = False
                    LineEditF = False
                    PropertyWindowF = False
                    DefAttributeF = False
                    MultiObjectsF = False
                    MulitLinesF = False
                    _MapEditor.menuEnable()
                Case frmMapEditor.editingModes.ObjectEditingMode
                    If MapData.Map.Time_Mode = True Then
                        ObjectEditF = False
                        ObjectTimeEditF = True
                    Else
                        ObjectEditF = True
                        ObjectTimeEditF = False
                    End If
                    LineEditF = False
                    PropertyWindowF = True
                    If MapData.ObjectKind(EditingObject.Kind).DefTimeAttDataNum = 0 Then
                        '初期属性のない場合
                        DefAttributeF = False
                    Else
                        '初期属性のある場合
                        .scPropertyAndDefAttribute.SplitterDistance = .scPropertyAndDefAttribute.Height * 0.7
                        DefAttributeF = True
                    End If
                    MultiObjectsF = False
                    MulitLinesF = False
                    _MapEditor.menuEnable()
                Case frmMapEditor.editingModes.LineSearchingMode
                    ObjectEditF = False
                    ObjectTimeEditF = False
                    LineEditF = False
                    PropertyWindowF = False
                    DefAttributeF = False
                    MultiObjectsF = False
                    MulitLinesF = False
                    _MapEditor.menuEnable()
                Case frmMapEditor.editingModes.LineEditingMode
                    ObjectEditF = False
                    ObjectTimeEditF = False
                    LineEditF = True
                    PropertyWindowF = True
                    DefAttributeF = False
                    MultiObjectsF = False
                    MulitLinesF = False
                    _MapEditor.menuEnable()
                Case frmMapEditor.editingModes.MultiObjectsEditingMode
                    ObjectEditF = False
                    ObjectTimeEditF = False
                    LineEditF = False
                    PropertyWindowF = True
                    DefAttributeF = False
                    MultiObjectsF = True
                    MulitLinesF = False
                    _MapEditor.menuEnable()
                Case frmMapEditor.editingModes.MultiLinesEditingMode
                    ObjectEditF = False
                    ObjectTimeEditF = False
                    LineEditF = False
                    PropertyWindowF = True
                    DefAttributeF = False
                    MultiObjectsF = False
                    MulitLinesF = True
                    _MapEditor.menuEnable()
            End Select

            .pnlObjectEdit.Visible = ObjectEditF
            .pnlObjectTimeEdit.Visible = ObjectTimeEditF
            .pnlLineEdit.Visible = LineEditF
            .pnlPropertyWindow.Visible = PropertyWindowF
            .pnlDefAttribute.Visible = DefAttributeF
            .pnlMultiObjects.Visible = MultiObjectsF
            .pnlMultiLines.Visible = MulitLinesF
        End With
    End Sub
    ''' <summary>
    ''' 複数選択ボタンをクリック
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub multiSelectButton(ByVal checked As Boolean)
        With _MapEditor
            If checked = True Then
                Select Case _MapEditor.EditingMode
                    Case frmMapEditor.editingModes.ObjectSearchingMode
                        .EditingMode = frmMapEditor.editingModes.MultiObjectsEditingMode
                        setRightPanelVisible()
                        .rbMultiObjectSelectMode_Pointing.Checked = True
                        EditingMultiObject.Clear()
                        setTabstripButtonAndMenuEnabled()
                        SetMultiObJInformation()
                        .gbObjTypeEdit.Enabled = False
                    Case frmMapEditor.editingModes.LineSearchingMode
                        .EditingMode = frmMapEditor.editingModes.MultiLinesEditingMode
                        setRightPanelVisible()
                        .rbMultiLineSelectMode_Pointing.Checked = True
                        EditingMultiLine.Clear()
                        setTabstripButtonAndMenuEnabled()
                        SetMultiLineInformation()
                End Select
            Else
                Select Case .EditingMode
                    Case frmMapEditor.editingModes.MultiObjectsEditingMode
                        cancelEditingObject()
                    Case frmMapEditor.editingModes.MultiLinesEditingMode
                        cancelEditingLine()
                End Select

            End If
            .menuEnable()
        End With
    End Sub
    Public Sub MulitLineCommand(ByVal ItemText As String)
        Dim co As Integer = ItemText.IndexOf(":")
        If co <> -1 Then
            ItemText = ItemText.Substring(co + 1)
        End If
        If EditingMultiLine.Count = 0 Then
            If ItemText <> "全て選択" Then
                Dim msgText1 As String = "ラインを選択してください。"
                MsgBox(msgText1, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If

        Select Case ItemText
            Case "線種設定"
                If MapData.Map.Time_Mode = False Then
                    Change_Selected_Line_Kind_No_Time()
                Else
                    Change_Selected_Line_Kind_With_Time()
                End If
            Case "分割＆結節点"

                MapEditorUndo.SetUndo_LineDivide_and_Node("複数ラインの分割&結節点")
                '分割されたラインを再分割できるように繰り返す
                Dim TargetLine As List(Of Integer) = New List(Of Integer)(EditingMultiLine)
                Dim LineSearchIndex As clsSpatialIndexSearch = getLineSearchIndex(MapData.Map.Circumscribed_Rectangle)
                Do
                    Dim AddTarget As New List(Of Integer)
                    For Each i As Integer In TargetLine
                        Dim LineDivide() As strLineDivideData_info = LineDivide_and_Node(MapData.MPLine(i), LineSearchIndex)
                        If LineDivide Is Nothing = False Then
                            For j As Integer = 0 To LineDivide.GetUpperBound(0)
                                If TargetLine.IndexOf(LineDivide(j).OriginalLineCode) <> -1 Then
                                    AddTarget.Add(LineDivide(j).AddedLineCode)
                                    EditingMultiLine.Add(LineDivide(j).AddedLineCode)
                                End If
                            Next
                        End If
                    Next
                    TargetLine = New List(Of Integer)(AddTarget)
                Loop Until TargetLine.Count = 0

                SetMultiLineInformation()
                EditMapping(True)
                Dim msgText As String = "分割&結節点を行いました。"
                MsgBox(msgText)
            Case "ラインを交点で切断"
                Dim E_L_F As Boolean
                Dim msgResult As MsgBoxResult = CutLine_by_CrossPoint_Sub_Check_sameLineKind(EditingMultiLine)
                Select Case msgResult
                    Case MsgBoxResult.Yes
                        E_L_F = True
                    Case MsgBoxResult.No
                        E_L_F = False
                    Case MsgBoxResult.Cancel
                        Exit Sub
                End Select

                Dim addline As Integer = CutLine_by_CrossPoint_Sub(EditingMultiLine, E_L_F)
                If addline = 0 Then
                    MsgBox("交差しているラインはありませんでした。")
                Else
                    For i As Integer = MapData.Map.ALIN - addline To MapData.Map.ALIN - 1
                        EditingMultiLine.Add(i)
                    Next
                    SetMultiLineInformation()
                    EditMapping(True)
                    Dim msgText As String = "切断した結果、" + addline.ToString + "本ラインが増加しました。"
                    MsgBox(msgText)
                End If
            Case "ラインの共有部分を別ラインに"
                Dim addline As Integer
                Dim s_ap As Integer = MapData.Get_All_MpLinePoint()
                Dim f As Boolean = TopologyLine_Sub(EditingMultiLine, addline)
                If f = False Then
                    MsgBox("共有部分を含むラインはありませんでした。")
                Else
                    Dim e_ap As Integer = MapData.Get_All_MpLinePoint()
                    EditingMultiLine.Clear()
                    SetMultiLineInformation()
                    EditMapping(True)
                    Dim msgText As String = "共有部分を切断した結果、" + addline.ToString + "本ラインが増加しました。" & vbCrLf +
                                            "ポイント数は" & s_ap & "から" & e_ap & "になりました。"
                    MsgBox(msgText)
                End If
            Case "ライン結合"
                Dim ReduceLineNum As Integer
                EditingMultiLine = LineConnectSub(EditingMultiLine, ReduceLineNum)
                If ReduceLineNum = 0 Then
                    MsgBox("結合されたラインはありません。", MsgBoxStyle.Exclamation)
                Else
                    EditMapping(True)
                    SetMultiLineInformation()
                    Dim txt As String = ReduceLineNum.ToString + "本ラインが減少しました。"
                    MsgBox(txt)
                End If
            Case "端点結合"

                Dim ConnectNeedLine As New List(Of Integer)
                For Each i As Integer In EditingMultiLine
                    With MapData.MPLine(i)
                        If .Connect = enmLineConnect.no Or .Connect = enmLineConnect.one Then
                            ConnectNeedLine.Add(i)
                        End If
                    End With
                Next
                If ConnectNeedLine.Count = 0 Then

                    Dim msgText As String = "端点結合の必要なラインはありません。"
                    MsgBox(msgText, MsgBoxStyle.Exclamation)
                Else
                    Dim iv As String = InputBox("結合するすき間の地図領域に対するしきい値（単位％,1％以下）を指定してください", , "0.1")
                    Dim v As Single
                    If iv = "" Then
                        Return
                    Else
                        v = Val(iv)
                        If v <= 0 Or 1 <= v Then
                            MsgBox("0より大きく1以下の値を指定してください。", MsgBoxStyle.Exclamation)
                            Return
                        End If
                    End If

                    Dim n As Integer = NodalPointMake(ConnectNeedLine, v)
                    If n = 0 Then
                        Dim msgText As String = "端点結合されたラインはありません。"
                        MsgBox(msgText, MsgBoxStyle.Exclamation)
                    Else
                        SetMultiLineInformation()
                        EditMapping(True)
                        Dim msgText As String = n.ToString + "箇所結合されました。"
                        MsgBox(msgText, MsgBoxStyle.Exclamation)
                    End If
                End If
            Case "ポイント・ループ間引き"
                SmoothingLine_sub(EditingMultiLine)
                EditingMultiLine.Clear()
                SetMultiLineInformation()
                EditMapping(True)
            Case "座標表示"
                Dim txtArray As New List(Of String)
                txtArray.Add(clsGeneric.getZahyoModeYString(MapData.Map.Zahyo.Mode) + vbTab +
                    clsGeneric.getZahyoModeXString(MapData.Map.Zahyo.Mode))
                For i As Integer = 0 To EditingMultiLine.Count - 1
                    txtArray.Add("ライン番号" + vbTab + EditingMultiLine.Item(i).ToString)
                    With MapData.MPLine(EditingMultiLine.Item(i))
                        For j As Integer = 0 To .NumOfPoint - 1
                            Dim p As PointF = spatial.Get_Reverse_XY(.PointSTC(j), MapData.Map.Zahyo)
                            txtArray.Add(clsGeneric.SingleToString(p.Y) + vbTab + clsGeneric.SingleToString(p.X))
                        Next
                    End With
                    If i <> EditingMultiLine.Count - 1 Then
                        txtArray.Add(vbTab)
                    End If
                Next
                clsGeneric.Message(_MapEditor, "選択中のラインの座標", txtArray, {VariantType.Single, VariantType.Single}, {False, False}, False, False)

            Case "削除"
                MapEditorUndo.SetUndo_EraseLine(EditingMultiLine, MapData.Map.Circumscribed_Rectangle)
                MapData.Erase_MultiLine(EditingMultiLine, True, True, True)
                EditingMultiLine.Clear()
                SetMultiLineInformation()
                EditMapping(True)
                Dim msgText As String = "選択したラインを削除しました。"
                MsgBox(msgText)

        End Select
    End Sub
    ''' <summary>
    ''' 端点結合(メニューから)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub NodalPointLine()
        Dim LList As List(Of Integer) = clsGeneric.Get_Specified_Value_Array(lineEnabled, MapData.Map.ALIN, True)
        If LList.Count = 0 Then
            MsgBox("対象ラインが存在しません。", MsgBoxStyle.Exclamation)
            Return
        End If
        If MsgBox("結節点でない最寄りの端点同士を結合します。", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim iv As String = InputBox("結合するすき間の地図領域に対するしきい値（%,1以下）を指定してください", , "0.05")
            Dim v As Single
            If iv = "" Then
                Return
            Else
                v = Val(iv)
                If v <= 0 Or 1 <= v Then
                    MsgBox("0より大きく1以下の値を指定してください。", MsgBoxStyle.Exclamation)
                    Return
                End If
            End If

            Dim n As Integer = NodalPointMake(LList, v)
            If n = 0 Then
                Dim msgText As String = "端点結合されたラインはありません。"
                MsgBox(msgText, MsgBoxStyle.Exclamation)
            Else
                EditMapping(True)
                Dim msgText As String = n.ToString + "箇所結合されました。"
                MsgBox(msgText, MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub
    ''' <summary>
    ''' 共有部分を別ラインに(メニューから)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub TopologyLine()
        Dim LList As List(Of Integer) = clsGeneric.Get_Specified_Value_Array(lineEnabled, MapData.Map.ALIN, True)
        If LList.Count = 0 Then
            MsgBox("対象ラインが存在しません。", MsgBoxStyle.Exclamation)
            Return
        End If
        If MsgBox("編集対象のラインで、複数ラインの共有部分を別ラインに設定します。", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim addline As Integer
            Dim s_ap As Integer = MapData.Get_All_MpLinePoint()
            Dim f As Boolean = TopologyLine_Sub(LList, addline)
            If f = False Then
                MsgBox("共有部分を含むラインはありませんでした。")
            Else
                Dim e_ap As Integer = MapData.Get_All_MpLinePoint()
                EditMapping(True)
                Dim msgText As String = "共有部分を切断した結果、" + addline.ToString + "本ラインが増加しました。" & vbCrLf +
                                            "ポイント数は" & s_ap & "から" & e_ap & "になりました。"
                MsgBox(msgText)
            End If
        End If

    End Sub
    ''' <summary>
    ''' 編集中の複数ラインの共有部分を別ラインに（位相構造化）
    ''' </summary>
    ''' <remarks></remarks>
    Private Function TopologyLine_Sub(TopoLineList As List(Of Integer), ByRef addLineNum As Integer) As Boolean

        Dim msgText As String = ""

        MapEditorUndo.SetUndo_LineDivide_and_Node("複数ラインの共有部分を別ラインに")
        Dim Oalin As Integer = MapData.Map.ALIN
        Dim f As Boolean = MapData.TopologyStructure_SameLine(TopoLineList)
        addLineNum = MapData.Map.ALIN - Oalin
        If f = False Then
            MapEditorUndo.RemoveLastUndo()
        Else
            Check_ALl_Line_Connect()
        End If
        Return f


    End Function
    ''' <summary>
    ''' 時空間モード時の複数ライン編集で線種・有効期間変更
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Change_Selected_Line_Kind_With_Time()
        Dim form As New frmMED_LineKindTimeSet
        Dim PushLine As clsMapData.strLine_Data = MapData.Init_One_Line(MapData.MPLine(EditingMultiLine.Item(0)).LineTimeSTC(0).Kind)
        PushLine.LineTimeSTC(0) = MapData.MPLine(EditingMultiLine.Item(0)).LineTimeSTC(0)
        If form.ShowDialog(_MapEditor, PushLine, MapData, _MapEditor.EditingMode) = Windows.Forms.DialogResult.OK Then
            MapEditorUndo.SetUndo_SaveLine("複数ラインの線種変更", EditingMultiLine, MapData.Map.Circumscribed_Rectangle)
            PushLine.LineTimeSTC = form.getResult(PushLine.NumOfTime, LastSavedLineKind)
            For Each i As Integer In EditingMultiLine
                With MapData.MPLine(i)
                    .NumOfTime = PushLine.NumOfTime
                    .LineTimeSTC = PushLine.LineTimeSTC.Clone
                End With
            Next
            Dim chkObj(MapData.Map.Kend - 1) As Boolean
            For Each i As Integer In EditingMultiLine
                Dim OCode() As Integer
                Dim n As Integer = MapData.Object_Using_Particular_Line(i, OCode)
                For j = 0 To n - 1
                    chkObj(OCode(j)) = True
                Next
            Next
            For i = 0 To MapData.Map.Kend - 1
                If chkObj(i) = True Then
                    MapData.MPObj(i).Shape = MapData.Check_Obj_Shape_AllTime(MapData.MPObj(i))
                End If
            Next
            EditMapping(True)
            SetMultiLineInformation()
            Dim msgText As String = "選択中のラインの線種・有効期間を変更しました。"
            MsgBox(msgText)
        End If

        form.Dispose()
    End Sub
    ''' <summary>
    ''' 編集中の複数ラインを交点で切断
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CutLine_by_CrossPoint()
        Dim LList As List(Of Integer) = clsGeneric.Get_Specified_Value_Array(lineEnabled, MapData.Map.ALIN, True)
        If LList.Count = 0 Then
            MsgBox("対象ラインが存在しません。", MsgBoxStyle.Exclamation)
            Return
        End If

        If MsgBox("編集対象のライン同士の交点で分割します。", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim E_L_F As Boolean
            Dim msgResult As MsgBoxResult = CutLine_by_CrossPoint_Sub_Check_sameLineKind(LList)
            Select Case msgResult
                Case MsgBoxResult.Yes
                    E_L_F = True
                Case MsgBoxResult.No
                    E_L_F = False
                Case MsgBoxResult.Cancel
                    Exit Sub
            End Select

            Dim addline As Integer = CutLine_by_CrossPoint_Sub(LList, E_L_F)
            If addline = 0 Then
                MsgBox("交差しているラインはありませんでした。")
            Else
                For i As Integer = MapData.Map.ALIN - addline To MapData.Map.ALIN - 1
                    EditingMultiLine.Add(i)
                Next
                EditMapping(True)
                Dim msgText As String = "切断した結果、" + addline.ToString + "本ラインが増加しました。"
                MsgBox(msgText)
            End If

        End If

    End Sub
    Private Function CutLine_by_CrossPoint_Sub_Check_sameLineKind(ByRef CutLineList As List(Of Integer)) As MsgBoxResult
        '選択ラインの線種をチェック
        Dim LK(MapData.Map.LpNum - 1) As Integer
        For Each i As Integer In CutLineList
            Dim L As Integer = MapData.MPLine(i).LineTimeSTC(0).Kind
            LK(L) = 1
        Next
        Dim n As Integer = 0
        For i As Integer = 0 To MapData.Map.LpNum - 1
            n += LK(i)
        Next

        If n = 1 Then
            Return MsgBoxResult.Yes
        Else
            Dim msgText As String = "複数の線種が含まれています。" + vbCrLf + "同一線種同士でも切断しますか？"
            Return MsgBox(msgText, MsgBoxStyle.YesNoCancel)

        End If
    End Function
    ''' <summary>
    ''' ラインを交点で切断
    ''' </summary>
    ''' <param name="CutLineList">切断するラインコードのList</param>
    ''' <param name="sameLineKindCutF">複数の線種が含まれる場合、同一線種の交差で切断する場合true。ただし、時間設定で同一ラインに複数の線種が設定してある場合は、最初の線種が使用される。</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CutLine_by_CrossPoint_Sub(ByRef CutLineList As List(Of Integer), ByVal sameLineKindCutF As Boolean) As Integer
        MapEditorUndo.SetUndo_LineDivide_and_Node("複数ラインを交点で切断")
        Dim Oalin As Integer = MapData.Map.ALIN
        MapData.CutLine_by_CrossPoint(CutLineList, sameLineKindCutF)
        Dim addLineNum As Integer = MapData.Map.ALIN - Oalin

        If addLineNum = 0 Then
            MapEditorUndo.RemoveLastUndo()
        End If
        Return addLineNum
    End Function
    ''' <summary>
    ''' 指定した複数のライン同士で、非結節点の末端同士を移動して、結節点化する（自分自身には結合しない）
    ''' </summary>
    ''' <param name="EDLCode">ライン番号のList</param>
    ''' <param name="Threshold_percent">結合させる閾値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function NodalPointMake(ByRef EDLCode As List(Of Integer), ByVal Threshold_percent As Single) As Integer


        Dim EndPointIndex As New clsSpatialIndexSearch
        Dim EDLNum As Integer = EDLCode.Count
        Dim EDLConnect(EDLNum - 1) As Integer
        Dim OLCode As New List(Of Integer)

        Dim Threshold_Dis As Single
        MapEditorUndo.SetUndo_LineDivide_and_Node("端点結合")
        With MapData.Map.Circumscribed_Rectangle
            Threshold_Dis = Math.Sqrt(2 * .Width * .Height) * Threshold_percent / 100
            EndPointIndex.Init(SpatialPointType.SinglePoint, True, .Left, .Top, .Right, .Bottom, Threshold_Dis)
        End With

        For i As Integer = 0 To EDLNum - 1
            Dim lcd As Integer = EDLCode.Item(i)
            With MapData.MPLine(lcd)
                If .Connect = 0 Then
                    EDLConnect(i) = 0
                Else
                    EDLConnect(i) = MapData.Check_Line_Connect_Detail(MapData.MPLine(lcd))
                End If
                Select Case EDLConnect(i)
                    Case 0
                        OLCode.Add(lcd * 10)
                        OLCode.Add(lcd * 10 + 1)
                        EndPointIndex.AddSinglePoint(.PointSTC(0), lcd * 10)
                        EndPointIndex.AddSinglePoint(.PointSTC(.NumOfPoint - 1), lcd * 10 + 1)
                    Case 1
                        OLCode.Add(lcd * 10 + 1)
                        EndPointIndex.AddSinglePoint(.PointSTC(.NumOfPoint - 1), lcd * 10 + 1)
                    Case 2
                        OLCode.Add(lcd * 10)
                        EndPointIndex.AddSinglePoint(.PointSTC(0), lcd * 10)
                End Select
            End With
        Next
        EndPointIndex.AddEnd()

        Dim ObStac() As Integer
        Dim PStac() As Integer
        Dim LCodeNumber() As Integer

        Dim Connected(OLCode.Count - 1) As Boolean
        Dim ConnectN As Integer = 0
        For i As Integer = 0 To OLCode.Count - 1
            'Dim lcd As Integer = EDLCode.Item(i)
            If Connected(i) = False Then
                Dim lcd As Integer = OLCode.Item(i) \ 10
                Dim sepoint As Integer = OLCode.Item(i) Mod 2
                With MapData.MPLine(lcd)
                    Select Case sepoint
                        Case 0
                            Dim n As Integer = EndPointIndex.GetNearestPointNumber(.PointSTC(0).X, .PointSTC(0).Y, Threshold_Dis, ObStac, PStac, LCodeNumber, 0, , New ArrayList(New Integer() {lcd * 10, lcd * 10 + 1}))
                            If n <> 0 Then
                                Dim XY As PointF
                                Dim conLCode As Integer = LCodeNumber(0) \ 10
                                With MapData.MPLine(conLCode)
                                    If LCodeNumber(0) Mod 2 = 0 Then
                                        XY = .PointSTC(0)
                                    Else
                                        XY = .PointSTC(.NumOfPoint - 1)
                                    End If
                                End With
                                .PointSTC(0) = XY
                                Connected(ObStac(0)) = True
                                ConnectN += 1
                                MapData.Check_Line_Maxmin(lcd, False)
                                MapData.Save_Line(MapData.MPLine(lcd), True, True, True)
                            End If
                        Case 1
                            Dim n As Integer = EndPointIndex.GetNearestPointNumber(.PointSTC(.NumOfPoint - 1).X, .PointSTC(.NumOfPoint - 1).Y, Threshold_Dis, ObStac, PStac, LCodeNumber, 0, , New ArrayList(New Integer() {lcd * 10, lcd * 10 + 1}))
                            If n <> 0 Then
                                Dim XY As PointF
                                Dim conLCode As Integer = LCodeNumber(0) \ 10
                                With MapData.MPLine(conLCode)
                                    If LCodeNumber(0) Mod 2 = 0 Then
                                        XY = .PointSTC(0)
                                    Else
                                        XY = .PointSTC(.NumOfPoint - 1)
                                    End If
                                End With
                                .PointSTC(.NumOfPoint - 1) = XY
                                Connected(ObStac(0)) = True
                                ConnectN += 1
                                MapData.Save_Line(MapData.MPLine(lcd), True, True, True)
                            End If
                    End Select
                End With

            End If
        Next

        If ConnectN = 0 Then
            MapEditorUndo.RemoveLastUndo()
        End If
        Return ConnectN
    End Function

    Public Sub MulitObjectsCommand(ByVal ItemText As String)

        Dim co As Integer = ItemText.IndexOf(":")
        If co <> -1 Then
            ItemText = ItemText.Substring(co + 1)
        End If
        If EditingMultiObject.Count = 0 Then
            If ItemText <> "オブジェクト名検索" And ItemText <> "全て選択" Then
                Dim msgText1 As String = "オブジェクトを選択してください。"
                MsgBox(msgText1, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        If MapData.Map.Time_Mode = True Then
            If ItemText = "境界線自動設定" Or ItemText = "代表点を重心に" Then
                Dim msgText1 As String = "時空間モードでは利用できません。"
                MsgBox(msgText1, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If

        If _MapEditor.EditList.ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
            If ItemText = "境界線自動設定" Or ItemText = "外側オブジェクト削除" Then
                Dim msgText1 As String = "集成オブジェクトでは利用できません。"
                MsgBox(msgText1, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If

        Select Case ItemText
            Case "オブジェクト名検索"
                Dim SearchObject As New frmSearch_Object
                Dim init_para As New frmSearch_Object.init_parameter_data(MapData)
                init_para.Time = _MapEditor.EditList.EditTime
                init_para.MultiSelect = True
                If SearchObject.ShowDialog(_MapEditor, MapData, init_para) = Windows.Forms.DialogResult.OK Then
                    SearchMultiObjectSelect(SearchObject.getSelectedObjectNumbers)
                End If
                SearchObject.Dispose()
            Case "結合"
                If EditingMultiObject.Count < 2 Then
                    Dim msgText1 As String = "複数のオブジェクトを選択してください。"
                    MsgBox(msgText1, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                CombineObjects()
            Case "境界線自動設定"
                MultiObjectsBoundarySelected()
            Case "代表点を重心に"
                MapEditorUndo.SetUndo_SaveObject("複数オブジェクトの代表点を重心に", EditingMultiObject, MapData.Map.Circumscribed_Rectangle)
                For Each ObjCode In EditingMultiObject
                    Dim f As Boolean = MapData.GetObjGraviityXY(MapData.MPObj(ObjCode), MapData.MPObj(ObjCode).CenterPSTC(0).Position, clsTime.GetNullYMD)
                Next
                EditMapping(True)
            Case "オブジェクトグループ変更"
                ChangeObjKind()
            Case "削除"
                MapEditorUndo.SetUndo_EraseObjects("複数オブジェクトの削除", EditingMultiObject, MapData.Map.Circumscribed_Rectangle)
                MapData.Erase_MultiObjects(EditingMultiObject, True)
                EditingMultiObject.Clear()
                SetMultiObJInformation()
                EditMapping(True)
            Case "使用ラインごと削除"
                Dim msgText As String
                If _MapEditor.EditList.ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                    msgText = "選択したオブジェクトを削除し、使用するラインが他のオブジェクトと共有されていなければ同時に削除します。"
                Else
                    msgText = "選択した集成オブジェクトを削除し、同時に集成オブジェクトを構成するオブジェクを削除します。" _
                        & vbCrLf & "さらに、およびその使用するラインが他のオブジェクトと共有さていなければ同時に削除します。"
                End If
                If MsgBox(msgText, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Delete_Multi_Object_with_use_Line(EditingMultiObject)
                    EditingMultiObject.Clear()
                    EditMapping(True)
                End If
            Case "外側オブジェクト削除"
                ObjectClipping()
            Case "メッシュオブジェクト作成"
                MeshMake_in_Multi_Object()
            Case "使用ライン線種変更"
                Change_Using_Line_Kind()
            Case "集成オブジェクトを構成"
                ComponentAggrObj()
            Case "選択オブジェクト名表示"
                Dim GridText As String = ""
                For Each i As Integer In EditingMultiObject
                    Dim oname As String
                    Dim sp As Integer
                    MapData.Get_Enable_ObjectName(MapData.MPObj(i), _MapEditor.EditList.EditTime, True, oname, sp, vbTab)
                    GridText += oname + vbCrLf
                Next
                GridText = GridText.Remove(GridText.Length - 2)
                clsGeneric.Message(_MapEditor, "選択オブジェクト数：" + EditingMultiObject.Count.ToString, GridText)
            Case "初期属性入力"
                Dim SelOKind As Integer = MapData.MPObj(EditingMultiObject.Item(0)).Kind
                For Each i As Integer In EditingMultiObject
                    If SelOKind <> MapData.MPObj(i).Kind Then
                        Dim msgText As String = "２種類以上のオブジェクトグループが選択されています。"
                        MsgBox(msgText, MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                Next
                If MapData.ObjectKind(SelOKind).DefTimeAttDataNum = 0 Then
                    Dim msgText As String = "選択したオブジェクトグループには初期属性データ項目が設定されていません。"
                    MsgBox(msgText, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                Dim form As New frmMED_MultiObjDefAttr
                Dim oldMapRect As RectangleF = MapData.Map.Circumscribed_Rectangle
                If form.ShowDialog(_MapEditor, EditingMultiObject, MapData) = DialogResult.OK Then
                    MapEditorUndo.SetUndo_SaveObject("複数オブジェクトの初期属性変更", EditingMultiObject, oldMapRect)
                    If MapData.Map.Time_Mode = False Then
                        Dim data(,) As String = form.getResult
                        Dim n As Integer = 0
                        For Each i As Integer In EditingMultiObject
                            For j As Integer = 0 To data.GetUpperBound(0)
                                MapData.MPObj(i).DefTimeAttValue(j).Data(0).Value = data(j, n)
                            Next
                            n += 1
                        Next
                    Else
                        form.getResult(MapData)
                    End If

                End If
                form.Dispose()
        End Select
    End Sub
    ''' <summary>
    ''' 集成オブジェクトを構成
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub ComponentAggrObj()
        If MapData.Check_AggregateObjectType_Exists() = False Then
            Dim msgText As String = "この地図ファイルには集成オブジェクトのグループがありません。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim SelMEOBJnum As Integer = EditingMultiObject.Count
        Dim Obk(MapData.Map.OBKNum - 1) As Boolean
        Dim ObkA() As Integer
        For i = 0 To SelMEOBJnum - 1
            Obk(MapData.MPObj(EditingMultiObject.Item(i)).Kind) = True
        Next
        Dim ObkSelNum As Integer = clsGeneric.Get_Specified_Value_Array(Obk, MapData.Map.OBKNum, True, ObkA)

        '上位階層となるオブジェクトグループを取得
        Dim UpperClassObjK As New List(Of Integer)
        For i = 0 To MapData.Map.OBKNum - 1
            If MapData.ObjectKind(i).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject And Obk(i) = False Then
                Dim f As Boolean = True
                For j = 0 To ObkSelNum - 1
                    If MapData.ObjectKind(i).UseObjectGroup(ObkA(j)) = False Then
                        f = False
                        Exit For
                    End If
                Next
                If f = True Then
                    UpperClassObjK.Add(i)
                End If
            End If
        Next
        If UpperClassObjK.Count = 0 Then
            Dim msgText As String = "選択オブジェクトを構成要素とする、集成オブジェクトはありません。"
            MsgBox(msgText, vbExclamation)
            Exit Sub
        End If

        Dim form As New frmMED_AggrObjSet
        If form.ShowDialog(_MapEditor, UpperClassObjK, MapData) = DialogResult.OK Then
            Dim ObjK As Integer
            Dim NewObjName As String = ""
            Dim ExistingObjectCode As Integer
            Dim NewObjF As Boolean = form.getResult(ObjK, ExistingObjectCode)
            If NewObjF = False Then
                '既存オブジェクトに追加
                MapEditorUndo.SetUndo_SaveObject("既存集成オブジェクトを構成", MapData.MPObj(ExistingObjectCode), MapData.Map.Circumscribed_Rectangle)
                With MapData.MPObj(ExistingObjectCode)
                    Dim AddObjS As New clsSortingSearch
                    AddObjS.AddInit(VariantType.Integer)
                    For i As Integer = 0 To .NumOfLine - 1
                        AddObjS.Add(.LineCodeSTC(i).LineCode)
                    Next
                    AddObjS.AddEnd()
                    ReDim Preserve .LineCodeSTC(.NumOfLine + SelMEOBJnum - 1)
                    Dim j As Integer = 0
                    For i As Integer = 0 To SelMEOBJnum - 1
                        If AddObjS.SearchData_One(EditingMultiObject.Item(i)) = -1 Then
                            With .LineCodeSTC(.NumOfLine + j)
                                .LineCode = EditingMultiObject.Item(i)
                                .NumOfTime = 0
                            End With
                            j += 1
                        End If
                    Next
                    .NumOfLine += j
                    ReDim Preserve .LineCodeSTC(Math.Max(.NumOfLine - 1, 0))
                End With
                _MapEditor.EditList.editEventStopF = True
                _MapEditor.tsbMultiSelect.Checked = False
                _MapEditor.EditList.editEventStopF = False
                _MapEditor.rbObjTypeEditAggregation.Checked = True
                setEditingObject(MapData.MPObj(ExistingObjectCode))
            Else
                '新規集成オブジェクト
                Dim newObj As clsMapData.strObj_Data = MapData.Init_One_Object(ObjK)
                With newObj
                    .Shape = MapData.ObjectKind(ObjK).Shape
                    .NumOfLine = SelMEOBJnum
                    ReDim .LineCodeSTC(SelMEOBJnum - 1)
                    Dim cxy As PointF
                    For i = 0 To SelMEOBJnum - 1
                        With .LineCodeSTC(i)
                            .LineCode = EditingMultiObject.Item(i)
                            .NumOfTime = 0
                        End With
                        With MapData.MPObj(EditingMultiObject.Item(i)).CenterPSTC(0).Position
                            cxy.X += .X
                            cxy.Y += .Y
                        End With
                    Next
                    .CenterPSTC(0).Position.X = cxy.X / SelMEOBJnum
                    .CenterPSTC(0).Position.Y = cxy.Y / SelMEOBJnum
                    With .NameTimeSTC(0)
                        ReDim .NamesList(MapData.ObjectKind(ObjK).ObjectNameNum - 1)
                        .NamesList(0) = NewObjName
                    End With
                End With
                MapEditorUndo.SetUndo_AddObject("新規集成オブジェクトを構成", MapData.Map.Kend, MapData.Map.Circumscribed_Rectangle)
                ReDim Preserve objectEnabled(MapData.Map.Kend)
                objectEnabled(MapData.Map.Kend) = True
                MapData.Save_Object(newObj, True)
                _MapEditor.EditList.editEventStopF = True
                _MapEditor.tsbMultiSelect.Checked = False
                _MapEditor.EditList.editEventStopF = False
                _MapEditor.rbObjTypeEditAggregation.Checked = True
                setEditingObject(newObj)
            End If

        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 複数ライン編集で線種の変更
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Change_Selected_Line_Kind_No_Time()
        Dim form As New frmMED_ChangeLineKind_in_MultiLineNoTime
        Dim LKindC(MapData.Map.LpNum - 1) As Boolean
        For Each i As Integer In EditingMultiLine
            LKindC(MapData.MPLine(i).LineTimeSTC(0).Kind) = True
        Next
        Dim LineKindName() As String
        Dim OriginUseLineKindNumber() As Integer
        Dim firstValue() As Integer
        Dim DataCount As Integer
        Dim clmComboBox As New DataGridViewComboBoxColumn
        If Get_SelecttableLineKind(LKindC, DataCount, LineKindName, firstValue, OriginUseLineKindNumber, clmComboBox) = False Then
            Exit Sub
        End If
        If form.ShowDialog(_MapEditor, "現在の線種", DataCount, LineKindName, firstValue, clmComboBox) = DialogResult.OK Then
            MapEditorUndo.SetUndo_SaveLine("複数ラインの線種変更", EditingMultiLine, MapData.Map.Circumscribed_Rectangle)
            Dim reValue As Integer() = form.getResult()
            For Each i As Integer In EditingMultiLine
                If MapData.LineKind(MapData.MPLine(i).LineTimeSTC(0).Kind).Mesh = enmMesh_Number.mhNonMesh Then
                    Dim lkn As Integer = Array.IndexOf(OriginUseLineKindNumber, MapData.MPLine(i).LineTimeSTC(0).Kind)
                    MapData.MPLine(i).LineTimeSTC(0).Kind = reValue(lkn)
                End If
            Next
            EditMapping(True)
            SetMultiLineInformation()
            Dim msgtext = "線種を変更しました"
            MsgBox(msgtext)
        End If
    End Sub
    Private Function Get_SelecttableLineKind(ByRef LKindC() As Boolean, ByRef DataCount As Integer, ByRef LineKindName() As String,
                                             ByRef firstValue() As Integer, ByRef OriginUseLineKindNumber() As Integer,
                                              ByRef clmComboBox As DataGridViewComboBoxColumn) As Boolean

        ReDim LineKindName(MapData.Map.LpNum - 1)
        ReDim OriginUseLineKindNumber(MapData.Map.LpNum - 1)
        ReDim firstValue(MapData.Map.LpNum - 1)

        DataCount = 0
        Dim ConvCount As Integer = 0
        clmComboBox.Items.Clear()
        clmComboBox.HeaderText = "変更後の線種"
        For i = 0 To MapData.Map.LpNum - 1
            If MapData.LineKind(i).Mesh = enmMesh_Number.mhNonMesh Then
                If LKindC(i) = True Then
                    LineKindName(DataCount) = MapData.LineKind(i).Name
                    OriginUseLineKindNumber(DataCount) = i
                    firstValue(DataCount) = ConvCount
                    DataCount += 1
                End If
                clmComboBox.Items.Add(MapData.LineKind(i).Name)
                ConvCount += 1
            End If
        Next
        If DataCount = 0 Then
            Dim txtMSG = "メッシュラインは変更できません。"
            MsgBox(txtMSG, MsgBoxStyle.Exclamation)
            Return False
        Else
            Return True
        End If

    End Function
    ''' <summary>
    ''' 複数オブジェクト選択で使用ライン線種変更
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Change_Using_Line_Kind()
        Dim Change_Line_List(MapData.Map.ALIN - 1) As Integer
        Dim LineNumber() As Integer
        Dim Muse_F As Boolean = False
        Dim form As New frmMED_ChengeLineKind_in_Multiobject

        For i As Integer = 0 To EditingMultiObject.Count - 1
            Dim Ocode As Integer = EditingMultiObject.Item(i)
            Dim ELN As Integer
            If MapData.ObjectKind(MapData.MPObj(Ocode).Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                ELN = MapData.Get_AggrOuterLine_AllTime(MapData.MPObj(Ocode), LineNumber)
            Else
                With MapData.MPObj(Ocode)
                    ReDim LineNumber(.NumOfLine)
                    ELN = .NumOfLine
                    For j = 0 To .NumOfLine - 1
                        LineNumber(j) = .LineCodeSTC(j).LineCode
                    Next
                End With
            End If
            For j As Integer = 0 To ELN - 1
                Dim n As Integer = LineNumber(j)
                Change_Line_List(n) += 1
                If Change_Line_List(n) >= 2 Then
                    Muse_F = True
                End If
            Next
        Next

        Dim LKindC(MapData.Map.LpNum - 1) As Boolean
        For i As Integer = 0 To MapData.Map.ALIN - 1
            If Change_Line_List(i) > 0 Then
                For j As Integer = 0 To MapData.MPLine(i).NumOfTime - 1
                    LKindC(MapData.MPLine(i).LineTimeSTC(j).Kind) = True
                Next
            End If
        Next

        Dim LineKindName() As String
        Dim OriginUseLineKindNumber() As Integer
        Dim firstValue() As Integer
        Dim DataCount As Integer
        Dim clmComboBox As New DataGridViewComboBoxColumn
        If Get_SelecttableLineKind(LKindC, DataCount, LineKindName, firstValue, OriginUseLineKindNumber, clmComboBox) = False Then
            Exit Sub
        End If


        If form.ShowDialog(_MapEditor, "使用中の線種", DataCount, LineKindName, firstValue, clmComboBox, Muse_F) = DialogResult.OK Then
            Dim KyoyuLineChangeF As Boolean
            Dim reValue As Integer() = form.getResult(KyoyuLineChangeF)
            MapEditorUndo.SetUndo_Change_Using_Line_Kind(Change_Line_List, OriginUseLineKindNumber, reValue, KyoyuLineChangeF)
            EditMapping(True)
            Dim msgtext = "線種を変更しました"
            MsgBox(msgtext)
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' メニューからメッシュオブジェクト作成
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub makeMakefromMenu()
        Dim CheckPolygon_s As New List(Of Integer)

        For i As Integer = 0 To MapData.Map.Kend - 1
            If objectEnabled(i) = True And MapData.MPObj(i).Shape = enmShape.PolygonShape Then
                CheckPolygon_s.Add(i)
            End If
        Next
        Dim f As Boolean = Make_MeshObject(CheckPolygon_s)

        If f = True Then
            EditMapping(True)
            Dim msgText = "メッシュオブジェクトを作成しました。"
            MsgBox(msgText)
        End If
    End Sub
    ''' <summary>
    ''' 複数オブジェクト選択でメッシュオブジェクト作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MeshMake_in_Multi_Object()

        If Check_EditingTime_Setting() = False Then
            Return
        End If


        Dim CheckPolygon_s As New List(Of Integer)
        For Each ObjCode As Integer In EditingMultiObject
            If MapData.MPObj(ObjCode).Shape = enmShape.PolygonShape Then
                CheckPolygon_s.Add(ObjCode)
            End If
        Next
        If CheckPolygon_s.Count = 0 Then
            Dim msgText = "面オブジェクトが選択されていません。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim f As Boolean = Make_MeshObject(CheckPolygon_s)

        If f = True Then
            EditMapping(True)
            Dim msgText = "メッシュオブジェクトを作成しました。"
            MsgBox(msgText)
        End If
    End Sub
    ''' <summary>
    ''' メッシュオブジェクト作成
    ''' </summary>
    ''' <param name="Check_Obj_Number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Make_MeshObject(ByRef Check_Obj_Number As List(Of Integer)) As Boolean

        Dim form As New frmMED_makeMesh
        Dim beforeKend As Integer = MapData.Map.Kend
        Dim beforeAlin As Integer = MapData.Map.ALIN
        Dim obknum As Integer = MapData.Map.OBKNum
        Dim LineKindnum As Integer = MapData.Map.LpNum
        Dim oldMapRect As RectangleF = MapData.Map.Circumscribed_Rectangle
        If form.ShowDialog(_MapEditor, Check_Obj_Number, MapData, _MapEditor.EditList.EditTime) = Windows.Forms.DialogResult.OK Then
            ScrData.MapRectangle = MapData.Map.Circumscribed_Rectangle
            ScrData.ScrView = MapData.Map.Circumscribed_Rectangle
            If MapData.Map.OBKNum <> obknum Then
                add_ObjectKindToList()
            End If
            If MapData.Map.LpNum <> LineKindnum Then
                add_LineKindToList()
            End If
            MapEditorUndo.SetUndo_Make_MeshObject("メッシュオブジェクトの作成", beforeKend, beforeAlin, (MapData.Map.OBKNum <> obknum), (MapData.Map.LpNum <> LineKindnum), oldMapRect)
            Return True
        Else
            Return False
        End If
        form.Dispose()

    End Function
    ''' <summary>
    ''' オブジェクトグループが追加された時、マップエディタのリストボックス等に反映する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub add_ObjectKindToList()

        Dim name As String = MapData.ObjectKind(MapData.Map.OBKNum - 1).Name
        With _MapEditor
            Dim n = .clbObjectKindEdit.Items.Count
            ReDim Preserve .EditList.ObjectKind(n)
            .EditList.ObjectKind(n) = True
            .EditList.editEventStopF = True
            .clbObjectKindEdit.Items.Add(name)
            .clbObjectKindEdit.SetItemChecked(n, True)
            .cboObjectKind.Items.Add(name)
            .cbObjectGroupTime.Items.Add(name)
            .EditList.editEventStopF = False
        End With
    End Sub
    ''' <summary>
    ''' 線種が追加された時、マップエディタのリストボックス等に反映する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub add_LineKindToList()

        Dim name As String = MapData.LineKind(MapData.Map.LpNum - 1).Name
        With _MapEditor
            Dim n = .clbLineKindEdit.Items.Count
            ReDim Preserve .EditList.LineKind(n)
            .EditList.LineKind(n) = True
            .EditList.editEventStopF = True
            .clbLineKindEdit.Items.Add(name)
            .clbLineKindEdit.SetItemChecked(n, True)
            .cboLineKind.Items.Add(name)
            .EditList.editEventStopF = False
        End With
    End Sub
    ''' <summary>
    ''' 指定した面オブジェクトの外側にあるオブジェクトを削除する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ObjectClipping()

        Dim msgText As String
        Dim SN As Integer = EditingMultiObject.Count

        If MapData.Check_Same_ObjectShape_in_Multi_Objects(EditingMultiObject, enmShape.PolygonShape) = False Then
            MsgBox("面形状以外の形状のオブジェクトが選択されています。", MsgBoxStyle.Exclamation)
            Return
        End If

        msgText = "選択したオブジェクトの外側のオブジェクトと、その使用ラインを削除します。"
        If MsgBox(msgText, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Cursor.Current = Cursors.WaitCursor
        Dim Out_Obj() As Integer
        Dim Out_Obj_n As Integer = Get_OutSide_Inside_Object(EditingMultiObject, 1, Out_Obj)

        If Out_Obj_n = 0 Then
            Cursor.Current = Cursors.Default
            msgText = "外側オブジェクトは存在しません。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim del_Line As Integer = MapData.Map.ALIN
        Dim Out_ObjArray As New List(Of Integer)(Out_Obj)
        Call Delete_Multi_Object_with_use_Line(Out_ObjArray)
        del_Line = del_Line - MapData.Map.ALIN

        For i As Integer = 0 To EditingMultiObject.Count - 1
            Dim objCode As Integer = EditingMultiObject.Item(i)
            Dim NewobjCode As Integer = objCode
            For j As Integer = 0 To Out_Obj_n - 1
                If Out_Obj(j) < objCode Then
                    NewobjCode -= 1
                End If
                EditingMultiObject.Item(i) = NewobjCode
            Next
        Next

        EditMapping(True)
        Cursor.Current = Cursors.Default

        If del_Line = 0 Then
            msgText = "範囲外側のオブジェクトを削除しました。"
        Else
            msgText = "範囲外側のオブジェクト" & Out_Obj_n & "とその使用ライン" & del_Line & "本を削除しました。"
        End If
        MsgBox(msgText)

    End Sub
    ''' <summary>
    ''' 指定したオブジェクト内部または外部のオブジェクト番号とその数を取得
    ''' </summary>
    ''' <param name="BaseObjectCodes">オブジェクト番号のList(Of Integer)</param>
    ''' <param name="In_Out_Get">1/Outを取得,-1/inを取得</param>
    ''' <param name="Get_Object">取得したオブジェクト番号（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_OutSide_Inside_Object(ByVal BaseObjectCodes As List(Of Integer), ByVal In_Out_Get As Integer, ByRef Get_Object() As Integer) As Integer

        Dim Values() As Integer = BaseObjectCodes.ToArray
        Return Get_OutSide_Inside_Object(Values, Values.GetUpperBound(0) + 1, In_Out_Get, Get_Object)
    End Function

    ''' <summary>
    ''' 指定したオブジェクト内部または外部のオブジェクト番号とその数を取得
    ''' </summary>
    ''' <param name="BaseObject">オブジェクト番号の配列</param>
    ''' <param name="BaseObject_Num">オブジェクトの数</param>
    ''' <param name="In_Out_Get">1/Outを取得,-1/inを取得</param>
    ''' <param name="Get_Object">取得したオブジェクト番号（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Function Get_OutSide_Inside_Object(ByVal BaseObject() As Integer, ByVal BaseObject_Num As Integer, ByVal In_Out_Get As Integer, ByRef Get_Object() As Integer) As Integer

        Dim Ken_Boundary_n As Integer, Ken_Boundary_Line() As Integer, Poly_Rect As RectangleF
        Dim Test_Obj() As Boolean
        Dim InOutObj() As Integer

        Dim E_Line() As clsMapData.EnableMPLine_Data

        Ken_Boundary_n = MapData.Get_MultiObject_Boundary(BaseObject, BaseObject_Num, _MapEditor.EditList.EditTime, Ken_Boundary_Line, Poly_Rect)
        ReDim Test_Obj(MapData.Map.Kend - 1)
        ReDim InOutObj(MapData.Map.Kend - 1)
        For i = 0 To MapData.Map.Kend - 1
            Test_Obj(i) = objectEnabled(i)
            If _MapEditor.EditList.ObjectType <> MapData.ObjectKind(MapData.MPObj(i).Kind).ObjectType Then
                Test_Obj(i) = False
            End If
        Next
        For i = 0 To BaseObject_Num - 1
            Test_Obj(BaseObject(i)) = False
        Next

        For i = 0 To MapData.Map.Kend - 1
            If Test_Obj(i) = True Then
                With MapData.MPObj(i)
                    If spatial.Compare_Two_Rectangle_Position(Poly_Rect, .Circumscribed_Rectangle) = cstRectangle_Cross.cstOuter Then
                        InOutObj(i) = 1
                    Else
                        '代表点チェック
                        Dim cvx As Single, cvy As Single
                        MapData.Get_Enable_CenterP(cvx, cvy, MapData.MPObj(i), _MapEditor.EditList.EditTime)
                        Dim f As Boolean = MapData.Check_Point_in_Polygon_LineCode(cvx, cvy, Ken_Boundary_n, Ken_Boundary_Line)
                        If f = True Then
                            '代表点が内部
                            InOutObj(i) = -1
                        Else
                            If .Shape = enmShape.PointShape Then
                                InOutObj(i) = 1
                            Else
                                '代表点が内部にない場合の線・面オブジェクトは線を一本ずつチェック
                                Dim Line_n As Integer = MapData.Get_EnableMPLine(E_Line, MapData.MPObj(i), _MapEditor.EditList.EditTime)
                                f = False
                                Dim j As Integer = 0
                                Do While j < Line_n And f = False
                                    With MapData.MPLine(E_Line(j).LineCode)
                                        If spatial.Compare_Two_Rectangle_Position(Poly_Rect, .Circumscribed_Rectangle) <> cstRectangle_Cross.cstOuter Then
                                            Dim k As Integer = 0
                                            Do While k < .NumOfPoint - 1 And f = False
                                                f = MapData.Check_Point_in_Polygon_LineCode(.PointSTC(k).X, .PointSTC(k).Y, Ken_Boundary_n, Ken_Boundary_Line)
                                                If f = True Then
                                                    InOutObj(i) = -1
                                                End If
                                                k += 1
                                            Loop
                                        End If
                                    End With
                                    j += 1
                                Loop
                                If f = False Then
                                    InOutObj(i) = 1
                                End If
                            End If
                        End If
                    End If
                End With
            Else
                InOutObj(i) = 0
            End If
        Next

        Dim n As Integer = clsGeneric.Get_Specified_Value_Array(InOutObj, MapData.Map.Kend, In_Out_Get, Get_Object)
        Return n
    End Function

    ''' <summary>
    ''' 複数オブジェクト選択で使用ラインごと削除
    ''' </summary>
    ''' <param name="ObjCodes"></param>
    ''' <remarks></remarks>
    Private Sub Delete_Multi_Object_with_use_Line(ByRef ObjCodes As List(Of Integer))

        Dim LineList() As Integer
        Dim n As Integer = 0

        Dim ErasedObjects As New ArrayList
        Dim EraseLine As New ArrayList

        Dim realEraseLines() As Integer
        Dim Kouho_ErasedLines() As clsMapData.strLine_Data

        Dim oldMapRect As RectangleF = MapData.Map.Circumscribed_Rectangle
        Dim SN As Integer = ObjCodes.Count
        If _MapEditor.EditList.ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
            ReDim LineList(0)
            For Each objCode As Integer In ObjCodes
                With MapData.MPObj(objCode)
                    ReDim Preserve LineList(n + .NumOfLine)
                    For j As Integer = 0 To .NumOfLine - 1
                        LineList(n) = .LineCodeSTC(j).LineCode
                        n += 1
                    Next
                End With
            Next
            For i As Integer = 0 To ObjCodes.Count - 1
                ErasedObjects.Add(MapData.MPObj(ObjCodes.Item(i)).Clone)
            Next

            ReDim Kouho_ErasedLines(LineList.Count - 1)
            For i As Integer = 0 To LineList.Count - 1
                Kouho_ErasedLines(i) = MapData.MPLine(LineList(i)).Clone
            Next
            MapData.Erase_MultiObjects(ObjCodes, False)
            realEraseLines = MapData.Erase_MultiLine(n, LineList, False, False, False)
        Else
            '集成オブジェクトのラインごと削除
            Dim AggUseObjectDel As New List(Of Integer)
            For Each objCode As Integer In ObjCodes
                With MapData.MPObj(objCode)
                    For j As Integer = 0 To .NumOfLine - 1
                        With .LineCodeSTC(j)
                            If MapData.ObjectKind(MapData.MPObj(.LineCode).Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                                '構成要素が集成オブジェクトだった場合
                                Dim AggObsSub() As Integer
                                Dim AggObsSubnum As Integer = MapData.Get_MpObj_used_AggregateObject(MapData.MPObj(.LineCode), clsTime.GetNullYMD, AggObsSub)
                                For k As Integer = 0 To AggObsSubnum - 1
                                    AggUseObjectDel.Add(AggObsSub(k))
                                Next
                            End If

                        End With
                        AggUseObjectDel.Add(.LineCodeSTC(j).LineCode)
                    Next
                End With
            Next
            ReDim LineList(0)
            For Each objCode As Integer In AggUseObjectDel
                With MapData.MPObj(objCode)
                    If MapData.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                        '構成要素オブジェクトが通常のオブジェクトの場合は削除ラインを設定
                        ReDim Preserve LineList(n + .NumOfLine)
                        For j As Integer = 0 To .NumOfLine - 1
                            LineList(n) = .LineCodeSTC(j).LineCode
                            n += 1
                        Next
                    End If
                End With
            Next
            '削除する構成要素オブジェクトと元の複数選択オブジェクトを追加する
            For Each objCode As Integer In ObjCodes
                AggUseObjectDel.Add(objCode)
            Next
            For i As Integer = 0 To AggUseObjectDel.Count - 1
                ErasedObjects.Add(MapData.MPObj(AggUseObjectDel.Item(i)).Clone)
            Next
            ReDim Kouho_ErasedLines(LineList.Count - 1)
            For i As Integer = 0 To LineList.Count - 1
                Kouho_ErasedLines(i) = MapData.MPLine(LineList(i)).Clone
            Next
            MapData.Erase_MultiObjects(AggUseObjectDel, False)
            realEraseLines = MapData.Erase_MultiLine(n, LineList, False, False, False)

        End If
        MapData.Map.Circumscribed_Rectangle = MapData.Get_Mapfile_Rectangle
        If realEraseLines Is Nothing = False Then
            For i As Integer = 0 To Kouho_ErasedLines.Count - 1
                'Kouho_ErasedLines(i)は同じラインがダブって入っていることがある
                Dim ix As Integer = Array.IndexOf(realEraseLines, Kouho_ErasedLines(i).Number)
                If ix <> -1 Then
                    realEraseLines(ix) = -1
                    EraseLine.Add(Kouho_ErasedLines(i).Clone())
                End If
            Next
        End If
        MapEditorUndo.SetUndo_EraseObjects_with_UseLines(ErasedObjects, EraseLine, oldMapRect)

    End Sub
    ''' <summary>
    ''' 複数オブジェクトのオブジェクトグループ変更
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChangeObjKind()
        Dim Obk(MapData.Map.OBKNum - 1)
        Dim NumdefAtt As Integer
        Dim ObkShape As enmShape
        For Each ObjCode In EditingMultiObject
            With MapData.MPObj(ObjCode)
                Obk(.Kind) += 1
                NumdefAtt = MapData.ObjectKind(.Kind).DefTimeAttDataNum
                ObkShape = MapData.ObjectKind(.Kind).Shape
            End With
        Next
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            If Obk(i) > 0 Then
                If MapData.ObjectKind(i).DefTimeAttDataNum <> NumdefAtt Then
                    Dim msgText As String = "初期属性数が異なるオブジェクトグループが複数選択されています。"
                    MsgBox(msgText, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                If MapData.ObjectKind(i).Shape <> ObkShape Then
                    Dim msgText As String = "形状が異なるオブジェクトグループが選択されています。"
                    MsgBox(msgText, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
        Next

        Dim OBName As New List(Of String)
        Dim OBNumber As New List(Of Integer)
        '変更可能なオブジェクトグループのみリストに入れる
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            With MapData.ObjectKind(i)
                If .ObjectType = _MapEditor.EditList.ObjectType And .Shape = ObkShape And NumdefAtt = .DefTimeAttDataNum Then
                    OBName.Add(.Name)
                    OBNumber.Add(i)
                End If
            End With
        Next
        If OBName.Count = 0 Then
            Dim msgText As String = "変更可能なオブジェクトグループがありません。"
            MsgBox(msgText)
            Exit Sub
        End If
        Dim seln As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("変更後オブジェクトグループ選択", OBName)
        If seln <> -1 Then
            Dim msgText As String = "選択したオブジェクトをグループを次のグループに変更します。" + vbCrLf + OBName.Item(seln)
            Dim oldMapRect As RectangleF = MapData.Map.Circumscribed_Rectangle
            If MsgBox(msgText, MsgBoxStyle.YesNo) = vbYes Then
                For Each ObjCode In EditingMultiObject
                    MapData.MPObj(ObjCode).Kind = OBNumber.Item(seln)
                Next
                MapEditorUndo.SetUndo_SaveObject("複数オブジェクトのオブジェクトグループ変更", EditingMultiObject, oldMapRect)
                Dim msgText1 As String = "オブジェクトグループを変更しました。"
                MsgBox(msgText1)
                EditMapping(True)
            End If
        End If
    End Sub
    ''' <summary>
    ''' 複数オブジェクトの境界線自動設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MultiObjectsBoundarySelected()
        Dim a As Long

        Dim LinePointIndex As clsSpatialIndexSearch

        LinePointIndex = New clsSpatialIndexSearch
        With MapData.Map.Circumscribed_Rectangle
            LinePointIndex.Init(SpatialPointType.SinglePoint, False, .Left, .Top, .Right, .Bottom, 0)
        End With
        For i As Integer = 0 To MapData.Map.ALIN - 1
            With MapData.MPLine(i)
                If lineEnabled(i) = True And .NumOfPoint > 0 Then
                    LinePointIndex.AddDoublePoint(.PointSTC(0), .PointSTC(.NumOfPoint - 1), i)
                End If
            End With
        Next
        LinePointIndex.AddEnd()

        Dim PLine() As Integer

        Cursor.Current = Cursors.WaitCursor

        'ProgressLabel.Visible = True
        'ProgressLabel.Start(SelMEOBJnum, "境界線設定中")


        Dim ln As Integer = 0
        Dim ern As Integer = 0
        Dim et = ""
        Dim RegObjArray As New List(Of Integer)
        For Each ObjCode In EditingMultiObject
            Dim PushObj As clsMapData.strObj_Data = MapData.MPObj(ObjCode).Clone
            If Peripheri(PushObj.CenterPSTC(0).Position, ln, PLine, PushObj.Kind, LinePointIndex) = False Then
                ern += 1
                et += vbCrLf & PushObj.NameTimeSTC(PushObj.NumOfNameTime - 1).connectNames
            Else
                RegObjArray.Add(ObjCode)
            End If
        Next
        If RegObjArray.Count > 0 Then
            MapEditorUndo.SetUndo_SaveObject("複数オブジェクトの境界線設定", RegObjArray, MapData.Map.Circumscribed_Rectangle)
        End If

        For Each ObjCode In RegObjArray
            Dim PushObj As clsMapData.strObj_Data = MapData.MPObj(ObjCode).Clone
            Peripheri(PushObj.CenterPSTC(0).Position, ln, PLine, PushObj.Kind, LinePointIndex)
            With PushObj
                ReDim .LineCodeSTC(ln - 1)
                For j As Integer = 0 To ln - 1
                    With .LineCodeSTC(j)
                        .LineCode = PLine(j)
                        .NumOfTime = 0
                    End With
                Next
                .NumOfLine = ln
                .Shape = enmShape.PolygonShape
            End With
            MapData.Save_Object(PushObj, True)
        Next

        Cursor.Current = Cursors.Default
        'ProgressLabel.Visible = False

        If ern <> 0 Then
            Dim msgText1 As String = ern & "個のオブジェクトの境界線が確定できませんでした。"
            MsgBox(msgText1, MsgBoxStyle.Exclamation)
            Dim onameList As String = "選択オブジェクト数:" + EditingMultiObject.Count.ToString + vbCrLf
            clsGeneric.Message(_MapEditor, "境界線未確定オブジェクト一覧", msgText1 & vbCrLf & et, True, True)
        End If
        EditMapping(True)
    End Sub
    ''' <summary>
    ''' 複数ライン編集モードで四角形・円選択
    ''' </summary>
    ''' <param name="MousePosition">マウス位置</param>
    ''' <param name="MouseUpF">マウスアップ時にtrue、move時にfalse</param>
    ''' <param name="CancelF">右クリックでキャンセルの際にtrue</param>
    ''' <remarks></remarks>
    Public Sub picMapMouseMoveMultiLineSelect_Shape(ByVal MousePosition As Point, ByVal MouseUpF As Boolean, ByVal CancelF As Boolean)
        Static MouseUpP As PointF
        Static MouseUpFirstF As Boolean = False
        Static PolygonP() As PointF
        Dim P As PointF = ScrData.getSRXY(MousePosition)
        If CancelF = True Then
            If MouseUpFirstF = True Then
                picMap.Refresh()
                MouseUpFirstF = False
                _MapEditor.pnlMultiLines.Enabled = True
            End If
            Exit Sub
        End If

        If MouseUpF = True Then
            If MouseUpFirstF = False Then
                '初回のマウスアップ
                MouseUpP = P
                MouseUpFirstF = True
                _MapEditor.pnlMultiLines.Enabled = False
                If _MapEditor.EditingMode_MultiLineSub = frmMapEditor.EditingModes_MultiLineSub.Polygon Then
                    ReDim PolygonP(0)
                    PolygonP(0) = P
                End If
            Else
                '二度目以降のマウスアップ
                Dim selectf As Boolean = True
                If _MapEditor.EditingMode_MultiLineSub = frmMapEditor.EditingModes_MultiLineSub.Polygon Then
                    Dim n As Integer = PolygonP.GetUpperBound(0)
                    If P.Equals(PolygonP(n)) = False Then
                        '多角形の場合、前のクリックした地点と同じ場所でクリックしたら終了、そうでなければ追加
                        ReDim Preserve PolygonP(n + 1)
                        PolygonP(n + 1) = P
                        selectf = False
                    End If
                End If
                If selectf = True Then
                    '四角形・円・多角形領域内のラインを検索・選択
                    'どの場合も領域をポリゴンにして検索する
                    picMap.Refresh()
                    MouseUpFirstF = False
                    Dim Polyrect As RectangleF

                    Select Case _MapEditor.EditingMode_MultiLineSub
                        Case frmMapEditor.EditingModes_MultiLineSub.Circle
                            Dim r As Single = spatial.get_Distance(MouseUpP, P)
                            PolygonP = spatial.Get_CirclePolygon(MouseUpP, r, 20)
                            Polyrect = New RectangleF(MouseUpP.X - r, MouseUpP.Y - r, r * 2, r * 2)
                        Case frmMapEditor.EditingModes_MultiLineSub.Rectangle
                            Polyrect = spatial.Get_Circumscribed_Rectangle(MouseUpP, P)
                            PolygonP = spatial.Get_PolyLine_from_Recatngle(Polyrect)
                        Case frmMapEditor.EditingModes_MultiLineSub.Polygon
                            Dim n As Integer = PolygonP.GetUpperBound(0)
                            ReDim Preserve PolygonP(n + 1)
                            PolygonP(n + 1) = PolygonP(0)
                            Polyrect = spatial.Get_Circumscribed_Rectangle(PolygonP, 0, PolygonP.GetLength(0))
                    End Select
                    For i As Integer = 0 To MapData.Map.ALIN - 1
                        If lineEnabled(i) = True Then
                            With MapData.MPLine(i)
                                If spatial.Check_Line_Relatiton_To_Polygon(.PointSTC, .NumOfPoint, .Circumscribed_Rectangle,
                                                 Polyrect, PolygonP, PolygonP.GetLength(0)) <> cstLinePolygonRelationd.cstOuter Then
                                    If EditingMultiLine.Contains(i) = False Then
                                        EditingMultiLine.Add(i)
                                    Else
                                        EditingMultiLine.RemoveAt(EditingMultiLine.IndexOf(i))
                                    End If
                                End If
                            End With
                        End If
                    Next
                    _MapEditor.pnlMultiLines.Enabled = True
                    SetMultiLineInformation()
                    EditMapping(False)
                End If
            End If
        ElseIf MouseUpFirstF = True Then
            '描画
            Dim MouseDownPositionScreen As Point = ScrData.getSxSy(MouseUpP)
            Dim g As Graphics = picMap.CreateGraphics
            Dim pen As New Pen(Color.FromArgb(180, 0, 0, 0), 2)
            pen.LineJoin = Drawing2D.LineJoin.Round
            Dim brush As New SolidBrush(Color.FromArgb(50, 0, 0, 0))
            picMap.Refresh()
            Select Case _MapEditor.EditingMode_MultiLineSub
                Case frmMapEditor.EditingModes_MultiLineSub.Rectangle
                    Dim Rect As Rectangle = spatial.Get_Circumscribed_Rectangle(MousePosition, MouseDownPositionScreen)
                    g.FillRectangle(brush, Rect)
                    g.DrawRectangle(pen, Rect)
                Case frmMapEditor.EditingModes_MultiLineSub.Circle
                    Dim r As Integer = spatial.get_Distance(MousePosition, MouseDownPositionScreen)
                    clsDraw.Ellipse(g, MouseDownPositionScreen, 3, pen)
                    clsDraw.Ellipse(g, MouseDownPositionScreen, r, brush, pen)
                Case frmMapEditor.EditingModes_MultiLineSub.Polygon
                    Dim n As Integer = PolygonP.GetUpperBound(0)
                    Dim Points(n + 1) As Point
                    For i As Integer = 0 To n
                        Points(i) = ScrData.getSxSy(PolygonP(i))
                    Next
                    Points(n + 1) = MousePosition
                    g.FillPolygon(brush, Points)
                    g.DrawPolygon(pen, Points)
            End Select
            pen.Dispose()
            brush.Dispose()
            g.Dispose()
        End If

    End Sub

    ''' <summary>
    ''' 複数オブジェクト編集モードで四角形・円選択
    ''' </summary>
    ''' <param name="MousePosition">マウス位置</param>
    ''' <param name="MouseUpF">マウスアップ時にtrue、move時にfalse</param>
    ''' <param name="CancelF">右クリックでキャンセルの際にtrue</param>
    ''' <remarks></remarks>
    Public Sub picMapMouseMoveMultiObjectSelect_Shape(ByVal MousePosition As Point, ByVal MouseUpF As Boolean, ByVal CancelF As Boolean)
        Static MouseUpP As PointF
        Static MouseUpFirstF As Boolean = False
        Static PolygonP() As PointF
        Dim P As PointF = ScrData.getSRXY(MousePosition)
        If CancelF = True Then
            If MouseUpFirstF = True Then
                picMap.Refresh()
                MouseUpFirstF = False
                _MapEditor.pnlMultiObjects.Enabled = True
            End If
            Exit Sub
        End If

        If MouseUpF = True Then
            If MouseUpFirstF = False Then
                '初回のマウスアップ
                MouseUpP = P
                MouseUpFirstF = True
                _MapEditor.pnlMultiObjects.Enabled = False
                If _MapEditor.EditingMode_MultiObjectSub = frmMapEditor.EditingModes_MultiObjectSub.Polygon Then
                    ReDim PolygonP(0)
                    PolygonP(0) = P
                End If
            Else
                '二度目以降のマウスアップ
                Dim selectf As Boolean = True
                If _MapEditor.EditingMode_MultiObjectSub = frmMapEditor.EditingModes_MultiObjectSub.Polygon Then
                    Dim n As Integer = PolygonP.GetUpperBound(0)
                    If P.Equals(PolygonP(n)) = False Then
                        '多角形の場合、前のクリックした地点と同じ場所でクリックしたら終了、そうでなければ追加
                        ReDim Preserve PolygonP(n + 1)
                        PolygonP(n + 1) = P
                        selectf = False
                    End If
                End If
                If selectf = True Then
                    '四角形・円・多角形領域内のオブジェクトを検索・選択
                    picMap.Refresh()
                    MouseUpFirstF = False
                    Dim r As Single
                    Dim Polyrect As RectangleF
                    Select Case _MapEditor.EditingMode_MultiObjectSub
                        Case frmMapEditor.EditingModes_MultiObjectSub.Circle
                            r = spatial.get_Distance(MouseUpP, P)
                        Case frmMapEditor.EditingModes_MultiObjectSub.Polygon
                            Polyrect = spatial.Get_Circumscribed_Rectangle(PolygonP, 0, PolygonP.GetUpperBound(0) + 1)
                    End Select
                    For i As Integer = 0 To MapData.Map.Kend - 1
                        If objectEnabled(i) = True Then
                            With MapData.MPObj(i)
                                For j As Integer = 0 To .NumOfCenterP - 1
                                    Dim f As Boolean = False
                                    Select Case _MapEditor.EditingMode_MultiObjectSub
                                        Case frmMapEditor.EditingModes_MultiObjectSub.Rectangle
                                            f = spatial.Get_Circumscribed_Rectangle(MouseUpP, P).Contains(.CenterPSTC(j).Position)
                                        Case frmMapEditor.EditingModes_MultiObjectSub.Circle
                                            If spatial.get_Distance(.CenterPSTC(j).Position, MouseUpP) <= r Then
                                                f = True
                                            End If
                                        Case frmMapEditor.EditingModes_MultiObjectSub.Polygon
                                            If Polyrect.Contains(.CenterPSTC(j).Position) = True Then
                                                Dim Cross_x(0) As Single
                                                Dim crn As Integer = 0
                                                Dim n As Integer = PolygonP.GetUpperBound(0)
                                                ReDim Preserve PolygonP(n + 1)
                                                PolygonP(n + 1) = PolygonP(0)
                                                f = spatial.check_Point_in_Polygon(.CenterPSTC(j).Position, PolygonP)
                                            End If
                                    End Select
                                    If f = True Then
                                        If EditingMultiObject.Contains(i) = False Then
                                            EditingMultiObject.Add(i)
                                        Else
                                            EditingMultiObject.RemoveAt(EditingMultiObject.IndexOf(i))
                                        End If
                                        Exit For
                                    End If
                                Next
                            End With
                        End If
                    Next
                    removeDifferentObjectType(EditingMultiObject)
                    _MapEditor.pnlMultiObjects.Enabled = True
                    SetMultiObJInformation()
                    EditMapping(False)
                End If
            End If
        ElseIf MouseUpFirstF = True Then
            '描画
            Dim MouseDownPositionScreen As Point = ScrData.getSxSy(MouseUpP)
            Dim g As Graphics = picMap.CreateGraphics
            Dim pen As New Pen(Color.FromArgb(180, 0, 0, 0), 2)
            pen.LineJoin = Drawing2D.LineJoin.Round
            Dim brush As New SolidBrush(Color.FromArgb(50, 0, 0, 0))
            picMap.Refresh()
            Select Case _MapEditor.EditingMode_MultiObjectSub
                Case frmMapEditor.EditingModes_MultiObjectSub.Rectangle
                    Dim Rect As Rectangle = spatial.Get_Circumscribed_Rectangle(MousePosition, MouseDownPositionScreen)
                    g.FillRectangle(brush, Rect)
                    g.DrawRectangle(pen, Rect)
                Case frmMapEditor.EditingModes_MultiObjectSub.Circle
                    Dim r As Integer = spatial.get_Distance(MousePosition, MouseDownPositionScreen)
                    clsDraw.Ellipse(g, MouseDownPositionScreen, 3, pen)
                    clsDraw.Ellipse(g, MouseDownPositionScreen, r, brush, pen)
                Case frmMapEditor.EditingModes_MultiObjectSub.Polygon
                    Dim n As Integer = PolygonP.GetUpperBound(0)
                    Dim Points(n + 1) As Point
                    For i As Integer = 0 To n
                        Points(i) = ScrData.getSxSy(PolygonP(i))
                    Next
                    Points(n + 1) = MousePosition
                    g.FillPolygon(brush, Points)
                    g.DrawPolygon(pen, Points)
            End Select
            pen.Dispose()
            brush.Dispose()
            g.Dispose()
        End If

    End Sub
    ''' <summary>
    ''' 複数オブジェクトモードの結合
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CombineObjects()

        Dim SN As Integer = EditingMultiObject.Count

        If Check_ObjectShape_for_Combine(EditingMultiObject) = False Then
            Dim msgText As String = "異なる形状のオブジェクトが含まれています。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Check_ObjectKind_for_Combine(EditingMultiObject) = False Then
            Dim msgText As String = "複数のオブジェクトグループが含まれています。よろしいですか？"
            If MsgBox(msgText, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        If MapData.Map.Time_Mode = True Then
            '時空間モードの結合(オブジェクトの保存まで行う。関連オブジェクトの継承が設定されるため)

            Dim form As New frmMED_TimeObjectCombine

            If form.ShowDialog(_MapEditor, EditingMultiObject, MapData) = Windows.Forms.DialogResult.OK Then
                Dim End_F As Boolean, suc_f As Boolean, S_time As strYMD, E_Time As strYMD
                Dim O_Name As String()
                Dim Connect_Mode As Integer, Change_ObjName_F As Boolean, LiveObject As Integer
                Dim EM As String = ""
                form.getResult(LiveObject, Connect_Mode, Change_ObjName_F, S_time, End_F, suc_f, O_Name)
                If S_time.nullFlag = False Then
                    E_Time = clsTime.getYesterday(S_time)
                Else
                    E_Time = clsTime.GetNullYMD
                End If
                MapEditorUndo.SetUndo_SaveObject("時空間モードオブジェクトの結合", EditingMultiObject, MapData.Map.Circumscribed_Rectangle)
                EditingObject = MapData.Combine_TimeObjects(EditingMultiObject, S_time, Connect_Mode, _
                                    End_F, suc_f, LiveObject, Change_ObjName_F, O_Name, EM)
                If EM = "" Then
                    If EditingObject.Number = -1 Then
                        ReDim Preserve objectEnabled(MapData.Map.Kend)
                        objectEnabled(MapData.Map.Kend) = True
                    End If
                    MapData.Save_Object(EditingObject, True)
                    setEditingObject(EditingObject)
                    _MapEditor.EditList.editEventStopF = True
                    _MapEditor.tsbMultiSelect.Checked = False
                    _MapEditor.EditList.editEventStopF = False
                Else
                    MapEditorUndo.RemoveLastUndo()
                    MsgBox(EM, MsgBoxStyle.Exclamation)
                End If
            End If
            form.Dispose()

        Else
            '非時空間モードの結合(オブジェクトの保存まで行わない)
            Dim newName As String() = MapData.MPObj(EditingMultiObject(0)).NameTimeSTC(0).NamesList.Clone
            setEditingObject(MapData.Combine_Objects(newName, EditingMultiObject, clsTime.GetNullYMD))
            _MapEditor.EditList.editEventStopF = True
            _MapEditor.tsbMultiSelect.Checked = False
            _MapEditor.EditList.editEventStopF = False
        End If
    End Sub
    ''' <summary>
    ''' List(Of Integer)中のオブジェクトの形状が一種類だけだった場合はTrue複数はFalseを返す
    ''' </summary>
    ''' <param name="ObjectCode">List(Of Integer)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_ObjectShape_for_Combine(ByRef ObjectCode As List(Of Integer)) As Boolean

        Dim k As enmShape = MapData.MPObj(ObjectCode.Item(0)).Shape
        For i As Integer = 1 To ObjectCode.Count - 1
            If MapData.MPObj(ObjectCode.Item(i)).Shape <> k Then
                Return False
            End If
        Next
        Return True

    End Function
    ''' <summary>
    ''' List(Of Integer)中のオブジェクトのオブジェクトグループが一つだけだった場合はTrue複数はFalseを返す
    ''' </summary>
    ''' <param name="ObjectCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_ObjectKind_for_Combine(ByRef ObjectCode As List(Of Integer)) As Boolean

        Dim k As Integer = MapData.MPObj(ObjectCode.Item(0)).Kind
        For i As Integer = 1 To ObjectCode.Count - 1
            If MapData.MPObj(ObjectCode.Item(i)).Kind <> k Then
                Return False
            End If
        Next
        Return True

    End Function
    Public Sub LineTimeKindSet()
        Dim form As New frmMED_LineKindTimeSet

        If form.ShowDialog(_MapEditor, EditingLine, MapData, _MapEditor.EditingMode) = Windows.Forms.DialogResult.OK Then
            EditingLine.LineTimeSTC = form.getResult(EditingLine.NumOfTime, LastSavedLineKind)
            setEditingLine(EditingLine)
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' オブジェクトグループ設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Function SettingObjectGroup() As Boolean
        Dim form = New frmMED_ObjectKind
        Dim f As Boolean = False
        If form.ShowDialog(_MapEditor, MapData) = Windows.Forms.DialogResult.OK Then
            MapEditorUndo.Set_Undo_SettingObjectGroup("オブジェクトグループ設定")
            Dim old2newObjGroupNumber() As Integer
            Dim oldObkNum As Integer = MapData.Map.OBKNum
            MapData.ObjectKind = form.getResult(MapData.Map.OBKNum, old2newObjGroupNumber)
            For i As Integer = 0 To MapData.Map.Kend - 1
                MapData.MPObj(i).Kind = old2newObjGroupNumber(MapData.MPObj(i).Kind)
            Next
            '線種のオブジェクトグループ連動型のグループ設定
            For i As Integer = 0 To MapData.Map.LpNum - 1
                With MapData.LineKind(i)
                    Dim n As Integer = 1
                    For j As Integer = 1 To .NumofObjectGroup - 1
                        If old2newObjGroupNumber(.ObjGroup(j).GroupNumber) <> -1 Then
                            .ObjGroup(n).GroupNumber = old2newObjGroupNumber(.ObjGroup(j).GroupNumber)
                            n += 1
                        End If
                    Next
                    .NumofObjectGroup = n
                End With
            Next

            refreshObjectKindList(old2newObjGroupNumber)

            EditMapping(True)
            f = True
        End If
        form.Dispose()
        Return f
    End Function
    ''' <summary>
    ''' 線種設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SettingLineKind()
        Dim attr As New clsAttrData(TileMap)
        attr.TotalData.ViewStyle.ScrData = ScrData
        attr.TotalData.BasePicture = clsBase.PictureNoUse
        Dim form = New frmMED_LineKind
        If form.ShowDialog(_MapEditor, MapData, attr) = Windows.Forms.DialogResult.OK Then
            MapEditorUndo.Set_Undo_SettingLineKind("線種設定")
            Dim old2newLineKindNumber() As Integer
            Dim oldLpNum As Integer = MapData.Map.LpNum
            Dim UseLine_by_ObjectKind(,) As Boolean
            With MapData
                .LineKind = form.getResult(.Map.LpNum, old2newLineKindNumber, UseLine_by_ObjectKind)
                For i As Integer = 0 To .Map.OBKNum - 1
                    If .ObjectKind(i).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                        ReDim .ObjectKind(i).UseLineType(.Map.LpNum - 1)
                        For j As Integer = 0 To .Map.LpNum - 1
                            .ObjectKind(i).UseLineType(j) = UseLine_by_ObjectKind(i, j)
                        Next
                    End If
                Next
                For i As Integer = 0 To .Map.ALIN - 1
                    With .MPLine(i)
                        For j As Integer = 0 To .NumOfTime - 1
                            .LineTimeSTC(j).Kind = old2newLineKindNumber(.LineTimeSTC(j).Kind)
                        Next

                    End With
                Next
            End With

            refreshLineKindList(old2newLineKindNumber)
            EditMapping(True)

        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 線種統合
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CombineLineKind()
        Dim form = New frmMED_LineKindCombine
        If form.ShowDialog(ScrData, MapData, clsBase.PictureNoUse) = Windows.Forms.DialogResult.OK Then
            MapEditorUndo.Set_Undo_SettingLineKind("線種統合")
            Dim LinePatName As String = "", Lpat As New Line_Property
            Dim combinef() As Boolean = form.getResult(LinePatName, Lpat)
            Dim old2newLineKindNumber() As Integer = MapData.Combine_Linekinds(combinef, LinePatName, Lpat)
            refreshLineKindList(old2newLineKindNumber)
            EditMapping(True)
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 線種設定、線種統合後の左側リストを変更
    ''' </summary>
    ''' <param name="old2newLineKindNumber"></param>
    ''' <remarks></remarks>
    Public Sub refreshLineKindList(ByRef old2newLineKindNumber() As Integer)
        With _MapEditor
            Dim oldLpNum As Integer = old2newLineKindNumber.Count
            Dim EditLine(MapData.Map.LpNum - 1) As Boolean
            For i As Integer = 0 To MapData.Map.LpNum - 1
                EditLine(i) = True
            Next
            For i As Integer = 0 To oldLpNum - 1
                If old2newLineKindNumber(i) <> -1 Then
                    EditLine(old2newLineKindNumber(i)) = .EditList.LineKind(i)
                End If
            Next
            .EditList.LineKind = EditLine.Clone
            .clbLineKindEdit.BeginUpdate()
            .clbLineKindEdit.EventStop = True
            .clbLineKindEdit.Items.Clear()
            For i As Integer = 0 To MapData.Map.LpNum - 1
                .clbLineKindEdit.Items.Add(MapData.LineKind(i).Name, .EditList.LineKind(i))
            Next
            .clbLineKindEdit.EndUpdate()
            .clbLineKindEdit.EventStop = False
        End With

    End Sub
    ''' <summary>
    ''' オブジェクトグループ統合
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CombineObjectKind()
        Dim form = New frmMED_ObjectKindCombine
        If form.ShowDialog(MapData) = Windows.Forms.DialogResult.OK Then
            MapEditorUndo.Set_Undo_SettingObjectGroup("オブジェクトグループ統合")
            Dim ObjGName As String = ""
            Dim combinef() As Boolean = form.getResult(ObjGName)
            Dim old2newObjGroupNumber() As Integer = MapData.Combine_Objectkinds(combinef, ObjGName)
            refreshObjectKindList(old2newObjGroupNumber)
            EditMapping(True)
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' オブジェクト設定、オブジェクト統合後の左側リストを変更
    ''' </summary>
    ''' <param name="old2newObjGroupNumber"></param>
    ''' <remarks></remarks>
    Public Sub refreshObjectKindList(ByRef old2newObjGroupNumber() As Integer)
        With _MapEditor
            Dim EditObj(MapData.Map.OBKNum - 1) As Boolean
            Dim oldObkNum = old2newObjGroupNumber.Count
            For i As Integer = 0 To MapData.Map.OBKNum - 1
                EditObj(i) = True
            Next
            For i As Integer = 0 To oldObkNum - 1
                If old2newObjGroupNumber(i) <> -1 Then
                    EditObj(old2newObjGroupNumber(i)) = _MapEditor.EditList.ObjectKind(i)
                End If
            Next
            .EditList.ObjectKind = EditObj.Clone
            .clbObjectKindEdit.BeginUpdate()
            .clbObjectKindEdit.EventStop = True
            .clbObjectKindEdit.Items.Clear()
            For i As Integer = 0 To MapData.Map.OBKNum - 1
                .clbObjectKindEdit.Items.Add(MapData.ObjectKind(i).Name, .EditList.ObjectKind(i))
            Next
            .clbObjectKindEdit.EndUpdate()
            .clbObjectKindEdit.EventStop = False
        End With
    End Sub
    ''' <summary>
    ''' 初期属性データ編集
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EditingDefAttData()
        Dim form = New frmMED_DefAttData
        If form.ShowDialog(MapData) = Windows.Forms.DialogResult.OK Then
            MapEditorUndo.SetUndo_EditingDefAttData()

            Dim newMPdata = form.getResult()
            For i As Integer = 0 To MapData.Map.OBKNum - 1
                MapData.ObjectKind(i) = newMPdata.ObjectKind(i).Clone
            Next
            For i As Integer = 0 To MapData.Map.Kend - 1
                If newMPdata.MPObj(i).DefTimeAttValue Is Nothing = True Then
                    Erase MapData.MPObj(i).DefTimeAttValue
                Else
                    MapData.MPObj(i).DefTimeAttValue = clsGeneric.DefTimeAttValueClone(newMPdata.MPObj(i).DefTimeAttValue)
                End If
            Next
            EditMapping(True)
        End If
        form.Dispose()
    End Sub

    ''' <summary>
    ''' 初期時点属性データ編集
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EditingDefPointAttData()
        Dim form = New frmMED_DefTimeAttData
        If form.ShowDialog(_MapEditor, MapData) = Windows.Forms.DialogResult.OK Then
            MapEditorUndo.SetUndo_EditingDefAttData()
            form.getResults(MapData)
            EditMapping(True)
        End If
        form.Dispose()

    End Sub
    ''' <summary>
    ''' 方位設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SettingCompass()
        Dim form = New frmCompassSetting
        If form.ShowDialog(_MapEditor, MapData.Map.MapCompass, ScrData) = DialogResult.OK Then
            MapEditorUndo.SetUndo_Compass("方位設定")
            MapData.Map.MapCompass = form.getResult
            EditMapping(False)
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' Undo
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Undo()
        Dim f As Boolean = MapEditorUndo.Undo()
        '複数選択モードの場合はUndoで選択解除
        Select Case _MapEditor.EditingMode
            Case frmMapEditor.editingModes.MultiObjectsEditingMode
                EditingMultiObject.Clear()
                SetMultiObJInformation()
            Case frmMapEditor.editingModes.MultiLinesEditingMode
                EditingMultiLine.Clear()
                SetMultiLineInformation()
        End Select
        If f = True Then
            ScrData.init(picMap, New ScreenMargin(3, 3, 3, 3, False), MapData.Map.Circumscribed_Rectangle, True, True)
        End If
        EditMapping(True)
    End Sub
    ''' <summary>
    ''' オブジェクト名置換
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReplaceObjectName()
        Dim form = New frmMED_ReplaceObjectName
        form.ShowDialog(_MapEditor, MapData)
        Dim UndoObj As List(Of clsMapData.Object_NameTimeStac_Data())
        If form.getResult(UndoObj) = True Then
            MapEditorUndo.SetUndo_ReplaceObjectName("オブジェクト名置換", UndoObj)
        End If
        form.Dispose()
        If clsSettings.Data.MapEditor.ObjectNameVisibleFlag = True Then
            EditMapping(False)
        End If
    End Sub
    ''' <summary>
    ''' オブジェクト名一括変換
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ChangeAllObjectName()
        Dim form = New frmMED_ChangeAllObjectName
        If form.ShowDialog(_MapEditor, MapData, objectEnabled) = DialogResult.OK Then
            Dim UndoObj As List(Of clsMapData.Object_NameTimeStac_Data())
            If form.getResult(UndoObj) = True Then
                MapEditorUndo.SetUndo_ReplaceObjectName("オブジェクト名一括変換", UndoObj)
            End If
        End If
        form.Dispose()
        If clsSettings.Data.MapEditor.ObjectNameVisibleFlag = True Then
            EditMapping(False)
        End If
    End Sub
    ''' <summary>
    ''' オフジェクト名編集
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ObjectNameEdit()
        If MapData.Map.Time_Mode = True Then
            Dim form = New frmMED_ObjectTimeNameEdit
            If form.ShowDialog(MapData) = DialogResult.OK Then
                MapEditorUndo.SetUndo_ObjectNameListChange("オブジェクト名編集")
                form.GetResults()
                If clsSettings.Data.MapEditor.ObjectNameVisibleFlag = True Then
                    EditMapping(False)
                End If
            End If
            form.Dispose()
        Else
            Dim form = New frmMED_ObjectNameEdit
            If form.ShowDialog(MapData) = DialogResult.OK Then
                MapEditorUndo.SetUndo_ObjectNameListChange("オブジェクト名編集")
                form.GetResults()
                If clsSettings.Data.MapEditor.ObjectNameVisibleFlag = True Then
                    EditMapping(False)
                End If
            End If
            form.Dispose()
        End If
    End Sub
    ''' <summary>
    ''' 初期属性からオブジェクト名追加（使われていない）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ObjectNameAddFromAttrData()
        Dim form = New frmMED_ObjectNameAddFromAttrData
        If form.ShowDialog(_MapEditor, MapData, 0) = DialogResult.OK Then
            MapEditorUndo.SetUndo_ObjectNameListChange("初期属性からオブジェクト名追加")
            Dim OBG As Integer
            Dim DataNum As Integer
            form.GetResults(OBG, DataNum)
            Dim title As String = MapData.ObjectKind(OBG).DefTimeAttSTC(DataNum).attData.Title
            MapData.Add_one_ObjectNameList(OBG, title)
            Dim ObjNameN As Integer = MapData.ObjectKind(OBG).ObjectNameNum
            For i As Integer = 0 To MapData.Map.Kend - 1
                With MapData.MPObj(i)
                    If .Kind = OBG Then
                        Dim v As String = ""
                        For j As Integer = 0 To .NumOfNameTime - 1
                            With .NameTimeSTC(j)
                                Dim time As strYMD
                                If MapData.Map.Time_Mode = False Then
                                    time = clsTime.GetNullYMD
                                Else
                                    time = .SETime.StartTime
                                End If
                                ReDim Preserve .NamesList(ObjNameN - 1)
                                If MapData.Get_DefTimeAttrValue(i, DataNum, time, v) = True Then
                                    .NamesList(ObjNameN - 1) = v
                                End If
                            End With
                        Next
                    End If
                End With
            Next
            MsgBox(MapData.ObjectKind(OBG).Name + "のオブジェクト名に" + title + "の値を追加しました。")
            If clsSettings.Data.MapEditor.ObjectNameVisibleFlag = True Then
                EditMapping(False)
            End If
        End If

        form.Dispose()

    End Sub
    ''' <summary>
    ''' オブジェクト名のクリック割り当て
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClickSetObjName()
        If Check_EditingTime_Setting() = False Then
            Return
        End If

        clsGeneric.set_FormPosition_toMousePosition(My.Forms.frmMED_ClickSetObjName, VisualStyles.VerticalAlignment.Top)
        My.Forms.frmMED_ClickSetObjName.Show(_MapEditor)
        AddHandler My.Forms.frmMED_ClickSetObjName.Closed, AddressOf frmMED_ClickSetObjName_Closed
        _MapEditor.EditingMode = frmMapEditor.editingModes.Set_ClickObjectName
        setTabstripButtonAndMenuEnabled()
        _MapEditor.menuEnable()
        EditingObject.Number = -1
    End Sub
    ''' <summary>
    ''' frmMED_ClickSetObjNameでClosedイベントが発生した場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMED_ClickSetObjName_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        _MapEditor.EditingMode = frmMapEditor.editingModes.ObjectSearchingMode
        setTabstripButtonAndMenuEnabled()
        _MapEditor.menuEnable()
    End Sub
    ''' <summary>
    ''' オブジェクト名のクリック割り当てでオブジェクトを選択
    ''' </summary>
    ''' <param name="Obj"></param>
    ''' <remarks></remarks>
    Private Sub Set_ClickObjectNameSelObj(ByVal Obj As clsMapData.strObj_Data)
        Dim seln As Integer = My.Forms.frmMED_ClickSetObjName.lbObjName.SelectedIndex
        If seln = -1 Then
            MsgBox("オブジェクト名のリストを選択してください。", MsgBoxStyle.Exclamation)
            picMap.Refresh()
            Return
        End If
        EditingObject = Obj.Clone()
        EditMapping(False)
        Dim cname As String() = My.Forms.frmMED_ClickSetObjName.newObjName(seln)
        If MapData.ObjectKind(EditingObject.Kind).ObjectNameNum <> cname.Length Then
            MsgBox("オブジェクト名リスト数が異なります。", MsgBoxStyle.Exclamation)
            EditingObject.Number = -1
            EditMapping(False)
            Return
        End If
        Dim NameStr As String
        Dim stacP As Integer
        MapData.Get_Enable_ObjectName(EditingObject, _MapEditor.EditList.EditTime, True, NameStr, stacP)
        Dim f As Boolean = True
        If My.Forms.frmMED_ClickSetObjName.cbConfirm.Checked = True Then
            If MsgBox(NameStr & vbCrLf & " > " & Join(cname, "/"), vbYesNo) = MsgBoxResult.No Then
                f = False
                EditingObject.Number = -1
                EditMapping(False)
            End If
        End If
        If f = True Then
            EditingObject.NameTimeSTC(stacP).NamesList = cname.Clone
            With My.Forms.frmMED_ClickSetObjName
                If .ChangeObjNameFlag = False Then
                    Dim UndoObj As List(Of clsMapData.Object_NameTimeStac_Data()) = MapData.Get_All_ObjectName()
                    MapEditorUndo.SetUndo_ReplaceObjectName("オブジェクト名のクリック割り当て", UndoObj)
                    .ChangeObjNameFlag = True
                End If
                MapData.Save_Object(EditingObject, True)
                Dim maxn As Integer = .lbObjName.Items.Count
                If seln = maxn - 1 Then
                    seln = 0
                Else
                    seln += 1
                End If
                .lbObjName.SelectedIndex = seln
            End With
        End If
        EditingObject.Number = -1
        EditMapping(False)
    End Sub
    ''' <summary>
    ''' 同一のオブジェクト名のオブジェクトを結合
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CombineSameNameObjecs()
        Dim mtx As String = "同一のオブジェクト名のオブジェクトを結合"
        Dim UndoObj(MapData.Map.Kend - 1) As clsMapData.strObj_Data
        For i As Integer = 0 To MapData.Map.Kend - 1
            UndoObj(i) = MapData.MPObj(i).Clone
        Next
        Dim mes As String
        Dim n As Integer = MapData.CombineSameNameObjecs(objectEnabled, mes)
        If n = 0 Then
            If mes <> "" Then
                clsGeneric.Message(_MapEditor, mtx, mes, True, True)
            Else
                MsgBox("同一オブジェクト名のオブジェクトは見つかりませんでした。", MsgBoxStyle.Exclamation)
            End If
        Else
            MapEditorUndo.SetUndo_CombineSameObjectName(mtx, UndoObj)
            mes = "結合したオブジェクト" + vbCrLf + vbCrLf + mes
            clsGeneric.Message(_MapEditor, mtx, mes, True, True)
            EditMapping(True)
        End If
    End Sub
    ''' <summary>
    ''' 集成オブジェクトにまとめて設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AggrObjClipSet()
        Dim form = New frmMED_AggrObjClipSet
        If form.ShowDialog(_MapEditor, MapData) = DialogResult.OK Then
            Dim AddObj() As Integer = form.getResult()
            MapEditorUndo.SetUndo_AddObject("集成オブジェクトにまとめて設定", AddObj, MapData.Map.Circumscribed_Rectangle)
            EditMapping(True)
        End If
        form.Dispose()
    End Sub

    ''' <summary>
    ''' 代表点の一括設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CenterPointSet()
        Dim form = New frmMED_CenterPointSet
        Dim oldMapRect As RectangleF = MapData.Map.Circumscribed_Rectangle
        If form.ShowDialog(_MapEditor, MapData) = DialogResult.OK Then
            Dim saveObj() As clsMapData.strObj_Data = form.getResult()
            MapEditorUndo.SetUndo_SaveObject("代表点の一括設定", saveObj, oldMapRect)
            EditMapping(True)
            MsgBox("代表点の座標を設定しました。")
        End If
        form.Dispose()

    End Sub

    ''' <summary>
    ''' 点オブジェクトの取り込み
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetPointObject()
        Dim form = New frmMED_GetPointObject
        Dim oldMapRect As RectangleF = MapData.Map.Circumscribed_Rectangle
        If form.ShowDialog(_MapEditor, MapData) = DialogResult.OK Then
            Dim beforeKend As Integer
            Dim ObjGAddF As Boolean
            form.getResult(beforeKend, ObjGAddF)
            If ObjGAddF = True Then
                add_ObjectKindToList()
            End If
            MapEditorUndo.SetUndo_Make_MeshObject("点オブジェクトの取り込み", beforeKend, MapData.Map.ALIN, ObjGAddF, False, oldMapRect)

            EditMapping(True)
            MsgBox((MapData.Map.Kend - beforeKend).ToString + "オブジェクトを取り込みました。")
        End If
        form.Dispose()
    End Sub
    Public Sub LineConnect()
        Dim LList As List(Of Integer) = clsGeneric.Get_Specified_Value_Array(lineEnabled, MapData.Map.ALIN, True)
        If LList.Count = 0 Then
            MsgBox("対象ラインが存在しません。", MsgBoxStyle.Exclamation)
            Return
        End If
        If MsgBox("編集対象のラインで、端点が同じラインで結合可能なラインを結合します。", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim ReduceLineNum As Integer
            LineConnectSub(LList, ReduceLineNum)
            If ReduceLineNum = 0 Then
                MsgBox("結合されたラインはありません。", MsgBoxStyle.Exclamation)
            Else
                EditMapping(True)
                Dim txt As String = ReduceLineNum.ToString + "本ラインが減少しました。"
                MsgBox(txt)
            End If
        End If
    End Sub
    ''' <summary>
    ''' ライン結合
    ''' </summary>
    ''' <param name="ConnectLineCode">結合候補のライン番号のList(Of Integer)</param>
    ''' <returns>残ったライン番号のList(Of Integer)</returns>
    ''' <remarks></remarks>
    Private Function LineConnectSub(ByVal ConnectLineCode As List(Of Integer), ByRef ReduceLineNum As Integer) As List(Of Integer)
        MapEditorUndo.SetUndo_LineDivide_and_Node("ライン結合")
        Dim Lcode() As Integer = ConnectLineCode.ToArray
        Dim oldalin As Integer = MapData.Map.ALIN
        Dim restLine As List(Of Integer) = MapData.Connect_Line(Lcode.GetLength(0), Lcode)
        ReduceLineNum = oldalin - MapData.Map.ALIN
        If ReduceLineNum = 0 Then
            MapEditorUndo.RemoveLastUndo()
        End If
        Return restLine
    End Function
    ''' <summary>
    ''' ポイント・ループ間引き(メニューから)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SmoothingLine()
        Dim LList As List(Of Integer) = clsGeneric.Get_Specified_Value_Array(lineEnabled, MapData.Map.ALIN, True)
        If LList.Count = 0 Then
            MsgBox("対象ラインが存在しません。", MsgBoxStyle.Exclamation)
            Return
        End If
        SmoothingLine_sub(LList)
        EditMapping(True)
    End Sub
    Private Sub SmoothingLine_sub(ByRef LList As List(Of Integer))
        Dim form = New frmSmootingLineIn
        Dim oldMapRect As RectangleF = MapData.Map.Circumscribed_Rectangle
        Dim PointInterval As Single = MapData.Get_Interval_of_LinePoint(LList, 1)
        Dim LoopSize As Single = 0
        If form.ShowDialog(_MapEditor, False, PointInterval, False, LoopSize, True, MapData.Map.SCL_U) = DialogResult.OK Then
            MapEditorUndo.SetUndo_SmoothingLine("ポイント・ループ間引き", MapData.MPObj, MapData.MPLine, MapData.Map.Circumscribed_Rectangle)
            Dim TF As Boolean, LF As Boolean
            form.getResult(TF, PointInterval, LF, LoopSize)
            Dim Cng As Integer = 0
            If TF = True Then
                Cng = 1
            End If
            If LF = True Then
                Cng = Cng Or 2
            End If
            If Cng = 0 Then
                Return
            End If
            Dim wtx As String
            Select Case Cng
                Case 1
                    wtx = "ポイント間引き"
                Case 2
                    wtx = "ループ間引き"
                Case 3
                    wtx = "ポイント・ループ間引き"
            End Select
            Dim O_Map As clsMapData.strMap_data = MapData.Map
            Dim s_men As Single = LoopSize
            Dim EDLNum As Integer = LList.Count
            Dim s_ap As Integer = MapData.Get_All_MpLinePoint()
            If TF = True Then
                'ポイント間引き
                For i As Integer = 0 To EDLNum - 1
                    MapData.Smoothing_Line_by_LineCode(MapData.MPLine(LList.Item(i)), PointInterval)
                Next
            End If

            If LF = True Then
                'ループ間引き
                Dim DelLCode As New List(Of Integer)
                For i As Integer = 0 To EDLNum - 1
                    Dim Lcode As Integer = LList.Item(i)
                    Dim men As Single = MapData.Get_LoopLine_Menseki(Lcode)
                    If men < s_men And men <> -1 Then
                        Dim O_Code() As Integer
                        Dim O_Num As Integer = MapData.Get_Object_UsingLine(Lcode, O_Code)
                        Dim del_f As Boolean = True
                        For j As Integer = 0 To O_Num - 1
                            'ラインを使用しているオブジェクトをチェックし、当該オブジェクトの使用するラインが
                            '該当ラインのみの場合は削除しない
                            If MapData.MPObj(O_Code(j)).NumOfLine = 1 Then
                                del_f = False
                                Exit For
                            End If
                        Next
                        If del_f = True Then
                            DelLCode.Add(Lcode)
                        End If
                    End If
                Next
                MapData.Erase_MultiLine(DelLCode, True, False, True)
            End If
            Dim e_ap As Integer = MapData.Get_All_MpLinePoint()
            EditMapping(True)

            Dim wtx2 As String
            Select Case Cng
                Case 1
                    wtx2 = "ポイント数は" & s_ap & "から" & e_ap & "になりました。"
                Case 2, 3
                    wtx2 = "ポイント数は" & s_ap & "から" & e_ap & "になりました。" & vbCrLf & _
                        "ライン数は" & O_Map.ALIN & "から" & MapData.Map.ALIN & "になりました。"
            End Select
            MsgBox(wtx & "が完了しました。" & vbCrLf & vbCrLf & wtx2)
        End If
        form.Dispose()

    End Sub
    ''' <summary>
    ''' 編集中のラインの座標値の表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub showLineCoord()
        Dim txtArray As New List(Of String)
        txtArray.Add(clsGeneric.getZahyoModeYString(MapData.Map.Zahyo.Mode) + vbTab +
            clsGeneric.getZahyoModeXString(MapData.Map.Zahyo.Mode))
        For i As Integer = 0 To EditingLine.NumOfPoint - 1
            Dim p As PointF = spatial.Get_Reverse_XY(EditingLine.PointSTC(i), MapData.Map.Zahyo)
            txtArray.Add(clsGeneric.SingleToString(p.Y) + vbTab + clsGeneric.SingleToString(p.X))
        Next
        clsGeneric.Message(_MapEditor, "編集中のラインの座標", txtArray, {VariantType.Single, VariantType.Single}, {False, False}, True, False)
    End Sub

    Public Sub MultiObjectSelect(ByVal selectMethod As String)
        Select Case selectMethod
            Case "すべて選択"
                For i As Integer = 0 To MapData.Map.Kend - 1
                    If objectEnabled(i) = True Then
                        If EditingMultiObject.Contains(i) = False Then
                            EditingMultiObject.Add(i)
                        End If
                    End If
                Next
            Case "選択解除"
                EditingMultiObject.Clear()
                SetMultiObJInformation()
                EditMapping(False)
            Case "選択/非選択交換"
                Dim presentSelect(MapData.Map.Kend - 1) As Boolean
                For i As Integer = 0 To EditingMultiObject.Count - 1
                    presentSelect(EditingMultiObject.Item(i)) = True
                Next
                EditingMultiObject.Clear()
                For i As Integer = 0 To MapData.Map.Kend - 1
                    If objectEnabled(i) = True And presentSelect(i) = False Then
                        EditingMultiObject.Add(i)
                    End If
                Next

            Case "外側オブジェクト選択"
                If Check_EditingTime_Setting() = False Then
                    Return
                End If
                If MapData.Check_Same_ObjectShape_in_Multi_Objects(EditingMultiObject, enmShape.PolygonShape) = False Then
                    MsgBox("面形状以外の形状のオブジェクトが選択されています。", MsgBoxStyle.Exclamation)
                    Return
                End If
                Dim Out_Obj() As Integer
                Dim Out_Obj_n As Integer = Get_OutSide_Inside_Object(EditingMultiObject, 1, Out_Obj)
                If Out_Obj_n = 0 Then
                    Dim msgText = "外側オブジェクトは存在しません。"
                    MsgBox(msgText, MsgBoxStyle.Exclamation)
                    Return
                Else
                    EditingMultiObject.Clear()
                    EditingMultiObject.AddRange(Out_Obj)
                End If
            Case "内側オブジェクト選択"
                If Check_EditingTime_Setting() = False Then
                    Return
                End If
                If MapData.Check_Same_ObjectShape_in_Multi_Objects(EditingMultiObject, enmShape.PolygonShape) = False Then
                    MsgBox("面形状以外の形状のオブジェクトが選択されています。", MsgBoxStyle.Exclamation)
                    Return
                End If

                Dim In_Obj() As Integer
                Dim In_Obj_n As Integer = Get_OutSide_Inside_Object(EditingMultiObject, -1, In_Obj)
                If In_Obj_n = 0 Then
                    Dim msgText = "内側オブジェクトは存在しません。"
                    MsgBox(msgText, MsgBoxStyle.Exclamation)
                    Return
                Else
                    EditingMultiObject.Clear()
                    EditingMultiObject.AddRange(In_Obj)
                End If
        End Select
        removeDifferentObjectType(EditingMultiObject)
        SetMultiObJInformation()
        EditMapping(False)

    End Sub
    ''' <summary>
    ''' 時期限定が設定されている場合はtrue、そうでない場合は警告表示とfalse
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_EditingTime_Setting() As Boolean
        If MapData.Map.Time_Mode = True And _MapEditor.EditList.EditTime.nullFlag = True Then
            Dim msgText = "編集対象選択パネルで時期限定を設定して下さい。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' 複数ラインの選択ボタン
    ''' </summary>
    ''' <param name="selectMethod"></param>
    ''' <remarks></remarks>
    Public Sub MultiLineSelect(ByVal selectMethod As String)
        Select Case selectMethod
            Case "すべて選択"
                EditingMultiLine.Clear()
                For i As Integer = 0 To MapData.Map.ALIN - 1
                    If lineEnabled(i) = True Then
                        EditingMultiLine.Add(i)
                    End If
                Next
                SetMultiLineInformation()
                EditMapping(False)
            Case "選択解除"
                EditingMultiLine.Clear()
                SetMultiLineInformation()
                EditMapping(False)
            Case "選択/非選択交換"
                Dim presentSelect(MapData.Map.ALIN - 1) As Boolean
                For i As Integer = 0 To EditingMultiLine.Count - 1
                    presentSelect(EditingMultiLine.Item(i)) = True
                Next
                EditingMultiLine.Clear()
                For i As Integer = 0 To MapData.Map.ALIN - 1
                    If lineEnabled(i) = True And presentSelect(i) = False Then
                        EditingMultiLine.Add(i)
                    End If
                Next
        End Select
        SetMultiLineInformation()
        EditMapping(False)

    End Sub
    ''' <summary>
    ''' ラインの取り込み（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetLine()
        Dim form = New frmMED_GetLine
        Dim oldMapRect As RectangleF = MapData.Map.Circumscribed_Rectangle
        If form.ShowDialog(_MapEditor, MapData) = DialogResult.OK Then
            Dim beforeAlin As Integer
            Dim LkAddF As Boolean
            form.getResult(beforeAlin, LkAddF)
            If LkAddF = True Then
                add_LineKindToList()
            End If
            MapEditorUndo.SetUndo_Make_MeshObject("ラインの取り込み", MapData.Map.Kend, beforeAlin, False, LkAddF, oldMapRect)
            EditMapping(True)
            MsgBox((MapData.Map.ALIN - beforeAlin).ToString + "本ラインを取り込みました。")

        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 世界測地系に変換（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Convert_Tokyo97toITRF94()
        If MapData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
            MsgBox("緯度経度座標系でないと変換できません。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MapData.Map.Zahyo.System = enmZahyo_System_Info.Zahyo_System_World Then
            MsgBox("既に世界測地系になっています。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MapData.Map.Zahyo.System <> enmZahyo_System_Info.Zahyo_System_tokyo Then
            MsgBox("日本測地系からしか変換できません。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox("日本測地系の緯度経度座標を世界測地系に変換します。", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        MapEditorUndo.SetUndo_ZahyoConvert("日本測地系を世界測地系に変換", MapData)
        MapData.Conv_Tokyo97_ITRF94(1)
        showAllMapArea()

        MsgBox("世界測地系に変換しました。")
    End Sub
    ''' <summary>
    ''' 日本測地系に変換（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Convert_ITRF94toTokyo97()
        If MapData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
            MsgBox("緯度経度座標系でないと変換できません。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MapData.Map.Zahyo.System = enmZahyo_System_Info.Zahyo_System_tokyo Then
            MsgBox("既に日本測地系になっています。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MapData.Map.Zahyo.System <> enmZahyo_System_Info.Zahyo_System_World Then
            MsgBox("世界測地系からしか変換できません。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox("世界測地系の緯度経度座標を日本測地系に変換します。", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        MapEditorUndo.SetUndo_ZahyoConvert("世界測地系を日本測地系に変換", MapData)
        MapData.Conv_Tokyo97_ITRF94(0)
        showAllMapArea()

        MsgBox("日本測地系に変換しました。")
    End Sub
    ''' <summary>
    ''' 平面直角座標系を緯度経度に変換（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Convert_XY2IdoKedo()
        If MapData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_HeimenTyokkaku Then
            MsgBox("平面直角座標系でないと変換できません。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MapData.Map.Zahyo.System = enmZahyo_System_Info.Zahyo_System_No Then
            MsgBox("測地系が設定してありません。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox("平面直角座標系を緯度経度座標系に変換します。", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        MapEditorUndo.SetUndo_ZahyoConvert("平面直角座標系を緯度経度座標系に変換", MapData)
        MapData.Conv_Tokyo97_ITRF94(2)
        showAllMapArea()
        MsgBox("緯度経度座標系に変換しました。")
    End Sub
    ''' <summary>
    ''' 測地系の入れ替え（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Replace_ITRF94_Tokyo97()
        Select Case MapData.Map.Zahyo.System
            Case enmZahyo_System_Info.Zahyo_System_No
                MsgBox("測地系が設定してありません。", MsgBoxStyle.Exclamation)
            Case enmZahyo_System_Info.Zahyo_System_World
                MapEditorUndo.SetUndo_Replace_ITRF94_Tokyo97("測地系の入れ替え")
                MapData.Map.Zahyo.System = enmZahyo_System_Info.Zahyo_System_tokyo
                MsgBox("座標値はそのままで測地系を日本測地系に設定しました。")
            Case enmZahyo_System_Info.Zahyo_System_tokyo
                MapEditorUndo.SetUndo_Replace_ITRF94_Tokyo97("測地系の入れ替え")
                MapData.Map.Zahyo.System = enmZahyo_System_Info.Zahyo_System_World
                MsgBox("座標値はそのままで測地系を世界測地系に設定しました。")
        End Select
    End Sub
    ''' <summary>
    ''' 緯度経度平行移動（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub idokedoMove()
        If MapData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
            MsgBox("緯度経度座標系ではありません。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim form = New frmMED_LatLonInput
        Dim oldMapRect As RectangleF = MapData.Map.Circumscribed_Rectangle
        If form.ShowDialog(_MapEditor, 0, 0, 0) = DialogResult.OK Then
            Dim plus As PointF = form.getResult()
            MapEditorUndo.SetUndo_ZahyoConvert("緯度経度平行移動", MapData)
            If MapData.LatLonMove(plus.Y, plus.X) = False Then
                MapEditorUndo.RemoveLastUndo()
                MsgBox("緯度の値が-90～90から外れたため、移動できませんでした。", MsgBoxStyle.Exclamation)
            Else
                showAllMapArea()
                MsgBox("緯度経度を移動しました。")
            End If
        End If
        form.Dispose()

    End Sub
    ''' <summary>
    ''' 投影法変換（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ProjectionConvert()
        If MapData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
            MsgBox("緯度経度座標系ではありません。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim form = New frmProjectionConvert
        Dim oldMapRect As RectangleF = MapData.Map.Circumscribed_Rectangle
        If form.ShowDialog(_MapEditor, MapData.Map.Zahyo, oldMapRect) = DialogResult.OK Then
            Dim centerLon As Single
            Dim newPrj As enmProjection_Info
            form.getResult(centerLon, newPrj)
            MapEditorUndo.SetUndo_ZahyoConvert("投影法変換", MapData)
            MapData.ProjectionConvert(centerLon, newPrj)
            showAllMapArea()
            MsgBox("投影法を変換しました。")

        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 背景画像表示
    ''' </summary>
    ''' <param name="formshowf"></param>
    ''' <remarks></remarks>
    Public Sub BackImage(ByVal formshowf As Boolean)
        If TileMapView.visible = True And formshowf = False Then
            TileMapView.visible = False
            EditMapping(False)
        Else
            Dim form = New frmTileMapServiceSelect
            TileMapView.visible = True
            If form.ShowDialog(_MapEditor, TileMapView.ViewData, TileMapView.visible, TileMap) = DialogResult.OK Then
                form.getResult(TileMapView.ViewData, TileMapView.visible)
                EditMapping(False)
            Else
                TileMapView.visible = False
            End If
            form.Dispose()
        End If
    End Sub
    ''' <summary>
    ''' 地図ファイルの挿入（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertMapFile(ByVal FileNames() As String)
        Dim InsertMapData As clsMapData
        Dim n = FileNames.Length
        Dim Omap As clsMapData.strMap_data = MapData.Map
        If n = 1 Then
            Dim FileName As String = FileNames(0)
            Cursor.Current = Cursors.WaitCursor
            Try
                InsertMapData = New clsMapData(FileName)
            Catch ex As Exception
                MsgBox(ex.Message)
                Return
            End Try
            InsertMapData.Map.FileName = System.IO.Path.GetFileName(FileName)
            InsertMapData.Map.FullPath = FileName
            Cursor.Current = Cursors.Default
            Dim Header As String = System.IO.Path.GetFileNameWithoutExtension(InsertMapData.Map.FileName) + "."
            Header = InputBox("挿入するオブジェクト名・オブジェクトグループ名・線種名にヘッダを付ける場合は設定して下さい。" + vbCrLf +
                                               "付けない場合は「キャンセル」をクリックして下さい。", , Header)

            Dim Emes As String = ""
            If spatial.Check_Zahyo_Projection_Convert_Enabled(MapData.Map.Zahyo, InsertMapData.Map.Zahyo, Emes) = False Then
                MsgBox(Emes, MsgBoxStyle.Exclamation)
                Return
            End If


            MapEditorUndo.SetUndo_AllMapData("地図ファイルの挿入")
            MapData.InsertMapData(InsertMapData, Header)
            Insert_Mapdata_Reset(Omap)
        Else
            Dim ques As MsgBoxResult = MsgBox("オブジェクト名のヘッダに地図ファイル名をつけますか？", MsgBoxStyle.YesNoCancel)
            If ques = MsgBoxResult.Cancel Then
                Return
            End If
            MapEditorUndo.SetUndo_AllMapData("地図ファイルの挿入")
            For i As Integer = 0 To n - 1
                Dim ef As Boolean = False
                Cursor.Current = Cursors.WaitCursor
                Dim FileName As String = FileNames(i)
                Try
                    InsertMapData = New clsMapData(FileName)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    ef = True
                End Try
                If ef = False Then
                    InsertMapData.Map.FileName = System.IO.Path.GetFileName(FileName)
                    InsertMapData.Map.FullPath = FileName
                    Dim Header As String = ""
                    If ques = MsgBoxResult.Yes Then
                        Header = InsertMapData.Map.FileName
                    End If

                    Dim Emes As String = ""
                    If spatial.Check_Zahyo_Projection_Convert_Enabled(MapData.Map.Zahyo, InsertMapData.Map.Zahyo, Emes) = False Then
                        MsgBox(Emes, MsgBoxStyle.Exclamation)
                    End If
                    MapData.InsertMapData(InsertMapData, Header)
                End If

            Next
            Insert_Mapdata_Reset(Omap)
            Cursor.Current = Cursors.Default
        End If
    End Sub
    ''' <summary>
    ''' 基盤地図情報ファイル読み込み（メニューから）
    ''' </summary>
    ''' <param name="Folder"></param>
    ''' <param name="Kibanfiles"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetKibanFile() As clsMapData
        Dim form As New frmMED_Kiban
        If form.ShowDialog(_MapEditor, MapData) = DialogResult.OK Then
            If MapData.NoDataFlag = False Then
                MapEditorUndo.SetUndo_AllMapData("基盤地図情報ファイル読み込み")
            End If
            Dim KibanMapData As clsMapData
            KibanMapData = form.GetResult()
            Return KibanMapData
        Else
            Return Nothing
        End If
        form.Dispose()
    End Function

    ''' <summary>
    ''' E00ファイル読み込み（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetE00file(ByRef E00files() As clsE00.E00file_info) As Boolean
        Dim form As New frmMED_E00File
        If form.ShowDialog(_MapEditor, MapData) = DialogResult.OK Then
            If MapData.NoDataFlag = False Then
                MapEditorUndo.SetUndo_AllMapData("E00ファイル読み込み")
            End If
            E00files = form.GetResults
            Return True
        Else
            Return False
        End If
        form.Dispose()
    End Function

    ''' <summary>
    ''' シェープファイル読み込み（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetShapefile(ByRef shapefiles() As clsShapefile.shapefile_info, ByRef topology_f As Boolean, ByRef integrate_F As Boolean) As Boolean
        Dim form As New frmShapeFile
        Dim f As Boolean
        If form.ShowDialog(_MapEditor, MapData, "ひとつのオブジェクトグループにまとめる") = DialogResult.OK Then
            If MapData.NoDataFlag = False Then
                MapEditorUndo.SetUndo_AllMapData("シェープファイル読み込み")
            End If
            shapefiles = form.getResult(topology_f, integrate_F)
            f = True
        Else
            f = False
        End If
        form.Dispose()
        Return f
    End Function
    ''' <summary>
    ''' 国勢調査小地域データ取得（メニューから）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCencusGISData() As clsMapData
        Dim form As New frmMED_CensusGISData
        If form.Show(False) = DialogResult.OK Then
            If MapData.NoDataFlag = False Then
                MapEditorUndo.SetUndo_AllMapData("国勢調査小地域データ取得")
            End If
            Return form.GetResults
        Else
            Return Nothing
        End If
        form.Dispose()
    End Function
    ''' <summary>
    ''' 標高データから等高線取得（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetMeshContour() As clsMapData
        Dim form As New frmMED_MeshContour
        If form.ShowDialog(TileMap) = DialogResult.OK Then
            If MapData.NoDataFlag = False Then
                MapEditorUndo.SetUndo_AllMapData("標高データから等高線取得")
            End If
            Return form.getResult
        Else
            Return Nothing
        End If
        form.Dispose()
    End Function
    ''' <summary>
    ''' オープンストリートマップデータ取得（メニューから）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOSM() As clsMapData

        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = clsSettings.Data.Directory.OSM
        ofd.Filter = "オープンストリートマップデータファイル(*.osm)|*.osm"
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim OSM As New clsOSM
            Dim OSMMapData As clsMapData
            Dim f As Boolean = OSM.Get_OSMFile(ofd.FileName, OSMMapData)
            If f = True Then
                If MapData.NoDataFlag = False Then
                    MapEditorUndo.SetUndo_AllMapData("オープンストリートマップデータファイル読み込み")
                End If
                clsSettings.Data.Directory.OSM = System.IO.Path.GetDirectoryName(ofd.FileName)
                OSMMapData.Map.FullPath = ""
                Return OSMMapData
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' KMLファイル取得（メニューから）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetKML() As clsMapData
        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = clsSettings.Data.Directory.KML
        ofd.Filter = "kml/kmzファイル(*.kml,*.kmz)|*.kml;*.kmz"
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim KML As New clsKML
            Dim kmlMapData As clsMapData
            Dim f As Boolean = KML.Get_KMLFile(ofd.FileName, kmlMapData)
            If f = True Then
                If MapData.NoDataFlag = False Then
                    MapEditorUndo.SetUndo_AllMapData("KMLファイル読み込み")
                End If
                clsSettings.Data.Directory.KML = System.IO.Path.GetDirectoryName(ofd.FileName)
                kmlMapData.Map.FullPath = ""
                Return kmlMapData
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' 地図データを追加した場合のパネルや編集対象の処理
    ''' </summary>
    ''' <param name="OMap">古い地図データのMAPへの参照</param>
    ''' <remarks></remarks>
    Public Sub Insert_Mapdata_Reset(ByRef OMap As clsMapData.strMap_data)
        ReDim Preserve _MapEditor.EditList.ObjectKind(MapData.Map.OBKNum - 1)
        ReDim Preserve _MapEditor.EditList.LineKind(MapData.Map.LpNum - 1)
        For i As Integer = OMap.OBKNum To MapData.Map.OBKNum - 1
            _MapEditor.EditList.ObjectKind(i) = True
        Next
        For i As Integer = OMap.LpNum To MapData.Map.LpNum - 1
            _MapEditor.EditList.LineKind(i) = True
        Next
        _MapEditor.EditList.AggregationF = MapData.Check_AggregateObjectType_Exists
        _MapEditor.setEditPanel()
        ScrData.init(picMap, New ScreenMargin(3, 3, 3, 3, False), MapData.Map.Circumscribed_Rectangle, enmBasePosition.Screen, True)
        EditMapping(True)
    End Sub
    ''' <summary>
    ''' 初期属性表示（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DefAttVisibleSetting()
        Dim form As New frmMED_DefAttShow
        If form.ShowDialog(_MapEditor, DefAttVisibleData, MapData) = DialogResult.OK Then
            DefAttVisibleData = form.getResult
            EditMapping(False)
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 時間情報の一括設定（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub TimeObjectSet()
        Dim form As New frmMED_TimeObjectSet
        If form.ShowDialog(MapData) = Windows.Forms.DialogResult.OK Then
            Dim UndoObj(MapData.Map.Kend - 1) As clsMapData.strObj_Data
            For i As Integer = 0 To MapData.Map.Kend - 1
                UndoObj(i) = MapData.MPObj(i).Clone
            Next
            MapEditorUndo.SetUndo_CombineSameObjectName("時間情報の一括設定", UndoObj)
            form.GetResults()
            EditMapping(True)
            MsgBox("時間情報の一括設定を行いました。")
        End If
        form.Dispose()

    End Sub
End Class
