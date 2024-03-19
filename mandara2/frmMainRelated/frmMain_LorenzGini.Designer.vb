<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_LorenzGini
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbYData = New mandara10.ListBoxEx()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboXData = New mandara10.ComboBoxEx()
        Me.rbData = New System.Windows.Forms.RadioButton()
        Me.rbArea = New System.Windows.Forms.RadioButton()
        Me.rbNoX = New System.Windows.Forms.RadioButton()
        Me.picGraph = New System.Windows.Forms.PictureBox()
        Me.btnCopyGraph = New System.Windows.Forms.Button()
        Me.btnImageCopy = New System.Windows.Forms.Button()
        Me.btnTextCopy = New System.Windows.Forms.Button()
        Me.ListViewEX = New mandara10.ListViewEX()
        Me.chkConditionUse = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(870, 392)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 24)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "終了"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbYData)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(190, 151)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "縦軸データ"
        '
        'lbYData
        '
        Me.lbYData.AsteriskSelectEnabled = False
        Me.lbYData.FormattingEnabled = True
        Me.lbYData.ItemHeight = 12
        Me.lbYData.Location = New System.Drawing.Point(12, 18)
        Me.lbYData.Name = "lbYData"
        Me.lbYData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbYData.Size = New System.Drawing.Size(163, 124)
        Me.lbYData.TabIndex = 55
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboXData)
        Me.GroupBox2.Controls.Add(Me.rbData)
        Me.GroupBox2.Controls.Add(Me.rbArea)
        Me.GroupBox2.Controls.Add(Me.rbNoX)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 207)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(190, 99)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "横軸データ"
        '
        'cboXData
        '
        Me.cboXData.AsteriskSelectEnabled = False
        Me.cboXData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXData.FormattingEnabled = True
        Me.cboXData.IntegralHeight = False
        Me.cboXData.Location = New System.Drawing.Point(35, 64)
        Me.cboXData.MaxDropDownItems = 20
        Me.cboXData.Name = "cboXData"
        Me.cboXData.Size = New System.Drawing.Size(140, 20)
        Me.cboXData.TabIndex = 51
        '
        'rbData
        '
        Me.rbData.AutoSize = True
        Me.rbData.Location = New System.Drawing.Point(21, 42)
        Me.rbData.Name = "rbData"
        Me.rbData.Size = New System.Drawing.Size(75, 16)
        Me.rbData.TabIndex = 3
        Me.rbData.TabStop = True
        Me.rbData.Text = "データ項目"
        Me.rbData.UseVisualStyleBackColor = True
        '
        'rbArea
        '
        Me.rbArea.AutoSize = True
        Me.rbArea.Location = New System.Drawing.Point(89, 18)
        Me.rbArea.Name = "rbArea"
        Me.rbArea.Size = New System.Drawing.Size(83, 16)
        Me.rbArea.TabIndex = 2
        Me.rbArea.TabStop = True
        Me.rbArea.Text = "面積（計測）"
        Me.rbArea.UseVisualStyleBackColor = True
        '
        'rbNoX
        '
        Me.rbNoX.AutoSize = True
        Me.rbNoX.Location = New System.Drawing.Point(21, 18)
        Me.rbNoX.Name = "rbNoX"
        Me.rbNoX.Size = New System.Drawing.Size(42, 16)
        Me.rbNoX.TabIndex = 1
        Me.rbNoX.TabStop = True
        Me.rbNoX.Text = "なし"
        Me.rbNoX.UseVisualStyleBackColor = True
        '
        'picGraph
        '
        Me.picGraph.BackColor = System.Drawing.Color.White
        Me.picGraph.Location = New System.Drawing.Point(218, 37)
        Me.picGraph.Name = "picGraph"
        Me.picGraph.Size = New System.Drawing.Size(543, 379)
        Me.picGraph.TabIndex = 10
        Me.picGraph.TabStop = False
        '
        'btnCopyGraph
        '
        Me.btnCopyGraph.Location = New System.Drawing.Point(767, 335)
        Me.btnCopyGraph.Name = "btnCopyGraph"
        Me.btnCopyGraph.Size = New System.Drawing.Size(99, 23)
        Me.btnCopyGraph.TabIndex = 4
        Me.btnCopyGraph.Text = "グラフコピー"
        Me.btnCopyGraph.UseVisualStyleBackColor = True
        '
        'btnImageCopy
        '
        Me.btnImageCopy.Location = New System.Drawing.Point(767, 364)
        Me.btnImageCopy.Name = "btnImageCopy"
        Me.btnImageCopy.Size = New System.Drawing.Size(99, 23)
        Me.btnImageCopy.TabIndex = 5
        Me.btnImageCopy.Text = "画像としてコピー"
        Me.btnImageCopy.UseVisualStyleBackColor = True
        '
        'btnTextCopy
        '
        Me.btnTextCopy.Location = New System.Drawing.Point(870, 297)
        Me.btnTextCopy.Name = "btnTextCopy"
        Me.btnTextCopy.Size = New System.Drawing.Size(99, 23)
        Me.btnTextCopy.TabIndex = 3
        Me.btnTextCopy.Text = "ジニ係数コピー"
        Me.btnTextCopy.UseVisualStyleBackColor = True
        '
        'ListViewEX
        '
        Me.ListViewEX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewEX.GridLines = True
        Me.ListViewEX.Location = New System.Drawing.Point(767, 37)
        Me.ListViewEX.Name = "ListViewEX"
        Me.ListViewEX.Size = New System.Drawing.Size(202, 254)
        Me.ListViewEX.TabIndex = 2
        Me.ListViewEX.UseCompatibleStateImageBehavior = False
        Me.ListViewEX.View = System.Windows.Forms.View.Details
        '
        'chkConditionUse
        '
        Me.chkConditionUse.Location = New System.Drawing.Point(22, 326)
        Me.chkConditionUse.Name = "chkConditionUse"
        Me.chkConditionUse.Size = New System.Drawing.Size(175, 43)
        Me.chkConditionUse.TabIndex = 21
        Me.chkConditionUse.Text = "表示オブジェクト限定・属性検索の条件設定を使用する"
        Me.chkConditionUse.UseVisualStyleBackColor = True
        '
        'frmMain_LorenzGini
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(981, 428)
        Me.Controls.Add(Me.chkConditionUse)
        Me.Controls.Add(Me.btnTextCopy)
        Me.Controls.Add(Me.ListViewEX)
        Me.Controls.Add(Me.btnImageCopy)
        Me.Controls.Add(Me.btnCopyGraph)
        Me.Controls.Add(Me.picGraph)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_LorenzGini"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ローレンツ曲線・ジニ係数"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbData As System.Windows.Forms.RadioButton
    Friend WithEvents rbArea As System.Windows.Forms.RadioButton
    Friend WithEvents rbNoX As System.Windows.Forms.RadioButton
    Friend WithEvents cboXData As mandara10.ComboBoxEx
    Friend WithEvents picGraph As System.Windows.Forms.PictureBox
    Friend WithEvents lbYData As mandara10.ListBoxEx
    Friend WithEvents btnCopyGraph As System.Windows.Forms.Button
    Friend WithEvents btnImageCopy As System.Windows.Forms.Button
    Friend WithEvents ListViewEX As mandara10.ListViewEX
    Friend WithEvents btnTextCopy As System.Windows.Forms.Button
    Friend WithEvents chkConditionUse As System.Windows.Forms.CheckBox
End Class
