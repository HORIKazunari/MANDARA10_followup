<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTileMapServiceSelect
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
        Me.cbVisible = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.hsbAlphaValue = New System.Windows.Forms.HScrollBar()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnUserTile = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboTileDataSet = New mandara10.ComboBoxEx()
        Me.cboTileTag = New mandara10.ComboBoxEx()
        Me.FolderSelectorUser = New KTGISUserControl.KtgisFolderSelector()
        Me.FolderSelectorWorldFile = New KTGISUserControl.KtgisFolderSelector()
        Me.rbWorldFile = New System.Windows.Forms.RadioButton()
        Me.rbUser = New System.Windows.Forms.RadioButton()
        Me.rbTileMap = New System.Windows.Forms.RadioButton()
        Me.gbDrawTiming = New System.Windows.Forms.GroupBox()
        Me.rbAfterDraw = New System.Windows.Forms.RadioButton()
        Me.rbBeforeDraw = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkTransparent = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gbDrawTiming.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(363, 316)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(437, 316)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cbVisible
        '
        Me.cbVisible.AutoSize = True
        Me.cbVisible.Location = New System.Drawing.Point(17, 20)
        Me.cbVisible.Margin = New System.Windows.Forms.Padding(2)
        Me.cbVisible.Name = "cbVisible"
        Me.cbVisible.Size = New System.Drawing.Size(105, 16)
        Me.cbVisible.TabIndex = 0
        Me.cbVisible.Text = "背景画像を表示"
        Me.cbVisible.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(170, 228)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(168, 72)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "透過度"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(116, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "不透明"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "透明"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.hsbAlphaValue)
        Me.Panel1.Location = New System.Drawing.Point(13, 27)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(145, 19)
        Me.Panel1.TabIndex = 21
        '
        'hsbAlphaValue
        '
        Me.hsbAlphaValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hsbAlphaValue.LargeChange = 1
        Me.hsbAlphaValue.Location = New System.Drawing.Point(0, 0)
        Me.hsbAlphaValue.Maximum = 255
        Me.hsbAlphaValue.Name = "hsbAlphaValue"
        Me.hsbAlphaValue.Size = New System.Drawing.Size(143, 17)
        Me.hsbAlphaValue.TabIndex = 24
        Me.hsbAlphaValue.Value = 255
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnUserTile)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.FolderSelectorUser)
        Me.GroupBox2.Controls.Add(Me.FolderSelectorWorldFile)
        Me.GroupBox2.Controls.Add(Me.rbWorldFile)
        Me.GroupBox2.Controls.Add(Me.rbUser)
        Me.GroupBox2.Controls.Add(Me.rbTileMap)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 40)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(482, 177)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "表示画像"
        '
        'btnUserTile
        '
        Me.btnUserTile.Location = New System.Drawing.Point(99, 140)
        Me.btnUserTile.Name = "btnUserTile"
        Me.btnUserTile.Size = New System.Drawing.Size(135, 23)
        Me.btnUserTile.TabIndex = 1
        Me.btnUserTile.Text = "ユーザー設定タイルマップ"
        Me.btnUserTile.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboTileDataSet)
        Me.GroupBox4.Controls.Add(Me.cboTileTag)
        Me.GroupBox4.Location = New System.Drawing.Point(28, 50)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(206, 83)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'cboTileDataSet
        '
        Me.cboTileDataSet.AsteriskSelectEnabled = False
        Me.cboTileDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTileDataSet.FormattingEnabled = True
        Me.cboTileDataSet.IntegralHeight = False
        Me.cboTileDataSet.Location = New System.Drawing.Point(4, 51)
        Me.cboTileDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTileDataSet.MaxDropDownItems = 20
        Me.cboTileDataSet.Name = "cboTileDataSet"
        Me.cboTileDataSet.Size = New System.Drawing.Size(194, 20)
        Me.cboTileDataSet.TabIndex = 1
        '
        'cboTileTag
        '
        Me.cboTileTag.AsteriskSelectEnabled = False
        Me.cboTileTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTileTag.FormattingEnabled = True
        Me.cboTileTag.IntegralHeight = False
        Me.cboTileTag.Location = New System.Drawing.Point(4, 16)
        Me.cboTileTag.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTileTag.MaxDropDownItems = 15
        Me.cboTileTag.Name = "cboTileTag"
        Me.cboTileTag.Size = New System.Drawing.Size(194, 20)
        Me.cboTileTag.TabIndex = 0
        '
        'FolderSelectorUser
        '
        Me.FolderSelectorUser.AddFolder_Flag = False
        Me.FolderSelectorUser.Caption = "フォルダ"
        Me.FolderSelectorUser.Folder = ""
        Me.FolderSelectorUser.Location = New System.Drawing.Point(264, 54)
        Me.FolderSelectorUser.Margin = New System.Windows.Forms.Padding(2)
        Me.FolderSelectorUser.Name = "FolderSelectorUser"
        Me.FolderSelectorUser.Size = New System.Drawing.Size(204, 38)
        Me.FolderSelectorUser.TabIndex = 2
        '
        'FolderSelectorWorldFile
        '
        Me.FolderSelectorWorldFile.AddFolder_Flag = False
        Me.FolderSelectorWorldFile.Caption = "フォルダ"
        Me.FolderSelectorWorldFile.Folder = ""
        Me.FolderSelectorWorldFile.Location = New System.Drawing.Point(264, 125)
        Me.FolderSelectorWorldFile.Margin = New System.Windows.Forms.Padding(2)
        Me.FolderSelectorWorldFile.Name = "FolderSelectorWorldFile"
        Me.FolderSelectorWorldFile.Size = New System.Drawing.Size(204, 38)
        Me.FolderSelectorWorldFile.TabIndex = 11
        '
        'rbWorldFile
        '
        Me.rbWorldFile.AutoSize = True
        Me.rbWorldFile.Location = New System.Drawing.Point(247, 105)
        Me.rbWorldFile.Margin = New System.Windows.Forms.Padding(2)
        Me.rbWorldFile.Name = "rbWorldFile"
        Me.rbWorldFile.Size = New System.Drawing.Size(174, 16)
        Me.rbWorldFile.TabIndex = 3
        Me.rbWorldFile.TabStop = True
        Me.rbWorldFile.Text = "ワールドファイル付き画像ファイル"
        Me.rbWorldFile.UseVisualStyleBackColor = True
        '
        'rbUser
        '
        Me.rbUser.AutoSize = True
        Me.rbUser.Location = New System.Drawing.Point(247, 30)
        Me.rbUser.Margin = New System.Windows.Forms.Padding(2)
        Me.rbUser.Name = "rbUser"
        Me.rbUser.Size = New System.Drawing.Size(123, 16)
        Me.rbUser.TabIndex = 7
        Me.rbUser.TabStop = True
        Me.rbUser.Text = "ユーザ－画像ファイル"
        Me.rbUser.UseVisualStyleBackColor = True
        '
        'rbTileMap
        '
        Me.rbTileMap.AutoSize = True
        Me.rbTileMap.Location = New System.Drawing.Point(15, 30)
        Me.rbTileMap.Margin = New System.Windows.Forms.Padding(2)
        Me.rbTileMap.Name = "rbTileMap"
        Me.rbTileMap.Size = New System.Drawing.Size(112, 16)
        Me.rbTileMap.TabIndex = 0
        Me.rbTileMap.TabStop = True
        Me.rbTileMap.Text = "タイルマップサービス"
        Me.rbTileMap.UseVisualStyleBackColor = True
        '
        'gbDrawTiming
        '
        Me.gbDrawTiming.Controls.Add(Me.rbAfterDraw)
        Me.gbDrawTiming.Controls.Add(Me.rbBeforeDraw)
        Me.gbDrawTiming.Location = New System.Drawing.Point(17, 228)
        Me.gbDrawTiming.Margin = New System.Windows.Forms.Padding(2)
        Me.gbDrawTiming.Name = "gbDrawTiming"
        Me.gbDrawTiming.Padding = New System.Windows.Forms.Padding(2)
        Me.gbDrawTiming.Size = New System.Drawing.Size(140, 72)
        Me.gbDrawTiming.TabIndex = 2
        Me.gbDrawTiming.TabStop = False
        Me.gbDrawTiming.Text = "描画タイミング"
        '
        'rbAfterDraw
        '
        Me.rbAfterDraw.AutoSize = True
        Me.rbAfterDraw.Location = New System.Drawing.Point(14, 46)
        Me.rbAfterDraw.Margin = New System.Windows.Forms.Padding(2)
        Me.rbAfterDraw.Name = "rbAfterDraw"
        Me.rbAfterDraw.Size = New System.Drawing.Size(87, 16)
        Me.rbAfterDraw.TabIndex = 2
        Me.rbAfterDraw.TabStop = True
        Me.rbAfterDraw.Text = "データ描画後"
        Me.rbAfterDraw.UseVisualStyleBackColor = True
        '
        'rbBeforeDraw
        '
        Me.rbBeforeDraw.AutoSize = True
        Me.rbBeforeDraw.Location = New System.Drawing.Point(14, 23)
        Me.rbBeforeDraw.Margin = New System.Windows.Forms.Padding(2)
        Me.rbBeforeDraw.Name = "rbBeforeDraw"
        Me.rbBeforeDraw.Size = New System.Drawing.Size(87, 16)
        Me.rbBeforeDraw.TabIndex = 1
        Me.rbBeforeDraw.TabStop = True
        Me.rbBeforeDraw.Text = "データ描画前"
        Me.rbBeforeDraw.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkTransparent)
        Me.GroupBox3.Location = New System.Drawing.Point(359, 228)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(140, 72)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "白地透過"
        '
        'chkTransparent
        '
        Me.chkTransparent.AutoSize = True
        Me.chkTransparent.Location = New System.Drawing.Point(28, 30)
        Me.chkTransparent.Name = "chkTransparent"
        Me.chkTransparent.Size = New System.Drawing.Size(72, 16)
        Me.chkTransparent.TabIndex = 0
        Me.chkTransparent.Text = "白地透過"
        Me.chkTransparent.UseVisualStyleBackColor = True
        '
        'frmTileMapServiceSelect
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(514, 351)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.gbDrawTiming)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbVisible)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTileMapServiceSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "背景画像設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.gbDrawTiming.ResumeLayout(False)
        Me.gbDrawTiming.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cbVisible As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents hsbAlphaValue As System.Windows.Forms.HScrollBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbWorldFile As System.Windows.Forms.RadioButton
    Friend WithEvents rbUser As System.Windows.Forms.RadioButton
    Friend WithEvents rbTileMap As System.Windows.Forms.RadioButton
    Friend WithEvents gbDrawTiming As System.Windows.Forms.GroupBox
    Friend WithEvents rbAfterDraw As System.Windows.Forms.RadioButton
    Friend WithEvents rbBeforeDraw As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderSelectorUser As KTGISUserControl.KtgisFolderSelector
    Friend WithEvents FolderSelectorWorldFile As KTGISUserControl.KtgisFolderSelector
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTransparent As System.Windows.Forms.CheckBox
    Friend WithEvents cboTileTag As mandara10.ComboBoxEx
    Friend WithEvents cboTileDataSet As mandara10.ComboBoxEx
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUserTile As System.Windows.Forms.Button
End Class
