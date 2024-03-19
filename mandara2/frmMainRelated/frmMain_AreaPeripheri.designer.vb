<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_AreaPeripheri
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboScaleUnit = New mandara10.ComboBoxEx()
        Me.rbPeripheri = New System.Windows.Forms.RadioButton()
        Me.rbArea = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(89, 175)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(22, 175)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 21
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "取得単位"
        '
        'cboScaleUnit
        '
        Me.cboScaleUnit.AsteriskSelectEnabled = False
        Me.cboScaleUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScaleUnit.FormattingEnabled = True
        Me.cboScaleUnit.IntegralHeight = False
        Me.cboScaleUnit.Location = New System.Drawing.Point(79, 117)
        Me.cboScaleUnit.Margin = New System.Windows.Forms.Padding(2)
        Me.cboScaleUnit.MaxDropDownItems = 15
        Me.cboScaleUnit.Name = "cboScaleUnit"
        Me.cboScaleUnit.Size = New System.Drawing.Size(72, 20)
        Me.cboScaleUnit.TabIndex = 25
        '
        'rbPeripheri
        '
        Me.rbPeripheri.AutoSize = True
        Me.rbPeripheri.Location = New System.Drawing.Point(29, 77)
        Me.rbPeripheri.Name = "rbPeripheri"
        Me.rbPeripheri.Size = New System.Drawing.Size(122, 16)
        Me.rbPeripheri.TabIndex = 24
        Me.rbPeripheri.TabStop = True
        Me.rbPeripheri.Text = "オブジェクト周長取得"
        Me.rbPeripheri.UseVisualStyleBackColor = True
        '
        'rbArea
        '
        Me.rbArea.AutoSize = True
        Me.rbArea.Location = New System.Drawing.Point(29, 35)
        Me.rbArea.Name = "rbArea"
        Me.rbArea.Size = New System.Drawing.Size(122, 16)
        Me.rbArea.TabIndex = 23
        Me.rbArea.TabStop = True
        Me.rbArea.Text = "オブジェクト面積取得"
        Me.rbArea.UseVisualStyleBackColor = True
        '
        'frmMain_AreaPeripheri
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(181, 211)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboScaleUnit)
        Me.Controls.Add(Me.rbPeripheri)
        Me.Controls.Add(Me.rbArea)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_AreaPeripheri"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "面積・周長取得"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboScaleUnit As mandara10.ComboBoxEx
    Friend WithEvents rbPeripheri As System.Windows.Forms.RadioButton
    Friend WithEvents rbArea As System.Windows.Forms.RadioButton
End Class
