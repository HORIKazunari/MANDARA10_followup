<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackgroundSetting
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
        Me.cboRoundSize = New System.Windows.Forms.ComboBox()
        Me.picBackTile = New System.Windows.Forms.PictureBox()
        Me.picLine = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPadding = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.picBackTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(30, 149)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(99, 149)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cboRoundSize
        '
        Me.cboRoundSize.FormattingEnabled = True
        Me.cboRoundSize.Location = New System.Drawing.Point(83, 83)
        Me.cboRoundSize.Name = "cboRoundSize"
        Me.cboRoundSize.Size = New System.Drawing.Size(59, 20)
        Me.cboRoundSize.TabIndex = 0
        '
        'picBackTile
        '
        Me.picBackTile.BackColor = System.Drawing.Color.White
        Me.picBackTile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picBackTile.Location = New System.Drawing.Point(83, 21)
        Me.picBackTile.Name = "picBackTile"
        Me.picBackTile.Size = New System.Drawing.Size(43, 25)
        Me.picBackTile.TabIndex = 12
        Me.picBackTile.TabStop = False
        '
        'picLine
        '
        Me.picLine.BackColor = System.Drawing.Color.White
        Me.picLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLine.Location = New System.Drawing.Point(83, 52)
        Me.picLine.Name = "picLine"
        Me.picLine.Size = New System.Drawing.Size(59, 25)
        Me.picLine.TabIndex = 13
        Me.picLine.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "背景"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "枠線"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 12)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "角丸サイズ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "余白"
        '
        'cboPadding
        '
        Me.cboPadding.FormattingEnabled = True
        Me.cboPadding.Location = New System.Drawing.Point(83, 114)
        Me.cboPadding.Name = "cboPadding"
        Me.cboPadding.Size = New System.Drawing.Size(59, 20)
        Me.cboPadding.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(145, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "％"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(145, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "％"
        '
        'frmBackgroundSetting
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(178, 184)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboPadding)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picLine)
        Me.Controls.Add(Me.picBackTile)
        Me.Controls.Add(Me.cboRoundSize)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBackgroundSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "背景フレーム設定"
        CType(Me.picBackTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cboRoundSize As System.Windows.Forms.ComboBox
    Friend WithEvents picBackTile As System.Windows.Forms.PictureBox
    Friend WithEvents picLine As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboPadding As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
