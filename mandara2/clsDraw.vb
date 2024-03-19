
Public Class clsDraw

    ''' <summary>
    ''' ポリゴン塗りつぶし（単色）
    ''' </summary>
    ''' <param name="g">グラフィックス</param>
    ''' <param name="Pon">ポリゴン数</param>
    ''' <param name="pxy">座標列</param>
    ''' <param name="nPolyP">ポリゴンごとの座標数</param>
    ''' <param name="Fcolor">塗り色</param>
    ''' <remarks></remarks>
    Public Shared Sub DrawPolyPolygon(ByRef g As Graphics, ByVal Pon As Integer, ByRef pxy() As Point, ByRef nPolyP() As Integer, ByVal Fcolor As Color)
        Dim PolyRegion As Region = Get_Region_From_PointStac(Pon, pxy, nPolyP)
        g.FillRegion(New SolidBrush(Fcolor), PolyRegion)
    End Sub
    ''' <summary>
    ''' クリップ領域を設定
    ''' </summary>
    ''' <param name="g">グラフィックス</param>
    ''' <param name="Pon">ポリゴン数</param>
    ''' <param name="pxy">座標列</param>
    ''' <param name="nPolyP">ポリゴンごとの座標数</param>
    ''' <returns>設定前のクリップ領域</returns>
    ''' <remarks></remarks>
    Public Shared Function Set_Clipping_Region(ByRef g As Graphics, ByVal Pon As Integer, ByRef pxy() As Point, ByRef nPolyP() As Integer, ByRef makeRegion As Region) As Region

        Dim clipF As Region = g.Clip
        makeRegion = Get_Region_From_PointStac(Pon, pxy, nPolyP)
        Try
            g.SetClip(makeRegion, System.Drawing.Drawing2D.CombineMode.Intersect)
        Catch ex As Exception
            Return Nothing
        End Try
        Return clipF
    End Function
    ''' <summary>
    ''' 複数ポリゴン座標配列からリージョン作成
    ''' </summary>
    ''' <param name="Pon">ポリゴン数</param>
    ''' <param name="pxy">座標列</param>
    ''' <param name="nPolyP">ポリゴンごとの座標数</param>
    ''' <returns>リージョン</returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Region_From_PointStac(ByVal Pon As Integer, ByRef pxy() As Point, ByRef nPolyP() As Integer) As Region
        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
        Dim n As Integer = 0
        For i As Integer = 0 To Pon - 1
            If nPolyP(i) > 2 Then
                Dim pointsub(nPolyP(i) - 1) As Point
                Array.Copy(pxy, n, pointsub, 0, nPolyP(i))
                path.AddPolygon(pointsub)
            End If
            n += nPolyP(i)
        Next
        Return New Region(path)
    End Function

    ''' 
    ''' 円の塗りつぶし
    ''' 
    ''' g 描画先グラフィックス
    ''' P 中心位置
    ''' r 半径
    ''' InnerBrush 内部ブラシ
    ''' 
    Public Overloads Shared Sub FillEllipse(ByRef g As Graphics, ByVal Point As Point, ByVal r As Integer, _
                                  ByVal InnerBrush As Brush)
        Dim cp As Point = Point
        cp.Offset(-r, -r)
        Dim rectEllipse As Rectangle = New Rectangle(cp, New Size(r * 2, r * 2))
        g.FillEllipse(InnerBrush, rectEllipse)

    End Sub
    ''' <summary>
    ''' 円の描画
    ''' </summary>
    ''' <param name="g">描画先グラフィックス</param>
    ''' <param name="P">中心位置</param>
    ''' <param name="r">半径</param>
    ''' <param name="InnerBrush">内部ブラシ</param>
    ''' <param name="BorderPen">境界ペン</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub Ellipse(ByRef g As Graphics, ByVal Point As Point, ByVal r As Integer, _
                                  ByVal InnerBrush As Brush, ByVal BorderPen As Pen)
        Dim cp As Point = Point
        cp.Offset(-r, -r)
        Dim rectEllipse As Rectangle = New Rectangle(cp, New Size(r * 2, r * 2))
        g.FillEllipse(InnerBrush, rectEllipse)
        g.DrawEllipse(BorderPen, rectEllipse)

    End Sub
    Public Overloads Shared Sub Ellipse(ByRef g As Graphics, ByVal Point As Point, ByVal r As Integer, _
                                   ByVal BorderPen As Pen)
        Dim cp As Point = Point
        cp.Offset(-r, -r)
        Dim rectEllipse As Rectangle = New Rectangle(cp, New Size(r * 2, r * 2))
        g.DrawEllipse(BorderPen, rectEllipse)

    End Sub

    ''' <summary>
    ''' 文字列描画
    ''' </summary>
    ''' <param name="g">描画先グラフィックス</param>
    ''' <param name="Word">文字列</param>
    ''' <param name="P">位置</param>
    ''' <param name="Font">フォント</param>
    ''' <param name="brush">内部ブラシ</param>
    ''' <param name="HorizonalAlignment">水平方向の位置</param>
    ''' <param name="VerticalAlignment">垂直方向の位置</param>
    ''' <remarks></remarks>
    Public Shared Sub print(ByRef g As Graphics, ByVal Word As String, ByVal P As Point, ByVal Font As Font, _
                            ByVal brush As Brush, ByVal HorizonalAlignment As StringAlignment, ByVal VerticalAlignment As StringAlignment)

        Dim sf As New StringFormat
        sf.Alignment = HorizonalAlignment
        sf.LineAlignment = VerticalAlignment

        g.DrawString(Word, Font, brush, P, sf)

    End Sub
    Public Shared Function print(ByRef g As Graphics, ByVal Word As String, ByVal P As Point, ByVal Font_P As Font_Property, _
                            ByVal HorizonalAlignment As enmHorizontalAlignment, ByVal VerticalAlignment As enmVerticalAlignment,
                            ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)

        Dim Word_Array As New List(Of String)

        Dim Word_a As String = Word

        Dim xw As Integer
        Dim yw As Integer = -1
        Word_Array = TextCut_for_print(g, Word_a, Font_P, True, -1, xw, yw, ScrData)

        Dim an As Integer = Word_Array.Count
        Dim X As Integer, Y As Integer
        Select Case HorizonalAlignment
            Case enmHorizontalAlignment.Left '左座標
                X = P.X
            Case enmHorizontalAlignment.Center '中座標
                X = P.X - xw / 2
            Case enmHorizontalAlignment.Right '右座標
                X = P.X - xw
        End Select
        Select Case VerticalAlignment
            Case enmVerticalAlignment.Top '上座標
                Y = P.Y
            Case enmVerticalAlignment.Center '中座標
                Y = P.Y - yw * an / 2
            Case enmVerticalAlignment.Bottom '下座標
                Y = P.Y - yw * an
        End Select


        Dim C_Rect As Rectangle = New Rectangle(X, Y, xw, yw * an)

        Dim f As Boolean = False
        If ScrData.SampleBoxFlag = False Then
            If spatial.Compare_Two_Rectangle_Position(C_Rect, Font_P.Body.Kakudo, ScrData.MapScreen_Scale) <> cstRectangle_Cross.cstOuter Then
                f = True
            Else
                f = False
            End If
        Else
            f = True
        End If

        If f = True Then
            Dim TH As Integer
            If ScrData.SampleBoxFlag = False Then
                TH = ScrData.Get_Length_On_Screen(Font_P.Body.Size)
            Else
                TH = Font_P.Body.Size
            End If
            Dim npw As Integer = 1
            If Font_P.Body.FringeF = True Then
                npw = Math.Max(TH * Font_P.Body.FringeWidth / 100 / 2, 3)
            End If
            Dim ita_plus As Integer = 0
            If Font_P.Body.italic = True Then
                ita_plus = TH / 5
            End If
            clsDrawTile.Draw_Tile_RoundBox(g, Rectangle.FromLTRB(X - npw, Y - npw, X + xw + npw - 1 + ita_plus, Y + yw * an + npw - 1),
                                          Font_P.Back, Font_P.Body.Kakudo, ScrData, basePic)
            For i As Integer = 0 To an - 1
                Dim P2 As New Point(-xw / 2, -yw / 2)
                P2 = spatial.Trans2D(P2, -Font_P.Body.Kakudo)
                P2 = Point.Add(P2, New Size(X + xw / 2, Y + yw * i + yw / 2))
                DrawText2(g, P2, Word_Array(i), Font_P, Font_P.Body.FringeF, ScrData)
            Next

        End If
        Return f
    End Function

    Private Shared Sub DrawText2(ByRef g As Graphics, ByVal P As Point, ByVal Tx As String,
                          P_Font As Font_Property, ByVal FringeF As Boolean, ByRef ScrData As Screen_info)


        Dim hnfont As Font
        Dim TH As Integer
        If ScrData.SampleBoxFlag = False Then
            TH = ScrData.Get_Length_On_Screen(P_Font.Body.Size)
        Else
            TH = P_Font.Body.Size
        End If
        With P_Font.Body
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
            hnfont = New Font(.Name, TH, fstyle, GraphicsUnit.Pixel)
        End With
        If FringeF = True Then
            Dim gp As New System.Drawing.Drawing2D.GraphicsPath()
            Dim initialMode As System.Drawing.Drawing2D.SmoothingMode = g.SmoothingMode
            Dim initialQuality As System.Drawing.Drawing2D.CompositingQuality = g.CompositingQuality
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
            gp.AddString(Tx, hnfont.FontFamily, hnfont.Style, hnfont.Size, P, StringFormat.GenericDefault)
            If P_Font.Body.Kakudo <> 0 Then
                Dim translateMatrix As New System.Drawing.Drawing2D.Matrix
                translateMatrix.RotateAt(-P_Font.Body.Kakudo, P)
                gp.Transform(translateMatrix)
            End If
            Dim w As Integer = Math.Max(TH * P_Font.Body.FringeWidth / 100 / 2, 1)
            Dim pen As New Pen(P_Font.Body.FringeColor.getColor, w)
            pen.LineJoin = Drawing2D.LineJoin.Round
            g.DrawPath(pen, gp)
            g.FillPath(New SolidBrush(P_Font.Body.Color.getColor), gp)
            gp.Dispose()
            g.SmoothingMode = initialMode
            g.CompositingQuality = initialQuality
        Else
            g.TranslateTransform(P.X, P.Y)
            g.RotateTransform(-P_Font.Body.Kakudo)
            g.DrawString(Tx, hnfont, New SolidBrush(P_Font.Body.Color.getColor), 0, 0)
            g.RotateTransform(P_Font.Body.Kakudo)
            g.TranslateTransform(-P.X, -P.Y)
        End If
        hnfont.Dispose()

    End Sub

    ''' <summary>
    ''' 指定した幅で文字列を分割して返す
    ''' </summary>
    ''' <param name="g">グラフィックス</param>
    ''' <param name="T">テキスト</param>
    ''' <param name="P_Font">フォントプロパティ</param>
    ''' <param name="Orikaesi_F">折り返す場合True。</param>
    ''' <param name="Max_Width">最大幅。Max_Widthに0以下を指定すると長さは検討しない</param>
    ''' <param name="RealWidth">実際の最大幅を返す</param>
    ''' <param name="Tx_Height">テキスト１文字の高さを返す（戻り値）</param>
    ''' <param name="ScrData">Screen_info</param>
    ''' <returns>折り返して分割した文字列の入ったList(Of String)</returns>
    ''' <remarks></remarks>
    Public Shared Function TextCut_for_print(ByRef g As Graphics, ByVal T As String, ByRef P_Font As Font_Property, ByVal Orikaesi_F As Boolean,
                                             ByRef Max_Width As Integer, ByRef RealWidth As Integer, ByRef Tx_Height As Integer,
                                             ByRef ScrData As Screen_info) As List(Of String)


        Dim Out_Text As New List(Of String)

        Dim TH As Integer
        If ScrData.SampleBoxFlag = False Then
            TH = ScrData.Get_Length_On_Screen(P_Font.Body.Size)
        Else
            TH = P_Font.Body.Size
        End If
        If TH = 0 Then
            Return Out_Text
        End If

        Dim hnfont As Font
        With P_Font.Body
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
            hnfont = New Font(.Name, TH, fstyle, GraphicsUnit.Pixel)
        End With

        Dim FSize As SizeF
        Dim subText As String = ""
        Dim i As Integer = 1
        Dim Mxw As Integer = 0
        Do
            Dim MidText As String = Mid(T, i, 1)
            If MidText = Chr(13) Then
                i += 2
                Out_Text.Add(subText)
                subText = ""
            Else
                FSize = g.MeasureString(subText & MidText, hnfont)
                If Max_Width > 0 Then
                    If FSize.Width > Max_Width Then
                        Out_Text.Add(subText)
                        i += 1
                        subText = MidText
                    Else
                        Mxw = Math.Max(Mxw, FSize.Width)
                        subText = subText & MidText
                        i += 1
                    End If
                Else
                    subText = subText & MidText
                    i += 1
                    Mxw = Math.Max(Mxw, FSize.Width)
                End If
            End If
        Loop While i <= Len(T)
        Out_Text.Add(subText)

        If Orikaesi_F = False Then
            For j As Integer = Out_Text.Count - 1 To 1 Step -1
                Out_Text.RemoveAt(j)
            Next
        End If

        RealWidth = Mxw
        Tx_Height = FSize.Height

        Return Out_Text


    End Function
    ''' <summary>
    ''' FillRegion(複数ポリゴンの塗りつぶし)
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="Brush">ブラシ</param>
    ''' <param name="path">Drawing2D.GraphicsPath</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub FillRegion(ByRef g As Graphics, ByVal Brush As Brush, ByRef path As Drawing2D.GraphicsPath)
        Dim region As New Region(path)
        g.FillRegion(Brush, region)
    End Sub
    ''' <summary>
    '''  FillRegion(複数ポリゴンの塗りつぶしと輪郭)
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="Pen">ペン</param>
    ''' <param name="Brush">ブラシ</param>
    ''' <param name="path">Drawing2D.GraphicsPath</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub FillRegion(ByRef g As Graphics, ByVal Pen As Pen, ByVal Brush As Brush, ByRef path As Drawing2D.GraphicsPath)
        Dim region As New Region(path)
        g.FillRegion(Brush, region)
        g.DrawPath(Pen, path)
    End Sub

    Public Shared Sub DrawPicture(ByRef g As Graphics, ByRef bmp As Bitmap, ByVal CenteP As Point, ByVal rad As Single,
                              ByVal TransColFlag As Boolean, ByVal transCol As colorARGB, ByVal TransRange As Single,
                              ByVal AlphaValue As Integer, ByVal Rotate As Single,
                              ByVal ColorChangeFlag As Boolean, ByVal OldCOlor As colorARGB, ByVal newColor As colorARGB)

        Dim bmpSize = New Size(bmp.Width, bmp.Height)
        Dim consize As Size
        If bmpSize.Width >= bmpSize.Height Then
            consize.Width = rad * 2
            consize.Height = consize.Width * (bmp.Height / bmp.Width)
        Else
            consize.Height = rad * 2
            consize.Width = consize.Height * (bmp.Width / bmp.Height)
        End If

        Dim ia As New System.Drawing.Imaging.ImageAttributes()
        Dim cm As New System.Drawing.Imaging.ColorMatrix()
        'ColorMatrixの行列の値を変更して、アルファ値を指定
        cm.Matrix00 = 1
        cm.Matrix11 = 1
        cm.Matrix22 = 1
        cm.Matrix33 = AlphaValue / 255
        cm.Matrix44 = 1
        ia.SetColorMatrix(cm)

        If TransColFlag = True Then
            '透過色を指定して描画
            Dim p As Integer = 256 * TransRange / 100
            Dim r1 As Integer = Math.Min(transCol.r + p, 255)
            Dim g1 As Integer = Math.Min(transCol.g + p, 255)
            Dim b1 As Integer = Math.Min(transCol.b + p, 255)
            Dim HighColor As Color = Color.FromArgb(r1, g1, b1) '白
            Dim r2 As Integer = Math.Max(transCol.r - p, 0)
            Dim g2 As Integer = Math.Max(transCol.g - p, 0)
            Dim b2 As Integer = Math.Max(transCol.b - p, 0)
            Dim LowColor As Color = Color.FromArgb(r2, g2, b2) '白
            ia.SetColorKey(LowColor, HighColor)
        End If

        If ColorChangeFlag = True Then
            '色を変換して描画
            Dim cms() As System.Drawing.Imaging.ColorMap = {New System.Drawing.Imaging.ColorMap()}
            cms(0).OldColor = OldCOlor.getColor
            cms(0).NewColor = newColor.getColor
            ia.SetRemapTable(cms)
        End If

        'ワールド変換行列を単位行列にリセット
        g.ResetTransform()
        ''ワールド変換行列を下に10平行移動する
        g.TranslateTransform(CenteP.X, CenteP.Y)
        g.RotateTransform(-Rotate)
        '画像を描画
        g.DrawImage(bmp, New Rectangle(-consize.Width / 2, -consize.Height / 2, consize.Width, consize.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, ia)
        g.ResetTransform()


    End Sub
End Class

Public Class clsDrawLine
    Private Structure OptionalLine_Var_Info
        Dim L_First_F As Boolean
        Dim Old_l_x As Integer
        Dim Old_l_y As Integer
        Dim Accum_Distance As Single
        Dim LineRepN As Integer
        Dim LineStac As List(Of Integer)
        Dim B_Line_middle_num As Integer
    End Structure

    Private Shared Var_OptionalLine As OptionalLine_Var_Info

    Private Structure BrokenLine_middle_Data_Info
        Dim XYstac As Integer
        Dim Pointnum As Integer
        Dim kazari_stac As Integer
    End Structure
    Private Shared B_LineXY As List(Of PointF)
    Private Shared B_Line_middle() As BrokenLine_middle_Data_Info

    ''' <summary>
    ''' 矢印の描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="P">矢の先端の座標</param>
    ''' <param name="BeforPoint">矢の先端の座標の1つ前の座標</param>
    ''' <param name="LPat"></param>
    ''' <param name="DArrow"></param>
    ''' <param name="ScrData"></param>
    ''' <remarks></remarks>
    Public Shared Sub Arrow(ByVal g As Graphics, ByVal P As PointF, ByVal BeforPoint As PointF,
                     ByRef LPat As Line_Property, ByRef DArrow As Arrow_Data,
                     ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)
        Dim e2 As PointF
        Dim e3 As PointF
        Dim e4 As PointF
        Dim Fillcol As colorARGB
        Draw_Arrow_Keisan(e3, e2, e4, Fillcol, P, BeforPoint, LPat, DArrow, False, ScrData)
        Dim pxy(3) As Point
        pxy(0) = ScrData.Get_SxSy_With_3D(e3)
        pxy(1) = ScrData.Get_SxSy_With_3D(P)
        pxy(2) = ScrData.Get_SxSy_With_3D(e4)


        Select Case DArrow.ArrowHeadType
            Case enmArrowHeadType.Line
                Dim LA_Pat As Line_Property = LPat
                With LA_Pat.Edge_Connect_Pattern
                    .MiterLimitValue = 10
                    .Join_Pattern = 2
                    .Edge_Pattern = 2
                End With
                ReDim Preserve pxy(2)
                clsDrawLine.Line(g, LA_Pat, 3, pxy, ScrData, basePic)
            Case enmArrowHeadType.Fill
                pxy(3) = pxy(0)
                g.FillPolygon(New SolidBrush(Fillcol.getColor), pxy)
        End Select
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="a1">矢印の端1点目（戻り値）</param>
    ''' <param name="ac">矢印の先端点（戻り値）</param>
    ''' <param name="a2">矢印の端2点目（戻り値）</param>
    ''' <param name="Fillcol">塗りつぶし矢印の内部色（戻り値）</param>
    ''' <param name="OP"></param>
    ''' <param name="BeforPoint"></param>
    ''' <param name="LPat"></param>
    ''' <param name="DArrow"></param>
    ''' <param name="Check_F"></param>
    ''' <param name="ScrData"></param>
    ''' <remarks></remarks>
    Private Shared Sub Draw_Arrow_Keisan(ByRef a1 As PointF, ByRef ac As PointF, ByRef a2 As PointF,
                                         ByRef Fillcol As colorARGB, _
                    ByVal OP As PointF, ByVal BeforPoint As PointF, ByRef LPat As Line_Property,
                    ByVal DArrow As Arrow_Data, ByVal Check_F As Boolean, ByRef ScrData As Screen_info)

        Dim e2 As PointF

        Dim tva As Single, en As Single
        Dim x2 As Single, y2 As Single
        Dim sita As Single
        Dim VecX As Single = OP.X - BeforPoint.X
        Dim VecY As Single = OP.Y - BeforPoint.Y


        'sita:矢印の角度の半分
        sita = DArrow.Angle / 2

        '線の幅を求める
        Dim LineW As Single = 0
        Select Case LPat.BasicLine.pattern
            Case enmLinePattern.Solid
                LineW = LPat.BasicLine.SolidLine.Width
                Fillcol = LPat.BasicLine.SolidLine.Color
            Case enmLinePattern.BROKEN
                For i As Integer = 0 To 5
                    With LPat.BasicLine.Get_CenterLineParts(i)
                        If .Use_F = True And .Print_f = True Then
                            LineW = Math.Max(LineW, .Width)
                            Fillcol = .Color
                        End If
                    End With
                Next
            Case enmLinePattern.InVisible
        End Select
        If LPat.CrossLine.XLine_f = True Then
            For i As Integer = 0 To 5
                With LPat.CrossLine.Get_CrossLineParts(i)
                    If .Use_F = True Then
                        LineW = Math.Max(LineW, .Length)
                        If LPat.BasicLine.pattern = enmLinePattern.InVisible Then
                            Fillcol = .Color
                        End If
                    End If
                End With
            Next
        End If
        With LPat.ParallelLine
            If .P_Line_f = True Then
                LineW = Math.Max(LineW, .Interval + LineW / 2)
            End If
        End With

        'a:矢印の底辺の長さの半分
        Dim a As Single = ScrData.STDWsize * ((LineW * DArrow.LWidthRatio + DArrow.WidthPlus) / 2) / 100 * ScrData.GSMul
        If Check_F = True Then
            a = a * 0.95
        End If
        'c:矢印の頂点から底辺へ垂線の長さ
        Dim c As Single = a / Math.Sin(sita * Math.PI / 180)
        'b:矢印の三角形の長辺の長さ
        Dim b As Single = c * Math.Cos(sita * Math.PI / 180)

        tva = Math.Sqrt(1 / (VecX ^ 2 + VecY ^ 2))
        e2.X = VecX * tva * b
        e2.Y = VecY * tva * b

        Dim V_VecX As Single, V_VecY As Single
        spatial.Get_Suisen_Vec(VecX, VecY, V_VecX, V_VecY)
        Dim newP As PointF = spatial.Get_Vec_Point(V_VecX, V_VecY, a, False)

        ac.X = OP.X - e2.X
        ac.Y = OP.Y - e2.Y

        a1.X = ac.X + newP.X
        a1.Y = ac.Y + newP.Y

        a2.X = ac.X - newP.X
        a2.Y = ac.Y - newP.Y


    End Sub

    Public Shared Function Check_Draw_Arrow_Line(ByRef CP As PointF, ByVal OP As PointF, ByVal BeforPoint As PointF,
                           ByVal LineP1 As PointF, ByVal LineP2 As PointF,
                           ByRef LPat As Line_Property, ByRef DArrow As Arrow_Data, ByRef ScrData As Screen_info) As Boolean

        Dim e2 As PointF
        Dim e3 As PointF
        Dim e4 As PointF
        Dim Fillcol As colorARGB
        Draw_Arrow_Keisan(e3, e2, e4, Fillcol, OP, BeforPoint, LPat, DArrow, True, ScrData)

        Return spatial.Line_Cross_Point(CP, e3, e4, LineP1, LineP2)

    End Function
    ''' <summary>
    ''' ライン描画（2地点）
    ''' </summary>
    ''' <param name="g">描画先グラフィックス</param>
    ''' <param name="LinePattern">ラインパターン</param>
    ''' <param name="P1">地点1</param>
    ''' <param name="P2">地点2</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub Line(ByRef g As Graphics, ByRef LinePattern As Line_Property,
                                     ByVal P1 As Point, ByVal P2 As Point,
                                     ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)

        Line(g, LinePattern, 2, {P1, P2}, ScrData, basePic)
    End Sub
    ''' <summary>
    ''' ライン描画（配列）
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="LineP">ラインパターン</param>
    ''' <param name="Points">Point配列</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub Line(ByRef g As Graphics, ByRef LineP As Line_Property, ByVal nPoints As Integer,
                                     ByRef pxy() As Point, ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)
        Dim ParaXY1() As Point
        Dim ParaXY2() As Point
        Dim Para_PolyXY() As Point
        Dim Para1_Points As Integer, Para2_Points As Integer

        Dim Pst As Integer
        If nPoints = 0 Then
            Return
        End If

        If LineP.ParallelLine.P_Line_f = True Then
            '平行線の場合は平行線の座標を取得
            Dim w As Integer = ScrData.Get_Length_On_Screen(LineP.ParallelLine.Interval)
            Call Get_Parallel_Line(ParaXY1, ParaXY2, Para1_Points, Para2_Points, pxy, nPoints, w / 2)
            If LineP.ParallelLine.InnerColor_f = True Then
                '平行線の内部塗りつぶし
                Dim pon As Integer
                Dim nPolyP() As Integer
                If pxy(0).Equals(pxy(nPoints - 1)) = True Then
                    pon = 2
                    ReDim nPolyP(1)
                    nPolyP(0) = Para1_Points
                    nPolyP(1) = Para2_Points
                Else
                    pon = 1
                    ReDim nPolyP(0)
                    nPolyP(0) = Para1_Points + Para2_Points
                End If
                ReDim Para_PolyXY(Para1_Points + Para2_Points - 1)
                For i As Integer = 0 To Para1_Points - 1
                    Para_PolyXY(i) = ParaXY1(i)
                Next
                For i As Integer = 0 To Para2_Points - 1
                    Para_PolyXY(i + Para1_Points) = ParaXY2(Para2_Points - 1 - i)
                Next
                'ループの場合でもうまく処理される
                Dim ParallelRegion As Region = clsDraw.Get_Region_From_PointStac(pon, Para_PolyXY, nPolyP)
                g.FillRegion(New SolidBrush(LineP.ParallelLine.InnerColor.getColor()), ParallelRegion)
                'g.FillPolygon(New SolidBrush(LineP.ParallelLine.InnerColor.getColor()), Para_PolyXY)
            End If
            With LineP.ParallelLine
                If .Center_Line_f = True Then
                    '平行線の中心線
                    If .CenterLine_ParaLine_f = True Then
                        '平行線と同じ線種
                        Select Case LineP.BasicLine.pattern
                            Case enmLinePattern.InVisible
                            Case enmLinePattern.Solid
                                Draw_SolidPolyLine(g, pxy, LineP.BasicLine, LineP.Edge_Connect_Pattern, ScrData)
                            Case enmLinePattern.BROKEN
                                Draw_BrokenLine(g, pxy, LineP.BasicLine, LineP.Edge_Connect_Pattern, ScrData)
                        End Select
                    Else
                        '独自線種
                        Select Case LineP.ParallelLine.P_CenterLine.pattern
                            Case enmLinePattern.Solid
                                Draw_SolidPolyLine(g, pxy, LineP.ParallelLine.P_CenterLine, LineP.Edge_Connect_Pattern, ScrData)
                            Case enmLinePattern.BROKEN
                                Call Draw_BrokenLine(g, pxy, LineP.ParallelLine.P_CenterLine, LineP.Edge_Connect_Pattern, ScrData)
                        End Select

                    End If
                End If
            End With
        End If

        Select Case LineP.BasicLine.pattern
            Case enmLinePattern.InVisible
            Case enmLinePattern.Solid
                If LineP.ParallelLine.P_Line_f = False Then
                    Call Draw_SolidPolyLine(g, pxy, LineP.BasicLine, LineP.Edge_Connect_Pattern, ScrData)
                Else
                    Call Draw_SolidPolyLine(g, ParaXY1, LineP.BasicLine, LineP.Edge_Connect_Pattern, ScrData)
                    Call Draw_SolidPolyLine(g, ParaXY2, LineP.BasicLine, LineP.Edge_Connect_Pattern, ScrData)
                End If
            Case enmLinePattern.BROKEN
                If LineP.ParallelLine.P_Line_f = False Then
                    Call Draw_BrokenLine(g, pxy, LineP.BasicLine, LineP.Edge_Connect_Pattern, ScrData)
                Else
                    Call Draw_BrokenLine(g, ParaXY1, LineP.BasicLine, LineP.Edge_Connect_Pattern, ScrData)
                    Call Draw_BrokenLine(g, ParaXY2, LineP.BasicLine, LineP.Edge_Connect_Pattern, ScrData)
                End If
        End Select


        '交差線
        If LineP.CrossLine.XLine_f = True Then
            Dim CreatedPenHDC(5) As Pen

            With Var_OptionalLine
                .LineStac = New List(Of Integer)
                .LineStac.Clear()
                For i As Integer = 0 To 5
                    If LineP.CrossLine.Get_CrossLineParts(i).Use_F = True Then
                        Dim w As Integer = ScrData.Get_Line_Width(LineP.CrossLine.Get_CrossLineParts(i).Width)
                        Dim col As Color = LineP.CrossLine.Get_CrossLineParts(i).Color.getColor
                        CreatedPenHDC(i) = New Pen(col, w)
                        LineP.Edge_Connect_Pattern.set_Pen_JoinCap(CreatedPenHDC(i))
                        .LineStac.Add(i)
                    End If
                Next

                If .LineStac.Count > 0 Then
                    .L_First_F = True
                    For i As Integer = 0 To nPoints - 2
                        Opt_X_Line(g, pxy(i), pxy(i + 1), LineP, CreatedPenHDC, ScrData, basePic)
                    Next
                End If
                For i As Integer = 0 To 5
                    If LineP.CrossLine.Get_CrossLineParts(i).Use_F = True Then
                        CreatedPenHDC(i).Dispose()
                    End If
                Next
            End With
        End If

    End Sub

    Private Shared Sub Opt_X_Line(ByRef g As Graphics, ByVal P1 As Point, ByVal P2 As Point,
                                  ByRef LPat As Line_Property, ByRef CreatedPenHDC() As Pen,
                                  ByRef ScrData As Screen_info, ByRef basePic As BasePicture_Info)
        '任意の間隔のクロス線を引く

        Dim MK As Mark_Property

        If P1.Equals(P2) = True Then
            Exit Sub
        End If

        If Var_OptionalLine.L_First_F = True Then
            With Var_OptionalLine
                .L_First_F = False
                .LineRepN = 0
                .Accum_Distance = 0
            End With
        End If

        Dim Vx As Integer = P2.X - P1.X
        Dim Vy As Integer = P2.Y - P1.Y
        Dim DP(10) As Point, kazari(10) As Integer


        Dim VDis As Single = Math.Sqrt(Vx ^ 2 + Vy ^ 2)
        Dim n As Integer = 0
        Dim Max_Dis As Single = spatial.get_Distance(P1, P2)

        With Var_OptionalLine
            Dim D As Single = -.Accum_Distance
            Dim XInterval(.LineStac.Count - 1) As Single

            Dim ad As Single = 0
            For i As Integer = 0 To .LineStac.Count - 1
                XInterval(i) = ScrData.Get_Length_On_Screen(LPat.CrossLine.Get_CrossLineParts(.LineStac(i)).Interval)
                ad += XInterval(i)
            Next
            If ad = 0 Then
                Exit Sub
            End If

            Do While D < Max_Dis
                If LPat.CrossLine.Get_CrossLineParts(.LineStac(.LineRepN)).Length <> 0 Then
                    D += XInterval(.LineRepN)
                    Dim fx As Single, fy As Single
                    If Vx = 0 Then
                        fx = 0
                        fy = D * Vy / VDis
                    Else
                        fx = D * Vx / VDis
                        fy = fx * Vy / Vx
                    End If
                    DP(n).X = fx + P1.X
                    DP(n).Y = fy + P1.Y
                    kazari(n) = .LineStac(.LineRepN)
                    n += 1
                End If
                .LineRepN += 1
                If .LineRepN = .LineStac.Count Then
                    .LineRepN = 0
                End If
                If UBound(DP) < n Then
                    ReDim Preserve DP(n + 10), kazari(n + 10)
                End If
            Loop
            If D = Max_Dis Then
                .Accum_Distance = 0
            Else
                n -= 1
                .LineRepN -= 1
                If .LineRepN < 0 Then
                    .LineRepN = .LineStac.Count - 1
                End If
                If n = 0 Then
                    .Accum_Distance += spatial.get_Distance(P1, P2)
                Else
                    .Accum_Distance = spatial.get_Distance(DP(n - 1).X, DP(n - 1).Y, P2.X, P2.Y)
                End If
            End If
        End With

        For i As Integer = 0 To n - 1
            With LPat.CrossLine.Get_CrossLineParts(kazari(i))
                Dim L As Integer = ScrData.Get_Length_On_Screen(.Length)
                Select Case .pattern
                    Case enmLineCrossPattern.Line
                        Dim rVx As Integer, rVy As Integer
                        spatial.Get_Suisen_Vec(Vx, Vy, rVx, rVy)
                        Draw_LimitedLine(g, DP(i), rVx, rVy, L, CreatedPenHDC(kazari(i)))
                    Case enmLineCrossPattern.Circle
                        Dim cp As Point = DP(i)
                        cp.Offset(-L \ 2, -L \ 2)
                        Dim rect As Rectangle = New Rectangle(cp, New Size(L, L))
                        g.FillEllipse(New SolidBrush(.Color.getColor), rect)
                    Case enmLineCrossPattern.Rectangle
                        Dim cp As Point = DP(i)
                        cp.Offset(-L \ 2, -L \ 2)
                        Dim rect As Rectangle = New Rectangle(cp, New Size(L, L))
                        g.FillRectangle(New SolidBrush(.Color.getColor), rect)
                    Case enmLineCrossPattern.Mark
                        clsDrawMarkFan.TileMark_Print(g, DP(i), L / 2, .TileMark, .Color, ScrData, basePic)
                End Select
            End With
        Next
    End Sub

    Private Shared Sub Draw_SolidPolyLine(ByRef g As Graphics, ByRef pxy() As Point, ByRef LPat As Line_Basic_Data_Info,
                                   ByRef Edge_Connect_Pattern As LineEdge_Connect_Pattern_Data_Info,
                                   ByRef ScrData As Screen_info)
        If pxy.Length = 1 Then
            Return
        End If
        Dim nWidth As Integer = ScrData.Get_Line_Width(LPat.SolidLine.Width)
        Dim Pen As New Pen(LPat.SolidLine.Color.getColor, nWidth)
        Edge_Connect_Pattern.set_Pen_JoinCap(Pen)
        g.DrawLines(Pen, pxy)
        Pen.Dispose()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Out1_Pxy">左右の平行線の座標(戻り値)</param>
    ''' <param name="Out2_Pxy">左右の平行線の座標(戻り値)</param>
    ''' <param name="Out1_n">左右の平行線のポイント数(戻り値)</param>
    ''' <param name="Out2_n">左右の平行線のポイント数(戻り値)</param>
    ''' <param name="pxy">pxy()/元の中央線</param>
    ''' <param name="nPoints">元のポイント数</param>
    ''' <param name="Line_Interval">平行線の間隔</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Get_Parallel_Line(ByRef Out1_Pxy() As Point, ByRef Out2_Pxy() As Point,
                                              ByRef Out1_n As Integer, ByRef Out2_n As Integer,
                                              ByRef pxy() As Point, ByVal nPoints As Integer, ByVal Line_Interval As Single) As Boolean


        If nPoints < 2 Then
            Return False
            Exit Function
        End If

        Dim LP As Integer = (nPoints - 1) * 2 - 1
        Dim pxy1(LP) As Point
        Dim pxy2(LP) As Point
        Dim pxy12(LP + 1) As Point
        Dim pxy22(LP + 1) As Point
        Dim pxy13(LP + 1) As Point
        Dim pxy23(LP + 1) As Point

        Dim crossP As Point


        For i As Integer = 0 To nPoints - 2
            Get_Parallel_SoloLine(pxy1(i * 2), pxy1(i * 2 + 1), pxy2(i * 2), pxy2(i * 2 + 1),
                pxy(i), pxy(i + 1), Line_Interval)
        Next

        '平行線の隙間を埋める，重なりをカットする
        pxy12(0) = pxy1(0)
        pxy22(0) = pxy2(0)
        Dim n1 As Integer = 1
        Dim n2 As Integer = 1
        For i As Integer = 0 To nPoints - 3
            If spatial.Line_Cross_Point(crossP, pxy1(i * 2), pxy1(i * 2 + 1), pxy1(i * 2 + 2), pxy1(i * 2 + 3)) = True Then
                pxy12(n1) = crossP
                n1 += 1
            Else
                pxy12(n1) = pxy1(i * 2 + 1)
                pxy12(n1 + 1) = pxy1(i * 2 + 2)
                n1 += 2
            End If
            If spatial.Line_Cross_Point(crossP, pxy2(i * 2), pxy2(i * 2 + 1), pxy2(i * 2 + 2), pxy2(i * 2 + 3)) = True Then
                pxy22(n2) = crossP
                n2 += 1
            Else
                pxy22(n2) = pxy2(i * 2 + 1)
                pxy22(n2 + 1) = pxy2(i * 2 + 2)
                n2 += 2
            End If
        Next
        pxy12(N1) = pxy1(LP)
        pxy22(n2) = pxy2(LP)
        n1 += 1
        n2 += 1


        'クロスして複雑化したカ所の処理
        Dim n13 As Integer = 0
        For i As Integer = 0 To n1 - 1
            pxy13(n13) = pxy12(i)
            n13 += 1
            For j As Integer = i + 2 To i + 6
                If j >= n1 - 2 Then
                    Exit For
                End If
                If spatial.Line_Cross_Point(crossP, pxy12(i), pxy12(i + 1), pxy12(j), pxy12(j + 1)) = True Then
                    pxy13(n13) = crossP
                    pxy13(n13 + 1) = pxy12(j + 1)
                    n13 += 2
                    i = j + 1
                    Exit For
                End If
            Next
        Next
        Dim n23 As Integer = 0
        For i As Integer = 0 To n2 - 1
            pxy23(n23) = pxy22(i)
            n23 += 1
            For j As Integer = i + 2 To i + 6
                If j >= n2 - 2 Then
                    Exit For
                End If
                If spatial.Line_Cross_Point(crossP, pxy22(i), pxy22(i + 1), pxy22(j), pxy22(j + 1)) = True Then
                    pxy23(n23) = crossP
                    pxy23(n23 + 1) = pxy22(j + 1)
                    n23 += 2
                    i = j + 1
                    Exit For
                End If
            Next
        Next

        If pxy(0).Equals(pxy(nPoints - 1)) = True Then
            'ループの場合
            If spatial.Line_Cross_Point(crossP, pxy13(0), pxy13(1), pxy13(n13 - 2), pxy13(n13 - 1)) = True Then
                pxy13(0) = crossP
                pxy13(n13 - 1) = pxy13(0)
            Else
                pxy13(n13) = pxy13(0)
                n13 += 1
            End If
            If spatial.Line_Cross_Point(crossP, pxy23(0), pxy23(1), pxy23(n23 - 2), pxy23(n23 - 1)) = True Then
                pxy23(0)= crossP
                pxy23(n23 - 1) = pxy23(0)
            Else
                pxy23(n23) = pxy22(0)
                n23 += 1
            End If

        End If

        Out1_Pxy = pxy13.Clone
        Out2_Pxy = pxy23.Clone
        ReDim Preserve Out1_Pxy(n13 - 1)
        ReDim Preserve Out2_Pxy(n23 - 1)

        Out1_n = n13
        Out2_n = n23
        Return True
    End Function

    Private Shared Sub Get_Parallel_SoloLine(ByRef oxy1 As Point, ByRef dxy1 As Point, _
            ByRef oxy2 As Point, ByRef dxy2 As Point, _
            ByVal oxy0 As Point, ByVal dxy0 As Point, ByVal Length As Single)
        '平行線を取得
        'ox0,oy0,dx0,dy0:元の線分
        'Length/平行移動の距離
        '出力／ox12,oy12,dx12,dy12/平行線の座標
        Dim V_VecX As Single, V_VecY As Single
        Dim x2 As Single, y2 As Single
        Dim VecX As Integer, VecY As Integer

        VecX = dxy0.X - oxy0.X
        VecY = dxy0.Y - oxy0.Y
        '垂直ベクトルを求める
        spatial.Get_Suisen_Vec(VecX, VecY, V_VecX, V_VecY)
        Dim Vp As PointF = spatial.Get_Vec_Point(V_VecX, V_VecY, Length, False)
        oxy1 = oxy0
        oxy2 = oxy0
        oxy1.Offset(-Vp.X, -Vp.Y)
        oxy2.Offset(Vp.X, Vp.Y)

        dxy1 = dxy0
        dxy2 = dxy0
        dxy1.Offset(-Vp.X, -Vp.Y)
        dxy2.Offset(Vp.X, Vp.Y)

    End Sub

    Private Shared Sub Draw_BrokenLine(ByRef g As Graphics, ByRef pxy() As Point,
                                       ByRef BrokenLinePat As Line_Basic_Data_Info,
                                       ByRef Edge_Connect_Pattern As LineEdge_Connect_Pattern_Data_Info,
                                       ByRef ScrData As Screen_info)


        Dim CreatedPenHDC(5) As Pen
        With Var_OptionalLine
            '破線の線種を作成
            .LineStac = New List(Of Integer)
            .LineStac.Clear()
            For i As Integer = 0 To 5
                If BrokenLinePat.Get_CenterLineParts(i).Use_F = True Then
                    .LineStac.Add(i)
                    If BrokenLinePat.Get_CenterLineParts(i).Print_f = True Then
                        Dim w As Integer = ScrData.Get_Line_Width(BrokenLinePat.Get_CenterLineParts(i).Width)
                        Dim col As Color = BrokenLinePat.Get_CenterLineParts(i).Color.getColor
                        CreatedPenHDC(i) = New Pen(col, w)
                        Edge_Connect_Pattern.set_Pen_JoinCap(CreatedPenHDC(i))
                    End If
                End If
            Next

            If .LineStac.Count > 0 Then
                .L_First_F = True
                For i As Integer = 0 To pxy.Count - 2
                    OptLine(pxy(i), pxy(i + 1), BrokenLinePat, ScrData)
                Next
                With Var_OptionalLine
                    For i As Integer = 0 To .B_Line_middle_num
                        With B_Line_middle(i)
                            If BrokenLinePat.Get_CenterLineParts(.kazari_stac).Print_f = True Then
                                If .Pointnum = 2 Then
                                    g.DrawLine(CreatedPenHDC(.kazari_stac), B_LineXY(.XYstac), B_LineXY(.XYstac + 1))
                                ElseIf .Pointnum >= 3 Then
                                    Dim pxy2(.Pointnum - 1) As Point
                                    For j As Integer = 0 To .Pointnum - 1
                                        pxy2(j).X = B_LineXY(.XYstac + j).X
                                        pxy2(j).Y = B_LineXY(.XYstac + j).Y
                                    Next
                                    g.DrawLines(CreatedPenHDC(.kazari_stac), pxy2)
                                End If
                            End If
                        End With
                    Next
                End With
            End If
        End With

        '破線の線種を削除
        For i As Integer = 0 To 5
            If BrokenLinePat.Get_CenterLineParts(i).Use_F = True And BrokenLinePat.Get_CenterLineParts(i).Print_f = True Then
                CreatedPenHDC(i).Dispose()
            End If
        Next

    End Sub

    Private Shared Sub OptLine(ByVal P1 As Point, ByVal P2 As Point, ByRef BrokenLinePat As Line_Basic_Data_Info,
                               ByRef ScrData As Screen_info)
        '任意の間隔の線を引く


        With Var_OptionalLine
            If Var_OptionalLine.L_First_F = True Then
                .L_First_F = False
                .LineRepN = 0
                .Accum_Distance = 0
                B_LineXY = New List(Of PointF)
                .B_Line_middle_num = 0
                B_LineXY.Add(P1)
                ReDim B_Line_middle(50)
                B_Line_middle(0).XYstac = 0
                B_Line_middle(0).Pointnum = 1
            End If
            If P1.Equals(P2) = True Then
                Return
            End If

            Dim Vx As Integer = P2.X - P1.X
            Dim Vy As Integer = P2.Y - P1.Y

            Dim VDis As Single = Math.Sqrt(Vx ^ 2 + Vy ^ 2)
            Dim n As Integer = 0
            Dim Max_Dis As Single = spatial.get_Distance(P1, P2)

            Dim D As Single
            If .Accum_Distance <> 0 Then
                D = .Accum_Distance - ScrData.Get_Length_On_Screen(BrokenLinePat.Get_CenterLineParts(.LineStac(.LineRepN)).Length)
            Else
                D = 0
            End If
            '    d = -.Accum_Distance

            Dim XInterval(.LineStac.Count - 1) As Single
            Dim ad As Single = 0
            For i As Integer = 0 To .LineStac.Count - 1
                XInterval(i) = ScrData.Get_Length_On_Screen(BrokenLinePat.Get_CenterLineParts(i).Length)
                ad += XInterval(i)
            Next
            If ad = 0 Then
                Exit Sub
            End If

            Do While D < Max_Dis
                D += XInterval(.LineRepN)
                Dim fx As Single, fy As Single
                If Vx = 0 Then
                    fx = 0
                    fy = D * Vy / VDis
                Else
                    fx = D * Vx / VDis
                    fy = fx * Vy / Vx
                End If
                B_LineXY.Add(New PointF(fx + P1.X, fy + P1.Y))
                B_Line_middle(.B_Line_middle_num).kazari_stac = .LineStac(.LineRepN)
                B_Line_middle(.B_Line_middle_num).Pointnum += 1
                .B_Line_middle_num += 1

                .LineRepN += 1
                If .LineRepN = .LineStac.Count Then
                    .LineRepN = 0
                End If
                If UBound(B_Line_middle) < .B_Line_middle_num Then
                    ReDim Preserve B_Line_middle(.B_Line_middle_num * 2)
                End If
                B_Line_middle(.B_Line_middle_num).XYstac = B_LineXY.Count - 1
                B_Line_middle(.B_Line_middle_num).Pointnum = 1

                n += 1
            Loop
            If D = Max_Dis Then
                .Accum_Distance = 0
            Else
                If n = 0 Then
                    .Accum_Distance += spatial.get_Distance(P1, P2)
                Else
                    .LineRepN -= 1
                    If .LineRepN < 0 Then
                        .LineRepN = .LineStac.Count - 1
                    End If
                    .B_Line_middle_num -= 1
                    .Accum_Distance = spatial.get_Distance(B_LineXY(B_LineXY.Count - 1), P2)
                End If
                B_LineXY.Item(B_LineXY.Count - 1) = P2
            End If

        End With

    End Sub
    Private Shared Sub Draw_LimitedLine(ByRef g As Graphics, ByVal P As Point, ByVal VecX As Single, ByVal VecY As Single,
                                 ByVal Dis As Single, ByRef Pen As Pen)
        '指定したポイントから，ベクトルVecX,VecY方向に長さDの線を描く

        Dim vecP As PointF = spatial.Get_Vec_Point(VecX, VecY, Dis, True)
        Dim L1 As Point = P
        Dim L2 As Point = P
        L1.Offset(-vecP.X, -vecP.Y)
        L2.Offset(vecP.X, vecP.Y)
        g.DrawLine(Pen, L1, L2)
    End Sub

    ''' <summary>
    ''' サンプル線種ボックスに指定の線種を描画
    ''' </summary>
    ''' <param name="ob">ピクチャボックス</param>
    ''' <param name="L">ラインパターン</param>
    ''' <param name="ScrData">画面情報</param>
    ''' <remarks></remarks>
    Public Shared Sub Draw_Sample_LineBox(ByRef ob As PictureBox, ByVal L As Line_Property, ByVal ScrData As Screen_info, ByRef basePic As BasePicture_Info)

        With ob
            Dim w As Integer = .Width
            Dim H As Integer = .Height
            If ob.BorderStyle = BorderStyle.Fixed3D Then
                w -= 4
                H -= 4
            End If
            Dim canvas As New Bitmap(w, H)
            'ImageオブジェクトのGraphicsオブジェクトを作成する
            Dim g As Graphics = Graphics.FromImage(canvas)
            ScrData.SampleBoxFlag = True
            If L.Check_Line_PrintPattern = False Then
                Dim Font As New Font("MS UI Gothic", 10, GraphicsUnit.Pixel)
                clsDraw.print(g, "透明", New Point(w \ 2, H \ 2), Font, New SolidBrush(Color.Black), StringAlignment.Center, StringAlignment.Center)
            Else
                Dim P1 As Point = New Point(w * 0.1, H \ 2)
                Dim P2 As Point = New Point(w * 0.9, H \ 2)
                clsDrawLine.Line(g, L, P1, P2, ScrData, basePic)
            End If
            g.Dispose()
            ob.Image = canvas
            ob.Refresh()
        End With
    End Sub

End Class

Public Class clsSpline
    Public Shared Function Spline_Get(ByVal Ls As Integer, ByRef ln As Integer, ByRef Line_XY() As PointF,
                                 ByVal stp As Single, ByRef ScrData As Screen_info) As Point()


        If ln = 2 Then
            Dim p(1) As Point
            p(0) = ScrData.Get_SxSy_With_3D(Line_XY(0))
            p(1) = ScrData.Get_SxSy_With_3D(Line_XY(1))
            Return p
        End If

        Dim lpf As Boolean = False
        If Line_XY(Ls).X = Line_XY(Ls + ln - 1).X And Line_XY(Ls).Y = Line_XY(Ls + ln - 1).Y Then
            lpf = True
        End If
        Dim clf As Boolean
        Dim SPP() As PointF
        If lpf = True Then
            ReDim SPP(ln - 1 + 4)
            For k As Integer = 0 To ln - 1
                SPP(k) = Line_XY(Ls + k)
            Next
            For k As Integer = 0 To 2
                SPP(ln + k) = SPP(1 + k)
            Next
            ln += 3
            clf = True
        Else
            ReDim SPP(ln)
            For k As Integer = 0 To ln - 1
                SPP(k) = Line_XY(Ls + k)
            Next
            clf = False
        End If
        Dim Maxpt As Integer = ln
        Dim Kvalue As Integer = 3
        Dim mxt As Integer = Maxpt - 1 - Kvalue + 2
        Dim ln2 As Integer = Int(mxt / stp) + 2

        Dim pxy(ln2) As Point
        Dim fa As Integer
        Dim fa2 As Integer
        Dim n As Integer = 0
        If clf = True Then
            fa = 1 : fa2 = mxt - 1
        Else
            fa = 0 : fa2 = mxt
        End If
        For spa As Single = fa To fa2 + 0.0001 Step stp
            If spa < fa2 Then
                Dim p As PointF = Spline_xy(spa, Kvalue, Maxpt, SPP)
                pxy(n) = ScrData.Get_SxSy_With_3D(p)
                n += 1
            End If
        Next
        If lpf = True Then
            If pxy(n - 1).Equals(pxy(0)) = False Then
                pxy(n - 1) = pxy(0)
            End If
        Else
            pxy(n) = ScrData.Get_SxSy_With_3D(Line_XY(Ls + ln - 1))
            n += 1
        End If
        ReDim Preserve pxy(n - 1)
        ln = n
        Return pxy
    End Function
    Public Shared Function Spline_Get_Fill(ByVal Ls As Integer, ByRef ln As Integer, ByRef Line_XY() As PointF,
                                 ByVal stp As Single, ByRef ScrData As Screen_info) As Point()
 

        Dim lpf As Boolean
        If Line_XY(Ls).Equals(Line_XY(Ls + ln - 1)) = True Then
            lpf = True
        End If

        Dim SPP(ln - 1 + 4) As PointF
        For k As Integer = 0 To ln - 1
            SPP(k) = Line_XY(Ls + k)
        Next
        If lpf = False Then
            For k As Integer = 0 To 3
                SPP(ln + k) = SPP(k)
            Next
            ln += 4
        Else
            For k As Integer = 0 To 2
                SPP(ln + k) = SPP(1 + k)
            Next
            ln += 3
        End If
        Dim clf As Boolean = True

        Dim Maxpt As Integer = ln
        Dim Kvalue As Integer = 3
        Dim mxt As Integer = Maxpt - 1 - Kvalue + 2
        Dim ln2 As Integer = Int(mxt / 0.1) + 2

        Dim pxy(ln2) As Point
        Dim n As Integer = 0
        Dim fa As Integer
        Dim fa2 As Integer
        If clf = True Then
            fa = 1 : fa2 = mxt - 1
        Else
            fa = 0 : fa2 = mxt
        End If
        For spa As Single = fa To fa2 + 0.0001 Step stp
            If spa < fa2 Then
                Dim p As PointF = Spline_xy(spa, Kvalue, Maxpt, SPP)
                pxy(n) = ScrData.Get_SxSy_With_3D(p)
                n += 1
            End If
        Next
        If pxy(n - 1).Equals(pxy(0)) = False Then
            pxy(n - 1) = pxy(0)
        End If
        ln = n
        Return pxy
    End Function
    Private Shared Function Spline_xy(ByVal T As Single, ByVal Kvalue As Integer, ByVal Maxpt As Integer,
                                 pt() As PointF) As PointF

        Dim P As PointF

        Dim z As Integer = Maxpt - 1
        Dim Value As Single = 0
        Dim ST As Integer = Int(T) - 2
        Dim ET As Integer = Int(T) + 2
        If ST < 0 Then ST = 0
        If ET > z Then ET = z
        For i As Integer = ST To ET
            Dim Q As Single = Blend(i, Kvalue, T, Kvalue, z)
            Value += pt(i).X * Q
        Next
        P.X = Value

        Value = 0
        For i As Integer = ST To ET
            Value += pt(i).Y * Blend(i, Kvalue, T, Kvalue, z)
        Next
        P.Y = Value

        Return P
    End Function

    Private Shared Function Blend(ByVal i As Integer, ByVal k As Integer, ByVal T As Single,
                    ByVal Kvalue As Integer, ByVal Maxpt As Integer) As Single


        If k = 1 Then
            If Knot(i, Kvalue, Maxpt) <= T And T < Knot(i + 1, Kvalue, Maxpt) Then
                Return 1
            ElseIf T = Maxpt - Kvalue + 2 And Knot(i, Kvalue, Maxpt) <= T And T <= Knot(i + 1, Kvalue, Maxpt) Then
                Return 1
            Else
                Return 0
            End If
        End If

        Dim Number As Single
        Dim value1 As Single
        Dim denom As Single = Knot(i + k - 1, Kvalue, Maxpt) - Knot(i, Kvalue, Maxpt)
        If denom = 0 Then
            value1 = 0
        Else
            Number = (T - Knot(i, Kvalue, Maxpt)) * Blend(i, k - 1, T, Kvalue, Maxpt)
            value1 = Number / denom
        End If

        Dim value2 As Single
        denom = Knot(i + k, Kvalue, Maxpt) - Knot(i + 1, Kvalue, Maxpt)
        If denom = 0 Then
            value2 = 0
        Else
            Number = (Knot(i + k, Kvalue, Maxpt) - T) * Blend(i + 1, k - 1, T, Kvalue, Maxpt)
            value2 = Number / denom
        End If
        Return value1 + value2

    End Function
    Private Shared Function Knot(ByVal i As Integer, ByVal Kvalue As Integer, ByVal Maxpt As Integer) As Integer

        If i < Kvalue Then
            Return 0
        ElseIf i <= Maxpt Then
            Return i - Kvalue + 1
        Else
            Return Maxpt - Kvalue + 2
        End If

    End Function


End Class




