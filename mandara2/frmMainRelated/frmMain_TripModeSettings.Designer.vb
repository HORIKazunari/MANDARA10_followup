<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_TripModeSettings
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
        Me.gbDataSet = New System.Windows.Forms.GroupBox()
        Me.cboTripDataSet = New mandara10.ComboBoxEx()
        Me.btnDeleteDataSet = New System.Windows.Forms.Button()
        Me.lblDataSetTitle = New System.Windows.Forms.Label()
        Me.txtDataSetTitle = New System.Windows.Forms.TextBox()
        Me.btnAddDataSet = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnDefaultDuration = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePickerEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePickerStart = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbTripGraphTripLayer = New System.Windows.Forms.RadioButton()
        Me.rbTripGraphDefinitionLayer = New System.Windows.Forms.RadioButton()
        Me.rbTripGraphBlanc = New System.Windows.Forms.RadioButton()
        Me.gbTripDefinitionLayerDataMode = New System.Windows.Forms.GroupBox()
        Me.rbTripDefinitionDataOD = New System.Windows.Forms.RadioButton()
        Me.rbTripDefinitionDataPaint = New System.Windows.Forms.RadioButton()
        Me.cboTripDefinitionData = New mandara10.ComboBoxEx()
        Me.gbTripLayerDataMode = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.rbTripDataOD = New System.Windows.Forms.RadioButton()
        Me.rbTripDataPaint = New System.Windows.Forms.RadioButton()
        Me.cboTripData = New mandara10.ComboBoxEx()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cboStayData = New mandara10.ComboBoxEx()
        Me.rbStayDataOD = New System.Windows.Forms.RadioButton()
        Me.rbStayDataPaint = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboZData = New mandara10.ComboBoxEx()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnOption = New System.Windows.Forms.Button()
        Me.gbDataSet.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbTripDefinitionLayerDataMode.SuspendLayout()
        Me.gbTripLayerDataMode.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDataSet
        '
        Me.gbDataSet.Controls.Add(Me.cboTripDataSet)
        Me.gbDataSet.Controls.Add(Me.btnDeleteDataSet)
        Me.gbDataSet.Controls.Add(Me.lblDataSetTitle)
        Me.gbDataSet.Controls.Add(Me.txtDataSetTitle)
        Me.gbDataSet.Controls.Add(Me.btnAddDataSet)
        Me.gbDataSet.Location = New System.Drawing.Point(9, 18)
        Me.gbDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.gbDataSet.Name = "gbDataSet"
        Me.gbDataSet.Padding = New System.Windows.Forms.Padding(2)
        Me.gbDataSet.Size = New System.Drawing.Size(438, 96)
        Me.gbDataSet.TabIndex = 0
        Me.gbDataSet.TabStop = False
        Me.gbDataSet.Text = "移動データセット"
        '
        'cboTripDataSet
        '
        Me.cboTripDataSet.AsteriskSelectEnabled = False
        Me.cboTripDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTripDataSet.FormattingEnabled = True
        Me.cboTripDataSet.IntegralHeight = False
        Me.cboTripDataSet.Location = New System.Drawing.Point(23, 25)
        Me.cboTripDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTripDataSet.Name = "cboTripDataSet"
        Me.cboTripDataSet.Size = New System.Drawing.Size(190, 20)
        Me.cboTripDataSet.TabIndex = 0
        '
        'btnDeleteDataSet
        '
        Me.btnDeleteDataSet.Location = New System.Drawing.Point(326, 25)
        Me.btnDeleteDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteDataSet.Name = "btnDeleteDataSet"
        Me.btnDeleteDataSet.Size = New System.Drawing.Size(99, 22)
        Me.btnDeleteDataSet.TabIndex = 2
        Me.btnDeleteDataSet.Text = "データセット削除"
        Me.btnDeleteDataSet.UseVisualStyleBackColor = True
        '
        'lblDataSetTitle
        '
        Me.lblDataSetTitle.AutoSize = True
        Me.lblDataSetTitle.Location = New System.Drawing.Point(21, 66)
        Me.lblDataSetTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDataSetTitle.Name = "lblDataSetTitle"
        Me.lblDataSetTitle.Size = New System.Drawing.Size(40, 12)
        Me.lblDataSetTitle.TabIndex = 4
        Me.lblDataSetTitle.Text = "タイトル"
        '
        'txtDataSetTitle
        '
        Me.txtDataSetTitle.Location = New System.Drawing.Point(65, 63)
        Me.txtDataSetTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDataSetTitle.Name = "txtDataSetTitle"
        Me.txtDataSetTitle.Size = New System.Drawing.Size(212, 19)
        Me.txtDataSetTitle.TabIndex = 3
        '
        'btnAddDataSet
        '
        Me.btnAddDataSet.Location = New System.Drawing.Point(221, 25)
        Me.btnAddDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddDataSet.Name = "btnAddDataSet"
        Me.btnAddDataSet.Size = New System.Drawing.Size(101, 22)
        Me.btnAddDataSet.TabIndex = 1
        Me.btnAddDataSet.Text = "データセット追加"
        Me.btnAddDataSet.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 129)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(212, 268)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "トリップデータのグラフ"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnDefaultDuration)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.DateTimePickerEnd)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.DateTimePickerStart)
        Me.GroupBox4.Location = New System.Drawing.Point(14, 160)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(181, 102)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "表示期間"
        '
        'btnDefaultDuration
        '
        Me.btnDefaultDuration.Location = New System.Drawing.Point(104, 70)
        Me.btnDefaultDuration.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDefaultDuration.Name = "btnDefaultDuration"
        Me.btnDefaultDuration.Size = New System.Drawing.Size(70, 22)
        Me.btnDefaultDuration.TabIndex = 2
        Me.btnDefaultDuration.Text = "既定に戻す"
        Me.btnDefaultDuration.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 48)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "終了"
        '
        'DateTimePickerEnd
        '
        Me.DateTimePickerEnd.CustomFormat = "yyyy/MM/dd HH:mm"
        Me.DateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerEnd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DateTimePickerEnd.Location = New System.Drawing.Point(42, 48)
        Me.DateTimePickerEnd.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePickerEnd.Name = "DateTimePickerEnd"
        Me.DateTimePickerEnd.Size = New System.Drawing.Size(132, 19)
        Me.DateTimePickerEnd.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 25)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "開始"
        '
        'DateTimePickerStart
        '
        Me.DateTimePickerStart.CustomFormat = "yyyy/MM/dd HH:mm"
        Me.DateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerStart.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DateTimePickerStart.Location = New System.Drawing.Point(42, 25)
        Me.DateTimePickerStart.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePickerStart.Name = "DateTimePickerStart"
        Me.DateTimePickerStart.Size = New System.Drawing.Size(132, 19)
        Me.DateTimePickerStart.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbTripGraphTripLayer)
        Me.GroupBox3.Controls.Add(Me.rbTripGraphDefinitionLayer)
        Me.GroupBox3.Controls.Add(Me.rbTripGraphBlanc)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 25)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(182, 122)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "表示方法"
        '
        'rbTripGraphTripLayer
        '
        Me.rbTripGraphTripLayer.Location = New System.Drawing.Point(21, 81)
        Me.rbTripGraphTripLayer.Margin = New System.Windows.Forms.Padding(2)
        Me.rbTripGraphTripLayer.Name = "rbTripGraphTripLayer"
        Me.rbTripGraphTripLayer.Size = New System.Drawing.Size(120, 34)
        Me.rbTripGraphTripLayer.TabIndex = 2
        Me.rbTripGraphTripLayer.TabStop = True
        Me.rbTripGraphTripLayer.Text = "現在のレイヤのデータ項目を利用"
        Me.rbTripGraphTripLayer.UseVisualStyleBackColor = True
        '
        'rbTripGraphDefinitionLayer
        '
        Me.rbTripGraphDefinitionLayer.Location = New System.Drawing.Point(21, 42)
        Me.rbTripGraphDefinitionLayer.Margin = New System.Windows.Forms.Padding(2)
        Me.rbTripGraphDefinitionLayer.Name = "rbTripGraphDefinitionLayer"
        Me.rbTripGraphDefinitionLayer.Size = New System.Drawing.Size(129, 34)
        Me.rbTripGraphDefinitionLayer.TabIndex = 1
        Me.rbTripGraphDefinitionLayer.TabStop = True
        Me.rbTripGraphDefinitionLayer.Text = "移動主体定義レイヤのデータ項目を利用"
        Me.rbTripGraphDefinitionLayer.UseVisualStyleBackColor = True
        '
        'rbTripGraphBlanc
        '
        Me.rbTripGraphBlanc.AutoSize = True
        Me.rbTripGraphBlanc.Location = New System.Drawing.Point(21, 22)
        Me.rbTripGraphBlanc.Margin = New System.Windows.Forms.Padding(2)
        Me.rbTripGraphBlanc.Name = "rbTripGraphBlanc"
        Me.rbTripGraphBlanc.Size = New System.Drawing.Size(59, 16)
        Me.rbTripGraphBlanc.TabIndex = 0
        Me.rbTripGraphBlanc.TabStop = True
        Me.rbTripGraphBlanc.Text = "白地図"
        Me.rbTripGraphBlanc.UseVisualStyleBackColor = True
        '
        'gbTripDefinitionLayerDataMode
        '
        Me.gbTripDefinitionLayerDataMode.Controls.Add(Me.rbTripDefinitionDataOD)
        Me.gbTripDefinitionLayerDataMode.Controls.Add(Me.rbTripDefinitionDataPaint)
        Me.gbTripDefinitionLayerDataMode.Controls.Add(Me.cboTripDefinitionData)
        Me.gbTripDefinitionLayerDataMode.Location = New System.Drawing.Point(463, 129)
        Me.gbTripDefinitionLayerDataMode.Margin = New System.Windows.Forms.Padding(2)
        Me.gbTripDefinitionLayerDataMode.Name = "gbTripDefinitionLayerDataMode"
        Me.gbTripDefinitionLayerDataMode.Padding = New System.Windows.Forms.Padding(2)
        Me.gbTripDefinitionLayerDataMode.Size = New System.Drawing.Size(212, 82)
        Me.gbTripDefinitionLayerDataMode.TabIndex = 4
        Me.gbTripDefinitionLayerDataMode.TabStop = False
        Me.gbTripDefinitionLayerDataMode.Text = "表示する移動主体定義レイヤのデータ項目"
        '
        'rbTripDefinitionDataOD
        '
        Me.rbTripDefinitionDataOD.AutoSize = True
        Me.rbTripDefinitionDataOD.Location = New System.Drawing.Point(141, 56)
        Me.rbTripDefinitionDataOD.Margin = New System.Windows.Forms.Padding(2)
        Me.rbTripDefinitionDataOD.Name = "rbTripDefinitionDataOD"
        Me.rbTripDefinitionDataOD.Size = New System.Drawing.Size(35, 16)
        Me.rbTripDefinitionDataOD.TabIndex = 2
        Me.rbTripDefinitionDataOD.TabStop = True
        Me.rbTripDefinitionDataOD.Text = "線"
        Me.rbTripDefinitionDataOD.UseVisualStyleBackColor = True
        '
        'rbTripDefinitionDataPaint
        '
        Me.rbTripDefinitionDataPaint.AutoSize = True
        Me.rbTripDefinitionDataPaint.Location = New System.Drawing.Point(141, 36)
        Me.rbTripDefinitionDataPaint.Margin = New System.Windows.Forms.Padding(2)
        Me.rbTripDefinitionDataPaint.Name = "rbTripDefinitionDataPaint"
        Me.rbTripDefinitionDataPaint.Size = New System.Drawing.Size(59, 16)
        Me.rbTripDefinitionDataPaint.TabIndex = 1
        Me.rbTripDefinitionDataPaint.TabStop = True
        Me.rbTripDefinitionDataPaint.Text = "ペイント"
        Me.rbTripDefinitionDataPaint.UseVisualStyleBackColor = True
        '
        'cboTripDefinitionData
        '
        Me.cboTripDefinitionData.AsteriskSelectEnabled = False
        Me.cboTripDefinitionData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTripDefinitionData.FormattingEnabled = True
        Me.cboTripDefinitionData.IntegralHeight = False
        Me.cboTripDefinitionData.Location = New System.Drawing.Point(9, 37)
        Me.cboTripDefinitionData.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTripDefinitionData.Name = "cboTripDefinitionData"
        Me.cboTripDefinitionData.Size = New System.Drawing.Size(121, 20)
        Me.cboTripDefinitionData.TabIndex = 0
        '
        'gbTripLayerDataMode
        '
        Me.gbTripLayerDataMode.Controls.Add(Me.GroupBox8)
        Me.gbTripLayerDataMode.Controls.Add(Me.GroupBox7)
        Me.gbTripLayerDataMode.Location = New System.Drawing.Point(235, 129)
        Me.gbTripLayerDataMode.Margin = New System.Windows.Forms.Padding(2)
        Me.gbTripLayerDataMode.Name = "gbTripLayerDataMode"
        Me.gbTripLayerDataMode.Padding = New System.Windows.Forms.Padding(2)
        Me.gbTripLayerDataMode.Size = New System.Drawing.Size(212, 161)
        Me.gbTripLayerDataMode.TabIndex = 2
        Me.gbTripLayerDataMode.TabStop = False
        Me.gbTripLayerDataMode.Text = "表示するデータ項目"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.rbTripDataOD)
        Me.GroupBox8.Controls.Add(Me.rbTripDataPaint)
        Me.GroupBox8.Controls.Add(Me.cboTripData)
        Me.GroupBox8.Location = New System.Drawing.Point(4, 87)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox8.Size = New System.Drawing.Size(198, 62)
        Me.GroupBox8.TabIndex = 4
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "移動データ"
        '
        'rbTripDataOD
        '
        Me.rbTripDataOD.AutoSize = True
        Me.rbTripDataOD.Location = New System.Drawing.Point(136, 39)
        Me.rbTripDataOD.Margin = New System.Windows.Forms.Padding(2)
        Me.rbTripDataOD.Name = "rbTripDataOD"
        Me.rbTripDataOD.Size = New System.Drawing.Size(35, 16)
        Me.rbTripDataOD.TabIndex = 2
        Me.rbTripDataOD.TabStop = True
        Me.rbTripDataOD.Text = "線"
        Me.rbTripDataOD.UseVisualStyleBackColor = True
        '
        'rbTripDataPaint
        '
        Me.rbTripDataPaint.AutoSize = True
        Me.rbTripDataPaint.Location = New System.Drawing.Point(136, 19)
        Me.rbTripDataPaint.Margin = New System.Windows.Forms.Padding(2)
        Me.rbTripDataPaint.Name = "rbTripDataPaint"
        Me.rbTripDataPaint.Size = New System.Drawing.Size(59, 16)
        Me.rbTripDataPaint.TabIndex = 1
        Me.rbTripDataPaint.TabStop = True
        Me.rbTripDataPaint.Text = "ペイント"
        Me.rbTripDataPaint.UseVisualStyleBackColor = True
        '
        'cboTripData
        '
        Me.cboTripData.AsteriskSelectEnabled = False
        Me.cboTripData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTripData.FormattingEnabled = True
        Me.cboTripData.IntegralHeight = False
        Me.cboTripData.Location = New System.Drawing.Point(4, 24)
        Me.cboTripData.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTripData.Name = "cboTripData"
        Me.cboTripData.Size = New System.Drawing.Size(121, 20)
        Me.cboTripData.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cboStayData)
        Me.GroupBox7.Controls.Add(Me.rbStayDataOD)
        Me.GroupBox7.Controls.Add(Me.rbStayDataPaint)
        Me.GroupBox7.Location = New System.Drawing.Point(4, 23)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox7.Size = New System.Drawing.Size(198, 60)
        Me.GroupBox7.TabIndex = 3
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "滞在データ"
        '
        'cboStayData
        '
        Me.cboStayData.AsteriskSelectEnabled = False
        Me.cboStayData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStayData.FormattingEnabled = True
        Me.cboStayData.IntegralHeight = False
        Me.cboStayData.Location = New System.Drawing.Point(4, 24)
        Me.cboStayData.Margin = New System.Windows.Forms.Padding(2)
        Me.cboStayData.Name = "cboStayData"
        Me.cboStayData.Size = New System.Drawing.Size(121, 20)
        Me.cboStayData.TabIndex = 0
        '
        'rbStayDataOD
        '
        Me.rbStayDataOD.AutoSize = True
        Me.rbStayDataOD.Location = New System.Drawing.Point(136, 38)
        Me.rbStayDataOD.Margin = New System.Windows.Forms.Padding(2)
        Me.rbStayDataOD.Name = "rbStayDataOD"
        Me.rbStayDataOD.Size = New System.Drawing.Size(35, 16)
        Me.rbStayDataOD.TabIndex = 2
        Me.rbStayDataOD.TabStop = True
        Me.rbStayDataOD.Text = "線"
        Me.rbStayDataOD.UseVisualStyleBackColor = True
        '
        'rbStayDataPaint
        '
        Me.rbStayDataPaint.AutoSize = True
        Me.rbStayDataPaint.Location = New System.Drawing.Point(136, 18)
        Me.rbStayDataPaint.Margin = New System.Windows.Forms.Padding(2)
        Me.rbStayDataPaint.Name = "rbStayDataPaint"
        Me.rbStayDataPaint.Size = New System.Drawing.Size(59, 16)
        Me.rbStayDataPaint.TabIndex = 1
        Me.rbStayDataPaint.TabStop = True
        Me.rbStayDataPaint.Text = "ペイント"
        Me.rbStayDataPaint.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboZData)
        Me.GroupBox2.Location = New System.Drawing.Point(235, 294)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(212, 65)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "3D表示の際の高さデータ"
        '
        'cboZData
        '
        Me.cboZData.AsteriskSelectEnabled = False
        Me.cboZData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZData.FormattingEnabled = True
        Me.cboZData.IntegralHeight = False
        Me.cboZData.Location = New System.Drawing.Point(21, 27)
        Me.cboZData.Margin = New System.Windows.Forms.Padding(2)
        Me.cboZData.Name = "cboZData"
        Me.cboZData.Size = New System.Drawing.Size(175, 20)
        Me.cboZData.TabIndex = 0
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(417, 1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(30, 21)
        Me.btnHelp.TabIndex = 6
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnOption
        '
        Me.btnOption.Location = New System.Drawing.Point(273, 373)
        Me.btnOption.Name = "btnOption"
        Me.btnOption.Size = New System.Drawing.Size(118, 24)
        Me.btnOption.TabIndex = 7
        Me.btnOption.Text = "移動表示オプション"
        Me.btnOption.UseVisualStyleBackColor = True
        '
        'frmMain_TripModeSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(707, 406)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnOption)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbTripDefinitionLayerDataMode)
        Me.Controls.Add(Me.gbTripLayerDataMode)
        Me.Controls.Add(Me.gbDataSet)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_TripModeSettings"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "移動表示モード"
        Me.gbDataSet.ResumeLayout(False)
        Me.gbDataSet.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbTripDefinitionLayerDataMode.ResumeLayout(False)
        Me.gbTripDefinitionLayerDataMode.PerformLayout()
        Me.gbTripLayerDataMode.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDataSet As System.Windows.Forms.GroupBox
    Friend WithEvents cboTripDataSet As mandara10.ComboBoxEx
    Friend WithEvents btnDeleteDataSet As System.Windows.Forms.Button
    Friend WithEvents lblDataSetTitle As System.Windows.Forms.Label
    Friend WithEvents txtDataSetTitle As System.Windows.Forms.TextBox
    Friend WithEvents btnAddDataSet As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbTripLayerDataMode As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents gbTripDefinitionLayerDataMode As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTripGraphTripLayer As System.Windows.Forms.RadioButton
    Friend WithEvents rbTripGraphDefinitionLayer As System.Windows.Forms.RadioButton
    Friend WithEvents rbTripGraphBlanc As System.Windows.Forms.RadioButton
    Friend WithEvents DateTimePickerStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbTripDefinitionDataOD As System.Windows.Forms.RadioButton
    Friend WithEvents rbTripDefinitionDataPaint As System.Windows.Forms.RadioButton
    Friend WithEvents cboTripDefinitionData As mandara10.ComboBoxEx
    Friend WithEvents rbTripDataOD As System.Windows.Forms.RadioButton
    Friend WithEvents rbTripDataPaint As System.Windows.Forms.RadioButton
    Friend WithEvents cboTripData As mandara10.ComboBoxEx
    Friend WithEvents cboStayData As mandara10.ComboBoxEx
    Friend WithEvents rbStayDataOD As System.Windows.Forms.RadioButton
    Friend WithEvents rbStayDataPaint As System.Windows.Forms.RadioButton
    Friend WithEvents btnDefaultDuration As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboZData As mandara10.ComboBoxEx
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnOption As System.Windows.Forms.Button
End Class
