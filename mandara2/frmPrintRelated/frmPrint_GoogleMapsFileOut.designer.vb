<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_GoogleMapsFileOut
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rbLeaflet = New System.Windows.Forms.RadioButton()
        Me.rbGoogle = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkMapSize = New System.Windows.Forms.CheckBox()
        Me.txtMapHeight = New mandara10.TextNumberBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMapWidth = New mandara10.TextNumberBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkDoubleMap = New System.Windows.Forms.CheckBox()
        Me.cboMaxZoomLevel = New mandara10.ComboBoxEx()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbMaptype = New mandara10.ListBoxEx()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMapTitle = New System.Windows.Forms.TextBox()
        Me.KtgisFileSelector1 = New KTGISUserControl.KtgisFileSelector()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.lbLayerZOrder = New System.Windows.Forms.ListBox()
        Me.tabLayer = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pnlLayer = New System.Windows.Forms.Panel()
        Me.gbMarkSizeMode = New System.Windows.Forms.GroupBox()
        Me.lbMappingMarkSizeMode = New mandara10.ListBoxEx()
        Me.gbSetting = New System.Windows.Forms.GroupBox()
        Me.gbLine = New System.Windows.Forms.GroupBox()
        Me.picPolyLineColor = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboPolyOutline = New mandara10.ComboBoxEx()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboToka = New mandara10.ComboBoxEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkLegendVisible = New System.Windows.Forms.CheckBox()
        Me.chkLayerVisible = New System.Windows.Forms.CheckBox()
        Me.gbPaintMode = New System.Windows.Forms.GroupBox()
        Me.lbMappitPaintMode = New mandara10.ListBoxEx()
        Me.gbInfoData = New System.Windows.Forms.GroupBox()
        Me.lbInfoData = New mandara10.ListBoxEx()
        Me.TabPagex = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cboCompress = New System.Windows.Forms.ComboBox()
        Me.chkGPS = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tabLayer.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.pnlLayer.SuspendLayout()
        Me.gbMarkSizeMode.SuspendLayout()
        Me.gbSetting.SuspendLayout()
        Me.gbLine.SuspendLayout()
        CType(Me.picPolyLineColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPaintMode.SuspendLayout()
        Me.gbInfoData.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(740, 565)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(663, 565)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.lbMaptype)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMapTitle)
        Me.GroupBox1.Controls.Add(Me.KtgisFileSelector1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(818, 184)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "全体設定"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rbLeaflet)
        Me.GroupBox5.Controls.Add(Me.rbGoogle)
        Me.GroupBox5.Location = New System.Drawing.Point(17, 23)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(289, 71)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "使用地図ライブラリ"
        '
        'rbLeaflet
        '
        Me.rbLeaflet.AutoSize = True
        Me.rbLeaflet.Checked = True
        Me.rbLeaflet.Location = New System.Drawing.Point(31, 36)
        Me.rbLeaflet.Name = "rbLeaflet"
        Me.rbLeaflet.Size = New System.Drawing.Size(58, 16)
        Me.rbLeaflet.TabIndex = 1
        Me.rbLeaflet.TabStop = True
        Me.rbLeaflet.Text = "Leaflet"
        Me.rbLeaflet.UseVisualStyleBackColor = True
        '
        'rbGoogle
        '
        Me.rbGoogle.AutoSize = True
        Me.rbGoogle.Location = New System.Drawing.Point(134, 37)
        Me.rbGoogle.Name = "rbGoogle"
        Me.rbGoogle.Size = New System.Drawing.Size(111, 16)
        Me.rbGoogle.TabIndex = 0
        Me.rbGoogle.Text = "Google Maps API"
        Me.rbGoogle.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkGPS)
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Controls.Add(Me.chkDoubleMap)
        Me.GroupBox4.Controls.Add(Me.cboMaxZoomLevel)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(314, 23)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(287, 146)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "地図画面"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkMapSize)
        Me.GroupBox3.Controls.Add(Me.txtMapHeight)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtMapWidth)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(267, 71)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "地図の大きさ"
        '
        'chkMapSize
        '
        Me.chkMapSize.AutoSize = True
        Me.chkMapSize.Location = New System.Drawing.Point(21, 18)
        Me.chkMapSize.Name = "chkMapSize"
        Me.chkMapSize.Size = New System.Drawing.Size(122, 16)
        Me.chkMapSize.TabIndex = 1
        Me.chkMapSize.Text = "表示画面に合わせる"
        Me.chkMapSize.UseVisualStyleBackColor = True
        '
        'txtMapHeight
        '
        Me.txtMapHeight.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMapHeight.Location = New System.Drawing.Point(169, 43)
        Me.txtMapHeight.MaxValue = 0.0R
        Me.txtMapHeight.MaxValueFlag = False
        Me.txtMapHeight.MinValue = 0.0R
        Me.txtMapHeight.MinValueFlag = False
        Me.txtMapHeight.Name = "txtMapHeight"
        Me.txtMapHeight.NumberPoint = True
        Me.txtMapHeight.Size = New System.Drawing.Size(43, 19)
        Me.txtMapHeight.TabIndex = 6
        Me.txtMapHeight.Text = "500"
        Me.txtMapHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMapHeight.ValueErrorMessageFlag = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "幅"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(138, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "高さ"
        '
        'txtMapWidth
        '
        Me.txtMapWidth.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMapWidth.Location = New System.Drawing.Point(42, 43)
        Me.txtMapWidth.MaxValue = 0.0R
        Me.txtMapWidth.MaxValueFlag = False
        Me.txtMapWidth.MinValue = 0.0R
        Me.txtMapWidth.MinValueFlag = False
        Me.txtMapWidth.Name = "txtMapWidth"
        Me.txtMapWidth.NumberPoint = True
        Me.txtMapWidth.Size = New System.Drawing.Size(42, 19)
        Me.txtMapWidth.TabIndex = 5
        Me.txtMapWidth.Text = "800"
        Me.txtMapWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMapWidth.ValueErrorMessageFlag = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(90, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "ピクセル"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(218, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "ピクセル"
        '
        'chkDoubleMap
        '
        Me.chkDoubleMap.AutoSize = True
        Me.chkDoubleMap.Location = New System.Drawing.Point(21, 120)
        Me.chkDoubleMap.Name = "chkDoubleMap"
        Me.chkDoubleMap.Size = New System.Drawing.Size(102, 16)
        Me.chkDoubleMap.TabIndex = 3
        Me.chkDoubleMap.Text = "2画面表示可能"
        Me.chkDoubleMap.UseVisualStyleBackColor = True
        '
        'cboMaxZoomLevel
        '
        Me.cboMaxZoomLevel.AsteriskSelectEnabled = False
        Me.cboMaxZoomLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaxZoomLevel.FormattingEnabled = True
        Me.cboMaxZoomLevel.IntegralHeight = False
        Me.cboMaxZoomLevel.Location = New System.Drawing.Point(113, 96)
        Me.cboMaxZoomLevel.Name = "cboMaxZoomLevel"
        Me.cboMaxZoomLevel.Size = New System.Drawing.Size(97, 20)
        Me.cboMaxZoomLevel.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "最大ズームレベル"
        '
        'lbMaptype
        '
        Me.lbMaptype.AsteriskSelectEnabled = False
        Me.lbMaptype.FormattingEnabled = True
        Me.lbMaptype.ItemHeight = 12
        Me.lbMaptype.Location = New System.Drawing.Point(625, 41)
        Me.lbMaptype.Name = "lbMaptype"
        Me.lbMaptype.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbMaptype.Size = New System.Drawing.Size(187, 124)
        Me.lbMaptype.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(623, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "背景画像"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "タイトル"
        '
        'txtMapTitle
        '
        Me.txtMapTitle.Location = New System.Drawing.Point(68, 150)
        Me.txtMapTitle.Name = "txtMapTitle"
        Me.txtMapTitle.Size = New System.Drawing.Size(238, 19)
        Me.txtMapTitle.TabIndex = 2
        '
        'KtgisFileSelector1
        '
        Me.KtgisFileSelector1.Caption = "出力ファイル"
        Me.KtgisFileSelector1.Extension = "html"
        Me.KtgisFileSelector1.InitFolder = ""
        Me.KtgisFileSelector1.Location = New System.Drawing.Point(14, 100)
        Me.KtgisFileSelector1.Name = "KtgisFileSelector1"
        Me.KtgisFileSelector1.Off_Button_Flag = False
        Me.KtgisFileSelector1.Path = ""
        Me.KtgisFileSelector1.Save_Flag = True
        Me.KtgisFileSelector1.Size = New System.Drawing.Size(294, 42)
        Me.KtgisFileSelector1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnDown)
        Me.GroupBox2.Controls.Add(Me.btnUp)
        Me.GroupBox2.Controls.Add(Me.lbLayerZOrder)
        Me.GroupBox2.Location = New System.Drawing.Point(558, 232)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(264, 142)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "選択されているレイヤの描画順"
        '
        'btnDown
        '
        Me.btnDown.Location = New System.Drawing.Point(180, 87)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(78, 38)
        Me.btnDown.TabIndex = 2
        Me.btnDown.Text = "後に描画（上に表示）"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Location = New System.Drawing.Point(180, 28)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(78, 38)
        Me.btnUp.TabIndex = 1
        Me.btnUp.Text = "先に描画（下に表示）"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'lbLayerZOrder
        '
        Me.lbLayerZOrder.FormattingEnabled = True
        Me.lbLayerZOrder.ItemHeight = 12
        Me.lbLayerZOrder.Location = New System.Drawing.Point(13, 26)
        Me.lbLayerZOrder.Name = "lbLayerZOrder"
        Me.lbLayerZOrder.Size = New System.Drawing.Size(157, 100)
        Me.lbLayerZOrder.TabIndex = 0
        '
        'tabLayer
        '
        Me.tabLayer.Controls.Add(Me.TabPage1)
        Me.tabLayer.Controls.Add(Me.TabPagex)
        Me.tabLayer.Location = New System.Drawing.Point(10, 210)
        Me.tabLayer.Name = "tabLayer"
        Me.tabLayer.SelectedIndex = 0
        Me.tabLayer.Size = New System.Drawing.Size(529, 383)
        Me.tabLayer.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.pnlLayer)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(521, 357)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'pnlLayer
        '
        Me.pnlLayer.Controls.Add(Me.gbMarkSizeMode)
        Me.pnlLayer.Controls.Add(Me.gbSetting)
        Me.pnlLayer.Controls.Add(Me.gbPaintMode)
        Me.pnlLayer.Controls.Add(Me.gbInfoData)
        Me.pnlLayer.Location = New System.Drawing.Point(13, 15)
        Me.pnlLayer.Name = "pnlLayer"
        Me.pnlLayer.Size = New System.Drawing.Size(495, 321)
        Me.pnlLayer.TabIndex = 4
        '
        'gbMarkSizeMode
        '
        Me.gbMarkSizeMode.Controls.Add(Me.lbMappingMarkSizeMode)
        Me.gbMarkSizeMode.Location = New System.Drawing.Point(252, 13)
        Me.gbMarkSizeMode.Name = "gbMarkSizeMode"
        Me.gbMarkSizeMode.Size = New System.Drawing.Size(224, 147)
        Me.gbMarkSizeMode.TabIndex = 1
        Me.gbMarkSizeMode.TabStop = False
        Me.gbMarkSizeMode.Text = "記号の大きさモードで表示されるデータ項目"
        '
        'lbMappingMarkSizeMode
        '
        Me.lbMappingMarkSizeMode.AsteriskSelectEnabled = False
        Me.lbMappingMarkSizeMode.FormattingEnabled = True
        Me.lbMappingMarkSizeMode.ItemHeight = 12
        Me.lbMappingMarkSizeMode.Location = New System.Drawing.Point(11, 19)
        Me.lbMappingMarkSizeMode.Name = "lbMappingMarkSizeMode"
        Me.lbMappingMarkSizeMode.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbMappingMarkSizeMode.Size = New System.Drawing.Size(207, 112)
        Me.lbMappingMarkSizeMode.TabIndex = 0
        '
        'gbSetting
        '
        Me.gbSetting.Controls.Add(Me.gbLine)
        Me.gbSetting.Controls.Add(Me.cboToka)
        Me.gbSetting.Controls.Add(Me.Label8)
        Me.gbSetting.Controls.Add(Me.chkLegendVisible)
        Me.gbSetting.Controls.Add(Me.chkLayerVisible)
        Me.gbSetting.Location = New System.Drawing.Point(252, 166)
        Me.gbSetting.Name = "gbSetting"
        Me.gbSetting.Size = New System.Drawing.Size(224, 147)
        Me.gbSetting.TabIndex = 3
        Me.gbSetting.TabStop = False
        Me.gbSetting.Text = "レイヤ設定"
        '
        'gbLine
        '
        Me.gbLine.Controls.Add(Me.picPolyLineColor)
        Me.gbLine.Controls.Add(Me.Label11)
        Me.gbLine.Controls.Add(Me.cboPolyOutline)
        Me.gbLine.Controls.Add(Me.Label9)
        Me.gbLine.Location = New System.Drawing.Point(14, 82)
        Me.gbLine.Name = "gbLine"
        Me.gbLine.Size = New System.Drawing.Size(204, 50)
        Me.gbLine.TabIndex = 12
        Me.gbLine.TabStop = False
        Me.gbLine.Text = "輪郭線"
        '
        'picPolyLineColor
        '
        Me.picPolyLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPolyLineColor.Location = New System.Drawing.Point(144, 17)
        Me.picPolyLineColor.Name = "picPolyLineColor"
        Me.picPolyLineColor.Size = New System.Drawing.Size(46, 20)
        Me.picPolyLineColor.TabIndex = 15
        Me.picPolyLineColor.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(120, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 12)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "色"
        '
        'cboPolyOutline
        '
        Me.cboPolyOutline.AsteriskSelectEnabled = False
        Me.cboPolyOutline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPolyOutline.FormattingEnabled = True
        Me.cboPolyOutline.IntegralHeight = False
        Me.cboPolyOutline.Location = New System.Drawing.Point(29, 18)
        Me.cboPolyOutline.MaxDropDownItems = 11
        Me.cboPolyOutline.Name = "cboPolyOutline"
        Me.cboPolyOutline.Size = New System.Drawing.Size(71, 20)
        Me.cboPolyOutline.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 12)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "幅"
        '
        'cboToka
        '
        Me.cboToka.AsteriskSelectEnabled = False
        Me.cboToka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToka.FormattingEnabled = True
        Me.cboToka.IntegralHeight = False
        Me.cboToka.Location = New System.Drawing.Point(61, 52)
        Me.cboToka.MaxDropDownItems = 11
        Me.cboToka.Name = "cboToka"
        Me.cboToka.Size = New System.Drawing.Size(97, 20)
        Me.cboToka.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "透過度"
        '
        'chkLegendVisible
        '
        Me.chkLegendVisible.AutoSize = True
        Me.chkLegendVisible.Location = New System.Drawing.Point(136, 30)
        Me.chkLegendVisible.Name = "chkLegendVisible"
        Me.chkLegendVisible.Size = New System.Drawing.Size(82, 16)
        Me.chkLegendVisible.TabIndex = 1
        Me.chkLegendVisible.Text = "凡例の表示"
        Me.chkLegendVisible.UseVisualStyleBackColor = True
        '
        'chkLayerVisible
        '
        Me.chkLayerVisible.AutoSize = True
        Me.chkLayerVisible.Location = New System.Drawing.Point(17, 30)
        Me.chkLayerVisible.Name = "chkLayerVisible"
        Me.chkLayerVisible.Size = New System.Drawing.Size(112, 16)
        Me.chkLayerVisible.TabIndex = 0
        Me.chkLayerVisible.Text = "初期表示にチェック"
        Me.chkLayerVisible.UseVisualStyleBackColor = True
        '
        'gbPaintMode
        '
        Me.gbPaintMode.Controls.Add(Me.lbMappitPaintMode)
        Me.gbPaintMode.Location = New System.Drawing.Point(11, 13)
        Me.gbPaintMode.Name = "gbPaintMode"
        Me.gbPaintMode.Size = New System.Drawing.Size(224, 147)
        Me.gbPaintMode.TabIndex = 0
        Me.gbPaintMode.TabStop = False
        Me.gbPaintMode.Text = "ペイントモードで表示されるデータ項目"
        '
        'lbMappitPaintMode
        '
        Me.lbMappitPaintMode.AsteriskSelectEnabled = False
        Me.lbMappitPaintMode.FormattingEnabled = True
        Me.lbMappitPaintMode.ItemHeight = 12
        Me.lbMappitPaintMode.Location = New System.Drawing.Point(11, 19)
        Me.lbMappitPaintMode.Name = "lbMappitPaintMode"
        Me.lbMappitPaintMode.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbMappitPaintMode.Size = New System.Drawing.Size(207, 112)
        Me.lbMappitPaintMode.TabIndex = 0
        '
        'gbInfoData
        '
        Me.gbInfoData.Controls.Add(Me.lbInfoData)
        Me.gbInfoData.Location = New System.Drawing.Point(11, 168)
        Me.gbInfoData.Name = "gbInfoData"
        Me.gbInfoData.Size = New System.Drawing.Size(224, 147)
        Me.gbInfoData.TabIndex = 2
        Me.gbInfoData.TabStop = False
        Me.gbInfoData.Text = "クリック時に表示されるデータ項目"
        '
        'lbInfoData
        '
        Me.lbInfoData.AsteriskSelectEnabled = False
        Me.lbInfoData.FormattingEnabled = True
        Me.lbInfoData.ItemHeight = 12
        Me.lbInfoData.Location = New System.Drawing.Point(11, 19)
        Me.lbInfoData.Name = "lbInfoData"
        Me.lbInfoData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbInfoData.Size = New System.Drawing.Size(207, 112)
        Me.lbInfoData.TabIndex = 0
        '
        'TabPagex
        '
        Me.TabPagex.Location = New System.Drawing.Point(4, 22)
        Me.TabPagex.Name = "TabPagex"
        Me.TabPagex.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPagex.Size = New System.Drawing.Size(521, 357)
        Me.TabPagex.TabIndex = 1
        Me.TabPagex.Text = "TabPage2"
        Me.TabPagex.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cboCompress)
        Me.GroupBox6.Location = New System.Drawing.Point(558, 388)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(152, 71)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "座標の取得"
        '
        'cboCompress
        '
        Me.cboCompress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompress.FormattingEnabled = True
        Me.cboCompress.Items.AddRange(New Object() {"そのまま", "1/2取得", "1/3取得", "1/4取得"})
        Me.cboCompress.Location = New System.Drawing.Point(21, 27)
        Me.cboCompress.Name = "cboCompress"
        Me.cboCompress.Size = New System.Drawing.Size(107, 20)
        Me.cboCompress.TabIndex = 0
        '
        'chkGPS
        '
        Me.chkGPS.AutoSize = True
        Me.chkGPS.Location = New System.Drawing.Point(139, 120)
        Me.chkGPS.Name = "chkGPS"
        Me.chkGPS.Size = New System.Drawing.Size(70, 16)
        Me.chkGPS.TabIndex = 4
        Me.chkGPS.Text = "GPS機能"
        Me.chkGPS.UseVisualStyleBackColor = True
        '
        'frmPrint_GoogleMapsFileOut
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(840, 604)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.tabLayer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_GoogleMapsFileOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Googleマップ・Leafletに出力"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.tabLayer.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.pnlLayer.ResumeLayout(False)
        Me.gbMarkSizeMode.ResumeLayout(False)
        Me.gbSetting.ResumeLayout(False)
        Me.gbSetting.PerformLayout()
        Me.gbLine.ResumeLayout(False)
        Me.gbLine.PerformLayout()
        CType(Me.picPolyLineColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPaintMode.ResumeLayout(False)
        Me.gbInfoData.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMapWidth As mandara10.TextNumberBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMapTitle As System.Windows.Forms.TextBox
    Friend WithEvents KtgisFileSelector1 As KTGISUserControl.KtgisFileSelector
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents lbLayerZOrder As System.Windows.Forms.ListBox
    Friend WithEvents lbMaptype As mandara10.ListBoxEx
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboMaxZoomLevel As mandara10.ComboBoxEx
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMapHeight As mandara10.TextNumberBox
    Friend WithEvents tabLayer As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents gbPaintMode As System.Windows.Forms.GroupBox
    Friend WithEvents TabPagex As System.Windows.Forms.TabPage
    Friend WithEvents pnlLayer As System.Windows.Forms.Panel
    Friend WithEvents gbMarkSizeMode As System.Windows.Forms.GroupBox
    Friend WithEvents gbSetting As System.Windows.Forms.GroupBox
    Friend WithEvents gbLine As System.Windows.Forms.GroupBox
    Friend WithEvents picPolyLineColor As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboPolyOutline As mandara10.ComboBoxEx
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboToka As mandara10.ComboBoxEx
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkLegendVisible As System.Windows.Forms.CheckBox
    Friend WithEvents chkLayerVisible As System.Windows.Forms.CheckBox
    Friend WithEvents gbInfoData As System.Windows.Forms.GroupBox
    Friend WithEvents lbMappingMarkSizeMode As mandara10.ListBoxEx
    Friend WithEvents lbMappitPaintMode As mandara10.ListBoxEx
    Friend WithEvents lbInfoData As mandara10.ListBoxEx
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkMapSize As System.Windows.Forms.CheckBox
    Friend WithEvents chkDoubleMap As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbLeaflet As System.Windows.Forms.RadioButton
    Friend WithEvents rbGoogle As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCompress As System.Windows.Forms.ComboBox
    Friend WithEvents chkGPS As System.Windows.Forms.CheckBox
End Class
