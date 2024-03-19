<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGridGPX
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.ktGrid = New KTGISUserControl.KTGISGrid()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkDistance = New System.Windows.Forms.CheckBox()
        Me.chkSpeed = New System.Windows.Forms.CheckBox()
        Me.chkInterval = New System.Windows.Forms.CheckBox()
        Me.chkElevation = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLayerName = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(557, 274)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(490, 274)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
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
        Me.ktGrid.Location = New System.Drawing.Point(228, 25)
        Me.ktGrid.MsgBoxTitle = ""
        Me.ktGrid.Name = "ktGrid"
        Me.ktGrid.RowCaption = Nothing
        Me.ktGrid.Size = New System.Drawing.Size(391, 234)
        Me.ktGrid.TabClickEnabled = False
        Me.ktGrid.TabIndex = 2
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(62, 25)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(110, 27)
        Me.btnFile.TabIndex = 0
        Me.btnFile.Text = "GPXファイル選択"
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDistance)
        Me.GroupBox1.Controls.Add(Me.chkSpeed)
        Me.GroupBox1.Controls.Add(Me.chkInterval)
        Me.GroupBox1.Controls.Add(Me.chkElevation)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtLayerName)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(183, 188)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'chkDistance
        '
        Me.chkDistance.AutoSize = True
        Me.chkDistance.Checked = True
        Me.chkDistance.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDistance.Location = New System.Drawing.Point(24, 144)
        Me.chkDistance.Name = "chkDistance"
        Me.chkDistance.Size = New System.Drawing.Size(96, 16)
        Me.chkDistance.TabIndex = 4
        Me.chkDistance.Text = "距離間隔取得"
        Me.chkDistance.UseVisualStyleBackColor = True
        '
        'chkSpeed
        '
        Me.chkSpeed.AutoSize = True
        Me.chkSpeed.Checked = True
        Me.chkSpeed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSpeed.Location = New System.Drawing.Point(24, 166)
        Me.chkSpeed.Name = "chkSpeed"
        Me.chkSpeed.Size = New System.Drawing.Size(72, 16)
        Me.chkSpeed.TabIndex = 5
        Me.chkSpeed.Text = "速度取得"
        Me.chkSpeed.UseVisualStyleBackColor = True
        '
        'chkInterval
        '
        Me.chkInterval.AutoSize = True
        Me.chkInterval.Checked = True
        Me.chkInterval.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInterval.Location = New System.Drawing.Point(24, 119)
        Me.chkInterval.Name = "chkInterval"
        Me.chkInterval.Size = New System.Drawing.Size(96, 16)
        Me.chkInterval.TabIndex = 3
        Me.chkInterval.Text = "時間間隔取得"
        Me.chkInterval.UseVisualStyleBackColor = True
        '
        'chkElevation
        '
        Me.chkElevation.AutoSize = True
        Me.chkElevation.Checked = True
        Me.chkElevation.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkElevation.Location = New System.Drawing.Point(24, 97)
        Me.chkElevation.Name = "chkElevation"
        Me.chkElevation.Size = New System.Drawing.Size(94, 16)
        Me.chkElevation.TabIndex = 2
        Me.chkElevation.Text = "GPS標高取得"
        Me.chkElevation.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "主体名"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(21, 72)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(136, 19)
        Me.txtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "レイヤ名"
        '
        'txtLayerName
        '
        Me.txtLayerName.Location = New System.Drawing.Point(21, 33)
        Me.txtLayerName.Name = "txtLayerName"
        Me.txtLayerName.Size = New System.Drawing.Size(136, 19)
        Me.txtLayerName.TabIndex = 0
        '
        'frmGridGPX
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(637, 309)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnFile)
        Me.Controls.Add(Me.ktGrid)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGridGPX"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "GPXファイル読み込み"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ktGrid As KTGISUserControl.KTGISGrid
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSpeed As System.Windows.Forms.CheckBox
    Friend WithEvents chkInterval As System.Windows.Forms.CheckBox
    Friend WithEvents chkElevation As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLayerName As System.Windows.Forms.TextBox
    Friend WithEvents chkDistance As System.Windows.Forms.CheckBox
End Class
