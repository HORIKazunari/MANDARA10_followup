Public Class clsPrintMap
    Private Structure VecContourStac_Info
        Public fnum As Integer
        Public CNum As Integer
        Public FStac() As Integer
        Public cStac() As Integer
    End Structure
    Public Shared Sub ShowMap(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData)
        Dim OriginClip As Region
        Try
            attrData.ResetMPSubLineXY()
            attrData.ResetObjectPrintedCheckFlag()
            attrData.TileMap.LicenseFont = attrData.TotalData.ViewStyle.TileLicenceFont
            If clsSettings.Data.AntiAlias = True Then
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            Else
                g.SmoothingMode = Drawing2D.SmoothingMode.None
                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.None
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
            End If
            With attrData.TotalData.ViewStyle
                If .SouByou.Auto = True Or (.SouByou.ThinningPrint_F = True And .SouByou.PointInterval <> 0) Or (.SouByou.LoopAreaF = True Or .SouByou.LoopSize <> 0) Then
                    attrData.check_AutoSoubyou_Enable()
                End If
                If .SouByou.Auto = True Then
                    'ラインのポイント自動間引き用に画面の対角線の距離を取得（座標系設定ありの場合）
                    Dim D As Single
                    If attrData.TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                        D = spatial.Distance_Ido_Kedo_XY(.ScrData.ScrRectangle.Left, .ScrData.ScrRectangle.Top, .ScrData.ScrRectangle.Right, .ScrData.ScrRectangle.Bottom, .Zahyo)
                    Else
                        D = spatial.get_Distance(.ScrData.ScrRectangle.Left, .ScrData.ScrRectangle.Top, .ScrData.ScrRectangle.Right, .ScrData.ScrRectangle.Bottom)
                        D /= attrData.SetMapFile("").Map.SCL
                    End If
                    attrData.TempData.SoubyouLinePointIntervalCriteria = D * 0.001 * attrData.TotalData.ViewStyle.SouByou.AutoDegree
                    attrData.TempData.SoubyouLoopAreaCriteria = (attrData.TempData.SoubyouLinePointIntervalCriteria) ^ 2
                End If
            End With
            Screen_Area_Back(g, attrData)
            With attrData.TotalData.ViewStyle.ScrData
                If .Screen_Margin.ClipF = True Then
                    OriginClip = g.Clip
                    Dim marginRect As Rectangle = .getSXSY_Margin
                    g.SetClip(marginRect, Drawing2D.CombineMode.Intersect)
                End If
            End With
            Screen_Back_ObjectInner_Set(g, attrData)

            With attrData.TotalData.ViewStyle.TileMapView
                If .Visible = True And .DrawTiming = enmDrawTiming.BeforeDataDraw And attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F = False Then
                    printTMS(g, attrData, attrData.TotalData.ViewStyle.TileMapView.ViewData)
                End If
            End With
            Figure_Print(g, attrData, True)

        Catch ex As Exception
            MsgBox("clsPrintShowMap1" + ex.ToString)
            Return
        End Try
        Try

            If attrData.TotalData.ViewStyle.MapPrint_Flag = True Then

                If attrData.TotalData.TotalMode.OverLay.Always_Overlay_Index <> -1 Then
                    OverLay_Plus_Print(g, prog, attrData)
                Else
                    Select Case attrData.TotalData.LV1.Print_Mode_Total
                        Case enmTotalMode_Number.DataViewMode
                            Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
                            attrData.TempData.ModeValueInScreen_Stac.setF = False
                            Select Case attrData.LayerData(Layernum).Print_Mode_Layer
                                Case enmLayerMode_Number.SoloMode
                                    Dim DataNum As Integer = attrData.LayerData(Layernum).atrData.SelectedIndex
                                    Select Case attrData.SoloMode(Layernum, DataNum)
                                        Case enmSoloMode_Number.ClassPaintMode
                                            PrintClassPaintMode(g, prog, attrData, Layernum, DataNum)
                                        Case enmSoloMode_Number.ClassHatchMode
                                            PrintClassHatchMode(g, prog, attrData, Layernum, DataNum)
                                        Case enmSoloMode_Number.ClassMarkMode
                                            PrintClassMarkMode(g, prog, attrData, Layernum, DataNum)
                                        Case enmSoloMode_Number.ClassODMode
                                            If attrData.LayerData(Layernum).Shape = enmShape.LineShape Then
                                                PrintClassLineShapeSENMode(g, prog, attrData, Layernum, DataNum)
                                            Else
                                                PrintClassODMode(g, prog, attrData, Layernum, DataNum)
                                            End If
                                        Case enmSoloMode_Number.MarkSizeMode
                                            PrintMarkSizeMode(g, prog, attrData, Layernum, DataNum)
                                        Case enmSoloMode_Number.MarkBlockMode
                                            PrintMarkBlockMode(g, prog, attrData, Layernum, DataNum)
                                        Case enmSoloMode_Number.MarkTurnMode
                                            PrintMarkTurnMode(g, prog, attrData, Layernum, DataNum)
                                        Case enmSoloMode_Number.MarkBarMode
                                            PrintMarkBarMode(g, prog, attrData, Layernum, DataNum)
                                        Case enmSoloMode_Number.ContourMode
                                            PrintContourMode(g, prog, attrData, Layernum, DataNum)
                                        Case enmSoloMode_Number.StringMode
                                            PrintStringMode(g, prog, attrData, Layernum, DataNum)
                                    End Select
                                Case enmLayerMode_Number.GraphMode
                                    With attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode
                                        PrintGraphMode(g, prog, attrData, Layernum, .SelectedIndex)
                                    End With
                                Case enmLayerMode_Number.LabelMode
                                    With attrData.LayerData(Layernum).LayerModeViewSettings.LabelMode
                                        PrintLabelMode(g, prog, attrData, Layernum, .SelectedIndex)
                                    End With
                                Case enmLayerMode_Number.TripMode
                                    With attrData.LayerData(Layernum).LayerModeViewSettings.TripMode
                                        PrintTripMode(g, prog, attrData, Layernum, .SelectedIndex)
                                    End With
                            End Select
                        Case enmTotalMode_Number.OverLayMode
                            With attrData.TotalData.TotalMode.OverLay
                                Print_OverLay(g, prog, attrData, .SelectedIndex)
                            End With
                        Case enmTotalMode_Number.SeriesMode
                    End Select
                End If
            End If
        Catch ex As Exception
            MsgBox("clsPrintShowMap2" + ex.ToString)
            Return
        End Try

        Try

            Legend_Data_Set(attrData)  '凡例に表示するデータの設定
            Dim tempAccRec As clsAttrData.AccessoryTemp_Infp
            If attrData.TotalData.ViewStyle.ScrData.OutputDevide = enmOutputDevice.Printer Then
                tempAccRec = attrData.TempData.Accessory_Temp.Clone
            End If
            With attrData.TotalData.ViewStyle.TileMapView
                If .Visible = True And .DrawTiming = enmDrawTiming.AfterDataDraw And attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F = False Then
                    printTMS(g, attrData, attrData.TotalData.ViewStyle.TileMapView.ViewData)
                End If
            End With
            With attrData.TotalData.ViewStyle.ScrData
                If .Screen_Margin.ClipF = True Then
                    g.Clip = OriginClip
                End If
            End With
            Screen_MapAreaLine(g, attrData)

            GetAccessoryRectangles(g, attrData)
            Figure_Print(g, attrData, False)
            Screen_BackLine(g, attrData)
            If attrData.TempData.ModeValueInScreen_Stac.setF = True Then
                Restore_InScreenObjectData(attrData)
            End If

            If attrData.TotalData.ViewStyle.ScrData.OutputDevide = enmOutputDevice.Printer Then
                attrData.TempData.Accessory_Temp = tempAccRec.Clone
            End If
            prog.Value = 0
            Dim H As Boolean() = attrData.Get_LineKindUsedList
        Catch ex As Exception
            MsgBox("clsPrintShowMap3" + ex.ToString)
            Return
        End Try
    End Sub
    ''' <summary>
    ''' ダミーのクリップ領域を考えて背景画像表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrdata"></param>
    ''' <remarks></remarks>
    Private Shared Sub printTMS(ByRef g As Graphics, ByRef attrdata As clsAttrData, ByRef TmapView As strTileMapViewDataInfo)
        With TmapView
            Dim Clip_F As Boolean
            Dim Make_ClippingRegion2 As Region
            Dim Original_ClippingRegion2 As Region
            If attrdata.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.OverLayMode Then
                Dim Layers As List(Of Integer) = Get_DummyClipLayers(attrdata)
                If Layers.Count > 0 Then
                    Clip_F = ClippingRegion_ObjectBoundary_set(g, attrdata, Layers, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
                End If
            Else
                Dim Layernum As Integer = attrdata.TotalData.LV1.SelectedLayer
                If attrdata.LayerData(Layernum).LayerModeViewSettings.PolygonDummy_ClipSet_F = True Then
                    Clip_F = ClippingRegion_ObjectBoundary_set(g, attrdata, Layernum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
                End If
            End If
            attrdata.TileMap.PrintTMS(g, .TileMapDataSet, .TransparentF, .AlphaValue, clsSettings.Data.BackImageSpeed, attrdata.SetMapFile(""), attrdata.TotalData.ViewStyle.ScrData)
            If Clip_F = True Then
                g.Clip = Original_ClippingRegion2
                Make_ClippingRegion2.Dispose()
            End If
        End With
    End Sub
    ''' <summary>
    ''' スクリーン、地図領域背景色
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <remarks></remarks>
    Public Shared Sub Screen_Area_Back(ByRef g As Graphics, ByRef attrData As clsAttrData)
        With attrData.TotalData.ViewStyle
            Dim Scrrect As Rectangle = .ScrData.getSxSy(.ScrData.ScrRectangle)
            attrData.Draw_Tile_Box(g, Scrrect, 0, clsBase.BlancLine, .Screen_Back.ScreenAreaBack)
            Dim marginRect As Rectangle = .ScrData.getSXSY_Margin
            attrData.Draw_Tile_Box(g, marginRect, 0, clsBase.BlancLine, .Screen_Back.MapAreaBack)
        End With

    End Sub
    ''' <summary>
    ''' 経緯線（背面表示）とオブジェクト内部色設定
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <remarks></remarks>
    Public Shared Sub Screen_Back_ObjectInner_Set(ByRef g As Graphics, ByRef attrData As clsAttrData)

        With attrData.TotalData.ViewStyle.LatLonLine_Print
            If attrData.TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido And .Order = clsAttrData.enmLatLonLine_Order.Back And .Visible = True Then
                clsAccessory.LatLonLine_Print(g, attrData)
            End If
        End With

        If attrData.TotalData.ViewStyle.Screen_Back.ObjectInner.TileCode <> enmTilePattern.Blank Then
            With attrData.TotalData.LV1
                If .Print_Mode_Total = enmTotalMode_Number.DataViewMode Then
                    Screen_Back_Set_Paint(g, attrData, .SelectedLayer)
                Else
                    Dim n As Integer = attrData.TotalData.TotalMode.OverLay.SelectedIndex
                    Dim OvLay(.Lay_Maxn - 1) As Boolean
                    With attrData.TotalData.TotalMode.OverLay.DataSet(n)
                        For i As Integer = 0 To .DataItem.Count - 1
                            For j As Integer = 0 To .DataItem.Count - 1
                                OvLay(.DataItem(j).Layer) = True
                            Next
                        Next
                    End With
                    For i As Integer = 0 To .Lay_Maxn - 1
                        If OvLay(i) = True Then
                            Screen_Back_Set_Paint(g, attrData, i)
                        End If
                    Next
                End If
            End With
        End If

    End Sub
    ''' <summary>
    ''' 経緯線（前面表示）と地図領域の枠線
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <remarks></remarks>
    Public Shared Sub Screen_MapAreaLine(ByRef g As Graphics, ByRef attrData As clsAttrData)

        With attrData.TotalData.ViewStyle.LatLonLine_Print
            If attrData.TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido And .Order = clsAttrData.enmLatLonLine_Order.Front And .Visible = True Then
                clsAccessory.LatLonLine_Print(g, attrData)
            End If
        End With

        With attrData.TotalData.ViewStyle
            Dim Lpat As Line_Property = .Screen_Back.MapAreaFrameLine
            If Lpat.BasicLine.pattern <> enmLinePattern.InVisible Then
                Dim marginRect As Rectangle = .ScrData.getSXSY_Margin
                Dim penw As Integer = attrData.TotalData.ViewStyle.ScrData.Get_Length_On_Screen(Lpat.Get_Max_LineWidth) \ 2
                If penw = 0 Then
                    penw = 1
                End If
                marginRect.Inflate(-penw, -penw)
                attrData.Draw_Tile_Box(g, marginRect, 0, Lpat, clsBase.BlancTile)
            End If

        End With


    End Sub
    ''' <summary>
    ''' オブジェクト内部の背景塗りつぶし
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <remarks></remarks>
    Private Shared Sub Screen_Back_Set_Paint(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer)

        Dim LT As strYMD = attrData.LayerData(Layernum).Time

        With attrData.LayerData(Layernum)
            Dim MultiObj As New List(Of Integer)
            For i As Integer = 0 To .Dummy.Count - 1
                Dim c As Integer = .Dummy.DummyObj(i).code
                If .MapFileData.MPObj(c).Shape = enmShape.PolygonShape And
                    attrData.Check_Screen_Objcode_In(Layernum, c) = True Then
                    MultiObj.Add(c)
                End If
            Next
            If .DummyGroup.Count > 0 Then
                For i As Integer = 0 To .DummyGroup.Count - 1
                    Dim ok As Integer = .DummyGroup.DummyObjG(i)
                    If .MapFileData.ObjectKind(ok).Shape = enmShape.PolygonShape Then
                        Dim temp() As Integer
                        Dim tnp As Integer = .MapFileData.Get_Objects_by_Group(ok, temp, .Time)
                        For j As Integer = 0 To tnp - 1
                            If attrData.Check_Screen_Objcode_In(Layernum, temp(j)) = True Then
                                MultiObj.Add(temp(j))
                            End If
                        Next
                    End If
                Next
            End If
            Dim MbjN As Integer = MultiObj.Count
            If MbjN > 0 Then
                HatchMultiPolygonObject(g, attrData, Layernum, MbjN, MultiObj.ToArray, attrData.TotalData.ViewStyle.Screen_Back.ObjectInner, True)
            End If

            If .Shape = enmShape.PolygonShape Then
                MultiObj = New List(Of Integer)
                For i As Integer = 0 To .atrObject.ObjectNum - 1
                    If attrData.Check_screen_Kencode_In(Layernum, i) = True Then
                        MultiObj.Add(i)
                    End If
                Next
                MbjN = MultiObj.Count
                If MbjN > 0 Then
                    HatchMultiPolygonObject(g, attrData, Layernum, MbjN, MultiObj.ToArray, attrData.TotalData.ViewStyle.Screen_Back.ObjectInner, False)
                End If
            End If
        End With

    End Sub

    ''' <summary>
    ''' 最後に画面枠線を描く
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Screen_BackLine(ByRef g As Graphics, ByRef attrData As clsAttrData)

        Dim rect As Rectangle = attrData.TotalData.ViewStyle.ScrData.getSxSy(attrData.TotalData.ViewStyle.ScrData.ScrRectangle)
        With attrData.TotalData.ViewStyle.Screen_Back
            Dim penw As Integer = attrData.TotalData.ViewStyle.ScrData.Get_Length_On_Screen(.ScreenFrameLine.Get_Max_LineWidth) \ 2
            If penw = 0 Then
                penw = 1
            End If
            rect.Inflate(-penw, -penw)
            attrData.Draw_Tile_Box(g, rect, 0, .ScreenFrameLine, clsBase.BlancTile)
        End With
    End Sub

    ''' <summary>
    ''' 飾りの外接四角形をまとめて記録
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <remarks></remarks>
    Private Shared Sub GetAccessoryRectangles(ByRef g As Graphics, ByRef attrData As clsAttrData)
        With attrData.TempData.Accessory_Temp
            If attrData.TotalData.ViewStyle.AttMapCompass.Visible = True Then
                .MapCompass_Rect = clsAccessory.GetCompassRect(g, attrData)
            End If
            If attrData.TotalData.ViewStyle.MapTitle.Visible = True Then
                .MapTitle_Rect = clsAccessory.GetTitleRect(g, attrData)
                Dim padw As Integer = attrData.Get_PaddingPixcel(attrData.TotalData.ViewStyle.MapTitle.Font.Back)
                .MapTitle_Rect.Inflate(padw, padw)
            End If

            If attrData.TotalData.ViewStyle.DataNote.Visible = True Then
                .DataNote_Rect = clsAccessory.GetNoteRect(g, attrData)
                If .DataNote_Rect.Width <> 0 Then
                    Dim padw As Integer = attrData.Get_PaddingPixcel(attrData.TotalData.ViewStyle.DataNote.Font.Back)
                    .DataNote_Rect.Inflate(padw, padw)
                End If
            End If

            If attrData.TotalData.ViewStyle.MapScale.Visible = True Then
                Dim padw As Integer = attrData.Get_PaddingPixcel(attrData.TotalData.ViewStyle.MapScale.Back)
                .MapScale_Rect = clsAccessory.GetScaleRect(g, attrData)
                .MapScale_Rect.Inflate(padw, padw)
            End If
            If attrData.TotalData.ViewStyle.MapLegend.Base.Visible = True Or
                attrData.TotalData.ViewStyle.MapLegend.Line_DummyKind.Line_Visible = True Then
                For i As Integer = 0 To attrData.TempData.Accessory_Temp.Legend_No_Max - 1
                    clsAccessory.Legend_print(g, attrData, i, True)
                Next
            End If

            Dim Agb As clsAttrData.strAccessoryGroupBox_Info = attrData.TotalData.ViewStyle.AccessoryGroupBox
            If Agb.Visible = True Then
                Dim n As Integer = 0
                Dim Rects(6 + .Legend_No_Max) As Rectangle
                If Agb.Title = True And .MapTitle_Rect.Width <> 0 And attrData.TotalData.ViewStyle.MapTitle.Visible = True Then
                    Rects(n) = .MapTitle_Rect
                    n += 1
                End If
                If Agb.Scale = True And .MapScale_Rect.Width <> 0 And attrData.TotalData.ViewStyle.MapScale.Visible = True Then
                    Rects(n) = .MapScale_Rect
                    n += 1
                End If
                If Agb.Comapss = True And .MapCompass_Rect.Width <> 0 And attrData.TotalData.ViewStyle.AttMapCompass.Visible = True Then
                    Rects(n) = .MapCompass_Rect
                    n += 1
                End If
                If Agb.Note = True And .DataNote_Rect.Width <> 0 And attrData.TotalData.ViewStyle.DataNote.Visible = True Then
                    Rects(n) = .DataNote_Rect
                    n += 1
                End If
                If Agb.Legend = True And attrData.TotalData.ViewStyle.MapLegend.Base.Visible = True Then
                    For i As Integer = 0 To .Legend_No_Max - 1
                        Rects(n) = .MapLegend_W(i).Rect
                        n += 1
                    Next
                End If
                Dim rect As Rectangle = Rects(0)
                For i As Integer = 1 To n - 1
                    rect = spatial.Get_Circumscribed_Rectangle(rect, Rects(i))
                Next
                .GroupBox_Rect = rect
            End If
        End With
    End Sub
    ''' <summary>
    ''' ダミーオブジェクトをクリップ領域に設定ているレイヤ一覧取得
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Get_DummyClipLayers(ByRef attrData As clsAttrData) As List(Of Integer)
        Dim dummyClipLayer As New List(Of Integer)
        With attrData.TotalData.TotalMode.OverLay
            With .DataSet(.SelectedIndex)
                For i As Integer = 0 To .DataItem.Count - 1
                    With .DataItem(i)
                        If .TileMapf = False Then
                            Dim lay As Integer = .Layer
                            If attrData.LayerData(lay).LayerModeViewSettings.PolygonDummy_ClipSet_F = True Then
                                dummyClipLayer.Add(lay)
                            End If
                        End If
                    End With
                Next
            End With

        End With

        Return dummyClipLayer
    End Function
    ''' <summary>
    ''''常時重ね合わせが設定してある場合 
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub OverLay_Plus_Print(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData)

        Dim n As Integer = attrData.TotalData.TotalMode.OverLay.Always_Overlay_Index
        attrData.TempData.OverLay_Temp.Always_Ove_DataStac = New List(Of clsAttrData.strOverLay_DataSet_Item_Info)
        Select Case attrData.TotalData.LV1.Print_Mode_Total
            Case enmTotalMode_Number.DataViewMode
                With attrData.TotalData.TotalMode.OverLay.DataSet(n)
                    attrData.TempData.OverLay_Temp.Always_Ove_DataStac.AddRange(attrData.TotalData.TotalMode.OverLay.DataSet(n).DataItem)
                    Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
                    If attrData.LayerData(Layernum).Print_Mode_Layer = enmLayerMode_Number.SoloMode Then
                        Dim DataNum As Integer = attrData.LayerData(Layernum).atrData.SelectedIndex
                        Dim d As clsAttrData.strOverLay_DataSet_Item_Info
                        With d
                            .DataNumber = DataNum
                            .Layer = Layernum
                            .Print_Mode_Layer = enmLayerMode_Number.SoloMode
                            .Mode = attrData.LayerData(Layernum).atrData.Data(DataNum).ModeData
                            .Legend_Print_Flag = True
                        End With
                        attrData.TempData.OverLay_Temp.Always_Ove_DataStac.Add(d)
                    Else
                        Dim d As clsAttrData.strOverLay_DataSet_Item_Info
                        With d
                            .Layer = Layernum
                            .DataNumber = attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode.SelectedIndex
                            .Print_Mode_Layer = attrData.LayerData(Layernum).Print_Mode_Layer
                            .Legend_Print_Flag = True
                        End With
                        attrData.TempData.OverLay_Temp.Always_Ove_DataStac.Add(d)
                    End If
                End With
            Case enmTotalMode_Number.OverLayMode
                Dim n_now As Integer = attrData.TotalData.TotalMode.OverLay.SelectedIndex
                attrData.TempData.OverLay_Temp.Always_Ove_DataStac.AddRange(attrData.TotalData.TotalMode.OverLay.DataSet(n).DataItem)
                If n <> n_now Then
                    attrData.TempData.OverLay_Temp.Always_Ove_DataStac.AddRange(attrData.TotalData.TotalMode.OverLay.DataSet(n_now).DataItem)
                End If
        End Select
        Dim d2 As New List(Of clsAttrData.strOverLay_DataSet_Item_Info)
        d2 = attrData.Sort_OverLay_Data_Sub(attrData.TempData.OverLay_Temp.Always_Ove_DataStac)

        attrData.TempData.OverLay_Temp.OverLay_Printing_Flag = True

        For i As Integer = 0 To attrData.TempData.OverLay_Temp.Always_Ove_DataStac.Count - 1
            With d2(i)
                If .Print_Mode_Layer = enmLayerMode_Number.SoloMode Then
                    Dim Equal_Mode_N As Integer = 0
                    For j As Integer = 0 To d2.Count - 1
                        If i = j Then
                            attrData.TempData.OverLay_Temp.OverLay_EMode_Now = Equal_Mode_N
                            Equal_Mode_N += 1
                        Else
                            Dim ovData As clsAttrData.strOverLay_DataSet_Item_Info = d2(j)
                            If ovData.Layer = .Layer And ovData.Mode = .Mode And
                                .Mode <> enmSoloMode_Number.ClassODMode Then
                                Equal_Mode_N += 1
                            End If
                        End If
                    Next
                    attrData.TempData.OverLay_Temp.OverLay_EMode_N = Equal_Mode_N
                End If
            End With
            Call OverLay_Print_Sub(g, prog, attrData, d2(i))
        Next
        attrData.TempData.OverLay_Temp.OverLay_Printing_Flag = False
    End Sub
    ''' <summary>
    ''' 重ね合わせモードのデータセット内の表示項目ごとの凡例セット
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Over_D"></param>
    ''' <param name="n"></param>
    ''' <remarks></remarks>
    Private Shared Sub Legend_Data_Set_Over_sub(ByRef attrData As clsAttrData, ByRef Over_D As clsAttrData.strOverLay_DataSet_Item_Info,
                                                ByRef n As Integer)


        Dim L As Integer = Over_D.Layer
        Select Case Over_D.Print_Mode_Layer
            Case enmLayerMode_Number.SoloMode
                Dim dt As Integer = Over_D.DataNumber
                If Over_D.Legend_Print_Flag = True Then
                    Dim OVerData As clsAttrData.strData_info = attrData.LayerData(L).atrData.Data(dt)
                    With attrData.TempData.Accessory_Temp.MapLegend_W(n)
                        .DatN = Over_D.DataNumber
                        .Layn = L
                        .title = attrData.Get_DataTitle(L, dt, False)
                        .Print_Mode_Layer = enmLayerMode_Number.SoloMode

                        If Over_D.Mode = enmSoloMode_Number.ContourMode Then
                            Select Case OVerData.SoloModeViewSettings.ContourMD.Interval_Mode
                                Case clsAttrData.enmContourIntervalMode.ClassPaint
                                Case clsAttrData.enmContourIntervalMode.ClassHatch
                                    If OVerData.SoloModeViewSettings.ContourMD.Interval_Mode = clsAttrData.enmContourIntervalMode.ClassPaint Then
                                        .SoloMode = enmSoloMode_Number.ClassPaintMode
                                    Else
                                        .SoloMode = enmSoloMode_Number.ClassHatchMode
                                    End If
                                Case Else
                                    n -= 1
                            End Select
                        Else
                            .SoloMode = Over_D.Mode
                            Select Case OVerData.ModeData
                                Case enmSoloMode_Number.MarkSizeMode, enmSoloMode_Number.MarkBlockMode, enmSoloMode_Number.MarkTurnMode, enmSoloMode_Number.MarkBarMode, enmSoloMode_Number.StringMode
                                    Legend_Mark_Mode_Inner_Data_Set(attrData, OVerData.SoloModeViewSettings.MarkCommon.Inner_Data, n, L, .DatN)
                                Case enmSoloMode_Number.ClassMarkMode
                                    Legend_Mark_Mode_Inner_Data_Set(attrData, OVerData.SoloModeViewSettings.ClassMarkMD, n, L, .DatN)
                            End Select
                        End If
                    End With
                    n += 1
                End If
            Case enmLayerMode_Number.GraphMode
                If Over_D.Legend_Print_Flag = True Then
                    With attrData.TempData.Accessory_Temp.MapLegend_W(n)
                        .DatN = Over_D.DataNumber
                        .Layn = L
                        .GraphMode = attrData.LayerData(L).LayerModeViewSettings.GraphMode.DataSet(.DatN).GraphMode
                        .title = attrData.LayerData(L).LayerModeViewSettings.GraphMode.DataSet(.DatN).title
                        .Print_Mode_Layer = enmLayerMode_Number.GraphMode
                    End With
                    n += 1
                End If
            Case enmLayerMode_Number.LabelMode
            Case enmLayerMode_Number.TripMode
                Dim tpd As clsAttrData.strTrip_Data = attrData.LayerData(L).LayerModeViewSettings.TripMode.DataSet(Over_D.DataNumber)
                Select Case tpd.Mode
                    Case clsAttrData.enmTripMode.Blanc
                    Case clsAttrData.enmTripMode.TripDefinitionLayerDataMode
                        Dim TDEFL As Integer = attrData.Get_Trip_Definition_Layer_Number
                        With attrData.TempData.Accessory_Temp.MapLegend_W(n)
                            .DatN = tpd.Definition_Layer_Data
                            If tpd.Definition_Layer_Data_Mode = clsAttrData.enmTripDrawType.PaintMode Then
                                .SoloMode = enmSoloMode_Number.ClassPaintMode
                            Else
                                .SoloMode = enmSoloMode_Number.ClassODMode
                            End If
                            .Layn = TDEFL
                            .Print_Mode_Layer = enmLayerMode_Number.SoloMode
                            .title = attrData.Get_DataTitle(TDEFL, tpd.Definition_Layer_Data, False)
                        End With
                        n = n + 1
                    Case clsAttrData.enmTripMode.TripLayerDataMode
                        Dim DataStay As Integer = tpd.Stay_Data - 2
                        Dim DataMove As Integer = tpd.Move_Data - 2
                        Dim DataStayMode As Integer = tpd.Stay_Data_Mode
                        Dim DataMoveMode As Integer = tpd.Move_Data_Mode
                        If DataStay >= 0 Then
                            With attrData.TempData.Accessory_Temp.MapLegend_W(n)
                                .DatN = DataStay
                                If tpd.Stay_Data_Mode = clsAttrData.enmTripDrawType.PaintMode Then
                                    .SoloMode = enmSoloMode_Number.ClassPaintMode
                                Else
                                    .SoloMode = enmSoloMode_Number.ClassODMode
                                End If
                                .Layn = L
                                .Print_Mode_Layer = enmLayerMode_Number.SoloMode
                                .title = attrData.Get_DataTitle(L, DataStay, False)
                            End With
                            n += 1
                        End If
                        If DataMove >= 0 Then
                            With attrData.TempData.Accessory_Temp.MapLegend_W(n)
                                .DatN = DataMove
                                If tpd.Move_Data_Mode = clsAttrData.enmTripDrawType.PaintMode Then
                                    .SoloMode = enmSoloMode_Number.ClassPaintMode
                                Else
                                    .SoloMode = enmSoloMode_Number.ClassODMode
                                End If
                                .Layn = L
                                .Print_Mode_Layer = enmLayerMode_Number.SoloMode
                                .title = attrData.Get_DataTitle(L, DataMove, False)
                            End With
                            n += 1
                        End If
                End Select
        End Select

    End Sub
    ''' <summary>
    ''' 内部に設定されている凡例の設定
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="InnerData"></param>
    ''' <param name="n"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub Legend_Mark_Mode_Inner_Data_Set(ByRef attrData As clsAttrData, ByVal InnerData As clsAttrData.strInner_Data_Info,
                                                        ByRef n As Integer, ByVal Layernum As Integer, ByVal DataNum As Integer)

        If InnerData.Flag = False Then
            Exit Sub
        Else
            If attrData.TempData.Accessory_Temp.MapLegend_W.Length <= n + 1 Then
                ReDim Preserve attrData.TempData.Accessory_Temp.MapLegend_W(n + 1)
            End If
            Dim att As clsAttrData.strData_info = attrData.LayerData(Layernum).atrData.Data(DataNum)
            attrData.TempData.Accessory_Temp.MapLegend_W(n).title = attrData.Get_DataTitle(Layernum, DataNum, False)
            With attrData.TempData.Accessory_Temp.MapLegend_W(n + 1)
                .DatN = InnerData.Data
                .Layn = Layernum
                .Print_Mode_Layer = enmLayerMode_Number.SoloMode
                .title = attrData.Get_DataTitle(Layernum, InnerData.Data, False)
                Select Case InnerData.Mode
                    Case clsAttrData.enmInner_Data_Info_Mode.ClassPaint
                        .SoloMode = enmSoloMode_Number.ClassPaintMode
                    Case clsAttrData.enmInner_Data_Info_Mode.ClassHatch
                        .SoloMode = enmSoloMode_Number.ClassHatchMode
                End Select
            End With
            n += 1
        End If


    End Sub

    Private Shared Sub Legend_Data_Set(ByRef attrData As clsAttrData)


        Dim n As Integer = 0
        If attrData.TotalData.TotalMode.OverLay.Always_Overlay_Index <> -1 Then
            With attrData.TempData
                ReDim .Accessory_Temp.MapLegend_W(.OverLay_Temp.Always_Ove_DataStac.Count)
                For i As Integer = 0 To .OverLay_Temp.Always_Ove_DataStac.Count - 1
                    Legend_Data_Set_Over_sub(attrData, .OverLay_Temp.Always_Ove_DataStac(i), n)
                Next
            End With
        Else
            Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
            Dim DataNum As Integer = attrData.LayerData(Layernum).atrData.SelectedIndex
            ReDim attrData.TempData.Accessory_Temp.MapLegend_W(0)
            Select Case attrData.TotalData.LV1.Print_Mode_Total
                Case enmTotalMode_Number.DataViewMode
                    Select Case attrData.LayerData(Layernum).Print_Mode_Layer
                        Case enmLayerMode_Number.SoloMode
                            '単独・グラフモードの凡例設定
                            Dim att_Data As clsAttrData.strData_info = attrData.LayerData(Layernum).atrData.Data(DataNum)
                            With attrData.TempData.Accessory_Temp.MapLegend_W(0)
                                .DatN = DataNum
                                .Layn = Layernum
                                .Print_Mode_Layer = attrData.LayerData(Layernum).Print_Mode_Layer
                                .title = ""
                                .SoloMode = att_Data.ModeData
                            End With
                            Select Case att_Data.ModeData
                                Case enmSoloMode_Number.MarkSizeMode, enmSoloMode_Number.MarkBlockMode, enmSoloMode_Number.MarkTurnMode, enmSoloMode_Number.MarkBarMode, enmSoloMode_Number.StringMode
                                    Legend_Mark_Mode_Inner_Data_Set(attrData,
                                            attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon.Inner_Data,
                                             n, Layernum, DataNum)
                                Case enmSoloMode_Number.ClassMarkMode
                                    Legend_Mark_Mode_Inner_Data_Set(attrData,
                                            attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.ClassMarkMD,
                                             n, Layernum, DataNum)
                            End Select
                            n += 1
                        Case enmLayerMode_Number.GraphMode
                            'グラフモード
                            With attrData.TempData.Accessory_Temp.MapLegend_W(0)
                                .Layn = Layernum
                                .Print_Mode_Layer = attrData.LayerData(Layernum).Print_Mode_Layer
                                .title = ""
                                .DatN = attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode.SelectedIndex
                                .GraphMode = attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode.DataSet(.DatN).GraphMode
                            End With
                            n += 1
                        Case enmLayerMode_Number.LabelMode
                        Case enmLayerMode_Number.TripMode
                            '移動表示モード
                            Dim TripData As clsAttrData.strTrip_Data
                            With attrData.LayerData(Layernum).LayerModeViewSettings.TripMode
                                TripData = .DataSet(.SelectedIndex)
                            End With
                            Select Case TripData.Mode
                                Case clsAttrData.enmTripMode.Blanc
                                Case clsAttrData.enmTripMode.TripDefinitionLayerDataMode
                                    Dim TDEFL As Integer = attrData.Get_Trip_Definition_Layer_Number
                                    With attrData.TempData.Accessory_Temp.MapLegend_W(0)
                                        .DatN = TripData.Definition_Layer_Data
                                        If TripData.Definition_Layer_Data_Mode = clsAttrData.enmTripDrawType.PaintMode Then
                                            .SoloMode = enmSoloMode_Number.ClassPaintMode
                                        Else
                                            .SoloMode = enmSoloMode_Number.ClassODMode
                                        End If
                                        .Layn = TDEFL
                                        .Print_Mode_Layer = enmLayerMode_Number.SoloMode
                                        .title = attrData.Get_DataTitle(TDEFL, TripData.Definition_Layer_Data, False)
                                    End With
                                    n += 1
                                Case clsAttrData.enmTripMode.TripLayerDataMode
                                    Dim DataStay As Integer = TripData.Stay_Data - 2
                                    Dim DataMove As Integer = TripData.Move_Data - 2

                                    If DataStay >= 0 Then
                                        If UBound(attrData.TempData.Accessory_Temp.MapLegend_W) < n + 1 Then
                                            ReDim Preserve attrData.TempData.Accessory_Temp.MapLegend_W(n + 1)
                                        End If
                                        With attrData.TempData.Accessory_Temp.MapLegend_W(n)
                                            .DatN = DataStay
                                            .Layn = Layernum
                                            .Print_Mode_Layer = enmLayerMode_Number.SoloMode
                                            .title = attrData.Get_DataTitle(Layernum, DataStay, False)
                                            If TripData.Stay_Data_Mode = clsAttrData.enmTripDrawType.PaintMode Then
                                                .SoloMode = enmSoloMode_Number.ClassPaintMode
                                            Else
                                                .SoloMode = enmSoloMode_Number.ClassODMode
                                            End If
                                        End With
                                        n += 1
                                    End If
                                    If DataMove >= 0 Then
                                        If UBound(attrData.TempData.Accessory_Temp.MapLegend_W) < n + 1 Then
                                            ReDim Preserve attrData.TempData.Accessory_Temp.MapLegend_W(n + 1)
                                        End If
                                        With attrData.TempData.Accessory_Temp.MapLegend_W(n)
                                            .DatN = DataMove
                                            .Layn = Layernum
                                            .Print_Mode_Layer = enmLayerMode_Number.SoloMode
                                            .title = attrData.Get_DataTitle(Layernum, DataMove, False)
                                            If TripData.Move_Data_Mode = clsAttrData.enmTripDrawType.PaintMode Then
                                                .SoloMode = enmSoloMode_Number.ClassPaintMode
                                            Else
                                                .SoloMode = enmSoloMode_Number.ClassODMode
                                            End If
                                        End With
                                        n += 1
                                    End If
                            End Select
                    End Select
                Case enmTotalMode_Number.OverLayMode
                    '重ね合わせモード凡例の設定
                    With attrData.TotalData.TotalMode.OverLay
                        With .DataSet(.SelectedIndex)
                            ReDim attrData.TempData.Accessory_Temp.MapLegend_W(.DataItem.Count)
                            For i As Integer = 0 To .DataItem.Count - 1
                                Legend_Data_Set_Over_sub(attrData, .DataItem(i), n)
                            Next
                        End With
                    End With
            End Select
        End If

        For i As Integer = 0 To n - 1
            With attrData.TempData.Accessory_Temp.MapLegend_W(i)
                .LineKind_Flag = False
                .PointObject_Flag = False
            End With
        Next
        If attrData.TotalData.ViewStyle.MapLegend.Line_DummyKind.Line_Visible = True Then
            ReDim Preserve attrData.TempData.Accessory_Temp.MapLegend_W(n)
            With attrData.TempData.Accessory_Temp.MapLegend_W(n)
                .LineKind_Flag = True
                .PointObject_Flag = False
                n += 1
            End With
        End If
        If attrData.TotalData.ViewStyle.MapLegend.Line_DummyKind.Dummy_Point_Visible = True Then
            ReDim Preserve attrData.TempData.Accessory_Temp.MapLegend_W(n)
            With attrData.TempData.Accessory_Temp.MapLegend_W(n)
                .LineKind_Flag = False
                .PointObject_Flag = True
                n += 1
            End With
        End If

        If n > attrData.TotalData.ViewStyle.MapLegend.Base.Legend_Num Then
            Dim oldn As Integer

            oldn = attrData.TotalData.ViewStyle.MapLegend.Base.Legend_Num
            attrData.TotalData.ViewStyle.MapLegend.Base.Legend_Num = n
            ReDim Preserve attrData.TotalData.ViewStyle.MapLegend.Base.LegendXY(n)
            For i As Integer = oldn To n - 1
                With attrData.TotalData.ViewStyle.ScrData
                    If .Accessory_Base = enmBasePosition.Screen Then
                        With attrData.TotalData.ViewStyle.MapLegend.Base
                            .LegendXY(i).X = .LegendXY(i - 1).X + 0.05
                            .LegendXY(i).Y = .LegendXY(i - 1).Y + 0.05
                            If .LegendXY(i).X >= 0.98 Then
                                .LegendXY(i).X = .LegendXY(i - 1).X
                            End If
                            If .LegendXY(i).Y >= 0.98 Then
                                .LegendXY(i).Y = .LegendXY(i - 1).Y
                            End If
                        End With
                    Else
                        Dim Mprect As RectangleF = .MapRectangle
                        Dim ScrRect As RectangleF = .ScrRectangle
                        With attrData.TotalData.ViewStyle.MapLegend.Base
                            .LegendXY(i).X = .LegendXY(i - 1).X + (Mprect.Width) * 0.05
                            .LegendXY(i).Y = .LegendXY(i - 1).Y + (Mprect.Height) * 0.05
                            If .LegendXY(i).X > ScrRect.Right Then
                                .LegendXY(i).X = .LegendXY(i - 1).X
                            End If
                            If .LegendXY(i).Y > ScrRect.Bottom Then
                                .LegendXY(i).Y = .LegendXY(i - 1).Y
                            End If
                        End With
                    End If
                End With
            Next
        End If

        attrData.TempData.Accessory_Temp.Legend_No_Max = n
    End Sub
    ''' <summary>
    ''' 図形やスケールの飾を表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="back_gazo_f"></param>
    ''' <remarks></remarks>
    Private Shared Sub Figure_Print(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal back_gazo_f As Boolean)
        If back_gazo_f = True Then
            '背景画像の表示
            If attrData.TotalData.ViewStyle.FigureVisible = True Then
                For wi As Integer = 0 To attrData.TotalData.FigureStac.Count - 1
                    Dim FigStac As Object = attrData.TotalData.FigureStac(wi)
                    Select Case True
                        Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                            Dim FigData As clsAttrData.strFig_gazo_data = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                            If FigData.Back = True Then
                                If Figure_Print_CheckPrint(attrData, FigData.Data) = True Then
                                    attrData.TempData.FigurePrinted(wi) = clsAccessory.Fig_PrintGazo(g, attrData, FigData)
                                End If
                            End If
                    End Select
                Next
            End If
            Return
        End If

        If attrData.TotalData.ViewStyle.FigureVisible = True Then
            For wi As Integer = 0 To attrData.TotalData.FigureStac.Count - 1
                Dim FigStac As Object = attrData.TotalData.FigureStac(wi)
                Select Case True
                    Case TypeOf FigStac Is clsAttrData.strFig_Word_Data
                        Dim FigData As clsAttrData.strFig_Word_Data = DirectCast(FigStac, clsAttrData.strFig_Word_Data)
                        If Figure_Print_CheckPrint(attrData, FigData.Data) = True Then
                            attrData.TempData.FigurePrinted(wi) = clsAccessory.Fig_PrintWords(g, attrData, FigData)
                        End If
                    Case TypeOf FigStac Is clsAttrData.strFig_Line_Data
                        Dim FigData As clsAttrData.strFig_Line_Data = DirectCast(FigStac, clsAttrData.strFig_Line_Data)
                        If Figure_Print_CheckPrint(attrData, FigData.Data) = True Then
                            attrData.TempData.FigurePrinted(wi) = clsAccessory.Fig_PrintLine(g, attrData, FigData)
                        End If
                    Case TypeOf FigStac Is clsAttrData.strFig_Rectangle_Data
                        Dim FigData As clsAttrData.strFig_Rectangle_Data = DirectCast(FigStac, clsAttrData.strFig_Rectangle_Data)
                        If Figure_Print_CheckPrint(attrData, FigData.Data) = True Then
                            attrData.TempData.FigurePrinted(wi) = clsAccessory.Fig_PrintRectangle(g, attrData, FigData)
                        End If
                    Case TypeOf FigStac Is clsAttrData.strFig_Circle_data
                        Dim FigData As clsAttrData.strFig_Circle_data = DirectCast(FigStac, clsAttrData.strFig_Circle_data)
                        If Figure_Print_CheckPrint(attrData, FigData.Data) = True Then
                            attrData.TempData.FigurePrinted(wi) = clsAccessory.Fig_PrintCircle(g, attrData, FigData)
                        End If
                    Case TypeOf FigStac Is clsAttrData.strFig_Point_Data
                        Dim FigData As clsAttrData.strFig_Point_Data = DirectCast(FigStac, clsAttrData.strFig_Point_Data)
                        If Figure_Print_CheckPrint(attrData, FigData.Data) = True Then
                            attrData.TempData.FigurePrinted(wi) = clsAccessory.Fig_PrintPoint(g, attrData, FigData)
                        End If
                    Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                        Dim FigData As clsAttrData.strFig_gazo_data = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                        If Figure_Print_CheckPrint(attrData, FigData.Data) = True Then
                            If FigData.Back = False Then
                                attrData.TempData.FigurePrinted(wi) = clsAccessory.Fig_PrintGazo(g, attrData, FigData)
                            End If
                        End If
                End Select
            Next
        End If

        If back_gazo_f = False Then
            clsAccessory.AccGroupBoxDraw(g, attrData)
            clsAccessory.Scale_Print(g, attrData)
            clsAccessory.Note_Print(g, attrData)
            clsAccessory.Compass_print(g, attrData)
            'If Blanc_Map_F = False Then
            clsAccessory.Title_Print(g, attrData)
            For i As Integer = 0 To attrData.TempData.Accessory_Temp.Legend_No_Max - 1
                If attrData.Check_Screen_In(attrData.TempData.Accessory_Temp.MapLegend_W(i).Rect) = True Then
                    clsAccessory.Legend_print(g, attrData, i, False)
                End If
            Next
            'End If
            'Call BackImageWMS_Approval_Print()

        End If
    End Sub
    ''' <summary>
    ''' 図形が表示されるレイヤ・データ項目かをチェック
    ''' </summary>
    ''' <param name="wi"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Figure_Print_CheckPrint(ByRef attrData As clsAttrData, ByVal Figure_Data As clsAttrData.strFigure_data) As Boolean

        Dim f As Boolean
        Dim Layernum As Integer, DataNum As Integer

        Dim Fig_Lay As Integer = Figure_Data.Layer - 1
        If Fig_Lay = -1 Then
            '全てのレイヤで表示
            f = True
        Else
            Dim Fig_Data As Integer = Figure_Data.Data - 1
            f = False
            Select Case attrData.TotalData.LV1.Print_Mode_Total
                Case enmTotalMode_Number.DataViewMode
                    Layernum = attrData.TotalData.LV1.SelectedLayer
                    DataNum = attrData.LayerData(Layernum).atrData.SelectedIndex
                    Select Case attrData.LayerData(Layernum).Print_Mode_Layer
                        Case enmLayerMode_Number.SoloMode
                            If attrData.TotalData.LV1.Lay_Maxn = 1 Or Fig_Lay = Layernum Then
                                If Fig_Data = -1 Or Fig_Data = DataNum Then
                                    f = True
                                End If
                            End If
                        Case Else
                            If attrData.TotalData.LV1.Lay_Maxn = 1 Or Fig_Lay = Layernum Then
                                If Fig_Data = -1 Or Fig_Data = attrData.LayerData(Layernum).atrData.Count Then
                                    f = True
                                End If
                            End If
                    End Select
                Case enmTotalMode_Number.OverLayMode
                    With attrData.TotalData.TotalMode.OverLay.DataSet(attrData.TotalData.TotalMode.OverLay.SelectedIndex)
                        For j As Integer = 0 To .DataItem.Count - 1
                            With .DataItem(j)
                                If .Layer = Fig_Lay Then
                                    Select Case .Print_Mode_Layer
                                        Case enmLayerMode_Number.SoloMode
                                            If Fig_Data = -1 Or Fig_Data = .DataNumber Then
                                                f = True
                                            End If
                                        Case enmLayerMode_Number.GraphMode, enmLayerMode_Number.LabelMode
                                            If Fig_Data = -1 Or Fig_Data = attrData.LayerData(.Layer).atrData.Count Then
                                                f = True
                                            End If
                                    End Select
                                End If
                            End With
                        Next
                    End With
                Case enmTotalMode_Number.SeriesMode
                    Dim SN As Integer = attrData.TotalData.TotalMode.Series.SelectedIndex
                    With attrData.TotalData.TotalMode.Series.DataSet(SN).DataItem(attrData.TempData.Series_temp.Koma)
                        Select Case .Print_Mode_Total
                            Case enmTotalMode_Number.DataViewMode
                                Layernum = .Layer
                                DataNum = .Data
                                Select Case .Print_Mode_Layer
                                    Case enmLayerMode_Number.SoloMode
                                        If attrData.TotalData.LV1.Lay_Maxn = 1 Or Fig_Lay = Layernum Then
                                            If Fig_Data = -1 Or Fig_Data = DataNum Then
                                                f = True
                                            End If
                                        End If
                                    Case Else
                                        If attrData.TotalData.LV1.Lay_Maxn = 1 Or Fig_Lay = Layernum Then
                                            If Fig_Data = -1 Or Fig_Data = attrData.LayerData(Layernum).atrData.Count Then
                                                f = True
                                            End If
                                        End If
                                End Select
                            Case 1
                                With attrData.TotalData.TotalMode.OverLay.DataSet(.Data)
                                    For j As Integer = 0 To .DataItem.Count - 1
                                        With .DataItem(j)
                                            If .Layer = Fig_Lay Then
                                                Select Case .Print_Mode_Layer
                                                    Case enmLayerMode_Number.SoloMode
                                                        If .Layer = Fig_Lay Then
                                                            If Fig_Data = 0 Or Fig_Data = .DataNumber Then
                                                                f = True
                                                            End If
                                                        End If
                                                    Case enmLayerMode_Number.GraphMode, enmLayerMode_Number.LabelMode
                                                        If Fig_Data = 0 Or Fig_Data = attrData.LayerData(.Layer).atrData.Count Then
                                                            f = True
                                                        End If
                                                End Select
                                            End If
                                        End With
                                    Next
                                End With
                        End Select
                    End With
            End Select
        End If
        Return f

    End Function

    Private Shared Sub PrintGraphMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                      ByVal Layernum As Integer, ByVal DataSet As Integer)
        With attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode.DataSet(DataSet)
            Select Case .GraphMode
                Case enmGraphMode.PieGraph, enmGraphMode.StackedBarGraph
                    PrintGraph_Pie_StackdBarMode(g, prog, attrData, Layernum, DataSet)
                Case enmGraphMode.LineGraph, enmGraphMode.BarGraph
                    PrintGraph_Line_BarMode(g, prog, attrData, Layernum, DataSet)
            End Select
        End With
    End Sub
    ''' <summary>
    ''' 重ね合わせ表示モード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="DataSet"></param>
    ''' <remarks></remarks>
    Private Shared Sub Print_OverLay(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                     ByVal DataSet As Integer)


        attrData.TempData.OverLay_Temp.OverLay_Printing_Flag = True


        Dim Num As Integer = attrData.TotalData.TotalMode.OverLay.DataSet(DataSet).DataItem.Count

        For i As Integer = 0 To Num - 1
            attrData.TempData.OverLay_Temp.Printing_Number = i
            With attrData.TotalData.TotalMode.OverLay.DataSet(DataSet).DataItem(i)
                If .Print_Mode_Layer = enmLayerMode_Number.SoloMode Then
                    Dim Equal_Mode_N As Integer = 0
                    For j As Integer = 0 To Num - 1
                        If i = j Then
                            attrData.TempData.OverLay_Temp.OverLay_EMode_Now = Equal_Mode_N
                            Equal_Mode_N += 1
                        Else
                            Dim ovData As clsAttrData.strOverLay_DataSet_Item_Info = attrData.TotalData.TotalMode.OverLay.DataSet(DataSet).DataItem(j)
                            If ovData.Layer = .Layer And ovData.Mode = .Mode And
                                .Mode <> enmSoloMode_Number.ClassODMode Then
                                Equal_Mode_N += 1
                            End If
                        End If
                    Next
                    attrData.TempData.OverLay_Temp.OverLay_EMode_N = Equal_Mode_N
                End If
                OverLay_Print_Sub(g, prog, attrData, attrData.TotalData.TotalMode.OverLay.DataSet(DataSet).DataItem(i))
            End With
        Next
        attrData.TempData.OverLay_Temp.OverLay_Printing_Flag = False
    End Sub
    Private Shared Sub OverLay_Print_Sub(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                         ByRef Ov_Data As clsAttrData.strOverLay_DataSet_Item_Info)

        With Ov_Data
            If .TileMapf = True Then
                printTMS(g, attrData, .TileData)
            Else
                Dim MFileName As String = attrData.LayerData(.Layer).MapFileName
                Select Case .Print_Mode_Layer
                    Case enmLayerMode_Number.SoloMode
                        Select Case .Mode
                            Case enmSoloMode_Number.ClassPaintMode
                                attrData.ResetMPSubLineDrawn(MFileName)
                                PrintClassPaintMode(g, prog, attrData, .Layer, .DataNumber)
                            Case enmSoloMode_Number.MarkSizeMode
                                PrintMarkSizeMode(g, prog, attrData, .Layer, .DataNumber)
                            Case enmSoloMode_Number.MarkBlockMode
                                attrData.TempData.DotMap_Temp.DotMapTempResetF = True
                                PrintMarkBlockMode(g, prog, attrData, .Layer, .DataNumber)
                            Case enmSoloMode_Number.ContourMode
                                attrData.TempData.ContourMode_Temp.ContourDataResetF = True
                                PrintContourMode(g, prog, attrData, .Layer, .DataNumber)
                            Case enmSoloMode_Number.ClassHatchMode
                                attrData.ResetMPSubLineDrawn(MFileName)
                                PrintClassHatchMode(g, prog, attrData, .Layer, .DataNumber)
                            Case enmSoloMode_Number.ClassMarkMode
                                PrintClassMarkMode(g, prog, attrData, .Layer, .DataNumber)
                            Case enmSoloMode_Number.ClassODMode
                                If attrData.LayerData(.Layer).Shape = enmShape.LineShape Then
                                    PrintClassLineShapeSENMode(g, prog, attrData, .Layer, .DataNumber)
                                Else
                                    PrintClassODMode(g, prog, attrData, .Layer, .DataNumber)
                                End If
                            Case enmSoloMode_Number.MarkTurnMode
                                PrintMarkTurnMode(g, prog, attrData, .Layer, .DataNumber)
                            Case enmSoloMode_Number.MarkBarMode
                                PrintMarkBarMode(g, prog, attrData, .Layer, .DataNumber)
                            Case enmSoloMode_Number.StringMode
                                PrintStringMode(g, prog, attrData, .Layer, .DataNumber)
                        End Select
                    Case enmLayerMode_Number.GraphMode
                        PrintGraphMode(g, prog, attrData, .Layer, .DataNumber)
                    Case enmLayerMode_Number.LabelMode
                        PrintLabelMode(g, prog, attrData, .Layer, .DataNumber)
                    Case enmLayerMode_Number.TripMode
                        PrintTripMode(g, prog, attrData, .Layer, .DataNumber)
                End Select
            End If
        End With


    End Sub
    Private Shared Sub PrintTripMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                        ByVal Layernum As Integer, ByVal DataSet As Integer)
        Dim attTrip As clsAttrData.strTrip_Data = attrData.LayerData(Layernum).LayerModeViewSettings.TripMode.DataSet(DataSet)
        With attrData.LayerData(Layernum).LayerModeViewSettings.TripMode
            With .DataSet(DataSet)
                attrData.TempData.Trip_Temp.Trip_StartTime = .StartTime
                attrData.TempData.Trip_Temp.Trip_EndTime = .EndTime
                Select Case .Mode
                    Case clsAttrData.enmTripMode.Blanc
                        PrintTrip_WhiteMap(g, prog, attrData, Layernum, DataSet)
                    Case clsAttrData.enmTripMode.TripDefinitionLayerDataMode
                        PrintTrip_Definition(g, prog, attrData, Layernum, DataSet)
                    Case clsAttrData.enmTripMode.TripLayerDataMode
                        PrintTrip_Complex(g, prog, attrData, Layernum, DataSet)
                End Select
            End With
        End With

    End Sub

    Private Shared Sub PrintTrip_Complex(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                    ByVal Layernum As Integer, ByVal DataSet As Integer)


        Dim DataStay As Integer
        Dim DataMove As Integer
        Dim DataStayMode As clsAttrData.enmTripDrawType
        Dim DataMoveMode As clsAttrData.enmTripDrawType
        Dim Category_Array_Move() As Integer
        Dim Category_Array_Stay() As Integer

        Vector_Dummy_Boundary(g, attrData, Layernum, True, True)

        With attrData.LayerData(Layernum).LayerModeViewSettings.TripMode.DataSet(DataSet)
            DataStay = .Stay_Data - 2
            DataMove = .Move_Data - 2
            DataStayMode = .Stay_Data_Mode
            DataMoveMode = .Move_Data_Mode
        End With
        If DataStay >= 0 Then
            Category_Array_Stay = attrData.Get_Categoly(Layernum, DataStay)
        End If
        If DataMove >= 0 Then
            Category_Array_Move = attrData.Get_Categoly(Layernum, DataMove)
        End If

        Dim n As Integer = Get_Same_Trip_Series(g, attrData, Layernum, DataSet)
        prog.Maximum = n
        Dim ProgInterval As Integer = n \ 10
        If ProgInterval < 5 Then
            ProgInterval = 5
        End If
        Trip_Print_Start_End_Mark(g, attrData, 0)
        Dim Set3D As Boolean = attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F
        For i As Integer = 0 To n - 1
            If i Mod ProgInterval = 0 Then
                prog.Value = i
            End If
            With attrData.TempData.Trip_Temp.Trip_Print_XY(i)
                Select Case DataStay    '滞在ライン
                    Case -2
                    Case -1
                        If Set3D = True And .Stay_F = True Then
                            Trip_Draw_Line(g, attrData, .StayP1, .StayP2, attrData.TotalData.ViewStyle.Trip_Line.Stay_Line)
                        End If
                    Case Else
                        Dim Cate As Integer = Category_Array_Stay(.Number)
                        If Set3D = True Then
                            If Cate <> -1 And .Stay_F = True Then
                                Dim T_Line_Pat As Line_Property
                                If DataStayMode = clsAttrData.enmTripDrawType.PaintMode Then
                                    T_Line_Pat = attrData.TotalData.ViewStyle.Trip_Line.Stay_Line
                                    T_Line_Pat.Set_Same_Color_to_LinePat(attrData.LayerData(Layernum).atrData.Data(DataStay).SoloModeViewSettings.Class_Div(Cate).PaintColor)
                                Else
                                    T_Line_Pat = attrData.LayerData(Layernum).atrData.Data(DataStay).SoloModeViewSettings.Class_Div(Cate).ODLinePat
                                End If
                                Trip_Draw_Line(g, attrData, .StayP1, .StayP2, T_Line_Pat) '滞在ライン
                            End If
                        Else
                            If Cate <> -1 And .Stay_F = True Then
                                Dim PM As Mark_Property= attrData.LayerData(Layernum).LayerModeViewSettings.PointLineShape.PointMark
                                Dim r As Integer = attrData.Radius(attrData.LayerData(Layernum).LayerModeViewSettings.PointLineShape.PointMark.WordFont.Body.Size, 1, 1)
                                PM.Tile.TileCode = enmTilePattern.Paint
                                If attrData.Check_Screen_In(.StayP1, r) = True Then
                                    If DataStayMode = clsAttrData.enmTripDrawType.PaintMode Then
                                        PM.Tile.Line.Set_Same_Color_to_LinePat(attrData.LayerData(Layernum).atrData.Data(DataStay).SoloModeViewSettings.Class_Div(Cate).PaintColor)
                                    Else
                                        PM.Tile.Line = attrData.LayerData(Layernum).atrData.Data(DataStay).SoloModeViewSettings.Class_Div(Cate).ODLinePat
                                    End If
                                    attrData.Draw_Mark(g, .StayP1, r, PM)
                                End If
                            End If
                        End If
                End Select

                Select Case DataMove
                    Case -2
                    Case -1
                        Trip_Draw_Line(g, attrData, .TripP1, .TripP2, attrData.TotalData.ViewStyle.Trip_Line.Trip_Line)
                    Case Else
                        Dim Cate As Integer = Category_Array_Move(.Number)
                        If .Trip_F = True And Cate <> -1 Then
                            Dim T_Line_Pat As Line_Property
                            If DataMoveMode = clsAttrData.enmTripDrawType.PaintMode Then
                                T_Line_Pat = attrData.TotalData.ViewStyle.Trip_Line.Trip_Line
                                T_Line_Pat.Set_Same_Color_to_LinePat(attrData.LayerData(Layernum).atrData.Data(DataMove).SoloModeViewSettings.Class_Div(Cate).PaintColor)
                            Else
                                T_Line_Pat = attrData.LayerData(Layernum).atrData.Data(DataMove).SoloModeViewSettings.Class_Div(Cate).ODLinePat
                            End If
                            Trip_Draw_Line(g, attrData, .TripP1, .TripP2, T_Line_Pat) '移動ライン
                        End If
                End Select
            End With
        Next
        Trip_Print_Start_End_Mark(g, attrData, 1)
        Trip_Frame(g, attrData, Layernum, DataSet)
    End Sub

    Private Shared Sub PrintTrip_Definition(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                    ByVal Layernum As Integer, ByVal DataSet As Integer)

        Vector_Dummy_Boundary(g, attrData, Layernum, True, True)

        Dim Set3D As Boolean = attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F
        Dim TDEFL As Integer = attrData.Get_Trip_Definition_Layer_Number()
        Dim TDEFL_Data As Integer
        Dim md As clsAttrData.enmTripDrawType
        With attrData.LayerData(Layernum).LayerModeViewSettings.TripMode.DataSet(DataSet)
            TDEFL_Data = .Definition_Layer_Data
            md = .Definition_Layer_Data_Mode
        End With

        Dim n As Integer = Get_Same_Trip_Series(g, attrData, Layernum, DataSet)
        prog.Maximum = n
        Dim ProgInterval As Integer = n \ 10
        If ProgInterval < 5 Then
            ProgInterval = 5
        End If
        Trip_Print_Start_End_Mark(g, attrData, 0)
        Dim Category_Array() As Integer = attrData.Get_Categoly(TDEFL, TDEFL_Data)
        For i As Integer = 0 To n - 1
            If i Mod ProgInterval = 0 Then
                prog.Value = i
            End If
            With attrData.TempData.Trip_Temp.Trip_Print_XY(i)
                Dim O_Code As Integer = attrData.LayerData(Layernum).atrObject.TripObjData(.Number).TripPersonCode
                If O_Code <> -1 Then
                    Dim Cate As Integer = Category_Array(O_Code)
                    Select Case md
                        Case clsAttrData.enmTripDrawType.PaintMode
                            Dim T_Line_Pat As Line_Property = attrData.TotalData.ViewStyle.Trip_Line.Stay_Line
                            T_Line_Pat.Set_Same_Color_to_LinePat(attrData.LayerData(TDEFL).atrData.Data(TDEFL_Data).SoloModeViewSettings.Class_Div(Cate).PaintColor)
                            If Set3D = True And .Stay_F = True Then
                                Trip_Draw_Line(g, attrData, .StayP1, .StayP2, T_Line_Pat) '滞在ライン
                            End If
                            If .Trip_F = True Then
                                Trip_Draw_Line(g, attrData, .TripP1, .TripP2, T_Line_Pat) '移動ライン
                            End If
                        Case clsAttrData.enmTripDrawType.OdMode
                            Dim T_Line_Pat As Line_Property = attrData.LayerData(TDEFL).atrData.Data(TDEFL_Data).SoloModeViewSettings.Class_Div(Cate).ODLinePat
                            If Set3D = True And .Stay_F = True Then
                                Trip_Draw_Line(g, attrData, .StayP1, .StayP2, T_Line_Pat) '滞在ライン
                            End If
                            If .Trip_F = True Then
                                Trip_Draw_Line(g, attrData, .TripP1, .TripP2, T_Line_Pat) '移動ライン
                            End If
                    End Select
                Else  '移動主体定義レイヤにない場合
                    If Set3D = True And .Stay_F = True Then
                        Trip_Draw_Line(g, attrData, .StayP1, .StayP2, attrData.TotalData.ViewStyle.Trip_Line.Stay_Line)  '滞在ライン
                    End If
                    If .Trip_F = True Then
                        Trip_Draw_Line(g, attrData, .TripP1, .TripP2, attrData.TotalData.ViewStyle.Trip_Line.Trip_Line) '移動ライン
                    End If
                End If


            End With
        Next
        Trip_Print_Start_End_Mark(g, attrData, 1)

        Trip_Frame(g, attrData, Layernum, DataSet)
    End Sub

    Private Shared Sub PrintTrip_WhiteMap(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                        ByVal Layernum As Integer, ByVal DataSet As Integer)
        Vector_Dummy_Boundary(g, attrData, Layernum, True, True)
        PrintTrip_Normal(g, prog, attrData, Layernum, DataSet)
    End Sub
    Private Shared Sub PrintTrip_Normal(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                        ByVal Layernum As Integer, ByVal DataSet As Integer)
        Dim n As Integer = Get_Same_Trip_Series(g, attrData, Layernum, DataSet)
        prog.Maximum = n
        Dim ProgInterval As Integer = n \ 10
        If ProgInterval < 5 Then
            ProgInterval = 5
        End If
        Call Trip_Print_Start_End_Mark(g, attrData, 0)
        For i As Integer = 0 To n - 1
            If i Mod ProgInterval = 0 Then
                prog.Value = i
            End If
            With attrData.TempData.Trip_Temp.Trip_Print_XY(i)
                If attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F = True And .Stay_F = True Then
                    Trip_Draw_Line(g, attrData, .StayP1, .StayP2, attrData.TotalData.ViewStyle.Trip_Line.Stay_Line) '滞在ライン
                End If
                If .Trip_F = True Then
                    Trip_Draw_Line(g, attrData, .TripP1, .TripP2, attrData.TotalData.ViewStyle.Trip_Line.Trip_Line) '移動ライン
                End If
            End With
        Next
        Trip_Print_Start_End_Mark(g, attrData, 1)

        Trip_Frame(g, attrData, Layernum, DataSet)
    End Sub
    ''' <summary>
    ''' 3D表示時の移動データの飾り
    ''' </summary>
    ''' <param name="zlf"></param>
    ''' <param name="zpf"></param>
    ''' <param name="vlf"></param>
    ''' <param name="trn"></param>
    ''' <param name="ZeroPoint"></param>
    ''' <remarks></remarks>
    Private Shared Sub Trip_Zero_Line_Point_Draw(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal zlf As Boolean,
                                                 ByVal zpf As Boolean, ByVal vlf As Boolean,
                                          ByVal trn As Integer, ByRef ZeroPoint() As clsAttrData.Trip_XY_info)

        Dim ox As Integer, oy As Integer


        '地面上の移動線を描く
        If zlf = True Then
            For i As Integer = 0 To trn - 1
                With ZeroPoint(i)
                    If .Trip_F = True Then
                        Trip_Draw_Line(g, attrData, .TripP1, .TripP2, attrData.TotalData.ViewStyle.Trip_Line.ZeroLine) '移動ライン
                    End If
                End With
            Next
        End If
        ''地面上の滞在地点を描く
        If zpf = True Then
            Dim r As Integer = attrData.Radius(attrData.TotalData.ViewStyle.Trip_Line.ZeroPoint_Mark.WordFont.Body.Size, 1, 1)
            For i As Integer = 0 To trn - 1
                With ZeroPoint(i)
                    If .Stay_F = True Then
                        Dim C_Rect As Rectangle = spatial.Get_Rectangle(.StayP1, r)
                        If attrData.Check_Screen_In(C_Rect) = True Then
                            attrData.Draw_Mark(g, .StayP1, r, attrData.TotalData.ViewStyle.Trip_Line.ZeroPoint_Mark)
                        End If
                    End If
                End With
            Next
        End If
        '地面上の滞在地点とZ軸の滞在地点を結ぶ
        If vlf = True Then
            For i As Integer = 0 To trn - 1
                With ZeroPoint(i)
                    If .Stay_F = True Then
                        Trip_Draw_Line(g, attrData, attrData.TempData.Trip_Temp.Trip_Print_XY(i).StayP1, .StayP1, attrData.TotalData.ViewStyle.Trip_Line.VerticalLine) '垂直ライン
                    End If
                End With
            Next
        End If
    End Sub

    ''' <summary>
    ''' 移動表示の3D枠表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub Trip_Frame(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal DataSet As Integer)
        '

        If attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F = False Or attrData.TotalData.ViewStyle.Trip_Line.Frame_Print = False Then
            Return
        End If

        Dim StdWSize As Single = attrData.TotalData.ViewStyle.ScrData.STDWsize
        Dim XY(3, 1) As Point
        With attrData.TotalData.ViewStyle.ScrData.MapRectangle
            For i As Integer = 0 To 1
                Dim pxy(4) As Point
                Dim z As Single
                If i = 0 Then
                    z = 0
                Else
                    z = StdWSize * attrData.TotalData.ViewStyle.Trip_Line.Height / 100
                End If
                pxy(0) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_Z(New Point(.Left, .Top), z)
                pxy(1) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_Z(New Point(.Right, .Top), z)
                pxy(2) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_Z(New Point(.Right, .Bottom), z)
                pxy(3) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_Z(New Point(.Left, .Bottom), z)
                pxy(4) = pxy(0)
                For j As Integer = 0 To 3
                    XY(j, i) = pxy(j)
                Next
                attrData.Draw_Line(g, attrData.TotalData.ViewStyle.Trip_Line.Frame_Line, 5, pxy)
            Next
        End With
        For i As Integer = 0 To 3
            attrData.Draw_Line(g, attrData.TotalData.ViewStyle.Trip_Line.Frame_Line, XY(i, 0), XY(i, 1))
        Next

        Dim MaxHeight As Single = StdWSize * attrData.TotalData.ViewStyle.Trip_Line.Height / 100

        Dim TimeMax As DateTime = attrData.TempData.Trip_Temp.Trip_EndTime
        Dim TimeMin As DateTime = attrData.TempData.Trip_Temp.Trip_StartTime

        Dim TimeWidth As Double = (TimeMax - TimeMin).TotalDays


        With attrData.TotalData.ViewStyle.Trip_Line
            Dim zdata As Integer = attrData.LayerData(Layernum).LayerModeViewSettings.TripMode.DataSet(DataSet).ZData
            If .TimeLegend_Position <> 4 Then
                Dim tx As String
                If zdata = 0 Then
                    tx = CStr(TimeMin.Year) & "年" & CStr(TimeMin.Month) & "月"
                    If TimeWidth <= 365 Then
                        tx += CStr(TimeMin.Day) & "日"
                        If TimeWidth <= 1 Then
                            tx += CStr(TimeMin.Hour) & "時" & CStr(TimeMin.Minute) & "分"
                        End If
                    End If
                Else
                    tx = "0"
                End If
                attrData.Draw_Print(g, tx, New Point(XY(.TimeLegend_Position, 0).X + 5, XY(.TimeLegend_Position, 0).Y), .TimeLegend_Font, enmHorizontalAlignment.Left, enmVerticalAlignment.Bottom)

                If zdata = 0 Then
                    tx = CStr(TimeMax.Year) & "年" & CStr(TimeMax.Month) & "月"
                    If TimeWidth <= 365 Then
                        tx += CStr(TimeMax.Day) & "日"
                        If TimeWidth <= 1 Then
                            tx += CStr(TimeMax.Hour) & "時" & CStr(TimeMax.Minute) & "分"
                        End If
                    End If
                Else
                    tx = Str(attrData.LayerData(Layernum).atrData.Data(zdata - 1).Statistics.Max) + attrData.Get_DataUnit_With_Kakko(Layernum, zdata - 1)
                End If
                attrData.Draw_Print(g, tx, New Point(XY(.TimeLegend_Position, 1).X + 5, XY(.TimeLegend_Position, 1).Y), .TimeLegend_Font, enmHorizontalAlignment.Left, enmVerticalAlignment.Bottom)
            End If
        End With
    End Sub
    ''' <summary>
    ''' レイヤ内の表示する移動データのすべての座標を取得
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="Num_MultiDataSet"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Get_Same_Trip_Series(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal Num_MultiDataSet As Integer) As Integer

        Dim obn As Integer = attrData.LayerData(Layernum).atrObject.ObjectNum
        ReDim attrData.TempData.Trip_Temp.Trip_Print_XY(obn - 1)
        Dim zpf As Boolean, zlf As Boolean, vlf As Boolean, socf As Boolean
        With attrData.TotalData.ViewStyle
            With .Trip_Line
                zpf = .ZeroPointF
                zlf = .ZeroLineF
                vlf = .VerticalLineF
                socf = .Overlap_Mode
            End With
            If .ScrData.ThreeDMode.Set3D_F = False Then
                zpf = False
                zlf = False
                vlf = False
                socf = False
            End If
        End With
        If socf = True Then
            ReDim attrData.TempData.Trip_Temp.Stay_Object_Check(attrData.LayerData(Layernum).MapFileData.Map.Kend - 1)
        End If

        Dim ZeroPoint() As clsAttrData.Trip_XY_info
        If zpf = True Or zlf = True Or vlf = True Then
            ReDim ZeroPoint(obn - 1)
        End If

        Dim Trip_Definition_Layer_Number As Integer = attrData.Get_Trip_Definition_Layer_Number
        Dim trn As Integer = 0
        Dim i As Integer = 0
        Do
            '連続する同一主体名の終点ポインタと主体名を取得
            Dim Subject_Name As String
            Dim j As Integer = Get_Same_SubjectName_Point(attrData, Layernum, i, Subject_Name)
            '定義レイヤのデータのチェックで表示非表示
            If attrData.Check_Condition(Trip_Definition_Layer_Number, attrData.Get_KenObjCode(Layernum, i)) = True Then
                Dim i3 As Integer
                Dim i4 As Integer
                If Check_Start_End_TripNumber(attrData, Layernum, trn, i, j, i3, i4) = True Then
                    For k As Integer = i3 To i4
                        With attrData.TempData.Trip_Temp.Trip_Print_XY(trn)
                            .Number = k
                            If .Stay_F = True Then
                                If zpf = True Or vlf = True Then
                                    With ZeroPoint(trn)
                                        Get_Trip_StayLine_XY(attrData, Layernum, k, .StayP1, .StayP2, False)
                                        .Stay_F = True
                                    End With
                                End If
                                Get_Trip_StayLine_XY(attrData, Layernum, k, .StayP1, .StayP2, True)
                            End If
                            If .Trip_F = True Then
                                If zlf = True Then
                                    With ZeroPoint(trn)
                                        Get_Trip_TripLine_XY(attrData, Layernum, k, .TripP1, .TripP2, False)
                                        .Trip_F = True
                                    End With
                                End If
                                Get_Trip_TripLine_XY(attrData, Layernum, k, .TripP1, .TripP2, True)
                            End If
                        End With
                        trn += 1
                    Next
                    If socf = True Then
                        For k As Integer = 0 To attrData.LayerData(Layernum).MapFileData.Map.Kend - 1
                            attrData.TempData.Trip_Temp.Stay_Object_Check(k).Flag = False
                        Next
                    End If
                End If
            End If
            i = j
        Loop While i < obn - 1
        ReDim Preserve attrData.TempData.Trip_Temp.Trip_Print_XY(trn)

        If socf = True Then
            ReDim attrData.TempData.Trip_Temp.Stay_Object_Check(0)
        End If

        Trip_Zero_Line_Point_Draw(g, attrData, zlf, zpf, vlf, trn, ZeroPoint)

        Return trn
    End Function
    ''' <summary>
    ''' 滞在ライン、移動ラインの表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="P1"></param>
    ''' <param name="P2"></param>
    ''' <param name="Line_Pat"></param>
    ''' <remarks></remarks>
    Private Shared Sub Trip_Draw_Line(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal P1 As Point, ByVal P2 As Point, ByRef Line_Pat As Line_Property)

        Dim C_Rect As Rectangle = spatial.Get_Rectangle(P1, P2)
        If attrData.Check_Screen_In(C_Rect) = True Then
            attrData.Draw_Line(g, Line_Pat, P1, P2)
        End If
    End Sub
    ''' <summary>
    ''' 滞在ラインの座標を求める
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="Number"></param>
    ''' <param name="P1">到着時座標</param>
    ''' <param name="P2">出発時座標</param>
    ''' <param name="Z_Flag">高さデータを使用する</param>
    ''' <remarks></remarks>
    Private Shared Sub Get_Trip_StayLine_XY(ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal Number As Integer,
                                     ByRef P1 As Point, ByRef P2 As Point, ByVal Z_Flag As Boolean)


        Dim f1 As Integer = Get_TripPosition(attrData, Layernum, Number, 1, P1, Z_Flag)
        If Z_Flag = True Then
            Dim f2 As Integer = Get_TripPosition(attrData, Layernum, Number, 2, P2, Z_Flag)
        Else
            P2 = P1
        End If

    End Sub
    ''' <summary>
    ''' 移動ラインの座標を求める
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="Number"></param>
    ''' <param name="P1">出発地点の座標1(戻り値)</param>
    ''' <param name="P2">次の到着地点の座標2(戻り値)</param>
    ''' <param name="Z_Flag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Get_Trip_TripLine_XY(ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal Number As Integer,
                                ByRef P1 As Point, ByRef P2 As Point, Z_Flag As Boolean) As Boolean

        Dim f1 As Integer = Get_TripPosition(attrData, Layernum, Number, 2, P1, Z_Flag)
        Dim f2 As Integer = Get_TripPosition(attrData, Layernum, Number + 1, 1, P2, Z_Flag)
        If f1 = 0 And f2 = 0 Then
        Else
            Dim Set3D As Boolean = attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F
            Dim Trip_EndTime As DateTime = attrData.TempData.Trip_Temp.Trip_EndTime
            Dim Trip_StartTime As DateTime = attrData.TempData.Trip_Temp.Trip_StartTime
            Dim TripPType As clsAttrData.enmTripPositionType = attrData.LayerData(Layernum).TripType
            Dim np As PointF
            Dim cp1 As PointF
            Dim cp2 As PointF
            Dim MaxHeight As Single = attrData.TotalData.ViewStyle.ScrData.STDWsize * attrData.TotalData.ViewStyle.Trip_Line.Height / 100
            Dim TimeWidth As Double = (Trip_EndTime - Trip_StartTime).TotalDays
            Select Case TripPType
                Case clsAttrData.enmTripPositionType.ObjectSet
                    Dim O_Code1 As Integer = attrData.LayerData(Layernum).atrObject.TripObjData(Number).PositionObjCode
                    Dim O_Code2 As Integer = attrData.LayerData(Layernum).atrObject.TripObjData(Number + 1).PositionObjCode
                    If Set3D = True And attrData.TotalData.ViewStyle.Trip_Line.Overlap_Mode = True Then
                        cp1 = attrData.TempData.Trip_Temp.Stay_Object_Check(O_Code1).point
                        cp2 = attrData.TempData.Trip_Temp.Stay_Object_Check(O_Code2).point
                    Else
                        attrData.LayerData(Layernum).MapFileData.Get_Enable_CenterP(cp1, O_Code1, attrData.LayerData(Layernum).Time)
                        attrData.LayerData(Layernum).MapFileData.Get_Enable_CenterP(cp2, O_Code2, attrData.LayerData(Layernum).Time)
                    End If
                Case clsAttrData.enmTripPositionType.LatLon
                    With attrData.LayerData(Layernum)
                        Dim latlon As strLatLon = spatial.ConvertRefSystemLatLon(.atrObject.TripObjData(Number).LatLon, .ReferenceSystem, attrData.TotalData.ViewStyle.Zahyo.System)
                        cp1 = spatial.Get_Converted_XY(latlon.toPointF, attrData.TotalData.ViewStyle.Zahyo)
                        latlon = spatial.ConvertRefSystemLatLon(.atrObject.TripObjData(Number + 1).LatLon, .ReferenceSystem, attrData.TotalData.ViewStyle.Zahyo.System)
                        cp2 = spatial.Get_Converted_XY(latlon.toPointF, attrData.TotalData.ViewStyle.Zahyo)
                    End With

            End Select
            Dim T1 As DateTime = attrData.LayerData(Layernum).atrObject.TripObjData(Number).DepartureTime
            Dim T2 As DateTime = attrData.LayerData(Layernum).atrObject.TripObjData(Number + 1).ArrivalTime
            Dim SpanT12 As Double = (T1 - T2).TotalDays
            If f1 = -1 And f2 = 1 Then
                Dim TV As DateTime = Trip_StartTime
                np.X = (cp1.X * (TV - T2).TotalDays + cp2.X * (T1 - TV).TotalDays) / SpanT12
                np.Y = (cp1.Y * (TV - T2).TotalDays + cp2.Y * (T1 - TV).TotalDays) / SpanT12
                Dim z As Single = 0
                If Set3D = True And Z_Flag = True Then
                    z = MaxHeight * ((TV - Trip_StartTime).TotalDays / TimeWidth)
                End If
                P1 = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_Z(np, z)

                TV = Trip_EndTime
                np.X = (cp1.X * (TV - T2).TotalDays + cp2.X * (T1 - TV).TotalDays) / SpanT12
                np.Y = (cp1.Y * (TV - T2).TotalDays + cp2.Y * (T1 - TV).TotalDays) / SpanT12
                If Set3D = True And Z_Flag = True Then
                    z = MaxHeight * ((TV - Trip_StartTime).TotalDays / TimeWidth)
                Else
                    z = 0
                End If
                P2 = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_Z(np, z)
            Else
                Dim TV As DateTime
                If f1 = -1 And f2 = 0 Then
                    TV = Trip_StartTime
                ElseIf f1 = 0 And f2 = 1 Then
                    TV = Trip_EndTime
                End If
                np.X = (cp1.X * (TV - T2).TotalDays + cp2.X * (T1 - TV).TotalDays) / SpanT12
                np.Y = (cp1.Y * (TV - T2).TotalDays + cp2.Y * (T1 - TV).TotalDays) / SpanT12
                Dim z As Single = 0
                If Set3D = True And Z_Flag = True Then
                    z = MaxHeight * ((TV - Trip_StartTime).TotalDays / TimeWidth)
                End If
                Dim P3 As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_Z(np, z)
                If f1 = -1 And f2 = 0 Then
                    P1 = P3
                ElseIf f1 = 0 And f2 = 1 Then
                    P2 = P3
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' 戻り値は、-1/時間外より早い 0/時間内 1/時間より遅い
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="Number"></param>
    ''' <param name="Arrival_or_Departure">1到着時間  2出発時間</param>
    ''' <param name="OutP">指定した番号の出発時間または到着時間の３次元変換後のXY座標を取得</param>
    ''' <param name="Z_Flag">高さデータを使用する</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Get_TripPosition(ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal Number As Integer,
                            ByVal Arrival_or_Departure As Integer, ByRef OutP As Point, ByVal Z_Flag As Boolean) As Integer


        Dim StdWSize As Single = attrData.TotalData.ViewStyle.ScrData.STDWsize
        Dim Trip_EndTime As DateTime = attrData.TempData.Trip_Temp.Trip_EndTime
        Dim Trip_StartTime As DateTime = attrData.TempData.Trip_Temp.Trip_StartTime
        Dim ZRange As Double
        Dim selData As Integer = attrData.LayerData(Layernum).LayerModeViewSettings.TripMode.SelectedIndex
        Dim Zdata As Integer = attrData.LayerData(Layernum).LayerModeViewSettings.TripMode.DataSet(selData).ZData
        If Zdata = 0 Then
            ZRange = (Trip_EndTime - Trip_StartTime).TotalDays
        Else
            ZRange = attrData.LayerData(Layernum).atrData.Data(Zdata - 1).Statistics.Max
        End If
        Dim TripPType As clsAttrData.enmTripPositionType = attrData.LayerData(Layernum).TripType
        Dim MaxHeight As Single = StdWSize * attrData.TotalData.ViewStyle.Trip_Line.Height / 100

        Dim O_Code As Integer = attrData.LayerData(Layernum).atrObject.TripObjData(Number).PositionObjCode
        Dim cp As PointF
        If attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F = True And attrData.TotalData.ViewStyle.Trip_Line.Overlap_Mode = True And
                TripPType = clsAttrData.enmTripPositionType.ObjectSet Then
            '3D表示時に滞在ばょしょが重なった場合にずらす処理
            With attrData.TempData.Trip_Temp.Stay_Object_Check(O_Code)
                Dim ct As Integer = .Count
                If .Flag = False Then
                    attrData.LayerData(Layernum).MapFileData.Get_Enable_CenterP(cp, O_Code, attrData.LayerData(Layernum).Time)
                    ct += 1
                    .Count = ct
                    .Flag = True
                    If ct = 1 Then
                        .point = cp
                    Else
                        Dim n As Integer = 1
                        Dim n2 As Integer = 0
                        Do
                            n2 += n * 10
                            n += 1
                        Loop While n2 < ct
                        Dim r As Single = (New System.Random).NextDouble * 0.4 + (n - 2) * 0.4
                        Dim Rad As Single = (New System.Random).NextDouble * Math.PI * 2
                        .point.X = cp.X + Math.Cos(Rad) * r * StdWSize / 100
                        .point.Y = cp.Y + Math.Sin(Rad) * r * StdWSize / 100
                    End If
                End If
                cp = .point
            End With
        Else
            If TripPType = clsAttrData.enmTripPositionType.ObjectSet Then
                attrData.LayerData(Layernum).MapFileData.Get_Enable_CenterP(cp, O_Code, attrData.LayerData(Layernum).Time)
            Else
                With attrData.LayerData(Layernum)
                    Dim latlon As strLatLon = spatial.ConvertRefSystemLatLon(.atrObject.TripObjData(Number).LatLon, .ReferenceSystem, attrData.TotalData.ViewStyle.Zahyo.System)
                    cp = spatial.Get_Converted_XY(latlon.toPointF, attrData.TotalData.ViewStyle.Zahyo)
                End With
            End If
        End If

        Dim TV As DateTime
        If Arrival_or_Departure = 1 Then
            TV = attrData.LayerData(Layernum).atrObject.TripObjData(Number).ArrivalTime
        Else
            TV = attrData.LayerData(Layernum).atrObject.TripObjData(Number).DepartureTime
        End If

        Dim retV As Integer
        If TV < Trip_StartTime Then
            TV = Trip_StartTime
            retV = -1
        ElseIf TV > Trip_EndTime Then
            TV = Trip_EndTime
            retV = 1
        Else
            retV = 0
        End If

        Dim z As Single = 0
        If attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F = True And Z_Flag = True Then
            If Zdata = 0 Then
                z = MaxHeight * ((TV - Trip_StartTime).TotalDays / ZRange)
            Else
                Dim v As String = attrData.Get_Data_Value(Layernum, Zdata - 1, Number, "*")
                If v <> "*" Then
                    z = MaxHeight * (Val(v) / ZRange)
                End If
            End If
        Else

        End If
        OutP = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_Z(cp, z)

        Return retV

    End Function

    ''' <summary>
    ''' トリップデータの開始位置と終了位置を設定し、Trip_Print_XY()の一部を設定する
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="trn"></param>
    ''' <param name="i2">開始ポインタ</param>
    ''' <param name="j">終了ポインタ</param>
    ''' <param name="i3">描画開始番号(戻り値)</param>
    ''' <param name="i4">描画終了番号(戻り値)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Check_Start_End_TripNumber(ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal trn As Integer,
                                                ByVal i2 As Integer, ByVal j As Integer, ByRef i3 As Integer, ByRef i4 As Integer) As Boolean

        Dim S_STTR As Integer
        Dim E_STTR As Integer
        Dim Trip_EndTime As DateTime = attrData.TempData.Trip_Temp.Trip_EndTime
        Dim Trip_StartTime As DateTime = attrData.TempData.Trip_Temp.Trip_StartTime
        '場所や時間が欠損値だった場合はとばす

        Do While (attrData.LayerData(Layernum).atrObject.TripObjData(i2).PositionObjCode = -1)
            i2 += 1
        Loop

        Dim ST As DateTime = attrData.LayerData(Layernum).atrObject.TripObjData(i2).ArrivalTime
        Dim et As DateTime = attrData.LayerData(Layernum).atrObject.TripObjData(j - 1).DepartureTime

        If ST > Trip_EndTime Or et < Trip_StartTime Then
            Return False
        Else
            '描画開始番号
            For k As Integer = i2 To j - 1
                Dim art As DateTime = attrData.LayerData(Layernum).atrObject.TripObjData(k).ArrivalTime
                Dim det As DateTime = attrData.LayerData(Layernum).atrObject.TripObjData(k).DepartureTime
                If art >= Trip_StartTime Then
                    '描画開始時間よりも到着時間が後の箇所があった
                    If k = i2 Then
                        i3 = k
                        S_STTR = 0
                    Else
                        i3 = k - 1
                        S_STTR = 1
                    End If
                    Exit For
                ElseIf det > Trip_StartTime Then
                    '描画開始時間よりも出発時間が後の箇所があった
                    i3 = k
                    S_STTR = 0
                    Exit For
                End If
            Next

            '描画終了番号
            If et <= Trip_EndTime Then
                i4 = j - 1
                E_STTR = 0
            Else
                For k As Integer = j - 1 To i2 Step -1
                    Dim art As DateTime = attrData.LayerData(Layernum).atrObject.TripObjData(k).ArrivalTime
                    Dim det As DateTime = attrData.LayerData(Layernum).atrObject.TripObjData(k).DepartureTime
                    If det <= Trip_EndTime Then
                        '描画終了時間よりも出発時間が前の箇所があった
                        i4 = k
                        E_STTR = 1
                        Exit For
                    ElseIf art <= Trip_EndTime Then
                        '描画終了時間よりも到着時間が前の箇所があった
                        i4 = k
                        E_STTR = 0
                        Exit For
                    End If
                Next
            End If

            If i3 = i4 Then
                '描画開始番号と描画終了番号が同じ
                With attrData.TempData.Trip_Temp.Trip_Print_XY(trn)
                    .Start_F = True
                    .End_F = True
                    If S_STTR = 0 Then
                        .Stay_F = True
                        .Trip_F = True
                    Else
                        .Stay_F = False
                        .Trip_F = True
                    End If
                    If E_STTR = 0 Then
                        .Trip_F = False
                    End If
                End With
            Else
                With attrData.TempData.Trip_Temp.Trip_Print_XY(trn)
                    .Start_F = True
                    .End_F = False
                    If S_STTR = 0 Then
                        .Stay_F = True
                        .Trip_F = True
                    Else
                        .Stay_F = False
                        .Trip_F = True
                    End If
                End With

                With attrData.TempData.Trip_Temp.Trip_Print_XY(trn + i4 - i3)
                    .Start_F = False
                    .End_F = True
                    If E_STTR = 0 Then
                        .Stay_F = True
                        .Trip_F = False
                    Else
                        .Stay_F = True
                        .Trip_F = True
                    End If
                End With
                For k As Integer = i3 + 1 To i4 - 1
                    With attrData.TempData.Trip_Temp.Trip_Print_XY(trn + k - i3)
                        .Stay_F = True
                        .Trip_F = True
                        .Start_F = False
                        .End_F = False
                    End With
                Next
            End If
            Return True
        End If


    End Function

    ''' <summary>
    ''' 連続する同一主体名の終点ポインタ（関数戻り値）と主体名を取得
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="Start_Number">データ中の開始位置</param>
    ''' <param name="Subject_Name">主体名(戻り値)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Get_Same_SubjectName_Point(ByRef attrData As clsAttrData, ByVal Layernum As Integer,
                                            ByVal Start_Number As Integer, ByRef Subject_Name As String) As Integer

        Dim j As Integer = Start_Number
        Dim objName2 As String
        Dim objName As String = attrData.Get_KenObjName(Layernum, Start_Number)
        Do
            objName2 = attrData.Get_KenObjName(Layernum, j + 1)
            j += 1
            If j = attrData.LayerData(Layernum).atrObject.ObjectNum - 1 Then
                j += 1
                Exit Do
            End If
        Loop While objName = objName2
        Subject_Name = objName
        Return j
    End Function
    Private Shared Sub Trip_Print_Start_End_Mark(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Start_End As Integer)


        If attrData.TotalData.ViewStyle.Trip_Line.Start_End_Print = False Then
            Exit Sub
        End If

        '始点・終点記号の表示
        Dim n As Integer = attrData.TempData.Trip_Temp.Trip_Print_XY.Length
        For i As Integer = 0 To n - 1
            With attrData.TempData.Trip_Temp.Trip_Print_XY(i)

                Select Case Start_End
                    Case 0
                        Dim op As Point
                        If .Start_F = True Then
                            If .Stay_F = True Then
                                op = .StayP1
                            Else
                                op = .TripP1
                            End If
                            Dim r As Integer = attrData.Radius(attrData.TotalData.ViewStyle.Trip_Line.StartPoint_Mark.WordFont.Body.Size, 1, 1)
                            Dim C_Rect As Rectangle = spatial.Get_Rectangle(op, r)
                            If attrData.Check_Screen_In(C_Rect) = True Then
                                attrData.Draw_Mark(g, op, r, attrData.TotalData.ViewStyle.Trip_Line.StartPoint_Mark)
                            End If
                        End If
                    Case 1
                        Dim op As Point
                        If .End_F = True Then
                            If .Trip_F = True Then
                                op = .TripP2
                            Else
                                op = .StayP2
                            End If
                            Dim r As Integer = attrData.Radius(attrData.TotalData.ViewStyle.Trip_Line.EndPoint_Mark.WordFont.Body.Size, 1, 1)
                            Dim C_Rect As Rectangle = spatial.Get_Rectangle(op, r)
                            If attrData.Check_Screen_In(C_Rect) = True Then
                                attrData.Draw_Mark(g, op, r, attrData.TotalData.ViewStyle.Trip_Line.EndPoint_Mark)
                            End If
                        End If
                End Select
            End With
        Next

    End Sub

    ''' <summary>
    ''' ラベル表示モード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataSet"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintLabelMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                        ByVal Layernum As Integer, ByVal DataSet As Integer)

        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(Layernum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Clip_F As Boolean
        Dim Original_ClippingRegion2 As Region
        Dim Make_ClippingRegion2 As Region
        If PolygonDummy_ClipSet_F = True Then
            Vector_Dummy_Boundary(g, attrData, Layernum, True, False)
            Clip_F = ClippingRegion_ObjectBoundary_set(g, attrData, Layernum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
        Else
            Clip_F = False
        End If

        Vector_Object_Boundary(g, attrData, Layernum)
        Vector_Dummy_Boundary(g, attrData, Layernum, (Clip_F = False), True)

        Dim attLbl As clsAttrData.strLabel_Data = attrData.LayerData(Layernum).LayerModeViewSettings.LabelMode.DataSet(DataSet).Clone
        Dim LabelMark As Mark_Property = attLbl.Location_Mark


        Dim LocMarkFlag As Boolean = attLbl.Location_Mark_Flag
        Dim mark_r As Integer = attrData.Radius(attLbl.Location_Mark.WordFont.Body.Size, 1, 1)

        If attLbl.Dummy_Object_Flag = True Then
            'ダミーオブジェクトのオブジェクト名
            With attrData.LayerData(Layernum).Dummy
                Dim y2 As Integer
                For i As Integer = 0 To .Count - 1
                    Dim Name As String
                    Dim AP As Point
                    With .DummyObj(i)
                        Name = .Name
                        Dim StartFP As PointF
                        attrData.LayerData(Layernum).MapFileData.Get_Enable_CenterP(StartFP, .code, attrData.LayerData(Layernum).Time)
                        AP = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(StartFP)
                        If LocMarkFlag = True Then
                            Label_MarkPrint(g, attrData, AP, mark_r, LabelMark)
                            AP.Y += mark_r * 4
                        End If
                        attrData.Draw_Print(g, .Name, AP, attLbl.Dummy_Object_Font, enmHorizontalAlignment.Center, enmVerticalAlignment.Top)
                    End With
                Next
            End With
        End If
        If attLbl.Dummy_Object_Group_Flag = True Then
            'ダミーオブジェクトグループのオブジェクト名

            With attrData.LayerData(Layernum)
                For i As Integer = 0 To .DummyGroup.Count - 1
                    Dim obk As Integer = .DummyGroup.DummyObjG(i)
                    Dim temp() As Integer
                    Dim tnp As Integer = .MapFileData.Get_Objects_by_Group(obk, temp, .Time)
                    For j As Integer = 0 To tnp - 1
                        Dim P As PointF
                        attrData.LayerData(Layernum).MapFileData.Get_Enable_CenterP(P, temp(j), attrData.LayerData(Layernum).Time)
                        Dim AP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(P)
                        If attLbl.Location_Mark_Flag = True Then
                            Label_MarkPrint(g, attrData, AP, mark_r, LabelMark)
                            AP.Y += mark_r * 4
                        End If
                        Dim N1 As String()
                        attrData.LayerData(Layernum).MapFileData.Get_Enable_ObjectName(temp(j), .Time, False, N1)
                        Dim Oname As String = ""
                        If attLbl.Dummy_Object_Group_Name1priority = True Or N1.Length = 1 Then
                            Oname = N1(0)
                        Else
                            Oname = String.Join("/", N1)
                        End If
                        attrData.Draw_Print(g, Oname, AP, attLbl.Dummy_Object_Group_Font, enmHorizontalAlignment.Center, enmVerticalAlignment.Top)
                    Next
                Next
            End With

        End If

        Dim obn As Integer = attrData.LayerData(Layernum).atrObject.ObjectNum
        Dim XY(obn - 1) As Point
        For i As Integer = 0 To obn - 1
            Dim CP As PointF = attrData.LayerData(Layernum).atrObject.atrObjectData(i).Label
            XY(i) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(CP)
        Next

        Dim Data_n As Integer = attLbl.CountOfDataItem
        Dim BoxWidth As Integer = attrData.Get_Length_On_Screen(attLbl.Width)


        'ラベルを表示
        prog.Maximum = obn
        Dim ProgInterval As Integer = obn \ 10
        If ProgInterval < 5 Then
            ProgInterval = 5
        End If
        For i As Integer = 0 To obn - 1
            If i Mod ProgInterval = 0 Then
                prog.Value = i
            End If
            If attrData.Check_Condition(Layernum, i) = True Then
                Dim D_TxHeight As Integer
                Dim D_Word_Cut As New List(Of String)
                If Data_n > 0 Then

                    For j As Integer = 0 To Data_n - 1
                        Dim wo2 As String = ""
                        Dim DataNum As Integer = attLbl.DataItem(j)
                        If attLbl.DataName_Print_Flag = True Then
                            wo2 = attrData.Get_DataTitle(Layernum, DataNum, False) & "："
                        End If
                        If attrData.Check_Missing_Value(Layernum, DataNum, i) = True Then
                            If attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True Then
                                wo2 = wo2 & attrData.TotalData.ViewStyle.Missing_Data.Label
                            Else
                                wo2 = ""
                            End If
                        Else
                            Select Case attrData.Get_DataType(Layernum, DataNum)
                                Case enmAttDataType.Normal
                                    Dim V As Double = Val(attrData.Get_Data_Value(Layernum, DataNum, i, ""))
                                    wo2 += clsGeneric.Figure_Using(V, attrData.TotalData.ViewStyle.MapLegend.Base.Comma_f)
                                    If attLbl.DataValue_Unit_Flag = True Then
                                        wo2 += attrData.Get_DataUnit(Layernum, DataNum)
                                    End If
                                Case enmAttDataType.Category, enmAttDataType.Strings
                                    wo2 += attrData.Get_Data_Value(Layernum, DataNum, i, "")
                            End Select
                        End If
                        Dim d_an2 As List(Of String) = clsDraw.TextCut_for_print(g, wo2,
                                                attLbl.DataValue_Font, attLbl.DataValue_TurnFlag,
                                                BoxWidth, 0, D_TxHeight, attrData.TotalData.ViewStyle.ScrData)
                        D_Word_Cut.AddRange(d_an2)
                    Next
                End If


                If D_Word_Cut.Count > 0 Or attLbl.ObjectName_Print_Flag = True Then
                    Dim O_Word_Cut As New List(Of String)
                    Dim O_TxHeight As Integer
                    If attLbl.ObjectName_Print_Flag = True Then
                        O_Word_Cut = clsDraw.TextCut_for_print(g, attrData.Get_KenObjName(Layernum, i),
                                            attLbl.ObjectName_Font, attLbl.ObjectName_Turn_Flag,
                                            BoxWidth, 0, O_TxHeight, attrData.TotalData.ViewStyle.ScrData)
                    End If

                    attrData.TempData.ObjectPrintedCheckFlag(Layernum)(i) = True

                    Dim TH As Integer = D_TxHeight * D_Word_Cut.Count + O_TxHeight * O_Word_Cut.Count
                    Dim AP As Point
                    Dim BP As Point
                    AP.X = XY(i).X - BoxWidth / 2
                    BP.X = AP.X + BoxWidth
                    Dim scx As Integer = XY(i).X

                    If attLbl.Location_Mark_Flag = True Then
                        AP.Y = XY(i).Y
                    Else
                        AP.Y = XY(i).Y - TH / 2
                    End If

                    If attrData.Check_Screen_In(New Rectangle(AP, New Size(BoxWidth * 2, TH * 2))) = True Then
                        Dim y2 As Integer = 0
                        If attLbl.Location_Mark_Flag = True Then
                            Label_MarkPrint(g, attrData, XY(i), mark_r, LabelMark) '表示位置の記号を表示
                            y2 += mark_r * 4
                        End If

                        With attLbl
                            If .ObjectName_Print_Flag = True Then
                                Dim Rect As Rectangle = Rectangle.FromLTRB(AP.X - 1, AP.Y + y2 - 1, BP.X, AP.Y + y2 + O_TxHeight * O_Word_Cut.Count)
                                attrData.Draw_Tile_Box(g, Rect, 0, .BorderLine, .BorderObjectTile)
                                For j As Integer = 0 To O_Word_Cut.Count - 1
                                    attrData.Draw_Print(g, O_Word_Cut(j), New Point(scx, AP.Y + y2), .ObjectName_Font, enmHorizontalAlignment.Center, enmVerticalAlignment.Top)
                                    y2 += O_TxHeight
                                Next
                                y2 += 1
                            End If

                            If .DataValue_Print_Flag = True Then
                                Dim Rect As Rectangle = Rectangle.FromLTRB(AP.X - 1, AP.Y + y2 - 1, BP.X, AP.Y + y2 + D_TxHeight * D_Word_Cut.Count)
                                attrData.Draw_Tile_Box(g, Rect, 0, .BorderLine, .BorderDataTile)
                                For j As Integer = 0 To D_Word_Cut.Count - 1
                                    attrData.Draw_Print(g, D_Word_Cut(j), New Point(scx, AP.Y + y2), .DataValue_Font, enmHorizontalAlignment.Center, enmVerticalAlignment.Top)
                                    y2 += D_TxHeight
                                Next
                            End If
                        End With
                    End If
                End If
            End If
        Next

        If Clip_F = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion2
            Make_ClippingRegion2.Dispose()
        End If
    End Sub
    Private Shared Sub Label_MarkPrint(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Pos As Point, ByVal r As Integer, ByRef MK As Mark_Property)
        'ラベルモードの記号を表示

        If attrData.Check_Screen_In(Pos, r) = True Then
            attrData.Draw_Mark(g, Pos, r, MK)
        End If

    End Sub
    ''' <summary>
    ''' 円グラフまたは帯グラフモード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataSet"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintGraph_Pie_StackdBarMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                        ByVal Layernum As Integer, ByVal DataSet As Integer)



        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(Layernum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Clip_F As Boolean
        Dim Original_ClippingRegion2 As Region
        Dim Make_ClippingRegion2 As Region
        If PolygonDummy_ClipSet_F = True Then
            Vector_Dummy_Boundary(g, attrData, Layernum, True, False)
            Clip_F = ClippingRegion_ObjectBoundary_set(g, attrData, Layernum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
        Else
            Clip_F = False
        End If

        Vector_Object_Boundary(g, attrData, Layernum)
        Vector_Dummy_Boundary(g, attrData, Layernum, (Clip_F = False), True)
        Vector_Connect_CenterP_To_SymbolPoint(g, attrData, Layernum)
        Dim obn As Integer = attrData.LayerData(Layernum).atrObject.ObjectNum

        With attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode.DataSet(DataSet)

            Dim en_sort As New clsSortingSearch(VariantType.Double)
            For i As Integer = 0 To obn - 1
                Dim env As Double = 0
                For j As Integer = 0 To .Count - 1
                    Dim Datan As Integer = .Data(j).DataNumner
                    If attrData.Check_Missing_Value(Layernum, Datan, i) = True Then
                        env = 0 '欠損値を含む場合は０にして表示しない
                        Exit For
                    Else
                        env += Val(attrData.Get_Data_Value(Layernum, Datan, i, ""))
                    End If
                Next
                en_sort.Add(env)
            Next
            en_sort.AddEnd()

            Dim RMAXVAL As Double = .En_Obi.MaxValue
            prog.Maximum = obn
            Dim ProgInterval As Integer = obn \ 10
            If ProgInterval < 5 Then
                ProgInterval = 5
            End If
            For i As Integer = obn - 1 To 0 Step -1
                If (obn - i) Mod ProgInterval = 0 Then
                    prog.Value = obn - i
                End If
                Dim SortObjPos As Integer = en_sort.DataPosition(i)
                Dim SortSumDataValue As Double = en_sort.DataPositionValue_Double(i)
                If SortSumDataValue <> 0 And attrData.Check_Condition(Layernum, SortObjPos) = True Then

                    Dim CP As PointF = attrData.LayerData(Layernum).atrObject.atrObjectData(SortObjPos).Symbol
                    Dim OP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(CP)

                    attrData.TempData.ObjectPrintedCheckFlag(Layernum)(SortObjPos) = True
                    Select Case .GraphMode
                        Case enmGraphMode.PieGraph  '円グラフ
                            Dim r As Integer
                            With .En_Obi
                                If .EnSizeMode = 0 Then
                                    r = attrData.Radius(.EnSize, RMAXVAL, RMAXVAL)
                                Else
                                    r = attrData.Radius(.EnSize, SortSumDataValue, RMAXVAL)
                                End If
                            End With
                            If r <> 0 Then

                                If attrData.Check_Screen_In(OP, r) = True Then
                                    Dim acum As Double = 0
                                    For j As Integer = 0 To .Count - 1
                                        Dim Datan As Integer = .Data(j).DataNumner
                                        If attrData.Check_Missing_Value(Layernum, Datan, SortObjPos) = False Then
                                            Dim H As Double = Val(attrData.Get_Data_Value(Layernum, Datan, SortObjPos, "")) / SortSumDataValue
                                            If Math.Abs(H - 1) <= 0.00001 Then
                                                Dim Circle_Mark As Mark_Property
                                                Circle_Mark.PrintMark = enmMarkPrintType.Mark
                                                Circle_Mark.WordFont.Back.Tile = clsBase.BlancTile
                                                Circle_Mark.WordFont.Back.Line = clsBase.BlancLine
                                                Circle_Mark.WordFont.Back.Round = 0
                                                Circle_Mark.Line = .En_Obi.BoaderLine
                                                Circle_Mark.Tile = .Data(j).Tile
                                                attrData.Draw_Mark(g, OP, r, Circle_Mark)
                                            Else
                                                If H <> 0 Then
                                                    Dim start_p As Double
                                                    Dim end_p As Double
                                                    start_p = acum
                                                    end_p = start_p + 2 * Math.PI * H
                                                    attrData.Draw_Fan(g, OP, r, start_p, end_p, .En_Obi.BoaderLine, .Data(j).Tile)
                                                    acum = end_p
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            End If
                        Case enmGraphMode.StackedBarGraph  '帯グラフ
                            Dim r As Integer
                            Dim r2 As Single
                            Dim xw As Integer
                            Dim yw As Integer
                            With .En_Obi
                                If .EnSizeMode = 0 Then
                                    r = attrData.Get_Length_On_Screen(.EnSize)
                                Else
                                    r = attrData.Radius(.EnSize, SortSumDataValue, RMAXVAL) * 2
                                End If
                                r2 = r * .AspectRatio
                                If .StackedBarDirection = enmStackedBarChart_Direction.Vertical Then
                                    xw = r2 / 2
                                    yw = r
                                Else
                                    xw = r / 2
                                    yw = r2 / 2
                                End If
                            End With
                            Dim C_Rect As Rectangle = New Rectangle(New Point(OP.X - xw, OP.Y - yw), New Size(xw * 2, yw * 2))
                            If attrData.Check_Screen_In(C_Rect) = True Then
                                Dim E As Double = 0
                                For j As Integer = 0 To .Count - 1
                                    Dim Datan As Integer = .Data(j).DataNumner
                                    If attrData.Check_Missing_Value(Layernum, Datan, SortObjPos) = False Then
                                        Dim H As Double = attrData.Get_Data_Value(Layernum, Datan, SortObjPos, "") / SortSumDataValue
                                        Dim Rect As Rectangle
                                        Select Case .En_Obi.StackedBarDirection
                                            Case enmStackedBarChart_Direction.Vertical
                                                Rect = Rectangle.FromLTRB(OP.X - r2 / 2, OP.Y - r + E * r, OP.X + r2 / 2, OP.Y - r + E * r + r * H)
                                            Case enmStackedBarChart_Direction.Horizontal
                                                Rect = Rectangle.FromLTRB(OP.X - r / 2 + E * r, OP.Y - r2 / 2, OP.X - r / 2 + E * r + r * H, OP.Y + r2 / 2)
                                        End Select
                                        attrData.Draw_Tile_Box(g, Rect, 0, .En_Obi.BoaderLine, .Data(j).Tile)
                                        E += H
                                    End If
                                Next
                            End If
                    End Select
                End If
            Next
        End With

        If Clip_F = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion2
            Make_ClippingRegion2.Dispose()
        End If

    End Sub
    ''' <summary>
    ''' 線グラフまたは折れ線グラフ
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataSet"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintGraph_Line_BarMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                             ByVal Layernum As Integer, ByVal DataSet As Integer)



        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(Layernum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Clip_F As Boolean
        Dim Original_ClippingRegion2 As Region
        Dim Make_ClippingRegion2 As Region
        If PolygonDummy_ClipSet_F = True Then
            Vector_Dummy_Boundary(g, attrData, Layernum, True, False)
            Clip_F = ClippingRegion_ObjectBoundary_set(g, attrData, Layernum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
        Else
            Clip_F = False
        End If

        Vector_Object_Boundary(g, attrData, Layernum)
        Vector_Dummy_Boundary(g, attrData, Layernum, (Clip_F = False), True)
        Dim obn As Integer = attrData.LayerData(Layernum).atrObject.ObjectNum

        With attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode.DataSet(DataSet)
            Dim OverLay_Refference_Multi As clsAttrData.strGraph_Data
            Dim OverLay_With_Bou As Boolean = False
            If attrData.TempData.OverLay_Temp.OverLay_Printing_Flag = True And .GraphMode = enmGraphMode.LineGraph Then
                For i As Integer = 0 To attrData.TempData.OverLay_Temp.Printing_Number - 1
                    With attrData.TotalData.TotalMode.OverLay.DataSet(attrData.TotalData.TotalMode.OverLay.SelectedIndex).DataItem(i)
                        If .Layer = Layernum And .Print_Mode_Layer = enmLayerMode_Number.GraphMode Then
                            OverLay_Refference_Multi = attrData.LayerData(.Layer).LayerModeViewSettings.GraphMode.DataSet(.DataNumber)
                            With OverLay_Refference_Multi
                                If .GraphMode = enmGraphMode.BarGraph Then
                                    OverLay_With_Bou = True
                                End If
                            End With
                        End If
                    End With
                Next
            End If

            Dim a As Integer
            Dim YMax As Double
            Dim Ymin As Double
            Dim ST As Double
            Dim ww As Integer
            Dim wh As Single
            With .Oresen_Bou
                YMax = .YMax
                Ymin = .Ymin
                ST = .Ystep
            End With
            If OverLay_With_Bou = False Then
                Vector_Connect_CenterP_To_SymbolPoint(g, attrData, Layernum)
                With .Oresen_Bou
                    ww = attrData.Get_Length_On_Screen(.Size)
                    wh = ww / .AspectRatio
                End With
                If .GraphMode = enmGraphMode.LineGraph Then
                    a = 1
                Else
                    a = 2
                End If
            Else

                With OverLay_Refference_Multi.Oresen_Bou
                    ww = attrData.Get_Length_On_Screen(.Size)
                    wh = ww / .AspectRatio
                    a = 1
                End With
            End If


            Dim stx As Single = ww / (.Count + a)
            prog.Maximum = obn
            Dim ProgInterval As Integer = obn \ 10
            If ProgInterval < 5 Then
                ProgInterval = 5
            End If
            For i As Integer = 0 To obn - 1
                If i Mod ProgInterval = 0 Then
                    prog.Value = i
                End If
                If attrData.Check_Condition(Layernum, i) = True Then
                    Dim CP As PointF = attrData.LayerData(Layernum).atrObject.atrObjectData(i).Symbol
                    Dim OP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(CP)
                    attrData.TempData.ObjectPrintedCheckFlag(Layernum)(i) = True
                    If .Oresen_Bou.BorderLine.Check_Line_PrintPattern = False And .Oresen_Bou.BackgroundTile.TileCode = enmTilePattern.Blank Then
                        OP.Offset(-ww / 2, -wh)
                    Else
                        OP.Offset(-ww / 2, -wh / 2)
                    End If
                    Dim Rect As New Rectangle(OP, New Size(ww, wh))
                    If attrData.Check_Screen_In(Rect) = True Then
                        If OverLay_With_Bou = False Then
                            With .Oresen_Bou
                                attrData.Draw_Tile_Box(g, Rect, 0, .BorderLine, .BackgroundTile)

                                For wakuj As Double = Ymin To YMax Step ST
                                    If wakuj <> Ymin And wakuj <> YMax Then
                                        Dim H As Single = 1 - (wakuj - Ymin) / (YMax - Ymin)
                                        Dim yy As Integer = OP.Y + wh * H
                                        attrData.Draw_Line(g, .BorderLine, New Point(OP.X, yy), New Point(OP.X + ww / 15, yy))
                                        attrData.Draw_Line(g, .BorderLine, New Point(OP.X + ww, yy), New Point(OP.X + ww - ww / 15, yy))
                                    End If
                                Next
                                Dim Zero_Line As Line_Property
                                Zero_Line = clsBase.Line
                                Zero_Line.BasicLine.SolidLine.Color = .BorderLine.BasicLine.SolidLine.Color
                                With Zero_Line.BasicLine
                                    .pattern = enmLinePattern.BROKEN
                                    Dim LP0 As OptionalLine_Data_info = .Get_CenterLineParts(0)
                                    LP0.Use_F = True
                                    .Set_CenterLineParts(0, LP0)
                                    Dim LP1 As OptionalLine_Data_info = .Get_CenterLineParts(1)
                                    LP1.Use_F = True
                                    LP1.Print_f = False
                                    .Set_CenterLineParts(1, LP1)
                                End With
                                If Ymin < 0 And YMax > 0 Then
                                    Dim H As Double = 1 - (-Ymin) / (YMax - Ymin)
                                    Dim yy As Integer = OP.Y + wh * H
                                    attrData.Draw_Line(g, Zero_Line, New Point(OP.X, yy), New Point(OP.X + ww, yy))
                                End If
                            End With
                        End If

                        Dim OriginClip As Region = g.Clip
                        Dim RectC As Rectangle = Rect
                        RectC.Inflate(1, 1)
                        g.SetClip(RectC, Drawing2D.CombineMode.Intersect)
                        Select Case .GraphMode
                            Case enmGraphMode.LineGraph '折れ線グラフ
                                Dim flx1 As Single
                                Dim fly1 As Integer
                                Dim fsx As Single = OP.X + stx
                                Dim ff As Boolean = True
                                For j As Integer = 0 To .Count - 1
                                    Dim Datan As Integer = .Data(j).DataNumner
                                    If attrData.Check_Missing_Value(Layernum, Datan, i) = False Then
                                        Dim H As Single = 1 - (Val(attrData.Get_Data_Value(Layernum, Datan, i, "")) - Ymin) / (YMax - Ymin)
                                        Dim yy As Integer = OP.Y + wh * H
                                        If ff = True Then
                                            flx1 = fsx
                                            fly1 = yy
                                            ff = False
                                        Else
                                            attrData.Draw_Line(g, .Oresen_Bou.Line, New Point(flx1, fly1), New Point(fsx, yy))
                                            flx1 = fsx
                                            fly1 = yy
                                        End If
                                        fsx += stx
                                    End If
                                Next
                            Case enmGraphMode.BarGraph '棒グラフ
                                Dim fsx As Single = OP.X + stx
                                For j As Integer = 0 To .Count - 1
                                    Dim Datan As Integer = .Data(j).DataNumner
                                    If attrData.Check_Missing_Value(Layernum, Datan, i) = False Then
                                        Dim H As Single = 1 - (Val(attrData.Get_Data_Value(Layernum, Datan, i, "")) - Ymin) / (YMax - Ymin)
                                        Dim yy As Integer = OP.Y + wh * H
                                        Dim yy2 As Single = OP.Y + (wh * (1 - (-Ymin) / (YMax - Ymin)))
                                        Dim barRect As Rectangle = Rectangle.FromLTRB(fsx, yy, fsx + stx, yy2)
                                        attrData.Draw_Tile_Box(g, barRect, 0, .Oresen_Bou.Line, .Data(j).Tile)
                                    End If
                                    fsx += stx
                                Next
                        End Select
                        g.Clip = OriginClip
                    End If
                End If
            Next
        End With
        If Clip_F = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion2
            Make_ClippingRegion2.Dispose()
        End If
    End Sub
    ''' <summary>
    ''' 等値線モード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintContourMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                       ByVal LayerNum As Integer, ByVal DataNum As Integer)



        If attrData.TempData.ContourMode_Temp.ContourDataResetF = True Then
            '等値線用メッシュデータを作成する
            ContourMeshIndexSet(attrData, prog, LayerNum, DataNum)
        End If
        Dim Missing_DataArray() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, DataNum)
        For i As Integer = 0 To attrData.LayerData(LayerNum).atrObject.ObjectNum - 1
            If Missing_DataArray(i) = False Then
                attrData.TempData.ObjectPrintedCheckFlag(LayerNum)(i) = True
            End If
        Next

        Dim C_md As clsAttrData.strContour_Data = attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD

        '等値線間隔と値を取得
        Dim C_Line_Pat() As Line_Property
        Dim Contour_High_M() As Double
        Dim hn As Integer = GetContourIntervalValue(attrData, LayerNum, DataNum, Contour_High_M, C_Line_Pat)

        'メッシュから等高線を抜き出す
        Dim Pre_CStac() As clsMeshContour.ContourLineStacInfo
        Dim Pre_CPoint() As PointF

        Dim ln As Integer = attrData.TempData.ContourMode_Temp.ContourMesh.Execute_Mesh(hn, Contour_High_M, Pre_CStac, Pre_CPoint)

        If ln = 0 Then
            MsgBox("該当する等値線が取得できませんでした。" & vbCrLf & "下限値・上限値を変更してください。", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(LayerNum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Make_ClippingRegion2 As Region
        Dim Original_ClippingRegion2 As Region
        Dim Clip_F2 As Boolean = False
        If PolygonDummy_ClipSet_F = True Then
            If C_md.Interval_Mode = 0 Or C_md.Interval_Mode = 1 Then
                Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
            End If
            Clip_F2 = ClippingRegion_ObjectBoundary_set(g, attrData, LayerNum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
            If C_md.Interval_Mode = 0 Or C_md.Interval_Mode = 1 Then
                Vector_Object_Boundary(g, attrData, LayerNum)
                Vector_Dummy_Boundary(g, attrData, LayerNum, (Clip_F2 = False), True)
            End If
        Else
            If C_md.Interval_Mode = 0 Or C_md.Interval_Mode = 1 Then
                Vector_Object_Boundary(g, attrData, LayerNum)
                Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
            End If
        End If

        Dim ST As Single
        If C_md.Detailed <= 2 Then
            ST = 0.4
        Else
            ST = 0.2
        End If

        Dim Make_ClippingRegion As Region
        Dim Original_ClippingRegion As Region
        Dim Clip_F As Boolean = False
        If C_md.Draw_in_Polygon_F = True Then
            'ポリゴン内部のみ描画
            Clip_F = ClippingRegion_ObjectBoundary_set(g, attrData, LayerNum, True, (PolygonDummy_ClipSet_F = False), Make_ClippingRegion, Original_ClippingRegion)
        End If


        If C_md.Interval_Mode = clsAttrData.enmContourIntervalMode.ClassPaint Or C_md.Interval_Mode = clsAttrData.enmContourIntervalMode.ClassHatch Then
            'ペイントモードで塗りつぶす
            Dim Frame_AllPoint() As PointF
            Dim FrameStac(3, 1) As Integer
            Dim Frame_AllLineStac() As Integer
            Dim FrameAllLineN As Integer = 0
            For i As Integer = 0 To 3
                Dim Frame_LineStac() As Integer
                Dim Frame_Point() As PointF
                Dim FrameLineN As Integer = attrData.TempData.ContourMode_Temp.ContourMesh.Execute_FrameGet(i, hn, Contour_High_M, Frame_LineStac, Frame_Point)
                FrameStac(i, 0) = FrameAllLineN
                FrameStac(i, 1) = FrameLineN
                Dim k As Integer = FrameAllLineN + FrameLineN
                ReDim Preserve Frame_AllPoint(k), Frame_AllLineStac(k)
                For j As Integer = 0 To FrameLineN - 1
                    Frame_AllPoint(j + FrameAllLineN) = Frame_Point(j)
                    Frame_AllLineStac(j + FrameAllLineN) = Frame_LineStac(j)
                Next
                FrameAllLineN += FrameLineN
            Next


            Dim HnPolygon(hn) As VecContourStac_Info
            For i As Integer = 0 To hn
                ReDim HnPolygon(i).FStac(0)
                ReDim HnPolygon(i).cStac(0)
            Next
            For i As Integer = 0 To ln - 1
                Dim n As Integer = Pre_CStac(i).Number
                For j As Integer = 0 To 1
                    With HnPolygon(n + j)
                        If UBound(.cStac) <= .CNum Then
                            ReDim Preserve .cStac(.CNum + 10)
                        End If
                        .cStac(.CNum) = i
                        .CNum += 1
                    End With
                Next
            Next
            For i As Integer = 0 To 3
                For j As Integer = 0 To FrameStac(i, 1) - 2
                    Dim n As Integer = Frame_AllLineStac(FrameStac(i, 0) + j)
                    With HnPolygon(n + 1)
                        If UBound(.FStac) <= .fnum Then
                            ReDim Preserve .FStac(.fnum + 10)
                        End If
                        .FStac(.fnum) = FrameStac(i, 0) + j
                        .fnum += 1
                    End With
                Next
            Next
            prog.Maximum = hn + 1
            For i As Integer = 0 To hn
                prog.Value = i + 1
                If HnPolygon(i).fnum > 0 Or HnPolygon(i).CNum > 0 Then
                    ContourPolyBoundary(g, attrData, LayerNum, DataNum, i, hn, C_md.Interval_Mode,
                                        HnPolygon(i), Pre_CPoint, Pre_CStac, Frame_AllPoint, C_md.Spline_flag, ST)
                End If
            Next
        End If

        With attrData.TempData.ContourMode_Temp
            ReDim Preserve .Contour_Object(.Contour_All_Number + ln - 1)
            ReDim Preserve .Contour_Point(.Contour_All_Point + UBound(Pre_CPoint))
        End With



        prog.Maximum = ln
        For i As Integer = 0 To ln - 1
            prog.Value = i
            Dim Con_Obj_Code As Integer = i + attrData.TempData.ContourMode_Temp.Contour_All_Number
            Dim stc As Integer = Pre_CStac(i).PointStac
            With attrData.TempData.ContourMode_Temp.Contour_Object(Con_Obj_Code)
                .Layernum = LayerNum
                .DataNum = DataNum
                .PointStac = attrData.TempData.ContourMode_Temp.Contour_All_Point
                .NumOfPoint = Pre_CStac(i).PointNum
                .Value = Contour_High_M(Pre_CStac(i).Number)
                .Circumscribed_Rectangle = New RectangleF(Pre_CPoint(stc), New Size(0, 0))
            End With
            With attrData.TempData.ContourMode_Temp
                For j As Integer = stc To stc + Pre_CStac(i).PointNum - 1
                    .Contour_Point(.Contour_All_Point) = Pre_CPoint(j)
                    .Contour_All_Point += 1
                    .Contour_Object(Con_Obj_Code).Circumscribed_Rectangle = spatial.Get_Circumscribed_Rectangle(Pre_CPoint(j), .Contour_Object(Con_Obj_Code).Circumscribed_Rectangle)
                Next
                .Contour_Object(Con_Obj_Code).Flag = True
            End With
            Dim pxy() As Point
            If C_md.Spline_flag = True Then
                pxy = clsSpline.Spline_Get(stc, Pre_CStac(i).PointNum, Pre_CPoint, ST, attrData.TotalData.ViewStyle.ScrData)
            Else
                ReDim pxy(Pre_CStac(i).PointNum - 1)
                For j As Integer = 0 To Pre_CStac(i).PointNum - 1
                    pxy(j) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(Pre_CPoint(stc + j))
                Next
            End If
            attrData.Draw_Line(g, C_Line_Pat(Pre_CStac(i).Number), Pre_CStac(i).PointNum, pxy)
        Next
        ObjectValue_And_Name_Print_byLayer(g, attrData, LayerNum, DataNum)

        If C_md.Draw_in_Polygon_F = True And Clip_F = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion
            Make_ClippingRegion.Dispose()
        End If

        If C_md.Interval_Mode = 2 Or C_md.Interval_Mode = 3 Then
            Vector_Object_Boundary(g, attrData, LayerNum)
            Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
        End If

        If Clip_F2 = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion2
            Make_ClippingRegion2.Dispose()
        End If

        attrData.TempData.ContourMode_Temp.Contour_All_Number += ln
    End Sub
    ''' <summary>
    ''' ポリゴンのクリッピングリージョンを作成
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="RealObjClip_f">オブジェクトの領域のクリップ</param>
    ''' <param name="DummyClip_F">ダミーの領域のクリップ</param>
    ''' <param name="makeRegion">作成するクリッピングリージョン</param>
    ''' <param name="OriginalClipRegion">現在のクリッピングリージョン</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function ClippingRegion_ObjectBoundary_set(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer,
                                                              ByVal RealObjClip_f As Boolean, ByVal DummyClip_F As Boolean,
                                                              ByRef makeRegion As Region, ByRef OriginalClipRegion As Region) As Boolean
        Dim Layers As New List(Of Integer)
        Layers.Add(Layernum)
        Return ClippingRegion_ObjectBoundary_set(g, attrData, Layers, RealObjClip_f, DummyClip_F, makeRegion, OriginalClipRegion)

    End Function
    ''' <summary>
    ''' ポリゴンのクリッピングリージョンを作成
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layers">調べるレイヤのリスト</param>
    ''' <param name="RealObjClip_f">オブジェクトの領域のクリップ</param>
    ''' <param name="DummyClip_F">ダミーの領域のクリップ</param>
    ''' <param name="makeRegion">作成するクリッピングリージョン</param>
    ''' <param name="OriginalClipRegion">現在のクリッピングリージョン</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function ClippingRegion_ObjectBoundary_set(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layers As List(Of Integer),
                                                              ByVal RealObjClip_f As Boolean, ByVal DummyClip_F As Boolean,
                                                              ByRef makeRegion As Region, ByRef OriginalClipRegion As Region) As Boolean
        OriginalClipRegion = g.Clip
        Dim Pregion As New Region
        Dim f As Boolean = False
        Dim allPoint As Integer = 0
        Dim AllPon As Integer
        Dim Allpxy() As Point
        Dim AllnPolyP() As Integer
        For i As Integer = 0 To Layers.Count - 1
            Dim pxy() As Point
            Dim nPolyP() As Integer
            Dim Pon As Integer = ContourPolygonRegion(attrData, Layers(i), RealObjClip_f, DummyClip_F, pxy, nPolyP)
            If Pon > 0 Then
                ReDim Preserve AllnPolyP(AllPon + Pon - 1)
                Dim plusP As Integer = 0
                For j As Integer = 0 To Pon - 1
                    AllnPolyP(AllPon + j) = nPolyP(j)
                    plusP += nPolyP(j)
                Next
                ReDim Preserve Allpxy(allPoint + plusP - 1)
                For j As Integer = 0 To plusP - 1
                    Allpxy(allPoint + j) = pxy(j)
                Next
                AllPon += Pon
                allPoint += plusP
                f = True
            End If
        Next
        If f = True Then
            makeRegion = clsDraw.Get_Region_From_PointStac(AllPon, Allpxy, AllnPolyP)
            g.SetClip(makeRegion, System.Drawing.Drawing2D.CombineMode.Intersect)
        End If
        Return f
    End Function

    ''' <summary>
    ''' 等値線モード他の背後のポリゴンのクリッピングリージョン作成、ポリゴン数を返す
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="RealObjClip_f"></param>
    ''' <param name="DummyClip_F"></param>
    ''' <param name="pxy"></param>
    ''' <param name="nPolyP"></param>
    ''' <remarks></remarks>
    Private Shared Function ContourPolygonRegion(ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal RealObjClip_f As Boolean,
                                            ByVal DummyClip_F As Boolean, ByRef pxy() As Point, ByRef nPolyP() As Integer) As Integer
        '
        Dim Dummy_F As Boolean

        Dim MultiObj() As Integer

        Dim LT As strYMD = attrData.LayerData(Layernum).Time

        Dim MbjN As Integer = 0
        If attrData.LayerData(Layernum).Shape = enmShape.PolygonShape And RealObjClip_f = True And attrData.LayerData(Layernum).Type = clsAttrData.enmLayerType.Normal Then
            Dim ObjN As Integer = attrData.LayerData(Layernum).atrObject.ObjectNum
            ReDim MultiObj(ObjN)
            For i As Integer = 0 To ObjN - 1
                If attrData.Check_screen_Kencode_In(Layernum, i) = True Then
                    MultiObj(MbjN) = i
                    MbjN += 1
                End If
            Next
            Dummy_F = False
        ElseIf DummyClip_F = True Then
            Dim dummyN As Integer = attrData.LayerData(Layernum).Dummy.Count
            ReDim MultiObj(dummyN)
            For i As Integer = 0 To dummyN - 1
                Dim c As Integer = attrData.LayerData(Layernum).Dummy.DummyObj(i).code
                If attrData.LayerData(Layernum).MapFileData.MPObj(c).Shape = enmShape.PolygonShape And
                            attrData.Check_Screen_Objcode_In(Layernum, c) = True Then
                    MultiObj(MbjN) = c
                    MbjN += 1
                End If
            Next
            Dim dummyGroupN As Integer = attrData.LayerData(Layernum).DummyGroup.Count
            If dummyGroupN > 0 Then
                With attrData.LayerData(Layernum).MapFileData
                    Dim DummyObjG(.Map.OBKNum - 1) As Boolean
                    Dim n As Integer
                    For i As Integer = 0 To dummyGroupN - 1
                        Dim objg As Integer = attrData.LayerData(Layernum).DummyGroup.DummyObjG(i)
                        If .ObjectKind(objg).Shape = enmShape.PolygonShape Then
                            DummyObjG(objg) = True
                            n += 1
                        End If
                    Next
                    If n > 0 Then
                        For j As Integer = 0 To .Map.Kend - 1
                            If DummyObjG(.MPObj(j).Kind) = True And .MPObj(j).Shape = enmShape.PolygonShape Then
                                If .CheckEnableObject(.MPObj(j), LT) = True Then
                                    If UBound(MultiObj) < MbjN Then
                                        ReDim Preserve MultiObj(MbjN + 100)
                                    End If
                                    MultiObj(MbjN) = j
                                    MbjN += 1
                                End If
                            End If
                        Next
                    End If
                End With
            End If
            Dummy_F = True
        End If
        If MbjN > 0 Then
            Return Get_Multi_Object_Boundary(attrData, Layernum, MbjN, MultiObj, pxy, nPolyP, Dummy_F)
        Else
            Return 0
        End If

    End Function
    ''' <summary>
    ''' 等値線内部塗りつぶし
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <param name="Pcon"></param>
    ''' <param name="hn"></param>
    ''' <param name="Interval_Mode"></param>
    ''' <param name="HnPolygon"></param>
    ''' <param name="Pre_CPoint"></param>
    ''' <param name="Pre_CStac"></param>
    ''' <param name="Frame_AllPoint"></param>
    ''' <param name="Spline_flag"></param>
    ''' <param name="SplineT"></param>
    ''' <remarks></remarks>
    Private Shared Sub ContourPolyBoundary(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal DataNum As Integer,
                                           ByVal Pcon As Integer, ByVal hn As Integer, ByVal Interval_Mode As clsAttrData.enmContourIntervalMode, HnPolygon As VecContourStac_Info,
                                           ByRef Pre_CPoint() As PointF, ByRef Pre_CStac() As clsMeshContour.ContourLineStacInfo,
                                            ByRef Frame_AllPoint() As PointF, ByVal Spline_flag As Boolean, ByVal SplineT As Single)

        Dim spxy() As PointF
        Dim epxy() As PointF
        Dim NL As Integer
        With HnPolygon
            NL = .CNum + .fnum
            ReDim spxy(NL), epxy(NL)
            For j As Integer = 0 To .CNum - 1
                Dim s As Integer = Pre_CStac(.cStac(j)).PointStac
                Dim n As Integer = Pre_CStac(.cStac(j)).PointNum
                spxy(j) = Pre_CPoint(s)
                epxy(j) = Pre_CPoint(s + n - 1)
            Next
            For j As Integer = 0 To .fnum - 1
                spxy(.CNum + j) = Frame_AllPoint(.FStac(j))
                epxy(.CNum + j) = Frame_AllPoint(.FStac(j) + 1)
            Next
        End With
        Dim Arrange_LineCode(,) As Integer
        Dim Fringe() As clsMapData.Fringe_Line_Info
        Dim Pon As Integer = spatial.BoundaryArrangeGeneral(NL, spxy, epxy, Arrange_LineCode, Fringe)
        If Pon = -1 Then
            Return
        End If
        Dim nPolyP(Pon - 1) As Integer
        Dim p As Integer = 0
        For i As Integer = 0 To UBound(Fringe)
            If Fringe(i).code < HnPolygon.CNum Then
                p += Pre_CStac(HnPolygon.cStac(Fringe(i).code)).PointNum
            Else
                p += 2
            End If
        Next
        Dim pxy(p - 1) As Point
        Dim np As Integer = 0
        Dim ponpon As Integer = 0
        For i As Integer = 0 To Pon - 1
            Dim np2 As Integer = 0
            For j As Integer = 0 To Arrange_LineCode(i, 1) - 1
                Dim revf As Boolean
                If Fringe(Arrange_LineCode(i, 0) + j).Direction = 1 Then
                    revf = False
                Else
                    revf = True
                End If
                Dim L As Integer = Fringe(Arrange_LineCode(i, 0) + j).code
                If L < HnPolygon.CNum Then
                    Dim n As Integer = Pre_CStac(HnPolygon.cStac(L)).PointNum
                    Dim s As Integer = Pre_CStac(HnPolygon.cStac(L)).PointStac
                    If Spline_flag = True Then
                        Dim pxytemp() As Point = clsSpline.Spline_Get(s, n, Pre_CPoint, SplineT, attrData.TotalData.ViewStyle.ScrData)
                        If UBound(pxy) <= np + n Then
                            ReDim Preserve pxy(np + n + 100)
                        End If
                        If revf = False Then
                            For k As Integer = 0 To n - 1
                                pxy(np + k) = pxytemp(k)
                            Next
                        Else
                            For k As Integer = 0 To n - 1
                                pxy(np + k) = pxytemp(n - 1 - k)
                            Next
                        End If
                    Else
                        If UBound(pxy) <= np + n Then
                            ReDim Preserve pxy(np + n + 100)
                        End If
                        If revf = False Then
                            For k As Integer = 0 To n - 1
                                pxy(np + k) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(Pre_CPoint(s + k))
                            Next
                        Else
                            For k As Integer = 0 To n - 1
                                pxy(np + k) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(Pre_CPoint(s + n - 1 - k))
                            Next
                        End If
                    End If
                    np += n
                    np2 += n
                Else
                    If UBound(pxy) <= np + 2 Then
                        ReDim Preserve pxy(np + 100)
                    End If
                    If revf = False Then
                        pxy(np) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(spxy(L))
                        pxy(np + 1) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(epxy(L))
                    Else
                        pxy(np) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(epxy(L))
                        pxy(np + 1) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(spxy(L))
                    End If
                    np += 2
                    np2 += 2
                End If
            Next
            nPolyP(ponpon) = np2
            ponpon += 1
        Next
        Select Case Interval_Mode
            Case clsAttrData.enmContourIntervalMode.ClassPaint
                Dim col As Color = attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.Class_Div(hn - Pcon).PaintColor.getColor
                clsDraw.DrawPolyPolygon(g, ponpon, pxy, nPolyP, col)
            Case clsAttrData.enmContourIntervalMode.ClassHatch
                Dim HatchRect As Rectangle = New Rectangle(pxy(0), New Size(0, 0))
                For i As Integer = 0 To np - 1
                    HatchRect = spatial.Get_Circumscribed_Rectangle(pxy(i), HatchRect)
                Next
                Dim Tile As Tile_Property = attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.Class_Div(hn - Pcon).TilePat
                attrData.Draw_Tile_Region(g, HatchRect, pxy, nPolyP, ponpon, Tile)
        End Select
    End Sub
    Private Shared Sub ContourMeshIndexSet(ByRef attrData As clsAttrData, ByRef prog As ToolStripProgressBar, ByVal Layernum As Integer, ByVal DataNum As Integer)
        '等値線メッシュデータの作成
        'F_Mesh/地図を区切り，その中に含まれるオブジェクトの代表点をカウント
        'F_Mesh(,,0)／含まれるオブジェクト数
        '含まれるオブジェクトの番号を示すスタックの開始位置
        'F_Mesh_In/F_Meshのメッシュ内に入るオブジェクトの番号を示すスタック


        Dim mw As Single, mh As Single
        With attrData.TotalData.ViewStyle.ScrData.MapRectangle
            mw = .Width
            mh = .Height
        End With
        Dim ObjN As Integer = attrData.LayerData(Layernum).atrObject.ObjectNum
        Dim StdWSize As Single = attrData.TotalData.ViewStyle.ScrData.STDWsize
        Dim md As Single = Math.Sqrt(15 * mw * mh / ObjN)
        md = Math.Min(md, StdWSize * 0.05)
        Dim F_Meshx As Integer = Int(mw / md)
        Dim F_Meshy As Integer = Int(mh / md)
        Dim F_Mesh(F_Meshx, F_Meshy, 1) As Integer

        For j As Integer = 0 To F_Meshx
            For k As Integer = 0 To F_Meshy
                F_Mesh(j, k, 1) = -1
            Next
        Next

        Dim nn As Integer = 0
        prog.Maximum = ObjN
        Dim Missing_DataArray() As Boolean = attrData.Get_Missing_Value_DataArray(Layernum, DataNum)
        Dim F_Mesh_In(ObjN - 1) As Integer

        For i As Integer = 0 To ObjN - 1
            If i Mod 100 = 0 Then
                prog.Value = i
            End If
            If Missing_DataArray(i) = False Then
                Dim cp As PointF = attrData.LayerData(Layernum).atrObject.atrObjectData(i).CenterPoint
                Dim X As Integer, Y As Integer
                X = Int((cp.X - attrData.TotalData.ViewStyle.ScrData.MapRectangle.Left) / md)
                Y = Int((cp.Y - attrData.TotalData.ViewStyle.ScrData.MapRectangle.Top) / md)
                F_Mesh(X, Y, 0) += 1
                For j As Integer = 0 To F_Meshx
                    For k As Integer = 0 To F_Meshy
                        If F_Mesh(j, k, 1) > F_Mesh(X, Y, 1) Then
                            F_Mesh(j, k, 1) += 1
                        End If
                    Next
                Next
                If F_Mesh(X, Y, 0) = 1 Then
                    F_Mesh(X, Y, 1) = 0
                End If
                For j As Integer = nn - 1 To F_Mesh(X, Y, 1) Step -1
                    F_Mesh_In(j + 1) = F_Mesh_In(j)
                Next
                F_Mesh_In(F_Mesh(X, Y, 1)) = i
                nn += 1
            End If
        Next

        'Mesh()／メッシュの数値を入れる．大きさは設定による
        Dim md2 As Single
        Select Case attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD.Detailed
            Case 0
                md2 = StdWSize * 0.005
            Case 1
                md2 = StdWSize * 0.01
            Case 2
                md2 = StdWSize * 0.017
            Case 3
                md2 = StdWSize * 0.025
            Case 4
                md2 = StdWSize * 0.035
        End Select
        Dim D_Meshx As Integer = Int(mw / md2)
        Dim D_Meshy As Integer = Int(mh / md2)
        With attrData.TempData.ContourMode_Temp
            .Contour_All_Number = 0
            .Contour_All_Point = 0
            .ContourMesh = New clsMeshContour
            .ContourMesh.SetMeshInfo(D_Meshx + 1, D_Meshy + 1, md2 * D_Meshx, md2 * D_Meshy,
                        attrData.TotalData.ViewStyle.ScrData.MapRectangle.Left, attrData.TotalData.ViewStyle.ScrData.MapRectangle.Top)

            .ContourDataResetF = False
        End With

        prog.Maximum = D_Meshx + 1
        Dim DataValue() As Double = attrData.Get_Data_Cell_Array_With_MissingValue(Layernum, DataNum)
        For i As Integer = 0 To D_Meshx
            If i Mod 10 = 0 Then
                prog.Value = i
            End If
            For j As Integer = 0 To D_Meshy
                Dim P As PointF = attrData.TotalData.ViewStyle.ScrData.MapRectangle.Location
                spatial.PointF_offset(P, i * md2, j * md2)
                Dim v As Double = ContourMesh_Value(attrData, Layernum, DataNum, DataValue, P, md, F_Mesh, F_Mesh_In)
                attrData.TempData.ContourMode_Temp.ContourMesh.SetMeshValue(i, j, v)
            Next
        Next

    End Sub
    ''' <summary>
    ''' 周囲の点から数値を推測する
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <param name="P"></param>
    ''' <param name="md"></param>
    ''' <param name="F_Mesh"></param>
    ''' <param name="F_Mesh_In"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function ContourMesh_Value(ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal DataNum As Integer,
                                              ByVal DataValue() As Double, ByVal P As PointF, ByVal md As Single,
                                              ByRef F_Mesh(,,) As Integer, ByRef F_Mesh_In() As Integer) As Double


        Dim xx As Integer = Int((P.X - attrData.TotalData.ViewStyle.ScrData.MapRectangle.Left) / md)
        Dim yy As Integer = Int((P.Y - attrData.TotalData.ViewStyle.ScrData.MapRectangle.Top) / md)
        Dim F_Mesh_W As Integer = UBound(F_Mesh, 1)
        Dim F_Mesh_H As Integer = UBound(F_Mesh, 2)

        Dim O_Code(20 - 1) As Integer
        Dim O_Distance(20 - 1) As Single
        Dim n As Integer = 0
        Dim c As Integer = 0
        Dim cend As Integer = 3

        'メッシュ点周辺のオブジェクトを検索する
        Dim AngleSort As New clsSortingSearch(VariantType.Single)
        Dim dir_num(2, 2) As Integer
        Dim dir_c(2, 2) As Boolean
        Do
            Dim enf As Boolean
            Do
                'kkは菱形に走査していくために使う
                Dim kk As Integer = 0
                For i As Integer = xx - c To xx + c
                    If 0 <= i And i <= F_Mesh_W Then
                        Dim qx As Integer = Math.Sign(i - xx) + 1
                        For i2 As Integer = 0 To 1
                            Dim j As Integer
                            Select Case i2
                                Case 0
                                    j = yy - kk
                                Case 1
                                    j = yy + kk
                            End Select
                            Dim qy As Integer = Math.Sign(j - yy) + 1
                            If 0 <= j And j <= F_Mesh_H Then
                                If dir_c(qx, qy) = True Or F_Mesh(i, j, 0) = 0 Then
                                Else
                                    dir_num(qx, qy) = dir_num(qx, qy) + F_Mesh(i, j, 0)
                                    For k As Integer = 0 To F_Mesh(i, j, 0) - 1
                                        Dim O_cd As Integer = F_Mesh_In(k + F_Mesh(i, j, 1))
                                        Dim P3 As PointF = attrData.LayerData(Layernum).atrObject.atrObjectData(O_cd).CenterPoint
                                        If P.Equals(P3) = True Then
                                            Return DataValue(O_cd)
                                        End If
                                        O_Distance(n) = Math.Sqrt((P3.X - P.X) ^ 2 + (P3.Y - P.Y) ^ 2)
                                        O_Code(n) = O_cd
                                        Dim si As Single = (P3.Y - P.Y) / O_Distance(n)
                                        Dim co As Single = (P3.X - P.X) / O_Distance(n)
                                        AngleSort.Add(clsGeneric.Angle(si, co))
                                        n += 1
                                        If UBound(O_Code) < n Then
                                            ReDim Preserve O_Code(n + 10), O_Distance(n + 10)
                                        End If
                                    Next
                                    If dir_num(qx, qy) >= 2 Then
                                        dir_c(qx, qy) = True
                                    End If
                                End If
                            End If
                            If kk = 0 Then Exit For
                        Next

                    End If
                    If i < xx Then
                        kk += 1
                    Else
                        kk -= 1
                    End If
                Next
                If xx - c < 0 Then
                    dir_c(0, 1) = True
                End If
                If xx + c > F_Mesh_W Then
                    dir_c(2, 1) = True
                End If

                If yy - c < 0 Then
                    dir_c(1, 0) = True
                End If
                If yy + c > F_Mesh_H Then
                    dir_c(1, 2) = True
                End If

                c += 1
                enf = True
                For i As Integer = 0 To 2
                    For j As Integer = 0 To 2
                        If i = 1 And j = 1 Then
                        Else
                            If dir_c(i, j) = False Then
                                enf = False
                                j = 2
                                i = 2
                            End If
                        End If
                    Next
                Next

            Loop While enf = False And c < cend
            cend += 2
        Loop While n = 0
        AngleSort.AddEnd()

        'メッシュに最も近いオブジェクトの距離を１とする

        Dim mind As Single = O_Distance(0)
        For i As Integer = 0 To n - 1
            mind = Math.Min(mind, O_Distance(i))
            If mind = 0 Then
                Return DataValue(O_Code(i))
            End If
        Next
        For i As Integer = 0 To n - 1
            O_Distance(i) = (O_Distance(i) / mind) '^ 2 ^2の数字を大きくすると一番近い位置の値が強調される
        Next


        '30度以内に近接し、ある程度離れている点は、近い方を選択する
        Dim alimit As Single = 25 * (3 - Math.Max(attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD.Detailed - 1, 0)) + 30


        Dim O_Distance_NoUseF(n - 1) As Boolean
        With AngleSort
            Dim nn As Integer = n
            Dim fa As Single = .DataPositionValue_Single(0)
            Dim fai As Integer = 0
            Dim ffa As Single = fa
            For i As Integer = 1 To n - 1
                Dim So_fai As Integer = .DataPosition(fai)
                Dim So_i As Integer = .DataPosition(i)
                If .DataPositionValue_Single(i) - fa < alimit And .DataPositionValue_Single(i) - ffa < alimit _
                     And Math.Abs(O_Distance(So_fai) - O_Distance(So_i)) > 0.1 Then
                    If O_Distance(So_fai) < O_Distance(So_i) Then
                        O_Distance_NoUseF(So_i) = True
                    Else
                        O_Distance_NoUseF(So_fai) = True
                        fai = i
                        fa = .DataPositionValue_Single(i)
                    End If
                    nn -= 1
                Else
                    fai = i
                    fa = .DataPositionValue_Single(i)
                    ffa = fa
                End If
            Next

            '最後と最初のオブジェクトの角度を比較する
            Dim OI As Integer
            Dim a As Single
            For i As Integer = 0 To n - 1
                If O_Distance_NoUseF(.DataPosition(i)) = False Then
                    a = .DataPositionValue_Single(i)
                    OI = i
                    Exit For
                End If
            Next
            If a - (fa - 360) < alimit And nn >= 2 And a - (ffa - 360) < alimit And _
                Math.Abs(O_Distance(.DataPosition(fai)) - O_Distance(.DataPosition(OI))) > 0.1 Then
                If O_Distance(.DataPosition(fai)) < O_Distance(.DataPosition(OI)) Then
                    O_Distance_NoUseF(.DataPosition(OI)) = True
                Else
                    O_Distance_NoUseF(.DataPosition(fai)) = True
                End If
            End If
        End With


        Dim SV As Double = 0
        Dim SU As Double = 0
        For i As Integer = 0 To n - 1
            If O_Distance_NoUseF(i) = False Then
                SV += DataValue(O_Code(i)) / O_Distance(i)
                SU += 1 / O_Distance(i)
            End If
        Next
        Return SV / SU

    End Function
    ''' <summary>
    ''' 等値線の間隔の値を取得
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <param name="Contour_High_M"></param>
    ''' <param name="C_Line_Pat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetContourIntervalValue(ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal DataNum As Integer,
                                                    ByRef Contour_High_M() As Double, ByRef C_Line_Pat() As Line_Property) As Integer

        Dim C_md As clsAttrData.strContour_Data = attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD
        Dim hn As Integer
        With C_md
            hn = 0
            Select Case .Interval_Mode
                Case clsAttrData.enmContourIntervalMode.RegularInterval
                    With .Regular
                        hn = (.top - .bottom) / .Interval + 1
                        ReDim Contour_High_M(hn - 1), C_Line_Pat(hn - 1)
                        Dim n As Integer = 0
                        Dim V As Double = .bottom
                        Do
                            Contour_High_M(n) = V
                            C_Line_Pat(n) = .Line_Pat
                            n += 1
                            V = .bottom + n * .Interval
                        Loop While V < .top
                        Dim n2 As Integer = 0
                        V = .SP_Bottom
                        Do While V < Math.Min(.SP_Top, .top)
                            V = .SP_Bottom + n2 * .SP_interval
                            For j As Integer = 0 To n - 1
                                If V = Contour_High_M(j) Then
                                    C_Line_Pat(j) = .SP_Line_Pat
                                    Exit For
                                End If
                            Next
                            n2 += 1
                        Loop

                        If .EX_Value_Flag = True Then
                            For j As Integer = 0 To n - 1
                                If Contour_High_M(j) = .EX_Value Then
                                    C_Line_Pat(j) = .EX_Line_Pat
                                End If
                            Next
                        End If
                    End With
                Case clsAttrData.enmContourIntervalMode.SeparateSettings
                    hn = .IrregularNum
                    ReDim Contour_High_M(hn - 1), C_Line_Pat(hn - 1)
                    For i As Integer = 0 To hn - 1
                        Contour_High_M(i) = .Irregular(i).Value
                        C_Line_Pat(i) = .Irregular(i).Line_Pat
                    Next
                Case clsAttrData.enmContourIntervalMode.ClassPaint, clsAttrData.enmContourIntervalMode.ClassHatch
                    hn = attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.Div_Num - 1
                    ReDim Contour_High_M(hn - 1)
                    ReDim C_Line_Pat(hn - 1)
                    For i As Integer = 0 To hn - 1
                        Contour_High_M(i) = attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.Class_Div(hn - 1 - i).Value
                        C_Line_Pat(i) = .Regular.Line_Pat
                    Next
            End Select
        End With
        Return hn
    End Function
    ''' <summary>
    ''' 文字モード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintStringMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                   ByVal LayerNum As Integer, ByVal DataNum As Integer)
        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(LayerNum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Clip_F As Boolean
        Dim Original_ClippingRegion2 As Region
        Dim Make_ClippingRegion2 As Region
        If PolygonDummy_ClipSet_F = True Then
            Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
            Clip_F = ClippingRegion_ObjectBoundary_set(g, attrData, LayerNum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
        Else
            Clip_F = False
        End If

        If attrData.LayerData(LayerNum).Shape = enmShape.PolygonShape Or attrData.LayerData(LayerNum).Shape = enmShape.LineShape Then
            Vector_Object_Boundary(g, attrData, LayerNum)
        End If
        Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
        Dim Missing_DataArray() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, DataNum)
        With attrData.LayerData(LayerNum)
            Dim InnerDT As clsAttrData.strInner_Data_Info = .atrData.Data(DataNum).SoloModeViewSettings.MarkCommon.Inner_Data
            Dim Category_Array_Inner() As Integer
            If InnerDT.Flag = True Then
                Category_Array_Inner = attrData.Get_Categoly(LayerNum, InnerDT.Data)
            End If

            Dim Font As Font_Property
            Dim xw As Integer
            Dim turnF As Boolean
            With .atrData.Data(DataNum).SoloModeViewSettings.StringMD
                Dim H As Integer = attrData.Get_Length_On_Screen(.Font.Body.Size)
                Font = .Font
                xw = attrData.Get_Length_On_Screen(.maxWidth)
                turnF = .WordTurnF
            End With
            prog.Maximum = .atrObject.ObjectNum - 1
            Dim ProgInterval As Integer = .atrObject.ObjectNum \ 10
            If ProgInterval < 5 Then
                ProgInterval = 5
            End If
            For i As Integer = 0 To .atrObject.ObjectNum - 1
                If i Mod ProgInterval = 0 Then
                    prog.Value = i
                End If
                If attrData.Check_Condition(LayerNum, i) = True And _
                       (Missing_DataArray(i) = False Or attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True) Then
                    Dim tx As String = attrData.Get_Data_Value(LayerNum, DataNum, i, attrData.TotalData.ViewStyle.Missing_Data.Label)
                    If tx <> "" Then
                        attrData.TempData.ObjectPrintedCheckFlag(LayerNum)(i) = True
                        Dim CP As PointF = attrData.LayerData(LayerNum).atrObject.atrObjectData(i).Label
                        Dim LP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(CP)

                        Dim atx As String = tx
                        Dim yw As Integer = 0
                        Dim RealW As Integer
                        Dim d_an2 As List(Of String) = clsDraw.TextCut_for_print(g, atx, Font, turnF, xw, RealW, yw, attrData.TotalData.ViewStyle.ScrData)
                        Dim outTx As String = d_an2(0)
                        For j As Integer = 1 To d_an2.Count - 1
                            outTx += vbCrLf + d_an2(j)
                        Next
                        yw *= d_an2.Count
                        Dim rect As Rectangle = New Rectangle(New Point(LP.X - RealW / 2, LP.Y - yw / 2), New Size(RealW, yw))
                        If InnerDT.Flag = True Then
                            Font.Body.Color = attrData.Get_InnerTile(InnerDT, LayerNum, Category_Array_Inner(i)).Line.BasicLine.SolidLine.Color
                        End If
                        attrData.Draw_Print(g, outTx, rect.Location, Font, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
                    End If

                End If
            Next
        End With

        If Clip_F = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion2
            Make_ClippingRegion2.Dispose()
        End If


    End Sub


    ''' <summary>
    ''' 棒の高さモード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintMarkBarMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                       ByVal LayerNum As Integer, ByVal DataNum As Integer)

        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(LayerNum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Clip_F As Boolean
        Dim Original_ClippingRegion2 As Region
        Dim Make_ClippingRegion2 As Region
        If PolygonDummy_ClipSet_F = True Then
            Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
            Clip_F = ClippingRegion_ObjectBoundary_set(g, attrData, LayerNum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
        Else
            Clip_F = False
        End If

        If attrData.LayerData(LayerNum).Shape = enmShape.PolygonShape Then
            Vector_Object_Boundary(g, attrData, LayerNum)
        End If
        Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
        Vector_Connect_CenterP_To_SymbolPoint(g, attrData, LayerNum)
        Dim InnerDT As clsAttrData.strInner_Data_Info = attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon.Inner_Data
        Dim Category_Array_Inner() As Integer
        If InnerDT.Flag = True Then
            Category_Array_Inner = attrData.Get_Categoly(LayerNum, InnerDT.Data)
        End If
        Dim MkCommon As clsAttrData.strMarkCommon_Data = attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon

        Dim Objn As Integer = attrData.LayerData(LayerNum).atrObject.ObjectNum

        '表示順序と表示の可否
        Dim D_Order() As Integer
        Dim ShowF() As Boolean
        Dim MV_Array() As Double
        Dim Missing_DataArray() As Boolean
        Dim ObjP() As Point
        getDrawOrder_and_ShowF_MarkMode(attrData, LayerNum, DataNum, enmSoloMode_Number.MarkBarMode, D_Order, ShowF, ObjP, Missing_DataArray, MV_Array)

        With attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
            Dim w As Integer = attrData.Get_Length_On_Screen(.Width)
            For i As Integer = 0 To Objn - 1
                Dim num As Integer = D_Order(i)
                Dim MV As Double = MV_Array(num)
                If ShowF(num) = True Then
                    Dim OP As Point = ObjP(num)
                    attrData.TempData.ObjectPrintedCheckFlag(LayerNum)(num) = True

                    If Missing_DataArray(num) = True Then
                        Dim MK As Mark_Property
                        MK = attrData.TotalData.ViewStyle.Missing_Data.MarkBar
                        Dim r As Integer = attrData.Radius(MK.WordFont.Body.Size, 1, 1)
                        attrData.Draw_Mark(g, OP, r, MK)
                    Else
                        Dim maxv As Double
                        If .MaxValueMode = clsAttrData.enmMarkSizeValueMode.inDataItem Then
                            maxv = attrData.LayerData(LayerNum).atrData.Data(DataNum).Statistics.Max
                        Else
                            maxv = .MaxValue
                        End If
                        Dim h As Integer = attrData.Get_Length_On_Screen(.MaxHeight) * MV / maxv
                        Dim rect As Rectangle = New Rectangle(OP.X - w / 2, OP.Y - h, w, h)

                        Dim Tile As Tile_Property
                        If MkCommon.Inner_Data.Flag = True Then
                            Tile = attrData.Get_InnerTile(MkCommon.Inner_Data, LayerNum, Category_Array_Inner(num))
                        Else
                            Tile = .InnerTile
                        End If
                        Select Case .BarShape
                            Case clsAttrData.MarkBarShape.triangle
                                Dim tri(3) As Point
                                tri(0) = New Point(OP.X - w / 2, OP.Y)
                                tri(1) = New Point(OP.X + w / 2, OP.Y)
                                tri(2) = New Point(OP.X, OP.Y - h)
                                tri(3) = tri(0)
                                attrData.Draw_Poly_Inner(g, tri, {4}, 1, Tile)
                                attrData.Draw_Line(g, .FrameLinePat, 4, tri)
                            Case clsAttrData.MarkBarShape.bar
                                If .ThreeD = True Then
                                    Dim poly() As Point
                                    Dim poly2() As Point
                                    MarkBarRectPrint3D(OP, w, h, rect, poly, poly2)
                                    Dim Ptile As Tile_Property = Tile
                                    Ptile.Line.BasicLine.SolidLine.Color = clsGeneric.GetColorArrange(Tile.Line.BasicLine.SolidLine.Color, 100)
                                    attrData.Draw_Poly_Inner(g, poly, {5}, 1, Ptile)
                                    attrData.Draw_Line(g, .FrameLinePat, 5, poly)

                                    Dim Ptile2 As Tile_Property = Tile
                                    Ptile2.Line.BasicLine.SolidLine.Color = clsGeneric.GetColorArrange(Tile.Line.BasicLine.SolidLine.Color, -100)
                                    attrData.Draw_Poly_Inner(g, poly2, {5}, 1, Ptile2)
                                    attrData.Draw_Line(g, .FrameLinePat, 5, poly2)
                                End If
                                attrData.Draw_Tile_Box(g, rect, 0, .FrameLinePat, Tile)
                                If .ScaleLineVisible = True Then
                                    For v As Double = .ScaleLineInterval To MV Step .ScaleLineInterval
                                        Dim ypos As Integer = rect.Bottom - attrData.Get_Length_On_Screen(.MaxHeight) * v / maxv
                                        attrData.Draw_Line(g, .scaleLinePat, New Point(rect.X, ypos), New Point(rect.Right, ypos))
                                    Next
                                    attrData.Draw_Tile_Box(g, rect, 0, .FrameLinePat, clsBase.BlancTile)
                                End If
                        End Select

                        Dim OVP As Point = New Point(rect.X + rect.Width / 2, rect.Bottom)
                        ObjectValue_and_Name_Print(g, attrData, OVP, enmVerticalAlignment.Top, LayerNum, DataNum, num)

                    End If
                End If
            Next
        End With

        If Clip_F = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion2
            Make_ClippingRegion2.Dispose()
        End If
    End Sub
    Public Shared Sub MarkBarRectPrint3D(ByVal Pos As Point, ByVal w As Integer, ByVal h As Integer,
                                            ByRef CenterRect As Rectangle, ByRef UpperPoly() As Point, ByRef RightPoly() As Point)

        Dim TheeDS As Integer = w \ 3
        ReDim UpperPoly(4)
        UpperPoly(0) = CenterRect.Location
        UpperPoly(1) = New Point(CenterRect.X + CenterRect.Width, CenterRect.Y)
        UpperPoly(2) = New Point(CenterRect.X + CenterRect.Width + TheeDS, CenterRect.Y - TheeDS)
        UpperPoly(3) = New Point(CenterRect.X + TheeDS, CenterRect.Y - TheeDS)
        UpperPoly(4) = UpperPoly(0)

        ReDim RightPoly(4)
        RightPoly(0) = UpperPoly(1)
        RightPoly(1) = UpperPoly(2)
        RightPoly(2) = New Point(RightPoly(1).X, UpperPoly(2).Y + CenterRect.Height)
        RightPoly(3) = New Point(RightPoly(0).X, CenterRect.Y + CenterRect.Height)
        RightPoly(4) = UpperPoly(0)

    End Sub
    ''' <summary>
    ''' 記号の回転モード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintMarkTurnMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                       ByVal LayerNum As Integer, ByVal DataNum As Integer)
        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(LayerNum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Clip_F As Boolean
        Dim Original_ClippingRegion2 As Region
        Dim Make_ClippingRegion2 As Region
        If PolygonDummy_ClipSet_F = True Then
            Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
            Clip_F = ClippingRegion_ObjectBoundary_set(g, attrData, LayerNum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
        Else
            Clip_F = False
        End If

        If attrData.LayerData(LayerNum).Shape = enmShape.PolygonShape Then
            Vector_Object_Boundary(g, attrData, LayerNum)
        End If
        Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
        Vector_Connect_CenterP_To_SymbolPoint(g, attrData, LayerNum)
        Dim InnerDT As clsAttrData.strInner_Data_Info = attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon.Inner_Data
        Dim Category_Array_Inner() As Integer
        If InnerDT.Flag = True Then
            Category_Array_Inner = attrData.Get_Categoly(LayerNum, InnerDT.Data)
        End If
        Dim MkCommon As clsAttrData.strMarkCommon_Data = attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon

        '表示順序と表示の可否
        Dim D_Order() As Integer
        Dim ShowF() As Boolean
        Dim MV_Array() As Double
        Dim Missing_DataArray() As Boolean
        Dim ObjP() As Point
        getDrawOrder_and_ShowF_MarkMode(attrData, LayerNum, DataNum, enmSoloMode_Number.MarkTurnMode, D_Order, ShowF, ObjP, Missing_DataArray, MV_Array)

        With attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkTurnMD

            For i As Integer = 0 To attrData.LayerData(LayerNum).atrObject.ObjectNum - 1
                If ShowF(i) = True Then
                    attrData.TempData.ObjectPrintedCheckFlag(LayerNum)(i) = True
                    Dim MV As Double = MV_Array(i)

                    Dim MK As Mark_Property
                    If Missing_DataArray(i) = True Then
                        MK = attrData.TotalData.ViewStyle.Missing_Data.TurnMark
                    Else
                        MK = .Mark
                        If MkCommon.Inner_Data.Flag = True Then
                            MK.Tile = attrData.Get_InnerTile(MkCommon.Inner_Data, LayerNum, Category_Array_Inner(i))
                            MK.WordFont.Body.Color = MK.Tile.Line.BasicLine.SolidLine.Color

                        End If
                        Dim k2 As Single = (MV / .DegreeLap) * 360
                        If .Dirction = clsAttrData.enmMarkTurnDirection.Clockwise Then
                            k2 = -k2
                        End If
                        MK.WordFont.Body.Kakudo = MK.WordFont.Body.Kakudo + k2
                    End If
                    Dim r As Integer = attrData.Radius(MK.WordFont.Body.Size, 1, 1)
                    Dim OP = ObjP(i)
                    attrData.Draw_Mark(g, OP, r, MK)
                    Dim OVP As Point = OP
                    OVP.Y += r
                    ObjectValue_and_Name_Print(g, attrData, OVP, enmVerticalAlignment.Top, LayerNum, DataNum, i)
                End If
            Next
        End With

        If Clip_F = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion2
            Make_ClippingRegion2.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' 記号の数モード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintMarkBlockMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                       ByVal LayerNum As Integer, ByVal DataNum As Integer)
        Dim Rand As New System.Random()
        If attrData.TempData.DotMap_Temp.DotMapTempResetF = True Then
            attrData.TempData.DotMap_Temp.DotMapPoint = New Dictionary(Of Integer, PointF())
        End If

        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(LayerNum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Clip_F As Boolean
        Dim Original_ClippingRegion2 As Region
        Dim Make_ClippingRegion2 As Region
        If PolygonDummy_ClipSet_F = True Then
            Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
            Clip_F = ClippingRegion_ObjectBoundary_set(g, attrData, LayerNum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
        Else
            Clip_F = False
        End If

        If attrData.LayerData(LayerNum).Shape = enmShape.PolygonShape Then
            Vector_Object_Boundary(g, attrData, LayerNum)
        End If
        Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
        Vector_Connect_CenterP_To_SymbolPoint(g, attrData, LayerNum)

        Dim MV_Array() As Double = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, DataNum)
        Dim Missing_DataArray() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, DataNum)

        Dim MkCommon As clsAttrData.strMarkCommon_Data = attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon
        With attrData.LayerData(LayerNum)
            Dim InnerDT As clsAttrData.strInner_Data_Info = .atrData.Data(DataNum).SoloModeViewSettings.MarkCommon.Inner_Data
            Dim Category_Array_Inner() As Integer
            If InnerDT.Flag = True Then
                Category_Array_Inner = attrData.Get_Categoly(LayerNum, InnerDT.Data)
            End If
            Dim BlockInterval As Single
            Select Case .atrData.Data(DataNum).SoloModeViewSettings.MarkBlockMD.Overlap
                Case 0
                    BlockInterval = 1.1
                Case 1
                    BlockInterval = 1
                Case 2
                    BlockInterval = 0.75
                Case 3
                    BlockInterval = 0.5
                Case 4
                    BlockInterval = 0.25
            End Select
            Dim r As Integer = attrData.Radius(.atrData.Data(DataNum).SoloModeViewSettings.MarkBlockMD.Mark.WordFont.Body.Size, 1, 1)
            prog.Maximum = .atrObject.ObjectNum - 1
            Dim ProgInterval As Integer = .atrObject.ObjectNum \ 10
            If ProgInterval < 5 Then
                ProgInterval = 5
            End If
            For i As Integer = 0 To .atrObject.ObjectNum - 1
                If i Mod ProgInterval = 0 Then
                    prog.Value = i
                End If

                If attrData.Check_Condition(LayerNum, i) = True And _
                   (Missing_DataArray(i) = False Or attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True) Then
                    Dim MV As Double = MV_Array(i)
                    With .atrData.Data(DataNum).SoloModeViewSettings.MarkBlockMD

                        Dim Block_n As Integer = Int(Math.Abs(MV) / .Value)
                        Dim Hasu As Double = Math.Abs(MV) - (.Value * Block_n)
                        Dim Hasu_R As Integer = attrData.Radius(.Mark.WordFont.Body.Size, Hasu, .Value)
                        Dim CP As PointF = attrData.LayerData(LayerNum).atrObject.atrObjectData(i).Symbol
                        Dim OP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(CP)
                        attrData.TempData.ObjectPrintedCheckFlag(LayerNum)(i) = True
                        If Missing_DataArray(i) = True Then
                            Vector_Block_Draw_Block(g, attrData, LayerNum, i, Rand, OP, r, attrData.TotalData.ViewStyle.Missing_Data.BlockMark, 1, clsAttrData.enmMarkBlockArrange.Block, False, 0, 0, 1)
                        Else
                            Dim MK As Mark_Property = .Mark
                            If MkCommon.Inner_Data.Flag = True Then
                                MK.Tile = attrData.Get_InnerTile(MkCommon.Inner_Data, LayerNum, Category_Array_Inner(i))
                                MK.WordFont.Body.Color = MK.Tile.Line.BasicLine.SolidLine.Color
                            Else
                                If MV < 0 Then
                                    MK.Tile = MkCommon.MinusTile
                                End If
                            End If
                            Dim valPos As Point = Vector_Block_Draw_Block(g, attrData, LayerNum, i, Rand, OP, r, MK, Block_n, .ArrangeB, .HasuVisible, Hasu_R, Hasu, BlockInterval)
                            ObjectValue_and_Name_Print(g, attrData, valPos, enmVerticalAlignment.Top, LayerNum, DataNum, i)
                        End If
                    End With
                End If
            Next
        End With
        attrData.TempData.DotMap_Temp.DotMapTempResetF = False
        If Clip_F = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion2
            Make_ClippingRegion2.Dispose()
        End If
    End Sub
    Private Shared Function Vector_Block_Draw_Block(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal ObjNum As Integer, ByRef Rand As System.Random,
                                                    ByVal OP As Point, ByVal r As Integer, ByVal MK As Mark_Property,
                                        ByVal Block_n As Integer, ByVal ArrangeB As clsAttrData.enmMarkBlockArrange,
                                        ByVal HasuVisible As Boolean, ByVal Hasu_R As Integer, ByVal Hasu As Double, ByVal BlockInterval As Single) As Point


        Dim r2 As Integer
        Dim ap As Point
        Dim RetP As Point = OP

        spatial.Get_TurnedBox(r, r, MK.WordFont.Body.Kakudo, r2, r2)
        Select Case ArrangeB
            Case clsAttrData.enmMarkBlockArrange.Block
                Dim Q As Single = Math.Sqrt(Block_n)
                Dim qx As Integer
                Dim qy As Integer
                If Q <> Int(Q) Then
                    qx = Int(Q) + 1
                    If Block_n <= qx * qx - qx Then
                        qy = qx - 1
                    Else
                        qy = qx
                    End If
                Else
                    qx = Int(Q)
                    qy = Int(Q)
                End If

                If qx = 0 Then
                    Vector_Block_Draw_Hasu(g, attrData, OP, Hasu_R, MK, Hasu, HasuVisible)
                End If


                OP.Y -= (qy - 1) * r2 * BlockInterval
                OP.X -= (qx - 1) * r2 * BlockInterval
                Dim n As Integer = 0
                Dim k2 As Integer
                Dim j2 As Integer
                For k As Integer = 0 To qy - 1
                    For j As Integer = 0 To qx - 1
                        ap.Y = OP.Y + r2 * 2 * BlockInterval * k
                        If n < Block_n Then
                            ap.X = OP.X + r2 * 2 * BlockInterval * j
                            ap.Y = OP.Y + r2 * 2 * BlockInterval * k
                            Vector_Block_Arrange_OverLay_Block(attrData, ap, r, ArrangeB, Q, BlockInterval)
                            Vector_Block_Draw_Block2(g, attrData, ap, r, MK)
                            k2 = k
                            j2 = j
                        End If
                        n += 1
                    Next
                Next
                If Block_n > 0 Then
                    ap.X = OP.X + r2 * 2 * BlockInterval * (j2 + 0.5) + Hasu_R * BlockInterval
                    ap.Y = OP.Y + r2 * 2 * BlockInterval * (k2 - 0.5) + Hasu_R * BlockInterval
                    Vector_Block_Arrange_OverLay_Block(attrData, ap, r, ArrangeB, Q, BlockInterval)
                    Vector_Block_Draw_Hasu(g, attrData, ap, Hasu_R, MK, Hasu, HasuVisible)
                End If
                RetP.Y += (r2 * 2 * BlockInterval * Math.Max(qy, 1)) / 2
            Case clsAttrData.enmMarkBlockArrange.Vertical
                For j As Integer = 0 To Block_n - 1
                    ap.Y = OP.Y - r2 * 2 * BlockInterval * j
                    ap.X = OP.X
                    Vector_Block_Arrange_OverLay_Block(attrData, ap, r, ArrangeB)
                    Call Vector_Block_Draw_Block2(g, attrData, ap, r, MK)
                Next
                ap.Y = OP.Y - r2 * 2 * BlockInterval * (Block_n - 1) - r2 * BlockInterval - Hasu_R * BlockInterval
                ap.X = OP.X
                Vector_Block_Arrange_OverLay_Block(attrData, ap, r, ArrangeB)
                Vector_Block_Draw_Hasu(g, attrData, ap, Hasu_R, MK, Hasu, HasuVisible)
                RetP.Y += r2
            Case clsAttrData.enmMarkBlockArrange.Horizontal
                For j As Integer = 0 To Block_n - 1
                    ap.X = OP.X + r2 * 2 * BlockInterval * (j - Block_n / 2 + 0.5)
                    ap.Y = OP.Y
                    Vector_Block_Arrange_OverLay_Block(attrData, ap, r, ArrangeB)
                    Vector_Block_Draw_Block2(g, attrData, ap, r, MK)
                Next
                ap.X = OP.X + r2 * 2 * BlockInterval * (Block_n - 1 - Block_n / 2 + 0.5) + r2 * BlockInterval + Hasu_R * BlockInterval
                ap.Y = OP.Y
                Vector_Block_Arrange_OverLay_Block(attrData, ap, r, ArrangeB)
                Vector_Block_Draw_Hasu(g, attrData, ap, Hasu_R, MK, Hasu, HasuVisible)
                RetP.Y += r2
            Case clsAttrData.enmMarkBlockArrange.PolygonRandom
                Dim brush = New SolidBrush(MK.Tile.Line.BasicLine.SolidLine.Color.getColor)
                If attrData.TempData.DotMap_Temp.DotMapTempResetF = True Or attrData.TempData.DotMap_Temp.DotMapPoint.ContainsKey(ObjNum) = False Then
                    Dim onP As New List(Of PointF)
                    For j As Integer = 0 To Block_n - 1
                        Dim area As RectangleF = attrData.Get_Kencode_Object_Circumscribed_Rectangle(Layernum, ObjNum)
                        Dim inf As Boolean = False
                        Dim p As PointF
                        Do
                            p.X = Rand.NextDouble() * area.Width + area.Left
                            p.Y = Rand.NextDouble() * area.Height + area.Top
                            inf = attrData.Check_Point_in_Kencode_OneObject(Layernum, ObjNum, p)
                        Loop Until inf = True
                        onP.Add(p)
                        ap = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(p)
                        If r <> 0 Then
                            Vector_Block_Draw_Block2(g, attrData, ap, r, MK)
                        Else
                            g.FillRectangle(brush, ap.X, ap.Y, 1, 1)
                        End If
                    Next
                    attrData.TempData.DotMap_Temp.DotMapPoint.Add(ObjNum, onP.ToArray())
                Else
                    Dim pOn As PointF() = attrData.TempData.DotMap_Temp.DotMapPoint(ObjNum)
                    For j As Integer = 0 To Block_n - 1
                        ap = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(pOn(j))
                        If r <> 0 Then
                            Vector_Block_Draw_Block2(g, attrData, ap, r, MK)
                        Else
                            g.FillRectangle(brush, ap.X, ap.Y, 1, 1)
                        End If
                    Next

                End If

        End Select
        Return RetP
    End Function
    Private Shared Sub Vector_Block_Draw_Block2(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal ap As Point, ByVal r As Integer, ByVal MK As Mark_Property)

        If attrData.Check_Screen_In(ap, r) = True Then
            attrData.Draw_Mark(g, ap, r, MK)
        End If
    End Sub
    Private Shared Sub Vector_Block_Draw_Hasu(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal ap As Point, ByVal Hasu_R As Integer, ByVal MK As Mark_Property,
                                              ByVal Hasu As Double, ByVal HasuVisible As Boolean)

        If Hasu = 0 Or HasuVisible = False Then
            Return
        End If
        If attrData.Check_Screen_In(ap, Hasu_R) = True Then
            attrData.Draw_Mark(g, ap, Hasu_R, MK)
        End If

    End Sub
    Private Shared Sub Vector_Block_Arrange_OverLay_Block(ByRef attrData As clsAttrData, ByRef ap As Point, ByVal r As Integer,
                                                 ByVal ArrangeB As clsAttrData.enmMarkBlockArrange, Optional ByVal Q As Single = 0, Optional BlockInterval As Single = 0)
 
        With attrData.TempData.OverLay_Temp
            If .OverLay_EMode_N >= 2 And .OverLay_Printing_Flag = True And attrData.TotalData.TotalMode.OverLay.MarkModePosFixFlag = False Then
                Select Case ArrangeB
                    Case clsAttrData.enmMarkBlockArrange.Block
                        ap.X += ((.OverLay_EMode_Now Mod 2) * 2 - 1) * (Math.Ceiling(Q) * r * BlockInterval + r)
                        If .OverLay_EMode_N > 2 Then
                            ap.Y += +((.OverLay_EMode_Now \ 2) * 2 - 1) * (Int(Q) * r * BlockInterval + r)
                        End If
                    Case clsAttrData.enmMarkBlockArrange.Vertical
                        ap.X += ((.OverLay_EMode_Now - .OverLay_EMode_N + 1) - (.OverLay_EMode_N \ 2)) * r * 2.2
                    Case clsAttrData.enmMarkBlockArrange.Horizontal
                        ap.Y += ((.OverLay_EMode_Now - .OverLay_EMode_N + 1) - (.OverLay_EMode_N \ 2)) * r * 2.2
                End Select
            End If
        End With
    End Sub
    ''' <summary>
    ''' 記号の大きさモード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintMarkSizeMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                       ByVal LayerNum As Integer, ByVal DataNum As Integer)
        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(LayerNum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Clip_F As Boolean
        Dim Original_ClippingRegion2 As Region
        Dim Make_ClippingRegion2 As Region
        If PolygonDummy_ClipSet_F = True Then
            Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
            Clip_F = ClippingRegion_ObjectBoundary_set(g, attrData, LayerNum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
        Else
            Clip_F = False
        End If

        If attrData.LayerData(LayerNum).Shape = enmShape.PolygonShape Then
            Vector_Object_Boundary(g, attrData, LayerNum)
        End If
        Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
        Vector_Connect_CenterP_To_SymbolPoint(g, attrData, LayerNum)

        Dim hnfontObname As Font
        Dim hnfontValue As Font

        With attrData.TotalData.ViewStyle.ValueShow
            With .ObjNameFont.Body
                Dim TH As Integer = attrData.Get_Length_On_Screen(.Size)
                Dim fstyle As New FontStyle
                If .bold = True Then
                    fstyle = fstyle Or FontStyle.Bold
                End If
                If .italic = True Then
                    fstyle = fstyle Or FontStyle.Italic
                End If
                If .Underline = True Then
                    fstyle = fstyle Or FontStyle.Underline
                End If
                hnfontObname = New Font(.Name, TH, fstyle, GraphicsUnit.Pixel)
            End With
            With .ValueFont.Body
                Dim TH As Integer = attrData.Get_Length_On_Screen(.Size)
                Dim fstyle As New FontStyle
                If .bold = True Then
                    fstyle = fstyle Or FontStyle.Bold
                End If
                If .italic = True Then
                    fstyle = fstyle Or FontStyle.Italic
                End If
                If .Underline = True Then
                    fstyle = fstyle Or FontStyle.Underline
                End If
                hnfontValue = New Font(.Name, TH, fstyle, GraphicsUnit.Pixel)
            End With
        End With



        With attrData.LayerData(LayerNum)
            Dim MkCommon As clsAttrData.strMarkCommon_Data = .atrData.Data(DataNum).SoloModeViewSettings.MarkCommon
            Dim InnerDT As clsAttrData.strInner_Data_Info = .atrData.Data(DataNum).SoloModeViewSettings.MarkCommon.Inner_Data
            Dim Category_Array_Inner() As Integer
            If InnerDT.Flag = True Then
                Category_Array_Inner = attrData.Get_Categoly(LayerNum, InnerDT.Data)
            End If
            prog.Maximum = .atrObject.ObjectNum - 1
            Dim ProgInterval As Integer = .atrObject.ObjectNum \ 10
            If ProgInterval < 5 Then
                ProgInterval = 5
            End If

            '表示順序と表示の可否
            Dim D_Order() As Integer
            Dim ShowF() As Boolean
            Dim MV_Array() As Double
            Dim Missing_DataArray() As Boolean
            Dim ObjP() As Point
            getDrawOrder_and_ShowF_MarkMode(attrData, LayerNum, DataNum, enmSoloMode_Number.MarkSizeMode, D_Order, ShowF, ObjP, Missing_DataArray, MV_Array)

            For i As Integer = 0 To .atrObject.ObjectNum - 1
                If i Mod ProgInterval = 0 Then
                    prog.Value = i
                End If
                Dim kpos As Integer = D_Order(i)
                Dim MV As Double = MV_Array(kpos)
                With .atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD
                    Dim MK As Mark_Property = .Mark
                    If ShowF(kpos) = True Then
                        If InnerDT.Flag = True Then
                            MK.Tile = attrData.Get_InnerTile(InnerDT, LayerNum, Category_Array_Inner(kpos))
                            MK.WordFont.Body.Color = MK.Tile.Line.BasicLine.SolidLine.Color
                        Else
                            If MV < 0 Then
                                MK.Tile = MkCommon.MinusTile
                                MK.WordFont.Body.Color = MkCommon.MinusTile.Line.BasicLine.SolidLine.Color
                            End If
                        End If
                        Dim r As Integer= PrintMarkSizeMode_Draw(g, attrData, LayerNum, DataNum, kpos, ObjP(kpos), MK, MV, Missing_DataArray(kpos))
                        attrData.TempData.ObjectPrintedCheckFlag(LayerNum)(kpos) = True
                        With attrData.TotalData.ViewStyle.ValueShow
                            If .ObjNameVisible = True Or .ValueVisible = True Then
                                Dim name As String = attrData.Get_KenObjName(LayerNum, kpos)
                                Dim V As String = attrData.Get_Data_Value(LayerNum, DataNum, kpos, "欠損値")
                                Dim OP As Point = ObjP(kpos)
                                Dim xs As Integer = 0
                                If .ObjNameVisible = True Then
                                    xs = g.MeasureString(name, hnfontObname).Width
                                End If
                                If .ValueVisible = True Then
                                    xs = Math.Max(xs, g.MeasureString(V, hnfontValue).Width)
                                End If

                                If xs < r * 2 Or attrData.LayerData(LayerNum).Shape = enmShape.LineShape Then
                                    ObjectValue_and_Name_Print(g, attrData, OP, enmVerticalAlignment.Center, LayerNum, DataNum, kpos)
                                Else
                                    Dim OVP As Point = OP
                                    OVP.Y += r
                                    ObjectValue_and_Name_Print(g, attrData, OVP, enmVerticalAlignment.Top, LayerNum, DataNum, kpos)

                                End If
                            End If
                        End With
                    End If
                End With
            Next
        End With
        hnfontValue.Dispose()
        hnfontObname.Dispose()

        If Clip_F = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion2
            Make_ClippingRegion2.Dispose()
        End If
    End Sub

    Private Shared Function PrintMarkSizeMode_Draw(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal DataNum As Integer,
                                   ByVal kpos As Integer, ByVal pos As Point, ByVal MK As Mark_Property, ByVal MV As Double, ByVal MisF As Boolean) As Integer
        Dim InnerDT As clsAttrData.strInner_Data_Info = attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon.Inner_Data
        With attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD
            Dim maxv As Double
            If .MaxValueMode = clsAttrData.enmMarkSizeValueMode.inDataItem Then
                maxv = Math.Max(Math.Abs(attrData.Get_DataMax(Layernum, DataNum)), Math.Abs(attrData.Get_DataMin(Layernum, DataNum)))
            Else
                maxv = .MaxValue
            End If
            Select Case attrData.LayerData(Layernum).Shape
                Case enmShape.PointShape, enmShape.PolygonShape
                    Dim r As Integer
                    If MisF = True Then
                        MK = attrData.TotalData.ViewStyle.Missing_Data.Mark
                        r = attrData.Radius(MK.WordFont.Body.Size, 1, 1)
                    Else
                        r = attrData.Radius(.Mark.WordFont.Body.Size, Math.Abs(MV), maxv)
                    End If
                    attrData.Draw_Mark(g, pos, r, MK)
                    Return r
                Case enmShape.LineShape
                    Dim LineSize As Single = Math.Abs(MV) / maxv * .LineShape.LineWidth
                    Dim ELine() As clsMapData.EnableMPLine_Data
                    Dim n As Integer = attrData.Get_Enable_KenCode_MPLine(ELine, Layernum, kpos)
                    For j As Integer = 0 To n - 1
                        Dim pxy() As Point
                        Dim np As Integer
                        With attrData.LayerData(Layernum).MapFileData.MPLine(ELine(j).LineCode)
                            np = .NumOfPoint
                            pxy = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(np, .PointSTC, False)
                        End With
                        Dim LineShapeLine As Line_Property
                        If MisF = True Then
                            LineShapeLine = attrData.TotalData.ViewStyle.Missing_Data.LineShape
                        Else
                            LineShapeLine = clsBase.Line
                            If InnerDT.Flag = True Then
                                LineShapeLine.Set_Same_ColorWidth_to_LinePat(MK.WordFont.Body.Color, LineSize)
                            Else
                                LineShapeLine.Set_Same_ColorWidth_to_LinePat(.LineShape.Color, LineSize)
                            End If
                            LineShapeLine.Edge_Connect_Pattern = .Mark.Line.Edge_Connect_Pattern
                        End If
                        attrData.Draw_Line(g, LineShapeLine, np, pxy)
                    Next
            End Select
        End With
    End Function
    ''' <summary>
    ''' 階級区分モードの点・面形状オブジェクトの線モード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintClassODMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                       ByVal LayerNum As Integer, ByVal DataNum As Integer)


        Dim Clip_F As Boolean
        Dim Original_ClippingRegion2 As Region
        Dim Make_ClippingRegion2 As Region
        With attrData.LayerData(LayerNum)
            Dim PolygonDummy_ClipSet_F As Boolean = .LayerModeViewSettings.PolygonDummy_ClipSet_F
            If PolygonDummy_ClipSet_F = True Then
                Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
                Clip_F = ClippingRegion_ObjectBoundary_set(g, attrData, LayerNum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
            Else
                Clip_F = False
            End If

            Dim Category_Array() As Integer = attrData.Get_Categoly(LayerNum, DataNum)
            Dim DrawOrderByValue As clsSortingSearch = ClassMode_Point_Shape_DrawOrder(attrData, LayerNum, DataNum)
            Vector_Object_Boundary(g, attrData, LayerNum)
            Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)

            Dim OD_MD As clsAttrData.strClassODMode_data = .atrData.Data(DataNum).SoloModeViewSettings.ClassODMD
            Dim StartP As Point
            Dim StartFP As PointF
            With OD_MD
                If .Dummy_ObjectFlag = True Then
                    attrData.LayerData(LayerNum).MapFileData.Get_Enable_CenterP(StartFP, attrData.LayerData(.o_Layer).Dummy.DummyObj(.O_object).code, attrData.LayerData(.o_Layer).Time)
                Else
                    StartFP = attrData.LayerData(.o_Layer).atrObject.atrObjectData(.O_object).CenterPoint
                End If
                StartP = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(StartFP)
            End With
            prog.Maximum = .atrObject.ObjectNum - 1
            Dim ProgInterval As Integer = .atrObject.ObjectNum \ 10
            If ProgInterval < 5 Then
                ProgInterval = 5
            End If
            For i As Integer = 0 To .atrObject.ObjectNum - 1
                If i Mod ProgInterval = 0 Then
                    prog.Value = i
                End If
                Dim DrawOrder As Integer
                Select Case attrData.TotalData.ViewStyle.PointPaint_Order
                    Case clsAttrData.enmPointOnjectDrawOrder.ObjectOrder
                        DrawOrder = i
                    Case clsAttrData.enmPointOnjectDrawOrder.LowerToUpperCategory
                        DrawOrder = DrawOrderByValue.DataPosition(i)
                    Case clsAttrData.enmPointOnjectDrawOrder.UpperToLowerCategory
                        DrawOrder = DrawOrderByValue.DataPositionRev(i)
                End Select

                If attrData.Check_Condition(LayerNum, DrawOrder) = True And Category_Array(DrawOrder) <> -1 And DrawOrder <> OD_MD.O_object Then
                    Dim colpos As Integer = Category_Array(DrawOrder)
                    attrData.TempData.ObjectPrintedCheckFlag(LayerNum)(DrawOrder) = True
                    Dim DestFP As PointF = attrData.LayerData(LayerNum).atrObject.atrObjectData(DrawOrder).CenterPoint
                    Dim DestP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(DestFP)
                    Dim C_Rect As Rectangle = spatial.Get_Circumscribed_Rectangle(DestP, StartP)
                    If attrData.Check_Screen_In(C_Rect) = True And DestFP.Equals(StartFP) = False Then
                        Dim ODLinePat As Line_Property = .atrData.Data(DataNum).SoloModeViewSettings.Class_Div(colpos).ODLinePat
                        If ODLinePat.Check_Line_PrintPattern = True Then
                            Dim SplineRefP As PointF
                            Dim fp As Boolean = .Get_OD_Bezier_RefPoint(DrawOrder, DataNum, SplineRefP)
                            If fp = False Then
                                '曲線近似でない場合
                                If OD_MD.Arrow.End_Arrow_F = True And OD_MD.Arrow.ArrowHeadType = enmArrowHeadType.Fill Then

                                    Dim Cp As PointF
                                    Dim f As Boolean = clsDrawLine.Check_Draw_Arrow_Line(Cp, DestFP, StartFP, DestFP, StartFP, ODLinePat, OD_MD.Arrow, attrData.TotalData.ViewStyle.ScrData)
                                    If f = True Then
                                        DestP = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(Cp)
                                    End If
                                End If
                                attrData.Draw_Line(g, ODLinePat, StartP, DestP)
                                If OD_MD.Arrow.End_Arrow_F = True Then
                                    attrData.Draw_Arrow(g, DestFP, StartFP, ODLinePat, OD_MD.Arrow)
                                End If
                            Else
                                '曲線近似の場合
                                Dim Refp() As PointF = clsGeneric.Get_OD_Spline_Point(SplineRefP, StartFP, DestFP)
                                If OD_MD.Arrow.End_Arrow_F = True And OD_MD.Arrow.ArrowHeadType = enmArrowHeadType.Fill Then
                                    '塗りつぶしの矢印付き
                                    Dim Cp As PointF
                                    Dim f As Boolean = clsDrawLine.Check_Draw_Arrow_Line(Cp, DestFP, Refp(1), Refp(1), Refp(0), ODLinePat, OD_MD.Arrow, attrData.TotalData.ViewStyle.ScrData)
                                    If f = True Then
                                        Refp(0) = Cp
                                    Else
                                        Refp(0).X = Refp(1).X
                                        Refp(0).Y = Refp(1).Y
                                    End If
                                End If
                                Dim ln As Integer = 4
                                Dim pxy() As Point
                                pxy = clsSpline.Spline_Get(0, ln, Refp, 0.05, attrData.TotalData.ViewStyle.ScrData)
                                attrData.Draw_Line(g, ODLinePat, ln, pxy)

                                If OD_MD.Arrow.End_Arrow_F = True Then
                                    attrData.Draw_Arrow(g, DestFP, Refp(1), ODLinePat, OD_MD.Arrow)
                                End If
                            End If
                        End If
                    End If
                End If
            Next
            ObjectValue_And_Name_Print_byLayer(g, attrData, LayerNum, DataNum)
        End With

        If Clip_F = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion2
            Make_ClippingRegion2.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' 階級区分モードの線形状オブジェクトの線モード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintClassLineShapeSENMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                       ByVal LayerNum As Integer, ByVal DataNum As Integer)
        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(LayerNum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Make_ClippingRegion2 As Region
        Dim Original_ClippingRegion2 As Region
        Dim Clip_F2 As Boolean = False
        Dim LayerShape As enmShape = attrData.LayerData(LayerNum).Shape
        If PolygonDummy_ClipSet_F = True Then
            Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
            Clip_F2 = ClippingRegion_ObjectBoundary_set(g, attrData, LayerNum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
        End If



        Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
        With attrData.LayerData(LayerNum)
            Dim D_Order() As Integer
            Dim ShowF() As Boolean
            Dim Category_Array() As Integer
            getDrawOrder_and_ShowF_ClassMode(attrData, LayerNum, DataNum, Category_Array, D_Order, ShowF)
            prog.Maximum = .atrObject.ObjectNum - 1
            Dim ProgInterval As Integer = .atrObject.ObjectNum \ 10
            If ProgInterval < 5 Then
                ProgInterval = 5
            End If
            For i As Integer = 0 To .atrObject.ObjectNum - 1
                If i Mod ProgInterval = 0 Then
                    prog.Value = i
                End If
                Dim DrawOrder As Integer = D_Order(i)
                If ShowF(DrawOrder) = True Then
                    Dim CP As PointF = .atrObject.atrObjectData(DrawOrder).Symbol
                    attrData.TempData.ObjectPrintedCheckFlag(LayerNum)(DrawOrder) = True
                    Dim colpos As Integer = Category_Array(DrawOrder)
                    Dim ELine() As clsMapData.EnableMPLine_Data
                    Dim n As Integer = attrData.Get_Enable_KenCode_MPLine(ELine, LayerNum, DrawOrder)
                    Dim LineShapeLine As Line_Property
                    If colpos = -1 Then
                        LineShapeLine = attrData.TotalData.ViewStyle.Missing_Data.LineShape
                    Else
                        LineShapeLine = .atrData.Data(DataNum).SoloModeViewSettings.Class_Div(colpos).ODLinePat
                    End If
                    For j As Integer = 0 To n - 1
                        Dim pxy() As Point
                        Dim np As Integer = Get_PointXY_by_LineCode(attrData, LayerNum, ELine(j).LineCode, pxy)
                        attrData.Draw_Line(g, LineShapeLine, np, pxy)
                    Next
                End If
            Next
            ObjectValue_And_Name_Print_byLayer(g, attrData, LayerNum, DataNum)

        End With
        If Clip_F2 = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion2
            Make_ClippingRegion2.Dispose()
        End If
    End Sub


    ''' <summary>
    ''' 階級区分モードの階級記号モード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="prog"></param>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintClassMarkMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                       ByVal LayerNum As Integer, ByVal DataNum As Integer)

        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(LayerNum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Clip_F As Boolean
        Dim Original_ClippingRegion2 As Region
        Dim Make_ClippingRegion2 As Region
        If PolygonDummy_ClipSet_F = True Then
            Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
            Clip_F = ClippingRegion_ObjectBoundary_set(g, attrData, LayerNum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
        Else
            Clip_F = False
        End If

        If attrData.LayerData(LayerNum).Shape = enmShape.PolygonShape Then
            Vector_Object_Boundary(g, attrData, LayerNum)
            Class_Category_Boundary(g, attrData, LayerNum, DataNum)
        End If
        Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
        Vector_Connect_CenterP_To_SymbolPoint(g, attrData, LayerNum)
        '表示順序と表示の可否
        Dim D_Order() As Integer
        Dim ShowF() As Boolean
        Dim Category_Array() As Integer
        getDrawOrder_and_ShowF_ClassMode(attrData, LayerNum, DataNum, Category_Array, D_Order, ShowF)

        With attrData.LayerData(LayerNum)
            Dim InnerDT As clsAttrData.strInner_Data_Info = .atrData.Data(DataNum).SoloModeViewSettings.ClassMarkMD
            Dim Category_Array_Inner() As Integer
            If InnerDT.Flag = True Then
                Category_Array_Inner = attrData.Get_Categoly(LayerNum, InnerDT.Data)
            End If
            prog.Maximum = .atrObject.ObjectNum - 1
            Dim ProgInterval As Integer = .atrObject.ObjectNum \ 10
            If ProgInterval < 5 Then
                ProgInterval = 5
            End If
            For i As Integer = 0 To .atrObject.ObjectNum - 1
                If i Mod ProgInterval = 0 Then
                    prog.Value = i
                End If
                Dim DrawOrder As Integer = D_Order(i)
                If ShowF(DrawOrder) = True Then
                    attrData.TempData.ObjectPrintedCheckFlag(LayerNum)(DrawOrder) = True
                    Dim colpos As Integer = Category_Array(DrawOrder)
                    Dim MK As Mark_Property
                    If colpos = -1 Then
                        MK = attrData.TotalData.ViewStyle.Missing_Data.ClassMark
                    Else
                        MK = .atrData.Data(DataNum).SoloModeViewSettings.Class_Div(colpos).ClassMark
                    End If
                    If InnerDT.Flag = True Then
                        MK.Tile = attrData.Get_InnerTile(InnerDT, LayerNum, Category_Array_Inner(DrawOrder))
                        MK.WordFont.Body.Color = MK.Tile.Line.BasicLine.SolidLine.Color
                    End If
                    Dim r As Integer
                    Dim CP As PointF = .atrObject.atrObjectData(DrawOrder).Symbol
                    Dim OP As Point
                    With attrData.TotalData.ViewStyle.ScrData
                        OP = .Get_SxSy_With_3D(CP)
                        r = .Radius(MK.WordFont.Body.Size, 1, 1)
                    End With
                    OP = getOverlayMarkPosition(attrData, OP, r)
                    attrData.Draw_Mark(g, OP, r, MK)
                    Dim OVP As Point = OP
                    OVP.Y += r
                    ObjectValue_and_Name_Print(g, attrData, OVP, enmVerticalAlignment.Top, LayerNum, DataNum, DrawOrder)
                End If
            Next

        End With

        If Clip_F = True Then
            '作成したクリッピングリージョンを削除
            g.Clip = Original_ClippingRegion2
            Make_ClippingRegion2.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' 階級区分モードのハッチモード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintClassHatchMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                           ByVal LayerNum As Integer, ByVal DataNum As Integer)

        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(LayerNum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Make_ClippingRegion2 As Region
        Dim Original_ClippingRegion2 As Region
        Dim Clip_F2 As Boolean = False
        Dim LayerShape As enmShape = attrData.LayerData(LayerNum).Shape
        If PolygonDummy_ClipSet_F = True Then
            If LayerShape <> enmShape.PolygonShape Then
                Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
            End If
            Clip_F2 = ClippingRegion_ObjectBoundary_set(g, attrData, LayerNum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
            If LayerShape <> enmShape.PolygonShape Then
                Vector_Object_Boundary(g, attrData, LayerNum)
            End If
        Else
            If LayerShape <> enmShape.PolygonShape Then
                Vector_Object_Boundary(g, attrData, LayerNum)
                Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
            End If
        End If

        Dim MSG_Poly As String = ""

        '表示順序と表示の可否
        Dim D_Order() As Integer
        Dim ShowF() As Boolean
        Dim Category_Array() As Integer
        getDrawOrder_and_ShowF_ClassMode(attrData, LayerNum, DataNum, Category_Array, D_Order, ShowF)

        With attrData.LayerData(LayerNum)

            Select Case .Shape
                Case enmShape.PolygonShape
                    If .Type = clsAttrData.enmLayerType.Mesh Then
                        prog.Maximum = .atrObject.ObjectNum
                        Dim ProgInterval As Integer = .atrObject.ObjectNum \ 10
                        If ProgInterval < 5 Then
                            ProgInterval = 5
                        End If
                        For i As Integer = 0 To .atrObject.ObjectNum - 1
                            If i Mod ProgInterval = 0 Then
                                prog.Value = i
                            End If
                            If ShowF(i) = True Then
                                Dim colpos As Integer = Category_Array(i)
                                If colpos = -1 Then
                                    HatchOnePolygonObject(g, attrData, LayerNum, i, attrData.TotalData.ViewStyle.Missing_Data.PaintTile)
                                Else
                                    HatchOnePolygonObject(g, attrData, LayerNum, i, attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.Class_Div(colpos).TilePat)
                                End If
                            End If
                        Next

                    Else
                        Dim sti As Integer
                        If attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True And .atrData.Data(DataNum).MissingValueNum <> 0 Then
                            sti = -1
                        Else
                            sti = 0
                        End If
                        '階級区分ごとに地図描画
                        prog.Maximum = .atrData.Data(DataNum).SoloModeViewSettings.Div_Num
                        For i As Integer = sti To .atrData.Data(DataNum).SoloModeViewSettings.Div_Num - 1
                            prog.Value = i + 1
                            Dim TI As Tile_Property
                            If i = -1 Then
                                TI = attrData.TotalData.ViewStyle.Missing_Data.HatchTile
                            Else
                                TI = .atrData.Data(DataNum).SoloModeViewSettings.Class_Div(i).TilePat
                            End If
                            Dim MultiObj(.atrObject.ObjectNum - 1) As Integer
                            Dim MbjN As Integer = 0
                            For j As Integer = 0 To .atrObject.ObjectNum - 1
                                If Category_Array(j) = i Then
                                    If ShowF(j) = True Then
                                        attrData.TempData.ObjectPrintedCheckFlag(LayerNum)(j) = True
                                        MultiObj(MbjN) = j
                                        MbjN += 1
                                    End If
                                End If
                            Next
                            If MbjN > 0 And TI.TileCode <> enmTilePattern.Blank Then
                                HatchMultiPolygonObject(g, attrData, LayerNum, MbjN, MultiObj, TI, False)
                            End If
                        Next
                    End If
                Case enmShape.PointShape
                    Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
                    Vector_Connect_CenterP_To_SymbolPoint(g, attrData, LayerNum)
                    Dim PointLayerMark As Mark_Property = .LayerModeViewSettings.PointLineShape.PointMark

                    prog.Maximum = .atrObject.ObjectNum
                    Dim ProgInterval As Integer = .atrObject.ObjectNum \ 10
                    If ProgInterval < 5 Then
                        ProgInterval = 5
                    End If
                    For i As Integer = 0 To .atrObject.ObjectNum - 1
                        If i Mod ProgInterval = 0 Then
                            prog.Value = i
                        End If
                        Dim DrawOrder As Integer = D_Order(i)
                        If ShowF(DrawOrder) = True Then
                            Dim colpos As Integer = Category_Array(DrawOrder)
                            Dim CP As PointF = .atrObject.atrObjectData(DrawOrder).Symbol
                            Dim OP As Point
                            Dim r As Integer
                            With attrData.TotalData.ViewStyle.ScrData
                                OP = .Get_SxSy_With_3D(CP)
                                r = .Radius(PointLayerMark.WordFont.Body.Size, 1, 1)
                            End With

                            If colpos = -1 Then
                                PointLayerMark.Tile = attrData.TotalData.ViewStyle.Missing_Data.HatchTile
                            Else
                                PointLayerMark.Tile = attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.Class_Div(colpos).TilePat
                            End If
                            attrData.Draw_Mark(g, OP, r, PointLayerMark)
                            Dim OVP As Point = OP
                            OVP.Y += r
                            ObjectValue_and_Name_Print(g, attrData, OVP, enmVerticalAlignment.Top, LayerNum, DataNum, DrawOrder)
                        End If
                    Next
            End Select


            If .Shape = enmShape.PolygonShape Then
                Vector_Object_Boundary(g, attrData, LayerNum)
                Class_Category_Boundary(g, attrData, LayerNum, DataNum)
                ObjectValue_And_Name_Print_byLayer(g, attrData, LayerNum, DataNum)
            End If


            If Clip_F2 = True Then
                '作成したクリッピングリージョンを削除
                Vector_Dummy_Boundary(g, attrData, LayerNum, False, True)
                g.Clip = Original_ClippingRegion2
                Make_ClippingRegion2.Dispose()
                Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
            Else
                Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
            End If

        End With
    End Sub
    ''' <summary>
    ''' 階級区分ごとの境界線描が
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub Class_Category_Boundary(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal DataNum As Integer)



        If attrData.TotalData.ViewStyle.MapLegend.ClassMD.ClassBoundaryLine.Visible = False Or attrData.LayerData(Layernum).Type = clsAttrData.enmLayerType.Mesh Then
            Exit Sub
        End If

        Dim Alin As Integer = attrData.LayerData(Layernum).MapFileData.Map.ALIN
        Dim objN As Integer = attrData.LayerData(Layernum).atrObject.ObjectNum
        Dim StacLine(Alin) As Integer
        Dim MultiObj(objN - 1) As Integer
        Dim ELine() As clsMapData.EnableMPLine_Data

        Dim sti As Integer = 0
        If attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True And
            attrData.LayerData(Layernum).atrData.Data(DataNum).MissingValueNum <> 0 Then
            sti = -1
        End If

        Dim Category_Array() As Integer = attrData.Get_Categoly(Layernum, DataNum)
        For i As Integer = sti To attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.Div_Num - 1
            Dim MbjN As Integer = 0
            For j As Integer = 0 To objN - 1
                If Category_Array(j) = i Then
                    If attrData.Check_Condition(Layernum, j) = True And _
                        (Category_Array(j) <> -1 Or attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True) Then
                        If attrData.Check_screen_Kencode_In(Layernum, j) = True Then
                            MultiObj(MbjN) = j
                            MbjN += 1
                        End If
                    End If
                End If
            Next
            If MbjN > 0 Then
                Dim n As Integer = Gey_Multi_Object_OuterLineCode(attrData, Layernum, MbjN, MultiObj, False, ELine)
                For j As Integer = 0 To n - 1
                    StacLine(ELine(j).LineCode) += 1
                Next
            End If
        Next

        For i As Integer = 0 To Alin - 1
            If StacLine(i) = 2 Then
                Dim pxy() As Point
                Dim ln As Integer = Get_PointXY_by_LineCode(attrData, Layernum, i, pxy)
                attrData.Draw_Line(g, attrData.TotalData.ViewStyle.MapLegend.ClassMD.ClassBoundaryLine.LPat, ln, pxy)
            End If
        Next

    End Sub
    ''' <summary>
    ''' 複数オブジェクトにまとめてハッチをかける
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="MbjN"></param>
    ''' <param name="MultiObj">レイヤ内のオブジェクトの位置またはオブジェクト番号</param>
    ''' <param name="TI"></param>
    ''' <param name="Dummy_F">trueの場合はO_ObjNum_Code=MPObjの番号、Falseの場合はKencodeの位置</param>
    ''' <remarks></remarks>
    Private Shared Sub HatchMultiPolygonObject(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer,
                                               ByVal MbjN As Integer, MultiObj() As Integer,
                                                ByRef TI As Tile_Property, ByVal Dummy_F As Boolean)
        Dim MobjBox As RectangleF
        Dim pxy() As Point, nPolyP() As Integer
        Dim HatchRect As RectangleF

        If MbjN = 0 Or TI.TileCode = enmTilePattern.Blank Then
            Exit Sub
        End If
        If Dummy_F = False Then
            MobjBox = attrData.Get_Kencode_Object_Circumscribed_Rectangle(Layernum, MultiObj(0))
            For i As Integer = 1 To MbjN - 1
                MobjBox = spatial.Get_Circumscribed_Rectangle(attrData.Get_Kencode_Object_Circumscribed_Rectangle(Layernum, MultiObj(i)), MobjBox)
            Next
        Else
            MobjBox = attrData.Get_Object_Circumscribed_Rectangle(Layernum, MultiObj(0))
            For i As Integer = 1 To MbjN - 1
                MobjBox = spatial.Get_Circumscribed_Rectangle(attrData.Get_Object_Circumscribed_Rectangle(Layernum, MultiObj(i)), MobjBox)
            Next
        End If
        Dim Pon As Integer = Get_Multi_Object_Boundary(attrData, Layernum, MbjN, MultiObj, pxy, nPolyP, Dummy_F)
        HatchRect = RectangleF.Intersect(MobjBox, attrData.TotalData.ViewStyle.ScrData.ScrRectangle)
        If Pon <> 0 Then
            Dim HatchRectS As Rectangle = attrData.TotalData.ViewStyle.ScrData.getSxSy(HatchRect)
            attrData.Draw_Tile_Region(g, HatchRectS, pxy, nPolyP, Pon, TI)
        End If
    End Sub
    ''' <summary>
    ''' ポリゴンオブジェクトの周囲の線の座標を取得
    ''' </summary>
    ''' <param name="Objn">オブジェクトの数</param>
    ''' <param name="ObjCode">レイヤ内のオブジェクトの位置またはオブジェクト番号</param>
    ''' <param name="Layernum"></param>
    ''' <param name="pxy">座標（戻り値）</param>
    ''' <param name="nPolyP">ポリゴン毎のポインタ（戻り値）</param>
    ''' <param name="Dummy_F">trueの場合はO_ObjNum_Code=MPObjの番号、Falseの場合はKencodeの位置</param>
    ''' <returns>ポリゴンの数を返す</returns>
    ''' <remarks></remarks>
    Private Shared Function Get_Multi_Object_Boundary(ByRef attrData As clsAttrData, ByVal Layernum As Integer,
                                ByVal Objn As Integer, ByRef ObjCode() As Integer,
                                   ByRef pxy() As Point, ByRef nPolyP() As Integer, ByVal Dummy_F As Boolean) As Integer

        Dim Arrange_LineCode(,) As Integer
        Dim Fringe() As clsMapData.Fringe_Line_Info
        Dim ELine() As clsMapData.EnableMPLine_Data

        Dim n As Integer = Gey_Multi_Object_OuterLineCode(attrData, Layernum, Objn, ObjCode, Dummy_F, ELine)

        Dim Pon As Integer = attrData.LayerData(Layernum).MapFileData.Boundary_Arrange_Sub(n, ELine, Arrange_LineCode, Fringe)

        If Pon <= 0 Then
            Return 0
        Else
            Dim NewPolyN As Integer
            Get_Boundary_XY(attrData, Layernum, pxy, Pon, NewPolyN, nPolyP, Arrange_LineCode, Fringe)
            Return NewPolyN
        End If
    End Function
    ''' <summary>
    ''' 1つの面形状オブジェクトのハッチ
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="ObjNum">レイヤ内のオブジェクトの位置</param>
    ''' <param name="TI"></param>
    ''' <remarks></remarks>
    Private Shared Sub HatchOnePolygonObject(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                             ByVal Layernum As Integer, ByVal ObjNum As Integer, ByRef TI As Tile_Property)

        Dim pxy() As Point, nPolyP() As Integer
        With TI
            Select Case .TileCode
                Case enmTilePattern.Blank
                Case enmTilePattern.Paint
                    PaintOnePolygonObject(g, attrData, Layernum, ObjNum, .Line.BasicLine.SolidLine.Color)
                Case Else
                    If attrData.LayerData(Layernum).Type = clsAttrData.enmLayerType.Mesh Then
                        ReDim nPolyP(0)
                        pxy = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(attrData.LayerData(Layernum).atrObject.atrObjectData(ObjNum).MeshPoint)
                        If pxy.Length = 5 Then
                            Dim rectS As Rectangle = attrData.TotalData.ViewStyle.ScrData.getSxSy(attrData.Get_Kencode_Object_Circumscribed_Rectangle(Layernum, ObjNum))
                            nPolyP(0) = 5
                            attrData.Draw_Tile_Region(g, rectS, pxy, nPolyP, 1, TI)
                        End If
                    Else
                        Dim Pon As Integer = Get_OnePolygonObject_Boundary(attrData, Layernum, ObjNum, pxy, nPolyP, False)
                        If Pon > 0 Then
                            Dim rectM As RectangleF = attrData.Get_Kencode_Object_Circumscribed_Rectangle(Layernum, ObjNum)
                            Dim rectS As Rectangle = attrData.TotalData.ViewStyle.ScrData.getSxSy(rectM)
                            attrData.Draw_Tile_Region(g, rectS, pxy, nPolyP, Pon, TI)
                        End If
                    End If
            End Select
        End With

    End Sub
    ''' <summary>
    ''' 指定された複数のオブジェクトの外側のラインコードを取得
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="Objn"></param>
    ''' <param name="ObjCode"></param>
    ''' <param name="Dummy_F">trueの場合はO_ObjNum_Code=MPObjの番号</param>
    ''' <param name="ELine">ライン番号（文字利地）</param>
    ''' <returns>ラインの数を返す</returns>
    ''' <remarks></remarks>
    Private Shared Function Gey_Multi_Object_OuterLineCode(ByRef attrData As clsAttrData, ByVal Layernum As Integer,
                                        ByVal Objn As Integer, ByRef ObjCode() As Integer, ByVal Dummy_F As Boolean, ByRef ELine() As clsMapData.EnableMPLine_Data) As Integer


        Dim Use_Line() As Integer
        Dim ALineN As Integer
        With attrData.LayerData(Layernum)
            ALineN = .MapFileData.Map.ALIN
            ReDim Use_Line(ALineN)
            For i As Integer = 0 To Objn - 1
                Dim Arrange_LineCode(,) As Integer
                Dim Fringe() As clsMapData.Fringe_Line_Info
                Dim Pon As Integer
                If Dummy_F = False Then
                    Pon = attrData.Boundary_Kencode_Arrange(Layernum, ObjCode(i), Arrange_LineCode, Fringe)
                Else
                    Pon = .MapFileData.Boundary_Arrange(ObjCode(i), .Time, Arrange_LineCode, Fringe)
                End If
                For j As Integer = 0 To UBound(Fringe)
                    Use_Line(Fringe(j).code) += 1
                Next
            Next
        End With
        ReDim ELine(ALineN)
        Dim n As Integer = 0
        For i As Integer = 0 To ALineN - 1
            If Use_Line(i) Mod 2 = 1 Then
                ELine(n).LineCode = i
                n += 1
            End If
        Next
        ReDim Preserve ELine(n)
        Return n
    End Function
    ''' <summary>
    ''' 階級区分モードの表示順序と表示の可否を返す
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <param name="Category_Array"></param>
    ''' <param name="D_Order"></param>
    ''' <param name="ShowF"></param>
    ''' <remarks></remarks>
    Private Shared Sub getDrawOrder_and_ShowF_ClassMode(ByRef attrData As clsAttrData, ByVal LayerNum As Integer, ByVal DataNum As Integer,
                                ByRef Category_Array() As Integer, ByRef D_Order() As Integer,
                                ByRef ShowF() As Boolean)
        With attrData
            Dim LayerShape As enmShape = .LayerData(LayerNum).Shape
            Dim Objn As Integer = .LayerData(LayerNum).atrObject.ObjectNum
            Dim SortModeF As Boolean = (LayerShape = enmShape.PointShape Or LayerShape = enmShape.LineShape)
            If attrData.SoloMode(LayerNum, DataNum) = enmSoloMode_Number.ClassMarkMode Then
                SortModeF = True
            End If
            Dim DrawOrderByValue As clsSortingSearch
            If SortModeF = True Then
                DrawOrderByValue = ClassMode_Point_Shape_DrawOrder(attrData, LayerNum, DataNum)
            End If
            Dim Missing_DataArray() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, DataNum)
            ReDim D_Order(Objn - 1)
            ReDim ShowF(Objn - 1)

            Dim PointLayerMark As Mark_Property = .LayerData(LayerNum).LayerModeViewSettings.PointLineShape.PointMark
            Dim pointR As Integer = .TotalData.ViewStyle.ScrData.Radius(PointLayerMark.WordFont.Body.Size, 1, 1)

            For i As Integer = 0 To Objn - 1
                Dim dod As Integer
                If SortModeF = True Then
                    Select Case .TotalData.ViewStyle.PointPaint_Order
                        Case clsAttrData.enmPointOnjectDrawOrder.ObjectOrder
                            dod = i
                        Case clsAttrData.enmPointOnjectDrawOrder.LowerToUpperCategory
                            If .LayerData(LayerNum).atrData.Data(DataNum).DataType = enmAttDataType.Normal Then
                                dod = DrawOrderByValue.DataPosition(i)
                            Else
                                dod = DrawOrderByValue.DataPositionRev(i)
                            End If
                        Case clsAttrData.enmPointOnjectDrawOrder.UpperToLowerCategory
                            If .LayerData(LayerNum).atrData.Data(DataNum).DataType = enmAttDataType.Normal Then
                                dod = DrawOrderByValue.DataPositionRev(i)
                            Else
                                dod = DrawOrderByValue.DataPosition(i)
                            End If
                    End Select
                Else
                    dod = i
                End If
                D_Order(i) = dod
                If .Check_Condition(LayerNum, dod) = True And _
                        (Missing_DataArray(dod) = False Or .TotalData.ViewStyle.Missing_Data.Print_Flag = True) Then
                    Select Case LayerShape
                        Case enmShape.PointShape
                            Dim CP As PointF = .LayerData(LayerNum).atrObject.atrObjectData(dod).Symbol
                            Dim OP As Point = .TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(CP)
                            ShowF(dod) = .Check_Screen_In(OP, pointR)
                        Case enmShape.LineShape, enmShape.PolygonShape
                            ShowF(dod) = .Check_screen_Kencode_In(LayerNum, dod)
                    End Select
                End If
            Next
            If .TotalData.ViewStyle.MapLegend.Base.ModeValueInScreenFlag = True Then
                ReDim Category_Array(Objn - 1)
                get_InScreenObjectData(attrData, LayerNum, DataNum, ShowF)
                For i As Integer = 0 To Objn - 1
                    If ShowF(i) = True Then
                        Category_Array(i) = .Get_Categoly(LayerNum, DataNum, i)
                    End If
                Next
            Else
                Category_Array = .Get_Categoly(LayerNum, DataNum)
            End If

        End With
    End Sub

    ''' <summary>
    ''' 記号モードの表示順序と表示の可否を返す
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <param name="mode"></param>
    ''' <param name="D_Order"></param>
    ''' <param name="ShowF"></param>
    ''' <param name="ObjP"></param>
    ''' <param name="Missing_DataArray"></param>
    ''' <param name="MV_Array"></param>
    ''' <remarks></remarks>
    Private Shared Sub getDrawOrder_and_ShowF_MarkMode(ByRef attrData As clsAttrData, ByVal LayerNum As Integer, ByVal DataNum As Integer,
                            ByVal mode As enmSoloMode_Number, ByRef D_Order() As Integer, ByRef ShowF() As Boolean,
                            ByRef ObjP() As Point, ByRef Missing_DataArray() As Boolean, ByRef MV_Array() As Double)
        With attrData
            Dim LayerShape As enmShape = .LayerData(LayerNum).Shape
            Dim Objn As Integer = .LayerData(LayerNum).atrObject.ObjectNum
            Missing_DataArray = attrData.Get_Missing_Value_DataArray(LayerNum, DataNum)
            Dim MK_Order As New clsSortingSearch
            MV_Array = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, DataNum)
            ReDim ObjP(Objn - 1)
            For i As Integer = 0 To Objn - 1
                Dim CP As PointF = .LayerData(LayerNum).atrObject.atrObjectData(i).Symbol
                ObjP(i) = .TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(CP)
            Next
            Select Case mode
                Case enmSoloMode_Number.MarkSizeMode
                    MK_Order.AddInit(VariantType.Double)
                    For i As Integer = 0 To Objn - 1
                        MK_Order.Add(Math.Abs(MV_Array(i)))
                    Next
                    MK_Order.AddEnd()
                Case enmSoloMode_Number.MarkBarMode
                    MK_Order.AddInit(VariantType.Integer)
                    For i As Integer = 0 To Objn - 1
                        MK_Order.Add(ObjP(i).Y)
                    Next
                    MK_Order.AddEnd()
            End Select

            Dim misR As Integer
            Dim normR As Integer
            Dim normSize As Size
            Dim maxv As Double
            Select Case mode
                Case enmSoloMode_Number.MarkSizeMode
                    misR = .Radius(attrData.TotalData.ViewStyle.Missing_Data.Mark.WordFont.Body.Size, 1, 1)
                    normR = .LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD.Mark.WordFont.Body.Size
                    maxv = Math.Max(Math.Abs(.Get_DataMax(LayerNum, DataNum)), Math.Abs(attrData.Get_DataMin(LayerNum, DataNum)))
                Case enmSoloMode_Number.MarkBarMode
                    misR = .Radius(.TotalData.ViewStyle.Missing_Data.MarkBar.WordFont.Body.Size, 1, 1)
                    With .LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
                        Dim w As Integer = attrData.Get_Length_On_Screen(.Width)
                        Dim h As Integer = attrData.Get_Length_On_Screen(.MaxHeight)
                        Dim wThree As Integer = 0
                        If .ThreeD = True Then
                            wThree = w \ 3
                        End If
                        normSize = New Size(w + wThree, h + wThree)
                    End With
                Case enmSoloMode_Number.MarkTurnMode
                    misR = .Radius(.TotalData.ViewStyle.Missing_Data.TurnMark.WordFont.Body.Size, 1, 1)
                    normR = .Radius(.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkTurnMD.Mark.WordFont.Body.Size, 1, 1)
                Case enmSoloMode_Number.MarkBlockMode
            End Select


            ReDim D_Order(Objn - 1)
            ReDim ShowF(Objn - 1)
            For i As Integer = 0 To Objn - 1
                Dim dod As Integer
                Select Case mode
                    Case enmSoloMode_Number.MarkSizeMode
                        dod = MK_Order.DataPositionRev(i)
                    Case enmSoloMode_Number.MarkBarMode
                        dod = MK_Order.DataPosition(i)
                    Case enmSoloMode_Number.MarkTurnMode
                        dod = i
                    Case enmSoloMode_Number.MarkBlockMode
                End Select
                D_Order(i) = dod
                If .Check_Condition(LayerNum, dod) = True And _
                        (Missing_DataArray(dod) = False Or .TotalData.ViewStyle.Missing_Data.Print_Flag = True) Then
                    Dim scinf As Boolean = False
                    Select Case mode
                        Case enmSoloMode_Number.MarkSizeMode
                            Select Case LayerShape
                                Case enmShape.PointShape, enmShape.PolygonShape
                                    If Missing_DataArray(dod) = True Then
                                        ObjP(dod) = getOverlayMarkPosition(attrData, ObjP(dod), misR)
                                        scinf = .Check_Screen_In(ObjP(dod), misR)
                                    Else
                                        If MV_Array(dod) <> 0 Then
                                            Dim r As Integer = attrData.Radius(normR, Math.Abs(MV_Array(dod)), maxv)
                                            ObjP(dod) = getOverlayMarkPosition(attrData, ObjP(dod), r)
                                            scinf = .Check_Screen_In(ObjP(dod), r)
                                        End If
                                    End If
                                Case enmShape.LineShape
                                    scinf = .Check_screen_Kencode_In(LayerNum, dod)
                            End Select
                        Case enmSoloMode_Number.MarkBarMode
                            If MV_Array(dod) > 0 Then
                                If Missing_DataArray(dod) = True Then
                                    scinf = .Check_Screen_In(ObjP(dod), misR)
                                Else
                                    Dim rect As Rectangle = New Rectangle(New Point(ObjP(dod).X - normSize.Width / 2, ObjP(dod).Y - normSize.Height), normSize)
                                    scinf = .Check_Screen_In(rect)
                                End If
                            End If
                        Case enmSoloMode_Number.MarkTurnMode
                            If Missing_DataArray(dod) = True Then
                                ObjP(dod) = getOverlayMarkPosition(attrData, ObjP(dod), misR)
                                scinf = .Check_Screen_In(ObjP(dod), misR)
                            Else
                                ObjP(dod) = getOverlayMarkPosition(attrData, ObjP(dod), normR)
                                scinf = .Check_Screen_In(ObjP(dod), normR)
                            End If
                    End Select
                    ShowF(dod) = scinf
                End If
            Next

            If .TotalData.ViewStyle.MapLegend.Base.ModeValueInScreenFlag = True Then
                If mode = enmSoloMode_Number.MarkSizeMode Or mode = enmSoloMode_Number.MarkBarMode Then
                    get_InScreenObjectData(attrData, LayerNum, DataNum, ShowF)
                End If
            End If
        End With

    End Sub

    ''' <summary>
    ''' 記号の大きさ、階級記号、記号の回転モードの重ね合わせの際の記号表示位置の移動
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="OP"></param>
    ''' <param name="r"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getOverlayMarkPosition(ByRef attrData As clsAttrData, ByVal OP As Point, ByVal r As Integer) As Point
        Dim newP As Point = OP
        If attrData.TempData.OverLay_Temp.OverLay_Printing_Flag = True And attrData.TotalData.TotalMode.OverLay.MarkModePosFixFlag = False Then
            With attrData.TempData.OverLay_Temp
                If .OverLay_EMode_N >= 2 Then
                    newP.X += ((.OverLay_EMode_Now Mod 2) * 2 - 1) * r
                    If .OverLay_EMode_N > 2 Then
                        '2つの場合はY座標変えず、3つ以上はずらす
                        newP.Y += ((.OverLay_EMode_Now \ 2) * 2 - 1) * r
                    End If
                End If
            End With
        End If
        Return newP
    End Function
    ''' <summary>
    ''' 階級区分モードのペイントモード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub PrintClassPaintMode(ByRef g As Graphics, ByRef prog As ToolStripProgressBar, ByRef attrData As clsAttrData,
                                           ByVal LayerNum As Integer, ByVal DataNum As Integer)

        Dim PolygonDummy_ClipSet_F As Boolean = attrData.LayerData(LayerNum).LayerModeViewSettings.PolygonDummy_ClipSet_F
        Dim Make_ClippingRegion2 As Region
        Dim Original_ClippingRegion2 As Region
        Dim Clip_F2 As Boolean = False
        Dim LayerShape As enmShape = attrData.LayerData(LayerNum).Shape
        If PolygonDummy_ClipSet_F = True Then
            If LayerShape <> enmShape.PolygonShape Then
                Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
            End If
            Clip_F2 = ClippingRegion_ObjectBoundary_set(g, attrData, LayerNum, False, True, Make_ClippingRegion2, Original_ClippingRegion2)
            If LayerShape <> enmShape.PolygonShape Then
                Vector_Object_Boundary(g, attrData, LayerNum)
                Vector_Dummy_Boundary(g, attrData, LayerNum, (Clip_F2 = False), True)
            End If
        Else
            If LayerShape <> enmShape.PolygonShape Then
                Vector_Object_Boundary(g, attrData, LayerNum)
                Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
            End If
        End If


        Dim pointR As Integer
        With attrData.LayerData(LayerNum)
            Dim PointLayerMark As Mark_Property

            If LayerShape = enmShape.PointShape Then
                Vector_Connect_CenterP_To_SymbolPoint(g, attrData, LayerNum)
                PointLayerMark = .LayerModeViewSettings.PointLineShape.PointMark
                With attrData.TotalData.ViewStyle.ScrData
                    pointR = .Radius(PointLayerMark.WordFont.Body.Size, 1, 1)
                End With
            End If

            prog.Maximum = .atrObject.ObjectNum - 1
            Dim ProgInterval As Integer = .atrObject.ObjectNum \ 10
            If ProgInterval < 5 Then
                ProgInterval = 5
            End If
            '表示順序と表示の可否
            Dim D_Order() As Integer
            Dim ShowF() As Boolean
            Dim Category_Array() As Integer
            getDrawOrder_and_ShowF_ClassMode(attrData, LayerNum, DataNum, Category_Array, D_Order, ShowF)

            '描画
            For i As Integer = 0 To .atrObject.ObjectNum - 1
                If i Mod ProgInterval = 0 Then
                    prog.Value = i
                End If
                Dim DrawOrder As Integer = D_Order(i)
                If ShowF(DrawOrder) = True Then
                    Dim colpos As Integer = Category_Array(DrawOrder)
                    Dim col As colorARGB
                    If colpos <> -1 Then
                        col = .atrData.Data(DataNum).SoloModeViewSettings.Class_Div(colpos).PaintColor
                    End If
                    attrData.TempData.ObjectPrintedCheckFlag(LayerNum)(DrawOrder) = True
                    Dim CP As PointF = .atrObject.atrObjectData(DrawOrder).Symbol
                    Dim OP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(CP)
                    Select Case LayerShape
                        Case enmShape.PointShape
                            PointLayerMark.Tile.TileCode = 8
                            If colpos = -1 Then
                                PointLayerMark.Tile = attrData.TotalData.ViewStyle.Missing_Data.PaintTile
                            Else
                                PointLayerMark.Tile.Line.BasicLine.SolidLine.Color = col
                                PointLayerMark.WordFont.Body.Color = col
                            End If
                            attrData.Draw_Mark(g, OP, pointR, PointLayerMark)
                            Dim OVP As Point = OP
                            OVP.Y += pointR
                            ObjectValue_and_Name_Print(g, attrData, OVP, enmVerticalAlignment.Top, LayerNum, DataNum, DrawOrder)
                        Case enmShape.LineShape
                            Dim penw As Single = .LayerModeViewSettings.PointLineShape.LineWidth
                            Dim LineShapeLine As Line_Property
                            If colpos = -1 Then
                                LineShapeLine = attrData.TotalData.ViewStyle.Missing_Data.LineShape
                            Else
                                LineShapeLine = clsBase.Line
                                LineShapeLine.Set_Same_ColorWidth_to_LinePat(col, penw)
                            End If
                            LineShapeLine.Edge_Connect_Pattern = .LayerModeViewSettings.PointLineShape.LineEdge

                            If .Type = clsAttrData.enmLayerType.Mesh Then
                                Dim pxy() As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(.atrObject.atrObjectData(DrawOrder).MeshPoint)
                                attrData.Draw_Line(g, LineShapeLine, 5, pxy)
                            Else
                                Dim ELine() As clsMapData.EnableMPLine_Data
                                Dim n As Integer = attrData.Get_Enable_KenCode_MPLine(ELine, LayerNum, DrawOrder)
                                For j As Integer = 0 To n - 1
                                    Dim pxy() As Point
                                    Dim np As Integer = Get_PointXY_by_LineCode(attrData, LayerNum, ELine(j).LineCode, pxy)
                                    attrData.Draw_Line(g, LineShapeLine, np, pxy)
                                Next
                            End If
                            ObjectValue_and_Name_Print(g, attrData, OP, enmVerticalAlignment.Center, LayerNum, DataNum, DrawOrder)
                        Case enmShape.PolygonShape
                            If colpos = -1 Then
                                HatchOnePolygonObject(g, attrData, LayerNum, DrawOrder, attrData.TotalData.ViewStyle.Missing_Data.PaintTile)
                            Else
                                Dim f As Boolean = PaintOnePolygonObject(g, attrData, LayerNum, DrawOrder, col)
                            End If
                    End Select
                End If
            Next

            If LayerShape = enmShape.PolygonShape Then
                Vector_Object_Boundary(g, attrData, LayerNum)
                Class_Category_Boundary(g, attrData, LayerNum, DataNum)
                For i As Integer = 0 To .atrObject.ObjectNum - 1
                    Dim DrawOrder As Integer = D_Order(i)
                    If ShowF(DrawOrder) = True Then
                        Dim CP As PointF = .atrObject.atrObjectData(DrawOrder).Symbol
                        Dim OP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(CP)
                        ObjectValue_and_Name_Print(g, attrData, OP, enmVerticalAlignment.Center, LayerNum, DataNum, DrawOrder)
                    End If
                Next
            End If

            If Clip_F2 = True Then
                '作成したクリッピングリージョンを削除
                Vector_Dummy_Boundary(g, attrData, LayerNum, False, True)
                g.Clip = Original_ClippingRegion2
                Make_ClippingRegion2.Dispose()
                Vector_Dummy_Boundary(g, attrData, LayerNum, True, False)
            Else
                Vector_Dummy_Boundary(g, attrData, LayerNum, True, True)
            End If
        End With
    End Sub
    ''' <summary>
    ''' レイヤのオブジェクトの値を記号表示位置の中央に表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Shared Sub ObjectValue_And_Name_Print_byLayer(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal DataNum As Integer)
        If attrData.TotalData.ViewStyle.ValueShow.ValueVisible = True Or attrData.TotalData.ViewStyle.ValueShow.ObjNameVisible = True Then
            For i As Integer = 0 To attrData.LayerData(Layernum).atrObject.ObjectNum - 1
                If attrData.Check_Condition(Layernum, i) = True Then
                    Dim CP As PointF = attrData.LayerData(Layernum).atrObject.atrObjectData(i).Symbol
                    Dim OP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(CP)
                    ObjectValue_and_Name_Print(g, attrData, OP, enmVerticalAlignment.Center, Layernum, DataNum, i)
                End If
            Next
        End If
    End Sub
    ''' <summary>
    ''' データ値／オブジェクト名表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Pos"></param>
    ''' <param name="VerticalAlignment">Top/Centerのみ</param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <param name="ObjectNumber"></param>
    ''' <remarks></remarks>
    Private Shared Sub ObjectValue_and_Name_Print(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Pos As Point, ByVal VerticalAlignment As enmVerticalAlignment,
                                                  ByVal Layernum As Integer, ByVal DataNum As Integer, ByVal ObjectNumber As Integer)
        Dim vpos As enmVerticalAlignment
        With attrData.TotalData.ViewStyle.ValueShow
            Select Case VerticalAlignment
                Case enmVerticalAlignment.Top
                    Dim pos2 As Point = Pos
                    If .ObjNameVisible = True Then
                        Dim name As String = attrData.Get_KenObjName(Layernum, ObjectNumber)
                        attrData.Draw_Print(g, name, Pos, .ObjNameFont, enmHorizontalAlignment.Center, enmVerticalAlignment.Top)
                        pos2.Y += attrData.Get_Length_On_Screen(.ObjNameFont.Body.Size)
                    End If
                    If .ValueVisible = True Then
                        Dim V As String = attrData.Get_Data_Value(Layernum, DataNum, ObjectNumber, "欠損値")
                        If attrData.Get_DataType(Layernum, DataNum) = enmAttDataType.Normal Then
                            If .DecimalSepaF = True Then
                                V = clsGeneric.Figure_Using(Val(V), .DecimalNumber)
                            End If
                        End If
                        attrData.Draw_Print(g, V, pos2, .ValueFont, enmHorizontalAlignment.Center, enmVerticalAlignment.Top)
                    End If

                Case enmVerticalAlignment.Center
                    If .ObjNameVisible = True Then
                        Dim opos As enmVerticalAlignment = enmVerticalAlignment.Center
                        If .ValueVisible = True Then
                            opos = enmVerticalAlignment.Bottom
                        End If
                        Dim name As String = attrData.Get_KenObjName(Layernum, ObjectNumber)
                        attrData.Draw_Print(g, name, Pos, .ObjNameFont, enmHorizontalAlignment.Center, opos)
                    End If
                    If .ValueVisible = True Then
                        Dim opos As enmVerticalAlignment = enmVerticalAlignment.Center
                        If .ObjNameVisible = True Then
                            opos = enmVerticalAlignment.Top
                        End If
                        Dim V As String = attrData.Get_Data_Value(Layernum, DataNum, ObjectNumber, "欠損値")
                        If attrData.Get_DataType(Layernum, DataNum) = enmAttDataType.Normal Then
                            If .DecimalSepaF = True Then
                                V = clsGeneric.Figure_Using(Val(V), .DecimalNumber)
                            End If
                        End If
                        attrData.Draw_Print(g, V, Pos, .ValueFont, enmHorizontalAlignment.Center, opos)
                    End If
            End Select

        End With

    End Sub
    ''' <summary>
    ''' 代表点と記号表示位置を線で結ぶ
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <remarks></remarks>
    Private Shared Sub Vector_Connect_CenterP_To_SymbolPoint(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer)

        If attrData.TotalData.ViewStyle.SymbolLine.Visible = False Then
            Exit Sub
        End If
        If attrData.TempData.OverLay_Temp.OverLay_Printing_Flag = True And attrData.TempData.OverLay_Temp.OverLay_EMode_N >= 2 Then
            Exit Sub
        End If
        With attrData
            For i As Integer = 0 To .LayerData(Layernum).atrObject.ObjectNum - 1
                Dim cp As PointF = attrData.LayerData(Layernum).atrObject.atrObjectData(i).CenterPoint
                Dim sp As PointF = .LayerData(Layernum).atrObject.atrObjectData(i).Symbol
                If cp.Equals(sp) = False Then
                    With .TotalData.ViewStyle
                        Dim cp2 As Point = .ScrData.Get_SxSy_With_3D(cp)
                        Dim sp2 As Point = .ScrData.Get_SxSy_With_3D(sp)
                        attrData.Draw_Line(g, .SymbolLine.Line, cp2, sp2)
                    End With
                End If
            Next
        End With
    End Sub
    ''' <summary>
    ''' 階級区分モードで点・線オブジェクトの場合で、オブジェクトの描画順で使用するソートクラスを作成する
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function ClassMode_Point_Shape_DrawOrder(ByRef attrData As clsAttrData, ByVal Layernum As Integer,
                                            ByVal DataNum As Integer) As clsSortingSearch

        Dim en_sort() As Double
        Dim s As New clsSortingSearch(VariantType.Double)

        If attrData.TotalData.ViewStyle.PointPaint_Order <> clsAttrData.enmPointOnjectDrawOrder.ObjectOrder Then
            en_sort = attrData.Get_Data_Cell_Array_With_MissingValue(Layernum, DataNum)
            s.AddRange(en_sort.Length, en_sort)
        End If
        Return s
    End Function

    ''' <summary>
    ''' ダミーオブジェクト・ダミーオブジェクトグループを描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="Polygon_F">ポリゴン形状を表示する場合true</param>
    ''' <param name="nonPolygon_F">非ポリゴン形状を表示する場合true</param>
    ''' <remarks></remarks>
    Private Shared Sub Vector_Dummy_Boundary(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                             ByVal Layernum As Integer, ByVal Polygon_F As Boolean, ByVal nonPolygon_F As Boolean)


        If attrData.LayerData(Layernum).DummyGroup.Count > 0 Then
            If Polygon_F = True Then
                Vector_DummyGroup_Draw(g, attrData, enmShape.PolygonShape, Layernum)
            End If
            If nonPolygon_F = True Then
                Vector_DummyGroup_Draw(g, attrData, enmShape.NotDeffinition, Layernum)
                Vector_DummyGroup_Draw(g, attrData, enmShape.LineShape, Layernum)
                Vector_DummyGroup_Draw(g, attrData, enmShape.PointShape, Layernum)
            End If
        End If

        With attrData.LayerData(Layernum)
            For i As Integer = 0 To .Dummy.Count - 1
                Dim c As Integer = .Dummy.DummyObj(i).code
                With .MapFileData.MPObj(c)
                    If (.Shape = enmShape.PolygonShape And Polygon_F = True) Or (.Shape <> enmShape.PolygonShape And nonPolygon_F = True) Then
                        Vector_Dummy_Draw(g, attrData, c, Layernum)
                    End If
                End With
            Next
        End With

    End Sub
    ''' <summary>
    ''' ダミーオブジェクトグループの描画。描画順は設定したグループ順
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="SHP">描画する形状の指定</param>
    ''' <param name="Layernum"></param>
    ''' <remarks></remarks>
    Private Shared Sub Vector_DummyGroup_Draw(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                              ByVal SHP As enmShape, ByVal Layernum As Integer)


        With attrData.LayerData(Layernum)
            For i As Integer = 0 To .DummyGroup.Count - 1
                Dim ok As Integer = .DummyGroup.DummyObjG(i)
                If .MapFileData.ObjectKind(ok).Shape = SHP Then
                    Dim temp() As Integer
                    Dim tnp As Integer = .MapFileData.Get_Objects_by_Group(ok, temp, .Time)
                    For j As Integer = 0 To tnp - 1
                        Vector_Dummy_Draw(g, attrData, temp(j), Layernum)
                    Next
                End If
            Next

        End With
    End Sub
    ''' <summary>
    ''' ダミーオブジェクトの描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="code">オブジェクト番号</param>
    ''' <param name="Layernum"></param>
    ''' <remarks></remarks>
    Private Shared Sub Vector_Dummy_Draw(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                         ByVal code As Integer, ByVal Layernum As Integer)


        If attrData.Check_Screen_Objcode_In(Layernum, code) = True Then
            With attrData.LayerData(Layernum)
                If .MapFileData.MPObj(code).Shape = enmShape.PointShape Then
                    Dim ok As Integer = .MapFileData.MPObj(code).Kind
                    If .MapFileData.ObjectKind(ok).Shape = enmShape.PointShape Then
                        Dim CP As PointF
                        .MapFileData.Get_Enable_CenterP(CP, code, .Time)
                        Dim OP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(CP)
                        Dim MK As Mark_Property = getPointDummyMark(attrData, .MapFileName, .MapFileData.ObjectKind(ok).Name)
                        Dim r As Integer = attrData.Radius(MK.WordFont.Body.Size, 1, 1)
                        attrData.Draw_Mark(g, OP, r, MK)
                        If attrData.TotalData.ViewStyle.MapLegend.Line_DummyKind.Dummy_Point_Visible = True Then
                            attrData.AddPointObjectKindUsed(attrData.LayerData(Layernum).MapFileName, ok, MK)
                        End If
                    End If
                Else
                    Vector_Boundary_Draw(g, attrData, Layernum, code, True)
                End If
            End With
        End If

    End Sub
    ''' <summary>
    ''' ダミー点オブジェクトの記号取得
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="MapFIleName">地図ファイル</param>
    ''' <param name="ObjectGroupName">オブジェクトグループ名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getPointDummyMark(ByRef attrData As clsAttrData, ByVal MapFIleName As String, ByVal ObjectGroupName As String) As Mark_Property
        With attrData.TotalData.ViewStyle
            Dim obk As clsAttrData.strDummyObjectPointMark_Info() = .DummyObjectPointMark(MapFIleName)
            For i As Integer = 0 To obk.Length - 1
                If obk(i).ObjectKindName = ObjectGroupName Then
                    Return obk(i).Mark
                End If
            Next
        End With
    End Function
    ''' <summary>
    ''' 境界線描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <remarks></remarks>
    Private Shared Sub Vector_Object_Boundary(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer)

        Dim Blanc_Map_F As Boolean = False
        With attrData.LayerData(Layernum)
            If (.Shape = enmShape.LineShape And Blanc_Map_F = False) Or
                .Shape = enmShape.PointShape Or .Type = clsAttrData.enmLayerType.Trip Then
            Else
                For i As Integer = 0 To .atrObject.ObjectNum - 1
                    Dim vf As Boolean = False
                    If attrData.TotalData.ViewStyle.InVisibleObjectBoundaryF = True Then
                        vf = True
                    Else
                        vf = attrData.Check_Condition(Layernum, i)
                    End If
                    If vf = True Then
                        Vector_Boundary_Draw(g, attrData, Layernum, i, False)
                    End If
                Next
            End If

        End With

    End Sub
    Private Shared Sub Vector_Boundary_Draw(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                            ByVal Layernum As Integer, ByVal Obj_Num_code As Integer,
                                            ByVal Dummy_F As Boolean)

        Dim ELine() As clsMapData.EnableMPLine_Data

        Dim pxy() As Point
        Dim n As Integer
        If Dummy_F = True Then
            If attrData.Check_Screen_Objcode_In(Layernum, Obj_Num_code) = False Then
                Return
            Else
                With attrData.LayerData(Layernum)
                    n = .MapFileData.Get_EnableMPLine(ELine, Obj_Num_code, .Time)
                End With
            End If
        Else
            If attrData.Check_screen_Kencode_In(Layernum, Obj_Num_code) = False Then
                Return
            End If
            If attrData.LayerData(Layernum).Type = clsAttrData.enmLayerType.Mesh Then
                pxy = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(attrData.LayerData(Layernum).atrObject.atrObjectData(Obj_Num_code).MeshPoint)
                attrData.Draw_Line(g, attrData.TotalData.ViewStyle.MeshLine, pxy.Length, pxy)
                Return
            Else
                n = attrData.Get_Enable_KenCode_MPLine(ELine, Layernum, Obj_Num_code)
            End If
        End If
        Dim MPFileNapa As String = attrData.LayerData(Layernum).MapFileName
        For j As Integer = 0 To n - 1
            Dim lc As Integer = ELine(j).LineCode
            Dim lcc As Integer = ELine(j).Kind
            Dim PatNum As Integer = attrData.LayerData(Layernum).ObjectGroupRelatedLine(lc)
            Dim Lpat As Line_Property = attrData.LayerData(Layernum).MapFileData.LineKind(lcc).ObjGroup(PatNum).Pattern
            If Lpat.Check_Line_PrintPattern = True And attrData.MpLineDrawn(MPFileNapa, lc) = False Then
                Dim ln As Integer = Get_PointXY_by_LineCode(attrData, Layernum, lc, pxy)
                If ln > 0 Then
                    attrData.Draw_Line(g, Lpat, ln, pxy)
                End If
                attrData.MpLineDrawn(MPFileNapa, lc) = True
                attrData.LineKindUseChecked(MPFileNapa, lcc, PatNum) = True
            End If
        Next

    End Sub
    Private Shared Function PaintOnePolygonObject(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal ObjNum As Integer, ByVal ocol As colorARGB) As Boolean

        Dim pxy() As Point, nPolyP() As Integer

        Dim Pon As Integer = Get_OnePolygonObject_Boundary(attrData, Layernum, ObjNum, pxy, nPolyP, False)
        If Pon > 0 Then
            clsDraw.DrawPolyPolygon(g, Pon, pxy, nPolyP, ocol.getColor)
            PaintOnePolygonObject = True
        Else
            PaintOnePolygonObject = False
        End If

    End Function
    ''' <summary>
    ''' ポリゴンオブジェクトの周囲の線の座標を取得
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="O_ObjNum_Code"></param>
    ''' <param name="pxy">座標（戻り値）</param>
    ''' <param name="nPolyP">ポリゴン毎の座標数（戻り値）</param>
    ''' <param name="Dummy_F">trueの場合はO_ObjNum_Code=MPObjの番号、Falseの場合はO_ObjNum_Code=Kencodeの位置</param>
    ''' <returns>ポリゴンの数を返す</returns>
    ''' <remarks></remarks>
    Private Shared Function Get_OnePolygonObject_Boundary(ByRef attrData As clsAttrData, ByVal Layernum As Integer, ByVal O_ObjNum_Code As Integer,
                                ByRef pxy() As Point, ByRef nPolyP() As Integer, ByVal Dummy_F As Boolean) As Integer

        Dim Pon As Integer
        Dim Arrange_LineCode(,) As Integer
        Dim Fringe() As clsMapData.Fringe_Line_Info

        If Dummy_F = False Then
            If attrData.LayerData(Layernum).Type = clsAttrData.enmLayerType.Mesh Then
                pxy = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(attrData.LayerData(Layernum).atrObject.atrObjectData(O_ObjNum_Code).MeshPoint)
                ReDim nPolyP(0)
                nPolyP(0) = pxy.Length
                If pxy.Length >= 4 Then
                    'メッシュオブジェクトで計算誤差による白抜けが入るのを防ぐ処置
                    pxy(1).X += 1
                    pxy(2).X += 1
                    pxy(2).Y += 1
                    pxy(3).Y += 1
                End If
                Return 1
            Else
                Pon = attrData.Boundary_Kencode_Arrange(Layernum, O_ObjNum_Code, Arrange_LineCode, Fringe)
            End If
        Else
            With attrData.LayerData(Layernum)
                Pon = .MapFileData.Boundary_Arrange(O_ObjNum_Code, .Time, Arrange_LineCode, Fringe)
            End With
        End If

        If Pon <= 0 Then
            Return 0
        Else
            Dim NewPolyN As Integer
            Get_Boundary_XY(attrData, Layernum, pxy, Pon, NewPolyN, nPolyP, Arrange_LineCode, Fringe)
            Return NewPolyN
        End If

    End Function
    ''' <summary>
    ''' '指定されたラインをポリゴン化したXY座標を返す
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="pxy">座標（戻り値）</param>
    ''' <param name="Pon">元のポリゴン数</param>
    ''' <param name="NewPolyN">新しいポリゴン数（戻り値）</param>
    ''' <param name="nPolyP">ポリゴン毎の座標数（戻り値）</param>
    ''' <param name="Arrange_LineCode"></param>
    ''' <param name="Fringe"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Sub Get_Boundary_XY(ByRef attrData As clsAttrData, ByVal Layernum As Integer,
                ByRef pxy() As Point, ByVal Pon As Integer, ByRef NewPolyN As Integer, ByRef nPolyP() As Integer, _
                ByRef Arrange_LineCode(,) As Integer, ByRef Fringe() As clsMapData.Fringe_Line_Info)

        ReDim nPolyP(Pon - 1)
        Dim p As Integer = 0
        For i As Integer = 0 To UBound(Fringe)
            p += attrData.LayerData(Layernum).MapFileData.MPLine(Fringe(i).code).NumOfPoint
        Next
        ReDim pxy(p - 1)
        Dim np As Integer = 0

        Dim ponpon As Integer = 0
        For i As Integer = 0 To Pon - 1
            Dim pxytemp() As Point
            Dim np2 As Integer = 0
            Dim f As Boolean = True
            For j As Integer = 0 To Arrange_LineCode(i, 1) - 1
                Dim revf As Boolean
                If Fringe(Arrange_LineCode(i, 0) + j).Direction = 1 Then
                    revf = False
                Else
                    revf = True
                End If
                Dim L As Integer = Fringe(Arrange_LineCode(i, 0) + j).code
                Dim ntp As Integer = Get_PointXY_by_LineCode(attrData, Layernum, L, pxytemp, revf)
                If ntp = 0 And Arrange_LineCode(i, 1) = 1 Then
                    Pon -= 1
                    f = False
                Else
                    If UBound(pxy) < np + ntp - 1 Then
                        ReDim Preserve pxy(np + ntp)
                    End If
                    '座標配列をコピーする
                    pxytemp.CopyTo(pxy, np)
                    np += ntp
                    np2 += ntp
                End If
            Next
            If f = True Then
                nPolyP(ponpon) = np2
                ponpon += 1
            End If
        Next
        NewPolyN = ponpon


    End Sub
    ''' <summary>
    ''' 指定したラインコードの座標を変換して取得
    ''' </summary>
    ''' <param name="LCode"></param>
    ''' <param name="pxy"></param>
    ''' <param name="ReverseGetF">Trueの場合は座標列を反転させて取得</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_PointXY_by_LineCode(ByRef attrData As clsAttrData, ByVal Layernum As Integer,
                                                    ByVal LCode As Integer, ByRef pxy() As Point,
                                                    Optional ByVal ReverseGetF As Boolean = False) As Integer


        Dim md As Integer = 0
        Dim mpfilename As String = attrData.LayerData(Layernum).MapFileName

        With attrData.TotalData.ViewStyle
            'ループ間引き
            If .SouByou.Auto = True Or (.SouByou.LoopAreaF = True And .SouByou.LoopSize <> 0) Then
                If attrData.TempData.SoubyouLayerEnable(Layernum) = True Then
                    Dim men As Single = attrData.TempData.SoubyouLoopLineArea.Item(Layernum)(LCode)
                    If men > 0 Then
                        Dim Check_S As Single
                        If .SouByou.Auto = True Then
                            Check_S = attrData.TempData.SoubyouLoopAreaCriteria
                        Else
                            If md = 0 Then
                                Check_S = .SouByou.LoopSize
                            Else
                                '画面の%で面積チェックだが、使われていない
                                Check_S = .ScrData.STDWsize ^ 2 / 2 * .SouByou.LoopSize / 100
                            End If
                        End If
                        If men < Check_S Then
                            Return 0
                        End If
                    End If
                End If
            End If

        End With

        If attrData.Get_MPSubLineXY(mpfilename, LCode, pxy, ReverseGetF) = False Then
            'まだ計算していないライン
            Dim np As Integer = attrData.LayerData(Layernum).MapFileData.MPLine(LCode).NumOfPoint
            ReDim pxy(np - 1)
            Dim spxy() As PointF
            Dim spxy2() As PointF
            spxy = attrData.LayerData(Layernum).MapFileData.MPLine(LCode).PointSTC.Clone
            With attrData.TotalData.ViewStyle
                If .SouByou.Auto = True Or (.SouByou.ThinningPrint_F = True And .SouByou.PointInterval <> 0) Then
                    If attrData.TempData.SoubyouLayerEnable(Layernum) = True Then
                        If .SouByou.Auto = True Then
                            np = attrData.LayerData(Layernum).MapFileData.Smoothing_Line(spxy, np, spxy2, attrData.TempData.SoubyouLinePointIntervalCriteria)
                            spxy = spxy2.Clone
                        ElseIf .SouByou.ThinningPrint_F = True Then
                            np = attrData.LayerData(Layernum).MapFileData.Smoothing_Line(spxy, np, spxy2, .SouByou.PointInterval)
                            spxy = spxy2.Clone
                        End If
                    End If
                End If
            End With

            If attrData.TotalData.ViewStyle.SouByou.Spline_F = True Then
                If ReverseGetF = True Then
                    ReDim spxy2(np - 1)
                    For i As Integer = 0 To np - 1
                        spxy2(i) = spxy(np - 1 - i)
                    Next
                    pxy = clsSpline.Spline_Get(0, np, spxy2, 0.3, attrData.TotalData.ViewStyle.ScrData)
                Else
                    pxy = clsSpline.Spline_Get(0, np, spxy, 0.3, attrData.TotalData.ViewStyle.ScrData)
                End If
            Else
                pxy = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(np, spxy, ReverseGetF)
            End If
            attrData.Set_MPSubLineXY(mpfilename, LCode, pxy, ReverseGetF)

        End If

        Return pxy.Length
    End Function
    ''' <summary>
    ''' 出力画面の地図領域を、指定したサイズと位置に変更する
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="FormP">出力画面</param>
    ''' <param name="PrintWindowSize">変更後のサイズ</param>
    ''' <param name="position">0:位置変更せず 1:画面の中央 2:画面の左上</param>
    ''' <remarks></remarks>
    Public Shared Sub Change_Mapscreen_Size_and_Position(ByRef attrData As clsAttrData, ByRef FormP As frmPrint, ByVal PrintWindowSize As Size, ByVal position As Integer)
        '
        FormP.Visible = False
        FormP.ClientSize = New Size(PrintWindowSize.Width, PrintWindowSize.Height + FormP.StatusStrip.Height + FormP.MenuStrip.Height)

        With attrData.TotalData.ViewStyle.ScrData.frmPrint_FormSize
            Dim s As System.Windows.Forms.Screen = System.Windows.Forms.Screen.FromControl(FormP)
            Select Case position
                Case 0
                Case 1
                    .X = s.Bounds.Width / 2 - FormP.Width / 2
                    .Y = s.Bounds.Height / 2 - FormP.Height / 2
                Case 2
                    .X = 0
                    .Y = 0
            End Select
            .Width = PrintWindowSize.Width
            .Height = PrintWindowSize.Height
            FormP.Left = .Left
            FormP.Top = .Top
            FormP.Visible = True
        End With

    End Sub

    ''' <summary>
    ''' 表示範囲のデータで階級区分などを設定
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <param name="ShowF"></param>
    ''' <remarks></remarks>
    Private Shared Sub get_InScreenObjectData(ByRef attrData As clsAttrData, ByVal LayerNum As Integer, ByVal DataNum As Integer, ByRef ShowF() As Boolean)

        If attrData.TempData.OverLay_Temp.OverLay_Printing_Flag = True Then
            Return
        End If

        Dim Missing_DataArray() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, DataNum)
        Dim MV_Array() As Double = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, DataNum)
        Dim Objn As Integer = attrData.LayerData(LayerNum).atrObject.ObjectNum
        Dim inObjN As Integer = 0
        Dim maxV As Double
        Dim minV As Double
        Dim Add As Double = 0
        Dim Add2 As Double = 0
        Dim div_num As Integer
        Dim BeforeDecimal As Integer = 0
        Dim AfterDecimal As Integer = 0
        Dim divMethos As enmDivisionMethod
        Dim inObjectList(Objn - 1) As Integer

        With attrData.LayerData(LayerNum).atrData.Data(DataNum)
            maxV = .Statistics.Min
            minV = .Statistics.Max
            div_num = .SoloModeViewSettings.Div_Num
            divMethos = .SoloModeViewSettings.Div_Method
        End With

        With attrData.TempData.ModeValueInScreen_Stac
            .LayerNum = LayerNum
            .DataNum = DataNum
            ReDim .divValue(div_num - 1)
            For i As Integer = 0 To div_num - 1
                .divValue(i) = attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.Class_Div(i).Value
            Next
            .MarkSize_MaxValueMode = attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD.MaxValueMode
            .MarkSize_MaxValue = attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD.MaxValue
            .MarkBar_MaxValueMode = attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD.MaxValueMode
            .MarkBar_MaxValue = attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD.MaxValue
        End With


            Dim SortV As New clsSortingSearch(VariantType.Double)
            For i As Integer = 0 To Objn - 1
                If ShowF(i) = True And Missing_DataArray(i) = False Then
                    Dim v As Double = MV_Array(i)
                    SortV.Add(v)
                    inObjectList(inObjN) = i
                    Add += v
                    Add2 += +v * v
                    maxV = Math.Max(maxV, v)
                    minV = Math.Min(minV, v)
                    Dim b As Integer, a As Integer
                    clsGeneric.Figure_Arrange(v, b, a)
                    BeforeDecimal = Math.Max(BeforeDecimal, b)
                    AfterDecimal = Math.Max(AfterDecimal, a)
                    inObjN += 1
                End If
            Next
            SortV.AddEnd()
            Dim md As enmSoloMode_Number = attrData.SoloMode(LayerNum, DataNum)
            Select Case md
                Case enmSoloMode_Number.ClassPaintMode, enmSoloMode_Number.ClassHatchMode, enmSoloMode_Number.ClassMarkMode, enmSoloMode_Number.ClassODMode
                    If md = enmSoloMode_Number.ClassODMode Then
                        If attrData.LayerData(LayerNum).Shape <> enmShape.LineShape Then
                            Return
                        End If
                    End If
                    Dim Ave = Add / inObjN
                    Dim sa As Double = maxV - minV
                    Dim STD As Double = Math.Sqrt(Add2 / inObjN - Ave * Ave)
                    Dim Div_Value(div_num - 1) As Double
                    Select Case divMethos
                        Case enmDivisionMethod.Free
                            Return
                        Case enmDivisionMethod.Quantile '分位数
                            Dim divvStp As Single = SortV.NumofData / div_num
                            Dim i As Integer = 0
                            Dim divv As Single = divvStp
                            Do
                                Div_Value(i) = SortV.DataPositionRevValue_double(Int(divv) - 1)
                                divv += divvStp
                                i += 1
                            Loop While divv < SortV.NumofData
                        Case enmDivisionMethod.AreaQuantile
                            '面積分位数
                            Dim Mense(inObjN - 1) As Single
                            Dim AddMense As Single = 0
                            For i As Integer = 0 To inObjN - 1
                                Mense(i) = attrData.GetObjMenseki(LayerNum, inObjectList(i))
                                AddMense += Mense(i)
                            Next
                            Dim n As Integer = 0

                            Dim Addv As Single = 0
                            Dim divvStp As Single = AddMense / div_num
                            Dim divv As Single = divvStp
                            For i As Integer = 0 To SortV.NumofData - 1
                                Dim j As Integer = SortV.DataPositionRev(i)
                                Addv += Mense(j)
                                If Addv >= divv Then
                                    Div_Value(n) = SortV.DataPositionRevValue_double(i)
                                    divv += divvStp
                                    n += 1
                                    Addv = Addv - Mense(j)
                                    i = i - 1
                                End If
                            Next
                        Case enmDivisionMethod.StandardDeviation '標準偏差
                            If inObjN > 1 Then
                                Div_Value(0) = Ave + STD
                                Div_Value(1) = Ave + STD / 2
                                Div_Value(2) = Ave
                                Div_Value(3) = Ave - STD / 2
                                Div_Value(4) = Ave - STD
                            End If
                            For i As Integer = 0 To 4
                                Div_Value(i) = Val(clsGeneric.Figure_Using(Div_Value(i), AfterDecimal + 1))
                            Next
                        Case enmDivisionMethod.EqualInterval '等間隔
                            Dim a As Double = sa / div_num
                            For i As Integer = 0 To div_num - 1
                                Div_Value(i) = maxV - a * (i + 1)
                            Next
                            For i As Integer = 0 To div_num - 1
                                Div_Value(i) = Val(clsGeneric.Figure_Using(Div_Value(i), AfterDecimal + 1))
                            Next
                    End Select
                    For i As Integer = 0 To div_num - 1
                        attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.Class_Div(i).Value = Div_Value(i)
                    Next
                attrData.TempData.ModeValueInScreen_Stac.setF = True
            Case enmSoloMode_Number.MarkSizeMode
                With attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD
                    .MaxValueMode = clsAttrData.enmMarkSizeValueMode.UserDefinition
                    .MaxValue = maxV
                End With

                attrData.TempData.ModeValueInScreen_Stac.setF = True
                Case enmSoloMode_Number.MarkBarMode
                    With attrData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.MarkBarMD
                        .MaxValueMode = clsAttrData.enmMarkSizeValueMode.UserDefinition
                        .MaxValue = maxV
                    End With
                attrData.TempData.ModeValueInScreen_Stac.setF = True

            End Select

    End Sub
    Public Shared Sub Restore_InScreenObjectData(ByRef attrData As clsAttrData)
        With attrData.TempData.ModeValueInScreen_Stac
            For i As Integer = 0 To .divValue.Length - 1
                attrData.LayerData(.LayerNum).atrData.Data(.DataNum).SoloModeViewSettings.Class_Div(i).Value = .divValue(i)
            Next
            attrData.LayerData(.LayerNum).atrData.Data(.DataNum).SoloModeViewSettings.MarkSizeMD.MaxValueMode = .MarkSize_MaxValueMode
            attrData.LayerData(.LayerNum).atrData.Data(.DataNum).SoloModeViewSettings.MarkSizeMD.MaxValue = .MarkSize_MaxValue
            attrData.LayerData(.LayerNum).atrData.Data(.DataNum).SoloModeViewSettings.MarkBarMD.MaxValueMode = .MarkBar_MaxValueMode
            attrData.LayerData(.LayerNum).atrData.Data(.DataNum).SoloModeViewSettings.MarkBarMD.MaxValue = .MarkBar_MaxValue
            .setF = False
        End With
    End Sub
End Class
