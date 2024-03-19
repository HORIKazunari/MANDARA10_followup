<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMakeLinePattern
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
        Me.btnBasicLine = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCrossSet = New System.Windows.Forms.Button()
        Me.btnDoubleSet = New System.Windows.Forms.Button()
        Me.btnBrokenSet = New System.Windows.Forms.Button()
        Me.btnSolidSet = New System.Windows.Forms.Button()
        Me.btnEdge = New System.Windows.Forms.Button()
        Me.cbCrossLine = New System.Windows.Forms.CheckBox()
        Me.cbDoubleLine = New System.Windows.Forms.CheckBox()
        Me.rbBlancLine = New System.Windows.Forms.RadioButton()
        Me.rbBrokenLine = New System.Windows.Forms.RadioButton()
        Me.rbSolidLine = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.picSample = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picSample, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(91, 294)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(162, 293)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 25)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnBasicLine
        '
        Me.btnBasicLine.Location = New System.Drawing.Point(162, 251)
        Me.btnBasicLine.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBasicLine.Name = "btnBasicLine"
        Me.btnBasicLine.Size = New System.Drawing.Size(70, 26)
        Me.btnBasicLine.TabIndex = 2
        Me.btnBasicLine.Text = "基本線種"
        Me.btnBasicLine.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCrossSet)
        Me.GroupBox1.Controls.Add(Me.btnDoubleSet)
        Me.GroupBox1.Controls.Add(Me.btnBrokenSet)
        Me.GroupBox1.Controls.Add(Me.btnSolidSet)
        Me.GroupBox1.Controls.Add(Me.btnEdge)
        Me.GroupBox1.Controls.Add(Me.cbCrossLine)
        Me.GroupBox1.Controls.Add(Me.cbDoubleLine)
        Me.GroupBox1.Controls.Add(Me.rbBlancLine)
        Me.GroupBox1.Controls.Add(Me.rbBrokenLine)
        Me.GroupBox1.Controls.Add(Me.rbSolidLine)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(224, 222)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "スタイル"
        '
        'btnCrossSet
        '
        Me.btnCrossSet.Location = New System.Drawing.Point(142, 153)
        Me.btnCrossSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCrossSet.Name = "btnCrossSet"
        Me.btnCrossSet.Size = New System.Drawing.Size(77, 22)
        Me.btnCrossSet.TabIndex = 9
        Me.btnCrossSet.Text = "交差線設定"
        Me.btnCrossSet.UseVisualStyleBackColor = True
        '
        'btnDoubleSet
        '
        Me.btnDoubleSet.Location = New System.Drawing.Point(142, 119)
        Me.btnDoubleSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDoubleSet.Name = "btnDoubleSet"
        Me.btnDoubleSet.Size = New System.Drawing.Size(77, 22)
        Me.btnDoubleSet.TabIndex = 8
        Me.btnDoubleSet.Text = "二重線設定"
        Me.btnDoubleSet.UseVisualStyleBackColor = True
        '
        'btnBrokenSet
        '
        Me.btnBrokenSet.Location = New System.Drawing.Point(85, 59)
        Me.btnBrokenSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBrokenSet.Name = "btnBrokenSet"
        Me.btnBrokenSet.Size = New System.Drawing.Size(77, 22)
        Me.btnBrokenSet.TabIndex = 7
        Me.btnBrokenSet.Text = "破線設定"
        Me.btnBrokenSet.UseVisualStyleBackColor = True
        '
        'btnSolidSet
        '
        Me.btnSolidSet.Location = New System.Drawing.Point(85, 22)
        Me.btnSolidSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSolidSet.Name = "btnSolidSet"
        Me.btnSolidSet.Size = New System.Drawing.Size(77, 22)
        Me.btnSolidSet.TabIndex = 6
        Me.btnSolidSet.Text = "実線設定"
        Me.btnSolidSet.UseVisualStyleBackColor = True
        '
        'btnEdge
        '
        Me.btnEdge.Location = New System.Drawing.Point(20, 190)
        Me.btnEdge.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEdge.Name = "btnEdge"
        Me.btnEdge.Size = New System.Drawing.Size(142, 21)
        Me.btnEdge.TabIndex = 5
        Me.btnEdge.Text = "線端・中間点接合設定"
        Me.btnEdge.UseVisualStyleBackColor = True
        '
        'cbCrossLine
        '
        Me.cbCrossLine.AutoSize = True
        Me.cbCrossLine.Location = New System.Drawing.Point(20, 157)
        Me.cbCrossLine.Margin = New System.Windows.Forms.Padding(2)
        Me.cbCrossLine.Name = "cbCrossLine"
        Me.cbCrossLine.Size = New System.Drawing.Size(123, 16)
        Me.cbCrossLine.TabIndex = 4
        Me.cbCrossLine.Text = "交差線・記号を表示"
        Me.cbCrossLine.UseVisualStyleBackColor = True
        '
        'cbDoubleLine
        '
        Me.cbDoubleLine.AutoSize = True
        Me.cbDoubleLine.Location = New System.Drawing.Point(20, 123)
        Me.cbDoubleLine.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDoubleLine.Name = "cbDoubleLine"
        Me.cbDoubleLine.Size = New System.Drawing.Size(88, 16)
        Me.cbDoubleLine.TabIndex = 3
        Me.cbDoubleLine.Text = "二重線にする"
        Me.cbDoubleLine.UseVisualStyleBackColor = True
        '
        'rbBlancLine
        '
        Me.rbBlancLine.AutoSize = True
        Me.rbBlancLine.Location = New System.Drawing.Point(20, 90)
        Me.rbBlancLine.Margin = New System.Windows.Forms.Padding(2)
        Me.rbBlancLine.Name = "rbBlancLine"
        Me.rbBlancLine.Size = New System.Drawing.Size(47, 16)
        Me.rbBlancLine.TabIndex = 2
        Me.rbBlancLine.TabStop = True
        Me.rbBlancLine.Text = "透明"
        Me.rbBlancLine.UseVisualStyleBackColor = True
        '
        'rbBrokenLine
        '
        Me.rbBrokenLine.AutoSize = True
        Me.rbBrokenLine.Location = New System.Drawing.Point(20, 59)
        Me.rbBrokenLine.Margin = New System.Windows.Forms.Padding(2)
        Me.rbBrokenLine.Name = "rbBrokenLine"
        Me.rbBrokenLine.Size = New System.Drawing.Size(47, 16)
        Me.rbBrokenLine.TabIndex = 1
        Me.rbBrokenLine.TabStop = True
        Me.rbBrokenLine.Text = "破線"
        Me.rbBrokenLine.UseVisualStyleBackColor = True
        '
        'rbSolidLine
        '
        Me.rbSolidLine.AutoSize = True
        Me.rbSolidLine.Location = New System.Drawing.Point(20, 25)
        Me.rbSolidLine.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSolidLine.Name = "rbSolidLine"
        Me.rbSolidLine.Size = New System.Drawing.Size(47, 16)
        Me.rbSolidLine.TabIndex = 0
        Me.rbSolidLine.TabStop = True
        Me.rbSolidLine.Text = "実線"
        Me.rbSolidLine.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.picSample)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 236)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(146, 47)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "描画サンプル"
        '
        'picSample
        '
        Me.picSample.BackColor = System.Drawing.Color.White
        Me.picSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSample.Location = New System.Drawing.Point(14, 18)
        Me.picSample.Margin = New System.Windows.Forms.Padding(2)
        Me.picSample.Name = "picSample"
        Me.picSample.Size = New System.Drawing.Size(121, 24)
        Me.picSample.TabIndex = 0
        Me.picSample.TabStop = False
        '
        'frmMakeLinePattern
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(240, 327)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnBasicLine)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMakeLinePattern"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ラインパターン設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.picSample, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnBasicLine As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCrossSet As System.Windows.Forms.Button
    Friend WithEvents btnDoubleSet As System.Windows.Forms.Button
    Friend WithEvents btnBrokenSet As System.Windows.Forms.Button
    Friend WithEvents btnSolidSet As System.Windows.Forms.Button
    Friend WithEvents btnEdge As System.Windows.Forms.Button
    Friend WithEvents cbCrossLine As System.Windows.Forms.CheckBox
    Friend WithEvents cbDoubleLine As System.Windows.Forms.CheckBox
    Friend WithEvents rbBlancLine As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrokenLine As System.Windows.Forms.RadioButton
    Friend WithEvents rbSolidLine As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents picSample As System.Windows.Forms.PictureBox
End Class
