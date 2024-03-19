<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_OverLayModeSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain_OverLayModeSettings))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboOverlayDataSet = New mandara10.ComboBoxEx()
        Me.chkAlwaysOver = New System.Windows.Forms.CheckBox()
        Me.btnDeleteDataSet = New System.Windows.Forms.Button()
        Me.lblDataSetTitle = New System.Windows.Forms.Label()
        Me.txtDataSetTitle = New System.Windows.Forms.TextBox()
        Me.btnAddDataSet = New System.Windows.Forms.Button()
        Me.chkMarkModePosFixFlag = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnNote = New System.Windows.Forms.Button()
        Me.btnAddTile = New System.Windows.Forms.Button()
        Me.btnAllClear = New System.Windows.Forms.Button()
        Me.gbItemData = New System.Windows.Forms.GroupBox()
        Me.btnErase = New System.Windows.Forms.Button()
        Me.chkOverLayLegend = New System.Windows.Forms.CheckBox()
        Me.btnPositionDown = New System.Windows.Forms.Button()
        Me.btnPositionUp = New System.Windows.Forms.Button()
        Me.btnTileChange = New System.Windows.Forms.Button()
        Me.ListViewOverLay = New mandara10.ListViewEX()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbItemData.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboOverlayDataSet)
        Me.GroupBox2.Controls.Add(Me.chkAlwaysOver)
        Me.GroupBox2.Controls.Add(Me.btnDeleteDataSet)
        Me.GroupBox2.Controls.Add(Me.lblDataSetTitle)
        Me.GroupBox2.Controls.Add(Me.txtDataSetTitle)
        Me.GroupBox2.Controls.Add(Me.btnAddDataSet)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 21)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(499, 102)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "重ね合わせデータセット"
        '
        'cboOverlayDataSet
        '
        Me.cboOverlayDataSet.AsteriskSelectEnabled = False
        Me.cboOverlayDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOverlayDataSet.FormattingEnabled = True
        Me.cboOverlayDataSet.IntegralHeight = False
        Me.cboOverlayDataSet.Location = New System.Drawing.Point(11, 29)
        Me.cboOverlayDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.cboOverlayDataSet.Name = "cboOverlayDataSet"
        Me.cboOverlayDataSet.Size = New System.Drawing.Size(220, 20)
        Me.cboOverlayDataSet.TabIndex = 6
        '
        'chkAlwaysOver
        '
        Me.chkAlwaysOver.AutoSize = True
        Me.chkAlwaysOver.Location = New System.Drawing.Point(323, 70)
        Me.chkAlwaysOver.Margin = New System.Windows.Forms.Padding(2)
        Me.chkAlwaysOver.Name = "chkAlwaysOver"
        Me.chkAlwaysOver.Size = New System.Drawing.Size(157, 16)
        Me.chkAlwaysOver.TabIndex = 5
        Me.chkAlwaysOver.Text = "このデータセットを常に重ねる"
        Me.chkAlwaysOver.UseVisualStyleBackColor = True
        '
        'btnDeleteDataSet
        '
        Me.btnDeleteDataSet.Location = New System.Drawing.Point(366, 29)
        Me.btnDeleteDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteDataSet.Name = "btnDeleteDataSet"
        Me.btnDeleteDataSet.Size = New System.Drawing.Size(114, 22)
        Me.btnDeleteDataSet.TabIndex = 2
        Me.btnDeleteDataSet.Text = "データセット削除"
        Me.btnDeleteDataSet.UseVisualStyleBackColor = True
        '
        'lblDataSetTitle
        '
        Me.lblDataSetTitle.AutoSize = True
        Me.lblDataSetTitle.Location = New System.Drawing.Point(9, 69)
        Me.lblDataSetTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDataSetTitle.Name = "lblDataSetTitle"
        Me.lblDataSetTitle.Size = New System.Drawing.Size(40, 12)
        Me.lblDataSetTitle.TabIndex = 4
        Me.lblDataSetTitle.Text = "タイトル"
        '
        'txtDataSetTitle
        '
        Me.txtDataSetTitle.Location = New System.Drawing.Point(61, 67)
        Me.txtDataSetTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDataSetTitle.Name = "txtDataSetTitle"
        Me.txtDataSetTitle.Size = New System.Drawing.Size(247, 19)
        Me.txtDataSetTitle.TabIndex = 3
        '
        'btnAddDataSet
        '
        Me.btnAddDataSet.Location = New System.Drawing.Point(250, 29)
        Me.btnAddDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddDataSet.Name = "btnAddDataSet"
        Me.btnAddDataSet.Size = New System.Drawing.Size(110, 22)
        Me.btnAddDataSet.TabIndex = 1
        Me.btnAddDataSet.Text = "データセット追加"
        Me.btnAddDataSet.UseVisualStyleBackColor = True
        '
        'chkMarkModePosFixFlag
        '
        Me.chkMarkModePosFixFlag.Location = New System.Drawing.Point(346, 422)
        Me.chkMarkModePosFixFlag.Margin = New System.Windows.Forms.Padding(2)
        Me.chkMarkModePosFixFlag.Name = "chkMarkModePosFixFlag"
        Me.chkMarkModePosFixFlag.Size = New System.Drawing.Size(168, 28)
        Me.chkMarkModePosFixFlag.TabIndex = 7
        Me.chkMarkModePosFixFlag.Text = "記号モードの位置はずらさない"
        Me.chkMarkModePosFixFlag.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnNote)
        Me.GroupBox1.Controls.Add(Me.btnAddTile)
        Me.GroupBox1.Controls.Add(Me.btnAllClear)
        Me.GroupBox1.Controls.Add(Me.gbItemData)
        Me.GroupBox1.Controls.Add(Me.ListViewOverLay)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 136)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(498, 282)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "重ね合わせデータ"
        '
        'btnNote
        '
        Me.btnNote.Location = New System.Drawing.Point(266, 220)
        Me.btnNote.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNote.Name = "btnNote"
        Me.btnNote.Size = New System.Drawing.Size(103, 22)
        Me.btnNote.TabIndex = 2
        Me.btnNote.Text = "注"
        Me.btnNote.UseVisualStyleBackColor = True
        '
        'btnAddTile
        '
        Me.btnAddTile.Location = New System.Drawing.Point(266, 248)
        Me.btnAddTile.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddTile.Name = "btnAddTile"
        Me.btnAddTile.Size = New System.Drawing.Size(103, 22)
        Me.btnAddTile.TabIndex = 3
        Me.btnAddTile.Text = "画像タイル追加"
        Me.btnAddTile.UseVisualStyleBackColor = True
        '
        'btnAllClear
        '
        Me.btnAllClear.Location = New System.Drawing.Point(398, 248)
        Me.btnAllClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAllClear.Name = "btnAllClear"
        Me.btnAllClear.Size = New System.Drawing.Size(82, 22)
        Me.btnAllClear.TabIndex = 4
        Me.btnAllClear.Text = "すべて消去"
        Me.btnAllClear.UseVisualStyleBackColor = True
        '
        'gbItemData
        '
        Me.gbItemData.Controls.Add(Me.btnErase)
        Me.gbItemData.Controls.Add(Me.chkOverLayLegend)
        Me.gbItemData.Controls.Add(Me.btnPositionDown)
        Me.gbItemData.Controls.Add(Me.btnPositionUp)
        Me.gbItemData.Controls.Add(Me.btnTileChange)
        Me.gbItemData.Location = New System.Drawing.Point(15, 212)
        Me.gbItemData.Margin = New System.Windows.Forms.Padding(2)
        Me.gbItemData.Name = "gbItemData"
        Me.gbItemData.Padding = New System.Windows.Forms.Padding(2)
        Me.gbItemData.Size = New System.Drawing.Size(232, 62)
        Me.gbItemData.TabIndex = 1
        Me.gbItemData.TabStop = False
        '
        'btnErase
        '
        Me.btnErase.Location = New System.Drawing.Point(106, 38)
        Me.btnErase.Margin = New System.Windows.Forms.Padding(2)
        Me.btnErase.Name = "btnErase"
        Me.btnErase.Size = New System.Drawing.Size(70, 22)
        Me.btnErase.TabIndex = 7
        Me.btnErase.Text = "消去"
        Me.btnErase.UseVisualStyleBackColor = True
        '
        'chkOverLayLegend
        '
        Me.chkOverLayLegend.AutoSize = True
        Me.chkOverLayLegend.Location = New System.Drawing.Point(97, 17)
        Me.chkOverLayLegend.Margin = New System.Windows.Forms.Padding(2)
        Me.chkOverLayLegend.Name = "chkOverLayLegend"
        Me.chkOverLayLegend.Size = New System.Drawing.Size(100, 16)
        Me.chkOverLayLegend.TabIndex = 6
        Me.chkOverLayLegend.Text = "凡例を表示する"
        Me.chkOverLayLegend.UseVisualStyleBackColor = True
        '
        'btnPositionDown
        '
        Me.btnPositionDown.BackgroundImage = CType(resources.GetObject("btnPositionDown.BackgroundImage"), System.Drawing.Image)
        Me.btnPositionDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPositionDown.Location = New System.Drawing.Point(48, 19)
        Me.btnPositionDown.Name = "btnPositionDown"
        Me.btnPositionDown.Size = New System.Drawing.Size(35, 33)
        Me.btnPositionDown.TabIndex = 3
        Me.btnPositionDown.UseVisualStyleBackColor = True
        '
        'btnPositionUp
        '
        Me.btnPositionUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPositionUp.Image = CType(resources.GetObject("btnPositionUp.Image"), System.Drawing.Image)
        Me.btnPositionUp.Location = New System.Drawing.Point(6, 19)
        Me.btnPositionUp.Name = "btnPositionUp"
        Me.btnPositionUp.Size = New System.Drawing.Size(35, 34)
        Me.btnPositionUp.TabIndex = 2
        Me.btnPositionUp.UseVisualStyleBackColor = True
        '
        'btnTileChange
        '
        Me.btnTileChange.Location = New System.Drawing.Point(97, 12)
        Me.btnTileChange.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTileChange.Name = "btnTileChange"
        Me.btnTileChange.Size = New System.Drawing.Size(103, 22)
        Me.btnTileChange.TabIndex = 10
        Me.btnTileChange.Text = "画像タイル変更"
        Me.btnTileChange.UseVisualStyleBackColor = True
        '
        'ListViewOverLay
        '
        Me.ListViewOverLay.FullRowSelect = True
        Me.ListViewOverLay.GridLines = True
        Me.ListViewOverLay.HideSelection = False
        Me.ListViewOverLay.Location = New System.Drawing.Point(15, 19)
        Me.ListViewOverLay.Margin = New System.Windows.Forms.Padding(2)
        Me.ListViewOverLay.Name = "ListViewOverLay"
        Me.ListViewOverLay.Size = New System.Drawing.Size(465, 191)
        Me.ListViewOverLay.TabIndex = 0
        Me.ListViewOverLay.UseCompatibleStateImageBehavior = False
        Me.ListViewOverLay.View = System.Windows.Forms.View.Details
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(474, 2)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(35, 21)
        Me.btnHelp.TabIndex = 2
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmMain_OverLayModeSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(525, 451)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkMarkModePosFixFlag)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmMain_OverLayModeSettings"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "重ね合わせ表示モード"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.gbItemData.ResumeLayout(False)
        Me.gbItemData.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAlwaysOver As System.Windows.Forms.CheckBox
    Friend WithEvents btnDeleteDataSet As System.Windows.Forms.Button
    Friend WithEvents lblDataSetTitle As System.Windows.Forms.Label
    Friend WithEvents txtDataSetTitle As System.Windows.Forms.TextBox
    Friend WithEvents btnAddDataSet As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListViewOverLay As mandara10.ListViewEX
    Friend WithEvents gbItemData As System.Windows.Forms.GroupBox
    Friend WithEvents btnErase As System.Windows.Forms.Button
    Friend WithEvents chkOverLayLegend As System.Windows.Forms.CheckBox
    Friend WithEvents btnPositionDown As System.Windows.Forms.Button
    Friend WithEvents btnPositionUp As System.Windows.Forms.Button
    Friend WithEvents btnAllClear As System.Windows.Forms.Button
    Friend WithEvents cboOverlayDataSet As mandara10.ComboBoxEx
    Friend WithEvents btnAddTile As System.Windows.Forms.Button
    Friend WithEvents btnTileChange As System.Windows.Forms.Button
    Friend WithEvents btnNote As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents chkMarkModePosFixFlag As System.Windows.Forms.CheckBox
End Class
