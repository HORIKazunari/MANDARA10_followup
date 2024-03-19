Public Class frmMain_ClassViewSettings
    Private Const picClassBoxWidth = 40
    Private Const picClassBoxHeight = 23
    Private Const picClassBoxLeft = 10
    Private Const picClassBoxTop = 10
    Private Const txtClassValueLeftMergin = 5

    Dim attData As clsAttrData
    Dim ClassMode As enmSoloMode_Number
    Dim LayerNum As Integer
    Dim DataNum As Integer
    Dim LayerShape As enmShape
    Dim DDType As enmAttDataType
    Dim SelectedCategoryIndex As Integer
    Private picClassBox() As System.Windows.Forms.PictureBox
    Private txtClassValue() As System.Windows.Forms.TextBox
    Private lblFreq() As System.Windows.Forms.Label

    Private Sub frmMain_ClassViewSettings_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim frm As frmMain
            frm = CType(Me.Owner, frmMain)
            frm.btnDraw.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub frmMain_ClassViewSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        With cboDivisionCount
            .Items.Clear()
            For i As Integer = 0 To 18
                .Items.Add(i + 2)
            Next
        End With
        With cboDivisionMethod
            .Items.Clear()
            .Items.Add("自由設定")
            .Items.Add("分位数")
            .Items.Add("面積分位数")
            .Items.Add("標準偏差")
            .Items.Add("等間隔")
        End With
        pnlClassHatch.Location = pnlClassPaint.Location
        pnlClassMark.Location = pnlClassPaint.Location
        pnlClassOD.Location = pnlClassPaint.Location
        Me.Width = pnlClassDivBase.Left + pnlClassDivBase.Width + 20
        'カテゴリーを移動させる場合の矢印用PictureBox
        With picCategrySelector
            Dim XY(3) As Point
            .Width = picClassBoxLeft
            .Height = picClassBoxHeight
            XY(0).X = 0
            XY(0).Y = 0
            XY(1).X = picClassBoxLeft - 2
            XY(1).Y = picClassBoxHeight / 2
            XY(2).X = 0
            XY(2).Y = picClassBoxHeight - 2
            XY(3) = XY(0)
            Dim canvas As New Bitmap(picClassBoxWidth, picClassBoxHeight)
            Dim g As Graphics = Graphics.FromImage(canvas)
            Dim pen As New Pen(Color.Black, 1)
            g.FillPolygon(New SolidBrush(Color.LightGreen), XY)
            g.DrawLines(pen, XY)
            g.Dispose()
            .Image = canvas
            .Refresh()
        End With


    End Sub

    ''' <summary>
    ''' 階級区分ボックスを作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateClassBox()

        Dim div_num As Integer = attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.Div_Num

        If Me.picClassBox Is Nothing = False Then
            For Each p As PictureBox In Me.picClassBox
                RemoveHandler p.Click, AddressOf picClassBoxClick
                Me.pnlClassDiv.Controls.Remove(p)
            Next
            For Each p As Label In Me.lblFreq
                Me.pnlClassDiv.Controls.Remove(p)
            Next
            For Each t As TextBox In Me.txtClassValue
                RemoveHandler t.Enter, AddressOf txtClassValueEnter
                RemoveHandler t.Click, AddressOf txtClassValueEnter
                RemoveHandler t.KeyDown, AddressOf txtClassValueKeyDown
                RemoveHandler t.KeyPress, AddressOf txtClassValueKeyPress
                RemoveHandler t.LostFocus, AddressOf txtClassValueLostFocus
                Me.pnlClassDiv.Controls.Remove(t)
            Next
        End If
        pnlClassDiv.Visible = False


        Me.picClassBox = New PictureBox(div_num - 1) {}
        Me.lblFreq = New Label(div_num - 1) {}
        Dim txn As Integer = 0
        If DDType = enmAttDataType.Category Then
            txn = div_num - 1
        Else
            txn = div_num - 2
        End If
        Me.txtClassValue = New TextBox(txn) {}
        pnlClassDiv.Height = picClassBoxHeight * div_num + 20
        pnlClassDiv.Width = pnlClassDivBase.Width - SystemInformation.VerticalScrollBarWidth - 3

        For i As Integer = 0 To div_num - 1
            Me.picClassBox(i) = New System.Windows.Forms.PictureBox
            With Me.picClassBox(i)
                .Parent = pnlClassDiv
                .Top = i * picClassBoxHeight + picClassBoxTop
                .Left = picClassBoxLeft
                .Width = picClassBoxWidth
                .Height = picClassBoxHeight
                .BorderStyle = BorderStyle.Fixed3D
                .Tag = i
                AddHandler .Click, AddressOf picClassBoxClick
            End With

            Me.lblFreq(i) = New Label
            With Me.lblFreq(i)
                .Parent = pnlClassDiv
                .Height = picClassBoxHeight
                .Left = pnlClassDiv.Width - picClassBoxWidth - 5
                .Top = Me.picClassBox(i).Top
            End With

            If i <> div_num - 1 Or DDType = enmAttDataType.Category Then
                Me.txtClassValue(i) = New System.Windows.Forms.TextBox
                With Me.txtClassValue(i)
                    .Parent = pnlClassDiv
                    .Top = i * picClassBoxHeight + picClassBoxTop
                    .Left = picClassBoxLeft + picClassBoxWidth + txtClassValueLeftMergin
                    .Height = picClassBoxHeight
                    .Width = Me.lblFreq(i).Left - .Left - 5
                    If DDType = enmAttDataType.Normal Then
                        .Top += picClassBoxHeight \ 2
                        .TextAlign = HorizontalAlignment.Right
                        .ImeMode = Windows.Forms.ImeMode.Disable
                    Else
                        .TextAlign = HorizontalAlignment.Left
                        .ImeMode = Windows.Forms.ImeMode.NoControl
                    End If
                    .BackColor = Color.White
                    .Font = New Font(.Font.FontFamily, 11)
                    .Tag = i
                    AddHandler .Enter, AddressOf txtClassValueEnter
                    AddHandler .Click, AddressOf txtClassValueEnter
                    AddHandler .KeyDown, AddressOf txtClassValueKeyDown
                    AddHandler .KeyPress, AddressOf txtClassValueKeyPress
                    AddHandler .LostFocus, AddressOf txtClassValueLostFocus

                End With
            End If
        Next
        If DDType = enmAttDataType.Category Then
            SelectedCategoryIndex = 0
            picCategrySelector.Height = picClassBoxHeight
            SetCategorySelector()
        Else
            picCategrySelector.Visible = False
        End If


        pnlClassDiv.Visible = True
    End Sub
    ''' <summary>
    ''' 階級区分値テキストボックスでEnter,カーソル上下でフォーカス移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtClassValueKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim tx As TextBox = CType(sender, TextBox)
        Dim n As Integer = tx.Tag
        Dim mx As Integer = txtClassValue.Length
        Select Case e.KeyData
            Case Keys.Down
                If n = mx - 1 Then
                    txtClassValue(0).Focus()
                Else
                    txtClassValue(n + 1).Focus()
                End If
            Case Keys.Up
                If n = 0 Then
                    txtClassValue(mx - 1).Focus()
                Else
                    txtClassValue(n - 1).Focus()
                End If
        End Select
    End Sub
    ''' <summary>
    ''' 階級区分値テキストボックスでEnter,ESCが押されたときにBeepが鳴らないようにする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtClassValueKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) OrElse _
                e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape) Then
            e.Handled = True
        End If
    End Sub
    ''' <summary>
    ''' 階級区分値テキストボックスがフォーカス・クリック時に選択状態にする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtClassValueEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tx As TextBox = CType(sender, TextBox)
        tx.SelectAll()
        SelectedCategoryIndex = sender.tag
        ToolTip1.SetToolTip(tx, "")
        SetCategorySelector()
    End Sub
    ''' <summary>
    ''' 階級区分値テキストボックスからフォーカスが外れる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtClassValueLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tx As TextBox = CType(sender, TextBox)
        tx.SelectionLength = 0
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            If DDType = enmAttDataType.Category Then
                Dim oldTx As String = .Class_Div(tx.Tag).Cat_Name
                Dim newTx As String = Trim(tx.Text)
                If newTx = "" And attData.LayerData(LayerNum).atrData.Data(DataNum).MissingF = True Then
                    MsgBox("欠損値設定があるので空白にはできません。", MsgBoxStyle.Exclamation)
                    tx.Text = oldTx
                    Return
                End If
                For i As Integer = 0 To .Div_Num - 1
                    If .Class_Div(i).Cat_Name = newTx And i <> tx.Tag Then
                        MsgBox(newTx + "は既に存在しています。", MsgBoxStyle.Exclamation)
                        tx.Text = oldTx
                        Return
                    End If
                Next
                'カテゴリーの元を新名称に書き換える
                With attData.LayerData(LayerNum)
                    For i As Integer = 0 To .atrObject.ObjectNum - 1
                        With .atrData.Data(DataNum)
                            If .Value(i) = oldTx Then
                                .Value(i) = newTx
                            End If
                        End With
                    Next
                End With
                .Class_Div(tx.Tag).Cat_Name = tx.Text
            Else
                If clsGeneric.Check_Suji(tx.Text) = True Then
                    Dim v As Double = Val(tx.Text)
                    .Class_Div(tx.Tag).Value = v
                End If
                tx.Text = CStr(.Class_Div(tx.Tag).Value)
            End If
        End With
        ToolTip1.SetToolTip(tx, tx.Text)
        setFrequencyLabel()
        Dim frm As frmMain
        frm = CType(Me.Owner, frmMain)
        frm.Check_Print_err()
    End Sub
    ''' <summary>
    ''' 階級区分PictureBoxがクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picClassBoxClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dm As clsAttrData.enmPaintColorSettingModeInfo = attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ClassPaintMD.Color_Mode
        Dim pcol As PictureBox = TryCast(sender, PictureBox)
        Dim n As Integer = pcol.Tag
        If DDType = enmAttDataType.Category Then
            If ClassMode = enmSoloMode_Number.ClassPaintMode And dm = clsAttrData.enmPaintColorSettingModeInfo.multiColor Then
            Else
                SelectedCategoryIndex = n
                SetCategorySelector()
            End If
        End If
        If picClassBox(n).Cursor <> Cursors.Cross Then
            Return
        End If
        picClassBox(n).Focus()
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            Select Case ClassMode
                Case enmSoloMode_Number.ClassPaintMode
                    Dim col As colorARGB = .Class_Div(n).PaintColor
                    If clsGeneric.Color_Set(col) = True Then

                        Select Case dm
                            Case clsAttrData.enmPaintColorSettingModeInfo.twoColor
                                If n = 0 Then
                                    .ClassPaintMD.color1 = col
                                Else
                                    .ClassPaintMD.color2 = col
                                End If
                                attData.Twocolort(LayerNum, DataNum)
                            Case clsAttrData.enmPaintColorSettingModeInfo.threeeColor
                                If n = 0 Then
                                    .ClassPaintMD.color1 = col
                                    attData.Twocolort(LayerNum, DataNum)
                                ElseIf n = .Div_Num - 1 Then
                                    .ClassPaintMD.color2 = col
                                    attData.Twocolort(LayerNum, DataNum)
                                Else
                                    .ClassPaintMD.color3 = col
                                    attData.Threecolor(LayerNum, DataNum, n)
                                End If
                            Case clsAttrData.enmPaintColorSettingModeInfo.multiColor
                                If n = 0 Then
                                    .ClassPaintMD.color1 = col
                                    attData.Twocolort(LayerNum, DataNum)
                                    SelectedCategoryIndex = -1
                                ElseIf n = .Div_Num - 1 Then
                                    .ClassPaintMD.color2 = col
                                    attData.Twocolort(LayerNum, DataNum)
                                    SelectedCategoryIndex = -1
                                Else
                                    If SelectedCategoryIndex = -1 Then
                                        SelectedCategoryIndex = n
                                        .ClassPaintMD.color3 = col
                                        attData.Threecolor(LayerNum, DataNum, n)
                                    Else
                                        attData.FourColor(LayerNum, DataNum, n, SelectedCategoryIndex, col)
                                        SelectedCategoryIndex = n
                                        .ClassPaintMD.color3 = col
                                    End If
                                End If

                                SetCategorySelector()
                            Case clsAttrData.enmPaintColorSettingModeInfo.SoloColor
                                .Class_Div(n).PaintColor = col
                                If n = 0 Then
                                    .ClassPaintMD.color1 = col
                                ElseIf n = .Div_Num - 1 Then
                                    .ClassPaintMD.color2 = col
                                End If
                        End Select
                        SetPictureBox()
                    End If
                Case enmSoloMode_Number.ClassHatchMode
                    Dim T As Tile_Property = .Class_Div(n).TilePat
                    If attData.Select_Tile(T) = True Then
                        .Class_Div(n).TilePat = T
                        SetPictureBox()
                    End If
                Case enmSoloMode_Number.ClassMarkMode
                    Dim mk As Mark_Property = .Class_Div(n).ClassMark
                    If attData.Select_Mark(mk) = True Then
                        .Class_Div(n).ClassMark = mk
                        SetPictureBox()
                    End If
                Case enmSoloMode_Number.ClassODMode
                    Dim lk As Line_Property = .Class_Div(n).ODLinePat
                    If attData.Select_Line_Pattern(lk, True) = True Then
                        .Class_Div(n).ODLinePat = lk
                        SetPictureBox()
                    End If

            End Select

        End With
        'pcol.BorderStyle = BorderStyle.Fixed3D

    End Sub
    ''' <summary>
    ''' データ項目の階級区分モードの初期値をコントロールに設定
    ''' </summary>
    ''' <param name="_attData"></param>
    ''' <remarks></remarks>
    Public Sub SetData(ByRef _attData As clsAttrData)
        Me.Tag = "OFF"
        attData = _attData
        LayerNum = attData.TotalData.LV1.SelectedLayer
        DataNum = attData.LayerData(LayerNum).atrData.SelectedIndex
        LayerShape = attData.LayerData(LayerNum).Shape
        If attData.LayerData(LayerNum).Type = clsAttrData.enmLayerType.Trip Then
            LayerShape = enmShape.LineShape
        End If
        ClassMode = attData.LayerData(LayerNum).atrData.Data(DataNum).ModeData
        DDType = attData.Get_DataType(LayerNum, DataNum)
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            If DDType = enmAttDataType.Normal Then
                cboDivisionCount.SelectedIndex = .Div_Num - 2
                Select Case .Div_Method
                    Case enmDivisionMethod.Free
                        cboDivisionMethod.SelectedIndex = 0
                    Case enmDivisionMethod.Quantile
                        cboDivisionMethod.SelectedIndex = 1
                    Case enmDivisionMethod.AreaQuantile
                        cboDivisionMethod.SelectedIndex = 2
                    Case enmDivisionMethod.StandardDeviation
                        cboDivisionMethod.SelectedIndex = 3
                    Case enmDivisionMethod.EqualInterval
                        cboDivisionMethod.SelectedIndex = 4
                End Select
                cboDivisionCount.Enabled = True
                gbDivNum.Visible = True
                pnlCategoryUpDown.Visible = False
                btnCategorize_Arrange.Text = "カテゴリーデータ化"
            Else
                cboDivisionCount.Enabled = False
                gbDivNum.Visible = False
                pnlCategoryUpDown.Enabled = True
                pnlCategoryUpDown.Visible = True
                btnCategorize_Arrange.Text = "並べ替え"
            End If
            pnlCategoryUpDown.Left = pnlClassDivBase.Left - pnlCategoryUpDown.Width
            pnlClassPaint.Visible = False
            pnlClassHatch.Visible = False
            pnlClassMark.Visible = False
            pnlClassOD.Visible = False
            Select Case ClassMode
                Case enmSoloMode_Number.ClassPaintMode
                    Me.Text = "ペイントモード"
                    pnlClassPaint.Visible = True
                Case enmSoloMode_Number.ClassHatchMode
                    Me.Text = "ハッチモード"
                    pnlClassHatch.Visible = True
                Case enmSoloMode_Number.ClassMarkMode
                    Me.Text = "階級記号モード"
                    pnlClassMark.Visible = True
                Case enmSoloMode_Number.ClassODMode
                    Me.Text = "線モード"
                    pnlClassOD.Visible = True
            End Select
            'レイヤ形状に応じたグループボックスの表示/非表示
            Select Case LayerShape
                Case enmShape.PointShape
                    attData.Draw_Sample_Mark_Box(picPointShapeMark, attData.LayerData(LayerNum).LayerModeViewSettings.PointLineShape.PointMark)
                    Select Case ClassMode
                        Case enmSoloMode_Number.ClassPaintMode
                            gbPointShapeMark.Parent = pnlClassPaint
                            gbPointShapeMark.Top = gbClassPaint.Top + gbClassPaint.Height + 10
                        Case enmSoloMode_Number.ClassHatchMode
                            gbPointShapeMark.Parent = pnlClassHatch
                            gbPointShapeMark.Top = btnHatchSetting.Top + btnHatchSetting.Height + 10
                    End Select
                    gbLineObjectSize.Visible = False
                    gbPointShapeMark.Visible = True
                    gbOriginObject.Visible = True
                Case enmShape.LineShape
                    gbLineObjectSize.Visible = True
                    gbPointShapeMark.Visible = False
                    txtLineObjectSize.Text = attData.LayerData(LayerNum).LayerModeViewSettings.PointLineShape.LineWidth
                    gbOriginObject.Visible = False
                Case enmShape.PolygonShape
                    gbPointShapeMark.Visible = False
                    gbLineObjectSize.Visible = False
                    gbOriginObject.Visible = True
            End Select
            Select Case ClassMode
                Case enmSoloMode_Number.ClassPaintMode
                    Select Case .ClassPaintMD.Color_Mode
                        Case clsAttrData.enmPaintColorSettingModeInfo.twoColor
                            rbTwoColor.Checked = True
                        Case clsAttrData.enmPaintColorSettingModeInfo.threeeColor
                            rbThreeColor.Checked = True
                        Case clsAttrData.enmPaintColorSettingModeInfo.multiColor
                            rbMultiColor.Checked = True
                        Case clsAttrData.enmPaintColorSettingModeInfo.SoloColor
                            rbSoloColor.Checked = True
                    End Select
                Case enmSoloMode_Number.ClassODMode
                    If attData.LayerData(LayerNum).Type <> clsAttrData.enmLayerType.Trip Then
                        SetODModeOriginObject()
                    End If

            End Select

            CreateClassBox()
            SetPictureBox()
            setFrequencyLabel()
            SetPicClassBoxCursol()
            SetClassDivValueTextBox()
            Me.Tag = ""
            Me.Refresh()
        End With


    End Sub
    Private Sub SetCategorySelector()
        If DDType = enmAttDataType.Category Or attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ClassPaintMD.Color_Mode = clsAttrData.enmPaintColorSettingModeInfo.multiColor Then
            If SelectedCategoryIndex = -1 Then
                picCategrySelector.Visible = False
            Else
                picCategrySelector.Visible = True
                picCategrySelector.Top = picClassBox(SelectedCategoryIndex).Top
            End If
        Else
            picCategrySelector.Visible = False
        End If
    End Sub
    Private Sub SetODModeOriginObject()
        Dim tx As String = ""
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ClassODMD
            If .o_Layer <> LayerNum Then
                tx += "レイヤ:" + attData.LayerData(.o_Layer).Name + vbCrLf
            End If
            If .Dummy_ObjectFlag = False Then
                tx += attData.LayerData(.o_Layer).atrObject.atrObjectData(.O_object).Name
            Else
                tx += attData.LayerData(.o_Layer).Dummy.DummyObj(.O_object).Name
            End If
        End With
        lblOriginObject.Text = tx
    End Sub
    Private Sub setFrequencyLabel()
        Dim freq() As Integer, missFreq As Integer
        If attData.Get_ClassFrequency(LayerNum, DataNum, False, freq, missFreq) = True Then
            For j As Integer = 0 To Me.lblFreq.Count - 1
                Me.lblFreq(j).Text = "(" + freq(j).ToString + ")"
            Next
        Else
            For j As Integer = 0 To Me.lblFreq.Count - 1
                Me.lblFreq(j).Text = "--"
            Next
        End If
    End Sub
    ''' <summary>
    ''' 階級区分のpictureboxを設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPictureBox()
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings

            For i As Integer = 0 To .Div_Num - 1
                With .Class_Div(i)

                    Select Case ClassMode
                        Case enmSoloMode_Number.ClassPaintMode
                            Me.picClassBox(i).BackColor = .PaintColor.getColor
                        Case enmSoloMode_Number.ClassHatchMode
                            pnlClassPaint.Visible = False
                            Me.picClassBox(i).BackColor = Color.White
                            attData.Draw_Sample_TileBox(Me.picClassBox(i), .TilePat)
                        Case enmSoloMode_Number.ClassMarkMode
                            Me.picClassBox(i).BackColor = Color.White
                            attData.Draw_Sample_Mark_Box(Me.picClassBox(i), .ClassMark)
                        Case enmSoloMode_Number.ClassODMode
                            Me.picClassBox(i).BackColor = Color.White
                            attData.Draw_Sample_LineBox(Me.picClassBox(i), .ODLinePat)
                    End Select
                End With


            Next
        End With
    End Sub

    ''' <summary>
    ''' 'picTureBoxのマウスカーソルを設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPicClassBoxCursol()
        If picClassBox Is Nothing = True Then
            Return
        End If
        Dim picN As Integer = picClassBox.Length
        Select Case ClassMode
            Case enmSoloMode_Number.ClassPaintMode
                Select Case attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ClassPaintMD.Color_Mode
                    Case clsAttrData.enmPaintColorSettingModeInfo.twoColor
                        picClassBox(0).Cursor = Cursors.Cross
                        picClassBox(picN - 1).Cursor = Cursors.Cross
                        For i As Integer = 1 To picN - 2
                            picClassBox(i).Cursor = Cursors.Default
                        Next
                    Case Else
                        For i As Integer = 0 To picN - 1
                            picClassBox(i).Cursor = Cursors.Cross
                        Next
                End Select
            Case Else
                For i As Integer = 0 To picN - 1
                    picClassBox(i).Cursor = Cursors.Cross
                Next
        End Select

    End Sub
    ''' <summary>
    ''' 階級区分の値を設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetClassDivValueTextBox()
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings

            For i As Integer = 0 To .Div_Num - 1
                If i <> .Div_Num - 1 Or DDType = enmAttDataType.Category Then
                    If DDType = enmAttDataType.Normal Then
                        Me.txtClassValue(i).Text = .Class_Div(i).Value.ToString
                    Else
                        Me.txtClassValue(i).Text = .Class_Div(i).Cat_Name
                    End If
                    If .Div_Method = enmDivisionMethod.Free Or DDType = enmAttDataType.Category Then
                        Me.txtClassValue(i).Enabled = True
                    Else
                        Me.txtClassValue(i).Enabled = False
                    End If
                    ToolTip1.SetToolTip(Me.txtClassValue(i), Me.txtClassValue(i).Text)
                End If
            Next
        End With

    End Sub
    Private Sub rbColorSet_CheckedChanged(sender As Object, e As EventArgs) Handles rbThreeColor.CheckedChanged,
            rbSoloColor.CheckedChanged, rbTwoColor.CheckedChanged, rbMultiColor.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim rb As RadioButton = CType(sender, RadioButton)
        pnlCategoryUpDown.Enabled = True
        If rb.Checked = True Then
            Dim cmode As clsAttrData.enmPaintColorSettingModeInfo
            Select Case rb.Name
                Case "rbTwoColor"
                    cmode = clsAttrData.enmPaintColorSettingModeInfo.twoColor
                    attData.Twocolort(LayerNum, DataNum)
                    SetPictureBox()

                Case "rbThreeColor"
                    cmode = clsAttrData.enmPaintColorSettingModeInfo.threeeColor
                Case "rbMultiColor"
                    attData.Twocolort(LayerNum, DataNum)
                    SetPictureBox()
                    SelectedCategoryIndex = -1
                    pnlCategoryUpDown.Enabled = False
                    cmode = clsAttrData.enmPaintColorSettingModeInfo.multiColor
                Case "rbSoloColor"
                    cmode = clsAttrData.enmPaintColorSettingModeInfo.SoloColor
            End Select
            attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ClassPaintMD.Color_Mode = cmode
            SetCategorySelector()
            SetPicClassBoxCursol()
        End If
    End Sub

    Private Sub btnHatchSetting_Click(sender As Object, e As EventArgs) Handles btnHatchSetting.Click

        Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult( _
                    "ハッチの設定", {"既定パターン", "全色変更", "ペイントモードの色をコピー", "すべてベタ塗りにする"})
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            Dim divn As Integer = .Div_Num
            Select Case sel
                Case 0
                    For i As Integer = 0 To divn - 1
                        With .Class_Div(i)
                            If i <= 8 Then
                                Dim n2 As Integer = clsGeneric.m_min_max(divn, 0, 9)
                                .TilePat = clsBase.ClassTile(n2, i)
                            Else
                                .TilePat = clsBase.Tile
                                .TilePat.TileCode = 7
                            End If
                        End With
                    Next
                Case 1
                    Dim c As New colorARGB(Color.Black)
                    If clsGeneric.Color_Set(c) Then
                        For i As Integer = 0 To divn - 1
                            .Class_Div(i).TilePat.Line.Set_Same_Color_to_LinePat(c)
                        Next
                    End If
                Case 2
                    For i As Integer = 0 To divn - 1
                        .Class_Div(i).TilePat.Line.Set_Same_Color_to_LinePat(.Class_Div(i).PaintColor)
                    Next
                Case 3
                    For i As Integer = 0 To divn - 1
                        .Class_Div(i).TilePat.TileCode = 8
                    Next
            End Select
        End With
        SetPictureBox()
    End Sub

    Private Sub cboDivisionCount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDivisionCount.SelectedIndexChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim NDVN As Integer = cboDivisionCount.SelectedIndex + 2
        Dim oldDivNum As Integer
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            oldDivNum = .Div_Num
            If .Div_Num = NDVN Then
                Return
            Else
                .Div_Num = NDVN
            End If
            ReDim Preserve .Class_Div(NDVN)
            attData.Set_Class_Div(LayerNum, DataNum, oldDivNum)
            Select Case .ClassPaintMD.Color_Mode
                Case clsAttrData.enmPaintColorSettingModeInfo.SoloColor
                    For i As Integer = oldDivNum To .Div_Num - 1
                        .Class_Div(i).PaintColor = .Class_Div(oldDivNum - 1).PaintColor
                    Next
                    .ClassPaintMD.color2 = .Class_Div(.Div_Num - 1).PaintColor
                Case Else
                    attData.Twocolort(LayerNum, DataNum)
            End Select

            Select Case .Div_Method
                Case enmDivisionMethod.Free
                    For i As Integer = oldDivNum - 1 To NDVN - 1
                        .Class_Div(i).Value = 0
                    Next
                Case Else
                    attData.Set_Div_Value(LayerNum, DataNum)
            End Select
        End With
        CreateClassBox()
        SetPictureBox()
        SetPicClassBoxCursol()
        SetClassDivValueTextBox()
        setFrequencyLabel()
    End Sub

    Private Sub cboDivisionMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDivisionMethod.SelectedIndexChanged
        If Me.Tag = "OFF" Then
            Return
        End If

        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            cboDivisionCount.Enabled = True
            Dim odvn As Integer = .Div_Num
            Select Case cboDivisionMethod.Text
                Case "自由設定"
                    .Div_Method = enmDivisionMethod.Free
                Case "分位数"
                    .Div_Method = enmDivisionMethod.Quantile
                Case "面積分位数"
                    Dim Lshape As enmShape = attData.LayerData(LayerNum).Shape
                    If Lshape <> enmShape.PolygonShape Then
                        MsgBox("レイヤの形状が" + clsGeneric.ConvertShapeEnumString(Lshape) + "なので面積分位数は使えません。", MsgBoxStyle.Exclamation)
                        Select Case .Div_Method
                            Case enmDivisionMethod.Free
                                cboDivisionMethod.SelectedIndex = 0
                            Case enmDivisionMethod.Quantile
                                cboDivisionMethod.SelectedIndex = 1
                            Case enmDivisionMethod.StandardDeviation
                                cboDivisionMethod.SelectedIndex = 3
                            Case enmDivisionMethod.EqualInterval
                                cboDivisionMethod.SelectedIndex = 4
                        End Select
                        Return
                    End If
                    .Div_Method = enmDivisionMethod.AreaQuantile
                Case "標準偏差"
                    .Div_Method = enmDivisionMethod.StandardDeviation
                    cboDivisionCount.SelectedIndex = 4
                    cboDivisionCount.Enabled = False
                Case "等間隔"
                    .Div_Method = enmDivisionMethod.EqualInterval
            End Select
            If .Div_Method <> enmDivisionMethod.StandardDeviation Or odvn = .Div_Num Then
                attData.Set_Div_Value(LayerNum, DataNum)
                SetClassDivValueTextBox()
                setFrequencyLabel()
            End If
        End With
    End Sub

    Private Sub btnClassMarkSettings_Click(sender As Object, e As EventArgs) Handles btnClassMarkSettings.Click
        Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult( _
            "記号の設定", {"同一記号に設定", "ペイントモードの色を内部色に設定", "内部データの設定"})
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            Dim divn As Integer = .Div_Num
            Select Case sel
                Case 0

                    Dim mk As Mark_Property = .Class_Div(0).ClassMark
                    If attData.Select_Mark(mk) = True Then
                        For i As Integer = 0 To divn - 1
                            .Class_Div(i).ClassMark = mk
                        Next
                        SetPictureBox()
                    End If
                Case 1
                    For i As Integer = 0 To .Div_Num - 1
                        With .Class_Div(i)
                            .ClassMark.Tile.Line.BasicLine.SolidLine.Color = .PaintColor
                            .ClassMark.WordFont.Body.Color = .PaintColor
                        End With
                    Next
                    SetPictureBox()
                Case 2
                    Dim form As New frmInnerData
                    If form.ShowDialog(Me, attData) = Windows.Forms.DialogResult.OK Then
                        attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ClassMarkMD = form.getResults
                    End If
                    form.Dispose()
            End Select
        End With


    End Sub

    Private Sub btnClassOD_Click(sender As Object, e As EventArgs) Handles btnClassOD.Click
        Dim itm() As String
        If attData.LayerData(LayerNum).Shape <> enmShape.LineShape Then
            itm = {"全線種変更", "全色変更", "ペイントモードの色をコピー", "線幅自動設定", "矢印設定"}
        Else
            itm = {"全線種変更", "全色変更", "ペイントモードの色をコピー", "線幅自動設定"}
        End If
        Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("線の設定", itm)
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            Select Case sel
                Case 0
                    Dim Line As Line_Property = .Class_Div(0).ODLinePat
                    If clsGeneric.Line_Pattern_select(Line, True, attData) = True Then
                        For i As Integer = 0 To .Div_Num - 1
                            With .Class_Div(i)
                                .ODLinePat = Line
                            End With
                        Next
                        SetPictureBox()
                    End If
                Case 1
                    Dim col As colorARGB = .Class_Div(0).PaintColor
                    If clsGeneric.Color_Set(col) = True Then
                        For i As Integer = 0 To .Div_Num - 1
                            With .Class_Div(i)
                                .ODLinePat.Set_Same_Color_to_LinePat(col)
                            End With
                        Next
                        SetPictureBox()
                    End If
                Case 2
                    For i As Integer = 0 To .Div_Num - 1
                        With .Class_Div(i)
                            .ODLinePat.Set_Same_Color_to_LinePat(.PaintColor)
                        End With
                    Next
                    SetPictureBox()
                Case 3
                    If MsgBox("一番上のラインパターンの幅と、一番下のラインパターンの幅から、その中間の幅を設定します。", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                        Return
                    End If
                    Dim w1 As Single = .Class_Div(0).ODLinePat.BasicLine.SolidLine.Width
                    Dim n As Integer = .Div_Num - 1
                    If .Class_Div(.Div_Num - 1).ODLinePat.BasicLine.pattern = enmLinePattern.InVisible Then
                        n -= 1
                    End If
                    Dim w2 As Single = .Class_Div(n).ODLinePat.BasicLine.SolidLine.Width
                    Dim stp As Single = (w1 - w2) / n
                    For i As Integer = 1 To n - 1
                        With .Class_Div(i)
                            .ODLinePat.Set_Same_Width_to_LinePat(w1 - stp * i)
                        End With
                    Next
                    SetPictureBox()
                Case 4
                    clsGeneric.Arrow_Set(.ClassODMD.Arrow, "", "矢印をつける")
                    SetPictureBox()
            End Select
        End With

    End Sub

    Private Sub btnOriginObject_Click(sender As Object, e As EventArgs) Handles btnOriginObject.Click
        Dim form As New frmMain_LayeObjectSelect
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ClassODMD
            Dim a() As Integer = {.O_object}
            If form.ShowDialog(attData, SelectionMode.One, True, .o_Layer, a, .Dummy_ObjectFlag) = Windows.Forms.DialogResult.OK Then
                form.getResult(.o_Layer, a, .Dummy_ObjectFlag)
                .O_object = a(0)
                SetODModeOriginObject()
            End If
        End With

    End Sub

    Private Sub picPointShapeMark_Click(sender As Object, e As EventArgs) Handles picPointShapeMark.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.PointLineShape
            attData.Select_Mark(picPointShapeMark, .PointMark)
        End With
    End Sub

    Private Sub txtLineObjectSize_Enter(sender As Object, e As EventArgs) Handles txtLineObjectSize.Enter, txtLineObjectSize.Click
        txtLineObjectSize.SelectAll()
    End Sub
    Private Sub txtLineObjectSize_LostFocus(sender As Object, e As EventArgs) Handles txtLineObjectSize.LostFocus
        Dim v As Single = Val(txtLineObjectSize.Text)
        txtLineObjectSize.Text = CStr(v)
        With attData.LayerData(LayerNum).LayerModeViewSettings.PointLineShape
            .LineWidth = v
        End With
    End Sub

    Private Sub btnLineShapeEdgePattern_Click(sender As Object, e As EventArgs) Handles btnLineShapeEdgePattern.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.PointLineShape
            clsGeneric.LineEdgePattern_Set(.LineEdge)
        End With

    End Sub

    Private Sub btnCategoryUp_Click(sender As Object, e As EventArgs) Handles btnCategoryUp.Click
        Dim os As Integer = SelectedCategoryIndex
        If SelectedCategoryIndex = 0 Then
            SelectedCategoryIndex = attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.Div_Num - 1
        Else
            SelectedCategoryIndex -= 1
        End If
        SwapCategoryData(SelectedCategoryIndex, os)
    End Sub

    Private Sub btnCategoryDown_Click(sender As Object, e As EventArgs) Handles btnCategoryDown.Click
        Dim os As Integer = SelectedCategoryIndex
        If SelectedCategoryIndex = attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.Div_Num - 1 Then
            SelectedCategoryIndex = 0
        Else
            SelectedCategoryIndex += 1
        End If
        SwapCategoryData(SelectedCategoryIndex, os)
    End Sub
    ''' <summary>
    ''' カテゴリーデータを入れ替える
    ''' </summary>
    ''' <param name="d1"></param>
    ''' <param name="d2"></param>
    ''' <remarks></remarks>
    Private Sub SwapCategoryData(ByVal d1 As Integer, ByVal d2 As Integer)
        Dim tp As clsAttrData.strClass_Div_data
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            tp = .Class_Div(d1)
            .Class_Div(d1) = .Class_Div(d2)
            .Class_Div(d2) = tp
        End With
        SetPictureBox()
        SetClassDivValueTextBox()
        SetPicClassBoxCursol()
        SetCategorySelector()
        setFrequencyLabel()
    End Sub


    Private Sub pnlClassDiv_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pnlClassDiv.MouseDown
        If SelectedCategoryIndex = -1 Then
            Return
        End If
        Dim Y As Integer = ((e.Location.Y - picClassBoxTop) \ picClassBoxHeight)
        SelectedCategoryIndex = Y
        SetCategorySelector()
    End Sub

    Private Sub btnCategorize_Arrange_Click(sender As Object, e As EventArgs) Handles btnCategorize_Arrange.Click
        Select Case DDType
            Case enmAttDataType.Normal
                Dim freq() As Integer, missFreq As Integer
                If attData.Get_ClassFrequency(LayerNum, DataNum, False, freq, missFreq) = False Then
                    clsGeneric.MessageBox(FormStartPosition.CenterParent, "区分値が不正です。", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                Else
                    For i As Integer = 0 To freq.Length - 1
                        If freq(i) = 0 Then
                            clsGeneric.MessageBox(FormStartPosition.CenterParent, "頻度が0の区分値があります。", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        End If
                    Next
                End If
                Dim lbl = "現在の階級区分により区分したカテゴリーデータをデータ項目に追加します。"
                Dim tx As String = attData.Get_DataTitle(LayerNum, DataNum, False) + "（カテゴリー）"
                Dim unt As String = "CAT"
                Dim note As String = attData.Get_DataNote(LayerNum, DataNum)
                Dim form As New frmTitleSettingsAddingData
                If form.ShowDialog(tx, unt, note, True, lbl) = Windows.Forms.DialogResult.OK Then
                    form.getResult(tx, unt, note)
                    Dim caten As Integer = attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.Div_Num
                    Dim cateStr(caten - 1) As String
                    With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
                        cateStr(0) = .Class_Div(0).Value.ToString + "以上"
                        For i As Integer = 1 To caten - 2
                            cateStr(i) = .Class_Div(i).Value.ToString + "～" + .Class_Div(i - 1).Value.ToString
                        Next
                        cateStr(caten - 1) = .Class_Div(caten - 2).Value.ToString + "未満"
                    End With

                    Dim Cate() As Integer = attData.Get_Categoly(LayerNum, DataNum)
                    Dim val(attData.Get_ObjectNum(LayerNum) - 1) As String
                    For i As Integer = 0 To attData.Get_ObjectNum(LayerNum) - 1
                        If Cate(i) = -1 Then
                            val(i) = ""
                        Else
                            val(i) = cateStr(Cate(i))
                        End If
                    Next
                    attData.Add_One_Data_Value(LayerNum, tx, unt, note,
                                               val, attData.LayerData(LayerNum).atrData.Data(DataNum).MissingF)
                    Dim newN As Integer = attData.Get_DataNum(LayerNum) - 1
                    With attData.LayerData(LayerNum).atrData.Data(newN).SoloModeViewSettings
                        For j As Integer = 0 To caten - 1
                            .Class_Div(j) = attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.Class_Div(j)
                            .Class_Div(j).Cat_Name = cateStr(j)
                        Next
                    End With
                    clsGeneric.MessageBox(FormStartPosition.CenterParent, tx + "を登録しました。", MessageBoxButtons.OK, MessageBoxIcon.None)
                    Dim frm As frmMain
                    frm = CType(Me.Owner, frmMain)
                    frm.cboDataItem.Items.Add(attData.Get_DataTitle(LayerNum, newN, True))
                    frm.cboDataItem.SelectedIndex = newN
                End If
                form.Dispose()
            Case enmAttDataType.Category
                Dim itm() As String = {"オブジェクトの少ない順", "オブジェクトの多い順", "数字順(0to9)", "数字順(9to0)", "文字コード順(AtoZ)", "文字コード順(ZtoA)", "反転"}
                Dim Seln As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("カテゴリーの並べ替え", itm)
                Dim caten As Integer = attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.Div_Num
                Dim oldDiv() As clsAttrData.strClass_Div_data = attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.Class_Div.Clone
                Dim sort As New clsSortingSearch
                Select Case Seln
                    Case -1
                        Return
                    Case 0, 1
                        Dim freq() As Integer, missFreq As Integer
                        If attData.Get_ClassFrequency(LayerNum, DataNum, False, freq, missFreq) = False Then
                            clsGeneric.MessageBox(FormStartPosition.CenterParent, "区分値が不正です。", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        Else
                            sort.AddRange(freq.Length, freq)
                        End If
                    Case 2, 3
                        sort.AddInit(VariantType.Double)
                        For i As Integer = 0 To caten - 1
                            sort.Add(Val(oldDiv(i).Cat_Name))
                        Next
                        sort.AddEnd()
                    Case 4, 5
                        sort.AddInit(VariantType.String)
                        For i As Integer = 0 To caten - 1
                            sort.Add(oldDiv(i).Cat_Name)
                        Next
                        sort.AddEnd()
                    Case 6
                End Select

                For i As Integer = 0 To caten - 1
                    With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
                        Dim n As Integer
                        Select Case Seln
                            Case 6
                                n = caten - 1 - i
                            Case Else
                                Select Case Seln Mod 2
                                    Case 0
                                        n = sort.DataPosition(i)
                                    Case 1
                                        n = sort.DataPositionRev(i)
                                End Select
                        End Select
                        .Class_Div(i) = oldDiv(n)
                    End With
                Next

                SetPictureBox()
                SetClassDivValueTextBox()
                SetPicClassBoxCursol()
                SetCategorySelector()
                setFrequencyLabel()
        End Select
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Dim tx As String = ""
        Select Case ClassMode
            Case enmSoloMode_Number.ClassPaintMode
                tx = "paintMode"
            Case enmSoloMode_Number.ClassHatchMode
                tx = "hatchMode"
            Case enmSoloMode_Number.ClassMarkMode
                tx = "classsMarkMode"
            Case enmSoloMode_Number.ClassODMode
                tx = "odMode"
        End Select
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, tx)
    End Sub

    Private Sub btColorPattern_Click(sender As Object, e As EventArgs) Handles btColorPattern.Click
        Dim form As New frmMain_PainrColor

        If form.ShowDialog(attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.Div_Num) = Windows.Forms.DialogResult.OK Then
            Dim col() As colorARGB = form.GetResults
            rbSoloColor.Checked = True
            With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
                Dim n As Integer = .Div_Num

                For i As Integer = 0 To n - 1
                    .Class_Div(i).PaintColor = col(i)
                Next
                With .ClassPaintMD
                    .color1 = col(0)
                    .color2 = col(n - 1)
                End With
                SetPictureBox()
            End With
        End If
        form.Dispose()
    End Sub

    Private Sub btnReverseColor_Click(sender As Object, e As EventArgs) Handles btnReverseColor.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            Dim n As Integer = .Div_Num
            Dim col(n - 1) As colorARGB
            For i As Integer = 0 To n - 1
                col(i) = .Class_Div(i).PaintColor
            Next
            For i As Integer = 0 To n - 1
                .Class_Div(i).PaintColor = col(n - 1 - i)
            Next
            With .ClassPaintMD
                .color1 = col(n - 1)
                .color2 = col(0)
            End With
            SetPictureBox()
        End With
    End Sub
    Private Sub btnTransparency_Click(sender As Object, e As EventArgs) Handles btnTransparency.Click
        Dim form As New frmColorTransparency
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            Dim n As Integer = .Div_Num
            Dim ft = 255
            For i As Integer = 0 To n - 1
                ft = Math.Min(.Class_Div(i).PaintColor.a, ft)
            Next
            If form.ShowDialog(ft) = Windows.Forms.DialogResult.OK Then
                Dim t As Integer = form.getResult()
                For i As Integer = 0 To n - 1
                    .Class_Div(i).PaintColor.a = t
                Next
                With .ClassPaintMD
                    .color1.a = t
                    .color2.a = t
                End With
                SetPictureBox()
            End If
            form.Dispose()
        End With
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form As New frmUserClassSettings

        With attData.LayerData(LayerNum).atrData.Data(DataNum)
            If form.ShowDialog(.ModeData, .SoloModeViewSettings) = Windows.Forms.DialogResult.OK Then
                Dim data As Object = form.GetResults()
                If data Is Nothing = False Then
                    Select Case .ModeData
                        Case enmSoloMode_Number.ClassPaintMode
                            Dim cdata As clsSettings.User_ColorChart_Info = DirectCast(data, clsSettings.User_ColorChart_Info)
                            For i As Integer = 0 To .SoloModeViewSettings.Div_Num - 1
                                .SoloModeViewSettings.Class_Div(i).PaintColor = cdata.Color(i)
                            Next
                        Case enmSoloMode_Number.ClassHatchMode
                            Dim cdata As clsSettings.User_TileChart_Info = DirectCast(data, clsSettings.User_TileChart_Info)
                            For i As Integer = 0 To .SoloModeViewSettings.Div_Num - 1
                                .SoloModeViewSettings.Class_Div(i).TilePat = cdata.Tile(i)
                            Next
                        Case enmSoloMode_Number.ClassMarkMode
                            Dim cdata As clsSettings.User_MarkChart_Info = DirectCast(data, clsSettings.User_MarkChart_Info)
                            For i As Integer = 0 To .SoloModeViewSettings.Div_Num - 1
                                .SoloModeViewSettings.Class_Div(i).ClassMark = cdata.Mark(i)
                            Next
                        Case enmSoloMode_Number.ClassODMode
                            Dim cdata As clsSettings.User_LineChart_Info = DirectCast(data, clsSettings.User_LineChart_Info)
                            For i As Integer = 0 To .SoloModeViewSettings.Div_Num - 1
                                .SoloModeViewSettings.Class_Div(i).ODLinePat = cdata.Line(i)
                            Next
                    End Select

                End If
            End If
        End With
        SetPictureBox()
        form.Dispose()
    End Sub


End Class