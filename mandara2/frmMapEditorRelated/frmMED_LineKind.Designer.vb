<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_LineKind
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMED_LineKind))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAddLineKind = New System.Windows.Forms.Button()
        Me.btnDownword = New System.Windows.Forms.Button()
        Me.btnUpword = New System.Windows.Forms.Button()
        Me.lbLineKind = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbSet = New System.Windows.Forms.GroupBox()
        Me.gbObjectGroup = New System.Windows.Forms.GroupBox()
        Me.btnObjGAdd = New System.Windows.Forms.Button()
        Me.lbObjG = New System.Windows.Forms.ListBox()
        Me.cbObjG = New System.Windows.Forms.CheckBox()
        Me.btnObjDelete = New System.Windows.Forms.Button()
        Me.btnObjDownward = New System.Windows.Forms.Button()
        Me.btnObjUpward = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.picObjGLine = New System.Windows.Forms.PictureBox()
        Me.lblPattern = New System.Windows.Forms.Label()
        Me.btnDeleteLineKind = New System.Windows.Forms.Button()
        Me.picLine = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbLineKindObjectGroup = New System.Windows.Forms.RadioButton()
        Me.rbLineKindNormal = New System.Windows.Forms.RadioButton()
        Me.txtNewName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.gbSet.SuspendLayout()
        Me.gbObjectGroup.SuspendLayout()
        CType(Me.picObjGLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(498, 255)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 26)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAddLineKind
        '
        Me.btnAddLineKind.Location = New System.Drawing.Point(42, 255)
        Me.btnAddLineKind.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddLineKind.Name = "btnAddLineKind"
        Me.btnAddLineKind.Size = New System.Drawing.Size(82, 26)
        Me.btnAddLineKind.TabIndex = 3
        Me.btnAddLineKind.Text = "線種追加"
        Me.btnAddLineKind.UseVisualStyleBackColor = True
        '
        'btnDownword
        '
        Me.btnDownword.Image = CType(resources.GetObject("btnDownword.Image"), System.Drawing.Image)
        Me.btnDownword.Location = New System.Drawing.Point(88, 206)
        Me.btnDownword.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDownword.Name = "btnDownword"
        Me.btnDownword.Size = New System.Drawing.Size(36, 34)
        Me.btnDownword.TabIndex = 2
        Me.btnDownword.UseVisualStyleBackColor = True
        '
        'btnUpword
        '
        Me.btnUpword.Image = CType(resources.GetObject("btnUpword.Image"), System.Drawing.Image)
        Me.btnUpword.Location = New System.Drawing.Point(42, 206)
        Me.btnUpword.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpword.Name = "btnUpword"
        Me.btnUpword.Size = New System.Drawing.Size(36, 34)
        Me.btnUpword.TabIndex = 1
        Me.btnUpword.UseVisualStyleBackColor = True
        '
        'lbLineKind
        '
        Me.lbLineKind.FormattingEnabled = True
        Me.lbLineKind.ItemHeight = 12
        Me.lbLineKind.Location = New System.Drawing.Point(9, 34)
        Me.lbLineKind.Margin = New System.Windows.Forms.Padding(2)
        Me.lbLineKind.Name = "lbLineKind"
        Me.lbLineKind.Size = New System.Drawing.Size(151, 160)
        Me.lbLineKind.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 12)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "編集する線種"
        '
        'gbSet
        '
        Me.gbSet.Controls.Add(Me.gbObjectGroup)
        Me.gbSet.Controls.Add(Me.lblPattern)
        Me.gbSet.Controls.Add(Me.btnDeleteLineKind)
        Me.gbSet.Controls.Add(Me.picLine)
        Me.gbSet.Controls.Add(Me.GroupBox1)
        Me.gbSet.Controls.Add(Me.txtNewName)
        Me.gbSet.Controls.Add(Me.Label2)
        Me.gbSet.Location = New System.Drawing.Point(176, 31)
        Me.gbSet.Margin = New System.Windows.Forms.Padding(2)
        Me.gbSet.Name = "gbSet"
        Me.gbSet.Padding = New System.Windows.Forms.Padding(2)
        Me.gbSet.Size = New System.Drawing.Size(403, 209)
        Me.gbSet.TabIndex = 4
        Me.gbSet.TabStop = False
        '
        'gbObjectGroup
        '
        Me.gbObjectGroup.Controls.Add(Me.btnObjGAdd)
        Me.gbObjectGroup.Controls.Add(Me.lbObjG)
        Me.gbObjectGroup.Controls.Add(Me.cbObjG)
        Me.gbObjectGroup.Controls.Add(Me.btnObjDelete)
        Me.gbObjectGroup.Controls.Add(Me.btnObjDownward)
        Me.gbObjectGroup.Controls.Add(Me.btnObjUpward)
        Me.gbObjectGroup.Controls.Add(Me.Label4)
        Me.gbObjectGroup.Controls.Add(Me.picObjGLine)
        Me.gbObjectGroup.Location = New System.Drawing.Point(173, 17)
        Me.gbObjectGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.gbObjectGroup.Name = "gbObjectGroup"
        Me.gbObjectGroup.Padding = New System.Windows.Forms.Padding(2)
        Me.gbObjectGroup.Size = New System.Drawing.Size(226, 182)
        Me.gbObjectGroup.TabIndex = 3
        Me.gbObjectGroup.TabStop = False
        Me.gbObjectGroup.Text = "オブジェクトグループ連動"
        '
        'btnObjGAdd
        '
        Me.btnObjGAdd.Location = New System.Drawing.Point(142, 150)
        Me.btnObjGAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjGAdd.Name = "btnObjGAdd"
        Me.btnObjGAdd.Size = New System.Drawing.Size(68, 26)
        Me.btnObjGAdd.TabIndex = 6
        Me.btnObjGAdd.Text = "追加"
        Me.btnObjGAdd.UseVisualStyleBackColor = True
        '
        'lbObjG
        '
        Me.lbObjG.FormattingEnabled = True
        Me.lbObjG.ItemHeight = 12
        Me.lbObjG.Location = New System.Drawing.Point(14, 25)
        Me.lbObjG.Margin = New System.Windows.Forms.Padding(2)
        Me.lbObjG.Name = "lbObjG"
        Me.lbObjG.Size = New System.Drawing.Size(121, 88)
        Me.lbObjG.TabIndex = 0
        '
        'cbObjG
        '
        Me.cbObjG.Location = New System.Drawing.Point(142, 83)
        Me.cbObjG.Margin = New System.Windows.Forms.Padding(2)
        Me.cbObjG.Name = "cbObjG"
        Me.cbObjG.Size = New System.Drawing.Size(75, 42)
        Me.cbObjG.TabIndex = 4
        Me.cbObjG.Text = "レイヤ内での使用に限定"
        Me.cbObjG.UseVisualStyleBackColor = True
        '
        'btnObjDelete
        '
        Me.btnObjDelete.Location = New System.Drawing.Point(73, 150)
        Me.btnObjDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjDelete.Name = "btnObjDelete"
        Me.btnObjDelete.Size = New System.Drawing.Size(62, 26)
        Me.btnObjDelete.TabIndex = 5
        Me.btnObjDelete.Text = "削除"
        Me.btnObjDelete.UseVisualStyleBackColor = True
        '
        'btnObjDownward
        '
        Me.btnObjDownward.Image = CType(resources.GetObject("btnObjDownward.Image"), System.Drawing.Image)
        Me.btnObjDownward.Location = New System.Drawing.Point(73, 117)
        Me.btnObjDownward.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjDownward.Name = "btnObjDownward"
        Me.btnObjDownward.Size = New System.Drawing.Size(31, 29)
        Me.btnObjDownward.TabIndex = 3
        Me.btnObjDownward.UseVisualStyleBackColor = True
        '
        'btnObjUpward
        '
        Me.btnObjUpward.Image = CType(resources.GetObject("btnObjUpward.Image"), System.Drawing.Image)
        Me.btnObjUpward.Location = New System.Drawing.Point(38, 117)
        Me.btnObjUpward.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjUpward.Name = "btnObjUpward"
        Me.btnObjUpward.Size = New System.Drawing.Size(31, 29)
        Me.btnObjUpward.TabIndex = 2
        Me.btnObjUpward.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(139, 34)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 12)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "パターン"
        '
        'picObjGLine
        '
        Me.picObjGLine.BackColor = System.Drawing.Color.White
        Me.picObjGLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picObjGLine.Location = New System.Drawing.Point(142, 49)
        Me.picObjGLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picObjGLine.Name = "picObjGLine"
        Me.picObjGLine.Size = New System.Drawing.Size(60, 26)
        Me.picObjGLine.TabIndex = 27
        Me.picObjGLine.TabStop = False
        '
        'lblPattern
        '
        Me.lblPattern.AutoSize = True
        Me.lblPattern.Location = New System.Drawing.Point(4, 145)
        Me.lblPattern.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPattern.Name = "lblPattern"
        Me.lblPattern.Size = New System.Drawing.Size(42, 12)
        Me.lblPattern.TabIndex = 26
        Me.lblPattern.Text = "パターン"
        '
        'btnDeleteLineKind
        '
        Me.btnDeleteLineKind.Location = New System.Drawing.Point(86, 159)
        Me.btnDeleteLineKind.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteLineKind.Name = "btnDeleteLineKind"
        Me.btnDeleteLineKind.Size = New System.Drawing.Size(73, 26)
        Me.btnDeleteLineKind.TabIndex = 2
        Me.btnDeleteLineKind.Text = "線種削除"
        Me.btnDeleteLineKind.UseVisualStyleBackColor = True
        '
        'picLine
        '
        Me.picLine.BackColor = System.Drawing.Color.White
        Me.picLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLine.Location = New System.Drawing.Point(7, 159)
        Me.picLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picLine.Name = "picLine"
        Me.picLine.Size = New System.Drawing.Size(68, 26)
        Me.picLine.TabIndex = 24
        Me.picLine.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbLineKindObjectGroup)
        Me.GroupBox1.Controls.Add(Me.rbLineKindNormal)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 66)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(155, 76)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "タイプ"
        '
        'rbLineKindObjectGroup
        '
        Me.rbLineKindObjectGroup.Location = New System.Drawing.Point(10, 34)
        Me.rbLineKindObjectGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLineKindObjectGroup.Name = "rbLineKindObjectGroup"
        Me.rbLineKindObjectGroup.Size = New System.Drawing.Size(141, 36)
        Me.rbLineKindObjectGroup.TabIndex = 3
        Me.rbLineKindObjectGroup.TabStop = True
        Me.rbLineKindObjectGroup.Text = "オブジェクトグループ連動"
        Me.rbLineKindObjectGroup.UseVisualStyleBackColor = True
        '
        'rbLineKindNormal
        '
        Me.rbLineKindNormal.AutoSize = True
        Me.rbLineKindNormal.Location = New System.Drawing.Point(10, 16)
        Me.rbLineKindNormal.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLineKindNormal.Name = "rbLineKindNormal"
        Me.rbLineKindNormal.Size = New System.Drawing.Size(47, 16)
        Me.rbLineKindNormal.TabIndex = 2
        Me.rbLineKindNormal.TabStop = True
        Me.rbLineKindNormal.Text = "通常"
        Me.rbLineKindNormal.UseVisualStyleBackColor = True
        '
        'txtNewName
        '
        Me.txtNewName.Location = New System.Drawing.Point(4, 30)
        Me.txtNewName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNewName.Name = "txtNewName"
        Me.txtNewName.Size = New System.Drawing.Size(154, 19)
        Me.txtNewName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 12)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "線種の名称"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(422, 255)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 26)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmMED_LineKind
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(594, 292)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.gbSet)
        Me.Controls.Add(Me.btnAddLineKind)
        Me.Controls.Add(Me.btnDownword)
        Me.Controls.Add(Me.btnUpword)
        Me.Controls.Add(Me.lbLineKind)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_LineKind"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "線種設定"
        Me.gbSet.ResumeLayout(False)
        Me.gbSet.PerformLayout()
        Me.gbObjectGroup.ResumeLayout(False)
        Me.gbObjectGroup.PerformLayout()
        CType(Me.picObjGLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAddLineKind As System.Windows.Forms.Button
    Friend WithEvents btnDownword As System.Windows.Forms.Button
    Friend WithEvents btnUpword As System.Windows.Forms.Button
    Friend WithEvents lbLineKind As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbSet As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNewName As System.Windows.Forms.TextBox
    Friend WithEvents rbLineKindObjectGroup As System.Windows.Forms.RadioButton
    Friend WithEvents rbLineKindNormal As System.Windows.Forms.RadioButton
    Friend WithEvents picLine As System.Windows.Forms.PictureBox
    Friend WithEvents gbObjectGroup As System.Windows.Forms.GroupBox
    Friend WithEvents lbObjG As System.Windows.Forms.ListBox
    Friend WithEvents cbObjG As System.Windows.Forms.CheckBox
    Friend WithEvents btnObjDelete As System.Windows.Forms.Button
    Friend WithEvents btnObjDownward As System.Windows.Forms.Button
    Friend WithEvents btnObjUpward As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents picObjGLine As System.Windows.Forms.PictureBox
    Friend WithEvents lblPattern As System.Windows.Forms.Label
    Friend WithEvents btnDeleteLineKind As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnObjGAdd As System.Windows.Forms.Button
End Class
