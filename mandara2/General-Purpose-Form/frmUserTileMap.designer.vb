<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserTileMap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserTileMap))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbSetting = New System.Windows.Forms.GroupBox()
        Me.cboExt = New mandara10.ComboBoxEx()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboMinZoom = New mandara10.ComboBoxEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboMaxZoom = New mandara10.ComboBoxEx()
        Me.txtCopyright = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtLegendURL = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbOrignSW = New System.Windows.Forms.RadioButton()
        Me.rbOrifinNW = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbZYX = New System.Windows.Forms.RadioButton()
        Me.rbZXY = New System.Windows.Forms.RadioButton()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDownword = New System.Windows.Forms.Button()
        Me.btnUpword = New System.Windows.Forms.Button()
        Me.list = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbSetting.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(338, 443)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(270, 443)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "名称"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 232)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "著作権表示"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 12)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "凡例URL"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 12)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "URL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(267, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "拡張子"
        '
        'gbSetting
        '
        Me.gbSetting.Controls.Add(Me.cboExt)
        Me.gbSetting.Controls.Add(Me.GroupBox4)
        Me.gbSetting.Controls.Add(Me.txtCopyright)
        Me.gbSetting.Controls.Add(Me.btnDelete)
        Me.gbSetting.Controls.Add(Me.Label6)
        Me.gbSetting.Controls.Add(Me.txtLegendURL)
        Me.gbSetting.Controls.Add(Me.GroupBox3)
        Me.gbSetting.Controls.Add(Me.GroupBox2)
        Me.gbSetting.Controls.Add(Me.Label2)
        Me.gbSetting.Controls.Add(Me.txtName)
        Me.gbSetting.Controls.Add(Me.txtURL)
        Me.gbSetting.Controls.Add(Me.Label1)
        Me.gbSetting.Controls.Add(Me.Label3)
        Me.gbSetting.Controls.Add(Me.Label5)
        Me.gbSetting.Location = New System.Drawing.Point(24, 144)
        Me.gbSetting.Name = "gbSetting"
        Me.gbSetting.Size = New System.Drawing.Size(376, 294)
        Me.gbSetting.TabIndex = 4
        Me.gbSetting.TabStop = False
        Me.gbSetting.Text = "設定"
        '
        'cboExt
        '
        Me.cboExt.AsteriskSelectEnabled = False
        Me.cboExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExt.FormattingEnabled = True
        Me.cboExt.IntegralHeight = False
        Me.cboExt.Location = New System.Drawing.Point(314, 147)
        Me.cboExt.Name = "cboExt"
        Me.cboExt.Size = New System.Drawing.Size(53, 20)
        Me.cboExt.TabIndex = 5
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboMinZoom)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.cboMaxZoom)
        Me.GroupBox4.Location = New System.Drawing.Point(22, 129)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(237, 48)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "ズームレベル"
        '
        'cboMinZoom
        '
        Me.cboMinZoom.AsteriskSelectEnabled = False
        Me.cboMinZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMinZoom.FormattingEnabled = True
        Me.cboMinZoom.IntegralHeight = False
        Me.cboMinZoom.Location = New System.Drawing.Point(58, 18)
        Me.cboMinZoom.Name = "cboMinZoom"
        Me.cboMinZoom.Size = New System.Drawing.Size(53, 20)
        Me.cboMinZoom.TabIndex = 39
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(129, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 12)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "最大"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "最小"
        '
        'cboMaxZoom
        '
        Me.cboMaxZoom.AsteriskSelectEnabled = False
        Me.cboMaxZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaxZoom.FormattingEnabled = True
        Me.cboMaxZoom.IntegralHeight = False
        Me.cboMaxZoom.Location = New System.Drawing.Point(167, 19)
        Me.cboMaxZoom.Name = "cboMaxZoom"
        Me.cboMaxZoom.Size = New System.Drawing.Size(53, 20)
        Me.cboMaxZoom.TabIndex = 38
        '
        'txtCopyright
        '
        Me.txtCopyright.Location = New System.Drawing.Point(92, 232)
        Me.txtCopyright.Name = "txtCopyright"
        Me.txtCopyright.Size = New System.Drawing.Size(266, 19)
        Me.txtCopyright.TabIndex = 7
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(295, 256)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(63, 26)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtLegendURL
        '
        Me.txtLegendURL.Location = New System.Drawing.Point(92, 201)
        Me.txtLegendURL.Name = "txtLegendURL"
        Me.txtLegendURL.Size = New System.Drawing.Size(266, 19)
        Me.txtLegendURL.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbOrignSW)
        Me.GroupBox3.Controls.Add(Me.rbOrifinNW)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 75)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(164, 48)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "起点"
        '
        'rbOrignSW
        '
        Me.rbOrignSW.AutoSize = True
        Me.rbOrignSW.Location = New System.Drawing.Point(97, 18)
        Me.rbOrignSW.Name = "rbOrignSW"
        Me.rbOrignSW.Size = New System.Drawing.Size(47, 16)
        Me.rbOrignSW.TabIndex = 1
        Me.rbOrignSW.TabStop = True
        Me.rbOrignSW.Text = "南西"
        Me.rbOrignSW.UseVisualStyleBackColor = True
        '
        'rbOrifinNW
        '
        Me.rbOrifinNW.AutoSize = True
        Me.rbOrifinNW.Location = New System.Drawing.Point(22, 18)
        Me.rbOrifinNW.Name = "rbOrifinNW"
        Me.rbOrifinNW.Size = New System.Drawing.Size(47, 16)
        Me.rbOrifinNW.TabIndex = 0
        Me.rbOrifinNW.TabStop = True
        Me.rbOrifinNW.Text = "北西"
        Me.rbOrifinNW.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbZYX)
        Me.GroupBox2.Controls.Add(Me.rbZXY)
        Me.GroupBox2.Location = New System.Drawing.Point(201, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(163, 48)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "XYZの並び"
        '
        'rbZYX
        '
        Me.rbZYX.AutoSize = True
        Me.rbZYX.Location = New System.Drawing.Point(97, 18)
        Me.rbZYX.Name = "rbZYX"
        Me.rbZYX.Size = New System.Drawing.Size(52, 16)
        Me.rbZYX.TabIndex = 35
        Me.rbZYX.TabStop = True
        Me.rbZYX.Text = "z/y/x"
        Me.rbZYX.UseVisualStyleBackColor = True
        '
        'rbZXY
        '
        Me.rbZXY.AutoSize = True
        Me.rbZXY.Location = New System.Drawing.Point(22, 18)
        Me.rbZXY.Name = "rbZXY"
        Me.rbZXY.Size = New System.Drawing.Size(52, 16)
        Me.rbZXY.TabIndex = 34
        Me.rbZXY.TabStop = True
        Me.rbZXY.Text = "z/x/y"
        Me.rbZXY.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(54, 17)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(168, 19)
        Me.txtName.TabIndex = 0
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(54, 46)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(304, 19)
        Me.txtURL.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(338, 101)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(62, 26)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDownword
        '
        Me.btnDownword.Image = CType(resources.GetObject("btnDownword.Image"), System.Drawing.Image)
        Me.btnDownword.Location = New System.Drawing.Point(338, 65)
        Me.btnDownword.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDownword.Name = "btnDownword"
        Me.btnDownword.Size = New System.Drawing.Size(36, 34)
        Me.btnDownword.TabIndex = 2
        Me.btnDownword.UseVisualStyleBackColor = True
        '
        'btnUpword
        '
        Me.btnUpword.Image = CType(resources.GetObject("btnUpword.Image"), System.Drawing.Image)
        Me.btnUpword.Location = New System.Drawing.Point(338, 27)
        Me.btnUpword.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpword.Name = "btnUpword"
        Me.btnUpword.Size = New System.Drawing.Size(36, 34)
        Me.btnUpword.TabIndex = 1
        Me.btnUpword.UseVisualStyleBackColor = True
        '
        'list
        '
        Me.list.FormattingEnabled = True
        Me.list.ItemHeight = 12
        Me.list.Location = New System.Drawing.Point(24, 23)
        Me.list.Margin = New System.Windows.Forms.Padding(2)
        Me.list.Name = "list"
        Me.list.Size = New System.Drawing.Size(308, 112)
        Me.list.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 12)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "ユーザー設定タイルマップリスト"
        '
        'frmUserTileMap
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(418, 473)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.list)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDownword)
        Me.Controls.Add(Me.btnUpword)
        Me.Controls.Add(Me.gbSetting)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserTileMap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ユーザー設定タイルマップ"
        Me.gbSetting.ResumeLayout(False)
        Me.gbSetting.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbSetting As System.Windows.Forms.GroupBox
    Friend WithEvents rbZXY As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbZYX As System.Windows.Forms.RadioButton
    Friend WithEvents cboMaxZoom As mandara10.ComboBoxEx
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbOrignSW As System.Windows.Forms.RadioButton
    Friend WithEvents rbOrifinNW As System.Windows.Forms.RadioButton
    Friend WithEvents txtCopyright As System.Windows.Forms.TextBox
    Friend WithEvents txtLegendURL As System.Windows.Forms.TextBox
    Friend WithEvents cboExt As mandara10.ComboBoxEx
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboMinZoom As mandara10.ComboBoxEx
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDownword As System.Windows.Forms.Button
    Friend WithEvents btnUpword As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents list As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
