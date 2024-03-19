Imports System.IO
Imports System.Xml
Public Class clsOSM
    Private Enum ReadingElement
        node
        way
        relation
    End Enum
    Private Structure strTagInfo
        Public k As String
        Public v As String
    End Structure
    Private Structure strMemberInfo
        Public Type As String
        Public ref As String
        Public role As String
    End Structure
    Private Structure strRelationInfo
        Public id As String
        Public member As List(Of strMemberInfo)
        Public tag As List(Of strTagInfo)
    End Structure

    Private Structure strWayInfo
        Public id As String
        Public ref As List(Of String)
        Public tag As List(Of strtagInfo)
    End Structure
    Private Structure strNodeInfo
        Public id As String
        Public pos As strLatLon
        Public tag As List(Of strtagInfo)
    End Structure

    Private NodeData As List(Of strNodeInfo)
    Private WayData As List(Of strWayInfo)
    Private RelationData As List(Of strRelationInfo)
    Public Function Get_OSMFile(ByVal FileName As String, ByRef OSMMapData As clsMapData) As Boolean
        Dim MapData As New clsMapData

        NodeData = New List(Of strNodeInfo)
        WayData = New List(Of strWayInfo)
        RelationData = New List(Of strRelationInfo)
        If readOSM(FileName) = False Then
            Return False
        End If

        With MapData.Map.Zahyo
            .Mode = enmZahyo_mode_info.Zahyo_Ido_Keido
            .Projection = clsSettings.Data.default_Projection
            .System = enmZahyo_System_Info.Zahyo_System_World
        End With
        MapData.NoDataFlag = False

        Dim NodeID As New clsSortingSearch(VariantType.String)
        Dim NodeKey As New List(Of String)
        For i As Integer = 0 To NodeData.Count - 1
            NodeID.Add(NodeData(i).id)
            For j As Integer = 0 To NodeData(i).tag.Count - 1
                NodeKey.Add(NodeData(i).tag(j).k)
            Next
        Next
        NodeID.AddEnd()

        Dim s As New clsSortingSearch()
        s.AddRange(NodeKey.Count, NodeKey.ToArray)
        Dim NodeKeyPat_pre() As String
        Dim NodekeyValueN As Integer = s.getEachValue_Alley(NodeKeyPat_pre)
        Dim NodeKeyPat_pre2(NodekeyValueN - 1) As String
        For i As Integer = 0 To NodekeyValueN - 1
            NodeKeyPat_pre2(i) = UCase(NodeKeyPat_pre(i))
        Next
        Dim sNodeKeyNum As New clsSortingSearch()
        Dim NodeKeyPat(NodekeyValueN - 1) As String
        sNodeKeyNum.AddRange(NodekeyValueN, NodeKeyPat_pre2)
        For i As Integer = 0 To NodekeyValueN - 1
            NodeKeyPat(i) = NodeKeyPat_pre(sNodeKeyNum.DataPosition(i))
        Next
        Dim sNodeSearach As New clsSortingSearch()
        sNodeSearach.AddRange(NodekeyValueN, NodeKeyPat)

        'wayのキー要素のソート
        Dim wayKey As New List(Of String)
        For i As Integer = 0 To WayData.Count - 1
            For j As Integer = 0 To WayData(i).tag.Count - 1
                wayKey.Add(WayData(i).tag(j).k)
            Next
        Next

        Dim s2 As New clsSortingSearch()
        s2.AddRange(wayKey.Count, wayKey.ToArray)
        Dim WayKeyPat_pre() As String
        Dim WaykeyValueN As Integer = s2.getEachValue_Alley(WayKeyPat_pre)
        Dim WayKeyPat_pre2(WaykeyValueN - 1) As String
        For i As Integer = 0 To WaykeyValueN - 1
            WayKeyPat_pre2(i) = UCase(WayKeyPat_pre(i))
        Next
        Dim sWayKeyNum As New clsSortingSearch()
        sWayKeyNum.AddRange(WaykeyValueN, WayKeyPat_pre2)
        Dim WayKeyPat(WaykeyValueN - 1) As String
        For i As Integer = 0 To WaykeyValueN - 1
            WayKeyPat(i) = WayKeyPat_pre(sWayKeyNum.DataPosition(i))
        Next
        Dim sWaySearach As New clsSortingSearch()
        sWaySearach.AddRange(WaykeyValueN, WayKeyPat)


        With MapData.Map
            .FileName = System.IO.Path.GetFileName(FileName)
            .FullPath = FileName
            .Comment = "オープンストリートマップデータファイル" + vbCrLf + .FileName + vbCrLf
            .OBKNum = 0
            .Kend = 0
            .LpNum = 0
            .ALIN = 0
        End With
        With MapData
            'オブジェクトグループと線種
            .Add_OneLineKind("オープンストリートマップデータ", clsBase.Line, enmMesh_Number.mhNonMesh)
            .Add_OneObjectGroup_Parameter("オープンストリートマップデータ点", enmShape.PointShape, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
            .Add_OneObjectGroup_Parameter("オープンストリートマップデータ線", enmShape.LineShape, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
            .Add_OneObjectGroup_Parameter("オープンストリートマップデータ面", enmShape.PolygonShape, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
            For k As Integer = 0 To 2
                .ObjectKind(k).Color = MapData.Set_First_ObjectKind_Color_Solo(k)
                Dim n As Integer
                Select Case k
                    Case 0
                        n = NodekeyValueN + 1
                    Case 1, 2
                        n = WaykeyValueN + 1
                        .ObjectKind(k).UseLineType(0) = True
                End Select
                .ObjectKind(k).DefTimeAttDataNum = n
                ReDim .ObjectKind(k).DefTimeAttSTC(n - 1)
                With .ObjectKind(k).DefTimeAttSTC(0)
                    .attData.Title = "形状"
                    .attData.Unit = "CAT"
                    .attData.MissingF = False
                    .attData.AttDataType = enmAttDataType.Category
                End With
                For i As Integer = 0 To n - 2
                    With .ObjectKind(k).DefTimeAttSTC(i + 1)
                        .Type = clsMapData.enmDefTimeAttDataType.SpanData
                        .ExtraValue = clsMapData.enmDefPointAttDataExtraValue.MissingValue

                        Dim ttl As String
                        Select Case k
                            Case 0
                                ttl = NodeKeyPat(i)
                            Case 1, 2
                                ttl = WayKeyPat(i)
                        End Select
                        With .attData
                            .MissingF = False
                            .Note = ""
                            .AttDataType = enmAttDataType.Strings
                            .Title = ttl
                            .Unit = "str"
                        End With
                    End With
                Next
            Next
        End With

        'ノードデータでTAGが入っている場合は点オブジェクト
        For i As Integer = 0 To NodeData.Count - 1
            With NodeData(i)
                If .tag.Count > 0 Then
                    Dim n As Integer = MapData.Map.Kend
                    MapData.Add_OnePointObject(0, {"P" + .id}, .pos.toPointF)
                    MapData.MPObj(n).DefTimeAttValue(0).Data(0).Value = clsGeneric.ConvertShapeEnumString(enmShape.PointShape)
                    For j As Integer = 0 To .tag.Count - 1
                        Dim ks As String = .tag(j).k
                        Dim pos As Integer = sNodeSearach.SearchData_One(ks)
                        MapData.MPObj(n).DefTimeAttValue(pos + 1).Data(0).Value = .tag(j).v
                    Next
                End If
            End With
        Next

        ReDim MapData.MPLine(WayData.Count - 1)
        MapData.Map.ALIN = WayData.Count
        ReDim Preserve MapData.MPObj(MapData.Map.Kend + WayData.Count - 1)
        For i As Integer = 0 To WayData.Count - 1
            With WayData(i)
                Dim np As Integer = .ref.Count
                Dim PTS(np - 1) As PointF
                Dim n As Integer = 0
                For j As Integer = 0 To np - 1
                    Dim idpos As Integer = NodeID.SearchData_One(.ref(j))
                    If idpos <> -1 Then
                        PTS(n) = NodeData(idpos).pos.toPointF
                        n += 1
                    End If
                Next
                ReDim Preserve PTS(n - 1)
                MapData.MPLine(i) = MapData.Init_One_Line(0)
                With MapData.MPLine(i)
                    .Number = 0
                    .NumOfPoint = n
                    .PointSTC = PTS.Clone
                End With

                Dim kenn As Integer = MapData.Map.Kend + i
                MapData.MPObj(kenn) = MapData.Init_One_Object(1)
                With MapData.MPObj(kenn)
                    Dim Line As clsMapData.strLine_Data = MapData.MPLine(i)
                    Dim obk As Integer = 1
                    With Line
                        If .PointSTC(0).Equals(.PointSTC(.NumOfPoint - 1)) = True Then
                            obk = 2
                        End If
                    End With
                    .Number = kenn
                    .Kind = obk
                    .Shape = MapData.ObjectKind(obk).Shape
                    If obk = 1 Then
                        .NameTimeSTC(0).NamesList(0) = "W" + WayData(i).id
                    Else
                        .NameTimeSTC(0).NamesList(0) = "W" + WayData(i).id
                    End If
                    .NumOfLine = 1
                    ReDim .LineCodeSTC(0)
                    With .LineCodeSTC(0)
                        .NumOfTime = 0
                        .LineCode = i
                    End With
                    .CenterPSTC(0).Position = Line.PointSTC(MapData.MPLine(i).NumOfPoint \ 2)
                    .DefTimeAttValue(0).Data(0).Value = clsGeneric.ConvertShapeEnumString(.Shape)
                End With
                For j As Integer = 0 To .tag.Count - 1
                    Dim ks As String = .tag(j).k
                    Dim pos As Integer = sWaySearach.SearchData_One(ks)
                    MapData.MPObj(kenn).DefTimeAttValue(pos + 1).Data(0).Value = .tag(j).v
                Next
            End With

        Next
        MapData.Map.Kend += WayData.Count

        MapData.MapLatLon_Zahyo_convert()
        MapData.init_Compass_First()
        OSMMapData = MapData
        Return True
    End Function

    Private Function readOSM(ByVal FileName As String) As Boolean
        Dim st As New System.Xml.XmlReaderSettings
        '空白を無視する
        st.IgnoreWhitespace = True
        st.IgnoreComments = True
        Dim readingNodeText As ReadingElement
        NodeData = New List(Of strNodeInfo)
        Dim NodeElement As strNodeInfo
        Dim WayElement As strWayInfo
        Dim RelationElement As strRelationInfo
        Dim nodeStart As Boolean
        Try
            Dim reader As XmlReader = XmlReader.Create(FileName, st)
            Try
                While reader.Read()
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            Select Case reader.Name
                                Case "node"
                                    If nodeStart = True Then
                                        NodeData.Add(NodeElement)
                                    End If
                                    readingNodeText = ReadingElement.node
                                    Dim a As String = reader.GetAttribute("/")
                                    NodeElement.id = reader.GetAttribute("id")
                                    NodeElement.pos.Longitude = Val(reader.GetAttribute("lon"))
                                    NodeElement.pos.Latitude = Val(reader.GetAttribute("lat"))
                                    NodeElement.tag = New List(Of strTagInfo)
                                    nodeStart = True
                                Case "way"
                                    readingNodeText = ReadingElement.way
                                    WayElement.id = reader.GetAttribute("id")
                                    WayElement.tag = New List(Of strTagInfo)
                                    WayElement.ref = New List(Of String)
                                Case "relation"
                                    readingNodeText = ReadingElement.relation
                                    RelationElement.id = reader.GetAttribute("id")
                                    RelationElement.tag = New List(Of strTagInfo)
                                    RelationElement.member = New List(Of strMemberInfo)
                                Case "nd"
                                    If readingNodeText = ReadingElement.way Then
                                        Dim r As String = reader.GetAttribute("ref")
                                        If r Is Nothing = False Then
                                            WayElement.ref.Add(r)
                                        End If
                                    End If
                                Case "tag"
                                    Dim tagvk As strTagInfo
                                    tagvk.v = reader.GetAttribute("v")
                                    tagvk.k = reader.GetAttribute("k")
                                    Select Case readingNodeText
                                        Case ReadingElement.node
                                            NodeElement.tag.Add(tagvk)
                                        Case ReadingElement.way
                                            WayElement.tag.Add(tagvk)
                                        Case ReadingElement.relation
                                            RelationElement.tag.Add(tagvk)
                                    End Select

                                Case "member"
                                    Dim m As strMemberInfo
                                    m.ref = reader.GetAttribute("ref")
                                    m.role = reader.GetAttribute("role")
                                    m.Type = reader.GetAttribute("type")
                                    RelationElement.member.Add(m)
                            End Select
                        Case XmlNodeType.Text
                        Case XmlNodeType.EndElement
                            Select Case reader.Name
                                Case "node"
                                    NodeData.Add(NodeElement)
                                    nodeStart = False
                                Case "way"
                                    WayData.Add(WayElement)
                                Case "relation"
                                    RelationData.Add(RelationElement)
                            End Select
                    End Select
                End While
                If nodeStart = True Then
                    NodeData.Add(NodeElement)
                End If
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
        Return True
    End Function
End Class
