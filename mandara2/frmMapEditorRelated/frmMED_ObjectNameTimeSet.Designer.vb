<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_ObjectNameTimeSet
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lbList = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCopyName = New System.Windows.Forms.Button()
        Me.gbObjectName12 = New System.Windows.Forms.GroupBox()
        Me.ktObjectName = New KTGISUserControl.KTGISGrid()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dbdtpEndTime = New mandara10.DbDateTimePicker()
        Me.dbdtpStartTime = New mandara10.DbDateTimePicker()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbObjectName12.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(242, 337)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(317, 337)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lbList
        '
        Me.lbList.FormattingEnabled = True
        Me.lbList.ItemHeight = 12
        Me.lbList.Location = New System.Drawing.Point(12, 24)
        Me.lbList.Name = "lbList"
        Me.lbList.Size = New System.Drawing.Size(375, 76)
        Me.lbList.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnCopyName)
        Me.GroupBox1.Controls.Add(Me.gbObjectName12)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(370, 227)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "設定"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(50, 183)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(85, 24)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "削除"
        Me.ToolTip1.SetToolTip(Me.btnDelete, "一つ上のオブジェクト名をコピーします")
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dbdtpEndTime)
        Me.GroupBox2.Controls.Add(Me.dbdtpStartTime)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(161, 138)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(199, 77)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "時期設定"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 45)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "終了"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "開始"
        '
        'btnCopyName
        '
        Me.btnCopyName.Location = New System.Drawing.Point(50, 138)
        Me.btnCopyName.Name = "btnCopyName"
        Me.btnCopyName.Size = New System.Drawing.Size(85, 24)
        Me.btnCopyName.TabIndex = 2
        Me.btnCopyName.Text = "名称コピー"
        Me.ToolTip1.SetToolTip(Me.btnCopyName, "一つ上のオブジェクト名をコピーします")
        Me.btnCopyName.UseVisualStyleBackColor = True
        '
        'gbObjectName12
        '
        Me.gbObjectName12.Controls.Add(Me.ktObjectName)
        Me.gbObjectName12.Location = New System.Drawing.Point(19, 17)
        Me.gbObjectName12.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjectName12.Name = "gbObjectName12"
        Me.gbObjectName12.Padding = New System.Windows.Forms.Padding(17, 8, 2, 2)
        Me.gbObjectName12.Size = New System.Drawing.Size(341, 116)
        Me.gbObjectName12.TabIndex = 1
        Me.gbObjectName12.TabStop = False
        Me.gbObjectName12.Text = "オブジェクト名"
        '
        'ktObjectName
        '
        Me.ktObjectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.ktObjectName.Location = New System.Drawing.Point(11, 14)
        Me.ktObjectName.MsgBoxTitle = ""
        Me.ktObjectName.Name = "ktObjectName"
        Me.ktObjectName.RowCaption = Nothing
        Me.ktObjectName.Size = New System.Drawing.Size(325, 84)
        Me.ktObjectName.TabClickEnabled = False
        Me.ktObjectName.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(17, 337)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 24)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "期間追加"
        Me.ToolTip1.SetToolTip(Me.btnAdd, "一つ上のオブジェクト名をコピーします")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "設定一覧"
        '
        'dbdtpEndTime
        '
        Me.dbdtpEndTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dbdtpEndTime.Location = New System.Drawing.Point(39, 42)
        Me.dbdtpEndTime.Name = "dbdtpEndTime"
        Me.dbdtpEndTime.ShowCheckBox = True
        Me.dbdtpEndTime.Size = New System.Drawing.Size(150, 19)
        Me.dbdtpEndTime.TabIndex = 4
        '
        'dbdtpStartTime
        '
        Me.dbdtpStartTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dbdtpStartTime.Location = New System.Drawing.Point(39, 17)
        Me.dbdtpStartTime.Name = "dbdtpStartTime"
        Me.dbdtpStartTime.ShowCheckBox = True
        Me.dbdtpStartTime.Size = New System.Drawing.Size(150, 19)
        Me.dbdtpStartTime.TabIndex = 3
        '
        'frmMED_ObjectNameTimeSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(398, 372)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbList)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_ObjectNameTimeSet"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オブジェクト名の有効期間の設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbObjectName12.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lbList As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCopyName As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gbObjectName12 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dbdtpStartTime As mandara10.DbDateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dbdtpEndTime As mandara10.DbDateTimePicker
    Friend WithEvents ktObjectName As KTGISUserControl.KTGISGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
