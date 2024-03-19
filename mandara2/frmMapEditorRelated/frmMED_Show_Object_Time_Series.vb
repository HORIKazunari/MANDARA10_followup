Public Class frmMED_Show_Object_Time_Series
    Dim Obj As clsMapData.strObj_Data
    Dim mpData As clsMapData
    Dim ScrDataTimeSeries As Screen_info

    Dim relatedObject As New ArrayList
    Dim AggrLine_n As Integer
    Dim AggrLineNumber() As Integer
    Dim mousePointingSituation As mousePointingSituations
    Dim mouseDownPosition As Point

    Dim picMapImageOperation As clsPictureBoxDragOrWheelImageChange


    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef mpObj As clsMapData.strObj_Data, ByRef MapData As clsMapData) As System.Windows.Forms.DialogResult

        Obj = mpObj.Clone
        mpData = MapData

        Dim TimeRef As New clsSortingSearch(VariantType.Integer)
        Dim TimeRefEntity As New ArrayList
        Dim eventTime As New clsSortingSearch(VariantType.Integer)

        For i As Integer = 0 To Obj.NumOfNameTime - 1
            With Obj.NameTimeSTC(i)
                TimeRef.Add(clsTime.YMDtoValue(.SETime.StartTime))
                TimeRefEntity.Add(clsTime.StartEndtoString(.SETime) + vbTab + "オブジェクト名" + vbTab + .connectNames)
                eventTime.Add(clsTime.YMDtoValue(.SETime.StartTime))
                eventTime.Add(clsTime.YMDtoValue(.SETime.EndTime))
            End With
        Next

        For i As Integer = 0 To Obj.NumOfCenterP - 1
            With Obj.CenterPSTC(i)
                TimeRef.Add(clsTime.YMDtoValue(.SETime.StartTime))
                TimeRefEntity.Add(clsTime.StartEndtoString(.SETime) + vbTab + "代表点" + vbTab + (i + 1).ToString)
                eventTime.Add(clsTime.YMDtoValue(.SETime.StartTime))
                eventTime.Add(clsTime.YMDtoValue(.SETime.EndTime))
            End With
        Next

        relatedObject.Clear()
        For i As Integer = 0 To Obj.NumOfSuc - 1
            With Obj.SucSTC(i)
                TimeRef.Add(clsTime.YMDtoValue(.Time))
                Dim Name12 As String
                mpData.Get_Enable_ObjectName(mpData.MPObj(.ObjectCode), .Time, False, Name12)
                TimeRefEntity.Add(clsTime.YMDtoString(.Time) + vbTab + "継承先" + vbTab + Name12)
                eventTime.Add(clsTime.YMDtoValue(.Time))
                relatedObject.Add(.ObjectCode)
            End With
        Next

        Dim H_Data() As clsMapData.Hennyu_Data
        Dim n As Integer = mpData.Get_Hennyu_Object(Obj, H_Data)
        For i As Integer = 0 To n - 1
            With H_Data(i)
                TimeRef.Add(clsTime.YMDtoValue(.Time))
                If .Part = True Then
                    TimeRefEntity.Add(clsTime.YMDtoString(.Time) + vbTab + "編入" + vbTab + .Name + "の一部")
                Else
                    TimeRefEntity.Add(clsTime.YMDtoString(.Time) + vbTab + "編入" + vbTab + .Name)
                End If
                eventTime.Add(clsTime.YMDtoValue(.Time))
                relatedObject.Add(.code)
            End With
        Next

        For j As Integer = 0 To Obj.NumOfLine - 1
            With Obj.LineCodeSTC(j)
                Dim k As Integer = .LineCode
                For i As Integer = 0 To .NumOfTime - 1
                    With .Times(i)
                        TimeRef.Add(clsTime.YMDtoValue(.StartTime))
                        eventTime.Add(clsTime.YMDtoValue(.StartTime))
                        eventTime.Add(clsTime.YMDtoValue(.EndTime))
                    End With
                    If mpData.ObjectKind(Obj.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                        TimeRefEntity.Add(clsTime.StartEndtoString(.Times(i)) + vbTab + "ライン番号使用期間" + vbTab + k.ToString)
                    Else
                        Dim Name12 As String
                        mpData.Get_Enable_ObjectName(mpData.MPObj(k), .Times(i).StartTime, False, Name12)
                        TimeRefEntity.Add(clsTime.StartEndtoString(.Times(i)) + vbTab + "オブジェクト構成期間" + vbTab + Name12)
                    End If
                Next
                If mpData.ObjectKind(Obj.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                    For i As Integer = 0 To mpData.MPLine(k).NumOfTime - 1
                        With mpData.MPLine(k).LineTimeSTC(i)
                            With .SETime
                                TimeRef.Add(clsTime.YMDtoValue(.StartTime))
                                eventTime.Add(clsTime.YMDtoValue(.StartTime))
                                eventTime.Add(clsTime.YMDtoValue(.EndTime))
                            End With
                            TimeRefEntity.Add(clsTime.StartEndtoString(.SETime) + vbTab + "ライン" + k.ToString & "有効期間" + vbTab + mpData.LineKind(.Kind).Name)
                        End With
                    Next
                Else
                    For i As Integer = 0 To mpData.MPObj(k).NumOfNameTime - 1
                        With mpData.MPObj(k).NameTimeSTC(i)
                            With .SETime
                                TimeRef.Add(clsTime.YMDtoValue(.StartTime))
                                eventTime.Add(clsTime.YMDtoValue(.StartTime))
                                eventTime.Add(clsTime.YMDtoValue(.EndTime))
                            End With
                            TimeRefEntity.Add(clsTime.StartEndtoString(.SETime) + vbTab + "有効期間" + vbTab + .connectNames)
                        End With
                    Next
                End If
            End With
        Next
        TimeRef.AddEnd()
        eventTime.AddEnd()
        Dim SData(TimeRef.NumofData) As String
        SData(0) = "時期" + vbTab + "事象" + vbTab + "情報"
        For i As Integer = 0 To TimeRef.NumofData - 1
            SData(i + 1) = TimeRefEntity.Item(TimeRef.DataPosition(i))
        Next
        lvTimeSeries.SetData(SData, {VariantType.String, VariantType.String, VariantType.String}, {False, True, False}, False)


        Dim kind As Integer = mpObj.Kind
        Dim dlist As New List(Of String)
        With MapData.ObjectKind(kind)
            For i As Integer = 0 To .DefTimeAttDataNum - 1
                Dim title As String = .DefTimeAttSTC(i).attData.Title
                Dim un As String = .DefTimeAttSTC(i).attData.Unit
                If un <> "" Then
                    un = "（" + un + "）"
                End If
                If mpObj.DefTimeAttValue(i).Data Is Nothing = False Then
                    Dim dt() As clsMapData.strDefTimeAttDataEach_Info = mpObj.DefTimeAttValue(i).Data
                    For j As Integer = 0 To mpObj.DefTimeAttValue(i).Data.Length - 1
                        Dim timetx As String = ""
                        Select Case .DefTimeAttSTC(i).Type
                            Case clsMapData.enmDefTimeAttDataType.PointData
                                timetx = clsTime.YMDtoString(dt(j).Span.StartTime)
                            Case clsMapData.enmDefTimeAttDataType.SpanData
                                timetx = clsTime.StartEndtoString(dt(j).Span)
                        End Select
                        Dim tx As String = title + vbTab + timetx + vbTab + dt(j).Value + un
                        dlist.Add(tx)
                    Next
                End If
            Next
        End With


        Dim DefData(dlist.Count) As String
        DefData(0) = "データ項目" + vbTab + "時期" + vbTab + "データ値"
        For i As Integer = 0 To dlist.Count - 1
            DefData(i + 1) = dlist(i)
        Next
        lbDefAttr.SetData(DefData, {VariantType.String, VariantType.String, VariantType.String}, {False, True, False}, False)

        If mpData.ObjectKind(Obj.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
            AggrLine_n = mpData.Get_AggrOuterLine_AllTime(Obj, AggrLineNumber)
        End If
        With Obj.Circumscribed_Rectangle
            If .Width = 0 Then
                .X -= 1
                .Width = 2
            End If
            If .Height = 0 Then
                .Y -= 1
                .Height = 2
            End If
        End With


        ScrDataTimeSeries.init(picMap, New ScreenMargin(3, 3, 3, 3, False), Obj.Circumscribed_Rectangle, True, True)


        '時間のコンボボックスに追加
        Me.Tag = "off"
        Dim SpecificV() As Integer
        Dim spn As Integer = eventTime.getEachValue_Alley(SpecificV)
        cbEventTime.BeginUpdate()
        cbEventTime.Items.Clear()
        For i As Integer = 0 To spn - 1
            If SpecificV(i) <> 0 Then
                Dim d As strYMD = clsTime.GetYMDfromValue(SpecificV(i))
                cbEventTime.Items.Add(clsTime.YMDtoString(d))
            End If
        Next
        cbEventTime.EndUpdate()
        Me.Tag = "on"
        If cbEventTime.Items.Count = 0 Then
            cbEventTime.Enabled = False
            btnAfterEvent.Enabled = False
            btnBeforeEvent.Enabled = False
            printMap()
        Else
            cbEventTime.SelectedIndex = 0
        End If

        mousePointingSituation = mousePointingSituations.up
        picMapImageOperation = New clsPictureBoxDragOrWheelImageChange(picMap)

        Return Me.ShowDialog(Owner)

    End Function
    Private Sub printMap()
        ScrDataTimeSeries.Set_PictureBox_and_CulculateMul(picMap)
        '描画先とするImageオブジェクトを作成する
        Dim canvas As New Bitmap(picMap.Width, picMap.Height)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)

        Mapping_All_Line(g)
        Mapping_Time(g, dbdtpTime.Value)

        'リソースを解放する
        g.Dispose()
        If picMap.Image Is Nothing = False Then
            picMap.Image.Dispose()
        End If
        picMap.Image = canvas
        picMap.Refresh()
    End Sub
    Private Sub Mapping_All_Line(ByRef g As Graphics)
        If mpData.ObjectKind(Obj.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
            For i As Integer = 0 To Obj.NumOfLine - 1
                PrtOneLine(g, Obj.LineCodeSTC(i).LineCode, False)

            Next
            Dim CoreSizeR As Integer = 2
            For i As Integer = 0 To Obj.NumOfCenterP - 1
                clsDraw.Ellipse(g, ScrDataTimeSeries.getSxSy(Obj.CenterPSTC(i).Position), _
                            CoreSizeR, New SolidBrush(Color.Green), Pens.Black)
            Next
        Else
            For i As Integer = 0 To AggrLine_n - 1
                PrtOneLine(g, AggrLineNumber(i), False)
            Next
        End If
    End Sub

    Private Sub PrtOneLine(ByRef g As Graphics, ByVal LCode As Integer, ByVal SelF As Boolean)

        Dim w As Integer, col As Color

        If SelF = True Then
            col = Color.FromArgb(255, 0, 255, 0)
            w = 2
        Else
            col = Color.Black
            w = 1
        End If
        With mpData.MPLine(LCode)
            Dim xy() As Point = ScrDataTimeSeries.getSxSy(.NumOfPoint, .PointSTC, False, True)
            g.DrawLines(New Pen(col, w), xy)
        End With
    End Sub
    Private Sub Mapping_Time(ByRef g As Graphics, ByVal Time As strYMD)

        Dim EnL() As clsMapData.EnableMPLine_Data
        Dim Font As New Font("MS UI Gothic", 10, GraphicsUnit.Pixel)
        '関連オブジェクトの代表点とオブジェクト名
        For i As Integer = 0 To relatedObject.Count - 1
            Dim c As Integer = relatedObject.Item(i)
            Dim P As PointF
            Dim f As Boolean = mpData.Get_Enable_CenterP(P.X, P.Y, mpData.MPObj(c), Time)
            If f = True Then
                Dim sp As Point = ScrDataTimeSeries.getSxSy(P)
                clsDraw.Ellipse(g, sp, 3, New SolidBrush(Color.Green), Pens.Green)
                sp.Offset(0, 7)
                Dim Name12 As String = ""
                mpData.Get_Enable_ObjectName(mpData.MPObj(c), Time, True, Name12)
                clsDraw.print(g, Name12, sp, Font, New SolidBrush(Color.Black), StringAlignment.Center, StringAlignment.Near)
            End If
        Next
        'ラインの描画
        Dim n As Integer = mpData.Get_EnableMPLine(EnL, Obj, Time)
        For i As Integer = 0 To n - 1
            Call PrtOneLine(g, EnL(i).LineCode, True)
        Next
        '代表点の描画
        Dim CP As PointF
        mpData.Get_Enable_CenterP(CP.X, CP.Y, Obj, Time)
        Dim scp As Point = ScrDataTimeSeries.getSxSy(CP)
        clsDraw.Ellipse(g, scp, 4, New SolidBrush(Color.Red), Pens.Red)
        Dim oName12 As String = ""
        mpData.Get_Enable_ObjectName(Obj, Time, True, oName12)
        scp.Offset(0, 7)
        clsDraw.print(g, oName12, scp, Font, New SolidBrush(Color.Black), StringAlignment.Center, StringAlignment.Near)

    End Sub

    Private Sub cbEventTime_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbEventTime.SelectedIndexChanged
        If Me.Tag = "off" Then
            Exit Sub
        End If
        Dim L As Integer = cbEventTime.SelectedIndex
        Dim D As strYMD = clsTime.GetYMD(cbEventTime.Items(L))
        dbdtpTime.Value = D
    End Sub

    Private Sub picMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMap.Click

    End Sub


    Private Sub SplitContainer1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.Resize, SplitContainer1.SplitterMoved
        If Me.Visible = True Then
            printMap()
        End If
    End Sub

    Private Sub picMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            mousePointingSituation = mousePointingSituations.down
            mouseDownPosition = e.Location
        End If
    End Sub

    Private Sub picMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseMove


        Static mousePreviousPosition As Point

        Select mousePointingSituation
            Case mousePointingSituations.up
                picMap.Focus()
            Case mousePointingSituations.down
                'マウスダウンの直後
                If e.Location.Equals(mouseDownPosition) = False Then
                    '前の座標から移動した場合
                    'ドラッグ用に、現在の地図画面をbackCanvasに待避
                    picMapImageOperation.getPictureImage()
                    mousePreviousPosition = e.Location
                    mousePointingSituation = mousePointingSituations.downAndMove
                End If
            Case mousePointingSituations.downAndMove
                'マウスダウンとドラッグ開始後
                If e.Location.Equals(mousePreviousPosition) = False Then
                    picMapImageOperation.DragPicture(e.Location, mouseDownPosition)
                    mousePreviousPosition = e.Location
                End If
        End Select
    End Sub

    Private Sub picMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseUp
        Dim mouseUpPosition As Point = e.Location
        If mousePointingSituation = mousePointingSituations.downAndMove Then
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left
                    '左クリックの場合－－－－－－－－－－－－－－－－
                    If mousePointingSituation = mousePointingSituations.downAndMove Then
                        picMapImageOperation.DisposeBackCanvasPictureImage()
                        Dim StartP As PointF = ScrDataTimeSeries.getSRXY(mouseDownPosition)
                        Dim EndP As PointF = ScrDataTimeSeries.getSRXY(mouseUpPosition)
                        ScrDataTimeSeries.ScrView.Offset(StartP.X - EndP.X, StartP.Y - EndP.Y)
                        printMap()
                    End If
                Case Windows.Forms.MouseButtons.Right
                    '右クリックは元に戻す
                    picMapImageOperation.DisposeBackCanvasPictureImage()
                    printMap()
            End Select
        End If
        mousePointingSituation = mousePointingSituations.up
    End Sub

    Private Sub picMap_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseWheel
        picMapImageOperation.pictureBoxMouseWheel(e.Location, e.Delta, ScrDataTimeSeries)
        printMap()

    End Sub

    Private Sub btnAllShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllShow.Click
        ScrDataTimeSeries.ScrView = Obj.Circumscribed_Rectangle
        printMap()
    End Sub

    Private Sub btnYesterday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYesterday.Click
        dbdtpTime.Value = clsTime.getYesterday(dbdtpTime.Value)
    End Sub

    Private Sub btnTommorow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTommorow.Click
        dbdtpTime.Value = clsTime.getTomorrow(dbdtpTime.Value)
    End Sub

    Private Sub btnBeforeEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeforeEvent.Click
        Dim L As Integer = cbEventTime.SelectedIndex
        If L = 0 Then
            L = cbEventTime.Items.Count - 1
        Else
            L -= 1
        End If
        cbEventTime.SelectedIndex = L
    End Sub

    Private Sub btnAfterEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAfterEvent.Click
        Dim L As Integer = cbEventTime.SelectedIndex
        If L = cbEventTime.Items.Count - 1 Then
            L = 0
        Else
            L += 1
        End If
        cbEventTime.SelectedIndex = L
    End Sub

    Private Sub dbdtpTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbdtpTime.ValueChanged

        If Me.Tag = "off" Then
            Exit Sub
        End If
        printMap()

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class