<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMakeLineBrokenPattern
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
        Me.lblUseParts = New System.Windows.Forms.Label()
        Me.lblPartLenth = New System.Windows.Forms.Label()
        Me.lblPartsPrint = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.lblPartsWidth = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblUseParts
        '
        Me.lblUseParts.AutoSize = True
        Me.lblUseParts.Location = New System.Drawing.Point(76, 18)
        Me.lblUseParts.Name = "lblUseParts"
        Me.lblUseParts.Size = New System.Drawing.Size(61, 15)
        Me.lblUseParts.TabIndex = 0
        Me.lblUseParts.Text = "使用する"
        '
        'lblPartLenth
        '
        Me.lblPartLenth.AutoSize = True
        Me.lblPartLenth.Location = New System.Drawing.Point(156, 18)
        Me.lblPartLenth.Name = "lblPartLenth"
        Me.lblPartLenth.Size = New System.Drawing.Size(50, 15)
        Me.lblPartLenth.TabIndex = 1
        Me.lblPartLenth.Text = "長さ(%)"
        '
        'lblPartsPrint
        '
        Me.lblPartsPrint.AutoSize = True
        Me.lblPartsPrint.Location = New System.Drawing.Point(238, 18)
        Me.lblPartsPrint.Name = "lblPartsPrint"
        Me.lblPartsPrint.Size = New System.Drawing.Size(37, 15)
        Me.lblPartsPrint.TabIndex = 2
        Me.lblPartsPrint.Text = "空白"
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(290, 18)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(22, 15)
        Me.lblColor.TabIndex = 3
        Me.lblColor.Text = "色"
        '
        'lblPartsWidth
        '
        Me.lblPartsWidth.AutoSize = True
        Me.lblPartsWidth.Location = New System.Drawing.Point(353, 18)
        Me.lblPartsWidth.Name = "lblPartsWidth"
        Me.lblPartsWidth.Size = New System.Drawing.Size(40, 15)
        Me.lblPartsWidth.TabIndex = 4
        Me.lblPartsWidth.Text = "幅(%)"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(220, 258)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(83, 30)
        Me.btnOK.TabIndex = 21
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(324, 258)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 30)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmMakeLineBrokenPattern
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 298)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblPartsWidth)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.lblPartsPrint)
        Me.Controls.Add(Me.lblPartLenth)
        Me.Controls.Add(Me.lblUseParts)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMakeLineBrokenPattern"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ラインパターン／破線設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUseParts As System.Windows.Forms.Label
    Friend WithEvents lblPartLenth As System.Windows.Forms.Label
    Friend WithEvents lblPartsPrint As System.Windows.Forms.Label
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents lblPartsWidth As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
