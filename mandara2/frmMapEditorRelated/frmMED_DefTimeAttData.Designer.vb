<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_DefTimeAttData
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
        Me.ktgrid = New KTGISUserControl.KTGISGrid()
        Me.gbObjectKind = New System.Windows.Forms.GroupBox()
        Me.cboObjectKind = New mandara10.ComboBoxEx()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtObjNameSearch = New System.Windows.Forms.TextBox()
        Me.btnBefore = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.gbEditTime = New System.Windows.Forms.GroupBox()
        Me.dbdtpEditTime = New mandara10.DbDateTimePicker()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAddData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopyData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopySelectedData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopyAllData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuValue = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSettingValue = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteValue = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbObjectKind.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbEditTime.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ktgrid
        '
        Me.ktgrid.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktgrid.DefaultFixedXNumberingWidth = 50
        Me.ktgrid.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktgrid.DefaultFixedXWidth = 150
        Me.ktgrid.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktgrid.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ktgrid.DefaultGridWidth = 100
        Me.ktgrid.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ktgrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ktgrid.FixedGridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ktgrid.FrameColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.ktgrid.GridColor = System.Drawing.Color.White
        Me.ktgrid.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktgrid.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ktgrid.Layer = 0
        Me.ktgrid.LayerCaption = Nothing
        Me.ktgrid.Location = New System.Drawing.Point(0, 0)
        Me.ktgrid.Margin = New System.Windows.Forms.Padding(4)
        Me.ktgrid.MsgBoxTitle = ""
        Me.ktgrid.Name = "ktgrid"
        Me.ktgrid.RowCaption = Nothing
        Me.ktgrid.Size = New System.Drawing.Size(985, 524)
        Me.ktgrid.TabClickEnabled = False
        Me.ktgrid.TabIndex = 0
        '
        'gbObjectKind
        '
        Me.gbObjectKind.Controls.Add(Me.cboObjectKind)
        Me.gbObjectKind.Location = New System.Drawing.Point(13, 11)
        Me.gbObjectKind.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjectKind.Name = "gbObjectKind"
        Me.gbObjectKind.Padding = New System.Windows.Forms.Padding(11, 8, 11, 3)
        Me.gbObjectKind.Size = New System.Drawing.Size(201, 55)
        Me.gbObjectKind.TabIndex = 1
        Me.gbObjectKind.TabStop = False
        Me.gbObjectKind.Text = "オブジェクトグループ"
        '
        'cboObjectKind
        '
        Me.cboObjectKind.AsteriskSelectEnabled = False
        Me.cboObjectKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObjectKind.FormattingEnabled = True
        Me.cboObjectKind.IntegralHeight = False
        Me.cboObjectKind.Location = New System.Drawing.Point(11, 20)
        Me.cboObjectKind.Margin = New System.Windows.Forms.Padding(2)
        Me.cboObjectKind.Name = "cboObjectKind"
        Me.cboObjectKind.Size = New System.Drawing.Size(172, 20)
        Me.cboObjectKind.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(661, 28)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(736, 28)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnHelp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbEditTime)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbObjectKind)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnOK)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCancel)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ktgrid)
        Me.SplitContainer1.Size = New System.Drawing.Size(985, 618)
        Me.SplitContainer1.SplitterDistance = 90
        Me.SplitContainer1.TabIndex = 1
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(947, 11)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(26, 24)
        Me.btnHelp.TabIndex = 5
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtObjNameSearch)
        Me.GroupBox1.Controls.Add(Me.btnBefore)
        Me.GroupBox1.Controls.Add(Me.btnNext)
        Me.GroupBox1.Location = New System.Drawing.Point(394, 11)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(262, 54)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "オブジェクト名検索"
        '
        'txtObjNameSearch
        '
        Me.txtObjNameSearch.Location = New System.Drawing.Point(18, 22)
        Me.txtObjNameSearch.Name = "txtObjNameSearch"
        Me.txtObjNameSearch.Size = New System.Drawing.Size(147, 19)
        Me.txtObjNameSearch.TabIndex = 0
        '
        'btnBefore
        '
        Me.btnBefore.Location = New System.Drawing.Point(170, 19)
        Me.btnBefore.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBefore.Name = "btnBefore"
        Me.btnBefore.Size = New System.Drawing.Size(33, 24)
        Me.btnBefore.TabIndex = 1
        Me.btnBefore.Text = "前"
        Me.btnBefore.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(207, 19)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(33, 24)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "次"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'gbEditTime
        '
        Me.gbEditTime.Controls.Add(Me.dbdtpEditTime)
        Me.gbEditTime.Location = New System.Drawing.Point(228, 11)
        Me.gbEditTime.Margin = New System.Windows.Forms.Padding(2)
        Me.gbEditTime.Name = "gbEditTime"
        Me.gbEditTime.Padding = New System.Windows.Forms.Padding(2)
        Me.gbEditTime.Size = New System.Drawing.Size(162, 55)
        Me.gbEditTime.TabIndex = 2
        Me.gbEditTime.TabStop = False
        Me.gbEditTime.Text = "時期限定"
        '
        'dbdtpEditTime
        '
        Me.dbdtpEditTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dbdtpEditTime.Location = New System.Drawing.Point(16, 20)
        Me.dbdtpEditTime.Margin = New System.Windows.Forms.Padding(2)
        Me.dbdtpEditTime.Name = "dbdtpEditTime"
        Me.dbdtpEditTime.ShowCheckBox = True
        Me.dbdtpEditTime.Size = New System.Drawing.Size(130, 19)
        Me.dbdtpEditTime.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEdit, Me.mnuData, Me.mnuValue})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(985, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUndo})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(57, 20)
        Me.mnuEdit.Text = "編集(&E)"
        '
        'mnuUndo
        '
        Me.mnuUndo.Name = "mnuUndo"
        Me.mnuUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.mnuUndo.Size = New System.Drawing.Size(173, 22)
        Me.mnuUndo.Text = "元に戻す(&U)"
        '
        'mnuData
        '
        Me.mnuData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAddData, Me.mnuEditData, Me.mnuDeleteData, Me.mnuCopyData})
        Me.mnuData.Name = "mnuData"
        Me.mnuData.Size = New System.Drawing.Size(157, 20)
        Me.mnuData.Text = "初期時間属性データ項目(&D)"
        '
        'mnuAddData
        '
        Me.mnuAddData.Name = "mnuAddData"
        Me.mnuAddData.Size = New System.Drawing.Size(220, 22)
        Me.mnuAddData.Text = "追加(&A)"
        '
        'mnuEditData
        '
        Me.mnuEditData.Name = "mnuEditData"
        Me.mnuEditData.Size = New System.Drawing.Size(220, 22)
        Me.mnuEditData.Text = "修正(&M)"
        '
        'mnuDeleteData
        '
        Me.mnuDeleteData.Name = "mnuDeleteData"
        Me.mnuDeleteData.Size = New System.Drawing.Size(220, 22)
        Me.mnuDeleteData.Text = "削除(&D)"
        '
        'mnuCopyData
        '
        Me.mnuCopyData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCopySelectedData, Me.mnuCopyAllData})
        Me.mnuCopyData.Name = "mnuCopyData"
        Me.mnuCopyData.Size = New System.Drawing.Size(220, 22)
        Me.mnuCopyData.Text = "他オブジェクトグループにコピー(&C)"
        '
        'mnuCopySelectedData
        '
        Me.mnuCopySelectedData.Name = "mnuCopySelectedData"
        Me.mnuCopySelectedData.Size = New System.Drawing.Size(218, 22)
        Me.mnuCopySelectedData.Text = "選択中のデータ項目のコピー(&S)"
        '
        'mnuCopyAllData
        '
        Me.mnuCopyAllData.Name = "mnuCopyAllData"
        Me.mnuCopyAllData.Size = New System.Drawing.Size(218, 22)
        Me.mnuCopyAllData.Text = "全データ項目のコピー(&A)"
        '
        'mnuValue
        '
        Me.mnuValue.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettingValue, Me.mnuDeleteValue})
        Me.mnuValue.Name = "mnuValue"
        Me.mnuValue.Size = New System.Drawing.Size(72, 20)
        Me.mnuValue.Text = "データ値(&V)"
        '
        'mnuSettingValue
        '
        Me.mnuSettingValue.Name = "mnuSettingValue"
        Me.mnuSettingValue.Size = New System.Drawing.Size(138, 22)
        Me.mnuSettingValue.Text = "一括設定(&A)"
        '
        'mnuDeleteValue
        '
        Me.mnuDeleteValue.Name = "mnuDeleteValue"
        Me.mnuDeleteValue.Size = New System.Drawing.Size(138, 22)
        Me.mnuDeleteValue.Text = "削除(&D)"
        '
        'frmMED_DefTimeAttData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmMED_DefTimeAttData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "初期時間属性データ編集"
        Me.gbObjectKind.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbEditTime.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ktgrid As KTGISUserControl.KTGISGrid
    Friend WithEvents gbObjectKind As System.Windows.Forms.GroupBox
    Friend WithEvents cboObjectKind As mandara10.ComboBoxEx
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAddData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuValue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSettingValue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteValue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbEditTime As System.Windows.Forms.GroupBox
    Friend WithEvents dbdtpEditTime As mandara10.DbDateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtObjNameSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnBefore As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents mnuCopyData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopySelectedData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopyAllData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnHelp As System.Windows.Forms.Button
End Class
