<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_LayerObjectCombine
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNewLayerName = New System.Windows.Forms.TextBox()
        Me.gbObject = New System.Windows.Forms.GroupBox()
        Me.rbMissing = New System.Windows.Forms.RadioButton()
        Me.rbRemove = New System.Windows.Forms.RadioButton()
        Me.clbLayer = New System.Windows.Forms.CheckedListBox()
        Me.gbObject.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(257, 376)
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
        Me.btnOK.Location = New System.Drawing.Point(190, 376)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 12)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "オブジェクトを集計するレイヤ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 195)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 12)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "新しいレイヤの名称"
        '
        'txtNewLayerName
        '
        Me.txtNewLayerName.Location = New System.Drawing.Point(127, 189)
        Me.txtNewLayerName.Name = "txtNewLayerName"
        Me.txtNewLayerName.Size = New System.Drawing.Size(192, 19)
        Me.txtNewLayerName.TabIndex = 1
        '
        'gbObject
        '
        Me.gbObject.Controls.Add(Me.rbMissing)
        Me.gbObject.Controls.Add(Me.rbRemove)
        Me.gbObject.Location = New System.Drawing.Point(29, 232)
        Me.gbObject.Name = "gbObject"
        Me.gbObject.Size = New System.Drawing.Size(290, 127)
        Me.gbObject.TabIndex = 2
        Me.gbObject.TabStop = False
        Me.gbObject.Text = "レイヤ間で共通しないオブジェクトの処理"
        '
        'rbMissing
        '
        Me.rbMissing.Checked = True
        Me.rbMissing.Location = New System.Drawing.Point(21, 72)
        Me.rbMissing.Name = "rbMissing"
        Me.rbMissing.Size = New System.Drawing.Size(207, 33)
        Me.rbMissing.TabIndex = 1
        Me.rbMissing.TabStop = True
        Me.rbMissing.Text = "新しいレイヤに入れ、存在しないレイヤのデータ項目は欠損値とする"
        Me.rbMissing.UseVisualStyleBackColor = True
        '
        'rbRemove
        '
        Me.rbRemove.Location = New System.Drawing.Point(21, 27)
        Me.rbRemove.Name = "rbRemove"
        Me.rbRemove.Size = New System.Drawing.Size(170, 39)
        Me.rbRemove.TabIndex = 0
        Me.rbRemove.Text = "新しいレイヤには入れない"
        Me.rbRemove.UseVisualStyleBackColor = True
        '
        'clbLayer
        '
        Me.clbLayer.CheckOnClick = True
        Me.clbLayer.FormattingEnabled = True
        Me.clbLayer.Location = New System.Drawing.Point(32, 48)
        Me.clbLayer.Name = "clbLayer"
        Me.clbLayer.Size = New System.Drawing.Size(286, 116)
        Me.clbLayer.TabIndex = 0
        '
        'frmMain_LayerObjectCombine
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(339, 415)
        Me.Controls.Add(Me.clbLayer)
        Me.Controls.Add(Me.gbObject)
        Me.Controls.Add(Me.txtNewLayerName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_LayerObjectCombine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "レイヤ間オブジェクト集計"
        Me.gbObject.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNewLayerName As System.Windows.Forms.TextBox
    Friend WithEvents gbObject As System.Windows.Forms.GroupBox
    Friend WithEvents rbMissing As System.Windows.Forms.RadioButton
    Friend WithEvents rbRemove As System.Windows.Forms.RadioButton
    Friend WithEvents clbLayer As System.Windows.Forms.CheckedListBox
End Class
