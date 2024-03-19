<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_MeshContour
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
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSRTM30Convert = New System.Windows.Forms.Button()
        Me.cboMeshData = New mandara10.ComboBoxEx()
        Me.FolderSelector = New KTGISUserControl.KtgisFolderSelector()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtAltitude = New mandara10.TextBoxFocusAllSelect()
        Me.btnClipBoard = New System.Windows.Forms.Button()
        Me.btnAllClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lbContour = New System.Windows.Forms.ListBox()
        Me.ProgressLabel = New KTGISUserControl.KTGISProgressLabel()
        Me.lblPos = New System.Windows.Forms.Label()
        Me.cboBackImage = New mandara10.ComboBoxEx()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(136, 431)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(203, 431)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'picMap
        '
        Me.picMap.BackColor = System.Drawing.Color.White
        Me.picMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMap.Location = New System.Drawing.Point(279, 11)
        Me.picMap.Margin = New System.Windows.Forms.Padding(2)
        Me.picMap.Name = "picMap"
        Me.picMap.Size = New System.Drawing.Size(526, 446)
        Me.picMap.TabIndex = 8
        Me.picMap.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSRTM30Convert)
        Me.GroupBox1.Controls.Add(Me.cboMeshData)
        Me.GroupBox1.Controls.Add(Me.FolderSelector)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(266, 126)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "取得標高データ"
        '
        'btnSRTM30Convert
        '
        Me.btnSRTM30Convert.Location = New System.Drawing.Point(171, 14)
        Me.btnSRTM30Convert.Name = "btnSRTM30Convert"
        Me.btnSRTM30Convert.Size = New System.Drawing.Size(90, 41)
        Me.btnSRTM30Convert.TabIndex = 16
        Me.btnSRTM30Convert.Text = "SRTM30/Plusコンバータ"
        Me.btnSRTM30Convert.UseVisualStyleBackColor = True
        '
        'cboMeshData
        '
        Me.cboMeshData.AsteriskSelectEnabled = False
        Me.cboMeshData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMeshData.FormattingEnabled = True
        Me.cboMeshData.IntegralHeight = False
        Me.cboMeshData.Location = New System.Drawing.Point(14, 25)
        Me.cboMeshData.Margin = New System.Windows.Forms.Padding(2)
        Me.cboMeshData.MaxDropDownItems = 10
        Me.cboMeshData.Name = "cboMeshData"
        Me.cboMeshData.Size = New System.Drawing.Size(152, 20)
        Me.cboMeshData.TabIndex = 0
        '
        'FolderSelector
        '
        Me.FolderSelector.AddFolder_Flag = False
        Me.FolderSelector.Caption = "データフォルダ"
        Me.FolderSelector.Folder = ""
        Me.FolderSelector.Location = New System.Drawing.Point(14, 64)
        Me.FolderSelector.Margin = New System.Windows.Forms.Padding(2)
        Me.FolderSelector.Name = "FolderSelector"
        Me.FolderSelector.Size = New System.Drawing.Size(231, 37)
        Me.FolderSelector.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtAltitude)
        Me.GroupBox2.Controls.Add(Me.btnClipBoard)
        Me.GroupBox2.Controls.Add(Me.btnAllClear)
        Me.GroupBox2.Controls.Add(Me.btnDelete)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.lbContour)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 148)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(266, 232)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "取得等高線"
        '
        'txtAltitude
        '
        Me.txtAltitude.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtAltitude.Location = New System.Drawing.Point(146, 42)
        Me.txtAltitude.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAltitude.Name = "txtAltitude"
        Me.txtAltitude.Size = New System.Drawing.Size(57, 19)
        Me.txtAltitude.TabIndex = 3
        Me.txtAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnClipBoard
        '
        Me.btnClipBoard.Location = New System.Drawing.Point(142, 90)
        Me.btnClipBoard.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClipBoard.Name = "btnClipBoard"
        Me.btnClipBoard.Size = New System.Drawing.Size(120, 22)
        Me.btnClipBoard.TabIndex = 5
        Me.btnClipBoard.Text = "クリップボードから追加"
        Me.btnClipBoard.UseVisualStyleBackColor = True
        '
        'btnAllClear
        '
        Me.btnAllClear.Location = New System.Drawing.Point(88, 197)
        Me.btnAllClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAllClear.Name = "btnAllClear"
        Me.btnAllClear.Size = New System.Drawing.Size(66, 22)
        Me.btnAllClear.TabIndex = 2
        Me.btnAllClear.Text = "すべて削除"
        Me.btnAllClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(18, 197)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(66, 22)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(212, 42)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 19)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lbContour
        '
        Me.lbContour.FormattingEnabled = True
        Me.lbContour.ItemHeight = 12
        Me.lbContour.Location = New System.Drawing.Point(14, 16)
        Me.lbContour.Margin = New System.Windows.Forms.Padding(2)
        Me.lbContour.Name = "lbContour"
        Me.lbContour.Size = New System.Drawing.Size(123, 172)
        Me.lbContour.TabIndex = 0
        '
        'ProgressLabel
        '
        Me.ProgressLabel.LabelColor = System.Drawing.SystemColors.Control
        Me.ProgressLabel.Location = New System.Drawing.Point(9, 394)
        Me.ProgressLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.Size = New System.Drawing.Size(208, 30)
        Me.ProgressLabel.TabIndex = 13
        Me.ProgressLabel.Visible = False
        '
        'lblPos
        '
        Me.lblPos.AutoSize = True
        Me.lblPos.Location = New System.Drawing.Point(289, 27)
        Me.lblPos.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPos.Name = "lblPos"
        Me.lblPos.Size = New System.Drawing.Size(36, 12)
        Me.lblPos.TabIndex = 15
        Me.lblPos.Text = "lblPos"
        '
        'cboBackImage
        '
        Me.cboBackImage.AsteriskSelectEnabled = False
        Me.cboBackImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBackImage.FormattingEnabled = True
        Me.cboBackImage.IntegralHeight = False
        Me.cboBackImage.Location = New System.Drawing.Point(673, 24)
        Me.cboBackImage.Margin = New System.Windows.Forms.Padding(2)
        Me.cboBackImage.Name = "cboBackImage"
        Me.cboBackImage.Size = New System.Drawing.Size(120, 20)
        Me.cboBackImage.TabIndex = 14
        '
        'frmMED_MeshContour
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(816, 473)
        Me.Controls.Add(Me.lblPos)
        Me.Controls.Add(Me.cboBackImage)
        Me.Controls.Add(Me.ProgressLabel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.picMap)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_MeshContour"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "標高データから等高線取得"
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboMeshData As mandara10.ComboBoxEx
    Friend WithEvents FolderSelector As KTGISUserControl.KtgisFolderSelector
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClipBoard As System.Windows.Forms.Button
    Friend WithEvents btnAllClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lbContour As System.Windows.Forms.ListBox
    Friend WithEvents txtAltitude As mandara10.TextBoxFocusAllSelect
    Friend WithEvents ProgressLabel As KTGISUserControl.KTGISProgressLabel
    Friend WithEvents cboBackImage As mandara10.ComboBoxEx
    Friend WithEvents lblPos As System.Windows.Forms.Label
    Friend WithEvents btnSRTM30Convert As System.Windows.Forms.Button
End Class
