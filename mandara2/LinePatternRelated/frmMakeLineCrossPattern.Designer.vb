<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMakeLineCrossPattern
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
        Me.lblPartsWidth = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.lblXPartsLength = New System.Windows.Forms.Label()
        Me.lblXPartsInterval = New System.Windows.Forms.Label()
        Me.lblUseParts = New System.Windows.Forms.Label()
        Me.lblXlineShape = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(247, 209)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 23
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(315, 209)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 24)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblPartsWidth
        '
        Me.lblPartsWidth.AutoSize = True
        Me.lblPartsWidth.Location = New System.Drawing.Point(314, 20)
        Me.lblPartsWidth.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPartsWidth.Name = "lblPartsWidth"
        Me.lblPartsWidth.Size = New System.Drawing.Size(73, 12)
        Me.lblPartsWidth.TabIndex = 28
        Me.lblPartsWidth.Text = "線幅(%)/記号"
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(278, 20)
        Me.lblColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(17, 12)
        Me.lblColor.TabIndex = 27
        Me.lblColor.Text = "色"
        '
        'lblXPartsLength
        '
        Me.lblXPartsLength.AutoSize = True
        Me.lblXPartsLength.Location = New System.Drawing.Point(202, 20)
        Me.lblXPartsLength.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblXPartsLength.Name = "lblXPartsLength"
        Me.lblXPartsLength.Size = New System.Drawing.Size(74, 12)
        Me.lblXPartsLength.TabIndex = 26
        Me.lblXPartsLength.Text = "長さ・大きさ(%)"
        '
        'lblXPartsInterval
        '
        Me.lblXPartsInterval.AutoSize = True
        Me.lblXPartsInterval.Location = New System.Drawing.Point(152, 20)
        Me.lblXPartsInterval.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblXPartsInterval.Name = "lblXPartsInterval"
        Me.lblXPartsInterval.Size = New System.Drawing.Size(43, 12)
        Me.lblXPartsInterval.TabIndex = 25
        Me.lblXPartsInterval.Text = "間隔(%)"
        '
        'lblUseParts
        '
        Me.lblUseParts.AutoSize = True
        Me.lblUseParts.Location = New System.Drawing.Point(46, 20)
        Me.lblUseParts.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUseParts.Name = "lblUseParts"
        Me.lblUseParts.Size = New System.Drawing.Size(48, 12)
        Me.lblUseParts.TabIndex = 24
        Me.lblUseParts.Text = "使用する"
        '
        'lblXlineShape
        '
        Me.lblXlineShape.AutoSize = True
        Me.lblXlineShape.Location = New System.Drawing.Point(103, 20)
        Me.lblXlineShape.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblXlineShape.Name = "lblXlineShape"
        Me.lblXlineShape.Size = New System.Drawing.Size(29, 12)
        Me.lblXlineShape.TabIndex = 29
        Me.lblXlineShape.Text = "形状"
        '
        'frmMakeLineCrossPattern
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 244)
        Me.Controls.Add(Me.lblXlineShape)
        Me.Controls.Add(Me.lblPartsWidth)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.lblXPartsLength)
        Me.Controls.Add(Me.lblXPartsInterval)
        Me.Controls.Add(Me.lblUseParts)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMakeLineCrossPattern"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ラインパターン／交差線・円・記号設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblPartsWidth As System.Windows.Forms.Label
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents lblXPartsLength As System.Windows.Forms.Label
    Friend WithEvents lblXPartsInterval As System.Windows.Forms.Label
    Friend WithEvents lblUseParts As System.Windows.Forms.Label
    Friend WithEvents lblXlineShape As System.Windows.Forms.Label
End Class
