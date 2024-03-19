<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_ClickSetObjName
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
        Me.lbObjName = New System.Windows.Forms.ListBox()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.cbConfirm = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCancel.Location = New System.Drawing.Point(203, 275)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "終了"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lbObjName
        '
        Me.lbObjName.FormattingEnabled = True
        Me.lbObjName.ItemHeight = 12
        Me.lbObjName.Location = New System.Drawing.Point(9, 62)
        Me.lbObjName.Margin = New System.Windows.Forms.Padding(2)
        Me.lbObjName.Name = "lbObjName"
        Me.lbObjName.Size = New System.Drawing.Size(259, 208)
        Me.lbObjName.TabIndex = 1
        '
        'btnGetData
        '
        Me.btnGetData.Location = New System.Drawing.Point(9, 10)
        Me.btnGetData.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(117, 24)
        Me.btnGetData.TabIndex = 0
        Me.btnGetData.Text = "クリップボードから取得"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'cbConfirm
        '
        Me.cbConfirm.AutoSize = True
        Me.cbConfirm.Checked = True
        Me.cbConfirm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbConfirm.Location = New System.Drawing.Point(14, 279)
        Me.cbConfirm.Margin = New System.Windows.Forms.Padding(2)
        Me.cbConfirm.Name = "cbConfirm"
        Me.cbConfirm.Size = New System.Drawing.Size(110, 16)
        Me.cbConfirm.TabIndex = 2
        Me.cbConfirm.Text = "変更の確認をする"
        Me.cbConfirm.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "割り当てオブジェクト名"
        '
        'frmMED_ClickSetObjName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(279, 307)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbConfirm)
        Me.Controls.Add(Me.btnGetData)
        Me.Controls.Add(Me.lbObjName)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_ClickSetObjName"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "オブジェクト名のクリック割り当て"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lbObjName As System.Windows.Forms.ListBox
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents cbConfirm As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
