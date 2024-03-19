'
' GIS Software MANDARA
' Source Code File name  frmMain.vb
'
' (C) 2016 - 2022 TANI Kenji
' License of this code is  CC BY-SA 4.0
'
' 2024  Errors and Warnings Collection by HORI Kazunari
'
Public Class frmMain
    Public Structure userTileXML_info
        Public utilecol As List(Of strTileMapData_Info)
    End Structure
    Private Enum enmSelectMode
        noMode = -1
        ClassPaintMode = 0
        MarkSizeMode = 1
        MarkBlockMode = 2
        ContourMode = 3
        ClassHatchMode = 4
        ClassMarkMode = 5
        ClassODMode = 6
        MarkTurnMode = 7
        MarkBarMode = 8
        StringMode = 9
        OverLayMode = 11
        SeriesMode = 12
        GraphMode = 21
        LabelMode = 22
        TripMode = 23
    End Enum
    Public Structure strMapList_Info
        Public name As String
        Public LatLonBox As strLatLonBox
        Public note As String
    End Structure
    Public Structure strkjmapDataSetAge_Info
        Public FolderName As String
        Public StartYear As Integer
        Public EndYear As Integer
        Public Scale As String
        Public MapList As List(Of strMapList_Info)
    End Structure
    Public Structure strkjmapDataSetList_info
        Public name As String
        Public folderName As String
        Public certification As String
        Public centerLatLon As strLatLon
        Public useMapType As ArrayList
        Public AgeDataSet As List(Of strkjmapDataSetAge_Info)
    End Structure

    Private Structure OldSelectedMode_info
        Public oldSelMode As enmSelectMode
        Public oldTotoalMode As enmTotalMode_Number
        Public oldLayerMode As enmLayerMode_Number
    End Structure
    Dim attrData As clsAttrData
    Dim SelectedMode As enmSelectMode
    Dim oldSelectedMode As List(Of OldSelectedMode_info)
    Dim Frm_ClassView As New frmMain_ClassViewSettings
    Dim Frm_MarkView As New frmMain_MarkViewSettings
    Dim Frm_ContourView As New frmMain_ContourViewSettings
    Dim Frm_Graph As New frmMain_GraphModeSettings
    Dim Frm_Label As New frmMain_LabelModeSettings
    Public Frm_Print As frmPrint
    Dim Frm_Trip As New frmMain_TripModeSettings
    Dim Frm_Overlay As New frmMain_OverLayModeSettings
    Dim Frm_Series As New frmMain_SeriesModeSettings
    Dim MANDARA10_datafolder As String
    Dim TileMapFolder As String
    Dim kjmapdataUrl As String
    Dim LoadingCloseF As Boolean = False
    Dim TileMap As clsTileMapService
    Dim man_Data As enmDataSource


    Private Sub mnuMapEditor_Click(sender As Object, e As EventArgs) Handles mnuMapEditor.Click
        Dim omandata As enmDataSource = man_Data
        If Check_EraseSettei_OK(False) = True Then
            Dim FileName As String
            Dim form As New frmMapEditor
            If omandata <> enmDataSource.NoData Then
                form.ShowDialog(attrData.SetMapFile(""), TileMap)
            Else
                form.ShowDialog("", TileMap)
            End If
            FileName = form.getResult
            form.Dispose()
            Me.Visible = True
            If FileName <> "" Then
                Show_Viewer(FileName)
            End If
        End If
    End Sub

    ''' <summary>
    ''' ドロップまたはコマンドラインからファイルを開く
    ''' </summary>
    ''' <param name="FIlePath"></param>
    ''' <remarks></remarks>
    Private Sub FileDrom_CommandLine(ByVal FilePath As String)
        Dim ext As String = System.IO.Path.GetExtension(FilePath)
        Select Case UCase(ext)
            Case ".MPF", ".MPFZ", ".MPFX"
                Me.Visible = False
                Dim form As New frmMapEditor
                form.ShowDialog(FilePath, TileMap)
                form.Dispose()
                Me.Visible = True
            Case ".CSV", ".MDR", ".MDRM", ".MDRMZ", ".MDRZ"
                Cursor.Current = Cursors.WaitCursor
                OpenNewMandaraFile(False, FilePath)
                Cursor.Current = Cursors.Default
        End Select

    End Sub




    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If LoadingCloseF = True Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor

        '設定ファイルの保存
        Dim swset As System.IO.StreamWriter = Nothing
        Try
            Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsSettings.Setting_Info))
            swset = New System.IO.StreamWriter(MANDARA10_datafolder + "\settings.xml", False, New System.Text.UTF8Encoding(False))
            serializer.Serialize(swset, clsSettings.Data)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If swset IsNot Nothing Then
                swset.Close()
            End If
        End Try

        'ユーザーカラー
        Dim swcol As System.IO.StreamWriter = Nothing
        Try
            Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsSettings.Color_Setting_Info))
            swcol = New System.IO.StreamWriter(MANDARA10_datafolder + "\Color_settings.xml", False, New System.Text.UTF8Encoding(False))
            serializer.Serialize(swcol, clsSettings.Color)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If swcol IsNot Nothing Then
                swcol.Close()
            End If
        End Try

        'ユーザーカラー/タイルチャート
        Dim swcoltile As System.IO.StreamWriter = Nothing
        Try
            Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsSettings.User_Class_Setting_Info))
            swcoltile = New System.IO.StreamWriter(MANDARA10_datafolder + "\User_Class.xml", False, New System.Text.UTF8Encoding(False))
            serializer.Serialize(swcoltile, clsSettings.UserClass)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If swcoltile IsNot Nothing Then
                swcoltile.Close()
            End If
        End Try


        'ユーザーライン
        Dim swLine As System.IO.StreamWriter = Nothing
        Try
            Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsSettings.LinePat_Setting_Info))
            swLine = New System.IO.StreamWriter(MANDARA10_datafolder + "\Line_settings.xml", False, New System.Text.UTF8Encoding(False))
            serializer.Serialize(swLine, clsSettings.Line)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If swLine IsNot Nothing Then
                swLine.Close()
            End If
        End Try

        'ユーザー設定タイルマップ
        Dim utile() As strTileMapData_Info = TileMap.getTileMapList("ユーザー設定タイルマップ")
        If utile Is Nothing = False Then
            Dim swuTile As System.IO.StreamWriter = Nothing
            Try
                Dim userTileXML As userTileXML_info
                userTileXML.utilecol = New List(Of strTileMapData_Info)
                userTileXML.utilecol.AddRange(utile)
                Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(userTileXML_info))
                swuTile = New System.IO.StreamWriter(MANDARA10_datafolder + "\user_tilemapdata.xml", False, New System.Text.UTF8Encoding(False))
                serializer.Serialize(swuTile, userTileXML)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If swuTile IsNot Nothing Then
                    swuTile.Close()
                End If
            End Try

        End If

        'キャッシュしないタイルマップフォルダを削除する
        If System.IO.Directory.Exists(TileMapFolder) = True Then
            Try
                System.IO.Directory.Delete(TileMapFolder, True)
            Catch ex As Exception
                MsgBox(ex.Message + vbCrLf + TileMapFolder)
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MANDARA10_datafolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\MANDARA10"
        System.IO.Directory.SetCurrentDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal))
        TileMapFolder = MANDARA10_datafolder + "\tilemap"

        kjmapdataUrl = "http://ktgis.net/kjmap/data/"
        If CheckMandara10_DataFile() = False Then
            LoadingCloseF = True
            Me.Close()
            Return
        End If

        If System.IO.Directory.Exists(MANDARA10_datafolder + "\MAP") = False Then
            MakeMapFolder()
        End If
        If System.IO.Directory.Exists(MANDARA10_datafolder + "\SAMPLE") = False Then
            MakeSampleFolder()
        End If

        TileMap = New clsTileMapService(TileMapFolder)

        ReadSettingFile()
        defoHanreiColorSet()

        readTileMapDataXML()
        ReadJavaScript_kjmapdataJS()

        man_Data = enmDataSource.NoData
        menu_Setting()
        Me.BackColor = pnlSettings.BackColor
        SetMDRFileHistorytoMenu()
        picTotalModeOverPanel.Visible = False

        Frm_Print = New frmPrint
        Frm_Print.Pre_load()
        Me.Text = "MANDARA"
    End Sub

    ''' <summary>
    ''' 凡例初期色設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function defoHanreiColorSet() As Dictionary(Of Integer, clsHanrei_Defo_Color.colors_info)
        Dim Gray As clsHanrei_Defo_Color.colors_info
        With Gray
            .PaintModeClass1 = New colorARGB(&HFF, 0, 0, 0)
            .PaintModeClass2 = New colorARGB(&HFF, &HFF, &HFF, &HFF)
            .MarkLineShapeColor = New colorARGB(Color.Black)
            .MarkColor = New colorARGB(255, &HC0, &HC0, &HC0)
            .MarkBarColor = New colorARGB(&HFF, &H80, &H80, &H80)
            .MarkCommonMinusColor = New colorARGB(Color.Gray)
        End With
        Dim Red As clsHanrei_Defo_Color.colors_info
        With Red
            .PaintModeClass1 = New colorARGB(&HFF, &H99, &H34, &H4)
            .PaintModeClass2 = New colorARGB(&HFF, &HFF, &HFF, &HD4)
            .MarkLineShapeColor = New colorARGB(Color.Brown)
            .MarkColor = New colorARGB(255, &HFF, &HBF, &HBF)
            .MarkBarColor = New colorARGB(&HFF, &HFF, &H80, &H0)
            .MarkCommonMinusColor = New colorARGB(&HFF, &H55, &H55, &HBF)
        End With
        Dim Blue As clsHanrei_Defo_Color.colors_info
        With Blue
            .PaintModeClass1 = New colorARGB(&HFF, &H8, &H51, &H9C)
            .PaintModeClass2 = New colorARGB(&HFF, &HEF, &HF3, &HFF)
            .MarkLineShapeColor = New colorARGB(Color.BlueViolet)
            .MarkColor = New colorARGB(255, &HBF, &HBF, &HFF)
            .MarkBarColor = New colorARGB(&HFF, &H0, &H80, &HFF)
            .MarkCommonMinusColor = New colorARGB(&HFF, &HBF, &H55, &H55)
        End With

        clsHanrei_Defo_Color.Color = New Dictionary(Of Integer, clsHanrei_Defo_Color.colors_info)
        clsHanrei_Defo_Color.Color.Add(enmDefoHanreiColor.Gray, Gray)
        clsHanrei_Defo_Color.Color.Add(enmDefoHanreiColor.Red, Red)
        clsHanrei_Defo_Color.Color.Add(enmDefoHanreiColor.Blue, Blue)

        Return clsHanrei_Defo_Color.Color

    End Function
    ''' <summary>
    ''' 最初の実行時にサンプルファイルを解凍してSampleフォルダに入れる
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function MakeSampleFolder() As Boolean
        Dim SampleFolder As String = MANDARA10_datafolder + "\SAMPLE"
        Dim myPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\samplefiles.zip"
        If System.IO.File.Exists(myPath) = False Then
            Return False
        End If
        If clsGeneric.MakeFolder(SampleFolder) = False Then
            Return False
        End If
        Try
            System.IO.Compression.ZipFile.ExtractToDirectory(myPath, SampleFolder)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    ''' <summary>
    ''' 最初の実行時に地図ファイルを解凍してMAPフォルダに入れる
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function MakeMapFolder() As Boolean
        Dim MapFolder As String = MANDARA10_datafolder + "\MAP"
        Dim myPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\mapfiles.zip"
        If System.IO.File.Exists(myPath) = False Then
            Return False
        End If
        If clsGeneric.MakeFolder(MapFolder) = False Then
            Return False
        End If
        Try
            System.IO.Compression.ZipFile.ExtractToDirectory(myPath, MapFolder)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    ''' 
    ''' 設定ファイル読み込み
    ''' 
    ''' 
    ''' 
    Private Sub ReadSettingFile()

        Dim erf As Boolean = True
        Dim fileName As String = MANDARA10_datafolder + "\settings.xml"
        If System.IO.File.Exists(fileName) = True Then
            Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsSettings.Setting_Info))
            Try
                'アンチエイリアス設定前のファイルを読んだ際に，ONにするための処理
                Dim atf As Boolean = True
                Dim xmldoc As New System.Xml.XmlDocument
                xmldoc.Load(fileName)
                Dim aa As System.Xml.XmlNodeList = xmldoc.GetElementsByTagName("AntiAlias")
                If aa.Count = 0 Then
                    atf = False
                End If

                Dim sr As New System.IO.StreamReader(fileName, New System.Text.UTF8Encoding(False))
                clsSettings.Data = DirectCast(serializer.Deserialize(sr), clsSettings.Setting_Info)
                sr.Close()
                If atf = False Then
                    clsSettings.Data.AntiAlias = True
                End If
                erf = False
            Catch ex As Exception
                erf = True
            End Try

        End If
        If erf = True Then
            With clsSettings.Data
                With .MapEditor
                    .MapFileHistory = "|"
                    .ObjectNameVisibleFlag = True
                    .Backcolor = New colorARGB(Color.White)
                    .LineColor = New colorARGB(Color.Black)
                    .LineColorDisabled = New colorARGB(50, 0, 0, 0)
                    .LineColorSelected = New colorARGB(Color.Blue)
                    .LineColorPoints = New colorARGB(Color.Magenta)
                    .ObjectLineColor = New colorARGB(Color.Red)
                    .ObjectLineColorDisabled = New colorARGB(Color.Brown)
                    .ObjectTimeLineColor = New colorARGB(Color.Magenta)
                    .ObjectNameColor = New colorARGB(Color.Blue)
                    .ObjectNameSize = 10
                    .ObjectNamePrinting_Maxmun = 100
                    .DefAttrColor = New colorARGB(Color.Red)
                    .DefAttrSize = 10
                    .CutPointOfPolygonColor = New colorARGB(255, 150, 0, 255)
                    .LineEndPointVisible = False
                End With
                Dim F_Title(9) As String

                F_Title(0) = "日本.CSV"
                F_Title(1) = "日本市町村人口.csv"
                F_Title(2) = "日本市町村人口緯度経度.csv"
                F_Title(3) = "世界データ.csv"
                F_Title(4) = "日本の気候.csv"
                F_Title(5) = "USA.csv"
                F_Title(6) = "中国.csv"
                F_Title(7) = "3次メッシュ土地利用.csv"
                F_Title(8) = "東京地価公示標準地.csv"
                F_Title(9) = "移動データサンプル.csv"
                Dim FileHistory As String = ""
                For i As Integer = 0 To 9
                    FileHistory += MANDARA10_datafolder + "\SAMPLE\" + F_Title(i) + "|"
                Next
                With .Directory
                    .Kiban = MANDARA10_datafolder
                    .CensusGIS = MANDARA10_datafolder
                    .ASTERGDEM = MANDARA10_datafolder
                    .DataFile = MANDARA10_datafolder
                    .ETOPO5 = MANDARA10_datafolder
                    .ImageFile = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                    .Kiban10mMesh = MANDARA10_datafolder
                    .Kiban5mMesh = MANDARA10_datafolder
                    .KML = MANDARA10_datafolder
                    .OSM = MANDARA10_datafolder
                    .GPX = MANDARA10_datafolder
                    .E00File = MANDARA10_datafolder
                    .Mapfile = MANDARA10_datafolder + "\MAP"
                    .MapFolder_Default = enmMapFolder_Default_info.LastAccesedFolder
                    .Shapefile = MANDARA10_datafolder
                    .SRTM3 = MANDARA10_datafolder
                    .SRTM30Plus = MANDARA10_datafolder
                    .SuchiTizu1kMesh = MANDARA10_datafolder
                    .SuchiTizu250Mesh = MANDARA10_datafolder
                    .SuchiTizu50Mesh = MANDARA10_datafolder
                    .TileOut = MANDARA10_datafolder
                End With
                .MDRFileHistory = FileHistory
                .ObjectName_Word_Compatible = "ヶガケかカヵ|曽曾|桧檜|条條|蕊蘂|釜竈竃|桜櫻|当當|頸頚|梼檮|挾狭|諫諌|鶯鴬|真眞|篭籠|鯵鰺|檮梼|藪薮|龍竜"
                .SetFont = "MS UI Gothic"
                .MinimumLineWidth = 4
                .Printing_Time_Limit = 1
                .Ido_Kedo_Print_Pattern = enmLatLonPrintPattern.DecimalDegree
                .Compass_Mark = 11
                .Compass_Mark_Size = 8
                .Header = ""
                .SinKyuCharacter = True
                .KatakanaCheck = True
                .default_Projection = enmProjection_Info.prjMercator
                .BackImageSpeed = 3
                .Print_PropertyWindow = True
                .print_Property_Rect = New Rectangle(0, 0, 0, 0)
                .LegendMinusWord = "負の値"
                .LegendPlusWord = "正の値"
                .LegendBlockmodeWord = "1個あたり"
                .AntiAlias = True
                .defoHanreiColor = enmDefoHanreiColor.Gray
            End With
        End If

        '色の設定ファイル
        Dim ColorfileName As String = MANDARA10_datafolder + "\Color_settings.xml"
        Try
            Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsSettings.Color_Setting_Info))
            Dim sr As New System.IO.StreamReader(ColorfileName, New System.Text.UTF8Encoding(False))
            clsSettings.Color = DirectCast(serializer.Deserialize(sr), clsSettings.Color_Setting_Info)
            sr.Close()
            For i As Integer = clsSettings.Color.UserColor.Count To 8
                clsSettings.Color.UserColor.Add(New colorARGB(Color.White))
            Next
            For i As Integer = clsSettings.Color.RecentColor.Count To 8
                clsSettings.Color.UserColor.Add(New colorARGB(Color.White))
                clsSettings.Color.RecentColor.Add(New colorARGB(Color.White))
            Next
        Catch ex As Exception
            clsSettings.Color.UserColor = New List(Of colorARGB)
            clsSettings.Color.RecentColor = New List(Of colorARGB)
            For i As Integer = 0 To 7
                clsSettings.Color.UserColor.Add(New colorARGB(Color.White))
                clsSettings.Color.RecentColor.Add(New colorARGB(Color.White))
            Next
        End Try

        'ユーザーカラーチャート設定ファイル
        Dim ColorChartfileName As String = MANDARA10_datafolder + "\User_Class.xml"
        Try
            Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsSettings.User_Class_Setting_Info))
            Dim sr As New System.IO.StreamReader(ColorChartfileName, New System.Text.UTF8Encoding(False))
            clsSettings.UserClass = DirectCast(serializer.Deserialize(sr), clsSettings.User_Class_Setting_Info)
            sr.Close()
        Catch ex As Exception
            With clsSettings.UserClass
                .Color = New List(Of clsSettings.User_ColorChart_Info)
                .Tile = New List(Of clsSettings.User_TileChart_Info)
                .Mark = New List(Of clsSettings.User_MarkChart_Info)
                .Line = New List(Of clsSettings.User_LineChart_Info)
            End With
        End Try

        '線種の設定ファイル
        Dim LinefileName As String = MANDARA10_datafolder + "\Line_settings.xml"
        Dim defUserLine As clsSettings.UserLine_Info
        defUserLine.Lpat = clsBase.Line
        defUserLine.LpatName = "未設定"
        Try
            Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsSettings.LinePat_Setting_Info))
            Dim sr As New System.IO.StreamReader(LinefileName, New System.Text.UTF8Encoding(False))
            clsSettings.Line = DirectCast(serializer.Deserialize(sr), clsSettings.LinePat_Setting_Info)
            sr.Close()
            For i As Integer = clsSettings.Color.UserColor.Count To 10
                clsSettings.Line.UserLinePat.Add(defUserLine)
            Next
            For i As Integer = clsSettings.Color.RecentColor.Count To 10
                clsSettings.Line.UserLinePat.Add(defUserLine)
                clsSettings.Line.RecentLinePat.Add(clsBase.Line)
            Next
        Catch ex As Exception
            clsSettings.Line.UserLinePat = New List(Of clsSettings.UserLine_Info)
            clsSettings.Line.RecentLinePat = New List(Of Line_Property)
            For i As Integer = 0 To 9
                clsSettings.Line.UserLinePat.Add(defUserLine)
                clsSettings.Line.RecentLinePat.Add(clsBase.Line)
            Next
        End Try
    End Sub
    ''' <summary>
    ''' データフォルダにkjmapdata.js、tilemapdata.xml、dataversion.txtをコピー（存在しない場合）
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckMandara10_DataFile() As Boolean
        If System.IO.Directory.Exists(MANDARA10_datafolder) = False Then
            'mydocumentにkjmap3フォルダが存在しない場合はフォルダを作成
            If clsGeneric.MakeFolder(MANDARA10_datafolder) = False Then
                MsgBox(MANDARA10_datafolder + "を作成できなかったため、終了します。", vbExclamation)
                Return False
            End If
        End If
        If System.IO.Directory.Exists(TileMapFolder) = False Then
            If clsGeneric.MakeFolder(TileMapFolder) = False Then
                'タイルマップフォルダが作成できなくてもエラーとしない
                Return True
            End If
        End If
        Dim downloadF As Boolean = False
        Dim jsdataname As String = "\kjmapdata.js"
        Dim xmlfilename As String = "\tilemapdata.xml"
        Dim verfilename As String = "\dataversion.txt"
        Dim jsdatanameF As Boolean = System.IO.File.Exists(MANDARA10_datafolder + jsdataname)
        Dim xmlfilenameF As Boolean = System.IO.File.Exists(MANDARA10_datafolder + xmlfilename)
        Dim verfilenameF As Boolean = System.IO.File.Exists(MANDARA10_datafolder + verfilename)

        Dim myExeFolder As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

        If jsdatanameF = False Then
            Try
                System.IO.File.Copy(myExeFolder + jsdataname, MANDARA10_datafolder + jsdataname)
            Catch ex As Exception

            End Try
        End If

        If xmlfilenameF = False Then
            Try
                System.IO.File.Copy(myExeFolder + xmlfilename, MANDARA10_datafolder + xmlfilename)
            Catch ex As Exception

            End Try
        End If

        If verfilenameF = False Then
            Try
                System.IO.File.Copy(myExeFolder + verfilename, MANDARA10_datafolder + verfilename)
            Catch ex As Exception

            End Try
        End If
        Return True
    End Function
    ''' <summary>
    ''' タイルマップデータの設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Function readTileMapDataXML() As Boolean

        '外部タイルマップ
        Dim xmlfilename As String = MANDARA10_datafolder + "\tilemapdata.xml"
        If System.IO.File.Exists(xmlfilename) = True Then
            Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(tilemapXML_info))
            Dim sr As New System.IO.StreamReader(xmlfilename, New System.Text.UTF8Encoding(False))
            Dim tmxml As tilemapXML_info = DirectCast(serializer.Deserialize(sr), tilemapXML_info)
            sr.Close()
            For i As Integer = 0 To tmxml.TileMapData.Length - 1
                TileMap.AddTileMap(tmxml.TileMapData(i))
            Next
        End If

        'ユーザー設定タイルマップ
        Dim uxmlfilename As String = MANDARA10_datafolder + "\user_tilemapdata.xml"
        If System.IO.File.Exists(uxmlfilename) = True Then
            Dim userializer As New System.Xml.Serialization.XmlSerializer(GetType(userTileXML_info))
            Dim usr As New System.IO.StreamReader(uxmlfilename, New System.Text.UTF8Encoding(False))
            Try
                Dim utmxml As userTileXML_info = DirectCast(userializer.Deserialize(usr), userTileXML_info)
                For i As Integer = 0 To utmxml.utilecol.Count - 1
                    TileMap.AddTileMap(utmxml.utilecol(i))
                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Finally
                usr.Close()
            End Try
        End If

        Return True
    End Function
    ''' <summary>
    ''' kjmapdata.jsを読み込む
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ReadJavaScript_kjmapdataJS() As Boolean
        Dim jsdataname As String = MANDARA10_datafolder + "\kjmapdata.js"
        If System.IO.File.Exists(jsdataname) = False Then
            Return False
        End If
        Dim sr As New System.IO.StreamReader(jsdataname, System.Text.Encoding.GetEncoding("utf-8"))
        Dim DataSet As String = Nothing
        Dim kjmapDataSet As New Dictionary(Of String, strkjmapDataSetList_info)
        Dim DatasetOrder(100) As String
        Dim Dataset_n As Integer = 0
        Do Until sr.EndOfStream
            Dim str As String = Trim(sr.ReadLine())
            If Microsoft.VisualBasic.Left(str, 21) = "kjmapDataSetList.push" Then
                Dim st(5) As String
                For i As Integer = 0 To 5
                    st(i) = Trim(sr.ReadLine())
                Next
                Dim kjdata As strkjmapDataSetList_info
                With kjdata
                    .name = clsGeneric.Get_InnerStrings(st(0), Chr(34), Chr(34))
                    .folderName = clsGeneric.Get_InnerStrings(st(1), Chr(34), Chr(34))
                    .certification = clsGeneric.Get_InnerStrings(st(2), Chr(34), Chr(34))
                    Dim lat As Single = Val(clsGeneric.Get_InnerStrings(st(3), ":", ","))
                    Dim lon As Single = Val(clsGeneric.Get_InnerStrings(st(4), ":", ","))
                    .centerLatLon = New strLatLon(lat, lon)
                    Dim T As String = clsGeneric.Get_InnerStrings(st(5), "[", "]")
                    Dim T2() As String = T.Split(",")
                    .useMapType = New ArrayList
                    For i As Integer = 0 To T2.Length - 1
                        .useMapType.Add(clsGeneric.Get_InnerStrings(T2(i), "'", "'"))
                    Next
                    .AgeDataSet = New List(Of strkjmapDataSetAge_Info)
                    If DatasetOrder.Length < Dataset_n Then
                        ReDim Preserve DatasetOrder(Dataset_n + 10)
                    End If
                    DatasetOrder(Dataset_n) = .folderName
                    Dataset_n += 1
                End With
                kjmapDataSet.Add(kjdata.folderName, kjdata)
            ElseIf Microsoft.VisualBasic.Left(str, 13) = "kjmapDataSet[" Then
                DataSet = clsGeneric.Get_InnerStrings(str, "'", "'")
            ElseIf Microsoft.VisualBasic.Left(str, 16) = "dataset.age.push" Then
                Dim T() As String = sr.ReadLine().Split(",")
                Dim age As strkjmapDataSetAge_Info
                age.FolderName = clsGeneric.Get_InnerStrings(T(0), "'", "'")
                age.StartYear = Val(Mid(T(1), InStr(T(1), ":") + 1))
                age.EndYear = Val(Mid(T(2), InStr(T(2), ":") + 1))
                age.Scale = clsGeneric.Get_InnerStrings(T(3), "'", "'")
                age.MapList = New List(Of strMapList_Info)
                Dim maplist As strMapList_Info
                Do
                    Dim TX As String = Trim(sr.ReadLine())
                    If Microsoft.VisualBasic.Right(TX, 1) = ";" Then
                        kjmapDataSet(DataSet).AgeDataSet.Add(age)
                        Exit Do
                    ElseIf Mid(TX, 1, 1) = "{" Then
                        Dim at() As String = TX.Split(",")
                        With maplist
                            .name = clsGeneric.Get_InnerStrings(at(0), "'", "'")
                            Dim north As Single = Val(Mid(at(1), InStr(at(1), ":") + 1))
                            Dim west As Single = Val(Mid(at(2), InStr(at(2), ":") + 1))
                            Dim south As Single = Val(Mid(at(3), InStr(at(3), ":") + 1))
                            Dim east As Single = Val(Mid(at(4), InStr(at(4), ":") + 1))
                            .LatLonBox = New strLatLonBox(New strLatLon(north, west), New strLatLon(south, east))
                            .note = clsGeneric.Get_InnerStrings(at(5), "'", "'")
                        End With
                        age.MapList.Add(maplist)
                    End If
                Loop
            End If

        Loop
        sr.Close()
        For i As Integer = 0 To Dataset_n - 1
            Dim kjdataset As strkjmapDataSetList_info = kjmapDataSet(DatasetOrder(i))
            With kjdataset
                For j As Integer = 0 To .AgeDataSet.Count - 1
                    Dim TileMapSet As New strTileMapData_Info
                    TileMapSet.Name = "今昔マップ on the web:" + .name + ":"
                    TileMapSet.Copyright = "今昔マップ on the web" + vbCrLf + "(C)谷謙二"
                    TileMapSet.Tag = "今昔マップ"
                    TileMapSet.XYZOrder = enmXYZOrder.ZXY
                    TileMapSet.exp = ".png"
                    With .AgeDataSet(j)
                        TileMapSet.URL = "http://ktgis.net/kjmapw/kjtilemap/" + kjdataset.folderName + "/" + .FolderName + "/"
                        TileMapSet.StartYear = .StartYear
                        TileMapSet.EndYear = .EndYear
                        TileMapSet.ReverseF = True
                        TileMapSet.LegendURL = ""
                        TileMapSet.Name += .StartYear.ToString + "年-" + .EndYear.ToString + "年"
                        TileMapSet.ID = "kjmap"
                        TileMapSet.IDSub = DatasetOrder(i)
                        TileMapSet.ZoomLevelMin = 8
                        If .Scale = "1/50000" Then
                            TileMapSet.zoomLevelMax = 15
                        Else
                            TileMapSet.zoomLevelMax = 16
                        End If
                    End With
                    TileMap.AddTileMap(TileMapSet)
                Next
            End With
        Next

        Return True
    End Function
    Private Sub mnuDataFromClipboard_Click(sender As Object, e As EventArgs) Handles mnuDataFromClipboard.Click
        If Check_EraseSettei_OK(True) = True Then
            Cursor.Current = Cursors.WaitCursor
            OpenNewMandaraFile(True, "Clipboard")
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Sub mnuFileProperty_Click(sender As Object, e As EventArgs) Handles mnuFileProperty.Click
        Dim form As New frmMain_Property
        form.ShowDialog(Me, attrData)
        form.Dispose()
    End Sub

    Private Sub mnuOpenDataFile_Click(sender As Object, e As EventArgs) Handles mnuOpenDataFile.Click
        If Check_EraseSettei_OK(True) = True Then
            Dim ofd As New OpenFileDialog
            If clsSettings.Data.Directory.DataFile = "" Then
                clsSettings.Data.Directory.DataFile = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)
            End If
            ofd.InitialDirectory = clsSettings.Data.Directory.DataFile
            ofd.Filter = "MANDARAデータファイル(*.csv;*.mdrz;*.mdrmz;*.mdr;*.mdrm)|*.csv;*.mdrz;*.mdrmz;*.mdr;*.mdrm|CSVファイル(*.csv)|*.csv|属性データファイル(*.mdrz)|*.mdrz|地図ファイル付属形式ファイル(*.mdrmz)|*.mdrmz|旧データファイル(*.mdr;*.mdrm)|*.mdr;*.mdrm|すべてのファイル(*.*)|*.*"
            If ofd.ShowDialog() = DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                OpenNewMandaraFile(False, ofd.FileName)
                Cursor.Current = Cursors.Default
            End If
        End If

    End Sub
    ''' <summary>
    ''' MANDARAファイルを開く
    ''' </summary>
    ''' <param name="ClipBoardFlag"></param>
    ''' <param name="FileFullPath"></param>
    ''' <remarks></remarks>
    Private Sub OpenNewMandaraFile(ByVal ClipBoardFlag As Boolean, ByVal FileFullPath As String)
        Frm_Print.Visible = False
        Dim ObjectErrorMessage As String = ""
        attrData = New clsAttrData(TileMap)
        Dim f As Boolean = attrData.OpenNewMandaraFile(ClipBoardFlag, FileFullPath, ObjectErrorMessage, ProgressBar)

        If ObjectErrorMessage <> "" Then
            Cursor.Current = Cursors.Default
            clsGeneric.Message(Me, "読み込みエラー", ObjectErrorMessage, True, False)
        End If
        If f = False Then
            Cursor.Current = Cursors.Default
            MsgBox("MANDARAデータとして読み込めませんでした。")
        Else
            Me.Text = attrData.TotalData.LV1.FileName
            Dim non_clearf As Boolean = False
            With attrData.TotalData.LV1
                man_Data = .DataSourceType
                If .DataSourceType <> enmDataSource.Clipboard Then
                    clsSettings.Data.Directory.DataFile = System.IO.Path.GetDirectoryName(FileFullPath)
                    replaceMDRFileHistory(attrData.TotalData.LV1.FullPath)
                End If
                If .DataSourceType = enmDataSource.MDR Or .DataSourceType = enmDataSource.MDRM Or
                    .DataSourceType = enmDataSource.MDRZ Or .DataSourceType = enmDataSource.MDRMZ Then
                    non_clearf = True
                End If
            End With
            Init_Screen_Set(non_clearf)
            initFirtScreen()
            menu_Setting()

        End If
        Me.Activate()
    End Sub
    ''' <summary>
    ''' 読み込み直後の初期表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initFirtScreen()
        Dim bcol As Color = Color.White
        lblClassMark.BackColor = bcol
        lblContour.BackColor = bcol
        lblGraph.BackColor = bcol
        lblClassHatch.BackColor = bcol
        lblLabel.BackColor = bcol
        lblMarkSize.BackColor = bcol
        lblMarkBlock.BackColor = bcol
        lblMarkTurn.BackColor = bcol
        lblMarkTurn.BackColor = bcol
        lblMarkBar.BackColor = bcol
        lblClassOD.BackColor = bcol
        lblOverlay.BackColor = bcol
        lblClassPaint.BackColor = bcol
        lblSeries.BackColor = bcol
        lblString.BackColor = bcol
        lblTrip.BackColor = bcol
        picClassMark.BackColor = bcol
        picContour.BackColor = bcol
        picGraph.BackColor = bcol
        picClassHatch.BackColor = bcol
        picLabel.BackColor = bcol
        picMarkSize.BackColor = bcol
        picMarkBlock.BackColor = bcol
        picMarkTurn.BackColor = bcol
        picMarkBar.BackColor = bcol
        picClassOD.BackColor = bcol
        picOverlay.BackColor = bcol
        picClassPaint.BackColor = bcol
        picSeries.BackColor = bcol
        picTrip.BackColor = bcol
        picString.BackColor = bcol
        pnlClassMark.BackColor = bcol
        pnlContour.BackColor = bcol
        pnlGraph.BackColor = bcol
        pnlClassHatch.BackColor = bcol
        pnlLabel.BackColor = bcol
        pnlMarkSize.BackColor = bcol
        pnlMarkBlock.BackColor = bcol
        pnlMarkTurn.BackColor = bcol
        pnlMarkBar.BackColor = bcol
        pnlString.BackColor = bcol
        pnlClassOD.BackColor = bcol
        pnlOverlay.BackColor = bcol
        pnlClassPaint.BackColor = bcol
        pnlSeries.BackColor = bcol
        pnlTrip.BackColor = bcol

        'Frm_ClassView.BackColor = pnlSettings.BackColor
        pnlSettings.Visible = True
        SelectedMode = enmSelectMode.noMode
        attrData.Set_LayerName_to(cboLayer, attrData.TotalData.LV1.SelectedLayer)

        If attrData.TotalData.LV1.Lay_Maxn = 1 And attrData.LayerData(0).Name = "" Then
            lblLayer.Visible = False
            cboLayer.Visible = False
        Else
            lblLayer.Visible = True
            cboLayer.Visible = True
        End If
    End Sub
    ''' <summary>
    ''' モードセレクタ入る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub View_MouseEnter(sender As Object, e As EventArgs) Handles lblClassMark.MouseEnter,
        lblGraph.MouseEnter, lblClassHatch.MouseEnter, lblLabel.MouseEnter, lblMarkSize.MouseEnter, lblMarkBlock.MouseEnter, lblMarkTurn.MouseEnter,
        lblClassOD.MouseEnter, lblOverlay.MouseEnter, lblClassPaint.MouseEnter, lblSeries.MouseEnter, lblTrip.MouseEnter, lblMarkBar.MouseEnter,
        picClassMark.MouseEnter, picContour.MouseEnter,
        picGraph.MouseEnter, picClassHatch.MouseEnter, picLabel.MouseEnter, picMarkSize.MouseEnter, picMarkBlock.MouseEnter, picMarkTurn.MouseEnter,
        picClassOD.MouseEnter, picOverlay.MouseEnter, picClassPaint.MouseEnter, picSeries.MouseEnter, picTrip.MouseEnter, picMarkBar.MouseEnter,
        pnlClassMark.MouseEnter, pnlContour.MouseEnter,
        pnlGraph.MouseEnter, pnlClassHatch.MouseEnter, pnlLabel.MouseEnter, pnlMarkSize.MouseEnter, pnlMarkBlock.MouseEnter, pnlMarkTurn.MouseEnter,
        pnlClassOD.MouseEnter, pnlOverlay.MouseEnter, pnlClassPaint.MouseEnter, pnlSeries.MouseEnter, pnlTrip.MouseEnter, pnlMarkBar.MouseEnter,
        pnlString.MouseEnter, picString.MouseEnter, lblString.MouseEnter

        Dim name As String = Mid(sender.name, 4)
        If GetModeENUMfromControlName(name) <> SelectedMode Then
            SetModePicLabelBackColor(name, Color.FromArgb(255, 220, 220))
        End If


    End Sub
    ''' <summary>
    ''' モードセレクタ離れた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub View_MouseLeave(sender As Object, e As EventArgs) Handles lblClassMark.MouseLeave,
        lblGraph.MouseLeave, lblClassHatch.MouseLeave, lblLabel.MouseLeave, lblMarkSize.MouseLeave, lblMarkBlock.MouseLeave, lblMarkTurn.MouseLeave,
        lblClassOD.MouseLeave, lblOverlay.MouseLeave, lblClassPaint.MouseLeave, lblSeries.MouseLeave, lblTrip.MouseLeave, lblMarkBar.MouseLeave,
        picClassMark.MouseLeave, picContour.MouseLeave,
        picGraph.MouseLeave, picClassHatch.MouseLeave, picLabel.MouseLeave, picMarkSize.MouseLeave, picMarkBlock.MouseLeave, picMarkTurn.MouseLeave,
        picClassOD.MouseLeave, picOverlay.MouseLeave, picClassPaint.MouseLeave, picSeries.MouseLeave, picTrip.MouseLeave, picMarkBar.MouseLeave,
        pnlClassMark.MouseLeave, pnlContour.MouseLeave,
        pnlGraph.MouseLeave, pnlClassHatch.MouseLeave, pnlLabel.MouseLeave, pnlMarkSize.MouseLeave, pnlMarkBlock.MouseLeave, pnlMarkTurn.MouseLeave,
        pnlClassOD.MouseLeave, pnlOverlay.MouseLeave, pnlClassPaint.MouseLeave, pnlSeries.MouseLeave, pnlTrip.MouseLeave, pnlMarkBar.MouseLeave,
        pnlString.MouseLeave, picString.MouseLeave, lblString.MouseLeave

        Dim name As String = Mid(sender.name, 4)
        If name <> GetModeControlName(SelectedMode) Then
            SetModePicLabelBackColor(name, Color.White)

        End If


    End Sub
    ''' <summary>
    ''' 表示モードをマウスクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub View_MouseClick(sender As Object, e As EventArgs) Handles lblClassMark.MouseClick, lblContour.MouseClick,
        lblGraph.MouseClick, lblClassHatch.MouseClick, lblLabel.MouseClick, lblMarkSize.MouseClick, lblMarkBlock.MouseClick, lblMarkTurn.MouseClick,
        lblClassOD.MouseClick, lblOverlay.MouseClick, lblClassPaint.MouseClick, lblSeries.MouseClick, lblTrip.MouseClick, lblMarkBar.MouseClick,
        picClassMark.MouseClick, picContour.MouseClick,
        picGraph.MouseClick, picClassHatch.MouseClick, picLabel.MouseClick, picMarkSize.MouseClick, picMarkBlock.MouseClick, picMarkTurn.MouseClick,
        picClassOD.MouseClick, picOverlay.MouseClick, picClassPaint.MouseClick, picSeries.MouseClick, picTrip.MouseClick, picMarkBar.MouseClick,
        pnlClassMark.MouseClick, pnlContour.MouseClick,
        pnlGraph.MouseClick, pnlClassHatch.MouseClick, pnlLabel.MouseClick, pnlMarkSize.MouseClick, pnlMarkBlock.MouseClick, pnlMarkTurn.MouseClick,
        pnlClassOD.MouseClick, pnlOverlay.MouseClick, pnlClassPaint.MouseClick, pnlSeries.MouseClick, pnlTrip.MouseClick, pnlMarkBar.MouseClick,
        pnlString.MouseClick, picString.MouseClick, lblString.MouseClick

        Dim osel As enmSelectMode = SelectedMode
        SelectedModeClear()
        Dim name As String = Mid(sender.name, 4)
        SelectedMode = GetModeENUMfromControlName(name)
        Select Case name
            Case "Overlay", "Series"
                If picTotalModeOverPanel.Visible = False Then
                    picLayerModeOverPanel.Visible = False
                    Dim os As OldSelectedMode_info
                    os.oldSelMode = osel
                    os.oldTotoalMode = attrData.TotalData.LV1.Print_Mode_Total
                    oldSelectedMode.Add(os)
                    picTotalModeOverPanel_Visible()
                End If
                Select Case name
                    Case "Overlay"
                        attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.OverLayMode
                    Case "Series"
                        attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.SeriesMode
                End Select
            Case "Graph", "Label", "Trip"
                If picLayerModeOverPanel.Visible = False Then
                    picTotalModeOverPanel.Visible = False
                    Dim os As OldSelectedMode_info
                    os.oldSelMode = osel
                    os.oldTotoalMode = attrData.TotalData.LV1.Print_Mode_Total
                    If os.oldTotoalMode = enmTotalMode_Number.DataViewMode Then
                        os.oldLayerMode = attrData.LayerData(attrData.TotalData.LV1.SelectedLayer).Print_Mode_Layer
                    End If
                    oldSelectedMode.Add(os)
                    picLayerModeOverPanel_Visible()
                End If
                attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.DataViewMode
                Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
                Select Case name
                    Case "Graph"
                        attrData.LayerData(LayerNum).Print_Mode_Layer = enmLayerMode_Number.GraphMode
                    Case "Label"
                        attrData.LayerData(LayerNum).Print_Mode_Layer = enmLayerMode_Number.LabelMode
                    Case "Trip"
                        attrData.LayerData(LayerNum).Print_Mode_Layer = enmLayerMode_Number.TripMode
                End Select
            Case Else

                Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
                Dim DataNum As Integer = attrData.LayerData(LayerNum).atrData.SelectedIndex
                attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.DataViewMode
                attrData.LayerData(LayerNum).Print_Mode_Layer = enmLayerMode_Number.SoloMode
                attrData.LayerData(LayerNum).atrData.Data(DataNum).ModeData = GetSoloModeFromSelectMode(SelectedMode)

        End Select
        SelectModeSet()

    End Sub
    ''' 
    ''' 表示モードを選択状態に
    ''' 
    ''' 
    ''' 
    Private Sub SelectModeSet()
        Frm_Print.Visible = False
        If SelectedMode = enmSelectMode.noMode Then
            '文字列データの場合
            Frm_MarkView.Visible = False
            Frm_ContourView.Visible = False
            Frm_Graph.Visible = False
            Frm_Label.Visible = False
            Frm_Trip.Visible = False
            Frm_Series.Visible = False
            Frm_Overlay.Visible = False
            Frm_ClassView.Visible = False
            Check_Print_err()
            Return
        End If
        SetModePicLabelBackColor(GetModeControlName(SelectedMode), Color.FromArgb(255, 100, 100))
        btnSetSeries.Enabled = True
        Select Case SelectedMode
            Case enmSelectMode.ClassPaintMode, enmSelectMode.ClassHatchMode, enmSelectMode.ClassODMode, enmSelectMode.ClassMarkMode
                Frm_MarkView.Visible = False
                Frm_ContourView.Visible = False
                Frm_Graph.Visible = False
                Frm_Label.Visible = False
                Frm_Trip.Visible = False
                Frm_Series.Visible = False
                Frm_Overlay.Visible = False
                If Frm_ClassView.Visible = False Then
                    Frm_ClassView.Show(Me)
                    Frm_ClassView.Location = New Point(Me.Left + Me.Width, Me.Top)
                End If
                Frm_ClassView.SetData(attrData)
            Case enmSelectMode.MarkSizeMode, enmSelectMode.MarkBlockMode, enmSelectMode.MarkTurnMode, enmSelectMode.MarkBarMode, enmSelectMode.StringMode
                Frm_ClassView.Visible = False
                Frm_ContourView.Visible = False
                Frm_Graph.Visible = False
                Frm_Label.Visible = False
                Frm_Trip.Visible = False
                Frm_Series.Visible = False
                Frm_Overlay.Visible = False
                If Frm_MarkView.Visible = False Then
                    Frm_MarkView.Show(Me)
                    Frm_MarkView.Location = New Point(Me.Left + Me.Width, Me.Top)
                End If
                Frm_MarkView.SetData(attrData)
            Case enmSelectMode.ContourMode
                Frm_MarkView.Visible = False
                Frm_ClassView.Visible = False
                Frm_Graph.Visible = False
                Frm_Label.Visible = False
                Frm_Trip.Visible = False
                Frm_Series.Visible = False
                Frm_Overlay.Visible = False
                If Frm_ContourView.Visible = False Then
                    Frm_ContourView.Show(Me)
                    Frm_ContourView.Location = New Point(Me.Left + Me.Width, Me.Top)
                End If
                Frm_ContourView.SetData(attrData)
            Case enmSelectMode.GraphMode
                Frm_MarkView.Visible = False
                Frm_ClassView.Visible = False
                Frm_ContourView.Visible = False
                Frm_Label.Visible = False
                Frm_Trip.Visible = False
                Frm_Series.Visible = False
                Frm_Overlay.Visible = False
                If Frm_Graph.Visible = False Then
                    Frm_Graph.Show(Me)
                    Frm_Graph.Location = New Point(Me.Left + Me.Width, Me.Top)
                End If
                Frm_Graph.SetData(attrData)
            Case enmSelectMode.LabelMode
                Frm_MarkView.Visible = False
                Frm_ClassView.Visible = False
                Frm_ContourView.Visible = False
                Frm_Graph.Visible = False
                Frm_Trip.Visible = False
                Frm_Series.Visible = False
                Frm_Overlay.Visible = False
                If Frm_Label.Visible = False Then
                    Frm_Label.Show(Me)
                    Frm_Label.Location = New Point(Me.Left + Me.Width, Me.Top)
                End If
                Frm_Label.SetData(attrData)
            Case enmSelectMode.TripMode
                Frm_MarkView.Visible = False
                Frm_ClassView.Visible = False
                Frm_ContourView.Visible = False
                Frm_Graph.Visible = False
                Frm_Label.Visible = False
                Frm_Series.Visible = False
                Frm_Overlay.Visible = False
                If Frm_Trip.Visible = False Then
                    Frm_Trip.Show(Me)
                    Frm_Trip.Location = New Point(Me.Left + Me.Width, Me.Top)
                End If
                Frm_Trip.SetData(attrData)
            Case enmSelectMode.OverLayMode
                Frm_MarkView.Visible = False
                Frm_ClassView.Visible = False
                Frm_ContourView.Visible = False
                Frm_Graph.Visible = False
                Frm_Label.Visible = False
                Frm_Trip.Visible = False
                Frm_Series.Visible = False
                If Frm_Overlay.Visible = False Then
                    Frm_Overlay.Show(Me)
                    Frm_Overlay.Location = New Point(Me.Left + Me.Width, Me.Top)
                End If
                Frm_Overlay.SetData(attrData)
            Case enmSelectMode.SeriesMode
                Frm_MarkView.Visible = False
                Frm_ClassView.Visible = False
                Frm_ContourView.Visible = False
                Frm_Graph.Visible = False
                Frm_Label.Visible = False
                Frm_Trip.Visible = False
                Frm_Overlay.Visible = False
                If Frm_Series.Visible = False Then
                    Frm_Series.Show(Me)
                    Frm_Series.Location = New Point(Me.Left + Me.Width, Me.Top)
                End If
                Frm_Series.SetData(attrData)
                btnSetSeries.Enabled = False
        End Select
        If SelectedMode <> enmSelectMode.OverLayMode Then
            If attrData.LayerData(attrData.TotalData.LV1.SelectedLayer).Type = clsAttrData.enmLayerType.Trip_Definition Then
                btnSetSeries.Enabled = False
            End If
        End If
        Check_Print_err()
    End Sub
    Private Sub SetModePicLabelBackColor(ByVal Name As String, ByVal col As Color)
        Dim cs As Control()
        cs = Me.Controls.Find("lbl" + Name, True)
        CType(cs(0), Label).BackColor = col
        cs = Me.Controls.Find("pnl" + Name, True)
        CType(cs(0), Panel).BackColor = col

    End Sub

    ''' <summary>
    ''' '選択している単独モードがあった場合クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SelectedModeClear()
        Dim cs As Control()
        If SelectedMode <> enmSelectMode.noMode Then
            cs = Me.Controls.Find("lbl" + GetModeControlName(SelectedMode), True)
            CType(cs(0), Label).BackColor = Color.White
            cs = Me.Controls.Find("pnl" + GetModeControlName(SelectedMode), True)
            CType(cs(0), Panel).BackColor = Color.White
        End If

    End Sub

    ''' <summary>
    ''' レイヤボックスの選択変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayer.SelectedIndexChanged
        Dim LayerNum As Integer = cboLayer.SelectedIndex
        attrData.TotalData.LV1.SelectedLayer = LayerNum
        Frm_Print.Visible = False

        If LayerNum = -1 Then
            Return
        End If
        If attrData.LayerData(LayerNum).atrData.Count > 0 Then
            attrData.Set_DataTitle_to_cboBox(cboDataItem, LayerNum, attrData.LayerData(LayerNum).atrData.SelectedIndex)
            cboDataItem.Enabled = True
        Else
            'データ項目が無い場合（移動データモードの場合のみあり得る）
            cboDataItem.Items.Clear()
            cboDataItem.Enabled = False
            Dim val As enmSoloMode_Number
            For Each val In [Enum].GetValues(GetType(enmSoloMode_Number))
                If val <> enmSoloMode_Number.noMode Then
                    SetPicPnlDataEnabled(GetSelectModeFromSoloMode(val), False)
                End If
            Next
            '一つ前の選択を解除
            SetModePicLabelBackColor(GetModeControlName(SelectedMode), Color.White)
            SelectedMode = enmSelectMode.TripMode
            SelectModeSet()
        End If

        btnSetOverLayMode.Enabled = True
        btnSetSeries.Enabled = True
        Select Case attrData.LayerData(LayerNum).Type
            Case clsAttrData.enmLayerType.Normal, clsAttrData.enmLayerType.Mesh, clsAttrData.enmLayerType.DefPoint
                If attrData.LayerData(LayerNum).getFirstNormalDataItem = -1 Then
                    SetPicPnlDataEnabled(enmSelectMode.GraphMode, False)
                Else
                    SetPicPnlDataEnabled(enmSelectMode.GraphMode, True)
                End If
                SetPicPnlDataEnabled(enmSelectMode.LabelMode, True)
                SetPicPnlDataEnabled(enmSelectMode.TripMode, False)
            Case clsAttrData.enmLayerType.Trip
                SetPicPnlDataEnabled(enmSelectMode.GraphMode, False)
                SetPicPnlDataEnabled(enmSelectMode.LabelMode, False)
                SetPicPnlDataEnabled(enmSelectMode.TripMode, True)
            Case clsAttrData.enmLayerType.Trip_Definition
                SetPicPnlDataEnabled(enmSelectMode.GraphMode, False)
                SetPicPnlDataEnabled(enmSelectMode.LabelMode, False)
                SetPicPnlDataEnabled(enmSelectMode.TripMode, False)
                btnSetOverLayMode.Enabled = False
                btnSetSeries.Enabled = False
        End Select
    End Sub
    ''' <summary>
    ''' データ項目ボックスの選択変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboDataItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDataItem.SelectedIndexChanged
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim DataNum As Integer = cboDataItem.SelectedIndex
        attrData.LayerData(LayerNum).atrData.SelectedIndex = DataNum
        SelectedModeClear()

        Dim val As enmSoloMode_Number
        For Each val In [Enum].GetValues(GetType(enmSoloMode_Number))
            If val <> enmSoloMode_Number.noMode Then
                SetPicPnlSoloDataEnabled(val, LayerNum, DataNum)
            End If
        Next
        Select Case attrData.TotalData.LV1.Print_Mode_Total
            Case enmTotalMode_Number.DataViewMode
                Select Case attrData.LayerData(LayerNum).Print_Mode_Layer
                    Case enmLayerMode_Number.SoloMode
                        Dim MD As enmSoloMode_Number = attrData.LayerData(LayerNum).atrData.Data(DataNum).ModeData
                        SelectedMode = GetSelectModeFromSoloMode(MD)

                    Case enmLayerMode_Number.GraphMode
                        SelectedMode = enmSelectMode.GraphMode
                    Case enmLayerMode_Number.LabelMode
                        SelectedMode = enmSelectMode.LabelMode
                    Case enmLayerMode_Number.TripMode
                        SelectedMode = enmSelectMode.TripMode
                End Select
            Case enmTotalMode_Number.OverLayMode
                SelectedMode = enmSelectMode.OverLayMode
            Case enmTotalMode_Number.SeriesMode
                SelectedMode = enmSelectMode.SeriesMode
        End Select
        SelectModeSet()
        oldSelectedMode = New List(Of OldSelectedMode_info)
        Select Case SelectedMode
            Case enmSelectMode.OverLayMode, enmSelectMode.SeriesMode
                picLayerModeOverPanel.Visible = False
                Dim os As OldSelectedMode_info
                os.oldSelMode = GetSelectModeFromSoloMode(attrData.LayerData(LayerNum).atrData.Data(DataNum).ModeData)
                os.oldTotoalMode = enmTotalMode_Number.DataViewMode
                oldSelectedMode.Add(os)
                picTotalModeOverPanel_Visible()
            Case enmSelectMode.LabelMode, enmSelectMode.GraphMode, enmSelectMode.TripMode
                picTotalModeOverPanel.Visible = False
                Dim os As OldSelectedMode_info
                os.oldSelMode = GetSelectModeFromSoloMode(attrData.LayerData(LayerNum).atrData.Data(DataNum).ModeData)
                os.oldTotoalMode = enmTotalMode_Number.DataViewMode
                oldSelectedMode.Add(os)
                picLayerModeOverPanel_Visible()
            Case Else
                picLayerModeOverPanel.Visible = False
                picTotalModeOverPanel.Visible = False
        End Select
    End Sub
    ''' <summary>
    ''' データ項目が変更された際に、単独表示モードの可否を調べ、コントロールを設定
    ''' </summary>
    ''' <param name="solomode"></param>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Sub SetPicPnlSoloDataEnabled(ByVal solomode As enmSoloMode_Number, ByVal LayerNum As Integer, ByVal DataNum As Integer)
        Dim f As Boolean = attrData.Check_Enable_SoloMode(solomode, LayerNum, DataNum)

        SetPicPnlDataEnabled(GetSelectModeFromSoloMode(solomode), f)
    End Sub
    ''' 
    ''' 表示モードセレクタのEnabel設定
    ''' 
    ''' 
    ''' 
    ''' 
    Private Sub SetPicPnlDataEnabled(ByVal Mode As enmSelectMode, ByVal Flag As Boolean)
        Dim name As String = GetModeControlName(Mode)
        Dim lbls As Control()
        lbls = Me.Controls.Find("lbl" + name, True)
        Dim lbl As Label = CType(lbls(0), Label)

        Dim pnls As Control()
        pnls = Me.Controls.Find("pnl" + name, True)
        Dim pnl As Panel = CType(pnls(0), Panel)

        Dim pics As Control()
        pics = Me.Controls.Find("pic" + name, True)
        Dim pic As PictureBox = CType(pics(0), PictureBox)

        lbl.Enabled = Flag
        pnl.Enabled = Flag

        Dim canvas As New Bitmap(pic.Width, pic.Height)
        Dim g As Graphics = Graphics.FromImage(canvas)
        Dim col As Color
        If Flag = True Then
            col = Color.FromArgb(0, 255, 255, 255)
        Else
            col = Color.FromArgb(200, 255, 255, 255)
        End If
        g.FillRectangle(New SolidBrush(col), New Rectangle(0, 0, pic.Width, pic.Height))
        pic.Image = canvas
        pic.Refresh()

    End Sub



    ''' <summary>
    ''' コントロール名から表示モード列挙型を取得
    ''' </summary>
    ''' <param name="CName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetModeENUMfromControlName(ByVal CName As String) As enmSelectMode
        Select Case CName
            Case "ClassPaint"
                Return enmSelectMode.ClassPaintMode
            Case "ClassHatch"
                Return enmSelectMode.ClassHatchMode
            Case "ClassMark"
                Return enmSelectMode.ClassMarkMode
            Case "ClassOD"
                Return enmSelectMode.ClassODMode
            Case "MarkSize"
                Return enmSelectMode.MarkSizeMode
            Case "MarkBlock"
                Return enmSelectMode.MarkBlockMode
            Case "MarkTurn"
                Return enmSelectMode.MarkTurnMode
            Case "Contour"
                Return enmSelectMode.ContourMode
            Case "MarkBar"
                Return enmSelectMode.MarkBarMode
            Case "String"
                Return enmSelectMode.StringMode

            Case "Graph"
                Return enmSelectMode.GraphMode
            Case "Label"
                Return enmSelectMode.LabelMode
            Case "Trip"
                Return enmSelectMode.TripMode

            Case "Overlay"
                Return enmSelectMode.OverLayMode
            Case "Series"
                Return enmSelectMode.SeriesMode
            Case Else
                ' デフォルトの処理は "ClassPaint" ということにする。 
                Return enmSelectMode.ClassPaintMode
        End Select
    End Function
    ''' 
    ''' 表示モード列挙型からコントロール名を取得
    ''' 
    ''' 
    ''' 
    ''' 
    Private Function GetModeControlName(ByVal sm As enmSelectMode) As String
        Select Case sm
            Case enmSelectMode.ClassPaintMode
                Return "ClassPaint"
            Case enmSelectMode.ClassHatchMode
                Return "ClassHatch"
            Case enmSelectMode.ClassMarkMode
                Return "ClassMark"
            Case enmSelectMode.ClassODMode
                Return "ClassOD"
            Case enmSelectMode.MarkSizeMode
                Return "MarkSize"
            Case enmSelectMode.MarkBlockMode
                Return "MarkBlock"
            Case enmSelectMode.MarkTurnMode
                Return "MarkTurn"
            Case enmSelectMode.MarkBarMode
                Return "MarkBar"
            Case enmSelectMode.ContourMode
                Return "Contour"
            Case enmSelectMode.StringMode
                Return "String"

            Case enmSelectMode.GraphMode
                Return "Graph"
            Case enmSelectMode.LabelMode
                Return "Label"
            Case enmSelectMode.TripMode
                Return "Trip"

            Case enmSelectMode.OverLayMode
                Return "Overlay"
            Case enmSelectMode.SeriesMode
                Return "Series"
            Case Else
                ' デフォルトの処理は "ClassPaint" ということにする。 
                Return "ClassPaint"
        End Select
    End Function
    ''' <summary>
    ''' 選択モードから単独表示モードを取得
    ''' </summary>
    ''' <param name="SelMode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSoloModeFromSelectMode(ByVal SelMode As enmSelectMode) As enmSoloMode_Number
        Select Case SelMode
            Case enmSelectMode.ClassPaintMode
                Return enmSoloMode_Number.ClassPaintMode
            Case enmSelectMode.ClassHatchMode
                Return enmSoloMode_Number.ClassHatchMode
            Case enmSelectMode.ClassMarkMode
                Return enmSoloMode_Number.ClassMarkMode
            Case enmSelectMode.ClassODMode
                Return enmSoloMode_Number.ClassODMode
            Case enmSelectMode.MarkSizeMode
                Return enmSoloMode_Number.MarkSizeMode
            Case enmSelectMode.MarkBlockMode
                Return enmSoloMode_Number.MarkBlockMode
            Case enmSelectMode.MarkTurnMode
                Return enmSoloMode_Number.MarkTurnMode
            Case enmSelectMode.ContourMode
                Return enmSoloMode_Number.ContourMode
            Case enmSelectMode.MarkBarMode
                Return enmSoloMode_Number.MarkBarMode
            Case enmSelectMode.StringMode
                Return enmSoloMode_Number.StringMode
            Case Else
                Return -1
        End Select
    End Function

    ''' 
    ''' 単独表示モードから選択モードを取得noModeの場合はラベルモードを返す
    ''' 
    ''' 
    ''' 
    ''' 
    Private Function GetSelectModeFromSoloMode(ByVal SoloMode As enmSoloMode_Number) As enmSelectMode
        Select Case SoloMode
            Case enmSoloMode_Number.ClassPaintMode
                Return enmSelectMode.ClassPaintMode
            Case enmSoloMode_Number.ClassHatchMode
                Return enmSelectMode.ClassHatchMode
            Case enmSoloMode_Number.ClassMarkMode
                Return enmSelectMode.ClassMarkMode
            Case enmSoloMode_Number.ClassODMode
                Return enmSelectMode.ClassODMode
            Case enmSoloMode_Number.MarkSizeMode
                Return enmSelectMode.MarkSizeMode
            Case enmSoloMode_Number.MarkBlockMode
                Return enmSelectMode.MarkBlockMode
            Case enmSoloMode_Number.MarkTurnMode
                Return enmSelectMode.MarkTurnMode
            Case enmSoloMode_Number.ContourMode
                Return enmSelectMode.ContourMode
            Case enmSoloMode_Number.MarkBarMode
                Return enmSelectMode.MarkBarMode
            Case enmSoloMode_Number.StringMode
                Return enmSelectMode.StringMode

            Case enmSoloMode_Number.noMode
                '文字列データの場合
                Return enmSelectMode.noMode

            Case Else
                ' デフォルトの処理は "ClassPaint" ということにする。 
                Return enmSelectMode.ClassPaintMode
        End Select
    End Function
    ''' <summary>
    ''' 画面の初期設定
    ''' </summary>
    ''' <param name="Non_Clear_Flag">出力画面の位置サイズを新しく設定する場合はfalse</param>
    ''' <remarks></remarks>
    Private Sub Init_Screen_Set(ByVal Non_Clear_Flag As Boolean)

        If Non_Clear_Flag = False Then
            Call Init_FrmPrint()
            Call set_frmPrint_Window_Size()
            With attrData.TotalData.ViewStyle.ScrData
                .init(Frm_Print.picMap, .Screen_Margin, .MapRectangle, .Accessory_Base, True)
            End With
            attrData.Set_Acc_First_Position()
        Else
            Call set_frmPrint_Window_Size()
            With attrData.TotalData.ViewStyle.ScrData
                .init(Frm_Print.picMap, .Screen_Margin, .MapRectangle, .Accessory_Base, False)
            End With
        End If
    End Sub

    Private Sub set_frmPrint_Window_Size()

        With Frm_Print
            If .WindowState <> FormWindowState.Minimized Then
                Dim FpicRect As Rectangle = attrData.TotalData.ViewStyle.ScrData.frmPrint_FormSize
                .ClientSize = New Size(FpicRect.Width, FpicRect.Height + .StatusStrip.Height + .MenuStrip.Height)
                .Left = FpicRect.Left
                .Top = FpicRect.Top
            End If
            attrData.TotalData.ViewStyle.ScrData.Set_PictureBox_and_CulculateMul(Frm_Print.picMap)
            If attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F = True Then
                'Call SetWorldXY_3DpicSize()
                'Call Change3D()
                'Call frmSet3D.prt3DSample()
            End If
        End With
    End Sub
    Private Sub Init_FrmPrint()

        'ディスプレイの高さ
        Dim ScreenH As Integer = System.Windows.Forms.Screen.GetBounds(Me).Height
        'ディスプレイの幅
        Dim ScreenW As Integer = System.Windows.Forms.Screen.GetBounds(Me).Width
        Dim capH As Integer = SystemInformation.CaptionHeight
        Dim BH As Single
        Dim BW As Single
        With Frm_Print
            .Visible = False
            BH = .Height - .ClientSize.Height + .MenuStrip.Height + .StatusLabel.Height
            BW = .Width - .ClientSize.Width
        End With

        'デフォルトは横長画面
        Dim a As Single = ScreenH * 0.7
        Dim psh As Single = a
        Dim psw As Single = a * 1.41

        With attrData.TotalData.ViewStyle.ScrData.frmPrint_FormSize
            .Height = psh
            .Width = psw
            .X = ScreenW / 2 - (psw + BW) / 2
            .Y = ScreenH / 2 - (psh + BH) / 2
        End With
    End Sub


    Private Sub btnDraw_Click(sender As Object, e As EventArgs) Handles btnDraw.Click

        Dim mes As String = ""
        If attrData.Get_PrintError(mes) = clsAttrData.enmPrint_Enable.UnPrintable Then
            clsGeneric.Message(Me, "エラー", mes, True, True)
            Return
        End If
        If Frm_Print.IsDisposed = True Then
            Try
                Frm_Print = New frmPrint
                Frm_Print.Pre_load()
                Init_Screen_Set(True)
            Catch ex As Exception
                MsgBox("frmMain_btnDraw" + vbCrLf + ex.Message, MsgBoxStyle.Exclamation)
                Return
            End Try
        End If
        Frm_Print.SetData(Me, attrData)
    End Sub

    ''' <summary>
    ''' 最近使ったファイルのメニュー項目の作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMDRFileHistorytoMenu()
        mnuRecentUsedFile.DropDownItems.Clear()
        Dim FileHistory() As String = clsSettings.Data.MDRFileHistory.Split("|")
        If FileHistory.GetLength(0) < 10 Then
            ReDim Preserve FileHistory(9)
            clsSettings.Data.MDRFileHistory = String.Join("|", FileHistory)
        End If
        For i As Integer = 0 To FileHistory.GetUpperBound(0)
            Dim menuRecentFile As New ToolStripMenuItem
            If FileHistory(i) <> "" Then
                menuRecentFile.Text = FileHistory(i) + "(&" + Convert.ToString(i + 1, 16) + ")"
                menuRecentFile.Tag = FileHistory(i)
            Else
                menuRecentFile.Text = ""
                menuRecentFile.Tag = ""
            End If
            AddHandler menuRecentFile.Click, AddressOf recentUsedFileOpen
            '「新規作成」を「ファイル」へ追加
            mnuRecentUsedFile.DropDownItems.Add(menuRecentFile)
        Next
    End Sub
    ''' <summary>
    ''' 最近使ったファイルのオーダー変更
    ''' </summary>
    ''' <param name="NewTopPath">トップに来るファイルパス</param>
    ''' <remarks></remarks>
    Private Sub replaceMDRFileHistory(ByVal NewTopPath As String)
        Dim FileHistory() As String = clsSettings.Data.MDRFileHistory.Split("|")
        Dim lastp As Integer = FileHistory.GetUpperBound(0)
        For i As Integer = 0 To FileHistory.GetUpperBound(0)
            If FileHistory(i) = NewTopPath Then
                lastp = i
                Exit For
            End If
        Next

        For i As Integer = lastp - 1 To 0 Step -1
            FileHistory(i + 1) = FileHistory(i)
        Next
        FileHistory(0) = NewTopPath
        clsSettings.Data.MDRFileHistory = String.Join("|", FileHistory)
        SetMDRFileHistorytoMenu()

    End Sub


    Private Sub recentUsedFileOpen(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If System.IO.File.Exists(sender.tag) = False Then
            MsgBox(sender.tag + "が見つかりません。", MsgBoxStyle.Exclamation)
        Else
            Cursor.Current = Cursors.WaitCursor
            For i As Integer = Application.OpenForms.Count - 1 To 0 Step -1
                Dim frm As Form = Application.OpenForms(i)
                If TypeOf frm Is frmPrint_Instance Then
                    frm.Close()
                End If
            Next
            OpenNewMandaraFile(False, sender.tag)
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub mnuOption_Click(sender As Object, e As EventArgs) Handles mnuOption.Click
        Dim form As New frmOption
        If form.ShowDialog(Me, attrData.TotalData.ViewStyle.ScrData, clsBase.PictureNoUse) = Windows.Forms.DialogResult.OK Then
        End If
        form.Dispose()
    End Sub



    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        Dim MFile As String = attrData.TotalData.LV1.FullPath
        Dim firstExt As String = System.IO.Path.GetExtension(MFile)
        If man_Data = enmDataSource.MDRZ Or man_Data = enmDataSource.MDRMZ Then
            Cursor.Current = Cursors.WaitCursor
            Dim f As Boolean = attrData.SaveMDRZFile(MFile, ProgressBar)
            Cursor.Current = Cursors.Default
            If f = True Then
                MsgBox(attrData.TotalData.LV1.FileName + "を保存しました。")
            Else
                MsgBox(attrData.TotalData.LV1.FileName + "は保存できませんでした。", MsgBoxStyle.Exclamation)
            End If
        Else
            DataSaveAs()
        End If

    End Sub
    Private Sub mnuSaveAs_Click(sender As Object, e As EventArgs) Handles mnuSaveAs.Click
        DataSaveAs()
    End Sub
    Private Sub DataSaveAs()
        Dim sfd As New SaveFileDialog()
        sfd.InitialDirectory = clsSettings.Data.Directory.DataFile
        Dim MFile As String = attrData.TotalData.LV1.FullPath
        Dim firstExt As String = System.IO.Path.GetExtension(MFile)
        Select Case man_Data
            Case enmDataSource.MDRZ, enmDataSource.MDRMZ
            Case enmDataSource.MDRM, enmDataSource.Shapefile
                MFile = System.IO.Path.GetFileNameWithoutExtension(MFile) + ".mdrmz"
            Case Else
                MFile = System.IO.Path.GetFileNameWithoutExtension(MFile) + ".mdrz"
        End Select

        sfd.FileName = MFile
        sfd.DefaultExt = System.IO.Path.GetExtension(MFile)
        Select Case sfd.DefaultExt
            Case "mdrz"
                sfd.Filter = "MANDARA属性データファイル(*.mdrz)|*.mdrz|地図ファイル付属形式ファイル(*.mdrmz)|*.mdrmz"
                sfd.FilterIndex = 1
            Case "mdrmz"
                sfd.Filter = "地図ファイル付属形式ファイル(*.mdrmz)|*.mdrmz"
                sfd.FilterIndex = 1
        End Select
        If sfd.ShowDialog() = DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            Dim f As Boolean = attrData.SaveMDRZFile(sfd.FileName, ProgressBar)
            Cursor.Current = Cursors.Default
            If f = True Then
                clsSettings.Data.Directory.DataFile = System.IO.Path.GetDirectoryName(sfd.FileName)
                attrData.TotalData.LV1.FullPath = sfd.FileName
                attrData.TotalData.LV1.FileName = System.IO.Path.GetFileName(sfd.FileName)
                Select Case LCase(System.IO.Path.GetExtension(sfd.FileName))
                    Case ".mdrz"
                        attrData.TotalData.LV1.DataSourceType = enmDataSource.MDRZ
                    Case ".mdrmz"
                        attrData.TotalData.LV1.DataSourceType = enmDataSource.MDRMZ
                End Select
                man_Data = attrData.TotalData.LV1.DataSourceType
                replaceMDRFileHistory(attrData.TotalData.LV1.FullPath)
                Me.Text = attrData.TotalData.LV1.FileName
                MsgBox(attrData.TotalData.LV1.FileName + "を保存しました。")
            Else
                MsgBox(sfd.FileName + "は保存できませんでした。", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub


    Private Sub btnDrawCaution_Click(sender As Object, e As EventArgs) Handles btnDrawCaution.Click
        Dim mes As String = ""
        If attrData.Get_PrintError(mes) <> clsAttrData.enmPrint_Enable.Printable Then
            clsGeneric.Message(Me, "エラー", mes, True, True)
        Else
            Check_Print_err()
        End If
    End Sub

    Public Sub Check_Print_err()

        Dim emes As String = ""
        Dim c As clsAttrData.enmPrint_Enable = attrData.Get_PrintError(emes)

        With btnDrawCaution
            If c = clsAttrData.enmPrint_Enable.Printable Then
                .Visible = False
            Else
                .Visible = True
                If c = clsAttrData.enmPrint_Enable.Printable_with_Error Then
                    .BackColor = Color.Yellow
                    ToolTip1.SetToolTip(btnDrawCaution, "注意事項あり")
                Else
                    .BackColor = Color.Red
                    ToolTip1.SetToolTip(btnDrawCaution, "設定エラーあり")
                End If
            End If
        End With

        '属性検索設定の有無
        With attrData
            Dim f As Boolean = False
            Select Case .TotalData.LV1.Print_Mode_Total
                Case enmTotalMode_Number.DataViewMode
                    f = .Check_Condition_UMU(attrData.TotalData.LV1.SelectedLayer)
                Case enmTotalMode_Number.OverLayMode
                    Dim n As Integer = .TotalData.TotalMode.OverLay.SelectedIndex
                    For i As Integer = 0 To .TotalData.TotalMode.OverLay.DataSet(n).DataItem.Count - 1
                        f = .Check_Condition_UMU(.TotalData.TotalMode.OverLay.DataSet(n).DataItem(i).Layer)
                        If f = True Then
                            Exit For
                        End If
                    Next
                Case enmTotalMode_Number.SeriesMode
                    Dim n As Integer = .TotalData.TotalMode.Series.SelectedIndex
                    For i As Integer = 0 To .TotalData.TotalMode.Series.DataSet(n).DataItem.Count - 1
                        With .TotalData.TotalMode.Series.DataSet(n).DataItem(i)
                            Select Case .Print_Mode_Total
                                Case enmTotalMode_Number.DataViewMode
                                    f = attrData.Check_Condition_UMU(.Layer)
                                    If f = True Then
                                        Exit For
                                    End If
                                Case enmTotalMode_Number.OverLayMode
                                    For j As Integer = 0 To attrData.TotalData.TotalMode.OverLay.DataSet(.Data).DataItem.Count - 1
                                        f = attrData.Check_Condition_UMU(attrData.TotalData.TotalMode.OverLay.DataSet(.Data).DataItem(j).Layer)
                                        If f = True Then
                                            Exit For
                                        End If
                                    Next
                            End Select
                        End With
                    Next
            End Select
            btnConditionInfo.Visible = f
        End With
    End Sub


    Private Sub btnSetOverLayMode_Click(sender As Object, e As EventArgs) Handles btnSetOverLayMode.Click

        Dim mes As String = ""
        If attrData.Get_PrintError(mes) = clsAttrData.enmPrint_Enable.UnPrintable Then
            MsgBox(mes, MsgBoxStyle.Exclamation, "エラー")
            Return
        End If

        Dim OverLayDataSetNum As Integer = attrData.TotalData.TotalMode.OverLay.SelectedIndex
        Dim ovdn As Integer = attrData.TotalData.TotalMode.OverLay.DataSet.Count
        Dim ovttl(ovdn - 1) As String
        For i As Integer = 0 To ovdn - 1
            ovttl(i) = attrData.TotalData.TotalMode.OverLay.DataSet(i).title
            If ovttl(i) = "" Then
                ovttl(i) = "重ね合わせデータセット" + (i + 1).ToString
            End If
        Next
        If ovdn > 1 Then
            Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("重ね合わせデータセット選択", ovttl)
            If sel = -1 Then
                Return
            End If
            OverLayDataSetNum = sel
        End If
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim DataNum As Integer = attrData.LayerData(Layernum).atrData.SelectedIndex
        Dim MDLayer As enmLayerMode_Number = attrData.LayerData(Layernum).Print_Mode_Layer

        Dim SoloMd As enmSoloMode_Number
        Dim MultiDataSetIndex As Integer
        Select Case MDLayer
            Case enmLayerMode_Number.SoloMode
                SoloMd = attrData.LayerData(Layernum).atrData.Data(DataNum).ModeData
            Case enmLayerMode_Number.GraphMode
                MultiDataSetIndex = attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode.SelectedIndex
            Case enmLayerMode_Number.LabelMode
                MultiDataSetIndex = attrData.LayerData(Layernum).LayerModeViewSettings.LabelMode.SelectedIndex
            Case enmLayerMode_Number.TripMode
                MultiDataSetIndex = attrData.LayerData(Layernum).LayerModeViewSettings.TripMode.SelectedIndex
        End Select
        Dim Index As Integer = -1
        Dim DataSet As clsAttrData.strOverLay_Dataset_Info = attrData.TotalData.TotalMode.OverLay.DataSet(OverLayDataSetNum)
        With DataSet
            Dim Num As Integer = .DataItem.Count

            Index = Num
            For i As Integer = 0 To Num - 1
                With .DataItem(i)
                    Select Case MDLayer
                        Case enmLayerMode_Number.SoloMode
                            If .Print_Mode_Layer = enmLayerMode_Number.SoloMode Then
                                i = Num
                            End If
                        Case enmLayerMode_Number.GraphMode
                            If .Layer = Layernum And .Print_Mode_Layer = enmLayerMode_Number.GraphMode Then
                                Dim PresentGraphMode As enmGraphMode = attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode.DataSet(MultiDataSetIndex).GraphMode
                                Dim StackedGraphMode As enmGraphMode = attrData.LayerData(.Layer).LayerModeViewSettings.GraphMode.DataSet(.DataNumber).GraphMode
                                If .DataNumber = MultiDataSetIndex Then
                                    Index = -2
                                    i = Num
                                ElseIf (StackedGraphMode = enmGraphMode.BarGraph And PresentGraphMode = enmGraphMode.LineGraph) Or
                                        (StackedGraphMode = enmGraphMode.LineGraph And PresentGraphMode = enmGraphMode.BarGraph) Then
                                Else
                                    If MsgBox("同一レイヤのグラフモードで重ね合わせ可能な組み合わせは、" & vbCrLf & "折れ線グラフと棒グラフのみです。置換します。", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                        Index = -1
                                        i = Num
                                    Else
                                        Index = i
                                        i = Num
                                    End If
                                End If
                            End If
                        Case enmLayerMode_Number.LabelMode
                            If .Layer = Layernum And .DataNumber = MultiDataSetIndex And .Print_Mode_Layer = enmLayerMode_Number.LabelMode Then
                                Index = -2
                                i = Num
                            End If
                        Case enmLayerMode_Number.TripMode
                            If .Layer = Layernum And .DataNumber = MultiDataSetIndex And .Print_Mode_Layer = enmLayerMode_Number.TripMode Then
                                Index = -2
                                i = Num
                            End If
                    End Select
                End With
            Next

            If Index = -2 Then
                MsgBox("このデータセットはすでに重ね合わせモードに設定してあります。", MsgBoxStyle.Exclamation)
            ElseIf Index = -1 Then
            Else

                Dim d As New clsAttrData.strOverLay_DataSet_Item_Info
                With d
                    .TileMapf = False
                    .Layer = Layernum
                    .Print_Mode_Layer = MDLayer
                    Dim lpf As Boolean = False
                    Select Case MDLayer
                        Case enmLayerMode_Number.SoloMode
                            .DataNumber = DataNum
                            .Mode = SoloMd
                            lpf = True
                            Select Case .Mode
                                Case enmSoloMode_Number.ContourMode
                                    With attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD
                                        If .Interval_Mode = clsAttrData.enmContourIntervalMode.RegularInterval Or
                                            .Interval_Mode = clsAttrData.enmContourIntervalMode.SeparateSettings Then
                                            lpf = False
                                        End If
                                    End With
                                Case enmSoloMode_Number.MarkTurnMode
                                    '記号の回転モードは、内部データがある場合のみ凡例を表示
                                    If attrData.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.MarkCommon.Inner_Data.Flag = False Then
                                        lpf = False
                                    End If
                            End Select
                        Case enmLayerMode_Number.GraphMode
                            .DataNumber = MultiDataSetIndex
                            lpf = True
                        Case enmLayerMode_Number.LabelMode
                            .DataNumber = MultiDataSetIndex
                            lpf = False
                        Case enmLayerMode_Number.TripMode
                            .DataNumber = MultiDataSetIndex
                            lpf = False
                    End Select
                    .Legend_Print_Flag = lpf
                End With
                If Index = Num Then
                    .DataItem.Add(d)
                Else
                    .DataItem(Index) = d
                End If
                attrData.TotalData.TotalMode.OverLay.DataSet(OverLayDataSetNum) = DataSet
                attrData.Sort_OverLay_Data(OverLayDataSetNum)
                clsGeneric.MessageBox(FormStartPosition.Manual, "「" & ovttl(OverLayDataSetNum) & "」にセットしました。", MessageBoxButtons.OK, MessageBoxIcon.None)
                If OverLayDataSetNum <> attrData.TotalData.TotalMode.OverLay.SelectedIndex Then
                    attrData.TotalData.TotalMode.OverLay.SelectedIndex = OverLayDataSetNum
                End If
            End If
        End With
    End Sub
    ''' <summary>
    ''' 複合表示をクリックした際に、上の選択画面を隠す
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub picTotalModeOverPanel_Visible()
        With pnlData
            Dim bmp As New Bitmap(.Width, .Height)
            .DrawToBitmap(bmp, New Rectangle(0, 0, .Width, .Height))
            Dim g As Graphics = Graphics.FromImage(bmp)
            g.FillRectangle(New SolidBrush(Color.FromArgb(150, 255, 255, 255)), New Rectangle(0, 0, .Width, .Height))
            With picTotalModeOverPanel
                .Width = pnlData.Width
                .Height = pnlData.Height
                .Top = pnlData.Top
                .Left = pnlData.Left
                .Image = bmp
                .Visible = True
            End With
        End With
    End Sub
    Private Sub picTotalModeOverPanel_Click(sender As Object, e As EventArgs) Handles picTotalModeOverPanel.Click
        picTotalModeOverPanel.Visible = False
        SelectedModeClear()
        Dim n As Integer = oldSelectedMode.Count - 1
        SelectedMode = oldSelectedMode(n).oldSelMode
        attrData.TotalData.LV1.Print_Mode_Total = oldSelectedMode(n).oldTotoalMode
        oldSelectedMode.RemoveAt(n)
        SelectModeSet()
        Select Case SelectedMode
            Case enmSelectMode.LabelMode, enmSelectMode.GraphMode, enmSelectMode.TripMode
                picLayerModeOverPanel_Visible()
        End Select
    End Sub
    ''' <summary>
    ''' 複数表示をクリックした際に、上の選択画面を隠す
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub picLayerModeOverPanel_Visible()
        With pnlSolo
            Dim bmp As New Bitmap(.Width, .Height)
            .DrawToBitmap(bmp, New Rectangle(0, 0, .Width, .Height))
            Dim g As Graphics = Graphics.FromImage(bmp)
            g.FillRectangle(New SolidBrush(Color.FromArgb(150, 255, 255, 255)), New Rectangle(0, 0, .Width, .Height))
            With picLayerModeOverPanel
                .Width = pnlSolo.Width
                .Height = pnlSolo.Height
                .Top = pnlSolo.Top
                .Left = pnlSolo.Left
                .Image = bmp
                .Visible = True
            End With
        End With
    End Sub

    Private Sub picLayerModeOverPanel_Click(sender As Object, e As EventArgs) Handles picLayerModeOverPanel.Click
        picLayerModeOverPanel.Visible = False
        SelectedModeClear()
        Dim n As Integer = oldSelectedMode.Count - 1
        If n <> -1 Then
            SelectedMode = oldSelectedMode(n).oldSelMode
            attrData.TotalData.LV1.Print_Mode_Total = oldSelectedMode(n).oldTotoalMode
            If oldSelectedMode(n).oldTotoalMode = enmTotalMode_Number.DataViewMode Then
                attrData.LayerData(attrData.TotalData.LV1.SelectedLayer).Print_Mode_Layer = oldSelectedMode(n).oldLayerMode
            End If
            oldSelectedMode.RemoveAt(n)
        Else
            SelectedMode = enmSelectMode.ClassPaintMode
        End If
        SelectModeSet()
        If attrData.LayerData(attrData.TotalData.LV1.SelectedLayer).Type = clsAttrData.enmLayerType.Trip Then
            Frm_Print.Visible = False
        End If
    End Sub

    Private Sub btnSetSeries_Click(sender As Object, e As EventArgs) Handles btnSetSeries.Click


        Dim mes As String = ""
        If attrData.Get_PrintError(mes) = clsAttrData.enmPrint_Enable.UnPrintable Then
            MsgBox(mes, MsgBoxStyle.Exclamation, "エラー")
            Return
        End If

        Dim DataSetNum As Integer = attrData.TotalData.TotalMode.Series.SelectedIndex
        Dim sedn As Integer = attrData.TotalData.TotalMode.Series.DataSet.Count
        Dim ttl(sedn - 1) As String
        For i As Integer = 0 To sedn - 1
            ttl(i) = attrData.TotalData.TotalMode.Series.DataSet(i).title
            If ttl(i) = "" Then
                ttl(i) = "連続表示データセット" + (i + 1).ToString
            End If
        Next
        If sedn > 1 Then
            Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("連続表示データセット選択", ttl)
            If sel = -1 Then
                Return
            End If
            DataSetNum = sel
        End If

        With attrData.TotalData.TotalMode.Series.DataSet(DataSetNum)
            Dim Num As Integer = .DataItem.Count
            Dim Layernum As Integer
            Dim DataNum As Integer
            Dim ModeData As enmSoloMode_Number
            Dim Print_Mode_Layer As enmLayerMode_Number
            Dim Print_Mode_Total As enmTotalMode_Number = attrData.TotalData.LV1.Print_Mode_Total
            Select Case Print_Mode_Total
                Case enmTotalMode_Number.DataViewMode
                    Layernum = attrData.TotalData.LV1.SelectedLayer
                    Print_Mode_Layer = attrData.LayerData(Layernum).Print_Mode_Layer
                    Select Case Print_Mode_Layer
                        Case enmLayerMode_Number.SoloMode
                            DataNum = attrData.LayerData(Layernum).atrData.SelectedIndex
                            ModeData = attrData.LayerData(Layernum).atrData.Data(DataNum).ModeData
                        Case enmLayerMode_Number.GraphMode
                            DataNum = attrData.LayerData(Layernum).LayerModeViewSettings.GraphMode.SelectedIndex
                        Case enmLayerMode_Number.LabelMode
                            DataNum = attrData.LayerData(Layernum).LayerModeViewSettings.LabelMode.SelectedIndex
                        Case enmLayerMode_Number.TripMode
                            DataNum = attrData.LayerData(Layernum).LayerModeViewSettings.TripMode.SelectedIndex
                    End Select
                Case enmTotalMode_Number.OverLayMode
                    DataNum = attrData.TotalData.TotalMode.OverLay.SelectedIndex
            End Select
            .AddData(Layernum, DataNum, Print_Mode_Total, Print_Mode_Layer, ModeData)
            clsGeneric.MessageBox(FormStartPosition.Manual, "「" & ttl(DataSetNum) & "」にセットしました。", MessageBoxButtons.OK, MessageBoxIcon.None)
            If DataSetNum <> attrData.TotalData.TotalMode.Series.SelectedIndex Then
                attrData.TotalData.TotalMode.Series.SelectedIndex = DataSetNum
            End If

        End With

    End Sub



    Private Sub mnuViewer_Click(sender As Object, e As EventArgs) Handles mnuViewer.Click
        If Check_EraseSettei_OK(True) = True Then
            Show_Viewer("")
        End If
    End Sub
    ''' <summary>
    ''' 白地図・初期属性データ表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Show_Viewer(ByVal MapFilePath As String)
        attrData = New clsAttrData(TileMap)
        Dim form As New frmMain_ShowViewer
        If form.ShowDialog(MapFilePath, TileMap) = Windows.Forms.DialogResult.OK Then
            attrData = form.GetResult
            man_Data = attrData.TotalData.LV1.DataSourceType
            Init_Screen_Set(False)
            initFirtScreen()
            menu_Setting()
            Me.Text = attrData.TotalData.LV1.FileName
        End If
        form.Dispose()

    End Sub
    ''' <summary>
    ''' 現在の属性データは消去されますメッセージ
    ''' </summary>
    ''' <param name="Settei_Visible">はいの場合、設定画面を表示/非表示</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_EraseSettei_OK(ByVal Settei_Visible As Boolean) As Boolean
        If man_Data <> enmDataSource.NoData Then

            If MsgBox("現在の属性データは消去されます。" & vbCrLf & "よろしいですか？", vbYesNo) = MsgBoxResult.Yes Then
                man_Data = enmDataSource.NoData
                menu_Setting()
                Me.Text = "MANDARA"
                Frm_Print.Visible = False
                Me.Visible = Settei_Visible
                Frm_MarkView.Visible = False
                Frm_ContourView.Visible = False
                Frm_Graph.Visible = False
                Frm_Label.Visible = False
                Frm_Trip.Visible = False
                Frm_Series.Visible = False
                Frm_Overlay.Visible = False
                Frm_ClassView.Visible = False

                For i As Integer = Application.OpenForms.Count - 1 To 0 Step -1
                    Dim frm As Form = Application.OpenForms(i)
                    If TypeOf frm Is frmPrint_Instance Then
                        frm.Close()
                    End If
                Next
                Return True
            Else
                Return False
            End If
        Else
            Frm_Print.Visible = False
            Me.Visible = Settei_Visible
            Return True
        End If

    End Function
    ''' <summary>
    ''' メニュー選択の可否
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub menu_Setting()
        Dim fv1 As Boolean

        Select Case man_Data
            Case enmDataSource.NoData
                fv1 = False
                ProgressLabel.Parent = Me
                ProgressLabel.Location = pnlSettings.Location
                ProgressBar.Parent = Me
                ProgressBar.Location = pnlSettings.Location

            Case Else
                fv1 = True
                ProgressLabel.Parent = pnlSettings
                ProgressLabel.Location = New Point(0, 0)
                ProgressBar.Parent = pnlSettings
                ProgressBar.Location = New Point(0, 0)

        End Select
        mnuAnalysis.Enabled = fv1
        mnuFileProperty.Enabled = fv1
        mnuShapeFileOut.Enabled = fv1
        pnlSettings.Visible = fv1
        mnuSave.Enabled = fv1
        mnuSaveAs.Enabled = fv1
        mnuImportData.Enabled = fv1
        mnuClipOut.Enabled = fv1
        mnuShowDataItems.Enabled = fv1
        mnuDeleteInvisibleObject.Enabled = fv1
        mnuPropertyEdit.Enabled = fv1
        mnuCopyDataItemSettings.Enabled = fv1
        mnuSetSeriesMode.Enabled = fv1
        mnuSymbolPosition.Enabled = fv1
        mnuExchangeObjectName.Enabled = fv1
        mnuOption.Enabled = fv1
    End Sub

    Private Sub ImportFileFromMANDARAfile_Click(sender As Object, e As EventArgs) Handles mnuImportFileFromMANDARAfile.Click

        Dim ofd As New OpenFileDialog
        If clsSettings.Data.Directory.DataFile = "" Then
            clsSettings.Data.Directory.DataFile = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        End If
        ofd.InitialDirectory = clsSettings.Data.Directory.DataFile
        ofd.Filter = "MANDARAデータファイル(*.csv;*.mdrz;*.mdrmz;*.mdr;*.mdrm)|*.csv;*.mdrz;*.mdrmz;*.mdr;*.mdrm|CSVファイル(*.csv)|*.csv|属性データファイル(*.mdrz)|*.mdrz|地図ファイル付属形式ファイル(*.mdrmz)|*.mdrmz|旧データファイル(*.mdr;*.mdrm)|*.mdr;*.mdrm|すべてのファイル(*.*)|*.*"
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim newAttrData As New clsAttrData(TileMap)
            Dim oem As String = ""
            Cursor.Current = Cursors.WaitCursor
            Dim f As Boolean = newAttrData.OpenNewMandaraFile(False, ofd.FileName, oem, ProgressBar)
            Cursor.Current = Cursors.Default
            If f = False Then
                If oem <> "" Then
                    clsGeneric.Message(Me, "読み込みエラー", oem, True, False)
                End If
            Else
                Dim f2 As Boolean = attrData.ADD_AttrData(newAttrData, True, oem)
                If f2 = True Then
                    Init_Screen_Set(True)
                    attrData.Set_LayerName_to(cboLayer, attrData.TotalData.LV1.SelectedLayer)
                    cboLayer.Visible = True
                End If
                If oem <> "" Then
                    clsGeneric.Message(Me, "読み込みエラー", oem, True, False)
                End If
            End If
        End If


    End Sub

    Private Sub mnuImportFileFromClipBoard_Click(sender As Object, e As EventArgs) Handles mnuImportFileFromClipBoard.Click
        Dim newAttrData As New clsAttrData(TileMap)
        Dim oem As String = ""
        Cursor.Current = Cursors.WaitCursor
        Dim f As Boolean = newAttrData.OpenNewMandaraFile(True, "Clipboard", oem, ProgressBar)
        Cursor.Current = Cursors.Default
        If f = False Then
            If oem <> "" Then
                clsGeneric.Message(Me, "読み込みエラー", oem, True, False)
            End If
        Else
            Dim oem2 As String = ""
            Dim f2 As Boolean = attrData.ADD_AttrData(newAttrData, False, oem2)
            If f2 = True Then
                Init_Screen_Set(True)
                attrData.Set_LayerName_to(cboLayer, attrData.TotalData.LV1.SelectedLayer)
                cboLayer.Visible = True
            Else
                clsGeneric.Message(Me, "読み込みエラー", oem2, True, False)
            End If
            If oem <> "" Then
                clsGeneric.Message(Me, "読み込みエラー", oem, True, False)
            End If
        End If
    End Sub

    Private Sub mnuImportFileFromViewer_Click(sender As Object, e As EventArgs) Handles mnuImportFileFromViewer.Click
        Dim form As New frmMain_ShowViewer
        If form.ShowDialog("", TileMap) = Windows.Forms.DialogResult.OK Then
            Dim newAttrData As clsAttrData = form.GetResult
            Dim oem As String = ""
            Dim f2 As Boolean = attrData.ADD_AttrData(newAttrData, False, oem)
            If f2 = True Then
                Init_Screen_Set(True)
                attrData.Set_LayerName_to(cboLayer, attrData.TotalData.LV1.SelectedLayer)
                cboLayer.Visible = True
            End If
            If oem <> "" Then
                clsGeneric.Message(Me, "読み込みエラー", oem, True, False)
            End If
        End If
        form.Dispose()

    End Sub

    ''' <summary>
    ''' クリップボードにデータのコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuClipOut_Click(sender As Object, e As EventArgs) Handles mnuClipOut.Click
        Dim sb As New System.Text.StringBuilder()
        Cursor.Current = Cursors.WaitCursor
        sb.Append("MAP" + vbTab)
        Dim MapFile() As String = attrData.GetMapFileName
        sb.Append(String.Join(vbTab, MapFile) + vbCrLf)

        If attrData.TotalData.LV1.Comment <> "" Then
            Dim ComSplit() As String = attrData.TotalData.LV1.Comment.Split(vbCrLf)
            For i As Integer = 0 To ComSplit.Length - 1
                sb.Append("COMMENT" & vbTab & ComSplit(i) & vbCrLf)
            Next
        End If

        For L As Integer = 0 To attrData.TotalData.LV1.Lay_Maxn - 1
            With attrData.LayerData(L)
                Dim layType As clsAttrData.enmLayerType = .Type
                Dim URLMax As Integer = 0
                If layType <> clsAttrData.enmLayerType.Trip And layType <> clsAttrData.enmLayerType.Trip_Definition Then
                    URLMax = attrData.Get_MaxURLNum(L)
                End If
                'レイヤのヘッダ
                If attrData.TotalData.LV1.Lay_Maxn = 1 And .Name = "" Then
                Else
                    Dim LAYHeader As String = "LAYER" + vbTab + .Name + vbTab + .MapFileName + vbCrLf
                    sb.Append(LAYHeader)
                End If

                Dim Ltype As String = "TYPE" + vbTab
                Select Case layType
                    Case clsAttrData.enmLayerType.Normal
                        Ltype += "NORMAL"
                    Case clsAttrData.enmLayerType.DefPoint
                        Ltype += "POINT"
                    Case clsAttrData.enmLayerType.Mesh
                        Ltype += "MESH" + vbTab
                        Select Case .MeshType
                            Case enmMesh_Number.mhFirst
                                Ltype += "1"
                            Case enmMesh_Number.mhSecond
                                Ltype += "2"
                            Case enmMesh_Number.mhThird
                                Ltype += "3"
                            Case enmMesh_Number.mhHalf
                                Ltype += "1/2"
                            Case enmMesh_Number.mhQuarter
                                Ltype += "1/4"
                            Case enmMesh_Number.mhOne_Eighth
                                Ltype += "1/8"
                            Case enmMesh_Number.mhOne_Tenth
                                Ltype += "1/10"
                        End Select
                    Case clsAttrData.enmLayerType.Trip
                        Ltype += "TRIP"
                    Case clsAttrData.enmLayerType.Trip_Definition
                        Ltype += "TRIP_DEFINITION"
                End Select
                Select Case layType
                    Case clsAttrData.enmLayerType.DefPoint, clsAttrData.enmLayerType.Mesh
                        Select Case .ReferenceSystem
                            Case enmZahyo_System_Info.Zahyo_System_tokyo
                                Ltype += vbTab + "日本"
                            Case enmZahyo_System_Info.Zahyo_System_World
                                Ltype += vbTab + "世界"
                        End Select
                End Select
                Ltype += vbCrLf
                sb.Append(Ltype)

                If layType <> clsAttrData.enmLayerType.Trip_Definition Then
                    If .MapFileData.Map.Time_Mode = True Then
                        Dim LayTime As String = "TIME" + vbTab + .Time.Year.ToString + vbTab + .Time.Month.ToString + vbTab + .Time.Day.ToString + vbCrLf
                        sb.Append(LayTime)
                    End If
                End If

                If layType = clsAttrData.enmLayerType.Normal Then
                    Dim Shape As String = "SHAPE" + vbTab
                    Select Case .Shape
                        Case enmShape.PolygonShape
                            Shape += "POLYGON"
                        Case enmShape.LineShape
                            Shape += "LINE"
                        Case enmShape.PointShape
                            Shape += "POINT"
                    End Select
                    sb.Append(Shape + vbCrLf)
                End If

                If .Comment <> "" Then
                    Dim ComSplit() As String = .Comment.Split(vbCrLf)
                    For i As Integer = 0 To ComSplit.Length - 1
                        sb.Append("COMMENT" & vbTab & ComSplit(i) & vbCrLf)
                    Next
                End If

                With .atrData
                    'データ項目のヘッダ
                    Dim Title As String = "TITLE"
                    Dim Unit As String = "UNIT"
                    Dim Missing As String = "DATA_MISSING"
                    Dim Note As String = "NOTE"
                    Dim misf As Boolean = False
                    Select Case layType
                        Case clsAttrData.enmLayerType.Trip
                            If attrData.LayerData(L).TripType = clsAttrData.enmTripPositionType.ObjectSet Then
                                Title += vbTab + "PLACE"
                            Else
                                Title += vbTab + "LAT" + vbTab + "LON"
                                Unit += vbTab
                                Missing += vbTab
                                Note += vbTab
                            End If
                            Title += vbTab + "ARRIVAL" + vbTab + "DEPARTURE"
                            Unit += vbTab + vbTab + vbTab
                            Missing += vbTab + vbTab + vbTab
                            Note += vbTab + vbTab + vbTab
                        Case clsAttrData.enmLayerType.DefPoint
                            Title += vbTab + "LON" + vbTab + "LAT"
                            Unit += vbTab + vbTab
                            Missing += vbTab + vbTab
                            Note += vbTab + vbTab
                    End Select
                    For i As Integer = 0 To .Count - 1
                        With .Data(i)
                            Title += vbTab + .Title
                            Unit += vbTab + .Unit
                            Missing += vbTab
                            If .MissingF = True Then
                                misf = True
                                Missing += "ON"
                            End If
                            Note += vbTab + .Note
                        End With
                    Next
                    For i As Integer = 0 To URLMax - 1
                        Title += vbTab + "URL_NAME" + vbTab + "URL"
                        Unit += vbTab + vbTab
                        Missing += vbTab + vbTab
                        Note += vbTab + vbTab
                    Next
                    Title += vbCrLf
                    Unit += vbCrLf
                    Note += vbCrLf
                    Missing += vbCrLf
                    sb.Append(Title)
                    sb.Append(Unit)
                    If misf = True Then
                        sb.Append(Missing)
                    End If
                    sb.Append(Note)
                End With
                'データ
                For i As Integer = 0 To .atrObject.ObjectNum - 1
                    Dim obj As String = attrData.Get_KenObjName(L, i)
                    Select Case layType
                        Case clsAttrData.enmLayerType.Trip
                            With .atrObject.TripObjData(i)
                                If attrData.LayerData(L).TripType = clsAttrData.enmTripPositionType.ObjectSet Then
                                    obj += vbTab + .PositionObjName
                                Else
                                    obj += vbTab + .LatLon.Latitude.ToString + vbTab + .LatLon.Longitude.ToString
                                End If
                                obj += vbTab + .ArrivalTime.ToString("yyyyMMddhhmmss")
                                obj += vbTab + .DepartureTime.ToString("yyyyMMddhhmmss")
                            End With
                        Case clsAttrData.enmLayerType.DefPoint
                            Dim p As PointF = spatial.Get_Reverse_XY(.atrObject.atrObjectData(i).Symbol, attrData.TotalData.ViewStyle.Zahyo)
                            obj += vbTab + p.X.ToString + vbTab + p.Y.ToString
                    End Select
                    For j As Integer = 0 To .atrData.Count - 1
                        obj += vbTab + attrData.Get_Data_Value(L, j, i, "")
                    Next
                    If layType <> clsAttrData.enmLayerType.Trip Then
                        With .atrObject.atrObjectData(i)
                            For j As Integer = 0 To .HyperLinkNum - 1
                                obj += vbTab + .HyperLink(j).Name
                                obj += vbTab + .HyperLink(j).Address
                            Next
                        End With
                    End If
                    obj += vbCrLf
                    sb.Append(obj)
                Next
            End With
        Next

        Clipboard.SetText(sb.ToString)
        Cursor.Current = Cursors.Default
        MsgBox("クリップボードにデータをコピーしました。")
    End Sub
    Private Sub btnDataShow_Click(sender As Object, e As EventArgs) Handles btnDataShow.Click
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim DataNum As Integer = attrData.LayerData(Layernum).atrData.SelectedIndex
        Dim dataList As New List(Of String)
        dataList.Add("オブジェクト名" + vbTab + "値" + attrData.Get_DataUnit_With_Kakko(Layernum, DataNum))
        For i As Integer = 0 To attrData.LayerData(Layernum).atrObject.ObjectNum - 1
            Dim tx As String = attrData.Get_KenObjName(Layernum, i) + vbTab + attrData.Get_Data_Value(Layernum, DataNum, i, attrData.TotalData.ViewStyle.Missing_Data.Text)
            dataList.Add(tx)
        Next
        Dim var() As VariantType = {VariantType.String, VariantType.String}
        Select Case attrData.LayerData(Layernum).atrData.Data(DataNum).DataType
            Case enmAttDataType.Normal
                var(1) = VariantType.Double
            Case Else
        End Select
        clsGeneric.Message(Me, attrData.Get_DataTitle(Layernum, DataNum, False), dataList, var, {True, True}, True, True)
    End Sub

    Private Sub btnStatictics_Click(sender As Object, e As EventArgs) Handles btnStatictics.Click
        Dim tx As String = ""
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim DataNum As Integer = attrData.LayerData(Layernum).atrData.SelectedIndex
        With attrData.LayerData(Layernum).atrData.Data(DataNum)
            tx += attrData.Get_Layer_Name(Layernum)
            tx += "データ項目：" + .Title + vbCrLf
            tx += "オブジェクト数：" + attrData.LayerData(Layernum).atrObject.ObjectNum.ToString + vbCrLf
            tx += "データの種類：" + clsGeneric.ConvertAttDataTypeString(.DataType) + vbCrLf
            If .DataType = enmAttDataType.Normal Then
                tx += "単位：" + .Unit + vbCrLf
                tx += "最大値：" + .Statistics.Max.ToString + vbCrLf
                tx += "最小値：" + .Statistics.Min.ToString + vbCrLf
                tx += "合計値：" + .Statistics.Sum.ToString + vbCrLf
                tx += "平均値：" + .Statistics.Ave.ToString + vbCrLf
                tx += "中央値：" + attrData.Get_MedianValue(Layernum, DataNum).ToString + vbCrLf
                tx += "標準偏差：" + .Statistics.STD.ToString + vbCrLf
                tx += "分散：" + (.Statistics.STD ^ 2).ToString + vbCrLf

            End If
            tx += vbCrLf
            tx += "非欠損値オブジェクト：" + .EnableValueNum.ToString + vbCrLf
            tx += "欠損値オブジェクト：" + .MissingValueNum.ToString + vbCrLf
        End With
        clsGeneric.Message(Me, attrData.Get_DataTitle(Layernum, DataNum, False), tx, False, True)

    End Sub

    Private Sub mnuShapefile_Click(sender As Object, e As EventArgs) Handles mnuShapefile.Click

        If Check_EraseSettei_OK(True) = True Then
            GetShapefile()
        End If
    End Sub
    ''' <summary>
    ''' シェープファイル読み込み（メニューから）
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetShapefile() As Boolean
        Dim shapefiles() As clsShapefile.shapefile_info
        Dim form As New frmShapeFile
        Dim topology_f As Boolean
        If form.ShowDialog(Me, New clsMapData, "ひとつのレイヤにまとめる") = DialogResult.OK Then
            Dim integrate_F As Boolean
            shapefiles = form.getResult(topology_f, integrate_F)

            Dim MapData As New Dictionary(Of String, clsMapData)
            Dim LayerData As New List(Of frmMain_ShowViewer.strLayerInfo)
            Dim f As Boolean = getShapeFileCommon(shapefiles, topology_f, integrate_F, MapData, LayerData)
            If f = False Then
                MsgBox("シェープファイルを読み込めませんでした", MsgBoxStyle.Exclamation)
            Else
                attrData = New clsAttrData(TileMap)
                attrData.SetMapViewerData(MapData, LayerData, True)
                attrData.TotalData.LV1.DataSourceType = enmDataSource.Shapefile
                man_Data = attrData.TotalData.LV1.DataSourceType
                Init_Screen_Set(False)
                initFirtScreen()
                menu_Setting()
                Me.Text = attrData.TotalData.LV1.FileName
            End If
        End If

        form.Dispose()

        Return True

    End Function

    Private Function getShapeFileCommon(ByRef shapefiles() As clsShapefile.shapefile_info, ByVal topology_f As Boolean, ByVal integrate_F As Boolean,
                                        ByRef MapData As Dictionary(Of String, clsMapData), ByRef LayerData As List(Of frmMain_ShowViewer.strLayerInfo)) As Boolean
        Dim n As Integer = shapefiles.Length
        If integrate_F = True Then
            Dim integratedMapData As New clsMapData
            Dim filen As Integer = 0
            Dim newMapFile As String = ""
            Dim mshape As enmShape
            For i As Integer = 0 To n - 1
                With shapefiles(i)
                    Dim newMapData As clsMapData = clsShapefile.Get_ShapeFile(.FullPath, .FileName + ".", True, .Zahyo, False, .encodingnumber, ProgressLabel)
                    If newMapData Is Nothing = False Then
                        newMapData.Map.Comment += "シェープファイル：" + .FileName + vbCrLf
                        newMapData.ObjectKind(0).Color = newMapData.Set_First_ObjectKind_Color_Solo(0)
                        If newMapData.ObjectKind(0).Shape = enmShape.PolygonShape And topology_f = True Then
                            newMapData.TopologyStructure_SameLine()
                        End If
                        If filen = 0 Then
                            newMapFile = System.IO.Path.GetFileNameWithoutExtension(.FileName)
                            integratedMapData = newMapData.Clone()
                            mshape = newMapData.ObjectKind(0).Shape
                        Else
                            integratedMapData.InsertMapData(newMapData, "")
                        End If
                        filen += 1
                    End If
                End With
            Next
            Dim bl(filen - 1) As Boolean
            clsGeneric.FillArray(bl, True)

            With integratedMapData
                If mshape <> enmShape.PointShape Then
                    .Combine_Linekinds(bl, "境界", clsBase.Line)
                    .countNumOfLineUse()
                End If
                .Combine_Objectkinds(bl, .ObjectKind(0).Name)
                .init_Compass_First()
                If mshape = enmShape.PolygonShape And topology_f = True Then
                    .Add_OneLineKind("外周境界", clsBase.BoldLine, enmMesh_Number.mhNonMesh)
                    For i As Integer = 0 To .Map.ALIN - 1
                        With .MPLine(i)
                            If .NumOfLineUse = 1 Then
                                .LineTimeSTC(0).Kind = 1
                            End If
                        End With
                    Next
                    .CheckLine_Kind_UsedBy_ObjectKind(.ObjectKind(0).Name + vbTab + .LineKind(0).Name + vbTab + .LineKind(1).Name)
                End If
                Dim datanum As Integer = .ObjectKind(0).DefTimeAttDataNum
                Dim data_str(datanum - 1, .Map.OBKNum - 1) As String
                For i As Integer = 0 To .ObjectKind(0).DefTimeAttDataNum - 1
                    For j As Integer = 0 To .Map.OBKNum - 1
                        data_str(i, j) = .MPObj(j).DefTimeAttValue(i).Data(0).Value
                    Next
                Next
                Dim UNT() As String = clsGeneric.Check_DataType(datanum, .Map.OBKNum, data_str)
                For i As Integer = 0 To datanum - 1
                    With .ObjectKind(0).DefTimeAttSTC(i).attData
                        .Unit = UNT(i)
                    End With
                Next
                If .Map.LpNum = 0 Then
                    .Add_OneLineKind("新規線種", clsBase.Line, enmMesh_Number.mhNonMesh)
                End If
            End With
            MapData.Add(newMapFile.ToUpper, integratedMapData)
            Dim d As frmMain_ShowViewer.strLayerInfo
            With d
                .Name = newMapFile
                .MapfileName = newMapFile
                .Shape = mshape
                .Time = clsTime.GetNullYMD
                ReDim .UseObjectKind(0)
                .UseObjectKind(0) = True
            End With
            LayerData.Add(d)
        Else
            For i As Integer = 0 To n - 1
                With shapefiles(i)
                    Dim newMapData As clsMapData = clsShapefile.Get_ShapeFile(.FullPath, .FileName + ".", True, .Zahyo, True, .encodingnumber, ProgressLabel)
                    If newMapData Is Nothing = False Then
                        newMapData.Map.Comment += "シェープファイル：" + .FileName + vbCrLf
                        newMapData.init_Compass_First()
                        newMapData.ObjectKind(0).Color = newMapData.Set_First_ObjectKind_Color_Solo(0)
                        Dim newMapFile As String = System.IO.Path.GetFileNameWithoutExtension(.FileName)
                        If newMapData.ObjectKind(0).Shape = enmShape.PolygonShape And topology_f = True Then
                            newMapData.TopologyStructure_SameLine()
                        End If
                        If newMapData.Map.LpNum = 0 Then
                            newMapData.Add_OneLineKind("新規線種", clsBase.Line, enmMesh_Number.mhNonMesh)
                        End If
                        MapData.Add(newMapFile.ToUpper, newMapData)
                        Dim d As frmMain_ShowViewer.strLayerInfo
                        With d
                            .Name = shapefiles(i).FileName
                            .MapfileName = newMapFile
                            .Shape = newMapData.ObjectKind(0).Shape
                            .Time = clsTime.GetNullYMD
                            ReDim .UseObjectKind(0)
                            .UseObjectKind(0) = True
                        End With
                        LayerData.Add(d)
                    End If
                End With
            Next
        End If
        Return MapData.Count > 0
    End Function
    Private Sub mnuImportFileFromShapefile_Click(sender As Object, e As EventArgs) Handles mnuImportFileFromShapefile.Click
        Dim shapefiles() As clsShapefile.shapefile_info
        Dim form As New frmShapeFile
        Dim topology_f As Boolean
        If form.ShowDialog(Me, New clsMapData, "ひとつのレイヤにまとめる") = DialogResult.OK Then
            Dim integrate_F As Boolean
            shapefiles = form.getResult(topology_f, integrate_F)
            Dim MapData As New Dictionary(Of String, clsMapData)
            Dim LayerData As New List(Of frmMain_ShowViewer.strLayerInfo)
            Dim f As Boolean = getShapeFileCommon(shapefiles, topology_f, integrate_F, MapData, LayerData)
            If f = False Then
                MsgBox("シェープファイルを読み込めませんでした", MsgBoxStyle.Exclamation)
            Else
                Dim newAttrData As clsAttrData = New clsAttrData(TileMap)
                newAttrData.SetMapViewerData(MapData, LayerData, True)
                newAttrData.TotalData.LV1.FileName = ""
                Dim emes As String = ""
                Dim f2 As Boolean = attrData.ADD_AttrData(newAttrData, True, emes)
                If f2 = True Then
                    attrData.TotalData.LV1.DataSourceType = enmDataSource.Shapefile
                    man_Data = enmDataSource.Shapefile
                    Init_Screen_Set(True)
                    attrData.Set_LayerName_to(cboLayer, attrData.TotalData.LV1.SelectedLayer)
                    cboLayer.Visible = True
                End If
                If emes <> "" Then
                    clsGeneric.Message(Me, "読み込みエラー", emes, True, False)
                End If
            End If
        End If

        form.Dispose()
    End Sub

    Private Sub mnuPropertyEdit_Click(sender As Object, e As EventArgs) Handles mnuPropertyEdit.Click
        If man_Data = enmDataSource.NoData Then
            mnuPropertyNew.PerformClick()
        Else
            Frm_Print.Visible = False
            Dim form As New frmGrid
            If form.ShowDialog(attrData, TileMap) = Windows.Forms.DialogResult.OK Then
                attrData = New clsAttrData(TileMap)
                attrData = form.getResult
                Init_Screen_Set(True)
                initFirtScreen()
                menu_Setting()
            End If
            form.Dispose()
        End If
    End Sub

    Private Sub mnuPropertyNew_Click(sender As Object, e As EventArgs) Handles mnuPropertyNew.Click
        If Check_EraseSettei_OK(True) = True Then
            attrData = New clsAttrData(TileMap)
            Dim form As New frmGrid
            If form.ShowDialog(attrData, TileMap) = Windows.Forms.DialogResult.OK Then
                attrData = form.getResult
                man_Data = attrData.TotalData.LV1.DataSourceType
                Init_Screen_Set(False)
                initFirtScreen()
                menu_Setting()
                Me.Text = attrData.TotalData.LV1.FileName
            End If
            form.Dispose()
        End If
    End Sub

    Private Sub frmMain_Move(sender As Object, e As EventArgs) Handles Me.Move
        For Each cForm As Form In Me.OwnedForms
            cForm.Location = New Point(Me.Left + Me.Width, Me.Top)
        Next cForm
    End Sub


    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Select Case Me.WindowState
            Case FormWindowState.Minimized
                If Frm_Print.Visible = True Then
                    Frm_Print.WindowState = FormWindowState.Minimized
                End If
            Case FormWindowState.Normal
                If Frm_Print Is Nothing = False Then
                    If Frm_Print.Visible = True Then
                        Frm_Print.WindowState = FormWindowState.Normal
                    End If
                End If
        End Select
    End Sub


    Private Sub mnuCopyDataItemSettings_Click(sender As Object, e As EventArgs) Handles mnuCopyDataItemSettings.Click
        Dim form As New frmMain_CopyDataItemSettings
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim DataNum As Integer = attrData.LayerData(Layernum).atrData.SelectedIndex
        If form.ShowDialog(attrData, Layernum, DataNum) = DialogResult.OK Then
            form.getResults(attrData)
            MsgBox("データ項目設定をコピーしました。")
            SelectModeSet()
        End If
        form.Dispose()
    End Sub



    Private Sub mnuSetSeriesMode_Click(sender As Object, e As EventArgs) Handles mnuSetSeriesMode.Click
        Dim form As New frmMain_SetSeriesMode
        If form.ShowDialog(attrData, attrData.TotalData.LV1.SelectedLayer) = DialogResult.OK Then
            Dim sel As Integer = form.getResults(attrData)
            MsgBox("連続表示モードに設定しました。")
            attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.SeriesMode
            attrData.TotalData.TotalMode.Series.SelectedIndex = sel
            Dim osel As enmSelectMode = SelectedMode
            Dim os As OldSelectedMode_info
            os.oldSelMode = osel
            os.oldTotoalMode = attrData.TotalData.LV1.Print_Mode_Total
            oldSelectedMode.Add(os)

            SelectedModeClear()
            SelectedMode = enmSelectMode.SeriesMode
            picTotalModeOverPanel_Visible()
            SelectModeSet()
        End If
        form.Dispose()
    End Sub

    Private Sub picSeries_Click(sender As Object, e As EventArgs) Handles picSeries.Click

    End Sub

    Private Sub mnuConditionSettings_Click(sender As Object, e As EventArgs) Handles mnuConditionSettings.Click
        Dim form As New frmMain_ConditionSettings
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            Check_Print_err()
        End If
        form.Dispose()
    End Sub

    Private Sub btnConditionInfo_Click(sender As Object, e As EventArgs) Handles btnConditionInfo.Click

        Dim Check_Lay(attrData.TotalData.LV1.Lay_Maxn - 1) As Boolean
        Dim ST As String = ""
        Dim sb As New System.Text.StringBuilder()
        Select Case attrData.TotalData.LV1.Print_Mode_Total
            Case enmTotalMode_Number.DataViewMode
                Dim L As Integer = attrData.TotalData.LV1.SelectedLayer
                If attrData.LayerData(L).Type <> clsAttrData.enmLayerType.Trip Then
                    ST = attrData.Get_Condition_Info(L)
                    sb.Append(attrData.Get_Condition_Ok_Num_Info(L))
                    sb.Append(vbCrLf + "適合オブジェクト一覧" & vbCrLf & vbCrLf)
                    For i As Integer = 0 To attrData.Get_ObjectNum(L) - 1
                        If attrData.Check_Condition(L, i) = True Then
                            sb.Append(attrData.Get_KenObjName(L, i) & vbCrLf)
                        End If
                    Next
                Else
                    '移動データレイヤの場合
                    Dim tdefl As Integer = attrData.Get_Trip_Definition_Layer_Number()
                    ST = attrData.Get_Condition_Info(tdefl)
                    Dim tripPerson As New List(Of Integer)
                    Dim tripn As Integer = 0
                    Dim mx As Integer = attrData.LayerData(L).atrObject.ObjectNum
                    Do
                        Dim cd As Integer = attrData.LayerData(L).atrObject.TripObjData(tripn).TripPersonCode
                        tripPerson.Add(cd)
                        Do While cd = attrData.LayerData(L).atrObject.TripObjData(tripn).TripPersonCode
                            tripn += 1
                            If tripn = mx Then
                                Exit Do
                            End If
                        Loop
                    Loop While tripn < mx
                    sb.Append("レイヤ：" & attrData.LayerData(L).Name + vbCrLf + vbCrLf)
                    sb.Append("全移動主体数:" & tripPerson.Count.ToString + vbCrLf)
                    Dim nonvisin As Integer = 0
                    Dim nonvisiObj As String = ""
                    For i As Integer = 0 To tripPerson.Count - 1
                        If attrData.Check_Condition(tdefl, tripPerson(i)) = True Then
                            nonvisiObj += attrData.Get_KenObjName(tdefl, tripPerson(i)) & vbCrLf
                            nonvisin += 1
                        End If
                    Next
                    sb.Append("適合移動主体数:" & (tripPerson.Count - nonvisin).ToString + vbCrLf)
                    sb.Append("非適合移動主体数:" & nonvisin.ToString + vbCrLf)
                    sb.Append(vbCrLf + "適合移動主体一覧" & vbCrLf & vbCrLf & nonvisiObj)

                End If

            Case enmTotalMode_Number.OverLayMode
                Dim s As Integer = attrData.TotalData.TotalMode.OverLay.SelectedIndex
                For i As Integer = 0 To attrData.TotalData.TotalMode.OverLay.DataSet(s).DataItem.Count - 1
                    Dim L As Integer = attrData.TotalData.TotalMode.OverLay.DataSet(s).DataItem.Item(i).Layer
                    If Check_Lay(L) = False Then
                        ST += attrData.Get_Condition_Info(L)
                        sb.Append(attrData.Get_Condition_Ok_Num_Info(L))
                        Check_Lay(L) = True
                    End If
                Next
            Case enmTotalMode_Number.SeriesMode
                Dim s As Integer = attrData.TotalData.TotalMode.Series.SelectedIndex
                For i As Integer = 0 To attrData.TotalData.TotalMode.Series.DataSet(s).DataItem.Count - 1
                    Dim L As Integer = attrData.TotalData.TotalMode.Series.DataSet(s).DataItem.Item(i).Layer
                    If Check_Lay(L) = False Then
                        ST += attrData.Get_Condition_Info(L)
                        sb.Append(attrData.Get_Condition_Ok_Num_Info(L))
                        Check_Lay(L) = True
                    End If
                Next
        End Select



        clsGeneric.Message(Me, "属性検索条件", ST & sb.ToString, True, True)
    End Sub
    ''' 
    ''' 代表点を属性データとして取得
    ''' 
    Private Sub mnuRepresentativePointGet_Click(sender As Object, e As EventArgs) Handles mnuRepresentativePointGet.Click

        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim Objn = attrData.Get_ObjectNum(LayerNum)
        Dim Data_Val_STRX(Objn - 1) As String
        Dim Data_Val_STRY(Objn - 1) As String

        For i As Integer = 0 To Objn - 1
            Dim P As PointF = attrData.Get_CenterP(LayerNum, i)
            Dim P2 As PointF = spatial.Get_Reverse_XY(P, attrData.TotalData.ViewStyle.Zahyo)
            Data_Val_STRX(i) = CStr(P2.X)
            Data_Val_STRY(i) = CStr(P2.Y)
        Next
        addLocation(Data_Val_STRX, Data_Val_STRY, "代表点")


    End Sub
    ''' 
    ''' 記号表示位置を属性データとして取得
    ''' 
    ''' 
    ''' 
    ''' 
    Private Sub mnuSymbolLocationGet_Click(sender As Object, e As EventArgs) Handles mnuSymbolLocationGet.Click
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim Objn = attrData.Get_ObjectNum(LayerNum)
        Dim Data_Val_STRX(Objn - 1) As String
        Dim Data_Val_STRY(Objn - 1) As String

        For i As Integer = 0 To Objn - 1
            Dim P As PointF = attrData.LayerData(LayerNum).atrObject.atrObjectData(i).Symbol
            Dim P2 As PointF = spatial.Get_Reverse_XY(P, attrData.TotalData.ViewStyle.Zahyo)
            Data_Val_STRX(i) = CStr(P2.X)
            Data_Val_STRY(i) = CStr(P2.Y)
        Next
        addLocation(Data_Val_STRX, Data_Val_STRY, "記号表示位置")
    End Sub
    ''' <summary>
    ''' ラベル、シンボル、代表点を追加
    ''' </summary>
    ''' <param name="Data_Val_STRX"></param>
    ''' <param name="Data_Val_STRY"></param>
    ''' <param name="title"></param>
    ''' <remarks></remarks>
    Private Sub addLocation(ByRef Data_Val_STRX() As String, ByRef Data_Val_STRY() As String, ByVal title As String)
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim newN As Integer = attrData.Get_DataNum(LayerNum)


        Dim TTL As String = ""
        Select Case attrData.TotalData.ViewStyle.Zahyo.Mode
            Case enmZahyo_mode_info.Zahyo_No_Mode
                TTL = title + "Ｘ"
            Case enmZahyo_mode_info.Zahyo_Ido_Keido
                TTL = title + "経度"
            Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                TTL = title + "Ｙ"
        End Select
        attrData.Add_One_Data_Value(LayerNum, TTL, "", "", Data_Val_STRX, False)

        Select Case attrData.TotalData.ViewStyle.Zahyo.Mode
            Case enmZahyo_mode_info.Zahyo_No_Mode
                TTL = title + "Ｙ"
            Case enmZahyo_mode_info.Zahyo_Ido_Keido
                TTL = title + "緯度"
            Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                TTL = title + "Ｘ"
        End Select
        attrData.Add_One_Data_Value(LayerNum, TTL, "", "", Data_Val_STRY, False)
        cboDataItem.Items.Add(attrData.Get_DataTitle(LayerNum, newN, True))
        cboDataItem.Items.Add(attrData.Get_DataTitle(LayerNum, newN + 1, True))
        MsgBox(title + "を取得しました。")
        cboDataItem.SelectedIndex = newN


    End Sub
    ''' 
    ''' ラベル位置を属性データとして取得
    ''' 
    ''' 
    ''' 
    ''' 
    Private Sub mnuLabelLocationGet_Click(sender As Object, e As EventArgs) Handles mnuLabelLocationGet.Click
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim Objn = attrData.Get_ObjectNum(LayerNum)
        Dim Data_Val_STRX(Objn - 1) As String
        Dim Data_Val_STRY(Objn - 1) As String

        For i As Integer = 0 To Objn - 1
            Dim P As PointF = attrData.LayerData(LayerNum).atrObject.atrObjectData(i).Label
            Dim P2 As PointF = spatial.Get_Reverse_XY(P, attrData.TotalData.ViewStyle.Zahyo)
            Data_Val_STRX(i) = CStr(P2.X)
            Data_Val_STRY(i) = CStr(P2.Y)
        Next
        addLocation(Data_Val_STRX, Data_Val_STRY, "ラベル表示位置")
    End Sub
    ''' 
    ''' 記号表示位置を代表点に戻す
    ''' 
    ''' 
    ''' 
    ''' 
    Private Sub mnuSetRepPoint_Click(sender As Object, e As EventArgs) Handles mnuSetRepPoint.Click
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim Objn = attrData.Get_ObjectNum(LayerNum)
        For i As Integer = 0 To Objn - 1
            Dim P As PointF = attrData.Get_CenterP(LayerNum, i)
            attrData.LayerData(LayerNum).atrObject.atrObjectData(i).Symbol = P
        Next
        MsgBox("記号表示位置をオブジェクトの代表点に戻しました。")
    End Sub
    '''
    ''' ラベル表示位置を代表点に戻す
    ''' 
    ''' 
    ''' 
    ''' 
    Private Sub mnuSetRepPointToLabel_Click(sender As Object, e As EventArgs) Handles mnuSetRepPointToLabel.Click
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim Objn = attrData.Get_ObjectNum(LayerNum)
        For i As Integer = 0 To Objn - 1
            Dim P As PointF = attrData.Get_CenterP(LayerNum, i)
            attrData.LayerData(LayerNum).atrObject.atrObjectData(i).Label = P
        Next
        MsgBox("ラベル表示位置をオブジェクトの代表点に戻しました。")
    End Sub
    ''' <summary>
    ''' 重心を記号/ラベル表示位置に設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuSetGPointToSumbolPosition_Click(sender As Object, e As EventArgs) Handles mnuSetGPointToSymbolPosition.Click, mnuSetGPointToLabelPosition.Click
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        If attrData.LayerData(LayerNum).Shape <> enmShape.PolygonShape Then
            MsgBox("この機能は面オブジェクトのみで使用できます。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim Objn = attrData.Get_ObjectNum(LayerNum)
        For i As Integer = 0 To Objn - 1
            Dim P As PointF
            Dim f As Boolean = attrData.Get_ObjectGravityPoint(LayerNum, i, P)
            If f = True Then
                If sender.name = "mnuSetGPointToSymbolPosition" Then
                    attrData.LayerData(LayerNum).atrObject.atrObjectData(i).Symbol = P
                Else
                    attrData.LayerData(LayerNum).atrObject.atrObjectData(i).Label = P
                End If
            End If
        Next
        If sender.name = "mnuSetGPointToSymbolPosition" Then
            MsgBox("記号表示位置をオブジェクトの重心に設定しました。")
        Else
            MsgBox("ラベル表示位置をオブジェクトの重心に設定しました。")
        End If
    End Sub
    ''' 
    ''' 記号表示位置をラベル表示位置に設定
    ''' 
    ''' 
    ''' 
    ''' 
    Private Sub mnuSetSymbolPosToLabelPos_Click(sender As Object, e As EventArgs) Handles mnuSetSymbolPosToLabelPos.Click
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim Objn = attrData.Get_ObjectNum(LayerNum)
        For i As Integer = 0 To Objn - 1
            attrData.LayerData(LayerNum).atrObject.atrObjectData(i).Label = attrData.LayerData(LayerNum).atrObject.atrObjectData(i).Symbol
        Next
        MsgBox("記号表示位置をラベル表示位置に設定しました。")
    End Sub
    ''' 
    ''' クロス集計
    ''' 
    ''' 
    ''' 
    ''' 
    Private Sub mnuCross_Click(sender As Object, e As EventArgs) Handles mnuCross.Click
        Dim form As New frmMain_Cross
        form.ShowDialog(attrData)
        form.Dispose()
    End Sub


    ''' <summary>
    ''' 時系列集計
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuTimeSeriesGO_Click(sender As Object, e As EventArgs) Handles mnuTimeSeriesGO.Click
        Dim mfilename() As String = attrData.GetMapFileName
        Dim f As Boolean
        For i As Integer = 0 To mfilename.Length - 1
            If attrData.SetMapFile(mfilename(i)).Map.Time_Mode = True Then
                f = True
                Exit For
            End If
        Next
        If f = False Then
            MsgBox("時空間地図データを使用していません。", MsgBoxStyle.Exclamation)
            Return
        End If

        If attrData.TotalData.LV1.Lay_Maxn = 1 Then
            MsgBox("レイヤが1つしかありません。", MsgBoxStyle.Exclamation)
            Return
        End If


        f = False
        For i As Integer = 0 To attrData.TotalData.LV1.Lay_Maxn - 2
            If attrData.LayerData(i).Time.Equals(attrData.LayerData(i + 1).Time) = False Then
                f = True
            End If
        Next
        If f = False Then
            MsgBox("レイヤの時期設定が同一です。", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim normn As Integer = 0
        For i As Integer = 0 To attrData.TotalData.LV1.Lay_Maxn - 1
            If attrData.LayerData(i).Type = clsAttrData.enmLayerType.Normal Then
                normn += 1
            End If
        Next
        If normn < 2 Then
            MsgBox("時系列集計可能なレイヤが不足しています。", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim form As New frmMain_TimeSeriesSummingUp
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            Dim L As Integer = attrData.TotalData.LV1.Lay_Maxn - 1
            cboLayer.Items.Add(attrData.LayerData(L).Name)
            If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.DataViewMode Then
                cboLayer.SelectedIndex = L
            End If
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' シェープファイル出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuShapeFileOut_Click(sender As Object, e As EventArgs) Handles mnuShapeFileOut.Click
        Dim form As New frmMain_ShapefileOut
        form.ShowDialog(attrData)
        form.Dispose()
    End Sub

    ''' <summary>
    ''' 起動画面表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim CmdLine() As String = System.Environment.GetCommandLineArgs()

        If CmdLine.Length > 1 Then
            Dim file As String = CmdLine(1)
            FileDrom_CommandLine(file)
        Else
            Dim form As New frmStartUp
            Dim rv As DialogResult = form.ShowDialog
            Select Case rv
                Case Windows.Forms.DialogResult.OK
                    Dim RecentFile As String = ""
                    Dim re As frmStartUp.enmRetCommand = form.GetResults(RecentFile)
                    Select Case re
                        Case frmStartUp.enmRetCommand.Clipboard
                            mnuDataFromClipboard.PerformClick()
                        Case frmStartUp.enmRetCommand.File
                            mnuOpenDataFile.PerformClick()
                        Case frmStartUp.enmRetCommand.Recent
                            If System.IO.File.Exists(RecentFile) = False Then
                                MsgBox(RecentFile + "が見つかりません。", MsgBoxStyle.Exclamation)
                            Else
                                Cursor.Current = Cursors.WaitCursor
                                OpenNewMandaraFile(False, RecentFile)
                                Cursor.Current = Cursors.Default
                            End If
                        Case frmStartUp.enmRetCommand.NewData
                            mnuPropertyNew.PerformClick()
                        Case frmStartUp.enmRetCommand.White
                            mnuViewer.PerformClick()
                        Case frmStartUp.enmRetCommand.Shape
                            mnuShapefile.PerformClick()
                        Case frmStartUp.enmRetCommand.MapEditor
                            mnuMapEditor.PerformClick()
                    End Select
                Case Windows.Forms.DialogResult.Cancel
                Case Windows.Forms.DialogResult.Ignore
                    mnuEnd.PerformClick()
            End Select
            form.Dispose()

        End If
    End Sub
    ''' <summary>
    ''' 終了メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuEnd_Click(sender As Object, e As EventArgs) Handles mnuEnd.Click
        Me.Close()
    End Sub

    Private Sub mnuVersion_Click(sender As Object, e As EventArgs) Handles mnuVersion.Click
        Dim form As New frmVersionInfo
        form.ShowDialog()
        form.Dispose()
    End Sub


    ''' <summary>
    ''' データ取得・計算メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuCulc_Click(sender As Object, e As EventArgs) Handles mnuCulc.Click
        Dim form As New frmMain_Culc
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim datan As Integer = attrData.Get_DataNum(Layernum)
        form.ShowDialog(attrData)
        form.Dispose()
        Dim newDatan As Integer = attrData.Get_DataNum(Layernum)
        If datan <> newDatan Then
            For i As Integer = 0 To newDatan - datan - 1
                cboDataItem.Items.Add(attrData.Get_DataTitle(Layernum, i + datan, True))
            Next
            cboDataItem.SelectedIndex = datan
        End If
    End Sub
    ''' <summary>
    ''' オブジェクト名入れ替えメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuExchangeObjectName_Click(sender As Object, e As EventArgs) Handles mnuExchangeObjectName.Click
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        If attrData.LayerData(LayerNum).Type <> clsAttrData.enmLayerType.Normal Then
            MsgBox("オブジェクト名入れ替えは通常のレイヤのみです。", MsgBoxStyle.Exclamation)
        End If
        Dim form As New frmMain_ExchangeObjectName
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            Dim ObjG As Integer
            Dim ObjListNum As Integer
            form.GetResults(ObjG, ObjListNum)
            Dim USeMap As clsMapData = attrData.LayerData(LayerNum).MapFileData
            For i As Integer = 0 To attrData.Get_ObjectNum(LayerNum) - 1
                With attrData.LayerData(LayerNum)
                    If .atrObject.atrObjectData(i).Objectstructure = enmKenCodeObjectstructure.MapObj Then
                        If USeMap.MPObj(attrData.Get_KenObjCode(LayerNum, i)).Kind = ObjG Then
                            Dim newName As String = attrData.Get_KenObjName(LayerNum, i)
                            Dim cd As Integer = attrData.Get_KenObjCode(LayerNum, i)
                            Dim objName As String() = {}
                            USeMap.Get_Enable_ObjectName(cd, .Time, False, objName)
                            If objName(ObjListNum) <> "" Then
                                newName = objName(ObjListNum)
                            End If
                            .atrObject.atrObjectData(i).Name = newName
                        End If
                    End If
                End With
            Next
            If SelectedMode = enmSelectMode.ClassODMode Then
                Frm_ClassView.SetData(attrData)
            End If
            Me.Cursor = Cursors.Default
            MsgBox("オブジェクト名を入れ替えました。")
        End If
        form.Dispose()
    End Sub

    ''' <summary>
    ''' 距離測定メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuGetDistance_Click(sender As Object, e As EventArgs) Handles mnuGetDistance.Click
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        If attrData.LayerData(Layernum).MapFileData.Map.Detail.DistanceMeasurable = False Then
            MsgBox("レイヤで使用されている地図データが、距離測定ができない設定になっています。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim oldData As Integer = attrData.LayerData(Layernum).atrData.Count
        Dim form As New frmMain_GetDistance
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            Dim newData As Integer = attrData.LayerData(Layernum).atrData.Count
            For i As Integer = oldData To newData - 1
                cboDataItem.Items.Add(attrData.Get_DataTitle(Layernum, i, True))
            Next
            MsgBox("距離データを出力しました。")
            If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.DataViewMode Then
                If attrData.LayerData(Layernum).Print_Mode_Layer = enmLayerMode_Number.SoloMode Then
                    cboDataItem.SelectedIndex = oldData
                End If
            End If
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' バッファメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuBuffer_Click(sender As Object, e As EventArgs) Handles mnuBuffer.Click
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim oldData As Integer = attrData.LayerData(Layernum).atrData.Count
        Dim form As New frmMain_Buffer
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            Dim newData As Integer = attrData.LayerData(Layernum).atrData.Count
            For i As Integer = oldData To newData - 1
                cboDataItem.Items.Add(attrData.Get_DataTitle(Layernum, i, True))
            Next
            MsgBox("集計が終了しました。")
            If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.DataViewMode Then
                If attrData.LayerData(Layernum).Print_Mode_Layer = enmLayerMode_Number.SoloMode Then
                    cboDataItem.SelectedIndex = oldData
                End If
            End If
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' レイヤ間オブジェクト集計メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuLayerObject_Click(sender As Object, e As EventArgs) Handles mnuLayerObject.Click
        Dim form As New frmMain_LayerObjectCombine
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            Dim L As Integer = attrData.TotalData.LV1.Lay_Maxn - 1
            cboLayer.Items.Add(attrData.LayerData(L).Name)
            If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.DataViewMode Then
                cboLayer.SelectedIndex = L
            End If

        End If
        form.Dispose()

    End Sub

    Private Sub mnuHelp2_Click(sender As Object, e As EventArgs) Handles mnuHelp2.Click
        clsGeneric.HelpShow(enmHelpFile.Index, "")
    End Sub

    Private Sub mnuSettingHelp_Click(sender As Object, e As EventArgs) Handles mnuSettingHelp.Click
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "")
    End Sub

    Private Sub mnuWeb_Click(sender As Object, e As EventArgs) Handles mnuWeb.Click
        System.Diagnostics.Process.Start("http://ktgis.net/mandara/")
    End Sub


    ''' 
    ''' 表示オブジェクト限定
    ''' 
    ''' 
    ''' 
    Private Sub mnuObjectLimitaion_Click(sender As Object, e As EventArgs) Handles mnuObjectLimitaion.Click
        Dim form As New frmMain_ObjectLimitaion
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            form.GetResults()
            Check_Print_err()
        End If
        form.Dispose()
    End Sub

    Private Sub mnuTileMapRevise_Click(sender As Object, e As EventArgs) Handles mnuTileMapRevise.Click
        Dim wc As New clsWebClient
        Try
            Dim ver As Integer = Val(wc.DownloadString(kjmapdataUrl + "dataversion.txt"))
            Dim DataVersion As Integer = ReadDataVersion()
            If DataVersion < ver Then
                If MsgBox("新しいタイルマップデータがあります。更新しますか？", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    Dim xmlfilename As String = MANDARA10_datafolder + "\tilemapdata.xml"
                    If clsGeneric.Check_and_Download_File(xmlfilename, kjmapdataUrl + "tilemapdata.xml", True) = False Then
                        Return
                    End If
                    Dim jsdataname As String = MANDARA10_datafolder + "\kjmapdata.js"
                    If clsGeneric.Check_and_Download_File(jsdataname, kjmapdataUrl + "kjmapdata.js", True) = False Then
                        Return
                    End If
                    DataVersion = ver
                    WriteDataVersion(DataVersion)
                    MsgBox("更新は次回起動時から有効になります。")
                End If
            Else
                MsgBox("現在のタイルマップデータは最新です。")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
        wc.Dispose()
    End Sub
    Private Sub WriteDataVersion(ByVal DataVersion As Integer)
        Dim DataVerName As String = MANDARA10_datafolder + "\dataversion.txt"
        Try
            Dim sw As New System.IO.StreamWriter(DataVerName, False, System.Text.Encoding.GetEncoding("utf-8"))
            sw.WriteLine(DataVersion)
            sw.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function ReadDataVersion() As Integer
        Dim DataVerName As String = MANDARA10_datafolder + "\dataversion.txt"
        If System.IO.File.Exists(DataVerName) = False Then
            Return 0
        Else
            Dim sr As New System.IO.StreamReader(DataVerName, System.Text.Encoding.GetEncoding("utf-8"))
            Dim va As String = sr.ReadLine
            sr.Close()
            Return Val(va)
        End If

    End Function

    Private Sub mnuDeleteInvisibleObject_Click(sender As Object, e As EventArgs) Handles mnuDeleteInvisibleObject.Click
        Dim ObjLive As New List(Of Boolean())
        Dim LayMax As Integer = attrData.TotalData.LV1.Lay_Maxn
        Dim delN As Integer = 0
        Dim DelNum(LayMax - 1) As Integer
        For i As Integer = 0 To LayMax - 1
            Dim objn As Integer = attrData.Get_ObjectNum(i)
            Dim obn(objn - 1) As Boolean
            If attrData.LayerData(i).Type <> clsAttrData.enmLayerType.Trip And attrData.LayerData(i).Type <> clsAttrData.enmLayerType.Trip_Definition And
                attrData.LayerData(i).atrObject.NumOfSyntheticObj = 0 Then
                For j As Integer = 0 To objn - 1
                    If attrData.Check_Condition(i, j) = False Then
                        obn(j) = True
                        DelNum(i) += 1
                        delN += 1
                    End If
                Next
            End If
            If objn = DelNum(i) Then
                MsgBox(attrData.LayerData(i).Name + "は全てのオブジェクトが非表示なので、削除できません。", MsgBoxStyle.Exclamation)
                Return
            End If
            ObjLive.Add(obn)
        Next

        If delN = 0 Then
            MsgBox("非表示オブジェクトはありません。", MsgBoxStyle.Exclamation)
            Return
        Else
            If MsgBox("非表示の " + delN.ToString + " オブジェクトを削除します。", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return
            End If
        End If

        attrData.DeleteObjects(DelNum, ObjLive)


        attrData.Check_Vector_Object()
        attrData.PrtObjectSpatialIndex()
        SelectModeSet()

    End Sub

    Private Sub mnuSyntheticObject_Click(sender As Object, e As EventArgs) Handles mnuSyntheticObject.Click
        Dim f As Boolean = False
        Dim L As Integer = 0
        For i As Integer = 0 To attrData.TotalData.LV1.Lay_Maxn - 1

            If attrData.LayerData(i).atrObject.NumOfSyntheticObj > 0 Then
                L = i
                f = True
                Exit For
            End If
        Next
        If f = False Then
            MsgBox("時系列集計されたレイヤはありません。", MsgBoxStyle.Exclamation)
        Else
            Dim form As New frmSyntheticObject
            form.ShowDialog(attrData, attrData.TotalData.LV1.SelectedLayer, 0)
            form.Dispose()
        End If
    End Sub

    Private Sub mnuSymbolLocationSet_Click(sender As Object, e As EventArgs) Handles mnuSymbolLocationSet.Click, mnuLabelLocationSet.Click
        If attrData.TotalData.ViewStyle.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
            MsgBox("地図データが緯度経度座標系でないと設定できません。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim lay As Integer = attrData.TotalData.LV1.SelectedLayer
        If attrData.LayerData(lay).Type = clsAttrData.enmLayerType.Mesh Or attrData.LayerData(lay).Type = clsAttrData.enmLayerType.Normal Then

            Dim form As New frmMain_SetPositionFromData

            ' 以下の５行のIF文に対し
            ' 「BC43025 共有メンバー、定数メンバー、列挙型メンバー、
            ' 　または入れ子にされた型にインスタンス経由でアクセスしています。正規の式は評価されません。」
            ' と警告メッセージが出る。
            ' 対処法がわからないので、とりあえず放置
            ' Comment by HORI Kazunari at 2024/03/18
            ' 
            If sender.Name = "mnuSymbolLocationSet" Then
                form.ShowDialog(attrData, lay, form.enmChangeMode.symbol)
            Else
                form.ShowDialog(attrData, lay, form.enmChangeMode.label)
            End If

            form.Close()
        Else
            MsgBox("現在のレイヤの種類では設定できません。", MsgBoxStyle.Exclamation)

        End If
    End Sub

    Private Sub pnlSettings_DragDrop(sender As Object, e As DragEventArgs) Handles pnlSettings.DragDrop, Me.DragDrop
        Dim fileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        For i As Integer = 0 To Application.OpenForms.Count - 1
            Dim cForm As Form = Application.OpenForms(i)
            If cForm.Name = "frmStartUp" Then
                cForm.Close()
            End If
        Next
        For Each cForm As Form In My.Application.OpenForms
        Next
        If Check_EraseSettei_OK(True) = True Then
            Cursor.Current = Cursors.WaitCursor
            OpenNewMandaraFile(False, fileName(0))
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub pnlSettings_DragEnter(sender As Object, e As DragEventArgs) Handles pnlSettings.DragEnter, Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ''' <summary>
    ''' 面積・周長取得メニューー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuAreaPeripheri_Click(sender As Object, e As EventArgs) Handles mnuAreaPeripheri.Click
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        If attrData.LayerData(Layernum).Shape = enmShape.PointShape Or attrData.LayerData(Layernum).Shape = enmShape.NotDeffinition Then
            MsgBox("線または面形状のレイヤでないと、この機能は使えません。", MsgBoxStyle.Exclamation)
            Return
        End If
        If attrData.LayerData(Layernum).MapFileData.Map.Detail.DistanceMeasurable = False Then
            MsgBox("使用する地図ファイルで面積・距離測定はできない設定になっています。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim form As New frmMain_AreaPeripheri
        If form.ShowDialog(attrData) = Windows.Forms.DialogResult.OK Then
            Dim newN As Integer = attrData.Get_DataNum(Layernum)
            cboDataItem.Items.Add(attrData.Get_DataTitle(Layernum, newN - 1, True))
            MsgBox("データ項目：" + attrData.Get_DataTitle(Layernum, newN - 1, False) + " を取得しました。")
            If attrData.TotalData.LV1.Print_Mode_Total = enmTotalMode_Number.DataViewMode Then
                If attrData.LayerData(Layernum).Print_Mode_Layer = enmLayerMode_Number.SoloMode Then
                    cboDataItem.SelectedIndex = newN - 1
                End If
            End If
        End If

        form.Dispose()
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Frm_Print.IsDisposed = False Then
            clsSettings.Data.Print_PropertyWindow = Frm_Print.mnuPropertyWindow.Checked
        End If
    End Sub

    Private Sub mnuShowDataItems_Click(sender As Object, e As EventArgs) Handles mnuShowDataItems.Click
        Dim form As New frmShowDataItems
        form.ShowDialog(attrData)
        form.Dispose()
    End Sub

    Private Sub mnuCensusSmallArea_Click(sender As Object, e As EventArgs) Handles mnuCensusSmallArea.Click
        If Check_EraseSettei_OK(True) = True Then

            Dim form As New frmMED_CensusGISData
            If form.Show(True) = DialogResult.OK Then
                Dim newMap As clsMapData = form.GetResults
                Dim LayerData As New List(Of frmMain_ShowViewer.strLayerInfo)
                Dim newMapFile As String = System.IO.Path.GetFileNameWithoutExtension(newMap.Map.FileName)
                Dim MapData As New Dictionary(Of String, clsMapData)
                MapData.Add(newMapFile.ToUpper, newMap)
                Dim d As frmMain_ShowViewer.strLayerInfo
                With d
                    .Name = "国勢調査小地域データ"
                    .MapfileName = newMapFile
                    .Shape = newMap.ObjectKind(0).Shape
                    .Time = clsTime.GetNullYMD
                    ReDim .UseObjectKind(0)
                    .UseObjectKind(0) = True
                End With
                LayerData.Add(d)

                attrData = New clsAttrData(TileMap)
                attrData.SetMapViewerData(MapData, LayerData, True)
                attrData.TotalData.LV1.DataSourceType = enmDataSource.Shapefile
                man_Data = attrData.TotalData.LV1.DataSourceType
                Init_Screen_Set(False)
                initFirtScreen()
                menu_Setting()
                Me.Text = attrData.TotalData.LV1.FileName

            End If
            form.Dispose()
        End If
    End Sub


    Private Sub mnuLorenzGini_Click(sender As Object, e As EventArgs) Handles mnuLorenzGini.Click
        Dim form As New frmMain_LorenzGini
        form.ShowDialog(attrData)
        form.Dispose()
    End Sub


    Private Sub mnuAutocorrelation_Click(sender As Object, e As EventArgs) Handles mnuAutocorrelation.Click
        Dim Layernum As Integer = attrData.TotalData.LV1.SelectedLayer
        If attrData.LayerData(Layernum).Shape = enmShape.PolygonShape And attrData.LayerData(Layernum).Type <> clsAttrData.enmLayerType.Mesh Then
        Else
            MsgBox("面形状レイヤでメッシュレイヤでないレイヤでないと、この機能は使えません。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim form As New frmMain_Autocorrelation

        Dim datan As Integer = attrData.Get_DataNum(Layernum)
        form.ShowDialog(attrData)
        form.Dispose()
        Dim newDatan As Integer = attrData.Get_DataNum(Layernum)
        If datan <> newDatan Then
            For i As Integer = 0 To newDatan - datan - 1
                cboDataItem.Items.Add(attrData.Get_DataTitle(Layernum, i + datan, True))
            Next
            cboDataItem.SelectedIndex = datan
        End If
    End Sub

    Private Sub mnuScatterplot_Click(sender As Object, e As EventArgs) Handles mnuScatterplot.Click
        Dim form As New frmMain_Scatterplot
        form.ShowDialog(attrData)
        form.Dispose()
    End Sub
End Class
