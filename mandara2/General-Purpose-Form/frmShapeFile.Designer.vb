<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShapeFile
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        Me.gbProjection = New System.Windows.Forms.GroupBox()
        Me.gbShapeFileInfo = New System.Windows.Forms.GroupBox()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.chkCommonChange = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbSystem = New System.Windows.Forms.GroupBox()
        Me.rbD_Other = New System.Windows.Forms.RadioButton()
        Me.rbD_World = New System.Windows.Forms.RadioButton()
        Me.rbD_Tokyo = New System.Windows.Forms.RadioButton()
        Me.gbMode = New System.Windows.Forms.GroupBox()
        Me.cbKeiNumber = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbOther = New System.Windows.Forms.RadioButton()
        Me.rbJapanZone = New System.Windows.Forms.RadioButton()
        Me.rbLatLon = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblShape = New System.Windows.Forms.Label()
        Me.lbPRJ = New System.Windows.Forms.Label()
        Me.lbSHX = New System.Windows.Forms.Label()
        Me.lbDBF = New System.Windows.Forms.Label()
        Me.txtFullPath = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbFile = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkTopology = New System.Windows.Forms.CheckBox()
        Me.chkIntegrate = New System.Windows.Forms.CheckBox()
        Me.cboEncoding = New mandara10.ComboBoxEx()
        Me.cbProjection = New mandara10.ComboBoxEx()
        Me.gbProjection.SuspendLayout()
        Me.gbShapeFileInfo.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbSystem.SuspendLayout()
        Me.gbMode.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(400, 345)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(478, 345)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(29, 198)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(62, 25)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 12)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "読み込むシェープファイル"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(97, 198)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(62, 25)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "取り消し"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.Location = New System.Drawing.Point(165, 198)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(93, 25)
        Me.btnDeleteAll.TabIndex = 3
        Me.btnDeleteAll.Text = "全て取り消し"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        '
        'gbProjection
        '
        Me.gbProjection.Controls.Add(Me.cbProjection)
        Me.gbProjection.Location = New System.Drawing.Point(59, 241)
        Me.gbProjection.Name = "gbProjection"
        Me.gbProjection.Size = New System.Drawing.Size(169, 47)
        Me.gbProjection.TabIndex = 4
        Me.gbProjection.TabStop = False
        Me.gbProjection.Text = "投影法"
        '
        'gbShapeFileInfo
        '
        Me.gbShapeFileInfo.Controls.Add(Me.pnlInfo)
        Me.gbShapeFileInfo.Location = New System.Drawing.Point(269, 28)
        Me.gbShapeFileInfo.Name = "gbShapeFileInfo"
        Me.gbShapeFileInfo.Size = New System.Drawing.Size(274, 311)
        Me.gbShapeFileInfo.TabIndex = 5
        Me.gbShapeFileInfo.TabStop = False
        Me.gbShapeFileInfo.Text = "gbShapeFileInfo"
        '
        'pnlInfo
        '
        Me.pnlInfo.Controls.Add(Me.chkCommonChange)
        Me.pnlInfo.Controls.Add(Me.GroupBox1)
        Me.pnlInfo.Controls.Add(Me.gbSystem)
        Me.pnlInfo.Controls.Add(Me.gbMode)
        Me.pnlInfo.Controls.Add(Me.GroupBox4)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInfo.Location = New System.Drawing.Point(3, 15)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(268, 293)
        Me.pnlInfo.TabIndex = 0
        '
        'chkCommonChange
        '
        Me.chkCommonChange.AutoSize = True
        Me.chkCommonChange.Checked = True
        Me.chkCommonChange.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCommonChange.Location = New System.Drawing.Point(157, 145)
        Me.chkCommonChange.Name = "chkCommonChange"
        Me.chkCommonChange.Size = New System.Drawing.Size(94, 16)
        Me.chkCommonChange.TabIndex = 1
        Me.chkCommonChange.Text = "全ファイル共通"
        Me.chkCommonChange.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboEncoding)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 127)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(142, 47)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "文字コード"
        '
        'gbSystem
        '
        Me.gbSystem.Controls.Add(Me.rbD_Other)
        Me.gbSystem.Controls.Add(Me.rbD_World)
        Me.gbSystem.Controls.Add(Me.rbD_Tokyo)
        Me.gbSystem.Location = New System.Drawing.Point(149, 180)
        Me.gbSystem.Name = "gbSystem"
        Me.gbSystem.Size = New System.Drawing.Size(111, 110)
        Me.gbSystem.TabIndex = 3
        Me.gbSystem.TabStop = False
        Me.gbSystem.Text = "測地系"
        '
        'rbD_Other
        '
        Me.rbD_Other.AutoSize = True
        Me.rbD_Other.Location = New System.Drawing.Point(22, 73)
        Me.rbD_Other.Name = "rbD_Other"
        Me.rbD_Other.Size = New System.Drawing.Size(84, 16)
        Me.rbD_Other.TabIndex = 3
        Me.rbD_Other.TabStop = True
        Me.rbD_Other.Text = "その他・不明"
        Me.rbD_Other.UseVisualStyleBackColor = True
        '
        'rbD_World
        '
        Me.rbD_World.AutoSize = True
        Me.rbD_World.Location = New System.Drawing.Point(22, 50)
        Me.rbD_World.Name = "rbD_World"
        Me.rbD_World.Size = New System.Drawing.Size(83, 16)
        Me.rbD_World.TabIndex = 2
        Me.rbD_World.TabStop = True
        Me.rbD_World.Text = "世界測地系"
        Me.rbD_World.UseVisualStyleBackColor = True
        '
        'rbD_Tokyo
        '
        Me.rbD_Tokyo.AutoSize = True
        Me.rbD_Tokyo.Location = New System.Drawing.Point(22, 28)
        Me.rbD_Tokyo.Name = "rbD_Tokyo"
        Me.rbD_Tokyo.Size = New System.Drawing.Size(83, 16)
        Me.rbD_Tokyo.TabIndex = 1
        Me.rbD_Tokyo.TabStop = True
        Me.rbD_Tokyo.Text = "日本測地系"
        Me.rbD_Tokyo.UseVisualStyleBackColor = True
        '
        'gbMode
        '
        Me.gbMode.Controls.Add(Me.cbKeiNumber)
        Me.gbMode.Controls.Add(Me.Label2)
        Me.gbMode.Controls.Add(Me.rbOther)
        Me.gbMode.Controls.Add(Me.rbJapanZone)
        Me.gbMode.Controls.Add(Me.rbLatLon)
        Me.gbMode.Location = New System.Drawing.Point(9, 180)
        Me.gbMode.Name = "gbMode"
        Me.gbMode.Size = New System.Drawing.Size(134, 110)
        Me.gbMode.TabIndex = 2
        Me.gbMode.TabStop = False
        Me.gbMode.Text = "座標系"
        '
        'cbKeiNumber
        '
        Me.cbKeiNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbKeiNumber.FormattingEnabled = True
        Me.cbKeiNumber.Location = New System.Drawing.Point(85, 59)
        Me.cbKeiNumber.MaxDropDownItems = 20
        Me.cbKeiNumber.Name = "cbKeiNumber"
        Me.cbKeiNumber.Size = New System.Drawing.Size(37, 20)
        Me.cbKeiNumber.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "系番号"
        '
        'rbOther
        '
        Me.rbOther.AutoSize = True
        Me.rbOther.Location = New System.Drawing.Point(21, 87)
        Me.rbOther.Name = "rbOther"
        Me.rbOther.Size = New System.Drawing.Size(54, 16)
        Me.rbOther.TabIndex = 2
        Me.rbOther.TabStop = True
        Me.rbOther.Text = "その他"
        Me.rbOther.UseVisualStyleBackColor = True
        '
        'rbJapanZone
        '
        Me.rbJapanZone.AutoSize = True
        Me.rbJapanZone.Location = New System.Drawing.Point(21, 40)
        Me.rbJapanZone.Name = "rbJapanZone"
        Me.rbJapanZone.Size = New System.Drawing.Size(71, 16)
        Me.rbJapanZone.TabIndex = 1
        Me.rbJapanZone.TabStop = True
        Me.rbJapanZone.Text = "平面直角"
        Me.rbJapanZone.UseVisualStyleBackColor = True
        '
        'rbLatLon
        '
        Me.rbLatLon.AutoSize = True
        Me.rbLatLon.Location = New System.Drawing.Point(21, 18)
        Me.rbLatLon.Name = "rbLatLon"
        Me.rbLatLon.Size = New System.Drawing.Size(71, 16)
        Me.rbLatLon.TabIndex = 0
        Me.rbLatLon.TabStop = True
        Me.rbLatLon.Text = "緯度経度"
        Me.rbLatLon.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblShape)
        Me.GroupBox4.Controls.Add(Me.lbPRJ)
        Me.GroupBox4.Controls.Add(Me.lbSHX)
        Me.GroupBox4.Controls.Add(Me.lbDBF)
        Me.GroupBox4.Controls.Add(Me.txtFullPath)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(249, 108)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "関連ファイル"
        '
        'lblShape
        '
        Me.lblShape.BackColor = System.Drawing.Color.White
        Me.lblShape.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblShape.Location = New System.Drawing.Point(16, 80)
        Me.lblShape.Name = "lblShape"
        Me.lblShape.Size = New System.Drawing.Size(90, 15)
        Me.lblShape.TabIndex = 5
        Me.lblShape.Text = "shape"
        '
        'lbPRJ
        '
        Me.lbPRJ.BackColor = System.Drawing.Color.White
        Me.lbPRJ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbPRJ.Location = New System.Drawing.Point(16, 59)
        Me.lbPRJ.Name = "lbPRJ"
        Me.lbPRJ.Size = New System.Drawing.Size(90, 15)
        Me.lbPRJ.TabIndex = 2
        Me.lbPRJ.Text = "PRJ"
        '
        'lbSHX
        '
        Me.lbSHX.BackColor = System.Drawing.Color.White
        Me.lbSHX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbSHX.Location = New System.Drawing.Point(16, 36)
        Me.lbSHX.Name = "lbSHX"
        Me.lbSHX.Size = New System.Drawing.Size(90, 15)
        Me.lbSHX.TabIndex = 0
        Me.lbSHX.Text = "SHX"
        '
        'lbDBF
        '
        Me.lbDBF.BackColor = System.Drawing.Color.White
        Me.lbDBF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbDBF.Location = New System.Drawing.Point(120, 36)
        Me.lbDBF.Name = "lbDBF"
        Me.lbDBF.Size = New System.Drawing.Size(108, 30)
        Me.lbDBF.TabIndex = 1
        Me.lbDBF.Text = "DBF"
        '
        'txtFullPath
        '
        Me.txtFullPath.BackColor = System.Drawing.Color.White
        Me.txtFullPath.Location = New System.Drawing.Point(6, 14)
        Me.txtFullPath.Name = "txtFullPath"
        Me.txtFullPath.ReadOnly = True
        Me.txtFullPath.Size = New System.Drawing.Size(237, 19)
        Me.txtFullPath.TabIndex = 4
        '
        'lbFile
        '
        Me.lbFile.FormattingEnabled = True
        Me.lbFile.ItemHeight = 12
        Me.lbFile.Location = New System.Drawing.Point(15, 33)
        Me.lbFile.Margin = New System.Windows.Forms.Padding(2)
        Me.lbFile.Name = "lbFile"
        Me.lbFile.Size = New System.Drawing.Size(243, 160)
        Me.lbFile.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(267, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 12)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "シェープファイル情報"
        '
        'chkTopology
        '
        Me.chkTopology.AutoSize = True
        Me.chkTopology.Location = New System.Drawing.Point(59, 303)
        Me.chkTopology.Name = "chkTopology"
        Me.chkTopology.Size = New System.Drawing.Size(182, 16)
        Me.chkTopology.TabIndex = 23
        Me.chkTopology.Text = "面形状ファイルを位相構造化する"
        Me.chkTopology.UseVisualStyleBackColor = True
        '
        'chkIntegrate
        '
        Me.chkIntegrate.AutoSize = True
        Me.chkIntegrate.Location = New System.Drawing.Point(59, 325)
        Me.chkIntegrate.Name = "chkIntegrate"
        Me.chkIntegrate.Size = New System.Drawing.Size(134, 16)
        Me.chkIntegrate.TabIndex = 24
        Me.chkIntegrate.Text = "ひとつのレイヤにまとめる"
        Me.chkIntegrate.UseVisualStyleBackColor = True
        '
        'cboEncoding
        '
        Me.cboEncoding.AsteriskSelectEnabled = False
        Me.cboEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEncoding.FormattingEnabled = True
        Me.cboEncoding.IntegralHeight = False
        Me.cboEncoding.Location = New System.Drawing.Point(6, 18)
        Me.cboEncoding.MaxDropDownItems = 12
        Me.cboEncoding.Name = "cboEncoding"
        Me.cboEncoding.Size = New System.Drawing.Size(126, 20)
        Me.cboEncoding.TabIndex = 0
        '
        'cbProjection
        '
        Me.cbProjection.AsteriskSelectEnabled = False
        Me.cbProjection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProjection.FormattingEnabled = True
        Me.cbProjection.IntegralHeight = False
        Me.cbProjection.Location = New System.Drawing.Point(20, 20)
        Me.cbProjection.Name = "cbProjection"
        Me.cbProjection.Size = New System.Drawing.Size(131, 20)
        Me.cbProjection.TabIndex = 0
        '
        'frmShapeFile
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(555, 374)
        Me.Controls.Add(Me.chkIntegrate)
        Me.Controls.Add(Me.chkTopology)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbFile)
        Me.Controls.Add(Me.btnDeleteAll)
        Me.Controls.Add(Me.gbShapeFileInfo)
        Me.Controls.Add(Me.gbProjection)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmShapeFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "シェープファイル読み込み"
        Me.gbProjection.ResumeLayout(False)
        Me.gbShapeFileInfo.ResumeLayout(False)
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.gbSystem.ResumeLayout(False)
        Me.gbSystem.PerformLayout()
        Me.gbMode.ResumeLayout(False)
        Me.gbMode.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents gbProjection As System.Windows.Forms.GroupBox
    Friend WithEvents cbProjection As mandara10.ComboBoxEx
    Friend WithEvents gbShapeFileInfo As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents gbSystem As System.Windows.Forms.GroupBox
    Friend WithEvents rbD_Other As System.Windows.Forms.RadioButton
    Friend WithEvents rbD_World As System.Windows.Forms.RadioButton
    Friend WithEvents rbD_Tokyo As System.Windows.Forms.RadioButton
    Friend WithEvents gbMode As System.Windows.Forms.GroupBox
    Friend WithEvents cbKeiNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbOther As System.Windows.Forms.RadioButton
    Friend WithEvents rbJapanZone As System.Windows.Forms.RadioButton
    Friend WithEvents rbLatLon As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lbPRJ As System.Windows.Forms.Label
    Friend WithEvents lbSHX As System.Windows.Forms.Label
    Friend WithEvents lbDBF As System.Windows.Forms.Label
    Friend WithEvents txtFullPath As System.Windows.Forms.TextBox
    Friend WithEvents lbFile As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboEncoding As mandara10.ComboBoxEx
    Friend WithEvents chkCommonChange As System.Windows.Forms.CheckBox
    Friend WithEvents chkTopology As System.Windows.Forms.CheckBox
    Friend WithEvents chkIntegrate As System.Windows.Forms.CheckBox
    Friend WithEvents lblShape As System.Windows.Forms.Label
End Class
