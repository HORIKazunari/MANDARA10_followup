<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_LinkEdit
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
        Me.lbLink = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbLinkEdit = New System.Windows.Forms.GroupBox()
        Me.btnFileSelect = New System.Windows.Forms.Button()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnLinkAdd = New System.Windows.Forms.Button()
        Me.btnLinkDelete = New System.Windows.Forms.Button()
        Me.gbLinkEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(415, 176)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 27)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(348, 176)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 27)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lbLink
        '
        Me.lbLink.FormattingEnabled = True
        Me.lbLink.ItemHeight = 12
        Me.lbLink.Location = New System.Drawing.Point(11, 40)
        Me.lbLink.Margin = New System.Windows.Forms.Padding(2)
        Me.lbLink.Name = "lbLink"
        Me.lbLink.Size = New System.Drawing.Size(206, 88)
        Me.lbLink.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "リンク"
        '
        'gbLinkEdit
        '
        Me.gbLinkEdit.Controls.Add(Me.btnFileSelect)
        Me.gbLinkEdit.Controls.Add(Me.txtURL)
        Me.gbLinkEdit.Controls.Add(Me.Label3)
        Me.gbLinkEdit.Controls.Add(Me.Label2)
        Me.gbLinkEdit.Controls.Add(Me.txtName)
        Me.gbLinkEdit.Location = New System.Drawing.Point(238, 30)
        Me.gbLinkEdit.Name = "gbLinkEdit"
        Me.gbLinkEdit.Size = New System.Drawing.Size(239, 135)
        Me.gbLinkEdit.TabIndex = 3
        Me.gbLinkEdit.TabStop = False
        '
        'btnFileSelect
        '
        Me.btnFileSelect.Location = New System.Drawing.Point(140, 108)
        Me.btnFileSelect.Name = "btnFileSelect"
        Me.btnFileSelect.Size = New System.Drawing.Size(77, 21)
        Me.btnFileSelect.TabIndex = 2
        Me.btnFileSelect.Text = "ファイル参照"
        Me.btnFileSelect.UseVisualStyleBackColor = True
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(18, 81)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(199, 19)
        Me.txtURL.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 66)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 12)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "リンク先URLまたはファイル"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 15)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "リンクの名称"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(18, 30)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(199, 19)
        Me.txtName.TabIndex = 0
        '
        'btnLinkAdd
        '
        Me.btnLinkAdd.Location = New System.Drawing.Point(65, 138)
        Me.btnLinkAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLinkAdd.Name = "btnLinkAdd"
        Me.btnLinkAdd.Size = New System.Drawing.Size(74, 27)
        Me.btnLinkAdd.TabIndex = 1
        Me.btnLinkAdd.Text = "リンク追加"
        Me.btnLinkAdd.UseVisualStyleBackColor = True
        '
        'btnLinkDelete
        '
        Me.btnLinkDelete.Location = New System.Drawing.Point(143, 138)
        Me.btnLinkDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLinkDelete.Name = "btnLinkDelete"
        Me.btnLinkDelete.Size = New System.Drawing.Size(74, 27)
        Me.btnLinkDelete.TabIndex = 2
        Me.btnLinkDelete.Text = "リンク削除"
        Me.btnLinkDelete.UseVisualStyleBackColor = True
        '
        'frmPrint_LinkEdit
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(489, 212)
        Me.Controls.Add(Me.btnLinkAdd)
        Me.Controls.Add(Me.btnLinkDelete)
        Me.Controls.Add(Me.gbLinkEdit)
        Me.Controls.Add(Me.lbLink)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_LinkEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "リンク編集"
        Me.gbLinkEdit.ResumeLayout(False)
        Me.gbLinkEdit.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lbLink As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbLinkEdit As System.Windows.Forms.GroupBox
    Friend WithEvents btnFileSelect As System.Windows.Forms.Button
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents btnLinkAdd As System.Windows.Forms.Button
    Friend WithEvents btnLinkDelete As System.Windows.Forms.Button
End Class
