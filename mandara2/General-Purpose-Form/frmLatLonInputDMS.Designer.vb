<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLatLonInputDMS
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlEastWest = New System.Windows.Forms.Panel()
        Me.rbEast = New System.Windows.Forms.RadioButton()
        Me.rbWest = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtLonSecond = New mandara10.TextNumberBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLonMinute = New mandara10.TextNumberBox()
        Me.txtLonDegree = New mandara10.TextNumberBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlNorthSouth = New System.Windows.Forms.Panel()
        Me.rbNorth = New System.Windows.Forms.RadioButton()
        Me.rbSouth = New System.Windows.Forms.RadioButton()
        Me.txtLatDegree = New mandara10.TextNumberBox()
        Me.txtLatSecond = New mandara10.TextNumberBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLatMinute = New mandara10.TextNumberBox()
        Me.lblYdegree = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.pnlEastWest.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlNorthSouth.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pnlEastWest)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(295, 128)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        '
        'pnlEastWest
        '
        Me.pnlEastWest.Controls.Add(Me.rbEast)
        Me.pnlEastWest.Controls.Add(Me.rbWest)
        Me.pnlEastWest.Location = New System.Drawing.Point(42, 70)
        Me.pnlEastWest.Name = "pnlEastWest"
        Me.pnlEastWest.Size = New System.Drawing.Size(50, 43)
        Me.pnlEastWest.TabIndex = 38
        '
        'rbEast
        '
        Me.rbEast.AutoSize = True
        Me.rbEast.Location = New System.Drawing.Point(3, 3)
        Me.rbEast.Name = "rbEast"
        Me.rbEast.Size = New System.Drawing.Size(47, 16)
        Me.rbEast.TabIndex = 25
        Me.rbEast.TabStop = True
        Me.rbEast.Text = "東経"
        Me.rbEast.UseVisualStyleBackColor = True
        '
        'rbWest
        '
        Me.rbWest.AutoSize = True
        Me.rbWest.Location = New System.Drawing.Point(3, 24)
        Me.rbWest.Name = "rbWest"
        Me.rbWest.Size = New System.Drawing.Size(47, 16)
        Me.rbWest.TabIndex = 27
        Me.rbWest.TabStop = True
        Me.rbWest.Text = "西経"
        Me.rbWest.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtLonSecond)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtLonMinute)
        Me.Panel2.Controls.Add(Me.txtLonDegree)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(6, 70)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(284, 46)
        Me.Panel2.TabIndex = 27
        '
        'txtLonSecond
        '
        Me.txtLonSecond.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLonSecond.Location = New System.Drawing.Point(220, 10)
        Me.txtLonSecond.MaxValue = 60.0R
        Me.txtLonSecond.MaxValueFlag = True
        Me.txtLonSecond.MinValue = 0.0R
        Me.txtLonSecond.MinValueFlag = True
        Me.txtLonSecond.Name = "txtLonSecond"
        Me.txtLonSecond.NumberPoint = True
        Me.txtLonSecond.Size = New System.Drawing.Size(34, 19)
        Me.txtLonSecond.TabIndex = 37
        Me.txtLonSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLonSecond.ValueErrorMessageFlag = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(259, 17)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "秒"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(203, 17)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "分"
        '
        'txtLonMinute
        '
        Me.txtLonMinute.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLonMinute.Location = New System.Drawing.Point(171, 10)
        Me.txtLonMinute.MaxValue = 60.0R
        Me.txtLonMinute.MaxValueFlag = True
        Me.txtLonMinute.MinValue = 0.0R
        Me.txtLonMinute.MinValueFlag = True
        Me.txtLonMinute.Name = "txtLonMinute"
        Me.txtLonMinute.NumberPoint = False
        Me.txtLonMinute.Size = New System.Drawing.Size(30, 19)
        Me.txtLonMinute.TabIndex = 34
        Me.txtLonMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLonMinute.ValueErrorMessageFlag = True
        '
        'txtLonDegree
        '
        Me.txtLonDegree.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLonDegree.Location = New System.Drawing.Point(92, 10)
        Me.txtLonDegree.MaxValue = 180.0R
        Me.txtLonDegree.MaxValueFlag = True
        Me.txtLonDegree.MinValue = 0.0R
        Me.txtLonDegree.MinValueFlag = True
        Me.txtLonDegree.Name = "txtLonDegree"
        Me.txtLonDegree.NumberPoint = False
        Me.txtLonDegree.Size = New System.Drawing.Size(44, 19)
        Me.txtLonDegree.TabIndex = 29
        Me.txtLonDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLonDegree.ValueErrorMessageFlag = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(146, 17)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "度"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "経度"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlNorthSouth)
        Me.Panel1.Controls.Add(Me.txtLatDegree)
        Me.Panel1.Controls.Add(Me.txtLatSecond)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtLatMinute)
        Me.Panel1.Controls.Add(Me.lblYdegree)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(6, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 46)
        Me.Panel1.TabIndex = 26
        '
        'pnlNorthSouth
        '
        Me.pnlNorthSouth.Controls.Add(Me.rbNorth)
        Me.pnlNorthSouth.Controls.Add(Me.rbSouth)
        Me.pnlNorthSouth.Location = New System.Drawing.Point(36, 4)
        Me.pnlNorthSouth.Name = "pnlNorthSouth"
        Me.pnlNorthSouth.Size = New System.Drawing.Size(50, 36)
        Me.pnlNorthSouth.TabIndex = 34
        '
        'rbNorth
        '
        Me.rbNorth.AutoSize = True
        Me.rbNorth.Location = New System.Drawing.Point(3, -1)
        Me.rbNorth.Name = "rbNorth"
        Me.rbNorth.Size = New System.Drawing.Size(47, 16)
        Me.rbNorth.TabIndex = 25
        Me.rbNorth.TabStop = True
        Me.rbNorth.Text = "北緯"
        Me.rbNorth.UseVisualStyleBackColor = True
        '
        'rbSouth
        '
        Me.rbSouth.AutoSize = True
        Me.rbSouth.Location = New System.Drawing.Point(3, 21)
        Me.rbSouth.Name = "rbSouth"
        Me.rbSouth.Size = New System.Drawing.Size(47, 16)
        Me.rbSouth.TabIndex = 27
        Me.rbSouth.TabStop = True
        Me.rbSouth.Text = "南緯"
        Me.rbSouth.UseVisualStyleBackColor = True
        '
        'txtLatDegree
        '
        Me.txtLatDegree.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLatDegree.Location = New System.Drawing.Point(91, 8)
        Me.txtLatDegree.MaxValue = 180.0R
        Me.txtLatDegree.MaxValueFlag = True
        Me.txtLatDegree.MinValue = 0.0R
        Me.txtLatDegree.MinValueFlag = True
        Me.txtLatDegree.Name = "txtLatDegree"
        Me.txtLatDegree.NumberPoint = False
        Me.txtLatDegree.Size = New System.Drawing.Size(44, 19)
        Me.txtLatDegree.TabIndex = 29
        Me.txtLatDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLatDegree.ValueErrorMessageFlag = True
        '
        'txtLatSecond
        '
        Me.txtLatSecond.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLatSecond.Location = New System.Drawing.Point(220, 8)
        Me.txtLatSecond.MaxValue = 60.0R
        Me.txtLatSecond.MaxValueFlag = True
        Me.txtLatSecond.MinValue = 0.0R
        Me.txtLatSecond.MinValueFlag = True
        Me.txtLatSecond.Name = "txtLatSecond"
        Me.txtLatSecond.NumberPoint = True
        Me.txtLatSecond.Size = New System.Drawing.Size(34, 19)
        Me.txtLatSecond.TabIndex = 33
        Me.txtLatSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLatSecond.ValueErrorMessageFlag = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(259, 15)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "秒"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(203, 15)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "分"
        '
        'txtLatMinute
        '
        Me.txtLatMinute.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLatMinute.Location = New System.Drawing.Point(171, 8)
        Me.txtLatMinute.MaxValue = 60.0R
        Me.txtLatMinute.MaxValueFlag = True
        Me.txtLatMinute.MinValue = 0.0R
        Me.txtLatMinute.MinValueFlag = True
        Me.txtLatMinute.Name = "txtLatMinute"
        Me.txtLatMinute.NumberPoint = False
        Me.txtLatMinute.Size = New System.Drawing.Size(30, 19)
        Me.txtLatMinute.TabIndex = 30
        Me.txtLatMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLatMinute.ValueErrorMessageFlag = True
        '
        'lblYdegree
        '
        Me.lblYdegree.AutoSize = True
        Me.lblYdegree.Location = New System.Drawing.Point(146, 15)
        Me.lblYdegree.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblYdegree.Name = "lblYdegree"
        Me.lblYdegree.Size = New System.Drawing.Size(17, 12)
        Me.lblYdegree.TabIndex = 28
        Me.lblYdegree.Text = "度"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 13)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "緯度"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(238, 146)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 21)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(164, 146)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 21)
        Me.btnOK.TabIndex = 26
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmLatLonInputDMS
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(316, 178)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLatLonInputDMS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "緯度経度入力"
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlEastWest.ResumeLayout(False)
        Me.pnlEastWest.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlNorthSouth.ResumeLayout(False)
        Me.pnlNorthSouth.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtLonDegree As mandara10.TextNumberBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbWest As System.Windows.Forms.RadioButton
    Friend WithEvents rbEast As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtLatDegree As mandara10.TextNumberBox
    Friend WithEvents lblYdegree As System.Windows.Forms.Label
    Friend WithEvents rbSouth As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbNorth As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtLatMinute As mandara10.TextNumberBox
    Friend WithEvents txtLonSecond As mandara10.TextNumberBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLonMinute As mandara10.TextNumberBox
    Friend WithEvents txtLatSecond As mandara10.TextNumberBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlEastWest As System.Windows.Forms.Panel
    Friend WithEvents pnlNorthSouth As System.Windows.Forms.Panel
End Class
