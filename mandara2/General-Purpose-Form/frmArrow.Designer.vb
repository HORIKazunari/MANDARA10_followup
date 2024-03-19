<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArrow
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
        Me.cbArrowStart = New System.Windows.Forms.CheckBox()
        Me.cbArrowEnd = New System.Windows.Forms.CheckBox()
        Me.gbArrowHeadType = New System.Windows.Forms.GroupBox()
        Me.picFill = New System.Windows.Forms.PictureBox()
        Me.picLine = New System.Windows.Forms.PictureBox()
        Me.rbFill = New System.Windows.Forms.RadioButton()
        Me.rbLine = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAngle = New mandara10.TextNumberBox()
        Me.txtLineWidth1 = New mandara10.TextNumberBox()
        Me.txtLineWidth2 = New mandara10.TextNumberBox()
        Me.gbArrowHeadType.SuspendLayout()
        CType(Me.picFill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(249, 160)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(316, 160)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cbArrowStart
        '
        Me.cbArrowStart.AutoSize = True
        Me.cbArrowStart.Location = New System.Drawing.Point(16, 13)
        Me.cbArrowStart.Name = "cbArrowStart"
        Me.cbArrowStart.Size = New System.Drawing.Size(72, 16)
        Me.cbArrowStart.TabIndex = 0
        Me.cbArrowStart.Text = "始点矢印"
        Me.cbArrowStart.UseVisualStyleBackColor = True
        '
        'cbArrowEnd
        '
        Me.cbArrowEnd.AutoSize = True
        Me.cbArrowEnd.Location = New System.Drawing.Point(106, 13)
        Me.cbArrowEnd.Name = "cbArrowEnd"
        Me.cbArrowEnd.Size = New System.Drawing.Size(72, 16)
        Me.cbArrowEnd.TabIndex = 1
        Me.cbArrowEnd.Text = "終点矢印"
        Me.cbArrowEnd.UseVisualStyleBackColor = True
        '
        'gbArrowHeadType
        '
        Me.gbArrowHeadType.Controls.Add(Me.picFill)
        Me.gbArrowHeadType.Controls.Add(Me.picLine)
        Me.gbArrowHeadType.Controls.Add(Me.rbFill)
        Me.gbArrowHeadType.Controls.Add(Me.rbLine)
        Me.gbArrowHeadType.Location = New System.Drawing.Point(16, 49)
        Me.gbArrowHeadType.Name = "gbArrowHeadType"
        Me.gbArrowHeadType.Size = New System.Drawing.Size(126, 106)
        Me.gbArrowHeadType.TabIndex = 2
        Me.gbArrowHeadType.TabStop = False
        Me.gbArrowHeadType.Text = "形状"
        '
        'picFill
        '
        Me.picFill.BackColor = System.Drawing.Color.White
        Me.picFill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picFill.Location = New System.Drawing.Point(40, 62)
        Me.picFill.Name = "picFill"
        Me.picFill.Size = New System.Drawing.Size(72, 28)
        Me.picFill.TabIndex = 3
        Me.picFill.TabStop = False
        '
        'picLine
        '
        Me.picLine.BackColor = System.Drawing.Color.White
        Me.picLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLine.Location = New System.Drawing.Point(40, 28)
        Me.picLine.Name = "picLine"
        Me.picLine.Size = New System.Drawing.Size(72, 28)
        Me.picLine.TabIndex = 2
        Me.picLine.TabStop = False
        '
        'rbFill
        '
        Me.rbFill.AutoSize = True
        Me.rbFill.Location = New System.Drawing.Point(15, 69)
        Me.rbFill.Name = "rbFill"
        Me.rbFill.Size = New System.Drawing.Size(14, 13)
        Me.rbFill.TabIndex = 1
        Me.rbFill.TabStop = True
        Me.rbFill.UseVisualStyleBackColor = True
        '
        'rbLine
        '
        Me.rbLine.AutoSize = True
        Me.rbLine.Location = New System.Drawing.Point(15, 31)
        Me.rbLine.Name = "rbLine"
        Me.rbLine.Size = New System.Drawing.Size(14, 13)
        Me.rbLine.TabIndex = 0
        Me.rbLine.TabStop = True
        Me.rbLine.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLineWidth2)
        Me.GroupBox1.Controls.Add(Me.txtLineWidth1)
        Me.GroupBox1.Controls.Add(Me.txtAngle)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(159, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(223, 108)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "角度・大きさ"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(134, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "＋"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "線幅×"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(111, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "度"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "矢の最大幅(%)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "角度"
        '
        'txtAngle
        '
        Me.txtAngle.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtAngle.Location = New System.Drawing.Point(58, 27)
        Me.txtAngle.MaxValue = 255.0R
        Me.txtAngle.MaxValueFlag = True
        Me.txtAngle.MinValue = 0.0R
        Me.txtAngle.MinValueFlag = True
        Me.txtAngle.Name = "txtAngle"
        Me.txtAngle.NumberPoint = True
        Me.txtAngle.Size = New System.Drawing.Size(50, 19)
        Me.txtAngle.TabIndex = 26
        Me.txtAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAngle.ValueErrorMessageFlag = False
        '
        'txtLineWidth1
        '
        Me.txtLineWidth1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLineWidth1.Location = New System.Drawing.Point(79, 77)
        Me.txtLineWidth1.MaxValue = 255.0R
        Me.txtLineWidth1.MaxValueFlag = True
        Me.txtLineWidth1.MinValue = 0.0R
        Me.txtLineWidth1.MinValueFlag = True
        Me.txtLineWidth1.Name = "txtLineWidth1"
        Me.txtLineWidth1.NumberPoint = True
        Me.txtLineWidth1.Size = New System.Drawing.Size(50, 19)
        Me.txtLineWidth1.TabIndex = 27
        Me.txtLineWidth1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLineWidth1.ValueErrorMessageFlag = False
        '
        'txtLineWidth2
        '
        Me.txtLineWidth2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLineWidth2.Location = New System.Drawing.Point(157, 77)
        Me.txtLineWidth2.MaxValue = 255.0R
        Me.txtLineWidth2.MaxValueFlag = True
        Me.txtLineWidth2.MinValue = 0.0R
        Me.txtLineWidth2.MinValueFlag = True
        Me.txtLineWidth2.Name = "txtLineWidth2"
        Me.txtLineWidth2.NumberPoint = True
        Me.txtLineWidth2.Size = New System.Drawing.Size(50, 19)
        Me.txtLineWidth2.TabIndex = 28
        Me.txtLineWidth2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLineWidth2.ValueErrorMessageFlag = False
        '
        'frmArrow
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(396, 194)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbArrowHeadType)
        Me.Controls.Add(Me.cbArrowEnd)
        Me.Controls.Add(Me.cbArrowStart)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmArrow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "矢印設定"
        Me.gbArrowHeadType.ResumeLayout(False)
        Me.gbArrowHeadType.PerformLayout()
        CType(Me.picFill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cbArrowStart As System.Windows.Forms.CheckBox
    Friend WithEvents cbArrowEnd As System.Windows.Forms.CheckBox
    Friend WithEvents gbArrowHeadType As System.Windows.Forms.GroupBox
    Friend WithEvents picFill As System.Windows.Forms.PictureBox
    Friend WithEvents picLine As System.Windows.Forms.PictureBox
    Friend WithEvents rbFill As System.Windows.Forms.RadioButton
    Friend WithEvents rbLine As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAngle As mandara10.TextNumberBox
    Friend WithEvents txtLineWidth2 As mandara10.TextNumberBox
    Friend WithEvents txtLineWidth1 As mandara10.TextNumberBox
End Class
