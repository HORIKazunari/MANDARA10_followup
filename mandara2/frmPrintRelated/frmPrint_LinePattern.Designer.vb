<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_LinePattern
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
        Me.pnlLinePattern = New System.Windows.Forms.Panel()
        Me.pnlLineList = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picMeshLine = New System.Windows.Forms.PictureBox()
        Me.pnlMeshLine = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboLinePattern = New mandara10.ComboBoxEx()
        Me.pnlLinePattern.SuspendLayout()
        CType(Me.picMeshLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMeshLine.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(52, 307)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 19
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(119, 307)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnlLinePattern
        '
        Me.pnlLinePattern.AutoScroll = True
        Me.pnlLinePattern.Controls.Add(Me.pnlLineList)
        Me.pnlLinePattern.Location = New System.Drawing.Point(8, 60)
        Me.pnlLinePattern.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlLinePattern.Name = "pnlLinePattern"
        Me.pnlLinePattern.Size = New System.Drawing.Size(173, 203)
        Me.pnlLinePattern.TabIndex = 22
        '
        'pnlLineList
        '
        Me.pnlLineList.BackColor = System.Drawing.Color.White
        Me.pnlLineList.Location = New System.Drawing.Point(2, 5)
        Me.pnlLineList.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlLineList.Name = "pnlLineList"
        Me.pnlLineList.Size = New System.Drawing.Size(171, 189)
        Me.pnlLineList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "地図ファイル"
        '
        'picMeshLine
        '
        Me.picMeshLine.BackColor = System.Drawing.Color.White
        Me.picMeshLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMeshLine.Location = New System.Drawing.Point(112, 6)
        Me.picMeshLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picMeshLine.Name = "picMeshLine"
        Me.picMeshLine.Size = New System.Drawing.Size(50, 25)
        Me.picMeshLine.TabIndex = 21
        Me.picMeshLine.TabStop = False
        '
        'pnlMeshLine
        '
        Me.pnlMeshLine.Controls.Add(Me.picMeshLine)
        Me.pnlMeshLine.Controls.Add(Me.Label22)
        Me.pnlMeshLine.Location = New System.Drawing.Point(7, 267)
        Me.pnlMeshLine.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlMeshLine.Name = "pnlMeshLine"
        Me.pnlMeshLine.Size = New System.Drawing.Size(173, 36)
        Me.pnlMeshLine.TabIndex = 27
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(14, 6)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(94, 29)
        Me.Label22.TabIndex = 26
        Me.Label22.Text = "メッシュデータの輪郭ラインパターン"
        '
        'cboLinePattern
        '
        Me.cboLinePattern.AsteriskSelectEnabled = False
        Me.cboLinePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLinePattern.FormattingEnabled = True
        Me.cboLinePattern.IntegralHeight = False
        Me.cboLinePattern.Location = New System.Drawing.Point(10, 25)
        Me.cboLinePattern.Name = "cboLinePattern"
        Me.cboLinePattern.Size = New System.Drawing.Size(170, 20)
        Me.cboLinePattern.TabIndex = 28
        '
        'frmPrint_LinePattern
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(195, 336)
        Me.Controls.Add(Me.cboLinePattern)
        Me.Controls.Add(Me.pnlMeshLine)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlLinePattern)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_LinePattern"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "線種ラインパターン設定"
        Me.pnlLinePattern.ResumeLayout(False)
        CType(Me.picMeshLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMeshLine.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlLinePattern As System.Windows.Forms.Panel
    Friend WithEvents pnlLineList As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picMeshLine As System.Windows.Forms.PictureBox
    Friend WithEvents pnlMeshLine As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboLinePattern As mandara10.ComboBoxEx
End Class
