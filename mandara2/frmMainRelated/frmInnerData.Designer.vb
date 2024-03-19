<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInnerData
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
        Me.chkInnerData = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboData = New mandara10.ComboBoxEx()
        Me.rbPaint = New System.Windows.Forms.RadioButton()
        Me.rbHatch = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(185, 161)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 30)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(88, 161)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(89, 30)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'chkInnerData
        '
        Me.chkInnerData.AutoSize = True
        Me.chkInnerData.Location = New System.Drawing.Point(20, 19)
        Me.chkInnerData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkInnerData.Name = "chkInnerData"
        Me.chkInnerData.Size = New System.Drawing.Size(152, 19)
        Me.chkInnerData.TabIndex = 12
        Me.chkInnerData.Text = "データ値で塗り分ける"
        Me.chkInnerData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 61)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "データ項目"
        '
        'cboData
        '
        Me.cboData.AsteriskSelectEnabled = False
        Me.cboData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboData.FormattingEnabled = True
        Me.cboData.IntegralHeight = False
        Me.cboData.Location = New System.Drawing.Point(27, 80)
        Me.cboData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboData.Name = "cboData"
        Me.cboData.Size = New System.Drawing.Size(228, 23)
        Me.cboData.TabIndex = 14
        '
        'rbPaint
        '
        Me.rbPaint.AutoSize = True
        Me.rbPaint.Location = New System.Drawing.Point(39, 121)
        Me.rbPaint.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbPaint.Name = "rbPaint"
        Me.rbPaint.Size = New System.Drawing.Size(107, 19)
        Me.rbPaint.TabIndex = 15
        Me.rbPaint.TabStop = True
        Me.rbPaint.Text = "ペイントモード"
        Me.rbPaint.UseVisualStyleBackColor = True
        '
        'rbHatch
        '
        Me.rbHatch.AutoSize = True
        Me.rbHatch.Location = New System.Drawing.Point(171, 121)
        Me.rbHatch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbHatch.Name = "rbHatch"
        Me.rbHatch.Size = New System.Drawing.Size(96, 19)
        Me.rbHatch.TabIndex = 16
        Me.rbHatch.TabStop = True
        Me.rbHatch.Text = "ハッチモード"
        Me.rbHatch.UseVisualStyleBackColor = True
        '
        'frmInnerData
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(297, 211)
        Me.Controls.Add(Me.rbHatch)
        Me.Controls.Add(Me.rbPaint)
        Me.Controls.Add(Me.cboData)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkInnerData)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInnerData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "内部に表示するデータ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents chkInnerData As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboData As mandara10.ComboBoxEx
    Friend WithEvents rbPaint As System.Windows.Forms.RadioButton
    Friend WithEvents rbHatch As System.Windows.Forms.RadioButton
End Class
