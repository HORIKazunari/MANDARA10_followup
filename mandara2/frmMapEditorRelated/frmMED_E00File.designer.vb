<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_E00File
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
        Me.lbFile = New System.Windows.Forms.ListBox()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        Me.gbE00FileInfo = New System.Windows.Forms.GroupBox()
        Me.pnlInfo = New System.Windows.Forms.Panel()
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
        Me.gbProjection = New System.Windows.Forms.GroupBox()
        Me.cbProjection = New mandara10.ComboBoxEx()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbE00FileInfo.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        Me.gbSystem.SuspendLayout()
        Me.gbMode.SuspendLayout()
        Me.gbProjection.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(479, 234)
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
        Me.btnOK.Location = New System.Drawing.Point(412, 234)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lbFile
        '
        Me.lbFile.FormattingEnabled = True
        Me.lbFile.ItemHeight = 12
        Me.lbFile.Location = New System.Drawing.Point(17, 41)
        Me.lbFile.Margin = New System.Windows.Forms.Padding(2)
        Me.lbFile.Name = "lbFile"
        Me.lbFile.Size = New System.Drawing.Size(243, 124)
        Me.lbFile.TabIndex = 0
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.Location = New System.Drawing.Point(167, 179)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(93, 25)
        Me.btnDeleteAll.TabIndex = 3
        Me.btnDeleteAll.Text = "全て取り消し"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        '
        'gbE00FileInfo
        '
        Me.gbE00FileInfo.Controls.Add(Me.pnlInfo)
        Me.gbE00FileInfo.Location = New System.Drawing.Point(271, 35)
        Me.gbE00FileInfo.Name = "gbE00FileInfo"
        Me.gbE00FileInfo.Size = New System.Drawing.Size(274, 147)
        Me.gbE00FileInfo.TabIndex = 4
        Me.gbE00FileInfo.TabStop = False
        Me.gbE00FileInfo.Text = "gbShapeFileInfo"
        '
        'pnlInfo
        '
        Me.pnlInfo.Controls.Add(Me.gbSystem)
        Me.pnlInfo.Controls.Add(Me.gbMode)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInfo.Location = New System.Drawing.Point(3, 15)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(268, 129)
        Me.pnlInfo.TabIndex = 0
        '
        'gbSystem
        '
        Me.gbSystem.Controls.Add(Me.rbD_Other)
        Me.gbSystem.Controls.Add(Me.rbD_World)
        Me.gbSystem.Controls.Add(Me.rbD_Tokyo)
        Me.gbSystem.Location = New System.Drawing.Point(145, 8)
        Me.gbSystem.Name = "gbSystem"
        Me.gbSystem.Size = New System.Drawing.Size(111, 110)
        Me.gbSystem.TabIndex = 1
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
        Me.gbMode.Location = New System.Drawing.Point(5, 8)
        Me.gbMode.Name = "gbMode"
        Me.gbMode.Size = New System.Drawing.Size(134, 110)
        Me.gbMode.TabIndex = 0
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
        'gbProjection
        '
        Me.gbProjection.Controls.Add(Me.cbProjection)
        Me.gbProjection.Location = New System.Drawing.Point(91, 211)
        Me.gbProjection.Name = "gbProjection"
        Me.gbProjection.Size = New System.Drawing.Size(169, 47)
        Me.gbProjection.TabIndex = 5
        Me.gbProjection.TabStop = False
        Me.gbProjection.Text = "投影法"
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
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(99, 179)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(62, 25)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "取り消し"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 12)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "読み込むe00ファイル"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(31, 179)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(62, 25)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(269, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 12)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "e00ファイル情報"
        '
        'frmMED_E00File
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(557, 268)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbFile)
        Me.Controls.Add(Me.btnDeleteAll)
        Me.Controls.Add(Me.gbE00FileInfo)
        Me.Controls.Add(Me.gbProjection)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_E00File"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export(e00)形式ファイル読み込み"
        Me.gbE00FileInfo.ResumeLayout(False)
        Me.pnlInfo.ResumeLayout(False)
        Me.gbSystem.ResumeLayout(False)
        Me.gbSystem.PerformLayout()
        Me.gbMode.ResumeLayout(False)
        Me.gbMode.PerformLayout()
        Me.gbProjection.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lbFile As System.Windows.Forms.ListBox
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents gbE00FileInfo As System.Windows.Forms.GroupBox
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
    Friend WithEvents gbProjection As System.Windows.Forms.GroupBox
    Friend WithEvents cbProjection As mandara10.ComboBoxEx
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
