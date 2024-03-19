<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSyntheticObject
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSynLayer = New mandara10.ComboBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbSynObjects = New mandara10.ListBoxEx()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbIncludingObject = New mandara10.ListBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObjName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(264, 258)
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
        Me.btnOK.Location = New System.Drawing.Point(190, 258)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 21
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 12)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "時系列集計レイヤ"
        '
        'cboSynLayer
        '
        Me.cboSynLayer.AsteriskSelectEnabled = False
        Me.cboSynLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSynLayer.FormattingEnabled = True
        Me.cboSynLayer.IntegralHeight = False
        Me.cboSynLayer.Location = New System.Drawing.Point(14, 37)
        Me.cboSynLayer.Name = "cboSynLayer"
        Me.cboSynLayer.Size = New System.Drawing.Size(135, 20)
        Me.cboSynLayer.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 12)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "レイヤ内の合成オブジェクト"
        '
        'lbSynObjects
        '
        Me.lbSynObjects.AsteriskSelectEnabled = True
        Me.lbSynObjects.FormattingEnabled = True
        Me.lbSynObjects.ItemHeight = 12
        Me.lbSynObjects.Location = New System.Drawing.Point(14, 93)
        Me.lbSynObjects.Name = "lbSynObjects"
        Me.lbSynObjects.Size = New System.Drawing.Size(131, 148)
        Me.lbSynObjects.TabIndex = 26
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbIncludingObject)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtObjName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(171, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(155, 218)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "選択された合成オブジェクト"
        '
        'lbIncludingObject
        '
        Me.lbIncludingObject.AsteriskSelectEnabled = True
        Me.lbIncludingObject.FormattingEnabled = True
        Me.lbIncludingObject.ItemHeight = 12
        Me.lbIncludingObject.Location = New System.Drawing.Point(16, 86)
        Me.lbIncludingObject.Name = "lbIncludingObject"
        Me.lbIncludingObject.Size = New System.Drawing.Size(131, 124)
        Me.lbIncludingObject.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 12)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "含まれるオブジェクト"
        '
        'txtObjName
        '
        Me.txtObjName.Location = New System.Drawing.Point(16, 43)
        Me.txtObjName.Name = "txtObjName"
        Me.txtObjName.Size = New System.Drawing.Size(125, 19)
        Me.txtObjName.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 12)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "合成オブジェクトの名称"
        '
        'frmSyntheticObject
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(342, 292)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbSynObjects)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboSynLayer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSyntheticObject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "合成オブジェクト一覧"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSynLayer As mandara10.ComboBoxEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbSynObjects As mandara10.ListBoxEx
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtObjName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbIncludingObject As mandara10.ListBoxEx
End Class
