Public Enum enmShape
    NotDeffinition = -1
    PointShape = 0
    LineShape = 1
    PolygonShape = 2
End Enum
Public Enum cstRectangle_Cross '長方形間の関係を示す定数
    cstOuter = -1
    cstCross = 0
    cstInner = 1
    cstInclusion = 2
    cstEqual = 3
End Enum
Public Enum cstLinePolygonRelationd 'ラインとポリゴンの関係を示す定数
    cstOuter = -1
    cstCross = 0
    cstInner = 1
End Enum

Public Enum chvValue_on_twoValue '二つの値にチェックする値が挟まれているか調べる
    chvOuter = -1
    chvJust = 0
    chvIN = 1
End Enum
Public Enum SpatialPointType
    SinglePoint = 1
    SPILine = 2
    SPIRect = 3
End Enum
Public Enum enmProjection_Info As Short '投影法
    prjNo = -1
    prjSanson = 0 'サンソン図法
    prjSeikyoEntou = 1 '正距円筒図法
    prjMercator = 2 'メルカトル図法
    prjMiller = 3 'ミラー図法
    prjLambertSeisekiEntou = 4 'ランベルト正積円筒図法
    prjMollweide = 5 'モルワイデ図法
    prjEckert4 = 6 'エッケルト第4図法
End Enum
Public Enum enmZahyo_System_Info
    Zahyo_System_No = -1
    Zahyo_System_tokyo = 0 '日本測地系
    Zahyo_System_World = 1 '世界測地系
End Enum
Public Enum enmZahyo_mode_info
    Zahyo_No_Mode = -1
    Zahyo_Ido_Keido = 0 '緯度経度
    Zahyo_HeimenTyokkaku = 1 '平面直角
End Enum

Public Structure Cross_Line_Data '交点取得用
    Public BeforPoint As Integer
    Public Point As PointF
End Structure





