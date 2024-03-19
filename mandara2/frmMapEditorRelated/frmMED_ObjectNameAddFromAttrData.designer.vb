<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_ObjectNameAddFromAttrData
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
        Me.gbObjectKind = New System.Windows.Forms.GroupBox()
        Me.cboObjectKind = New mandara10.ComboBoxEx()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboData = New mandara10.ComboBoxEx()
        Me.gbObjectKind.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(208, 135)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(141, 135)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'gbObjectKind
        '
        Me.gbObjectKind.Controls.Add(Me.cboObjectKind)
        Me.gbObjectKind.Location = New System.Drawing.Point(30, 11)
        Me.gbObjectKind.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjectKind.Name = "gbObjectKind"
        Me.gbObjectKind.Padding = New System.Windows.Forms.Padding(11, 8, 11, 3)
        Me.gbObjectKind.Size = New System.Drawing.Size(240, 48)
        Me.gbObjectKind.TabIndex = 0
        Me.gbObjectKind.TabStop = False
        Me.gbObjectKind.Text = "オブジェクトグループ"
        '
        'cboObjectKind
        '
        Me.cboObjectKind.AsteriskSelectEnabled = False
        Me.cboObjectKind.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboObjectKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObjectKind.FormattingEnabled = True
        Me.cboObjectKind.IntegralHeight = False
        Me.cboObjectKind.Location = New System.Drawing.Point(11, 20)
        Me.cboObjectKind.Margin = New System.Windows.Forms.Padding(2)
        Me.cboObjectKind.Name = "cboObjectKind"
        Me.cboObjectKind.Size = New System.Drawing.Size(218, 20)
        Me.cboObjectKind.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboData)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 73)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(11, 8, 11, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(240, 51)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "設定する初期属性データ"
        '
        'cboData
        '
        Me.cboData.AsteriskSelectEnabled = False
        Me.cboData.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboData.FormattingEnabled = True
        Me.cboData.IntegralHeight = False
        Me.cboData.Location = New System.Drawing.Point(11, 20)
        Me.cboData.Margin = New System.Windows.Forms.Padding(2)
        Me.cboData.Name = "cboData"
        Me.cboData.Size = New System.Drawing.Size(218, 20)
        Me.cboData.TabIndex = 1
        '
        'frmMED_ObjectNameAddFromAttrData
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(301, 170)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbObjectKind)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_ObjectNameAddFromAttrData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "初期属性データからオブジェクト名に追加"
        Me.gbObjectKind.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents gbObjectKind As System.Windows.Forms.GroupBox
    Friend WithEvents cboObjectKind As mandara10.ComboBoxEx
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboData As mandara10.ComboBoxEx
End Class
