<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPictureSelector
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
        Me.pnlPictureBase = New System.Windows.Forms.Panel()
        Me.pnlPictureList = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlSelectedImage = New System.Windows.Forms.Panel()
        Me.picSelectedImage = New System.Windows.Forms.PictureBox()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTransRange = New System.Windows.Forms.ComboBox()
        Me.pnlInnerColor = New System.Windows.Forms.Panel()
        Me.picInnerColor = New System.Windows.Forms.PictureBox()
        Me.pnlTransparency = New System.Windows.Forms.Panel()
        Me.picTransparancyColor = New System.Windows.Forms.PictureBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.chkInnerColor = New System.Windows.Forms.CheckBox()
        Me.chkTransparencyColor = New System.Windows.Forms.CheckBox()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAddFromClipBoard = New System.Windows.Forms.Button()
        Me.btnAddFromFile = New System.Windows.Forms.Button()
        Me.pnlPictureBase.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlSelectedImage.SuspendLayout()
        CType(Me.picSelectedImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInfo.SuspendLayout()
        Me.pnlInnerColor.SuspendLayout()
        CType(Me.picInnerColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTransparency.SuspendLayout()
        CType(Me.picTransparancyColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(546, 332)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 22
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(624, 332)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnlPictureBase
        '
        Me.pnlPictureBase.AutoScroll = True
        Me.pnlPictureBase.BackColor = System.Drawing.Color.White
        Me.pnlPictureBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPictureBase.Controls.Add(Me.pnlPictureList)
        Me.pnlPictureBase.Location = New System.Drawing.Point(9, 11)
        Me.pnlPictureBase.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlPictureBase.Name = "pnlPictureBase"
        Me.pnlPictureBase.Size = New System.Drawing.Size(184, 228)
        Me.pnlPictureBase.TabIndex = 23
        '
        'pnlPictureList
        '
        Me.pnlPictureList.BackColor = System.Drawing.Color.White
        Me.pnlPictureList.Location = New System.Drawing.Point(0, 0)
        Me.pnlPictureList.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlPictureList.Name = "pnlPictureList"
        Me.pnlPictureList.Size = New System.Drawing.Size(166, 209)
        Me.pnlPictureList.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pnlSelectedImage)
        Me.GroupBox1.Controls.Add(Me.pnlInfo)
        Me.GroupBox1.Location = New System.Drawing.Point(197, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(499, 319)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "情報"
        '
        'pnlSelectedImage
        '
        Me.pnlSelectedImage.AutoScroll = True
        Me.pnlSelectedImage.Controls.Add(Me.picSelectedImage)
        Me.pnlSelectedImage.Location = New System.Drawing.Point(19, 19)
        Me.pnlSelectedImage.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlSelectedImage.Name = "pnlSelectedImage"
        Me.pnlSelectedImage.Size = New System.Drawing.Size(278, 286)
        Me.pnlSelectedImage.TabIndex = 9
        '
        'picSelectedImage
        '
        Me.picSelectedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSelectedImage.Location = New System.Drawing.Point(0, 0)
        Me.picSelectedImage.Margin = New System.Windows.Forms.Padding(2)
        Me.picSelectedImage.Name = "picSelectedImage"
        Me.picSelectedImage.Size = New System.Drawing.Size(174, 144)
        Me.picSelectedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picSelectedImage.TabIndex = 0
        Me.picSelectedImage.TabStop = False
        '
        'pnlInfo
        '
        Me.pnlInfo.Controls.Add(Me.Label2)
        Me.pnlInfo.Controls.Add(Me.Label1)
        Me.pnlInfo.Controls.Add(Me.cboTransRange)
        Me.pnlInfo.Controls.Add(Me.pnlInnerColor)
        Me.pnlInfo.Controls.Add(Me.pnlTransparency)
        Me.pnlInfo.Controls.Add(Me.btnDelete)
        Me.pnlInfo.Controls.Add(Me.chkInnerColor)
        Me.pnlInfo.Controls.Add(Me.chkTransparencyColor)
        Me.pnlInfo.Controls.Add(Me.txtInfo)
        Me.pnlInfo.Location = New System.Drawing.Point(301, 19)
        Me.pnlInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(188, 286)
        Me.pnlInfo.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(160, 194)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 12)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "%"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 190)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "透過範囲"
        '
        'cboTransRange
        '
        Me.cboTransRange.FormattingEnabled = True
        Me.cboTransRange.Location = New System.Drawing.Point(115, 188)
        Me.cboTransRange.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTransRange.Name = "cboTransRange"
        Me.cboTransRange.Size = New System.Drawing.Size(44, 20)
        Me.cboTransRange.TabIndex = 11
        '
        'pnlInnerColor
        '
        Me.pnlInnerColor.Controls.Add(Me.picInnerColor)
        Me.pnlInnerColor.Location = New System.Drawing.Point(115, 212)
        Me.pnlInnerColor.Name = "pnlInnerColor"
        Me.pnlInnerColor.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlInnerColor.Size = New System.Drawing.Size(60, 26)
        Me.pnlInnerColor.TabIndex = 10
        '
        'picInnerColor
        '
        Me.picInnerColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picInnerColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picInnerColor.Location = New System.Drawing.Point(3, 3)
        Me.picInnerColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picInnerColor.Name = "picInnerColor"
        Me.picInnerColor.Size = New System.Drawing.Size(54, 20)
        Me.picInnerColor.TabIndex = 5
        Me.picInnerColor.TabStop = False
        '
        'pnlTransparency
        '
        Me.pnlTransparency.Controls.Add(Me.picTransparancyColor)
        Me.pnlTransparency.Location = New System.Drawing.Point(115, 158)
        Me.pnlTransparency.Name = "pnlTransparency"
        Me.pnlTransparency.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlTransparency.Size = New System.Drawing.Size(60, 26)
        Me.pnlTransparency.TabIndex = 8
        '
        'picTransparancyColor
        '
        Me.picTransparancyColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picTransparancyColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picTransparancyColor.Location = New System.Drawing.Point(3, 3)
        Me.picTransparancyColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picTransparancyColor.Name = "picTransparancyColor"
        Me.picTransparancyColor.Size = New System.Drawing.Size(54, 20)
        Me.picTransparancyColor.TabIndex = 5
        Me.picTransparancyColor.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(91, 249)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 22)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'chkInnerColor
        '
        Me.chkInnerColor.AutoSize = True
        Me.chkInnerColor.Location = New System.Drawing.Point(18, 212)
        Me.chkInnerColor.Margin = New System.Windows.Forms.Padding(2)
        Me.chkInnerColor.Name = "chkInnerColor"
        Me.chkInnerColor.Size = New System.Drawing.Size(94, 16)
        Me.chkInnerColor.TabIndex = 3
        Me.chkInnerColor.Text = "内部色の指定"
        Me.chkInnerColor.UseVisualStyleBackColor = True
        '
        'chkTransparencyColor
        '
        Me.chkTransparencyColor.AutoSize = True
        Me.chkTransparencyColor.Location = New System.Drawing.Point(18, 165)
        Me.chkTransparencyColor.Margin = New System.Windows.Forms.Padding(2)
        Me.chkTransparencyColor.Name = "chkTransparencyColor"
        Me.chkTransparencyColor.Size = New System.Drawing.Size(94, 16)
        Me.chkTransparencyColor.TabIndex = 2
        Me.chkTransparencyColor.Text = "透過色の指定"
        Me.chkTransparencyColor.UseVisualStyleBackColor = True
        '
        'txtInfo
        '
        Me.txtInfo.Location = New System.Drawing.Point(12, 15)
        Me.txtInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ReadOnly = True
        Me.txtInfo.Size = New System.Drawing.Size(163, 130)
        Me.txtInfo.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAddFromClipBoard)
        Me.GroupBox2.Controls.Add(Me.btnAddFromFile)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 243)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(184, 86)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "画像追加"
        '
        'btnAddFromClipBoard
        '
        Me.btnAddFromClipBoard.Location = New System.Drawing.Point(39, 50)
        Me.btnAddFromClipBoard.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddFromClipBoard.Name = "btnAddFromClipBoard"
        Me.btnAddFromClipBoard.Size = New System.Drawing.Size(92, 22)
        Me.btnAddFromClipBoard.TabIndex = 9
        Me.btnAddFromClipBoard.Text = "クリップボードから"
        Me.btnAddFromClipBoard.UseVisualStyleBackColor = True
        '
        'btnAddFromFile
        '
        Me.btnAddFromFile.Location = New System.Drawing.Point(46, 24)
        Me.btnAddFromFile.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddFromFile.Name = "btnAddFromFile"
        Me.btnAddFromFile.Size = New System.Drawing.Size(75, 22)
        Me.btnAddFromFile.TabIndex = 8
        Me.btnAddFromFile.Text = "ファイルから"
        Me.btnAddFromFile.UseVisualStyleBackColor = True
        '
        'frmPictureSelector
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(706, 369)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.pnlPictureBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPictureSelector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "画像選択"
        Me.pnlPictureBase.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlSelectedImage.ResumeLayout(False)
        Me.pnlSelectedImage.PerformLayout()
        CType(Me.picSelectedImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        Me.pnlInnerColor.ResumeLayout(False)
        CType(Me.picInnerColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTransparency.ResumeLayout(False)
        CType(Me.picTransparancyColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlPictureBase As System.Windows.Forms.Panel
    Friend WithEvents pnlPictureList As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents picInnerColor As System.Windows.Forms.PictureBox
    Friend WithEvents chkInnerColor As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransparencyColor As System.Windows.Forms.CheckBox
    Friend WithEvents txtInfo As System.Windows.Forms.TextBox
    Friend WithEvents picSelectedImage As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddFromClipBoard As System.Windows.Forms.Button
    Friend WithEvents btnAddFromFile As System.Windows.Forms.Button
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents pnlInnerColor As System.Windows.Forms.Panel
    Friend WithEvents pnlTransparency As System.Windows.Forms.Panel
    Friend WithEvents picTransparancyColor As System.Windows.Forms.PictureBox
    Friend WithEvents pnlSelectedImage As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTransRange As System.Windows.Forms.ComboBox
End Class
