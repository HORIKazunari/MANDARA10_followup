<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_DefTimeAttData_ValueSet
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
        Me.初期時間属性データ項目 = New System.Windows.Forms.GroupBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblObjectGroup = New System.Windows.Forms.Label()
        Me.lblMissing = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.ktGrid = New KTGISUserControl.KTGISGrid()
        Me.btmCheck = New System.Windows.Forms.Button()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.初期時間属性データ項目.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(296, 446)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(376, 444)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 26)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        '初期時間属性データ項目
        '
        Me.初期時間属性データ項目.Controls.Add(Me.lblType)
        Me.初期時間属性データ項目.Controls.Add(Me.lblObjectGroup)
        Me.初期時間属性データ項目.Controls.Add(Me.lblMissing)
        Me.初期時間属性データ項目.Controls.Add(Me.lblUnit)
        Me.初期時間属性データ項目.Controls.Add(Me.lblTitle)
        Me.初期時間属性データ項目.Location = New System.Drawing.Point(12, 12)
        Me.初期時間属性データ項目.Name = "初期時間属性データ項目"
        Me.初期時間属性データ項目.Size = New System.Drawing.Size(432, 107)
        Me.初期時間属性データ項目.TabIndex = 0
        Me.初期時間属性データ項目.TabStop = False
        Me.初期時間属性データ項目.Text = "初期時間属性データ項目"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(17, 65)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(38, 12)
        Me.lblType.TabIndex = 4
        Me.lblType.Text = "Label3"
        '
        'lblObjectGroup
        '
        Me.lblObjectGroup.AutoSize = True
        Me.lblObjectGroup.Location = New System.Drawing.Point(17, 44)
        Me.lblObjectGroup.Name = "lblObjectGroup"
        Me.lblObjectGroup.Size = New System.Drawing.Size(38, 12)
        Me.lblObjectGroup.TabIndex = 3
        Me.lblObjectGroup.Text = "Label3"
        '
        'lblMissing
        '
        Me.lblMissing.AutoSize = True
        Me.lblMissing.Location = New System.Drawing.Point(207, 83)
        Me.lblMissing.Name = "lblMissing"
        Me.lblMissing.Size = New System.Drawing.Size(38, 12)
        Me.lblMissing.TabIndex = 2
        Me.lblMissing.Text = "Label3"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(17, 83)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(38, 12)
        Me.lblUnit.TabIndex = 1
        Me.lblUnit.Text = "Label3"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(17, 22)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(44, 12)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Label3"
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
        Me.ktGrid.Location = New System.Drawing.Point(13, 205)
        Me.ktGrid.MsgBoxTitle = ""
        Me.ktGrid.Name = "ktGrid"
        Me.ktGrid.RowCaption = Nothing
        Me.ktGrid.Size = New System.Drawing.Size(431, 226)
        Me.ktGrid.TabClickEnabled = False
        Me.ktGrid.TabIndex = 3
        '
        'btmCheck
        '
        Me.btmCheck.Location = New System.Drawing.Point(148, 153)
        Me.btmCheck.Margin = New System.Windows.Forms.Padding(2)
        Me.btmCheck.Name = "btmCheck"
        Me.btmCheck.Size = New System.Drawing.Size(47, 24)
        Me.btmCheck.TabIndex = 2
        Me.btmCheck.Text = "チェック"
        Me.btmCheck.UseVisualStyleBackColor = True
        '
        'btnGetData
        '
        Me.btnGetData.Location = New System.Drawing.Point(12, 153)
        Me.btnGetData.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(117, 24)
        Me.btnGetData.TabIndex = 1
        Me.btnGetData.Text = "クリップボードから取得"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 190)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "データ"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(12, 129)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(126, 12)
        Me.lblTime.TabIndex = 7
        Me.lblTime.Text = "オブジェクト名の検索時期"
        '
        'frmMED_DefTimeAttData_ValueSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 486)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ktGrid)
        Me.Controls.Add(Me.btmCheck)
        Me.Controls.Add(Me.btnGetData)
        Me.Controls.Add(Me.初期時間属性データ項目)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_DefTimeAttData_ValueSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "初期時間属性データ一括設定"
        Me.初期時間属性データ項目.ResumeLayout(False)
        Me.初期時間属性データ項目.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents 初期時間属性データ項目 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMissing As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents ktGrid As KTGISUserControl.KTGISGrid
    Friend WithEvents btmCheck As System.Windows.Forms.Button
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents lblObjectGroup As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
End Class
