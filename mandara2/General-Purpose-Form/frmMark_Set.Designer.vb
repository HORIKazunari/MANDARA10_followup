<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMark_Set
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlMark = New System.Windows.Forms.Panel()
        Me.picFrameLine = New System.Windows.Forms.PictureBox()
        Me.lbFrameLine = New System.Windows.Forms.Label()
        Me.picMark = New System.Windows.Forms.PictureBox()
        Me.pnlWord = New System.Windows.Forms.Panel()
        Me.btnFont = New System.Windows.Forms.Button()
        Me.txtWordMark = New System.Windows.Forms.TextBox()
        Me.pnlPicture = New System.Windows.Forms.Panel()
        Me.btnImageAlphaValue = New System.Windows.Forms.Button()
        Me.btnGazoClear = New System.Windows.Forms.Button()
        Me.picGazo = New System.Windows.Forms.PictureBox()
        Me.rbPicture = New System.Windows.Forms.RadioButton()
        Me.rbWord = New System.Windows.Forms.RadioButton()
        Me.rbMark = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.picInnerTile = New System.Windows.Forms.PictureBox()
        Me.picBack = New System.Windows.Forms.PictureBox()
        Me.picInnerColor = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboSize = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKakudo = New mandara10.TextNumberBox()
        Me.GroupBox1.SuspendLayout()
        Me.pnlMark.SuspendLayout()
        CType(Me.picFrameLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlWord.SuspendLayout()
        Me.pnlPicture.SuspendLayout()
        CType(Me.picGazo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picInnerTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picInnerColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(254, 181)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(337, 181)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pnlMark)
        Me.GroupBox1.Controls.Add(Me.pnlWord)
        Me.GroupBox1.Controls.Add(Me.pnlPicture)
        Me.GroupBox1.Controls.Add(Me.rbPicture)
        Me.GroupBox1.Controls.Add(Me.rbWord)
        Me.GroupBox1.Controls.Add(Me.rbMark)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(239, 157)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "表示記号"
        '
        'pnlMark
        '
        Me.pnlMark.Controls.Add(Me.picFrameLine)
        Me.pnlMark.Controls.Add(Me.lbFrameLine)
        Me.pnlMark.Controls.Add(Me.picMark)
        Me.pnlMark.Location = New System.Drawing.Point(80, 17)
        Me.pnlMark.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlMark.Name = "pnlMark"
        Me.pnlMark.Size = New System.Drawing.Size(154, 36)
        Me.pnlMark.TabIndex = 16
        '
        'picFrameLine
        '
        Me.picFrameLine.BackColor = System.Drawing.Color.White
        Me.picFrameLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picFrameLine.Location = New System.Drawing.Point(84, 6)
        Me.picFrameLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picFrameLine.Name = "picFrameLine"
        Me.picFrameLine.Size = New System.Drawing.Size(57, 23)
        Me.picFrameLine.TabIndex = 14
        Me.picFrameLine.TabStop = False
        '
        'lbFrameLine
        '
        Me.lbFrameLine.AutoSize = True
        Me.lbFrameLine.Location = New System.Drawing.Point(55, 6)
        Me.lbFrameLine.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbFrameLine.Name = "lbFrameLine"
        Me.lbFrameLine.Size = New System.Drawing.Size(29, 12)
        Me.lbFrameLine.TabIndex = 13
        Me.lbFrameLine.Text = "輪郭"
        '
        'picMark
        '
        Me.picMark.BackColor = System.Drawing.Color.White
        Me.picMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMark.Location = New System.Drawing.Point(3, 2)
        Me.picMark.Margin = New System.Windows.Forms.Padding(2)
        Me.picMark.Name = "picMark"
        Me.picMark.Size = New System.Drawing.Size(32, 28)
        Me.picMark.TabIndex = 12
        Me.picMark.TabStop = False
        '
        'pnlWord
        '
        Me.pnlWord.Controls.Add(Me.btnFont)
        Me.pnlWord.Controls.Add(Me.txtWordMark)
        Me.pnlWord.Location = New System.Drawing.Point(80, 63)
        Me.pnlWord.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlWord.Name = "pnlWord"
        Me.pnlWord.Size = New System.Drawing.Size(131, 28)
        Me.pnlWord.TabIndex = 15
        '
        'btnFont
        '
        Me.btnFont.Location = New System.Drawing.Point(71, 3)
        Me.btnFont.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFont.Name = "btnFont"
        Me.btnFont.Size = New System.Drawing.Size(56, 21)
        Me.btnFont.TabIndex = 11
        Me.btnFont.Text = "フォント"
        Me.btnFont.UseVisualStyleBackColor = True
        '
        'txtWordMark
        '
        Me.txtWordMark.Font = New System.Drawing.Font("MS UI Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWordMark.Location = New System.Drawing.Point(3, 1)
        Me.txtWordMark.Margin = New System.Windows.Forms.Padding(2)
        Me.txtWordMark.Name = "txtWordMark"
        Me.txtWordMark.Size = New System.Drawing.Size(42, 26)
        Me.txtWordMark.TabIndex = 10
        '
        'pnlPicture
        '
        Me.pnlPicture.Controls.Add(Me.btnImageAlphaValue)
        Me.pnlPicture.Controls.Add(Me.btnGazoClear)
        Me.pnlPicture.Controls.Add(Me.picGazo)
        Me.pnlPicture.Location = New System.Drawing.Point(80, 96)
        Me.pnlPicture.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlPicture.Name = "pnlPicture"
        Me.pnlPicture.Size = New System.Drawing.Size(154, 58)
        Me.pnlPicture.TabIndex = 14
        '
        'btnImageAlphaValue
        '
        Me.btnImageAlphaValue.Location = New System.Drawing.Point(58, 9)
        Me.btnImageAlphaValue.Margin = New System.Windows.Forms.Padding(2)
        Me.btnImageAlphaValue.Name = "btnImageAlphaValue"
        Me.btnImageAlphaValue.Size = New System.Drawing.Size(70, 21)
        Me.btnImageAlphaValue.TabIndex = 17
        Me.btnImageAlphaValue.Text = "透過度"
        Me.btnImageAlphaValue.UseVisualStyleBackColor = True
        '
        'btnGazoClear
        '
        Me.btnGazoClear.Location = New System.Drawing.Point(58, 33)
        Me.btnGazoClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGazoClear.Name = "btnGazoClear"
        Me.btnGazoClear.Size = New System.Drawing.Size(70, 21)
        Me.btnGazoClear.TabIndex = 16
        Me.btnGazoClear.Text = "選択解除"
        Me.btnGazoClear.UseVisualStyleBackColor = True
        '
        'picGazo
        '
        Me.picGazo.BackColor = System.Drawing.Color.White
        Me.picGazo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picGazo.Location = New System.Drawing.Point(3, 6)
        Me.picGazo.Margin = New System.Windows.Forms.Padding(2)
        Me.picGazo.Name = "picGazo"
        Me.picGazo.Size = New System.Drawing.Size(32, 28)
        Me.picGazo.TabIndex = 15
        Me.picGazo.TabStop = False
        '
        'rbPicture
        '
        Me.rbPicture.AutoSize = True
        Me.rbPicture.Location = New System.Drawing.Point(16, 110)
        Me.rbPicture.Margin = New System.Windows.Forms.Padding(2)
        Me.rbPicture.Name = "rbPicture"
        Me.rbPicture.Size = New System.Drawing.Size(47, 16)
        Me.rbPicture.TabIndex = 2
        Me.rbPicture.TabStop = True
        Me.rbPicture.Text = "画像"
        Me.rbPicture.UseVisualStyleBackColor = True
        '
        'rbWord
        '
        Me.rbWord.AutoSize = True
        Me.rbWord.Location = New System.Drawing.Point(16, 70)
        Me.rbWord.Margin = New System.Windows.Forms.Padding(2)
        Me.rbWord.Name = "rbWord"
        Me.rbWord.Size = New System.Drawing.Size(71, 16)
        Me.rbWord.TabIndex = 1
        Me.rbWord.TabStop = True
        Me.rbWord.Text = "文字記号"
        Me.rbWord.UseVisualStyleBackColor = True
        '
        'rbMark
        '
        Me.rbMark.AutoSize = True
        Me.rbMark.Location = New System.Drawing.Point(16, 26)
        Me.rbMark.Margin = New System.Windows.Forms.Padding(2)
        Me.rbMark.Name = "rbMark"
        Me.rbMark.Size = New System.Drawing.Size(71, 16)
        Me.rbMark.TabIndex = 0
        Me.rbMark.TabStop = True
        Me.rbMark.Text = "既定記号"
        Me.rbMark.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtKakudo)
        Me.GroupBox2.Controls.Add(Me.picInnerTile)
        Me.GroupBox2.Controls.Add(Me.picBack)
        Me.GroupBox2.Controls.Add(Me.picInnerColor)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cboSize)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(253, 10)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(146, 156)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'picInnerTile
        '
        Me.picInnerTile.BackColor = System.Drawing.Color.White
        Me.picInnerTile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picInnerTile.Location = New System.Drawing.Point(54, 55)
        Me.picInnerTile.Margin = New System.Windows.Forms.Padding(2)
        Me.picInnerTile.Name = "picInnerTile"
        Me.picInnerTile.Size = New System.Drawing.Size(47, 24)
        Me.picInnerTile.TabIndex = 17
        Me.picInnerTile.TabStop = False
        '
        'picBack
        '
        Me.picBack.BackColor = System.Drawing.Color.White
        Me.picBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picBack.Location = New System.Drawing.Point(54, 83)
        Me.picBack.Margin = New System.Windows.Forms.Padding(2)
        Me.picBack.Name = "picBack"
        Me.picBack.Size = New System.Drawing.Size(67, 28)
        Me.picBack.TabIndex = 15
        Me.picBack.TabStop = False
        '
        'picInnerColor
        '
        Me.picInnerColor.BackColor = System.Drawing.Color.White
        Me.picInnerColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picInnerColor.Location = New System.Drawing.Point(54, 54)
        Me.picInnerColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picInnerColor.Name = "picInnerColor"
        Me.picInnerColor.Size = New System.Drawing.Size(47, 24)
        Me.picInnerColor.TabIndex = 14
        Me.picInnerColor.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(114, 125)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "度"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 91)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "背景"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(114, 30)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 12)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 62)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "内部"
        '
        'cboSize
        '
        Me.cboSize.FormattingEnabled = True
        Me.cboSize.Location = New System.Drawing.Point(54, 24)
        Me.cboSize.Margin = New System.Windows.Forms.Padding(2)
        Me.cboSize.Name = "cboSize"
        Me.cboSize.Size = New System.Drawing.Size(56, 20)
        Me.cboSize.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 122)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "回転角度"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 12)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "サイズ"
        '
        'txtKakudo
        '
        Me.txtKakudo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKakudo.Location = New System.Drawing.Point(68, 122)
        Me.txtKakudo.MaxValue = 0.0R
        Me.txtKakudo.MaxValueFlag = False
        Me.txtKakudo.MinValue = 0.0R
        Me.txtKakudo.MinValueFlag = False
        Me.txtKakudo.Name = "txtKakudo"
        Me.txtKakudo.NumberPoint = True
        Me.txtKakudo.Size = New System.Drawing.Size(45, 19)
        Me.txtKakudo.TabIndex = 2
        Me.txtKakudo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtKakudo.ValueErrorMessageFlag = True
        '
        'frmMark_Set
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(411, 216)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMark_Set"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "記号設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlMark.ResumeLayout(False)
        Me.pnlMark.PerformLayout()
        CType(Me.picFrameLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlWord.ResumeLayout(False)
        Me.pnlWord.PerformLayout()
        Me.pnlPicture.ResumeLayout(False)
        CType(Me.picGazo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picInnerTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picInnerColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPicture As System.Windows.Forms.RadioButton
    Friend WithEvents rbWord As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picBack As System.Windows.Forms.PictureBox
    Friend WithEvents picInnerColor As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSize As System.Windows.Forms.ComboBox
    Friend WithEvents rbMark As System.Windows.Forms.RadioButton
    Friend WithEvents pnlMark As System.Windows.Forms.Panel
    Friend WithEvents picFrameLine As System.Windows.Forms.PictureBox
    Friend WithEvents lbFrameLine As System.Windows.Forms.Label
    Friend WithEvents picMark As System.Windows.Forms.PictureBox
    Friend WithEvents pnlWord As System.Windows.Forms.Panel
    Friend WithEvents btnFont As System.Windows.Forms.Button
    Friend WithEvents txtWordMark As System.Windows.Forms.TextBox
    Friend WithEvents pnlPicture As System.Windows.Forms.Panel
    Friend WithEvents btnGazoClear As System.Windows.Forms.Button
    Friend WithEvents picGazo As System.Windows.Forms.PictureBox
    Friend WithEvents picInnerTile As System.Windows.Forms.PictureBox
    Friend WithEvents btnImageAlphaValue As System.Windows.Forms.Button
    Friend WithEvents txtKakudo As mandara10.TextNumberBox
End Class
