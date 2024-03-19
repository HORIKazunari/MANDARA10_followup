<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_SRTM30Divide
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbSRTM30 = New System.Windows.Forms.RadioButton()
        Me.rbSRTM30Plus = New System.Windows.Forms.RadioButton()
        Me.inputFolder = New KTGISUserControl.KtgisFolderSelector()
        Me.outputFolder = New KTGISUserControl.KtgisFolderSelector()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(209, 200)
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
        Me.btnOK.Location = New System.Drawing.Point(124, 200)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 21
        Me.btnOK.Text = "ファイル変換"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSRTM30)
        Me.GroupBox1.Controls.Add(Me.rbSRTM30Plus)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 56)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "変換データ"
        '
        'rbSRTM30
        '
        Me.rbSRTM30.AutoSize = True
        Me.rbSRTM30.Location = New System.Drawing.Point(155, 21)
        Me.rbSRTM30.Name = "rbSRTM30"
        Me.rbSRTM30.Size = New System.Drawing.Size(66, 16)
        Me.rbSRTM30.TabIndex = 1
        Me.rbSRTM30.Text = "SRTM30"
        Me.rbSRTM30.UseVisualStyleBackColor = True
        '
        'rbSRTM30Plus
        '
        Me.rbSRTM30Plus.AutoSize = True
        Me.rbSRTM30Plus.Checked = True
        Me.rbSRTM30Plus.Location = New System.Drawing.Point(23, 21)
        Me.rbSRTM30Plus.Name = "rbSRTM30Plus"
        Me.rbSRTM30Plus.Size = New System.Drawing.Size(88, 16)
        Me.rbSRTM30Plus.TabIndex = 0
        Me.rbSRTM30Plus.TabStop = True
        Me.rbSRTM30Plus.Text = "SRTM30Plus"
        Me.rbSRTM30Plus.UseVisualStyleBackColor = True
        '
        'inputFolder
        '
        Me.inputFolder.AddFolder_Flag = False
        Me.inputFolder.Caption = "SRTM30/30Plusフォルダ"
        Me.inputFolder.Folder = ""
        Me.inputFolder.Location = New System.Drawing.Point(11, 84)
        Me.inputFolder.Margin = New System.Windows.Forms.Padding(2)
        Me.inputFolder.Name = "inputFolder"
        Me.inputFolder.Size = New System.Drawing.Size(258, 42)
        Me.inputFolder.TabIndex = 24
        '
        'outputFolder
        '
        Me.outputFolder.AddFolder_Flag = True
        Me.outputFolder.Caption = "変換ファイル出力フォルダ"
        Me.outputFolder.Folder = ""
        Me.outputFolder.Location = New System.Drawing.Point(11, 142)
        Me.outputFolder.Margin = New System.Windows.Forms.Padding(2)
        Me.outputFolder.Name = "outputFolder"
        Me.outputFolder.Size = New System.Drawing.Size(258, 42)
        Me.outputFolder.TabIndex = 25
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 191)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(94, 15)
        Me.ProgressBar1.TabIndex = 26
        Me.ProgressBar1.Visible = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(13, 212)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(94, 15)
        Me.ProgressBar2.TabIndex = 27
        Me.ProgressBar2.Visible = False
        '
        'frmMED_SRTM30Divide
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(282, 238)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.outputFolder)
        Me.Controls.Add(Me.inputFolder)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_SRTM30Divide"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SRTM30/30Plusコンバータ"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSRTM30 As System.Windows.Forms.RadioButton
    Friend WithEvents rbSRTM30Plus As System.Windows.Forms.RadioButton
    Friend WithEvents inputFolder As KTGISUserControl.KtgisFolderSelector
    Friend WithEvents outputFolder As KTGISUserControl.KtgisFolderSelector
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
End Class
