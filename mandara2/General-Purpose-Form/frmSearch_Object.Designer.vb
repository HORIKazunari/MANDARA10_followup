<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch_Object
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.gbObjTypeEdit = New System.Windows.Forms.GroupBox()
        Me.rbObjTypeEditAggregation = New System.Windows.Forms.RadioButton()
        Me.rbObjTypeEditNormal = New System.Windows.Forms.RadioButton()
        Me.gbObjGroupEdit = New System.Windows.Forms.GroupBox()
        Me.clbObjectKindEdit = New mandara10.CheckedListBoxEx()
        Me.gbObjShapeEdit = New System.Windows.Forms.GroupBox()
        Me.cbPolygonShapeEdit = New System.Windows.Forms.CheckBox()
        Me.cbLineShapeEdit = New System.Windows.Forms.CheckBox()
        Me.cbPointShapeEdit = New System.Windows.Forms.CheckBox()
        Me.gbTime = New System.Windows.Forms.GroupBox()
        Me.dbdtpTime = New mandara10.DbDateTimePicker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lbList = New mandara10.ListBoxEx()
        Me.gbObjTypeEdit.SuspendLayout()
        Me.gbObjGroupEdit.SuspendLayout()
        Me.gbObjShapeEdit.SuspendLayout()
        Me.gbTime.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(317, 397)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(242, 397)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "検索するオブジェクト名を入力してください"
        '
        'tbName
        '
        Me.tbName.Location = New System.Drawing.Point(13, 43)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(179, 19)
        Me.tbName.TabIndex = 1
        '
        'gbObjTypeEdit
        '
        Me.gbObjTypeEdit.Controls.Add(Me.rbObjTypeEditAggregation)
        Me.gbObjTypeEdit.Controls.Add(Me.rbObjTypeEditNormal)
        Me.gbObjTypeEdit.Location = New System.Drawing.Point(11, 73)
        Me.gbObjTypeEdit.Margin = New System.Windows.Forms.Padding(2, 8, 2, 2)
        Me.gbObjTypeEdit.Name = "gbObjTypeEdit"
        Me.gbObjTypeEdit.Padding = New System.Windows.Forms.Padding(2)
        Me.gbObjTypeEdit.Size = New System.Drawing.Size(175, 48)
        Me.gbObjTypeEdit.TabIndex = 3
        Me.gbObjTypeEdit.TabStop = False
        Me.gbObjTypeEdit.Text = "オブジェクトのタイプ"
        '
        'rbObjTypeEditAggregation
        '
        Me.rbObjTypeEditAggregation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbObjTypeEditAggregation.AutoSize = True
        Me.rbObjTypeEditAggregation.Location = New System.Drawing.Point(71, 21)
        Me.rbObjTypeEditAggregation.Margin = New System.Windows.Forms.Padding(2)
        Me.rbObjTypeEditAggregation.Name = "rbObjTypeEditAggregation"
        Me.rbObjTypeEditAggregation.Size = New System.Drawing.Size(47, 16)
        Me.rbObjTypeEditAggregation.TabIndex = 1
        Me.rbObjTypeEditAggregation.Text = "集成"
        Me.rbObjTypeEditAggregation.UseVisualStyleBackColor = True
        '
        'rbObjTypeEditNormal
        '
        Me.rbObjTypeEditNormal.AutoSize = True
        Me.rbObjTypeEditNormal.Checked = True
        Me.rbObjTypeEditNormal.Location = New System.Drawing.Point(10, 21)
        Me.rbObjTypeEditNormal.Margin = New System.Windows.Forms.Padding(2)
        Me.rbObjTypeEditNormal.Name = "rbObjTypeEditNormal"
        Me.rbObjTypeEditNormal.Size = New System.Drawing.Size(47, 16)
        Me.rbObjTypeEditNormal.TabIndex = 0
        Me.rbObjTypeEditNormal.TabStop = True
        Me.rbObjTypeEditNormal.Text = "通常"
        Me.rbObjTypeEditNormal.UseVisualStyleBackColor = True
        '
        'gbObjGroupEdit
        '
        Me.gbObjGroupEdit.Controls.Add(Me.clbObjectKindEdit)
        Me.gbObjGroupEdit.Location = New System.Drawing.Point(11, 207)
        Me.gbObjGroupEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjGroupEdit.Name = "gbObjGroupEdit"
        Me.gbObjGroupEdit.Padding = New System.Windows.Forms.Padding(10)
        Me.gbObjGroupEdit.Size = New System.Drawing.Size(175, 146)
        Me.gbObjGroupEdit.TabIndex = 5
        Me.gbObjGroupEdit.TabStop = False
        Me.gbObjGroupEdit.Text = "オブジェクトグループ"
        '
        'clbObjectKindEdit
        '
        Me.clbObjectKindEdit.CheckOnClick = True
        Me.clbObjectKindEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbObjectKindEdit.EventStop = False
        Me.clbObjectKindEdit.FormattingEnabled = True
        Me.clbObjectKindEdit.Location = New System.Drawing.Point(10, 22)
        Me.clbObjectKindEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.clbObjectKindEdit.Name = "clbObjectKindEdit"
        Me.clbObjectKindEdit.Size = New System.Drawing.Size(155, 114)
        Me.clbObjectKindEdit.TabIndex = 0
        '
        'gbObjShapeEdit
        '
        Me.gbObjShapeEdit.Controls.Add(Me.cbPolygonShapeEdit)
        Me.gbObjShapeEdit.Controls.Add(Me.cbLineShapeEdit)
        Me.gbObjShapeEdit.Controls.Add(Me.cbPointShapeEdit)
        Me.gbObjShapeEdit.Location = New System.Drawing.Point(11, 137)
        Me.gbObjShapeEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjShapeEdit.Name = "gbObjShapeEdit"
        Me.gbObjShapeEdit.Padding = New System.Windows.Forms.Padding(2)
        Me.gbObjShapeEdit.Size = New System.Drawing.Size(175, 50)
        Me.gbObjShapeEdit.TabIndex = 4
        Me.gbObjShapeEdit.TabStop = False
        Me.gbObjShapeEdit.Text = "オブジェクトの形状"
        '
        'cbPolygonShapeEdit
        '
        Me.cbPolygonShapeEdit.AutoSize = True
        Me.cbPolygonShapeEdit.Checked = True
        Me.cbPolygonShapeEdit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPolygonShapeEdit.Location = New System.Drawing.Point(113, 23)
        Me.cbPolygonShapeEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbPolygonShapeEdit.Name = "cbPolygonShapeEdit"
        Me.cbPolygonShapeEdit.Size = New System.Drawing.Size(36, 16)
        Me.cbPolygonShapeEdit.TabIndex = 2
        Me.cbPolygonShapeEdit.Text = "面"
        Me.cbPolygonShapeEdit.UseVisualStyleBackColor = True
        '
        'cbLineShapeEdit
        '
        Me.cbLineShapeEdit.AutoSize = True
        Me.cbLineShapeEdit.Checked = True
        Me.cbLineShapeEdit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbLineShapeEdit.Location = New System.Drawing.Point(60, 23)
        Me.cbLineShapeEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbLineShapeEdit.Name = "cbLineShapeEdit"
        Me.cbLineShapeEdit.Size = New System.Drawing.Size(36, 16)
        Me.cbLineShapeEdit.TabIndex = 1
        Me.cbLineShapeEdit.Text = "線"
        Me.cbLineShapeEdit.UseVisualStyleBackColor = True
        '
        'cbPointShapeEdit
        '
        Me.cbPointShapeEdit.AutoSize = True
        Me.cbPointShapeEdit.Checked = True
        Me.cbPointShapeEdit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPointShapeEdit.Location = New System.Drawing.Point(10, 23)
        Me.cbPointShapeEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.cbPointShapeEdit.Name = "cbPointShapeEdit"
        Me.cbPointShapeEdit.Size = New System.Drawing.Size(36, 16)
        Me.cbPointShapeEdit.TabIndex = 0
        Me.cbPointShapeEdit.Text = "点"
        Me.cbPointShapeEdit.UseVisualStyleBackColor = True
        '
        'gbTime
        '
        Me.gbTime.Controls.Add(Me.dbdtpTime)
        Me.gbTime.Location = New System.Drawing.Point(11, 356)
        Me.gbTime.Margin = New System.Windows.Forms.Padding(2)
        Me.gbTime.Name = "gbTime"
        Me.gbTime.Padding = New System.Windows.Forms.Padding(2)
        Me.gbTime.Size = New System.Drawing.Size(175, 65)
        Me.gbTime.TabIndex = 6
        Me.gbTime.TabStop = False
        Me.gbTime.Text = "時期限定"
        '
        'dbdtpTime
        '
        Me.dbdtpTime.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.dbdtpTime.Location = New System.Drawing.Point(16, 26)
        Me.dbdtpTime.Margin = New System.Windows.Forms.Padding(2)
        Me.dbdtpTime.Name = "dbdtpTime"
        Me.dbdtpTime.ShowCheckBox = True
        Me.dbdtpTime.Size = New System.Drawing.Size(130, 19)
        Me.dbdtpTime.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(196, 39)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(62, 25)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "検索"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lbList
        '
        Me.lbList.AsteriskSelectEnabled = False
        Me.lbList.FormattingEnabled = True
        Me.lbList.ItemHeight = 12
        Me.lbList.Location = New System.Drawing.Point(196, 73)
        Me.lbList.Margin = New System.Windows.Forms.Padding(2)
        Me.lbList.Name = "lbList"
        Me.lbList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbList.Size = New System.Drawing.Size(191, 304)
        Me.lbList.TabIndex = 7
        '
        'frmSearch_Object
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(398, 440)
        Me.Controls.Add(Me.lbList)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.gbTime)
        Me.Controls.Add(Me.gbObjShapeEdit)
        Me.Controls.Add(Me.gbObjGroupEdit)
        Me.Controls.Add(Me.gbObjTypeEdit)
        Me.Controls.Add(Me.tbName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearch_Object"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オブジェクト検索"
        Me.gbObjTypeEdit.ResumeLayout(False)
        Me.gbObjTypeEdit.PerformLayout()
        Me.gbObjGroupEdit.ResumeLayout(False)
        Me.gbObjShapeEdit.ResumeLayout(False)
        Me.gbObjShapeEdit.PerformLayout()
        Me.gbTime.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbName As System.Windows.Forms.TextBox
    Friend WithEvents gbObjTypeEdit As System.Windows.Forms.GroupBox
    Friend WithEvents rbObjTypeEditAggregation As System.Windows.Forms.RadioButton
    Friend WithEvents rbObjTypeEditNormal As System.Windows.Forms.RadioButton
    Friend WithEvents gbObjGroupEdit As System.Windows.Forms.GroupBox
    Friend WithEvents clbObjectKindEdit As mandara10.CheckedListBoxEx
    Friend WithEvents gbObjShapeEdit As System.Windows.Forms.GroupBox
    Friend WithEvents cbPolygonShapeEdit As System.Windows.Forms.CheckBox
    Friend WithEvents cbLineShapeEdit As System.Windows.Forms.CheckBox
    Friend WithEvents cbPointShapeEdit As System.Windows.Forms.CheckBox
    Friend WithEvents gbTime As System.Windows.Forms.GroupBox
    Friend WithEvents dbdtpTime As mandara10.DbDateTimePicker
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lbList As mandara10.ListBoxEx
End Class
