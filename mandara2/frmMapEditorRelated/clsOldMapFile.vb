Public Class clsOldMapFile

    Private Structure Obj_Data_10 'オブジェクト（地図データ）
        Public Kind As Integer
        Public NumOfNameTime As Integer
        Public NumOfCenterP As Integer
        Public NumOfSuc As Integer
        Public NumOfLine As Integer
        Public NameTimeStac As Integer
        Public CenterPStac As Integer
        Public SucStac As Integer
        Public LineStac As Integer
        Public Shape As Short
        Public Edited As Boolean
        Public Circumscribed_Rectangle As clsVB6File.Box_Data_single_v11
    End Structure

    Private Structure ObjectKind_Data_9
        Public Name As String
        Public Shape As Short
        Public Color As Integer
        Public Edited As Boolean
    End Structure

    Private Structure ObjectKind_Data_10
        Public Name As String
        Public Shape As Short
        Public Mesh As Integer
        Public Color As Integer
        Public Edited As Boolean
    End Structure
    Private Structure map_data_9
        Public OBKNum As Integer
        Public Kend As Integer
        Public NameTimeStacNum As Integer
        Public CenterPointStacNum As Integer
        Public SucStacNum As Integer
        Public LCPO As Integer
        Public LineTimeStacNum As Integer
        Public LpNum As Integer
        Public ALIN As Integer
        Public AP As Integer
        Public CompD As Single
        Public SCL As Single
        Public SCL_U As String
        Public Comment As String
        Public Time_Mode As Boolean
    End Structure

    Private Structure map_data_10
        Public OBKNum As Integer
        Public Kend As Integer
        Public NameTimeStacNum As Integer
        Public CenterPointStacNum As Integer
        Public SucStacNum As Integer
        Public LCPO As Integer
        Public LineTimeStacNum As Integer
        Public LpNum As Integer
        Public ALIN As Integer
        Public AP As Integer
        Public CompD As Single
        Public SCL As Single
        Public SCL_U As String
        Public Comment As String
        Public Time_Mode As Boolean
        Public Circumscribed_Rectangle As clsVB6File.Box_Data_single_v11 '地図の外接四角形
        Public Zahyo As Zahyo_info_v11
    End Structure

    Private Structure Line_Data10 'ラインデータ（地図データ）
        Public NumOfPoint As Integer
        Public PointStac As Integer
        Public Connect As Short
        Public NumOfLineUse As Integer
        Public Circumscribed_Rectangle As clsVB6File.Box_Data_single_v11
        Public NumOfTime As Integer
        Public TimeStac As Integer
        Public Edited As Boolean
        Public Drawn As Boolean
    End Structure
    Private Structure LineKind_Data_10  '線種名とパターン（地図データ）
        Public Name As String
        Public Pat As clsVB6File.Line_Property_v11
        Public Mesh As Integer
        Public Edited As Boolean
    End Structure
    Private Structure LineKind_Data_9  '線種名とパターン（地図データ）
        Public Name As String
        Public Pat As clsVB6File.Line_Property_v11
        Public Edited As Boolean
    End Structure

    Private Structure LineCodeStac_Data_10  'ラインコードスタック（地図データ）
        Public LineCode As Integer
        Public NumOfTime As Integer
        Public Times As String
    End Structure



    Private Structure Zahyo_info_v11
        Public Mode As Integer '緯度経度か、平面直角か
        Public System As Integer '世界測地系か、日本測地系か
        Public HeimenTyokkaku_KEI_Number As Short  '1-19の値
        Public Projection As Integer '投影法
        Public CenterXY As clsVB6File.SingleXY_v1275  '緯度経度の中心
    End Structure
    Private Structure map_data_v11
        Public OBKNum As Integer
        Public Kend As Integer
        Public LpNum As Integer
        Public ALIN As Integer
        Public CompD As Single
        Public SCL As Single
        Public SCL_U As String
        Public Comment As String
        Public Time_Mode As Boolean
        Public Circumscribed_Rectangle As clsVB6File.Box_Data_single_v11 '地図の外接四角形
        Public Zahyo As Zahyo_info_v11
    End Structure
 
    Private Structure Map_Detail_Data_v11
        Public Distance As Integer
        Public Direction As Integer
    End Structure
    Public Structure MPObjDefAttData_Info_v11 '初期属性データ（地図データ）
        Public title As String
        Public Unit As String
    End Structure
    Public Structure ObjectKind_Data_v11 'オブジェクトグループデータ（地図データ）
        Public ObjectType As Integer 'ObjectGoupType_Dataの内容
        Public Name As String
        Public Shape As Short
        Public Mesh As Integer
        Public Color As Integer
        Public Edited As Boolean
        Public DefAttDataNum As Integer
        Public DefAttSTC() As MPObjDefAttData_Info_v11
        Public UseLineType() As Boolean 'NormalObjectで使用
        Public UseObjectGroup() As Boolean 'AggregationObjectで使用するオブジェクトグループ
    End Structure
    Private Structure Object_Succession_Data_v11 'オブジェクト継承データ（地図データ）
        Public ObjectCode As Integer
        Public Time As Integer
    End Structure
    Private Structure Object_NameTimeStac_Data_v11 'オブジェクト名スタック（地図データ）
        Public Name1 As String
        Public Name2 As String
        Public StartTime As Integer
        Public EndTime As Integer
    End Structure
    Private Structure Object_CenterPoint_Data_v11 'オブジェクト代表点（地図データ）
        Public X As Single
        Public Y As Single
        Public StartTime As Integer
        Public EndTime As Integer
    End Structure
    Private Structure Start_End_Time_data_v11
        Public StartTime As Integer
        Public EndTime As Integer
    End Structure

    Private Structure LineCodeStac_Data_v11  'ラインコードスタック（地図データ）
        Public LineCode As Integer
        Public NumOfTime As Integer
        Public Times() As Start_End_Time_data_v11
    End Structure

    Private Structure Obj_Data_v11 'オブジェクト（地図データ）
        Public Kind As Integer
        Public NumOfNameTime As Integer
        Public NumOfCenterP As Integer
        Public NumOfSuc As Integer
        Public NumOfLine As Integer '集約オブジェクトの場合は、AggrtObj、普通のオブジェクトの場合はLineの数
        Public Shape As Short
        Public Edited As Boolean
        Public Circumscribed_Rectangle As clsVB6File.Box_Data_single_v11
        Public DefAttValue As String
        Public SucSTC() As Object_Succession_Data_v11
        Public NameTimeSTC() As Object_NameTimeStac_Data_v11
        Public CenterPSTC() As Object_CenterPoint_Data_v11
        Public LineCodeSTC() As LineCodeStac_Data_v11
    End Structure
    Public Structure LKOjectGroup_Info_v11
        Public GroupNumber As Integer
        Public UseOnly As Boolean
    End Structure

    Public Structure LineKind_Data_v11  '線種名とパターン（地図データ）
        Public Name As String
        Public NumofOjectGroup As Integer '1の場合は通常の線種、2以上の場合はオブジェクトグループ連動
        Public ObjGroup() As LKOjectGroup_Info_v11
        Public Pat() As clsVB6File.Line_Property_v11
        Public Mesh As Integer
        Public Edited As Boolean
    End Structure
    Private Structure Line_Time_Data_v11  'ライン線種・時間データ（地図データ）
        Public Kind As Integer
        Public StartTime As Integer
        Public EndTime As Integer
    End Structure
    Private Structure Line_Data_v11 'ラインデータ（地図データ）
        Public NumOfPoint As Integer
        Public Connect As Short
        Public NumOfLineUse As Integer
        Public Circumscribed_Rectangle As clsVB6File.Box_Data_single_v11
        Public NumOfTime As Integer
        Public Edited As Boolean
        Public Drawn As Boolean
        Public LineTimeSTC() As Line_Time_Data_v11
        Public PointSTC() As clsVB6File.SingleXY_v1275
    End Structure
    Private Shared MPVersion As Single
    ''' <summary>
    ''' 旧mpfファイル読み込み（ver9、10、11）
    ''' </summary>
    ''' <param name="oldMapFileName">地図ファイル名（フルパス）</param>
    ''' <param name="Map"></param>
    ''' <param name="ObjectKind"></param>
    ''' <param name="MPObj"></param>
    ''' <param name="LineKind"></param>
    ''' <param name="MPLine"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getOldMapFile(ByVal oldMapFileName As String, ByRef Map As clsMapData.strMap_data, _
            ByRef ObjectKind() As clsMapData.strObjectGroup_Data, ByRef MPObj() As clsMapData.strObj_Data, _
            ByRef LineKind() As clsMapData.LineKind_Data, ByRef MPLine() As clsMapData.strLine_Data) As Boolean
        Dim n As Integer = FreeFile()
        FileOpen(n, oldMapFileName, OpenMode.Binary, OpenAccess.Read, OpenShare.LockWrite)
        Map.FileName = System.IO.Path.GetFileName(oldMapFileName)
        Map.FullPath = oldMapFileName
        Return get_OldMapFile2(n, Map, ObjectKind, MPObj, LineKind, MPLine)
        FileClose(n)
    End Function
    ''' <summary>
    ''' 旧mpfファイル読み込み(mdrfファイルから読み込む場合)
    ''' </summary>
    ''' <param name="File_N">ファイルナンバー</param>
    ''' <param name="Map"></param>
    ''' <param name="ObjectKind"></param>
    ''' <param name="MPObj"></param>
    ''' <param name="LineKind"></param>
    ''' <param name="MPLine"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function get_OldMapFile2(ByVal File_N As Integer, ByRef Map As clsMapData.strMap_data, _
            ByRef ObjectKind() As clsMapData.strObjectGroup_Data, ByRef MPObj() As clsMapData.strObj_Data, _
            ByRef LineKind() As clsMapData.LineKind_Data, ByRef MPLine() As clsMapData.strLine_Data) As Boolean

        Dim n As Integer = File_N
        Dim SucStacNum10 As Integer
        Dim NameTimeNum10 As Integer
        Dim CenterPNum10 As Integer
        Dim LCPO10 As Integer
        Dim LineTimeNum10 As Integer
        Dim AP10 As Integer


        FileGet(n, MPVersion)
        If MPVersion < 9 Then
            FileClose(n)
            Throw New Exception("この地図ファイルはバージョンが古いので読み込めません。")
            Return False
        End If

        Dim Mapv11 As New map_data_v11
        Select Case MPVersion
            Case 9
                Dim Map_9 As map_data_9
                FileGet(n, Map_9)
                With Mapv11
                    .ALIN = Map_9.ALIN
                    AP10 = Map_9.AP
                    .Comment = Map_9.Comment
                    .CompD = Map_9.CompD
                    .Kend = Map_9.Kend
                    LCPO10 = Map_9.LCPO
                    .LpNum = Map_9.LpNum
                    .OBKNum = Map_9.OBKNum
                    .SCL = Map_9.SCL
                    .SCL_U = clsGeneric.getScaleUnit_from_Strings(Map_9.SCL_U)
                    LineTimeNum10 = Map_9.LineTimeStacNum
                    CenterPNum10 = Map_9.CenterPointStacNum
                    SucStacNum10 = Map_9.SucStacNum
                    NameTimeNum10 = Map_9.NameTimeStacNum
                    .Time_Mode = Map_9.Time_Mode
                    .Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode
                    .Zahyo.System = enmZahyo_System_Info.Zahyo_System_No
                    .Zahyo.Projection = enmProjection_Info.prjNo
                End With
            Case 10
                Dim Map_10 As map_data_10
                FileGet(n, Map_10)
                With Mapv11
                    .ALIN = Map_10.ALIN
                    AP10 = Map_10.AP
                    .Comment = Map_10.Comment
                    .CompD = Map_10.CompD
                    .Kend = Map_10.Kend
                    LCPO10 = Map_10.LCPO
                    .LpNum = Map_10.LpNum
                    .OBKNum = Map_10.OBKNum
                    .SCL = Map_10.SCL
                    .SCL_U = clsGeneric.getScaleUnit_from_Strings(Map_10.SCL_U)
                    LineTimeNum10 = Map_10.LineTimeStacNum
                    NameTimeNum10 = Map_10.NameTimeStacNum
                    CenterPNum10 = Map_10.CenterPointStacNum
                    SucStacNum10 = Map_10.SucStacNum
                    .Time_Mode = Map_10.Time_Mode
                    .Zahyo = Map_10.Zahyo
                    .Circumscribed_Rectangle = Map_10.Circumscribed_Rectangle
                End With
            Case 11
                FileGet(n, Mapv11)
        End Select

        '方位情報

        Dim MapCompasssv11 As clsVB6File.Compass_Attri_v11 = clsVB6File.getCompassAttri(n)
        Dim MapDetailv11 As Map_Detail_Data_v11
        FileGet(n, MapDetailv11)

        With Mapv11
            Map.ALIN = .ALIN
            Map.Circumscribed_Rectangle = clsVB6File.convertBoxDataSingle(.Circumscribed_Rectangle)
            Map.Comment = .Comment
            Map.Kend = .Kend
            Map.LpNum = .LpNum
            Map.MPVersion = MPVersion
            Map.OBKNum = .OBKNum
            Map.SCL = .SCL
            Map.SCL_U = clsGeneric.getScaleUnit_from_Strings(.SCL_U)
            Map.Time_Mode = .Time_Mode
            Map.Zahyo.CenterXY = clsVB6File.convertSingleXY(.Zahyo.CenterXY)
            Map.Zahyo.HeimenTyokkaku_KEI_Number = .Zahyo.HeimenTyokkaku_KEI_Number
            Map.Zahyo.Mode = .Zahyo.Mode
            Map.Zahyo.Projection = .Zahyo.Projection
            Map.Zahyo.System = .Zahyo.System
        End With
        Map.MapCompass = clsVB6File.convertCompassProperty(MapCompasssv11)

        With MapDetailv11
            Map.MapCompass.Mark.WordFont.Body.Kakudo = .Direction
            Select Case .Distance
                Case 0
                    Map.Detail.DistanceMeasurable = True
                    Map.Detail.ScaleVisible = True
                Case 1
                    Map.Detail.DistanceMeasurable = False
                    Map.Detail.ScaleVisible = True
                Case 2
                    Map.Detail.DistanceMeasurable = False
                    Map.Detail.ScaleVisible = False

            End Select
            If .Direction = 1 Then
                Map.MapCompass.Visible = False
            End If
        End With

        'オブジェクトグループ処理

        Dim ObjectKindv11() As ObjectKind_Data_v11
        ReDim ObjectKindv11(Mapv11.OBKNum - 1)
        If Mapv11.LpNum > 0 Then
            For i As Integer = 0 To Mapv11.OBKNum - 1
                ReDim ObjectKindv11(i).UseLineType(Mapv11.LpNum - 1)
            Next
        End If
        Select Case MPVersion
            Case 9
                For i As Integer = 0 To Mapv11.OBKNum - 1
                    Dim Objectkind_9 As ObjectKind_Data_9
                    FileGet(n, Objectkind_9)
                    With ObjectKindv11(i)
                        .Name = Objectkind_9.Name
                        .Shape = Objectkind_9.Shape
                        .Color = Objectkind_9.Color
                        .Edited = Objectkind_9.Edited
                        .Mesh = enmMesh_Number.mhNonMesh
                        .DefAttDataNum = 0
                    End With
                Next
            Case 10
                For i As Integer = 0 To Mapv11.OBKNum - 1
                    Dim Objectkind_10 As ObjectKind_Data_10
                    FileGet(n, Objectkind_10)
                    With ObjectKindv11(i)
                        .Name = Objectkind_10.Name
                        .Shape = Objectkind_10.Shape
                        .Color = Objectkind_10.Color
                        .Edited = Objectkind_10.Edited
                        .Mesh = Objectkind_10.Mesh
                        .DefAttDataNum = 0
                    End With
                Next
            Case 11
                For i As Integer = 0 To Mapv11.OBKNum - 1
                    FileGet(n, ObjectKindv11(i))
                Next
        End Select

        Select Case MPVersion
            Case 9, 10
                For i As Integer = 0 To Mapv11.OBKNum - 1
                    For j As Integer = 0 To Mapv11.LpNum - 1
                        FileGet(n, ObjectKindv11(i).UseLineType(j))
                    Next
                Next
        End Select

        ReDim ObjectKind(Map.OBKNum - 1)
        For i As Integer = 0 To Map.OBKNum - 1
            With ObjectKindv11(i)
                ObjectKind(i).Color = New colorARGB(255, ColorTranslator.FromWin32(.Color).ToArgb)
                ObjectKind(i).DefTimeAttDataNum = .DefAttDataNum
                If .DefAttSTC Is Nothing Then
                Else
                    ReDim ObjectKind(i).DefTimeAttSTC(Math.Max(0, .DefAttSTC.GetUpperBound(0)))
                    For j As Integer = 0 To .DefAttSTC.GetUpperBound(0)
                        ObjectKind(i).DefTimeAttSTC(j).attData.Title = .DefAttSTC(j).title
                        ObjectKind(i).DefTimeAttSTC(j).attData.Unit = .DefAttSTC(j).Unit
                        ObjectKind(i).DefTimeAttSTC(j).Type = clsMapData.enmDefTimeAttDataType.SpanData
                        ObjectKind(i).DefTimeAttSTC(j).ExtraValue = clsMapData.enmDefPointAttDataExtraValue.NearestValue
                    Next
                End If
                ObjectKind(i).Mesh = .Mesh
                ObjectKind(i).Name = .Name
                ObjectKind(i).ObjectType = .ObjectType
                ObjectKind(i).Shape = .Shape
                ObjectKind(i).UseLineType = .UseLineType.Clone
                If .UseObjectGroup Is Nothing Then
                Else
                    ObjectKind(i).UseObjectGroup = .UseObjectGroup.Clone
                End If
            End With
        Next


        'オブジェクト処理
        Dim mpObjv11() As Obj_Data_v11
        ReDim mpObjv11(Mapv11.Kend - 1)

        Dim OBJSTCStac(Mapv11.Kend - 1) As Integer
        Dim ObjNameTime(Mapv11.Kend - 1) As Object_NameTimeStac_Data_v11
        Dim ObjNameTimeStac(Mapv11.Kend - 1) As Integer
        Dim ObjCTP(Mapv11.Kend - 1) As Object_CenterPoint_Data_v11
        Dim ObjCenterPSTac(Mapv11.Kend - 1) As Integer
        Dim LCodeStac10(Mapv11.Kend - 1) As Integer

        For i As Integer = 0 To Mapv11.Kend - 1
            Select Case MPVersion
                Case 9, 10
                    Dim MPObj_10 As Obj_Data_10
                    FileGet(n, MPObj_10)
                    With mpObjv11(i)
                        .Edited = False
                        .Kind = MPObj_10.Kind
                        LCodeStac10(i) = MPObj_10.LineStac
                        .NumOfLine = MPObj_10.NumOfLine
                        .Shape = MPObj_10.Shape
                        .Circumscribed_Rectangle = MPObj_10.Circumscribed_Rectangle
                        .NumOfNameTime = MPObj_10.NumOfNameTime
                        .NumOfCenterP = MPObj_10.NumOfCenterP
                        .NumOfSuc = MPObj_10.NumOfSuc
                        .DefAttValue = ""
                        ObjNameTimeStac(i) = MPObj_10.NameTimeStac
                        OBJSTCStac(i) = MPObj_10.SucStac
                        ObjCenterPSTac(i) = MPObj_10.CenterPStac
                    End With
                Case 11
                    FileGet(n, mpObjv11(i))
            End Select
        Next

        Select Case MPVersion
            Case 9, 10
                ReDim ObjNameTime(NameTimeNum10)
                For i As Integer = 0 To NameTimeNum10 - 1
                    FileGet(n, ObjNameTime(i))
                Next
                For i As Integer = 0 To Mapv11.Kend - 1
                    With mpObjv11(i)
                        ReDim .NameTimeSTC(.NumOfNameTime - 1)
                        For j As Integer = 0 To .NumOfNameTime - 1
                            .NameTimeSTC(j) = ObjNameTime(ObjNameTimeStac(i) + j)
                        Next
                    End With
                Next

                ReDim ObjCTP(CenterPNum10)
                For i = 0 To CenterPNum10 - 1
                    FileGet(n, ObjCTP(i))
                Next
                For i As Integer = 0 To Map.Kend - 1
                    With mpObjv11(i)
                        ReDim .CenterPSTC(.NumOfCenterP - 1)
                        For j = 0 To .NumOfCenterP - 1
                            .CenterPSTC(j) = ObjCTP(ObjCenterPSTac(i) + j)
                        Next
                    End With
                Next

                Dim SUC(SucStacNum10) As Object_Succession_Data_v11
                For i As Integer = 0 To SucStacNum10 - 1
                    FileGet(n, SUC(i))
                Next
                For i As Integer = 0 To Map.Kend - 1
                    With mpObjv11(i)
                        If .NumOfSuc > 0 Then
                            ReDim .SucSTC(.NumOfSuc - 1)
                            For j As Integer = 0 To .NumOfSuc - 1
                                .SucSTC(j) = SUC(OBJSTCStac(i) + j)
                            Next
                        End If
                    End With
                Next

                Dim LcodeS(LCPO10) As LineCodeStac_Data_10
                For i As Integer = 0 To LCPO10 - 1
                    FileGet(n, LcodeS(i))
                Next
                For i As Integer = 0 To Mapv11.Kend - 1
                    With mpObjv11(i)
                        If .NumOfLine > 0 Then
                            ReDim .LineCodeSTC(.NumOfLine - 1)
                        End If
                        For j As Integer = 0 To .NumOfLine - 1
                            With .LineCodeSTC(j)
                                .LineCode = LcodeS(LCodeStac10(i) + j).LineCode
                                .NumOfTime = LcodeS(LCodeStac10(i) + j).NumOfTime
                                If .NumOfTime > 0 Then
                                    ReDim .Times(.NumOfTime - 1)
                                    Dim SPTime() As String = Split(LcodeS(LCodeStac10(i) + j).Times, vbTab)
                                    For k As Integer = 0 To .NumOfTime - 1
                                        .Times(k).StartTime = Val(SPTime(k * 2))
                                        .Times(k).EndTime = Val(SPTime(k * 2 + 1))
                                    Next
                                End If
                            End With
                        Next
                    End With
                Next
        End Select

        'オブジェクトグループ毎のオブジェクト名リスト数を数える
        Dim obk_objectNameListNum(Map.OBKNum - 1) As Integer
        For i As Integer = 0 To Map.Kend - 1
            With mpObjv11(i)
                For j As Integer = 0 To .NameTimeSTC.GetUpperBound(0)
                    Dim listn As Integer = 0
                    With .NameTimeSTC(j)
                        If .Name1 <> "" Then
                            listn += 1
                        End If
                        If .Name2 <> "" Then
                            listn += 1
                        End If
                    End With
                    obk_objectNameListNum(.Kind) = Math.Max(obk_objectNameListNum(.Kind), listn)
                Next
            End With
        Next
        For i As Integer = 0 To Map.OBKNum - 1
            With ObjectKind(i)
                .ObjectNameNum = Math.Max(obk_objectNameListNum(i), 1)
                ReDim .ObjectNameList(.ObjectNameNum - 1)
                For j As Integer = 0 To .ObjectNameNum - 1
                    .ObjectNameList(j) = "オブジェクト名" + (j + 1).ToString
                Next
            End With
        Next

        ReDim MPObj(Map.Kend - 1)
        For i As Integer = 0 To Map.Kend - 1
            With mpObjv11(i)
                MPObj(i).Number = i
                ReDim MPObj(i).CenterPSTC(.CenterPSTC.GetUpperBound(0))
                For j As Integer = 0 To .CenterPSTC.GetUpperBound(0)
                    With .CenterPSTC(j)
                        MPObj(i).CenterPSTC(j).Position = New PointF(.X, .Y)
                        MPObj(i).CenterPSTC(j).SETime.StartTime = clsTime.GetYMD(.StartTime)
                        MPObj(i).CenterPSTC(j).SETime.EndTime = clsTime.GetYMD(.EndTime)
                    End With
                Next
                MPObj(i).Circumscribed_Rectangle = clsVB6File.convertBoxDataSingle(.Circumscribed_Rectangle)
                If .DefAttValue <> "" Then
                    Dim spv() As String = .DefAttValue.Split(vbTab)
                    ReDim MPObj(i).DefTimeAttValue(spv.Length - 1)
                    For j As Integer = 0 To spv.Length - 1
                        ReDim MPObj(i).DefTimeAttValue(j).Data(0)
                        MPObj(i).DefTimeAttValue(j).Data(0).Value = spv(j)
                    Next
                End If
                MPObj(i).Kind = .Kind
                If .LineCodeSTC Is Nothing Then
                Else
                    ReDim MPObj(i).LineCodeSTC(.LineCodeSTC.GetUpperBound(0))
                    For j As Integer = 0 To .LineCodeSTC.GetUpperBound(0)
                        With .LineCodeSTC(j)
                            MPObj(i).LineCodeSTC(j).LineCode = .LineCode
                            MPObj(i).LineCodeSTC(j).NumOfTime = .NumOfTime
                            MPObj(i).LineCodeSTC(j).NumOfTime = .NumOfTime
                            If .Times Is Nothing Then
                            Else
                                ReDim MPObj(i).LineCodeSTC(j).Times(.Times.GetUpperBound(0))
                                For k As Integer = 0 To Math.Min(.Times.GetUpperBound(0), .NumOfTime - 1)
                                    With .Times(k)
                                        MPObj(i).LineCodeSTC(j).Times(k).StartTime = clsTime.GetYMD(.StartTime)
                                        MPObj(i).LineCodeSTC(j).Times(k).EndTime = clsTime.GetYMD(.EndTime)
                                    End With
                                Next
                            End If
                        End With
                    Next
                End If
                Dim ObjNameListNum As Integer = ObjectKind(MPObj(i).Kind).ObjectNameNum
                ReDim MPObj(i).NameTimeSTC(.NameTimeSTC.GetUpperBound(0))
                For j As Integer = 0 To .NameTimeSTC.GetUpperBound(0)
                    With .NameTimeSTC(j)
                        Dim oname As New List(Of String)
                        If .Name1 <> "" Then
                            oname.Add(.Name1)
                        End If
                        If .Name2 <> "" Then
                            oname.Add(.Name2)
                        End If
                        With MPObj(i).NameTimeSTC(j)
                            ReDim .NamesList(ObjNameListNum - 1)
                            For k As Integer = 0 To oname.Count - 1
                                .NamesList(k) = oname(k)
                            Next
                        End With
                        MPObj(i).NameTimeSTC(j).SETime.StartTime = clsTime.GetYMD(.StartTime)
                        MPObj(i).NameTimeSTC(j).SETime.EndTime = clsTime.GetYMD(.EndTime)
                    End With
                Next
                MPObj(i).NumOfCenterP = .NumOfCenterP
                MPObj(i).NumOfLine = .NumOfLine
                MPObj(i).NumOfNameTime = .NumOfNameTime
                MPObj(i).NumOfSuc = .NumOfSuc
                MPObj(i).Shape = .Shape
                If .SucSTC Is Nothing Then
                Else
                    ReDim MPObj(i).SucSTC(.SucSTC.GetUpperBound(0))
                    For j As Integer = 0 To .SucSTC.GetUpperBound(0)
                        With .SucSTC(j)
                            MPObj(i).SucSTC(j).ObjectCode = .ObjectCode
                            MPObj(i).SucSTC(j).Time = clsTime.GetYMD(.Time)
                        End With
                    Next
                End If
            End With
        Next

        '線種処理


        Dim lineKindv11(Mapv11.LpNum - 1) As LineKind_Data_v11
        Select Case MPVersion
            Case 9
                For i As Integer = 0 To Mapv11.LpNum - 1
                    Dim Lkind_9 As LineKind_Data_9
                    With Lkind_9
                        .Name = clsVB6File.getStringsV11(n)
                        .Pat = clsVB6File.getLinePropertyV11(n)
                        FileGet(n, .Edited)
                    End With
                    With lineKindv11(i)
                        ReDim .Pat(0)
                        ReDim .ObjGroup(0)
                        .Pat(0) = Lkind_9.Pat
                        .Name = Lkind_9.Name
                        .Mesh = enmMesh_Number.mhNonMesh
                        .NumofOjectGroup = 1
                    End With
                Next
            Case 10
                For i As Integer = 0 To Map.LpNum - 1
                    Dim Lkind_10 As LineKind_Data_10
                    With Lkind_10
                        .Name = clsVB6File.getStringsV11(n)
                        .Pat = clsVB6File.getLinePropertyV11(n)
                        FileGet(n, .Mesh)
                        FileGet(n, .Edited)
                    End With
                    With lineKindv11(i)
                        ReDim .Pat(0)
                        ReDim .ObjGroup(0)
                        .Pat(0) = Lkind_10.Pat
                        .Name = Lkind_10.Name
                        .Mesh = Lkind_10.Mesh
                        .NumofOjectGroup = 1
                    End With
                Next
            Case 11
                For i As Integer = 0 To Mapv11.LpNum - 1
                    lineKindv11(i) = clsVB6File.getLineKindV11(n)
                Next
        End Select

        ReDim LineKind(Map.LpNum - 1)
        For i As Integer = 0 To Map.LpNum - 1
            With lineKindv11(i)
                LineKind(i).Mesh = .Mesh
                LineKind(i).Name = .Name
                LineKind(i).NumofObjectGroup = .NumofOjectGroup
                If .ObjGroup.GetUpperBound(0) = -1 Then
                    ReDim LineKind(i).ObjGroup(0)
                    LineKind(i).ObjGroup(0).Pattern = clsVB6File.convertLineProperty(.Pat(0))
                Else
                    ReDim LineKind(i).ObjGroup(.ObjGroup.GetUpperBound(0))
                    For j As Integer = 0 To .ObjGroup.GetUpperBound(0)
                        With .ObjGroup(j)
                            LineKind(i).ObjGroup(j).GroupNumber = .GroupNumber
                            LineKind(i).ObjGroup(j).UseOnly = .UseOnly
                        End With
                        LineKind(i).ObjGroup(j).Pattern = clsVB6File.convertLineProperty(.Pat(j))
                    Next
                End If

            End With
        Next

        'ライン処理

        Dim LineTimeStac10(Map.ALIN) As Integer
        Dim MppointStac10(Map.ALIN) As Integer

        Dim mpLinev11(Mapv11.ALIN) As Line_Data_v11
        Select Case MPVersion
            Case 9, 10
                For i As Integer = 0 To Mapv11.ALIN - 1
                    Dim MPLine_10 As Line_Data10
                    FileGet(n, MPLine_10)
                    With mpLinev11(i)
                        .Circumscribed_Rectangle = MPLine_10.Circumscribed_Rectangle
                        .Connect = MPLine_10.Connect
                        .Edited = False
                        .Drawn = False
                        .NumOfLineUse = MPLine_10.NumOfLineUse
                        .NumOfPoint = MPLine_10.NumOfPoint
                        .NumOfTime = MPLine_10.NumOfTime
                        MppointStac10(i) = MPLine_10.PointStac
                        LineTimeStac10(i) = MPLine_10.TimeStac
                    End With
                Next
            Case 11
                For i As Integer = 0 To Mapv11.ALIN - 1
                    FileGet(n, mpLinev11(i))
                Next
        End Select

        Select Case MPVersion
            Case 9, 10
                Dim MPLineTimeStac10(LineTimeNum10) As Line_Time_Data_v11
                For i As Integer = 0 To LineTimeNum10 - 1
                    FileGet(n, MPLineTimeStac10(i))
                Next
                For i As Integer = 0 To Mapv11.ALIN - 1
                    With mpLinev11(i)
                        ReDim .LineTimeSTC(.NumOfTime - 1)
                        For j As Integer = 0 To .NumOfTime - 1
                            .LineTimeSTC(j) = MPLineTimeStac10(LineTimeStac10(i) + j)
                        Next
                    End With
                Next

                Dim Mppoint10() As clsVB6File.SingleXY_v1275
                ReDim Mppoint10(Math.Max(AP10 - 1, 0))
                For i As Integer = 0 To AP10 - 1
                    FileGet(n, Mppoint10(i))
                Next
                For i As Integer = 0 To Map.ALIN - 1
                    With mpLinev11(i)
                        ReDim .PointSTC(Math.Max(.NumOfPoint - 1, 0))
                        For j As Integer = 0 To .NumOfPoint - 1
                            .PointSTC(j) = Mppoint10(MppointStac10(i) + j)
                        Next
                    End With
                Next
        End Select

        ReDim MPLine(Map.ALIN - 1)
        For i As Integer = 0 To Map.ALIN - 1
            With mpLinev11(i)
                MPLine(i).Number = i
                MPLine(i).Circumscribed_Rectangle = clsVB6File.convertBoxDataSingle(.Circumscribed_Rectangle)
                MPLine(i).Connect = .Connect
                MPLine(i).Drawn = .Drawn
                ReDim MPLine(i).LineTimeSTC(.LineTimeSTC.GetUpperBound(0))
                For j As Integer = 0 To .LineTimeSTC.GetUpperBound(0)
                    With .LineTimeSTC(j)
                        MPLine(i).LineTimeSTC(j).Kind = .Kind
                        MPLine(i).LineTimeSTC(j).SETime.StartTime = clsTime.GetYMD(.StartTime)
                        MPLine(i).LineTimeSTC(j).SETime.EndTime = clsTime.GetYMD(.EndTime)
                    End With
                Next
                MPLine(i).NumOfLineUse = .NumOfLineUse
                MPLine(i).NumOfPoint = .NumOfPoint
                MPLine(i).NumOfTime = .NumOfTime
                ReDim MPLine(i).PointSTC(.NumOfPoint - 1)
                For j As Integer = 0 To .NumOfPoint - 1
                    MPLine(i).PointSTC(j) = clsVB6File.convertSingleXY(.PointSTC(j))
                Next
            End With
        Next

        Select Case MPVersion
            Case 9

                Dim MapRec As RectangleF
                If Map.ALIN > 0 Then
                    MapRec = New RectangleF(MPLine(0).PointSTC(0), New Size(0, 0))

                    For i As Integer = 0 To Map.ALIN - 1
                        MapRec = spatial.Get_Circumscribed_Rectangle(MPLine(i).Circumscribed_Rectangle, MapRec)
                    Next
                Else
                    MapRec = New RectangleF(MPObj(0).CenterPSTC(0).Position, New Size(0, 0))
                End If

                For i As Integer = 0 To Map.Kend - 1
                    For j As Integer = 0 To MPObj(i).NumOfCenterP - 1
                        With MPObj(i).CenterPSTC(j)
                            MapRec = spatial.Get_Circumscribed_Rectangle(.Position, MapRec)
                        End With
                    Next
                Next
                Map.Circumscribed_Rectangle = MapRec
        End Select

        Return True
    End Function
End Class
