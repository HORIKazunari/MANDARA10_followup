<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_KMLFileOut
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
        Me.FileSelect = New KTGISUserControl.KtgisFileSelector()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.hsbTransparency = New System.Windows.Forms.HScrollBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbPointShape = New System.Windows.Forms.GroupBox()
        Me.cboPoint = New mandara10.ComboBoxEx()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.picPolyLineColor = New System.Windows.Forms.PictureBox()
        Me.lblPolyInner = New System.Windows.Forms.Label()
        Me.cboPolyOutline = New mandara10.ComboBoxEx()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkLegend = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkHeight = New System.Windows.Forms.CheckBox()
        Me.gbHeight = New System.Windows.Forms.GroupBox()
        Me.rbSeaLevel = New System.Windows.Forms.RadioButton()
        Me.rbGround = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboAltiData = New mandara10.ComboBoxEx()
        Me.chkExtrude = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMaxAltitude = New mandara10.TextNumberBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtRegionLodMax = New mandara10.TextNumberBox()
        Me.txtRegionLodMin = New mandara10.TextNumberBox()
        Me.chkRegion = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.chkObjectNameMarker = New System.Windows.Forms.CheckBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.lbData = New mandara10.ListBoxEx()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.chkObjectNameRegion = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtObjectNameLodMax = New mandara10.TextNumberBox()
        Me.txtObjectNameLodMin = New mandara10.TextNumberBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkObjectName = New System.Windows.Forms.CheckBox()
        Me.chkDataItem = New System.Windows.Forms.CheckBox()
        Me.chkDataValue = New System.Windows.Forms.CheckBox()
        Me.chkUnit = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbPointShape.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.picPolyLineColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.gbHeight.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(725, 420)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(658, 420)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'FileSelect
        '
        Me.FileSelect.Caption = "出力ファイル"
        Me.FileSelect.Extension = "kml"
        Me.FileSelect.InitFolder = ""
        Me.FileSelect.Location = New System.Drawing.Point(12, 12)
        Me.FileSelect.Name = "FileSelect"
        Me.FileSelect.Off_Button_Flag = False
        Me.FileSelect.Path = ""
        Me.FileSelect.Save_Flag = True
        Me.FileSelect.Size = New System.Drawing.Size(388, 44)
        Me.FileSelect.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(226, 58)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "透過度"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.hsbTransparency)
        Me.Panel1.Location = New System.Drawing.Point(54, 26)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(112, 19)
        Me.Panel1.TabIndex = 21
        '
        'hsbTransparency
        '
        Me.hsbTransparency.Dock = System.Windows.Forms.DockStyle.Top
        Me.hsbTransparency.LargeChange = 32
        Me.hsbTransparency.Location = New System.Drawing.Point(0, 0)
        Me.hsbTransparency.Maximum = 255
        Me.hsbTransparency.Name = "hsbTransparency"
        Me.hsbTransparency.Size = New System.Drawing.Size(110, 21)
        Me.hsbTransparency.SmallChange = 16
        Me.hsbTransparency.TabIndex = 24
        Me.hsbTransparency.Value = 200
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(165, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "不透明"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "透明"
        '
        'gbPointShape
        '
        Me.gbPointShape.Controls.Add(Me.cboPoint)
        Me.gbPointShape.Location = New System.Drawing.Point(12, 126)
        Me.gbPointShape.Name = "gbPointShape"
        Me.gbPointShape.Size = New System.Drawing.Size(226, 58)
        Me.gbPointShape.TabIndex = 2
        Me.gbPointShape.TabStop = False
        Me.gbPointShape.Text = "記号の形状"
        '
        'cboPoint
        '
        Me.cboPoint.AsteriskSelectEnabled = False
        Me.cboPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPoint.FormattingEnabled = True
        Me.cboPoint.IntegralHeight = False
        Me.cboPoint.Location = New System.Drawing.Point(80, 19)
        Me.cboPoint.Name = "cboPoint"
        Me.cboPoint.Size = New System.Drawing.Size(66, 20)
        Me.cboPoint.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.picPolyLineColor)
        Me.GroupBox3.Controls.Add(Me.lblPolyInner)
        Me.GroupBox3.Controls.Add(Me.cboPolyOutline)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 191)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(226, 58)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "輪郭線"
        '
        'picPolyLineColor
        '
        Me.picPolyLineColor.BackColor = System.Drawing.Color.White
        Me.picPolyLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPolyLineColor.Location = New System.Drawing.Point(148, 19)
        Me.picPolyLineColor.Name = "picPolyLineColor"
        Me.picPolyLineColor.Size = New System.Drawing.Size(44, 26)
        Me.picPolyLineColor.TabIndex = 3
        Me.picPolyLineColor.TabStop = False
        '
        'lblPolyInner
        '
        Me.lblPolyInner.AutoSize = True
        Me.lblPolyInner.Location = New System.Drawing.Point(125, 24)
        Me.lblPolyInner.Name = "lblPolyInner"
        Me.lblPolyInner.Size = New System.Drawing.Size(17, 12)
        Me.lblPolyInner.TabIndex = 2
        Me.lblPolyInner.Text = "色"
        '
        'cboPolyOutline
        '
        Me.cboPolyOutline.AsteriskSelectEnabled = False
        Me.cboPolyOutline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPolyOutline.FormattingEnabled = True
        Me.cboPolyOutline.IntegralHeight = False
        Me.cboPolyOutline.Location = New System.Drawing.Point(22, 21)
        Me.cboPolyOutline.Name = "cboPolyOutline"
        Me.cboPolyOutline.Size = New System.Drawing.Size(80, 20)
        Me.cboPolyOutline.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkLegend)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 259)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(226, 58)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "凡例"
        '
        'chkLegend
        '
        Me.chkLegend.AutoSize = True
        Me.chkLegend.Location = New System.Drawing.Point(22, 27)
        Me.chkLegend.Name = "chkLegend"
        Me.chkLegend.Size = New System.Drawing.Size(124, 16)
        Me.chkLegend.TabIndex = 36
        Me.chkLegend.Text = "凡例画像を出力する"
        Me.chkLegend.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkHeight)
        Me.GroupBox5.Controls.Add(Me.gbHeight)
        Me.GroupBox5.Location = New System.Drawing.Point(260, 67)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(226, 227)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "高さ"
        '
        'chkHeight
        '
        Me.chkHeight.AutoSize = True
        Me.chkHeight.Location = New System.Drawing.Point(20, 28)
        Me.chkHeight.Name = "chkHeight"
        Me.chkHeight.Size = New System.Drawing.Size(96, 16)
        Me.chkHeight.TabIndex = 0
        Me.chkHeight.Text = "高さを設定する"
        Me.chkHeight.UseVisualStyleBackColor = True
        '
        'gbHeight
        '
        Me.gbHeight.Controls.Add(Me.rbSeaLevel)
        Me.gbHeight.Controls.Add(Me.rbGround)
        Me.gbHeight.Controls.Add(Me.Label10)
        Me.gbHeight.Controls.Add(Me.cboAltiData)
        Me.gbHeight.Controls.Add(Me.chkExtrude)
        Me.gbHeight.Controls.Add(Me.Label2)
        Me.gbHeight.Controls.Add(Me.Label7)
        Me.gbHeight.Controls.Add(Me.txtMaxAltitude)
        Me.gbHeight.Location = New System.Drawing.Point(11, 56)
        Me.gbHeight.Name = "gbHeight"
        Me.gbHeight.Size = New System.Drawing.Size(209, 165)
        Me.gbHeight.TabIndex = 1
        Me.gbHeight.TabStop = False
        Me.gbHeight.Text = "高さ"
        '
        'rbSeaLevel
        '
        Me.rbSeaLevel.AutoSize = True
        Me.rbSeaLevel.Location = New System.Drawing.Point(105, 20)
        Me.rbSeaLevel.Name = "rbSeaLevel"
        Me.rbSeaLevel.Size = New System.Drawing.Size(65, 16)
        Me.rbSeaLevel.TabIndex = 1
        Me.rbSeaLevel.TabStop = True
        Me.rbSeaLevel.Text = "海面から"
        Me.rbSeaLevel.UseVisualStyleBackColor = True
        '
        'rbGround
        '
        Me.rbGround.AutoSize = True
        Me.rbGround.Checked = True
        Me.rbGround.Location = New System.Drawing.Point(17, 20)
        Me.rbGround.Name = "rbGround"
        Me.rbGround.Size = New System.Drawing.Size(65, 16)
        Me.rbGround.TabIndex = 0
        Me.rbGround.TabStop = True
        Me.rbGround.Text = "地面から"
        Me.rbGround.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 12)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "高さデータ"
        '
        'cboAltiData
        '
        Me.cboAltiData.AsteriskSelectEnabled = False
        Me.cboAltiData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAltiData.FormattingEnabled = True
        Me.cboAltiData.IntegralHeight = False
        Me.cboAltiData.Location = New System.Drawing.Point(34, 66)
        Me.cboAltiData.Name = "cboAltiData"
        Me.cboAltiData.Size = New System.Drawing.Size(161, 20)
        Me.cboAltiData.TabIndex = 2
        '
        'chkExtrude
        '
        Me.chkExtrude.AutoSize = True
        Me.chkExtrude.Checked = True
        Me.chkExtrude.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExtrude.Location = New System.Drawing.Point(15, 136)
        Me.chkExtrude.Name = "chkExtrude"
        Me.chkExtrude.Size = New System.Drawing.Size(98, 16)
        Me.chkExtrude.TabIndex = 4
        Me.chkExtrude.Text = "地面まで降ろす"
        Me.chkExtrude.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "最大の高さ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(165, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 12)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "km"
        '
        'txtMaxAltitude
        '
        Me.txtMaxAltitude.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMaxAltitude.Location = New System.Drawing.Point(82, 99)
        Me.txtMaxAltitude.MaxValue = 0.0R
        Me.txtMaxAltitude.MaxValueFlag = False
        Me.txtMaxAltitude.MinValue = 0.0R
        Me.txtMaxAltitude.MinValueFlag = False
        Me.txtMaxAltitude.Name = "txtMaxAltitude"
        Me.txtMaxAltitude.NumberPoint = True
        Me.txtMaxAltitude.Size = New System.Drawing.Size(77, 19)
        Me.txtMaxAltitude.TabIndex = 3
        Me.txtMaxAltitude.Text = "50"
        Me.txtMaxAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaxAltitude.ValueErrorMessageFlag = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtRegionLodMax)
        Me.GroupBox6.Controls.Add(Me.txtRegionLodMin)
        Me.GroupBox6.Controls.Add(Me.chkRegion)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Location = New System.Drawing.Point(260, 310)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(226, 93)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Regionタグの設定"
        '
        'txtRegionLodMax
        '
        Me.txtRegionLodMax.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtRegionLodMax.Location = New System.Drawing.Point(57, 65)
        Me.txtRegionLodMax.MaxValue = 0.0R
        Me.txtRegionLodMax.MaxValueFlag = False
        Me.txtRegionLodMax.MinValue = 0.0R
        Me.txtRegionLodMax.MinValueFlag = False
        Me.txtRegionLodMax.Name = "txtRegionLodMax"
        Me.txtRegionLodMax.NumberPoint = True
        Me.txtRegionLodMax.Size = New System.Drawing.Size(77, 19)
        Me.txtRegionLodMax.TabIndex = 37
        Me.txtRegionLodMax.Text = "-1"
        Me.txtRegionLodMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRegionLodMax.ValueErrorMessageFlag = True
        '
        'txtRegionLodMin
        '
        Me.txtRegionLodMin.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtRegionLodMin.Location = New System.Drawing.Point(57, 40)
        Me.txtRegionLodMin.MaxValue = 0.0R
        Me.txtRegionLodMin.MaxValueFlag = False
        Me.txtRegionLodMin.MinValue = 0.0R
        Me.txtRegionLodMin.MinValueFlag = False
        Me.txtRegionLodMin.Name = "txtRegionLodMin"
        Me.txtRegionLodMin.NumberPoint = True
        Me.txtRegionLodMin.Size = New System.Drawing.Size(77, 19)
        Me.txtRegionLodMin.TabIndex = 36
        Me.txtRegionLodMin.Text = "100"
        Me.txtRegionLodMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRegionLodMin.ValueErrorMessageFlag = True
        '
        'chkRegion
        '
        Me.chkRegion.AutoSize = True
        Me.chkRegion.Location = New System.Drawing.Point(17, 18)
        Me.chkRegion.Name = "chkRegion"
        Me.chkRegion.Size = New System.Drawing.Size(67, 16)
        Me.chkRegion.TabIndex = 35
        Me.chkRegion.Text = "設定する"
        Me.chkRegion.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(140, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 12)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "ピクセル以下"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(140, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "ピクセル以上"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.chkObjectNameMarker)
        Me.GroupBox7.Controls.Add(Me.GroupBox9)
        Me.GroupBox7.Controls.Add(Me.GroupBox8)
        Me.GroupBox7.Location = New System.Drawing.Point(503, 67)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(284, 336)
        Me.GroupBox7.TabIndex = 7
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "オブジェクト名マーカー・データ値"
        '
        'chkObjectNameMarker
        '
        Me.chkObjectNameMarker.AutoSize = True
        Me.chkObjectNameMarker.Location = New System.Drawing.Point(20, 28)
        Me.chkObjectNameMarker.Name = "chkObjectNameMarker"
        Me.chkObjectNameMarker.Size = New System.Drawing.Size(162, 16)
        Me.chkObjectNameMarker.TabIndex = 0
        Me.chkObjectNameMarker.Text = "オブジェクト名マーカーをつける"
        Me.chkObjectNameMarker.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.lbData)
        Me.GroupBox9.Location = New System.Drawing.Point(20, 56)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(246, 141)
        Me.GroupBox9.TabIndex = 1
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "クリック時に表示されるデータ項目"
        '
        'lbData
        '
        Me.lbData.AsteriskSelectEnabled = False
        Me.lbData.FormattingEnabled = True
        Me.lbData.ItemHeight = 12
        Me.lbData.Location = New System.Drawing.Point(16, 20)
        Me.lbData.Name = "lbData"
        Me.lbData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbData.Size = New System.Drawing.Size(224, 112)
        Me.lbData.TabIndex = 4
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.chkObjectNameRegion)
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Controls.Add(Me.txtObjectNameLodMax)
        Me.GroupBox8.Controls.Add(Me.txtObjectNameLodMin)
        Me.GroupBox8.Location = New System.Drawing.Point(20, 207)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(246, 120)
        Me.GroupBox8.TabIndex = 30
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Regionタグの設定"
        '
        'chkObjectNameRegion
        '
        Me.chkObjectNameRegion.AutoSize = True
        Me.chkObjectNameRegion.Checked = True
        Me.chkObjectNameRegion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkObjectNameRegion.Location = New System.Drawing.Point(16, 23)
        Me.chkObjectNameRegion.Name = "chkObjectNameRegion"
        Me.chkObjectNameRegion.Size = New System.Drawing.Size(67, 16)
        Me.chkObjectNameRegion.TabIndex = 0
        Me.chkObjectNameRegion.Text = "設定する"
        Me.chkObjectNameRegion.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(109, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 12)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "ピクセル以下"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(109, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 12)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "ピクセル以上"
        '
        'txtObjectNameLodMax
        '
        Me.txtObjectNameLodMax.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtObjectNameLodMax.Location = New System.Drawing.Point(26, 85)
        Me.txtObjectNameLodMax.MaxValue = 0.0R
        Me.txtObjectNameLodMax.MaxValueFlag = False
        Me.txtObjectNameLodMax.MinValue = 0.0R
        Me.txtObjectNameLodMax.MinValueFlag = False
        Me.txtObjectNameLodMax.Name = "txtObjectNameLodMax"
        Me.txtObjectNameLodMax.NumberPoint = True
        Me.txtObjectNameLodMax.Size = New System.Drawing.Size(77, 19)
        Me.txtObjectNameLodMax.TabIndex = 2
        Me.txtObjectNameLodMax.Text = "-1"
        Me.txtObjectNameLodMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtObjectNameLodMax.ValueErrorMessageFlag = True
        '
        'txtObjectNameLodMin
        '
        Me.txtObjectNameLodMin.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtObjectNameLodMin.Location = New System.Drawing.Point(26, 53)
        Me.txtObjectNameLodMin.MaxValue = 0.0R
        Me.txtObjectNameLodMin.MaxValueFlag = False
        Me.txtObjectNameLodMin.MinValue = 0.0R
        Me.txtObjectNameLodMin.MinValueFlag = False
        Me.txtObjectNameLodMin.Name = "txtObjectNameLodMin"
        Me.txtObjectNameLodMin.NumberPoint = True
        Me.txtObjectNameLodMin.Size = New System.Drawing.Size(77, 19)
        Me.txtObjectNameLodMin.TabIndex = 1
        Me.txtObjectNameLodMin.Text = "200"
        Me.txtObjectNameLodMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtObjectNameLodMin.ValueErrorMessageFlag = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkUnit)
        Me.GroupBox2.Controls.Add(Me.chkDataValue)
        Me.GroupBox2.Controls.Add(Me.chkDataItem)
        Me.GroupBox2.Controls.Add(Me.chkObjectName)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 334)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(226, 80)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "クリック時の表示項目"
        '
        'chkObjectName
        '
        Me.chkObjectName.AutoSize = True
        Me.chkObjectName.Checked = True
        Me.chkObjectName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkObjectName.Location = New System.Drawing.Point(22, 27)
        Me.chkObjectName.Name = "chkObjectName"
        Me.chkObjectName.Size = New System.Drawing.Size(87, 16)
        Me.chkObjectName.TabIndex = 36
        Me.chkObjectName.Text = "オブジェクト名"
        Me.chkObjectName.UseVisualStyleBackColor = True
        '
        'chkDataItem
        '
        Me.chkDataItem.AutoSize = True
        Me.chkDataItem.Checked = True
        Me.chkDataItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDataItem.Location = New System.Drawing.Point(119, 28)
        Me.chkDataItem.Name = "chkDataItem"
        Me.chkDataItem.Size = New System.Drawing.Size(88, 16)
        Me.chkDataItem.TabIndex = 37
        Me.chkDataItem.Text = "データ項目名"
        Me.chkDataItem.UseVisualStyleBackColor = True
        '
        'chkDataValue
        '
        Me.chkDataValue.AutoSize = True
        Me.chkDataValue.Checked = True
        Me.chkDataValue.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDataValue.Location = New System.Drawing.Point(22, 53)
        Me.chkDataValue.Name = "chkDataValue"
        Me.chkDataValue.Size = New System.Drawing.Size(64, 16)
        Me.chkDataValue.TabIndex = 38
        Me.chkDataValue.Text = "データ値"
        Me.chkDataValue.UseVisualStyleBackColor = True
        '
        'chkUnit
        '
        Me.chkUnit.AutoSize = True
        Me.chkUnit.Checked = True
        Me.chkUnit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUnit.Location = New System.Drawing.Point(119, 50)
        Me.chkUnit.Name = "chkUnit"
        Me.chkUnit.Size = New System.Drawing.Size(48, 16)
        Me.chkUnit.TabIndex = 39
        Me.chkUnit.Text = "単位"
        Me.chkUnit.UseVisualStyleBackColor = True
        '
        'frmPrint_KMLFileOut
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(803, 459)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.gbPointShape)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.FileSelect)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_KMLFileOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "KML形式で出力"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.gbPointShape.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.picPolyLineColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.gbHeight.ResumeLayout(False)
        Me.gbHeight.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents FileSelect As KTGISUserControl.KtgisFileSelector
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbPointShape As System.Windows.Forms.GroupBox
    Friend WithEvents cboPoint As mandara10.ComboBoxEx
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents picPolyLineColor As System.Windows.Forms.PictureBox
    Friend WithEvents lblPolyInner As System.Windows.Forms.Label
    Friend WithEvents cboPolyOutline As mandara10.ComboBoxEx
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkLegend As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkExtrude As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMaxAltitude As mandara10.TextNumberBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbHeight As System.Windows.Forms.GroupBox
    Friend WithEvents cboAltiData As mandara10.ComboBoxEx
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRegionLodMax As mandara10.TextNumberBox
    Friend WithEvents txtRegionLodMin As mandara10.TextNumberBox
    Friend WithEvents chkRegion As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents chkObjectNameMarker As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents chkObjectNameRegion As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtObjectNameLodMax As mandara10.TextNumberBox
    Friend WithEvents txtObjectNameLodMin As mandara10.TextNumberBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents hsbTransparency As System.Windows.Forms.HScrollBar
    Friend WithEvents chkHeight As System.Windows.Forms.CheckBox
    Friend WithEvents rbSeaLevel As System.Windows.Forms.RadioButton
    Friend WithEvents rbGround As System.Windows.Forms.RadioButton
    Friend WithEvents lbData As mandara10.ListBoxEx
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDataValue As System.Windows.Forms.CheckBox
    Friend WithEvents chkDataItem As System.Windows.Forms.CheckBox
    Friend WithEvents chkObjectName As System.Windows.Forms.CheckBox
    Friend WithEvents chkUnit As System.Windows.Forms.CheckBox
End Class
