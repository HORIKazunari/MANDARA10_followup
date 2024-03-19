<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_SeriesModeSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain_SeriesModeSettings))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnReverse = New System.Windows.Forms.Button()
        Me.btnAllClear = New System.Windows.Forms.Button()
        Me.gbItemData = New System.Windows.Forms.GroupBox()
        Me.btnErase = New System.Windows.Forms.Button()
        Me.btnPositionDown = New System.Windows.Forms.Button()
        Me.btnPositionUp = New System.Windows.Forms.Button()
        Me.ListViewSeries = New mandara10.ListViewEX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboSeriesDataSet = New mandara10.ComboBoxEx()
        Me.btnDeleteDataSet = New System.Windows.Forms.Button()
        Me.lblDataSetTitle = New System.Windows.Forms.Label()
        Me.txtDataSetTitle = New System.Windows.Forms.TextBox()
        Me.btnAddDataSet = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.gbItemData.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnReverse)
        Me.GroupBox1.Controls.Add(Me.btnAllClear)
        Me.GroupBox1.Controls.Add(Me.gbItemData)
        Me.GroupBox1.Controls.Add(Me.ListViewSeries)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 135)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(498, 290)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "連続表示データ"
        '
        'btnReverse
        '
        Me.btnReverse.Location = New System.Drawing.Point(289, 251)
        Me.btnReverse.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReverse.Name = "btnReverse"
        Me.btnReverse.Size = New System.Drawing.Size(82, 22)
        Me.btnReverse.TabIndex = 1
        Me.btnReverse.Text = "反転"
        Me.btnReverse.UseVisualStyleBackColor = True
        '
        'btnAllClear
        '
        Me.btnAllClear.Location = New System.Drawing.Point(380, 250)
        Me.btnAllClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAllClear.Name = "btnAllClear"
        Me.btnAllClear.Size = New System.Drawing.Size(82, 22)
        Me.btnAllClear.TabIndex = 3
        Me.btnAllClear.Text = "すべて消去"
        Me.btnAllClear.UseVisualStyleBackColor = True
        '
        'gbItemData
        '
        Me.gbItemData.Controls.Add(Me.btnErase)
        Me.gbItemData.Controls.Add(Me.btnPositionDown)
        Me.gbItemData.Controls.Add(Me.btnPositionUp)
        Me.gbItemData.Location = New System.Drawing.Point(15, 235)
        Me.gbItemData.Margin = New System.Windows.Forms.Padding(2)
        Me.gbItemData.Name = "gbItemData"
        Me.gbItemData.Padding = New System.Windows.Forms.Padding(2)
        Me.gbItemData.Size = New System.Drawing.Size(178, 50)
        Me.gbItemData.TabIndex = 1
        Me.gbItemData.TabStop = False
        '
        'btnErase
        '
        Me.btnErase.Location = New System.Drawing.Point(86, 17)
        Me.btnErase.Margin = New System.Windows.Forms.Padding(2)
        Me.btnErase.Name = "btnErase"
        Me.btnErase.Size = New System.Drawing.Size(70, 22)
        Me.btnErase.TabIndex = 2
        Me.btnErase.Text = "消去"
        Me.btnErase.UseVisualStyleBackColor = True
        '
        'btnPositionDown
        '
        Me.btnPositionDown.BackgroundImage = CType(resources.GetObject("btnPositionDown.BackgroundImage"), System.Drawing.Image)
        Me.btnPositionDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPositionDown.Location = New System.Drawing.Point(44, 11)
        Me.btnPositionDown.Name = "btnPositionDown"
        Me.btnPositionDown.Size = New System.Drawing.Size(35, 33)
        Me.btnPositionDown.TabIndex = 1
        Me.btnPositionDown.UseVisualStyleBackColor = True
        '
        'btnPositionUp
        '
        Me.btnPositionUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPositionUp.Image = CType(resources.GetObject("btnPositionUp.Image"), System.Drawing.Image)
        Me.btnPositionUp.Location = New System.Drawing.Point(2, 10)
        Me.btnPositionUp.Name = "btnPositionUp"
        Me.btnPositionUp.Size = New System.Drawing.Size(35, 34)
        Me.btnPositionUp.TabIndex = 0
        Me.btnPositionUp.UseVisualStyleBackColor = True
        '
        'ListViewSeries
        '
        Me.ListViewSeries.FullRowSelect = True
        Me.ListViewSeries.GridLines = True
        Me.ListViewSeries.HideSelection = False
        Me.ListViewSeries.Location = New System.Drawing.Point(15, 17)
        Me.ListViewSeries.Margin = New System.Windows.Forms.Padding(2)
        Me.ListViewSeries.Name = "ListViewSeries"
        Me.ListViewSeries.Size = New System.Drawing.Size(465, 214)
        Me.ListViewSeries.TabIndex = 0
        Me.ListViewSeries.UseCompatibleStateImageBehavior = False
        Me.ListViewSeries.View = System.Windows.Forms.View.Details
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboSeriesDataSet)
        Me.GroupBox2.Controls.Add(Me.btnDeleteDataSet)
        Me.GroupBox2.Controls.Add(Me.lblDataSetTitle)
        Me.GroupBox2.Controls.Add(Me.txtDataSetTitle)
        Me.GroupBox2.Controls.Add(Me.btnAddDataSet)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 21)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(499, 102)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "連続表示データセット"
        '
        'cboSeriesDataSet
        '
        Me.cboSeriesDataSet.AsteriskSelectEnabled = False
        Me.cboSeriesDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSeriesDataSet.FormattingEnabled = True
        Me.cboSeriesDataSet.IntegralHeight = False
        Me.cboSeriesDataSet.Location = New System.Drawing.Point(41, 27)
        Me.cboSeriesDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.cboSeriesDataSet.Name = "cboSeriesDataSet"
        Me.cboSeriesDataSet.Size = New System.Drawing.Size(220, 20)
        Me.cboSeriesDataSet.TabIndex = 5
        '
        'btnDeleteDataSet
        '
        Me.btnDeleteDataSet.Location = New System.Drawing.Point(380, 27)
        Me.btnDeleteDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteDataSet.Name = "btnDeleteDataSet"
        Me.btnDeleteDataSet.Size = New System.Drawing.Size(105, 22)
        Me.btnDeleteDataSet.TabIndex = 2
        Me.btnDeleteDataSet.Text = "データセット削除"
        Me.btnDeleteDataSet.UseVisualStyleBackColor = True
        '
        'lblDataSetTitle
        '
        Me.lblDataSetTitle.AutoSize = True
        Me.lblDataSetTitle.Location = New System.Drawing.Point(24, 68)
        Me.lblDataSetTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDataSetTitle.Name = "lblDataSetTitle"
        Me.lblDataSetTitle.Size = New System.Drawing.Size(40, 12)
        Me.lblDataSetTitle.TabIndex = 4
        Me.lblDataSetTitle.Text = "タイトル"
        '
        'txtDataSetTitle
        '
        Me.txtDataSetTitle.Location = New System.Drawing.Point(76, 65)
        Me.txtDataSetTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDataSetTitle.Name = "txtDataSetTitle"
        Me.txtDataSetTitle.Size = New System.Drawing.Size(247, 19)
        Me.txtDataSetTitle.TabIndex = 3
        '
        'btnAddDataSet
        '
        Me.btnAddDataSet.Location = New System.Drawing.Point(266, 27)
        Me.btnAddDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddDataSet.Name = "btnAddDataSet"
        Me.btnAddDataSet.Size = New System.Drawing.Size(105, 22)
        Me.btnAddDataSet.TabIndex = 1
        Me.btnAddDataSet.Text = "データセット追加"
        Me.btnAddDataSet.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(475, 2)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(35, 21)
        Me.btnHelp.TabIndex = 2
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmMain_SeriesModeSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(524, 433)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmMain_SeriesModeSettings"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "連続表示モード"
        Me.GroupBox1.ResumeLayout(False)
        Me.gbItemData.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAllClear As System.Windows.Forms.Button
    Friend WithEvents gbItemData As System.Windows.Forms.GroupBox
    Friend WithEvents btnErase As System.Windows.Forms.Button
    Friend WithEvents btnPositionDown As System.Windows.Forms.Button
    Friend WithEvents btnPositionUp As System.Windows.Forms.Button
    Friend WithEvents ListViewSeries As mandara10.ListViewEX
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDeleteDataSet As System.Windows.Forms.Button
    Friend WithEvents lblDataSetTitle As System.Windows.Forms.Label
    Friend WithEvents txtDataSetTitle As System.Windows.Forms.TextBox
    Friend WithEvents btnAddDataSet As System.Windows.Forms.Button
    Friend WithEvents cboSeriesDataSet As mandara10.ComboBoxEx
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnReverse As System.Windows.Forms.Button
End Class
