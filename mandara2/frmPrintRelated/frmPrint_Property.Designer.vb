<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_Property
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.pnlMultiObjectSelect = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkShowAllData = New System.Windows.Forms.CheckBox()
        Me.btnMultiObjOpe = New System.Windows.Forms.Button()
        Me.btnEndMultiObject = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.ktGridMultiObj = New KTGISUserControl.KTGISGrid()
        Me.gbSelectMode = New System.Windows.Forms.GroupBox()
        Me.btnMultiObjectClear = New System.Windows.Forms.Button()
        Me.btnOtherSelectMethos = New System.Windows.Forms.Button()
        Me.rbMultiObjectSelectMode_Polygon = New System.Windows.Forms.RadioButton()
        Me.rbMultiObjectSelectMode_Circle = New System.Windows.Forms.RadioButton()
        Me.rbMultiObjectSelectMode_Rectangle = New System.Windows.Forms.RadioButton()
        Me.rbMultiObjectSelectMode_Pointing = New System.Windows.Forms.RadioButton()
        Me.pnlProperty = New System.Windows.Forms.Panel()
        Me.ktGridValue = New KTGISUserControl.KTGISGrid()
        Me.lblSoloModeValue = New System.Windows.Forms.Label()
        Me.lblObjName = New System.Windows.Forms.Label()
        Me.pnlOverLayProperty = New System.Windows.Forms.Panel()
        Me.txtOverLayProperty = New System.Windows.Forms.TextBox()
        Me.btnCopy = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlMultiObjectSelect.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbSelectMode.SuspendLayout()
        Me.pnlProperty.SuspendLayout()
        Me.pnlOverLayProperty.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlMultiObjectSelect)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlProperty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlOverLayProperty)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCopy)
        Me.SplitContainer1.Size = New System.Drawing.Size(375, 472)
        Me.SplitContainer1.SplitterDistance = 446
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 4
        '
        'pnlMultiObjectSelect
        '
        Me.pnlMultiObjectSelect.Controls.Add(Me.GroupBox1)
        Me.pnlMultiObjectSelect.Controls.Add(Me.btnHelp)
        Me.pnlMultiObjectSelect.Controls.Add(Me.ktGridMultiObj)
        Me.pnlMultiObjectSelect.Controls.Add(Me.gbSelectMode)
        Me.pnlMultiObjectSelect.Location = New System.Drawing.Point(123, 43)
        Me.pnlMultiObjectSelect.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlMultiObjectSelect.Name = "pnlMultiObjectSelect"
        Me.pnlMultiObjectSelect.Size = New System.Drawing.Size(241, 386)
        Me.pnlMultiObjectSelect.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkShowAllData)
        Me.GroupBox1.Controls.Add(Me.btnMultiObjOpe)
        Me.GroupBox1.Controls.Add(Me.btnEndMultiObject)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 71)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "操作"
        '
        'chkShowAllData
        '
        Me.chkShowAllData.AutoSize = True
        Me.chkShowAllData.Location = New System.Drawing.Point(14, 48)
        Me.chkShowAllData.Name = "chkShowAllData"
        Me.chkShowAllData.Size = New System.Drawing.Size(121, 16)
        Me.chkShowAllData.TabIndex = 23
        Me.chkShowAllData.Text = "全データ項目を表示"
        Me.chkShowAllData.UseVisualStyleBackColor = True
        '
        'btnMultiObjOpe
        '
        Me.btnMultiObjOpe.Location = New System.Drawing.Point(14, 16)
        Me.btnMultiObjOpe.Name = "btnMultiObjOpe"
        Me.btnMultiObjOpe.Size = New System.Drawing.Size(85, 22)
        Me.btnMultiObjOpe.TabIndex = 22
        Me.btnMultiObjOpe.Text = "非表示化"
        Me.btnMultiObjOpe.UseVisualStyleBackColor = True
        '
        'btnEndMultiObject
        '
        Me.btnEndMultiObject.Location = New System.Drawing.Point(105, 16)
        Me.btnEndMultiObject.Name = "btnEndMultiObject"
        Me.btnEndMultiObject.Size = New System.Drawing.Size(84, 22)
        Me.btnEndMultiObject.TabIndex = 21
        Me.btnEndMultiObject.Text = "終了"
        Me.btnEndMultiObject.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(217, 8)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(30, 21)
        Me.btnHelp.TabIndex = 21
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'ktGridMultiObj
        '
        Me.ktGridMultiObj.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ktGridMultiObj.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGridMultiObj.DefaultFixedXNumberingWidth = 50
        Me.ktGridMultiObj.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGridMultiObj.DefaultFixedXWidth = 150
        Me.ktGridMultiObj.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGridMultiObj.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ktGridMultiObj.DefaultGridWidth = 100
        Me.ktGridMultiObj.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ktGridMultiObj.FixedGridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ktGridMultiObj.FrameColor = System.Drawing.SystemColors.Control
        Me.ktGridMultiObj.GridColor = System.Drawing.Color.White
        Me.ktGridMultiObj.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktGridMultiObj.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ktGridMultiObj.Layer = 0
        Me.ktGridMultiObj.LayerCaption = Nothing
        Me.ktGridMultiObj.Location = New System.Drawing.Point(1, 176)
        Me.ktGridMultiObj.Margin = New System.Windows.Forms.Padding(4)
        Me.ktGridMultiObj.MsgBoxTitle = ""
        Me.ktGridMultiObj.Name = "ktGridMultiObj"
        Me.ktGridMultiObj.RowCaption = Nothing
        Me.ktGridMultiObj.Size = New System.Drawing.Size(241, 210)
        Me.ktGridMultiObj.TabClickEnabled = False
        Me.ktGridMultiObj.TabIndex = 15
        '
        'gbSelectMode
        '
        Me.gbSelectMode.Controls.Add(Me.btnMultiObjectClear)
        Me.gbSelectMode.Controls.Add(Me.btnOtherSelectMethos)
        Me.gbSelectMode.Controls.Add(Me.rbMultiObjectSelectMode_Polygon)
        Me.gbSelectMode.Controls.Add(Me.rbMultiObjectSelectMode_Circle)
        Me.gbSelectMode.Controls.Add(Me.rbMultiObjectSelectMode_Rectangle)
        Me.gbSelectMode.Controls.Add(Me.rbMultiObjectSelectMode_Pointing)
        Me.gbSelectMode.Location = New System.Drawing.Point(8, 8)
        Me.gbSelectMode.Name = "gbSelectMode"
        Me.gbSelectMode.Size = New System.Drawing.Size(203, 82)
        Me.gbSelectMode.TabIndex = 16
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
        'pnlProperty
        '
        Me.pnlProperty.Controls.Add(Me.ktGridValue)
        Me.pnlProperty.Controls.Add(Me.lblSoloModeValue)
        Me.pnlProperty.Controls.Add(Me.lblObjName)
        Me.pnlProperty.Location = New System.Drawing.Point(2, 181)
        Me.pnlProperty.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlProperty.Name = "pnlProperty"
        Me.pnlProperty.Size = New System.Drawing.Size(115, 178)
        Me.pnlProperty.TabIndex = 2
        '
        'ktGridValue
        '
        Me.ktGridValue.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGridValue.DefaultFixedXNumberingWidth = 50
        Me.ktGridValue.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGridValue.DefaultFixedXWidth = 150
        Me.ktGridValue.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGridValue.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ktGridValue.DefaultGridWidth = 100
        Me.ktGridValue.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ktGridValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ktGridValue.FixedGridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ktGridValue.FrameColor = System.Drawing.SystemColors.Control
        Me.ktGridValue.GridColor = System.Drawing.Color.White
        Me.ktGridValue.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktGridValue.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ktGridValue.Layer = 0
        Me.ktGridValue.LayerCaption = Nothing
        Me.ktGridValue.Location = New System.Drawing.Point(0, 38)
        Me.ktGridValue.Margin = New System.Windows.Forms.Padding(4)
        Me.ktGridValue.MsgBoxTitle = ""
        Me.ktGridValue.Name = "ktGridValue"
        Me.ktGridValue.RowCaption = Nothing
        Me.ktGridValue.Size = New System.Drawing.Size(115, 140)
        Me.ktGridValue.TabClickEnabled = False
        Me.ktGridValue.TabIndex = 15
        '
        'lblSoloModeValue
        '
        Me.lblSoloModeValue.AutoEllipsis = True
        Me.lblSoloModeValue.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSoloModeValue.Location = New System.Drawing.Point(0, 24)
        Me.lblSoloModeValue.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSoloModeValue.Name = "lblSoloModeValue"
        Me.lblSoloModeValue.Size = New System.Drawing.Size(115, 14)
        Me.lblSoloModeValue.TabIndex = 17
        Me.lblSoloModeValue.Text = "lblSoloModeValue"
        '
        'lblObjName
        '
        Me.lblObjName.BackColor = System.Drawing.SystemColors.Control
        Me.lblObjName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblObjName.Font = New System.Drawing.Font("MS UI Gothic", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblObjName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblObjName.Location = New System.Drawing.Point(0, 0)
        Me.lblObjName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblObjName.Name = "lblObjName"
        Me.lblObjName.Size = New System.Drawing.Size(115, 24)
        Me.lblObjName.TabIndex = 16
        Me.lblObjName.Text = "オブジェクト名"
        Me.lblObjName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlOverLayProperty
        '
        Me.pnlOverLayProperty.Controls.Add(Me.txtOverLayProperty)
        Me.pnlOverLayProperty.Location = New System.Drawing.Point(2, 4)
        Me.pnlOverLayProperty.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlOverLayProperty.Name = "pnlOverLayProperty"
        Me.pnlOverLayProperty.Size = New System.Drawing.Size(113, 175)
        Me.pnlOverLayProperty.TabIndex = 4
        '
        'txtOverLayProperty
        '
        Me.txtOverLayProperty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOverLayProperty.Location = New System.Drawing.Point(0, 0)
        Me.txtOverLayProperty.Margin = New System.Windows.Forms.Padding(2)
        Me.txtOverLayProperty.Multiline = True
        Me.txtOverLayProperty.Name = "txtOverLayProperty"
        Me.txtOverLayProperty.Size = New System.Drawing.Size(113, 175)
        Me.txtOverLayProperty.TabIndex = 0
        '
        'btnCopy
        '
        Me.btnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopy.Location = New System.Drawing.Point(314, 3)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(51, 19)
        Me.btnCopy.TabIndex = 0
        Me.btnCopy.Text = "コピー"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'frmPrint_Property
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 472)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_Property"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "プロパティ"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlMultiObjectSelect.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbSelectMode.ResumeLayout(False)
        Me.gbSelectMode.PerformLayout()
        Me.pnlProperty.ResumeLayout(False)
        Me.pnlOverLayProperty.ResumeLayout(False)
        Me.pnlOverLayProperty.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlOverLayProperty As System.Windows.Forms.Panel
    Friend WithEvents txtOverLayProperty As System.Windows.Forms.TextBox
    Friend WithEvents pnlProperty As System.Windows.Forms.Panel
    Friend WithEvents ktGridValue As KTGISUserControl.KTGISGrid
    Friend WithEvents lblSoloModeValue As System.Windows.Forms.Label
    Friend WithEvents lblObjName As System.Windows.Forms.Label
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents pnlMultiObjectSelect As System.Windows.Forms.Panel
    Friend WithEvents ktGridMultiObj As KTGISUserControl.KTGISGrid
    Friend WithEvents gbSelectMode As System.Windows.Forms.GroupBox
    Friend WithEvents btnMultiObjectClear As System.Windows.Forms.Button
    Friend WithEvents btnOtherSelectMethos As System.Windows.Forms.Button
    Friend WithEvents rbMultiObjectSelectMode_Polygon As System.Windows.Forms.RadioButton
    Friend WithEvents rbMultiObjectSelectMode_Circle As System.Windows.Forms.RadioButton
    Friend WithEvents rbMultiObjectSelectMode_Rectangle As System.Windows.Forms.RadioButton
    Friend WithEvents rbMultiObjectSelectMode_Pointing As System.Windows.Forms.RadioButton
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowAllData As System.Windows.Forms.CheckBox
    Friend WithEvents btnMultiObjOpe As System.Windows.Forms.Button
    Friend WithEvents btnEndMultiObject As System.Windows.Forms.Button
End Class
