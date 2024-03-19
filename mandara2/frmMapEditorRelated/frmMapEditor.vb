Public Enum mousePointingSituations
    down
    move
    up
    downAndMove
End Enum
Public Class frmMapEditor

    Public EditingMode As editingModes
    Public EditingMode_ObjectSub As EditingModes_ObjectSub
    Public EditingMode_LineSub As EditingModes_LineSub
    Public EditingMode_MultiObjectSub As EditingModes_MultiObjectSub
    Public EditingMode_MultiLineSub As EditingModes_MultiLineSub

    Public mousePointingSituation As mousePointingSituations
    Dim mouseDownPosition As Point
    Dim TileMap As clsTileMapService
    Dim ViewrMapFile As String
    Public Enum editingModes '編集モード
        ObjectSearchingMode 'オブジェクト編集検索モード
        ObjectEditingMode 'オブジェクト編集中
        MultiObjectsEditingMode '複数オブジェクト編集
        LineSearchingMode 'ライン編集検索モード
        LineEditingMode 'ライン編集モード
        MultiLinesEditingMode '複数ライン編集
        CompassDragMode '方位移動モード（オブジェクト編集検索モード/ライン編集検索モードから入る）
        Set_ClickObjectName 'オブジェクト名のクリック割り当てモード（オブジェクト編集検索モードから入る）
    End Enum
    ''' <summary>
    ''' オブジェクト編集モード時の、選択モード
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum EditingModes_ObjectSub
        LineSelectMode 'ライン選択モード
        AggregationObjectSelectMode '集成オブジェクトの構成オブジェクト選択モード
        ObjectCoreDragMode '代表点ドラッグモード
        Object_and_Line_DragMode 'オブジェクトと使用ラインをドラッグ
    End Enum
    ''' <summary>
    ''' 複数オブジェクト編集モード時の、選択モード
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum EditingModes_MultiObjectSub
        Pointing
        Rectangle
        Circle
        Polygon
        ObjectLineDragMode 'オブジェクト・ラインドラッグはPointingからのみ入れる。終了後はPointingに戻る
    End Enum
    ''' <summary>
    ''' 複数ライン編集モード時の、選択モード
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum EditingModes_MultiLineSub
        Pointing
        Rectangle
        Circle
        Polygon
        LineDragMode 'ラインドラッグはPointingからのみ入れる。終了後はPointingに戻る
    End Enum
    ''' <summary>
    ''' ライン編集モード時の、選択モード
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum EditingModes_LineSub
        SearchMode  '点・線分探索モード
        PointDragMode '点移動モード
        LineDragMode 'ライン全体ドラッグモード
    End Enum


    Public Structure MapEditor_Option_Data  'マップエディタのオプション
        Public Drag_Flag As Boolean
    End Structure
    Public MapEditor_Option As MapEditor_Option_Data

    Public Structure MapEditorEditing
        Public AggregationF As Boolean
        Public ObjectKind() As Boolean
        Public LineKind() As Boolean
        Public ObjectType As clsMapData.enmObjectGoupType_Data
        Public PointShape As Boolean
        Public LineShape As Boolean
        Public PolygonShape As Boolean
        Public LineNonConnected As Boolean
        Public LineOneConnected As Boolean
        Public LineBothConnected As Boolean
        Public LineLoop As Boolean
        Public LineObjectNoUsed As Boolean
        Public LineObjectOneUsed As Boolean
        Public LineObjectSecondUsed As Boolean
        Public LineObjectThirdUsed As Boolean
        Public EditTime As strYMD
        Public EditedLineTime_Flag As Boolean
        Public editEventStopF As Boolean
        Public unEditableVisible As Boolean
        Public Object_and_Line_DragEnabled As Boolean
    End Structure
    Public EditList As MapEditorEditing


    Dim MapData As clsMapData

    Dim MapEditorOpe As clsMapEditorOperation

    ''' <summary>
    '''　マップエディタがLoadされた時だけ呼び出される初期化プロシージャ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Default_Init()

        picMap.BackColor = clsSettings.Data.MapEditor.Backcolor.getColor

        ToolStrip.Visible = False
        mnuSaveMapFile.Enabled = False
        mnuSaveMapFileRename.Enabled = False
        mnuInsertMapFile.Enabled = False
        mnuMapFileProperty.Enabled = False
        mnuSaveAsMPFJ.Enabled = False
        mnuShapefileOut.Enabled = False
        mnuViewrGo.Enabled = False
        SplitContainerTotal.Visible = False

        SplitContainerMapAndProperty.SplitterDistance = SplitContainerMapAndProperty.Width * 0.75
        If MapData Is Nothing Then
            MapData = New clsMapData
            MapEditorOpe.initScrData(MapData, picMap)
        Else
            If MapData.NoDataFlag = False Then
                EditMappingIni()
                setEditPanel()
                MapEditorOpe.EditMapping(True)
                Cursor.Current = Cursors.Default
            End If
        End If
        menuEnable()


    End Sub

    Public Sub menuEnable()
        If MapData.NoDataFlag = True Then
            mnuFile.Enabled = True
            mnuEdit.Enabled = False
            mnuSettings.Enabled = False
            mnuObjectEdit.Enabled = False
            mnuImportData.Enabled = True
            mnuLineEdit.Enabled = False
            mnuTimeEditMode.Enabled = False
            mnuView.Enabled = False
        Else
            mnuFile.Enabled = True
            mnuEdit.Enabled = True
            mnuTimeEditMode.Enabled = True
            mnuImportData.Enabled = True
            mnuSettings.Enabled = True
            mnuObjectEditMode.Enabled = True
            mnuLineEditMode.Enabled = True
            mnuObjectEdit.Enabled = False
            mnuLineEdit.Enabled = False
            mnuView.Enabled = True
            mnuMapFileProperty.Enabled = True
            mnuSaveMapFile.Enabled = True
            mnuSaveMapFileRename.Enabled = True
            If MapData.Map.Kend > 0 Or MapData.Map.ALIN > 0 Then
                mnuInsertMapFile.Enabled = True
                mnuSaveAsMPFJ.Enabled = True
                mnuShapefileOut.Enabled = True
                mnuViewrGo.Enabled = True
            Else
                'mnuSaveMapFile.Enabled = False
                'mnuSaveMapFileRename.Enabled = False
                mnuInsertMapFile.Enabled = False
                mnuSaveAsMPFJ.Enabled = False
                mnuShapefileOut.Enabled = False
                mnuViewrGo.Enabled = False
            End If
            Select Case EditingMode
                Case editingModes.LineSearchingMode
                    mnuLineEdit.Enabled = True
                Case editingModes.LineEditingMode
                    mnuFile.Enabled = False
                    mnuEdit.Enabled = False
                    mnuLineEdit.Enabled = False
                    mnuTimeEditMode.Enabled = False
                    mnuImportData.Enabled = False
                    mnuSettings.Enabled = False
                Case editingModes.ObjectSearchingMode
                    mnuObjectEdit.Enabled = True
                Case editingModes.ObjectEditingMode
                    mnuFile.Enabled = False
                    mnuEdit.Enabled = False
                    mnuObjectEdit.Enabled = False
                    mnuTimeEditMode.Enabled = False
                    mnuImportData.Enabled = False
                    mnuSettings.Enabled = False
                Case editingModes.MultiLinesEditingMode, editingModes.MultiObjectsEditingMode
                    mnuFile.Enabled = False
                    'mnuEdit.Enabled = False
                    mnuObjectEditMode.Enabled = False
                    mnuLineEditMode.Enabled = False
                    mnuTimeEditMode.Enabled = False
                    mnuImportData.Enabled = False
                    mnuSettings.Enabled = False
                Case editingModes.Set_ClickObjectName
                    mnuFile.Enabled = False
                    mnuEdit.Enabled = False
                    mnuObjectEditMode.Enabled = False
                    mnuLineEditMode.Enabled = False
                    mnuTimeEditMode.Enabled = False
                    mnuImportData.Enabled = False
                    mnuSettings.Enabled = False
                Case editingModes.CompassDragMode

            End Select
        End If
    End Sub


    Private Sub EditMappingIni()
        EditingMode = editingModes.ObjectSearchingMode
        tsbObjectEditMode.Checked = True
        mnuLineEndPointShow.Checked = clsSettings.Data.MapEditor.LineEndPointVisible
        mnuObjectNameVisible.Checked = clsSettings.Data.MapEditor.ObjectNameVisibleFlag
        If MapData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
            tsbBackImage.Enabled = False
        Else
            tsbBackImage.Enabled = True
        End If
        MapEditorOpe.initScrData(MapData, picMap)


        With EditList
            ReDim .ObjectKind(MapData.Map.OBKNum - 1)
            clsGeneric.FillArray(.ObjectKind, True)
            ReDim .LineKind(MapData.Map.LpNum - 1)
            clsGeneric.FillArray(.LineKind, True)
            .ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject
            .PointShape = True
            .LineShape = True
            .PolygonShape = True
            .LineNonConnected = True
            .LineOneConnected = True
            .LineBothConnected = True
            .LineLoop = True
            .LineObjectNoUsed = True
            .LineObjectOneUsed = True
            .LineObjectSecondUsed = True
            .LineObjectThirdUsed = True
            .EditTime = clsTime.GetYMD(0, 0, 0)
            .EditedLineTime_Flag = True
            .unEditableVisible = True
            .AggregationF = MapData.Check_AggregateObjectType_Exists
        End With

        mousePointingSituation = mousePointingSituations.up

    End Sub
    ''' <summary>
    ''' マップエディタを開く(ファイルパス)
    ''' </summary>
    ''' <param name="DefoFilename">ファイル名を指定して開く場合はファイルパス、そうでない場合は""</param>
    ''' <param name="_TileMap">タイルのクラス</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal DefoFilename As String, ByVal _TileMap As clsTileMapService)
        SplitContainerTotal.Visible = False
        TileMap = _TileMap
        MapEditorOpe = New clsMapEditorOperation(Me, TileMap)
        ViewrMapFile = ""
        If DefoFilename <> "" Then
            openFile(DefoFilename)
        End If
        Return Me.ShowDialog
    End Function
    ''' <summary>
    ''' マップエディタを開く（clsMapdata）
    ''' </summary>
    ''' <param name="DefoFilename">ファイル名を指定して開く場合はファイルパス、そうでない場合は""</param>
    ''' <param name="_TileMap">タイルのクラス</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByRef mpData As clsMapData, ByVal _TileMap As clsTileMapService)
        SplitContainerTotal.Visible = False
        TileMap = _TileMap
        MapEditorOpe = New clsMapEditorOperation(Me, TileMap)
        ViewrMapFile = ""
        MapData = mpData
        Me.Text = MapData.Map.FileName
        EditMappingIni()
        setEditPanel()
        MapEditorOpe.EditMapping(True)
        Return Me.ShowDialog
    End Function
    ''' <summary>
    ''' 白地図初期属性データに移る場合は、ファイルパスを返す。そうでない場合は""
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getResult() As String
        Return ViewrMapFile
    End Function
    Private Sub frmMapEditor_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim btn As Button
        Select Case e.KeyCode
            Case Keys.Escape
                Select Case EditingMode
                    Case editingModes.LineEditingMode
                        btn = btnLineCancel
                    Case editingModes.ObjectEditingMode
                        If MapData.Map.Time_Mode = True Then
                            btn = btnObjectCancelTime
                        Else
                            btn = btnObjectCancel
                        End If
                    Case editingModes.Set_ClickObjectName
                        My.Forms.frmMED_ClickSetObjName.Focus()
                        btn = My.Forms.frmMED_ClickSetObjName.btnCancel
                    Case editingModes.MultiLinesEditingMode
                        btn = btnMultiLineEnd
                    Case editingModes.MultiObjectsEditingMode
                        btn = btnMultiPbjectsEnd
                End Select
            Case Keys.Enter
                Select Case EditingMode
                    Case editingModes.LineEditingMode
                        btn = btnLineRegist
                    Case editingModes.ObjectEditingMode
                        If MapData.Map.Time_Mode = True Then
                            btn = btnObjrectRegistTime
                        Else
                            btn = btnObjectRegist
                        End If
                    Case editingModes.MultiLinesEditingMode
                        btn = btnMultiLineExe
                    Case editingModes.MultiObjectsEditingMode
                        btn = btnMultiObjectsExe
                End Select
        End Select
        If btn Is Nothing = False Then
            If btn.Focused = True Then
                btn.PerformClick()
            Else
                btn.Focus()
            End If
        End If
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblPicMap.Parent = picMap

        With MapEditor_Option  'マップエディタのオプション
            .Drag_Flag = False


        End With
        SetMapFileHistorytoMenu()

        '新規オブジェクトボタンをToolStrip1に追加
        ToolStrip.Items.Insert(12, New ToolStripControlHost(Me.btnNewObjectAndLine))

        'オブジェクト等プロパティウィンドウをscPropertyAndDefAttribute.panel1に割り当てる
        pnlPropertyWindow.Parent = scPropertyAndDefAttribute.Panel1
        pnlPropertyWindow.Dock = DockStyle.Fill
        pnlObjectTimeEdit.Parent = scPropertyAndDefAttribute.Panel1
        pnlObjectTimeEdit.Dock = DockStyle.Top
        pnlObjectEdit.Parent = scPropertyAndDefAttribute.Panel1
        pnlObjectEdit.Dock = DockStyle.Top
        pnlLineEdit.Parent = scPropertyAndDefAttribute.Panel1
        pnlLineEdit.Dock = DockStyle.Top
        pnlMultiObjects.Parent = scPropertyAndDefAttribute.Panel1
        pnlMultiObjects.Dock = DockStyle.Top
        pnlMultiLines.Parent = scPropertyAndDefAttribute.Panel1
        pnlMultiLines.Dock = DockStyle.Top

        Dim lblList() As String = {"オブジェクト名検索", "結合", "境界線自動設定", "代表点を重心に", _
                                   "オブジェクトグループ変更", "削除", "使用ラインごと削除", "外側オブジェクト削除", _
                                   "メッシュオブジェクト作成", "使用ライン線種変更", "集成オブジェクトを構成", _
                                   "選択オブジェクト名表示", "初期属性入力"}
        With lbMultiObjectsCommand.Items
            .Clear()
            For i As Integer = 0 To lblList.GetUpperBound(0)
                .Add((i + 1).ToString + ":" + lblList(i))
            Next
        End With

        Dim lblMultiLineList() As String = {"線種設定", "分割＆結節点", "ラインを交点で切断", _
                                            "ラインの共有部分を別ラインに", "ライン結合", "端点結合", "ポイント・ループ間引き",
                                            "座標表示", "削除"}
        With lbMultiLineCommand.Items
            .Clear()
            For i As Integer = 0 To lblMultiLineList.GetUpperBound(0)
                .Add((i + 1).ToString + ":" + lblMultiLineList(i))
            Next
        End With
        If Me.Text = "" Then
            Me.Text = "マップエディタ"
        End If
        Default_Init()
        ProgressLabel.Left = 0
        ProgressLabel.Top = MenuStrip1.Height
    End Sub
    Private Sub recentUsedFileOpen(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ファイル履歴のクリックイベント
        openFile(sender.tag)
    End Sub


    Private Sub picMap_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picMap.MouseLeave
        lblPicMap.Visible = False
    End Sub

    Private Sub picMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseDown
        'マウスダウンイベント
        If IsNothing(MapData) = False Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                mousePointingSituation = mousePointingSituations.down
                mouseDownPosition = e.Location
                If EditingMode = editingModes.LineEditingMode And EditingMode_LineSub = EditingModes_LineSub.SearchMode Then
                    'ライン編集モードでサーチモードの場合で、線分が近い場合はマウスダウンで点を生成する
                    MapEditorOpe.picMapMouseDownLineEditingMode(e.Location)
                End If
            End If
        End If
    End Sub

    Private Sub picMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseMove
        'マウスムーブイベント
        Static mousePreviousPosition As Point

        If IsNothing(MapData) = False Then
            Select Case mousePointingSituation
                Case mousePointingSituations.up
                    'マウスアップで移動中
                    MapEditorOpe.picMapMouseMovePointInformation(e.Location) '位置情報の表示
                    Select Case EditingMode
                        Case editingModes.ObjectSearchingMode, editingModes.Set_ClickObjectName
                            'オブジェクト検索モード/'オブジェクト名のクリック割り当てモード
                            MapEditorOpe.picMapMouseMoveObjectSearchMode(e.Location)
                        Case editingModes.ObjectEditingMode
                            'オブジェクト編集モード、代表点、ライン番号等の情報をラベルに表示
                            MapEditorOpe.LabelOfObjectEditingMode(e.Location)
                        Case editingModes.LineSearchingMode
                            'ライン検索モードでライン番号をラベルに表示
                            MapEditorOpe.picMapMouseMoveLineSearchMode(e.Location)
                        Case editingModes.LineEditingMode
                            'ライン編集モードでラインの最寄りポイントまたは線分を強調表示
                            MapEditorOpe.picMapMouseMoveLineEditingMode(e.Location)
                        Case editingModes.MultiObjectsEditingMode
                            '、複数オブジェクト選択モード
                            Select Case EditingMode_MultiObjectSub
                                Case EditingModes_MultiObjectSub.Pointing
                                    MapEditorOpe.picMapMouseMoveObjectSearchMode(e.Location)
                                Case EditingModes_MultiObjectSub.Rectangle, EditingModes_MultiObjectSub.Circle, EditingModes_MultiObjectSub.Polygon
                                    MapEditorOpe.picMapMouseMoveObjectSearchMode(e.Location)
                                    MapEditorOpe.picMapMouseMoveMultiObjectSelect_Shape(e.Location, False, False)
                            End Select
                        Case editingModes.MultiLinesEditingMode
                            '、複数ライン選択モード
                            Select Case EditingMode_MultiLineSub
                                Case EditingModes_MultiLineSub.Pointing
                                    MapEditorOpe.picMapMouseMoveLineSearchMode(e.Location)
                                Case EditingModes_MultiLineSub.Rectangle, EditingModes_MultiLineSub.Circle, EditingModes_MultiLineSub.Polygon
                                    MapEditorOpe.picMapMouseMoveLineSearchMode(e.Location)
                                    MapEditorOpe.picMapMouseMoveMultiLineSelect_Shape(e.Location, False, False)
                            End Select
                    End Select
                Case mousePointingSituations.down
                    'マウスダウンの直後
                    If e.Location.Equals(mouseDownPosition) = False Then
                        '前の座標から移動した場合
                        'ドラッグ用に、現在の地図画面をbackCanvasに待避
                        MapEditorOpe.picMapMouseDownAndReservePicMap(mouseDownPosition)
                        mousePreviousPosition = e.Location
                    End If
                Case mousePointingSituations.downAndMove
                    'マウスダウンとドラッグ開始後
                    If e.Location.Equals(mousePreviousPosition) = False Then
                        MapEditorOpe.picMapMouseDownAndMove(e.Location, mouseDownPosition)
                        mousePreviousPosition = e.Location
                    End If
            End Select
        End If
    End Sub
    Private Sub picMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseUp
        'マウスアップイベント
        If IsNothing(MapData) = False Then
            Dim mouseUpPosition As Point = e.Location
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left
                    '左クリックの場合－－－－－－－－－－－－－－－－
                    Select Case mousePointingSituation
                        Case mousePointingSituations.downAndMove
                            'ドラッグの場合
                            '左クリックを上げた場合は確定
                            MapEditorOpe.picMapMouseUpDragAndMove(mouseUpPosition, mouseDownPosition, False)
                        Case mousePointingSituations.down
                            '左クリックの場合、オブジェクトの選択
                            Dim originalP As PointF = MapEditorOpe.ScrData.getSRXY(New Point(e.X, e.Y))
                            Select Case EditingMode
                                Case editingModes.ObjectSearchingMode, editingModes.Set_ClickObjectName
                                    MapEditorOpe.selectObject(e.Location) 'オブジ ェクトを選択する
                                Case editingModes.MultiObjectsEditingMode
                                    Select Case EditingMode_MultiObjectSub
                                        Case EditingModes_MultiObjectSub.Pointing
                                            MapEditorOpe.selectObject(e.Location) '複数オブジェクト選択モードでオブジェクトをクリック選択する
                                        Case EditingModes_MultiObjectSub.Rectangle, EditingModes_MultiObjectSub.Circle, EditingModes_MultiObjectSub.Polygon
                                            MapEditorOpe.picMapMouseMoveMultiObjectSelect_Shape(e.Location, True, False)
                                    End Select
                                Case editingModes.ObjectEditingMode
                                    If EditingMode_ObjectSub = EditingModes_ObjectSub.LineSelectMode Then
                                        MapEditorOpe.selectObjectLine(e.Location) 'オブジェクトの使用ラインを選択する
                                    ElseIf EditingMode_ObjectSub = EditingModes_ObjectSub.AggregationObjectSelectMode Then
                                        MapEditorOpe.selectAggrObjectComponentObject(e.Location) 'オブジェクトの使用ラインを選択する
                                    End If
                                Case editingModes.LineSearchingMode
                                    MapEditorOpe.selectLine(e.Location) 'ラインを選択する
                                Case editingModes.MultiLinesEditingMode
                                    Select Case EditingMode_MultiLineSub
                                        Case EditingModes_MultiLineSub.Pointing
                                            MapEditorOpe.selectLine(e.Location) '複数ライン選択モードでラインをクリック選択する
                                        Case EditingModes_MultiLineSub.Rectangle, EditingModes_MultiLineSub.Circle, EditingModes_MultiLineSub.Polygon
                                            MapEditorOpe.picMapMouseMoveMultiLineSelect_Shape(e.Location, True, False)
                                    End Select
                            End Select
                    End Select
                Case Windows.Forms.MouseButtons.Right
                    '右クリックの場合－－－－－－－－－－－－－－－－
                    Select Case mousePointingSituation
                        Case mousePointingSituations.downAndMove
                            'ドラッグの場合
                            '右クリックした場合は元の位置に戻る
                            MapEditorOpe.picMapMouseUpDragAndMove(mouseDownPosition, mouseDownPosition, True)
                        Case mousePointingSituations.up
                            '右クリックした場合
                            MapEditorOpe.picMapClickRightButton(mouseUpPosition)
                    End Select
            End Select
            mousePointingSituation = mousePointingSituations.up
            lblPicMap.Visible = False
        End If
    End Sub
    Private Sub picMap_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseWheel

        If mousePointingSituation = mousePointingSituations.up Then
            MapEditorOpe.changeViewScale(e.Location, e.Delta)
        End If

    End Sub



    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click

        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = clsGeneric.Get_MapFolder
        ofd.Filter = "MANDARA地図ファイル(*.mpf?)|*.mpf?|圧縮地図ファイル(*.mpfz)|*.mpfz|非圧縮ファイル(*.mpfx)|*.mpfx|旧地図ファイル(*.mpf)|*.mpf"
        If ofd.ShowDialog() = DialogResult.OK Then
            openFile(ofd.FileName)
            clsSettings.Data.Directory.Mapfile = System.IO.Path.GetDirectoryName(ofd.FileName)
        End If
    End Sub
    Private Sub openFile(ByVal fileName As String)

        Cursor.Current = Cursors.WaitCursor
        Try
            MapData = New clsMapData(fileName)
        Catch ex As Exception
            MsgBox(ex.Message)
            SplitContainerTotal.Visible = False
            Return
        End Try
        MapData.Map.FileName = System.IO.Path.GetFileName(fileName)
        MapData.Map.FullPath = fileName
        Me.Text = MapData.Map.FileName
        ReDim Preserve MapData.MPObj(MapData.Map.Kend - 1)
        EditMappingIni()
        setEditPanel()
        replaceMapFileHistory(fileName)
        MapEditorOpe.EditMapping(True)

        Cursor.Current = Cursors.Default

    End Sub
    ''' <summary>
    ''' 最近使ったファイルのメニュー項目の作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMapFileHistorytoMenu()
        mnuRecentUsedFile.DropDownItems.Clear()
        Dim FileHistory() As String = clsSettings.Data.MapEditor.MapFileHistory.Split("|")
        ReDim Preserve FileHistory(8)
        clsSettings.Data.MapEditor.MapFileHistory = String.Join("|", FileHistory)
        For i As Integer = 0 To FileHistory.GetUpperBound(0)
            Dim menuRecentFile As New ToolStripMenuItem
            If FileHistory(i) <> "" Then
                menuRecentFile.Text = FileHistory(i) + "(&" + (i + 1).ToString + ")"
                menuRecentFile.Tag = FileHistory(i)
            Else
                menuRecentFile.Text = ""
                menuRecentFile.Tag = ""
            End If
            AddHandler menuRecentFile.Click, AddressOf recentUsedFileOpen
            '「新規作成」を「ファイル」へ追加
            mnuRecentUsedFile.DropDownItems.Add(menuRecentFile)
        Next
    End Sub
    ''' <summary>
    ''' 最近使ったファイルのオーダー変更
    ''' </summary>
    ''' <param name="NewTopPath">トップに来るファイルパス</param>
    ''' <remarks></remarks>
    Private Sub replaceMapFileHistory(ByVal NewTopPath As String)
        Dim FileHistory() As String = clsSettings.Data.MapEditor.MapFileHistory.Split("|")
        Dim lastp As Integer = FileHistory.GetUpperBound(0)
        For i As Integer = 0 To FileHistory.GetUpperBound(0)
            If FileHistory(i) = NewTopPath Then
                lastp = i
                Exit For
            End If
        Next

        For i As Integer = lastp - 1 To 0 Step -1
            FileHistory(i + 1) = FileHistory(i)
        Next
        FileHistory(0) = NewTopPath
        clsSettings.Data.MapEditor.MapFileHistory = String.Join("|", FileHistory)
        SetMapFileHistorytoMenu()

    End Sub

    Public Sub setEditPanelLineKind()
        clbLineKindEdit.BeginUpdate()
        clbLineKindEdit.EventStop = True
        clbLineKindEdit.Items.Clear()
        For i As Integer = 0 To MapData.Map.LpNum - 1
            clbLineKindEdit.Items.Add(MapData.LineKind(i).Name, EditList.LineKind(i))
        Next
        clbLineKindEdit.EndUpdate()
        clbLineKindEdit.EventStop = False
    End Sub
    Public Sub setEditPanelObjectKind()
        clbObjectKindEdit.BeginUpdate()
        clbObjectKindEdit.EventStop = True
        clbObjectKindEdit.Items.Clear()
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            clbObjectKindEdit.Items.Add(MapData.ObjectKind(i).Name, EditList.ObjectKind(i))
        Next
        clbObjectKindEdit.EndUpdate()
        clbObjectKindEdit.EventStop = False

    End Sub
    Public Sub setEditPanel()

        With EditList
            .editEventStopF = True
            setEditPanelObjectKind()
            setEditPanelLineKind()


            If .ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                rbObjTypeEditNormal.Checked = True
            Else
                rbObjTypeEditAggregation.Checked = True
            End If
            pnlObjTypeEdit.Visible = .AggregationF
            cbPointShapeEdit.Checked = .PointShape
            cbPolygonShapeEdit.Checked = .PolygonShape
            cbLineShapeEdit.Checked = .LineShape

            cbLineBothConnectEdit.Checked = .LineBothConnected
            cbLineLoopEdit.Checked = .LineLoop
            cbLineOneConnectEdit.Checked = .LineOneConnected
            cbLineNonConnectEdit.Checked = .LineNonConnected

            cbLineObjectNoUsedEdit.Checked = .LineObjectNoUsed
            cbLineObjectOneUsedEdit.Checked = .LineObjectOneUsed
            cbLineObjectSecondUsedEdit.Checked = .LineObjectSecondUsed
            cbLineObjectThirdUsedEdit.Checked = .LineObjectThirdUsed

            pnEditTime.Visible = MapData.Map.Time_Mode
            dbdtpEditTime.Value = .EditTime
            cbLineTime.Checked = .EditedLineTime_Flag
            cbUnEditableVisible.Checked = .unEditableVisible

        End With

        'If MapData.Map.Kend > 0 Or MapData.Map.ALIN > 0 Then
        '    ToolStrip.Visible = True
        '    SplitContainerTotal.Visible = True
        'Else
        ToolStrip.Visible = True
        SplitContainerTotal.Visible = True
        'End If
        menuEnable()
        mnuTimeEditMode.Checked = MapData.Map.Time_Mode
        mnuObjectTimeEdit.Enabled = MapData.Map.Time_Mode

        MapEditorOpe.setRightPanelVisible()

        EditList.editEventStopF = False
    End Sub
    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveMapFileRename.Click, mnuSaveAsMPFJ.Click
        Dim emes As String
        Cursor.Current = Cursors.WaitCursor
        Dim fg As Boolean = MapData.ErrorCheck_Mapfile(emes)
        Cursor.Current = Cursors.Default
        If fg = False Then
            If emes <> "" Then
                clsGeneric.Message(Me, "地図ファイルに問題があります。", emes, False, True)
            End If
            Return
        End If

        Save(True, (sender.name = "mnuSaveAsMPFJ"))
    End Sub


    Private Sub mnuSaveAsMPFJ_Click(sender As Object, e As EventArgs) Handles mnuSaveAsMPFJ.Click

    End Sub

    Private Function Save(ByVal OKmessageF As Boolean, ByVal mpfjFlag As Boolean) As Boolean
        Dim Filename As String = Me.MapData.Map.FileName
        Dim sfd As New SaveFileDialog()
        If mpfjFlag = True Then
            Filename = System.IO.Path.GetFileNameWithoutExtension(Filename) + ".mpfj"
            sfd.Filter = "mpfj地図ファイル(*.mpfj)|*.mpfj"
        Else
            If LCase(System.IO.Path.GetExtension(Filename)) = ".mpf" Then
                Filename = System.IO.Path.GetFileNameWithoutExtension(Filename) + ".mpfz"
            End If
            sfd.Filter = "圧縮地図ファイル(*.mpfz)|*.mpfz|非圧縮地図ファイル(*.mpfx)|*.mpfx"
        End If
        sfd.InitialDirectory = clsGeneric.Get_MapFolder
        sfd.FileName = Filename
        sfd.DefaultExt = System.IO.Path.GetExtension(Filename)
        Select Case sfd.DefaultExt
            Case "mpfz"
                sfd.FilterIndex = 1
            Case "mpfx"
                sfd.FilterIndex = 2
        End Select
        If sfd.ShowDialog() = DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            MapData.Map.FileName = System.IO.Path.GetFileName(sfd.FileName)
            MapData.Map.FullPath = sfd.FileName
            MapData.Map.MPVersion = 12
            Dim f As Boolean = MapData.SaveMapFile(sfd.FileName)
            Cursor.Current = Cursors.Default
            If f = True Then
                If mpfjFlag = False Then
                    clsSettings.Data.Directory.Mapfile = System.IO.Path.GetDirectoryName(sfd.FileName)
                    replaceMapFileHistory(sfd.FileName)
                End If
                Me.Text = MapData.Map.FileName
                If OKmessageF = True Then
                    MsgBox(sfd.FileName + "を保存しました。")
                End If
                Return True
            Else
                MsgBox(sfd.FileName + "は保存できませんでした。", MsgBoxStyle.Exclamation)
            End If
        End If
        Return False
    End Function


    Private Sub SplitContainer1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainerTotal.Resize
        If EditList.editEventStopF = False And Me.Visible = True Then
            MapEditorOpe.EditMapping(False)
        End If
    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainerTotal.SplitterMoved, SplitContainerMapAndProperty.SplitterMoved
        If EditList.editEventStopF = False And Me.Visible = True Then
            MapEditorOpe.EditMapping(False)
        End If
    End Sub

    Private Sub tsbAllShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAllShow.Click
        MapEditorOpe.showAllMapArea()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbPolygonShapeEdit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                cbPolygonShapeEdit.CheckedChanged, cbPointShapeEdit.CheckedChanged, cbLineShapeEdit.CheckedChanged, _
                cbLineBothConnectEdit.CheckedChanged, cbLineLoopEdit.CheckedChanged, cbLineNonConnectEdit.CheckedChanged, _
                cbLineObjectNoUsedEdit.CheckedChanged, cbLineObjectOneUsedEdit.CheckedChanged, cbLineObjectSecondUsedEdit.CheckedChanged, _
                cbLineObjectThirdUsedEdit.CheckedChanged, cbLineOneConnectEdit.CheckedChanged, _
                rbObjTypeEditAggregation.CheckedChanged, rbObjTypeEditNormal.CheckedChanged

        If EditList.editEventStopF = False And Me.Visible = True Then
            With EditList
                If .editEventStopF = False Then
                    .PointShape = cbPointShapeEdit.Checked
                    .PolygonShape = cbPolygonShapeEdit.Checked
                    .LineShape = cbLineShapeEdit.Checked

                    .LineBothConnected = cbLineBothConnectEdit.Checked
                    .LineLoop = cbLineLoopEdit.Checked
                    .LineOneConnected = cbLineOneConnectEdit.Checked
                    .LineNonConnected = cbLineNonConnectEdit.Checked

                    .LineObjectNoUsed = cbLineObjectNoUsedEdit.Checked
                    .LineObjectOneUsed = cbLineObjectOneUsedEdit.Checked
                    .LineObjectSecondUsed = cbLineObjectSecondUsedEdit.Checked
                    .LineObjectThirdUsed = cbLineObjectThirdUsedEdit.Checked

                    If rbObjTypeEditNormal.Checked = True Then
                        .ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject
                    Else
                        .ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject
                    End If

                    .EditedLineTime_Flag = cbLineTime.Checked
                    MapEditorOpe.EditMapping(True)
                End If
            End With
        End If
    End Sub



    Private Sub dbdtpEditTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbdtpEditTime.ValueChanged
        EditList.EditTime = dbdtpEditTime.Value
        If EditList.editEventStopF = False Then
            'イベントを発生させる場合は描画
            MapEditorOpe.EditMapping(True)
        End If
    End Sub




    Private Sub clbObjectKindEdit_changed(ByVal sender As Object, ByVal e As CheckedListBoxExChangeEventArgs) Handles clbObjectKindEdit.changed

        For i As Integer = 0 To sender.items.count - 1
            EditList.ObjectKind(i) = e.ItemCheck(i)
        Next

        If EditList.editEventStopF = False And Me.Visible = True Then
            'イベントを発生させる場合は描画
            MapEditorOpe.EditMapping(True)
        End If
    End Sub



    Private Sub clbLineKindEdit_changed(ByVal sender As Object, ByVal e As CheckedListBoxExChangeEventArgs) Handles clbLineKindEdit.changed

        For i As Integer = 0 To sender.items.count - 1
            EditList.LineKind(i) = e.ItemCheck(i)
        Next

        If EditList.editEventStopF = False And Me.Visible = True Then
            'イベントを発生させる場合は描画
            MapEditorOpe.EditMapping(True)
        End If
    End Sub

    Private Sub tsbObjectEditMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbObjectEditMode.Click, tsbObjectEditMode.CheckedChanged
        If tsbObjectEditMode.Checked = True Then
            EditingMode = editingModes.ObjectSearchingMode
            btnNewObjectAndLine.Text = "新規オブジェクト"
            tsbLineEditMode.Checked = False
            mnuObjectEditMode.Checked = True
            mnuLineEditMode.Checked = False
        Else
            tsbLineEditMode.Checked = True
        End If
        menuEnable()
    End Sub

    Private Sub tsbLineEditMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbLineEditMode.Click, tsbLineEditMode.CheckedChanged
        If tsbLineEditMode.Checked = True Then
            EditingMode = editingModes.LineSearchingMode
            btnNewObjectAndLine.Text = "新規ライン"
            tsbObjectEditMode.Checked = False
            mnuLineEditMode.Checked = True
            mnuObjectEditMode.Checked = False
        Else
            tsbObjectEditMode.Checked = True
        End If
        menuEnable()
    End Sub



    Private Sub btnObjrectRegist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObjectRegist.Click, btnObjrectRegistTime.Click

        'オブジェクトの登録
        MapEditorOpe.registEditingObject()
    End Sub

    Private Sub btnObjectCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObjectCancel.Click, btnObjectCancelTime.Click

        'オブジェクト編集のキャンセル

        MapEditorOpe.cancelEditingObject()

    End Sub

    Private Sub btnObjectDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObjectDelete.Click, btnObjectDeleteTime.Click

        MapEditorOpe.deleteEditingObject()
    End Sub


    Private Sub btnNewObjectAndLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewObjectAndLine.Click

        If EditingMode = editingModes.ObjectSearchingMode Then
            MapEditorOpe.New_Object_DataSet()
        ElseIf EditingMode = editingModes.LineSearchingMode Then
            MapEditorOpe.New_Line_DataSet()
        End If
    End Sub


    Private Sub cboObjectKind_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboObjectKind.SelectedIndexChanged, cbObjectGroupTime.SelectedIndexChanged

        MapEditorOpe.checkCboObjectKindChange(sender)
    End Sub

    Private Sub btnAutoBoundary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoBoundary.Click

        MapEditorOpe.Boundary_Auto()
    End Sub

    Private Sub btnCenterGrabityPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCenterGrabityPoint.Click

        MapEditorOpe.centerPointGravity()
    End Sub



    Private Sub btnObjNameTimeSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObjNameTimeSet.Click

        MapEditorOpe.SetObjNameTime()
    End Sub

    Private Sub btnSuccession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuccession.Click

        MapEditorOpe.SetObjectSuccession()
    End Sub




    Private Sub btnCenterPointTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCenterPointTime.Click
        MapEditorOpe.SetObjectCenterPointTime()
    End Sub

    Private Sub btnTimeObject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeObject.Click
        MapEditorOpe.ShowObjectTimeSeries()

    End Sub




    Private Sub btnLineCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLineCancel.Click

        MapEditorOpe.cancelEditingLine()
    End Sub

    Private Sub btnLineDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLineDelete.Click

        MapEditorOpe.deleteEditingLine()
    End Sub

    Private Sub btnLineRegist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLineRegist.Click

        MapEditorOpe.registEditingLine()
    End Sub




    Private Sub btnNode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNode.Click

        MapEditorOpe.nodarize()
    End Sub

    Private Sub btnLineDivide_and_Node_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLineDivide_and_Node.Click
        MapEditorOpe.LineDivide_and_Nodarize()
    End Sub

    Private Sub tsbMultiSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbMultiSelect.Click, tsbMultiSelect.CheckedChanged

        '複数選択ボタン
        If EditList.editEventStopF = False Then
            MapEditorOpe.multiSelectButton(tsbMultiSelect.Checked)
        End If
    End Sub

    Private Sub btnMultiPbjectsEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMultiPbjectsEnd.Click

        '複数オブジェクト編集の終了
        tsbMultiSelect.Checked = False
    End Sub

    Private Sub btnMultiObjectsExe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMultiObjectsExe.Click

        If lbMultiObjectsCommand.SelectedIndex = -1 Then
            Dim msgText As String = "処理を選択してください"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
        Else
            MapEditorOpe.MulitObjectsCommand(lbMultiObjectsCommand.SelectedItem)
        End If
    End Sub

    Private Sub rbMultiObjectSelectMode_Pointing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                            rbMultiObjectSelectMode_Pointing.CheckedChanged, rbMultiObjectSelectMode_Rectangle.CheckedChanged, _
                            rbMultiObjectSelectMode_Circle.CheckedChanged, rbMultiObjectSelectMode_Polygon.CheckedChanged
        If rbMultiObjectSelectMode_Pointing.Checked = True Then
            EditingMode_MultiObjectSub = EditingModes_MultiObjectSub.Pointing
        ElseIf rbMultiObjectSelectMode_Rectangle.Checked = True Then
            EditingMode_MultiObjectSub = EditingModes_MultiObjectSub.Rectangle
        ElseIf rbMultiObjectSelectMode_Circle.Checked = True Then
            EditingMode_MultiObjectSub = EditingModes_MultiObjectSub.Circle
        ElseIf rbMultiObjectSelectMode_Polygon.Checked = True Then
            EditingMode_MultiObjectSub = EditingModes_MultiObjectSub.Polygon
        End If

    End Sub





    Private Sub lbMultiObjectsCommand_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbMultiObjectsCommand.MouseEnter
        lbMultiObjectsCommand.Focus()
    End Sub


    Private Sub rbMultiLineSelectMode_Pointing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    rbMultiLineSelectMode_Pointing.CheckedChanged, rbMultiLineSelectMode_Rectangle.CheckedChanged, _
                    rbMultiLineSelectMode_Circle.CheckedChanged, rbMultiLineSelectMode_Polygon.CheckedChanged
        Select Case True
            Case rbMultiLineSelectMode_Pointing.Checked
                EditingMode_MultiLineSub = EditingModes_MultiLineSub.Pointing
            Case rbMultiLineSelectMode_Rectangle.Checked
                EditingMode_MultiLineSub = EditingModes_MultiLineSub.Rectangle
            Case rbMultiLineSelectMode_Circle.Checked
                EditingMode_MultiLineSub = EditingModes_MultiLineSub.Circle
            Case rbMultiLineSelectMode_Polygon.Checked
                EditingMode_MultiLineSub = EditingModes_MultiLineSub.Polygon
        End Select


    End Sub

    Private Sub btnMultiLineEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMultiLineEnd.Click
        '複数ライン編集の終了
        tsbMultiSelect.Checked = False
    End Sub

    Private Sub btnMultiLineExe_Click(sender As Object, e As EventArgs) Handles btnMultiLineExe.Click

        If lbMultiLineCommand.SelectedIndex = -1 Then
            Dim msgText As String = "処理を選択してください"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
        Else
            MapEditorOpe.MulitLineCommand(lbMultiLineCommand.SelectedItem)
        End If
    End Sub

    Private Sub btnLineTimeKindSet_Click(sender As Object, e As EventArgs) Handles btnLineTimeKindSet.Click
        MapEditorOpe.LineTimeKindSet()
    End Sub



    Private Sub mnuSettingObjectGroup_Click(sender As Object, e As EventArgs) Handles mnuSettingObjectGroup.Click

        Dim agf As Boolean = Me.EditList.AggregationF

        If MapEditorOpe.SettingObjectGroup = True Then
            Me.EditList.AggregationF = MapData.Check_AggregateObjectType_Exists

            If agf <> Me.EditList.AggregationF Then
                If EditList.AggregationF = False And EditList.ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                    EditList.ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject
                End If
                setEditPanel()
            End If

            MapEditorOpe.EditMapping(True)
        End If

    End Sub






    Private Sub mnuSettingLineKind_Click(sender As Object, e As EventArgs) Handles mnuSettingLineKind.Click
        MapEditorOpe.SettingLineKind()
    End Sub


    Private Sub mnuCombineLineKind_Click(sender As Object, e As EventArgs) Handles mnuCombineLineKind.Click
        MapEditorOpe.CombineLineKind()
    End Sub

    Private Sub mnuCombineObjectGroup_Click(sender As Object, e As EventArgs) Handles mnuCombineObjectGroup.Click
        MapEditorOpe.CombineObjectKind()
    End Sub

    Private Sub ProgressKtGrid1_Load(sender As Object, e As EventArgs)

    End Sub


    Private Sub mnuDefAttData_Click(sender As Object, e As EventArgs) Handles mnuDefAttData.Click
        If MapData.Map.Time_Mode = True Then
            MapEditorOpe.EditingDefPointAttData()

        Else

            MapEditorOpe.EditingDefAttData()
        End If
    End Sub



    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        If MapData Is Nothing Then

        Else
            If MapData.NoDataFlag = False Then
                If MsgBox("現在の地図データは破棄されます。", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    MapData.init_MapData()
                    Me.Text = "マップエディタ"
                    Default_Init()
                End If
            End If
        End If
    End Sub





    Private Sub mnuCompassSetting_Click(sender As Object, e As EventArgs) Handles mnuCompassSetting.Click
        MapEditorOpe.SettingCompass()
    End Sub

    Private Sub mnuUndo_Click(sender As Object, e As EventArgs) Handles mnuUndo.Click
        MapEditorOpe.Undo()
    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub lbMultiObjectsCommand_MouseMove(sender As Object, e As MouseEventArgs) Handles lbMultiObjectsCommand.MouseMove
        Dim i As Integer = lbMultiObjectsCommand.IndexFromPoint(New Point(e.X, e.Y))
        If i <> -1 Then
            Dim ItemText As String = lbMultiObjectsCommand.Items(i)
            Dim co As Integer = ItemText.IndexOf(":")
            If co <> -1 Then
                ItemText = ItemText.Substring(co + 1)
            End If
            Dim tiptext As String = ""
            Select Case ItemText
                Case "オブジェクト名検索"
                    tiptext = "オブジェクト名から検索して選択します。"
                Case "結合"
                    If MapData.Map.Time_Mode = True Then
                        tiptext = "選択したオブジェクトを結合し、オブジェクトに時間設定を行います。"
                    Else
                        tiptext = "選択されたオブジェクトを結合し、新規オブジェクトとして登録します｡"
                    End If
                Case "境界線自動設定"
                    tiptext = "選択したオブジェクトの代表点を囲むように境界線を設定します。"
                Case "代表点を重心に"
                    tiptext = "選択したオブジェクトの代表点を面の重心に設定します。"
                Case "オブジェクトグループ変更"
                    tiptext = "選択したオブジェクトのオブジェクトクループを変更します。"
                Case "削除"
                    tiptext = "選択したオブジェクトをすべて削除します。"
                Case "使用ラインごと削除"
                    If EditList.ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                        tiptext = "選択したオブジェクトを削除し、使用するラインが他のオブジェクトと共有されていなければ同時に削除します。"
                    Else
                        tiptext = "選択した集成オブジェクトを削除し、同時に集成オブジェクトを構成するオブジェクを削除します。" _
                            & vbCrLf & "さらに、その使用するラインが他のオブジェクトと共有さていなければ同時に削除します。"
                    End If
                Case "外側オブジェクト削除"
                    tiptext = "選択した面形状オブジェクトの外側に位置するオブジェクトをすべて削除します。"
                Case "メッシュオブジェクト作成"
                    tiptext = "メッシュオブジェクトを作成します。"
                Case "使用ライン線種変更"
                    tiptext = "選択したオブジェクトの使用しているラインの線種を変更します。"
                Case "集成オブジェクトを構成"
                    tiptext = "選択したオブジェクトから構成される新しい集成オブジェクトを作成します。"
                Case "選択オブジェクト名表示"
                    tiptext = "選択したオブジェクトのオブジェクト名を表示します。"
                Case "初期属性入力"
                    tiptext = "選択したオブジェクトの初期属性を入力します。"
            End Select
            If tiptext <> ToolTip1.GetToolTip(lbMultiObjectsCommand) Then
                ToolTip1.SetToolTip(lbMultiObjectsCommand, tiptext)
            End If
        Else
            ToolTip1.SetToolTip(lbMultiObjectsCommand, "")
        End If
    End Sub

    Private Sub lbMultiLineCommand_MouseMove(sender As Object, e As MouseEventArgs) Handles lbMultiLineCommand.MouseMove
        Dim i As Integer = lbMultiLineCommand.IndexFromPoint(New Point(e.X, e.Y))
        If i <> -1 Then
            Dim ItemText As String = lbMultiLineCommand.Items(i)
            Dim co As Integer = ItemText.IndexOf(":")
            If co <> -1 Then
                ItemText = ItemText.Substring(co + 1)
            End If
            Dim tiptext As String = ""
            Select Case ItemText
                Case "線種設定"
                    tiptext = "選択したラインの線種を設定します。"
                Case "分割＆結節点"
                    tiptext = "近くのラインに結節点が作られ，端点が移動します。"
                Case "ラインを交点で切断"
                    tiptext = "選択したラインで交差している場合に交点で切断します。"
                Case "ラインの共有部分を別ラインに"
                    tiptext = "選択したラインで同じ座標列があるライン部分を別のラインとしてまとめます。"
                Case "ライン結合"
                    tiptext = "選択ラインで端点同士が一致し、かつ3ライン以上の結節点でない場合、1本のラインにまとめます。。"
                Case "端点結合"
                    tiptext = "選択ラインの非結節点の末端同士を移動して、結合します。"
                Case "ポイント・ループ間引き"
                    tiptext = "選択ラインのポイントを簡略化したり、小さなループラインを削除します。"
                Case "座標表示"
                    tiptext = "選択ラインの座標を表示します。"
                Case "削除"
                    tiptext = "選択したラインをすべて削除します。"
            End Select
            If tiptext <> ToolTip1.GetToolTip(lbMultiLineCommand) Then
                ToolTip1.SetToolTip(lbMultiLineCommand, tiptext)
            End If
        Else
            ToolTip1.SetToolTip(lbMultiLineCommand, "")
        End If
    End Sub



    Private Sub mnuObjectEdit_Click(sender As Object, e As EventArgs) Handles mnuObjectEditMode.Click
        tsbObjectEditMode.PerformClick()
    End Sub

    Private Sub mnuLineEdit_Click(sender As Object, e As EventArgs) Handles mnuLineEditMode.Click
        tsbLineEditMode.PerformClick()
    End Sub

    Private Sub mnuObjectSearch_Click_1(sender As Object, e As EventArgs) Handles mnuObjectSearch.Click


        Dim SearchObject As New frmSearch_Object
        Dim init_para As New frmSearch_Object.init_parameter_data(MapData)
        init_para.Time = EditList.EditTime
        init_para.MultiSelect = True
        If SearchObject.ShowDialog(Me, MapData, init_para) = Windows.Forms.DialogResult.OK Then
            MapEditorOpe.SearchObjectSelect(SearchObject.getSelectedObjectNumbers)
        End If
        SearchObject.Dispose()

    End Sub


    Private Sub mnuCopyScreen_Click(sender As Object, e As EventArgs) Handles mnuCopyScreen.Click
        Clipboard.SetDataObject(picMap.Image)
    End Sub

    Private Sub mnuSearch_Object_by_Number_Click(sender As Object, e As System.EventArgs) Handles mnuSearch_Object_by_Number.Click
        Dim tx As String = InputBox("オブジェクト番号を指定してください。")
        If tx <> "" Then
            Dim lv As Integer = Val(tx)
            If lv >= 0 And lv < MapData.Map.Kend - 1 Then
                MapEditorOpe.SearchObjectSelect(New Integer() {lv})
            End If
        End If
    End Sub

    Private Sub mnuSearch_Line_Click(sender As Object, e As EventArgs) Handles mnuSearch_Line.Click
        Dim tx As String = InputBox("ライン番号を指定してください。")
        If tx <> "" Then
            Dim lv As Integer = Val(tx)
            If lv >= 0 And lv < MapData.Map.ALIN - 1 Then
                MapEditorOpe.setEditingLine(MapData.MPLine(lv))
            End If
        End If
    End Sub

    Private Sub mnuReplaceObjectName_Click(sender As Object, e As EventArgs) Handles mnuReplaceObjectName.Click
        MapEditorOpe.ReplaceObjectName()
    End Sub

    Private Sub mnuChangeAllObjectName_Click(sender As Object, e As EventArgs) Handles mnuChangeAllObjectName.Click
        MapEditorOpe.ChangeAllObjectName()
    End Sub

    Private Sub mnuCopyObjectName_Click(sender As Object, e As EventArgs) Handles mnuCopyObjectName.Click
        Dim init_para As New frmCopyObjectName.init_parameter_data(MapData)
        init_para.Time = EditList.EditTime
        Dim form = New frmCopyObjectName
        form.ShowDialog(Me, MapData, init_para)
        form.Dispose()
    End Sub


    Private Sub mnuSet_ClickObjectName_Click(sender As Object, e As EventArgs) Handles mnuSet_ClickObjectName.Click

        MapEditorOpe.ClickSetObjName()

    End Sub


    Private Sub mnuCombineSameNameObjecs_Click(sender As Object, e As EventArgs) Handles mnuCombineSameNameObjecs.Click
        Dim Tx As String = "同一のオブジェクト名のオブジェクトを結合して一つにします。"
        If MapData.Map.Time_Mode = True Then
            Tx += vbCrLf + "オブジェクト名に時間が設定してあるオブジェクトは結合対象外です。"
        End If
        If MsgBox(Tx, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MapEditorOpe.CombineSameNameObjecs()
        End If
    End Sub


    Private Sub mnuAggrObjClipSet_Click(sender As Object, e As EventArgs) Handles mnuAggrObjClipSet.Click
        If MapData.Check_AggregateObjectType_Exists = False Then
            MsgBox("集成オブジェクトグループが設定されていません。", MsgBoxStyle.Exclamation)
        Else
            MapEditorOpe.AggrObjClipSet()
        End If
    End Sub

    Private Sub mnuGetPointObject_Click(sender As Object, e As EventArgs) Handles mnuGetPointObject.Click
        If MapData.Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
            MsgBox("緯度経度座標系の地図データでない場合は使用できません。", MsgBoxStyle.Exclamation)
        Else
            MapEditorOpe.GetPointObject()
        End If
    End Sub

    Private Sub mnuSetCenterP_Click(sender As Object, e As EventArgs) Handles mnuSetCenterP.Click
        If MapData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
            MsgBox("緯度経度座標系の地図データでない場合は使用できません。", MsgBoxStyle.Exclamation)
        Else
            MapEditorOpe.CenterPointSet()
        End If

    End Sub

    Private Sub tabLineEndPointShow_Click(sender As Object, e As EventArgs) Handles tsbLineEndPointShow.Click
        clsSettings.Data.MapEditor.LineEndPointVisible = Not clsSettings.Data.MapEditor.LineEndPointVisible
        mnuLineEndPointShow.Checked = clsSettings.Data.MapEditor.LineEndPointVisible
        If EditList.editEventStopF = False Then
            MapEditorOpe.EditMapping(False)
        End If
    End Sub




    Private Sub tsbObjectNameVisible_Click(sender As Object, e As EventArgs) Handles tsbObjectNameVisible.Click
        clsSettings.Data.MapEditor.ObjectNameVisibleFlag = Not clsSettings.Data.MapEditor.ObjectNameVisibleFlag
        mnuObjectNameVisible.Checked = clsSettings.Data.MapEditor.ObjectNameVisibleFlag
        If EditList.editEventStopF = False Then
            MapEditorOpe.EditMapping(False)
        End If

    End Sub

    Private Sub mnuLineConnect_Click(sender As Object, e As EventArgs) Handles mnuLineConnect.Click
        MapEditorOpe.LineConnect()
    End Sub


    Private Sub mnuLineCut_by_CrossPoint_Click(sender As Object, e As EventArgs) Handles mnuLineCut_by_CrossPoint.Click
        MapEditorOpe.CutLine_by_CrossPoint()
    End Sub


    Private Sub mnuLineTopolyze_Click(sender As Object, e As EventArgs) Handles mnuLineTopolyze.Click
        MapEditorOpe.TopologyLine()
    End Sub

    Private Sub mnuLineNodalPoint_Click(sender As Object, e As EventArgs) Handles mnuLineNodalPoint.Click
        MapEditorOpe.NodalPointLine()
    End Sub

    Private Sub mnuLineSmoothing_Click(sender As Object, e As EventArgs) Handles mnuLineSmoothing.Click
        MapEditorOpe.SmoothingLine()
    End Sub

    Private Sub btnShowCoord_Click(sender As Object, e As EventArgs) Handles btnShowCoord.Click
        MapEditorOpe.showLineCoord()
    End Sub

    Private Sub btnOtherSelectMethos_Click(sender As Object, e As EventArgs) Handles btnOtherSelectMethos.Click
        Dim Menu As New List(Of String)
        Menu.Add("すべて選択")
        Menu.Add("選択/非選択交換")
        Menu.Add("外側オブジェクト選択")
        Menu.Add("内側オブジェクト選択")
        Dim n As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("オブジェクトの選択方法", Menu)
        If n <> -1 Then
            MapEditorOpe.MultiObjectSelect(Menu.Item(n))
        End If
    End Sub

    Private Sub btnMultiObjectClear_Click(sender As Object, e As EventArgs) Handles btnMultiObjectClear.Click
        MapEditorOpe.MultiObjectSelect("選択解除")
    End Sub


    Private Sub btnOtherLineSelectMethos_Click(sender As Object, e As EventArgs) Handles btnOtherLineSelectMethos.Click
        Dim Menu As New List(Of String)
        Menu.Add("すべて選択")
        Menu.Add("選択/非選択交換")
        Dim n As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("ラインの選択方法", Menu)
        If n <> -1 Then
            MapEditorOpe.MultiLineSelect(Menu.Item(n))
        End If
    End Sub

    Private Sub btnMultiLineClear_Click(sender As Object, e As EventArgs) Handles btnMultiLineClear.Click
        MapEditorOpe.MultiLineSelect("選択解除")

    End Sub

    Private Sub ラインの取り込みToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuGetLine.Click
        MapEditorOpe.getLine()

    End Sub

    Private Sub mnuAllShow_Click(sender As Object, e As EventArgs) Handles mnuAllShow.Click
        tsbAllShow.PerformClick()
    End Sub

    Private Sub mnuObjectNameVisible_Click(sender As Object, e As EventArgs) Handles mnuObjectNameVisible.Click
        tsbObjectNameVisible.PerformClick()
    End Sub

    Private Sub mnuLineEndPointShow_Click(sender As Object, e As EventArgs) Handles mnuLineEndPointShow.Click
        tsbLineEndPointShow.PerformClick()
    End Sub

    Private Sub mnuPreview_Click(sender As Object, e As EventArgs) Handles mnuPreview.Click
        Dim form As New frmMED_Preview
        form.ShowDialog(Me, MapData, EditList.ObjectKind, dbdtpEditTime.Value)
        form.Dispose()
    End Sub

    Private Sub frmMapEditor_Resize(sender As Object, e As EventArgs) Handles Me.Resize

    End Sub



 
    Private Sub mnuIdokedoMove_Click(sender As Object, e As EventArgs) Handles mnuIdokedoMove.Click
        If MapData.Map.ALIN = 0 And MapData.Map.OBKNum < 2 Then
            MsgBox("オブジェクトを2つ以上、またはラインを作成してから行ってください。", MsgBoxStyle.Exclamation)
            Return
        End If
        MapEditorOpe.idokedoMove()
    End Sub

    Private Sub mnuConvert_Tokyo97toITRF94_Click(sender As Object, e As EventArgs) Handles mnuConvert_Tokyo97toITRF94.Click
        If MapData.Map.ALIN = 0 And MapData.Map.OBKNum < 2 Then
            MsgBox("オブジェクトを2つ以上、またはラインを作成してから行ってください。", MsgBoxStyle.Exclamation)
            Return
        End If
        MapEditorOpe.Convert_Tokyo97toITRF94()


    End Sub

    Private Sub mnuConvert_ITRF94toTokyo97_Click(sender As Object, e As EventArgs) Handles mnuConvert_ITRF94toTokyo97.Click
        If MapData.Map.ALIN = 0 And MapData.Map.OBKNum < 2 Then
            MsgBox("オブジェクトを2つ以上、またはラインを作成してから行ってください。", MsgBoxStyle.Exclamation)
            Return
        End If
        MapEditorOpe.Convert_ITRF94toTokyo97()
    End Sub

    Private Sub mnuConvert_XY2IdoKedo_Click(sender As Object, e As EventArgs) Handles mnuConvert_XY2IdoKedo.Click
        If MapData.Map.ALIN = 0 And MapData.Map.OBKNum < 2 Then
            MsgBox("オブジェクトを2つ以上、またはラインを作成してから行ってください。", MsgBoxStyle.Exclamation)
            Return
        End If
        MapEditorOpe.Convert_XY2IdoKedo()
        tsbBackImage.Enabled = True
    End Sub

    Private Sub mnuReplace_ITRF94_Tokyo97_Click(sender As Object, e As EventArgs) Handles mnuReplace_ITRF94_Tokyo97.Click
        MapEditorOpe.Replace_ITRF94_Tokyo97()


    End Sub

    Private Sub mnuProjectionConvert_Click(sender As Object, e As EventArgs) Handles mnuProjectionConvert.Click
        If MapData.Map.ALIN = 0 And MapData.Map.OBKNum < 2 Then
            MsgBox("オブジェクトを2つ以上、またはラインを作成してから行ってください。", MsgBoxStyle.Exclamation)
            Return
        End If

        MapEditorOpe.ProjectionConvert()
    End Sub

    Private Sub mnuMapFileProperty_Click(sender As Object, e As EventArgs) Handles mnuMapFileProperty.Click
        Dim form As New frmMED_Property_of_MapFile
        form.ShowDialog(Me, MapData)
        form.Dispose()
    End Sub

    Private Sub mnuSaveMapFile_Click(sender As Object, e As EventArgs) Handles mnuSaveMapFile.Click
        Dim emes As String
        Cursor.Current = Cursors.WaitCursor
        Dim fg As Boolean = MapData.ErrorCheck_Mapfile(emes)
        Cursor.Current = Cursors.Default
        If fg = False Then
            If emes <> "" Then
                clsGeneric.Message(Me, "地図ファイルに問題があります。", emes, False, True)
            End If
            Return
        End If

        If LCase(System.IO.Path.GetExtension(Me.MapData.Map.FileName)) = ".mpf" Or Me.MapData.Map.FullPath = "" Then
            Save(True, False)
        Else
            Cursor.Current = Cursors.WaitCursor
            Dim f As Boolean = MapData.SaveMapFile(Me.MapData.Map.FullPath)
            Cursor.Current = Cursors.Default
            If f = True Then
                MsgBox(Me.MapData.Map.FullPath + "を保存しました。")
            Else
                MsgBox(Me.MapData.Map.FullPath + "は保存できませんでした。", MsgBoxStyle.Exclamation)
            End If

        End If

    End Sub

    Private Sub mnuBackImage_Click(sender As Object, e As EventArgs) Handles mnuBackImage.Click
        If MapData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
            MsgBox("緯度経度座標系の地図ファイル以外では背景画像を設定できません。", MsgBoxStyle.Exclamation)
        Else
            MapEditorOpe.BackImage(True)
        End If
    End Sub

    Private Sub mnuClose_Click(sender As Object, e As EventArgs) Handles mnuClose.Click

        Me.Close()
    End Sub

    Private Sub tsbBackImage_Click(sender As Object, e As EventArgs) Handles tsbBackImage.Click

        MapEditorOpe.BackImage(False)

    End Sub


    Private Sub mnuInsertMapFile_Click(sender As Object, e As EventArgs) Handles mnuInsertMapFile.Click

        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = "f:\mdrwin\map"
        ofd.Filter = "MANDARA地図ファイル(*.mpf?)|*.mpf?|圧縮地図ファイル(*.mpfz)|*.mpfz|非圧縮ファイル(*.mpfx)|*.mpfx|旧地図ファイル(*.mpf)|*.mpf"
        ofd.Multiselect = True
        If ofd.ShowDialog() = DialogResult.OK Then
            MapEditorOpe.InsertMapFile(ofd.FileNames)
        End If


    End Sub


    Private Sub mnuShapeFile_Click(sender As Object, e As EventArgs) Handles mnuShapeFile.Click
        Dim newF As Boolean = MapData.NoDataFlag
        Dim shapefiles() As clsShapefile.shapefile_info
        Dim topology_f As Boolean
        Dim integrate_F As Boolean
        If MapEditorOpe.GetShapefile(shapefiles, topology_f, integrate_F) = True Then
            Dim n As Integer = shapefiles.Length
            Dim Omap As clsMapData.strMap_data
            If newF = False Then
                Omap = MapData.Map
            End If
            If integrate_F = True Then
                Dim integratedMapData As clsMapData
                Dim filen As Integer = 0
                Dim newMapFile As String = ""
                Dim mshape As enmShape
                For i As Integer = 0 To n - 1
                    With shapefiles(i)
                        Dim newMapData As clsMapData = clsShapefile.Get_ShapeFile(.FullPath, .FileName + ".", True, .Zahyo, False, .encodingnumber, ProgressLabel)
                        If newMapData Is Nothing = False Then
                            newMapData.Map.Comment += "シェープファイル：" + .FileName + vbCrLf
                            newMapData.ObjectKind(0).Color = newMapData.Set_First_ObjectKind_Color_Solo(0)
                            If newMapData.ObjectKind(0).Shape = enmShape.PolygonShape And topology_f = True Then
                                newMapData.TopologyStructure_SameLine()
                            End If
                            If filen = 0 Then
                                newMapFile = System.IO.Path.GetFileNameWithoutExtension(.FileName)
                                integratedMapData = newMapData.Clone()
                                mshape = newMapData.ObjectKind(0).Shape
                            Else
                                integratedMapData.InsertMapData(newMapData, "")
                            End If
                            filen += 1
                        End If
                    End With
                Next
                Dim bl(filen - 1) As Boolean
                clsGeneric.FillArray(bl, True)

                With integratedMapData
                    If mshape <> enmShape.PointShape Then
                        .Combine_Linekinds(bl, "境界", clsBase.Line)
                    End If
                    .Combine_Objectkinds(bl, .ObjectKind(0).Name)
                    '.init_Compass_First()
                    Dim datanum As Integer = .ObjectKind(0).DefTimeAttDataNum
                    Dim data_str(datanum - 1, .Map.OBKNum - 1) As String
                    For i As Integer = 0 To .ObjectKind(0).DefTimeAttDataNum - 1
                        For j As Integer = 0 To .Map.OBKNum - 1
                            data_str(i, j) = .MPObj(j).DefTimeAttValue(i).Data(0).Value
                        Next
                    Next
                    Dim UNT() As String = clsGeneric.Check_DataType(datanum, .Map.OBKNum, data_str)
                    For i As Integer = 0 To datanum - 1
                        With .ObjectKind(0).DefTimeAttSTC(i).attData
                            .Unit = UNT(i)
                        End With
                    Next
                End With
                If MapData.NoDataFlag = True Then
                    MapData = integratedMapData.Clone
                Else
                    MapData.InsertMapData(integratedMapData, "")
                    MapData.ObjectKind(MapData.Map.OBKNum - 1).Color = MapData.Set_First_ObjectKind_Color_Solo(MapData.Map.OBKNum - 1)
                End If
            Else
                For i As Integer = 0 To n - 1
                    With shapefiles(i)
                        Dim newMapData As clsMapData = clsShapefile.Get_ShapeFile(.FullPath, .FileName + ".", True, .Zahyo, True, .encodingnumber, ProgressLabel)
                        If newMapData Is Nothing = False Then
                            If newMapData.ObjectKind(0).Shape = enmShape.PolygonShape And topology_f = True Then
                                newMapData.TopologyStructure_SameLine()
                            End If
                            If i = 0 And MapData.NoDataFlag = True Then
                                MapData = newMapData.Clone
                                MapData.Map.FullPath = ""
                                .FileName = System.IO.Path.ChangeExtension(.FileName, ".mpfz")
                                Me.Text = .FileName
                            Else
                                MapData.InsertMapData(newMapData, "")
                                MapData.ObjectKind(MapData.Map.OBKNum - 1).Color = MapData.Set_First_ObjectKind_Color_Solo(MapData.Map.OBKNum - 1)
                            End If
                        End If
                        MapData.Map.Comment += "シェープファイル：" + .FileName + vbCrLf
                    End With
                Next

            End If
            MapData.init_Compass_First()

            If MapData.Map.LpNum = 0 Then
                MapData.Add_OneLineKind("新規線種", clsBase.Line, enmMesh_Number.mhNonMesh)
            End If
            If newF = True Then
                EditMappingIni()
                setEditPanel()
                MapEditorOpe.EditMapping(True)
            Else
                MapEditorOpe.Insert_Mapdata_Reset(Omap)
            End If
        End If

    End Sub

    Private Sub mnuDefAtrShow_Click(sender As Object, e As EventArgs) Handles mnuDefAtrShow.Click
        MapEditorOpe.DefAttVisibleSetting()
    End Sub

    Private Sub mnuOption_Click(sender As Object, e As EventArgs) Handles mnuOption.Click
        Dim form As New frmOption
        If form.ShowDialog(Me, MapEditorOpe.ScrData, clsBase.PictureNoUse) = Windows.Forms.DialogResult.OK Then
            MapEditorOpe.EditMapping(False)
        End If
        form.Dispose()
    End Sub

    Private Sub mnuGetContour_Click(sender As Object, e As EventArgs) Handles mnuGetContour.Click
        Dim newF As Boolean = MapData.NoDataFlag
        Dim Omap As clsMapData.strMap_data
        If newF = False Then
            Omap = MapData.Map
        End If
        Dim ContourMapData As clsMapData = MapEditorOpe.GetMeshContour()
        If (ContourMapData Is Nothing) = False Then
            If newF = True Then
                MapData = ContourMapData
                EditMappingIni()
                setEditPanel()
                MapEditorOpe.EditMapping(True)
                Me.Text = MapData.Map.FileName
            Else
                MapData.InsertMapData(ContourMapData, "")
                MapEditorOpe.Insert_Mapdata_Reset(Omap)
            End If
        End If
    End Sub


    Private Sub mnuShapefileOut_Click(sender As Object, e As EventArgs) Handles mnuShapefileOut.Click
        Dim form As New frmMED_ShapefileOut
        form.ShowDialog(Me, MapData, EditList.EditTime)
        form.Dispose()
    End Sub

    Private Sub mnuKMLFile_Click(sender As Object, e As EventArgs) Handles mnuKMLFile.Click
        Dim newF As Boolean = MapData.NoDataFlag
        Dim Omap As clsMapData.strMap_data
        If newF = False Then
            Omap = MapData.Map
        End If

        Dim kmlMapData As clsMapData = MapEditorOpe.GetKML
        If (kmlMapData Is Nothing) = False Then
            If newF = True Then
                MapData = kmlMapData
                EditMappingIni()
                setEditPanel()
                MapEditorOpe.EditMapping(True)
                MapData.Map.FileName = System.IO.Path.ChangeExtension(MapData.Map.FileName, ".mpfz")
                Me.Text = MapData.Map.FileName
            Else
                MapData.InsertMapData(kmlMapData, "")
                MapEditorOpe.Insert_Mapdata_Reset(Omap)
            End If
        End If
    End Sub

    Private Sub ktGridDefAttValue_Click_DataGrid(Layer As Integer, X As Integer, Y As Integer, Value As String, Top As Single, Left As Single, Width As Single, Height As Single) Handles ktGridDefAttValue.Click_DataGrid
        If MapData.Map.Time_Mode = True Then
            MapEditorOpe.SetDefTimeAttrData(Y)
        End If
    End Sub



    Private Sub mnuViewrGo_Click(sender As Object, e As EventArgs) Handles mnuViewrGo.Click
        If LCase(System.IO.Path.GetExtension(Me.MapData.Map.FileName)) = ".mpf" Or Me.MapData.Map.FullPath = "" Then
            If Save(False, False) = True Then
                ViewrMapFile = Me.MapData.Map.FullPath
                Me.Close()
            End If
        Else
            Cursor.Current = Cursors.WaitCursor
            Dim f As Boolean = MapData.SaveMapFile(Me.MapData.Map.FullPath)
            Cursor.Current = Cursors.Default
            If f = True Then
                ViewrMapFile = Me.MapData.Map.FullPath
                Me.Close()
            Else
                MsgBox(Me.MapData.Map.FullPath + "は保存できませんでした。", MsgBoxStyle.Exclamation)
            End If

        End If
    End Sub

    Private Sub mnuE00File_Click(sender As Object, e As EventArgs) Handles mnuE00File.Click
        Dim newF As Boolean = MapData.NoDataFlag
        Dim E00files() As clsE00.E00file_info
        Dim form As New frmMED_E00File

        If MapEditorOpe.GetE00file(E00files) = True Then
            Dim n As Integer = E00files.Length
            Dim Omap As clsMapData.strMap_data
            If newF = False Then
                Omap = MapData.Map
            End If
            For i As Integer = 0 To n - 1
                With E00files(i)
                    Dim newMapData As clsMapData
                    If clsE00.Get_e00File(.FullPath, .FileName + ".", .Zahyo, newMapData, ProgressLabel) = True Then
                        If i = 0 And MapData.NoDataFlag = True Then
                            MapData = newMapData.Clone
                            MapData.Map.FileName = System.IO.Path.ChangeExtension(MapData.Map.FileName, ".mpfz")
                            Me.Text = .FileName
                        Else
                            MapData.InsertMapData(newMapData, "")
                            MapData.ObjectKind(MapData.Map.OBKNum - 1).Color = MapData.Set_First_ObjectKind_Color_Solo(MapData.Map.OBKNum - 1)
                        End If
                        MapData.Map.Comment += "e00ファイル：" + .FileName + vbCrLf
                    End If
                    MapData.init_Compass_First()
                End With
            Next
            If newF = True Then
                EditMappingIni()
                setEditPanel()
                MapEditorOpe.EditMapping(True)
            Else
                MapEditorOpe.Insert_Mapdata_Reset(Omap)
            End If
        End If

    End Sub

  


    Private Sub ktObjectName_Resize(sender As Object, e As EventArgs) Handles ktObjectName.Resize
        If EditList.editEventStopF = False And Me.Visible = True Then
            If ktObjectName.LayerMax = 1 Then
                ktObjectName.GridWidth(0, 0) = ktObjectName.Width - SystemInformation.VerticalScrollBarWidth - 4
                ktObjectName.Refresh()
            End If
        End If
    End Sub



    Private Sub mnuObjectNameEdit_Click(sender As Object, e As EventArgs) Handles mnuObjectNameEdit.Click
        MapEditorOpe.ObjectNameEdit()
    End Sub

    Private Sub mnuImportData_Click(sender As Object, e As EventArgs) Handles mnuImportData.Click

    End Sub

    Private Sub mnuHelp_Click(sender As Object, e As EventArgs) Handles mnuHelp.Click
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "")
    End Sub

    Private Sub mnuCensusSmallArea_Click(sender As Object, e As EventArgs) Handles mnuCensusSmallArea.Click
        Dim newF As Boolean = MapData.NoDataFlag
        Dim Omap As clsMapData.strMap_data
        If newF = False Then
            Omap = MapData.Map
        End If
        Dim CensusMapData As clsMapData = MapEditorOpe.GetCencusGISData()
        If (CensusMapData Is Nothing) = False Then
            If newF = True Then
                MapData = CensusMapData
                EditMappingIni()
                setEditPanel()
                MapEditorOpe.EditMapping(True)
                Me.Text = MapData.Map.FileName
            Else
                MapData.InsertMapData(CensusMapData, "")
                MapEditorOpe.Insert_Mapdata_Reset(Omap)
            End If
        End If
    End Sub

    Private Sub mnuFile_Click(sender As Object, e As EventArgs) Handles mnuFile.Click

    End Sub

    Private Sub mnuTimeEditMode_Click(sender As Object, e As EventArgs) Handles mnuTimeEditMode.Click


        If MapData.Map.Time_Mode = False Then
            MapData.Map.Time_Mode = True
            For i As Integer = 0 To MapData.Map.OBKNum - 1
                With MapData.ObjectKind(i)
                    If .DefTimeAttDataNum > 0 Then
                        For j As Integer = 0 To .DefTimeAttDataNum - 1
                            .DefTimeAttSTC(j).ExtraValue = clsMapData.enmDefPointAttDataExtraValue.NearestValue
                            .DefTimeAttSTC(j).Type = clsMapData.enmDefTimeAttDataType.SpanData
                        Next
                    End If
                End With
            Next
            setEditPanel()

        Else
            Dim MLine_f As Boolean
            Dim ObjName_f As Boolean
            Dim ObjLine_f As Boolean
            Dim defAtt_f As Boolean
            Dim f As Boolean = MapData.Check_Time_Mode_of_Map(MLine_f, ObjName_f, ObjLine_f, defAtt_f)
            If f = False Then
                MapData.Map.Time_Mode = False
                setEditPanel()
            Else
                Dim tx As String = ""
                If MLine_f = True Then
                    tx += "時間設定のあるラインがあるため、時空間モードから抜けることはできません。" + vbCrLf
                End If
                If ObjName_f = True Then
                    tx += "時間設定のあるオブジェクト名があるため、時空間モードから抜けることはできません。" + vbCrLf
                End If
                If ObjLine_f = True Then
                    tx += "オブジェクトの使用するラインに時間設定があるため、時空間モードから抜けることはできません。" + vbCrLf
                End If
                If defAtt_f = True Then
                    tx += "初期属性データに時間設定があるため、時空間モードから抜けることはできません。" + vbCrLf
                End If
                If tx <> "" Then
                    MsgBox(tx, MsgBoxStyle.Exclamation)
                End If
            End If
        End If

    End Sub

    Private Sub mnuSuccesionView_Click(sender As Object, e As EventArgs) Handles mnuSuccesionView.Click

        Dim StimeSort As New clsSortingSearch
        Dim n As Integer = 0
        Dim ODest(1, 50) As Integer
        StimeSort.AddInit(VariantType.Integer)
        For i As Integer = 0 To MapData.Map.Kend - 1
            With MapData.MPObj(i)
                For j As Integer = 0 To .NumOfSuc - 1
                    With .SucSTC(j)
                        If UBound(ODest, 2) < n Then
                            ReDim Preserve ODest(1, n + 50)
                        End If
                        StimeSort.Add(clsTime.YMDtoValue(.Time))
                        ODest(0, n) = i
                        ODest(1, n) = .ObjectCode
                        n += 1
                    End With
                Next
            End With
        Next
        StimeSort.AddEnd()


        Dim txtArray As New List(Of String)
        txtArray.Add("日付" + vbTab + "元オブジェクト" + vbTab + "元オブジェクトグループ" + vbTab + "継承先" + vbTab + "継承先オブジェクトグループ")

        With StimeSort
            For i As Integer = 0 To n - 1
                Dim docode As Integer = ODest(0, .DataPosition(i))
                Dim stime As strYMD = clsTime.GetYMDfromValue(.DataPositionValue_Integer(i))
                Dim D As strYMD = clsTime.getYesterday(stime)
                Dim NameO As String
                MapData.Get_Enable_ObjectName(docode, D, False, NameO)
                Dim tx As String = clsTime.YMDtoString(stime) + vbTab
                Dim f As Boolean = False
                With MapData.MPObj(docode)
                    For j As Integer = 0 To .NumOfNameTime - 1
                        With .NameTimeSTC(j)
                            If .SETime.EndTime.Equals(D) = True Then
                                f = True
                                Exit For
                            End If
                        End With
                    Next
                    tx += NameO
                    If f = False Then
                        tx += "の一部"
                    End If
                    tx += vbTab + MapData.ObjectKind(.Kind).Name
                End With
                Dim NameD As String
                MapData.Get_Enable_ObjectName(ODest(1, .DataPosition(i)), stime, False, NameD)
                tx += vbTab + NameD + vbTab + MapData.ObjectKind(MapData.MPObj(ODest(1, .DataPosition(i))).Kind).Name
                txtArray.Add(tx)
            Next
        End With
        StimeSort = Nothing
        clsGeneric.Message(Me, "継承関係一覧", txtArray,
                           {VariantType.String, VariantType.String, VariantType.String, VariantType.String, VariantType.String},
                           {True, False, False, False, False}, True, True)
    End Sub

    Private Sub mnuObjectNameChangeView_Click_1(sender As Object, e As EventArgs) Handles mnuObjectNameChangeView.Click
        Dim StimeSort As New clsSortingSearch

        Dim n As Integer = 0
        Dim ODest(3, 50) As String
        StimeSort.AddInit(VariantType.Integer)
        For i As Integer = 0 To MapData.Map.Kend - 1
            With MapData.MPObj(i)
                Dim grp As String = MapData.ObjectKind(.Kind).Name
                For j As Integer = 0 To .NumOfNameTime - 1
                    With .NameTimeSTC(j)
                        If UBound(ODest) < n Then
                            ReDim Preserve ODest(3, n + 50)
                        End If
                        If .SETime.StartTime.nullFlag = False Then
                            If j = 0 Then
                                StimeSort.Add(clsTime.YMDtoValue(.SETime.StartTime))
                                ODest(0, n) = grp
                                ODest(1, n) = .connectNames
                                ODest(2, n) = "開始"
                                n += 1
                            Else
                                If clsTime.getYesterday(.SETime.StartTime).Equals(MapData.MPObj(i).NameTimeSTC(j - 1).SETime.EndTime) Then
                                    StimeSort.Add(clsTime.YMDtoValue(.SETime.StartTime))
                                    ODest(0, n) = grp
                                    ODest(1, n) = MapData.MPObj(i).NameTimeSTC(j - 1).connectNames
                                    ODest(2, n) = "名称変更"
                                    ODest(3, n) = .connectNames
                                    n += 1
                                End If
                            End If
                        End If
                        If UBound(ODest) < n Then
                            ReDim Preserve ODest(3, n + 50)
                        End If
                        If .SETime.EndTime.nullFlag = False Then
                            Dim ef As Boolean
                            ef = False
                            If j = MapData.MPObj(i).NumOfNameTime - 1 Then
                                StimeSort.Add(clsTime.YMDtoValue(.SETime.EndTime))
                                ODest(0, n) = grp
                                ODest(1, n) = .connectNames
                                ODest(2, n) = "終了"
                                ef = True
                                n += 1
                            Else
                                If clsTime.getTomorrow(.SETime.EndTime).Equals(MapData.MPObj(i).NameTimeSTC(j + 1).SETime.StartTime) = False Then
                                    StimeSort.Add(clsTime.YMDtoValue(.SETime.EndTime))
                                    ODest(0, n) = grp
                                    ODest(1, n) = .connectNames
                                    ODest(2, n) = "終了"
                                    ef = True
                                    n += 1
                                End If
                            End If
                            If ef = True Then
                                For k As Integer = 0 To MapData.MPObj(i).NumOfSuc - 1
                                    With MapData.MPObj(i).SucSTC(k)
                                        If clsTime.getTomorrow(MapData.MPObj(i).NameTimeSTC(j).SETime.EndTime).Equals(.Time) = True Then
                                            Dim Name12 As String
                                            MapData.Get_Enable_ObjectName(.ObjectCode, .Time, False, Name12)
                                            ODest(2, n - 1) = "終了継承"
                                            If ODest(3, n - 1) <> "" Then
                                                Name12 = "," + Name12
                                            End If
                                            ODest(3, n - 1) += Name12
                                        End If
                                    End With
                                Next
                            End If
                        End If
                    End With
                Next
            End With
        Next
        StimeSort.AddEnd()

        Dim txtArray As New List(Of String)
        txtArray.Add("日付" + vbTab + "オブジェクトグループ" + vbTab + "オブジェクト" + vbTab + "種別" + vbTab + "変更先")


        For i As Integer = 0 To n - 1
            Dim tx As String = clsTime.YMDtoString(clsTime.GetYMDfromValue(StimeSort.DataPositionValue_Integer(i)))
            Dim sn As Integer = StimeSort.DataPosition(i)
            tx += vbTab + ODest(0, sn) + vbTab + ODest(1, sn) + vbTab + ODest(2, sn) + vbTab + ODest(3, sn)
            txtArray.Add(tx)
        Next

        clsGeneric.Message(Me, "オブジェクト名変更一覧", txtArray,
                   {VariantType.String, VariantType.String, VariantType.String, VariantType.String, VariantType.String},
                   {True, False, False, True, False}, True, True)
    End Sub

    Private Sub mnuTimeObjectSet_Click(sender As Object, e As EventArgs) Handles mnuTimeObjectSet.Click
        MapEditorOpe.TimeObjectSet()

    End Sub


    Private Sub mnuSettings_Click(sender As Object, e As EventArgs) Handles mnuSettings.Click

    End Sub

    Private Sub lbMultiObjectsCommand_SelectedIndexChanged(sender As System.Object, e As System.Windows.Forms.DrawItemEventArgs) Handles lbMultiObjectsCommand.DrawItem, lbMultiLineCommand.DrawItem
        If e.Index = -1 Then
            Return
        End If

        '背景を描画する
        e.DrawBackground()

        '表示すべき文字列を取得
        Dim txt As String = CType(sender, ListBox).Items(e.Index).ToString()
        Dim myBrush As Brush = New SolidBrush(e.ForeColor)

        '文字の描画
        e.Graphics.DrawString(txt, e.Font, myBrush, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
        e.DrawFocusRectangle()
    End Sub



    Private Sub btnEditPanelHelp_Click(sender As Object, e As EventArgs) Handles btnEditPanelHelp.Click
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "EditPanel", Me)
    End Sub

    Private Sub btnMultiObjectsEditHelp_Click(sender As Object, e As EventArgs) Handles btnMultiObjectsEditHelp.Click
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "MultiObjectsEditPanel", Me)
    End Sub

    Private Sub btnLineEditHelp_Click(sender As Object, e As EventArgs) Handles btnLineEditHelp.Click
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "LineEditPanel", Me)
    End Sub

    Private Sub btnObjectEditHelp_Click(sender As Object, e As EventArgs) Handles btnObjectEditHelp.Click
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "ObjectEditPanel", Me)
    End Sub

    Private Sub btnTimeObjectEditHelp_Click(sender As Object, e As EventArgs) Handles btnTimeObjectEditHelp.Click
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "TimeObjectEditPanel", Me)
    End Sub

    Private Sub btnMultiLinesEditHelp_Click(sender As Object, e As EventArgs) Handles btnMultiLinesEditHelp.Click
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "MultiLinesEditPanel", Me)
    End Sub

    Private Sub mnuKiban_Click(sender As Object, e As EventArgs) Handles mnuKiban.Click
        Dim newF As Boolean = MapData.NoDataFlag
        Dim Omap As clsMapData.strMap_data
        If newF = False Then
            Omap = MapData.Map
        End If

        Dim Kiban As clsMapData = MapEditorOpe.GetKibanFile()
        If Kiban Is Nothing = False Then
            If newF = True Then
                MapData = Kiban
                EditMappingIni()
                setEditPanel()
                MapEditorOpe.EditMapping(True)
                MapData.Map.FileName = System.IO.Path.ChangeExtension(MapData.Map.FileName, ".mpfz")
                Me.Text = MapData.Map.FileName
            Else
                MapData.InsertMapData(Kiban, "")
                MapEditorOpe.Insert_Mapdata_Reset(Omap)
            End If
        End If
    End Sub

    Private Sub cbUnEditableVisible_CheckedChanged1(sender As Object, e As EventArgs) Handles cbUnEditableVisible.CheckedChanged
        EditList.unEditableVisible = cbUnEditableVisible.Checked
        If EditList.editEventStopF = False Then
            'イベントを発生させる場合は描画
            MapEditorOpe.EditMapping(True)
        End If
    End Sub

    Private Sub mnuOpenStreetMap_Click(sender As Object, e As EventArgs) Handles mnuOpenStreetMap.Click
        Dim newF As Boolean = MapData.NoDataFlag
        Dim Omap As clsMapData.strMap_data
        If newF = False Then
            Omap = MapData.Map
        End If

        Dim Osm As clsMapData = MapEditorOpe.GetOSM()
        If Osm Is Nothing = False Then
            If newF = True Then
                MapData = Osm
                EditMappingIni()
                setEditPanel()
                MapEditorOpe.EditMapping(True)
                MapData.Map.FileName = System.IO.Path.ChangeExtension(MapData.Map.FileName, ".mpfz")
                Me.Text = MapData.Map.FileName
            Else
                MapData.InsertMapData(Osm, "")
                MapEditorOpe.Insert_Mapdata_Reset(Omap)
            End If
        End If
    End Sub


    Private Sub mnuMakeMeshObject_Click(sender As Object, e As EventArgs) Handles mnuMakeMeshObject.Click
        MapEditorOpe.makeMakefromMenu()
    End Sub



    Private Sub mnuNewBlankMapData_Click(sender As Object, e As EventArgs) Handles mnuNewBlankMapData.Click
        If MapData.NoDataFlag = False Then
            If MsgBox("現在の地図データは消去されます。", vbYesNoCancel) <> MsgBoxResult.Yes Then
                Return
            End If
        End If
        Dim pll As strLatLon = New strLatLon(35.8627, 139.6102)
        MsgBox("作成する地域の中央の緯度経度を設定してください。")
        If clsGeneric.Get_LatLon(pll, enmLatLonPrintPattern.DecimalDegree, True) = False Then
            Return
        End If
        Dim cp As PointF = pll.toPointF()
        With MapData
            .init_MapData()
            .NoDataFlag = False
            .Add_OneLineKind("線種1", clsBase.Line, enmMesh_Number.mhNonMesh)
            .Add_OneObjectGroup_Parameter("オブジェクトグループ1", enmShape.PointShape, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
            .Map.Zahyo.CenterXY = cp
            .Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido
            .Map.Zahyo.System = enmZahyo_System_Info.Zahyo_System_World
            .Map.Zahyo.Projection = clsSettings.Data.default_Projection
            .Map.FileName = "ブランクマップ.mpfz"
            Dim crect = New RectangleF(cp, New Size(0, 0))
            crect.Inflate(0.05, 0.05)
            Dim cpc As PointF = spatial.Get_Converted_XY(cp, .Map.Zahyo)
            Dim nwp As PointF = spatial.Get_Converted_XY(New PointF(crect.Left, crect.Bottom), .Map.Zahyo)
            Dim sep As PointF = spatial.Get_Converted_XY(New PointF(crect.Right, crect.Top), .Map.Zahyo)
            .Map.Circumscribed_Rectangle = New RectangleF(New PointF(nwp.X, nwp.Y), New Size(sep.X - nwp.X, sep.Y - nwp.Y))
            .init_Compass_First()
            Me.Text = .Map.FileName
            EditMappingIni()
            setEditPanel()
            MapEditorOpe.EditMapping(True)
        End With
        Default_Init()
    End Sub

    Private Sub mnuSokutiConvert_Click(sender As Object, e As EventArgs) Handles mnuSokutiConvert.Click

    End Sub

    Private Sub picMap_Click(sender As Object, e As EventArgs) Handles picMap.Click

    End Sub
End Class
