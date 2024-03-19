<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlphaValueSet
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.hsbTransparency = New System.Windows.Forms.HScrollBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAlphaValue = New mandara10.TextNumberBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(84, 64)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(152, 63)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(178, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "不透明"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "透明"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.hsbTransparency)
        Me.Panel1.Location = New System.Drawing.Point(32, 9)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(145, 19)
        Me.Panel1.TabIndex = 1
        '
        'hsbTransparency
        '
        Me.hsbTransparency.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hsbTransparency.LargeChange = 1
        Me.hsbTransparency.Location = New System.Drawing.Point(0, 0)
        Me.hsbTransparency.Maximum = 255
        Me.hsbTransparency.Name = "hsbTransparency"
        Me.hsbTransparency.Size = New System.Drawing.Size(143, 17)
        Me.hsbTransparency.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "0～255 "
        '
        'txtAlphaValue
        '
        Me.txtAlphaValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtAlphaValue.Location = New System.Drawing.Point(106, 38)
        Me.txtAlphaValue.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAlphaValue.MaxValue = 255.0R
        Me.txtAlphaValue.MaxValueFlag = True
        Me.txtAlphaValue.MinValue = 0.0R
        Me.txtAlphaValue.MinValueFlag = True
        Me.txtAlphaValue.Name = "txtAlphaValue"
        Me.txtAlphaValue.NumberPoint = False
        Me.txtAlphaValue.Size = New System.Drawing.Size(71, 19)
        Me.txtAlphaValue.TabIndex = 4
        Me.txtAlphaValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAlphaValue.ValueErrorMessageFlag = True
        '
        'frmAlphaValueSet
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(223, 94)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAlphaValue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAlphaValueSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "透過度設定"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtAlphaValue As mandara10.TextNumberBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents hsbTransparency As System.Windows.Forms.HScrollBar
End Class
