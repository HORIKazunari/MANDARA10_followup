<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_TimeSeriesSummingUp
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblData = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNewLayerName = New System.Windows.Forms.TextBox()
        Me.clbLayer = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(271, 399)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(204, 399)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 12)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "集計するレイヤ"
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Location = New System.Drawing.Point(12, 147)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(100, 12)
        Me.lblData.TabIndex = 26
        Me.lblData.Text = "取得するデータ項目"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 366)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 12)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "新しいレイヤの名称"
        '
        'txtNewLayerName
        '
        Me.txtNewLayerName.Location = New System.Drawing.Point(126, 363)
        Me.txtNewLayerName.Name = "txtNewLayerName"
        Me.txtNewLayerName.Size = New System.Drawing.Size(207, 19)
        Me.txtNewLayerName.TabIndex = 1
        '
        'clbLayer
        '
        Me.clbLayer.FormattingEnabled = True
        Me.clbLayer.Location = New System.Drawing.Point(28, 27)
        Me.clbLayer.Name = "clbLayer"
        Me.clbLayer.Size = New System.Drawing.Size(304, 102)
        Me.clbLayer.TabIndex = 0
        '
        'frmMain_TimeSeriesSummingUp
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(353, 434)
        Me.Controls.Add(Me.clbLayer)
        Me.Controls.Add(Me.txtNewLayerName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_TimeSeriesSummingUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "時系列集計"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblData As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNewLayerName As System.Windows.Forms.TextBox
    Friend WithEvents clbLayer As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbData As System.Windows.Forms.CheckedListBox
End Class
