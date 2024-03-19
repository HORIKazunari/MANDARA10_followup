Imports System.IO
Imports System.Xml
Public Class clsKiban
    Public Structure strKiban_Info
        Public Name As String
        Public Tag As String
        Public Shape As enmShape
        Public dataTag As List(Of String)
        Public dataTitle As List(Of String)
        Public dataUnit As List(Of String)
        Public Number As Integer
    End Structure

    Private Structure ObjData_Info
        Public ID As String
        Public Points As List(Of strLatLon)
        Public Data As String()
    End Structure
    Private Structure UseKiban_Info
        Public Objkind As Integer
        Public LineKind As Integer
    End Structure
    Dim KibanData As List(Of strKiban_Info)
    Dim KibanTag As String()
    Dim UseKibanData() As UseKiban_Info
    Dim MapData As clsMapData
    Dim ProgressBar As ProgressBar
    Public Function Get_KibanFiles(ByVal filenames As List(Of String), ByVal _Projectiona As enmProjection_Info, ByRef _ProgressBar As ProgressBar) As clsMapData

        MapData = New clsMapData()
        MapData.NoDataFlag = False
        ProgressBar = _ProgressBar
        With MapData
            With .Map
                .FileName = System.IO.Path.GetFileName(filenames(0))
                .FullPath = ""
                With .Zahyo
                    .System = enmZahyo_System_Info.Zahyo_System_World
                    .Mode = enmZahyo_mode_info.Zahyo_Ido_Keido
                    .Projection = _Projectiona
                    .CenterXY.X = 135
                    .CenterXY.Y = 0
                End With
            End With
            ReDim .MPObj(100)
            ReDim .MPLine(0)
        End With
        ProgressBar.Visible = True
        ProgressBar.Maximum = filenames.Count + 1
        Dim MP As String = "基盤地図情報" + vbCrLf
        For i As Integer = 0 To filenames.Count - 1
            ProgressBar.Value = i
            Dim ObjData As New List(Of ObjData_Info)
            Dim f As Boolean = openKibanXML(filenames(i), ObjData)
            If f = True Then
                Dim f2 As Boolean = addMapData(filenames(i), ObjData)
                If f2 = True Then
                    MP += System.IO.Path.GetFileName(filenames(i)) + vbCrLf
                Else
                    Exit For
                End If
            Else
                Exit For
            End If
        Next
        MapData.Map.Comment = MP
        MapData.Check_ALl_Line_Connect()
        MapData.Checl_All_Line_Maxmin()
        MapData.MapLatLon_Zahyo_convert()
        MapData.init_Compass_First()
        ProgressBar.Visible = False

        Return MapData
    End Function
    Private Function addMapData(ByVal FileName As String, ByRef ObjData As List(Of ObjData_Info)) As Boolean
        Dim RefKibanType As strKiban_Info = GetKibanType(FileName)
        Dim ObkNum As Integer
        Dim LkNum As Integer
        If UseKibanData(RefKibanType.Number).Objkind = -1 Then
            ObkNum = MapData.Map.OBKNum
            LkNum = MapData.Map.LpNum
            UseKibanData(RefKibanType.Number).Objkind = ObkNum
            UseKibanData(RefKibanType.Number).LineKind = LkNum
            With MapData
                .Add_OneObjectGroup_Parameter(RefKibanType.Name, RefKibanType.Shape, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
                If RefKibanType.Shape <> enmShape.PointShape Then
                    .Add_OneLineKind(RefKibanType.Name, clsBase.Line, enmMesh_Number.mhNonMesh)
                    .ObjectKind(ObkNum).UseLineType(LkNum) = True
                End If
                For i As Integer = 0 To RefKibanType.dataTag.Count - 1
                    .Add_one_DefAttDataSet(ObkNum, RefKibanType.dataTitle(i), RefKibanType.dataUnit(i), "")
                Next
            End With
        Else
            ObkNum = UseKibanData(RefKibanType.Number).Objkind
            LkNum = UseKibanData(RefKibanType.Number).LineKind
        End If
        Dim LineNum As Integer
        If RefKibanType.Shape <> enmShape.PointShape Then
            Try
                ReDim Preserve MapData.MPLine(MapData.Map.ALIN + ObjData.Count)
                LineNum = MapData.Map.ALIN
                ReDim Preserve MapData.MPObj(MapData.Map.Kend + ObjData.Count)
                MapData.Map.ALIN += ObjData.Count
            Catch ex As Exception
                MsgBox(FileName + vbCrLf + ex.Message, MsgBoxStyle.Exclamation)
                Return False
            End Try
        End If
        For i As Integer = 0 To ObjData.Count - 1
            Dim SoloData As ObjData_Info = ObjData(i)
            Dim SaveObj As clsMapData.strObj_Data = MapData.Init_One_Object(ObkNum)
            With SaveObj
                .Number = -1
                With .NameTimeSTC(0)
                    ReDim .NamesList(0)
                    .NamesList(0) = SoloData.ID
                End With
                .Shape = RefKibanType.Shape
                .NumOfCenterP = 1
                If SoloData.Data Is Nothing = False Then
                    For j As Integer = 0 To SoloData.Data.Length - 1
                        .DefTimeAttValue(j).Data(0).Value = SoloData.Data(j)
                    Next
                End If
                If RefKibanType.Shape <> enmShape.PointShape Then
                    .NumOfLine = 1
                    ReDim .LineCodeSTC(0)
                    .LineCodeSTC(0).LineCode = LineNum
                    With MapData.MPLine(LineNum)
                        .NumOfTime = 1
                        ReDim .LineTimeSTC(0)
                        .LineTimeSTC(0).Kind = LkNum
                        .LineTimeSTC(0).SETime = clsTime.GetNullStartEndYMD
                        .NumOfPoint = SoloData.Points.Count
                        ReDim .PointSTC(SoloData.Points.Count - 1)
                        For j As Integer = 0 To SoloData.Points.Count - 1
                            .PointSTC(j) = SoloData.Points(j).toPointF
                        Next
                    End With
                    LineNum += 1
                Else
                    .CenterPSTC(0).Position = SoloData.Points(0).toPointF
                End If
            End With
            MapData.Save_Object(SaveObj, False)
        Next
        Return True
    End Function
    ''' <summary>
    ''' ファイル名から、基盤地図情報の種類を取得
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetKibanType(ByVal FileName As String) As strKiban_Info
        Dim parts() As String = FileName.Split("-")
        Dim tp As String = parts(3)
        Dim idx As Integer = Array.IndexOf(KibanTag, tp)
        Return KibanData(idx)
    End Function
    ''' <summary>
    ''' 基盤地図情報のXMLファイル読み込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Function openKibanXML(ByVal FileName As String, ByRef ObjData As List(Of ObjData_Info)) As Boolean

        Dim RefKibanType As strKiban_Info = GetKibanType(FileName)
        Dim readingNodeText As String

        Dim st As New System.Xml.XmlReaderSettings
        '空白を無視する
        st.IgnoreWhitespace = True
        st.IgnoreComments = True
        Dim reader As XmlReader
        Try
            reader = XmlReader.Create(FileName, st)
            Dim SoloData As ObjData_Info
            Dim readingDataIndex As Integer
            Try
                While reader.Read()
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            Select Case reader.Name
                                Case RefKibanType.Tag
                                    If RefKibanType.dataTag.Count > 0 Then
                                        ReDim SoloData.Data(RefKibanType.dataTag.Count - 1)
                                    End If
                                    SoloData.Points = New List(Of strLatLon)
                                    readingNodeText = RefKibanType.Tag
                                Case "fid"
                                    readingNodeText = "fid"
                                Case "gml:posList"
                                    readingNodeText = "poslist"
                                Case "gml:pos"
                                    readingNodeText = "pos"
                                Case Else
                                    Dim datapos As Integer = RefKibanType.dataTag.IndexOf(reader.Name)
                                    If datapos <> -1 Then
                                        readingNodeText = "data"
                                        readingDataIndex = datapos
                                    Else
                                        readingNodeText = ""
                                    End If
                            End Select
                        Case XmlNodeType.Text
                            Select Case readingNodeText
                                Case "fid"
                                    SoloData.ID = reader.Value
                                Case "pos"
                                    Dim latlon As strLatLon = changeLatLon(reader.Value)
                                    SoloData.Points.Add(latlon)
                                Case "poslist"
                                    Dim pos() As String = reader.Value.Split(Chr(10))
                                    For i As Integer = 0 To pos.Length - 1
                                        If pos(i) <> "" Then
                                            Dim latlon As strLatLon = changeLatLon(pos(i))
                                            SoloData.Points.Add(latlon)
                                        End If
                                    Next
                                Case "data"
                                    SoloData.Data(readingDataIndex) = reader.Value
                            End Select
                        Case XmlNodeType.EndElement
                            Select Case reader.Name
                                Case RefKibanType.Tag
                                    ObjData.Add(SoloData)
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
        End Try
        reader.Close()
        Return True

    End Function
    Private Function changeLatLon(ByVal StrLatlon As String) As strLatLon
        Dim sp As String() = StrLatlon.Split(" ")
        Dim ll As strLatLon
        ll.Latitude = Val(sp(0))
        ll.Longitude = Val(sp(1))
        Return ll
    End Function
    Public Sub New()
        Dim KibanName As String() = {"行政区画", "行政区画界線", "行政区画代表点", "町字界線", "町字の代表点",
                             "街区線", "街区の代表点", "街区域",
                             "海岸線", "水崖線", "水域", "水部構造物線", "水部構造物面", "河川区域界線", "河川堤防表肩法線",
                             "建築物の外周線", "建築物",
                             "道路縁", "道路構成線", "道路域分割線", "道路域", "道路区分面", "道路区域界線", "軌道の中心線",
                            "測量の基準点", "標高点", "等高線"}
        KibanTag = {"AdmArea", "AdmBdry", "AdmPt", "CommBdry", "CommPt",
                             "SBBdry", "SBAPt", "SBArea",
                             "Cstline", "WL", "WA", "WStrL", "WStrA", "RvrMgtBdry", "LeveeEdge",
                             "BldL", "BldA",
                              "RdEdg", "RdCompt", "RdASL", "RdArea", "RdSgmtA", "RdMgtBdry", "RailCL",
                                  "GCP", "ElevPt", "Cntr"}
        Dim KibanShape As enmShape() = {enmShape.PolygonShape, enmShape.LineShape, enmShape.PointShape, enmShape.LineShape, enmShape.PointShape,
                         enmShape.LineShape, enmShape.PointShape, enmShape.PolygonShape,
                         enmShape.LineShape, enmShape.LineShape, enmShape.PolygonShape, enmShape.LineShape, enmShape.PolygonShape, enmShape.LineShape, enmShape.LineShape,
                         enmShape.LineShape, enmShape.PolygonShape,
                         enmShape.LineShape, enmShape.LineShape, enmShape.LineShape, enmShape.PolygonShape, enmShape.LineShape, enmShape.LineShape, enmShape.LineShape,
                         enmShape.PointShape, enmShape.PointShape, enmShape.LineShape}

        KibanData = New List(Of strKiban_Info)
        ReDim UseKibanData(KibanName.Length - 1)
        For i As Integer = 0 To KibanName.Length - 1
            UseKibanData(i).Objkind = -1
            Dim data As strKiban_Info
            With data
                .Name = KibanName(i)
                .Tag = KibanTag(i)
                .Shape = KibanShape(i)
                .dataTag = New List(Of String)
                .dataTitle = New List(Of String)
                .dataUnit = New List(Of String)
                .Number = i
                With .dataTag
                    Select Case i
                        Case 0 '行政区画
                            .AddRange({"type", "name", "admCode"})
                        Case 1
                            .AddRange({"type"})
                        Case 2
                            .AddRange({"type", "name", "admCode"})
                        Case 3
                            .AddRange({"type"})
                        Case 4
                            .AddRange({"type", "name", "admCode"})
                        Case 5 '街区線
                            .AddRange({})
                        Case 6
                            .AddRange({"sbaNo"})
                        Case 7
                            .AddRange({"type", "sbaNo"})
                        Case 8 '海岸線
                            .AddRange({"type", "name"})
                        Case 9 '水崖線
                            .AddRange({"type", "name"})
                        Case 10 '水域
                            .AddRange({"type", "name"})
                        Case 11 '水部構造物線
                            .AddRange({"type", "name"})
                        Case 12 '水部構造物面
                            .AddRange({"type", "name"})
                        Case 13 '河川区域界線
                            .AddRange({"name"})
                        Case 14 '河川堤防表肩法線
                            .AddRange({"name"})
                        Case 15 '建築物の外周線
                            .AddRange({"type", "name"})
                        Case 16 '建築物
                            .AddRange({"type", "name"})
                        Case 17 '道路縁
                            .AddRange({"type", "name", "admOffice"})
                        Case 18 '道路構成線
                            .AddRange({"type", "name", "admOffice"})
                        Case 19 '道路域分割線
                            .AddRange({})
                        Case 20 '道路域
                            .AddRange({"name", "admOffice"})
                        Case 21 '道路区分面
                            .AddRange({"type", "name", "admOffice"})
                        Case 22 '道路区域界線
                            .AddRange({"name"})
                        Case 23 '軌道の中心線
                            .AddRange({"type", "name"})
                        Case 24 '測量の基準点
                            .AddRange({"advNo", "orgName", "type", "gcpClass", "gcoCode", "name", "B", "L", "alti", "altiAcc"})
                        Case 25 '標高点
                            .AddRange({"type", "alti"})
                        Case 26 '等高線
                            .AddRange({"type", "alti"})
                    End Select
                End With
                For j As Integer = 0 To .dataTag.Count - 1
                    Dim tag As String = .dataTag(j)
                    Select Case tag
                        Case "type"
                            .dataTitle.Add("種別")
                            .dataUnit.Add("CAT")
                        Case "name"
                            .dataTitle.Add("名称")
                            .dataUnit.Add("STR")
                        Case "admCode"
                            .dataTitle.Add("行政コード")
                            .dataUnit.Add("STR")
                        Case "admOffice"
                            .dataTitle.Add("管理主体")
                            .dataUnit.Add("STR")
                        Case "advNo"
                            .dataTitle.Add("助言番号")
                            .dataUnit.Add("STR")
                        Case "orgName"
                            .dataTitle.Add("計画機関名")
                            .dataUnit.Add("STR")
                        Case "alti"
                            .dataTitle.Add("標高値")
                            .dataUnit.Add("m")
                        Case "gcpClass"
                            .dataTitle.Add("等級種別")
                            .dataUnit.Add("CAT")
                        Case "gcoCode"
                            .dataTitle.Add("基準点コード")
                            .dataUnit.Add("CAT")
                        Case "B"
                            .dataTitle.Add("緯度")
                            .dataUnit.Add("度")
                        Case "L"
                            .dataTitle.Add("経度")
                            .dataUnit.Add("度")
                        Case "altiAcc"
                            .dataTitle.Add("標高値有効小数桁数")
                            .dataUnit.Add("")
                        Case "sbaNo"
                            .dataTitle.Add("街区符号")
                            .dataUnit.Add("STR")
                    End Select
                Next
            End With
            KibanData.Add(data)
        Next
    End Sub
    Public Function GetKibanList() As List(Of strKiban_Info)
        Return KibanData
    End Function
End Class
