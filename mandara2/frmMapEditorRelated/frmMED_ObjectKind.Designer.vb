<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_ObjectKind
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMED_ObjectKind))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbObjectKind = New System.Windows.Forms.ListBox()
        Me.btnUpword = New System.Windows.Forms.Button()
        Me.btnDownword = New System.Windows.Forms.Button()
        Me.btnAddGroup = New System.Windows.Forms.Button()
        Me.gbSet = New System.Windows.Forms.GroupBox()
        Me.btnDeleteGroup = New System.Windows.Forms.Button()
        Me.picColor = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbObjShape = New System.Windows.Forms.GroupBox()
        Me.rbPolygon = New System.Windows.Forms.RadioButton()
        Me.rbLine = New System.Windows.Forms.RadioButton()
        Me.rbPoint = New System.Windows.Forms.RadioButton()
        Me.rbNoShape = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbObjectTypeAggrigation = New System.Windows.Forms.RadioButton()
        Me.rbObjectTypeNormal = New System.Windows.Forms.RadioButton()
        Me.txtNewName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbUseLineKind = New System.Windows.Forms.GroupBox()
        Me.clbUseLineKind = New System.Windows.Forms.CheckedListBox()
        Me.gbUseObjectGroup = New System.Windows.Forms.GroupBox()
        Me.clbUseObjectGroup = New System.Windows.Forms.CheckedListBox()
        Me.gbSet.SuspendLayout()
        CType(Me.picColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbObjShape.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbUseLineKind.SuspendLayout()
        Me.gbUseObjectGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(441, 317)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(524, 317)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 26)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "編集するオブジェクトグループ"
        '
        'lbObjectKind
        '
        Me.lbObjectKind.FormattingEnabled = True
        Me.lbObjectKind.ItemHeight = 12
        Me.lbObjectKind.Location = New System.Drawing.Point(9, 38)
        Me.lbObjectKind.Margin = New System.Windows.Forms.Padding(2)
        Me.lbObjectKind.Name = "lbObjectKind"
        Me.lbObjectKind.Size = New System.Drawing.Size(184, 196)
        Me.lbObjectKind.TabIndex = 1
        '
        'btnUpword
        '
        Me.btnUpword.Image = CType(resources.GetObject("btnUpword.Image"), System.Drawing.Image)
        Me.btnUpword.Location = New System.Drawing.Point(60, 238)
        Me.btnUpword.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpword.Name = "btnUpword"
        Me.btnUpword.Size = New System.Drawing.Size(33, 34)
        Me.btnUpword.TabIndex = 2
        Me.btnUpword.UseVisualStyleBackColor = True
        '
        'btnDownword
        '
        Me.btnDownword.Image = CType(resources.GetObject("btnDownword.Image"), System.Drawing.Image)
        Me.btnDownword.Location = New System.Drawing.Point(106, 238)
        Me.btnDownword.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDownword.Name = "btnDownword"
        Me.btnDownword.Size = New System.Drawing.Size(36, 34)
        Me.btnDownword.TabIndex = 3
        Me.btnDownword.UseVisualStyleBackColor = True
        '
        'btnAddGroup
        '
        Me.btnAddGroup.Location = New System.Drawing.Point(60, 276)
        Me.btnAddGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddGroup.Name = "btnAddGroup"
        Me.btnAddGroup.Size = New System.Drawing.Size(82, 26)
        Me.btnAddGroup.TabIndex = 4
        Me.btnAddGroup.Text = "グループ追加"
        Me.btnAddGroup.UseVisualStyleBackColor = True
        '
        'gbSet
        '
        Me.gbSet.Controls.Add(Me.btnDeleteGroup)
        Me.gbSet.Controls.Add(Me.picColor)
        Me.gbSet.Controls.Add(Me.Label3)
        Me.gbSet.Controls.Add(Me.gbObjShape)
        Me.gbSet.Controls.Add(Me.GroupBox2)
        Me.gbSet.Controls.Add(Me.txtNewName)
        Me.gbSet.Controls.Add(Me.Label2)
        Me.gbSet.Controls.Add(Me.gbUseLineKind)
        Me.gbSet.Controls.Add(Me.gbUseObjectGroup)
        Me.gbSet.Location = New System.Drawing.Point(208, 30)
        Me.gbSet.Margin = New System.Windows.Forms.Padding(2)
        Me.gbSet.Name = "gbSet"
        Me.gbSet.Padding = New System.Windows.Forms.Padding(2)
        Me.gbSet.Size = New System.Drawing.Size(384, 272)
        Me.gbSet.TabIndex = 5
        Me.gbSet.TabStop = False
        Me.gbSet.Text = "設定"
        '
        'btnDeleteGroup
        '
        Me.btnDeleteGroup.Location = New System.Drawing.Point(191, 229)
        Me.btnDeleteGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteGroup.Name = "btnDeleteGroup"
        Me.btnDeleteGroup.Size = New System.Drawing.Size(82, 26)
        Me.btnDeleteGroup.TabIndex = 6
        Me.btnDeleteGroup.Text = "グループ削除"
        Me.btnDeleteGroup.UseVisualStyleBackColor = True
        '
        'picColor
        '
        Me.picColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picColor.Location = New System.Drawing.Point(92, 227)
        Me.picColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picColor.Name = "picColor"
        Me.picColor.Size = New System.Drawing.Size(44, 28)
        Me.picColor.TabIndex = 21
        Me.picColor.TabStop = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 227)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 27)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "マップエディタ上の代表点の色"
        '
        'gbObjShape
        '
        Me.gbObjShape.Controls.Add(Me.rbPolygon)
        Me.gbObjShape.Controls.Add(Me.rbLine)
        Me.gbObjShape.Controls.Add(Me.rbPoint)
        Me.gbObjShape.Controls.Add(Me.rbNoShape)
        Me.gbObjShape.Location = New System.Drawing.Point(14, 138)
        Me.gbObjShape.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjShape.Name = "gbObjShape"
        Me.gbObjShape.Padding = New System.Windows.Forms.Padding(2)
        Me.gbObjShape.Size = New System.Drawing.Size(130, 74)
        Me.gbObjShape.TabIndex = 3
        Me.gbObjShape.TabStop = False
        Me.gbObjShape.Text = "オブジェクトの形状"
        '
        'rbPolygon
        '
        Me.rbPolygon.AutoSize = True
        Me.rbPolygon.Location = New System.Drawing.Point(86, 44)
        Me.rbPolygon.Margin = New System.Windows.Forms.Padding(2)
        Me.rbPolygon.Name = "rbPolygon"
        Me.rbPolygon.Size = New System.Drawing.Size(35, 16)
        Me.rbPolygon.TabIndex = 3
        Me.rbPolygon.TabStop = True
        Me.rbPolygon.Text = "面"
        Me.rbPolygon.UseVisualStyleBackColor = True
        '
        'rbLine
        '
        Me.rbLine.AutoSize = True
        Me.rbLine.Location = New System.Drawing.Point(50, 44)
        Me.rbLine.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLine.Name = "rbLine"
        Me.rbLine.Size = New System.Drawing.Size(35, 16)
        Me.rbLine.TabIndex = 2
        Me.rbLine.TabStop = True
        Me.rbLine.Text = "線"
        Me.rbLine.UseVisualStyleBackColor = True
        '
        'rbPoint
        '
        Me.rbPoint.AutoSize = True
        Me.rbPoint.Location = New System.Drawing.Point(13, 44)
        Me.rbPoint.Margin = New System.Windows.Forms.Padding(2)
        Me.rbPoint.Name = "rbPoint"
        Me.rbPoint.Size = New System.Drawing.Size(35, 16)
        Me.rbPoint.TabIndex = 1
        Me.rbPoint.TabStop = True
        Me.rbPoint.Text = "点"
        Me.rbPoint.UseVisualStyleBackColor = True
        '
        'rbNoShape
        '
        Me.rbNoShape.AutoSize = True
        Me.rbNoShape.Location = New System.Drawing.Point(13, 24)
        Me.rbNoShape.Margin = New System.Windows.Forms.Padding(2)
        Me.rbNoShape.Name = "rbNoShape"
        Me.rbNoShape.Size = New System.Drawing.Size(66, 16)
        Me.rbNoShape.TabIndex = 0
        Me.rbNoShape.TabStop = True
        Me.rbNoShape.Text = "指定なし"
        Me.rbNoShape.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbObjectTypeAggrigation)
        Me.GroupBox2.Controls.Add(Me.rbObjectTypeNormal)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 70)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(130, 52)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "オブジェクトのタイプ"
        '
        'rbObjectTypeAggrigation
        '
        Me.rbObjectTypeAggrigation.AutoSize = True
        Me.rbObjectTypeAggrigation.Location = New System.Drawing.Point(72, 24)
        Me.rbObjectTypeAggrigation.Margin = New System.Windows.Forms.Padding(2)
        Me.rbObjectTypeAggrigation.Name = "rbObjectTypeAggrigation"
        Me.rbObjectTypeAggrigation.Size = New System.Drawing.Size(47, 16)
        Me.rbObjectTypeAggrigation.TabIndex = 1
        Me.rbObjectTypeAggrigation.TabStop = True
        Me.rbObjectTypeAggrigation.Text = "集成"
        Me.rbObjectTypeAggrigation.UseVisualStyleBackColor = True
        '
        'rbObjectTypeNormal
        '
        Me.rbObjectTypeNormal.AutoSize = True
        Me.rbObjectTypeNormal.Location = New System.Drawing.Point(13, 24)
        Me.rbObjectTypeNormal.Margin = New System.Windows.Forms.Padding(2)
        Me.rbObjectTypeNormal.Name = "rbObjectTypeNormal"
        Me.rbObjectTypeNormal.Size = New System.Drawing.Size(47, 16)
        Me.rbObjectTypeNormal.TabIndex = 0
        Me.rbObjectTypeNormal.TabStop = True
        Me.rbObjectTypeNormal.Text = "通常"
        Me.rbObjectTypeNormal.UseVisualStyleBackColor = True
        '
        'txtNewName
        '
        Me.txtNewName.Location = New System.Drawing.Point(14, 38)
        Me.txtNewName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNewName.Name = "txtNewName"
        Me.txtNewName.Size = New System.Drawing.Size(238, 19)
        Me.txtNewName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 24)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "オブジェクトグループの名称"
        '
        'gbUseLineKind
        '
        Me.gbUseLineKind.Controls.Add(Me.clbUseLineKind)
        Me.gbUseLineKind.Location = New System.Drawing.Point(176, 70)
        Me.gbUseLineKind.Margin = New System.Windows.Forms.Padding(2)
        Me.gbUseLineKind.Name = "gbUseLineKind"
        Me.gbUseLineKind.Padding = New System.Windows.Forms.Padding(2)
        Me.gbUseLineKind.Size = New System.Drawing.Size(204, 142)
        Me.gbUseLineKind.TabIndex = 5
        Me.gbUseLineKind.TabStop = False
        Me.gbUseLineKind.Text = "使用する線種"
        '
        'clbUseLineKind
        '
        Me.clbUseLineKind.CheckOnClick = True
        Me.clbUseLineKind.FormattingEnabled = True
        Me.clbUseLineKind.Location = New System.Drawing.Point(13, 25)
        Me.clbUseLineKind.Margin = New System.Windows.Forms.Padding(2)
        Me.clbUseLineKind.Name = "clbUseLineKind"
        Me.clbUseLineKind.Size = New System.Drawing.Size(175, 102)
        Me.clbUseLineKind.TabIndex = 0
        '
        'gbUseObjectGroup
        '
        Me.gbUseObjectGroup.Controls.Add(Me.clbUseObjectGroup)
        Me.gbUseObjectGroup.Location = New System.Drawing.Point(176, 70)
        Me.gbUseObjectGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.gbUseObjectGroup.Name = "gbUseObjectGroup"
        Me.gbUseObjectGroup.Padding = New System.Windows.Forms.Padding(2)
        Me.gbUseObjectGroup.Size = New System.Drawing.Size(200, 142)
        Me.gbUseObjectGroup.TabIndex = 25
        Me.gbUseObjectGroup.TabStop = False
        Me.gbUseObjectGroup.Text = "使用するオブジェクトグループ"
        '
        'clbUseObjectGroup
        '
        Me.clbUseObjectGroup.CheckOnClick = True
        Me.clbUseObjectGroup.FormattingEnabled = True
        Me.clbUseObjectGroup.Location = New System.Drawing.Point(13, 26)
        Me.clbUseObjectGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.clbUseObjectGroup.Name = "clbUseObjectGroup"
        Me.clbUseObjectGroup.Size = New System.Drawing.Size(175, 102)
        Me.clbUseObjectGroup.TabIndex = 0
        '
        'frmMED_ObjectKind
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(603, 354)
        Me.Controls.Add(Me.gbSet)
        Me.Controls.Add(Me.btnAddGroup)
        Me.Controls.Add(Me.btnDownword)
        Me.Controls.Add(Me.btnUpword)
        Me.Controls.Add(Me.lbObjectKind)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_ObjectKind"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オブジェクトグループ設定"
        Me.gbSet.ResumeLayout(False)
        Me.gbSet.PerformLayout()
        CType(Me.picColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbObjShape.ResumeLayout(False)
        Me.gbObjShape.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbUseLineKind.ResumeLayout(False)
        Me.gbUseObjectGroup.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbObjectKind As System.Windows.Forms.ListBox
    Friend WithEvents btnUpword As System.Windows.Forms.Button
    Friend WithEvents btnDownword As System.Windows.Forms.Button
    Friend WithEvents btnAddGroup As System.Windows.Forms.Button
    Friend WithEvents gbSet As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbObjShape As System.Windows.Forms.GroupBox
    Friend WithEvents rbPolygon As System.Windows.Forms.RadioButton
    Friend WithEvents rbLine As System.Windows.Forms.RadioButton
    Friend WithEvents rbPoint As System.Windows.Forms.RadioButton
    Friend WithEvents rbNoShape As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbObjectTypeAggrigation As System.Windows.Forms.RadioButton
    Friend WithEvents rbObjectTypeNormal As System.Windows.Forms.RadioButton
    Friend WithEvents txtNewName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbUseObjectGroup As System.Windows.Forms.GroupBox
    Friend WithEvents gbUseLineKind As System.Windows.Forms.GroupBox
    Friend WithEvents btnDeleteGroup As System.Windows.Forms.Button
    Friend WithEvents picColor As System.Windows.Forms.PictureBox
    Friend WithEvents clbUseObjectGroup As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbUseLineKind As System.Windows.Forms.CheckedListBox
End Class
