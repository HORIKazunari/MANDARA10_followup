<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_GraphModeSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain_GraphModeSettings))
        Me.gbGraphMode = New System.Windows.Forms.GroupBox()
        Me.rbBarChart = New System.Windows.Forms.RadioButton()
        Me.rbLineChart = New System.Windows.Forms.RadioButton()
        Me.rbStackedBarChart = New System.Windows.Forms.RadioButton()
        Me.rbPieChart = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboGraphDataSet = New mandara10.ComboBoxEx()
        Me.btnDeleteDataSet = New System.Windows.Forms.Button()
        Me.lblDataSetTitle = New System.Windows.Forms.Label()
        Me.txtDataSetTitle = New System.Windows.Forms.TextBox()
        Me.btnAddDataSet = New System.Windows.Forms.Button()
        Me.btnAllClear = New System.Windows.Forms.Button()
        Me.btnObjDownward = New System.Windows.Forms.Button()
        Me.btnObjUpward = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.gbDataItems = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.pnlDataItemBase = New System.Windows.Forms.Panel()
        Me.pnlDataItem = New System.Windows.Forms.Panel()
        Me.btnAddRange = New System.Windows.Forms.Button()
        Me.gbGraphSettings = New System.Windows.Forms.GroupBox()
        Me.gbMaxMinValue = New System.Windows.Forms.GroupBox()
        Me.pnlMaxMinValue = New System.Windows.Forms.Panel()
        Me.txtMinValue = New mandara10.TextNumberBox()
        Me.txtMaxValue = New mandara10.TextNumberBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rbManual = New System.Windows.Forms.RadioButton()
        Me.rbAuto = New System.Windows.Forms.RadioButton()
        Me.gbLegendValue = New System.Windows.Forms.GroupBox()
        Me.txtLegendValue3 = New mandara10.TextNumberBox()
        Me.txtLegendValue2 = New mandara10.TextNumberBox()
        Me.txtLegendValue1 = New mandara10.TextNumberBox()
        Me.gbBarLineSize = New System.Windows.Forms.GroupBox()
        Me.txtBarLineSize = New mandara10.TextNumberBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbMaxSizeValue = New System.Windows.Forms.GroupBox()
        Me.txtMaxSizeValue = New mandara10.TextNumberBox()
        Me.rbMaxSizeValueUserSetting = New System.Windows.Forms.RadioButton()
        Me.rbMaxSizeValueDataMax = New System.Windows.Forms.RadioButton()
        Me.gbFrame = New System.Windows.Forms.GroupBox()
        Me.picLineBarBackGroundTile = New System.Windows.Forms.PictureBox()
        Me.picLineBarBorderLine = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSetSameHatch = New System.Windows.Forms.Button()
        Me.gbTateYokoHi = New System.Windows.Forms.GroupBox()
        Me.txtLineBarAspectRatio = New mandara10.TextNumberBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbStackedBarView = New System.Windows.Forms.GroupBox()
        Me.txtStackedBarAspectRatio = New mandara10.TextNumberBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rbStackedBarHorizontal = New System.Windows.Forms.RadioButton()
        Me.rbStackedBarVeritical = New System.Windows.Forms.RadioButton()
        Me.gbLinePattern = New System.Windows.Forms.GroupBox()
        Me.picLinePattern = New System.Windows.Forms.PictureBox()
        Me.gbMaxSize = New System.Windows.Forms.GroupBox()
        Me.txtMaxSize = New mandara10.TextNumberBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbMaxSizeNonFixed = New System.Windows.Forms.RadioButton()
        Me.rbMaxSizeFixed = New System.Windows.Forms.RadioButton()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.gbGraphMode.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbDataItems.SuspendLayout()
        Me.pnlDataItemBase.SuspendLayout()
        Me.gbGraphSettings.SuspendLayout()
        Me.gbMaxMinValue.SuspendLayout()
        Me.pnlMaxMinValue.SuspendLayout()
        Me.gbLegendValue.SuspendLayout()
        Me.gbBarLineSize.SuspendLayout()
        Me.gbMaxSizeValue.SuspendLayout()
        Me.gbFrame.SuspendLayout()
        CType(Me.picLineBarBackGroundTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLineBarBorderLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTateYokoHi.SuspendLayout()
        Me.gbStackedBarView.SuspendLayout()
        Me.gbLinePattern.SuspendLayout()
        CType(Me.picLinePattern, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMaxSize.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbGraphMode
        '
        Me.gbGraphMode.Controls.Add(Me.rbBarChart)
        Me.gbGraphMode.Controls.Add(Me.rbLineChart)
        Me.gbGraphMode.Controls.Add(Me.rbStackedBarChart)
        Me.gbGraphMode.Controls.Add(Me.rbPieChart)
        Me.gbGraphMode.Location = New System.Drawing.Point(13, 20)
        Me.gbGraphMode.Margin = New System.Windows.Forms.Padding(2)
        Me.gbGraphMode.Name = "gbGraphMode"
        Me.gbGraphMode.Padding = New System.Windows.Forms.Padding(2)
        Me.gbGraphMode.Size = New System.Drawing.Size(125, 104)
        Me.gbGraphMode.TabIndex = 0
        Me.gbGraphMode.TabStop = False
        Me.gbGraphMode.Text = "グラフの形式"
        '
        'rbBarChart
        '
        Me.rbBarChart.AutoSize = True
        Me.rbBarChart.Location = New System.Drawing.Point(27, 81)
        Me.rbBarChart.Margin = New System.Windows.Forms.Padding(2)
        Me.rbBarChart.Name = "rbBarChart"
        Me.rbBarChart.Size = New System.Drawing.Size(60, 16)
        Me.rbBarChart.TabIndex = 3
        Me.rbBarChart.Text = "棒グラフ"
        Me.rbBarChart.UseVisualStyleBackColor = True
        '
        'rbLineChart
        '
        Me.rbLineChart.AutoSize = True
        Me.rbLineChart.Location = New System.Drawing.Point(27, 61)
        Me.rbLineChart.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLineChart.Name = "rbLineChart"
        Me.rbLineChart.Size = New System.Drawing.Size(83, 16)
        Me.rbLineChart.TabIndex = 2
        Me.rbLineChart.Text = "折れ線グラフ"
        Me.rbLineChart.UseVisualStyleBackColor = True
        '
        'rbStackedBarChart
        '
        Me.rbStackedBarChart.AutoSize = True
        Me.rbStackedBarChart.Location = New System.Drawing.Point(27, 41)
        Me.rbStackedBarChart.Margin = New System.Windows.Forms.Padding(2)
        Me.rbStackedBarChart.Name = "rbStackedBarChart"
        Me.rbStackedBarChart.Size = New System.Drawing.Size(60, 16)
        Me.rbStackedBarChart.TabIndex = 1
        Me.rbStackedBarChart.Text = "帯グラフ"
        Me.rbStackedBarChart.UseVisualStyleBackColor = True
        '
        'rbPieChart
        '
        Me.rbPieChart.AutoSize = True
        Me.rbPieChart.Checked = True
        Me.rbPieChart.Location = New System.Drawing.Point(27, 21)
        Me.rbPieChart.Margin = New System.Windows.Forms.Padding(2)
        Me.rbPieChart.Name = "rbPieChart"
        Me.rbPieChart.Size = New System.Drawing.Size(60, 16)
        Me.rbPieChart.TabIndex = 0
        Me.rbPieChart.TabStop = True
        Me.rbPieChart.Text = "円グラフ"
        Me.rbPieChart.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboGraphDataSet)
        Me.GroupBox2.Controls.Add(Me.btnDeleteDataSet)
        Me.GroupBox2.Controls.Add(Me.lblDataSetTitle)
        Me.GroupBox2.Controls.Add(Me.txtDataSetTitle)
        Me.GroupBox2.Controls.Add(Me.btnAddDataSet)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 18)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(499, 96)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "グラフデータセット"
        '
        'cboGraphDataSet
        '
        Me.cboGraphDataSet.AsteriskSelectEnabled = False
        Me.cboGraphDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGraphDataSet.FormattingEnabled = True
        Me.cboGraphDataSet.IntegralHeight = False
        Me.cboGraphDataSet.Location = New System.Drawing.Point(27, 35)
        Me.cboGraphDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.cboGraphDataSet.Name = "cboGraphDataSet"
        Me.cboGraphDataSet.Size = New System.Drawing.Size(220, 20)
        Me.cboGraphDataSet.TabIndex = 0
        '
        'btnDeleteDataSet
        '
        Me.btnDeleteDataSet.Location = New System.Drawing.Point(376, 35)
        Me.btnDeleteDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteDataSet.Name = "btnDeleteDataSet"
        Me.btnDeleteDataSet.Size = New System.Drawing.Size(115, 22)
        Me.btnDeleteDataSet.TabIndex = 2
        Me.btnDeleteDataSet.Text = "データセット削除"
        Me.btnDeleteDataSet.UseVisualStyleBackColor = True
        '
        'lblDataSetTitle
        '
        Me.lblDataSetTitle.AutoSize = True
        Me.lblDataSetTitle.Location = New System.Drawing.Point(24, 76)
        Me.lblDataSetTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDataSetTitle.Name = "lblDataSetTitle"
        Me.lblDataSetTitle.Size = New System.Drawing.Size(40, 12)
        Me.lblDataSetTitle.TabIndex = 4
        Me.lblDataSetTitle.Text = "タイトル"
        '
        'txtDataSetTitle
        '
        Me.txtDataSetTitle.Location = New System.Drawing.Point(76, 73)
        Me.txtDataSetTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDataSetTitle.Name = "txtDataSetTitle"
        Me.txtDataSetTitle.Size = New System.Drawing.Size(247, 19)
        Me.txtDataSetTitle.TabIndex = 3
        '
        'btnAddDataSet
        '
        Me.btnAddDataSet.Location = New System.Drawing.Point(252, 35)
        Me.btnAddDataSet.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddDataSet.Name = "btnAddDataSet"
        Me.btnAddDataSet.Size = New System.Drawing.Size(119, 22)
        Me.btnAddDataSet.TabIndex = 1
        Me.btnAddDataSet.Text = "データセット追加"
        Me.btnAddDataSet.UseVisualStyleBackColor = True
        '
        'btnAllClear
        '
        Me.btnAllClear.Location = New System.Drawing.Point(189, 257)
        Me.btnAllClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAllClear.Name = "btnAllClear"
        Me.btnAllClear.Size = New System.Drawing.Size(77, 22)
        Me.btnAllClear.TabIndex = 5
        Me.btnAllClear.Text = "すべて削除"
        Me.btnAllClear.UseVisualStyleBackColor = True
        '
        'btnObjDownward
        '
        Me.btnObjDownward.Image = CType(resources.GetObject("btnObjDownward.Image"), System.Drawing.Image)
        Me.btnObjDownward.Location = New System.Drawing.Point(51, 227)
        Me.btnObjDownward.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjDownward.Name = "btnObjDownward"
        Me.btnObjDownward.Size = New System.Drawing.Size(35, 30)
        Me.btnObjDownward.TabIndex = 1
        Me.btnObjDownward.UseVisualStyleBackColor = True
        '
        'btnObjUpward
        '
        Me.btnObjUpward.Image = CType(resources.GetObject("btnObjUpward.Image"), System.Drawing.Image)
        Me.btnObjUpward.Location = New System.Drawing.Point(12, 227)
        Me.btnObjUpward.Margin = New System.Windows.Forms.Padding(2)
        Me.btnObjUpward.Name = "btnObjUpward"
        Me.btnObjUpward.Size = New System.Drawing.Size(35, 30)
        Me.btnObjUpward.TabIndex = 0
        Me.btnObjUpward.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(93, 232)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 22)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'gbDataItems
        '
        Me.gbDataItems.Controls.Add(Me.btnDelete)
        Me.gbDataItems.Controls.Add(Me.btnObjDownward)
        Me.gbDataItems.Controls.Add(Me.pnlDataItemBase)
        Me.gbDataItems.Controls.Add(Me.btnObjUpward)
        Me.gbDataItems.Controls.Add(Me.btnAddRange)
        Me.gbDataItems.Controls.Add(Me.btnAllClear)
        Me.gbDataItems.Controls.Add(Me.btnAdd)
        Me.gbDataItems.Location = New System.Drawing.Point(10, 123)
        Me.gbDataItems.Margin = New System.Windows.Forms.Padding(2)
        Me.gbDataItems.Name = "gbDataItems"
        Me.gbDataItems.Padding = New System.Windows.Forms.Padding(2)
        Me.gbDataItems.Size = New System.Drawing.Size(271, 289)
        Me.gbDataItems.TabIndex = 1
        Me.gbDataItems.TabStop = False
        Me.gbDataItems.Text = "表示データ項目"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(189, 232)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(77, 22)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'pnlDataItemBase
        '
        Me.pnlDataItemBase.AutoScroll = True
        Me.pnlDataItemBase.BackColor = System.Drawing.Color.White
        Me.pnlDataItemBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDataItemBase.Controls.Add(Me.pnlDataItem)
        Me.pnlDataItemBase.Location = New System.Drawing.Point(7, 22)
        Me.pnlDataItemBase.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlDataItemBase.Name = "pnlDataItemBase"
        Me.pnlDataItemBase.Size = New System.Drawing.Size(258, 201)
        Me.pnlDataItemBase.TabIndex = 6
        '
        'pnlDataItem
        '
        Me.pnlDataItem.BackColor = System.Drawing.Color.White
        Me.pnlDataItem.Location = New System.Drawing.Point(2, 8)
        Me.pnlDataItem.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlDataItem.Name = "pnlDataItem"
        Me.pnlDataItem.Size = New System.Drawing.Size(212, 133)
        Me.pnlDataItem.TabIndex = 0
        '
        'btnAddRange
        '
        Me.btnAddRange.Location = New System.Drawing.Point(93, 257)
        Me.btnAddRange.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddRange.Name = "btnAddRange"
        Me.btnAddRange.Size = New System.Drawing.Size(85, 22)
        Me.btnAddRange.TabIndex = 3
        Me.btnAddRange.Text = "まとめて追加"
        Me.btnAddRange.UseVisualStyleBackColor = True
        '
        'gbGraphSettings
        '
        Me.gbGraphSettings.Controls.Add(Me.gbMaxMinValue)
        Me.gbGraphSettings.Controls.Add(Me.gbLegendValue)
        Me.gbGraphSettings.Controls.Add(Me.gbBarLineSize)
        Me.gbGraphSettings.Controls.Add(Me.gbMaxSizeValue)
        Me.gbGraphSettings.Controls.Add(Me.gbGraphMode)
        Me.gbGraphSettings.Controls.Add(Me.gbFrame)
        Me.gbGraphSettings.Controls.Add(Me.btnSetSameHatch)
        Me.gbGraphSettings.Controls.Add(Me.gbTateYokoHi)
        Me.gbGraphSettings.Controls.Add(Me.gbStackedBarView)
        Me.gbGraphSettings.Controls.Add(Me.gbLinePattern)
        Me.gbGraphSettings.Controls.Add(Me.gbMaxSize)
        Me.gbGraphSettings.Location = New System.Drawing.Point(287, 123)
        Me.gbGraphSettings.Margin = New System.Windows.Forms.Padding(2)
        Me.gbGraphSettings.Name = "gbGraphSettings"
        Me.gbGraphSettings.Padding = New System.Windows.Forms.Padding(2)
        Me.gbGraphSettings.Size = New System.Drawing.Size(593, 289)
        Me.gbGraphSettings.TabIndex = 2
        Me.gbGraphSettings.TabStop = False
        Me.gbGraphSettings.Text = "グラフ設定"
        '
        'gbMaxMinValue
        '
        Me.gbMaxMinValue.Controls.Add(Me.pnlMaxMinValue)
        Me.gbMaxMinValue.Controls.Add(Me.Label9)
        Me.gbMaxMinValue.Controls.Add(Me.Label8)
        Me.gbMaxMinValue.Controls.Add(Me.rbManual)
        Me.gbMaxMinValue.Controls.Add(Me.rbAuto)
        Me.gbMaxMinValue.Location = New System.Drawing.Point(300, 194)
        Me.gbMaxMinValue.Margin = New System.Windows.Forms.Padding(2)
        Me.gbMaxMinValue.Name = "gbMaxMinValue"
        Me.gbMaxMinValue.Padding = New System.Windows.Forms.Padding(2)
        Me.gbMaxMinValue.Size = New System.Drawing.Size(282, 68)
        Me.gbMaxMinValue.TabIndex = 9
        Me.gbMaxMinValue.TabStop = False
        Me.gbMaxMinValue.Text = "最大・最小値"
        '
        'pnlMaxMinValue
        '
        Me.pnlMaxMinValue.Controls.Add(Me.txtMinValue)
        Me.pnlMaxMinValue.Controls.Add(Me.txtMaxValue)
        Me.pnlMaxMinValue.Location = New System.Drawing.Point(174, 16)
        Me.pnlMaxMinValue.Name = "pnlMaxMinValue"
        Me.pnlMaxMinValue.Size = New System.Drawing.Size(100, 47)
        Me.pnlMaxMinValue.TabIndex = 55
        '
        'txtMinValue
        '
        Me.txtMinValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMinValue.Location = New System.Drawing.Point(0, 26)
        Me.txtMinValue.MaxValue = 0.0R
        Me.txtMinValue.MaxValueFlag = False
        Me.txtMinValue.MinValue = 0.0R
        Me.txtMinValue.MinValueFlag = False
        Me.txtMinValue.Name = "txtMinValue"
        Me.txtMinValue.NumberPoint = True
        Me.txtMinValue.Size = New System.Drawing.Size(93, 19)
        Me.txtMinValue.TabIndex = 4
        Me.txtMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMinValue.ValueErrorMessageFlag = True
        '
        'txtMaxValue
        '
        Me.txtMaxValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMaxValue.Location = New System.Drawing.Point(0, 1)
        Me.txtMaxValue.MaxValue = 0.0R
        Me.txtMaxValue.MaxValueFlag = False
        Me.txtMaxValue.MinValue = 0.0R
        Me.txtMaxValue.MinValueFlag = False
        Me.txtMaxValue.Name = "txtMaxValue"
        Me.txtMaxValue.NumberPoint = True
        Me.txtMaxValue.Size = New System.Drawing.Size(93, 19)
        Me.txtMaxValue.TabIndex = 3
        Me.txtMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaxValue.ValueErrorMessageFlag = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(120, 45)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "最小値"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(120, 21)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "最大値"
        '
        'rbManual
        '
        Me.rbManual.AutoSize = True
        Me.rbManual.Location = New System.Drawing.Point(15, 41)
        Me.rbManual.Margin = New System.Windows.Forms.Padding(2)
        Me.rbManual.Name = "rbManual"
        Me.rbManual.Size = New System.Drawing.Size(77, 16)
        Me.rbManual.TabIndex = 1
        Me.rbManual.TabStop = True
        Me.rbManual.Text = "ユーザ設定"
        Me.rbManual.UseVisualStyleBackColor = True
        '
        'rbAuto
        '
        Me.rbAuto.AutoSize = True
        Me.rbAuto.Location = New System.Drawing.Point(15, 19)
        Me.rbAuto.Margin = New System.Windows.Forms.Padding(2)
        Me.rbAuto.Name = "rbAuto"
        Me.rbAuto.Size = New System.Drawing.Size(47, 16)
        Me.rbAuto.TabIndex = 0
        Me.rbAuto.TabStop = True
        Me.rbAuto.Text = "自動"
        Me.rbAuto.UseVisualStyleBackColor = True
        '
        'gbLegendValue
        '
        Me.gbLegendValue.Controls.Add(Me.txtLegendValue3)
        Me.gbLegendValue.Controls.Add(Me.txtLegendValue2)
        Me.gbLegendValue.Controls.Add(Me.txtLegendValue1)
        Me.gbLegendValue.Location = New System.Drawing.Point(143, 178)
        Me.gbLegendValue.Margin = New System.Windows.Forms.Padding(2)
        Me.gbLegendValue.Name = "gbLegendValue"
        Me.gbLegendValue.Padding = New System.Windows.Forms.Padding(2)
        Me.gbLegendValue.Size = New System.Drawing.Size(152, 91)
        Me.gbLegendValue.TabIndex = 5
        Me.gbLegendValue.TabStop = False
        Me.gbLegendValue.Text = "凡例値"
        '
        'txtLegendValue3
        '
        Me.txtLegendValue3.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLegendValue3.Location = New System.Drawing.Point(29, 66)
        Me.txtLegendValue3.MaxValue = 0.0R
        Me.txtLegendValue3.MaxValueFlag = False
        Me.txtLegendValue3.MinValue = 0.0R
        Me.txtLegendValue3.MinValueFlag = True
        Me.txtLegendValue3.Name = "txtLegendValue3"
        Me.txtLegendValue3.NumberPoint = True
        Me.txtLegendValue3.Size = New System.Drawing.Size(108, 19)
        Me.txtLegendValue3.TabIndex = 2
        Me.txtLegendValue3.Tag = "3"
        Me.txtLegendValue3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLegendValue3.ValueErrorMessageFlag = True
        '
        'txtLegendValue2
        '
        Me.txtLegendValue2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLegendValue2.Location = New System.Drawing.Point(29, 39)
        Me.txtLegendValue2.MaxValue = 0.0R
        Me.txtLegendValue2.MaxValueFlag = False
        Me.txtLegendValue2.MinValue = 0.0R
        Me.txtLegendValue2.MinValueFlag = True
        Me.txtLegendValue2.Name = "txtLegendValue2"
        Me.txtLegendValue2.NumberPoint = True
        Me.txtLegendValue2.Size = New System.Drawing.Size(108, 19)
        Me.txtLegendValue2.TabIndex = 1
        Me.txtLegendValue2.Tag = "2"
        Me.txtLegendValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLegendValue2.ValueErrorMessageFlag = True
        '
        'txtLegendValue1
        '
        Me.txtLegendValue1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLegendValue1.Location = New System.Drawing.Point(29, 14)
        Me.txtLegendValue1.MaxValue = 0.0R
        Me.txtLegendValue1.MaxValueFlag = False
        Me.txtLegendValue1.MinValue = 0.0R
        Me.txtLegendValue1.MinValueFlag = True
        Me.txtLegendValue1.Name = "txtLegendValue1"
        Me.txtLegendValue1.NumberPoint = True
        Me.txtLegendValue1.Size = New System.Drawing.Size(108, 19)
        Me.txtLegendValue1.TabIndex = 0
        Me.txtLegendValue1.Tag = "1"
        Me.txtLegendValue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLegendValue1.ValueErrorMessageFlag = True
        '
        'gbBarLineSize
        '
        Me.gbBarLineSize.Controls.Add(Me.txtBarLineSize)
        Me.gbBarLineSize.Controls.Add(Me.Label4)
        Me.gbBarLineSize.Location = New System.Drawing.Point(300, 20)
        Me.gbBarLineSize.Margin = New System.Windows.Forms.Padding(2)
        Me.gbBarLineSize.Name = "gbBarLineSize"
        Me.gbBarLineSize.Padding = New System.Windows.Forms.Padding(2)
        Me.gbBarLineSize.Size = New System.Drawing.Size(152, 52)
        Me.gbBarLineSize.TabIndex = 6
        Me.gbBarLineSize.TabStop = False
        Me.gbBarLineSize.Text = "サイズ"
        '
        'txtBarLineSize
        '
        Me.txtBarLineSize.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBarLineSize.Location = New System.Drawing.Point(42, 21)
        Me.txtBarLineSize.MaxValue = 0.0R
        Me.txtBarLineSize.MaxValueFlag = False
        Me.txtBarLineSize.MinValue = 0.0R
        Me.txtBarLineSize.MinValueFlag = True
        Me.txtBarLineSize.Name = "txtBarLineSize"
        Me.txtBarLineSize.NumberPoint = True
        Me.txtBarLineSize.Size = New System.Drawing.Size(48, 19)
        Me.txtBarLineSize.TabIndex = 52
        Me.txtBarLineSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBarLineSize.ValueErrorMessageFlag = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(96, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 12)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "%"
        '
        'gbMaxSizeValue
        '
        Me.gbMaxSizeValue.Controls.Add(Me.txtMaxSizeValue)
        Me.gbMaxSizeValue.Controls.Add(Me.rbMaxSizeValueUserSetting)
        Me.gbMaxSizeValue.Controls.Add(Me.rbMaxSizeValueDataMax)
        Me.gbMaxSizeValue.Location = New System.Drawing.Point(143, 85)
        Me.gbMaxSizeValue.Margin = New System.Windows.Forms.Padding(2)
        Me.gbMaxSizeValue.Name = "gbMaxSizeValue"
        Me.gbMaxSizeValue.Padding = New System.Windows.Forms.Padding(2)
        Me.gbMaxSizeValue.Size = New System.Drawing.Size(152, 86)
        Me.gbMaxSizeValue.TabIndex = 4
        Me.gbMaxSizeValue.TabStop = False
        Me.gbMaxSizeValue.Text = "最大サイズの値"
        '
        'txtMaxSizeValue
        '
        Me.txtMaxSizeValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMaxSizeValue.Location = New System.Drawing.Point(44, 59)
        Me.txtMaxSizeValue.MaxValue = 0.0R
        Me.txtMaxSizeValue.MaxValueFlag = False
        Me.txtMaxSizeValue.MinValue = 0.0R
        Me.txtMaxSizeValue.MinValueFlag = True
        Me.txtMaxSizeValue.Name = "txtMaxSizeValue"
        Me.txtMaxSizeValue.NumberPoint = True
        Me.txtMaxSizeValue.Size = New System.Drawing.Size(93, 19)
        Me.txtMaxSizeValue.TabIndex = 2
        Me.txtMaxSizeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaxSizeValue.ValueErrorMessageFlag = True
        '
        'rbMaxSizeValueUserSetting
        '
        Me.rbMaxSizeValueUserSetting.AutoSize = True
        Me.rbMaxSizeValueUserSetting.Location = New System.Drawing.Point(16, 41)
        Me.rbMaxSizeValueUserSetting.Margin = New System.Windows.Forms.Padding(2)
        Me.rbMaxSizeValueUserSetting.Name = "rbMaxSizeValueUserSetting"
        Me.rbMaxSizeValueUserSetting.Size = New System.Drawing.Size(77, 16)
        Me.rbMaxSizeValueUserSetting.TabIndex = 1
        Me.rbMaxSizeValueUserSetting.TabStop = True
        Me.rbMaxSizeValueUserSetting.Text = "ユーザ設定"
        Me.rbMaxSizeValueUserSetting.UseVisualStyleBackColor = True
        '
        'rbMaxSizeValueDataMax
        '
        Me.rbMaxSizeValueDataMax.AutoSize = True
        Me.rbMaxSizeValueDataMax.Location = New System.Drawing.Point(16, 21)
        Me.rbMaxSizeValueDataMax.Margin = New System.Windows.Forms.Padding(2)
        Me.rbMaxSizeValueDataMax.Name = "rbMaxSizeValueDataMax"
        Me.rbMaxSizeValueDataMax.Size = New System.Drawing.Size(121, 16)
        Me.rbMaxSizeValueDataMax.TabIndex = 0
        Me.rbMaxSizeValueDataMax.TabStop = True
        Me.rbMaxSizeValueDataMax.Text = "選択データの最大値"
        Me.rbMaxSizeValueDataMax.UseVisualStyleBackColor = True
        '
        'gbFrame
        '
        Me.gbFrame.Controls.Add(Me.picLineBarBackGroundTile)
        Me.gbFrame.Controls.Add(Me.picLineBarBorderLine)
        Me.gbFrame.Controls.Add(Me.Label3)
        Me.gbFrame.Controls.Add(Me.Label2)
        Me.gbFrame.Location = New System.Drawing.Point(300, 124)
        Me.gbFrame.Margin = New System.Windows.Forms.Padding(2)
        Me.gbFrame.Name = "gbFrame"
        Me.gbFrame.Padding = New System.Windows.Forms.Padding(2)
        Me.gbFrame.Size = New System.Drawing.Size(152, 67)
        Me.gbFrame.TabIndex = 8
        Me.gbFrame.TabStop = False
        Me.gbFrame.Text = "枠"
        '
        'picLineBarBackGroundTile
        '
        Me.picLineBarBackGroundTile.BackColor = System.Drawing.Color.White
        Me.picLineBarBackGroundTile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLineBarBackGroundTile.Location = New System.Drawing.Point(72, 41)
        Me.picLineBarBackGroundTile.Margin = New System.Windows.Forms.Padding(2)
        Me.picLineBarBackGroundTile.Name = "picLineBarBackGroundTile"
        Me.picLineBarBackGroundTile.Size = New System.Drawing.Size(63, 22)
        Me.picLineBarBackGroundTile.TabIndex = 54
        Me.picLineBarBackGroundTile.TabStop = False
        '
        'picLineBarBorderLine
        '
        Me.picLineBarBorderLine.BackColor = System.Drawing.Color.White
        Me.picLineBarBorderLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLineBarBorderLine.Location = New System.Drawing.Point(72, 13)
        Me.picLineBarBorderLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picLineBarBorderLine.Name = "picLineBarBorderLine"
        Me.picLineBarBorderLine.Size = New System.Drawing.Size(63, 22)
        Me.picLineBarBorderLine.TabIndex = 53
        Me.picLineBarBorderLine.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 41)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "内部色"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 13)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "枠線"
        '
        'btnSetSameHatch
        '
        Me.btnSetSameHatch.Location = New System.Drawing.Point(15, 262)
        Me.btnSetSameHatch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSetSameHatch.Name = "btnSetSameHatch"
        Me.btnSetSameHatch.Size = New System.Drawing.Size(121, 27)
        Me.btnSetSameHatch.TabIndex = 3
        Me.btnSetSameHatch.Text = "同一ハッチに設定"
        Me.btnSetSameHatch.UseVisualStyleBackColor = True
        '
        'gbTateYokoHi
        '
        Me.gbTateYokoHi.Controls.Add(Me.txtLineBarAspectRatio)
        Me.gbTateYokoHi.Controls.Add(Me.Label6)
        Me.gbTateYokoHi.Location = New System.Drawing.Point(300, 74)
        Me.gbTateYokoHi.Margin = New System.Windows.Forms.Padding(2)
        Me.gbTateYokoHi.Name = "gbTateYokoHi"
        Me.gbTateYokoHi.Padding = New System.Windows.Forms.Padding(2)
        Me.gbTateYokoHi.Size = New System.Drawing.Size(152, 44)
        Me.gbTateYokoHi.TabIndex = 7
        Me.gbTateYokoHi.TabStop = False
        '
        'txtLineBarAspectRatio
        '
        Me.txtLineBarAspectRatio.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLineBarAspectRatio.Location = New System.Drawing.Point(86, 18)
        Me.txtLineBarAspectRatio.MaxValue = 0.0R
        Me.txtLineBarAspectRatio.MaxValueFlag = False
        Me.txtLineBarAspectRatio.MinValue = 0.0R
        Me.txtLineBarAspectRatio.MinValueFlag = True
        Me.txtLineBarAspectRatio.Name = "txtLineBarAspectRatio"
        Me.txtLineBarAspectRatio.NumberPoint = True
        Me.txtLineBarAspectRatio.Size = New System.Drawing.Size(51, 19)
        Me.txtLineBarAspectRatio.TabIndex = 0
        Me.txtLineBarAspectRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLineBarAspectRatio.ValueErrorMessageFlag = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 20)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 12)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "縦：横＝１："
        '
        'gbStackedBarView
        '
        Me.gbStackedBarView.Controls.Add(Me.txtStackedBarAspectRatio)
        Me.gbStackedBarView.Controls.Add(Me.Label5)
        Me.gbStackedBarView.Controls.Add(Me.Label7)
        Me.gbStackedBarView.Controls.Add(Me.rbStackedBarHorizontal)
        Me.gbStackedBarView.Controls.Add(Me.rbStackedBarVeritical)
        Me.gbStackedBarView.Location = New System.Drawing.Point(13, 178)
        Me.gbStackedBarView.Margin = New System.Windows.Forms.Padding(2)
        Me.gbStackedBarView.Name = "gbStackedBarView"
        Me.gbStackedBarView.Padding = New System.Windows.Forms.Padding(2)
        Me.gbStackedBarView.Size = New System.Drawing.Size(125, 79)
        Me.gbStackedBarView.TabIndex = 2
        Me.gbStackedBarView.TabStop = False
        Me.gbStackedBarView.Text = "帯グラフ表示"
        '
        'txtStackedBarAspectRatio
        '
        Me.txtStackedBarAspectRatio.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtStackedBarAspectRatio.Location = New System.Drawing.Point(54, 53)
        Me.txtStackedBarAspectRatio.MaxValue = 0.0R
        Me.txtStackedBarAspectRatio.MaxValueFlag = False
        Me.txtStackedBarAspectRatio.MinValue = 0.0R
        Me.txtStackedBarAspectRatio.MinValueFlag = True
        Me.txtStackedBarAspectRatio.Name = "txtStackedBarAspectRatio"
        Me.txtStackedBarAspectRatio.NumberPoint = True
        Me.txtStackedBarAspectRatio.Size = New System.Drawing.Size(51, 19)
        Me.txtStackedBarAspectRatio.TabIndex = 2
        Me.txtStackedBarAspectRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtStackedBarAspectRatio.ValueErrorMessageFlag = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 55)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 12)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "＝１："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 38)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "長辺：短辺"
        '
        'rbStackedBarHorizontal
        '
        Me.rbStackedBarHorizontal.AutoSize = True
        Me.rbStackedBarHorizontal.Location = New System.Drawing.Point(65, 16)
        Me.rbStackedBarHorizontal.Margin = New System.Windows.Forms.Padding(2)
        Me.rbStackedBarHorizontal.Name = "rbStackedBarHorizontal"
        Me.rbStackedBarHorizontal.Size = New System.Drawing.Size(35, 16)
        Me.rbStackedBarHorizontal.TabIndex = 1
        Me.rbStackedBarHorizontal.TabStop = True
        Me.rbStackedBarHorizontal.Text = "横"
        Me.rbStackedBarHorizontal.UseVisualStyleBackColor = True
        '
        'rbStackedBarVeritical
        '
        Me.rbStackedBarVeritical.AutoSize = True
        Me.rbStackedBarVeritical.Location = New System.Drawing.Point(16, 15)
        Me.rbStackedBarVeritical.Margin = New System.Windows.Forms.Padding(2)
        Me.rbStackedBarVeritical.Name = "rbStackedBarVeritical"
        Me.rbStackedBarVeritical.Size = New System.Drawing.Size(35, 16)
        Me.rbStackedBarVeritical.TabIndex = 0
        Me.rbStackedBarVeritical.TabStop = True
        Me.rbStackedBarVeritical.Text = "縦"
        Me.rbStackedBarVeritical.UseVisualStyleBackColor = True
        '
        'gbLinePattern
        '
        Me.gbLinePattern.Controls.Add(Me.picLinePattern)
        Me.gbLinePattern.Location = New System.Drawing.Point(15, 129)
        Me.gbLinePattern.Margin = New System.Windows.Forms.Padding(2)
        Me.gbLinePattern.Name = "gbLinePattern"
        Me.gbLinePattern.Padding = New System.Windows.Forms.Padding(2)
        Me.gbLinePattern.Size = New System.Drawing.Size(124, 42)
        Me.gbLinePattern.TabIndex = 1
        Me.gbLinePattern.TabStop = False
        Me.gbLinePattern.Text = "線種"
        '
        'picLinePattern
        '
        Me.picLinePattern.BackColor = System.Drawing.Color.White
        Me.picLinePattern.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLinePattern.Location = New System.Drawing.Point(30, 14)
        Me.picLinePattern.Margin = New System.Windows.Forms.Padding(2)
        Me.picLinePattern.Name = "picLinePattern"
        Me.picLinePattern.Size = New System.Drawing.Size(63, 22)
        Me.picLinePattern.TabIndex = 35
        Me.picLinePattern.TabStop = False
        '
        'gbMaxSize
        '
        Me.gbMaxSize.Controls.Add(Me.txtMaxSize)
        Me.gbMaxSize.Controls.Add(Me.Label1)
        Me.gbMaxSize.Controls.Add(Me.rbMaxSizeNonFixed)
        Me.gbMaxSize.Controls.Add(Me.rbMaxSizeFixed)
        Me.gbMaxSize.Location = New System.Drawing.Point(143, 20)
        Me.gbMaxSize.Margin = New System.Windows.Forms.Padding(2)
        Me.gbMaxSize.Name = "gbMaxSize"
        Me.gbMaxSize.Padding = New System.Windows.Forms.Padding(2)
        Me.gbMaxSize.Size = New System.Drawing.Size(152, 60)
        Me.gbMaxSize.TabIndex = 3
        Me.gbMaxSize.TabStop = False
        Me.gbMaxSize.Text = "最大サイズ"
        '
        'txtMaxSize
        '
        Me.txtMaxSize.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMaxSize.Location = New System.Drawing.Point(79, 38)
        Me.txtMaxSize.MaxValue = 0.0R
        Me.txtMaxSize.MaxValueFlag = False
        Me.txtMaxSize.MinValue = 0.0R
        Me.txtMaxSize.MinValueFlag = True
        Me.txtMaxSize.Name = "txtMaxSize"
        Me.txtMaxSize.NumberPoint = True
        Me.txtMaxSize.Size = New System.Drawing.Size(48, 19)
        Me.txtMaxSize.TabIndex = 51
        Me.txtMaxSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaxSize.ValueErrorMessageFlag = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(133, 40)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 12)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "%"
        '
        'rbMaxSizeNonFixed
        '
        Me.rbMaxSizeNonFixed.AutoSize = True
        Me.rbMaxSizeNonFixed.Location = New System.Drawing.Point(16, 40)
        Me.rbMaxSizeNonFixed.Margin = New System.Windows.Forms.Padding(2)
        Me.rbMaxSizeNonFixed.Name = "rbMaxSizeNonFixed"
        Me.rbMaxSizeNonFixed.Size = New System.Drawing.Size(47, 16)
        Me.rbMaxSizeNonFixed.TabIndex = 1
        Me.rbMaxSizeNonFixed.TabStop = True
        Me.rbMaxSizeNonFixed.Text = "可変"
        Me.rbMaxSizeNonFixed.UseVisualStyleBackColor = True
        '
        'rbMaxSizeFixed
        '
        Me.rbMaxSizeFixed.AutoSize = True
        Me.rbMaxSizeFixed.Location = New System.Drawing.Point(16, 20)
        Me.rbMaxSizeFixed.Margin = New System.Windows.Forms.Padding(2)
        Me.rbMaxSizeFixed.Name = "rbMaxSizeFixed"
        Me.rbMaxSizeFixed.Size = New System.Drawing.Size(47, 16)
        Me.rbMaxSizeFixed.TabIndex = 0
        Me.rbMaxSizeFixed.TabStop = True
        Me.rbMaxSizeFixed.Text = "固定"
        Me.rbMaxSizeFixed.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(547, 2)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(35, 21)
        Me.btnHelp.TabIndex = 3
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmMain_GraphModeSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(969, 436)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.gbGraphSettings)
        Me.Controls.Add(Me.gbDataItems)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmMain_GraphModeSettings"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "グラフ表示モード"
        Me.gbGraphMode.ResumeLayout(False)
        Me.gbGraphMode.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbDataItems.ResumeLayout(False)
        Me.pnlDataItemBase.ResumeLayout(False)
        Me.gbGraphSettings.ResumeLayout(False)
        Me.gbMaxMinValue.ResumeLayout(False)
        Me.gbMaxMinValue.PerformLayout()
        Me.pnlMaxMinValue.ResumeLayout(False)
        Me.pnlMaxMinValue.PerformLayout()
        Me.gbLegendValue.ResumeLayout(False)
        Me.gbLegendValue.PerformLayout()
        Me.gbBarLineSize.ResumeLayout(False)
        Me.gbBarLineSize.PerformLayout()
        Me.gbMaxSizeValue.ResumeLayout(False)
        Me.gbMaxSizeValue.PerformLayout()
        Me.gbFrame.ResumeLayout(False)
        Me.gbFrame.PerformLayout()
        CType(Me.picLineBarBackGroundTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLineBarBorderLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTateYokoHi.ResumeLayout(False)
        Me.gbTateYokoHi.PerformLayout()
        Me.gbStackedBarView.ResumeLayout(False)
        Me.gbStackedBarView.PerformLayout()
        Me.gbLinePattern.ResumeLayout(False)
        CType(Me.picLinePattern, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMaxSize.ResumeLayout(False)
        Me.gbMaxSize.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbGraphMode As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbStackedBarChart As System.Windows.Forms.RadioButton
    Friend WithEvents rbPieChart As System.Windows.Forms.RadioButton
    Friend WithEvents btnDeleteDataSet As System.Windows.Forms.Button
    Friend WithEvents lblDataSetTitle As System.Windows.Forms.Label
    Friend WithEvents txtDataSetTitle As System.Windows.Forms.TextBox
    Friend WithEvents btnAddDataSet As System.Windows.Forms.Button
    Friend WithEvents rbBarChart As System.Windows.Forms.RadioButton
    Friend WithEvents rbLineChart As System.Windows.Forms.RadioButton
    Friend WithEvents btnAllClear As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents gbDataItems As System.Windows.Forms.GroupBox
    Friend WithEvents btnObjDownward As System.Windows.Forms.Button
    Friend WithEvents btnObjUpward As System.Windows.Forms.Button
    Friend WithEvents btnAddRange As System.Windows.Forms.Button
    Friend WithEvents cboGraphDataSet As mandara10.ComboBoxEx
    Friend WithEvents pnlDataItemBase As System.Windows.Forms.Panel
    Friend WithEvents pnlDataItem As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents gbGraphSettings As System.Windows.Forms.GroupBox
    Friend WithEvents gbMaxSize As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbMaxSizeNonFixed As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxSizeFixed As System.Windows.Forms.RadioButton
    Friend WithEvents gbLinePattern As System.Windows.Forms.GroupBox
    Friend WithEvents gbStackedBarView As System.Windows.Forms.GroupBox
    Friend WithEvents rbStackedBarHorizontal As System.Windows.Forms.RadioButton
    Friend WithEvents rbStackedBarVeritical As System.Windows.Forms.RadioButton
    Friend WithEvents btnSetSameHatch As System.Windows.Forms.Button
    Friend WithEvents gbBarLineSize As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbFrame As System.Windows.Forms.GroupBox
    Friend WithEvents picLineBarBackGroundTile As System.Windows.Forms.PictureBox
    Friend WithEvents picLineBarBorderLine As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picLinePattern As System.Windows.Forms.PictureBox
    Friend WithEvents gbLegendValue As System.Windows.Forms.GroupBox
    Friend WithEvents gbMaxSizeValue As System.Windows.Forms.GroupBox
    Friend WithEvents rbMaxSizeValueUserSetting As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxSizeValueDataMax As System.Windows.Forms.RadioButton
    Friend WithEvents gbTateYokoHi As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLegendValue3 As mandara10.TextNumberBox
    Friend WithEvents txtLegendValue2 As mandara10.TextNumberBox
    Friend WithEvents txtLegendValue1 As mandara10.TextNumberBox
    Friend WithEvents txtBarLineSize As mandara10.TextNumberBox
    Friend WithEvents txtMaxSizeValue As mandara10.TextNumberBox
    Friend WithEvents txtLineBarAspectRatio As mandara10.TextNumberBox
    Friend WithEvents txtStackedBarAspectRatio As mandara10.TextNumberBox
    Friend WithEvents txtMaxSize As mandara10.TextNumberBox
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents gbMaxMinValue As System.Windows.Forms.GroupBox
    Friend WithEvents pnlMaxMinValue As System.Windows.Forms.Panel
    Friend WithEvents txtMinValue As mandara10.TextNumberBox
    Friend WithEvents txtMaxValue As mandara10.TextNumberBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rbManual As System.Windows.Forms.RadioButton
    Friend WithEvents rbAuto As System.Windows.Forms.RadioButton
End Class
