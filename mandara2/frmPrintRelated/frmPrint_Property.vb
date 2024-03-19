Public Class frmPrint_Property
    Private Enum enmPropertyMode
        solo
        multi
        overlay
        trip
    End Enum
    Dim Mode As enmPropertyMode




    Private Sub frmPrint_Property_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Dim frm As frmPrint = CType(Me.Owner, frmPrint)
            frm.mnuPropertyWindow.Checked = False
            If Mode = enmPropertyMode.multi Then
                CType(Me.Owner, frmPrint).EndMultiObjectSelectMode()
            End If
        End If
        clsSettings.Data.print_Property_Rect = New Rectangle(Me.Location, Me.Size)

    End Sub

    Public Sub Fixed(ByVal f As Boolean)
        If f = True Then
            SplitContainer1.BorderStyle = BorderStyle.FixedSingle
        Else
            SplitContainer1.BorderStyle = BorderStyle.None
        End If
        btnCopy.Enabled = f
    End Sub

    Private Sub frmPrint_Property_Load(sender As Object, e As EventArgs) Handles Me.Load

        'ディスプレイの高さと幅を取得
        Dim s As System.Windows.Forms.Screen = System.Windows.Forms.Screen.FromControl(Me)
        Dim w As Integer = s.Bounds.Width
        Dim locleft As Integer
        Dim loctop As Integer
        Dim fw As Integer = 200
        Dim fh As Integer = Me.Owner.Height
        If clsSettings.Data.print_Property_Rect.Width = 0 Then
            locleft = Me.Owner.Left + Me.Owner.Width
            If locleft + Me.Width > w Then
                locleft = w - Me.Width
            End If
            loctop = Me.Owner.Top
        Else
            With clsSettings.Data.print_Property_Rect
                fw = .Width
                fh = .Height
                locleft = .Left
                loctop = .Top
            End With
        End If
        Me.Location = New Point(locleft, loctop)
        Me.Size = New Size(fw, fh)

        pnlProperty.Parent = SplitContainer1.Panel1
        pnlMultiObjectSelect.Dock = DockStyle.Fill
        pnlProperty.Dock = DockStyle.Fill
        pnlOverLayProperty.Parent = SplitContainer1.Panel1
        pnlOverLayProperty.Dock = DockStyle.Fill
        pnlMultiObjectSelect.Visible = False
        pnlProperty.Visible = False
        pnlOverLayProperty.Visible = False
        btnCopy.Enabled = False
        Me.SplitContainer1.SplitterDistance = Me.SplitContainer1.Height - btnCopy.Height * 1.5

    End Sub

    ''' <summary>
    ''' 重ね合わせモード
    ''' </summary>
    ''' <param name="lblTxt"></param>
    ''' <remarks></remarks>
    Public Sub ShowOverLayObjectProperty(ByVal lblTxt As String)
        Mode = enmPropertyMode.overlay
        pnlProperty.Visible = False
        pnlMultiObjectSelect.Visible = False
        If lblTxt <> "" Then
            txtOverLayProperty.Text = lblTxt
            pnlOverLayProperty.Visible = True
        Else
            pnlOverLayProperty.Visible = False
        End If
    End Sub
    ''' <summary>
    ''' 移動表示モード
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="Obj"></param>
    ''' <param name="DataNumber"></param>
    ''' <remarks></remarks>
    Public Sub ShowTripModeProperty(ByRef attrData As clsAttrData, ByVal LayerNum As Integer, ByRef Obj As List(Of frmPrint.strLocationSearchObject), ByVal DataNumber As Integer)
        Mode = enmPropertyMode.trip
        Static firstF As Boolean = True
        lblObjName.Text = ""
        lblSoloModeValue.Text = ""

        With ktGridValue
            Dim n As Integer = attrData.Get_DataNum(LayerNum) + 3
            .init("データ", "移動主体", "データ", 1, 0, 1, 0, True, True, True, False, False, False, False, False, False, False)
            .AddLayer("", 0, Obj.Count, n)
            .FixedUpperLeftData(0, 0, 0) = ""
            For j As Integer = 0 To Obj.Count - 1
                .FixedYSData(0, j, 0) = attrData.Get_KenObjName(LayerNum, Obj(j).ObjNumber)
            Next
            .FixedXSData(0, 0, 0) = "滞在地"
            .FixedXSData(0, 0, 1) = "到着時間"
            .FixedXSData(0, 0, 2) = "出発時間"
            .FixedXSAllignment(0, 0) = HorizontalAlignment.Left
            .FixedXSWidth(0, 0) = 100
            For i As Integer = 0 To Obj.Count - 1
                .GridAlligntment(0, i) = HorizontalAlignment.Left
                .GridWidth(0, i) = 200
            Next
            For i As Integer = 0 To attrData.Get_DataNum(LayerNum) - 1
                .FixedXSData(0, 0, i + 3) = attrData.Get_DataTitle(LayerNum, i, False)
            Next
            For i As Integer = 0 To Obj.Count - 1
                Dim objn As Integer = Obj(i).ObjNumber
                With attrData.LayerData(LayerNum).atrObject.TripObjData(objn)
                    Select Case attrData.LayerData(LayerNum).TripType
                        Case clsAttrData.enmTripPositionType.ObjectSet
                            ktGridValue.GridData(0, i, 0) = .PositionObjName
                        Case clsAttrData.enmTripPositionType.LatLon
                            ktGridValue.GridData(0, i, 0) = .LatLon.Longitude.ToString + "/" + .LatLon.Latitude.ToString
                    End Select
                    ktGridValue.GridData(0, i, 1) = .ArrivalTime.ToString("yyyy/MM/dd HH:mm ss")
                    ktGridValue.GridData(0, i, 2) = .DepartureTime.ToString("yyyy/MM/dd HH:mm ss")
                End With
                For j As Integer = 0 To attrData.Get_DataNum(LayerNum) - 1
                    .GridData(0, i, j + 3) = attrData.Get_Data_Value(LayerNum, j, objn, "")
                Next
            Next
            .Show()
        End With
        firstF = False
        pnlMultiObjectSelect.Visible = False
        pnlOverLayProperty.Visible = False
        pnlProperty.Visible = True
        pnlProperty.Refresh()
    End Sub
    ''' <summary>
    ''' 単独表示モード
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="objNumber"></param>
    ''' <param name="DataNumber"></param>
    ''' <param name="LayerMode"></param>
    ''' <remarks></remarks>
    Public Sub ShowOneObjectProperty(ByRef attrData As clsAttrData, ByVal LayerNum As Integer, ByVal objNumber As Integer, ByVal DataNumber As Integer,
                                  ByVal LayerMode As enmLayerMode_Number)
        Mode = enmPropertyMode.solo
        Static firstF As Boolean = True
        Static o_ModeLayer As enmLayerMode_Number
        Static o_Graphmode As enmGraphMode
        Dim SoloProperty As String = ""

        lblObjName.Text = attrData.Get_KenObjName(LayerNum, objNumber)
        With attrData.LayerData(LayerNum)
            If o_ModeLayer <> LayerMode Then
                firstF = True
            End If
            Select Case LayerMode
                Case enmLayerMode_Number.SoloMode
                    '単独表示
                    If DataNumber <> -1 Then
                        SoloProperty = attrData.getOneObjectPanelLabelString(LayerNum, DataNumber, objNumber, vbCrLf + " ")
                    End If
                    With ktGridValue
                        Dim w0 As Integer = 100
                        Dim w1 As Integer = 100
                        Dim w2 As Integer = 50
                        If firstF = False Then
                            w0 = .FixedXSWidth(0, 0)
                            w1 = .GridWidth(0, 0)
                            w2 = .GridWidth(0, 1)
                        End If
                        Dim n As Integer = attrData.Get_DataNum(LayerNum)
                        .init("データ", "属性データ", "値", 1, 0, 1, 0, False, True, False, False, False, False, False, False, False, False)
                        .AddLayer("", 0, 2, n)
                        For i As Integer = 0 To n - 1
                            .FixedXSData(0, 0, i) = attrData.Get_DataTitle(LayerNum, i, True)
                            .GridData(0, 0, i) = attrData.Get_Data_Value(LayerNum, i, objNumber, "")
                            .GridData(0, 1, i) = attrData.Get_DataUnit(LayerNum, i)
                        Next
                        .FixedXSWidth(0, 0) = w0
                        .FixedXSAllignment(0, 0) = HorizontalAlignment.Left
                        .GridWidth(0, 0) = w1
                        .GridWidth(0, 1) = w2
                        .GridAlligntment(0, 0) = HorizontalAlignment.Left
                        .GridAlligntment(0, 1) = HorizontalAlignment.Left
                        .FixedUpperLeftData(0, 0, 0) = "データ項目"
                        .FixedYSData(0, 0, 0) = "値"
                        .FixedYSData(0, 1, 0) = "単位"
                        .Show()
                    End With

                Case enmLayerMode_Number.GraphMode
                    'グラフ表示
                    Dim Dset As Integer = .LayerModeViewSettings.GraphMode.SelectedIndex
                    Dim n As Integer = .LayerModeViewSettings.GraphMode.DataSet(Dset).Count
                    If n = 0 Then
                        firstF = True
                        pnlProperty.Visible = False
                        Return
                    End If
                    Dim DataItem() As clsAttrData.GraphModeDataItem = .LayerModeViewSettings.GraphMode.DataSet(Dset).Data
                    If o_Graphmode <> .LayerModeViewSettings.GraphMode.DataSet(Dset).GraphMode Then
                        firstF = True
                    End If
                    Select Case .LayerModeViewSettings.GraphMode.DataSet(Dset).GraphMode
                        Case enmGraphMode.PieGraph, enmGraphMode.StackedBarGraph
                            Dim w0 As Integer = 100
                            Dim w1 As Integer = 75
                            Dim w2 As Integer = 75
                            With ktGridValue
                                If firstF = False Then
                                    w0 = .FixedXSWidth(0, 0)
                                    w1 = .GridWidth(0, 0)
                                    w2 = .GridWidth(0, 1)
                                End If
                                .init("データ", "属性データ", "値", 1, 0, 1, 0, False, True, False, False, False, False, False, False, False, False)
                                .AddLayer("", 0, 2, n + 1)
                                Dim sum As Double = 0
                                Dim v(n) As Double
                                For i As Integer = 0 To n - 1
                                    .FixedXSData(0, 0, i) = attrData.Get_DataTitle(LayerNum, DataItem(i).DataNumner, True)
                                    Dim tx As String = attrData.Get_Data_Value(LayerNum, DataItem(i).DataNumner, objNumber, "")
                                    .GridData(0, 0, i) = tx
                                    v(i) = Val(tx)
                                    sum += v(i)
                                Next
                                .FixedXSData(0, 0, n) = "合計"
                                .GridData(0, 0, n) = sum.ToString
                                v(n) = sum
                                For i As Integer = 0 To n
                                    Dim per As Single = v(i) / sum * 100
                                    Dim s As String = Format(per, "0.00")
                                    .GridData(0, 1, i) = s
                                Next
                                .FixedXSWidth(0, 0) = w0
                                .GridWidth(0, 0) = w1
                                .GridWidth(0, 1) = w2
                                .FixedXSAllignment(0, 0) = HorizontalAlignment.Left
                                .GridAlligntment(0, 0) = HorizontalAlignment.Right
                                .GridAlligntment(0, 1) = HorizontalAlignment.Right
                                .FixedUpperLeftData(0, 0, 0) = "データ項目"
                                .FixedYSData(0, 0, 0) = "値(" + attrData.Get_DataUnit(LayerNum, DataItem(0).DataNumner) + ")"
                                .FixedYSData(0, 1, 0) = "割合(%)"
                                .Show()
                            End With
                        Case enmGraphMode.LineGraph, enmGraphMode.BarGraph
                            Dim w0 As Integer = 100
                            Dim w1 As Integer = 100
                            With ktGridValue
                                If firstF = False Then
                                    w0 = .FixedXSWidth(0, 0)
                                    w1 = .GridWidth(0, 0)
                                End If
                                .init("データ", "属性データ", "値", 1, 0, 1, 0, False, True, False, False, False, False, False, False, False, False)
                                .AddLayer("", 0, 1, n + 4)
                                Dim sum As Double = 0
                                Dim v(n - 1) As Double
                                For i As Integer = 0 To n - 1
                                    .FixedXSData(0, 0, i) = attrData.Get_DataTitle(LayerNum, DataItem(i).DataNumner, True)
                                    Dim tx As String = attrData.Get_Data_Value(LayerNum, DataItem(i).DataNumner, objNumber, "")
                                    .GridData(0, 0, i) = tx
                                    v(i) = Val(tx)
                                    sum += v(i)
                                Next
                                Array.Sort(v)
                                .FixedXSData(0, 0, n) = "合計"
                                .FixedXSData(0, 0, n + 1) = "平均値"
                                .FixedXSData(0, 0, n + 2) = "最大値"
                                .FixedXSData(0, 0, n + 3) = "最小値"
                                .GridData(0, 0, n) = sum.ToString
                                .GridData(0, 0, n + 1) = Format(sum / n, "0.0000")
                                .GridData(0, 0, n + 2) = v(n - 1).ToString
                                .GridData(0, 0, n + 3) = v(0).ToString

                                .FixedXSWidth(0, 0) = w0
                                .GridWidth(0, 0) = w1
                                .FixedXSAllignment(0, 0) = HorizontalAlignment.Left
                                .GridAlligntment(0, 0) = HorizontalAlignment.Right
                                .FixedUpperLeftData(0, 0, 0) = "データ項目"
                                .FixedYSData(0, 0, 0) = "値" + attrData.Get_DataUnit_With_Kakko(LayerNum, DataItem(0).DataNumner)
                                .Show()
                            End With
                    End Select
                    o_Graphmode = .LayerModeViewSettings.GraphMode.DataSet(Dset).GraphMode
                Case enmLayerMode_Number.LabelMode
                    'ラベル表示
                    Dim Dset As Integer = .LayerModeViewSettings.LabelMode.SelectedIndex
                    Dim n As Integer = .LayerModeViewSettings.LabelMode.DataSet(Dset).CountOfDataItem
                    If n = 0 Then
                        firstF = True
                        pnlProperty.Visible = False

                        Return
                    End If
                    Dim DataItem() As Integer = .LayerModeViewSettings.LabelMode.DataSet(Dset).DataItem

                    Dim w0 As Integer = 100
                    Dim w1 As Integer = 75
                    Dim w2 As Integer = 75
                    With ktGridValue
                        If firstF = False Then
                            w0 = .FixedXSWidth(0, 0)
                            w1 = .GridWidth(0, 0)
                            w2 = .GridWidth(0, 1)
                        End If
                        .init("データ", "属性データ", "値", 1, 0, 1, 0, False, True, False, False, False, False, False, False, False, False)
                        .AddLayer("", 0, 2, n)
                        Dim sum As Double = 0
                        For i As Integer = 0 To n - 1
                            .FixedXSData(0, 0, i) = attrData.Get_DataTitle(LayerNum, DataItem(i), True)
                            .GridData(0, 0, i) = attrData.Get_Data_Value(LayerNum, DataItem(i), objNumber, "")
                            .GridData(0, 1, i) = attrData.Get_DataUnit(LayerNum, DataItem(i))
                        Next
                        .FixedXSWidth(0, 0) = w0
                        .GridWidth(0, 0) = w1
                        .GridWidth(0, 1) = w2
                        .FixedXSAllignment(0, 0) = HorizontalAlignment.Left
                        .GridAlligntment(0, 0) = HorizontalAlignment.Right
                        .GridAlligntment(0, 1) = HorizontalAlignment.Left
                        .FixedUpperLeftData(0, 0, 0) = "データ項目"

                        .FixedYSData(0, 0, 0) = "値"
                        .FixedYSData(0, 1, 0) = "単位"
                        .Show()
                    End With
                Case enmLayerMode_Number.TripMode
            End Select
            o_ModeLayer = .Print_Mode_Layer
        End With

        If SoloProperty <> "" Then
            Dim lblSoloModeValue_rows As Integer = clsGeneric.CountChar(SoloProperty, vbCr) + 1
            lblSoloModeValue.Height = lblSoloModeValue_rows * 23
            lblSoloModeValue.Text = SoloProperty
            lblSoloModeValue.Visible = True
        Else
            lblSoloModeValue.Visible = False
        End If
        firstF = False
        pnlOverLayProperty.Visible = False
        pnlMultiObjectSelect.Visible = False
        pnlProperty.Visible = True
        pnlProperty.Refresh()
    End Sub
    ''' <summary>
    ''' 複数オブジェクト選択
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="objNumber"></param>
    ''' <remarks></remarks>
    Public Sub ShowMultiObjectInformation(ByRef attrData As clsAttrData, ByVal objNumber As List(Of Integer))
        Mode = enmPropertyMode.multi
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim SelObj As Integer = objNumber.Count
        Dim ShowAllData As Boolean = chkShowAllData.Checked
        Dim ShowData As New List(Of Integer)
        If chkShowAllData.Checked = False Then
            ShowData.Add(attrData.LayerData(LayerNum).atrData.SelectedIndex)
        Else
            For i As Integer = 0 To attrData.Get_DataNum(LayerNum) - 1
                ShowData.Add(i)
            Next
        End If

        With ktGridMultiObj
            Dim YHeader As String() = {"データの種類", "選択オブジェクト数", "非欠損値オブジェクト数", "欠損値オブジェクト数", "単位", "最大値", "最小値", "合計値", "平均値", "中央値", "標準偏差", "分散"}
            .init("データ", "オブジェクト", "値", 1, 0, 1, 0, True, True, False, False, False, False, False, False, False, False)
            .AddLayer("", 0, ShowData.Count, SelObj + YHeader.Length)
            .FixedUpperLeftData(0, 0, 0) = "データ項目"
            .FixedXSAllignment(0, 0) = HorizontalAlignment.Left
            .FixedXSWidth(0, 0) = 120
            For i As Integer = 0 To ShowData.Count - 1
                .GridWidth(0, i) = 120
            Next
            For i As Integer = 0 To YHeader.Length - 1
                .FixedXSData(0, 0, i) = YHeader(i)
            Next
            For i As Integer = 0 To SelObj - 1
                .FixedXSData(0, 0, i + YHeader.Length) = attrData.Get_KenObjName(LayerNum, objNumber(i))
                .FixedXSColor(0, 0, i + YHeader.Length) = Color.AliceBlue
            Next


            For k As Integer = 0 To ShowData.Count - 1
                Dim DataNum As Integer = ShowData(k)
                Dim DT() As String = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, DataNum, "")
                Dim Mis() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, DataNum)

                .FixedYSData(0, k, 0) = attrData.Get_DataTitle(LayerNum, DataNum, False)
                Dim DataType As enmAttDataType = attrData.Get_DataType(LayerNum, DataNum)

                For i As Integer = 0 To SelObj - 1
                    .GridData(0, k, i + YHeader.Length) = DT(objNumber(i))
                Next


                Dim misNum As Integer = 0
                For i As Integer = 0 To SelObj - 1
                    If Mis(objNumber(i)) = True Then
                        misNum += 1
                    End If
                Next
                Dim EDataNum As Integer = SelObj - misNum

                Dim YStat As New List(Of String)
                YStat.Add(clsGeneric.ConvertAttDataTypeString(DataType))
                YStat.Add(SelObj)
                YStat.Add(EDataNum)
                YStat.Add(misNum)
                YStat.Add(attrData.Get_DataUnit(LayerNum, DataNum))
                Select Case DataType
                    Case enmAttDataType.Category, enmAttDataType.Strings
                        .GridAlligntment(0, k) = HorizontalAlignment.Left
                    Case enmAttDataType.Normal
                        .GridAlligntment(0, k) = HorizontalAlignment.Right
                        If EDataNum > 0 Then
                            Dim Add As Double = 0
                            Dim Add2 As Double = 0
                            Dim Max As Double = attrData.LayerData(LayerNum).atrData.Data(DataNum).Statistics.Min
                            Dim Min As Double = attrData.LayerData(LayerNum).atrData.Data(DataNum).Statistics.Max
                            Dim medianData As New clsSortingSearch(VariantType.Double)
                            For i As Integer = 0 To SelObj - 1
                                If Mis(i) = False Then
                                    Dim v As Double = Val(DT(objNumber(i)))
                                    Add += v
                                    Add2 += +v * v
                                    Max = Math.Max(Max, v)
                                    Min = Math.Min(Min, v)
                                    medianData.Add(v)
                                End If
                            Next
                            '中央値
                            medianData.AddEnd()
                            Dim medV As Double
                            If EDataNum Mod 2 = 1 Then
                                '奇数個の場合
                                medV = medianData.DataPositionRevValue_double(EDataNum \ 2)
                            Else
                                '偶数個の場合
                                medV = (medianData.DataPositionRevValue_double(EDataNum \ 2 - 1) + medianData.DataPositionRevValue_double(EDataNum \ 2)) / 2
                            End If
                            YStat.Add(Max)
                            YStat.Add(Min)
                            YStat.Add(Add)
                            Dim ave As Double = Add / EDataNum
                            YStat.Add(ave)
                            YStat.Add(medV)
                            Dim sa As Double = Max - Min
                            Dim STD As Double = Math.Sqrt(Add2 / EDataNum - ave * ave)
                            YStat.Add(STD)
                            YStat.Add(STD ^ 2)
                        End If
                End Select
                For i As Integer = 0 To YStat.Count - 1
                    .GridData(0, k, i) = YStat(i)
                Next
            Next
            .Show()
        End With
        pnlMultiObjectSelect.Visible = True
        pnlOverLayProperty.Visible = False
        pnlProperty.Visible = False
        btnCopy.Enabled = True
    End Sub
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        If pnlProperty.Visible = True Then
            Dim tx As String = lblObjName.Text + vbCrLf
            If lblSoloModeValue.Visible = True Then
                tx += lblSoloModeValue.Text + vbCrLf
            End If
            tx += copyGrid(ktGridValue)
            Clipboard.SetText(tx)
        ElseIf pnlOverLayProperty.Visible = True Then

            Clipboard.SetText(txtOverLayProperty.Text)
        ElseIf pnlMultiObjectSelect.Visible = True Then

            Dim tx As String = copyGrid(ktGridMultiObj)
            Clipboard.SetText(tx)
        End If
    End Sub
    Private Function copyGrid(ByRef ktGrid As KTGISUserControl.KTGISGrid) As String
        Dim up(,) As String = ktGrid.FixedYSData(0)
        Dim lft(,) As String = ktGrid.FixedXSData(0)
        Dim dt(,) As String = ktGrid.GridData(0)
        Dim UpLeft(,) As String = ktGrid.FixedUpperLeftData(0)
        Dim tx As String = ""

        For y As Integer = 0 To up.GetLength(1) - 1
            For i As Integer = 0 To UpLeft.GetLength(0) - 1
                tx += UpLeft(i, y) + vbTab
            Next
            For i As Integer = 0 To up.GetLength(0) - 1
                tx += up(i, y)
                If i <> up.GetLength(0) - 1 Then
                    tx += vbTab
                End If
            Next
            tx += vbCrLf
        Next

        For i As Integer = 0 To lft.GetLength(1) - 1
            For j As Integer = 0 To lft.GetLength(0) - 1
                tx += lft(j, i) + vbTab
            Next
            For j As Integer = 0 To dt.GetLength(0) - 1
                tx += dt(j, i)
                If j <> dt.GetLength(0) - 1 Then
                    tx += vbTab
                End If
            Next
            tx += vbCrLf
        Next
        Return tx

    End Function
    Private Sub btnEndMultiObject_Click(sender As Object, e As EventArgs) Handles btnEndMultiObject.Click
        Dim frm As frmPrint = CType(Me.Owner, frmPrint)
        frm.EndMultiObjectSelectMode()
        pnlMultiObjectSelect.Visible = False
    End Sub

    Private Sub rbMultiObjectSelectMode_Pointing_CheckedChanged(sender As Object, e As EventArgs) Handles rbMultiObjectSelectMode_Pointing.CheckedChanged,
        rbMultiObjectSelectMode_Circle.CheckedChanged, rbMultiObjectSelectMode_Polygon.CheckedChanged, rbMultiObjectSelectMode_Rectangle.CheckedChanged
        Dim frm As frmPrint = CType(Me.Owner, frmPrint)
        Dim selMode As frmPrint.enmMultiObjectSelecModesSub
        Select Case True
            Case rbMultiObjectSelectMode_Pointing.Checked
                selMode = frmPrint.enmMultiObjectSelecModesSub.Pointing
            Case rbMultiObjectSelectMode_Circle.Checked
                selMode = frmPrint.enmMultiObjectSelecModesSub.Circle
            Case rbMultiObjectSelectMode_Polygon.Checked
                selMode = frmPrint.enmMultiObjectSelecModesSub.Polygon
            Case rbMultiObjectSelectMode_Rectangle.Checked
                selMode = frmPrint.enmMultiObjectSelecModesSub.Rectangle
        End Select
        frm.SetMultiObjectSelectModeSub(selMode)

    End Sub

    Private Sub btnMultiObjectClear_Click(sender As Object, e As EventArgs) Handles btnMultiObjectClear.Click
        CType(Me.Owner, frmPrint).ClearSelectedMultiObject()
    End Sub

    Private Sub chkShowAllData_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowAllData.CheckedChanged
        CType(Me.Owner, frmPrint).SetMultiObJInformation()
    End Sub

    Private Sub btnOtherSelectMethos_Click(sender As Object, e As EventArgs) Handles btnOtherSelectMethos.Click
        Dim Menu As New List(Of String)
        Menu.Add("オブジェクト名検索")
        Menu.Add("すべて選択")
        Menu.Add("選択/非選択交換")
        Dim n As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("オブジェクトの選択方法", Menu)
        If n <> -1 Then
            CType(Me.Owner, frmPrint).OtherSelectMultiObject(n)
        End If
    End Sub

    Private Sub btnMultiObjOpe_Click(sender As Object, e As EventArgs) Handles btnMultiObjOpe.Click

        Dim Menu As New List(Of String)
        Menu.Add("選択オブジェクトを非表示に")
        Menu.Add("非選択オブジェクトを非表示に")
        Dim n As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("非表示に設定", Menu)
        If n <> -1 Then
            Dim tx As String = Menu.Item(n) + "設定します。"
            If MsgBox(tx, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim f As Boolean = CType(Me.Owner, frmPrint).MultiObjectInVisible(n)
                If f = True Then
                    pnlMultiObjectSelect.Visible = False
                    MsgBox("設定画面の[分析]>[表示オブジェクト限定]から表示に戻すことができます。")
                End If
            End If
        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "multiObjectSelect", Me)
    End Sub


End Class