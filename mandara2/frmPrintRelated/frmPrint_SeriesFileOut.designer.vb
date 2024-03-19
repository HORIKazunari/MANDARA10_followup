<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_SeriesFileOut
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
        Me.gbBaseImageFileName = New System.Windows.Forms.GroupBox()
        Me.txtBaseImageFileName = New System.Windows.Forms.TextBox()
        Me.gbHtml = New System.Windows.Forms.GroupBox()
        Me.txtHTML = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbAnimatedGIF = New System.Windows.Forms.RadioButton()
        Me.rbWebImageAnime = New System.Windows.Forms.RadioButton()
        Me.rbWebImageChange = New System.Windows.Forms.RadioButton()
        Me.rbImage = New System.Windows.Forms.RadioButton()
        Me.gbImageFormat = New System.Windows.Forms.GroupBox()
        Me.rbEMF = New System.Windows.Forms.RadioButton()
        Me.rbBMP = New System.Windows.Forms.RadioButton()
        Me.rbJpeg = New System.Windows.Forms.RadioButton()
        Me.rbPNG = New System.Windows.Forms.RadioButton()
        Me.gbComaInterval = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtComaInterval = New mandara10.TextNumberBox()
        Me.GIFFileSelect = New KTGISUserControl.KtgisFileSelector()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFirstComa = New mandara10.TextNumberBox()
        Me.txtLastComa = New mandara10.TextNumberBox()
        Me.gbBaseImageFileName.SuspendLayout()
        Me.gbHtml.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbImageFormat.SuspendLayout()
        Me.gbComaInterval.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(300, 345)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(233, 345)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'FolderSelect
        '
        Me.FolderSelect.AddFolder_Flag = True
        Me.FolderSelect.Caption = "出力先フォルダ"
        Me.FolderSelect.Folder = ""
        Me.FolderSelect.Location = New System.Drawing.Point(11, 142)
        Me.FolderSelect.Margin = New System.Windows.Forms.Padding(2)
        Me.FolderSelect.Name = "FolderSelect"
        Me.FolderSelect.Size = New System.Drawing.Size(351, 39)
        Me.FolderSelect.TabIndex = 4
        '
        'gbBaseImageFileName
        '
        Me.gbBaseImageFileName.Controls.Add(Me.txtBaseImageFileName)
        Me.gbBaseImageFileName.Location = New System.Drawing.Point(11, 200)
        Me.gbBaseImageFileName.Name = "gbBaseImageFileName"
        Me.gbBaseImageFileName.Size = New System.Drawing.Size(168, 66)
        Me.gbBaseImageFileName.TabIndex = 5
        Me.gbBaseImageFileName.TabStop = False
        Me.gbBaseImageFileName.Text = "ベース画像ファイル名"
        '
        'txtBaseImageFileName
        '
        Me.txtBaseImageFileName.Location = New System.Drawing.Point(16, 28)
        Me.txtBaseImageFileName.Name = "txtBaseImageFileName"
        Me.txtBaseImageFileName.Size = New System.Drawing.Size(133, 19)
        Me.txtBaseImageFileName.TabIndex = 1
        '
        'gbHtml
        '
        Me.gbHtml.Controls.Add(Me.txtHTML)
        Me.gbHtml.Location = New System.Drawing.Point(194, 200)
        Me.gbHtml.Name = "gbHtml"
        Me.gbHtml.Size = New System.Drawing.Size(168, 66)
        Me.gbHtml.TabIndex = 6
        Me.gbHtml.TabStop = False
        Me.gbHtml.Text = "出力htmlファイル名"
        '
        'txtHTML
        '
        Me.txtHTML.Location = New System.Drawing.Point(13, 28)
        Me.txtHTML.Name = "txtHTML"
        Me.txtHTML.Size = New System.Drawing.Size(133, 19)
        Me.txtHTML.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbAnimatedGIF)
        Me.GroupBox3.Controls.Add(Me.rbWebImageAnime)
        Me.GroupBox3.Controls.Add(Me.rbWebImageChange)
        Me.GroupBox3.Controls.Add(Me.rbImage)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(168, 125)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "出力方法"
        '
        'rbAnimatedGIF
        '
        Me.rbAnimatedGIF.AutoSize = True
        Me.rbAnimatedGIF.Location = New System.Drawing.Point(25, 94)
        Me.rbAnimatedGIF.Name = "rbAnimatedGIF"
        Me.rbAnimatedGIF.Size = New System.Drawing.Size(102, 16)
        Me.rbAnimatedGIF.TabIndex = 3
        Me.rbAnimatedGIF.TabStop = True
        Me.rbAnimatedGIF.Text = "アニメーションGIF"
        Me.rbAnimatedGIF.UseVisualStyleBackColor = True
        '
        'rbWebImageAnime
        '
        Me.rbWebImageAnime.AutoSize = True
        Me.rbWebImageAnime.Location = New System.Drawing.Point(25, 50)
        Me.rbWebImageAnime.Name = "rbWebImageAnime"
        Me.rbWebImageAnime.Size = New System.Drawing.Size(105, 16)
        Me.rbWebImageAnime.TabIndex = 1
        Me.rbWebImageAnime.TabStop = True
        Me.rbWebImageAnime.Text = "Webアニメーション"
        Me.rbWebImageAnime.UseVisualStyleBackColor = True
        '
        'rbWebImageChange
        '
        Me.rbWebImageChange.AutoSize = True
        Me.rbWebImageChange.Location = New System.Drawing.Point(25, 72)
        Me.rbWebImageChange.Name = "rbWebImageChange"
        Me.rbWebImageChange.Size = New System.Drawing.Size(92, 16)
        Me.rbWebImageChange.TabIndex = 2
        Me.rbWebImageChange.TabStop = True
        Me.rbWebImageChange.Text = "Web画像変化"
        Me.rbWebImageChange.UseVisualStyleBackColor = True
        '
        'rbImage
        '
        Me.rbImage.AutoSize = True
        Me.rbImage.Location = New System.Drawing.Point(25, 28)
        Me.rbImage.Name = "rbImage"
        Me.rbImage.Size = New System.Drawing.Size(102, 16)
        Me.rbImage.TabIndex = 0
        Me.rbImage.TabStop = True
        Me.rbImage.Text = "画像ファイルのみ"
        Me.rbImage.UseVisualStyleBackColor = True
        '
        'gbImageFormat
        '
        Me.gbImageFormat.Controls.Add(Me.rbEMF)
        Me.gbImageFormat.Controls.Add(Me.rbBMP)
        Me.gbImageFormat.Controls.Add(Me.rbJpeg)
        Me.gbImageFormat.Controls.Add(Me.rbPNG)
        Me.gbImageFormat.Location = New System.Drawing.Point(194, 12)
        Me.gbImageFormat.Name = "gbImageFormat"
        Me.gbImageFormat.Size = New System.Drawing.Size(168, 125)
        Me.gbImageFormat.TabIndex = 1
        Me.gbImageFormat.TabStop = False
        Me.gbImageFormat.Text = "出力画像形式"
        '
        'rbEMF
        '
        Me.rbEMF.AutoSize = True
        Me.rbEMF.Location = New System.Drawing.Point(22, 94)
        Me.rbEMF.Name = "rbEMF"
        Me.rbEMF.Size = New System.Drawing.Size(46, 16)
        Me.rbEMF.TabIndex = 3
        Me.rbEMF.TabStop = True
        Me.rbEMF.Text = "EMF"
        Me.rbEMF.UseVisualStyleBackColor = True
        '
        'rbBMP
        '
        Me.rbBMP.AutoSize = True
        Me.rbBMP.Location = New System.Drawing.Point(22, 72)
        Me.rbBMP.Name = "rbBMP"
        Me.rbBMP.Size = New System.Drawing.Size(47, 16)
        Me.rbBMP.TabIndex = 2
        Me.rbBMP.TabStop = True
        Me.rbBMP.Text = "BMP"
        Me.rbBMP.UseVisualStyleBackColor = True
        '
        'rbJpeg
        '
        Me.rbJpeg.AutoSize = True
        Me.rbJpeg.Location = New System.Drawing.Point(22, 50)
        Me.rbJpeg.Name = "rbJpeg"
        Me.rbJpeg.Size = New System.Drawing.Size(52, 16)
        Me.rbJpeg.TabIndex = 1
        Me.rbJpeg.TabStop = True
        Me.rbJpeg.Text = "JPEG"
        Me.rbJpeg.UseVisualStyleBackColor = True
        '
        'rbPNG
        '
        Me.rbPNG.AutoSize = True
        Me.rbPNG.Location = New System.Drawing.Point(22, 28)
        Me.rbPNG.Name = "rbPNG"
        Me.rbPNG.Size = New System.Drawing.Size(46, 16)
        Me.rbPNG.TabIndex = 0
        Me.rbPNG.TabStop = True
        Me.rbPNG.Text = "PNG"
        Me.rbPNG.UseVisualStyleBackColor = True
        '
        'gbComaInterval
        '
        Me.gbComaInterval.Controls.Add(Me.txtLastComa)
        Me.gbComaInterval.Controls.Add(Me.txtFirstComa)
        Me.gbComaInterval.Controls.Add(Me.Label3)
        Me.gbComaInterval.Controls.Add(Me.Label2)
        Me.gbComaInterval.Controls.Add(Me.Label1)
        Me.gbComaInterval.Controls.Add(Me.txtComaInterval)
        Me.gbComaInterval.Location = New System.Drawing.Point(12, 272)
        Me.gbComaInterval.Name = "gbComaInterval"
        Me.gbComaInterval.Size = New System.Drawing.Size(313, 65)
        Me.gbComaInterval.TabIndex = 7
        Me.gbComaInterval.TabStop = False
        Me.gbComaInterval.Text = "コマ移動時間（秒）"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(115, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "中間のコマ"
        '
        'txtComaInterval
        '
        Me.txtComaInterval.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtComaInterval.Location = New System.Drawing.Point(129, 37)
        Me.txtComaInterval.MaxValue = 0.0R
        Me.txtComaInterval.MaxValueFlag = False
        Me.txtComaInterval.MinValue = 0.0R
        Me.txtComaInterval.MinValueFlag = True
        Me.txtComaInterval.Name = "txtComaInterval"
        Me.txtComaInterval.NumberPoint = True
        Me.txtComaInterval.Size = New System.Drawing.Size(67, 19)
        Me.txtComaInterval.TabIndex = 1
        Me.txtComaInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtComaInterval.ValueErrorMessageFlag = True
        '
        'GIFFileSelect
        '
        Me.GIFFileSelect.Caption = "保存GIFファイル"
        Me.GIFFileSelect.Extension = "gif"
        Me.GIFFileSelect.InitFolder = ""
        Me.GIFFileSelect.Location = New System.Drawing.Point(12, 142)
        Me.GIFFileSelect.Name = "GIFFileSelect"
        Me.GIFFileSelect.Off_Button_Flag = False
        Me.GIFFileSelect.Path = ""
        Me.GIFFileSelect.Save_Flag = True
        Me.GIFFileSelect.Size = New System.Drawing.Size(313, 39)
        Me.GIFFileSelect.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 379)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(376, 22)
        Me.StatusStrip1.TabIndex = 35
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "最初のコマ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(219, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "最後のコマ"
        '
        'txtFirstComa
        '
        Me.txtFirstComa.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtFirstComa.Location = New System.Drawing.Point(24, 37)
        Me.txtFirstComa.MaxValue = 0.0R
        Me.txtFirstComa.MaxValueFlag = False
        Me.txtFirstComa.MinValue = 0.0R
        Me.txtFirstComa.MinValueFlag = True
        Me.txtFirstComa.Name = "txtFirstComa"
        Me.txtFirstComa.NumberPoint = True
        Me.txtFirstComa.Size = New System.Drawing.Size(67, 19)
        Me.txtFirstComa.TabIndex = 0
        Me.txtFirstComa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFirstComa.ValueErrorMessageFlag = True
        '
        'txtLastComa
        '
        Me.txtLastComa.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLastComa.Location = New System.Drawing.Point(231, 37)
        Me.txtLastComa.MaxValue = 0.0R
        Me.txtLastComa.MaxValueFlag = False
        Me.txtLastComa.MinValue = 0.0R
        Me.txtLastComa.MinValueFlag = True
        Me.txtLastComa.Name = "txtLastComa"
        Me.txtLastComa.NumberPoint = True
        Me.txtLastComa.Size = New System.Drawing.Size(67, 19)
        Me.txtLastComa.TabIndex = 2
        Me.txtLastComa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLastComa.ValueErrorMessageFlag = True
        '
        'frmPrint_SeriesFileOut
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(376, 401)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GIFFileSelect)
        Me.Controls.Add(Me.gbComaInterval)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.gbHtml)
        Me.Controls.Add(Me.gbImageFormat)
        Me.Controls.Add(Me.gbBaseImageFileName)
        Me.Controls.Add(Me.FolderSelect)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_SeriesFileOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "連続表示モードのファイル出力"
        Me.gbBaseImageFileName.ResumeLayout(False)
        Me.gbBaseImageFileName.PerformLayout()
        Me.gbHtml.ResumeLayout(False)
        Me.gbHtml.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbImageFormat.ResumeLayout(False)
        Me.gbImageFormat.PerformLayout()
        Me.gbComaInterval.ResumeLayout(False)
        Me.gbComaInterval.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents FolderSelect As KTGISUserControl.KtgisFolderSelector
    Friend WithEvents gbBaseImageFileName As System.Windows.Forms.GroupBox
    Friend WithEvents txtBaseImageFileName As System.Windows.Forms.TextBox
    Friend WithEvents gbHtml As System.Windows.Forms.GroupBox
    Friend WithEvents txtHTML As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAnimatedGIF As System.Windows.Forms.RadioButton
    Friend WithEvents rbWebImageAnime As System.Windows.Forms.RadioButton
    Friend WithEvents rbWebImageChange As System.Windows.Forms.RadioButton
    Friend WithEvents rbImage As System.Windows.Forms.RadioButton
    Friend WithEvents gbImageFormat As System.Windows.Forms.GroupBox
    Friend WithEvents rbEMF As System.Windows.Forms.RadioButton
    Friend WithEvents rbBMP As System.Windows.Forms.RadioButton
    Friend WithEvents rbJpeg As System.Windows.Forms.RadioButton
    Friend WithEvents rbPNG As System.Windows.Forms.RadioButton
    Friend WithEvents gbComaInterval As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtComaInterval As mandara10.TextNumberBox
    Friend WithEvents GIFFileSelect As KTGISUserControl.KtgisFileSelector
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLastComa As mandara10.TextNumberBox
    Friend WithEvents txtFirstComa As mandara10.TextNumberBox
End Class
