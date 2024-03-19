<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_GetLine
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbLonLat = New System.Windows.Forms.RadioButton()
        Me.rbLatLon = New System.Windows.Forms.RadioButton()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbExistingLineKind = New System.Windows.Forms.RadioButton()
        Me.txtNewLineKindName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbNewLineKind = New System.Windows.Forms.RadioButton()
        Me.ktGrid = New KTGISUserControl.KTGISGrid()
        Me.cboLineKind = New mandara10.ComboBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btmCheck
        '
        Me.btmCheck.Location = New System.Drawing.Point(165, 226)
        Me.btmCheck.Margin = New System.Windows.Forms.Padding(2)
        Me.btmCheck.Name = "btmCheck"
        Me.btmCheck.Size = New System.Drawing.Size(47, 24)
        Me.btmCheck.TabIndex = 3
        Me.btmCheck.Text = "チェック"
        Me.btmCheck.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(318, 259)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(385, 259)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 24)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbLonLat)
        Me.GroupBox1.Controls.Add(Me.rbLatLon)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 141)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(220, 62)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "並び順"
        '
        'rbLonLat
        '
        Me.rbLonLat.AutoSize = True
        Me.rbLonLat.Location = New System.Drawing.Point(124, 25)
        Me.rbLonLat.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLonLat.Name = "rbLonLat"
        Me.rbLonLat.Size = New System.Drawing.Size(83, 16)
        Me.rbLonLat.TabIndex = 1
        Me.rbLonLat.TabStop = True
        Me.rbLonLat.Text = "経度－緯度"
        Me.rbLonLat.UseVisualStyleBackColor = True
        '
        'rbLatLon
        '
        Me.rbLatLon.AutoSize = True
        Me.rbLatLon.Checked = True
        Me.rbLatLon.Location = New System.Drawing.Point(24, 25)
        Me.rbLatLon.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLatLon.Name = "rbLatLon"
        Me.rbLatLon.Size = New System.Drawing.Size(83, 16)
        Me.rbLatLon.TabIndex = 0
        Me.rbLatLon.TabStop = True
        Me.rbLatLon.Text = "緯度－経度"
        Me.rbLatLon.UseVisualStyleBackColor = True
        '
        'btnGetData
        '
        Me.btnGetData.Location = New System.Drawing.Point(35, 225)
        Me.btnGetData.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(117, 24)
        Me.btnGetData.TabIndex = 2
        Me.btnGetData.Text = "クリップボードから取得"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboLineKind)
        Me.GroupBox2.Controls.Add(Me.rbExistingLineKind)
        Me.GroupBox2.Controls.Add(Me.txtNewLineKindName)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.rbNewLineKind)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 13)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(218, 115)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "線種"
        '
        'rbExistingLineKind
        '
        Me.rbExistingLineKind.AutoSize = True
        Me.rbExistingLineKind.Location = New System.Drawing.Point(16, 64)
        Me.rbExistingLineKind.Margin = New System.Windows.Forms.Padding(2)
        Me.rbExistingLineKind.Name = "rbExistingLineKind"
        Me.rbExistingLineKind.Size = New System.Drawing.Size(71, 16)
        Me.rbExistingLineKind.TabIndex = 3
        Me.rbExistingLineKind.Text = "既存線種"
        Me.rbExistingLineKind.UseVisualStyleBackColor = True
        '
        'txtNewLineKindName
        '
        Me.txtNewLineKindName.Location = New System.Drawing.Point(71, 42)
        Me.txtNewLineKindName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNewLineKindName.Name = "txtNewLineKindName"
        Me.txtNewLineKindName.Size = New System.Drawing.Size(134, 19)
        Me.txtNewLineKindName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 44)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "名称"
        '
        'rbNewLineKind
        '
        Me.rbNewLineKind.AutoSize = True
        Me.rbNewLineKind.Checked = True
        Me.rbNewLineKind.Location = New System.Drawing.Point(16, 22)
        Me.rbNewLineKind.Margin = New System.Windows.Forms.Padding(2)
        Me.rbNewLineKind.Name = "rbNewLineKind"
        Me.rbNewLineKind.Size = New System.Drawing.Size(71, 16)
        Me.rbNewLineKind.TabIndex = 0
        Me.rbNewLineKind.TabStop = True
        Me.rbNewLineKind.Text = "新規線種"
        Me.rbNewLineKind.UseVisualStyleBackColor = True
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
        Me.ktGrid.Location = New System.Drawing.Point(244, 28)
        Me.ktGrid.MsgBoxTitle = ""
        Me.ktGrid.Name = "ktGrid"
        Me.ktGrid.RowCaption = Nothing
        Me.ktGrid.Size = New System.Drawing.Size(209, 222)
        Me.ktGrid.TabClickEnabled = False
        Me.ktGrid.TabIndex = 4
        '
        'cboLineKind
        '
        Me.cboLineKind.AsteriskSelectEnabled = False
        Me.cboLineKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLineKind.FormattingEnabled = True
        Me.cboLineKind.IntegralHeight = False
        Me.cboLineKind.Location = New System.Drawing.Point(35, 83)
        Me.cboLineKind.Margin = New System.Windows.Forms.Padding(2)
        Me.cboLineKind.Name = "cboLineKind"
        Me.cboLineKind.Size = New System.Drawing.Size(173, 20)
        Me.cboLineKind.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(242, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "座標"
        '
        'frmMED_GetLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 290)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ktGrid)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btmCheck)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnGetData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_GetLine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ライン取り込み"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btmCheck As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbLonLat As System.Windows.Forms.RadioButton
    Friend WithEvents rbLatLon As System.Windows.Forms.RadioButton
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLineKind As mandara10.ComboBoxEx
    Friend WithEvents rbExistingLineKind As System.Windows.Forms.RadioButton
    Friend WithEvents txtNewLineKindName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbNewLineKind As System.Windows.Forms.RadioButton
    Friend WithEvents ktGrid As KTGISUserControl.KTGISGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
