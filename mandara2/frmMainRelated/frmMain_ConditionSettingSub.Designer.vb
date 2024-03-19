<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_ConditionSettingSub
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.cboLayer = New mandara10.ComboBoxEx()
        Me.lblOLay = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.btnAddLevel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnDataValue = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.cboData = New mandara10.ComboBoxEx()
        Me.lblOData = New System.Windows.Forms.Label()
        Me.gbCondition = New System.Windows.Forms.GroupBox()
        Me.rbExclude = New System.Windows.Forms.RadioButton()
        Me.rbInclude = New System.Windows.Forms.RadioButton()
        Me.rbNotEqual = New System.Windows.Forms.RadioButton()
        Me.rbGreater = New System.Windows.Forms.RadioButton()
        Me.rbGreaterEqual = New System.Windows.Forms.RadioButton()
        Me.rbEqual = New System.Windows.Forms.RadioButton()
        Me.rbLessEqual = New System.Windows.Forms.RadioButton()
        Me.rbLess = New System.Windows.Forms.RadioButton()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbOR = New System.Windows.Forms.RadioButton()
        Me.rbAND = New System.Windows.Forms.RadioButton()
        Me.ListView = New mandara10.ListViewEX()
        Me.btnDeleteLevel = New System.Windows.Forms.Button()
        Me.rbHead = New System.Windows.Forms.RadioButton()
        Me.rbFoot = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbCondition.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(348, 545)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(271, 545)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtTitle)
        Me.GroupBox1.Controls.Add(Me.cboLayer)
        Me.GroupBox1.Controls.Add(Me.lblOLay)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(407, 99)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "タイトル"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(69, 64)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(212, 19)
        Me.txtTitle.TabIndex = 1
        '
        'cboLayer
        '
        Me.cboLayer.AsteriskSelectEnabled = False
        Me.cboLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayer.FormattingEnabled = True
        Me.cboLayer.IntegralHeight = False
        Me.cboLayer.Location = New System.Drawing.Point(69, 18)
        Me.cboLayer.Name = "cboLayer"
        Me.cboLayer.Size = New System.Drawing.Size(165, 20)
        Me.cboLayer.TabIndex = 0
        '
        'lblOLay
        '
        Me.lblOLay.AutoSize = True
        Me.lblOLay.Location = New System.Drawing.Point(23, 21)
        Me.lblOLay.Name = "lblOLay"
        Me.lblOLay.Size = New System.Drawing.Size(33, 12)
        Me.lblOLay.TabIndex = 3
        Me.lblOLay.Text = "レイヤ"
        '
        'TabControl
        '
        Me.TabControl.Location = New System.Drawing.Point(14, 140)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(403, 27)
        Me.TabControl.TabIndex = 1
        '
        'btnAddLevel
        '
        Me.btnAddLevel.Location = New System.Drawing.Point(25, 545)
        Me.btnAddLevel.Name = "btnAddLevel"
        Me.btnAddLevel.Size = New System.Drawing.Size(81, 24)
        Me.btnAddLevel.TabIndex = 3
        Me.btnAddLevel.Text = "段階追加"
        Me.btnAddLevel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.ListView)
        Me.Panel1.Location = New System.Drawing.Point(15, 166)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(402, 362)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnDataValue)
        Me.GroupBox3.Controls.Add(Me.btnAdd)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtValue)
        Me.GroupBox3.Controls.Add(Me.cboData)
        Me.GroupBox3.Controls.Add(Me.lblOData)
        Me.GroupBox3.Controls.Add(Me.gbCondition)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 176)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(392, 181)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "新規設定"
        '
        'btnDataValue
        '
        Me.btnDataValue.Location = New System.Drawing.Point(269, 15)
        Me.btnDataValue.Name = "btnDataValue"
        Me.btnDataValue.Size = New System.Drawing.Size(81, 24)
        Me.btnDataValue.TabIndex = 1
        Me.btnDataValue.Text = "データ値参照"
        Me.btnDataValue.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(305, 151)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(81, 24)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "項目追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "条件値"
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(80, 57)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(212, 19)
        Me.txtValue.TabIndex = 2
        '
        'cboData
        '
        Me.cboData.AsteriskSelectEnabled = False
        Me.cboData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboData.FormattingEnabled = True
        Me.cboData.IntegralHeight = False
        Me.cboData.Location = New System.Drawing.Point(80, 18)
        Me.cboData.Name = "cboData"
        Me.cboData.Size = New System.Drawing.Size(165, 20)
        Me.cboData.TabIndex = 0
        '
        'lblOData
        '
        Me.lblOData.AutoSize = True
        Me.lblOData.Location = New System.Drawing.Point(17, 21)
        Me.lblOData.Name = "lblOData"
        Me.lblOData.Size = New System.Drawing.Size(57, 12)
        Me.lblOData.TabIndex = 13
        Me.lblOData.Text = "データ項目"
        '
        'gbCondition
        '
        Me.gbCondition.Controls.Add(Me.rbFoot)
        Me.gbCondition.Controls.Add(Me.rbHead)
        Me.gbCondition.Controls.Add(Me.rbExclude)
        Me.gbCondition.Controls.Add(Me.rbInclude)
        Me.gbCondition.Controls.Add(Me.rbNotEqual)
        Me.gbCondition.Controls.Add(Me.rbGreater)
        Me.gbCondition.Controls.Add(Me.rbGreaterEqual)
        Me.gbCondition.Controls.Add(Me.rbEqual)
        Me.gbCondition.Controls.Add(Me.rbLessEqual)
        Me.gbCondition.Controls.Add(Me.rbLess)
        Me.gbCondition.Location = New System.Drawing.Point(13, 82)
        Me.gbCondition.Name = "gbCondition"
        Me.gbCondition.Size = New System.Drawing.Size(366, 64)
        Me.gbCondition.TabIndex = 3
        Me.gbCondition.TabStop = False
        Me.gbCondition.Text = "条件"
        '
        'rbExclude
        '
        Me.rbExclude.AutoSize = True
        Me.rbExclude.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbExclude.Location = New System.Drawing.Point(132, 41)
        Me.rbExclude.Name = "rbExclude"
        Me.rbExclude.Size = New System.Drawing.Size(64, 16)
        Me.rbExclude.TabIndex = 7
        Me.rbExclude.TabStop = True
        Me.rbExclude.Text = "含まない"
        Me.rbExclude.UseVisualStyleBackColor = True
        '
        'rbInclude
        '
        Me.rbInclude.AutoSize = True
        Me.rbInclude.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbInclude.Location = New System.Drawing.Point(84, 43)
        Me.rbInclude.Name = "rbInclude"
        Me.rbInclude.Size = New System.Drawing.Size(45, 16)
        Me.rbInclude.TabIndex = 6
        Me.rbInclude.TabStop = True
        Me.rbInclude.Text = "含む"
        Me.rbInclude.UseVisualStyleBackColor = True
        '
        'rbNotEqual
        '
        Me.rbNotEqual.AutoSize = True
        Me.rbNotEqual.Location = New System.Drawing.Point(29, 43)
        Me.rbNotEqual.Name = "rbNotEqual"
        Me.rbNotEqual.Size = New System.Drawing.Size(47, 16)
        Me.rbNotEqual.TabIndex = 5
        Me.rbNotEqual.TabStop = True
        Me.rbNotEqual.Text = "以外"
        Me.rbNotEqual.UseVisualStyleBackColor = True
        '
        'rbGreater
        '
        Me.rbGreater.AutoSize = True
        Me.rbGreater.Location = New System.Drawing.Point(245, 19)
        Me.rbGreater.Name = "rbGreater"
        Me.rbGreater.Size = New System.Drawing.Size(71, 16)
        Me.rbGreater.TabIndex = 4
        Me.rbGreater.TabStop = True
        Me.rbGreater.Text = "より大きい"
        Me.rbGreater.UseVisualStyleBackColor = True
        '
        'rbGreaterEqual
        '
        Me.rbGreaterEqual.AutoSize = True
        Me.rbGreaterEqual.Location = New System.Drawing.Point(192, 19)
        Me.rbGreaterEqual.Name = "rbGreaterEqual"
        Me.rbGreaterEqual.Size = New System.Drawing.Size(47, 16)
        Me.rbGreaterEqual.TabIndex = 3
        Me.rbGreaterEqual.TabStop = True
        Me.rbGreaterEqual.Text = "以上"
        Me.rbGreaterEqual.UseVisualStyleBackColor = True
        '
        'rbEqual
        '
        Me.rbEqual.AutoSize = True
        Me.rbEqual.Location = New System.Drawing.Point(132, 19)
        Me.rbEqual.Name = "rbEqual"
        Me.rbEqual.Size = New System.Drawing.Size(54, 16)
        Me.rbEqual.TabIndex = 2
        Me.rbEqual.TabStop = True
        Me.rbEqual.Text = "等しい"
        Me.rbEqual.UseVisualStyleBackColor = True
        '
        'rbLessEqual
        '
        Me.rbLessEqual.AutoSize = True
        Me.rbLessEqual.Location = New System.Drawing.Point(82, 19)
        Me.rbLessEqual.Name = "rbLessEqual"
        Me.rbLessEqual.Size = New System.Drawing.Size(47, 16)
        Me.rbLessEqual.TabIndex = 1
        Me.rbLessEqual.TabStop = True
        Me.rbLessEqual.Text = "以下"
        Me.rbLessEqual.UseVisualStyleBackColor = True
        '
        'rbLess
        '
        Me.rbLess.AutoSize = True
        Me.rbLess.Location = New System.Drawing.Point(29, 19)
        Me.rbLess.Name = "rbLess"
        Me.rbLess.Size = New System.Drawing.Size(47, 16)
        Me.rbLess.TabIndex = 0
        Me.rbLess.TabStop = True
        Me.rbLess.Text = "未満"
        Me.rbLess.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(306, 88)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(81, 24)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "項目削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbOR)
        Me.GroupBox2.Controls.Add(Me.rbAND)
        Me.GroupBox2.Location = New System.Drawing.Point(306, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(78, 66)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'rbOR
        '
        Me.rbOR.AutoSize = True
        Me.rbOR.Location = New System.Drawing.Point(10, 39)
        Me.rbOR.Name = "rbOR"
        Me.rbOR.Size = New System.Drawing.Size(39, 16)
        Me.rbOR.TabIndex = 1
        Me.rbOR.TabStop = True
        Me.rbOR.Text = "OR"
        Me.rbOR.UseVisualStyleBackColor = True
        '
        'rbAND
        '
        Me.rbAND.AutoSize = True
        Me.rbAND.Location = New System.Drawing.Point(8, 17)
        Me.rbAND.Name = "rbAND"
        Me.rbAND.Size = New System.Drawing.Size(47, 16)
        Me.rbAND.TabIndex = 0
        Me.rbAND.TabStop = True
        Me.rbAND.Text = "AND"
        Me.rbAND.UseVisualStyleBackColor = True
        '
        'ListView
        '
        Me.ListView.FullRowSelect = True
        Me.ListView.GridLines = True
        Me.ListView.Location = New System.Drawing.Point(3, 3)
        Me.ListView.MultiSelect = False
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(289, 167)
        Me.ListView.TabIndex = 0
        Me.ListView.UseCompatibleStateImageBehavior = False
        Me.ListView.View = System.Windows.Forms.View.Details
        '
        'btnDeleteLevel
        '
        Me.btnDeleteLevel.Location = New System.Drawing.Point(112, 545)
        Me.btnDeleteLevel.Name = "btnDeleteLevel"
        Me.btnDeleteLevel.Size = New System.Drawing.Size(81, 24)
        Me.btnDeleteLevel.TabIndex = 4
        Me.btnDeleteLevel.Text = "段階削除"
        Me.btnDeleteLevel.UseVisualStyleBackColor = True
        '
        'rbHead
        '
        Me.rbHead.AutoSize = True
        Me.rbHead.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbHead.Location = New System.Drawing.Point(192, 41)
        Me.rbHead.Name = "rbHead"
        Me.rbHead.Size = New System.Drawing.Size(81, 16)
        Me.rbHead.TabIndex = 8
        Me.rbHead.TabStop = True
        Me.rbHead.Text = "先頭の文字"
        Me.rbHead.UseVisualStyleBackColor = True
        '
        'rbFoot
        '
        Me.rbFoot.AutoSize = True
        Me.rbFoot.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbFoot.Location = New System.Drawing.Point(275, 41)
        Me.rbFoot.Name = "rbFoot"
        Me.rbFoot.Size = New System.Drawing.Size(81, 16)
        Me.rbFoot.TabIndex = 9
        Me.rbFoot.TabStop = True
        Me.rbFoot.Text = "末尾の文字"
        Me.rbFoot.UseVisualStyleBackColor = True
        '
        'frmMain_ConditionSettingSub
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(433, 581)
        Me.Controls.Add(Me.btnDeleteLevel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAddLevel)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_ConditionSettingSub"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "属性検索条件設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbCondition.ResumeLayout(False)
        Me.gbCondition.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLayer As mandara10.ComboBoxEx
    Friend WithEvents lblOLay As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents ListView As mandara10.ListViewEX
    Friend WithEvents btnAddLevel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbOR As System.Windows.Forms.RadioButton
    Friend WithEvents rbAND As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents gbCondition As System.Windows.Forms.GroupBox
    Friend WithEvents rbNotEqual As System.Windows.Forms.RadioButton
    Friend WithEvents rbGreater As System.Windows.Forms.RadioButton
    Friend WithEvents rbGreaterEqual As System.Windows.Forms.RadioButton
    Friend WithEvents rbEqual As System.Windows.Forms.RadioButton
    Friend WithEvents rbLessEqual As System.Windows.Forms.RadioButton
    Friend WithEvents rbLess As System.Windows.Forms.RadioButton
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents cboData As mandara10.ComboBoxEx
    Friend WithEvents lblOData As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDeleteLevel As System.Windows.Forms.Button
    Friend WithEvents btnDataValue As System.Windows.Forms.Button
    Friend WithEvents rbExclude As System.Windows.Forms.RadioButton
    Friend WithEvents rbInclude As System.Windows.Forms.RadioButton
    Friend WithEvents rbFoot As System.Windows.Forms.RadioButton
    Friend WithEvents rbHead As System.Windows.Forms.RadioButton
End Class
