
Public Class clsDrawMarkFan
    Public Shared Mark_Num As Integer
    Private Shared Mark_Pointer() As Integer
    Public Shared Mark_Caption() As String
    Private Shared Mark_Stac() As Integer
    Shared Sub New()
        Dim inDataFile As String = "MarkShape.csv"
        ReDim Mark_Pointer(10)
        ReDim Mark_Caption(10)
        ReDim Mark_Stac(50)
        Dim i As Integer = 0
        Dim n As Integer = 0
        Dim sr As New System.IO.StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\" + inDataFile, System.Text.Encoding.GetEncoding("shift_jis"))
        Do Until sr.EndOfStream
            Dim Line As String = sr.ReadLine
            If Microsoft.VisualBasic.Left(Line, 1) <> "'" And Line <> "" Then
                Mark_Pointer(i) = n
                Dim Mark_XY_Split() As String = Line.Split(",")
                Dim mkn As Integer = Mark_XY_Split.GetLength(0)
                ReDim Preserve Mark_Stac(n + mkn * 3)
                Mark_Caption(i) = Mark_XY_Split(0)
                For j As Integer = 1 To mkn - 1
                    If Mark_XY_Split(j) <> "" Then
                        Mark_Stac(n) = Val(Mark_XY_Split(j))
                        n += 1
                    End If
                Next
                i += 1
                ReDim Preserve Mark_Pointer(i)
                ReDim Preserve Mark_Caption(i)
            End If
        Loop
        sr.Close()
        Mark_Num = i
    End Sub
    Public Shared Sub TileMark_Print(ByRef g As Graphics, ByVal Position As Point, ByVal r As Integer,
                                 ByRef TileMK As Tile_Mark_Property, ByVal InnerColor As colorARGB, ByRef ScrData As Screen_info,
                                 ByRef basePic As BasePicture_Info)
        Dim MK As Mark_Property = clsBase.Mark
        With TileMK
            MK.ShapeNumber = .ShapeNumber
            MK.PrintMark = .PrintMark
            MK.PictureNumber = .PictureNumber
            MK.wordmark = .wordmark
            MK.WordFont = clsBase.Font
            MK.WordFont.Body.Name = .WordFontName
            MK.WordFont.Body.Kakudo = .Kakudo
            MK.Line.BasicLine.SolidLine.Color = .Mark_Line_Color
        End With
        MK.Tile.TileCode = enmTilePattern.Paint
        MK.WordFont.Body.Color = InnerColor
        MK.Tile.Line.BasicLine.SolidLine.Color = InnerColor
        Mark_Print(g, Position, r, MK, ScrData, basePic)
    End Sub
    Public Shared Sub Mark_Print(ByRef g As Graphics, ByVal Position As Point, ByVal r As Integer,
                                 ByRef Mark As Mark_Property, ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)

        With Mark

            Select Case .PrintMark
                Case enmMarkPrintType.Mark
                    clsDrawTile.Draw_Tile_RoundBox(g, spatial.Get_Rectangle(Position, r), Mark.WordFont.Back, .WordFont.Body.Kakudo, ScrData, basePic)
                    Dim mkn As Integer = 0
                    Dim n As Integer = Mark_Pointer(.ShapeNumber)
                    Dim mk_fign As Integer = Mark_Stac(n)
                    n += 1
                    Do
                        Dim Shape As Integer = Mark_Stac(n)
                        n += 1
                        Select Case Shape
                            Case 0
                                Dim Circle_Tile As Tile_Property
                                If Mark_Stac(n + 4) = 1 Then
                                    Circle_Tile = .Tile
                                Else
                                    Circle_Tile = clsBase.Tile
                                    Circle_Tile.TileCode = enmTilePattern.Blank
                                End If
                                Dim P2 As Point = Position
                                P2.Offset(Mark_Stac(n) * r / 100, Mark_Stac(n + 1) * r / 100)
                                Draw_DAEN(g, P2, Mark_Stac(n + 2) * r / 100 _
                                    , Mark_Stac(n + 3) * r / 100, .WordFont.Body.Kakudo, .Line, Circle_Tile, True, ScrData, basePic)
                                n += 5
                            Case 1 'ポリゴン
                                Dim poln As Integer = Mark_Stac(n)
                                n += 1
                                Dim ln2 As Integer = 0
                                Dim pxy(100) As Point
                                Dim nPolyP(poln - 1) As Integer
                                For j As Integer = 0 To poln - 1
                                    Dim ln As Integer = Mark_Stac(n)
                                    Dim oln As Integer = ln2
                                    n += 1
                                    Dim ln3 As Integer
                                    If ln = -1 Then '円の場合
                                        Dim en_xy() As Point
                                        Dim P2 As Point = Position
                                        P2.Offset(Mark_Stac(n) * r / 100, Mark_Stac(n + 1) * r / 100)
                                        Dim f As Boolean = Get_DAEN_Peri_XY(P2, r * Mark_Stac(n + 2) / 100, r * Mark_Stac(n + 3) / 100,
                                            .WordFont.Body.Kakudo, ln3, en_xy, ScrData)
                                        n += 4
                                        ln2 += ln3
                                        ReDim Preserve pxy(ln2 - 1)
                                        For i As Integer = 0 To ln3 - 1
                                            pxy(oln + i) = en_xy(i)
                                        Next
                                    Else  '通常の多角形
                                        ln2 += ln
                                        ReDim Preserve pxy(ln2 - 1)
                                        For i As Integer = 0 To ln - 1
                                            pxy(oln + i) = New Point(r * Mark_Stac(n), r * Mark_Stac(n + 1))
                                            pxy(oln + i) = spatial.Trans2D(pxy(oln + i), -Mark.WordFont.Body.Kakudo)
                                            With pxy(oln + i)
                                                .X = .X / 100 + Position.X
                                                .Y = .Y / 100 + Position.Y
                                            End With

                                            n += 2
                                        Next
                                        ln3 = ln
                                    End If
                                    nPolyP(j) = ln3
                                Next
                                clsDrawTile.Draw_Tile_and_Paint_and_Line(g, pxy, nPolyP, poln, .Tile, .Line, ScrData, basePic)
                            Case 2
                                Dim ln As Integer = Mark_Stac(n)
                                n += 1
                                Dim pxy(ln - 1) As Point
                                For i As Integer = 0 To ln - 1
                                    pxy(i) = New Point(r * Mark_Stac(n), r * Mark_Stac(n + 1))
                                    pxy(i) = spatial.Trans2D(pxy(i), -Mark.WordFont.Body.Kakudo)
                                    With pxy(i)
                                        .X = .X / 100 + Position.X
                                        .Y = .Y / 100 + Position.Y
                                    End With
                                    n += 2
                                Next
                                clsDrawLine.Line(g, .Line, ln, pxy, ScrData, basePic)
                        End Select
                        mkn += 1
                    Loop While mkn < mk_fign

                Case enmMarkPrintType.Word
                    Dim W_Font As Font_Property = .WordFont
                    If r = 0 Then
                        r = 1
                    End If
                    If ScrData.SampleBoxFlag = False Then
                        W_Font.Body.Size = ScrData.Get_Length_On_BaseMap(r * 2)
                    Else
                        W_Font.Body.Size = r * 2
                    End If
                    clsDraw.print(g, .wordmark, Position, W_Font, enmHorizontalAlignment.Center, enmVerticalAlignment.Center, ScrData, basePic)
                Case enmMarkPrintType.Picture
                    If Mark.WordFont.Back.Tile.TileCode <> enmTilePattern.Blank Then
                        '内部の塗りつぶし
                        Dim bk As BackGround_Box_Property = Mark.WordFont.Back
                        bk.Line = clsBase.BlancLine
                        clsDrawTile.Draw_Tile_RoundBox(g, spatial.Get_Rectangle(Position, r), bk, .WordFont.Body.Kakudo, ScrData, basePic)
                    End If
                    '画像
                    If .PictureNumber <> -1 Then
                        Dim pic As Picture_Property = basePic.PictureData(.PictureNumber)
                        clsDraw.DrawPicture(g, pic.GetBitmap, Position, r,
                                                   pic.TransParency_f, pic.TransParency_Color, pic.TransRange, .PictureAlpahValue, .WordFont.Body.Kakudo,
                                                  pic.Alternate_f, pic.Alternate_Color, .WordFont.Body.Color)
                    End If
                    '輪郭線
                    Dim bk2 As BackGround_Box_Property = Mark.WordFont.Back
                    bk2.Tile = clsBase.BlancTile
                    clsDrawTile.Draw_Tile_RoundBox(g, spatial.Get_Rectangle(Position, r), bk2, .WordFont.Body.Kakudo, ScrData, basePic)

            End Select
        End With
    End Sub

    Public Function Mark_Set_With_Tile(Mark As Mark_Property) As Boolean

        'Push.Mark = Mark
        'frmMark_Set.Show 1

        'If Cancel_Button = False Then
        '    Mark_Set_With_Tile = True
        '    Mark = Push.Mark
        'Else
        '    Mark_Set_With_Tile = False
        'End If

        'Unload frmMark_Set
    End Function
    ''' <summary>
    ''' 扇形描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="CP"></param>
    ''' <param name="r"></param>
    ''' <param name="start_p"></param>
    ''' <param name="end_p"></param>
    ''' <param name="L"></param>
    ''' <param name="Tile"></param>
    ''' <param name="ScrData"></param>
    ''' <param name="basePic"></param>
    ''' <remarks></remarks>
    Public Shared Sub Draw_Fan(ByRef g As Graphics, ByVal CP As Point, ByVal r As Integer,
                 ByVal start_p As Double, ByVal end_p As Double, ByRef L As Line_Property, ByRef Tile As Tile_Property,
                 ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)


        Dim pxy() As Point = spatial.Get_Fan_Coordinates(CP, r, start_p, end_p, True)
        Dim nPolyn(0) As Integer
        nPolyn(0) = pxy.Length()
        clsDrawTile.Draw_Tile_and_Paint_and_Line(g, pxy, nPolyn, 1, Tile, L, ScrData, basePic)


    End Sub

    Public Shared Function Draw_DAEN(ByRef g As Graphics, ByVal Position As Point, ByVal XR As Integer, ByVal YR As Integer,
                       ByVal Kakudo As Single, ByRef L As Line_Property, ByRef T As Tile_Property, ByVal Real_Circle_F As Boolean,
                       ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info) As Boolean


        If XR = 0 Or YR = 0 Then Exit Function

        Dim inf As Boolean
        If XR = YR And Real_Circle_F = True And _
            L.BasicLine.pattern <> 1 And L.CrossLine.XLine_f = False And (T.TileCode = enmTilePattern.Blank Or T.TileCode = enmTilePattern.Paint) Then
            '楕円が真円で内部がベタ塗りか空白、線が実線または透明の場合
            Dim C_Rect As Rectangle = New Rectangle(Position.X - XR, Position.Y - YR, XR * 2, YR * 2)

            If ScrData.SampleBoxFlag = False Then
                If spatial.Compare_Two_Rectangle_Position(C_Rect, Kakudo, ScrData.MapScreen_Scale) = cstRectangle_Cross.cstOuter Then
                    Return False
                End If
            End If

            Dim w As Integer = ScrData.Get_Line_Width(L.BasicLine.SolidLine.Width)
            Select Case T.TileCode
                Case enmTilePattern.Blank
                    If L.BasicLine.pattern <> enmLinePattern.InVisible Then
                        clsDraw.Ellipse(g, Position, XR, New Pen(L.BasicLine.SolidLine.Color.getColor, w))
                    End If
                Case enmTilePattern.Paint
                    If L.BasicLine.pattern <> enmLinePattern.InVisible Then
                        clsDraw.Ellipse(g, Position, XR, New SolidBrush(T.Line.BasicLine.SolidLine.Color.getColor), New Pen(L.BasicLine.SolidLine.Color.getColor, w))
                    Else
                        clsDraw.FillEllipse(g, Position, XR, New SolidBrush(T.Line.BasicLine.SolidLine.Color.getColor))
                    End If
            End Select
            inf = True
        Else
            '円の周の座標を計算する必要あり.
            Dim n As Integer
            Dim pxy() As Point, nPolyn(0) As Integer
            inf = Get_DAEN_Peri_XY(Position, XR, YR, Kakudo, n, pxy, ScrData)
            If inf = True Then
                nPolyn(0) = n
                clsDrawTile.Draw_Tile_and_Paint_and_Line(g, pxy, nPolyn, 1, T, L, ScrData, basePic)

            End If
        End If
        Draw_DAEN = inf

    End Function
    ''' <summary>
    ''' 円の周の座標を計算(整数)
    ''' </summary>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="XR"></param>
    ''' <param name="YR"></param>
    ''' <param name="Kakudo"></param>
    ''' <param name="n"></param>
    ''' <param name="pxy"></param>
    ''' <param name="ScrData"></param>
    ''' <param name="Size_Mode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Get_DAEN_Peri_XY(ByVal Position As Point, ByVal XR As Integer, ByVal YR As Integer,
                                      ByVal Kakudo As Single, ByRef n As Integer,
                                      ByRef pxy() As Point, ByRef ScrData As Screen_info) As Boolean

        Dim ST As Single = 1 / ((XR + YR) / 5)
        Dim cn As Integer = CInt(Math.PI * 2 / ST) + 5
        ReDim pxy(cn - 1)

        Get_DAEN_Peri_XY = False
        Dim ff = False
        n = 0
        Do
            Dim ST2 As Single = n * ST
            Dim f As Boolean = Draw_DAEN_XY(ST2, Position, XR, YR, Kakudo, n, pxy, ScrData)
            n += 1
            If f = True Then ff = True
        Loop While n * ST < Math.PI * 2
        pxy(n) = pxy(0)
        ReDim Preserve pxy(n)
        n += 1
        Return ff
    End Function
    Public Shared Function Get_DAEN_IdoKedo(ByVal Kedo As Single, ByVal Ido As Single, ByVal XR As Single, ByVal YR As Single,
                                     ByVal Kakudo As Single, ByRef n As Integer, ByRef pxy() As PointF) As Boolean
        '緯度経度上の円の周の座標を計算(単精度)

        Dim ST As Single = 1 / ((XR + YR) * 10)
        If ST > 0.2 Then
            ST = 0.2
        End If
        Dim cn As Integer = CInt(Math.PI * 2 / ST) + 5
        ReDim pxy(cn - 1)

        n = 0
        For p As Single = 0 To Math.PI * 2 Step ST
            Dim point2 As PointF = New PointF(Math.Cos(p) * XR, Math.Sin(p) * YR)
            point2 = spatial.Trans2D(point2, Kakudo)
            point2.X += Kedo
            point2.Y = -point2.Y + Ido
            pxy(n) = point2
            n += 1
        Next
        pxy(n) = pxy(0)
        n += 1
        Return True

    End Function

    Private Shared Function Draw_DAEN_XY(ByVal p As Single, ByVal Position As Point, ByVal XR As Integer, ByVal YR As Integer,
                                  ByVal Kakudo As Single, ByVal n As Integer,
                                  ByRef pxy() As Point, ByRef ScrData As Screen_info) As Boolean

        Dim point2 As Point = New Point(Math.Cos(p) * XR, Math.Sin(p) * YR)
        point2 = spatial.Trans2D(point2, Kakudo)
        point2.X += Position.X
        point2.Y = -point2.Y + Position.Y
        pxy(n) = point2
        Dim f As Boolean = False
        If ScrData.SampleBoxFlag = False Then
            If clsGeneric.Check_Point_in_screen(pxy(n), ScrData, 1) = True Then
                f = True
            End If
        Else
            f = True
        End If
        Return f
    End Function

    Public Shared Sub Draw_Mark_Sample_Box(ByRef picMarkBox As PictureBox, ByRef MK As Mark_Property, ByVal ScrData As Screen_info, ByRef basePic As BasePicture_Info)
        With picMarkBox
            Dim w As Integer = .Width
            Dim H As Integer = .Height
            ScrData.SampleBoxFlag = True
            If .BorderStyle = BorderStyle.Fixed3D Then
                w -= 4
                H -= 4
            End If
            Dim Canvas As Bitmap = New Bitmap(w, H)
            Dim g As Graphics = Graphics.FromImage(Canvas)
            g.Clear(.BackColor)
            Mark_Print(g, New Point(w / 2, H / 2), Math.Min(w, H) * 0.4, MK, ScrData, basePic)
            g.Dispose()
            .Image = Canvas
            .Refresh()
        End With
    End Sub
    Public Shared Sub TileMark_Print_Sample_Box(ByRef picTileMarkBox As PictureBox, ByRef TileMK As Tile_Mark_Property,
                                                ByVal InnerColor As colorARGB, ByVal ScrData As Screen_info, ByRef basePic As BasePicture_Info)
        With picTileMarkBox
            Dim w As Integer = .Width
            Dim H As Integer = .Height
            ScrData.SampleBoxFlag = True
            If .BorderStyle = BorderStyle.Fixed3D Then
                w -= 4
                H -= 4
            End If
            Dim Canvas As Bitmap = New Bitmap(w, H)
            Dim g As Graphics = Graphics.FromImage(Canvas)
            g.Clear(.BackColor)
            TileMark_Print(g, New Point(w / 2, H / 2), Math.Min(w, H) * 0.4, TileMK, InnerColor, ScrData, basePic)
            g.Dispose()
            .Image = Canvas
            .Refresh()
        End With
    End Sub


End Class
