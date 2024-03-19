<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_ShowViewer
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
        Me.lstMapFile = New System.Windows.Forms.ListBox()
        Me.btnDeleteMapFile = New System.Windows.Forms.Button()
        Me.btnAddMapFile = New System.Windows.Forms.Button()
        Me.gbLayer = New System.Windows.Forms.GroupBox()
        Me.gbLayerSetting = New System.Windows.Forms.GroupBox()
        Me.cboMapFile = New mandara10.ComboBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLayerName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkObjKind = New mandara10.CheckedListBoxEx()
        Me.lstLayer = New System.Windows.Forms.ListBox()
        Me.btnDeleteLayer = New System.Windows.Forms.Button()
        Me.btnAddLayer = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.gbLayer.SuspendLayout()
        Me.gbLayerSetting.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(492, 329)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(417, 329)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstMapFile)
        Me.GroupBox1.Controls.Add(Me.btnDeleteMapFile)
        Me.GroupBox1.Controls.Add(Me.btnAddMapFile)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(414, 71)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "地図ファイル"
        '
        'lstMapFile
        '
        Me.lstMapFile.FormattingEnabled = True
        Me.lstMapFile.ItemHeight = 12
        Me.lstMapFile.Location = New System.Drawing.Point(22, 18)
        Me.lstMapFile.Name = "lstMapFile"
        Me.lstMapFile.Size = New System.Drawing.Size(187, 40)
        Me.lstMapFile.TabIndex = 0
        '
        'btnDeleteMapFile
        '
        Me.btnDeleteMapFile.Location = New System.Drawing.Point(344, 34)
        Me.btnDeleteMapFile.Name = "btnDeleteMapFile"
        Me.btnDeleteMapFile.Size = New System.Drawing.Size(55, 24)
        Me.btnDeleteMapFile.TabIndex = 2
        Me.btnDeleteMapFile.Text = "削除"
        Me.btnDeleteMapFile.UseVisualStyleBackColor = True
        '
        'btnAddMapFile
        '
        Me.btnAddMapFile.Location = New System.Drawing.Point(215, 34)
        Me.btnAddMapFile.Name = "btnAddMapFile"
        Me.btnAddMapFile.Size = New System.Drawing.Size(111, 24)
        Me.btnAddMapFile.TabIndex = 1
        Me.btnAddMapFile.Text = "地図ファイル追加"
        Me.btnAddMapFile.UseVisualStyleBackColor = True
        '
        'gbLayer
        '
        Me.gbLayer.Controls.Add(Me.gbLayerSetting)
        Me.gbLayer.Controls.Add(Me.lstLayer)
        Me.gbLayer.Controls.Add(Me.btnDeleteLayer)
        Me.gbLayer.Controls.Add(Me.btnAddLayer)
        Me.gbLayer.Location = New System.Drawing.Point(12, 98)
        Me.gbLayer.Name = "gbLayer"
        Me.gbLayer.Size = New System.Drawing.Size(560, 225)
        Me.gbLayer.TabIndex = 1
        Me.gbLayer.TabStop = False
        Me.gbLayer.Text = "レイヤ"
        '
        'gbLayerSetting
        '
        Me.gbLayerSetting.Controls.Add(Me.cboMapFile)
        Me.gbLayerSetting.Controls.Add(Me.Label4)
        Me.gbLayerSetting.Controls.Add(Me.txtLayerName)
        Me.gbLayerSetting.Controls.Add(Me.Label3)
        Me.gbLayerSetting.Controls.Add(Me.DateTimePicker)
        Me.gbLayerSetting.Controls.Add(Me.Label2)
        Me.gbLayerSetting.Controls.Add(Me.Label1)
        Me.gbLayerSetting.Controls.Add(Me.chkObjKind)
        Me.gbLayerSetting.Location = New System.Drawing.Point(227, 18)
        Me.gbLayerSetting.Name = "gbLayerSetting"
        Me.gbLayerSetting.Size = New System.Drawing.Size(322, 198)
        Me.gbLayerSetting.TabIndex = 3
        Me.gbLayerSetting.TabStop = False
        Me.gbLayerSetting.Text = "レイヤごとの設定"
        '
        'cboMapFile
        '
        Me.cboMapFile.AsteriskSelectEnabled = False
        Me.cboMapFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMapFile.FormattingEnabled = True
        Me.cboMapFile.IntegralHeight = False
        Me.cboMapFile.Location = New System.Drawing.Point(190, 40)
        Me.cboMapFile.Name = "cboMapFile"
        Me.cboMapFile.Size = New System.Drawing.Size(125, 20)
        Me.cboMapFile.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "レイヤ名"
        '
        'txtLayerName
        '
        Me.txtLayerName.Location = New System.Drawing.Point(19, 40)
        Me.txtLayerName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLayerName.Name = "txtLayerName"
        Me.txtLayerName.Size = New System.Drawing.Size(153, 19)
        Me.txtLayerName.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(190, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "時期設定"
        '
        'DateTimePicker
        '
        Me.DateTimePicker.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DateTimePicker.Location = New System.Drawing.Point(190, 90)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.Size = New System.Drawing.Size(126, 19)
        Me.DateTimePicker.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(182, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "使用する地図ファイル"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "表示するオブジェクトグループ"
        '
        'chkObjKind
        '
        Me.chkObjKind.CheckOnClick = True
        Me.chkObjKind.EventStop = False
        Me.chkObjKind.FormattingEnabled = True
        Me.chkObjKind.Location = New System.Drawing.Point(19, 90)
        Me.chkObjKind.Name = "chkObjKind"
        Me.chkObjKind.Size = New System.Drawing.Size(154, 88)
        Me.chkObjKind.TabIndex = 2
        '
        'lstLayer
        '
        Me.lstLayer.FormattingEnabled = True
        Me.lstLayer.ItemHeight = 12
        Me.lstLayer.Location = New System.Drawing.Point(22, 34)
        Me.lstLayer.Name = "lstLayer"
        Me.lstLayer.Size = New System.Drawing.Size(187, 124)
        Me.lstLayer.TabIndex = 0
        '
        'btnDeleteLayer
        '
        Me.btnDeleteLayer.Location = New System.Drawing.Point(140, 168)
        Me.btnDeleteLayer.Name = "btnDeleteLayer"
        Me.btnDeleteLayer.Size = New System.Drawing.Size(55, 24)
        Me.btnDeleteLayer.TabIndex = 2
        Me.btnDeleteLayer.Text = "削除"
        Me.btnDeleteLayer.UseVisualStyleBackColor = True
        '
        'btnAddLayer
        '
        Me.btnAddLayer.Location = New System.Drawing.Point(23, 168)
        Me.btnAddLayer.Name = "btnAddLayer"
        Me.btnAddLayer.Size = New System.Drawing.Size(111, 24)
        Me.btnAddLayer.TabIndex = 1
        Me.btnAddLayer.Text = "レイヤ追加"
        Me.btnAddLayer.UseVisualStyleBackColor = True
        '
        'frmMain_ShowViewer
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(583, 366)
        Me.Controls.Add(Me.gbLayer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_ShowViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "白地図・初期属性データ表示"
        Me.GroupBox1.ResumeLayout(False)
        Me.gbLayer.ResumeLayout(False)
        Me.gbLayerSetting.ResumeLayout(False)
        Me.gbLayerSetting.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstMapFile As System.Windows.Forms.ListBox
    Friend WithEvents btnDeleteMapFile As System.Windows.Forms.Button
    Friend WithEvents btnAddMapFile As System.Windows.Forms.Button
    Friend WithEvents gbLayer As System.Windows.Forms.GroupBox
    Friend WithEvents gbLayerSetting As System.Windows.Forms.GroupBox
    Friend WithEvents lstLayer As System.Windows.Forms.ListBox
    Friend WithEvents btnDeleteLayer As System.Windows.Forms.Button
    Friend WithEvents btnAddLayer As System.Windows.Forms.Button
    Friend WithEvents chkObjKind As mandara10.CheckedListBoxEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLayerName As System.Windows.Forms.TextBox
    Friend WithEvents cboMapFile As mandara10.ComboBoxEx
End Class
