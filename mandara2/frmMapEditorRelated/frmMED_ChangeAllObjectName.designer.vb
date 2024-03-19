<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_ChangeAllObjectName
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ktGrid = New KTGISUserControl.KTGISGrid()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.cbEditingObject = New System.Windows.Forms.CheckBox()
        Me.btmCheck = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(171, 348)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(238, 346)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 26)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ktGrid
        '
        Me.ktGrid.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultFixedXNumberingWidth = 50
        Me.ktGrid.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultFixedXWidth = 150
        Me.ktGrid.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ktGrid.DefaultGridWidth = 100
        Me.ktGrid.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ktGrid.FixedGridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ktGrid.FrameColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.ktGrid.GridColor = System.Drawing.Color.White
        Me.ktGrid.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktGrid.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ktGrid.Layer = 0
        Me.ktGrid.LayerCaption = Nothing
        Me.ktGrid.Location = New System.Drawing.Point(10, 65)
        Me.ktGrid.MsgBoxTitle = ""
        Me.ktGrid.Name = "ktGrid"
        Me.ktGrid.RowCaption = Nothing
        Me.ktGrid.Size = New System.Drawing.Size(296, 241)
        Me.ktGrid.TabClickEnabled = False
        Me.ktGrid.TabIndex = 1
        '
        'btnGetData
        '
        Me.btnGetData.Location = New System.Drawing.Point(10, 21)
        Me.btnGetData.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(117, 24)
        Me.btnGetData.TabIndex = 0
        Me.btnGetData.Text = "クリップボードから取得"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'cbEditingObject
        '
        Me.cbEditingObject.AutoSize = True
        Me.cbEditingObject.Checked = True
        Me.cbEditingObject.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbEditingObject.Location = New System.Drawing.Point(11, 315)
        Me.cbEditingObject.Margin = New System.Windows.Forms.Padding(2)
        Me.cbEditingObject.Name = "cbEditingObject"
        Me.cbEditingObject.Size = New System.Drawing.Size(166, 16)
        Me.cbEditingObject.TabIndex = 2
        Me.cbEditingObject.Text = "編集対象のオブジェクトを対象"
        Me.cbEditingObject.UseVisualStyleBackColor = True
        '
        'btmCheck
        '
        Me.btmCheck.Location = New System.Drawing.Point(258, 311)
        Me.btmCheck.Margin = New System.Windows.Forms.Padding(2)
        Me.btmCheck.Name = "btmCheck"
        Me.btmCheck.Size = New System.Drawing.Size(47, 23)
        Me.btmCheck.TabIndex = 3
        Me.btmCheck.Text = "チェック"
        Me.btmCheck.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 352)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(128, 15)
        Me.ProgressBar.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 50)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "変換対応"
        '
        'frmMED_ChangeAllObjectName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(316, 384)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.btmCheck)
        Me.Controls.Add(Me.cbEditingObject)
        Me.Controls.Add(Me.btnGetData)
        Me.Controls.Add(Me.ktGrid)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_ChangeAllObjectName"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オブジェクト名一括変換"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ktGrid As KTGISUserControl.KTGISGrid
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents cbEditingObject As System.Windows.Forms.CheckBox
    Friend WithEvents btmCheck As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
