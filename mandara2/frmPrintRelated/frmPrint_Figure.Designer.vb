<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_Figure
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint_Figure))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TableLayoutPanelFigMode = New System.Windows.Forms.TableLayoutPanel()
        Me.picFigImage = New System.Windows.Forms.PictureBox()
        Me.picFigPoint = New System.Windows.Forms.PictureBox()
        Me.picFigLine = New System.Windows.Forms.PictureBox()
        Me.picFigWord = New System.Windows.Forms.PictureBox()
        Me.picFigSelect = New System.Windows.Forms.PictureBox()
        Me.picFigObjectCircle = New System.Windows.Forms.PictureBox()
        Me.picFigCircle = New System.Windows.Forms.PictureBox()
        Me.picFigRectangle = New System.Windows.Forms.PictureBox()
        Me.pnlFigMode = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlTargetData = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlCommon = New System.Windows.Forms.Panel()
        Me.btnEdirCancel = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnAhead = New System.Windows.Forms.Button()
        Me.pnlPointting = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlWord = New System.Windows.Forms.Panel()
        Me.btnWordLineUp = New System.Windows.Forms.Button()
        Me.chkScattered_Mode_F = New System.Windows.Forms.CheckBox()
        Me.btnWordFont = New System.Windows.Forms.Button()
        Me.txtWord = New System.Windows.Forms.TextBox()
        Me.pnlLine = New System.Windows.Forms.Panel()
        Me.btnLineGet = New System.Windows.Forms.Button()
        Me.chkLineClose = New System.Windows.Forms.CheckBox()
        Me.btnLinePattern = New System.Windows.Forms.Button()
        Me.btnLineArrow = New System.Windows.Forms.Button()
        Me.picLineInnerPaint = New System.Windows.Forms.PictureBox()
        Me.chkLineInnerPaint = New System.Windows.Forms.CheckBox()
        Me.chkLineSpline = New System.Windows.Forms.CheckBox()
        Me.pnlRectangle = New System.Windows.Forms.Panel()
        Me.picRectangleBox = New System.Windows.Forms.PictureBox()
        Me.pnlCircle = New System.Windows.Forms.Panel()
        Me.picCircleCenterMark = New System.Windows.Forms.PictureBox()
        Me.chkCircleCenterMark = New System.Windows.Forms.CheckBox()
        Me.picCircleInnerPat = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.picCircleLinePat = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCircleScaleUnit1 = New System.Windows.Forms.Label()
        Me.lblCircleScaleUnit0 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlObjectCircle = New System.Windows.Forms.Panel()
        Me.picObjCircleCenterMark = New System.Windows.Forms.PictureBox()
        Me.chkObjCircleCenterMark = New System.Windows.Forms.CheckBox()
        Me.picObjCircleInnerPat = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.picObjCircleLinePat = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblObjCircleScaleUnit = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlPoints = New System.Windows.Forms.Panel()
        Me.lblPointNumber = New System.Windows.Forms.Label()
        Me.btnPointGet = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPointLegend = New System.Windows.Forms.TextBox()
        Me.btnPointLegendFont = New System.Windows.Forms.Button()
        Me.chkPointLegend = New System.Windows.Forms.CheckBox()
        Me.picPointMark = New System.Windows.Forms.PictureBox()
        Me.pnlImage = New System.Windows.Forms.Panel()
        Me.btnImageAlphaValue = New System.Windows.Forms.Button()
        Me.picImageInnerColor = New System.Windows.Forms.PictureBox()
        Me.chkImageChangeInnerColor = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkImageMapBack = New System.Windows.Forms.CheckBox()
        Me.picImageFrameLine = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnImageSelect = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.txtImageAngle = New mandara10.TextNumberBox()
        Me.lbObjCircleObject = New mandara10.ListBoxEx()
        Me.txtObjCircleRadius = New mandara10.TextNumberBox()
        Me.txtCircleAngle = New mandara10.TextNumberBox()
        Me.txtCircleAxisDistance1 = New mandara10.TextNumberBox()
        Me.txtCircleAxisDistance0 = New mandara10.TextNumberBox()
        Me.cboData = New mandara10.ComboBoxEx()
        Me.cboLayer = New mandara10.ComboBoxEx()
        Me.chkWordScreenSetF = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanelFigMode.SuspendLayout()
        CType(Me.picFigImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFigPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFigLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFigWord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFigSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFigObjectCircle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFigCircle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFigRectangle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFigMode.SuspendLayout()
        Me.pnlTargetData.SuspendLayout()
        Me.pnlCommon.SuspendLayout()
        Me.pnlPointting.SuspendLayout()
        Me.pnlWord.SuspendLayout()
        Me.pnlLine.SuspendLayout()
        CType(Me.picLineInnerPaint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRectangle.SuspendLayout()
        CType(Me.picRectangleBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCircle.SuspendLayout()
        CType(Me.picCircleCenterMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCircleInnerPat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCircleLinePat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlObjectCircle.SuspendLayout()
        CType(Me.picObjCircleCenterMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picObjCircleInnerPat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picObjCircleLinePat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPoints.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picPointMark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlImage.SuspendLayout()
        CType(Me.picImageInnerColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImageFrameLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(96, 376)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 26)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "図形モード終了"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TableLayoutPanelFigMode
        '
        Me.TableLayoutPanelFigMode.ColumnCount = 4
        Me.TableLayoutPanelFigMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelFigMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelFigMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelFigMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelFigMode.Controls.Add(Me.picFigImage, 3, 1)
        Me.TableLayoutPanelFigMode.Controls.Add(Me.picFigPoint, 2, 1)
        Me.TableLayoutPanelFigMode.Controls.Add(Me.picFigLine, 2, 0)
        Me.TableLayoutPanelFigMode.Controls.Add(Me.picFigWord, 1, 0)
        Me.TableLayoutPanelFigMode.Controls.Add(Me.picFigSelect, 0, 0)
        Me.TableLayoutPanelFigMode.Controls.Add(Me.picFigObjectCircle, 1, 1)
        Me.TableLayoutPanelFigMode.Controls.Add(Me.picFigCircle, 0, 1)
        Me.TableLayoutPanelFigMode.Controls.Add(Me.picFigRectangle, 3, 0)
        Me.TableLayoutPanelFigMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelFigMode.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelFigMode.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanelFigMode.Name = "TableLayoutPanelFigMode"
        Me.TableLayoutPanelFigMode.RowCount = 2
        Me.TableLayoutPanelFigMode.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelFigMode.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelFigMode.Size = New System.Drawing.Size(182, 71)
        Me.TableLayoutPanelFigMode.TabIndex = 0
        '
        'picFigImage
        '
        Me.picFigImage.BackgroundImage = CType(resources.GetObject("picFigImage.BackgroundImage"), System.Drawing.Image)
        Me.picFigImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picFigImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFigImage.Location = New System.Drawing.Point(137, 37)
        Me.picFigImage.Margin = New System.Windows.Forms.Padding(2)
        Me.picFigImage.Name = "picFigImage"
        Me.picFigImage.Size = New System.Drawing.Size(43, 32)
        Me.picFigImage.TabIndex = 10
        Me.picFigImage.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picFigImage, "画像")
        '
        'picFigPoint
        '
        Me.picFigPoint.BackgroundImage = CType(resources.GetObject("picFigPoint.BackgroundImage"), System.Drawing.Image)
        Me.picFigPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picFigPoint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFigPoint.Location = New System.Drawing.Point(92, 37)
        Me.picFigPoint.Margin = New System.Windows.Forms.Padding(2)
        Me.picFigPoint.Name = "picFigPoint"
        Me.picFigPoint.Size = New System.Drawing.Size(41, 32)
        Me.picFigPoint.TabIndex = 9
        Me.picFigPoint.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picFigPoint, "点")
        '
        'picFigLine
        '
        Me.picFigLine.BackgroundImage = CType(resources.GetObject("picFigLine.BackgroundImage"), System.Drawing.Image)
        Me.picFigLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picFigLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFigLine.Location = New System.Drawing.Point(92, 2)
        Me.picFigLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picFigLine.Name = "picFigLine"
        Me.picFigLine.Size = New System.Drawing.Size(41, 31)
        Me.picFigLine.TabIndex = 5
        Me.picFigLine.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picFigLine, "線・多角形")
        '
        'picFigWord
        '
        Me.picFigWord.BackgroundImage = CType(resources.GetObject("picFigWord.BackgroundImage"), System.Drawing.Image)
        Me.picFigWord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picFigWord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFigWord.Location = New System.Drawing.Point(47, 2)
        Me.picFigWord.Margin = New System.Windows.Forms.Padding(2)
        Me.picFigWord.Name = "picFigWord"
        Me.picFigWord.Size = New System.Drawing.Size(41, 31)
        Me.picFigWord.TabIndex = 4
        Me.picFigWord.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picFigWord, "文字")
        '
        'picFigSelect
        '
        Me.picFigSelect.BackgroundImage = CType(resources.GetObject("picFigSelect.BackgroundImage"), System.Drawing.Image)
        Me.picFigSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picFigSelect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFigSelect.Location = New System.Drawing.Point(2, 2)
        Me.picFigSelect.Margin = New System.Windows.Forms.Padding(2)
        Me.picFigSelect.Name = "picFigSelect"
        Me.picFigSelect.Size = New System.Drawing.Size(41, 31)
        Me.picFigSelect.TabIndex = 3
        Me.picFigSelect.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picFigSelect, "図形選択")
        '
        'picFigObjectCircle
        '
        Me.picFigObjectCircle.BackgroundImage = CType(resources.GetObject("picFigObjectCircle.BackgroundImage"), System.Drawing.Image)
        Me.picFigObjectCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picFigObjectCircle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFigObjectCircle.Location = New System.Drawing.Point(47, 37)
        Me.picFigObjectCircle.Margin = New System.Windows.Forms.Padding(2)
        Me.picFigObjectCircle.Name = "picFigObjectCircle"
        Me.picFigObjectCircle.Size = New System.Drawing.Size(41, 32)
        Me.picFigObjectCircle.TabIndex = 7
        Me.picFigObjectCircle.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picFigObjectCircle, "オブジェクト円")
        '
        'picFigCircle
        '
        Me.picFigCircle.BackgroundImage = CType(resources.GetObject("picFigCircle.BackgroundImage"), System.Drawing.Image)
        Me.picFigCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picFigCircle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFigCircle.Location = New System.Drawing.Point(2, 37)
        Me.picFigCircle.Margin = New System.Windows.Forms.Padding(2)
        Me.picFigCircle.Name = "picFigCircle"
        Me.picFigCircle.Size = New System.Drawing.Size(41, 32)
        Me.picFigCircle.TabIndex = 6
        Me.picFigCircle.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picFigCircle, "円")
        '
        'picFigRectangle
        '
        Me.picFigRectangle.BackgroundImage = CType(resources.GetObject("picFigRectangle.BackgroundImage"), System.Drawing.Image)
        Me.picFigRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picFigRectangle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFigRectangle.Location = New System.Drawing.Point(137, 2)
        Me.picFigRectangle.Margin = New System.Windows.Forms.Padding(2)
        Me.picFigRectangle.Name = "picFigRectangle"
        Me.picFigRectangle.Size = New System.Drawing.Size(43, 31)
        Me.picFigRectangle.TabIndex = 8
        Me.picFigRectangle.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picFigRectangle, "四角形")
        '
        'pnlFigMode
        '
        Me.pnlFigMode.BackColor = System.Drawing.Color.White
        Me.pnlFigMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFigMode.Controls.Add(Me.TableLayoutPanelFigMode)
        Me.pnlFigMode.Location = New System.Drawing.Point(9, 10)
        Me.pnlFigMode.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlFigMode.Name = "pnlFigMode"
        Me.pnlFigMode.Size = New System.Drawing.Size(184, 73)
        Me.pnlFigMode.TabIndex = 0
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 1
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ShowAlways = True
        '
        'pnlTargetData
        '
        Me.pnlTargetData.Controls.Add(Me.cboData)
        Me.pnlTargetData.Controls.Add(Me.cboLayer)
        Me.pnlTargetData.Controls.Add(Me.Label2)
        Me.pnlTargetData.Controls.Add(Me.Label1)
        Me.pnlTargetData.Location = New System.Drawing.Point(10, 88)
        Me.pnlTargetData.Name = "pnlTargetData"
        Me.pnlTargetData.Size = New System.Drawing.Size(182, 57)
        Me.pnlTargetData.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "表示データ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "表示レイヤ"
        '
        'pnlCommon
        '
        Me.pnlCommon.Controls.Add(Me.btnEdirCancel)
        Me.pnlCommon.Controls.Add(Me.btnDelete)
        Me.pnlCommon.Controls.Add(Me.btnRegist)
        Me.pnlCommon.Controls.Add(Me.btnBack)
        Me.pnlCommon.Controls.Add(Me.btnAhead)
        Me.pnlCommon.Location = New System.Drawing.Point(10, 311)
        Me.pnlCommon.Name = "pnlCommon"
        Me.pnlCommon.Size = New System.Drawing.Size(182, 60)
        Me.pnlCommon.TabIndex = 10
        '
        'btnEdirCancel
        '
        Me.btnEdirCancel.Location = New System.Drawing.Point(118, 29)
        Me.btnEdirCancel.Name = "btnEdirCancel"
        Me.btnEdirCancel.Size = New System.Drawing.Size(61, 25)
        Me.btnEdirCancel.TabIndex = 4
        Me.btnEdirCancel.Text = "キャンセル"
        Me.btnEdirCancel.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(62, 29)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(51, 25)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnRegist
        '
        Me.btnRegist.Location = New System.Drawing.Point(2, 29)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(54, 25)
        Me.btnRegist.TabIndex = 2
        Me.btnRegist.Text = "登録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(62, 2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(51, 20)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "後ろへ"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnAhead
        '
        Me.btnAhead.Location = New System.Drawing.Point(2, 2)
        Me.btnAhead.Name = "btnAhead"
        Me.btnAhead.Size = New System.Drawing.Size(55, 20)
        Me.btnAhead.TabIndex = 0
        Me.btnAhead.Text = "前へ"
        Me.btnAhead.UseVisualStyleBackColor = True
        '
        'pnlPointting
        '
        Me.pnlPointting.Controls.Add(Me.Label3)
        Me.pnlPointting.Location = New System.Drawing.Point(198, 10)
        Me.pnlPointting.Name = "pnlPointting"
        Me.pnlPointting.Size = New System.Drawing.Size(183, 103)
        Me.pnlPointting.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "図形を選択して下さい"
        '
        'pnlWord
        '
        Me.pnlWord.Controls.Add(Me.chkWordScreenSetF)
        Me.pnlWord.Controls.Add(Me.btnWordLineUp)
        Me.pnlWord.Controls.Add(Me.chkScattered_Mode_F)
        Me.pnlWord.Controls.Add(Me.btnWordFont)
        Me.pnlWord.Controls.Add(Me.txtWord)
        Me.pnlWord.Location = New System.Drawing.Point(198, 120)
        Me.pnlWord.Name = "pnlWord"
        Me.pnlWord.Size = New System.Drawing.Size(183, 150)
        Me.pnlWord.TabIndex = 3
        '
        'btnWordLineUp
        '
        Me.btnWordLineUp.Location = New System.Drawing.Point(110, 116)
        Me.btnWordLineUp.Name = "btnWordLineUp"
        Me.btnWordLineUp.Size = New System.Drawing.Size(55, 19)
        Me.btnWordLineUp.TabIndex = 3
        Me.btnWordLineUp.Text = "整列"
        Me.btnWordLineUp.UseVisualStyleBackColor = True
        '
        'chkScattered_Mode_F
        '
        Me.chkScattered_Mode_F.AutoSize = True
        Me.chkScattered_Mode_F.Location = New System.Drawing.Point(79, 94)
        Me.chkScattered_Mode_F.Name = "chkScattered_Mode_F"
        Me.chkScattered_Mode_F.Size = New System.Drawing.Size(96, 16)
        Me.chkScattered_Mode_F.TabIndex = 2
        Me.chkScattered_Mode_F.Text = "個別位置指定"
        Me.chkScattered_Mode_F.UseVisualStyleBackColor = True
        '
        'btnWordFont
        '
        Me.btnWordFont.Location = New System.Drawing.Point(3, 95)
        Me.btnWordFont.Name = "btnWordFont"
        Me.btnWordFont.Size = New System.Drawing.Size(61, 27)
        Me.btnWordFont.TabIndex = 1
        Me.btnWordFont.Text = "フォント"
        Me.btnWordFont.UseVisualStyleBackColor = True
        '
        'txtWord
        '
        Me.txtWord.Location = New System.Drawing.Point(3, 14)
        Me.txtWord.Multiline = True
        Me.txtWord.Name = "txtWord"
        Me.txtWord.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtWord.Size = New System.Drawing.Size(177, 46)
        Me.txtWord.TabIndex = 0
        '
        'pnlLine
        '
        Me.pnlLine.Controls.Add(Me.btnLineGet)
        Me.pnlLine.Controls.Add(Me.chkLineClose)
        Me.pnlLine.Controls.Add(Me.btnLinePattern)
        Me.pnlLine.Controls.Add(Me.btnLineArrow)
        Me.pnlLine.Controls.Add(Me.picLineInnerPaint)
        Me.pnlLine.Controls.Add(Me.chkLineInnerPaint)
        Me.pnlLine.Controls.Add(Me.chkLineSpline)
        Me.pnlLine.Location = New System.Drawing.Point(386, 10)
        Me.pnlLine.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlLine.Name = "pnlLine"
        Me.pnlLine.Size = New System.Drawing.Size(183, 151)
        Me.pnlLine.TabIndex = 3
        '
        'btnLineGet
        '
        Me.btnLineGet.Location = New System.Drawing.Point(97, 106)
        Me.btnLineGet.Name = "btnLineGet"
        Me.btnLineGet.Size = New System.Drawing.Size(70, 27)
        Me.btnLineGet.TabIndex = 5
        Me.btnLineGet.Text = "線取り込み"
        Me.btnLineGet.UseVisualStyleBackColor = True
        '
        'chkLineClose
        '
        Me.chkLineClose.AutoSize = True
        Me.chkLineClose.Location = New System.Drawing.Point(10, 109)
        Me.chkLineClose.Margin = New System.Windows.Forms.Padding(2)
        Me.chkLineClose.Name = "chkLineClose"
        Me.chkLineClose.Size = New System.Drawing.Size(80, 16)
        Me.chkLineClose.TabIndex = 4
        Me.chkLineClose.Text = "閉じたライン"
        Me.chkLineClose.UseVisualStyleBackColor = True
        '
        'btnLinePattern
        '
        Me.btnLinePattern.Location = New System.Drawing.Point(97, 57)
        Me.btnLinePattern.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLinePattern.Name = "btnLinePattern"
        Me.btnLinePattern.Size = New System.Drawing.Size(70, 27)
        Me.btnLinePattern.TabIndex = 3
        Me.btnLinePattern.Text = "線種設定"
        Me.btnLinePattern.UseVisualStyleBackColor = True
        '
        'btnLineArrow
        '
        Me.btnLineArrow.Location = New System.Drawing.Point(97, 14)
        Me.btnLineArrow.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLineArrow.Name = "btnLineArrow"
        Me.btnLineArrow.Size = New System.Drawing.Size(70, 31)
        Me.btnLineArrow.TabIndex = 1
        Me.btnLineArrow.Text = "矢印設定"
        Me.btnLineArrow.UseVisualStyleBackColor = True
        '
        'picLineInnerPaint
        '
        Me.picLineInnerPaint.BackColor = System.Drawing.Color.White
        Me.picLineInnerPaint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLineInnerPaint.Location = New System.Drawing.Point(31, 76)
        Me.picLineInnerPaint.Margin = New System.Windows.Forms.Padding(2)
        Me.picLineInnerPaint.Name = "picLineInnerPaint"
        Me.picLineInnerPaint.Size = New System.Drawing.Size(48, 21)
        Me.picLineInnerPaint.TabIndex = 22
        Me.picLineInnerPaint.TabStop = False
        '
        'chkLineInnerPaint
        '
        Me.chkLineInnerPaint.AutoSize = True
        Me.chkLineInnerPaint.Location = New System.Drawing.Point(10, 57)
        Me.chkLineInnerPaint.Margin = New System.Windows.Forms.Padding(2)
        Me.chkLineInnerPaint.Name = "chkLineInnerPaint"
        Me.chkLineInnerPaint.Size = New System.Drawing.Size(72, 16)
        Me.chkLineInnerPaint.TabIndex = 2
        Me.chkLineInnerPaint.Text = "塗りつぶし"
        Me.chkLineInnerPaint.UseVisualStyleBackColor = True
        '
        'chkLineSpline
        '
        Me.chkLineSpline.AutoSize = True
        Me.chkLineSpline.Location = New System.Drawing.Point(10, 16)
        Me.chkLineSpline.Margin = New System.Windows.Forms.Padding(2)
        Me.chkLineSpline.Name = "chkLineSpline"
        Me.chkLineSpline.Size = New System.Drawing.Size(72, 16)
        Me.chkLineSpline.TabIndex = 0
        Me.chkLineSpline.Text = "曲線近似"
        Me.chkLineSpline.UseVisualStyleBackColor = True
        '
        'pnlRectangle
        '
        Me.pnlRectangle.Controls.Add(Me.picRectangleBox)
        Me.pnlRectangle.Location = New System.Drawing.Point(386, 183)
        Me.pnlRectangle.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlRectangle.Name = "pnlRectangle"
        Me.pnlRectangle.Size = New System.Drawing.Size(182, 86)
        Me.pnlRectangle.TabIndex = 5
        '
        'picRectangleBox
        '
        Me.picRectangleBox.BackColor = System.Drawing.Color.White
        Me.picRectangleBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picRectangleBox.Location = New System.Drawing.Point(64, 24)
        Me.picRectangleBox.Margin = New System.Windows.Forms.Padding(2)
        Me.picRectangleBox.Name = "picRectangleBox"
        Me.picRectangleBox.Size = New System.Drawing.Size(48, 42)
        Me.picRectangleBox.TabIndex = 23
        Me.picRectangleBox.TabStop = False
        '
        'pnlCircle
        '
        Me.pnlCircle.Controls.Add(Me.picCircleCenterMark)
        Me.pnlCircle.Controls.Add(Me.chkCircleCenterMark)
        Me.pnlCircle.Controls.Add(Me.picCircleInnerPat)
        Me.pnlCircle.Controls.Add(Me.Label9)
        Me.pnlCircle.Controls.Add(Me.picCircleLinePat)
        Me.pnlCircle.Controls.Add(Me.Label8)
        Me.pnlCircle.Controls.Add(Me.txtCircleAngle)
        Me.pnlCircle.Controls.Add(Me.txtCircleAxisDistance1)
        Me.pnlCircle.Controls.Add(Me.txtCircleAxisDistance0)
        Me.pnlCircle.Controls.Add(Me.Label7)
        Me.pnlCircle.Controls.Add(Me.Label6)
        Me.pnlCircle.Controls.Add(Me.lblCircleScaleUnit1)
        Me.pnlCircle.Controls.Add(Me.lblCircleScaleUnit0)
        Me.pnlCircle.Controls.Add(Me.Label5)
        Me.pnlCircle.Controls.Add(Me.Label4)
        Me.pnlCircle.Location = New System.Drawing.Point(584, 10)
        Me.pnlCircle.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCircle.Name = "pnlCircle"
        Me.pnlCircle.Size = New System.Drawing.Size(184, 155)
        Me.pnlCircle.TabIndex = 6
        '
        'picCircleCenterMark
        '
        Me.picCircleCenterMark.BackColor = System.Drawing.Color.White
        Me.picCircleCenterMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCircleCenterMark.Location = New System.Drawing.Point(118, 127)
        Me.picCircleCenterMark.Margin = New System.Windows.Forms.Padding(2)
        Me.picCircleCenterMark.Name = "picCircleCenterMark"
        Me.picCircleCenterMark.Size = New System.Drawing.Size(31, 21)
        Me.picCircleCenterMark.TabIndex = 27
        Me.picCircleCenterMark.TabStop = False
        '
        'chkCircleCenterMark
        '
        Me.chkCircleCenterMark.AutoSize = True
        Me.chkCircleCenterMark.Location = New System.Drawing.Point(40, 131)
        Me.chkCircleCenterMark.Margin = New System.Windows.Forms.Padding(2)
        Me.chkCircleCenterMark.Name = "chkCircleCenterMark"
        Me.chkCircleCenterMark.Size = New System.Drawing.Size(84, 16)
        Me.chkCircleCenterMark.TabIndex = 26
        Me.chkCircleCenterMark.Text = "中心点表示"
        Me.chkCircleCenterMark.UseVisualStyleBackColor = True
        '
        'picCircleInnerPat
        '
        Me.picCircleInnerPat.BackColor = System.Drawing.Color.White
        Me.picCircleInnerPat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCircleInnerPat.Location = New System.Drawing.Point(102, 104)
        Me.picCircleInnerPat.Margin = New System.Windows.Forms.Padding(2)
        Me.picCircleInnerPat.Name = "picCircleInnerPat"
        Me.picCircleInnerPat.Size = New System.Drawing.Size(48, 21)
        Me.picCircleInnerPat.TabIndex = 25
        Me.picCircleInnerPat.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(34, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 12)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "内部パターン"
        '
        'picCircleLinePat
        '
        Me.picCircleLinePat.BackColor = System.Drawing.Color.White
        Me.picCircleLinePat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCircleLinePat.Location = New System.Drawing.Point(102, 81)
        Me.picCircleLinePat.Margin = New System.Windows.Forms.Padding(2)
        Me.picCircleLinePat.Name = "picCircleLinePat"
        Me.picCircleLinePat.Size = New System.Drawing.Size(48, 21)
        Me.picCircleLinePat.TabIndex = 23
        Me.picCircleLinePat.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(34, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 12)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "ラインパターン"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(142, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "°"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "回転角度"
        '
        'lblCircleScaleUnit1
        '
        Me.lblCircleScaleUnit1.AutoSize = True
        Me.lblCircleScaleUnit1.Location = New System.Drawing.Point(142, 42)
        Me.lblCircleScaleUnit1.Name = "lblCircleScaleUnit1"
        Me.lblCircleScaleUnit1.Size = New System.Drawing.Size(20, 12)
        Me.lblCircleScaleUnit1.TabIndex = 6
        Me.lblCircleScaleUnit1.Text = "km"
        '
        'lblCircleScaleUnit0
        '
        Me.lblCircleScaleUnit0.AutoSize = True
        Me.lblCircleScaleUnit0.Location = New System.Drawing.Point(142, 18)
        Me.lblCircleScaleUnit0.Name = "lblCircleScaleUnit0"
        Me.lblCircleScaleUnit0.Size = New System.Drawing.Size(20, 12)
        Me.lblCircleScaleUnit0.TabIndex = 5
        Me.lblCircleScaleUnit0.Text = "km"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "青軸"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "赤軸"
        '
        'pnlObjectCircle
        '
        Me.pnlObjectCircle.Controls.Add(Me.lbObjCircleObject)
        Me.pnlObjectCircle.Controls.Add(Me.picObjCircleCenterMark)
        Me.pnlObjectCircle.Controls.Add(Me.chkObjCircleCenterMark)
        Me.pnlObjectCircle.Controls.Add(Me.picObjCircleInnerPat)
        Me.pnlObjectCircle.Controls.Add(Me.Label10)
        Me.pnlObjectCircle.Controls.Add(Me.picObjCircleLinePat)
        Me.pnlObjectCircle.Controls.Add(Me.Label11)
        Me.pnlObjectCircle.Controls.Add(Me.txtObjCircleRadius)
        Me.pnlObjectCircle.Controls.Add(Me.lblObjCircleScaleUnit)
        Me.pnlObjectCircle.Controls.Add(Me.Label13)
        Me.pnlObjectCircle.Location = New System.Drawing.Point(780, 10)
        Me.pnlObjectCircle.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlObjectCircle.Name = "pnlObjectCircle"
        Me.pnlObjectCircle.Size = New System.Drawing.Size(182, 155)
        Me.pnlObjectCircle.TabIndex = 7
        '
        'picObjCircleCenterMark
        '
        Me.picObjCircleCenterMark.BackColor = System.Drawing.Color.White
        Me.picObjCircleCenterMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picObjCircleCenterMark.Location = New System.Drawing.Point(152, 130)
        Me.picObjCircleCenterMark.Margin = New System.Windows.Forms.Padding(2)
        Me.picObjCircleCenterMark.Name = "picObjCircleCenterMark"
        Me.picObjCircleCenterMark.Size = New System.Drawing.Size(26, 21)
        Me.picObjCircleCenterMark.TabIndex = 36
        Me.picObjCircleCenterMark.TabStop = False
        '
        'chkObjCircleCenterMark
        '
        Me.chkObjCircleCenterMark.AutoSize = True
        Me.chkObjCircleCenterMark.Location = New System.Drawing.Point(92, 133)
        Me.chkObjCircleCenterMark.Margin = New System.Windows.Forms.Padding(2)
        Me.chkObjCircleCenterMark.Name = "chkObjCircleCenterMark"
        Me.chkObjCircleCenterMark.Size = New System.Drawing.Size(60, 16)
        Me.chkObjCircleCenterMark.TabIndex = 35
        Me.chkObjCircleCenterMark.Text = "中心点"
        Me.chkObjCircleCenterMark.UseVisualStyleBackColor = True
        '
        'picObjCircleInnerPat
        '
        Me.picObjCircleInnerPat.BackColor = System.Drawing.Color.White
        Me.picObjCircleInnerPat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picObjCircleInnerPat.Location = New System.Drawing.Point(33, 130)
        Me.picObjCircleInnerPat.Margin = New System.Windows.Forms.Padding(2)
        Me.picObjCircleInnerPat.Name = "picObjCircleInnerPat"
        Me.picObjCircleInnerPat.Size = New System.Drawing.Size(33, 21)
        Me.picObjCircleInnerPat.TabIndex = 34
        Me.picObjCircleInnerPat.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(-1, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "内部"
        '
        'picObjCircleLinePat
        '
        Me.picObjCircleLinePat.BackColor = System.Drawing.Color.White
        Me.picObjCircleLinePat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picObjCircleLinePat.Location = New System.Drawing.Point(33, 106)
        Me.picObjCircleLinePat.Margin = New System.Windows.Forms.Padding(2)
        Me.picObjCircleLinePat.Name = "picObjCircleLinePat"
        Me.picObjCircleLinePat.Size = New System.Drawing.Size(33, 21)
        Me.picObjCircleLinePat.TabIndex = 32
        Me.picObjCircleLinePat.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(0, 108)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 12)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "線種"
        '
        'lblObjCircleScaleUnit
        '
        Me.lblObjCircleScaleUnit.AutoSize = True
        Me.lblObjCircleScaleUnit.Location = New System.Drawing.Point(162, 108)
        Me.lblObjCircleScaleUnit.Name = "lblObjCircleScaleUnit"
        Me.lblObjCircleScaleUnit.Size = New System.Drawing.Size(20, 12)
        Me.lblObjCircleScaleUnit.TabIndex = 29
        Me.lblObjCircleScaleUnit.Text = "km"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(70, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 12)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "半径"
        '
        'pnlPoints
        '
        Me.pnlPoints.Controls.Add(Me.lblPointNumber)
        Me.pnlPoints.Controls.Add(Me.btnPointGet)
        Me.pnlPoints.Controls.Add(Me.GroupBox1)
        Me.pnlPoints.Controls.Add(Me.picPointMark)
        Me.pnlPoints.Location = New System.Drawing.Point(780, 174)
        Me.pnlPoints.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlPoints.Name = "pnlPoints"
        Me.pnlPoints.Size = New System.Drawing.Size(182, 158)
        Me.pnlPoints.TabIndex = 8
        '
        'lblPointNumber
        '
        Me.lblPointNumber.AutoSize = True
        Me.lblPointNumber.Location = New System.Drawing.Point(70, 13)
        Me.lblPointNumber.Name = "lblPointNumber"
        Me.lblPointNumber.Size = New System.Drawing.Size(59, 12)
        Me.lblPointNumber.TabIndex = 0
        Me.lblPointNumber.Text = "ポイント数："
        '
        'btnPointGet
        '
        Me.btnPointGet.Location = New System.Drawing.Point(86, 33)
        Me.btnPointGet.Name = "btnPointGet"
        Me.btnPointGet.Size = New System.Drawing.Size(78, 21)
        Me.btnPointGet.TabIndex = 1
        Me.btnPointGet.Text = "点取り込み"
        Me.btnPointGet.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPointLegend)
        Me.GroupBox1.Controls.Add(Me.btnPointLegendFont)
        Me.GroupBox1.Controls.Add(Me.chkPointLegend)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 70)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(148, 69)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "凡例"
        '
        'txtPointLegend
        '
        Me.txtPointLegend.Location = New System.Drawing.Point(57, 17)
        Me.txtPointLegend.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPointLegend.Name = "txtPointLegend"
        Me.txtPointLegend.Size = New System.Drawing.Size(88, 19)
        Me.txtPointLegend.TabIndex = 0
        '
        'btnPointLegendFont
        '
        Me.btnPointLegendFont.Location = New System.Drawing.Point(82, 40)
        Me.btnPointLegendFont.Name = "btnPointLegendFont"
        Me.btnPointLegendFont.Size = New System.Drawing.Size(61, 21)
        Me.btnPointLegendFont.TabIndex = 1
        Me.btnPointLegendFont.Text = "フォント"
        Me.btnPointLegendFont.UseVisualStyleBackColor = True
        '
        'chkPointLegend
        '
        Me.chkPointLegend.AutoSize = True
        Me.chkPointLegend.Location = New System.Drawing.Point(8, 17)
        Me.chkPointLegend.Margin = New System.Windows.Forms.Padding(2)
        Me.chkPointLegend.Name = "chkPointLegend"
        Me.chkPointLegend.Size = New System.Drawing.Size(48, 16)
        Me.chkPointLegend.TabIndex = 2
        Me.chkPointLegend.Text = "表示"
        Me.chkPointLegend.UseVisualStyleBackColor = True
        '
        'picPointMark
        '
        Me.picPointMark.BackColor = System.Drawing.Color.White
        Me.picPointMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPointMark.Location = New System.Drawing.Point(15, 13)
        Me.picPointMark.Margin = New System.Windows.Forms.Padding(2)
        Me.picPointMark.Name = "picPointMark"
        Me.picPointMark.Size = New System.Drawing.Size(48, 42)
        Me.picPointMark.TabIndex = 24
        Me.picPointMark.TabStop = False
        '
        'pnlImage
        '
        Me.pnlImage.Controls.Add(Me.btnImageAlphaValue)
        Me.pnlImage.Controls.Add(Me.picImageInnerColor)
        Me.pnlImage.Controls.Add(Me.chkImageChangeInnerColor)
        Me.pnlImage.Controls.Add(Me.txtImageAngle)
        Me.pnlImage.Controls.Add(Me.Label16)
        Me.pnlImage.Controls.Add(Me.Label17)
        Me.pnlImage.Controls.Add(Me.chkImageMapBack)
        Me.pnlImage.Controls.Add(Me.picImageFrameLine)
        Me.pnlImage.Controls.Add(Me.Label15)
        Me.pnlImage.Controls.Add(Me.btnImageSelect)
        Me.pnlImage.Location = New System.Drawing.Point(10, 150)
        Me.pnlImage.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(182, 156)
        Me.pnlImage.TabIndex = 9
        '
        'btnImageAlphaValue
        '
        Me.btnImageAlphaValue.Location = New System.Drawing.Point(18, 111)
        Me.btnImageAlphaValue.Margin = New System.Windows.Forms.Padding(2)
        Me.btnImageAlphaValue.Name = "btnImageAlphaValue"
        Me.btnImageAlphaValue.Size = New System.Drawing.Size(70, 21)
        Me.btnImageAlphaValue.TabIndex = 41
        Me.btnImageAlphaValue.Text = "透過度"
        Me.btnImageAlphaValue.UseVisualStyleBackColor = True
        '
        'picImageInnerColor
        '
        Me.picImageInnerColor.BackColor = System.Drawing.Color.White
        Me.picImageInnerColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picImageInnerColor.Location = New System.Drawing.Point(110, 84)
        Me.picImageInnerColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picImageInnerColor.Name = "picImageInnerColor"
        Me.picImageInnerColor.Size = New System.Drawing.Size(38, 21)
        Me.picImageInnerColor.TabIndex = 40
        Me.picImageInnerColor.TabStop = False
        '
        'chkImageChangeInnerColor
        '
        Me.chkImageChangeInnerColor.AutoSize = True
        Me.chkImageChangeInnerColor.Location = New System.Drawing.Point(18, 85)
        Me.chkImageChangeInnerColor.Margin = New System.Windows.Forms.Padding(2)
        Me.chkImageChangeInnerColor.Name = "chkImageChangeInnerColor"
        Me.chkImageChangeInnerColor.Size = New System.Drawing.Size(94, 16)
        Me.chkImageChangeInnerColor.TabIndex = 39
        Me.chkImageChangeInnerColor.Text = "内部色の変更"
        Me.chkImageChangeInnerColor.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(128, 63)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(17, 12)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "°"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(16, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 12)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "回転角度"
        '
        'chkImageMapBack
        '
        Me.chkImageMapBack.AutoSize = True
        Me.chkImageMapBack.Location = New System.Drawing.Point(18, 137)
        Me.chkImageMapBack.Margin = New System.Windows.Forms.Padding(2)
        Me.chkImageMapBack.Name = "chkImageMapBack"
        Me.chkImageMapBack.Size = New System.Drawing.Size(110, 16)
        Me.chkImageMapBack.TabIndex = 35
        Me.chkImageMapBack.Text = "地図の背景にする"
        Me.chkImageMapBack.UseVisualStyleBackColor = True
        '
        'picImageFrameLine
        '
        Me.picImageFrameLine.BackColor = System.Drawing.Color.White
        Me.picImageFrameLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picImageFrameLine.Location = New System.Drawing.Point(74, 34)
        Me.picImageFrameLine.Margin = New System.Windows.Forms.Padding(2)
        Me.picImageFrameLine.Name = "picImageFrameLine"
        Me.picImageFrameLine.Size = New System.Drawing.Size(38, 21)
        Me.picImageFrameLine.TabIndex = 34
        Me.picImageFrameLine.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 12)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "枠線種"
        '
        'btnImageSelect
        '
        Me.btnImageSelect.Location = New System.Drawing.Point(17, 0)
        Me.btnImageSelect.Name = "btnImageSelect"
        Me.btnImageSelect.Size = New System.Drawing.Size(61, 27)
        Me.btnImageSelect.TabIndex = 20
        Me.btnImageSelect.Text = "画像選択"
        Me.btnImageSelect.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(9, 376)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(30, 21)
        Me.btnHelp.TabIndex = 12
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'txtImageAngle
        '
        Me.txtImageAngle.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtImageAngle.Location = New System.Drawing.Point(74, 58)
        Me.txtImageAngle.Margin = New System.Windows.Forms.Padding(2)
        Me.txtImageAngle.MaxValue = 0.0R
        Me.txtImageAngle.MaxValueFlag = False
        Me.txtImageAngle.MinValue = 0.0R
        Me.txtImageAngle.MinValueFlag = False
        Me.txtImageAngle.Name = "txtImageAngle"
        Me.txtImageAngle.NumberPoint = True
        Me.txtImageAngle.Size = New System.Drawing.Size(49, 19)
        Me.txtImageAngle.TabIndex = 38
        Me.txtImageAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImageAngle.ValueErrorMessageFlag = True
        '
        'lbObjCircleObject
        '
        Me.lbObjCircleObject.AsteriskSelectEnabled = False
        Me.lbObjCircleObject.FormattingEnabled = True
        Me.lbObjCircleObject.ItemHeight = 12
        Me.lbObjCircleObject.Location = New System.Drawing.Point(22, 10)
        Me.lbObjCircleObject.Margin = New System.Windows.Forms.Padding(2)
        Me.lbObjCircleObject.Name = "lbObjCircleObject"
        Me.lbObjCircleObject.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbObjCircleObject.Size = New System.Drawing.Size(135, 88)
        Me.lbObjCircleObject.TabIndex = 0
        '
        'txtObjCircleRadius
        '
        Me.txtObjCircleRadius.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtObjCircleRadius.Location = New System.Drawing.Point(100, 106)
        Me.txtObjCircleRadius.Margin = New System.Windows.Forms.Padding(2)
        Me.txtObjCircleRadius.MaxValue = 0.0R
        Me.txtObjCircleRadius.MaxValueFlag = False
        Me.txtObjCircleRadius.MinValue = 0.0R
        Me.txtObjCircleRadius.MinValueFlag = False
        Me.txtObjCircleRadius.Name = "txtObjCircleRadius"
        Me.txtObjCircleRadius.NumberPoint = True
        Me.txtObjCircleRadius.Size = New System.Drawing.Size(57, 19)
        Me.txtObjCircleRadius.TabIndex = 1
        Me.txtObjCircleRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtObjCircleRadius.ValueErrorMessageFlag = True
        '
        'txtCircleAngle
        '
        Me.txtCircleAngle.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtCircleAngle.Location = New System.Drawing.Point(88, 58)
        Me.txtCircleAngle.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCircleAngle.MaxValue = 0.0R
        Me.txtCircleAngle.MaxValueFlag = False
        Me.txtCircleAngle.MinValue = 0.0R
        Me.txtCircleAngle.MinValueFlag = False
        Me.txtCircleAngle.Name = "txtCircleAngle"
        Me.txtCircleAngle.NumberPoint = True
        Me.txtCircleAngle.Size = New System.Drawing.Size(49, 19)
        Me.txtCircleAngle.TabIndex = 11
        Me.txtCircleAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCircleAngle.ValueErrorMessageFlag = True
        '
        'txtCircleAxisDistance1
        '
        Me.txtCircleAxisDistance1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtCircleAxisDistance1.Location = New System.Drawing.Point(67, 35)
        Me.txtCircleAxisDistance1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCircleAxisDistance1.MaxValue = 0.0R
        Me.txtCircleAxisDistance1.MaxValueFlag = False
        Me.txtCircleAxisDistance1.MinValue = 0.0R
        Me.txtCircleAxisDistance1.MinValueFlag = False
        Me.txtCircleAxisDistance1.Name = "txtCircleAxisDistance1"
        Me.txtCircleAxisDistance1.NumberPoint = True
        Me.txtCircleAxisDistance1.Size = New System.Drawing.Size(71, 19)
        Me.txtCircleAxisDistance1.TabIndex = 10
        Me.txtCircleAxisDistance1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCircleAxisDistance1.ValueErrorMessageFlag = True
        '
        'txtCircleAxisDistance0
        '
        Me.txtCircleAxisDistance0.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtCircleAxisDistance0.Location = New System.Drawing.Point(67, 13)
        Me.txtCircleAxisDistance0.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCircleAxisDistance0.MaxValue = 0.0R
        Me.txtCircleAxisDistance0.MaxValueFlag = False
        Me.txtCircleAxisDistance0.MinValue = 0.0R
        Me.txtCircleAxisDistance0.MinValueFlag = False
        Me.txtCircleAxisDistance0.Name = "txtCircleAxisDistance0"
        Me.txtCircleAxisDistance0.NumberPoint = True
        Me.txtCircleAxisDistance0.Size = New System.Drawing.Size(71, 19)
        Me.txtCircleAxisDistance0.TabIndex = 9
        Me.txtCircleAxisDistance0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCircleAxisDistance0.ValueErrorMessageFlag = True
        '
        'cboData
        '
        Me.cboData.AsteriskSelectEnabled = False
        Me.cboData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboData.FormattingEnabled = True
        Me.cboData.IntegralHeight = False
        Me.cboData.Location = New System.Drawing.Point(66, 32)
        Me.cboData.Name = "cboData"
        Me.cboData.Size = New System.Drawing.Size(113, 20)
        Me.cboData.TabIndex = 3
        '
        'cboLayer
        '
        Me.cboLayer.AsteriskSelectEnabled = False
        Me.cboLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayer.FormattingEnabled = True
        Me.cboLayer.IntegralHeight = False
        Me.cboLayer.Location = New System.Drawing.Point(66, 6)
        Me.cboLayer.Name = "cboLayer"
        Me.cboLayer.Size = New System.Drawing.Size(113, 20)
        Me.cboLayer.TabIndex = 2
        '
        'chkWordScreenSetF
        '
        Me.chkWordScreenSetF.AutoSize = True
        Me.chkWordScreenSetF.Location = New System.Drawing.Point(3, 70)
        Me.chkWordScreenSetF.Name = "chkWordScreenSetF"
        Me.chkWordScreenSetF.Size = New System.Drawing.Size(81, 16)
        Me.chkWordScreenSetF.TabIndex = 4
        Me.chkWordScreenSetF.Text = "画面に固定"
        Me.chkWordScreenSetF.UseVisualStyleBackColor = True
        '
        'frmPrint_Figure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(980, 409)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.pnlImage)
        Me.Controls.Add(Me.pnlObjectCircle)
        Me.Controls.Add(Me.pnlCircle)
        Me.Controls.Add(Me.pnlPoints)
        Me.Controls.Add(Me.pnlRectangle)
        Me.Controls.Add(Me.pnlLine)
        Me.Controls.Add(Me.pnlWord)
        Me.Controls.Add(Me.pnlPointting)
        Me.Controls.Add(Me.pnlCommon)
        Me.Controls.Add(Me.pnlTargetData)
        Me.Controls.Add(Me.pnlFigMode)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_Figure"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "図形編集パネル"
        Me.TableLayoutPanelFigMode.ResumeLayout(False)
        CType(Me.picFigImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFigPoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFigLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFigWord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFigSelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFigObjectCircle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFigCircle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFigRectangle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFigMode.ResumeLayout(False)
        Me.pnlTargetData.ResumeLayout(False)
        Me.pnlTargetData.PerformLayout()
        Me.pnlCommon.ResumeLayout(False)
        Me.pnlPointting.ResumeLayout(False)
        Me.pnlPointting.PerformLayout()
        Me.pnlWord.ResumeLayout(False)
        Me.pnlWord.PerformLayout()
        Me.pnlLine.ResumeLayout(False)
        Me.pnlLine.PerformLayout()
        CType(Me.picLineInnerPaint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRectangle.ResumeLayout(False)
        CType(Me.picRectangleBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCircle.ResumeLayout(False)
        Me.pnlCircle.PerformLayout()
        CType(Me.picCircleCenterMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCircleInnerPat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCircleLinePat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlObjectCircle.ResumeLayout(False)
        Me.pnlObjectCircle.PerformLayout()
        CType(Me.picObjCircleCenterMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picObjCircleInnerPat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picObjCircleLinePat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPoints.ResumeLayout(False)
        Me.pnlPoints.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picPointMark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlImage.ResumeLayout(False)
        Me.pnlImage.PerformLayout()
        CType(Me.picImageInnerColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImageFrameLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanelFigMode As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picFigSelect As System.Windows.Forms.PictureBox
    Friend WithEvents pnlFigMode As System.Windows.Forms.Panel
    Friend WithEvents picFigLine As System.Windows.Forms.PictureBox
    Friend WithEvents picFigWord As System.Windows.Forms.PictureBox
    Friend WithEvents picFigRectangle As System.Windows.Forms.PictureBox
    Friend WithEvents picFigObjectCircle As System.Windows.Forms.PictureBox
    Friend WithEvents picFigCircle As System.Windows.Forms.PictureBox
    Friend WithEvents picFigImage As System.Windows.Forms.PictureBox
    Friend WithEvents picFigPoint As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlTargetData As System.Windows.Forms.Panel
    Friend WithEvents cboData As mandara10.ComboBoxEx
    Friend WithEvents cboLayer As mandara10.ComboBoxEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlCommon As System.Windows.Forms.Panel
    Friend WithEvents btnEdirCancel As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnAhead As System.Windows.Forms.Button
    Friend WithEvents pnlPointting As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlWord As System.Windows.Forms.Panel
    Friend WithEvents chkScattered_Mode_F As System.Windows.Forms.CheckBox
    Friend WithEvents btnWordFont As System.Windows.Forms.Button
    Friend WithEvents txtWord As System.Windows.Forms.TextBox
    Friend WithEvents btnWordLineUp As System.Windows.Forms.Button
    Friend WithEvents pnlLine As System.Windows.Forms.Panel
    Friend WithEvents chkLineInnerPaint As System.Windows.Forms.CheckBox
    Friend WithEvents chkLineSpline As System.Windows.Forms.CheckBox
    Friend WithEvents chkLineClose As System.Windows.Forms.CheckBox
    Friend WithEvents btnLinePattern As System.Windows.Forms.Button
    Friend WithEvents btnLineArrow As System.Windows.Forms.Button
    Friend WithEvents picLineInnerPaint As System.Windows.Forms.PictureBox
    Friend WithEvents pnlRectangle As System.Windows.Forms.Panel
    Friend WithEvents picRectangleBox As System.Windows.Forms.PictureBox
    Friend WithEvents pnlCircle As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCircleScaleUnit1 As System.Windows.Forms.Label
    Friend WithEvents lblCircleScaleUnit0 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents picCircleCenterMark As System.Windows.Forms.PictureBox
    Friend WithEvents chkCircleCenterMark As System.Windows.Forms.CheckBox
    Friend WithEvents picCircleInnerPat As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents picCircleLinePat As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCircleAngle As mandara10.TextNumberBox
    Friend WithEvents txtCircleAxisDistance1 As mandara10.TextNumberBox
    Friend WithEvents txtCircleAxisDistance0 As mandara10.TextNumberBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlObjectCircle As System.Windows.Forms.Panel
    Friend WithEvents lbObjCircleObject As mandara10.ListBoxEx
    Friend WithEvents picObjCircleCenterMark As System.Windows.Forms.PictureBox
    Friend WithEvents chkObjCircleCenterMark As System.Windows.Forms.CheckBox
    Friend WithEvents picObjCircleInnerPat As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents picObjCircleLinePat As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtObjCircleRadius As mandara10.TextNumberBox
    Friend WithEvents lblObjCircleScaleUnit As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlPoints As System.Windows.Forms.Panel
    Friend WithEvents pnlImage As System.Windows.Forms.Panel
    Friend WithEvents lblPointNumber As System.Windows.Forms.Label
    Friend WithEvents btnPointGet As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPointLegend As System.Windows.Forms.TextBox
    Friend WithEvents btnPointLegendFont As System.Windows.Forms.Button
    Friend WithEvents chkPointLegend As System.Windows.Forms.CheckBox
    Friend WithEvents picPointMark As System.Windows.Forms.PictureBox
    Friend WithEvents btnLineGet As System.Windows.Forms.Button
    Friend WithEvents picImageInnerColor As System.Windows.Forms.PictureBox
    Friend WithEvents chkImageChangeInnerColor As System.Windows.Forms.CheckBox
    Friend WithEvents txtImageAngle As mandara10.TextNumberBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkImageMapBack As System.Windows.Forms.CheckBox
    Friend WithEvents picImageFrameLine As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnImageSelect As System.Windows.Forms.Button
    Friend WithEvents btnImageAlphaValue As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents chkWordScreenSetF As System.Windows.Forms.CheckBox
End Class
