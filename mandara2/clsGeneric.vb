Public Enum enmHelpFile
    About
    Index
    MapEditor
    OutputWindow
    PropertyData
    SettingWindow
    SubWindow
End Enum
''' <summary>
''' 座標を文字列で保持する構造体
''' </summary>
''' <remarks></remarks>
Public Structure strPointStrings
    Public x As String
    Public y As String
End Structure

''' <summary>
''' 緯度経度ボックス構造体
''' </summary>
''' <remarks></remarks>
Public Structure strLatLonBox
    Public NorthWest As strLatLon
    Public SouthEast As strLatLon
    Public Function toRectangleF() As RectangleF
        Dim rec As RectangleF = RectangleF.FromLTRB(Me.NorthWest.Longitude, Me.SouthEast.Latitude, Me.SouthEast.Longitude, Me.NorthWest.Latitude)
        Return rec
    End Function
    Public Sub Offset(ByVal LonOffset As Single, ByVal LatOffset As Single)
        Me.NorthWest.Longitude += LonOffset
        Me.SouthEast.Longitude += LonOffset
        Me.NorthWest.Latitude += LatOffset
        Me.SouthEast.Latitude += LatOffset
    End Sub
    Public Sub New(ByVal _NorthWest As strLatLon, ByVal _SouthEast As strLatLon)
        Me.NorthWest = _NorthWest
        Me.SouthEast = _SouthEast
    End Sub
    Public Sub New(ByVal Rect As RectangleF)
        Me.NorthWest.Longitude = Rect.Left
        Me.NorthWest.Latitude = Rect.Bottom
        Me.SouthEast.Longitude = Rect.Right
        Me.SouthEast.Latitude = Rect.Top
    End Sub
    ''' <summary>
    ''' 中心の緯度経度を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CenterPoint() As strLatLon
        Get
            Return New strLatLon((Me.SouthEast.Latitude + Me.NorthWest.Latitude) / 2,
                (Me.SouthEast.Longitude + Me.NorthWest.Longitude) / 2)

        End Get
    End Property
    Public ReadOnly Property Width()
        Get
            Return (Me.SouthEast.Longitude - Me.NorthWest.Longitude)
        End Get
    End Property
    Public ReadOnly Property Height()
        Get
            Return Math.Abs(Me.SouthEast.Latitude - Me.NorthWest.Latitude)
        End Get
    End Property
    Public ReadOnly Property NorthEast As strLatLon
        Get
            Return New strLatLon(Me.NorthWest.Latitude, Me.SouthEast.Longitude)
        End Get
    End Property
    Public ReadOnly Property SouthWest As strLatLon
        Get
            Return New strLatLon(Me.SouthEast.Latitude, Me.NorthWest.Longitude)
        End Get
    End Property
End Structure

''' <summary>
''' 度分秒構造体
''' </summary>
''' <remarks></remarks>
Public Structure strDegreeMinuteSeconde
    ''' <summary>
    ''' 東経、北緯の場合Degreeは+、西経/南緯の場合Degreeは-
    ''' </summary>
    ''' <remarks></remarks>
    Public Degree As Integer
    Public Minute As Integer
    Public Second As Single
End Structure
''' <summary>
''' 度風秒緯度経度構造体
''' </summary>
''' <remarks></remarks>
Public Structure strLatLonDegreeMinuteSecond
    Public LatitudeDMS As strDegreeMinuteSeconde
    Public LongitudeDMS As strDegreeMinuteSeconde
End Structure

''' <summary>
''' 緯度経度構造体
''' </summary>
''' <remarks></remarks>
Public Structure strLatLon
    Public Latitude As Single
    Public Longitude As Single
    Public Sub New(ByVal _latitude As Single, ByVal _Longitude As Single)
        Me.Latitude = _latitude
        Me.Longitude = _Longitude
    End Sub
    Public Sub New(ByVal LatLonDMS As strLatLonDegreeMinuteSecond)
        fromDegreeMinuteSecond(LatLonDMS)
    End Sub
    Public Sub New(ByVal Point As PointF)
        Me.Latitude = Point.Y
        Me.Longitude = Point.X
    End Sub

    ''' <summary>
    ''' 度分秒から取得
    ''' </summary>
    ''' <param name="LatLonDMS"></param>
    ''' <remarks></remarks>
    Public Sub fromDegreeMinuteSecond(ByVal LatLonDMS As strLatLonDegreeMinuteSecond)
        With LatLonDMS
            With .LatitudeDMS
                Me.Latitude = Math.Abs(.Degree) + .Minute / 60 + .Second / 3600
                If .Degree < 0 Then
                    Me.Latitude = -Me.Latitude
                End If
            End With
            With .LongitudeDMS
                Me.Longitude = Math.Abs(.Degree) + .Minute / 60 + .Second / 3600
                If .Degree < 0 Then
                    Me.Longitude = -Me.Longitude
                End If
            End With
        End With
    End Sub
    ''' <summary>
    ''' 度分秒で返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function toDegreeMinuteSecond() As strLatLonDegreeMinuteSecond
        Dim s As strLatLonDegreeMinuteSecond
        s.LatitudeDMS = toDegreeMinuteSecond_sub(Me.Latitude)
        s.LongitudeDMS = toDegreeMinuteSecond_sub(Me.Longitude)
        Return s
    End Function
    Private Function toDegreeMinuteSecond_sub(ByVal V As Single) As strDegreeMinuteSeconde
        Dim s As strDegreeMinuteSeconde
        s.Degree = Int(V)
        Dim v2 As Single = (CDec(Math.Abs(V)) - s.Degree) * 60
        s.Minute = Int(v2)
        s.Second = (CDec(Math.Abs(v2)) - s.Minute) * 60
        Return s
    End Function
    ''' <summary>
    ''' PointFで返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function toPointF() As PointF
        Dim p As PointF
        p.X = Me.Longitude
        p.Y = Me.Latitude
        Return p
    End Function
End Structure

Public Structure strDecimalPointNumber
    Public Left_Of_Decimal_Point As Integer
    Public Right_Of_Decimal_Point As Integer
End Structure

Public Structure colorARGB
    '色情報を記憶する構造体
    Public a As Byte
    Public r As Byte
    Public g As Byte
    Public b As Byte
    Public Sub New(ByVal a As Byte, ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
        Me.a = a
        Me.r = r
        Me.g = g
        Me.b = b
    End Sub
    ''' <summary>
    ''' 32ビット値からセット
    ''' </summary>
    ''' <param name="colorValue"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal colorValue As Integer)

        setColor(colorValue)
    End Sub
    Public Sub New(ByVal alphaValue As Byte, ByVal RGBcolorValue As Integer)
        'RGBとアルファ値を別々に追加
        Dim c As Color = Color.FromArgb(RGBcolorValue)
        Me.a = alphaValue
        Me.r = c.R
        Me.g = c.G
        Me.b = c.B
    End Sub

    Public Sub New(ByVal col As Color)
        'color構造体からセット
        Me.a = col.A
        Me.r = col.R
        Me.g = col.G
        Me.b = col.B
    End Sub
    ''' <summary>
    ''' color構造体からデータセット
    ''' </summary>
    ''' <param name="col"></param>
    ''' <remarks></remarks>
    Public Overloads Sub setColor(ByVal col As Color)
        '
        Me.a = col.A
        Me.r = col.R
        Me.g = col.G
        Me.b = col.B
    End Sub
    ''' <summary>
    ''' 32ビットcolorからデータセット
    ''' </summary>
    ''' <param name="colorValue"></param>
    ''' <remarks></remarks>
    Public Overloads Sub setColor(ByVal colorValue As Integer)
        '
        Dim c As Color = Color.FromArgb(colorValue)
        Me.a = c.A
        Me.r = c.R
        Me.g = c.G
        Me.b = c.B
    End Sub
    ''' <summary>
    ''' Color 構造体にして返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getColor() As Color
        Return Color.FromArgb(Me.a, Me.r, Me.g, Me.b)
    End Function
End Structure

''' <summary>
''' インすトールされているフォント
''' </summary>
''' <remarks></remarks>
Public Class clsFontList_inPC
    Public Shared FontFamilyList() As FontFamily
    Shared Sub New()
        'InstalledFontCollectionオブジェクトの取得
        Dim ifc As New System.Drawing.Text.InstalledFontCollection
        'インストールされているすべてのフォントファミリアを取得
        FontFamilyList = ifc.Families
    End Sub
    ''' <summary>
    ''' 指定したフォントが存在するか
    ''' </summary>
    ''' <param name="FontName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function checkFontExist(ByVal FontName As String) As Boolean
        For i As Integer = 0 To FontFamilyList.GetLength(0) - 1
            If FontName = FontFamilyList(i).Name Then
                Return True
            End If
        Next
        Return False
    End Function
End Class
''' <summary>
''' エンコード可能な文字コードをコンボボックス設定用
''' </summary>
''' <remarks></remarks>
Public Class clsEncodings

    Private data As System.Text.EncodingInfo

    'コンストラクタ
    Public Sub New(ByVal eis As System.Text.EncodingInfo)
        data = eis
    End Sub

    '実際の値
    Public ReadOnly Property eis As System.Text.EncodingInfo
        Get
            Return data
        End Get
    End Property


    'オーバーライドしたメソッド
    'これがコンボボックスに表示される
    Public Overrides Function ToString() As String
        Return data.DisplayName
    End Function

End Class






''' <summary>
''' 線のプロパティ（汎用）配列は使用していないので直接代入可能--------------
''' </summary>
''' <remarks></remarks>
Public Structure Line_Property  '線種
    Public BasicLine As Line_Basic_Data_Info
    Public CrossLine As Cross_Line_Data_Info
    Public ParallelLine As Parallel_Line_Data_info
    Public Edge_Connect_Pattern As LineEdge_Connect_Pattern_Data_Info
    ''' <summary>
    ''' 線種が，画面に表示されるパターンの場合trueを返す
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Check_Line_PrintPattern
        Get
            With Me
                If .BasicLine.pattern <> -1 Or .CrossLine.XLine_f = True Or _
                        (.ParallelLine.P_Line_f = True And .ParallelLine.InnerColor_f = True) Then
                    Return True
                Else
                    Return False
                End If
            End With
        End Get
    End Property
    ''' <summary>
    ''' ラインの一番太い箇所の幅を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Max_LineWidth() As Single

        Dim w As Single = 0
        With Me
            With .BasicLine
                If .pattern = 0 Then
                    w = .SolidLine.Width
                Else
                    For i As Integer = 0 To 5
                        With .Get_CenterLineParts(i)
                            If .Use_F = True And .Print_f = True Then
                                w = Math.Max(w, .Width)
                            End If
                        End With
                    Next
                End If
            End With
            With .ParallelLine
                If .P_Line_f = True Then
                    w += .Interval
                End If
            End With
            With .CrossLine
                If .XLine_f = True Then
                    For i As Integer = 0 To 5
                        With .Get_CrossLineParts(i)
                            If .Use_F = True Then
                                w = Math.Max(w, .Length)
                            End If
                        End With
                    Next
                End If
            End With
        End With
        Return w

    End Function
    ''' <summary>
    ''' ラインパターンの各所に同じ色と幅を設定
    ''' </summary>
    ''' <param name="col"></param>
    ''' <param name="Width"></param>
    ''' <remarks></remarks>
    Public Sub Set_Same_ColorWidth_to_LinePat(ByVal col As colorARGB, ByVal Width As Single)
        Set_Same_Color_to_LinePat(col)
        Set_Same_Width_to_LinePat(Width)
    End Sub
    ''' <summary>
    ''' ラインパターンの各所に同じ色を設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Set_Same_Color_to_LinePat(ByVal col As colorARGB)
        With Me
            .BasicLine.SolidLine.Color = col
            .ParallelLine.P_CenterLine.SolidLine.Color = col
            For i As Integer = 0 To 5
                Dim BCLine As OptionalLine_Data_info = .BasicLine.Get_CenterLineParts(i)
                Dim CRLine As Optional_X_Line_Data_info = .CrossLine.Get_CrossLineParts(i)
                Dim PRLine As OptionalLine_Data_info = .ParallelLine.P_CenterLine.Get_CenterLineParts(i)
                BCLine.Color = col
                CRLine.Color = col
                PRLine.Color = col
                .BasicLine.Set_CenterLineParts(i, BCLine)
                .CrossLine.Set_CrossLineParts(i, CRLine)
                .ParallelLine.P_CenterLine.Set_CenterLineParts(i, PRLine)
            Next
        End With
    End Sub
    ''' <summary>
    ''' ラインパターンの各所に同じ幅を設定
    ''' </summary>
    ''' <param name="Width"></param>
    ''' <remarks></remarks>
    Public Sub Set_Same_Width_to_LinePat(ByVal Width As Single)
        With Me
            .BasicLine.SolidLine.Width = Width
            For i As Integer = 0 To 5
                Dim BCLine As OptionalLine_Data_info = .BasicLine.Get_CenterLineParts(i)
                Dim CRLine As Optional_X_Line_Data_info = .CrossLine.Get_CrossLineParts(i)
                Dim PRLine As OptionalLine_Data_info = .ParallelLine.P_CenterLine.Get_CenterLineParts(i)
                BCLine.Width = Width
                CRLine.Width = Width
                PRLine.Width = Width
                .BasicLine.Set_CenterLineParts(i, BCLine)
                .CrossLine.Set_CrossLineParts(i, CRLine)
                .ParallelLine.P_CenterLine.Set_CenterLineParts(i, PRLine)
            Next
        End With
    End Sub
End Structure
Public Structure OptionalLine_Data_info  '破線のパターン
    Public Use_F As Boolean
    Public Print_f As Boolean
    Public Length As Single
    Public Width As Single
    Public Color As colorARGB
End Structure

Public Structure Tile_Mark_Property 'ハッチ内部や線種内の記号
    Public PrintMark As enmMarkPrintType
    Public ShapeNumber As Short
    Public wordmark As String
    Public WordFontName As String
    Public PictureNumber As Integer
    Public Kakudo As Single
    Public Mark_Line_Color As colorARGB
End Structure


Public Structure Optional_X_Line_Data_info  '交差線のパターン
    Public Use_F As Boolean
    Public pattern As enmLineCrossPattern
    Public Length As Single
    Public Width As Single
    Public Color As colorARGB
    Public Interval As Single
    Public TileMark As Tile_Mark_Property
End Structure


Public Structure SolidLine_Data_Info
    Public Color As colorARGB
    Public Width As Single
End Structure

Public Structure Line_Basic_Data_Info
    Public pattern As enmLinePattern
    Public SolidLine As SolidLine_Data_Info
    Public CenterLineParts0 As OptionalLine_Data_info
    Public CenterLineParts1 As OptionalLine_Data_info
    Public CenterLineParts2 As OptionalLine_Data_info
    Public CenterLineParts3 As OptionalLine_Data_info
    Public CenterLineParts4 As OptionalLine_Data_info
    Public CenterLineParts5 As OptionalLine_Data_info
    Public Function Get_CenterLineParts(ByVal n As Integer) As OptionalLine_Data_info
        Select Case n
            Case 0
                Return Me.CenterLineParts0
            Case 1
                Return Me.CenterLineParts1
            Case 2
                Return Me.CenterLineParts2
            Case 3
                Return Me.CenterLineParts3
            Case 4
                Return Me.CenterLineParts4
            Case 5
                Return Me.CenterLineParts5
        End Select
    End Function
    Public Sub Set_CenterLineParts(ByVal n As Integer, ByVal Value As OptionalLine_Data_info)
        Select Case n
            Case 0
                Me.CenterLineParts0 = Value
            Case 1
                Me.CenterLineParts1 = Value
            Case 2
                Me.CenterLineParts2 = Value
            Case 3
                Me.CenterLineParts3 = Value
            Case 4
                Me.CenterLineParts4 = Value
            Case 5
                Me.CenterLineParts5 = Value
        End Select
    End Sub
End Structure


Public Structure Parallel_Line_Data_info
    Public P_Line_f As Boolean '二重線にする
    Public Interval As Single
    Public InnerColor_f As Boolean
    Public InnerColor As colorARGB
    Public Center_Line_f As Boolean
    Public CenterLine_ParaLine_f As Boolean
    Public P_CenterLine As Line_Basic_Data_Info
End Structure

Public Structure Cross_Line_Data_Info

    Public XLine_f As Boolean '交差線を描く
    Public XLineParts0 As Optional_X_Line_Data_info
    Public XLineParts1 As Optional_X_Line_Data_info
    Public XLineParts2 As Optional_X_Line_Data_info
    Public XLineParts3 As Optional_X_Line_Data_info
    Public XLineParts4 As Optional_X_Line_Data_info
    Public XLineParts5 As Optional_X_Line_Data_info
    Public Function Get_CrossLineParts(ByVal n As Integer) As Optional_X_Line_Data_info
        Select Case n
            Case 0
                Return Me.XLineParts0
            Case 1
                Return Me.XLineParts1
            Case 2
                Return Me.XLineParts2
            Case 3
                Return Me.XLineParts3
            Case 4
                Return Me.XLineParts4
            Case 5
                Return Me.XLineParts5
        End Select
    End Function
    Public Sub Set_CrossLineParts(ByVal n As Integer, ByVal Value As Optional_X_Line_Data_info)
        Select Case n
            Case 0
                Me.XLineParts0 = Value
            Case 1
                Me.XLineParts1 = Value
            Case 2
                Me.XLineParts2 = Value
            Case 3
                Me.XLineParts3 = Value
            Case 4
                Me.XLineParts4 = Value
            Case 5
                Me.XLineParts5 = Value
        End Select
    End Sub
End Structure

Public Structure LineEdge_Connect_Pattern_Data_Info
    Public Edge_Pattern As enmEdge_Pattern
    Public Join_Pattern As enmJoinPattern
    Public MiterLimitValue As Single
    Public Sub set_Pen_JoinCap(ByRef pen As Pen)
        Select Case Join_Pattern
            Case enmJoinPattern.Round
                pen.LineJoin = Drawing2D.LineJoin.Round
            Case enmJoinPattern.Miter
                pen.LineJoin = Drawing2D.LineJoin.Miter
                pen.MiterLimit = MiterLimitValue
            Case enmJoinPattern.Bevel
                pen.LineJoin = Drawing2D.LineJoin.Bevel
        End Select
        Select Case Edge_Pattern
            Case enmEdge_Pattern.Flat
                pen.StartCap = Drawing2D.LineCap.Flat
                pen.EndCap = Drawing2D.LineCap.Flat
            Case enmEdge_Pattern.Rectangle
                pen.StartCap = Drawing2D.LineCap.Square
                pen.EndCap = Drawing2D.LineCap.Square
            Case enmEdge_Pattern.Round
                pen.StartCap = Drawing2D.LineCap.Round
                pen.EndCap = Drawing2D.LineCap.Round
        End Select
    End Sub
End Structure
'フォントのプロパティ（汎用））---------------------------------
Public Structure Font_Body_Property
    Public Color As colorARGB
    Public Size As Single
    Public italic As Boolean
    Public bold As Boolean
    Public Underline As Boolean
    Public Name As String
    Public Kakudo As Single
    Public FringeF As Boolean
    Public FringeWidth As Single '文字の大きさに対する割合
    Public FringeColor As colorARGB
End Structure
Public Structure BackGround_Box_Property
    Public Tile As Tile_Property
    Public Line As Line_Property
    Public Round As Single
    Public Padding As Single
End Structure

Public Structure Font_Property
    Public Body As Font_Body_Property
    Public Back As BackGround_Box_Property
End Structure

Public Structure Tile_Property '模様のプロパティ（汎用）
    Public TileCode As enmTilePattern
    Public Line As Line_Property
    Public Density As Single
    Public BGColFlag As Boolean
    Public BGCOLOR As colorARGB
    Public TileMark As Tile_Mark_Property
End Structure

Public Structure Mark_Property '記号のプロパティ（汎用）
    Public PrintMark As enmMarkPrintType
    Public ShapeNumber As Short
    Public Tile As Tile_Property
    Public Line As Line_Property
    Public wordmark As String
    Public WordFont As Font_Property
    Public PictureNumber As Integer
    Public PictureAlpahValue As Integer
End Structure

Public Enum enmArrowHeadType
    Line = 0
    Fill = 1
End Enum
''' <summary>
''' 矢印のプロパティ
''' </summary>
''' <remarks></remarks>
Public Structure Arrow_Data
    Public Start_Arrow_F As Boolean
    Public End_Arrow_F As Boolean
    Public ArrowHeadType As enmArrowHeadType
    Public Angle As Single
    Public LWidthRatio As Single
    Public WidthPlus As Single
End Structure
''' <summary>
''' 属性データのタイプ
''' </summary>
''' <remarks></remarks>
Public Enum enmAttDataType
    Normal = 0
    Category = 1
    Strings = 2
    URL = 3
    URL_Name = 4
    Lon = 5
    Lat = 6
    Place = 7
    Arrival = 8
    Departure = 9
End Enum
''' <summary>
''' 度分秒の表記
''' </summary>
''' <remarks></remarks>
Public Enum enmLatLonPrintPattern
    DegreeMinuteSecond = 0
    DecimalDegree = 1
End Enum
''' <summary>
''' 地図ファイルデフォルトフォルダ
''' </summary>
''' <remarks></remarks>
Public Enum enmMapFolder_Default_info
    MapFolder = 0
    LastAccesedFolder = 1
End Enum

Public Enum enmDefoHanreiColor
    Gray = 0
    Red = 1
    Blue = 2
End Enum




''' <summary>
''' タイルパターンの列挙型
''' </summary>
''' <remarks></remarks>
Public Enum enmTilePattern
    Point = 0
    HorizontalLine = 1
    VerticalLine = 2
    DiagonalLineRightUp = 3
    DiagonalLineRightDown = 4
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    CrossLine = 5
    ''' <summary>
    ''' ×
    ''' </summary>
    ''' <remarks></remarks>
    Saltire = 6
    Blank = 7
    Paint = 8
    Mark = 9
End Enum

''' <summary>
''' 記号のタイプ
''' </summary>
''' <remarks></remarks>
Public Enum enmMarkPrintType
    Mark = 0
    Word = 1
    Picture = 2
End Enum

Public Enum enmMesh_Number
    mhNonMesh = -1
    mhFirst = 0
    mhSecond = 1
    mhThird = 2
    mhHalf = 3
    mhQuarter = 4
    mhOne_Eighth = 5
    mhOne_Tenth = 6
End Enum

Public Enum enmDirection
    Reverse = -1
    Forward = 1
End Enum
Public Enum enmSize As Short
    VerySmall = -2
    Small = -1
    Medium = 0
    Large = 1
    VaryLarge = 2
End Enum
Public Enum enmLinePattern As Short
    'ラインパターン
    InVisible = -1 '透明
    Solid = 0 '実線
    BROKEN = 1 '破線
End Enum
Public Enum enmLineCrossPattern As Short
    '交差線パターン
    Line = 0 '直線
    Circle = 1 '円
    Rectangle = 2 '資格
    Mark = 3 '記号
End Enum
Public Enum enmEdge_Pattern As Short
    '線端形状
    Round = 0 '丸
    Rectangle = 1 '四角
    Flat = 2 '平ら
End Enum
Public Enum enmJoinPattern As Short
    '折れ線の接続
    Round = 0
    Bevel = 1
    Miter = 2
End Enum
Public Enum enmLineConnect As Short
    no = 0
    one = 1
    both = 2
    loopen = 3
End Enum



Public Enum enmHorizontalAlignment
    Left = -1
    Center = 0
    Right = 1
End Enum
Public Enum enmVerticalAlignment
    Top = -1
    Center = 0
    Bottom = 1
End Enum

Public Enum enmOutputDevice
    Screen = 0
    Printer = 1
    EMF = 2
End Enum
Public Structure Magnification
    Public Xplus As Single
    Public YPlus As Single
    Public Mul As Single
End Structure
Public Structure strThreeDMode_Set  '3Dモードの回転に使用（属性データ）
    Public Set3D_F As Boolean
    Public Pitch As Integer
    Public Head As Integer
    Public Bank As Integer
    Public Expand As Integer
End Structure
Public Structure ScreenMargin
    Public Left As Single
    Public Top As Single
    Public Right As Single
    Public Bottom As Single
    Public ClipF As Boolean
    Public Sub New(ByVal _Left As Single, ByVal _Top As Single, ByVal _Right As Single, ByVal _Bottom As Single, ByVal _ClipF As Boolean)
        Me.Left = _Left
        Me.Right = _Right
        Me.Top = _Top
        Me.Bottom = _Bottom
        Me.ClipF = _ClipF
    End Sub
End Structure
Public Structure Picture_Property '画像の基本値
    Public Size As Size
    Public TransParency_f As Boolean
    Public TransParency_Color As colorARGB
    Public Alternate_f As Boolean
    Public TransRange As Single
    Public Alternate_Color As colorARGB
    Private BitMapData As Bitmap
    Public Sub SetBitmap(ByRef _bmp As Bitmap)
        BitMapData = _bmp
    End Sub
    Public Function GetBitmap() As Bitmap
        Return BitMapData
    End Function
End Structure
Public Structure BasePicture_Info
    Public PictureNum As Integer
    Public PictureData As List(Of Picture_Property)
End Structure

