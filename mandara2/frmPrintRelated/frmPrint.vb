Public Class frmPrint
    Private Enum enmPrintMouseMode
        Normal = 0
        PlusMinus = 1
        Fig = 2
        SymbolPoint = 3
        LabelPoint = 4
        RangePrint = 5
        Accessory_Drag = 7
        Distance = 9
        od = 10
        DistanceObject = 11
        MultiObjectSelect = 12
    End Enum
    Private Enum Check_Acc_Result
        NoAccessory = 0
        Title = 1
        Compass = 2
        Scale = 3
        Legend = 4
        GroupBox = 5
        Note = 6
    End Enum
    Public Enum enmFigureMode
        Pointing = 99
        Word = 2
        Line = 3
        Rectangle = 4
        Circle = 5
        Object_Circle = 6
        Point = 7
        Image = 8
    End Enum
    ''' <summary>
    ''' 複数オブジェクト選択モード時の、選択モード
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enmMultiObjectSelecModesSub
        Pointing
        Rectangle
        Circle
        Polygon
    End Enum
    Private Structure strFigWordMode
        Public DragMode As Boolean
        Public DragPosition As Integer
        Public pushPoint As PointF
    End Structure
    Private Structure strFigureMode
        Public Mode As enmFigureMode
        Public WordMode As strFigWordMode
    End Structure
    Private Structure strTempLocationMenuString
        Public ObjectNameValue As String
        Public ContourStacPos As Integer
        Public ClickMapPos As PointF
        Public DataIndex As Integer
    End Structure
    Private Structure menu_Ename_Info
        Public MFIle As Boolean
        Public mEdit As Boolean
        Public mAnalysis As Boolean
        Public mView As Boolean
        Public mOption As Boolean
        Public mFig As Boolean
        Public mPrint As Boolean
    End Structure

    ''' <summary>
    ''' 一時データ
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure temp_info
        ''' <summary>
        ''' カーソル位置のオブジェクト情報パネルの固定
        ''' </summary>
        ''' <remarks></remarks>
        Public Location_Fixed_F As Boolean
        Public OnObject As List(Of strLocationSearchObject)
        Public PrintMouseMode As enmPrintMouseMode
        Public MultiObjectSelectSub As enmMultiObjectSelecModesSub
        Public MultiObjectSelectShowFlag As Boolean
        Public MultiObjects As List(Of Integer)
        Public FigMode As strFigureMode
        Public mouseAccesoryDragType As Check_Acc_Result
        Public OD_Drag As clsAttrData.ODBezier_Data
        Public MouseDownF As Boolean
        Public LocationMenuString As strTempLocationMenuString
        Public RightButtonClickF As Boolean
        Public SymbolPointFirstMessage As Boolean
        Public LabelPointFirstMessage As Boolean
        Public Menu_Enable As menu_Ename_Info
        Public PointDistanceArea As List(Of PointF)
    End Structure


    Dim temp_data As temp_info
    Dim attrData As clsAttrData
    Dim picMapImageOperation As clsPictureBoxDragOrWheelImageChange
    Dim mousePointingSituation As mousePointingSituations
    Dim mouseDownPosition As Point

    Dim PrintingTime As Double
    Dim oldWindowState As System.Windows.Forms.FormWindowState
    Dim PrinterDoc As New System.Drawing.Printing.PrintDocument
    Dim ownerForm As Form
    Dim Frm_Set3d As New frmPrint_3DSettings
    Dim mouseUpPos As PointF
    Public Sub SetData(ByVal Owner As IWin32Window, ByRef _attrData As clsAttrData)
        Try

            attrData = _attrData
            attrData.TempData.ContourMode_Temp.ContourDataResetF = True
            attrData.TempData.DotMap_Temp.DotMapTempResetF = True
            attrData.TotalData.ViewStyle.ScrData.OutputDevide = enmOutputDevice.Screen
            temp_data.Location_Fixed_F = False
            temp_data.PrintMouseMode = enmPrintMouseMode.Normal
            Set_Menu_Enable(True, True, True, True, True, True, True)
            pnlDistanceArea.Visible = False

            If temp_data.OnObject Is Nothing = False Then
                temp_data.OnObject.Clear()
            End If

            If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.SeriesMode Then
                attrData.TempData.Series_temp.Koma = 0
            End If
            printMapScreen(True)

            If Me.Visible = False Then
                mnuSet3d.Checked = False
                ownerForm = Owner
                Me.Show()
            End If
            mnuSet3d.Checked = attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F
            If mnuSet3d.Checked = True Then
                If Frm_Set3d.IsDisposed = True Then
                    Frm_Set3d = New frmPrint_3DSettings
                End If
                If Frm_Set3d.Visible = False Then
                    Dim prop As Boolean = mnuPropertyWindow.Checked
                    If prop = True Then
                        mnuPropertyWindow.Checked = False
                        frm_Property.Visible = False
                    End If
                    Frm_Set3d.Show(Me)
                    Frm_Set3d.Set_Data(attrData, prop)
                End If
            Else
                Frm_Set3d.Close()
            End If
            mnuLocalChabge.Tag = "OFF"
            mnuLocalChabge.Checked = attrData.TotalData.ViewStyle.MapLegend.Base.ModeValueInScreenFlag
            mnuLocalChabge.Tag = ""
            If attrData.SetMapFile("").Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                mnuBackImage.Enabled = True
                BackImageButton.Enabled = True
                BackImageLegendButton.Enabled = attrData.TotalData.ViewStyle.TileMapView.Visible
            Else
                mnuBackImage.Enabled = False
                BackImageButton.Enabled = False
                BackImageLegendButton.Enabled = False
            End If
            If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.SeriesMode Then
                SeriesModeButton(0).Enabled = True
                SeriesModeButton(1).Enabled = True
            Else
                SeriesModeButton(0).Enabled = False
                SeriesModeButton(1).Enabled = False
            End If
        Catch ex As Exception
            clsGeneric.Message(Me, "エラー", ex.StackTrace, False, True)
        End Try

    End Sub

    ''' <summary>
    ''' 図形モートを設定（図形モードパネルから呼び出し）
    ''' </summary>
    ''' <param name="FigMode"></param>
    ''' <remarks></remarks>
    Public Sub SetFigureMouseMode(ByVal FigMode As enmFigureMode)
        temp_data.FigMode.Mode = FigMode
    End Sub
    Public Sub printMapScreen(ByVal PrintingTimeResetFlag As Boolean)
        If PrintingTimeResetFlag = True Then
            PrintingTime = 0
        End If
        If PrintingTime > clsSettings.Data.Printing_Time_Limit Then
            Return
        End If


        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        End If
        Dim sw As New System.Diagnostics.Stopwatch()
        sw.Start()

        '描画先とするImageオブジェクトを作成する
        Dim canvas As New Bitmap(picMap.Width, picMap.Height)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)
        Me.ProgressBar.Visible = True

        Dim prog As ToolStripProgressBar = Me.ProgressBar
        g.FillRectangle(Brushes.White, 0, 0, picMap.Width, picMap.Height) 'これがないと文字が縁取りみたいになってきれいに表示されない
        If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.SeriesMode Then
            Series_Mapping(g, prog, False)
        Else
            printMap(g, prog)
        End If
        'リソースを解放する
        g.Dispose()
        picMap.Image = canvas
        picMap.Refresh()
        PrintingTime = sw.Elapsed.TotalSeconds
        sw.Stop()
        Me.ProgressBar.Visible = False
    End Sub
    ''' <summary>
    ''' 連続表示モードの表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <remarks></remarks>
    Public Sub Series_Mapping(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef FileOutF As Boolean)

        attrData.TempData.ContourMode_Temp.ContourDataResetF = True
        attrData.TempData.DotMap_Temp.DotMapTempResetF = True
        Dim n As Integer = attrData.TotalData.TotalMode.Series.SelectedIndex
        Dim koma As Integer = attrData.TempData.Series_temp.Koma
        If attrData.TotalData.TotalMode.Series.DataSet(n).DataItem.Count = 0 Then
            Return
        End If
        With attrData.TotalData.TotalMode.Series.DataSet(n).DataItem(koma)
            attrData.TotalData.LV1.Print_Mode_Total = .Print_Mode_Total
            Dim ttl As String
            Select Case .Print_Mode_Total
                Case enmTotalMode_Number.DataViewMode
                    Dim o_p_m_l As enmLayerMode_Number = attrData.LayerData(.Layer).Print_Mode_Layer
                    Dim O_L As Integer = attrData.TotalData.LV1.SelectedLayer
                    attrData.LayerData(.Layer).Print_Mode_Layer = .Print_Mode_Layer
                    attrData.TotalData.LV1.SelectedLayer = .Layer
                    Select Case .Print_Mode_Layer
                        Case enmLayerMode_Number.SoloMode
                            Dim O_L_Datn As Integer = attrData.LayerData(.Layer).atrData.SelectedIndex
                            attrData.LayerData(.Layer).atrData.SelectedIndex = .Data
                            Dim md As enmSoloMode_Number = attrData.SoloMode(.Layer, .Data)
                            attrData.LayerData(.Layer).atrData.Data(.Data).ModeData = .SoloMode
                            If FileOutF = False Then
                                printMap(g, prog)
                            Else
                                clsPrintMap.ShowMap(g, prog, attrData)
                            End If
                            ttl = attrData.Get_DataTitle(.Layer, .Data, False)
                            attrData.LayerData(.Layer).atrData.SelectedIndex = O_L_Datn
                            attrData.SoloMode(.Layer, .Data) = md
                        Case enmLayerMode_Number.GraphMode
                            Dim o_m_d As Integer = attrData.LayerData(.Layer).LayerModeViewSettings.GraphMode.SelectedIndex
                            attrData.LayerData(.Layer).LayerModeViewSettings.GraphMode.SelectedIndex = .Data
                            If FileOutF = False Then
                                printMap(g, prog)
                            Else
                                clsPrintMap.ShowMap(g, prog, attrData)
                            End If
                            ttl = attrData.LayerData(.Layer).LayerModeViewSettings.GraphMode.DataSet(.Data).title
                            attrData.LayerData(.Layer).LayerModeViewSettings.GraphMode.SelectedIndex = o_m_d
                        Case enmLayerMode_Number.LabelMode
                            Dim o_m_d As Integer = attrData.LayerData(.Layer).LayerModeViewSettings.LabelMode.SelectedIndex
                            attrData.LayerData(.Layer).LayerModeViewSettings.LabelMode.SelectedIndex = .Data
                            If FileOutF = False Then
                                printMap(g, prog)
                            Else
                                clsPrintMap.ShowMap(g, prog, attrData)
                            End If
                            ttl = attrData.LayerData(.Layer).LayerModeViewSettings.LabelMode.DataSet(.Data).title
                            attrData.LayerData(.Layer).LayerModeViewSettings.LabelMode.SelectedIndex = o_m_d
                        Case enmLayerMode_Number.TripMode
                            Dim o_m_d As Integer = attrData.LayerData(.Layer).LayerModeViewSettings.TripMode.SelectedIndex
                            attrData.LayerData(.Layer).LayerModeViewSettings.TripMode.SelectedIndex = .Data
                            If FileOutF = False Then
                                printMap(g, prog)
                            Else
                                clsPrintMap.ShowMap(g, prog, attrData)
                            End If
                            ttl = attrData.LayerData(.Layer).LayerModeViewSettings.TripMode.DataSet(.Data).title
                            attrData.LayerData(.Layer).LayerModeViewSettings.TripMode.SelectedIndex = o_m_d
                    End Select
                    attrData.TotalData.LV1.SelectedLayer = O_L
                    attrData.LayerData(.Layer).Print_Mode_Layer = o_p_m_l
                Case enmTotalMode_Number.OverLayMode
                    Dim O_O As Integer = attrData.TotalData.TotalMode.OverLay.SelectedIndex
                    attrData.TotalData.TotalMode.OverLay.SelectedIndex = .Data
                    If FileOutF = False Then
                        printMap(g, prog)
                    Else
                        clsPrintMap.ShowMap(g, prog, attrData)
                    End If
                    ttl = attrData.TotalData.TotalMode.OverLay.DataSet(.Data).title
                    attrData.TotalData.TotalMode.OverLay.SelectedIndex = O_O
            End Select
            attrData.TempData.Series_temp.title = ttl
            attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.SeriesMode
        End With

    End Sub
    Private Sub printMap(ByRef g As Graphics, ByRef prog As ToolStripProgressBar)

        If attrData.TotalData.ViewStyle.ScrData.OutputDevide <> enmOutputDevice.Printer Then
            mousePointingSituation = mousePointingSituations.up
            picMapImageOperation = New clsPictureBoxDragOrWheelImageChange(picMap)
        End If
        If attrData.TotalData.FigureStac.Count > 0 Then
            ReDim attrData.TempData.FigurePrinted(attrData.TotalData.FigureStac.Count - 1)
        End If
        attrData.TotalData.ViewStyle.ScrData.Set_PictureBox_and_CulculateMul(picMap)
        If attrData.TotalData.ViewStyle.ScrData.OutputDevide = enmOutputDevice.Printer Then
            g.SetClip(attrData.TotalData.ViewStyle.ScrData.MapScreen_Scale)
        End If
        Dim Ca As String = ""
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        Select Case attrData.TotalData.LV1.Print_Mode_Total
            Case enmTotalMode_Number.DataViewMode
                Select Case attrData.LayerData(Layernum).Print_Mode_Layer
                    Case enmLayerMode_Number.SoloMode
                        Ca = attrData.Get_SelectedDataTitle
                    Case enmLayerMode_Number.GraphMode
                        With attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode
                            Ca = .DataSet(.SelectedIndex).title
                        End With
                    Case enmLayerMode_Number.LabelMode
                        With attrData.LayerData(Layernum).LayerModeViewSettings.LabelMode
                            Ca = .DataSet(.SelectedIndex).title
                        End With
                    Case enmLayerMode_Number.TripMode
                        With attrData.LayerData(Layernum).LayerModeViewSettings.TripMode
                            Ca = .DataSet(.SelectedIndex).title
                        End With
                End Select
                If attrData.TotalData.LV1.Lay_Maxn <> 1 Then
                    Ca += "-" + attrData.LayerData(Layernum).Name
                End If
            Case enmTotalMode_Number.OverLayMode
                With attrData.TotalData.TotalMode.OverLay
                    Ca = .DataSet(.SelectedIndex).title
                End With
        End Select
        Me.Text = Ca

        clsPrintMap.ShowMap(g, prog, attrData)

        Me.Focus()

    End Sub

    Private Sub picMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Select Case temp_data.PrintMouseMode
                Case enmPrintMouseMode.RangePrint
            End Select
        Else
            temp_data.MouseDownF = True
            mousePointingSituation = mousePointingSituations.down
            mouseDownPosition = e.Location
            Select Case temp_data.PrintMouseMode
                Case enmPrintMouseMode.Fig
                    If temp_data.FigMode.Mode = enmFigureMode.Line Then
                        '図形モードの線で、線分間にポイント挿入
                        With frm_Figure.EditingFig
                            Dim EditingPoint As Integer
                            Dim EditingLine As Integer
                            Dim NpXY As PointF
                            Dim DragZoneF As Boolean
                            check_FigLineMode_NearLinePointOrLineSegment(e.Location, EditingPoint, EditingLine, NpXY, DragZoneF)
                            If EditingLine <> -1 Then
                                clsGeneric.Insert_Point_Array(EditingLine + 1, NpXY, .Line.Points)
                                .Line.NumOfPoint += 1
                                .LineModeInfo.EditingPoint = EditingLine + 1
                                .LineModeInfo.EditingLine = -1
                                frm_Figure.Print_Fig()
                            End If

                        End With
                    End If
            End Select
        End If
    End Sub



    Private Sub picMap_MouseLeave(sender As Object, e As EventArgs) Handles picMap.MouseLeave
        If temp_data.RightButtonClickF = True Then
            temp_data.RightButtonClickF = False
            Return
        End If
        If temp_data.Location_Fixed_F = False And temp_data.PrintMouseMode = enmPrintMouseMode.Normal Then
            picMap.Refresh()
        End If
        StatusLabel.Text = ""
        StatusLabel2.Text = ""
    End Sub

    Private Sub picMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseMove


        Static mousePreviousPosition As Point
        Dim MapPos = attrData.TotalData.ViewStyle.ScrData.getSRXY(e.Location)

        Dim g As Graphics = picMap.CreateGraphics

        Select Case mousePointingSituation
            Case mousePointingSituations.up
                'ボタンを押さずに移動中
                Select Case temp_data.PrintMouseMode
                    Case enmPrintMouseMode.Distance
                        picMapMouseMovePointInformation(e.Location)
                    Case enmPrintMouseMode.MultiObjectSelect
                        If temp_data.MultiObjectSelectSub = enmMultiObjectSelecModesSub.Pointing Then
                            LocationSearch(e.Location)
                        Else
                            picMapMouseMoveMultiObjectSelect_Shape(e.Location, False, False)
                        End If
                    Case enmPrintMouseMode.Normal, enmPrintMouseMode.od
                        Dim mCursorF As Boolean = False
                        If attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F = False Then
                            If temp_data.Location_Fixed_F = False Then
                                LocationSearch(e.Location)
                            Else
                                picMapMouseMovePointInformation(e.Location)
                            End If
                            LocationContourSearch(e.Location)
                            mCursorF = LocationODSearch(e.Location)
                        End If
                        If mCursorF = False Then
                            If Check_Acc(e.Location) <> Check_Acc_Result.NoAccessory Then
                                mCursorF = True
                            End If
                        End If
                        If mCursorF = True Then
                            picMap.Cursor = Cursors.Hand
                        Else
                            picMap.Cursor = Cursors.Default
                        End If
                    Case enmPrintMouseMode.Fig
                        picMapMouseMovePointInformation(e.Location)
                        Select Case temp_data.FigMode.Mode
                            Case enmFigureMode.Pointing
                                '図形モードの図形指定
                                If Check_Figure_Location(g, e.Location) = -1 Then
                                    picMap.Cursor = Cursors.Default
                                Else
                                    picMap.Cursor = Cursors.Cross
                                End If
                            Case enmFigureMode.Word
                                '図形モードの文字
                                If check_FigWord_Location(g, e.Location, frm_Figure.EditingFig.Word) = -1 Then
                                    '文字の上を通過した場合はマウスカートルをハンドに
                                    picMap.Cursor = Cursors.Default
                                Else
                                    picMap.Cursor = Cursors.Hand
                                End If
                                temp_data.FigMode.WordMode.DragMode = False
                            Case enmFigureMode.Line
                                '図形モードの線
                                Dim EditingPoint As Integer
                                Dim EditingLine As Integer
                                Dim NpXY As PointF
                                Dim DragZoneF As Boolean
                                check_FigLineMode_NearLinePointOrLineSegment(e.Location, EditingPoint, EditingLine, NpXY, DragZoneF)
                                If EditingPoint <> -1 Or EditingLine <> -1 Then
                                    picMap.Cursor = Cursors.Hand
                                ElseIf DragZoneF = True Then
                                    picMap.Cursor = Cursors.SizeAll
                                Else
                                    picMap.Cursor = Cursors.Default
                                End If
                                With frm_Figure.EditingFig.LineModeInfo
                                    If EditingPoint <> .EditingPoint Or EditingLine <> .EditingLine Then
                                        .EditingPoint = EditingPoint
                                        .EditingLine = EditingLine
                                        frm_Figure.Print_Fig()
                                    End If
                                End With
                            Case enmFigureMode.Rectangle
                                '図形モードの四角
                                Dim state As enmCeck_FigureRectangle = check_FigureRectangle_MousePosition(e.Location)
                                With frm_Figure.EditingFig.RectangleModeInfo
                                    Select Case state
                                        Case enmCeck_FigureRectangle.Point0
                                            .SelPointIndex = 0
                                            frm_Figure.Print_Fig()
                                            picMap.Cursor = Cursors.Hand
                                        Case enmCeck_FigureRectangle.Point1
                                            .SelPointIndex = 1
                                            frm_Figure.Print_Fig()
                                            picMap.Cursor = Cursors.Hand
                                        Case enmCeck_FigureRectangle.DragRect
                                            picMap.Cursor = Cursors.SizeAll
                                            If .SelPointIndex <> -1 Then
                                                .SelPointIndex = -1
                                                frm_Figure.Print_Fig()
                                            End If
                                        Case Else
                                            picMap.Cursor = Cursors.Default
                                            If .SelPointIndex <> -1 Then
                                                .SelPointIndex = -1
                                                frm_Figure.Print_Fig()
                                            End If
                                    End Select
                                End With
                            Case enmFigureMode.Circle
                                '図形モードの円
                                With frm_Figure.EditingFig
                                    Dim Map As clsMapData.strMap_data = attrData.SetMapFile("").Map
                                    Dim Pt() As Point = frm_Figure.Get_CircleR_FourPoints(.Circle, Map)
                                    Dim mind As Integer = 5
                                    Dim minP As Integer = spatial.get_PointDistance(e.Location, Pt, 4, mind)
                                    If minP <> -1 Then
                                        picMap.Cursor = Cursors.Hand
                                        .CircleModeInfo.SelPointIndex = minP
                                        frm_Figure.Print_Fig()
                                    Else
                                        If .CircleModeInfo.SelPointIndex <> -1 Then
                                            .CircleModeInfo.SelPointIndex = -1
                                            frm_Figure.Print_Fig()
                                        End If
                                        Dim MapScaleBairitu As Single = spatial.Get_Scale_Baititu_IdoKedo(.Circle.Position, Map.Zahyo)
                                        If Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
                                            MapScaleBairitu *= Map.SCL
                                        End If
                                        Dim xr As Single = .Circle.XR * MapScaleBairitu
                                        Dim yr As Single = .Circle.YR * MapScaleBairitu
                                        Dim rectf As RectangleF = New RectangleF(-xr + .Circle.Position.X, -yr + .Circle.Position.Y, xr * 2, yr * 2)
                                        Dim rect As Rectangle = attrData.TotalData.ViewStyle.ScrData.getSxSy(rectf)
                                        If spatial.Check_PointInBox(e.Location, CInt(.Circle.Angle), rect) = True Then
                                            picMap.Cursor = Cursors.SizeAll
                                        Else
                                            picMap.Cursor = Cursors.Default
                                        End If
                                    End If

                                End With
                            Case enmFigureMode.Point
                                '図形モードの点
                                Dim onLegendF As Boolean
                                Dim Epoint As Integer
                                With frm_Figure.EditingFig
                                    check_FigPointMode_NearPointOrLegend(g, e.Location, .Point, Epoint, onLegendF)
                                    If Epoint <> -1 Then
                                        .PointModeInfo.SelPointIndex = Epoint
                                        frm_Figure.Print_Fig()
                                        picMap.Cursor = Cursors.Hand
                                    ElseIf onLegendF = True Then
                                        If .PointModeInfo.SelPointIndex <> -1 Then
                                            .PointModeInfo.SelPointIndex = -1
                                            frm_Figure.Print_Fig()
                                        End If
                                        picMap.Cursor = Cursors.SizeAll
                                    Else
                                        If .PointModeInfo.SelPointIndex <> -1 Then
                                            .PointModeInfo.SelPointIndex = -1
                                            frm_Figure.Print_Fig()
                                        End If
                                        picMap.Cursor = Cursors.Default
                                    End If
                                End With
                            Case enmFigureMode.Image
                                '図形モードの画像
                                Dim cp As Point
                                Dim rad As Integer
                                Dim rect As Rectangle
                                With frm_Figure.EditingFig
                                    If .Gazo.PictureNumber <> -1 Then
                                        clsAccessory.Get_Fig_ImageRect(attrData, .Gazo, cp, rect, rad)
                                        Dim p() As Point = spatial.Get_TurnedRectangle(rect, .Gazo.Angle)
                                        Dim mind As Integer = 5
                                        Dim minP As Integer = spatial.get_PointDistance(e.Location, p, 4, mind)
                                        If minP = -1 Then
                                            If spatial.Check_PointInBox(e.Location, .Gazo.Angle, rect) = True Then
                                                picMap.Cursor = Cursors.SizeAll
                                            Else
                                                picMap.Cursor = Cursors.Default
                                            End If
                                            If .GazoModeInfo.SelectPoint <> -1 Then
                                                .GazoModeInfo.SelectPoint = -1
                                                frm_Figure.Print_Fig()
                                            End If
                                        Else
                                            .GazoModeInfo.SelectPoint = minP
                                            picMap.Cursor = Cursors.Hand
                                            frm_Figure.Print_Fig()
                                        End If
                                    End If
                                End With
                        End Select
                End Select
            Case mousePointingSituations.down
                'マウスダウンの直後
                If e.Location.Equals(mouseDownPosition) = False Then
                    '前の座標から移動した場合
                    'enmPrintMouseMode.Normalの場合はドラッグ用に、現在の地図画面をbackCanvasに待避
                    picMapImageOperation.getPictureImage()
                    mousePreviousPosition = e.Location
                    mousePointingSituation = mousePointingSituations.downAndMove
                    Select Case temp_data.PrintMouseMode
                        Case enmPrintMouseMode.Normal
                            temp_data.mouseAccesoryDragType = Check_Acc(e.Location)
                            If temp_data.mouseAccesoryDragType <> Check_Acc_Result.NoAccessory Then
                                temp_data.PrintMouseMode = enmPrintMouseMode.Accessory_Drag
                                picMap.Cursor = Cursors.SizeAll
                            End If
                        Case enmPrintMouseMode.RangePrint


                        Case enmPrintMouseMode.Fig
                            Select Case temp_data.FigMode.Mode
                                Case enmFigureMode.Word
                                    '図形モードの文字
                                    Dim ix As Integer = check_FigWord_Location(g, e.Location, frm_Figure.EditingFig.Word)
                                    If ix <> -1 Then
                                        temp_data.FigMode.WordMode.DragPosition = ix
                                        temp_data.FigMode.WordMode.pushPoint = frm_Figure.EditingFig.Word.StringPos(ix)
                                        temp_data.FigMode.WordMode.DragMode = True
                                    End If
                                Case enmFigureMode.Line
                                    '図形モードの線
                                    Dim EditingPoint As Integer
                                    Dim EditingLine As Integer
                                    Dim NpXY As PointF
                                    Dim DragZoneF As Boolean
                                    check_FigLineMode_NearLinePointOrLineSegment(e.Location, EditingPoint, EditingLine, NpXY, DragZoneF)
                                    If EditingPoint <> -1 Then
                                        With frm_Figure.EditingFig
                                            .LineModeInfo.DragMode = frmPrint_Figure.enmLineDragMode.PointDrag
                                            .LineModeInfo.OriginPoint = .Line.Points(.LineModeInfo.EditingPoint)
                                            .LineModeInfo.LoopDragF = False
                                            '閉じたラインで起終点をドラッグ
                                            If .LineModeInfo.EditingPoint = 0 Or .LineModeInfo.EditingPoint = .Line.NumOfPoint - 1 Then
                                                If .Line.Points(0).Equals(.Line.Points(.Line.NumOfPoint - 1)) Then
                                                    .LineModeInfo.EditingPoint = 0
                                                    .LineModeInfo.LoopDragF = True
                                                End If
                                            End If
                                        End With
                                    ElseIf DragZoneF = True Then
                                        With frm_Figure.EditingFig
                                            .LineModeInfo.DragMode = frmPrint_Figure.enmLineDragMode.LineDrag
                                            .LineModeInfo.OriginLinePoints = .Line.Points.Clone
                                        End With
                                    Else
                                        frm_Figure.EditingFig.LineModeInfo.DragMode = frmPrint_Figure.enmLineDragMode.noDrag
                                    End If
                                Case enmFigureMode.Rectangle
                                    '図形モードの四角
                                    Dim state As enmCeck_FigureRectangle = check_FigureRectangle_MousePosition(e.Location)
                                    With frm_Figure.EditingFig.RectangleModeInfo
                                        .OriginPoint0 = frm_Figure.EditingFig.Rectangle.Point0
                                        .OriginPoint1 = frm_Figure.EditingFig.Rectangle.Point1
                                        Select Case state
                                            Case enmCeck_FigureRectangle.Point0
                                                .SelPointIndex = 0
                                                .DragMode = frmPrint_Figure.enmRectangleDragMode.PointDrag
                                            Case enmCeck_FigureRectangle.Point1
                                                .SelPointIndex = 1
                                                .DragMode = frmPrint_Figure.enmRectangleDragMode.PointDrag
                                            Case enmCeck_FigureRectangle.DragRect
                                                .SelPointIndex = -1
                                                .DragMode = frmPrint_Figure.enmRectangleDragMode.RectDrag
                                            Case Else
                                                .SelPointIndex = -1
                                                .DragMode = frmPrint_Figure.enmRectangleDragMode.noDrag
                                        End Select
                                    End With
                                Case enmFigureMode.Circle
                                    '図形モードの円
                                    With frm_Figure.EditingFig
                                        Dim Map As clsMapData.strMap_data = attrData.SetMapFile("").Map
                                        Dim Pt() As Point = frm_Figure.Get_CircleR_FourPoints(.Circle, Map)
                                        Dim mind As Integer = 5
                                        Dim minP As Integer = spatial.get_PointDistance(mouseDownPosition, Pt, 4, mind)
                                        .CircleModeInfo.OriginCenterP = .Circle.Position
                                        .CircleModeInfo.OriginXr = .Circle.XR
                                        .CircleModeInfo.OriginYr = .Circle.YR
                                        .CircleModeInfo.OriginAngle = .Circle.Angle
                                        If minP <> -1 Then
                                            picMap.Cursor = Cursors.Hand
                                            .CircleModeInfo.SelPointIndex = minP
                                            .CircleModeInfo.DragMode = frmPrint_Figure.enmCircleDragMode.PointDrag
                                        Else
                                            .CircleModeInfo.SelPointIndex = -1
                                            Dim MapScaleBairitu As Single = spatial.Get_Scale_Baititu_IdoKedo(.Circle.Position, Map.Zahyo)
                                            If Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
                                                MapScaleBairitu *= Map.SCL
                                            End If
                                            Dim xr As Single = .Circle.XR * MapScaleBairitu
                                            Dim yr As Single = .Circle.YR * MapScaleBairitu
                                            Dim rectf As RectangleF = New RectangleF(-xr + .Circle.Position.X, -yr + .Circle.Position.Y, xr * 2, yr * 2)
                                            Dim rect As Rectangle = attrData.TotalData.ViewStyle.ScrData.getSxSy(rectf)
                                            If spatial.Check_PointInBox(e.Location, CInt(.Circle.Angle), rect) = True Then
                                                .CircleModeInfo.DragMode = frmPrint_Figure.enmCircleDragMode.CircleDrag
                                            Else
                                                .CircleModeInfo.DragMode = frmPrint_Figure.enmCircleDragMode.noDrag
                                            End If
                                        End If
                                    End With
                                Case enmFigureMode.Point
                                    '図形モードの点
                                    Dim onLegendF As Boolean
                                    Dim Epoint As Integer
                                    With frm_Figure.EditingFig
                                        check_FigPointMode_NearPointOrLegend(g, mouseDownPosition, .Point, Epoint, onLegendF)
                                        If Epoint <> -1 Then
                                            .PointModeInfo.SelPointIndex = Epoint
                                            .PointModeInfo.OriginPoint = .Point.Points(Epoint)
                                            .PointModeInfo.DragMode = frmPrint_Figure.enmPointDragMode.PointDrag
                                            picMap.Cursor = Cursors.Hand
                                        ElseIf onLegendF = True Then
                                            .PointModeInfo.OriginPoint = .Point.CaptionPosition
                                            .PointModeInfo.DragMode = frmPrint_Figure.enmPointDragMode.PointLegendDrag
                                        Else
                                            .PointModeInfo.DragMode = frmPrint_Figure.enmPointDragMode.noDrag
                                        End If
                                    End With
                                Case enmFigureMode.Image
                                    '図形モードの画像
                                    Dim cp As Point
                                    Dim rad As Integer
                                    Dim rect As Rectangle
                                    With frm_Figure.EditingFig
                                        If .Gazo.PictureNumber <> -1 Then
                                            clsAccessory.Get_Fig_ImageRect(attrData, .Gazo, cp, rect, rad)
                                            Dim p() As Point = spatial.Get_TurnedRectangle(rect, .Gazo.Angle)
                                            Dim mind As Integer = 6
                                            Dim minP As Integer = spatial.get_PointDistance(mouseDownPosition, p, 4, mind)
                                            .GazoModeInfo.SelectPoint = minP
                                            If minP = -1 Then
                                                If spatial.Check_PointInBox(mouseDownPosition, .Gazo.Angle, rect) = True Then
                                                    .GazoModeInfo.DragMode = frmPrint_Figure.enmGazoDragMode.GazoDrag
                                                    .GazoModeInfo.OriginPoint = .Gazo.Position
                                                Else
                                                    .GazoModeInfo.DragMode = frmPrint_Figure.enmGazoDragMode.noDrag
                                                End If
                                            Else
                                                .GazoModeInfo.DragMode = frmPrint_Figure.enmGazoDragMode.VartexDrag
                                                .GazoModeInfo.OriginSize = .Gazo.Size
                                                .GazoModeInfo.OriginAngle = .Gazo.Angle
                                                frm_Figure.Print_Fig()
                                            End If
                                        End If
                                    End With
                            End Select
                    End Select
                End If
            Case mousePointingSituations.downAndMove
                'マウスダウンとドラッグ開始後
                If e.Location.Equals(mousePreviousPosition) = False Then
                    Dim MouseDownSRxy As PointF = attrData.TotalData.ViewStyle.ScrData.getSRXY(mouseDownPosition)
                    Dim movePx As Point = New Point(e.Location.X - mouseDownPosition.X, e.Location.Y - mouseDownPosition.Y)
                    If temp_data.PrintMouseMode = enmPrintMouseMode.RangePrint Then
                        '表示範囲指定
                        Dim rect As Rectangle = spatial.Get_Circumscribed_Rectangle(mouseDownPosition, e.Location)
                        picMap.Refresh()
                        g.DrawRectangle(New Pen(Color.Black), rect)
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Accessory_Drag Then
                        '飾りの移動
                        picMap.Refresh()
                        Dim stp As PointF
                        With attrData.TotalData.ViewStyle
                            Dim smode As Boolean = (.ScrData.Accessory_Base = enmBasePosition.Screen)
                            If smode Then
                                stp.X = movePx.X / .ScrData.MapScreen_Scale.Width
                                stp.Y = movePx.Y / .ScrData.MapScreen_Scale.Height
                            Else
                                stp.X = MapPos.X - MouseDownSRxy.X
                                stp.Y = MapPos.Y - MouseDownSRxy.Y
                            End If

                            Select Case temp_data.mouseAccesoryDragType
                                Case Check_Acc_Result.Compass
                                    Dim P As PointF = attrData.TempData.Accessory_Temp.Push_CompassXY
                                    spatial.PointF_offset(P, stp)
                                    If smode Then
                                        P = spatial.checkAndModifyPointInRect(P, New RectangleF(0, 0, 1, 1))
                                    End If
                                    With .AttMapCompass
                                        .Position = P
                                        clsAccessory.Compass_print(g, attrData)
                                    End With
                                Case Check_Acc_Result.Title
                                    Dim P As PointF = attrData.TempData.Accessory_Temp.Push_titleXY
                                    spatial.PointF_offset(P, stp)
                                    If smode Then
                                        P = spatial.checkAndModifyPointInRect(P, New RectangleF(0, 0, 1, 1))
                                    End If
                                    With .MapTitle
                                        .Position = P
                                        clsAccessory.Title_Print(g, attrData)
                                    End With
                                Case Check_Acc_Result.Scale
                                    Dim P As PointF = attrData.TempData.Accessory_Temp.Push_ScaleXY
                                    spatial.PointF_offset(P, stp)
                                    If smode Then
                                        P = spatial.checkAndModifyPointInRect(P, New RectangleF(0, 0, 0.95, 0.95))
                                    End If
                                    With .MapScale
                                        .Position = P
                                        clsAccessory.Scale_Print(g, attrData)
                                    End With
                                Case Check_Acc_Result.Note
                                    Dim P As PointF = attrData.TempData.Accessory_Temp.Push_DataNoteXY
                                    spatial.PointF_offset(P, stp)
                                    If smode Then
                                        P = spatial.checkAndModifyPointInRect(P, New RectangleF(0, 0, 1, 1))
                                    End If
                                    With .DataNote
                                        .Position = P
                                        clsAccessory.Note_Print(g, attrData)
                                    End With
                                Case Check_Acc_Result.Legend
                                    Dim P As PointF = attrData.TempData.Accessory_Temp.Push_LegendXY
                                    spatial.PointF_offset(P, stp)
                                    If smode Then
                                        P = spatial.checkAndModifyPointInRect(P, New RectangleF(0, 0, 0.95, 0.95))
                                    End If
                                    .MapLegend.Base.LegendXY(attrData.TempData.Accessory_Temp.Edit_Legend) = P
                                    clsAccessory.Legend_print(g, attrData, attrData.TempData.Accessory_Temp.Edit_Legend, False)
                                Case Check_Acc_Result.GroupBox
                                    attrData.TempData.Accessory_Temp.GroupBox_Rect = attrData.TempData.Accessory_Temp.OriginalGroupBoxRect
                                    attrData.TempData.Accessory_Temp.GroupBox_Rect.Offset(movePx)
                                    If smode Then
                                        With attrData.TempData.Accessory_Temp.GroupBox_Rect
                                            Dim rcp As Point = New Point(.Left + .Width / 2, .Top + .Height / 2)
                                            rcp = spatial.checkAndModifyPointInRect(rcp, New Rectangle(0, 0, attrData.TotalData.ViewStyle.ScrData.frmPrint_FormSize.Width, attrData.TotalData.ViewStyle.ScrData.frmPrint_FormSize.Height))
                                            attrData.TempData.Accessory_Temp.GroupBox_Rect = New Rectangle(rcp.X - .Width / 2, rcp.Y - .Height / 2, .Width, .Height)
                                        End With

                                    End If
                                    clsAccessory.AccGroupBoxDraw(g, attrData)
                            End Select
                        End With
                        picMap.Cursor = Cursors.SizeAll
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.od Then
                        OD_Line_Print(MapPos)
                        picMap.Cursor = Cursors.SizeAll
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Word And
                                temp_data.FigMode.WordMode.DragMode = True Then
                        '図形モードの文字の文字ドラッグ
                        Dim stp As PointF
                        If frm_Figure.EditingFig.Word.Screen_Setf = False Then
                            stp = New PointF(MapPos.X - MouseDownSRxy.X, MapPos.Y - MouseDownSRxy.Y)
                        Else
                            stp.X = movePx.X / attrData.TotalData.ViewStyle.ScrData.MapScreen_Scale.Width
                            stp.Y = movePx.Y / attrData.TotalData.ViewStyle.ScrData.MapScreen_Scale.Height
                        End If
                        Dim P As PointF = temp_data.FigMode.WordMode.pushPoint
                        spatial.PointF_offset(P, stp)
                        frm_Figure.EditingFig.Word.StringPos(temp_data.FigMode.WordMode.DragPosition) = P
                        frm_Figure.Print_Fig()
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Line And
                                frm_Figure.EditingFig.LineModeInfo.DragMode = frmPrint_Figure.enmLineDragMode.PointDrag Then
                        '図形モードのラインの点ドラッグ
                        With frm_Figure.EditingFig
                            .Line.Points(.LineModeInfo.EditingPoint) = MapPos
                            If .LineModeInfo.LoopDragF = True Then
                                .Line.Points(.Line.NumOfPoint - 1) = MapPos
                            End If
                        End With
                        frm_Figure.Print_Fig()
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Line And
                                frm_Figure.EditingFig.LineModeInfo.DragMode = frmPrint_Figure.enmLineDragMode.LineDrag Then
                        '図形モードのラインの全体ドラッグ
                        With frm_Figure.EditingFig
                            Dim stp As PointF = New PointF(MapPos.X - MouseDownSRxy.X, MapPos.Y - MouseDownSRxy.Y)
                            For i As Integer = 0 To .Line.NumOfPoint - 1
                                Dim P As PointF = .LineModeInfo.OriginLinePoints(i)
                                spatial.PointF_offset(P, stp)
                                .Line.Points(i) = P
                            Next
                        End With
                        frm_Figure.Print_Fig()
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Rectangle And
                            frm_Figure.EditingFig.RectangleModeInfo.DragMode = frmPrint_Figure.enmRectangleDragMode.PointDrag Then
                        '図形モードの四角の点ドラッグ
                        With frm_Figure.EditingFig
                            If .RectangleModeInfo.SelPointIndex = 0 Then
                                .Rectangle.Point0 = MapPos
                            Else
                                .Rectangle.Point1 = MapPos
                            End If
                        End With
                        frm_Figure.Print_Fig()
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Rectangle And
                            frm_Figure.EditingFig.RectangleModeInfo.DragMode = frmPrint_Figure.enmRectangleDragMode.RectDrag Then
                        '図形モードの四角の全体ドラッグ
                        With frm_Figure.EditingFig
                            Dim stp As PointF = New PointF(MapPos.X - MouseDownSRxy.X, MapPos.Y - MouseDownSRxy.Y)
                            Dim P0 As PointF = .RectangleModeInfo.OriginPoint0
                            spatial.PointF_offset(P0, stp)
                            Dim P1 As PointF = .RectangleModeInfo.OriginPoint1
                            spatial.PointF_offset(P1, stp)
                            .Rectangle.Point0 = P0
                            .Rectangle.Point1 = P1
                            frm_Figure.Print_Fig()
                        End With
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Circle And
                            frm_Figure.EditingFig.CircleModeInfo.DragMode = frmPrint_Figure.enmCircleDragMode.PointDrag Then
                        '図形モード円モードの点ドラッグ
                        set_FigCircleValue(MapPos, Control.ModifierKeys)
                        frm_Figure.set_FigCircleValue_to_Panel()
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Circle And
                            frm_Figure.EditingFig.CircleModeInfo.DragMode = frmPrint_Figure.enmCircleDragMode.CircleDrag Then
                        '図形モードの円の全体ドラッグ
                        With frm_Figure.EditingFig
                            Dim stp As PointF = New PointF(MapPos.X - MouseDownSRxy.X, MapPos.Y - MouseDownSRxy.Y)
                            Dim P0 As PointF = .CircleModeInfo.OriginCenterP
                            spatial.PointF_offset(P0, stp)
                            .Circle.Position = P0
                            frm_Figure.Print_Fig()
                        End With
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Point And
                            frm_Figure.EditingFig.PointModeInfo.DragMode = frmPrint_Figure.enmPointDragMode.PointDrag Then
                        '図形モード点の点ドラッグ
                        With frm_Figure.EditingFig
                            .Point.Points(.PointModeInfo.SelPointIndex) = MapPos
                        End With
                        frm_Figure.Print_Fig()
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Point And
                            frm_Figure.EditingFig.PointModeInfo.DragMode = frmPrint_Figure.enmPointDragMode.PointLegendDrag Then
                        '図形モード点の凡例ドラッグ
                        With frm_Figure.EditingFig
                            Dim stp As PointF = New PointF(MapPos.X - MouseDownSRxy.X, MapPos.Y - MouseDownSRxy.Y)
                            Dim P0 As PointF = .PointModeInfo.OriginPoint
                            spatial.PointF_offset(P0, stp)
                            .Point.CaptionPosition = P0
                            frm_Figure.Print_Fig()
                        End With
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Image And
                            frm_Figure.EditingFig.GazoModeInfo.DragMode = frmPrint_Figure.enmGazoDragMode.GazoDrag Then
                        '図形モード画像の全体ドラッグ
                        With frm_Figure.EditingFig
                            Dim stp As PointF = New PointF(MapPos.X - MouseDownSRxy.X, MapPos.Y - MouseDownSRxy.Y)
                            Dim P0 As PointF = .GazoModeInfo.OriginPoint
                            spatial.PointF_offset(P0, stp)
                            .Gazo.Position = P0
                            frm_Figure.Print_Fig()
                        End With
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Image And
                            frm_Figure.EditingFig.GazoModeInfo.DragMode = frmPrint_Figure.enmGazoDragMode.VartexDrag Then
                        '図形モード画像の頂点ドラッグ
                        set_FigGazoValue(MapPos)
                        frm_Figure.Print_Fig()

                    Else
                        '通常の地図ドラッグ
                        picMapImageOperation.DragPicture(e.Location, mouseDownPosition)
                        picMap.Cursor = Cursors.SizeAll
                    End If
                    mousePreviousPosition = e.Location
                End If
        End Select
        g.Dispose()

    End Sub
    ''' <summary>
    ''' picMapマウスアップ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseUp
        Dim mouseUpPosition As Point = e.Location
        Dim mouseUpSRXT As PointF = attrData.TotalData.ViewStyle.ScrData.getSRXY(mouseUpPosition)
        mouseUpPos = mouseUpSRXT

        If temp_data.PrintMouseMode = enmPrintMouseMode.SymbolPoint Or temp_data.PrintMouseMode = enmPrintMouseMode.LabelPoint Then
            'シンボル位置／ラベル位置移動
            If e.Button = Windows.Forms.MouseButtons.Right Then
            Else
                Dim P As PointF = attrData.TotalData.ViewStyle.ScrData.getSRXY(mouseDownPosition)
                Select Case temp_data.PrintMouseMode
                    Case enmPrintMouseMode.SymbolPoint
                        With temp_data.OnObject.Item(0)
                            With attrData.LayerData(.objLayer).atrObject.atrObjectData(.ObjNumber)
                                .Symbol = P
                            End With
                        End With
                    Case enmPrintMouseMode.LabelPoint
                        With temp_data.OnObject.Item(0)
                            With attrData.LayerData(.objLayer).atrObject.atrObjectData(.ObjNumber)
                                .Label = P
                            End With
                        End With
                End Select
                printMapScreen(True)
            End If
            picMap.Cursor = Cursors.Default
            temp_data.PrintMouseMode = enmPrintMouseMode.Normal
            temp_data.MouseDownF = False
            Return
        End If


        If mousePointingSituation = mousePointingSituations.downAndMove Then
            'ドラッグ中の場合()
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left
                    '左クリックの場合－－－－－－－－－－－－－－－－
                    Dim StartP As PointF = attrData.TotalData.ViewStyle.ScrData.getSRXY(mouseDownPosition)
                    Dim EndP As PointF = mouseUpSRXT
                    Dim mapstep = New PointF(EndP.X - StartP.X, EndP.Y - StartP.Y)
                    If temp_data.PrintMouseMode = enmPrintMouseMode.RangePrint Then
                        '表示範囲の指定
                        Reset_Menu_Enable()
                        If StartP.X = EndP.X Or StartP.Y = EndP.Y Then
                        Else
                            If clsGeneric.Check_New_ScrView(attrData.TotalData.ViewStyle.ScrData.MapRectangle, spatial.Get_Circumscribed_Rectangle(StartP, EndP)) = True Then
                                attrData.TotalData.ViewStyle.ScrData.ScrView = spatial.Get_Circumscribed_Rectangle(StartP, EndP)
                                Dim rect As Rectangle = spatial.Get_Circumscribed_Rectangle(mouseDownPosition, e.Location)
                                Dim newSize As Size = spatial.Get_RectSize_by_Menseki(rect.Size, picMap.Width * picMap.Height)
                                clsPrintMap.Change_Mapscreen_Size_and_Position(attrData, Me, newSize, 0)
                                With attrData.TotalData.ViewStyle.ScrData
                                    If .Accessory_Base = enmBasePosition.Map Then
                                        attrData.Change_Acc_Position_by_Accessory_Base_Set_Screen()
                                    End If
                                    .Accessory_Base = enmBasePosition.Screen
                                    With .Screen_Margin
                                        .Left = 0
                                        .Right = 0
                                        .Top = 0
                                        .Bottom = 0
                                    End With
                                End With
                                printMapScreen(True)
                            Else
                                MsgBox("これ以上拡大できません。", MsgBoxStyle.Exclamation)
                                picMap.Refresh()
                            End If
                        End If
                        temp_data.PrintMouseMode = enmPrintMouseMode.Normal
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Accessory_Drag Then
                        If temp_data.mouseAccesoryDragType = Check_Acc_Result.GroupBox Then
                            'グループボックスのドラッグの場合
                            Dim stp As PointF
                            If attrData.TotalData.ViewStyle.ScrData.Accessory_Base = enmBasePosition.Screen Then
                                Dim movePx As Point
                                With attrData.TempData.Accessory_Temp
                                    movePx = New Point(.GroupBox_Rect.Location.X - .OriginalGroupBoxRect.Location.X, .GroupBox_Rect.Location.Y - .OriginalGroupBoxRect.Location.Y)
                                End With
                                stp.X = movePx.X / attrData.TotalData.ViewStyle.ScrData.MapScreen_Scale.Width
                                stp.Y = movePx.Y / attrData.TotalData.ViewStyle.ScrData.MapScreen_Scale.Height
                            Else
                                stp = mapstep
                            End If
                            With attrData.TotalData.ViewStyle.AccessoryGroupBox
                                If .Title = True Then
                                    spatial.PointF_offset(attrData.TotalData.ViewStyle.MapTitle.Position, stp)
                                End If
                                If .Scale = True Then
                                    spatial.PointF_offset(attrData.TotalData.ViewStyle.MapScale.Position, stp)
                                End If
                                If .Note = True Then
                                    spatial.PointF_offset(attrData.TotalData.ViewStyle.DataNote.Position, stp)
                                End If
                                If .Comapss = True Then
                                    spatial.PointF_offset(attrData.TotalData.ViewStyle.AttMapCompass.Position, stp)
                                End If
                                If .Legend = True Then
                                    For i As Integer = 0 To attrData.TempData.Accessory_Temp.Legend_No_Max - 1
                                        spatial.PointF_offset(attrData.TotalData.ViewStyle.MapLegend.Base.LegendXY(i), stp)
                                    Next
                                End If
                            End With
                        End If
                        printMapScreen(True)
                        temp_data.PrintMouseMode = enmPrintMouseMode.Normal
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.od Then
                        '線モード
                        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
                        With temp_data.OD_Drag
                            attrData.LayerData(Layernum).Add_OD_Bezier(.ObjectPos, .Data, mouseUpSRXT)
                        End With
                        printMapScreen(True)
                        temp_data.PrintMouseMode = enmPrintMouseMode.Normal
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Word And
                                temp_data.FigMode.WordMode.DragMode = True Then
                        '図形モードの文字の文字ドラッグ
                        Dim stp As PointF
                        If frm_Figure.EditingFig.Word.Screen_Setf = False Then
                            stp = mapstep
                        Else
                            Dim movePx As Point = New Point(mouseUpPosition.X - mouseDownPosition.X, mouseUpPosition.Y - mouseDownPosition.Y)
                            stp.X = movePx.X / attrData.TotalData.ViewStyle.ScrData.MapScreen_Scale.Width
                            stp.Y = movePx.Y / attrData.TotalData.ViewStyle.ScrData.MapScreen_Scale.Height
                        End If
                        Dim P As PointF = temp_data.FigMode.WordMode.pushPoint
                        spatial.PointF_offset(P, stp)
                        frm_Figure.EditingFig.Word.StringPos(temp_data.FigMode.WordMode.DragPosition) = P
                        temp_data.FigMode.WordMode.DragMode = False
                        frm_Figure.Print_Fig()
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Line And
                            frm_Figure.EditingFig.LineModeInfo.DragMode = frmPrint_Figure.enmLineDragMode.PointDrag Then
                        '図形モードのラインの点ドラッグ
                        With frm_Figure.EditingFig
                            .Line.Points(.LineModeInfo.EditingPoint) = mouseUpSRXT
                            If .LineModeInfo.LoopDragF = True Then
                                .Line.Points(.Line.NumOfPoint - 1) = mouseUpSRXT
                            End If
                            .LineModeInfo.DragMode = frmPrint_Figure.enmLineDragMode.noDrag
                            .LineModeInfo.EditingPoint = -1
                        End With
                        frm_Figure.Print_Fig()
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Line And
                            frm_Figure.EditingFig.LineModeInfo.DragMode = frmPrint_Figure.enmLineDragMode.LineDrag Then
                        '図形モードのラインの全体ドラッグ
                        With frm_Figure.EditingFig
                            For i As Integer = 0 To .Line.NumOfPoint - 1
                                Dim P As PointF = .LineModeInfo.OriginLinePoints(i)
                                spatial.PointF_offset(P, mapstep)
                                .Line.Points(i) = P
                            Next
                            .LineModeInfo.DragMode = frmPrint_Figure.enmLineDragMode.noDrag
                        End With
                        frm_Figure.Print_Fig()
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Rectangle And
                                frm_Figure.EditingFig.RectangleModeInfo.DragMode = frmPrint_Figure.enmRectangleDragMode.PointDrag Then
                        '図形モードの四角の点ドラッグ
                        With frm_Figure.EditingFig
                            If .RectangleModeInfo.SelPointIndex = 0 Then
                                .Rectangle.Point0 = mouseUpSRXT
                            Else
                                .Rectangle.Point1 = mouseUpSRXT
                            End If
                            .RectangleModeInfo.SelPointIndex = -1
                            .RectangleModeInfo.DragMode = frmPrint_Figure.enmRectangleDragMode.noDrag
                            frm_Figure.Print_Fig()
                        End With
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Rectangle And
                            frm_Figure.EditingFig.RectangleModeInfo.DragMode = frmPrint_Figure.enmRectangleDragMode.RectDrag Then
                        '図形モードの四角の全体ドラッグ
                        With frm_Figure.EditingFig
                            Dim P0 As PointF = .RectangleModeInfo.OriginPoint0
                            spatial.PointF_offset(P0, mapstep)
                            Dim P1 As PointF = .RectangleModeInfo.OriginPoint1
                            spatial.PointF_offset(P1, mapstep)
                            .Rectangle.Point0 = P0
                            .Rectangle.Point1 = P1
                            .RectangleModeInfo.SelPointIndex = -1
                            .RectangleModeInfo.DragMode = frmPrint_Figure.enmRectangleDragMode.noDrag
                            frm_Figure.Print_Fig()
                        End With
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Circle And
                        frm_Figure.EditingFig.CircleModeInfo.DragMode = frmPrint_Figure.enmCircleDragMode.PointDrag Then
                        '円モードの点ドラッグ
                        set_FigCircleValue(mouseUpSRXT, Control.ModifierKeys)
                        frm_Figure.set_FigCircleValue_to_Panel()
                        With frm_Figure.EditingFig
                            .CircleModeInfo.DragMode = frmPrint_Figure.enmCircleDragMode.noDrag
                            .CircleModeInfo.SelPointIndex = -1
                        End With
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Circle And
                        frm_Figure.EditingFig.CircleModeInfo.DragMode = frmPrint_Figure.enmCircleDragMode.CircleDrag Then
                        '図形モードの円の全体ドラッグ
                        With frm_Figure.EditingFig
                            Dim P0 As PointF = .CircleModeInfo.OriginCenterP
                            spatial.PointF_offset(P0, mapstep)
                            .Circle.Position = P0
                            frm_Figure.Print_Fig()
                            .CircleModeInfo.DragMode = frmPrint_Figure.enmCircleDragMode.noDrag
                            .CircleModeInfo.SelPointIndex = -1
                        End With
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Point And
                                frm_Figure.EditingFig.PointModeInfo.DragMode = frmPrint_Figure.enmPointDragMode.PointDrag Then
                        '図形モード点の点ドラッグ
                        With frm_Figure.EditingFig
                            .Point.Points(.PointModeInfo.SelPointIndex) = mouseUpSRXT
                            .PointModeInfo.DragMode = frmPrint_Figure.enmPointDragMode.noDrag
                            .PointModeInfo.SelPointIndex = -1
                        End With
                        frm_Figure.Print_Fig()
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Point And
                            frm_Figure.EditingFig.PointModeInfo.DragMode = frmPrint_Figure.enmPointDragMode.PointLegendDrag Then
                        '図形モード点の凡例ドラッグ
                        With frm_Figure.EditingFig
                            Dim P0 As PointF = .PointModeInfo.OriginPoint
                            spatial.PointF_offset(P0, mapstep)
                            .Point.CaptionPosition = P0
                            .PointModeInfo.DragMode = frmPrint_Figure.enmPointDragMode.noDrag
                            .PointModeInfo.SelPointIndex = -1
                            frm_Figure.Print_Fig()
                        End With
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Image And
                            frm_Figure.EditingFig.GazoModeInfo.DragMode = frmPrint_Figure.enmGazoDragMode.GazoDrag Then
                        '図形モード画像の全体ドラッグ
                        With frm_Figure.EditingFig
                            Dim P0 As PointF = .GazoModeInfo.OriginPoint
                            spatial.PointF_offset(P0, mapstep)
                            .Gazo.Position = P0
                            .GazoModeInfo.DragMode = frmPrint_Figure.enmGazoDragMode.noDrag
                            frm_Figure.Print_Fig()
                        End With
                    ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Fig And temp_data.FigMode.Mode = enmFigureMode.Image And
                            frm_Figure.EditingFig.GazoModeInfo.DragMode = frmPrint_Figure.enmGazoDragMode.VartexDrag Then
                        '図形モード画像の頂点ドラッグ attrData.TotalData.ViewStyle.ScrData.getSRXY(mouseDownPosition)
                        set_FigGazoValue(mouseUpSRXT)
                        With frm_Figure.EditingFig.GazoModeInfo
                            .DragMode = frmPrint_Figure.enmGazoDragMode.noDrag
                            .SelectPoint = -1
                        End With
                        frm_Figure.Print_Fig()
                    Else
                        picMapImageOperation.DisposeBackCanvasPictureImage()
                        attrData.TotalData.ViewStyle.ScrData.ScrView.Offset(StartP.X - EndP.X, StartP.Y - EndP.Y)
                        printMapScreen(True)
                        Select Case temp_data.PrintMouseMode
                            Case enmPrintMouseMode.Fig
                                frm_Figure.Print_Fig()
                            Case enmPrintMouseMode.MultiObjectSelect
                                printSeletedMultiObject()
                        End Select
                    End If
                Case Windows.Forms.MouseButtons.Right
                    '右クリックはドラッグ元に戻す
                    Select Case temp_data.PrintMouseMode
                        Case enmPrintMouseMode.Normal
                            picMapImageOperation.DisposeBackCanvasPictureImage()
                            printMapScreen(True)
                        Case enmPrintMouseMode.RangePrint
                            Reset_Menu_Enable()
                            picMap.Refresh()
                        Case enmPrintMouseMode.Accessory_Drag
                            With attrData.TotalData.ViewStyle
                                Select Case temp_data.mouseAccesoryDragType
                                    Case Check_Acc_Result.Compass
                                        .AttMapCompass.Position = attrData.TempData.Accessory_Temp.Push_CompassXY
                                    Case Check_Acc_Result.Title
                                        .MapTitle.Position = attrData.TempData.Accessory_Temp.Push_titleXY
                                    Case Check_Acc_Result.Scale
                                        .MapScale.Position = attrData.TempData.Accessory_Temp.Push_ScaleXY
                                    Case Check_Acc_Result.Note
                                        .DataNote.Position = attrData.TempData.Accessory_Temp.Push_DataNoteXY
                                    Case Check_Acc_Result.Legend
                                        .MapLegend.Base.LegendXY(attrData.TempData.Accessory_Temp.Edit_Legend) = attrData.TempData.Accessory_Temp.Push_LegendXY
                                    Case Check_Acc_Result.GroupBox
                                        'GroupBoxは右クリック時は何もしない
                                End Select
                            End With
                            temp_data.PrintMouseMode = enmPrintMouseMode.Normal
                            picMap.Refresh()
                        Case enmPrintMouseMode.od
                            temp_data.PrintMouseMode = enmPrintMouseMode.Normal
                            picMap.Refresh()
                        Case enmPrintMouseMode.Fig
                            Select Case temp_data.FigMode.Mode
                                Case enmFigureMode.Word
                                    If temp_data.FigMode.WordMode.DragMode = True Then
                                        frm_Figure.EditingFig.Word.StringPos(temp_data.FigMode.WordMode.DragPosition) = temp_data.FigMode.WordMode.pushPoint
                                        temp_data.FigMode.WordMode.DragMode = False
                                    Else
                                        picMapImageOperation.DisposeBackCanvasPictureImage()
                                        printMapScreen(True)
                                    End If
                                Case enmFigureMode.Line
                                    With frm_Figure.EditingFig
                                        If .LineModeInfo.DragMode <> frmPrint_Figure.enmLineDragMode.noDrag Then
                                            Select Case .LineModeInfo.DragMode
                                                Case frmPrint_Figure.enmLineDragMode.PointDrag
                                                    .Line.Points(.LineModeInfo.EditingPoint) = .LineModeInfo.OriginPoint
                                                    If .LineModeInfo.LoopDragF = True Then
                                                        .Line.Points(.Line.NumOfPoint - 1) = .LineModeInfo.OriginPoint
                                                    End If
                                                Case frmPrint_Figure.enmLineDragMode.LineDrag
                                                    .Line.Points = .LineModeInfo.OriginLinePoints.Clone
                                            End Select
                                            .LineModeInfo.EditingPoint = -1
                                            .LineModeInfo.DragMode = frmPrint_Figure.enmLineDragMode.noDrag
                                        Else
                                            picMapImageOperation.DisposeBackCanvasPictureImage()
                                            printMapScreen(True)
                                        End If
                                    End With
                                Case enmFigureMode.Rectangle
                                    With frm_Figure.EditingFig
                                        If .RectangleModeInfo.DragMode <> frmPrint_Figure.enmRectangleDragMode.noDrag Then
                                            .Rectangle.Point0 = .RectangleModeInfo.OriginPoint0
                                            .Rectangle.Point1 = .RectangleModeInfo.OriginPoint1
                                            .RectangleModeInfo.SelPointIndex = -1
                                            .RectangleModeInfo.DragMode = frmPrint_Figure.enmRectangleDragMode.noDrag
                                        Else
                                            picMapImageOperation.DisposeBackCanvasPictureImage()
                                            printMapScreen(True)
                                        End If
                                    End With
                                Case enmFigureMode.Circle
                                    With frm_Figure.EditingFig
                                        If .CircleModeInfo.DragMode <> frmPrint_Figure.enmCircleDragMode.noDrag Then
                                            .Circle.Position = .CircleModeInfo.OriginCenterP
                                            .Circle.XR = .CircleModeInfo.OriginXr
                                            .Circle.YR = .CircleModeInfo.OriginYr
                                            .Circle.Angle = .CircleModeInfo.OriginAngle
                                            .CircleModeInfo.DragMode = frmPrint_Figure.enmCircleDragMode.noDrag
                                            .CircleModeInfo.SelPointIndex = -1
                                            frm_Figure.set_FigCircleValue_to_Panel()
                                        Else
                                            picMapImageOperation.DisposeBackCanvasPictureImage()
                                            printMapScreen(True)
                                        End If
                                    End With
                                Case enmFigureMode.Point
                                    With frm_Figure.EditingFig
                                        If .PointModeInfo.DragMode <> frmPrint_Figure.enmPointDragMode.noDrag Then
                                            Select Case .PointModeInfo.DragMode
                                                Case frmPrint_Figure.enmPointDragMode.PointDrag
                                                    .Point.Points(.PointModeInfo.SelPointIndex) = .PointModeInfo.OriginPoint
                                                Case frmPrint_Figure.enmPointDragMode.PointLegendDrag
                                                    .Point.CaptionPosition = .PointModeInfo.OriginPoint
                                            End Select
                                            .PointModeInfo.DragMode = frmPrint_Figure.enmPointDragMode.noDrag
                                            .PointModeInfo.SelPointIndex = -1
                                        Else
                                            picMapImageOperation.DisposeBackCanvasPictureImage()
                                            printMapScreen(True)
                                        End If
                                    End With
                                Case enmFigureMode.Image
                                    With frm_Figure.EditingFig
                                        If .GazoModeInfo.DragMode <> frmPrint_Figure.enmGazoDragMode.noDrag Then
                                            Select Case .GazoModeInfo.DragMode
                                                Case frmPrint_Figure.enmGazoDragMode.GazoDrag
                                                    .Gazo.Position = .GazoModeInfo.OriginPoint
                                                Case frmPrint_Figure.enmGazoDragMode.VartexDrag
                                                    .Gazo.Angle = .GazoModeInfo.OriginAngle
                                                    .Gazo.Size = .GazoModeInfo.OriginSize
                                            End Select
                                            .GazoModeInfo.DragMode = frmPrint_Figure.enmGazoDragMode.noDrag
                                            .GazoModeInfo.SelectPoint = -1
                                        Else
                                            picMapImageOperation.DisposeBackCanvasPictureImage()
                                            printMapScreen(True)
                                        End If
                                    End With
                                Case Else
                                    'オブジェクト円の右クリック
                                    picMapImageOperation.DisposeBackCanvasPictureImage()
                                    printMapScreen(True)
                            End Select
                            frm_Figure.Print_Fig()
                    End Select
            End Select
            picMap.Cursor = Cursors.Default
        Else
            'クリックの場合■■■■■■■■■■■■■■■■
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left
                    '左クリック
                    Select Case temp_data.PrintMouseMode
                        Case enmPrintMouseMode.Normal
                            If frm_Property.Visible = True Then
                                If frm_Property.pnlProperty.Visible = True Then
                                    temp_data.Location_Fixed_F = Not temp_data.Location_Fixed_F
                                    frm_Property.Fixed(temp_data.Location_Fixed_F)
                                    picMap.Focus()
                                End If
                            End If
                        Case enmPrintMouseMode.MultiObjectSelect
                            '複数オブジェクト選択
                            Select Case temp_data.MultiObjectSelectSub
                                Case enmMultiObjectSelecModesSub.Pointing
                                    If temp_data.OnObject.Count = 1 Then
                                        setSelectedMultiObject(temp_data.OnObject(0).ObjNumber)
                                    End If
                                Case enmMultiObjectSelecModesSub.Rectangle, enmMultiObjectSelecModesSub.Polygon, enmMultiObjectSelecModesSub.Circle
                                    picMapMouseMoveMultiObjectSelect_Shape(mouseUpPosition, True, False)
                            End Select

                        Case enmPrintMouseMode.Fig
                            Select Case temp_data.FigMode.Mode
                                Case enmFigureMode.Pointing
                                    '図形モードの図形指定
                                    Dim g As Graphics = picMap.CreateGraphics
                                    Dim n As Integer = Check_Figure_Location(g, mouseUpPosition)
                                    If n <> -1 Then
                                        frm_Figure.SetFigureMode(attrData.TotalData.FigureStac(n), n)
                                    End If
                                    g.Dispose()
                                Case enmFigureMode.Point
                                    '図形モードの点で点の追加
                                    If temp_data.MouseDownF = True Then
                                        frm_Figure.AddPoint(mouseUpSRXT)
                                    End If
                            End Select
                        Case enmPrintMouseMode.Distance
                            '距離面積測定
                            If spatial.Check_PsitionReverse_Enable(mouseUpSRXT, attrData.TotalData.ViewStyle.Zahyo) = True Then
                                temp_data.PointDistanceArea.Add(mouseUpSRXT)
                                picMap.Refresh()
                            End If
                    End Select
                Case Windows.Forms.MouseButtons.Right
                    '右クリック
                    Select Case temp_data.PrintMouseMode
                        Case enmPrintMouseMode.Normal
                            Dim Acc As Check_Acc_Result = Check_Acc(e.Location)
                            If Acc = Check_Acc_Result.NoAccessory Then
                                '非表示の飾りを表示させるメニューの表示
                                mnuAccPopupVisible.Items.Clear()
                                If attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F = False Then
                                    Me.temp_data.LocationMenuString.ClickMapPos = mouseUpSRXT
                                    Loc_Data_Menu()
                                End If
                                With attrData.TotalData.ViewStyle
                                    If .MapTitle.Visible = False Or .MapLegend.Base.Visible = False Or .MapScale.Visible = False Or
                                         .AttMapCompass.Visible = False Or .AttMapCompass.Visible = False Or .AccessoryGroupBox.Visible = False Then
                                        If mnuAccPopupVisible.Items.Count > 0 Then
                                            mnuAccPopupVisible.Items.Add("-")
                                        End If
                                    End If
                                    If .MapTitle.Visible = False Then
                                        mnuAccPopupVisible.Items.Add("タイトル表示", Nothing, AddressOf AccTitleVisible)
                                    End If
                                    If .MapLegend.Base.Visible = False Then
                                        mnuAccPopupVisible.Items.Add("凡例表示", Nothing, AddressOf AccLegendVisible)
                                    End If
                                    If .MapScale.Visible = False Then
                                        mnuAccPopupVisible.Items.Add("スケール表示", Nothing, AddressOf AccScaleVisible)
                                    End If
                                    If .AttMapCompass.Visible = False Then
                                        mnuAccPopupVisible.Items.Add("方位表示", Nothing, AddressOf AccCompassVisible)
                                    End If
                                    If .DataNote.Visible = False Then
                                        mnuAccPopupVisible.Items.Add("注表示", Nothing, AddressOf AccNoteVisible)
                                    End If
                                    If .AccessoryGroupBox.Visible = False Then
                                        mnuAccPopupVisible.Items.Add("飾りグループボックス表示", Nothing, AddressOf AccGroupBoxVisible)
                                    End If
                                End With
                                If attrData.TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                                    Dim webtmenu = New ToolStripMenuItem()
                                    webtmenu.Text = "この地点のWeb地図を表示"
                                    webtmenu.DropDownItems.Add("Googleマップ", Nothing, AddressOf webMapShow)
                                    webtmenu.DropDownItems.Add("YAHOO!地図", Nothing, AddressOf webMapShow)
                                    webtmenu.DropDownItems.Add("Mapion", Nothing, AddressOf webMapShow)
                                    webtmenu.DropDownItems.Add("MapFan", Nothing, AddressOf webMapShow)
                                    webtmenu.DropDownItems.Add("地理院地図", Nothing, AddressOf webMapShow)
                                    webtmenu.DropDownItems.Add("今昔マップ", Nothing, AddressOf webMapShow)
                                    mnuAccPopupVisible.Items.Add(webtmenu)
                                End If
                                If mnuAccPopupVisible.Items.Count > 0 Then
                                    mnuAccPopupVisible.Show(picMap, mouseUpPosition)
                                    temp_data.RightButtonClickF = True 'MouseLeaveイベントで画面がRefreshされないようにする
                                End If
                            Else
                                '飾り上で右クリックメニュー
                                mnuAccPopup.Tag = Acc
                                Select Case Acc
                                    Case Check_Acc_Result.Compass
                                        mnuAccPopupInvisible.Text = "方位非表示"
                                        mnuAccPopupSettings.Text = "方位設定"
                                    Case Check_Acc_Result.GroupBox
                                        mnuAccPopupInvisible.Text = "飾りグループボックス非表示"
                                        mnuAccPopupSettings.Text = "飾りグループボックス設定"
                                    Case Check_Acc_Result.Legend
                                        mnuAccPopupInvisible.Text = "凡例非表示"
                                        mnuAccPopupSettings.Text = "凡例設定"
                                    Case Check_Acc_Result.Scale
                                        mnuAccPopupInvisible.Text = "スケール非表示"
                                        mnuAccPopupSettings.Text = "スケール設定"
                                    Case Check_Acc_Result.Note
                                        mnuAccPopupInvisible.Text = "注釈非表示"
                                        mnuAccPopupSettings.Text = "注釈設定"
                                    Case Check_Acc_Result.Title
                                        mnuAccPopupInvisible.Text = "タイトル非表示"
                                        mnuAccPopupSettings.Text = "タイトル設定"
                                End Select
                                Me.mnuAccPopup.Show(picMap, mouseUpPosition)
                            End If

                        Case enmPrintMouseMode.od
                            '線モードの元に戻すメニュー
                            temp_data.PrintMouseMode = enmPrintMouseMode.Normal
                            Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
                            Dim ControlP As PointF
                            If attrData.LayerData(Layernum).Get_OD_Bezier_RefPoint(temp_data.OD_Drag.ObjectPos, temp_data.OD_Drag.Data, ControlP) = True Then
                                Me.mnuODLineCurveResetMenu.Show(picMap, mouseUpPosition)
                            End If
                        Case enmPrintMouseMode.Fig
                            Select Case temp_data.FigMode.Mode
                                Case enmFigureMode.Line
                                    '図形モードのラインの点を削除
                                    Dim EditingPoint As Integer
                                    Dim EditingLine As Integer
                                    Dim NpXY As PointF
                                    Dim DragZoneF As Boolean
                                    check_FigLineMode_NearLinePointOrLineSegment(e.Location, EditingPoint, EditingLine, NpXY, DragZoneF)
                                    If EditingPoint <> -1 Then
                                        With frm_Figure.EditingFig
                                            Dim nm As Integer = .Line.NumOfPoint
                                            Dim lpf As Boolean = .Line.Points(0).Equals(.Line.Points(nm - 1))
                                            If (lpf = True And nm > 4) Or (lpf = False And nm > 2) Then
                                                clsGeneric.Remove_Point_Array(EditingPoint, .Line.Points)
                                                .Line.NumOfPoint -= 1
                                                frm_Figure.EditingFig.LineModeInfo.EditingPoint = -1
                                            End If
                                        End With
                                        frm_Figure.Print_Fig()
                                    End If
                                Case enmFigureMode.Point
                                    '図形モードの点の点を削除
                                    Dim onLegendF As Boolean
                                    Dim Epoint As Integer
                                    Dim g As Graphics = picMap.CreateGraphics
                                    check_FigPointMode_NearPointOrLegend(g, e.Location, frm_Figure.EditingFig.Point, Epoint, onLegendF)
                                    frm_Figure.EditingFig.PointModeInfo.SelPointIndex = -1
                                    If Epoint <> -1 Then
                                        frm_Figure.RemovePoint(Epoint)
                                    End If
                                    g.Dispose()
                            End Select
                        Case enmPrintMouseMode.MultiObjectSelect
                            Select Case temp_data.MultiObjectSelectSub
                                Case enmMultiObjectSelecModesSub.Circle, enmMultiObjectSelecModesSub.Polygon, enmMultiObjectSelecModesSub.Rectangle
                                    picMapMouseMoveMultiObjectSelect_Shape(mouseUpPosition, True, True)
                                Case enmMultiObjectSelecModesSub.Pointing
                            End Select
                        Case enmPrintMouseMode.Distance
                            '距離面積測定1つ戻る
                            If temp_data.PointDistanceArea.Count > 0 Then
                                temp_data.PointDistanceArea.RemoveAt(temp_data.PointDistanceArea.Count - 1)
                            End If
                            picMap.Refresh()
                    End Select
            End Select
        End If
        mousePointingSituation = mousePointingSituations.up
        Select Case temp_data.PrintMouseMode
            Case enmPrintMouseMode.Normal
                PrintCursorObjectLine(True)
        End Select

        temp_data.MouseDownF = False

    End Sub
    Private Sub webMapShow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim P As PointF = spatial.Get_Reverse_XY(mouseUpPos, attrData.TotalData.ViewStyle.Zahyo)
        Dim url As String = ""
        Dim zm As String = "13"
        Select Case sender.ToString
            Case "Googleマップ"
                url = "https://www.google.com/maps/search/?api=1&query=" + P.Y.ToString + "," + P.X.ToString + "&zoom=" + zm
            Case "YAHOO!地図"
                url = "https://map.yahoo.co.jp/maps?lat=" + P.Y.ToString + "&lon=" + P.X.ToString + "&z=" + zm
            Case "Mapion"
                url = "https://www.mapion.co.jp/m2/" + P.Y.ToString + "," + P.X.ToString + "," + zm
            Case "MapFan"
                url = "https://mapfan.com/map/spots/search?c=" + P.Y.ToString + "," + P.X.ToString + "," + zm
            Case "地理院地図"
                url = "http://maps.gsi.go.jp/#" + zm + "/" + P.Y.ToString + "/" + P.X.ToString + "/"
            Case "今昔マップ"
                url = "http://ktgis.net/kjmapw/kjmapw.html?" + "lat=" + P.Y.ToString + "&lng=" + P.X.ToString + "&zoom=" + zm
        End Select
        System.Diagnostics.Process.Start(url)
    End Sub
    ''' <summary>
    ''' 複数オブジェクト選択モードで画面クリックでオフジェクト追加・削除
    ''' </summary>
    ''' <param name="ObjNumber">オブジェクト番号</param>
    ''' <remarks></remarks>
    Private Sub setSelectedMultiObject(ByVal ObjNumber As Integer)
        If temp_data.MultiObjects.Contains(ObjNumber) = True Then
            temp_data.MultiObjects.RemoveAt(temp_data.MultiObjects.IndexOf(ObjNumber))
        Else
            temp_data.MultiObjects.Add(ObjNumber)
        End If
        SetMultiObJInformation()
        printSeletedMultiObject()
    End Sub
    ''' <summary>
    ''' 複数オブジェクト選択モードの選択情報をパネルに表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetMultiObJInformation()
        frm_Property.ShowMultiObjectInformation(attrData, temp_data.MultiObjects)
    End Sub
    Private Sub picMap_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseWheel
        If mousePointingSituation = mousePointingSituations.up Then
            picMapImageOperation.pictureBoxMouseWheel(e.Location, e.Delta, attrData.TotalData.ViewStyle.ScrData)
            printMapScreen(True)
            Select Case temp_data.PrintMouseMode
                Case enmPrintMouseMode.Fig
                    frm_Figure.Print_Fig()
                Case enmPrintMouseMode.Normal
                    PrintCursorObjectLine(True)
                Case enmPrintMouseMode.MultiObjectSelect
                    printSeletedMultiObject()
            End Select

        End If

    End Sub
    ''' <summary>
    ''' 右クリックオブジェクトメニュー
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Loc_Data_Menu()
        Select Case attrData.TotalData.LV1.Print_Mode_Total
            Case enmTotalMode_Number.DataViewMode
                If temp_data.OnObject.Count = 1 Then
                    mnuAccPopupVisible.Items.Add("図形モードでオブジェクト名・データ値表示", Nothing, AddressOf mnuAccPopupVisible_ObjectValueShow)
                    Dim Layernum As Integer = temp_data.OnObject.Item(0).objLayer
                    Dim ObjNum As Integer = temp_data.OnObject.Item(0).ObjNumber
                    Dim dtIndex As Integer = temp_data.LocationMenuString.DataIndex
                    Dim SymbolPosMeuF As Boolean = False
                    Select Case attrData.LayerData(Layernum).Print_Mode_Layer
                        Case enmLayerMode_Number.SoloMode
                            Me.temp_data.LocationMenuString.ObjectNameValue = attrData.getOneObjectPanelLabelString(Layernum, dtIndex, ObjNum, ":")
                            Select Case attrData.SoloMode(Layernum, dtIndex)
                                Case enmSoloMode_Number.ClassMarkMode, enmSoloMode_Number.MarkBlockMode, enmSoloMode_Number.MarkSizeMode, enmSoloMode_Number.MarkTurnMode, enmSoloMode_Number.MarkBarMode
                                    SymbolPosMeuF = True
                                Case enmSoloMode_Number.ClassHatchMode, enmSoloMode_Number.ClassPaintMode
                                    If attrData.LayerData(Layernum).Shape = enmShape.PointShape Then
                                        SymbolPosMeuF = True
                                    End If
                            End Select
                        Case enmLayerMode_Number.GraphMode
                            Dim DataItem() As clsAttrData.GraphModeDataItem = attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode.DataSet(dtIndex).Data
                            Dim n As Integer = attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode.DataSet(dtIndex).Count
                            Dim tx As String = ""
                            For i As Integer = 0 To n - 1
                                tx += attrData.Get_DataTitle(Layernum, DataItem(i).DataNumner, False) + ":" +
                                 attrData.Get_Data_Value(Layernum, DataItem(i).DataNumner, ObjNum, "") + attrData.Get_DataUnit(Layernum, DataItem(i).DataNumner)
                                If i <> n - 1 Then
                                    tx += vbCrLf
                                End If
                            Next
                            Me.temp_data.LocationMenuString.ObjectNameValue = tx
                            SymbolPosMeuF = True
                        Case enmLayerMode_Number.LabelMode
                            Dim DataItem() As Integer = attrData.LayerData(Layernum).LayerModeViewSettings.LabelMode.DataSet(dtIndex).DataItem
                            Dim n As Integer = attrData.LayerData(Layernum).LayerModeViewSettings.LabelMode.DataSet(dtIndex).CountOfDataItem
                            Dim tx As String = ""
                            For i As Integer = 0 To n - 1
                                tx += attrData.Get_DataTitle(Layernum, DataItem(i), False) + ":" +
                                 attrData.Get_Data_Value(Layernum, DataItem(i), ObjNum, "") + attrData.Get_DataUnit(Layernum, DataItem(i))
                                If i <> n - 1 Then
                                    tx += vbCrLf
                                End If
                            Next
                            Me.temp_data.LocationMenuString.ObjectNameValue = tx

                        Case enmLayerMode_Number.TripMode
                    End Select
                    If SymbolPosMeuF = True Then
                        mnuAccPopupVisible.Items.Add("記号表示位置移動", Nothing, AddressOf mnuSymbolPositionChange)
                        With attrData.LayerData(Layernum).atrObject.atrObjectData(ObjNum)
                            If .CenterPoint.Equals(.Symbol) = False Then
                                mnuAccPopupVisible.Items.Add("記号表示位置を元に戻す", Nothing, AddressOf mnuResetSymbolPosition)
                            End If
                        End With
                    End If
                    If attrData.LayerData(Layernum).Print_Mode_Layer = enmLayerMode_Number.LabelMode Or (attrData.LayerData(Layernum).Print_Mode_Layer = enmLayerMode_Number.SoloMode And
                                 attrData.SoloMode(Layernum, dtIndex) = enmSoloMode_Number.StringMode) Then
                        mnuAccPopupVisible.Items.Add("ラベル表示位置移動", Nothing, AddressOf mnuLabelPositionChange)
                        With attrData.LayerData(Layernum).atrObject.atrObjectData(ObjNum)
                            If .CenterPoint.Equals(.Label) = False Then
                                mnuAccPopupVisible.Items.Add("ラベル表示位置を元に戻す", Nothing, AddressOf mnuResetLabelPosition)
                            End If
                        End With
                    End If
                    With attrData.LayerData(Layernum).atrObject.atrObjectData(ObjNum)
                        If .HyperLinkNum > 0 Then
                            mnuAccPopupVisible.Items.Add("-")
                        End If
                        For i As Integer = 0 To .HyperLinkNum - 1
                            Dim itm As New ToolStripMenuItem
                            itm.Text = "リンク：" + .HyperLink(i).Name
                            itm.Tag = .HyperLink(i).Address
                            AddHandler itm.Click, AddressOf mnuAccPopupVisible_Link
                            mnuAccPopupVisible.Items.Add(itm)
                        Next
                        mnuAccPopupVisible.Items.Add("-")
                        mnuAccPopupVisible.Items.Add("リンクの編集", Nothing, AddressOf mnuAccPopupVisible_LinkEdit)

                        Dim ObjName As String = clsGeneric.Check_StringLength_And_Cut(attrData.Get_KenObjName(Layernum, ObjNum), 20)
                        If .Objectstructure = enmKenCodeObjectstructure.SyntheticObj Then
                            mnuAccPopupVisible.Items.Add(ObjName + "の構成", Nothing, AddressOf mnuAccPopupVisible_synthetic)
                        ElseIf attrData.LayerData(Layernum).Time.nullFlag = False Then
                            mnuAccPopupVisible.Items.Add(ObjName + "の時間変化", Nothing, AddressOf mnuAccPopupVisible_TimeChange)
                        End If
                    End With
                End If
            Case Else
        End Select
        If Me.temp_data.LocationMenuString.ContourStacPos <> -1 Then
            mnuAccPopupVisible.Items.Add("等値線の値表示", Nothing, AddressOf mnuAccPopupVisible_ContourValueShow)
        End If



    End Sub
    ''' <summary>
    ''' 右クリックメニュー／記号表示位置の移動
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mnuSymbolPositionChange()

        If temp_data.SymbolPointFirstMessage = True Then
            If clsGeneric.MessageBox(FormStartPosition.Manual, "新しい記号表示位置をクリックして指定します(右クリックでキャンセル)。", MsgBoxStyle.YesNo, MessageBoxIcon.None) = MsgBoxResult.No Then
                Return
            End If
        End If
        temp_data.SymbolPointFirstMessage = False
        picMap.Cursor = Cursors.Cross
        temp_data.PrintMouseMode = enmPrintMouseMode.SymbolPoint
    End Sub
    ''' <summary>
    ''' 右クリックメニュー／記号表示位置を元に戻す
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mnuResetSymbolPosition()
        With temp_data.OnObject.Item(0)
            With attrData.LayerData(.objLayer).atrObject.atrObjectData(.ObjNumber)
                .Symbol = .CenterPoint
            End With
        End With
        printMapScreen(True)
    End Sub
    ''' <summary>
    ''' 右クリックメニュー／ラベル位置の移動
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mnuLabelPositionChange()
        If temp_data.LabelPointFirstMessage = True Then
            If clsGeneric.MessageBox(FormStartPosition.Manual, "新しいラベル表示位置をクリックして指定します(右クリックでキャンセル)。", MsgBoxStyle.YesNo, MessageBoxIcon.None) = MsgBoxResult.No Then
                Return
            End If
        End If
        temp_data.LabelPointFirstMessage = False
        picMap.Cursor = Cursors.Cross
        temp_data.PrintMouseMode = enmPrintMouseMode.LabelPoint

    End Sub
    ''' <summary>
    ''' 右クリックメニュー／ラベル位置を元に戻す
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mnuResetLabelPosition()
        With temp_data.OnObject.Item(0)
            With attrData.LayerData(.objLayer).atrObject.atrObjectData(.ObjNumber)
                .Label = .CenterPoint
            End With
        End With
        printMapScreen(True)
    End Sub
    ''' <summary>
    ''' 右クリックメニュー/等値線の値表示"
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mnuAccPopupVisible_ContourValueShow()
        Dim FWord As clsAttrData.strFig_Word_Data
        Dim c As Integer = Me.temp_data.LocationMenuString.ContourStacPos
        Dim cdata As clsAttrData.strContour_Line_property = attrData.TempData.ContourMode_Temp.Contour_Object(c)
        With FWord
            ReDim .StringPos(0)
            .StringPos(0) = temp_data.LocationMenuString.ClickMapPos
            .Caption = cdata.Value.ToString + attrData.Get_DataUnit(cdata.Layernum, cdata.DataNum)
            .Data.Layer = cdata.Layernum + 1
            .Data.Data = cdata.DataNum + 1
            .Scattered_Mode_F = False
        End With
        Send_to_FigMode(FWord)
    End Sub
    ''' <summary>
    ''' 右クリックメニュー/オブジェクト名・データ値表示"
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mnuAccPopupVisible_ObjectValueShow()
        Dim FWord As clsAttrData.strFig_Word_Data
        With FWord
            Dim lay As Integer = temp_data.OnObject.Item(0).objLayer
            ReDim .StringPos(0)
            .StringPos(0) = temp_data.LocationMenuString.ClickMapPos
            .Caption = attrData.Get_KenObjName(lay, temp_data.OnObject.Item(0).ObjNumber) + vbCrLf +
                        temp_data.LocationMenuString.ObjectNameValue
            .Data.Layer = lay + 1
            If attrData.LayerData(lay).Print_Mode_Layer = enmLayerMode_Number.SoloMode Then
                .Data.Data = attrData.LayerData(lay).atrData.SelectedIndex + 1
            Else
                .Data.Data = 0
            End If
            .Scattered_Mode_F = False
        End With
        Send_to_FigMode(FWord)
    End Sub
    ''' <summary>
    ''' 右クリックメニュー/リンク
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuAccPopupVisible_Link(sender As System.Object, e As System.EventArgs)
        Dim theItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        System.Diagnostics.Process.Start(theItem.Tag)
    End Sub
    ''' <summary>
    ''' 右クリックメニュー/リンク編集
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuAccPopupVisible_LinkEdit(sender As System.Object, e As System.EventArgs)
        Dim lay As Integer = temp_data.OnObject.Item(0).objLayer
        Dim obj As Integer = attrData.LayerData(lay).atrObject.atrObjectData(temp_data.OnObject.Item(0).ObjNumber).MpObjCode
        Dim form As New frmPrint_LinkEdit
        form.ShowDialog(attrData, lay, obj)
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 右クリックメニュー/構成
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuAccPopupVisible_synthetic(sender As System.Object, e As System.EventArgs)
        Dim lay As Integer = temp_data.OnObject.Item(0).objLayer
        Dim obj As Integer = attrData.LayerData(lay).atrObject.atrObjectData(temp_data.OnObject.Item(0).ObjNumber).MpObjCode
        Dim form As New frmSyntheticObject
        form.ShowDialog(attrData, lay, obj)
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 右クリックメニュー/時間変化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuAccPopupVisible_TimeChange(sender As System.Object, e As System.EventArgs)
        Dim form As New frmMED_Show_Object_Time_Series
        Dim lay As Integer = temp_data.OnObject.Item(0).objLayer
        Dim obj As Integer = temp_data.OnObject.Item(0).ObjNumber
        Dim objcode As Integer = attrData.Get_KenObjCode(lay, obj)
        form.ShowDialog(Me, attrData.LayerData(lay).MapFileData.MPObj(objcode), attrData.LayerData(lay).MapFileData)
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 図形モードにデータを送る
    ''' </summary>
    ''' <param name="FigData"></param>
    ''' <remarks></remarks>
    Private Sub Send_to_FigMode(ByRef FigData As Object)
        ownerForm.Enabled = False
        Me.Tag = "OFF"
        mnuFigureMode.Checked = True
        Me.Tag = ""
        temp_data.PrintMouseMode = enmPrintMouseMode.Fig
        If frm_Figure.IsDisposed = True Then
            frm_Figure = New frmPrint_Figure
            frm_Figure.Owner = Me
        End If
        frm_Figure.Show(attrData, FigData)
    End Sub
    ''' <summary>
    ''' 図形モードの画像座標設定
    ''' </summary>
    ''' <param name="MPos"></param>
    ''' <param name="SelPoint"></param>
    ''' <remarks></remarks>
    Private Sub set_FigGazoValue(ByVal MapPos As PointF)
        With frm_Figure.EditingFig.Gazo
            Dim GazoSize As Size = attrData.TotalData.BasePicture.PictureData(.PictureNumber).Size
            Dim Dis As Single = spatial.get_Distance(MapPos, .Position)
            Dim st As Single
            If GazoSize.Width >= GazoSize.Height Then
                st = Math.Sqrt(Dis ^ 2 / (1 + (GazoSize.Height / GazoSize.Width) ^ 2)) * 2
            Else
                st = Math.Sqrt(Dis ^ 2 / (1 + (GazoSize.Width / GazoSize.Height) ^ 2)) * 2
            End If
            Dim N_Size As Single = st / attrData.TotalData.ViewStyle.ScrData.STDWsize * 100
            Select Case frm_Figure.EditingFig.GazoModeInfo.SelectPoint
                Case 1, 3 '回転付き
                    Dim x2 As Single = MapPos.X - .Position.X
                    Dim y2 As Single = MapPos.Y - .Position.Y
                    Dim si As Single = -y2 / Dis
                    Dim co As Single = x2 / Dis
                    Dim Angle1 As Single = clsGeneric.Angle(si, co)
                    si = GazoSize.Height / Math.Sqrt(GazoSize.Width ^ 2 + GazoSize.Height ^ 2)
                    co = GazoSize.Width / Math.Sqrt(GazoSize.Width ^ 2 + GazoSize.Height ^ 2)
                    Dim AngleO As Single = clsGeneric.Angle(si, co)
                    Dim N_Angle As Single = Angle1 - AngleO
                    If frm_Figure.EditingFig.GazoModeInfo.SelectPoint = 3 Then
                        N_Angle = N_Angle - 180
                    End If
                    If .Size <> N_Size Or .Angle <> N_Angle Then
                        .Size = N_Size
                        .Angle = N_Angle
                        frm_Figure.set_FigGazoValue_to_Panel()
                    End If
                Case 0, 2 '拡大縮小
                    If .Size <> N_Size Then
                        .Size = N_Size
                    End If
            End Select

        End With

    End Sub
    ''' <summary>
    ''' 図形モード円の点ドラッグ座標設定と表示
    ''' </summary>
    ''' <param name="MPos"></param>
    ''' <param name="keyvalue"></param>
    ''' <remarks></remarks>
    Private Sub set_FigCircleValue(ByVal MPos As PointF, ByVal keyvalue As Keys)
        With frm_Figure.EditingFig
            Dim Dis As Single = spatial.get_Distance(.CircleModeInfo.OriginCenterP, MPos)
            If Dis > 0 Then
                Dim xy2 As PointF = MPos
                spatial.PointF_offset(xy2, -.CircleModeInfo.OriginCenterP.X, -.CircleModeInfo.OriginCenterP.Y)
                Dim si As Single = -xy2.Y / Dis
                Dim co As Single = xy2.X / Dis
                Dim MapScaleBairitu As Single
                Dim map As clsMapData.strMap_data = attrData.SetMapFile("").Map
                If map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
                    MapScaleBairitu = map.SCL
                Else
                    MapScaleBairitu = spatial.Get_Scale_Baititu_IdoKedo(MPos, map.Zahyo)
                End If
                Dis /= MapScaleBairitu
                With .Circle
                    Select Case frm_Figure.EditingFig.CircleModeInfo.SelPointIndex
                        Case 0
                            .XR = Dis
                            .Angle = clsGeneric.Angle(si, co) - 180
                            If keyvalue = Keys.Shift Then
                                'シフトキーの場合はXY軸の比率を保って変化
                                Dim rr As Single = .XR / frm_Figure.EditingFig.CircleModeInfo.OriginXr
                                .YR = frm_Figure.EditingFig.CircleModeInfo.OriginYr * rr
                            ElseIf keyvalue = Keys.Control Then
                                'コントロールキーの場合は正円にする
                                .YR = Dis
                            End If
                        Case 1
                            .XR = Dis
                            .Angle = clsGeneric.Angle(si, co)
                            If keyvalue = Keys.Shift Then
                                Dim rr As Single = .XR / frm_Figure.EditingFig.CircleModeInfo.OriginXr
                                .YR = frm_Figure.EditingFig.CircleModeInfo.OriginYr * rr
                            ElseIf keyvalue = Keys.Control Then
                                .YR = Dis
                            End If
                        Case 2
                            .Angle = clsGeneric.Angle(si, co) - 270
                            .YR = Dis
                            If keyvalue = Keys.Shift Then
                                Dim rr As Single = .YR / frm_Figure.EditingFig.CircleModeInfo.OriginYr
                                .XR = frm_Figure.EditingFig.CircleModeInfo.OriginXr * rr
                            ElseIf keyvalue = Keys.Control Then
                                .XR = Dis
                            End If
                        Case 3
                            .Angle = clsGeneric.Angle(si, co) - 90
                            .YR = Dis
                            If keyvalue = Keys.Shift Then
                                Dim rr As Single = .YR / frm_Figure.EditingFig.CircleModeInfo.OriginYr
                                .XR = frm_Figure.EditingFig.CircleModeInfo.OriginXr * rr
                            ElseIf keyvalue = Keys.Control Then
                                .XR = Dis
                            End If
                    End Select
                    If .Angle < 0 Then .Angle = 360 + .Angle
                    If .Angle > 360 Then .Angle = .Angle - 360
                End With
                frm_Figure.Print_Fig()
            End If
        End With

    End Sub
    Private Enum enmCeck_FigureRectangle
        Point0 = 0
        Point1 = 1
        DragRect = 2
        No = -1
    End Enum
    ''' <summary>
    ''' 図形の四角でマウスとの位置関係に応じた値を返す
    ''' </summary>
    ''' <param name="MouseP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function check_FigureRectangle_MousePosition(ByVal MouseP As Point) As enmCeck_FigureRectangle
        Dim P0 As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(frm_Figure.EditingFig.Rectangle.Point0)
        Dim P1 As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(frm_Figure.EditingFig.Rectangle.Point1)
        Dim srect As Rectangle = spatial.Get_Circumscribed_Rectangle(P0, P1)
        Dim dis As Integer
        Dim inF As Boolean = spatial.Check_PointInBox(MouseP, srect, dis)
        Dim disp0 As Integer = spatial.get_Distance(P0, MouseP)
        Dim disp1 As Integer = spatial.get_Distance(P1, MouseP)
        If disp0 < 5 Or disp1 < 5 Then
            If disp0 < disp1 Then
                Return enmCeck_FigureRectangle.Point0
            Else
                Return enmCeck_FigureRectangle.Point1
            End If
        ElseIf (inF = True And frm_Figure.EditingFig.Rectangle.Back.Tile.TileCode <> enmTilePattern.Blank) Or dis < 5 Then
            Return enmCeck_FigureRectangle.DragRect
        Else
            Return enmCeck_FigureRectangle.No
        End If
    End Function
    Private Sub frmPrint_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If mnuPropertyWindow.Checked = True Then
            frm_Property.Show()
        End If
        Me.Focus()
        picMap.Focus()

    End Sub
    Public Structure strLocationSearchObject
        Public objLayer As Integer
        Public ObjNumber As Integer
    End Structure
    ''' <summary>
    ''' マウス位置の情報、カーソルを＋に変える場合trueを返す
    ''' </summary>
    ''' <param name="ScreenP"></param>
    ''' <remarks></remarks>
    Private Sub LocationSearch(ByVal ScreenP As Point)
        Dim MapP As PointF = attrData.TotalData.ViewStyle.ScrData.getSRXY(ScreenP)
        '座標
        picMapMouseMovePointInformation(ScreenP)

        temp_data.OnObject = New List(Of strLocationSearchObject)
        Dim L_Print_Mode_Total As enmTotalMode_Number
        Dim L_Layer As Integer
        Dim L_Print_Mode_Layer As enmLayerMode_Number
        Dim L_Data As Integer
        Dim L_Solomode As enmSoloMode_Number
        If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.SeriesMode Then
            Dim koma As Integer = attrData.TempData.Series_temp.Koma
            Dim n As Integer = attrData.TotalData.TotalMode.Series.SelectedIndex
            With attrData.TotalData.TotalMode.Series.DataSet(n).DataItem(koma)
                L_Print_Mode_Total = .Print_Mode_Total
                L_Print_Mode_Layer = .Print_Mode_Layer
                L_Layer = .Layer
                L_Data = .Data
                L_Solomode = .SoloMode
            End With
        Else
            With attrData.TotalData.LV1
                L_Print_Mode_Total = .Print_Mode_Total
                L_Layer = .SelectedLayer
                With attrData.LayerData(L_Layer)
                    L_Print_Mode_Layer = .Print_Mode_Layer
                    L_Data = .atrData.SelectedIndex
                    Select Case L_Print_Mode_Total
                        Case enmTotalMode_Number.DataViewMode
                            Select Case L_Print_Mode_Layer
                                Case enmLayerMode_Number.SoloMode
                                    L_Data = .atrData.SelectedIndex
                                    L_Solomode = .atrData.Data(L_Data).ModeData
                                Case enmLayerMode_Number.GraphMode
                                    L_Data = .LayerModeViewSettings.GraphMode.SelectedIndex
                                Case enmLayerMode_Number.LabelMode
                                    L_Data = .LayerModeViewSettings.LabelMode.SelectedIndex
                                Case enmLayerMode_Number.TripMode
                                    L_Data = .LayerModeViewSettings.TripMode.SelectedIndex
                            End Select
                        Case enmTotalMode_Number.OverLayMode
                            L_Data = attrData.TotalData.TotalMode.OverLay.SelectedIndex
                    End Select
                End With
            End With
        End If
        Select Case L_Print_Mode_Total
            Case enmTotalMode_Number.DataViewMode
                'データ表示モード
                Dim OnObject As List(Of strLocationSearchObject)
                Dim Layernum As Integer = L_Layer
                Dim dtindex = L_Data
                Select Case L_Print_Mode_Layer
                    Case enmLayerMode_Number.SoloMode
                        OnObject = NearestObject(MapP, Layernum)

                    Case enmLayerMode_Number.GraphMode
                        OnObject = NearestObject(MapP, Layernum)
                    Case enmLayerMode_Number.LabelMode
                        OnObject = NearestObject(MapP, Layernum)
                    Case enmLayerMode_Number.TripMode
                        OnObject = NearestObject(MapP, Layernum)
                        If OnObject.Count = 0 Then
                            frm_Property.pnlProperty.Visible = False
                        Else
                            If mnuPropertyWindow.Checked = True Then
                                frm_Property.ShowTripModeProperty(attrData, Layernum, OnObject, dtindex)
                            End If
                        End If
                End Select
                If L_Print_Mode_Layer <> enmLayerMode_Number.TripMode Then
                    Select Case OnObject.Count
                        Case 0
                            frm_Property.pnlProperty.Visible = False
                            StatusLabel2.Text = ""
                        Case 1
                            If mnuPropertyWindow.Checked = True And temp_data.PrintMouseMode = enmPrintMouseMode.Normal Then
                                frm_Property.ShowOneObjectProperty(attrData, Layernum, OnObject(0).ObjNumber, dtindex, attrData.LayerData(Layernum).Print_Mode_Layer)
                            End If
                            temp_data.LocationMenuString.DataIndex = dtindex
                        Case Else
                            Dim ptx As String = ""
                            For i As Integer = 0 To OnObject.Count - 1
                                ptx += attrData.Get_KenObjName(Layernum, OnObject(i).ObjNumber) + vbCrLf +
                                    attrData.Get_DataTitle(Layernum, dtindex, False) + ":" +
                                attrData.Get_Data_Value(Layernum, dtindex, OnObject(i).ObjNumber, attrData.TotalData.ViewStyle.Missing_Data.Label) +
                                attrData.Get_DataUnit_With_Kakko(Layernum, dtindex)
                                If i <> OnObject.Count - 1 Then
                                    ptx += vbCrLf + vbCrLf
                                End If
                            Next
                            If mnuPropertyWindow.Checked = True And temp_data.PrintMouseMode = enmPrintMouseMode.Normal Then
                                frm_Property.ShowOverLayObjectProperty(ptx)
                            End If
                    End Select
                End If
                Dim tx As String = ""
                For i As Integer = 0 To OnObject.Count - 1
                    Dim onum As Integer = OnObject(i).ObjNumber
                    tx += attrData.Get_KenObjName(Layernum, onum) + "［" + attrData.Get_Data_Value(Layernum, L_Data, onum, "欠損値") + "］"
                    If i <> OnObject.Count - 1 Then
                        tx += "／"
                    End If
                Next
                If tx <> "" Then
                    If temp_data.PrintMouseMode = enmPrintMouseMode.MultiObjectSelect Then
                        If temp_data.MultiObjects.IndexOf(OnObject(0).ObjNumber) <> -1 Then
                            tx += "（選択中）"
                        End If
                    End If
                End If
                StatusLabel2.Text = tx
                temp_data.OnObject = OnObject
                If temp_data.PrintMouseMode = enmPrintMouseMode.MultiObjectSelect And L_Print_Mode_Layer = enmLayerMode_Number.SoloMode Then
                End If

            Case enmTotalMode_Number.OverLayMode
                '重ね合わせモード
                Get_Object_By_XY_OverLayMode(MapP, L_Data)
                'Case enmTotalMode_Number.SeriesMode
                '    '連続表示モード
                '    Dim OnObject As List(Of strLocationSearchObject)
                '    Dim ix As Integer = attrData.TotalData.TotalMode.Series.SelectedIndex
                '    With attrData.TotalData.TotalMode.Series.DataSet(ix)
                '        If .DataItem.Count > 0 Then
                '            With .DataItem(attrData.TempData.Series_temp.Koma)
                '                Select Case .Print_Mode_Total
                '                    Case enmTotalMode_Number.DataViewMode
                '                        Select Case .Print_Mode_Layer
                '                            Case enmLayerMode_Number.SoloMode, enmLayerMode_Number.GraphMode, enmLayerMode_Number.LabelMode
                '                                OnObject = NearestObject(MapP, .Layer)
                '                            Case enmLayerMode_Number.TripMode
                '                        End Select
                '                        Select Case OnObject.Count
                '                            Case 0
                '                                frm_Property.pnlProperty.Visible = False
                '                            Case 1
                '                                If mnuPropertyWindow.Checked = True And temp_data.PrintMouseMode = enmPrintMouseMode.Normal Then
                '                                    frm_Property.ShowOneObjectProperty(attrData, OnObject(0).objLayer, OnObject(0).ObjNumber, .Data, .Print_Mode_Layer)
                '                                End If
                '                            Case 2

                '                        End Select
                '                    Case enmTotalMode_Number.OverLayMode
                '                        Get_Object_By_XY_OverLayMode(MapP, .Data)
                '                        OnObject = New List(Of strLocationSearchObject)
                '                End Select

                '            End With
                '            Dim tx As String = ""
                '            For i As Integer = 0 To OnObject.Count - 1
                '                Dim lay As Integer = OnObject(i).objLayer
                '                Dim datanum As Integer = attrData.LayerData(lay).atrData.SelectedIndex
                '                Dim onum As Integer = OnObject(i).ObjNumber
                '                tx += attrData.Get_KenObjName(lay, onum) + "［" + attrData.Get_Data_Value(lay, datanum, onum, "欠損値") + "］"
                '                If i <> OnObject.Count - 1 Then
                '                    tx += "／"
                '                End If
                '            Next
                '            StatusLabel2.Text = tx
                '        End If
                '    End With
                'temp_data.OnObject = OnObject
        End Select

        Select Case temp_data.PrintMouseMode
            Case enmPrintMouseMode.Normal
                PrintCursorObjectLine(False)
            Case enmPrintMouseMode.MultiObjectSelect
        End Select

        'リンク先の表示
        Dim urlTx As String = ""
        If temp_data.OnObject.Count = 1 Then
            If attrData.LayerData(temp_data.OnObject(0).objLayer).Type <> clsAttrData.enmLayerType.Trip Then
                With attrData.LayerData(temp_data.OnObject(0).objLayer).atrObject.atrObjectData(temp_data.OnObject(0).ObjNumber)
                    If .HyperLinkNum > 0 Then
                        urlTx += "【リンク】"
                    End If
                    For i As Integer = 0 To .HyperLinkNum - 1
                        urlTx += .HyperLink(i).Name
                        If i <> .HyperLinkNum - 1 Then
                            urlTx += "／"
                        End If
                    Next
                End With
            End If
        Else
        End If
        StatusLabel3.Text = urlTx


        If temp_data.PrintMouseMode = enmPrintMouseMode.Normal Then
            frm_Property.Fixed(temp_data.Location_Fixed_F)
        End If
    End Sub
    ''' <summary>
    ''' 等値線の位置とカーソルチェック
    ''' </summary>
    ''' <param name="ScreenP"></param>
    ''' <remarks></remarks>
    Private Sub LocationContourSearch(ByVal ScreenP As Point)
        '
        Dim MapP As PointF = attrData.TotalData.ViewStyle.ScrData.getSRXY(ScreenP)
        Dim tx4 As String = ""
        If temp_data.PrintMouseMode = enmPrintMouseMode.Normal Then
            Me.temp_data.LocationMenuString.ContourStacPos = -1
            If Check_Contour_in() = True Then
                Dim c As Integer = Near_Contour(MapP)

                If c <> -1 Then
                    Me.temp_data.LocationMenuString.ContourStacPos = c
                    With attrData.TempData.ContourMode_Temp.Contour_Object(c)
                        tx4 = "等値線" + .Value.ToString + attrData.Get_DataUnit(.Layernum, .DataNum)
                    End With
                End If
            End If
            StatusLabel4.Text = tx4
        End If


    End Sub

    ''' <summary>
    ''' '線モードのラインの移動
    ''' </summary>
    ''' <param name="ScreenP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function LocationODSearch(ByVal ScreenP As Point) As Boolean

        Dim MapP As PointF = attrData.TotalData.ViewStyle.ScrData.getSRXY(ScreenP)
        Dim odc As Integer = Near_OD(MapP)
        If odc <> -1 Then
            Dim tx4 As String = "OD" & attrData.Get_KenObjName(attrData.TotalData.LV1.SelectedLayer, odc)
            StatusLabel4.Text = tx4
            temp_data.PrintMouseMode = enmPrintMouseMode.od
            Return True
        Else
            temp_data.PrintMouseMode = enmPrintMouseMode.Normal
            Return False
        End If

    End Function

    ''' <summary>
    ''' カーソル位置のオブジェクトを強調
    ''' </summary>
    ''' <param name="Draw_F">ちらつき防止チェックをしない場合true</param>
    ''' <remarks></remarks>
    Private Sub PrintCursorObjectLine(ByVal Draw_F As Boolean)
        Dim OnObject As List(Of strLocationSearchObject) = temp_data.OnObject
        Static OldObject As New List(Of strLocationSearchObject)
        If OnObject Is Nothing = False Then
            If OnObject.Count = 0 Then
                If OldObject.Count > 0 Then
                    picMap.Refresh()
                End If
                OldObject = OnObject
                Return
            End If
            If OnObject.Count = OldObject.Count And Draw_F = False Then
                'ちらつき防止のため、描画済みの場合は再描画しない
                Dim f As Boolean = False
                For i As Integer = 0 To OnObject.Count - 1
                    For j As Integer = 0 To OldObject.Count - 1
                        If OnObject(i).ObjNumber <> OldObject(j).ObjNumber Or OnObject(i).objLayer <> OldObject(j).objLayer Then
                            i = OnObject.Count
                            f = True
                            Exit For
                        End If
                    Next
                Next
                If f = False Then
                    Return
                End If
            End If
            picMap.Refresh()
            OldObject = OnObject

            Dim g As Graphics = picMap.CreateGraphics
            For Each Obj In OnObject
                printSelectedObject(g, Obj.objLayer, Obj.ObjNumber)
            Next
            g.Dispose()
        End If
    End Sub
    ''' <summary>
    ''' 複数選択オブジェクトの表示/Paintイベントを発生させて描画
    ''' </summary>
    '''  <remarks></remarks>
    Private Sub printSeletedMultiObject()
        temp_data.MultiObjectSelectShowFlag = True
        picMap.Refresh()
        temp_data.MultiObjectSelectShowFlag = False

    End Sub
    ''' <summary>
    ''' 選択したオブジェクトの表示
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="ObjNum"></param>
    ''' <remarks></remarks>
    Private Sub printSelectedObject(ByRef g As Graphics, ByVal LayerNum As Integer, ByVal ObjNum As Integer)

        Dim sp As enmShape = attrData.LayerData(LayerNum).Shape
        Select Case sp
            Case enmShape.PointShape
                Dim CP As PointF = attrData.LayerData(LayerNum).atrObject.atrObjectData(ObjNum).Symbol
                Dim OP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(CP)
                Dim Mk As Mark_Property = clsBase.Mark
                Mk.Tile.TileCode = enmTilePattern.Paint
                Mk.Tile.Line.BasicLine.SolidLine.Color = New colorARGB(150, 255, 0, 150)
                attrData.Draw_Mark(g, OP, 10, Mk)
            Case enmShape.PolygonShape, enmShape.LineShape
                Dim w As Single = 3
                If sp = enmShape.LineShape Then
                    w = 5
                End If
                If attrData.LayerData(LayerNum).Type = clsAttrData.enmLayerType.Mesh Then
                    Dim meshP() As PointF = attrData.LayerData(LayerNum).atrObject.atrObjectData(ObjNum).MeshPoint
                    ReDim Preserve meshP(4)
                    meshP(4) = meshP(0)
                    Dim pxy() As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(5, meshP, False)
                    g.DrawLines(New Pen(Color.FromArgb(200, 255, 0, 150), 3), pxy)
                Else
                    Dim ELine() As clsMapData.EnableMPLine_Data
                    Dim n As Integer = attrData.Get_Enable_KenCode_MPLine(ELine, LayerNum, ObjNum)
                    Dim pen As New Pen(Color.FromArgb(150, 255, 0, 150), w)
                    pen.LineJoin = Drawing2D.LineJoin.Round
                    For j As Integer = 0 To n - 1
                        Dim pxy() As Point
                        Dim np As Integer = clsPrintMap.Get_PointXY_by_LineCode(attrData, LayerNum, ELine(j).LineCode, pxy)
                        If np <> 0 Then
                            g.DrawLines(pen, pxy)
                        End If
                    Next
                End If
        End Select

    End Sub
    ''' <summary>
    ''' 重ね合わせモードの位置情報
    ''' </summary>
    ''' <param name="MapP"></param>
    ''' <param name="OverLayIndex"></param>
    ''' <remarks></remarks>
    Private Sub Get_Object_By_XY_OverLayMode(ByVal MapP As PointF, ByVal OverLayIndex As Integer)

        Dim tx As String = ""
        Dim f As Boolean = False
        temp_data.OnObject = New List(Of strLocationSearchObject)
        With attrData.TotalData.TotalMode.OverLay
            Dim lblTxt As String = ""
            For i As Integer = .DataSet(OverLayIndex).DataItem.Count - 1 To 0 Step -1
                With .DataSet(OverLayIndex).DataItem(i)
                    If .Print_Mode_Layer <> enmLayerMode_Number.TripMode Then
                        If .TileMapf = False Then
                            Dim OnObject As List(Of strLocationSearchObject) = NearestObject(MapP, .Layer)
                            For j As Integer = 0 To OnObject.Count - 1
                                Dim ObjData As strLocationSearchObject = OnObject.Item(j)
                                lblTxt += "レイヤ：" + attrData.Get_LayerName(ObjData.objLayer) + vbCrLf
                                lblTxt += "オブジェクト：" + attrData.Get_KenObjName(ObjData.objLayer, ObjData.ObjNumber) + vbCrLf
                                If f = True Then
                                    tx += "／"
                                Else
                                    f = True
                                End If
                                tx += attrData.Get_KenObjName(ObjData.objLayer, ObjData.ObjNumber)
                                Select Case .Print_Mode_Layer
                                    Case enmLayerMode_Number.SoloMode
                                        lblTxt += "　" + getOneObjectPanelLabelString(ObjData.objLayer, .DataNumber, ObjData.ObjNumber) + vbCrLf
                                    Case enmLayerMode_Number.GraphMode
                                        lblTxt += "　グラフ表示モード" + vbCrLf
                                    Case enmLayerMode_Number.LabelMode
                                        lblTxt += "　ラベル表示モード" + vbCrLf
                                    Case enmLayerMode_Number.TripMode
                                        lblTxt += "　移動表示モード" + vbCrLf
                                End Select
                                lblTxt += vbCrLf
                                temp_data.OnObject.Add(ObjData)
                            Next
                        End If
                    End If
                End With
            Next
            If mnuPropertyWindow.Checked = True Then
                frm_Property.ShowOverLayObjectProperty(lblTxt)
            End If

            If lblTxt = "" Then
                frm_Property.pnlOverLayProperty.Visible = False
            End If
        End With
        StatusLabel2.Text = tx

    End Sub
    Private Function getOneObjectPanelLabelString(ByVal LayerNum As Integer, ByVal DataNumber As Integer, ByVal objNumber As Integer) As String
        Dim SoloProperty As String = attrData.Get_DataTitle(LayerNum, DataNumber, False) + vbCrLf +
        " " + attrData.Get_Data_Value(LayerNum, DataNumber, objNumber, attrData.TotalData.ViewStyle.Missing_Data.Text) +
        attrData.Get_DataUnit_With_Kakko(LayerNum, DataNumber)
        Dim inData As Integer = -1
        With attrData.LayerData(LayerNum)
            Select Case .atrData.Data(DataNumber).ModeData
                Case enmSoloMode_Number.ClassMarkMode
                    If .atrData.Data(DataNumber).SoloModeViewSettings.ClassMarkMD.Flag = True Then
                        inData = .atrData.Data(DataNumber).SoloModeViewSettings.ClassMarkMD.Data
                    End If
                Case enmSoloMode_Number.MarkSizeMode, enmSoloMode_Number.MarkBlockMode, enmSoloMode_Number.MarkTurnMode, enmSoloMode_Number.MarkBarMode
                    If .atrData.Data(DataNumber).SoloModeViewSettings.MarkCommon.Inner_Data.Flag = True Then
                        inData = .atrData.Data(DataNumber).SoloModeViewSettings.MarkCommon.Inner_Data.Data
                    End If
            End Select
        End With
        If inData <> -1 Then
            '内部データの値
            SoloProperty += vbCrLf + attrData.Get_DataTitle(LayerNum, inData, False) + vbCrLf +
               " " + attrData.Get_Data_Value(LayerNum, inData, objNumber, attrData.TotalData.ViewStyle.Missing_Data.Text) +
                attrData.Get_DataUnit_With_Kakko(LayerNum, inData)
        End If
        Return SoloProperty
    End Function
    ''' <summary>
    ''' 一番近いオブジェクトを探して数とオブジェクト番号を返す
    ''' </summary>
    ''' <param name="MapP"></param>
    ''' <param name="Layernum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function NearestObject(ByVal MapP As PointF, ByVal Layernum As Integer) As List(Of strLocationSearchObject)

        Dim OBCode() As Integer, Pnum() As Integer, OBTag() As Integer
        Dim OnObject As New List(Of strLocationSearchObject)

        If attrData.LayerData(Layernum).Type = clsAttrData.enmLayerType.Trip Then
            '移動レイヤ
            Dim cp As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(MapP)
            Dim mind As Single = 10
            For i As Integer = 0 To attrData.TempData.Trip_Temp.Trip_Print_XY.Length - 1
                With attrData.TempData.Trip_Temp.Trip_Print_XY(i)
                    Dim nearP As PointF
                    Dim D As Single
                    If .Trip_F = True Then
                        D = spatial.Distance_PointLine(cp, .TripP1, .TripP2, nearP)
                    ElseIf .Stay_F = True Then
                        D = spatial.get_Distance(cp, .StayP1)
                    End If
                    If D <= mind Then
                        mind = D
                        If D < mind Then
                            OnObject.Clear()
                        End If
                        Dim ObjData As strLocationSearchObject
                        ObjData.ObjNumber = .Number
                        ObjData.objLayer = Layernum
                        OnObject.Add(ObjData)
                    End If
                End With
            Next
        Else
            Select Case attrData.LayerData(Layernum).Shape

                Case enmShape.PolygonShape
                    Dim n As Integer = attrData.LayerData(Layernum).PrtSpatialIndex.GetRectIn(MapP.X, MapP.Y, OBCode, OBTag)
                    If n > 0 Then
                        For i As Integer = 0 To n - 1
                            If attrData.TempData.ObjectPrintedCheckFlag(Layernum)(OBTag(i)) = True Then
                                If attrData.Check_Point_in_Kencode_OneObject(Layernum, OBTag(i), MapP) = True Then
                                    Dim ObjData As strLocationSearchObject
                                    ObjData.ObjNumber = OBTag(i)
                                    ObjData.objLayer = Layernum
                                    OnObject.Add(ObjData)
                                End If
                            End If
                        Next
                    End If
                Case Else
                    Dim n As Integer
                    Dim mind As Single = 10 / attrData.TotalData.ViewStyle.ScrData.ScreenMG.Mul
                    If attrData.LayerData(Layernum).Shape = enmShape.PointShape Then
                        Dim dis() As Single
                        n = attrData.LayerData(Layernum).PrtSpatialIndex.GetNearPointNumber(MapP.X, MapP.Y, mind, OBCode, Pnum, OBTag, dis)
                    Else
                        n = attrData.LayerData(Layernum).PrtSpatialIndex.GetNearestLineNumber(MapP.X, MapP.Y, mind, OBCode, Pnum, OBTag)
                    End If
                    If n > 0 Then
                        Dim serarchNCount As Integer = 0
                        For i As Integer = 0 To n - 1
                            If attrData.TempData.ObjectPrintedCheckFlag(Layernum)(OBTag(i)) = True Then
                                Dim ObjData As strLocationSearchObject
                                ObjData.ObjNumber = OBTag(i)
                                ObjData.objLayer = Layernum
                                OnObject.Add(ObjData)
                                serarchNCount += 1
                                If serarchNCount = 5 Then '候補は最大で5つ
                                    Exit For
                                End If
                            End If
                        Next

                    End If

            End Select
        End If

        Return OnObject


    End Function
    ''' <summary>
    ''' 地図上をカーソルが移動した場合に座標情報を表示
    ''' </summary>
    ''' <param name="MousePosition">画面座標</param>
    ''' <remarks></remarks>
    Private Sub picMapMouseMovePointInformation(ByVal MousePosition As Point)
        Dim originalP As PointF = attrData.TotalData.ViewStyle.ScrData.getSRXY(MousePosition)
        Dim MapZahyo As clsMapData.Zahyo_info = attrData.TotalData.ViewStyle.Zahyo
        If spatial.Check_PsitionReverse_Enable(originalP, MapZahyo) = True Then
            Dim P As PointF = spatial.Get_Reverse_XY(originalP, MapZahyo)
            Dim PSt As strPointStrings = clsGeneric.Get_PositionCoordinate_Strings(P, MapZahyo)
            StatusLabel.Text = PSt.x + "/" + PSt.y
        Else
            StatusLabel.Text = ""
        End If
    End Sub

    Private Sub mnuCopy_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        'Metafileオブジェクトを作成する
        Dim bmp As New Bitmap(10, 10)
        Dim bmpg As Graphics = Graphics.FromImage(bmp)
        Dim hdc As IntPtr = bmpg.GetHdc()
        Dim rec As New Rectangle(0, 0, picMap.Width, picMap.Height)
        Dim meta As New System.Drawing.Imaging.Metafile(hdc, rec,
                            Imaging.MetafileFrameUnit.Pixel, System.Drawing.Imaging.EmfType.EmfPlusOnly)
        bmpg.ReleaseHdc(hdc)


        'Metafileに描画する
        Dim emfg As Graphics = Graphics.FromImage(meta)
        Dim prog As ToolStripProgressBar = Me.ProgressBar
        If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.SeriesMode Then
            Series_Mapping(emfg, prog, False)
        Else
            printMap(emfg, prog)
        End If
        emfg.Dispose()

        Dim f As Boolean
        'クリップボードに保存
        f = clsEMFMetafileCopy.PutEnhMetafileOnClipboard(Me.Handle, meta)
        '後片付け
        meta.Dispose()
        bmpg.Dispose()
        bmp.Dispose()

    End Sub
    Private Sub frmPrint_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Or (oldWindowState = FormWindowState.Maximized And Me.WindowState = FormWindowState.Normal) Then
            reDraw()
        End If
        oldWindowState = Me.WindowState
    End Sub
    Private Sub reDraw()
        If Me.Visible = True Then
            With attrData.TotalData.ViewStyle.ScrData.frmPrint_FormSize
                .X = Me.Left
                .Y = Me.Top
                If .Width <> Me.picMap.Width Or .Height <> Me.picMap.Height Then
                    If Me.picMap.Width <> 0 Then
                        .Width = Me.picMap.Width
                        .Height = Me.picMap.Height
                        printMapScreen(False)
                        Select Case temp_data.PrintMouseMode
                            Case enmPrintMouseMode.Fig
                                frm_Figure.Print_Fig()
                            Case enmPrintMouseMode.Normal
                                PrintCursorObjectLine(True)
                            Case enmPrintMouseMode.MultiObjectSelect
                                printSeletedMultiObject()
                        End Select
                        If mnuSet3d.Checked = True Then
                            Frm_Set3d.SetWorldXY_3DpicSize()
                        End If
                    End If
                End If
            End With
        End If
    End Sub
    Private Sub frmPrint_ResizeEnd(sender As Object, e As System.EventArgs) Handles MyBase.ResizeEnd

        If Me.WindowState <> FormWindowState.Minimized Then

            reDraw()
        End If

    End Sub

    Private Sub mnuPrintOut_Click(sender As Object, e As EventArgs) Handles mnuPrintOut.Click


        Dim form As New frmPrint_PrintOut
        If form.ShowDialog(Me, attrData, picMap, PrinterDoc) = Windows.Forms.DialogResult.OK Then
            With attrData.TotalData.ViewStyle.ScrData.PrinterMG
                form.getResults(.Mul, .Xplus, .YPlus)
            End With
            attrData.TotalData.ViewStyle.ScrData.OutputDevide = enmOutputDevice.Printer
            PrinterDoc.Print()
            attrData.TotalData.ViewStyle.ScrData.OutputDevide = enmOutputDevice.Screen
        End If
        form.Dispose()
    End Sub
    Private SeriesModeButton() As ToolStripControlHost
    Private BackImageButton As ToolStripControlHost
    Private BackImageLegendButton As ToolStripControlHost
    Private ShowAllButton As ToolStripControlHost
    Private ValueShowButton As ToolStripControlHost
    Private frm_Property As New frmPrint_Property
    Private frm_Figure As New frmPrint_Figure
    ''' <summary>
    ''' Loadイベントが画面表示までに実行されないため、new frmprint後にfrmprint.pre_loadを行う
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Pre_load()
        AddHandler PrinterDoc.PrintPage, AddressOf PrinterDoc_PrintPage
        ReDim SeriesModeButton(1)
        For i As Integer = 0 To 1
            SeriesModeButton(i) = New ToolStripControlHost(New Button)
            SeriesModeButton(i).Width = 40
            SeriesModeButton(i).Alignment = ToolStripItemAlignment.Right
            SeriesModeButton(i).Tag = i
            AddHandler SeriesModeButton(i).Click, AddressOf SeriesModeButtonClick
            StatusStrip.Items.Add(SeriesModeButton(i))
        Next
        SeriesModeButton(0).Text = "→"
        SeriesModeButton(1).Text = "←"

        BackImageLegendButton = New ToolStripControlHost(New Button)
        BackImageLegendButton.Width = 50
        BackImageLegendButton.Text = "背景凡例"
        AddHandler BackImageLegendButton.Click, AddressOf BackImageLegendButton_Click
        BackImageLegendButton.Alignment = ToolStripItemAlignment.Right
        StatusStrip.Items.Add(BackImageLegendButton)

        BackImageButton = New ToolStripControlHost(New Button)
        BackImageButton.Width = 50
        BackImageButton.Text = "背景表示"
        AddHandler BackImageButton.Click, AddressOf BackImageButton_Click
        BackImageButton.Alignment = ToolStripItemAlignment.Right
        StatusStrip.Items.Add(BackImageButton)

        ShowAllButton = New ToolStripControlHost(New Button)
        ShowAllButton.Width = 50
        ShowAllButton.Text = "全体表示"
        AddHandler ShowAllButton.Click, AddressOf ShowAllButtonClick
        StatusStrip.Items.Add(ShowAllButton)
        ShowAllButton.Alignment = ToolStripItemAlignment.Right

        ValueShowButton = New ToolStripControlHost(New Button)
        ValueShowButton.Width = 50
        ValueShowButton.Text = "データ値表示"
        AddHandler ValueShowButton.Click, AddressOf ValueShowButtonClick
        ValueShowButton.Alignment = ToolStripItemAlignment.Right
        StatusStrip.Items.Add(ValueShowButton)


        frm_Property.Owner = Me
        frm_Figure.Owner = Me
        mnuPropertyWindow.Checked = clsSettings.Data.Print_PropertyWindow

        StatusLabel.Text = ""
        StatusLabel2.Text = ""
        StatusLabel3.Text = ""
        StatusLabel4.Text = ""
        Me.ProgressBar.Visible = False

    End Sub
    ''' <summary>
    ''' 背景凡例ボタン
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BackImageLegendButton_Click()
        If attrData.TotalData.ViewStyle.TileMapView.ViewData.TileMapDataSet.LegendURL = "" Then

            MsgBox("凡例URLが設定されていません。", MsgBoxStyle.Exclamation)
        Else
            Dim tilemapdata As strTileMapData_Info = attrData.TotalData.ViewStyle.TileMapView.ViewData.TileMapDataSet
            Dim filename As String = System.IO.Path.GetFileName(tilemapdata.LegendURL)
            Dim extension As String = System.IO.Path.GetExtension(filename)
            If extension = ".html" Or extension = ".htm" Then
                System.Diagnostics.Process.Start(tilemapdata.LegendURL)
            Else
                Dim saveFile As String = attrData.TileMap.gettmpFolderName + "\" + filename
                Dim f As Boolean = clsGeneric.UrlToFile(tilemapdata.LegendURL, saveFile, True)
                If f = True Then
                    System.Diagnostics.Process.Start(saveFile)
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' データ値表示ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ValueShowButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim form As New frmPrint_ObjectValue
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            attrData.TotalData.ViewStyle.ValueShow = form.GetResults()
            printMapScreen(True)
        End If
        form.Dispose()

    End Sub

    ''' <summary>
    ''' 連続表示モード移動ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SeriesModeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer = attrData.TotalData.TotalMode.Series.SelectedIndex
        With attrData.TempData.Series_temp
            If sender.tag = 0 Then
                .Koma += 1
                If .Koma >= attrData.TotalData.TotalMode.Series.DataSet(i).DataItem.Count Then
                    .Koma = 0
                End If
            Else
                .Koma -= 1
                If .Koma < 0 Then
                    .Koma = attrData.TotalData.TotalMode.Series.DataSet(i).DataItem.Count - 1
                End If
            End If
            printMapScreen(True)
        End With
    End Sub
    ''' <summary>
    ''' 全体表示ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShowAllButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With attrData.TotalData.ViewStyle.ScrData
            .ScrView = .MapRectangle
        End With
        printMapScreen(True)
    End Sub
    ''' <summary>
    ''' 背景表示ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BackImageButton_Click(sender As Object, e As EventArgs) Handles mnuBackImage.Click
        With attrData.TotalData.ViewStyle
            If .TileMapView.Visible = True And sender.name <> "mnuBackImage" Then
                .TileMapView.Visible = False
                printMapScreen(True)
                BackImageLegendButton.Enabled = False
            Else
                Dim form = New frmTileMapServiceSelect
                With .TileMapView
                    .Visible = True
                    If form.ShowDialog(Me, .ViewData, .Visible, .DrawTiming, attrData.TileMap) = DialogResult.OK Then
                        form.getResult(.ViewData, .Visible, .DrawTiming)
                        printMapScreen(True)
                        If .ViewData.TileMapDataSet.Name = "ユーザー定義" Or .ViewData.TileMapDataSet.Name = "ワールドファイル" Then
                            BackImageLegendButton.Enabled = False
                        Else
                            BackImageLegendButton.Enabled = True
                        End If
                    Else
                        .Visible = False
                        BackImageLegendButton.Enabled = False
                    End If
                End With
                form.Dispose()
            End If
        End With
    End Sub

    Private Sub PrinterDoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        e.Graphics.PageUnit = GraphicsUnit.Pixel

        Dim prog As ToolStripProgressBar = Me.ProgressBar
        printMap(g, prog)
        'リソースを解放する
        e.HasMorePages = False
        g.Dispose()
    End Sub

    Private Sub mnuCopyAsBitmap_Click(sender As Object, e As EventArgs) Handles mnuCopyAsBitmap.Click
        Dim bmp As New Bitmap(picMap.Width, picMap.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.FillRectangle(New SolidBrush(Color.White), New Rectangle(New Point(0, 0), bmp.Size))
        g.DrawImage(picMap.Image, New Point(0, 0))
        Clipboard.SetDataObject(bmp)
        'bmp.Dispose()・・・これをやると貼り付けられない
        g.Dispose()
    End Sub

    Private Sub frmPrint_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        clsSettings.Data.Print_PropertyWindow = mnuPropertyWindow.Checked
        frm_Property.Dispose()
        frm_Figure.Dispose()
        ownerForm.Focus()
    End Sub


    Private Sub mnuSet3d_Click(sender As Object, e As EventArgs) Handles mnuSet3d.Click
        If mnuSet3d.Checked = True Then
            If Frm_Set3d.IsDisposed = True Then
                Frm_Set3d = New frmPrint_3DSettings
            End If
            Dim prop As Boolean = mnuPropertyWindow.Checked
            If prop = True Then
                mnuPropertyWindow.Checked = False
                frm_Property.Visible = False
            End If
            Frm_Set3d.Show(Me)
            Frm_Set3d.Set_Data(attrData, prop)
        Else
            Frm_Set3d.Close()
        End If
    End Sub


    Private Sub mnuPropertyWindow_CheckedChanged(sender As Object, e As EventArgs) Handles mnuPropertyWindow.CheckedChanged
        If Me.Visible = False Then
            Return
        End If
        If frm_Property.IsDisposed = True Then
            frm_Property = New frmPrint_Property
            frm_Property.Owner = Me
        End If
        frm_Property.Owner = Me
        frm_Property.Visible = mnuPropertyWindow.Checked
        If mnuPropertyWindow.Checked = False Then

            temp_data.Location_Fixed_F = False
        End If
    End Sub
    ''' <summary>
    ''' 等値線モードが表示されているかチェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_Contour_in() As Boolean

        Dim f As Boolean = False
        Select Case attrData.TotalData.LV1.Print_Mode_Total
            Case enmTotalMode_Number.DataViewMode
                Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
                If attrData.LayerData(Layernum).atrData.Count > 0 Then
                    Dim DataNum As Integer = attrData.LayerData(Layernum).atrData.SelectedIndex
                    If attrData.SoloMode(Layernum, DataNum) = enmSoloMode_Number.ContourMode Then
                        Return True
                    End If
                End If
            Case enmTotalMode_Number.OverLayMode
                With attrData.TotalData.TotalMode.OverLay
                    With .DataSet(.SelectedIndex)
                        For i As Integer = 0 To .DataItem.Count - 1
                            With .DataItem(i)
                                If .Print_Mode_Layer = enmLayerMode_Number.SoloMode And .Mode = enmSoloMode_Number.ContourMode Then
                                    Return True
                                End If
                            End With
                        Next
                    End With
                End With
        End Select
        Return False
    End Function
    ''' <summary>
    ''' 最寄りの等値線取得
    ''' </summary>
    ''' <param name="MapP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Near_Contour(ByVal MapP As PointF) As Integer
        Dim Near_ContourNumber As Integer = -1
        Dim mind As Single = 5
        With attrData.TempData.ContourMode_Temp
            For i As Integer = 0 To .Contour_All_Number - 1
                With .Contour_Object(i)
                    If .Flag = True And spatial.Check_PointInBox(MapP.X, MapP.Y, 0, .Circumscribed_Rectangle) = True Then
                        For j As Integer = .PointStac To .PointStac + .NumOfPoint - 2
                            Dim D As Single
                            With attrData.TempData.ContourMode_Temp
                                Dim np As PointF
                                D = spatial.Distance_PointLine(MapP, .Contour_Point(j), .Contour_Point(j + 1), np) * attrData.TotalData.ViewStyle.ScrData.ScreenMG.Mul
                            End With
                            If D < mind Then
                                mind = D
                                Near_ContourNumber = i
                            End If
                        Next
                    End If
                End With
            Next
        End With
        Return Near_ContourNumber
    End Function
    ''' <summary>
    ''' 線モードの最寄りラインを求める
    ''' </summary>
    ''' <param name="MapP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Near_OD(ByVal MapP As PointF) As Integer

        Dim Near_ODNumber As Integer = -1
        Select Case attrData.TotalData.LV1.Print_Mode_Total
            Case enmTotalMode_Number.DataViewMode
                Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
                Dim DataNum As Integer = attrData.LayerData(Layernum).atrData.SelectedIndex
                If attrData.LayerData(Layernum).Print_Mode_Layer = enmLayerMode_Number.SoloMode Then
                    If attrData.SoloMode(Layernum, DataNum) = enmSoloMode_Number.ClassODMode And
                              attrData.LayerData(Layernum).Shape <> enmShape.LineShape And attrData.LayerData(Layernum).Type <> clsAttrData.enmLayerType.Trip Then
                        Near_ODNumber = Near_OD_sub(MapP, Layernum, DataNum)
                    End If
                End If
            Case enmTotalMode_Number.OverLayMode
                With attrData.TotalData.TotalMode.OverLay.DataSet(attrData.TotalData.TotalMode.OverLay.SelectedIndex)
                    For i As Integer = .DataItem.Count - 1 To 0 Step -1
                        With .DataItem(i)
                            Dim Layernum As Integer = .Layer
                            Dim DataNum As Integer = .DataNumber
                            If .Print_Mode_Layer = enmLayerMode_Number.SoloMode And .Mode = enmSoloMode_Number.ClassODMode And
                                    attrData.LayerData(Layernum).Shape <> enmShape.LineShape Then
                                Near_ODNumber = Near_OD_sub(MapP, Layernum, DataNum)
                                If Near_ODNumber <> -1 Then
                                    Exit For
                                End If
                            End If
                        End With
                    Next
                End With
        End Select
        Return Near_ODNumber
    End Function
    ''' <summary>
    '''  線モードの最寄りラインを求めるSub
    ''' </summary>
    ''' <param name="MapP"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Near_OD_sub(ByVal MapP As PointF, ByVal Layernum As Integer, ByVal DataNum As Integer) As Long


        With attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.ClassODMD
            Dim StartP As PointF
            Dim EndP As PointF
            Dim objn As Integer = attrData.LayerData(Layernum).atrObject.ObjectNum
            Dim origin_objn As Integer = attrData.LayerData(.o_Layer).atrObject.ObjectNum
            If .O_object > origin_objn Then
                'ダミーオブジェクトが始点の場合
                Dim Dob As Integer = attrData.LayerData(.o_Layer).Dummy.DummyObj(.O_object - origin_objn).code
                attrData.LayerData(Layernum).MapFileData.Get_Enable_CenterP(StartP, Dob, attrData.LayerData(.o_Layer).Time)
            Else
                StartP = attrData.LayerData(.o_Layer).atrObject.atrObjectData(.O_object).CenterPoint
            End If

            Dim mind As Single = 5
            Dim Category_Array() As Integer = attrData.Get_Categoly(Layernum, DataNum)
            Dim Near_Obj As Integer = -1
            For i As Integer = 0 To objn - 1
                EndP = attrData.LayerData(Layernum).atrObject.atrObjectData(i).CenterPoint
                Dim Cate As Integer = Category_Array(i)
                If Cate <> -1 Then
                    Dim D As Single
                    Dim nearP As PointF
                    If (i = .O_object And Layernum = .o_Layer) Or
                        (attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.Class_Div(Cate).ODLinePat.Check_Line_PrintPattern = True And
                         attrData.Check_Missing_Value(Layernum, DataNum, i) = False) Then
                        Dim ControlP As PointF
                        Dim SplineF As Boolean = attrData.LayerData(Layernum).Get_OD_Bezier_RefPoint(i, DataNum, ControlP)
                        If SplineF = False Then
                            D = spatial.Distance_PointLine(MapP, StartP, EndP, nearP)
                        Else
                            Dim Refp() As PointF = clsGeneric.Get_OD_Spline_Point(ControlP, StartP, EndP)
                            Dim d1 As Single = spatial.Distance_PointLine(MapP, StartP, Refp(2), nearP)
                            Dim d2 As Single = spatial.Distance_PointLine(MapP, Refp(1), Refp(2), nearP)
                            Dim d3 As Single = spatial.Distance_PointLine(MapP, EndP, Refp(1), nearP)
                            D = Math.Min(d1, d2)
                            D = Math.Min(D, d3)
                        End If
                        D *= attrData.TotalData.ViewStyle.ScrData.ScreenMG.Mul
                        If D < mind Then
                            mind = D
                            Near_Obj = i
                            With temp_data.OD_Drag
                                .ObjectPos = Near_Obj
                                .Data = DataNum
                            End With
                        End If
                    End If
                End If
            Next
            Return Near_Obj
        End With
    End Function
    ''' <summary>
    ''' ドラッグで移動中のOD曲線を描く
    ''' </summary>
    ''' <param name="P"></param>
    ''' <remarks></remarks>
    Private Sub OD_Line_Print(ByVal P As PointF)


        Dim DataNum As Integer, ObNum As Integer
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        With temp_data.OD_Drag
            DataNum = .Data
            ObNum = .ObjectPos
        End With

        Dim OriginP As PointF
        Dim DestP As PointF
        With attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.ClassODMD
            Dim origin_objn As Integer = attrData.LayerData(.o_Layer).atrObject.ObjectNum
            If .O_object > origin_objn Then
                'ダミーオブジェクトが始点の場合
                Dim Dob As Integer = attrData.LayerData(.o_Layer).Dummy.DummyObj(.O_object - origin_objn).code
                attrData.LayerData(Layernum).MapFileData.Get_Enable_CenterP(OriginP, Dob, attrData.LayerData(.o_Layer).Time)
            Else
                OriginP = attrData.LayerData(.o_Layer).atrObject.atrObjectData(.O_object).CenterPoint
            End If
        End With
        DestP = attrData.LayerData(Layernum).atrObject.atrObjectData(ObNum).CenterPoint
        Dim poxy() As PointF = clsGeneric.Get_OD_Spline_Point(P, OriginP, DestP)

        Dim ln As Integer = 4
        Dim pxy() As Point = clsSpline.Spline_Get(0, ln, poxy, 0.1, attrData.TotalData.ViewStyle.ScrData)

        Dim Cate As Integer = attrData.Get_Categoly(Layernum, DataNum, ObNum)
        Dim O_LPat As Line_Property = attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.Class_Div(Cate).ODLinePat
        O_LPat.Set_Same_Color_to_LinePat(New colorARGB(Color.Red))
        Dim g As Graphics = picMap.CreateGraphics
        picMap.Refresh()
        attrData.Draw_Line(g, O_LPat, ln, pxy)

    End Sub
    ''' <summary>
    ''' 飾り位置チェック
    ''' </summary>
    ''' <param name="ScreenP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Private Function Check_Acc(ByVal ScreenP As Point) As Check_Acc_Result
        '------タイトル位置
        With attrData.TotalData.ViewStyle
            Dim threed As strThreeDMode_Set = .ScrData.ThreeDMode
            If .MapTitle.Visible = True Then
                Dim Acc_Rect As Rectangle = attrData.TempData.Accessory_Temp.MapTitle_Rect
                If spatial.Check_PointInBox(ScreenP, .MapTitle.Font.Body.Kakudo, Acc_Rect) = True Then
                    attrData.TempData.Accessory_Temp.Push_titleXY = .MapTitle.Position
                    Return Check_Acc_Result.Title
                End If
            End If
            '------方位
            If .AttMapCompass.Visible = True And (.ScrData.ThreeDMode.Set3D_F = False Or (threed.Pitch = 0 And threed.Head = 0)) Then
                Dim Acc_Rect As Rectangle = attrData.TempData.Accessory_Temp.MapCompass_Rect
                If spatial.Check_PointInBox(ScreenP, 0, Acc_Rect) = True Then
                    attrData.TempData.Accessory_Temp.Push_CompassXY = .AttMapCompass.Position
                    Return Check_Acc_Result.Compass
                End If
            End If
            '------スケール
            If .MapScale.Visible = True And (.ScrData.ThreeDMode.Set3D_F = False Or (threed.Pitch = 0 And threed.Head = 0)) Then
                Dim Acc_Rect As Rectangle = attrData.TempData.Accessory_Temp.MapScale_Rect
                If spatial.Check_PointInBox(ScreenP, 0, Acc_Rect) = True Then
                    attrData.TempData.Accessory_Temp.Push_ScaleXY = .MapScale.Position
                    Return Check_Acc_Result.Scale
                End If
            End If
            '------注
            If .DataNote.Visible = True Then
                Dim Acc_Rect As Rectangle = attrData.TempData.Accessory_Temp.DataNote_Rect
                If spatial.Check_PointInBox(ScreenP, 0, Acc_Rect) = True Then
                    attrData.TempData.Accessory_Temp.Push_DataNoteXY = .DataNote.Position
                    Return Check_Acc_Result.Note
                End If
            End If
            '------凡例
            For i As Integer = attrData.TempData.Accessory_Temp.Legend_No_Max - 1 To 0 Step -1
                Dim lg As clsAttrData.Legend2_Atri = attrData.TempData.Accessory_Temp.MapLegend_W(i)
                If .MapLegend.Base.Visible = True Or lg.LineKind_Flag = True Or lg.PointObject_Flag = True Then
                    Dim Acc_Rect As Rectangle = lg.Rect
                    If spatial.Check_PointInBox(ScreenP, 0, Acc_Rect) = True Then
                        attrData.TempData.Accessory_Temp.Edit_Legend = i
                        attrData.TempData.Accessory_Temp.Push_LegendXY = attrData.TotalData.ViewStyle.MapLegend.Base.LegendXY(i)
                        Return Check_Acc_Result.Legend
                    End If
                End If
            Next
            '------グループボックス
            If .AccessoryGroupBox.Visible = True And .ScrData.ThreeDMode.Set3D_F = False Then
                Dim Acc_Rect As Rectangle = attrData.TempData.Accessory_Temp.GroupBox_Rect
                Dim pad As Integer = attrData.Get_PaddingPixcel(.AccessoryGroupBox.Back)
                Acc_Rect.Inflate(pad, pad)
                If spatial.Check_PointInBox(ScreenP, 0, Acc_Rect) = True Then
                    attrData.TempData.Accessory_Temp.OriginalGroupBoxRect = Acc_Rect
                    Return Check_Acc_Result.GroupBox
                End If
            End If
            Return Check_Acc_Result.NoAccessory
        End With
    End Function

    Private Sub mnuOption_Click(sender As Object, e As EventArgs) Handles mnuOption.Click
        Dim n As Integer = 0
        If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.DataViewMode Then
            Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
            If attrData.LayerData(Layernum).Print_Mode_Layer = enmLayerMode_Number.TripMode Then
                n = 5
            End If
        End If
        OptionShow(n)
    End Sub
    ''' <summary>
    ''' オプション設定画面
    ''' </summary>
    ''' <param name="tabPage"></param>
    ''' <remarks></remarks>
    Private Sub OptionShow(ByRef TabIndex As Integer)
        With attrData.TotalData.ViewStyle
            Dim form As New frmPrint_Option
            Dim oldAccessory_Base As enmBasePosition = .ScrData.Accessory_Base
            If form.ShowDialog(attrData, TabIndex) = Windows.Forms.DialogResult.OK Then
                attrData.TotalData.ViewStyle = form.getResult()
                If .ScrData.Accessory_Base = enmBasePosition.Screen Then
                    If oldAccessory_Base = enmBasePosition.Map Then
                        attrData.Change_Acc_Position_by_Accessory_Base_Set_Screen()
                    End If
                Else
                    If oldAccessory_Base = enmBasePosition.Screen Then
                        .AttMapCompass.Position = attrData.SetMapFile("").Map.MapCompass.Position
                        attrData.Set_Acc_First_Position()
                        .ScrData.ScrView = .ScrData.MapRectangle
                    End If
                End If
                printMapScreen(True)
            End If
            form.Dispose()
        End With

    End Sub
    Private Sub mnuLinePattern_Click(sender As Object, e As EventArgs) Handles mnuLinePattern.Click
        Dim form As New frmPrint_LinePattern
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            printMapScreen(False)
        End If
        form.Dispose()
    End Sub

    Private Sub mnuRedraw_Click(sender As Object, e As EventArgs) Handles mnuRedraw.Click

        printMapScreen(True)
    End Sub

    Private Sub mnuPictureSetting_Click(sender As Object, e As EventArgs) Handles mnuPictureSetting.Click
        clsGeneric.Select_Picture(attrData, 0)
    End Sub

    Private Sub mnuDummyObjChange_Click(sender As Object, e As EventArgs) Handles mnuDummyObjChange.Click
        Dim form As New frmPrint_DummyObjectGroup
        Dim O_Dummy_Size_Flag As Boolean = attrData.TotalData.ViewStyle.Dummy_Size_Flag
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            Dim newDummy() As clsAttrData.strDummyObjectInfo
            Dim newDummyGroup() As clsAttrData.strDummyObjectGroupInfo
            Dim new_PolygonDummy_ClipSet_F() As Boolean
            form.getResults(newDummy, newDummyGroup, new_PolygonDummy_ClipSet_F,
                            attrData.TotalData.ViewStyle.Dummy_Size_Flag, attrData.TotalData.ViewStyle.DummyObjectPointMark)
            For i As Integer = 0 To attrData.TotalData.LV1.Lay_Maxn - 1
                With attrData.LayerData(i)
                    .Dummy = newDummy(i)
                    .DummyGroup.Count = newDummyGroup(i).Count
                    If .DummyGroup.Count > 0 Then
                        .DummyGroup.DummyObjG = newDummyGroup(i).DummyObjG.Clone
                    Else
                        .DummyGroup.DummyObjG = Nothing
                    End If
                    .LayerModeViewSettings.PolygonDummy_ClipSet_F = new_PolygonDummy_ClipSet_F(i)
                End With
            Next
            If O_Dummy_Size_Flag <> attrData.TotalData.ViewStyle.Dummy_Size_Flag Then
                attrData.Check_Vector_Object()
                With attrData.TotalData.ViewStyle.ScrData
                    .ScrView = .MapRectangle
                End With
            Else
                attrData.Check_Vector_Object()
            End If
            printMapScreen(True)
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 線モードの曲線を元に戻す
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuODLineCurveReset_Click(sender As Object, e As EventArgs) Handles mnuODLineCurveReset.Click
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        With temp_data.OD_Drag
            attrData.LayerData(Layernum).Remove_OD_Bezier(.ObjectPos, .Data)
        End With
        printMapScreen(True)
    End Sub

    ''' <summary>
    ''' 飾り非表示メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuAccPopupInvisible_Click(sender As Object, e As EventArgs) Handles mnuAccPopupInvisible.Click
        Dim Acc As Check_Acc_Result = mnuAccPopup.Tag
        Select Case Acc
            Case Check_Acc_Result.Compass
                attrData.TotalData.ViewStyle.AttMapCompass.Visible = False
            Case Check_Acc_Result.GroupBox
                attrData.TotalData.ViewStyle.AccessoryGroupBox.Visible = False
            Case Check_Acc_Result.Legend
                attrData.TotalData.ViewStyle.MapLegend.Base.Visible = False
            Case Check_Acc_Result.Scale
                attrData.TotalData.ViewStyle.MapScale.Visible = False
            Case Check_Acc_Result.Note
                attrData.TotalData.ViewStyle.DataNote.Visible = False
            Case Check_Acc_Result.Title
                attrData.TotalData.ViewStyle.MapTitle.Visible = False
        End Select
        printMapScreen(True)
    End Sub
    Private Sub AccTitleVisible()
        attrData.TotalData.ViewStyle.MapTitle.Visible = True
        printMapScreen(True)
    End Sub
    Private Sub AccScaleVisible()
        attrData.TotalData.ViewStyle.MapScale.Visible = True
        printMapScreen(True)
    End Sub
    Private Sub AccCompassVisible()
        attrData.TotalData.ViewStyle.AttMapCompass.Visible = True
        printMapScreen(True)
    End Sub
    Private Sub AccGroupBoxVisible()
        attrData.TotalData.ViewStyle.AccessoryGroupBox.Visible = True
        printMapScreen(True)
    End Sub
    Private Sub AccLegendVisible()
        attrData.TotalData.ViewStyle.MapLegend.Base.Visible = True
        printMapScreen(True)
    End Sub
    Private Sub AccNoteVisible()
        attrData.TotalData.ViewStyle.DataNote.Visible = True
        printMapScreen(True)
    End Sub
    ''' <summary>
    ''' 飾り設定メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuAccPopupSettings_Click(sender As Object, e As EventArgs) Handles mnuAccPopupSettings.Click
        Dim Acc As Check_Acc_Result = mnuAccPopup.Tag
        With attrData.TotalData.ViewStyle
            Select Case Acc
                Case Check_Acc_Result.Compass
                    Dim form = New frmCompassSetting
                    If form.ShowDialog(Me, .AttMapCompass, .ScrData) = DialogResult.OK Then
                        .AttMapCompass = form.getResult
                        printMapScreen(True)
                    End If
                    form.Dispose()
                Case Check_Acc_Result.Legend
                    OptionShow(2)
                Case Check_Acc_Result.Scale
                    OptionShow(4)
                Case Check_Acc_Result.Title, Check_Acc_Result.Note, Check_Acc_Result.GroupBox
                    OptionShow(0)
            End Select
        End With
    End Sub



    ''' <summary>
    ''' 図形モードメニューのチェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuFigureMode_CheckedChanged(sender As Object, e As EventArgs) Handles mnuFigureMode.CheckedChanged
        If Me.Tag = "" Then
            If mnuFigureMode.Checked = True Then
                temp_data.PrintMouseMode = enmPrintMouseMode.Fig
                ownerForm.Enabled = False
                If frm_Figure.IsDisposed = True Then
                    frm_Figure = New frmPrint_Figure
                    frm_Figure.Owner = Me
                End If
                Set_Menu_Enable(False, False, False, False, False, False, False)
                frm_Figure.Show(attrData)
            Else
                temp_data.PrintMouseMode = enmPrintMouseMode.Normal
                ownerForm.Enabled = True
                frm_Figure.Visible = False
                picMap.Refresh()
                Set_Menu_Enable(True, True, True, True, True, True, True)
            End If
        End If
    End Sub
    ''' <summary>
    ''' 図形モードの文字モードの場合の位置をチェック。含まれる場合は文字の位置番号を返す。含まれない場合は-1を返す
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="scp"></param>
    ''' <param name="Word"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function check_FigWord_Location(ByVal g As Graphics, ByVal scp As Point, ByRef Word As clsAttrData.strFig_Word_Data) As Integer
        Dim Fig_RectW() As Rectangle = Get_WordMode_Box(g, Word)
        For j As Integer = 0 To Fig_RectW.Count - 1
            If spatial.Check_PointInBox(scp, Word.Font.Body.Kakudo, Fig_RectW(j)) = True Then
                Return j
            End If
        Next
        Return -1
    End Function

    ''' <summary>
    ''' マウスから最寄りの編集中図形ライン上の点または線分の位置を求める
    ''' </summary>
    ''' <param name="MousePosition"></param>
    ''' <param name="EditedLinePoint">最寄りの点スタック位置（戻り値）</param>
    ''' <param name="InsertLinePoint">最寄りの線分の開始点スタック位置（戻り値）</param>
    ''' <param name="NearLineSegmentPoint">最寄りの線分の最近隣ポイント座標（戻り値）</param>
    ''' <param name="DragZoneFlag">ドラッグ可能ゾーンの場合true（戻り値）</param>
    ''' <remarks></remarks>
    Private Sub check_FigLineMode_NearLinePointOrLineSegment(ByVal MousePosition As Point, ByRef EditedLinePoint As Integer,
                                           ByRef InsertLinePoint As Integer,
                                           ByRef NearLineSegmentPoint As PointF, ByRef DragZoneFlag As Boolean)

        Dim pxy() As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(frm_Figure.EditingFig.Line.NumOfPoint, frm_Figure.EditingFig.Line.Points, False, False)
        Dim NearestP As Point
        spatial.NearLinePointOrLineSegment(MousePosition, pxy, 8, 25, EditedLinePoint, InsertLinePoint, NearestP, DragZoneFlag)
        NearLineSegmentPoint = attrData.TotalData.ViewStyle.ScrData.getSRXY(NearestP)
    End Sub
    ''' <summary>
    ''' マウスから最寄りの編集中図形モード点の位置または凡例上にあるか調べる
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="MousePosition">マウスの位置</param>
    ''' <param name="EditingPointData">図形の点</param>
    ''' <param name="EditedPoint">点の位置（戻り値、存在しない場合は-1）</param>
    ''' <param name="onLegendF">凡例上にある場合はtrue</param>
    ''' <remarks></remarks>
    Private Sub check_FigPointMode_NearPointOrLegend(ByRef g As Graphics, ByVal MousePosition As Point,
                                        ByRef EditingPointData As clsAttrData.strFig_Point_Data, ByRef EditedPoint As Integer,
                                        ByRef onLegendF As Boolean)
        Dim pNum As Integer = -1
        With EditingPointData
            Dim Dis As Integer = attrData.TotalData.ViewStyle.ScrData.Radius(.Mark.WordFont.Body.Size, 1, 1) + 1
            Dim pt() As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(.NumOfPoint, .Points, False, False)
            pNum = spatial.get_PointDistance(MousePosition, pt, .NumOfPoint, Dis)
            onLegendF = False
            If .Caption_F = True And pNum = -1 Then
                Dim r As Integer = attrData.TotalData.ViewStyle.ScrData.Radius(.Mark.WordFont.Body.Size, 1, 1) + 1
                Dim dp As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(.CaptionPosition)
                Dim UH As Integer = attrData.Get_Length_On_Screen(.Font.Body.Size)
                Dim hnfont As Font = New Font(.Font.Body.Name, UH, GraphicsUnit.Pixel)
                Dim mh As Integer = Math.Max(r, g.MeasureString(.Caption, hnfont).Height)
                Dim mw As Integer = r + r * 2 + g.MeasureString(.Caption, hnfont).Width
                If spatial.Check_PointInBox(MousePosition, 0, New Rectangle(dp.X - r, dp.Y - mh / 2, r + mw, mh)) = True Then
                    onLegendF = True
                End If
                hnfont.Dispose()
            End If
        End With
        EditedPoint = pNum
    End Sub
    ''' <summary>
    ''' 図形位置チェックをして図形番号を返す。見つからない場合は-1
    ''' </summary>
    ''' <param name="P"></param>
    ''' <remarks></remarks>
    Private Function Check_Figure_Location(ByVal g As Graphics, ByVal scp As Point) As Integer

        Dim n As Integer = -1
        For fi As Integer = attrData.TotalData.FigureStac.Count - 1 To 0 Step -1
            If attrData.TempData.FigurePrinted(fi) = True Then
                Dim f As Boolean = False
                Dim FigStac As Object = attrData.TotalData.FigureStac(fi)
                Select Case True
                    Case TypeOf FigStac Is clsAttrData.strFig_Word_Data
                        '文字
                        Dim FigData As clsAttrData.strFig_Word_Data = DirectCast(FigStac, clsAttrData.strFig_Word_Data)
                        If check_FigWord_Location(g, scp, FigData) <> -1 Then
                            f = True
                        End If
                    Case TypeOf FigStac Is clsAttrData.strFig_Line_Data
                        '線
                        Dim FigData As clsAttrData.strFig_Line_Data = DirectCast(FigStac, clsAttrData.strFig_Line_Data)
                        Dim Fig_Rect As Rectangle = attrData.TotalData.ViewStyle.ScrData.getSxSy(FigData.Circumscribed_Rectangle)
                        Fig_Rect.Inflate(3, 3)
                        If spatial.Check_PointInBox(scp, 0, Fig_Rect) = True Then
                            Dim dis As Integer = 0
                            For j As Integer = 0 To FigData.NumOfPoint - 2
                                Dim p1 As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(FigData.Points(j))
                                Dim p2 As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(FigData.Points(j + 1))
                                Dim d2 As Integer = spatial.Distance_PointLine(scp, p1, p2)
                                If j <> 0 Then
                                    dis = Math.Min(dis, d2)
                                Else
                                    dis = d2
                                End If
                            Next
                            If dis < 5 Then
                                f = True
                            End If
                        End If
                    Case TypeOf FigStac Is clsAttrData.strFig_Rectangle_Data
                        '四角
                        Dim FigData As clsAttrData.strFig_Rectangle_Data = DirectCast(FigStac, clsAttrData.strFig_Rectangle_Data)
                        With FigData
                            Dim P0 As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(.Point0)
                            Dim P1 As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(.Point1)
                            Dim srect As Rectangle = spatial.Get_Circumscribed_Rectangle(P0, P1)
                            Dim dis As Integer
                            Dim inF As Boolean = spatial.Check_PointInBox(scp, srect, dis)
                            If (.Back.Tile.TileCode <> enmTilePattern.Blank And inF = True) Or dis < 5 Then
                                f = True
                            End If
                        End With
                    Case TypeOf FigStac Is clsAttrData.strFig_Circle_data
                        '円
                        Dim FigData As clsAttrData.strFig_Circle_data = DirectCast(FigStac, clsAttrData.strFig_Circle_data)
                        With FigData
                            Dim cp As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(.Position)
                            If .Printcenter = True Then
                                Dim D As Integer = spatial.get_Distance(scp, cp)
                                If D < attrData.TotalData.ViewStyle.ScrData.Radius(.Mark.WordFont.Body.Size, 1, 1) + 1 Then
                                    f = True
                                End If
                            End If
                            Dim MapScaleBairitu As Single = spatial.Get_Scale_Baititu_IdoKedo(.Position, attrData.SetMapFile("").Map.Zahyo)
                            If attrData.SetMapFile("").Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
                                MapScaleBairitu *= attrData.SetMapFile("").Map.SCL
                            End If
                            If .XR = .YR And f = False Then
                                Dim D As Integer = spatial.get_Distance(scp, cp)
                                Dim d2 As Integer = .XR * attrData.TotalData.ViewStyle.ScrData.ScreenMG.Mul * MapScaleBairitu
                                Dim d3 As Integer = d2 - D
                                If Math.Abs(d3) < 5 Then
                                    f = True
                                End If
                            Else
                                Dim ST As Single = 1 / ((.XR + .YR) / 4 * attrData.TotalData.ViewStyle.ScrData.ScreenMG.Mul)
                                For ra As Single = 0 To 6.28 Step ST
                                    Dim x2 As Single = Math.Cos(ra) * .XR * MapScaleBairitu
                                    Dim y2 As Single = Math.Sin(ra) * .YR * MapScaleBairitu
                                    spatial.Trans2D(x2, y2, .Angle)
                                    Dim xy2 As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(New PointF(x2 + .Position.X, -y2 + .Position.Y))
                                    Dim ox2 As Point
                                    If ra = 0 Then
                                        ox2 = xy2
                                    Else
                                        Dim d2 As Integer = spatial.Distance_PointLine(scp, xy2, ox2)
                                        If d2 < 5 Then
                                            f = True
                                            Exit For
                                        End If
                                        ox2 = xy2
                                    End If
                                Next
                            End If
                        End With


                    Case TypeOf FigStac Is clsAttrData.strFig_Point_Data
                        '点
                        Dim FigData As clsAttrData.strFig_Point_Data = DirectCast(FigStac, clsAttrData.strFig_Point_Data)
                        Dim onLegendF As Boolean
                        Dim Epoint As Integer
                        check_FigPointMode_NearPointOrLegend(g, scp, FigData, Epoint, onLegendF)
                        If Epoint <> -1 Or onLegendF = True Then
                            f = True
                        End If
                    Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                        '画像
                        Dim FigData As clsAttrData.strFig_gazo_data = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                        Dim cp As Point
                        Dim rad As Integer
                        Dim rect As Rectangle
                        clsAccessory.Get_Fig_ImageRect(attrData, FigData, cp, rect, rad)
                        f = spatial.Check_PointInBox(scp, FigData.Angle, rect)
                End Select
                If f = True Then
                    n = fi
                    Exit For
                End If
            End If
        Next
        Return n

    End Function
    ''' <summary>
    ''' 図形モード文字の文字ごとの四角領域を取得
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="FigWord"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_WordMode_Box(ByRef g As Graphics, ByRef FigWord As clsAttrData.strFig_Word_Data) As Rectangle()

        Dim Word() As String
        Dim PN As Integer = clsAccessory.Get_FigWord_XY(FigWord, Word)
        Dim RECT(PN - 1) As Rectangle

        For i As Integer = 0 To PN - 1
            Dim xw As Integer, yw As Integer
            Dim Word_Array As New List(Of String)
            Word_Array = clsDraw.TextCut_for_print(g, Word(i), FigWord.Font, True, -1, xw, yw, attrData.TotalData.ViewStyle.ScrData)
            Dim p As Point
            If FigWord.Screen_Setf = False Then
                p = attrData.TotalData.ViewStyle.ScrData.getSxSy(FigWord.StringPos(i))
            Else
                p = attrData.TotalData.ViewStyle.ScrData.getSxSyfromRatio(FigWord.StringPos(i))
            End If
            RECT(i) = New Rectangle(p.X - xw / 2, p.Y - yw * Word_Array.Count / 2, xw, yw * Word_Array.Count)
        Next
        Return RECT
    End Function



    Private Sub frmPrint_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Select Case temp_data.PrintMouseMode
            Case enmPrintMouseMode.Fig
                frm_Figure.Print_Fig()
            Case enmPrintMouseMode.Normal
                PrintCursorObjectLine(True)
            Case enmPrintMouseMode.MultiObjectSelect
                printSeletedMultiObject()
        End Select
    End Sub

    Private Sub frmPrint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If frm_Figure.Visible = True Then
            MsgBox("図形モード中は閉じられません。", MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If
    End Sub

    Private Sub mnuProjection_Click(sender As Object, e As EventArgs) Handles mnuProjection.Click
        If attrData.TotalData.ViewStyle.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
            MsgBox("緯度経度座標系ではありません。", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim form = New frmProjectionConvert
        Dim oldMapRect As RectangleF = attrData.TotalData.ViewStyle.ScrData.MapRectangle
        If form.ShowDialog(Me, attrData.TotalData.ViewStyle.Zahyo, oldMapRect) = DialogResult.OK Then
            Dim centerLon As Single
            Dim newPrj As enmProjection_Info
            form.getResult(centerLon, newPrj)
            If newPrj <> attrData.TotalData.ViewStyle.Zahyo.Projection Or centerLon <> attrData.TotalData.ViewStyle.Zahyo.CenterXY.X Then
                Dim newZahyo As clsMapData.Zahyo_info = attrData.TotalData.ViewStyle.Zahyo
                newZahyo.Projection = newPrj
                newZahyo.CenterXY.X = centerLon
                attrData.Convert_Zahyo(newZahyo)
                Dim MapFileList() As String = attrData.GetMapFileName
                For i As Integer = 0 To MapFileList.Length - 1
                    attrData.SetMapFile(MapFileList(i)).Convert_ZahyoMode(newZahyo)
                Next
                attrData.TotalData.ViewStyle.Zahyo = newZahyo
                attrData.Check_Vector_Object()
                attrData.PrtObjectSpatialIndex()
                With attrData.TotalData.ViewStyle.ScrData
                    .ScrView = .MapRectangle
                End With
                printMapScreen(True)
                MsgBox("投影法を変換しました。")
            End If
        End If
        form.Dispose()
    End Sub

    Private Sub frmPrint_Load(sender As Object, e As EventArgs) Handles Me.Load
        temp_data.SymbolPointFirstMessage = True
        temp_data.LabelPointFirstMessage = True
    End Sub
    ''' <summary>
    ''' 画像の保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuSaveImage_Click(sender As Object, e As EventArgs) Handles mnuSaveImage.Click
        Dim sfd As New SaveFileDialog()
        sfd.InitialDirectory = clsSettings.Data.Directory.ImageFile
        Dim firstExt As String = ""

        sfd.FileName = ""
        sfd.DefaultExt = "png"
        sfd.Filter = "PNGファイル(*.png)|*.png|BMPファイル(*.bmp)|*.bmp|JPEGファイル(*.jpg)|*.jpg|拡張メタファイル(*.emf)|*.emf"
        sfd.FilterIndex = 1
        If sfd.ShowDialog() = DialogResult.OK Then
            Try
                Select Case LCase(System.IO.Path.GetExtension(sfd.FileName))
                    Case ".png"
                        picMap.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                    Case ".bmp"
                        picMap.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                    Case ".jpg"
                        picMap.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                    Case ".emf"
                        clsGeneric.SaveEMFFile(sfd.FileName, attrData, ProgressBar, Me)
                End Select
                MsgBox(sfd.FileName & "を保存しました。")

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If

    End Sub
    ''' <summary>
    ''' 画面サイズ変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuFormSizeChange_Click(sender As Object, e As EventArgs) Handles mnuFormSizeChange.Click
        Dim form As New frmPrint_SizeChange
        Dim s As Size
        With attrData.TotalData.ViewStyle.ScrData.frmPrint_FormSize
            s = New Size(.Width, .Height)
        End With
        If form.ShowDialog(s) = Windows.Forms.DialogResult.OK Then
            Dim news As Size
            Dim pos As Integer
            form.GetResults(news, pos)
            clsPrintMap.Change_Mapscreen_Size_and_Position(attrData, Me, news, pos)
            printMapScreen(True)
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 表示範囲指定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuPrintRange_Click(sender As Object, e As EventArgs) Handles mnuPrintRange.Click
        Dim mex As String = ""
        If attrData.TotalData.ViewStyle.ScrData.Accessory_Base = enmBasePosition.Map Then
            mex += "タイトル等の位置・記号のサイズは「ウインドウ上に固定」になります。" & vbCrLf
        End If
        With attrData.TotalData.ViewStyle.ScrData.Screen_Margin
            If .Left <> 0 Or .Top <> 0 Or .Right <> 0 Or .Bottom <> 0 Then
                mex += "ウインドウ内の余白は0にします。" & vbCrLf
            End If
        End With
        If mex <> "" Then
            If MsgBox(mex, MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                mex = ""
            End If
        End If
        If mex = "" Then
            Set_Menu_Enable(False, False, False, False, False, False, False)
            temp_data.PrintMouseMode = enmPrintMouseMode.RangePrint
            picMap.Cursor = Cursors.Cross
        End If
    End Sub
    ''' <summary>
    ''' ルートメニューの可否を設定
    ''' </summary>
    ''' <param name="MFIle"></param>
    ''' <param name="mEdit"></param>
    ''' <param name="mAnalysis"></param>
    ''' <param name="mView"></param>
    ''' <param name="mOption"></param>
    ''' <param name="mFig"></param>
    ''' <param name="mPrint"></param>
    ''' <remarks></remarks>
    Private Sub Set_Menu_Enable(ByVal MFIle As Boolean, ByVal mEdit As Boolean, ByVal mAnalysis As Boolean,
                ByVal mView As Boolean, ByVal mOption As Boolean, ByVal mFig As Boolean, ByVal mPrint As Boolean)
        With temp_data.Menu_Enable
            .MFIle = mnuFile.Enabled
            .mEdit = mnuEdit.Enabled
            .mAnalysis = mnuAnalysis.Enabled
            .mView = mnuView.Enabled
            .mFig = mnuFigure.Enabled
            .mPrint = mnuPrintOut.Enabled
            .mOption = mnuOptionRoot.Enabled
        End With
        mnuFile.Enabled = MFIle
        mnuEdit.Enabled = mEdit
        mnuAnalysis.Enabled = mAnalysis
        mnuView.Enabled = mView
        mnuFigure.Enabled = mFig
        mnuPrintOut.Enabled = mPrint
        mnuOptionRoot.Enabled = mOption
    End Sub
    Private Sub Reset_Menu_Enable()
        With temp_data.Menu_Enable
            mnuFile.Enabled = .MFIle
            mnuEdit.Enabled = .mEdit
            mnuAnalysis.Enabled = .mAnalysis
            mnuView.Enabled = .mView
            mnuFigure.Enabled = .mFig
            mnuPrintOut.Enabled = .mPrint
            mnuOptionRoot.Enabled = .mOption
        End With
    End Sub
    ''' <summary>
    ''' 画面設定保存・切り替え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuScreen_Setting_Click(sender As Object, e As EventArgs) Handles mnuScreen_Setting.Click
        Dim form As New frmPrint_ScreenSetting
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            Dim Setting = New List(Of clsAttrData.strScreen_Setting_Data_Info)
            Dim n As Integer = form.GetResults(Setting)
            attrData.TotalData.ViewStyle.Screen_Setting = Setting
            If n <> -1 Then
                Dim itm As clsAttrData.strScreen_Setting_Data_Info
                With attrData.TotalData.ViewStyle.Screen_Setting(n)
                    itm.Accessory_Base = .Accessory_Base
                    itm.AttMapCompass = .AttMapCompass
                    itm.DataNote = .DataNote
                    itm.frmPrint_FormSize = .frmPrint_FormSize
                    itm.MapLegend = .MapLegend
                    itm.MapLegend.Base.LegendXY = .MapLegend.Base.LegendXY.Clone
                    itm.MapScale = .MapScale
                    itm.MapTitle = .MapTitle
                    itm.Screen_Margin = .Screen_Margin
                    itm.ScrView = .ScrView
                    itm.ThreeDMode = .ThreeDMode
                    itm.title = .title
                End With
                With attrData.TotalData.ViewStyle
                    With .ScrData
                        .Accessory_Base = itm.Accessory_Base
                        .frmPrint_FormSize = itm.frmPrint_FormSize
                        .Screen_Margin = itm.Screen_Margin
                        .ScrView = itm.ScrView
                        .ThreeDMode = itm.ThreeDMode
                    End With
                    .DataNote = itm.DataNote
                    .MapLegend = itm.MapLegend
                    .MapScale = itm.MapScale
                    .MapTitle = itm.MapTitle
                    .AttMapCompass = itm.AttMapCompass
                End With
                Me.Visible = False
                With itm.frmPrint_FormSize
                    Me.ClientSize = New Size(.Width, .Height + Me.StatusStrip.Height + Me.MenuStrip.Height)
                    Me.Left = .Left
                    Me.Top = .Top
                End With
                Me.Visible = True
                printMapScreen(True)
            End If
        End If
        form.Dispose()
    End Sub

    Private Sub mnuInstance_Click(sender As Object, e As EventArgs) Handles mnuInstance.Click
        Dim form As New frmPrint_Instance
        form.ClientSize = Me.picMap.Size
        form.picImage.Image = Me.picMap.Image
        form.Text = Me.Text
        form.Show()
    End Sub
    ''' <summary>
    ''' タイルマップ出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuTileMapOut_Click(sender As Object, e As EventArgs) Handles mnuTileMapOut.Click
        If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.SeriesMode Then
            MsgBox("タイルマップ出力は連続表示モードでは使えません。", MsgBoxStyle.Exclamation)
            Return
        End If
        With attrData.TotalData.ViewStyle.Zahyo
            If .Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Or .System <> enmZahyo_System_Info.Zahyo_System_World Then
                MsgBox("タイルマップ出力には、世界測地系の緯度経度座標系でメルカトル図法の地図ファイルを使用している場合に限られます。", MsgBoxStyle.Exclamation)
                Return
            End If
            If .Projection <> enmProjection_Info.prjMercator Then
                MsgBox("タイルマップ出力には、投影法をメルカトル図法に指定して下さい。", MsgBoxStyle.Exclamation)
                Return
            End If
        End With

        Dim form As New frmPrint_TileMapOut
        form.ShowDialog(attrData)
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 連続表示モードのファイル出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuTimeSeriesFileOut_Click(sender As Object, e As EventArgs) Handles mnuTimeSeriesFileOut.Click
        If attrData.TotalData.LV1.Print_Mode_Total <> enmTotalMode_Number.SeriesMode Then
            MsgBox("連続表示モードのファイル出力は連続表示モードで表示して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim form As New frmPrint_SeriesFileOut
        form.Owner = Me
        form.ShowDialog(attrData)
        form.Dispose()
    End Sub

    Private Sub mnuTransPngSave_Click(sender As Object, e As EventArgs) Handles mnuTransPngSave.Click
        Dim sfd As New SaveFileDialog()
        sfd.InitialDirectory = clsSettings.Data.Directory.ImageFile
        Dim firstExt As String = ""

        sfd.FileName = ""
        sfd.DefaultExt = "png"
        sfd.Filter = "PNGファイル(*.png)|*.png"
        sfd.FilterIndex = 1
        If sfd.ShowDialog() = DialogResult.OK Then
            Dim canvas As New Bitmap(picMap.Width, picMap.Height)
            Dim g As Graphics = Graphics.FromImage(canvas)
            If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.SeriesMode Then
                Series_Mapping(g, ProgressBar, False)
            Else
                clsPrintMap.ShowMap(g, ProgressBar, attrData)
            End If
            g.Dispose()
            Try
                canvas.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png)
                MsgBox(sfd.FileName & "を保存しました。")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Finally
                canvas.Dispose()
            End Try
        End If

    End Sub
    ''' <summary>
    ''' KML形式で出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuKMLFileOut_Click(sender As Object, e As EventArgs) Handles mnuKMLFileOut.Click
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim Datanum As Integer = attrData.LayerData(Layernum).atrData.SelectedIndex
        Dim Mode As enmSoloMode_Number = attrData.LayerData(Layernum).atrData.Data(Datanum).ModeData
        Dim Shape As enmShape = attrData.LayerData(Layernum).Shape

        If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.DataViewMode And attrData.TotalData.ViewStyle.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_No_Mode And _
                attrData.LayerData(Layernum).Print_Mode_Layer = enmLayerMode_Number.SoloMode And _
                (Mode = enmSoloMode_Number.ClassPaintMode Or (Mode = enmSoloMode_Number.MarkSizeMode And Shape <> enmShape.LineShape)) Then
            Dim form As New frmPrint_KMLFileOut
            form.ShowDialog(attrData)
            form.Dispose()
        Else
            MsgBox("現在のデータではKLに出力できません。", MsgBoxStyle.Exclamation)
        End If

    End Sub






    Private Sub mnuHelp_Click(sender As Object, e As EventArgs) Handles mnuHelp.Click
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "")
    End Sub

    Private Sub mnuFigureList_Click(sender As Object, e As EventArgs) Handles mnuFigureList.Click
        If attrData.TotalData.FigureStac.Count = 0 Then
            MsgBox("図形は作成されていません。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim form As New frmPrint_FigureList
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            Dim edindex As Integer = form.GetResults()
            printMapScreen(True)
            If edindex <> -1 Then
                ownerForm.Enabled = False
                Me.Tag = "OFF"
                mnuFigureMode.Checked = True
                Me.Tag = ""
                temp_data.PrintMouseMode = enmPrintMouseMode.Fig
                If frm_Figure.IsDisposed = True Then
                    frm_Figure = New frmPrint_Figure
                    frm_Figure.Owner = Me
                End If
                frm_Figure.Show(attrData)
                frm_Figure.SetFigureMode(attrData.TotalData.FigureStac(edindex), edindex)
            End If
        End If
        form.Dispose()
    End Sub

    Private Sub mnuStdDaen_Click(sender As Object, e As EventArgs) Handles mnuStdDaen.Click
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim DataNum As Integer = attrData.LayerData(LayerNum).atrData.SelectedIndex

        If attrData.TotalData.LV1.Print_Mode_Total <> enmTotalMode_Number.DataViewMode Or attrData.LayerData(LayerNum).Print_Mode_Layer <> enmLayerMode_Number.SoloMode Then
            MsgBox("標準偏差楕円は単独表示モードで使用します。", MsgBoxStyle.Exclamation)
            Return
        End If
        Select Case attrData.Get_DataType(LayerNum, DataNum)
            Case enmAttDataType.Strings, enmAttDataType.Category
                MsgBox("カテゴリーデータ・文字データの場合は、すべてのオブジェクトの重み付けを1として計算します。")
            Case Else
                If attrData.Get_DataMin(LayerNum, DataNum) < 0 Then
                    MsgBox("標準偏差楕円は負のデータがある場合は使用できません。", MsgBoxStyle.Exclamation)
                    Return
                End If
        End Select
        StdDaen()
    End Sub
    ''' <summary>
    ''' 標準偏差楕円
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StdDaen()
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim DataNum As Integer = attrData.LayerData(LayerNum).atrData.SelectedIndex

        Dim V() As Double
        Dim ObjN As Integer = attrData.Get_ObjectNum(LayerNum)

        Dim MV() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, DataNum)
        For i As Integer = 0 To ObjN - 1
            If attrData.Check_Condition(LayerNum, i) = False Then
                MV(i) = True
            End If
        Next

        Dim Dtat As enmAttDataType = attrData.Get_DataType(LayerNum, DataNum)
        If Dtat = enmAttDataType.Normal Then
            V = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, DataNum)
        Else
            ReDim V(ObjN - 1)
            For i As Integer = 0 To ObjN - 1
                V(i) = 1
            Next
        End If
        Dim EnableObjN As Integer = 0
        Dim gn As Double = 0
        For i As Integer = 0 To ObjN - 1
            If MV(i) = False Then
                gn += V(i)
                EnableObjN += 1
            End If
        Next
        If EnableObjN = 0 Then
            MsgBox("対象オブジェクトが存在しないため計算できません。", MsgBoxStyle.Exclamation)
            Return
        End If
        If gn = 0 Then
            MsgBox("データの合計値が0のため計算できません。", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim X As Single = 0
        Dim Y As Single = 0
        For i As Integer = 0 To ObjN - 1
            If MV(i) = False Then
                Dim OP As PointF = attrData.LayerData(LayerNum).atrObject.atrObjectData(i).CenterPoint
                X += OP.X * V(i)
                Y += OP.Y * V(i)
            End If
        Next
        Dim gx As Single = X / gn
        Dim gy As Single = Y / gn
        Dim Map As clsMapData.strMap_data = attrData.SetMapFile("").Map
        Dim MapScaleBairitu As Single = spatial.Get_Scale_Baititu_IdoKedo(New Point(gx, gy), Map.Zahyo)
        If Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
            MapScaleBairitu *= Map.SCL
        End If
        Dim ZX1 As Double = 0
        Dim ZY1 As Double = 0
        Dim ZXY1 As Double = 0
        For i As Integer = 0 To ObjN - 1
            If MV(i) = False Then
                Dim OP As PointF = attrData.LayerData(LayerNum).atrObject.atrObjectData(i).CenterPoint
                Dim a As Double = (OP.X - gx) / (MapScaleBairitu)
                Dim b As Double = (OP.Y - gy) / (MapScaleBairitu)
                ZX1 += a * a * V(i)
                ZY1 += b * b * V(i)
                ZXY1 += +a * b * V(i)
            End If
        Next
        Dim TA As Double = ((ZX1 - ZY1) + Math.Sqrt((ZX1 - ZY1) ^ 2 + 4 * ZXY1 ^ 2)) / (2 * ZXY1)
        Dim co As Double = Math.Sqrt(1 / (1 + TA * TA))
        Dim si As Double = TA * co
        Dim SS As Double = Math.Sqrt(ZX1 * ZY1 - ZXY1 * ZXY1) * Math.PI / gn
        Dim Kakudo As Single = clsGeneric.Angle(si, co)
        Dim ZX2 As Double = 0
        Dim ZY2 As Double = 0
        For i As Integer = 0 To ObjN - 1
            If MV(i) = False Then
                Dim OP As PointF = attrData.LayerData(LayerNum).atrObject.atrObjectData(i).CenterPoint
                Dim a As Double = (OP.X - gx) / (MapScaleBairitu)
                Dim b As Double = (OP.Y - gy) / (MapScaleBairitu)
                ZX2 += (a * co - b * si) ^ 2 * V(i)
                ZY2 += (a * si + b * co) ^ 2 * V(i)
            End If
        Next
        Dim xl As Single = Math.Sqrt(ZX2 / gn)
        Dim yl As Single = Math.Sqrt(ZY2 / gn)

        Dim FigCircle As clsAttrData.strFig_Circle_data
        With FigCircle
            .Data.Layer = LayerNum + 1
            .Data.Data = DataNum + 1
            .Angle = Kakudo
            .Position = New PointF(gx, gy)
            .XR = xl
            .YR = yl
            .LinePat = clsBase.Line
            .Printcenter = True
            .Mark = clsBase.Mark
            With .Mark
                .ShapeNumber = 6
                .Tile.Line = clsBase.Line
                .WordFont = clsBase.Font
                .WordFont.Body.Size = 1.5
                .wordmark = ""
            End With
            .Tile = clsBase.BlancTile
        End With

        Dim P_Scl As clsAttrData.strScale_Attri = attrData.TotalData.ViewStyle.MapScale
        Dim conSCL As Single = clsGeneric.Convert_ScaleUnit(enmScaleUnit.kilometer, P_Scl.Unit)
        Dim SClU As String = clsGeneric.getScaleUnitStrings(P_Scl.Unit)
        Dim tx As String = ""
        tx = "レイヤ：" + attrData.LayerData(LayerNum).Name & vbCrLf
        tx += "データ項目：" + attrData.Get_DataTitle(LayerNum, DataNum, False) & vbCrLf & vbCrLf
        tx += String.Format("有効オブジェクト数:{0}/全オブジェクト数{1}", EnableObjN, ObjN) + vbCrLf + vbCrLf
        tx += "長軸半径：" & Math.Max(xl, yl) * conSCL & SClU & vbCrLf
        tx += "短軸半径：" & Math.Min(xl, yl) * conSCL & SClU & vbCrLf
        tx += "面積：" & SS * conSCL * conSCL & clsGeneric.getScaleUnitAreaStrings(P_Scl.Unit) & vbCrLf
        tx += "角度：" & Kakudo & "°" & vbCrLf
        clsGeneric.Message(Me, "標準偏差楕円統計量", tx, True, False)

        Send_to_FigMode(FigCircle)

    End Sub
    ''' <summary>
    ''' グーグルマップに出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuGoogleMapOut_Click(sender As Object, e As EventArgs) Handles mnuGoogleMapOut.Click
        If attrData.TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
            MsgBox("座標系の設定してある地図データを使用していない場合はGoogleマップに出力できません。", MsgBoxStyle.Exclamation)
        Else
            Dim form As New frmPrint_GoogleMapsFileOut
            form.Owner = Me
            form.ShowDialog(attrData)
            form.Dispose()
        End If
    End Sub
    ''' <summary>
    ''' 複数オブジェクト選択メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuMultiObjectSelectMode_Click(sender As Object, e As EventArgs) Handles mnuMultiObjectSelectMode.Click
        Dim f As Boolean = False
        If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.DataViewMode Then
            Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
            If attrData.LayerData(LayerNum).Print_Mode_Layer = enmLayerMode_Number.SoloMode Then
                f = True
            End If
        End If
        If f = True Then
            Set_Menu_Enable(False, False, False, False, False, False, False)
            temp_data.PrintMouseMode = enmPrintMouseMode.MultiObjectSelect
            temp_data.MultiObjects = New List(Of Integer)
            mnuPropertyWindow.Checked = True
            frm_Property.rbMultiObjectSelectMode_Pointing.Checked = True
            frm_Property.ShowMultiObjectInformation(attrData, temp_data.MultiObjects)
        Else
            MsgBox("複数オブジェクト選択は単独表示モードで使用して下さい。", MsgBoxStyle.Exclamation)
        End If

    End Sub
    ''' <summary>
    ''' 複数オブジェクト選択モードの選択方法の指定（frmPrint_Propertyから呼び出し）
    ''' </summary>
    ''' <param name="selMultiMode"></param>
    ''' <remarks></remarks>
    Public Sub SetMultiObjectSelectModeSub(ByVal selMultiMode As enmMultiObjectSelecModesSub)
        temp_data.MultiObjectSelectSub = selMultiMode
    End Sub
    ''' <summary>
    ''' 複数オブジェクト選択モードの終了（frmPrint_Propertyから呼び出し）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndMultiObjectSelectMode()
        temp_data.Location_Fixed_F = False
        temp_data.PrintMouseMode = enmPrintMouseMode.Normal
        Set_Menu_Enable(True, True, True, True, True, True, True)
        picMap.Refresh()
    End Sub
    ''' <summary>
    ''' 選択されたオブジェクトを選択解除（frmPrint_Propertyから呼び出し）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearSelectedMultiObject()
        temp_data.MultiObjects.Clear()
        frm_Property.ShowMultiObjectInformation(attrData, temp_data.MultiObjects)
        picMap.Refresh()
    End Sub
    ''' <summary>
    '''　他の選択方法（frmPrint_Propertyから呼び出し）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OtherSelectMultiObject(ByVal index As Integer)
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Select Case index
            Case 0
                Dim form As New frmPrint_SearchObjects
                If form.ShowDialog(attrData, True) = Windows.Forms.DialogResult.OK Then
                    Dim selObj As List(Of frmPrint_SearchObjects.selobj_Info) = form.GetResults
                    Dim selL(attrData.Get_ObjectNum(LayerNum) - 1) As Boolean
                    For i As Integer = 0 To temp_data.MultiObjects.Count - 1
                        selL(temp_data.MultiObjects(i)) = True
                    Next
                    For i As Integer = 0 To selObj.Count - 1
                        If selL(selObj(i).ObjPosition) = False Then
                            temp_data.MultiObjects.Add(selObj(i).ObjPosition)
                        End If
                    Next
                End If

            Case 1
                temp_data.MultiObjects.Clear()
                For i As Integer = 0 To attrData.Get_ObjectNum(LayerNum) - 1
                    If attrData.Check_Condition(LayerNum, i) = True Then
                        temp_data.MultiObjects.Add(i)
                    End If
                Next
            Case 2
                Dim preNo(attrData.Get_ObjectNum(LayerNum) - 1) As Boolean
                For i As Integer = 0 To temp_data.MultiObjects.Count - 1
                    preNo(temp_data.MultiObjects(i)) = True
                Next
                temp_data.MultiObjects.Clear()
                For i As Integer = 0 To attrData.Get_ObjectNum(LayerNum) - 1
                    If attrData.Check_Condition(LayerNum, i) = True And preNo(i) = False Then
                        temp_data.MultiObjects.Add(i)
                    End If
                Next

        End Select
        printSeletedMultiObject()
        frm_Property.ShowMultiObjectInformation(attrData, temp_data.MultiObjects)
    End Sub
    ''' <summary>
    ''' 複数オブジェクト選択モードで四角形・円選択
    ''' </summary>
    ''' <param name="MousePosition">マウス位置</param>
    ''' <param name="MouseUpF">マウスアップ時にtrue、move時にfalse</param>
    ''' <param name="CancelF">右クリックでキャンセルの際にtrue</param>
    ''' <remarks></remarks>
    Public Sub picMapMouseMoveMultiObjectSelect_Shape(ByVal MousePosition As Point, ByVal MouseUpF As Boolean, ByVal CancelF As Boolean)
        Static MouseUpP As PointF
        Static MouseUpFirstF As Boolean = False
        Static PolygonP() As PointF
        Dim P As PointF = attrData.TotalData.ViewStyle.ScrData.getSRXY(MousePosition)
        If CancelF = True Then
            If MouseUpFirstF = True Then
                picMap.Refresh()
                MouseUpFirstF = False
                frm_Property.pnlMultiObjectSelect.Enabled = True
            End If
            Exit Sub
        End If

        If MouseUpF = True Then
            If MouseUpFirstF = False Then
                '初回のマウスアップ
                MouseUpP = P
                MouseUpFirstF = True
                frm_Property.pnlMultiObjectSelect.Enabled = False
                If temp_data.MultiObjectSelectSub = enmMultiObjectSelecModesSub.Polygon Then
                    ReDim PolygonP(0)
                    PolygonP(0) = P
                End If
            Else
                '二度目以降のマウスアップ
                Dim selectf As Boolean = True
                If temp_data.MultiObjectSelectSub = frmMapEditor.EditingModes_MultiObjectSub.Polygon Then
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
                    Select Case temp_data.MultiObjectSelectSub
                        Case enmMultiObjectSelecModesSub.Circle
                            r = spatial.get_Distance(MouseUpP, P)
                        Case enmMultiObjectSelecModesSub.Polygon
                            Polyrect = spatial.Get_Circumscribed_Rectangle(PolygonP, 0, PolygonP.GetUpperBound(0) + 1)
                    End Select
                    Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
                    For i As Integer = 0 To attrData.Get_ObjectNum(LayerNum) - 1
                        If attrData.Check_Condition(LayerNum, i) = True Then
                            Dim cp As PointF = attrData.LayerData(LayerNum).atrObject.atrObjectData(i).CenterPoint
                            Dim f As Boolean = False
                            Select Case temp_data.MultiObjectSelectSub
                                Case enmMultiObjectSelecModesSub.Rectangle
                                    f = spatial.Get_Circumscribed_Rectangle(MouseUpP, P).Contains(cp)
                                Case enmMultiObjectSelecModesSub.Polygon
                                    If Polyrect.Contains(cp) = True Then
                                        Dim Cross_x(0) As Single
                                        Dim crn As Integer = 0
                                        Dim n As Integer = PolygonP.GetUpperBound(0)
                                        ReDim Preserve PolygonP(n + 1)
                                        PolygonP(n + 1) = PolygonP(0)
                                        f = spatial.check_Point_in_Polygon(cp, PolygonP)
                                    End If
                                Case enmMultiObjectSelecModesSub.Circle
                                    If spatial.get_Distance(cp, MouseUpP) <= r Then
                                        f = True
                                    End If
                            End Select
                            If f = True Then
                                If temp_data.MultiObjects.Contains(i) = True Then
                                    temp_data.MultiObjects.RemoveAt(temp_data.MultiObjects.IndexOf(i))
                                Else
                                    temp_data.MultiObjects.Add(i)
                                End If
                            End If
                        End If
                    Next
                    frm_Property.pnlMultiObjectSelect.Enabled = True
                    SetMultiObJInformation()
                    printSeletedMultiObject()
                End If
            End If
        ElseIf MouseUpFirstF = True Then
            '描画
            Dim MouseDownPositionScreen As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(MouseUpP)
            Dim g As Graphics = picMap.CreateGraphics
            Dim pen As New Pen(Color.FromArgb(180, 0, 0, 0), 2)
            pen.LineJoin = Drawing2D.LineJoin.Round
            Dim brush As New SolidBrush(Color.FromArgb(50, 0, 0, 0))
            If temp_data.MultiObjects.Count = 0 Then
                picMap.Refresh()
            Else
                printSeletedMultiObject()
            End If
            Select Case temp_data.MultiObjectSelectSub
                Case enmMultiObjectSelecModesSub.Rectangle
                    Dim Rect As Rectangle = spatial.Get_Circumscribed_Rectangle(MousePosition, MouseDownPositionScreen)
                    g.FillRectangle(brush, Rect)
                    g.DrawRectangle(pen, Rect)
                Case enmMultiObjectSelecModesSub.Circle
                    Dim r As Integer = spatial.get_Distance(MousePosition, MouseDownPositionScreen)
                    clsDraw.Ellipse(g, MouseDownPositionScreen, 3, pen)
                    clsDraw.Ellipse(g, MouseDownPositionScreen, r, brush, pen)
                Case enmMultiObjectSelecModesSub.Polygon
                    Dim n As Integer = PolygonP.GetUpperBound(0)
                    Dim Points(n + 1) As Point
                    For i As Integer = 0 To n
                        Points(i) = attrData.TotalData.ViewStyle.ScrData.getSxSy(PolygonP(i))
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
    ''' 選択オブジェクト非表示' 
    ''' </summary>
    ''' <param name="mode">0:選択オブジェクト非表示 1:非選択オブジェクト非表示</param>
    ''' <remarks></remarks>
    Public Function MultiObjectInVisible(ByVal mode As Integer) As Boolean
        If temp_data.MultiObjects.Count = 0 Then
            MsgBox("選択オブジェクトがありません。", MsgBoxStyle.Exclamation)
            Return False
        End If
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Select Case mode
            Case 0
                For i As Integer = 0 To temp_data.MultiObjects.Count - 1
                    attrData.LayerData(LayerNum).atrObject.atrObjectData(temp_data.MultiObjects(i)).Visible = False
                Next
            Case 1
                Dim preNo(attrData.Get_ObjectNum(LayerNum) - 1) As Boolean
                For i As Integer = 0 To temp_data.MultiObjects.Count - 1
                    preNo(temp_data.MultiObjects(i)) = True
                Next
                For i As Integer = 0 To attrData.Get_ObjectNum(LayerNum) - 1
                    If attrData.Check_Condition(LayerNum, i) = True And preNo(i) = False Then
                        attrData.LayerData(LayerNum).atrObject.atrObjectData(i).Visible = False
                    End If
                Next
        End Select

        EndMultiObjectSelectMode()
        attrData.TotalData.ViewStyle.ObjectLimitationF = True
        printMapScreen(True)
        CType(ownerForm, frmMain).Check_Print_err()
        Return True
    End Function
    Private Sub picMap_Paint(sender As Object, e As PaintEventArgs) Handles picMap.Paint
        Dim g As Graphics = e.Graphics
        If temp_data.PrintMouseMode = enmPrintMouseMode.MultiObjectSelect Then
            '複数オブジェクトの選択表示
            If temp_data.MultiObjectSelectShowFlag = True Then
                Dim LyaerNum As Integer = attrData.TotalData.LV1.SelectedLayer
                For Each Obj As Integer In temp_data.MultiObjects
                    printSelectedObject(g, LyaerNum, Obj)
                Next
            End If
        ElseIf temp_data.PrintMouseMode = enmPrintMouseMode.Distance Then
            printDistanceAreaLine(g)
        End If

    End Sub

    Private Sub frmPrint_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            frm_Property.Visible = False
            Frm_Set3d.Visible = False
        Else
            If mnuSet3d.Checked = True Then
                Frm_Set3d.Visible = True
            End If
            If mnuPropertyWindow.Checked = True Then
                frm_Property.Visible = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' オブジェクト検索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuObjectSerach_Click(sender As Object, e As EventArgs) Handles mnuObjectSerach.Click
        Dim form As New frmPrint_SearchObjects
        If form.ShowDialog(attrData, False) = Windows.Forms.DialogResult.OK Then
            Dim selObj As List(Of frmPrint_SearchObjects.selobj_Info) = form.GetResults
            mnuPropertyWindow.Checked = True
            frm_Property.Fixed(True)
            Dim OnObject = New List(Of strLocationSearchObject)
            Dim dt As strLocationSearchObject
            dt.objLayer = selObj(0).LayerNum
            dt.ObjNumber = selObj(0).ObjPosition
            OnObject.Add(dt)
            temp_data.Location_Fixed_F = True
            temp_data.OnObject = OnObject
            Dim dtindex As Integer
            Select Case attrData.TotalData.LV1.Print_Mode_Total
                Case enmTotalMode_Number.DataViewMode
                    Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
                    Select Case attrData.LayerData(Layernum).Print_Mode_Layer
                        Case enmLayerMode_Number.SoloMode
                            dtindex = attrData.LayerData(Layernum).atrData.SelectedIndex
                        Case enmLayerMode_Number.GraphMode
                            dtindex = attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode.SelectedIndex
                        Case enmLayerMode_Number.LabelMode
                            dtindex = attrData.LayerData(Layernum).LayerModeViewSettings.LabelMode.SelectedIndex
                    End Select
                    frm_Property.ShowOneObjectProperty(attrData, OnObject(0).objLayer, OnObject(0).ObjNumber, dtindex, attrData.LayerData(Layernum).Print_Mode_Layer)
                Case enmTotalMode_Number.OverLayMode
                    frm_Property.ShowOneObjectProperty(attrData, OnObject(0).objLayer, OnObject(0).ObjNumber, -1, enmLayerMode_Number.SoloMode)
                Case enmTotalMode_Number.SeriesMode
                    frm_Property.ShowOneObjectProperty(attrData, OnObject(0).objLayer, OnObject(0).ObjNumber, -1, enmLayerMode_Number.SoloMode)
            End Select
            If attrData.Check_screen_Kencode_In(OnObject(0).objLayer, OnObject(0).ObjNumber) = False Then
                Dim cp As PointF = attrData.LayerData(OnObject(0).objLayer).atrObject.atrObjectData(OnObject(0).ObjNumber).CenterPoint
                Dim scrw As RectangleF = attrData.TotalData.ViewStyle.ScrData.ScrView
                attrData.TotalData.ViewStyle.ScrData.ScrView = New RectangleF(cp.X - scrw.Width / 2, cp.Y - scrw.Height / 2, scrw.Width, scrw.Height)
                printMapScreen(True)
            End If
            PrintCursorObjectLine(False)

        End If
    End Sub
    ''' <summary>
    ''' 距離・面積測定メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuDIstanceArea_Click(sender As Object, e As EventArgs) Handles mnuDIstanceArea.Click
        With attrData
            For i As Integer = 0 To .TotalData.LV1.Lay_Maxn - 1
                If attrData.LayerData(i).Type <> clsAttrData.enmLayerType.Trip_Definition Then
                    If attrData.LayerData(i).MapFileData.Map.Detail.DistanceMeasurable = False Then
                        MsgBox("使用されている地図データが、距離測定ができない設定になっています。", MsgBoxStyle.Exclamation)
                        Return
                    End If
                End If
            Next
        End With
        Set_Menu_Enable(False, False, False, False, False, False, False)
        picMap.Cursor = Cursors.Cross
        lblUnitArea.Text = clsGeneric.getScaleUnitAreaStrings(attrData.TotalData.ViewStyle.MapScale.Unit)
        lblUnitDis.Text = clsGeneric.getScaleUnitStrings(attrData.TotalData.ViewStyle.MapScale.Unit)
        txtArea.Text = ""
        txtDistance.Text = ""
        pnlDistanceArea.Visible = True
        temp_data.PointDistanceArea = New List(Of PointF)

        picMap.Refresh()
        temp_data.PrintMouseMode = enmPrintMouseMode.Distance
    End Sub

    Private Sub btnDistanceEnd_Click(sender As Object, e As EventArgs) Handles btnDistanceEnd.Click
        temp_data.PrintMouseMode = enmPrintMouseMode.Normal
        Set_Menu_Enable(True, True, True, True, True, True, True)
        pnlDistanceArea.Visible = False
        picMap.Cursor = Cursors.Default
        picMap.Refresh()
    End Sub
    ''' <summary>
    ''' 距離・面積測定のラインポイント表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub printDistanceAreaLine(ByRef g As Graphics)
        With temp_data
            Dim n As Integer = .PointDistanceArea.Count
            For i As Integer = 0 To n - 1
                Dim OP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(.PointDistanceArea(i))
                Dim Mk As Mark_Property = clsBase.Mark
                Mk.Tile.TileCode = enmTilePattern.Paint
                Mk.Tile.Line.BasicLine.SolidLine.Color = New colorARGB(150, 255, 0, 150)
                attrData.Draw_Mark(g, OP, 5, Mk)
                If i = n - 1 Then
                    If i >= 2 Then
                        Dim OP2 As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(.PointDistanceArea(0))
                        Dim Lpat As Line_Property = clsBase.Line
                        Lpat.BasicLine.SolidLine.Color = New colorARGB(150, 50, 50, 50)
                        attrData.Draw_Line(g, Lpat, OP, OP2)
                    End If
                Else
                    Dim OP2 As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(.PointDistanceArea(i + 1))
                    Dim Lpat As Line_Property = clsBase.Line
                    Lpat.BasicLine.SolidLine.Color = New colorARGB(150, 255, 0, 150)
                    Lpat.BasicLine.SolidLine.Width = 0.3
                    attrData.Draw_Line(g, Lpat, OP, OP2)
                End If
            Next
            Dim ScaleRatio As Single = clsGeneric.Convert_ScaleUnit(enmScaleUnit.kilometer, attrData.TotalData.ViewStyle.MapScale.Unit)
            Dim pxy() As PointF = .PointDistanceArea.ToArray
            If n >= 3 Then
                ReDim Preserve pxy(n + 1)
                pxy(n) = pxy(0)
                pxy(n + 1) = pxy(1)
                Dim men As Single = spatial.Get_Hairetu_Menseki(n + 1, pxy, attrData.SetMapFile("").Map) * ScaleRatio ^ 2
                txtArea.Text = men
            Else
                txtArea.Text = ""
            End If
            If n >= 2 Then
                Dim D As Single
                For i As Integer = 0 To n - 2
                    If attrData.TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                        D += spatial.Distance_Ido_Kedo_XY(pxy(i), pxy(i + 1), attrData.TotalData.ViewStyle.Zahyo)
                    Else
                        D += spatial.get_Distance(pxy(i), pxy(i + 1))
                    End If
                Next
                If attrData.TotalData.ViewStyle.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
                    D /= attrData.SetMapFile("").Map.SCL
                End If
                D *= ScaleRatio
                txtDistance.Text = D
            Else
                txtDistance.Text = ""
            End If
        End With
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        temp_data.PointDistanceArea.Clear()
        picMap.Refresh()
    End Sub


    Private Sub mnuObjDataValueShow_Click(sender As Object, e As EventArgs) Handles mnuObjDataValueShow.Click
        Dim form As New frmPrint_ObjectValue
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            attrData.TotalData.ViewStyle.ValueShow = form.GetResults()
            printMapScreen(True)
        End If
        form.Dispose()
    End Sub



    Private Sub frmPrint_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If mousePointingSituation = mousePointingSituations.up Then
            Dim w As Single = attrData.TotalData.ViewStyle.ScrData.ScrView.Width
            Dim h As Single = attrData.TotalData.ViewStyle.ScrData.ScrView.Height
            Dim okf As Boolean = False
            If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.SeriesMode Then
                '連続表示モード
                If (e.Modifiers And Keys.Alt) = Keys.Alt Then
                    If e.KeyCode = 37 Then
                        SeriesModeButton(1).PerformClick()
                        Return
                    ElseIf e.KeyCode = 39 Then
                        SeriesModeButton(0).PerformClick()
                        Return
                    End If
                End If
                If e.KeyCode = 90 Then 'Z
                    SeriesModeButton(1).PerformClick()
                    Return
                ElseIf e.KeyCode = 88 Then 'x
                    SeriesModeButton(0).PerformClick()
                    Return
                End If
            End If
            Select Case e.KeyCode
                Case 82 'R
                    ShowAllButton.PerformClick()
                Case 37, 38, 39, 40
                    Dim xmove As Single = 0
                    Dim ymove As Single = 0
                    If e.KeyCode = 37 Or e.KeyCode = 39 Then
                        xmove = (e.KeyCode - 38) * w / 5
                    End If
                    If e.KeyCode = 38 Or e.KeyCode = 40 Then
                        ymove = (e.KeyCode - 39) * h / 5
                    End If
                    If (e.Modifiers And Keys.Shift) = Keys.Shift And (e.Modifiers And Keys.Control) = Keys.Control Then
                        xmove /= 8
                        ymove /= 8
                    Else
                        If (e.Modifiers And Keys.Shift) = Keys.Shift Then
                            xmove /= 2
                            ymove /= 2
                        End If
                        If (e.Modifiers And Keys.Control) = Keys.Control Then
                            xmove /= 4
                            ymove /= 4
                        End If
                    End If

                    attrData.TotalData.ViewStyle.ScrData.ScrView.Offset(xmove, ymove)
                    okf = True
                Case 33, 34
                    Dim bairitsu As Single

                    If e.KeyCode = 34 Then
                        bairitsu = 0.4
                    Else
                        bairitsu = -0.4
                    End If
                    If (e.Modifiers And Keys.Shift) = Keys.Shift And (e.Modifiers And Keys.Control) = Keys.Control Then
                        bairitsu /= 8
                    Else
                        If (e.Modifiers And Keys.Shift) = Keys.Shift Then
                            bairitsu /= 2
                        End If
                        If (e.Modifiers And Keys.Control) = Keys.Control Then
                            bairitsu /= 4
                        End If
                    End If

                    Dim ratio As Single = 1 - bairitsu
                    With attrData.TotalData.ViewStyle.ScrData
                        Dim rec As RectangleF
                        With .ScrView
                            Dim Pos As PointF = New Point(.Left + w / 2, .Top + h / 2)
                            Dim h1 As Single = Pos.Y - .Top
                            Dim h2 As Single = .Bottom - Pos.Y
                            Dim w1 As Single = Pos.X - .Left
                            Dim w2 As Single = .Right - Pos.X
                            rec = RectangleF.FromLTRB(Pos.X - w1 / ratio, Pos.Y - h1 / ratio, Pos.X + w2 / ratio, Pos.Y + h2 / ratio)
                        End With
                        If clsGeneric.Check_New_ScrView(attrData.TotalData.ViewStyle.ScrData.MapRectangle, rec) = True Then
                            .ScrView = rec
                            okf = True
                        End If
                    End With
            End Select

            If okf = True Then
                printMapScreen(True)
                Select Case temp_data.PrintMouseMode
                    Case enmPrintMouseMode.Fig
                        frm_Figure.Print_Fig()
                    Case enmPrintMouseMode.MultiObjectSelect
                        printSeletedMultiObject()
                End Select
            End If

        End If
    End Sub

    Private Sub mnuLocalChabge_Click(sender As Object, e As EventArgs) Handles mnuLocalChabge.CheckedChanged
        If mnuLocalChabge.Tag = "OFF" Then
            Return
        End If
        Dim f As Boolean = mnuLocalChabge.Checked
        If f = True Then
            MsgBox("局地変動モードは、階級区分モード（分割方法が自由設定の場合を除く）" + vbCrLf + "記号の大きさ、棒の高さモードで反映され、他の表示モードでは変化しません。")
        End If
        attrData.TotalData.ViewStyle.MapLegend.Base.ModeValueInScreenFlag = f
        printMapScreen(True)
    End Sub


    Private Sub mnuLocalChabge_Click_1(sender As Object, e As EventArgs) Handles mnuLocalChabge.Click

    End Sub

    Private Sub picMap_Click(sender As Object, e As EventArgs) Handles picMap.Click

    End Sub
End Class