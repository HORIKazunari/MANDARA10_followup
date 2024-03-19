<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_LabelModeSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain_LabelModeSettings))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboLabelDataSet = New mandara10.ComboBoxEx()
        Me.btnDeleteDataSet = New System.Windows.Forms.Button()
        Me.lblDataSetTitle = New System.Windows.Forms.Label()
        Me.txtDataSetTitle = New System.Windows.Forms.TextBox()
        Me.btnAddDataSet = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnObjectNameFont = New System.Windows.Forms.Button()
        Me.cbObjectNameMaxWidthReturn = New System.Windows.Forms.CheckBox()
        Me.cbObjectName = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ListBox = New System.Windows.Forms.ListBox()
        Me.btnDataItemFont = New System.Windows.Forms.Button()
        Me.cbDataUnit = New System.Windows.Forms.CheckBox()
        Me.cbDataItemMaxWidthReturn = New System.Windows.Forms.CheckBox()
        Me.cbDataTitle = New System.Windows.Forms.CheckBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnDataDownward = New System.Windows.Forms.Button()
        Me.btnDataUpward = New System.Windows.Forms.Button()
        Me.btnAddRange = New System.Windows.Forms.Button()
        Me.btnAllClear = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picDataItemBack = New System.Windows.Forms.PictureBox()
        Me.picObjectNameBack = New System.Windows.Forms.PictureBox()
        Me.picBorderLinePattern = New System.Windows.Forms.PictureBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnMarkSetting = New System.Windows.Forms.Button()
        Me.cbMark = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtMaxWidth = New mandara10.TextNumberBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cbObjectName1 = New System.Windows.Forms.CheckBox()
        Me.btnDummyObjectGroup = New System.Windows.Forms.Button()
        Me.btnDummyObject = New System.Windows.Forms.Button()
        Me.cbDummyObjectGroupName = New System.Windows.Forms.CheckBox()
        Me.cbDummyObjectName = New System.Windows.Forms.CheckBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.picDataItemBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picObjectNameBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBorderLinePattern, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboLabelDataSet)
        Me.GroupBox2.Controls.Add(Me.btnDeleteDataSet)
        Me.GroupBox2.Controls.Add(Me.lblDataSetTitle)
        Me.GroupBox2.Controls.Add(Me.txtDataSetTitle)
        Me.GroupBox2.Controls.Add(Me.btnAddDataSet)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 21)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(499, 96)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ラベルデータセット"
        '
        'cboLabelDataSet
        '
        Me.cboLabelDataSet.AsteriskSelectEnabled = False
        Me.cboLabelDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLabelDataSet.FormattingEnabled = True
        Me.cboLabelDataSet.IntegralHeight = False
        Me.cboLabelDataSet.Location = New System.Drawing.Point(27, 26)
        Me.cboLabelDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.cboLabelDataSet.Name = "cboLabelDataSet"
        Me.cboLabelDataSet.Size = New System.Drawing.Size(220, 20)
        Me.cboLabelDataSet.TabIndex = 0
        '
        'btnDeleteDataSet
        '
        Me.btnDeleteDataSet.Location = New System.Drawing.Point(376, 26)
        Me.btnDeleteDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteDataSet.Name = "btnDeleteDataSet"
        Me.btnDeleteDataSet.Size = New System.Drawing.Size(105, 22)
        Me.btnDeleteDataSet.TabIndex = 2
        Me.btnDeleteDataSet.Text = "データセット削除"
        Me.btnDeleteDataSet.UseVisualStyleBackColor = True
        '
        'lblDataSetTitle
        '
        Me.lblDataSetTitle.AutoSize = True
        Me.lblDataSetTitle.Location = New System.Drawing.Point(24, 67)
        Me.lblDataSetTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDataSetTitle.Name = "lblDataSetTitle"
        Me.lblDataSetTitle.Size = New System.Drawing.Size(40, 12)
        Me.lblDataSetTitle.TabIndex = 4
        Me.lblDataSetTitle.Text = "タイトル"
        '
        'txtDataSetTitle
        '
        Me.txtDataSetTitle.Location = New System.Drawing.Point(76, 64)
        Me.txtDataSetTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDataSetTitle.Name = "txtDataSetTitle"
        Me.txtDataSetTitle.Size = New System.Drawing.Size(247, 19)
        Me.txtDataSetTitle.TabIndex = 3
        '
        'btnAddDataSet
        '
        Me.btnAddDataSet.Location = New System.Drawing.Point(266, 26)
        Me.btnAddDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddDataSet.Name = "btnAddDataSet"
        Me.btnAddDataSet.Size = New System.Drawing.Size(105, 22)
        Me.btnAddDataSet.TabIndex = 1
        Me.btnAddDataSet.Text = "データセット追加"
        Me.btnAddDataSet.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnObjectNameFont)
        Me.GroupBox1.Controls.Add(Me.cbObjectNameMaxWidthReturn)
        Me.GroupBox1.Controls.Add(Me.cbObjectName)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 133)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(351, 57)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "オブジェクト名"
        '
        'btnObjectNameFont
        '
        Me.btnObjectNameFont.Location = New System.Drawing.Point(279, 20)
        Me.btnObjectNameFont.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjectNameFont.Name = "btnObjectNameFont"
        Me.btnObjectNameFont.Size = New System.Drawing.Size(58, 24)
        Me.btnObjectNameFont.TabIndex = 2
        Me.btnObjectNameFont.Text = "フォント"
        Me.btnObjectNameFont.UseVisualStyleBackColor = True
        '
        'cbObjectNameMaxWidthReturn
        '
        Me.cbObjectNameMaxWidthReturn.Location = New System.Drawing.Point(161, 16)
        Me.cbObjectNameMaxWidthReturn.Margin = New System.Windows.Forms.Padding(2)
        Me.cbObjectNameMaxWidthReturn.Name = "cbObjectNameMaxWidthReturn"
        Me.cbObjectNameMaxWidthReturn.Size = New System.Drawing.Size(104, 34)
        Me.cbObjectNameMaxWidthReturn.TabIndex = 1
        Me.cbObjectNameMaxWidthReturn.Text = "最大幅をこえたら折り返す"
        Me.cbObjectNameMaxWidthReturn.UseVisualStyleBackColor = True
        '
        'cbObjectName
        '
        Me.cbObjectName.AutoSize = True
        Me.cbObjectName.Location = New System.Drawing.Point(16, 26)
        Me.cbObjectName.Margin = New System.Windows.Forms.Padding(2)
        Me.cbObjectName.Name = "cbObjectName"
        Me.cbObjectName.Size = New System.Drawing.Size(121, 16)
        Me.cbObjectName.TabIndex = 0
        Me.cbObjectName.Text = "オブジェクト名の表示"
        Me.cbObjectName.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ListBox)
        Me.GroupBox3.Controls.Add(Me.btnDataItemFont)
        Me.GroupBox3.Controls.Add(Me.cbDataUnit)
        Me.GroupBox3.Controls.Add(Me.cbDataItemMaxWidthReturn)
        Me.GroupBox3.Controls.Add(Me.cbDataTitle)
        Me.GroupBox3.Controls.Add(Me.btnDelete)
        Me.GroupBox3.Controls.Add(Me.btnDataDownward)
        Me.GroupBox3.Controls.Add(Me.btnDataUpward)
        Me.GroupBox3.Controls.Add(Me.btnAddRange)
        Me.GroupBox3.Controls.Add(Me.btnAllClear)
        Me.GroupBox3.Controls.Add(Me.btnAdd)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 201)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(351, 174)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "データ項目"
        '
        'ListBox
        '
        Me.ListBox.FormattingEnabled = True
        Me.ListBox.ItemHeight = 12
        Me.ListBox.Location = New System.Drawing.Point(14, 20)
        Me.ListBox.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox.Name = "ListBox"
        Me.ListBox.Size = New System.Drawing.Size(244, 64)
        Me.ListBox.TabIndex = 0
        '
        'btnDataItemFont
        '
        Me.btnDataItemFont.Location = New System.Drawing.Point(279, 136)
        Me.btnDataItemFont.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDataItemFont.Name = "btnDataItemFont"
        Me.btnDataItemFont.Size = New System.Drawing.Size(58, 24)
        Me.btnDataItemFont.TabIndex = 10
        Me.btnDataItemFont.Text = "フォント"
        Me.btnDataItemFont.UseVisualStyleBackColor = True
        '
        'cbDataUnit
        '
        Me.cbDataUnit.AutoSize = True
        Me.cbDataUnit.Location = New System.Drawing.Point(12, 150)
        Me.cbDataUnit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDataUnit.Name = "cbDataUnit"
        Me.cbDataUnit.Size = New System.Drawing.Size(82, 16)
        Me.cbDataUnit.TabIndex = 8
        Me.cbDataUnit.Text = "単位の表示"
        Me.cbDataUnit.UseVisualStyleBackColor = True
        '
        'cbDataItemMaxWidthReturn
        '
        Me.cbDataItemMaxWidthReturn.Location = New System.Drawing.Point(161, 132)
        Me.cbDataItemMaxWidthReturn.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDataItemMaxWidthReturn.Name = "cbDataItemMaxWidthReturn"
        Me.cbDataItemMaxWidthReturn.Size = New System.Drawing.Size(104, 34)
        Me.cbDataItemMaxWidthReturn.TabIndex = 9
        Me.cbDataItemMaxWidthReturn.Text = "最大幅をこえたら折り返す"
        Me.cbDataItemMaxWidthReturn.UseVisualStyleBackColor = True
        '
        'cbDataTitle
        '
        Me.cbDataTitle.AutoSize = True
        Me.cbDataTitle.Location = New System.Drawing.Point(12, 132)
        Me.cbDataTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDataTitle.Name = "cbDataTitle"
        Me.cbDataTitle.Size = New System.Drawing.Size(122, 16)
        Me.cbDataTitle.TabIndex = 7
        Me.cbDataTitle.Text = "データ項目名の表示"
        Me.cbDataTitle.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(182, 93)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(77, 22)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnDataDownward
        '
        Me.btnDataDownward.Image = CType(resources.GetObject("btnDataDownward.Image"), System.Drawing.Image)
        Me.btnDataDownward.Location = New System.Drawing.Point(268, 56)
        Me.btnDataDownward.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDataDownward.Name = "btnDataDownward"
        Me.btnDataDownward.Size = New System.Drawing.Size(28, 26)
        Me.btnDataDownward.TabIndex = 2
        Me.btnDataDownward.UseVisualStyleBackColor = True
        '
        'btnDataUpward
        '
        Me.btnDataUpward.Image = CType(resources.GetObject("btnDataUpward.Image"), System.Drawing.Image)
        Me.btnDataUpward.Location = New System.Drawing.Point(268, 27)
        Me.btnDataUpward.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDataUpward.Name = "btnDataUpward"
        Me.btnDataUpward.Size = New System.Drawing.Size(28, 26)
        Me.btnDataUpward.TabIndex = 1
        Me.btnDataUpward.UseVisualStyleBackColor = True
        '
        'btnAddRange
        '
        Me.btnAddRange.Location = New System.Drawing.Point(92, 94)
        Me.btnAddRange.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddRange.Name = "btnAddRange"
        Me.btnAddRange.Size = New System.Drawing.Size(85, 22)
        Me.btnAddRange.TabIndex = 4
        Me.btnAddRange.Text = "まとめて追加"
        Me.btnAddRange.UseVisualStyleBackColor = True
        '
        'btnAllClear
        '
        Me.btnAllClear.Location = New System.Drawing.Point(266, 93)
        Me.btnAllClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAllClear.Name = "btnAllClear"
        Me.btnAllClear.Size = New System.Drawing.Size(77, 22)
        Me.btnAllClear.TabIndex = 6
        Me.btnAllClear.Text = "すべて削除"
        Me.btnAllClear.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 94)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 22)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.picDataItemBack)
        Me.GroupBox4.Controls.Add(Me.picObjectNameBack)
        Me.GroupBox4.Controls.Add(Me.picBorderLinePattern)
        Me.GroupBox4.Location = New System.Drawing.Point(374, 301)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(135, 118)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "枠"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 85)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 26)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "データ項目背景"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 47)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 26)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "オブジェクト名背景"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "線種"
        '
        'picDataItemBack
        '
        Me.picDataItemBack.BackColor = System.Drawing.Color.White
        Me.picDataItemBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picDataItemBack.Location = New System.Drawing.Point(79, 85)
        Me.picDataItemBack.Margin = New System.Windows.Forms.Padding(2)
        Me.picDataItemBack.Name = "picDataItemBack"
        Me.picDataItemBack.Size = New System.Drawing.Size(51, 22)
        Me.picDataItemBack.TabIndex = 38
        Me.picDataItemBack.TabStop = False
        '
        'picObjectNameBack
        '
        Me.picObjectNameBack.BackColor = System.Drawing.Color.White
        Me.picObjectNameBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picObjectNameBack.Location = New System.Drawing.Point(79, 47)
        Me.picObjectNameBack.Margin = New System.Windows.Forms.Padding(2)
        Me.picObjectNameBack.Name = "picObjectNameBack"
        Me.picObjectNameBack.Size = New System.Drawing.Size(51, 22)
        Me.picObjectNameBack.TabIndex = 37
        Me.picObjectNameBack.TabStop = False
        '
        'picBorderLinePattern
        '
        Me.picBorderLinePattern.BackColor = System.Drawing.Color.White
        Me.picBorderLinePattern.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picBorderLinePattern.Location = New System.Drawing.Point(79, 15)
        Me.picBorderLinePattern.Margin = New System.Windows.Forms.Padding(2)
        Me.picBorderLinePattern.Name = "picBorderLinePattern"
        Me.picBorderLinePattern.Size = New System.Drawing.Size(51, 22)
        Me.picBorderLinePattern.TabIndex = 36
        Me.picBorderLinePattern.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnMarkSetting)
        Me.GroupBox5.Controls.Add(Me.cbMark)
        Me.GroupBox5.Location = New System.Drawing.Point(374, 201)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Size = New System.Drawing.Size(135, 88)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "表示位置の記号"
        '
        'btnMarkSetting
        '
        Me.btnMarkSetting.Location = New System.Drawing.Point(34, 55)
        Me.btnMarkSetting.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMarkSetting.Name = "btnMarkSetting"
        Me.btnMarkSetting.Size = New System.Drawing.Size(82, 24)
        Me.btnMarkSetting.TabIndex = 1
        Me.btnMarkSetting.Text = "記号設定"
        Me.btnMarkSetting.UseVisualStyleBackColor = True
        '
        'cbMark
        '
        Me.cbMark.Location = New System.Drawing.Point(12, 22)
        Me.cbMark.Margin = New System.Windows.Forms.Padding(2)
        Me.cbMark.Name = "cbMark"
        Me.cbMark.Size = New System.Drawing.Size(118, 29)
        Me.cbMark.TabIndex = 0
        Me.cbMark.Text = "表示位置に記号を表示"
        Me.cbMark.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtMaxWidth)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Location = New System.Drawing.Point(374, 133)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox6.Size = New System.Drawing.Size(135, 57)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "最大幅"
        '
        'txtMaxWidth
        '
        Me.txtMaxWidth.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMaxWidth.Location = New System.Drawing.Point(34, 28)
        Me.txtMaxWidth.MaxValue = 0.0R
        Me.txtMaxWidth.MaxValueFlag = False
        Me.txtMaxWidth.MinValue = 0.0R
        Me.txtMaxWidth.MinValueFlag = True
        Me.txtMaxWidth.Name = "txtMaxWidth"
        Me.txtMaxWidth.NumberPoint = True
        Me.txtMaxWidth.Size = New System.Drawing.Size(51, 19)
        Me.txtMaxWidth.TabIndex = 0
        Me.txtMaxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaxWidth.ValueErrorMessageFlag = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(89, 31)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 12)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "%"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cbObjectName1)
        Me.GroupBox7.Controls.Add(Me.btnDummyObjectGroup)
        Me.GroupBox7.Controls.Add(Me.btnDummyObject)
        Me.GroupBox7.Controls.Add(Me.cbDummyObjectGroupName)
        Me.GroupBox7.Controls.Add(Me.cbDummyObjectName)
        Me.GroupBox7.Location = New System.Drawing.Point(10, 388)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox7.Size = New System.Drawing.Size(351, 102)
        Me.GroupBox7.TabIndex = 3
        Me.GroupBox7.TabStop = False
        '
        'cbObjectName1
        '
        Me.cbObjectName1.AutoSize = True
        Me.cbObjectName1.Location = New System.Drawing.Point(35, 73)
        Me.cbObjectName1.Margin = New System.Windows.Forms.Padding(2)
        Me.cbObjectName1.Name = "cbObjectName1"
        Me.cbObjectName1.Size = New System.Drawing.Size(126, 16)
        Me.cbObjectName1.TabIndex = 2
        Me.cbObjectName1.Text = "オブジェクト名1を優先"
        Me.cbObjectName1.UseVisualStyleBackColor = True
        '
        'btnDummyObjectGroup
        '
        Me.btnDummyObjectGroup.Location = New System.Drawing.Point(279, 48)
        Me.btnDummyObjectGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDummyObjectGroup.Name = "btnDummyObjectGroup"
        Me.btnDummyObjectGroup.Size = New System.Drawing.Size(58, 24)
        Me.btnDummyObjectGroup.TabIndex = 4
        Me.btnDummyObjectGroup.Text = "フォント"
        Me.btnDummyObjectGroup.UseVisualStyleBackColor = True
        '
        'btnDummyObject
        '
        Me.btnDummyObject.Location = New System.Drawing.Point(279, 20)
        Me.btnDummyObject.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDummyObject.Name = "btnDummyObject"
        Me.btnDummyObject.Size = New System.Drawing.Size(58, 24)
        Me.btnDummyObject.TabIndex = 3
        Me.btnDummyObject.Text = "フォント"
        Me.btnDummyObject.UseVisualStyleBackColor = True
        '
        'cbDummyObjectGroupName
        '
        Me.cbDummyObjectGroupName.AutoSize = True
        Me.cbDummyObjectGroupName.Location = New System.Drawing.Point(10, 53)
        Me.cbDummyObjectGroupName.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDummyObjectGroupName.Name = "cbDummyObjectGroupName"
        Me.cbDummyObjectGroupName.Size = New System.Drawing.Size(212, 16)
        Me.cbDummyObjectGroupName.TabIndex = 1
        Me.cbDummyObjectGroupName.Text = "ダミーオブジェクトグループのオブジェクト名"
        Me.cbDummyObjectGroupName.UseVisualStyleBackColor = True
        '
        'cbDummyObjectName
        '
        Me.cbDummyObjectName.AutoSize = True
        Me.cbDummyObjectName.Location = New System.Drawing.Point(10, 20)
        Me.cbDummyObjectName.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDummyObjectName.Name = "cbDummyObjectName"
        Me.cbDummyObjectName.Size = New System.Drawing.Size(174, 16)
        Me.cbDummyObjectName.TabIndex = 0
        Me.cbDummyObjectName.Text = "ダミーオブジェクトのオブジェクト名"
        Me.cbDummyObjectName.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(475, 2)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(35, 21)
        Me.btnHelp.TabIndex = 7
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmMain_LabelModeSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(521, 497)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.HelpButton = True
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "frmMain_LabelModeSettings"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ラベル表示モード"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.picDataItemBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picObjectNameBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBorderLinePattern, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLabelDataSet As mandara10.ComboBoxEx
    Friend WithEvents btnDeleteDataSet As System.Windows.Forms.Button
    Friend WithEvents lblDataSetTitle As System.Windows.Forms.Label
    Friend WithEvents txtDataSetTitle As System.Windows.Forms.TextBox
    Friend WithEvents btnAddDataSet As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnObjectNameFont As System.Windows.Forms.Button
    Friend WithEvents cbObjectNameMaxWidthReturn As System.Windows.Forms.CheckBox
    Friend WithEvents cbObjectName As System.Windows.Forms.CheckBox
    Friend WithEvents btnDataItemFont As System.Windows.Forms.Button
    Friend WithEvents cbDataUnit As System.Windows.Forms.CheckBox
    Friend WithEvents cbDataItemMaxWidthReturn As System.Windows.Forms.CheckBox
    Friend WithEvents cbDataTitle As System.Windows.Forms.CheckBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnDataDownward As System.Windows.Forms.Button
    Friend WithEvents btnDataUpward As System.Windows.Forms.Button
    Friend WithEvents btnAddRange As System.Windows.Forms.Button
    Friend WithEvents btnAllClear As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnMarkSetting As System.Windows.Forms.Button
    Friend WithEvents cbMark As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents picDataItemBack As System.Windows.Forms.PictureBox
    Friend WithEvents picObjectNameBack As System.Windows.Forms.PictureBox
    Friend WithEvents picBorderLinePattern As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cbObjectName1 As System.Windows.Forms.CheckBox
    Friend WithEvents btnDummyObjectGroup As System.Windows.Forms.Button
    Friend WithEvents btnDummyObject As System.Windows.Forms.Button
    Friend WithEvents cbDummyObjectGroupName As System.Windows.Forms.CheckBox
    Friend WithEvents cbDummyObjectName As System.Windows.Forms.CheckBox
    Friend WithEvents ListBox As System.Windows.Forms.ListBox
    Friend WithEvents txtMaxWidth As mandara10.TextNumberBox
    Friend WithEvents btnHelp As System.Windows.Forms.Button
End Class
