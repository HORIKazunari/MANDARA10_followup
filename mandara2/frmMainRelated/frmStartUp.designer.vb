<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStartUp))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnEnd = New System.Windows.Forms.Button()
        Me.btnVersion = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbRecentFile = New mandara10.ListBoxEx()
        Me.rbMapEditor = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbShapeFile = New System.Windows.Forms.RadioButton()
        Me.rbWhiteMap = New System.Windows.Forms.RadioButton()
        Me.rbNewData = New System.Windows.Forms.RadioButton()
        Me.rbRecent = New System.Windows.Forms.RadioButton()
        Me.rbDataFile = New System.Windows.Forms.RadioButton()
        Me.rbClipBoard = New System.Windows.Forms.RadioButton()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(147, 329)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(81, 329)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnEnd
        '
        Me.btnEnd.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.btnEnd.Location = New System.Drawing.Point(214, 330)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(62, 23)
        Me.btnEnd.TabIndex = 3
        Me.btnEnd.Text = "終了"
        Me.btnEnd.UseVisualStyleBackColor = True
        '
        'btnVersion
        '
        Me.btnVersion.Location = New System.Drawing.Point(157, 359)
        Me.btnVersion.Name = "btnVersion"
        Me.btnVersion.Size = New System.Drawing.Size(119, 23)
        Me.btnVersion.TabIndex = 4
        Me.btnVersion.Text = "バージョン情報"
        Me.btnVersion.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbRecentFile)
        Me.GroupBox1.Controls.Add(Me.rbMapEditor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rbShapeFile)
        Me.GroupBox1.Controls.Add(Me.rbWhiteMap)
        Me.GroupBox1.Controls.Add(Me.rbNewData)
        Me.GroupBox1.Controls.Add(Me.rbRecent)
        Me.GroupBox1.Controls.Add(Me.rbDataFile)
        Me.GroupBox1.Controls.Add(Me.rbClipBoard)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 298)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "操作選択"
        '
        'lbRecentFile
        '
        Me.lbRecentFile.AsteriskSelectEnabled = False
        Me.lbRecentFile.FormattingEnabled = True
        Me.lbRecentFile.ItemHeight = 12
        Me.lbRecentFile.Location = New System.Drawing.Point(35, 97)
        Me.lbRecentFile.Name = "lbRecentFile"
        Me.lbRecentFile.Size = New System.Drawing.Size(214, 88)
        Me.lbRecentFile.TabIndex = 3
        '
        'rbMapEditor
        '
        Me.rbMapEditor.AutoSize = True
        Me.rbMapEditor.Location = New System.Drawing.Point(18, 273)
        Me.rbMapEditor.Name = "rbMapEditor"
        Me.rbMapEditor.Size = New System.Drawing.Size(82, 16)
        Me.rbMapEditor.TabIndex = 7
        Me.rbMapEditor.Text = "マップエディタ"
        Me.rbMapEditor.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(18, 263)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 1)
        Me.Label1.TabIndex = 6
        '
        'rbShapeFile
        '
        Me.rbShapeFile.AutoSize = True
        Me.rbShapeFile.Location = New System.Drawing.Point(18, 235)
        Me.rbShapeFile.Name = "rbShapeFile"
        Me.rbShapeFile.Size = New System.Drawing.Size(139, 16)
        Me.rbShapeFile.TabIndex = 6
        Me.rbShapeFile.Text = "シェープファイル読み込み"
        Me.rbShapeFile.UseVisualStyleBackColor = True
        '
        'rbWhiteMap
        '
        Me.rbWhiteMap.AutoSize = True
        Me.rbWhiteMap.Location = New System.Drawing.Point(18, 213)
        Me.rbWhiteMap.Name = "rbWhiteMap"
        Me.rbWhiteMap.Size = New System.Drawing.Size(165, 16)
        Me.rbWhiteMap.TabIndex = 5
        Me.rbWhiteMap.Text = "白地図・初期属性データ表示"
        Me.rbWhiteMap.UseVisualStyleBackColor = True
        '
        'rbNewData
        '
        Me.rbNewData.AutoSize = True
        Me.rbNewData.Location = New System.Drawing.Point(18, 191)
        Me.rbNewData.Name = "rbNewData"
        Me.rbNewData.Size = New System.Drawing.Size(111, 16)
        Me.rbNewData.TabIndex = 4
        Me.rbNewData.Text = "新しくデータを作成"
        Me.rbNewData.UseVisualStyleBackColor = True
        '
        'rbRecent
        '
        Me.rbRecent.AutoSize = True
        Me.rbRecent.Location = New System.Drawing.Point(18, 71)
        Me.rbRecent.Name = "rbRecent"
        Me.rbRecent.Size = New System.Drawing.Size(164, 16)
        Me.rbRecent.TabIndex = 2
        Me.rbRecent.Text = "最近使ったファイルを読み込む"
        Me.rbRecent.UseVisualStyleBackColor = True
        '
        'rbDataFile
        '
        Me.rbDataFile.AutoSize = True
        Me.rbDataFile.Location = New System.Drawing.Point(18, 49)
        Me.rbDataFile.Name = "rbDataFile"
        Me.rbDataFile.Size = New System.Drawing.Size(139, 16)
        Me.rbDataFile.TabIndex = 1
        Me.rbDataFile.Text = "データファイルを読み込む"
        Me.rbDataFile.UseVisualStyleBackColor = True
        '
        'rbClipBoard
        '
        Me.rbClipBoard.AutoSize = True
        Me.rbClipBoard.Checked = True
        Me.rbClipBoard.Location = New System.Drawing.Point(18, 27)
        Me.rbClipBoard.Name = "rbClipBoard"
        Me.rbClipBoard.Size = New System.Drawing.Size(175, 16)
        Me.rbClipBoard.TabIndex = 0
        Me.rbClipBoard.TabStop = True
        Me.rbClipBoard.Text = "クリップボードのデータを読み込む"
        Me.rbClipBoard.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(246, 2)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(30, 21)
        Me.btnHelp.TabIndex = 5
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmStartUp
        '
        Me.AcceptButton = Me.btnOK
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(288, 394)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnVersion)
        Me.Controls.Add(Me.btnEnd)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStartUp"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "地理情報分析支援システム　MANDARA"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnEnd As System.Windows.Forms.Button
    Friend WithEvents btnVersion As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbShapeFile As System.Windows.Forms.RadioButton
    Friend WithEvents rbWhiteMap As System.Windows.Forms.RadioButton
    Friend WithEvents rbNewData As System.Windows.Forms.RadioButton
    Friend WithEvents rbRecent As System.Windows.Forms.RadioButton
    Friend WithEvents rbDataFile As System.Windows.Forms.RadioButton
    Friend WithEvents rbClipBoard As System.Windows.Forms.RadioButton
    Friend WithEvents lbRecentFile As mandara10.ListBoxEx
    Friend WithEvents rbMapEditor As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnHelp As System.Windows.Forms.Button
End Class
