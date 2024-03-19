Imports System.IO
Imports System.Xml
Public Class clsKML
    Private Enum ReadingUpperElement
        document
        folder
        placemark
    End Enum
    Private Enum ReadingElement
        folder
        placemark
        name
        description
        coordinates
        Polygon
        LineString
        Point
        data
        other
        style
        styleUrl
        LineStyle
        color
        width
        PolyStyle
        fill
        outline
    End Enum
    Private Structure lineCoords
        Public Pxy() As PointF
    End Structure
    Private Structure propertData
        Public Title As String
        Public Value As String
    End Structure
    Private Structure KmlLineStyle_Info
        Public color As String
        Public Width As Integer
    End Structure
    Private Structure KmlPolyStyle_Info
        Public color As String
        Public fill As Boolean
        Public outline As Boolean
    End Structure

    Private Structure Placemark_Info
        Public name As String
        Public description As String
        Public Folder As String
        Public shape As enmShape
        Public styleUrl As String
        Public numofLine As Integer
        Public linePoint() As lineCoords
        Public LineStyle As KmlLineStyle_Info
        Public PolyStyle As KmlPolyStyle_Info
        Public data() As propertData
        Public Obk As Integer
        Public DataIndex() As Integer
    End Structure
    Private Structure Style_Info
        Public ID As String
        Public LineStyle As KmlLineStyle_Info
        Public PolyStyle As KmlPolyStyle_Info
    End Structure
    Private ObjData As New ArrayList
    Private StyleData As New ArrayList
    Public Function Get_KMLFile(ByVal FileName As String, ByRef KMLMapData As clsMapData) As Boolean
        Dim MapData As New clsMapData
        If readKML(FileName) = False Then
            Return False
        End If
        With MapData.Map.Zahyo
            .Mode = enmZahyo_mode_info.Zahyo_Ido_Keido
            .Projection = clsSettings.Data.default_Projection
            .System = enmZahyo_System_Info.Zahyo_System_World
        End With
        MapData.NoDataFlag = False

        Dim objNameHeader = Path.GetFileNameWithoutExtension(FileName) + "."
        Dim FolderList As New ArrayList
        Dim FolderShape As New ArrayList
        Dim DataTitle As New ArrayList
        'オブジェクトグループ数
        For i As Integer = 0 To ObjData.Count - 1
            Dim Obj As Placemark_Info = CType(ObjData.Item(i), Placemark_Info)
            Obj.Obk = FolderList.IndexOf(Obj.Folder)
            If Obj.Obk = -1 Then
                FolderList.Add(Obj.Folder)
                FolderShape.Add(Obj.shape)
                Obj.Obk = FolderList.Count - 1
            End If
            ObjData.Item(i) = Obj
        Next
        With MapData.Map
            .FileName = System.IO.Path.GetFileName(FileName)
            .FullPath = FileName
            .Comment = "KMLファイル" + vbCrLf + .FileName + vbCrLf
            .OBKNum = FolderList.Count
            .Kend = ObjData.Count
            .LpNum = .Kend
            .ALIN = 0
        End With
        With MapData
            'オブジェクトグループと線種
            ReDim .ObjectKind(.Map.OBKNum - 1)
            ReDim .LineKind(.Map.OBKNum - 1)
            For i As Integer = 0 To .Map.OBKNum - 1
                Dim name As String = objNameHeader + FolderList.Item(i)
                .ObjectKind(i) = MapData.Get_OneObjectGroup_Parameter(name, FolderShape.Item(i), i, MapData.Map.OBKNum, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
                .ObjectKind(i).UseLineType(i) = True
                .LineKind(i) = MapData.Get_OneLineKind_Parameter(name, clsBase.Line, enmMesh_Number.mhNonMesh)
            Next
            'オブジェクトグループの初期属性の設定
            For i As Integer = 0 To ObjData.Count - 1
                Dim Obj As Placemark_Info = CType(ObjData.Item(i), Placemark_Info)
                If Obj.data Is Nothing = False Then
                    Dim obk = Obj.Obk
                    ReDim Obj.dataIndex(Obj.data.Length - 1)
                    For j As Integer = 0 To Obj.data.Length - 1
                        Dim f As Boolean = False
                        Dim dan As Integer = .ObjectKind(obk).DefTimeAttDataNum
                        For k As Integer = 0 To dan - 1
                            If .ObjectKind(obk).DefTimeAttSTC(k).attData.Title = Obj.data(j).Title Then
                                Obj.DataIndex(j) = k
                                f = True
                                Exit For
                            End If
                        Next
                        If f = False Then
                            With .ObjectKind(obk)
                                ReDim Preserve .DefTimeAttSTC(dan)
                                .DefTimeAttSTC(dan).attData.Title = Obj.data(j).Title
                                .DefTimeAttSTC(dan).attData.Unit = "STR"
                                Obj.DataIndex(j) = dan
                                .DefTimeAttDataNum += 1
                            End With
                        End If
                    Next
                End If
                ObjData.Item(i) = Obj
            Next

            'オブジェクトの設定
            ReDim .MPObj(.Map.Kend - 1)
            ReDim .MPLine(.Map.Kend - 1)
            Dim objn As Integer = 0
            Dim linen As Integer = 0
            For Each Obj As Placemark_Info In ObjData
                Dim obk As Integer = Obj.Obk
                .MPObj(objn) = MapData.Init_One_Object(obk)
                With .MPObj(objn)
                    If Obj.data Is Nothing = False Then
                        For i As Integer = 0 To Obj.data.Length - 1
                            .DefTimeAttValue(Obj.DataIndex(i)).Data(0).Value = Obj.data(i).Value
                        Next
                    End If
                    .Number = objn
                    .Kind = obk
                    .Shape = Obj.shape
                    .NameTimeSTC(0).NamesList(0) = objNameHeader + Obj.name
                    If MapData.ObjectKind(obk).Shape = enmShape.LineShape Or MapData.ObjectKind(obk).Shape = enmShape.PolygonShape Then
                        .NumOfLine = Obj.numofLine
                        If UBound(MapData.MPLine) < linen + Obj.numofLine Then
                            ReDim Preserve MapData.MPLine((linen + Obj.numofLine) * 2)
                        End If
                        ReDim .LineCodeSTC(.NumOfLine - 1)
                        For i As Integer = 0 To Obj.numofLine - 1
                            With .LineCodeSTC(i)
                                .LineCode = linen + i
                                .NumOfTime = 0
                            End With
                            MapData.MPLine(linen + i) = MapData.Init_One_Line(obk)
                            With MapData.MPLine(linen + i)
                                .Number = linen + i
                                .NumOfPoint = Obj.linePoint(i).Pxy.Length
                                .PointSTC = Obj.linePoint(i).Pxy.Clone
                            End With
                        Next
                        linen += Obj.numofLine
                    End If
                    Select Case Obj.shape
                        Case enmShape.PointShape
                            .CenterPSTC(0).Position = Obj.linePoint(0).Pxy(0)
                        Case Else
                            .CenterPSTC(0).Position = Obj.linePoint(Obj.numofLine \ 2).Pxy(Obj.linePoint(Obj.numofLine \ 2).Pxy.Length \ 2)
                    End Select
                End With
                objn += 1
            Next
            .Map.ALIN = linen
            For i As Integer = 0 To .Map.OBKNum - 1
                .ObjectKind(i).Color = MapData.Set_First_ObjectKind_Color_Solo(i)
            Next
        End With
        MapData.Erase_Non_Use_Linekind()
        If MapData.Map.LpNum = 0 Then
            MapData.Add_OneLineKind("新規1", clsBase.Line, enmMesh_Number.mhNonMesh)
        End If
        MapData.MapLatLon_Zahyo_convert()
        MapData.init_Compass_First()
        KMLMapData = MapData
        Return True
    End Function
    ''' <summary>
    ''' KMLの色文字列をcolor型に変換
    ''' </summary>
    ''' <param name="KMLcolor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertKMLcolorToColor(ByVal KMLcolor As String) As Color
        Dim a As Integer = Convert.ToInt32(Mid(KMLcolor, 1, 2), 16)
        Dim b As Integer = Convert.ToInt32(Mid(KMLcolor, 3, 2), 16)
        Dim g As Integer = Convert.ToInt32(Mid(KMLcolor, 5, 2), 16)
        Dim r As Integer = Convert.ToInt32(Mid(KMLcolor, 7, 2), 16)
        Dim col As Color = Color.FromArgb(a, r, g, b)
        Return col
    End Function
    Private Function readKML(ByVal FileName As String) As Boolean

        Dim readType As Integer = -1
        Dim readingNodeText As ReadingElement
        Dim readingUpperNodeText As ReadingUpperElement
        Dim FolderName As New ArrayList
        Dim st As New System.Xml.XmlReaderSettings
        '空白を無視する
        st.IgnoreWhitespace = True
        st.IgnoreComments = True
        Dim placemark_f As Boolean = False
        Dim placemark_n As Integer = 0
        Dim LinePropertyData As KmlLineStyle_Info
        Dim PolyStyleTmp As KmlPolyStyle_Info
        Dim LineStyleF As Boolean = False
        Dim PolyStyleF As Boolean = False
        Dim PolyStyleDefault As KmlPolyStyle_Info

        Dim ext As String = System.IO.Path.GetExtension(FileName).ToUpper
        Dim kmzFolder As String = ""

        If ext = ".KMZ" Then
            kmzFolder = clsGeneric.MakeTempFolder()
            If kmzFolder = "" Then
                Return False
            Else
                System.IO.Compression.ZipFile.ExtractToDirectory(FileName, kmzFolder)
                Dim files As String() = System.IO.Directory.GetFiles(kmzFolder, "*.kml")
                FileName = files(0)
            End If
        End If
        With PolyStyleDefault
            .color = "ffffffff"
            .fill = True
            .outline = True
        End With
        Try
            Dim reader As XmlReader = XmlReader.Create(FileName, st)
            Dim PlacemarkData As Placemark_Info
            Dim StyleTmpData As Style_Info
            Try
                While reader.Read()
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            Select Case reader.Name
                                Case "Document"
                                    readingUpperNodeText = ReadingUpperElement.document
                                    FolderName.Add(FolderName.Count.ToString)
                                Case "Folder"
                                    readingNodeText = ReadingElement.folder
                                    readingUpperNodeText = ReadingUpperElement.folder
                                    FolderName.Add(FolderName.Count.ToString)
                                Case "Style"
                                    If placemark_f = False Then
                                        readingNodeText = ReadingElement.style
                                        reader.MoveToAttribute("id")
                                        With StyleTmpData
                                            .ID = reader.Value
                                            .LineStyle.color = "ffffffff"
                                            .LineStyle.Width = 2
                                            .PolyStyle = PolyStyleDefault
                                        End With
                                        reader.MoveToElement()
                                    End If
                                Case "LineStyle"
                                    readingNodeText = ReadingElement.LineStyle
                                    LinePropertyData.color = "ffffffff"
                                    LinePropertyData.Width = 2
                                    LineStyleF = True
                                Case "PolyStyle"
                                    readingNodeText = ReadingElement.PolyStyle
                                    PolyStyleTmp = PolyStyleDefault
                                    PolyStyleF = True
                                Case "color"
                                    If LineStyleF = True Or PolyStyleF = True Then
                                        readingNodeText = ReadingElement.color
                                    End If
                                Case "width"
                                    If LineStyleF = True Then
                                        readingNodeText = ReadingElement.width
                                    End If
                                Case "fill"
                                    If PolyStyleF = True Then
                                        readingNodeText = ReadingElement.fill
                                    End If
                                Case "outline"
                                    If PolyStyleF = True Then
                                        readingNodeText = ReadingElement.outline
                                    End If
                                Case "Placemark"
                                    placemark_f = True
                                    PlacemarkData.name = placemark_n.ToString
                                    PlacemarkData.Folder = ""
                                    For Each Fname As String In FolderName
                                        PlacemarkData.Folder += Fname + "."
                                    Next
                                    PlacemarkData.Folder = PlacemarkData.Folder.Trim(".")
                                    PlacemarkData.shape = enmShape.NotDeffinition
                                    PlacemarkData.styleUrl = ""
                                    PlacemarkData.numofLine = 0
                                    PlacemarkData.LineStyle.color = "ffffffff"
                                    PlacemarkData.LineStyle.Width = 2
                                    PlacemarkData.PolyStyle = PolyStyleDefault
                                    ReDim PlacemarkData.linePoint(0)
                                    readingNodeText = ReadingElement.placemark
                                    readingUpperNodeText = ReadingUpperElement.placemark
                                    If PlacemarkData.data Is Nothing = False Then
                                        Erase PlacemarkData.data
                                    End If
                                    placemark_n += 1
                                Case "styleUrl"
                                    readingNodeText = ReadingElement.styleUrl
                                Case "Polygon"
                                    PlacemarkData.shape = enmShape.PolygonShape
                                    readingNodeText = ReadingElement.Polygon
                                Case "LineString"
                                    PlacemarkData.shape = enmShape.LineShape
                                    readingNodeText = ReadingElement.LineString
                                Case "Point"
                                    PlacemarkData.shape = enmShape.PointShape
                                    readingNodeText = ReadingElement.Point
                                Case "coordinates"
                                    readingNodeText = ReadingElement.coordinates
                                Case "name"
                                    readingNodeText = ReadingElement.name
                                Case "description"
                                    readingNodeText = ReadingElement.description
                                Case "SimpleData", "Data"
                                    If PlacemarkData.data Is Nothing = True Then
                                        ReDim PlacemarkData.data(0)
                                    Else
                                        ReDim Preserve PlacemarkData.data(PlacemarkData.data.Length)
                                    End If
                                    Dim n As Integer = PlacemarkData.data.Length - 1
                                    If reader.MoveToFirstAttribute() Then
                                        Do
                                            If reader.Name = "name" Then
                                                PlacemarkData.data(n).Title = reader.Value
                                            End If
                                        Loop Until (Not reader.MoveToNextAttribute())
                                    End If
                                    readingNodeText = ReadingElement.data
                                Case Else
                                    readingNodeText = ReadingElement.other
                            End Select
                        Case XmlNodeType.Text
                            Select Case readingNodeText
                                Case ReadingElement.styleUrl
                                    PlacemarkData.styleUrl = reader.Value
                                Case ReadingElement.color
                                    If LineStyleF = True Then
                                        LinePropertyData.color = reader.Value
                                    Else
                                        PolyStyleTmp.color = reader.Value
                                    End If
                                Case ReadingElement.width
                                    LinePropertyData.Width = Val(reader.Value)
                                Case ReadingElement.fill
                                    PolyStyleTmp.fill = Val(reader.Value)
                                Case ReadingElement.outline
                                    PolyStyleTmp.outline = Val(reader.Value)
                                Case ReadingElement.coordinates
                                    Dim data As String = reader.Value.Replace(vbLf, vbCr)
                                    data = data.Replace(vbTab, "")
                                    data = data.Replace(" ", vbCr)
                                    data = clsGeneric.RemoveConsecStrings(data, vbCr)

                                    data = data.Trim(New Char() {ControlChars.Cr})
                                    Dim spCoord() As String = data.Split(vbCr)
                                    ReDim Preserve PlacemarkData.linePoint(PlacemarkData.numofLine)
                                    Select Case PlacemarkData.shape
                                        Case enmShape.LineShape, enmShape.PolygonShape
                                            Dim pointN As Integer = spCoord.Length
                                            ReDim PlacemarkData.linePoint(PlacemarkData.numofLine).Pxy(pointN - 1)
                                            For i As Integer = 0 To pointN - 1
                                                Dim xy() As String = spCoord(i).Split(",")
                                                If xy.Length >= 2 Then
                                                    With PlacemarkData.linePoint(PlacemarkData.numofLine).Pxy(i)
                                                        .X = Val(xy(0))
                                                        .Y = Val(xy(1))
                                                    End With
                                                End If
                                            Next
                                            PlacemarkData.numofLine += 1
                                        Case enmShape.PointShape
                                            ReDim PlacemarkData.linePoint(PlacemarkData.numofLine).Pxy(0)
                                            Dim xy() As String = reader.Value.Split(",")
                                            With PlacemarkData.linePoint(PlacemarkData.numofLine).Pxy(0)
                                                .X = Val(xy(0))
                                                .Y = Val(xy(1))
                                            End With
                                    End Select
                                Case ReadingElement.data
                                    Dim n As Integer = PlacemarkData.data.Length - 1
                                    PlacemarkData.data(n).Value = reader.Value
                                Case ReadingElement.name
                                    Select Case readingUpperNodeText
                                        Case ReadingUpperElement.placemark
                                            Dim header As String = ""
                                            For i As Integer = 0 To FolderName.Count - 1
                                                header += FolderName.Item(i) + "."
                                            Next
                                            PlacemarkData.name = header + reader.Value
                                        Case ReadingUpperElement.folder, ReadingUpperElement.document
                                            FolderName.Item(FolderName.Count - 1) = reader.Value
                                    End Select
                                Case ReadingElement.description
                                    Dim n As Integer = 0
                                    If PlacemarkData.data Is Nothing = True Then
                                        ReDim PlacemarkData.data(0)
                                    Else
                                        n = PlacemarkData.data.Length
                                        ReDim Preserve PlacemarkData.data(n)
                                    End If
                                    PlacemarkData.data(n).Title = "description"
                                    PlacemarkData.data(n).Value = reader.Value
                                Case ReadingElement.other
                            End Select
                        Case XmlNodeType.EndElement
                            Select Case reader.Name
                                Case "Placemark"
                                    ObjData.Add(PlacemarkData)
                                    placemark_f = False
                                Case "Folder", "Document"
                                    FolderName.RemoveAt(FolderName.Count - 1)
                                Case "Style"
                                    If placemark_f = False Then
                                        StyleData.Add(StyleTmpData)
                                    End If
                                Case "LineStyle"
                                    If placemark_f = True Then
                                        PlacemarkData.LineStyle = LinePropertyData
                                    Else
                                        StyleTmpData.LineStyle = LinePropertyData
                                    End If
                                    LineStyleF = False
                                Case "PolyStyle"
                                    If placemark_f = True Then
                                        PlacemarkData.PolyStyle = PolyStyleTmp
                                    Else
                                        StyleTmpData.PolyStyle = PolyStyleTmp
                                    End If
                                    PolyStyleF = False
                            End Select
                    End Select
                End While
            Catch ex As XmlException
                MsgBox(ex.ToString())
                Return False
            Finally
                reader.Close()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            If ext = ".KMZ" Then
                System.IO.Directory.Delete(kmzFolder, True)
            End If
        End Try

        Return True
    End Function
End Class
