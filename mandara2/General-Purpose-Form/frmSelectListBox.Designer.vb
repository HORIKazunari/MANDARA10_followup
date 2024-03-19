<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectListBox
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
        Me.components = New System.ComponentModel.Container()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.CheckedListBoxEx = New mandara10.CheckedListBoxEx()
        Me.ListBoxEx = New mandara10.ListBoxEx()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(65, 260)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(144, 260)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'CheckedListBoxEx
        '
        Me.CheckedListBoxEx.CheckOnClick = True
        Me.CheckedListBoxEx.EventStop = False
        Me.CheckedListBoxEx.FormattingEnabled = True
        Me.CheckedListBoxEx.Location = New System.Drawing.Point(13, 13)
        Me.CheckedListBoxEx.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckedListBoxEx.Name = "CheckedListBoxEx"
        Me.CheckedListBoxEx.Size = New System.Drawing.Size(186, 228)
        Me.CheckedListBoxEx.TabIndex = 20
        '
        'ListBoxEx
        '
        Me.ListBoxEx.AsteriskSelectEnabled = False
        Me.ListBoxEx.FormattingEnabled = True
        Me.ListBoxEx.ItemHeight = 12
        Me.ListBoxEx.Location = New System.Drawing.Point(13, 13)
        Me.ListBoxEx.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBoxEx.Name = "ListBoxEx"
        Me.ListBoxEx.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBoxEx.Size = New System.Drawing.Size(188, 232)
        Me.ListBoxEx.TabIndex = 19
        '
        'frmSelectListBox
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(217, 295)
        Me.Controls.Add(Me.CheckedListBoxEx)
        Me.Controls.Add(Me.ListBoxEx)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectListBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmSelectListBox"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ListBoxEx As mandara10.ListBoxEx
    Friend WithEvents CheckedListBoxEx As mandara10.CheckedListBoxEx
End Class
