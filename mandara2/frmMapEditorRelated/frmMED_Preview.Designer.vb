<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_Preview
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.gbObjGroupEdit = New System.Windows.Forms.GroupBox()
        Me.clbObjectKindEdit = New mandara10.CheckedListBoxEx()
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbObjGroupEdit.SuspendLayout()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnHelp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnSave)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCopy)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbObjGroupEdit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnOK)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.picMap)
        Me.SplitContainer1.Size = New System.Drawing.Size(731, 451)
        Me.SplitContainer1.SplitterDistance = 209
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 191)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(69, 24)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "画像保存"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(84, 191)
        Me.btnCopy.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(69, 24)
        Me.btnCopy.TabIndex = 3
        Me.btnCopy.Text = "コピー"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'gbObjGroupEdit
        '
        Me.gbObjGroupEdit.Controls.Add(Me.clbObjectKindEdit)
        Me.gbObjGroupEdit.Location = New System.Drawing.Point(2, 6)
        Me.gbObjGroupEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjGroupEdit.Name = "gbObjGroupEdit"
        Me.gbObjGroupEdit.Padding = New System.Windows.Forms.Padding(5)
        Me.gbObjGroupEdit.Size = New System.Drawing.Size(152, 147)
        Me.gbObjGroupEdit.TabIndex = 0
        Me.gbObjGroupEdit.TabStop = False
        Me.gbObjGroupEdit.Text = "オブジェクトグループ"
        '
        'clbObjectKindEdit
        '
        Me.clbObjectKindEdit.CheckOnClick = True
        Me.clbObjectKindEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbObjectKindEdit.EventStop = False
        Me.clbObjectKindEdit.FormattingEnabled = True
        Me.clbObjectKindEdit.Location = New System.Drawing.Point(5, 17)
        Me.clbObjectKindEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.clbObjectKindEdit.Name = "clbObjectKindEdit"
        Me.clbObjectKindEdit.Size = New System.Drawing.Size(142, 125)
        Me.clbObjectKindEdit.TabIndex = 0
        '
        'DateTimePicker
        '
        Me.DateTimePicker.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.DateTimePicker.Location = New System.Drawing.Point(21, 157)
        Me.DateTimePicker.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.Size = New System.Drawing.Size(108, 19)
        Me.DateTimePicker.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(84, 230)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "閉じる"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'picMap
        '
        Me.picMap.BackColor = System.Drawing.Color.White
        Me.picMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picMap.Location = New System.Drawing.Point(0, 0)
        Me.picMap.Margin = New System.Windows.Forms.Padding(2)
        Me.picMap.Name = "picMap"
        Me.picMap.Size = New System.Drawing.Size(519, 451)
        Me.picMap.TabIndex = 0
        Me.picMap.TabStop = False
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(12, 233)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(30, 21)
        Me.btnHelp.TabIndex = 9
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmMED_Preview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 451)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimizeBox = False
        Me.Name = "frmMED_Preview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "マップエディタプレビュー"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbObjGroupEdit.ResumeLayout(False)
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents DateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbObjGroupEdit As System.Windows.Forms.GroupBox
    Friend WithEvents clbObjectKindEdit As mandara10.CheckedListBoxEx
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
End Class
