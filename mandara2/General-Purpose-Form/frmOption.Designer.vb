<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOption
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
        Me.Panel = New System.Windows.Forms.Panel()
        Me.pnlOption = New System.Windows.Forms.Panel()
        Me.chkAntiAlias = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cboDefProjection = New mandara10.ComboBoxEx()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tracBarBackImageSpeed = New System.Windows.Forms.TrackBar()
        Me.lblLine2 = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.cboCompassSize = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.picCompass = New System.Windows.Forms.PictureBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rbMapFolderLastSelected = New System.Windows.Forms.RadioButton()
        Me.rbMapFolderMAP = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rbLatLonDecimal = New System.Windows.Forms.RadioButton()
        Me.rbLatLonDMS = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboBaseFont = New mandara10.ComboBoxEx()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbKatakanaCheck = New System.Windows.Forms.CheckBox()
        Me.ktGridCompatibleCharacter = New KTGISUserControl.KTGISGrid()
        Me.cbSinKyuCharacter = New System.Windows.Forms.CheckBox()
        Me.btnDeleteCompatibleCharacter = New System.Windows.Forms.Button()
        Me.btnAddCompatibleCharacter = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboObjectNameSize = New System.Windows.Forms.ComboBox()
        Me.txtMEDObjectNameMaxNumber = New mandara10.TextBoxFocusAllSelect()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.picMED_ObjectNameColor = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.picMED_LineColor = New System.Windows.Forms.PictureBox()
        Me.picMED_LineColorSelected = New System.Windows.Forms.PictureBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.picMED_LineColorPoints = New System.Windows.Forms.PictureBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.picMED_ObjectTimeLineColor = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picMED_ObjectLineColorDisabled = New System.Windows.Forms.PictureBox()
        Me.picMED_ObjectLineColor = New System.Windows.Forms.PictureBox()
        Me.picMED_LineColorDisabled = New System.Windows.Forms.PictureBox()
        Me.picMED_Backcolor = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.cboDefoHanreiColor = New mandara10.ComboBoxEx()
        Me.Panel.SuspendLayout()
        Me.pnlOption.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.tracBarBackImageSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        CType(Me.picCompass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picMED_ObjectNameColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picMED_LineColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMED_LineColorSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMED_LineColorPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMED_ObjectTimeLineColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMED_ObjectLineColorDisabled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMED_ObjectLineColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMED_LineColorDisabled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMED_Backcolor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(259, 373)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(340, 373)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 24)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Panel
        '
        Me.Panel.AutoScroll = True
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.pnlOption)
        Me.Panel.Location = New System.Drawing.Point(9, 9)
        Me.Panel.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(417, 347)
        Me.Panel.TabIndex = 0
        '
        'pnlOption
        '
        Me.pnlOption.BackColor = System.Drawing.Color.White
        Me.pnlOption.Controls.Add(Me.GroupBox8)
        Me.pnlOption.Controls.Add(Me.chkAntiAlias)
        Me.pnlOption.Controls.Add(Me.GroupBox7)
        Me.pnlOption.Controls.Add(Me.GroupBox10)
        Me.pnlOption.Controls.Add(Me.lblLine2)
        Me.pnlOption.Controls.Add(Me.GroupBox9)
        Me.pnlOption.Controls.Add(Me.GroupBox6)
        Me.pnlOption.Controls.Add(Me.GroupBox5)
        Me.pnlOption.Controls.Add(Me.GroupBox4)
        Me.pnlOption.Controls.Add(Me.GroupBox3)
        Me.pnlOption.Controls.Add(Me.Label12)
        Me.pnlOption.Controls.Add(Me.GroupBox2)
        Me.pnlOption.Controls.Add(Me.Label1)
        Me.pnlOption.Controls.Add(Me.GroupBox1)
        Me.pnlOption.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOption.Location = New System.Drawing.Point(0, 0)
        Me.pnlOption.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlOption.Name = "pnlOption"
        Me.pnlOption.Size = New System.Drawing.Size(396, 755)
        Me.pnlOption.TabIndex = 0
        '
        'chkAntiAlias
        '
        Me.chkAntiAlias.Location = New System.Drawing.Point(10, 372)
        Me.chkAntiAlias.Name = "chkAntiAlias"
        Me.chkAntiAlias.Size = New System.Drawing.Size(182, 26)
        Me.chkAntiAlias.TabIndex = 15
        Me.chkAntiAlias.Text = "出力画面のアンチエイリアス処理"
        Me.chkAntiAlias.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cboDefProjection)
        Me.GroupBox7.Location = New System.Drawing.Point(9, 314)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(181, 52)
        Me.GroupBox7.TabIndex = 14
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "デフォルト地図投影法"
        '
        'cboDefProjection
        '
        Me.cboDefProjection.AsteriskSelectEnabled = False
        Me.cboDefProjection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefProjection.FormattingEnabled = True
        Me.cboDefProjection.IntegralHeight = False
        Me.cboDefProjection.Location = New System.Drawing.Point(16, 19)
        Me.cboDefProjection.MaxDropDownItems = 20
        Me.cboDefProjection.Name = "cboDefProjection"
        Me.cboDefProjection.Size = New System.Drawing.Size(147, 20)
        Me.cboDefProjection.TabIndex = 1
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Label20)
        Me.GroupBox10.Controls.Add(Me.Label19)
        Me.GroupBox10.Controls.Add(Me.tracBarBackImageSpeed)
        Me.GroupBox10.Location = New System.Drawing.Point(11, 232)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(181, 76)
        Me.GroupBox10.TabIndex = 13
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "背景画像の表示速度"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(133, 34)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(47, 12)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "遅い(密)"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(4, 34)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 12)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "速い(疎)"
        '
        'tracBarBackImageSpeed
        '
        Me.tracBarBackImageSpeed.Location = New System.Drawing.Point(46, 26)
        Me.tracBarBackImageSpeed.Margin = New System.Windows.Forms.Padding(2)
        Me.tracBarBackImageSpeed.Maximum = 6
        Me.tracBarBackImageSpeed.Minimum = 1
        Me.tracBarBackImageSpeed.Name = "tracBarBackImageSpeed"
        Me.tracBarBackImageSpeed.Size = New System.Drawing.Size(88, 45)
        Me.tracBarBackImageSpeed.TabIndex = 0
        Me.tracBarBackImageSpeed.Value = 1
        '
        'lblLine2
        '
        Me.lblLine2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLine2.Location = New System.Drawing.Point(9, 401)
        Me.lblLine2.Name = "lblLine2"
        Me.lblLine2.Size = New System.Drawing.Size(379, 1)
        Me.lblLine2.TabIndex = 6
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.cboCompassSize)
        Me.GroupBox9.Controls.Add(Me.Label16)
        Me.GroupBox9.Controls.Add(Me.Label14)
        Me.GroupBox9.Controls.Add(Me.picCompass)
        Me.GroupBox9.Location = New System.Drawing.Point(8, 428)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(185, 67)
        Me.GroupBox9.TabIndex = 9
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "デフォルト方位記号"
        '
        'cboCompassSize
        '
        Me.cboCompassSize.FormattingEnabled = True
        Me.cboCompassSize.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cboCompassSize.Location = New System.Drawing.Point(111, 33)
        Me.cboCompassSize.Name = "cboCompassSize"
        Me.cboCompassSize.Size = New System.Drawing.Size(44, 20)
        Me.cboCompassSize.TabIndex = 19
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(161, 41)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 12)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "%"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(71, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 12)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "サイズ"
        '
        'picCompass
        '
        Me.picCompass.BackColor = System.Drawing.Color.White
        Me.picCompass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCompass.Location = New System.Drawing.Point(19, 21)
        Me.picCompass.Margin = New System.Windows.Forms.Padding(2)
        Me.picCompass.Name = "picCompass"
        Me.picCompass.Size = New System.Drawing.Size(34, 32)
        Me.picCompass.TabIndex = 16
        Me.picCompass.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rbMapFolderLastSelected)
        Me.GroupBox6.Controls.Add(Me.rbMapFolderMAP)
        Me.GroupBox6.Location = New System.Drawing.Point(206, 232)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(186, 76)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "地図ファイルデフォルトフォルダ"
        '
        'rbMapFolderLastSelected
        '
        Me.rbMapFolderLastSelected.AutoSize = True
        Me.rbMapFolderLastSelected.Location = New System.Drawing.Point(18, 45)
        Me.rbMapFolderLastSelected.Name = "rbMapFolderLastSelected"
        Me.rbMapFolderLastSelected.Size = New System.Drawing.Size(133, 16)
        Me.rbMapFolderLastSelected.TabIndex = 1
        Me.rbMapFolderLastSelected.TabStop = True
        Me.rbMapFolderLastSelected.Text = "最後に指定したフォルダ"
        Me.rbMapFolderLastSelected.UseVisualStyleBackColor = True
        '
        'rbMapFolderMAP
        '
        Me.rbMapFolderMAP.AutoSize = True
        Me.rbMapFolderMAP.Location = New System.Drawing.Point(18, 23)
        Me.rbMapFolderMAP.Name = "rbMapFolderMAP"
        Me.rbMapFolderMAP.Size = New System.Drawing.Size(157, 16)
        Me.rbMapFolderMAP.TabIndex = 0
        Me.rbMapFolderMAP.TabStop = True
        Me.rbMapFolderMAP.Text = "MANDARA10\MAPフォルダ"
        Me.rbMapFolderMAP.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rbLatLonDecimal)
        Me.GroupBox5.Controls.Add(Me.rbLatLonDMS)
        Me.GroupBox5.Location = New System.Drawing.Point(206, 174)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(181, 51)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "緯度経度の表示"
        '
        'rbLatLonDecimal
        '
        Me.rbLatLonDecimal.AutoSize = True
        Me.rbLatLonDecimal.Location = New System.Drawing.Point(107, 20)
        Me.rbLatLonDecimal.Name = "rbLatLonDecimal"
        Me.rbLatLonDecimal.Size = New System.Drawing.Size(59, 16)
        Me.rbLatLonDecimal.TabIndex = 1
        Me.rbLatLonDecimal.TabStop = True
        Me.rbLatLonDecimal.Text = "10進数"
        Me.rbLatLonDecimal.UseVisualStyleBackColor = True
        '
        'rbLatLonDMS
        '
        Me.rbLatLonDMS.AutoSize = True
        Me.rbLatLonDMS.Location = New System.Drawing.Point(18, 19)
        Me.rbLatLonDMS.Name = "rbLatLonDMS"
        Me.rbLatLonDMS.Size = New System.Drawing.Size(71, 16)
        Me.rbLatLonDMS.TabIndex = 0
        Me.rbLatLonDMS.TabStop = True
        Me.rbLatLonDMS.Text = "度・分・秒"
        Me.rbLatLonDMS.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboBaseFont)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 175)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(185, 51)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "ベースフォント"
        '
        'cboBaseFont
        '
        Me.cboBaseFont.AsteriskSelectEnabled = False
        Me.cboBaseFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBaseFont.FormattingEnabled = True
        Me.cboBaseFont.IntegralHeight = False
        Me.cboBaseFont.Location = New System.Drawing.Point(15, 19)
        Me.cboBaseFont.MaxDropDownItems = 20
        Me.cboBaseFont.Name = "cboBaseFont"
        Me.cboBaseFont.Size = New System.Drawing.Size(147, 20)
        Me.cboBaseFont.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbKatakanaCheck)
        Me.GroupBox3.Controls.Add(Me.ktGridCompatibleCharacter)
        Me.GroupBox3.Controls.Add(Me.cbSinKyuCharacter)
        Me.GroupBox3.Controls.Add(Me.btnDeleteCompatibleCharacter)
        Me.GroupBox3.Controls.Add(Me.btnAddCompatibleCharacter)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 32)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(379, 133)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "オブジェクト名読み込み時に同一と見なす文字"
        '
        'cbKatakanaCheck
        '
        Me.cbKatakanaCheck.Location = New System.Drawing.Point(257, 50)
        Me.cbKatakanaCheck.Name = "cbKatakanaCheck"
        Me.cbKatakanaCheck.Size = New System.Drawing.Size(92, 35)
        Me.cbKatakanaCheck.TabIndex = 3
        Me.cbKatakanaCheck.Text = "カタカナチェック（ヴァ,ヴェ,ティ）"
        Me.cbKatakanaCheck.UseVisualStyleBackColor = True
        '
        'ktGridCompatibleCharacter
        '
        Me.ktGridCompatibleCharacter.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGridCompatibleCharacter.DefaultFixedXNumberingWidth = 50
        Me.ktGridCompatibleCharacter.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGridCompatibleCharacter.DefaultFixedXWidth = 150
        Me.ktGridCompatibleCharacter.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGridCompatibleCharacter.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ktGridCompatibleCharacter.DefaultGridWidth = 100
        Me.ktGridCompatibleCharacter.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ktGridCompatibleCharacter.FixedGridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ktGridCompatibleCharacter.FrameColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.ktGridCompatibleCharacter.GridColor = System.Drawing.Color.White
        Me.ktGridCompatibleCharacter.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktGridCompatibleCharacter.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ktGridCompatibleCharacter.Layer = 0
        Me.ktGridCompatibleCharacter.LayerCaption = Nothing
        Me.ktGridCompatibleCharacter.Location = New System.Drawing.Point(7, 15)
        Me.ktGridCompatibleCharacter.Margin = New System.Windows.Forms.Padding(4)
        Me.ktGridCompatibleCharacter.MsgBoxTitle = ""
        Me.ktGridCompatibleCharacter.Name = "ktGridCompatibleCharacter"
        Me.ktGridCompatibleCharacter.RowCaption = Nothing
        Me.ktGridCompatibleCharacter.Size = New System.Drawing.Size(163, 111)
        Me.ktGridCompatibleCharacter.TabClickEnabled = False
        Me.ktGridCompatibleCharacter.TabIndex = 0
        '
        'cbSinKyuCharacter
        '
        Me.cbSinKyuCharacter.Location = New System.Drawing.Point(257, 91)
        Me.cbSinKyuCharacter.Name = "cbSinKyuCharacter"
        Me.cbSinKyuCharacter.Size = New System.Drawing.Size(111, 35)
        Me.cbSinKyuCharacter.TabIndex = 4
        Me.cbSinKyuCharacter.Text = "新字体/旧字体チェック"
        Me.cbSinKyuCharacter.UseVisualStyleBackColor = True
        '
        'btnDeleteCompatibleCharacter
        '
        Me.btnDeleteCompatibleCharacter.Location = New System.Drawing.Point(187, 106)
        Me.btnDeleteCompatibleCharacter.Name = "btnDeleteCompatibleCharacter"
        Me.btnDeleteCompatibleCharacter.Size = New System.Drawing.Size(56, 20)
        Me.btnDeleteCompatibleCharacter.TabIndex = 2
        Me.btnDeleteCompatibleCharacter.Text = "削除"
        Me.btnDeleteCompatibleCharacter.UseVisualStyleBackColor = True
        '
        'btnAddCompatibleCharacter
        '
        Me.btnAddCompatibleCharacter.Location = New System.Drawing.Point(187, 70)
        Me.btnAddCompatibleCharacter.Name = "btnAddCompatibleCharacter"
        Me.btnAddCompatibleCharacter.Size = New System.Drawing.Size(56, 20)
        Me.btnAddCompatibleCharacter.TabIndex = 1
        Me.btnAddCompatibleCharacter.Text = "追加"
        Me.btnAddCompatibleCharacter.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 9)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 12)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "全般"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cboObjectNameSize)
        Me.GroupBox2.Controls.Add(Me.txtMEDObjectNameMaxNumber)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.picMED_ObjectNameColor)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 653)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(378, 89)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "オブジェクト名表示"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(193, 65)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 12)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "ピクセル"
        '
        'cboObjectNameSize
        '
        Me.cboObjectNameSize.FormattingEnabled = True
        Me.cboObjectNameSize.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboObjectNameSize.Location = New System.Drawing.Point(145, 57)
        Me.cboObjectNameSize.MaxDropDownItems = 15
        Me.cboObjectNameSize.Name = "cboObjectNameSize"
        Me.cboObjectNameSize.Size = New System.Drawing.Size(43, 20)
        Me.cboObjectNameSize.TabIndex = 18
        '
        'txtMEDObjectNameMaxNumber
        '
        Me.txtMEDObjectNameMaxNumber.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMEDObjectNameMaxNumber.Location = New System.Drawing.Point(145, 24)
        Me.txtMEDObjectNameMaxNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMEDObjectNameMaxNumber.Name = "txtMEDObjectNameMaxNumber"
        Me.txtMEDObjectNameMaxNumber.Size = New System.Drawing.Size(36, 19)
        Me.txtMEDObjectNameMaxNumber.TabIndex = 17
        Me.txtMEDObjectNameMaxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 24)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 31)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "オブジェクト名・初期属性の画面中の最大表示数"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 58)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 12)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "オブジェクト名のサイズ"
        '
        'picMED_ObjectNameColor
        '
        Me.picMED_ObjectNameColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMED_ObjectNameColor.Location = New System.Drawing.Point(333, 24)
        Me.picMED_ObjectNameColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picMED_ObjectNameColor.Name = "picMED_ObjectNameColor"
        Me.picMED_ObjectNameColor.Size = New System.Drawing.Size(36, 18)
        Me.picMED_ObjectNameColor.TabIndex = 13
        Me.picMED_ObjectNameColor.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(195, 24)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 12)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "オブジェクト名の表示色"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 410)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "マップエディタ"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.picMED_LineColor)
        Me.GroupBox1.Controls.Add(Me.picMED_LineColorSelected)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.picMED_LineColorPoints)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.picMED_ObjectTimeLineColor)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.picMED_ObjectLineColorDisabled)
        Me.GroupBox1.Controls.Add(Me.picMED_ObjectLineColor)
        Me.GroupBox1.Controls.Add(Me.picMED_LineColorDisabled)
        Me.GroupBox1.Controls.Add(Me.picMED_Backcolor)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 502)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(379, 143)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "色設定"
        '
        'picMED_LineColor
        '
        Me.picMED_LineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMED_LineColor.Location = New System.Drawing.Point(148, 50)
        Me.picMED_LineColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picMED_LineColor.Name = "picMED_LineColor"
        Me.picMED_LineColor.Size = New System.Drawing.Size(36, 18)
        Me.picMED_LineColor.TabIndex = 18
        Me.picMED_LineColor.TabStop = False
        '
        'picMED_LineColorSelected
        '
        Me.picMED_LineColorSelected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMED_LineColorSelected.Location = New System.Drawing.Point(148, 95)
        Me.picMED_LineColorSelected.Margin = New System.Windows.Forms.Padding(2)
        Me.picMED_LineColorSelected.Name = "picMED_LineColorSelected"
        Me.picMED_LineColorSelected.Size = New System.Drawing.Size(36, 18)
        Me.picMED_LineColorSelected.TabIndex = 17
        Me.picMED_LineColorSelected.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 95)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 12)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "編集中のライン"
        '
        'picMED_LineColorPoints
        '
        Me.picMED_LineColorPoints.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMED_LineColorPoints.Location = New System.Drawing.Point(148, 117)
        Me.picMED_LineColorPoints.Margin = New System.Windows.Forms.Padding(2)
        Me.picMED_LineColorPoints.Name = "picMED_LineColorPoints"
        Me.picMED_LineColorPoints.Size = New System.Drawing.Size(36, 18)
        Me.picMED_LineColorPoints.TabIndex = 15
        Me.picMED_LineColorPoints.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 117)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(123, 12)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "編集中のラインのポイント"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(196, 79)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 30)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "編集中オブジェクトで使用期間の設定してあるライン"
        '
        'picMED_ObjectTimeLineColor
        '
        Me.picMED_ObjectTimeLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMED_ObjectTimeLineColor.Location = New System.Drawing.Point(333, 79)
        Me.picMED_ObjectTimeLineColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picMED_ObjectTimeLineColor.Name = "picMED_ObjectTimeLineColor"
        Me.picMED_ObjectTimeLineColor.Size = New System.Drawing.Size(36, 18)
        Me.picMED_ObjectTimeLineColor.TabIndex = 12
        Me.picMED_ObjectTimeLineColor.TabStop = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(196, 50)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 30)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "編集中オブジェクトで編集対象でないライン"
        '
        'picMED_ObjectLineColorDisabled
        '
        Me.picMED_ObjectLineColorDisabled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMED_ObjectLineColorDisabled.Location = New System.Drawing.Point(333, 50)
        Me.picMED_ObjectLineColorDisabled.Margin = New System.Windows.Forms.Padding(2)
        Me.picMED_ObjectLineColorDisabled.Name = "picMED_ObjectLineColorDisabled"
        Me.picMED_ObjectLineColorDisabled.Size = New System.Drawing.Size(36, 18)
        Me.picMED_ObjectLineColorDisabled.TabIndex = 10
        Me.picMED_ObjectLineColorDisabled.TabStop = False
        '
        'picMED_ObjectLineColor
        '
        Me.picMED_ObjectLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMED_ObjectLineColor.Location = New System.Drawing.Point(333, 26)
        Me.picMED_ObjectLineColor.Margin = New System.Windows.Forms.Padding(2)
        Me.picMED_ObjectLineColor.Name = "picMED_ObjectLineColor"
        Me.picMED_ObjectLineColor.Size = New System.Drawing.Size(36, 18)
        Me.picMED_ObjectLineColor.TabIndex = 9
        Me.picMED_ObjectLineColor.TabStop = False
        '
        'picMED_LineColorDisabled
        '
        Me.picMED_LineColorDisabled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMED_LineColorDisabled.Location = New System.Drawing.Point(148, 73)
        Me.picMED_LineColorDisabled.Margin = New System.Windows.Forms.Padding(2)
        Me.picMED_LineColorDisabled.Name = "picMED_LineColorDisabled"
        Me.picMED_LineColorDisabled.Size = New System.Drawing.Size(36, 18)
        Me.picMED_LineColorDisabled.TabIndex = 8
        Me.picMED_LineColorDisabled.TabStop = False
        '
        'picMED_Backcolor
        '
        Me.picMED_Backcolor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMED_Backcolor.Location = New System.Drawing.Point(148, 26)
        Me.picMED_Backcolor.Margin = New System.Windows.Forms.Padding(2)
        Me.picMED_Backcolor.Name = "picMED_Backcolor"
        Me.picMED_Backcolor.Size = New System.Drawing.Size(36, 18)
        Me.picMED_Backcolor.TabIndex = 6
        Me.picMED_Backcolor.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(195, 26)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "編集中オブジェクトのライン"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 73)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "編集対象でないライン"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 50)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "編集対象のライン"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "背景色"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.cboDefoHanreiColor)
        Me.GroupBox8.Location = New System.Drawing.Point(205, 314)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(181, 52)
        Me.GroupBox8.TabIndex = 16
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "デフォルト凡例色"
        '
        'cboDefoHanreiColor
        '
        Me.cboDefoHanreiColor.AsteriskSelectEnabled = False
        Me.cboDefoHanreiColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefoHanreiColor.FormattingEnabled = True
        Me.cboDefoHanreiColor.IntegralHeight = False
        Me.cboDefoHanreiColor.Location = New System.Drawing.Point(16, 19)
        Me.cboDefoHanreiColor.MaxDropDownItems = 20
        Me.cboDefoHanreiColor.Name = "cboDefoHanreiColor"
        Me.cboDefoHanreiColor.Size = New System.Drawing.Size(147, 20)
        Me.cboDefoHanreiColor.TabIndex = 1
        '
        'frmOption
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(437, 407)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オプション"
        Me.Panel.ResumeLayout(False)
        Me.pnlOption.ResumeLayout(False)
        Me.pnlOption.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.tracBarBackImageSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        CType(Me.picCompass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picMED_ObjectNameColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picMED_LineColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMED_LineColorSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMED_LineColorPoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMED_ObjectTimeLineColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMED_ObjectLineColorDisabled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMED_ObjectLineColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMED_LineColorDisabled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMED_Backcolor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents pnlOption As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMEDObjectNameMaxNumber As mandara10.TextBoxFocusAllSelect
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents picMED_ObjectNameColor As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents picMED_ObjectTimeLineColor As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents picMED_ObjectLineColorDisabled As System.Windows.Forms.PictureBox
    Friend WithEvents picMED_ObjectLineColor As System.Windows.Forms.PictureBox
    Friend WithEvents picMED_LineColorDisabled As System.Windows.Forms.PictureBox
    Friend WithEvents picMED_Backcolor As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboObjectNameSize As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSinKyuCharacter As System.Windows.Forms.CheckBox
    Friend WithEvents btnDeleteCompatibleCharacter As System.Windows.Forms.Button
    Friend WithEvents btnAddCompatibleCharacter As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMapFolderLastSelected As System.Windows.Forms.RadioButton
    Friend WithEvents rbMapFolderMAP As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbLatLonDecimal As System.Windows.Forms.RadioButton
    Friend WithEvents rbLatLonDMS As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboBaseFont As mandara10.ComboBoxEx
    Friend WithEvents picCompass As System.Windows.Forms.PictureBox
    Friend WithEvents cboCompassSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents picMED_LineColorPoints As System.Windows.Forms.PictureBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents picMED_LineColorSelected As System.Windows.Forms.PictureBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents picMED_LineColor As System.Windows.Forms.PictureBox
    Friend WithEvents lblLine2 As System.Windows.Forms.Label
    Friend WithEvents ktGridCompatibleCharacter As KTGISUserControl.KTGISGrid
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents tracBarBackImageSpeed As System.Windows.Forms.TrackBar
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDefProjection As mandara10.ComboBoxEx
    Friend WithEvents cbKatakanaCheck As System.Windows.Forms.CheckBox
    Friend WithEvents chkAntiAlias As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDefoHanreiColor As mandara10.ComboBoxEx
End Class
