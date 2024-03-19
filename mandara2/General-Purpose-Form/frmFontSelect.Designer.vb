<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFontSelect
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
        Me.cboFontName = New mandara10.ComboBoxEx()
        Me.gbPointSize = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFontSize = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.picColor = New System.Windows.Forms.PictureBox()
        Me.gbACC = New System.Windows.Forms.GroupBox()
        Me.txtKakudo = New mandara10.TextNumberBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbUnderLine = New System.Windows.Forms.CheckBox()
        Me.cbItalic = New System.Windows.Forms.CheckBox()
        Me.cbBold = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.picBack = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.picSample = New System.Windows.Forms.PictureBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboFringeWidth = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picFringeColor = New System.Windows.Forms.PictureBox()
        Me.cbFringe = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.gbPointSize.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.picColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbACC.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.picBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picSample, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.picFringeColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(384, 157)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(453, 157)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFontName)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(134, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "フォント"
        '
        'cboFontName
        '
        Me.cboFontName.AsteriskSelectEnabled = False
        Me.cboFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFontName.FormattingEnabled = True
        Me.cboFontName.IntegralHeight = False
        Me.cboFontName.Location = New System.Drawing.Point(9, 22)
        Me.cboFontName.Margin = New System.Windows.Forms.Padding(2)
        Me.cboFontName.MaxDropDownItems = 20
        Me.cboFontName.Name = "cboFontName"
        Me.cboFontName.Size = New System.Drawing.Size(119, 20)
        Me.cboFontName.TabIndex = 32
        '
        'gbPointSize
        '
        Me.gbPointSize.Controls.Add(Me.Label1)
        Me.gbPointSize.Controls.Add(Me.cboFontSize)
        Me.gbPointSize.Location = New System.Drawing.Point(158, 10)
        Me.gbPointSize.Margin = New System.Windows.Forms.Padding(2)
        Me.gbPointSize.Name = "gbPointSize"
        Me.gbPointSize.Padding = New System.Windows.Forms.Padding(2)
        Me.gbPointSize.Size = New System.Drawing.Size(94, 51)
        Me.gbPointSize.TabIndex = 1
        Me.gbPointSize.TabStop = False
        Me.gbPointSize.Text = "サイズ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(76, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 12)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "%"
        '
        'cboFontSize
        '
        Me.cboFontSize.FormattingEnabled = True
        Me.cboFontSize.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cboFontSize.Location = New System.Drawing.Point(14, 22)
        Me.cboFontSize.Margin = New System.Windows.Forms.Padding(2)
        Me.cboFontSize.Name = "cboFontSize"
        Me.cboFontSize.Size = New System.Drawing.Size(56, 20)
        Me.cboFontSize.TabIndex = 30
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.picColor)
        Me.GroupBox4.Location = New System.Drawing.Point(265, 10)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(79, 50)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "文字色"
        '
        'picColor
        '
        Me.picColor.BackColor = System.Drawing.Color.White
        Me.picColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picColor.Location = New System.Drawing.Point(14, 17)
        Me.picColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picColor.Name = "picColor"
        Me.picColor.Size = New System.Drawing.Size(47, 28)
        Me.picColor.TabIndex = 15
        Me.picColor.TabStop = False
        '
        'gbACC
        '
        Me.gbACC.Controls.Add(Me.txtKakudo)
        Me.gbACC.Controls.Add(Me.Label8)
        Me.gbACC.Controls.Add(Me.Label3)
        Me.gbACC.Controls.Add(Me.cbUnderLine)
        Me.gbACC.Controls.Add(Me.cbItalic)
        Me.gbACC.Controls.Add(Me.cbBold)
        Me.gbACC.Location = New System.Drawing.Point(11, 71)
        Me.gbACC.Margin = New System.Windows.Forms.Padding(2)
        Me.gbACC.Name = "gbACC"
        Me.gbACC.Padding = New System.Windows.Forms.Padding(2)
        Me.gbACC.Size = New System.Drawing.Size(277, 62)
        Me.gbACC.TabIndex = 4
        Me.gbACC.TabStop = False
        Me.gbACC.Text = "飾り"
        '
        'txtKakudo
        '
        Me.txtKakudo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKakudo.Location = New System.Drawing.Point(201, 33)
        Me.txtKakudo.MaxValue = 0.0R
        Me.txtKakudo.MaxValueFlag = False
        Me.txtKakudo.MinValue = 0.0R
        Me.txtKakudo.MinValueFlag = False
        Me.txtKakudo.Name = "txtKakudo"
        Me.txtKakudo.NumberPoint = True
        Me.txtKakudo.Size = New System.Drawing.Size(45, 19)
        Me.txtKakudo.TabIndex = 3
        Me.txtKakudo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtKakudo.ValueErrorMessageFlag = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(247, 38)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "度"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(199, 18)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "回転角度"
        '
        'cbUnderLine
        '
        Me.cbUnderLine.AutoSize = True
        Me.cbUnderLine.Location = New System.Drawing.Point(147, 29)
        Me.cbUnderLine.Margin = New System.Windows.Forms.Padding(2)
        Me.cbUnderLine.Name = "cbUnderLine"
        Me.cbUnderLine.Size = New System.Drawing.Size(48, 16)
        Me.cbUnderLine.TabIndex = 2
        Me.cbUnderLine.Text = "下線"
        Me.cbUnderLine.UseVisualStyleBackColor = True
        '
        'cbItalic
        '
        Me.cbItalic.AutoSize = True
        Me.cbItalic.Location = New System.Drawing.Point(71, 29)
        Me.cbItalic.Margin = New System.Windows.Forms.Padding(2)
        Me.cbItalic.Name = "cbItalic"
        Me.cbItalic.Size = New System.Drawing.Size(63, 16)
        Me.cbItalic.TabIndex = 1
        Me.cbItalic.Text = "イタリック"
        Me.cbItalic.UseVisualStyleBackColor = True
        '
        'cbBold
        '
        Me.cbBold.AutoSize = True
        Me.cbBold.Location = New System.Drawing.Point(9, 29)
        Me.cbBold.Margin = New System.Windows.Forms.Padding(2)
        Me.cbBold.Name = "cbBold"
        Me.cbBold.Size = New System.Drawing.Size(48, 16)
        Me.cbBold.TabIndex = 0
        Me.cbBold.Text = "強調"
        Me.cbBold.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.picBack)
        Me.GroupBox3.Location = New System.Drawing.Point(348, 10)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(117, 54)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "文字背景"
        '
        'picBack
        '
        Me.picBack.BackColor = System.Drawing.Color.White
        Me.picBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picBack.Location = New System.Drawing.Point(12, 20)
        Me.picBack.Margin = New System.Windows.Forms.Padding(2)
        Me.picBack.Name = "picBack"
        Me.picBack.Size = New System.Drawing.Size(97, 28)
        Me.picBack.TabIndex = 19
        Me.picBack.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.picSample)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 143)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(216, 48)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "サンプル"
        '
        'picSample
        '
        Me.picSample.BackColor = System.Drawing.Color.White
        Me.picSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSample.Location = New System.Drawing.Point(9, 14)
        Me.picSample.Margin = New System.Windows.Forms.Padding(2)
        Me.picSample.Name = "picSample"
        Me.picSample.Size = New System.Drawing.Size(194, 28)
        Me.picSample.TabIndex = 21
        Me.picSample.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.cboFringeWidth)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.picFringeColor)
        Me.GroupBox5.Controls.Add(Me.cbFringe)
        Me.GroupBox5.Location = New System.Drawing.Point(292, 76)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Size = New System.Drawing.Size(223, 57)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "文字縁取り"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(126, 34)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 12)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "%"
        '
        'cboFringeWidth
        '
        Me.cboFringeWidth.FormattingEnabled = True
        Me.cboFringeWidth.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cboFringeWidth.Location = New System.Drawing.Point(80, 27)
        Me.cboFringeWidth.Margin = New System.Windows.Forms.Padding(2)
        Me.cboFringeWidth.Name = "cboFringeWidth"
        Me.cboFringeWidth.Size = New System.Drawing.Size(42, 20)
        Me.cboFringeWidth.TabIndex = 39
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(68, 12)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 12)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "文字に対する幅"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(159, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "色"
        '
        'picFringeColor
        '
        Me.picFringeColor.BackColor = System.Drawing.Color.White
        Me.picFringeColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picFringeColor.Location = New System.Drawing.Point(180, 22)
        Me.picFringeColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picFringeColor.Name = "picFringeColor"
        Me.picFringeColor.Size = New System.Drawing.Size(34, 24)
        Me.picFringeColor.TabIndex = 36
        Me.picFringeColor.TabStop = False
        '
        'cbFringe
        '
        Me.cbFringe.AutoSize = True
        Me.cbFringe.Location = New System.Drawing.Point(11, 20)
        Me.cbFringe.Margin = New System.Windows.Forms.Padding(2)
        Me.cbFringe.Name = "cbFringe"
        Me.cbFringe.Size = New System.Drawing.Size(56, 16)
        Me.cbFringe.TabIndex = 35
        Me.cbFringe.Text = "縁取り"
        Me.cbFringe.UseVisualStyleBackColor = True
        '
        'frmFontSelect
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(528, 201)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.gbACC)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.gbPointSize)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFontSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "フォントの設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.gbPointSize.ResumeLayout(False)
        Me.gbPointSize.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.picColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbACC.ResumeLayout(False)
        Me.gbACC.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.picBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.picSample, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.picFringeColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbPointSize As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFontSize As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents picColor As System.Windows.Forms.PictureBox
    Friend WithEvents gbACC As System.Windows.Forms.GroupBox
    Friend WithEvents cbUnderLine As System.Windows.Forms.CheckBox
    Friend WithEvents cbItalic As System.Windows.Forms.CheckBox
    Friend WithEvents cbBold As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents picBack As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFontName As mandara10.ComboBoxEx
    Friend WithEvents picSample As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboFringeWidth As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picFringeColor As System.Windows.Forms.PictureBox
    Friend WithEvents cbFringe As System.Windows.Forms.CheckBox
    Friend WithEvents txtKakudo As mandara10.TextNumberBox
End Class
