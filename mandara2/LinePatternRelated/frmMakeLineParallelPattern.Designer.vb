<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMakeLineParallelPattern
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboPartsWidth = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbInnerCol = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picCol = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.gbCenterLinePat = New System.Windows.Forms.GroupBox()
        Me.btnBrokenSet = New System.Windows.Forms.Button()
        Me.btnSolidSet = New System.Windows.Forms.Button()
        Me.rbBrokenLine = New System.Windows.Forms.RadioButton()
        Me.rbSolidLine = New System.Windows.Forms.RadioButton()
        Me.cbCenterLinePat = New System.Windows.Forms.CheckBox()
        Me.cbCenterLine = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picCol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.gbCenterLinePat.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(215, 192)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(292, 191)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 25)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboPartsWidth)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(139, 70)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "間隔"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(101, 33)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 12)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "%"
        '
        'cboPartsWidth
        '
        Me.cboPartsWidth.FormattingEnabled = True
        Me.cboPartsWidth.Location = New System.Drawing.Point(19, 26)
        Me.cboPartsWidth.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cboPartsWidth.Name = "cboPartsWidth"
        Me.cboPartsWidth.Size = New System.Drawing.Size(79, 20)
        Me.cboPartsWidth.TabIndex = 24
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbInnerCol)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.picCol)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 91)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(137, 87)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "内部"
        '
        'cbInnerCol
        '
        Me.cbInnerCol.AutoSize = True
        Me.cbInnerCol.Location = New System.Drawing.Point(20, 19)
        Me.cbInnerCol.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbInnerCol.Name = "cbInnerCol"
        Me.cbInnerCol.Size = New System.Drawing.Size(72, 16)
        Me.cbInnerCol.TabIndex = 1
        Me.cbInnerCol.Text = "塗りつぶし"
        Me.cbInnerCol.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 49)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "内部色"
        '
        'picCol
        '
        Me.picCol.BackColor = System.Drawing.Color.Black
        Me.picCol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCol.Location = New System.Drawing.Point(68, 45)
        Me.picCol.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.picCol.Name = "picCol"
        Me.picCol.Size = New System.Drawing.Size(44, 26)
        Me.picCol.TabIndex = 24
        Me.picCol.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.gbCenterLinePat)
        Me.GroupBox3.Controls.Add(Me.cbCenterLinePat)
        Me.GroupBox3.Controls.Add(Me.cbCenterLine)
        Me.GroupBox3.Location = New System.Drawing.Point(160, 10)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(203, 169)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "中心線"
        '
        'gbCenterLinePat
        '
        Me.gbCenterLinePat.Controls.Add(Me.btnBrokenSet)
        Me.gbCenterLinePat.Controls.Add(Me.btnSolidSet)
        Me.gbCenterLinePat.Controls.Add(Me.rbBrokenLine)
        Me.gbCenterLinePat.Controls.Add(Me.rbSolidLine)
        Me.gbCenterLinePat.Location = New System.Drawing.Point(30, 80)
        Me.gbCenterLinePat.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbCenterLinePat.Name = "gbCenterLinePat"
        Me.gbCenterLinePat.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbCenterLinePat.Size = New System.Drawing.Size(163, 78)
        Me.gbCenterLinePat.TabIndex = 0
        Me.gbCenterLinePat.TabStop = False
        Me.gbCenterLinePat.Text = "線種"
        '
        'btnBrokenSet
        '
        Me.btnBrokenSet.Location = New System.Drawing.Point(62, 48)
        Me.btnBrokenSet.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnBrokenSet.Name = "btnBrokenSet"
        Me.btnBrokenSet.Size = New System.Drawing.Size(67, 22)
        Me.btnBrokenSet.TabIndex = 0
        Me.btnBrokenSet.Text = "破線設定"
        Me.btnBrokenSet.UseVisualStyleBackColor = True
        '
        'btnSolidSet
        '
        Me.btnSolidSet.Location = New System.Drawing.Point(62, 14)
        Me.btnSolidSet.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnSolidSet.Name = "btnSolidSet"
        Me.btnSolidSet.Size = New System.Drawing.Size(67, 22)
        Me.btnSolidSet.TabIndex = 1
        Me.btnSolidSet.Text = "実線設定"
        Me.btnSolidSet.UseVisualStyleBackColor = True
        '
        'rbBrokenLine
        '
        Me.rbBrokenLine.AutoSize = True
        Me.rbBrokenLine.Location = New System.Drawing.Point(7, 51)
        Me.rbBrokenLine.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rbBrokenLine.Name = "rbBrokenLine"
        Me.rbBrokenLine.Size = New System.Drawing.Size(47, 16)
        Me.rbBrokenLine.TabIndex = 2
        Me.rbBrokenLine.TabStop = True
        Me.rbBrokenLine.Text = "破線"
        Me.rbBrokenLine.UseVisualStyleBackColor = True
        '
        'rbSolidLine
        '
        Me.rbSolidLine.AutoSize = True
        Me.rbSolidLine.Location = New System.Drawing.Point(7, 17)
        Me.rbSolidLine.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rbSolidLine.Name = "rbSolidLine"
        Me.rbSolidLine.Size = New System.Drawing.Size(47, 16)
        Me.rbSolidLine.TabIndex = 0
        Me.rbSolidLine.TabStop = True
        Me.rbSolidLine.Text = "実線"
        Me.rbSolidLine.UseVisualStyleBackColor = True
        '
        'cbCenterLinePat
        '
        Me.cbCenterLinePat.AutoSize = True
        Me.cbCenterLinePat.Location = New System.Drawing.Point(30, 50)
        Me.cbCenterLinePat.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbCenterLinePat.Name = "cbCenterLinePat"
        Me.cbCenterLinePat.Size = New System.Drawing.Size(113, 16)
        Me.cbCenterLinePat.TabIndex = 1
        Me.cbCenterLinePat.Text = "平行線と同じ線種"
        Me.cbCenterLinePat.UseVisualStyleBackColor = True
        '
        'cbCenterLine
        '
        Me.cbCenterLine.AutoSize = True
        Me.cbCenterLine.Location = New System.Drawing.Point(17, 28)
        Me.cbCenterLine.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbCenterLine.Name = "cbCenterLine"
        Me.cbCenterLine.Size = New System.Drawing.Size(94, 16)
        Me.cbCenterLine.TabIndex = 0
        Me.cbCenterLine.Text = "中心線の表示"
        Me.cbCenterLine.UseVisualStyleBackColor = True
        '
        'frmMakeLineParallelPattern
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 225)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMakeLineParallelPattern"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ラインパターン／二重線設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picCol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbCenterLinePat.ResumeLayout(False)
        Me.gbCenterLinePat.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboPartsWidth As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picCol As System.Windows.Forms.PictureBox
    Friend WithEvents cbInnerCol As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents gbCenterLinePat As System.Windows.Forms.GroupBox
    Friend WithEvents cbCenterLinePat As System.Windows.Forms.CheckBox
    Friend WithEvents cbCenterLine As System.Windows.Forms.CheckBox
    Friend WithEvents btnBrokenSet As System.Windows.Forms.Button
    Friend WithEvents btnSolidSet As System.Windows.Forms.Button
    Friend WithEvents rbBrokenLine As System.Windows.Forms.RadioButton
    Friend WithEvents rbSolidLine As System.Windows.Forms.RadioButton
End Class
