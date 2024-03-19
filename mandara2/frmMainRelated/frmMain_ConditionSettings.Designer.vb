<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_ConditionSettings
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
        Me.btnChange = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.ctnCheck = New System.Windows.Forms.Button()
        Me.clbList = New System.Windows.Forms.CheckedListBox()
        Me.btnAllCheck = New System.Windows.Forms.Button()
        Me.btnAllUnChecked = New System.Windows.Forms.Button()
        Me.chkInvisibleObjectBoundary = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(217, 345)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(16, 241)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(81, 24)
        Me.btnChange.TabIndex = 1
        Me.btnChange.Text = "設定変更"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(112, 241)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(81, 24)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(206, 241)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(81, 24)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'ctnCheck
        '
        Me.ctnCheck.Location = New System.Drawing.Point(16, 345)
        Me.ctnCheck.Name = "ctnCheck"
        Me.ctnCheck.Size = New System.Drawing.Size(104, 24)
        Me.ctnCheck.TabIndex = 7
        Me.ctnCheck.Text = "該当条件チェック"
        Me.ctnCheck.UseVisualStyleBackColor = True
        '
        'clbList
        '
        Me.clbList.FormattingEnabled = True
        Me.clbList.Location = New System.Drawing.Point(18, 29)
        Me.clbList.Name = "clbList"
        Me.clbList.Size = New System.Drawing.Size(268, 200)
        Me.clbList.TabIndex = 0
        '
        'btnAllCheck
        '
        Me.btnAllCheck.Location = New System.Drawing.Point(16, 271)
        Me.btnAllCheck.Name = "btnAllCheck"
        Me.btnAllCheck.Size = New System.Drawing.Size(81, 24)
        Me.btnAllCheck.TabIndex = 4
        Me.btnAllCheck.Text = "すべてチェック"
        Me.btnAllCheck.UseVisualStyleBackColor = True
        '
        'btnAllUnChecked
        '
        Me.btnAllUnChecked.Location = New System.Drawing.Point(112, 271)
        Me.btnAllUnChecked.Name = "btnAllUnChecked"
        Me.btnAllUnChecked.Size = New System.Drawing.Size(90, 24)
        Me.btnAllUnChecked.TabIndex = 5
        Me.btnAllUnChecked.Text = "すべて非チェック"
        Me.btnAllUnChecked.UseVisualStyleBackColor = True
        '
        'chkInvisibleObjectBoundary
        '
        Me.chkInvisibleObjectBoundary.AutoSize = True
        Me.chkInvisibleObjectBoundary.Location = New System.Drawing.Point(16, 314)
        Me.chkInvisibleObjectBoundary.Name = "chkInvisibleObjectBoundary"
        Me.chkInvisibleObjectBoundary.Size = New System.Drawing.Size(202, 16)
        Me.chkInvisibleObjectBoundary.TabIndex = 6
        Me.chkInvisibleObjectBoundary.Text = "非表示面オブジェクトの境界線を描画"
        Me.chkInvisibleObjectBoundary.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "条件設定"
        '
        'frmMain_ConditionSettings
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(299, 380)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkInvisibleObjectBoundary)
        Me.Controls.Add(Me.btnAllUnChecked)
        Me.Controls.Add(Me.btnAllCheck)
        Me.Controls.Add(Me.clbList)
        Me.Controls.Add(Me.ctnCheck)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_ConditionSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "属性検索設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents ctnCheck As System.Windows.Forms.Button
    Friend WithEvents clbList As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnAllCheck As System.Windows.Forms.Button
    Friend WithEvents btnAllUnChecked As System.Windows.Forms.Button
    Friend WithEvents chkInvisibleObjectBoundary As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
