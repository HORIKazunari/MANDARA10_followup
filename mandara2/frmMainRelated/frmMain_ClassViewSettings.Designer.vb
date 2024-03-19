<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_ClassViewSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain_ClassViewSettings))
        Me.gbDivNum = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlClassDivBase = New System.Windows.Forms.Panel()
        Me.pnlClassDiv = New System.Windows.Forms.Panel()
        Me.picCategrySelector = New System.Windows.Forms.PictureBox()
        Me.gbClassPaint = New System.Windows.Forms.GroupBox()
        Me.btnTransparency = New System.Windows.Forms.Button()
        Me.btnReverseColor = New System.Windows.Forms.Button()
        Me.btColorPattern = New System.Windows.Forms.Button()
        Me.rbSoloColor = New System.Windows.Forms.RadioButton()
        Me.rbMultiColor = New System.Windows.Forms.RadioButton()
        Me.rbThreeColor = New System.Windows.Forms.RadioButton()
        Me.rbTwoColor = New System.Windows.Forms.RadioButton()
        Me.pnlClassPaint = New System.Windows.Forms.Panel()
        Me.gbLineObjectSize = New System.Windows.Forms.GroupBox()
        Me.btnLineShapeEdgePattern = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLineObjectSize = New System.Windows.Forms.TextBox()
        Me.gbPointShapeMark = New System.Windows.Forms.GroupBox()
        Me.picPointShapeMark = New System.Windows.Forms.PictureBox()
        Me.pnlClassHatch = New System.Windows.Forms.Panel()
        Me.btnHatchSetting = New System.Windows.Forms.Button()
        Me.pnlClassMark = New System.Windows.Forms.Panel()
        Me.btnClassMarkSettings = New System.Windows.Forms.Button()
        Me.pnlClassOD = New System.Windows.Forms.Panel()
        Me.gbOriginObject = New System.Windows.Forms.GroupBox()
        Me.lblOriginObject = New System.Windows.Forms.Label()
        Me.btnOriginObject = New System.Windows.Forms.Button()
        Me.btnClassOD = New System.Windows.Forms.Button()
        Me.pnlCategoryUpDown = New System.Windows.Forms.Panel()
        Me.btnCategoryDown = New System.Windows.Forms.Button()
        Me.btnCategoryUp = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCategorize_Arrange = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboDivisionCount = New mandara10.ComboBoxEx()
        Me.cboDivisionMethod = New mandara10.ComboBoxEx()
        Me.gbDivNum.SuspendLayout()
        Me.pnlClassDivBase.SuspendLayout()
        Me.pnlClassDiv.SuspendLayout()
        CType(Me.picCategrySelector, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbClassPaint.SuspendLayout()
        Me.pnlClassPaint.SuspendLayout()
        Me.gbLineObjectSize.SuspendLayout()
        Me.gbPointShapeMark.SuspendLayout()
        CType(Me.picPointShapeMark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlClassHatch.SuspendLayout()
        Me.pnlClassMark.SuspendLayout()
        Me.pnlClassOD.SuspendLayout()
        Me.gbOriginObject.SuspendLayout()
        Me.pnlCategoryUpDown.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDivNum
        '
        Me.gbDivNum.Controls.Add(Me.cboDivisionCount)
        Me.gbDivNum.Controls.Add(Me.cboDivisionMethod)
        Me.gbDivNum.Controls.Add(Me.Label2)
        Me.gbDivNum.Controls.Add(Me.Label1)
        Me.gbDivNum.Location = New System.Drawing.Point(19, 20)
        Me.gbDivNum.Name = "gbDivNum"
        Me.gbDivNum.Size = New System.Drawing.Size(145, 110)
        Me.gbDivNum.TabIndex = 0
        Me.gbDivNum.TabStop = False
        Me.gbDivNum.Text = "階級区分方法"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "分割数"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "区分方法"
        '
        'pnlClassDivBase
        '
        Me.pnlClassDivBase.AutoScroll = True
        Me.pnlClassDivBase.Controls.Add(Me.pnlClassDiv)
        Me.pnlClassDivBase.Location = New System.Drawing.Point(169, 24)
        Me.pnlClassDivBase.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlClassDivBase.Name = "pnlClassDivBase"
        Me.pnlClassDivBase.Size = New System.Drawing.Size(265, 348)
        Me.pnlClassDivBase.TabIndex = 3
        '
        'pnlClassDiv
        '
        Me.pnlClassDiv.BackColor = System.Drawing.Color.Transparent
        Me.pnlClassDiv.Controls.Add(Me.picCategrySelector)
        Me.pnlClassDiv.Location = New System.Drawing.Point(0, 10)
        Me.pnlClassDiv.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlClassDiv.Name = "pnlClassDiv"
        Me.pnlClassDiv.Size = New System.Drawing.Size(194, 119)
        Me.pnlClassDiv.TabIndex = 0
        '
        'picCategrySelector
        '
        Me.picCategrySelector.BackColor = System.Drawing.Color.Transparent
        Me.picCategrySelector.Location = New System.Drawing.Point(0, 10)
        Me.picCategrySelector.Name = "picCategrySelector"
        Me.picCategrySelector.Size = New System.Drawing.Size(12, 26)
        Me.picCategrySelector.TabIndex = 0
        Me.picCategrySelector.TabStop = False
        '
        'gbClassPaint
        '
        Me.gbClassPaint.Controls.Add(Me.btnTransparency)
        Me.gbClassPaint.Controls.Add(Me.btnReverseColor)
        Me.gbClassPaint.Controls.Add(Me.btColorPattern)
        Me.gbClassPaint.Controls.Add(Me.rbSoloColor)
        Me.gbClassPaint.Controls.Add(Me.rbMultiColor)
        Me.gbClassPaint.Controls.Add(Me.rbThreeColor)
        Me.gbClassPaint.Controls.Add(Me.rbTwoColor)
        Me.gbClassPaint.Location = New System.Drawing.Point(19, 3)
        Me.gbClassPaint.Name = "gbClassPaint"
        Me.gbClassPaint.Size = New System.Drawing.Size(138, 182)
        Me.gbClassPaint.TabIndex = 0
        Me.gbClassPaint.TabStop = False
        Me.gbClassPaint.Text = "色設定方法"
        '
        'btnTransparency
        '
        Me.btnTransparency.Location = New System.Drawing.Point(30, 155)
        Me.btnTransparency.Name = "btnTransparency"
        Me.btnTransparency.Size = New System.Drawing.Size(98, 23)
        Me.btnTransparency.TabIndex = 6
        Me.btnTransparency.Text = "透過度設定"
        Me.btnTransparency.UseVisualStyleBackColor = True
        '
        'btnReverseColor
        '
        Me.btnReverseColor.Location = New System.Drawing.Point(29, 128)
        Me.btnReverseColor.Name = "btnReverseColor"
        Me.btnReverseColor.Size = New System.Drawing.Size(98, 23)
        Me.btnReverseColor.TabIndex = 5
        Me.btnReverseColor.Text = "上下色反転"
        Me.btnReverseColor.UseVisualStyleBackColor = True
        '
        'btColorPattern
        '
        Me.btColorPattern.Location = New System.Drawing.Point(30, 102)
        Me.btColorPattern.Name = "btColorPattern"
        Me.btColorPattern.Size = New System.Drawing.Size(97, 23)
        Me.btColorPattern.TabIndex = 4
        Me.btColorPattern.Text = "カラーチャート"
        Me.btColorPattern.UseVisualStyleBackColor = True
        '
        'rbSoloColor
        '
        Me.rbSoloColor.AutoSize = True
        Me.rbSoloColor.Location = New System.Drawing.Point(7, 86)
        Me.rbSoloColor.Name = "rbSoloColor"
        Me.rbSoloColor.Size = New System.Drawing.Size(71, 16)
        Me.rbSoloColor.TabIndex = 3
        Me.rbSoloColor.TabStop = True
        Me.rbSoloColor.Text = "単独設定"
        Me.rbSoloColor.UseVisualStyleBackColor = True
        '
        'rbMultiColor
        '
        Me.rbMultiColor.AutoSize = True
        Me.rbMultiColor.Location = New System.Drawing.Point(7, 64)
        Me.rbMultiColor.Name = "rbMultiColor"
        Me.rbMultiColor.Size = New System.Drawing.Size(109, 16)
        Me.rbMultiColor.TabIndex = 2
        Me.rbMultiColor.TabStop = True
        Me.rbMultiColor.Text = "複数グラデーション"
        Me.rbMultiColor.UseVisualStyleBackColor = True
        '
        'rbThreeColor
        '
        Me.rbThreeColor.AutoSize = True
        Me.rbThreeColor.Location = New System.Drawing.Point(7, 42)
        Me.rbThreeColor.Name = "rbThreeColor"
        Me.rbThreeColor.Size = New System.Drawing.Size(103, 16)
        Me.rbThreeColor.TabIndex = 1
        Me.rbThreeColor.TabStop = True
        Me.rbThreeColor.Text = "3色グラデーション"
        Me.rbThreeColor.UseVisualStyleBackColor = True
        '
        'rbTwoColor
        '
        Me.rbTwoColor.AutoSize = True
        Me.rbTwoColor.Location = New System.Drawing.Point(7, 20)
        Me.rbTwoColor.Name = "rbTwoColor"
        Me.rbTwoColor.Size = New System.Drawing.Size(103, 16)
        Me.rbTwoColor.TabIndex = 0
        Me.rbTwoColor.TabStop = True
        Me.rbTwoColor.Text = "2色グラデーション"
        Me.rbTwoColor.UseVisualStyleBackColor = True
        '
        'pnlClassPaint
        '
        Me.pnlClassPaint.Controls.Add(Me.gbClassPaint)
        Me.pnlClassPaint.Controls.Add(Me.gbLineObjectSize)
        Me.pnlClassPaint.Controls.Add(Me.gbPointShapeMark)
        Me.pnlClassPaint.Location = New System.Drawing.Point(3, 136)
        Me.pnlClassPaint.Name = "pnlClassPaint"
        Me.pnlClassPaint.Size = New System.Drawing.Size(160, 263)
        Me.pnlClassPaint.TabIndex = 1
        '
        'gbLineObjectSize
        '
        Me.gbLineObjectSize.Controls.Add(Me.btnLineShapeEdgePattern)
        Me.gbLineObjectSize.Controls.Add(Me.Label3)
        Me.gbLineObjectSize.Controls.Add(Me.txtLineObjectSize)
        Me.gbLineObjectSize.Location = New System.Drawing.Point(19, 191)
        Me.gbLineObjectSize.Name = "gbLineObjectSize"
        Me.gbLineObjectSize.Size = New System.Drawing.Size(138, 72)
        Me.gbLineObjectSize.TabIndex = 1
        Me.gbLineObjectSize.TabStop = False
        Me.gbLineObjectSize.Text = "線オブジェクトサイズ"
        '
        'btnLineShapeEdgePattern
        '
        Me.btnLineShapeEdgePattern.Location = New System.Drawing.Point(22, 39)
        Me.btnLineShapeEdgePattern.Name = "btnLineShapeEdgePattern"
        Me.btnLineShapeEdgePattern.Size = New System.Drawing.Size(97, 26)
        Me.btnLineShapeEdgePattern.TabIndex = 2
        Me.btnLineShapeEdgePattern.Text = "線端設定"
        Me.btnLineShapeEdgePattern.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(96, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "%"
        '
        'txtLineObjectSize
        '
        Me.txtLineObjectSize.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLineObjectSize.Location = New System.Drawing.Point(30, 15)
        Me.txtLineObjectSize.Name = "txtLineObjectSize"
        Me.txtLineObjectSize.Size = New System.Drawing.Size(59, 19)
        Me.txtLineObjectSize.TabIndex = 0
        Me.txtLineObjectSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbPointShapeMark
        '
        Me.gbPointShapeMark.Controls.Add(Me.picPointShapeMark)
        Me.gbPointShapeMark.Location = New System.Drawing.Point(19, 192)
        Me.gbPointShapeMark.Name = "gbPointShapeMark"
        Me.gbPointShapeMark.Size = New System.Drawing.Size(138, 66)
        Me.gbPointShapeMark.TabIndex = 2
        Me.gbPointShapeMark.TabStop = False
        Me.gbPointShapeMark.Text = "表示記号設定"
        '
        'picPointShapeMark
        '
        Me.picPointShapeMark.BackColor = System.Drawing.Color.White
        Me.picPointShapeMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPointShapeMark.Location = New System.Drawing.Point(33, 18)
        Me.picPointShapeMark.Name = "picPointShapeMark"
        Me.picPointShapeMark.Size = New System.Drawing.Size(51, 39)
        Me.picPointShapeMark.TabIndex = 0
        Me.picPointShapeMark.TabStop = False
        '
        'pnlClassHatch
        '
        Me.pnlClassHatch.Controls.Add(Me.btnHatchSetting)
        Me.pnlClassHatch.Location = New System.Drawing.Point(440, 77)
        Me.pnlClassHatch.Name = "pnlClassHatch"
        Me.pnlClassHatch.Size = New System.Drawing.Size(145, 127)
        Me.pnlClassHatch.TabIndex = 4
        '
        'btnHatchSetting
        '
        Me.btnHatchSetting.Location = New System.Drawing.Point(21, 26)
        Me.btnHatchSetting.Name = "btnHatchSetting"
        Me.btnHatchSetting.Size = New System.Drawing.Size(99, 31)
        Me.btnHatchSetting.TabIndex = 0
        Me.btnHatchSetting.Text = "ハッチ設定"
        Me.btnHatchSetting.UseVisualStyleBackColor = True
        '
        'pnlClassMark
        '
        Me.pnlClassMark.Controls.Add(Me.btnClassMarkSettings)
        Me.pnlClassMark.Location = New System.Drawing.Point(440, 217)
        Me.pnlClassMark.Name = "pnlClassMark"
        Me.pnlClassMark.Size = New System.Drawing.Size(145, 69)
        Me.pnlClassMark.TabIndex = 5
        '
        'btnClassMarkSettings
        '
        Me.btnClassMarkSettings.Location = New System.Drawing.Point(21, 20)
        Me.btnClassMarkSettings.Name = "btnClassMarkSettings"
        Me.btnClassMarkSettings.Size = New System.Drawing.Size(99, 31)
        Me.btnClassMarkSettings.TabIndex = 0
        Me.btnClassMarkSettings.Text = "記号設定"
        Me.btnClassMarkSettings.UseVisualStyleBackColor = True
        '
        'pnlClassOD
        '
        Me.pnlClassOD.Controls.Add(Me.gbOriginObject)
        Me.pnlClassOD.Controls.Add(Me.btnClassOD)
        Me.pnlClassOD.Location = New System.Drawing.Point(591, 139)
        Me.pnlClassOD.Name = "pnlClassOD"
        Me.pnlClassOD.Size = New System.Drawing.Size(147, 174)
        Me.pnlClassOD.TabIndex = 6
        '
        'gbOriginObject
        '
        Me.gbOriginObject.Controls.Add(Me.lblOriginObject)
        Me.gbOriginObject.Controls.Add(Me.btnOriginObject)
        Me.gbOriginObject.Location = New System.Drawing.Point(3, 47)
        Me.gbOriginObject.Name = "gbOriginObject"
        Me.gbOriginObject.Size = New System.Drawing.Size(136, 119)
        Me.gbOriginObject.TabIndex = 1
        Me.gbOriginObject.TabStop = False
        Me.gbOriginObject.Text = "起点オブジェクト"
        '
        'lblOriginObject
        '
        Me.lblOriginObject.BackColor = System.Drawing.SystemColors.Window
        Me.lblOriginObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOriginObject.Location = New System.Drawing.Point(7, 20)
        Me.lblOriginObject.Name = "lblOriginObject"
        Me.lblOriginObject.Size = New System.Drawing.Size(122, 53)
        Me.lblOriginObject.TabIndex = 0
        Me.lblOriginObject.Text = "Label3"
        '
        'btnOriginObject
        '
        Me.btnOriginObject.Location = New System.Drawing.Point(6, 78)
        Me.btnOriginObject.Name = "btnOriginObject"
        Me.btnOriginObject.Size = New System.Drawing.Size(124, 39)
        Me.btnOriginObject.TabIndex = 1
        Me.btnOriginObject.Text = "起点オブジェクト設定"
        Me.btnOriginObject.UseVisualStyleBackColor = True
        '
        'btnClassOD
        '
        Me.btnClassOD.Location = New System.Drawing.Point(19, 9)
        Me.btnClassOD.Name = "btnClassOD"
        Me.btnClassOD.Size = New System.Drawing.Size(99, 31)
        Me.btnClassOD.TabIndex = 0
        Me.btnClassOD.Text = "線設定"
        Me.btnClassOD.UseVisualStyleBackColor = True
        '
        'pnlCategoryUpDown
        '
        Me.pnlCategoryUpDown.Controls.Add(Me.btnCategoryDown)
        Me.pnlCategoryUpDown.Controls.Add(Me.btnCategoryUp)
        Me.pnlCategoryUpDown.Location = New System.Drawing.Point(3, 38)
        Me.pnlCategoryUpDown.Name = "pnlCategoryUpDown"
        Me.pnlCategoryUpDown.Size = New System.Drawing.Size(35, 78)
        Me.pnlCategoryUpDown.TabIndex = 27
        '
        'btnCategoryDown
        '
        Me.btnCategoryDown.BackgroundImage = CType(resources.GetObject("btnCategoryDown.BackgroundImage"), System.Drawing.Image)
        Me.btnCategoryDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCategoryDown.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnCategoryDown.Location = New System.Drawing.Point(0, 40)
        Me.btnCategoryDown.Name = "btnCategoryDown"
        Me.btnCategoryDown.Size = New System.Drawing.Size(35, 38)
        Me.btnCategoryDown.TabIndex = 1
        Me.btnCategoryDown.UseVisualStyleBackColor = True
        '
        'btnCategoryUp
        '
        Me.btnCategoryUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCategoryUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCategoryUp.Image = CType(resources.GetObject("btnCategoryUp.Image"), System.Drawing.Image)
        Me.btnCategoryUp.Location = New System.Drawing.Point(0, 0)
        Me.btnCategoryUp.Name = "btnCategoryUp"
        Me.btnCategoryUp.Size = New System.Drawing.Size(35, 37)
        Me.btnCategoryUp.TabIndex = 0
        Me.btnCategoryUp.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 1
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ShowAlways = True
        '
        'btnCategorize_Arrange
        '
        Me.btnCategorize_Arrange.Location = New System.Drawing.Point(271, 377)
        Me.btnCategorize_Arrange.Name = "btnCategorize_Arrange"
        Me.btnCategorize_Arrange.Size = New System.Drawing.Size(145, 22)
        Me.btnCategorize_Arrange.TabIndex = 7
        Me.btnCategorize_Arrange.Text = "カテゴリーデータ化"
        Me.btnCategorize_Arrange.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(399, 2)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(35, 21)
        Me.btnHelp.TabIndex = 8
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(183, 378)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 21)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "ユーザ設定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cboDivisionCount
        '
        Me.cboDivisionCount.AsteriskSelectEnabled = False
        Me.cboDivisionCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDivisionCount.FormattingEnabled = True
        Me.cboDivisionCount.IntegralHeight = False
        Me.cboDivisionCount.Location = New System.Drawing.Point(27, 79)
        Me.cboDivisionCount.MaxDropDownItems = 20
        Me.cboDivisionCount.Name = "cboDivisionCount"
        Me.cboDivisionCount.Size = New System.Drawing.Size(96, 20)
        Me.cboDivisionCount.TabIndex = 3
        '
        'cboDivisionMethod
        '
        Me.cboDivisionMethod.AsteriskSelectEnabled = False
        Me.cboDivisionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDivisionMethod.FormattingEnabled = True
        Me.cboDivisionMethod.IntegralHeight = False
        Me.cboDivisionMethod.Location = New System.Drawing.Point(27, 38)
        Me.cboDivisionMethod.Name = "cboDivisionMethod"
        Me.cboDivisionMethod.Size = New System.Drawing.Size(96, 20)
        Me.cboDivisionMethod.TabIndex = 2
        '
        'frmMain_ClassViewSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(765, 406)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnCategorize_Arrange)
        Me.Controls.Add(Me.pnlCategoryUpDown)
        Me.Controls.Add(Me.pnlClassOD)
        Me.Controls.Add(Me.pnlClassMark)
        Me.Controls.Add(Me.pnlClassHatch)
        Me.Controls.Add(Me.pnlClassDivBase)
        Me.Controls.Add(Me.pnlClassPaint)
        Me.Controls.Add(Me.gbDivNum)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_ClassViewSettings"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "階級区分モード"
        Me.gbDivNum.ResumeLayout(False)
        Me.gbDivNum.PerformLayout()
        Me.pnlClassDivBase.ResumeLayout(False)
        Me.pnlClassDiv.ResumeLayout(False)
        CType(Me.picCategrySelector, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbClassPaint.ResumeLayout(False)
        Me.gbClassPaint.PerformLayout()
        Me.pnlClassPaint.ResumeLayout(False)
        Me.gbLineObjectSize.ResumeLayout(False)
        Me.gbLineObjectSize.PerformLayout()
        Me.gbPointShapeMark.ResumeLayout(False)
        CType(Me.picPointShapeMark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlClassHatch.ResumeLayout(False)
        Me.pnlClassMark.ResumeLayout(False)
        Me.pnlClassOD.ResumeLayout(False)
        Me.gbOriginObject.ResumeLayout(False)
        Me.pnlCategoryUpDown.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDivNum As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionCount As mandara10.ComboBoxEx
    Friend WithEvents cboDivisionMethod As mandara10.ComboBoxEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlClassDivBase As System.Windows.Forms.Panel
    Friend WithEvents pnlClassDiv As System.Windows.Forms.Panel
    Friend WithEvents gbClassPaint As System.Windows.Forms.GroupBox
    Friend WithEvents rbSoloColor As System.Windows.Forms.RadioButton
    Friend WithEvents rbMultiColor As System.Windows.Forms.RadioButton
    Friend WithEvents rbThreeColor As System.Windows.Forms.RadioButton
    Friend WithEvents rbTwoColor As System.Windows.Forms.RadioButton
    Friend WithEvents pnlClassPaint As System.Windows.Forms.Panel
    Friend WithEvents pnlClassHatch As System.Windows.Forms.Panel
    Friend WithEvents btnHatchSetting As System.Windows.Forms.Button
    Friend WithEvents pnlClassMark As System.Windows.Forms.Panel
    Friend WithEvents btnClassMarkSettings As System.Windows.Forms.Button
    Friend WithEvents pnlClassOD As System.Windows.Forms.Panel
    Friend WithEvents btnClassOD As System.Windows.Forms.Button
    Friend WithEvents gbOriginObject As System.Windows.Forms.GroupBox
    Friend WithEvents btnOriginObject As System.Windows.Forms.Button
    Friend WithEvents lblOriginObject As System.Windows.Forms.Label
    Friend WithEvents gbPointShapeMark As System.Windows.Forms.GroupBox
    Friend WithEvents picPointShapeMark As System.Windows.Forms.PictureBox
    Friend WithEvents gbLineObjectSize As System.Windows.Forms.GroupBox
    Friend WithEvents btnLineShapeEdgePattern As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLineObjectSize As System.Windows.Forms.TextBox
    Friend WithEvents picCategrySelector As System.Windows.Forms.PictureBox
    Friend WithEvents pnlCategoryUpDown As System.Windows.Forms.Panel
    Friend WithEvents btnCategoryDown As System.Windows.Forms.Button
    Friend WithEvents btnCategoryUp As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnCategorize_Arrange As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btColorPattern As System.Windows.Forms.Button
    Friend WithEvents btnReverseColor As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnTransparency As System.Windows.Forms.Button
End Class
