<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_Buffer
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
        Me.cboScaleUnit = New mandara10.ComboBoxEx()
        Me.rbBufModeObjectInPolygon = New System.Windows.Forms.RadioButton()
        Me.rbBufModeDistance = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBuffer = New mandara10.TextNumberBox()
        Me.rbBufModeParentObject = New System.Windows.Forms.RadioButton()
        Me.chkConditionUse = New System.Windows.Forms.CheckBox()
        Me.lblHandledLayer = New System.Windows.Forms.Label()
        Me.cboHandledLayer = New mandara10.ComboBoxEx()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pnlCountMethod = New System.Windows.Forms.Panel()
        Me.cboRegistMethod = New mandara10.ComboBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkClipBoardOut = New System.Windows.Forms.CheckBox()
        Me.lblObjectData = New System.Windows.Forms.Label()
        Me.lbRegistData = New mandara10.ListBoxEx()
        Me.chkObjNameOut = New System.Windows.Forms.CheckBox()
        Me.chkObjectData = New System.Windows.Forms.CheckBox()
        Me.chkObjectCount = New System.Windows.Forms.CheckBox()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlCountMethod.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(436, 373)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(369, 373)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.chkConditionUse)
        Me.GroupBox1.Controls.Add(Me.lblHandledLayer)
        Me.GroupBox1.Controls.Add(Me.cboHandledLayer)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(232, 318)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "対象レイヤと方法"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboScaleUnit)
        Me.GroupBox3.Controls.Add(Me.rbBufModeObjectInPolygon)
        Me.GroupBox3.Controls.Add(Me.rbBufModeDistance)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtBuffer)
        Me.GroupBox3.Controls.Add(Me.rbBufModeParentObject)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 69)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(220, 182)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "方法"
        '
        'cboScaleUnit
        '
        Me.cboScaleUnit.AsteriskSelectEnabled = False
        Me.cboScaleUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScaleUnit.FormattingEnabled = True
        Me.cboScaleUnit.IntegralHeight = False
        Me.cboScaleUnit.Location = New System.Drawing.Point(141, 105)
        Me.cboScaleUnit.Margin = New System.Windows.Forms.Padding(2)
        Me.cboScaleUnit.MaxDropDownItems = 15
        Me.cboScaleUnit.Name = "cboScaleUnit"
        Me.cboScaleUnit.Size = New System.Drawing.Size(72, 20)
        Me.cboScaleUnit.TabIndex = 11
        '
        'rbBufModeObjectInPolygon
        '
        Me.rbBufModeObjectInPolygon.AutoSize = True
        Me.rbBufModeObjectInPolygon.Location = New System.Drawing.Point(21, 18)
        Me.rbBufModeObjectInPolygon.Name = "rbBufModeObjectInPolygon"
        Me.rbBufModeObjectInPolygon.Size = New System.Drawing.Size(196, 16)
        Me.rbBufModeObjectInPolygon.TabIndex = 1
        Me.rbBufModeObjectInPolygon.TabStop = True
        Me.rbBufModeObjectInPolygon.Text = "面領域内部のオブジェクトを検索する"
        Me.rbBufModeObjectInPolygon.UseVisualStyleBackColor = True
        '
        'rbBufModeDistance
        '
        Me.rbBufModeDistance.Location = New System.Drawing.Point(21, 59)
        Me.rbBufModeDistance.Name = "rbBufModeDistance"
        Me.rbBufModeDistance.Size = New System.Drawing.Size(179, 28)
        Me.rbBufModeDistance.TabIndex = 2
        Me.rbBufModeDistance.TabStop = True
        Me.rbBufModeDistance.Text = "バッファ距離を設定して内部のオブジェクトを検索する"
        Me.rbBufModeDistance.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 12)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "バッファ距離"
        '
        'txtBuffer
        '
        Me.txtBuffer.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBuffer.Location = New System.Drawing.Point(59, 105)
        Me.txtBuffer.MaxValue = 0.0R
        Me.txtBuffer.MaxValueFlag = False
        Me.txtBuffer.MinValue = 0.0R
        Me.txtBuffer.MinValueFlag = False
        Me.txtBuffer.Name = "txtBuffer"
        Me.txtBuffer.NumberPoint = True
        Me.txtBuffer.Size = New System.Drawing.Size(77, 19)
        Me.txtBuffer.TabIndex = 4
        Me.txtBuffer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBuffer.ValueErrorMessageFlag = True
        '
        'rbBufModeParentObject
        '
        Me.rbBufModeParentObject.Location = New System.Drawing.Point(21, 139)
        Me.rbBufModeParentObject.Name = "rbBufModeParentObject"
        Me.rbBufModeParentObject.Size = New System.Drawing.Size(164, 36)
        Me.rbBufModeParentObject.TabIndex = 3
        Me.rbBufModeParentObject.TabStop = True
        Me.rbBufModeParentObject.Text = "元レイヤのオブジェクトを含むオブジェクトを検索する"
        Me.rbBufModeParentObject.UseVisualStyleBackColor = True
        '
        'chkConditionUse
        '
        Me.chkConditionUse.Checked = True
        Me.chkConditionUse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkConditionUse.Location = New System.Drawing.Point(20, 265)
        Me.chkConditionUse.Name = "chkConditionUse"
        Me.chkConditionUse.Size = New System.Drawing.Size(182, 34)
        Me.chkConditionUse.TabIndex = 2
        Me.chkConditionUse.Text = "表示オブジェクト限定・属性検索の条件設定を使用する"
        Me.chkConditionUse.UseVisualStyleBackColor = True
        '
        'lblHandledLayer
        '
        Me.lblHandledLayer.AutoSize = True
        Me.lblHandledLayer.Location = New System.Drawing.Point(18, 28)
        Me.lblHandledLayer.Name = "lblHandledLayer"
        Me.lblHandledLayer.Size = New System.Drawing.Size(81, 12)
        Me.lblHandledLayer.TabIndex = 8
        Me.lblHandledLayer.Text = "検索対象レイヤ"
        '
        'cboHandledLayer
        '
        Me.cboHandledLayer.AsteriskSelectEnabled = False
        Me.cboHandledLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHandledLayer.FormattingEnabled = True
        Me.cboHandledLayer.IntegralHeight = False
        Me.cboHandledLayer.Location = New System.Drawing.Point(20, 43)
        Me.cboHandledLayer.Name = "cboHandledLayer"
        Me.cboHandledLayer.Size = New System.Drawing.Size(167, 20)
        Me.cboHandledLayer.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pnlCountMethod)
        Me.GroupBox2.Controls.Add(Me.chkClipBoardOut)
        Me.GroupBox2.Controls.Add(Me.lblObjectData)
        Me.GroupBox2.Controls.Add(Me.lbRegistData)
        Me.GroupBox2.Controls.Add(Me.chkObjNameOut)
        Me.GroupBox2.Controls.Add(Me.chkObjectData)
        Me.GroupBox2.Controls.Add(Me.chkObjectCount)
        Me.GroupBox2.Location = New System.Drawing.Point(259, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(246, 343)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "出力項目"
        '
        'pnlCountMethod
        '
        Me.pnlCountMethod.Controls.Add(Me.cboRegistMethod)
        Me.pnlCountMethod.Controls.Add(Me.Label1)
        Me.pnlCountMethod.Location = New System.Drawing.Point(25, 245)
        Me.pnlCountMethod.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCountMethod.Name = "pnlCountMethod"
        Me.pnlCountMethod.Size = New System.Drawing.Size(221, 62)
        Me.pnlCountMethod.TabIndex = 9
        '
        'cboRegistMethod
        '
        Me.cboRegistMethod.AsteriskSelectEnabled = False
        Me.cboRegistMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegistMethod.FormattingEnabled = True
        Me.cboRegistMethod.IntegralHeight = False
        Me.cboRegistMethod.Location = New System.Drawing.Point(32, 1)
        Me.cboRegistMethod.Name = "cboRegistMethod"
        Me.cboRegistMethod.Size = New System.Drawing.Size(129, 20)
        Me.cboRegistMethod.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(30, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 27)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "カテゴリーデータの場合はカテゴリーごとに数がカウントされます"
        '
        'chkClipBoardOut
        '
        Me.chkClipBoardOut.AutoSize = True
        Me.chkClipBoardOut.Enabled = False
        Me.chkClipBoardOut.Location = New System.Drawing.Point(23, 312)
        Me.chkClipBoardOut.Name = "chkClipBoardOut"
        Me.chkClipBoardOut.Size = New System.Drawing.Size(222, 16)
        Me.chkClipBoardOut.TabIndex = 8
        Me.chkClipBoardOut.Text = "含まれるオブジェクト名のクリップボード出力"
        Me.chkClipBoardOut.UseVisualStyleBackColor = True
        '
        'lblObjectData
        '
        Me.lblObjectData.AutoSize = True
        Me.lblObjectData.Location = New System.Drawing.Point(42, 109)
        Me.lblObjectData.Name = "lblObjectData"
        Me.lblObjectData.Size = New System.Drawing.Size(81, 12)
        Me.lblObjectData.TabIndex = 7
        Me.lblObjectData.Text = "集計データ項目"
        '
        'lbRegistData
        '
        Me.lbRegistData.AsteriskSelectEnabled = False
        Me.lbRegistData.FormattingEnabled = True
        Me.lbRegistData.ItemHeight = 12
        Me.lbRegistData.Location = New System.Drawing.Point(45, 128)
        Me.lbRegistData.Name = "lbRegistData"
        Me.lbRegistData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbRegistData.Size = New System.Drawing.Size(187, 112)
        Me.lbRegistData.TabIndex = 3
        '
        'chkObjNameOut
        '
        Me.chkObjNameOut.AutoSize = True
        Me.chkObjNameOut.Enabled = False
        Me.chkObjNameOut.Location = New System.Drawing.Point(23, 56)
        Me.chkObjNameOut.Name = "chkObjNameOut"
        Me.chkObjNameOut.Size = New System.Drawing.Size(128, 16)
        Me.chkObjNameOut.TabIndex = 2
        Me.chkObjNameOut.Text = "含まれるオブジェクト名"
        Me.chkObjNameOut.UseVisualStyleBackColor = True
        '
        'chkObjectData
        '
        Me.chkObjectData.Location = New System.Drawing.Point(23, 78)
        Me.chkObjectData.Name = "chkObjectData"
        Me.chkObjectData.Size = New System.Drawing.Size(217, 32)
        Me.chkObjectData.TabIndex = 1
        Me.chkObjectData.Text = "含まれるオブジェクトの属性データ集計"
        Me.chkObjectData.UseVisualStyleBackColor = True
        '
        'chkObjectCount
        '
        Me.chkObjectCount.AutoSize = True
        Me.chkObjectCount.Enabled = False
        Me.chkObjectCount.Location = New System.Drawing.Point(23, 30)
        Me.chkObjectCount.Name = "chkObjectCount"
        Me.chkObjectCount.Size = New System.Drawing.Size(173, 16)
        Me.chkObjectCount.TabIndex = 0
        Me.chkObjectCount.Text = "含まれるオブジェクト数のカウント"
        Me.chkObjectCount.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(26, 373)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(215, 23)
        Me.ProgressBar.TabIndex = 25
        '
        'frmMain_Buffer
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(520, 407)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_Buffer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "空間検索"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlCountMethod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboHandledLayer As mandara10.ComboBoxEx
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblHandledLayer As System.Windows.Forms.Label
    Friend WithEvents rbBufModeParentObject As System.Windows.Forms.RadioButton
    Friend WithEvents txtBuffer As mandara10.TextNumberBox
    Friend WithEvents rbBufModeDistance As System.Windows.Forms.RadioButton
    Friend WithEvents rbBufModeObjectInPolygon As System.Windows.Forms.RadioButton
    Friend WithEvents lblObjectData As System.Windows.Forms.Label
    Friend WithEvents lbRegistData As mandara10.ListBoxEx
    Friend WithEvents chkObjNameOut As System.Windows.Forms.CheckBox
    Friend WithEvents chkObjectData As System.Windows.Forms.CheckBox
    Friend WithEvents chkObjectCount As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents chkConditionUse As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboScaleUnit As mandara10.ComboBoxEx
    Friend WithEvents chkClipBoardOut As System.Windows.Forms.CheckBox
    Friend WithEvents pnlCountMethod As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboRegistMethod As mandara10.ComboBoxEx
End Class
