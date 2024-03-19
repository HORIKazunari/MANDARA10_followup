<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_Option
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint_Option))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tabAll = New System.Windows.Forms.TabControl()
        Me.tabGeneral = New System.Windows.Forms.TabPage()
        Me.GroupBox21 = New System.Windows.Forms.GroupBox()
        Me.cboMinimumLineWidth = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.picSymbolLine = New System.Windows.Forms.PictureBox()
        Me.chkSymbolLine = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkSoubyouAuto = New System.Windows.Forms.CheckBox()
        Me.btnThiningPoint = New System.Windows.Forms.Button()
        Me.chkObjSpline = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbPointPaintOrder_fromTopCategory = New System.Windows.Forms.RadioButton()
        Me.rbPointPaintOrder_fromBottomCategory = New System.Windows.Forms.RadioButton()
        Me.rbPointPaintOrder_byObjectOrder = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbAccBaseOnScreen = New System.Windows.Forms.RadioButton()
        Me.rbAccBaseOnMap = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.picAccGroupBoxBack = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.clbAccGroupBoxItem = New System.Windows.Forms.CheckedListBox()
        Me.chkAccGroupBox = New System.Windows.Forms.CheckBox()
        Me.gbAccVisible = New System.Windows.Forms.GroupBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.btnNoteFont = New System.Windows.Forms.Button()
        Me.chkNoteVisible = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnCompassSetting = New System.Windows.Forms.Button()
        Me.btnTitleFont = New System.Windows.Forms.Button()
        Me.chkFigureVisible = New System.Windows.Forms.CheckBox()
        Me.chkCompassVisible = New System.Windows.Forms.CheckBox()
        Me.chkTitleVisible = New System.Windows.Forms.CheckBox()
        Me.chkMapShow = New System.Windows.Forms.CheckBox()
        Me.tabBackGround = New System.Windows.Forms.TabPage()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cboMaxAutoDrawTime = New System.Windows.Forms.ComboBox()
        Me.btnTIleLicenceFont = New System.Windows.Forms.Button()
        Me.gbLatLonLine = New System.Windows.Forms.GroupBox()
        Me.GroupBox25 = New System.Windows.Forms.GroupBox()
        Me.picLatLonEqLine = New System.Windows.Forms.PictureBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.picLatLonOuterLine = New System.Windows.Forms.PictureBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.picLatLonLine = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.btnLatLonLineInterval = New System.Windows.Forms.Button()
        Me.lblLonLineInterval = New System.Windows.Forms.Label()
        Me.lblLatLineInterval = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.rbLatLonLineFront = New System.Windows.Forms.RadioButton()
        Me.rbLatLonLineBack = New System.Windows.Forms.RadioButton()
        Me.chkLatLonPrint = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.chkMarginClip = New System.Windows.Forms.CheckBox()
        Me.picObjectInnerTile = New System.Windows.Forms.PictureBox()
        Me.picScreenFrameLine = New System.Windows.Forms.PictureBox()
        Me.picMapAreaTile = New System.Windows.Forms.PictureBox()
        Me.picScreenAreaTile = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.picMapFrameLine = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabLegend = New System.Windows.Forms.TabPage()
        Me.chkLegendComma = New System.Windows.Forms.CheckBox()
        Me.tbLegend = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.chkModeValueInScreenFlag = New System.Windows.Forms.CheckBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.chkOverlayTitleVisible = New System.Windows.Forms.CheckBox()
        Me.picLegendBack = New System.Windows.Forms.PictureBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnLegendFontSetting = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chkFreq = New System.Windows.Forms.CheckBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboSeparateGapSize = New System.Windows.Forms.ComboBox()
        Me.rbSeparateClassWords_English = New System.Windows.Forms.RadioButton()
        Me.rbSeparateClassWords_Japanese = New System.Windows.Forms.RadioButton()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.picClassBoundary = New System.Windows.Forms.PictureBox()
        Me.chkClassBoundary = New System.Windows.Forms.CheckBox()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.picPaintFrame = New System.Windows.Forms.PictureBox()
        Me.cboClassPaintWidth = New System.Windows.Forms.ComboBox()
        Me.chkClassMarkFrame = New System.Windows.Forms.CheckBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.cbCategorySeparated = New System.Windows.Forms.CheckBox()
        Me.rbPaintLegend_Separated = New System.Windows.Forms.RadioButton()
        Me.rbPaintLegend_Normal = New System.Windows.Forms.RadioButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.picMultiEnLine = New System.Windows.Forms.PictureBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.正の値 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.chkMark_Circle_Mini = New System.Windows.Forms.CheckBox()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.rbOneCircle = New System.Windows.Forms.RadioButton()
        Me.rbMuliFan = New System.Windows.Forms.RadioButton()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.chkPointDummy = New System.Windows.Forms.CheckBox()
        Me.picLineKindLegendBack = New System.Windows.Forms.PictureBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.chkLineKindLegend = New System.Windows.Forms.CheckBox()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.rbLineKindStraight = New System.Windows.Forms.RadioButton()
        Me.rbLineKindZigzag = New System.Windows.Forms.RadioButton()
        Me.chkLegendVisible = New System.Windows.Forms.CheckBox()
        Me.tabMissingValue = New System.Windows.Forms.TabPage()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.picMarkBarMissingValue = New System.Windows.Forms.PictureBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.picLineShapeMissingValue = New System.Windows.Forms.PictureBox()
        Me.picMarkTurnMissingValue = New System.Windows.Forms.PictureBox()
        Me.picMarkBlockMissingValue = New System.Windows.Forms.PictureBox()
        Me.picMarkSizeMissingValue = New System.Windows.Forms.PictureBox()
        Me.picClassMarkMissingValue = New System.Windows.Forms.PictureBox()
        Me.picClassHatchMissingValue = New System.Windows.Forms.PictureBox()
        Me.picClassPaintMissingValue = New System.Windows.Forms.PictureBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.chkMissingPrintFlag = New System.Windows.Forms.CheckBox()
        Me.tabScale = New System.Windows.Forms.TabPage()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.rbScaleBar3 = New System.Windows.Forms.RadioButton()
        Me.rbScalebar2 = New System.Windows.Forms.RadioButton()
        Me.rbScalebar1 = New System.Windows.Forms.RadioButton()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.chkScaleBarAuto = New System.Windows.Forms.CheckBox()
        Me.picScaleBack = New System.Windows.Forms.PictureBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.btScaleFont = New System.Windows.Forms.Button()
        Me.chkScaleShow = New System.Windows.Forms.CheckBox()
        Me.tabTrip = New System.Windows.Forms.TabPage()
        Me.GroupBox23 = New System.Windows.Forms.GroupBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.btnTripZLegendFont = New System.Windows.Forms.Button()
        Me.GroupBox24 = New System.Windows.Forms.GroupBox()
        Me.rbTripZLegendLowerRight = New System.Windows.Forms.RadioButton()
        Me.rbTripZLegendLowerLeft = New System.Windows.Forms.RadioButton()
        Me.rbTripZLegendUpperRight = New System.Windows.Forms.RadioButton()
        Me.rbTripZLegendUpperLeft = New System.Windows.Forms.RadioButton()
        Me.rbTripZLegendNo = New System.Windows.Forms.RadioButton()
        Me.picTripFrameLine = New System.Windows.Forms.PictureBox()
        Me.picTripZeroLine = New System.Windows.Forms.PictureBox()
        Me.picTripVerticalLine = New System.Windows.Forms.PictureBox()
        Me.picTripZeroPointMark = New System.Windows.Forms.PictureBox()
        Me.chkTripOverLap = New System.Windows.Forms.CheckBox()
        Me.chkTripVerticalLine = New System.Windows.Forms.CheckBox()
        Me.chkTripZeroLine = New System.Windows.Forms.CheckBox()
        Me.chkTripZeroPoint = New System.Windows.Forms.CheckBox()
        Me.chkTripFrame = New System.Windows.Forms.CheckBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.GroupBox22 = New System.Windows.Forms.GroupBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.picEndPointMark = New System.Windows.Forms.PictureBox()
        Me.picStartPointMark = New System.Windows.Forms.PictureBox()
        Me.chkTripStart_End_Print = New System.Windows.Forms.CheckBox()
        Me.picTripStayLine = New System.Windows.Forms.PictureBox()
        Me.picTripMoveLine = New System.Windows.Forms.PictureBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.cboSoubyouAutoDegree = New System.Windows.Forms.ComboBox()
        Me.txtNoteMaxWidth = New mandara10.TextNumberBox()
        Me.txtTitleMaxWidth = New mandara10.TextNumberBox()
        Me.txtLeftMargin = New mandara10.TextNumberBox()
        Me.txtBottomMargin = New mandara10.TextNumberBox()
        Me.txtRightMargin = New mandara10.TextNumberBox()
        Me.txtUpperMargin = New mandara10.TextNumberBox()
        Me.txtOverlayTitleWidth = New mandara10.TextNumberBox()
        Me.txtBlockLegendWord = New mandara10.TextBoxFocusAllSelect()
        Me.txtPlusValue = New mandara10.TextBoxFocusAllSelect()
        Me.txtMinusValue = New mandara10.TextBoxFocusAllSelect()
        Me.clbLineKindLegendShow = New mandara10.CheckedListBoxEx()
        Me.txtLabelModeMissingValue = New mandara10.TextBoxFocusAllSelect()
        Me.txtMissingWord = New mandara10.TextBoxFocusAllSelect()
        Me.txtScaleBarKugiri = New mandara10.TextNumberBox()
        Me.txtScaleBarDistance = New mandara10.TextNumberBox()
        Me.cboScaleUnit = New mandara10.ComboBoxEx()
        Me.txtTripPathHeight = New mandara10.TextNumberBox()
        Me.tabAll.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.GroupBox21.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.picSymbolLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.picAccGroupBoxBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAccVisible.SuspendLayout()
        Me.tabBackGround.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.gbLatLonLine.SuspendLayout()
        Me.GroupBox25.SuspendLayout()
        CType(Me.picLatLonEqLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLatLonOuterLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLatLonLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.picObjectInnerTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picScreenFrameLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMapAreaTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picScreenAreaTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMapFrameLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.tabLegend.SuspendLayout()
        Me.tbLegend.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.picLegendBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        CType(Me.picClassBoundary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox14.SuspendLayout()
        CType(Me.picPaintFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.picMultiEnLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox16.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.picLineKindLegendBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox17.SuspendLayout()
        Me.tabMissingValue.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        CType(Me.picMarkBarMissingValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLineShapeMissingValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMarkTurnMissingValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMarkBlockMissingValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMarkSizeMissingValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClassMarkMissingValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClassHatchMissingValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClassPaintMissingValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabScale.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        CType(Me.picScaleBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTrip.SuspendLayout()
        Me.GroupBox23.SuspendLayout()
        Me.GroupBox24.SuspendLayout()
        CType(Me.picTripFrameLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTripZeroLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTripVerticalLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTripZeroPointMark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox22.SuspendLayout()
        CType(Me.picEndPointMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStartPointMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTripStayLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTripMoveLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(435, 351)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(514, 351)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tabAll
        '
        Me.tabAll.Controls.Add(Me.tabGeneral)
        Me.tabAll.Controls.Add(Me.tabBackGround)
        Me.tabAll.Controls.Add(Me.tabLegend)
        Me.tabAll.Controls.Add(Me.tabMissingValue)
        Me.tabAll.Controls.Add(Me.tabScale)
        Me.tabAll.Controls.Add(Me.tabTrip)
        Me.tabAll.ItemSize = New System.Drawing.Size(128, 21)
        Me.tabAll.Location = New System.Drawing.Point(12, 15)
        Me.tabAll.Name = "tabAll"
        Me.tabAll.SelectedIndex = 0
        Me.tabAll.Size = New System.Drawing.Size(583, 333)
        Me.tabAll.TabIndex = 2
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.GroupBox21)
        Me.tabGeneral.Controls.Add(Me.GroupBox3)
        Me.tabGeneral.Controls.Add(Me.GroupBox4)
        Me.tabGeneral.Controls.Add(Me.GroupBox2)
        Me.tabGeneral.Controls.Add(Me.GroupBox1)
        Me.tabGeneral.Controls.Add(Me.GroupBox5)
        Me.tabGeneral.Controls.Add(Me.gbAccVisible)
        Me.tabGeneral.Location = New System.Drawing.Point(4, 25)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGeneral.Size = New System.Drawing.Size(575, 304)
        Me.tabGeneral.TabIndex = 0
        Me.tabGeneral.Text = "全般"
        Me.tabGeneral.UseVisualStyleBackColor = True
        '
        'GroupBox21
        '
        Me.GroupBox21.Controls.Add(Me.cboMinimumLineWidth)
        Me.GroupBox21.Location = New System.Drawing.Point(432, 205)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(129, 62)
        Me.GroupBox21.TabIndex = 6
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "幅が「最小」のライン幅"
        '
        'cboMinimumLineWidth
        '
        Me.cboMinimumLineWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMinimumLineWidth.FormattingEnabled = True
        Me.cboMinimumLineWidth.Location = New System.Drawing.Point(38, 30)
        Me.cboMinimumLineWidth.MaxDropDownItems = 15
        Me.cboMinimumLineWidth.Name = "cboMinimumLineWidth"
        Me.cboMinimumLineWidth.Size = New System.Drawing.Size(62, 20)
        Me.cboMinimumLineWidth.TabIndex = 20
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.picSymbolLine)
        Me.GroupBox3.Controls.Add(Me.chkSymbolLine)
        Me.GroupBox3.Location = New System.Drawing.Point(227, 235)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(189, 53)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "記号表示位置とオブジェクト代表点"
        '
        'picSymbolLine
        '
        Me.picSymbolLine.BackColor = System.Drawing.Color.White
        Me.picSymbolLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSymbolLine.Location = New System.Drawing.Point(110, 17)
        Me.picSymbolLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picSymbolLine.Name = "picSymbolLine"
        Me.picSymbolLine.Size = New System.Drawing.Size(62, 30)
        Me.picSymbolLine.TabIndex = 21
        Me.picSymbolLine.TabStop = False
        '
        'chkSymbolLine
        '
        Me.chkSymbolLine.AutoSize = True
        Me.chkSymbolLine.Location = New System.Drawing.Point(18, 17)
        Me.chkSymbolLine.Name = "chkSymbolLine"
        Me.chkSymbolLine.Size = New System.Drawing.Size(68, 16)
        Me.chkSymbolLine.TabIndex = 0
        Me.chkSymbolLine.Text = "線で結ぶ"
        Me.chkSymbolLine.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboSoubyouAutoDegree)
        Me.GroupBox4.Controls.Add(Me.chkSoubyouAuto)
        Me.GroupBox4.Controls.Add(Me.btnThiningPoint)
        Me.GroupBox4.Controls.Add(Me.chkObjSpline)
        Me.GroupBox4.Location = New System.Drawing.Point(18, 232)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(196, 67)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "総描"
        '
        'chkSoubyouAuto
        '
        Me.chkSoubyouAuto.AutoSize = True
        Me.chkSoubyouAuto.Location = New System.Drawing.Point(11, 16)
        Me.chkSoubyouAuto.Name = "chkSoubyouAuto"
        Me.chkSoubyouAuto.Size = New System.Drawing.Size(48, 16)
        Me.chkSoubyouAuto.TabIndex = 12
        Me.chkSoubyouAuto.Text = "自動"
        Me.chkSoubyouAuto.UseVisualStyleBackColor = True
        '
        'btnThiningPoint
        '
        Me.btnThiningPoint.Location = New System.Drawing.Point(20, 36)
        Me.btnThiningPoint.Name = "btnThiningPoint"
        Me.btnThiningPoint.Size = New System.Drawing.Size(158, 24)
        Me.btnThiningPoint.TabIndex = 11
        Me.btnThiningPoint.Text = "ポイント・ループ間引き設定"
        Me.btnThiningPoint.UseVisualStyleBackColor = True
        '
        'chkObjSpline
        '
        Me.chkObjSpline.AutoSize = True
        Me.chkObjSpline.Location = New System.Drawing.Point(118, 16)
        Me.chkObjSpline.Name = "chkObjSpline"
        Me.chkObjSpline.Size = New System.Drawing.Size(72, 16)
        Me.chkObjSpline.TabIndex = 10
        Me.chkObjSpline.Text = "曲線近似"
        Me.chkObjSpline.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbPointPaintOrder_fromTopCategory)
        Me.GroupBox2.Controls.Add(Me.rbPointPaintOrder_fromBottomCategory)
        Me.GroupBox2.Controls.Add(Me.rbPointPaintOrder_byObjectOrder)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 112)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(196, 114)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "点線オブジェクト・階級記号・線モードの描画順"
        '
        'rbPointPaintOrder_fromTopCategory
        '
        Me.rbPointPaintOrder_fromTopCategory.AutoSize = True
        Me.rbPointPaintOrder_fromTopCategory.Location = New System.Drawing.Point(20, 80)
        Me.rbPointPaintOrder_fromTopCategory.Name = "rbPointPaintOrder_fromTopCategory"
        Me.rbPointPaintOrder_fromTopCategory.Size = New System.Drawing.Size(119, 16)
        Me.rbPointPaintOrder_fromTopCategory.TabIndex = 2
        Me.rbPointPaintOrder_fromTopCategory.TabStop = True
        Me.rbPointPaintOrder_fromTopCategory.Text = "カテゴリーの上位から"
        Me.rbPointPaintOrder_fromTopCategory.UseVisualStyleBackColor = True
        '
        'rbPointPaintOrder_fromBottomCategory
        '
        Me.rbPointPaintOrder_fromBottomCategory.AutoSize = True
        Me.rbPointPaintOrder_fromBottomCategory.Location = New System.Drawing.Point(20, 58)
        Me.rbPointPaintOrder_fromBottomCategory.Name = "rbPointPaintOrder_fromBottomCategory"
        Me.rbPointPaintOrder_fromBottomCategory.Size = New System.Drawing.Size(119, 16)
        Me.rbPointPaintOrder_fromBottomCategory.TabIndex = 1
        Me.rbPointPaintOrder_fromBottomCategory.TabStop = True
        Me.rbPointPaintOrder_fromBottomCategory.Text = "カテゴリーの下位から"
        Me.rbPointPaintOrder_fromBottomCategory.UseVisualStyleBackColor = True
        '
        'rbPointPaintOrder_byObjectOrder
        '
        Me.rbPointPaintOrder_byObjectOrder.AutoSize = True
        Me.rbPointPaintOrder_byObjectOrder.Location = New System.Drawing.Point(20, 36)
        Me.rbPointPaintOrder_byObjectOrder.Name = "rbPointPaintOrder_byObjectOrder"
        Me.rbPointPaintOrder_byObjectOrder.Size = New System.Drawing.Size(118, 16)
        Me.rbPointPaintOrder_byObjectOrder.TabIndex = 0
        Me.rbPointPaintOrder_byObjectOrder.TabStop = True
        Me.rbPointPaintOrder_byObjectOrder.Text = "オブジェクトの並び順"
        Me.rbPointPaintOrder_byObjectOrder.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbAccBaseOnScreen)
        Me.GroupBox1.Controls.Add(Me.rbAccBaseOnMap)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 74)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "タイトル等の位置・記号のサイズ"
        '
        'rbAccBaseOnScreen
        '
        Me.rbAccBaseOnScreen.AutoSize = True
        Me.rbAccBaseOnScreen.Location = New System.Drawing.Point(20, 48)
        Me.rbAccBaseOnScreen.Name = "rbAccBaseOnScreen"
        Me.rbAccBaseOnScreen.Size = New System.Drawing.Size(113, 16)
        Me.rbAccBaseOnScreen.TabIndex = 4
        Me.rbAccBaseOnScreen.TabStop = True
        Me.rbAccBaseOnScreen.Text = "ウインドウ上に固定"
        Me.rbAccBaseOnScreen.UseVisualStyleBackColor = True
        '
        'rbAccBaseOnMap
        '
        Me.rbAccBaseOnMap.AutoSize = True
        Me.rbAccBaseOnMap.Location = New System.Drawing.Point(20, 26)
        Me.rbAccBaseOnMap.Name = "rbAccBaseOnMap"
        Me.rbAccBaseOnMap.Size = New System.Drawing.Size(92, 16)
        Me.rbAccBaseOnMap.TabIndex = 3
        Me.rbAccBaseOnMap.TabStop = True
        Me.rbAccBaseOnMap.Text = "地図上に固定"
        Me.rbAccBaseOnMap.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.picAccGroupBoxBack)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.clbAccGroupBoxItem)
        Me.GroupBox5.Controls.Add(Me.chkAccGroupBox)
        Me.GroupBox5.Location = New System.Drawing.Point(432, 20)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(128, 178)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "飾りグループボックス"
        '
        'picAccGroupBoxBack
        '
        Me.picAccGroupBoxBack.BackColor = System.Drawing.Color.White
        Me.picAccGroupBoxBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picAccGroupBoxBack.Location = New System.Drawing.Point(57, 128)
        Me.picAccGroupBoxBack.Margin = New System.Windows.Forms.Padding(2)
        Me.picAccGroupBoxBack.Name = "picAccGroupBoxBack"
        Me.picAccGroupBoxBack.Size = New System.Drawing.Size(66, 43)
        Me.picAccGroupBoxBack.TabIndex = 20
        Me.picAccGroupBoxBack.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "設定項目"
        '
        'clbAccGroupBoxItem
        '
        Me.clbAccGroupBoxItem.CheckOnClick = True
        Me.clbAccGroupBoxItem.FormattingEnabled = True
        Me.clbAccGroupBoxItem.Location = New System.Drawing.Point(27, 52)
        Me.clbAccGroupBoxItem.Name = "clbAccGroupBoxItem"
        Me.clbAccGroupBoxItem.Size = New System.Drawing.Size(96, 74)
        Me.clbAccGroupBoxItem.TabIndex = 11
        '
        'chkAccGroupBox
        '
        Me.chkAccGroupBox.AutoSize = True
        Me.chkAccGroupBox.Location = New System.Drawing.Point(6, 18)
        Me.chkAccGroupBox.Name = "chkAccGroupBox"
        Me.chkAccGroupBox.Size = New System.Drawing.Size(67, 16)
        Me.chkAccGroupBox.TabIndex = 10
        Me.chkAccGroupBox.Text = "設定する"
        Me.chkAccGroupBox.UseVisualStyleBackColor = True
        '
        'gbAccVisible
        '
        Me.gbAccVisible.Controls.Add(Me.txtNoteMaxWidth)
        Me.gbAccVisible.Controls.Add(Me.Label46)
        Me.gbAccVisible.Controls.Add(Me.Label47)
        Me.gbAccVisible.Controls.Add(Me.btnNoteFont)
        Me.gbAccVisible.Controls.Add(Me.chkNoteVisible)
        Me.gbAccVisible.Controls.Add(Me.txtTitleMaxWidth)
        Me.gbAccVisible.Controls.Add(Me.Label18)
        Me.gbAccVisible.Controls.Add(Me.Label22)
        Me.gbAccVisible.Controls.Add(Me.btnCompassSetting)
        Me.gbAccVisible.Controls.Add(Me.btnTitleFont)
        Me.gbAccVisible.Controls.Add(Me.chkFigureVisible)
        Me.gbAccVisible.Controls.Add(Me.chkCompassVisible)
        Me.gbAccVisible.Controls.Add(Me.chkTitleVisible)
        Me.gbAccVisible.Controls.Add(Me.chkMapShow)
        Me.gbAccVisible.Location = New System.Drawing.Point(227, 20)
        Me.gbAccVisible.Name = "gbAccVisible"
        Me.gbAccVisible.Size = New System.Drawing.Size(189, 206)
        Me.gbAccVisible.TabIndex = 3
        Me.gbAccVisible.TabStop = False
        Me.gbAccVisible.Text = "飾り"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(160, 160)
        Me.Label46.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(17, 12)
        Me.Label46.TabIndex = 30
        Me.Label46.Text = "％"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(66, 157)
        Me.Label47.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(41, 12)
        Me.Label47.TabIndex = 10
        Me.Label47.Text = "最大幅"
        '
        'btnNoteFont
        '
        Me.btnNoteFont.Location = New System.Drawing.Point(110, 128)
        Me.btnNoteFont.Name = "btnNoteFont"
        Me.btnNoteFont.Size = New System.Drawing.Size(73, 20)
        Me.btnNoteFont.TabIndex = 9
        Me.btnNoteFont.Text = "フォント設定"
        Me.btnNoteFont.UseVisualStyleBackColor = True
        '
        'chkNoteVisible
        '
        Me.chkNoteVisible.AutoSize = True
        Me.chkNoteVisible.Location = New System.Drawing.Point(18, 133)
        Me.chkNoteVisible.Name = "chkNoteVisible"
        Me.chkNoteVisible.Size = New System.Drawing.Size(60, 16)
        Me.chkNoteVisible.TabIndex = 8
        Me.chkNoteVisible.Text = "注表示"
        Me.chkNoteVisible.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(160, 72)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(17, 12)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "％"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(66, 69)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(41, 12)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "最大幅"
        '
        'btnCompassSetting
        '
        Me.btnCompassSetting.Location = New System.Drawing.Point(110, 98)
        Me.btnCompassSetting.Name = "btnCompassSetting"
        Me.btnCompassSetting.Size = New System.Drawing.Size(73, 20)
        Me.btnCompassSetting.TabIndex = 7
        Me.btnCompassSetting.Text = "方位設定"
        Me.btnCompassSetting.UseVisualStyleBackColor = True
        '
        'btnTitleFont
        '
        Me.btnTitleFont.Location = New System.Drawing.Point(110, 40)
        Me.btnTitleFont.Name = "btnTitleFont"
        Me.btnTitleFont.Size = New System.Drawing.Size(73, 20)
        Me.btnTitleFont.TabIndex = 2
        Me.btnTitleFont.Text = "フォント設定"
        Me.btnTitleFont.UseVisualStyleBackColor = True
        '
        'chkFigureVisible
        '
        Me.chkFigureVisible.AutoSize = True
        Me.chkFigureVisible.Location = New System.Drawing.Point(18, 184)
        Me.chkFigureVisible.Name = "chkFigureVisible"
        Me.chkFigureVisible.Size = New System.Drawing.Size(72, 16)
        Me.chkFigureVisible.TabIndex = 11
        Me.chkFigureVisible.Text = "図形表示"
        Me.chkFigureVisible.UseVisualStyleBackColor = True
        '
        'chkCompassVisible
        '
        Me.chkCompassVisible.AutoSize = True
        Me.chkCompassVisible.Location = New System.Drawing.Point(18, 102)
        Me.chkCompassVisible.Name = "chkCompassVisible"
        Me.chkCompassVisible.Size = New System.Drawing.Size(72, 16)
        Me.chkCompassVisible.TabIndex = 6
        Me.chkCompassVisible.Text = "方位表示"
        Me.chkCompassVisible.UseVisualStyleBackColor = True
        '
        'chkTitleVisible
        '
        Me.chkTitleVisible.AutoSize = True
        Me.chkTitleVisible.Location = New System.Drawing.Point(18, 45)
        Me.chkTitleVisible.Name = "chkTitleVisible"
        Me.chkTitleVisible.Size = New System.Drawing.Size(83, 16)
        Me.chkTitleVisible.TabIndex = 1
        Me.chkTitleVisible.Text = "タイトル表示"
        Me.chkTitleVisible.UseVisualStyleBackColor = True
        '
        'chkMapShow
        '
        Me.chkMapShow.AutoSize = True
        Me.chkMapShow.Location = New System.Drawing.Point(18, 18)
        Me.chkMapShow.Name = "chkMapShow"
        Me.chkMapShow.Size = New System.Drawing.Size(72, 16)
        Me.chkMapShow.TabIndex = 0
        Me.chkMapShow.Text = "地図表示"
        Me.chkMapShow.UseVisualStyleBackColor = True
        '
        'tabBackGround
        '
        Me.tabBackGround.Controls.Add(Me.GroupBox13)
        Me.tabBackGround.Controls.Add(Me.btnTIleLicenceFont)
        Me.tabBackGround.Controls.Add(Me.gbLatLonLine)
        Me.tabBackGround.Controls.Add(Me.GroupBox7)
        Me.tabBackGround.Controls.Add(Me.GroupBox6)
        Me.tabBackGround.Location = New System.Drawing.Point(4, 25)
        Me.tabBackGround.Name = "tabBackGround"
        Me.tabBackGround.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBackGround.Size = New System.Drawing.Size(575, 304)
        Me.tabBackGround.TabIndex = 1
        Me.tabBackGround.Text = "背景・描画"
        Me.tabBackGround.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.Label45)
        Me.GroupBox13.Controls.Add(Me.cboMaxAutoDrawTime)
        Me.GroupBox13.Location = New System.Drawing.Point(325, 250)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(235, 48)
        Me.GroupBox13.TabIndex = 4
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "自動再描画する最大描画時間"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(132, 27)
        Me.Label45.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(17, 12)
        Me.Label45.TabIndex = 21
        Me.Label45.Text = "秒"
        '
        'cboMaxAutoDrawTime
        '
        Me.cboMaxAutoDrawTime.FormattingEnabled = True
        Me.cboMaxAutoDrawTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cboMaxAutoDrawTime.Location = New System.Drawing.Point(79, 20)
        Me.cboMaxAutoDrawTime.MaxDropDownItems = 15
        Me.cboMaxAutoDrawTime.Name = "cboMaxAutoDrawTime"
        Me.cboMaxAutoDrawTime.Size = New System.Drawing.Size(49, 20)
        Me.cboMaxAutoDrawTime.TabIndex = 20
        '
        'btnTIleLicenceFont
        '
        Me.btnTIleLicenceFont.Location = New System.Drawing.Point(19, 268)
        Me.btnTIleLicenceFont.Name = "btnTIleLicenceFont"
        Me.btnTIleLicenceFont.Size = New System.Drawing.Size(144, 24)
        Me.btnTIleLicenceFont.TabIndex = 2
        Me.btnTIleLicenceFont.Text = "背景画像ライセンスフォント"
        Me.btnTIleLicenceFont.UseVisualStyleBackColor = True
        '
        'gbLatLonLine
        '
        Me.gbLatLonLine.Controls.Add(Me.GroupBox25)
        Me.gbLatLonLine.Controls.Add(Me.GroupBox9)
        Me.gbLatLonLine.Controls.Add(Me.GroupBox8)
        Me.gbLatLonLine.Controls.Add(Me.chkLatLonPrint)
        Me.gbLatLonLine.Location = New System.Drawing.Point(325, 17)
        Me.gbLatLonLine.Margin = New System.Windows.Forms.Padding(2)
        Me.gbLatLonLine.Name = "gbLatLonLine"
        Me.gbLatLonLine.Padding = New System.Windows.Forms.Padding(2)
        Me.gbLatLonLine.Size = New System.Drawing.Size(236, 226)
        Me.gbLatLonLine.TabIndex = 3
        Me.gbLatLonLine.TabStop = False
        Me.gbLatLonLine.Text = "経緯線"
        '
        'GroupBox25
        '
        Me.GroupBox25.Controls.Add(Me.picLatLonEqLine)
        Me.GroupBox25.Controls.Add(Me.Label58)
        Me.GroupBox25.Controls.Add(Me.picLatLonOuterLine)
        Me.GroupBox25.Controls.Add(Me.Label57)
        Me.GroupBox25.Controls.Add(Me.picLatLonLine)
        Me.GroupBox25.Controls.Add(Me.Label15)
        Me.GroupBox25.Location = New System.Drawing.Point(108, 22)
        Me.GroupBox25.Name = "GroupBox25"
        Me.GroupBox25.Size = New System.Drawing.Size(111, 105)
        Me.GroupBox25.TabIndex = 27
        Me.GroupBox25.TabStop = False
        Me.GroupBox25.Text = "ラインパターン"
        '
        'picLatLonEqLine
        '
        Me.picLatLonEqLine.BackColor = System.Drawing.Color.White
        Me.picLatLonEqLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLatLonEqLine.Location = New System.Drawing.Point(56, 46)
        Me.picLatLonEqLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picLatLonEqLine.Name = "picLatLonEqLine"
        Me.picLatLonEqLine.Size = New System.Drawing.Size(50, 18)
        Me.picLatLonEqLine.TabIndex = 27
        Me.picLatLonEqLine.TabStop = False
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(5, 50)
        Me.Label58.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(29, 12)
        Me.Label58.TabIndex = 28
        Me.Label58.Text = "赤道"
        '
        'picLatLonOuterLine
        '
        Me.picLatLonOuterLine.BackColor = System.Drawing.Color.White
        Me.picLatLonOuterLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLatLonOuterLine.Location = New System.Drawing.Point(56, 17)
        Me.picLatLonOuterLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picLatLonOuterLine.Name = "picLatLonOuterLine"
        Me.picLatLonOuterLine.Size = New System.Drawing.Size(50, 18)
        Me.picLatLonOuterLine.TabIndex = 25
        Me.picLatLonOuterLine.TabStop = False
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(5, 19)
        Me.Label57.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(29, 12)
        Me.Label57.TabIndex = 26
        Me.Label57.Text = "外周"
        '
        'picLatLonLine
        '
        Me.picLatLonLine.BackColor = System.Drawing.Color.White
        Me.picLatLonLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLatLonLine.Location = New System.Drawing.Point(56, 77)
        Me.picLatLonLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picLatLonLine.Name = "picLatLonLine"
        Me.picLatLonLine.Size = New System.Drawing.Size(50, 18)
        Me.picLatLonLine.TabIndex = 23
        Me.picLatLonLine.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 79)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 12)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "その他"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.btnLatLonLineInterval)
        Me.GroupBox9.Controls.Add(Me.lblLonLineInterval)
        Me.GroupBox9.Controls.Add(Me.lblLatLineInterval)
        Me.GroupBox9.Controls.Add(Me.Label17)
        Me.GroupBox9.Controls.Add(Me.Label16)
        Me.GroupBox9.Location = New System.Drawing.Point(18, 132)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox9.Size = New System.Drawing.Size(202, 87)
        Me.GroupBox9.TabIndex = 26
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "間隔"
        '
        'btnLatLonLineInterval
        '
        Me.btnLatLonLineInterval.Location = New System.Drawing.Point(106, 57)
        Me.btnLatLonLineInterval.Name = "btnLatLonLineInterval"
        Me.btnLatLonLineInterval.Size = New System.Drawing.Size(73, 24)
        Me.btnLatLonLineInterval.TabIndex = 27
        Me.btnLatLonLineInterval.Text = "間隔設定"
        Me.btnLatLonLineInterval.UseVisualStyleBackColor = True
        '
        'lblLonLineInterval
        '
        Me.lblLonLineInterval.AutoSize = True
        Me.lblLonLineInterval.Location = New System.Drawing.Point(49, 41)
        Me.lblLonLineInterval.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLonLineInterval.Name = "lblLonLineInterval"
        Me.lblLonLineInterval.Size = New System.Drawing.Size(53, 12)
        Me.lblLonLineInterval.TabIndex = 26
        Me.lblLonLineInterval.Text = "経度間隔"
        '
        'lblLatLineInterval
        '
        Me.lblLatLineInterval.AutoSize = True
        Me.lblLatLineInterval.Location = New System.Drawing.Point(49, 22)
        Me.lblLatLineInterval.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLatLineInterval.Name = "lblLatLineInterval"
        Me.lblLatLineInterval.Size = New System.Drawing.Size(53, 12)
        Me.lblLatLineInterval.TabIndex = 25
        Me.lblLatLineInterval.Text = "緯度間隔"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(16, 41)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 12)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "経度："
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(16, 22)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 12)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "緯度："
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.rbLatLonLineFront)
        Me.GroupBox8.Controls.Add(Me.rbLatLonLineBack)
        Me.GroupBox8.Location = New System.Drawing.Point(18, 57)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox8.Size = New System.Drawing.Size(75, 71)
        Me.GroupBox8.TabIndex = 25
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "表示階層"
        '
        'rbLatLonLineFront
        '
        Me.rbLatLonLineFront.AutoSize = True
        Me.rbLatLonLineFront.Location = New System.Drawing.Point(18, 42)
        Me.rbLatLonLineFront.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLatLonLineFront.Name = "rbLatLonLineFront"
        Me.rbLatLonLineFront.Size = New System.Drawing.Size(47, 16)
        Me.rbLatLonLineFront.TabIndex = 1
        Me.rbLatLonLineFront.TabStop = True
        Me.rbLatLonLineFront.Text = "前面"
        Me.rbLatLonLineFront.UseVisualStyleBackColor = True
        '
        'rbLatLonLineBack
        '
        Me.rbLatLonLineBack.AutoSize = True
        Me.rbLatLonLineBack.Location = New System.Drawing.Point(18, 22)
        Me.rbLatLonLineBack.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLatLonLineBack.Name = "rbLatLonLineBack"
        Me.rbLatLonLineBack.Size = New System.Drawing.Size(47, 16)
        Me.rbLatLonLineBack.TabIndex = 0
        Me.rbLatLonLineBack.TabStop = True
        Me.rbLatLonLineBack.Text = "背面"
        Me.rbLatLonLineBack.UseVisualStyleBackColor = True
        '
        'chkLatLonPrint
        '
        Me.chkLatLonPrint.AutoSize = True
        Me.chkLatLonPrint.Location = New System.Drawing.Point(18, 26)
        Me.chkLatLonPrint.Margin = New System.Windows.Forms.Padding(2)
        Me.chkLatLonPrint.Name = "chkLatLonPrint"
        Me.chkLatLonPrint.Size = New System.Drawing.Size(48, 16)
        Me.chkLatLonPrint.TabIndex = 1
        Me.chkLatLonPrint.Text = "表示"
        Me.chkLatLonPrint.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.chkMarginClip)
        Me.GroupBox7.Controls.Add(Me.picObjectInnerTile)
        Me.GroupBox7.Controls.Add(Me.picScreenFrameLine)
        Me.GroupBox7.Controls.Add(Me.picMapAreaTile)
        Me.GroupBox7.Controls.Add(Me.picScreenAreaTile)
        Me.GroupBox7.Controls.Add(Me.Label14)
        Me.GroupBox7.Controls.Add(Me.Label13)
        Me.GroupBox7.Controls.Add(Me.Label12)
        Me.GroupBox7.Controls.Add(Me.picMapFrameLine)
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.Label10)
        Me.GroupBox7.Location = New System.Drawing.Point(19, 113)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox7.Size = New System.Drawing.Size(299, 141)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "枠・色"
        '
        'chkMarginClip
        '
        Me.chkMarginClip.AutoSize = True
        Me.chkMarginClip.Location = New System.Drawing.Point(15, 24)
        Me.chkMarginClip.Margin = New System.Windows.Forms.Padding(2)
        Me.chkMarginClip.Name = "chkMarginClip"
        Me.chkMarginClip.Size = New System.Drawing.Size(137, 16)
        Me.chkMarginClip.TabIndex = 0
        Me.chkMarginClip.Text = "余白で地図画像クリップ"
        Me.chkMarginClip.UseVisualStyleBackColor = True
        '
        'picObjectInnerTile
        '
        Me.picObjectInnerTile.BackColor = System.Drawing.Color.White
        Me.picObjectInnerTile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picObjectInnerTile.Location = New System.Drawing.Point(243, 85)
        Me.picObjectInnerTile.Margin = New System.Windows.Forms.Padding(2)
        Me.picObjectInnerTile.Name = "picObjectInnerTile"
        Me.picObjectInnerTile.Size = New System.Drawing.Size(50, 18)
        Me.picObjectInnerTile.TabIndex = 29
        Me.picObjectInnerTile.TabStop = False
        '
        'picScreenFrameLine
        '
        Me.picScreenFrameLine.BackColor = System.Drawing.Color.White
        Me.picScreenFrameLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picScreenFrameLine.Location = New System.Drawing.Point(90, 85)
        Me.picScreenFrameLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picScreenFrameLine.Name = "picScreenFrameLine"
        Me.picScreenFrameLine.Size = New System.Drawing.Size(50, 18)
        Me.picScreenFrameLine.TabIndex = 28
        Me.picScreenFrameLine.TabStop = False
        '
        'picMapAreaTile
        '
        Me.picMapAreaTile.BackColor = System.Drawing.Color.White
        Me.picMapAreaTile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMapAreaTile.Location = New System.Drawing.Point(243, 55)
        Me.picMapAreaTile.Margin = New System.Windows.Forms.Padding(2)
        Me.picMapAreaTile.Name = "picMapAreaTile"
        Me.picMapAreaTile.Size = New System.Drawing.Size(50, 18)
        Me.picMapAreaTile.TabIndex = 27
        Me.picMapAreaTile.TabStop = False
        '
        'picScreenAreaTile
        '
        Me.picScreenAreaTile.BackColor = System.Drawing.Color.White
        Me.picScreenAreaTile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picScreenAreaTile.Location = New System.Drawing.Point(90, 111)
        Me.picScreenAreaTile.Margin = New System.Windows.Forms.Padding(2)
        Me.picScreenAreaTile.Name = "picScreenAreaTile"
        Me.picScreenAreaTile.Size = New System.Drawing.Size(50, 19)
        Me.picScreenAreaTile.TabIndex = 26
        Me.picScreenAreaTile.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 111)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 12)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "画面領域色"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(147, 85)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 12)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "オブジェクト内部色"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(147, 55)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 12)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "地図領域背景色"
        '
        'picMapFrameLine
        '
        Me.picMapFrameLine.BackColor = System.Drawing.Color.White
        Me.picMapFrameLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMapFrameLine.Location = New System.Drawing.Point(90, 55)
        Me.picMapFrameLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picMapFrameLine.Name = "picMapFrameLine"
        Me.picMapFrameLine.Size = New System.Drawing.Size(50, 18)
        Me.picMapFrameLine.TabIndex = 22
        Me.picMapFrameLine.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 85)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "画面外枠線"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 56)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 12)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "地図領域枠線"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtLeftMargin)
        Me.GroupBox6.Controls.Add(Me.txtBottomMargin)
        Me.GroupBox6.Controls.Add(Me.txtRightMargin)
        Me.GroupBox6.Controls.Add(Me.txtUpperMargin)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Location = New System.Drawing.Point(17, 17)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox6.Size = New System.Drawing.Size(301, 91)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "ウィンドウ内余白"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(240, 60)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 12)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "％"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(116, 60)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "％"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(240, 29)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "％"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(116, 29)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "％"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(146, 57)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "左余白"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 58)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "下余白"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(146, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "右余白"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "上余白"
        '
        'tabLegend
        '
        Me.tabLegend.Controls.Add(Me.chkLegendComma)
        Me.tabLegend.Controls.Add(Me.tbLegend)
        Me.tabLegend.Controls.Add(Me.chkLegendVisible)
        Me.tabLegend.Location = New System.Drawing.Point(4, 25)
        Me.tabLegend.Name = "tabLegend"
        Me.tabLegend.Size = New System.Drawing.Size(575, 304)
        Me.tabLegend.TabIndex = 2
        Me.tabLegend.Text = "凡例設定"
        Me.tabLegend.UseVisualStyleBackColor = True
        '
        'chkLegendComma
        '
        Me.chkLegendComma.AutoSize = True
        Me.chkLegendComma.Location = New System.Drawing.Point(346, 26)
        Me.chkLegendComma.Name = "chkLegendComma"
        Me.chkLegendComma.Size = New System.Drawing.Size(147, 16)
        Me.chkLegendComma.TabIndex = 1
        Me.chkLegendComma.Text = "桁区切りカンマを表示する"
        Me.chkLegendComma.UseVisualStyleBackColor = True
        '
        'tbLegend
        '
        Me.tbLegend.Controls.Add(Me.TabPage1)
        Me.tbLegend.Controls.Add(Me.TabPage2)
        Me.tbLegend.Controls.Add(Me.TabPage3)
        Me.tbLegend.Controls.Add(Me.TabPage4)
        Me.tbLegend.ItemSize = New System.Drawing.Size(167, 21)
        Me.tbLegend.Location = New System.Drawing.Point(36, 59)
        Me.tbLegend.Name = "tbLegend"
        Me.tbLegend.SelectedIndex = 0
        Me.tbLegend.Size = New System.Drawing.Size(508, 233)
        Me.tbLegend.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label59)
        Me.TabPage1.Controls.Add(Me.chkModeValueInScreenFlag)
        Me.TabPage1.Controls.Add(Me.GroupBox10)
        Me.TabPage1.Controls.Add(Me.picLegendBack)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.btnLegendFontSetting)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(500, 204)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "凡例の背景・フォント"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label59
        '
        Me.Label59.Location = New System.Drawing.Point(49, 159)
        Me.Label59.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(193, 28)
        Me.Label59.TabIndex = 34
        Me.Label59.Text = "（階級区分値・記号の大きさなどを表示領域内のオブジェクトに合わせる）"
        '
        'chkModeValueInScreenFlag
        '
        Me.chkModeValueInScreenFlag.Location = New System.Drawing.Point(34, 127)
        Me.chkModeValueInScreenFlag.Name = "chkModeValueInScreenFlag"
        Me.chkModeValueInScreenFlag.Size = New System.Drawing.Size(208, 43)
        Me.chkModeValueInScreenFlag.TabIndex = 33
        Me.chkModeValueInScreenFlag.Text = "局地変動モード"
        Me.chkModeValueInScreenFlag.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.txtOverlayTitleWidth)
        Me.GroupBox10.Controls.Add(Me.Label20)
        Me.GroupBox10.Controls.Add(Me.Label21)
        Me.GroupBox10.Controls.Add(Me.chkOverlayTitleVisible)
        Me.GroupBox10.Location = New System.Drawing.Point(248, 36)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(183, 134)
        Me.GroupBox10.TabIndex = 2
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "重ね合わせの凡例タイトル"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(112, 80)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(17, 12)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "％"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(18, 77)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 12)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "最大幅"
        '
        'chkOverlayTitleVisible
        '
        Me.chkOverlayTitleVisible.AutoSize = True
        Me.chkOverlayTitleVisible.Location = New System.Drawing.Point(17, 35)
        Me.chkOverlayTitleVisible.Name = "chkOverlayTitleVisible"
        Me.chkOverlayTitleVisible.Size = New System.Drawing.Size(48, 16)
        Me.chkOverlayTitleVisible.TabIndex = 5
        Me.chkOverlayTitleVisible.Text = "表示"
        Me.chkOverlayTitleVisible.UseVisualStyleBackColor = True
        '
        'picLegendBack
        '
        Me.picLegendBack.BackColor = System.Drawing.Color.White
        Me.picLegendBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLegendBack.Location = New System.Drawing.Point(104, 71)
        Me.picLegendBack.Margin = New System.Windows.Forms.Padding(2)
        Me.picLegendBack.Name = "picLegendBack"
        Me.picLegendBack.Size = New System.Drawing.Size(50, 36)
        Me.picLegendBack.TabIndex = 32
        Me.picLegendBack.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(39, 82)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 12)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "凡例背景"
        '
        'btnLegendFontSetting
        '
        Me.btnLegendFontSetting.Location = New System.Drawing.Point(30, 24)
        Me.btnLegendFontSetting.Name = "btnLegendFontSetting"
        Me.btnLegendFontSetting.Size = New System.Drawing.Size(73, 24)
        Me.btnLegendFontSetting.TabIndex = 0
        Me.btnLegendFontSetting.Text = "凡例フォント設定"
        Me.btnLegendFontSetting.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.chkFreq)
        Me.TabPage2.Controls.Add(Me.GroupBox12)
        Me.TabPage2.Controls.Add(Me.GroupBox15)
        Me.TabPage2.Controls.Add(Me.GroupBox14)
        Me.TabPage2.Controls.Add(Me.GroupBox11)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(500, 204)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "階級区分"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chkFreq
        '
        Me.chkFreq.AutoSize = True
        Me.chkFreq.Location = New System.Drawing.Point(273, 160)
        Me.chkFreq.Margin = New System.Windows.Forms.Padding(2)
        Me.chkFreq.Name = "chkFreq"
        Me.chkFreq.Size = New System.Drawing.Size(82, 16)
        Me.chkFreq.TabIndex = 24
        Me.chkFreq.Text = "度数の表示"
        Me.chkFreq.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label25)
        Me.GroupBox12.Controls.Add(Me.cboSeparateGapSize)
        Me.GroupBox12.Controls.Add(Me.rbSeparateClassWords_English)
        Me.GroupBox12.Controls.Add(Me.rbSeparateClassWords_Japanese)
        Me.GroupBox12.Location = New System.Drawing.Point(145, 17)
        Me.GroupBox12.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox12.Size = New System.Drawing.Size(138, 114)
        Me.GroupBox12.TabIndex = 1
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "分離表示の文字と間隔"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(4, 81)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 29)
        Me.Label25.TabIndex = 22
        Me.Label25.Text = "間隔（文字の高さとの比）"
        '
        'cboSeparateGapSize
        '
        Me.cboSeparateGapSize.FormattingEnabled = True
        Me.cboSeparateGapSize.Location = New System.Drawing.Point(78, 91)
        Me.cboSeparateGapSize.Margin = New System.Windows.Forms.Padding(2)
        Me.cboSeparateGapSize.Name = "cboSeparateGapSize"
        Me.cboSeparateGapSize.Size = New System.Drawing.Size(48, 20)
        Me.cboSeparateGapSize.TabIndex = 3
        '
        'rbSeparateClassWords_English
        '
        Me.rbSeparateClassWords_English.Location = New System.Drawing.Point(11, 50)
        Me.rbSeparateClassWords_English.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSeparateClassWords_English.Name = "rbSeparateClassWords_English"
        Me.rbSeparateClassWords_English.Size = New System.Drawing.Size(122, 29)
        Me.rbSeparateClassWords_English.TabIndex = 2
        Me.rbSeparateClassWords_English.TabStop = True
        Me.rbSeparateClassWords_English.Text = "or more/ less than"
        Me.rbSeparateClassWords_English.UseVisualStyleBackColor = True
        '
        'rbSeparateClassWords_Japanese
        '
        Me.rbSeparateClassWords_Japanese.AutoSize = True
        Me.rbSeparateClassWords_Japanese.Location = New System.Drawing.Point(11, 30)
        Me.rbSeparateClassWords_Japanese.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSeparateClassWords_Japanese.Name = "rbSeparateClassWords_Japanese"
        Me.rbSeparateClassWords_Japanese.Size = New System.Drawing.Size(77, 16)
        Me.rbSeparateClassWords_Japanese.TabIndex = 1
        Me.rbSeparateClassWords_Japanese.TabStop = True
        Me.rbSeparateClassWords_Japanese.Text = "以上/未満"
        Me.rbSeparateClassWords_Japanese.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.Label24)
        Me.GroupBox15.Controls.Add(Me.picClassBoundary)
        Me.GroupBox15.Controls.Add(Me.chkClassBoundary)
        Me.GroupBox15.Location = New System.Drawing.Point(14, 135)
        Me.GroupBox15.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox15.Size = New System.Drawing.Size(225, 59)
        Me.GroupBox15.TabIndex = 3
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "面形状階級区分オブジェクト間の境界線"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(78, 30)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(68, 12)
        Me.Label24.TabIndex = 24
        Me.Label24.Text = "ラインパターン"
        '
        'picClassBoundary
        '
        Me.picClassBoundary.BackColor = System.Drawing.Color.White
        Me.picClassBoundary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picClassBoundary.Location = New System.Drawing.Point(150, 25)
        Me.picClassBoundary.Margin = New System.Windows.Forms.Padding(2)
        Me.picClassBoundary.Name = "picClassBoundary"
        Me.picClassBoundary.Size = New System.Drawing.Size(58, 23)
        Me.picClassBoundary.TabIndex = 23
        Me.picClassBoundary.TabStop = False
        '
        'chkClassBoundary
        '
        Me.chkClassBoundary.AutoSize = True
        Me.chkClassBoundary.Location = New System.Drawing.Point(22, 29)
        Me.chkClassBoundary.Margin = New System.Windows.Forms.Padding(2)
        Me.chkClassBoundary.Name = "chkClassBoundary"
        Me.chkClassBoundary.Size = New System.Drawing.Size(48, 16)
        Me.chkClassBoundary.TabIndex = 2
        Me.chkClassBoundary.Text = "表示"
        Me.chkClassBoundary.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.picPaintFrame)
        Me.GroupBox14.Controls.Add(Me.cboClassPaintWidth)
        Me.GroupBox14.Controls.Add(Me.chkClassMarkFrame)
        Me.GroupBox14.Controls.Add(Me.Label44)
        Me.GroupBox14.Controls.Add(Me.Label23)
        Me.GroupBox14.Location = New System.Drawing.Point(287, 17)
        Me.GroupBox14.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox14.Size = New System.Drawing.Size(204, 110)
        Me.GroupBox14.TabIndex = 2
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "階級区分枠"
        '
        'picPaintFrame
        '
        Me.picPaintFrame.BackColor = System.Drawing.Color.White
        Me.picPaintFrame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPaintFrame.Location = New System.Drawing.Point(21, 81)
        Me.picPaintFrame.Margin = New System.Windows.Forms.Padding(2)
        Me.picPaintFrame.Name = "picPaintFrame"
        Me.picPaintFrame.Size = New System.Drawing.Size(56, 23)
        Me.picPaintFrame.TabIndex = 23
        Me.picPaintFrame.TabStop = False
        '
        'cboClassPaintWidth
        '
        Me.cboClassPaintWidth.FormattingEnabled = True
        Me.cboClassPaintWidth.Location = New System.Drawing.Point(88, 40)
        Me.cboClassPaintWidth.Margin = New System.Windows.Forms.Padding(2)
        Me.cboClassPaintWidth.Name = "cboClassPaintWidth"
        Me.cboClassPaintWidth.Size = New System.Drawing.Size(59, 20)
        Me.cboClassPaintWidth.TabIndex = 0
        '
        'chkClassMarkFrame
        '
        Me.chkClassMarkFrame.Location = New System.Drawing.Point(100, 73)
        Me.chkClassMarkFrame.Margin = New System.Windows.Forms.Padding(2)
        Me.chkClassMarkFrame.Name = "chkClassMarkFrame"
        Me.chkClassMarkFrame.Size = New System.Drawing.Size(100, 30)
        Me.chkClassMarkFrame.TabIndex = 14
        Me.chkClassMarkFrame.Text = "階級記号モードでも表示する"
        Me.chkClassMarkFrame.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(19, 22)
        Me.Label44.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(144, 29)
        Me.Label44.TabIndex = 23
        Me.Label44.Text = "枠の幅（文字の高さとの比）"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(15, 64)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 12)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "ラインパターン"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.cbCategorySeparated)
        Me.GroupBox11.Controls.Add(Me.rbPaintLegend_Separated)
        Me.GroupBox11.Controls.Add(Me.rbPaintLegend_Normal)
        Me.GroupBox11.Location = New System.Drawing.Point(14, 17)
        Me.GroupBox11.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox11.Size = New System.Drawing.Size(127, 114)
        Me.GroupBox11.TabIndex = 0
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "凡例の表示方法"
        '
        'cbCategorySeparated
        '
        Me.cbCategorySeparated.Location = New System.Drawing.Point(9, 78)
        Me.cbCategorySeparated.Margin = New System.Windows.Forms.Padding(2)
        Me.cbCategorySeparated.Name = "cbCategorySeparated"
        Me.cbCategorySeparated.Size = New System.Drawing.Size(107, 36)
        Me.cbCategorySeparated.TabIndex = 26
        Me.cbCategorySeparated.Text = "カテゴリーデータは常に分離表示"
        Me.cbCategorySeparated.UseVisualStyleBackColor = True
        '
        'rbPaintLegend_Separated
        '
        Me.rbPaintLegend_Separated.AutoSize = True
        Me.rbPaintLegend_Separated.Location = New System.Drawing.Point(11, 58)
        Me.rbPaintLegend_Separated.Margin = New System.Windows.Forms.Padding(2)
        Me.rbPaintLegend_Separated.Name = "rbPaintLegend_Separated"
        Me.rbPaintLegend_Separated.Size = New System.Drawing.Size(71, 16)
        Me.rbPaintLegend_Separated.TabIndex = 1
        Me.rbPaintLegend_Separated.TabStop = True
        Me.rbPaintLegend_Separated.Text = "分離表示"
        Me.rbPaintLegend_Separated.UseVisualStyleBackColor = True
        '
        'rbPaintLegend_Normal
        '
        Me.rbPaintLegend_Normal.AutoSize = True
        Me.rbPaintLegend_Normal.Location = New System.Drawing.Point(13, 31)
        Me.rbPaintLegend_Normal.Margin = New System.Windows.Forms.Padding(2)
        Me.rbPaintLegend_Normal.Name = "rbPaintLegend_Normal"
        Me.rbPaintLegend_Normal.Size = New System.Drawing.Size(71, 16)
        Me.rbPaintLegend_Normal.TabIndex = 0
        Me.rbPaintLegend_Normal.TabStop = True
        Me.rbPaintLegend_Normal.Text = "通常表示"
        Me.rbPaintLegend_Normal.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.picMultiEnLine)
        Me.TabPage3.Controls.Add(Me.Label29)
        Me.TabPage3.Controls.Add(Me.正の値)
        Me.TabPage3.Controls.Add(Me.Label28)
        Me.TabPage3.Controls.Add(Me.Label27)
        Me.TabPage3.Controls.Add(Me.Label26)
        Me.TabPage3.Controls.Add(Me.chkMark_Circle_Mini)
        Me.TabPage3.Controls.Add(Me.GroupBox16)
        Me.TabPage3.Controls.Add(Me.txtBlockLegendWord)
        Me.TabPage3.Controls.Add(Me.txtPlusValue)
        Me.TabPage3.Controls.Add(Me.txtMinusValue)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(500, 204)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "記号・円グラフ"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'picMultiEnLine
        '
        Me.picMultiEnLine.BackColor = System.Drawing.Color.White
        Me.picMultiEnLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMultiEnLine.Location = New System.Drawing.Point(207, 58)
        Me.picMultiEnLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picMultiEnLine.Name = "picMultiEnLine"
        Me.picMultiEnLine.Size = New System.Drawing.Size(56, 23)
        Me.picMultiEnLine.TabIndex = 49
        Me.picMultiEnLine.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(27, 155)
        Me.Label29.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(39, 12)
        Me.Label29.TabIndex = 47
        Me.Label29.Text = "負の値"
        '
        '正の値
        '
        Me.正の値.AutoSize = True
        Me.正の値.Location = New System.Drawing.Point(25, 135)
        Me.正の値.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.正の値.Name = "正の値"
        Me.正の値.Size = New System.Drawing.Size(39, 12)
        Me.正の値.TabIndex = 46
        Me.正の値.Text = "正の値"
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(184, 100)
        Me.Label28.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(164, 29)
        Me.Label28.TabIndex = 25
        Me.Label28.Text = "記号の数モードの際の凡例文字"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(26, 100)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(138, 29)
        Me.Label27.TabIndex = 24
        Me.Label27.Text = "負の値の記号モードの凡例文字"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(184, 27)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(164, 31)
        Me.Label26.TabIndex = 23
        Me.Label26.Text = "記号の大きさモードの円、円・縦帯グラフの際の凡例線"
        '
        'chkMark_Circle_Mini
        '
        Me.chkMark_Circle_Mini.Location = New System.Drawing.Point(28, 28)
        Me.chkMark_Circle_Mini.Margin = New System.Windows.Forms.Padding(2)
        Me.chkMark_Circle_Mini.Name = "chkMark_Circle_Mini"
        Me.chkMark_Circle_Mini.Size = New System.Drawing.Size(152, 30)
        Me.chkMark_Circle_Mini.TabIndex = 15
        Me.chkMark_Circle_Mini.Text = "記号の大きさモードで円の凡例をコンパクトにまとめる"
        Me.chkMark_Circle_Mini.UseVisualStyleBackColor = True
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.rbOneCircle)
        Me.GroupBox16.Controls.Add(Me.rbMuliFan)
        Me.GroupBox16.Location = New System.Drawing.Point(352, 27)
        Me.GroupBox16.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox16.Size = New System.Drawing.Size(132, 102)
        Me.GroupBox16.TabIndex = 1
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "円グラフの凡例形状"
        '
        'rbOneCircle
        '
        Me.rbOneCircle.AutoSize = True
        Me.rbOneCircle.Location = New System.Drawing.Point(13, 71)
        Me.rbOneCircle.Margin = New System.Windows.Forms.Padding(2)
        Me.rbOneCircle.Name = "rbOneCircle"
        Me.rbOneCircle.Size = New System.Drawing.Size(62, 16)
        Me.rbOneCircle.TabIndex = 1
        Me.rbOneCircle.TabStop = True
        Me.rbOneCircle.Text = "１つの円"
        Me.rbOneCircle.UseVisualStyleBackColor = True
        '
        'rbMuliFan
        '
        Me.rbMuliFan.Location = New System.Drawing.Point(13, 31)
        Me.rbMuliFan.Margin = New System.Windows.Forms.Padding(2)
        Me.rbMuliFan.Name = "rbMuliFan"
        Me.rbMuliFan.Size = New System.Drawing.Size(115, 36)
        Me.rbMuliFan.TabIndex = 0
        Me.rbMuliFan.TabStop = True
        Me.rbMuliFan.Text = "複数の扇形に分ける"
        Me.rbMuliFan.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.chkPointDummy)
        Me.TabPage4.Controls.Add(Me.picLineKindLegendBack)
        Me.TabPage4.Controls.Add(Me.Label30)
        Me.TabPage4.Controls.Add(Me.chkLineKindLegend)
        Me.TabPage4.Controls.Add(Me.GroupBox17)
        Me.TabPage4.Controls.Add(Me.clbLineKindLegendShow)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(500, 204)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "線種・点ダミーの凡例"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'chkPointDummy
        '
        Me.chkPointDummy.Location = New System.Drawing.Point(326, 25)
        Me.chkPointDummy.Margin = New System.Windows.Forms.Padding(2)
        Me.chkPointDummy.Name = "chkPointDummy"
        Me.chkPointDummy.Size = New System.Drawing.Size(130, 30)
        Me.chkPointDummy.TabIndex = 35
        Me.chkPointDummy.Text = "点オブジェクトのダミーの凡例を表示"
        Me.chkPointDummy.UseVisualStyleBackColor = True
        '
        'picLineKindLegendBack
        '
        Me.picLineKindLegendBack.BackColor = System.Drawing.Color.White
        Me.picLineKindLegendBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLineKindLegendBack.Location = New System.Drawing.Point(201, 42)
        Me.picLineKindLegendBack.Margin = New System.Windows.Forms.Padding(2)
        Me.picLineKindLegendBack.Name = "picLineKindLegendBack"
        Me.picLineKindLegendBack.Size = New System.Drawing.Size(50, 36)
        Me.picLineKindLegendBack.TabIndex = 34
        Me.picLineKindLegendBack.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(198, 25)
        Me.Label30.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(53, 12)
        Me.Label30.TabIndex = 33
        Me.Label30.Text = "凡例背景"
        '
        'chkLineKindLegend
        '
        Me.chkLineKindLegend.Location = New System.Drawing.Point(24, 7)
        Me.chkLineKindLegend.Margin = New System.Windows.Forms.Padding(2)
        Me.chkLineKindLegend.Name = "chkLineKindLegend"
        Me.chkLineKindLegend.Size = New System.Drawing.Size(130, 30)
        Me.chkLineKindLegend.TabIndex = 15
        Me.chkLineKindLegend.Text = "線種の凡例を表示"
        Me.chkLineKindLegend.UseVisualStyleBackColor = True
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.rbLineKindStraight)
        Me.GroupBox17.Controls.Add(Me.rbLineKindZigzag)
        Me.GroupBox17.Location = New System.Drawing.Point(195, 88)
        Me.GroupBox17.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox17.Size = New System.Drawing.Size(110, 84)
        Me.GroupBox17.TabIndex = 2
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "線の描き方"
        '
        'rbLineKindStraight
        '
        Me.rbLineKindStraight.AutoSize = True
        Me.rbLineKindStraight.Location = New System.Drawing.Point(13, 56)
        Me.rbLineKindStraight.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLineKindStraight.Name = "rbLineKindStraight"
        Me.rbLineKindStraight.Size = New System.Drawing.Size(59, 16)
        Me.rbLineKindStraight.TabIndex = 1
        Me.rbLineKindStraight.TabStop = True
        Me.rbLineKindStraight.Text = "───"
        Me.rbLineKindStraight.UseVisualStyleBackColor = True
        '
        'rbLineKindZigzag
        '
        Me.rbLineKindZigzag.Location = New System.Drawing.Point(13, 16)
        Me.rbLineKindZigzag.Margin = New System.Windows.Forms.Padding(2)
        Me.rbLineKindZigzag.Name = "rbLineKindZigzag"
        Me.rbLineKindZigzag.Size = New System.Drawing.Size(115, 36)
        Me.rbLineKindZigzag.TabIndex = 0
        Me.rbLineKindZigzag.TabStop = True
        Me.rbLineKindZigzag.Text = "＼／＼"
        Me.rbLineKindZigzag.UseVisualStyleBackColor = True
        '
        'chkLegendVisible
        '
        Me.chkLegendVisible.AutoSize = True
        Me.chkLegendVisible.Location = New System.Drawing.Point(36, 26)
        Me.chkLegendVisible.Name = "chkLegendVisible"
        Me.chkLegendVisible.Size = New System.Drawing.Size(100, 16)
        Me.chkLegendVisible.TabIndex = 0
        Me.chkLegendVisible.Text = "凡例を表示する"
        Me.chkLegendVisible.UseVisualStyleBackColor = True
        '
        'tabMissingValue
        '
        Me.tabMissingValue.Controls.Add(Me.GroupBox18)
        Me.tabMissingValue.Controls.Add(Me.chkMissingPrintFlag)
        Me.tabMissingValue.Location = New System.Drawing.Point(4, 25)
        Me.tabMissingValue.Name = "tabMissingValue"
        Me.tabMissingValue.Size = New System.Drawing.Size(575, 304)
        Me.tabMissingValue.TabIndex = 3
        Me.tabMissingValue.Text = "欠損値"
        Me.tabMissingValue.UseVisualStyleBackColor = True
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.picMarkBarMissingValue)
        Me.GroupBox18.Controls.Add(Me.Label48)
        Me.GroupBox18.Controls.Add(Me.picLineShapeMissingValue)
        Me.GroupBox18.Controls.Add(Me.txtLabelModeMissingValue)
        Me.GroupBox18.Controls.Add(Me.picMarkTurnMissingValue)
        Me.GroupBox18.Controls.Add(Me.picMarkBlockMissingValue)
        Me.GroupBox18.Controls.Add(Me.picMarkSizeMissingValue)
        Me.GroupBox18.Controls.Add(Me.picClassMarkMissingValue)
        Me.GroupBox18.Controls.Add(Me.picClassHatchMissingValue)
        Me.GroupBox18.Controls.Add(Me.picClassPaintMissingValue)
        Me.GroupBox18.Controls.Add(Me.txtMissingWord)
        Me.GroupBox18.Controls.Add(Me.Label39)
        Me.GroupBox18.Controls.Add(Me.Label38)
        Me.GroupBox18.Controls.Add(Me.Label37)
        Me.GroupBox18.Controls.Add(Me.Label36)
        Me.GroupBox18.Controls.Add(Me.Label35)
        Me.GroupBox18.Controls.Add(Me.Label34)
        Me.GroupBox18.Controls.Add(Me.Label33)
        Me.GroupBox18.Controls.Add(Me.Label32)
        Me.GroupBox18.Controls.Add(Me.Label31)
        Me.GroupBox18.Location = New System.Drawing.Point(160, 24)
        Me.GroupBox18.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox18.Size = New System.Drawing.Size(401, 269)
        Me.GroupBox18.TabIndex = 1
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "欠損値のパターン"
        '
        'picMarkBarMissingValue
        '
        Me.picMarkBarMissingValue.BackColor = System.Drawing.Color.White
        Me.picMarkBarMissingValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMarkBarMissingValue.Location = New System.Drawing.Point(268, 140)
        Me.picMarkBarMissingValue.Margin = New System.Windows.Forms.Padding(2)
        Me.picMarkBarMissingValue.Name = "picMarkBarMissingValue"
        Me.picMarkBarMissingValue.Size = New System.Drawing.Size(56, 23)
        Me.picMarkBarMissingValue.TabIndex = 59
        Me.picMarkBarMissingValue.TabStop = False
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(229, 126)
        Me.Label48.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(133, 12)
        Me.Label48.TabIndex = 58
        Me.Label48.Text = "棒の高さモードの凡例記号"
        '
        'picLineShapeMissingValue
        '
        Me.picLineShapeMissingValue.BackColor = System.Drawing.Color.White
        Me.picLineShapeMissingValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLineShapeMissingValue.Location = New System.Drawing.Point(268, 237)
        Me.picLineShapeMissingValue.Margin = New System.Windows.Forms.Padding(2)
        Me.picLineShapeMissingValue.Name = "picLineShapeMissingValue"
        Me.picLineShapeMissingValue.Size = New System.Drawing.Size(56, 23)
        Me.picLineShapeMissingValue.TabIndex = 57
        Me.picLineShapeMissingValue.TabStop = False
        '
        'picMarkTurnMissingValue
        '
        Me.picMarkTurnMissingValue.BackColor = System.Drawing.Color.White
        Me.picMarkTurnMissingValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMarkTurnMissingValue.Location = New System.Drawing.Point(268, 94)
        Me.picMarkTurnMissingValue.Margin = New System.Windows.Forms.Padding(2)
        Me.picMarkTurnMissingValue.Name = "picMarkTurnMissingValue"
        Me.picMarkTurnMissingValue.Size = New System.Drawing.Size(56, 23)
        Me.picMarkTurnMissingValue.TabIndex = 55
        Me.picMarkTurnMissingValue.TabStop = False
        '
        'picMarkBlockMissingValue
        '
        Me.picMarkBlockMissingValue.BackColor = System.Drawing.Color.White
        Me.picMarkBlockMissingValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMarkBlockMissingValue.Location = New System.Drawing.Point(268, 43)
        Me.picMarkBlockMissingValue.Margin = New System.Windows.Forms.Padding(2)
        Me.picMarkBlockMissingValue.Name = "picMarkBlockMissingValue"
        Me.picMarkBlockMissingValue.Size = New System.Drawing.Size(56, 23)
        Me.picMarkBlockMissingValue.TabIndex = 54
        Me.picMarkBlockMissingValue.TabStop = False
        '
        'picMarkSizeMissingValue
        '
        Me.picMarkSizeMissingValue.BackColor = System.Drawing.Color.White
        Me.picMarkSizeMissingValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMarkSizeMissingValue.Location = New System.Drawing.Point(52, 237)
        Me.picMarkSizeMissingValue.Margin = New System.Windows.Forms.Padding(2)
        Me.picMarkSizeMissingValue.Name = "picMarkSizeMissingValue"
        Me.picMarkSizeMissingValue.Size = New System.Drawing.Size(56, 23)
        Me.picMarkSizeMissingValue.TabIndex = 53
        Me.picMarkSizeMissingValue.TabStop = False
        '
        'picClassMarkMissingValue
        '
        Me.picClassMarkMissingValue.BackColor = System.Drawing.Color.White
        Me.picClassMarkMissingValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picClassMarkMissingValue.Location = New System.Drawing.Point(52, 191)
        Me.picClassMarkMissingValue.Margin = New System.Windows.Forms.Padding(2)
        Me.picClassMarkMissingValue.Name = "picClassMarkMissingValue"
        Me.picClassMarkMissingValue.Size = New System.Drawing.Size(56, 23)
        Me.picClassMarkMissingValue.TabIndex = 52
        Me.picClassMarkMissingValue.TabStop = False
        '
        'picClassHatchMissingValue
        '
        Me.picClassHatchMissingValue.BackColor = System.Drawing.Color.White
        Me.picClassHatchMissingValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picClassHatchMissingValue.Location = New System.Drawing.Point(51, 140)
        Me.picClassHatchMissingValue.Margin = New System.Windows.Forms.Padding(2)
        Me.picClassHatchMissingValue.Name = "picClassHatchMissingValue"
        Me.picClassHatchMissingValue.Size = New System.Drawing.Size(56, 23)
        Me.picClassHatchMissingValue.TabIndex = 51
        Me.picClassHatchMissingValue.TabStop = False
        '
        'picClassPaintMissingValue
        '
        Me.picClassPaintMissingValue.BackColor = System.Drawing.Color.White
        Me.picClassPaintMissingValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picClassPaintMissingValue.Location = New System.Drawing.Point(52, 89)
        Me.picClassPaintMissingValue.Margin = New System.Windows.Forms.Padding(2)
        Me.picClassPaintMissingValue.Name = "picClassPaintMissingValue"
        Me.picClassPaintMissingValue.Size = New System.Drawing.Size(56, 23)
        Me.picClassPaintMissingValue.TabIndex = 50
        Me.picClassPaintMissingValue.TabStop = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(229, 223)
        Me.Label39.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(126, 12)
        Me.Label39.TabIndex = 8
        Me.Label39.Text = "線形状オブジェクトの凡例"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(229, 80)
        Me.Label38.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(149, 12)
        Me.Label38.TabIndex = 7
        Me.Label38.Text = "記号の回転モードの凡例記号"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(229, 178)
        Me.Label37.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(149, 12)
        Me.Label37.TabIndex = 6
        Me.Label37.Text = "文字・ラベルモードの凡例文字"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(19, 223)
        Me.Label36.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(154, 12)
        Me.Label36.TabIndex = 4
        Me.Label36.Text = "記号の大きさモードの凡例記号"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(229, 29)
        Me.Label35.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(137, 12)
        Me.Label35.TabIndex = 5
        Me.Label35.Text = "記号の数モードの凡例記号"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(19, 178)
        Me.Label34.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(139, 12)
        Me.Label34.TabIndex = 3
        Me.Label34.Text = "階級記号モードの凡例記号"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(19, 126)
        Me.Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(93, 12)
        Me.Label33.TabIndex = 2
        Me.Label33.Text = "ハッチモードの凡例"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(19, 75)
        Me.Label32.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(103, 12)
        Me.Label32.TabIndex = 1
        Me.Label32.Text = "ペイントモードの凡例"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(19, 29)
        Me.Label31.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(99, 12)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "欠損値の凡例文字"
        '
        'chkMissingPrintFlag
        '
        Me.chkMissingPrintFlag.AutoSize = True
        Me.chkMissingPrintFlag.Location = New System.Drawing.Point(28, 34)
        Me.chkMissingPrintFlag.Name = "chkMissingPrintFlag"
        Me.chkMissingPrintFlag.Size = New System.Drawing.Size(112, 16)
        Me.chkMissingPrintFlag.TabIndex = 1
        Me.chkMissingPrintFlag.Text = "欠損値を表示する"
        Me.chkMissingPrintFlag.UseVisualStyleBackColor = True
        '
        'tabScale
        '
        Me.tabScale.Controls.Add(Me.GroupBox20)
        Me.tabScale.Controls.Add(Me.Label41)
        Me.tabScale.Controls.Add(Me.GroupBox19)
        Me.tabScale.Controls.Add(Me.picScaleBack)
        Me.tabScale.Controls.Add(Me.Label40)
        Me.tabScale.Controls.Add(Me.btScaleFont)
        Me.tabScale.Controls.Add(Me.chkScaleShow)
        Me.tabScale.Controls.Add(Me.cboScaleUnit)
        Me.tabScale.Location = New System.Drawing.Point(4, 25)
        Me.tabScale.Name = "tabScale"
        Me.tabScale.Size = New System.Drawing.Size(575, 304)
        Me.tabScale.TabIndex = 4
        Me.tabScale.Text = "スケール設定"
        Me.tabScale.UseVisualStyleBackColor = True
        '
        'GroupBox20
        '
        Me.GroupBox20.Controls.Add(Me.rbScaleBar3)
        Me.GroupBox20.Controls.Add(Me.rbScalebar2)
        Me.GroupBox20.Controls.Add(Me.rbScalebar1)
        Me.GroupBox20.Location = New System.Drawing.Point(408, 56)
        Me.GroupBox20.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox20.Size = New System.Drawing.Size(153, 128)
        Me.GroupBox20.TabIndex = 5
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "スケールバーの種類"
        '
        'rbScaleBar3
        '
        Me.rbScaleBar3.Image = CType(resources.GetObject("rbScaleBar3.Image"), System.Drawing.Image)
        Me.rbScaleBar3.Location = New System.Drawing.Point(26, 91)
        Me.rbScaleBar3.Margin = New System.Windows.Forms.Padding(2)
        Me.rbScaleBar3.Name = "rbScaleBar3"
        Me.rbScaleBar3.Size = New System.Drawing.Size(86, 26)
        Me.rbScaleBar3.TabIndex = 2
        Me.rbScaleBar3.TabStop = True
        Me.rbScaleBar3.UseVisualStyleBackColor = True
        '
        'rbScalebar2
        '
        Me.rbScalebar2.Image = CType(resources.GetObject("rbScalebar2.Image"), System.Drawing.Image)
        Me.rbScalebar2.Location = New System.Drawing.Point(26, 61)
        Me.rbScalebar2.Margin = New System.Windows.Forms.Padding(2)
        Me.rbScalebar2.Name = "rbScalebar2"
        Me.rbScalebar2.Size = New System.Drawing.Size(80, 25)
        Me.rbScalebar2.TabIndex = 1
        Me.rbScalebar2.TabStop = True
        Me.rbScalebar2.UseVisualStyleBackColor = True
        '
        'rbScalebar1
        '
        Me.rbScalebar1.Image = CType(resources.GetObject("rbScalebar1.Image"), System.Drawing.Image)
        Me.rbScalebar1.Location = New System.Drawing.Point(26, 30)
        Me.rbScalebar1.Margin = New System.Windows.Forms.Padding(2)
        Me.rbScalebar1.Name = "rbScalebar1"
        Me.rbScalebar1.Size = New System.Drawing.Size(86, 27)
        Me.rbScalebar1.TabIndex = 0
        Me.rbScalebar1.TabStop = True
        Me.rbScalebar1.UseVisualStyleBackColor = True
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(46, 162)
        Me.Label41.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(121, 12)
        Me.Label41.TabIndex = 37
        Me.Label41.Text = "スケールバーの表示単位"
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.Label43)
        Me.GroupBox19.Controls.Add(Me.Label42)
        Me.GroupBox19.Controls.Add(Me.txtScaleBarKugiri)
        Me.GroupBox19.Controls.Add(Me.txtScaleBarDistance)
        Me.GroupBox19.Controls.Add(Me.chkScaleBarAuto)
        Me.GroupBox19.Location = New System.Drawing.Point(180, 56)
        Me.GroupBox19.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox19.Size = New System.Drawing.Size(209, 152)
        Me.GroupBox19.TabIndex = 4
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "スケールバーの長さ・間隔"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(52, 106)
        Me.Label43.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(117, 12)
        Me.Label43.TabIndex = 39
        Me.Label43.Text = "スケールバーの区切り数"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(52, 62)
        Me.Label42.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(97, 12)
        Me.Label42.TabIndex = 38
        Me.Label42.Text = "スケールバーの距離"
        '
        'chkScaleBarAuto
        '
        Me.chkScaleBarAuto.AutoSize = True
        Me.chkScaleBarAuto.Location = New System.Drawing.Point(23, 30)
        Me.chkScaleBarAuto.Name = "chkScaleBarAuto"
        Me.chkScaleBarAuto.Size = New System.Drawing.Size(130, 16)
        Me.chkScaleBarAuto.TabIndex = 3
        Me.chkScaleBarAuto.Text = "スケールバー自動設定"
        Me.chkScaleBarAuto.UseVisualStyleBackColor = True
        '
        'picScaleBack
        '
        Me.picScaleBack.BackColor = System.Drawing.Color.White
        Me.picScaleBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picScaleBack.Location = New System.Drawing.Point(115, 101)
        Me.picScaleBack.Margin = New System.Windows.Forms.Padding(2)
        Me.picScaleBack.Name = "picScaleBack"
        Me.picScaleBack.Size = New System.Drawing.Size(50, 36)
        Me.picScaleBack.TabIndex = 34
        Me.picScaleBack.TabStop = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(50, 111)
        Me.Label40.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(67, 12)
        Me.Label40.TabIndex = 2
        Me.Label40.Text = "スケール背景"
        '
        'btScaleFont
        '
        Me.btScaleFont.Location = New System.Drawing.Point(48, 56)
        Me.btScaleFont.Name = "btScaleFont"
        Me.btScaleFont.Size = New System.Drawing.Size(73, 24)
        Me.btScaleFont.TabIndex = 1
        Me.btScaleFont.Text = "フォント設定"
        Me.btScaleFont.UseVisualStyleBackColor = True
        '
        'chkScaleShow
        '
        Me.chkScaleShow.AutoSize = True
        Me.chkScaleShow.Location = New System.Drawing.Point(24, 24)
        Me.chkScaleShow.Name = "chkScaleShow"
        Me.chkScaleShow.Size = New System.Drawing.Size(114, 16)
        Me.chkScaleShow.TabIndex = 0
        Me.chkScaleShow.Text = "スケールを表示する"
        Me.chkScaleShow.UseVisualStyleBackColor = True
        '
        'tabTrip
        '
        Me.tabTrip.BackColor = System.Drawing.Color.Transparent
        Me.tabTrip.Controls.Add(Me.GroupBox23)
        Me.tabTrip.Controls.Add(Me.GroupBox22)
        Me.tabTrip.Location = New System.Drawing.Point(4, 25)
        Me.tabTrip.Name = "tabTrip"
        Me.tabTrip.Size = New System.Drawing.Size(575, 304)
        Me.tabTrip.TabIndex = 5
        Me.tabTrip.Text = "移動データ"
        Me.tabTrip.UseVisualStyleBackColor = True
        '
        'GroupBox23
        '
        Me.GroupBox23.Controls.Add(Me.Label54)
        Me.GroupBox23.Controls.Add(Me.btnTripZLegendFont)
        Me.GroupBox23.Controls.Add(Me.GroupBox24)
        Me.GroupBox23.Controls.Add(Me.picTripFrameLine)
        Me.GroupBox23.Controls.Add(Me.picTripZeroLine)
        Me.GroupBox23.Controls.Add(Me.picTripVerticalLine)
        Me.GroupBox23.Controls.Add(Me.picTripZeroPointMark)
        Me.GroupBox23.Controls.Add(Me.chkTripOverLap)
        Me.GroupBox23.Controls.Add(Me.chkTripVerticalLine)
        Me.GroupBox23.Controls.Add(Me.chkTripZeroLine)
        Me.GroupBox23.Controls.Add(Me.chkTripZeroPoint)
        Me.GroupBox23.Controls.Add(Me.chkTripFrame)
        Me.GroupBox23.Controls.Add(Me.Label53)
        Me.GroupBox23.Controls.Add(Me.Label50)
        Me.GroupBox23.Controls.Add(Me.Label49)
        Me.GroupBox23.Controls.Add(Me.txtTripPathHeight)
        Me.GroupBox23.Location = New System.Drawing.Point(232, 21)
        Me.GroupBox23.Name = "GroupBox23"
        Me.GroupBox23.Size = New System.Drawing.Size(328, 269)
        Me.GroupBox23.TabIndex = 1
        Me.GroupBox23.TabStop = False
        Me.GroupBox23.Text = "3Dモード時"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(228, 94)
        Me.Label54.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(94, 12)
        Me.Label54.TabIndex = 10
        Me.Label54.Text = "高さ軸凡例フォント"
        '
        'btnTripZLegendFont
        '
        Me.btnTripZLegendFont.Location = New System.Drawing.Point(230, 114)
        Me.btnTripZLegendFont.Name = "btnTripZLegendFont"
        Me.btnTripZLegendFont.Size = New System.Drawing.Size(85, 24)
        Me.btnTripZLegendFont.TabIndex = 11
        Me.btnTripZLegendFont.Text = "フォント"
        Me.btnTripZLegendFont.UseVisualStyleBackColor = True
        '
        'GroupBox24
        '
        Me.GroupBox24.Controls.Add(Me.rbTripZLegendLowerRight)
        Me.GroupBox24.Controls.Add(Me.rbTripZLegendLowerLeft)
        Me.GroupBox24.Controls.Add(Me.rbTripZLegendUpperRight)
        Me.GroupBox24.Controls.Add(Me.rbTripZLegendUpperLeft)
        Me.GroupBox24.Controls.Add(Me.rbTripZLegendNo)
        Me.GroupBox24.Location = New System.Drawing.Point(25, 74)
        Me.GroupBox24.Name = "GroupBox24"
        Me.GroupBox24.Size = New System.Drawing.Size(186, 68)
        Me.GroupBox24.TabIndex = 5
        Me.GroupBox24.TabStop = False
        Me.GroupBox24.Text = "高さ軸凡例位置"
        '
        'rbTripZLegendLowerRight
        '
        Me.rbTripZLegendLowerRight.AutoSize = True
        Me.rbTripZLegendLowerRight.Location = New System.Drawing.Point(132, 44)
        Me.rbTripZLegendLowerRight.Name = "rbTripZLegendLowerRight"
        Me.rbTripZLegendLowerRight.Size = New System.Drawing.Size(47, 16)
        Me.rbTripZLegendLowerRight.TabIndex = 8
        Me.rbTripZLegendLowerRight.TabStop = True
        Me.rbTripZLegendLowerRight.Text = "右下"
        Me.rbTripZLegendLowerRight.UseVisualStyleBackColor = True
        '
        'rbTripZLegendLowerLeft
        '
        Me.rbTripZLegendLowerLeft.AutoSize = True
        Me.rbTripZLegendLowerLeft.Location = New System.Drawing.Point(59, 44)
        Me.rbTripZLegendLowerLeft.Name = "rbTripZLegendLowerLeft"
        Me.rbTripZLegendLowerLeft.Size = New System.Drawing.Size(47, 16)
        Me.rbTripZLegendLowerLeft.TabIndex = 7
        Me.rbTripZLegendLowerLeft.TabStop = True
        Me.rbTripZLegendLowerLeft.Text = "左下"
        Me.rbTripZLegendLowerLeft.UseVisualStyleBackColor = True
        '
        'rbTripZLegendUpperRight
        '
        Me.rbTripZLegendUpperRight.AutoSize = True
        Me.rbTripZLegendUpperRight.Location = New System.Drawing.Point(132, 22)
        Me.rbTripZLegendUpperRight.Name = "rbTripZLegendUpperRight"
        Me.rbTripZLegendUpperRight.Size = New System.Drawing.Size(47, 16)
        Me.rbTripZLegendUpperRight.TabIndex = 6
        Me.rbTripZLegendUpperRight.TabStop = True
        Me.rbTripZLegendUpperRight.Text = "右上"
        Me.rbTripZLegendUpperRight.UseVisualStyleBackColor = True
        '
        'rbTripZLegendUpperLeft
        '
        Me.rbTripZLegendUpperLeft.AutoSize = True
        Me.rbTripZLegendUpperLeft.Location = New System.Drawing.Point(59, 22)
        Me.rbTripZLegendUpperLeft.Name = "rbTripZLegendUpperLeft"
        Me.rbTripZLegendUpperLeft.Size = New System.Drawing.Size(47, 16)
        Me.rbTripZLegendUpperLeft.TabIndex = 5
        Me.rbTripZLegendUpperLeft.TabStop = True
        Me.rbTripZLegendUpperLeft.Text = "左上"
        Me.rbTripZLegendUpperLeft.UseVisualStyleBackColor = True
        '
        'rbTripZLegendNo
        '
        Me.rbTripZLegendNo.AutoSize = True
        Me.rbTripZLegendNo.Location = New System.Drawing.Point(6, 18)
        Me.rbTripZLegendNo.Name = "rbTripZLegendNo"
        Me.rbTripZLegendNo.Size = New System.Drawing.Size(42, 16)
        Me.rbTripZLegendNo.TabIndex = 4
        Me.rbTripZLegendNo.TabStop = True
        Me.rbTripZLegendNo.Text = "なし"
        Me.rbTripZLegendNo.UseVisualStyleBackColor = True
        '
        'picTripFrameLine
        '
        Me.picTripFrameLine.BackColor = System.Drawing.Color.White
        Me.picTripFrameLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picTripFrameLine.Location = New System.Drawing.Point(155, 48)
        Me.picTripFrameLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picTripFrameLine.Name = "picTripFrameLine"
        Me.picTripFrameLine.Size = New System.Drawing.Size(56, 20)
        Me.picTripFrameLine.TabIndex = 54
        Me.picTripFrameLine.TabStop = False
        '
        'picTripZeroLine
        '
        Me.picTripZeroLine.BackColor = System.Drawing.Color.White
        Me.picTripZeroLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picTripZeroLine.Location = New System.Drawing.Point(167, 185)
        Me.picTripZeroLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picTripZeroLine.Name = "picTripZeroLine"
        Me.picTripZeroLine.Size = New System.Drawing.Size(56, 21)
        Me.picTripZeroLine.TabIndex = 64
        Me.picTripZeroLine.TabStop = False
        '
        'picTripVerticalLine
        '
        Me.picTripVerticalLine.BackColor = System.Drawing.Color.White
        Me.picTripVerticalLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picTripVerticalLine.Location = New System.Drawing.Point(167, 210)
        Me.picTripVerticalLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picTripVerticalLine.Name = "picTripVerticalLine"
        Me.picTripVerticalLine.Size = New System.Drawing.Size(56, 22)
        Me.picTripVerticalLine.TabIndex = 63
        Me.picTripVerticalLine.TabStop = False
        '
        'picTripZeroPointMark
        '
        Me.picTripZeroPointMark.BackColor = System.Drawing.Color.White
        Me.picTripZeroPointMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picTripZeroPointMark.Location = New System.Drawing.Point(167, 162)
        Me.picTripZeroPointMark.Margin = New System.Windows.Forms.Padding(2)
        Me.picTripZeroPointMark.Name = "picTripZeroPointMark"
        Me.picTripZeroPointMark.Size = New System.Drawing.Size(56, 20)
        Me.picTripZeroPointMark.TabIndex = 62
        Me.picTripZeroPointMark.TabStop = False
        '
        'chkTripOverLap
        '
        Me.chkTripOverLap.AutoSize = True
        Me.chkTripOverLap.Location = New System.Drawing.Point(22, 238)
        Me.chkTripOverLap.Name = "chkTripOverLap"
        Me.chkTripOverLap.Size = New System.Drawing.Size(182, 16)
        Me.chkTripOverLap.TabIndex = 9
        Me.chkTripOverLap.Text = "滞在位置が重なった場合にずらす"
        Me.chkTripOverLap.UseVisualStyleBackColor = True
        '
        'chkTripVerticalLine
        '
        Me.chkTripVerticalLine.AutoSize = True
        Me.chkTripVerticalLine.Location = New System.Drawing.Point(22, 214)
        Me.chkTripVerticalLine.Name = "chkTripVerticalLine"
        Me.chkTripVerticalLine.Size = New System.Drawing.Size(81, 16)
        Me.chkTripVerticalLine.TabIndex = 8
        Me.chkTripVerticalLine.Text = "垂線を表示"
        Me.chkTripVerticalLine.UseVisualStyleBackColor = True
        '
        'chkTripZeroLine
        '
        Me.chkTripZeroLine.AutoSize = True
        Me.chkTripZeroLine.Location = New System.Drawing.Point(22, 190)
        Me.chkTripZeroLine.Name = "chkTripZeroLine"
        Me.chkTripZeroLine.Size = New System.Drawing.Size(140, 16)
        Me.chkTripZeroLine.TabIndex = 7
        Me.chkTripZeroLine.Text = "地上に移動ラインを表示"
        Me.chkTripZeroLine.UseVisualStyleBackColor = True
        '
        'chkTripZeroPoint
        '
        Me.chkTripZeroPoint.AutoSize = True
        Me.chkTripZeroPoint.Location = New System.Drawing.Point(22, 167)
        Me.chkTripZeroPoint.Name = "chkTripZeroPoint"
        Me.chkTripZeroPoint.Size = New System.Drawing.Size(129, 16)
        Me.chkTripZeroPoint.TabIndex = 6
        Me.chkTripZeroPoint.Text = "地上に滞在地点表示"
        Me.chkTripZeroPoint.UseVisualStyleBackColor = True
        '
        'chkTripFrame
        '
        Me.chkTripFrame.AutoSize = True
        Me.chkTripFrame.Location = New System.Drawing.Point(22, 52)
        Me.chkTripFrame.Name = "chkTripFrame"
        Me.chkTripFrame.Size = New System.Drawing.Size(69, 16)
        Me.chkTripFrame.TabIndex = 3
        Me.chkTripFrame.Text = "枠を表示"
        Me.chkTripFrame.UseVisualStyleBackColor = True
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(110, 52)
        Me.Label53.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(41, 12)
        Me.Label53.TabIndex = 4
        Me.Label53.Text = "枠線種"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(142, 29)
        Me.Label50.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(17, 12)
        Me.Label50.TabIndex = 2
        Me.Label50.Text = "％"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(20, 25)
        Me.Label49.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(25, 12)
        Me.Label49.TabIndex = 0
        Me.Label49.Text = "高さ"
        '
        'GroupBox22
        '
        Me.GroupBox22.Controls.Add(Me.Label56)
        Me.GroupBox22.Controls.Add(Me.Label55)
        Me.GroupBox22.Controls.Add(Me.picEndPointMark)
        Me.GroupBox22.Controls.Add(Me.picStartPointMark)
        Me.GroupBox22.Controls.Add(Me.chkTripStart_End_Print)
        Me.GroupBox22.Controls.Add(Me.picTripStayLine)
        Me.GroupBox22.Controls.Add(Me.picTripMoveLine)
        Me.GroupBox22.Controls.Add(Me.Label52)
        Me.GroupBox22.Controls.Add(Me.Label51)
        Me.GroupBox22.Location = New System.Drawing.Point(20, 21)
        Me.GroupBox22.Name = "GroupBox22"
        Me.GroupBox22.Size = New System.Drawing.Size(187, 269)
        Me.GroupBox22.TabIndex = 0
        Me.GroupBox22.TabStop = False
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(27, 146)
        Me.Label56.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(87, 12)
        Me.Label56.TabIndex = 66
        Me.Label56.Text = "開始地点の記号"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(27, 194)
        Me.Label55.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(87, 12)
        Me.Label55.TabIndex = 65
        Me.Label55.Text = "終了地点の記号"
        '
        'picEndPointMark
        '
        Me.picEndPointMark.BackColor = System.Drawing.Color.White
        Me.picEndPointMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picEndPointMark.Location = New System.Drawing.Point(52, 214)
        Me.picEndPointMark.Margin = New System.Windows.Forms.Padding(2)
        Me.picEndPointMark.Name = "picEndPointMark"
        Me.picEndPointMark.Size = New System.Drawing.Size(45, 29)
        Me.picEndPointMark.TabIndex = 64
        Me.picEndPointMark.TabStop = False
        '
        'picStartPointMark
        '
        Me.picStartPointMark.BackColor = System.Drawing.Color.White
        Me.picStartPointMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picStartPointMark.Location = New System.Drawing.Point(52, 163)
        Me.picStartPointMark.Margin = New System.Windows.Forms.Padding(2)
        Me.picStartPointMark.Name = "picStartPointMark"
        Me.picStartPointMark.Size = New System.Drawing.Size(45, 29)
        Me.picStartPointMark.TabIndex = 63
        Me.picStartPointMark.TabStop = False
        '
        'chkTripStart_End_Print
        '
        Me.chkTripStart_End_Print.AutoSize = True
        Me.chkTripStart_End_Print.Location = New System.Drawing.Point(6, 112)
        Me.chkTripStart_End_Print.Name = "chkTripStart_End_Print"
        Me.chkTripStart_End_Print.Size = New System.Drawing.Size(168, 16)
        Me.chkTripStart_End_Print.TabIndex = 0
        Me.chkTripStart_End_Print.Text = "開始・終了地点に記号を表示"
        Me.chkTripStart_End_Print.UseVisualStyleBackColor = True
        '
        'picTripStayLine
        '
        Me.picTripStayLine.BackColor = System.Drawing.Color.White
        Me.picTripStayLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picTripStayLine.Location = New System.Drawing.Point(106, 75)
        Me.picTripStayLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picTripStayLine.Name = "picTripStayLine"
        Me.picTripStayLine.Size = New System.Drawing.Size(56, 23)
        Me.picTripStayLine.TabIndex = 55
        Me.picTripStayLine.TabStop = False
        '
        'picTripMoveLine
        '
        Me.picTripMoveLine.BackColor = System.Drawing.Color.White
        Me.picTripMoveLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picTripMoveLine.Location = New System.Drawing.Point(106, 30)
        Me.picTripMoveLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picTripMoveLine.Name = "picTripMoveLine"
        Me.picTripMoveLine.Size = New System.Drawing.Size(56, 23)
        Me.picTripMoveLine.TabIndex = 54
        Me.picTripMoveLine.TabStop = False
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(5, 75)
        Me.Label52.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(55, 12)
        Me.Label52.TabIndex = 42
        Me.Label52.Text = "滞在ライン"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(5, 38)
        Me.Label51.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(55, 12)
        Me.Label51.TabIndex = 41
        Me.Label51.Text = "移動ライン"
        '
        'cboSoubyouAutoDegree
        '
        Me.cboSoubyouAutoDegree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSoubyouAutoDegree.FormattingEnabled = True
        Me.cboSoubyouAutoDegree.Items.AddRange(New Object() {"弱", "中", "強", "最強"})
        Me.cboSoubyouAutoDegree.Location = New System.Drawing.Point(56, 14)
        Me.cboSoubyouAutoDegree.MaxDropDownItems = 15
        Me.cboSoubyouAutoDegree.Name = "cboSoubyouAutoDegree"
        Me.cboSoubyouAutoDegree.Size = New System.Drawing.Size(53, 20)
        Me.cboSoubyouAutoDegree.TabIndex = 21
        '
        'txtNoteMaxWidth
        '
        Me.txtNoteMaxWidth.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtNoteMaxWidth.Location = New System.Drawing.Point(110, 154)
        Me.txtNoteMaxWidth.MaxValue = 0.0R
        Me.txtNoteMaxWidth.MaxValueFlag = False
        Me.txtNoteMaxWidth.MinValue = 0.0R
        Me.txtNoteMaxWidth.MinValueFlag = True
        Me.txtNoteMaxWidth.Name = "txtNoteMaxWidth"
        Me.txtNoteMaxWidth.NumberPoint = True
        Me.txtNoteMaxWidth.Size = New System.Drawing.Size(48, 19)
        Me.txtNoteMaxWidth.TabIndex = 31
        Me.txtNoteMaxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNoteMaxWidth.ValueErrorMessageFlag = True
        '
        'txtTitleMaxWidth
        '
        Me.txtTitleMaxWidth.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTitleMaxWidth.Location = New System.Drawing.Point(110, 66)
        Me.txtTitleMaxWidth.MaxValue = 0.0R
        Me.txtTitleMaxWidth.MaxValueFlag = False
        Me.txtTitleMaxWidth.MinValue = 0.0R
        Me.txtTitleMaxWidth.MinValueFlag = True
        Me.txtTitleMaxWidth.Name = "txtTitleMaxWidth"
        Me.txtTitleMaxWidth.NumberPoint = True
        Me.txtTitleMaxWidth.Size = New System.Drawing.Size(48, 19)
        Me.txtTitleMaxWidth.TabIndex = 4
        Me.txtTitleMaxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTitleMaxWidth.ValueErrorMessageFlag = True
        '
        'txtLeftMargin
        '
        Me.txtLeftMargin.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLeftMargin.Location = New System.Drawing.Point(192, 54)
        Me.txtLeftMargin.MaxValue = 0.0R
        Me.txtLeftMargin.MaxValueFlag = False
        Me.txtLeftMargin.MinValue = 0.0R
        Me.txtLeftMargin.MinValueFlag = True
        Me.txtLeftMargin.Name = "txtLeftMargin"
        Me.txtLeftMargin.NumberPoint = True
        Me.txtLeftMargin.Size = New System.Drawing.Size(48, 19)
        Me.txtLeftMargin.TabIndex = 23
        Me.txtLeftMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLeftMargin.ValueErrorMessageFlag = True
        '
        'txtBottomMargin
        '
        Me.txtBottomMargin.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBottomMargin.Location = New System.Drawing.Point(66, 54)
        Me.txtBottomMargin.MaxValue = 0.0R
        Me.txtBottomMargin.MaxValueFlag = False
        Me.txtBottomMargin.MinValue = 0.0R
        Me.txtBottomMargin.MinValueFlag = True
        Me.txtBottomMargin.Name = "txtBottomMargin"
        Me.txtBottomMargin.NumberPoint = True
        Me.txtBottomMargin.Size = New System.Drawing.Size(48, 19)
        Me.txtBottomMargin.TabIndex = 22
        Me.txtBottomMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBottomMargin.ValueErrorMessageFlag = True
        '
        'txtRightMargin
        '
        Me.txtRightMargin.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtRightMargin.Location = New System.Drawing.Point(192, 22)
        Me.txtRightMargin.MaxValue = 0.0R
        Me.txtRightMargin.MaxValueFlag = False
        Me.txtRightMargin.MinValue = 0.0R
        Me.txtRightMargin.MinValueFlag = True
        Me.txtRightMargin.Name = "txtRightMargin"
        Me.txtRightMargin.NumberPoint = True
        Me.txtRightMargin.Size = New System.Drawing.Size(48, 19)
        Me.txtRightMargin.TabIndex = 21
        Me.txtRightMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRightMargin.ValueErrorMessageFlag = True
        '
        'txtUpperMargin
        '
        Me.txtUpperMargin.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtUpperMargin.Location = New System.Drawing.Point(66, 23)
        Me.txtUpperMargin.MaxValue = 0.0R
        Me.txtUpperMargin.MaxValueFlag = False
        Me.txtUpperMargin.MinValue = 0.0R
        Me.txtUpperMargin.MinValueFlag = True
        Me.txtUpperMargin.Name = "txtUpperMargin"
        Me.txtUpperMargin.NumberPoint = True
        Me.txtUpperMargin.Size = New System.Drawing.Size(48, 19)
        Me.txtUpperMargin.TabIndex = 20
        Me.txtUpperMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUpperMargin.ValueErrorMessageFlag = True
        '
        'txtOverlayTitleWidth
        '
        Me.txtOverlayTitleWidth.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtOverlayTitleWidth.Location = New System.Drawing.Point(62, 74)
        Me.txtOverlayTitleWidth.MaxValue = 0.0R
        Me.txtOverlayTitleWidth.MaxValueFlag = False
        Me.txtOverlayTitleWidth.MinValue = 0.0R
        Me.txtOverlayTitleWidth.MinValueFlag = True
        Me.txtOverlayTitleWidth.Name = "txtOverlayTitleWidth"
        Me.txtOverlayTitleWidth.NumberPoint = True
        Me.txtOverlayTitleWidth.Size = New System.Drawing.Size(48, 19)
        Me.txtOverlayTitleWidth.TabIndex = 23
        Me.txtOverlayTitleWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtOverlayTitleWidth.ValueErrorMessageFlag = True
        '
        'txtBlockLegendWord
        '
        Me.txtBlockLegendWord.Location = New System.Drawing.Point(207, 131)
        Me.txtBlockLegendWord.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBlockLegendWord.Name = "txtBlockLegendWord"
        Me.txtBlockLegendWord.Size = New System.Drawing.Size(77, 19)
        Me.txtBlockLegendWord.TabIndex = 48
        '
        'txtPlusValue
        '
        Me.txtPlusValue.Location = New System.Drawing.Point(68, 131)
        Me.txtPlusValue.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPlusValue.Name = "txtPlusValue"
        Me.txtPlusValue.Size = New System.Drawing.Size(77, 19)
        Me.txtPlusValue.TabIndex = 44
        '
        'txtMinusValue
        '
        Me.txtMinusValue.Location = New System.Drawing.Point(68, 152)
        Me.txtMinusValue.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMinusValue.Name = "txtMinusValue"
        Me.txtMinusValue.Size = New System.Drawing.Size(77, 19)
        Me.txtMinusValue.TabIndex = 45
        '
        'clbLineKindLegendShow
        '
        Me.clbLineKindLegendShow.CheckOnClick = True
        Me.clbLineKindLegendShow.EventStop = False
        Me.clbLineKindLegendShow.FormattingEnabled = True
        Me.clbLineKindLegendShow.Location = New System.Drawing.Point(24, 42)
        Me.clbLineKindLegendShow.Name = "clbLineKindLegendShow"
        Me.clbLineKindLegendShow.Size = New System.Drawing.Size(157, 102)
        Me.clbLineKindLegendShow.TabIndex = 3
        '
        'txtLabelModeMissingValue
        '
        Me.txtLabelModeMissingValue.Location = New System.Drawing.Point(268, 196)
        Me.txtLabelModeMissingValue.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLabelModeMissingValue.Name = "txtLabelModeMissingValue"
        Me.txtLabelModeMissingValue.Size = New System.Drawing.Size(98, 19)
        Me.txtLabelModeMissingValue.TabIndex = 56
        '
        'txtMissingWord
        '
        Me.txtMissingWord.Location = New System.Drawing.Point(51, 42)
        Me.txtMissingWord.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMissingWord.Name = "txtMissingWord"
        Me.txtMissingWord.Size = New System.Drawing.Size(98, 19)
        Me.txtMissingWord.TabIndex = 0
        '
        'txtScaleBarKugiri
        '
        Me.txtScaleBarKugiri.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtScaleBarKugiri.Location = New System.Drawing.Point(89, 121)
        Me.txtScaleBarKugiri.MaxValue = 0.0R
        Me.txtScaleBarKugiri.MaxValueFlag = False
        Me.txtScaleBarKugiri.MinValue = 0.0R
        Me.txtScaleBarKugiri.MinValueFlag = True
        Me.txtScaleBarKugiri.Name = "txtScaleBarKugiri"
        Me.txtScaleBarKugiri.NumberPoint = True
        Me.txtScaleBarKugiri.Size = New System.Drawing.Size(48, 19)
        Me.txtScaleBarKugiri.TabIndex = 24
        Me.txtScaleBarKugiri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtScaleBarKugiri.ValueErrorMessageFlag = True
        '
        'txtScaleBarDistance
        '
        Me.txtScaleBarDistance.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtScaleBarDistance.Location = New System.Drawing.Point(89, 78)
        Me.txtScaleBarDistance.MaxValue = 0.0R
        Me.txtScaleBarDistance.MaxValueFlag = False
        Me.txtScaleBarDistance.MinValue = 0.0R
        Me.txtScaleBarDistance.MinValueFlag = True
        Me.txtScaleBarDistance.Name = "txtScaleBarDistance"
        Me.txtScaleBarDistance.NumberPoint = True
        Me.txtScaleBarDistance.Size = New System.Drawing.Size(48, 19)
        Me.txtScaleBarDistance.TabIndex = 23
        Me.txtScaleBarDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtScaleBarDistance.ValueErrorMessageFlag = True
        '
        'cboScaleUnit
        '
        Me.cboScaleUnit.AsteriskSelectEnabled = False
        Me.cboScaleUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScaleUnit.FormattingEnabled = True
        Me.cboScaleUnit.IntegralHeight = False
        Me.cboScaleUnit.Location = New System.Drawing.Point(68, 177)
        Me.cboScaleUnit.Margin = New System.Windows.Forms.Padding(2)
        Me.cboScaleUnit.MaxDropDownItems = 15
        Me.cboScaleUnit.Name = "cboScaleUnit"
        Me.cboScaleUnit.Size = New System.Drawing.Size(92, 20)
        Me.cboScaleUnit.TabIndex = 3
        '
        'txtTripPathHeight
        '
        Me.txtTripPathHeight.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTripPathHeight.Location = New System.Drawing.Point(89, 22)
        Me.txtTripPathHeight.MaxValue = 0.0R
        Me.txtTripPathHeight.MaxValueFlag = False
        Me.txtTripPathHeight.MinValue = 0.0R
        Me.txtTripPathHeight.MinValueFlag = True
        Me.txtTripPathHeight.Name = "txtTripPathHeight"
        Me.txtTripPathHeight.NumberPoint = True
        Me.txtTripPathHeight.Size = New System.Drawing.Size(48, 19)
        Me.txtTripPathHeight.TabIndex = 1
        Me.txtTripPathHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTripPathHeight.ValueErrorMessageFlag = True
        '
        'frmPrint_Option
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(607, 384)
        Me.Controls.Add(Me.tabAll)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_Option"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オプション"
        Me.tabAll.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        Me.GroupBox21.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.picSymbolLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.picAccGroupBoxBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAccVisible.ResumeLayout(False)
        Me.gbAccVisible.PerformLayout()
        Me.tabBackGround.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.gbLatLonLine.ResumeLayout(False)
        Me.gbLatLonLine.PerformLayout()
        Me.GroupBox25.ResumeLayout(False)
        Me.GroupBox25.PerformLayout()
        CType(Me.picLatLonEqLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLatLonOuterLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLatLonLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.picObjectInnerTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picScreenFrameLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMapAreaTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picScreenAreaTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMapFrameLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.tabLegend.ResumeLayout(False)
        Me.tabLegend.PerformLayout()
        Me.tbLegend.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.picLegendBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        CType(Me.picClassBoundary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        CType(Me.picPaintFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.picMultiEnLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.picLineKindLegendBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.tabMissingValue.ResumeLayout(False)
        Me.tabMissingValue.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        CType(Me.picMarkBarMissingValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLineShapeMissingValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMarkTurnMissingValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMarkBlockMissingValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMarkSizeMissingValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClassMarkMissingValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClassHatchMissingValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClassPaintMissingValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabScale.ResumeLayout(False)
        Me.tabScale.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        CType(Me.picScaleBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTrip.ResumeLayout(False)
        Me.GroupBox23.ResumeLayout(False)
        Me.GroupBox23.PerformLayout()
        Me.GroupBox24.ResumeLayout(False)
        Me.GroupBox24.PerformLayout()
        CType(Me.picTripFrameLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTripZeroLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTripVerticalLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTripZeroPointMark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox22.ResumeLayout(False)
        Me.GroupBox22.PerformLayout()
        CType(Me.picEndPointMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStartPointMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTripStayLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTripMoveLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tabAll As System.Windows.Forms.TabControl
    Friend WithEvents tabGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tabBackGround As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnThiningPoint As System.Windows.Forms.Button
    Friend WithEvents chkObjSpline As System.Windows.Forms.CheckBox
    Friend WithEvents chkSymbolLine As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPointPaintOrder_fromTopCategory As System.Windows.Forms.RadioButton
    Friend WithEvents rbPointPaintOrder_fromBottomCategory As System.Windows.Forms.RadioButton
    Friend WithEvents rbPointPaintOrder_byObjectOrder As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tabLegend As System.Windows.Forms.TabPage
    Friend WithEvents tabMissingValue As System.Windows.Forms.TabPage
    Friend WithEvents tabScale As System.Windows.Forms.TabPage
    Friend WithEvents tabTrip As System.Windows.Forms.TabPage
    Friend WithEvents rbAccBaseOnMap As System.Windows.Forms.RadioButton
    Friend WithEvents rbAccBaseOnScreen As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents picSymbolLine As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents chkMarginClip As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents picObjectInnerTile As System.Windows.Forms.PictureBox
    Friend WithEvents picScreenFrameLine As System.Windows.Forms.PictureBox
    Friend WithEvents picMapAreaTile As System.Windows.Forms.PictureBox
    Friend WithEvents picScreenAreaTile As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents picMapFrameLine As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents gbLatLonLine As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents picLatLonLine As System.Windows.Forms.PictureBox
    Friend WithEvents chkLatLonPrint As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents rbLatLonLineFront As System.Windows.Forms.RadioButton
    Friend WithEvents rbLatLonLineBack As System.Windows.Forms.RadioButton
    Friend WithEvents txtUpperMargin As mandara10.TextNumberBox
    Friend WithEvents txtLeftMargin As mandara10.TextNumberBox
    Friend WithEvents txtBottomMargin As mandara10.TextNumberBox
    Friend WithEvents txtRightMargin As mandara10.TextNumberBox
    Friend WithEvents btnLatLonLineInterval As System.Windows.Forms.Button
    Friend WithEvents lblLonLineInterval As System.Windows.Forms.Label
    Friend WithEvents lblLatLineInterval As System.Windows.Forms.Label
    Friend WithEvents chkLegendComma As System.Windows.Forms.CheckBox
    Friend WithEvents tbLegend As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents chkLegendVisible As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txtOverlayTitleWidth As mandara10.TextNumberBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents chkOverlayTitleVisible As System.Windows.Forms.CheckBox
    Friend WithEvents picLegendBack As System.Windows.Forms.PictureBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnLegendFontSetting As System.Windows.Forms.Button
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSeparateClassWords_English As System.Windows.Forms.RadioButton
    Friend WithEvents rbSeparateClassWords_Japanese As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents picClassBoundary As System.Windows.Forms.PictureBox
    Friend WithEvents chkClassBoundary As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents picPaintFrame As System.Windows.Forms.PictureBox
    Friend WithEvents chkClassMarkFrame As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboClassPaintWidth As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPaintLegend_Separated As System.Windows.Forms.RadioButton
    Friend WithEvents rbPaintLegend_Normal As System.Windows.Forms.RadioButton
    Friend WithEvents cboSeparateGapSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents chkMark_Circle_Mini As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents rbOneCircle As System.Windows.Forms.RadioButton
    Friend WithEvents rbMuliFan As System.Windows.Forms.RadioButton
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtPlusValue As mandara10.TextBoxFocusAllSelect
    Friend WithEvents 正の値 As System.Windows.Forms.Label
    Friend WithEvents txtMinusValue As mandara10.TextBoxFocusAllSelect
    Friend WithEvents txtBlockLegendWord As mandara10.TextBoxFocusAllSelect
    Friend WithEvents picMultiEnLine As System.Windows.Forms.PictureBox
    Friend WithEvents chkPointDummy As System.Windows.Forms.CheckBox
    Friend WithEvents picLineKindLegendBack As System.Windows.Forms.PictureBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents chkLineKindLegend As System.Windows.Forms.CheckBox
    Friend WithEvents clbLineKindLegendShow As mandara10.CheckedListBoxEx
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents rbLineKindStraight As System.Windows.Forms.RadioButton
    Friend WithEvents rbLineKindZigzag As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents chkMissingPrintFlag As System.Windows.Forms.CheckBox
    Friend WithEvents picLineShapeMissingValue As System.Windows.Forms.PictureBox
    Friend WithEvents txtLabelModeMissingValue As mandara10.TextBoxFocusAllSelect
    Friend WithEvents picMarkTurnMissingValue As System.Windows.Forms.PictureBox
    Friend WithEvents picMarkBlockMissingValue As System.Windows.Forms.PictureBox
    Friend WithEvents picMarkSizeMissingValue As System.Windows.Forms.PictureBox
    Friend WithEvents picClassMarkMissingValue As System.Windows.Forms.PictureBox
    Friend WithEvents picClassHatchMissingValue As System.Windows.Forms.PictureBox
    Friend WithEvents picClassPaintMissingValue As System.Windows.Forms.PictureBox
    Friend WithEvents txtMissingWord As mandara10.TextBoxFocusAllSelect
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents rbScalebar2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbScalebar1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents cboScaleUnit As mandara10.ComboBoxEx
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtScaleBarKugiri As mandara10.TextNumberBox
    Friend WithEvents txtScaleBarDistance As mandara10.TextNumberBox
    Friend WithEvents chkScaleBarAuto As System.Windows.Forms.CheckBox
    Friend WithEvents picScaleBack As System.Windows.Forms.PictureBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents btScaleFont As System.Windows.Forms.Button
    Friend WithEvents chkScaleShow As System.Windows.Forms.CheckBox
    Friend WithEvents chkFreq As System.Windows.Forms.CheckBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents picAccGroupBoxBack As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents clbAccGroupBoxItem As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkAccGroupBox As System.Windows.Forms.CheckBox
    Friend WithEvents gbAccVisible As System.Windows.Forms.GroupBox
    Friend WithEvents txtTitleMaxWidth As mandara10.TextNumberBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnCompassSetting As System.Windows.Forms.Button
    Friend WithEvents btnTitleFont As System.Windows.Forms.Button
    Friend WithEvents chkFigureVisible As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompassVisible As System.Windows.Forms.CheckBox
    Friend WithEvents chkTitleVisible As System.Windows.Forms.CheckBox
    Friend WithEvents chkMapShow As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents cboMinimumLineWidth As System.Windows.Forms.ComboBox
    Friend WithEvents btnTIleLicenceFont As System.Windows.Forms.Button
    Friend WithEvents txtNoteMaxWidth As mandara10.TextNumberBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents btnNoteFont As System.Windows.Forms.Button
    Friend WithEvents chkNoteVisible As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cboMaxAutoDrawTime As System.Windows.Forms.ComboBox
    Friend WithEvents picMarkBarMissingValue As System.Windows.Forms.PictureBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents GroupBox23 As System.Windows.Forms.GroupBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents btnTripZLegendFont As System.Windows.Forms.Button
    Friend WithEvents GroupBox24 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTripZLegendLowerRight As System.Windows.Forms.RadioButton
    Friend WithEvents rbTripZLegendLowerLeft As System.Windows.Forms.RadioButton
    Friend WithEvents rbTripZLegendUpperRight As System.Windows.Forms.RadioButton
    Friend WithEvents rbTripZLegendUpperLeft As System.Windows.Forms.RadioButton
    Friend WithEvents rbTripZLegendNo As System.Windows.Forms.RadioButton
    Friend WithEvents picTripFrameLine As System.Windows.Forms.PictureBox
    Friend WithEvents picTripZeroLine As System.Windows.Forms.PictureBox
    Friend WithEvents picTripVerticalLine As System.Windows.Forms.PictureBox
    Friend WithEvents picTripZeroPointMark As System.Windows.Forms.PictureBox
    Friend WithEvents chkTripOverLap As System.Windows.Forms.CheckBox
    Friend WithEvents chkTripVerticalLine As System.Windows.Forms.CheckBox
    Friend WithEvents chkTripZeroLine As System.Windows.Forms.CheckBox
    Friend WithEvents chkTripZeroPoint As System.Windows.Forms.CheckBox
    Friend WithEvents chkTripFrame As System.Windows.Forms.CheckBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtTripPathHeight As mandara10.TextNumberBox
    Friend WithEvents GroupBox22 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTripStart_End_Print As System.Windows.Forms.CheckBox
    Friend WithEvents picTripStayLine As System.Windows.Forms.PictureBox
    Friend WithEvents picTripMoveLine As System.Windows.Forms.PictureBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents picEndPointMark As System.Windows.Forms.PictureBox
    Friend WithEvents picStartPointMark As System.Windows.Forms.PictureBox
    Friend WithEvents rbScaleBar3 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox25 As System.Windows.Forms.GroupBox
    Friend WithEvents picLatLonEqLine As System.Windows.Forms.PictureBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents picLatLonOuterLine As System.Windows.Forms.PictureBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents chkModeValueInScreenFlag As System.Windows.Forms.CheckBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents cbCategorySeparated As System.Windows.Forms.CheckBox
    Friend WithEvents chkSoubyouAuto As System.Windows.Forms.CheckBox
    Friend WithEvents cboSoubyouAutoDegree As System.Windows.Forms.ComboBox
End Class
