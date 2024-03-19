<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHatchSelecter
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbMark = New System.Windows.Forms.RadioButton()
        Me.rbPaint = New System.Windows.Forms.RadioButton()
        Me.rbBlank = New System.Windows.Forms.RadioButton()
        Me.rbSaltire = New System.Windows.Forms.RadioButton()
        Me.rbCrossLine = New System.Windows.Forms.RadioButton()
        Me.rbDiagonalLineRightDown = New System.Windows.Forms.RadioButton()
        Me.rbDiagonalLineRightUp = New System.Windows.Forms.RadioButton()
        Me.rbVerticalLine = New System.Windows.Forms.RadioButton()
        Me.rbHorizontalLine = New System.Windows.Forms.RadioButton()
        Me.rbPoint = New System.Windows.Forms.RadioButton()
        Me.gbDensity = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboDensity = New System.Windows.Forms.ComboBox()
        Me.gbPointSize = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSize = New System.Windows.Forms.ComboBox()
        Me.gbCol = New System.Windows.Forms.GroupBox()
        Me.picColor = New System.Windows.Forms.PictureBox()
        Me.gbSample = New System.Windows.Forms.GroupBox()
        Me.picSample = New System.Windows.Forms.PictureBox()
        Me.gbBack = New System.Windows.Forms.GroupBox()
        Me.picBGCol = New System.Windows.Forms.PictureBox()
        Me.rbNonTransparency = New System.Windows.Forms.RadioButton()
        Me.rbTransparency = New System.Windows.Forms.RadioButton()
        Me.gbMark = New System.Windows.Forms.GroupBox()
        Me.picMark = New System.Windows.Forms.PictureBox()
        Me.gbLine = New System.Windows.Forms.GroupBox()
        Me.picLine = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.gbDensity.SuspendLayout()
        Me.gbPointSize.SuspendLayout()
        Me.gbCol.SuspendLayout()
        CType(Me.picColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSample.SuspendLayout()
        CType(Me.picSample, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBack.SuspendLayout()
        CType(Me.picBGCol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMark.SuspendLayout()
        CType(Me.picMark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLine.SuspendLayout()
        CType(Me.picLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(348, 416)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(83, 30)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(455, 416)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 30)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbMark)
        Me.GroupBox1.Controls.Add(Me.rbPaint)
        Me.GroupBox1.Controls.Add(Me.rbBlank)
        Me.GroupBox1.Controls.Add(Me.rbSaltire)
        Me.GroupBox1.Controls.Add(Me.rbCrossLine)
        Me.GroupBox1.Controls.Add(Me.rbDiagonalLineRightDown)
        Me.GroupBox1.Controls.Add(Me.rbDiagonalLineRightUp)
        Me.GroupBox1.Controls.Add(Me.rbVerticalLine)
        Me.GroupBox1.Controls.Add(Me.rbHorizontalLine)
        Me.GroupBox1.Controls.Add(Me.rbPoint)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(194, 384)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "模様"
        '
        'rbMark
        '
        Me.rbMark.AutoSize = True
        Me.rbMark.Location = New System.Drawing.Point(24, 359)
        Me.rbMark.Name = "rbMark"
        Me.rbMark.Size = New System.Drawing.Size(74, 19)
        Me.rbMark.TabIndex = 10
        Me.rbMark.TabStop = True
        Me.rbMark.Text = "（記号）"
        Me.rbMark.UseVisualStyleBackColor = True
        '
        'rbPaint
        '
        Me.rbPaint.AutoSize = True
        Me.rbPaint.Location = New System.Drawing.Point(24, 321)
        Me.rbPaint.Name = "rbPaint"
        Me.rbPaint.Size = New System.Drawing.Size(105, 19)
        Me.rbPaint.TabIndex = 9
        Me.rbPaint.TabStop = True
        Me.rbPaint.Text = "■（ベタ塗り）"
        Me.rbPaint.UseVisualStyleBackColor = True
        '
        'rbBlank
        '
        Me.rbBlank.AutoSize = True
        Me.rbBlank.Location = New System.Drawing.Point(24, 286)
        Me.rbBlank.Name = "rbBlank"
        Me.rbBlank.Size = New System.Drawing.Size(89, 19)
        Me.rbBlank.TabIndex = 8
        Me.rbBlank.TabStop = True
        Me.rbBlank.Text = "□（空白）"
        Me.rbBlank.UseVisualStyleBackColor = True
        '
        'rbSaltire
        '
        Me.rbSaltire.AutoSize = True
        Me.rbSaltire.Location = New System.Drawing.Point(24, 252)
        Me.rbSaltire.Name = "rbSaltire"
        Me.rbSaltire.Size = New System.Drawing.Size(91, 19)
        Me.rbSaltire.TabIndex = 7
        Me.rbSaltire.TabStop = True
        Me.rbSaltire.Text = "×（クロス）"
        Me.rbSaltire.UseVisualStyleBackColor = True
        '
        'rbCrossLine
        '
        Me.rbCrossLine.AutoSize = True
        Me.rbCrossLine.Location = New System.Drawing.Point(24, 214)
        Me.rbCrossLine.Name = "rbCrossLine"
        Me.rbCrossLine.Size = New System.Drawing.Size(91, 19)
        Me.rbCrossLine.TabIndex = 6
        Me.rbCrossLine.TabStop = True
        Me.rbCrossLine.Text = "＋（クロス）"
        Me.rbCrossLine.UseVisualStyleBackColor = True
        '
        'rbDiagonalLineRightDown
        '
        Me.rbDiagonalLineRightDown.AutoSize = True
        Me.rbDiagonalLineRightDown.Location = New System.Drawing.Point(24, 180)
        Me.rbDiagonalLineRightDown.Name = "rbDiagonalLineRightDown"
        Me.rbDiagonalLineRightDown.Size = New System.Drawing.Size(89, 19)
        Me.rbDiagonalLineRightDown.TabIndex = 5
        Me.rbDiagonalLineRightDown.TabStop = True
        Me.rbDiagonalLineRightDown.Text = "＼（斜線）"
        Me.rbDiagonalLineRightDown.UseVisualStyleBackColor = True
        '
        'rbDiagonalLineRightUp
        '
        Me.rbDiagonalLineRightUp.AutoSize = True
        Me.rbDiagonalLineRightUp.Location = New System.Drawing.Point(24, 143)
        Me.rbDiagonalLineRightUp.Name = "rbDiagonalLineRightUp"
        Me.rbDiagonalLineRightUp.Size = New System.Drawing.Size(89, 19)
        Me.rbDiagonalLineRightUp.TabIndex = 4
        Me.rbDiagonalLineRightUp.TabStop = True
        Me.rbDiagonalLineRightUp.Text = "／（斜線）"
        Me.rbDiagonalLineRightUp.UseVisualStyleBackColor = True
        '
        'rbVerticalLine
        '
        Me.rbVerticalLine.AutoSize = True
        Me.rbVerticalLine.Location = New System.Drawing.Point(24, 106)
        Me.rbVerticalLine.Name = "rbVerticalLine"
        Me.rbVerticalLine.Size = New System.Drawing.Size(83, 19)
        Me.rbVerticalLine.TabIndex = 3
        Me.rbVerticalLine.TabStop = True
        Me.rbVerticalLine.Text = "｜(縦線)"
        Me.rbVerticalLine.UseVisualStyleBackColor = True
        '
        'rbHorizontalLine
        '
        Me.rbHorizontalLine.AutoSize = True
        Me.rbHorizontalLine.Location = New System.Drawing.Point(24, 69)
        Me.rbHorizontalLine.Name = "rbHorizontalLine"
        Me.rbHorizontalLine.Size = New System.Drawing.Size(83, 19)
        Me.rbHorizontalLine.TabIndex = 2
        Me.rbHorizontalLine.TabStop = True
        Me.rbHorizontalLine.Text = "－(横線)"
        Me.rbHorizontalLine.UseVisualStyleBackColor = True
        '
        'rbPoint
        '
        Me.rbPoint.AutoSize = True
        Me.rbPoint.Location = New System.Drawing.Point(24, 34)
        Me.rbPoint.Name = "rbPoint"
        Me.rbPoint.Size = New System.Drawing.Size(76, 19)
        Me.rbPoint.TabIndex = 1
        Me.rbPoint.TabStop = True
        Me.rbPoint.Text = " ・　(点)"
        Me.rbPoint.UseVisualStyleBackColor = True
        '
        'gbDensity
        '
        Me.gbDensity.Controls.Add(Me.Label7)
        Me.gbDensity.Controls.Add(Me.cboDensity)
        Me.gbDensity.Location = New System.Drawing.Point(216, 12)
        Me.gbDensity.Name = "gbDensity"
        Me.gbDensity.Size = New System.Drawing.Size(159, 88)
        Me.gbDensity.TabIndex = 1
        Me.gbDensity.TabStop = False
        Me.gbDensity.Text = "間隔"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(129, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "%"
        '
        'cboDensity
        '
        Me.cboDensity.FormattingEnabled = True
        Me.cboDensity.Location = New System.Drawing.Point(19, 34)
        Me.cboDensity.Name = "cboDensity"
        Me.cboDensity.Size = New System.Drawing.Size(104, 23)
        Me.cboDensity.TabIndex = 28
        '
        'gbPointSize
        '
        Me.gbPointSize.Controls.Add(Me.Label1)
        Me.gbPointSize.Controls.Add(Me.cboSize)
        Me.gbPointSize.Location = New System.Drawing.Point(216, 127)
        Me.gbPointSize.Name = "gbPointSize"
        Me.gbPointSize.Size = New System.Drawing.Size(159, 74)
        Me.gbPointSize.TabIndex = 3
        Me.gbPointSize.TabStop = False
        Me.gbPointSize.Text = "点・記号の大きさ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(129, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 15)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "%"
        '
        'cboSize
        '
        Me.cboSize.FormattingEnabled = True
        Me.cboSize.Location = New System.Drawing.Point(19, 28)
        Me.cboSize.Name = "cboSize"
        Me.cboSize.Size = New System.Drawing.Size(104, 23)
        Me.cboSize.TabIndex = 30
        '
        'gbCol
        '
        Me.gbCol.Controls.Add(Me.picColor)
        Me.gbCol.Location = New System.Drawing.Point(216, 323)
        Me.gbCol.Name = "gbCol"
        Me.gbCol.Size = New System.Drawing.Size(159, 73)
        Me.gbCol.TabIndex = 6
        Me.gbCol.TabStop = False
        Me.gbCol.Text = "色"
        '
        'picColor
        '
        Me.picColor.BackColor = System.Drawing.Color.White
        Me.picColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picColor.Location = New System.Drawing.Point(19, 21)
        Me.picColor.Name = "picColor"
        Me.picColor.Size = New System.Drawing.Size(61, 34)
        Me.picColor.TabIndex = 15
        Me.picColor.TabStop = False
        '
        'gbSample
        '
        Me.gbSample.Controls.Add(Me.picSample)
        Me.gbSample.Location = New System.Drawing.Point(387, 267)
        Me.gbSample.Name = "gbSample"
        Me.gbSample.Size = New System.Drawing.Size(150, 129)
        Me.gbSample.TabIndex = 9
        Me.gbSample.TabStop = False
        Me.gbSample.Text = "サンプル"
        '
        'picSample
        '
        Me.picSample.BackColor = System.Drawing.Color.White
        Me.picSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSample.Location = New System.Drawing.Point(6, 21)
        Me.picSample.Name = "picSample"
        Me.picSample.Size = New System.Drawing.Size(138, 102)
        Me.picSample.TabIndex = 16
        Me.picSample.TabStop = False
        '
        'gbBack
        '
        Me.gbBack.Controls.Add(Me.picBGCol)
        Me.gbBack.Controls.Add(Me.rbNonTransparency)
        Me.gbBack.Controls.Add(Me.rbTransparency)
        Me.gbBack.Location = New System.Drawing.Point(387, 12)
        Me.gbBack.Name = "gbBack"
        Me.gbBack.Size = New System.Drawing.Size(150, 137)
        Me.gbBack.TabIndex = 2
        Me.gbBack.TabStop = False
        Me.gbBack.Text = "背景色"
        '
        'picBGCol
        '
        Me.picBGCol.BackColor = System.Drawing.Color.White
        Me.picBGCol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picBGCol.Location = New System.Drawing.Point(57, 91)
        Me.picBGCol.Name = "picBGCol"
        Me.picBGCol.Size = New System.Drawing.Size(61, 34)
        Me.picBGCol.TabIndex = 16
        Me.picBGCol.TabStop = False
        '
        'rbNonTransparency
        '
        Me.rbNonTransparency.AutoSize = True
        Me.rbNonTransparency.Location = New System.Drawing.Point(20, 69)
        Me.rbNonTransparency.Name = "rbNonTransparency"
        Me.rbNonTransparency.Size = New System.Drawing.Size(73, 19)
        Me.rbNonTransparency.TabIndex = 3
        Me.rbNonTransparency.TabStop = True
        Me.rbNonTransparency.Text = "不透明"
        Me.rbNonTransparency.UseVisualStyleBackColor = True
        '
        'rbTransparency
        '
        Me.rbTransparency.AutoSize = True
        Me.rbTransparency.Location = New System.Drawing.Point(20, 31)
        Me.rbTransparency.Name = "rbTransparency"
        Me.rbTransparency.Size = New System.Drawing.Size(58, 19)
        Me.rbTransparency.TabIndex = 2
        Me.rbTransparency.TabStop = True
        Me.rbTransparency.Text = "透明"
        Me.rbTransparency.UseVisualStyleBackColor = True
        '
        'gbMark
        '
        Me.gbMark.Controls.Add(Me.picMark)
        Me.gbMark.Location = New System.Drawing.Point(387, 163)
        Me.gbMark.Name = "gbMark"
        Me.gbMark.Size = New System.Drawing.Size(148, 82)
        Me.gbMark.TabIndex = 4
        Me.gbMark.TabStop = False
        Me.gbMark.Text = "記号"
        '
        'picMark
        '
        Me.picMark.BackColor = System.Drawing.Color.White
        Me.picMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMark.Location = New System.Drawing.Point(35, 21)
        Me.picMark.Name = "picMark"
        Me.picMark.Size = New System.Drawing.Size(58, 47)
        Me.picMark.TabIndex = 4
        Me.picMark.TabStop = False
        '
        'gbLine
        '
        Me.gbLine.Controls.Add(Me.picLine)
        Me.gbLine.Location = New System.Drawing.Point(216, 226)
        Me.gbLine.Name = "gbLine"
        Me.gbLine.Size = New System.Drawing.Size(159, 74)
        Me.gbLine.TabIndex = 5
        Me.gbLine.TabStop = False
        Me.gbLine.Text = "線種設定"
        '
        'picLine
        '
        Me.picLine.BackColor = System.Drawing.Color.White
        Me.picLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLine.Location = New System.Drawing.Point(19, 34)
        Me.picLine.Name = "picLine"
        Me.picLine.Size = New System.Drawing.Size(75, 28)
        Me.picLine.TabIndex = 12
        Me.picLine.TabStop = False
        '
        'frmHatchSelecter
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(554, 454)
        Me.Controls.Add(Me.gbLine)
        Me.Controls.Add(Me.gbSample)
        Me.Controls.Add(Me.gbMark)
        Me.Controls.Add(Me.gbBack)
        Me.Controls.Add(Me.gbCol)
        Me.Controls.Add(Me.gbPointSize)
        Me.Controls.Add(Me.gbDensity)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHatchSelecter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ハッチ設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbDensity.ResumeLayout(False)
        Me.gbDensity.PerformLayout()
        Me.gbPointSize.ResumeLayout(False)
        Me.gbPointSize.PerformLayout()
        Me.gbCol.ResumeLayout(False)
        CType(Me.picColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSample.ResumeLayout(False)
        CType(Me.picSample, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBack.ResumeLayout(False)
        Me.gbBack.PerformLayout()
        CType(Me.picBGCol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMark.ResumeLayout(False)
        CType(Me.picMark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLine.ResumeLayout(False)
        CType(Me.picLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbDensity As System.Windows.Forms.GroupBox
    Friend WithEvents gbPointSize As System.Windows.Forms.GroupBox
    Friend WithEvents gbLine As System.Windows.Forms.GroupBox
    Friend WithEvents gbCol As System.Windows.Forms.GroupBox
    Friend WithEvents gbSample As System.Windows.Forms.GroupBox
    Friend WithEvents gbBack As System.Windows.Forms.GroupBox
    Friend WithEvents gbMark As System.Windows.Forms.GroupBox
    Friend WithEvents rbMark As System.Windows.Forms.RadioButton
    Friend WithEvents rbPaint As System.Windows.Forms.RadioButton
    Friend WithEvents rbBlank As System.Windows.Forms.RadioButton
    Friend WithEvents rbSaltire As System.Windows.Forms.RadioButton
    Friend WithEvents rbCrossLine As System.Windows.Forms.RadioButton
    Friend WithEvents rbDiagonalLineRightDown As System.Windows.Forms.RadioButton
    Friend WithEvents rbDiagonalLineRightUp As System.Windows.Forms.RadioButton
    Friend WithEvents rbVerticalLine As System.Windows.Forms.RadioButton
    Friend WithEvents rbHorizontalLine As System.Windows.Forms.RadioButton
    Friend WithEvents rbPoint As System.Windows.Forms.RadioButton
    Friend WithEvents cboDensity As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents picLine As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSize As System.Windows.Forms.ComboBox
    Friend WithEvents picColor As System.Windows.Forms.PictureBox
    Friend WithEvents picBGCol As System.Windows.Forms.PictureBox
    Friend WithEvents rbNonTransparency As System.Windows.Forms.RadioButton
    Friend WithEvents rbTransparency As System.Windows.Forms.RadioButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents picSample As System.Windows.Forms.PictureBox
    Friend WithEvents picMark As System.Windows.Forms.PictureBox
End Class
