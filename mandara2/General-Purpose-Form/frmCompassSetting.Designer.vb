<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompassSetting
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
        Me.picCompass = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFont = New System.Windows.Forms.Button()
        Me.txtWest = New System.Windows.Forms.TextBox()
        Me.txtEast = New System.Windows.Forms.TextBox()
        Me.txtSouth = New System.Windows.Forms.TextBox()
        Me.txtNorth = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCompassVisible = New System.Windows.Forms.CheckBox()
        CType(Me.picCompass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(123, 178)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(190, 178)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'picCompass
        '
        Me.picCompass.BackColor = System.Drawing.Color.White
        Me.picCompass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCompass.Location = New System.Drawing.Point(20, 58)
        Me.picCompass.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.picCompass.Name = "picCompass"
        Me.picCompass.Size = New System.Drawing.Size(104, 103)
        Me.picCompass.TabIndex = 15
        Me.picCompass.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 41)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 12)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "方位記号の形状"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFont)
        Me.GroupBox1.Controls.Add(Me.txtWest)
        Me.GroupBox1.Controls.Add(Me.txtEast)
        Me.GroupBox1.Controls.Add(Me.txtSouth)
        Me.GroupBox1.Controls.Add(Me.txtNorth)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(136, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(117, 155)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "方位文字"
        '
        'btnFont
        '
        Me.btnFont.Location = New System.Drawing.Point(45, 130)
        Me.btnFont.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnFont.Name = "btnFont"
        Me.btnFont.Size = New System.Drawing.Size(56, 21)
        Me.btnFont.TabIndex = 8
        Me.btnFont.Text = "フォント"
        Me.btnFont.UseVisualStyleBackColor = True
        '
        'txtWest
        '
        Me.txtWest.Location = New System.Drawing.Point(45, 102)
        Me.txtWest.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtWest.Name = "txtWest"
        Me.txtWest.Size = New System.Drawing.Size(57, 19)
        Me.txtWest.TabIndex = 7
        '
        'txtEast
        '
        Me.txtEast.Location = New System.Drawing.Point(45, 77)
        Me.txtEast.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtEast.Name = "txtEast"
        Me.txtEast.Size = New System.Drawing.Size(57, 19)
        Me.txtEast.TabIndex = 6
        '
        'txtSouth
        '
        Me.txtSouth.Location = New System.Drawing.Point(45, 50)
        Me.txtSouth.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSouth.Name = "txtSouth"
        Me.txtSouth.Size = New System.Drawing.Size(57, 19)
        Me.txtSouth.TabIndex = 5
        '
        'txtNorth
        '
        Me.txtNorth.Location = New System.Drawing.Point(45, 23)
        Me.txtNorth.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtNorth.Name = "txtNorth"
        Me.txtNorth.Size = New System.Drawing.Size(57, 19)
        Me.txtNorth.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 105)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "西"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 79)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "東"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 53)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "南"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "北"
        '
        'cbCompassVisible
        '
        Me.cbCompassVisible.AutoSize = True
        Me.cbCompassVisible.Location = New System.Drawing.Point(8, 10)
        Me.cbCompassVisible.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbCompassVisible.Name = "cbCompassVisible"
        Me.cbCompassVisible.Size = New System.Drawing.Size(124, 16)
        Me.cbCompassVisible.TabIndex = 0
        Me.cbCompassVisible.Text = "方位記号を表示する"
        Me.cbCompassVisible.UseVisualStyleBackColor = True
        '
        'frmCompassSetting
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(264, 211)
        Me.Controls.Add(Me.cbCompassVisible)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picCompass)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCompassSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "方位記号の設定"
        CType(Me.picCompass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents picCompass As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFont As System.Windows.Forms.Button
    Friend WithEvents txtWest As System.Windows.Forms.TextBox
    Friend WithEvents txtEast As System.Windows.Forms.TextBox
    Friend WithEvents txtSouth As System.Windows.Forms.TextBox
    Friend WithEvents txtNorth As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbCompassVisible As System.Windows.Forms.CheckBox
End Class
