<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMakeLineEdgePattern
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
        Me.rbFlat = New System.Windows.Forms.RadioButton()
        Me.rbRect = New System.Windows.Forms.RadioButton()
        Me.rbRound = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMiterDir = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbMiter = New System.Windows.Forms.RadioButton()
        Me.rbBevel = New System.Windows.Forms.RadioButton()
        Me.rbRoundJoin = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(9, 230)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 23
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(86, 230)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 25)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbFlat)
        Me.GroupBox1.Controls.Add(Me.rbRect)
        Me.GroupBox1.Controls.Add(Me.rbRound)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(148, 81)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "線端"
        '
        'rbFlat
        '
        Me.rbFlat.AutoSize = True
        Me.rbFlat.Location = New System.Drawing.Point(17, 57)
        Me.rbFlat.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rbFlat.Name = "rbFlat"
        Me.rbFlat.Size = New System.Drawing.Size(50, 16)
        Me.rbFlat.TabIndex = 2
        Me.rbFlat.TabStop = True
        Me.rbFlat.Text = "たいら"
        Me.rbFlat.UseVisualStyleBackColor = True
        '
        'rbRect
        '
        Me.rbRect.AutoSize = True
        Me.rbRect.Location = New System.Drawing.Point(17, 37)
        Me.rbRect.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rbRect.Name = "rbRect"
        Me.rbRect.Size = New System.Drawing.Size(57, 16)
        Me.rbRect.TabIndex = 1
        Me.rbRect.TabStop = True
        Me.rbRect.Text = "四角い"
        Me.rbRect.UseVisualStyleBackColor = True
        '
        'rbRound
        '
        Me.rbRound.AutoSize = True
        Me.rbRound.Location = New System.Drawing.Point(18, 17)
        Me.rbRound.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rbRound.Name = "rbRound"
        Me.rbRound.Size = New System.Drawing.Size(45, 16)
        Me.rbRound.TabIndex = 0
        Me.rbRound.TabStop = True
        Me.rbRound.Text = "丸い"
        Me.rbRound.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMiterDir)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.rbMiter)
        Me.GroupBox2.Controls.Add(Me.rbBevel)
        Me.GroupBox2.Controls.Add(Me.rbRoundJoin)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 102)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(148, 122)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "中間点接合"
        '
        'txtMiterDir
        '
        Me.txtMiterDir.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtMiterDir.Location = New System.Drawing.Point(48, 97)
        Me.txtMiterDir.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtMiterDir.Name = "txtMiterDir"
        Me.txtMiterDir.Size = New System.Drawing.Size(96, 19)
        Me.txtMiterDir.TabIndex = 27
        Me.txtMiterDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 82)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 12)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "マイター接合の限界値"
        '
        'rbMiter
        '
        Me.rbMiter.AutoSize = True
        Me.rbMiter.Location = New System.Drawing.Point(17, 65)
        Me.rbMiter.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rbMiter.Name = "rbMiter"
        Me.rbMiter.Size = New System.Drawing.Size(130, 16)
        Me.rbMiter.TabIndex = 4
        Me.rbMiter.TabStop = True
        Me.rbMiter.Text = "とがった（マイター接合）"
        Me.rbMiter.UseVisualStyleBackColor = True
        '
        'rbBevel
        '
        Me.rbBevel.AutoSize = True
        Me.rbBevel.Location = New System.Drawing.Point(17, 45)
        Me.rbBevel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rbBevel.Name = "rbBevel"
        Me.rbBevel.Size = New System.Drawing.Size(116, 16)
        Me.rbBevel.TabIndex = 3
        Me.rbBevel.TabStop = True
        Me.rbBevel.Text = "たいら（ベベル接合）"
        Me.rbBevel.UseVisualStyleBackColor = True
        '
        'rbRoundJoin
        '
        Me.rbRoundJoin.AutoSize = True
        Me.rbRoundJoin.Location = New System.Drawing.Point(17, 25)
        Me.rbRoundJoin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rbRoundJoin.Name = "rbRoundJoin"
        Me.rbRoundJoin.Size = New System.Drawing.Size(45, 16)
        Me.rbRoundJoin.TabIndex = 1
        Me.rbRoundJoin.TabStop = True
        Me.rbRoundJoin.Text = "丸い"
        Me.rbRoundJoin.UseVisualStyleBackColor = True
        '
        'frmMakeLineEdgePattern
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(170, 261)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMakeLineEdgePattern"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ラインパターン／線端・中間点接合設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbFlat As System.Windows.Forms.RadioButton
    Friend WithEvents rbRect As System.Windows.Forms.RadioButton
    Friend WithEvents rbRound As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMiter As System.Windows.Forms.RadioButton
    Friend WithEvents rbBevel As System.Windows.Forms.RadioButton
    Friend WithEvents rbRoundJoin As System.Windows.Forms.RadioButton
    Friend WithEvents txtMiterDir As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
