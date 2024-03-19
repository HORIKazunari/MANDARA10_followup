<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_ShapefileOut
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.fileSelect = New KTGISUserControl.KtgisFileSelector()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboObjectKind = New mandara10.ComboBoxEx()
        Me.gbTimeSet = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboEncoding = New mandara10.ComboBoxEx()
        Me.GroupBox1.SuspendLayout()
        Me.gbTimeSet.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(76, 278)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(143, 278)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'fileSelect
        '
        Me.fileSelect.Caption = "出力シェープファイル"
        Me.fileSelect.Extension = "shp"
        Me.fileSelect.InitFolder = ""
        Me.fileSelect.Location = New System.Drawing.Point(10, 18)
        Me.fileSelect.Name = "fileSelect"
        Me.fileSelect.Off_Button_Flag = False
        Me.fileSelect.Path = ""
        Me.fileSelect.Save_Flag = True
        Me.fileSelect.Size = New System.Drawing.Size(195, 44)
        Me.fileSelect.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboObjectKind)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 76)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(195, 53)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "出力オブジェクトグループ"
        '
        'cboObjectKind
        '
        Me.cboObjectKind.AsteriskSelectEnabled = False
        Me.cboObjectKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObjectKind.FormattingEnabled = True
        Me.cboObjectKind.IntegralHeight = False
        Me.cboObjectKind.Location = New System.Drawing.Point(11, 23)
        Me.cboObjectKind.Margin = New System.Windows.Forms.Padding(2)
        Me.cboObjectKind.Name = "cboObjectKind"
        Me.cboObjectKind.Size = New System.Drawing.Size(173, 20)
        Me.cboObjectKind.TabIndex = 5
        '
        'gbTimeSet
        '
        Me.gbTimeSet.Controls.Add(Me.DateTimePicker)
        Me.gbTimeSet.Location = New System.Drawing.Point(9, 148)
        Me.gbTimeSet.Margin = New System.Windows.Forms.Padding(2)
        Me.gbTimeSet.Name = "gbTimeSet"
        Me.gbTimeSet.Padding = New System.Windows.Forms.Padding(2)
        Me.gbTimeSet.Size = New System.Drawing.Size(196, 53)
        Me.gbTimeSet.TabIndex = 2
        Me.gbTimeSet.TabStop = False
        Me.gbTimeSet.Text = "時期設定"
        '
        'DateTimePicker
        '
        Me.DateTimePicker.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.DateTimePicker.Location = New System.Drawing.Point(29, 23)
        Me.DateTimePicker.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.Size = New System.Drawing.Size(108, 19)
        Me.DateTimePicker.TabIndex = 42
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboEncoding)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 217)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(142, 47)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "文字コード"
        '
        'cboEncoding
        '
        Me.cboEncoding.AsteriskSelectEnabled = False
        Me.cboEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEncoding.FormattingEnabled = True
        Me.cboEncoding.IntegralHeight = False
        Me.cboEncoding.Location = New System.Drawing.Point(6, 18)
        Me.cboEncoding.MaxDropDownItems = 12
        Me.cboEncoding.Name = "cboEncoding"
        Me.cboEncoding.Size = New System.Drawing.Size(126, 20)
        Me.cboEncoding.TabIndex = 0
        '
        'frmMED_ShapefileOut
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(219, 309)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gbTimeSet)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.fileSelect)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_ShapefileOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "シェープファイル出力"
        Me.GroupBox1.ResumeLayout(False)
        Me.gbTimeSet.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents fileSelect As KTGISUserControl.KtgisFileSelector
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboObjectKind As mandara10.ComboBoxEx
    Friend WithEvents gbTimeSet As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboEncoding As mandara10.ComboBoxEx
End Class