Public Structure Screen_info
    Public FirstScreenMGMul As Single '全体が表示してある場合の拡大係数(MDRには保存しない)
    Public GSMul As Double '地図サイズに対するウィンドウサイズの比(MDRには保存しない)
    ''' <summary>
    ''' MapRectangleの面積と同等の正方形の対角線の長さ
    ''' </summary>
    ''' <remarks></remarks>
    Public STDWsize As Single
    ''' <summary>
    '''  '地図中の画面に表示したい領域（地図座標）
    ''' </summary>
    ''' <remarks></remarks>
    Public ScrView As RectangleF '旧wx1など
    ''' <summary>
    ''' 画面領域四隅の地図座標
    ''' </summary>
    ''' <remarks></remarks>
    Public ScrRectangle As RectangleF '旧S_Wx1など
    ''' <summary>
    ''' 地図の領域全体の地図座標
    ''' </summary>
    ''' <remarks></remarks>
    Public MapRectangle As RectangleF  '旧F_Wx1など
    ''' <summary>
    ''' 画面の四隅の座標（0,0,width,bottom）
    ''' </summary>
    ''' <remarks></remarks>
    Public MapScreen_Scale As Rectangle 'pictureboxの大きさ.Left=0  .Top=0  .bottom=Scalebottom  .Top=scaleTop
    ''' <summary>
    ''' 地図座標を画面座標に変換する際の拡大係数とXY座標の平行移動値
    ''' </summary>
    ''' <remarks></remarks>
    Public ScreenMG As Magnification '旧mul,xp,yp
    Public OutputDevide As enmOutputDevice
    Public PrinterMG As Magnification '旧Prtmul,xp,yp
    ''' <summary>
    ''' 画面上下左右端のマージン
    ''' </summary>
    ''' <remarks></remarks>
    Public Screen_Margin As ScreenMargin '画面のマージン
    Public frmPrint_FormSize As Rectangle 'frmPrintのウィンドウ自体の位置とサイズ
    Public Accessory_Base As enmBasePosition '飾り等のサイズを地図領域でなくpictureboxの大きさに比例させる場合true
    Public SampleBoxFlag As Boolean 'サンプルのライン、記号等に表示する際にtrueにする
    Public ThreeDMode As strThreeDMode_Set
    ''' <summary>
    ''' 画面上のピクセルが地図中の何パーセントに当たるか計算
    ''' </summary>
    ''' <param name="Pixcel"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Get_Length_On_BaseMap(ByVal Pixcel As Integer) As Single
        Get
            Dim a As Single = Pixcel / Me.STDWsize * 100 / Me.ScreenMG.Mul / Me.GSMul
            If OutputDevide = enmOutputDevice.Printer Then
                a = a / Me.PrinterMG.Mul
            End If
            Return a
        End Get
    End Property
    ''' <summary>
    ''' パーセントのサイズが，画面上で何ピクセルかを取得
    ''' </summary>
    ''' <param name="Percentage"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Get_Length_On_Screen(ByVal Percentage As Single) As Integer
        Get
            If Me.SampleBoxFlag = False Then
                Dim RR As Single = STDWsize * Percentage / 100 * ScreenMG.Mul * GSMul
                If OutputDevide = enmOutputDevice.Printer Then
                    RR = RR * Me.PrinterMG.Mul
                End If
                Return CInt(RR)
            Else
                Return CInt(STDWsize * Percentage / 100 * FirstScreenMGMul)
            End If
        End Get
    End Property
    ''' <summary>
    ''' 最大値に占める指定値の割合に面積比例する画面半径を返す
    ''' </summary>
    ''' <param name="R_Percent">最大半径</param>
    ''' <param name="Value">指定値</param>
    ''' <param name="max_Value">最大値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Radius(ByVal R_Percent As Single, ByVal Value As Double, ByVal max_Value As Double) As Integer
        Dim RR As Single
        If max_Value = 0 Then
            RR = 0
        Else
            RR = STDWsize * R_Percent * GSMul / 100 * ScreenMG.Mul * Math.Sqrt(Value) / Math.Sqrt(max_Value) / 2
            If OutputDevide = enmOutputDevice.Printer Then
                RR = RR * Me.PrinterMG.Mul
            End If
        End If
        Return CInt(RR)
    End Function
    ''' <summary>
    ''' 線幅を返す（線幅が0の場合は最小値に）
    ''' </summary>
    ''' <param name="Percentage"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Get_Line_Width(ByVal Percentage As Single) As Integer
        Get
            If Percentage = 0 Then
                Select Case clsSettings.Data.MinimumLineWidth
                    Case 0
                        Return 0
                    Case 1
                        Return 1
                    Case Else
                        Dim size As Single = 0.025 * (clsSettings.Data.MinimumLineWidth - 2) + 0.05
                        Return Get_Length_On_Screen(size)
                End Select
            Else
                Return Get_Length_On_Screen(Percentage)
            End If
        End Get
    End Property
    ''' <summary>
    ''' 画面上のピクセル数に対応する地図座標のサイズを取得
    ''' </summary>
    ''' <param name="Pixcel">画面上のピクセル数</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Get_MapDataSize_from_ScreenPixcel(ByVal Pixcel As Integer) As Single
        Get
            Return Pixcel / Me.ScreenMG.Mul
        End Get
    End Property

    ''' <summary>
    ''' 地図X座標をスクリーン座標に
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSx(ByVal x As Single) As Integer

        With Me
            If .OutputDevide <> enmOutputDevice.Printer Then
                Return (x - .ScrView.Left) * .ScreenMG.Mul + .ScreenMG.Xplus
            Else
                Return ((x - .ScrView.Left) * .ScreenMG.Mul + .ScreenMG.Xplus) * .PrinterMG.Mul + .PrinterMG.Xplus
            End If
        End With


    End Function
    ''' <summary>
    ''' 地図Y座標をスクリーン座標に
    ''' </summary>
    ''' <param name="y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSy(ByVal y As Single) As Integer

        With Me
            If .OutputDevide <> enmOutputDevice.Printer Then
                Return (y - .ScrView.Top) * .ScreenMG.Mul + .ScreenMG.YPlus
            Else
                Return ((y - .ScrView.Top) * .ScreenMG.Mul + .ScreenMG.YPlus) * .PrinterMG.Mul + .PrinterMG.YPlus
            End If
        End With

    End Function
    ''' <summary>
    ''' 回転を考慮して地図座標列をスクリーン座標に変換
    ''' </summary>
    ''' <param name="Pnum"></param>
    ''' <param name="inXY">座標列</param>
    ''' <param name="ReverseGetF">Trueの場合は座標列を反転させて取得</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_SxSy_With_3D(ByVal Pnum As Integer, ByRef inXY() As PointF, ByVal ReverseGetF As Boolean) As Point()

        If ThreeDMode.Set3D_F = True Then
            Dim XYPara As Single
            Dim TurnCenter As PointF
            With Me.MapRectangle
                TurnCenter = New PointF((.Left + .Right) / 2, (.Top + .Bottom) / 2)
                XYPara = Math.Sqrt((.Right - .Left) ^ 2 + (.Bottom - .Top) ^ 2)
            End With

            Dim INXY2(Pnum) As PointF
            With ThreeDMode
                For i As Integer = 0 To Pnum - 1
                    INXY2(i) = spatial.Trans3D(inXY(i).X, inXY(i).Y, 0, TurnCenter, .Expand, .Pitch, .Head, .Bank, XYPara)
                Next
            End With
            Return getSxSy(Pnum, INXY2, ReverseGetF, True)
        Else
            Return getSxSy(Pnum, inXY, ReverseGetF, True)
        End If

    End Function
    ''' <summary>
    ''' 回転を考慮して地図座標四角形をスクリーン座標に変換
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_SxSy_With_3D(ByVal PointRect() As PointF) As Point()
        Dim meshP() As PointF = PointRect
        ReDim Preserve meshP(4)
        meshP(4) = meshP(0)
        Dim pxy() As Point = Get_SxSy_With_3D(5, meshP, False)
        Return pxy
    End Function
    ''' <summary>
    ''' 回転を考慮して地図座標四角形の回転後の外接角形をスクリーン座標で取得
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_SxSy_With_3D(ByVal Rect As RectangleF) As Rectangle
        Dim meshP(3) As PointF
        meshP(0) = New PointF(Rect.Left, Rect.Top)
        meshP(1) = New PointF(Rect.Right, Rect.Top)
        meshP(2) = New PointF(Rect.Right, Rect.Bottom)
        meshP(3) = New PointF(Rect.Left, Rect.Bottom)
        Dim pxy() As Point = Get_SxSy_With_3D(4, meshP, False)
        Dim minx As Integer = pxy(0).X
        Dim maxx As Integer = pxy(0).X
        Dim miny As Integer = pxy(0).Y
        Dim maxy As Integer = pxy(0).Y
        For i As Integer = 1 To pxy.Length - 1
            minx = Math.Min(minx, pxy(i).X)
            maxx = Math.Max(maxx, pxy(i).X)
            miny = Math.Min(miny, pxy(i).Y)
            maxy = Math.Max(maxy, pxy(i).Y)
        Next
        Dim ret As Rectangle
        ret = Rectangle.FromLTRB(minx, miny, maxx, maxy)
        Return ret
    End Function
    ''' <summary>
    ''' 回転を考慮して地図座標をスクリーン座標に変換
    ''' </summary>
    ''' <param name="inXY"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_SxSy_With_3D(ByRef inXY As PointF) As Point

        Dim P(0) As PointF
        P(0) = inXY
        Dim POut() As Point = Get_SxSy_With_3D(1, P, False)
        Return POut(0)

    End Function

    Public Function Get_SxSy_With_Z(ByVal P As PointF, ByVal InZ As Single) As Point
        If ThreeDMode.Set3D_F = True Then
            Dim XYPara As Single
            Dim TurnCenter As PointF
            Dim INXY2 As PointF
            With Me.MapRectangle
                TurnCenter = New Point((.Left + .Right) / 2, (.Top + .Bottom) / 2)
                XYPara = Math.Sqrt((.Right - .Left) ^ 2 + (.Bottom - .Top) ^ 2)
            End With
            With ThreeDMode
                INXY2 = spatial.Trans3D(P.X, P.Y, InZ, TurnCenter, .Expand, .Pitch, .Head, .Bank, XYPara)
                Return getSxSy(INXY2)
            End With
        Else
            Return getSxSy(P)
        End If
    End Function
    ''' <summary>
    ''' 余白の四角形を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSXSY_Margin() As Rectangle

        Dim p1 As PointF = New PointF(Me.Screen_Margin.Left / 100, Me.Screen_Margin.Top / 100)
        Dim p2 As PointF = New PointF(1 - Me.Screen_Margin.Right / 100, 1 - Me.Screen_Margin.Bottom / 100)
        Dim pp1 As Point = Me.getSxSy(Me.getSRXYfromRatio(p1))
        Dim pp2 As Point = Me.getSxSy(Me.getSRXYfromRatio(p2))
        Dim marginRect As Rectangle = Rectangle.FromLTRB(pp1.X, pp1.Y, pp2.X, pp2.Y)
        Return marginRect
    End Function
    ''' <summary>
    ''' 元々の座標を地図座標経由してスクリーン座標XYに変換
    ''' </summary>
    ''' <param name="Point"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function getSxSy(ByVal Point As PointF, ByRef MapdataMap As clsMapData.strMap_data) As Point
        Dim P2 As PointF = spatial.Get_Converted_XY(Point, MapdataMap.Zahyo)
        Return getSxSy(P2)
    End Function
    ''' <summary>
    ''' 地図XY座標をスクリーン座標XYに
    ''' </summary>
    ''' <param name="Point"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function getSxSy(ByVal Point As PointF) As Point
        Dim P As Point
        P.X = getSx(Point.X)
        P.Y = getSy(Point.Y)
        Return P
    End Function
    ''' <summary>
    ''' 地図RectangleFをスクリーン座標に
    ''' </summary>
    ''' <param name="RectF"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function getSxSy(ByVal RectF As RectangleF) As Rectangle
        With RectF
            Dim L As PointF = New PointF(.Left, .Top)
            Dim R As PointF = New PointF(.Right, .Bottom)
            Dim LC As Point = getSxSy(L)
            Dim RC As Point = getSxSy(R)
            Return Rectangle.FromLTRB(LC.X, LC.Y, RC.X, RC.Y)
        End With
    End Function
    ''' <summary>
    ''' 地図XY座標配列からスクリーンXY座標配列に変換(前後が同一座標の場合はまとめることもできる)
    ''' </summary>
    ''' <param name="n">座標数</param>
    ''' <param name="XY">地図XY座標配列</param>
    ''' <param name="ReverseGetF">Trueの場合は座標列を反転させて取得</param>
    ''' <param name="SamePointCheck">前後が同一座標の場合はまとめる場合true</param>
    ''' <returns>スクリーンXY座標配列</returns>
    ''' <remarks></remarks>
    Public Overloads Function getSxSy(ByVal n As Integer, ByRef XY() As PointF, ByVal ReverseGetF As Boolean, ByVal SamePointCheck As Boolean) As Point()

        Dim j As Integer
        Dim jp As Integer
        Dim XY2(n - 1) As Point
        If ReverseGetF = False Then
            j = 0
            jp = 1
        Else
            j = n - 1
            jp = -1
        End If

        If SamePointCheck = True Then
            XY2(0) = getSxSy(XY(j))
            j += jp
            Dim newP As Integer = 1
            For i As Integer = 1 To n - 1
                Dim nXY As Point = getSxSy(XY(j))
                If nXY.Equals(XY2(newP - 1)) = False Then
                    '一つ前のポイントとスクリーン座標が違う場合は追加する
                    XY2(newP) = nXY
                    newP += 1
                End If
                j += jp
            Next
            If newP = 1 And n > 1 Then
                '短い線で1点になってしまう場合
                newP += 1
                XY2(1) = XY2(0)
            End If
            ReDim Preserve XY2(newP - 1)
        Else
            For i As Integer = 0 To n - 1
                XY2(i) = getSxSy(XY(j))
                j += jp
            Next
        End If
        Return XY2
    End Function

    ''' <summary>
    ''' スクリーンX座標を地図座標に戻す
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSRX(ByVal x As Single) As Single

        With Me
            If .OutputDevide <> enmOutputDevice.Printer Then
                getSRX = (x - .ScreenMG.Xplus) / .ScreenMG.Mul + .ScrView.Left
            Else
                getSRX = (x - .PrinterMG.Xplus) / .ScreenMG.Mul / .PrinterMG.Mul - .ScreenMG.Xplus / .ScreenMG.Mul + .ScrView.Left
            End If
        End With
    End Function
    ''' <summary>
    ''' スクリーンY座標を地図座標に戻す
    ''' </summary>
    ''' <param name="Y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSRY(ByVal Y As Single) As Single

        With Me
            If .OutputDevide <> enmOutputDevice.Printer Then
                getSRY = (Y - .ScreenMG.YPlus) / .ScreenMG.Mul + .ScrView.Top
            Else
                getSRY = (Y - .PrinterMG.YPlus) / .ScreenMG.Mul / .PrinterMG.Mul - .ScreenMG.YPlus / .ScreenMG.Mul + .ScrView.Top
            End If
        End With

    End Function
    ''' <summary>
    ''' スクリーンXY座標から地図座標に戻す
    ''' </summary>
    ''' <param name="P"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSRXY(ByVal P As Point) As PointF
        Dim x As Single, y As Single
        With Me
            If .OutputDevide <> enmOutputDevice.Printer Then
                x = (P.X - .ScreenMG.Xplus) / .ScreenMG.Mul + .ScrView.Left
            Else
                x = (P.X - .PrinterMG.Xplus) / .ScreenMG.Mul / .PrinterMG.Mul - .ScreenMG.Xplus / .ScreenMG.Mul + .ScrView.Left
            End If
            If .OutputDevide <> enmOutputDevice.Printer Then
                y = (P.Y - .ScreenMG.YPlus) / .ScreenMG.Mul + .ScrView.Top
            Else
                y = (P.Y - .PrinterMG.YPlus) / .ScreenMG.Mul / .PrinterMG.Mul - .ScreenMG.YPlus / .ScreenMG.Mul + .ScrView.Top
            End If
        End With
        Return New PointF(x, y)
    End Function
    ''' <summary>
    ''' 画面の上下の位置の相対比（0～1）から画面座標を返す
    ''' </summary>
    ''' <param name="P"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSxSyfromRatio(ByVal P As PointF) As Point
        With Me.ScrRectangle
            Dim P2 As PointF
            P2.X = .Left + (.Right - .Left) * P.X
            P2.Y = .Top + (.Bottom - .Top) * P.Y
            Return getSxSy(P2)
        End With
    End Function
    ''' <summary>
    ''' 画面座標から相対比座標を返す
    ''' </summary>
    ''' <param name="P"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getRatioPfromSxSy(ByVal P As Point) As PointF
        Return New PointF(P.X / Me.frmPrint_FormSize.Width, P.Y / Me.frmPrint_FormSize.Height)

    End Function
    ''' <summary>
    ''' 地図座標から相対比座標を返す
    ''' </summary>
    ''' <param name="P"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getRatioPfromSrxSry(ByVal P As PointF) As PointF
        Dim p2 As Point = Me.getSxSy(P)
        Return New PointF(p2.X / Me.frmPrint_FormSize.Width, p2.Y / Me.frmPrint_FormSize.Height)

    End Function
    ''' <summary>
    ''' 画面の上下の位置の相対比（0～1）から地図座標に戻す(旧SRX2,SRY2)
    ''' </summary>
    ''' <param name="P"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSRXYfromRatio(ByVal P As PointF) As PointF
        With Me.ScrRectangle
            Dim P2 As PointF
            P2.X = .Left + (.Right - .Left) * P.X
            P2.Y = .Top + (.Bottom - .Top) * P.Y
            Return P2
        End With
    End Function
    Public Sub Set_PictureBox_and_CulculateMul(ByRef picMapBox As PictureBox)
        Set_PictureBox_and_CulculateMul(picMapBox.Size)
    End Sub
    ''' <summary>
    ''' 指定されたpictureboxに合わせて拡大係数などを計算する(旧Set_Map_Width_to_Windows)
    ''' </summary>
    ''' <param name="picMapBox">地図を表示するpicturebox</param>
    ''' <remarks></remarks>
    Public Sub Set_PictureBox_and_CulculateMul(ByVal Size As Size)
        '使用するScreen_infoデータは、
        '入力用に.ScrViewと.Screen_Margin
        '出力に、.ScreenMG
        'その他のプロパティは使用せず

        Dim w As Single, H As Single
        Dim Wwidth As Integer = Size.Width
        Dim Wheight As Integer = Size.Height
        With Me.Screen_Margin
            w = Wwidth * (1 - (.Left + .Right) / 100)
            H = Wheight * (1 - (.Top + .Bottom) / 100)
        End With
        Dim FN As Single = w / H

        Dim xw As Single
        Dim yw As Single
        With ScrView
            xw = .Right - .Left
            yw = .Bottom - .Top
        End With
        Dim n As Single = xw / yw
        If n >= FN Then
            Me.ScreenMG.Mul = w / xw
        Else
            Me.ScreenMG.Mul = H / yw
        End If
        Me.ScreenMG.Xplus = (w - xw * Me.ScreenMG.Mul) / 2 + Wwidth * Me.Screen_Margin.Left / 100
        Me.ScreenMG.YPlus = (H - yw * Me.ScreenMG.Mul) / 2 + Wheight * Me.Screen_Margin.Top / 100

        If Me.OutputDevide <> enmOutputDevice.Printer Then
            Me.MapScreen_Scale = New Rectangle(0, 0, Wwidth, Wheight)
            Me.ScrRectangle = RectangleF.FromLTRB(Me.getSRX(0), Me.getSRY(0), Me.getSRX(Wwidth), Me.getSRY(Wheight))
        Else
            Me.OutputDevide = enmOutputDevice.Screen
            Me.ScrRectangle = RectangleF.FromLTRB(Me.getSRX(0), Me.getSRY(0), Me.getSRX(Wwidth), Me.getSRY(Wheight))
            Me.OutputDevide = enmOutputDevice.Printer
            Me.MapScreen_Scale = Me.getSxSy(Me.ScrRectangle)
        End If
        Get_Screen_BaseMul()

    End Sub
    ''' <summary>
    ''' ScrData初期化
    ''' </summary>
    ''' <param name="picturebox">表示するpictureBox</param>
    ''' <param name="picBoxMargin">マージンScreenMargin構造体</param>
    ''' <param name="MapAllAreaRect">地図領域全体の外接四角形</param>
    ''' <param name="AccessoryBaseSetScreenFlag">飾り等のサイズを地図領域でなくpictureboxの大きさに比例させる場合true</param>
    ''' <param name="SCRViewResetF">SCRViewResetFを初期化する場合true</param>
    ''' <remarks></remarks>
    Public Sub init(ByRef picturebox As PictureBox, ByVal picBoxMargin As ScreenMargin, ByVal MapAllAreaRect As RectangleF,
                    ByVal AccessoryBase As enmBasePosition, ByVal SCRViewResetF As Boolean)
        Me.Screen_Margin = picBoxMargin
        Me.MapRectangle = MapAllAreaRect
        Dim SCRS As RectangleF = Me.ScrView
        Me.ScrView = MapAllAreaRect
        Set_PictureBox_and_CulculateMul(picturebox)
        Me.FirstScreenMGMul = Me.ScreenMG.Mul
        If SCRViewResetF = False Then
            Me.ScrView = SCRS
        End If
        Me.Accessory_Base = AccessoryBase
        If Me.MapRectangle.Width = 0 Or Me.MapRectangle.Height = 0 Then
            Me.STDWsize = Math.Sqrt(Math.Max(Me.MapRectangle.Width, Me.MapRectangle.Height))
        Else
            Me.STDWsize = Math.Sqrt(Me.MapRectangle.Width * Me.MapRectangle.Height)
        End If
        '        Me.STDWsize = Math.Sqrt((Me.MapRectangle.Right - Me.MapRectangle.Left) * (Me.MapRectangle.Bottom - Me.MapRectangle.Top))
        Get_Screen_BaseMul()
        Me.SampleBoxFlag = False
        Me.OutputDevide = enmOutputDevice.Screen
    End Sub
    ''' <summary>
    ''' '地図サイズに対する表示領域サイズの比を求める
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Get_Screen_BaseMul()

        Dim s As Single

        If Me.Accessory_Base = enmBasePosition.Screen Then
            With Me.ScrView
                s = Math.Sqrt((.Right - .Left) * (.Bottom - .Top))
            End With
            Me.GSMul = s / Me.STDWsize
        Else
            Me.GSMul = 1
        End If
    End Sub
End Structure


Public Class clsGeneric

    ''' <summary>
    ''' コンボボックスに文字エンコーディングの一覧を設定
    ''' </summary>
    ''' <param name="cboScaleUnit"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetEncodings_to_Cbobox(ByRef cboEncoding As ComboBoxEx)
        Dim eis As System.Text.EncodingInfo() = System.Text.Encoding.GetEncodings()
        Dim okf(eis.Length) As Boolean
        cboEncoding.Items.Clear()
        For i As Integer = 0 To eis.Length - 1
            If InStr(eis(i).DisplayName, "日本語") <> 0 Then
                cboEncoding.Items.Add(New clsEncodings(eis(i)))
                okf(i) = True
            End If
        Next
        For i As Integer = 0 To eis.Length - 1
            If InStr(eis(i).DisplayName, "UTF") <> 0 Then
                cboEncoding.Items.Add(New clsEncodings(eis(i)))
                okf(i) = True
            End If
        Next
        For i As Integer = 0 To eis.Length - 1
            If okf(i) = False Then
                cboEncoding.Items.Add(New clsEncodings(eis(i)))
                okf(i) = True
            End If
        Next

    End Sub
    ''' <summary>
    ''' コンボボックスにスケール単位を設定
    ''' </summary>
    ''' <param name="cboScaleUnit"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetScaleUnit_to_Cbobox(ByRef cboScaleUnit As ComboBoxEx)
        cboScaleUnit.Items.Clear()
        cboScaleUnit.Items.AddRange({clsGeneric.getScaleUnitStrings(enmScaleUnit.centimeter),
                                    clsGeneric.getScaleUnitStrings(enmScaleUnit.meter),
                                    clsGeneric.getScaleUnitStrings(enmScaleUnit.kilometer),
                                    clsGeneric.getScaleUnitStrings(enmScaleUnit.inch),
                                    clsGeneric.getScaleUnitStrings(enmScaleUnit.feet),
                                    clsGeneric.getScaleUnitStrings(enmScaleUnit.yard),
                                    clsGeneric.getScaleUnitStrings(enmScaleUnit.mile),
                                    clsGeneric.getScaleUnitStrings(enmScaleUnit.syaku),
                                    clsGeneric.getScaleUnitStrings(enmScaleUnit.ken),
                                    clsGeneric.getScaleUnitStrings(enmScaleUnit.ri),
                                     clsGeneric.getScaleUnitStrings(enmScaleUnit.kairi)})

    End Sub
    ''' <summary>
    ''' 単精度を9桁の文字列で返す
    ''' </summary>
    ''' <param name="singlevalue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SingleToString(ByVal singlevalue As Single) As String
        Return singlevalue.ToString("g9")
    End Function
    ''' <summary>
    ''' 画面表示領域変更の可否のチェック
    ''' </summary>
    ''' <param name="MapRect"></param>
    ''' <param name="new_Rect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_New_ScrView(ByRef MapRect As RectangleF, ByVal new_Rect As RectangleF) As Boolean
        If new_Rect.Width > MapRect.Width / 5000 Then
            '拡大しすぎでない場合
            If new_Rect.Width < MapRect.Width * 10 Then
                '縮小しすぎでない場合
                Return True
            End If
        End If
        Return False
    End Function
    ''' <summary>
    ''' コンボボックスexに投影法一覧を追加
    ''' </summary>
    ''' <param name="cboxex"></param>
    ''' <remarks></remarks>
    Public Shared Sub AddProjectionName2ComboBoxEx(ByRef cboxex As ComboBoxEx)
        With cboxex.Items
            .Clear()
            .Add(clsGeneric.getStringProjectionEnum(enmProjection_Info.prjMercator))
            .Add(clsGeneric.getStringProjectionEnum(enmProjection_Info.prjMiller))
            .Add(clsGeneric.getStringProjectionEnum(enmProjection_Info.prjSeikyoEntou))
            .Add(clsGeneric.getStringProjectionEnum(enmProjection_Info.prjLambertSeisekiEntou))
            .Add(clsGeneric.getStringProjectionEnum(enmProjection_Info.prjEckert4))
            .Add(clsGeneric.getStringProjectionEnum(enmProjection_Info.prjMollweide))
            .Add(clsGeneric.getStringProjectionEnum(enmProjection_Info.prjSanson))
        End With

    End Sub
    ''' <summary>
    ''' 緯度経度の整数をN(S)**E(W)***の文字列に変換
    ''' </summary>
    ''' <param name="LatLon"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_IdoKedo_Strings_NSWE(ByVal LatLon As strLatLon) As String

        Dim a As String = "N"
        If LatLon.Latitude < 0 Then
            a = "S"
        End If
        a += Microsoft.VisualBasic.Right("0" & CStr(Math.Abs(LatLon.Latitude)), 2)

        Dim b As String = "E"
        If 180 <= LatLon.Longitude Then
            LatLon.Longitude = -180 + (LatLon.Longitude - 180)
        End If

        If LatLon.Longitude < 0 Then
            b = "W"
        End If
        b += Microsoft.VisualBasic.Right("00" & CStr(Math.Abs(LatLon.Longitude)), 3)

        Return a & b
    End Function
    ''' <summary>
    ''' COlorARGBをHTMLで使用する色に変換
    ''' </summary>
    ''' <param name="col"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function convHTMLColor(ByVal col As colorARGB) As String
        Return "#" + col.r.ToString("X2") + col.g.ToString("X2") + col.b.ToString("X2")
    End Function

    ''' <summary>
    ''' COlorARGBをKMLで使用する色に変換
    ''' </summary>
    ''' <param name="col"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function convKMLColor(ByVal col As colorARGB) As String
        Return col.a.ToString("X2") + col.b.ToString("X2") + col.g.ToString("X2") + col.r.ToString("X2")
    End Function
    ''' <summary>
    ''' 数字アルファベットを全角半角変換
    ''' </summary>
    ''' <param name="a"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Convert_DoubleByteWord_to_Single(ByVal a As String) As String
        '
        Dim b As String = a
        For i As Integer = 0 To 25
            b = Replace(b, Chr(Asc("Ａ") + i), Chr(Asc("A") + i))
        Next
        For i As Integer = 0 To 25
            b = Replace(b, Chr(Asc("ａ") + i), Chr(Asc("a") + i))
        Next
        For i As Integer = 0 To 9
            b = Replace(b, Chr(Asc("０") + i), Chr(Asc("0") + i))
        Next

        Return b
    End Function
    ''' <summary>
    ''' ヘルプ表示
    ''' </summary>
    ''' <param name="HelpFile"></param>
    ''' <param name="innerRef">ファイル内の参照　#は不要</param>
    ''' <remarks></remarks>
    Public Shared Sub HelpShow(ByVal HelpFile As enmHelpFile, ByVal innerRef As String)
        Dim URI As String
        Select Case HelpFile
            Case enmHelpFile.About
                URI = "about"
            Case enmHelpFile.Index
                URI = "index"
            Case enmHelpFile.MapEditor
                URI = "mapeditor"
            Case enmHelpFile.OutputWindow
                URI = "outputwindow"
            Case enmHelpFile.PropertyData
                URI = "propertydata"
            Case enmHelpFile.SettingWindow
                URI = "settingwindow"
            Case enmHelpFile.SubWindow
                URI = "subwindow"
        End Select
        URI += ".html"
        If innerRef <> "" Then
            URI += "#" + innerRef
        End If
        For Each f As Form In Application.OpenForms
            If f.Name = "frmHelpBrowser" Then
                Dim helpform As frmHelpBrowser = CType(f, frmHelpBrowser)
                helpform.Show(URI)
                Return
            End If
        Next
        Dim form As New frmHelpBrowser
        form.Show(URI)
    End Sub

    ''' <summary>
    ''' ヘルプ表示（通常のダイアログからのヘルプ）
    ''' </summary>
    ''' <param name="URl"></param>
    ''' <param name="innerRef">ファイル内の参照　#は不要</param>
    ''' <param name="owner">オーナーフォーム</param>
    ''' <remarks></remarks>
    Public Shared Sub HelpShow(ByVal HelpFile As enmHelpFile, ByVal innerRef As String, ByRef owner As Form)
        Dim URI As String
        Select Case HelpFile
            Case enmHelpFile.About
                URI = "about"
            Case enmHelpFile.Index
                URI = "index"
            Case enmHelpFile.MapEditor
                URI = "mapeditor"
            Case enmHelpFile.OutputWindow
                URI = "outputwindow"
            Case enmHelpFile.PropertyData
                URI = "propertydata"
            Case enmHelpFile.SettingWindow
                URI = "settingwindow"
            Case enmHelpFile.SubWindow
                URI = "subwindow"
        End Select
        URI += ".html"
        If innerRef <> "" Then
            URI += "#" + innerRef
        End If
        For Each cForm As Form In owner.OwnedForms
            If cForm.Name = "frmHelpBrowser" Then
                Dim fm As frmHelpBrowser = CType(cForm, frmHelpBrowser)
                If fm.IsDisposed = True Then
                    fm = New frmHelpBrowser
                End If
                fm.Show(URI)
                Return
            End If
        Next
        Dim HelpForm As New frmHelpBrowser
        HelpForm.Owner = owner
        HelpForm.Show(URI)
    End Sub

    ''' <summary>
    ''' 文字列端のスペース、またタブCRLFを除去
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Remove_SpaceTabCRLF(ByVal str As String) As String

        Dim btx As String = ""

        str = Trim(str)
        For i As Integer = 1 To Len(str)
            Dim ctx As String = Mid$(str, i, 1)
            If ctx = vbTab Or ctx = Chr(10) Or ctx = Chr(13) Then
            Else
                btx += ctx
            End If
        Next
        Return btx
    End Function

    ''' <summary>
    ''' グリッドに入れたオブジェクト名から取得する
    ''' </summary>
    ''' <param name="ktgrid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getObjectNameFromKtgrid(ByRef ktgrid As KTGISUserControl.KTGISGrid, ByRef ObjNameList() As String) As Boolean
        Dim oname(ktgrid.Ysize(0) - 1) As String
        Dim f As Boolean = False
        For i As Integer = 0 To ktgrid.Ysize(0) - 1
            oname(i) = ktgrid.GridData(0, 0, i)
            If oname(i) <> "" Then
                f = True
            End If
        Next
        ObjNameList = oname

        Return f
    End Function
    ''' <summary>
    ''' グリッドにオブジェクト名を入れる
    ''' </summary>
    ''' <param name="ktgrid"></param>
    ''' <param name="oname"></param>
    ''' <remarks></remarks>
    Public Shared Sub setObjectNameToKTGrid(ByRef ktgrid As KTGISUserControl.KTGISGrid, ByRef ObjectKind() As clsMapData.strObjectGroup_Data, ByVal ObjGroup As Integer, ByRef oname() As String)
        ktgrid.init("", "", "", 1, 0, 1, 0, False, False, True, False, False, False, False, False, False, False)
        With oname
            ktgrid.AddLayer("", 0, 1, oname.Length)
            ktgrid.FixedYSData(0, 0, 0) = "オブジェクト名"
            ktgrid.FixedUpperLeftData(0, 0, 0) = "リスト名"
            For i As Integer = 0 To ObjectKind(ObjGroup).ObjectNameNum - 1
                ktgrid.FixedXSData(0, 0, i) = ObjectKind(ObjGroup).ObjectNameList(i)
                ktgrid.GridData(0, 0, i) = oname(i)
            Next
            ktgrid.FixedXSWidth(0, 0) = 90
            ktgrid.FixedUpperLeftAlligntment(0) = HorizontalAlignment.Center
            ktgrid.FixedXSAllignment(0, 0) = HorizontalAlignment.Left
            ktgrid.GridAlligntment(0, 0) = HorizontalAlignment.Left
            ktgrid.GridWidth(0, 0) = ktgrid.Width - SystemInformation.VerticalScrollBarWidth - 4 - ktgrid.FixedXSWidth(0, 0)
        End With
        ktgrid.Show()
    End Sub
    ''' <summary>
    ''' 拡張メタファイルで地図保存
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="attrdata"></param>
    ''' <param name="prog"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveEMFFile(ByVal FileName As String, ByRef attrdata As clsAttrData, ByVal prog As ToolStripProgressBar,
                                       ByRef frmPrint As frmPrint)
        'Metafileオブジェクトを作成する
        Dim bmp As New Bitmap(10, 10)
        Dim bmpg As Graphics = Graphics.FromImage(bmp)
        Dim hdc As IntPtr = bmpg.GetHdc()
        Dim rec As New Rectangle(0, 0, attrdata.TotalData.ViewStyle.ScrData.frmPrint_FormSize.Width, attrdata.TotalData.ViewStyle.ScrData.frmPrint_FormSize.Height)
        Dim meta As New System.Drawing.Imaging.Metafile(FileName, hdc, rec, Imaging.MetafileFrameUnit.Pixel, System.Drawing.Imaging.EmfType.EmfOnly)
        bmpg.ReleaseHdc(hdc)
        'Metafileに描画する
        Dim emfg As Graphics = Graphics.FromImage(meta)
        If attrdata.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.SeriesMode Then
            frmPrint.Series_Mapping(emfg, prog, False)
        Else
            clsPrintMap.ShowMap(emfg, prog, attrdata)
        End If
        emfg.Dispose()

        '後片付け
        meta.Dispose()
        bmpg.Dispose()
        bmp.Dispose()
    End Function
    ''' <summary>
    ''' 連続表示モードのデータセットをリストビューに入れる
    ''' </summary>
    ''' <param name="ListViewSeries"></param>
    ''' <param name="attData"></param>
    ''' <param name="DataSet"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub SeriesMode_to_ListViewData(ByRef ListViewSeries As ListViewEX, ByRef attData As clsAttrData,
                                                      ByRef DataSetItem As List(Of clsAttrData.strSeries_DataSet_Item_Info))
        With DataSetItem
            Dim SeriesData(.Count) As String
            SeriesData(0) = "順番" + vbTab + "レイヤ" + vbTab + "データ" + vbTab + "表示モード"
            For i As Integer = 0 To .Count - 1
                With DataSetItem(i)
                    Dim tx As String = (i + 1).ToString + vbTab
                    Select Case .Print_Mode_Total
                        Case enmTotalMode_Number.DataViewMode
                            tx += attData.LayerData(.Layer).Name + vbTab
                            Select Case .Print_Mode_Layer
                                Case enmLayerMode_Number.SoloMode
                                    tx += attData.Get_DataTitle(.Layer, .Data, False) + vbTab
                                    tx += clsGeneric.getSolomodeStrings(.SoloMode) + vbTab
                                Case enmLayerMode_Number.GraphMode
                                    tx += "グラフ表示" + vbTab
                                    Dim T As String = attData.LayerData(.Layer).LayerModeViewSettings.GraphMode.DataSet(.Data).title
                                    If T = "" Then
                                        T = "データセット" & CStr(.Data + 1)
                                    End If
                                    tx += T + vbTab
                                Case enmLayerMode_Number.LabelMode
                                    tx += "ラベル表示" + vbTab
                                    Dim T As String = attData.LayerData(.Layer).LayerModeViewSettings.LabelMode.DataSet(.Data).title
                                    If T = "" Then
                                        T = "データセット" & CStr(.Data + 1)
                                    End If
                                    tx += T + vbTab
                                Case enmLayerMode_Number.TripMode
                                    tx += "移動表示" + vbTab
                                    Dim T As String = attData.LayerData(.Layer).LayerModeViewSettings.TripMode.DataSet(.Data).title
                                    If T = "" Then
                                        T = "データセット" & CStr(.Data + 1)
                                    End If
                                    tx += T + vbTab
                            End Select
                        Case enmTotalMode_Number.OverLayMode
                            tx += "重ね合わせモード" + vbTab
                            Dim T As String = attData.TotalData.TotalMode.OverLay.DataSet(.Data).title
                            If T = "" Then
                                T = "データセット" & CStr(.Data + 1)
                            End If
                            tx += T + vbTab
                    End Select
                    SeriesData(i + 1) = tx
                End With
            Next
            ListViewSeries.SetData(SeriesData, {VariantType.String, VariantType.String, VariantType.String, VariantType.String}, {False, False, False, False}, False)
            ListViewSeries.Select()
        End With

    End Sub
    ''' <summary>
    ''' 色を指定分明るくまたは暗くする（0を下回った場合は0、255を上回った場合は255）
    ''' </summary>
    ''' <param name="Col"></param>
    ''' <param name="ChangeValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetColorArrange(ByVal Col As colorARGB, ByVal ChangeValue As Integer) As colorARGB
        Dim r As Integer = clsGeneric.m_min_max(Col.r + ChangeValue, 0, 255)
        Dim g As Integer = clsGeneric.m_min_max(Col.g + ChangeValue, 0, 255)
        Dim b As Integer = clsGeneric.m_min_max(Col.b + ChangeValue, 0, 255)
        Col.r = CByte(r)
        Col.g = CByte(g)
        Col.b = CByte(b)
        Return Col
    End Function
    ''' <summary>
    ''' MPobj().DefTimeAttrDataのCloneを取得
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DefTimeAttValueClone(ByVal attrData() As clsMapData.strDefTimeAttData_Info) As clsMapData.strDefTimeAttData_Info()
        If attrData Is Nothing = False Then
            Dim RDefValue(attrData.GetUpperBound(0)) As clsMapData.strDefTimeAttData_Info
            For i As Integer = 0 To attrData.GetUpperBound(0)
                If attrData(i).Data Is Nothing = False Then
                    RDefValue(i).Data = attrData(i).Data.Clone
                End If
            Next
            Return RDefValue
        Else
            Return Nothing
        End If

    End Function
    ''' <summary>
    ''' オリジナルメッセージボックス
    ''' </summary>
    ''' <param name="StartPos">FormStartPosition.Manualの場合は、マウスの位置に表示</param>
    ''' <param name="text"></param>
    ''' <param name="Style"></param>
    ''' <param name="Icon"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MessageBox(ByVal StartPos As FormStartPosition, ByVal text As String, ByVal Style As MessageBoxButtons, ByVal Icon As MessageBoxIcon) As DialogResult
        Dim form As New frmMessageBox
        Dim f As DialogResult = form.ShowDialog(StartPos, text, Style, Icon)
        form.Dispose()
        Return f
    End Function
    ''' <summary>
    ''' 初期時点属性のオブジェクトごとのデータを時間順に並べ替える
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Public Shared Sub Sort_strDefPointAttDataEach_Info(ByRef data() As clsMapData.strDefTimeAttDataEach_Info)
        If data Is Nothing = True Then
            Return
        End If
        Dim data_n As Integer = data.Length
        If data_n = 1 Then
            Return
        End If
        Dim So As New clsSortingSearch(VariantType.Integer)
        For i As Integer = 0 To data_n - 1
            So.Add(clsTime.YMDtoValue(data(i).Span.StartTime))
        Next
        So.AddEnd()
        Dim defPData2(data_n - 1) As clsMapData.strDefTimeAttDataEach_Info
        For i As Integer = 0 To data_n - 1
            defPData2(i) = data(So.DataPosition(i))
        Next
        data = defPData2.Clone
    End Sub


    ''' <summary>
    ''' バイナリファイルをバイト配列に読み込む
    ''' </summary>
    ''' <param name="FilePath"></param>
    ''' <param name="ByteArray"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_BinaryFile_asByte(ByVal FilePath As String, ByRef ByteArray() As Byte) As Boolean
        If System.IO.File.Exists(FilePath) = False Then
            MsgBox(FilePath & "が見つかりません。", MsgBoxStyle.Exclamation)
            Return False
        End If
        Try
            Dim fs As New System.IO.FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            ReDim ByteArray(fs.Length - 1)
            fs.Read(ByteArray, 0, ByteArray.Length)
            fs.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 指定の文字数より長い場合、以降を...で省略して返す。短い場合はそのまま返す
    ''' </summary>
    ''' <param name="Str"></param>
    ''' <param name="Len"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_StringLength_And_Cut(ByVal Str As String, ByVal MaxLen As Integer) As String
        Dim rstr As String = Str
        If Len(rstr) > MaxLen Then
            rstr = Mid(rstr, 1, MaxLen) + "..."
        End If
        Return rstr
    End Function
    ''' <summary>
    ''' 透過度設定ダイアログ
    ''' </summary>
    ''' <param name="AlphaValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Set_AlphaValueForm(ByRef AlphaValue As Integer) As Boolean
        Dim form As New frmAlphaValueSet
        Dim f As Boolean = False
        If form.SetDialog(AlphaValue) = DialogResult.OK Then
            AlphaValue = form.GetResult
            f = True
        End If
        form.Dispose()
        Return f
    End Function
    ''' <summary>
    ''' Point配列に一つ削除する
    ''' </summary>
    ''' <param name="RemoveAt">削除箇所</param>
    ''' <param name="Points">座標配列</param>
    ''' <remarks></remarks>
    Public Shared Sub Remove_Point_Array(ByVal RemoveAt As Integer, ByRef Points() As PointF)
        Dim n As Integer = Points.Length
        For i As Integer = RemoveAt To n - 2
            Points(i) = Points(i + 1)
        Next
        ReDim Preserve Points(n - 1)
    End Sub
    ''' <summary>
    ''' Point配列に一つ挿入するする
    ''' </summary>
    ''' <param name="InsertAt">挿入箇所</param>
    ''' <param name="XY">挿入する座標</param>
    ''' <param name="Points">座標配列</param>
    ''' <remarks></remarks>
    Public Shared Sub Insert_Point_Array(ByVal InsertAt As Integer, ByVal XY As PointF, ByRef Points() As PointF)
        Dim n As Integer = Points.Length
        ReDim Preserve Points(n)
        For i As Integer = n To InsertAt + 1 Step -1
            Points(i) = Points(i - 1)
        Next
        Points(InsertAt) = XY
        Return
    End Sub
    Public Shared Function Get_InnerStrings(ByVal Str As String, ByVal FirstSTR As String, ByVal EndSTR As String) As String
        Dim i1 As Integer, i2 As Integer

        i1 = InStr(Str, FirstSTR)
        i2 = InStrRev(Str, EndSTR)
        If i1 = 0 Or i2 = 0 Then
            Return ""
        Else
            Return Mid(Str, i1 + 1, i2 - i1 - 1)
        End If
    End Function
    ''' <summary>
    ''' レイヤの形状ごとの数を入れた配列から、可能な形状を返す
    ''' </summary>
    ''' <param name="Shape"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function checkShape(ByVal Shape() As Integer) As enmShape
        If Shape(enmShape.PointShape) > 0 Then
            Return enmShape.PointShape
        ElseIf Shape(enmShape.LineShape) > 0 Then
            Return enmShape.LineShape
        Else
            Return enmShape.PolygonShape
        End If
    End Function

    ''' <summary>
    ''' 指定したファイルをロックせずに、System.Drawing.Imageを作成する。
    ''' </summary>
    ''' <param name="filename">作成元のファイルのパス</param>
    ''' <returns>作成したSystem.Drawing.Image。</returns>
    Public Shared Function CreateImage(ByVal filename As String) As System.Drawing.Image
        Dim fs As New System.IO.FileStream( _
            filename, _
            System.IO.FileMode.Open, _
            System.IO.FileAccess.Read)
        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(fs)
        fs.Close()
        Return img
    End Function
    ''' <summary>
    ''' 緯度経度入力
    ''' </summary>
    ''' <param name="LatLon">緯度経度（入力値　兼　戻り値）</param>
    ''' <param name="BoxF">北緯／南緯／東経／西経の表示非表示</param>
    ''' <param name="Pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_LatLon(ByRef LatLon As strLatLon, ByVal Pattern As enmLatLonPrintPattern, ByVal BoxF As Boolean) As Boolean

        Select Case Pattern
            Case enmLatLonPrintPattern.DecimalDegree
                Dim f As Boolean = False
                Dim form As New frmLatLonInput10
                If form.ShowDialog(LatLon, BoxF) = DialogResult.OK Then
                    LatLon = form.getResults
                    f = True
                End If
                form.Close()
                Return f
            Case enmLatLonPrintPattern.DegreeMinuteSecond
                Dim f As Boolean = False
                Dim form As New frmLatLonInputDMS
                If form.ShowDialog(LatLon, BoxF) = DialogResult.OK Then
                    LatLon = form.getResults
                    f = True
                End If
                form.Close()
                Return f
        End Select
    End Function
    ''' <summary>
    ''' 画像ファイルを読み込んでBITMAPに入れる
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <param name="bmp"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_BitMap_FromFile(ByVal filename As String, ByRef bmp As Bitmap) As Boolean
        Try
            bmp = DirectCast(System.Drawing.Image.FromFile(filename), System.Drawing.Bitmap)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 画像リストから選択
    ''' </summary>
    ''' <param name="attrData"></param>
    ''' <param name="DefaultPicNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Select_Picture(ByRef attrData As clsAttrData, ByVal DefaultPicNum As Integer) As Integer
        Dim form As New frmPictureSelector
        Dim picNum As Integer = -1
        If form.ShowDialog(attrData, DefaultPicNum) = DialogResult.OK Then
            picNum = form.getResult
        End If
        form.Dispose()
        Return picNum
    End Function

    ''' <summary>
    ''' 線モードの曲線の座標列を求めるための4つのコントロールポイント取得
    ''' </summary>
    ''' <param name="SpP">コントロール中心ポイント</param>
    ''' <param name="OriginP">始点</param>
    ''' <param name="DestP">終点</param>
    ''' <param name="poxy">4ポイントのPointF配列</param>
    ''' <remarks></remarks>
    Public Shared Function Get_OD_Spline_Point(ByVal ControlP As PointF, ByVal OriginP As PointF, ByVal DestP As PointF) As PointF()
        Dim poxy(3) As PointF
        Dim np As PointF
        Dim D As Single = spatial.Distance_PointLine(ControlP, OriginP, DestP, np)
        Dim dd1 As Single = Math.Abs((OriginP.X - ControlP.X) ^ 2 + (OriginP.Y - ControlP.Y) ^ 2 - D ^ 2)
        Dim dd2 As Single = Math.Abs((DestP.X - ControlP.X) ^ 2 + (DestP.Y - ControlP.Y) ^ 2 - D ^ 2)
        If dd2 < dd1 Then
            dd1 = dd2
        End If

        If OriginP.Y = DestP.Y Then
            poxy(1).X = ControlP.X - Math.Sqrt(dd1) * 0.75
            poxy(1).Y = ControlP.Y
            poxy(2).X = ControlP.X + Math.Sqrt(dd1) * 0.75
            poxy(2).Y = ControlP.Y
        ElseIf OriginP.X = DestP.X Then
            poxy(1).X = ControlP.X
            poxy(1).Y = ControlP.Y - Math.Sqrt(dd1) * 0.75
            poxy(2).X = ControlP.X
            poxy(2).Y = ControlP.Y + Math.Sqrt(dd1) * 0.75
        Else
            Dim a As Double = (DestP.Y - OriginP.Y) / (DestP.X - OriginP.X)
            Dim xa As Double = Math.Sqrt(dd1 / (a * a + 1)) * 0.75
            If OriginP.X < DestP.X Then xa = -xa
            Dim ya As Single = xa * a

            poxy(1).X = ControlP.X - xa
            poxy(1).Y = ControlP.Y - ya
            poxy(2).X = ControlP.X + xa
            poxy(2).Y = ControlP.Y + ya
        End If

        poxy(0) = DestP
        poxy(3) = OriginP
        Return poxy
    End Function
    ''' <summary>
    ''' 文字の出現回数をカウント
    ''' </summary>
    ''' <param name="s">元の文字列</param>
    ''' <param name="c">検索文字</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CountChar(ByVal s As String, ByVal c As Char) As Integer
        Return s.Length - s.Replace(c.ToString(), "").Length
    End Function



    ''' <summary>
    ''' 矢印設定
    ''' </summary>
    ''' <param name="Arrow_DT">矢印構造体（入力・出力）</param>
    ''' <param name="Start_Arrow_Caption">始点のキャプション。""で表示せず</param>
    ''' <param name="End_Arrow_Caption">終点のキャプション。""で表示せず</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Arrow_Set(ByRef Arrow_DT As Arrow_Data, ByVal Start_Arrow_Caption As String, ByVal End_Arrow_Caption As String) As Boolean
        Dim form As New frmArrow
        Dim f As Boolean = False
        If form.ShowDialog(Arrow_DT, Start_Arrow_Caption, End_Arrow_Caption) = DialogResult.OK Then
            Arrow_DT = form.getResult
            f = True
        End If
        form.Dispose()
        Return f
    End Function
    ''' <summary>
    ''' yyyymmddhhMMの長整数型変数をDatetime型に変換、エラーの場合false
    ''' </summary>
    ''' <param name="Time">元の14桁yyyymmddhhMMの長整数型</param>
    ''' <param name="ResultDateTime">datetime型（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Convert_Long_Time_to_DateTime(ByVal Time As Long, ByRef ResultDateTime As DateTime) As Boolean
        Dim v As String = Microsoft.VisualBasic.Right("00000000000000" + Time.ToString, 14)
        Dim y As Integer = Val(Mid(v, 1, 4))
        Dim m As Integer = Val(Mid(v, 5, 2))
        Dim d As Integer = Val(Mid(v, 7, 2))
        Dim h As Integer = Val(Mid(v, 9, 2))
        Dim Minute As Integer = Val(Mid(v, 11, 2))
        Dim s As Integer = Val(Mid(v, 13, 2))
        Dim dat As DateTime
        Try
            If h = 24 And Minute = 0 Then
                dat = New DateTime(y, m, d, 0, 0, 0)
                dat = dat.AddDays(1)
            Else
                dat = New DateTime(y, m, d, h, Minute, s)
            End If
            ResultDateTime = dat
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Datetime型をyyyymmddhhMMssの長整数型変数に変換
    ''' </summary>
    ''' <param name="Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Convert_DateTime_to_Long_Time(ByVal Time As DateTime) As Long

        Dim v As String = Time.ToString("yyyyMMddHHmmss")
        Return CLng(v)
    End Function
    ''' <summary>
    ''' 集成オブジェクトの輪郭線（>ラインコード）のみを抽出し、その数を返す
    ''' </summary>
    ''' <param name="n">最初のライン数</param>
    ''' <param name="LCode">使用するラインコードを渡し、必要なラインコードに変換して返す（戻り値）</param>
    ''' <param name="Shape"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Outer_Mpline_AggregatedObj(ByVal n As Integer, ByRef LCode() As clsMapData.EnableMPLine_Data, _
                                                    ByVal Shape As enmShape) As Integer

        Dim PGN As Integer = 0
        For i As Integer = 0 To n - 1
            Dim k As Integer = LCode(i).LineCode
            If k <> -1 Then
                For j As Integer = i + 1 To n - 1
                    If k = LCode(j).LineCode Then
                        LCode(j).LineCode = -1
                        If Shape = enmShape.PolygonShape Then
                            '面形状の場合は重複するラインは使用しない
                            '線形上の場合は、最初の1回だけ使用する
                            LCode(i).LineCode = -1
                        End If
                    End If
                Next
            End If
            If LCode(i).LineCode <> -1 Then
                LCode(PGN) = LCode(i)
                PGN += 1
            End If
        Next
        ReDim Preserve LCode(Math.Max(PGN - 1, 0))
        Return PGN

    End Function

    ''' <summary>
    ''' 二色の間で指定の数だけグラデーションをかける
    ''' </summary>
    ''' <param name="StartCol"></param>
    ''' <param name="EndCol"></param>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TwoColorGradation(ByVal StartCol As colorARGB, ByVal EndCol As colorARGB, ByVal n As Integer) As colorARGB()

        Dim ColData(n - 1) As colorARGB

        Dim a1 As Short = StartCol.a
        Dim AL As Short = EndCol.a - a1
        Dim r1 As Short = StartCol.r
        Dim RL As Short = EndCol.r - r1
        Dim g1 As Short = StartCol.g
        Dim GL As Short = EndCol.g - g1
        Dim B1 As Short = StartCol.b
        Dim BL As Short = EndCol.b - B1

        Dim cf As Integer = 0
        If n >= 3 Then
            If EndCol.getColor = Color.White Then cf = 1
            If StartCol.getColor = Color.White Then cf = -1
        End If

        For i As Integer = 0 To n - 1
            Dim v As Single = i / (n - 1)
            If i >= 1 And i <= n - 2 And cf <> 0 Then
                v = v + 1 / (2 * (n - 1)) * cf
            End If
            Dim a As Byte = a1 + AL * v
            Dim b As Byte = B1 + BL * v
            Dim r As Byte = r1 + RL * v
            Dim g As Byte = g1 + GL * v
            ColData(i) = New colorARGB(a, r, g, b)
        Next
        Return ColData
    End Function
    Public Shared Function ThreeColorGradation(ByVal StartCol As colorARGB, ByVal CenterCol As colorARGB, ByVal EndCol As colorARGB, ByVal n As Integer, ByVal Color_cng_n As Integer) As colorARGB()
        Dim ColData(n - 1) As colorARGB
        Dim coldata1() As colorARGB

        coldata1 = clsGeneric.TwoColorGradation(StartCol, CenterCol, Color_cng_n + 1)
        For i As Integer = 0 To Color_cng_n
            ColData(i) = coldata1(i)
        Next
        coldata1 = clsGeneric.TwoColorGradation(CenterCol, EndCol, n - Color_cng_n)
        For i As Integer = Color_cng_n To n - 1
            ColData(i) = coldata1(i - Color_cng_n)
        Next
        Return ColData
    End Function
    ''' <summary>
    ''' 最大値と最小値を指定の区分数で切りのよい数字で区切る。MaxMinは戻り値にもなる
    ''' </summary>
    ''' <param name="CUTN">区分数</param>
    ''' <param name="Max">最大値</param>
    ''' <param name="Min">最小値</param>
    ''' <param name="ST">区分間隔</param>
    ''' <remarks></remarks>
    Public Shared Sub WIC(ByVal CUTN As Integer, ByRef Max As Double, ByRef Min As Double, ByRef ST As Double)


        If Max = Min Then
            Max += 1
            Min -= 1
            ST = 1
            Return
        End If

        Dim H As Double = CDbl(CDec(Max) - CDec(Min))
        Dim f As Long = 1
        Dim L As Integer, r As Integer
        Figure_Arrange(Max, L, r)
        Dim m As Double = L
        Figure_Arrange(Min, L, r)
        If m + L = 0 Then
            f = 10 ^ r
            Max = Max * f
            Min = Min * f
            H = H * f
        Else
            Figure_Arrange(H, L, r)
            If L = 0 Then
                f = 10 ^ r
                Max = Max * f
                Min = Min * f
                H = H * f
            End If
        End If
        Figure_Arrange(H, L, r)
        Dim k As Integer = L
        Dim b As Double = 10 ^ (L - 1)
        Dim w As Double = (1 + Int(H / b)) * b / CUTN

        Figure_Arrange(w, L, r)
        b = 10 ^ (L - 1)
        Dim w2 As Double = w
        w = Int(w / b) * b
        If w = 0 Then
            w = w2 / b
        End If
        Figure_Arrange(Min, L, r)
        b = 10 ^ (k - 1)
        H = Int(Min / b) * b
        If H >= 0 Or Max <= 0 Then
        Else
            Dim H2 As Double = H
            While H2 < 0
                H2 += w
            End While
            H -= H2
        End If
        ST = w / f
        Dim a As Double = H / f
        Min = a

        Dim n As Integer = 0
        While a < Max / f
            a += ST
            n += 1
        End While
        Max = Min + ST * n
    End Sub


    ''' <summary>
    ''' 地図フォルダを取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_MapFolder() As String
        Select Case clsSettings.Data.Directory.MapFolder_Default
            Case enmMapFolder_Default_info.MapFolder
                Return System.Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\MANDARA10\MAP"
            Case enmMapFolder_Default_info.LastAccesedFolder
                Return clsSettings.Data.Directory.Mapfile
        End Select
    End Function

    ''' <summary>
    ''' 連続した文字列を一つにする
    ''' </summary>
    ''' <param name="strOrg">対象文字列</param>
    ''' <param name="strRem">一つにしたい文字列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RemoveConsecStrings(ByVal strOrg As String, ByVal strRem As String) As String

        Dim lngLen As Integer

        Do
            lngLen = Len(strOrg)
            strOrg = Replace(strOrg, strRem & strRem, strRem)
        Loop While lngLen > Len(strOrg)

        Return strOrg

    End Function
    ''' -----------------------------------------------------------------------------------------
    ''' <summary>文字列の指定されたバイト位置から、指定されたバイト数分の文字列を返します。</summary>
    ''' <param name="stTarget">取り出す元になる文字列。</param>
    ''' <param name="iStart">取り出しを開始する位置。</param>
    ''' <param name="iByteSize">取り出すバイト数。</param>
    ''' <returns>指定されたバイト位置から指定されたバイト数分の文字列。</returns>
    ''' -----------------------------------------------------------------------------------------
    Public Shared Function MidB(ByVal stTarget As String, ByVal iStart As Integer, ByVal iByteSize As Integer) As String
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncoding.GetBytes(stTarget)

        Return hEncoding.GetString(btBytes, iStart - 1, iByteSize)
    End Function
    ''' <summary>
    ''' ファイルが存在していたら削除する
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function KillFile_if_exists(filename As String) As Boolean
        If System.IO.File.Exists(filename) = True Then
            Try
                System.IO.File.Delete(filename)
            Catch ex As Exception
                Return False
            End Try
        End If
        Return True
    End Function
    ''' <summary>
    ''' 座標の文字列取得
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="Header_Flag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_PositionCoordinate_Strings(ByVal P As PointF, ByRef MPDataMapZahyo As clsMapData.Zahyo_info,
                                                          Optional ByVal Header_Flag As Boolean = True) As strPointStrings
        '緯度経度の文字列取得
        Dim retPS As strPointStrings
        Select Case MPDataMapZahyo.Mode
            Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                If Header_Flag = True Then
                    retPS.x = "Y:"
                    retPS.y = "X:"
                End If
                retPS.x += P.X.ToString("n1")
                retPS.y += P.Y.ToString("n1")
            Case enmZahyo_mode_info.Zahyo_No_Mode
                If Header_Flag = True Then
                    retPS.x = "X:"
                    retPS.y = "Y:"
                End If
                retPS.x += P.X.ToString("n3")
                retPS.y += P.Y.ToString("n3")
            Case enmZahyo_mode_info.Zahyo_Ido_Keido
                retPS = Get_LatLon_Strings(P, Header_Flag)
        End Select
        Return retPS
    End Function
    ''' <summary>
    ''' 緯度経度の文字列取得
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="Header_Flag">北緯／東経などつける場合true</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_LatLon_Strings(ByVal LatLonP As strLatLon, Optional ByVal Header_Flag As Boolean = True) As strPointStrings
        Return Get_LatLon_Strings(LatLonP.toPointF, Header_Flag)
    End Function
    ''' <summary>
    ''' 緯度経度の文字列取得
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="Header_Flag">北緯／東経などつける場合true</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_LatLon_Strings(ByVal P As PointF, Optional ByVal Header_Flag As Boolean = True) As strPointStrings

        Dim retPS As strPointStrings

        If Header_Flag = True Then

            If P.Y < 0 Then
                retPS.y = "南緯"
            Else
                retPS.y = "北緯"
            End If


            Dim V2 As Single = Math.Abs(P.X)
            Dim V3 As Single = V2 Mod 360
            If 180 < V3 Then
                If P.X < 0 Then
                    P.X = (P.X - (P.X \ 360) * 360) + 360
                Else
                    P.X = (P.X - (P.X \ 360) * 360) - 360
                End If
            Else
                P.X = P.X - (P.X \ 360) * 360
            End If
            If P.X < 0 Then
                retPS.x = "西経"
            Else
                retPS.x = "東経"
            End If
            P.X = Math.Abs(P.X)
            P.Y = Math.Abs(P.Y)
        Else
            retPS.x = ""
            retPS.y = ""
        End If
        If clsSettings.Data.Ido_Kedo_Print_Pattern = enmLatLonPrintPattern.DegreeMinuteSecond Then
            Dim LatLonDMS As strLatLonDegreeMinuteSecond = New strLatLon(P).toDegreeMinuteSecond
            With LatLonDMS
                With .LongitudeDMS
                    retPS.x += CStr(.Degree) & "度" & CStr(.Minute) & "分" & Left(CStr(.Second), 4) & "秒"
                End With
                With .LatitudeDMS
                    retPS.y += CStr(.Degree) & "度" & CStr(.Minute) & "分" & Left(CStr(.Second), 4) & "秒"
                End With
            End With
        Else
            retPS.x += clsGeneric.SingleToString(P.X) & "度"
            retPS.y += clsGeneric.SingleToString(P.Y) & "度"
        End If
        Return retPS

    End Function
    ''' <summary>
    ''' 指定したファイル名のフルパスから，ディレクトリ名を取得し，一方のファイル名を追加して返す
    ''' </summary>
    ''' <param name="DefoFile"></param>
    ''' <param name="PlusFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFileDirPlusFileName(ByVal DefoFile As String, ByVal PlusFile As String) As String
        Dim dir As String = System.IO.Path.GetDirectoryName(DefoFile)
        If dir <> "" Then
            dir += "\"

        End If
        dir += PlusFile
        Return dir
    End Function
    ''' <summary>
    ''' フルパス内のフォルダが存在するかチェック
    ''' </summary>
    ''' <param name="FullPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_Folder_Exists(ByVal FullPath As String) As Boolean
        If FullPath = "" Then
            MsgBox("出力ファイルを指定してください。", MsgBoxStyle.Exclamation)
            Return False
        End If
        If System.IO.Path.GetFileName(FullPath) = "" Then
            MsgBox("ファイル名を設定してください。", MsgBoxStyle.Exclamation)
            Return False
        End If
        Dim folder As String = System.IO.Path.GetDirectoryName(FullPath)
        If folder <> "" Then
            If System.IO.Directory.Exists(folder) = False Then
                MsgBox(folder & "が見つかりません。", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If
        Return True
    End Function
    ''' <summary>
    ''' 拡張子を差し替えて返す"."はつけない
    ''' </summary>
    ''' <param name="originalFullPath"></param>
    ''' <param name="newExtension"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReplaceFileExtention(ByVal originalFullPath As String, ByVal newExtension As String)
        Dim dir As String = GetFileDirPlusFileName(originalFullPath, System.IO.Path.GetFileNameWithoutExtension(originalFullPath))
        Return dir + "." + newExtension
    End Function
    ''' <summary>
    ''' 2次元配列aData()の内容から、データ項目ごとに通常、文字列、カテゴリーと分類する
    ''' </summary>
    ''' <param name="DataNum"></param>
    ''' <param name="ObjNum"></param>
    ''' <param name="aData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_DataType(ByVal DataNum As Integer, ObjNum As Integer, ByRef aData(,) As String) As String()
        '
        Dim UNT() As String
        Dim SS As New clsSortingSearch

        ReDim UNT(DataNum - 1)

        For i As Integer = 0 To DataNum - 1
            Dim f As Boolean = True
            For j As Integer = 0 To ObjNum - 1
                Dim L As Integer = Len(aData(i, j))
                If L > 20 Then
                    f = False
                    Exit For
                Else
                    If aData(i, j) <> "" Then
                        If clsGeneric.Check_Suji(aData(i, j)) = False Then
                            f = False
                            Exit For
                        End If
                    End If
                End If
            Next
            If f = False Then
                '文字列のデータ項目の場合
                SS.AddInit(VariantType.String)
                For j As Integer = 0 To ObjNum - 1
                    SS.Add(aData(i, j))
                Next
                SS.AddEnd()
                Dim ctn As Integer = SS.EachValue_Number

                'カテゴリー数が256未満の場合はカテゴリーデータ
                If ctn < 256 Then
                    UNT(i) = "CAT"
                Else
                    UNT(i) = "STR"
                End If
            Else
                UNT(i) = ""
            End If
        Next
        Return UNT

    End Function

    ''' <summary>
    ''' 指定ファイルをダウンロードする。既存の場合はさし替える。
    ''' </summary>
    ''' <param name="PC_Path"></param>
    ''' <param name="URL"></param>
    ''' <param name="SameDateNoDownloadF">1日に複数回ダウンロードしない</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_and_Download_File(ByVal PC_Path As String, ByVal URL As String, ByVal SameDateNoDownloadF As Boolean) As Boolean
        Dim file_exists As Boolean = System.IO.File.Exists(PC_Path)
        Dim wc As New clsWebClient
        Try
            wc.DownloadFile(URL, PC_Path + "2")
            If file_exists = True Then
                System.IO.File.Delete(PC_Path)
            End If
            System.IO.File.Move(PC_Path + "2", PC_Path)
        Catch ex As Exception
            If file_exists = False Then
                MsgBox(ex.Message)
                Return False
            End If
        Finally
            wc.Dispose()
        End Try
        Return True
    End Function
    ''' <summary>
    ''' 指定したURLのファイルをダウンロード
    ''' </summary>
    ''' <param name="URL"></param>
    ''' <param name="SaveFileFullPath"></param>
    ''' <param name="ErrorMessageShowFlag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UrlToFile(ByVal URL As String, SaveFileFullPath As String, ByVal ErrorMessageShowFlag As Boolean) As Boolean


        Try
            Dim wc As New System.Net.WebClient()
            wc.DownloadFile(URL, SaveFileFullPath)
            wc.Dispose()
            Return True
        Catch ex As Exception
            If ErrorMessageShowFlag = True Then
                MsgBox(ex.Message)
            End If
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 指定したURLのファイルをダウンロード
    ''' </summary>
    ''' <param name="URL"></param>
    ''' <param name="filename"></param>
    ''' <param name="SaveFolder"></param>
    ''' <param name="ErrorMessageShowFlag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UrlToFile(ByVal URL As String, ByVal filename As String, ByVal SaveFolder As String, ByVal ErrorMessageShowFlag As Boolean) As Boolean

        Dim strFNAME As String = SaveFolder & "\" & filename 'ダウンロード先（パス＋ファイル名）

        Try
            Dim wc As New System.Net.WebClient()
            wc.DownloadFile(URL, strFNAME)
            wc.Dispose()
            Return True
        Catch ex As Exception
            If ErrorMessageShowFlag = True Then
                MsgBox(ex.Message)
            End If
            Return False
        End Try


    End Function
    ''' <summary>
    ''' フォルダの作成
    ''' </summary>
    ''' <param name="Path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MakeFolder(ByVal Path As String) As Boolean

        Try
            System.IO.Directory.CreateDirectory(Path)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 一時フォルダを作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MakeTempFolder() As String
        Dim tmpFolderName As String = clsGeneric.Make_TempFile()
        If tmpFolderName = "" Then
            Return ""
        End If
        System.IO.File.Delete(tmpFolderName) 'tempファイルが作られるので削除
        If clsGeneric.MakeFolder(tmpFolderName) = False Then
            Return ""
        Else
            Return tmpFolderName
        End If

    End Function
    ''' <summary>
    ''' mpfz,mdrz,mdrmz用に一時フォルダ作成、エラーの場合は""を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MakeTempFolder_forZip() As String
        '一時フォルダを作成
        Dim tmpFolderName As String = clsGeneric.Make_TempFile()
        If tmpFolderName = "" Then
            Return ""
        End If
        System.IO.File.Delete(tmpFolderName) 'tempファイルが作られるので削除
        If clsGeneric.MakeFolder(tmpFolderName) = False Then
            Return ""
        End If
        Return tmpFolderName
    End Function
    ''' <summary>
    ''' mpfz,mdrz,mdrmz用に一時フォルダ内のファイルを圧縮保存し、一時フォルダを削除
    ''' </summary>
    ''' <param name="FolderName"></param>
    ''' <param name="FileFullPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CompressFolder_and_DeleteTempFolder(ByVal FolderName As String, ByVal FileFullPath As String) As Boolean
        If System.IO.File.Exists(FileFullPath) = True Then
            System.IO.File.Delete(FileFullPath)
        End If
        Try
            'xmlファイル用のフォルダ内を圧縮し、指定したパスのファイル名で保存する
            System.IO.Compression.ZipFile.CreateFromDirectory(FolderName, FileFullPath, System.IO.Compression.CompressionLevel.Optimal, False, System.Text.Encoding.GetEncoding("shift_jis"))
            '作成した一時フォルダを削除
            System.IO.Directory.Delete(FolderName, True)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' tempフォルダに一時ファイルを作成する際のファイル名を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Make_TempFile() As String

        Try
            Dim name As String = System.IO.Path.GetTempFileName()
            Return name
        Catch ex As Exception
            MsgBox("一時ファイルが作成できませんでした。", vbExclamation)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' 指定した線種が，画面に表示される模様かどうかを調べる
    ''' </summary>
    ''' <param name="LPat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_Line_PrintPattern(LPat As Line_Property) As Boolean
        With LPat
            If .BasicLine.pattern <> -1 Or .CrossLine.XLine_f = True Or _
                    (.ParallelLine.P_Line_f = True And .ParallelLine.InnerColor_f = True) Then
                Return True
            Else
                Return False
            End If
        End With
    End Function

    ''' <summary>
    ''' KtGRIDコントロールにクリップボードの緯度経度データを貼り付ける(緯度経度でなくても可)
    ''' </summary>
    ''' <param name="KtGrid">KtGRIDコントロール</param>
    ''' <param name="LatLonXStartPos">緯度経度のグリッドの左側のX位置(緯度経度でない場合は省略可)</param>
    ''' <param name="LatFirstFlag">緯度が左の場合true</param>
    ''' <returns>表示されたらtue</returns>
    ''' <remarks></remarks>
    Public Shared Function Set_ClipIdoKedo_to_KtgisGrid(ByRef KtGrid As KTGISUserControl.KTGISGrid,
                                                              Optional ByVal LatLonXStartPos As Integer = -1, Optional ByVal LatFirstFlag As Boolean = True) As Boolean
        Dim clipText As String = Clipboard.GetText
        If clipText = "" Then
            Dim msgText1 As String = "クリップボードにデータがありません。"
            MsgBox(msgText1, MsgBoxStyle.Exclamation)
            Return False
        End If
        If Microsoft.VisualBasic.Right(clipText, 2) = vbCrLf Then
            clipText = Mid(clipText, 1, Len(clipText) - 2)
        End If
        Dim STR() As String = Split(clipText, vbCrLf)

        With KtGrid
            Dim xs As Integer = .Xsize(0)
            Dim ys As Integer = .Ysize(0)
            If ys < STR.Length Then
                .AddObject(0, 0, STR.Length - ys)
            ElseIf STR.Length < ys Then
                .RemoveObject(0, 0, ys - STR.Length)
            End If

            If LatLonXStartPos <> -1 Then
                If LatFirstFlag = True Then
                    .FixedYSData(0, LatLonXStartPos, 0) = "緯度"
                    .FixedYSData(0, LatLonXStartPos + 1, 0) = "経度"
                Else
                    .FixedYSData(0, LatLonXStartPos, 0) = "経度"
                    .FixedYSData(0, LatLonXStartPos + 1, 0) = "緯度"
                End If
            End If

            For i As Integer = 0 To STR.Length - 1
                Dim sp() As String = Split(STR(i), vbTab)
                For j As Integer = 0 To xs - 1
                    If j <= sp.GetUpperBound(0) Then
                        .GridData(0, j, i) = Trim(sp(j))
                    End If
                Next
            Next
            .Refresh()
        End With
        Return True
    End Function
    ''' <summary>
    ''' ２バイト文字が含まれる場合はTrueを返す
    ''' </summary>
    ''' <param name="strWord"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function check_Moji(ByVal strWord As String) As Boolean

        For i As Integer = 1 To Len(strWord)
            Dim lWk As Integer = Asc(Mid(strWord, i, 1))
            If lWk < 0 Or lWk > 255 Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' 数字と．- 以外が含まれる場合はfalseを返す
    ''' </summary>
    ''' <param name="SujiWord"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_Suji(ByVal SujiWord As String) As Boolean
        Dim f As Boolean = True
        Dim pointNum As Integer = 0
        Dim minusNum As Integer = 0
        Dim comma As Integer = 0
        Dim spc As Integer = 0
        If SujiWord = "" Or SujiWord = "-" Then
            Return False
        End If
        For i As Integer = 1 To Len(SujiWord)
            Dim lWk As String = Asc(Mid(SujiWord, i, 1))
            If (lWk <= 57 And lWk >= 48) Then
            ElseIf lWk = 32 Then
                spc += 1
            ElseIf lWk = 44 Then
                comma += 1
            ElseIf lWk = 45 Then
                minusNum += 1
            ElseIf lWk = 46 Then
                pointNum += 1
            Else
                f = False
                Exit For
            End If
        Next
        If f = False Then
            If InStr(UCase(SujiWord), "E+") <> 0 Or InStr(UCase(SujiWord), "E-") <> 0 Then
                f = True
            End If
        Else
            If 1 < pointNum Or 1 < minusNum Or spc = Len(SujiWord) Then
                f = False
            End If
        End If
        Return f
    End Function
    ''' <summary>
    ''' 緯度経度の文字列値をチェック（数字以外の文字、90度以上の緯度）する
    ''' </summary>
    ''' <param name="STValue1">文字列1</param>
    ''' <param name="STValue2">文字列2</param>
    ''' <param name="LatFirstFlag">文字列1が緯度の場合true</param>
    ''' <param name="Ido">緯度（戻り値）</param>
    ''' <param name="Kedo">経度（戻り値）</param>
    ''' <param name="MessageHeader">エラーメッセージの先頭に付けるヘッダ</param>
    ''' <param name="Message">エラーメッセージ（戻り値、初期化は行わない）</param>
    ''' <returns>OKの場合true</returns>
    ''' <remarks></remarks>
    Public Shared Function Check_IdoKedo_Value(ByVal STValue1 As String, ByVal STValue2 As String, ByVal LatFirstFlag As Boolean,
                                        ByRef Ido As Single, ByRef Kedo As Single, ByVal MessageHeader As String, ByRef Message As String) As Boolean
        Dim Msg As String = ""
        Dim f As Boolean = True
        If STValue1 = "" Or STValue2 = "" Then
            Msg += MessageHeader + "緯度または経度が未設定です。" + vbCrLf
            f = False
        Else

            If clsGeneric.Check_Suji(STValue1) = False Or clsGeneric.Check_Suji(STValue2) = False Then
                Msg += MessageHeader + "緯度・経度に半角数字以外の文字が含まれています。" + vbCrLf
                f = False
            Else
                Dim st1 As Single = Val(STValue1)
                Dim st2 As Single = Val(STValue2)
                Dim cIdo As Single
                If LatFirstFlag = True Then
                    cIdo = st1
                Else
                    cIdo = st2
                End If
                If Math.Abs(cIdo) > 90 Then
                    Msg += MessageHeader + "緯度が90度を超えています。" + vbCrLf
                    f = False
                Else
                    If LatFirstFlag = True Then
                        Ido = st1
                        Kedo = st2
                    Else
                        Kedo = st1
                        Ido = st2
                    End If
                End If
            End If
        End If
        Message += Msg
        Return f
    End Function
    ''' <summary>
    ''' 数値から小数点以下、以上の桁数を返す
    ''' </summary>
    ''' <param name="a"></param>
    ''' <param name="L"></param>
    ''' <param name="R"></param>
    ''' <remarks></remarks>
    Public Shared Sub Figure_Arrange(ByVal a As Double, ByRef L As Integer, ByRef R As Integer)

        If a = 0 Then
            L = 1
        Else
            'Dim L1 As Double, L2 As Double
            'L1 = Math.Log(Math.Abs(a))
            'L2 = Val(Str(L1 / Math.Log(10)))
            'L += 1
            L = Int(Math.Log10(Math.Abs(a))) + 1
        End If

        Dim b As String = CStr(a)
        Dim c As Integer = InStr(b, ".")
        If c = 0 Or InStr(b$, "E+") <> 0 Then
            R = 0
        ElseIf InStr(b, "E-") <> 0 Then
            R = Len(b) - InStr(b$, "E") + Val(Mid(b, InStr(b, "-") + 1))
        Else
            R = Len(Mid(b, c + 1))
        End If
        If L < 0 Then L = 0

    End Sub
    Public Shared Function Figure_Using_Solo(ByVal Val As Double, ByVal Commma_f As Boolean) As String
        Dim L As Integer, r As Integer
        Figure_Arrange(Val, L, r)
        If L = 0 Then
            L = 1
        End If
        If Val < 0 Then
            L += 1
        End If
        Return Figure_Using(Val, L, r, Commma_f)
    End Function
    ''' <summary>
    ''' 指定した数値を、指定した小数点以下桁数の文字列に変換して返す
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <param name="LeftOfDecimalPoint">小数点の左側の桁数</param>
    ''' <param name="RightOfDecimaplPoint">小数点の右側の桁数</param>
    ''' <param name="Comma_f"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Figure_Using(ByVal Value As Double,
                                        ByVal RightOfDecimaplPoint As Integer) As String
        Dim FL As String = FormatNumber(Value, RightOfDecimaplPoint, True, False, TriState.False)
        Return FL
    End Function
    ''' <summary>
    ''' 指定した数値を、指定した桁数・小数点以下桁数の文字列に変換して返す
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <param name="LeftOfDecimalPoint">小数点の左側の桁数</param>
    ''' <param name="RightOfDecimaplPoint">小数点の右側の桁数</param>
    ''' <param name="Comma_f"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Figure_Using(ByVal Value As Integer, ByVal LeftOfDecimalPoint As Integer,
                                        ByVal RightOfDecimaplPoint As Integer, ByVal Comma_f As Boolean) As String
        Dim FL As String
        Dim Comma_Num As Integer
        Dim Num As Integer
        If Comma_f = True Then
            Comma_Num = (LeftOfDecimalPoint - 1) \ 3
        Else
            Comma_Num = 0
        End If
        Num = Comma_Num + LeftOfDecimalPoint + RightOfDecimaplPoint
        If RightOfDecimaplPoint > 0 Then
            Num += 1
        End If
        FL = Space(LeftOfDecimalPoint) & FormatNumber(Value, RightOfDecimaplPoint, True, False, Comma_f)
        FL = Microsoft.VisualBasic.Right(FL, Num)
        Return FL
    End Function
    ''' <summary>
    ''' 指定した数値を、指定した桁数・小数点以下桁数の文字列に変換して返す
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <param name="LeftOfDecimalPoint">小数点の左側の桁数</param>
    ''' <param name="RightOfDecimaplPoint">小数点の右側の桁数</param>
    ''' <param name="Comma_f"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Figure_Using(ByVal Value As Double, ByVal LeftOfDecimalPoint As Integer,
                                        ByVal RightOfDecimaplPoint As Integer, ByVal Comma_f As Boolean) As String
        Dim FL As String
        Dim Comma_Num As Integer
        Dim Num As Integer
        If Comma_f = True Then
            Comma_Num = (LeftOfDecimalPoint - 1) \ 3
        Else
            Comma_Num = 0
        End If
        Num = Comma_Num + LeftOfDecimalPoint + RightOfDecimaplPoint
        If RightOfDecimaplPoint > 0 Then
            Num += 1
        End If
        FL = Space(LeftOfDecimalPoint) & FormatNumber(Value, RightOfDecimaplPoint, True, False, Comma_f)
        FL = Microsoft.VisualBasic.Right(FL, Num)
        Return FL
    End Function
    ''' <summary>
    ''' 指定した数値を、指定した桁数・小数点以下桁数の文字列に変換して返す
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <param name="LeftOfDecimalPoint">小数点の左側の桁数</param>
    ''' <param name="RightOfDecimaplPoint">小数点の右側の桁数</param>
    ''' <param name="Comma_f"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Figure_Using(ByVal Value As Single, ByVal LeftOfDecimalPoint As Integer,
                                        ByVal RightOfDecimaplPoint As Integer, ByVal Comma_f As Boolean) As String
        Dim FL As String
        Dim Comma_Num As Integer
        Dim Num As Integer
        If Comma_f = True Then
            Comma_Num = (LeftOfDecimalPoint - 1) \ 3
        Else
            Comma_Num = 0
        End If
        Num = Comma_Num + LeftOfDecimalPoint + RightOfDecimaplPoint
        If RightOfDecimaplPoint > 0 Then
            Num += 1
        End If
        FL = Space(LeftOfDecimalPoint) & FormatNumber(Value, RightOfDecimaplPoint, True, False, Comma_f)
        FL = Microsoft.VisualBasic.Right(FL, Num)
        Return FL
    End Function
    ''' <summary>
    ''' 指定した数値を、必要な場合カンマをつけて返す
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <param name="Comma_f"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Figure_Using(ByVal Value As Double, ByVal Comma_f As Boolean) As String
        Dim L As Integer, r As Integer
        Figure_Arrange(Value, L, r)
        If L = 0 Then
            L = 1
        End If
        If Value < 0 Then
            L += 1
        End If
        Return Figure_Using(Value, L, r, Comma_f)
    End Function
    ''' <summary>
    ''' 数値の小数点以下、以上の桁数を求める
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns>strDecimalPointNumber構造体</returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Figure_Arrange(ByVal Value As Double) As strDecimalPointNumber
        Dim L1 As Double, L2 As Double
        Dim Left As Integer
        Dim Right As Integer

        If Value = 0 Then
            Left = 1
        Else
            L1 = Math.Log(Math.Abs(Value))
            L2 = Val(Str(L1 / Math.Log(10)))
            Left = Int(L2)
            Left += 1
        End If
        Dim b As String = CStr(Value)
        Dim c As Integer = InStr(b, ".")
        If c = 0 Or InStr(b, "E+") <> 0 Then
            Right = 0
        ElseIf InStr(b, "E-") <> 0 Then
            Right = Len(b) - InStr(b, "E") + Val(Mid(b, InStr(b, "-") + 1))
        Else
            Right = Len(Mid(b, c + 1))
        End If
        If Left < 0 Then
            Left = 0

        End If
        Dim deciP As strDecimalPointNumber
        deciP.Left_Of_Decimal_Point = Left
        deciP.Right_Of_Decimal_Point = Right
        Return deciP
    End Function
    ''' <summary>
    ''' 数値の小数点以下、以上の桁数を求める
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns>strDecimalPointNumber構造体</returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Figure_Arrange(ByVal Value As Single) As strDecimalPointNumber
        Dim L1 As Double, L2 As Double
        Dim Left As Integer
        Dim Right As Integer

        If Value = 0 Then
            Left = 1
        Else
            L1 = Math.Log(Math.Abs(Value))
            L2 = Val(Str(L1 / Math.Log(10)))
            Left = Int(L2)
            Left += 1
        End If
        Dim b As String = CStr(Value)
        Dim c As Integer = InStr(b, ".")
        If c = 0 Or InStr(b, "E+") <> 0 Then
            Right = 0
        ElseIf InStr(b, "E-") <> 0 Then
            Right = Len(b) - InStr(b, "E") + Val(Mid(b, InStr(b, "-") + 1))
        Else
            Right = Len(Mid(b, c + 1))
        End If
        If Left < 0 Then
            Left = 0

        End If
        Dim deciP As strDecimalPointNumber
        deciP.Left_Of_Decimal_Point = Left
        deciP.Right_Of_Decimal_Point = Right
        Return deciP
    End Function
    ''' <summary>
    ''' リストビュー形式でデータを表示
    ''' </summary>
    ''' <param name="Owner">オーナーフォーム</param>
    ''' <param name="Title">タイトル</param>
    ''' <param name="ListData">表示する配列データ・横方向はタブ区切り</param>
    ''' <param name="VariType">ヘッダの列数分の配列、VariTypeはStringとそれ以外しかない</param>
    ''' <param name="SortingFlag">ヘッダの列数分の配列で、並べ替えをするか。Falseの場合列の並べ替えは無し、ヘッダの列数分の配列</param>
    ''' <param name="RowNumberFlag">trueにすると左端に行番号がつく</param>
    ''' <param name="ModalFlag">Modalの場合true</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Message(ByVal Owner As IWin32Window, ByVal Title As String, ByVal ListData As List(Of String), _
                                         ByRef VariType() As VariantType, ByRef SortingFlag() As Boolean,
                                         ByVal RowNumberFlag As Boolean, ByVal ModalFlag As Boolean) As Windows.Forms.DialogResult
        Dim form As New frmMessage
        If ModalFlag = True Then
            Dim val As Windows.Forms.DialogResult = form.ShowDialog(Owner, Title, ListData, VariType, SortingFlag, RowNumberFlag)
            form.Dispose()
            Return val
        Else
            form.Show(Owner, Title, ListData, VariType, SortingFlag, RowNumberFlag)
        End If
    End Function
    ''' <summary>
    ''' テキスト形式でメッセージを表示
    ''' </summary>
    ''' <param name="Owner">オーナーフォーム</param>
    ''' <param name="Title">タイトル</param>
    ''' <param name="MessageText">メッセージテキスト(ModalFlag=trueの場合、変更後のテキストに置き換える)</param>
    ''' <param name="ReadOnlyF">読み取り専用の場合true</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Message(ByVal Owner As IWin32Window, ByVal Title As String, ByRef MessageText As String,
                                             ByVal ReadOnlyF As Boolean, ByVal ModalFlag As Boolean) As Windows.Forms.DialogResult
        Dim form As New frmMessage
        If ModalFlag = True Then
            Dim val As Windows.Forms.DialogResult = form.ShowDialog(Owner, Title, MessageText, ReadOnlyF)
            If val = DialogResult.OK Then
                MessageText = form.getResult
            End If
            form.Dispose()
            Return val
        Else
            form.Show(Owner, Title, MessageText, ReadOnlyF)
        End If
    End Function
    ''' <summary>
    ''' グリッド形式でメッセージを表示
    ''' </summary>
    ''' <param name="Owner"></param>
    ''' <param name="Title"></param>
    ''' <param name="GridText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Message(ByVal Owner As IWin32Window, ByVal Title As String, ByRef GridText As String) As Windows.Forms.DialogResult
        Dim Grid(,) As String = String_Cut_By_CRLF_TAB(GridText, vbCrLf, vbTab)
        Dim form As New frmMessage
        Dim s As System.Windows.Forms.Screen = System.Windows.Forms.Screen.FromControl(form)
        form.Size = New Size(s.Bounds.Width / 2, s.Bounds.Height / 2)
        form.StartPosition = FormStartPosition.CenterScreen
        form.ShowDialog(Owner, Title, Grid)

    End Function
    ''' <summary>
    ''' オブジェクト名の漢字を統一する。比較する漢字が含まれていた場合にtrue
    ''' </summary>
    ''' <param name="objName">オブジェクト名（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ObjName_Kanji_Compatible(ByRef objName As String) As Boolean
        Dim Word_Compatible() As String = clsSettings.Data.ObjectName_Word_Compatible.Split("|")
        Dim f As Boolean = False

        Dim oldCharacter As String = "亞圍壹飮榮艷應毆穩壞覺樂寬罐陷戲據峽鄕驅徑溪莖鷄缺圈獻險嚴恆國濟劑慘贊絲兒實釋獸肅緖敍稱剩條疊囑愼盡醉數聲攝專潛錢壯插裝續對臺澤擔彈遲鑄敕遞點黨當獨屆貳霸發濱福變辨舖寶餠藥餘搖來龍獵禮齡戀爐朗惡爲隱衞圓鹽橫假畫繪擴學勸歡觀顏歸龜犧擧挾勳惠經螢藝儉檢顯效鑛碎櫻雜棧殘辭舍壽從縱處奬燒證壤淨讓觸眞圖隨樞靜竊戰纖禪總騷臟墮帶瀧單膽斷晝鎭鐵傳盜讀繩惱廢賣髮甁拂邊瓣襃沒萬譯與樣賴覽綠隸勞樓灣壓醫稻營驛奧歐價會懷殼嶽卷關氣僞舊狹曉區薰繼輕劍權縣驗廣號黑齋册參蠶齒濕寫收澁諸將祥乘孃釀寢神粹髓瀨齊淺踐曾雙搜爭莊增藏屬體滯擇團癡蟲廳聽塚轉都燈德腦拜麥拔蠻祕佛竝辯穗豐飜滿默彌豫譽謠亂隆兩壘勵靈"
        Dim newCharacter As String = "亜囲壱飲栄艶応殴穏壊覚楽寛缶陥戯拠峡郷駆径渓茎鶏欠圏献険厳恒国済剤惨賛糸児実釈獣粛緒叙称剰条畳嘱慎尽酔数声摂専潜銭壮挿装続対台沢担弾遅鋳勅逓点党当独届弐覇発浜福変弁舗宝餅薬余揺来竜猟礼齢恋炉朗悪為隠衛円塩横仮画絵拡学勧歓観顔帰亀犠挙挟勲恵経蛍芸倹検顕効鉱砕桜雑桟残辞舎寿従縦処奨焼証壌浄譲触真図随枢静窃戦繊禅総騒臓堕帯滝単胆断昼鎮鉄伝盗読縄悩廃売髪瓶払辺弁褒没万訳与様頼覧緑隷労楼湾圧医稲営駅奥欧価会懐殻岳巻関気偽旧狭暁区薫継軽剣権県験広号黒斎冊参蚕歯湿写収渋諸将祥乗嬢醸寝神粋髄瀬斉浅践曽双捜争荘増蔵属体滞択団痴虫庁聴塚転都灯徳脳拝麦抜蛮秘仏並弁穂豊翻満黙弥予誉謡乱隆両塁励霊"



        For i As Integer = 0 To Word_Compatible.GetUpperBound(0)
            For j As Integer = 1 To Word_Compatible(i).Length
                Dim k As Integer = InStr(objName, Mid$(Word_Compatible(i), j, 1))
                If k <> 0 Then
                    Mid(objName, k, 1) = Word_Compatible(i)
                    f = True
                End If
            Next
        Next

        If clsSettings.Data.KatakanaCheck = True Then
            Dim katakana(2, 1) As String
            katakana(0, 0) = "ヴァ"
            katakana(0, 1) = "バ"
            katakana(1, 0) = "ティ"
            katakana(1, 1) = "チ"
            katakana(2, 0) = "ヴェ"
            katakana(2, 1) = "ベ"
            For i As Integer = 0 To 2
                Dim k As Integer = objName.IndexOf(katakana(i, 0))
                If k <> -1 Then
                    objName = objName.Replace(katakana(i, 0), katakana(i, 1))
                    f = True
                End If
            Next
        End If


        '新字体旧字体比較
        If clsSettings.Data.SinKyuCharacter = True Then
            For j As Integer = 1 To Len(objName)
                Dim k As Integer = InStr(oldCharacter, Mid(objName, j, 1))
                If k <> 0 Then
                    Mid(objName, j, 1) = Mid(newCharacter, k, 1)
                    f = True
                End If
            Next
        End If

        Return f
    End Function

    ''' <summary>
    ''' タイル内の記号設定呼び出し
    ''' </summary>
    ''' <param name="TileMK">元のタイル記号兼戻り値</param>
    ''' <param name="ScrData">screen_info</param>
    ''' <param name="pictureFlag">画像を選択できるようにするか</param>
    ''' <returns>OKならtrue</returns>
    ''' <remarks></remarks>
    Public Shared Function TileMark_Set(ByRef TileMK As Tile_Mark_Property, ByVal InnerColor As colorARGB,
                                        ByRef _attrData As clsAttrData, ByVal pictureFlag As Boolean) As Boolean
        Dim form As New frmHatch_Mark
        Dim f As Boolean = (form.ShowDialog(TileMK, InnerColor, _attrData, pictureFlag) = Windows.Forms.DialogResult.OK)
        If f = True Then
            TileMK = form.getResult()
        End If
        form.Dispose()
        Return f
    End Function

    ''' <summary>
    ''' 記号設定呼び出し
    ''' </summary>
    ''' <param name="MK">元の記号兼戻り値</param>
    ''' <param name="ScrData">screen_info</param>
    ''' <returns>OKならtrue</returns>
    ''' <remarks></remarks>
    Public Shared Function Mark_Set(ByRef MK As Mark_Property, ByRef _attrData As clsAttrData) As Boolean
        Dim form As New frmMark_Set
        Dim f As Boolean = (form.ShowDialog(MK, _attrData) = Windows.Forms.DialogResult.OK)
        If f = True Then
            MK = form.getResult()
        End If
        form.Dispose()
        Return f
    End Function
    ''' <summary>
    ''' ラインパターン選択
    ''' </summary>
    ''' <param name="Lpat">元のラインパターン兼戻り値</param>
    ''' <param name="DetailFlag">詳細ボタンの表示</param>
    ''' <param name="ScrData">screen_info</param>
    ''' <returns>OKならtrue</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Line_Pattern_select(ByRef Lpat As Line_Property, ByVal DetailFlag As Boolean,
                                               ByRef attrData As clsAttrData) As Boolean
        Dim form As New frmLpatBasicSelect
        Dim f As Boolean = (form.ShowDialog(Lpat, DetailFlag, attrData) = Windows.Forms.DialogResult.OK)
        If f = True Then
            Lpat = form.getResult()
        End If
        form.Dispose()
        Return f
    End Function
    Public Overloads Shared Function Line_Pattern_select(ByRef picBox As PictureBox, ByRef Lpat As Line_Property, ByVal DetailFlag As Boolean,
                                               ByRef attrData As clsAttrData) As Boolean
        Dim form As New frmLpatBasicSelect
        Dim f As Boolean = (form.ShowDialog(Lpat, DetailFlag, attrData) = Windows.Forms.DialogResult.OK)
        If f = True Then
            Lpat = form.getResult()
            clsDrawLine.Draw_Sample_LineBox(picBox, Lpat, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End If
        form.Dispose()
        Return f
    End Function
    ''' <summary>
    ''' 枠線付き背景設定
    ''' </summary>
    ''' <param name="back"></param>
    ''' <param name="_attrData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function BackGround_Setting(ByRef back As BackGround_Box_Property, ByRef _attrData As clsAttrData) As Boolean
        Dim form As New frmBackgroundSetting
        Dim f As Boolean = (form.ShowDialog(back, _attrData) = Windows.Forms.DialogResult.OK)
        If f = True Then
            back = form.getResult()
        End If
        form.Dispose()
        Return f
    End Function
    ''' <summary>
    ''' 枠線付き背景設定PictureBoxに表示
    ''' </summary>
    ''' <param name="picBox"></param>
    ''' <param name="back"></param>
    ''' <param name="_attrData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function BackGround_Setting(ByRef picBox As PictureBox, ByRef back As BackGround_Box_Property, ByRef _attrData As clsAttrData) As Boolean
        Dim form As New frmBackgroundSetting
        Dim f As Boolean = (form.ShowDialog(back, _attrData) = Windows.Forms.DialogResult.OK)
        If f = True Then
            back = form.getResult()
            clsDrawTile.Darw_Sample_BackGroundBox(picBox, back, _attrData.TotalData.ViewStyle.ScrData, _attrData.TotalData.BasePicture)
        End If
        form.Dispose()
        Return f
    End Function
    ''' <summary>
    ''' ハッチパターン選択
    ''' </summary>
    ''' <param name="T"></param>
    ''' <param name="ScrData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Tile_Set(ByRef T As Tile_Property,
                                               ByRef _attrData As clsAttrData) As Boolean
        Dim form As New frmHatchSelecter
        Dim f As Boolean = (form.ShowDialog(T, _attrData) = Windows.Forms.DialogResult.OK)
        If f = True Then
            T = form.getResult()
        End If
        form.Dispose()
        Return f

    End Function
    Public Shared Function Font_select(ByRef Font As Font_Property,
                                               ByRef _attrData As clsAttrData) As Boolean
        Dim form As New frmFontSelect
        Dim f As Boolean = form.ShowDialog(Font, _attrData) = Windows.Forms.DialogResult.OK
        If f = True Then
            Font = form.getResult()
        End If
        form.Dispose()
        Return f
    End Function
    ''' <summary>
    ''' KTGridに設定した初期属性の単位等をそろえる
    ''' </summary>
    ''' <param name="KtgisGrid">グリッドコントロール</param>
    ''' <param name="Layernum">対象レイヤ</param>
    ''' <remarks></remarks>
    Public Shared Sub Check_DataKind_and_Allignment(ByRef KtgisGrid As KTGISUserControl.KTGISGrid, ByVal Layernum As Integer, ByVal layerType As clsAttrData.enmLayerType)
        '
        With KtgisGrid
            .FixedUpperLeftData(Layernum, 1, 1) = "データの種類"
            .FixedUpperLeftData(Layernum, 1, 2) = "空白セル"
            .FixedUpperLeftData(Layernum, 1, 3) = "タイトル"
            .FixedUpperLeftData(Layernum, 1, 4) = "単位"

            For i As Integer = 0 To .Xsize(Layernum) - 1

                Dim dtype As enmAttDataType = clsGeneric.getAttDataType_From_TitleUnit(.FixedYSData(Layernum, i, 3), .FixedYSData(Layernum, i, 4))
                .FixedYSData(Layernum, i, 1) = clsGeneric.ConvertAttDataTypeString(dtype)
                Select Case dtype
                    Case enmAttDataType.Normal, enmAttDataType.Lat, enmAttDataType.Lon, enmAttDataType.Arrival, enmAttDataType.Departure
                        .GridAlligntment(Layernum, i) = HorizontalAlignment.Right
                    Case Else
                        .GridAlligntment(Layernum, i) = HorizontalAlignment.Left
                End Select
            Next
        End With

    End Sub
    ''' <summary>
    ''' 属性データ編集の最初のグリッドの設定
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <remarks></remarks>
    Public Shared Sub Set_First_GridCellWidthHeight(ByRef KtgisGrid As KTGISUserControl.KTGISGrid, ByVal Layernum As Integer)
        With KtgisGrid
            .FixedXSWidth(Layernum, 0) = 50
            .FixedXSWidth(Layernum, 1) = 150
            .FixedYSHeight(Layernum, 3) = 38
            .FixedUpperLeftData(Layernum, 1, 1) = "データの種類"
            .FixedUpperLeftData(Layernum, 1, 2) = "空白セル"
            .FixedUpperLeftData(Layernum, 1, 3) = "タイトル"
            .FixedUpperLeftData(Layernum, 1, 4) = "単位"
            .FixedUpperLeftData(Layernum, 1, 5) = "注"

        End With
    End Sub

    ''' <summary>
    ''' 指定のラインパターンの色を一斉に変える
    ''' </summary>
    ''' <param name="Origin_LPat"></param>
    ''' <param name="col"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Set_Same_Color_to_LinePat(ByVal Origin_LPat As Line_Property, ByVal col As colorARGB) As Line_Property
        Dim LP As Line_Property = Origin_LPat
        With LP
            .BasicLine.SolidLine.Color = col
            .ParallelLine.P_CenterLine.SolidLine.Color = col
            With .BasicLine
                .CenterLineParts0.Color = col
                .CenterLineParts1.Color = col
                .CenterLineParts2.Color = col
                .CenterLineParts3.Color = col
                .CenterLineParts4.Color = col
            End With
            With .CrossLine
                .XLineParts0.Color = col
                .XLineParts1.Color = col
                .XLineParts2.Color = col
                .XLineParts3.Color = col
                .XLineParts4.Color = col
            End With
            With .ParallelLine.P_CenterLine
                .CenterLineParts0.Color = col
                .CenterLineParts1.Color = col
                .CenterLineParts2.Color = col
                .CenterLineParts3.Color = col
                .CenterLineParts4.Color = col
            End With
        End With
        Return LP
    End Function
    ''' <summary>
    ''' 指定のラインパターンの幅を一斉に変える
    ''' </summary>
    ''' <param name="Origin_LPat"></param>
    ''' <param name="w"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Set_Same_Width_to_LinePat(ByVal Origin_LPat As Line_Property, ByVal w As Single) As Line_Property

        Dim LP As Line_Property = Origin_LPat

        With LP
            .BasicLine.SolidLine.Width = w
            With .BasicLine
                .CenterLineParts0.Width = w
                .CenterLineParts1.Width = w
                .CenterLineParts2.Width = w
                .CenterLineParts3.Width = w
                .CenterLineParts4.Width = w
            End With
            With .CrossLine
                .XLineParts0.Width = w
                .XLineParts1.Width = w
                .XLineParts2.Width = w
                .XLineParts3.Width = w
                .XLineParts4.Width = w
            End With
        End With
        Return LP
    End Function
    ''' <summary>
    ''' リストボックスのアイテム削除後に、次のインデックスを指定する
    ''' </summary>
    ''' <param name="LstBox"></param>
    ''' <param name="Old_n"></param>
    ''' <remarks></remarks>
    Public Shared Sub ListIndex_Reset(ByRef LstBox As ListBox, ByVal Old_n As Integer)
        '
        If LstBox.Items.Count = 0 Then
            Exit Sub
        End If
        If Old_n = LstBox.Items.Count Then
            LstBox.SelectedIndex = Old_n - 1
        Else
            LstBox.SelectedIndex = Old_n
        End If
    End Sub
    Public Shared Function Color_Set(ByRef col As colorARGB) As Boolean
        Dim form As New frmColor
        Dim f As Boolean = False
        If form.ShowDialog(col) = Windows.Forms.DialogResult.OK Then
            col = form.getResult()
            f = True
        End If
        form.Dispose()
        Return f
    End Function
    Public Shared Function LineEdgePattern_Set(ByRef LineEdgePattern As LineEdge_Connect_Pattern_Data_Info) As Boolean
        Dim form As New frmMakeLineEdgePattern
        Dim f As Boolean = False
        If form.ShowDialog(LineEdgePattern) = Windows.Forms.DialogResult.OK Then
            LineEdgePattern = form.getResult()
            f = True
        End If
        form.Dispose()
        Return f
    End Function
    ''' <summary>
    ''' 条件検索の文字を返す
    ''' </summary>
    ''' <param name="con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getConditionString(ByVal con As clsAttrData.enmCondition)
        Select Case con
            Case clsAttrData.enmCondition.Less
                Return "未満"
            Case clsAttrData.enmCondition.LessEqual
                Return "以下"
            Case clsAttrData.enmCondition.Equal
                Return "等しい"
            Case clsAttrData.enmCondition.GreaterEqual
                Return "以上"
            Case clsAttrData.enmCondition.Greater
                Return "より大きい"
            Case clsAttrData.enmCondition.NotEqual
                Return "以外"
            Case clsAttrData.enmCondition.Include
                Return "含む"
            Case clsAttrData.enmCondition.Exclude
                Return "含まない"
            Case clsAttrData.enmCondition.Head
                Return "先頭の文字"
            Case clsAttrData.enmCondition.Foot
                Return "末尾の文字"
        End Select
    End Function
    ''' <summary>
    ''' 文字列配列をチェックして「新規1」「新規2」など連番を付ける
    ''' </summary>
    ''' <param name="CheckWords">調べる文字</param>
    ''' <param name="Words">既存の文字列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_New_Numbering_Strings(ByVal CheckWords As String, ByVal Words() As String) As String


        Dim L As Integer = Len(CheckWords)
        Dim V As Integer = 0
        For i As Integer = 0 To Words.GetUpperBound(0)
            If Left(Words(i), L) = CheckWords Then
                V = Math.Max(Val(Mid(Words(i), L + 1)), V)
            End If
        Next
        Return CheckWords & CStr(V + 1)
    End Function

    ''' <summary>
    ''' フォームをマウス位置に設定する。画面からはみ出す場合は位置を変える
    ''' </summary>
    ''' <param name="setForm">フォーム</param>
    ''' <param name="VerticalAlignment">垂直位置</param>
    ''' <remarks></remarks>
    Public Shared Sub set_FormPosition_toMousePosition(ByRef setForm As Form, ByVal VerticalAlignment As VisualStyles.VerticalAlignment)
        Dim sc() As Screen = System.Windows.Forms.Screen.AllScreens()

        Dim pos As Point = System.Windows.Forms.Cursor.Position()
        '画面を取得して左端と下端を求める
        Dim ScrrenPos As Integer = 0
        For i As Integer = 0 To sc.GetUpperBound(0)
            With sc(i)
                If spatial.Check_PointInBox(pos, 0, .Bounds) Then
                    ScrrenPos = i
                    Exit For
                End If
            End With
        Next

        Select Case VerticalAlignment
            Case VisualStyles.VerticalAlignment.Center
                pos.Y -= setForm.Height / 2
            Case VisualStyles.VerticalAlignment.Top
                pos.Y -= SystemInformation.CaptionHeight
                pos.Y -= 20
            Case VisualStyles.VerticalAlignment.Bottom
                pos.Y -= setForm.Height
        End Select
        pos.X += 10
        Dim scrW As Integer = sc(ScrrenPos).WorkingArea.Width
        Dim scrH As Integer = sc(ScrrenPos).WorkingArea.Height
        If pos.X + setForm.Width > sc(ScrrenPos).WorkingArea.X + scrW Then
            pos.X = sc(ScrrenPos).WorkingArea.X + scrW - setForm.Width - 5
        End If
        If pos.Y < sc(ScrrenPos).WorkingArea.Y Then
            pos.Y = sc(ScrrenPos).WorkingArea.Y
        End If
        If pos.Y + setForm.Height > sc(ScrrenPos).WorkingArea.Y + scrH Then
            pos.Y = sc(ScrrenPos).WorkingArea.Y + scrH - setForm.Height - 5
        End If
        setForm.Location = pos
    End Sub
    ''' <summary>
    ''' スペース、カンマ、タブで区切る
    ''' </summary>
    ''' <param name="Wo">文字列</param>
    ''' <param name="Spliter">スペース、カンマ、タブ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function String_Cut(ByVal Wo As String, ByVal Spliter As String) As String()

        Dim i As Integer, ST As Integer, wf As Boolean
        Dim w As String
        Dim cn As Long, qua_f As Boolean, Cutw As String, inf As Boolean
        Dim CUT As New List(Of String)
        Dim vbQuate As String = Chr(34)

        If Len(Wo) = 0 Then
            Return Nothing
        End If
        cn = 0

        Select Case Spliter
            Case " "  'スペース区切り
                If Wo = Space(Len(Wo)) Then
                    Return Nothing
                End If
                While Left(Wo, 1) = " "
                    Wo = Mid(Wo, 2)
                End While
                Wo += " "
                qua_f = False
                ST = 1
                For i = 1 To Len(Wo)
                    w = Mid(Wo, i, 1)
                    If w = vbQuate Then
                        qua_f = Not qua_f
                    End If
                    Select Case w
                        Case " "
                            If qua_f = False Then
                                Cutw = Mid(Wo, ST, i - ST)
                                If Left(Cutw, 1) = vbQuate Then
                                    Cutw = Mid(Cutw, 2)
                                End If
                                If Right(Cutw, 1) = vbQuate Then
                                    Cutw = Mid(Cutw, 1, Len(Cutw) - 1)
                                End If
                                CUT.Add(Cutw)
                                While Mid(Wo, i, 1) = " "
                                    i += 1
                                End While
                                ST = i
                                i -= 1
                            End If
                    End Select
                Next
                Return CUT.ToArray
            Case ","  'カンマ区切り
                Wo += ","
                qua_f = False
                wf = False

                ST = 1
                For i = 1 To Len(Wo)
                    w = Mid(Wo, i, 1)
                    Select Case w
                        Case vbQuate
                            qua_f = Not qua_f
                            wf = True
                            If qua_f = True Then
                                ST = i
                            End If
                        Case ","
                            If qua_f = False Then
                                If wf = False Then
                                    Cutw = Trim(Mid(Wo, ST, i - ST))
                                    ST = i + 1
                                Else
                                    Cutw = Mid(Wo, ST + 1, i - ST - 2)
                                    ST = i + 1
                                    wf = False
                                End If
                                CUT.Add(Cutw)
                            End If
                    End Select
                Next
                Dim str As String() = CUT.ToArray
                Return str
            Case vbTab 'タブ区切り
                Dim RetCut() As String = Strings.Split(Wo, vbTab, )
                For i = 0 To RetCut.Length - 1
                    RetCut(i) = Trim(RetCut(i))
                Next
                Return RetCut
        End Select

    End Function
    ''' <summary>
    ''' 指定の文字で区切って二次元配列にに
    ''' </summary>
    ''' <param name="StringData"></param>
    ''' <param name="delimiter1">行末端の文字</param>
    ''' <param name="delimiter2">列区切りの文字</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function String_Cut_By_CRLF_TAB(ByRef StringData As String, ByVal delimiter1 As String, ByVal delimiter2 As String) As String(,)
        'CR(Chr$(13) & Chr$(10))で区切り、

        If StringData = "" Then
            Return Nothing
            Exit Function
        End If

        Dim SplitCRLF() As String = Split(StringData, delimiter1)
        Dim SPG As New List(Of String())
        Dim ys As Integer = SplitCRLF.Length
        Dim xs As Integer = 0
        For i As Integer = 0 To ys - 1
            Dim CPTemp() As String = Split(SplitCRLF(i), delimiter2)
            SPG.Add(CPTemp)
            xs = Math.Max(xs, CPTemp.Length)
        Next

        Dim CP2(xs - 1, ys - 1) As String
        For i As Integer = 0 To ys - 1
            Dim tx() As String = SPG(i)
            For j As Integer = 0 To tx.Length - 1
                CP2(j, i) = tx(j)
            Next
        Next
        Return CP2
    End Function



    ''' <summary>
    ''' 検査値がMinより小さければMinを返し、Maxより大きければMaxを返す
    ''' </summary>
    ''' <param name="V">検査値</param>
    ''' <param name="Min">最小値</param>
    ''' <param name="Max">最大値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function m_min_max(ByVal V As Integer, ByVal Min As Integer, ByVal Max As Integer) As Integer
        If V < Min Then
            Return Min
        End If
        If V > Max Then
            Return Max
        End If
        Return V
    End Function
    ''' <summary>
    ''' 検査値がMinより小さければMinを返し、Maxより大きければMaxを返す
    ''' </summary>
    ''' <param name="V">検査値</param>
    ''' <param name="Min">最小値</param>
    ''' <param name="Max">最大値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function m_min_max(ByVal V As Single, ByVal Min As Single, ByVal Max As Single) As Single
        If V < Min Then
            Return Min
        End If
        If V > Max Then
            Return Max
        End If
        Return V
    End Function
    ''' <summary>
    ''' チェックする値が二つの数字の中間であればtrue
    ''' </summary>
    ''' <param name="CheckV">チェックする値</param>
    ''' <param name="V1"></param>
    ''' <param name="V2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_Two_Value_In(ByVal CheckV As Integer, ByVal V1 As Integer, ByVal V2 As Integer) As chvValue_on_twoValue


        If CheckV = V1 Or CheckV = V2 Then
            Return chvValue_on_twoValue.chvJust
        Else
            If V1 < V2 Then
                If V1 < CheckV And CheckV < V2 Then
                    Return chvValue_on_twoValue.chvIN
                End If
            Else
                If V2 < CheckV And CheckV < V1 Then
                    Return chvValue_on_twoValue.chvIN
                End If
            End If
            Return chvValue_on_twoValue.chvOuter
        End If

    End Function
    ''' <summary>
    ''' チェックする値が二つの数字の中間であればtrue
    ''' </summary>
    ''' <param name="CheckV">チェックする値</param>
    ''' <param name="V1"></param>
    ''' <param name="V2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_Two_Value_In(ByVal CheckV As Single, ByVal V1 As Single, ByVal V2 As Single) As chvValue_on_twoValue


        If CheckV = V1 Or CheckV = V2 Then
            Return chvValue_on_twoValue.chvJust
        Else
            If V1 < V2 Then
                If V1 < CheckV And CheckV < V2 Then
                    Return chvValue_on_twoValue.chvIN
                End If
            Else
                If V2 < CheckV And CheckV < V1 Then
                    Return chvValue_on_twoValue.chvIN
                End If
            End If
            Return chvValue_on_twoValue.chvOuter
        End If

    End Function
    ''' <summary>
    ''' 指定した配列から、指定した位置を削除して詰める
    ''' </summary>
    ''' <param name="DataArray">詰める配列（戻り値）</param>
    ''' <param name="DeleteNumber">削除する位置の配列</param>
    ''' <remarks></remarks>
    Public Shared Sub DeletePartArray(ByRef DataArray() As Boolean, ByVal DeleteNumber() As Integer)

        Dim OriginNum As Integer = DataArray.GetLength(0)
        Dim ChangeList() As Integer = Get_Convert_Array_of_DeletePartArray_new2old(OriginNum, DeleteNumber, -1)

        Dim newNum = ChangeList.GetLength(0)
        Dim newData(newNum - 1) As Boolean
        For i As Integer = 0 To newNum - 1
            newData(i) = DataArray(ChangeList(i))
        Next
        DataArray = newData.Clone
    End Sub
    Public Shared Sub DeletePartArray(ByRef DataArray() As Integer, ByVal DeleteNumber() As Integer)

        Dim OriginNum As Integer = DataArray.GetLength(0)
        Dim ChangeList() As Integer = Get_Convert_Array_of_DeletePartArray_new2old(OriginNum, DeleteNumber, -1)

        Dim newNum = ChangeList.GetLength(0)
        Dim newData(newNum - 1) As Integer
        For i As Integer = 0 To newNum - 1
            newData(i) = DataArray(ChangeList(i))
        Next
        DataArray = newData.Clone
    End Sub
    ''' <summary>
    ''' 指定した位置の値を抜いた場合の、旧位置から新しい位置を示す配列を返す。削除された位置は-1
    ''' </summary>
    ''' <param name="OriginNum">全体の数</param>
    ''' <param name="DeleteNumber">削除する位置</param>
    ''' <param name="DeleteNumResult">削除した数（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Convert_Array_of_DeletePartArray_old2new(ByRef OriginNum As Integer, ByVal DeleteNumber() As Integer, ByRef DeleteNumResult As Integer) As Integer()
        Dim DeleteNum As Integer = DeleteNumber.GetLength(0)
        Dim ChangeList(OriginNum - 1) As Integer

        For i As Integer = 0 To DeleteNum - 1
            ChangeList(DeleteNumber(i)) = -1
        Next
        Dim n As Integer = 0
        For i As Integer = 0 To OriginNum - 1
            If ChangeList(i) = -1 Then
                n += 1
            Else
                ChangeList(i) = i - n
            End If
        Next
        DeleteNumResult = n
        Return ChangeList
    End Function
    ''' <summary>
    ''' 指定した位置の値を抜いた場合の、新しい位置から旧位置を示す配列を返す
    ''' </summary>
    ''' <param name="OriginNum">全体の数</param>
    ''' <param name="DeleteNumber">削除する位置</param>
    ''' <param name="DeleteNumResult">削除した数（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Convert_Array_of_DeletePartArray_new2old(ByRef OriginNum As Integer, ByVal DeleteNumber() As Integer, ByRef DeleteNumResult As Integer) As Integer()
        Dim DeleteNum As Integer = DeleteNumber.GetLength(0)
        Dim ChangeList(OriginNum - 1) As Integer
        Dim new2old_List(OriginNum - 1) As Integer

        For i As Integer = 0 To DeleteNum - 1
            ChangeList(DeleteNumber(i)) = -1
        Next
        Dim cvn As Integer = 0
        Dim n As Integer = 0
        For i As Integer = 0 To OriginNum - 1
            If ChangeList(i) = -1 Then
                n += 1
            Else
                new2old_List(cvn) = i
                cvn += 1
            End If
        Next
        DeleteNumResult = n
        ReDim Preserve new2old_List(cvn - 1)
        Return new2old_List
    End Function

    ''' <summary>
    ''' 配列に含まれる値の一覧を返す
    ''' </summary>
    ''' <param name="Data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Get_EachValueArray(ByRef Data() As Integer) As Integer()
        Dim s As New clsSortingSearch()
        s.AddRange(Data.Length, Data)
        Dim retArray() As Integer
        s.getEachValue_Alley(retArray)
        Return retArray
    End Function
    Public Overloads Shared Function Get_EachValueArray(ByRef Data() As String) As String()
        Dim s As New clsSortingSearch()
        s.AddRange(Data.Length, Data)
        Dim retArray() As String
        s.getEachValue_Alley(retArray)
        Return retArray
    End Function
    Public Shared Sub FillArray(ByRef Arr() As Boolean, ByVal value As Boolean)
        '配列を指定した値で埋める
        For i As Integer = 0 To Arr.GetUpperBound(0)
            Arr(i) = value
        Next
    End Sub
    Public Shared Sub FillArray(ByRef Arr() As Integer, ByVal value As Integer)
        '配列を指定した値で埋める
        For i As Integer = 0 To Arr.GetUpperBound(0)
            Arr(i) = value
        Next
    End Sub
    Public Shared Sub FillArray(ByRef Arr() As Single, ByVal value As Single)
        '配列を指定した値で埋める
        For i As Integer = 0 To Arr.GetUpperBound(0)
            Arr(i) = value
        Next
    End Sub

    Public Shared Sub FillArray(ByRef Arr() As Double, ByVal value As Double)
        '配列を指定した値で埋める
        For i As Integer = 0 To Arr.GetUpperBound(0)
            Arr(i) = value
        Next
    End Sub

    Public Shared Function Check_Point_in_screen(ByVal P As PointF, ByRef ScrData As Screen_info, ByVal Mode As Integer) As Boolean
        '定義
        'Mode=0/SRX:SRY  Mode=1/SR:SY
        'ScrData.ScrRectangle.Left = SRX(0): ScrData.ScrRectangle.Top = SRY(0)
        'ScrData.ScrRectangle.Right = SRX(MapScreen.ScaleWidth): ScrData.ScrRectangle.bottom = SRY(MapScreen.ScaleHeight)

        Select Case Mode
            Case 0
                Return ScrData.ScrRectangle.Contains(P)
            Case 1
                Return ScrData.MapScreen_Scale.Contains(P.X, P.Y)
        End Select
    End Function
    ''' <summary>
    ''' 単独表示モードの文字列を返す
    ''' </summary>
    ''' <param name="solomode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getSolomodeStrings(ByVal solomode As enmSoloMode_Number)
        Select Case solomode
            Case enmSoloMode_Number.ClassPaintMode
                Return "ペイント"
            Case enmSoloMode_Number.MarkSizeMode
                Return "記号の大きさ"
            Case enmSoloMode_Number.MarkBlockMode
                Return "記号の数"
            Case enmSoloMode_Number.ContourMode
                Return "等値線"
            Case enmSoloMode_Number.ClassHatchMode
                Return "ハッチ"
            Case enmSoloMode_Number.ClassMarkMode
                Return "階級記号"
            Case enmSoloMode_Number.ClassODMode
                Return "線"
            Case enmSoloMode_Number.MarkTurnMode
                Return "記号の回転"
            Case enmSoloMode_Number.MarkBarMode
                Return "棒の高さ"
            Case enmSoloMode_Number.StringMode
                Return "文字"
        End Select
    End Function
    ''' <summary>
    ''' メッシュコードの文字の長さを取得
    ''' </summary>
    ''' <param name="Mesh"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getMeshCodeLength(ByVal MeshNumber As enmMesh_Number) As Integer
        Dim CodeLen As Integer
        Select Case MeshNumber
            Case enmMesh_Number.mhFirst
                CodeLen = 4
            Case enmMesh_Number.mhSecond
                CodeLen = 6
            Case enmMesh_Number.mhThird
                CodeLen = 8
            Case enmMesh_Number.mhHalf
                CodeLen = 9
            Case enmMesh_Number.mhQuarter
                CodeLen = 10
            Case enmMesh_Number.mhOne_Eighth
                CodeLen = 11
            Case enmMesh_Number.mhOne_Tenth
                CodeLen = 10
        End Select
        Return CodeLen
    End Function
    ''' <summary>
    ''' メッシュコードの名称を取得
    ''' </summary>
    ''' <param name="Mesh"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ConvertMeshTypeEnumString(ByVal MeshNumber As enmMesh_Number) As String
        Select Case MeshNumber
            Case enmMesh_Number.mhNonMesh
                Return ""
            Case enmMesh_Number.mhFirst
                Return "1次メッシュ"
            Case enmMesh_Number.mhSecond
                Return "2次メッシュ"
            Case enmMesh_Number.mhThird
                Return "3次メッシュ"
            Case enmMesh_Number.mhHalf
                Return "1/2メッシュ"
            Case enmMesh_Number.mhQuarter
                Return "1/4メッシュ"
            Case enmMesh_Number.mhOne_Eighth
                Return "1/8メッシュ"
            Case enmMesh_Number.mhOne_Tenth
                Return "1/10メッシュ"
        End Select
    End Function
    ''' <summary>
    ''' 名称からメッシュコードタイプを取得
    ''' </summary>
    ''' <param name="MeshType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ConvertMeshTypeEnumString(ByVal MeshType As String) As enmMesh_Number
        Select Case MeshType
            Case ""
                Return enmMesh_Number.mhNonMesh
            Case "1次メッシュ"
                Return enmMesh_Number.mhFirst
            Case "2次メッシュ"
                Return enmMesh_Number.mhSecond
            Case "3次メッシュ"
                Return enmMesh_Number.mhThird
            Case "1/2メッシュ"
                Return enmMesh_Number.mhHalf
            Case "1/4メッシュ"
                Return enmMesh_Number.mhQuarter
            Case "1/8メッシュ"
                Return enmMesh_Number.mhOne_Eighth
            Case "1/10メッシュ"
                Return enmMesh_Number.mhOne_Tenth
        End Select
    End Function
    ''' <summary>
    ''' 投影法に対応した文字列を返す
    ''' </summary>
    ''' <param name="prj">enmProjection_Info列挙型</param>
    ''' <returns>文字列</returns>
    ''' <remarks></remarks>
    Public Shared Function getStringProjectionEnum(ByVal prj As enmProjection_Info) As String
        Select Case prj
            Case enmProjection_Info.prjNo
                Return "設定なし"
            Case enmProjection_Info.prjSanson
                Return "サンソン図法"
            Case enmProjection_Info.prjSeikyoEntou
                Return "正距円筒図法"
            Case enmProjection_Info.prjMercator
                Return "メルカトル図法"
            Case enmProjection_Info.prjMiller
                Return "ミラー図法"
            Case enmProjection_Info.prjLambertSeisekiEntou
                Return "ランベルト正積円筒図法"
            Case enmProjection_Info.prjMollweide
                Return "モルワイデ図法"
            Case enmProjection_Info.prjEckert4
                Return "エッケルト第４図法"
        End Select
    End Function
    ''' <summary>
    ''' 文字列に対応した対応した投影法列挙型を返す
    ''' </summary>
    ''' <param name="prjWord">投影法文字列</param>
    ''' <returns>enmProjection_Info列挙型</returns>
    ''' <remarks></remarks>
    Public Shared Function getProjectionEnum_fromStrings(ByVal prjWord As String) As enmProjection_Info
        Select Case prjWord
            Case "設定なし"
                Return enmProjection_Info.prjNo
            Case "サンソン図法"
                Return enmProjection_Info.prjSanson
            Case "正距円筒図法"
                Return enmProjection_Info.prjSeikyoEntou
            Case "メルカトル図法"
                Return enmProjection_Info.prjMercator
            Case "ミラー図法"
                Return enmProjection_Info.prjMiller
            Case "ランベルト正積円筒図法"
                Return enmProjection_Info.prjLambertSeisekiEntou
            Case "モルワイデ図法"
                Return enmProjection_Info.prjMollweide
            Case "エッケルト第４図法"
                Return enmProjection_Info.prjEckert4
        End Select
    End Function
    ''' <summary>
    ''' 座標系に対応した文字列を返す
    ''' </summary>
    ''' <param name="Zahyo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getZahyouKeiStrings(ByRef Zahyo As clsMapData.Zahyo_info) As String
        With Zahyo
            Select Case .Mode
                Case enmZahyo_mode_info.Zahyo_No_Mode
                    Return "設定なし"
                Case enmZahyo_mode_info.Zahyo_Ido_Keido
                    Return "緯度経度"
                Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                    Return "平面直角座標系" & .HeimenTyokkaku_KEI_Number
            End Select
        End With

    End Function
    ''' <summary>
    ''' 測地系に対応した文字列を返す
    ''' </summary>
    ''' <param name="Sokutikei"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getSokutikeiStrings(ByVal Sokutikei As enmZahyo_System_Info) As String
        Select Case Sokutikei
            Case enmZahyo_System_Info.Zahyo_System_No
                Return "設定なし"
            Case enmZahyo_System_Info.Zahyo_System_tokyo
                Return "日本測地系"
            Case enmZahyo_System_Info.Zahyo_System_World
                Return "世界測地系"

        End Select
    End Function
    ''' <summary>
    ''' 座標系に対応したX座標の文字列を返す
    ''' </summary>
    ''' <param name="ZahyoMode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getZahyoModeXString(ByVal ZahyoMode As enmZahyo_mode_info) As String
        Select Case ZahyoMode
            Case enmZahyo_mode_info.Zahyo_No_Mode
                Return "X"
            Case enmZahyo_mode_info.Zahyo_Ido_Keido
                Return "経度"
            Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                Return "Y"
        End Select
    End Function
    ''' <summary>
    ''' 座標モードに対応したY座標の文字列を返す
    ''' </summary>
    ''' <param name="ZahyoMode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getZahyoModeYString(ByVal ZahyoMode As enmZahyo_mode_info) As String
        Select Case ZahyoMode
            Case enmZahyo_mode_info.Zahyo_No_Mode
                Return "Y"
            Case enmZahyo_mode_info.Zahyo_Ido_Keido
                Return "緯度"
            Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                Return "X"
        End Select
    End Function
    ''' <summary>
    ''' '形状列挙型からその文字を返す
    ''' </summary>
    ''' <param name="shape">enmShape列挙型</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ConvertShapeEnumString(ByVal shape As enmShape) As String

        Select Case shape
            Case enmShape.LineShape
                Return "線"
            Case enmShape.PointShape
                Return "点"
            Case enmShape.PolygonShape
                Return "面"
            Case enmShape.NotDeffinition
                Return "未指定" '本当はこれは出現しない
        End Select
    End Function
    Public Overloads Shared Function ConvertShapeEnumString(ByVal shape As String) As enmShape

        Select Case shape
            Case "線"
                Return enmShape.LineShape
            Case "点"
                Return enmShape.PointShape
            Case "面"
                Return enmShape.PolygonShape
            Case "未指定"
                Return enmShape.NotDeffinition
        End Select
    End Function
    ''' <summary>
    ''' 属性データタイプ列挙型から文字を返す
    ''' </summary>
    ''' <param name="dataType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ConvertAttDataTypeString(ByVal dataType As enmAttDataType) As String

        Select Case dataType
            Case enmAttDataType.Normal
                Return "通常のデータ"
            Case enmAttDataType.Category
                Return "ｶﾃｺﾞﾘｰﾃﾞｰﾀ"
            Case enmAttDataType.Strings
                Return "文字データ"
            Case enmAttDataType.URL
                Return "URLのアドレス"
            Case enmAttDataType.URL_Name
                Return "URLの名称"
            Case enmAttDataType.Lon
                Return "経度"
            Case enmAttDataType.Lat
                Return "緯度"
            Case enmAttDataType.Place
                Return "場所"
            Case enmAttDataType.Arrival
                Return "到着時刻"
            Case enmAttDataType.Departure
                Return "出発時刻"
            Case Else
                Return "その他" '本当はこれは出現しない
        End Select
    End Function
    ''' <summary>
    ''' 属性データタイプの文字から列挙型を返す
    ''' </summary>
    ''' <param name="attDataTypeWord"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ConvertAttDataTypeString(ByVal attDataTypeWord As String) As enmAttDataType

        Select Case attDataTypeWord
            Case "通常のデータ"
                Return enmAttDataType.Normal
            Case "ｶﾃｺﾞﾘｰﾃﾞｰﾀ"
                Return enmAttDataType.Category
            Case "文字データ"
                Return enmAttDataType.Strings
            Case "URLの名称"
                Return enmAttDataType.URL_Name
            Case "URLのアドレス"
                Return enmAttDataType.URL
            Case "経度"
                Return enmAttDataType.Lon
            Case "緯度"
                Return enmAttDataType.Lat
            Case "場所"
                Return enmAttDataType.Place
            Case "到着時刻"
                Return enmAttDataType.Arrival
            Case "出発時刻"
                Return enmAttDataType.Departure
            Case "その他"
        End Select
    End Function
    ''' <summary>
    ''' タイトル、単位から属性データタイプ列挙型を返す
    ''' </summary>
    ''' <param name="Title"></param>
    ''' <param name="Unit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getAttDataType_From_TitleUnit(ByVal Title As String, ByVal Unit As String) As enmAttDataType
        Dim dtype As enmAttDataType

        Dim UTitle As String = UCase(Title)

        If UTitle = "URL" Then
            dtype = enmAttDataType.URL
        ElseIf UTitle = "URL_NAME" Then
            dtype = enmAttDataType.URL_Name
        ElseIf UTitle = "LON" Then
            dtype = enmAttDataType.Lon
        ElseIf UTitle = "LAT" Then
            dtype = enmAttDataType.Lat
        ElseIf UTitle = "PLACE" Then
            dtype = enmAttDataType.Place
        ElseIf UTitle = "ARRIVAL" Then
            dtype = enmAttDataType.Arrival
        ElseIf UTitle = "DEPARTURE" Then
            dtype = enmAttDataType.Departure
        ElseIf UCase(Unit) = "CAT" Then
            dtype = enmAttDataType.Category
        ElseIf UCase(Unit) = "STR" Then
            dtype = enmAttDataType.Strings
        Else
            dtype = enmAttDataType.Normal
        End If
        Return dtype
    End Function
    ''' <summary>
    ''' 属性データタイプ列挙型からTITLE、単位文字列を設定
    ''' </summary>
    ''' <param name="dtype">属性データタイプ</param>
    ''' <param name="Title">タイトル(戻り値)</param>
    ''' <param name="Unit">単位(戻り値)</param>
    ''' <remarks></remarks>
    Public Shared Sub SetTitleUnit_from_AttDataType(ByVal dtype As enmAttDataType, ByRef Title As String, ByRef Unit As String)
        Select Case dtype
            Case enmAttDataType.Normal
                If UCase(Title) = "URL" Or UCase(Title) = "URL_NAME" Then
                    Title = "データ" + Title
                End If
                If UCase(Unit) = "CAT" Or UCase(Unit) = "STR" Then
                    Unit = ""
                End If
            Case enmAttDataType.Lon
                Title = "LON"
                Unit = ""
            Case enmAttDataType.Lat
                Title = "LAT"
                Unit = ""
            Case enmAttDataType.Category
                Unit = "CAT"
            Case enmAttDataType.Strings
                Unit = "STR"
            Case enmAttDataType.URL
                Title = "URL"
            Case enmAttDataType.URL_Name
                Title = "URL_NAME"
            Case enmAttDataType.Arrival
                Title = "ARRIVAL"
            Case enmAttDataType.Departure
                Title = "DEPARTURE"
            Case enmAttDataType.Place
                Title = "PLACE"

        End Select
    End Sub
    ''' <summary>
    ''' レイヤタイプの文字列を返す
    ''' </summary>
    ''' <param name="Type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ConvertStringLayerTypeString(ByVal Type As clsAttrData.enmLayerType) As String
        Select Case Type
            Case clsAttrData.enmLayerType.Normal
                Return "通常のレイヤ"
            Case clsAttrData.enmLayerType.Mesh
                Return "メッシュレイヤ"
            Case clsAttrData.enmLayerType.DefPoint
                Return "地点定義レイヤ"
            Case clsAttrData.enmLayerType.Trip
                Return "移動データレイヤ"
            Case clsAttrData.enmLayerType.Trip_Definition
                Return "移動主体定義レイヤ"
        End Select
    End Function
    ''' <summary>
    ''' レイヤタイプ文字列からレイヤタイプ定数を返す
    ''' </summary>
    ''' <param name="TypeStr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ConvertStringLayerTypeString(ByVal TypeStr As String) As clsAttrData.enmLayerType
        Select Case TypeStr
            Case "通常のレイヤ"
                Return clsAttrData.enmLayerType.Normal
            Case "メッシュレイヤ"
                Return clsAttrData.enmLayerType.Mesh
            Case "地点定義レイヤ"
                Return clsAttrData.enmLayerType.DefPoint
            Case "移動データレイヤ"
                Return clsAttrData.enmLayerType.Trip
            Case "移動主体定義レイヤ"
                Return clsAttrData.enmLayerType.Trip_Definition
        End Select
    End Function

    ''' <summary>
    ''' 属性データ編集で欠損値扱い欄に表示する文字を返す
    ''' </summary>
    ''' <param name="MissingValue">trueまたはfalse</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ConvertMissingValueBoolString(ByVal MissingValue As Boolean) As String
        Select Case MissingValue
            Case True
                Return "欠損値"
            Case False
                Return "0または空白"
        End Select
    End Function
    ''' <summary>
    ''' 属性データ編集で欠損値扱い欄の表示する文から値を返す
    ''' </summary>
    ''' <param name="MissingValueWord"></param>
    ''' <returns>trueまたはfalse</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ConvertMissingValueBoolString(ByVal MissingValueWord As String) As Boolean
        Select Case MissingValueWord
            Case "欠損値"
                Return True
            Case "0または空白"
                Return False
        End Select
    End Function
    ''' <summary>
    ''' 初期属性時間属性のタイプの文字列を返す
    ''' </summary>
    ''' <param name="defTimeType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getDefTimeAttrDataTypeStrings(ByVal defTimeType As clsMapData.enmDefTimeAttDataType) As String
        Select Case defTimeType
            Case clsMapData.enmDefTimeAttDataType.PointData
                Return "時点データ"
            Case clsMapData.enmDefTimeAttDataType.SpanData
                Return "期間データ"
        End Select
    End Function
    ''' <summary>
    ''' ラインの端点列挙型からその文字を返す
    ''' </summary>
    ''' <param name="Connect">端点列挙型</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getLineConnectStrings(ByVal Connect As enmLineConnect) As String
        Select Case Connect
            Case enmLineConnect.no
                Return "非結節点"
            Case enmLineConnect.both
                Return "両結節点"
            Case enmLineConnect.one
                Return "片結節点"
            Case enmLineConnect.loopen
                Return "ループ"
        End Select
    End Function
    ''' <summary>
    ''' 距離単位列挙型から距離文字列を返す
    ''' </summary>
    ''' <param name="scl_u"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getScaleUnitStrings(ByVal scl As enmScaleUnit) As String
        Select Case scl
            Case enmScaleUnit.meter
                Return "m"
            Case enmScaleUnit.kilometer
                Return "km"
            Case enmScaleUnit.centimeter
                Return "cm"
            Case enmScaleUnit.inch
                Return "inch"
            Case enmScaleUnit.feet
                Return "feet"
            Case enmScaleUnit.yard
                Return "yard"
            Case enmScaleUnit.mile
                Return "mile"
            Case enmScaleUnit.syaku
                Return "尺"
            Case enmScaleUnit.ken
                Return "間"
            Case enmScaleUnit.ri
                Return "里"
            Case enmScaleUnit.kairi
                Return "海里"
            Case Else
                Return "km"
        End Select
    End Function
    ''' <summary>
    ''' 距離単位列挙型から面積文字列を返す
    ''' </summary>
    ''' <param name="scl_u"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getScaleUnitAreaStrings(ByVal scl As enmScaleUnit) As String
        Select Case scl
            Case enmScaleUnit.meter
                Return "㎡"
            Case enmScaleUnit.kilometer
                Return "㎢"
            Case enmScaleUnit.centimeter
                Return "㎠"
            Case enmScaleUnit.inch
                Return "sq in"
            Case enmScaleUnit.feet
                Return "sq ft"
            Case enmScaleUnit.yard
                Return "sq yd"
            Case enmScaleUnit.mile
                Return "sq mi "
            Case enmScaleUnit.syaku
                Return "平方尺"
            Case enmScaleUnit.ken
                Return "坪"
            Case enmScaleUnit.ri
                Return "平方里"
            Case enmScaleUnit.kairi
                Return "平方海里"
            Case Else
                Return "km"
        End Select
    End Function
    ''' <summary>
    ''' 距離単位列挙型と値から距離文字列を返す
    ''' </summary>
    ''' <param name="scl_u"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getScaleUnitStrings(ByVal Value As Single, ByVal scl As enmScaleUnit) As String
        Select Case scl
            Case enmScaleUnit.meter
                Return Value.ToString + "m"
            Case enmScaleUnit.kilometer
                Return Value.ToString + "km"
            Case enmScaleUnit.centimeter
                Return Value.ToString + "cm"
            Case enmScaleUnit.inch
                Return Value.ToString + "inch"
            Case enmScaleUnit.feet
                If Value = 1 Then
                    Return "1 foot"
                Else
                    Return Value.ToString + "feet"
                End If
            Case enmScaleUnit.yard
                If Value = 1 Then
                    Return "1 yard"
                Else
                    Return Value.ToString + " yards"
                End If
            Case enmScaleUnit.mile
                If Value = 1 Then
                    Return "1 mile"
                Else
                    Return Value.ToString + " miles"
                End If
            Case enmScaleUnit.syaku
                Return Value.ToString + "尺"
            Case enmScaleUnit.ken
                Return Value.ToString + "間"
            Case enmScaleUnit.ri
                Return Value.ToString + "里"
            Case enmScaleUnit.kairi
                Return Value.ToString + "海里"
            Case Else
                Return Value.ToString + "km"
        End Select
    End Function

    ''' <summary>
    ''' 距離文字列から距離単位列挙型を返す
    ''' </summary>
    ''' <param name="scl_u"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getScaleUnit_from_Strings(ByVal scl_u As String) As enmScaleUnit
        scl_u = LCase(scl_u)
        Select Case scl_u
            Case "m"
                Return enmScaleUnit.meter
            Case "km"
                Return enmScaleUnit.kilometer
            Case "cm"
                Return enmScaleUnit.centimeter
            Case "inch"
                Return enmScaleUnit.inch
            Case "feet"
                Return enmScaleUnit.feet
            Case "yard"
                Return enmScaleUnit.yard
            Case "mile"
                Return enmScaleUnit.mile
            Case "尺"
                Return enmScaleUnit.syaku
            Case "間"
                Return enmScaleUnit.ken
            Case "里"
                Return enmScaleUnit.ri
            Case "海里"
                Return enmScaleUnit.kairi
            Case Else
                Return enmScaleUnit.kilometer
        End Select
    End Function
    ''' <summary>
    ''' 距離単位の変換係数を求める
    ''' </summary>
    ''' <param name="from_Unit"></param>
    ''' <param name="to_Unit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Convert_ScaleUnit(ByVal from_Unit As enmScaleUnit, ByVal to_Unit As enmScaleUnit) As Single
        Dim kmco(10) As Double
        kmco(enmScaleUnit.meter) = 1000
        kmco(enmScaleUnit.kilometer) = 1
        kmco(enmScaleUnit.centimeter) = 100000
        kmco(enmScaleUnit.inch) = 39370.078740157
        kmco(enmScaleUnit.feet) = 3280.8398950131
        kmco(enmScaleUnit.yard) = 1093.6132983377
        kmco(enmScaleUnit.mile) = 0.62137119223733
        kmco(enmScaleUnit.syaku) = 3300
        kmco(enmScaleUnit.ken) = 550
        kmco(enmScaleUnit.ri) = 0.25462962962963
        kmco(enmScaleUnit.kairi) = 0.53995680345572

        Dim fromdis As Double = kmco(from_Unit)
        Dim todis As Double = kmco(to_Unit)
        Return CSng(todis / fromdis)
    End Function
    ''' <summary>
    ''' 二つの変数の入れ替え
    ''' </summary>
    ''' <param name="v1"></param>
    ''' <param name="v2"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub SWAP(ByRef v1 As Boolean, ByRef v2 As Boolean)
        Dim c As Boolean = v1
        v1 = v2
        v2 = c
    End Sub
    ''' <summary>
    ''' 二つの変数の入れ替え
    ''' </summary>
    ''' <param name="v1"></param>
    ''' <param name="v2"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub SWAP(ByRef v1 As Integer, ByRef v2 As Integer)
        Dim c As Integer = v1
        v1 = v2
        v2 = c
    End Sub
    ''' <summary>
    ''' 二つの変数の入れ替え
    ''' </summary>
    ''' <param name="v1"></param>
    ''' <param name="v2"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub SWAP(ByRef v1 As Single, ByRef v2 As Single)
        Dim c As Single = v1
        v1 = v2
        v2 = c
    End Sub
    ''' <summary>
    ''' </summary>
    ''' <param name="v1"></param>
    ''' <param name="v2"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub SWAP(ByRef v1 As Double, ByRef v2 As Double)
        Dim c As Double = v1
        v1 = v2
        v2 = c
    End Sub
    ''' <summary>
    ''' 二つの変数の入れ替え
    ''' </summary>
    ''' <param name="v1"></param>
    ''' <param name="v2"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub SWAP(ByRef v1 As strYMD, ByRef v2 As strYMD)
        Dim c As strYMD = v1
        v1 = v2
        v2 = c
    End Sub
    ''' <summary>
    ''' 二つのベクトルのなす角度を求める
    ''' </summary>
    ''' <param name="VectorA"></param>
    ''' <param name="VectorB"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Angle_from_Two_Vector(ByVal VectorA As PointF, ByVal VectorB As PointF) As Single

        Dim a_b As Double = VectorA.X * VectorB.X + VectorA.Y * VectorB.Y
        Dim a As Single = Math.Sqrt(VectorA.X ^ 2 + VectorA.Y ^ 2)
        Dim b As Single = Math.Sqrt(VectorB.X ^ 2 + VectorB.Y ^ 2)

        Dim cosx As Single = a_b / (a * b)

        If cosx < -1 Then
            cosx = -1
        ElseIf cosx > 1 Then
            cosx = 1
        End If

        Dim sqrcos As Single = 1 - cosx
        If sqrcos < 0 Then
            sqrcos = 0
        ElseIf sqrcos > 1 Then
            sqrcos = 1
        End If
        Dim sinx As Single = Math.Sqrt(1 - cosx ^ 2)

        Return Angle(sinx, cosx)
    End Function
    ''' <summary>
    ''' sin、cosから角度を求めて返す
    ''' </summary>
    ''' <param name="si">sin</param>
    ''' <param name="co">cos</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Angle(ByVal si As Single, ByVal co As Single) As Single

        Dim Ang As Single

        If co = 0 Then
            Ang = 90
        Else
            Ang = Math.Atan(Math.Abs(si / co)) * 180 / Math.PI
        End If
        If si >= 0 And co >= 0 Then
        ElseIf si >= 0 And co < 0 Then
            Ang = 180 - Ang
        ElseIf si < 0 And co >= 0 Then
            Ang = 360 - Ang
        ElseIf si < 0 And co < 0 Then
            Ang = 180 + Ang
        End If
        Return Ang
    End Function

    ''' <summary>
    ''' 文字配列中の同じ文字を削除して同じ変数に返し、戻り値は削除後の数
    ''' </summary>
    ''' <param name="n">要素数</param>
    ''' <param name="ST">文字列配列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Remove_Same_String(ByVal n As Integer, ByRef ST() As String) As Integer

        Dim ST2(n - 1) As String
        Dim sdv(n - 1) As Boolean

        For i As Integer = 0 To n - 2
            If sdv(i) = False Then
                For j As Integer = i + 1 To n - 1
                    If ST(i) = ST(j) And sdv(j) = False Then
                        sdv(j) = True
                    End If
                Next
            End If
        Next

        Dim n2 As Integer = 0
        For i As Integer = 0 To n - 1
            If sdv(i) = False Then
                ST2(n2) = ST(i)
                n2 += 1
            End If
        Next
        ReDim Preserve ST2(n2 - 1)
        ST = ST2.Clone
        Return n2

    End Function
    ''' <summary>
    ''' オブジェクト名と設定期間の組み合わせ文字列を返す
    ''' </summary>
    ''' <param name="OnameStac">オブジェクト名・期間スタック構造体</param>
    ''' <param name="separator">名称と期間を分ける文字列（オプション）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function getTimeList(ByVal OnameStac As clsMapData.Object_NameTimeStac_Data, Optional ByVal separator As String = "") As String
        Dim tx As String
        tx = "【" & OnameStac.connectNames & "】" & separator & clsTime.StartEndtoString(OnameStac.SETime)
        Return tx
    End Function
    ''' <summary>
    ''' 継承設定のリストに入れる文字列を返す【オブジェクト名】+時間
    ''' </summary>
    ''' <param name="SUC"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function getTimeList(ByVal SUC As clsMapData.Object_Succession_Data, ByRef mpData As clsMapData) As String
        Dim N1 As String = ""
        With SUC
            If .ObjectCode = -1 Then
                N1 = "未設定"
            Else
                mpData.Get_Enable_ObjectName(mpData.MPObj(.ObjectCode), .Time, False, N1)
            End If
            Return "【" + N1 + "】" & clsTime.YMDtoString(.Time)
        End With
    End Function
    ''' <summary>
    ''' ラインの期間設定時の使用ラインの有効期間参照リストに入れる文字列を返す【線種名】+期間
    ''' </summary>
    ''' <param name="L"></param>
    ''' <param name="mpData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function getTimeList(ByVal L As clsMapData.Line_Time_Data, ByRef mpData As clsMapData, Optional ByVal separator As String = "") As String

        Dim N1 As String = ""
        With L
            Return "【" + mpData.LineKind(L.Kind).Name + "】" + clsTime.StartEndtoString(.SETime)
        End With
    End Function
    ''' <summary>
    ''' 代表点期間設定のリストに入れる文字列を返す　【代表点番号】期間
    ''' </summary>
    ''' <param name="centerP"></param>
    ''' <param name="centerPositionNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function getTimeList(ByVal centerP As clsMapData.Object_CenterPoint_Data, ByVal centerPositionNumber As Integer) As String
        With centerP
            Return "【" + centerPositionNumber.ToString & "】" + clsTime.StartEndtoString(.SETime)
        End With
    End Function
    ''' <summary>
    ''' boolean配列中から指定した数字を取り出し、その位置を配列で返す
    ''' </summary>
    ''' <param name="Original_Array">取り出す配列</param>
    ''' <param name="Original_Array_Num">要素数</param>
    ''' <param name="Specified_Value">取り出す要素</param>
    ''' <param name="Specified_Val_Number_Array">一致した位置（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Overloads Shared Function Get_Specified_Value_Array(ByVal Original_Array() As Integer, ByVal Original_Array_Num As Integer, _
                             ByVal Specified_Value As Integer, ByRef Specified_Val_Number_Array() As Integer) As Integer

        Dim n As Integer = 0
        Dim Out_Array() As Integer

        ReDim Out_Array(Original_Array_Num - 1)
        For i As Integer = 0 To Original_Array_Num - 1
            If Original_Array(i) = Specified_Value Then
                Out_Array(n) = i
                n += 1
            End If
        Next
        If n = 0 Then
            ReDim Out_Array(0)
        Else
            ReDim Preserve Out_Array(n - 1)
        End If
        Specified_Val_Number_Array = Out_Array
        Return n
    End Function
    Public Overloads Shared Function Get_Specified_Value_Array(ByVal Original_Array() As Integer, ByVal Original_Array_Num As Integer, _
                     ByVal Specified_Value As Boolean) As List(Of Integer)

        Dim Out_List As New List(Of Integer)

        For i As Integer = 0 To Original_Array_Num - 1
            If Original_Array(i) = Specified_Value Then
                Out_List.Add(i)
            End If
        Next
        Return Out_List
    End Function
    Public Overloads Shared Function Get_Specified_Value_Array(ByVal Original_Array() As Boolean, ByVal Original_Array_Num As Integer, _
                             ByVal Specified_Value As Boolean, ByRef Specified_Val_Number_Array() As Integer) As Integer

        Dim n As Integer = 0
        Dim Out_Array() As Integer

        ReDim Out_Array(Original_Array_Num - 1)
        For i As Integer = 0 To Original_Array_Num - 1
            If Original_Array(i) = Specified_Value Then
                Out_Array(n) = i
                n += 1
            End If
        Next
        If n = 0 Then
            ReDim Out_Array(0)
        Else
            ReDim Preserve Out_Array(n - 1)
        End If
        Specified_Val_Number_Array = Out_Array
        Return n
    End Function
    Public Overloads Shared Function Get_Specified_Value_Array(ByVal Original_Array() As Boolean, ByVal Original_Array_Num As Integer, _
                         ByVal Specified_Value As Boolean) As List(Of Integer)

        Dim Out_List As New List(Of Integer)
        For i As Integer = 0 To Original_Array_Num - 1
            If Original_Array(i) = Specified_Value Then
                Out_List.Add(i)
            End If
        Next
        Return Out_List
    End Function
    ''' <summary>
    ''' 配列中の指定した値の数をカウントする
    ''' </summary>
    ''' <param name="Original_Array">配列（boolean）</param>
    ''' <param name="CheckValue">調べる値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Count_Specified_Value_Array(ByVal Original_Array() As Boolean, ByVal CheckValue As Boolean) As Integer
        Dim n As Integer
        For i As Integer = 0 To Original_Array.Length - 1
            If Original_Array(i) = CheckValue Then
                n += 1
            End If
        Next
        Return n
    End Function
    ''' <summary>
    ''' 配列中の指定した値の数をカウントする
    ''' </summary>
    ''' <param name="Original_Array">配列（boolean）</param>
    ''' <param name="CheckValue">調べる値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Count_Specified_Value_Array(ByVal Original_Array() As Integer, ByVal CheckValue As Integer) As Integer
        Dim n As Integer
        For i As Integer = 0 To Original_Array.Length - 1
            If Original_Array(i) = CheckValue Then
                n += 1
            End If
        Next
        Return n
    End Function
    ''' <summary>
    ''' 配列中の指定した値の数をカウントする
    ''' </summary>
    ''' <param name="Original_Array">配列（boolean）</param>
    ''' <param name="CheckValue">調べる値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Count_Specified_Value_Array(ByVal Original_Array() As String, ByVal CheckValue As String) As Integer
        Dim n As Integer
        For i As Integer = 0 To Original_Array.Length - 1
            If Original_Array(i) = CheckValue Then
                n += 1
            End If
        Next
        Return n
    End Function
    ''' <summary>
    ''' 二段階コンボボックスの表示と値取得
    ''' </summary>
    ''' <param name="Title">フォームタイトル</param>
    ''' <param name="List1Title">ラベル1</param>
    ''' <param name="List2Title">ラベル２</param>
    ''' <param name="List1">上段のリスト文字列</param>
    ''' <param name="List2">下段のリスト文字列List(Of String()</param>
    ''' <param name="List1SelectedIndex">上段選択（戻り値）</param>
    ''' <param name="List2SelectedIndex">下段選択（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Show_TwoCombobox_and_GetResult(ByVal Title As String, ByVal List1Title As String, ByVal List2Title As String,
                                         ByRef List1() As String, ByRef List2 As List(Of String()),
                                         ByRef List1SelectedIndex As Integer, ByRef List2SelectedIndex As Integer) As Boolean
        Dim form As New frmSelectTwoCombobox
        Dim f As Boolean = (form.ShowDialog(Title, List1Title, List2Title, List1, List2, List1SelectedIndex, List2SelectedIndex) = DialogResult.OK)
        If f = True Then
            form.GetResults(List1SelectedIndex, List2SelectedIndex)
        End If
        form.Dispose()
        Return f
    End Function
    ''' <summary>
    ''' フォームのリストボックスに設定し、選択状態を取得
    ''' </summary>
    ''' <param name="Title"></param>
    ''' <param name="Items"></param>
    ''' <param name="Selected"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Show_ListBoxForm_and_GetResult(ByVal Title As String, ByVal Items() As String, ByRef Selected() As Boolean, ByVal ListType As frmSelectListBox.enmListType) As Boolean
        Dim form As New frmSelectListBox
        Dim f As Boolean = (form.ShowDialog(Title, Items, Selected, ListType) = Windows.Forms.DialogResult.OK)

        If f = True Then
            Selected = form.GetResults
        End If
        form.Dispose()
        Return f

    End Function
    ''' <summary>
    ''' コンボボックスにリストを入れたダイアログを表示し、値を取得する。キャンセルの場合は-1を返す
    ''' </summary>
    ''' <param name="Title">タイトル</param>
    ''' <param name="Items">リストの内容（配列）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Show_ComboboxForm_and_GetResult(ByVal Title As String, ByVal Items() As String) As Integer
        Dim form As New frmSelectComboBox
        Dim result As Integer
        If form.ShowDialog(Title, Items) = Windows.Forms.DialogResult.OK Then
            result = form.GetResult
        Else
            result = -1
        End If
        form.Dispose()
        Return result
    End Function
    ''' <summary>
    ''' コンボボックスにリストを入れたダイアログを表示し、値を取得する。キャンセルの場合は-1を返す
    ''' </summary>
    ''' <param name="Title">タイトル</param>
    ''' <param name="Items">リストの内容（ArrrayList）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Show_ComboboxForm_and_GetResult(ByVal Title As String, ByVal Items As List(Of String)) As Integer
        Dim form As New frmSelectComboBox
        Dim result As Integer
        If form.ShowDialog(Title, Items.ToArray) = Windows.Forms.DialogResult.OK Then
            result = form.GetResult
        Else
            result = -1
        End If
        form.Dispose()
        Return result
    End Function
    ''' <summary>
    ''' フォームを画面中央に配置
    ''' </summary>
    ''' <param name="form"></param>
    ''' <remarks></remarks>
    Public Shared Sub CenterForm(ByRef form As Form)
        form.Left = Screen.GetBounds(form).Width / 2 - form.Width / 2
        form.Top = Screen.GetBounds(form).Height / 2 - form.Height / 2
    End Sub
End Class

''' <summary>
''' pictureボックスの拡大縮小、ドラッグ等の画面退避処理
''' </summary>
''' <remarks></remarks>
Public Class clsPictureBoxDragOrWheelImageChange
    Dim picMap As PictureBox
    Dim backCanvas As Bitmap
    Dim canvasSub As Bitmap
    Public Sub New(ByRef pictureBox As PictureBox)

        picMap = pictureBox
    End Sub
    '地図ドラッグ時の画像待避

    ''' <summary>
    ''' pictureBoxでのマウスホイールによる拡大縮小の前に、ベクトルを描画開始する前に画像を拡大表示して速く見せ、拡大率等設定
    ''' </summary>
    ''' <param name="CenterLocation">ホイールの回った位置</param>
    ''' <param name="wheelDelta">ホイールの回転方向</param>
    ''' <param name="ScrData">Screen_Info(戻り値)</param>
    ''' <remarks></remarks>
    Public Sub pictureBoxMouseWheel(ByVal CenterLocation As Point, ByVal wheelDelta As Integer, _
                                           ByRef ScrData As Screen_info)
        Dim bairitu As Single = 0.5
        Dim key As Keys = Control.ModifierKeys
        If key = Keys.Shift Then
            bairitu = bairitu * 0.5
        End If
        If key = Keys.Control Then
            bairitu = bairitu * 0.25
        End If
        If key = (Keys.Control Or Keys.Shift) Then
            bairitu = bairitu * 0.125
        End If
        Dim ratio As Single
        If wheelDelta < 0 Then
            ratio = 1 - bairitu
        Else
            ratio = 1 + bairitu * 2
        End If



        Dim Pos As PointF = ScrData.getSRXY(New Point(CenterLocation.X, CenterLocation.Y))

        With ScrData.ScrView
            Dim h1 As Single = Pos.Y - .Top
            Dim h2 As Single = .Bottom - Pos.Y
            Dim w1 As Single = Pos.X - .Left
            Dim w2 As Single = .Right - Pos.X
            Dim rec As RectangleF = RectangleF.FromLTRB(Pos.X - w1 / ratio, Pos.Y - h1 / ratio, Pos.X + w2 / ratio, Pos.Y + h2 / ratio)
            If clsGeneric.Check_New_ScrView(ScrData.MapRectangle, rec) = True Then
                ScrData.ScrView = rec
                With picMap
                    Dim Canvas As Bitmap = New Bitmap(.Width, .Height)
                    Dim g As Graphics = Graphics.FromImage(Canvas)
                    Dim Rect As New Rectangle(New Point(CenterLocation.X - CenterLocation.X * ratio, CenterLocation.Y - CenterLocation.Y * ratio), _
                                              New Size(.Width * ratio, .Height * ratio))
                    Try
                        g.DrawImage(.Image, Rect)
                    Catch ex As Exception
                        Console.WriteLine(5161)
                    End Try
                    If picMap.Image Is Nothing = False Then
                        picMap.Image.Dispose()
                    End If
                    .Image = Canvas
                    .Refresh()
                    g.Dispose()
                    Canvas.Dispose()
                End With
            End If
        End With
    End Sub

    ''' <summary>
    ''' ドラッグ用に、現在のpictureBox画面をbackCanvasに待避
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub getPictureImage()
        backCanvas = New Bitmap(picMap.Width, picMap.Height)
        Dim gBackCanvas As Graphics = Graphics.FromImage(backCanvas)
        'Console.WriteLine("getPictureImage")
        'Console.WriteLine(picMap.Width.ToString)
        If Not (picMap.Image Is Nothing) Then
            gBackCanvas.DrawImage(picMap.Image, 0, 0)
        End If
        gBackCanvas.Dispose()
    End Sub
    ''' <summary>
    ''' 退避画像を同じ位置に表示(使われていない)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setBackCanvasSamePosition()
        'Console.WriteLine("setBackCanvasSamePosition")
        '待避した地図画面をドラッグに合わせて表示（地図のドラッグ）
        Dim canvas As New Bitmap(picMap.Width, picMap.Height)
        Dim g As Graphics = Graphics.FromImage(canvas)
        Dim P As Point = New Point(0, 0)
        Try
            g.DrawImage(backCanvas, P)
        Catch ex As Exception
            Console.WriteLine(5202)
        End Try
        picMap.Image = canvas
        picMap.Refresh()
        g.Dispose()
        canvas.Dispose()

    End Sub
    ''' <summary>
    ''' 退避画像を当初位置からずらして表示
    ''' </summary>
    ''' <param name="MousePosition"></param>
    ''' <param name="mouseDownPosition"></param>
    ''' <remarks></remarks>
    Public Sub DragPicture(ByVal MousePosition As Point, ByVal mouseDownPosition As Point)
        'Console.WriteLine("DragPicture")
        '待避した地図画面をドラッグに合わせて表示（地図のドラッグ）
        Dim canvas As New Bitmap(picMap.Width, picMap.Height)
        Dim g As Graphics = Graphics.FromImage(canvas)
        Dim P As Point = New Point(MousePosition.X - mouseDownPosition.X, MousePosition.Y - mouseDownPosition.Y)
        Try
            g.DrawImage(backCanvas, P)
        Catch ex As Exception
            Console.WriteLine(5227)
        End Try
        If picMap.Image Is Nothing = False Then
            picMap.Image.Dispose()
        End If
        picMap.Image = canvas
        picMap.Refresh()
        g.Dispose()
        canvas.Dispose()

    End Sub
    ''' <summary>
    ''' 退避画像のグラフィックスを返す。上書きでグラフィックスを描く場合に使う。描いたらsetGraphicsを行いgをおくる。(使われていない)
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetBackCanvasGrapics() As Graphics
        'Console.WriteLine("GetBackCanvasGrapics")
        canvasSub = New Bitmap(picMap.Width, picMap.Height)
        Dim g As Graphics = Graphics.FromImage(canvasSub)
        g.DrawImage(backCanvas, 0, 0)

        Return g
    End Function
    ''' <summary>
    ''' GetBackCanvasGrapicsで取得したグラフィックスに描画後、picMapに描画(使われていない)
    ''' </summary>
    ''' <param name="g"></param>
    ''' <remarks></remarks>
    Public Sub setGraphics(ByRef g As Graphics)
        'Console.WriteLine("setGraphics")
        picMap.Image = canvasSub
        picMap.Refresh()
        g.Dispose()
        canvasSub.Dispose()

    End Sub
    ''' <summary>
    ''' ドラッグ後の退避画像をdispose
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DisposeBackCanvasPictureImage()
        Try
            backCanvas.Dispose()
        Catch ex As Exception
            Console.WriteLine(5269)
        End Try
    End Sub

End Class

''' <summary>
''' ライン、タイル等のデフォルト値を返す
''' </summary>
''' <remarks></remarks>
Public Class clsBase
    ''' <summary>
    ''' 記号の選択で、画像を選択したくない場合に使う
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PictureNoUse() As BasePicture_Info
        Dim a As BasePicture_Info
        a.PictureNum = -1
        Return a
    End Function

    ''' <summary>
    ''' 白色
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ColorWhite() As colorARGB
        Return New colorARGB(Color.White)
    End Function
    ''' <summary>
    '''黒色
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ColorBlack() As colorARGB
        Dim c As colorARGB = New colorARGB(Color.Black)
        Return c
    End Function
    ''' <summary>
    '''赤色
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ColorRed() As colorARGB
        Return New colorARGB(Color.Red)
    End Function
    ''' <summary>
    '''青色
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ColorBlue() As colorARGB
        Return New colorARGB(Color.Blue)
    End Function
    ''' <summary>
    '''黄色
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ColorYellow() As colorARGB
        Return New colorARGB(Color.Yellow)
    End Function
    ''' <summary>
    '''緑色
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ColorGreen() As colorARGB
        Return New colorARGB(Color.Green)
    End Function
    ''' <summary>
    '''紫色
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ColorMagenta() As colorARGB
        Return New colorARGB(Color.Magenta)
    End Function
    ''' <summary>
    '''水色
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ColorCyan() As colorARGB
        Return New colorARGB(Color.Cyan)
    End Function
    ''' <summary>
    ''' 基本の実線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Line() As Line_Property
        Dim BaseLine As Line_Property
        With BaseLine
            With .Edge_Connect_Pattern
                .Edge_Pattern = enmEdge_Pattern.Round
                .Join_Pattern = enmJoinPattern.Round
                .MiterLimitValue = 10
            End With

            .CrossLine.XLine_f = False
            .ParallelLine.P_Line_f = False

            With .BasicLine
                .pattern = 0
                With .SolidLine
                    .Color.setColor(Color.Black)
                    .Width = 0
                End With
                For i As Integer = 0 To 5
                    Dim clParts As OptionalLine_Data_info
                    With clParts
                        .Color.setColor(Color.Black)
                        .Length = 0.5
                        .Use_F = False
                        .Print_f = True
                        .Width = 0
                    End With
                    .Set_CenterLineParts(i, clParts)
                Next
                .CenterLineParts0.Use_F = True
                .CenterLineParts1.Use_F = True
                .CenterLineParts1.Print_f = False
            End With

            With .CrossLine
                For i As Integer = 0 To 5
                    Dim crlParts As Optional_X_Line_Data_info
                    With crlParts
                        .Color.setColor(Color.Black)
                        .Use_F = False
                        .pattern = 0
                        .Length = 1
                        .Width = 0
                        .Interval = 1
                        With .TileMark
                            .PrintMark = enmMarkPrintType.Mark
                            .ShapeNumber = 0
                            .PictureNumber = -1
                            .Kakudo = 0
                            .WordFontName = clsSettings.Data.SetFont
                            .wordmark = ""
                            .Mark_Line_Color.setColor(Color.Black)
                        End With
                    End With
                    .Set_CrossLineParts(i, crlParts)
                Next
                .XLineParts0.Use_F = True
            End With

            .ParallelLine.P_CenterLine = .BasicLine
            With .ParallelLine
                .InnerColor_f = True
                .InnerColor.setColor(Color.White)
                .Interval = 0.4
                .Center_Line_f = False
                .CenterLine_ParaLine_f = True
            End With
        End With
        Return BaseLine
    End Function
    ''' <summary>
    ''' 透明ラインを返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BlancLine() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        BLine.BasicLine.pattern = enmLinePattern.InVisible
        Return BLine
    End Function

    ''' <summary>
    ''' 破線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BrokenLine() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        With BLine.BasicLine
            .pattern = enmLinePattern.BROKEN
            With .CenterLineParts0
                .Length = 2
                .Use_F = True
            End With
            With .CenterLineParts1
                .Length = 0.8
                .Use_F = True
                .Print_f = False
            End With
        End With
        Return BLine
    End Function

    ''' <summary>
    ''' 点線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DotLine() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        With BLine.BasicLine
            .pattern = enmLinePattern.BROKEN
            With .CenterLineParts0
                .Length = 0.3
                .Use_F = True
            End With
            With .CenterLineParts1
                .Length = 0.3
                .Use_F = True
                .Print_f = False
            End With
        End With
        BLine.Edge_Connect_Pattern.Edge_Pattern = enmEdge_Pattern.Flat
        Return BLine
    End Function

    ''' <summary>
    ''' 一点鎖線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Chain1Line() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        With BLine.BasicLine
            .pattern = enmLinePattern.BROKEN
            With .CenterLineParts0
                .Length = 1.5
                .Use_F = True
            End With
            With .CenterLineParts1
                .Length = 0.5
                .Use_F = True
                .Print_f = False
            End With
            With .CenterLineParts2
                .Length = 0.5
                .Use_F = True
            End With
            With .CenterLineParts3
                .Length = 0.5
                .Use_F = True
                .Print_f = False
            End With
        End With
        Return BLine
    End Function

    ''' <summary>
    ''' 二点鎖線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Chain2Line() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        With BLine.BasicLine
            .pattern = enmLinePattern.BROKEN
            With .CenterLineParts0
                .Length = 1.5
                .Use_F = True
            End With
            With .CenterLineParts1
                .Length = 0.5
                .Use_F = True
                .Print_f = False
            End With
            With .CenterLineParts2
                .Length = 0.5
                .Use_F = True
            End With
            With .CenterLineParts3
                .Length = 0.5
                .Use_F = True
                .Print_f = False
            End With
            With .CenterLineParts4
                .Length = 0.5
                .Use_F = True
            End With
            With .CenterLineParts5
                .Length = 0.5
                .Use_F = True
                .Print_f = False
            End With
        End With
        Return BLine
    End Function

    ''' <summary>
    ''' 太線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BoldLine() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        BLine.BasicLine.SolidLine.Width = 0.3
        Return BLine
    End Function
    ''' <summary>
    ''' 極太線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BoldExLine() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        BLine.BasicLine.SolidLine.Width = 0.5
        Return BLine
    End Function
    ''' <summary>
    ''' 二重線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DoubleLine() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        With BLine.ParallelLine
            .P_Line_f = True
            .Interval = 0.3
            .InnerColor_f = True
            .InnerColor = New colorARGB(Color.White)
            .CenterLine_ParaLine_f = True
            .Center_Line_f = False
        End With
        Return BLine
    End Function

    ''' <summary>
    ''' 幅広二重線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DoubleWideLine() As Line_Property
        Dim BLine As Line_Property
        BLine = DoubleLine()
        With BLine.ParallelLine
            .Interval = 0.5
        End With
        BLine.BasicLine.SolidLine.Width = 0.1
        Return BLine
    End Function

    ''' <summary>
    ''' 極幅広二重線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DoubleWideExLine() As Line_Property
        Dim BLine As Line_Property
        BLine = DoubleWideLine()
        With BLine.ParallelLine
            .Interval = 0.9
        End With
        BLine.BasicLine.SolidLine.Width = 0.1
        Return BLine
    End Function
    ''' <summary>
    ''' 三重線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TripleLine() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        With BLine.ParallelLine
            .P_Line_f = True
            .Interval = 0.5
            .InnerColor_f = True
            .InnerColor = New colorARGB(Color.White)
            .CenterLine_ParaLine_f = True
            .Center_Line_f = True
        End With
        Return BLine
    End Function

    ''' <summary>
    ''' 幅広三重線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TripleWideLine() As Line_Property
        Dim BLine As Line_Property
        BLine = TripleLine()
        With BLine.ParallelLine
            .Interval = 1
        End With
        BLine.BasicLine.SolidLine.Width = 0.1
        Return BLine
    End Function

    ''' <summary>
    ''' JR線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JRLine() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        With BLine.ParallelLine
            .P_Line_f = True
            .Interval = 0.4
            .InnerColor_f = True
            .InnerColor = New colorARGB(Color.White)
            .Center_Line_f = True
            .CenterLine_ParaLine_f = False
            With .P_CenterLine
                .pattern = 1
                With .CenterLineParts0
                    .Print_f = True
                    .Length = 1
                    .Width = 0.4
                    .Use_F = True
                End With
                With .CenterLineParts1
                    .Print_f = False
                    .Use_F = True
                    .Length = 1
                End With
            End With
        End With
        BLine.Edge_Connect_Pattern.Edge_Pattern = enmEdge_Pattern.Flat

        Return BLine
    End Function

    ''' <summary>
    ''' 私鉄線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RailLine() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        With BLine.CrossLine
            .XLine_f = True
            With .XLineParts0
                .Interval = 1
                .Use_F = True
                .Width = 0
                .Length = 0.5
                .pattern = 0
            End With
        End With
        BLine.BasicLine.SolidLine.Width = 0.1
        BLine.Edge_Connect_Pattern.Edge_Pattern = enmEdge_Pattern.Flat
        Return BLine
    End Function

    ''' <summary>
    ''' 地下鉄線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UndergroundRailLine() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        With BLine.BasicLine
            .pattern = enmLinePattern.BROKEN
            With .CenterLineParts0
                .Use_F = True
                .Print_f = True
                .Length = 0.7
                .Width = 0.3
            End With
            With .CenterLineParts1
                .Use_F = True
                .Print_f = False
                .Length = 1
                .Width = 0.3
            End With
        End With
        BLine.Edge_Connect_Pattern.Edge_Pattern = enmEdge_Pattern.Flat
        Return BLine
    End Function
    ''' <summary>
    ''' 丸線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CircleLine() As Line_Property
        Dim BLine As Line_Property
        BLine = Line()
        With BLine.CrossLine
            .XLine_f = True
            With .XLineParts0
                .Interval = 1
                .Use_F = True
                .Width = 0
                .Length = 0.6
                .pattern = enmLineCrossPattern.Circle
            End With
        End With
        Return BLine
    End Function

    ''' <summary>
    ''' 四角線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RectLine() As Line_Property
        Dim BLine As Line_Property
        BLine = CircleLine()
        With BLine
            .BasicLine.SolidLine.Width = 0.1
            With .CrossLine.XLineParts0
                .pattern = enmLineCrossPattern.Rectangle
            End With
        End With
        Return BLine
    End Function

    ''' <summary>
    ''' 丸点線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CircleDotLine() As Line_Property
        Dim BLine As Line_Property
        BLine = CircleLine()
        With BLine
            .BasicLine.pattern = enmLinePattern.InVisible
        End With
        Return BLine
    End Function

    ''' <summary>
    ''' 四角点線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RectDotLine() As Line_Property
        Dim BLine As Line_Property
        BLine = RectLine()
        With BLine
            .BasicLine.pattern = enmLinePattern.InVisible
        End With
        Return BLine
    End Function

    ''' <summary>
    ''' 横線を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SideLine() As Line_Property
        Dim BLine As Line_Property
        BLine = RailLine()
        With BLine
            .BasicLine.pattern = enmLinePattern.InVisible
            .CrossLine.XLineParts0.Interval = 0.5
            .CrossLine.XLineParts0.Length = 1
        End With
        Return BLine
    End Function

    ''' <summary>
    ''' 基本タイルを返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Tile()
        Dim BTile As Tile_Property
        With BTile
            .TileCode = enmTilePattern.Paint
            .Line = clsBase.Line
            .Density = 1.5
            .BGColFlag = False
            .BGCOLOR = New colorARGB(Color.White)
            With .TileMark
                .PrintMark = enmMarkPrintType.Mark
                .ShapeNumber = 0
                .PictureNumber = -1
                .Kakudo = 0
                .WordFontName = clsSettings.Data.SetFont
                .wordmark = ""
                .wordmark = ""
                .Mark_Line_Color = New colorARGB(Color.Black)
            End With
        End With
        Return BTile
    End Function
    ''' <summary>
    ''' 透明タイルを返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BlancTile()
        Dim BTile As Tile_Property = Tile()
        BTile.TileCode = enmTilePattern.Blank
        Return BTile
    End Function
    ''' <summary>
    ''' 枠線付き角丸ボックスの透明を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BlankBackground()
        Dim Back As BackGround_Box_Property
        Back.Line = BlancLine()
        Back.Tile = BlancTile()
        Back.Round = 1
        Back.Padding = 1
        Return Back
    End Function
    ''' <summary>
    ''' べた塗りタイルを返す
    ''' </summary>
    ''' <param name="Col">色</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PaintTile(ByVal Col As colorARGB)
        Dim BTile As Tile_Property = Tile()
        BTile.TileCode = enmTilePattern.Paint
        BTile.Line.BasicLine.SolidLine.Color = Col
        Return BTile
    End Function

    ''' <summary>
    '''  階級区分ハッチモード用既定タイルを返す
    ''' </summary>
    ''' <param name="DivNum">分割数(1-10)</param>
    ''' <param name="n">階級位置(0-分割数-1)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ClassTile(ByVal DivNum As Integer, ByVal n As Integer) As Tile_Property
        Dim t As Tile_Property = clsBase.Tile
        If DivNum - 1 = n And DivNum <> 1 Then
            t.TileCode = enmTilePattern.Blank
            Return t
        End If
        With t
            Select Case DivNum
                Case 1
                    .TileCode = enmTilePattern.Saltire
                    .Density = 1.5
                Case 2
                    .TileCode = 6
                    .Density = 1
                Case 3
                    Select Case n
                        Case 0
                            .TileCode = enmTilePattern.Saltire
                            .Density = 1
                        Case 1
                            .TileCode = enmTilePattern.DiagonalLineRightUp
                            .Density = 1.5
                    End Select
                Case 4
                    Select Case n
                        Case 0
                            .TileCode = enmTilePattern.Saltire
                            .Density = 1
                        Case 1
                            .TileCode = enmTilePattern.DiagonalLineRightUp
                            .Density = 1.5
                        Case 2
                            .TileCode = enmTilePattern.Point
                            .Density = 1
                            .Line.BasicLine.SolidLine.Width = 0.2
                    End Select
                Case 5
                    Select Case n
                        Case 0
                            .TileCode = enmTilePattern.Saltire
                            .Density = 0.5
                        Case 1
                            .TileCode = enmTilePattern.Saltire
                            .Density = 1
                        Case 2
                            .TileCode = enmTilePattern.DiagonalLineRightUp
                            .Density = 1.5
                        Case 3
                            .TileCode = enmTilePattern.Point
                            .Density = 1
                            .Line.BasicLine.SolidLine.Width = 0.2
                    End Select
                Case 6
                    Select Case n
                        Case 0
                            .TileCode = enmTilePattern.Saltire
                            .Density = 0.5
                        Case 1
                            .TileCode = enmTilePattern.DiagonalLineRightDown
                            .Density = 0.5
                        Case 2
                            .TileCode = enmTilePattern.DiagonalLineRightUp
                            .Density = 1
                        Case 3
                            .TileCode = enmTilePattern.DiagonalLineRightDown
                            .Density = 1.5
                        Case 4
                            .TileCode = enmTilePattern.Point
                            .Density = 1
                            .Line.BasicLine.SolidLine.Width = 0.2
                    End Select
                Case 7
                    Select Case n
                        Case 0
                            .TileCode = enmTilePattern.Saltire
                            .Density = 0.5
                        Case 1
                            .TileCode = enmTilePattern.DiagonalLineRightDown
                            .Density = 0.5
                        Case 2
                            .TileCode = enmTilePattern.DiagonalLineRightUp
                            .Density = 1
                        Case 3
                            .TileCode = enmTilePattern.DiagonalLineRightDown
                            .Density = 1.5
                        Case 4
                            .TileCode = enmTilePattern.VerticalLine
                            .Density = 1.5
                            .Line = clsBase.DotLine
                        Case 5
                            .TileCode = enmTilePattern.Point
                            .Density = 1
                            .Line.BasicLine.SolidLine.Width = 0.2
                    End Select
                Case 8
                    Select Case n
                        Case 0
                            .TileCode = enmTilePattern.Saltire
                            .Density = 0.5
                        Case 1
                            .TileCode = enmTilePattern.DiagonalLineRightDown
                            .Density = 0.5
                        Case 2
                            .TileCode = enmTilePattern.DiagonalLineRightUp
                            .Density = 1
                        Case 3
                            .TileCode = enmTilePattern.DiagonalLineRightDown
                            .Density = 1.5
                        Case 4
                            .TileCode = enmTilePattern.VerticalLine
                            .Density = 1.5
                            .Line = clsBase.DotLine
                        Case 5
                            .TileCode = enmTilePattern.Point
                            .Density = 1
                            .Line.BasicLine.SolidLine.Width = 0.2
                        Case 6
                            .TileCode = enmTilePattern.Point
                            .Density = 1.5
                            .Line.BasicLine.SolidLine.Width = 0.2
                    End Select
                Case 9
                    Select Case n
                        Case 0
                            .TileCode = enmTilePattern.Saltire
                            .Density = 0.5
                        Case 1
                            .TileCode = enmTilePattern.DiagonalLineRightDown
                            .Density = 0.5
                        Case 2
                            .TileCode = enmTilePattern.DiagonalLineRightUp
                            .Density = 1
                        Case 3
                            .TileCode = enmTilePattern.DiagonalLineRightDown
                            .Density = 1.5
                        Case 4
                            .TileCode = enmTilePattern.DiagonalLineRightUp
                            .Density = 1.5
                            .Line = clsBase.DotLine
                        Case 5
                            .TileCode = enmTilePattern.VerticalLine
                            .Density = 2
                            .Line = clsBase.DotLine
                        Case 6
                            .TileCode = enmTilePattern.Point
                            .Density = 1
                            .Line.BasicLine.SolidLine.Width = 0.2
                        Case 7
                            .TileCode = enmTilePattern.Point
                            .Density = 1.5
                            .Line.BasicLine.SolidLine.Width = 0.2
                    End Select
            End Select
        End With

        Return t
    End Function
    ''' <summary>
    ''' 基本フォントを返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Font()
        Dim Ft As Font_Property
        With Ft
            With .Body
                .Size = 4
                .Color = New colorARGB(Color.Black)
                .italic = False
                .Underline = False
                .Name = clsSettings.Data.SetFont
                .bold = False
                .Kakudo = 0
                .FringeF = False
                .FringeWidth = 60
                .FringeColor = New colorARGB(Color.White)
            End With
            With .Back
                .Tile = Tile()
                .Tile.TileCode = enmTilePattern.Blank
                .Tile.BGCOLOR = New colorARGB(Color.White)
                .Tile.Line.BasicLine.SolidLine.Color = New colorARGB(Color.White)
                .Line = clsBase.Line
                .Line.BasicLine.pattern = -1
                .Round = 1
                .Padding = 1
            End With
        End With
        Return Ft
    End Function

    ''' <summary>
    ''' 基本記号を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Mark() As Mark_Property
        Dim BMark As Mark_Property
        With BMark
            .Line = Line()
            .Tile = Tile()
            .Tile.Line.BasicLine.SolidLine.Color = New colorARGB(255, &HC0, &HC0, &HC0)
            .ShapeNumber = 0
            .PrintMark = enmMarkPrintType.Mark
            .wordmark = ""
            .WordFont = Font()
            .WordFont.Body.Color = .Tile.Line.BasicLine.SolidLine.Color
            .WordFont.Body.Size = 2
            .PictureNumber = -1
            .PictureAlpahValue = 255
        End With
        Return BMark
    End Function

    ''' <summary>
    ''' 矢印の基本形を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Arrow() As Arrow_Data
        Dim BArrow As Arrow_Data
        With BArrow
            .End_Arrow_F = False
            .Start_Arrow_F = False
            .ArrowHeadType = enmArrowHeadType.Line
            .WidthPlus = 2
            .Angle = 50
            .LWidthRatio = 1
        End With
        Return BArrow
    End Function
End Class

''' <summary>
''' オブジェクト名検索用クラス
''' </summary>
''' <remarks></remarks>
Public Class clsObjectNameSearch

    Public Structure ObjNameAndTime_Info
        Public ObjCode As Integer
        Public SETime As Start_End_Time_data
    End Structure
    Private Object_Name_Search As clsSortingSearch
    Private Object_Name_Stac_for_Search_O_Code() As ObjNameAndTime_Info
    Private checkObjectNameKanjiCompatibleF As Boolean
    ''' <summary>
    ''' 地図データからオブジェクト名検索用のクラスを生成
    ''' </summary>
    ''' <param name="MapData">地図データ</param>
    ''' <param name="CheckKanjiCompatibleFlag">漢字の互換性チェック</param>
    ''' <remarks></remarks>
    Sub New(ByRef MapData As clsMapData, ByVal CheckKanjiCompatibleFlag As Boolean)

        Object_Name_Search = New clsSortingSearch
        checkObjectNameKanjiCompatibleF = CheckKanjiCompatibleFlag
        Dim Name_n As Integer = 0
        For i As Integer = 0 To MapData.Map.Kend - 1
            Name_n += MapData.MPObj(i).NumOfNameTime * MapData.ObjectKind(MapData.MPObj(i).Kind).ObjectNameNum
        Next

        ReDim Object_Name_Stac_for_Search_O_Code(Name_n - 1)

        Object_Name_Search.AddInit(vbString)
        Dim n As Integer = 0
        For i As Integer = 0 To MapData.Map.Kend - 1
            For j As Integer = 0 To MapData.MPObj(i).NumOfNameTime - 1
                With MapData.MPObj(i).NameTimeSTC(j)
                    For k As Integer = 0 To .NamesList.Length - 1
                        Dim nam As String = .NamesList(k)
                        If nam <> "" Then
                            If checkObjectNameKanjiCompatibleF = True Then
                                clsGeneric.ObjName_Kanji_Compatible(nam)
                            End If
                            Object_Name_Search.Add(nam)
                            Object_Name_Stac_for_Search_O_Code(n).ObjCode = i
                            Object_Name_Stac_for_Search_O_Code(n).SETime = .SETime
                            n += 1
                        End If
                    Next
                End With
            Next
        Next
        Object_Name_Search.AddEnd()

        ReDim Preserve Object_Name_Stac_for_Search_O_Code(n - 1)
    End Sub
    Public Function Object_Name_Stac(ByVal Pos As Integer) As ObjNameAndTime_Info
        Return Object_Name_Stac_for_Search_O_Code(Pos)
    End Function
    Public Function DataPositionValue(ByVal Pos As Integer) As String
        Return Object_Name_Search.DataPositionValue_string(Pos)

    End Function
    Public Function NumofData() As Integer
        Return Object_Name_Search.NumofData
    End Function
    Public Function DataPosition(ByVal Num) As Integer
        Return Object_Name_Search.DataPosition(Num)
    End Function
    ''' <summary>
    ''' オブジェクト名からオブジェクト番号を取得する。見つからなかった場合-1を返す
    ''' </summary>
    ''' <param name="ObjName">検索オブジェクト名</param>
    ''' <param name="Time">時期</param>
    ''' <returns>オブジェクト番号</returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_KenToCode(ByVal ObjName As String, ByVal Time As strYMD) As Integer
        If ObjName = "" Then
            Return -1
        End If
        If checkObjectNameKanjiCompatibleF = True Then
            clsGeneric.ObjName_Kanji_Compatible(ObjName)
        End If

        Dim DataList() As Integer
        Dim NED As Integer = Object_Name_Search.getSearchData_Allay(ObjName, DataList)

        For i As Integer = 0 To NED - 1
            Dim j As Integer = DataList(i)
            If clsTime.checkDurationIn(Object_Name_Stac_for_Search_O_Code(j).SETime, Time) = True Then
                Return Object_Name_Stac_for_Search_O_Code(j).ObjCode
            End If
        Next
        Return -1
    End Function
    ''' <summary>
    ''' オブジェクト名からオブジェクト番号を配列で取得する。
    ''' </summary>
    ''' <param name="ObjName"></param>
    ''' <param name="Time"></param>
    ''' <param name="ObjCode"></param>
    ''' <returns>数</returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_KenToCode(ByVal ObjName As String, ByVal Time As strYMD, ByRef ObjCode() As Integer) As Integer
        If ObjName = "" Then
            Return -1
        End If
        If checkObjectNameKanjiCompatibleF = True Then
            clsGeneric.ObjName_Kanji_Compatible(ObjName)
        End If

        Dim DataList() As Integer
        Dim NED As Integer = Object_Name_Search.getSearchData_Allay(ObjName, DataList)

        Dim Code As New List(Of Integer)
        For i As Integer = 0 To NED - 1
            Dim j As Integer = DataList(i)
            If clsTime.checkDurationIn(Object_Name_Stac_for_Search_O_Code(j).SETime, Time) = True Then
                Code.Add(Object_Name_Stac_for_Search_O_Code(j).ObjCode)
            End If
        Next
        ObjCode = Code.ToArray()
        Return Code.Count
    End Function
    ''' <summary>
    ''' オブジェクト名から時間を考慮せずオブジェクト番号を配列で取得する。
    ''' </summary>
    ''' <param name="ObjName"></param>
    ''' <param name="Time"></param>
    ''' <param name="ObjCode"></param>
    ''' <returns>数</returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_KenToCode(ByVal ObjName As String, ByRef ObjCode() As Integer) As Integer
        If ObjName = "" Then
            Return -1
        End If
        If checkObjectNameKanjiCompatibleF = True Then
            clsGeneric.ObjName_Kanji_Compatible(ObjName)
        End If

        Dim DataList() As Integer
        Dim NED As Integer = Object_Name_Search.getSearchData_Allay(ObjName, DataList)

        Dim n As Integer = 0
        If NED > 0 Then
            ObjCode = clsGeneric.Get_EachValueArray(DataList)
            n = ObjCode.Length
        End If
        Return n
    End Function
End Class


Public Class clsEMFMetafileCopy
    Public Declare Function OpenClipboard Lib "user32" Alias "OpenClipboard" (ByVal hwnd As IntPtr) As Long
    Public Declare Function EmptyClipboard Lib "user32" Alias "EmptyClipboard" () As Boolean
    Public Declare Function SetClipboardData Lib "user32" (ByVal wFormat As Integer, ByVal hMem As IntPtr) As IntPtr
    Public Declare Function CloseClipboard Lib "user32" Alias "CloseClipboard" () As Boolean
    Public Declare Function CopyEnhMetaFile Lib "gdi32" Alias "CopyEnhMetaFileA" (ByVal hemfSrc As IntPtr, ByVal hNULL As IntPtr) As IntPtr
    Public Declare Function DeleteEnhMetaFile Lib "gdi32" Alias "DeleteEnhMetaFile" (ByVal hemf As IntPtr) As Boolean

    'http://support.microsoft.com/kb/323530　参照
    ' Metafile mf is set to a state that is not valid inside this function.
    Public Shared Function PutEnhMetafileOnClipboard(ByVal hWnd As IntPtr, ByVal mf As System.Drawing.Imaging.Metafile) As Boolean
        Dim bResult As New Boolean()
        bResult = False
        Dim hEMF, hEMF2 As IntPtr
        hEMF = mf.GetHenhmetafile() ' invalidates mf
        If Not hEMF.Equals(New IntPtr(0)) Then
            hEMF2 = CopyEnhMetaFile(hEMF, New IntPtr(0))
            If Not hEMF2.Equals(New IntPtr(0)) Then
                If OpenClipboard(hWnd) Then
                    If EmptyClipboard() Then
                        Dim hRes As IntPtr
                        hRes = SetClipboardData(14, hEMF2) ' 14 == CF_ENHMETAFILE
                        bResult = hRes.Equals(hEMF2)
                        CloseClipboard()
                    End If
                End If
            End If
            DeleteEnhMetaFile(hEMF)
        End If
        Return bResult
    End Function

End Class

Public Class clsSettings
    Public Structure Directory_info
        Public Shapefile As String
        Public E00File As String
        Public Mapfile As String
        Public SuchiTizu50Mesh As String
        Public SuchiTizu250Mesh As String
        Public SuchiTizu1kMesh As String
        Public Kiban5mMesh As String
        Public Kiban10mMesh As String
        Public SRTM30Plus As String
        Public SRTM3 As String
        Public ASTERGDEM As String
        Public ETOPO5 As String
        Public KML As String
        Public OSM As String
        Public GPX As String
        Public DataFile As String
        Public ImageFile As String
        Public MapFolder_Default As enmMapFolder_Default_info
        Public TileOut As String
        Public CensusGIS As String
        Public Kiban As String
    End Structure
    Public Structure mapeditor_Info
        Public MapFileHistory As String
        Public ObjectNameVisibleFlag As Boolean
        Public Backcolor As colorARGB
        Public LineColor As colorARGB
        Public LineColorDisabled As colorARGB
        Public LineColorSelected As colorARGB
        Public LineColorPoints As colorARGB
        Public ObjectLineColor As colorARGB
        Public ObjectLineColorDisabled As colorARGB
        Public ObjectTimeLineColor As colorARGB
        Public ObjectNameColor As colorARGB
        Public ObjectNamePrinting_Maxmun As Integer
        Public ObjectNameSize As Integer
        Public DefAttrColor As colorARGB
        Public DefAttrSize As Integer
        Public CutPointOfPolygonColor As colorARGB
        Public LineEndPointVisible As Boolean
    End Structure
    Public Structure Setting_Info
        Public ObjectName_Word_Compatible As String
        Public SetFont As String
        Public MinimumLineWidth As Integer
        Public Printing_Time_Limit As Single
        Public Ido_Kedo_Print_Pattern As enmLatLonPrintPattern
        Public Compass_Mark As Integer
        Public Compass_Mark_Size As Single
        Public Header As String
        Public SinKyuCharacter As Boolean
        Public KatakanaCheck As Boolean
        Public default_Projection As enmProjection_Info
        Public MDRFileHistory As String
        Public BackImageSpeed As Integer
        Public Print_PropertyWindow As Boolean
        Public print_Property_Rect As Rectangle
        Public LegendMinusWord As String
        Public LegendPlusWord As String
        Public LegendBlockmodeWord As String
        Public MapEditor As mapeditor_Info
        Public Directory As Directory_info
        Public AntiAlias As Boolean
        Public defoHanreiColor As enmDefoHanreiColor
    End Structure
    Public Structure Color_Setting_Info
        Public UserColor As List(Of colorARGB)
        Public RecentColor As List(Of colorARGB)
    End Structure
    Public Structure User_ColorChart_Info
        Public Name As String
        Public Color As List(Of colorARGB)
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Structure
    Public Structure User_TileChart_Info
        Public Name As String
        Public Tile As List(Of Tile_Property)
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Structure
    Public Structure User_LineChart_Info
        Public Name As String
        Public Line As List(Of Line_Property)
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Structure
    Public Structure User_MarkChart_Info
        Public Name As String
        Public Mark As List(Of Mark_Property)
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Structure
    Public Structure User_Class_Setting_Info
        Public Color As List(Of User_ColorChart_Info)
        Public Tile As List(Of User_TileChart_Info)
        Public Mark As List(Of User_MarkChart_Info)
        Public Line As List(Of User_LineChart_Info)
    End Structure

    Public Structure UserLine_Info
        Public Lpat As Line_Property
        Public LpatName As String
    End Structure
    Public Structure LinePat_Setting_Info
        Public UserLinePat As List(Of UserLine_Info)
        Public RecentLinePat As List(Of Line_Property)
    End Structure
    Public Shared Data As Setting_Info
    Public Shared Color As Color_Setting_Info
    Public Shared Line As LinePat_Setting_Info
    Public Shared UserClass As User_Class_Setting_Info
End Class

Public Class clsHanrei_Defo_Color
    Public Structure colors_info
        Public PaintModeClass1 As colorARGB
        Public PaintModeClass2 As colorARGB
        Public MarkLineShapeColor As colorARGB
        Public MarkColor As colorARGB
        Public MarkBarColor As colorARGB
        Public MarkCommonMinusColor As colorARGB
    End Structure
    Public Shared Color As Dictionary(Of Integer, colors_info)

End Class