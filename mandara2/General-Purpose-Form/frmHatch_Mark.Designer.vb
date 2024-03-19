<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHatch_Mark
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtKakudo = New mandara10.TextNumberBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlPicture = New System.Windows.Forms.Panel()
        Me.btnGazoClear = New System.Windows.Forms.Button()
        Me.picGazo = New System.Windows.Forms.PictureBox()
        Me.pnlWord = New System.Windows.Forms.Panel()
        Me.cboFontName = New mandara10.ComboBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtWordMark = New System.Windows.Forms.TextBox()
        Me.pnlMark = New System.Windows.Forms.Panel()
        Me.picFrameLine = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picMark = New System.Windows.Forms.PictureBox()
        Me.rbPicture = New System.Windows.Forms.RadioButton()
        Me.rbWord = New System.Windows.Forms.RadioButton()
        Me.rbMark = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlPicture.SuspendLayout()
        CType(Me.picGazo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlWord.SuspendLayout()
        Me.pnlMark.SuspendLayout()
        CType(Me.picFrameLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(303, 110)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(303, 142)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtKakudo)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(286, 12)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(93, 50)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "回転角度"
        '
        'txtKakudo
        '
        Me.txtKakudo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKakudo.Location = New System.Drawing.Point(17, 23)
        Me.txtKakudo.MaxValue = 0.0R
        Me.txtKakudo.MaxValueFlag = False
        Me.txtKakudo.MinValue = 0.0R
        Me.txtKakudo.MinValueFlag = False
        Me.txtKakudo.Name = "txtKakudo"
        Me.txtKakudo.NumberPoint = True
        Me.txtKakudo.Size = New System.Drawing.Size(45, 19)
        Me.txtKakudo.TabIndex = 0
        Me.txtKakudo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtKakudo.ValueErrorMessageFlag = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(63, 28)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "度"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pnlPicture)
        Me.GroupBox1.Controls.Add(Me.pnlWord)
        Me.GroupBox1.Controls.Add(Me.pnlMark)
        Me.GroupBox1.Controls.Add(Me.rbPicture)
        Me.GroupBox1.Controls.Add(Me.rbWord)
        Me.GroupBox1.Controls.Add(Me.rbMark)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(272, 157)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "表示記号"
        '
        'pnlPicture
        '
        Me.pnlPicture.Controls.Add(Me.btnGazoClear)
        Me.pnlPicture.Controls.Add(Me.picGazo)
        Me.pnlPicture.Location = New System.Drawing.Point(80, 102)
        Me.pnlPicture.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlPicture.Name = "pnlPicture"
        Me.pnlPicture.Size = New System.Drawing.Size(154, 41)
        Me.pnlPicture.TabIndex = 31
        '
        'btnGazoClear
        '
        Me.btnGazoClear.Location = New System.Drawing.Point(61, 13)
        Me.btnGazoClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGazoClear.Name = "btnGazoClear"
        Me.btnGazoClear.Size = New System.Drawing.Size(67, 21)
        Me.btnGazoClear.TabIndex = 14
        Me.btnGazoClear.Text = "選択解除"
        Me.btnGazoClear.UseVisualStyleBackColor = True
        '
        'picGazo
        '
        Me.picGazo.BackColor = System.Drawing.Color.White
        Me.picGazo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picGazo.Location = New System.Drawing.Point(7, 6)
        Me.picGazo.Margin = New System.Windows.Forms.Padding(2)
        Me.picGazo.Name = "picGazo"
        Me.picGazo.Size = New System.Drawing.Size(32, 28)
        Me.picGazo.TabIndex = 13
        Me.picGazo.TabStop = False
        '
        'pnlWord
        '
        Me.pnlWord.Controls.Add(Me.cboFontName)
        Me.pnlWord.Controls.Add(Me.Label4)
        Me.pnlWord.Controls.Add(Me.txtWordMark)
        Me.pnlWord.Location = New System.Drawing.Point(80, 58)
        Me.pnlWord.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlWord.Name = "pnlWord"
        Me.pnlWord.Size = New System.Drawing.Size(182, 40)
        Me.pnlWord.TabIndex = 30
        '
        'cboFontName
        '
        Me.cboFontName.AsteriskSelectEnabled = False
        Me.cboFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFontName.FormattingEnabled = True
        Me.cboFontName.IntegralHeight = False
        Me.cboFontName.Location = New System.Drawing.Point(61, 14)
        Me.cboFontName.Margin = New System.Windows.Forms.Padding(2)
        Me.cboFontName.MaxDropDownItems = 20
        Me.cboFontName.Name = "cboFontName"
        Me.cboFontName.Size = New System.Drawing.Size(119, 20)
        Me.cboFontName.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 12)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "フォント"
        '
        'txtWordMark
        '
        Me.txtWordMark.Font = New System.Drawing.Font("MS UI Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWordMark.Location = New System.Drawing.Point(7, 6)
        Me.txtWordMark.Margin = New System.Windows.Forms.Padding(2)
        Me.txtWordMark.Name = "txtWordMark"
        Me.txtWordMark.Size = New System.Drawing.Size(42, 26)
        Me.txtWordMark.TabIndex = 29
        '
        'pnlMark
        '
        Me.pnlMark.Controls.Add(Me.picFrameLine)
        Me.pnlMark.Controls.Add(Me.Label1)
        Me.pnlMark.Controls.Add(Me.picMark)
        Me.pnlMark.Location = New System.Drawing.Point(80, 17)
        Me.pnlMark.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlMark.Name = "pnlMark"
        Me.pnlMark.Size = New System.Drawing.Size(154, 36)
        Me.pnlMark.TabIndex = 29
        '
        'picFrameLine
        '
        Me.picFrameLine.BackColor = System.Drawing.Color.White
        Me.picFrameLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picFrameLine.Location = New System.Drawing.Point(100, 9)
        Me.picFrameLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picFrameLine.Name = "picFrameLine"
        Me.picFrameLine.Size = New System.Drawing.Size(38, 23)
        Me.picFrameLine.TabIndex = 14
        Me.picFrameLine.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "線色"
        '
        'picMark
        '
        Me.picMark.BackColor = System.Drawing.Color.White
        Me.picMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMark.Location = New System.Drawing.Point(7, 2)
        Me.picMark.Margin = New System.Windows.Forms.Padding(2)
        Me.picMark.Name = "picMark"
        Me.picMark.Size = New System.Drawing.Size(32, 28)
        Me.picMark.TabIndex = 12
        Me.picMark.TabStop = False
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
        Me.rbWord.Location = New System.Drawing.Point(16, 69)
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
        'frmHatch_Mark
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(392, 177)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHatch_Mark"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ハッチ記号設定"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlPicture.ResumeLayout(False)
        CType(Me.picGazo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlWord.ResumeLayout(False)
        Me.pnlWord.PerformLayout()
        Me.pnlMark.ResumeLayout(False)
        Me.pnlMark.PerformLayout()
        CType(Me.picFrameLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPicture As System.Windows.Forms.RadioButton
    Friend WithEvents rbWord As System.Windows.Forms.RadioButton
    Friend WithEvents rbMark As System.Windows.Forms.RadioButton
    Friend WithEvents pnlMark As System.Windows.Forms.Panel
    Friend WithEvents picFrameLine As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picMark As System.Windows.Forms.PictureBox
    Friend WithEvents pnlWord As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtWordMark As System.Windows.Forms.TextBox
    Friend WithEvents pnlPicture As System.Windows.Forms.Panel
    Friend WithEvents btnGazoClear As System.Windows.Forms.Button
    Friend WithEvents picGazo As System.Windows.Forms.PictureBox
    Friend WithEvents cboFontName As mandara10.ComboBoxEx
    Friend WithEvents txtKakudo As mandara10.TextNumberBox
End Class
