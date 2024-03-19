<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_CenterPointSet
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbLonLat = New System.Windows.Forms.RadioButton()
        Me.rbLatLon = New System.Windows.Forms.RadioButton()
        Me.dbdtpTime = New mandara10.DbDateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btmCheck
        '
        Me.btmCheck.Location = New System.Drawing.Point(28, 403)
        Me.btmCheck.Margin = New System.Windows.Forms.Padding(2)
        Me.btmCheck.Name = "btmCheck"
        Me.btmCheck.Size = New System.Drawing.Size(47, 23)
        Me.btmCheck.TabIndex = 4
        Me.btmCheck.Text = "チェック"
        Me.btmCheck.UseVisualStyleBackColor = True
        '
        'btnGetData
        '
        Me.btnGetData.Location = New System.Drawing.Point(250, 63)
        Me.btnGetData.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(129, 24)
        Me.btnGetData.TabIndex = 2
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
        Me.ktGrid.Location = New System.Drawing.Point(10, 112)
        Me.ktGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.ktGrid.MsgBoxTitle = ""
        Me.ktGrid.Name = "ktGrid"
        Me.ktGrid.RowCaption = Nothing
        Me.ktGrid.Size = New System.Drawing.Size(404, 285)
        Me.ktGrid.TabClickEnabled = False
        Me.ktGrid.TabIndex = 3
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(275, 405)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(346, 403)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 26)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbLonLat)
        Me.GroupBox1.Controls.Add(Me.rbLatLon)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(212, 78)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "並び順"
        '
        'rbLonLat
        '
        Me.rbLonLat.AutoSize = True
        Me.rbLonLat.Location = New System.Drawing.Point(18, 45)
        Me.rbLonLat.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLonLat.Name = "rbLonLat"
        Me.rbLonLat.Size = New System.Drawing.Size(158, 16)
        Me.rbLonLat.TabIndex = 1
        Me.rbLonLat.TabStop = True
        Me.rbLonLat.Text = "オブジェクト名－経度－緯度"
        Me.rbLonLat.UseVisualStyleBackColor = True
        '
        'rbLatLon
        '
        Me.rbLatLon.AutoSize = True
        Me.rbLatLon.Checked = True
        Me.rbLatLon.Location = New System.Drawing.Point(18, 25)
        Me.rbLatLon.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLatLon.Name = "rbLatLon"
        Me.rbLatLon.Size = New System.Drawing.Size(158, 16)
        Me.rbLatLon.TabIndex = 0
        Me.rbLatLon.TabStop = True
        Me.rbLatLon.Text = "オブジェクト名－緯度－経度"
        Me.rbLatLon.UseVisualStyleBackColor = True
        '
        'dbdtpTime
        '
        Me.dbdtpTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dbdtpTime.Location = New System.Drawing.Point(250, 34)
        Me.dbdtpTime.Margin = New System.Windows.Forms.Padding(2)
        Me.dbdtpTime.Name = "dbdtpTime"
        Me.dbdtpTime.ShowCheckBox = True
        Me.dbdtpTime.Size = New System.Drawing.Size(130, 19)
        Me.dbdtpTime.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "オブジェクト名と座標"
        '
        'frmMED_CenterPointSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(432, 444)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dbdtpTime)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btmCheck)
        Me.Controls.Add(Me.btnGetData)
        Me.Controls.Add(Me.ktGrid)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_CenterPointSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "代表点一括設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btmCheck As System.Windows.Forms.Button
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents ktGrid As KTGISUserControl.KTGISGrid
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbLonLat As System.Windows.Forms.RadioButton
    Friend WithEvents rbLatLon As System.Windows.Forms.RadioButton
    Friend WithEvents dbdtpTime As mandara10.DbDateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
