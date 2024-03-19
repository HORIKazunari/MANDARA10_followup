<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_makeMesh
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbMesh1_10 = New System.Windows.Forms.RadioButton()
        Me.rbMesh1_8 = New System.Windows.Forms.RadioButton()
        Me.rbMesh1_4 = New System.Windows.Forms.RadioButton()
        Me.rbMesh1_2 = New System.Windows.Forms.RadioButton()
        Me.rbMesh3 = New System.Windows.Forms.RadioButton()
        Me.rbMesh2 = New System.Windows.Forms.RadioButton()
        Me.rbMesh1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbPoint = New System.Windows.Forms.RadioButton()
        Me.rbRect = New System.Windows.Forms.RadioButton()
        Me.rbPolygon = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbMethodClipboard = New System.Windows.Forms.RadioButton()
        Me.rbMethodAllArea = New System.Windows.Forms.RadioButton()
        Me.rbMethodPolygonIn = New System.Windows.Forms.RadioButton()
        Me.ProgressLabel = New KTGISUserControl.KTGISProgressLabel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(320, 214)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(245, 214)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbMesh1_10)
        Me.GroupBox1.Controls.Add(Me.rbMesh1_8)
        Me.GroupBox1.Controls.Add(Me.rbMesh1_4)
        Me.GroupBox1.Controls.Add(Me.rbMesh1_2)
        Me.GroupBox1.Controls.Add(Me.rbMesh3)
        Me.GroupBox1.Controls.Add(Me.rbMesh2)
        Me.GroupBox1.Controls.Add(Me.rbMesh1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(143, 193)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "メッシュの種類"
        '
        'rbMesh1_10
        '
        Me.rbMesh1_10.AutoSize = True
        Me.rbMesh1_10.Location = New System.Drawing.Point(16, 162)
        Me.rbMesh1_10.Name = "rbMesh1_10"
        Me.rbMesh1_10.Size = New System.Drawing.Size(80, 16)
        Me.rbMesh1_10.TabIndex = 6
        Me.rbMesh1_10.Text = "1/10メッシュ"
        Me.rbMesh1_10.UseVisualStyleBackColor = True
        '
        'rbMesh1_8
        '
        Me.rbMesh1_8.AutoSize = True
        Me.rbMesh1_8.Location = New System.Drawing.Point(16, 140)
        Me.rbMesh1_8.Name = "rbMesh1_8"
        Me.rbMesh1_8.Size = New System.Drawing.Size(74, 16)
        Me.rbMesh1_8.TabIndex = 5
        Me.rbMesh1_8.Text = "1/8メッシュ"
        Me.rbMesh1_8.UseVisualStyleBackColor = True
        '
        'rbMesh1_4
        '
        Me.rbMesh1_4.AutoSize = True
        Me.rbMesh1_4.Location = New System.Drawing.Point(16, 118)
        Me.rbMesh1_4.Name = "rbMesh1_4"
        Me.rbMesh1_4.Size = New System.Drawing.Size(74, 16)
        Me.rbMesh1_4.TabIndex = 4
        Me.rbMesh1_4.Text = "1/4メッシュ"
        Me.rbMesh1_4.UseVisualStyleBackColor = True
        '
        'rbMesh1_2
        '
        Me.rbMesh1_2.AutoSize = True
        Me.rbMesh1_2.Location = New System.Drawing.Point(16, 96)
        Me.rbMesh1_2.Name = "rbMesh1_2"
        Me.rbMesh1_2.Size = New System.Drawing.Size(74, 16)
        Me.rbMesh1_2.TabIndex = 3
        Me.rbMesh1_2.Text = "1/2メッシュ"
        Me.rbMesh1_2.UseVisualStyleBackColor = True
        '
        'rbMesh3
        '
        Me.rbMesh3.AutoSize = True
        Me.rbMesh3.Checked = True
        Me.rbMesh3.Location = New System.Drawing.Point(16, 74)
        Me.rbMesh3.Name = "rbMesh3"
        Me.rbMesh3.Size = New System.Drawing.Size(74, 16)
        Me.rbMesh3.TabIndex = 2
        Me.rbMesh3.TabStop = True
        Me.rbMesh3.Text = "3次メッシュ"
        Me.rbMesh3.UseVisualStyleBackColor = True
        '
        'rbMesh2
        '
        Me.rbMesh2.AutoSize = True
        Me.rbMesh2.Location = New System.Drawing.Point(16, 52)
        Me.rbMesh2.Name = "rbMesh2"
        Me.rbMesh2.Size = New System.Drawing.Size(74, 16)
        Me.rbMesh2.TabIndex = 1
        Me.rbMesh2.Text = "2次メッシュ"
        Me.rbMesh2.UseVisualStyleBackColor = True
        '
        'rbMesh1
        '
        Me.rbMesh1.AutoSize = True
        Me.rbMesh1.Location = New System.Drawing.Point(16, 30)
        Me.rbMesh1.Name = "rbMesh1"
        Me.rbMesh1.Size = New System.Drawing.Size(74, 16)
        Me.rbMesh1.TabIndex = 0
        Me.rbMesh1.Text = "1次メッシュ"
        Me.rbMesh1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbPoint)
        Me.GroupBox2.Controls.Add(Me.rbRect)
        Me.GroupBox2.Controls.Add(Me.rbPolygon)
        Me.GroupBox2.Location = New System.Drawing.Point(166, 101)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(226, 101)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "オブジェクトの形状"
        '
        'rbPoint
        '
        Me.rbPoint.AutoSize = True
        Me.rbPoint.Location = New System.Drawing.Point(12, 74)
        Me.rbPoint.Name = "rbPoint"
        Me.rbPoint.Size = New System.Drawing.Size(59, 16)
        Me.rbPoint.TabIndex = 3
        Me.rbPoint.Text = "点形状"
        Me.rbPoint.UseVisualStyleBackColor = True
        '
        'rbRect
        '
        Me.rbRect.AutoSize = True
        Me.rbRect.Location = New System.Drawing.Point(12, 52)
        Me.rbRect.Name = "rbRect"
        Me.rbRect.Size = New System.Drawing.Size(138, 16)
        Me.rbRect.TabIndex = 2
        Me.rbRect.Text = "面形状（位相構造なし）"
        Me.rbRect.UseVisualStyleBackColor = True
        '
        'rbPolygon
        '
        Me.rbPolygon.AutoSize = True
        Me.rbPolygon.Checked = True
        Me.rbPolygon.Location = New System.Drawing.Point(12, 30)
        Me.rbPolygon.Name = "rbPolygon"
        Me.rbPolygon.Size = New System.Drawing.Size(119, 16)
        Me.rbPolygon.TabIndex = 1
        Me.rbPolygon.TabStop = True
        Me.rbPolygon.Text = "面形状（位相構造）"
        Me.rbPolygon.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbMethodClipboard)
        Me.GroupBox3.Controls.Add(Me.rbMethodAllArea)
        Me.GroupBox3.Controls.Add(Me.rbMethodPolygonIn)
        Me.GroupBox3.Location = New System.Drawing.Point(166, 10)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(226, 85)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "作成方法"
        '
        'rbMethodClipboard
        '
        Me.rbMethodClipboard.AutoSize = True
        Me.rbMethodClipboard.Location = New System.Drawing.Point(6, 62)
        Me.rbMethodClipboard.Name = "rbMethodClipboard"
        Me.rbMethodClipboard.Size = New System.Drawing.Size(163, 16)
        Me.rbMethodClipboard.TabIndex = 2
        Me.rbMethodClipboard.TabStop = True
        Me.rbMethodClipboard.Text = "クリップボードのデータから作成"
        Me.rbMethodClipboard.UseVisualStyleBackColor = True
        '
        'rbMethodAllArea
        '
        Me.rbMethodAllArea.AutoSize = True
        Me.rbMethodAllArea.Location = New System.Drawing.Point(6, 40)
        Me.rbMethodAllArea.Name = "rbMethodAllArea"
        Me.rbMethodAllArea.Size = New System.Drawing.Size(162, 16)
        Me.rbMethodAllArea.TabIndex = 1
        Me.rbMethodAllArea.TabStop = True
        Me.rbMethodAllArea.Text = "編集対象の領域全体に作成"
        Me.rbMethodAllArea.UseVisualStyleBackColor = True
        '
        'rbMethodPolygonIn
        '
        Me.rbMethodPolygonIn.AutoSize = True
        Me.rbMethodPolygonIn.Checked = True
        Me.rbMethodPolygonIn.Location = New System.Drawing.Point(6, 18)
        Me.rbMethodPolygonIn.Name = "rbMethodPolygonIn"
        Me.rbMethodPolygonIn.Size = New System.Drawing.Size(211, 16)
        Me.rbMethodPolygonIn.TabIndex = 0
        Me.rbMethodPolygonIn.TabStop = True
        Me.rbMethodPolygonIn.Text = "編集対象の面オブジェクトの内部に作成"
        Me.rbMethodPolygonIn.UseVisualStyleBackColor = True
        '
        'ProgressLabel
        '
        Me.ProgressLabel.LabelColor = System.Drawing.SystemColors.Control
        Me.ProgressLabel.Location = New System.Drawing.Point(11, 212)
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.Size = New System.Drawing.Size(143, 26)
        Me.ProgressLabel.TabIndex = 5
        Me.ProgressLabel.Visible = False
        '
        'frmMED_makeMesh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 250)
        Me.Controls.Add(Me.ProgressLabel)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_makeMesh"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "メッシュオブジェクト作成"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMesh1_10 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMesh1_8 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMesh1_4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMesh1_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMesh3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMesh2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMesh1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPoint As System.Windows.Forms.RadioButton
    Friend WithEvents rbRect As System.Windows.Forms.RadioButton
    Friend WithEvents rbPolygon As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMethodClipboard As System.Windows.Forms.RadioButton
    Friend WithEvents rbMethodAllArea As System.Windows.Forms.RadioButton
    Friend WithEvents rbMethodPolygonIn As System.Windows.Forms.RadioButton
    Friend WithEvents ProgressLabel As KTGISUserControl.KTGISProgressLabel
End Class
