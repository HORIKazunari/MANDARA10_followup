Public Class clsAccessory
    ''' <summary>PrintTMS
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <remarks></remarks>
    Public Shared Sub LatLonLine_Print(ByRef g As Graphics, ByRef attrData As clsAttrData)
        

        With attrData.TotalData.ViewStyle
            If .ScrData.ThreeDMode.Set3D_F = True Then
                Return
            End If
            Dim MapIdoKedoRect As RectangleF = attrData.TempData.MapAreaLatLon

            Dim iiv As Single = .LatLonLine_Print.Lat_Interval
            Dim s1 As Integer = Int(MapIdoKedoRect.Top / iiv)
            Dim Start_Ido As Single = iiv * s1
            Dim End_Ido As Single = iiv * Int(MapIdoKedoRect.Bottom / iiv) + iiv
            Dim mer85f As Boolean = False
            If .Zahyo.Projection = enmProjection_Info.prjMercator Then
                If End_Ido > 85 Then
                    End_Ido = 85
                    mer85f = True
                End If
                If Start_Ido < -85 Then
                    Start_Ido = Start_Ido + iiv
                End If
            End If
            Dim ikv As Single = .LatLonLine_Print.Lon_Interval

            Dim s2 As Integer
            If ikv > 2 Then
                If MapIdoKedoRect.Left > 0 Then
                    s2 = Fix(MapIdoKedoRect.Left / ikv)
                Else
                    s2 = Math.Round((MapIdoKedoRect.Left) / ikv)
                End If
            Else
                s2 = Fix(MapIdoKedoRect.Left / ikv)
            End If

            Dim Start_Kedo As Single = ikv * s2
            Dim End_kedo As Single
            If ikv > 2 Then
                End_kedo = Math.Round(MapIdoKedoRect.Right / ikv) * ikv
            Else
                End_kedo = Fix(MapIdoKedoRect.Right / ikv) * ikv + ikv
            End If


            Dim idon As Integer = 0
            Dim Idock As Single
            Do
                Idock = Start_Ido + idon * iiv
                idon += 1
            Loop While Idock < End_Ido
            If mer85f = False Then
                If Idock <> End_Ido Then
                    If Idock - End_Ido > iiv / 2 Then
                        idon -= 1
                        End_Ido = Start_Ido + (idon - 1) * iiv
                    Else
                        End_Ido = Idock
                    End If
                End If
            End If
            For i As Integer = 0 To idon - 1
                Dim Ido As Single = Start_Ido + i * iiv
                Select Case .Zahyo.Projection
                    Case enmProjection_Info.prjSanson, enmProjection_Info.prjSeikyoEntou, enmProjection_Info.prjMercator, enmProjection_Info.prjMiller,
                            enmProjection_Info.prjSeikyoEntou, enmProjection_Info.prjLambertSeisekiEntou, enmProjection_Info.prjMollweide, enmProjection_Info.prjEckert4
                        Dim P1 As PointF = spatial.Get_Converted_XY(New PointF(Start_Kedo, Ido), .Zahyo)
                        Dim P2 As PointF = spatial.Get_Converted_XY(New PointF(End_kedo, Ido), .Zahyo)
                        Dim PC1 As Point = .ScrData.getSxSy(P1)
                        Dim PC2 As Point = .ScrData.getSxSy(P2)
                        Dim lpt As Line_Property = .LatLonLine_Print.LPat
                        If i = 0 Or i = idon - 1 Then
                            If Ido = End_Ido Or i = 0 Then
                                lpt = .LatLonLine_Print.OuterPat
                            End If
                        End If
                        If Ido = 0 Then
                            lpt = .LatLonLine_Print.Equator
                        End If
                        clsDrawLine.Line(g, lpt, PC1, PC2, .ScrData, attrData.TotalData.BasePicture)
                End Select
            Next
            If .Zahyo.Projection = enmProjection_Info.prjMercator Then
                If End_Ido = 85 Then
                    Dim P1 As PointF = spatial.Get_Converted_XY(New PointF(Start_Kedo, End_Ido), .Zahyo)
                    Dim P2 As PointF = spatial.Get_Converted_XY(New PointF(End_kedo, End_Ido), .Zahyo)
                    Dim PC1 As Point = .ScrData.getSxSy(P1)
                    Dim PC2 As Point = .ScrData.getSxSy(P2)
                    Dim lpt As Line_Property = .LatLonLine_Print.LPat
                    clsDrawLine.Line(g, .LatLonLine_Print.OuterPat, PC1, PC2, .ScrData, attrData.TotalData.BasePicture)
                End If
            End If

            Dim kedon As Integer = 0
            Dim Kedock As Single
            Do
                Kedock = Start_Kedo + kedon * ikv
                kedon += 1
            Loop While Kedock < End_kedo
            If Kedock <> End_kedo Then
                If Kedock - End_kedo > ikv / 2 Then
                    kedon -= 1
                    End_kedo = Start_Kedo + (kedon - 1) * ikv
                Else
                    End_kedo = Kedock
                End If
            End If

            For i As Integer = 0 To kedon - 1
                Dim Kedo As Single = Start_Kedo + i * ikv
                Dim lpt As Line_Property = .LatLonLine_Print.LPat
                If i = 0 Or i = kedon - 1 Then
                    lpt = .LatLonLine_Print.OuterPat
                End If

                Select Case .Zahyo.Projection
                    Case enmProjection_Info.prjSanson, enmProjection_Info.prjMollweide, enmProjection_Info.prjEckert4
                        Dim P1 As PointF = spatial.Get_Converted_XY(New PointF(Kedo, End_Ido), .Zahyo)
                        Dim P2 As PointF = spatial.Get_Converted_XY(New PointF(Kedo, Start_Ido), .Zahyo)
                        Dim PC1 As Point = .ScrData.getSxSy(P1)
                        Dim PC2 As Point = .ScrData.getSxSy(P2)
                        If PC1.X = PC2.X And End_Ido * Start_Ido >= 0 Then
                            clsDrawLine.Line(g, .LatLonLine_Print.LPat, PC1, PC2, .ScrData, attrData.TotalData.BasePicture)
                        ElseIf End_Ido * Start_Ido >= 0 Then
                            '赤道を挟まない場合
                            Dim w As Integer = Math.Abs(PC2.X - PC1.X)
                            Dim H As Single = End_Ido - Start_Ido
                            Dim pxy(w) As Point
                            For j As Integer = 0 To w
                                Dim PP1 As PointF = spatial.Get_Converted_XY(New PointF(Kedo, Start_Ido + H * (j / w)), .Zahyo)
                                pxy(j) = .ScrData.getSxSy(PP1)
                            Next
                            clsDrawLine.Line(g, lpt, w + 1, pxy, .ScrData, attrData.TotalData.BasePicture)
                        Else
                            '赤道を挟む場合
                            Dim P3 As PointF = spatial.Get_Converted_XY(New PointF(Kedo, 0), .Zahyo)
                            Dim PC3 As Point = .ScrData.getSxSy(P3)
                            Dim w As Integer = Math.Abs(PC1.X - PC3.X)
                            Dim w2 As Integer = Math.Abs(PC2.X - PC3.X)
                            If w + w2 = 0 Then
                                clsDrawLine.Line(g, lpt, PC1, PC2, .ScrData, attrData.TotalData.BasePicture)
                            Else
                                Dim H As Single = Math.Abs(Start_Ido) + End_Ido
                                Dim pxy(w + w2) As Point
                                For j As Integer = 0 To w + w2
                                    Dim PP1 As PointF = spatial.Get_Converted_XY(New PointF(Kedo, Start_Ido + H * (j / (w + w2))), .Zahyo)
                                    pxy(j) = .ScrData.getSxSy(PP1)
                                Next
                                clsDrawLine.Line(g, lpt, w + w2 + 1, pxy, .ScrData, attrData.TotalData.BasePicture)
                            End If
                        End If
                    Case enmProjection_Info.prjSeikyoEntou, enmProjection_Info.prjMercator, enmProjection_Info.prjMiller, enmProjection_Info.prjLambertSeisekiEntou
                        Dim PC1 As Point
                        Dim PC2 As Point
                        If .Zahyo.Projection = enmProjection_Info.prjMercator Then
                            Dim P1 As PointF = spatial.Get_Converted_XY(New PointF(Kedo, End_Ido), .Zahyo)
                            Dim P2 As PointF = spatial.Get_Converted_XY(New PointF(Kedo, Start_Ido), .Zahyo)
                            PC1 = .ScrData.getSxSy(P1)
                            PC2 = .ScrData.getSxSy(P2)
                        Else
                            Dim P1 As PointF = spatial.Get_Converted_XY(New PointF(Kedo, End_Ido), .Zahyo)
                            Dim P2 As PointF = spatial.Get_Converted_XY(New PointF(Kedo, Start_Ido), .Zahyo)
                            PC1 = .ScrData.getSxSy(P1)
                            PC2 = .ScrData.getSxSy(P2)
                        End If
                        clsDrawLine.Line(g, lpt, PC1, PC2, .ScrData, attrData.TotalData.BasePicture)
                End Select
            Next
        End With


    End Sub
    ''' <summary>
    ''' 飾りグループボックス表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <remarks></remarks>
    Public Shared Sub AccGroupBoxDraw(ByRef g As Graphics, ByRef attrData As clsAttrData)
        Dim Agb As clsAttrData.strAccessoryGroupBox_Info = attrData.TotalData.ViewStyle.AccessoryGroupBox
        If Agb.Visible = True Then
            clsDrawTile.Draw_Tile_RoundBox(g, attrData.TempData.Accessory_Temp.GroupBox_Rect, Agb.Back, 0, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End If
    End Sub
    ''' <summary>
    ''' 凡例の表示/またはサイズ取得
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Legend_No"></param>
    ''' <param name="SizeGetOnlyF"></param>
    ''' <remarks></remarks>
    Public Shared Sub Legend_print(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal Legend_No As Integer,
                                   ByVal SizeGetOnlyF As Boolean)

        Dim LegendW As clsAttrData.Legend2_Atri = attrData.TempData.Accessory_Temp.MapLegend_W(Legend_No)

        If attrData.TotalData.ViewStyle.MapLegend.Base.Visible = False And
            LegendW.LineKind_Flag = False And LegendW.PointObject_Flag = False Then
            Return
        End If

        Dim ALP As Point
        Dim LFont As Font_Property
        Dim P_Legend As clsAttrData.strLegend_Attri = attrData.TotalData.ViewStyle.MapLegend
        With attrData.TotalData.ViewStyle
            If .ScrData.Accessory_Base = enmBasePosition.Screen Then
                Dim p As PointF = attrData.TotalData.ViewStyle.MapLegend.Base.LegendXY(Legend_No)
                ALP = .ScrData.getSxSy(.ScrData.getSRXYfromRatio(p))
            Else
                Dim p As PointF = attrData.TotalData.ViewStyle.MapLegend.Base.LegendXY(Legend_No)
                ALP = .ScrData.getSxSy(p)
            End If
            LFont = .MapLegend.Base.Font
        End With

        Dim BoxSize As Size
        Dim TX As String
        Dim screen_in As Boolean
        With LegendW
            If .LineKind_Flag = True Then
                'ライン線種の凡例
                TX = ""
                screen_in = Draw_LineKind(g, attrData, ALP, BoxSize, SizeGetOnlyF)
            ElseIf .PointObject_Flag = True Then
                'ダミーオブジェクトの凡例
                TX = ""
                screen_in = Draw_PointObject(g, attrData, ALP, BoxSize, SizeGetOnlyF)
            Else
                Dim Layn2 As Integer = .Layn
                Select Case .Print_Mode_Layer
                    Case enmLayerMode_Number.LabelMode   'ラベルは凡例無し
                    Case enmLayerMode_Number.GraphMode
                        Select Case .GraphMode
                            Case enmGraphMode.PieGraph, enmGraphMode.StackedBarGraph
                                screen_in = Draw_Multi_Engraph(g, attrData, ALP, BoxSize, Layn2, .DatN, SizeGetOnlyF)
                            Case enmGraphMode.LineGraph, enmGraphMode.BarGraph
                                screen_in = Draw_Multi_Oresen(g, attrData, ALP, BoxSize, Layn2, .DatN, SizeGetOnlyF)
                        End Select
                    Case enmLayerMode_Number.SoloMode
                        Dim datn2 As Integer = LegendW.DatN
                        Dim UTX As String = attrData.Get_DataUnit_With_Kakko(Layn2, datn2)
                        BoxSize = New Size(0, 0)
                        With attrData.TotalData.ViewStyle.MapLegend.OverLay_Legend_Title
                            If .Print_f = True Then
                                TX = LegendW.title
                                If TX <> "" Then
                                    Dim Tx_H As Integer
                                    Dim mx_w As Integer = attrData.Get_Length_On_Screen(.MaxWidth)
                                    Dim Out_Title As List(Of String) = clsDraw.TextCut_for_print(g, TX, LFont, True, mx_w, 0, Tx_H, attrData.TotalData.ViewStyle.ScrData)
                                    Dim t_Line_n As Integer = Out_Title.Count
                                    Dim TX2 As String = ""
                                    BoxSize.Width = 0
                                    Dim H As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
                                    Dim hnfont As Font = New Font(LFont.Body.Name, H, GraphicsUnit.Pixel)
                                    For i As Integer = 0 To t_Line_n - 1
                                        BoxSize.Width = Math.Max(BoxSize.Width, g.MeasureString(Out_Title(i), hnfont).Width)
                                        TX2 += Out_Title(i)
                                        If i <> t_Line_n - 1 Then
                                            TX2 += vbCrLf
                                        End If
                                    Next
                                    BoxSize.Height = Tx_H * (t_Line_n + 0.5)
                                    TX = TX2
                                End If
                            End If
                        End With

                        Select Case LegendW.SoloMode
                            Case enmSoloMode_Number.ClassPaintMode
                                If attrData.LayerData(Layn2).Shape <> enmShape.LineShape Then
                                    screen_in = Draw_ClassPaintHatchMode(g, attrData, ALP, BoxSize, UTX, Layn2, datn2, 0, SizeGetOnlyF)
                                Else
                                    screen_in = Draw_ClassPaint_LineShape(g, attrData, ALP, BoxSize, UTX, Layn2, datn2, SizeGetOnlyF)
                                End If
                            Case enmSoloMode_Number.MarkSizeMode
                                screen_in = Draw_MarkSizeMode(g, attrData, ALP, BoxSize, UTX, Layn2, datn2, SizeGetOnlyF)
                            Case enmSoloMode_Number.MarkBlockMode
                                screen_in = Draw_MarkBlockMode(g, attrData, ALP, BoxSize, UTX, Layn2, datn2, SizeGetOnlyF)
                            Case enmSoloMode_Number.MarkBarMode
                                screen_in = Draw_MarkBarMode(g, attrData, ALP, BoxSize, UTX, Layn2, datn2, SizeGetOnlyF)
                            Case enmSoloMode_Number.StringMode
                                screen_in = Draw_StringMode(g, attrData, ALP, BoxSize, UTX, Layn2, datn2, SizeGetOnlyF)
                            Case enmSoloMode_Number.ContourMode
                                Dim PushMisF As Boolean = attrData.TotalData.ViewStyle.Missing_Data.Print_Flag
                                '等値線モードの場合は欠損値の凡例を表示しない
                                attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = False
                                Select Case attrData.LayerData(Layn2).atrData.Data(datn2).SoloModeViewSettings.ContourMD.Interval_Mode
                                    Case clsAttrData.enmContourIntervalMode.ClassPaint
                                        screen_in = Draw_ClassPaintHatchMode(g, attrData, ALP, BoxSize, UTX, Layn2, datn2, 0, SizeGetOnlyF)
                                    Case clsAttrData.enmContourIntervalMode.ClassHatch
                                        screen_in = Draw_ClassPaintHatchMode(g, attrData, ALP, BoxSize, UTX, Layn2, datn2, 1, SizeGetOnlyF)
                                End Select
                                attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = PushMisF
                            Case enmSoloMode_Number.ClassHatchMode
                                screen_in = Draw_ClassPaintHatchMode(g, attrData, ALP, BoxSize, UTX, Layn2, datn2, 1, SizeGetOnlyF)
                            Case enmSoloMode_Number.ClassMarkMode
                                screen_in = Draw_ClassMarkMode(g, attrData, ALP, BoxSize, UTX, Layn2, datn2, SizeGetOnlyF)
                            Case enmSoloMode_Number.ClassODMode
                                screen_in = Draw_ClassODModeMode(g, attrData, ALP, BoxSize, UTX, Layn2, datn2, SizeGetOnlyF)
                            Case enmSoloMode_Number.MarkTurnMode
                                '記号の回転は凡例無し
                        End Select
                End Select
            End If
        End With
        If SizeGetOnlyF = True Then
            attrData.TempData.Accessory_Temp.MapLegend_W(Legend_No).Rect = New Rectangle(ALP, BoxSize)
            Dim padw As Integer = attrData.Get_PaddingPixcel(attrData.TotalData.ViewStyle.MapLegend.Base.Back)
            attrData.TempData.Accessory_Temp.MapLegend_W(Legend_No).Rect.Inflate(padw, padw)
            Return
        End If
        If TX <> "" And screen_in = True Then
            attrData.Draw_Print(g, TX, ALP, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
        End If

        'If attrData.TotalData.ViewStyle.ScrData.OutputDevide = enmOutputDevice.Screen And screen_in = True Then
        '    attrData.TempData.Accessory_Temp.MapLegend_W(Legend_No).Rect = New Rectangle(ALP, BoxSize)
        'End If

        attrData.TotalData.ViewStyle.MapLegend = P_Legend
    End Sub
    ''' <summary>
    ''' 線種の凡例
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="ALP"></param>
    ''' <param name="HeadBoxSize"></param>
    ''' <param name="SizeGetOnlyF"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_LineKind(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                     ByVal ALP As Point, ByRef HeadBoxSize As Size, ByVal SizeGetOnlyF As Boolean) As Boolean


        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim LPC() As clsMapData.LPatSek_Info = attrData.Get_AllMapLineKind()
        Dim PatNum As Integer = LPC.Length
        Dim LineKind_Used() As Boolean = attrData.Get_LineKindUsedList
        Dim n As Integer = 0
        Dim Use_Line_Number(PatNum - 1) As Integer
        For i As Integer = 0 To PatNum - 1
            If LineKind_Used(i) = True And _
                Mid$(attrData.TotalData.ViewStyle.MapLegend.Line_DummyKind.Line_Visible_Number_STR, i + 1, 1) = "1" Then
                Use_Line_Number(n) = i
                n += 1
            End If
        Next

        Dim UH As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        Dim hnfont As Font = New Font(LFont.Body.Name, UH, GraphicsUnit.Pixel)
        Dim Xsize As Integer = 0
        For i As Integer = 0 To n - 1
            Xsize = Math.Max(Xsize, g.MeasureString(LPC(Use_Line_Number(i)).Name, hnfont).Width)
        Next
        Xsize = Xsize + attrData.Radius(16, 1, 1)
        Dim Ysize As Integer = UH * n

        With HeadBoxSize
            .Width = Xsize
            .Height = Ysize
        End With
        Dim C_Rect As Rectangle = New Rectangle(ALP, HeadBoxSize)
        If SizeGetOnlyF = True Then
            Return False
        End If

        If attrData.Check_Screen_In(C_Rect) = False Then
            Return False
        Else
            attrData.Draw_Tile_RoundBox(g, C_Rect, attrData.TotalData.ViewStyle.MapLegend.Line_DummyKind.Back, 0)

            For i As Integer = 0 To n - 1
                With LPC(Use_Line_Number(i))
                    Dim Y As Integer = C_Rect.Top + i * UH
                    Dim x3 As Integer = C_Rect.Left + attrData.Radius(16, 1, 1)
                    Select Case attrData.TotalData.ViewStyle.MapLegend.Line_DummyKind.Line_Pattern
                        Case clsAttrData.enmCircleMDLegendLine.Zigzag
                            Dim pxy(3) As Point
                            For j As Integer = 0 To 3
                                pxy(j).X = C_Rect.Left + attrData.Radius(4.5, 1, 1) * j
                                pxy(j).Y = Y + UH / 4 + UH / 2 * (j Mod 2)
                            Next
                            attrData.Draw_Line(g, .Pat, 4, pxy)
                        Case clsAttrData.enmCircleMDLegendLine.Straight
                            attrData.Draw_Line(g, .Pat, New Point(C_Rect.Left, Y + UH / 2), New Point(C_Rect.Left + attrData.Radius(4.5, 1, 1) * 3, Y + UH / 2))
                    End Select
                    attrData.Draw_Print(g, .Name, New Point(x3, Y), LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
                End With
            Next
        End If
    End Function
    ''' <summary>
    ''' 点オブジェクトの凡例
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="ALP"></param>
    ''' <param name="HeadBoxSize"></param>
    ''' <param name="SizeGetOnlyF"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_PointObject(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                 ByVal ALP As Point, ByRef HeadBoxSize As Size, ByVal SizeGetOnlyF As Boolean) As Boolean

        Dim Use_ObjKind_Number() As Long

        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim UH As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        Dim hnfont As Font = New Font(LFont.Body.Name, UH, GraphicsUnit.Pixel)
        Dim mxw1 As Integer = 0
        Dim mxw2 As Integer = 0
        Dim Ys As Integer = 0
        For Each pok In attrData.TempData.PointObjectKindUsedStack
            Dim w1 = attrData.Radius(pok.Mark.WordFont.Body.Size, 1, 1) * 3
            mxw1 = Math.Max(mxw1, w1)
            mxw2 = Math.Max(mxw2, g.MeasureString(pok.ObjectKindName, hnfont).Width)
            Ys += Math.Max(UH, w1)
        Next

        mxw1 += attrData.Radius(2, 1, 1)

        With HeadBoxSize
            .Width = mxw1 + mxw2
            .Height = Ys
        End With
        If SizeGetOnlyF = True Then
            Return False
        End If
        Dim C_Rect As Rectangle = New Rectangle(ALP, HeadBoxSize)
        If attrData.Check_Screen_In(C_Rect) = False Then
            Return False
        End If
        attrData.Draw_Tile_RoundBox(g, C_Rect, attrData.TotalData.ViewStyle.MapLegend.Line_DummyKind.Back, 0)
        Ys = 0
        For Each pok In attrData.TempData.PointObjectKindUsedStack
            Dim r As Integer = attrData.Radius(pok.Mark.WordFont.Body.Size, 1, 1) * 3
            Dim s As Integer = Math.Max(r, UH)
            mxw2 = Math.Max(mxw2, g.MeasureString(pok.ObjectKindName, hnfont).Width)
            attrData.Draw_Mark(g, New Point(ALP.X + mxw1 / 2, ALP.Y + Ys + s / 2), attrData.Radius(pok.Mark.WordFont.Body.Size, 1, 1), pok.Mark)
            attrData.Draw_Print(g, pok.ObjectKindName, New Point(ALP.X + mxw1, ALP.Y + Ys + s / 2), LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
            Ys += s
        Next


    End Function
    ''' <summary>
    ''' 折れ線・棒グラフモード
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="ALP"></param>
    ''' <param name="HeadBoxSize"></param>
    ''' <param name="Layn2"></param>
    ''' <param name="DataSet_Num"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_Multi_Oresen(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                         ByVal ALP As Point, ByRef HeadBoxSize As Size,
                                         ByVal Layn2 As Integer, ByVal DataSet_Num As Integer,
                                   ByVal SizeGetOnlyF As Boolean) As Boolean
        If attrData.TotalData.ViewStyle.MapLegend.Base.Visible = False Then
            Return False
        End If

        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim TH As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        Dim hnfont As Font = New Font(LFont.Body.Name, TH, GraphicsUnit.Pixel)

        Dim gData As clsAttrData.strGraph_Data = attrData.LayerData(Layn2).LayerModeViewSettings.GraphMode.DataSet(DataSet_Num)

        Dim DataN As Integer = gData.Count

        Dim DataTitleWidth As Integer = g.MeasureString(attrData.Get_DataTitle(Layn2, gData.Data(0).DataNumner, False), hnfont).Width * (DataN + 2)

        Dim DataTitleHeight As Integer = 0
        Dim UnitTx As String = attrData.Get_DataUnit_With_Kakko(Layn2, gData.Data(0).DataNumner)
        For i As Integer = 0 To DataN - 1
            DataTitleHeight = Math.Max(DataTitleHeight, g.MeasureString(attrData.Get_DataTitle(Layn2, gData.Data(i).DataNumner, False), hnfont).Width)
        Next
        Dim ww As Integer = attrData.Get_Length_On_Screen(gData.Oresen_Bou.Size)
        If ww * 1.5 < DataTitleWidth Then
            ww *= 1.5
        ElseIf ww < DataTitleWidth Then
            ww = DataTitleWidth
        End If
        '    ww = math.max(ww, DataTitleWidth)
        Dim wh As Integer = ww / gData.Oresen_Bou.AspectRatio
        Dim VL As Integer = UNIT_P(g, attrData, New Point(0, 0), gData.Oresen_Bou.YMax, UnitTx, 0, False)
        Dim xsize2 As Integer = Math.Max(HeadBoxSize.Width, ww + VL)
        VL = UNIT_P(g, attrData, New Point(0, 0), gData.Oresen_Bou.Ymin, UnitTx, 1, False)
        xsize2 = Math.Max(xsize2, ww + VL)
        Dim ysize2 As Integer = HeadBoxSize.Height + TH / 2 + wh + TH / 4 + DataTitleHeight
        Dim C_Rect As Rectangle = New Rectangle(ALP, New Size(xsize2, ysize2))
        If SizeGetOnlyF = True Then
            HeadBoxSize = New Size(xsize2, ysize2)
            Return False
        End If
        If attrData.Check_Screen_In(C_Rect) = False Then
            Return False
        End If

        'ここから描画
        LegendBoxBack(g, attrData, C_Rect)

        '折れ線グラフの枠
        Dim Ymax As Double
        Dim Ymin As Double
        Dim ST As Double
        Dim stx As Single
        With gData.Oresen_Bou
            Ymax = .YMax
            Ymin = .Ymin
            ST = .Ystep
            If gData.GraphMode = enmGraphMode.LineGraph Then
                stx = ww / (DataN + 1)
            Else
                stx = ww / (DataN + 2)
            End If
        End With
        Dim GraphRect As Rectangle = New Rectangle(ALP.X, ALP.Y + HeadBoxSize.Height + TH / 2, ww, wh)
        attrData.Draw_Tile_Box(g, GraphRect, 0,
                               gData.Oresen_Bou.BorderLine, gData.Oresen_Bou.BackgroundTile)

        '枠の目盛り
        Dim Zero_Line As Line_Property = clsBase.Line
        Zero_Line.BasicLine.SolidLine.Color = gData.Oresen_Bou.BorderLine.BasicLine.SolidLine.Color
        With Zero_Line.BasicLine
            .pattern = 1
            .CenterLineParts0.Use_F = True
            .CenterLineParts1.Use_F = True
            .CenterLineParts1.Print_f = False
        End With
        For j As Double = Ymin To Ymax Step ST
            If j <> Ymin And j <> Ymax Then
                Dim H As Double = 1 - (j - Ymin) / (Ymax - Ymin)
                Dim yy As Integer = HeadBoxSize.Height + TH / 2 + wh * H
                attrData.Draw_Line(g, gData.Oresen_Bou.BorderLine, ALP.X, ALP.Y + yy, ALP.X + stx / 2 + 1, ALP.Y + yy)
                attrData.Draw_Line(g, gData.Oresen_Bou.BorderLine, ALP.X + ww, ALP.Y + yy, ALP.X + ww - stx / 2 - 1, ALP.Y + yy)
            End If
        Next

        Dim zpf As Boolean = False
        Dim zy As Integer
        If Ymin < 0 And Ymax > 0 Then
            Dim H As Double = 1 - (-Ymin) / (Ymax - Ymin)
            Dim yy As Integer = HeadBoxSize.Height + TH / 2 + wh * H
            attrData.Draw_Line(g, Zero_Line, ALP.X, ALP.Y + yy, ALP.X + ww + 1, ALP.Y + yy)
            zpf = True
            zy = yy
        End If

        Dim OriginClip As Region = g.Clip
        Dim RectC As Rectangle = GraphRect
        RectC.Inflate(1, 1)
        g.SetClip(RectC, Drawing2D.CombineMode.Intersect)
        If gData.GraphMode = enmGraphMode.LineGraph Then
            Dim fsx As Single = stx '折れ線
            Dim flx1 As Integer
            Dim fly2 As Integer
            For j As Integer = 0 To DataN - 1
                Dim a As Integer = gData.Data(j).DataNumner
                Dim H As Single = 1 - (attrData.LayerData(Layn2).atrData.Data(a).Statistics.Ave - Ymin) / (Ymax - Ymin)
                Dim yy As Integer = HeadBoxSize.Height + wh * H + TH / 2
                If j = 0 Then
                    flx1 = ALP.X + fsx
                    fly2 = ALP.Y + yy
                    fsx += stx
                Else
                    attrData.Draw_Line(g, gData.Oresen_Bou.Line, flx1, fly2, ALP.X + fsx + 1, ALP.Y + yy + 1)
                    flx1 = ALP.X + fsx + 1
                    fly2 = ALP.Y + yy + 1
                    fsx += stx
                End If
            Next
        Else
            Dim fsx As Single = stx '棒グラフ
            For j As Integer = 0 To DataN - 1
                Dim a As Integer = gData.Data(j).DataNumner
                Dim H As Single = 1 - (attrData.LayerData(Layn2).atrData.Data(a).Statistics.Ave - Ymin) / (Ymax - Ymin)
                Dim yy As Integer = HeadBoxSize.Height + wh * H + TH / 2
                Dim yy2 As Integer = HeadBoxSize.Height + TH / 2 + (wh * (1 - (-Ymin) / (Ymax - Ymin)))
                attrData.Draw_Tile_Box(g, New Rectangle(ALP.X + fsx, ALP.Y + yy, stx, yy2 - yy), 0, gData.Oresen_Bou.Line, gData.Data(j).Tile)
                fsx += stx
            Next
        End If
        g.Clip = OriginClip

        VL = UNIT_P(g, attrData, New Point(ALP.X + ww + TH * 0.2, ALP.Y + HeadBoxSize.Height), Ymax, UnitTx, 0, True)
        HeadBoxSize.Width = Math.Max(HeadBoxSize.Width, ww + VL)
        VL = UNIT_P(g, attrData, New Point(ALP.X + ww + TH * 0.2, ALP.Y + HeadBoxSize.Height + wh), Ymin, UnitTx, 1, True)
        HeadBoxSize.Width = Math.Max(HeadBoxSize.Width, ww + VL)
        If zpf = True Then
            attrData.Draw_Print(g, "0", New Point(ALP.X + ww + TH * 0.2, ALP.Y + HeadBoxSize.Height + zy - TH / 2), LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
        End If
        HeadBoxSize.Height += wh + TH / 4

        'データの項目表示
        LFont.Body.Kakudo = 90
        Dim xstacu As Integer = 0
        For i As Integer = 0 To DataN - 1
            If xstacu <= stx * i Then
                Dim ttl As String = attrData.Get_DataTitle(Layn2, gData.Data(i).DataNumner, False)
                Dim H As Integer = g.MeasureString(ttl, hnfont).Width
                Dim p As New Point(ALP.X + stx * i + stx, ALP.Y + HeadBoxSize.Height + H / 2)
                Select Case gData.GraphMode
                    Case enmGraphMode.LineGraph
                    Case enmGraphMode.BarGraph
                        p.Offset(stx / 2, 0)
                End Select
                attrData.Draw_Print(g, ttl, p, LFont, enmHorizontalAlignment.Center, enmVerticalAlignment.Top)
                xstacu += TH
            End If
        Next
        HeadBoxSize.Height = ysize2


    End Function
    ''' <summary>
    ''' 円グラフで、凡例の表示方法が円一つの場合で円グラフの周囲にデータ項目名を並べる場合の凡例
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="ALP"></param>
    ''' <param name="HeadBoxSize"></param>
    ''' <param name="UnitTx"></param>
    ''' <param name="Layn2"></param>
    ''' <param name="DataSet_Num"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_Multi_Engraph_Pattern1(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                         ByVal ALP As Point, ByRef HeadBoxSize As Size,
                                         ByVal Layn2 As Integer, ByVal DataSet_Num As Integer,
                                         ByVal SizeGetOnlyF As Boolean) As Boolean

        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim TH As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        Dim hnfont As Font = New Font(LFont.Body.Name, TH, GraphicsUnit.Pixel)

        Dim EN_TP As Tile_Property = clsBase.Tile
        EN_TP.Line.BasicLine.SolidLine.Color = New colorARGB(Color.White)

        Dim gData As clsAttrData.strGraph_Data = attrData.LayerData(Layn2).LayerModeViewSettings.GraphMode.DataSet(DataSet_Num)
        Dim UnitTx As String = attrData.Get_DataUnit_With_Kakko(Layn2, gData.Data(0).DataNumner)
        Dim n As Integer = gData.Count
        Dim size2 As Size = HeadBoxSize
        Dim upXsmin As Single
        Dim upXsmax As Single
        Dim Value(2) As Double
        Dim rmaxw As Integer
        With gData.En_Obi
            Value(0) = .Value1
            Value(1) = .Value2
            Value(2) = .Value3
            If .EnSizeMode = enmGraphMaxSize.Changeable Then
                'サイズ可変型の場合
                rmaxw = attrData.Radius(.EnSize, Value(0), .MaxValue)
                upXsmin = -rmaxw
                upXsmax = size2.Width - rmaxw
            Else
                rmaxw = attrData.Get_Length_On_Screen(.EnSize / 2)
            End If
        End With

        Dim Xsmin As Single = -rmaxw
        Dim Xsmax As Single = rmaxw
        Dim Ysmin As Single = -rmaxw
        Dim Ysmax As Single = rmaxw

        Dim UnderW As Single
        Dim UnderH As Single
        Dim xposi(n - 1) As enmHorizontalAlignment
        Dim yposi(n - 1) As enmVerticalAlignment
        Dim WordP(n - 1) As Point
        'rep=0の時は大きさを計算、rep1で実際の描画
        For rep As Integer = 0 To 1
            size2 = HeadBoxSize
            With gData.En_Obi
                If .EnSizeMode = enmGraphMaxSize.Changeable Then
                    Dim p As Point = ALP
                    p.Offset(UnderW / 2 - rmaxw, 0)
                    OverCircle_Print(g, attrData, p, .MaxValue, Value, UnitTx, .EnSize, .BoaderLine, EN_TP, size2.Height, size2.Width, (rep = 1))
                End If
            End With

            If rep = 0 Then
                For i As Integer = 0 To n - 1
                    Dim a As Integer = gData.Data(i).DataNumner
                    Dim CeR As Single = Math.PI * 2 * ((i + 0.5) / n)
                    Dim p As PointF = New PointF(Math.Sin(CeR) * rmaxw * 1.3, Math.Cos(CeR) * rmaxw * 1.3)
                    Dim w As Integer = g.MeasureString(attrData.Get_DataTitle(Layn2, a, False), hnfont).Width
                    Dim n2 As Single = (i + 0.5) / n
                    If n2 < 0.5 Then
                        xposi(i) = enmHorizontalAlignment.Left
                        Xsmax = Math.Max(Xsmax, p.X + w)
                    ElseIf n2 = 0.5 Then
                        Xsmax = Math.Max(Xsmax, p.X + w / 2)
                        Xsmin = Math.Min(Xsmin, p.X - w / 2)
                        xposi(i) = enmHorizontalAlignment.Center
                    Else
                        Xsmin = Math.Min(Xsmin, p.X - w)
                        xposi(i) = enmHorizontalAlignment.Right
                    End If
                    If n2 < 0.25 Or n2 > 0.75 Then
                        Ysmin = Math.Min(Ysmin, -p.Y - TH)
                        yposi(i) = enmVerticalAlignment.Bottom
                    ElseIf n2 = 0.25 Or n2 = 0.75 Then
                        Ysmax = Math.Max(Ysmax, -p.Y + TH)
                        yposi(i) = enmVerticalAlignment.Center
                    Else
                        Ysmax = Math.Max(Ysmax, -p.Y + TH)
                        yposi(i) = enmVerticalAlignment.Top
                    End If
                    WordP(i) = New Point(p.X, -p.Y)
                Next
                UnderW = Xsmax - Xsmin
                UnderH = Ysmax - Ysmin
            Else
                For i As Integer = 0 To n - 1
                    Dim sr As Single = Math.PI * 2 * (i / n)
                    Dim Er As Single = Math.PI * 2 * ((i + 1) / n)
                    Dim a As Integer = gData.Data(i).DataNumner
                    Dim fp As Point = ALP
                    fp.Offset(-Xsmin, size2.Height + TH / 2 + UnderH / 2)
                    attrData.Draw_Fan(g, fp, rmaxw, sr, Er, gData.En_Obi.BoaderLine, gData.Data(i).Tile)
                    Dim p As Point = WordP(i)
                    p.Offset(ALP.X - Xsmin, ALP.Y + size2.Height + TH / 2 + UnderH / 2)
                    attrData.Draw_Print(g, attrData.Get_DataTitle(Layn2, a, False), p, LFont, xposi(i), yposi(i))
                Next
            End If
            size2.Height += UnderH + TH
            size2.Width = Math.Max(size2.Width, UnderW)
            size2.Width *= 1.1

            If SizeGetOnlyF = True Then
                HeadBoxSize = size2
                Return False
            End If

            Dim C_Rect As Rectangle = New Rectangle(ALP, size2)
            If attrData.Check_Screen_In(C_Rect) = False Then
                Return False
            End If

            If rep = 0 Then
                LegendBoxBack(g, attrData, C_Rect)
            Else
                HeadBoxSize = size2
            End If
        Next
        Return True
    End Function
    ''' <summary>
    ''' 円グラフ/帯グラフモードの凡例
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="ALP"></param>
    ''' <param name="HeadBoxSize"></param>
    ''' <param name="UnitTx"></param>
    ''' <param name="Layn2"></param>
    ''' <param name="DataSet_Num"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_Multi_Engraph(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                         ByVal ALP As Point, ByRef HeadBoxSize As Size,
                                         ByVal Layn2 As Integer, ByVal DataSet_Num As Integer,
                                         ByVal SizeGetOnlyF As Boolean) As Boolean
        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim TH As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        Dim hnfont As Font = New Font(LFont.Body.Name, TH, GraphicsUnit.Pixel)

        If attrData.TotalData.ViewStyle.MapLegend.Base.Visible = False Then
            Return False
        End If

        If attrData.LayerData(Layn2).LayerModeViewSettings.GraphMode.DataSet(DataSet_Num).GraphMode = enmGraphMode.PieGraph And
            attrData.TotalData.ViewStyle.MapLegend.En_Graph_Pattern = enmMultiEnGraphPattern.oneCircle Then
            '円グラフで、凡例の表示方法が円一つの場合
            Return Draw_Multi_Engraph_Pattern1(g, attrData, ALP, HeadBoxSize, Layn2, DataSet_Num, SizeGetOnlyF)
        End If

        Dim TilePat As Tile_Property = clsBase.Tile
        TilePat.Line.BasicLine.SolidLine.Color = New colorARGB(255, 210, 210, 210)

        Dim gData As clsAttrData.strGraph_Data = attrData.LayerData(Layn2).LayerModeViewSettings.GraphMode.DataSet(DataSet_Num)

        Dim UnitTx As String = attrData.Get_DataUnit_With_Kakko(Layn2, gData.Data(0).DataNumner)
        Dim n As Integer = gData.Count
        Dim Value(2) As Double
        With gData.En_Obi
            Value(0) = .Value1
            Value(1) = .Value2
            Value(2) = .Value3
        End With
        Array.Sort(Value)
        Array.Reverse(Value)
        Dim LegendVn As Integer = 0
        For i As Integer = 0 To Value.Length - 1
            If Value(i) <= 0 Then
                Exit For
            Else
                LegendVn += 1
            End If
        Next
        'rep=0の時は大きさを計算、rep1で実際の描画
        For rep As Integer = 0 To 1
            Dim size2 As Size = HeadBoxSize
            With gData.En_Obi
                If .EnSizeMode = enmGraphMaxSize.Changeable Then
                    'サイズ可変型の場合
                    Select Case attrData.LayerData(Layn2).LayerModeViewSettings.GraphMode.DataSet(DataSet_Num).GraphMode
                        Case enmGraphMode.PieGraph
                            Dim EN_TP As Tile_Property = clsBase.Tile
                            EN_TP.TileCode = enmTilePattern.Paint
                            EN_TP.Line.BasicLine.SolidLine.Color = New colorARGB(Color.White)
                            OverCircle_Print(g, attrData, ALP, .MaxValue, Value, UnitTx, .EnSize, .BoaderLine, EN_TP, size2.Height, size2.Width, (rep = 1))
                        Case enmGraphMode.StackedBarGraph
                            Dim ysize2 As Integer = HeadBoxSize.Height
                            Dim r1 As Integer = attrData.Get_Length_On_Screen(.EnSize)
                            Dim y3 As Integer = HeadBoxSize.Height + r1 + TH / 2
                            For i As Integer = 0 To LegendVn - 1
                                Dim V As Double = Value(i)
                                Dim r As Integer = attrData.Radius(.EnSize, V, .MaxValue) * 2
                                Dim r2 As Integer = r * .AspectRatio
                                If .StackedBarDirection = enmStackedBarChart_Direction.Horizontal Then
                                    If rep = 1 Then
                                        attrData.Draw_Tile_Box(g, New Rectangle(ALP.X, ALP.Y + ysize2, r + 1, r2 + 1), 0, .BoaderLine, TilePat)
                                    End If
                                    ysize2 += r2 * 1.1
                                    Dim VL As Integer = UNIT_P(g, attrData, New Point(ALP.X + TH / 2, ALP.Y + ysize2), V, UnitTx, i, (rep = 1))
                                    ysize2 += TH * 1.5
                                    size2.Width = Math.Max(size2.Width, TH / 2 + VL)
                                Else
                                    Dim tateObiXMoji As Integer = ALP.X + r1 * .AspectRatio + TH * 1.5
                                    Dim tateObiXVal As Integer = ALP.X + r1 * .AspectRatio
                                    Dim tateObiYVal As Integer = ALP.Y + TH / 2 + r1 - r
                                    Dim VL As Integer
                                    Dim rect As New Rectangle(tateObiXVal - r2 - 1, tateObiYVal, r2 + 1, r - 1)
                                    attrData.Draw_Tile_Box(g, rect, 0, .BoaderLine, TilePat)
                                    If tateObiYVal >= ALP.Y + TH * i + TH / 2 Then
                                        VL = UNIT_P(g, attrData, New Point(tateObiXMoji, tateObiYVal - TH / 2), V, UnitTx, i, (rep = 1))
                                        If rep = 1 Then
                                            With attrData.TotalData.ViewStyle.MapLegend.MarkMD
                                                attrData.Draw_Line(g, .MultiEnMode_Line, tateObiXVal, tateObiYVal, tateObiXMoji, tateObiYVal)
                                            End With
                                        End If
                                    Else
                                        Dim tateObiYMoji As Integer = ALP.Y + TH * i
                                        VL = UNIT_P(g, attrData, New Point(tateObiXMoji, tateObiYMoji), V, UnitTx, i, (rep = 1))
                                        Dim lx2 As Integer = tateObiXVal + (tateObiXMoji - tateObiXVal) * (LegendVn + 1 - i) / (LegendVn + 1)
                                        If rep = 1 Then
                                            With attrData.TotalData.ViewStyle.MapLegend.MarkMD
                                                attrData.Draw_Line(g, .MultiEnMode_Line, tateObiXVal, tateObiYVal, lx2, tateObiYVal)
                                                attrData.Draw_Line(g, .MultiEnMode_Line, lx2, tateObiYVal, lx2, tateObiYMoji + TH / 2)
                                                attrData.Draw_Line(g, .MultiEnMode_Line, lx2, tateObiYMoji + TH / 2, tateObiXMoji, tateObiYMoji + TH / 2)
                                            End With
                                        End If
                                    End If
                                    size2.Width = Math.Max(size2.Width, r1 * .AspectRatio + TH * 1.5 + VL)
                                    ysize2 += TH
                                End If
                            Next
                            size2.Height = Math.Max(ysize2 + TH / 2, y3 + TH / 2)
                    End Select
                End If
            End With

            '縦にデータ項目名を並べる場合
            Dim UnderW As Single
            'size2.Height += TH / 2
            For i As Integer = 0 To n - 1
                Dim a As Integer = gData.Data(i).DataNumner
                UnderW = Math.Max(UnderW, g.MeasureString(attrData.Get_DataTitle(Layn2, a, False), hnfont).Width)
                Select Case gData.GraphMode
                    Case enmGraphMode.PieGraph
                        If rep = 1 Then
                            attrData.Draw_Print(g, attrData.Get_DataTitle(Layn2, a, False),
                                                New Point(ALP.X + TH * 2, ALP.Y + size2.Height), LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
                            attrData.Draw_Fan(g, New Point(ALP.X, ALP.Y + size2.Height + TH / 2), TH * 1.5, 1.2, 1.9, gData.En_Obi.BoaderLine, gData.Data(i).Tile)
                        End If
                        size2.Height += TH * 1.2
                    Case enmGraphMode.StackedBarGraph
                        If rep = 1 Then
                            attrData.Draw_Print(g, attrData.Get_DataTitle(Layn2, a, False),
                                                New Point(ALP.X + TH * 2, ALP.Y + size2.Height), LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
                            attrData.Draw_Tile_Box(g, New Rectangle(ALP.X, ALP.Y + size2.Height, TH * 1.5, TH), 0, gData.En_Obi.BoaderLine, gData.Data(i).Tile)
                        End If
                        size2.Height += TH * 1.2
                End Select

            Next
            UnderW += TH * 2
            size2.Width = Math.Max(size2.Width, UnderW)

            If SizeGetOnlyF = True Then
                HeadBoxSize = size2
                Return False
            End If

            Dim C_Rect As Rectangle = New Rectangle(ALP, size2)
            If attrData.Check_Screen_In(C_Rect) = False Then
                Return False
            End If

            If rep = 0 Then
                LegendBoxBack(g, attrData, C_Rect)
            Else
                HeadBoxSize = size2
            End If
        Next

    End Function
    Public Shared Function getLegendMinusWord(ByVal s As String) As String
        If s = "" Then
            Return clsSettings.Data.LegendMinusWord
        Else
            Return s
        End If
    End Function
    Public Shared Function getLegendPlusWord(ByVal s As String) As String
        If s = "" Then
            Return clsSettings.Data.LegendPlusWord
        Else
            Return s
        End If
    End Function
    ''' <summary>
    ''' 棒の高さモードの凡例
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="ALP"></param>
    ''' <param name="HeadBoxSize"></param>
    ''' <param name="UnitTx"></param>
    ''' <param name="Layn2"></param>
    ''' <param name="datn2"></param>
    ''' <param name="SizeGetOnlyF"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_MarkBarMode(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                     ByVal ALP As Point, ByRef HeadBoxSize As Size, ByVal UnitTx As String,
                                     ByVal Layn2 As Integer, ByVal datn2 As Integer,
                                     ByVal SizeGetOnlyF As Boolean) As Boolean
        Dim PData As clsAttrData.strData_info = attrData.LayerData(Layn2).atrData.Data(datn2)
 
        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim UH As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        Dim hnfont As Font = New Font(LFont.Body.Name, UH, GraphicsUnit.Pixel)

        Dim Bar_Md As clsAttrData.strMarkBar_Data = PData.SoloModeViewSettings.MarkBarMD


        Dim val As String
        Dim printVal As Double
        Dim maxv As Double
        Dim BarAreaSize As Size
        Dim BarSize As Size
        Dim UnitHeight As Integer = UH
        With Bar_Md
            BarSize.Height = attrData.Get_Length_On_Screen(.MaxHeight)
            BarSize.Width = attrData.Get_Length_On_Screen(.Width)
            If .MaxValueMode = clsAttrData.enmMarkSizeValueMode.inDataItem Then
                maxv = attrData.LayerData(Layn2).atrData.Data(datn2).Statistics.Max
            Else
                maxv = .MaxValue
            End If
            If attrData.TotalData.ViewStyle.MapLegend.Base.ModeValueInScreenFlag = True Or .BarShape = clsAttrData.MarkBarShape.triangle Then
                printVal = maxv
            Else
                printVal = (Int(maxv / .ScaleLineInterval) * .ScaleLineInterval)
            End If
            val = printVal.ToString
            BarAreaSize = BarSize
            Dim printvalP As Integer = BarSize.Height - printVal / maxv * BarSize.Height
            Dim barareaPlusH As Integer = 0
            If printvalP < UH / 2 Then
                barareaPlusH = UH / 2 - printvalP
            End If

            If .ThreeD = True And .BarShape = clsAttrData.MarkBarShape.bar Then
                BarAreaSize.Width += BarAreaSize.Width / 3
                If barareaPlusH < BarAreaSize.Width / 3 Then
                    barareaPlusH = BarAreaSize.Width / 3
                End If
            End If
            BarAreaSize.Height += barareaPlusH
            BarAreaSize.Width += attrData.Get_Length_On_Screen(4)
            BarAreaSize.Height += UnitHeight + UH / 2
        End With

        Dim tickw As Integer = attrData.Get_Length_On_Screen(0.3)
        Dim wordw As Integer = g.MeasureString(val, hnfont).Width

        Dim FigSize As Size
        FigSize.Width = BarAreaSize.Width + wordw + tickw
        FigSize.Width = Math.Max(FigSize.Width, g.MeasureString(UnitTx, hnfont).Width)
        FigSize.Width = Math.Max(FigSize.Width, HeadBoxSize.Width)
        FigSize.Height = BarAreaSize.Height + UH / 2 + HeadBoxSize.Height

        With attrData.TotalData.ViewStyle.Missing_Data
            If PData.MissingValueNum > 0 And .Print_Flag = True Then
                FigSize.Height += UH + Math.Max(attrData.Radius(.MarkBar.WordFont.Body.Size, 1, 1) * 2, UH)
                FigSize.Width = Math.Max(FigSize.Width, attrData.Radius(.MarkBar.WordFont.Body.Size, 1, 1) * 2.5 + UH + g.MeasureString(.Text, hnfont).Width)
            End If
        End With

        If SizeGetOnlyF = True Then
            HeadBoxSize = FigSize
            Return False
        End If

        Dim C_Rect As Rectangle = New Rectangle(ALP, FigSize)
        If attrData.Check_Screen_In(C_Rect) = False Then
            Return False
        End If

        LegendBoxBack(g, attrData, C_Rect)
        Dim TopP As Point = ALP
        TopP.Y += HeadBoxSize.Height
        Dim zerop As Point = New Point(ALP.X + wordw + tickw, TopP.Y + BarAreaSize.Height)
        Dim OP As Point = New Point(zerop.X + attrData.Get_Length_On_Screen(2) + BarSize.Width / 2, zerop.Y)
        Dim barrect As Rectangle = New Rectangle(OP.X - BarSize.Width / 2, OP.Y - BarSize.Height, BarSize.Width, BarSize.Height)
        Dim Tile As Tile_Property = Bar_Md.InnerTile
        Select Case Bar_Md.BarShape
            Case clsAttrData.MarkBarShape.triangle
                Dim tri(3) As Point
                tri(0) = New Point(OP.X - BarSize.Width / 2, OP.Y)
                tri(1) = New Point(OP.X + BarSize.Width / 2, OP.Y)
                tri(2) = New Point(OP.X, OP.Y - BarSize.Height)
                tri(3) = tri(0)
                attrData.Draw_Poly_Inner(g, tri, {4}, 1, Tile)
                attrData.Draw_Line(g, Bar_Md.FrameLinePat, 4, tri)
            Case clsAttrData.MarkBarShape.bar
                If Bar_Md.ThreeD = True Then
                    Dim poly() As Point
                    Dim poly2() As Point
                    clsPrintMap.MarkBarRectPrint3D(OP, BarSize.Width, BarSize.Height, barrect, poly, poly2)
                    Dim Ptile As Tile_Property = Tile
                    Ptile.Line.BasicLine.SolidLine.Color = clsGeneric.GetColorArrange(Tile.Line.BasicLine.SolidLine.Color, 100)
                    attrData.Draw_Poly_Inner(g, poly, {5}, 1, Ptile)
                    attrData.Draw_Line(g, Bar_Md.FrameLinePat, 5, poly)

                    Dim Ptile2 As Tile_Property = Tile
                    Ptile2.Line.BasicLine.SolidLine.Color = clsGeneric.GetColorArrange(Tile.Line.BasicLine.SolidLine.Color, -100)
                    attrData.Draw_Poly_Inner(g, poly2, {5}, 1, Ptile2)
                    attrData.Draw_Line(g, Bar_Md.FrameLinePat, 5, poly2)
                End If
                attrData.Draw_Tile_Box(g, barrect, 0, Bar_Md.FrameLinePat, Tile)

                For v As Double = 0 To maxv Step Bar_Md.ScaleLineInterval
                    Dim h As Integer = v / maxv * BarSize.Height
                    attrData.Draw_Line(g, clsBase.Line, New Point(zerop.X, zerop.Y - h), New Point(zerop.X - tickw, zerop.Y - h))
                    If Bar_Md.ScaleLineVisible = True Then
                        attrData.Draw_Line(g, Bar_Md.scaleLinePat, New Point(barrect.Left, zerop.Y - h), New Point(barrect.Right, zerop.Y - h))
                    End If
                Next
        End Select
        attrData.Draw_Line(g, clsBase.Line, zerop, New Point(zerop.X + BarAreaSize.Width, zerop.Y))
        attrData.Draw_Line(g, clsBase.Line, zerop, New Point(zerop.X, zerop.Y - BarSize.Height))

        'If Bar_Md.ScaleLineVisible = True Then
        '    attrData.Draw_Tile_Box(g, barrect, 0, Bar_Md.FrameLinePat, clsBase.BlancTile)
        'End If
        attrData.Draw_Print(g, UnitTx, TopP, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
        attrData.Draw_Print(g, "0", New Point(zerop.X - tickw, zerop.Y), LFont, enmHorizontalAlignment.Right, enmVerticalAlignment.Center)
        attrData.Draw_Print(g, val, New Point(zerop.X - tickw, zerop.Y - printVal / maxv * BarSize.Height), LFont, enmHorizontalAlignment.Right, enmVerticalAlignment.Center)
        TopP.Y += BarAreaSize.Height + UH / 2 + HeadBoxSize.Height
        If PData.MissingValueNum > 0 And attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True Then
            With attrData.TotalData.ViewStyle.Missing_Data
                Dim r2 As Integer = attrData.Radius(.MarkBar.WordFont.Body.Size, 1, 1)
                Dim mp As Point = TopP
                mp.Offset(r2 + UH, r2 + UH)
                attrData.Draw_Mark(g, mp, r2, .MarkBar)
                mp.Offset(r2 * 1.5, 0)
                attrData.Draw_Print(g, .Text, mp, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
            End With
        End If

        Return True
    End Function
    ''' <summary>
    ''' 文字モードの凡例
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_StringMode(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                         ByVal ALP As Point, ByRef HeadBoxSize As Size, ByVal UnitTx As String,
                                         ByVal Layn2 As Integer, ByVal datn2 As Integer,
                                         ByVal SizeGetOnlyF As Boolean) As Boolean

        Dim PData As clsAttrData.strData_info = attrData.LayerData(Layn2).atrData.Data(datn2)

        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim UH As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        Dim hnfont As Font = New Font(LFont.Body.Name, UH, GraphicsUnit.Pixel)

        Dim Unx As String = attrData.Get_DataUnit_With_Kakko(Layn2, datn2)
        If Unx = "" Then
            Return False
        End If
        Dim size2 As Size = HeadBoxSize
        size2.Width = Math.Max(size2.Width, g.MeasureString(Unx, hnfont).Width)
        size2.Height += UH
        If SizeGetOnlyF = True Then
            HeadBoxSize = size2
            Return False
        End If
        Dim C_Rect As Rectangle = New Rectangle(ALP, size2)
        If attrData.Check_Screen_In(C_Rect) = False Then
            Return False
        End If
        LegendBoxBack(g, attrData, C_Rect)
        Dim tP As Point = ALP
        tP.Y += UH
        attrData.Draw_Print(g, Unx, tP, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
        Return True
    End Function
    ''' <summary>
    ''' 記号の数モードの凡例
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="ALP"></param>
    ''' <param name="HeadBoxSize"></param>
    ''' <param name="UnitTx"></param>
    ''' <param name="Layn2"></param>
    ''' <param name="datn2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_MarkBlockMode(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                         ByVal ALP As Point, ByRef HeadBoxSize As Size, ByVal UnitTx As String,
                                         ByVal Layn2 As Integer, ByVal datn2 As Integer,
                                         ByVal SizeGetOnlyF As Boolean) As Boolean

        Dim PData As clsAttrData.strData_info = attrData.LayerData(Layn2).atrData.Data(datn2)
        Dim MkCommon As clsAttrData.strMarkCommon_Data = attrData.LayerData(Layn2).atrData.Data(datn2).SoloModeViewSettings.MarkCommon

        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim UH As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        Dim hnfont As Font = New Font(LFont.Body.Name, UH, GraphicsUnit.Pixel)

        Dim B_Md As clsAttrData.strMarkBlock_Data = PData.SoloModeViewSettings.MarkBlockMD

        Dim size2 As Size = HeadBoxSize

        Dim r As Integer = attrData.Radius(B_Md.Mark.WordFont.Body.Size, 1, 1)
        spatial.Get_TurnedBox(r, r, B_Md.Mark.WordFont.Body.Kakudo, r, r)
        Dim in1 As String = clsSettings.Data.LegendBlockmodeWord
        Dim LegendWord As String = attrData.LayerData(Layn2).atrData.Data(datn2).SoloModeViewSettings.MarkBlockMD.LegendBlockModeWord
        If LegendWord <> "" Then
            in1 = LegendWord
        End If
        Dim in2 As String = "　" + CStr(clsGeneric.Figure_Using_Solo(B_Md.Value, attrData.TotalData.ViewStyle.MapLegend.Base.Comma_f)) + UnitTx
        Dim leftMargin As Single = r * 2.5
        If B_Md.ArrangeB = clsAttrData.enmMarkBlockArrange.PolygonRandom Then
            leftMargin = UH
        End If
        size2.Width = Math.Max(size2.Width, g.MeasureString(in1, hnfont).Width + leftMargin)
        size2.Width = Math.Max(size2.Width, g.MeasureString(in2, hnfont).Width + leftMargin)
        size2.Height += Math.Max(r * 2.1, UH * 2)
        Dim MinusWord As String
        Dim PlusWord As String
        With attrData.LayerData(Layn2).atrData.Data(datn2).SoloModeViewSettings.MarkCommon
            MinusWord = getLegendMinusWord(.LegendMinusWord)
            PlusWord = getLegendPlusWord(.LegendPlusWord)
        End With

        If PData.Statistics.Min < 0 Then
            Dim pmw As Integer = Math.Max(g.MeasureString(PlusWord, hnfont).Width,
                               g.MeasureString(MinusWord, hnfont).Width)
            size2.Width = Math.Max(size2.Width, r * 2.5 + pmw)
            Dim yy As Integer = Math.Max(r * 2, UH)
            size2.Height *= 1.5
            size2.Height += yy * 2
        End If
        If PData.MissingValueNum > 0 And attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True Then
            size2.Height += UH * 0.5 + Math.Max(attrData.Radius(attrData.TotalData.ViewStyle.Missing_Data.BlockMark.WordFont.Body.Size, 1, 1) * 2, UH)
        End If
        If SizeGetOnlyF = True Then
            HeadBoxSize = size2
            Return False
        End If
        Dim C_Rect As Rectangle = New Rectangle(ALP, size2)
        If attrData.Check_Screen_In(C_Rect) = False Then
            Return False
        End If

        'ここまで範囲調べ、以降描画

        LegendBoxBack(g, attrData, C_Rect)

        size2 = HeadBoxSize
        Dim ax As Integer = r * 1.1
        Dim ay As Integer = HeadBoxSize.Height + r * 1.1
        Dim MKP As Point = ALP
        Dim MKR As Integer = attrData.Radius(B_Md.Mark.WordFont.Body.Size, 1, 1)
        If B_Md.ArrangeB = clsAttrData.enmMarkBlockArrange.PolygonRandom Then
            Dim Rand As New System.Random()
            Dim rp(4) As PointF
            rp(0).X = 0.3
            rp(0).Y = 0.2
            rp(1).X = 0.74
            rp(1).Y = 0.25
            rp(2).X = 0.58
            rp(2).Y = 0.48
            rp(3).X = 0.28
            rp(3).Y = 0.75
            rp(4).X = 0.7
            rp(4).Y = 0.72
            Dim brush = New SolidBrush(B_Md.Mark.Tile.Line.BasicLine.SolidLine.Color.getColor)
            For i As Integer = 0 To 4
                Dim p As Point
                p.X = rp(i).X * UH
                p.Y = rp(i).Y * UH
                Dim np As Point = MKP
                np.Offset(p)
                If MKR <> 0 Then
                    attrData.Draw_Mark(g, np, MKR, B_Md.Mark)
                Else
                    g.FillRectangle(Brush, np.X, np.Y, 1, 1)
                End If
            Next
        Else
            MKP.Offset(ax, ay)
            attrData.Draw_Mark(g, MKP, MKR, B_Md.Mark)
        End If
        Dim DP1 As Point = ALP
        size2 = HeadBoxSize
        DP1.Offset(leftMargin, size2.Height)
        Dim DP2 As Point = DP1
        DP2.Offset(0, UH)
        attrData.Draw_Print(g, in1, DP1, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
        attrData.Draw_Print(g, in2, DP2, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
        size2.Width = Math.Max(size2.Width, g.MeasureString(in1, hnfont).Width + r * 2.5)
        size2.Width = Math.Max(size2.Width, g.MeasureString(in2, hnfont).Width)
        size2.Height += Math.Max(r * 2.1, UH * 2)

        If PData.Statistics.Min < 0 Then
            Dim yy As Integer = Math.Max(r * 2, UH)
            size2.Height *= 1.5
            Dim pP As Point = ALP
            pP.Offset(ax, size2.Height)
            attrData.Draw_Mark(g, pP, MKR, B_Md.Mark)
            Dim mP As Point = ALP
            mP.Offset(ax, size2.Height + yy)
            Dim PushMK = B_Md.Mark
            PushMK.Tile = MkCommon.MinusTile
            attrData.Draw_Mark(g, mP, MKR, PushMK)

            Dim tP1 As Point = ALP
            tP1.Offset(r * 2.5, size2.Height - UH / 2)
            Dim tP2 As Point = tP1
            tP2.Offset(0, yy)
            attrData.Draw_Print(g, PlusWord, tP1, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
            attrData.Draw_Print(g, MinusWord, tP2, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)

            size2.Height += yy * 2
        End If
        If PData.MissingValueNum > 0 And attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True Then
            With attrData.TotalData.ViewStyle.Missing_Data
                Dim r2 As Integer = attrData.Radius(.BlockMark.WordFont.Body.Size, 1, 1)
                Dim myy As Integer = Math.Max(r2, UH / 2)
                Dim mp As Point = ALP
                mp.Offset(ax, size2.Height + myy + UH * 0.5)
                attrData.Draw_Mark(g, mp, r2, .BlockMark)
                size2.Height += UH * 0.5 + myy * 2

                Dim tp = New Point(ALP.X + r * 2.5, mp.Y)
                attrData.Draw_Print(g, .Text, tp, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
            End With
        End If
        Return True
    End Function
    ''' <summary>
    ''' 記号モードの凡例数値を並べ替えて返す
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <param name="Legend_Val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_CircleModeLegendValue(ByRef attrData As clsAttrData, Layernum As Integer, ByVal DataNum As Integer, ByRef Legend_Val() As Double) As Integer

        Dim PData As clsAttrData.strData_info = attrData.LayerData(Layernum).atrData.Data(DataNum)
        ReDim Legend_Val(4)
        Legend_Val = PData.SoloModeViewSettings.MarkSizeMD.Value.Clone
        With PData.SoloModeViewSettings.MarkSizeMD
            Dim checked = False
            If .MaxValueMode = clsAttrData.enmMarkSizeValueMode.UserDefinition Then
                For i As Integer = 0 To Legend_Val.Length - 1
                    If Legend_Val(i) > .MaxValue Then
                        If checked = False Then
                            Legend_Val(i) = .MaxValue
                            checked = True
                        Else
                            Legend_Val(i) = 0
                        End If
                    End If
                Next
            End If

        End With

        Array.Sort(Legend_Val)
        Array.Reverse(Legend_Val)
        Dim LegendVn As Integer = 0
        For i As Integer = 0 To Legend_Val.Length - 1
            If Legend_Val(i) <= 0 Then
                Exit For
            Else
                LegendVn += 1
            End If
        Next

        Return LegendVn
    End Function

    Private Shared Function UNIT_P(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                   ByVal pos As Point, ByVal V As Double, ByVal UnitTx As String,
                                   ByVal i As Integer, ByVal print_f As Boolean) As Integer
        Dim vv As String = clsGeneric.Figure_Using_Solo(V, attrData.TotalData.ViewStyle.MapLegend.Base.Comma_f)
        If i = 0 Then
            vv += UnitTx
        End If
        If print_f = True Then
            attrData.Draw_Print(g, vv, pos, attrData.TotalData.ViewStyle.MapLegend.Base.Font, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
        End If
        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim UH As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        Dim hnfont As Font = New Font(LFont.Body.Name, UH, GraphicsUnit.Pixel)
        Dim w As Integer = g.MeasureString(vv, hnfont).Width
        hnfont.Dispose()
        Return w
    End Function
    ''' <summary>
    ''' 円をコンパクトにまとめる凡例を描き、幅を返す
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="pos"></param>
    ''' <param name="RMAX"></param>
    ''' <param name="Va"></param>
    ''' <param name="UnitTx"></param>
    ''' <param name="EN_Size"></param>
    ''' <param name="LP"></param>
    ''' <param name="tp"></param>
    ''' <param name="Ys"></param>
    ''' <param name="xs"></param>
    ''' <param name="Print_Flag"></param>
    ''' <remarks></remarks>
    Private Shared Sub OverCircle_Print(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                        ByVal pos As Point, ByVal RMAX As Double, ByVal Va() As Double,
                                        ByVal UnitTx As String, ByVal EN_Size As Single, ByVal LP As Line_Property,
                                        ByVal tp As Tile_Property, ByRef Ys As Integer, ByRef xs As Integer,
                                        ByVal Print_Flag As Boolean)

        Dim MP As Mark_Property

        MP.ShapeNumber = 0
        MP.Tile = tp
        MP.Line = LP
        MP.WordFont.Back.Tile.TileCode = enmTilePattern.Blank
        MP.WordFont.Back.Line.BasicLine.pattern = enmLinePattern.InVisible
        MP.WordFont.Back.Round = 0
        Dim TH As Integer = attrData.Get_Length_On_Screen(attrData.TotalData.ViewStyle.MapLegend.Base.Font.Body.Size)
        Dim rx As Integer = attrData.Radius(EN_Size, Va(0), RMAX) * 1.1
        Dim xss As Integer = 0
        Dim yss As Integer = 0
        Dim x2 As Integer = rx * 3
        Dim OLY2 As Integer = pos.Y
        Dim cy As Integer
        For i As Integer = 0 To Va.Length - 1
            Dim val As Double = Va(i)
            If val > 0 Then
                Dim r As Integer = attrData.Radius(EN_Size, val, RMAX)
                cy = rx * 2 - r + TH / 2
                If Print_Flag = True Then
                    attrData.Draw_Mark(g, New Point(pos.X + rx, pos.Y + cy), r, MP)
                End If
                If i = 0 Then
                    yss = cy - r - TH / 2
                End If
                Dim lx1 As Integer = pos.X + rx
                Dim lx2 As Integer = pos.X + rx * 2.7 - i * (rx * 2.9 - rx) / 10
                Dim LX3 As Integer = lx2 + rx * 0.2 + i * (rx * 2.9 - rx) / 10
                Dim ly1 As Integer = pos.Y + cy - r
                Dim ly2 As Integer = ly1
                If ly2 < OLY2 Then
                    ly2 = OLY2
                End If
                Dim VL As Integer = UNIT_P(g, attrData, New Point(pos.X + x2, ly2 - TH / 2), val, UnitTx, i, Print_Flag)
                xss = Math.Max(xss, x2 + VL)
                If Print_Flag = True Then
                    With attrData.TotalData.ViewStyle.MapLegend.MarkMD
                        attrData.Draw_Line(g, .MultiEnMode_Line, New Point(lx1, ly1), New Point(lx2, ly1))
                        attrData.Draw_Line(g, .MultiEnMode_Line, New Point(lx2, ly1), New Point(lx2, ly2))
                        attrData.Draw_Line(g, .MultiEnMode_Line, New Point(lx2, ly2), New Point(LX3, ly2))
                    End With
                End If
                yss = yss + TH
                OLY2 = ly2 + TH
            End If
        Next
        xs = xss
        Ys = Math.Max(yss, cy + rx)
    End Sub
    ''' <summary>
    ''' 記号の大きさモードの凡例
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="ALP"></param>
    ''' <param name="HeadBoxSize"></param>
    ''' <param name="UnitTx"></param>
    ''' <param name="Layn2"></param>
    ''' <param name="datn2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_MarkSizeMode(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                         ByVal ALP As Point, ByRef HeadBoxSize As Size, ByVal UnitTx As String,
                                         ByVal Layn2 As Integer, ByVal datn2 As Integer,
                                         ByVal SizeGetOnlyF As Boolean) As Boolean

        Dim PData As clsAttrData.strData_info = attrData.LayerData(Layn2).atrData.Data(datn2)
        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim UH As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        Dim hnfont As Font = New Font(LFont.Body.Name, UH, GraphicsUnit.Pixel)
        Dim WordsX As Integer
        Dim ys2 As Single
        Dim Legend_Val() As Double
        Dim LegendVn As Integer = Get_CircleModeLegendValue(attrData, Layn2, datn2, Legend_Val)
        Dim MkCommon As clsAttrData.strMarkCommon_Data = attrData.LayerData(Layn2).atrData.Data(datn2).SoloModeViewSettings.MarkCommon
        Dim MinusWord As String
        Dim PlusWord As String
        With MkCommon
            MinusWord = getLegendMinusWord(.LegendMinusWord)
            PlusWord = getLegendPlusWord(.LegendPlusWord)
        End With

        Dim LayerShape As enmShape = attrData.LayerData(Layn2).Shape
        With PData.SoloModeViewSettings.MarkSizeMD
            Dim RMAXV As Double
            If .MaxValueMode = clsAttrData.enmMarkSizeValueMode.inDataItem Then
                RMAXV = Math.Max(Math.Abs(attrData.Get_DataMax(Layn2, datn2)), Math.Abs(attrData.Get_DataMin(Layn2, datn2)))
            Else
                RMAXV = .MaxValue
            End If
            Dim shapexs As Integer
            Dim xs As Integer = HeadBoxSize.Width
            Dim Ys As Integer = HeadBoxSize.Height
            ys2 = HeadBoxSize.Height

            If LayerShape = enmShape.LineShape Then
                shapexs = attrData.Get_Length_On_Screen(8)
            Else
                Dim maxr As Integer = attrData.Radius(.Mark.WordFont.Body.Size, Legend_Val(0), RMAXV)
                spatial.Get_TurnedBox(maxr, maxr, .Mark.WordFont.Body.Kakudo, maxr, maxr)
                shapexs = 2 * maxr
            End If
            Dim AllXs As Integer
            If LayerShape <> enmShape.LineShape And .Mark.PrintMark = 0 And .Mark.ShapeNumber = 0 And attrData.TotalData.ViewStyle.MapLegend.MarkMD.CircleMD_CircleMini_F = True Then
                '円の大きさでコンパクトの場合の縦横
                Dim xcs As Integer
                Dim ycs As Integer
                OverCircle_Print(g, attrData, New Point(ALP.X, ALP.Y + Ys), RMAXV, Legend_Val, UnitTx, .Mark.WordFont.Body.Size, .Mark.Line, .Mark.Tile, ycs, xcs, False)
                AllXs = Math.Max(xs, xcs)
                Ys += ycs
            Else
                '凡例文字の幅比較
                WordsX = shapexs + g.MeasureString(" ", hnfont).Width
                Dim xsWords As Integer = 0
                For i As Integer = 0 To LegendVn - 1
                    Dim fw As String = clsGeneric.Figure_Using_Solo(Legend_Val(i), attrData.TotalData.ViewStyle.MapLegend.Base.Comma_f)
                    If i = 0 Then
                        fw += UnitTx
                    End If
                    xsWords = Math.Max(xsWords, g.MeasureString(fw, hnfont).Width)
                Next
                AllXs = WordsX + xsWords
                '凡例記号の高さ加算
                For i As Integer = 0 To LegendVn - 1
                    If LayerShape = enmShape.LineShape Then
                        Dim r As Integer = attrData.Get_Length_On_Screen(Legend_Val(i) / RMAXV * .LineShape.LineWidth)
                        Ys += Math.Max(r + UH / 2, UH * 1.5)
                    Else
                        Dim r As Integer = attrData.Radius(.Mark.WordFont.Body.Size, Legend_Val(i), RMAXV)
                        spatial.Get_TurnedBox(r, r, .Mark.WordFont.Body.Kakudo, r, r)
                        Ys += Math.Max(r * 2 + UH / 2, UH)
                    End If
                Next
            End If
            If PData.Statistics.Min < 0 And (MkCommon.Inner_Data.Flag = False Or MkCommon.Inner_Data.Mode = clsAttrData.enmInner_Data_Info_Mode.ClassHatch) Then
                '正の数負の数の幅計算
                ' If .Mark.PrintMark = 1 Then MKCN = 0
                Ys += UH

                Dim pmw As Integer = Math.Max(g.MeasureString(PlusWord, hnfont).Width,
                                       g.MeasureString(MinusWord, hnfont).Width)

                Select Case LayerShape
                    Case enmShape.PolygonShape, enmShape.PointShape
                        Ys += UH * 2
                        Dim r As Integer = UH / 2
                        AllXs = Math.Max(AllXs, r * 2 + r * 1.5 + pmw)
                    Case enmShape.LineShape
                        Ys += UH * 2
                        AllXs = Math.Max(AllXs, shapexs + pmw)
                End Select
            End If
            If PData.MissingValueNum > 0 And attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True Then
                '欠損値の凡例計算
                With attrData.TotalData.ViewStyle.Missing_Data
                    Dim MKR As Integer = attrData.Radius(.Mark.WordFont.Body.Size, 1, 1)
                    Select Case LayerShape
                        Case enmShape.PolygonShape, enmShape.PointShape
                            AllXs = Math.Max(AllXs, MKR + MKR * 2 + g.MeasureString(.Text, hnfont).Width)
                            Ys += UH * 0.5 + Math.Max(MKR * 2, UH)
                        Case enmShape.LineShape
                            If .LineShape.BasicLine.pattern <> -1 Then
                                AllXs = Math.Max(AllXs, shapexs + g.MeasureString(.Text, hnfont).Width)
                                Ys += Math.Max(UH, .LineShape.Get_Max_LineWidth() * 2) * 1.5
                            End If
                    End Select
                End With
            End If
            HeadBoxSize = New Size(AllXs, Ys)
            If SizeGetOnlyF = True Then
                Return False
            End If
            Dim C_Rect As Rectangle = New Rectangle(ALP, HeadBoxSize)
            If attrData.Check_Screen_In(C_Rect) = False Then
                Return False
            End If

            '--------描画
            LegendBoxBack(g, attrData, C_Rect)

            If LayerShape <> enmShape.LineShape And (.Mark.PrintMark = 0 And .Mark.ShapeNumber = 0) And
                attrData.TotalData.ViewStyle.MapLegend.MarkMD.CircleMD_CircleMini_F = True Then
                Dim xcs As Integer
                Dim ycs As Integer
                OverCircle_Print(g, attrData, New Point(ALP.X, ALP.Y + ys2), RMAXV, Legend_Val, UnitTx, .Mark.WordFont.Body.Size, .Mark.Line, .Mark.Tile, ycs, xcs, True)
                ys2 += ycs
            Else
                Dim HL As Integer = shapexs / 2
                'MKCN = .Mark.ShapeNumber
                For i As Integer = 0 To LegendVn - 1
                    Dim r As Integer
                    If LayerShape = enmShape.LineShape Then
                        r = Legend_Val(i) / RMAXV * .LineShape.LineWidth
                    Else
                        r = attrData.Radius(.Mark.WordFont.Body.Size, Legend_Val(i), RMAXV)
                        spatial.Get_TurnedBox(r, r, .Mark.WordFont.Body.Kakudo, r, r)
                    End If
                    Dim cyplus As Integer = Math.Max(r, UH / 2)
                    Select Case LayerShape
                        Case enmShape.PolygonShape, enmShape.PointShape
                            Dim MKP As Point = New Point(ALP.X + HL, ALP.Y + ys2 + cyplus)
                            Dim MKR As Integer = attrData.Radius(.Mark.WordFont.Body.Size, Legend_Val(i), RMAXV)
                            attrData.Draw_Mark(g, MKP, MKR, .Mark)
                        Case enmShape.LineShape
                            Dim Line_Pat As Line_Property = clsBase.Line
                            Line_Pat.Set_Same_ColorWidth_to_LinePat(.LineShape.Color, r)
                            Line_Pat.Edge_Connect_Pattern = .Mark.Line.Edge_Connect_Pattern
                            Dim P1 As New Point(ALP.X + r, ALP.Y + ys2 + cyplus)
                            Dim P2 As New Point(ALP.X + shapexs + 1 - r, ALP.Y + ys2 + cyplus)
                            attrData.Draw_Line(g, Line_Pat, P1, P2)
                            HL = shapexs / 2
                    End Select

                    Dim fw As String = clsGeneric.Figure_Using_Solo(Legend_Val(i), attrData.TotalData.ViewStyle.MapLegend.Base.Comma_f)
                    If i = 0 Then
                        fw += UnitTx
                    End If
                    Dim P As New Point(ALP.X + WordsX, ALP.Y + ys2 + cyplus)
                    attrData.Draw_Print(g, fw, P, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
                    ys2 += Math.Max(r * 2 + UH / 2, UH * 1.5)
                Next
            End If

            If PData.Statistics.Min < 0 And (MkCommon.Inner_Data.Flag = False Or MkCommon.Inner_Data.Mode = clsAttrData.enmInner_Data_Info_Mode.ClassHatch) Then
                ys2 += UH
                Dim r As Integer = UH / 2.2
                Select Case LayerShape
                    Case enmShape.PolygonShape, enmShape.PointShape
                        Dim P As New Point(ALP.X + r, ALP.Y + ys2)
                        attrData.Draw_Mark(g, P, r, .Mark)
                        P.Y = ALP.Y + ys2 + UH
                        Dim PushMark = .Mark
                        PushMark.Tile = MkCommon.MinusTile
                        attrData.Draw_Mark(g, P, r, PushMark)
                        Dim p2 As New Point(P.X + r * 1.5, ALP.Y + ys2 - UH / 2)
                        Dim p3 As Point = p2
                        p3.Y += UH
                        attrData.Draw_Print(g, PlusWord, p2, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
                        attrData.Draw_Print(g, MinusWord, p3, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
                        ys2 += UH * 2
                    Case enmShape.LineShape
                        Dim Lpat As Line_Property = clsBase.Line
                        Lpat.Set_Same_ColorWidth_to_LinePat(MkCommon.MinusTile.Line.BasicLine.SolidLine.Color, LFont.Body.Size / 5)
                        Dim p1 As New Point(ALP.X + r, ALP.Y + ys2)
                        Dim p2 As New Point(ALP.X + shapexs - r, ALP.Y + ys2)
                        attrData.Draw_Line(g, Lpat, p1, p2)
                        Dim p3 As New Point(ALP.X + r, ALP.Y + ys2 + r * 2.5)
                        Dim p4 As New Point(ALP.X + shapexs - r, ALP.Y + ys2 + r * 2.5)
                        Lpat.Set_Same_ColorWidth_to_LinePat(MkCommon.MinusTile.Line.BasicLine.SolidLine.Color, LFont.Body.Size / 5)
                        attrData.Draw_Line(g, Lpat, p3, p4)
                        Dim p5 As New Point(ALP.X + shapexs, ALP.Y + ys2 - UH / 2)
                        Dim p6 As New Point(ALP.X + shapexs, ALP.Y + ys2 - UH / 2 + r * 2.5)
                        attrData.Draw_Print(g, PlusWord, p5, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
                        attrData.Draw_Print(g, MinusWord, p6, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
                        ys2 += UH * 2
                End Select
            End If
            If PData.MissingValueNum > 0 And attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True Then
                '欠損値の凡例描画
                With attrData.TotalData.ViewStyle.Missing_Data
                    Select Case LayerShape
                        Case enmShape.PolygonShape, enmShape.PointShape
                            Dim MKR As Integer = attrData.Radius(.Mark.WordFont.Body.Size, 1, 1)
                            Dim yy As Integer = Math.Max(MKR, UH / 2)
                            Dim p As New Point(ALP.X + MKR, ALP.Y + ys2 + yy + UH * 0.5)
                            attrData.Draw_Mark(g, p, MKR, .Mark)
                            ys2 += UH * 0.5 + yy * 2
                            Dim p2 As New Point(p.X + MKR * 2, p.Y)
                            attrData.Draw_Print(g, .Text, p2, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
                        Case enmShape.LineShape
                            If .LineShape.BasicLine.pattern <> enmLinePattern.InVisible Then
                                Dim r As Integer
                                Dim MaxLW = attrData.Get_Length_On_Screen(.LineShape.Get_Max_LineWidth())
                                If .LineShape.Edge_Connect_Pattern.Edge_Pattern = 2 Then
                                    r = 0
                                Else
                                    r = MaxLW
                                End If
                                Dim P1 As New Point(ALP.X + r, ALP.Y + ys2 + Math.Max(UH, MaxLW))
                                Dim P2 As New Point(ALP.X + shapexs - r, P1.Y)
                                attrData.Draw_Line(g, .LineShape, P1, P2)
                                Dim P3 As New Point(ALP.X + shapexs, P1.Y)
                                attrData.Draw_Print(g, .Text, P3, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
                            End If
                    End Select
                End With
            End If

        End With
        Return True
    End Function
    ''' <summary>
    ''' 凡例の背景塗りつぶし
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Rect"></param>
    ''' <remarks></remarks>
    Private Shared Sub LegendBoxBack(ByRef g As Graphics, ByRef attrData As clsAttrData, ByVal C_Rect As Rectangle)

        attrData.Draw_Tile_RoundBox(g, C_Rect, attrData.TotalData.ViewStyle.MapLegend.Base.Back, 0)

    End Sub
    ''' <summary>
    ''' 階級記号モードの凡例
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="ALP"></param>
    ''' <param name="HeadBoxSize"></param>
    ''' <param name="UnitTx"></param>
    ''' <param name="Layn2"></param>
    ''' <param name="datn2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_ClassMarkMode(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                         ByVal ALP As Point, ByRef HeadBoxSize As Size, ByVal UnitTx As String,
                                         ByVal Layn2 As Integer, ByVal datn2 As Integer,
                                         ByVal SizeGetOnlyF As Boolean) As Boolean

        Dim PData As clsAttrData.strData_info = attrData.LayerData(Layn2).atrData.Data(datn2)
        Dim Class_div() As clsAttrData.strClass_Div_data = PData.SoloModeViewSettings.Class_Div

        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim UH As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        Dim hnfont As Font = New Font(LFont.Body.Name, UH, GraphicsUnit.Pixel)
        Dim Div_Num As Integer = PData.SoloModeViewSettings.Div_Num


        Dim ww As Integer
        Dim hh As Integer
        Dim hu As Integer
        Dim bxw As Integer
        Dim byh As Integer
        Dim vn As Integer
        Dim sujiW As Integer
        Dim freqW As Integer
        Dim LL As Integer
        Dim RR As Integer
        Paint_Tile_Word_Set(g, attrData, ww, hh, hu, bxw, byh, vn, sujiW, freqW, LL, RR, UnitTx, Layn2, datn2, False)

        Dim inBox As Size = New Size(bxw, 0)
        Dim ysize(Div_Num - 1) As Integer
        Dim acumy As Integer = 0
        For i As Integer = 0 To Div_Num - 1
            With Class_div(i).ClassMark
                Dim w2 As Integer
                Dim h2 As Integer
                If .PrintMark = 1 Then
                    Dim wft As Font = New Font(.WordFont.Body.Name, attrData.Get_Length_On_Screen(.WordFont.Body.Size), GraphicsUnit.Pixel)
                    w2 = g.MeasureString(.wordmark, wft).Width + byh * 0.5
                    h2 = g.MeasureString(.wordmark, wft).Height
                Else
                    w2 = attrData.Radius(.WordFont.Body.Size, 1, 1) * 2 + byh * 0.5
                    h2 = w2
                End If
                spatial.Get_TurnedBox(w2, h2, .WordFont.Body.Kakudo, w2, h2)
                inBox.Width = Math.Max(inBox.Width, w2)
                ysize(i) = Math.Max(h2, byh)
                acumy += ysize(i)
            End With
        Next

        Dim bxwy As Integer = 0
        If GetClassMethod(attrData, Layn2, datn2, False) = enmClassMode_Meshod.Separated Then
            bxwy = byh * attrData.TotalData.ViewStyle.MapLegend.ClassMD.SeparateGapSize
        End If

        HeadBoxSize.Width = Math.Max(HeadBoxSize.Width, inBox.Width + sujiW + ww / 2 + freqW)

        Dim ysize2 As Integer = HeadBoxSize.Height + acumy + hu + (Div_Num - 1) * bxwy
        inBox.Height = ysize2
        If PData.MissingValueNum > 0 And attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True Then
            With attrData.TotalData.ViewStyle.Missing_Data
                Dim H As Integer
                If .ClassMark.PrintMark = enmMarkPrintType.Word Then
                    Dim wft As Font = New Font(.ClassMark.WordFont.Body.Name, attrData.Get_Length_On_Screen(.ClassMark.WordFont.Body.Size), GraphicsUnit.Pixel)
                    H = g.MeasureString(.ClassMark.wordmark, wft).Height
                Else
                    H = attrData.Radius(.ClassMark.WordFont.Body.Size, 1, 1) * 2
                End If
                ysize2 += H + byh
            End With
        End If
        If SizeGetOnlyF = True Then
            HeadBoxSize.Height = ysize2
            Return False
        End If

        Dim C_Rect As Rectangle = New Rectangle(ALP, New Size(HeadBoxSize.Width, ysize2))
        If attrData.Check_Screen_In(C_Rect) = False Then
            Return False
        End If

        LegendBoxBack(g, attrData, C_Rect)

        acumy = 0
        For i As Integer = 0 To Div_Num - 1
            If attrData.TotalData.ViewStyle.MapLegend.ClassMD.ClassMarkFrame_Visible = True Then
                Dim rect As Rectangle = New Rectangle(New Point(ALP.X, ALP.Y + acumy + hu + HeadBoxSize.Height),
                                                      New Size(inBox.Width + 1, ysize(i) + 1))
                Dim TilePat As Tile_Property = clsBase.Tile
                TilePat.Line.BasicLine.SolidLine.Color = New colorARGB(Color.White)
                attrData.Draw_Tile_Box(g, rect, 0, attrData.TotalData.ViewStyle.MapLegend.ClassMD.PaintMode_Line, TilePat)
            End If
            Dim r As Integer = attrData.Radius(Class_div(i).ClassMark.WordFont.Body.Size, 1, 1)
            Dim p As Point = New Point(ALP.X + inBox.Width / 2, ALP.Y + acumy + ysize(i) / 2 + hu + HeadBoxSize.Height)
            attrData.Draw_Mark(g, p, r, Class_div(i).ClassMark)
            acumy += ysize(i) + bxwy
        Next
        attrData.Draw_Print(g, UnitTx, New Point(ALP.X + inBox.Width, ALP.Y + HeadBoxSize.Height), LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)

        If GetClassMethod(attrData, Layn2, datn2, False) = enmClassMode_Meshod.Separated Or PData.DataType = enmAttDataType.Category Then
            acumy = 0
            For i As Integer = 0 To vn
                Dim fu As String
                If PData.DataType = enmAttDataType.Category Then
                    fu = Class_div(i).Cat_Name
                Else
                    fu = Get_SeparateClassWords(attrData, Class_div, i, Div_Num, LL, RR)
                End If
                Dim p As Point = New Point(ALP.X + inBox.Width + ww / 2, ALP.Y + acumy + ysize(i) / 2 + hu + HeadBoxSize.Height)
                attrData.Draw_Print(g, fu, p, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
                acumy += ysize(i) + bxwy
            Next
        Else
            acumy = 0
            For i As Integer = 0 To Div_Num - 2
                Dim fu As String
                fu = clsGeneric.Figure_Using(Class_div(i).Value, LL, RR, attrData.TotalData.ViewStyle.MapLegend.Base.Comma_f)
                Dim p As Point = New Point(ALP.X + inBox.Width + ww / 2, ALP.Y + acumy + ysize(i) + hu + HeadBoxSize.Height)
                attrData.Draw_Print(g, fu, p, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
                acumy += ysize(i) + bxwy
            Next
        End If

        Dim freq() As Integer, missFreq As Integer
        If attrData.TotalData.ViewStyle.MapLegend.ClassMD.FrequencyPrint = True Then
            '度数分布
            If attrData.Get_ClassFrequency(Layn2, datn2, True, freq, missFreq) = True Then
                acumy = 0
                For i As Integer = 0 To freq.Count - 1
                    Dim cwp As Point
                    cwp.Y = ALP.Y + acumy + ysize(i) / 2 + hu + HeadBoxSize.Height
                    cwp.X = ALP.X + inBox.Width + ww / 2 + sujiW
                    attrData.Draw_Print(g, "(" + freq(i).ToString + ")", cwp, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
                    acumy += ysize(i) + bxwy
                Next
            End If
        End If

        If PData.MissingValueNum > 0 And attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True Then
            With attrData.TotalData.ViewStyle.Missing_Data
                Dim H As Integer
                If .ClassMark.PrintMark = enmMarkPrintType.Word Then
                    Dim wft As Font = New Font(.ClassMark.WordFont.Body.Name, attrData.Get_Length_On_Screen(.ClassMark.WordFont.Body.Size), GraphicsUnit.Pixel)
                    H = g.MeasureString(.ClassMark.wordmark, wft).Height
                Else
                    H = attrData.Radius(.ClassMark.WordFont.Body.Size, 1, 1) * 2
                End If
                Dim y2 As Integer = ALP.Y + inBox.Height + byh / 2 + HeadBoxSize.Height
                If attrData.TotalData.ViewStyle.MapLegend.ClassMD.ClassMarkFrame_Visible = True Then
                    Dim TilePat As Tile_Property = clsBase.Tile
                    TilePat.Line.BasicLine.SolidLine.Color = New colorARGB(Color.White)
                    Dim rect As Rectangle = New Rectangle(New Point(ALP.X, y2), New Size(inBox.Width + 1, H + 1))
                    attrData.Draw_Tile_Box(g, rect, 0, attrData.TotalData.ViewStyle.MapLegend.ClassMD.PaintMode_Line, TilePat)
                End If
                Dim p As Point = New Point(ALP.X + inBox.Width / 2, y2 + H / 2)
                attrData.Draw_Mark(g, p, attrData.Radius(.ClassMark.WordFont.Body.Size, 1, 1), .ClassMark)
                p = New Point(ALP.X + inBox.Width + ww / 2, y2 + H / 2)
                attrData.Draw_Print(g, .Text, p, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
                If attrData.TotalData.ViewStyle.MapLegend.ClassMD.FrequencyPrint = True Then
                    Dim cwp As Point
                    cwp.Y = p.Y
                    cwp.X = ALP.X + inBox.Width + ww / 2 + sujiW
                    attrData.Draw_Print(g, "(" + missFreq.ToString + ")", cwp, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
                End If
            End With
        End If

        HeadBoxSize.Height = ysize2
        Return True
    End Function
    ''' <summary>
    ''' 線形状オブジェクトのペイントモードの凡例
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="ALP"></param>
    ''' <param name="HeadBoxSize"></param>
    ''' <param name="UnitTx"></param>
    ''' <param name="Layn2"></param>
    ''' <param name="datn2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_ClassPaint_LineShape(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                         ByVal ALP As Point, ByRef HeadBoxSize As Size, ByVal UnitTx As String,
                                         ByVal Layn2 As Integer, ByVal datn2 As Integer,
                                         ByVal SizeGetOnlyF As Boolean) As Boolean

        Dim PData As clsAttrData.strData_info = attrData.LayerData(Layn2).atrData.Data(datn2)

        Dim PointLayerMark As clsAttrData.strLayerPointLineShape_Data = attrData.LayerData(Layn2).LayerModeViewSettings.PointLineShape

        Dim dvn As Integer = PData.SoloModeViewSettings.Div_Num
        Dim LinePush(dvn - 1) As Line_Property
        For i As Integer = 0 To dvn - 1
            LinePush(i) = PData.SoloModeViewSettings.Class_Div(i).ODLinePat
        Next

        For i As Integer = 0 To dvn - 1
            With PData.SoloModeViewSettings.Class_Div(i)
                .ODLinePat = clsBase.Line
                .ODLinePat.Set_Same_ColorWidth_to_LinePat(.PaintColor, PointLayerMark.LineWidth)
                .ODLinePat.Edge_Connect_Pattern = PointLayerMark.LineEdge
            End With
        Next

        Dim screen_in_f As Boolean = Draw_ClassODModeMode(g, attrData, ALP, HeadBoxSize, UnitTx, Layn2, datn2, SizeGetOnlyF)

        For i As Integer = 0 To dvn - 1
            PData.SoloModeViewSettings.Class_Div(i).ODLinePat = LinePush(i)
        Next
        Return screen_in_f
    End Function
    ''' <summary>
    ''' 線モードと形状オブジェクトのペイントモードの凡例
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="ALP"></param>
    ''' <param name="HeadBoxSize"></param>
    ''' <param name="UnitTx"></param>
    ''' <param name="Layn2"></param>
    ''' <param name="datn2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_ClassODModeMode(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                         ByVal ALP As Point, ByRef HeadBoxSize As Size, ByVal UnitTx As String,
                                         ByVal Layn2 As Integer, ByVal datn2 As Integer,
                                         ByVal SizeGetOnlyF As Boolean) As Boolean

        Dim PData As clsAttrData.strData_info = attrData.LayerData(Layn2).atrData.Data(datn2)
        Dim Class_div() As clsAttrData.strClass_Div_data = PData.SoloModeViewSettings.Class_Div

        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim UH As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        Dim hnfont As Font = New Font(LFont.Body.Name, UH, GraphicsUnit.Pixel)
        Dim Div_Num As Integer = PData.SoloModeViewSettings.Div_Num
        Dim LL As Integer = 1
        Dim RR As Integer = 0
        If PData.DataType <> enmAttDataType.Category Then
            For i As Integer = 0 To Div_Num - 1
                Dim L As Integer
                Dim r As Integer
                Dim a As Double = Class_div(i).Value
                clsGeneric.Figure_Arrange(a, L, r)
                If L = 0 Then L = 1
                If a < 0 Then L += 1
                LL = Math.Max(LL, L)
                RR = Math.Max(RR, r)
            Next
        End If

        Dim rm As Single = 0
        For i As Integer = 0 To Div_Num - 1
            rm = Math.Max(Class_div(i).ODLinePat.Get_Max_LineWidth(), rm)
        Next
        Dim x2 As Integer = attrData.Get_Length_On_Screen(8)
        Dim Xsepa As Integer = attrData.Get_Length_On_Screen(2)
        Dim ysize2 As Integer = HeadBoxSize.Height
        '---
        Dim xs As Integer = 0
        If UnitTx <> "" Then
            HeadBoxSize.Height += UH
        End If
        For i As Integer = 0 To Div_Num - 1
            With Class_div(i)
                If clsGeneric.Check_Line_PrintPattern(.ODLinePat) = True Then
                    Dim LW As Integer = attrData.Get_Length_On_Screen(.ODLinePat.Get_Max_LineWidth())
                    Dim H As Integer = Math.Max(UH, LW)
                    Dim r As Integer
                    If .ODLinePat.Edge_Connect_Pattern.Edge_Pattern = 2 Then
                        r = attrData.Radius(rm, 0, rm)
                    Else
                        r = attrData.Radius(rm, .ODLinePat.Get_Max_LineWidth(), rm)
                    End If
                    Dim fu As String
                    If PData.DataType = enmAttDataType.Category Then
                        fu = Class_div(i).Cat_Name
                    Else
                        fu = Get_SeparateClassWords(attrData, Class_div, i, Div_Num, LL, RR)
                    End If
                    xs = Math.Max(xs, g.MeasureString(fu, hnfont).Width)
                    HeadBoxSize.Height += H * 1.5
                End If
            End With
        Next


        With attrData.TotalData.ViewStyle.Missing_Data
            If PData.MissingValueNum > 0 And .Print_Flag = True And .LineShape.BasicLine.pattern <> -1 And
                attrData.LayerData(Layn2).Shape = enmShape.LineShape Then
                xs = Math.Max(xs, g.MeasureString(.Text, hnfont).Width)
                Dim LW As Integer = attrData.Get_Length_On_Screen(.LineShape.Get_Max_LineWidth())
                HeadBoxSize.Height += Math.Max(UH, LW) * 1.5
            End If
        End With

        Dim FreqW As Integer = 0
        Dim freq() As Integer, missFreq As Integer
        If attrData.TotalData.ViewStyle.MapLegend.ClassMD.FrequencyPrint = True Then
            If attrData.Get_ClassFrequency(Layn2, datn2, True, freq, missFreq) = True Then
                For j As Integer = 0 To freq.Count - 1
                    FreqW = Math.Max(FreqW, g.MeasureString("(" + freq(j).ToString + ")", hnfont).Width)
                Next
            End If
        End If

        HeadBoxSize.Width = x2 + xs + Xsepa + FreqW

        If SizeGetOnlyF = True Then
            Return False
        End If
        Dim C_Rect As Rectangle = New Rectangle(ALP, HeadBoxSize)
        If attrData.Check_Screen_In(C_Rect) = False Then
            Return False
        End If

        'ここまで範囲調べ、以降描画

        LegendBoxBack(g, attrData, C_Rect)

        '---
        HeadBoxSize.Height = ysize2
        If UnitTx <> "" Then
            attrData.Draw_Print(g, UnitTx,
                    New Point(ALP.X + x2 + attrData.Radius(5, 1, 1), ALP.Y + HeadBoxSize.Height),
                    LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
            HeadBoxSize.Height += UH
        End If
        For i As Integer = 0 To Div_Num - 1
            With Class_div(i)
                If clsGeneric.Check_Line_PrintPattern(.ODLinePat) = True Then
                    Dim LW As Integer = attrData.Get_Length_On_Screen(.ODLinePat.Get_Max_LineWidth())
                    Dim H As Integer = Math.Max(UH, LW)
                    Dim Y As Integer = HeadBoxSize.Height + UH / 2
                    Dim r As Integer
                    If .ODLinePat.Edge_Connect_Pattern.Edge_Pattern = enmEdge_Pattern.Flat Then
                        r = 0
                    Else
                        r = LW / 2
                    End If
                    attrData.Draw_Line(g, .ODLinePat, New Point(ALP.X + r, ALP.Y + Y), New Point(ALP.X + x2 - r, ALP.Y + Y))
                    Dim fu As String
                    If PData.DataType = enmAttDataType.Category Then
                        fu = Class_div(i).Cat_Name
                    Else
                        fu = Get_SeparateClassWords(attrData, Class_div, i, Div_Num, LL, RR)
                    End If
                    attrData.Draw_Print(g, fu, New Point(ALP.X + x2 + Xsepa, ALP.Y + Y), LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
                    If attrData.TotalData.ViewStyle.MapLegend.ClassMD.FrequencyPrint = True Then
                        Dim cwp As Point
                        cwp.Y = ALP.Y + HeadBoxSize.Height + UH / 2
                        cwp.X = ALP.X + x2 + Xsepa + xs
                        attrData.Draw_Print(g, "(" + freq(i).ToString + ")", cwp, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
                    End If
                    HeadBoxSize.Height += H * 1.5
                    If i = Div_Num - 1 Then
                        HeadBoxSize.Height -= H
                    End If
                End If
            End With
        Next


        With attrData.TotalData.ViewStyle.Missing_Data
            If PData.MissingValueNum > 0 And .Print_Flag = True And .LineShape.BasicLine.pattern <> -1 And
                attrData.LayerData(Layn2).Shape = enmShape.LineShape Then
                Dim LW As Integer = attrData.Get_Length_On_Screen(.LineShape.Get_Max_LineWidth())
                Dim r As Integer
                If .LineShape.Edge_Connect_Pattern.Edge_Pattern = enmEdge_Pattern.Flat Then
                    r = 0
                Else
                    r = LW / 2
                End If
                Dim Y As Integer = HeadBoxSize.Height + Math.Max(UH, LW) * 1.5
                attrData.Draw_Line(g, .LineShape, New Point(ALP.X + r, ALP.Y + Y), New Point(ALP.X + x2 - r, ALP.Y + Y))
                attrData.Draw_Print(g, .Text, New Point(ALP.X + x2 + Xsepa, ALP.Y + Y), LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
                HeadBoxSize.Height = Y
            End If
        End With
        Return True

    End Function

    ''' <summary>
    ''' ペイントモード、ハッチモードの凡例
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="ALP">凡例の左上の座標</param>
    ''' <param name="HeadBoxSize">オーバーレイ等で凡例の上にタイトルが表示される場合、その幅と高さ</param>
    ''' <param name="UnitTx">単位の文字列</param>
    ''' <param name="Layn2"></param>
    ''' <param name="datn2"></param>
    ''' <param name="m_f">ペイントモードの場合0、ハッチモードの場合1</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Draw_ClassPaintHatchMode(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                         ByVal ALP As Point, ByRef HeadBoxSize As Size, ByVal UnitTx As String,
                                         ByVal Layn2 As Integer, ByVal datn2 As Integer, ByVal m_f As Integer,
                                         ByVal SizeGetOnlyF As Boolean) As Boolean


        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim PData As clsAttrData.strData_info = attrData.LayerData(Layn2).atrData.Data(datn2)

        Dim ww As Integer
        Dim hh As Integer
        Dim hu As Integer
        Dim bxw As Integer
        Dim byh As Integer
        Dim vn As Integer
        Dim sujiW As Integer
        Dim freqW As Integer
        Dim LL As Integer
        Dim RR As Integer
        Paint_Tile_Word_Set(g, attrData, ww, hh, hu, bxw, byh, vn, sujiW, freqW, LL, RR, UnitTx, Layn2, datn2, True)

        HeadBoxSize.Width = Math.Max(HeadBoxSize.Width, bxw + ww / 2 + sujiW + freqW)
        Dim fbyh As Integer = byh
        If GetClassMethod(attrData, Layn2, datn2, True) = enmClassMode_Meshod.Separated Then
            byh *= (attrData.TotalData.ViewStyle.MapLegend.ClassMD.SeparateGapSize + 1)
        End If
        Dim ysize2 As Integer = HeadBoxSize.Height + byh * (PData.SoloModeViewSettings.Div_Num + 0.1) + hu
        '    Ysize2 = YSize + bxw * (PData.Div_Num + 0.1) + hu + (PData.Div_Num - 1) * bxwy
        If PData.MissingValueNum > 0 And attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True And
            attrData.LayerData(Layn2).Type <> clsAttrData.enmLayerType.Trip Then
            ysize2 += bxw * 2
        End If

        If SizeGetOnlyF = True Then
            HeadBoxSize.Height = ysize2
            Return False
        End If
        Dim C_Rect As Rectangle = New Rectangle(ALP, New Size(HeadBoxSize.Width, ysize2))

        If attrData.Check_Screen_In(C_Rect) = False Then
            Return False
        End If
        'ここまで範囲調べ、以降描画
        LegendBoxBack(g, attrData, C_Rect)

        Dim P As Point = ALP
        P.Offset(bxw, HeadBoxSize.Height)
        attrData.Draw_Print(g, UnitTx, P, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
        Dim ClassBoxLine As Line_Property = attrData.TotalData.ViewStyle.MapLegend.ClassMD.PaintMode_Line

        For i As Integer = 0 To PData.SoloModeViewSettings.Div_Num - 1
            Dim PaintBox As Rectangle = New Rectangle(ALP.X, ALP.Y + i * byh + hu + HeadBoxSize.Height, bxw + 1, fbyh)
            Select Case m_f
                Case 0
                    'ペイント
                    Dim TilePat As Tile_Property = clsBase.Tile
                    TilePat.Line.BasicLine.SolidLine.Color = PData.SoloModeViewSettings.Class_Div(i).PaintColor
                    attrData.Draw_Tile_Box(g, PaintBox, 0, ClassBoxLine, TilePat)
                Case 1
                    'ハッチ
                    attrData.Draw_Tile_Box(g, PaintBox, 0, ClassBoxLine,
                            PData.SoloModeViewSettings.Class_Div(i).TilePat)
            End Select
        Next

        If GetClassMethod(attrData, Layn2, datn2, True) = enmClassMode_Meshod.Separated Or PData.DataType = enmAttDataType.Category Then
            '分離表示またはカテゴリー
            For i As Integer = 0 To vn
                Dim fu As String
                If PData.DataType = enmAttDataType.Category Then
                    fu = PData.SoloModeViewSettings.Class_Div(i).Cat_Name
                Else
                    fu = Get_SeparateClassWords(attrData, PData.SoloModeViewSettings.Class_Div, i, PData.SoloModeViewSettings.Div_Num, LL, RR)
                End If
                Dim cwp As Point = ALP
                cwp.Offset(bxw + ww / 2, i * byh + hu + HeadBoxSize.Height)
                attrData.Draw_Print(g, fu, cwp, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
            Next
        Else
            For i As Integer = 0 To PData.SoloModeViewSettings.Div_Num - 2
                Dim fu As String = clsGeneric.Figure_Using(PData.SoloModeViewSettings.Class_Div(i).Value, LL, RR, attrData.TotalData.ViewStyle.MapLegend.Base.Comma_f)
                Dim cwp As Point = ALP
                cwp.Offset(bxw + ww / 2, (i + 0.5) * byh + hu + HeadBoxSize.Height)
                attrData.Draw_Print(g, fu, cwp, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
            Next
        End If

        Dim freq() As Integer, missFreq As Integer
        If attrData.TotalData.ViewStyle.MapLegend.ClassMD.FrequencyPrint = True Then
            '度数分布
            If attrData.Get_ClassFrequency(Layn2, datn2, True, freq, missFreq) = True Then
                For i As Integer = 0 To freq.Count - 1
                    Dim cwp As Point
                    cwp.Y = ALP.Y + i * byh + hu + HeadBoxSize.Height
                    cwp.X = ALP.X + bxw + ww / 2 + sujiW
                    attrData.Draw_Print(g, "(" + freq(i).ToString + ")", cwp, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
                Next
            End If
        End If

        If PData.MissingValueNum > 0 And attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True And
                attrData.LayerData(Layn2).Type <> clsAttrData.enmLayerType.Trip Then
            '欠損値
            Dim MissRect As Rectangle = New Rectangle(ALP.X, ALP.Y + (PData.SoloModeViewSettings.Div_Num + 0.5) * byh + hu + HeadBoxSize.Height,
                                                      bxw, fbyh)
            With attrData.TotalData.ViewStyle.Missing_Data
                Select Case m_f
                    Case 0
                        attrData.Draw_Tile_Box(g, MissRect, 0, ClassBoxLine, .PaintTile)
                    Case 1
                        attrData.Draw_Tile_Box(g, MissRect, 0, ClassBoxLine, .HatchTile)
                End Select
                Dim mistxp As Point = New Point(ALP.X + bxw + ww / 2, MissRect.Top)
                attrData.Draw_Print(g, .Text, mistxp, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
            End With
            If attrData.TotalData.ViewStyle.MapLegend.ClassMD.FrequencyPrint = True Then
                Dim cwp As Point
                cwp.Y = MissRect.Top
                cwp.X = ALP.X + bxw + ww / 2 + sujiW
                attrData.Draw_Print(g, "(" + missFreq.ToString + ")", cwp, LFont, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
            End If
        End If
        HeadBoxSize.Height = ysize2
        Return True
    End Function
    ''' <summary>
    ''' 階級区分凡例分離表示の文字
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Class_div">階級区分配列</param>
    ''' <param name="checkN">階級区分配列で調べる位置</param>
    ''' <param name="DivNum"></param>
    ''' <param name="LL"></param>
    ''' <param name="RR"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_SeparateClassWords(ByRef attrData As clsAttrData, ByRef Class_div() As clsAttrData.strClass_Div_data,
                                                  ByVal checkN As Integer, ByVal DivNum As Integer, ByVal LL As Integer, ByVal RR As Integer) As String

        Dim UnderSTR As String
        Dim HifunSTR As String
        Dim MoreSTR As String
        Dim MiddleSTR As String

        Select Case attrData.TotalData.ViewStyle.MapLegend.ClassMD.SeparateClassWords
            Case enmSeparateClassWords.Japanese
                UnderSTR = "未満"
                HifunSTR = "～"
                MoreSTR = "以上"
                MiddleSTR = ""
            Case enmSeparateClassWords.English
                UnderSTR = "less than "
                HifunSTR = " - "
                MoreSTR = " or more"
                MiddleSTR = ""
        End Select

        Dim fu As String
        Dim comma_f As Boolean = attrData.TotalData.ViewStyle.MapLegend.Base.Comma_f
        Select Case checkN
            Case 0
                fu = clsGeneric.Figure_Using(Class_div(checkN).Value, LL, RR, comma_f) + MoreSTR
            Case DivNum - 1
                If attrData.TotalData.ViewStyle.MapLegend.ClassMD.SeparateClassWords = enmSeparateClassWords.Japanese Then
                    fu = clsGeneric.Figure_Using(Class_div(checkN - 1).Value, LL, RR, comma_f) + UnderSTR
                Else
                    fu = UnderSTR + Trim(clsGeneric.Figure_Using(Class_div(checkN - 1).Value, LL, RR, comma_f))
                End If
            Case Else
                fu = clsGeneric.Figure_Using(Class_div(checkN).Value, LL, RR, comma_f) + HifunSTR +
                                clsGeneric.Figure_Using(Class_div(checkN - 1).Value, LL, RR, comma_f) + MiddleSTR
        End Select
        Return fu
    End Function
    Public Shared Function GetClassMethod(ByRef attrData As clsAttrData, ByVal Layn2 As Integer, ByVal datn2 As Integer, ByVal CategorySeparate_f_Enable As Boolean) As enmClassMode_Meshod
        Dim CMethod As enmClassMode_Meshod = attrData.TotalData.ViewStyle.MapLegend.ClassMD.PaintMode_Method
        Dim PData As clsAttrData.strData_info = attrData.LayerData(Layn2).atrData.Data(datn2)
        If PData.DataType = enmAttDataType.Category = True And attrData.TotalData.ViewStyle.MapLegend.ClassMD.CategorySeparate_f = True And CategorySeparate_f_Enable = True Then
            CMethod = enmClassMode_Meshod.Separated
        End If
        Return CMethod
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ww">1文字分の幅ピクセル（戻り値）</param>
    ''' <param name="hh">1文字分の高さピクセル（戻り値）</param>
    ''' <param name="hu">単位の高さ。単位が空白の場合0（戻り値）</param>
    ''' <param name="bxw">階級区分色ボックスの幅（戻り値）</param>
    ''' <param name="byh">階級区分色ボックスの高さ（hhと同じになる）（戻り値）</param>
    ''' <param name="vn">凡例文字の数（戻り値）</param>
    ''' <param name="sujiW">数字の最大幅（戻り値）</param>
    ''' <param name="FreqW">度数分布値の最大幅（戻り値）</param>
    ''' <param name="LL">整数部分の桁数（戻り値）</param>
    ''' <param name="RR">小数部分の桁数（戻り値）</param>
    ''' <param name="UnitTX">表示する単位</param>
    ''' <param name="Layn2">レイヤ</param>
    ''' <param name="datn2">データ番号</param>
    ''' <remarks></remarks>
    Public Shared Sub Paint_Tile_Word_Set(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                          ByRef ww As Integer, ByRef hh As Integer, ByRef hu As Integer,
                                          ByRef bxw As Integer, ByRef byh As Integer, ByRef vn As Integer,
                                          ByRef sujiW As Integer, ByRef FreqW As Integer,
                                          ByRef LL As Integer, ByRef RR As Integer,
                                          ByVal UnitTX As String, ByVal Layn2 As Integer, ByVal datn2 As Integer, ByVal CategorySeparate_f_Enable As Boolean)

        Dim PData As clsAttrData.strData_info = attrData.LayerData(Layn2).atrData.Data(datn2)
        Dim Class_div() As clsAttrData.strClass_Div_data = PData.SoloModeViewSettings.Class_Div
        LL = 1
        RR = 0
        Dim n As Integer
        If PData.DataType = enmAttDataType.Category Then
            n = 0
        Else
            n = 1
        End If
        Dim Div_Num As Integer = PData.SoloModeViewSettings.Div_Num
        For i As Integer = 0 To Div_Num - 1 - n
            Dim L As Integer
            Dim r As Integer
            Dim a As Double = Class_div(i).Value
            clsGeneric.Figure_Arrange(a, L, r)
            If L = 0 Then L = 1
            If a < 0 Then L += 1
            LL = Math.Max(LL, L)
            RR = Math.Max(RR, r)
        Next

        Dim COML As Integer
        If attrData.TotalData.ViewStyle.MapLegend.Base.Comma_f = True Then
            COML = (LL - 1) \ 3
        Else
            COML = 0
        End If

        Dim LFont As Font_Property = attrData.TotalData.ViewStyle.MapLegend.Base.Font
        Dim H As Integer = attrData.Get_Length_On_Screen(LFont.Body.Size)
        If H = 0 Then
            Return
        End If
        Dim hnfont As Font = New Font(LFont.Body.Name, H, GraphicsUnit.Pixel)
        ww = g.MeasureString("8", hnfont).Width
        hh = g.MeasureString("8", hnfont).Height
        If UnitTX <> "" Then
            hu = hh
        Else
            hu = 0
        End If
        sujiW = g.MeasureString(UnitTX, hnfont).Width
        If PData.MissingValueNum > 0 And attrData.TotalData.ViewStyle.Missing_Data.Print_Flag = True And
            attrData.LayerData(Layn2).Type <> clsAttrData.enmLayerType.Trip Then
            sujiW = Math.Max(sujiW, g.MeasureString(attrData.TotalData.ViewStyle.Missing_Data.Text, hnfont).Width)
        End If

        Dim CMethod As enmClassMode_Meshod = GetClassMethod(attrData, Layn2, datn2, CategorySeparate_f_Enable)

        If PData.DataType = enmAttDataType.Category Then
            vn = Div_Num - 1
        Else
            If CMethod = enmClassMode_Meshod.Noral Then
                vn = Div_Num - 2
            Else
                vn = Div_Num - 1
            End If
        End If

        Dim sujiw2 As Integer = 0
        If CMethod = enmClassMode_Meshod.Separated Or PData.DataType = enmAttDataType.Category Then
            Dim fu As String
            For i As Integer = 0 To vn
                If PData.DataType = enmAttDataType.Category Then
                    fu = Class_div(i).Cat_Name
                Else
                    fu = Get_SeparateClassWords(attrData, PData.SoloModeViewSettings.Class_Div, i, Div_Num, LL, RR)
                End If
                sujiw2 = Math.Max(sujiw2, g.MeasureString(fu, hnfont).Width)
            Next
        Else
            Dim fu As String
            For i As Integer = 0 To Div_Num - 2
                fu = clsGeneric.Figure_Using(Class_div(i).Value, LL, RR, attrData.TotalData.ViewStyle.MapLegend.Base.Comma_f)
                sujiw2 = Math.Max(sujiw2, g.MeasureString(fu, hnfont).Width)
            Next
        End If
        sujiw2 += ww / 2

        sujiW = Math.Max(sujiW, sujiw2)

        If attrData.TotalData.ViewStyle.MapLegend.ClassMD.FrequencyPrint = True Then
            Dim freq() As Integer, missFreq As Integer
            FreqW = 0
            If attrData.Get_ClassFrequency(Layn2, datn2, True, freq, missFreq) = True Then
                For j As Integer = 0 To freq.Count - 1
                    FreqW = Math.Max(FreqW, g.MeasureString("(" + freq(j).ToString + ")", hnfont).Width)
                Next
            End If
        End If

        byh = attrData.Get_Length_On_Screen(LFont.Body.Size)
        bxw = byh * attrData.TotalData.ViewStyle.MapLegend.ClassMD.PaintMode_Width
    End Sub
    ''' <summary>
    ''' 注表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <remarks></remarks>
    Public Shared Sub Note_Print(ByRef g As Graphics, ByRef attrData As clsAttrData)
        If attrData.TotalData.ViewStyle.DataNote.Visible = False Then
            Return
        End If

        Dim rect As Rectangle
        Dim Note As String = getPrintNote(g, attrData, rect)
        If Note <> "" Then
            attrData.Draw_Print(g, Note, rect.Location, attrData.TotalData.ViewStyle.DataNote.Font, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
        End If

    End Sub

    ''' <summary>
    ''' 注の外接四角形領域取得
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <remarks></remarks>
    Public Shared Function GetNoteRect(ByRef g As Graphics, ByRef attrData As clsAttrData) As Rectangle

        Dim rect As Rectangle
        Dim TI As String = getPrintNote(g, attrData, rect)
        Return rect
    End Function
    Private Shared Function getPrintNote(ByRef g As Graphics, ByRef attrData As clsAttrData, ByRef Rect As Rectangle) As String
        Dim Note As String = ""
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer

        Select Case attrData.TotalData.LV1.Print_Mode_Total
            Case enmTotalMode_Number.DataViewMode
                With attrData.LayerData(Layernum)
                    Select Case .Print_Mode_Layer
                        Case enmLayerMode_Number.SoloMode
                            Dim DataNum As Integer = .atrData.SelectedIndex
                            Note = .atrData.Data(DataNum).Note
                        Case enmLayerMode_Number.GraphMode
                            With .LayerModeViewSettings.GraphMode
                                Dim n As Integer = .DataSet(.SelectedIndex).Count
                                If n > 0 Then
                                    Dim NoteD(n - 1) As String
                                    Dim nn As Integer = 0
                                    For i As Integer = 0 To n - 1
                                        Dim tx As String = attrData.Get_DataNote(Layernum, .DataSet(.SelectedIndex).Data(i).DataNumner)
                                        If tx <> "" Then
                                            NoteD(nn) = tx
                                            nn += 1
                                        End If
                                    Next
                                    If nn <> 0 Then
                                        clsGeneric.Remove_Same_String(nn, NoteD)
                                        Note = String.Join(vbCrLf, NoteD)
                                    End If
                                End If
                            End With
                        Case enmLayerMode_Number.LabelMode
                            With .LayerModeViewSettings.LabelMode
                                Dim n As Integer = .DataSet(.SelectedIndex).CountOfDataItem
                                If n > 0 Then
                                    Dim NoteD(n - 1) As String
                                    Dim nn As Integer = 0
                                    For i As Integer = 0 To n - 1
                                        Dim tx As String = attrData.Get_DataNote(Layernum, .DataSet(.SelectedIndex).DataItem(i))
                                        If tx <> "" Then
                                            NoteD(nn) = attrData.Get_DataNote(Layernum, .DataSet(.SelectedIndex).DataItem(i))
                                            nn += 1
                                        End If
                                    Next
                                    If nn <> 0 Then
                                        clsGeneric.Remove_Same_String(nn, NoteD)
                                        Note = String.Join(vbCrLf, NoteD)
                                    End If
                                End If
                            End With
                    End Select
                End With
            Case enmTotalMode_Number.OverLayMode
                With attrData.TotalData.TotalMode.OverLay
                    With attrData.TotalData.TotalMode.OverLay
                        Note = .DataSet(.SelectedIndex).Note
                    End With
                End With
        End Select

        If Note = "" Then
            Rect = New Rectangle(0, 0, 0, 0)
            Return ""
        End If
        Dim P_Note As clsAttrData.strNote_Attri = attrData.TotalData.ViewStyle.DataNote
        With attrData.TotalData.ViewStyle.ScrData
            If .Accessory_Base = enmBasePosition.Screen Then
                P_Note.Position = .getSRXYfromRatio(P_Note.Position)
            End If
        End With
        Dim atx As String = Note
        Dim xw As Integer = attrData.Get_Length_On_Screen(P_Note.MaxWidth)
        Dim yw As Integer = 0
        Dim RealW As Integer
        Dim d_an2 As List(Of String) = clsDraw.TextCut_for_print(g, atx, P_Note.Font, True, xw, RealW, yw, attrData.TotalData.ViewStyle.ScrData)

        Dim outTx As String = d_an2(0)
        For i As Integer = 1 To d_an2.Count - 1
            outTx += vbCrLf + d_an2(i)
        Next
        yw *= d_an2.Count
        Dim tP As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(P_Note.Position)
        Rect = New Rectangle(New Point(tP.X - RealW / 2, tP.Y - yw / 2), New Size(RealW, yw))
        Return outTx
    End Function
    ''' <summary>
    ''' タイトル表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <remarks></remarks>
    Public Shared Sub Title_Print(ByRef g As Graphics, ByRef attrData As clsAttrData)

        If attrData.TotalData.ViewStyle.MapTitle.Visible = False Then
            Return
        End If

        Dim rect As Rectangle
        Dim TI As String = getPrintTitle(g, attrData, rect)

        attrData.Draw_Print(g, TI, rect.Location, attrData.TotalData.ViewStyle.MapTitle.Font, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
    End Sub
    Private Shared Function getPrintTitle(ByRef g As Graphics, ByRef attrData As clsAttrData, ByRef Rect As Rectangle) As String
        Dim TI As String
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer

        Select Case attrData.TotalData.LV1.Print_Mode_Total
            Case enmTotalMode_Number.DataViewMode
                With attrData.LayerData(Layernum)
                    Select Case .Print_Mode_Layer
                        Case enmLayerMode_Number.SoloMode
                            Dim DataNum As Integer = .atrData.SelectedIndex
                            TI = .atrData.Data(DataNum).Title
                        Case enmLayerMode_Number.GraphMode
                            With .LayerModeViewSettings.GraphMode
                                TI = .DataSet(.SelectedIndex).title
                            End With
                        Case enmLayerMode_Number.LabelMode
                            With .LayerModeViewSettings.LabelMode
                                TI = .DataSet(.SelectedIndex).title
                            End With
                        Case enmLayerMode_Number.TripMode
                            With .LayerModeViewSettings.TripMode
                                TI = .DataSet(.SelectedIndex).title
                            End With
                    End Select
                End With
            Case enmTotalMode_Number.OverLayMode
                With attrData.TotalData.TotalMode.OverLay
                    TI = .DataSet(.SelectedIndex).title
                End With
            Case enmTotalMode_Number.SeriesMode
                TI = attrData.TempData.Series_temp.title
        End Select

        Dim P_Title As clsAttrData.strTitle_Attri = attrData.TotalData.ViewStyle.MapTitle
        With attrData.TotalData.ViewStyle.ScrData
            If .Accessory_Base = enmBasePosition.Screen Then
                P_Title.Position = .getSRXYfromRatio(P_Title.Position)
            End If
        End With
        Dim atx As String = TI
        Dim xw As Integer = attrData.Get_Length_On_Screen(P_Title.MaxWidth)
        Dim yw As Integer = 0
        Dim RealW As Integer
        Dim d_an2 As List(Of String) = clsDraw.TextCut_for_print(g, atx, P_Title.Font, True, xw, RealW, yw, attrData.TotalData.ViewStyle.ScrData)

        Dim outTx As String = ""
        If d_an2.Count > 0 Then
            outTx = d_an2(0)
        End If
        For i As Integer = 1 To d_an2.Count - 1
            outTx += vbCrLf + d_an2(i)
        Next
        yw *= d_an2.Count
        Dim tP As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(P_Title.Position)
        Rect = New Rectangle(New Point(tP.X - RealW / 2, tP.Y - yw / 2), New Size(RealW, yw))
        Return outTx
    End Function

    ''' <summary>
    ''' タイトルの外接四角形領域取得
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <remarks></remarks>
    Public Shared Function GetTitleRect(ByRef g As Graphics, ByRef attrData As clsAttrData) As Rectangle

        Dim rect As Rectangle
        Dim TI As String = getPrintTitle(g, attrData, rect)
        Return rect
    End Function
    ''' <summary>
    ''' 方位記号の外接四角形領域取得
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCompassRect(ByRef g As Graphics, ByRef attrData As clsAttrData) As Rectangle
        Dim P_Comp As clsMapData.strCompass_Attri
        With attrData.TotalData.ViewStyle
            P_Comp = .AttMapCompass
            If .ScrData.Accessory_Base = enmBasePosition.Screen Then
                P_Comp.Position = .ScrData.getSRXYfromRatio(P_Comp.Position)
            End If
        End With

        With P_Comp
            Dim r As Integer = attrData.Radius(.Mark.WordFont.Body.Size, 1, 1)
            Dim centerP As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(.Position)
            Return New Rectangle(New Point(centerP.X - r, centerP.Y - r), New Size(r * 2, r * 2))
        End With
    End Function
    ''' <summary>
    ''' スケールの外接四角形領域取得
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetScaleRect(ByRef g As Graphics, ByRef attrData As clsAttrData) As Rectangle
        Dim P_Scl As clsAttrData.strScale_Attri
        Dim SCST As Integer
        Dim scaleMax As String
        Dim sxy As Point
        Dim zeroW As Single
        Dim ScaleLength As Single
        Dim ScaleMaxW As Single
        Dim C_Rect As Rectangle = getScaleSub(g, attrData, SCST, scaleMax, sxy, P_Scl, zeroW, ScaleLength, ScaleMaxW)
        Return C_Rect
    End Function
    ''' <summary>
    ''' 方位表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <remarks></remarks>
    Public Shared Sub Compass_print(ByRef g As Graphics, ByRef attrData As clsAttrData)
        Dim P_Comp As clsMapData.strCompass_Attri
        Dim threed As strThreeDMode_Set = attrData.TotalData.ViewStyle.ScrData.ThreeDMode
        With attrData.TotalData.ViewStyle
            If .AttMapCompass.Visible = False Or (threed.Set3D_F = True And (threed.Pitch <> 0 Or threed.Head <> 0)) Then
                Return
            End If
            P_Comp = .AttMapCompass
            If .ScrData.Accessory_Base = enmBasePosition.Screen Then
                P_Comp.Position = .ScrData.getSRXYfromRatio(P_Comp.Position)
            End If
        End With

        With P_Comp
            Dim fmap As clsMapData = attrData.SetMapFile("")
            Dim CompD As Integer = fmap.Map.MapCompass.Mark.WordFont.Body.Kakudo
            If threed.Set3D_F = True Then
                CompD -= threed.Bank
            End If
            .Mark.WordFont.Body.Kakudo = CompD

            Dim r As Integer = attrData.Radius(.Mark.WordFont.Body.Size, 1, 1)
            Dim centerP As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(.Position)
            If attrData.Check_Screen_In(centerP, r) = True Then
                attrData.Draw_Mark(g, centerP, r, .Mark)
                Dim ww As Integer = attrData.Get_Length_On_Screen(.Font.Body.Size) * 0.7
                Dim PlusFont As Font_Property = .Font
                PlusFont.Body.Kakudo += .Mark.WordFont.Body.Kakudo
                For i As Integer = 0 To 3
                    Dim wpos As Point = centerP
                    wpos.Offset(Math.Cos((i * 90 + 90 + CompD) * Math.PI / 180) * (r + ww),
                                -Math.Sin((i * 90 + 90 + CompD) * Math.PI / 180) * (r + ww))
                    Dim CmpassWord As String
                    With .dirWord
                        Select Case i
                            Case 0
                                CmpassWord = .North
                            Case 1
                                CmpassWord = .West
                            Case 2
                                CmpassWord = .South
                            Case 3
                                CmpassWord = .East
                        End Select
                    End With
                    attrData.Draw_Print(g, CmpassWord, wpos, PlusFont, enmHorizontalAlignment.Center, enmVerticalAlignment.Center)
                Next

            End If
        End With
    End Sub
    Private Shared Function getScaleSub(ByRef g As Graphics, ByRef attrData As clsAttrData,
                                 ByRef SCST As Integer, ByRef scaleMax As String,
                                 ByRef sxy As Point, ByRef P_Scl As clsAttrData.strScale_Attri,
                                 ByRef zeroW As Single, ByRef ScaleLength As Single, ByRef ScaleMaxW As Single) As Rectangle

        Dim C_Rect As Rectangle
        Dim threed As strThreeDMode_Set = attrData.TotalData.ViewStyle.ScrData.ThreeDMode
        With attrData.TotalData.ViewStyle
            If .MapScale.Visible = False Or (threed.Set3D_F = True And (threed.Pitch <> 0 Or threed.Head <> 0)) Then ' Map_Detail.Distance = 2 Or 
                Return C_Rect
            End If
            P_Scl = .MapScale
            If .ScrData.Accessory_Base = enmBasePosition.Screen Then
                P_Scl.Position = .ScrData.getSRXYfromRatio(P_Scl.Position)
            End If
        End With

        Dim Map As clsMapData.strMap_data = attrData.SetMapFile("").Map
        Dim SCT() As Integer = {0, 2, 2, 3, 4, 2, 3, 2, 4, 3, 2}
        SCST = 0
        Dim SCM As Single = 0
        Dim MapScaleBairitu As Single
        If P_Scl.BarAuto = True Then
            Dim xw As Single = attrData.TotalData.ViewStyle.ScrData.ScrView.Right - attrData.TotalData.ViewStyle.ScrData.ScrView.Left
            MapScaleBairitu = spatial.Get_Scale_Baititu_IdoKedo(P_Scl.Position, Map.Zahyo)
            MapScaleBairitu /= clsGeneric.Convert_ScaleUnit(enmScaleUnit.kilometer, P_Scl.Unit)
            Dim i As Integer = 5
            While SCM < 1 And i >= 4
                Select Case Map.Zahyo.Mode
                    Case enmZahyo_mode_info.Zahyo_Ido_Keido
                        SCM = xw / i / MapScaleBairitu
                    Case enmZahyo_mode_info.Zahyo_No_Mode, enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                        SCM = xw / i / (Map.SCL * MapScaleBairitu)
                End Select
                i -= 1
            End While
            Dim L As Integer
            If SCM >= 1 Then
                L = Int(Math.Log(SCM) / Math.Log(10)) + 1
            Else
                L = Math.Abs(Int(Math.Log(SCM) / Math.Log(10)))
            End If
            If L > 6 Then
                '表示桁が大きすぎる場合は表示しない
                Return C_Rect
            End If
            Dim a As Integer
            Dim b As Integer = 10 ^ (L - 1)
            If SCM >= 1 Then
                SCM = (SCM \ b) * b
                a = SCM \ b
                If a = 3 Or a = 5 Or a = 7 Or a = 9 Then
                    a += 1
                    SCM = a * b
                End If
            Else
                SCM = Val(Left(Str(SCM), 2 + L))
                a = Val(Right(Str(SCM), 1))
                If a = 3 Or a = 5 Or a = 7 Or a = 9 Then
                    a += 1
                    SCM = a / (10 ^ L)
                End If
            End If
            SCST = SCT(a)
            attrData.TotalData.ViewStyle.MapScale.BarDistance = SCM
            attrData.TotalData.ViewStyle.MapScale.BarKugiriNum = SCST
        Else
            SCM = P_Scl.BarDistance
            SCST = P_Scl.BarKugiriNum
            MapScaleBairitu = spatial.Get_Scale_Baititu_IdoKedo(P_Scl.Position, Map.Zahyo)
            MapScaleBairitu /= clsGeneric.Convert_ScaleUnit(enmScaleUnit.kilometer, P_Scl.Unit)
        End If

        If SCM = 0 Then
            Return C_Rect
        End If
        With P_Scl
            sxy = attrData.TotalData.ViewStyle.ScrData.getSxSy(.Position)
            scaleMax = CStr(SCM)
            Select Case Map.Zahyo.Mode
                Case enmZahyo_mode_info.Zahyo_Ido_Keido
                    ScaleLength = SCM * MapScaleBairitu * attrData.TotalData.ViewStyle.ScrData.ScreenMG.Mul
                Case enmZahyo_mode_info.Zahyo_No_Mode, enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                    ScaleLength = SCM * Map.SCL * MapScaleBairitu * attrData.TotalData.ViewStyle.ScrData.ScreenMG.Mul
            End Select

            If attrData.TotalData.ViewStyle.ScrData.OutputDevide = enmOutputDevice.Printer Then
                ScaleLength *= attrData.TotalData.ViewStyle.ScrData.PrinterMG.Mul
            End If
            Dim H As Integer = attrData.Get_Length_On_Screen(.Font.Body.Size)
            If H > 0 Then
                Dim hnfont As Font = New Font(.Font.Body.Name, H, GraphicsUnit.Pixel)
                zeroW = g.MeasureString("0", hnfont).Width / 2
                ScaleMaxW = g.MeasureString(scaleMax, hnfont).Width / 2
                Dim ww2 As Single = g.MeasureString(clsGeneric.getScaleUnitStrings(P_Scl.Unit), hnfont).Width

                Dim mw As Integer = (ScaleLength + zeroW + ScaleMaxW + ww2)
                Dim mh As Integer = H * 1.5
                C_Rect = New Rectangle(New Point(sxy.X - mh / 4, sxy.Y - mh / 4), New Size(mw + mh / 2, mh + mh / 2))
            End If
        End With
        Return C_Rect
    End Function
    ''' <summary>
    ''' スケール表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <remarks></remarks>
    Public Shared Sub Scale_Print(ByRef g As Graphics, ByRef attrData As clsAttrData)

        Dim P_Scl As clsAttrData.strScale_Attri
        Dim SCST As Integer
        Dim scaleMax As String
        Dim sxy As Point
        Dim zeroW As Single
        Dim ScaleLength As Single
        Dim ScaleMaxW As Single
        Dim C_Rect As Rectangle = getScaleSub(g, attrData, SCST, scaleMax, sxy, P_Scl, zeroW, ScaleLength, ScaleMaxW)

        If C_Rect.Width = 0 Then
            Return
        End If
        With P_Scl
            If attrData.Check_Screen_In(C_Rect) = True Then
                Dim H As Integer = attrData.Get_Length_On_Screen(.Font.Body.Size)
                attrData.Draw_Tile_RoundBox(g, C_Rect, attrData.TotalData.ViewStyle.MapScale.Back, 0)
                Dim TilePat As Tile_Property = clsBase.Tile
                TilePat.Line.BasicLine.SolidLine.Color = .Font.Body.Color
                Dim LPat As Line_Property = clsBase.Line
                LPat.Set_Same_ColorWidth_to_LinePat(.Font.Body.Color, 0)
                Select Case .BarPattern
                    Case clsAttrData.enmScaleBarPattern.Thin
                        attrData.Draw_Tile_Box(g, New Rectangle(sxy.X + zeroW, sxy.Y + H * 1.4, ScaleLength, H * 0.1), 0, LPat, TilePat)
                        LPat.Set_Same_ColorWidth_to_LinePat(.Font.Body.Color, 0.1)
                        For i As Integer = 1 To SCST + 1
                            Dim P1 As Point = New Point(sxy.X + zeroW + ScaleLength / SCST * (i - 1), sxy.Y + H)
                            Dim P2 As Point = New Point(sxy.X + zeroW + ScaleLength / SCST * (i - 1), sxy.Y + H * 1.5 - 1)
                            attrData.Draw_Line(g, LPat, P1, P2)
                        Next
                    Case clsAttrData.enmScaleBarPattern.Slim
                        LPat.Set_Same_ColorWidth_to_LinePat(.Font.Body.Color, 0.1)
                        attrData.Draw_Line(g, LPat, New Point(sxy.X + zeroW, sxy.Y + H * 1.5 - 1), New Point(sxy.X + zeroW + ScaleLength, sxy.Y + H * 1.5 - 1))
                        For i As Integer = 1 To SCST + 1
                            Dim P1 As Point = New Point(sxy.X + zeroW + ScaleLength / SCST * (i - 1), sxy.Y + H)
                            Dim P2 As Point = New Point(sxy.X + zeroW + ScaleLength / SCST * (i - 1), sxy.Y + H * 1.5 - 1)
                            attrData.Draw_Line(g, LPat, P1, P2)
                        Next

                    Case clsAttrData.enmScaleBarPattern.Bold
                        Dim TilePat2 As Tile_Property
                        Dim TilePat3 As Tile_Property
                        TilePat2 = TilePat
                        TilePat2.Line.BasicLine.SolidLine.Color = New colorARGB(Color.White)
                        For i As Integer = 1 To SCST
                            If i Mod 2 = 1 Then
                                TilePat3 = TilePat
                            Else
                                TilePat3 = TilePat2
                            End If
                            Dim Rect1 As Rectangle = New Rectangle(sxy.X + zeroW + ScaleLength / SCST * (i - 1), sxy.Y + H, ScaleLength / SCST, H * 0.5 - 1)
                            attrData.Draw_Tile_Box(g, Rect1, 0, LPat, TilePat3)
                        Next
                End Select
                attrData.Draw_Print(g, "0", sxy, .Font, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
                Dim tx As String = clsGeneric.getScaleUnitStrings(scaleMax, P_Scl.Unit)
                attrData.Draw_Print(g, tx, New Point(sxy.X + ScaleLength + zeroW - ScaleMaxW, sxy.Y), .Font, enmHorizontalAlignment.Left, enmVerticalAlignment.Top)
            End If
        End With
    End Sub
    ''' <summary>
    ''' 図形の文字表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Fig_Word"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Fig_PrintWords(ByRef g As Graphics, ByRef attrData As clsAttrData, ByRef Fig_Word As clsAttrData.strFig_Word_Data) As Boolean
        Dim Word() As String
        Dim printf As Boolean = False
        With Fig_Word
            Dim PN As Integer = Get_FigWord_XY(Fig_Word, Word)
            For i As Integer = 0 To PN - 1
                Dim P As Point
                If .Screen_Setf = False Then
                    P = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(Fig_Word.StringPos(i))
                Else
                    P = attrData.TotalData.ViewStyle.ScrData.getSxSyfromRatio(Fig_Word.StringPos(i))
                End If
                Dim f As Boolean = attrData.Draw_Print(g, Word(i), P, .Font, enmHorizontalAlignment.Center, enmVerticalAlignment.Center)
                If f = True Then
                    printf = True
                End If
            Next
        End With
        Return printf
    End Function
    ''' <summary>
    ''' 図形の文字で、個別モードの場合は文字ごとの配列と文字数、そうでない場合は文字列と1を返す
    ''' </summary>
    ''' <param name="Fig_Word"></param>
    ''' <param name="Word"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_FigWord_XY(ByRef Fig_Word As clsAttrData.strFig_Word_Data, ByRef Word() As String) As Integer

        Dim n As Integer
        With Fig_Word
            n = Len(Fig_Word.Caption)
            If .Scattered_Mode_F = True Then
                ReDim Word(n)
                For i As Integer = 0 To n - 1
                    Word(i) = Mid(.Caption, i + 1, 1)
                Next
            Else
                ReDim Word(0)
                Word(0) = .Caption
                n = 1
            End If
        End With
        Return n
    End Function
    ''' <summary>
    ''' 画像の表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Fig_Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Fig_PrintGazo(ByRef g As Graphics, ByRef attrData As clsAttrData, ByRef Fig_Gazo As clsAttrData.strFig_gazo_data) As Boolean
        Dim cp As Point
        Dim rad As Integer
        Dim rect As Rectangle
        Get_Fig_ImageRect(attrData, Fig_Gazo, cp, rect, rad)
        With Fig_Gazo
            If spatial.Compare_Two_Rectangle_Position(rect, .Angle, attrData.TotalData.ViewStyle.ScrData.MapScreen_Scale) = cstRectangle_Cross.cstOuter Then
                Return False
            End If

            Dim pic As Picture_Property = attrData.TotalData.BasePicture.PictureData(.PictureNumber)
            clsDraw.DrawPicture(g, pic.GetBitmap, cp, rad,
                           pic.TransParency_f, pic.TransParency_Color, pic.TransRange, .AlphaValue, .Angle,
                           .InnerCol_F, pic.Alternate_Color, .Inner_Color)
            '輪郭線

            attrData.Draw_Tile_Box(g, rect, .Angle, .LinePat, clsBase.BlancTile)

        End With
        Return True
    End Function
    ''' <summary>
    ''' 図形モード画像の中心位置と四角形座標を取得
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="Fig_Gazo"></param>
    ''' <param name="CenterP"></param>
    ''' <param name="Rect"></param>
    ''' <remarks></remarks>
    Public Shared Sub Get_Fig_ImageRect(ByRef attrData As clsAttrData, ByRef Fig_Gazo As clsAttrData.strFig_gazo_data, ByRef CenterP As Point, ByRef Rect As Rectangle, ByRef rad As Integer)
        With Fig_Gazo
            CenterP = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(.Position)
            Dim ScreenMGMul As Single = attrData.TotalData.ViewStyle.ScrData.ScreenMG.Mul
            Dim PrinterMGMul As Single = attrData.TotalData.ViewStyle.ScrData.PrinterMG.Mul
            Dim STDWsize As Single = attrData.TotalData.ViewStyle.ScrData.STDWsize
            rad = STDWsize * .Size / 100 * ScreenMGMul / 2
            Dim GazoSize As Size = attrData.TotalData.BasePicture.PictureData(.PictureNumber).Size
            Dim OutputDevide As enmOutputDevice = attrData.TotalData.ViewStyle.ScrData.OutputDevide
            If OutputDevide = enmOutputDevice.Printer Then
                rad *= PrinterMGMul
            End If
            Dim fSize As Size
            If GazoSize.Width >= GazoSize.Height Then
                fSize.Width = rad
                fSize.Height = rad * (GazoSize.Height / GazoSize.Width)
            Else
                fSize.Height = rad
                fSize.Width = rad * (GazoSize.Width / GazoSize.Height)
            End If
            Rect = New Rectangle(CenterP, New Size(0, 0))
            Rect.Inflate(fSize)
        End With
    End Sub
    ''' <summary>
    ''' 線の表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Fig_Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Fig_PrintLine(ByRef g As Graphics, ByRef attrData As clsAttrData, ByRef Fig_Line As clsAttrData.strFig_Line_Data) As Boolean
        With Fig_Line
            If spatial.Compare_Two_Rectangle_Position(.Circumscribed_Rectangle, attrData.TotalData.ViewStyle.ScrData.ScrRectangle) = cstRectangle_Cross.cstOuter Then
                Return False
            End If
            Dim ln As Integer = .NumOfPoint
            Dim Line_XY(ln - 1) As PointF
            For i As Integer = 0 To ln - 1
                Line_XY(i) = .Points(i)
            Next
            Dim Arrow_E2 As PointF
            Dim Arrow_E1 As PointF
            If .Arrow.End_Arrow_F = True Then
                Arrow_E2 = Line_XY(.NumOfPoint - 1)
                Arrow_E1 = Line_XY(.NumOfPoint - 2)
                If .Arrow.ArrowHeadType = enmArrowHeadType.Fill Then
                    '線端矢印の場合の線の長さ調整
                    Dim f As Boolean
                    For i As Integer = ln - 2 To 0 Step -1
                        Dim CP As PointF
                        f = clsDrawLine.Check_Draw_Arrow_Line(CP, Arrow_E2, Arrow_E1, Line_XY(i), Line_XY(i + 1), .Patttern, .Arrow, attrData.TotalData.ViewStyle.ScrData)
                        If f = True Then
                            Line_XY(i + 1) = CP
                            Exit For
                        End If
                    Next
                    If f = False Then
                        Line_XY(ln - 1) = Line_XY(ln - 2)
                    End If
                End If
            End If
            Dim Arrow_S2 As PointF
            Dim Arrow_S1 As PointF
            If .Arrow.Start_Arrow_F = True Then
                Arrow_S2 = Line_XY(0)
                Arrow_S1 = Line_XY(1)
                If .Arrow.ArrowHeadType = enmArrowHeadType.Fill Then
                    '線端矢印の場合の線の長さ調整
                    Dim f As Boolean
                    For i As Integer = 0 To ln - 2
                        Dim CP As PointF
                        f = clsDrawLine.Check_Draw_Arrow_Line(CP, Arrow_S2, Arrow_S1, Line_XY(i), Line_XY(i + 1), .Patttern, .Arrow, attrData.TotalData.ViewStyle.ScrData)
                        If f = True Then
                            Line_XY(i) = CP
                            Exit For
                        End If
                    Next
                    If f = False Then
                        Line_XY(0) = Line_XY(1)
                    End If
                End If
            End If

            Dim pxy() As Point
            If .Spline = True And ln > 2 Then
                If .FillFlag = True Then
                    pxy = clsSpline.Spline_Get_Fill(0, ln, Line_XY, 0.1, attrData.TotalData.ViewStyle.ScrData)
                Else
                    pxy = clsSpline.Spline_Get(0, ln, Line_XY, 0.1, attrData.TotalData.ViewStyle.ScrData)
                End If
            Else
                ReDim pxy(ln)
                For k As Integer = 0 To ln - 1
                    pxy(k) = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(Line_XY(k))
                Next
                If .FillFlag = True Then
                    If Line_XY(0).Equals(Line_XY(ln - 1)) = False Then
                        pxy(ln) = pxy(0)
                        ln += 1
                    End If
                End If
            End If

            If .FillFlag = True Then
                attrData.Draw_Poly_Inner(g, pxy, {ln}, 1, .Tile)
            End If

            ReDim Preserve pxy(ln - 1)
            attrData.Draw_Line(g, .Patttern, ln, pxy)

            If .Arrow.End_Arrow_F = True Then
                attrData.Draw_Arrow(g, Arrow_E2, Arrow_E1, .Patttern, .Arrow)
            End If
            If .Arrow.Start_Arrow_F = True Then
                attrData.Draw_Arrow(g, Arrow_S2, Arrow_S1, .Patttern, .Arrow)
            End If

        End With
        Return True
    End Function
    ''' <summary>
    ''' 図形四角形の表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Fig_Circle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Fig_PrintRectangle(ByRef g As Graphics, ByRef attrData As clsAttrData, ByRef Fig_Rect As clsAttrData.strFig_Rectangle_Data) As Boolean
        With Fig_Rect
            Dim rect As RectangleF = spatial.Get_Circumscribed_Rectangle(.Point0, .Point1)
            If spatial.Compare_Two_Rectangle_Position(rect, attrData.TotalData.ViewStyle.ScrData.ScrRectangle) = cstRectangle_Cross.cstOuter Then
                Return False
            End If
            Dim P1 As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(.Point0)
            Dim P2 As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(.Point1)
            Dim srect As Rectangle = spatial.Get_Circumscribed_Rectangle(P1, P2)
            attrData.Draw_Tile_RoundBox(g, srect, .Back, 0)
            Return True
        End With
    End Function
    ''' <summary>
    ''' 図形の円表示
    ''' </summary>
    ''' <param name="Fig_Circle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Fig_PrintCircle(ByRef g As Graphics, ByRef attrData As clsAttrData, ByRef Fig_Circle As clsAttrData.strFig_Circle_data) As Boolean

        Dim sc_in As Boolean
        With Fig_Circle
            '円図形はウインドウに固定の状態でも地図上に固定する
            'sc_in = Draw_DAEN(sx(.x), sy(.y), Get_Length_On_Screen(.XR / StdWSize * 100), Get_Length_On_Screen(.YR / StdWSize * 100), .Angle, .Pat, .Tile, False, OutputHDC, 0)
            Dim Map As clsMapData.strMap_data = attrData.SetMapFile("").Map
            Dim MapScaleBairitu As Single
            If Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
                MapScaleBairitu = Map.SCL
            Else
                MapScaleBairitu = spatial.Get_Scale_Baititu_IdoKedo(.Position, Map.Zahyo)
            End If
            Dim xxr As Integer = .XR * attrData.TotalData.ViewStyle.ScrData.ScreenMG.Mul * MapScaleBairitu
            Dim yyr As Integer = .YR * attrData.TotalData.ViewStyle.ScrData.ScreenMG.Mul * MapScaleBairitu

            If attrData.TotalData.ViewStyle.ScrData.OutputDevide = enmOutputDevice.Printer Then
                xxr *= attrData.TotalData.ViewStyle.ScrData.PrinterMG.Mul
                yyr *= attrData.TotalData.ViewStyle.ScrData.PrinterMG.Mul
            End If
            Dim P As Point = attrData.TotalData.ViewStyle.ScrData.getSxSy(.Position)
            sc_in = attrData.Draw_DAEN(g, P, xxr, yyr, .Angle, .LinePat, .Tile, False)

            If .Printcenter = True Then
                Dim MP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(.Position)
                Dim r As Integer = attrData.Radius(.Mark.WordFont.Body.Size, 1, 1)
                Dim C_Rect As Rectangle = spatial.Get_Rectangle(MP, r)
                If spatial.Compare_Two_Rectangle_Position(C_Rect, attrData.TotalData.ViewStyle.ScrData.MapScreen_Scale) <> cstRectangle_Cross.cstOuter Then
                    attrData.Draw_Mark(g, MP, r, .Mark)
                End If
            End If

        End With
        Return sc_in
    End Function
    ''' <summary>
    ''' 図形の点表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="attrData"></param>
    ''' <param name="Fig_Point"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Fig_PrintPoint(ByRef g As Graphics, ByRef attrData As clsAttrData, ByRef Fig_Point As clsAttrData.strFig_Point_Data) As Boolean

        Dim f As Boolean
        Dim r As Integer
        With Fig_Point
            Dim ln As Integer = .NumOfPoint
            For k As Integer = 0 To ln - 1
                Dim P As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(.Points(k))
                r = attrData.TotalData.ViewStyle.ScrData.Radius(.Mark.WordFont.Body.Size, 1, 1)
                Dim C_Rect As Rectangle = spatial.Get_Rectangle(P, r)
                If spatial.Compare_Two_Rectangle_Position(C_Rect, attrData.TotalData.ViewStyle.ScrData.MapScreen_Scale) <> cstRectangle_Cross.cstOuter Then
                    f = True
                    attrData.Draw_Mark(g, P, r, .Mark)
                End If
            Next
            If .Caption_F = True Then
                '凡例
                Dim CapP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(.CaptionPosition)
                Dim H As Integer = attrData.Get_Length_On_Screen(.Font.Body.Size)
                Dim hnfont As Font = New Font(.Font.Body.Name, H, GraphicsUnit.Pixel)
                Dim fwidth As Integer = g.MeasureString(.Caption, hnfont).Width
                Dim mh As Integer = Math.Max(r, fwidth / 2)
                Dim mw As Integer = r + r * 2 + fwidth
                Dim C_Rect As Rectangle = New Rectangle(CapP.X - r, CapP.Y - mh, r + mw, mh * 2)
                hnfont.Dispose()
                If spatial.Compare_Two_Rectangle_Position(C_Rect, attrData.TotalData.ViewStyle.ScrData.MapScreen_Scale) <> cstRectangle_Cross.cstOuter Then
                    attrData.Draw_Mark(g, CapP, r, .Mark)
                    attrData.Draw_Print(g, .Caption, New Point(CapP.X + +r * 2, CapP.Y), .Font, enmHorizontalAlignment.Left, enmVerticalAlignment.Center)
                End If
            End If
        End With
        Return f
    End Function


End Class
