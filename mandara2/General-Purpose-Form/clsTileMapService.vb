Imports Shell32
Public Structure tilemapXML_info
    Public TileMapData() As strTileMapData_Info
End Structure

Public Enum enmDrawTiming
    ''' <summary>
    ''' 描画タイミングの設定をしない
    ''' </summary>
    ''' <remarks></remarks>
    BeforeDataDraw = 0
    AfterDataDraw = 1
End Enum
''' <summary>
''' タイルマップを描画する際の情報
''' </summary>
''' <remarks></remarks>
Public Structure strTileMapViewDataInfo
    Public AlphaValue As Integer
    Public TileMapDataSet As strTileMapData_Info
    Public LastUserFolder As String
    Public LastWorldFileFolder As String
    Public TransparentF As Boolean
End Structure

Public Enum enmXYZOrder
    ZXY = 0
    ZYX = 1
End Enum
''' <summary>
''' タイルマップのデータセットごとの情報
''' </summary>
''' <remarks></remarks>
Public Structure strTileMapData_Info
    Private Structure UserWorldFileList_Info
        Public FilePath As String
        Public LatLonBox As strLatLonBox
    End Structure
    Private UserWorldFile() As UserWorldFileList_Info
    ''' <summary>
    ''' 名称（タイルマップの名称、"ユーザー定義"、"ワールドファイル"）
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String
    ''' <summary>
    ''' 著作権表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Copyright As String
    ''' <summary>
    ''' タイルマップの場合はURL、ユーザー定義とワールドファイルの場合はフォルダ
    ''' </summary>
    ''' <remarks></remarks>
    Public URL As String
    ''' <summary>
    ''' データセットの種類を分類するためのタグ／タイルマップは"国土地理院"ほか、"ユーザー定義"、"ワールドファイル"
    ''' </summary>
    ''' <remarks></remarks>
    Public Tag As String
    ''' <summary>
    ''' 並び順(タイルマップの場合のみ)
    ''' </summary>
    ''' <remarks></remarks>
    Public ReverseF As Boolean '南西端が(0,0)の時true、北西端が(0,0)の時False
    ''' <summary>
    ''' 最小ズームレベル(タイルマップの場合のみ)
    ''' </summary>
    ''' <remarks></remarks>
    Public ZoomLevelMin As Integer
    ''' <summary>
    ''' 最大ズームレベル(タイルマップの場合のみ)
    ''' </summary>
    ''' <remarks></remarks>
    Public zoomLevelMax As Integer
    ''' <summary>
    ''' 拡張子(タイルマップの場合のみ)
    ''' </summary>
    ''' <remarks></remarks>
    Public exp As String
    Public StartYear As Integer
    Public EndYear As Integer
    Public ID As String
    Public IDSub As String
    Public ChacheFolderEnabled As Boolean
    Public XYZOrder As enmXYZOrder
    Public CommentaryURL As String
    Public LegendURL As String



    ''' <summary>
    ''' フォルダ内のユーザー画像ファイル／ワールドファイルの数を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getUserImageFileNumber() As Integer
        Try
            Return UserWorldFile.Length
        Catch ex As Exception
            Return -1
        End Try
    End Function
    ''' <summary>
    ''' フォルダ内の指定したユーザー画像ファイル／ワールドファイルのファイル名を取得
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getUserImageFileName(ByVal n As Integer) As String
        Return UserWorldFile(n).FilePath
    End Function
    ''' <summary>
    ''' フォルダ内の指定したユーザー画像ファイル／ワールドファイルのlatlonBoxを取得
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getUserImageFileLatLonBox(ByVal n As Integer) As strLatLonBox
        Return UserWorldFile(n).LatLonBox
    End Function
    ''' <summary>
    ''' ユーザー画像フォルダからファイルリストを作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function setUserImageFileList() As Boolean
        Dim GPFile As String = Me.URL & "\" & "position.csv"
        If System.IO.File.Exists(GPFile) = False Then
            MsgBox("ユーザー画像位置定義ファイル「position.csv」が指定のフォルダ内に見つかりません。", vbExclamation)
            Return False
        End If

        ReDim UserWorldFile(100)
        Dim n As Integer = 0
        Dim sr As New System.IO.StreamReader(GPFile, System.Text.Encoding.GetEncoding("shift_jis"))
        sr.ReadLine()
        Do Until sr.EndOfStream
            Dim Line As String = sr.ReadLine
            If Line <> "" Then
                Dim dataSplit() As String = Line.Split(",")
                If dataSplit.Length < 5 Then
                    MsgBox("ユーザー画像位置定義ファイル「position.csv」が不正です。", vbExclamation)
                    sr.Close()
                    Return False
                End If
                If UserWorldFile.GetUpperBound(0) < n Then
                    ReDim Preserve UserWorldFile(n + 50)
                End If
                With UserWorldFile(n)
                    .FilePath = dataSplit(0)
                    With .LatLonBox
                        .NorthWest.Longitude = Val(dataSplit(1))
                        .SouthEast.Longitude = Val(dataSplit(2))
                        .NorthWest.Latitude = Val(dataSplit(3))
                        .SouthEast.Latitude = Val(dataSplit(4))
                    End With
                    If 90 < Math.Max(Math.Abs(Val(dataSplit(3))), Math.Abs(Val(dataSplit(4)))) Then
                        MsgBox("ユーザー画像位置定義ファイル「position.csv」内の緯度の値が90を超えています。", vbExclamation)
                        sr.Close()
                        Return False
                    End If
                End With
                n += 1
            End If
        Loop
        sr.Close()
        If n = 0 Then
            MsgBox("表示可能な画像ファイルがありません。", MsgBoxStyle.Exclamation)
            Return False
        Else
            ReDim Preserve UserWorldFile(n - 1)
        End If
        Return True
    End Function

    Public Function setWorldImageFileList()

        If System.IO.Directory.Exists(Me.URL) = False Then
            MsgBox("フォルダ" + Me.URL + "が見つかりません。", MsgBoxStyle.Exclamation)
            Return False
        End If
        Dim FileNameList() As String = System.IO.Directory.GetFiles(Me.URL, "*.*", System.IO.SearchOption.TopDirectoryOnly)
        Dim allFileN As Integer = FileNameList.Length


        Dim IFN As Integer = 0
        Dim WFN As Integer = 0
        Dim ImageFileName_Extension(allFileN) As String
        Dim ImageFileName_withoutExtention(allFileN) As String
        Dim WorldFileName_Extension(allFileN) As String
        Dim WorldFileName_withoutExtention(allFileN) As String
        For i As Integer = 0 To allFileN - 1
            Dim ext As String = UCase(System.IO.Path.GetExtension(FileNameList(i)))
            Select Case ext
                Case ".PNG", ".BMP", ".GIF", ".JPG", ".JPEG", ".TIFF"
                    ImageFileName_Extension(IFN) = ext
                    ImageFileName_withoutExtention(IFN) = UCase(System.IO.Path.GetFileNameWithoutExtension(FileNameList(i)))
                    IFN += 1
                Case ".PNGW", ".BMPW", ".GIFW", ".JPGW", ".JPEGW", ".PGW", ".BPW", ".GFW", ".JGW", ".TIFFW"
                    WorldFileName_Extension(IFN) = ext
                    WorldFileName_withoutExtention(WFN) = UCase(System.IO.Path.GetFileNameWithoutExtension(FileNameList(i)))
                    WFN += 1
            End Select
        Next
        ReDim UserWorldFile(100)
        Dim n As Integer = 0
        For i As Integer = 0 To IFN - 1
            Dim ix As Integer = Array.IndexOf(WorldFileName_withoutExtention, ImageFileName_withoutExtention(i))
            If ix <> -1 Then
                Dim WFName As String = Me.URL & "\" + WorldFileName_withoutExtention(ix) + WorldFileName_Extension(ix)
                Dim IFileName As String = Me.URL & "\" + ImageFileName_withoutExtention(i) + ImageFileName_Extension(i)
                Dim NorthD As Double, WestD As Double
                Dim EastD As Double, SouthD As Double
                Dim Xplus As Double, YPlus As Double
                Dim f As Boolean = GetWorldFile(WFName, NorthD, WestD, Xplus, YPlus)
                If f = True Then
                    If UserWorldFile.GetUpperBound(0) < n Then
                        ReDim Preserve UserWorldFile(n + 50)
                    End If
                    Dim wh As Size = Get_Image_Size(IFileName)
                    If wh.Width <> 0 Then
                        UserWorldFile(n).FilePath = ImageFileName_withoutExtention(i) + ImageFileName_Extension(i)
                        EastD = WestD + wh.Width * Xplus
                        SouthD = NorthD + wh.Height * YPlus
                        With UserWorldFile(n).LatLonBox
                            .NorthWest.Latitude = NorthD
                            .NorthWest.Longitude = WestD
                            .SouthEast.Latitude = SouthD
                            .SouthEast.Longitude = EastD
                        End With
                        n += 1
                    End If
                End If

            End If
        Next
        If n = 0 Then
            MsgBox("表示可能な画像ファイルがありません。", MsgBoxStyle.Exclamation)
            Return False
        Else
            ReDim Preserve UserWorldFile(n - 1)
        End If
        Return True

    End Function

    ''' <summary>
    ''' ワールドファイルの読み込み
    ''' </summary>
    ''' <param name="WorldFilePath"></param>
    ''' <param name="North"></param>
    ''' <param name="West"></param>
    ''' <param name="Xplus"></param>
    ''' <param name="YPlus"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetWorldFile(ByVal WorldFilePath As String, ByRef North As Double, ByRef West As Double, _
            ByRef Xplus As Double, ByRef YPlus As Double) As Boolean
        '
        Try
            Dim sr As New System.IO.StreamReader(WorldFilePath, System.Text.Encoding.GetEncoding("shift_jis"))
            Do Until sr.EndOfStream
                Xplus = Val(sr.ReadLine)
                sr.ReadLine()
                sr.ReadLine()
                YPlus = Val(sr.ReadLine)
                West = Val(sr.ReadLine)
                North = Val(sr.ReadLine)
            Loop
            sr.Close()
        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function
    ''' <summary>
    ''' 画像ファイルの縦横サイズを求める
    ''' </summary>
    ''' <param name="Fname"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_Image_Size(ByVal Fname As String) As Size
        Dim shell As New ShellClass()
        Dim wh As Size

        Dim f As Folder = shell.NameSpace(System.IO.Path.GetDirectoryName(Fname))
        Dim item As FolderItem = f.ParseName(System.IO.Path.GetFileName(Fname))
        Dim SizeI As String = f.GetDetailsOf(item, 26) '26でもいいというが、win7/8では31
        If SizeI = "" Then
            SizeI = f.GetDetailsOf(item, 31)
        End If
        If SizeI = "" Then
        Else
            Dim v As String() = SizeI.Split(" × ")
            Dim reg As New System.Text.RegularExpressions.Regex("^\D*(?<w>\d+?)\D+(?<h>\d+?)\D*$")
            Dim mc = reg.Match(SizeI)
            wh.Width = Integer.Parse(mc.Groups("w").Value)
            wh.Height = Integer.Parse(mc.Groups("h").Value)
        End If
        Return wh
    End Function


