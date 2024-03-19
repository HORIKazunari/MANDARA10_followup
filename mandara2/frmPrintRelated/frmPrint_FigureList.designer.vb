<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_FigureList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint_FigureList))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbItemData = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnErase = New System.Windows.Forms.Button()
        Me.btnPositionDown = New System.Windows.Forms.Button()
        Me.btnPositionUp = New System.Windows.Forms.Button()
        Me.cboData = New mandara10.ComboBoxEx()
        Me.cboLayer = New mandara10.ComboBoxEx()
        Me.ListView = New mandara10.ListViewEX()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.gbItemData.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(348, 314)
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
        Me.btnOK.Location = New System.Drawing.Point(281, 314)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 21
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "図形一覧"
        '
        'gbItemData
        '
        Me.gbItemData.Controls.Add(Me.btnEdit)
        Me.gbItemData.Controls.Add(Me.cboData)
        Me.gbItemData.Controls.Add(Me.cboLayer)
        Me.gbItemData.Controls.Add(Me.Label2)
        Me.gbItemData.Controls.Add(Me.Label3)
        Me.gbItemData.Controls.Add(Me.btnErase)
        Me.gbItemData.Controls.Add(Me.btnPositionDown)
        Me.gbItemData.Controls.Add(Me.btnPositionUp)
        Me.gbItemData.Location = New System.Drawing.Point(12, 222)
        Me.gbItemData.Name = "gbItemData"
        Me.gbItemData.Size = New System.Drawing.Size(398, 75)
        Me.gbItemData.TabIndex = 25
        Me.gbItemData.TabStop = False
        Me.gbItemData.Text = "選択図形"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(94, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "表示データ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(93, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 12)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "表示レイヤ"
        '
        'btnErase
        '
        Me.btnErase.Location = New System.Drawing.Point(318, 17)
        Me.btnErase.Margin = New System.Windows.Forms.Padding(2)
        Me.btnErase.Name = "btnErase"
        Me.btnErase.Size = New System.Drawing.Size(60, 22)
        Me.btnErase.TabIndex = 10
        Me.btnErase.Text = "削除"
        Me.btnErase.UseVisualStyleBackColor = True
        '
        'btnPositionDown
        '
        Me.btnPositionDown.BackgroundImage = CType(resources.GetObject("btnPositionDown.BackgroundImage"), System.Drawing.Image)
        Me.btnPositionDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPositionDown.Location = New System.Drawing.Point(48, 17)
        Me.btnPositionDown.Name = "btnPositionDown"
        Me.btnPositionDown.Size = New System.Drawing.Size(30, 33)
        Me.btnPositionDown.TabIndex = 9
        Me.btnPositionDown.UseVisualStyleBackColor = True
        '
        'btnPositionUp
        '
        Me.btnPositionUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPositionUp.Image = CType(resources.GetObject("btnPositionUp.Image"), System.Drawing.Image)
        Me.btnPositionUp.Location = New System.Drawing.Point(12, 16)
        Me.btnPositionUp.Name = "btnPositionUp"
        Me.btnPositionUp.Size = New System.Drawing.Size(30, 34)
        Me.btnPositionUp.TabIndex = 8
        Me.btnPositionUp.UseVisualStyleBackColor = True
        '
        'cboData
        '
        Me.cboData.AsteriskSelectEnabled = False
        Me.cboData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboData.FormattingEnabled = True
        Me.cboData.IntegralHeight = False
        Me.cboData.Location = New System.Drawing.Point(157, 42)
        Me.cboData.Name = "cboData"
        Me.cboData.Size = New System.Drawing.Size(113, 20)
        Me.cboData.TabIndex = 14
        '
        'cboLayer
        '
        Me.cboLayer.AsteriskSelectEnabled = False
        Me.cboLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayer.FormattingEnabled = True
        Me.cboLayer.IntegralHeight = False
        Me.cboLayer.Location = New System.Drawing.Point(157, 16)
        Me.cboLayer.Name = "cboLayer"
        Me.cboLayer.Size = New System.Drawing.Size(113, 20)
        Me.cboLayer.TabIndex = 13
        '
        'ListView
        '
        Me.ListView.FullRowSelect = True
        Me.ListView.GridLines = True
        Me.ListView.HideSelection = False
        Me.ListView.Location = New System.Drawing.Point(11, 26)
        Me.ListView.Margin = New System.Windows.Forms.Padding(2)
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(399, 191)
        Me.ListView.TabIndex = 23
        Me.ListView.UseCompatibleStateImageBehavior = False
        Me.ListView.View = System.Windows.Forms.View.Details
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(318, 45)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(60, 22)
        Me.btnEdit.TabIndex = 15
        Me.btnEdit.Text = "編集"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'frmPrint_FigureList
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(424, 349)
        Me.Controls.Add(Me.gbItemData)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_FigureList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "図形一覧"
        Me.gbItemData.ResumeLayout(False)
        Me.gbItemData.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ListView As mandara10.ListViewEX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbItemData As System.Windows.Forms.GroupBox
    Friend WithEvents btnErase As System.Windows.Forms.Button
    Friend WithEvents btnPositionDown As System.Windows.Forms.Button
    Friend WithEvents btnPositionUp As System.Windows.Forms.Button
    Friend WithEvents cboData As mandara10.ComboBoxEx
    Friend WithEvents cboLayer As mandara10.ComboBoxEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
End Class
