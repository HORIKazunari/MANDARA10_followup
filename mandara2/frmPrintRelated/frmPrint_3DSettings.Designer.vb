<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_3DSettings
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtExpansion = New mandara10.TextNumberBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.HScrollBarY = New System.Windows.Forms.HScrollBar()
        Me.txtTurnZ = New mandara10.TextNumberBox()
        Me.txtTurnY = New mandara10.TextNumberBox()
        Me.txtTurnX = New mandara10.TextNumberBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.HScrollBarEx = New System.Windows.Forms.HScrollBar()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.HScrollBarZ = New System.Windows.Forms.HScrollBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.HScrollBarX = New System.Windows.Forms.HScrollBar()
        Me.PanelPic = New System.Windows.Forms.Panel()
        Me.pic3D = New System.Windows.Forms.PictureBox()
        Me.btnRedraw = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelPic.SuspendLayout()
        CType(Me.pic3D, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "X軸回転"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 57)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Y軸回転"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 87)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Z軸回転"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 134)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "拡大率"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtExpansion)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.txtTurnZ)
        Me.GroupBox1.Controls.Add(Me.txtTurnY)
        Me.GroupBox1.Controls.Add(Me.txtTurnX)
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(279, 162)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "角度設定"
        '
        'txtExpansion
        '
        Me.txtExpansion.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtExpansion.Location = New System.Drawing.Point(71, 131)
        Me.txtExpansion.MaxValue = 300.0R
        Me.txtExpansion.MaxValueFlag = True
        Me.txtExpansion.MinValue = 0.0R
        Me.txtExpansion.MinValueFlag = True
        Me.txtExpansion.Name = "txtExpansion"
        Me.txtExpansion.NumberPoint = False
        Me.txtExpansion.Size = New System.Drawing.Size(50, 19)
        Me.txtExpansion.TabIndex = 16
        Me.txtExpansion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtExpansion.ValueErrorMessageFlag = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.HScrollBarY)
        Me.Panel3.Location = New System.Drawing.Point(131, 54)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(142, 18)
        Me.Panel3.TabIndex = 10
        '
        'HScrollBarY
        '
        Me.HScrollBarY.LargeChange = 1
        Me.HScrollBarY.Location = New System.Drawing.Point(11, 0)
        Me.HScrollBarY.Maximum = 360
        Me.HScrollBarY.Minimum = -360
        Me.HScrollBarY.Name = "HScrollBarY"
        Me.HScrollBarY.Size = New System.Drawing.Size(121, 18)
        Me.HScrollBarY.TabIndex = 0
        Me.HScrollBarY.Value = -72
        '
        'txtTurnZ
        '
        Me.txtTurnZ.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTurnZ.Location = New System.Drawing.Point(71, 84)
        Me.txtTurnZ.MaxValue = 360.0R
        Me.txtTurnZ.MaxValueFlag = True
        Me.txtTurnZ.MinValue = -360.0R
        Me.txtTurnZ.MinValueFlag = True
        Me.txtTurnZ.Name = "txtTurnZ"
        Me.txtTurnZ.NumberPoint = False
        Me.txtTurnZ.Size = New System.Drawing.Size(50, 19)
        Me.txtTurnZ.TabIndex = 15
        Me.txtTurnZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTurnZ.ValueErrorMessageFlag = False
        '
        'txtTurnY
        '
        Me.txtTurnY.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTurnY.Location = New System.Drawing.Point(71, 54)
        Me.txtTurnY.MaxValue = 360.0R
        Me.txtTurnY.MaxValueFlag = True
        Me.txtTurnY.MinValue = -360.0R
        Me.txtTurnY.MinValueFlag = True
        Me.txtTurnY.Name = "txtTurnY"
        Me.txtTurnY.NumberPoint = False
        Me.txtTurnY.Size = New System.Drawing.Size(50, 19)
        Me.txtTurnY.TabIndex = 14
        Me.txtTurnY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTurnY.ValueErrorMessageFlag = False
        '
        'txtTurnX
        '
        Me.txtTurnX.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTurnX.Location = New System.Drawing.Point(70, 24)
        Me.txtTurnX.MaxValue = 360.0R
        Me.txtTurnX.MaxValueFlag = True
        Me.txtTurnX.MinValue = -360.0R
        Me.txtTurnX.MinValueFlag = True
        Me.txtTurnX.Name = "txtTurnX"
        Me.txtTurnX.NumberPoint = False
        Me.txtTurnX.Size = New System.Drawing.Size(50, 19)
        Me.txtTurnX.TabIndex = 13
        Me.txtTurnX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTurnX.ValueErrorMessageFlag = False
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.HScrollBarEx)
        Me.Panel5.Location = New System.Drawing.Point(131, 132)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(142, 18)
        Me.Panel5.TabIndex = 12
        '
        'HScrollBarEx
        '
        Me.HScrollBarEx.LargeChange = 1
        Me.HScrollBarEx.Location = New System.Drawing.Point(11, 0)
        Me.HScrollBarEx.Maximum = 300
        Me.HScrollBarEx.Name = "HScrollBarEx"
        Me.HScrollBarEx.Size = New System.Drawing.Size(121, 18)
        Me.HScrollBarEx.TabIndex = 9
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.HScrollBarZ)
        Me.Panel4.Location = New System.Drawing.Point(131, 84)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(142, 18)
        Me.Panel4.TabIndex = 11
        '
        'HScrollBarZ
        '
        Me.HScrollBarZ.LargeChange = 1
        Me.HScrollBarZ.Location = New System.Drawing.Point(11, 0)
        Me.HScrollBarZ.Maximum = 360
        Me.HScrollBarZ.Minimum = -360
        Me.HScrollBarZ.Name = "HScrollBarZ"
        Me.HScrollBarZ.Size = New System.Drawing.Size(121, 18)
        Me.HScrollBarZ.TabIndex = 9
        Me.HScrollBarZ.Value = -72
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.HScrollBarX)
        Me.Panel1.Location = New System.Drawing.Point(131, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(142, 18)
        Me.Panel1.TabIndex = 9
        '
        'HScrollBarX
        '
        Me.HScrollBarX.LargeChange = 1
        Me.HScrollBarX.Location = New System.Drawing.Point(11, 0)
        Me.HScrollBarX.Maximum = 360
        Me.HScrollBarX.Minimum = -360
        Me.HScrollBarX.Name = "HScrollBarX"
        Me.HScrollBarX.Size = New System.Drawing.Size(121, 18)
        Me.HScrollBarX.TabIndex = 0
        Me.HScrollBarX.Value = -72
        '
        'PanelPic
        '
        Me.PanelPic.Controls.Add(Me.pic3D)
        Me.PanelPic.Location = New System.Drawing.Point(297, 12)
        Me.PanelPic.Name = "PanelPic"
        Me.PanelPic.Size = New System.Drawing.Size(284, 186)
        Me.PanelPic.TabIndex = 2
        '
        'pic3D
        '
        Me.pic3D.BackColor = System.Drawing.Color.DarkGray
        Me.pic3D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pic3D.Location = New System.Drawing.Point(3, 0)
        Me.pic3D.Name = "pic3D"
        Me.pic3D.Size = New System.Drawing.Size(279, 183)
        Me.pic3D.TabIndex = 2
        Me.pic3D.TabStop = False
        '
        'btnRedraw
        '
        Me.btnRedraw.Location = New System.Drawing.Point(224, 180)
        Me.btnRedraw.Name = "btnRedraw"
        Me.btnRedraw.Size = New System.Drawing.Size(61, 25)
        Me.btnRedraw.TabIndex = 1
        Me.btnRedraw.Text = "再描画"
        Me.btnRedraw.UseVisualStyleBackColor = True
        '
        'frmPrint_3DSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 210)
        Me.Controls.Add(Me.btnRedraw)
        Me.Controls.Add(Me.PanelPic)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_3DSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "3D設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.PanelPic.ResumeLayout(False)
        CType(Me.pic3D, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents HScrollBarEx As System.Windows.Forms.HScrollBar
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents HScrollBarZ As System.Windows.Forms.HScrollBar
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents HScrollBarY As System.Windows.Forms.HScrollBar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents HScrollBarX As System.Windows.Forms.HScrollBar
    Friend WithEvents txtExpansion As mandara10.TextNumberBox
    Friend WithEvents txtTurnZ As mandara10.TextNumberBox
    Friend WithEvents txtTurnY As mandara10.TextNumberBox
    Friend WithEvents txtTurnX As mandara10.TextNumberBox
    Friend WithEvents PanelPic As System.Windows.Forms.Panel
    Friend WithEvents pic3D As System.Windows.Forms.PictureBox
    Friend WithEvents btnRedraw As System.Windows.Forms.Button
End Class
