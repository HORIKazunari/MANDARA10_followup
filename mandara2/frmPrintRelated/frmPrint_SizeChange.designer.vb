<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_SizeChange
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkAspectRation = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHeight = New mandara10.TextNumberBox()
        Me.txtWidth = New mandara10.TextNumberBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnHorizontal = New System.Windows.Forms.Button()
        Me.btnVartical = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbPosition00 = New System.Windows.Forms.RadioButton()
        Me.rbPositionCenter = New System.Windows.Forms.RadioButton()
        Me.rbPositionnoChange = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(270, 249)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(203, 249)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkAspectRation)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtHeight)
        Me.GroupBox1.Controls.Add(Me.txtWidth)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(310, 96)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkAspectRation
        '
        Me.chkAspectRation.AutoSize = True
        Me.chkAspectRation.Checked = True
        Me.chkAspectRation.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAspectRation.Location = New System.Drawing.Point(208, 61)
        Me.chkAspectRation.Name = "chkAspectRation"
        Me.chkAspectRation.Size = New System.Drawing.Size(93, 16)
        Me.chkAspectRation.TabIndex = 2
        Me.chkAspectRation.Text = "縦横比を固定"
        Me.chkAspectRation.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(137, 61)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 12)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "ピクセル"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(137, 28)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 12)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "ピクセル"
        '
        'txtHeight
        '
        Me.txtHeight.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtHeight.Location = New System.Drawing.Point(61, 54)
        Me.txtHeight.MaxValue = 0.0R
        Me.txtHeight.MaxValueFlag = False
        Me.txtHeight.MinValue = 1.0R
        Me.txtHeight.MinValueFlag = True
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.NumberPoint = True
        Me.txtHeight.Size = New System.Drawing.Size(71, 19)
        Me.txtHeight.TabIndex = 1
        Me.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHeight.ValueErrorMessageFlag = True
        '
        'txtWidth
        '
        Me.txtWidth.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtWidth.Location = New System.Drawing.Point(61, 21)
        Me.txtWidth.MaxValue = 0.0R
        Me.txtWidth.MaxValueFlag = False
        Me.txtWidth.MinValue = 1.0R
        Me.txtWidth.MinValueFlag = True
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.NumberPoint = True
        Me.txtWidth.Size = New System.Drawing.Size(71, 19)
        Me.txtWidth.TabIndex = 0
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWidth.ValueErrorMessageFlag = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 61)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 12)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "高さ"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(20, 28)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(17, 12)
        Me.Label22.TabIndex = 27
        Me.Label22.Text = "幅"
        '
        'btnHorizontal
        '
        Me.btnHorizontal.Location = New System.Drawing.Point(44, 147)
        Me.btnHorizontal.Name = "btnHorizontal"
        Me.btnHorizontal.Size = New System.Drawing.Size(80, 24)
        Me.btnHorizontal.TabIndex = 1
        Me.btnHorizontal.Text = "A4横の比率"
        Me.btnHorizontal.UseVisualStyleBackColor = True
        '
        'btnVartical
        '
        Me.btnVartical.Location = New System.Drawing.Point(44, 188)
        Me.btnVartical.Name = "btnVartical"
        Me.btnVartical.Size = New System.Drawing.Size(80, 24)
        Me.btnVartical.TabIndex = 2
        Me.btnVartical.Text = "A4縦の比率"
        Me.btnVartical.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbPosition00)
        Me.GroupBox2.Controls.Add(Me.rbPositionCenter)
        Me.GroupBox2.Controls.Add(Me.rbPositionnoChange)
        Me.GroupBox2.Location = New System.Drawing.Point(161, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(171, 105)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "位置"
        '
        'rbPosition00
        '
        Me.rbPosition00.AutoSize = True
        Me.rbPosition00.Location = New System.Drawing.Point(28, 83)
        Me.rbPosition00.Name = "rbPosition00"
        Me.rbPosition00.Size = New System.Drawing.Size(97, 16)
        Me.rbPosition00.TabIndex = 2
        Me.rbPosition00.Text = "左上に合わせる"
        Me.rbPosition00.UseVisualStyleBackColor = True
        '
        'rbPositionCenter
        '
        Me.rbPositionCenter.AutoSize = True
        Me.rbPositionCenter.Checked = True
        Me.rbPositionCenter.Location = New System.Drawing.Point(28, 49)
        Me.rbPositionCenter.Name = "rbPositionCenter"
        Me.rbPositionCenter.Size = New System.Drawing.Size(75, 16)
        Me.rbPositionCenter.TabIndex = 1
        Me.rbPositionCenter.TabStop = True
        Me.rbPositionCenter.Text = "センタリング"
        Me.rbPositionCenter.UseVisualStyleBackColor = True
        '
        'rbPositionnoChange
        '
        Me.rbPositionnoChange.AutoSize = True
        Me.rbPositionnoChange.Location = New System.Drawing.Point(28, 20)
        Me.rbPositionnoChange.Name = "rbPositionnoChange"
        Me.rbPositionnoChange.Size = New System.Drawing.Size(75, 16)
        Me.rbPositionnoChange.TabIndex = 0
        Me.rbPositionnoChange.Text = "現状のまま"
        Me.rbPositionnoChange.UseVisualStyleBackColor = True
        '
        'frmPrint_SizeChange
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(345, 283)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnVartical)
        Me.Controls.Add(Me.btnHorizontal)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_SizeChange"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "地図画面サイズ変更"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtWidth As mandara10.TextNumberBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents chkAspectRation As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHeight As mandara10.TextNumberBox
    Friend WithEvents btnHorizontal As System.Windows.Forms.Button
    Friend WithEvents btnVartical As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPosition00 As System.Windows.Forms.RadioButton
    Friend WithEvents rbPositionCenter As System.Windows.Forms.RadioButton
    Friend WithEvents rbPositionnoChange As System.Windows.Forms.RadioButton
End Class
