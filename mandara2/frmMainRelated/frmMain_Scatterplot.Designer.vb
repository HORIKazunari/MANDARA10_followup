<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_Scatterplot
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
        Me.btnImageCopy = New System.Windows.Forms.Button()
        Me.btnCopyGraph = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboXData = New mandara10.ComboBoxEx()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboYData = New mandara10.ComboBoxEx()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.picGraph = New System.Windows.Forms.PictureBox()
        Me.lblPicGraph = New System.Windows.Forms.Label()
        Me.picMark = New System.Windows.Forms.PictureBox()
        Me.txtStatBox = New System.Windows.Forms.TextBox()
        Me.cbReg = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkConditionUse = New System.Windows.Forms.CheckBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImageCopy
        '
        Me.btnImageCopy.Location = New System.Drawing.Point(115, 382)
        Me.btnImageCopy.Name = "btnImageCopy"
        Me.btnImageCopy.Size = New System.Drawing.Size(99, 23)
        Me.btnImageCopy.TabIndex = 10
        Me.btnImageCopy.Text = "画像としてコピー"
        Me.btnImageCopy.UseVisualStyleBackColor = True
        '
        'btnCopyGraph
        '
        Me.btnCopyGraph.Location = New System.Drawing.Point(115, 353)
        Me.btnCopyGraph.Name = "btnCopyGraph"
        Me.btnCopyGraph.Size = New System.Drawing.Size(99, 23)
        Me.btnCopyGraph.TabIndex = 9
        Me.btnCopyGraph.Text = "グラフコピー"
        Me.btnCopyGraph.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboXData)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(190, 62)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "X軸データ"
        '
        'cboXData
        '
        Me.cboXData.AsteriskSelectEnabled = False
        Me.cboXData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXData.FormattingEnabled = True
        Me.cboXData.IntegralHeight = False
        Me.cboXData.Location = New System.Drawing.Point(15, 27)
        Me.cboXData.MaxDropDownItems = 20
        Me.cboXData.Name = "cboXData"
        Me.cboXData.Size = New System.Drawing.Size(155, 20)
        Me.cboXData.TabIndex = 51
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboYData)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(190, 70)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Y軸データ"
        '
        'cboYData
        '
        Me.cboYData.AsteriskSelectEnabled = False
        Me.cboYData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYData.FormattingEnabled = True
        Me.cboYData.IntegralHeight = False
        Me.cboYData.Location = New System.Drawing.Point(15, 30)
        Me.cboYData.MaxDropDownItems = 20
        Me.cboYData.Name = "cboYData"
        Me.cboYData.Size = New System.Drawing.Size(155, 20)
        Me.cboYData.TabIndex = 52
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(115, 410)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 24)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "終了"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'picGraph
        '
        Me.picGraph.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picGraph.BackColor = System.Drawing.Color.White
        Me.picGraph.Location = New System.Drawing.Point(230, 12)
        Me.picGraph.Name = "picGraph"
        Me.picGraph.Size = New System.Drawing.Size(509, 419)
        Me.picGraph.TabIndex = 12
        Me.picGraph.TabStop = False
        '
        'lblPicGraph
        '
        Me.lblPicGraph.AutoSize = True
        Me.lblPicGraph.Location = New System.Drawing.Point(437, 201)
        Me.lblPicGraph.Name = "lblPicGraph"
        Me.lblPicGraph.Size = New System.Drawing.Size(38, 12)
        Me.lblPicGraph.TabIndex = 14
        Me.lblPicGraph.Text = "Label1"
        '
        'picMark
        '
        Me.picMark.BackColor = System.Drawing.Color.White
        Me.picMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMark.Location = New System.Drawing.Point(31, 182)
        Me.picMark.Name = "picMark"
        Me.picMark.Size = New System.Drawing.Size(41, 38)
        Me.picMark.TabIndex = 15
        Me.picMark.TabStop = False
        '
        'txtStatBox
        '
        Me.txtStatBox.Location = New System.Drawing.Point(31, 262)
        Me.txtStatBox.Multiline = True
        Me.txtStatBox.Name = "txtStatBox"
        Me.txtStatBox.Size = New System.Drawing.Size(183, 85)
        Me.txtStatBox.TabIndex = 16
        '
        'cbReg
        '
        Me.cbReg.AutoSize = True
        Me.cbReg.Location = New System.Drawing.Point(31, 240)
        Me.cbReg.Name = "cbReg"
        Me.cbReg.Size = New System.Drawing.Size(84, 16)
        Me.cbReg.TabIndex = 18
        Me.cbReg.Text = "単回帰分析"
        Me.cbReg.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "記号"
        '
        'chkConditionUse
        '
        Me.chkConditionUse.Location = New System.Drawing.Point(78, 182)
        Me.chkConditionUse.Name = "chkConditionUse"
        Me.chkConditionUse.Size = New System.Drawing.Size(146, 43)
        Me.chkConditionUse.TabIndex = 20
        Me.chkConditionUse.Text = "表示オブジェクト限定・属性検索の条件設定を使用する"
        Me.chkConditionUse.UseVisualStyleBackColor = True
        '
        'frmMain_Scatterplot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 443)
        Me.Controls.Add(Me.chkConditionUse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbReg)
        Me.Controls.Add(Me.txtStatBox)
        Me.Controls.Add(Me.picMark)
        Me.Controls.Add(Me.lblPicGraph)
        Me.Controls.Add(Me.picGraph)
        Me.Controls.Add(Me.btnImageCopy)
        Me.Controls.Add(Me.btnCopyGraph)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_Scatterplot"
        Me.Text = "散布図"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picGraph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnImageCopy As System.Windows.Forms.Button
    Friend WithEvents btnCopyGraph As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboXData As mandara10.ComboBoxEx
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboYData As mandara10.ComboBoxEx
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents picGraph As System.Windows.Forms.PictureBox
    Friend WithEvents lblPicGraph As System.Windows.Forms.Label
    Friend WithEvents picMark As System.Windows.Forms.PictureBox
    Friend WithEvents txtStatBox As System.Windows.Forms.TextBox
    Friend WithEvents cbReg As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkConditionUse As System.Windows.Forms.CheckBox
End Class
