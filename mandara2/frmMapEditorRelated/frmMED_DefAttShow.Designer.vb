<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_DefAttShow
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
        Me.cbVisible = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDefAttData = New mandara10.ComboBoxEx()
        Me.cbObjectGroup = New mandara10.ComboBoxEx()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.picColor = New System.Windows.Forms.PictureBox()
        Me.lblTimeNote = New System.Windows.Forms.Label()
        Me.txtSize = New mandara10.TextNumberBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(175, 187)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(248, 186)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cbVisible
        '
        Me.cbVisible.AutoSize = True
        Me.cbVisible.Location = New System.Drawing.Point(26, 23)
        Me.cbVisible.Name = "cbVisible"
        Me.cbVisible.Size = New System.Drawing.Size(105, 16)
        Me.cbVisible.TabIndex = 0
        Me.cbVisible.Text = "初期属性を表示"
        Me.cbVisible.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbDefAttData)
        Me.GroupBox1.Controls.Add(Me.cbObjectGroup)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(207, 117)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "表示データ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 12)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "初期属性データ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 12)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "オブジェクトグループ"
        '
        'cbDefAttData
        '
        Me.cbDefAttData.AsteriskSelectEnabled = False
        Me.cbDefAttData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDefAttData.FormattingEnabled = True
        Me.cbDefAttData.IntegralHeight = False
        Me.cbDefAttData.Location = New System.Drawing.Point(21, 82)
        Me.cbDefAttData.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDefAttData.MaxDropDownItems = 15
        Me.cbDefAttData.Name = "cbDefAttData"
        Me.cbDefAttData.Size = New System.Drawing.Size(178, 20)
        Me.cbDefAttData.TabIndex = 1
        '
        'cbObjectGroup
        '
        Me.cbObjectGroup.AsteriskSelectEnabled = False
        Me.cbObjectGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbObjectGroup.FormattingEnabled = True
        Me.cbObjectGroup.IntegralHeight = False
        Me.cbObjectGroup.Location = New System.Drawing.Point(21, 34)
        Me.cbObjectGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.cbObjectGroup.MaxDropDownItems = 15
        Me.cbObjectGroup.Name = "cbObjectGroup"
        Me.cbObjectGroup.Size = New System.Drawing.Size(178, 20)
        Me.cbObjectGroup.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSize)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.picColor)
        Me.GroupBox2.Location = New System.Drawing.Point(235, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(75, 117)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "文字"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 102)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "ビクセル"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 68)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 12)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "文字サイズ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "文字色"
        '
        'picColor
        '
        Me.picColor.BackColor = System.Drawing.Color.Black
        Me.picColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picColor.Location = New System.Drawing.Point(18, 34)
        Me.picColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picColor.Name = "picColor"
        Me.picColor.Size = New System.Drawing.Size(33, 26)
        Me.picColor.TabIndex = 26
        Me.picColor.TabStop = False
        '
        'lblTimeNote
        '
        Me.lblTimeNote.Location = New System.Drawing.Point(137, 21)
        Me.lblTimeNote.Name = "lblTimeNote"
        Me.lblTimeNote.Size = New System.Drawing.Size(194, 27)
        Me.lblTimeNote.TabIndex = 1
        Me.lblTimeNote.Text = "時空間モード地図ファイルの場合は、時間限定されている場合に表示されます。"
        '
        'txtSize
        '
        Me.txtSize.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSize.Location = New System.Drawing.Point(17, 81)
        Me.txtSize.MaxValue = 0.0R
        Me.txtSize.MaxValueFlag = False
        Me.txtSize.MinValue = 0.0R
        Me.txtSize.MinValueFlag = True
        Me.txtSize.Name = "txtSize"
        Me.txtSize.NumberPoint = True
        Me.txtSize.Size = New System.Drawing.Size(33, 19)
        Me.txtSize.TabIndex = 31
        Me.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSize.ValueErrorMessageFlag = True
        '
        'frmMED_DefAttShow
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(330, 221)
        Me.Controls.Add(Me.lblTimeNote)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbVisible)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_DefAttShow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "初期属性表示設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cbVisible As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbDefAttData As mandara10.ComboBoxEx
    Friend WithEvents cbObjectGroup As mandara10.ComboBoxEx
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents picColor As System.Windows.Forms.PictureBox
    Friend WithEvents lblTimeNote As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSize As mandara10.TextNumberBox
End Class
