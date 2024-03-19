<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_ObjectValue
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnNameFont = New System.Windows.Forms.Button()
        Me.chkName = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnValueFont = New System.Windows.Forms.Button()
        Me.chkValue = New System.Windows.Forms.CheckBox()
        Me.chkDecimalSepaF = New System.Windows.Forms.CheckBox()
        Me.cboDecimalNumber = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(88, 225)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(166, 225)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnNameFont)
        Me.GroupBox1.Controls.Add(Me.chkName)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 65)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "オブジェクト名"
        '
        'btnNameFont
        '
        Me.btnNameFont.Location = New System.Drawing.Point(127, 23)
        Me.btnNameFont.Name = "btnNameFont"
        Me.btnNameFont.Size = New System.Drawing.Size(67, 25)
        Me.btnNameFont.TabIndex = 1
        Me.btnNameFont.Text = "フォント"
        Me.btnNameFont.UseVisualStyleBackColor = True
        '
        'chkName
        '
        Me.chkName.AutoSize = True
        Me.chkName.Location = New System.Drawing.Point(26, 28)
        Me.chkName.Name = "chkName"
        Me.chkName.Size = New System.Drawing.Size(48, 16)
        Me.chkName.TabIndex = 0
        Me.chkName.Text = "表示"
        Me.chkName.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboDecimalNumber)
        Me.GroupBox2.Controls.Add(Me.chkDecimalSepaF)
        Me.GroupBox2.Controls.Add(Me.btnValueFont)
        Me.GroupBox2.Controls.Add(Me.chkValue)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(216, 109)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "データ値"
        '
        'btnValueFont
        '
        Me.btnValueFont.Location = New System.Drawing.Point(127, 23)
        Me.btnValueFont.Name = "btnValueFont"
        Me.btnValueFont.Size = New System.Drawing.Size(67, 25)
        Me.btnValueFont.TabIndex = 1
        Me.btnValueFont.Text = "フォント"
        Me.btnValueFont.UseVisualStyleBackColor = True
        '
        'chkValue
        '
        Me.chkValue.AutoSize = True
        Me.chkValue.Location = New System.Drawing.Point(26, 28)
        Me.chkValue.Name = "chkValue"
        Me.chkValue.Size = New System.Drawing.Size(48, 16)
        Me.chkValue.TabIndex = 0
        Me.chkValue.Text = "表示"
        Me.chkValue.UseVisualStyleBackColor = True
        '
        'chkDecimalSepaF
        '
        Me.chkDecimalSepaF.AutoSize = True
        Me.chkDecimalSepaF.Location = New System.Drawing.Point(53, 54)
        Me.chkDecimalSepaF.Name = "chkDecimalSepaF"
        Me.chkDecimalSepaF.Size = New System.Drawing.Size(118, 16)
        Me.chkDecimalSepaF.TabIndex = 2
        Me.chkDecimalSepaF.Text = "小数点以下の設定"
        Me.chkDecimalSepaF.UseVisualStyleBackColor = True
        '
        'cboDecimalNumber
        '
        Me.cboDecimalNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDecimalNumber.FormattingEnabled = True
        Me.cboDecimalNumber.Location = New System.Drawing.Point(72, 76)
        Me.cboDecimalNumber.Name = "cboDecimalNumber"
        Me.cboDecimalNumber.Size = New System.Drawing.Size(66, 20)
        Me.cboDecimalNumber.TabIndex = 3
        '
        'frmPrint_ObjectValue
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(244, 259)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_ObjectValue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オブジェクト名・データ値表示"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNameFont As System.Windows.Forms.Button
    Friend WithEvents chkName As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnValueFont As System.Windows.Forms.Button
    Friend WithEvents chkValue As System.Windows.Forms.CheckBox
    Friend WithEvents cboDecimalNumber As System.Windows.Forms.ComboBox
    Friend WithEvents chkDecimalSepaF As System.Windows.Forms.CheckBox
End Class
