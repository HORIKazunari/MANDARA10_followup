<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_DefTimeAttDataItem
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
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboExtra = New System.Windows.Forms.ComboBox()
        Me.cboUnit = New System.Windows.Forms.ComboBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.chkMissingValue = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbSpan = New System.Windows.Forms.RadioButton()
        Me.rbPoint = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(154, 304)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(79, 304)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(60, 12)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(163, 19)
        Me.txtTitle.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "タイトル"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "単位"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "注釈"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(186, 12)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "所定時期以外を指定した場合の処理"
        '
        'cboExtra
        '
        Me.cboExtra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExtra.FormattingEnabled = True
        Me.cboExtra.Location = New System.Drawing.Point(60, 202)
        Me.cboExtra.Name = "cboExtra"
        Me.cboExtra.Size = New System.Drawing.Size(163, 20)
        Me.cboExtra.TabIndex = 5
        '
        'cboUnit
        '
        Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnit.FormattingEnabled = True
        Me.cboUnit.Location = New System.Drawing.Point(60, 91)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(112, 20)
        Me.cboUnit.TabIndex = 2
        '
        'txtUnit
        '
        Me.txtUnit.Location = New System.Drawing.Point(88, 117)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(135, 19)
        Me.txtUnit.TabIndex = 3
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(60, 239)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(163, 44)
        Me.txtNote.TabIndex = 6
        '
        'chkMissingValue
        '
        Me.chkMissingValue.AutoSize = True
        Me.chkMissingValue.Location = New System.Drawing.Point(60, 155)
        Me.chkMissingValue.Name = "chkMissingValue"
        Me.chkMissingValue.Size = New System.Drawing.Size(122, 16)
        Me.chkMissingValue.TabIndex = 4
        Me.chkMissingValue.Text = "空白データは欠損値"
        Me.chkMissingValue.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbSpan)
        Me.Panel1.Controls.Add(Me.rbPoint)
        Me.Panel1.Location = New System.Drawing.Point(71, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(147, 42)
        Me.Panel1.TabIndex = 1
        '
        'rbSpan
        '
        Me.rbSpan.AutoSize = True
        Me.rbSpan.Location = New System.Drawing.Point(80, 17)
        Me.rbSpan.Name = "rbSpan"
        Me.rbSpan.Size = New System.Drawing.Size(47, 16)
        Me.rbSpan.TabIndex = 1
        Me.rbSpan.TabStop = True
        Me.rbSpan.Text = "期間"
        Me.rbSpan.UseVisualStyleBackColor = True
        '
        'rbPoint
        '
        Me.rbPoint.AutoSize = True
        Me.rbPoint.Location = New System.Drawing.Point(10, 17)
        Me.rbPoint.Name = "rbPoint"
        Me.rbPoint.Size = New System.Drawing.Size(47, 16)
        Me.rbPoint.TabIndex = 0
        Me.rbPoint.TabStop = True
        Me.rbPoint.Text = "時点"
        Me.rbPoint.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "時間設定"
        '
        'frmMED_DefTimeAttDataItem
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(247, 340)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.chkMissingValue)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.cboUnit)
        Me.Controls.Add(Me.cboExtra)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_DefTimeAttDataItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "初期時間属性データ項目"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboExtra As System.Windows.Forms.ComboBox
    Friend WithEvents cboUnit As System.Windows.Forms.ComboBox
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents chkMissingValue As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbSpan As System.Windows.Forms.RadioButton
    Friend WithEvents rbPoint As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
