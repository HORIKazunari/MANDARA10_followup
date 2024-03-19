<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_ObjectSuccession
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
        Me.btnSetRef = New System.Windows.Forms.Button()
        Me.lbTimeRef = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSetObjRef = New System.Windows.Forms.Button()
        Me.lbObjRef = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ddtpTime = New mandara10.DbDateTimePicker()
        Me.lblObjSet = New System.Windows.Forms.Button()
        Me.lblObjName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbList = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(350, 345)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(275, 345)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSetRef)
        Me.GroupBox1.Controls.Add(Me.lbTimeRef)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(175, 153)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "時期参照"
        '
        'btnSetRef
        '
        Me.btnSetRef.Location = New System.Drawing.Point(100, 124)
        Me.btnSetRef.Name = "btnSetRef"
        Me.btnSetRef.Size = New System.Drawing.Size(63, 21)
        Me.btnSetRef.TabIndex = 1
        Me.btnSetRef.Text = "設定する"
        Me.btnSetRef.UseVisualStyleBackColor = True
        '
        'lbTimeRef
        '
        Me.lbTimeRef.FormattingEnabled = True
        Me.lbTimeRef.ItemHeight = 12
        Me.lbTimeRef.Location = New System.Drawing.Point(11, 18)
        Me.lbTimeRef.Name = "lbTimeRef"
        Me.lbTimeRef.Size = New System.Drawing.Size(152, 100)
        Me.lbTimeRef.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSetObjRef)
        Me.GroupBox2.Controls.Add(Me.lbObjRef)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 179)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(175, 150)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "オブジェクト参照"
        '
        'btnSetObjRef
        '
        Me.btnSetObjRef.Location = New System.Drawing.Point(100, 123)
        Me.btnSetObjRef.Name = "btnSetObjRef"
        Me.btnSetObjRef.Size = New System.Drawing.Size(63, 21)
        Me.btnSetObjRef.TabIndex = 1
        Me.btnSetObjRef.Text = "設定する"
        Me.btnSetObjRef.UseVisualStyleBackColor = True
        '
        'lbObjRef
        '
        Me.lbObjRef.FormattingEnabled = True
        Me.lbObjRef.ItemHeight = 12
        Me.lbObjRef.Location = New System.Drawing.Point(11, 17)
        Me.lbObjRef.Name = "lbObjRef"
        Me.lbObjRef.Size = New System.Drawing.Size(152, 100)
        Me.lbObjRef.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.ddtpTime)
        Me.GroupBox3.Controls.Add(Me.lblObjSet)
        Me.GroupBox3.Controls.Add(Me.lblObjName)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(197, 117)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(222, 152)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "設定"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "継承時期"
        '
        'ddtpTime
        '
        Me.ddtpTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ddtpTime.Location = New System.Drawing.Point(29, 108)
        Me.ddtpTime.Name = "ddtpTime"
        Me.ddtpTime.ShowCheckBox = True
        Me.ddtpTime.Size = New System.Drawing.Size(144, 19)
        Me.ddtpTime.TabIndex = 4
        '
        'lblObjSet
        '
        Me.lblObjSet.Location = New System.Drawing.Point(110, 65)
        Me.lblObjSet.Name = "lblObjSet"
        Me.lblObjSet.Size = New System.Drawing.Size(93, 21)
        Me.lblObjSet.TabIndex = 3
        Me.lblObjSet.Text = "オブジェクト設定"
        Me.lblObjSet.UseVisualStyleBackColor = True
        '
        'lblObjName
        '
        Me.lblObjName.BackColor = System.Drawing.Color.White
        Me.lblObjName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblObjName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjName.Location = New System.Drawing.Point(16, 43)
        Me.lblObjName.Name = "lblObjName"
        Me.lblObjName.Size = New System.Drawing.Size(187, 19)
        Me.lblObjName.TabIndex = 1
        Me.lblObjName.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "継承先オブジェクト"
        '
        'lbList
        '
        Me.lbList.FormattingEnabled = True
        Me.lbList.ItemHeight = 12
        Me.lbList.Location = New System.Drawing.Point(197, 35)
        Me.lbList.Name = "lbList"
        Me.lbList.Size = New System.Drawing.Size(222, 76)
        Me.lbList.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(206, 285)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(93, 21)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "継承先追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(307, 285)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(93, 21)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "継承先削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(195, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "設定一覧"
        '
        'frmMED_ObjectSuccession
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(435, 381)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lbList)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_ObjectSuccession"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オブジェクトの継承先の設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetRef As System.Windows.Forms.Button
    Friend WithEvents lbTimeRef As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetObjRef As System.Windows.Forms.Button
    Friend WithEvents lbObjRef As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblObjSet As System.Windows.Forms.Button
    Friend WithEvents lblObjName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbList As System.Windows.Forms.ListBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents ddtpTime As mandara10.DbDateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
