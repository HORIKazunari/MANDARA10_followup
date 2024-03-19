<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColor
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
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.txtAlpha = New mandara10.TextNumberBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDetailColor = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picBackColor = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.hsbTransparency = New System.Windows.Forms.HScrollBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.gbUser = New System.Windows.Forms.GroupBox()
        Me.gbRecent = New System.Windows.Forms.GroupBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlButtons.SuspendLayout()
        CType(Me.picBackColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(202, 47)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.txtAlpha)
        Me.pnlButtons.Controls.Add(Me.btnCancel)
        Me.pnlButtons.Controls.Add(Me.btnOK)
        Me.pnlButtons.Controls.Add(Me.btnDetailColor)
        Me.pnlButtons.Controls.Add(Me.Label1)
        Me.pnlButtons.Controls.Add(Me.picBackColor)
        Me.pnlButtons.Controls.Add(Me.Panel1)
        Me.pnlButtons.Controls.Add(Me.Label2)
        Me.pnlButtons.Location = New System.Drawing.Point(0, 144)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(342, 75)
        Me.pnlButtons.TabIndex = 0
        '
        'txtAlpha
        '
        Me.txtAlpha.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtAlpha.Location = New System.Drawing.Point(158, 19)
        Me.txtAlpha.MaxValue = 255.0R
        Me.txtAlpha.MaxValueFlag = True
        Me.txtAlpha.MinValue = 0.0R
        Me.txtAlpha.MinValueFlag = True
        Me.txtAlpha.Name = "txtAlpha"
        Me.txtAlpha.NumberPoint = True
        Me.txtAlpha.Size = New System.Drawing.Size(50, 19)
        Me.txtAlpha.TabIndex = 1
        Me.txtAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAlpha.ValueErrorMessageFlag = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(269, 45)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 26)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnDetailColor
        '
        Me.btnDetailColor.Location = New System.Drawing.Point(213, 13)
        Me.btnDetailColor.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDetailColor.Name = "btnDetailColor"
        Me.btnDetailColor.Size = New System.Drawing.Size(70, 24)
        Me.btnDetailColor.TabIndex = 2
        Me.btnDetailColor.Text = "詳細設定"
        Me.btnDetailColor.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 47)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "設定色"
        '
        'picBackColor
        '
        Me.picBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picBackColor.Location = New System.Drawing.Point(58, 42)
        Me.picBackColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picBackColor.Name = "picBackColor"
        Me.picBackColor.Size = New System.Drawing.Size(51, 25)
        Me.picBackColor.TabIndex = 21
        Me.picBackColor.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.hsbTransparency)
        Me.Panel1.Location = New System.Drawing.Point(57, 13)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(96, 25)
        Me.Panel1.TabIndex = 0
        '
        'hsbTransparency
        '
        Me.hsbTransparency.Dock = System.Windows.Forms.DockStyle.Top
        Me.hsbTransparency.LargeChange = 1
        Me.hsbTransparency.Location = New System.Drawing.Point(0, 0)
        Me.hsbTransparency.Maximum = 255
        Me.hsbTransparency.Name = "hsbTransparency"
        Me.hsbTransparency.Size = New System.Drawing.Size(94, 21)
        Me.hsbTransparency.TabIndex = 0
        Me.hsbTransparency.Value = 255
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "透過度"
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'gbUser
        '
        Me.gbUser.Location = New System.Drawing.Point(172, 3)
        Me.gbUser.Name = "gbUser"
        Me.gbUser.Size = New System.Drawing.Size(163, 55)
        Me.gbUser.TabIndex = 25
        Me.gbUser.TabStop = False
        Me.gbUser.Text = "ユーザ定義（右クリックで設定）"
        '
        'gbRecent
        '
        Me.gbRecent.Location = New System.Drawing.Point(172, 83)
        Me.gbRecent.Name = "gbRecent"
        Me.gbRecent.Size = New System.Drawing.Size(163, 55)
        Me.gbRecent.TabIndex = 26
        Me.gbRecent.TabStop = False
        Me.gbRecent.Text = "最近使用した色"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 1000
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 1
        Me.ToolTip1.ReshowDelay = 1
        '
        'frmColor
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(347, 231)
        Me.Controls.Add(Me.gbRecent)
        Me.Controls.Add(Me.gbUser)
        Me.Controls.Add(Me.pnlButtons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmColor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "色の指定"
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlButtons.PerformLayout()
        CType(Me.picBackColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDetailColor As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picBackColor As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents hsbTransparency As System.Windows.Forms.HScrollBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents gbRecent As System.Windows.Forms.GroupBox
    Friend WithEvents gbUser As System.Windows.Forms.GroupBox
    Friend WithEvents txtAlpha As mandara10.TextNumberBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
