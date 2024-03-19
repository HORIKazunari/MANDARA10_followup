<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_ObjectLimitaion
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
        Me.components = New System.ComponentModel.Container()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cboLayer = New mandara10.ComboBoxEx()
        Me.chkObjectLimitaion = New System.Windows.Forms.CheckBox()
        Me.cbObj = New mandara10.CheckedListBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.chkInvisibleObjectBoundary = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(197, 337)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(128, 337)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'cboLayer
        '
        Me.cboLayer.AsteriskSelectEnabled = False
        Me.cboLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayer.FormattingEnabled = True
        Me.cboLayer.IntegralHeight = False
        Me.cboLayer.Location = New System.Drawing.Point(12, 55)
        Me.cboLayer.Name = "cboLayer"
        Me.cboLayer.Size = New System.Drawing.Size(225, 20)
        Me.cboLayer.TabIndex = 1
        '
        'chkObjectLimitaion
        '
        Me.chkObjectLimitaion.AutoSize = True
        Me.chkObjectLimitaion.Location = New System.Drawing.Point(16, 12)
        Me.chkObjectLimitaion.Name = "chkObjectLimitaion"
        Me.chkObjectLimitaion.Size = New System.Drawing.Size(184, 16)
        Me.chkObjectLimitaion.TabIndex = 0
        Me.chkObjectLimitaion.Text = "表示オブジェクト限定を有効にする"
        Me.chkObjectLimitaion.UseVisualStyleBackColor = True
        '
        'cbObj
        '
        Me.cbObj.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbObj.CheckOnClick = True
        Me.cbObj.EventStop = True
        Me.cbObj.FormattingEnabled = True
        Me.cbObj.Location = New System.Drawing.Point(11, 90)
        Me.cbObj.Name = "cbObj"
        Me.cbObj.Size = New System.Drawing.Size(247, 200)
        Me.cbObj.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 12)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "レイヤ"
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(229, 9)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(30, 21)
        Me.btnHelp.TabIndex = 6
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'chkInvisibleObjectBoundary
        '
        Me.chkInvisibleObjectBoundary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkInvisibleObjectBoundary.AutoSize = True
        Me.chkInvisibleObjectBoundary.Location = New System.Drawing.Point(12, 300)
        Me.chkInvisibleObjectBoundary.Name = "chkInvisibleObjectBoundary"
        Me.chkInvisibleObjectBoundary.Size = New System.Drawing.Size(202, 16)
        Me.chkInvisibleObjectBoundary.TabIndex = 3
        Me.chkInvisibleObjectBoundary.Text = "非表示面オブジェクトの境界線を描画"
        Me.chkInvisibleObjectBoundary.UseVisualStyleBackColor = True
        '
        'frmMain_ObjectLimitaion
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(270, 374)
        Me.Controls.Add(Me.chkInvisibleObjectBoundary)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbObj)
        Me.Controls.Add(Me.chkObjectLimitaion)
        Me.Controls.Add(Me.cboLayer)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_ObjectLimitaion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "表示オブジェクト限定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents cboLayer As mandara10.ComboBoxEx
    Friend WithEvents chkObjectLimitaion As System.Windows.Forms.CheckBox
    Friend WithEvents cbObj As mandara10.CheckedListBoxEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents chkInvisibleObjectBoundary As System.Windows.Forms.CheckBox
End Class
