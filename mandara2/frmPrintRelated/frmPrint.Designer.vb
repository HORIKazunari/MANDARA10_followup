<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransPngSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuKMLFileOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGoogleMapOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTileMapOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTimeSeriesFileOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopyAsBitmap = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInstance = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuObjectSerach = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAnalysis = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStdDaen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMultiObjectSelectMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDIstanceArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRedraw = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFormSizeChange = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintRange = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuScreen_Setting = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDummyObjChange = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBackImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuObjDataValueShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLocalChabge = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSet3d = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPropertyWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptionRoot = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLinePattern = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPictureSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProjection = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFigure = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFigureMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFigureList = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.mnuODLineCurveResetMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuODLineCurveReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccPopup = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAccPopupInvisible = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccPopupSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccPopupVisible = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pnlDistanceArea = New System.Windows.Forms.Panel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblUnitArea = New System.Windows.Forms.Label()
        Me.lblUnitDis = New System.Windows.Forms.Label()
        Me.txtArea = New System.Windows.Forms.TextBox()
        Me.txtDistance = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDistanceEnd = New System.Windows.Forms.Button()
        Me.StatusStrip.SuspendLayout()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.mnuODLineCurveResetMenu.SuspendLayout()
        Me.mnuAccPopup.SuspendLayout()
        Me.pnlDistanceArea.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBar, Me.StatusLabel, Me.StatusLabel2, Me.StatusLabel3, Me.StatusLabel4})
        Me.StatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.StatusStrip.Location = New System.Drawing.Point(0, 236)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(727, 28)
        Me.StatusStrip.TabIndex = 0
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ProgressBar
        '
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(100, 22)
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(119, 23)
        Me.StatusLabel.Text = "ToolStripStatusLabel1"
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusLabel2
        '
        Me.StatusLabel2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.StatusLabel2.Name = "StatusLabel2"
        Me.StatusLabel2.Size = New System.Drawing.Size(148, 23)
        Me.StatusLabel2.Text = "ToolStripStatusLabel1"
        '
        'StatusLabel3
        '
        Me.StatusLabel3.Name = "StatusLabel3"
        Me.StatusLabel3.Size = New System.Drawing.Size(119, 23)
        Me.StatusLabel3.Text = "ToolStripStatusLabel1"
        '
        'StatusLabel4
        '
        Me.StatusLabel4.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.StatusLabel4.Name = "StatusLabel4"
        Me.StatusLabel4.Size = New System.Drawing.Size(148, 23)
        Me.StatusLabel4.Text = "ToolStripStatusLabel1"
        '
        'picMap
        '
        Me.picMap.BackColor = System.Drawing.Color.White
        Me.picMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picMap.Location = New System.Drawing.Point(0, 24)
        Me.picMap.Name = "picMap"
        Me.picMap.Size = New System.Drawing.Size(727, 212)
        Me.picMap.TabIndex = 1
        Me.picMap.TabStop = False
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuAnalysis, Me.mnuView, Me.mnuOptionRoot, Me.mnuFigure, Me.mnuPrintOut, Me.mnuHelp})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(727, 24)
        Me.MenuStrip.TabIndex = 2
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSaveImage, Me.mnuTransPngSave, Me.mnuKMLFileOut, Me.mnuGoogleMapOut, Me.mnuTileMapOut, Me.mnuTimeSeriesFileOut})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(67, 20)
        Me.mnuFile.Text = "ファイル(&F)"
        '
        'mnuSaveImage
        '
        Me.mnuSaveImage.Name = "mnuSaveImage"
        Me.mnuSaveImage.Size = New System.Drawing.Size(229, 22)
        Me.mnuSaveImage.Text = "画像の保存(&S)"
        '
        'mnuTransPngSave
        '
        Me.mnuTransPngSave.Name = "mnuTransPngSave"
        Me.mnuTransPngSave.Size = New System.Drawing.Size(229, 22)
        Me.mnuTransPngSave.Text = "透過PNGで保存(P)"
        '
        'mnuKMLFileOut
        '
        Me.mnuKMLFileOut.Name = "mnuKMLFileOut"
        Me.mnuKMLFileOut.Size = New System.Drawing.Size(229, 22)
        Me.mnuKMLFileOut.Text = "KML形式で出力(&K)"
        '
        'mnuGoogleMapOut
        '
        Me.mnuGoogleMapOut.Name = "mnuGoogleMapOut"
        Me.mnuGoogleMapOut.Size = New System.Drawing.Size(229, 22)
        Me.mnuGoogleMapOut.Text = "Googleマップ・Leafletに出力(&G)"
        '
        'mnuTileMapOut
        '
        Me.mnuTileMapOut.Name = "mnuTileMapOut"
        Me.mnuTileMapOut.Size = New System.Drawing.Size(229, 22)
        Me.mnuTileMapOut.Text = "タイルマップ出力(&T)"
        '
        'mnuTimeSeriesFileOut
        '
        Me.mnuTimeSeriesFileOut.Name = "mnuTimeSeriesFileOut"
        Me.mnuTimeSeriesFileOut.Size = New System.Drawing.Size(229, 22)
        Me.mnuTimeSeriesFileOut.Text = "連続表示モードのファイル出力(&S)"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCopy, Me.mnuCopyAsBitmap, Me.mnuInstance, Me.mnuObjectSerach})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(57, 20)
        Me.mnuEdit.Text = "編集(&E)"
        '
        'mnuCopy
        '
        Me.mnuCopy.Name = "mnuCopy"
        Me.mnuCopy.ShortcutKeyDisplayString = "  "
        Me.mnuCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnuCopy.Size = New System.Drawing.Size(203, 22)
        Me.mnuCopy.Text = "コピー(&C)"
        '
        'mnuCopyAsBitmap
        '
        Me.mnuCopyAsBitmap.Name = "mnuCopyAsBitmap"
        Me.mnuCopyAsBitmap.Size = New System.Drawing.Size(203, 22)
        Me.mnuCopyAsBitmap.Text = "画像としてコピー(&P)"
        '
        'mnuInstance
        '
        Me.mnuInstance.Name = "mnuInstance"
        Me.mnuInstance.Size = New System.Drawing.Size(203, 22)
        Me.mnuInstance.Text = "参照ウインドウにコピー(&R)"
        '
        'mnuObjectSerach
        '
        Me.mnuObjectSerach.Name = "mnuObjectSerach"
        Me.mnuObjectSerach.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.mnuObjectSerach.Size = New System.Drawing.Size(203, 22)
        Me.mnuObjectSerach.Text = "オブジェクト検索(&S)"
        '
        'mnuAnalysis
        '
        Me.mnuAnalysis.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuStdDaen, Me.mnuMultiObjectSelectMode, Me.mnuDIstanceArea})
        Me.mnuAnalysis.Name = "mnuAnalysis"
        Me.mnuAnalysis.Size = New System.Drawing.Size(59, 20)
        Me.mnuAnalysis.Text = "分析(&A)"
        '
        'mnuStdDaen
        '
        Me.mnuStdDaen.Name = "mnuStdDaen"
        Me.mnuStdDaen.Size = New System.Drawing.Size(188, 22)
        Me.mnuStdDaen.Text = "標準偏差楕円(&D)"
        '
        'mnuMultiObjectSelectMode
        '
        Me.mnuMultiObjectSelectMode.Name = "mnuMultiObjectSelectMode"
        Me.mnuMultiObjectSelectMode.Size = New System.Drawing.Size(188, 22)
        Me.mnuMultiObjectSelectMode.Text = "複数オブジェクト選択(&S)"
        '
        'mnuDIstanceArea
        '
        Me.mnuDIstanceArea.Name = "mnuDIstanceArea"
        Me.mnuDIstanceArea.Size = New System.Drawing.Size(188, 22)
        Me.mnuDIstanceArea.Text = "距離・面積測定(&A)"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRedraw, Me.mnuFormSizeChange, Me.mnuPrintRange, Me.mnuScreen_Setting, Me.mnuDummyObjChange, Me.mnuBackImage, Me.mnuObjDataValueShow, Me.mnuLocalChabge, Me.mnuSet3d, Me.mnuPropertyWindow})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(58, 20)
        Me.mnuView.Text = "表示(&V)"
        '
        'mnuRedraw
        '
        Me.mnuRedraw.Name = "mnuRedraw"
        Me.mnuRedraw.Size = New System.Drawing.Size(232, 22)
        Me.mnuRedraw.Text = "再描画(&R)"
        '
        'mnuFormSizeChange
        '
        Me.mnuFormSizeChange.Name = "mnuFormSizeChange"
        Me.mnuFormSizeChange.Size = New System.Drawing.Size(232, 22)
        Me.mnuFormSizeChange.Text = "地図画面サイズ変更(&S)"
        '
        'mnuPrintRange
        '
        Me.mnuPrintRange.Name = "mnuPrintRange"
        Me.mnuPrintRange.Size = New System.Drawing.Size(232, 22)
        Me.mnuPrintRange.Text = "表示範囲指定(&A)"
        '
        'mnuScreen_Setting
        '
        Me.mnuScreen_Setting.Name = "mnuScreen_Setting"
        Me.mnuScreen_Setting.Size = New System.Drawing.Size(232, 22)
        Me.mnuScreen_Setting.Text = "画面設定保存・切り替え(&C)"
        '
        'mnuDummyObjChange
        '
        Me.mnuDummyObjChange.Name = "mnuDummyObjChange"
        Me.mnuDummyObjChange.Size = New System.Drawing.Size(232, 22)
        Me.mnuDummyObjChange.Text = "ダミーオブジェクト・グループ変更(&D)"
        '
        'mnuBackImage
        '
        Me.mnuBackImage.Name = "mnuBackImage"
        Me.mnuBackImage.Size = New System.Drawing.Size(232, 22)
        Me.mnuBackImage.Text = "背景画像設定(&B)"
        '
        'mnuObjDataValueShow
        '
        Me.mnuObjDataValueShow.Name = "mnuObjDataValueShow"
        Me.mnuObjDataValueShow.Size = New System.Drawing.Size(232, 22)
        Me.mnuObjDataValueShow.Text = "オブジェクト名・データ値表示(&O)"
        '
        'mnuLocalChabge
        '
        Me.mnuLocalChabge.CheckOnClick = True
        Me.mnuLocalChabge.Name = "mnuLocalChabge"
        Me.mnuLocalChabge.Size = New System.Drawing.Size(232, 22)
        Me.mnuLocalChabge.Text = "局地変動モード(&L)"
        '
        'mnuSet3d
        '
        Me.mnuSet3d.CheckOnClick = True
        Me.mnuSet3d.Name = "mnuSet3d"
        Me.mnuSet3d.Size = New System.Drawing.Size(232, 22)
        Me.mnuSet3d.Text = "3D表示(&3)"
        '
        'mnuPropertyWindow
        '
        Me.mnuPropertyWindow.CheckOnClick = True
        Me.mnuPropertyWindow.Name = "mnuPropertyWindow"
        Me.mnuPropertyWindow.Size = New System.Drawing.Size(232, 22)
        Me.mnuPropertyWindow.Text = "プロパティウインドウ(&P)"
        '
        'mnuOptionRoot
        '
        Me.mnuOptionRoot.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLinePattern, Me.mnuPictureSetting, Me.mnuProjection, Me.mnuOption})
        Me.mnuOptionRoot.Name = "mnuOptionRoot"
        Me.mnuOptionRoot.Size = New System.Drawing.Size(80, 20)
        Me.mnuOptionRoot.Text = "オプション(&O)"
        '
        'mnuLinePattern
        '
        Me.mnuLinePattern.Name = "mnuLinePattern"
        Me.mnuLinePattern.Size = New System.Drawing.Size(198, 22)
        Me.mnuLinePattern.Text = "線種ラインパターン設定(&L)"
        '
        'mnuPictureSetting
        '
        Me.mnuPictureSetting.Name = "mnuPictureSetting"
        Me.mnuPictureSetting.Size = New System.Drawing.Size(198, 22)
        Me.mnuPictureSetting.Text = "画像設定(&I)"
        '
        'mnuProjection
        '
        Me.mnuProjection.Name = "mnuProjection"
        Me.mnuProjection.Size = New System.Drawing.Size(198, 22)
        Me.mnuProjection.Text = "投影法変換(&P)"
        '
        'mnuOption
        '
        Me.mnuOption.Name = "mnuOption"
        Me.mnuOption.Size = New System.Drawing.Size(198, 22)
        Me.mnuOption.Text = "オプション(&O)"
        '
        'mnuFigure
        '
        Me.mnuFigure.Checked = True
        Me.mnuFigure.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuFigure.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFigureMode, Me.mnuFigureList})
        Me.mnuFigure.Name = "mnuFigure"
        Me.mnuFigure.Size = New System.Drawing.Size(82, 20)
        Me.mnuFigure.Text = "図形モード(&T)"
        '
        'mnuFigureMode
        '
        Me.mnuFigureMode.CheckOnClick = True
        Me.mnuFigureMode.Name = "mnuFigureMode"
        Me.mnuFigureMode.Size = New System.Drawing.Size(137, 22)
        Me.mnuFigureMode.Text = "図形モード(T)"
        '
        'mnuFigureList
        '
        Me.mnuFigureList.Name = "mnuFigureList"
        Me.mnuFigureList.Size = New System.Drawing.Size(137, 22)
        Me.mnuFigureList.Text = "図形一覧(L)"
        '
        'mnuPrintOut
        '
        Me.mnuPrintOut.Name = "mnuPrintOut"
        Me.mnuPrintOut.Size = New System.Drawing.Size(58, 20)
        Me.mnuPrintOut.Text = "印刷(&P)"
        '
        'mnuHelp
        '
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(65, 20)
        Me.mnuHelp.Text = "ヘルプ(&H)"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 0
        Me.ToolTip1.ReshowDelay = 100
        '
        'mnuODLineCurveResetMenu
        '
        Me.mnuODLineCurveResetMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuODLineCurveResetMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuODLineCurveReset})
        Me.mnuODLineCurveResetMenu.Name = "mnuODLineCurveResetMenu"
        Me.mnuODLineCurveResetMenu.Size = New System.Drawing.Size(130, 26)
        '
        'mnuODLineCurveReset
        '
        Me.mnuODLineCurveReset.Name = "mnuODLineCurveReset"
        Me.mnuODLineCurveReset.Size = New System.Drawing.Size(129, 22)
        Me.mnuODLineCurveReset.Text = "直線に戻す"
        '
        'mnuAccPopup
        '
        Me.mnuAccPopup.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuAccPopup.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAccPopupInvisible, Me.mnuAccPopupSettings})
        Me.mnuAccPopup.Name = "ContextMenuStrip1"
        Me.mnuAccPopup.Size = New System.Drawing.Size(111, 48)
        '
        'mnuAccPopupInvisible
        '
        Me.mnuAccPopupInvisible.Name = "mnuAccPopupInvisible"
        Me.mnuAccPopupInvisible.Size = New System.Drawing.Size(110, 22)
        Me.mnuAccPopupInvisible.Text = "非表示"
        '
        'mnuAccPopupSettings
        '
        Me.mnuAccPopupSettings.Name = "mnuAccPopupSettings"
        Me.mnuAccPopupSettings.Size = New System.Drawing.Size(110, 22)
        Me.mnuAccPopupSettings.Text = "設定"
        '
        'mnuAccPopupVisible
        '
        Me.mnuAccPopupVisible.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuAccPopupVisible.Name = "mnuAccPopupVisible"
        Me.mnuAccPopupVisible.Size = New System.Drawing.Size(61, 4)
        '
        'pnlDistanceArea
        '
        Me.pnlDistanceArea.Controls.Add(Me.btnClear)
        Me.pnlDistanceArea.Controls.Add(Me.Label3)
        Me.pnlDistanceArea.Controls.Add(Me.lblUnitArea)
        Me.pnlDistanceArea.Controls.Add(Me.lblUnitDis)
        Me.pnlDistanceArea.Controls.Add(Me.txtArea)
        Me.pnlDistanceArea.Controls.Add(Me.txtDistance)
        Me.pnlDistanceArea.Controls.Add(Me.Label2)
        Me.pnlDistanceArea.Controls.Add(Me.Label1)
        Me.pnlDistanceArea.Controls.Add(Me.btnDistanceEnd)
        Me.pnlDistanceArea.Location = New System.Drawing.Point(0, 24)
        Me.pnlDistanceArea.Name = "pnlDistanceArea"
        Me.pnlDistanceArea.Size = New System.Drawing.Size(235, 91)
        Me.pnlDistanceArea.TabIndex = 3
        Me.pnlDistanceArea.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(184, 11)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(48, 23)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "クリア"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(197, 11)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "左クリックでポイント追加、右クリックで1つ戻る"
        '
        'lblUnitArea
        '
        Me.lblUnitArea.AutoSize = True
        Me.lblUnitArea.Location = New System.Drawing.Point(131, 47)
        Me.lblUnitArea.Name = "lblUnitArea"
        Me.lblUnitArea.Size = New System.Drawing.Size(29, 12)
        Me.lblUnitArea.TabIndex = 6
        Me.lblUnitArea.Text = "距離"
        '
        'lblUnitDis
        '
        Me.lblUnitDis.AutoSize = True
        Me.lblUnitDis.Location = New System.Drawing.Point(131, 19)
        Me.lblUnitDis.Name = "lblUnitDis"
        Me.lblUnitDis.Size = New System.Drawing.Size(29, 12)
        Me.lblUnitDis.TabIndex = 5
        Me.lblUnitDis.Text = "距離"
        '
        'txtArea
        '
        Me.txtArea.Location = New System.Drawing.Point(46, 41)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.Size = New System.Drawing.Size(83, 19)
        Me.txtArea.TabIndex = 4
        Me.txtArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDistance
        '
        Me.txtDistance.Location = New System.Drawing.Point(47, 12)
        Me.txtDistance.Name = "txtDistance"
        Me.txtDistance.ReadOnly = True
        Me.txtDistance.Size = New System.Drawing.Size(82, 19)
        Me.txtDistance.TabIndex = 3
        Me.txtDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "面積"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "距離"
        '
        'btnDistanceEnd
        '
        Me.btnDistanceEnd.Location = New System.Drawing.Point(184, 40)
        Me.btnDistanceEnd.Name = "btnDistanceEnd"
        Me.btnDistanceEnd.Size = New System.Drawing.Size(48, 23)
        Me.btnDistanceEnd.TabIndex = 0
        Me.btnDistanceEnd.Text = "終了"
        Me.btnDistanceEnd.UseVisualStyleBackColor = True
        '
        'frmPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(727, 264)
        Me.Controls.Add(Me.pnlDistanceArea)
        Me.Controls.Add(Me.picMap)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmPrint"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.mnuODLineCurveResetMenu.ResumeLayout(False)
        Me.mnuAccPopup.ResumeLayout(False)
        Me.pnlDistanceArea.ResumeLayout(False)
        Me.pnlDistanceArea.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopyAsBitmap As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSet3d As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPropertyWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuOptionRoot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLinePattern As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRedraw As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPictureSetting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFigure As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDummyObjChange As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuODLineCurveResetMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuODLineCurveReset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAccPopup As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuAccPopupInvisible As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAccPopupSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAccPopupVisible As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuFigureMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFigureList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProjection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFormSizeChange As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBackImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintRange As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAnalysis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuScreen_Setting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInstance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTileMapOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTimeSeriesFileOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransPngSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuKMLFileOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStdDaen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGoogleMapOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMultiObjectSelectMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuObjectSerach As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDIstanceArea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlDistanceArea As System.Windows.Forms.Panel
    Friend WithEvents lblUnitArea As System.Windows.Forms.Label
    Friend WithEvents lblUnitDis As System.Windows.Forms.Label
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents txtDistance As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDistanceEnd As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents mnuObjDataValueShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLocalChabge As System.Windows.Forms.ToolStripMenuItem
End Class
