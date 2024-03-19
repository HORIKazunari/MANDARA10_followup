<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_ReplaceObjectName
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearchStrings = New System.Windows.Forms.TextBox()
        Me.txtReplaceStrings = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbList = New System.Windows.Forms.ListBox()
        Me.gbObjGroupEdit = New System.Windows.Forms.GroupBox()
        Me.btnReplace = New System.Windows.Forms.Button()
        Me.btnReplaceAll = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.clbObjectKind = New mandara10.CheckedListBoxEx()
        Me.gbObjGroupEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCancel.Location = New System.Drawing.Point(256, 284)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "終了"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(182, 23)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(52, 19)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "検索"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "検索文字列"
        '
        'txtSearchStrings
        '
        Me.txtSearchStrings.Location = New System.Drawing.Point(21, 23)
        Me.txtSearchStrings.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearchStrings.Name = "txtSearchStrings"
        Me.txtSearchStrings.Size = New System.Drawing.Size(156, 19)
        Me.txtSearchStrings.TabIndex = 0
        '
        'txtReplaceStrings
        '
        Me.txtReplaceStrings.Location = New System.Drawing.Point(21, 63)
        Me.txtReplaceStrings.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReplaceStrings.Name = "txtReplaceStrings"
        Me.txtReplaceStrings.Size = New System.Drawing.Size(156, 19)
        Me.txtReplaceStrings.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 49)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "置換文字列"
        '
        'lbList
        '
        Me.lbList.FormattingEnabled = True
        Me.lbList.ItemHeight = 12
        Me.lbList.Location = New System.Drawing.Point(182, 64)
        Me.lbList.Name = "lbList"
        Me.lbList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbList.Size = New System.Drawing.Size(156, 172)
        Me.lbList.TabIndex = 4
        '
        'gbObjGroupEdit
        '
        Me.gbObjGroupEdit.Controls.Add(Me.clbObjectKind)
        Me.gbObjGroupEdit.Location = New System.Drawing.Point(11, 97)
        Me.gbObjGroupEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjGroupEdit.Name = "gbObjGroupEdit"
        Me.gbObjGroupEdit.Padding = New System.Windows.Forms.Padding(10)
        Me.gbObjGroupEdit.Size = New System.Drawing.Size(165, 146)
        Me.gbObjGroupEdit.TabIndex = 3
        Me.gbObjGroupEdit.TabStop = False
        Me.gbObjGroupEdit.Text = "オブジェクトグループ"
        '
        'btnReplace
        '
        Me.btnReplace.Location = New System.Drawing.Point(182, 254)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(69, 24)
        Me.btnReplace.TabIndex = 5
        Me.btnReplace.Text = "置換"
        Me.btnReplace.UseVisualStyleBackColor = True
        '
        'btnReplaceAll
        '
        Me.btnReplaceAll.Location = New System.Drawing.Point(256, 254)
        Me.btnReplaceAll.Name = "btnReplaceAll"
        Me.btnReplaceAll.Size = New System.Drawing.Size(80, 24)
        Me.btnReplaceAll.TabIndex = 6
        Me.btnReplaceAll.Text = "すべて置換"
        Me.btnReplaceAll.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(180, 49)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "検索結果"
        '
        'clbObjectKind
        '
        Me.clbObjectKind.CheckOnClick = True
        Me.clbObjectKind.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbObjectKind.EventStop = False
        Me.clbObjectKind.FormattingEnabled = True
        Me.clbObjectKind.Location = New System.Drawing.Point(10, 22)
        Me.clbObjectKind.Margin = New System.Windows.Forms.Padding(2)
        Me.clbObjectKind.Name = "clbObjectKind"
        Me.clbObjectKind.Size = New System.Drawing.Size(145, 114)
        Me.clbObjectKind.TabIndex = 0
        '
        'frmMED_ReplaceObjectName
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(345, 321)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnReplaceAll)
        Me.Controls.Add(Me.btnReplace)
        Me.Controls.Add(Me.lbList)
        Me.Controls.Add(Me.gbObjGroupEdit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtReplaceStrings)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearchStrings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_ReplaceObjectName"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オブジェクト名の置換"
        Me.gbObjGroupEdit.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearchStrings As System.Windows.Forms.TextBox
    Friend WithEvents txtReplaceStrings As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbList As System.Windows.Forms.ListBox
    Friend WithEvents gbObjGroupEdit As System.Windows.Forms.GroupBox
    Friend WithEvents clbObjectKind As mandara10.CheckedListBoxEx
    Friend WithEvents btnReplace As System.Windows.Forms.Button
    Friend WithEvents btnReplaceAll As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
