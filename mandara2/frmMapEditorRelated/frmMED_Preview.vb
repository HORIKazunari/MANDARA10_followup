Public Class frmMED_Preview
    Dim MapData As clsMapData
    Dim ScrData As Screen_info
    Dim PrintedLine() As Boolean
    Dim mousePointingSituation As mousePointingSituations
    Dim mouseDownPosition As Point
    Dim picMapImageOperation As clsPictureBoxDragOrWheelImageChange
    Dim ObjectGRelatedLine() As Integer
    Dim ObjKindEdit() As Boolean

    Public Overloads Sub ShowDialog(ByVal Owner As IWin32Window, ByRef MData As clsMapData, ByRef _ObjKindEdit() As Boolean, ByRef DefTime As strYMD)

        MapData = MData
        If MapData.Map.Time_Mode = False Then
            DateTimePicker.Visible = False
        Else
            DateTimePicker.Visible = True
            If DefTime.nullFlag = True Then
                DateTimePicker.Value = DateTime.Today
            Else
                DateTimePicker.Value = clsTime.getDateTime(DefTime)
            End If
        End If
        ObjKindEdit = _ObjKindEdit.Clone
        With clbObjectKindEdit
            .BeginUpdate()
            .EventStop = True
            .Items.Clear()
            For i As Integer = 0 To MapData.Map.OBKNum - 1
                .Items.Add(MapData.ObjectKind(i).Name, ObjKindEdit(i))
            Next
            .EndUpdate()
            .EventStop = False
        End With
        ScrData.init(picMap, New ScreenMargin(3, 3, 3, 3, False), MapData.Map.Circumscribed_Rectangle, True, True)
        mousePointingSituation = mousePointingSituations.up
        LinePatternCheck()
        printMap()
        Me.ShowDialog(Owner)
    End Sub
    Private Sub printMap()
        picMapImageOperation = New clsPictureBoxDragOrWheelImageChange(picMap)
        ScrData.Set_PictureBox_and_CulculateMul(picMap)
        '描画先とするImageオブジェクトを作成する
        Dim canvas As New Bitmap(picMap.Width, picMap.Height)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)

        Dim T As strYMD
        If MapData.Map.Time_Mode = False Then
            T = clsTime.GetNullYMD
        Else
            T = clsTime.GetYMD(DateTimePicker.Value)
        End If
        ReDim PrintedLine(MapData.Map.ALIN)
        Mapping(g, T)


        'リソースを解放する
        g.Dispose()
        picMap.Image = canvas
        picMap.Refresh()
    End Sub
    Private Sub Mapping(ByRef g As Graphics, ByVal Time As strYMD)

        g.FillRectangle(Brushes.White, New Rectangle(0, 0, picMap.Width, picMap.Height))
        For i As Integer = 0 To 3
            Dim gshape As enmShape
            Select Case i
                Case 0
                    gshape = enmShape.PolygonShape
                Case 1
                    gshape = enmShape.LineShape
                Case 2
                    gshape = enmShape.PointShape
                Case 3
                    gshape = enmShape.NotDeffinition
            End Select
            With MapData
                For j As Integer = 0 To .Map.Kend - 1
                    Dim k As Integer = .MPObj(j).Kind
                    If .ObjectKind(k).Shape = gshape And ObjKindEdit(k) = True Then
                        If .CheckEnableObject(.MPObj(j), Time) = True Then
                            drawObject(g, j, Time)
                        End If
                    End If
                Next
            End With
        Next

    End Sub
    Private Sub drawObject(ByRef g As Graphics, ByVal OCode As Integer, ByVal Time As strYMD)
        Dim P As PointF
        MapData.Get_Enable_CenterP(P.X, P.Y, MapData.MPObj(OCode), Time)
        If MapData.MPObj(OCode).Shape <> enmShape.PointShape Then
            Dim ELine() As clsMapData.EnableMPLine_Data
            Dim n As Integer = MapData.Get_EnableMPLine(ELine, MapData.MPObj(OCode), Time)
            For j As Integer = 0 To n - 1
                Dim lc As Integer = ELine(j).LineCode
                Dim lcc As Integer = ELine(j).Kind
                Dim PatNum = ObjectGRelatedLine(lc)
                If clsGeneric.Check_Line_PrintPattern(MapData.LineKind(lcc).ObjGroup(PatNum).Pattern) = True And PrintedLine(lc) = False Then
                    Dim xy() As Point
                    With MapData.MPLine(lc)
                        xy = ScrData.getSxSy(.NumOfPoint, .PointSTC, False, True)
                    End With
                    clsDrawLine.Line(g, MapData.LineKind(lcc).ObjGroup(PatNum).Pattern, xy.Length, xy, ScrData, clsBase.PictureNoUse)
                    PrintedLine(lc) = True
                End If
            Next
        End If
        If MapData.MPObj(OCode).Shape = enmShape.PointShape Then
            Dim CenterMK As Mark_Property = clsBase.Mark
            CenterMK.Tile.Line.BasicLine.SolidLine.Color = MapData.ObjectKind(MapData.MPObj(OCode).Kind).Color
            CenterMK.WordFont.Body.Size = 1
            Dim r As Integer = ScrData.Get_Length_On_Screen(CenterMK.WordFont.Body.Size / 2)
            Dim P2 As Point = ScrData.getSxSy(P)
            clsDrawMarkFan.Mark_Print(g, P2, r, CenterMK, ScrData, clsBase.PictureNoUse)
        End If

    End Sub


    Private Sub SplitContainer1_Resize(sender As Object, e As System.EventArgs) Handles SplitContainer1.Resize
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

        Select Case mousePointingSituation
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
                        Dim StartP As PointF = ScrData.getSRXY(mouseDownPosition)
                        Dim EndP As PointF = ScrData.getSRXY(mouseUpPosition)
                        ScrData.ScrView.Offset(StartP.X - EndP.X, StartP.Y - EndP.Y)
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
        picMapImageOperation.pictureBoxMouseWheel(e.Location, e.Delta, ScrData)
        printMap()

    End Sub
    ''' <summary>
    ''' オブジェクトグループ連動型線種の設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LinePatternCheck()
        ReDim ObjectGRelatedLine(MapData.Map.ALIN - 1)
        Dim Time As strYMD = clsTime.GetYMD(DateTimePicker.Value)
        For i As Integer = 0 To MapData.Map.LpNum - 1
            With MapData.LineKind(i)
                If .NumofObjectGroup >= 2 Then
                    For j As Integer = 1 To .NumofObjectGroup - 1
                        Dim Ltmp(MapData.Map.ALIN - 1) As Boolean
                        '地図ファイル中で使われていればOK
                        For k As Integer = 0 To MapData.Map.Kend - 1
                            If MapData.MPObj(k).Kind = .ObjGroup(j).GroupNumber Then
                                'オブジェクトが線種の使用オブジェクトとグループが同じ
                                Dim ELine() As clsMapData.EnableMPLine_Data
                                Dim n As Integer = MapData.Get_EnableMPLine(ELine, MapData.MPObj(k), Time)
                                For k2 As Integer = 0 To n - 1
                                    If ELine(k2).Kind = i Then
                                        Ltmp(ELine(k2).LineCode) = True
                                    End If
                                Next
                            End If
                        Next
                        For k As Integer = 0 To MapData.Map.ALIN - 1
                            If Ltmp(k) = True And ObjectGRelatedLine(k) = 0 Then
                                ObjectGRelatedLine(k) = j
                            End If
                        Next
                    Next
                End If
            End With
        Next

    End Sub

    Private Sub DateTimePicker_Leave(sender As Object, e As System.EventArgs) Handles DateTimePicker.Leave
        LinePatternCheck()
        printMap()
    End Sub


    Private Sub DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker.ValueChanged

    End Sub

    Private Sub clbObjectKindEdit_changed(sender As Object, e As CheckedListBoxExChangeEventArgs) Handles clbObjectKindEdit.changed
        If Me.Visible = True Then
            For i As Integer = 0 To MapData.Map.OBKNum - 1
                ObjKindEdit(i) = e.ItemCheck(i)
            Next
            printMap()
        End If

    End Sub

    Private Sub clbObjectKindEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbObjectKindEdit.SelectedIndexChanged

    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        'Metafileオブジェクトを作成する
        Dim bmp As New Bitmap(10, 10)
        Dim bmpg As Graphics = Graphics.FromImage(bmp)
        Dim hdc As IntPtr = bmpg.GetHdc()
        Dim rec As New Rectangle(0, 0, picMap.Width, picMap.Height)
        Dim meta As New System.Drawing.Imaging.Metafile(hdc, rec,
                            Imaging.MetafileFrameUnit.Pixel, System.Drawing.Imaging.EmfType.EmfOnly)
        bmpg.ReleaseHdc(hdc)


        'Metafileに描画する
        Dim emfg As Graphics = Graphics.FromImage(meta)

        Dim T As strYMD
        If MapData.Map.Time_Mode = False Then
            T = clsTime.GetNullYMD
        Else
            T = clsTime.GetYMD(DateTimePicker.Value)
        End If
        ReDim PrintedLine(MapData.Map.ALIN)
        Mapping(emfg, T)
        emfg.Dispose()

        Dim f As Boolean
        'クリップボードに保存
        f = clsEMFMetafileCopy.PutEnhMetafileOnClipboard(Me.Handle, meta)
        '後片付け
        meta.Dispose()
        bmpg.Dispose()
        bmp.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sfd As New SaveFileDialog()
        sfd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        sfd.Filter = "pngファイル(*.png)|*.png|bmpファイル(*.bmp)|*.bmp|jpgファイル(*.jpg)|*.jpg|emfファイル(*.emf)|*.emf"
        sfd.DefaultExt = "png"
        If sfd.ShowDialog() = DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            Try
                Select Case UCase(System.IO.Path.GetExtension(sfd.FileName))
                    Case ".PNG"
                        picMap.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png)
                    Case ".BMP"
                        picMap.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
                    Case ".JPG"
                        picMap.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Case ".EMF"
                        Dim bmp As New Bitmap(10, 10)
                        Dim bmpg As Graphics = Graphics.FromImage(bmp)
                        Dim hdc As IntPtr = bmpg.GetHdc()
                        Dim rec As New Rectangle(0, 0, picMap.Width, picMap.Height)
                        Dim meta As New System.Drawing.Imaging.Metafile(sfd.FileName, hdc, rec, Imaging.MetafileFrameUnit.Pixel, System.Drawing.Imaging.EmfType.EmfOnly)
                        bmpg.ReleaseHdc(hdc)

                        'Metafileに描画する
                        Dim emfg As Graphics = Graphics.FromImage(meta)

                        Dim T As strYMD
                        If MapData.Map.Time_Mode = False Then
                            T = clsTime.GetNullYMD
                        Else
                            T = clsTime.GetYMD(DateTimePicker.Value)
                        End If
                        ReDim PrintedLine(MapData.Map.ALIN)
                        Mapping(emfg, T)
                        emfg.Dispose()
                        '後片付け
                        meta.Dispose()
                        bmpg.Dispose()
                        bmp.Dispose()
                End Select
                Cursor.Current = Cursors.Default
                MsgBox(sfd.FileName + "を保存しました。")
            Catch ex As Exception
                Cursor.Current = Cursors.Default
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub picMap_Click(sender As Object, e As EventArgs) Handles picMap.Click

    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_Preview", Me)
    End Sub
End Class