<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_CopyDataItemSettings
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkContour = New System.Windows.Forms.CheckBox()
        Me.chkMarkMode = New System.Windows.Forms.CheckBox()
        Me.chkODOriginCopy = New System.Windows.Forms.CheckBox()
        Me.chkClassMode = New System.Windows.Forms.CheckBox()
        Me.cboCopyData = New mandara10.ComboBoxEx()
        Me.cboCopyLayer = New mandara10.ComboBoxEx()
        Me.lblOData = New System.Windows.Forms.Label()
        Me.lblOLay = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbDestinationData = New mandara10.ListBoxEx()
        Me.cboDestinationLayer = New mandara10.ComboBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDlay = New System.Windows.Forms.Label()
        Me.chkODMarkSizeValueCopy = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(478, 331)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(402, 331)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.cboCopyData)
        Me.GroupBox1.Controls.Add(Me.cboCopyLayer)
        Me.GroupBox1.Controls.Add(Me.lblOData)
        Me.GroupBox1.Controls.Add(Me.lblOLay)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(253, 285)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "コピー元"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkODMarkSizeValueCopy)
        Me.GroupBox3.Controls.Add(Me.chkContour)
        Me.GroupBox3.Controls.Add(Me.chkMarkMode)
        Me.GroupBox3.Controls.Add(Me.chkODOriginCopy)
        Me.GroupBox3.Controls.Add(Me.chkClassMode)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 114)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(232, 161)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "コピーする表示モード"
        '
        'chkContour
        '
        Me.chkContour.AutoSize = True
        Me.chkContour.Checked = True
        Me.chkContour.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkContour.Location = New System.Drawing.Point(12, 130)
        Me.chkContour.Name = "chkContour"
        Me.chkContour.Size = New System.Drawing.Size(88, 16)
        Me.chkContour.TabIndex = 3
        Me.chkContour.Text = "等値線モード"
        Me.chkContour.UseVisualStyleBackColor = True
        '
        'chkMarkMode
        '
        Me.chkMarkMode.AutoSize = True
        Me.chkMarkMode.Checked = True
        Me.chkMarkMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMarkMode.Location = New System.Drawing.Point(12, 79)
        Me.chkMarkMode.Name = "chkMarkMode"
        Me.chkMarkMode.Size = New System.Drawing.Size(134, 16)
        Me.chkMarkMode.TabIndex = 2
        Me.chkMarkMode.Text = "記号モード・文字モード"
        Me.chkMarkMode.UseVisualStyleBackColor = True
        '
        'chkODOriginCopy
        '
        Me.chkODOriginCopy.AutoSize = True
        Me.chkODOriginCopy.Checked = True
        Me.chkODOriginCopy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkODOriginCopy.Location = New System.Drawing.Point(31, 46)
        Me.chkODOriginCopy.Name = "chkODOriginCopy"
        Me.chkODOriginCopy.Size = New System.Drawing.Size(185, 16)
        Me.chkODOriginCopy.TabIndex = 1
        Me.chkODOriginCopy.Text = "線モードの起点オブジェクトもコピー"
        Me.chkODOriginCopy.UseVisualStyleBackColor = True
        '
        'chkClassMode
        '
        Me.chkClassMode.AutoSize = True
        Me.chkClassMode.Checked = True
        Me.chkClassMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClassMode.Location = New System.Drawing.Point(13, 24)
        Me.chkClassMode.Name = "chkClassMode"
        Me.chkClassMode.Size = New System.Drawing.Size(100, 16)
        Me.chkClassMode.TabIndex = 0
        Me.chkClassMode.Text = "階級区分モード"
        Me.chkClassMode.UseVisualStyleBackColor = True
        '
        'cboCopyData
        '
        Me.cboCopyData.AsteriskSelectEnabled = False
        Me.cboCopyData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCopyData.FormattingEnabled = True
        Me.cboCopyData.IntegralHeight = False
        Me.cboCopyData.Location = New System.Drawing.Point(73, 72)
        Me.cboCopyData.Name = "cboCopyData"
        Me.cboCopyData.Size = New System.Drawing.Size(165, 20)
        Me.cboCopyData.TabIndex = 1
        '
        'cboCopyLayer
        '
        Me.cboCopyLayer.AsteriskSelectEnabled = False
        Me.cboCopyLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCopyLayer.FormattingEnabled = True
        Me.cboCopyLayer.IntegralHeight = False
        Me.cboCopyLayer.Location = New System.Drawing.Point(72, 26)
        Me.cboCopyLayer.Name = "cboCopyLayer"
        Me.cboCopyLayer.Size = New System.Drawing.Size(165, 20)
        Me.cboCopyLayer.TabIndex = 0
        '
        'lblOData
        '
        Me.lblOData.AutoSize = True
        Me.lblOData.Location = New System.Drawing.Point(10, 75)
        Me.lblOData.Name = "lblOData"
        Me.lblOData.Size = New System.Drawing.Size(57, 12)
        Me.lblOData.TabIndex = 1
        Me.lblOData.Text = "データ項目"
        '
        'lblOLay
        '
        Me.lblOLay.AutoSize = True
        Me.lblOLay.Location = New System.Drawing.Point(10, 29)
        Me.lblOLay.Name = "lblOLay"
        Me.lblOLay.Size = New System.Drawing.Size(33, 12)
        Me.lblOLay.TabIndex = 0
        Me.lblOLay.Text = "レイヤ"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbDestinationData)
        Me.GroupBox2.Controls.Add(Me.cboDestinationLayer)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lblDlay)
        Me.GroupBox2.Location = New System.Drawing.Point(280, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(267, 285)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "コピー先"
        '
        'lbDestinationData
        '
        Me.lbDestinationData.AsteriskSelectEnabled = False
        Me.lbDestinationData.FormattingEnabled = True
        Me.lbDestinationData.ItemHeight = 12
        Me.lbDestinationData.Location = New System.Drawing.Point(76, 68)
        Me.lbDestinationData.Name = "lbDestinationData"
        Me.lbDestinationData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbDestinationData.Size = New System.Drawing.Size(179, 208)
        Me.lbDestinationData.TabIndex = 3
        '
        'cboDestinationLayer
        '
        Me.cboDestinationLayer.AsteriskSelectEnabled = False
        Me.cboDestinationLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestinationLayer.FormattingEnabled = True
        Me.cboDestinationLayer.IntegralHeight = False
        Me.cboDestinationLayer.Location = New System.Drawing.Point(72, 26)
        Me.cboDestinationLayer.Name = "cboDestinationLayer"
        Me.cboDestinationLayer.Size = New System.Drawing.Size(165, 20)
        Me.cboDestinationLayer.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "データ項目"
        '
        'lblDlay
        '
        Me.lblDlay.AutoSize = True
        Me.lblDlay.Location = New System.Drawing.Point(21, 29)
        Me.lblDlay.Name = "lblDlay"
        Me.lblDlay.Size = New System.Drawing.Size(33, 12)
        Me.lblDlay.TabIndex = 0
        Me.lblDlay.Text = "レイヤ"
        '
        'chkODMarkSizeValueCopy
        '
        Me.chkODMarkSizeValueCopy.AutoSize = True
        Me.chkODMarkSizeValueCopy.Checked = True
        Me.chkODMarkSizeValueCopy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkODMarkSizeValueCopy.Location = New System.Drawing.Point(31, 101)
        Me.chkODMarkSizeValueCopy.Name = "chkODMarkSizeValueCopy"
        Me.chkODMarkSizeValueCopy.Size = New System.Drawing.Size(197, 16)
        Me.chkODMarkSizeValueCopy.TabIndex = 4
        Me.chkODMarkSizeValueCopy.Text = "記号の大きさモードの凡例値もコピー"
        Me.chkODMarkSizeValueCopy.UseVisualStyleBackColor = True
        '
        'frmMain_CopyDataItemSettings
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(557, 367)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_CopyDataItemSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "データ項目設定コピー"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCopyLayer As mandara10.ComboBoxEx
    Friend WithEvents lblOData As System.Windows.Forms.Label
    Friend WithEvents lblOLay As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCopyData As mandara10.ComboBoxEx
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbDestinationData As mandara10.ListBoxEx
    Friend WithEvents cboDestinationLayer As mandara10.ComboBoxEx
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDlay As System.Windows.Forms.Label
    Friend WithEvents chkClassMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkMarkMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkODOriginCopy As System.Windows.Forms.CheckBox
    Friend WithEvents chkContour As System.Windows.Forms.CheckBox
    Friend WithEvents chkODMarkSizeValueCopy As System.Windows.Forms.CheckBox
End Class
