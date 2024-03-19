<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_DefTimeAttDataObjectEdit
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
        Me.gbTimeRef = New System.Windows.Forms.GroupBox()
        Me.btnSetRef = New System.Windows.Forms.Button()
        Me.lbTimeRef = New System.Windows.Forms.ListBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.gbSetting = New System.Windows.Forms.GroupBox()
        Me.ddtpTime2 = New mandara10.DbDateTimePicker()
        Me.lblTime2 = New System.Windows.Forms.Label()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.lblTime1 = New System.Windows.Forms.Label()
        Me.ddtpTime1 = New mandara10.DbDateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lbList = New System.Windows.Forms.ListBox()
        Me.初期時間属性データ項目 = New System.Windows.Forms.GroupBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblMissing = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lbObjName = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbTimeRef.SuspendLayout()
        Me.gbSetting.SuspendLayout()
        Me.初期時間属性データ項目.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTimeRef
        '
        Me.gbTimeRef.Controls.Add(Me.btnSetRef)
        Me.gbTimeRef.Controls.Add(Me.lbTimeRef)
        Me.gbTimeRef.Location = New System.Drawing.Point(313, 173)
        Me.gbTimeRef.Name = "gbTimeRef"
        Me.gbTimeRef.Size = New System.Drawing.Size(222, 116)
        Me.gbTimeRef.TabIndex = 3
        Me.gbTimeRef.TabStop = False
        Me.gbTimeRef.Text = "時期参照"
        '
        'btnSetRef
        '
        Me.btnSetRef.Location = New System.Drawing.Point(142, 88)
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
        Me.lbTimeRef.Size = New System.Drawing.Size(194, 64)
        Me.lbTimeRef.TabIndex = 0
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(425, 423)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(93, 21)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "値削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(326, 423)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(93, 21)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "値追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'gbSetting
        '
        Me.gbSetting.Controls.Add(Me.ddtpTime2)
        Me.gbSetting.Controls.Add(Me.lblTime2)
        Me.gbSetting.Controls.Add(Me.txtValue)
        Me.gbSetting.Controls.Add(Me.lblTime1)
        Me.gbSetting.Controls.Add(Me.ddtpTime1)
        Me.gbSetting.Controls.Add(Me.Label1)
        Me.gbSetting.Location = New System.Drawing.Point(313, 295)
        Me.gbSetting.Name = "gbSetting"
        Me.gbSetting.Size = New System.Drawing.Size(222, 119)
        Me.gbSetting.TabIndex = 4
        Me.gbSetting.TabStop = False
        Me.gbSetting.Text = "設定"
        '
        'ddtpTime2
        '
        Me.ddtpTime2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ddtpTime2.Location = New System.Drawing.Point(62, 90)
        Me.ddtpTime2.Name = "ddtpTime2"
        Me.ddtpTime2.ShowCheckBox = True
        Me.ddtpTime2.Size = New System.Drawing.Size(143, 19)
        Me.ddtpTime2.TabIndex = 3
        '
        'lblTime2
        '
        Me.lblTime2.AutoSize = True
        Me.lblTime2.Location = New System.Drawing.Point(13, 93)
        Me.lblTime2.Name = "lblTime2"
        Me.lblTime2.Size = New System.Drawing.Size(29, 12)
        Me.lblTime2.TabIndex = 7
        Me.lblTime2.Text = "終了"
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(61, 33)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(142, 19)
        Me.txtValue.TabIndex = 1
        '
        'lblTime1
        '
        Me.lblTime1.AutoSize = True
        Me.lblTime1.Location = New System.Drawing.Point(13, 70)
        Me.lblTime1.Name = "lblTime1"
        Me.lblTime1.Size = New System.Drawing.Size(29, 12)
        Me.lblTime1.TabIndex = 5
        Me.lblTime1.Text = "時期"
        '
        'ddtpTime1
        '
        Me.ddtpTime1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ddtpTime1.Location = New System.Drawing.Point(62, 65)
        Me.ddtpTime1.Name = "ddtpTime1"
        Me.ddtpTime1.ShowCheckBox = True
        Me.ddtpTime1.Size = New System.Drawing.Size(143, 19)
        Me.ddtpTime1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "値"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(466, 455)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(391, 455)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lbList
        '
        Me.lbList.FormattingEnabled = True
        Me.lbList.ItemHeight = 12
        Me.lbList.Location = New System.Drawing.Point(12, 188)
        Me.lbList.Name = "lbList"
        Me.lbList.Size = New System.Drawing.Size(285, 256)
        Me.lbList.TabIndex = 2
        '
        '初期時間属性データ項目
        '
        Me.初期時間属性データ項目.Controls.Add(Me.lblType)
        Me.初期時間属性データ項目.Controls.Add(Me.lblMissing)
        Me.初期時間属性データ項目.Controls.Add(Me.lblUnit)
        Me.初期時間属性データ項目.Controls.Add(Me.lblTitle)
        Me.初期時間属性データ項目.Location = New System.Drawing.Point(12, 88)
        Me.初期時間属性データ項目.Name = "初期時間属性データ項目"
        Me.初期時間属性データ項目.Size = New System.Drawing.Size(523, 76)
        Me.初期時間属性データ項目.TabIndex = 1
        Me.初期時間属性データ項目.TabStop = False
        Me.初期時間属性データ項目.Text = "初期時間属性データ項目"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(16, 54)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(38, 12)
        Me.lblType.TabIndex = 10
        Me.lblType.Text = "Label3"
        '
        'lblMissing
        '
        Me.lblMissing.AutoSize = True
        Me.lblMissing.Location = New System.Drawing.Point(316, 54)
        Me.lblMissing.Name = "lblMissing"
        Me.lblMissing.Size = New System.Drawing.Size(38, 12)
        Me.lblMissing.TabIndex = 2
        Me.lblMissing.Text = "Label3"
        '
        'lblUnit
        '
        Me.lblUnit.Location = New System.Drawing.Point(237, 54)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(73, 12)
        Me.lblUnit.TabIndex = 1
        Me.lblUnit.Text = "Label3"
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(17, 24)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(215, 19)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Label3"
        '
        'lbObjName
        '
        Me.lbObjName.FormattingEnabled = True
        Me.lbObjName.ItemHeight = 12
        Me.lbObjName.Location = New System.Drawing.Point(11, 26)
        Me.lbObjName.Name = "lbObjName"
        Me.lbObjName.Size = New System.Drawing.Size(524, 52)
        Me.lbObjName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "オブジェクト名"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 12)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "データ"
        '
        'frmMED_DefTimeAttDataObjectEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(550, 491)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbObjName)
        Me.Controls.Add(Me.初期時間属性データ項目)
        Me.Controls.Add(Me.lbList)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.gbSetting)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.gbTimeRef)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_DefTimeAttDataObjectEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "初期時間属性オブジェクトデータ編集"
        Me.gbTimeRef.ResumeLayout(False)
        Me.gbSetting.ResumeLayout(False)
        Me.gbSetting.PerformLayout()
        Me.初期時間属性データ項目.ResumeLayout(False)
        Me.初期時間属性データ項目.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbTimeRef As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetRef As System.Windows.Forms.Button
    Friend WithEvents lbTimeRef As System.Windows.Forms.ListBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents gbSetting As System.Windows.Forms.GroupBox
    Friend WithEvents lblTime1 As System.Windows.Forms.Label
    Friend WithEvents ddtpTime1 As mandara10.DbDateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents lbList As System.Windows.Forms.ListBox
    Friend WithEvents 初期時間属性データ項目 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMissing As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lbObjName As System.Windows.Forms.ListBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblTime2 As System.Windows.Forms.Label
    Friend WithEvents ddtpTime2 As mandara10.DbDateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
