<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_AggrObjClipSet
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
        Me.btmCheck = New System.Windows.Forms.Button()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.ktGrid = New KTGISUserControl.KTGISGrid()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.gbObjectKind = New System.Windows.Forms.GroupBox()
        Me.cboObjectKind = New mandara10.ComboBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbObjectKind.SuspendLayout()
        Me.SuspendLayout()
        '
        'btmCheck
        '
        Me.btmCheck.Location = New System.Drawing.Point(30, 327)
        Me.btmCheck.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btmCheck.Name = "btmCheck"
        Me.btmCheck.Size = New System.Drawing.Size(47, 23)
        Me.btmCheck.TabIndex = 31
        Me.btmCheck.Text = "チェック"
        Me.btmCheck.UseVisualStyleBackColor = True
        '
        'btnGetData
        '
        Me.btnGetData.Location = New System.Drawing.Point(210, 28)
        Me.btnGetData.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(117, 24)
        Me.btnGetData.TabIndex = 30
        Me.btnGetData.Text = "クリップボードから取得"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'ktGrid
        '
        Me.ktGrid.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultFixedXNumberingWidth = 50
        Me.ktGrid.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultFixedXWidth = 150
        Me.ktGrid.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ktGrid.DefaultGridWidth = 100
        Me.ktGrid.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ktGrid.FixedGridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ktGrid.FrameColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.ktGrid.GridColor = System.Drawing.Color.White
        Me.ktGrid.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktGrid.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ktGrid.Layer = 0
        Me.ktGrid.LayerCaption = Nothing
        Me.ktGrid.Location = New System.Drawing.Point(12, 86)
        Me.ktGrid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ktGrid.MsgBoxTitle = ""
        Me.ktGrid.Name = "ktGrid"
        Me.ktGrid.RowCaption = Nothing
        Me.ktGrid.Size = New System.Drawing.Size(315, 227)
        Me.ktGrid.TabClickEnabled = False
        Me.ktGrid.TabIndex = 34
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(188, 329)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 32
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(259, 327)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 26)
        Me.btnCancel.TabIndex = 33
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'gbObjectKind
        '
        Me.gbObjectKind.Controls.Add(Me.cboObjectKind)
        Me.gbObjectKind.Location = New System.Drawing.Point(12, 11)
        Me.gbObjectKind.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbObjectKind.Name = "gbObjectKind"
        Me.gbObjectKind.Padding = New System.Windows.Forms.Padding(11, 8, 11, 3)
        Me.gbObjectKind.Size = New System.Drawing.Size(194, 48)
        Me.gbObjectKind.TabIndex = 35
        Me.gbObjectKind.TabStop = False
        Me.gbObjectKind.Text = "設定集成オブジェクトグループ"
        '
        'cboObjectKind
        '
        Me.cboObjectKind.AsteriskSelectEnabled = False
        Me.cboObjectKind.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboObjectKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObjectKind.FormattingEnabled = True
        Me.cboObjectKind.IntegralHeight = False
        Me.cboObjectKind.Location = New System.Drawing.Point(11, 20)
        Me.cboObjectKind.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cboObjectKind.Name = "cboObjectKind"
        Me.cboObjectKind.Size = New System.Drawing.Size(172, 20)
        Me.cboObjectKind.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 12)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "集成オブジェクト対応"
        '
        'frmMED_AggrObjClipSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(339, 364)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbObjectKind)
        Me.Controls.Add(Me.btmCheck)
        Me.Controls.Add(Me.btnGetData)
        Me.Controls.Add(Me.ktGrid)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_AggrObjClipSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "集成オブジェクトにまとめて設定"
        Me.gbObjectKind.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btmCheck As System.Windows.Forms.Button
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents ktGrid As KTGISUserControl.KTGISGrid
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbObjectKind As System.Windows.Forms.GroupBox
    Friend WithEvents cboObjectKind As mandara10.ComboBoxEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