End Structure

Public Class clsTileMapService


    Private Structure TileMap_Info
        Public tmpFolderName As String
        Public tilemaps As List(Of strTileMapData_Info)
    End Structure

    Private TileMapData As TileMap_Info

    Private Structure Watchize_Data_Info
        Public Fname As String
        Public LatLonBox As strLatLonBox
        Public ScrPosition As Rectangle
        Public URL As String
    End Structure
    Private Structure UserGazoFile_Info
        Public Fname As String
        Public LatLonBox As strLatLonBox
        Public ScrPosition As Rectangle
    End Structure

    Private LicenseFontData As Font_Property

    Public Sub AddTileMap(ByRef TMP As strTileMapData_Info)
        With Me.TileMapData.tilemaps
            .Add(TMP)
        End With
    End Sub
    Public Sub New(ByVal TileMapFolder As String)
        With TileMapData
            .tmpFolderName = TileMapFolder
            .tilemaps = New List(Of strTileMapData_Info)
        End With
        LicenseFontData = clsBase.Font
        With LicenseFontData
            .Body.Size = 2.5
            With .Back
                .Tile.TileCode = enmTilePattern.Paint
                .Tile.Line.BasicLine.SolidLine.Color = New colorARGB(200, 255, 255, 255)
            End With
        End With

    End Sub
    Public ReadOnly Property gettmpFolderName() As String
        Get
            Return TileMapData.tmpFolderName
        End Get
    End Property

    ''' <summary>
    ''' ライセンス表示用のフォント
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LicenseFont() As Font_Property
        Get
            Return LicenseFontData
        End Get
        Set(value As Font_Property)
            LicenseFontData = value
        End Set
    End Property
    ''' <summary>
    ''' タイルマップの中のタグの一覧を取得
    ''' </summary>
    ''' <returns>文字列のArraylist</returns>
    ''' <remarks></remarks>
    Public Function getTileMapTagList() As List(Of String)
        Dim TagList As New List(Of String)
        For i As Integer = 0 To TileMapData.tilemaps.Count - 1
            Dim Tile As strTileMapData_Info = TileMapData.tilemaps(i)
            If TagList.IndexOf(Tile.Tag) = -1 Then
                TagList.Add(Tile.Tag)
            End If
        Next
        Return TagList
    End Function
    ''' <summary>
    ''' タイルマップの中の指定した名称Nameのタイルマップを取得
    ''' </summary>
    ''' <param name="checkName">指定のタグ。空欄の場合チェックしない</param>
    ''' <returns>strTileMapData_Info構造体</returns>
    ''' <remarks></remarks>
    Public Function getTileMap_by_Name(ByVal checkName As String) As strTileMapData_Info
        For i As Integer = 0 To TileMapData.tilemaps.Count - 1
            Dim Tile As strTileMapData_Info = TileMapData.tilemaps(i)
            If Tile.Name = checkName Then
                Return Tile
            End If
        Next
        Return Nothing
    End Function
    ''' <summary>
    ''' 指定したタグに一致するタイルマップ一覧を配列で取得
    ''' </summary>
    ''' <param name="checkTag">指定のタグ。空欄の場合チェックしない</param>
    ''' <returns>strTileMapData_Info構造体の配列</returns>
    ''' <remarks></remarks>
    Public Function getTileMapList(ByVal checkTag As String) As strTileMapData_Info()
        Dim TileList(TileMapData.tilemaps.Count - 1) As strTileMapData_Info
        Dim n As Integer
        For i As Integer = 0 To TileMapData.tilemaps.Count - 1
            Dim Tile As strTileMapData_Info = TileMapData.tilemaps(i)
            Dim f As Boolean = True
            If checkTag <> "" Then
                If Tile.Tag <> checkTag Then
                    f = False
                End If
            End If
            If f = True Then
                TileList(n) = Tile
                n += 1
            End If
        Next
        If n = 0 Then
            TileList = Nothing
        Else
            ReDim Preserve TileList(n - 1)
        End If
        Return TileList
    End Function
    ''' <summary>
    ''' 指定したタグに一致するタイルマップを削除する
    ''' </summary>
    ''' <param name="checkTag"></param>
    ''' <remarks></remarks>
    Public Sub RemoveTileMapListByTag(ByVal checkTag As String)
        For i As Integer = TileMapData.tilemaps.Count - 1 To 0 Step -1
            Dim Tile As strTileMapData_Info = TileMapData.tilemaps(i)
            If Tile.Tag = checkTag Then
                TileMapData.tilemaps.RemoveAt(i)
            End If
        Next

    End Sub
    ''' <summary>
    ''' タイルマップを表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="TileMap">タイルマップデータのstrTileMapData_Info構造体</param>
    ''' <param name="TranparentF">白色を透過</param>
    ''' <param name="AlphaValue">透過度(0-100)</param>
    ''' <param name="BackImageSpeed">速度1-6</param>
    ''' <param name="MapData"></param>
    ''' <param name="ScrData"></param>
    ''' <remarks></remarks>
    Public Sub PrintTMS(ByRef g As Graphics, ByRef TileMap As strTileMapData_Info, ByVal TranparentF As Boolean, ByVal AlphaValue As Integer,
                        ByVal BackImageSpeed As Integer, ByRef MapData As clsMapData, ByRef ScrData As Screen_info)

        Select Case TileMap.Name
            Case "ユーザー定義"
                UserGazoFolder(g, TileMap, TranparentF, AlphaValue, MapData, ScrData)
                PrintCopyright(g, TileMap, ScrData)
            Case "ワールドファイル"
                UserGazoFolder(g, TileMap, TranparentF, AlphaValue, MapData, ScrData)
                PrintCopyright(g, TileMap, ScrData)
            Case Else
                If TileMapData.tmpFolderName <> "" Then
                    If TileMap_Show(g, TileMap, TranparentF, AlphaValue, BackImageSpeed, MapData, ScrData) = True Then
                        PrintCopyright(g, TileMap, ScrData)
                    End If
                End If
        End Select

    End Sub
    Private Sub UserGazoFolder(ByRef g As Graphics, ByRef TileMap As strTileMapData_Info, ByVal TranparentF As Boolean, ByVal AlphaValue As Integer, ByRef MapData As clsMapData, ByRef ScrData As Screen_info)

        Dim iRect As RectangleF = RectangleF.Intersect(ScrData.ScrRectangle, MapData.Map.Circumscribed_Rectangle)
        Dim ScrLatLonBox As strLatLonBox
        Dim p As PointF = spatial.Get_Reverse_XY(New PointF(iRect.Left, iRect.Top), MapData.Map.Zahyo)
        ScrLatLonBox.NorthWest = spatial.Get_World_IdoKedo(p, MapData.Map.Zahyo)
        p = spatial.Get_Reverse_XY(New PointF(iRect.Right, iRect.Bottom), MapData.Map.Zahyo)
        ScrLatLonBox.SouthEast = spatial.Get_World_IdoKedo(p, MapData.Map.Zahyo)
        Dim n As Integer = TileMap.getUserImageFileNumber
        If n = -1 Then
            Select Case TileMap.Name
                Case "ユーザー定義"
                    If TileMap.setUserImageFileList() = False Then
                        Return
                    End If
                    n = TileMap.getUserImageFileNumber
                Case "ワールドファイル"
                    If TileMap.setWorldImageFileList() = False Then
                        Return
                    End If
                    n = TileMap.getUserImageFileNumber
            End Select
        End If
        For i As Integer = 0 To n - 1
            Dim LatLonBox As strLatLonBox = TileMap.getUserImageFileLatLonBox(i)
            If spatial.Compare_Two_Rectangle_Position(LatLonBox.toRectangleF, ScrLatLonBox.toRectangleF) <> cstRectangle_Cross.cstOuter Then
                Dim NW As strLatLon = spatial.Get_ReverseWorld_IdoKedo(LatLonBox.NorthWest, MapData.Map.Zahyo)
                Dim SE As strLatLon = spatial.Get_ReverseWorld_IdoKedo(LatLonBox.SouthEast, MapData.Map.Zahyo)
                Dim NWpoint As Point = ScrData.getSxSy(spatial.Get_Converted_XY(NW.toPointF, MapData.Map.Zahyo))
                Dim SEpoint As Point = ScrData.getSxSy(spatial.Get_Converted_XY(SE.toPointF, MapData.Map.Zahyo))
                Dim w As Integer = SEpoint.X - NWpoint.X
                Dim H As Integer = SEpoint.Y - NWpoint.Y
                Dim tileRect As Rectangle = New Rectangle(NWpoint, New Size(w, H))
                Dim GFile As String = TileMap.URL & "\" & TileMap.getUserImageFileName(i)
                Call Show_Alpha_BackImage(g, TranparentF, AlphaValue, GFile, tileRect, MapData, ScrData)
            End If

        Next
    End Sub
    Private Function TileMap_Show(ByRef g As Graphics, ByRef TileMap As strTileMapData_Info, ByVal TranparentF As Boolean, ByVal AlphaValue As Integer,
                                  ByVal BackImageSpeed As Integer, ByRef MapData As clsMapData, ByRef ScrData As Screen_info) As Boolean
        'タイルマップ表示

        Dim Watchize_Data() As Watchize_Data_Info

        'Dim iRect As RectangleF = RectangleF.Intersect(ScrData.ScrRectangle, MapData.Map.Circumscribed_Rectangle)'地図領域のみ表示
        Dim iRect As RectangleF = RectangleF.Intersect(ScrData.ScrRectangle, ScrData.ScrRectangle) '画面全体に表示

        Dim ScrLatLonBox As strLatLonBox
        Dim p As PointF = spatial.Get_Reverse_XY(New PointF(iRect.Left, iRect.Top), MapData.Map.Zahyo)
        ScrLatLonBox.NorthWest = spatial.Get_World_IdoKedo(p, MapData.Map.Zahyo)
        p = spatial.Get_Reverse_XY(New PointF(iRect.Right, iRect.Bottom), MapData.Map.Zahyo)
        ScrLatLonBox.SouthEast = spatial.Get_World_IdoKedo(p, MapData.Map.Zahyo)

        If ScrLatLonBox.NorthWest.Latitude > 85 Then
            ScrLatLonBox.NorthWest.Latitude = 85
        End If
        If ScrLatLonBox.SouthEast.Latitude < -85 Then
            ScrLatLonBox.SouthEast.Latitude = -85
        End If

        Dim ZoomMin As Integer = TileMap.ZoomLevelMin
        Dim ZoomMax As Integer = TileMap.zoomLevelMax
        Dim g_num As Long

        Dim z As Integer = ZoomMax
        Do
            g_num = Get_TileMap_Image_Number(z, ScrLatLonBox)
            z -= 1
        Loop Until g_num < BackImageSpeed * 10 Or z < ZoomMin
        If z + 1 < ZoomMin Or g_num >= BackImageSpeed * 10 Then
            'MsgBox("背景画像を表示するにはさらに拡大してください。", MsgBoxStyle.Exclamation)
            Return False
        End If
        Dim ZoomLevel As Integer = z + 1
        Dim n As Double

        Call Get_TileMap_Image(TileMap, ZoomLevel, ScrLatLonBox, n, Watchize_Data, MapData.Map.Zahyo, ScrData)


        For i As Integer = 0 To n - 1
            With Watchize_Data(i)
                If .URL <> "" Then
                    Dim f As Boolean = clsGeneric.UrlToFile(.URL, .Fname, False)
                    If f = True Then
                        .URL = ""
                    End If
                End If
                If .URL = "" Then
                    Call Show_Alpha_BackImage(g, TranparentF, AlphaValue, .Fname, .ScrPosition, MapData, ScrData)
                End If
            End With
        Next
        Return True
    End Function
    Private Sub Show_Alpha_BackImage(ByRef g As Graphics, ByVal TranparentF As Boolean, ByVal AlphaValue As Integer, ByVal FilePath As String, ByVal TileBox As Rectangle,
                                     ByRef MapData As clsMapData, ByRef ScrData As Screen_info)


        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor
        Try
            Dim img As Image = Image.FromFile(FilePath)
            If AlphaValue = 255 And TranparentF = False Then
                g.DrawImage(img, TileBox.Left, TileBox.Top, TileBox.Width + 1, TileBox.Height + 1)
            Else
                Dim cm As New System.Drawing.Imaging.ColorMatrix()
                'ColorMatrixの行列の値を変更して、アルファ値を指定
                cm.Matrix00 = 1
                cm.Matrix11 = 1
                cm.Matrix22 = 1
                cm.Matrix33 = AlphaValue / 255
                cm.Matrix44 = 1
                'ImageAttributesオブジェクトの作成
                Dim ia As New System.Drawing.Imaging.ImageAttributes()
                'ColorMatrixを設定する
                ia.SetColorMatrix(cm)
                If TranparentF = True Then
                    '範囲を指定して透過
                    Dim HighColor As Color = Color.FromArgb(255, 255, 255) '白
                    Dim LowColor As Color = Color.FromArgb(150, 150, 150) '薄い灰色
                    ia.SetColorKey(LowColor, HighColor)
                End If

                'ImageAttributesを使用して画像を描画
                g.DrawImage(img, TileBox, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia)
            End If
            'リソースを解放する
            img.Dispose()
        Catch ex As Exception
        End Try

    End Sub
    ''' <summary>
    ''' 解像度と緯度経度範囲で、必要なタイルマップ数を求める
    ''' </summary>
    ''' <param name="ZoomLevel"></param>
    ''' <param name="ScrLatLonBox"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_TileMap_Image_Number(ByVal ZoomLevel As Single, ByVal ScrLatLonBox As strLatLonBox) As Long

        Dim StartP As Point = Get_TileMap_Image_Code(ZoomLevel, ScrLatLonBox.NorthWest)
        Dim EndP As Point = Get_TileMap_Image_Code(ZoomLevel, ScrLatLonBox.SouthEast)

        Dim w As Integer

        If StartP.X > EndP.X Then
            w = EndP.X + 2 ^ ZoomLevel - StartP.X + 1
        Else
            w = EndP.X - StartP.X + 1
        End If
        Dim H As Integer = EndP.Y - StartP.Y + 1
        Return CLng(w) * CLng(H)
    End Function

    Public Shared Function Get_TileMap_Image_Code(ByVal ZoomLevel As Integer, ByVal LatLon As strLatLon) As Point
        '緯度経度とズームレベルからタイルマップのXYを求める

        Dim TileXY As Point
        Dim r As Single = spatial.EarthR
        Dim Wz As Double = 2 * Math.PI * r / 2 ^ ZoomLevel
        With LatLon
            If .Latitude <= -90 Or 90 <= .Latitude Then
                .Latitude = Math.Sign(.Latitude) * 89.9999
            End If

            TileXY.X = Int((.Longitude / 180 + 1) * 2 ^ ZoomLevel / 2)
            TileXY.Y = Int((-Math.Log(Math.Tan((45 + .Latitude / 2) * Math.PI / 180)) + Math.PI) * 2 ^ ZoomLevel / (2 * Math.PI))
        End With
        Return TileXY
    End Function
    Private Sub Get_TileMap_Image(ByRef TileMap As strTileMapData_Info, ByVal ZoomLevel As Integer, ByVal ScrLatLonBox As strLatLonBox,
                ByRef FileNum As Long, ByRef Watchize_Data() As Watchize_Data_Info, ByRef MapZahyo As clsMapData.Zahyo_info, ByRef ScrData As Screen_info)


        FileNum = Get_TileMap_Image_Number(ZoomLevel, ScrLatLonBox)
        Dim StartP As Point = Get_TileMap_Image_Code(ZoomLevel, ScrLatLonBox.NorthWest)
        Dim EndP As Point = Get_TileMap_Image_Code(ZoomLevel, ScrLatLonBox.SouthEast)

        If FileNum < 0 Then
            '地図ファイルの投影法が変更されていた場合などにここになるケースがある
            Return
        End If
        ReDim Watchize_Data(FileNum)
        Dim ex As String = TileMap.exp
        Dim n As Long = 0
        For X As Integer = StartP.X To EndP.X
            For Y As Integer = StartP.Y To EndP.Y
                Dim xx As Integer = X
                Dim yy As Integer = Y
                Dim ry As Integer
                Dim ox As Integer = xx
                Call check_TileMap_XY(ZoomLevel, xx, yy)
                If TileMap.ReverseF = True Then
                    ry = 2 ^ ZoomLevel - yy - 1
                Else
                    ry = yy
                End If


                Dim Folder As String = TileMapData.tmpFolderName & "\" & Mid(TileMap.URL, InStr(TileMap.URL, "//") + 2).Replace("/", "\")
                Dim Fname As String = Folder
                Select Case TileMap.XYZOrder
                    Case enmXYZOrder.ZXY
                        Folder += CStr(ZoomLevel) & "\" + CStr(xx)
                        Fname = Folder + "\" + CStr(ry) + ex
                    Case enmXYZOrder.ZYX
                        Folder += CStr(ZoomLevel) & "\" & CStr(ry)
                        Fname = Folder + "\" + CStr(xx) + ex
                End Select
                Dim FolderExist As Boolean = System.IO.Directory.Exists(Folder)
                With Watchize_Data(n)
                    Call Get_TileMap_IdoKedo(ZoomLevel, ox, yy, .LatLonBox)
                    Dim NW As strLatLon = spatial.Get_ReverseWorld_IdoKedo(.LatLonBox.NorthWest, MapZahyo)
                    Dim SE As strLatLon = spatial.Get_ReverseWorld_IdoKedo(.LatLonBox.SouthEast, MapZahyo)
                    Dim NWpoint As Point = ScrData.getSxSy(spatial.Get_Converted_XY(NW.toPointF, MapZahyo))
                    Dim SEpoint As PointF = ScrData.getSxSy(spatial.Get_Converted_XY(SE.toPointF, MapZahyo))
                    .ScrPosition = New Rectangle(NWpoint, New Size(SEpoint.X - NWpoint.X, SEpoint.Y - NWpoint.Y))

                    .Fname = Fname
                    .URL = TileMap.URL & CStr(ZoomLevel) & "/"
                    Select Case TileMap.XYZOrder
                        Case enmXYZOrder.ZXY
                            .URL += CStr(xx) + "/" & CStr(ry) + ex
                        Case enmXYZOrder.ZYX
                            .URL += CStr(ry) + "/" & CStr(xx) + ex
                    End Select
                    If FolderExist = True Then
                        If System.IO.File.Exists(Fname) = True Then
                            .URL = ""
                        End If
                    Else
                        clsGeneric.MakeFolder(Folder)
                    End If
                End With
                n += 1
            Next
        Next

        n = 0
        Dim hplus As Integer = EndP.Y - StartP.Y + 1
        For X As Integer = StartP.X To EndP.X
            For Y As Integer = StartP.Y To EndP.Y
                If X <> EndP.X And Y <> EndP.Y Then
                    With Watchize_Data(n)
                        Dim w As Integer = Watchize_Data(n + hplus).ScrPosition.Left - .ScrPosition.Left
                        Dim h As Integer = Watchize_Data(n + 1).ScrPosition.Top - .ScrPosition.Top
                        .ScrPosition.Width = w
                        .ScrPosition.Height = h
                    End With
                End If
                n += 1
            Next
        Next

        FileNum = n
    End Sub
    Public Shared Sub Get_TileMap_IdoKedo(ByVal ZoomLevel As Integer, ByVal X As Integer, ByVal Y As Integer, _
                     ByRef TileLatLonBox As strLatLonBox)
        '指定したZoomのタイルマップの緯度経度を求める

        Dim tx As Double
        With TileLatLonBox
            .NorthWest.Longitude = (X / 2 ^ ZoomLevel) * 360 - 180
            .SouthEast.Longitude = ((X + 1) / 2 ^ ZoomLevel) * 360 - 180
            tx = (Y / 2 ^ ZoomLevel) * 2 * Math.PI - Math.PI
            .NorthWest.Latitude = 2 * Math.Atan(Math.Exp(-tx)) * 180 / Math.PI - 90
            tx = ((Y + 1) / 2 ^ ZoomLevel) * 2 * Math.PI - Math.PI
            .SouthEast.Latitude = 2 * Math.Atan(Math.Exp(-tx)) * 180 / Math.PI - 90
        End With

    End Sub

    ''' <summary>
    ''' タイルマップのXYの値が外れていた場合に修正する
    ''' </summary>
    ''' <param name="ZoomLevel"></param>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <remarks></remarks>
    Private Sub check_TileMap_XY(ByVal ZoomLevel As Integer, ByRef X As Integer, ByRef Y As Integer)

        If X < 0 Then
            X = -X
        End If
        If X > 2 ^ ZoomLevel - 1 Then
            X = X - 2 ^ ZoomLevel
        End If
        If Y < 0 Then
            Y = 0
        End If
        If Y > 2 ^ ZoomLevel - 1 Then
            Y = 2 ^ ZoomLevel - 1
        End If

    End Sub
    ''' <summary>
    ''' 画面左下に著作権表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="TileMap"></param>
    ''' <param name="LicenseFont"></param>
    ''' <param name="ScrData"></param>
    ''' <remarks></remarks>
    Private Sub PrintCopyright(ByRef g As Graphics, ByRef TileMap As strTileMapData_Info, ByVal ScrData As Screen_info)
        Dim x As Integer = 5
        Dim y As Integer = ScrData.MapScreen_Scale.Bottom - 5
        clsDraw.print(g, TileMap.Copyright, New Point(x, y), LicenseFontData, enmHorizontalAlignment.Left, enmVerticalAlignment.Bottom, ScrData, clsBase.PictureNoUse)
    End Sub

End Class


Public Class clsWebClient
    Inherits System.Net.WebClient
    Public tag As String
    Public filename As String
    Public TileLatLonBox As strLatLonBox

    Public AlphaValue As Integer
End Class
