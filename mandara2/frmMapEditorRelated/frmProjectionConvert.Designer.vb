<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectionConvert
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
        Me.lbGenzai = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCenterLat = New mandara10.TextBoxFocusAllSelect()
        Me.rbManual = New System.Windows.Forms.RadioButton()
        Me.rbMapCenter = New System.Windows.Forms.RadioButton()
        Me.rbCenterNoChange = New System.Windows.Forms.RadioButton()
        Me.gbProjection = New System.Windows.Forms.GroupBox()
        Me.rbEckert4 = New System.Windows.Forms.RadioButton()
        Me.rbMol = New System.Windows.Forms.RadioButton()
        Me.rbMiller = New System.Windows.Forms.RadioButton()
        Me.rbLambertSeisekiEntou = New System.Windows.Forms.RadioButton()
        Me.rbMercator = New System.Windows.Forms.RadioButton()
        Me.rbSeikyoEntou = New System.Windows.Forms.RadioButton()
        Me.rbSanson = New System.Windows.Forms.RadioButton()
        Me.lblLine2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbProjection.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(333, 230)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(252, 230)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbGenzai)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(205, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "現在の投影法"
        '
        'lbGenzai
        '
        Me.lbGenzai.BackColor = System.Drawing.SystemColors.Window
        Me.lbGenzai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbGenzai.Location = New System.Drawing.Point(13, 24)
        Me.lbGenzai.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbGenzai.Name = "lbGenzai"
        Me.lbGenzai.Size = New System.Drawing.Size(178, 16)
        Me.lbGenzai.TabIndex = 0
        Me.lbGenzai.Text = "Label1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCenterLat)
        Me.GroupBox2.Controls.Add(Me.rbManual)
        Me.GroupBox2.Controls.Add(Me.rbMapCenter)
        Me.GroupBox2.Controls.Add(Me.rbCenterNoChange)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 73)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(205, 143)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "中央経線の設定"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(136, 113)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "度"
        '
        'txtCenterLat
        '
        Me.txtCenterLat.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCenterLat.Location = New System.Drawing.Point(38, 107)
        Me.txtCenterLat.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCenterLat.Name = "txtCenterLat"
        Me.txtCenterLat.Size = New System.Drawing.Size(94, 19)
        Me.txtCenterLat.TabIndex = 2
        Me.txtCenterLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rbManual
        '
        Me.rbManual.AutoSize = True
        Me.rbManual.Location = New System.Drawing.Point(20, 87)
        Me.rbManual.Margin = New System.Windows.Forms.Padding(2)
        Me.rbManual.Name = "rbManual"
        Me.rbManual.Size = New System.Drawing.Size(47, 16)
        Me.rbManual.TabIndex = 2
        Me.rbManual.TabStop = True
        Me.rbManual.Text = "指定"
        Me.rbManual.UseVisualStyleBackColor = True
        '
        'rbMapCenter
        '
        Me.rbMapCenter.AutoSize = True
        Me.rbMapCenter.Location = New System.Drawing.Point(20, 58)
        Me.rbMapCenter.Margin = New System.Windows.Forms.Padding(2)
        Me.rbMapCenter.Name = "rbMapCenter"
        Me.rbMapCenter.Size = New System.Drawing.Size(81, 16)
        Me.rbMapCenter.TabIndex = 1
        Me.rbMapCenter.TabStop = True
        Me.rbMapCenter.Text = "地図の中央"
        Me.rbMapCenter.UseVisualStyleBackColor = True
        '
        'rbCenterNoChange
        '
        Me.rbCenterNoChange.AutoSize = True
        Me.rbCenterNoChange.Location = New System.Drawing.Point(20, 28)
        Me.rbCenterNoChange.Margin = New System.Windows.Forms.Padding(2)
        Me.rbCenterNoChange.Name = "rbCenterNoChange"
        Me.rbCenterNoChange.Size = New System.Drawing.Size(105, 16)
        Me.rbCenterNoChange.TabIndex = 0
        Me.rbCenterNoChange.TabStop = True
        Me.rbCenterNoChange.Text = "中央経線の設定"
        Me.rbCenterNoChange.UseVisualStyleBackColor = True
        '
        'gbProjection
        '
        Me.gbProjection.Controls.Add(Me.lblLine2)
        Me.gbProjection.Controls.Add(Me.rbEckert4)
        Me.gbProjection.Controls.Add(Me.rbMol)
        Me.gbProjection.Controls.Add(Me.rbMiller)
        Me.gbProjection.Controls.Add(Me.rbLambertSeisekiEntou)
        Me.gbProjection.Controls.Add(Me.rbMercator)
        Me.gbProjection.Controls.Add(Me.rbSeikyoEntou)
        Me.gbProjection.Controls.Add(Me.rbSanson)
        Me.gbProjection.Location = New System.Drawing.Point(224, 14)
        Me.gbProjection.Margin = New System.Windows.Forms.Padding(2)
        Me.gbProjection.Name = "gbProjection"
        Me.gbProjection.Padding = New System.Windows.Forms.Padding(2)
        Me.gbProjection.Size = New System.Drawing.Size(178, 202)
        Me.gbProjection.TabIndex = 2
        Me.gbProjection.TabStop = False
        Me.gbProjection.Text = "変換後の投影法"
        '
        'rbEckert4
        '
        Me.rbEckert4.AutoSize = True
        Me.rbEckert4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbEckert4.Location = New System.Drawing.Point(23, 135)
        Me.rbEckert4.Margin = New System.Windows.Forms.Padding(2)
        Me.rbEckert4.Name = "rbEckert4"
        Me.rbEckert4.Size = New System.Drawing.Size(110, 16)
        Me.rbEckert4.TabIndex = 6
        Me.rbEckert4.TabStop = True
        Me.rbEckert4.Text = "エッケルト第４図法"
        Me.rbEckert4.UseVisualStyleBackColor = True
        '
        'rbMol
        '
        Me.rbMol.AutoSize = True
        Me.rbMol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbMol.Location = New System.Drawing.Point(23, 155)
        Me.rbMol.Margin = New System.Windows.Forms.Padding(2)
        Me.rbMol.Name = "rbMol"
        Me.rbMol.Size = New System.Drawing.Size(94, 16)
        Me.rbMol.TabIndex = 5
        Me.rbMol.TabStop = True
        Me.rbMol.Text = "モルワイデ図法"
        Me.rbMol.UseVisualStyleBackColor = True
        '
        'rbMiller
        '
        Me.rbMiller.AutoSize = True
        Me.rbMiller.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbMiller.Location = New System.Drawing.Point(23, 50)
        Me.rbMiller.Margin = New System.Windows.Forms.Padding(2)
        Me.rbMiller.Name = "rbMiller"
        Me.rbMiller.Size = New System.Drawing.Size(72, 16)
        Me.rbMiller.TabIndex = 4
        Me.rbMiller.TabStop = True
        Me.rbMiller.Text = "ミラー図法"
        Me.rbMiller.UseVisualStyleBackColor = True
        '
        'rbLambertSeisekiEntou
        '
        Me.rbLambertSeisekiEntou.AutoSize = True
        Me.rbLambertSeisekiEntou.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbLambertSeisekiEntou.Location = New System.Drawing.Point(23, 90)
        Me.rbLambertSeisekiEntou.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLambertSeisekiEntou.Name = "rbLambertSeisekiEntou"
        Me.rbLambertSeisekiEntou.Size = New System.Drawing.Size(140, 16)
        Me.rbLambertSeisekiEntou.TabIndex = 3
        Me.rbLambertSeisekiEntou.TabStop = True
        Me.rbLambertSeisekiEntou.Text = "ランベルト正積円筒図法"
        Me.rbLambertSeisekiEntou.UseVisualStyleBackColor = True
        '
        'rbMercator
        '
        Me.rbMercator.AutoSize = True
        Me.rbMercator.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbMercator.Location = New System.Drawing.Point(23, 30)
        Me.rbMercator.Margin = New System.Windows.Forms.Padding(2)
        Me.rbMercator.Name = "rbMercator"
        Me.rbMercator.Size = New System.Drawing.Size(92, 16)
        Me.rbMercator.TabIndex = 2
        Me.rbMercator.TabStop = True
        Me.rbMercator.Text = "メルカトル図法"
        Me.rbMercator.UseVisualStyleBackColor = True
        '
        'rbSeikyoEntou
        '
        Me.rbSeikyoEntou.AutoSize = True
        Me.rbSeikyoEntou.Location = New System.Drawing.Point(23, 70)
        Me.rbSeikyoEntou.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSeikyoEntou.Name = "rbSeikyoEntou"
        Me.rbSeikyoEntou.Size = New System.Drawing.Size(95, 16)
        Me.rbSeikyoEntou.TabIndex = 1
        Me.rbSeikyoEntou.TabStop = True
        Me.rbSeikyoEntou.Text = "正距円筒図法"
        Me.rbSeikyoEntou.UseVisualStyleBackColor = True
        '
        'rbSanson
        '
        Me.rbSanson.AutoSize = True
        Me.rbSanson.Location = New System.Drawing.Point(23, 175)
        Me.rbSanson.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSanson.Name = "rbSanson"
        Me.rbSanson.Size = New System.Drawing.Size(84, 16)
        Me.rbSanson.TabIndex = 0
        Me.rbSanson.TabStop = True
        Me.rbSanson.Text = "サンソン図法"
        Me.rbSanson.UseVisualStyleBackColor = True
        '
        'lblLine2
        '
        Me.lblLine2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLine2.Location = New System.Drawing.Point(15, 120)
        Me.lblLine2.Name = "lblLine2"
        Me.lblLine2.Size = New System.Drawing.Size(150, 1)
        Me.lblLine2.TabIndex = 9
        '
        'frmProjectionConvert
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(413, 264)
        Me.Controls.Add(Me.gbProjection)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProjectionConvert"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "投影法変換"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbProjection.ResumeLayout(False)
        Me.gbProjection.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbGenzai As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbManual As System.Windows.Forms.RadioButton
    Friend WithEvents rbMapCenter As System.Windows.Forms.RadioButton
    Friend WithEvents rbCenterNoChange As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCenterLat As mandara10.TextBoxFocusAllSelect
    Friend WithEvents gbProjection As System.Windows.Forms.GroupBox
    Friend WithEvents rbLambertSeisekiEntou As System.Windows.Forms.RadioButton
    Friend WithEvents rbMercator As System.Windows.Forms.RadioButton
    Friend WithEvents rbSeikyoEntou As System.Windows.Forms.RadioButton
    Friend WithEvents rbSanson As System.Windows.Forms.RadioButton
    Friend WithEvents rbMiller As System.Windows.Forms.RadioButton
    Friend WithEvents rbMol As System.Windows.Forms.RadioButton
    Friend WithEvents rbEckert4 As System.Windows.Forms.RadioButton
    Friend WithEvents lblLine2 As System.Windows.Forms.Label
End Class
