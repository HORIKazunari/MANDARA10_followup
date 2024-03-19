<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_DefAttData
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.gbGet = New System.Windows.Forms.GroupBox()
        Me.btnGetArea = New System.Windows.Forms.Button()
        Me.btnGetCenterPoint = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnBefore = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.cboMissingValue = New System.Windows.Forms.ComboBox()
        Me.cboAttDataType = New System.Windows.Forms.ComboBox()
        Me.KtGrid = New KTGISUserControl.KTGISGrid()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbGet.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnOK)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCancel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbGet)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnHelp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboMissingValue)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboAttDataType)
        Me.SplitContainer1.Panel2.Controls.Add(Me.KtGrid)
        Me.SplitContainer1.Size = New System.Drawing.Size(802, 422)
        Me.SplitContainer1.SplitterDistance = 96
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(411, 28)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(486, 28)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'gbGet
        '
        Me.gbGet.Controls.Add(Me.btnGetArea)
        Me.gbGet.Controls.Add(Me.btnGetCenterPoint)
        Me.gbGet.Location = New System.Drawing.Point(244, 10)
        Me.gbGet.Margin = New System.Windows.Forms.Padding(2)
        Me.gbGet.Name = "gbGet"
        Me.gbGet.Padding = New System.Windows.Forms.Padding(2)
        Me.gbGet.Size = New System.Drawing.Size(146, 54)
        Me.gbGet.TabIndex = 1
        Me.gbGet.TabStop = False
        Me.gbGet.Text = "取得"
        '
        'btnGetArea
        '
        Me.btnGetArea.Location = New System.Drawing.Point(20, 18)
        Me.btnGetArea.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetArea.Name = "btnGetArea"
        Me.btnGetArea.Size = New System.Drawing.Size(52, 24)
        Me.btnGetArea.TabIndex = 0
        Me.btnGetArea.Text = "面積"
        Me.btnGetArea.UseVisualStyleBackColor = True
        '
        'btnGetCenterPoint
        '
        Me.btnGetCenterPoint.Location = New System.Drawing.Point(76, 18)
        Me.btnGetCenterPoint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetCenterPoint.Name = "btnGetCenterPoint"
        Me.btnGetCenterPoint.Size = New System.Drawing.Size(52, 24)
        Me.btnGetCenterPoint.TabIndex = 1
        Me.btnGetCenterPoint.Text = "代表点"
        Me.btnGetCenterPoint.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(764, 12)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(26, 24)
        Me.btnHelp.TabIndex = 4
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Controls.Add(Me.btnBefore)
        Me.GroupBox1.Controls.Add(Me.btnNext)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(229, 54)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "検索"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(12, 18)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(101, 19)
        Me.txtSearch.TabIndex = 0
        '
        'btnBefore
        '
        Me.btnBefore.Location = New System.Drawing.Point(118, 18)
        Me.btnBefore.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBefore.Name = "btnBefore"
        Me.btnBefore.Size = New System.Drawing.Size(46, 19)
        Me.btnBefore.TabIndex = 1
        Me.btnBefore.Text = "前"
        Me.btnBefore.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(168, 18)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(46, 19)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "次"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'cboMissingValue
        '
        Me.cboMissingValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissingValue.FormattingEnabled = True
        Me.cboMissingValue.Location = New System.Drawing.Point(302, 146)
        Me.cboMissingValue.Margin = New System.Windows.Forms.Padding(2)
        Me.cboMissingValue.Name = "cboMissingValue"
        Me.cboMissingValue.Size = New System.Drawing.Size(69, 20)
        Me.cboMissingValue.TabIndex = 16
        '
        'cboAttDataType
        '
        Me.cboAttDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttDataType.FormattingEnabled = True
        Me.cboAttDataType.Location = New System.Drawing.Point(298, 123)
        Me.cboAttDataType.Margin = New System.Windows.Forms.Padding(2)
        Me.cboAttDataType.Name = "cboAttDataType"
        Me.cboAttDataType.Size = New System.Drawing.Size(69, 20)
        Me.cboAttDataType.TabIndex = 15
        '
        'KtGrid
        '
        Me.KtGrid.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.KtGrid.DefaultFixedXNumberingWidth = 50
        Me.KtGrid.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.KtGrid.DefaultFixedXWidth = 150
        Me.KtGrid.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.KtGrid.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.KtGrid.DefaultGridWidth = 100
        Me.KtGrid.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.KtGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KtGrid.FixedGridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.KtGrid.FrameColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.KtGrid.GridColor = System.Drawing.Color.White
        Me.KtGrid.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KtGrid.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.KtGrid.Layer = 0
        Me.KtGrid.LayerCaption = Nothing
        Me.KtGrid.Location = New System.Drawing.Point(0, 0)
        Me.KtGrid.MsgBoxTitle = ""
        Me.KtGrid.Name = "KtGrid"
        Me.KtGrid.RowCaption = Nothing
        Me.KtGrid.Size = New System.Drawing.Size(802, 323)
        Me.KtGrid.TabClickEnabled = False
        Me.KtGrid.TabIndex = 0
        '
        'frmMED_DefAttData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 422)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmMED_DefAttData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "初期属性データ編集"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbGet.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents KtGrid As KTGISUserControl.KTGISGrid
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnBefore As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnGetCenterPoint As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents cboMissingValue As System.Windows.Forms.ComboBox
    Friend WithEvents cboAttDataType As System.Windows.Forms.ComboBox
    Friend WithEvents gbGet As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetArea As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
End Class
