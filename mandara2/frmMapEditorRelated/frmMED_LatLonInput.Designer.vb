<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_LatLonInput
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
        Me.lblY = New System.Windows.Forms.Label()
        Me.lblX = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblYdegree = New System.Windows.Forms.Label()
        Me.lblXdegree = New System.Windows.Forms.Label()
        Me.txtLat = New mandara10.TextNumberBox()
        Me.txtLon = New mandara10.TextNumberBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(92, 85)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 21)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(16, 85)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 21)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Location = New System.Drawing.Point(12, 36)
        Me.lblY.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(29, 12)
        Me.lblY.TabIndex = 14
        Me.lblY.Text = "緯度"
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(12, 55)
        Me.lblX.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(29, 12)
        Me.lblX.TabIndex = 15
        Me.lblX.Text = "経度"
        Me.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 12)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "移動量の入力"
        '
        'lblYdegree
        '
        Me.lblYdegree.AutoSize = True
        Me.lblYdegree.Location = New System.Drawing.Point(142, 36)
        Me.lblYdegree.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblYdegree.Name = "lblYdegree"
        Me.lblYdegree.Size = New System.Drawing.Size(17, 12)
        Me.lblYdegree.TabIndex = 17
        Me.lblYdegree.Text = "度"
        '
        'lblXdegree
        '
        Me.lblXdegree.AutoSize = True
        Me.lblXdegree.Location = New System.Drawing.Point(142, 58)
        Me.lblXdegree.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblXdegree.Name = "lblXdegree"
        Me.lblXdegree.Size = New System.Drawing.Size(17, 12)
        Me.lblXdegree.TabIndex = 18
        Me.lblXdegree.Text = "度"
        '
        'txtLat
        '
        Me.txtLat.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLat.Location = New System.Drawing.Point(44, 33)
        Me.txtLat.MaxValue = 90.0R
        Me.txtLat.MaxValueFlag = True
        Me.txtLat.MinValue = -90.0R
        Me.txtLat.MinValueFlag = True
        Me.txtLat.Name = "txtLat"
        Me.txtLat.NumberPoint = True
        Me.txtLat.Size = New System.Drawing.Size(94, 19)
        Me.txtLat.TabIndex = 19
        Me.txtLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLat.ValueErrorMessageFlag = True
        '
        'txtLon
        '
        Me.txtLon.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLon.Location = New System.Drawing.Point(44, 54)
        Me.txtLon.MaxValue = 0.0R
        Me.txtLon.MaxValueFlag = False
        Me.txtLon.MinValue = 0.0R
        Me.txtLon.MinValueFlag = False
        Me.txtLon.Name = "txtLon"
        Me.txtLon.NumberPoint = True
        Me.txtLon.Size = New System.Drawing.Size(94, 19)
        Me.txtLon.TabIndex = 20
        Me.txtLon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLon.ValueErrorMessageFlag = True
        '
        'frmMED_LatLonInput
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(172, 118)
        Me.Controls.Add(Me.txtLon)
        Me.Controls.Add(Me.txtLat)
        Me.Controls.Add(Me.lblXdegree)
        Me.Controls.Add(Me.lblYdegree)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblX)
        Me.Controls.Add(Me.lblY)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_LatLonInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "緯度経度平行移動"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblY As System.Windows.Forms.Label
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblYdegree As System.Windows.Forms.Label
    Friend WithEvents lblXdegree As System.Windows.Forms.Label
    Friend WithEvents txtLat As mandara10.TextNumberBox
    Friend WithEvents txtLon As mandara10.TextNumberBox
End Class
