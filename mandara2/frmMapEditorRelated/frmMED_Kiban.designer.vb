<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_Kiban
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
        Me.KibanFolder = New KTGISUserControl.KtgisFolderSelector()
        Me.gbProjection = New System.Windows.Forms.GroupBox()
        Me.cbProjection = New mandara10.ComboBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.clbType = New mandara10.CheckedListBoxEx()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.lbFile = New mandara10.ListBoxEx()
        Me.gbProjection.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(453, 427)
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
        Me.btnOK.Location = New System.Drawing.Point(386, 427)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 21
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'KibanFolder
        '
        Me.KibanFolder.AddFolder_Flag = False
        Me.KibanFolder.Caption = "データフォルダ"
        Me.KibanFolder.Folder = ""
        Me.KibanFolder.Location = New System.Drawing.Point(20, 21)
        Me.KibanFolder.Margin = New System.Windows.Forms.Padding(2)
        Me.KibanFolder.Name = "KibanFolder"
        Me.KibanFolder.Size = New System.Drawing.Size(285, 42)
        Me.KibanFolder.TabIndex = 23
        '
        'gbProjection
        '
        Me.gbProjection.Controls.Add(Me.cbProjection)
        Me.gbProjection.Location = New System.Drawing.Point(20, 360)
        Me.gbProjection.Name = "gbProjection"
        Me.gbProjection.Size = New System.Drawing.Size(169, 47)
        Me.gbProjection.TabIndex = 26
        Me.gbProjection.TabStop = False
        Me.gbProjection.Text = "投影法"
        '
        'cbProjection
        '
        Me.cbProjection.AsteriskSelectEnabled = False
        Me.cbProjection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProjection.FormattingEnabled = True
        Me.cbProjection.IntegralHeight = False
        Me.cbProjection.Location = New System.Drawing.Point(20, 20)
        Me.cbProjection.Name = "cbProjection"
        Me.cbProjection.Size = New System.Drawing.Size(131, 20)
        Me.cbProjection.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "取得項目"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(198, 12)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "該当ファイル一覧および取得ファイル選択"
        '
        'clbType
        '
        Me.clbType.CheckOnClick = True
        Me.clbType.EventStop = True
        Me.clbType.FormattingEnabled = True
        Me.clbType.Location = New System.Drawing.Point(21, 84)
        Me.clbType.Name = "clbType"
        Me.clbType.Size = New System.Drawing.Size(168, 270)
        Me.clbType.TabIndex = 29
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(23, 429)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(175, 21)
        Me.ProgressBar.TabIndex = 30
        Me.ProgressBar.Visible = False
        '
        'lbFile
        '
        Me.lbFile.AsteriskSelectEnabled = False
        Me.lbFile.FormattingEnabled = True
        Me.lbFile.ItemHeight = 12
        Me.lbFile.Location = New System.Drawing.Point(207, 86)
        Me.lbFile.Name = "lbFile"
        Me.lbFile.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbFile.Size = New System.Drawing.Size(307, 316)
        Me.lbFile.TabIndex = 31
        '
        'frmMED_Kiban
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(527, 462)
        Me.Controls.Add(Me.lbFile)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.clbType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbProjection)
        Me.Controls.Add(Me.KibanFolder)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_Kiban"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "基盤地図情報読み込み"
        Me.gbProjection.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents KibanFolder As KTGISUserControl.KtgisFolderSelector
    Friend WithEvents gbProjection As System.Windows.Forms.GroupBox
    Friend WithEvents cbProjection As mandara10.ComboBoxEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents clbType As mandara10.CheckedListBoxEx
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lbFile As mandara10.ListBoxEx
End Class
