<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLpatBasicSelect
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.picColor = New System.Windows.Forms.PictureBox()
        Me.btnDetail = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.pnlLineSample = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelUser = New System.Windows.Forms.Panel()
        Me.pnlUserLine = New System.Windows.Forms.Panel()
        Me.PanelRecent = New System.Windows.Forms.Panel()
        Me.pnlRecentLine = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.picColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        Me.PanelUser.SuspendLayout()
        Me.PanelRecent.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(307, 274)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 26)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'picColor
        '
        Me.picColor.BackColor = System.Drawing.Color.Black
        Me.picColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picColor.Location = New System.Drawing.Point(39, 238)
        Me.picColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picColor.Name = "picColor"
        Me.picColor.Size = New System.Drawing.Size(44, 26)
        Me.picColor.TabIndex = 17
        Me.picColor.TabStop = False
        '
        'btnDetail
        '
        Me.btnDetail.Location = New System.Drawing.Point(101, 236)
        Me.btnDetail.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(86, 26)
        Me.btnDetail.TabIndex = 18
        Me.btnDetail.Text = "詳細設定へ"
        Me.btnDetail.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(227, 276)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 19
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Panel
        '
        Me.Panel.AutoScroll = True
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.pnlLineSample)
        Me.Panel.Location = New System.Drawing.Point(9, 10)
        Me.Panel.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(180, 222)
        Me.Panel.TabIndex = 20
        '
        'pnlLineSample
        '
        Me.pnlLineSample.BackColor = System.Drawing.Color.White
        Me.pnlLineSample.Location = New System.Drawing.Point(0, 0)
        Me.pnlLineSample.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlLineSample.Name = "pnlLineSample"
        Me.pnlLineSample.Size = New System.Drawing.Size(137, 198)
        Me.pnlLineSample.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 245)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "色"
        '
        'PanelUser
        '
        Me.PanelUser.AutoScroll = True
        Me.PanelUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelUser.Controls.Add(Me.pnlUserLine)
        Me.PanelUser.Location = New System.Drawing.Point(193, 23)
        Me.PanelUser.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelUser.Name = "PanelUser"
        Me.PanelUser.Size = New System.Drawing.Size(184, 118)
        Me.PanelUser.TabIndex = 22
        '
        'pnlUserLine
        '
        Me.pnlUserLine.BackColor = System.Drawing.Color.White
        Me.pnlUserLine.Location = New System.Drawing.Point(0, 0)
        Me.pnlUserLine.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlUserLine.Name = "pnlUserLine"
        Me.pnlUserLine.Size = New System.Drawing.Size(137, 80)
        Me.pnlUserLine.TabIndex = 0
        '
        'PanelRecent
        '
        Me.PanelRecent.AutoScroll = True
        Me.PanelRecent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelRecent.Controls.Add(Me.pnlRecentLine)
        Me.PanelRecent.Location = New System.Drawing.Point(193, 157)
        Me.PanelRecent.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelRecent.Name = "PanelRecent"
        Me.PanelRecent.Size = New System.Drawing.Size(184, 105)
        Me.PanelRecent.TabIndex = 23
        '
        'pnlRecentLine
        '
        Me.pnlRecentLine.BackColor = System.Drawing.Color.White
        Me.pnlRecentLine.Location = New System.Drawing.Point(0, 0)
        Me.pnlRecentLine.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlRecentLine.Name = "pnlRecentLine"
        Me.pnlRecentLine.Size = New System.Drawing.Size(137, 80)
        Me.pnlRecentLine.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(193, 9)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 12)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "ユーザ定義ライン（右クリックで設定）"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(193, 143)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 12)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "最近使用したラインパターン"
        '
        'frmLpatBasicSelect
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(388, 311)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PanelRecent)
        Me.Controls.Add(Me.PanelUser)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnDetail)
        Me.Controls.Add(Me.picColor)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLpatBasicSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "基本ラインパターン"
        CType(Me.picColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        Me.PanelUser.ResumeLayout(False)
        Me.PanelRecent.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents picColor As System.Windows.Forms.PictureBox
    Friend WithEvents btnDetail As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents pnlLineSample As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelUser As System.Windows.Forms.Panel
    Friend WithEvents pnlUserLine As System.Windows.Forms.Panel
    Friend WithEvents PanelRecent As System.Windows.Forms.Panel
    Friend WithEvents pnlRecentLine As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
