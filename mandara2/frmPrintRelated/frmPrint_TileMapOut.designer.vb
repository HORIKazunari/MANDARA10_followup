<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_TileMapOut
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
        Me.FolderSelect = New KTGISUserControl.KtgisFolderSelector()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnFileCount = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbJPEG = New System.Windows.Forms.RadioButton()
        Me.rbPNG = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbPresentArea = New System.Windows.Forms.RadioButton()
        Me.rbAllArea = New System.Windows.Forms.RadioButton()
        Me.cboMinZoom = New System.Windows.Forms.ComboBox()
        Me.cboMaxZoom = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblProg = New System.Windows.Forms.Label()
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(313, 286)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(225, 286)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "出力"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'FolderSelect
        '
        Me.FolderSelect.AddFolder_Flag = True
        Me.FolderSelect.Caption = "タイルマップ出力フォルダ"
        Me.FolderSelect.Folder = ""
        Me.FolderSelect.Location = New System.Drawing.Point(20, 26)
        Me.FolderSelect.Margin = New System.Windows.Forms.Padding(2)
        Me.FolderSelect.Name = "FolderSelect"
        Me.FolderSelect.Size = New System.Drawing.Size(364, 47)
        Me.FolderSelect.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnFileCount)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cboMinZoom)
        Me.GroupBox1.Controls.Add(Me.cboMaxZoom)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(364, 166)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(87, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "～"
        '
        'btnFileCount
        '
        Me.btnFileCount.Location = New System.Drawing.Point(220, 127)
        Me.btnFileCount.Name = "btnFileCount"
        Me.btnFileCount.Size = New System.Drawing.Size(126, 21)
        Me.btnFileCount.TabIndex = 4
        Me.btnFileCount.Text = "生成ファイル数カウント"
        Me.btnFileCount.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbJPEG)
        Me.GroupBox3.Controls.Add(Me.rbPNG)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 94)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(184, 54)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "画像ファイル"
        '
        'rbJPEG
        '
        Me.rbJPEG.AutoSize = True
        Me.rbJPEG.Location = New System.Drawing.Point(102, 23)
        Me.rbJPEG.Name = "rbJPEG"
        Me.rbJPEG.Size = New System.Drawing.Size(52, 16)
        Me.rbJPEG.TabIndex = 1
        Me.rbJPEG.TabStop = True
        Me.rbJPEG.Text = "JPEG"
        Me.rbJPEG.UseVisualStyleBackColor = True
        '
        'rbPNG
        '
        Me.rbPNG.AutoSize = True
        Me.rbPNG.Location = New System.Drawing.Point(22, 23)
        Me.rbPNG.Name = "rbPNG"
        Me.rbPNG.Size = New System.Drawing.Size(46, 16)
        Me.rbPNG.TabIndex = 0
        Me.rbPNG.TabStop = True
        Me.rbPNG.Text = "PNG"
        Me.rbPNG.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbPresentArea)
        Me.GroupBox2.Controls.Add(Me.rbAllArea)
        Me.GroupBox2.Location = New System.Drawing.Point(210, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(136, 85)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "出力範囲"
        '
        'rbPresentArea
        '
        Me.rbPresentArea.AutoSize = True
        Me.rbPresentArea.Location = New System.Drawing.Point(22, 51)
        Me.rbPresentArea.Name = "rbPresentArea"
        Me.rbPresentArea.Size = New System.Drawing.Size(105, 16)
        Me.rbPresentArea.TabIndex = 1
        Me.rbPresentArea.TabStop = True
        Me.rbPresentArea.Text = "現在の表示範囲"
        Me.rbPresentArea.UseVisualStyleBackColor = True
        '
        'rbAllArea
        '
        Me.rbAllArea.AutoSize = True
        Me.rbAllArea.Location = New System.Drawing.Point(22, 23)
        Me.rbAllArea.Name = "rbAllArea"
        Me.rbAllArea.Size = New System.Drawing.Size(71, 16)
        Me.rbAllArea.TabIndex = 0
        Me.rbAllArea.TabStop = True
        Me.rbAllArea.Text = "地図全体"
        Me.rbAllArea.UseVisualStyleBackColor = True
        '
        'cboMinZoom
        '
        Me.cboMinZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMinZoom.FormattingEnabled = True
        Me.cboMinZoom.Location = New System.Drawing.Point(16, 53)
        Me.cboMinZoom.Name = "cboMinZoom"
        Me.cboMinZoom.Size = New System.Drawing.Size(65, 20)
        Me.cboMinZoom.TabIndex = 0
        '
        'cboMaxZoom
        '
        Me.cboMaxZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaxZoom.FormattingEnabled = True
        Me.cboMaxZoom.Location = New System.Drawing.Point(116, 53)
        Me.cboMaxZoom.Name = "cboMaxZoom"
        Me.cboMaxZoom.Size = New System.Drawing.Size(65, 20)
        Me.cboMaxZoom.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "最小ズームレベル"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(113, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "最大ズームレベル"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(18, 250)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(182, 21)
        Me.ProgressBar.TabIndex = 24
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(219, 250)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(64, 21)
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "中断"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 319)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(398, 22)
        Me.StatusStrip1.TabIndex = 28
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'lblProg
        '
        Me.lblProg.AutoSize = True
        Me.lblProg.Location = New System.Drawing.Point(26, 274)
        Me.lblProg.Name = "lblProg"
        Me.lblProg.Size = New System.Drawing.Size(29, 12)
        Me.lblProg.TabIndex = 29
        Me.lblProg.Text = "進行"
        '
        'picMap
        '
        Me.picMap.Location = New System.Drawing.Point(313, 74)
        Me.picMap.Name = "picMap"
        Me.picMap.Size = New System.Drawing.Size(215, 207)
        Me.picMap.TabIndex = 2
        Me.picMap.TabStop = False
        Me.picMap.Visible = False
        '
        'frmPrint_TileMapOut
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(398, 341)
        Me.Controls.Add(Me.lblProg)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.FolderSelect)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.picMap)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_TileMapOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "タイルマップ出力"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents FolderSelect As KTGISUserControl.KtgisFolderSelector
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbJPEG As System.Windows.Forms.RadioButton
    Friend WithEvents rbPNG As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPresentArea As System.Windows.Forms.RadioButton
    Friend WithEvents rbAllArea As System.Windows.Forms.RadioButton
    Friend WithEvents cboMinZoom As System.Windows.Forms.ComboBox
    Friend WithEvents cboMaxZoom As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFileCount As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblProg As System.Windows.Forms.Label
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
End Class
