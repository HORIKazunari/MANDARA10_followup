﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_LineCodeTime
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
        Me.btnSetSunRef = New System.Windows.Forms.Button()
        Me.lbSucRef = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSetRef = New System.Windows.Forms.Button()
        Me.lbTimeRef = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblLineNO = New System.Windows.Forms.Label()
        Me.btnSetLineRefTime = New System.Windows.Forms.Button()
        Me.lbLineRef = New System.Windows.Forms.ListBox()
        Me.lbList = New System.Windows.Forms.ListBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dbdtpEndTime = New mandara10.DbDateTimePicker()
        Me.dbdtpStartTime = New mandara10.DbDateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(556, 411)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(481, 411)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSetSunRef)
        Me.GroupBox1.Controls.Add(Me.lbSucRef)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(399, 151)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "オブジェクトの編入時期参照"
        '
        'btnSetSunRef
        '
        Me.btnSetSunRef.Location = New System.Drawing.Point(326, 124)
        Me.btnSetSunRef.Name = "btnSetSunRef"
        Me.btnSetSunRef.Size = New System.Drawing.Size(63, 21)
        Me.btnSetSunRef.TabIndex = 1
        Me.btnSetSunRef.Text = "設定する"
        Me.btnSetSunRef.UseVisualStyleBackColor = True
        '
        'lbSucRef
        '
        Me.lbSucRef.FormattingEnabled = True
        Me.lbSucRef.ItemHeight = 12
        Me.lbSucRef.Location = New System.Drawing.Point(11, 18)
        Me.lbSucRef.Name = "lbSucRef"
        Me.lbSucRef.Size = New System.Drawing.Size(378, 100)
        Me.lbSucRef.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSetRef)
        Me.GroupBox2.Controls.Add(Me.lbTimeRef)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 328)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 114)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "他のラインでの使用期間参照"
        '
        'btnSetRef
        '
        Me.btnSetRef.Location = New System.Drawing.Point(179, 85)
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
        Me.lbTimeRef.Size = New System.Drawing.Size(152, 88)
        Me.lbTimeRef.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblLineNO)
        Me.GroupBox3.Controls.Add(Me.btnSetLineRefTime)
        Me.GroupBox3.Controls.Add(Me.lbLineRef)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 169)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(399, 153)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ラインの有効期間参照"
        '
        'lblLineNO
        '
        Me.lblLineNO.AutoSize = True
        Me.lblLineNO.Location = New System.Drawing.Point(9, 29)
        Me.lblLineNO.Name = "lblLineNO"
        Me.lblLineNO.Size = New System.Drawing.Size(55, 12)
        Me.lblLineNO.TabIndex = 16
        Me.lblLineNO.Text = "ライン番号"
        '
        'btnSetLineRefTime
        '
        Me.btnSetLineRefTime.Location = New System.Drawing.Point(325, 126)
        Me.btnSetLineRefTime.Name = "btnSetLineRefTime"
        Me.btnSetLineRefTime.Size = New System.Drawing.Size(63, 21)
        Me.btnSetLineRefTime.TabIndex = 1
        Me.btnSetLineRefTime.Text = "設定する"
        Me.btnSetLineRefTime.UseVisualStyleBackColor = True
        '
        'lbLineRef
        '
        Me.lbLineRef.FormattingEnabled = True
        Me.lbLineRef.ItemHeight = 12
        Me.lbLineRef.Location = New System.Drawing.Point(11, 44)
        Me.lbLineRef.Name = "lbLineRef"
        Me.lbLineRef.Size = New System.Drawing.Size(377, 76)
        Me.lbLineRef.TabIndex = 0
        '
        'lbList
        '
        Me.lbList.FormattingEnabled = True
        Me.lbList.ItemHeight = 12
        Me.lbList.Location = New System.Drawing.Point(426, 30)
        Me.lbList.Name = "lbList"
        Me.lbList.Size = New System.Drawing.Size(199, 100)
        Me.lbList.TabIndex = 3
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(540, 244)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(85, 24)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(433, 244)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 24)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "期間追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dbdtpEndTime)
        Me.GroupBox4.Controls.Add(Me.dbdtpStartTime)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(426, 148)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(199, 77)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "期間設定"
        '
        'dbdtpEndTime
        '
        Me.dbdtpEndTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dbdtpEndTime.Location = New System.Drawing.Point(39, 42)
        Me.dbdtpEndTime.Name = "dbdtpEndTime"
        Me.dbdtpEndTime.ShowCheckBox = True
        Me.dbdtpEndTime.Size = New System.Drawing.Size(150, 19)
        Me.dbdtpEndTime.TabIndex = 4
        '
        'dbdtpStartTime
        '
        Me.dbdtpStartTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dbdtpStartTime.Location = New System.Drawing.Point(39, 17)
        Me.dbdtpStartTime.Name = "dbdtpStartTime"
        Me.dbdtpStartTime.ShowCheckBox = True
        Me.dbdtpStartTime.Size = New System.Drawing.Size(150, 19)
        Me.dbdtpStartTime.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 45)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "終了"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "開始"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(424, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "設定一覧"
        '
        'frmMED_LineCodeTime
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(644, 452)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.GroupBox4)
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
        Me.Name = "frmMED_LineCodeTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "使用ラインの期間設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetSunRef As System.Windows.Forms.Button
    Friend WithEvents lbSucRef As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetRef As System.Windows.Forms.Button
    Friend WithEvents lbTimeRef As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetLineRefTime As System.Windows.Forms.Button
    Friend WithEvents lbLineRef As System.Windows.Forms.ListBox
    Friend WithEvents lbList As System.Windows.Forms.ListBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dbdtpEndTime As mandara10.DbDateTimePicker
    Friend WithEvents dbdtpStartTime As mandara10.DbDateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLineNO As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class