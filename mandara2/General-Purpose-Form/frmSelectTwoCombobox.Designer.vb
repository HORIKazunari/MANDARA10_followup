<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectTwoCombobox
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
        Me.lblList1 = New System.Windows.Forms.Label()
        Me.lblList2 = New System.Windows.Forms.Label()
        Me.cboList1 = New mandara10.ComboBoxEx()
        Me.cboList2 = New mandara10.ComboBoxEx()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(95, 89)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 22)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblList1
        '
        Me.lblList1.AutoSize = True
        Me.lblList1.Location = New System.Drawing.Point(9, 7)
        Me.lblList1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblList1.Name = "lblList1"
        Me.lblList1.Size = New System.Drawing.Size(33, 12)
        Me.lblList1.TabIndex = 3
        Me.lblList1.Text = "レイヤ"
        '
        'lblList2
        '
        Me.lblList2.AutoSize = True
        Me.lblList2.Location = New System.Drawing.Point(9, 50)
        Me.lblList2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblList2.Name = "lblList2"
        Me.lblList2.Size = New System.Drawing.Size(57, 12)
        Me.lblList2.TabIndex = 4
        Me.lblList2.Text = "データ項目"
        '
        'cboList1
        '
        Me.cboList1.AsteriskSelectEnabled = False
        Me.cboList1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboList1.FormattingEnabled = True
        Me.cboList1.IntegralHeight = False
        Me.cboList1.Location = New System.Drawing.Point(11, 22)
        Me.cboList1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cboList1.MaxDropDownItems = 20
        Me.cboList1.Name = "cboList1"
        Me.cboList1.Size = New System.Drawing.Size(154, 20)
        Me.cboList1.TabIndex = 0
        '
        'cboList2
        '
        Me.cboList2.AsteriskSelectEnabled = False
        Me.cboList2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboList2.FormattingEnabled = True
        Me.cboList2.IntegralHeight = False
        Me.cboList2.Location = New System.Drawing.Point(11, 65)
        Me.cboList2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cboList2.MaxDropDownItems = 20
        Me.cboList2.Name = "cboList2"
        Me.cboList2.Size = New System.Drawing.Size(154, 20)
        Me.cboList2.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(95, 90)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(31, 21)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmSelectTwoCombobox
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(174, 118)
        Me.Controls.Add(Me.cboList2)
        Me.Controls.Add(Me.cboList1)
        Me.Controls.Add(Me.lblList2)
        Me.Controls.Add(Me.lblList1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectTwoCombobox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "データ選択"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblList1 As System.Windows.Forms.Label
    Friend WithEvents lblList2 As System.Windows.Forms.Label
    Friend WithEvents cboList1 As mandara10.ComboBoxEx
    Friend WithEvents cboList2 As mandara10.ComboBoxEx
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
