<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLatLonInput10
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtLon = New mandara10.TextNumberBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbWest = New System.Windows.Forms.RadioButton()
        Me.rbEast = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtLat = New mandara10.TextNumberBox()
        Me.lblYdegree = New System.Windows.Forms.Label()
        Me.rbSouth = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbNorth = New System.Windows.Forms.RadioButton()
        Me.pnlNorthSouth = New System.Windows.Forms.Panel()
        Me.pnlEastWest = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlNorthSouth.SuspendLayout()
        Me.pnlEastWest.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(139, 144)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 21)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(64, 144)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 21)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(197, 128)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlEastWest)
        Me.Panel2.Controls.Add(Me.txtLon)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(6, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(181, 46)
        Me.Panel2.TabIndex = 1
        '
        'txtLon
        '
        Me.txtLon.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLon.Location = New System.Drawing.Point(83, 10)
        Me.txtLon.MaxValue = 180.0R
        Me.txtLon.MaxValueFlag = True
        Me.txtLon.MinValue = 0.0R
        Me.txtLon.MinValueFlag = True
        Me.txtLon.Name = "txtLon"
        Me.txtLon.NumberPoint = True
        Me.txtLon.Size = New System.Drawing.Size(65, 19)
        Me.txtLon.TabIndex = 3
        Me.txtLon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLon.ValueErrorMessageFlag = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(153, 17)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "度"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "経度"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rbWest
        '
        Me.rbWest.AutoSize = True
        Me.rbWest.Location = New System.Drawing.Point(0, 22)
        Me.rbWest.Name = "rbWest"
        Me.rbWest.Size = New System.Drawing.Size(47, 16)
        Me.rbWest.TabIndex = 1
        Me.rbWest.TabStop = True
        Me.rbWest.Text = "西経"
        Me.rbWest.UseVisualStyleBackColor = True
        '
        'rbEast
        '
        Me.rbEast.AutoSize = True
        Me.rbEast.Location = New System.Drawing.Point(0, 0)
        Me.rbEast.Name = "rbEast"
        Me.rbEast.Size = New System.Drawing.Size(47, 16)
        Me.rbEast.TabIndex = 0
        Me.rbEast.TabStop = True
        Me.rbEast.Text = "東経"
        Me.rbEast.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlNorthSouth)
        Me.Panel1.Controls.Add(Me.txtLat)
        Me.Panel1.Controls.Add(Me.lblYdegree)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(6, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(181, 46)
        Me.Panel1.TabIndex = 0
        '
        'txtLat
        '
        Me.txtLat.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLat.Location = New System.Drawing.Point(83, 12)
        Me.txtLat.MaxValue = 180.0R
        Me.txtLat.MaxValueFlag = True
        Me.txtLat.MinValue = 0.0R
        Me.txtLat.MinValueFlag = True
        Me.txtLat.Name = "txtLat"
        Me.txtLat.NumberPoint = True
        Me.txtLat.Size = New System.Drawing.Size(65, 19)
        Me.txtLat.TabIndex = 3
        Me.txtLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLat.ValueErrorMessageFlag = True
        '
        'lblYdegree
        '
        Me.lblYdegree.AutoSize = True
        Me.lblYdegree.Location = New System.Drawing.Point(153, 19)
        Me.lblYdegree.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblYdegree.Name = "lblYdegree"
        Me.lblYdegree.Size = New System.Drawing.Size(17, 12)
        Me.lblYdegree.TabIndex = 1
        Me.lblYdegree.Text = "度"
        '
        'rbSouth
        '
        Me.rbSouth.AutoSize = True
        Me.rbSouth.Location = New System.Drawing.Point(0, 22)
        Me.rbSouth.Name = "rbSouth"
        Me.rbSouth.Size = New System.Drawing.Size(47, 16)
        Me.rbSouth.TabIndex = 1
        Me.rbSouth.TabStop = True
        Me.rbSouth.Text = "南緯"
        Me.rbSouth.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 19)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "緯度"
        '
        'rbNorth
        '
        Me.rbNorth.AutoSize = True
        Me.rbNorth.Location = New System.Drawing.Point(0, 0)
        Me.rbNorth.Name = "rbNorth"
        Me.rbNorth.Size = New System.Drawing.Size(47, 16)
        Me.rbNorth.TabIndex = 0
        Me.rbNorth.TabStop = True
        Me.rbNorth.Text = "北緯"
        Me.rbNorth.UseVisualStyleBackColor = True
        '
        'pnlNorthSouth
        '
        Me.pnlNorthSouth.Controls.Add(Me.rbNorth)
        Me.pnlNorthSouth.Controls.Add(Me.rbSouth)
        Me.pnlNorthSouth.Location = New System.Drawing.Point(36, 3)
        Me.pnlNorthSouth.Name = "pnlNorthSouth"
        Me.pnlNorthSouth.Size = New System.Drawing.Size(47, 43)
        Me.pnlNorthSouth.TabIndex = 2
        '
        'pnlEastWest
        '
        Me.pnlEastWest.Controls.Add(Me.rbEast)
        Me.pnlEastWest.Controls.Add(Me.rbWest)
        Me.pnlEastWest.Location = New System.Drawing.Point(36, 0)
        Me.pnlEastWest.Name = "pnlEastWest"
        Me.pnlEastWest.Size = New System.Drawing.Size(44, 42)
        Me.pnlEastWest.TabIndex = 0
        '
        'frmLatLonInput10
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(218, 176)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLatLonInput10"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "緯度経度入力"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlNorthSouth.ResumeLayout(False)
        Me.pnlNorthSouth.PerformLayout()
        Me.pnlEastWest.ResumeLayout(False)
        Me.pnlEastWest.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtLat As mandara10.TextNumberBox
    Friend WithEvents lblYdegree As System.Windows.Forms.Label
    Friend WithEvents rbSouth As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbNorth As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtLon As mandara10.TextNumberBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbWest As System.Windows.Forms.RadioButton
    Friend WithEvents rbEast As System.Windows.Forms.RadioButton
    Friend WithEvents pnlEastWest As System.Windows.Forms.Panel
    Friend WithEvents pnlNorthSouth As System.Windows.Forms.Panel
End Class
