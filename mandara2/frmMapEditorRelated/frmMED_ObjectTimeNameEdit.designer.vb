<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_ObjectTimeNameEdit
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
        Me.btnObjNameListEdit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtObjNameSearch = New System.Windows.Forms.TextBox()
        Me.btnBefore = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.KtGrid = New KTGISUserControl.KTGISGrid()
        Me.btnHelp = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnHelp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnObjNameListEdit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCancel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnOK)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.KtGrid)
        Me.SplitContainer1.Size = New System.Drawing.Size(811, 528)
        Me.SplitContainer1.SplitterDistance = 96
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 0
        '
        'btnObjNameListEdit
        '
        Me.btnObjNameListEdit.Location = New System.Drawing.Point(306, 26)
        Me.btnObjNameListEdit.Name = "btnObjNameListEdit"
        Me.btnObjNameListEdit.Size = New System.Drawing.Size(141, 24)
        Me.btnObjNameListEdit.TabIndex = 1
        Me.btnObjNameListEdit.Text = "オブジェクト名リスト編集"
        Me.btnObjNameListEdit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(627, 28)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(550, 28)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtObjNameSearch)
        Me.GroupBox1.Controls.Add(Me.btnBefore)
        Me.GroupBox1.Controls.Add(Me.btnNext)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(266, 54)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "検索"
        '
        'txtObjNameSearch
        '
        Me.txtObjNameSearch.Location = New System.Drawing.Point(21, 20)
        Me.txtObjNameSearch.Name = "txtObjNameSearch"
        Me.txtObjNameSearch.Size = New System.Drawing.Size(128, 19)
        Me.txtObjNameSearch.TabIndex = 0
        '
        'btnBefore
        '
        Me.btnBefore.Location = New System.Drawing.Point(154, 16)
        Me.btnBefore.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBefore.Name = "btnBefore"
        Me.btnBefore.Size = New System.Drawing.Size(46, 24)
        Me.btnBefore.TabIndex = 1
        Me.btnBefore.Text = "前"
        Me.btnBefore.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(204, 16)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(46, 24)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "次"
        Me.btnNext.UseVisualStyleBackColor = True
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
        Me.KtGrid.Size = New System.Drawing.Size(811, 429)
        Me.KtGrid.TabClickEnabled = False
        Me.KtGrid.TabIndex = 0
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(769, 12)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(30, 21)
        Me.btnHelp.TabIndex = 9
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmMED_ObjectTimeNameEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 528)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmMED_ObjectTimeNameEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "時間オブジェクト名編集"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtObjNameSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnBefore As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents KtGrid As KTGISUserControl.KTGISGrid
    Friend WithEvents btnObjNameListEdit As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
End Class
