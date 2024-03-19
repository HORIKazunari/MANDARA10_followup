<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGrid
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
        Me.SplitContainerOuter = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerUpper = New System.Windows.Forms.SplitContainer()
        Me.btnGPX = New System.Windows.Forms.Button()
        Me.btnAddDefAttr = New System.Windows.Forms.Button()
        Me.gbFind = New System.Windows.Forms.GroupBox()
        Me.btnBefore = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.gbMapfile = New System.Windows.Forms.GroupBox()
        Me.btnReplaceMapFile = New System.Windows.Forms.Button()
        Me.btnRemoveMapFile = New System.Windows.Forms.Button()
        Me.btnAddMapfile = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnObjectNameCopy = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainerLayer = New System.Windows.Forms.SplitContainer()
        Me.cboMissingValue = New System.Windows.Forms.ComboBox()
        Me.cboAttDataType = New System.Windows.Forms.ComboBox()
        Me.ktGrid = New KTGISUserControl.KTGISGrid()
        Me.gbReferenceSystem = New System.Windows.Forms.GroupBox()
        Me.rbTokyo = New System.Windows.Forms.RadioButton()
        Me.rbWorld = New System.Windows.Forms.RadioButton()
        Me.gbLayerComment = New System.Windows.Forms.GroupBox()
        Me.txtLayerComment = New System.Windows.Forms.TextBox()
        Me.gbShape = New System.Windows.Forms.GroupBox()
        Me.cboLayerShape = New System.Windows.Forms.ComboBox()
        Me.gbMeshType = New System.Windows.Forms.GroupBox()
        Me.cboMesh = New System.Windows.Forms.ComboBox()
        Me.gbLayerMapFile = New System.Windows.Forms.GroupBox()
        Me.cboLayerMapFile = New System.Windows.Forms.ComboBox()
        Me.gbDateTime = New System.Windows.Forms.GroupBox()
        Me.DateTimePickerLayer = New System.Windows.Forms.DateTimePicker()
        Me.gbLayerType = New System.Windows.Forms.GroupBox()
        Me.cboLayerType = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbMapFile = New mandara10.ListBoxEx()
        Me.lbError = New mandara10.ListBoxEx()
        Me.ListBoxEx1 = New mandara10.ListBoxEx()
        CType(Me.SplitContainerOuter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerOuter.Panel1.SuspendLayout()
        Me.SplitContainerOuter.Panel2.SuspendLayout()
        Me.SplitContainerOuter.SuspendLayout()
        CType(Me.SplitContainerUpper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerUpper.Panel1.SuspendLayout()
        Me.SplitContainerUpper.Panel2.SuspendLayout()
        Me.SplitContainerUpper.SuspendLayout()
        Me.gbFind.SuspendLayout()
        Me.gbMapfile.SuspendLayout()
        CType(Me.SplitContainerLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerLayer.Panel1.SuspendLayout()
        Me.SplitContainerLayer.Panel2.SuspendLayout()
        Me.SplitContainerLayer.SuspendLayout()
        Me.gbReferenceSystem.SuspendLayout()
        Me.gbLayerComment.SuspendLayout()
        Me.gbShape.SuspendLayout()
        Me.gbMeshType.SuspendLayout()
        Me.gbLayerMapFile.SuspendLayout()
        Me.gbDateTime.SuspendLayout()
        Me.gbLayerType.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerOuter
        '
        Me.SplitContainerOuter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerOuter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerOuter.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerOuter.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainerOuter.Name = "SplitContainerOuter"
        Me.SplitContainerOuter.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerOuter.Panel1
        '
        Me.SplitContainerOuter.Panel1.Controls.Add(Me.SplitContainerUpper)
        '
        'SplitContainerOuter.Panel2
        '
        Me.SplitContainerOuter.Panel2.Controls.Add(Me.SplitContainerLayer)
        Me.SplitContainerOuter.Size = New System.Drawing.Size(791, 675)
        Me.SplitContainerOuter.SplitterDistance = 114
        Me.SplitContainerOuter.SplitterWidth = 3
        Me.SplitContainerOuter.TabIndex = 1
        '
        'SplitContainerUpper
        '
        Me.SplitContainerUpper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerUpper.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerUpper.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerUpper.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainerUpper.Name = "SplitContainerUpper"
        '
        'SplitContainerUpper.Panel1
        '
        Me.SplitContainerUpper.Panel1.Controls.Add(Me.btnGPX)
        Me.SplitContainerUpper.Panel1.Controls.Add(Me.btnAddDefAttr)
        Me.SplitContainerUpper.Panel1.Controls.Add(Me.gbFind)
        Me.SplitContainerUpper.Panel1.Controls.Add(Me.gbMapfile)
        Me.SplitContainerUpper.Panel1.Controls.Add(Me.btnCancel)
        Me.SplitContainerUpper.Panel1.Controls.Add(Me.btnObjectNameCopy)
        Me.SplitContainerUpper.Panel1.Controls.Add(Me.btnOK)
        '
        'SplitContainerUpper.Panel2
        '
        Me.SplitContainerUpper.Panel2.Controls.Add(Me.btnHelp)
        Me.SplitContainerUpper.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainerUpper.Panel2.Controls.Add(Me.lbError)
        Me.SplitContainerUpper.Size = New System.Drawing.Size(791, 114)
        Me.SplitContainerUpper.SplitterDistance = 613
        Me.SplitContainerUpper.SplitterWidth = 3
        Me.SplitContainerUpper.TabIndex = 0
        '
        'btnGPX
        '
        Me.btnGPX.Location = New System.Drawing.Point(434, 16)
        Me.btnGPX.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGPX.Name = "btnGPX"
        Me.btnGPX.Size = New System.Drawing.Size(113, 41)
        Me.btnGPX.TabIndex = 2
        Me.btnGPX.Text = "GPXファイルから移動データレイヤ作成"
        Me.btnGPX.UseVisualStyleBackColor = True
        '
        'btnAddDefAttr
        '
        Me.btnAddDefAttr.Location = New System.Drawing.Point(240, 65)
        Me.btnAddDefAttr.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddDefAttr.Name = "btnAddDefAttr"
        Me.btnAddDefAttr.Size = New System.Drawing.Size(99, 39)
        Me.btnAddDefAttr.TabIndex = 3
        Me.btnAddDefAttr.Text = "初期属性追加"
        Me.btnAddDefAttr.UseVisualStyleBackColor = True
        '
        'gbFind
        '
        Me.gbFind.Controls.Add(Me.btnBefore)
        Me.gbFind.Controls.Add(Me.btnNext)
        Me.gbFind.Controls.Add(Me.btnSearch)
        Me.gbFind.Location = New System.Drawing.Point(240, 10)
        Me.gbFind.Margin = New System.Windows.Forms.Padding(2)
        Me.gbFind.Name = "gbFind"
        Me.gbFind.Padding = New System.Windows.Forms.Padding(2)
        Me.gbFind.Size = New System.Drawing.Size(188, 49)
        Me.gbFind.TabIndex = 1
        Me.gbFind.TabStop = False
        Me.gbFind.Text = "検索"
        '
        'btnBefore
        '
        Me.btnBefore.Location = New System.Drawing.Point(80, 19)
        Me.btnBefore.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBefore.Name = "btnBefore"
        Me.btnBefore.Size = New System.Drawing.Size(46, 20)
        Me.btnBefore.TabIndex = 37
        Me.btnBefore.Text = "前"
        Me.btnBefore.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(130, 18)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(46, 21)
        Me.btnNext.TabIndex = 36
        Me.btnNext.Text = "次"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(14, 18)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(61, 21)
        Me.btnSearch.TabIndex = 35
        Me.btnSearch.Text = "検索"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'gbMapfile
        '
        Me.gbMapfile.Controls.Add(Me.btnReplaceMapFile)
        Me.gbMapfile.Controls.Add(Me.btnRemoveMapFile)
        Me.gbMapfile.Controls.Add(Me.lbMapFile)
        Me.gbMapfile.Controls.Add(Me.btnAddMapfile)
        Me.gbMapfile.Location = New System.Drawing.Point(16, 10)
        Me.gbMapfile.Margin = New System.Windows.Forms.Padding(2)
        Me.gbMapfile.Name = "gbMapfile"
        Me.gbMapfile.Padding = New System.Windows.Forms.Padding(2)
        Me.gbMapfile.Size = New System.Drawing.Size(212, 100)
        Me.gbMapfile.TabIndex = 0
        Me.gbMapfile.TabStop = False
        Me.gbMapfile.Text = "地図ファイル"
        '
        'btnReplaceMapFile
        '
        Me.btnReplaceMapFile.Location = New System.Drawing.Point(134, 16)
        Me.btnReplaceMapFile.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReplaceMapFile.Name = "btnReplaceMapFile"
        Me.btnReplaceMapFile.Size = New System.Drawing.Size(63, 21)
        Me.btnReplaceMapFile.TabIndex = 1
        Me.btnReplaceMapFile.Text = "差し替え"
        Me.btnReplaceMapFile.UseVisualStyleBackColor = True
        '
        'btnRemoveMapFile
        '
        Me.btnRemoveMapFile.Location = New System.Drawing.Point(135, 44)
        Me.btnRemoveMapFile.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRemoveMapFile.Name = "btnRemoveMapFile"
        Me.btnRemoveMapFile.Size = New System.Drawing.Size(63, 21)
        Me.btnRemoveMapFile.TabIndex = 2
        Me.btnRemoveMapFile.Text = "削除"
        Me.btnRemoveMapFile.UseVisualStyleBackColor = True
        '
        'btnAddMapfile
        '
        Me.btnAddMapfile.Location = New System.Drawing.Point(135, 74)
        Me.btnAddMapfile.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddMapfile.Name = "btnAddMapfile"
        Me.btnAddMapfile.Size = New System.Drawing.Size(63, 21)
        Me.btnAddMapfile.TabIndex = 3
        Me.btnAddMapfile.Text = "追加"
        Me.btnAddMapfile.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(516, 76)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 28)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnObjectNameCopy
        '
        Me.btnObjectNameCopy.Location = New System.Drawing.Point(344, 65)
        Me.btnObjectNameCopy.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjectNameCopy.Name = "btnObjectNameCopy"
        Me.btnObjectNameCopy.Size = New System.Drawing.Size(84, 39)
        Me.btnObjectNameCopy.TabIndex = 4
        Me.btnObjectNameCopy.Text = "オブジェクト名コピーパネル"
        Me.btnObjectNameCopy.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(434, 76)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 28)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(140, 7)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(30, 21)
        Me.btnHelp.TabIndex = 9
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "エラー情報"
        '
        'SplitContainerLayer
        '
        Me.SplitContainerLayer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerLayer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerLayer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerLayer.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainerLayer.Name = "SplitContainerLayer"
        '
        'SplitContainerLayer.Panel1
        '
        Me.SplitContainerLayer.Panel1.Controls.Add(Me.cboMissingValue)
        Me.SplitContainerLayer.Panel1.Controls.Add(Me.cboAttDataType)
        Me.SplitContainerLayer.Panel1.Controls.Add(Me.ktGrid)
        '
        'SplitContainerLayer.Panel2
        '
        Me.SplitContainerLayer.Panel2.Controls.Add(Me.gbReferenceSystem)
        Me.SplitContainerLayer.Panel2.Controls.Add(Me.gbLayerComment)
        Me.SplitContainerLayer.Panel2.Controls.Add(Me.gbShape)
        Me.SplitContainerLayer.Panel2.Controls.Add(Me.gbMeshType)
        Me.SplitContainerLayer.Panel2.Controls.Add(Me.gbLayerMapFile)
        Me.SplitContainerLayer.Panel2.Controls.Add(Me.gbDateTime)
        Me.SplitContainerLayer.Panel2.Controls.Add(Me.gbLayerType)
        Me.SplitContainerLayer.Size = New System.Drawing.Size(791, 558)
        Me.SplitContainerLayer.SplitterDistance = 569
        Me.SplitContainerLayer.SplitterWidth = 3
        Me.SplitContainerLayer.TabIndex = 1
        '
        'cboMissingValue
        '
        Me.cboMissingValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissingValue.FormattingEnabled = True
        Me.cboMissingValue.Location = New System.Drawing.Point(268, 209)
        Me.cboMissingValue.Margin = New System.Windows.Forms.Padding(2)
        Me.cboMissingValue.Name = "cboMissingValue"
        Me.cboMissingValue.Size = New System.Drawing.Size(69, 20)
        Me.cboMissingValue.TabIndex = 18
        '
        'cboAttDataType
        '
        Me.cboAttDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttDataType.FormattingEnabled = True
        Me.cboAttDataType.Location = New System.Drawing.Point(266, 186)
        Me.cboAttDataType.Margin = New System.Windows.Forms.Padding(2)
        Me.cboAttDataType.Name = "cboAttDataType"
        Me.cboAttDataType.Size = New System.Drawing.Size(69, 20)
        Me.cboAttDataType.TabIndex = 17
        '
        'ktGrid
        '
        Me.ktGrid.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultFixedXNumberingWidth = 50
        Me.ktGrid.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultFixedXWidth = 150
        Me.ktGrid.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ktGrid.DefaultGridWidth = 100
        Me.ktGrid.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ktGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ktGrid.FixedGridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ktGrid.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktGrid.FrameColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.ktGrid.GridColor = System.Drawing.Color.White
        Me.ktGrid.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktGrid.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ktGrid.Layer = 0
        Me.ktGrid.LayerCaption = Nothing
        Me.ktGrid.Location = New System.Drawing.Point(0, 0)
        Me.ktGrid.Margin = New System.Windows.Forms.Padding(5)
        Me.ktGrid.MsgBoxTitle = ""
        Me.ktGrid.Name = "ktGrid"
        Me.ktGrid.RowCaption = Nothing
        Me.ktGrid.Size = New System.Drawing.Size(569, 558)
        Me.ktGrid.TabClickEnabled = False
        Me.ktGrid.TabIndex = 19
        '
        'gbReferenceSystem
        '
        Me.gbReferenceSystem.Controls.Add(Me.rbTokyo)
        Me.gbReferenceSystem.Controls.Add(Me.rbWorld)
        Me.gbReferenceSystem.Location = New System.Drawing.Point(9, 348)
        Me.gbReferenceSystem.Name = "gbReferenceSystem"
        Me.gbReferenceSystem.Size = New System.Drawing.Size(170, 62)
        Me.gbReferenceSystem.TabIndex = 6
        Me.gbReferenceSystem.TabStop = False
        Me.gbReferenceSystem.Text = "座標の測地系"
        '
        'rbTokyo
        '
        Me.rbTokyo.AutoSize = True
        Me.rbTokyo.Location = New System.Drawing.Point(29, 40)
        Me.rbTokyo.Name = "rbTokyo"
        Me.rbTokyo.Size = New System.Drawing.Size(83, 16)
        Me.rbTokyo.TabIndex = 1
        Me.rbTokyo.TabStop = True
        Me.rbTokyo.Text = "日本測地系"
        Me.rbTokyo.UseVisualStyleBackColor = True
        '
        'rbWorld
        '
        Me.rbWorld.AutoSize = True
        Me.rbWorld.Location = New System.Drawing.Point(29, 18)
        Me.rbWorld.Name = "rbWorld"
        Me.rbWorld.Size = New System.Drawing.Size(83, 16)
        Me.rbWorld.TabIndex = 0
        Me.rbWorld.TabStop = True
        Me.rbWorld.Text = "世界測地系"
        Me.rbWorld.UseVisualStyleBackColor = True
        '
        'gbLayerComment
        '
        Me.gbLayerComment.Controls.Add(Me.txtLayerComment)
        Me.gbLayerComment.Location = New System.Drawing.Point(7, 415)
        Me.gbLayerComment.Margin = New System.Windows.Forms.Padding(2)
        Me.gbLayerComment.Name = "gbLayerComment"
        Me.gbLayerComment.Padding = New System.Windows.Forms.Padding(2)
        Me.gbLayerComment.Size = New System.Drawing.Size(170, 98)
        Me.gbLayerComment.TabIndex = 5
        Me.gbLayerComment.TabStop = False
        Me.gbLayerComment.Text = "レイヤコメント"
        '
        'txtLayerComment
        '
        Me.txtLayerComment.Location = New System.Drawing.Point(5, 17)
        Me.txtLayerComment.Multiline = True
        Me.txtLayerComment.Name = "txtLayerComment"
        Me.txtLayerComment.Size = New System.Drawing.Size(160, 69)
        Me.txtLayerComment.TabIndex = 0
        '
        'gbShape
        '
        Me.gbShape.Controls.Add(Me.cboLayerShape)
        Me.gbShape.Location = New System.Drawing.Point(11, 146)
        Me.gbShape.Name = "gbShape"
        Me.gbShape.Size = New System.Drawing.Size(170, 62)
        Me.gbShape.TabIndex = 2
        Me.gbShape.TabStop = False
        Me.gbShape.Text = "形状"
        '
        'cboLayerShape
        '
        Me.cboLayerShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayerShape.FormattingEnabled = True
        Me.cboLayerShape.Location = New System.Drawing.Point(25, 27)
        Me.cboLayerShape.Margin = New System.Windows.Forms.Padding(2)
        Me.cboLayerShape.Name = "cboLayerShape"
        Me.cboLayerShape.Size = New System.Drawing.Size(121, 20)
        Me.cboLayerShape.TabIndex = 1
        '
        'gbMeshType
        '
        Me.gbMeshType.Controls.Add(Me.cboMesh)
        Me.gbMeshType.Location = New System.Drawing.Point(9, 214)
        Me.gbMeshType.Name = "gbMeshType"
        Me.gbMeshType.Size = New System.Drawing.Size(170, 62)
        Me.gbMeshType.TabIndex = 3
        Me.gbMeshType.TabStop = False
        Me.gbMeshType.Text = "メッシュ"
        '
        'cboMesh
        '
        Me.cboMesh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesh.FormattingEnabled = True
        Me.cboMesh.Location = New System.Drawing.Point(27, 26)
        Me.cboMesh.Margin = New System.Windows.Forms.Padding(2)
        Me.cboMesh.Name = "cboMesh"
        Me.cboMesh.Size = New System.Drawing.Size(121, 20)
        Me.cboMesh.TabIndex = 4
        '
        'gbLayerMapFile
        '
        Me.gbLayerMapFile.Controls.Add(Me.cboLayerMapFile)
        Me.gbLayerMapFile.Location = New System.Drawing.Point(12, 13)
        Me.gbLayerMapFile.Margin = New System.Windows.Forms.Padding(2)
        Me.gbLayerMapFile.Name = "gbLayerMapFile"
        Me.gbLayerMapFile.Padding = New System.Windows.Forms.Padding(2)
        Me.gbLayerMapFile.Size = New System.Drawing.Size(170, 62)
        Me.gbLayerMapFile.TabIndex = 0
        Me.gbLayerMapFile.TabStop = False
        Me.gbLayerMapFile.Text = "レイヤで使用する地図ファイル"
        '
        'cboLayerMapFile
        '
        Me.cboLayerMapFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayerMapFile.FormattingEnabled = True
        Me.cboLayerMapFile.Location = New System.Drawing.Point(20, 26)
        Me.cboLayerMapFile.Margin = New System.Windows.Forms.Padding(2)
        Me.cboLayerMapFile.Name = "cboLayerMapFile"
        Me.cboLayerMapFile.Size = New System.Drawing.Size(132, 20)
        Me.cboLayerMapFile.TabIndex = 0
        '
        'gbDateTime
        '
        Me.gbDateTime.Controls.Add(Me.DateTimePickerLayer)
        Me.gbDateTime.Location = New System.Drawing.Point(7, 281)
        Me.gbDateTime.Margin = New System.Windows.Forms.Padding(2)
        Me.gbDateTime.Name = "gbDateTime"
        Me.gbDateTime.Padding = New System.Windows.Forms.Padding(2)
        Me.gbDateTime.Size = New System.Drawing.Size(170, 62)
        Me.gbDateTime.TabIndex = 4
        Me.gbDateTime.TabStop = False
        Me.gbDateTime.Text = "時期設定"
        '
        'DateTimePickerLayer
        '
        Me.DateTimePickerLayer.CustomFormat = "yyyy/MM/dd"
        Me.DateTimePickerLayer.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerLayer.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DateTimePickerLayer.Location = New System.Drawing.Point(31, 26)
        Me.DateTimePickerLayer.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePickerLayer.Name = "DateTimePickerLayer"
        Me.DateTimePickerLayer.Size = New System.Drawing.Size(119, 19)
        Me.DateTimePickerLayer.TabIndex = 2
        '
        'gbLayerType
        '
        Me.gbLayerType.Controls.Add(Me.cboLayerType)
        Me.gbLayerType.Location = New System.Drawing.Point(11, 79)
        Me.gbLayerType.Margin = New System.Windows.Forms.Padding(2)
        Me.gbLayerType.Name = "gbLayerType"
        Me.gbLayerType.Padding = New System.Windows.Forms.Padding(2)
        Me.gbLayerType.Size = New System.Drawing.Size(170, 62)
        Me.gbLayerType.TabIndex = 1
        Me.gbLayerType.TabStop = False
        Me.gbLayerType.Text = "レイヤの種類"
        '
        'cboLayerType
        '
        Me.cboLayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayerType.FormattingEnabled = True
        Me.cboLayerType.Location = New System.Drawing.Point(14, 25)
        Me.cboLayerType.Margin = New System.Windows.Forms.Padding(2)
        Me.cboLayerType.Name = "cboLayerType"
        Me.cboLayerType.Size = New System.Drawing.Size(132, 20)
        Me.cboLayerType.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(5, 7)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(177, 59)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "レイヤで使用する地図ファイル"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(5, 79)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(177, 135)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "レイヤの種類"
        '
        'lbMapFile
        '
        Me.lbMapFile.AsteriskSelectEnabled = False
        Me.lbMapFile.FormattingEnabled = True
        Me.lbMapFile.ItemHeight = 12
        Me.lbMapFile.Location = New System.Drawing.Point(8, 19)
        Me.lbMapFile.Margin = New System.Windows.Forms.Padding(2)
        Me.lbMapFile.Name = "lbMapFile"
        Me.lbMapFile.Size = New System.Drawing.Size(122, 76)
        Me.lbMapFile.TabIndex = 0
        '
        'lbError
        '
        Me.lbError.AsteriskSelectEnabled = False
        Me.lbError.FormattingEnabled = True
        Me.lbError.ItemHeight = 12
        Me.lbError.Location = New System.Drawing.Point(9, 33)
        Me.lbError.Margin = New System.Windows.Forms.Padding(2)
        Me.lbError.Name = "lbError"
        Me.lbError.Size = New System.Drawing.Size(151, 76)
        Me.lbError.TabIndex = 0
        '
        'ListBoxEx1
        '
        Me.ListBoxEx1.AsteriskSelectEnabled = False
        Me.ListBoxEx1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListBoxEx1.FormattingEnabled = True
        Me.ListBoxEx1.ItemHeight = 12
        Me.ListBoxEx1.Location = New System.Drawing.Point(0, 35)
        Me.ListBoxEx1.Name = "ListBoxEx1"
        Me.ListBoxEx1.Size = New System.Drawing.Size(832, 100)
        Me.ListBoxEx1.TabIndex = 0
        '
        'frmGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 675)
        Me.Controls.Add(Me.SplitContainerOuter)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmGrid"
        Me.Text = "属性データ編集"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainerOuter.Panel1.ResumeLayout(False)
        Me.SplitContainerOuter.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerOuter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerOuter.ResumeLayout(False)
        Me.SplitContainerUpper.Panel1.ResumeLayout(False)
        Me.SplitContainerUpper.Panel2.ResumeLayout(False)
        Me.SplitContainerUpper.Panel2.PerformLayout()
        CType(Me.SplitContainerUpper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerUpper.ResumeLayout(False)
        Me.gbFind.ResumeLayout(False)
        Me.gbMapfile.ResumeLayout(False)
        Me.SplitContainerLayer.Panel1.ResumeLayout(False)
        Me.SplitContainerLayer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerLayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerLayer.ResumeLayout(False)
        Me.gbReferenceSystem.ResumeLayout(False)
        Me.gbReferenceSystem.PerformLayout()
        Me.gbLayerComment.ResumeLayout(False)
        Me.gbLayerComment.PerformLayout()
        Me.gbShape.ResumeLayout(False)
        Me.gbMeshType.ResumeLayout(False)
        Me.gbLayerMapFile.ResumeLayout(False)
        Me.gbDateTime.ResumeLayout(False)
        Me.gbLayerType.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerOuter As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerLayer As System.Windows.Forms.SplitContainer
    Friend WithEvents gbMapfile As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemoveMapFile As System.Windows.Forms.Button
    Friend WithEvents lbMapFile As mandara10.ListBoxEx
    Friend WithEvents btnAddMapfile As System.Windows.Forms.Button
    Friend WithEvents gbDateTime As System.Windows.Forms.GroupBox
    Friend WithEvents gbLayerType As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePickerLayer As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnObjectNameCopy As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cboLayerMapFile As System.Windows.Forms.ComboBox
    Friend WithEvents cboLayerShape As System.Windows.Forms.ComboBox
    Friend WithEvents cboLayerType As System.Windows.Forms.ComboBox
    Friend WithEvents cboMissingValue As System.Windows.Forms.ComboBox
    Friend WithEvents cboAttDataType As System.Windows.Forms.ComboBox
    Friend WithEvents ktGrid As KTGISUserControl.KTGISGrid
    Friend WithEvents cboMesh As System.Windows.Forms.ComboBox
    Friend WithEvents btnReplaceMapFile As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents gbLayerMapFile As System.Windows.Forms.GroupBox
    Friend WithEvents gbShape As System.Windows.Forms.GroupBox
    Friend WithEvents gbMeshType As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainerUpper As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbError As mandara10.ListBoxEx
    Friend WithEvents ListBoxEx1 As mandara10.ListBoxEx
    Friend WithEvents gbFind As System.Windows.Forms.GroupBox
    Friend WithEvents btnBefore As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnAddDefAttr As System.Windows.Forms.Button
    Friend WithEvents gbLayerComment As System.Windows.Forms.GroupBox
    Friend WithEvents txtLayerComment As System.Windows.Forms.TextBox
    Friend WithEvents btnGPX As System.Windows.Forms.Button
    Friend WithEvents gbReferenceSystem As System.Windows.Forms.GroupBox
    Friend WithEvents rbTokyo As System.Windows.Forms.RadioButton
    Friend WithEvents rbWorld As System.Windows.Forms.RadioButton
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    'Friend WithEvents lbErrord As mandara10.ListBoxEx
End Class
