<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_ChengeLineKind_in_Multiobject
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
        Me.dgvComboBox = New mandara10.DataGridViewControlComboBox()
        Me.chkKyoyuLine = New System.Windows.Forms.CheckBox()
        CType(Me.dgvComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(166, 302)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(91, 302)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'dgvComboBox
        '
        Me.dgvComboBox.AllowUserToAddRows = False
        Me.dgvComboBox.AllowUserToDeleteRows = False
        Me.dgvComboBox.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgvComboBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComboBox.Location = New System.Drawing.Point(13, 22)
        Me.dgvComboBox.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvComboBox.Name = "dgvComboBox"
        Me.dgvComboBox.RowTemplate.Height = 24
        Me.dgvComboBox.Size = New System.Drawing.Size(222, 230)
        Me.dgvComboBox.TabIndex = 14
        '
        'chkKyoyuLine
        '
        Me.chkKyoyuLine.AutoSize = True
        Me.chkKyoyuLine.Checked = True
        Me.chkKyoyuLine.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKyoyuLine.Location = New System.Drawing.Point(15, 267)
        Me.chkKyoyuLine.Margin = New System.Windows.Forms.Padding(2)
        Me.chkKyoyuLine.Name = "chkKyoyuLine"
        Me.chkKyoyuLine.Size = New System.Drawing.Size(141, 16)
        Me.chkKyoyuLine.TabIndex = 15
        Me.chkKyoyuLine.Text = "共有ラインの線種も変更"
        Me.chkKyoyuLine.UseVisualStyleBackColor = True
        '
        'frmMED_ChengeLineKind_in_Multiobject
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(249, 332)
        Me.Controls.Add(Me.chkKyoyuLine)
        Me.Controls.Add(Me.dgvComboBox)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_ChengeLineKind_in_Multiobject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オブジェクトの使用線種変更"
        CType(Me.dgvComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents dgvComboBox As mandara10.DataGridViewControlComboBox
    Friend WithEvents chkKyoyuLine As System.Windows.Forms.CheckBox
End Class
