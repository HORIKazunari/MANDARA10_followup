<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_LineKindTimeSet
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
        Me.lbLineList = New System.Windows.Forms.ListBox()
        Me.gbTimeRef = New System.Windows.Forms.GroupBox()
        Me.btnSetRef = New System.Windows.Forms.Button()
        Me.lbTimeRef = New System.Windows.Forms.ListBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dbdtpEndTime = New mandara10.DbDateTimePicker()
        Me.dbdtpStartTime = New mandara10.DbDateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboLineKind = New mandara10.ComboBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbTimeRef.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(340, 317)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(265, 317)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lbLineList
        '
        Me.lbLineList.FormattingEnabled = True
        Me.lbLineList.ItemHeight = 12
        Me.lbLineList.Location = New System.Drawing.Point(12, 24)
        Me.lbLineList.Name = "lbLineList"
        Me.lbLineList.Size = New System.Drawing.Size(404, 76)
        Me.lbLineList.TabIndex = 0
        '
        'gbTimeRef
        '
        Me.gbTimeRef.Controls.Add(Me.btnSetRef)
        Me.gbTimeRef.Controls.Add(Me.lbTimeRef)
        Me.gbTimeRef.Location = New System.Drawing.Point(12, 115)
        Me.gbTimeRef.Name = "gbTimeRef"
        Me.gbTimeRef.Size = New System.Drawing.Size(194, 175)
        Me.gbTimeRef.TabIndex = 1
        Me.gbTimeRef.TabStop = False
        Me.gbTimeRef.Text = "期間参照"
        '
        'btnSetRef
        '
        Me.btnSetRef.Location = New System.Drawing.Point(113, 139)
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
        Me.lbTimeRef.Size = New System.Drawing.Size(165, 112)
        Me.lbTimeRef.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dbdtpEndTime)
        Me.GroupBox4.Controls.Add(Me.dbdtpStartTime)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(217, 184)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(199, 77)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "時期設定"
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
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(324, 273)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(85, 24)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(217, 273)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 24)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "期間追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboLineKind)
        Me.GroupBox1.Location = New System.Drawing.Point(217, 115)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(199, 63)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "線種設定"
        '
        'cboLineKind
        '
        Me.cboLineKind.AsteriskSelectEnabled = False
        Me.cboLineKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLineKind.FormattingEnabled = True
        Me.cboLineKind.IntegralHeight = False
        Me.cboLineKind.Location = New System.Drawing.Point(21, 27)
        Me.cboLineKind.Name = "cboLineKind"
        Me.cboLineKind.Size = New System.Drawing.Size(165, 20)
        Me.cboLineKind.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "設定一覧"
        '
        'frmMED_LineKindTimeSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(426, 353)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.gbTimeRef)
        Me.Controls.Add(Me.lbLineList)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_LineKindTimeSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ラインの線種と期間設定"
        Me.gbTimeRef.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lbLineList As System.Windows.Forms.ListBox
    Friend WithEvents gbTimeRef As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetRef As System.Windows.Forms.Button
    Friend WithEvents lbTimeRef As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dbdtpEndTime As mandara10.DbDateTimePicker
    Friend WithEvents dbdtpStartTime As mandara10.DbDateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLineKind As mandara10.ComboBoxEx
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