Public Class spatial


    ''' <summary>
    ''' 測地系をチェックして、違っていたら変換して返す
    ''' </summary>
    ''' <param name="P1">もともとの緯度経度</param>
    ''' <param name="OriginRefSystem">もともとの測地系</param>
    ''' <param name="DestRefSystem">変換する測地系</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertRefSystemLatLon(ByVal P1 As strLatLon, ByVal OriginRefSystem As enmZahyo_System_Info, ByVal DestRefSystem As enmZahyo_System_Info) As strLatLon
        If OriginRefSystem = DestRefSystem Then
            Return P1
        Else
            '測地系が違う場合は、データ中の緯度経度を地図の測地系に合わせて変換して代表点に
            Dim P2 As strLatLon
            Select Case OriginRefSystem
                Case enmZahyo_System_Info.Zahyo_System_tokyo
                    Call Tokyo97toITRF94(P1.Latitude, P1.Longitude, P2.Latitude, P2.Longitude)
                Case enmZahyo_System_Info.Zahyo_System_World
                    Call ITRF94toTokyo97(P1.Latitude, P1.Longitude, P2.Latitude, P2.Longitude)
            End Select
            Return P2
        End If
    End Function

    ''' <summary>
    ''' 面積を指定して、指定した縦横比の長方形のサイズを求める
    ''' </summary>
    ''' <param name="xs"></param>
    ''' <param name="Ys"></param>
    ''' <param name="Menseki"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_RectSize_by_Menseki(ByVal Size As Size, ByVal Menseki As Integer) As Size
        '縦横の比率を変えずに、指定した面積の長方形にする
        Dim a As Single = Menseki / (Size.Width * Size.Height)
        Dim rsize As Size = New Size(Math.Sqrt(a) * Size.Width, Math.Sqrt(a) * Size.Height)

        Return rsize
    End Function
    ''' <summary>
    ''' 最寄りのライン上の点または線分の位置を求める
    ''' </summary>
    ''' <param name="CheckPosition">調べる座標</param>
    ''' <param name="Points">ラインの座標</param>
    ''' <param name="minD">最寄り判断の最小距離</param>
    ''' <param name="minDragD">最小距離より遠く、ドラッグ可能ゾーン距離</param>
    ''' <param name="nearestLinePoint">最寄り地点スタック位置（戻り値）</param>
    ''' <param name="InsertLinePoint">最寄りの線分の開始点スタック位置（戻り値）</param>
    ''' <param name="NearLineSegmentPoint">最寄りの線分の最近隣ポイント座標（戻り値）</param>
    ''' <param name="DragZoneFlag">ドラッグ可能ゾーンの場合true（戻り値）</param>
    ''' <remarks></remarks>
    Public Shared Sub NearLinePointOrLineSegment(ByVal CheckPosition As Point, ByRef Points() As Point,
                                                 ByVal minD As Integer, ByVal minDragD As Integer,
                                                 ByRef nearestLinePoint As Integer, ByRef InsertLinePoint As Integer,
                                       ByRef NearLineSegmentPoint As Point, ByRef DragZoneFlag As Boolean)


        InsertLinePoint = -1
        '最寄りの点を検索
        Dim mind2 As Single = minD
        nearestLinePoint = spatial.get_PointDistance(CheckPosition, Points, Points.Length, mind2)

        If nearestLinePoint = -1 Then
            '最寄りの点がない場合は線分を検索する
            For i As Integer = 0 To Points.Length - 2
                Dim NP As PointF
                Dim d As Integer = spatial.Distance_PointLine(CheckPosition, Points(i), Points(i + 1), NP)
                If d <= mind2 Then
                    mind2 = d
                    InsertLinePoint = i
                    NearLineSegmentPoint = New Point(NP.X, NP.Y)
                End If
                If d < minDragD Then
                    DragZoneFlag = True
                End If
            Next
        End If
        If nearestLinePoint <> -1 Or InsertLinePoint <> -1 Then
            DragZoneFlag = False
        End If
    End Sub
    ''' <summary>
    ''' PointFを指定量移動
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="xPlus"></param>
    ''' <param name="yPlus"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub PointF_offset(ByRef P As PointF, ByVal xPlus As Single, ByVal yPlus As Single)
        P.X += xPlus
        P.Y += yPlus

    End Sub
    Public Overloads Shared Sub PointF_offset(ByRef P As PointF, ByVal xyPlus As PointF)
        PointF_offset(P, xyPlus.X, xyPlus.Y)

    End Sub
    ''' <summary>
    '''起終点座標だけを指定した境界線を面領域を描くように並べ替える、返す値は並び順とオブジェクトのポリゴン数
    ''' </summary>
    ''' <param name="LieneNum"></param>
    ''' <param name="spxy">ラインの起点座標配列</param>
    ''' <param name="epxy">ラインの終点座標配列</param>
    ''' <param name="Arrange_LineCode">ポリゴンごとのFringe()のスタック位置とライン数（戻り値）</param>
    ''' <param name="Fringe">境界線の番号、負の場合は逆回り（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BoundaryArrangeGeneral(ByVal LieneNum As Integer, ByVal spxy() As PointF, ByVal epxy() As PointF,
                                           ByRef Arrange_LineCode(,) As Integer, ByRef Fringe() As clsMapData.Fringe_Line_Info) As Integer

        Dim PointIndex As New clsSpatialIndexSearch

        If LieneNum = 0 Then
            Return 0
        End If

        ReDim Arrange_LineCode(LieneNum, 1)
        ReDim Fringe(LieneNum - 1)


        If LieneNum = 1 Then
            Fringe(0).code = 0
            Fringe(0).Direction = 1
            Arrange_LineCode(0, 0) = 0
            Arrange_LineCode(0, 1) = 1
            Return 1
        End If

        PointIndex.Init(SpatialPointType.SinglePoint, False)

        Dim fnl As Integer = 0
        Dim Pon As Integer = 0
        Dim Eline2_n As Integer = 0
        Dim Eline2(LieneNum - 1) As Integer
        'ループをチェック
        For i As Integer = 0 To LieneNum - 1
            If spxy(i).Equals(epxy(i)) = True Then
                Fringe(fnl).code = i
                Fringe(fnl).Direction = 1
                Arrange_LineCode(Pon, 0) = fnl
                Arrange_LineCode(Pon, 1) = 1
                Pon += 1
                fnl += 1
            Else
                PointIndex.AddDoublePoint(spxy(i), epxy(i), i)
                Eline2(Eline2_n) = i
                Eline2_n += +1
            End If
        Next
        PointIndex.AddEnd()

        Dim Contf As Boolean = False
        Dim f As Boolean = True
        Dim Eline2_i As Integer = 0
        Dim stxy As PointF
        Dim exy As PointF

        Do While Eline2_i < Eline2_n
            f = False
            If Contf = False Then
                For i As Integer = 0 To Eline2_n - 1
                    If Eline2(i) <> -1 Then
                        Arrange_LineCode(Pon, 0) = fnl
                        Arrange_LineCode(Pon, 1) = 1
                        Dim LineNO As Integer = Eline2(i)
                        Eline2(i) = -1
                        Fringe(fnl).code = LineNO
                        Fringe(fnl).Direction = 1
                        fnl += 1
                        Eline2_i += 1
                        stxy = spxy(LineNO)
                        exy = epxy(LineNO)
                        PointIndex.RemoveObject_byTag(LineNO)
                        Exit For
                    End If
                Next
            End If
            Contf = False

            Dim LineNO2 As Integer
            Dim PointTag As Integer
            Dim k2 As Integer = PointIndex.GetSamePointNumber(exy.X, exy.Y, PointTag, LineNO2)
            If k2 <> -1 Then
                Contf = True
                Eline2(k2) = -1
                Arrange_LineCode(Pon, 1) += 1
                Fringe(fnl).code = LineNO2
                If PointTag = 0 Then
                    exy = epxy(LineNO2)
                    Fringe(fnl).Direction = 1 '順方向
                Else
                    exy = spxy(LineNO2)
                    Fringe(fnl).Direction = -1 '逆方向
                End If
                PointIndex.RemoveObject_byTag(LineNO2)
                Eline2_i += 1
                fnl += 1
            End If

            If exy.Equals(stxy) = True Then
                Contf = False
                Pon += 1
                f = True
            Else
                If Contf = False Then
                    f = False
                    Exit Do
                End If
            End If
        Loop

        If f = False Then
            Return -1
        Else
            Return Pon
        End If
    End Function
    ''' <summary>
    ''' 指定した高さ、幅のボックスの、回転後の外接四角形の高さ、幅を取得する
    ''' </summary>
    ''' <param name="OW">元の幅</param>
    ''' <param name="oh">元の高さ</param>
    ''' <param name="Angle"></param>
    ''' <param name="TW">回転後の幅</param>
    ''' <param name="TH">回転後の高さ（）</param>
    ''' <remarks></remarks>
    Public Shared Sub Get_TurnedBox(ByVal OW As Integer, ByVal oh As Integer, ByVal Angle As Single, ByRef TW As Integer, ByRef TH As Integer)
        '
        Dim rect = New RectangleF(-OW / 2, -oh / 2, OW, oh)
        Dim trect = Get_Circumscribed_Rectangle(rect, Angle)
        TW = CInt(trect.Width)
        TH = CInt(trect.Height)
        Dim dminx As Single, dmaxx As Single, dminy As Single, dmaxy As Single


    End Sub

    ''' <summary>
    ''' 座標系・測地系が変換可能か調べる
    ''' </summary>
    ''' <param name="OriginMap">もともとの座標系</param>
    ''' <param name="ConvertMap">変換予定の座標系</param>
    ''' <param name="Emes">エラーメッセージ（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_Zahyo_Projection_Convert_Enabled(ByVal OriginMap As clsMapData.Zahyo_info, ByVal ConvertMap As clsMapData.Zahyo_info, ByRef Emes As String) As Boolean
        Emes = ""
        If (OriginMap.Mode = enmZahyo_mode_info.Zahyo_No_Mode And ConvertMap.Mode <> enmZahyo_mode_info.Zahyo_No_Mode) Or _
            (OriginMap.Mode <> enmZahyo_mode_info.Zahyo_No_Mode And ConvertMap.Mode = enmZahyo_mode_info.Zahyo_No_Mode) Then
            Emes = "座標系の設定していないデータと、設定してあるデータを重ねることはできません。"
            Return False
        End If
        If OriginMap.Mode = enmZahyo_mode_info.Zahyo_HeimenTyokkaku And ConvertMap.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
            Emes = "平面直角座標系のデータ上に緯度経度座標系のデータは追加できません。"
            Return False
        End If
        If OriginMap.Mode = enmZahyo_mode_info.Zahyo_HeimenTyokkaku And OriginMap.Mode = enmZahyo_mode_info.Zahyo_HeimenTyokkaku Then
            If ConvertMap.HeimenTyokkaku_KEI_Number <> OriginMap.HeimenTyokkaku_KEI_Number Then
                Emes = "平面直角座標系の系番号が違います。"
                Return False
            End If
            If ConvertMap.System <> OriginMap.System Then
                Emes = "平面直角座標系の測地系が違います。"
                Return False
            End If
        End If
        Return True
    End Function
    ''' <summary>
    ''' 度分秒緯度経度から10進数緯度経度に変換
    ''' </summary>
    ''' <param name="vdo"></param>
    ''' <param name="vfun"></param>
    ''' <param name="vbyou"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_IdoKedo10_from60(ByVal vdo As Integer, ByVal vfun As Integer, ByVal vbyou As Single) As Single
        '
        Return vdo + vfun / 60 + vbyou / 3600
    End Function
    ''' <summary>
    ''' 10進数緯度経度から度分秒緯度経度に変換
    ''' </summary>
    ''' <param name="vdo">度（戻り値）</param>
    ''' <param name="vfun">分（戻り値）</param>
    ''' <param name="vbyou">秒（戻り値）</param>
    ''' <param name="V10">元の値</param>
    ''' <remarks></remarks>
    Public Shared Sub Get_IdoKedo60_from10(ByRef vdo As Integer, ByRef vfun As Integer, ByRef vbyou As Single, ByVal V10 As Single)
        '10進数緯度経度から60進数緯度経度に変換
        Dim s As Single
        vdo = Int(V10)
        s = (CDec(V10) - vdo) * 60
        vfun = Int(s)
        vbyou = (CDec(s) - vfun) * 60
    End Sub

    Public Const EarthR As Single = 6370 '数字を変えると既存地図ファイルの調整が必要
    ''' <summary>
    ''' ポリゴン座標列の面積を求める。配列の最後は、始点、始点+1の座標を入れる
    ''' </summary>
    ''' <param name="n">ポイント数</param>
    ''' <param name="XY">座標列</param>
    ''' <param name="MapDataMap">clsMapData.strMap_data</param>
    ''' <returns>面積</returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Hairetu_Menseki(ByVal n As Integer, ByRef XY() As PointF, ByRef MapDataMap As clsMapData.strMap_data) As Single

        Dim oxy As PointF
        Dim xy2() As PointF = XY.Clone
        Dim Remap As clsMapData.strMap_data
        If MapDataMap.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
            '投影法が正積図法でない場合は座標を正積図法のものに変換
            Select Case MapDataMap.Zahyo.Projection
                Case enmProjection_Info.prjSeikyoEntou, enmProjection_Info.prjMercator, enmProjection_Info.prjMiller
                    Remap = MapDataMap
                    Remap.Zahyo.Projection = enmProjection_Info.prjLambertSeisekiEntou
                    For j As Integer = 0 To n
                        oxy = Get_Reverse_XY(XY(j), MapDataMap.Zahyo)
                        xy2(j) = Get_Converted_XY(oxy, Remap.Zahyo)
                    Next
            End Select
        End If
        Dim men As Single = 0
        For j As Integer = 1 To n - 1
            men += xy2(j).X * (xy2(j + 1).Y - xy2(j - 1).Y)
        Next
        Select Case MapDataMap.Zahyo.Mode
            Case enmZahyo_mode_info.Zahyo_No_Mode
                If MapDataMap.SCL <> 0 Then
                    men = Math.Abs(men / (MapDataMap.SCL * MapDataMap.SCL) / 2)
                Else
                    men = Math.Abs(men / 2)
                End If
            Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                men = Math.Abs(men / (MapDataMap.SCL * MapDataMap.SCL) / 2)
            Case Else
                men = Math.Abs(men / 2)
        End Select
        Return men

    End Function

    ''' <summary>
    ''' 二次元座標回転角度指定
    ''' </summary>
    ''' <param name="P">元座標</param>
    ''' <param name="Kakudo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Trans2D(ByVal P As PointF, ByVal Kakudo As Single) As PointF

        Dim OutP As PointF

        Dim k As Double = Kakudo * Math.PI / 180
        OutP.X = P.X * Math.Cos(k) - P.Y * Math.Sin(k)
        OutP.Y = P.X * Math.Sin(k) + P.Y * Math.Cos(k)
        Return OutP
    End Function
    ''' <summary>
    ''' 二次元座標回転角度指定
    ''' </summary>
    ''' <param name="P">元座標</param>
    ''' <param name="Kakudo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Trans2D(ByVal P As Point, ByVal Kakudo As Single) As Point

        Dim OutP As Point

        Dim k As Double = Kakudo * Math.PI / 180
        OutP.X = P.X * Math.Cos(k) - P.Y * Math.Sin(k)
        OutP.Y = P.X * Math.Sin(k) + P.Y * Math.Cos(k)
        Return OutP
    End Function
    ''' <summary>
    ''' 回転中心を指定して二次元座標回転角度指定
    ''' </summary>
    ''' <param name="CenterP"></param>
    ''' <param name="P"></param>
    ''' <param name="Kakudo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Trans2D(ByVal CenterP As Point, P As Point, ByVal Kakudo As Single) As Point
        Dim OutP As Point

        Dim k As Double = Kakudo * Math.PI / 180
        OutP.X = (P.X - CenterP.X) * Math.Cos(k) - (P.Y - CenterP.Y) * Math.Sin(k)
        OutP.Y = (P.X - CenterP.X) * Math.Sin(k) + (P.Y - CenterP.Y) * Math.Cos(k)
        OutP.Offset(CenterP)
        Return OutP
    End Function
    ''' <summary>
    ''' 回転中心を指定して二次元座標回転角度指定
    ''' </summary>
    ''' <param name="CenterP"></param>
    ''' <param name="P"></param>
    ''' <param name="Kakudo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Trans2D(ByVal CenterP As PointF, P As PointF, ByVal Kakudo As Single) As PointF
        Dim OutP As PointF

        Dim k As Double = Kakudo * Math.PI / 180
        OutP.X = (P.X - CenterP.X) * Math.Cos(k) - (P.Y - CenterP.Y) * Math.Sin(k)
        OutP.Y = (P.X - CenterP.X) * Math.Sin(k) + (P.Y - CenterP.Y) * Math.Cos(k)
        spatial.PointF_offset(OutP, CenterP)
        Return OutP
    End Function
    ''' <summary>
    ''' 二次元座標回転sincos指定
    ''' </summary>
    ''' <param name="P">元座標</param>
    ''' <param name="s">回転sin</param>
    ''' <param name="c">cos</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Trans2D(ByVal P As PointF, ByVal s As Single, ByVal c As Single) As PointF

        Dim OutP As PointF

        OutP.X = P.X * c - P.Y * s
        OutP.Y = P.X * s + P.Y * c
        Return OutP
    End Function
    ''' <summary>
    ''' 二次元座標回転sincos指定
    ''' </summary>
    ''' <param name="P">元座標</param>
    ''' <param name="s">回転sin</param>
    ''' <param name="c">cos</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Trans2D(ByVal P As Point, ByVal s As Single, ByVal c As Single) As Point

        Dim OutP As Point

        OutP.X = P.X * c - P.Y * s
        OutP.Y = P.X * s + P.Y * c
        Return OutP
    End Function
    ''' <summary>
    ''' 回転させた四角形の座標配列を取得。戻り値は5つの座標（4=0）
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <param name="Kakudo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_TurnedRectangle(ByVal Rect As RectangleF, ByVal Kakudo As Single) As PointF()
        Dim x1 As Integer = Rect.Left
        Dim y1 As Integer = Rect.Top
        Dim x2 As Integer = Rect.Right
        Dim y2 As Integer = Rect.Bottom

        Dim pxy(4) As PointF
        Dim cn As Integer = 4
        pxy(0).X = x1
        pxy(0).Y = y1
        pxy(1).X = x2
        pxy(1).Y = y1
        pxy(2).X = x2
        pxy(2).Y = y2
        pxy(3).X = x1
        pxy(3).Y = y2

        If Kakudo <> 0 Then
            Dim cp As PointF = Get_CenterPoint_of_Rect(Rect)
            For i As Integer = 0 To 3
                pxy(i) = spatial.Trans2D(cp, pxy(i), -Kakudo)
            Next
        Else
        End If
        pxy(4) = pxy(0)
        Return pxy
    End Function
    ''' <summary>
    ''' 回転させた四角形の座標配列を取得。戻り値は5つの座標（4=0）
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <param name="Kakudo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_TurnedRectangle(ByVal Rect As Rectangle, ByVal Kakudo As Single) As Point()
        Dim x1 As Integer = Rect.Left
        Dim y1 As Integer = Rect.Top
        Dim x2 As Integer = Rect.Right
        Dim y2 As Integer = Rect.Bottom

        Dim pxy(4) As Point
        Dim cn As Integer = 4
        pxy(0).X = x1
        pxy(0).Y = y1
        pxy(1).X = x2
        pxy(1).Y = y1
        pxy(2).X = x2
        pxy(2).Y = y2
        pxy(3).X = x1
        pxy(3).Y = y2

        If Kakudo <> 0 Then
            Dim cp As Point = Get_CenterPoint_of_Rect(Rect)
            For i As Integer = 0 To 3
                pxy(i) = spatial.Trans2D(cp, pxy(i), -Kakudo)
            Next
        Else
        End If
        pxy(4) = pxy(0)
        Return pxy
    End Function
    ''' <summary>
    ''' 2地点の座標から外接四角形を返す
    ''' </summary>
    ''' <param name="P1"></param>
    ''' <param name="P2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Circumscribed_Rectangle(ByVal P1 As Point, ByVal P2 As Point) As Rectangle
        '
        With P1
            Return Rectangle.FromLTRB(Math.Min(.X, P2.X), Math.Min(.Y, P2.Y), Math.Max(.X, P2.X), Math.Max(.Y, P2.Y))
        End With
    End Function
    ''' <summary>
    ''' 2地点の座標から外接四角形を返す
    ''' </summary>
    ''' <param name="P1"></param>
    ''' <param name="P2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Circumscribed_Rectangle(ByVal P1 As PointF, ByVal P2 As PointF) As RectangleF
        '
        With P1
            Return RectangleF.FromLTRB(Math.Min(.X, P2.X), Math.Min(.Y, P2.Y), Math.Max(.X, P2.X), Math.Max(.Y, P2.Y))
        End With
    End Function
    ''' <summary>
    ''' Circumscribed_Rectangleの上下左右と地点を比較し、Unionして返す
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="Circumscribed_Rectangle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Circumscribed_Rectangle(ByVal P As PointF, ByVal Circumscribed_Rectangle As RectangleF) As RectangleF
        '
        With Circumscribed_Rectangle
            Dim minX As Single = .Left
            Dim minY As Single = .Top
            Dim maxX As Single = .Right
            Dim maxY As Single = .Bottom
            If minX > P.X Then
                minX = P.X
            End If
            If minY > P.Y Then
                minY = P.Y
            End If
            If maxX < P.X Then
                maxX = P.X
            End If
            If maxY < P.Y Then
                maxY = P.Y
            End If
            Dim r As RectangleF = RectangleF.FromLTRB(minX, minY, maxX, maxY)
            Return r
        End With
    End Function
    ''' <summary>
    ''' Circumscribed_Rectangleの上下左右と地点を比較し、Unionして返す
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="Circumscribed_Rectangle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Circumscribed_Rectangle(ByVal P As Point, ByVal Circumscribed_Rectangle As Rectangle) As Rectangle
        '
        With Circumscribed_Rectangle
            Return Rectangle.FromLTRB(Math.Min(.Left, P.X), Math.Min(.Top, P.Y), Math.Max(.Right, P.X), Math.Max(.Bottom, P.Y))
        End With
    End Function
    Public Shared Function Get_Circumscribed_Rectangle(ByVal Rect1 As Rectangle, ByVal Rect2 As Rectangle) As Rectangle
        'Circumscribed_Rectangleの上下左右と地点を比較し、Unionして返す
        Return Rectangle.Union(Rect1, Rect2)
    End Function
    Public Shared Function Get_Circumscribed_Rectangle(ByVal Rect1 As RectangleF, ByVal Rect2 As RectangleF) As RectangleF
        'Circumscribed_Rectangleの上下左右と地点を比較し、Unionして返す
        Return RectangleF.Union(Rect1, Rect2)
    End Function
    Public Shared Function Get_Circumscribed_Rectangle(ByVal RectLatLon1 As strLatLonBox, ByVal RectLatLon2 As strLatLonBox) As strLatLonBox
        Dim Rec As RectangleF = RectangleF.Union(RectLatLon1.toRectangleF, RectLatLon2.toRectangleF)
        'Circumscribed_Rectangleの上下左右と地点を比較し、Unionして返す
        Return New strLatLonBox(Rec)
    End Function
    Public Shared Function Get_Circumscribed_Rectangle(ByRef LineXY() As PointF, ByVal StartP As Integer, ByVal Num As Integer) As RectangleF
        'Circumscribed_Rectangleの上下左右と地点を比較し、Unionして返す

        Dim minX As Single = LineXY(StartP).X
        Dim minY As Single = LineXY(StartP).Y
        Dim maxX As Single = minX
        Dim maxY As Single = minY
        For j As Integer = 1 To Num - 1
            With LineXY(StartP + j)
                If minX > .X Then
                    minX = .X
                End If
                If minY > .Y Then
                    minY = .Y
                End If
                If maxX < .X Then
                    maxX = .X
                End If
                If maxY < .Y Then
                    maxY = .Y
                End If
            End With
        Next
        Dim rect As RectangleF = RectangleF.FromLTRB(minX, minY, maxX, maxY)
        Return rect
    End Function

    Public Shared Function Get_Circumscribed_Rectangle(ByRef LineXY() As Point, ByVal StartP As Integer, ByVal Num As Integer) As Rectangle
        'Circumscribed_Rectangleの上下左右と地点を比較し、Unionして返す
        Dim RECT As Rectangle = New Rectangle(LineXY(StartP).X, LineXY(StartP).Y, 0, 0)

        For j As Integer = 1 To Num - 1
            RECT = Get_Circumscribed_Rectangle(LineXY(StartP + j), RECT)
        Next
        Return RECT
    End Function
    ''' <summary>
    ''' 四角形を回転させた外接四角形を求める
    ''' </summary>
    ''' <param name="Rect1"></param>
    ''' <param name="Angle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Circumscribed_Rectangle(ByVal Rect1 As Rectangle, ByVal Angle As Single) As Rectangle
        Dim P() As Point = spatial.Get_TurnedRectangle(Rect1, Angle)
        Dim Rect As Rectangle = spatial.Get_Circumscribed_Rectangle(P, 0, 3)
        Return Rect
    End Function
    ''' <summary>
    ''' 四角形を回転させた外接四角形を求める
    ''' </summary>
    ''' <param name="Rect1"></param>
    ''' <param name="Angle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Circumscribed_Rectangle(ByVal Rect1 As RectangleF, ByVal Angle As Single) As RectangleF
        Dim P() As PointF = spatial.Get_TurnedRectangle(Rect1, Angle)
        Dim Rect As RectangleF = spatial.Get_Circumscribed_Rectangle(P, 0, 4)
        Return Rect
    End Function
    ''' <summary>
    ''' 二つのポイントの外接四角形を求める
    ''' </summary>
    ''' <param name="P1"></param>
    ''' <param name="P2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Rectangle(ByVal P1 As PointF, ByVal P2 As PointF) As RectangleF
        With P1
            Return RectangleF.FromLTRB(Math.Min(.X, P2.X), Math.Min(.Y, P2.Y), Math.Max(.X, P2.X), Math.Max(.Y, P2.Y))
        End With
    End Function

    ''' <summary>
    ''' 二つのポイントの外接四角形を求める
    ''' </summary>
    ''' <param name="P1"></param>
    ''' <param name="P2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Rectangle(ByVal P1 As Point, ByVal P2 As Point) As Rectangle
        With P1
            Return Rectangle.FromLTRB(Math.Min(.X, P2.X), Math.Min(.Y, P2.Y), Math.Max(.X, P2.X), Math.Max(.Y, P2.Y))
        End With
    End Function
    ''' <summary>
    ''' 四角形の中心と幅高さから外接四角形を求める
    ''' </summary>
    ''' <param name="P1"></param>
    ''' <param name="Size"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Rectangle(ByVal P1 As Point, ByVal Size As Size) As Rectangle
        Return New Rectangle(New Point(P1.X - Size.Width / 2, P1.Y - Size.Height / 2), Size)
    End Function
    ''' <summary>
    ''' 四角形の中心と幅高さから外接四角形を求める
    ''' </summary>
    ''' <param name="P1"></param>
    ''' <param name="Size"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Rectangle(ByVal P1 As PointF, ByVal Size As SizeF) As RectangleF
        Return New RectangleF(New Point(P1.X - Size.Width, P1.Y - Size.Height), Size)
    End Function
    ''' <summary>
    ''' 中心と半径から外接四角形を求める
    ''' </summary>
    ''' <param name="P1"></param>
    ''' <param name="r"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Rectangle(ByVal P1 As Point, ByVal r As Integer) As Rectangle
        With P1
            Return New Rectangle(.X - r, .Y - r, r * 2, r * 2)
        End With
    End Function

    ''' <summary>
    ''' 2つの四角形の上下左右端1つでも一致する場合true
    ''' </summary>
    ''' <param name="Rec1"></param>
    ''' <param name="Rec2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_TwoRectangele_Inner_Contact(ByVal Rec1 As RectangleF, ByVal Rec2 As RectangleF) As Boolean
        'Rightとbottomに幅を持たせているのは誤差への対応
        If Rec1.Left = Rec2.Left Or Math.Abs(Rec1.Right - Rec2.Right) < 0.000001 Or Rec1.Top = Rec2.Top Or Math.Abs(Rec1.Bottom - Rec2.Bottom) << 0.000001 Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' 二つの長方形の内外判定(片方を回転)
    ''' </summary>
    ''' <param name="Rect1"></param>
    ''' <param name="Rect1Angle"></param>
    ''' <param name="Rect2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Compare_Two_Rectangle_Position(ByVal Rect1 As RectangleF, ByVal Rect1Angle As Single, ByVal Rect2 As RectangleF) As cstRectangle_Cross
        Dim trect As RectangleF = spatial.Get_Circumscribed_Rectangle(Rect1, Rect1Angle)
        Return spatial.Compare_Two_Rectangle_Position(trect, Rect2)
    End Function
    ''' <summary>
    ''' 二つの長方形の内外判定(片方を回転)
    ''' </summary>
    ''' <param name="Rect1"></param>
    ''' <param name="Rect1Angle"></param>
    ''' <param name="Rect2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Compare_Two_Rectangle_Position(ByVal Rect1 As Rectangle, ByVal Rect1Angle As Single, ByVal Rect2 As Rectangle) As cstRectangle_Cross
        Dim trect As Rectangle = spatial.Get_Circumscribed_Rectangle(Rect1, Rect1Angle)
        Return spatial.Compare_Two_Rectangle_Position(trect, Rect2)
    End Function
    ''' <summary>
    ''' 二つの長方形の内外判定(単精度)
    ''' </summary>
    ''' <param name="Rec1"></param>
    ''' <param name="Rec2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Compare_Two_Rectangle_Position(ByVal Rec1 As RectangleF, ByVal Rec2 As RectangleF) As cstRectangle_Cross
        With Rec1
            If .Equals(Rec2) = True Then
                Return cstRectangle_Cross.cstEqual '同じ
            Else
                If Rec1.Contains(Rec2) Then
                    Return cstRectangle_Cross.cstInclusion 'Rec1の中にRec2が含まれる
                ElseIf Rec2.Contains(Rec1) Then
                    Return cstRectangle_Cross.cstInner  'Rec2の中にRec1が含まれる
                ElseIf Rec1.IntersectsWith(Rec2) Then
                    Return cstRectangle_Cross.cstCross  '交差している
                Else
                    Return cstRectangle_Cross.cstOuter    'ずれている
                End If

            End If
        End With

    End Function
    ''' <summary>
    ''' 二つの長方形の内外判定(単精度)、指定量分拡大して比較する。
    ''' </summary>
    ''' <param name="Rec1"></param>
    ''' <param name="Rec2"></param>
    ''' <param name="inflateValue">少し拡大する量</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Compare_Two_Rectangle_Position(ByVal Rec1 As RectangleF, ByVal Rec2 As RectangleF, ByVal inflateValue As Single) As cstRectangle_Cross

        Rec1.Inflate(New SizeF(inflateValue, inflateValue))
        Rec2.Inflate(New SizeF(inflateValue, inflateValue))
        Return Compare_Two_Rectangle_Position(Rec1, Rec2)
    End Function

    ''' <summary>
    ''' 二つの長方形の内外判定(整数)
    ''' </summary>
    ''' <param name="Rec1"></param>
    ''' <param name="Rec2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Compare_Two_Rectangle_Position(ByVal Rec1 As Rectangle, ByVal Rec2 As Rectangle) As cstRectangle_Cross

        With Rec1
            If .Equals(Rec2) = True Then
                Return cstRectangle_Cross.cstEqual '同じ
            Else
                If Rec1.Contains(Rec2) Then
                    Return cstRectangle_Cross.cstInclusion 'Rec1の中にRec2が含まれる
                ElseIf Rec2.Contains(Rec1) Then
                    Return cstRectangle_Cross.cstInner  'Rec2の中にRec1が含まれる
                ElseIf Rec1.IntersectsWith(Rec2) Then
                    Return cstRectangle_Cross.cstCross  '交差している
                Else
                    Return cstRectangle_Cross.cstOuter    'ずれている
                End If

            End If
        End With
    End Function
    ''' <summary>
    ''' 二つの長方形の内外判定(整数)片方はポイントと半径
    ''' </summary>
    ''' <param name="Point1"></param>
    ''' <param name="PointR"></param>
    ''' <param name="Rec2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Compare_Two_Rectangle_Position(ByVal Point1 As Point, ByVal PointR As Integer, ByVal Rec2 As Rectangle) As cstRectangle_Cross
        Dim C_Rect As New Rectangle(New Point(Point1.X - PointR, Point1.Y - PointR), New Size(PointR * 2, PointR * 2))
        Return Compare_Two_Rectangle_Position(C_Rect, Rec2)
    End Function
    ''' <summary>
    ''' Pointと線分LineP1-LineP2間の距離を計算して返す
    ''' </summary>
    ''' <param name="Point"></param>
    ''' <param name="LineP1"></param>
    ''' <param name="LineP2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Distance_PointLine(ByVal Point As PointF, ByVal LineP1 As PointF, ByVal LineP2 As PointF) As Single
        Dim np1 As Single, np2 As Single
        Return Distance_PointLine(Point.X, Point.Y, LineP1.X, LineP1.Y, LineP2.X, LineP2.Y, np1, np2)
    End Function
    ''' <summary>
    ''' Pointと線分LineP1-LineP2間の距離を計算して返す
    ''' </summary>
    ''' <param name="Point"></param>
    ''' <param name="LineP1"></param>
    ''' <param name="LineP2"></param>
    ''' <param name="NearestPoint">最短地点（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Distance_PointLine(ByVal Point As PointF, ByVal LineP1 As PointF, ByVal LineP2 As PointF, ByRef NearestPoint As PointF) As Single
        Return Distance_PointLine(Point.X, Point.Y, LineP1.X, LineP1.Y, LineP2.X, LineP2.Y, NearestPoint.X, NearestPoint.Y)
    End Function

    ''' <summary>
    ''' AXAY,BXBYで定義される線分と、XYポイントの間の距離を計算して返す
    ''' </summary>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="ax"></param>
    ''' <param name="ay"></param>
    ''' <param name="BX"></param>
    ''' <param name="BY"></param>
    ''' <param name="Nearest_pointX">最も近い位置の線分上の点を取得（オプション）</param>
    ''' <param name="Nearest_pointY"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Distance_PointLine(ByVal X As Single, ByVal Y As Single, _
                                              ByVal ax As Single, ByVal ay As Single, _
                                              ByVal BX As Single, ByVal BY As Single, _
                                              Optional ByRef Nearest_pointX As Single = 0, Optional ByRef Nearest_pointY As Single = 0) As Single
        Dim D As Single

        Dim po As Integer = 0
        Dim xs As Single = BX - ax
        Dim Ys As Single = BY - ay
        Dim d1 As Single = get_Distance(X, Y, ax, ay)
        Dim d2 As Single = get_Distance(X, Y, BX, BY)

        If xs = 0 Then
            If Math.Min(ay, BY) <= Y And Y <= Math.Max(ay, BY) Then
                D = Math.Abs(X - ax)
                Nearest_pointX = ax
                Nearest_pointY = Y
            Else
                po = 1
            End If
        ElseIf Ys = 0 Then
            If Math.Min(ax, BX) <= X And X <= Math.Max(ax, BX) Then
                D = Math.Abs(Y - ay)
                Nearest_pointX = X
                Nearest_pointY = ay
            Else
                po = 1
            End If

        Else

            Dim a As Single = Ys / xs
            Dim b As Single = -a * ax + ay

            Dim Va As Single = -1 / a
            Dim Va2 As Single = -Va * X + Y
            Dim crossX As Single = (Va2 - b) / (a - Va)

            If Math.Min(ax, BX) <= crossX And crossX <= Math.Max(ax, BX) Then
                D = Math.Abs(-Ys * X + xs * Y - xs * ay + Ys * ax) / Math.Sqrt(xs ^ 2 + Ys ^ 2)
                Nearest_pointX = crossX
                Nearest_pointY = crossX * a + b
            Else
                po = 1
            End If
        End If

        If po = 1 Then
            If d1 < d2 Then
                D = d1
                Nearest_pointX = ax
                Nearest_pointY = ay
            Else
                D = d2
                Nearest_pointX = BX
                Nearest_pointY = BY
            End If
        End If

        Return D

    End Function
    Public Shared Function Check_PointInBox(ByVal P As PointF, ByVal Kakudo As Single, ByVal Circumscribed_Rectangle As RectangleF) As Boolean
        Return Check_PointInBox(P.X, P.Y, Kakudo, Circumscribed_Rectangle)
    End Function
    Public Shared Function Check_PointInBox(ByVal P As Point, ByVal Kakudo As Single, ByVal Circumscribed_Rectangle As Rectangle) As Boolean
        Return Check_PointInBox(P.X, P.Y, Kakudo, Circumscribed_Rectangle)
    End Function

    Public Shared Function Check_PointInBox(ByVal X As Single, ByVal Y As Single, ByVal Kakudo As Single, ByVal Circumscribed_Rectangle As RectangleF) As Boolean
        Dim cx As Single, cy As Single
        Dim x2 As Single, y2 As Single

        With Circumscribed_Rectangle
            If Kakudo <> 0 Then
                cx = (.Left + .Right) / 2
                cy = (.Top + .Bottom) / 2
                x2 = X - cx
                y2 = Y - cy
                Trans2D(x2, y2, Kakudo)
                X = cx + x2
                Y = cy + y2
            End If
            If X >= .Left And X <= .Right And Y >= .Top And Y <= .Bottom Then
                Return True
            Else
                Return False
            End If
        End With
    End Function
    ''' <summary>
    ''' 四角形に点が入らない場合，入るように座標を修正して返す
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="Rect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function checkAndModifyPointInRect(ByVal P As PointF, ByVal Rect As RectangleF) As PointF
        Dim np As PointF = P
        If np.X < Rect.Left Then
            np.X = Rect.Left
        End If
        If np.X > Rect.Right Then
            np.X = Rect.Right
        End If
        If np.Y < Rect.Top Then
            np.Y = Rect.Top
        End If
        If np.Y > Rect.Bottom Then
            np.Y = Rect.Bottom
        End If
        Return np
    End Function
    ''' <summary>
    ''' 四角形に点が入らない場合，入るように座標を修正して返す
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="Rect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function checkAndModifyPointInRect(ByVal P As Point, ByVal Rect As Rectangle) As Point
        Dim np As Point = P
        If np.X < Rect.Left Then
            np.X = Rect.Left
        End If
        If np.X > Rect.Right Then
            np.X = Rect.Right
        End If
        If np.Y < Rect.Top Then
            np.Y = Rect.Top
        End If
        If np.Y > Rect.Bottom Then
            np.Y = Rect.Bottom
        End If
        Return np
    End Function


    ''' <summary>
    ''' 四角形と点の内外判定と、周囲の線との距離を求めて返す
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="Rect"></param>
    ''' <param name="Distance_From_Line">距離（戻り値）</param>
    ''' <returns>内部の場合true</returns>
    ''' <remarks></remarks>
    Public Shared Function Check_PointInBox(ByVal P As Point, ByVal Rect As Rectangle, ByRef Distance_From_Line As Integer)

        '四角形の外周との距離
        Dim recp2() As Point = spatial.Get_PolyLine_from_Recatngle(Rect)
        Dim dis As Integer = 0
        For j As Integer = 0 To 3
            Dim d2 As Integer = spatial.Distance_PointLine(P, recp2(j), recp2(j + 1))
            If j <> 0 Then
                dis = Math.Min(dis, d2)
            Else
                dis = d2
            End If
        Next
        Distance_From_Line = dis
        Return Check_PointInBox(P, 0, Rect)
    End Function
    Public Shared Function Trans3D(ByVal X As Single, ByVal Y As Single, ByVal z As Single,
                                   ByVal TurnCenter As PointF, ByVal Expantion As Single,
                                   ByVal Pitch As Single, ByVal Head As Single, ByVal Bank As Single,
                                   ByVal XYPara As Single) As PointF

        Dim xx As Single, yy As Single, ZZ As Single
        Dim yy1 As Single, ZZ1 As Single
        Dim xx2 As Single, ZZ2 As Single
        Dim XX3 As Single, YY3 As Single, ww As Single
        Dim COSP As Single, SINP As Single, COSH As Single, SINH As Single, COSB As Single, SINB As Single
        Dim ESPara As Single
        Dim Z3D As Single


        ESPara = Expantion / 100
        COSP = Math.Cos(Pitch * Math.PI / 180) : SINP = Math.Sin(Pitch * Math.PI / 180)
        COSH = Math.Cos(Head * Math.PI / 180) : SINH = Math.Sin(Head * Math.PI / 180)
        COSB = Math.Cos(Bank * Math.PI / 180) : SINB = Math.Sin(Bank * Math.PI / 180)

        xx = X - TurnCenter.X
        yy = Y - TurnCenter.Y
        ZZ = z
        yy1 = yy * COSP - ZZ * SINP
        ZZ1 = yy * SINP + ZZ * COSP
        xx2 = xx * COSH + ZZ1 * SINH
        ZZ2 = -xx * SINH + ZZ1 * COSH '修正済み
        XX3 = xx2 * COSB - yy1 * SINB
        YY3 = xx2 * SINB + yy1 * COSB
        Z3D = ZZ2 * ESPara
        XX3 = XX3 * ESPara
        YY3 = YY3 * ESPara
        ww = XYPara / (XYPara - Z3D)

        Dim newP As PointF = New PointF(XX3 * ww + TurnCenter.X, YY3 * ww + TurnCenter.Y)
        Return newP
    End Function


    Public Shared Sub Trans2D_SinCos(ByRef X As Single, ByRef Y As Single, ByVal s As Single, ByVal c As Single)

        Dim xx As Single = X * c - Y * s
        Dim yy As Single = X * s + Y * c
        X = xx
        Y = yy
    End Sub
    ''' <summary>
    ''' 四角形の回転後の4隅座標取得。戻り値は5つの座標（4=0）
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <param name="Kakudo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Trans2D(ByVal Rect As Rectangle, ByVal Kakudo As Single) As Point()
        Dim p(4) As Point
        Dim cp As Point = Get_CenterPoint_of_Rect(Rect)
        With Rect
            p(0) = New Point(.Left - cp.X, .Top - cp.Y)
            p(1) = New Point(.Right - cp.X, .Top - cp.Y)
            p(2) = New Point(.Right - cp.X, .Bottom - cp.Y)
            p(3) = New Point(.Left - cp.X, .Bottom - cp.Y)
        End With
        For i As Integer = 0 To 3
            Trans2D(p(i), Kakudo)
            p(i).X += cp.X
            p(i).Y += cp.Y
        Next
        p(4) = p(0)
        Return p

    End Function
    ''' <summary>
    ''' 四角形の回転後の4隅座標取得。戻り値は5つの座標（4=0）
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <param name="Kakudo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Trans2D(ByVal Rect As RectangleF, ByVal Kakudo As Single) As PointF()
        Dim p(4) As PointF
        Dim cp As PointF = Get_CenterPoint_of_Rect(Rect)
        With Rect
            p(0) = New PointF(.Left - cp.X, .Top - cp.Y)
            p(1) = New PointF(.Right - cp.X, .Top - cp.Y)
            p(2) = New PointF(.Right - cp.X, .Bottom - cp.Y)
            p(3) = New PointF(.Left - cp.X, .Bottom - cp.Y)
        End With
        For i As Integer = 0 To 3
            Trans2D(p(i), Kakudo)
            p(i).X += cp.X
            p(i).Y += cp.Y
        Next
        p(4) = p(0)
        Return p

    End Function
    Public Shared Sub Trans2D(ByRef X As Single, ByRef Y As Single, ByVal Kakudo As Single)

        Dim k As Single = Kakudo * Math.PI / 180
        Dim xx As Single = X * Math.Cos(k) - Y * Math.Sin(k)
        Dim yy As Single = X * Math.Sin(k) + Y * Math.Cos(k)
        X = xx
        Y = yy
    End Sub
    ''' <summary>
    ''' 地図座標のXYから緯度経度にして距離測定
    ''' </summary>
    ''' <param name="P1"></param>
    ''' <param name="P2"></param>
    ''' <param name="MapDTMapZahyo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Distance_Ido_Kedo_XY(ByVal P1 As PointF, ByVal P2 As PointF, ByRef MapDTMapZahyo As clsMapData.Zahyo_info) As Single


        Dim D1 As PointF = Get_Reverse_XY(P1, MapDTMapZahyo)
        Dim D2 As PointF = Get_Reverse_XY(P2, MapDTMapZahyo)
        Return Distance_Ido_Kedo(D1.Y, D1.X, D2.Y, D2.X)
    End Function
    ''' <summary>
    ''' '地図座標のXYから緯度経度にして距離測定
    ''' </summary>
    ''' <param name="X1"></param>
    ''' <param name="Y1"></param>
    ''' <param name="x2"></param>
    ''' <param name="y2"></param>
    ''' <param name="MapDTMapZahyo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Distance_Ido_Kedo_XY(ByVal X1 As Single, ByVal Y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByRef MapDTMapZahyo As clsMapData.Zahyo_info) As Single


        Dim D1 As PointF = Get_Reverse_XY(New PointF(X1, Y1), MapDTMapZahyo)
        Dim D2 As PointF = Get_Reverse_XY(New PointF(x2, y2), MapDTMapZahyo)
        Return Distance_Ido_Kedo(D1.Y, D1.X, D2.Y, D2.X)
    End Function
    ''' <summary>
    ''' 緯度経度で地点間の距離を求める
    ''' </summary>
    ''' <param name="Ido1"></param>
    ''' <param name="Kedo1"></param>
    ''' <param name="Ido2"></param>
    ''' <param name="Kedo2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Distance_Ido_Kedo(ByVal Platlon1 As strLatLon, ByVal Platlon2 As strLatLon) As Single
        Return Distance_Ido_Kedo(Platlon1.Latitude, Platlon1.Longitude, Platlon2.Latitude, Platlon2.Longitude)
    End Function
    ''' <summary>
    ''' 緯度経度で地点間の距離を求める
    ''' </summary>
    ''' <param name="Ido1"></param>
    ''' <param name="Kedo1"></param>
    ''' <param name="Ido2"></param>
    ''' <param name="Kedo2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Distance_Ido_Kedo(ByVal Ido1 As Single, ByVal Kedo1 As Single, ByVal Ido2 As Single, ByVal Kedo2 As Single) As Single
        '
        Dim DV As Double

        If Ido1 = Ido2 And Kedo1 = Kedo2 Then
            Distance_Ido_Kedo = 0
        Else
            '        cos_an = Sin(Ido1 * PI / 180) * Sin(Ido2 * PI / 180) + Cos(Ido1 * PI / 180) * Cos(Ido2 * PI / 180) * Cos((Kedo2 - Kedo1) * PI / 180)
            '        sin_an = Sqr(1 - cos_an ^ 2)
            '        ag = Angle(sin_an, cos_an)
            '        Distance_Ido_Kedo = EarthR * PI * (ag / 180)
            DV = Math.Sqrt((Math.Cos((Ido1 + Ido2) * Math.PI / 180 / 2) * Math.Sin((Kedo1 - Kedo2) * Math.PI / 180 / 2)) ^ 2 + _
                        (Math.Sin((Ido1 - Ido2) * Math.PI / 180 / 2) * Math.Cos((Kedo1 - Kedo2) * Math.PI / 180 / 2)) ^ 2)

            Return 2 * EarthR * Math.Atan(DV / Math.Sqrt(-DV * DV + 1))
        End If
    End Function
    ''' <summary>
    ''' 特定地点と地点配列の最短距離とその位置を求める
    ''' </summary>
    ''' <param name="CheckP">調べる座標</param>
    ''' <param name="Points">座標配列</param>
    ''' <param name="pointN">座標配列数</param>
    ''' <param name="min_distance">最小距離（戻り値）</param>
    ''' <returns>最小距離の配列位置</returns>
    ''' <remarks></remarks>
    Public Shared Function get_PointDistance(ByVal CheckP As Point, ByRef Points() As Point, ByVal pointN As Integer, ByRef min_distance As Integer) As Integer
        Dim n As Integer = -1
        For i As Integer = 0 To pointN - 1
            Dim d As Integer = spatial.get_Distance(Points(i), CheckP)
            If d <= min_distance Then
                min_distance = d
                n = i
            End If
        Next
        Return n
    End Function
    Public Shared Function get_Distance(ByVal X1 As Single, ByVal Y1 As Single, ByVal x2 As Single, ByVal y2 As Single) As Single
        Return Math.Sqrt((X1 - x2) ^ 2 + (Y1 - y2) ^ 2)
    End Function
    Public Shared Function get_Distance(ByVal X1 As Integer, ByVal Y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Single
        Return Math.Sqrt((X1 - x2) ^ 2 + (Y1 - y2) ^ 2)
    End Function
    Public Shared Function get_Distance(ByVal Point1 As Point, ByVal Point2 As Point) As Single
        Return Math.Sqrt((Point1.X - Point2.X) ^ 2 + (Point1.Y - Point2.Y) ^ 2)
    End Function
    Public Shared Function get_Distance(ByVal Point1 As PointF, ByVal Point2 As PointF) As Single
        Return Math.Sqrt((Point1.X - Point2.X) ^ 2 + (Point1.Y - Point2.Y) ^ 2)
    End Function

    ''' <summary>
    ''' 地図座標を新しい設定の地図座標に変換する
    ''' </summary>
    ''' <param name="OldP"></param>
    ''' <param name="oldZahyo"></param>
    ''' <param name="newZahyo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Reverse_and_Convert_XY(ByVal OldP As PointF, ByVal oldMapZahyo As clsMapData.Zahyo_info, ByVal newMapZahyo As clsMapData.Zahyo_info) As PointF
        If oldMapZahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
            Return OldP
        Else
            Dim X2C As Double, Y2C As Double
            Dim X3C As Double, Y3C As Double
            Dim P2 As PointF = spatial.Get_Reverse_XY(OldP, oldMapZahyo)
            If newMapZahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido And oldMapZahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                If newMapZahyo.System <> oldMapZahyo.System Then
                    '二つとも緯度経度座標で、測地系が違う場合
                    Select Case oldMapZahyo.System
                        Case enmZahyo_System_Info.Zahyo_System_tokyo
                            Call Tokyo97toITRF94(P2.Y, P2.X, Y2C, X2C)
                        Case enmZahyo_System_Info.Zahyo_System_World
                            Call ITRF94toTokyo97(P2.Y, P2.X, Y2C, X2C)
                    End Select
                    P2.X = CSng(X2C)
                    P2.Y = CSng(Y2C)
                End If
            ElseIf oldMapZahyo.Mode = enmZahyo_mode_info.Zahyo_HeimenTyokkaku And newMapZahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                '元が平面直角、新規が緯度経度の場合、
                With oldMapZahyo
                    Dim Ellip12 As Integer
                    Dim Kei As Integer = .HeimenTyokkaku_KEI_Number
                    If .System = enmZahyo_System_Info.Zahyo_System_tokyo Then
                        Ellip12 = 1
                    ElseIf .System = enmZahyo_System_Info.Zahyo_System_World Then
                        Ellip12 = 2
                    End If
                    Call doCalcXy2bl(Ellip12, Kei, P2.Y, P2.X, Y2C, X2C)
                End With
                If newMapZahyo.System <> oldMapZahyo.System Then
                    'さらに測地系が違う場合
                    Select Case oldMapZahyo.System
                        Case enmZahyo_System_Info.Zahyo_System_tokyo
                            Call Tokyo97toITRF94(Y2C, X2C, Y3C, X3C)
                        Case enmZahyo_System_Info.Zahyo_System_World
                            Call ITRF94toTokyo97(Y2C, X2C, Y3C, X3C)
                    End Select
                    X2C = X3C
                    Y2C = Y3C
                End If
                P2.X = CSng(X2C)
                P2.Y = CSng(Y2C)
            End If
            Dim P3 As PointF = spatial.Get_Converted_XY(P2, newMapZahyo)
            Return P3
        End If
    End Function
    ''' <summary>
    ''' 緯度経度等もともとの座標から、投影変換した座標を返す
    ''' </summary>
    ''' <param name="Position">緯度経度、XY</param>
    ''' <param name="MPData"></param>
    ''' <returns>投影変換後の座標</returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Converted_XY(ByVal Position As PointF, ByRef MPDataMapZahyo As clsMapData.Zahyo_info) As PointF
        Dim ox As Single = Position.X
        Dim oy As Single = Position.Y
        With MPDataMapZahyo
            Select Case .Mode
                Case enmZahyo_mode_info.Zahyo_No_Mode
                    Return New PointF(ox, oy)
                Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                    Return New PointF(ox, -oy)
                Case enmZahyo_mode_info.Zahyo_Ido_Keido
                    Select Case .Projection
                        Case enmProjection_Info.prjSeikyoEntou
                            '正距円筒
                            Return New PointF(EarthR * (ox - .CenterXY.X) * Math.PI / 180, _
                                             -EarthR * oy * Math.PI / 180)
                        Case enmProjection_Info.prjMercator
                            'メルカトル
                            Dim newP As PointF
                            newP.X = EarthR * ((ox - .CenterXY.X) * Math.PI / 180)
                            If oy >= 89.9999 Then
                                oy = 89.9999
                            ElseIf oy <= -89.9999 Then
                                oy = -89.9999
                            End If
                            newP.Y = -EarthR * Math.Log(Math.Tan((45 + oy / 2) * Math.PI / 180))
                            Return newP
                        Case enmProjection_Info.prjMiller
                            'ミラー
                            Return New PointF(EarthR * ((ox - .CenterXY.X) * Math.PI / 180), _
                                      -EarthR * Math.Log(Math.Tan((45 + oy * 2 / 5) * Math.PI / 180)) * 1.25)
                        Case enmProjection_Info.prjLambertSeisekiEntou
                            'ランベルト正積円筒図法
                            Return New PointF(EarthR * ((ox - .CenterXY.X) * Math.PI / 180), _
                                        -EarthR * Math.Sin(oy * Math.PI / 180))
                        Case enmProjection_Info.prjSanson
                            'サンソン
                            Return New PointF(EarthR * ((ox - .CenterXY.X) * Math.PI / 180) * Math.Cos(oy * Math.PI / 180), _
                                                -EarthR * oy * Math.PI / 180)
                        Case enmProjection_Info.prjMollweide
                            'モルワイデ図法
                            Dim theata As Single
                            If NewtonMollweide(oy, theata) = True Then
                                Dim x As Single = EarthR * Math.Sqrt(2) / 90 * (ox - .CenterXY.X) * Math.Cos(theata)
                                Dim y As Single = -EarthR * Math.Sqrt(2) * Math.Sin(theata)
                                Return New PointF(x, y)
                            Else
                                Return New PointF(0, 0)
                            End If
                        Case enmProjection_Info.prjEckert4
                            'エッケルト4
                            Dim theata As Single
                            If NewtonEckert4(oy, theata) = True Then
                                Dim x As Single = EarthR * 0.4222382# * ((ox - .CenterXY.X) * Math.PI / 180) * (1 + Math.Cos(theata))
                                Dim y As Single = -EarthR * 1.3265044# * Math.Sin(theata)
                                Return New PointF(x, y)
                            Else
                                Return New PointF(0, 0)
                            End If
                    End Select
            End Select
        End With

    End Function

    Private Shared Function NewtonMollweide(ByVal lat As Single, ByRef theata As Single) As Boolean
        Dim x As Single = 0
        Dim dx As Single
        Dim lat2 = lat * Math.PI / 180
        Dim n As Integer = 0
        Do
            dx = -(x + Math.Sin(x) - Math.PI * Math.Sin(lat2)) / (Math.Cos(x) + 1)
            x += dx
            n += 1
            If n > 50 Then
                Return False
            End If
        Loop Until Math.Abs(dx) < 0.00001
        theata = x / 2
        Return True
    End Function

    Private Shared Function NewtonEckert4(ByVal lat As Single, ByRef theata As Single) As Boolean
        Dim x As Single = 0
        Dim dx As Single
        Dim lat2 = lat * Math.PI / 180
        Dim n As Integer = 0
        Do
            dx = -(x + Math.Sin(x) * Math.Cos(x) + 2 * Math.Sin(x) - (2 + Math.PI / 2) * Math.Sin(lat2)) / (1 + Math.Cos(2 * x) + 2 * Math.Cos(x))
            x += dx
            n += 1
            If n > 50 Then
                Return False
            End If
        Loop Until Math.Abs(dx) < 0.00001
        theata = x
        Return True
    End Function
    ''' <summary>
    ''' 地図座標が緯度経度に変換可能かチェックする
    ''' </summary>
    ''' <param name="Position"></param>
    ''' <param name="MPDataMapZahyo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_PsitionReverse_Enable(ByVal Position As PointF, ByRef MPDataMapZahyo As clsMapData.Zahyo_info) As Boolean
        Dim f As Boolean
        With MPDataMapZahyo
            Select Case .Mode
                Case enmZahyo_mode_info.Zahyo_No_Mode, enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                    f = True
                Case enmZahyo_mode_info.Zahyo_Ido_Keido
                    Dim oy As Single = Position.Y
                    f = True
                    Select Case .Projection
                        Case enmProjection_Info.prjSanson, enmProjection_Info.prjSeikyoEntou
                            If Math.Abs(oy / EarthR * 180 / Math.PI) > 90 Then
                                f = False
                            End If
                        Case enmProjection_Info.prjMercator
                            'メルカトル図法ではyは無限大でtrue
                        Case enmProjection_Info.prjMiller
                            Dim tx As Single = Math.Exp(-oy / (EarthR * 1.25))
                            If Math.Abs(Math.Atan(tx) * 5 / 2 * 180 / Math.PI - 45 * 5 / 2) > 90 Then
                                f = False
                            End If
                        Case enmProjection_Info.prjLambertSeisekiEntou
                            Dim tx As Single = -oy / EarthR
                            If Math.Abs(Math.Atan(tx / Math.Sqrt(-tx * tx + 1)) * 180 / Math.PI) > 90 Then
                                f = False
                            End If
                        Case enmProjection_Info.prjMollweide
                            If Math.Abs(Position.Y) > (Math.Sqrt(2) * EarthR - 0.001) Then
                                f = False
                            End If
                        Case enmProjection_Info.prjEckert4
                            If Math.Abs(Position.Y) > (1.3265004 * EarthR - 0.001) Then
                                f = False
                            End If
                    End Select
            End Select
        End With
        Return f
    End Function
    ''' <summary>
    ''' 緯度経度・平面直角座標系を変換した座標(地図ファイル中の座標)から、元の緯度経度・平面直角座標系座標に戻す
    ''' </summary>
    ''' <param name="Position">地図ファイル中の座標</param>
    ''' <param name="MPDataMap"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Reverse_XY(ByVal Position As PointF, ByRef MPDataMapZahyo As clsMapData.Zahyo_info) As PointF


        Dim ox As Single = Position.X
        Dim oy As Single = Position.Y

        With MPDataMapZahyo
            Select Case .Mode
                Case enmZahyo_mode_info.Zahyo_No_Mode
                    Return New PointF(ox, oy)
                Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                    Return New PointF(ox, -oy)
                Case enmZahyo_mode_info.Zahyo_Ido_Keido

                    Select Case .Projection
                        Case enmProjection_Info.prjSanson
                            'サンソン
                            Dim y As Single = -oy / EarthR * 180 / Math.PI
                            Return New PointF(.CenterXY.X + (ox * 180) / (EarthR * Math.PI * Math.Cos(y * Math.PI / 180)), y)
                        Case enmProjection_Info.prjSeikyoEntou
                            '正距円筒
                            Return New PointF(.CenterXY.X + (ox * 180) / (EarthR * Math.PI), _
                                            -oy / EarthR * 180 / Math.PI)
                        Case enmProjection_Info.prjMercator
                            'メルカトル
                            Dim tx As Single = Math.Exp(-oy / EarthR)
                            Return New PointF(.CenterXY.X + (ox * 180) / (EarthR * Math.PI), _
                                            2 * Math.Atan(tx) * 180 / Math.PI - 90)
                        Case enmProjection_Info.prjMiller
                            'ミラー
                            Dim tx As Single = Math.Exp(-oy / (EarthR * 1.25))
                            Return New PointF(.CenterXY.X + (ox * 180) / (EarthR * Math.PI), _
                                            Math.Atan(tx) * 5 / 2 * 180 / Math.PI - 45 * 5 / 2)
                        Case enmProjection_Info.prjLambertSeisekiEntou
                            'ランベルト正積円筒図法
                            Dim newP As PointF
                            newP.X = .CenterXY.X + (ox * 180) / (EarthR * Math.PI)
                            Dim tx As Single = -oy / EarthR
                            If tx >= 1 Then
                                newP.Y = 90
                            ElseIf tx <= -1 Then
                                newP.Y = -90
                            Else
                                newP.Y = Math.Atan(tx / Math.Sqrt(-tx * tx + 1)) * 180 / Math.PI
                            End If
                            Return newP
                        Case enmProjection_Info.prjMollweide
                            'モルワイデ図法
                            If Math.Abs(Position.Y) > (Math.Sqrt(2) * EarthR - 0.001) Then
                                Position.Y = (Math.Sqrt(2) * EarthR - 0.001) * Math.Sign(Position.Y)
                            End If
                            Dim theata As Single = Math.Asin(Position.Y / (Math.Sqrt(2) * EarthR))
                            Dim newP As PointF
                            newP.Y = -Math.Asin((2 * theata + Math.Sin(2 * theata)) / Math.PI) * 180 / Math.PI
                            newP.X = MPDataMapZahyo.CenterXY.X + Math.PI * Position.X / (2 * EarthR * Math.Sqrt(2) * Math.Cos(theata)) * 180 / Math.PI
                            Return newP
                        Case enmProjection_Info.prjEckert4
                            'エッケルト4
                            If Math.Abs(Position.Y) > (1.3265004 * EarthR - 0.001) Then
                                Position.Y = (1.3265004 * EarthR - 0.001) * Math.Sign(Position.Y)
                            End If
                            Dim theata As Single = Math.Asin(Position.Y / (1.3265004 * EarthR))
                            Dim newP As PointF
                            newP.Y = -Math.Asin((theata + Math.Sin(theata) * Math.Cos(theata) + 2 * Math.Sin(theata)) / (2 + Math.PI / 2)) * 180 / Math.PI
                            newP.X = MPDataMapZahyo.CenterXY.X + Position.X / (0.4223382# * EarthR * (1 + Math.Cos(theata))) * 180 / Math.PI
                            Return newP
                    End Select
            End Select
        End With
    End Function
    ''' <summary>
    ''' 投影法を逆変換する（現在使っていない）
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="MPDataMapZahyo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function twoDNewton(ByVal P As PointF, ByRef MPDataMapZahyo As clsMapData.Zahyo_info) As PointF

        Dim x As Single = P.X
        Dim y As Single = P.Y
        Dim u0 As Single = 0
        Dim v0 As Single = 0
        Dim espilon As Single = 10 ^ -2
        Dim delta = 0.001
        Dim x0 As Single, y0 As Single
        For i As Integer = 0 To 10
            If Proj(u0, v0, x0, y0, MPDataMapZahyo) = False Then
                Return New PointF(0, 0)
            End If
            Dim dx As Single = x - x0
            Dim dy As Single = y - y0
            If Math.Abs(dx) + Math.Abs(dy) < espilon Then
                Return New PointF(v0, u0)
            End If
            Dim x1 As Single, y1 As Single
            Dim x2 As Single, y2 As Single
            If Proj(u0 + delta, v0, x1, y1, MPDataMapZahyo) = False Then
                Return New PointF(0, 0)
            End If
            If Proj(u0 - delta, v0, x2, y2, MPDataMapZahyo) = False Then
                Return New PointF(0, 0)
            End If
            Dim dxdu As Single = (x1 - x2) / 2 / delta
            Dim dydu As Single = (y1 - y2) / 2 / delta
            If Proj(u0, v0 + delta, x1, y1, MPDataMapZahyo) = False Then
                Return New PointF(0, 0)
            End If
            If Proj(u0, v0 - delta, x2, y2, MPDataMapZahyo) = False Then
                Return New PointF(0, 0)
            End If
            Dim dxdv As Single = (x1 - x2) / 2 / delta
            Dim dydv As Single = (y1 - y2) / 2 / delta
            Dim det As Single = dxdu * dydv - dydu * dxdv
            Dim du As Single = (dydv * dx - dxdv * dy) / det
            Dim dv As Single = (-dydu * dx + dxdu * dy) / det
            u0 += du
            v0 += dv
        Next
        Return New PointF(10, 10)
    End Function
    Private Shared Function Proj(ByVal lat As Single, ByVal lon As Single, ByRef x As Single, ByRef y As Single, ByRef MPDataMapZahyo As clsMapData.Zahyo_info) As Boolean
        Select Case MPDataMapZahyo.Projection
            Case enmProjection_Info.prjMollweide
                Dim theata As Single
                If NewtonMollweide(lat, theata) = True Then
                    x = EarthR * Math.Sqrt(2) / 90 * (lon - MPDataMapZahyo.CenterXY.X) * Math.Cos(theata)
                    y = -EarthR * Math.Sqrt(2) * Math.Sin(theata)
                    Return True
                Else
                    Return False
                End If
            Case enmProjection_Info.prjEckert4
                Dim theata As Single
                If NewtonEckert4(lat, theata) = True Then
                    x = EarthR * 0.4222382# * ((lon - MPDataMapZahyo.CenterXY.X) * Math.PI / 180) * (1 + Math.Cos(theata))
                    y = -EarthR * 1.3265044# * Math.Sin(theata)
                    Return True
                Else
                    Return False
                End If
        End Select
    End Function
    ''' <summary>
    ''' 緯度経度・平面直角座標系を変換した四角形の四隅座標から、元の緯度経度・平面直角座標系座標に戻す
    ''' </summary>
    ''' <param name="In_Rect"></param>
    ''' <param name="MPDataMapZahyo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Reverse_Rect(ByVal In_Rect As RectangleF, ByRef MPDataMapZahyo As clsMapData.Zahyo_info) As RectangleF
        '
        'Dim dm As Single
        'Dim L1 As Single, L2 As Single, L3 As Single
        'Dim r1 As Single, r2 As Single, R3 As Single

        'Dim OriginP As RectangleF
        Dim leftP1 As PointF = Get_Reverse_XY(New PointF(In_Rect.Left, In_Rect.Top), MPDataMapZahyo)
        Dim leftP2 As PointF = Get_Reverse_XY(New PointF(In_Rect.Left, (In_Rect.Top + In_Rect.Bottom) / 2), MPDataMapZahyo)
        Dim leftP3 As PointF = Get_Reverse_XY(New PointF(In_Rect.Left, In_Rect.Bottom), MPDataMapZahyo)

        Dim left = Math.Min(Math.Min(leftP1.X, leftP2.X), leftP3.X)

        Dim rightP4 As PointF = Get_Reverse_XY(New PointF(In_Rect.Right, In_Rect.Top), MPDataMapZahyo)
        Dim rightP5 As PointF = Get_Reverse_XY(New PointF(In_Rect.Right, (In_Rect.Top + In_Rect.Bottom) / 2), MPDataMapZahyo)
        Dim rightP6 As PointF = Get_Reverse_XY(New PointF(In_Rect.Right, In_Rect.Bottom), MPDataMapZahyo)

        Dim right = Math.Max(Math.Max(rightP4.X, rightP5.X), rightP6.X)

        Return RectangleF.FromLTRB(left, leftP3.Y, right, leftP1.Y)

        'With Get_Reverse_Rect
        '    Call Get_Reverse_XY(L1, .Bottom, In_Rect.Left, In_Rect.Top, MPData)
        '    Call Get_Reverse_XY(L2, dm, In_Rect.Left, (In_Rect.Top + In_Rect.Bottom) / 2, MPData)
        '    Call Get_Reverse_XY(L3, .Top, In_Rect.Left, In_Rect.Bottom, MPData)

        '    .Left = Math.Min(L1, L2)
        '    .Left = Math.Min(.Left, L3)

        '    Call Get_Reverse_XY(r1, dm, In_Rect.Right, In_Rect.Top, MPData)
        '    Call Get_Reverse_XY(r2, dm, In_Rect.Right, (In_Rect.Top + In_Rect.Bottom) / 2, MPData)
        '    Call Get_Reverse_XY(R3, dm, In_Rect.Right, In_Rect.Bottom, MPData)

        '    Return RectangleF.FromLTRB(
        '    .right = mx(r1, r2)
        '    .Right = mx(.Right, R3)
        'End With
    End Function
    ''' <summary>
    ''' 投影法の緯度に応じたスケール値の倍率を取得
    ''' </summary>
    ''' <param name="p"地図ファイル座標></param>
    ''' <param name="MPDataMapZahyo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Scale_Baititu_IdoKedo(ByVal p As PointF, ByRef MPDataMapZahyo As clsMapData.Zahyo_info) As Single

        Dim v As Single
        Select Case MPDataMapZahyo.Mode
            Case enmZahyo_mode_info.Zahyo_Ido_Keido
                Select Case MPDataMapZahyo.Projection
                    Case enmProjection_Info.prjSanson
                        'サンソン
                        v = 1
                    Case enmProjection_Info.prjMollweide, enmProjection_Info.prjEckert4
                        Dim newP As PointF = Get_Reverse_XY(p, MPDataMapZahyo)
                        Dim PA1 As PointF = Get_Converted_XY(New Point(0, 0), MPDataMapZahyo)
                        Dim PA2 As PointF = Get_Converted_XY(New Point(180, 0), MPDataMapZahyo)
                        Dim PB1 As PointF = Get_Converted_XY(New Point(0, newP.Y), MPDataMapZahyo)
                        Dim PB2 As PointF = Get_Converted_XY(New Point(180, newP.Y), MPDataMapZahyo)
                        Dim chk As Single = (Math.PI * EarthR) / (PA2.X - PA1.X)
                        Dim v2 = (PA2.X - PA1.X) / (PB2.X - PB1.X)
                        v = v2 / chk
                    Case enmProjection_Info.prjSeikyoEntou, enmProjection_Info.prjMercator, enmProjection_Info.prjMiller, enmProjection_Info.prjLambertSeisekiEntou
                        '正距円筒
                        'メルカトル
                        'ミラー／ランベルト正積円筒
                        Dim newP As PointF = Get_Reverse_XY(p, MPDataMapZahyo)
                        Dim Ido As Single = clsGeneric.m_min_max(newP.Y, CSng(-89.9), CSng(89.9))
                        v = 1 / Math.Cos(Ido * Math.PI / 180)
                End Select
            Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                v = 1
            Case enmZahyo_mode_info.Zahyo_No_Mode
                v = 1
        End Select
        Return v
    End Function
    ''' <summary>
    ''' '指定した緯度での、指定した距離(km)あたりの緯度経度の度を求める
    ''' </summary>
    ''' <param name="Dis"></param>
    ''' <param name="CenterIdo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Ido_Kedo_Rage_by_Distance(ByVal Dis As Single, ByVal CenterIdo As Single) As strLatLon

        Dim R_ido As Single = (CSng(360) * CSng(3600)) / (2 * Math.PI * EarthR) * Dis / 3600
        Dim R_kedo As Single = (CSng(180) * CSng(3600)) / (Math.PI * EarthR * Math.Cos(CenterIdo * Math.PI / 180)) * Dis / 3600
        Return New strLatLon(R_ido, R_kedo)
    End Function
    ''' <summary>
    ''' 世界測地系の緯度経度の座標に変換して返す
    ''' </summary>
    ''' <param name="oxy">緯度経度のpointf(x:経度、y:緯度)または平面直角XY(x:Y,y:X)</param>
    ''' <param name="Map_Info"></param>
    ''' <remarks></remarks>
    Public Shared Function Get_World_IdoKedo(ByVal oxy As PointF, ByRef MapZahyo_Info As clsMapData.Zahyo_info) As strLatLon
        '

        Dim x2 As Double, y2 As Double
        Dim Ellip12 As Integer, Kei As Integer
        Dim LatLon As strLatLon

        If MapZahyo_Info.Mode = enmZahyo_mode_info.Zahyo_HeimenTyokkaku Then
            '平面直角座標系の場合は緯度経度に変換
            If MapZahyo_Info.System = enmZahyo_System_Info.Zahyo_System_tokyo Then
                Ellip12 = 1
            ElseIf MapZahyo_Info.System = enmZahyo_System_Info.Zahyo_System_World Then
                Ellip12 = 2
            End If
            Kei = MapZahyo_Info.HeimenTyokkaku_KEI_Number
            Call doCalcXy2bl(Ellip12, Kei, oxy.Y, oxy.X, y2, x2)
            LatLon.Longitude = CSng(x2)
            LatLon.Latitude = CSng(y2)
        Else
            LatLon.Latitude = oxy.Y
            LatLon.Longitude = oxy.X
        End If

        If MapZahyo_Info.System = enmZahyo_System_Info.Zahyo_System_tokyo Then
            '日本測地系の場合は世界測地系に変換
            Call Tokyo97toITRF94(LatLon.Latitude, LatLon.Longitude, y2, x2)
            LatLon.Longitude = CSng(x2)
            LatLon.Latitude = CSng(y2)
        End If
        Return LatLon
    End Function
    ''' <summary>
    ''' 世界測地系の緯度経度の座標を、地図ファイルの測地系が日本測地系だった場合、日本測地系の緯度経度に変換、平面直角座標系の場合は変換不可
    ''' </summary>
    ''' <param name="oLatLon">世界測地系の緯度経度</param>
    ''' <param name="Map_Info"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_ReverseWorld_IdoKedo(ByVal oLatLon As strLatLon, ByRef MapZahyo As clsMapData.Zahyo_info) As strLatLon

        If MapZahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
            MsgBox("平面直角は不可", vbExclamation)
        End If
        If MapZahyo.System = enmZahyo_System_Info.Zahyo_System_tokyo Then
            '日本測地系の場合は変換
            Dim x2 As Double, y2 As Double
            Call ITRF94toTokyo97(oLatLon.Latitude, oLatLon.Longitude, y2, x2)
            Dim retP As strLatLon
            retP.Longitude = CSng(x2)
            retP.Latitude = CSng(y2)
            Return retP
        Else
            Return oLatLon
        End If
    End Function




    Public Shared Function Get_Polygon_Direction(ByVal Point_Num As Integer, ByVal pxy() As PointF) As Integer
        'ポリゴンのポイントの並び順を返す
        '1:時計回り -1反時計回り

        Dim minp As Integer, Miny_p As PointF
        Dim Next_p As Integer, Before_P As Integer
        Dim Next_VEC As PointF, Before_VEC As PointF
        Dim Next_D As Single, Before_D As Single
        Dim Next_Sin As Single, Next_Cos As Single
        Dim Before_Sin As Single, Before_Cos As Single
        Dim Next_Angle As Single, Before_Angle As Single

        'yが最小の地点を求める
        minp = 0
        Miny_p = pxy(0)
        For i As Integer = 1 To Point_Num - 1
            If Miny_p.Y > pxy(i).Y Then
                Miny_p = pxy(i)
                minp = i
            End If
        Next

        '次の地点
        Next_p = minp
        Do
            Next_p += 1
            If Next_p = Point_Num Then
                Next_p = 0
            End If
            If Next_p = minp Then
                '一周した場合はすべての座標が同じ点。時計回りで返す
                Return 1
            End If
        Loop While pxy(Next_p).Equals(pxy(minp)) = True

        '前の地点
        Before_P = minp
        Do
            Before_P -= 1
            If Before_P = -1 Then
                Before_P = Point_Num - 1
            End If
        Loop While pxy(Before_P).Equals(pxy(minp)) = True

        '前後の地点との角度を計算して回転方向を求める
        With Next_VEC
            .X = pxy(Next_p).X - pxy(minp).X
            .Y = pxy(Next_p).Y - pxy(minp).Y
            Next_D = Math.Sqrt(.X ^ 2 + .Y ^ 2)
            Next_Sin = .Y / Next_D
            Next_Cos = .X / Next_D
            Next_Angle = clsGeneric.Angle(Next_Sin, Next_Cos)
        End With
        With Before_VEC
            .X = pxy(Before_P).X - pxy(minp).X
            .Y = pxy(Before_P).Y - pxy(minp).Y
            Before_D = Math.Sqrt(.X ^ 2 + .Y ^ 2)
            Before_Sin = .Y / Next_D
            Before_Cos = .X / Next_D
            Before_Angle = clsGeneric.Angle(Before_Sin, Before_Cos)
        End With
        If Before_Angle > Next_Angle Then
            Return 1
        Else
            Return -1
        End If

    End Function

    ''' <summary>
    ''' 単一ポリゴン内に指定の地点が含まれる場合trueを返す
    ''' </summary>
    ''' <param name="checkPoint">地点</param>
    ''' <param name="PolyLine">ポリゴンを構成するPointF構造体配列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function check_Point_in_Polygon(ByVal checkPoint As PointF, ByRef LinePoints() As PointF,
                                                  Optional ByRef CrossPointN As Integer = 0, Optional ByRef CrossPoint_X() As Single = Nothing) As Boolean

        Dim LineArray As New List(Of PointF())
        LineArray.Add(LinePoints)
        Return check_Point_in_Polygon(checkPoint, LineArray, CrossPointN, CrossPoint_X)
    End Function
    ''' <summary>
    ''' ポリゴン内に指定の地点が含まれる場合trueを返す
    ''' </summary>
    ''' <param name="checkPoint">地点</param>
    ''' <param name="PolyLine">ポリゴンを構成するPointF構造体配列のArrayList</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function check_Point_in_Polygon(ByVal checkPoint As PointF, ByRef PolyLine As List(Of PointF()), _
                                                  Optional ByRef CrossPointN As Integer = 0, Optional ByRef CrossPoint_X() As Single = Nothing) As Boolean

        ReDim CrossPoint_X(0)
        CrossPointN = 0

        For Each LinePoints In PolyLine
            For i As Integer = 0 To LinePoints.GetUpperBound(0) - 1
                Dim cx As Single
                If Get_CrossXPoint(checkPoint, LinePoints(i), LinePoints(i + 1), cx) = True Then
                    ReDim Preserve CrossPoint_X(CrossPointN)
                    CrossPoint_X(CrossPointN) = cx
                    CrossPointN += 1
                End If
            Next
        Next


        '調査地点のX座標が交点の偶数番目の後に来る場合はtrue
        Array.Sort(CrossPoint_X)
        For j As Integer = 0 To CrossPointN - 2 Step 2
            If CrossPoint_X(j) <= checkPoint.X And checkPoint.X <= CrossPoint_X(j + 1) Then
                Return True
            End If
        Next
        Return False
    End Function
    ''' <summary>
    ''' 水平線アルゴリズムで、線分と調査地点の座標との水平線上のX座標を求める。Y範囲がずれていた場合はfalse
    ''' </summary>
    ''' <param name="checkPoint"></param>
    ''' <param name="LinePoint1"></param>
    ''' <param name="LinePoint2"></param>
    ''' <param name="CrossX">交点のX座標（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Get_CrossXPoint(ByVal checkPoint As PointF, ByVal LinePoint1 As PointF, ByVal LinePoint2 As PointF, ByRef CrossX As Single) As Boolean
        Dim x As Single = checkPoint.X
        Dim y As Single = checkPoint.Y
        Dim ay As Single = LinePoint1.Y
        Dim by As Single = LinePoint2.Y
        If (ay <= y And y < by) Or (by <= y And y < ay) Then
            Dim BX As Single = LinePoint2.X
            Dim ax As Single = LinePoint1.X
            If ay = by Then
                CrossX = ax
            Else
                CrossX = (ax - BX) / (ay - by) * (y - ay) + ax
            End If
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' メッシュコードから投影変換した四角形を返す
    ''' </summary>
    ''' <param name="Meshcode"></param>
    ''' <param name="MeshType"></param>
    ''' <param name="refOrigin"></param>
    ''' <param name="refDestZahyo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub Get_MeshCode_Rectangle(ByVal Meshcode As String, ByVal MeshType As enmMesh_Number, ByRef refOrigin As enmZahyo_System_Info, ByRef refDestZahyo As clsMapData.Zahyo_info,
            ByRef latlonBox As strLatLonBox, ByRef convRect As RectangleF, ByRef RPoint() As PointF)
        Dim RectLatLon As strLatLonBox = spatial.Get_Ido_Kedo_from_MeshCode(Meshcode, MeshType)
        RectLatLon.NorthWest = spatial.ConvertRefSystemLatLon(RectLatLon.NorthWest, refOrigin, refDestZahyo.System)
        RectLatLon.SouthEast = spatial.ConvertRefSystemLatLon(RectLatLon.SouthEast, refOrigin, refDestZahyo.System)
        Dim P(3) As PointF
        P(0) = spatial.Get_Converted_XY(RectLatLon.NorthWest.toPointF, refDestZahyo)
        P(1) = spatial.Get_Converted_XY(RectLatLon.NorthEast.toPointF, refDestZahyo)
        P(2) = spatial.Get_Converted_XY(RectLatLon.SouthEast.toPointF, refDestZahyo)
        P(3) = spatial.Get_Converted_XY(RectLatLon.SouthWest.toPointF, refDestZahyo)
        convRect = spatial.Get_Circumscribed_Rectangle(P, 0, 4)
        latlonBox = RectLatLon
        RPoint = P
    End Sub
    ''' <summary>
    ''' 2つのメッシュコード間の差を求める
    ''' </summary>
    ''' <param name="NorthWestMeshCode">北西メッシュ</param>
    ''' <param name="SouthEastMeshCode">南東メッシュ</param>
    ''' <param name="MeshNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_MeshCode_Size_fromTwoMesh(ByVal NorthWestMeshCode As Integer, ByVal SouthEastMeshCode As Integer, ByVal MeshNumber As enmMesh_Number) As Size
        Dim xs As Integer
        Dim ys As Integer

        Dim MeshCodeNW As String = Microsoft.VisualBasic.Left(CStr(NorthWestMeshCode) & "0000000000", 8)
        Dim id1NW As Integer = Val(Mid(MeshCodeNW, 1, 2))
        Dim id2NW As Integer = Val(Mid(MeshCodeNW, 5, 1))
        Dim id3NW As Integer = Val(Mid(MeshCodeNW, 7, 1))
        Dim kd1NW As Integer = Val(Mid(MeshCodeNW, 3, 2))
        Dim kd2NW As Integer = Val(Mid(MeshCodeNW, 6, 1))
        Dim kd3NW As Integer = Val(Mid(MeshCodeNW, 8, 1))
        Dim MeshCodeSE As String = Microsoft.VisualBasic.Left(CStr(SouthEastMeshCode) & "0000000000", 8)
        Dim id1SE As Integer = Val(Mid(MeshCodeSE, 1, 2))
        Dim id2SE As Integer = Val(Mid(MeshCodeSE, 5, 1))
        Dim id3SE As Integer = Val(Mid(MeshCodeSE, 7, 1))
        Dim kd1SE As Integer = Val(Mid(MeshCodeSE, 3, 2))
        Dim kd2SE As Integer = Val(Mid(MeshCodeSE, 6, 1))
        Dim kd3SE As Integer = Val(Mid(MeshCodeSE, 8, 1))

        Select Case MeshNumber
            Case enmMesh_Number.mhFirst
                ys = id1NW - id1SE + 1
                xs = kd1SE - kd1NW + 1
            Case enmMesh_Number.mhSecond
                ys = (id1NW * 8 + id2NW) - (id1SE * 8 + id2SE) + 1
                xs = (kd1SE * 8 + kd2SE) - (kd1NW * 8 + kd2NW) + 1
            Case enmMesh_Number.mhThird
                ys = (id1NW * 8 * 10 + id2NW * 10 + id3NW) - (id1SE * 8 * 10 + id2SE * 10 + id3SE) + 1
                xs = (kd1SE * 8 * 10 + kd2SE * 10 + kd3SE) - (kd1NW * 8 * 10 + kd2NW * 10 + kd3NW) + 1
        End Select
        Return New Size(xs, ys)
    End Function
    ''' <summary>
    ''' メッシュコードを指定した値移動したメッシュコードを取得
    ''' </summary>
    ''' <param name="BaseCode">元のメッシュコード</param>
    ''' <param name="Xplus">経度方向の増減</param>
    ''' <param name="YPlus">緯度方向の増減</param>
    ''' <param name="MeshNumber">メッシュの種類</param>
    ''' <returns>メッシュコード</returns>
    ''' <remarks></remarks>
    Public Shared Function Get_MeshCodeOffset(ByVal BaseCode As Integer, ByVal Xplus As Integer,
                                              ByVal YPlus As Integer, ByVal MeshNumber As enmMesh_Number) As Integer
        Dim MeshCodeNW As String = Microsoft.VisualBasic.Left(CStr(BaseCode) & "0000000000", 8)
        Dim id1 As Integer = Val(Mid(MeshCodeNW, 1, 2))
        Dim id2 As Integer = Val(Mid(MeshCodeNW, 5, 1))
        Dim id3 As Integer = Val(Mid(MeshCodeNW, 7, 1))
        Dim kd1 As Integer = Val(Mid(MeshCodeNW, 3, 2))
        Dim kd2 As Integer = Val(Mid(MeshCodeNW, 6, 1))
        Dim kd3 As Integer = Val(Mid(MeshCodeNW, 8, 1))

        Dim newcode As Integer
        Select Case MeshNumber
            Case enmMesh_Number.mhFirst
                Dim ys As Integer = id1 + YPlus
                Dim xs As Integer = kd1 + Xplus
                newcode = ys * 100 + xs
            Case enmMesh_Number.mhSecond
                Dim ys As Integer = id1 * 8 + id2 + YPlus
                Dim xs As Integer = kd1 * 8 + kd2 + Xplus
                newcode = (Int(ys / 8) * 10000 + Int(xs / 8) * 100) +
                             ((ys Mod 8) * 10 + (xs Mod 8))
            Case enmMesh_Number.mhThird
                Dim ys As Integer = id1 * 8 * 10 + id2 * 10 + id3 + YPlus
                Dim xs As Integer = kd1 * 8 * 10 + kd2 * 10 + kd3 + Xplus
                Dim ys2 As Integer = ys - Int(ys / 80) * 80
                Dim xs2 As Integer = xs - Int(xs / 80) * 80
                newcode = (Int(ys / 80) * 1000000 + Int(xs / 80) * 10000) +
                             (Int(ys2 / 10) * 1000 + Int(xs2 / 10) * 100) +
                             ((ys2 Mod 10) * 10 + (xs2 Mod 10))
        End Select
        Return newcode
    End Function


    ''' <summary>
    ''' 緯度経度からメッシュコード取得
    ''' </summary>
    ''' <param name="LatLon">緯度経度構造体</param>
    ''' <param name="MeshNumber">取得するメッシュコード</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_MeshCode_from_LatLon(ByVal LatLon As strLatLon, ByVal MeshNumber As enmMesh_Number) As String
        Dim lat1 As Integer = Int(LatLon.Latitude / (40 / 60))
        Dim lat2 As Integer = Int(LatLon.Latitude / (5 / 60)) Mod 8
        Dim lat3 As Integer = Int(LatLon.Latitude / (30 / 3600)) Mod 10

        Dim lon1 As Integer = Int(LatLon.Longitude)
        Dim lon2 As Integer = Int(LatLon.Longitude / (7.5 / 60)) Mod 8
        Dim lon3 As Integer = Int(LatLon.Longitude / (45 / 3600)) Mod 10

        Dim firstMeshCode As String = Right(CStr(lat1), 2) + Right(CStr(lon1), 2)
        Dim secondMeshCode As String = firstMeshCode + CStr(lat2) + CStr(lon2)
        Dim thirdMeshCode As String = secondMeshCode + CStr(lat3) + CStr(lon3)
        Select Case MeshNumber
            Case enmMesh_Number.mhFirst
                Return firstMeshCode
            Case enmMesh_Number.mhSecond
                Return secondMeshCode
            Case enmMesh_Number.mhThird
                Return thirdMeshCode
        End Select
    End Function
    ''' <summary>
    ''' メッシュコードからメッシュの四角形緯度経度を求める
    ''' </summary>
    ''' <param name="Mesh_Size">メッシュの種類</param>
    ''' <param name="MeshCode">メッシュコード</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Ido_Kedo_from_MeshCode(ByVal MeshCode As String, ByVal Mesh_Size As enmMesh_Number) As strLatLonBox
        '
        Dim id1 As Integer, id2 As Integer, id3 As Integer
        Dim kd1 As Integer, kd2 As Integer, kd3 As Integer
        Dim V2 As Integer, V4 As Integer, v8 As Integer
        Dim Ido As Single, kdo As Single

        MeshCode = Left(MeshCode & "0000000000", 11)
        id1 = Val(Mid(MeshCode, 1, 2))
        id2 = Val(Mid(MeshCode, 5, 1))
        id3 = Val(Mid(MeshCode, 7, 1))
        kd1 = Val(Mid(MeshCode, 3, 2))
        kd2 = Val(Mid(MeshCode, 6, 1))
        kd3 = Val(Mid(MeshCode, 8, 1))
        V2 = Val(Mid(MeshCode, 9, 1))
        V4 = Val(Mid(MeshCode, 10, 1))
        v8 = Val(Mid(MeshCode, 11, 1))
        Ido = id1 / 1.5 + (id2 / 8) * (40 / 60) + (id3 / 10) * (5 / 60)
        kdo = kd1 + 100 + (kd2 / 8) + (kd3 / 10) * (7.5 / 60)
        If Mesh_Size = enmMesh_Number.mhOne_Tenth Then
            Ido = Ido + V2 * (30 / 3600) / 10
            kdo = kdo + V4 * (45 / 3600) / 10
        Else
            If V2 = 3 Or V2 = 4 Then
                '1/2メッシュの北側
                Ido = Ido + (15 / 3600)
            End If
            If V2 = 2 Or V2 = 4 Then
                '1/2メッシュの東側
                kdo = kdo + (22.5 / 3600)
            End If
            If V4 = 3 Or V4 = 4 Then
                '1/4メッシュの北側
                Ido = Ido + (7.5 / 3600)
            End If
            If V4 = 2 Or V4 = 4 Then
                '1/4メッシュの東側
                kdo = kdo + (11.25 / 3600)
            End If
            If v8 = 3 Or v8 = 4 Then
                Ido = Ido + (3.75 / 3600)
            End If
            If v8 = 2 Or v8 = 4 Then
                kdo = kdo + (5.625 / 3600)
            End If
        End If

        Dim meshWH As SizeF = Get_MeshCode_Size_IdoKedo(Mesh_Size)

        Return New strLatLonBox(New strLatLon(Ido + meshWH.Height, kdo), New strLatLon(Ido, (kdo + meshWH.Width)))        '等高線取得の場合はこちら
        'Return New strLatLonBox(New strLatLon(CSng(CDec(Ido + meshWH.Height)), kdo), New strLatLon(Ido, CSng(CDec(kdo + meshWH.Width))))
    End Function
    ''' <summary>
    ''' メッシュの東西南北の幅を取得
    ''' </summary>
    ''' <param name="Mesh_Size"></param>
    ''' の幅（戻り値）</param>
    ''' <remarks></remarks>
    Public Shared Function Get_MeshCode_Size_IdoKedo(ByVal Mesh_Size As enmMesh_Number) As SizeF
        Dim Xplus As Double, YPlus As Double

        Select Case Mesh_Size
            Case enmMesh_Number.mhFirst
                Xplus = 450 * 8 / 3600
                YPlus = 300 * 8 / 3600
            Case enmMesh_Number.mhSecond
                Xplus = 450 / 3600
                YPlus = 300 / 3600
            Case enmMesh_Number.mhThird, enmMesh_Number.mhHalf, enmMesh_Number.mhQuarter, enmMesh_Number.mhOne_Eighth, enmMesh_Number.mhOne_Tenth
                Xplus = 45 / 3600
                YPlus = 30 / 3600
                Select Case Mesh_Size
                    Case enmMesh_Number.mhHalf
                        Xplus = Xplus / 2
                        YPlus = YPlus / 2
                    Case enmMesh_Number.mhQuarter
                        Xplus = Xplus / 4
                        YPlus = YPlus / 4
                    Case enmMesh_Number.mhOne_Eighth
                        Xplus = Xplus / 8
                        YPlus = YPlus / 8
                    Case enmMesh_Number.mhOne_Tenth
                        Xplus = Xplus / 10
                        YPlus = YPlus / 10
                End Select
        End Select
        Return (New SizeF(Xplus, YPlus))
    End Function
    ''' <summary>
    ''' 線分上にポイントが乗っているかどうかをチェックして乗っているとtrue
    ''' </summary>
    ''' <param name="checkPoint">調べるポイント</param>
    ''' <param name="LP1">線分の端点1</param>
    ''' <param name="LP2">線分の端点2</param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function Check_Point_on_Line(ByVal checkPoint As PointF, ByVal LP1 As PointF, ByVal LP2 As PointF) As Boolean
        '

        If (LP1.Equals(LP2) = True) Or (LP1.Equals(checkPoint) = True) Or (LP2.Equals(checkPoint) = True) Then
            Return False
            Exit Function
        End If
        If LP1.X = LP2.X Then
            If checkPoint.X = LP1.X And clsGeneric.Check_Two_Value_In(checkPoint.Y, LP1.Y, LP2.Y) <> chvValue_on_twoValue.chvOuter Then
                Return True
            End If
        Else
            If clsGeneric.Check_Two_Value_In(checkPoint.X, LP1.X, LP2.X) <> chvValue_on_twoValue.chvOuter Then
                Dim a As Single, pyd As Single
                a = (LP2.Y - LP1.Y) / (LP2.X - LP1.X)
                pyd = a * (checkPoint.X - LP1.X) + LP1.Y
                If Val(CStr(pyd)) = Val(CStr(checkPoint.Y)) Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function
    Public Overloads Shared Function Line_Cross_Point(ByRef CrossPoint As Point, ByVal LAP1 As Point, ByVal LAP2 As Point, ByVal LBP1 As Point, ByVal LBP2 As Point) As Boolean
        Dim CP2 As PointF
        Dim f As Boolean = Line_Cross_Point(CP2, LAP1, LAP2, LBP1, LBP2)
        If f = True Then
            CrossPoint.X = CInt(CP2.X)
            CrossPoint.Y = CInt(CP2.Y)
        End If
        Return f
    End Function

    ''' <summary>
    ''' 二つの線分の交点を求める関数。交点がある場合trueと座標
    ''' </summary>
    ''' <param name="CrossPoint">交点の座標(戻り値)</param>
    ''' <param name="LAP1">線分Aの端点1</param>
    ''' <param name="LAP2">線分Aの端点2</param>
    ''' <param name="LBP1">線分Bの端点1</param>
    ''' <param name="LBP2">線分Bの端点2</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Line_Cross_Point(ByRef CrossPoint As PointF, ByVal LAP1 As PointF, ByVal LAP2 As PointF, ByVal LBP1 As PointF, ByVal LBP2 As PointF) As Boolean
        '

        Dim ax1 As Single = LAP1.X
        Dim ay1 As Single = LAP1.Y
        Dim ax2 As Single = LAP2.X
        Dim ay2 As Single = LAP2.Y
        Dim bx1 As Single = LBP1.X
        Dim by1 As Single = LBP1.Y
        Dim bx2 As Single = LBP2.X
        Dim by2 As Single = LBP2.Y

        '２点が同一、または２線が平行の場合は戻る
        If (ax2 = ax1 And bx2 = bx1) Or (ay2 = ay1 And by2 = by1) Or _
            (ax1 = bx1 And ay1 = by1) Or (ax2 = bx1 And ay2 = by1) Or (ax1 = bx2 And ay1 = by2) Or (ax2 = bx2 And ay2 = by2) Then
            Return False
        End If

        If (ax2 = ax1) Or (bx2 = bx1) Then
            'どちらかがY軸に平行の場合
            If bx2 = bx1 Then
                'B線の場合はAB入れ替えてA線を平行に
                clsGeneric.SWAP(bx1, ax1)
                clsGeneric.SWAP(bx2, ax2)
                clsGeneric.SWAP(by1, ay1)
                clsGeneric.SWAP(by2, ay2)
            End If
            If clsGeneric.Check_Two_Value_In(ax1, bx1, bx2) = chvValue_on_twoValue.chvIN Then
                '交点のY座標を求める
                Dim BL As Single = (by2 - by1) / (bx2 - bx1)
                Dim bm As Single = by1 - BL * bx1
                Dim px As Single = ax1
                Dim py As Single = BL * px + bm
                If clsGeneric.Check_Two_Value_In(py, ay1, ay2) <> chvValue_on_twoValue.chvOuter And
                        clsGeneric.Check_Two_Value_In(py, by1, by2) <> chvValue_on_twoValue.chvOuter Then
                    'Y座標がAB線の内部だったら交差
                    CrossPoint.X = px
                    CrossPoint.Y = py
                    Return True
                End If
            End If
            Return False
        ElseIf (ay2 = ay1) Or (by2 = by1) Then
            'どちらかがX軸に平行の場合
            If by2 = by1 Then
                'B線の場合はAB入れ替えてA線を平行に
                clsGeneric.SWAP(bx1, ax1)
                clsGeneric.SWAP(bx2, ax2)
                clsGeneric.SWAP(by1, ay1)
                clsGeneric.SWAP(by2, ay2)
            End If
            If clsGeneric.Check_Two_Value_In(ay1, by1, by2) <> chvValue_on_twoValue.chvOuter Then
                '交点のX座標を求める
                Dim BL As Single = (by2 - by1) / (bx2 - bx1)
                Dim bm As Single = by1 - BL * bx1
                Dim py As Single = ay1
                Dim px As Single = (py - bm) / BL
                If clsGeneric.Check_Two_Value_In(px, ax1, ax2) <> chvValue_on_twoValue.chvOuter And
                        clsGeneric.Check_Two_Value_In(px, bx1, bx2) <> chvValue_on_twoValue.chvOuter Then
                    'X座標がAB線の内部だったら交差
                    CrossPoint.X = px
                    CrossPoint.Y = py
                    Return True
                End If
            End If
            Return False
        Else

            Dim AL As Single = (ay2 - ay1) / (ax2 - ax1)
            Dim BL As Single = (by2 - by1) / (bx2 - bx1)
            If AL = BL Then
                '傾きが等しいと交差しない
                Return False
            End If
            Dim AM As Single = ay1 - AL * ax1
            Dim bm As Single = by1 - BL * bx1
            Dim px As Single = (bm - AM) / (AL - BL)
            Dim py As Single = AL * px + AM
            If (ax1 = px And ay1 = py) Or (ax2 = px And ay2 = py) Or (bx1 = px And by1 = py) Or (bx2 = px And by2 = py) Then
            Else
                If clsGeneric.Check_Two_Value_In(px, ax1, ax2) <> chvValue_on_twoValue.chvOuter And clsGeneric.Check_Two_Value_In(py, ay1, ay2) <> chvValue_on_twoValue.chvOuter Then
                    If clsGeneric.Check_Two_Value_In(px, bx1, bx2) <> chvValue_on_twoValue.chvOuter And
                        clsGeneric.Check_Two_Value_In(py, by1, by2) <> chvValue_on_twoValue.chvOuter Then
                        '交点が２線の内部だったら交差
                        CrossPoint.X = px
                        CrossPoint.Y = py
                        Return True
                    End If
                End If
            End If
            Return False
        End If
    End Function
    ''' <summary>
    ''' 2つの折れ線の交点を求める(折れ線の外接四角形を求める)
    ''' </summary>
    ''' <param name="Line1">ライン1配列</param>
    ''' <param name="Line2">ライン2配列</param>
    ''' <param name="Line1PointNum">ライン1ポイント数</param>
    ''' <param name="Line2PointNum">ライン2ポイント数</param>
    ''' <param name="Line1Rect">ライン1外接四角形</param>
    ''' <param name="Line2Rect">ライン2外接四角形</param>
    ''' <param name="CrossPointNum1">ライン1交点数（戻り値）</param>
    ''' <param name="CrossPointNum2">ライン2交点数（戻り値）</param>
    ''' <param name="CrossData1">ライン1交点データ</param>
    ''' <param name="CrossData2">ライン2交点データ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_Two_Line_Cross(ByVal Line1() As PointF, ByVal Line2() As PointF,
                                                ByVal Line1PointNum As Integer, ByVal Line2PointNum As Integer,
                                               ByRef CrossPointNum1 As Integer, ByRef CrossPointNum2 As Integer, _
                                                ByRef CrossData1() As Cross_Line_Data, ByRef CrossData2() As Cross_Line_Data) As Boolean
        Dim Line1Rect As RectangleF = Get_Circumscribed_Rectangle(Line1, 0, Line1PointNum)
        Dim Line2Rect As RectangleF = Get_Circumscribed_Rectangle(Line2, 0, Line2PointNum)
        Return Check_Two_Line_Cross(Line1, Line2, Line1PointNum, Line2PointNum, Line1Rect, Line2Rect, CrossPointNum1, CrossPointNum2, CrossData1, CrossData2)
    End Function

    ''' <summary>
    ''' 2つの折れ線の交点を求める
    ''' </summary>
    ''' <param name="Line1">ライン1配列</param>
    ''' <param name="Line2">ライン2配列</param>
    ''' <param name="Line1PointNum">ライン1ポイント数</param>
    ''' <param name="Line2PointNum">ライン2ポイント数</param>
    ''' <param name="Line1Rect">ライン1外接四角形</param>
    ''' <param name="Line2Rect">ライン2外接四角形</param>
    ''' <param name="CrossPointNum1">ライン1交点数（戻り値）</param>
    ''' <param name="CrossPointNum2">ライン2交点数（戻り値）</param>
    ''' <param name="CrossData1">ライン1交点データ</param>
    ''' <param name="CrossData2">ライン2交点データ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_Two_Line_Cross(ByVal Line1() As PointF, ByVal Line2() As PointF,
                                                ByVal Line1PointNum As Integer, ByVal Line2PointNum As Integer,
                                                ByVal Line1Rect As RectangleF, ByVal Line2Rect As RectangleF,
                                               ByRef CrossPointNum1 As Integer, ByRef CrossPointNum2 As Integer, _
                                                ByRef CrossData1() As Cross_Line_Data, ByRef CrossData2() As Cross_Line_Data) As Boolean

        If Compare_Two_Rectangle_Position(Line1Rect, Line2Rect) = cstRectangle_Cross.cstOuter Then
            CrossPointNum1 = 0
            CrossPointNum2 = 0
            Return False
        End If

        Dim LP2PointIndex As New clsSpatialIndexSearch
        Dim LP2RectIndex As New clsSpatialIndexSearch
        Dim LP1RectIndex As New clsSpatialIndexSearch

        With Line1Rect
            LP1RectIndex.Init(SpatialPointType.SPIRect, False, .Left, .Top, .Right, .Bottom)
        End With
        For i As Integer = 0 To Line1PointNum - 2
            LP1RectIndex.AddRect(Line1(i), Line1(i + 1), i)
        Next
        LP1RectIndex.AddEnd()

        With Line2Rect
            LP2PointIndex.Init(SpatialPointType.SinglePoint, False, .Left, .Top, .Right, .Bottom)
            LP2RectIndex.Init(SpatialPointType.SPIRect, False, .Left, .Top, .Right, .Bottom)
        End With
        For i As Integer = 0 To Line2PointNum - 2
            LP2RectIndex.AddRect(Line2(i), Line2(i + 1), i)
        Next
        LP2RectIndex.AddEnd()
        LP2PointIndex.AddSinglePoint_Allay(Line2PointNum, Line2, 0)
        LP2PointIndex.AddEnd()

        ReDim CrossData1(10), CrossData2(10)
        Dim CP1 As Integer, CP2 As Integer
        Dim ccutf As Boolean, Ccut2f() As Byte, Check_F(,) As Byte 'Booleanだとメモリ不足になることが

        '中間点が一致して交差
        ReDim Ccut2f(Line2PointNum - 1)
        For i As Integer = 0 To Line1PointNum - 1
            Dim Objn() As Integer, Pnum() As Integer, Tags() As Integer
            Dim cvp As PointF = Line1(i)
            Dim SPN As Integer = LP2PointIndex.GetSamePointNumberAlley(cvp.X, cvp.Y, Objn, Pnum, Tags)
            If SPN > 0 Then
                If i <> 0 And i <> Line1PointNum - 1 Then
                    If UBound(CrossData1) < CP1 Then
                        ReDim Preserve CrossData1(CP1 + 10)
                    End If
                    With CrossData1(CP1)
                        .BeforPoint = i - 1
                        .Point = cvp
                    End With
                    CP1 += 1
                End If
                For j As Integer = 0 To SPN - 1
                    Dim k As Integer = Objn(j)
                    If k <> 0 And k <> Line2PointNum - 1 Then
                        If Ccut2f(k) = False Then
                            If UBound(CrossData2) < CP2 Then
                                ReDim Preserve CrossData2(CP2 + 10)
                            End If
                            With CrossData2(CP2)
                                .BeforPoint = k - 1
                                .Point = cvp
                            End With
                            Ccut2f(k) = True
                            CP2 += 1
                        End If
                    End If

                Next
            End If
        Next

        '線分上にポイント
        ReDim Check_F(Line1PointNum - 1, Line2PointNum - 1) '線分上でチェックした箇所は中間点を計算しないフラグ
        For i As Integer = 0 To Line1PointNum - 1
            Dim Objn() As Integer, Pnum() As Integer, Tags() As Integer
            Dim cvp As PointF = Line1(i)
            Dim SPN As Integer = LP2RectIndex.GetRectIn(cvp.X, cvp.Y, Objn, Tags)
            For j As Integer = 0 To SPN - 1
                Dim k As Integer = Objn(j)
                If Check_Point_on_Line(cvp, Line2(k), Line2(k + 1)) = True Then
                    If i <> 0 And i <> Line1PointNum - 1 Then
                        If UBound(CrossData1) < CP1 Then
                            ReDim Preserve CrossData1(CP1 + 10)
                        End If
                        With CrossData1(CP1)
                            .BeforPoint = i - 1
                            .Point = cvp
                        End With
                        CP1 += 1
                        Check_F(i - 1, k) = True
                    End If
                    Check_F(i, k) = True
                    If UBound(CrossData2) < CP2 Then
                        ReDim Preserve CrossData2(CP2 + 10)
                    End If
                    With CrossData2(CP2)
                        .BeforPoint = k
                        .Point = cvp
                    End With
                    CP2 += 1
                End If
            Next
        Next

        For i As Integer = 0 To Line2PointNum - 1
            Dim Objn() As Integer, Pnum() As Integer, Tags() As Integer
            Dim cvp As PointF = Line2(i)
            Dim SPN As Integer = LP1RectIndex.GetRectIn(cvp.X, cvp.Y, Objn, Tags)

            For j As Integer = 0 To SPN - 1
                Dim k As Integer = Objn(j)
                If Check_Point_on_Line(cvp, Line1(k), Line1(k + 1)) = True Then
                    If i <> 0 And i <> Line2PointNum - 1 Then
                        If UBound(CrossData2) < CP2 Then
                            ReDim Preserve CrossData2(CP2 + 10)
                        End If
                        With CrossData2(CP2)
                            .BeforPoint = i - 1
                            .Point = cvp
                        End With
                        CP2 = CP2 + 1
                        Check_F(k, i - 1) = True
                    End If
                    Check_F(k, i) = True
                    If UBound(CrossData1) < CP1 Then
                        ReDim Preserve CrossData1(CP1 + 10)
                    End If
                    With CrossData1(CP1)
                        .BeforPoint = k
                        .Point = cvp
                    End With
                    CP1 += 1
                End If
            Next
        Next


        '線分が交差
        For i As Integer = 0 To Line1PointNum - 2
            Dim Objn() As Integer, Pnum() As Integer, Tags() As Integer
            Dim SPN As Integer = LP2RectIndex.GetRectOverlap(Line1(i), Line1(i + 1), Objn, Tags)
            For j As Integer = 0 To SPN - 1
                Dim k As Integer = Objn(j)
                If Check_F(i, k) = False Then
                    Dim cp As PointF
                    Dim f As Boolean = Line_Cross_Point(cp, Line1(i), Line1(i + 1), Line2(k), Line2(k + 1))
                    If f = True Then
                        If (i = 0 And cp.X = Line1(i).X And cp.Y = Line1(i).Y) Or _
                            (i = Line1PointNum - 2 And cp.X = Line1(i + 1).X And cp.Y = Line1(i + 1).Y) Then
                        Else
                            If UBound(CrossData1) < CP1 Then
                                ReDim Preserve CrossData1(CP1 + 10)
                            End If
                            With CrossData1(CP1)
                                .BeforPoint = i
                                .Point = cp
                                CP1 += 1
                            End With
                            If UBound(CrossData2) < CP2 Then
                                ReDim Preserve CrossData2(CP2 + 10)
                            End If
                            With CrossData2(CP2)
                                .BeforPoint = k
                                .Point = cp
                                CP2 += 1
                            End With
                        End If
                    End If
                End If
            Next
        Next

        CrossPointNum1 = CP1
        CrossPointNum2 = CP2
        If CP1 = 0 And CP2 = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' 四角形構造体から5ポイントの座標に変換
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_PolyLine_from_Recatngle(ByVal Rect As Rectangle) As Point()
        Dim PolygonP(4) As Point
        PolygonP(0).X = Rect.Left
        PolygonP(0).Y = Rect.Top
        PolygonP(1).X = Rect.Right
        PolygonP(1).Y = Rect.Top
        PolygonP(2).X = Rect.Right
        PolygonP(2).Y = Rect.Bottom
        PolygonP(3).X = Rect.Left
        PolygonP(3).Y = Rect.Bottom
        PolygonP(4) = PolygonP(0)
        Return PolygonP
    End Function
    ''' <summary>
    ''' 四角形構造体から5ポイントの座標に変換
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_PolyLine_from_Recatngle(ByVal Rect As RectangleF) As PointF()
        Dim PolygonP(4) As PointF
        PolygonP(0).X = Rect.Left
        PolygonP(0).Y = Rect.Top
        PolygonP(1).X = Rect.Right
        PolygonP(1).Y = Rect.Top
        PolygonP(2).X = Rect.Right
        PolygonP(2).Y = Rect.Bottom
        PolygonP(3).X = Rect.Left
        PolygonP(3).Y = Rect.Bottom
        PolygonP(4) = PolygonP(0)
        Return PolygonP
    End Function

    ''' <summary>
    ''' 折れ線とポリゴンの位置関係を求める(ライン・ポリゴンの外接四角形が不明)
    ''' </summary>
    ''' <param name="LineP">折れ線の座標</param>
    ''' <param name="LinePNum">折れ線のポイント数</param>
    ''' <param name="PolygonP">ポリゴンの座標</param>
    ''' <param name="PointPNum">ポリゴンのポイント数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_Line_Relatiton_To_Polygon(ByVal LineP() As PointF, ByVal LinePNum As Integer,
                                                           ByVal PolygonP() As PointF, ByVal PointPNum As Integer) As cstLinePolygonRelationd
        Dim CrossPointNum1 As Integer
        Dim CrossPointNum2 As Integer
        Dim CrossData1() As Cross_Line_Data
        Dim CrossData2() As Cross_Line_Data
        Dim f As Boolean = Check_Two_Line_Cross(LineP, PolygonP, LinePNum, PointPNum, CrossPointNum1, CrossPointNum2, CrossData1, CrossData2)
        If f = True Then
            Return cstLinePolygonRelationd.cstCross
        Else
            If check_Point_in_Polygon(LineP(0), PolygonP) = True Then
                Return cstLinePolygonRelationd.cstInner
            Else
                Return cstLinePolygonRelationd.cstOuter
            End If
        End If
    End Function
    ''' <summary>
    ''' 折れ線とポリゴンの位置関係を求める(ライン・ポリゴンの外接四角形が既知)
    ''' </summary>
    ''' <param name="LineP">折れ線の座標</param>
    ''' <param name="LinePNum">折れ線のポイント数</param>
    ''' <param name="LineRect">折れ線の外接四角形</param>
    ''' <param name="PolygonRect">ポリゴンの外接四角形</param>
    ''' <param name="PolygonP">ポリゴンの座標</param>
    ''' <param name="PointPNum">ポリゴンのポイント数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_Line_Relatiton_To_Polygon(ByVal LineP() As PointF, ByVal LinePNum As Integer,
                                                           ByVal LineRect As RectangleF, ByVal PolygonRect As RectangleF,
                                                           ByVal PolygonP() As PointF, ByVal PointPNum As Integer) As cstLinePolygonRelationd
        Dim CrossPointNum1 As Integer
        Dim CrossPointNum2 As Integer
        Dim CrossData1() As Cross_Line_Data
        Dim CrossData2() As Cross_Line_Data
        Dim f As Boolean = Check_Two_Line_Cross(LineP, PolygonP, LinePNum, PointPNum, LineRect, PolygonRect,
                                                CrossPointNum1, CrossPointNum2, CrossData1, CrossData2)
        If f = True Then
            Return cstLinePolygonRelationd.cstCross
        Else
            If check_Point_in_Polygon(LineP(0), PolygonP) = True Then
                Return cstLinePolygonRelationd.cstInner
            Else
                Return cstLinePolygonRelationd.cstOuter
            End If
        End If
    End Function
    ''' <summary>
    ''' 円に近似した多角形の座標を返す
    ''' </summary>
    ''' <param name="CP">中心点</param>
    ''' <param name="r">半径</param>
    ''' <param name="RoundPointNum">円周ポイント数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_CirclePolygon(ByVal CP As PointF, ByVal r As Single, ByVal RoundPointNum As Integer) As PointF()
        Dim RLine(RoundPointNum - 1) As PointF

        For i As Integer = 0 To RoundPointNum - 2
            Dim v As Single = (i / (RoundPointNum - 1)) * 2 * Math.PI
            RLine(i).X = CP.X + r * Math.Cos(v)
            RLine(i).Y = CP.Y + r * Math.Sin(v)
        Next
        RLine(RoundPointNum - 1) = RLine(0)
        Return RLine
    End Function
    ''' <summary>
    ''' 指定したベクトルと垂直のベクトルを取得
    ''' </summary>
    ''' <param name="Vx">元のベクトルx</param>
    ''' <param name="Vy">元のベクトルy</param>
    ''' <param name="rVx">垂直のベクトルx</param>
    ''' <param name="rVy">垂直のベクトルx</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub Get_Suisen_Vec(ByVal Vx As Integer, ByVal Vy As Integer, ByRef rVx As Integer, ByRef rVy As Integer)
        rVx = -Vy
        rVy = Vx
    End Sub
    Public Overloads Shared Sub Get_Suisen_Vec(ByVal Vx As Single, ByVal Vy As Single, ByRef rVx As Single, ByRef rVy As Single)
        rVx = -Vy
        rVy = Vx
    End Sub
    ''' <summary>
    '''  ベクトルVecX,VecY方向に距離D離れた地点の座標を取得
    ''' </summary>
    ''' <param name="VecX"></param>
    ''' <param name="VecY"></param>
    ''' <param name="Dis"></param>
    ''' <param name="CenterFlag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Get_Vec_Point(ByVal VecX As Single, ByVal VecY As Single,
                                    ByVal Dis As Single, ByVal CenterFlag As Boolean) As PointF
        Dim D As Single
        Dim x2 As Single, y2 As Single

        If CenterFlag = True Then
            D = Dis / 2
        Else
            D = Dis
        End If

        If VecX = 0 Then
            x2 = 0
            y2 = D * Math.Sign(VecY)
        ElseIf VecY = 0 Then
            x2 = D * Math.Sign(VecX)
            y2 = 0
        Else
            x2 = (D * VecX) / Math.Sqrt(VecY ^ 2 + VecX ^ 2)
            y2 = x2 * VecY / VecX
        End If
        Return New PointF(x2, y2)
    End Function
    ''' <summary>
    ''' 四角形の中心点を求める
    ''' </summary>
    ''' <param name="RECT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Get_CenterPoint_of_Rect(RECT As RectangleF) As PointF
        Return New PointF((RECT.Left + RECT.Right) / 2, (RECT.Top + RECT.Bottom) / 2)
    End Function
    ''' <summary>
    ''' 四角形の中心点を求める
    ''' </summary>
    ''' <param name="RECT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Get_CenterPoint_of_Rect(RECT As Rectangle) As Point
        Return New Point((RECT.Left + RECT.Right) / 2, (RECT.Top + RECT.Bottom) / 2)
    End Function

    ''' <summary>
    ''' 扇形の座標を求める
    ''' </summary>
    ''' <param name="CP">中心</param>
    ''' <param name="r">半径</param>
    ''' <param name="start_p">開始(0-6.28)</param>
    ''' <param name="end_p">終了(0-6.28)</param>
    ''' <param name="CenterLineF">中心から線を延ばす場合true</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Fan_Coordinates(ByVal CP As Point, ByVal r As Integer,
                 ByVal start_p As Double, ByVal end_p As Double, ByVal CenterLineF As Boolean) As Point()

        Dim ST As Double = 1 / (r * 2 / 5)
        Dim dtn As Integer = Int((end_p - start_p) / ST + 10)
        Dim pxy(dtn - 1) As Point
        Dim cn As Integer = 0

        If (start_p = 0 And end_p = Math.PI * 2) Or CenterLineF = False Then
        Else
            pxy(0) = CP
            cn += 1
        End If

        If end_p - start_p < ST Then
            pxy(cn).X = r * Math.Sin(start_p) + CP.X
            pxy(cn).Y = -r * Math.Cos(start_p) + CP.Y
            cn += 1
        Else
            For i As Single = start_p To end_p - ST Step ST
                pxy(cn).X = r * Math.Sin(i) + CP.X
                pxy(cn).Y = -r * Math.Cos(i) + CP.Y
                cn += 1
            Next
        End If
        pxy(cn).X = r * Math.Sin(end_p) + CP.X
        pxy(cn).Y = -r * Math.Cos(end_p) + CP.Y
        cn += 1

        If (start_p = 0 And end_p = Math.PI * 2) Or CenterLineF = False Then
        Else
            pxy(cn) = CP
            cn += 1
        End If
        ReDim Preserve pxy(cn - 1)
        Return pxy
    End Function

End Class