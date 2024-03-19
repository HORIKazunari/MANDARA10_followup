<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGridAddDefData
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
        Me.rbAddPresentLayer = New System.Windows.Forms.RadioButton()
        Me.rbAddNewLayer = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbPresentLayer = New System.Windows.Forms.Label()
        Me.gbAddPresentLayer = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPLayObjectGroup = New mandara10.ComboBoxEx()
        Me.lbPlayDefData = New mandara10.ListBoxEx()
        Me.gbAddNewLayer = New System.Windows.Forms.GroupBox()
        Me.pnlTime = New System.Windows.Forms.Panel()
        Me.DateTimePickerNewLayer = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNewLayerName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboNewLayerMapFile = New mandara10.ComboBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboNewLayObjGroup = New mandara10.ComboBoxEx()
        Me.lbNewLayerDefData = New mandara10.ListBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbAddPresentLayer.SuspendLayout()
        Me.gbAddNewLayer.SuspendLayout()
        Me.pnlTime.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(479, 357)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(408, 357)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'rbAddPresentLayer
        '
        Me.rbAddPresentLayer.AutoSize = True
        Me.rbAddPresentLayer.Location = New System.Drawing.Point(283, 12)
        Me.rbAddPresentLayer.Name = "rbAddPresentLayer"
        Me.rbAddPresentLayer.Size = New System.Drawing.Size(179, 16)
        Me.rbAddPresentLayer.TabIndex = 1
        Me.rbAddPresentLayer.TabStop = True
        Me.rbAddPresentLayer.Text = "現在のレイヤのオブジェクトに追加"
        Me.rbAddPresentLayer.UseVisualStyleBackColor = True
        '
        'rbAddNewLayer
        '
        Me.rbAddNewLayer.AutoSize = True
        Me.rbAddNewLayer.Location = New System.Drawing.Point(12, 12)
        Me.rbAddNewLayer.Name = "rbAddNewLayer"
        Me.rbAddNewLayer.Size = New System.Drawing.Size(238, 16)
        Me.rbAddNewLayer.TabIndex = 0
        Me.rbAddNewLayer.TabStop = True
        Me.rbAddNewLayer.Text = "新しいレイヤにオブジェクトグループ単位で追加"
        Me.rbAddNewLayer.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 12)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "レイヤ："
        '
        'lbPresentLayer
        '
        Me.lbPresentLayer.AutoSize = True
        Me.lbPresentLayer.Location = New System.Drawing.Point(58, 15)
        Me.lbPresentLayer.Name = "lbPresentLayer"
        Me.lbPresentLayer.Size = New System.Drawing.Size(45, 12)
        Me.lbPresentLayer.TabIndex = 26
        Me.lbPresentLayer.Text = "レイヤ名"
        '
        'gbAddPresentLayer
        '
        Me.gbAddPresentLayer.Controls.Add(Me.Label7)
        Me.gbAddPresentLayer.Controls.Add(Me.Label2)
        Me.gbAddPresentLayer.Controls.Add(Me.cboPLayObjectGroup)
        Me.gbAddPresentLayer.Controls.Add(Me.lbPlayDefData)
        Me.gbAddPresentLayer.Controls.Add(Me.lbPresentLayer)
        Me.gbAddPresentLayer.Controls.Add(Me.Label1)
        Me.gbAddPresentLayer.Location = New System.Drawing.Point(309, 34)
        Me.gbAddPresentLayer.Name = "gbAddPresentLayer"
        Me.gbAddPresentLayer.Size = New System.Drawing.Size(233, 246)
        Me.gbAddPresentLayer.TabIndex = 3
        Me.gbAddPresentLayer.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 12)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "オブジェクトグループ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 12)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "初期属性データ項目"
        '
        'cboPLayObjectGroup
        '
        Me.cboPLayObjectGroup.AsteriskSelectEnabled = True
        Me.cboPLayObjectGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLayObjectGroup.FormattingEnabled = True
        Me.cboPLayObjectGroup.IntegralHeight = False
        Me.cboPLayObjectGroup.Location = New System.Drawing.Point(20, 68)
        Me.cboPLayObjectGroup.Name = "cboPLayObjectGroup"
        Me.cboPLayObjectGroup.Size = New System.Drawing.Size(192, 20)
        Me.cboPLayObjectGroup.TabIndex = 0
        '
        'lbPlayDefData
        '
        Me.lbPlayDefData.AsteriskSelectEnabled = False
        Me.lbPlayDefData.FormattingEnabled = True
        Me.lbPlayDefData.ItemHeight = 12
        Me.lbPlayDefData.Location = New System.Drawing.Point(20, 118)
        Me.lbPlayDefData.Name = "lbPlayDefData"
        Me.lbPlayDefData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbPlayDefData.Size = New System.Drawing.Size(192, 112)
        Me.lbPlayDefData.TabIndex = 1
        '
        'gbAddNewLayer
        '
        Me.gbAddNewLayer.Controls.Add(Me.pnlTime)
        Me.gbAddNewLayer.Controls.Add(Me.Label5)
        Me.gbAddNewLayer.Controls.Add(Me.txtNewLayerName)
        Me.gbAddNewLayer.Controls.Add(Me.Label6)
        Me.gbAddNewLayer.Controls.Add(Me.cboNewLayerMapFile)
        Me.gbAddNewLayer.Controls.Add(Me.Label3)
        Me.gbAddNewLayer.Controls.Add(Me.cboNewLayObjGroup)
        Me.gbAddNewLayer.Controls.Add(Me.lbNewLayerDefData)
        Me.gbAddNewLayer.Controls.Add(Me.Label4)
        Me.gbAddNewLayer.Location = New System.Drawing.Point(17, 34)
        Me.gbAddNewLayer.Name = "gbAddNewLayer"
        Me.gbAddNewLayer.Size = New System.Drawing.Size(233, 348)
        Me.gbAddNewLayer.TabIndex = 2
        Me.gbAddNewLayer.TabStop = False
        '
        'pnlTime
        '
        Me.pnlTime.Controls.Add(Me.DateTimePickerNewLayer)
        Me.pnlTime.Controls.Add(Me.Label8)
        Me.pnlTime.Location = New System.Drawing.Point(18, 160)
        Me.pnlTime.Name = "pnlTime"
        Me.pnlTime.Size = New System.Drawing.Size(209, 31)
        Me.pnlTime.TabIndex = 37
        '
        'DateTimePickerNewLayer
        '
        Me.DateTimePickerNewLayer.CustomFormat = "yyyy/MM/dd"
        Me.DateTimePickerNewLayer.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerNewLayer.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.DateTimePickerNewLayer.Location = New System.Drawing.Point(81, 5)
        Me.DateTimePickerNewLayer.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePickerNewLayer.Name = "DateTimePickerNewLayer"
        Me.DateTimePickerNewLayer.Size = New System.Drawing.Size(112, 19)
        Me.DateTimePickerNewLayer.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(0, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "時期設定"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 12)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "オブジェクトグループ"
        '
        'txtNewLayerName
        '
        Me.txtNewLayerName.Location = New System.Drawing.Point(68, 65)
        Me.txtNewLayerName.Name = "txtNewLayerName"
        Me.txtNewLayerName.Size = New System.Drawing.Size(140, 19)
        Me.txtNewLayerName.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 12)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "地図ファイル"
        '
        'cboNewLayerMapFile
        '
        Me.cboNewLayerMapFile.AsteriskSelectEnabled = True
        Me.cboNewLayerMapFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewLayerMapFile.FormattingEnabled = True
        Me.cboNewLayerMapFile.IntegralHeight = False
        Me.cboNewLayerMapFile.Location = New System.Drawing.Point(14, 30)
        Me.cboNewLayerMapFile.Name = "cboNewLayerMapFile"
        Me.cboNewLayerMapFile.Size = New System.Drawing.Size(192, 20)
        Me.cboNewLayerMapFile.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 12)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "初期属性データ項目"
        '
        'cboNewLayObjGroup
        '
        Me.cboNewLayObjGroup.AsteriskSelectEnabled = True
        Me.cboNewLayObjGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewLayObjGroup.FormattingEnabled = True
        Me.cboNewLayObjGroup.IntegralHeight = False
        Me.cboNewLayObjGroup.Location = New System.Drawing.Point(19, 118)
        Me.cboNewLayObjGroup.Name = "cboNewLayObjGroup"
        Me.cboNewLayObjGroup.Size = New System.Drawing.Size(192, 20)
        Me.cboNewLayObjGroup.TabIndex = 2
        '
        'lbNewLayerDefData
        '
        Me.lbNewLayerDefData.AsteriskSelectEnabled = False
        Me.lbNewLayerDefData.FormattingEnabled = True
        Me.lbNewLayerDefData.ItemHeight = 12
        Me.lbNewLayerDefData.Location = New System.Drawing.Point(19, 222)
        Me.lbNewLayerDefData.Name = "lbNewLayerDefData"
        Me.lbNewLayerDefData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbNewLayerDefData.Size = New System.Drawing.Size(192, 112)
        Me.lbNewLayerDefData.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 12)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "レイヤ名"
        '
        'frmGridAddDefData
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(552, 392)
        Me.Controls.Add(Me.gbAddNewLayer)
        Me.Controls.Add(Me.gbAddPresentLayer)
        Me.Controls.Add(Me.rbAddNewLayer)
        Me.Controls.Add(Me.rbAddPresentLayer)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGridAddDefData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "初期属性追加"
        Me.gbAddPresentLayer.ResumeLayout(False)
        Me.gbAddPresentLayer.PerformLayout()
        Me.gbAddNewLayer.ResumeLayout(False)
        Me.gbAddNewLayer.PerformLayout()
        Me.pnlTime.ResumeLayout(False)
        Me.pnlTime.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents rbAddPresentLayer As System.Windows.Forms.RadioButton
    Friend WithEvents rbAddNewLayer As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbPresentLayer As System.Windows.Forms.Label
    Friend WithEvents gbAddPresentLayer As System.Windows.Forms.GroupBox
    Friend WithEvents cboPLayObjectGroup As mandara10.ComboBoxEx
    Friend WithEvents lbPlayDefData As mandara10.ListBoxEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbAddNewLayer As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboNewLayObjGroup As mandara10.ComboBoxEx
    Friend WithEvents lbNewLayerDefData As mandara10.ListBoxEx
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerNewLayer As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlTime As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNewLayerName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboNewLayerMapFile As mandara10.ComboBoxEx
End Class
