<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_AggrObjSet
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboUpperClassObjK = New System.Windows.Forms.ComboBox()
        Me.オブジェクト = New System.Windows.Forms.GroupBox()
        Me.btnObjSelect = New System.Windows.Forms.Button()
        Me.lblObjName = New System.Windows.Forms.Label()
        Me.rbNewObject = New System.Windows.Forms.RadioButton()
        Me.rbAddExistedObject = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.オブジェクト.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(234, 209)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(159, 209)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboUpperClassObjK)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(227, 60)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "上位オブジェクトグループ"
        '
        'cboUpperClassObjK
        '
        Me.cboUpperClassObjK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUpperClassObjK.FormattingEnabled = True
        Me.cboUpperClassObjK.Location = New System.Drawing.Point(20, 22)
        Me.cboUpperClassObjK.Name = "cboUpperClassObjK"
        Me.cboUpperClassObjK.Size = New System.Drawing.Size(164, 20)
        Me.cboUpperClassObjK.TabIndex = 0
        '
        'オブジェクト
        '
        Me.オブジェクト.Controls.Add(Me.btnObjSelect)
        Me.オブジェクト.Controls.Add(Me.lblObjName)
        Me.オブジェクト.Controls.Add(Me.rbNewObject)
        Me.オブジェクト.Controls.Add(Me.rbAddExistedObject)
        Me.オブジェクト.Location = New System.Drawing.Point(20, 78)
        Me.オブジェクト.Name = "オブジェクト"
        Me.オブジェクト.Size = New System.Drawing.Size(283, 116)
        Me.オブジェクト.TabIndex = 1
        Me.オブジェクト.TabStop = False
        Me.オブジェクト.Text = "オブジェクト"
        '
        'btnObjSelect
        '
        Me.btnObjSelect.Location = New System.Drawing.Point(217, 41)
        Me.btnObjSelect.Name = "btnObjSelect"
        Me.btnObjSelect.Size = New System.Drawing.Size(49, 23)
        Me.btnObjSelect.TabIndex = 3
        Me.btnObjSelect.Text = "選択"
        Me.btnObjSelect.UseVisualStyleBackColor = True
        '
        'lblObjName
        '
        Me.lblObjName.BackColor = System.Drawing.Color.White
        Me.lblObjName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblObjName.Location = New System.Drawing.Point(40, 39)
        Me.lblObjName.Name = "lblObjName"
        Me.lblObjName.Size = New System.Drawing.Size(168, 23)
        Me.lblObjName.TabIndex = 2
        Me.lblObjName.Text = "Label1"
        Me.lblObjName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rbNewObject
        '
        Me.rbNewObject.AutoSize = True
        Me.rbNewObject.Location = New System.Drawing.Point(25, 82)
        Me.rbNewObject.Name = "rbNewObject"
        Me.rbNewObject.Size = New System.Drawing.Size(98, 16)
        Me.rbNewObject.TabIndex = 1
        Me.rbNewObject.Text = "新規オブジェクト"
        Me.rbNewObject.UseVisualStyleBackColor = True
        '
        'rbAddExistedObject
        '
        Me.rbAddExistedObject.AutoSize = True
        Me.rbAddExistedObject.Location = New System.Drawing.Point(25, 20)
        Me.rbAddExistedObject.Name = "rbAddExistedObject"
        Me.rbAddExistedObject.Size = New System.Drawing.Size(131, 16)
        Me.rbAddExistedObject.TabIndex = 0
        Me.rbAddExistedObject.Text = "既存オブジェクトに追加"
        Me.rbAddExistedObject.UseVisualStyleBackColor = True
        '
        'frmMED_AggrObjSet
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(315, 243)
        Me.Controls.Add(Me.オブジェクト)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_AggrObjSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "集成オブジェクトに設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.オブジェクト.ResumeLayout(False)
        Me.オブジェクト.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboUpperClassObjK As System.Windows.Forms.ComboBox
    Friend WithEvents オブジェクト As System.Windows.Forms.GroupBox
    Friend WithEvents btnObjSelect As System.Windows.Forms.Button
    Friend WithEvents lblObjName As System.Windows.Forms.Label
    Friend WithEvents rbNewObject As System.Windows.Forms.RadioButton
    Friend WithEvents rbAddExistedObject As System.Windows.Forms.RadioButton
End Class
