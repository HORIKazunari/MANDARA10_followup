<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_DummyObjectGroup
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboLayer = New mandara10.ComboBoxEx()
        Me.gbDummyObject = New System.Windows.Forms.GroupBox()
        Me.btnAddFromClipboard = New System.Windows.Forms.Button()
        Me.btnObjCopyPanel = New System.Windows.Forms.Button()
        Me.btnAddDummyObject = New System.Windows.Forms.Button()
        Me.txtDummy = New System.Windows.Forms.TextBox()
        Me.btnDeleteDummyObject = New System.Windows.Forms.Button()
        Me.lstDummyObject = New mandara10.ListBoxEx()
        Me.gbDummyObjectGroup = New System.Windows.Forms.GroupBox()
        Me.chklDummyGroup = New mandara10.CheckedListBoxEx()
        Me.chkDummy_Size = New System.Windows.Forms.CheckBox()
        Me.chkDummyClip = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.gbPointOBJGMark = New System.Windows.Forms.GroupBox()
        Me.pnlPointObjGroupContainer = New System.Windows.Forms.Panel()
        Me.pnlPointObjGroup = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboMapFile = New mandara10.ComboBoxEx()
        Me.GroupBox1.SuspendLayout()
        Me.gbDummyObject.SuspendLayout()
        Me.gbDummyObjectGroup.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gbPointOBJGMark.SuspendLayout()
        Me.pnlPointObjGroupContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(547, 358)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(472, 358)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboLayer)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 17)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(178, 61)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "レイヤ"
        '
        'cboLayer
        '
        Me.cboLayer.AsteriskSelectEnabled = False
        Me.cboLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayer.FormattingEnabled = True
        Me.cboLayer.IntegralHeight = False
        Me.cboLayer.Location = New System.Drawing.Point(14, 25)
        Me.cboLayer.Margin = New System.Windows.Forms.Padding(2)
        Me.cboLayer.Name = "cboLayer"
        Me.cboLayer.Size = New System.Drawing.Size(156, 20)
        Me.cboLayer.TabIndex = 0
        '
        'gbDummyObject
        '
        Me.gbDummyObject.Controls.Add(Me.btnAddFromClipboard)
        Me.gbDummyObject.Controls.Add(Me.btnObjCopyPanel)
        Me.gbDummyObject.Controls.Add(Me.btnAddDummyObject)
        Me.gbDummyObject.Controls.Add(Me.txtDummy)
        Me.gbDummyObject.Controls.Add(Me.btnDeleteDummyObject)
        Me.gbDummyObject.Controls.Add(Me.lstDummyObject)
        Me.gbDummyObject.Location = New System.Drawing.Point(14, 93)
        Me.gbDummyObject.Margin = New System.Windows.Forms.Padding(2)
        Me.gbDummyObject.Name = "gbDummyObject"
        Me.gbDummyObject.Padding = New System.Windows.Forms.Padding(2)
        Me.gbDummyObject.Size = New System.Drawing.Size(178, 265)
        Me.gbDummyObject.TabIndex = 1
        Me.gbDummyObject.TabStop = False
        Me.gbDummyObject.Text = "ダミーオブジェクト"
        '
        'btnAddFromClipboard
        '
        Me.btnAddFromClipboard.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddFromClipboard.Location = New System.Drawing.Point(94, 212)
        Me.btnAddFromClipboard.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddFromClipboard.Name = "btnAddFromClipboard"
        Me.btnAddFromClipboard.Size = New System.Drawing.Size(75, 36)
        Me.btnAddFromClipboard.TabIndex = 5
        Me.btnAddFromClipboard.Text = "クリップボードから追加"
        Me.btnAddFromClipboard.UseVisualStyleBackColor = True
        '
        'btnObjCopyPanel
        '
        Me.btnObjCopyPanel.Location = New System.Drawing.Point(4, 212)
        Me.btnObjCopyPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjCopyPanel.Name = "btnObjCopyPanel"
        Me.btnObjCopyPanel.Size = New System.Drawing.Size(86, 36)
        Me.btnObjCopyPanel.TabIndex = 4
        Me.btnObjCopyPanel.Text = "オブジェクト名コピーパネル"
        Me.btnObjCopyPanel.UseVisualStyleBackColor = True
        '
        'btnAddDummyObject
        '
        Me.btnAddDummyObject.Location = New System.Drawing.Point(114, 181)
        Me.btnAddDummyObject.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddDummyObject.Name = "btnAddDummyObject"
        Me.btnAddDummyObject.Size = New System.Drawing.Size(55, 22)
        Me.btnAddDummyObject.TabIndex = 3
        Me.btnAddDummyObject.Text = "追加"
        Me.btnAddDummyObject.UseVisualStyleBackColor = True
        '
        'txtDummy
        '
        Me.txtDummy.Location = New System.Drawing.Point(14, 184)
        Me.txtDummy.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDummy.Name = "txtDummy"
        Me.txtDummy.Size = New System.Drawing.Size(93, 19)
        Me.txtDummy.TabIndex = 2
        '
        'btnDeleteDummyObject
        '
        Me.btnDeleteDummyObject.Location = New System.Drawing.Point(114, 151)
        Me.btnDeleteDummyObject.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteDummyObject.Name = "btnDeleteDummyObject"
        Me.btnDeleteDummyObject.Size = New System.Drawing.Size(55, 22)
        Me.btnDeleteDummyObject.TabIndex = 1
        Me.btnDeleteDummyObject.Text = "削除"
        Me.btnDeleteDummyObject.UseVisualStyleBackColor = True
        '
        'lstDummyObject
        '
        Me.lstDummyObject.AsteriskSelectEnabled = False
        Me.lstDummyObject.FormattingEnabled = True
        Me.lstDummyObject.ItemHeight = 12
        Me.lstDummyObject.Location = New System.Drawing.Point(14, 23)
        Me.lstDummyObject.Margin = New System.Windows.Forms.Padding(2)
        Me.lstDummyObject.Name = "lstDummyObject"
        Me.lstDummyObject.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstDummyObject.Size = New System.Drawing.Size(156, 124)
        Me.lstDummyObject.TabIndex = 0
        '
        'gbDummyObjectGroup
        '
        Me.gbDummyObjectGroup.Controls.Add(Me.chklDummyGroup)
        Me.gbDummyObjectGroup.Location = New System.Drawing.Point(203, 93)
        Me.gbDummyObjectGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.gbDummyObjectGroup.Name = "gbDummyObjectGroup"
        Me.gbDummyObjectGroup.Padding = New System.Windows.Forms.Padding(2)
        Me.gbDummyObjectGroup.Size = New System.Drawing.Size(178, 191)
        Me.gbDummyObjectGroup.TabIndex = 2
        Me.gbDummyObjectGroup.TabStop = False
        Me.gbDummyObjectGroup.Text = "ダミーオブジェクトグループ"
        '
        'chklDummyGroup
        '
        Me.chklDummyGroup.CheckOnClick = True
        Me.chklDummyGroup.EventStop = True
        Me.chklDummyGroup.FormattingEnabled = True
        Me.chklDummyGroup.Location = New System.Drawing.Point(17, 23)
        Me.chklDummyGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.chklDummyGroup.Name = "chklDummyGroup"
        Me.chklDummyGroup.Size = New System.Drawing.Size(151, 130)
        Me.chklDummyGroup.TabIndex = 0
        '
        'chkDummy_Size
        '
        Me.chkDummy_Size.Location = New System.Drawing.Point(207, 328)
        Me.chkDummy_Size.Margin = New System.Windows.Forms.Padding(2)
        Me.chkDummy_Size.Name = "chkDummy_Size"
        Me.chkDummy_Size.Size = New System.Drawing.Size(164, 30)
        Me.chkDummy_Size.TabIndex = 4
        Me.chkDummy_Size.Text = "ダミーオブジェクトを画面領域の計算対象に含む"
        Me.chkDummy_Size.UseVisualStyleBackColor = True
        '
        'chkDummyClip
        '
        Me.chkDummyClip.Location = New System.Drawing.Point(207, 293)
        Me.chkDummyClip.Margin = New System.Windows.Forms.Padding(2)
        Me.chkDummyClip.Name = "chkDummyClip"
        Me.chkDummyClip.Size = New System.Drawing.Size(164, 30)
        Me.chkDummyClip.TabIndex = 3
        Me.chkDummyClip.Text = "面形状ダミーオブジェクトをレイヤのクリッピング領域に設定"
        Me.chkDummyClip.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.gbDummyObject)
        Me.GroupBox4.Controls.Add(Me.chkDummyClip)
        Me.GroupBox4.Controls.Add(Me.gbDummyObjectGroup)
        Me.GroupBox4.Controls.Add(Me.chkDummy_Size)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(389, 370)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "ダミーオブジェクト・グループ"
        '
        'gbPointOBJGMark
        '
        Me.gbPointOBJGMark.Controls.Add(Me.cboMapFile)
        Me.gbPointOBJGMark.Controls.Add(Me.pnlPointObjGroupContainer)
        Me.gbPointOBJGMark.Controls.Add(Me.Label1)
        Me.gbPointOBJGMark.Location = New System.Drawing.Point(416, 12)
        Me.gbPointOBJGMark.Name = "gbPointOBJGMark"
        Me.gbPointOBJGMark.Size = New System.Drawing.Size(207, 323)
        Me.gbPointOBJGMark.TabIndex = 1
        Me.gbPointOBJGMark.TabStop = False
        Me.gbPointOBJGMark.Text = "点オブジェクトの記号設定"
        '
        'pnlPointObjGroupContainer
        '
        Me.pnlPointObjGroupContainer.AutoScroll = True
        Me.pnlPointObjGroupContainer.Controls.Add(Me.pnlPointObjGroup)
        Me.pnlPointObjGroupContainer.Location = New System.Drawing.Point(19, 74)
        Me.pnlPointObjGroupContainer.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlPointObjGroupContainer.Name = "pnlPointObjGroupContainer"
        Me.pnlPointObjGroupContainer.Size = New System.Drawing.Size(173, 239)
        Me.pnlPointObjGroupContainer.TabIndex = 27
        '
        'pnlPointObjGroup
        '
        Me.pnlPointObjGroup.BackColor = System.Drawing.Color.White
        Me.pnlPointObjGroup.Location = New System.Drawing.Point(2, 5)
        Me.pnlPointObjGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlPointObjGroup.Name = "pnlPointObjGroup"
        Me.pnlPointObjGroup.Size = New System.Drawing.Size(171, 189)
        Me.pnlPointObjGroup.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 12)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "地図ファイル"
        '
        'cboMapFile
        '
        Me.cboMapFile.AsteriskSelectEnabled = False
        Me.cboMapFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMapFile.FormattingEnabled = True
        Me.cboMapFile.IntegralHeight = False
        Me.cboMapFile.Location = New System.Drawing.Point(21, 50)
        Me.cboMapFile.Margin = New System.Windows.Forms.Padding(2)
        Me.cboMapFile.Name = "cboMapFile"
        Me.cboMapFile.Size = New System.Drawing.Size(171, 20)
        Me.cboMapFile.TabIndex = 28
        '
        'frmPrint_DummyObjectGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnOK
        Me.ClientSize = New System.Drawing.Size(638, 396)
        Me.Controls.Add(Me.gbPointOBJGMark)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_DummyObjectGroup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ダミーオブジェクト・グループ変更"
        Me.GroupBox1.ResumeLayout(False)
        Me.gbDummyObject.ResumeLayout(False)
        Me.gbDummyObject.PerformLayout()
        Me.gbDummyObjectGroup.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.gbPointOBJGMark.ResumeLayout(False)
        Me.gbPointOBJGMark.PerformLayout()
        Me.pnlPointObjGroupContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbDummyObject As System.Windows.Forms.GroupBox
    Friend WithEvents lstDummyObject As mandara10.ListBoxEx
    Friend WithEvents gbDummyObjectGroup As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddFromClipboard As System.Windows.Forms.Button
    Friend WithEvents btnObjCopyPanel As System.Windows.Forms.Button
    Friend WithEvents btnAddDummyObject As System.Windows.Forms.Button
    Friend WithEvents txtDummy As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteDummyObject As System.Windows.Forms.Button
    Friend WithEvents chklDummyGroup As mandara10.CheckedListBoxEx
    Friend WithEvents chkDummy_Size As System.Windows.Forms.CheckBox
    Friend WithEvents chkDummyClip As System.Windows.Forms.CheckBox
    Friend WithEvents cboLayer As mandara10.ComboBoxEx
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents gbPointOBJGMark As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlPointObjGroupContainer As System.Windows.Forms.Panel
    Friend WithEvents pnlPointObjGroup As System.Windows.Forms.Panel
    Friend WithEvents cboMapFile As mandara10.ComboBoxEx
End Class
