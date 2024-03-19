Public Class clsDrawTile


    Public Shared Sub Draw_Sample_TileBox(ByRef ob As PictureBox, ByRef T As Tile_Property,
                                          ByVal ScrData As Screen_info, ByRef basePic As BasePicture_Info)

        With ob
            Dim w As Integer = .Width
            Dim h As Integer = .Height
            Dim canvas As New Bitmap(w, h)
            Dim g As Graphics = Graphics.FromImage(canvas)
            ScrData.SampleBoxFlag = True
            Select Case T.TileCode
                Case enmTilePattern.Blank
                    Dim Font As New Font("MS UI Gothic", 10, GraphicsUnit.Pixel)
                    clsDraw.print(g, "空白", New Point(w \ 2, h \ 2), Font, New SolidBrush(Color.Black), StringAlignment.Center, StringAlignment.Center)
                Case enmTilePattern.Paint
                    g.FillRectangle(New SolidBrush(T.Line.BasicLine.SolidLine.Color.getColor), New Rectangle(0, 0, w, h))
                Case Else
                    If T.BGColFlag = True Then
                        g.FillRectangle(New SolidBrush(T.BGCOLOR.getColor), New Rectangle(0, 0, w, h))
                    End If
                    Dim Interval As Integer = ScrData.Get_Length_On_Screen(T.Density)
                    DrawTile(g, New Rectangle(0, 0, w, h), T, Interval, ScrData, basePic)
            End Select
            g.Dispose()
            ob.Image = canvas
            ob.Refresh()
        End With
    End Sub

    Public Shared Sub Darw_Sample_BackGroundBox(ByRef ob As PictureBox, ByRef BG As BackGround_Box_Property, ByVal ScrData As Screen_info, ByRef basePic As BasePicture_Info)
        With ob
            Dim w As Integer = .Width
            Dim h As Integer = .Height
            Dim canvas As New Bitmap(w, h)
            Dim rect As New Rectangle(2, 2, .Width - 10, .Height - 10)
            If BG.Padding <> 0 Then
                Dim wp As Integer = ScrData.Get_Length_On_Screen(BG.Padding)
                rect.Inflate(-wp, -wp)
            End If
            Dim g As Graphics = Graphics.FromImage(canvas)
            ScrData.SampleBoxFlag = True
            Draw_Tile_RoundBox(g, rect, BG, 0, ScrData, basePic)
            Select Case BG.Tile.TileCode
                Case enmTilePattern.Blank
                    Dim Font As New Font("MS UI Gothic", 10, GraphicsUnit.Pixel)
                    clsDraw.print(g, "空白", New Point(w \ 2, h \ 2), Font, New SolidBrush(Color.Black), StringAlignment.Center, StringAlignment.Center)
            End Select
            g.Dispose()
            ob.Image = canvas
            ob.Refresh()
        End With
    End Sub




    Public Shared Sub Draw_Tile_and_Paint_and_Line(ByRef g As Graphics, ByRef pxy() As Point, ByRef nPolyP() As Integer,
        ByVal polyn As Integer, T As Tile_Property, L As Line_Property, ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)


        Draw_Poly_Inner(g, pxy, nPolyP, polyn, T, ScrData, basePic)
        Draw_Poly_Line(g, pxy, nPolyP, polyn, L, ScrData, basePic)

    End Sub
    ''' <summary>
    ''' 'polygonの輪郭線
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="pxy"></param>
    ''' <param name="nPolyP"></param>
    ''' <param name="polyn"></param>
    ''' <param name="L"></param>
    ''' <param name="ScrData"></param>
    ''' <remarks></remarks>
    Public Shared Sub Draw_Poly_Line(ByRef g As Graphics, ByRef pxy() As Point, ByRef nPolyP() As Integer, ByVal polyn As Integer,
        L As Line_Property, ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)

        If polyn = 1 Then
            clsDrawLine.Line(g, L, nPolyP(0), pxy, ScrData, basePic)
        Else
            Dim s As Integer = 0
            For i As Integer = 0 To polyn - 1
                Dim pointsub(nPolyP(i) - 1) As Point
                Array.Copy(pxy, s, pointsub, 0, nPolyP(i))
                clsDrawLine.Line(g, L, nPolyP(i), pointsub, ScrData, basePic)
                s += nPolyP(i)
            Next
        End If
    End Sub
    Public Shared Sub Draw_Poly_Inner(ByRef g As Graphics, ByRef pxy() As Point, ByRef nPolyP() As Integer, ByVal polyn As Integer,
                                      T As Tile_Property, ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)
        'polygonの内部塗りつぶし

        Dim Rect As Rectangle = spatial.Get_Circumscribed_Rectangle(pxy, 0, pxy.GetLength(0))

        With T
            Select Case .TileCode
                Case enmTilePattern.Blank
                Case enmTilePattern.Paint
                    With .Line.BasicLine
                        clsDraw.DrawPolyPolygon(g, polyn, pxy, nPolyP, .SolidLine.Color.getColor)
                    End With
                Case Else
                    Call Draw_Tile_Region(g, Rect, pxy, nPolyP, polyn, T, ScrData, basePic)
            End Select
        End With

    End Sub
    ''' <summary>
    ''' リージョンを設定してタイル塗りつぶし
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="BoundaryRect">外接四角形</param>
    ''' <param name="pxy">座標列</param>
    ''' <param name="nPolyP">ポリゴンの数</param>
    ''' <param name="polyn">ポリゴンごとのスタック座標位置の配列</param>
    ''' <param name="T">タイルパターン</param>
    ''' <param name="ScrData"></param>
    ''' <param name="basePic"></param>
    ''' <remarks></remarks>
    Public Shared Sub Draw_Tile_Region(ByRef g As Graphics, ByVal BoundaryRect As Rectangle,
                ByRef pxy() As Point, ByRef nPolyP() As Integer, ByVal polyn As Integer, ByRef T As Tile_Property,
                ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)

        '細いラインでクリッピングが働かないケースがある
        'For i As Integer = 0 To pxy.Length - 2
        '    If pxy(i).Equals(pxy(i + 1)) = True Then
        '        g.FillEllipse(New SolidBrush(Color.Black), New Rectangle(New Point(pxy(i).X - 2, pxy(i).Y - 2), New Size(4, 4)))
        '        i += 1
        '    Else
        '        g.FillEllipse(New SolidBrush(Color.Aqua), New Rectangle(New Point(pxy(i).X - 2, pxy(i).Y - 2), New Size(4, 4)))
        '    End If
        'Next


        Dim Interval As Integer
        Dim makeRegion As Region
        Dim OriginalClipRegion As Region = clsDraw.Set_Clipping_Region(g, polyn, pxy, nPolyP, makeRegion)
        If OriginalClipRegion Is Nothing = False Then
            With T
                If .BGColFlag = True Then
                    clsDraw.DrawPolyPolygon(g, polyn, pxy, nPolyP, .BGCOLOR.getColor)
                End If
                Interval = ScrData.Get_Length_On_Screen(.Density)
            End With
            DrawTile(g, BoundaryRect, T, Interval, ScrData, basePic)

            'クリッピングリージョンを戻す
            g.Clip = OriginalClipRegion
            makeRegion.Dispose()
        End If
    End Sub
    ''' <summary>
    ''' 角丸四角形
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="BoundaryRect"></param>
    ''' <param name="RoundR"></param>
    ''' <param name="Kakudo"></param>
    ''' <param name="L"></param>
    ''' <param name="T"></param>
    ''' <param name="ScrData"></param>
    ''' <param name="basePic"></param>
    ''' <remarks></remarks>
    Public Shared Sub Draw_Tile_RoundBox(ByRef g As Graphics, ByVal BoundaryRect As Rectangle, ByVal Back As BackGround_Box_Property, ByVal Kakudo As Single,
                                    ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)

        If Back.Padding <> 0 Then
            Dim w As Integer = ScrData.Get_Length_On_Screen(Back.Padding)
            BoundaryRect.Inflate(w, w)
        End If
        If Back.Round = 0 Then
            Draw_Tile_Box(g, BoundaryRect, Kakudo, Back.Line, Back.Tile, ScrData, basePic)
            Return
        End If
        Dim RoundR As Integer = ScrData.Get_Length_On_Screen(Back.Round)
        Dim pxy1() As Point = spatial.Get_Fan_Coordinates(New Point(BoundaryRect.Left + RoundR, BoundaryRect.Top + RoundR), RoundR, Math.PI * 2 * 3 / 4, Math.PI * 2, False)
        Dim pxy2() As Point = spatial.Get_Fan_Coordinates(New Point(BoundaryRect.Right - RoundR, BoundaryRect.Top + RoundR), RoundR, 0, Math.PI * 2 / 4, False)
        Dim pxy3() As Point = spatial.Get_Fan_Coordinates(New Point(BoundaryRect.Right - RoundR, BoundaryRect.Bottom - RoundR), RoundR, Math.PI * 2 / 4, Math.PI, False)
        Dim pxy4() As Point = spatial.Get_Fan_Coordinates(New Point(BoundaryRect.Left + RoundR, BoundaryRect.Bottom - RoundR), RoundR, Math.PI, Math.PI * 2 * 3 / 4, False)
        Dim cn As Integer = pxy1.Length + pxy2.Length + pxy3.Length + pxy4.Length + 1
        Dim pxy(cn - 1) As Point
        Array.Copy(pxy1, pxy, pxy1.Length)
        Array.Copy(pxy2, 0, pxy, pxy1.Length, pxy2.Length)
        Array.Copy(pxy3, 0, pxy, pxy1.Length + pxy2.Length, pxy3.Length)
        Array.Copy(pxy4, 0, pxy, pxy1.Length + pxy2.Length + pxy3.Length, pxy4.Length)
        pxy(cn - 1) = pxy(0)
        If Kakudo <> 0 Then
            Dim cp As Point = New Point((BoundaryRect.Left + BoundaryRect.Right) / 2, (BoundaryRect.Top + BoundaryRect.Bottom) / 2)
            For i As Integer = 0 To cn - 1
                pxy(i) = spatial.Trans2D(cp, pxy(i), -Kakudo)
            Next
        End If

        Dim pRect() As Point = spatial.Get_TurnedRectangle(BoundaryRect, Kakudo)
        Dim TurnedRect As Rectangle = spatial.Get_Circumscribed_Rectangle(pRect, 0, 4)
        Select Case Back.Tile.TileCode
            Case enmTilePattern.Blank
            Case enmTilePattern.Paint
                With Back.Tile.Line.BasicLine
                    g.FillPolygon(New SolidBrush(.SolidLine.Color.getColor), pxy)
                End With
            Case Else
                Dim nPolyP(0) As Integer
                nPolyP(0) = cn
                Draw_Tile_Region(g, TurnedRect, pxy, nPolyP, 1, Back.Tile, ScrData, basePic)
        End Select
        clsDrawLine.Line(g, Back.Line, cn, pxy, ScrData, basePic)
    End Sub


    ''' <summary>
    ''' タイル四角形描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="BoundaryRect"></param>
    ''' <param name="Kakudo"></param>
    ''' <param name="L"></param>
    ''' <param name="T"></param>
    ''' <param name="ScrData"></param>
    ''' <param name="basePic"></param>
    ''' <remarks></remarks>
    Public Shared Sub Draw_Tile_Box(ByRef g As Graphics, ByVal BoundaryRect As Rectangle, ByVal Kakudo As Single,
                                    ByRef L As Line_Property, ByRef T As Tile_Property,
                                    ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)

        Dim pxy() As Point
        Dim cn As Integer = 4

        pxy = spatial.Get_TurnedRectangle(BoundaryRect, Kakudo)
        Dim TurnedRect As Rectangle = spatial.Get_Circumscribed_Rectangle(pxy, 0, 4)
        Select Case T.TileCode
            Case enmTilePattern.Blank
            Case enmTilePattern.Paint
                With T.Line.BasicLine
                    g.FillPolygon(New SolidBrush(.SolidLine.Color.getColor), pxy)
                End With
            Case Else
                Dim nPolyP(0) As Integer
                nPolyP(0) = cn
                Draw_Tile_Region(g, TurnedRect, pxy, nPolyP, 1, T, ScrData, basePic)
        End Select
        clsDrawLine.Line(g, L, cn + 1, pxy, ScrData, basePic)
    End Sub
    'Public Shared Function Get_Meta_Region(pxy() As Point, ByVal n As Integer) As Point()
    '    Dim i As Integer
    '    Dim pxy2() As Point
    '    ''メタファイル出力の場合は、クリッピングリージョンはビューポートの座標になる
    '    'ReDim pxy2(n - 1)
    '    'For i = 0 To n - 1
    '    '    pxy2(i).X = pxy(i).X / TotalData.ScrData.PrinterMG.Mul
    '    '    pxy2(i).Y = pxy(i).Y / TotalData.ScrData.PrinterMG.Mul
    '    'Next

    'End Function
    Public Shared Sub DrawTile(ByRef g As Graphics, ByVal BoundaryRect As Rectangle,
                               TI As Tile_Property, ByVal Interval As Integer,
                               ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)
        'Size_Mode
        '0:%
        '1:Sampleの%
        '2:そのまま(ピクセル)


        Dim BRextEx As Rectangle = Rectangle.Inflate(BoundaryRect, BoundaryRect.Width * 0.05, BoundaryRect.Height * 0.05)


        Select Case TI.TileCode
            Case enmTilePattern.Point
                Call DrawTile_Point_Tile(g, BRextEx, Interval, TI.Line, ScrData)
            Case enmTilePattern.HorizontalLine
                Call DrawTile_Line_Tile(g, BRextEx, enmTilePattern.HorizontalLine, Interval, TI.Line, ScrData, basePic)
            Case enmTilePattern.VerticalLine
                Call DrawTile_Line_Tile(g, BRextEx, enmTilePattern.VerticalLine, Interval, TI.Line, ScrData, basePic)
            Case enmTilePattern.DiagonalLineRightUp
                Call DrawTile_Line_Tile(g, BRextEx, enmTilePattern.DiagonalLineRightUp, Interval, TI.Line, ScrData, basePic)
            Case enmTilePattern.DiagonalLineRightDown
                Call DrawTile_Line_Tile(g, BRextEx, enmTilePattern.DiagonalLineRightDown, Interval, TI.Line, ScrData, basePic)
            Case enmTilePattern.CrossLine
                Call DrawTile_Line_Tile(g, BRextEx, enmTilePattern.HorizontalLine, Interval, TI.Line, ScrData, basePic)
                Call DrawTile_Line_Tile(g, BRextEx, enmTilePattern.VerticalLine, Interval, TI.Line, ScrData, basePic)
            Case enmTilePattern.Saltire
                Call DrawTile_Line_Tile(g, BRextEx, enmTilePattern.DiagonalLineRightUp, Interval, TI.Line, ScrData, basePic)
                Call DrawTile_Line_Tile(g, BRextEx, enmTilePattern.DiagonalLineRightDown, Interval, TI.Line, ScrData, basePic)
            Case enmTilePattern.Blank
            Case enmTilePattern.Paint
                g.FillRectangle(New SolidBrush(TI.Line.BasicLine.SolidLine.Color.getColor), BoundaryRect)
            Case enmTilePattern.Mark
                Call DrawTile_Mark_Tile(g, BRextEx, Interval, TI, ScrData, basePic)
        End Select

    End Sub
    Private Shared Sub DrawTile_Point_Tile(ByRef g As Graphics, ByVal BoundaryRect As Rectangle,
                                           ByVal Interval As Integer, LPat As Line_Property, ByRef ScrData As Screen_info)

        Dim minx As Integer = BoundaryRect.Left
        Dim miny As Integer = BoundaryRect.Top
        Dim maxx As Integer = BoundaryRect.Right
        Dim maxy As Integer = BoundaryRect.Bottom

        Dim LineWidth As Single = LPat.BasicLine.SolidLine.Width
        Dim TCOL As Color = LPat.BasicLine.SolidLine.Color.getColor

        Dim Psize As Integer = ScrData.Get_Length_On_Screen(LineWidth)

        If Psize = 0 Then
            Psize = 1
        End If

        Dim Hint As Integer = Int(miny / Interval)
        Hint = Math.Abs(Hint - 1) Mod 2
        Dim sty As Single = Interval * Hint - Interval
        Dim ic As Integer = 0
        Dim LINY As Single
        Do
            LINY = sty + Interval * ic
            Dim stx As Single = Int(minx / Interval) * Interval - Interval * (Hint / 2 - 1)
            Dim ic2 As Integer = 0
            Dim psx As Single
            Do
                psx = stx + ic2 * Interval
                If Psize = 1 Then
                    g.FillRectangle(New SolidBrush(TCOL), psx, LINY, 1, 1)
                Else
                    Dim C_Rect As Rectangle = New Rectangle(psx - Psize / 2, LINY - Psize / 2, Psize, Psize)
                    g.FillEllipse(New SolidBrush(TCOL), C_Rect)
                End If
                ic2 += 1
            Loop While psx + Interval < maxx
            ic += 1
            Hint = 1 - Hint
        Loop While LINY + Interval < maxy
    End Sub
    Private Shared Sub DrawTile_Mark_Tile(ByRef g As Graphics, ByVal BoundaryRect As Rectangle,
                                          ByVal Interval As Integer, TI As Tile_Property,
                                          ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)


        Dim LineWidth As Single = TI.Line.BasicLine.SolidLine.Width
        Dim Psize As Integer = ScrData.Get_Length_On_Screen(LineWidth)

        If Psize = 0 Then
            Psize = 1
        End If

        Dim Hint As Integer = Int(BoundaryRect.Top / Interval)
        Hint = Math.Abs(Hint - 1) Mod 2
        Dim sty As Single = Interval * Hint - Interval
        Dim ic As Integer = 0
        Dim LINY As Single
        Do
            LINY = sty + Interval * ic
            Dim stx As Single = Int(BoundaryRect.Left / Interval) * Interval - Interval * (Hint / 2 - 1)
            Dim ic2 As Integer = 0
            Dim psx As Single
            Do
                psx = stx + ic2 * Interval
                clsDrawMarkFan.TileMark_Print(g, New Point(psx, LINY), Int(Psize / 2), TI.TileMark, TI.Line.BasicLine.SolidLine.Color, ScrData, basePic)
                ic2 += 1
            Loop While psx + Interval < BoundaryRect.Right
            ic += 1
            Hint = 1 - Hint
        Loop While LINY + Interval < BoundaryRect.Bottom
    End Sub
    Private Shared Sub DrawTile_Line_Tile(ByRef g As Graphics, ByVal BoundaryRect As Rectangle,
                                          ByVal LineDIR As enmTilePattern, ByVal Interval As Integer, LPat As Line_Property,
                                          ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)
        'LineDIR:0横　1縦　2右上から左下　3左上から右下

        Dim minx As Integer = BoundaryRect.Left
        Dim miny As Integer = BoundaryRect.Top
        Dim maxx As Integer = BoundaryRect.Right
        Dim maxy As Integer = BoundaryRect.Bottom
        Select Case LineDIR
            Case enmTilePattern.HorizontalLine
                Dim Hint As Single = Int(miny / Interval)
                Dim sty As Single = Interval * Hint - Interval
                Dim ic As Integer = 0
                Dim LINY As Single
                Do
                    LINY = sty + Interval * ic
                    clsDrawLine.Line(g, LPat, New Point(minx, LINY), New Point(maxx, LINY), ScrData, basePic)
                    ic += 1
                Loop While LINY + Interval < maxy
            Case enmTilePattern.VerticalLine
                Dim Hint As Single = Int(minx / Interval)
                Dim stx As Single = Interval * Hint - Interval
                Dim ic As Integer = 0
                Dim LINX As Single
                Do
                    LINX = stx + Interval * ic
                    clsDrawLine.Line(g, LPat, New Point(LINX, miny), New Point(LINX, maxy), ScrData, basePic)
                    ic += 1
                Loop While LINX + Interval < maxx
            Case Else
                Dim Interval2 As Single = Interval * Math.Sqrt(2)
                Dim X As Integer
                Dim x2 As Integer
                Select Case LineDIR
                    Case enmTilePattern.DiagonalLineRightUp
                        maxx = Int(maxx / Interval2) * Interval2 + Interval2
                        miny = Int(miny / Interval2) * Interval2
                        X = maxx
                        x2 = minx
                    Case enmTilePattern.DiagonalLineRightDown
                        miny = Int(miny / Interval2) * Interval2
                        minx = Int(minx / Interval2) * Interval2
                        X = minx
                        x2 = maxx
                End Select
                Dim w As Single = maxx - minx
                Dim Hint As Single = Int((miny - w) / Interval2)
                Dim sty As Single = Interval2 * Hint - Interval2
                Dim ic As Integer = 0
                Dim LINY As Single
                Dim cx As Integer
                Do
                    LINY = sty + Interval2 * ic
                    Dim Y As Integer = LINY
                    Dim y2 As Integer = LINY + w
                    Dim cx2 As Integer
                    If miny <= y2 And Y <= maxy Then
                        If Y < miny And y2 < maxy Then '上にはみ出る場合
                            cx = (X - x2) / (Y - y2) * (miny - Y) + X
                            clsDrawLine.Line(g, LPat, New Point(cx, miny), New Point(x2, y2), ScrData, basePic)
                        ElseIf Y <= miny And maxy < y2 Then  '上下にはみ出る場合
                            cx = (X - x2) / (Y - y2) * (miny - Y) + X
                            cx2 = (X - x2) / (Y - y2) * (maxy - Y) + X
                            clsDrawLine.Line(g, LPat, New Point(cx, miny), New Point(cx2, maxy), ScrData, basePic)
                        ElseIf maxy < y2 Then  '下にはみ出る場合
                            cx2 = (X - x2) / (Y - y2) * (maxy - Y) + X
                            clsDrawLine.Line(g, LPat, New Point(X, Y), New Point(cx2, maxy), ScrData, basePic)
                        Else  'はみ出ない場合
                            clsDrawLine.Line(g, LPat, New Point(X, Y), New Point(x2, y2), ScrData, basePic)
                        End If
                    End If
                    ic += 1
                Loop While LINY + Interval2 < maxy

        End Select


    End Sub


End Class
