<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_Property_of_MapFile
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
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.gbDistance = New System.Windows.Forms.GroupBox()
        Me.cbCompass = New System.Windows.Forms.CheckBox()
        Me.cbScale = New System.Windows.Forms.CheckBox()
        Me.cbDistance = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListViewEX = New mandara10.ListViewEX()
        Me.gbDistance.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(563, 313)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(468, 313)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(11, 114)
        Me.txtComment.Margin = New System.Windows.Forms.Padding(2)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComment.Size = New System.Drawing.Size(305, 184)
        Me.txtComment.TabIndex = 1
        '
        'gbDistance
        '
        Me.gbDistance.Controls.Add(Me.cbCompass)
        Me.gbDistance.Controls.Add(Me.cbScale)
        Me.gbDistance.Controls.Add(Me.cbDistance)
        Me.gbDistance.Location = New System.Drawing.Point(11, 11)
        Me.gbDistance.Margin = New System.Windows.Forms.Padding(2)
        Me.gbDistance.Name = "gbDistance"
        Me.gbDistance.Padding = New System.Windows.Forms.Padding(2)
        Me.gbDistance.Size = New System.Drawing.Size(305, 78)
        Me.gbDistance.TabIndex = 0
        Me.gbDistance.TabStop = False
        Me.gbDistance.Text = "出力画面での距離・スケール・方位"
        '
        'cbCompass
        '
        Me.cbCompass.AutoSize = True
        Me.cbCompass.Location = New System.Drawing.Point(17, 53)
        Me.cbCompass.Margin = New System.Windows.Forms.Padding(2)
        Me.cbCompass.Name = "cbCompass"
        Me.cbCompass.Size = New System.Drawing.Size(133, 16)
        Me.cbCompass.TabIndex = 2
        Me.cbCompass.Text = "方位記号を表示できる"
        Me.cbCompass.UseVisualStyleBackColor = True
        '
        'cbScale
        '
        Me.cbScale.AutoSize = True
        Me.cbScale.Location = New System.Drawing.Point(163, 23)
        Me.cbScale.Margin = New System.Windows.Forms.Padding(2)
        Me.cbScale.Name = "cbScale"
        Me.cbScale.Size = New System.Drawing.Size(123, 16)
        Me.cbScale.TabIndex = 1
        Me.cbScale.Text = "スケールを表示できる"
        Me.cbScale.UseVisualStyleBackColor = True
        '
        'cbDistance
        '
        Me.cbDistance.AutoSize = True
        Me.cbDistance.Location = New System.Drawing.Point(17, 23)
        Me.cbDistance.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDistance.Name = "cbDistance"
        Me.cbDistance.Size = New System.Drawing.Size(109, 16)
        Me.cbDistance.TabIndex = 0
        Me.cbDistance.Text = "距離を測定できる"
        Me.cbDistance.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 100)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "地図ファイルのコメント"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(325, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "データ"
        '
        'ListViewEX
        '
        Me.ListViewEX.GridLines = True
        Me.ListViewEX.Location = New System.Drawing.Point(327, 21)
        Me.ListViewEX.Margin = New System.Windows.Forms.Padding(2)
        Me.ListViewEX.Name = "ListViewEX"
        Me.ListViewEX.Size = New System.Drawing.Size(305, 277)
        Me.ListViewEX.TabIndex = 2
        Me.ListViewEX.UseCompatibleStateImageBehavior = False
        Me.ListViewEX.View = System.Windows.Forms.View.Details
        '
        'frmMED_Property_of_MapFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 348)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListViewEX)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbDistance)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_Property_of_MapFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "地図ファイルのプロパティ"
        Me.gbDistance.ResumeLayout(False)
        Me.gbDistance.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents gbDistance As System.Windows.Forms.GroupBox
    Friend WithEvents cbCompass As System.Windows.Forms.CheckBox
    Friend WithEvents cbScale As System.Windows.Forms.CheckBox
    Friend WithEvents cbDistance As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListViewEX As mandara10.ListViewEX
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
