<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_ExchangeObjectName
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
        Me.lblLayer = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboObjectGroup = New mandara10.ComboBoxEx()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboObjectNameList = New mandara10.ComboBoxEx()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(186, 182)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(119, 182)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblLayer
        '
        Me.lblLayer.AutoSize = True
        Me.lblLayer.Location = New System.Drawing.Point(12, 18)
        Me.lblLayer.Name = "lblLayer"
        Me.lblLayer.Size = New System.Drawing.Size(38, 12)
        Me.lblLayer.TabIndex = 0
        Me.lblLayer.Text = "Label1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboObjectGroup)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(234, 50)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "オブジェクトグループ"
        '
        'cboObjectGroup
        '
        Me.cboObjectGroup.AsteriskSelectEnabled = False
        Me.cboObjectGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObjectGroup.FormattingEnabled = True
        Me.cboObjectGroup.IntegralHeight = False
        Me.cboObjectGroup.Location = New System.Drawing.Point(17, 18)
        Me.cboObjectGroup.Name = "cboObjectGroup"
        Me.cboObjectGroup.Size = New System.Drawing.Size(202, 20)
        Me.cboObjectGroup.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboObjectNameList)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 114)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(234, 50)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "オブジェクト名リスト"
        '
        'cboObjectNameList
        '
        Me.cboObjectNameList.AsteriskSelectEnabled = False
        Me.cboObjectNameList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObjectNameList.FormattingEnabled = True
        Me.cboObjectNameList.IntegralHeight = False
        Me.cboObjectNameList.Location = New System.Drawing.Point(17, 18)
        Me.cboObjectNameList.Name = "cboObjectNameList"
        Me.cboObjectNameList.Size = New System.Drawing.Size(202, 20)
        Me.cboObjectNameList.TabIndex = 0
        '
        'frmMain_ExchangeObjectName
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(263, 222)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblLayer)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_ExchangeObjectName"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オブジェクト名入れ替え"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblLayer As System.Windows.Forms.Label
    Friend WithEvents cboObjectGroup As mandara10.ComboBoxEx
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboObjectNameList As mandara10.ComboBoxEx
End Class
