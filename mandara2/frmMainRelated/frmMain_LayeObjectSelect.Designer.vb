<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_LayeObjectSelect
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
        Me.cboLayer = New mandara10.ComboBoxEx()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkDumyObjectSelect = New System.Windows.Forms.CheckBox()
        Me.lbObject = New mandara10.ListBoxEx()
        Me.SuspendLayout()
        '
        'cboLayer
        '
        Me.cboLayer.AsteriskSelectEnabled = False
        Me.cboLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayer.FormattingEnabled = True
        Me.cboLayer.IntegralHeight = False
        Me.cboLayer.Location = New System.Drawing.Point(12, 14)
        Me.cboLayer.Name = "cboLayer"
        Me.cboLayer.Size = New System.Drawing.Size(225, 20)
        Me.cboLayer.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(108, 227)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(175, 227)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkDumyObjectSelect
        '
        Me.chkDumyObjectSelect.Location = New System.Drawing.Point(12, 227)
        Me.chkDumyObjectSelect.Margin = New System.Windows.Forms.Padding(2)
        Me.chkDumyObjectSelect.Name = "chkDumyObjectSelect"
        Me.chkDumyObjectSelect.Size = New System.Drawing.Size(91, 34)
        Me.chkDumyObjectSelect.TabIndex = 2
        Me.chkDumyObjectSelect.Text = "ダミーオブジェクト選択"
        Me.chkDumyObjectSelect.UseVisualStyleBackColor = True
        '
        'lbObject
        '
        Me.lbObject.AsteriskSelectEnabled = False
        Me.lbObject.FormattingEnabled = True
        Me.lbObject.ItemHeight = 12
        Me.lbObject.Location = New System.Drawing.Point(12, 40)
        Me.lbObject.Name = "lbObject"
        Me.lbObject.Size = New System.Drawing.Size(225, 172)
        Me.lbObject.TabIndex = 1
        '
        'frmMain_LayeObjectSelect
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(252, 262)
        Me.Controls.Add(Me.chkDumyObjectSelect)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lbObject)
        Me.Controls.Add(Me.cboLayer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_LayeObjectSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "レイヤ内オブジェクト選択"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboLayer As mandara10.ComboBoxEx
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkDumyObjectSelect As System.Windows.Forms.CheckBox
    Friend WithEvents lbObject As mandara10.ListBoxEx
End Class
