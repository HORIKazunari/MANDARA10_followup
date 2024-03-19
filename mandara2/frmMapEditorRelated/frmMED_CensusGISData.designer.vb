<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_CensusGISData
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
        Me.components = New System.ComponentModel.Container()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.ktFolder = New KTGISUserControl.KtgisFolderSelector()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressLabel = New KTGISUserControl.KTGISProgressLabel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbAddPrefName = New System.Windows.Forms.CheckBox()
        Me.rbCode = New System.Windows.Forms.RadioButton()
        Me.rbName = New System.Windows.Forms.RadioButton()
        Me.cbArea = New mandara10.CheckedListBoxEx()
        Me.chkWaterArea = New System.Windows.Forms.CheckBox()
        Me.grAttrData = New System.Windows.Forms.GroupBox()
        Me.FileSelect = New KTGISUserControl.KtgisFileSelector()
        Me.rbDefATT = New System.Windows.Forms.RadioButton()
        Me.rbCSV = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbZero = New System.Windows.Forms.RadioButton()
        Me.rbMissing = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.grAttrData.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(461, 310)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(394, 310)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'ktFolder
        '
        Me.ktFolder.AddFolder_Flag = False
        Me.ktFolder.Caption = "データフォルダ"
        Me.ktFolder.Folder = ""
        Me.ktFolder.Location = New System.Drawing.Point(11, 11)
        Me.ktFolder.Margin = New System.Windows.Forms.Padding(2)
        Me.ktFolder.Name = "ktFolder"
        Me.ktFolder.Size = New System.Drawing.Size(441, 42)
        Me.ktFolder.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "取得都道府県・市区町村"
        '
        'ProgressLabel
        '
        Me.ProgressLabel.LabelColor = System.Drawing.SystemColors.Control
        Me.ProgressLabel.Location = New System.Drawing.Point(129, 313)
        Me.ProgressLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.Size = New System.Drawing.Size(137, 30)
        Me.ProgressLabel.TabIndex = 26
        Me.ProgressLabel.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(10, 313)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(112, 21)
        Me.ProgressBar1.TabIndex = 27
        Me.ProgressBar1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbAddPrefName)
        Me.GroupBox1.Controls.Add(Me.rbCode)
        Me.GroupBox1.Controls.Add(Me.rbName)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 221)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 63)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "オブジェクト名"
        '
        'cbAddPrefName
        '
        Me.cbAddPrefName.AutoSize = True
        Me.cbAddPrefName.Location = New System.Drawing.Point(52, 40)
        Me.cbAddPrefName.Name = "cbAddPrefName"
        Me.cbAddPrefName.Size = New System.Drawing.Size(121, 16)
        Me.cbAddPrefName.TabIndex = 2
        Me.cbAddPrefName.Text = "都道府県名をつける"
        Me.cbAddPrefName.UseVisualStyleBackColor = True
        '
        'rbCode
        '
        Me.rbCode.AutoSize = True
        Me.rbCode.Location = New System.Drawing.Point(131, 18)
        Me.rbCode.Name = "rbCode"
        Me.rbCode.Size = New System.Drawing.Size(72, 16)
        Me.rbCode.TabIndex = 1
        Me.rbCode.Text = "Key Code"
        Me.rbCode.UseVisualStyleBackColor = True
        '
        'rbName
        '
        Me.rbName.AutoSize = True
        Me.rbName.Checked = True
        Me.rbName.Location = New System.Drawing.Point(35, 19)
        Me.rbName.Name = "rbName"
        Me.rbName.Size = New System.Drawing.Size(47, 16)
        Me.rbName.TabIndex = 0
        Me.rbName.TabStop = True
        Me.rbName.Text = "名称"
        Me.rbName.UseVisualStyleBackColor = True
        '
        'cbArea
        '
        Me.cbArea.CheckOnClick = True
        Me.cbArea.EventStop = True
        Me.cbArea.FormattingEnabled = True
        Me.cbArea.Location = New System.Drawing.Point(11, 84)
        Me.cbArea.Name = "cbArea"
        Me.cbArea.Size = New System.Drawing.Size(216, 130)
        Me.cbArea.TabIndex = 1
        '
        'chkWaterArea
        '
        Me.chkWaterArea.AutoSize = True
        Me.chkWaterArea.Location = New System.Drawing.Point(14, 290)
        Me.chkWaterArea.Name = "chkWaterArea"
        Me.chkWaterArea.Size = New System.Drawing.Size(151, 16)
        Me.chkWaterArea.TabIndex = 3
        Me.chkWaterArea.Text = "水面オブジェクトを取得する"
        Me.chkWaterArea.UseVisualStyleBackColor = True
        '
        'grAttrData
        '
        Me.grAttrData.Controls.Add(Me.FileSelect)
        Me.grAttrData.Controls.Add(Me.rbDefATT)
        Me.grAttrData.Controls.Add(Me.rbCSV)
        Me.grAttrData.Location = New System.Drawing.Point(242, 84)
        Me.grAttrData.Name = "grAttrData"
        Me.grAttrData.Size = New System.Drawing.Size(287, 135)
        Me.grAttrData.TabIndex = 4
        Me.grAttrData.TabStop = False
        Me.grAttrData.Text = "属性データ"
        '
        'FileSelect
        '
        Me.FileSelect.Caption = "出力CSVファイル"
        Me.FileSelect.Extension = "csv"
        Me.FileSelect.InitFolder = ""
        Me.FileSelect.Location = New System.Drawing.Point(35, 40)
        Me.FileSelect.Name = "FileSelect"
        Me.FileSelect.Off_Button_Flag = False
        Me.FileSelect.Path = ""
        Me.FileSelect.Save_Flag = True
        Me.FileSelect.Size = New System.Drawing.Size(246, 44)
        Me.FileSelect.TabIndex = 2
        '
        'rbDefATT
        '
        Me.rbDefATT.Location = New System.Drawing.Point(23, 90)
        Me.rbDefATT.Name = "rbDefATT"
        Me.rbDefATT.Size = New System.Drawing.Size(157, 29)
        Me.rbDefATT.TabIndex = 0
        Me.rbDefATT.Text = "地図ファイル中の初期属性データに保存"
        Me.rbDefATT.UseVisualStyleBackColor = True
        '
        'rbCSV
        '
        Me.rbCSV.AutoSize = True
        Me.rbCSV.Checked = True
        Me.rbCSV.Location = New System.Drawing.Point(23, 18)
        Me.rbCSV.Name = "rbCSV"
        Me.rbCSV.Size = New System.Drawing.Size(113, 16)
        Me.rbCSV.TabIndex = 1
        Me.rbCSV.TabStop = True
        Me.rbCSV.Text = "CSVファイルに出力"
        Me.rbCSV.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbZero)
        Me.GroupBox3.Controls.Add(Me.rbMissing)
        Me.GroupBox3.Location = New System.Drawing.Point(242, 225)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(287, 59)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "秘匿値"
        '
        'rbZero
        '
        Me.rbZero.AutoSize = True
        Me.rbZero.Checked = True
        Me.rbZero.Location = New System.Drawing.Point(35, 24)
        Me.rbZero.Name = "rbZero"
        Me.rbZero.Size = New System.Drawing.Size(57, 16)
        Me.rbZero.TabIndex = 0
        Me.rbZero.TabStop = True
        Me.rbZero.Text = "0にする"
        Me.rbZero.UseVisualStyleBackColor = True
        '
        'rbMissing
        '
        Me.rbMissing.AutoSize = True
        Me.rbMissing.Location = New System.Drawing.Point(127, 25)
        Me.rbMissing.Name = "rbMissing"
        Me.rbMissing.Size = New System.Drawing.Size(87, 16)
        Me.rbMissing.TabIndex = 1
        Me.rbMissing.Text = "欠損値にする"
        Me.rbMissing.UseVisualStyleBackColor = True
        '
        'frmMED_CensusGISData
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(541, 352)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grAttrData)
        Me.Controls.Add(Me.chkWaterArea)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ProgressLabel)
        Me.Controls.Add(Me.cbArea)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ktFolder)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_CensusGISData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "統計GIS国勢調査小地域データ"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grAttrData.ResumeLayout(False)
        Me.grAttrData.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ktFolder As KTGISUserControl.KtgisFolderSelector
    Friend WithEvents cbArea As mandara10.CheckedListBoxEx
    Friend WithEvents ProgressLabel As KTGISUserControl.KTGISProgressLabel
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCode As System.Windows.Forms.RadioButton
    Friend WithEvents rbName As System.Windows.Forms.RadioButton
    Friend WithEvents chkWaterArea As System.Windows.Forms.CheckBox
    Friend WithEvents grAttrData As System.Windows.Forms.GroupBox
    Friend WithEvents rbDefATT As System.Windows.Forms.RadioButton
    Friend WithEvents rbCSV As System.Windows.Forms.RadioButton
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FileSelect As KTGISUserControl.KtgisFileSelector
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbZero As System.Windows.Forms.RadioButton
    Friend WithEvents rbMissing As System.Windows.Forms.RadioButton
    Friend WithEvents cbAddPrefName As System.Windows.Forms.CheckBox
End Class
