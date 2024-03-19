Public Class frmMain_GraphModeSettings
    Dim attData As clsAttrData
    Dim LayerNum As Integer
    Dim lastSettingtile As Tile_Property
    Dim PreCol(15) As Color

    Private pnlDataItemBox() As System.Windows.Forms.Panel
    Private picDataItemTile() As System.Windows.Forms.PictureBox
    Private lblDataItemSelect() As Label
    Dim pnlDataItemBoxSelectedindex As Integer
    ''' <summary>
    ''' グラフ表示モードの初期値をコントロールに設定
    ''' </summary>
    ''' <param name="_attData"></param>
    ''' <remarks></remarks>
    Public Sub SetData(ByRef _attData As clsAttrData)
        Me.Tag = "OFF"
        attData = _attData
        LayerNum = attData.TotalData.LV1.SelectedLayer
        AddDataSetToCboBox()
        Me.Tag = ""
        lastSettingtile = clsBase.Tile
        lastSettingtile.Line.Set_Same_Color_to_LinePat(clsBase.ColorWhite)

    End Sub
    Private Sub AddDataSetToCboBox()
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            cboGraphDataSet.Items.Clear()
            For i As Integer = 0 To .Count - 1
                Dim tx As String = .DataSet(i).title
                If tx = "" Then
                    tx = "データセット" + (i + 1).ToString
                End If
                cboGraphDataSet.Items.Add(tx)
            Next
            cboGraphDataSet.SelectedIndex = .SelectedIndex
        End With

    End Sub


    Private Sub txtDataSetTitle_LostFocus(sender As Object, e As EventArgs) Handles txtDataSetTitle.LostFocus

        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            Dim i As Integer = cboGraphDataSet.SelectedIndex
            With .DataSet(i)
                If .title <> txtDataSetTitle.Text Then
                    .title = txtDataSetTitle.Text
                    cboGraphDataSet.Items(i) = .title
                End If
            End With
        End With
    End Sub

    Private Sub btnAddDataSet_Click(sender As Object, e As EventArgs) Handles btnAddDataSet.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            Dim i As Integer = .Count
            .AddDataSet()
            cboGraphDataSet.Items.Add("データセット" + (i + 1).ToString)
            Me.Tag = "OFF"
            cboGraphDataSet.SelectedIndex = i
            Me.Tag = ""
            CType(Me.Owner, frmMain).Check_Print_err()
        End With
    End Sub

    Private Sub cboGraphDataSet_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboGraphDataSet.SelectedIndexChanged

        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            .SelectedIndex = cboGraphDataSet.SelectedIndex
            With .DataSet(.SelectedIndex)
                Me.Tag = "OFF"
                txtDataSetTitle.Text = .title
                Select Case .GraphMode
                    Case enmGraphMode.PieGraph
                        rbPieChart.Checked = True
                    Case enmGraphMode.StackedBarGraph
                        rbStackedBarChart.Checked = True
                    Case enmGraphMode.LineGraph
                        rbLineChart.Checked = True
                    Case enmGraphMode.BarGraph
                        rbBarChart.Checked = True
                End Select
                Me.Tag = ""
            End With
        End With
        SetPnlDataItem()
        SetControlsVisible()
        SetControlsValue()
    End Sub
    ''' <summary>
    ''' データセットのデータ項目のリスト生成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPnlDataItem()
        Dim pnlHeight As Integer = cboGraphDataSet.Height * 1.1
        Dim cboWidth As Integer = pnlDataItem.Width * 0.8
        pnlDataItem.Visible = False

        If Me.pnlDataItemBox Is Nothing = False Then
            For i As Integer = 0 To Me.pnlDataItemBox.Length - 1
                RemoveHandler Me.pnlDataItemBox(i).Click, AddressOf pnlDataItemBox_Click
                RemoveHandler Me.picDataItemTile(i).Click, AddressOf picDataItemTile_Click
                RemoveHandler Me.lblDataItemSelect(i).Click, AddressOf pnlDataItemBox_Click
                Me.pnlDataItemBox(i).Controls.Remove(Me.picDataItemTile(i))
                Me.pnlDataItemBox(i).Controls.Remove(Me.lblDataItemSelect(i))
                Me.pnlDataItem.Controls.Remove(Me.pnlDataItemBox(i))
            Next
        End If

        Dim n As Integer
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                Dim md As enmGraphMode = .GraphMode
                n = .Count
                Me.pnlDataItemBox = New Panel(n - 1) {}
                Me.picDataItemTile = New PictureBox(n - 1) {}
                Me.lblDataItemSelect = New Label(n - 1) {}
                pnlDataItem.Width = pnlDataItemBase.Width - SystemInformation.VerticalScrollBarWidth - 6
                pnlDataItem.Height = (pnlHeight + 2) * n
                For i As Integer = 0 To n - 1
                    Dim GData As clsAttrData.GraphModeDataItem = .Data(i)
                    Me.pnlDataItemBox(i) = New Panel
                    With Me.pnlDataItemBox(i)
                        .Parent = pnlDataItem
                        .Top = (pnlHeight + 2) * i + 1
                        .Left = 3
                        .Width = pnlDataItem.Width - 5
                        .Height = pnlHeight
                        .BorderStyle = BorderStyle.None
                        .Tag = i
                        AddHandler .Click, AddressOf pnlDataItemBox_Click
                    End With
                    Me.lblDataItemSelect(i) = New Label
                    With Me.lblDataItemSelect(i)
                        .Parent = Me.pnlDataItemBox(i)
                        .Top = 2
                        .Left = 4
                        .Width = cboWidth
                        .Tag = i
                        .Height = pnlHeight - 5
                        .Text = attData.Get_DataTitle(LayerNum, GData.DataNumner, True)
                        AddHandler .Click, AddressOf pnlDataItemBox_Click
                    End With
                    Me.picDataItemTile(i) = New PictureBox
                    With Me.picDataItemTile(i)
                        .Parent = Me.pnlDataItemBox(i)
                        .Top = 2
                        .Left = cboWidth + Me.pnlDataItemBox(i).Left + 5
                        .Width = Me.pnlDataItemBox(i).Width - .Left - 5
                        .Height = Me.lblDataItemSelect(i).Height
                        .Tag = i
                        .BorderStyle = BorderStyle.FixedSingle
                        attData.Draw_Sample_TileBox(Me.picDataItemTile(i), GData.Tile)
                        AddHandler .Click, AddressOf picDataItemTile_Click
                        If md = enmGraphMode.LineGraph Then
                            .Visible = False
                        Else
                            .Visible = True
                        End If
                    End With
                Next
            End With
        End With
        pnlDataItem.Visible = True
        If n > 0 Then
            If pnlDataItemBoxSelectedindex >= n Then
                pnlDataItemBoxSelectedindex = n - 1
            End If
            Me.pnlDataItemBox(pnlDataItemBoxSelectedindex).BorderStyle = BorderStyle.FixedSingle
            If pnlDataItemBase.VerticalScroll.Visible = True Then
                pnlDataItemBase.AutoScrollPosition = New Point(0, pnlHeight * pnlDataItemBoxSelectedindex)
            End If
        End If
        culculateRmaxRmin()
    End Sub
    Private Sub culculateRmaxRmin()
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                If .Count = 0 Then
                    Return
                End If
                For j As Integer = 0 To attData.LayerData(LayerNum).atrObject.ObjectNum - 1
                    Dim s As Double = 0
                    For i As Integer = 0 To .Count - 1
                        Dim str As String = attData.Get_Data_Value(LayerNum, .Data(i).DataNumner, j, "")
                        If str <> "" Then
                            s += Val(str)
                        End If
                    Next
                    If j = 0 Then
                        .En_Obi.RMAX = s
                        .En_Obi.RMIN = s
                    Else
                        .En_Obi.RMAX = Math.Max(.En_Obi.RMAX, s)
                        .En_Obi.RMIN = Math.Min(.En_Obi.RMIN, s)
                    End If
                Next
                Dim Max As Double = .En_Obi.RMAX
                Dim min As Double = .En_Obi.RMIN
                Dim ST As Double = 0
                clsGeneric.WIC(10, Max, min, ST)
                Dim DVN As Integer = 0
                Dim zn(15) As Double
                For k As Double = min To Max Step ST
                    If .En_Obi.RMIN < k And k < .En_Obi.RMAX Then
                        zn(DVN) = k
                        DVN += 1
                    End If
                Next
                Dim h1 As Integer, h2 As Integer, h3 As Integer
                Select Case DVN
                    Case 1
                        h1 = 1 : h2 = -1 : h3 = -1
                    Case 2
                        h1 = 1 : h2 = 0 : h3 = -1
                    Case 3
                        h1 = 2 : h2 = 1 : h3 = 0
                    Case 4
                        h1 = 3 : h2 = 1 : h3 = 0
                    Case 5
                        h1 = 4 : h2 = 2 : h3 = 0
                    Case 6
                        h1 = 5 : h2 = 2 : h3 = 0
                    Case Else
                        h1 = DVN - 1
                        h2 = DVN \ 2 - 1
                        h3 = 0
                End Select
                With .En_Obi
                    .Value1 = zn(h1)
                    If h2 = -1 Then
                        .Value2 = 0
                    Else
                        .Value2 = zn(h2)
                    End If
                    If h3 = -1 Then
                        .Value3 = 0
                    Else
                        .Value3 = zn(h3)
                    End If
                    txtLegendValue1.Text = .Value1
                    txtLegendValue2.Text = .Value2
                    txtLegendValue3.Text = .Value3
                    If .MaxValueMode = enmMarkMaxValueType.SelectedDataMax Then
                        .MaxValue = .RMAX
                    End If
                    txtMaxSizeValue.Text = .MaxValue
                End With
            End With
        End With

        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                If .Oresen_Bou.YmaxMinMode = enmBarLineMaxMinMode.Auto Then
                    Dim YMax As Double
                    Dim Ymin As Double
                    For i As Integer = 0 To .Count - 1
                        Dim dn As Integer = .Data(i).DataNumner
                        If i = 0 Then
                            YMax = attData.LayerData(LayerNum).atrData.Data(dn).Statistics.Max
                            Ymin = attData.LayerData(LayerNum).atrData.Data(dn).Statistics.Min
                        Else
                            YMax = Math.Max(YMax, attData.LayerData(LayerNum).atrData.Data(dn).Statistics.Max)
                            Ymin = Math.Min(Ymin, attData.LayerData(LayerNum).atrData.Data(dn).Statistics.Min)
                        End If
                    Next
                    Dim a As Double = Ymin
                    If .GraphMode = enmGraphMode.BarGraph Then
                        If a > 0 Then
                            a = 0
                        End If
                    End If
                    Ymin = a
                    Dim st As Double
                    clsGeneric.WIC(5, YMax, Ymin, st)
                    With .Oresen_Bou
                        .YMax = YMax
                        .Ymin = Ymin
                        .Ystep = st
                    End With
                End If
            End With
        End With

    End Sub

    Private Sub picDataItemTile_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim picDataItemTile_Click As PictureBox = CType(sender, PictureBox)
        Me.pnlDataItemBox(pnlDataItemBoxSelectedindex).BorderStyle = BorderStyle.None
        pnlDataItemBoxSelectedindex = picDataItemTile_Click.Tag
        pnlDataItemBox(pnlDataItemBoxSelectedindex).BorderStyle = BorderStyle.FixedSingle
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                With .Data(pnlDataItemBoxSelectedindex)
                    If attData.Select_Tile(.Tile) = True Then
                        attData.Draw_Sample_TileBox(picDataItemTile_Click, .Tile)
                        lastSettingtile = .Tile
                    End If
                End With
            End With
        End With
    End Sub


    Private Sub pnlDataItemBox_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim n As Integer = Val(sender.tag)
        Me.pnlDataItemBox(pnlDataItemBoxSelectedindex).BorderStyle = BorderStyle.None
        Me.pnlDataItemBox(n).BorderStyle = BorderStyle.FixedSingle
        pnlDataItemBoxSelectedindex = n
    End Sub
    Private Sub btnDeleteDataSet_Click(sender As Object, e As EventArgs) Handles btnDeleteDataSet.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            If .Count = 1 Then
                MsgBox("これ以上削除できません。", MsgBoxStyle.Exclamation)
                Return
            Else
                .RemoveDataSet(.SelectedIndex)
                'Call Remove_OverLay_Data_Item(1, EditedGraphDataStac)
                'Call Remove_Series_Data_Item(0, 1, EditedGraphDataStac)
                .SelectedIndex = Math.Min(.SelectedIndex, .Count - 1)
                AddDataSetToCboBox()
            End If
        End With
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim n As Integer = attData.Get_DataSelect_fromComboBoxForm(LayerNum, True, True, False, False)
        If n = -1 Then
            Return
        Else
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex)
                    Dim ct As Integer = .Count
                    For i As Integer = 0 To ct - 1
                        If .Data(i).DataNumner = n Then
                            MsgBox("選択済みです。", MsgBoxStyle.Exclamation)
                            Return
                        End If
                    Next
                    ReDim Preserve .Data(ct)
                    With .Data(ct)
                        .Tile = clsBase.Tile
                        .Tile.Line.Set_Same_Color_to_LinePat(New colorARGB(PreCol(ct Mod 16)))
                        .DataNumner = n
                    End With
                    pnlDataItemBoxSelectedindex = ct
                    .Count += 1
                    SetPnlDataItem()
                    CType(Me.Owner, frmMain).Check_Print_err()
                End With
            End With
        End If
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                If .Count = 0 Then
                    MsgBox("これ以上削除できません。", MsgBoxStyle.Exclamation)
                    Return
                End If
                For i As Integer = pnlDataItemBoxSelectedindex To .Count - 2
                    .Data(i) = .Data(i + 1)
                Next
                If pnlDataItemBoxSelectedindex = .Count - 1 Then
                    pnlDataItemBoxSelectedindex -= 1
                End If
                .Count -= 1
                If .Count = 0 Then
                    Erase .Data
                Else
                    ReDim Preserve .Data(.Count - 1)
                End If
            End With
            SetPnlDataItem()
        End With
    End Sub

    Private Sub btnAllClear_Click(sender As Object, e As EventArgs) Handles btnAllClear.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                If .Count = 0 Then
                    MsgBox("これ以上削除できません。", MsgBoxStyle.Exclamation)
                    Return
                End If
                .Count = 0
                Erase .Data
            End With
            SetPnlDataItem()
        End With
    End Sub

    Private Sub btnObjUpward_Click(sender As Object, e As EventArgs) Handles btnObjUpward.Click
        Dim os As Integer = pnlDataItemBoxSelectedindex
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                If pnlDataItemBoxSelectedindex = 0 Then
                    pnlDataItemBoxSelectedindex = .Count - 1
                Else
                    pnlDataItemBoxSelectedindex -= 1
                End If
                SwapDataItem(pnlDataItemBoxSelectedindex, os)
            End With
        End With

    End Sub

    Private Sub SwapDataItem(ByVal d1 As Integer, ByVal d2 As Integer)
        Dim GData As clsAttrData.GraphModeDataItem
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                GData = .Data(d1)
                .Data(d1) = .Data(d2)
                .Data(d2) = GData
            End With
        End With
        SetPnlDataItem()
    End Sub

    Private Sub btnObjDownward_Click(sender As Object, e As EventArgs) Handles btnObjDownward.Click
        Dim os As Integer = pnlDataItemBoxSelectedindex
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                If pnlDataItemBoxSelectedindex = .Count - 1 Then
                    pnlDataItemBoxSelectedindex = 0
                Else
                    pnlDataItemBoxSelectedindex += 1
                End If
                SwapDataItem(pnlDataItemBoxSelectedindex, os)
            End With
        End With

    End Sub

    Private Sub rbCharts_CheckedChanged(sender As Object, e As EventArgs) Handles rbLineChart.CheckedChanged,
                rbPieChart.CheckedChanged, rbBarChart.CheckedChanged, rbStackedBarChart.CheckedChanged
        If Me.Tag = "OFF" Or Me.Visible = False Then
            Return
        End If
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                Select Case True
                    Case rbPieChart.Checked
                        .GraphMode = enmGraphMode.PieGraph
                    Case rbStackedBarChart.Checked
                        .GraphMode = enmGraphMode.StackedBarGraph
                    Case rbLineChart.Checked
                        .GraphMode = enmGraphMode.LineGraph
                    Case rbBarChart.Checked
                        .GraphMode = enmGraphMode.BarGraph
                End Select
            End With
        End With
        SetPnlDataItem()
        SetControlsVisible()
        SetControlsValue()
        CType(Me.Owner, frmMain).Check_Print_err()
    End Sub
    Private Sub SetControlsValue()
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            Dim METAG As String = Me.Tag
            Me.Tag = "OFF"
            With .DataSet(.SelectedIndex)
                With .En_Obi
                    If .EnSizeMode = enmGraphMaxSize.Fixed Then
                        rbMaxSizeFixed.Checked = True
                    Else
                        rbMaxSizeNonFixed.Checked = True
                    End If
                    txtMaxSize.Text = .EnSize
                    If .MaxValueMode = enmMarkMaxValueType.SelectedDataMax Then
                        rbMaxSizeValueDataMax.Checked = True
                        txtMaxSizeValue.Enabled = False
                    Else
                        rbMaxSizeValueUserSetting.Checked = True
                        txtMaxSizeValue.Enabled = True
                    End If
                    If .StackedBarDirection = enmStackedBarChart_Direction.Vertical Then
                        rbStackedBarVeritical.Checked = True
                    Else
                        rbStackedBarHorizontal.Checked = True
                    End If
                    txtMaxSizeValue.Text = .MaxValue
                    txtLegendValue1.Text = .Value1
                    txtLegendValue2.Text = .Value2
                    txtLegendValue3.Text = .Value3
                    txtStackedBarAspectRatio.Text = .AspectRatio

                End With
                With .Oresen_Bou
                    txtBarLineSize.Text = .Size
                    txtLineBarAspectRatio.Text = .AspectRatio

                    attData.Draw_Sample_TileBox(picLineBarBackGroundTile, .BackgroundTile)
                    attData.Draw_Sample_LineBox(picLineBarBorderLine, .BorderLine)
                    If .YmaxMinMode = enmBarLineMaxMinMode.Auto Then
                        rbAuto.Checked = True
                        pnlMaxMinValue.Enabled = False
                    Else
                        rbManual.Checked = True
                        pnlMaxMinValue.Enabled = True
                    End If
                    txtMaxValue.Text = .YMax
                    txtMinValue.Text = .Ymin
                End With
                If .GraphMode = enmGraphMode.PieGraph Or .GraphMode = enmGraphMode.StackedBarGraph Then
                    attData.Draw_Sample_LineBox(picLinePattern, .En_Obi.BoaderLine)
                Else
                    attData.Draw_Sample_LineBox(picLinePattern, .Oresen_Bou.Line)
                End If
            End With
            Me.Tag = METAG
        End With
    End Sub
    ''' <summary>
    ''' グラフモードに対応したコントロールを表示／非表示する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetControlsVisible()
        Dim gbMaxSize_Visible As Boolean
        Dim gbMaxSizeValue_Visible As Boolean
        Dim gbBarLineSize_Visible As Boolean
        Dim gbFrame_Visible As Boolean
        Dim gbLegendValue_Visible As Boolean
        Dim gbTateYokoHi_Visible As Boolean
        Dim gbStackedBarView_Visible As Boolean
        Dim gbMaxMinValue_Visible As Boolean

        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                Select Case .GraphMode
                    Case enmGraphMode.PieGraph, enmGraphMode.StackedBarGraph
                        gbMaxSize_Visible = True
                        If .En_Obi.EnSizeMode = enmGraphMaxSize.Fixed Then
                            gbMaxSizeValue_Visible = False
                            gbLegendValue_Visible = False
                        Else
                            gbMaxSizeValue_Visible = True
                            gbLegendValue_Visible = True
                        End If
                        If .GraphMode = enmGraphMode.StackedBarGraph Then
                            gbStackedBarView_Visible = True
                        Else
                            gbStackedBarView_Visible = False
                        End If
                        gbBarLineSize_Visible = False
                        gbFrame_Visible = False
                        gbTateYokoHi_Visible = False
                        btnSetSameHatch.Visible = False
                        gbMaxMinValue_Visible = False
                    Case enmGraphMode.LineGraph, enmGraphMode.BarGraph
                        gbMaxSize_Visible = False
                        gbMaxSizeValue_Visible = False
                        gbLegendValue_Visible = False
                        gbBarLineSize_Visible = True
                        gbTateYokoHi_Visible = True
                        gbFrame_Visible = True
                        If .GraphMode = enmGraphMode.LineGraph Then
                            btnSetSameHatch.Visible = False
                        Else
                            btnSetSameHatch.Visible = True
                        End If
                        gbMaxMinValue_Visible = True
                End Select
            End With
        End With
        gbMaxSize.Visible = gbMaxSize_Visible
        gbMaxSizeValue.Visible = gbMaxSizeValue_Visible
        gbBarLineSize.Visible = gbBarLineSize_Visible
        gbFrame.Visible = gbFrame_Visible
        gbLegendValue.Visible = gbLegendValue_Visible
        gbTateYokoHi.Visible = gbTateYokoHi_Visible
        gbStackedBarView.Visible = gbStackedBarView_Visible
        gbMaxMinValue.Visible = gbMaxMinValue_Visible

    End Sub
    Private Sub frmMain_GraphModeSettings_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim frm As frmMain
            frm = CType(Me.Owner, frmMain)
            frm.btnDraw.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub frmMain_GraphModeSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim L As Integer = gbMaxSize.Left
        gbBarLineSize.Left = L
        gbTateYokoHi.Left = L
        gbFrame.Left = L
        btnSetSameHatch.Top = gbStackedBarView.Top
        gbGraphSettings.Width = L + gbMaxSize.Width + gbGraphMode.Left
        gbMaxMinValue.Left = btnSetSameHatch.Left
        gbMaxMinValue.Top = btnSetSameHatch.Top + btnSetSameHatch.Height + 5
        Me.Width = gbGraphSettings.Left + gbGraphSettings.Width + gbDataItems.Left * 2

        PreCol(0) = Color.Red
        PreCol(1) = Color.Blue
        PreCol(2) = Color.Yellow
        PreCol(3) = Color.Lime
        PreCol(4) = Color.Aqua
        PreCol(5) = Color.Purple
        PreCol(6) = Color.White
        PreCol(7) = Color.Gray
        PreCol(8) = Color.Black
        Dim n As Integer = 9
        For i As Integer = 7 To 13
            PreCol(n) = ColorTranslator.FromOle(QBColor(i - 7 + 1))
            n += 1
        Next

    End Sub

    Private Sub picLinePattern_Click(sender As Object, e As EventArgs) Handles picLinePattern.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                Select Case .GraphMode
                    Case enmGraphMode.PieGraph, enmGraphMode.StackedBarGraph
                        attData.Select_Line_Pattern(picLinePattern, .En_Obi.BoaderLine, True)
                    Case enmGraphMode.BarGraph, enmGraphMode.LineGraph
                        attData.Select_Line_Pattern(picLinePattern, .Oresen_Bou.Line, True)
                End Select
            End With
        End With
    End Sub

    Private Sub txtStackedBarAspectRatio_LostFocus(sender As Object, e As EventArgs) Handles txtStackedBarAspectRatio.LostFocus
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex).En_Obi
                .AspectRatio = Val(txtStackedBarAspectRatio.Text)
                txtStackedBarAspectRatio.Text = .AspectRatio
            End With
        End With
    End Sub

    Private Sub rbStackedBarHorizontal_CheckedChanged(sender As Object, e As EventArgs) Handles rbStackedBarHorizontal.CheckedChanged, rbStackedBarVeritical.CheckedChanged
        If Me.Tag = "" Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex).En_Obi
                    Select Case True
                        Case rbStackedBarHorizontal.Checked
                            .StackedBarDirection = enmStackedBarChart_Direction.Horizontal
                        Case rbStackedBarVeritical.Checked
                            .StackedBarDirection = enmStackedBarChart_Direction.Vertical
                    End Select
                End With
            End With
        End If

    End Sub

    Private Sub rbMaxSizeFixed_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxSizeFixed.CheckedChanged, rbMaxSizeNonFixed.CheckedChanged
        If Me.Tag = "" Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex).En_Obi
                    Select Case True
                        Case rbMaxSizeFixed.Checked
                            .EnSizeMode = enmGraphMaxSize.Fixed
                        Case rbMaxSizeNonFixed.Checked
                            .EnSizeMode = enmGraphMaxSize.Changeable
                    End Select
                End With
                SetControlsVisible()
            End With
        End If
    End Sub


    Private Sub txtMaxSize_LostFocus(sender As Object, e As EventArgs) Handles txtMaxSize.LostFocus
        If Me.Tag = "" Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex).En_Obi
                    .EnSize = Val(txtMaxSize.Text)
                    txtMaxSize.Text = .EnSize
                End With
            End With
        End If
    End Sub

    Private Sub txtMaxSizeValue_LostFocus(sender As Object, e As EventArgs) Handles txtMaxSizeValue.LostFocus
        If Me.Tag = "" Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex).En_Obi
                    .MaxValue = Val(txtMaxSizeValue.Text)
                    txtMaxSizeValue.Text = .MaxValue
                End With
            End With
        End If

    End Sub

    Private Sub txtLegendValue_LostFocus(sender As Object, e As EventArgs) Handles txtLegendValue1.LostFocus, txtLegendValue2.LostFocus, txtLegendValue3.LostFocus
        If Me.Tag = "" Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex).En_Obi

                    Dim tx As TextNumberBox = CType(sender, TextNumberBox)
                    Select Case tx.Tag
                        Case "1"
                            .Value1 = Val(tx.Text)
                            tx.Text = .Value1
                        Case "2"
                            .Value2 = Val(tx.Text)
                            tx.Text = .Value2
                        Case "3"
                            .Value3 = Val(tx.Text)
                            tx.Text = .Value3
                    End Select

                End With
            End With
        End If
    End Sub

    Private Sub txtBarLineSize_LostFocus(sender As Object, e As EventArgs) Handles txtBarLineSize.LostFocus
        If Me.Tag = "" Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex).Oresen_Bou
                    .Size = Val(txtBarLineSize.Text)
                    txtBarLineSize.Text = .Size
                End With
            End With
        End If
    End Sub

    Private Sub txtLineBarAspectRatio_LostFocus(sender As Object, e As EventArgs) Handles txtLineBarAspectRatio.LostFocus
        If Me.Tag = "" Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex).Oresen_Bou
                    .AspectRatio = Val(txtLineBarAspectRatio.Text)
                    txtLineBarAspectRatio.Text = .AspectRatio
                End With
            End With
        End If
    End Sub

    Private Sub picLineBarBorderLine_Click(sender As Object, e As EventArgs) Handles picLineBarBorderLine.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex).Oresen_Bou
                attData.Select_Line_Pattern(picLineBarBorderLine, .BorderLine, True)
            End With
        End With

    End Sub

    Private Sub picLineBarBackGroundTile_Click(sender As Object, e As EventArgs) Handles picLineBarBackGroundTile.Click
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex).Oresen_Bou
                attData.Select_Tile(picLineBarBackGroundTile, .BackgroundTile)
            End With
        End With
    End Sub

    Private Sub rbMaxSizeValueDataMax_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxSizeValueDataMax.CheckedChanged, rbMaxSizeValueUserSetting.CheckedChanged
        If Me.Tag = "" Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex).En_Obi
                    Select Case True
                        Case rbMaxSizeValueDataMax.Checked
                            .MaxValueMode = enmMarkMaxValueType.SelectedDataMax
                            txtMaxSizeValue.Enabled = False
                        Case rbMaxSizeValueUserSetting.Checked
                            .MaxValueMode = enmMarkMaxValueType.UserSettingValue
                            txtMaxSizeValue.Enabled = True
                    End Select
                End With
                SetControlsVisible()
                culculateRmaxRmin()
            End With
        End If
    End Sub

    Private Sub btnSetSameHatch_Click(sender As Object, e As EventArgs) Handles btnSetSameHatch.Click
        If attData.Select_Tile(lastSettingtile) = True Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex)
                    For i As Integer = 0 To .Count - 1
                        .Data(i).Tile = lastSettingtile
                        attData.Draw_Sample_TileBox(picDataItemTile(i), lastSettingtile)
                    Next
                End With
            End With

        End If
    End Sub

    Private Sub btnAddRange_Click(sender As Object, e As EventArgs) Handles btnAddRange.Click
        Dim n As Integer = attData.Get_DataNum(LayerNum)
        Dim selected(n - 1) As Boolean
        With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
            With .DataSet(.SelectedIndex)
                For i As Integer = 0 To .Count - 1
                    selected(.Data(i).DataNumner) = True
                Next
                If attData.Get_DataSelect_from_ListBoxSelectForm(LayerNum, selected, True, True, False, False) = True Then
                    .Count = clsGeneric.Count_Specified_Value_Array(selected, True)
                    ReDim Preserve .Data(Math.Max(.Count - 1, 0))
                    Dim j As Integer = 0
                    For i As Integer = 0 To n - 1
                        If selected(i) = True Then
                            With .Data(j)
                                .Tile = clsBase.Tile
                                .Tile.Line.Set_Same_Color_to_LinePat(New colorARGB(PreCol(j Mod 16)))
                                .DataNumner = i
                            End With
                            j += 1
                        End If
                    Next
                    pnlDataItemBoxSelectedindex = 0
                    SetPnlDataItem()
                    CType(Me.Owner, frmMain).Check_Print_err()
                End If
            End With
        End With

    End Sub

   


    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "graphMode", Me)
    End Sub

    Private Sub rbAuto_CheckedChanged(sender As Object, e As EventArgs) Handles rbAuto.CheckedChanged, rbManual.CheckedChanged
        If Me.Tag = "" Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex).Oresen_Bou
                    Select Case True
                        Case rbAuto.Checked
                            .YmaxMinMode = enmBarLineMaxMinMode.Auto
                            pnlMaxMinValue.Enabled = False
                            culculateRmaxRmin()
                            txtMaxValue.Text = .YMax
                            txtMinValue.Text = .Ymin
                        Case rbManual.Checked
                            .YmaxMinMode = enmBarLineMaxMinMode.Manual
                            pnlMaxMinValue.Enabled = True
                    End Select
                End With
            End With
        End If
    End Sub

    Private Sub txtMaxValue_LostFocus(sender As Object, e As EventArgs) Handles txtMaxValue.LostFocus
        If Me.Tag = "" Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex).Oresen_Bou
                    .YMax = Val(txtMaxValue.Text)
                    txtMaxValue.Text = .YMax
                    If .Ymin >= .YMax Then
                        .Ymin = .YMax - 1
                        txtMinValue.Text = .Ymin
                    End If
                    .Ystep = (.YMax - .Ymin) / 5
                End With
            End With
        End If
    End Sub



    Private Sub txtMinValue_LostFocus(sender As Object, e As EventArgs) Handles txtMinValue.LostFocus
        If Me.Tag = "" Then
            With attData.LayerData(LayerNum).LayerModeViewSettings.GraphMode
                With .DataSet(.SelectedIndex).Oresen_Bou
                    .Ymin = Val(txtMinValue.Text)
                    txtMinValue.Text = .Ymin
                    If .Ymin >= .YMax Then
                        .YMax = .Ymin + 1
                        txtMaxValue.Text = .YMax
                    End If
                    .Ystep = (.YMax - .Ymin) / 5
                End With
            End With
        End If
    End Sub

    Private Sub txtMaxValue_TextChanged_1(sender As Object, e As EventArgs) Handles txtMaxValue.TextChanged

    End Sub
    Private Sub txtMaxValue_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class