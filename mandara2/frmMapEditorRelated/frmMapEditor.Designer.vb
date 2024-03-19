<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMapEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMapEditor))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveMapFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveMapFileRename = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewrGo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRecentUsedFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSaveAsMPFJ = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMapFileProperty = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsertMapFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuShapefileOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopyScreen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuObjectEditMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineEditMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTimeEditMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuObjectEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuObjectSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSearch_Object_by_Number = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuObjectNameEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReplaceObjectName = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuChangeAllObjectName = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSet_ClickObjectName = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopyObjectName = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCombineSameNameObjecs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAggrObjClipSet = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSetCenterP = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuGetPointObject = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMakeMeshObject = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDefAttData = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuObjectTimeEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTimeObjectSet = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSuccesionView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuObjectNameChangeView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSearch_Line = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineConnect = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineCut_by_CrossPoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineTopolyze = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineNodalPoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineSmoothing = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGetLine = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreview = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAllShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuObjectNameVisible = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineEndPointShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBackImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDefAtrShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImportData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuShapeFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuE00File = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuKMLFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuKiban = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenStreetMap = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCensusSmallArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGetContour = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNewBlankMapData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineKind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSettingLineKind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCombineLineKind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuObjectkind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSettingObjectGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCombineObjectGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCompassSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuConvZahyo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSokutiConvert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConvert_Tokyo97toITRF94 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConvert_ITRF94toTokyo97 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConvert_XY2IdoKedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIdokedoMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReplace_ITRF94_Tokyo97 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProjectionConvert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.SplitContainerTotal = New System.Windows.Forms.SplitContainer()
        Me.pnlLineConnect = New System.Windows.Forms.Panel()
        Me.gbLineConnect = New System.Windows.Forms.GroupBox()
        Me.cbLineLoopEdit = New System.Windows.Forms.CheckBox()
        Me.cbLineBothConnectEdit = New System.Windows.Forms.CheckBox()
        Me.cbLineOneConnectEdit = New System.Windows.Forms.CheckBox()
        Me.cbLineNonConnectEdit = New System.Windows.Forms.CheckBox()
        Me.pnlUsedNumber = New System.Windows.Forms.Panel()
        Me.gbUsetNumber = New System.Windows.Forms.GroupBox()
        Me.cbLineObjectThirdUsedEdit = New System.Windows.Forms.CheckBox()
        Me.cbLineObjectSecondUsedEdit = New System.Windows.Forms.CheckBox()
        Me.cbLineObjectOneUsedEdit = New System.Windows.Forms.CheckBox()
        Me.cbLineObjectNoUsedEdit = New System.Windows.Forms.CheckBox()
        Me.pnlLineKindEdit = New System.Windows.Forms.Panel()
        Me.gbLineKindEdit = New System.Windows.Forms.GroupBox()
        Me.clbLineKindEdit = New mandara10.CheckedListBoxEx()
        Me.ｌｂｌLineEdit = New System.Windows.Forms.Label()
        Me.pnlObjectShapeEdit = New System.Windows.Forms.Panel()
        Me.gbObjShapeEdit = New System.Windows.Forms.GroupBox()
        Me.cbPolygonShapeEdit = New System.Windows.Forms.CheckBox()
        Me.cbLineShapeEdit = New System.Windows.Forms.CheckBox()
        Me.cbPointShapeEdit = New System.Windows.Forms.CheckBox()
        Me.pnlObjTypeEdit = New System.Windows.Forms.Panel()
        Me.gbObjTypeEdit = New System.Windows.Forms.GroupBox()
        Me.rbObjTypeEditAggregation = New System.Windows.Forms.RadioButton()
        Me.rbObjTypeEditNormal = New System.Windows.Forms.RadioButton()
        Me.pnlObjectGroup = New System.Windows.Forms.Panel()
        Me.gbObjGroupEdit = New System.Windows.Forms.GroupBox()
        Me.clbObjectKindEdit = New mandara10.CheckedListBoxEx()
        Me.lblObjectEdit = New System.Windows.Forms.Label()
        Me.pnEditTime = New System.Windows.Forms.Panel()
        Me.gbEditTime = New System.Windows.Forms.GroupBox()
        Me.cbLineTime = New System.Windows.Forms.CheckBox()
        Me.dbdtpEditTime = New mandara10.DbDateTimePicker()
        Me.pnlEdit = New System.Windows.Forms.Panel()
        Me.btnEditPanelHelp = New System.Windows.Forms.Button()
        Me.cbUnEditableVisible = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainerMapAndProperty = New System.Windows.Forms.SplitContainer()
        Me.pnlObjectEdit = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnObjectCancel = New System.Windows.Forms.Button()
        Me.btnObjectDelete = New System.Windows.Forms.Button()
        Me.btnObjectRegist = New System.Windows.Forms.Button()
        Me.btnAutoBoundary = New System.Windows.Forms.Button()
        Me.btnCenterGrabityPoint = New System.Windows.Forms.Button()
        Me.pnlObjectKind = New System.Windows.Forms.Panel()
        Me.gbObjectKind = New System.Windows.Forms.GroupBox()
        Me.cboObjectKind = New mandara10.ComboBoxEx()
        Me.pnlObjectName12 = New System.Windows.Forms.Panel()
        Me.ktObjectName = New KTGISUserControl.KTGISGrid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlObjectEditTop = New System.Windows.Forms.Panel()
        Me.btnObjectEditHelp = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlMultiLines = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMultiLineEnd = New System.Windows.Forms.Button()
        Me.btnMultiLineExe = New System.Windows.Forms.Button()
        Me.lbMultiLineCommand = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnMultiLineClear = New System.Windows.Forms.Button()
        Me.btnOtherLineSelectMethos = New System.Windows.Forms.Button()
        Me.rbMultiLineSelectMode_Polygon = New System.Windows.Forms.RadioButton()
        Me.rbMultiLineSelectMode_Circle = New System.Windows.Forms.RadioButton()
        Me.rbMultiLineSelectMode_Rectangle = New System.Windows.Forms.RadioButton()
        Me.rbMultiLineSelectMode_Pointing = New System.Windows.Forms.RadioButton()
        Me.pnlMultiLineTop = New System.Windows.Forms.Panel()
        Me.btnMultiLinesEditHelp = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlMultiObjects = New System.Windows.Forms.Panel()
        Me.pnlMultiObjectCommand = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMultiPbjectsEnd = New System.Windows.Forms.Button()
        Me.btnMultiObjectsExe = New System.Windows.Forms.Button()
        Me.lbMultiObjectsCommand = New System.Windows.Forms.ListBox()
        Me.lblOperation = New System.Windows.Forms.Label()
        Me.pnlSelectMode = New System.Windows.Forms.Panel()
        Me.gbSelectMode = New System.Windows.Forms.GroupBox()
        Me.btnMultiObjectClear = New System.Windows.Forms.Button()
        Me.btnOtherSelectMethos = New System.Windows.Forms.Button()
        Me.rbMultiObjectSelectMode_Polygon = New System.Windows.Forms.RadioButton()
        Me.rbMultiObjectSelectMode_Circle = New System.Windows.Forms.RadioButton()
        Me.rbMultiObjectSelectMode_Rectangle = New System.Windows.Forms.RadioButton()
        Me.rbMultiObjectSelectMode_Pointing = New System.Windows.Forms.RadioButton()
        Me.pnlMultiObjectTop = New System.Windows.Forms.Panel()
        Me.btnMultiObjectsEditHelp = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlLineEdit = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnLineDivide_and_Node = New System.Windows.Forms.Button()
        Me.btnNode = New System.Windows.Forms.Button()
        Me.btnLineCancel = New System.Windows.Forms.Button()
        Me.btnLineRegist = New System.Windows.Forms.Button()
        Me.btnLineDelete = New System.Windows.Forms.Button()
        Me.btnShowCoord = New System.Windows.Forms.Button()
        Me.pnlLineTimekindSet = New System.Windows.Forms.Panel()
        Me.tbLineKindTime = New System.Windows.Forms.TextBox()
        Me.btnLineTimeKindSet = New System.Windows.Forms.Button()
        Me.pnlLineKind = New System.Windows.Forms.Panel()
        Me.gbLineKind = New System.Windows.Forms.GroupBox()
        Me.cboLineKind = New mandara10.ComboBoxEx()
        Me.pnlLineTop = New System.Windows.Forms.Panel()
        Me.btnLineEditHelp = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlPropertyWindow = New System.Windows.Forms.Panel()
        Me.lvtPropertyWindow = New mandara10.ListViewEX()
        Me.lblProperty = New System.Windows.Forms.Label()
        Me.pnlObjectTimeEdit = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCenterPointTime = New System.Windows.Forms.Button()
        Me.btnSuccession = New System.Windows.Forms.Button()
        Me.btnObjrectRegistTime = New System.Windows.Forms.Button()
        Me.btnTimeObject = New System.Windows.Forms.Button()
        Me.btnObjectDeleteTime = New System.Windows.Forms.Button()
        Me.btnObjectCancelTime = New System.Windows.Forms.Button()
        Me.pnlObjectGroupTime = New System.Windows.Forms.Panel()
        Me.gbObjectGroupTime = New System.Windows.Forms.GroupBox()
        Me.cbObjectGroupTime = New mandara10.ComboBoxEx()
        Me.pnlObjectNameTime = New System.Windows.Forms.Panel()
        Me.gbObjectNameTime = New System.Windows.Forms.GroupBox()
        Me.btnObjNameTimeSet = New System.Windows.Forms.Button()
        Me.tbObjectNameTime = New System.Windows.Forms.TextBox()
        Me.pnlTimeObjectTop = New System.Windows.Forms.Panel()
        Me.btnTimeObjectEditHelp = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPicMap = New System.Windows.Forms.Label()
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.scPropertyAndDefAttribute = New System.Windows.Forms.SplitContainer()
        Me.pnlDefAttribute = New System.Windows.Forms.Panel()
        Me.ktGridDefAttValue = New KTGISUserControl.KTGISGrid()
        Me.lblDefAttribute = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslblY = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslblX = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbAllShow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbBackImage = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbObjectNameVisible = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbLineEndPointShow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbObjectEditMode = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbLineEditMode = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbMultiSelect = New System.Windows.Forms.ToolStripButton()
        Me.btnNewObjectAndLine = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ProgressLabel = New KTGISUserControl.KTGISProgressLabel()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainerTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerTotal.Panel1.SuspendLayout()
        Me.SplitContainerTotal.Panel2.SuspendLayout()
        Me.SplitContainerTotal.SuspendLayout()
        Me.pnlLineConnect.SuspendLayout()
        Me.gbLineConnect.SuspendLayout()
        Me.pnlUsedNumber.SuspendLayout()
        Me.gbUsetNumber.SuspendLayout()
        Me.pnlLineKindEdit.SuspendLayout()
        Me.gbLineKindEdit.SuspendLayout()
        Me.pnlObjectShapeEdit.SuspendLayout()
        Me.gbObjShapeEdit.SuspendLayout()
        Me.pnlObjTypeEdit.SuspendLayout()
        Me.gbObjTypeEdit.SuspendLayout()
        Me.pnlObjectGroup.SuspendLayout()
        Me.gbObjGroupEdit.SuspendLayout()
        Me.pnEditTime.SuspendLayout()
        Me.gbEditTime.SuspendLayout()
        Me.pnlEdit.SuspendLayout()
        CType(Me.SplitContainerMapAndProperty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMapAndProperty.Panel1.SuspendLayout()
        Me.SplitContainerMapAndProperty.Panel2.SuspendLayout()
        Me.SplitContainerMapAndProperty.SuspendLayout()
        Me.pnlObjectEdit.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlObjectKind.SuspendLayout()
        Me.gbObjectKind.SuspendLayout()
        Me.pnlObjectName12.SuspendLayout()
        Me.pnlObjectEditTop.SuspendLayout()
        Me.pnlMultiLines.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlMultiLineTop.SuspendLayout()
        Me.pnlMultiObjects.SuspendLayout()
        Me.pnlMultiObjectCommand.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.pnlSelectMode.SuspendLayout()
        Me.gbSelectMode.SuspendLayout()
        Me.pnlMultiObjectTop.SuspendLayout()
        Me.pnlLineEdit.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.pnlLineTimekindSet.SuspendLayout()
        Me.pnlLineKind.SuspendLayout()
        Me.gbLineKind.SuspendLayout()
        Me.pnlLineTop.SuspendLayout()
        Me.pnlPropertyWindow.SuspendLayout()
        Me.pnlObjectTimeEdit.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnlObjectGroupTime.SuspendLayout()
        Me.gbObjectGroupTime.SuspendLayout()
        Me.pnlObjectNameTime.SuspendLayout()
        Me.gbObjectNameTime.SuspendLayout()
        Me.pnlTimeObjectTop.SuspendLayout()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scPropertyAndDefAttribute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scPropertyAndDefAttribute.Panel2.SuspendLayout()
        Me.scPropertyAndDefAttribute.SuspendLayout()
        Me.pnlDefAttribute.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuObjectEdit, Me.mnuLineEdit, Me.mnuView, Me.mnuImportData, Me.mnuSettings, Me.mnuHelp})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1348, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuOpen, Me.mnuSaveMapFile, Me.mnuSaveMapFileRename, Me.ToolStripMenuItem7, Me.mnuViewrGo, Me.mnuRecentUsedFile, Me.ToolStripMenuItem1, Me.mnuSaveAsMPFJ, Me.mnuMapFileProperty, Me.mnuInsertMapFile, Me.mnuShapefileOut, Me.ToolStripMenuItem9, Me.mnuClose})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(67, 20)
        Me.mnuFile.Text = "ファイル(&F)"
        '
        'mnuNew
        '
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mnuNew.Size = New System.Drawing.Size(322, 22)
        Me.mnuNew.Text = "新規作成(&N)"
        '
        'mnuOpen
        '
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.mnuOpen.Size = New System.Drawing.Size(322, 22)
        Me.mnuOpen.Text = "地図ファイルを開く(&O)"
        '
        'mnuSaveMapFile
        '
        Me.mnuSaveMapFile.Name = "mnuSaveMapFile"
        Me.mnuSaveMapFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuSaveMapFile.Size = New System.Drawing.Size(322, 22)
        Me.mnuSaveMapFile.Text = "地図ファイル保存(&S)"
        '
        'mnuSaveMapFileRename
        '
        Me.mnuSaveMapFileRename.Name = "mnuSaveMapFileRename"
        Me.mnuSaveMapFileRename.Size = New System.Drawing.Size(322, 22)
        Me.mnuSaveMapFileRename.Text = "名前をつけて地図ファイルを保存(&A)"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(319, 6)
        '
        'mnuViewrGo
        '
        Me.mnuViewrGo.Name = "mnuViewrGo"
        Me.mnuViewrGo.Size = New System.Drawing.Size(322, 22)
        Me.mnuViewrGo.Text = "地図ファイルを保存して白地図・初期属性データ表示"
        '
        'mnuRecentUsedFile
        '
        Me.mnuRecentUsedFile.Name = "mnuRecentUsedFile"
        Me.mnuRecentUsedFile.Size = New System.Drawing.Size(322, 22)
        Me.mnuRecentUsedFile.Text = "最近使ったファイル(&F)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(319, 6)
        '
        'mnuSaveAsMPFJ
        '
        Me.mnuSaveAsMPFJ.Name = "mnuSaveAsMPFJ"
        Me.mnuSaveAsMPFJ.Size = New System.Drawing.Size(322, 22)
        Me.mnuSaveAsMPFJ.Text = "MANDARA JS用地図ファイルに出力(&J)"
        '
        'mnuMapFileProperty
        '
        Me.mnuMapFileProperty.Name = "mnuMapFileProperty"
        Me.mnuMapFileProperty.Size = New System.Drawing.Size(322, 22)
        Me.mnuMapFileProperty.Text = "地図ファイルのプロパティ(&P)"
        '
        'mnuInsertMapFile
        '
        Me.mnuInsertMapFile.Name = "mnuInsertMapFile"
        Me.mnuInsertMapFile.Size = New System.Drawing.Size(322, 22)
        Me.mnuInsertMapFile.Text = "地図ファイルの挿入(&I)"
        '
        'mnuShapefileOut
        '
        Me.mnuShapefileOut.Name = "mnuShapefileOut"
        Me.mnuShapefileOut.Size = New System.Drawing.Size(322, 22)
        Me.mnuShapefileOut.Text = "シェープファイル出力(&E)"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(319, 6)
        '
        'mnuClose
        '
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(322, 22)
        Me.mnuClose.Text = "マップエディタの終了(&X)"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUndo, Me.mnuCopyScreen, Me.ToolStripSeparator5, Me.mnuObjectEditMode, Me.mnuLineEditMode, Me.ToolStripMenuItem6, Me.mnuTimeEditMode})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.mnuEdit.Size = New System.Drawing.Size(57, 20)
        Me.mnuEdit.Text = "編集(&E)"
        '
        'mnuUndo
        '
        Me.mnuUndo.Name = "mnuUndo"
        Me.mnuUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.mnuUndo.Size = New System.Drawing.Size(241, 22)
        Me.mnuUndo.Text = "元に戻す(&U)"
        '
        'mnuCopyScreen
        '
        Me.mnuCopyScreen.Name = "mnuCopyScreen"
        Me.mnuCopyScreen.Size = New System.Drawing.Size(241, 22)
        Me.mnuCopyScreen.Text = "画像のコピー(&C)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(238, 6)
        '
        'mnuObjectEditMode
        '
        Me.mnuObjectEditMode.Name = "mnuObjectEditMode"
        Me.mnuObjectEditMode.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.mnuObjectEditMode.Size = New System.Drawing.Size(241, 22)
        Me.mnuObjectEditMode.Text = "オブジェクト編集(&O)"
        '
        'mnuLineEditMode
        '
        Me.mnuLineEditMode.Name = "mnuLineEditMode"
        Me.mnuLineEditMode.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.mnuLineEditMode.Size = New System.Drawing.Size(241, 22)
        Me.mnuLineEditMode.Text = "ライン編集(&L)"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(238, 6)
        '
        'mnuTimeEditMode
        '
        Me.mnuTimeEditMode.Name = "mnuTimeEditMode"
        Me.mnuTimeEditMode.Size = New System.Drawing.Size(241, 22)
        Me.mnuTimeEditMode.Text = "時空間モード(&T)"
        '
        'mnuObjectEdit
        '
        Me.mnuObjectEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuObjectSearch, Me.mnuSearch_Object_by_Number, Me.ToolStripMenuItem8, Me.mnuObjectNameEdit, Me.mnuReplaceObjectName, Me.mnuChangeAllObjectName, Me.mnuSet_ClickObjectName, Me.mnuCopyObjectName, Me.ToolStripMenuItem3, Me.mnuCombineSameNameObjecs, Me.mnuAggrObjClipSet, Me.mnuSetCenterP, Me.ToolStripMenuItem11, Me.mnuGetPointObject, Me.mnuMakeMeshObject, Me.ToolStripMenuItem2, Me.mnuDefAttData, Me.ToolStripMenuItem10, Me.mnuObjectTimeEdit})
        Me.mnuObjectEdit.Name = "mnuObjectEdit"
        Me.mnuObjectEdit.Size = New System.Drawing.Size(112, 20)
        Me.mnuObjectEdit.Text = "オブジェクト編集(&O)"
        '
        'mnuObjectSearch
        '
        Me.mnuObjectSearch.Name = "mnuObjectSearch"
        Me.mnuObjectSearch.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.mnuObjectSearch.Size = New System.Drawing.Size(274, 22)
        Me.mnuObjectSearch.Text = "オブジェクト名検索(&O)"
        '
        'mnuSearch_Object_by_Number
        '
        Me.mnuSearch_Object_by_Number.Name = "mnuSearch_Object_by_Number"
        Me.mnuSearch_Object_by_Number.Size = New System.Drawing.Size(274, 22)
        Me.mnuSearch_Object_by_Number.Text = "オブジェクト番号検索(&S)"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(271, 6)
        '
        'mnuObjectNameEdit
        '
        Me.mnuObjectNameEdit.Name = "mnuObjectNameEdit"
        Me.mnuObjectNameEdit.Size = New System.Drawing.Size(274, 22)
        Me.mnuObjectNameEdit.Text = "オブジェクト名編集(&B)"
        '
        'mnuReplaceObjectName
        '
        Me.mnuReplaceObjectName.Name = "mnuReplaceObjectName"
        Me.mnuReplaceObjectName.Size = New System.Drawing.Size(274, 22)
        Me.mnuReplaceObjectName.Text = "オブジェクト名置換(&R)"
        '
        'mnuChangeAllObjectName
        '
        Me.mnuChangeAllObjectName.Name = "mnuChangeAllObjectName"
        Me.mnuChangeAllObjectName.Size = New System.Drawing.Size(274, 22)
        Me.mnuChangeAllObjectName.Text = "オブジェクト名一括変換(&A)"
        '
        'mnuSet_ClickObjectName
        '
        Me.mnuSet_ClickObjectName.Name = "mnuSet_ClickObjectName"
        Me.mnuSet_ClickObjectName.Size = New System.Drawing.Size(274, 22)
        Me.mnuSet_ClickObjectName.Text = "オブジェクト名のクリック割り当て&N)"
        '
        'mnuCopyObjectName
        '
        Me.mnuCopyObjectName.Name = "mnuCopyObjectName"
        Me.mnuCopyObjectName.Size = New System.Drawing.Size(274, 22)
        Me.mnuCopyObjectName.Text = "オブジェクト名のコピー(&C)"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(271, 6)
        '
        'mnuCombineSameNameObjecs
        '
        Me.mnuCombineSameNameObjecs.Name = "mnuCombineSameNameObjecs"
        Me.mnuCombineSameNameObjecs.Size = New System.Drawing.Size(274, 22)
        Me.mnuCombineSameNameObjecs.Text = "同一オブジェクト名のオブジェクトを結合(&O)"
        '
        'mnuAggrObjClipSet
        '
        Me.mnuAggrObjClipSet.Name = "mnuAggrObjClipSet"
        Me.mnuAggrObjClipSet.Size = New System.Drawing.Size(274, 22)
        Me.mnuAggrObjClipSet.Text = "集成オブジェクトにまとめて設定(&B)"
        '
        'mnuSetCenterP
        '
        Me.mnuSetCenterP.Name = "mnuSetCenterP"
        Me.mnuSetCenterP.Size = New System.Drawing.Size(274, 22)
        Me.mnuSetCenterP.Text = "代表点座標一括設定(&D)"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(271, 6)
        '
        'mnuGetPointObject
        '
        Me.mnuGetPointObject.Name = "mnuGetPointObject"
        Me.mnuGetPointObject.Size = New System.Drawing.Size(274, 22)
        Me.mnuGetPointObject.Text = "点オブジェクトの取り込み(&P)"
        '
        'mnuMakeMeshObject
        '
        Me.mnuMakeMeshObject.Name = "mnuMakeMeshObject"
        Me.mnuMakeMeshObject.Size = New System.Drawing.Size(274, 22)
        Me.mnuMakeMeshObject.Text = "メッシュオブジェクトの作成(&M)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(271, 6)
        '
        'mnuDefAttData
        '
        Me.mnuDefAttData.Name = "mnuDefAttData"
        Me.mnuDefAttData.Size = New System.Drawing.Size(274, 22)
        Me.mnuDefAttData.Text = "初期属性データ編集(&E)"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(271, 6)
        '
        'mnuObjectTimeEdit
        '
        Me.mnuObjectTimeEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTimeObjectSet, Me.mnuSuccesionView, Me.mnuObjectNameChangeView})
        Me.mnuObjectTimeEdit.Name = "mnuObjectTimeEdit"
        Me.mnuObjectTimeEdit.Size = New System.Drawing.Size(274, 22)
        Me.mnuObjectTimeEdit.Text = "時間設定(&T)"
        '
        'mnuTimeObjectSet
        '
        Me.mnuTimeObjectSet.Name = "mnuTimeObjectSet"
        Me.mnuTimeObjectSet.Size = New System.Drawing.Size(203, 22)
        Me.mnuTimeObjectSet.Text = "時間情報の一括設定(&A)"
        '
        'mnuSuccesionView
        '
        Me.mnuSuccesionView.Name = "mnuSuccesionView"
        Me.mnuSuccesionView.Size = New System.Drawing.Size(203, 22)
        Me.mnuSuccesionView.Text = "継承情報一覧(&S)"
        '
        'mnuObjectNameChangeView
        '
        Me.mnuObjectNameChangeView.Name = "mnuObjectNameChangeView"
        Me.mnuObjectNameChangeView.Size = New System.Drawing.Size(203, 22)
        Me.mnuObjectNameChangeView.Text = "オブジェクト名変更一覧(&O)"
        '
        'mnuLineEdit
        '
        Me.mnuLineEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSearch_Line, Me.mnuLineConnect, Me.mnuLineCut_by_CrossPoint, Me.mnuLineTopolyze, Me.mnuLineNodalPoint, Me.mnuLineSmoothing, Me.mnuGetLine})
        Me.mnuLineEdit.Name = "mnuLineEdit"
        Me.mnuLineEdit.Size = New System.Drawing.Size(83, 20)
        Me.mnuLineEdit.Text = "ライン編集(&L)"
        '
        'mnuSearch_Line
        '
        Me.mnuSearch_Line.Name = "mnuSearch_Line"
        Me.mnuSearch_Line.Size = New System.Drawing.Size(229, 22)
        Me.mnuSearch_Line.Text = "ライン番号検索(&S)"
        '
        'mnuLineConnect
        '
        Me.mnuLineConnect.Name = "mnuLineConnect"
        Me.mnuLineConnect.Size = New System.Drawing.Size(229, 22)
        Me.mnuLineConnect.Text = "ライン結合(&C)"
        '
        'mnuLineCut_by_CrossPoint
        '
        Me.mnuLineCut_by_CrossPoint.Name = "mnuLineCut_by_CrossPoint"
        Me.mnuLineCut_by_CrossPoint.Size = New System.Drawing.Size(229, 22)
        Me.mnuLineCut_by_CrossPoint.Text = "ラインを交点で切断(&R)"
        '
        'mnuLineTopolyze
        '
        Me.mnuLineTopolyze.Name = "mnuLineTopolyze"
        Me.mnuLineTopolyze.Size = New System.Drawing.Size(229, 22)
        Me.mnuLineTopolyze.Text = "ラインの共有部分を別ラインに(&P)"
        '
        'mnuLineNodalPoint
        '
        Me.mnuLineNodalPoint.Name = "mnuLineNodalPoint"
        Me.mnuLineNodalPoint.Size = New System.Drawing.Size(229, 22)
        Me.mnuLineNodalPoint.Text = "端点結合(&N)"
        '
        'mnuLineSmoothing
        '
        Me.mnuLineSmoothing.Name = "mnuLineSmoothing"
        Me.mnuLineSmoothing.Size = New System.Drawing.Size(229, 22)
        Me.mnuLineSmoothing.Text = "ポイント・ループ間引き(&T)"
        '
        'mnuGetLine
        '
        Me.mnuGetLine.Name = "mnuGetLine"
        Me.mnuGetLine.Size = New System.Drawing.Size(229, 22)
        Me.mnuGetLine.Text = "ラインの取り込み(&D)"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPreview, Me.mnuAllShow, Me.mnuObjectNameVisible, Me.mnuLineEndPointShow, Me.ToolStripMenuItem5, Me.mnuBackImage, Me.mnuDefAtrShow})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(58, 20)
        Me.mnuView.Text = "表示(&V)"
        '
        'mnuPreview
        '
        Me.mnuPreview.Name = "mnuPreview"
        Me.mnuPreview.Size = New System.Drawing.Size(179, 22)
        Me.mnuPreview.Text = "プレビュー(&P)"
        '
        'mnuAllShow
        '
        Me.mnuAllShow.Name = "mnuAllShow"
        Me.mnuAllShow.Size = New System.Drawing.Size(179, 22)
        Me.mnuAllShow.Text = "全体表示(&A)"
        '
        'mnuObjectNameVisible
        '
        Me.mnuObjectNameVisible.Name = "mnuObjectNameVisible"
        Me.mnuObjectNameVisible.Size = New System.Drawing.Size(179, 22)
        Me.mnuObjectNameVisible.Text = "オブジェクト名表示(&O)"
        '
        'mnuLineEndPointShow
        '
        Me.mnuLineEndPointShow.Name = "mnuLineEndPointShow"
        Me.mnuLineEndPointShow.Size = New System.Drawing.Size(179, 22)
        Me.mnuLineEndPointShow.Text = "ライン端点表示(&L)"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(176, 6)
        '
        'mnuBackImage
        '
        Me.mnuBackImage.Name = "mnuBackImage"
        Me.mnuBackImage.Size = New System.Drawing.Size(179, 22)
        Me.mnuBackImage.Text = "背景画像表示(&B)"
        '
        'mnuDefAtrShow
        '
        Me.mnuDefAtrShow.Name = "mnuDefAtrShow"
        Me.mnuDefAtrShow.Size = New System.Drawing.Size(179, 22)
        Me.mnuDefAtrShow.Text = "初期属性表示(&D)"
        '
        'mnuImportData
        '
        Me.mnuImportData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShapeFile, Me.mnuE00File, Me.mnuKMLFile, Me.mnuKiban, Me.mnuOpenStreetMap, Me.mnuCensusSmallArea, Me.mnuGetContour, Me.mnuNewBlankMapData})
        Me.mnuImportData.Name = "mnuImportData"
        Me.mnuImportData.Size = New System.Drawing.Size(112, 20)
        Me.mnuImportData.Text = "地図データ取得(&M)"
        '
        'mnuShapeFile
        '
        Me.mnuShapeFile.Name = "mnuShapeFile"
        Me.mnuShapeFile.Size = New System.Drawing.Size(239, 22)
        Me.mnuShapeFile.Text = "シェープファイル(&S)"
        '
        'mnuE00File
        '
        Me.mnuE00File.Name = "mnuE00File"
        Me.mnuE00File.Size = New System.Drawing.Size(239, 22)
        Me.mnuE00File.Text = "Exprort(e00)形式ファイル(&E)"
        '
        'mnuKMLFile
        '
        Me.mnuKMLFile.Name = "mnuKMLFile"
        Me.mnuKMLFile.Size = New System.Drawing.Size(239, 22)
        Me.mnuKMLFile.Text = "KML/KMZファイル(&K)"
        '
        'mnuKiban
        '
        Me.mnuKiban.Name = "mnuKiban"
        Me.mnuKiban.Size = New System.Drawing.Size(239, 22)
        Me.mnuKiban.Text = "基盤地図情報(&G)"
        '
        'mnuOpenStreetMap
        '
        Me.mnuOpenStreetMap.Name = "mnuOpenStreetMap"
        Me.mnuOpenStreetMap.Size = New System.Drawing.Size(239, 22)
        Me.mnuOpenStreetMap.Text = "オープンストリートマップデータ(&O)"
        '
        'mnuCensusSmallArea
        '
        Me.mnuCensusSmallArea.Name = "mnuCensusSmallArea"
        Me.mnuCensusSmallArea.Size = New System.Drawing.Size(239, 22)
        Me.mnuCensusSmallArea.Text = "統計GIS国勢調査小地域データ(&S)"
        '
        'mnuGetContour
        '
        Me.mnuGetContour.Name = "mnuGetContour"
        Me.mnuGetContour.Size = New System.Drawing.Size(239, 22)
        Me.mnuGetContour.Text = "標高データから等高線取得(&C)"
        '
        'mnuNewBlankMapData
        '
        Me.mnuNewBlankMapData.Name = "mnuNewBlankMapData"
        Me.mnuNewBlankMapData.Size = New System.Drawing.Size(239, 22)
        Me.mnuNewBlankMapData.Text = "ブランクデータ作成(&N)"
        '
        'mnuSettings
        '
        Me.mnuSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLineKind, Me.mnuObjectkind, Me.mnuCompassSetting, Me.ToolStripMenuItem4, Me.mnuConvZahyo, Me.mnuProjectionConvert, Me.mnuOption})
        Me.mnuSettings.Name = "mnuSettings"
        Me.mnuSettings.Size = New System.Drawing.Size(57, 20)
        Me.mnuSettings.Text = "設定(&S)"
        '
        'mnuLineKind
        '
        Me.mnuLineKind.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettingLineKind, Me.mnuCombineLineKind})
        Me.mnuLineKind.Name = "mnuLineKind"
        Me.mnuLineKind.Size = New System.Drawing.Size(202, 22)
        Me.mnuLineKind.Text = "線種設定(&L)"
        '
        'mnuSettingLineKind
        '
        Me.mnuSettingLineKind.Name = "mnuSettingLineKind"
        Me.mnuSettingLineKind.Size = New System.Drawing.Size(137, 22)
        Me.mnuSettingLineKind.Text = "線種設定(&L)"
        '
        'mnuCombineLineKind
        '
        Me.mnuCombineLineKind.Name = "mnuCombineLineKind"
        Me.mnuCombineLineKind.Size = New System.Drawing.Size(137, 22)
        Me.mnuCombineLineKind.Text = "線種統合(&C)"
        '
        'mnuObjectkind
        '
        Me.mnuObjectkind.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettingObjectGroup, Me.mnuCombineObjectGroup})
        Me.mnuObjectkind.Name = "mnuObjectkind"
        Me.mnuObjectkind.Size = New System.Drawing.Size(202, 22)
        Me.mnuObjectkind.Text = "オブジェクトグループ設定(&G)"
        '
        'mnuSettingObjectGroup
        '
        Me.mnuSettingObjectGroup.Name = "mnuSettingObjectGroup"
        Me.mnuSettingObjectGroup.Size = New System.Drawing.Size(202, 22)
        Me.mnuSettingObjectGroup.Text = "オブジェクトグループ設定(&G)"
        '
        'mnuCombineObjectGroup
        '
        Me.mnuCombineObjectGroup.Name = "mnuCombineObjectGroup"
        Me.mnuCombineObjectGroup.Size = New System.Drawing.Size(202, 22)
        Me.mnuCombineObjectGroup.Text = "オブジェクトグループ統合(&C)"
        '
        'mnuCompassSetting
        '
        Me.mnuCompassSetting.Name = "mnuCompassSetting"
        Me.mnuCompassSetting.Size = New System.Drawing.Size(202, 22)
        Me.mnuCompassSetting.Text = "方位設定(&C)"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(199, 6)
        '
        'mnuConvZahyo
        '
        Me.mnuConvZahyo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSokutiConvert, Me.mnuConvert_XY2IdoKedo, Me.mnuIdokedoMove, Me.mnuReplace_ITRF94_Tokyo97})
        Me.mnuConvZahyo.Name = "mnuConvZahyo"
        Me.mnuConvZahyo.Size = New System.Drawing.Size(202, 22)
        Me.mnuConvZahyo.Text = "座標変換(&Z)"
        '
        'mnuSokutiConvert
        '
        Me.mnuSokutiConvert.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConvert_Tokyo97toITRF94, Me.mnuConvert_ITRF94toTokyo97})
        Me.mnuSokutiConvert.Name = "mnuSokutiConvert"
        Me.mnuSokutiConvert.Size = New System.Drawing.Size(289, 22)
        Me.mnuSokutiConvert.Text = "緯度経度座標系の測地系変換(&S)"
        '
        'mnuConvert_Tokyo97toITRF94
        '
        Me.mnuConvert_Tokyo97toITRF94.Name = "mnuConvert_Tokyo97toITRF94"
        Me.mnuConvert_Tokyo97toITRF94.Size = New System.Drawing.Size(223, 22)
        Me.mnuConvert_Tokyo97toITRF94.Text = "日本測地系→世界測地系(&N)"
        '
        'mnuConvert_ITRF94toTokyo97
        '
        Me.mnuConvert_ITRF94toTokyo97.Name = "mnuConvert_ITRF94toTokyo97"
        Me.mnuConvert_ITRF94toTokyo97.Size = New System.Drawing.Size(223, 22)
        Me.mnuConvert_ITRF94toTokyo97.Text = "世界測地系→日本測地系(&S)"
        '
        'mnuConvert_XY2IdoKedo
        '
        Me.mnuConvert_XY2IdoKedo.Name = "mnuConvert_XY2IdoKedo"
        Me.mnuConvert_XY2IdoKedo.Size = New System.Drawing.Size(289, 22)
        Me.mnuConvert_XY2IdoKedo.Text = "平面直角座標系を緯度経度座標に変換(&H)"
        '
        'mnuIdokedoMove
        '
        Me.mnuIdokedoMove.Name = "mnuIdokedoMove"
        Me.mnuIdokedoMove.Size = New System.Drawing.Size(289, 22)
        Me.mnuIdokedoMove.Text = "緯度経度指定平行移動(&M)"
        '
        'mnuReplace_ITRF94_Tokyo97
        '
        Me.mnuReplace_ITRF94_Tokyo97.Name = "mnuReplace_ITRF94_Tokyo97"
        Me.mnuReplace_ITRF94_Tokyo97.Size = New System.Drawing.Size(289, 22)
        Me.mnuReplace_ITRF94_Tokyo97.Text = "測地系をの入れ替え(&R)"
        '
        'mnuProjectionConvert
        '
        Me.mnuProjectionConvert.Name = "mnuProjectionConvert"
        Me.mnuProjectionConvert.Size = New System.Drawing.Size(202, 22)
        Me.mnuProjectionConvert.Text = "投影法変換(&P)"
        '
        'mnuOption
        '
        Me.mnuOption.Name = "mnuOption"
        Me.mnuOption.Size = New System.Drawing.Size(202, 22)
        Me.mnuOption.Text = "オプション(&O)"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator9})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(65, 20)
        Me.mnuHelp.Text = "ヘルプ(&H)"
        '
        'toolStripSeparator9
        '
        Me.toolStripSeparator9.Name = "toolStripSeparator9"
        Me.toolStripSeparator9.Size = New System.Drawing.Size(57, 6)
        '
        'SplitContainerTotal
        '
        Me.SplitContainerTotal.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainerTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerTotal.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainerTotal.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainerTotal.Name = "SplitContainerTotal"
        '
        'SplitContainerTotal.Panel1
        '
        Me.SplitContainerTotal.Panel1.AutoScroll = True
        Me.SplitContainerTotal.Panel1.Controls.Add(Me.pnlLineConnect)
        Me.SplitContainerTotal.Panel1.Controls.Add(Me.pnlUsedNumber)
        Me.SplitContainerTotal.Panel1.Controls.Add(Me.pnlLineKindEdit)
        Me.SplitContainerTotal.Panel1.Controls.Add(Me.ｌｂｌLineEdit)
        Me.SplitContainerTotal.Panel1.Controls.Add(Me.pnlObjectShapeEdit)
        Me.SplitContainerTotal.Panel1.Controls.Add(Me.pnlObjTypeEdit)
        Me.SplitContainerTotal.Panel1.Controls.Add(Me.pnlObjectGroup)
        Me.SplitContainerTotal.Panel1.Controls.Add(Me.pnEditTime)
        Me.SplitContainerTotal.Panel1.Controls.Add(Me.pnlEdit)
        '
        'SplitContainerTotal.Panel2
        '
        Me.SplitContainerTotal.Panel2.Controls.Add(Me.SplitContainerMapAndProperty)
        Me.SplitContainerTotal.Size = New System.Drawing.Size(1348, 897)
        Me.SplitContainerTotal.SplitterDistance = 203
        Me.SplitContainerTotal.SplitterWidth = 3
        Me.SplitContainerTotal.TabIndex = 12
        '
        'pnlLineConnect
        '
        Me.pnlLineConnect.Controls.Add(Me.gbLineConnect)
        Me.pnlLineConnect.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLineConnect.Location = New System.Drawing.Point(0, 636)
        Me.pnlLineConnect.Name = "pnlLineConnect"
        Me.pnlLineConnect.Padding = New System.Windows.Forms.Padding(1, 5, 1, 5)
        Me.pnlLineConnect.Size = New System.Drawing.Size(203, 70)
        Me.pnlLineConnect.TabIndex = 18
        '
        'gbLineConnect
        '
        Me.gbLineConnect.Controls.Add(Me.cbLineLoopEdit)
        Me.gbLineConnect.Controls.Add(Me.cbLineBothConnectEdit)
        Me.gbLineConnect.Controls.Add(Me.cbLineOneConnectEdit)
        Me.gbLineConnect.Controls.Add(Me.cbLineNonConnectEdit)
        Me.gbLineConnect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbLineConnect.Location = New System.Drawing.Point(1, 5)
        Me.gbLineConnect.Margin = New System.Windows.Forms.Padding(2)
        Me.gbLineConnect.Name = "gbLineConnect"
        Me.gbLineConnect.Padding = New System.Windows.Forms.Padding(2)
        Me.gbLineConnect.Size = New System.Drawing.Size(201, 60)
        Me.gbLineConnect.TabIndex = 9
        Me.gbLineConnect.TabStop = False
        Me.gbLineConnect.Text = "ラインの結節関係"
        '
        'cbLineLoopEdit
        '
        Me.cbLineLoopEdit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbLineLoopEdit.AutoSize = True
        Me.cbLineLoopEdit.Location = New System.Drawing.Point(83, 37)
        Me.cbLineLoopEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbLineLoopEdit.Name = "cbLineLoopEdit"
        Me.cbLineLoopEdit.Size = New System.Drawing.Size(53, 16)
        Me.cbLineLoopEdit.TabIndex = 4
        Me.cbLineLoopEdit.Text = "ループ"
        Me.cbLineLoopEdit.UseVisualStyleBackColor = True
        '
        'cbLineBothConnectEdit
        '
        Me.cbLineBothConnectEdit.AutoSize = True
        Me.cbLineBothConnectEdit.Location = New System.Drawing.Point(10, 37)
        Me.cbLineBothConnectEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbLineBothConnectEdit.Name = "cbLineBothConnectEdit"
        Me.cbLineBothConnectEdit.Size = New System.Drawing.Size(72, 16)
        Me.cbLineBothConnectEdit.TabIndex = 3
        Me.cbLineBothConnectEdit.Text = "両結節点"
        Me.cbLineBothConnectEdit.UseVisualStyleBackColor = True
        '
        'cbLineOneConnectEdit
        '
        Me.cbLineOneConnectEdit.AutoSize = True
        Me.cbLineOneConnectEdit.Location = New System.Drawing.Point(83, 17)
        Me.cbLineOneConnectEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbLineOneConnectEdit.Name = "cbLineOneConnectEdit"
        Me.cbLineOneConnectEdit.Size = New System.Drawing.Size(72, 16)
        Me.cbLineOneConnectEdit.TabIndex = 2
        Me.cbLineOneConnectEdit.Text = "方結節点"
        Me.cbLineOneConnectEdit.UseVisualStyleBackColor = True
        '
        'cbLineNonConnectEdit
        '
        Me.cbLineNonConnectEdit.AutoSize = True
        Me.cbLineNonConnectEdit.Location = New System.Drawing.Point(10, 17)
        Me.cbLineNonConnectEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbLineNonConnectEdit.Name = "cbLineNonConnectEdit"
        Me.cbLineNonConnectEdit.Size = New System.Drawing.Size(72, 16)
        Me.cbLineNonConnectEdit.TabIndex = 1
        Me.cbLineNonConnectEdit.Text = "非結節点"
        Me.cbLineNonConnectEdit.UseVisualStyleBackColor = True
        '
        'pnlUsedNumber
        '
        Me.pnlUsedNumber.Controls.Add(Me.gbUsetNumber)
        Me.pnlUsedNumber.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlUsedNumber.Location = New System.Drawing.Point(0, 566)
        Me.pnlUsedNumber.Name = "pnlUsedNumber"
        Me.pnlUsedNumber.Padding = New System.Windows.Forms.Padding(1, 5, 1, 5)
        Me.pnlUsedNumber.Size = New System.Drawing.Size(203, 70)
        Me.pnlUsedNumber.TabIndex = 12
        '
        'gbUsetNumber
        '
        Me.gbUsetNumber.Controls.Add(Me.cbLineObjectThirdUsedEdit)
        Me.gbUsetNumber.Controls.Add(Me.cbLineObjectSecondUsedEdit)
        Me.gbUsetNumber.Controls.Add(Me.cbLineObjectOneUsedEdit)
        Me.gbUsetNumber.Controls.Add(Me.cbLineObjectNoUsedEdit)
        Me.gbUsetNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbUsetNumber.Location = New System.Drawing.Point(1, 5)
        Me.gbUsetNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.gbUsetNumber.Name = "gbUsetNumber"
        Me.gbUsetNumber.Padding = New System.Windows.Forms.Padding(2)
        Me.gbUsetNumber.Size = New System.Drawing.Size(201, 60)
        Me.gbUsetNumber.TabIndex = 10
        Me.gbUsetNumber.TabStop = False
        Me.gbUsetNumber.Text = "オブジェクトによる使用回数"
        '
        'cbLineObjectThirdUsedEdit
        '
        Me.cbLineObjectThirdUsedEdit.AutoSize = True
        Me.cbLineObjectThirdUsedEdit.Location = New System.Drawing.Point(80, 37)
        Me.cbLineObjectThirdUsedEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbLineObjectThirdUsedEdit.Name = "cbLineObjectThirdUsedEdit"
        Me.cbLineObjectThirdUsedEdit.Size = New System.Drawing.Size(54, 16)
        Me.cbLineObjectThirdUsedEdit.TabIndex = 5
        Me.cbLineObjectThirdUsedEdit.Text = "3回～"
        Me.cbLineObjectThirdUsedEdit.UseVisualStyleBackColor = True
        '
        'cbLineObjectSecondUsedEdit
        '
        Me.cbLineObjectSecondUsedEdit.AutoSize = True
        Me.cbLineObjectSecondUsedEdit.Location = New System.Drawing.Point(10, 37)
        Me.cbLineObjectSecondUsedEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbLineObjectSecondUsedEdit.Name = "cbLineObjectSecondUsedEdit"
        Me.cbLineObjectSecondUsedEdit.Size = New System.Drawing.Size(42, 16)
        Me.cbLineObjectSecondUsedEdit.TabIndex = 4
        Me.cbLineObjectSecondUsedEdit.Text = "2回"
        Me.cbLineObjectSecondUsedEdit.UseVisualStyleBackColor = True
        '
        'cbLineObjectOneUsedEdit
        '
        Me.cbLineObjectOneUsedEdit.AutoSize = True
        Me.cbLineObjectOneUsedEdit.Location = New System.Drawing.Point(80, 16)
        Me.cbLineObjectOneUsedEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbLineObjectOneUsedEdit.Name = "cbLineObjectOneUsedEdit"
        Me.cbLineObjectOneUsedEdit.Size = New System.Drawing.Size(42, 16)
        Me.cbLineObjectOneUsedEdit.TabIndex = 3
        Me.cbLineObjectOneUsedEdit.Text = "1回"
        Me.cbLineObjectOneUsedEdit.UseVisualStyleBackColor = True
        '
        'cbLineObjectNoUsedEdit
        '
        Me.cbLineObjectNoUsedEdit.AutoSize = True
        Me.cbLineObjectNoUsedEdit.Location = New System.Drawing.Point(10, 17)
        Me.cbLineObjectNoUsedEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbLineObjectNoUsedEdit.Name = "cbLineObjectNoUsedEdit"
        Me.cbLineObjectNoUsedEdit.Size = New System.Drawing.Size(60, 16)
        Me.cbLineObjectNoUsedEdit.TabIndex = 2
        Me.cbLineObjectNoUsedEdit.Text = "未使用"
        Me.cbLineObjectNoUsedEdit.UseVisualStyleBackColor = True
        '
        'pnlLineKindEdit
        '
        Me.pnlLineKindEdit.Controls.Add(Me.gbLineKindEdit)
        Me.pnlLineKindEdit.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLineKindEdit.Location = New System.Drawing.Point(0, 410)
        Me.pnlLineKindEdit.Name = "pnlLineKindEdit"
        Me.pnlLineKindEdit.Padding = New System.Windows.Forms.Padding(1, 5, 1, 5)
        Me.pnlLineKindEdit.Size = New System.Drawing.Size(203, 156)
        Me.pnlLineKindEdit.TabIndex = 17
        '
        'gbLineKindEdit
        '
        Me.gbLineKindEdit.Controls.Add(Me.clbLineKindEdit)
        Me.gbLineKindEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbLineKindEdit.Location = New System.Drawing.Point(1, 5)
        Me.gbLineKindEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.gbLineKindEdit.Name = "gbLineKindEdit"
        Me.gbLineKindEdit.Padding = New System.Windows.Forms.Padding(5)
        Me.gbLineKindEdit.Size = New System.Drawing.Size(201, 146)
        Me.gbLineKindEdit.TabIndex = 8
        Me.gbLineKindEdit.TabStop = False
        Me.gbLineKindEdit.Text = "線種"
        '
        'clbLineKindEdit
        '
        Me.clbLineKindEdit.CheckOnClick = True
        Me.clbLineKindEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbLineKindEdit.EventStop = True
        Me.clbLineKindEdit.FormattingEnabled = True
        Me.clbLineKindEdit.Location = New System.Drawing.Point(5, 17)
        Me.clbLineKindEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.clbLineKindEdit.Name = "clbLineKindEdit"
        Me.clbLineKindEdit.Size = New System.Drawing.Size(191, 124)
        Me.clbLineKindEdit.TabIndex = 0
        '
        'ｌｂｌLineEdit
        '
        Me.ｌｂｌLineEdit.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ｌｂｌLineEdit.Dock = System.Windows.Forms.DockStyle.Top
        Me.ｌｂｌLineEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ｌｂｌLineEdit.Location = New System.Drawing.Point(0, 396)
        Me.ｌｂｌLineEdit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ｌｂｌLineEdit.Name = "ｌｂｌLineEdit"
        Me.ｌｂｌLineEdit.Size = New System.Drawing.Size(203, 14)
        Me.ｌｂｌLineEdit.TabIndex = 12
        Me.ｌｂｌLineEdit.Text = "ライン"
        Me.ｌｂｌLineEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlObjectShapeEdit
        '
        Me.pnlObjectShapeEdit.Controls.Add(Me.gbObjShapeEdit)
        Me.pnlObjectShapeEdit.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlObjectShapeEdit.Location = New System.Drawing.Point(0, 336)
        Me.pnlObjectShapeEdit.Name = "pnlObjectShapeEdit"
        Me.pnlObjectShapeEdit.Padding = New System.Windows.Forms.Padding(1, 5, 1, 5)
        Me.pnlObjectShapeEdit.Size = New System.Drawing.Size(203, 60)
        Me.pnlObjectShapeEdit.TabIndex = 16
        '
        'gbObjShapeEdit
        '
        Me.gbObjShapeEdit.Controls.Add(Me.cbPolygonShapeEdit)
        Me.gbObjShapeEdit.Controls.Add(Me.cbLineShapeEdit)
        Me.gbObjShapeEdit.Controls.Add(Me.cbPointShapeEdit)
        Me.gbObjShapeEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbObjShapeEdit.Location = New System.Drawing.Point(1, 5)
        Me.gbObjShapeEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjShapeEdit.Name = "gbObjShapeEdit"
        Me.gbObjShapeEdit.Padding = New System.Windows.Forms.Padding(2)
        Me.gbObjShapeEdit.Size = New System.Drawing.Size(201, 50)
        Me.gbObjShapeEdit.TabIndex = 7
        Me.gbObjShapeEdit.TabStop = False
        Me.gbObjShapeEdit.Text = "オブジェクトの形状"
        '
        'cbPolygonShapeEdit
        '
        Me.cbPolygonShapeEdit.AutoSize = True
        Me.cbPolygonShapeEdit.Location = New System.Drawing.Point(113, 23)
        Me.cbPolygonShapeEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbPolygonShapeEdit.Name = "cbPolygonShapeEdit"
        Me.cbPolygonShapeEdit.Size = New System.Drawing.Size(36, 16)
        Me.cbPolygonShapeEdit.TabIndex = 2
        Me.cbPolygonShapeEdit.Text = "面"
        Me.cbPolygonShapeEdit.UseVisualStyleBackColor = True
        '
        'cbLineShapeEdit
        '
        Me.cbLineShapeEdit.AutoSize = True
        Me.cbLineShapeEdit.Location = New System.Drawing.Point(60, 23)
        Me.cbLineShapeEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbLineShapeEdit.Name = "cbLineShapeEdit"
        Me.cbLineShapeEdit.Size = New System.Drawing.Size(36, 16)
        Me.cbLineShapeEdit.TabIndex = 1
        Me.cbLineShapeEdit.Text = "線"
        Me.cbLineShapeEdit.UseVisualStyleBackColor = True
        '
        'cbPointShapeEdit
        '
        Me.cbPointShapeEdit.AutoSize = True
        Me.cbPointShapeEdit.Location = New System.Drawing.Point(10, 23)
        Me.cbPointShapeEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbPointShapeEdit.Name = "cbPointShapeEdit"
        Me.cbPointShapeEdit.Size = New System.Drawing.Size(36, 16)
        Me.cbPointShapeEdit.TabIndex = 0
        Me.cbPointShapeEdit.Text = "点"
        Me.cbPointShapeEdit.UseVisualStyleBackColor = True
        '
        'pnlObjTypeEdit
        '
        Me.pnlObjTypeEdit.Controls.Add(Me.gbObjTypeEdit)
        Me.pnlObjTypeEdit.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlObjTypeEdit.Location = New System.Drawing.Point(0, 278)
        Me.pnlObjTypeEdit.Name = "pnlObjTypeEdit"
        Me.pnlObjTypeEdit.Padding = New System.Windows.Forms.Padding(1, 5, 1, 5)
        Me.pnlObjTypeEdit.Size = New System.Drawing.Size(203, 58)
        Me.pnlObjTypeEdit.TabIndex = 4
        '
        'gbObjTypeEdit
        '
        Me.gbObjTypeEdit.Controls.Add(Me.rbObjTypeEditAggregation)
        Me.gbObjTypeEdit.Controls.Add(Me.rbObjTypeEditNormal)
        Me.gbObjTypeEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbObjTypeEdit.Location = New System.Drawing.Point(1, 5)
        Me.gbObjTypeEdit.Margin = New System.Windows.Forms.Padding(2, 8, 2, 2)
        Me.gbObjTypeEdit.Name = "gbObjTypeEdit"
        Me.gbObjTypeEdit.Padding = New System.Windows.Forms.Padding(2)
        Me.gbObjTypeEdit.Size = New System.Drawing.Size(201, 48)
        Me.gbObjTypeEdit.TabIndex = 5
        Me.gbObjTypeEdit.TabStop = False
        Me.gbObjTypeEdit.Text = "オブジェクトのタイプ"
        '
        'rbObjTypeEditAggregation
        '
        Me.rbObjTypeEditAggregation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbObjTypeEditAggregation.AutoSize = True
        Me.rbObjTypeEditAggregation.Location = New System.Drawing.Point(71, 21)
        Me.rbObjTypeEditAggregation.Margin = New System.Windows.Forms.Padding(2)
        Me.rbObjTypeEditAggregation.Name = "rbObjTypeEditAggregation"
        Me.rbObjTypeEditAggregation.Size = New System.Drawing.Size(47, 16)
        Me.rbObjTypeEditAggregation.TabIndex = 1
        Me.rbObjTypeEditAggregation.Text = "集成"
        Me.rbObjTypeEditAggregation.UseVisualStyleBackColor = True
        '
        'rbObjTypeEditNormal
        '
        Me.rbObjTypeEditNormal.AutoSize = True
        Me.rbObjTypeEditNormal.Checked = True
        Me.rbObjTypeEditNormal.Location = New System.Drawing.Point(10, 21)
        Me.rbObjTypeEditNormal.Margin = New System.Windows.Forms.Padding(2)
        Me.rbObjTypeEditNormal.Name = "rbObjTypeEditNormal"
        Me.rbObjTypeEditNormal.Size = New System.Drawing.Size(47, 16)
        Me.rbObjTypeEditNormal.TabIndex = 0
        Me.rbObjTypeEditNormal.TabStop = True
        Me.rbObjTypeEditNormal.Text = "通常"
        Me.rbObjTypeEditNormal.UseVisualStyleBackColor = True
        '
        'pnlObjectGroup
        '
        Me.pnlObjectGroup.Controls.Add(Me.gbObjGroupEdit)
        Me.pnlObjectGroup.Controls.Add(Me.lblObjectEdit)
        Me.pnlObjectGroup.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlObjectGroup.Location = New System.Drawing.Point(0, 137)
        Me.pnlObjectGroup.Name = "pnlObjectGroup"
        Me.pnlObjectGroup.Size = New System.Drawing.Size(203, 141)
        Me.pnlObjectGroup.TabIndex = 5
        '
        'gbObjGroupEdit
        '
        Me.gbObjGroupEdit.Controls.Add(Me.clbObjectKindEdit)
        Me.gbObjGroupEdit.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbObjGroupEdit.Location = New System.Drawing.Point(0, 14)
        Me.gbObjGroupEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjGroupEdit.Name = "gbObjGroupEdit"
        Me.gbObjGroupEdit.Padding = New System.Windows.Forms.Padding(5)
        Me.gbObjGroupEdit.Size = New System.Drawing.Size(203, 124)
        Me.gbObjGroupEdit.TabIndex = 6
        Me.gbObjGroupEdit.TabStop = False
        Me.gbObjGroupEdit.Text = "オブジェクトグループ"
        '
        'clbObjectKindEdit
        '
        Me.clbObjectKindEdit.CheckOnClick = True
        Me.clbObjectKindEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbObjectKindEdit.EventStop = True
        Me.clbObjectKindEdit.FormattingEnabled = True
        Me.clbObjectKindEdit.Location = New System.Drawing.Point(5, 17)
        Me.clbObjectKindEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.clbObjectKindEdit.Name = "clbObjectKindEdit"
        Me.clbObjectKindEdit.Size = New System.Drawing.Size(193, 102)
        Me.clbObjectKindEdit.TabIndex = 0
        '
        'lblObjectEdit
        '
        Me.lblObjectEdit.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblObjectEdit.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblObjectEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblObjectEdit.Location = New System.Drawing.Point(0, 0)
        Me.lblObjectEdit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblObjectEdit.Name = "lblObjectEdit"
        Me.lblObjectEdit.Size = New System.Drawing.Size(203, 14)
        Me.lblObjectEdit.TabIndex = 0
        Me.lblObjectEdit.Text = "オブジェクト"
        Me.lblObjectEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnEditTime
        '
        Me.pnEditTime.Controls.Add(Me.gbEditTime)
        Me.pnEditTime.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnEditTime.Location = New System.Drawing.Point(0, 57)
        Me.pnEditTime.Name = "pnEditTime"
        Me.pnEditTime.Padding = New System.Windows.Forms.Padding(1, 5, 1, 5)
        Me.pnEditTime.Size = New System.Drawing.Size(203, 80)
        Me.pnEditTime.TabIndex = 22
        '
        'gbEditTime
        '
        Me.gbEditTime.Controls.Add(Me.cbLineTime)
        Me.gbEditTime.Controls.Add(Me.dbdtpEditTime)
        Me.gbEditTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbEditTime.Location = New System.Drawing.Point(1, 5)
        Me.gbEditTime.Margin = New System.Windows.Forms.Padding(2)
        Me.gbEditTime.Name = "gbEditTime"
        Me.gbEditTime.Padding = New System.Windows.Forms.Padding(2)
        Me.gbEditTime.Size = New System.Drawing.Size(201, 70)
        Me.gbEditTime.TabIndex = 11
        Me.gbEditTime.TabStop = False
        Me.gbEditTime.Text = "時期限定"
        '
        'cbLineTime
        '
        Me.cbLineTime.AutoSize = True
        Me.cbLineTime.Location = New System.Drawing.Point(40, 49)
        Me.cbLineTime.Margin = New System.Windows.Forms.Padding(2)
        Me.cbLineTime.Name = "cbLineTime"
        Me.cbLineTime.Size = New System.Drawing.Size(100, 16)
        Me.cbLineTime.TabIndex = 4
        Me.cbLineTime.Text = "ラインも合わせる"
        Me.cbLineTime.UseVisualStyleBackColor = True
        '
        'dbdtpEditTime
        '
        Me.dbdtpEditTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dbdtpEditTime.Location = New System.Drawing.Point(16, 26)
        Me.dbdtpEditTime.Margin = New System.Windows.Forms.Padding(2)
        Me.dbdtpEditTime.Name = "dbdtpEditTime"
        Me.dbdtpEditTime.ShowCheckBox = True
        Me.dbdtpEditTime.Size = New System.Drawing.Size(130, 19)
        Me.dbdtpEditTime.TabIndex = 0
        '
        'pnlEdit
        '
        Me.pnlEdit.Controls.Add(Me.btnEditPanelHelp)
        Me.pnlEdit.Controls.Add(Me.cbUnEditableVisible)
        Me.pnlEdit.Controls.Add(Me.Label1)
        Me.pnlEdit.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEdit.Location = New System.Drawing.Point(0, 0)
        Me.pnlEdit.Name = "pnlEdit"
        Me.pnlEdit.Size = New System.Drawing.Size(203, 57)
        Me.pnlEdit.TabIndex = 21
        '
        'btnEditPanelHelp
        '
        Me.btnEditPanelHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditPanelHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnEditPanelHelp.Location = New System.Drawing.Point(186, -1)
        Me.btnEditPanelHelp.Name = "btnEditPanelHelp"
        Me.btnEditPanelHelp.Size = New System.Drawing.Size(19, 20)
        Me.btnEditPanelHelp.TabIndex = 13
        Me.btnEditPanelHelp.Text = "?"
        Me.btnEditPanelHelp.UseVisualStyleBackColor = True
        '
        'cbUnEditableVisible
        '
        Me.cbUnEditableVisible.Location = New System.Drawing.Point(15, 18)
        Me.cbUnEditableVisible.Margin = New System.Windows.Forms.Padding(2)
        Me.cbUnEditableVisible.Name = "cbUnEditableVisible"
        Me.cbUnEditableVisible.Size = New System.Drawing.Size(128, 37)
        Me.cbUnEditableVisible.TabIndex = 12
        Me.cbUnEditableVisible.Text = "編集対象からはずれた場合も表示する"
        Me.cbUnEditableVisible.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(2, 1)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "編集対象"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainerMapAndProperty
        '
        Me.SplitContainerMapAndProperty.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainerMapAndProperty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMapAndProperty.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerMapAndProperty.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainerMapAndProperty.Name = "SplitContainerMapAndProperty"
        '
        'SplitContainerMapAndProperty.Panel1
        '
        Me.SplitContainerMapAndProperty.Panel1.Controls.Add(Me.pnlObjectEdit)
        Me.SplitContainerMapAndProperty.Panel1.Controls.Add(Me.pnlMultiLines)
        Me.SplitContainerMapAndProperty.Panel1.Controls.Add(Me.pnlMultiObjects)
        Me.SplitContainerMapAndProperty.Panel1.Controls.Add(Me.pnlLineEdit)
        Me.SplitContainerMapAndProperty.Panel1.Controls.Add(Me.pnlPropertyWindow)
        Me.SplitContainerMapAndProperty.Panel1.Controls.Add(Me.pnlObjectTimeEdit)
        Me.SplitContainerMapAndProperty.Panel1.Controls.Add(Me.lblPicMap)
        Me.SplitContainerMapAndProperty.Panel1.Controls.Add(Me.picMap)
        '
        'SplitContainerMapAndProperty.Panel2
        '
        Me.SplitContainerMapAndProperty.Panel2.AutoScroll = True
        Me.SplitContainerMapAndProperty.Panel2.Controls.Add(Me.scPropertyAndDefAttribute)
        Me.SplitContainerMapAndProperty.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainerMapAndProperty.Size = New System.Drawing.Size(1142, 897)
        Me.SplitContainerMapAndProperty.SplitterDistance = 842
        Me.SplitContainerMapAndProperty.SplitterWidth = 3
        Me.SplitContainerMapAndProperty.TabIndex = 0
        '
        'pnlObjectEdit
        '
        Me.pnlObjectEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlObjectEdit.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlObjectEdit.Controls.Add(Me.pnlObjectKind)
        Me.pnlObjectEdit.Controls.Add(Me.pnlObjectName12)
        Me.pnlObjectEdit.Controls.Add(Me.pnlObjectEditTop)
        Me.pnlObjectEdit.Location = New System.Drawing.Point(468, 49)
        Me.pnlObjectEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlObjectEdit.Name = "pnlObjectEdit"
        Me.pnlObjectEdit.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlObjectEdit.Size = New System.Drawing.Size(207, 287)
        Me.pnlObjectEdit.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnObjectCancel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnObjectDelete, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnObjectRegist, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAutoBoundary, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCenterGrabityPoint, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 190)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.4!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(201, 88)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'btnObjectCancel
        '
        Me.btnObjectCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnObjectCancel.Location = New System.Drawing.Point(2, 59)
        Me.btnObjectCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjectCancel.Name = "btnObjectCancel"
        Me.btnObjectCancel.Size = New System.Drawing.Size(96, 24)
        Me.btnObjectCancel.TabIndex = 4
        Me.btnObjectCancel.Text = "キャンセル"
        Me.ToolTip1.SetToolTip(Me.btnObjectCancel, "オブジェクトの編集をキャンセルします")
        Me.btnObjectCancel.UseVisualStyleBackColor = True
        '
        'btnObjectDelete
        '
        Me.btnObjectDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnObjectDelete.Location = New System.Drawing.Point(102, 59)
        Me.btnObjectDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjectDelete.Name = "btnObjectDelete"
        Me.btnObjectDelete.Size = New System.Drawing.Size(97, 24)
        Me.btnObjectDelete.TabIndex = 3
        Me.btnObjectDelete.Text = "削除"
        Me.ToolTip1.SetToolTip(Me.btnObjectDelete, "オブジェクトを削除します")
        Me.btnObjectDelete.UseVisualStyleBackColor = True
        '
        'btnObjectRegist
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnObjectRegist, 2)
        Me.btnObjectRegist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnObjectRegist.Location = New System.Drawing.Point(2, 32)
        Me.btnObjectRegist.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjectRegist.Name = "btnObjectRegist"
        Me.btnObjectRegist.Size = New System.Drawing.Size(197, 23)
        Me.btnObjectRegist.TabIndex = 2
        Me.btnObjectRegist.Text = "登録"
        Me.ToolTip1.SetToolTip(Me.btnObjectRegist, "オブジェクトを登録します")
        Me.btnObjectRegist.UseVisualStyleBackColor = True
        '
        'btnAutoBoundary
        '
        Me.btnAutoBoundary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAutoBoundary.Location = New System.Drawing.Point(2, 5)
        Me.btnAutoBoundary.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAutoBoundary.Name = "btnAutoBoundary"
        Me.btnAutoBoundary.Size = New System.Drawing.Size(96, 23)
        Me.btnAutoBoundary.TabIndex = 0
        Me.btnAutoBoundary.Text = "境界線自動設定"
        Me.ToolTip1.SetToolTip(Me.btnAutoBoundary, "代表点を囲むように面オブジェクトの境界線を設定します")
        Me.btnAutoBoundary.UseVisualStyleBackColor = True
        '
        'btnCenterGrabityPoint
        '
        Me.btnCenterGrabityPoint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCenterGrabityPoint.Location = New System.Drawing.Point(102, 5)
        Me.btnCenterGrabityPoint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCenterGrabityPoint.Name = "btnCenterGrabityPoint"
        Me.btnCenterGrabityPoint.Size = New System.Drawing.Size(97, 23)
        Me.btnCenterGrabityPoint.TabIndex = 1
        Me.btnCenterGrabityPoint.Text = "代表点を重心に"
        Me.ToolTip1.SetToolTip(Me.btnCenterGrabityPoint, "代表点を面オブジェクトの重心に設定します")
        Me.btnCenterGrabityPoint.UseVisualStyleBackColor = True
        '
        'pnlObjectKind
        '
        Me.pnlObjectKind.Controls.Add(Me.gbObjectKind)
        Me.pnlObjectKind.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlObjectKind.Location = New System.Drawing.Point(2, 136)
        Me.pnlObjectKind.Name = "pnlObjectKind"
        Me.pnlObjectKind.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlObjectKind.Size = New System.Drawing.Size(201, 54)
        Me.pnlObjectKind.TabIndex = 1
        '
        'gbObjectKind
        '
        Me.gbObjectKind.Controls.Add(Me.cboObjectKind)
        Me.gbObjectKind.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbObjectKind.Location = New System.Drawing.Point(3, 3)
        Me.gbObjectKind.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjectKind.Name = "gbObjectKind"
        Me.gbObjectKind.Padding = New System.Windows.Forms.Padding(11, 8, 11, 3)
        Me.gbObjectKind.Size = New System.Drawing.Size(195, 48)
        Me.gbObjectKind.TabIndex = 0
        Me.gbObjectKind.TabStop = False
        Me.gbObjectKind.Text = "オブジェクトグループ"
        '
        'cboObjectKind
        '
        Me.cboObjectKind.AsteriskSelectEnabled = False
        Me.cboObjectKind.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboObjectKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObjectKind.FormattingEnabled = True
        Me.cboObjectKind.IntegralHeight = False
        Me.cboObjectKind.Location = New System.Drawing.Point(11, 20)
        Me.cboObjectKind.Margin = New System.Windows.Forms.Padding(2)
        Me.cboObjectKind.Name = "cboObjectKind"
        Me.cboObjectKind.Size = New System.Drawing.Size(173, 20)
        Me.cboObjectKind.TabIndex = 1
        '
        'pnlObjectName12
        '
        Me.pnlObjectName12.Controls.Add(Me.ktObjectName)
        Me.pnlObjectName12.Controls.Add(Me.Label3)
        Me.pnlObjectName12.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlObjectName12.Location = New System.Drawing.Point(2, 21)
        Me.pnlObjectName12.Name = "pnlObjectName12"
        Me.pnlObjectName12.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlObjectName12.Size = New System.Drawing.Size(201, 115)
        Me.pnlObjectName12.TabIndex = 0
        '
        'ktObjectName
        '
        Me.ktObjectName.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktObjectName.DefaultFixedXNumberingWidth = 50
        Me.ktObjectName.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktObjectName.DefaultFixedXWidth = 150
        Me.ktObjectName.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktObjectName.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ktObjectName.DefaultGridWidth = 100
        Me.ktObjectName.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ktObjectName.Dock = System.Windows.Forms.DockStyle.Top
        Me.ktObjectName.FixedGridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ktObjectName.FrameColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.ktObjectName.GridColor = System.Drawing.Color.White
        Me.ktObjectName.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktObjectName.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ktObjectName.Layer = 0
        Me.ktObjectName.LayerCaption = Nothing
        Me.ktObjectName.Location = New System.Drawing.Point(3, 15)
        Me.ktObjectName.MsgBoxTitle = ""
        Me.ktObjectName.Name = "ktObjectName"
        Me.ktObjectName.RowCaption = Nothing
        Me.ktObjectName.Size = New System.Drawing.Size(195, 98)
        Me.ktObjectName.TabClickEnabled = False
        Me.ktObjectName.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "オブジェクト名"
        '
        'pnlObjectEditTop
        '
        Me.pnlObjectEditTop.Controls.Add(Me.btnObjectEditHelp)
        Me.pnlObjectEditTop.Controls.Add(Me.Label4)
        Me.pnlObjectEditTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlObjectEditTop.Location = New System.Drawing.Point(2, 2)
        Me.pnlObjectEditTop.Name = "pnlObjectEditTop"
        Me.pnlObjectEditTop.Size = New System.Drawing.Size(201, 19)
        Me.pnlObjectEditTop.TabIndex = 25
        '
        'btnObjectEditHelp
        '
        Me.btnObjectEditHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnObjectEditHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnObjectEditHelp.Location = New System.Drawing.Point(180, -1)
        Me.btnObjectEditHelp.Name = "btnObjectEditHelp"
        Me.btnObjectEditHelp.Size = New System.Drawing.Size(20, 20)
        Me.btnObjectEditHelp.TabIndex = 13
        Me.btnObjectEditHelp.Text = "?"
        Me.btnObjectEditHelp.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(181, 19)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "オブジェクト編集"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMultiLines
        '
        Me.pnlMultiLines.Controls.Add(Me.Panel2)
        Me.pnlMultiLines.Controls.Add(Me.Panel3)
        Me.pnlMultiLines.Controls.Add(Me.pnlMultiLineTop)
        Me.pnlMultiLines.Location = New System.Drawing.Point(235, 334)
        Me.pnlMultiLines.Name = "pnlMultiLines"
        Me.pnlMultiLines.Size = New System.Drawing.Size(218, 302)
        Me.pnlMultiLines.TabIndex = 19
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel5)
        Me.Panel2.Controls.Add(Me.lbMultiLineCommand)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 114)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel2.Size = New System.Drawing.Size(218, 188)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.btnMultiLineEnd, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.btnMultiLineExe, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 154)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(212, 28)
        Me.TableLayoutPanel5.TabIndex = 3
        '
        'btnMultiLineEnd
        '
        Me.btnMultiLineEnd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnMultiLineEnd.Location = New System.Drawing.Point(108, 2)
        Me.btnMultiLineEnd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMultiLineEnd.Name = "btnMultiLineEnd"
        Me.btnMultiLineEnd.Size = New System.Drawing.Size(102, 24)
        Me.btnMultiLineEnd.TabIndex = 1
        Me.btnMultiLineEnd.Text = "終了"
        Me.btnMultiLineEnd.UseVisualStyleBackColor = True
        '
        'btnMultiLineExe
        '
        Me.btnMultiLineExe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnMultiLineExe.Location = New System.Drawing.Point(2, 2)
        Me.btnMultiLineExe.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMultiLineExe.Name = "btnMultiLineExe"
        Me.btnMultiLineExe.Size = New System.Drawing.Size(102, 24)
        Me.btnMultiLineExe.TabIndex = 0
        Me.btnMultiLineExe.Text = "実行"
        Me.ToolTip1.SetToolTip(Me.btnMultiLineExe, "選択したメニューを実行")
        Me.btnMultiLineExe.UseVisualStyleBackColor = True
        '
        'lbMultiLineCommand
        '
        Me.lbMultiLineCommand.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbMultiLineCommand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lbMultiLineCommand.FormattingEnabled = True
        Me.lbMultiLineCommand.ItemHeight = 15
        Me.lbMultiLineCommand.Location = New System.Drawing.Point(3, 15)
        Me.lbMultiLineCommand.Name = "lbMultiLineCommand"
        Me.lbMultiLineCommand.Size = New System.Drawing.Size(212, 139)
        Me.lbMultiLineCommand.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "処理を選択して「実行」をクリック"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 19)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel3.Size = New System.Drawing.Size(218, 95)
        Me.Panel3.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnMultiLineClear)
        Me.GroupBox1.Controls.Add(Me.btnOtherLineSelectMethos)
        Me.GroupBox1.Controls.Add(Me.rbMultiLineSelectMode_Polygon)
        Me.GroupBox1.Controls.Add(Me.rbMultiLineSelectMode_Circle)
        Me.GroupBox1.Controls.Add(Me.rbMultiLineSelectMode_Rectangle)
        Me.GroupBox1.Controls.Add(Me.rbMultiLineSelectMode_Pointing)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(212, 89)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ライン選択方法"
        '
        'btnMultiLineClear
        '
        Me.btnMultiLineClear.Location = New System.Drawing.Point(113, 65)
        Me.btnMultiLineClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMultiLineClear.Name = "btnMultiLineClear"
        Me.btnMultiLineClear.Size = New System.Drawing.Size(82, 20)
        Me.btnMultiLineClear.TabIndex = 7
        Me.btnMultiLineClear.Text = "選択解除"
        Me.btnMultiLineClear.UseVisualStyleBackColor = True
        '
        'btnOtherLineSelectMethos
        '
        Me.btnOtherLineSelectMethos.Location = New System.Drawing.Point(15, 65)
        Me.btnOtherLineSelectMethos.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOtherLineSelectMethos.Name = "btnOtherLineSelectMethos"
        Me.btnOtherLineSelectMethos.Size = New System.Drawing.Size(91, 20)
        Me.btnOtherLineSelectMethos.TabIndex = 6
        Me.btnOtherLineSelectMethos.Text = "他の選択方法"
        Me.btnOtherLineSelectMethos.UseVisualStyleBackColor = True
        '
        'rbMultiLineSelectMode_Polygon
        '
        Me.rbMultiLineSelectMode_Polygon.AutoSize = True
        Me.rbMultiLineSelectMode_Polygon.Location = New System.Drawing.Point(110, 43)
        Me.rbMultiLineSelectMode_Polygon.Name = "rbMultiLineSelectMode_Polygon"
        Me.rbMultiLineSelectMode_Polygon.Size = New System.Drawing.Size(83, 16)
        Me.rbMultiLineSelectMode_Polygon.TabIndex = 3
        Me.rbMultiLineSelectMode_Polygon.TabStop = True
        Me.rbMultiLineSelectMode_Polygon.Text = "多角形選択"
        Me.rbMultiLineSelectMode_Polygon.UseVisualStyleBackColor = True
        '
        'rbMultiLineSelectMode_Circle
        '
        Me.rbMultiLineSelectMode_Circle.AutoSize = True
        Me.rbMultiLineSelectMode_Circle.Location = New System.Drawing.Point(15, 43)
        Me.rbMultiLineSelectMode_Circle.Name = "rbMultiLineSelectMode_Circle"
        Me.rbMultiLineSelectMode_Circle.Size = New System.Drawing.Size(71, 16)
        Me.rbMultiLineSelectMode_Circle.TabIndex = 2
        Me.rbMultiLineSelectMode_Circle.TabStop = True
        Me.rbMultiLineSelectMode_Circle.Text = "円形選択"
        Me.rbMultiLineSelectMode_Circle.UseVisualStyleBackColor = True
        '
        'rbMultiLineSelectMode_Rectangle
        '
        Me.rbMultiLineSelectMode_Rectangle.AutoSize = True
        Me.rbMultiLineSelectMode_Rectangle.Location = New System.Drawing.Point(110, 18)
        Me.rbMultiLineSelectMode_Rectangle.Name = "rbMultiLineSelectMode_Rectangle"
        Me.rbMultiLineSelectMode_Rectangle.Size = New System.Drawing.Size(83, 16)
        Me.rbMultiLineSelectMode_Rectangle.TabIndex = 1
        Me.rbMultiLineSelectMode_Rectangle.TabStop = True
        Me.rbMultiLineSelectMode_Rectangle.Text = "四角形選択"
        Me.rbMultiLineSelectMode_Rectangle.UseVisualStyleBackColor = True
        '
        'rbMultiLineSelectMode_Pointing
        '
        Me.rbMultiLineSelectMode_Pointing.AutoSize = True
        Me.rbMultiLineSelectMode_Pointing.Location = New System.Drawing.Point(15, 18)
        Me.rbMultiLineSelectMode_Pointing.Name = "rbMultiLineSelectMode_Pointing"
        Me.rbMultiLineSelectMode_Pointing.Size = New System.Drawing.Size(77, 16)
        Me.rbMultiLineSelectMode_Pointing.TabIndex = 0
        Me.rbMultiLineSelectMode_Pointing.TabStop = True
        Me.rbMultiLineSelectMode_Pointing.Text = "クリック選択"
        Me.rbMultiLineSelectMode_Pointing.UseVisualStyleBackColor = True
        '
        'pnlMultiLineTop
        '
        Me.pnlMultiLineTop.Controls.Add(Me.btnMultiLinesEditHelp)
        Me.pnlMultiLineTop.Controls.Add(Me.Label6)
        Me.pnlMultiLineTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMultiLineTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlMultiLineTop.Name = "pnlMultiLineTop"
        Me.pnlMultiLineTop.Size = New System.Drawing.Size(218, 19)
        Me.pnlMultiLineTop.TabIndex = 23
        '
        'btnMultiLinesEditHelp
        '
        Me.btnMultiLinesEditHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMultiLinesEditHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnMultiLinesEditHelp.Location = New System.Drawing.Point(197, -1)
        Me.btnMultiLinesEditHelp.Name = "btnMultiLinesEditHelp"
        Me.btnMultiLinesEditHelp.Size = New System.Drawing.Size(20, 20)
        Me.btnMultiLinesEditHelp.TabIndex = 13
        Me.btnMultiLinesEditHelp.Text = "?"
        Me.btnMultiLinesEditHelp.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(198, 19)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "複数ライン編集"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMultiObjects
        '
        Me.pnlMultiObjects.Controls.Add(Me.pnlMultiObjectCommand)
        Me.pnlMultiObjects.Controls.Add(Me.pnlSelectMode)
        Me.pnlMultiObjects.Controls.Add(Me.pnlMultiObjectTop)
        Me.pnlMultiObjects.Location = New System.Drawing.Point(3, 4)
        Me.pnlMultiObjects.Name = "pnlMultiObjects"
        Me.pnlMultiObjects.Size = New System.Drawing.Size(206, 350)
        Me.pnlMultiObjects.TabIndex = 18
        '
        'pnlMultiObjectCommand
        '
        Me.pnlMultiObjectCommand.Controls.Add(Me.TableLayoutPanel4)
        Me.pnlMultiObjectCommand.Controls.Add(Me.lbMultiObjectsCommand)
        Me.pnlMultiObjectCommand.Controls.Add(Me.lblOperation)
        Me.pnlMultiObjectCommand.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMultiObjectCommand.Location = New System.Drawing.Point(0, 107)
        Me.pnlMultiObjectCommand.Name = "pnlMultiObjectCommand"
        Me.pnlMultiObjectCommand.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlMultiObjectCommand.Size = New System.Drawing.Size(206, 240)
        Me.pnlMultiObjectCommand.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnMultiPbjectsEnd, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnMultiObjectsExe, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 214)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(200, 24)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'btnMultiPbjectsEnd
        '
        Me.btnMultiPbjectsEnd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnMultiPbjectsEnd.Location = New System.Drawing.Point(102, 2)
        Me.btnMultiPbjectsEnd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMultiPbjectsEnd.Name = "btnMultiPbjectsEnd"
        Me.btnMultiPbjectsEnd.Size = New System.Drawing.Size(96, 20)
        Me.btnMultiPbjectsEnd.TabIndex = 1
        Me.btnMultiPbjectsEnd.Text = "終了"
        Me.btnMultiPbjectsEnd.UseVisualStyleBackColor = True
        '
        'btnMultiObjectsExe
        '
        Me.btnMultiObjectsExe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnMultiObjectsExe.Location = New System.Drawing.Point(2, 2)
        Me.btnMultiObjectsExe.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMultiObjectsExe.Name = "btnMultiObjectsExe"
        Me.btnMultiObjectsExe.Size = New System.Drawing.Size(96, 20)
        Me.btnMultiObjectsExe.TabIndex = 0
        Me.btnMultiObjectsExe.Text = "実行"
        Me.ToolTip1.SetToolTip(Me.btnMultiObjectsExe, "選択したメニューを実行")
        Me.btnMultiObjectsExe.UseVisualStyleBackColor = True
        '
        'lbMultiObjectsCommand
        '
        Me.lbMultiObjectsCommand.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbMultiObjectsCommand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lbMultiObjectsCommand.FormattingEnabled = True
        Me.lbMultiObjectsCommand.ItemHeight = 15
        Me.lbMultiObjectsCommand.Location = New System.Drawing.Point(3, 15)
        Me.lbMultiObjectsCommand.Name = "lbMultiObjectsCommand"
        Me.lbMultiObjectsCommand.Size = New System.Drawing.Size(200, 199)
        Me.lbMultiObjectsCommand.TabIndex = 1
        '
        'lblOperation
        '
        Me.lblOperation.AutoSize = True
        Me.lblOperation.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblOperation.Location = New System.Drawing.Point(3, 3)
        Me.lblOperation.Name = "lblOperation"
        Me.lblOperation.Size = New System.Drawing.Size(155, 12)
        Me.lblOperation.TabIndex = 0
        Me.lblOperation.Text = "処理を選択して「実行」をクリック"
        '
        'pnlSelectMode
        '
        Me.pnlSelectMode.Controls.Add(Me.gbSelectMode)
        Me.pnlSelectMode.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSelectMode.Location = New System.Drawing.Point(0, 19)
        Me.pnlSelectMode.Name = "pnlSelectMode"
        Me.pnlSelectMode.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlSelectMode.Size = New System.Drawing.Size(206, 88)
        Me.pnlSelectMode.TabIndex = 0
        '
        'gbSelectMode
        '
        Me.gbSelectMode.Controls.Add(Me.btnMultiObjectClear)
        Me.gbSelectMode.Controls.Add(Me.btnOtherSelectMethos)
        Me.gbSelectMode.Controls.Add(Me.rbMultiObjectSelectMode_Polygon)
        Me.gbSelectMode.Controls.Add(Me.rbMultiObjectSelectMode_Circle)
        Me.gbSelectMode.Controls.Add(Me.rbMultiObjectSelectMode_Rectangle)
        Me.gbSelectMode.Controls.Add(Me.rbMultiObjectSelectMode_Pointing)
        Me.gbSelectMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbSelectMode.Location = New System.Drawing.Point(3, 3)
        Me.gbSelectMode.Name = "gbSelectMode"
        Me.gbSelectMode.Size = New System.Drawing.Size(200, 82)
        Me.gbSelectMode.TabIndex = 0
        Me.gbSelectMode.TabStop = False
        Me.gbSelectMode.Text = "オブジェクト選択方法"
        '
        'btnMultiObjectClear
        '
        Me.btnMultiObjectClear.Location = New System.Drawing.Point(110, 57)
        Me.btnMultiObjectClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMultiObjectClear.Name = "btnMultiObjectClear"
        Me.btnMultiObjectClear.Size = New System.Drawing.Size(82, 20)
        Me.btnMultiObjectClear.TabIndex = 5
        Me.btnMultiObjectClear.Text = "選択解除"
        Me.btnMultiObjectClear.UseVisualStyleBackColor = True
        '
        'btnOtherSelectMethos
        '
        Me.btnOtherSelectMethos.Location = New System.Drawing.Point(15, 57)
        Me.btnOtherSelectMethos.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOtherSelectMethos.Name = "btnOtherSelectMethos"
        Me.btnOtherSelectMethos.Size = New System.Drawing.Size(91, 20)
        Me.btnOtherSelectMethos.TabIndex = 4
        Me.btnOtherSelectMethos.Text = "他の選択方法"
        Me.btnOtherSelectMethos.UseVisualStyleBackColor = True
        '
        'rbMultiObjectSelectMode_Polygon
        '
        Me.rbMultiObjectSelectMode_Polygon.AutoSize = True
        Me.rbMultiObjectSelectMode_Polygon.Location = New System.Drawing.Point(110, 40)
        Me.rbMultiObjectSelectMode_Polygon.Name = "rbMultiObjectSelectMode_Polygon"
        Me.rbMultiObjectSelectMode_Polygon.Size = New System.Drawing.Size(83, 16)
        Me.rbMultiObjectSelectMode_Polygon.TabIndex = 3
        Me.rbMultiObjectSelectMode_Polygon.TabStop = True
        Me.rbMultiObjectSelectMode_Polygon.Text = "多角形選択"
        Me.rbMultiObjectSelectMode_Polygon.UseVisualStyleBackColor = True
        '
        'rbMultiObjectSelectMode_Circle
        '
        Me.rbMultiObjectSelectMode_Circle.AutoSize = True
        Me.rbMultiObjectSelectMode_Circle.Location = New System.Drawing.Point(15, 39)
        Me.rbMultiObjectSelectMode_Circle.Name = "rbMultiObjectSelectMode_Circle"
        Me.rbMultiObjectSelectMode_Circle.Size = New System.Drawing.Size(71, 16)
        Me.rbMultiObjectSelectMode_Circle.TabIndex = 2
        Me.rbMultiObjectSelectMode_Circle.TabStop = True
        Me.rbMultiObjectSelectMode_Circle.Text = "円形選択"
        Me.rbMultiObjectSelectMode_Circle.UseVisualStyleBackColor = True
        '
        'rbMultiObjectSelectMode_Rectangle
        '
        Me.rbMultiObjectSelectMode_Rectangle.AutoSize = True
        Me.rbMultiObjectSelectMode_Rectangle.Location = New System.Drawing.Point(110, 18)
        Me.rbMultiObjectSelectMode_Rectangle.Name = "rbMultiObjectSelectMode_Rectangle"
        Me.rbMultiObjectSelectMode_Rectangle.Size = New System.Drawing.Size(83, 16)
        Me.rbMultiObjectSelectMode_Rectangle.TabIndex = 1
        Me.rbMultiObjectSelectMode_Rectangle.TabStop = True
        Me.rbMultiObjectSelectMode_Rectangle.Text = "四角形選択"
        Me.rbMultiObjectSelectMode_Rectangle.UseVisualStyleBackColor = True
        '
        'rbMultiObjectSelectMode_Pointing
        '
        Me.rbMultiObjectSelectMode_Pointing.AutoSize = True
        Me.rbMultiObjectSelectMode_Pointing.Location = New System.Drawing.Point(15, 18)
        Me.rbMultiObjectSelectMode_Pointing.Name = "rbMultiObjectSelectMode_Pointing"
        Me.rbMultiObjectSelectMode_Pointing.Size = New System.Drawing.Size(77, 16)
        Me.rbMultiObjectSelectMode_Pointing.TabIndex = 0
        Me.rbMultiObjectSelectMode_Pointing.TabStop = True
        Me.rbMultiObjectSelectMode_Pointing.Text = "クリック選択"
        Me.rbMultiObjectSelectMode_Pointing.UseVisualStyleBackColor = True
        '
        'pnlMultiObjectTop
        '
        Me.pnlMultiObjectTop.Controls.Add(Me.btnMultiObjectsEditHelp)
        Me.pnlMultiObjectTop.Controls.Add(Me.Label8)
        Me.pnlMultiObjectTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMultiObjectTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlMultiObjectTop.Name = "pnlMultiObjectTop"
        Me.pnlMultiObjectTop.Size = New System.Drawing.Size(206, 19)
        Me.pnlMultiObjectTop.TabIndex = 22
        '
        'btnMultiObjectsEditHelp
        '
        Me.btnMultiObjectsEditHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMultiObjectsEditHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnMultiObjectsEditHelp.Location = New System.Drawing.Point(187, -1)
        Me.btnMultiObjectsEditHelp.Name = "btnMultiObjectsEditHelp"
        Me.btnMultiObjectsEditHelp.Size = New System.Drawing.Size(19, 20)
        Me.btnMultiObjectsEditHelp.TabIndex = 13
        Me.btnMultiObjectsEditHelp.Text = "?"
        Me.btnMultiObjectsEditHelp.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(2, 1)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(187, 16)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "複数オブジェクト編集"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlLineEdit
        '
        Me.pnlLineEdit.AutoSize = True
        Me.pnlLineEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLineEdit.Controls.Add(Me.TableLayoutPanel3)
        Me.pnlLineEdit.Controls.Add(Me.pnlLineTimekindSet)
        Me.pnlLineEdit.Controls.Add(Me.pnlLineKind)
        Me.pnlLineEdit.Controls.Add(Me.pnlLineTop)
        Me.pnlLineEdit.Location = New System.Drawing.Point(262, 38)
        Me.pnlLineEdit.Name = "pnlLineEdit"
        Me.pnlLineEdit.Size = New System.Drawing.Size(206, 251)
        Me.pnlLineEdit.TabIndex = 17
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnLineDivide_and_Node, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnNode, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnLineCancel, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btnLineRegist, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btnLineDelete, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnShowCoord, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 165)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(204, 84)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'btnLineDivide_and_Node
        '
        Me.btnLineDivide_and_Node.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLineDivide_and_Node.Location = New System.Drawing.Point(2, 5)
        Me.btnLineDivide_and_Node.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLineDivide_and_Node.Name = "btnLineDivide_and_Node"
        Me.btnLineDivide_and_Node.Size = New System.Drawing.Size(98, 21)
        Me.btnLineDivide_and_Node.TabIndex = 0
        Me.btnLineDivide_and_Node.Text = "分割＆結節点"
        Me.ToolTip1.SetToolTip(Me.btnLineDivide_and_Node, "最寄りのラインに結合させて結節点化します。")
        Me.btnLineDivide_and_Node.UseVisualStyleBackColor = True
        '
        'btnNode
        '
        Me.btnNode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNode.Location = New System.Drawing.Point(104, 5)
        Me.btnNode.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNode.Name = "btnNode"
        Me.btnNode.Size = New System.Drawing.Size(98, 21)
        Me.btnNode.TabIndex = 1
        Me.btnNode.Text = "結節点化"
        Me.ToolTip1.SetToolTip(Me.btnNode, "非結節点を結節点化します")
        Me.btnNode.UseVisualStyleBackColor = True
        '
        'btnLineCancel
        '
        Me.btnLineCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLineCancel.Location = New System.Drawing.Point(104, 55)
        Me.btnLineCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLineCancel.Name = "btnLineCancel"
        Me.btnLineCancel.Size = New System.Drawing.Size(98, 24)
        Me.btnLineCancel.TabIndex = 5
        Me.btnLineCancel.Text = "キャンセル"
        Me.ToolTip1.SetToolTip(Me.btnLineCancel, "ラインの編集をキャンセルします")
        Me.btnLineCancel.UseVisualStyleBackColor = True
        '
        'btnLineRegist
        '
        Me.btnLineRegist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLineRegist.Location = New System.Drawing.Point(2, 55)
        Me.btnLineRegist.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLineRegist.Name = "btnLineRegist"
        Me.btnLineRegist.Size = New System.Drawing.Size(98, 24)
        Me.btnLineRegist.TabIndex = 4
        Me.btnLineRegist.Text = "登録"
        Me.ToolTip1.SetToolTip(Me.btnLineRegist, "ラインを登録します")
        Me.btnLineRegist.UseVisualStyleBackColor = True
        '
        'btnLineDelete
        '
        Me.btnLineDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLineDelete.Location = New System.Drawing.Point(104, 30)
        Me.btnLineDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLineDelete.Name = "btnLineDelete"
        Me.btnLineDelete.Size = New System.Drawing.Size(98, 21)
        Me.btnLineDelete.TabIndex = 3
        Me.btnLineDelete.Text = "削除"
        Me.ToolTip1.SetToolTip(Me.btnLineDelete, "ラインを削除します")
        Me.btnLineDelete.UseVisualStyleBackColor = True
        '
        'btnShowCoord
        '
        Me.btnShowCoord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShowCoord.Location = New System.Drawing.Point(2, 30)
        Me.btnShowCoord.Margin = New System.Windows.Forms.Padding(2)
        Me.btnShowCoord.Name = "btnShowCoord"
        Me.btnShowCoord.Size = New System.Drawing.Size(98, 21)
        Me.btnShowCoord.TabIndex = 2
        Me.btnShowCoord.Text = "座標表示"
        Me.btnShowCoord.UseVisualStyleBackColor = True
        '
        'pnlLineTimekindSet
        '
        Me.pnlLineTimekindSet.Controls.Add(Me.tbLineKindTime)
        Me.pnlLineTimekindSet.Controls.Add(Me.btnLineTimeKindSet)
        Me.pnlLineTimekindSet.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLineTimekindSet.Location = New System.Drawing.Point(0, 76)
        Me.pnlLineTimekindSet.Name = "pnlLineTimekindSet"
        Me.pnlLineTimekindSet.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlLineTimekindSet.Size = New System.Drawing.Size(204, 89)
        Me.pnlLineTimekindSet.TabIndex = 1
        Me.pnlLineTimekindSet.Visible = False
        '
        'tbLineKindTime
        '
        Me.tbLineKindTime.BackColor = System.Drawing.SystemColors.Window
        Me.tbLineKindTime.Dock = System.Windows.Forms.DockStyle.Top
        Me.tbLineKindTime.Location = New System.Drawing.Point(3, 3)
        Me.tbLineKindTime.Multiline = True
        Me.tbLineKindTime.Name = "tbLineKindTime"
        Me.tbLineKindTime.ReadOnly = True
        Me.tbLineKindTime.Size = New System.Drawing.Size(198, 55)
        Me.tbLineKindTime.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.tbLineKindTime, "オフジェクト名の期間を設定します")
        '
        'btnLineTimeKindSet
        '
        Me.btnLineTimeKindSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLineTimeKindSet.Location = New System.Drawing.Point(76, 63)
        Me.btnLineTimeKindSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLineTimeKindSet.Name = "btnLineTimeKindSet"
        Me.btnLineTimeKindSet.Size = New System.Drawing.Size(123, 21)
        Me.btnLineTimeKindSet.TabIndex = 1
        Me.btnLineTimeKindSet.Text = "線種・有効期間設定"
        Me.ToolTip1.SetToolTip(Me.btnLineTimeKindSet, "ラインの線種と有効期間を設定")
        Me.btnLineTimeKindSet.UseVisualStyleBackColor = True
        '
        'pnlLineKind
        '
        Me.pnlLineKind.Controls.Add(Me.gbLineKind)
        Me.pnlLineKind.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLineKind.Location = New System.Drawing.Point(0, 19)
        Me.pnlLineKind.Name = "pnlLineKind"
        Me.pnlLineKind.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlLineKind.Size = New System.Drawing.Size(204, 57)
        Me.pnlLineKind.TabIndex = 0
        Me.pnlLineKind.Visible = False
        '
        'gbLineKind
        '
        Me.gbLineKind.Controls.Add(Me.cboLineKind)
        Me.gbLineKind.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbLineKind.Location = New System.Drawing.Point(3, 3)
        Me.gbLineKind.Margin = New System.Windows.Forms.Padding(2)
        Me.gbLineKind.Name = "gbLineKind"
        Me.gbLineKind.Padding = New System.Windows.Forms.Padding(11, 8, 11, 3)
        Me.gbLineKind.Size = New System.Drawing.Size(198, 51)
        Me.gbLineKind.TabIndex = 0
        Me.gbLineKind.TabStop = False
        Me.gbLineKind.Text = "線種"
        '
        'cboLineKind
        '
        Me.cboLineKind.AsteriskSelectEnabled = False
        Me.cboLineKind.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboLineKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLineKind.FormattingEnabled = True
        Me.cboLineKind.IntegralHeight = False
        Me.cboLineKind.Location = New System.Drawing.Point(11, 20)
        Me.cboLineKind.Margin = New System.Windows.Forms.Padding(2)
        Me.cboLineKind.Name = "cboLineKind"
        Me.cboLineKind.Size = New System.Drawing.Size(176, 20)
        Me.cboLineKind.TabIndex = 1
        '
        'pnlLineTop
        '
        Me.pnlLineTop.Controls.Add(Me.btnLineEditHelp)
        Me.pnlLineTop.Controls.Add(Me.Label7)
        Me.pnlLineTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLineTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlLineTop.Name = "pnlLineTop"
        Me.pnlLineTop.Size = New System.Drawing.Size(204, 19)
        Me.pnlLineTop.TabIndex = 24
        '
        'btnLineEditHelp
        '
        Me.btnLineEditHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLineEditHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnLineEditHelp.Location = New System.Drawing.Point(183, -1)
        Me.btnLineEditHelp.Name = "btnLineEditHelp"
        Me.btnLineEditHelp.Size = New System.Drawing.Size(20, 20)
        Me.btnLineEditHelp.TabIndex = 13
        Me.btnLineEditHelp.Text = "?"
        Me.btnLineEditHelp.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(184, 19)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "ライン編集"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPropertyWindow
        '
        Me.pnlPropertyWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPropertyWindow.Controls.Add(Me.lvtPropertyWindow)
        Me.pnlPropertyWindow.Controls.Add(Me.lblProperty)
        Me.pnlPropertyWindow.Location = New System.Drawing.Point(9, 429)
        Me.pnlPropertyWindow.Name = "pnlPropertyWindow"
        Me.pnlPropertyWindow.Size = New System.Drawing.Size(206, 131)
        Me.pnlPropertyWindow.TabIndex = 13
        '
        'lvtPropertyWindow
        '
        Me.lvtPropertyWindow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvtPropertyWindow.GridLines = True
        Me.lvtPropertyWindow.Location = New System.Drawing.Point(0, 14)
        Me.lvtPropertyWindow.Margin = New System.Windows.Forms.Padding(2)
        Me.lvtPropertyWindow.Name = "lvtPropertyWindow"
        Me.lvtPropertyWindow.Size = New System.Drawing.Size(204, 115)
        Me.lvtPropertyWindow.TabIndex = 12
        Me.lvtPropertyWindow.UseCompatibleStateImageBehavior = False
        Me.lvtPropertyWindow.View = System.Windows.Forms.View.Details
        '
        'lblProperty
        '
        Me.lblProperty.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblProperty.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblProperty.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblProperty.Location = New System.Drawing.Point(0, 0)
        Me.lblProperty.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProperty.Name = "lblProperty"
        Me.lblProperty.Size = New System.Drawing.Size(204, 14)
        Me.lblProperty.TabIndex = 13
        Me.lblProperty.Text = "プロパティ"
        Me.lblProperty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlObjectTimeEdit
        '
        Me.pnlObjectTimeEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlObjectTimeEdit.Controls.Add(Me.TableLayoutPanel2)
        Me.pnlObjectTimeEdit.Controls.Add(Me.pnlObjectGroupTime)
        Me.pnlObjectTimeEdit.Controls.Add(Me.pnlObjectNameTime)
        Me.pnlObjectTimeEdit.Controls.Add(Me.pnlTimeObjectTop)
        Me.pnlObjectTimeEdit.Location = New System.Drawing.Point(478, 379)
        Me.pnlObjectTimeEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlObjectTimeEdit.Name = "pnlObjectTimeEdit"
        Me.pnlObjectTimeEdit.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlObjectTimeEdit.Size = New System.Drawing.Size(206, 295)
        Me.pnlObjectTimeEdit.TabIndex = 16
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnCenterPointTime, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnSuccession, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnObjrectRegistTime, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnTimeObject, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnObjectDeleteTime, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnObjectCancelTime, 1, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 209)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.62069!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.26401!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.1153!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(200, 83)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'btnCenterPointTime
        '
        Me.btnCenterPointTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCenterPointTime.Location = New System.Drawing.Point(2, 5)
        Me.btnCenterPointTime.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCenterPointTime.Name = "btnCenterPointTime"
        Me.btnCenterPointTime.Size = New System.Drawing.Size(96, 21)
        Me.btnCenterPointTime.TabIndex = 0
        Me.btnCenterPointTime.Text = "代表点期間設定"
        Me.ToolTip1.SetToolTip(Me.btnCenterPointTime, "代表点の追加と時間設定を行います")
        Me.btnCenterPointTime.UseVisualStyleBackColor = True
        '
        'btnSuccession
        '
        Me.btnSuccession.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSuccession.Location = New System.Drawing.Point(102, 5)
        Me.btnSuccession.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSuccession.Name = "btnSuccession"
        Me.btnSuccession.Size = New System.Drawing.Size(96, 21)
        Me.btnSuccession.TabIndex = 1
        Me.btnSuccession.Text = "継承設定"
        Me.ToolTip1.SetToolTip(Me.btnSuccession, "オブジェクトの継承先を設定します")
        Me.btnSuccession.UseVisualStyleBackColor = True
        '
        'btnObjrectRegistTime
        '
        Me.btnObjrectRegistTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnObjrectRegistTime.Location = New System.Drawing.Point(2, 57)
        Me.btnObjrectRegistTime.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjrectRegistTime.Name = "btnObjrectRegistTime"
        Me.btnObjrectRegistTime.Size = New System.Drawing.Size(96, 21)
        Me.btnObjrectRegistTime.TabIndex = 4
        Me.btnObjrectRegistTime.Text = "登録"
        Me.ToolTip1.SetToolTip(Me.btnObjrectRegistTime, "オブジェクトを登録します")
        Me.btnObjrectRegistTime.UseVisualStyleBackColor = True
        '
        'btnTimeObject
        '
        Me.btnTimeObject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTimeObject.Location = New System.Drawing.Point(2, 30)
        Me.btnTimeObject.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTimeObject.Name = "btnTimeObject"
        Me.btnTimeObject.Size = New System.Drawing.Size(96, 23)
        Me.btnTimeObject.TabIndex = 2
        Me.btnTimeObject.Text = "時間変化"
        Me.ToolTip1.SetToolTip(Me.btnTimeObject, "オブジェクトの時間変化を見ます")
        Me.btnTimeObject.UseVisualStyleBackColor = True
        '
        'btnObjectDeleteTime
        '
        Me.btnObjectDeleteTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnObjectDeleteTime.Location = New System.Drawing.Point(102, 30)
        Me.btnObjectDeleteTime.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjectDeleteTime.Name = "btnObjectDeleteTime"
        Me.btnObjectDeleteTime.Size = New System.Drawing.Size(96, 23)
        Me.btnObjectDeleteTime.TabIndex = 3
        Me.btnObjectDeleteTime.Text = "削除"
        Me.ToolTip1.SetToolTip(Me.btnObjectDeleteTime, "オブジェクトを削除します")
        Me.btnObjectDeleteTime.UseVisualStyleBackColor = True
        '
        'btnObjectCancelTime
        '
        Me.btnObjectCancelTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnObjectCancelTime.Location = New System.Drawing.Point(102, 57)
        Me.btnObjectCancelTime.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjectCancelTime.Name = "btnObjectCancelTime"
        Me.btnObjectCancelTime.Size = New System.Drawing.Size(96, 21)
        Me.btnObjectCancelTime.TabIndex = 5
        Me.btnObjectCancelTime.Text = "キャンセル"
        Me.ToolTip1.SetToolTip(Me.btnObjectCancelTime, "オブジェクトの編集をキャンセルします")
        Me.btnObjectCancelTime.UseVisualStyleBackColor = True
        '
        'pnlObjectGroupTime
        '
        Me.pnlObjectGroupTime.Controls.Add(Me.gbObjectGroupTime)
        Me.pnlObjectGroupTime.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlObjectGroupTime.Location = New System.Drawing.Point(2, 155)
        Me.pnlObjectGroupTime.Name = "pnlObjectGroupTime"
        Me.pnlObjectGroupTime.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlObjectGroupTime.Size = New System.Drawing.Size(200, 54)
        Me.pnlObjectGroupTime.TabIndex = 1
        '
        'gbObjectGroupTime
        '
        Me.gbObjectGroupTime.Controls.Add(Me.cbObjectGroupTime)
        Me.gbObjectGroupTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbObjectGroupTime.Location = New System.Drawing.Point(3, 3)
        Me.gbObjectGroupTime.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjectGroupTime.Name = "gbObjectGroupTime"
        Me.gbObjectGroupTime.Padding = New System.Windows.Forms.Padding(11, 8, 11, 3)
        Me.gbObjectGroupTime.Size = New System.Drawing.Size(194, 48)
        Me.gbObjectGroupTime.TabIndex = 0
        Me.gbObjectGroupTime.TabStop = False
        Me.gbObjectGroupTime.Text = "オブジェクトグループ"
        '
        'cbObjectGroupTime
        '
        Me.cbObjectGroupTime.AsteriskSelectEnabled = False
        Me.cbObjectGroupTime.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbObjectGroupTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbObjectGroupTime.FormattingEnabled = True
        Me.cbObjectGroupTime.IntegralHeight = False
        Me.cbObjectGroupTime.Location = New System.Drawing.Point(11, 20)
        Me.cbObjectGroupTime.Margin = New System.Windows.Forms.Padding(2)
        Me.cbObjectGroupTime.Name = "cbObjectGroupTime"
        Me.cbObjectGroupTime.Size = New System.Drawing.Size(172, 20)
        Me.cbObjectGroupTime.TabIndex = 1
        '
        'pnlObjectNameTime
        '
        Me.pnlObjectNameTime.Controls.Add(Me.gbObjectNameTime)
        Me.pnlObjectNameTime.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlObjectNameTime.Location = New System.Drawing.Point(2, 21)
        Me.pnlObjectNameTime.Name = "pnlObjectNameTime"
        Me.pnlObjectNameTime.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlObjectNameTime.Size = New System.Drawing.Size(200, 134)
        Me.pnlObjectNameTime.TabIndex = 0
        '
        'gbObjectNameTime
        '
        Me.gbObjectNameTime.Controls.Add(Me.btnObjNameTimeSet)
        Me.gbObjectNameTime.Controls.Add(Me.tbObjectNameTime)
        Me.gbObjectNameTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbObjectNameTime.Location = New System.Drawing.Point(3, 3)
        Me.gbObjectNameTime.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjectNameTime.Name = "gbObjectNameTime"
        Me.gbObjectNameTime.Size = New System.Drawing.Size(194, 128)
        Me.gbObjectNameTime.TabIndex = 0
        Me.gbObjectNameTime.TabStop = False
        Me.gbObjectNameTime.Text = "オブジェクト名"
        '
        'btnObjNameTimeSet
        '
        Me.btnObjNameTimeSet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnObjNameTimeSet.Location = New System.Drawing.Point(3, 102)
        Me.btnObjNameTimeSet.Name = "btnObjNameTimeSet"
        Me.btnObjNameTimeSet.Size = New System.Drawing.Size(188, 23)
        Me.btnObjNameTimeSet.TabIndex = 1
        Me.btnObjNameTimeSet.Text = "オブジェクト名期間設定"
        Me.btnObjNameTimeSet.UseVisualStyleBackColor = True
        '
        'tbObjectNameTime
        '
        Me.tbObjectNameTime.BackColor = System.Drawing.SystemColors.Window
        Me.tbObjectNameTime.Dock = System.Windows.Forms.DockStyle.Top
        Me.tbObjectNameTime.Location = New System.Drawing.Point(3, 15)
        Me.tbObjectNameTime.Multiline = True
        Me.tbObjectNameTime.Name = "tbObjectNameTime"
        Me.tbObjectNameTime.ReadOnly = True
        Me.tbObjectNameTime.Size = New System.Drawing.Size(188, 87)
        Me.tbObjectNameTime.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.tbObjectNameTime, "オフジェクト名の期間を設定します")
        '
        'pnlTimeObjectTop
        '
        Me.pnlTimeObjectTop.Controls.Add(Me.btnTimeObjectEditHelp)
        Me.pnlTimeObjectTop.Controls.Add(Me.Label9)
        Me.pnlTimeObjectTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTimeObjectTop.Location = New System.Drawing.Point(2, 2)
        Me.pnlTimeObjectTop.Name = "pnlTimeObjectTop"
        Me.pnlTimeObjectTop.Size = New System.Drawing.Size(200, 19)
        Me.pnlTimeObjectTop.TabIndex = 25
        '
        'btnTimeObjectEditHelp
        '
        Me.btnTimeObjectEditHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTimeObjectEditHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnTimeObjectEditHelp.Location = New System.Drawing.Point(179, -1)
        Me.btnTimeObjectEditHelp.Name = "btnTimeObjectEditHelp"
        Me.btnTimeObjectEditHelp.Size = New System.Drawing.Size(20, 20)
        Me.btnTimeObjectEditHelp.TabIndex = 13
        Me.btnTimeObjectEditHelp.Text = "?"
        Me.btnTimeObjectEditHelp.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(180, 19)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "時空間モードオブジェクト編集"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPicMap
        '
        Me.lblPicMap.AutoSize = True
        Me.lblPicMap.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblPicMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPicMap.Location = New System.Drawing.Point(498, 22)
        Me.lblPicMap.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPicMap.Name = "lblPicMap"
        Me.lblPicMap.Padding = New System.Windows.Forms.Padding(2)
        Me.lblPicMap.Size = New System.Drawing.Size(138, 18)
        Me.lblPicMap.TabIndex = 5
        Me.lblPicMap.Text = "オブジェクト名表示用ラベル"
        '
        'picMap
        '
        Me.picMap.BackColor = System.Drawing.Color.White
        Me.picMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picMap.Location = New System.Drawing.Point(0, 0)
        Me.picMap.Margin = New System.Windows.Forms.Padding(2)
        Me.picMap.Name = "picMap"
        Me.picMap.Size = New System.Drawing.Size(842, 897)
        Me.picMap.TabIndex = 4
        Me.picMap.TabStop = False
        '
        'scPropertyAndDefAttribute
        '
        Me.scPropertyAndDefAttribute.BackColor = System.Drawing.SystemColors.Control
        Me.scPropertyAndDefAttribute.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scPropertyAndDefAttribute.Location = New System.Drawing.Point(0, 0)
        Me.scPropertyAndDefAttribute.Name = "scPropertyAndDefAttribute"
        Me.scPropertyAndDefAttribute.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scPropertyAndDefAttribute.Panel1
        '
        Me.scPropertyAndDefAttribute.Panel1.BackColor = System.Drawing.SystemColors.Control
        '
        'scPropertyAndDefAttribute.Panel2
        '
        Me.scPropertyAndDefAttribute.Panel2.Controls.Add(Me.pnlDefAttribute)
        Me.scPropertyAndDefAttribute.Panel2MinSize = 0
        Me.scPropertyAndDefAttribute.Size = New System.Drawing.Size(297, 897)
        Me.scPropertyAndDefAttribute.SplitterDistance = 470
        Me.scPropertyAndDefAttribute.TabIndex = 15
        '
        'pnlDefAttribute
        '
        Me.pnlDefAttribute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDefAttribute.Controls.Add(Me.ktGridDefAttValue)
        Me.pnlDefAttribute.Controls.Add(Me.lblDefAttribute)
        Me.pnlDefAttribute.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDefAttribute.Location = New System.Drawing.Point(0, 0)
        Me.pnlDefAttribute.Name = "pnlDefAttribute"
        Me.pnlDefAttribute.Size = New System.Drawing.Size(297, 423)
        Me.pnlDefAttribute.TabIndex = 14
        '
        'ktGridDefAttValue
        '
        Me.ktGridDefAttValue.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGridDefAttValue.DefaultFixedXNumberingWidth = 50
        Me.ktGridDefAttValue.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGridDefAttValue.DefaultFixedXWidth = 150
        Me.ktGridDefAttValue.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGridDefAttValue.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ktGridDefAttValue.DefaultGridWidth = 100
        Me.ktGridDefAttValue.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ktGridDefAttValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ktGridDefAttValue.FixedGridColor = System.Drawing.SystemColors.Control
        Me.ktGridDefAttValue.FrameColor = System.Drawing.SystemColors.Control
        Me.ktGridDefAttValue.GridColor = System.Drawing.Color.White
        Me.ktGridDefAttValue.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktGridDefAttValue.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ktGridDefAttValue.Layer = 0
        Me.ktGridDefAttValue.LayerCaption = Nothing
        Me.ktGridDefAttValue.Location = New System.Drawing.Point(0, 14)
        Me.ktGridDefAttValue.Margin = New System.Windows.Forms.Padding(4)
        Me.ktGridDefAttValue.MsgBoxTitle = ""
        Me.ktGridDefAttValue.Name = "ktGridDefAttValue"
        Me.ktGridDefAttValue.RowCaption = Nothing
        Me.ktGridDefAttValue.Size = New System.Drawing.Size(295, 407)
        Me.ktGridDefAttValue.TabClickEnabled = False
        Me.ktGridDefAttValue.TabIndex = 14
        '
        'lblDefAttribute
        '
        Me.lblDefAttribute.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblDefAttribute.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDefAttribute.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDefAttribute.Location = New System.Drawing.Point(0, 0)
        Me.lblDefAttribute.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDefAttribute.Name = "lblDefAttribute"
        Me.lblDefAttribute.Size = New System.Drawing.Size(295, 14)
        Me.lblDefAttribute.TabIndex = 13
        Me.lblDefAttribute.Text = "初期属性"
        Me.lblDefAttribute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslblY, Me.tsslblX})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 946)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 10, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1348, 24)
        Me.StatusStrip1.TabIndex = 13
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslblY
        '
        Me.tsslblY.AutoSize = False
        Me.tsslblY.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tsslblY.Name = "tsslblY"
        Me.tsslblY.Size = New System.Drawing.Size(150, 19)
        Me.tsslblY.Text = "Y"
        Me.tsslblY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsslblX
        '
        Me.tsslblX.AutoSize = False
        Me.tsslblX.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tsslblX.Name = "tsslblX"
        Me.tsslblX.Size = New System.Drawing.Size(150, 19)
        Me.tsslblX.Text = "X"
        Me.tsslblX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAllShow, Me.ToolStripSeparator1, Me.tsbBackImage, Me.ToolStripSeparator7, Me.tsbObjectNameVisible, Me.ToolStripSeparator6, Me.tsbLineEndPointShow, Me.ToolStripSeparator2, Me.tsbObjectEditMode, Me.ToolStripSeparator3, Me.tsbLineEditMode, Me.ToolStripSeparator4, Me.tsbMultiSelect})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1348, 25)
        Me.ToolStrip.TabIndex = 1
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'tsbAllShow
        '
        Me.tsbAllShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbAllShow.Image = CType(resources.GetObject("tsbAllShow.Image"), System.Drawing.Image)
        Me.tsbAllShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAllShow.Name = "tsbAllShow"
        Me.tsbAllShow.Size = New System.Drawing.Size(59, 22)
        Me.tsbAllShow.Text = "全体表示"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbBackImage
        '
        Me.tsbBackImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbBackImage.Image = CType(resources.GetObject("tsbBackImage.Image"), System.Drawing.Image)
        Me.tsbBackImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBackImage.Name = "tsbBackImage"
        Me.tsbBackImage.Size = New System.Drawing.Size(59, 22)
        Me.tsbBackImage.Text = "背景画像"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tsbObjectNameVisible
        '
        Me.tsbObjectNameVisible.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbObjectNameVisible.Image = CType(resources.GetObject("tsbObjectNameVisible.Image"), System.Drawing.Image)
        Me.tsbObjectNameVisible.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbObjectNameVisible.Name = "tsbObjectNameVisible"
        Me.tsbObjectNameVisible.Size = New System.Drawing.Size(75, 22)
        Me.tsbObjectNameVisible.Text = "オブジェクト名"
        Me.tsbObjectNameVisible.ToolTipText = "オブジェクト名の表示/非表示の切り替え"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsbLineEndPointShow
        '
        Me.tsbLineEndPointShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbLineEndPointShow.Image = CType(resources.GetObject("tsbLineEndPointShow.Image"), System.Drawing.Image)
        Me.tsbLineEndPointShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLineEndPointShow.Name = "tsbLineEndPointShow"
        Me.tsbLineEndPointShow.Size = New System.Drawing.Size(61, 22)
        Me.tsbLineEndPointShow.Text = "ライン端点"
        Me.tsbLineEndPointShow.ToolTipText = "ライン端点の表示/非表示の切り替え"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbObjectEditMode
        '
        Me.tsbObjectEditMode.CheckOnClick = True
        Me.tsbObjectEditMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbObjectEditMode.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tsbObjectEditMode.Image = CType(resources.GetObject("tsbObjectEditMode.Image"), System.Drawing.Image)
        Me.tsbObjectEditMode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbObjectEditMode.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.tsbObjectEditMode.Name = "tsbObjectEditMode"
        Me.tsbObjectEditMode.Size = New System.Drawing.Size(123, 22)
        Me.tsbObjectEditMode.Text = "オブジェクト編集モード"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbLineEditMode
        '
        Me.tsbLineEditMode.CheckOnClick = True
        Me.tsbLineEditMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbLineEditMode.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tsbLineEditMode.Image = CType(resources.GetObject("tsbLineEditMode.Image"), System.Drawing.Image)
        Me.tsbLineEditMode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLineEditMode.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.tsbLineEditMode.Name = "tsbLineEditMode"
        Me.tsbLineEditMode.Size = New System.Drawing.Size(95, 22)
        Me.tsbLineEditMode.Text = "ライン編集モード"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbMultiSelect
        '
        Me.tsbMultiSelect.CheckOnClick = True
        Me.tsbMultiSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbMultiSelect.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tsbMultiSelect.Image = CType(resources.GetObject("tsbMultiSelect.Image"), System.Drawing.Image)
        Me.tsbMultiSelect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMultiSelect.Name = "tsbMultiSelect"
        Me.tsbMultiSelect.Size = New System.Drawing.Size(61, 22)
        Me.tsbMultiSelect.Text = "複数選択"
        '
        'btnNewObjectAndLine
        '
        Me.btnNewObjectAndLine.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnNewObjectAndLine.Location = New System.Drawing.Point(708, 29)
        Me.btnNewObjectAndLine.Name = "btnNewObjectAndLine"
        Me.btnNewObjectAndLine.Size = New System.Drawing.Size(96, 20)
        Me.btnNewObjectAndLine.TabIndex = 15
        Me.btnNewObjectAndLine.Text = "新規オブジェクト"
        Me.btnNewObjectAndLine.UseVisualStyleBackColor = True
        '
        'ProgressLabel
        '
        Me.ProgressLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProgressLabel.LabelColor = System.Drawing.SystemColors.Control
        Me.ProgressLabel.Location = New System.Drawing.Point(482, 44)
        Me.ProgressLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.Size = New System.Drawing.Size(180, 40)
        Me.ProgressLabel.TabIndex = 20
        Me.ProgressLabel.Visible = False
        '
        'frmMapEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1348, 970)
        Me.Controls.Add(Me.ProgressLabel)
        Me.Controls.Add(Me.btnNewObjectAndLine)
        Me.Controls.Add(Me.SplitContainerTotal)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmMapEditor"
        Me.Text = "マップエディタ"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainerTotal.Panel1.ResumeLayout(False)
        Me.SplitContainerTotal.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerTotal.ResumeLayout(False)
        Me.pnlLineConnect.ResumeLayout(False)
        Me.gbLineConnect.ResumeLayout(False)
        Me.gbLineConnect.PerformLayout()
        Me.pnlUsedNumber.ResumeLayout(False)
        Me.gbUsetNumber.ResumeLayout(False)
        Me.gbUsetNumber.PerformLayout()
        Me.pnlLineKindEdit.ResumeLayout(False)
        Me.gbLineKindEdit.ResumeLayout(False)
        Me.pnlObjectShapeEdit.ResumeLayout(False)
        Me.gbObjShapeEdit.ResumeLayout(False)
        Me.gbObjShapeEdit.PerformLayout()
        Me.pnlObjTypeEdit.ResumeLayout(False)
        Me.gbObjTypeEdit.ResumeLayout(False)
        Me.gbObjTypeEdit.PerformLayout()
        Me.pnlObjectGroup.ResumeLayout(False)
        Me.gbObjGroupEdit.ResumeLayout(False)
        Me.pnEditTime.ResumeLayout(False)
        Me.gbEditTime.ResumeLayout(False)
        Me.gbEditTime.PerformLayout()
        Me.pnlEdit.ResumeLayout(False)
        Me.SplitContainerMapAndProperty.Panel1.ResumeLayout(False)
        Me.SplitContainerMapAndProperty.Panel1.PerformLayout()
        Me.SplitContainerMapAndProperty.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerMapAndProperty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMapAndProperty.ResumeLayout(False)
        Me.pnlObjectEdit.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlObjectKind.ResumeLayout(False)
        Me.gbObjectKind.ResumeLayout(False)
        Me.pnlObjectName12.ResumeLayout(False)
        Me.pnlObjectName12.PerformLayout()
        Me.pnlObjectEditTop.ResumeLayout(False)
        Me.pnlMultiLines.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlMultiLineTop.ResumeLayout(False)
        Me.pnlMultiObjects.ResumeLayout(False)
        Me.pnlMultiObjectCommand.ResumeLayout(False)
        Me.pnlMultiObjectCommand.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.pnlSelectMode.ResumeLayout(False)
        Me.gbSelectMode.ResumeLayout(False)
        Me.gbSelectMode.PerformLayout()
        Me.pnlMultiObjectTop.ResumeLayout(False)
        Me.pnlLineEdit.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.pnlLineTimekindSet.ResumeLayout(False)
        Me.pnlLineTimekindSet.PerformLayout()
        Me.pnlLineKind.ResumeLayout(False)
        Me.gbLineKind.ResumeLayout(False)
        Me.pnlLineTop.ResumeLayout(False)
        Me.pnlPropertyWindow.ResumeLayout(False)
        Me.pnlObjectTimeEdit.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnlObjectGroupTime.ResumeLayout(False)
        Me.gbObjectGroupTime.ResumeLayout(False)
        Me.pnlObjectNameTime.ResumeLayout(False)
        Me.gbObjectNameTime.ResumeLayout(False)
        Me.gbObjectNameTime.PerformLayout()
        Me.pnlTimeObjectTop.ResumeLayout(False)
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scPropertyAndDefAttribute.Panel2.ResumeLayout(False)
        CType(Me.scPropertyAndDefAttribute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scPropertyAndDefAttribute.ResumeLayout(False)
        Me.pnlDefAttribute.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveMapFileRename As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainerTotal As System.Windows.Forms.SplitContainer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslblX As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslblY As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainerMapAndProperty As System.Windows.Forms.SplitContainer
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents lblObjectEdit As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAllShow As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbObjTypeEdit As System.Windows.Forms.GroupBox
    Friend WithEvents rbObjTypeEditAggregation As System.Windows.Forms.RadioButton
    Friend WithEvents rbObjTypeEditNormal As System.Windows.Forms.RadioButton
    Friend WithEvents gbObjGroupEdit As System.Windows.Forms.GroupBox
    Friend WithEvents gbObjShapeEdit As System.Windows.Forms.GroupBox
    Friend WithEvents cbPointShapeEdit As System.Windows.Forms.CheckBox
    Friend WithEvents gbLineKindEdit As System.Windows.Forms.GroupBox
    Friend WithEvents cbPolygonShapeEdit As System.Windows.Forms.CheckBox
    Friend WithEvents cbLineShapeEdit As System.Windows.Forms.CheckBox
    Friend WithEvents gbUsetNumber As System.Windows.Forms.GroupBox
    Friend WithEvents cbLineObjectThirdUsedEdit As System.Windows.Forms.CheckBox
    Friend WithEvents cbLineObjectSecondUsedEdit As System.Windows.Forms.CheckBox
    Friend WithEvents cbLineObjectOneUsedEdit As System.Windows.Forms.CheckBox
    Friend WithEvents cbLineObjectNoUsedEdit As System.Windows.Forms.CheckBox
    Friend WithEvents gbLineConnect As System.Windows.Forms.GroupBox
    Friend WithEvents cbLineLoopEdit As System.Windows.Forms.CheckBox
    Friend WithEvents cbLineBothConnectEdit As System.Windows.Forms.CheckBox
    Friend WithEvents cbLineOneConnectEdit As System.Windows.Forms.CheckBox
    Friend WithEvents cbLineNonConnectEdit As System.Windows.Forms.CheckBox
    Friend WithEvents ｌｂｌLineEdit As System.Windows.Forms.Label
    Friend WithEvents tsbObjectNameVisible As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlObjectGroup As System.Windows.Forms.Panel
    Friend WithEvents pnlObjTypeEdit As System.Windows.Forms.Panel
    Friend WithEvents pnlObjectShapeEdit As System.Windows.Forms.Panel
    Friend WithEvents pnlLineKindEdit As System.Windows.Forms.Panel
    Friend WithEvents pnlUsedNumber As System.Windows.Forms.Panel
    Friend WithEvents pnlLineConnect As System.Windows.Forms.Panel
    Friend WithEvents clbObjectKindEdit As mandara10.CheckedListBoxEx
    Friend WithEvents clbLineKindEdit As mandara10.CheckedListBoxEx
    Friend WithEvents lblPicMap As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbObjectEditMode As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbLineEditMode As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRecentUsedFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnNewObjectAndLine As System.Windows.Forms.Button
    Friend WithEvents tsbMultiSelect As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlDefAttribute As System.Windows.Forms.Panel
    Friend WithEvents lblDefAttribute As System.Windows.Forms.Label
    Friend WithEvents pnlPropertyWindow As System.Windows.Forms.Panel
    Friend WithEvents lblProperty As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlObjectEdit As System.Windows.Forms.Panel
    Friend WithEvents pnlObjectName12 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnObjectCancel As System.Windows.Forms.Button
    Friend WithEvents btnObjectDelete As System.Windows.Forms.Button
    Friend WithEvents btnObjectRegist As System.Windows.Forms.Button
    Friend WithEvents btnAutoBoundary As System.Windows.Forms.Button
    Friend WithEvents btnCenterGrabityPoint As System.Windows.Forms.Button
    Friend WithEvents scPropertyAndDefAttribute As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlObjectKind As System.Windows.Forms.Panel
    Friend WithEvents gbObjectKind As System.Windows.Forms.GroupBox
    Friend WithEvents cboObjectKind As mandara10.ComboBoxEx
    Friend WithEvents pnlObjectTimeEdit As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCenterPointTime As System.Windows.Forms.Button
    Friend WithEvents btnObjectDeleteTime As System.Windows.Forms.Button
    Friend WithEvents btnObjectCancelTime As System.Windows.Forms.Button
    Friend WithEvents btnTimeObject As System.Windows.Forms.Button
    Friend WithEvents btnObjrectRegistTime As System.Windows.Forms.Button
    Friend WithEvents btnSuccession As System.Windows.Forms.Button
    Friend WithEvents pnlObjectNameTime As System.Windows.Forms.Panel
    Friend WithEvents gbObjectNameTime As System.Windows.Forms.GroupBox
    Friend WithEvents tbObjectNameTime As System.Windows.Forms.TextBox
    Friend WithEvents pnlObjectGroupTime As System.Windows.Forms.Panel
    Friend WithEvents gbObjectGroupTime As System.Windows.Forms.GroupBox
    Friend WithEvents cbObjectGroupTime As mandara10.ComboBoxEx
    Friend WithEvents lvtPropertyWindow As mandara10.ListViewEX
    Friend WithEvents btnObjNameTimeSet As System.Windows.Forms.Button
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlLineEdit As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnLineCancel As System.Windows.Forms.Button
    Friend WithEvents btnLineDelete As System.Windows.Forms.Button
    Friend WithEvents btnLineRegist As System.Windows.Forms.Button
    Friend WithEvents btnLineDivide_and_Node As System.Windows.Forms.Button
    Friend WithEvents btnNode As System.Windows.Forms.Button
    Friend WithEvents pnlLineKind As System.Windows.Forms.Panel
    Friend WithEvents gbLineKind As System.Windows.Forms.GroupBox
    Friend WithEvents cboLineKind As mandara10.ComboBoxEx
    Friend WithEvents pnlLineTimekindSet As System.Windows.Forms.Panel
    Friend WithEvents btnLineTimeKindSet As System.Windows.Forms.Button
    Friend WithEvents tbLineKindTime As System.Windows.Forms.TextBox
    Friend WithEvents pnlMultiObjects As System.Windows.Forms.Panel
    Friend WithEvents btnMultiPbjectsEnd As System.Windows.Forms.Button
    Friend WithEvents pnlMultiObjectCommand As System.Windows.Forms.Panel
    Friend WithEvents btnMultiObjectsExe As System.Windows.Forms.Button
    Friend WithEvents lbMultiObjectsCommand As System.Windows.Forms.ListBox
    Friend WithEvents lblOperation As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlSelectMode As System.Windows.Forms.Panel
    Friend WithEvents gbSelectMode As System.Windows.Forms.GroupBox
    Friend WithEvents rbMultiObjectSelectMode_Polygon As System.Windows.Forms.RadioButton
    Friend WithEvents rbMultiObjectSelectMode_Circle As System.Windows.Forms.RadioButton
    Friend WithEvents rbMultiObjectSelectMode_Rectangle As System.Windows.Forms.RadioButton
    Friend WithEvents rbMultiObjectSelectMode_Pointing As System.Windows.Forms.RadioButton
    Friend WithEvents pnlMultiLines As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMultiLineEnd As System.Windows.Forms.Button
    Friend WithEvents btnMultiLineExe As System.Windows.Forms.Button
    Friend WithEvents lbMultiLineCommand As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMultiLineSelectMode_Polygon As System.Windows.Forms.RadioButton
    Friend WithEvents rbMultiLineSelectMode_Circle As System.Windows.Forms.RadioButton
    Friend WithEvents rbMultiLineSelectMode_Rectangle As System.Windows.Forms.RadioButton
    Friend WithEvents rbMultiLineSelectMode_Pointing As System.Windows.Forms.RadioButton
    Friend WithEvents mnuSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuObjectkind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSettingObjectGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCombineObjectGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLineKind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSettingLineKind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCombineLineKind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ktGridDefAttValue As KTGISUserControl.KTGISGrid
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuImportData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSaveMapFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuInsertMapFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCompassSetting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuObjectEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLineEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuObjectSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDefAttData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopyScreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuObjectEditMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLineEditMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSearch_Object_by_Number As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReplaceObjectName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSearch_Line As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuChangeAllObjectName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopyObjectName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSet_ClickObjectName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCombineSameNameObjecs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAggrObjClipSet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSetCenterP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGetPointObject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbLineEndPointShow As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuLineConnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLineCut_by_CrossPoint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLineTopolyze As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLineNodalPoint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLineSmoothing As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnShowCoord As System.Windows.Forms.Button
    Friend WithEvents btnOtherSelectMethos As System.Windows.Forms.Button
    Friend WithEvents btnMultiObjectClear As System.Windows.Forms.Button
    Friend WithEvents btnMultiLineClear As System.Windows.Forms.Button
    Friend WithEvents btnOtherLineSelectMethos As System.Windows.Forms.Button
    Friend WithEvents mnuGetLine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAllShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuObjectNameVisible As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLineEndPointShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuConvZahyo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSokutiConvert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConvert_Tokyo97toITRF94 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConvert_ITRF94toTokyo97 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConvert_XY2IdoKedo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIdokedoMove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuBackImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDefAtrShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReplace_ITRF94_Tokyo97 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProjectionConvert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMapFileProperty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbBackImage As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTimeEditMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuShapeFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGetContour As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgressLabel As KTGISUserControl.KTGISProgressLabel
    Friend WithEvents mnuShapefileOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuKMLFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewrGo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuE00File As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ktObjectName As KTGISUserControl.KTGISGrid
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuObjectNameEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCensusSmallArea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuObjectTimeEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSuccesionView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuObjectNameChangeView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTimeObjectSet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnEditTime As System.Windows.Forms.Panel
    Friend WithEvents gbEditTime As System.Windows.Forms.GroupBox
    Friend WithEvents cbLineTime As System.Windows.Forms.CheckBox
    Friend WithEvents dbdtpEditTime As mandara10.DbDateTimePicker
    Friend WithEvents pnlEdit As System.Windows.Forms.Panel
    Friend WithEvents btnEditPanelHelp As System.Windows.Forms.Button
    Friend WithEvents cbUnEditableVisible As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlObjectEditTop As System.Windows.Forms.Panel
    Friend WithEvents btnObjectEditHelp As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlMultiLineTop As System.Windows.Forms.Panel
    Friend WithEvents btnMultiLinesEditHelp As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlMultiObjectTop As System.Windows.Forms.Panel
    Friend WithEvents btnMultiObjectsEditHelp As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlLineTop As System.Windows.Forms.Panel
    Friend WithEvents btnLineEditHelp As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlTimeObjectTop As System.Windows.Forms.Panel
    Friend WithEvents btnTimeObjectEditHelp As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents mnuKiban As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents mnuOpenStreetMap As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuMakeMeshObject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveAsMPFJ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNewBlankMapData As System.Windows.Forms.ToolStripMenuItem

End Class
