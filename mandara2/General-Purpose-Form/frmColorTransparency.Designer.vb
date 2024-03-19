<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColorTransparency
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
        Me.txtAlpha = New mandara10.TextNumberBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.hsbTransparency = New System.Windows.Forms.HScrollBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAlpha
        '
        Me.txtAlpha.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtAlpha.Location = New System.Drawing.Point(174, 33)
        Me.txtAlpha.MaxValue = 255.0R
        Me.txtAlpha.MaxValueFlag = True
        Me.txtAlpha.MinValue = 0.0R
        Me.txtAlpha.MinValueFlag = True
        Me.txtAlpha.Name = "txtAlpha"
        Me.txtAlpha.NumberPoint = True
        Me.txtAlpha.Size = New System.Drawing.Size(50, 19)
        Me.txtAlpha.TabIndex = 21
        Me.txtAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAlpha.ValueErrorMessageFlag = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.hsbTransparency)
        Me.Panel1.Location = New System.Drawing.Point(73, 27)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(96, 25)
        Me.Panel1.TabIndex = 20
        '
        'hsbTransparency
        '
        Me.hsbTransparency.Dock = System.Windows.Forms.DockStyle.Top
        Me.hsbTransparency.LargeChange = 1
        Me.hsbTransparency.Location = New System.Drawing.Point(0, 0)
        Me.hsbTransparency.Maximum = 255
        Me.hsbTransparency.Name = "hsbTransparency"
        Me.hsbTransparency.Size = New System.Drawing.Size(94, 21)
        Me.hsbTransparency.TabIndex = 0
        Me.hsbTransparency.Value = 255
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 30)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "透過度"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(213, 71)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 26)
        Me.btnCancel.TabIndex = 24
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(146, 73)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 23
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmColorTransparency
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(284, 109)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtAlpha)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmColorTransparency"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "色の透過度設定"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAlpha As mandara10.TextNumberBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents hsbTransparency As System.Windows.Forms.HScrollBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
