<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_SetPositionFromData
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
        Me.cboLon = New mandara10.ComboBoxEx()
        Me.cboLat = New mandara10.ComboBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbLayer = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(125, 119)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(58, 119)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 21
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'cboLon
        '
        Me.cboLon.AsteriskSelectEnabled = False
        Me.cboLon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLon.FormattingEnabled = True
        Me.cboLon.IntegralHeight = False
        Me.cboLon.Location = New System.Drawing.Point(66, 33)
        Me.cboLon.MaxDropDownItems = 20
        Me.cboLon.Name = "cboLon"
        Me.cboLon.Size = New System.Drawing.Size(121, 20)
        Me.cboLon.TabIndex = 23
        '
        'cboLat
        '
        Me.cboLat.AsteriskSelectEnabled = False
        Me.cboLat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLat.FormattingEnabled = True
        Me.cboLat.IntegralHeight = False
        Me.cboLat.Location = New System.Drawing.Point(66, 74)
        Me.cboLat.MaxDropDownItems = 20
        Me.cboLat.Name = "cboLat"
        Me.cboLat.Size = New System.Drawing.Size(121, 20)
        Me.cboLat.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "経度"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "緯度"
        '
        'lbLayer
        '
        Me.lbLayer.AutoSize = True
        Me.lbLayer.Location = New System.Drawing.Point(12, 9)
        Me.lbLayer.Name = "lbLayer"
        Me.lbLayer.Size = New System.Drawing.Size(57, 12)
        Me.lbLayer.TabIndex = 27
        Me.lbLayer.Text = "設定レイヤ"
        '
        'frmMain_SetPositionFromData
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(207, 156)
        Me.Controls.Add(Me.lbLayer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboLat)
        Me.Controls.Add(Me.cboLon)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_SetPositionFromData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "座標の設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents cboLon As mandara10.ComboBoxEx
    Friend WithEvents cboLat As mandara10.ComboBoxEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbLayer As System.Windows.Forms.Label
End Class
