<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmootingLineIn
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbExplanation = New System.Windows.Forms.Label()
        Me.lbUnit1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbPoint = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbAreaUnit = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbLoop = New System.Windows.Forms.CheckBox()
        Me.txtLoopSize = New mandara10.TextBoxFocusAllSelect()
        Me.txtPointInterval = New mandara10.TextBoxFocusAllSelect()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(134, 205)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(201, 205)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 26)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPointInterval)
        Me.GroupBox1.Controls.Add(Me.lbExplanation)
        Me.GroupBox1.Controls.Add(Me.lbUnit1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbPoint)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(260, 93)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ポイント間引き"
        '
        'lbExplanation
        '
        Me.lbExplanation.AutoSize = True
        Me.lbExplanation.Location = New System.Drawing.Point(34, 74)
        Me.lbExplanation.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbExplanation.Name = "lbExplanation"
        Me.lbExplanation.Size = New System.Drawing.Size(225, 12)
        Me.lbExplanation.TabIndex = 4
        Me.lbExplanation.Text = "※初期値は現状でのポイント間距離の中央値"
        '
        'lbUnit1
        '
        Me.lbUnit1.AutoSize = True
        Me.lbUnit1.Location = New System.Drawing.Point(218, 52)
        Me.lbUnit1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbUnit1.Name = "lbUnit1"
        Me.lbUnit1.Size = New System.Drawing.Size(29, 12)
        Me.lbUnit1.TabIndex = 3
        Me.lbUnit1.Text = "単位"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 49)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ポイント取得間隔"
        '
        'cbPoint
        '
        Me.cbPoint.AutoSize = True
        Me.cbPoint.Location = New System.Drawing.Point(22, 18)
        Me.cbPoint.Margin = New System.Windows.Forms.Padding(2)
        Me.cbPoint.Name = "cbPoint"
        Me.cbPoint.Size = New System.Drawing.Size(93, 16)
        Me.cbPoint.TabIndex = 0
        Me.cbPoint.Text = "ポイント間引き"
        Me.cbPoint.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtLoopSize)
        Me.GroupBox2.Controls.Add(Me.lbAreaUnit)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cbLoop)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 107)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(260, 82)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ループ間引き"
        '
        'lbAreaUnit
        '
        Me.lbAreaUnit.AutoSize = True
        Me.lbAreaUnit.Location = New System.Drawing.Point(218, 52)
        Me.lbAreaUnit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbAreaUnit.Name = "lbAreaUnit"
        Me.lbAreaUnit.Size = New System.Drawing.Size(29, 12)
        Me.lbAreaUnit.TabIndex = 3
        Me.lbAreaUnit.Text = "単位"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 49)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "ループ最小取得サイズ"
        '
        'cbLoop
        '
        Me.cbLoop.AutoSize = True
        Me.cbLoop.Location = New System.Drawing.Point(22, 18)
        Me.cbLoop.Margin = New System.Windows.Forms.Padding(2)
        Me.cbLoop.Name = "cbLoop"
        Me.cbLoop.Size = New System.Drawing.Size(86, 16)
        Me.cbLoop.TabIndex = 0
        Me.cbLoop.Text = "ループ間引き"
        Me.cbLoop.UseVisualStyleBackColor = True
        '
        'txtLoopSize
        '
        Me.txtLoopSize.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLoopSize.Location = New System.Drawing.Point(135, 46)
        Me.txtLoopSize.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLoopSize.Name = "txtLoopSize"
        Me.txtLoopSize.Size = New System.Drawing.Size(79, 19)
        Me.txtLoopSize.TabIndex = 2
        Me.txtLoopSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPointInterval
        '
        Me.txtPointInterval.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPointInterval.Location = New System.Drawing.Point(135, 46)
        Me.txtPointInterval.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPointInterval.Name = "txtPointInterval"
        Me.txtPointInterval.Size = New System.Drawing.Size(79, 19)
        Me.txtPointInterval.TabIndex = 5
        Me.txtPointInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmSmootingLineIn
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(282, 239)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSmootingLineIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ポイント・ループ間引き設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbExplanation As System.Windows.Forms.Label
    Friend WithEvents lbUnit1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbPoint As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbAreaUnit As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbLoop As System.Windows.Forms.CheckBox
    Friend WithEvents txtPointInterval As mandara10.TextBoxFocusAllSelect
    Friend WithEvents txtLoopSize As mandara10.TextBoxFocusAllSelect
End Class
