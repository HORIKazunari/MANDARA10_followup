<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_TimeObjectCombine
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbIncorporationObject = New System.Windows.Forms.RadioButton()
        Me.rbNewObject = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dbdtpCombineTime = New mandara10.DbDateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ktObjectName = New KTGISUserControl.KTGISGrid()
        Me.cbObjectNameChange = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbObjSuccess = New System.Windows.Forms.CheckBox()
        Me.cbObjectEnd = New System.Windows.Forms.CheckBox()
        Me.gbDest = New System.Windows.Forms.GroupBox()
        Me.lstObjects = New System.Windows.Forms.ListBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gbDest.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(411, 277)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(336, 277)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbIncorporationObject)
        Me.GroupBox1.Controls.Add(Me.rbNewObject)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(247, 59)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "結合形態"
        '
        'rbIncorporationObject
        '
        Me.rbIncorporationObject.AutoSize = True
        Me.rbIncorporationObject.Location = New System.Drawing.Point(120, 30)
        Me.rbIncorporationObject.Name = "rbIncorporationObject"
        Me.rbIncorporationObject.Size = New System.Drawing.Size(47, 16)
        Me.rbIncorporationObject.TabIndex = 1
        Me.rbIncorporationObject.Text = "編入"
        Me.rbIncorporationObject.UseVisualStyleBackColor = True
        '
        'rbNewObject
        '
        Me.rbNewObject.AutoSize = True
        Me.rbNewObject.Location = New System.Drawing.Point(31, 30)
        Me.rbNewObject.Name = "rbNewObject"
        Me.rbNewObject.Size = New System.Drawing.Size(47, 16)
        Me.rbNewObject.TabIndex = 0
        Me.rbNewObject.Text = "新設"
        Me.rbNewObject.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dbdtpCombineTime)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(247, 65)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "結合時期"
        '
        'dbdtpCombineTime
        '
        Me.dbdtpCombineTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dbdtpCombineTime.Location = New System.Drawing.Point(17, 30)
        Me.dbdtpCombineTime.Name = "dbdtpCombineTime"
        Me.dbdtpCombineTime.ShowCheckBox = True
        Me.dbdtpCombineTime.Size = New System.Drawing.Size(150, 19)
        Me.dbdtpCombineTime.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ktObjectName)
        Me.GroupBox3.Controls.Add(Me.cbObjectNameChange)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 151)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(247, 138)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "結合後のオブジェクト名"
        '
        'ktObjectName
        '
        Me.ktObjectName.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktObjectName.DefaultFixedXNumberingWidth = 50
        Me.ktObjectName.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktObjectName.DefaultFixedXWidth = 150
        Me.ktObjectName.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktObjectName.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ktObjectName.DefaultGridWidth = 100
        Me.ktObjectName.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ktObjectName.FixedGridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ktObjectName.FrameColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.ktObjectName.GridColor = System.Drawing.Color.White
        Me.ktObjectName.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktObjectName.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ktObjectName.Layer = 0
        Me.ktObjectName.LayerCaption = Nothing
        Me.ktObjectName.Location = New System.Drawing.Point(17, 47)
        Me.ktObjectName.MsgBoxTitle = ""
        Me.ktObjectName.Name = "ktObjectName"
        Me.ktObjectName.RowCaption = Nothing
        Me.ktObjectName.Size = New System.Drawing.Size(224, 85)
        Me.ktObjectName.TabClickEnabled = False
        Me.ktObjectName.TabIndex = 7
        '
        'cbObjectNameChange
        '
        Me.cbObjectNameChange.AutoSize = True
        Me.cbObjectNameChange.Location = New System.Drawing.Point(17, 25)
        Me.cbObjectNameChange.Name = "cbObjectNameChange"
        Me.cbObjectNameChange.Size = New System.Drawing.Size(77, 16)
        Me.cbObjectNameChange.TabIndex = 0
        Me.cbObjectNameChange.Text = "変更しない"
        Me.cbObjectNameChange.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cbObjSuccess)
        Me.GroupBox4.Controls.Add(Me.cbObjectEnd)
        Me.GroupBox4.Location = New System.Drawing.Point(265, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(215, 99)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "結合元オブジェクトの処理"
        '
        'cbObjSuccess
        '
        Me.cbObjSuccess.AutoSize = True
        Me.cbObjSuccess.Checked = True
        Me.cbObjSuccess.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbObjSuccess.Location = New System.Drawing.Point(21, 62)
        Me.cbObjSuccess.Name = "cbObjSuccess"
        Me.cbObjSuccess.Size = New System.Drawing.Size(171, 16)
        Me.cbObjSuccess.TabIndex = 2
        Me.cbObjSuccess.Text = "結合後オブジェクトに継承させる"
        Me.cbObjSuccess.UseVisualStyleBackColor = True
        '
        'cbObjectEnd
        '
        Me.cbObjectEnd.AutoSize = True
        Me.cbObjectEnd.Checked = True
        Me.cbObjectEnd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbObjectEnd.Location = New System.Drawing.Point(21, 30)
        Me.cbObjectEnd.Name = "cbObjectEnd"
        Me.cbObjectEnd.Size = New System.Drawing.Size(167, 16)
        Me.cbObjectEnd.TabIndex = 1
        Me.cbObjectEnd.Text = "結合時期の前日で終了させる"
        Me.cbObjectEnd.UseVisualStyleBackColor = True
        '
        'gbDest
        '
        Me.gbDest.Controls.Add(Me.lstObjects)
        Me.gbDest.Location = New System.Drawing.Point(265, 117)
        Me.gbDest.Name = "gbDest"
        Me.gbDest.Size = New System.Drawing.Size(215, 142)
        Me.gbDest.TabIndex = 4
        Me.gbDest.TabStop = False
        Me.gbDest.Text = "編入先オブジェクト"
        '
        'lstObjects
        '
        Me.lstObjects.FormattingEnabled = True
        Me.lstObjects.ItemHeight = 12
        Me.lstObjects.Location = New System.Drawing.Point(11, 18)
        Me.lstObjects.Name = "lstObjects"
        Me.lstObjects.Size = New System.Drawing.Size(193, 112)
        Me.lstObjects.TabIndex = 0
        '
        'frmMED_TimeObjectCombine
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(492, 313)
        Me.Controls.Add(Me.gbDest)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_TimeObjectCombine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "時空間モードでオブジェクト結合"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gbDest.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbIncorporationObject As System.Windows.Forms.RadioButton
    Friend WithEvents rbNewObject As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dbdtpCombineTime As mandara10.DbDateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbObjectNameChange As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbObjSuccess As System.Windows.Forms.CheckBox
    Friend WithEvents cbObjectEnd As System.Windows.Forms.CheckBox
    Friend WithEvents gbDest As System.Windows.Forms.GroupBox
    Friend WithEvents lstObjects As System.Windows.Forms.ListBox
    Friend WithEvents ktObjectName As KTGISUserControl.KTGISGrid
End Class
