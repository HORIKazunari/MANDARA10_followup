<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_ContourViewSettings
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbSeparateSettings = New System.Windows.Forms.RadioButton()
        Me.rbRegularInterval = New System.Windows.Forms.RadioButton()
        Me.rbClassHatchMode = New System.Windows.Forms.RadioButton()
        Me.rbClassPaintMode = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboContourDetail = New System.Windows.Forms.ComboBox()
        Me.chkSpline = New System.Windows.Forms.CheckBox()
        Me.chkInPolygon = New System.Windows.Forms.CheckBox()
        Me.gbPaintHatchContour = New System.Windows.Forms.GroupBox()
        Me.picPaitHatchLine = New System.Windows.Forms.PictureBox()
        Me.gbRegularInterval = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtHeavyLineValue = New mandara10.TextNumberBox()
        Me.chkHeavyLine = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.picHeavyContour = New System.Windows.Forms.PictureBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtThickMaxValue = New mandara10.TextNumberBox()
        Me.txtThickIntervalValue = New mandara10.TextNumberBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picThickContour = New System.Windows.Forms.PictureBox()
        Me.txtThickMinValue = New mandara10.TextNumberBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtIntervalValue = New mandara10.TextNumberBox()
        Me.txtMaxValue = New mandara10.TextNumberBox()
        Me.txtMinValue = New mandara10.TextNumberBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.picNormalContour = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbSeparatelySettings = New System.Windows.Forms.GroupBox()
        Me.btnClassValueSet = New System.Windows.Forms.Button()
        Me.bynAttangeSepaContour = New System.Windows.Forms.Button()
        Me.btnAllClear = New System.Windows.Forms.Button()
        Me.gbSelectedContour = New System.Windows.Forms.GroupBox()
        Me.txtSepaContour = New mandara10.TextNumberBox()
        Me.btnDeleteContour = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.picSepaLinePat = New System.Windows.Forms.PictureBox()
        Me.lbSepaContour = New System.Windows.Forms.ListBox()
        Me.btnAddContour = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbPaintHatchContour.SuspendLayout()
        CType(Me.picPaitHatchLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRegularInterval.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.picHeavyContour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.picThickContour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.picNormalContour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSeparatelySettings.SuspendLayout()
        Me.gbSelectedContour.SuspendLayout()
        CType(Me.picSepaLinePat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSeparateSettings)
        Me.GroupBox1.Controls.Add(Me.rbRegularInterval)
        Me.GroupBox1.Controls.Add(Me.rbClassHatchMode)
        Me.GroupBox1.Controls.Add(Me.rbClassPaintMode)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 25)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(191, 120)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "等値線の設定方法"
        '
        'rbSeparateSettings
        '
        Me.rbSeparateSettings.AutoSize = True
        Me.rbSeparateSettings.Location = New System.Drawing.Point(17, 89)
        Me.rbSeparateSettings.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSeparateSettings.Name = "rbSeparateSettings"
        Me.rbSeparateSettings.Size = New System.Drawing.Size(71, 16)
        Me.rbSeparateSettings.TabIndex = 3
        Me.rbSeparateSettings.TabStop = True
        Me.rbSeparateSettings.Text = "個別設定"
        Me.rbSeparateSettings.UseVisualStyleBackColor = True
        '
        'rbRegularInterval
        '
        Me.rbRegularInterval.AutoSize = True
        Me.rbRegularInterval.Location = New System.Drawing.Point(17, 69)
        Me.rbRegularInterval.Margin = New System.Windows.Forms.Padding(2)
        Me.rbRegularInterval.Name = "rbRegularInterval"
        Me.rbRegularInterval.Size = New System.Drawing.Size(59, 16)
        Me.rbRegularInterval.TabIndex = 2
        Me.rbRegularInterval.TabStop = True
        Me.rbRegularInterval.Text = "等間隔"
        Me.rbRegularInterval.UseVisualStyleBackColor = True
        '
        'rbClassHatchMode
        '
        Me.rbClassHatchMode.AutoSize = True
        Me.rbClassHatchMode.Location = New System.Drawing.Point(17, 49)
        Me.rbClassHatchMode.Margin = New System.Windows.Forms.Padding(2)
        Me.rbClassHatchMode.Name = "rbClassHatchMode"
        Me.rbClassHatchMode.Size = New System.Drawing.Size(121, 16)
        Me.rbClassHatchMode.TabIndex = 1
        Me.rbClassHatchMode.TabStop = True
        Me.rbClassHatchMode.Text = "ハッチモードで塗分け"
        Me.rbClassHatchMode.UseVisualStyleBackColor = True
        '
        'rbClassPaintMode
        '
        Me.rbClassPaintMode.AutoSize = True
        Me.rbClassPaintMode.Location = New System.Drawing.Point(17, 29)
        Me.rbClassPaintMode.Margin = New System.Windows.Forms.Padding(2)
        Me.rbClassPaintMode.Name = "rbClassPaintMode"
        Me.rbClassPaintMode.Size = New System.Drawing.Size(131, 16)
        Me.rbClassPaintMode.TabIndex = 0
        Me.rbClassPaintMode.TabStop = True
        Me.rbClassPaintMode.Text = "ペイントモードで塗分け"
        Me.rbClassPaintMode.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cboContourDetail)
        Me.GroupBox2.Controls.Add(Me.chkSpline)
        Me.GroupBox2.Controls.Add(Me.chkInPolygon)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 159)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(188, 126)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "等値線の描き方"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 88)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "密度"
        '
        'cboContourDetail
        '
        Me.cboContourDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContourDetail.FormattingEnabled = True
        Me.cboContourDetail.Location = New System.Drawing.Point(51, 86)
        Me.cboContourDetail.Margin = New System.Windows.Forms.Padding(2)
        Me.cboContourDetail.Name = "cboContourDetail"
        Me.cboContourDetail.Size = New System.Drawing.Size(95, 20)
        Me.cboContourDetail.TabIndex = 2
        '
        'chkSpline
        '
        Me.chkSpline.AutoSize = True
        Me.chkSpline.Location = New System.Drawing.Point(19, 54)
        Me.chkSpline.Margin = New System.Windows.Forms.Padding(2)
        Me.chkSpline.Name = "chkSpline"
        Me.chkSpline.Size = New System.Drawing.Size(127, 16)
        Me.chkSpline.TabIndex = 1
        Me.chkSpline.Text = "等値線を曲線で近似"
        Me.chkSpline.UseVisualStyleBackColor = True
        '
        'chkInPolygon
        '
        Me.chkInPolygon.AutoSize = True
        Me.chkInPolygon.Location = New System.Drawing.Point(19, 32)
        Me.chkInPolygon.Margin = New System.Windows.Forms.Padding(2)
        Me.chkInPolygon.Name = "chkInPolygon"
        Me.chkInPolygon.Size = New System.Drawing.Size(128, 16)
        Me.chkInPolygon.TabIndex = 0
        Me.chkInPolygon.Text = "ポリゴン内部のみ描画"
        Me.chkInPolygon.UseVisualStyleBackColor = True
        '
        'gbPaintHatchContour
        '
        Me.gbPaintHatchContour.Controls.Add(Me.picPaitHatchLine)
        Me.gbPaintHatchContour.Location = New System.Drawing.Point(217, 25)
        Me.gbPaintHatchContour.Margin = New System.Windows.Forms.Padding(2)
        Me.gbPaintHatchContour.Name = "gbPaintHatchContour"
        Me.gbPaintHatchContour.Padding = New System.Windows.Forms.Padding(2)
        Me.gbPaintHatchContour.Size = New System.Drawing.Size(107, 62)
        Me.gbPaintHatchContour.TabIndex = 2
        Me.gbPaintHatchContour.TabStop = False
        Me.gbPaintHatchContour.Text = "等値線線種"
        '
        'picPaitHatchLine
        '
        Me.picPaitHatchLine.BackColor = System.Drawing.Color.White
        Me.picPaitHatchLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPaitHatchLine.Location = New System.Drawing.Point(17, 16)
        Me.picPaitHatchLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picPaitHatchLine.Name = "picPaitHatchLine"
        Me.picPaitHatchLine.Size = New System.Drawing.Size(69, 33)
        Me.picPaitHatchLine.TabIndex = 0
        Me.picPaitHatchLine.TabStop = False
        '
        'gbRegularInterval
        '
        Me.gbRegularInterval.Controls.Add(Me.GroupBox5)
        Me.gbRegularInterval.Controls.Add(Me.GroupBox4)
        Me.gbRegularInterval.Controls.Add(Me.GroupBox3)
        Me.gbRegularInterval.Location = New System.Drawing.Point(331, 26)
        Me.gbRegularInterval.Margin = New System.Windows.Forms.Padding(2)
        Me.gbRegularInterval.Name = "gbRegularInterval"
        Me.gbRegularInterval.Padding = New System.Windows.Forms.Padding(2)
        Me.gbRegularInterval.Size = New System.Drawing.Size(308, 280)
        Me.gbRegularInterval.TabIndex = 3
        Me.gbRegularInterval.TabStop = False
        Me.gbRegularInterval.Text = "等値線間隔設定"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtHeavyLineValue)
        Me.GroupBox5.Controls.Add(Me.chkHeavyLine)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.picHeavyContour)
        Me.GroupBox5.Location = New System.Drawing.Point(16, 217)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Size = New System.Drawing.Size(278, 52)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "上のうちさらに一本だけ強調する"
        '
        'txtHeavyLineValue
        '
        Me.txtHeavyLineValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtHeavyLineValue.Location = New System.Drawing.Point(76, 22)
        Me.txtHeavyLineValue.Margin = New System.Windows.Forms.Padding(2)
        Me.txtHeavyLineValue.MaxValue = 0.0R
        Me.txtHeavyLineValue.MaxValueFlag = False
        Me.txtHeavyLineValue.MinValue = 0.0R
        Me.txtHeavyLineValue.MinValueFlag = False
        Me.txtHeavyLineValue.Name = "txtHeavyLineValue"
        Me.txtHeavyLineValue.NumberPoint = True
        Me.txtHeavyLineValue.Size = New System.Drawing.Size(76, 19)
        Me.txtHeavyLineValue.TabIndex = 0
        Me.txtHeavyLineValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHeavyLineValue.ValueErrorMessageFlag = True
        '
        'chkHeavyLine
        '
        Me.chkHeavyLine.AutoSize = True
        Me.chkHeavyLine.Location = New System.Drawing.Point(9, 25)
        Me.chkHeavyLine.Margin = New System.Windows.Forms.Padding(2)
        Me.chkHeavyLine.Name = "chkHeavyLine"
        Me.chkHeavyLine.Size = New System.Drawing.Size(60, 16)
        Me.chkHeavyLine.TabIndex = 8
        Me.chkHeavyLine.Text = "強調値"
        Me.chkHeavyLine.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(166, 26)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "線種"
        '
        'picHeavyContour
        '
        Me.picHeavyContour.BackColor = System.Drawing.Color.White
        Me.picHeavyContour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picHeavyContour.Location = New System.Drawing.Point(204, 23)
        Me.picHeavyContour.Margin = New System.Windows.Forms.Padding(2)
        Me.picHeavyContour.Name = "picHeavyContour"
        Me.picHeavyContour.Size = New System.Drawing.Size(52, 18)
        Me.picHeavyContour.TabIndex = 6
        Me.picHeavyContour.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtThickMaxValue)
        Me.GroupBox4.Controls.Add(Me.txtThickIntervalValue)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.picThickContour)
        Me.GroupBox4.Controls.Add(Me.txtThickMinValue)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 125)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(278, 85)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "上のうち強調する等値線"
        '
        'txtThickMaxValue
        '
        Me.txtThickMaxValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtThickMaxValue.Location = New System.Drawing.Point(191, 25)
        Me.txtThickMaxValue.Margin = New System.Windows.Forms.Padding(2)
        Me.txtThickMaxValue.MaxValue = 0.0R
        Me.txtThickMaxValue.MaxValueFlag = False
        Me.txtThickMaxValue.MinValue = 0.0R
        Me.txtThickMaxValue.MinValueFlag = False
        Me.txtThickMaxValue.Name = "txtThickMaxValue"
        Me.txtThickMaxValue.NumberPoint = True
        Me.txtThickMaxValue.Size = New System.Drawing.Size(76, 19)
        Me.txtThickMaxValue.TabIndex = 1
        Me.txtThickMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtThickMaxValue.ValueErrorMessageFlag = True
        '
        'txtThickIntervalValue
        '
        Me.txtThickIntervalValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtThickIntervalValue.Location = New System.Drawing.Point(62, 57)
        Me.txtThickIntervalValue.Margin = New System.Windows.Forms.Padding(2)
        Me.txtThickIntervalValue.MaxValue = 0.0R
        Me.txtThickIntervalValue.MaxValueFlag = False
        Me.txtThickIntervalValue.MinValue = 0.0R
        Me.txtThickIntervalValue.MinValueFlag = False
        Me.txtThickIntervalValue.Name = "txtThickIntervalValue"
        Me.txtThickIntervalValue.NumberPoint = True
        Me.txtThickIntervalValue.Size = New System.Drawing.Size(76, 19)
        Me.txtThickIntervalValue.TabIndex = 2
        Me.txtThickIntervalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtThickIntervalValue.ValueErrorMessageFlag = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(155, 57)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "線種"
        '
        'picThickContour
        '
        Me.picThickContour.BackColor = System.Drawing.Color.White
        Me.picThickContour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picThickContour.Location = New System.Drawing.Point(192, 57)
        Me.picThickContour.Margin = New System.Windows.Forms.Padding(2)
        Me.picThickContour.Name = "picThickContour"
        Me.picThickContour.Size = New System.Drawing.Size(52, 18)
        Me.picThickContour.TabIndex = 6
        Me.picThickContour.TabStop = False
        '
        'txtThickMinValue
        '
        Me.txtThickMinValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtThickMinValue.Location = New System.Drawing.Point(62, 28)
        Me.txtThickMinValue.Margin = New System.Windows.Forms.Padding(2)
        Me.txtThickMinValue.MaxValue = 0.0R
        Me.txtThickMinValue.MaxValueFlag = False
        Me.txtThickMinValue.MinValue = 0.0R
        Me.txtThickMinValue.MinValueFlag = False
        Me.txtThickMinValue.Name = "txtThickMinValue"
        Me.txtThickMinValue.NumberPoint = True
        Me.txtThickMinValue.Size = New System.Drawing.Size(76, 19)
        Me.txtThickMinValue.TabIndex = 0
        Me.txtThickMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtThickMinValue.ValueErrorMessageFlag = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 60)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 12)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "間隔"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(143, 28)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "上限値"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 28)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "下限値"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtIntervalValue)
        Me.GroupBox3.Controls.Add(Me.txtMaxValue)
        Me.GroupBox3.Controls.Add(Me.txtMinValue)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.picNormalContour)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 36)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(278, 84)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "通常の等値線"
        '
        'txtIntervalValue
        '
        Me.txtIntervalValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtIntervalValue.Location = New System.Drawing.Point(62, 56)
        Me.txtIntervalValue.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIntervalValue.MaxValue = 0.0R
        Me.txtIntervalValue.MaxValueFlag = False
        Me.txtIntervalValue.MinValue = 0.0R
        Me.txtIntervalValue.MinValueFlag = False
        Me.txtIntervalValue.Name = "txtIntervalValue"
        Me.txtIntervalValue.NumberPoint = True
        Me.txtIntervalValue.Size = New System.Drawing.Size(76, 19)
        Me.txtIntervalValue.TabIndex = 2
        Me.txtIntervalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIntervalValue.ValueErrorMessageFlag = True
        '
        'txtMaxValue
        '
        Me.txtMaxValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMaxValue.Location = New System.Drawing.Point(191, 27)
        Me.txtMaxValue.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMaxValue.MaxValue = 0.0R
        Me.txtMaxValue.MaxValueFlag = False
        Me.txtMaxValue.MinValue = 0.0R
        Me.txtMaxValue.MinValueFlag = False
        Me.txtMaxValue.Name = "txtMaxValue"
        Me.txtMaxValue.NumberPoint = True
        Me.txtMaxValue.Size = New System.Drawing.Size(76, 19)
        Me.txtMaxValue.TabIndex = 1
        Me.txtMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaxValue.ValueErrorMessageFlag = True
        '
        'txtMinValue
        '
        Me.txtMinValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMinValue.Location = New System.Drawing.Point(62, 27)
        Me.txtMinValue.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMinValue.MaxValue = 0.0R
        Me.txtMinValue.MaxValueFlag = False
        Me.txtMinValue.MinValue = 0.0R
        Me.txtMinValue.MinValueFlag = False
        Me.txtMinValue.Name = "txtMinValue"
        Me.txtMinValue.NumberPoint = True
        Me.txtMinValue.Size = New System.Drawing.Size(76, 19)
        Me.txtMinValue.TabIndex = 0
        Me.txtMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMinValue.ValueErrorMessageFlag = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(155, 56)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "線種"
        '
        'picNormalContour
        '
        Me.picNormalContour.BackColor = System.Drawing.Color.White
        Me.picNormalContour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picNormalContour.Location = New System.Drawing.Point(192, 56)
        Me.picNormalContour.Margin = New System.Windows.Forms.Padding(2)
        Me.picNormalContour.Name = "picNormalContour"
        Me.picNormalContour.Size = New System.Drawing.Size(52, 18)
        Me.picNormalContour.TabIndex = 6
        Me.picNormalContour.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 59)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "間隔"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(143, 27)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "上限値"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 27)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "下限値"
        '
        'gbSeparatelySettings
        '
        Me.gbSeparatelySettings.Controls.Add(Me.btnClassValueSet)
        Me.gbSeparatelySettings.Controls.Add(Me.bynAttangeSepaContour)
        Me.gbSeparatelySettings.Controls.Add(Me.btnAllClear)
        Me.gbSeparatelySettings.Controls.Add(Me.gbSelectedContour)
        Me.gbSeparatelySettings.Controls.Add(Me.lbSepaContour)
        Me.gbSeparatelySettings.Controls.Add(Me.btnAddContour)
        Me.gbSeparatelySettings.Location = New System.Drawing.Point(645, 25)
        Me.gbSeparatelySettings.Margin = New System.Windows.Forms.Padding(2)
        Me.gbSeparatelySettings.Name = "gbSeparatelySettings"
        Me.gbSeparatelySettings.Padding = New System.Windows.Forms.Padding(2)
        Me.gbSeparatelySettings.Size = New System.Drawing.Size(254, 234)
        Me.gbSeparatelySettings.TabIndex = 4
        Me.gbSeparatelySettings.TabStop = False
        Me.gbSeparatelySettings.Text = "個別設定"
        '
        'btnClassValueSet
        '
        Me.btnClassValueSet.Location = New System.Drawing.Point(9, 198)
        Me.btnClassValueSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClassValueSet.Name = "btnClassValueSet"
        Me.btnClassValueSet.Size = New System.Drawing.Size(142, 22)
        Me.btnClassValueSet.TabIndex = 5
        Me.btnClassValueSet.Text = "階級区分の値を設定"
        Me.btnClassValueSet.UseVisualStyleBackColor = True
        '
        'bynAttangeSepaContour
        '
        Me.bynAttangeSepaContour.Location = New System.Drawing.Point(173, 164)
        Me.bynAttangeSepaContour.Margin = New System.Windows.Forms.Padding(2)
        Me.bynAttangeSepaContour.Name = "bynAttangeSepaContour"
        Me.bynAttangeSepaContour.Size = New System.Drawing.Size(77, 22)
        Me.bynAttangeSepaContour.TabIndex = 4
        Me.bynAttangeSepaContour.Text = "並べ替え"
        Me.bynAttangeSepaContour.UseVisualStyleBackColor = True
        '
        'btnAllClear
        '
        Me.btnAllClear.Location = New System.Drawing.Point(91, 164)
        Me.btnAllClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAllClear.Name = "btnAllClear"
        Me.btnAllClear.Size = New System.Drawing.Size(77, 22)
        Me.btnAllClear.TabIndex = 3
        Me.btnAllClear.Text = "すべて削除"
        Me.btnAllClear.UseVisualStyleBackColor = True
        '
        'gbSelectedContour
        '
        Me.gbSelectedContour.Controls.Add(Me.txtSepaContour)
        Me.gbSelectedContour.Controls.Add(Me.btnDeleteContour)
        Me.gbSelectedContour.Controls.Add(Me.Label12)
        Me.gbSelectedContour.Controls.Add(Me.Label11)
        Me.gbSelectedContour.Controls.Add(Me.picSepaLinePat)
        Me.gbSelectedContour.Location = New System.Drawing.Point(127, 60)
        Me.gbSelectedContour.Margin = New System.Windows.Forms.Padding(2)
        Me.gbSelectedContour.Name = "gbSelectedContour"
        Me.gbSelectedContour.Padding = New System.Windows.Forms.Padding(2)
        Me.gbSelectedContour.Size = New System.Drawing.Size(114, 96)
        Me.gbSelectedContour.TabIndex = 1
        Me.gbSelectedContour.TabStop = False
        '
        'txtSepaContour
        '
        Me.txtSepaContour.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSepaContour.Location = New System.Drawing.Point(29, 26)
        Me.txtSepaContour.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSepaContour.MaxValue = 0.0R
        Me.txtSepaContour.MaxValueFlag = False
        Me.txtSepaContour.MinValue = 0.0R
        Me.txtSepaContour.MinValueFlag = False
        Me.txtSepaContour.Name = "txtSepaContour"
        Me.txtSepaContour.NumberPoint = True
        Me.txtSepaContour.Size = New System.Drawing.Size(76, 19)
        Me.txtSepaContour.TabIndex = 0
        Me.txtSepaContour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSepaContour.ValueErrorMessageFlag = True
        '
        'btnDeleteContour
        '
        Me.btnDeleteContour.Location = New System.Drawing.Point(38, 77)
        Me.btnDeleteContour.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteContour.Name = "btnDeleteContour"
        Me.btnDeleteContour.Size = New System.Drawing.Size(71, 20)
        Me.btnDeleteContour.TabIndex = 2
        Me.btnDeleteContour.Text = "削除"
        Me.btnDeleteContour.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 28)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(17, 12)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "値"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 55)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 12)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "線種"
        '
        'picSepaLinePat
        '
        Me.picSepaLinePat.BackColor = System.Drawing.Color.White
        Me.picSepaLinePat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSepaLinePat.Location = New System.Drawing.Point(42, 55)
        Me.picSepaLinePat.Margin = New System.Windows.Forms.Padding(2)
        Me.picSepaLinePat.Name = "picSepaLinePat"
        Me.picSepaLinePat.Size = New System.Drawing.Size(52, 18)
        Me.picSepaLinePat.TabIndex = 8
        Me.picSepaLinePat.TabStop = False
        '
        'lbSepaContour
        '
        Me.lbSepaContour.FormattingEnabled = True
        Me.lbSepaContour.ItemHeight = 12
        Me.lbSepaContour.Location = New System.Drawing.Point(9, 34)
        Me.lbSepaContour.Margin = New System.Windows.Forms.Padding(2)
        Me.lbSepaContour.Name = "lbSepaContour"
        Me.lbSepaContour.Size = New System.Drawing.Size(112, 124)
        Me.lbSepaContour.TabIndex = 0
        '
        'btnAddContour
        '
        Me.btnAddContour.Location = New System.Drawing.Point(9, 165)
        Me.btnAddContour.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddContour.Name = "btnAddContour"
        Me.btnAddContour.Size = New System.Drawing.Size(77, 22)
        Me.btnAddContour.TabIndex = 2
        Me.btnAddContour.Text = "追加"
        Me.btnAddContour.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(493, 4)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(35, 21)
        Me.btnHelp.TabIndex = 5
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmMain_ContourViewSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(974, 323)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.gbSeparatelySettings)
        Me.Controls.Add(Me.gbRegularInterval)
        Me.Controls.Add(Me.gbPaintHatchContour)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmMain_ContourViewSettings"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "等値線モード"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbPaintHatchContour.ResumeLayout(False)
        CType(Me.picPaitHatchLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRegularInterval.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.picHeavyContour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.picThickContour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.picNormalContour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSeparatelySettings.ResumeLayout(False)
        Me.gbSelectedContour.ResumeLayout(False)
        Me.gbSelectedContour.PerformLayout()
        CType(Me.picSepaLinePat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSeparateSettings As System.Windows.Forms.RadioButton
    Friend WithEvents rbRegularInterval As System.Windows.Forms.RadioButton
    Friend WithEvents rbClassHatchMode As System.Windows.Forms.RadioButton
    Friend WithEvents rbClassPaintMode As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboContourDetail As System.Windows.Forms.ComboBox
    Friend WithEvents chkSpline As System.Windows.Forms.CheckBox
    Friend WithEvents chkInPolygon As System.Windows.Forms.CheckBox
    Friend WithEvents gbPaintHatchContour As System.Windows.Forms.GroupBox
    Friend WithEvents picPaitHatchLine As System.Windows.Forms.PictureBox
    Friend WithEvents gbRegularInterval As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents picHeavyContour As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents picThickContour As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents picNormalContour As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbSeparatelySettings As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddContour As System.Windows.Forms.Button
    Friend WithEvents chkHeavyLine As System.Windows.Forms.CheckBox
    Friend WithEvents gbSelectedContour As System.Windows.Forms.GroupBox
    Friend WithEvents btnDeleteContour As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents picSepaLinePat As System.Windows.Forms.PictureBox
    Friend WithEvents lbSepaContour As System.Windows.Forms.ListBox
    Friend WithEvents btnAllClear As System.Windows.Forms.Button
    Friend WithEvents bynAttangeSepaContour As System.Windows.Forms.Button
    Friend WithEvents btnClassValueSet As System.Windows.Forms.Button
    Friend WithEvents txtMinValue As mandara10.TextNumberBox
    Friend WithEvents txtHeavyLineValue As mandara10.TextNumberBox
    Friend WithEvents txtThickMaxValue As mandara10.TextNumberBox
    Friend WithEvents txtThickIntervalValue As mandara10.TextNumberBox
    Friend WithEvents txtThickMinValue As mandara10.TextNumberBox
    Friend WithEvents txtIntervalValue As mandara10.TextNumberBox
    Friend WithEvents txtMaxValue As mandara10.TextNumberBox
    Friend WithEvents txtSepaContour As mandara10.TextNumberBox
    Friend WithEvents btnHelp As System.Windows.Forms.Button
End Class
