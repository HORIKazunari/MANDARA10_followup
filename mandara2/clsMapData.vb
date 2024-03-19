Public Class clsMapData
    ''' <summary>
    ''' Get_Hennyu_Objectで使用する構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Hennyu_Data
        Public code As Integer
        Public Name As String
        Public Time As strYMD
        Public Part As Boolean
    End Structure

    Public Structure Object_Succession_Data 'オブジェクト継承データ（地図データ）
        Public ObjectCode As Integer
        Public Time As strYMD
    End Structure

    Public Structure Object_NameTimeStac_Data 'オブジェクト名スタック（地図データ）
        Public NamesList() As String
        Public SETime As Start_End_Time_data
        Public Function connectNames(Optional ByVal delimiter As String = "/")
            Return Join(Me.NamesList, delimiter)
        End Function
        Public Function Clone() As Object_NameTimeStac_Data
            Dim o As Object_NameTimeStac_Data
            With o
                .SETime = Me.SETime
                .NamesList = Me.NamesList.Clone
            End With
            Return o
        End Function
    End Structure
    Public Structure Object_CenterPoint_Data 'オブジェクト代表点（地図データ）
        Public Position As PointF
        Public SETime As Start_End_Time_data
    End Structure
    Public Structure LineCodeStac_Data  'ラインコードスタック（地図データ）
        Public LineCode As Integer
        Public NumOfTime As Integer
        Public Times() As Start_End_Time_data
        Public Function Clone() As LineCodeStac_Data
            Dim o As New LineCodeStac_Data
            o.NumOfTime = Me.NumOfTime
            o.LineCode = Me.LineCode
            ReDim o.Times(o.NumOfTime - 1)
            For i As Integer = 0 To o.NumOfTime - 1
                o.Times(i) = Me.Times(i)
            Next
            Return o
        End Function
    End Structure
    Public Enum enmObjectGoupType_Data
        NormalObject = 0 '通常のオブジェクト
        AggregationObject = 1 '集成オブジェクト
    End Enum
    ''' <summary>
    ''' 初期属性データのデータ項目（地図データ）
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strMPObjDefAttData_Info
        Public Title As String
        Public Unit As String
        Public MissingF As Boolean
        Public Note As String
        Public Property AttDataType() As enmAttDataType
            Get
                Return clsGeneric.getAttDataType_From_TitleUnit(Me.Title, Me.Unit)
            End Get
            Set(value As enmAttDataType)
                clsGeneric.SetTitleUnit_from_AttDataType(value, Me.Title, Me.Unit)
            End Set
        End Property
    End Structure
    ''' <summary>
    ''' 初期時点属性データで、所定時点以外を指定した場合のデータの処理
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enmDefPointAttDataExtraValue
        ''' <summary>
        ''' 欠損値
        ''' </summary>
        ''' <remarks></remarks>
        MissingValue = 0
        ''' <summary>
        ''' 近い時期の値
        ''' </summary>
        ''' <remarks></remarks>
        NearestValue = 1
        ''' <summary>
        ''' 二時点間の場合は内挿、そうでない場合は欠損値
        ''' </summary>
        ''' <remarks></remarks>
        interpolation_MissingValue = 2
        ''' <summary>
        ''' 二時点間の場合は内挿、そうでない場合は近い時期の値
        ''' </summary>
        ''' <remarks></remarks>
        interpolation_NearestValue = 3
    End Enum
    ''' <summary>
    ''' 初期時間属性データの種類
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enmDefTimeAttDataType
        PointData = 0
        SpanData = 1
    End Enum
    ''' <summary>
    ''' 初期時間属性データのデータ項目（オブジェクトグループに指定）
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strMPObjDefTimeAttData_Info
        Public Type As enmDefTimeAttDataType
        Public attData As strMPObjDefAttData_Info
        Public ExtraValue As enmDefPointAttDataExtraValue
    End Structure

    ''' <summary>
    ''' オブジェクトグループデータ（地図データ）
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strObjectGroup_Data '
        Public ObjectType As enmObjectGoupType_Data 'ObjectGoupType_Dataの内容
        Public Name As String
        Public Shape As enmShape
        Public Mesh As enmMesh_Number
        Public Color As colorARGB

        Public DefTimeAttDataNum As Integer
        Public DefTimeAttSTC() As strMPObjDefTimeAttData_Info

        Public ObjectNameNum As Integer
        Public ObjectNameList() As String

        Public UseLineType() As Boolean 'NormalObjectで使用
        Public UseObjectGroup() As Boolean 'AggregationObjectで使用するオブジェクトグループ
        Public Function Clone() As strObjectGroup_Data
            Dim o As New strObjectGroup_Data
            o.ObjectType = Me.ObjectType
            o.Name = Me.Name
            o.Shape = Me.Shape
            o.Color = Me.Color
            o.Mesh = Me.Mesh
            o.ObjectNameNum = Me.ObjectNameNum
            If Me.ObjectNameNum > 0 Then
                o.ObjectNameList = Me.ObjectNameList.Clone
            End If
            o.DefTimeAttDataNum = Me.DefTimeAttDataNum
            If Me.DefTimeAttDataNum > 0 Then
                o.DefTimeAttSTC = Me.DefTimeAttSTC.Clone
            End If
            If Me.UseLineType Is Nothing = False Then
                o.UseLineType = Me.UseLineType.Clone
            End If
            If Me.UseObjectGroup Is Nothing = False Then
                o.UseObjectGroup = Me.UseObjectGroup.Clone
            End If

            Return o
        End Function
    End Structure
    ''' <summary>
    ''' 初期時間属性データ個別
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strDefTimeAttDataEach_Info
        ''' <summary>
        ''' TypeがPointの場合はSpanの開始だけを使う
        ''' </summary>
        ''' <remarks></remarks>
        Public Span As Start_End_Time_data
        Public Value As String
    End Structure
    ''' <summary>
    ''' 初期時間属性データ
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strDefTimeAttData_Info
        Public Data() As strDefTimeAttDataEach_Info


    End Structure

    Public Structure strObj_Data 'オブジェクト（地図データ）

        Public Number As Integer 'オブジェクト番号
        Public Kind As Integer
        Public Shape As enmShape
        Public NumOfNameTime As Integer
        Public NumOfCenterP As Integer
        Public NumOfSuc As Integer
        Public NumOfLine As Integer '集約オブジェクトの場合は、AggrtObj、普通のオブジェクトの場合はLineの数
        Public Circumscribed_Rectangle As RectangleF
        Public DefTimeAttValue() As strDefTimeAttData_Info
        Public SucSTC() As Object_Succession_Data
        Public NameTimeSTC() As Object_NameTimeStac_Data
        Public CenterPSTC() As Object_CenterPoint_Data
        Public LineCodeSTC() As LineCodeStac_Data
        Public Function Clone() As strObj_Data
            Dim o As New strObj_Data
            o.Number = Me.Number
            o.Kind = Me.Kind
            o.Shape = Me.Shape
            o.NumOfNameTime = Me.NumOfNameTime
            o.NumOfCenterP = Me.NumOfCenterP
            o.NumOfSuc = Me.NumOfSuc
            o.NumOfLine = Me.NumOfLine
            o.Circumscribed_Rectangle = Me.Circumscribed_Rectangle
            o.DefTimeAttValue = clsGeneric.DefTimeAttValueClone(Me.DefTimeAttValue)
            If Me.SucSTC Is Nothing = False Then
                o.SucSTC = Me.SucSTC.Clone
            End If
            If Me.NameTimeSTC Is Nothing = False Then
                ReDim o.NameTimeSTC(Me.NumOfNameTime - 1)
                For i As Integer = 0 To Me.NumOfNameTime - 1
                    o.NameTimeSTC(i) = Me.NameTimeSTC(i).Clone
                Next
                o.NameTimeSTC = Me.NameTimeSTC.Clone
            End If
            If Me.CenterPSTC Is Nothing = False Then
                o.CenterPSTC = Me.CenterPSTC.Clone
            End If
            If Me.LineCodeSTC Is Nothing = False Then
                ReDim o.LineCodeSTC(Me.LineCodeSTC.GetUpperBound(0))
                For i As Integer = 0 To Me.LineCodeSTC.GetUpperBound(0)
                    o.LineCodeSTC(i) = Me.LineCodeSTC(i).Clone
                Next
            End If
            Return o
        End Function
    End Structure
    Public Structure dirWord_Data '方位の文字
        Public East As String
        Public West As String
        Public North As String
        Public South As String
    End Structure
    Public Structure strCompass_Attri  '方位の設定（地図・属性データ）
        Public Visible As Boolean
        Public Position As PointF
        Public Mark As Mark_Property
        Public dirWord As dirWord_Data
        Public Font As Font_Property
    End Structure

    Public Structure Line_Time_Data  'ライン線種・時間データ（地図データ）
        Public Kind As Integer
        Public SETime As Start_End_Time_data
    End Structure

    Public Structure strLine_Data 'ラインデータ（地図データ）
        Public Number As Integer 'ライン番号
        Public NumOfPoint As Integer
        Public Connect As enmLineConnect
        Public NumOfLineUse As Integer
        Public Circumscribed_Rectangle As RectangleF
        Public NumOfTime As Integer
        Public Drawn As Boolean
        Public LineTimeSTC() As Line_Time_Data
        Public PointSTC() As PointF
        Public Function Clone() As strLine_Data
            Dim L As New strLine_Data
            L.Number = Me.Number
            L.NumOfLineUse = Me.NumOfLineUse
            L.NumOfPoint = Me.NumOfPoint
            L.NumOfTime = Me.NumOfTime
            If Me.PointSTC Is Nothing = False Then
                L.PointSTC = Me.PointSTC.Clone
            End If
            L.Circumscribed_Rectangle = Me.Circumscribed_Rectangle
            L.Connect = Me.Connect
            L.Drawn = Me.Drawn
            If Me.LineTimeSTC Is Nothing = False Then
                L.LineTimeSTC = Me.LineTimeSTC.Clone
            End If
            Return L
        End Function
    End Structure


    Public Structure EnableMPLine_Data  '利用可能なライン（属性・地図データ）
        Public LineCode As Integer
        Public Kind As Integer
    End Structure
    Public Structure Zahyo_info
        Public Mode As enmZahyo_mode_info '緯度経度か、平面直角か
        Public System As enmZahyo_System_Info '世界測地系か、日本測地系か
        Public HeimenTyokkaku_KEI_Number As Short  '1-19の値
        Public Projection As enmProjection_Info '投影法
        Public CenterXY As PointF  '緯度経度の中心
    End Structure
    Public Structure strMap_data
        Public MPVersion As Single
        Public FileName As String
        Public FullPath As String
        Public OBKNum As Integer
        Public Kend As Integer
        Public LpNum As Integer
        Public ALIN As Integer
        Public SCL As Single
        Public SCL_U As enmScaleUnit
        Public Comment As String
        Public Time_Mode As Boolean
        Public Circumscribed_Rectangle As RectangleF '地図の外接四角形
        Public Zahyo As Zahyo_info
        Public Detail As Map_Detail_Data
        Public MapCompass As strCompass_Attri
    End Structure
    Public Structure strLKOjectGroup_Info
        Public GroupNumber As Integer
        Public UseOnly As Boolean
        Public Pattern As Line_Property
    End Structure
    Public Structure LineKind_Data  '線種名とパターン（地図データ）
        Public Name As String
        Public NumofObjectGroup As Integer '1の場合は通常の線種、2以上の場合はオブジェクトグループ連動
        Public ObjGroup() As strLKOjectGroup_Info '(0)は通常の線種のパターン
        Public Mesh As enmMesh_Number
        Public Function Clone() As LineKind_Data
            Dim L As New LineKind_Data
            L.Mesh = Me.Mesh
            L.Name = Me.Name
            L.NumofObjectGroup = Me.NumofObjectGroup
            ReDim L.ObjGroup(Me.NumofObjectGroup - 1)
            For i As Integer = 0 To Me.NumofObjectGroup - 1
                L.ObjGroup(i) = Me.ObjGroup(i)
            Next
            Return L
        End Function
    End Structure
    Public Structure LPatSek_Info '線種をオブジェクトグループ連動を個別に数えた場合に使用
        Public LKind As Integer
        Public LkindPatNum As Integer
        Public Name As String
        Public Pat As Line_Property
    End Structure
    Public Structure Map_Detail_Data
        Public DistanceMeasurable As Boolean
        Public ScaleVisible As Boolean
    End Structure



    '面オブジェクトの境界線の方向
    'Boundary_Arrange関数で使用
    Public Structure Fringe_Line_Info
        Public code As Integer
        Public Direction As Integer '1 or -1
    End Structure


    Public Map As strMap_data
    Public ObjectKind() As strObjectGroup_Data
    Public MPObj() As strObj_Data
    Public LineKind() As LineKind_Data
    Public MPLine() As strLine_Data
    Private _NoDataFlag As Boolean

    Public Sub New(ByVal MapFileName As String)
        'エラーの検出は呼び出し元でTry Catch
        init_MapData()
        If System.IO.Path.GetExtension(MapFileName).ToLower = ".mpf" Then
            '旧mpf地図ファイル
            Dim f As Boolean = clsOldMapFile.getOldMapFile(MapFileName, Map, ObjectKind, MPObj, LineKind, MPLine)
        Else
            'xmlファイル読み込み
            readMapFile(MapFileName)
            Map.FileName = System.IO.Path.GetFileName(MapFileName)
            Map.FullPath = MapFileName
        End If
        Me._NoDataFlag = False
    End Sub
    Public Sub New()
        init_MapData()
    End Sub
    ''' <summary>
    ''' MapDataに中身をコピーする
    ''' </summary>
    ''' <param name="MapData"></param>
    ''' <remarks></remarks>
    Public Sub CopyTo(ByRef MapData As clsMapData)
        With MapData
            .Map = Me.Map

            ReDim .ObjectKind(Me.Map.OBKNum - 1)
            ReDim .MPObj(Me.Map.Kend - 1)
            ReDim .MPLine(Me.Map.ALIN - 1)
            ReDim .LineKind(Me.Map.LpNum - 1)
            For i As Integer = 0 To Me.Map.OBKNum - 1
                .ObjectKind(i) = Me.ObjectKind(i).Clone
            Next
            For i As Integer = 0 To Me.Map.Kend - 1
                .MPObj(i) = Me.MPObj(i).Clone
            Next
            For i As Integer = 0 To Me.Map.ALIN - 1
                .MPLine(i) = Me.MPLine(i).Clone
            Next
            For i As Integer = 0 To Me.Map.LpNum - 1
                .LineKind(i) = Me.LineKind(i).Clone
            Next
        End With

    End Sub
    ''' <summary>
    ''' clsMapDataの複製を作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Clone() As clsMapData
        Dim newMapData As New clsMapData
        With newMapData
            .Map = Me.Map
            ._NoDataFlag = Me._NoDataFlag
            ReDim .ObjectKind(Me.Map.OBKNum - 1)
            ReDim .MPObj(Me.Map.Kend - 1)
            ReDim .MPLine(Me.Map.ALIN - 1)
            ReDim .LineKind(Me.Map.LpNum - 1)
            For i As Integer = 0 To Me.Map.OBKNum - 1
                .ObjectKind(i) = Me.ObjectKind(i).Clone
            Next
            For i As Integer = 0 To Me.Map.Kend - 1
                .MPObj(i) = Me.MPObj(i).Clone
            Next
            For i As Integer = 0 To Me.Map.ALIN - 1
                .MPLine(i) = Me.MPLine(i).Clone
            Next
            For i As Integer = 0 To Me.Map.LpNum - 1
                .LineKind(i) = Me.LineKind(i).Clone
            Next
        End With
        Return newMapData
    End Function
    ''' <summary>
    ''' 地図ファイル保存
    ''' </summary>
    ''' <param name="MapFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveMapFile(ByVal MapFileName As String) As Boolean
        Dim ext As String = LCase(System.IO.Path.GetExtension(MapFileName))

        Select Case ext
            Case ".mpfx"
                'xml形式ファイルとして出力
                Try
                    Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsMapData))        'オブジェクトの型を指定する
                    Dim fs As New System.IO.FileStream(MapFileName, System.IO.FileMode.Create)        '書き込むファイルを開く
                    serializer.Serialize(fs, Me)        'シリアル化し、XMLファイルに保存する
                    fs.Close()        'ファイルを閉じる
                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                    Return False
                End Try
            Case ".mpfz"

                'clsMapDataをxmlzipファイルに出力する
                Dim tmpFolderName As String = clsGeneric.MakeTempFolder_forZip()
                If tmpFolderName = "" Then
                    Return False
                End If
                Try
                    'xmlファイルとして出力、この場合は拡張子をxmlにする
                    Dim xmlFile As String = tmpFolderName + "\mandara_map.xml"
                    'XmlSerializerオブジェクトを作成
                    Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsMapData))        'オブジェクトの型を指定する
                    Dim fs As New System.IO.FileStream(xmlFile, System.IO.FileMode.Create)        '書き込むファイルを開く
                    serializer.Serialize(fs, Me)        'シリアル化し、XMLファイルに保存する
                    fs.Close()        'ファイルを閉じる
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                    Return False
                End Try
                Dim f As Boolean = clsGeneric.CompressFolder_and_DeleteTempFolder(tmpFolderName, MapFileName)
                Return f
            Case ".mpfj"
                'JSONファイル
                Dim tmpFolderName As String = clsGeneric.MakeTempFolder_forZip()
                If tmpFolderName = "" Then
                    Return False
                End If
                Dim deserialized = Newtonsoft.Json.JsonConvert.SerializeObject(Me)
                Try
                    Dim tempFileName = tmpFolderName + "\" + System.IO.Path.GetFileNameWithoutExtension(MapFileName)
                    Dim sw As New System.IO.StreamWriter(tempFileName, False, System.Text.Encoding.GetEncoding("utf-8"))
                    Dim sb As New System.Text.StringBuilder(deserialized)
                    sb.Replace("," + Chr(34) + "IsEmpty" + Chr(34) + ":false,", "")
                    sb.Replace(Chr(34) + "IsEmpty" + Chr(34) + ":false,", "")
                    sb.Replace("," + Chr(34) + "IsEmpty" + Chr(34) + ":false", "")
                    sw.Write(sb.ToString)
                    sw.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                    Return False

                End Try
                Dim f As Boolean = clsGeneric.CompressFolder_and_DeleteTempFolder(tmpFolderName, MapFileName)
                Return f
        End Select

    End Function
    ''' <summary>
    ''' xml地図ファイルから読み込み
    ''' </summary>
    ''' <param name="MapFileName"></param>
    ''' <remarks></remarks>
    Private Sub readMapFile(ByRef MapFileName As String)
        '
        Dim ext As String = LCase(System.IO.Path.GetExtension(MapFileName))

        Select Case ext
            Case ".mpfx"
                'オブジェクトの型を指定する
                'Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsMapData))
                'Dim doc As New System.Xml.XmlDocument()
                'doc.PreserveWhitespace = True '改行をCRLFにする。これがないとLFになってしまう。
                'doc.Load(MapFileName)
                'Dim reader As New System.Xml.XmlNodeReader(doc.DocumentElement)
                'Dim obj As clsMapData = CType(serializer.Deserialize(reader), clsMapData)


                Dim fs As System.IO.FileStream = New System.IO.FileStream(MapFileName, IO.FileMode.Open)
                Dim serializer As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(clsMapData))
                Dim obj As clsMapData = CType(serializer.Deserialize(fs), clsMapData)
                fs.Close()
                fs.Dispose()

                Me.Map = obj.Map
                Me.MPObj = obj.MPObj
                Me.MPLine = obj.MPLine
                Me.LineKind = obj.LineKind
                Me.ObjectKind = obj.ObjectKind
            Case ".mpfz"
                '一時フォルダを作成
                Dim tmpFolderName As String = clsGeneric.MakeTempFolder_forZip()
                If tmpFolderName = "" Then
                    Return
                End If

                '一時フォルダにmpfxファイルを解凍
                System.IO.Compression.ZipFile.ExtractToDirectory(MapFileName, tmpFolderName)

                Dim xmlFile As String = tmpFolderName + "\mandara_map.xml"

                'Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsMapData)) '■この方法だと巨大ファイルでOut of memory exceptionが出る
                'Dim doc As New System.Xml.XmlDocument()
                'doc.PreserveWhitespace = True '改行をCRLFにする。これがないとLFになってしまう。
                'doc.Load(xmlFile)
                'Dim reader As New System.Xml.XmlNodeReader(doc.DocumentElement)
                'Dim obj As clsMapData = CType(serializer.Deserialize(reader), clsMapData)

                Dim fs As New System.IO.FileStream(xmlFile, IO.FileMode.Open)
                Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsMapData))
                Dim obj As clsMapData = CType(serializer.Deserialize(fs), clsMapData)
                fs.Close()
                fs.Dispose()
                If obj.Map.Comment Is Nothing = False Then
                    obj.Map.Comment = obj.Map.Comment.Replace(vbLf, vbCrLf) 'XMLで保存するとCRLFがLFになってしまうので、CRLFに戻す
                End If

                '作成した一時フォルダを削除
                System.IO.Directory.Delete(tmpFolderName, True)
                Me.Map = obj.Map
                Me.MPObj = obj.MPObj
                Me.MPLine = obj.MPLine
                Me.LineKind = obj.LineKind
                Me.ObjectKind = obj.ObjectKind
                '
                ''オブジェクトグループ毎のオブジェクト名リスト数を数える
                'Dim obk_objectNameListNum(Map.OBKNum - 1) As Integer
                'For i As Integer = 0 To Map.Kend - 1
                '    With MPObj(i)
                '        For j As Integer = 0 To .NameTimeSTC.GetUpperBound(0)
                '            With .NameTimeSTC(j)
                '                obk_objectNameListNum(MPObj(i).Kind) = Math.Max(obk_objectNameListNum(MPObj(i).Kind), .Names.NumOfName)
                '            End With
                '        Next
                '    End With
                'Next
                'For i As Integer = 0 To Map.OBKNum - 1
                '    With ObjectKind(i)
                '        .ObjectNameNum = obk_objectNameListNum(i)
                '        ReDim .ObjectNameList(.ObjectNameNum - 1)
                '        For j As Integer = 0 To obk_objectNameListNum(i) - 1
                '            .ObjectNameList(j) = "オブジェクト名" + (j + 1).ToString
                '        Next
                '    End With
                'Next
                'For i As Integer = 0 To Map.Kend - 1
                '    With MPObj(i)
                '        Dim n As Integer = ObjectKind(.Kind).ObjectNameNum
                '        For j As Integer = 0 To .NumOfNameTime - 1
                '            With .NameTimeSTC(j)
                '                ReDim .NamesList(n - 1)
                '                For k As Integer = 0 To Math.Min(.Names.NumOfName, n) - 1
                '                    .NamesList(k) = .Names.NameList(k)
                '                Next
                '            End With
                '        Next
                '    End With
                'Next
        End Select


    End Sub
    ''' <summary>
    ''' 地図データを初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub init_MapData()

        ReDim MPObj(0)
        ReDim ObjectKind(0)
        ReDim LineKind(0)
        ReDim MPLine(10)

        With Map
            .FileName = ""
            .FullPath = ""
            .MPVersion = 11
            .ALIN = 0
            .Kend = 0
            .OBKNum = 0
            .LpNum = 0
            .SCL = 0
            .SCL_U = enmScaleUnit.kilometer
            .Time_Mode = False
            .Comment = ""
            .Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode
            .Zahyo.System = enmZahyo_System_Info.Zahyo_System_No
            With .Detail
                .DistanceMeasurable = True
                .ScaleVisible = True
            End With
            .MapCompass.Visible = True
        End With
        _NoDataFlag = True
    End Sub
    Public Property NoDataFlag() As Boolean
        Get
            Return Me._NoDataFlag
        End Get
        Set(value As Boolean)
            Me._NoDataFlag = value
        End Set
    End Property
    ''' <summary>
    ''' 地図ファイル中のラインのポインの数のカウント
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_All_MpLinePoint() As Integer

        Dim n As Integer = 0
        For i As Integer = 0 To Me.Map.ALIN - 1
            n += Me.MPLine(i).NumOfPoint
        Next
        Return n

    End Function
    ''' <summary>
    ''' Undo機能でのみ使用。ラインをNumberプロパティの位置に挿入する。位置は挿入後の位置を示す。
    ''' </summary>
    ''' <param name="LineArray"></param>
    ''' <remarks></remarks>
    Public Sub Insert_Line(ByRef LineArray() As strLine_Data)
        If LineArray Is Nothing Then
            Return
        End If
        Dim plus_n As Integer = LineArray.GetLength(0)
        Dim PALIN As Integer = Me.Map.ALIN
        Dim newALIN As Integer = PALIN + plus_n
        Dim C_MpLine(newALIN - 1) As Integer
        Dim InsCode(plus_n - 1) As Integer
        For i As Integer = 0 To plus_n - 1
            InsCode(i) = LineArray(i).Number
        Next
        Array.Sort(InsCode)
        For i As Integer = 0 To PALIN - 1
            C_MpLine(i) = i
        Next

        '現在の番号を挿入後の番号に直す変換配列
        Dim searchPoint As Integer = 0
        For i As Integer = 0 To plus_n - 1
            Dim f As Boolean = False
            For j = searchPoint To PALIN - 1
                If InsCode(i) <= C_MpLine(j) Then
                    If f = False Then
                        searchPoint = j
                        f = True
                    End If
                    C_MpLine(j) += 1
                End If
            Next
        Next

        ReDim Preserve Me.MPLine(newALIN - 1)
        For i As Integer = PALIN - 1 To 0 Step -1
            Me.MPLine(C_MpLine(i)) = Me.MPLine(i).Clone
            Me.MPLine(C_MpLine(i)).Number = C_MpLine(i)
        Next

        'オブジェクトの使用ラインの番号を移す
        For i As Integer = 0 To Me.Map.Kend - 1
            With Me.MPObj(i)
                If Me.ObjectKind(.Kind).ObjectType = enmObjectGoupType_Data.NormalObject Then
                    For j As Integer = 0 To .NumOfLine - 1
                        .LineCodeSTC(j).LineCode = C_MpLine(.LineCodeSTC(j).LineCode)
                    Next
                End If
            End With
        Next
        For i As Integer = 0 To plus_n - 1
            Me.MPLine(LineArray(i).Number) = LineArray(i).Clone
        Next
        Me.Map.ALIN = newALIN

    End Sub
    ''' <summary>
    ''' Undo機能でのみ使用。オブジェクトをNumberプロパティの位置に挿入する。位置は挿入後の位置を示す。
    ''' </summary>
    ''' <param name="ObjArray">strObjの配列</param>
    ''' <remarks></remarks>
    Public Sub Insert_Object(ByRef ObjArray() As strObj_Data)
        If ObjArray Is Nothing Then
            Return
        End If
        Dim plus_n As Integer = ObjArray.GetLength(0)
        Dim PKend As Integer = Me.Map.Kend
        Dim newKend As Integer = PKend + plus_n
        Dim C_MpObj(PKend - 1) As Integer
        Dim InsCode(plus_n - 1) As Integer
        For i As Integer = 0 To plus_n - 1
            InsCode(i) = ObjArray(i).Number
        Next
        Array.Sort(InsCode)
        For i As Integer = 0 To PKend - 1
            C_MpObj(i) = i
        Next

        '現在の番号を挿入後の番号に直す変換配列
        Dim searchPoint As Integer = 0
        For i As Integer = 0 To plus_n - 1
            Dim f As Boolean = False
            For j = searchPoint To PKend - 1
                If InsCode(i) <= C_MpObj(j) Then
                    If f = False Then
                        searchPoint = j
                        f = True
                    End If
                    C_MpObj(j) += 1
                End If
            Next
        Next

        ReDim Preserve Me.MPObj(newKend - 1)
        For i As Integer = PKend - 1 To 0 Step -1
            Me.MPObj(C_MpObj(i)) = Me.MPObj(i).Clone
            'オブジェクトの継承と集成オブジェクトをチェックする
            With Me.MPObj(C_MpObj(i))
                .Number = C_MpObj(i) '番号を振り直す
                Dim nsuc As Integer = 0
                For j As Integer = 0 To .NumOfSuc - 1
                    .SucSTC(j).ObjectCode = C_MpObj(.SucSTC(j).ObjectCode)
                Next

                If Me.ObjectKind(.Kind).ObjectType = enmObjectGoupType_Data.AggregationObject Then
                    nsuc = 0
                    For j As Integer = 0 To .NumOfLine - 1
                        .LineCodeSTC(j).LineCode = C_MpObj(.LineCodeSTC(j).LineCode)
                    Next
                End If
            End With
        Next

        For i As Integer = 0 To plus_n - 1
            Me.MPObj(ObjArray(i).Number) = ObjArray(i).Clone
        Next
        Me.Map.Kend = newKend
        countNumOfLineUse()
    End Sub
    ''' <summary>
    ''' 点オブジェクトの新規登録
    ''' </summary>
    ''' <param name="ObjGroup">オブジェクトグループ</param>
    ''' <param name="Objnames">オブジェクト名の配列</param>
    ''' <param name="CenterP">代表点</param>
    ''' <remarks></remarks>
    Public Sub Add_OnePointObject(ByVal ObjGroup As Integer, ByRef Objnames() As String, ByVal CenterP As PointF)

        Dim obj As strObj_Data
        obj = Init_One_Object(ObjGroup)
        With obj
            .Kind = ObjGroup
            .Shape = enmShape.PointShape
            With .NameTimeSTC(0)
                Dim n As Integer = Math.Min(ObjectKind(ObjGroup).ObjectNameNum, Objnames.Length)
                For i As Integer = 0 To n - 1
                    .NamesList(i) = Objnames(i)
                Next
            End With
            .CenterPSTC(0).Position = CenterP
            .Number = -1
            .Circumscribed_Rectangle = New RectangleF(CenterP, New Size(0, 0))
        End With
        Save_Object(obj, False)
    End Sub
    ''' <summary>
    ''' Numberプロパティの番号にオブジェクト登録。
    ''' </summary>
    ''' <param name="EditingObject"></param>
    ''' <param name="checkObjectmaxMinFlaf">オブジェクトの外接四角形を計算する場合true</param>
    ''' <remarks></remarks>
    Public Sub Save_Object(ByRef EditingObject As strObj_Data, ByVal checkObjectmaxMinFlaf As Boolean)

        If EditingObject.Number = -1 Then
            EditingObject.Number = Me.Map.Kend
            '新規オブジェクト
            If Me.MPObj.Length <= EditingObject.Number Then
                ReDim Preserve Me.MPObj(Math.Min(Me.Map.Kend * 2, Me.Map.Kend + 10000))
            End If
            Me.Map.Kend += 1
        End If
        Me.MPObj(EditingObject.Number) = EditingObject.Clone
        If checkObjectmaxMinFlaf = True Then
            Check_Obj_Maxmin(Me.MPObj(EditingObject.Number), True)
        End If
    End Sub
    ''' <summary>
    ''' ライン登録
    ''' </summary>
    ''' <param name="EditingLine">ライン</param>
    ''' <param name="checkRelatedLineFlag">編集したラインの起終点に結合したラインの結節関係をチェックする場合true</param>
    ''' <param name="checkRelatedObjectShapeFlag">ラインを使用するオブジェクトの形状をチェックする場合true</param>
    ''' <param name="checkLineMaxMinFlag">ラインの外接四角形を計算する場合true</param>
    ''' <remarks></remarks>
    Public Sub Save_Line(ByRef EditingLine As strLine_Data, ByVal checkRelatedLineFlag As Boolean,
                         ByVal checkRelatedObjectShapeFlag As Boolean,
                         ByVal checkLineMaxMinFlag As Boolean)
        Dim SEpoint(3) As PointF
        Dim SEpointCheckN As Integer
        Dim newf As Boolean
        With EditingLine
            SEpoint(0) = .PointSTC(0)
            SEpoint(1) = .PointSTC(.NumOfPoint - 1)
            If EditingLine.Number = -1 Then
                '新規
                .Number = Map.ALIN
                If UBound(Me.MPLine) < Me.Map.ALIN Then
                    ReDim Preserve Me.MPLine(Me.Map.ALIN * 2)
                End If
                Me.Map.ALIN += 1
                SEpointCheckN = 2
                newf = True
            Else
                SEpoint(2) = Me.MPLine(.Number).PointSTC(0)
                SEpoint(3) = Me.MPLine(.Number).PointSTC(Me.MPLine(.Number).NumOfPoint - 1)
                SEpointCheckN = 4
                newf = False
            End If
            .Connect = Check_Line_Connect(EditingLine)
            Me.MPLine(.Number) = .Clone
            If checkLineMaxMinFlag = True Then
                Check_Line_Maxmin(.Number, True)
            End If

            If newf = False And checkRelatedObjectShapeFlag = True Then
                '当該ラインを使用するオブジェクトの形状チェック
                For i As Integer = 0 To Map.Kend - 1
                    With Me.MPObj(i)
                        For j As Integer = 0 To .NumOfLine - 1
                            If .LineCodeSTC(j).LineCode = EditingLine.Number Then
                                .Shape = Check_Obj_Shape_AllTime(Me.MPObj(i))
                                Exit For
                            End If
                        Next
                    End With
                Next
            End If

            If checkRelatedLineFlag = True Then
                Check_Related_Line(SEpointCheckN, SEpoint, .Number)
            End If
        End With
    End Sub
    ''' <summary>
    ''' 指定した起終点の座標のラインを検索し、結節関係をチェックする
    ''' </summary>
    ''' <param name="n">調べる座標数</param>
    ''' <param name="SEpoint">地図座標配列</param>
    ''' <param name="exCode">除外ライン番号（自分自身など）</param>
    ''' <remarks></remarks>
    Private Sub Check_Related_Line(ByVal n As Integer, ByVal SEpoint() As PointF, ByVal exCode As Integer)

        For i As Integer = 0 To Map.ALIN - 1
            With Me.MPLine(i)
                If i <> exCode And .NumOfPoint > 0 Then
                    Dim f As Boolean = False
                    For j As Integer = 0 To n - 1
                        If SEpoint(j).Equals(.PointSTC(0)) = True Then
                            f = True
                            Exit For
                        ElseIf SEpoint(j).Equals(.PointSTC(.NumOfPoint - 1)) = True Then
                            f = True
                            Exit For
                        End If
                    Next
                    If f = True Then
                        Dim ct As Integer = Check_Line_Connect(Me.MPLine(i), exCode)
                        If ct <> MPLine(i).Connect Then
                            .Connect = ct
                        End If
                    End If
                End If
            End With
        Next
    End Sub
    ''' <summary>
    ''' ラインの削除
    ''' </summary>
    ''' <param name="EraseLineCode">削除するラインコード</param>
    ''' <param name="Chack_Object_Shape_F">削除するラインを使用するオブジェクトの形状をチェックする場合true</param>
    ''' <remarks></remarks>
    Public Sub Erase_Line(ByVal EraseLineCode As Integer, ByVal Chack_Object_Shape_F As Boolean)

        Dim LCode(0) As Integer
        Dim SEpoint(1) As PointF
        LCode(0) = EraseLineCode
        With Me.MPLine(EraseLineCode)
            SEpoint(0) = .PointSTC(0)
            SEpoint(1) = .PointSTC(.NumOfPoint - 1)
        End With
        Call Erase_MultiLine(1, LCode, True, Chack_Object_Shape_F, True)
        Check_Related_Line(2, SEpoint, -1)
    End Sub
    ''' <summary>
    ''' 複数のラインを削除
    ''' </summary>
    ''' <param name="MultiLCode">ライン番号の入ったList(Of Integer)</param>
    ''' <param name="UsedLine_Delete_F">ラインがオブジェクトに使用されていたら削除しない場合、true</param>
    ''' <param name="Check_ObjectShape_F">ラインを使用するオブジェクトの形状を削除後にチェックする場合true</param>
    ''' <param name="MapRectCheckF">地図データ全体の外接四角形をチェックするか</param>
    ''' <returns>実際に削除したライン番号の配列</returns>
    ''' <remarks></remarks>
    Public Function Erase_MultiLine(ByVal MultiLCode As List(Of Integer), ByVal UsedLine_Delete_F As Boolean,
                                    ByVal Check_ObjectShape_F As Boolean, ByVal MapRectCheckF As Boolean)
        Dim Values() As Integer = MultiLCode.ToArray
        Return Erase_MultiLine(Values.GetLength(0), Values, UsedLine_Delete_F, Check_ObjectShape_F, MapRectCheckF)
    End Function
    ''' <summary>
    ''' 複数のラインを削除
    ''' </summary>
    ''' <param name="LNum">削除するライン数</param>
    ''' <param name="LCode">ライン番号配列</param>
    ''' <param name="UsedLine_Delete_F">ラインがオブジェクトに使用されていても削除する場合、true</param>
    ''' <param name="Check_ObjectShape_F">ラインを使用するオブジェクトの形状を削除後にチェックする場合true</param>
    ''' <param name="MapRectCheckF">地図データ全体の外接四角形をチェックするか</param>
    ''' <returns>実際に削除したライン番号の配列</returns>
    ''' <remarks></remarks>
    Public Function Erase_MultiLine(ByVal LNum As Integer, ByVal LCode() As Integer, ByVal UsedLine_Delete_F As Boolean, _
                                ByVal Check_ObjectShape_F As Boolean, ByVal MapRectCheckF As Boolean) As Integer()

        Dim C_Mpline(Me.Map.ALIN - 1) As Integer
        Dim RealDeleteLineCode(LNum) As Integer
        For i As Integer = 0 To LNum - 1
            C_Mpline(LCode(i)) = -1
        Next

        If UsedLine_Delete_F = False Then
            For i As Integer = 0 To Me.Map.ALIN - 1
                If C_Mpline(i) = -1 Then
                    If Me.MPLine(i).NumOfLineUse > 0 Then
                        C_Mpline(i) = 0
                    End If
                End If
            Next
        End If

        Dim n As Integer = 0
        For i As Integer = 0 To Me.Map.ALIN - 1
            If C_Mpline(i) = -1 Then
                RealDeleteLineCode(n) = i
                n += 1
            Else
                C_Mpline(i) = i - n
                Me.MPLine(i - n) = Me.MPLine(i).Clone
                Me.MPLine(i - n).Number = i - n
            End If
        Next
        If n = 0 Then
            RealDeleteLineCode = Nothing
        Else
            ReDim Preserve RealDeleteLineCode(n - 1)
        End If
        Me.Map.ALIN -= n
        ReDim Preserve Me.MPLine(Me.Map.ALIN - 1)

        For i As Integer = 0 To Me.Map.Kend - 1
            With Me.MPObj(i)
                If Me.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                    n = 0
                    For j As Integer = 0 To .NumOfLine - 1
                        If C_Mpline(.LineCodeSTC(j).LineCode) = -1 Then
                            n += 1
                        Else
                            .LineCodeSTC(j).LineCode = C_Mpline(.LineCodeSTC(j).LineCode)
                            .LineCodeSTC(j - n) = .LineCodeSTC(j)
                        End If
                    Next
                    If n > 0 Then
                        .NumOfLine -= n
                        If .NumOfLine = 0 Then
                            ReDim .LineCodeSTC(0)
                            Erase .LineCodeSTC
                        Else
                            ReDim Preserve .LineCodeSTC(.NumOfLine - 1)
                        End If
                        If UsedLine_Delete_F = True And Check_ObjectShape_F = True Then
                            .Shape = Check_Obj_Shape_AllTime(Me.MPObj(i))
                        End If
                    End If
                End If
            End With
        Next
        Check_ALl_Line_Connect()
        If MapRectCheckF = True And Map.ALIN > 0 Then
            Me.Map.Circumscribed_Rectangle = Get_Mapfile_Rectangle()
        End If
        Return RealDeleteLineCode
    End Function

    Public Sub Erase_LineKind(ByVal LKNum As Integer)
        '線種削除:使用していないことを確認してから使う

        For i As Integer = LKNum + 1 To Me.Map.LpNum - 1
            Me.LineKind(i - 1) = Me.LineKind(i)
            For j = 0 To Me.Map.OBKNum - 1
                Me.ObjectKind(j).UseLineType(i - 1) = Me.ObjectKind(j).UseLineType(i)
            Next
        Next

        For i As Integer = 0 To Me.Map.OBKNum - 1
            ReDim Preserve Me.ObjectKind(i).UseLineType(Math.Max(Me.Map.LpNum - 1, 0))
        Next

        For i As Integer = 0 To Me.Map.ALIN - 1
            For j As Integer = 0 To Me.MPLine(i).NumOfTime - 1
                With Me.MPLine(i).LineTimeSTC(j)
                    Dim k As Integer = .Kind
                    If k > LKNum Then
                        .Kind = k - 1
                    End If
                End With
            Next
        Next

        Me.Map.LpNum -= 1
    End Sub
    ''' <summary>
    ''' オブジェクトを削除
    ''' </summary>
    ''' <param name="OCode">オブジェクト番号</param>
    ''' <param name="MapRectCheckF">地図データ全体の外接四角形をチェックするか</param>
    ''' <remarks></remarks>
    Public Sub EraseObject(ByVal OCode As Integer, ByVal MapRectCheckF As Boolean)
        '
        Erase_MultiObjects(1, New Integer() {OCode}, MapRectCheckF)
    End Sub
    ''' <summary>
    ''' 複数オブジェクトを削除
    ''' </summary>
    ''' <param name="O_Codeas">オブジェクト番号のList(Of Integer)</param>
    ''' <param name="MapRectCheckF">地図データ全体の外接四角形をチェックするか</param>
    ''' <remarks></remarks>
    Public Sub Erase_MultiObjects(ByRef O_Codeas As List(Of Integer), ByVal MapRectCheckF As Boolean)

        Erase_MultiObjects(O_Codeas.Count, O_Codeas.ToArray, MapRectCheckF)
    End Sub
    ''' <summary>
    ''' 複数オブジェクトを削除
    ''' </summary>
    ''' <param name="Num">数</param>
    ''' <param name="O_Code">オブジェクト番号の配列</param>
    ''' <param name="MapRectCheckF">地図データ全体の外接四角形をチェックするか</param>
    ''' <remarks></remarks>
    Public Sub Erase_MultiObjects(ByVal Num As Integer, ByVal O_Code() As Integer,
                                  ByVal MapRectCheckF As Boolean)
        '

        ReDim Preserve O_Code(Num - 1)
        Dim n As Integer
        Dim C_MpObj() As Integer = clsGeneric.Get_Convert_Array_of_DeletePartArray_old2new(Me.Map.Kend, O_Code, n)

        For i As Integer = 0 To Me.Map.Kend - 1
            If C_MpObj(i) <> -1 Then
                If C_MpObj(i) <> i Then
                    Me.MPObj(C_MpObj(i)) = Me.MPObj(i).Clone
                End If
            End If
        Next
        Me.Map.Kend -= n
        ReDim Preserve Me.MPObj(Math.Max(Me.Map.Kend - 1, 0))

        'オブジェクトの継承と集成オブジェクトをチェックする
        For i As Integer = 0 To Me.Map.Kend - 1
            With Me.MPObj(i)
                .Number = i '番号を振り直す
                Dim nsuc As Integer = 0
                For j As Integer = 0 To .NumOfSuc - 1
                    If C_MpObj(.SucSTC(j).ObjectCode) = -1 Then
                        nsuc += 1
                    Else
                        .SucSTC(j).ObjectCode = C_MpObj(.SucSTC(j).ObjectCode)
                        .SucSTC(j - nsuc) = .SucSTC(j)
                    End If
                Next
                .NumOfSuc -= nsuc
                If .NumOfSuc = 0 Then
                    Erase .SucSTC
                Else
                    ReDim Preserve .SucSTC(.NumOfSuc - 1)
                End If

                If Me.ObjectKind(.Kind).ObjectType = enmObjectGoupType_Data.AggregationObject Then
                    nsuc = 0
                    For j As Integer = 0 To .NumOfLine - 1
                        If C_MpObj(.LineCodeSTC(j).LineCode) = -1 Then
                            nsuc += 1
                        Else
                            .LineCodeSTC(j).LineCode = C_MpObj(.LineCodeSTC(j).LineCode)
                            .LineCodeSTC(j - nsuc) = .LineCodeSTC(j)
                        End If
                    Next
                    .NumOfLine -= nsuc
                    If .NumOfLine = 0 Then
                        Erase .LineCodeSTC
                    Else
                        ReDim Preserve .LineCodeSTC(.NumOfLine - 1)
                    End If

                End If
            End With
        Next
        If MapRectCheckF = True Then
            Me.Map.Circumscribed_Rectangle = Get_Mapfile_Rectangle()
        End If
        countNumOfLineUse()
    End Sub
    ''' <summary>
    ''' オブジェクトグループ構造体配列の指定位置を削除（使用していないことを確認してから使う）
    ''' </summary>
    ''' <param name="DeleteObjectGroupNumber">削除される番号</param>
    ''' <param name="obknum">オブジェクトグループ数</param>
    ''' <param name="ObjGroup">オブジェクトグループ構造体配列</param>
    ''' <remarks></remarks>
    Public Sub Erase_ObjectKind_Main(ByVal DeleteObjectGroupNumber As Integer, ByRef obknum As Integer,
                                     ByRef ObjGroup() As strObjectGroup_Data)

        For i As Integer = DeleteObjectGroupNumber + 1 To obknum - 1
            ObjGroup(i - 1) = ObjGroup(i).Clone
        Next

        For i As Integer = 0 To obknum - 2
            With ObjGroup(i)
                If .ObjectType = enmObjectGoupType_Data.AggregationObject Then
                    For j As Integer = obknum + 1 To obknum - 1
                        .UseObjectGroup(j - 1) = .UseObjectGroup(j)
                    Next
                    ReDim Preserve .UseObjectGroup(obknum - 2)
                End If
            End With
        Next
        obknum -= 1
    End Sub
    Public Sub Erase_ObjectKind(ByVal EraseOBKNum As Integer, ByVal MPObj_Change_F As Boolean)
        'オブジェクトグループ削除:使用していないことを確認してから使う

        Erase_ObjectKind_Main(EraseOBKNum, Me.Map.OBKNum, Me.ObjectKind)

        If MPObj_Change_F = True Then
            '各オブジェクトグループ変更
            For i As Integer = 0 To Me.Map.Kend - 1
                With Me.MPObj(i)
                    If .Kind > EraseOBKNum Then
                        .Kind -= 1
                    End If
                End With
            Next
        End If


    End Sub
    ''' <summary>
    ''' 線種統合
    ''' </summary>
    ''' <param name="Combinef">統合する線種にtrueを入れた配列</param>
    ''' <param name="newName">統合後の名称</param>
    ''' <param name="NewLPat">統合後のラインパターン</param>
    ''' <returns>統合前後の線種を変換する配列</returns>
    ''' <remarks></remarks>
    Public Function Combine_Linekinds(ByVal Combinef() As Boolean, ByVal newName As String, ByVal NewLPat As Line_Property) As Integer()
        '
        Dim change_Kind(Me.Map.LpNum - 1) As Integer
        Dim P_LK(Me.Map.LpNum - 1) As LineKind_Data
        Dim P_UseLine_by_ObjectKind(Me.Map.OBKNum - 1, Me.Map.LpNum - 1) As Boolean


        Dim n As Integer = 0

        For i As Integer = 0 To Me.Map.LpNum - 1
            If Combinef(i) = True Then
                n += 1
            End If
            P_LK(i) = Me.LineKind(i)
            For j As Integer = 0 To Me.Map.OBKNum - 1
                If Me.ObjectKind(j).ObjectType = enmObjectGoupType_Data.NormalObject Then
                    P_UseLine_by_ObjectKind(j, i) = Me.ObjectKind(j).UseLineType(i)
                End If
            Next
        Next

        Dim New_code As Integer
        Dim s As Integer = 0
        Dim f As Boolean = False
        For i As Integer = 0 To Me.Map.LpNum - 1
            If Combinef(i) = True Then
                If f = False Then
                    f = True
                    New_code = i
                    s += 1
                End If
                change_Kind(i) = New_code
            Else
                change_Kind(i) = s
                s += 1
            End If
        Next

        For i As Integer = 0 To Me.Map.LpNum - 1
            Me.LineKind(change_Kind(i)) = P_LK(i)
        Next
        Me.LineKind(New_code).Name = newName
        Me.LineKind(New_code).ObjGroup(0).Pattern = NewLPat


        For i As Integer = 0 To Me.Map.OBKNum - 1
            ReDim Me.ObjectKind(i).UseLineType(Math.Max(Me.Map.LpNum - n, 0))
            For j As Integer = 0 To Me.Map.LpNum - 1
                Dim k As Integer = change_Kind(j)
                Me.ObjectKind(i).UseLineType(k) = Me.ObjectKind(i).UseLineType(k) Or P_UseLine_by_ObjectKind(i, j)
            Next
        Next


        Me.Map.LpNum = Me.Map.LpNum - n + 1
        For i As Integer = 0 To Me.Map.ALIN - 1
            For j = 0 To Me.MPLine(i).NumOfTime - 1
                With Me.MPLine(i).LineTimeSTC(j)
                    .Kind = change_Kind(.Kind)
                End With
            Next
        Next
        Return change_Kind
    End Function
    ''' <summary>
    ''' オブジェクトグループ統合
    ''' </summary>
    ''' <param name="Combinef">統合するオブジェクトグループにtrueを入れた配列</param>
    ''' <param name="newname">統合後の名称</param>
    ''' <returns>統合前後のオブジェクトグループを変換する配列</returns>
    ''' <remarks></remarks>
    Public Function Combine_Objectkinds(ByVal Combinef() As Boolean, ByVal newname As String) As Integer()


        Dim P_OBK(Me.Map.OBKNum - 1) As strObjectGroup_Data
        For i As Integer = 0 To Me.Map.OBKNum - 1
            P_OBK(i) = Me.ObjectKind(i).Clone
        Next
        Dim New_code As Integer
        Dim Old_knum As Integer = Me.Map.OBKNum

        Dim change_Kind(Old_knum - 1) As Integer
        Dim s As Integer = 0
        Dim f As Boolean = False
        Dim n As Integer = 0
        For i As Integer = 0 To Old_knum - 1
            If Combinef(i) = True Then
                n += 1
                If f = False Then
                    '選択したグループは選択した最初のオブジェクトグループの位置に統合される
                    Me.ObjectKind(s) = P_OBK(i)
                    f = True
                    New_code = i
                    s = s + 1
                End If
                change_Kind(i) = New_code
            Else
                Me.ObjectKind(s) = P_OBK(i)
                change_Kind(i) = s
                s += 1
            End If
        Next

        For i As Integer = 0 To Me.Map.OBKNum - 1
            If change_Kind(i) = New_code Then
                With Me.ObjectKind(New_code)
                    If .ObjectType = enmObjectGoupType_Data.NormalObject Then
                        For j As Integer = 0 To Me.Map.LpNum - 1
                            .UseLineType(j) = .UseLineType(j) Or P_OBK(i).UseLineType(j)
                        Next
                    Else
                        For j As Integer = 0 To Old_knum - 1
                            .UseObjectGroup(j) = .UseObjectGroup(j) Or P_OBK(i).UseObjectGroup(j)
                        Next
                    End If
                End With
            End If
        Next
        Me.ObjectKind(New_code).Name = newname

        Me.Map.OBKNum = Me.Map.OBKNum - n + 1


        For i As Integer = 0 To Me.Map.Kend - 1
            Me.MPObj(i).Kind = change_Kind(Me.MPObj(i).Kind)
        Next

        '集成オブジェクトの使用グループ
        Dim r_UseObjectGroup() As Boolean

        For i As Integer = 0 To Me.Map.OBKNum - 1
            With Me.ObjectKind(i)
                If .ObjectType = enmObjectGoupType_Data.AggregationObject Then
                    r_UseObjectGroup = .UseObjectGroup
                    ReDim .UseObjectGroup(Me.Map.OBKNum - 1)
                    For j As Integer = 0 To Old_knum - 1
                        .UseObjectGroup(change_Kind(j)) = .UseObjectGroup(change_Kind(j)) Or r_UseObjectGroup(j)
                    Next
                End If
            End With
        Next


        '線種のオブジェクトグループ連動型のグループ設定
        For i As Integer = 0 To Me.Map.LpNum - 1
            With Me.LineKind(i)
                For j As Integer = 1 To .NumofObjectGroup - 1
                    .ObjGroup(j).GroupNumber = change_Kind(.ObjGroup(j).GroupNumber)
                Next
            End With
        Next
        Return change_Kind
    End Function


    Public Function Get_Mapfile_Rectangle() As RectangleF
        '地図ファイルの外接四角形を計算して返す
        Dim MapRec As RectangleF
        Dim f As Boolean = False
        If Me.Map.ALIN > 0 Then
            MapRec = New RectangleF(Me.MPLine(0).PointSTC(0), New Size(0, 0))

            For i As Integer = 0 To Me.Map.ALIN - 1
                MapRec = spatial.Get_Circumscribed_Rectangle(Me.MPLine(i).Circumscribed_Rectangle, MapRec)
            Next
            f = True
        End If

        For i As Integer = 0 To Me.Map.Kend - 1
            For j As Integer = 0 To Me.MPObj(i).NumOfCenterP - 1
                With Me.MPObj(i).CenterPSTC(j)
                    If f = False Then
                        MapRec = New RectangleF(.Position, New Size(0, 0))
                        f = True
                    Else
                        MapRec = spatial.Get_Circumscribed_Rectangle(.Position, MapRec)
                    End If
                End With
            Next
        Next
        If f = False Then
            MapRec = Me.Map.Circumscribed_Rectangle
        ElseIf MapRec.Size.Width = 0 And MapRec.Size.Height = 0 Then
            MapRec.Inflate(Me.Map.Circumscribed_Rectangle.Width / 2, Me.Map.Circumscribed_Rectangle.Height / 2)
        End If
        Return MapRec
    End Function

    Public Function Get_LineKind_Use_Number() As Integer()
        '線種ごとの使用回数を求める
        Dim LNum_by_Lkind(Me.Map.LpNum) As Integer


        For i As Integer = 0 To Me.Map.ALIN - 1
            For j As Integer = 0 To Me.MPLine(i).NumOfTime - 1
                Dim k As Integer = Me.MPLine(i).LineTimeSTC(j).Kind
                LNum_by_Lkind(k) = LNum_by_Lkind(k) + 1
            Next
        Next
        Return LNum_by_Lkind
    End Function
    ''' <summary>
    ''' オブジェクトグループごとのオブジェクト数を求める
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_ObjectKind_Use_Number() As Integer()

        Dim ObkNum_by_Obkkind(Me.Map.OBKNum - 1) As Integer

        For i As Integer = 0 To Me.Map.Kend - 1
            Dim k As Integer = Me.MPObj(i).Kind
            ObkNum_by_Obkkind(k) += 1
        Next
        Return ObkNum_by_Obkkind
    End Function
    ''' <summary>
    ''' 指定したオブジェクトグループのオブジェクトを抽出して配列に取得(時間指定なし)
    ''' </summary>
    ''' <param name="ObjGroup"></param>
    ''' <param name="Get_Objects"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Objects_by_Group(ByVal ObjGroup As Integer, ByRef Get_Objects() As Integer) As Integer

        Dim OG(Me.Map.Kend - 1) As Integer

        Dim n As Integer = 0
        For i As Integer = 0 To Me.Map.Kend - 1
            If Me.MPObj(i).Kind = ObjGroup Then
                OG(n) = i
                n += 1
            End If
        Next
        ReDim Preserve OG(n)
        Get_Objects = OG
        Return n
    End Function
    ''' <summary>
    ''' 指定したオブジェクトグループのオブジェクトを抽出して配列に取得(時間指定)
    ''' </summary>
    ''' <param name="ObjGroup"></param>
    ''' <param name="Get_Objects"></param>
    ''' <param name="Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Objects_by_Group(ByVal ObjGroup As Integer, ByRef Get_Objects() As Integer, ByVal Time As strYMD) As Integer

        Dim OG(Me.Map.Kend - 1) As Integer

        Dim n As Integer = 0
        For i As Integer = 0 To Me.Map.Kend - 1
            If Me.MPObj(i).Kind = ObjGroup Then
                If CheckEnableObject(Me.MPObj(i), Time) = True Then
                    OG(n) = i
                    n += 1
                End If
            End If
        Next
        If n = 0 Then
            OG = Nothing
        Else
            ReDim Preserve OG(n - 1)
        End If
        Get_Objects = OG
        Return n
    End Function
    Public Function Get_ObjGroupNumber(ByVal ObjGName As String) As Integer
        'オブジェクトグループ名からその番号を取得
        '見つからなかった場合は-1を返す
        For i As Integer = 0 To Me.Map.OBKNum - 1
            If Me.ObjectKind(i).Name = ObjGName Then
                Return i
            End If
        Next
        Return -1
    End Function
    Public Function Get_Objects_by_AllGroup(ByRef Get_Objects(,) As Integer, ByVal Time As strYMD) As Integer()
        '全オブジェクトグループのオブジェクト番号を抽出して配列に取得

        Dim OG(,) As Integer
        Dim ObjGroupNum(Me.Map.OBKNum - 1) As Integer

        If Me.Map.Kend = 0 Then
            ReDim OG(Me.Map.OBKNum - 1, Me.Map.Kend)
        Else
            ReDim OG(Me.Map.OBKNum - 1, Me.Map.Kend - 1)
            For i As Integer = 0 To Me.Map.Kend - 1
                If CheckEnableObject(Me.MPObj(i), Time) = True Then
                    Dim ok As Integer = Me.MPObj(i).Kind
                    OG(ok, ObjGroupNum(ok)) = i
                    ObjGroupNum(ok) = ObjGroupNum(ok) + 1
                End If
            Next

            Dim k As Integer = ObjGroupNum(0)
            For i As Integer = 1 To Me.Map.OBKNum - 1
                If k < ObjGroupNum(i) Then
                    k = ObjGroupNum(i)
                End If
            Next
            ReDim Preserve OG(Me.Map.OBKNum - 1, k)
        End If
        Get_Objects = OG
        Return ObjGroupNum
    End Function

    ''' <summary>
    ''' 指定したラインコードを使用しているオブジェクト番号を取得
    ''' </summary>
    ''' <param name="LineCode">ラインコード</param>
    ''' <param name="ObjectCode">オブジェクト番号（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Object_Using_Particular_Line(ByVal LineCode As Integer, ByRef ObjectCode() As Integer) As Integer
        '
        Dim n As Integer = 0
        ReDim ObjectCode(10)
        For i As Integer = 0 To Me.Map.Kend - 1
            With Me.MPObj(i)
                If Me.ObjectKind(.Kind).ObjectType = enmObjectGoupType_Data.NormalObject Then
                    For j As Integer = 0 To .NumOfLine - 1
                        If .LineCodeSTC(j).LineCode = LineCode Then
                            If UBound(ObjectCode) < n Then
                                ReDim Preserve ObjectCode(n + 10)
                            End If
                            ObjectCode(n) = i
                            n += 1
                            Exit For
                        End If
                    Next
                End If
            End With
        Next
        Return n
    End Function
    ''' <summary>
    ''' 複数のラインを結合する
    ''' </summary>
    ''' <param name="LNum">対象ライン数</param>
    ''' <param name="Lstac">結合対象のライン番号</param>
    ''' <returns>残ったライン番号のList(Of Integer)</returns>
    ''' <remarks></remarks>
    Public Function Connect_Line(ByVal LNum As Integer, ByVal Lstac() As Integer) As List(Of Integer)
        '

        'If Progress_f = True Then
        '    ProgressLabel.Visible = True
        'End If

        '単精度座標の浮動小数点演算に伴う誤差をなくすために端点を数値化
        '
        For j As Integer = 0 To Me.Map.ALIN - 1
            With Me.MPLine(j)
                With .PointSTC(0)
                    .X = CSng(CDec(.X))
                    .Y = CSng(CDec(.Y))
                End With
                With .PointSTC(.NumOfPoint - 1)
                    .X = CSng(CDec(.X))
                    .Y = CSng(CDec(.Y))
                End With
                With .Circumscribed_Rectangle
                    .X = CSng(CDec(.X))
                    .Y = CSng(CDec(.Y))
                    .Width = CSng(CDec(.Width))
                    .Height = CSng(CDec(.Height))
                End With
            End With
        Next

        Dim restLine As New List(Of Integer)
        restLine.AddRange(Lstac)
        Dim i As Integer = 0
        Do
            'If Progress_f = True Then
            '    If i Mod 10 = 0 Then
            '        ProgressLabel.Start(LNum, "ライン結合中")
            '        ProgressLabel.SetValue(i)
            '        DoEvents()
            '    End If
            'End If
            Dim checkLineNumber As Integer = Lstac(i)
            Dim ssxy As PointF
            Dim eexy As PointF
            With Me.MPLine(checkLineNumber)
                ssxy = .PointSTC(0)
                eexy = .PointSTC(.NumOfPoint - 1)
            End With
            If eexy.Equals(ssxy) = True Then
                'ループの場合
                i += 1
            Else
                Dim StartCheckedLineNumber As Integer
                Dim EndCheckedLineNumber As Integer
                Dim StartPointDirection As enmDirection
                Dim EndPointDirection As enmDirection
                Dim StartConnectNum As Integer = 0
                Dim EndConnectNum As Integer = 0
                For j As Integer = 0 To LNum - 1
                    Dim checkLineNumber2 As Integer = Lstac(j)
                    If checkLineNumber <> checkLineNumber2 Then
                        Dim ssxy2 As PointF, eexy2 As PointF
                        With Me.MPLine(checkLineNumber2)
                            ssxy2 = .PointSTC(0)
                            eexy2 = .PointSTC(.NumOfPoint - 1)
                        End With
                        If ssxy.Equals(ssxy2) = True Then
                            '始点と始点が一致
                            StartCheckedLineNumber = checkLineNumber2
                            StartPointDirection = enmDirection.Reverse
                            StartConnectNum += 1
                        End If
                        If ssxy.Equals(eexy2) = True Then
                            '始点と終点が一致
                            StartCheckedLineNumber = checkLineNumber2
                            StartPointDirection = enmDirection.Forward
                            StartConnectNum += 1
                        End If

                        If eexy.Equals(ssxy2) = True Then
                            '終点と始点が一致
                            EndCheckedLineNumber = checkLineNumber2
                            EndPointDirection = enmDirection.Reverse
                            EndConnectNum += 1
                        End If

                        If eexy.Equals(eexy2) = True Then
                            '終点と終点が一致
                            EndCheckedLineNumber = checkLineNumber2
                            EndPointDirection = enmDirection.Forward
                            EndConnectNum += 1
                        End If
                    End If
                Next
                If StartConnectNum = 1 Or EndConnectNum = 1 Then
                    '一致しているのが一カ所の場合
                    Dim ConnectOk As Boolean = ConnctLine_Sub(LNum, Lstac, checkLineNumber, _
                                                              StartCheckedLineNumber, StartConnectNum, StartPointDirection, _
                                                              EndCheckedLineNumber, EndConnectNum, EndPointDirection, restLine)
                    If ConnectOk = False Then
                        i += 1
                    End If
                Else
                    i += 1
                End If
            End If
        Loop While i < LNum - 1
        Return restLine
        'If Progress_f = True Then
        '    ProgressLabel.Visible = False
        'End If
    End Function
    ''' <summary>
    ''' ライン結合のサブ
    ''' </summary>
    ''' <param name="LNum"></param>
    ''' <param name="Lstac"></param>
    ''' <param name="checkLineNumber"></param>
    ''' <param name="StartCheckedLineNumber"></param>
    ''' <param name="StartConnectNum"></param>
    ''' <param name="StartPointDirection"></param>
    ''' <param name="EndCheckedLineNumber"></param>
    ''' <param name="EndConnectNum"></param>
    ''' <param name="EndPointDirection"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConnctLine_Sub(ByRef LNum As Integer, ByRef Lstac() As Integer, ByVal checkLineNumber As Integer, _
                                           ByVal StartCheckedLineNumber As Integer, ByVal StartConnectNum As Integer, ByVal StartPointDirection As enmDirection, _
                                            ByVal EndCheckedLineNumber As Integer, ByVal EndConnectNum As Integer, ByVal EndPointDirection As enmDirection,
                                           ByRef restLine As List(Of Integer)) As Boolean



        Dim ConnectOk As Boolean = False

        Dim n As Integer = Me.MPLine(checkLineNumber).NumOfPoint

        If StartConnectNum = 1 Then
            '始点が一致した場合
            Dim n2 As Integer
            If Check_Connect_Two_Line(checkLineNumber, StartCheckedLineNumber) = True Then
                With Me.MPLine(StartCheckedLineNumber)
                    n2 = .NumOfPoint
                End With
                Dim PushLine As clsMapData.strLine_Data = Me.MPLine(checkLineNumber).Clone
                PushLine.NumOfPoint += n2 - 1
                ReDim PushLine.PointSTC(PushLine.NumOfPoint - 1)
                Dim nAP As Integer
                Select Case StartPointDirection
                    Case enmDirection.Reverse
                        '始点と始点が一致
                        'Array.Copy(Me.MPLine(StartCheckedLineNumber).PointSTC, PushLine.PointSTC, n2)
                        'Array.Reverse(PushLine.PointSTC, 0, n)
                        'Array.Copy(Me.MPLine(checkLineNumber).PointSTC, 1, PushLine.PointSTC, n2, n - 2)
                        nAP = 0
                        For i As Integer = n2 - 1 To 0 Step -1
                            PushLine.PointSTC(nAP) = Me.MPLine(StartCheckedLineNumber).PointSTC(i)
                            nAP += 1
                        Next
                        For i As Integer = 1 To n - 1
                            PushLine.PointSTC(nAP) = Me.MPLine(checkLineNumber).PointSTC(i)
                            nAP += 1
                        Next
                        'MoveMemory(PushLine.PointSTC(n2), MapData.MPLine(checkLineNumber).PointSTC(1), (n - 1) * LenB(MapData.MPLine(checkLineNumber).PointSTC(1)))
                    Case enmDirection.Forward
                        '始点と終点が一致
                        nAP = 0
                        For i As Integer = 0 To n2 - 1
                            PushLine.PointSTC(nAP) = Me.MPLine(StartCheckedLineNumber).PointSTC(i)
                            nAP += 1
                        Next
                        For i As Integer = 1 To n - 1
                            PushLine.PointSTC(nAP) = Me.MPLine(checkLineNumber).PointSTC(i)
                            nAP += 1
                        Next
                        'MoveMemory(PushLine.PointSTC(0), MapData.MPLine(SCN).PointSTC(0), n2 * LenB(MapData.MPLine(SCN).PointSTC(0)))
                        'MoveMemory(PushLine.PointSTC(n2), MapData.MPLine(checkLineNumber).PointSTC(1), (n - 1) * LenB(MapData.MPLine(SCN).PointSTC(0)))
                End Select
                Call Connect_Line_Stac_Change(PushLine, checkLineNumber, StartCheckedLineNumber, LNum, Lstac, restLine)
                ConnectOk = True
            End If
        End If

        If EndConnectNum = 1 And StartConnectNum = 1 And StartCheckedLineNumber = EndCheckedLineNumber Then
            Return False
        End If

        If EndConnectNum = 1 Then
            '終点が一致した場合
            Dim n2 As Integer
            If StartConnectNum = 1 And ConnectOk = True Then
                'すでに始点が一致していて、結合してある場合
                If EndCheckedLineNumber > StartCheckedLineNumber Then
                    EndCheckedLineNumber -= 1
                End If
                With Me.MPLine(checkLineNumber)
                    n = .NumOfPoint
                End With
            End If
            If Check_Connect_Two_Line(checkLineNumber, EndCheckedLineNumber) = True Then
                With Me.MPLine(EndCheckedLineNumber)
                    n2 = .NumOfPoint
                End With
                Dim PushLine As clsMapData.strLine_Data = Me.MPLine(checkLineNumber).Clone
                PushLine.NumOfPoint = PushLine.NumOfPoint + n2 - 1
                ReDim PushLine.PointSTC(PushLine.NumOfPoint - 1)
                Dim nAP As Integer
                Select Case EndPointDirection
                    Case enmDirection.Reverse
                        '終点と始点が一致
                        nAP = 0
                        For i As Integer = 0 To n - 1
                            PushLine.PointSTC(nAP) = Me.MPLine(checkLineNumber).PointSTC(i)
                            nAP += 1
                        Next
                        For i As Integer = 1 To n2 - 1
                            PushLine.PointSTC(nAP) = Me.MPLine(EndCheckedLineNumber).PointSTC(i)
                            nAP += 1
                        Next

                        'MoveMemory(PushLine.PointSTC(0), MapData.MPLine(checkLineNumber).PointSTC(0), n * LenB(MapData.MPLine(SCN).PointSTC(0)))
                        'MoveMemory(PushLine.PointSTC(n), MapData.MPLine(ECN).PointSTC(1), (n2 - 1) * LenB(MapData.MPLine(SCN).PointSTC(0)))
                    Case enmDirection.Forward
                        '終点と終点が一致
                        'MoveMemory(PushLine.PointSTC(0), MapData.MPLine(checkLineNumber).PointSTC(0), (n - 1) * LenB(MapData.MPLine(checkLineNumber).PointSTC(0)))
                        nAP = 0
                        For i As Integer = 0 To n - 2
                            PushLine.PointSTC(nAP) = Me.MPLine(checkLineNumber).PointSTC(i)
                            nAP += 1
                        Next
                        For i As Integer = n2 - 1 To 0 Step -1
                            PushLine.PointSTC(nAP) = Me.MPLine(EndCheckedLineNumber).PointSTC(i)
                            nAP += 1
                        Next
                End Select
                Connect_Line_Stac_Change(PushLine, checkLineNumber, EndCheckedLineNumber, LNum, Lstac, restLine)
                ConnectOk = True
            End If
        End If
        Return ConnectOk
    End Function
    ''' <summary>
    ''' ライン結合で、結合先のラインを削除、スタックのライン番号変更、結合もとのライン保存
    ''' </summary>
    ''' <param name="PushLine"></param>
    ''' <param name="checkLineNumber"></param>
    ''' <param name="CheckedLineNumber2"></param>
    ''' <param name="LNum"></param>
    ''' <param name="Lstac"></param>
    ''' <remarks></remarks>
    Private Sub Connect_Line_Stac_Change(ByRef PushLine As clsMapData.strLine_Data, ByRef checkLineNumber As Integer, ByVal CheckedLineNumber2 As Integer, _
                                                ByRef LNum As Integer, ByVal Lstac() As Integer, ByRef restLine As List(Of Integer))

        spatial.Get_Circumscribed_Rectangle(Me.MPLine(CheckedLineNumber2).Circumscribed_Rectangle, PushLine.Circumscribed_Rectangle)

        'CheckedLineNumber2のラインを削除
        Dim rn As Integer = restLine.IndexOf(CheckedLineNumber2)
        If rn <> -1 Then
            restLine.RemoveAt(rn)
        End If
        For i As Integer = 0 To restLine.Count - 1
            If CheckedLineNumber2 < restLine.Item(i) Then
                restLine.Item(i) -= 1
            End If
        Next
        Erase_Line(CheckedLineNumber2, False)

        For i As Integer = 0 To LNum - 1
            If Lstac(i) = CheckedLineNumber2 Then
                For j As Integer = i + 1 To LNum - 1
                    Lstac(j - 1) = Lstac(j)
                Next
                Exit For
            End If
        Next
        If checkLineNumber > CheckedLineNumber2 Then
            checkLineNumber -= 1
            PushLine.Number -= 1
        End If
        LNum -= 1
        For i As Integer = 0 To LNum - 1
            If Lstac(i) > CheckedLineNumber2 Then
                Lstac(i) = Lstac(i) - 1
            End If
        Next
        Me.Save_Line(PushLine, True, True, True)
    End Sub



    ''' <summary>
    ''' 二つのラインが、結合可能かをチェック(線種、ラインの時間設定、ラインを使用するオブジェクトの使用期間)して、可能ならtrueを返す
    ''' </summary>
    ''' <param name="L_Code1">ライン1のライン番号</param>
    ''' <param name="L_Code2">ライン2のライン番号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_Connect_Two_Line(ByVal L_Code1 As Integer, ByVal L_Code2 As Integer) As Boolean


        Dim f As Boolean = False
        If clsTime.Check_Time_Of_Two_Lines(L_Code1, L_Code2, Me) = True Then
            Dim Line_UseObject1() As Integer
            Dim Line_UseObject2() As Integer
            Dim Line_UseObject1Num As Integer = Get_Object_UsingLine(L_Code1, Line_UseObject1)
            Dim Line_UseObject2Num As Integer = Get_Object_UsingLine(L_Code2, Line_UseObject2)
            If Line_UseObject2Num <> Line_UseObject1Num Then
                '二つのラインでオブジェクトの使用回数が異なる場合はfalse
                f = False
            Else
                f = True
                For i As Integer = 0 To Line_UseObject1Num - 1
                    f = False
                    Dim f2 As Boolean
                    For j As Integer = 0 To Line_UseObject2Num - 1
                        If Line_UseObject1(i) = Line_UseObject2(j) Then
                            f2 = True
                            '結合予定の二つのラインを、同一のオブジェクトが使用している場合に、
                            '使用期間が同じかどうかをチェックする
                            f = Check_Object_Use_Line_Time(L_Code1, Line_UseObject1(i), L_Code2, Line_UseObject2(j))
                            If f = False Then
                                Exit For
                            End If
                        End If
                    Next
                    If f2 = False Then
                        f = False
                    End If
                    If f = False Then
                        Exit For
                    End If
                Next
            End If
        End If
        Return f
    End Function
    ''' <summary>
    ''' 指定したラインを使用する、二つのオブジェクトの、使用期間が同じかどうかチェックし、同じならtrueを返す
    ''' </summary>
    ''' <param name="L_Code1">ライン番号1</param>
    ''' <param name="O_Code1">ライン番号1を使用するオブジェクト番号</param>
    ''' <param name="L_Code2">ライン番号2</param>
    ''' <param name="O_Code2">ライン番号2を使用するオブジェクト番号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_Object_Use_Line_Time(ByVal L_Code1 As Integer, ByVal O_Code1 As Integer, _
                                                       ByVal L_Code2 As Integer, ByVal O_Code2 As Integer) As Boolean

        Dim s1 As Integer = -1
        With Me.MPObj(O_Code1)
            For i As Integer = 0 To .NumOfLine - 1
                If .LineCodeSTC(i).LineCode = L_Code1 Then
                    s1 = i
                    Exit For
                End If
            Next
        End With

        Dim s2 As Integer = -1
        With Me.MPObj(O_Code2)
            For i As Integer = 0 To .NumOfLine - 1
                If .LineCodeSTC(i).LineCode = L_Code2 Then
                    s2 = i
                    Exit For
                End If
            Next
        End With

        If s1 = -1 Or s2 = -1 Then
            '使用されていなかった場合はfalse
            Return False
        End If

        Dim f As Boolean
        Dim n As Integer = Me.MPObj(O_Code1).LineCodeSTC(s1).NumOfTime
        If n = Me.MPObj(O_Code2).LineCodeSTC(s2).NumOfTime Then
            'オブジェクトの使用ラインの期間数が同じ場合
            If n = 0 Then
                'n=0の場合はtrue
                f = True
            Else
                For i As Integer = 0 To n - 1
                    f = False
                    With Me.MPObj(O_Code1).LineCodeSTC(s1).Times(i)
                        For j As Integer = 0 To n - 1
                            If .Equals(Me.MPObj(O_Code2).LineCodeSTC(s2).Times(j)) = True Then
                                f = True
                                Exit For
                            End If
                        Next
                    End With
                    If f = False Then
                        '一致しない箇所があった場合はfalse
                        Exit For
                    End If
                Next
            End If
        Else
            'オブジェクトの使用ラインの期間数が異なる場合はfalse
            f = False
        End If
        Return f
    End Function
    ''' <summary>
    ''' 指定したラインコードを使用しているオブジェクト番号を入れ、数を返す
    ''' </summary>
    ''' <param name="L_Code">調べるラインコード</param>
    ''' <param name="O_Code">オブジェクト番号（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Object_UsingLine(ByVal L_Code As Integer, ByRef O_Code() As Integer) As Integer

        ReDim O_Code(10)
        Dim n As Integer = 0
        For i As Integer = 0 To Me.Map.Kend - 1
            With Me.MPObj(i)
                If Me.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                    For j As Integer = 0 To .NumOfLine - 1
                        Dim L As Integer = .LineCodeSTC(j).LineCode
                        If L = L_Code Then
                            If UBound(O_Code) < n Then
                                ReDim Preserve O_Code(n + 10)
                            End If
                            O_Code(n) = i
                            n += 1
                            Exit For
                        End If
                    Next
                End If
            End With
        Next
        Return n
    End Function
    ''' <summary>
    ''' 指定したオブジェクトを結合して新規オブジェクトとして取得（保存までは行わない）
    ''' </summary>
    ''' <param name="Num">結合するオブジェクトの数</param>
    ''' <param name="O_Code">結合するオブジェクト番号の配列</param>
    ''' <param name="C_Time"></param>
    ''' <remarks></remarks>
    Public Function Combine_Objects(ByVal newObjectName As String(), ByVal Num As Integer, ByVal O_Code() As Integer, _
                                     ByVal C_Time As strYMD) As strObj_Data

        Dim PushObj As New clsMapData.strObj_Data
        Dim Use_Line() As Integer
        Dim U_Line() As clsMapData.EnableMPLine_Data
        Dim U_Obj() As Integer

        '新しいオブジェクトのオブジェクトグループは最初のオブジェクトのものを使用
        PushObj = Init_One_Object(Me.MPObj(O_Code(0)).Kind)
        PushObj.NameTimeSTC(0).NamesList = newObjectName.Clone

        Dim mxn As Integer
        If Me.ObjectKind(MPObj(O_Code(0)).Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
            '通常のオブジェクトの場合
            Dim n2 As Integer = 0
            mxn = Me.Map.ALIN
            ReDim Use_Line(mxn)
            For i As Integer = 0 To Num - 1
                Dim n3 As Integer = Get_EnableMPLine(U_Line, Me.MPObj(O_Code(i)), C_Time)
                For j As Integer = 0 To n3 - 1
                    Use_Line(U_Line(j).LineCode) += 1
                Next
                n2 += n3
            Next
            If n2 = 0 Then
                Erase PushObj.LineCodeSTC
            Else
                ReDim PushObj.LineCodeSTC(n2 - 1)
            End If
        Else
            '集成オブジェクトの場合
            Dim n2 As Integer = 0
            mxn = Me.Map.Kend
            ReDim Use_Line(mxn)
            For i As Integer = 0 To Num - 1
                Dim n3 As Integer = Get_EnableObj_used_AggregateObject(Me.MPObj(O_Code(i)), C_Time, U_Obj)
                For j As Integer = 0 To n3 - 1
                    Use_Line(U_Obj(j)) += 1
                Next
                n2 += n3
            Next
            If n2 = 0 Then
                Erase PushObj.LineCodeSTC
            Else
                ReDim PushObj.LineCodeSTC(n2 - 1)
            End If
        End If

        Dim n As Integer = 0
        For i As Integer = 0 To mxn - 1
            If Use_Line(i) = 1 Then
                PushObj.LineCodeSTC(n).LineCode = i
                n += 1
            End If
        Next
        PushObj.NumOfLine = n


        Dim Shape(2) As Integer

        '代表点は個々のオブジェクトの重心に設定
        Dim X As Single = 0
        Dim Y As Single = 0
        For i As Integer = 0 To Num - 1
            With Me.MPObj(O_Code(i))
                Shape(.Shape) += 1
                X += .CenterPSTC(0).Position.X
                Y += .CenterPSTC(0).Position.Y
            End With
        Next
        With PushObj.CenterPSTC(0)
            If Shape(2) = Num Then
                'すべてが面形状だった場合は、通常の重心の位置を求める
                PushObj.Shape = enmShape.PolygonShape
                GetObjGraviityXY(PushObj, .Position, clsTime.GetNullYMD)
            Else
                PushObj.Shape = Check_Obj_Shape(PushObj, clsTime.GetNullYMD)
                .Position.X = X / Num
                .Position.Y = Y / Num
            End If
        End With

        '初期属性の処理，時空間モードでは初期属性は加算しない

        If Map.Time_Mode = False Then
            Dim DefNum As Integer = Me.ObjectKind(PushObj.Kind).DefTimeAttDataNum
            If DefNum > 0 Then
                Dim defattSub() As String
                Dim DefAttO(DefNum - 1, Num - 1) As String
                Dim DefAttNew(DefNum - 1) As String
                For i As Integer = 0 To Num - 1
                    For j As Integer = 0 To DefNum - 1
                        DefAttO(j, i) = Me.MPObj(O_Code(i)).DefTimeAttValue(j).Data(0).Value
                    Next
                Next

                For i As Integer = 0 To DefNum - 1
                    Dim UNT As String = UCase(Me.ObjectKind(PushObj.Kind).DefTimeAttSTC(i).attData.Unit)
                    ReDim defattSub(Num - 1)
                    For j As Integer = 0 To Num - 1
                        If UNT = "CAT" Or UNT = "STR" Then
                            defattSub(j) = DefAttO(i, j)
                        Else
                            '通常のデータの場合は加算する
                            DefAttNew(i) = CStr(Val(DefAttNew(i)) + Val(DefAttO(i, j)))
                        End If
                    Next
                    If UNT = "CAT" Or UNT = "STR" Then
                        '文字列かカテゴリデータの場合は、同じ値の場合は一つにまとめ、異なる場合は/で区切って追加
                        Dim defattSubn As Integer = clsGeneric.Remove_Same_String(Num, defattSub)
                        ReDim Preserve defattSub(defattSubn - 1)
                        DefAttNew(i) = String.Join("/", defattSub)
                    End If
                Next

                For i As Integer = 0 To DefNum - 1
                    PushObj.DefTimeAttValue(i).Data(0).Value = DefAttNew(i)
                Next
            End If
        End If

        Return PushObj
    End Function
    ''' <summary>
    ''' 指定したオブジェクトを結合して新規オブジェクトとして取得（保存までは行わない）
    ''' </summary>
    ''' <param name="newObjectName">新規オブジェクトのオブジェクト名構造体</param>
    ''' <param name="OCodes">結合するオブジェクトコードのArryyList</param>
    ''' <param name="C_Time">結合時期</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Combine_Objects(ByVal newObjectName As String(), ByRef OCodes As List(Of Integer), _
                                 ByVal C_Time As strYMD) As strObj_Data
        Dim Values() As Integer = OCodes.ToArray
        Return Combine_Objects(newObjectName, Values.GetUpperBound(0) + 1, Values, C_Time)
    End Function
    ''' <summary>
    ''' 集成オブジェクトが直接使用するオブジェクトを取得
    ''' </summary>
    ''' <param name="ObjData"></param>
    ''' <param name="Time"></param>
    ''' <param name="Obj"></param>
    ''' <returns></returns
    ''' <remarks></remarks>
    Public Function Get_EnableObj_used_AggregateObject(ByRef ObjData As clsMapData.strObj_Data, ByVal Time As strYMD, _
                                                    ByRef Obj() As Integer) As Integer

        Dim pobj As New List(Of Integer)
        With ObjData
            For i As Integer = 0 To .NumOfLine - 1
                Dim lc As Integer = .LineCodeSTC(i).LineCode
                If CheckEnableObject(Me.MPObj(lc), Time) = True Then
                    pobj.Add(lc)
                End If
            Next
        End With
        Obj = pobj.ToArray
        Dim n As Integer = pobj.Count
        Return n
    End Function
    ''' <summary>
    ''' 指定したオブジェクトで、指定した時間に利用できるライン番号を戻し、その要素数を返す
    ''' </summary>
    ''' <param name="Enable_LCode"></param>
    ''' <param name="ObjData"></param>
    ''' <param name="Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_EnableMPLine_Normal(ByRef Enable_LCode() As clsMapData.EnableMPLine_Data, _
                                           ByRef ObjData As clsMapData.strObj_Data, _
                                           ByVal Time As strYMD) As Integer


        ReDim Enable_LCode(ObjData.NumOfLine)

        If Time.nullFlag = True Then
            With ObjData
                For i As Integer = 0 To .NumOfLine - 1
                    With .LineCodeSTC(i)
                        Enable_LCode(i).LineCode = .LineCode
                        Enable_LCode(i).Kind = Me.MPLine(.LineCode).LineTimeSTC(0).Kind
                    End With
                Next
                Return .NumOfLine
            End With
        Else
            If CheckEnableObject(ObjData, Time) = False Then
                Return 0
            End If
        End If



        Dim L_N As Integer = 0
        With ObjData
            For i As Integer = 0 To .NumOfLine - 1
                Dim L_K As Integer
                Dim f As Boolean = False
                Dim L_Code As Integer = Check_Enable_LineCode(.LineCodeSTC(i), Time)
                If L_Code <> -1 Then
                    L_K = Check_Enable_Line(Me.MPLine(L_Code), Time)
                    If L_K <> -1 Then
                        f = True
                    End If
                End If
                If f = True Then
                    If Me.Map.Time_Mode = True Then
                        If Me.ObjectKind(.Kind).UseLineType(L_K) = True Then
                            Enable_LCode(L_N).LineCode = L_Code
                            Enable_LCode(L_N).Kind = L_K
                            L_N = L_N + 1
                        End If
                    Else  '時空間モードでない地図の場合は線種の使用をチェックしない
                        Enable_LCode(L_N).LineCode = L_Code
                        Enable_LCode(L_N).Kind = L_K
                        L_N = L_N + 1
                    End If
                End If
            Next
        End With
        Return L_N
    End Function
    ''' <summary>
    '''  指定した時間のオブジェクトの代表点を取得、取得できない場合はfalseを返す
    ''' </summary>
    ''' <param name="P">取得される座標</param>
    ''' <param name="ObjCode">オブジェクト番号</param>
    ''' <param name="Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Enable_CenterP(ByRef P As PointF, ByVal ObjCode As Integer, ByVal Time As strYMD) As Boolean
        Return Get_Enable_CenterP(P.X, P.Y, Me.MPObj(ObjCode), Time)
    End Function
    ''' <summary>
    '''  指定した時間のオブジェクトの代表点を取得、取得できない場合はfalseを返す
    ''' </summary>
    ''' <param name="X">取得されるX座標</param>
    ''' <param name="Y">取得されるY座標</param>
    ''' <param name="ObjData"></param>
    ''' <param name="Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Enable_CenterP(ByRef X As Single, ByRef Y As Single, ByRef ObjData As clsMapData.strObj_Data, _
                                   ByVal Time As strYMD) As Boolean

        If CheckEnableObject(ObjData, Time) = False Then
            Return False
        End If

        X = 0 : Y = 0
        Dim cf As Boolean = False
        For i As Integer = 0 To ObjData.NumOfCenterP - 1
            With ObjData.CenterPSTC(i)
                If clsTime.checkDurationIn(.SETime, Time) = True Then
                    X = .Position.X
                    Y = .Position.Y
                    cf = True
                    Exit For
                End If
            End With
        Next
        Return cf
    End Function
    ''' <summary>
    ''' 指定した時間に指定したオブジェクトが存在する場合trueを返す
    ''' </summary>
    ''' <param name="ObjData"></param>
    ''' <param name="Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckEnableObject(ByRef ObjData As clsMapData.strObj_Data, ByVal Time As strYMD) As Boolean
        Dim cf As Boolean = False

        With ObjData
            For i As Integer = 0 To .NumOfNameTime - 1
                If clsTime.checkDurationIn(.NameTimeSTC(i).SETime, Time) = True Then
                    cf = True
                    Exit For
                End If
            Next
        End With

        Return cf
    End Function
    ''' <summary>
    ''' 指定されたオブジェクトで、指定された時期に使用可能なライン数と番号を返す
    ''' </summary>
    ''' <param name="Enable_LCode"></param>
    ''' <param name="ObjData"></param>
    ''' <param name="Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_EnableMPLine(ByRef Enable_LCode() As clsMapData.EnableMPLine_Data, ByRef ObjData As clsMapData.strObj_Data, _
                                  ByVal Time As strYMD) As Integer

        Dim E_LCode() As clsMapData.EnableMPLine_Data
        Dim AggObs() As Integer
        Dim LCode() As clsMapData.EnableMPLine_Data


        Dim ln As Integer = 0
        If Me.ObjectKind(ObjData.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
            Dim AggObsnum As Integer = Get_MpObj_used_AggregateObject(ObjData, Time, AggObs)
            Dim LCoden As Integer = 0
            For i As Integer = 0 To AggObsnum - 1
                Dim lc As Integer = AggObs(i)
                If Me.ObjectKind(Me.MPObj(lc).Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                    LCoden = Get_EnableMPLine_Normal(E_LCode, Me.MPObj(lc), Time)
                    ReDim Preserve LCode(LCoden + ln)
                    For j As Integer = 0 To LCoden - 1
                        LCode(ln + j) = E_LCode(j)
                    Next
                    ln = ln + LCoden
                End If
            Next
            ln = clsGeneric.Get_Outer_Mpline_AggregatedObj(ln, LCode, Me.ObjectKind(ObjData.Kind).Shape)
        Else
            ln = Get_EnableMPLine_Normal(LCode, ObjData, Time)
        End If
        Enable_LCode = LCode
        Return ln
    End Function
    ''' <summary>
    ''' 指定されたオブジェクト番号で、指定された時期に使用可能なライン数と番号を返す
    ''' </summary>
    ''' <param name="Enable_LCode"></param>
    ''' <param name="ObjCode"></param>
    ''' <param name="Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_EnableMPLine(ByRef Enable_LCode() As clsMapData.EnableMPLine_Data, ByVal ObjCode As Integer, _
                                  ByVal Time As strYMD) As Integer
        Return Get_EnableMPLine(Enable_LCode, MPObj(ObjCode), Time)
    End Function

    Private Enable_MPObjStac() As Integer 'Get_MpObj_used_AggregateObjectで使用
    Private Enable_MPObjStac_Num As Integer 'Get_MpObj_used_AggregateObjectで使用

    ''' <summary>
    ''' 集成オブジェクトを構成する元のオブジェクト番号を取得し、数を返す
    ''' </summary>
    ''' <param name="ObjData">元のオブジェクト</param>
    ''' <param name="Time"></param>
    ''' <param name="Obj">構成するオブジェクト番号（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_MpObj_used_AggregateObject(ByRef ObjData As clsMapData.strObj_Data, ByVal Time As strYMD, _
                                                ByRef Obj() As Integer) As Integer
        Me.Enable_MPObjStac_Num = 0

        Get_MpObj_used_AggregateObject_Sub(ObjData, Time)

        Obj = Me.Enable_MPObjStac
        Return Enable_MPObjStac_Num
    End Function
    ''' <summary>
    ''' 集成オブジェクトを構成する元のオブジェクト番号を取得、再帰処理を行う
    ''' </summary>
    ''' <param name="ObjData">元のオブジェクト</param>
    ''' <param name="Time"></param>
    ''' <remarks></remarks>
    Private Sub Get_MpObj_used_AggregateObject_Sub(ByRef ObjData As clsMapData.strObj_Data, ByVal Time As strYMD)

        With ObjData
            For i As Integer = 0 To .NumOfLine - 1
                Dim lc As Integer = Check_Enable_LineCode(.LineCodeSTC(i), Time)
                If lc <> -1 Then
                    If CheckEnableObject(Me.MPObj(lc), Time) = True Then
                        ReDim Preserve Enable_MPObjStac(Enable_MPObjStac_Num)
                        Me.Enable_MPObjStac(Enable_MPObjStac_Num) = lc
                        Me.Enable_MPObjStac_Num += 1
                        If Me.ObjectKind(Me.MPObj(lc).Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                            '集成オブジェクトを参照している場合はさらに再帰処理
                            Call Get_MpObj_used_AggregateObject_Sub(Me.MPObj(lc), Time)
                        End If
                    End If
                End If
            Next
        End With

    End Sub


    ''' <summary>
    ''' ラインコードスタックのラインが指定時期に利用できるかをチェック、
    ''' 利用できる場合はラインコード番号を返し，そうでない場合は－１を返す
    ''' </summary>
    ''' <param name="Lcode_Stac">ラインコードスタック</param>
    ''' <param name="Check_Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function Check_Enable_LineCode(ByRef Lcode_Stac As clsMapData.LineCodeStac_Data, ByVal Check_Time As strYMD) As Integer

        With Lcode_Stac
            If .NumOfTime = 0 Or Check_Time.nullFlag = True Then
                Return .LineCode
            Else
                For i As Integer = 0 To .NumOfTime - 1
                    If clsTime.checkDurationIn(.Times(i), Check_Time) = True Then
                        Return .LineCode
                    End If
                Next
            End If
        End With
        Return -1
    End Function
    ''' <summary>
    ''' ラインが指定時期に利用できるかをチェック
    ''' 利用できる場合は線種番号そうでない場合は-1を返す
    ''' </summary>
    ''' <param name="MpLine">ライン構造体</param>
    ''' <param name="Check_Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function Check_Enable_Line(ByRef MpLine As clsMapData.strLine_Data, ByVal Check_Time As strYMD) As Integer


        Dim L_K As Integer = -1
        With MpLine
            If Check_Time.nullFlag = True Then
                L_K = .LineTimeSTC(0).Kind
            Else
                For i As Integer = 0 To .NumOfTime - 1
                    With .LineTimeSTC(i)
                        If clsTime.checkDurationIn(.SETime, Check_Time) = True Then
                            L_K = .Kind
                            Exit For
                        End If
                    End With
                Next
            End If
        End With

        Return L_K
    End Function
    ''' <summary>
    ''' 地図ファイル中のオブジェクト名の重複をチェックし、重複していなければ-1を、重複している場合はそのコードを返す
    ''' </summary>
    ''' <param name="Ex_Code">比較しないオブジェクト番号</param>
    ''' <param name="Name"></param>
    ''' <param name="duration">調査期間</param>
    ''' <param name="StacPosition">重複が見つかったコードのNameTimeSTC内の位置（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_ObjectName_OverLap_In_MapFile(ByVal Ex_Code As Integer, ByVal Name As String, _
                    ByVal duration As Start_End_Time_data, Optional ByRef StacPosition As Integer = -1) As Integer


        Check_ObjectName_OverLap_In_MapFile = -1
        If Name = "" Then Exit Function
        For i As Integer = 0 To Me.Map.Kend - 1
            If i <> Ex_Code Then
                StacPosition = Check_ObjectName_in_NameTimeSTC(i, Name, duration)
                If StacPosition <> -1 Then
                    Return i
                End If
            End If
        Next
        Return -1
    End Function

    ''' <summary>
    ''' 指定したオブジェクト番号で、指定した期間・名称のオブジェクト名のスタックの位置を返す、見つからなかった場合は-1を返す
    ''' </summary>
    ''' <param name="ObjCode">調べるオブジェクト番号</param>
    ''' <param name="Name">名称</param>
    ''' <param name="duration">調査期間</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_ObjectName_in_NameTimeSTC(ByVal ObjCode As Integer, ByVal Name As String, ByVal duration As Start_End_Time_data) As Integer

        For i As Integer = 0 To MPObj(ObjCode).NumOfNameTime - 1
            With MPObj(ObjCode).NameTimeSTC(i)
                For j As Integer = 0 To .NamesList.Length - 1
                    If .NamesList(j) = Name Then
                        Dim f As Boolean = clsTime.checkDurationOverlapped(.SETime, duration)
                        If f = True Then
                            Return i
                        End If
                    End If
                Next
            End With
        Next
        Return -1
    End Function
    ''' <summary>
    ''' オブジェクトの重心を求める。面形状でない場合はFalseを返す
    ''' </summary>
    ''' <param name="ObjData"></param>
    ''' <param name="GPoint">重心戻り値</param>
    ''' <param name="L_Time">求める時期</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetObjGraviityXY(ByRef ObjData As clsMapData.strObj_Data, ByRef GPoint As PointF, _
                                    ByVal L_Time As strYMD) As Boolean

        If ObjData.Shape <> enmShape.PolygonShape Then
            'ポリゴンでない場合は求めない
            Return False
        End If

        Dim x2 As Single, y2 As Single, men As Single
        men = Menseki(ObjData, x2, y2, L_Time)

        If men = -1 Then
            Return False
        ElseIf men = 0 Then
            GPoint.X = x2
            GPoint.Y = y2
        Else
            '重心がオブジェクト内部に収まるかチェック
            Dim ELine() As clsMapData.EnableMPLine_Data
            Dim Fringe_Line() As Integer

            Dim n As Integer = Get_EnableMPLine(ELine, ObjData, L_Time)
            ReDim Fringe_Line(n)
            For i As Integer = 0 To n - 1
                Fringe_Line(i) = ELine(i).LineCode
            Next
            Dim Cross_x() As Single
            Dim crn As Integer
            Dim f As Boolean = Check_Point_in_Polygon_LineCode(x2, y2, n, Fringe_Line, crn, Cross_x)

            If f = True Then
                GPoint.X = x2
                GPoint.Y = y2
            Else
                '入らない場合
                If crn < 2 Then
                    GPoint = MPLine(Fringe_Line(0)).PointSTC(0)
                    Return False
                End If
                Dim mw As Single = Cross_x(1) - Cross_x(0)
                Dim mww As Integer = 0
                If crn Mod 2 = 1 Then
                    crn -= 1
                End If
                If crn >= 4 Then
                    For i = 2 To crn - 1 Step 2
                        Dim mw2 As Single = Cross_x(i + 1) - Cross_x(i)
                        If mw2 > mw Then
                            mw = mw2
                            mww = i
                        End If
                    Next
                End If
                GPoint.Y = y2
                GPoint.X = (Cross_x(mww + 1) + Cross_x(mww)) / 2
            End If
        End If
        Return True
    End Function
    ''' <summary>
    ''' 指定したオブジェクトの面積を重心付きで返す
    ''' </summary>
    ''' <param name="ObjData"></param>
    ''' <param name="GXP"></param>
    ''' <param name="GYP"></param>
    ''' <param name="L_Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Menseki(ByRef ObjData As clsMapData.strObj_Data, _
                            ByRef GXP As Single, ByRef GYP As Single, ByVal L_Time As strYMD) As Single

        'オブジェクトの面積と重心を求める

        Dim Arrange_LineCode(,) As Integer, Fringe() As clsMapData.Fringe_Line_Info

        Dim Pon As Integer = Boundary_Arrange(ObjData, L_Time, Arrange_LineCode, Fringe)

        If Pon <= 0 Then
            Return -1
        Else
            Return Menseki_Sub(GXP, GYP, Pon, Arrange_LineCode, Fringe)
        End If


    End Function
    ''' <summary>
    ''' ポリゴンごとの面積を求めて、中抜け等を判定して全体の面積を返す
    ''' </summary>
    ''' <param name="Pon"></param>
    ''' <param name="Arrange_LineCode"></param>
    ''' <param name="Fringe"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Menseki_Sub(ByVal Pon As Integer, ByVal Arrange_LineCode(,) As Integer, _
                                           ByVal Fringe() As clsMapData.Fringe_Line_Info) As Single

        Dim mens(Pon - 1) As Single, LXY2(100) As PointF
        For i As Integer = 0 To Pon - 1
            Dim p As Integer = 0
            For j As Integer = 0 To Arrange_LineCode(i, 1) - 1
                Dim lc As Integer = Fringe(Arrange_LineCode(i, 0) + j).code
                p += Me.MPLine(lc).NumOfPoint
            Next
            ReDim LXY2(p)
            Dim n2 As Integer = Get_Object_Polygon_Coords(i, 0, Arrange_LineCode, Fringe, LXY2, False, 1)
            ReDim Preserve LXY2(n2)
            LXY2(n2) = LXY2(1)
            mens(i) = spatial.Get_Hairetu_Menseki(n2, LXY2, Me.Map)
        Next

        Dim m As Single
        If Pon = 1 Then
            m = mens(0)
        Else
            Dim In_Out(,) As Byte, TotalInOut() As Integer
            In_Out = Object_Polygon_InOut(Pon, Arrange_LineCode, Fringe, TotalInOut)
            m = 0
            For i As Integer = 0 To Pon - 1
                If TotalInOut(i) Mod 2 = 1 Then
                    '何かのポリゴンに奇数回含まれるポリゴンは中抜け
                    m -= mens(i)
                Else
                    m += mens(i)
                End If
            Next
        End If
        Return m

    End Function
    ''' <summary>
    ''' ポリゴンごとの面積を求める（重心つき）
    ''' </summary>
    ''' <param name="GXP">重心X（戻り値）</param>
    ''' <param name="GYP">重心Y（戻り値）</param>
    ''' <param name="Pon"></param>
    ''' <param name="Arrange_LineCode"></param>
    ''' <param name="Fringe"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Menseki_Sub(ByRef GXP As Single, ByRef GYP As Single, ByVal Pon As Integer, _
                                 ByVal Arrange_LineCode(,) As Integer, ByVal Fringe() As clsMapData.Fringe_Line_Info) As Single

        Dim mens(Pon - 1) As Single, gx(Pon - 1) As Single, gy(Pon - 1) As Single
        For i As Integer = 0 To Pon - 1
            Dim p As Integer = 0
            For j As Integer = 0 To Arrange_LineCode(i, 1) - 1
                Dim lc As Integer = Fringe(Arrange_LineCode(i, 0) + j).code
                p += Me.MPLine(lc).NumOfPoint
            Next
            Dim LXY2(p) As PointF
            Dim n2 As Integer = Get_Object_Polygon_Coords(i, 0, Arrange_LineCode, Fringe, LXY2, False, 1)
            ReDim Preserve LXY2(n2)
            LXY2(n2) = LXY2(1)
            Dim w As Single = 0
            If n2 > 2 Then
                '重心の位置を求める
                Dim wsw(n2 - 2) As Single
                Dim a As Single = LXY2(0).X
                Dim b As Single = LXY2(0).Y
                For j As Integer = 0 To n2 - 2
                    wsw(j) = (LXY2(j).X - a) * (LXY2(j + 1).Y - b) - (LXY2(j + 1).X - a) * (LXY2(j).Y - b)
                    w += wsw(j)
                Next
                Dim xx As Single = 0
                Dim yy As Single = 0
                For j As Integer = 0 To n2 - 2
                    With LXY2(j)
                        xx += wsw(j) * (.X + LXY2(j + 1).X)
                        yy += wsw(j) * (.Y + LXY2(j + 1).Y)
                    End With
                Next
                If w <> 0 Then
                    gx(i) = (a + xx / w) / 3
                    gy(i) = (b + yy / w) / 3
                End If
            End If

            If n2 < 2 Then
                gx(i) = LXY2(0).X
                gy(i) = LXY2(0).Y
            Else
                mens(i) = spatial.Get_Hairetu_Menseki(n2, LXY2, Me.Map)
                If (mens(i) < 0.0000000001 And gx(i) = 0 And gy(i) = 0) Or w = 0 Then
                    '幅のないポリゴンはポイント座標で重心
                    Dim xx As Single = 0
                    Dim yy As Single = 0
                    For j As Integer = 0 To n2 - 2
                        xx += LXY2(j).X
                        yy += LXY2(j).Y
                    Next
                    gx(i) = xx / (n2 - 1)
                    gy(i) = yy / (n2 - 1)
                End If
            End If
        Next

        Dim m As Single

        If Pon = 1 Then
            m = mens(0)
            GXP = gx(0)
            GYP = gy(0)
        Else
            Dim In_Out(,) As Byte, TotalInOut() As Integer
            In_Out = Object_Polygon_InOut(Pon, Arrange_LineCode, Fringe, TotalInOut)
            m = 0
            Dim sm As Single = 0
            For i As Integer = 0 To Pon - 1
                If TotalInOut(i) Mod 2 = 1 Then
                    '何かのポリゴンに奇数回含まれるポリゴンは中抜け
                    mens(i) = -mens(i)
                Else
                    If mens(i) > sm Then
                        'より面積の大きいポリゴンに重心を移す
                        GXP = gx(i)
                        GYP = gy(i)
                        sm = mens(i)
                    End If
                End If
                m += mens(i)
            Next
        End If
        Return m

    End Function
    ''' <summary>
    ''' 一つのオブジェクト内のポリゴンの包含関係を返す
    ''' </summary>
    ''' <param name="Polygon_Num"></param>
    ''' <param name="Arrange_LineCode"></param>
    ''' <param name="Fringe"></param>
    ''' <param name="TotalInOutNum">各ポリゴンが、他のポリゴン内部にある回数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Object_Polygon_InOut(ByVal Polygon_Num As Integer, ByRef Arrange_LineCode(,) As Integer, _
                                      ByRef Fringe() As clsMapData.Fringe_Line_Info, ByRef TotalInOutNum() As Integer) As Byte(,)

        Dim InOut(,) As Byte


        Dim Fringe_Line() As Integer
        Dim SIndex As New clsSpatialIndexSearch
        Dim PRect As RectangleF

        ReDim TotalInOutNum(Polygon_Num - 1)
        ReDim InOut(Polygon_Num - 1, Polygon_Num - 1)
        ReDim Fringe_Line(UBound(Fringe))

        SIndex.Init(SpatialPointType.SPIRect, False)
        For i As Integer = 0 To Polygon_Num - 1
            PRect = Me.MPLine(Fringe(Arrange_LineCode(i, 0)).code).Circumscribed_Rectangle
            For j As Integer = 1 To Arrange_LineCode(i, 1) - 1
                With Me.MPLine(Fringe(Arrange_LineCode(i, 0) + j).code)
                    PRect = spatial.Get_Circumscribed_Rectangle(.Circumscribed_Rectangle, PRect)
                End With
            Next
            SIndex.AddRect(PRect, i)
        Next
        SIndex.AddEnd()

        For i As Integer = 0 To Polygon_Num - 1
            Dim X As Single, Y As Single
            With Me.MPLine(Fringe(Arrange_LineCode(i, 0)).code)
                X = .PointSTC(0).X
                Y = .PointSTC(0).Y
            End With
            Dim Onum() As Integer, Otags() As Integer
            Dim n As Integer = SIndex.GetRectIn(X, Y, Onum, Otags)
            For j As Integer = 0 To n - 1
                Dim LCD As Integer = Otags(j)
                If LCD <> i Then
                    Dim n2 As Integer = 0
                    For k As Integer = 0 To Arrange_LineCode(LCD, 1) - 1
                        Fringe_Line(n2) = Fringe(Arrange_LineCode(LCD, 0) + k).code
                        n2 += 1
                    Next
                    Dim f As Boolean = Check_Point_in_Polygon_LineCode(X, Y, n2, Fringe_Line)
                    If f = True Then
                        Dim x2 As Single, y2 As Single
                        With Me.MPLine(Fringe(Arrange_LineCode(i, 0)).code)
                            x2 = .PointSTC(1).X
                            y2 = .PointSTC(1).Y
                        End With
                        f = Check_Point_in_Polygon_LineCode(x2, y2, n2, Fringe_Line)
                        If f = True Then
                            'iがjの中に含まれる場合は(i,j)を1に
                            InOut(i, LCD) = 1
                            TotalInOutNum(i) = TotalInOutNum(i) + 1
                        End If
                    End If
                End If
            Next
        Next

        Return InOut
    End Function
    ''' <summary>
    ''' オブジェクト内のポリゴンごとの連続した座標を取得する
    ''' </summary>
    ''' <param name="Num"></param>
    ''' <param name="Get_Coords_Data"></param>
    ''' <param name="Arrange_LineCode">ポリゴンごとのFringe()のスタック位置とライン数（戻り値）</param>
    ''' <param name="Fringe">境界線の番号、負の場合は逆回り（戻り値）</param>
    '''  <param name="poxy">座標列（戻り値）</param>
    ''' <param name="Equal_XY_Get_F">前後の座標が同一の場合にも座標を取得する場合はtrue</param>
    ''' <param name="getStep">座標取得間隔（1,2,3,4等）</param>
    ''' <param name="over180F">経度が180度を超えてもそのままの値を返す場合true</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Object_Polygon_Coords(ByVal Num As Integer, ByVal Get_Coords_Data As Integer, ByRef Arrange_LineCode(,) As Integer,
                                  ByRef Fringe() As clsMapData.Fringe_Line_Info, ByRef poxy() As PointF, ByVal Equal_XY_Get_F As Boolean,
                                  ByVal getStep As Integer, Optional ByVal over180F As Boolean = False) As Integer
        '
        'Get_Coords_Data
        '0:座標値そのもの
        '1:スクリーン上の座標に変換 --今は使わない。呼び出し元で変換する
        '2:世界測地系の緯度経度
        '3:元々の座標系の座標で取得


        Dim Pnum As Integer = Get_Object_Polygon_Points(Num, Arrange_LineCode, Fringe)

        ReDim poxy(Pnum - 1)

        Dim PN As Integer
        Dim n As Integer = 0
        For i As Integer = 0 To Arrange_LineCode(Num, 1) - 1
            Dim XYS() As PointF
            With Fringe(Arrange_LineCode(Num, 0) + i)
                PN = Get_Coords_by_LineCode(.code, Get_Coords_Data, .Direction, XYS, getStep, over180F)
            End With
            For j As Integer = 0 To PN - 1
                If n = 0 Or Equal_XY_Get_F = True Then
                    poxy(n) = XYS(j)
                    n += 1
                Else
                    If poxy(n - 1).Equals(XYS(j)) = True Then
                    Else
                        poxy(n) = XYS(j)
                        n += 1
                    End If
                End If
            Next
        Next
        Return n
    End Function
    ''' <summary>
    ''' Arrange_LineCodeの指定したポリゴンのポイント数を返す
    ''' </summary>
    ''' <param name="Num">取得するポリゴンの位置</param>
    ''' <param name="Arrange_LineCode"></param>
    ''' <param name="Fringe"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_Object_Polygon_Points(ByVal Num As Integer, ByRef Arrange_LineCode(,) As Integer, _
                                           ByRef Fringe() As clsMapData.Fringe_Line_Info) As Integer

        Dim Pnum As Integer = 0
        For i As Integer = 0 To Arrange_LineCode(Num, 1) - 1
            Dim L As Integer = Fringe(Arrange_LineCode(Num, 0) + i).code
            Pnum += Me.MPLine(L).NumOfPoint
        Next
        Return Pnum
    End Function
    ''' <summary>
    ''' 指定したライン番号の世界測地系緯度経度などをを取得する
    ''' </summary>
    ''' <param name="LCode">ライン番号</param>
    ''' <param name="Get_Coords_Data">取得方法</param>
    ''' <param name="P_Dir">P_Dir=-1の場合は逆向きに取得 1は順方向</param>
    ''' <param name="XYS">変換後の座標（戻り値）</param>
    ''' <param name="getStep">座標取得間隔（1,2,3,4等）</param>
    ''' <param name="over180F">経度が180度を超えてもそのままの値を返す場合true</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Coords_by_LineCode(ByVal LCode As Integer, ByVal Get_Coords_Data As Integer, _
                                                  ByVal P_Dir As Integer, ByRef XYS() As PointF, ByVal getStep As Integer, Optional ByVal over180F As Boolean = False) As Integer
        '
        'Get_Coords_Data
        '0:座標値そのもの
        '1:スクリーン上の座標に変換 --今は使わない。呼び出し元で変換する
        '2:世界測地系の緯度経度
        '3:元々の座標系の座標で取得
        'P_Dir=-1の場合は逆向きに取得 1は順方向

        Dim fs As Integer, fe As Integer
        Dim fst As Integer


        With Me.MPLine(LCode)
            If getStep + 1 >= .NumOfPoint And .PointSTC(0).Equals(.PointSTC(.NumOfPoint - 1)) Then
                'ループで2地点となって点になるのをふせぐ
                getStep = 1
            End If
            ReDim XYS(.NumOfPoint - 1)
            If P_Dir = 1 Then
                fs = 0
                fe = .NumOfPoint - 1
                fst = getStep
            Else
                fs = .NumOfPoint - 1
                fe = 0
                fst = -getStep
            End If
        End With

        Dim n As Integer = 0
        Dim lastp As Integer = fs
        For i As Integer = fs To fe Step fst
            Dim xy As PointF
            With Me.MPLine(LCode)
                Select Case Get_Coords_Data
                    Case 0
                        xy = .PointSTC(i)
                    Case 1
                        MsgBox("1は使わないerror")
                        'xy = clsGeneric.Get_SxSy_With_3D(.PointSTC(i), ScrData)
                    Case 2
                        xy = spatial.Get_Reverse_XY(.PointSTC(i), Me.Map.Zahyo)
                        xy = spatial.Get_World_IdoKedo(xy, Me.Map.Zahyo).toPointF
                        If xy.X > 180 And over180F = False Then
                            xy.X = xy.X - 360
                        End If
                    Case 3
                        xy = spatial.Get_Reverse_XY(.PointSTC(i), Me.Map.Zahyo)
                End Select
            End With
            lastp = i
            XYS(n) = xy
            n += 1
        Next
        If lastp <> fe Then
            Dim xy As PointF
            With Me.MPLine(LCode)
                Select Case Get_Coords_Data
                    Case 0
                        xy = .PointSTC(fe)
                    Case 2
                        xy = spatial.Get_Reverse_XY(.PointSTC(fe), Me.Map.Zahyo)
                        xy = spatial.Get_World_IdoKedo(xy, Me.Map.Zahyo).toPointF
                        If xy.X > 180 Then
                            xy.X = xy.X - 360
                        End If
                    Case 3
                        xy = spatial.Get_Reverse_XY(.PointSTC(fe), Me.Map.Zahyo)
                End Select
            End With
            XYS(n) = xy
            n += 1
        End If
        Return n
    End Function
    ''' <summary>
    ''' 指定したオブジェクトの境界線を面領域を描くような順番に並べ替える、返す値はオブジェクトのポリゴン数
    ''' </summary>
    ''' <param name="ObjData">オブジェクト</param>
    ''' <param name="Time"></param>
    ''' <param name="Arrange_LineCode">ポリゴンごとのFringe()のスタック位置とライン数（戻り値）</param>
    ''' <param name="Fringe">境界線の番号、負の場合は逆回り（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Overloads Function Boundary_Arrange(ByRef ObjData As clsMapData.strObj_Data, ByVal Time As strYMD, ByRef Arrange_LineCode(,) As Integer, _
                              ByRef Fringe() As clsMapData.Fringe_Line_Info) As Integer
        Dim ELine() As clsMapData.EnableMPLine_Data

        Dim NL As Integer = Get_EnableMPLine(ELine, ObjData, Time)
        Return Boundary_Arrange_Sub(NL, ELine, Arrange_LineCode, Fringe)

    End Function
    ''' <summary>
    ''' 指定したオブジェクトの境界線を面領域を描くような順番に並べ替える、返す値はオブジェクトのポリゴン数
    ''' </summary>
    ''' <param name="ObjCode">オブジェクト番号</param>
    ''' <param name="Time"></param>
    ''' <param name="Arrange_LineCode">ポリゴンごとのFringe()のスタック位置とライン数（戻り値）</param>
    ''' <param name="Fringe">境界線の番号、負の場合は逆回り（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Boundary_Arrange(ByVal ObjCode As Integer, ByVal Time As strYMD, ByRef Arrange_LineCode(,) As Integer, _
                          ByRef Fringe() As clsMapData.Fringe_Line_Info) As Integer
        Dim ELine() As clsMapData.EnableMPLine_Data

        Dim NL As Integer = Get_EnableMPLine(ELine, MPObj(ObjCode), Time)
        Return Boundary_Arrange_Sub(NL, ELine, Arrange_LineCode, Fringe)

    End Function


    ''' <summary>
    ''' オブジェクトの使用するラインの境界線を面領域を描くような順番に並べ替える、返す値はオブジェクトのポリゴン数
    ''' </summary>
    ''' <param name="NL">使用するライン数</param>
    ''' <param name="ELine">使用するライン番号・線種構造体</param>
    ''' <param name="Arrange_LineCode">ポリゴンごとのFringe()のスタック位置とライン数（戻り値）</param>
    ''' <param name="Fringe">境界線の番号、負の場合は逆回り（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Boundary_Arrange_Sub(ByVal NL As Integer, ByVal ELine() As clsMapData.EnableMPLine_Data, _
                                  ByRef Arrange_LineCode(,) As Integer, ByRef Fringe() As clsMapData.Fringe_Line_Info) As Integer


        If NL = 0 Then
            Return 0
        End If

        Dim spxy(NL - 1) As PointF
        Dim epxy(NL - 1) As PointF

        For i As Integer = 0 To NL - 1
            Dim LineNO As Integer = ELine(i).LineCode
            With Me.MPLine(LineNO)
                spxy(i) = .PointSTC(0)
                epxy(i) = .PointSTC(.NumOfPoint - 1)
            End With
        Next

        Dim n As Integer = spatial.BoundaryArrangeGeneral(NL, spxy, epxy, Arrange_LineCode, Fringe)
        For i As Integer = 0 To NL - 1
            Fringe(i).code = ELine(Fringe(i).code).LineCode
        Next
        Return n

    End Function




    ''' <summary>
    ''' 周辺ラインと指定した地点のX軸上の交点を求め、その地点数を返す
    ''' </summary>
    ''' <param name="X">調べる地点x</param>
    ''' <param name="Y">調べる地点y</param>
    ''' <param name="line_n">周辺ライン数</param>
    ''' <param name="Fringe_Line">周辺ライン番号</param>
    ''' <param name="CrossPointN">交点のx座標の数</param>
    ''' <param name="Cross_x">交点のx座標（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Point_in_Polygon_LineCode(ByVal X As Single, ByVal Y As Single, ByVal line_n As Integer,
                                     ByRef Fringe_Line() As Integer,
                                     Optional ByRef CrossPointN As Integer = 0,
                                     Optional ByRef Cross_x() As Single = Nothing) As Integer

        Dim P As New PointF(X, Y)
        Dim CheckLine As New List(Of PointF())

        For j As Integer = 0 To line_n - 1
            With Me.MPLine(Fringe_Line(j))
                '調査地点のY座標を含むラインのみを選択
                If .Circumscribed_Rectangle.Top <= Y And Y <= .Circumscribed_Rectangle.Bottom Then
                    CheckLine.Add(.PointSTC)
                End If
            End With
        Next
        Return spatial.check_Point_in_Polygon(P, CheckLine, CrossPointN, Cross_x)
    End Function
    ''' <summary>
    ''' 全期間を通したオブジェクトの形状をチェック
    ''' </summary>
    ''' <param name="ObjData">オブジェクト</param>
    ''' <param name="CutPoint">切れ目の地図座標を返す。必要ない場合は省略化</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Obj_Shape_AllTime(ByRef ObjData As clsMapData.strObj_Data, _
                                       Optional ByRef CutPoint As PointF = Nothing) As enmShape


        'オブジェクト名の有効期間の開始と終了時期での形状チェック

        If Me.ObjectKind(ObjData.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
            Return Check_Obj_Shape(ObjData, clsTime.GetNullYMD)
        End If

        Dim TimeSort As New clsSortingSearch
        Dim GT() As strYMD
        Dim OT() As Start_End_Time_data
        Dim obtn As Integer

        Dim SHP(10) As Integer
        Dim SHN As Integer = 0

        With ObjData
            obtn = .NumOfNameTime
            ReDim OT(obtn)
            For i As Integer = 0 To obtn - 1
                With .NameTimeSTC(i)
                    OT(i) = .SETime
                End With
            Next
        End With

        For i As Integer = 0 To obtn - 1
            If OT(i).StartTime.nullFlag = False Then
                If UBound(SHP) < SHN Then
                    ReDim Preserve SHP(SHN + 10)
                End If
                SHP(SHN) = Check_Obj_Shape(ObjData, OT(i).StartTime, CutPoint)
                SHN += 1
            End If
            If OT(i).EndTime.nullFlag = False Then
                If UBound(SHP) < SHN Then
                    ReDim Preserve SHP(SHN + 10)
                End If
                SHP(SHN) = Check_Obj_Shape(ObjData, OT(i).EndTime, CutPoint)
                SHN += 1
            End If
        Next


        TimeSort = New clsSortingSearch
        TimeSort.AddInit(VariantType.Integer)
        For i As Integer = 0 To ObjData.NumOfLine - 1
            With ObjData.LineCodeSTC(i)
                For j As Integer = 0 To .NumOfTime - 1
                    TimeSort.Add(clsTime.YMDtoValue(.Times(j).StartTime))
                    TimeSort.Add(clsTime.YMDtoValue(.Times(j).EndTime))
                Next
                For j As Integer = 0 To Me.MPLine(.LineCode).NumOfTime - 1
                    With Me.MPLine(.LineCode).LineTimeSTC(j)
                        TimeSort.Add(clsTime.YMDtoValue(.SETime.StartTime))
                        TimeSort.Add(clsTime.YMDtoValue(.SETime.EndTime))
                    End With
                Next
            End With

        Next
        TimeSort.AddEnd()

        Dim n As Integer = TimeSort.NumofData
        ReDim GT(n + 1)
        Dim n2 As Integer = 0
        For i As Integer = 0 To n - 1
            Dim v As Integer = TimeSort.DataPositionValue_Integer(i)
            Dim T As strYMD = clsTime.GetYMDfromValue(v)
            If T.nullFlag = False Then
                If n2 = 0 Then
                    If OT(0).StartTime.nullFlag = True Then
                        GT(0) = clsTime.getYesterday(T)
                        n2 = 1
                    End If
                    GT(n2) = T
                    n2 += 1
                Else
                    If GT(n2 - 1).Equals(T) = False Then
                        GT(n2) = T
                        n2 += 1
                    End If
                End If
            End If
        Next
        If OT(obtn - 1).EndTime.nullFlag = True Then
            If n2 <> 0 Then
                GT(n2) = clsTime.getTomorrow(GT(n2 - 1))
                n2 += 1
            End If
        End If

        For i As Integer = 0 To n2 - 1
            If GT(i).nullFlag = False Then
                For j = 0 To obtn - 1
                    If clsTime.checkDurationIn(OT(j), GT(i)) = True Then
                        If UBound(SHP) < SHN Then
                            ReDim Preserve SHP(SHN + 10)
                        End If
                        SHP(SHN) = Check_Obj_Shape(ObjData, GT(i), CutPoint)
                        SHN += 1
                    End If
                Next
            End If
        Next

        If SHN = 0 Then
            SHP(0) = Check_Obj_Shape(ObjData, clsTime.GetNullYMD, CutPoint)
            SHN = 1
        End If

        Dim SHF(2) As Integer
        For i As Integer = 0 To SHN - 1
            SHF(SHP(i)) += 1
        Next

        Dim sp As enmShape
        'チェックした期間内に、複数の形状が含まれている場合は、優先的に点＞線＞面が返される
        If SHF(enmShape.PolygonShape) <> 0 Then sp = enmShape.PolygonShape
        If SHF(enmShape.LineShape) <> 0 Then sp = enmShape.LineShape
        If SHF(enmShape.PointShape) <> 0 Then sp = enmShape.PointShape
        Return sp
    End Function

    ''' <summary>
    ''' オブジェクトの形状を返す
    ''' </summary>
    ''' <param name="ObjData">オブジェクト</param>
    ''' <param name="L_Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Check_Obj_Shape(ByRef ObjData As clsMapData.strObj_Data, ByVal L_Time As strYMD) As enmShape
        '

        If Me.ObjectKind(ObjData.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
            '集成オブジェクトタイプの場合
            Dim OBShape(2) As enmShape
            With ObjData
                For i As Integer = 0 To .NumOfLine - 1
                    OBShape(Me.MPObj(.LineCodeSTC(i).LineCode).Shape) += 1
                Next
            End With
            If OBShape(enmShape.LineShape) = 0 And OBShape(enmShape.PolygonShape) = 0 Then
                Return enmShape.PointShape
            ElseIf Me.ObjectKind(ObjData.Kind).Shape = enmShape.LineShape Or OBShape(enmShape.LineShape) > 0 Then
                Return enmShape.LineShape
            Else
                Return enmShape.PolygonShape
            End If
        Else
            '通常のオブジェクトタイプの場合
            Dim polyn As Integer = Check_PolyShape_PolygonNum(ObjData, L_Time)
            Select Case polyn
                Case -1
                    Return enmShape.PointShape
                Case 0
                    Return enmShape.LineShape
                Case Else
                    Return enmShape.PolygonShape
            End Select
        End If

    End Function
    ''' <summary>
    ''' オブジェクトの形状を返す。CutX,yで切れ目の座標を返す
    ''' </summary>
    ''' <param name="ObjData">オブジェクト</param>
    ''' <param name="L_Time">時期</param>
    ''' <param name="CutPoint">切れ目の地図座標</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Check_Obj_Shape(ByRef ObjData As clsMapData.strObj_Data, ByVal L_Time As strYMD, _
                                 ByRef CutPoint As PointF) As enmShape
        '

        If Me.ObjectKind(ObjData.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
            '集成オブジェクトタイプの場合
            Dim OBShape(2) As enmShape
            With ObjData
                For i As Integer = 0 To .NumOfLine - 1
                    OBShape(Me.MPObj(.LineCodeSTC(i).LineCode).Shape) += 1
                Next
            End With
            If OBShape(enmShape.LineShape) = 0 And OBShape(enmShape.PolygonShape) = 0 Then
                Return enmShape.PointShape
            ElseIf Me.ObjectKind(ObjData.Kind).Shape = enmShape.LineShape Or OBShape(enmShape.LineShape) > 0 Then
                Return enmShape.LineShape
            Else
                Return enmShape.PolygonShape
            End If
        Else
            '通常のオブジェクトタイプの場合
            Dim polyn As Integer = Check_PolyShape_PolygonNum(ObjData, L_Time, CutPoint)
            Select Case polyn
                Case -1
                    Return enmShape.PointShape
                Case 0
                    Return enmShape.LineShape
                Case Else
                    Return enmShape.PolygonShape
            End Select
        End If

    End Function
    ''' <summary>
    ''' オブジェクトを構成するポリゴン数を数えて返す
    ''' </summary>
    ''' <param name="ObjData">オブジェクト</param>
    ''' <param name="L_Time"></param>
    ''' <param name="CutPoint">切れ目の地図座標（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_PolyShape_PolygonNum(ByRef ObjData As clsMapData.strObj_Data, ByVal L_Time As strYMD, _
                                               Optional ByRef CutPoint As PointF = Nothing) As Integer

        Dim ELine() As clsMapData.EnableMPLine_Data


        Dim NL As Integer = Get_EnableMPLine(ELine, ObjData, L_Time)

        If NL = 0 Then
            Return -1
        End If

        If Me.ObjectKind(ObjData.Kind).Shape = enmShape.LineShape Then
            Return 0
        End If

        Dim Fringe(NL - 1) As Integer
        For i As Integer = 0 To NL - 1
            Fringe(i) = ELine(i).LineCode
        Next

        'ループラインをチェック
        Dim polyn As Integer = 0
        Dim stxy As PointF, exy As PointF
        Dim k As Integer = 0

        For i As Integer = 0 To NL - 1
            With Me.MPLine(Fringe(i))
                stxy = .PointSTC(0)
                exy = .PointSTC(.NumOfPoint - 1)
            End With
            If exy.Equals(stxy) = True Then
                NL = NL - 1
                polyn = polyn + 1
            Else
                Fringe(k) = Fringe(i)
                k = k + 1
            End If
        Next
        If k = 0 Then
            Return polyn
        End If

        Dim Contf As Boolean = False
        For i As Integer = 0 To NL - 1
            If Contf = False Then
                With Me.MPLine(Fringe(i))
                    stxy = .PointSTC(0)
                    exy = .PointSTC(.NumOfPoint - 1)
                End With
            End If
            Contf = False
            For j As Integer = i + 1 To NL - 1
                With Me.MPLine(Fringe(j))
                    If .PointSTC(0).Equals(exy) = True Then
                        exy = .PointSTC(.NumOfPoint - 1)
                        Contf = True
                        clsGeneric.SWAP(Fringe(j), Fringe(i + 1))
                        Exit For
                    ElseIf .PointSTC(.NumOfPoint - 1).Equals(exy) = True Then
                        exy = .PointSTC(0)
                        Contf = True
                        clsGeneric.SWAP(Fringe(j), Fringe(i + 1))
                        Exit For
                    End If
                End With
            Next
            If Contf = False Then
                If exy.Equals(stxy) Then
                    polyn += 1
                Else
                    polyn = 0
                    CutPoint = exy
                    Exit For
                End If
            End If
        Next
        Return polyn

    End Function


    ''' <summary>
    ''' 集成オブジェクトのグループが存在するかチェックし、存在する場合はtrueを返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_AggregateObjectType_Exists() As Boolean

        Dim f As Boolean = False
        For i As Integer = 0 To Me.Map.OBKNum - 1
            If Me.ObjectKind(i).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                f = True
                Exit For
            End If
        Next
        Return f
    End Function
    ''' <summary>
    ''' 全てのオブジェクトの大きさを求める
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Check_All_Obj_MaxMin()

        For i As Integer = 0 To Me.Map.Kend - 1
            Check_Obj_Maxmin(Me.MPObj(i), False)
        Next

    End Sub
    ''' <summary>
    ''' オブジェクトの外接四角形を求めて設定する
    ''' </summary>
    ''' <param name="ObjData">オブジェクト</param>
    ''' <param name="MapRectCheckF">地図データ全体の外接四角形をチェックするか</param>
    ''' <remarks></remarks>
    Public Sub Check_Obj_Maxmin(ByRef ObjData As clsMapData.strObj_Data, ByVal MapRectCheckF As Boolean)

        Dim Obj_rect As RectangleF

        Dim oldObjRect As RectangleF = ObjData.Circumscribed_Rectangle
        With ObjData
            For i As Integer = 0 To .NumOfCenterP - 1
                With .CenterPSTC(i)
                    If i = 0 Then
                        With .Position
                            Obj_rect = RectangleF.FromLTRB(.X, .Y, .X, .Y)
                        End With
                    Else
                        Obj_rect = spatial.Get_Circumscribed_Rectangle(.Position, Obj_rect)
                    End If
                End With
            Next
            If Me.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                If .NumOfLine > 0 Then
                    For i As Integer = 0 To .NumOfLine - 1
                        With Me.MPLine(.LineCodeSTC(i).LineCode)
                            Obj_rect = spatial.Get_Circumscribed_Rectangle(.Circumscribed_Rectangle, Obj_rect)
                            'For j As Integer = 0 To .NumOfPoint - 1
                            '    Obj_rect = spatial.Get_Circumscribed_Rectangle(.PointSTC(j), Obj_rect)
                            'Next
                        End With
                    Next
                End If
            Else
                Dim AggObs() As Integer
                Dim AggObsnum As Integer = Get_MpObj_used_AggregateObject(ObjData, clsTime.GetNullYMD, AggObs)
                For i As Integer = 0 To AggObsnum - 1
                    With Me.MPObj(AggObs(i))
                        If Me.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                            Obj_rect = spatial.Get_Circumscribed_Rectangle(.Circumscribed_Rectangle, Obj_rect)
                        End If
                    End With
                Next
            End If
        End With
        ObjData.Circumscribed_Rectangle = Obj_rect
        If MapRectCheckF = True Then
            Check_MapCircumscribedRectangle(oldObjRect, Obj_rect)
        End If
    End Sub
    Private Sub Check_MapCircumscribedRectangle(ByVal oldRect As RectangleF, ByVal newRect As RectangleF)
        If spatial.Compare_Two_Rectangle_Position(Me.Map.Circumscribed_Rectangle, newRect) <> cstRectangle_Cross.cstInclusion Then
            '内部に含まれない場合はUNIONで外接四角形を求める
            Me.Map.Circumscribed_Rectangle = RectangleF.Union(Me.Map.Circumscribed_Rectangle, newRect)
        Else
            'newRectが内部に含まれる場合
            If spatial.Check_TwoRectangele_Inner_Contact(Me.Map.Circumscribed_Rectangle, oldRect) = True Then
                'oldRectが地図データの外周の一部だった場合は再計算
                Me.Map.Circumscribed_Rectangle = Get_Mapfile_Rectangle()
            End If
        End If

    End Sub
    ''' <summary>
    ''' ある地点がオブジェクトの外接四角形に入るかどうかを調べ、さらに面オブジェクトの中かどうかを調べる
    ''' </summary>
    ''' <param name="ObjNumber"></param>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="LAY_Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Point_in_OneObject(ByVal ObjNumber As Integer, ByVal X As Single, ByVal Y As Single, _
                                                    ByVal LAY_Time As strYMD) As Boolean
        Return Check_Point_in_OneObject(MPObj(ObjNumber), X, Y, LAY_Time)
    End Function
    ''' <summary>
    ''' ある地点がオブジェクトの外接四角形に入るかどうかを調べ、さらに面オブジェクトの中かどうかを調べる
    ''' </summary>
    ''' <param name="Obj"></param>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="LAY_Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Point_in_OneObject(ByRef Obj As clsMapData.strObj_Data, ByVal X As Single, ByVal Y As Single, _
                                                    ByVal LAY_Time As strYMD) As Boolean

        Dim Fringe_Line() As Integer

        Dim f As Boolean = Check_Point_in_oneObject_Box(Obj, X, Y)

        If f = True Then
            Dim ELine() As clsMapData.EnableMPLine_Data
            Dim n As Integer = Get_EnableMPLine(ELine, Obj, LAY_Time)
            ReDim Fringe_Line(n)
            For j As Integer = 0 To n - 1
                Fringe_Line(j) = ELine(j).LineCode
            Next
            Return Check_Point_in_Polygon_LineCode(X, Y, n, Fringe_Line)
        Else
            Return False
        End If

    End Function
    ''' <summary>
    ''' ある地点がオブジェクトの外接四角形に入るかどうかを調べる
    ''' </summary>
    ''' <param name="ObjNumber"></param>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Point_in_oneObject_Box(ByVal ObjNumber As Integer, ByVal X As Single, ByVal Y As Single) As Boolean
        Return Check_Point_in_oneObject_Box(MPObj(ObjNumber), X, Y)
    End Function

    ''' <summary>
    ''' ある地点がオブジェクトの外接四角形に入るかどうかを調べる
    ''' </summary>
    ''' <param name="Obj">オブジェクト</param>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Point_in_oneObject_Box(ByRef Obj As clsMapData.strObj_Data, ByVal X As Single, ByVal Y As Single) As Boolean

        Dim f As Boolean = False
        If Obj.Shape <> enmShape.PointShape Then
            If spatial.Check_PointInBox(X, Y, 0, Obj.Circumscribed_Rectangle) = True Then
                f = True
            End If
        End If
        Return f
    End Function
    Public Sub Checl_All_Line_Maxmin()
        For i As Integer = 0 To Map.ALIN - 1
            Check_Line_Maxmin(i, False)
        Next
    End Sub
    ''' <summary>
    ''' 指定したラインコードの外接四角形を求める
    ''' </summary>
    ''' <param name="Lcode"></param>
    ''' <param name="MapRectCheckF">地図データ全体の外接四角形をチェックするか</param>
    ''' <remarks></remarks>
    Public Sub Check_Line_Maxmin(ByVal Lcode As Integer, ByVal MapRectCheckF As Boolean)

        Dim oldRect As RectangleF = Me.MPLine(Lcode).Circumscribed_Rectangle
        With Me.MPLine(Lcode)
            .Circumscribed_Rectangle = spatial.Get_Circumscribed_Rectangle(.PointSTC, 0, .NumOfPoint)
        End With

        If MapRectCheckF = True Then
            Check_MapCircumscribedRectangle(oldRect, Me.MPLine(Lcode).Circumscribed_Rectangle)
        End If
    End Sub
    ''' <summary>
    ''' PushLineの内容で，Div_Pointで分割したラインを，Div_LineCodeおよびMAP.ALINに分割保存
    ''' </summary>
    ''' <param name="PushLine">分割するライン</param>
    ''' <param name="Div_Point">分割するポイントの番号</param>
    ''' <remarks></remarks>
    Public Sub Div_Line(ByVal PushLine As clsMapData.strLine_Data, ByVal Div_Point As Integer)


        Dim Div_LineCode As Integer = PushLine.Number
        Me.MPLine(Div_LineCode) = PushLine.Clone
        With Me.MPLine(Div_LineCode)
            .NumOfPoint = Div_Point + 1
            ReDim Preserve .PointSTC(.NumOfPoint - 1)
        End With

        Check_Line_Maxmin(Div_LineCode, False)

        Dim NL As Integer = Me.Map.ALIN
        Me.Map.ALIN += 1
        ReDim Preserve Me.MPLine(NL)
        Me.MPLine(NL) = PushLine.Clone
        Me.MPLine(NL).Number = NL
        With Me.MPLine(NL)
            .NumOfPoint = PushLine.NumOfPoint - Div_Point
            ReDim .PointSTC(.NumOfPoint - 1)
            For i As Integer = 0 To .NumOfPoint - 1
                .PointSTC(i) = PushLine.PointSTC(i + Div_Point)
            Next
        End With
        Check_Line_Maxmin(NL, False)

        Object_LineCode_Add(Div_LineCode, 1, {NL})

        Me.MPLine(Div_LineCode).Connect = Check_Line_Connect(Me.MPLine(Div_LineCode), Div_LineCode)
        Me.MPLine(NL).Connect = Check_Line_Connect(Me.MPLine(NL), NL)

    End Sub
    Public Sub Check_ALl_Line_Connect()


        Dim PointIndex As New clsSpatialIndexSearch


        '        ProgressLabel.Start(1, "ライン結合チェック")

        PointIndex.Init(SpatialPointType.SinglePoint, False)
        For i As Integer = 0 To Map.ALIN - 1
            With MPLine(i)
                If .NumOfPoint > 0 Then
                    PointIndex.AddDoublePoint(.PointSTC(0), .PointSTC(.NumOfPoint - 1), i)
                End If
            End With
        Next
        PointIndex.AddEnd()
        For i As Integer = 0 To Map.ALIN - 1
            With MPLine(i)
                If .NumOfPoint > 0 Then
                    If .PointSTC(0).Equals(.PointSTC(.NumOfPoint - 1)) = True Then
                        .Connect = 3
                    Else
                        .Connect = 0
                        For j As Integer = 0 To 1
                            Dim PNumber() As Integer, Tags() As Integer, LNumber() As Integer
                            Dim n As Integer = PointIndex.GetSamePointNumberAlley(.PointSTC(j * (.NumOfPoint - 1)).X, .PointSTC(j * (.NumOfPoint - 1)).Y, _
                                     LNumber, PNumber, Tags)
                            For k As Integer = 0 To n - 1
                                If LNumber(k) <> i Then
                                    .Connect += 1
                                    Exit For
                                End If
                            Next
                        Next
                    End If
                End If
            End With
        Next


        'ProgressLabel.Visible = False

    End Sub
    ''' <summary>
    ''' 指定したラインの他ラインとの接続状況を返す
    ''' </summary>
    ''' <param name="Line">ライン</param>
    ''' <param name="exclusion_code">除外ラインコード</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Line_Connect(ByRef Line As clsMapData.strLine_Data, _
                                             Optional ByVal exclusion_code As Integer = -1) As enmLineConnect
        'exclude_codeで、比較対象からはずすラインを指定できる

        Dim ck As Integer = Check_Line_Connect_Detail(Line, exclusion_code)
        Select Case ck
            Case 0
                Return enmLineConnect.no
            Case 1, 2
                Return enmLineConnect.one
            Case 3
                Return enmLineConnect.both
            Case 4
                Return enmLineConnect.loopen
        End Select

    End Function
    ''' <summary>
    ''' 指定したラインの他ラインとの接続状況の詳細を返す
    ''' </summary>
    ''' <param name="Line">ライン</param>
    ''' <param name="exclusion_code">除外ラインコード</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Line_Connect_Detail(ByRef Line As clsMapData.strLine_Data, _
                                              Optional ByVal exclusion_code As Integer = -1) As Integer
        'exclusion_codeで、比較対象からはずすラインを指定できる。
        '返す値 1:始点が結合 2:終点が結合 4:ループ　0:結合なし

        If Line.NumOfPoint = 0 Then
            Return 0
        End If

        Dim XY1 As PointF = Line.PointSTC(0)
        Dim XY2 As PointF = Line.PointSTC(Line.NumOfPoint - 1)


        If XY1.Equals(XY2) = True Then
            Return 4
        End If

        Dim ret_v As Integer = 0

        For i As Integer = 0 To Me.Map.ALIN - 1
            If i <> exclusion_code And i <> Line.Number Then
                With Me.MPLine(i)
                    Dim n As Integer = .NumOfPoint
                    If n > 0 Then
                        Dim pxy1 As PointF = .PointSTC(0)
                        Dim pxy2 As PointF = .PointSTC(n - 1)
                        If pxy1.Equals(XY1) = True Or pxy2.Equals(XY1) = True Then
                            ret_v = (ret_v Or 1)
                        End If
                        If pxy1.Equals(XY2) = True Or pxy2.Equals(XY2) = True Then
                            ret_v = (ret_v Or 2)
                        End If
                    End If
                End With
            End If
        Next
        Return ret_v
    End Function


    ''' <summary>
    ''' 指定したラインに接続しているライン数とライン番号を返す
    ''' </summary>
    ''' <param name="Line">ライン</param>
    ''' <param name="code">接続しているラインコード配列（戻り値）</param>
    ''' <param name="exclusion_code">比較対象からはずすラインコード</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Connect_Line(ByRef Line As clsMapData.strLine_Data, ByRef code() As Integer, _
                                     Optional ByVal exclusion_code As Integer = -1) As Integer

        ReDim code(10)

        If Line.NumOfPoint = 0 Then
            Return 0
        End If

        Dim XY1 As PointF = Line.PointSTC(0)
        Dim XY2 As PointF = Line.PointSTC(Line.NumOfPoint - 1)

        Dim Num As Integer = 0
        For i As Integer = 0 To Me.Map.ALIN - 1
            If i <> exclusion_code Then
                With Me.MPLine(i)
                    Dim n As Integer = .NumOfPoint
                    If n > 0 Then
                        Dim pxy1 As PointF = .PointSTC(0)
                        Dim pxy2 As PointF = .PointSTC(n - 1)
                        If pxy1.X.Equals(XY1) = True Or pxy2.Equals(XY1) = True _
                            Or pxy1.Equals(XY2) = True Or pxy2.Equals(XY2) = True Then
                            If UBound(code) < Num Then
                                ReDim Preserve code(Num + 10)
                            End If
                            code(Num) = i
                            Num += 1
                        End If
                    End If
                End With
            End If
        Next
        Return Num

    End Function


    ''' <summary>
    ''' オブジェクト番号のラインコードスタック数を変更する
    ''' </summary>
    ''' <param name="ObjNum">オブジェクト番号</param>
    ''' <param name="New_NumOfLine">新しい使用ライン数</param>
    ''' <param name="Old_NumOfLine">古い使用ライン数</param>
    ''' <remarks></remarks>
    Public Sub Move_LineCodeStac(ByVal ObjNum As Integer, ByVal New_NumOfLine As Integer, ByVal Old_NumOfLine As Integer)


        With Me.MPObj(ObjNum)
            Dim dif As Integer = New_NumOfLine - Old_NumOfLine
            .NumOfLine = .NumOfLine + dif


            If dif <> 0 Then
                If dif > 0 Then
                    ReDim Preserve .LineCodeSTC(.NumOfLine - 1)
                    For i As Integer = Old_NumOfLine To .NumOfLine - 1
                        With .LineCodeSTC(i)
                            .NumOfTime = 0
                        End With
                    Next
                Else
                    If .NumOfLine = 0 Then
                        Erase .LineCodeSTC
                    Else
                        ReDim Preserve .LineCodeSTC(.NumOfLine - 1)
                    End If
                End If
            End If
        End With

    End Sub
    ''' <summary>
    ''' 指定したオブジェクト番号の範囲で、使用しているラインを結合する
    ''' </summary>
    ''' <param name="S_O_Code">オブジェクト番号の開始</param>
    ''' <param name="E_O_Code">オブジェクト番号の終了</param>
    ''' <remarks></remarks>
    Public Sub Connect_Object_Line(ByVal S_O_Code As Integer, ByVal E_O_Code As Integer)

        Dim Lstac(Me.Map.ALIN) As Integer

        Dim LNum As Integer = 0
        For j As Integer = S_O_Code To E_O_Code
            Dim LNum2 As Integer = Me.MPObj(j).NumOfLine
            Dim ii As Integer = LNum
            For i As Integer = 0 To LNum2 - 1
                Dim nLs As Integer = Me.MPObj(j).LineCodeSTC(i).LineCode
                Dim f As Boolean = True
                For k As Integer = 0 To LNum - 1
                    If Lstac(k) = nLs Then
                        f = False
                        Exit For
                    End If
                Next
                If f = True Then
                    Lstac(LNum) = nLs
                    LNum = LNum + 1
                End If
            Next
        Next
        Connect_Line(LNum, Lstac)
    End Sub
    ''' <summary>
    ''' 指定したオブジェクトグループの初期属性をすべて削除
    ''' </summary>
    ''' <param name="objG"></param>
    ''' <remarks></remarks>
    Public Sub DeleteAllDefAttrData(ByVal objG As Integer)
        With Me.ObjectKind(objG)
            .DefTimeAttDataNum = 0
            Erase .DefTimeAttSTC
        End With
        For i As Integer = 0 To Me.Map.Kend - 1
            With Me.MPObj(i)
                If .Kind = objG Then
                    Erase .DefTimeAttValue
                End If
            End With
        Next
    End Sub
    ''' <summary>
    ''' オブジェクトの初期属性データ取得。時期がはずれてデータが取得できない場合はfalse
    ''' </summary>
    ''' <param name="ObjCode">オブジェクト番号</param>
    ''' <param name="defNumber"></param>
    ''' <param name="Time"></param>
    ''' <param name="Value">戻り値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_DefTimeAttrValue(ByVal ObjCode As Integer, ByVal defNumber As Integer, ByVal Time As strYMD, ByRef Value As String) As Boolean
        With Me.MPObj(ObjCode)
            Dim ogp As Integer = .Kind
            Value = ""
            If Me.Map.Time_Mode = False Then
                '時間データでない場合
                    Value = .DefTimeAttValue(defNumber).Data(0).Value
                Return True
            Else
                '時間データの場合
                If Time.nullFlag = True Then
                    Return False
                End If
                With .DefTimeAttValue(defNumber)
                    If .Data Is Nothing = True Then
                        Return False
                    End If
                    Dim n As Integer = .Data.Length
                    Select Case Me.ObjectKind(ogp).DefTimeAttSTC(defNumber).Type
                        Case enmDefTimeAttDataType.PointData
                            '時点データの場合
                            For i As Integer = 0 To n - 1
                                If .Data(i).Span.StartTime.nullFlag = True Or
                                     .Data(i).Span.StartTime.Equals(Time) = True Then
                                    '同じ時点のデータがあった場合
                                    Value = .Data(i).Value
                                    Return True
                                End If
                            Next
                            'なかった場合
                            Select Case Me.ObjectKind(ogp).DefTimeAttSTC(defNumber).ExtraValue
                                Case enmDefPointAttDataExtraValue.MissingValue
                                    '欠損値
                                    Return False
                                Case enmDefPointAttDataExtraValue.NearestValue
                                    '一番近い値
                                    Dim ff As Boolean = True
                                    Dim minDay As Long
                                    For i As Integer = 0 To n - 1
                                        Dim daten As Integer = Math.Abs(clsTime.getDifference(.Data(i).Span.StartTime, Time))
                                        If ff = True Then
                                            minDay = daten
                                            Value = .Data(i).Value
                                        Else
                                            If minDay < daten Then
                                                minDay = daten
                                                Value = .Data(i).Value
                                            End If
                                        End If
                                    Next
                                    Return True
                                Case enmDefPointAttDataExtraValue.interpolation_MissingValue, enmDefPointAttDataExtraValue.interpolation_NearestValue
                                    '間に挟まれた場合は按分
                                    For i As Integer = 0 To n - 2
                                        Dim span As Start_End_Time_data
                                        span.StartTime = .Data(i).Span.StartTime
                                        span.EndTime = .Data(i + 1).Span.StartTime
                                        If clsTime.checkDurationIn(span, Time) = True Then
                                            Dim v1 As Double = Val(.Data(i).Value)
                                            Dim v2 As Double = Val(.Data(i + 1).Value)
                                            Dim vsa As Double = v2 - v1
                                            Dim daten1 As Long = Math.Abs(clsTime.getDifference(span.StartTime, Time))
                                            Dim daten2 As Long = Math.Abs(clsTime.getDifference(span.StartTime, span.EndTime))
                                            Dim v3 As Double = v1 + vsa * (daten1 / daten2)
                                            Value = v3.ToString
                                            Return True
                                        End If
                                    Next
                                    Select Case Me.ObjectKind(ogp).DefTimeAttSTC(defNumber).ExtraValue
                                        Case enmDefPointAttDataExtraValue.interpolation_MissingValue
                                            '間に挟まれていない場合は欠損値
                                            Return False
                                        Case enmDefPointAttDataExtraValue.interpolation_NearestValue
                                            '間に挟まれていない場合は近い値
                                            If .Data(0).Span.StartTime.nullFlag = True Then
                                                Value = .Data(0).Value
                                                Return True
                                            Else
                                                Dim d1 As Long = Math.Abs(clsTime.getDifference(.Data(0).Span.StartTime, Time))
                                                Dim d2 As Long = Math.Abs(clsTime.getDifference(.Data(n - 1).Span.StartTime, Time))
                                                If d1 < d2 Then
                                                    Value = .Data(0).Value
                                                Else
                                                    Value = .Data(n - 1).Value
                                                End If
                                                Return True
                                            End If
                                    End Select
                                Case enmDefPointAttDataExtraValue.interpolation_NearestValue
                            End Select
                        Case enmDefTimeAttDataType.SpanData
                            '期間データの場合
                            For i As Integer = 0 To n - 1
                                If clsTime.checkDurationIn(.Data(i).Span, Time) = True Then
                                    Value = .Data(i).Value
                                    Return True
                                End If
                            Next
                            Return False
                    End Select
                End With
            End If
        End With
    End Function
    ''' <summary>
    ''' 指定したオブジェクトに、編入されたオブジェクトの取得し、その数を返す
    ''' </summary>
    ''' <param name="Obj">オブジェクト</param>
    ''' <param name="H_Data">戻り値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Hennyu_Object(ByRef Obj As strObj_Data, ByRef H_Data() As clsMapData.Hennyu_Data) As Integer

        ReDim H_Data(100)
        Dim n As Integer = 0
        For i As Integer = 0 To Me.Map.Kend - 1
            For j As Integer = 0 To Me.MPObj(i).NumOfSuc - 1
                With Me.MPObj(i).SucSTC(j)
                    If .ObjectCode = Obj.Number Then
                        Dim TM As strYMD = clsTime.getYesterday(.Time)
                        Dim f As Boolean = True
                        With Me.MPObj(i)
                            For k As Integer = 0 To .NumOfNameTime - 1
                                With .NameTimeSTC(k).SETime
                                    If .EndTime.Equals(TM) = True Then
                                        f = False
                                        Exit For
                                    End If
                                End With
                            Next
                        End With
                        If H_Data.GetUpperBound(0) < n Then
                            ReDim Preserve H_Data(n + 100)
                        End If
                        H_Data(n).code = i
                        H_Data(n).Time = .Time
                        Get_Enable_ObjectName(Me.MPObj(i), TM, False, H_Data(n).Name)
                        H_Data(n).Part = f
                        n += 1
                    End If
                End With
            Next
        Next
        If n = 0 Then
            ReDim Preserve H_Data(0)
        Else
            ReDim Preserve H_Data(n - 1)
        End If
        Return n

    End Function
    Public Overloads Function Get_Enable_ObjectName(ByVal ObjCode As Integer, ByVal Time As strYMD, _
                                      ByVal NoDataLastGetF As Boolean, ByRef ReturnObjectName As String, Optional ByRef StacPoint As Integer = 0) As Boolean
        Return Me.Get_Enable_ObjectName(Me.MPObj(ObjCode), Time, NoDataLastGetF, ReturnObjectName, StacPoint)
    End Function

    Public Overloads Function Get_Enable_ObjectName(ByVal ObjCode As Integer, ByVal Time As strYMD, _
                                      ByVal NoDataLastGetF As Boolean, ByRef ReturnObjectName() As String, Optional ByRef StacPoint As Integer = 0) As Boolean
        Return Me.Get_Enable_ObjectName(Me.MPObj(ObjCode), Time, NoDataLastGetF, ReturnObjectName, StacPoint)
    End Function
    ''' <summary>
    ''' オブジェクトから、指定した時間のオブジェクト名リストを取得、取得できない場合はfalseを返す
    ''' </summary>
    ''' <param name="ObjData">調べるオブジェクト</param>
    ''' <param name="Time">調べる時期</param>
    ''' <param name="NoDataLastGetF">指定の時期にオブジェクト名が使えない場合、最後のオブジェクト名を取得する場合True</param>
    ''' <param name="ReturnObjectName">オブジェクト名リスト（戻り値）</param>
    ''' <param name="StacPoint">取得したオブジェクト名構造体のNameTimeSTCスタック位置(オプション)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_Enable_ObjectName(ByVal ObjData As clsMapData.strObj_Data, ByVal Time As strYMD, _
                                          ByVal NoDataLastGetF As Boolean, ByRef ReturnObjectName() As String, Optional ByRef StacPoint As Integer = 0) As Boolean
        Dim n As Integer
        With ObjData
            If Time.nullFlag = True Then
                '時期指定がない場合は最後のオブジェクト名
                n = .NumOfNameTime - 1
            Else
                n = -1
                For i As Integer = 0 To .NumOfNameTime - 1
                    If clsTime.checkDurationIn(.NameTimeSTC(i).SETime, Time) = True Then
                        n = i
                        Exit For
                    End If
                Next
                If n = -1 And NoDataLastGetF = True Then
                    n = .NumOfNameTime - 1
                End If
            End If
            If n = -1 Then
                Return False
            Else
                ReturnObjectName = .NameTimeSTC(n).NamesList.Clone
                Return True
            End If
        End With
    End Function
    ''' <summary>
    ''' オブジェクトから、指定した時間のオブジェクト名を取得、取得できない場合はfalseを返す
    ''' </summary>
    ''' <param name="ObjData">調べるオブジェクト</param>
    ''' <param name="Time">調べる時期</param>
    ''' <param name="NoDataLastGetF">指定の時期にオブジェクト名が使えない場合、最後のオブジェクト名を取得する場合True</param>
    ''' <param name="ReturnObjectName">オブジェクト名（戻り値）</param>
    ''' <param name="StacPoint">取得したオブジェクト名構造体のNameTimeSTCスタック位置(オプション)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_Enable_ObjectName(ByVal ObjData As clsMapData.strObj_Data, ByVal Time As strYMD, _
                                          ByVal NoDataLastGetF As Boolean, ByRef ReturnObjectName As String, Optional ByRef StacPoint As Integer = 0, Optional ByVal delimiter As String = "/") As Boolean
        Dim n As Integer
        With ObjData
            If Time.nullFlag = True Then
                '時期指定がない場合は最後のオブジェクト名
                n = .NumOfNameTime - 1
            Else
                n = -1
                For i As Integer = 0 To .NumOfNameTime - 1
                    If clsTime.checkDurationIn(.NameTimeSTC(i).SETime, Time) = True Then
                        n = i
                        Exit For
                    End If
                Next
                If n = -1 And NoDataLastGetF = True Then
                    n = .NumOfNameTime - 1
                End If
            End If
            StacPoint = n
            If n = -1 Then
                Return False
            Else
                ReturnObjectName = .NameTimeSTC(n).connectNames(delimiter)
                Return True
            End If
        End With
    End Function
    ''' <summary>
    ''' 線オブジェクトの代表点を設定して返す
    ''' </summary>
    ''' <param name="Obj">千オブジェクト</param>
    ''' <remarks></remarks>
    Public Function Get_LineShapeObj_CenterP(ByRef Obj As strObj_Data) As PointF
        If Obj.NumOfLine = 0 Then
            Return Nothing
        Else
            With Me.MPLine(Obj.LineCodeSTC(0).LineCode)
                Dim n As Integer
                If .NumOfPoint = 0 Then
                    n = 0
                Else
                    n = .NumOfPoint / 2
                End If
                Return .PointSTC(n)
            End With
        End If
    End Function
    ''' <summary>
    ''' 指定したオブジェクトを時空間モードで結合して新規オブジェクトとして返す。エラーの場合はobj.kind=-1にして返す。
    ''' </summary>
    ''' <param name="OCodes">対象オブジェクトのList</param>
    ''' <param name="C_Time">結合時期</param>
    ''' <param name="Conect_Mode">結合形態0新設1編入</param>
    ''' <param name="End_F">結合元オブジェクトを終了させる</param>
    ''' <param name="suc_f">結合元オブジェクトを編入先に継承させる</param>
    ''' <param name="LiveObject">編入先（または新設の場合代表点の位置）のオブジェクトの、対象オブジェクトリスト中の位置</param>
    ''' <param name="Change_ObjName_F">結合後のオブジェクト名を変更する</param>
    ''' <param name="O_names">結合後のオブジェクト名</param>
    ''' <param name="ERmessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Combine_TimeObjects(ByRef OCodes As List(Of Integer), ByVal C_Time As strYMD, _
                ByVal Conect_Mode As Integer, ByVal End_F As Boolean, ByVal suc_f As Boolean, _
                ByVal LiveObject As Integer, ByVal Change_ObjName_F As Boolean, ByVal O_names As String(), _
                ByRef ERmessage As String) As strObj_Data

        Dim Values() As Integer = OCodes.ToArray
        Return Combine_TimeObjects(Values.GetUpperBound(0) + 1, Values, C_Time, Conect_Mode, End_F, suc_f, LiveObject, Change_ObjName_F, O_names, ERmessage)
    End Function
    ''' <summary>
    ''' 指定したオブジェクトを時空間モードで結合して新規オブジェクトとして返す。エラーの場合はobj.kind=-1にして返す。
    ''' </summary>
    ''' <param name="Num">結合対象数</param>
    ''' <param name="O_Code">対象オブジェクトのリスト</param>
    ''' <param name="C_Time">結合時期</param>
    ''' <param name="Conect_Mode">結合形態0新設1編入</param>
    ''' <param name="End_F">結合元オブジェクトを終了させる</param>
    ''' <param name="suc_f">結合元オブジェクトを編入先に継承させる</param>
    ''' <param name="LiveObject">編入先（または新設の場合代表点の位置）のオブジェクトの、対象オブジェクトリスト中の位置</param>
    ''' <param name="Change_ObjName_F">結合後のオブジェクト名を変更する</param>
    ''' <param name="O_names">結合後のオブジェクト名</param>
    ''' <param name="ERmessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Combine_TimeObjects(ByVal Num As Integer, ByVal O_Code() As Integer, ByVal C_Time As strYMD, _
                    ByVal Conect_Mode As Integer, ByVal End_F As Boolean, ByVal suc_f As Boolean, _
                    ByVal LiveObject As Integer, ByVal Change_ObjName_F As Boolean, ByVal O_names As String(), _
                    ByRef ERmessage As String) As strObj_Data

        Dim E_Time As strYMD
        Dim EM As String
        Dim EMH As String
        Dim Obj As strObj_Data


        If C_Time.nullFlag = False Then
            E_Time = clsTime.getYesterday(C_Time)
        End If

        Dim Otype As clsMapData.enmObjectGoupType_Data = Me.ObjectKind(MPObj(O_Code(0)).Kind).ObjectType
        If C_Time.nullFlag = True Then
            '時期を指定しない場合に、使用するラインの時間チェック
            EM = ""
            For i As Integer = 0 To Num - 1
                With Me.MPObj(O_Code(i))
                    Dim f As Boolean
                    If Otype = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                        f = Check_AggrObject_relatedTime_Exists(Me.MPObj(O_Code(i)))
                    Else
                        For j As Integer = 0 To .NumOfLine - 1
                            f = False
                            With .LineCodeSTC(j)
                                If .NumOfTime <> 0 Then
                                    f = True
                                Else
                                    If Me.MPLine(.LineCode).NumOfTime <> 1 Then
                                        f = True
                                    End If
                                End If
                            End With
                            If f = True Then
                                Exit For
                            End If
                        Next
                    End If
                    If f = True Then
                        EM = EM & .NameTimeSTC(.NumOfNameTime - 1).connectNames & vbCrLf
                    End If
                End With
            Next
            If Otype = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                EMH = "以下のオブジェクトは時間設定がなされています。"
            Else
                EMH = "以下のオブジェクトはラインに時間設定がなされています。"
            End If
            If EM <> "" Then
                ERmessage = EMH & vbCrLf & "結合時期を指定してください。" & vbCrLf & vbCrLf & EM
                Obj.Kind = -1
                Return Obj
            End If
        Else
            '時期が指定してある場合に、結合前のオブジェクトの時期をチェック
            EM = ""
            For i As Integer = 0 To Num - 1
                Dim f As Boolean = CheckEnableObject(Me.MPObj(O_Code(i)), E_Time)
                If f = False Then
                    With Me.MPObj(O_Code(i))
                        EM = EM & .NameTimeSTC(.NumOfNameTime - 1).connectNames
                    End With
                End If
            Next
            If EM <> "" Then
                ERmessage = "以下のオブジェクトは結合時期に存在していません。" & vbCrLf & vbCrLf & EM
                Obj.Kind = -1
                Return Obj
            End If
        End If

        '終了するオブジェクトの設定（終了時期、継承先）
        For i As Integer = 0 To Num - 1
            If Conect_Mode = 1 And i = LiveObject Then
            Else
                Dim endObj As strObj_Data = Me.MPObj(O_Code(i))
                With endObj
                    If End_F = True Then
                        .NameTimeSTC(.NumOfNameTime - 1).SETime.EndTime = E_Time
                    End If
                    If suc_f = True Then
                        .NumOfSuc = .NumOfSuc + 1
                        ReDim Preserve .SucSTC(.NumOfSuc - 1)
                        With .SucSTC(endObj.NumOfSuc - 1)
                            .Time = C_Time
                            If Conect_Mode = 0 Then
                                .ObjectCode = Me.Map.Kend
                            Else
                                .ObjectCode = O_Code(LiveObject)
                            End If
                        End With
                    End If
                End With
                Save_Object(endObj, True)
            End If
        Next

        If Conect_Mode = 0 Then
            '新設の場合の新規オブジェクト
            Dim newNames As String()
            If Change_ObjName_F = False Then
                With Me.MPObj(O_Code(LiveObject))
                    newNames = .NameTimeSTC(.NumOfNameTime - 1).NamesList.Clone
                End With
            Else
                newNames = O_names.Clone
            End If

            Obj = Combine_Objects(newNames, Num, O_Code, E_Time)
            Obj.NameTimeSTC(0).SETime.StartTime = C_Time
            If LiveObject <> -1 Then
                With Obj.CenterPSTC(0).Position
                    Get_Enable_CenterP(.X, .Y, MPObj(O_Code(LiveObject)), E_Time)
                End With
            Else
                Dim gx As Single = 0
                Dim gy As Single = 0
                Dim n As Integer = 0
                For i As Integer = 0 To Num - 1
                    Dim x As Single, y As Single
                    If Get_Enable_CenterP(x, y, MPObj(O_Code(i)), E_Time) = True Then
                        gx += x
                        gy += y
                        n += 1
                    End If
                Next
                With Obj.CenterPSTC(0).Position
                    .X = gx / n
                    .Y = gy / n
                End With
            End If
        Else
            '編入の場合の編入先オブジェクト
            Obj = Absorption(Num, LiveObject, O_Code, C_Time)
            If Change_ObjName_F = True Then
                With Obj
                    Dim n As Integer = .NumOfNameTime
                    .NumOfNameTime = n + 1
                    ReDim Preserve .NameTimeSTC(n)
                    With .NameTimeSTC(n - 1)
                        .SETime.EndTime = E_Time
                    End With
                    With .NameTimeSTC(n)
                        .NamesList = O_names.Clone
                        .SETime.StartTime = C_Time
                        .SETime.EndTime = clsTime.GetNullYMD
                    End With
                End With
            End If
        End If

        Return Obj
    End Function

    ''' <summary>
    ''' 時空間モードでのオブジェクト編入合併を行い、編入先のオブジェクトを取得する
    ''' </summary>
    ''' <param name="Num">編入対象数</param>
    ''' <param name="Suc_num">対象数のうち編入先の番号</param>
    ''' <param name="O_Code">編入対象オブジェクト番号リスト</param>
    ''' <param name="C_Time">時期</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Absorption(ByVal Num As Integer, ByVal Suc_num As Integer, ByVal O_Code() As Integer, _
                                ByVal C_Time As strYMD) As strObj_Data
        '編入合併


        Dim E_Time As strYMD = clsTime.getYesterday(C_Time)
        Dim PushObj As strObj_Data = Me.MPObj(O_Code(Suc_num))

        Dim PushLCS_Enable(PushObj.NumOfLine) As Boolean
        For i As Integer = 0 To PushObj.NumOfLine - 1
            If Check_Enable_LineCode(PushObj.LineCodeSTC(i), E_Time) = -1 Then
                '構成要素が編入前日に利用不可
                PushLCS_Enable(i) = False
            Else
                PushLCS_Enable(i) = True
            End If
        Next

        Dim AddLCode() As Integer
        Dim U_Line() As clsMapData.EnableMPLine_Data
        Dim Use_Line() As Integer
        Dim checkN As Integer
        If Me.ObjectKind(PushObj.Kind).ObjectType = enmObjectGoupType_Data.AggregationObject Then
            '集成オブジェクトで、編入されるオブジェクトの構成オブジェクトをチェックする
            ReDim Use_Line(Me.Map.Kend)
            Dim Obj() As Integer
            Dim n2 As Integer = 0
            For i As Integer = 0 To Num - 1
                Dim n3 As Integer = Get_EnableObj_used_AggregateObject(Me.MPObj(O_Code(i)), E_Time, Obj)
                For j As Integer = 0 To n3 - 1
                    Use_Line(Obj(j)) += 1
                Next
                n2 += n3
            Next
            ReDim AddLCode(n2)
            checkN = Me.Map.Kend
        Else
            '通常のオブジェクトで編入されるオブジェクトの使用するラインをチェックする
            ReDim Use_Line(Me.Map.ALIN)
            Dim n2 As Integer = 0
            For i As Integer = 0 To Num - 1
                If i <> Suc_num Then
                    '継承先オブジェクトの使用ラインはチェックしない
                    Dim n3 As Integer = Get_EnableMPLine(U_Line, Me.MPObj(O_Code(i)), E_Time)
                    For j As Integer = 0 To n3 - 1
                        Use_Line(U_Line(j).LineCode) += 1
                    Next
                    n2 += n3
                End If
            Next
            ReDim AddLCode(n2)
            checkN = Me.Map.ALIN
        End If

        '編入されるオブジェクトの使用するラインと、編入先間オブジェクトの使用するラインの検討
        Dim AddNum As Integer = 0
        For i As Integer = 0 To checkN - 1
            If Use_Line(i) = 1 Then
                Dim c As Integer = -1
                For j As Integer = 0 To PushObj.NumOfLine - 1
                    If i = PushObj.LineCodeSTC(j).LineCode And PushLCS_Enable(j) = True Then
                        c = j
                        Exit For
                    End If
                Next
                If c = -1 Then
                    '編入先で使われていない構成要素を追加
                    AddLCode(AddNum) = i
                    AddNum += 1
                Else
                    'If MapEditing.EditedObjectGroupType = clsMapData.enmObjectGoupType_Data.NormalObject Then 'なぜVB6ではこれか不明
                    If Me.ObjectKind(PushObj.Kind).ObjectType = enmObjectGoupType_Data.NormalObject Then
                        '通常のオブジェクトの場合で、編入先で使われていて、編入元でも使われているラインの場合は、終了時期を設定する
                        With PushObj.LineCodeSTC(c)
                            If .NumOfTime = 0 Then
                                '時間設定がなかった場合は終了時期を追加
                                ReDim .Times(0)
                                With .Times(0)
                                    .StartTime = clsTime.GetNullYMD
                                    .EndTime = E_Time
                                End With
                                .NumOfTime = 1
                            Else
                                With .Times(.NumOfTime - 1)
                                    .EndTime = E_Time
                                End With
                            End If
                        End With
                    End If
                End If
            End If
        Next

        '編入先にラインを追加
        With PushObj
            ReDim Preserve .LineCodeSTC(.NumOfLine + AddNum - 1)
            For i As Integer = 0 To AddNum - 1
                With .LineCodeSTC(i + PushObj.NumOfLine)
                    .LineCode = AddLCode(i)
                    .NumOfTime = 1
                    ReDim .Times(0)
                    With .Times(0)
                        .StartTime = C_Time
                        .EndTime = clsTime.GetNullYMD
                    End With
                End With
            Next
            .NumOfLine += AddNum
        End With


        Return PushObj
    End Function

    ''' <summary>
    ''' 指定した集成オブジェクトの構成要素に時間設定があるかチェック
    ''' </summary>
    ''' <param name="Obj">集成オブジェクト</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_AggrObject_relatedTime_Exists(ByVal Obj As strObj_Data) As Boolean
        Dim TM As Integer
        Dim Tms() As strYMD

        TM = Get_AggrObject_relatedTime(Obj, Tms)
        If TM = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' 集成オブジェクトの外側輪郭線を通時的に取得
    ''' </summary>
    ''' <param name="Obj">集成オブジェクト</param>
    ''' <param name="AggrLineNumber">構成ライン（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_AggrOuterLine_AllTime(ByVal Obj As strObj_Data, ByRef AggrLineNumber() As Integer) As Integer


        Dim ELNT As Long, EnLine() As Boolean
        Dim ELine() As EnableMPLine_Data

        Dim ELN As Integer
        If Map.Time_Mode = False Then
            ELN = Get_EnableMPLine(ELine, Obj, clsTime.GetNullYMD)
            ReDim AggrLineNumber(Math.Max(ELN - 1, 0))
            For i As Integer = 0 To ELN - 1
                AggrLineNumber(i) = ELine(i).LineCode
            Next

        Else
            Dim Times() As strYMD
            Dim TimeN As Integer = Get_AggrObject_relatedTime(Obj, Times)

            If TimeN = 0 Then
                ELN = Get_EnableMPLine(ELine, Obj, clsTime.GetNullYMD)
                ReDim AggrLineNumber(ELN)
                For i As Integer = 0 To ELN - 1
                    AggrLineNumber(i) = ELine(i).LineCode
                Next
            Else
                ReDim EnLine(Map.ALIN - 1)
                For i As Integer = 0 To TimeN - 1
                    ELNT = Get_EnableMPLine(ELine, Obj, Times(i))
                    For j As Integer = 0 To ELNT - 1
                        EnLine(ELine(j).LineCode) = True
                    Next
                Next
                ELN = clsGeneric.Get_Specified_Value_Array(EnLine, Map.ALIN, True, AggrLineNumber)
            End If
        End If
        Return ELN
    End Function

    Dim Re_Times As clsSortingSearch   '時空間モードの集成オブジェクトの構成ラインを通時的に取得するための再帰処理用

    ''' <summary>
    ''' 集成オブジェクトの変化に関連する時間を取得する
    ''' </summary>
    ''' <param name="Obj">集成オブジェクト</param>
    ''' <param name="Times"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_AggrObject_relatedTime(ByVal Obj As strObj_Data, ByRef Times() As strYMD) As Integer
        '
        Dim Tms() As strYMD

        Re_Times = New clsSortingSearch(VariantType.Integer) 'Re_Timesは再帰処理のためにスコープがクラス全体
        Dim t As Start_End_Time_data = clsTime.GetNullStartEndYMD
        Call Get_MpObjTime_used_AggregateObject_Sub(Obj, t)
        Re_Times.AddEnd()

        ReDim Tms(Re_Times.NumofData)
        Dim n As Integer = 0
        For i As Integer = 0 To Re_Times.NumofData - 1
            Dim TM As strYMD = clsTime.GetYMDfromValue(Re_Times.DataPositionValue_Integer(i))
            If TM.nullFlag = False Then
                If CheckEnableObject(Obj, TM) = True Then
                    Dim f As Boolean = True
                    If i > 0 And i <> Re_Times.NumofData - 1 Then
                        Dim TM2 As strYMD = clsTime.GetYMDfromValue(Re_Times.DataPositionValue_Integer(i - 1))
                        If TM.Equals(TM2) Or TM.Equals(clsTime.getTomorrow(TM2)) Then
                            f = False
                        End If
                    End If
                    If f = True Then
                        Tms(n) = TM
                        n += 1
                    End If
                End If
            End If
        Next

        Re_Times = Nothing
        ReDim Preserve Tms(n)
        Times = Tms
        Return n
    End Function

    ''' <summary>
    ''' 集成オブジェクトの変化に関連する時間を取得する（再帰処理用）
    ''' </summary>
    ''' <param name="ObjData">集成オブジェクト</param>
    ''' <param name="checkSETime"></param>
    ''' <remarks></remarks>
    Private Sub Get_MpObjTime_used_AggregateObject_Sub(ByRef ObjData As strObj_Data, ByRef checkSETime As Start_End_Time_data)


        Dim Hennyuu_Data() As Hennyu_Data


        With ObjData
            '継承先時期
            For i As Integer = 0 To .NumOfSuc - 1
                If clsTime.checkDurationIn(checkSETime, .SucSTC(i).Time) = True Then
                    Re_Times.Add(clsTime.YMDtoValue(.SucSTC(i).Time))
                End If
            Next
            '継承された時期

            Dim n As Integer = Get_Hennyu_Object(ObjData, Hennyuu_Data)
            For i As Integer = 0 To n - 1
                Re_Times.Add(clsTime.YMDtoValue(Hennyuu_Data(i).Time))
            Next

            For ii As Integer = 0 To .NumOfNameTime - 1
                'オブジェクトの存在期間分のループ
                If clsTime.checkDurationOverlapped(.NameTimeSTC(ii).SETime, checkSETime) = True Then
                    ''オブジェクトの存在期間が対象期間内の場合
                    With .NameTimeSTC(ii)
                        If clsTime.checkDurationIn(checkSETime, .SETime.StartTime) = True Then
                            'オブジェクトの開始時期をスタックに入れる
                            Re_Times.Add(clsTime.YMDtoValue(checkSETime.StartTime))
                        End If
                        If clsTime.checkDurationIn(checkSETime, .SETime.EndTime) = True Then
                            'オブジェクトの終了時期をスタックに入れる
                            Re_Times.Add(clsTime.YMDtoValue(checkSETime.EndTime))
                        End If
                    End With
                    Dim Time2 As Start_End_Time_data
                    Time2.StartTime = clsTime.getLatter(.NameTimeSTC(ii).SETime.StartTime, checkSETime.StartTime)
                    Time2.EndTime = clsTime.getEarlier(.NameTimeSTC(ii).SETime.EndTime, checkSETime.EndTime)
                    For i As Integer = 0 To .NumOfLine - 1
                        'オブジェクトの構成オブジェクト分ループする
                        With .LineCodeSTC(i)
                            Dim lc As Integer = .LineCode
                            If .NumOfTime = 0 Then
                                If ObjectKind(ObjData.Kind).ObjectType = enmObjectGoupType_Data.AggregationObject Then
                                    Call Get_MpObjTime_used_AggregateObject_Sub(Me.MPObj(lc), Time2)
                                Else
                                    '通常のオブジェクトはラインの存在期間をチェック
                                    Call Get_MpObjTime_used_AggregateObject_LineSub(lc, Time2)
                                End If
                            Else
                                For j As Integer = 0 To .NumOfTime - 1
                                    '構成要素の存在時期分ループする
                                    With .Times(j)
                                        Dim Time3 As Start_End_Time_data
                                        If clsTime.checkDurationIn(Time2, .StartTime) = True Then
                                            Re_Times.Add(clsTime.YMDtoValue(.StartTime))
                                        End If
                                        If clsTime.checkDurationIn(Time2, .EndTime) = True Then
                                            Re_Times.Add(clsTime.YMDtoValue(.EndTime))
                                        End If
                                        '構成要素のオブジェクトについて、時間を限定して再帰処理する
                                        If ObjectKind(ObjData.Kind).ObjectType = enmObjectGoupType_Data.AggregationObject Then
                                            Time3.StartTime = clsTime.getLatter(.StartTime, Time2.StartTime)
                                            Time3.EndTime = clsTime.getEarlier(.EndTime, Time2.StartTime)
                                            Call Get_MpObjTime_used_AggregateObject_Sub(Me.MPObj(lc), Time3)
                                        Else
                                            '通常のオブジェクトはラインの存在期間をチェック
                                            Call Get_MpObjTime_used_AggregateObject_LineSub(lc, Time3)
                                        End If
                                    End With
                                Next
                            End If
                        End With
                    Next
                End If
            Next
        End With

    End Sub
    ''' <summary>
    ''' 集成オブジェクトを構成する通常オブジェクトの使用期間が、開始時期と終了時期が指定期間に含まれる場合にRE_Timeに追加する
    ''' </summary>
    ''' <param name="lc">ライン番号</param>
    ''' <param name="checkSETime">期間</param>
    ''' <remarks></remarks>
    Private Sub Get_MpObjTime_used_AggregateObject_LineSub(ByVal lc As Integer, ByRef checkSETime As Start_End_Time_data)

        With MPLine(lc)
            For k As Integer = 0 To .NumOfTime - 1
                With .LineTimeSTC(k).SETime
                    If clsTime.checkDurationIn(checkSETime, .StartTime) = True Then
                        Re_Times.Add(clsTime.YMDtoValue(.StartTime))
                    End If
                    If clsTime.checkDurationIn(checkSETime, .EndTime) = True Then
                        Re_Times.Add(clsTime.YMDtoValue(.EndTime))
                    End If
                End With
            Next
        End With
    End Sub
    ''' <summary>
    ''' 使用していない線種を削除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Erase_Non_Use_Linekind()

        Dim LNum_by_Lkind() As Integer = Get_LineKind_Use_Number()
        For i As Integer = Me.Map.LpNum - 1 To 0 Step -1
            If LNum_by_Lkind(i) = 0 Then
                Call Erase_LineKind(i)
            End If
        Next

    End Sub
    ''' <summary>
    ''' 指定したライン中の同一座標の連続を削除して戻す
    ''' </summary>
    ''' <param name="Line">ライン</param>
    ''' <remarks></remarks>
    Private Sub DeleteSamePoints_inLine(ByRef Line As strLine_Data)

        Dim ReMovePoint() As PointF

        With Line
            If .NumOfPoint > 0 Then
                ReDim ReMovePoint(.NumOfPoint - 1)
                ReMovePoint(0) = .PointSTC(0)
                Dim k As Integer = 1
                For j As Integer = 1 To .NumOfPoint - 1
                    If .PointSTC(j - 1).Equals(.PointSTC(j)) <> True Then
                        ReMovePoint(k) = .PointSTC(j)
                        k += 1
                    End If
                Next
                If .NumOfPoint <> k Then
                    ReDim Preserve ReMovePoint(k - 1)
                    .PointSTC = ReMovePoint
                    .NumOfPoint = k
                End If
            End If
        End With
    End Sub
    ''' <summary>
    ''' 点が二つで、ループで、かつ終点と始点が同じ、または点が二つ未満のラインを削除
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Erase_Irregular_Line()

        If Me.Map.ALIN = 0 Then Exit Sub

        Dim ELCODE(Me.Map.ALIN - 1) As Integer, n As Integer
        For i As Integer = 0 To Me.Map.ALIN - 1
            With Me.MPLine(i)
                Dim f As Boolean = True
                Call DeleteSamePoints_inLine(Me.MPLine(i))
                If .NumOfPoint <= 1 Then
                    f = False
                ElseIf .NumOfPoint = 2 Then
                    If .PointSTC(0).Equals(.PointSTC(1)) = True Then
                        f = False
                    End If
                End If
                If f = False Then
                    ELCODE(n) = i
                    n += 1
                End If
            End With
        Next
        Erase_MultiLine(n, ELCODE, True, False, True)
    End Sub
    ''' <summary>
    ''' 線または面オブジェクトで、ラインを持たないオブジェクトを削除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Erase_Irregular_Object()

        If Me.Map.Kend = 0 Then
            Exit Sub
        End If

        Dim DelList(Me.Map.Kend - 1) As Integer
        Dim n As Integer = 0
        For i As Integer = 0 To Me.Map.Kend - 1
            With Me.MPObj(i)
                If .Shape = enmShape.LineShape Or .Shape = enmShape.PolygonShape Or
                    Me.ObjectKind(.Kind).Shape = enmShape.LineShape Or Me.ObjectKind(.Kind).Shape = enmShape.PolygonShape Then
                    If .NumOfLine = 0 Then
                        DelList(n) = i
                        n += 1
                    End If
                End If
            End With
        Next
        If n > 0 Then
            Call Erase_MultiObjects(n, DelList, True)
        End If

    End Sub
    ''' <summary>
    ''' オブジェクトによるラインの使用回数を求める
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub countNumOfLineUse()

        For i As Integer = 0 To Me.Map.ALIN - 1
            Me.MPLine(i).NumOfLineUse = 0
        Next
        For i As Integer = 0 To Me.Map.Kend - 1
            With Me.MPObj(i)
                If Me.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                    For j As Integer = 0 To .NumOfLine - 1
                        With .LineCodeSTC(j)
                            Me.MPLine(.LineCode).NumOfLineUse += 1
                        End With
                    Next
                End If
            End With
        Next

    End Sub

    ''' <summary>
    ''' ラインの初期化
    ''' </summary>
    ''' <param name="LineKindNumber">線種番号</param>
    ''' <remarks></remarks>
    Public Function Init_One_Line(ByVal LineKindNumber As Integer) As strLine_Data
        Dim Line As strLine_Data
        With Line
            .Number = -1
            .NumOfPoint = 0
            .NumOfTime = 1
            ReDim .LineTimeSTC(0)
            .LineTimeSTC(0).Kind = LineKindNumber
            .LineTimeSTC(0).SETime = clsTime.GetNullStartEndYMD
            ReDim .PointSTC(0)
        End With
        Return Line
    End Function
    ''' <summary>
    ''' 初期化したオブジェクトを返す
    ''' </summary>
    ''' <param name="ObjectKindNumber">オブジェクトグループ番号</param>
    ''' <remarks></remarks>
    Public Function Init_One_Object(ByVal ObjectKindNumber As Integer) As strObj_Data
        Dim Obj As New strObj_Data
        With Obj
            .Number = -1
            .NumOfNameTime = 1
            .NumOfCenterP = 1
            .NumOfLine = 0
            .NumOfSuc = 0
            .Shape = enmShape.PointShape
            .Kind = ObjectKindNumber
            With Me.ObjectKind(ObjectKindNumber)
                If .DefTimeAttDataNum > 0 Then
                    ReDim Obj.DefTimeAttValue(.DefTimeAttDataNum - 1)
                    For i As Integer = 0 To .DefTimeAttDataNum - 1
                        ReDim Obj.DefTimeAttValue(i).Data(0)
                    Next
                End If
            End With
            ReDim .SucSTC(0)
            ReDim .NameTimeSTC(0)
            ReDim .NameTimeSTC(0).NamesList(Me.ObjectKind(ObjectKindNumber).ObjectNameNum - 1)
            With .NameTimeSTC(0)
                ReDim .NamesList(ObjectKind(ObjectKindNumber).ObjectNameNum - 1)
                .SETime = clsTime.GetNullStartEndYMD
            End With
            ReDim .CenterPSTC(0)
            With .CenterPSTC(0)
                .SETime = clsTime.GetNullStartEndYMD
            End With
        End With
        Return Obj
    End Function


    ''' <summary>
    ''' データ中にまったく同じラインがあった場合は一方を削除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Remove_SameLine()
        Dim i As Integer = 0
        Do
            Dim j As Integer = i + 1
            Do
                If Check_Two_Line_Same(i, j) = True Then
                    For k As Integer = 0 To Me.Map.Kend - 1
                        With Me.MPObj(k)
                            If Me.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                                For k2 As Integer = 0 To .NumOfLine - 1
                                    With .LineCodeSTC(k2)
                                        If .LineCode = j Then
                                            .LineCode = i
                                        End If
                                    End With
                                Next
                            End If
                        End With
                    Next
                    Call Erase_Line(j, False)
                Else
                    j += 1
                End If
            Loop While j < Me.Map.ALIN
            i += 1
        Loop While i < Me.Map.ALIN - 1

    End Sub
    ''' <summary>
    ''' 二つのラインが全く同じ位置・線種・時期のものであるかどうかをチェック同じならtrueを返す
    ''' </summary>
    ''' <param name="LCode1"></param>
    ''' <param name="LCode2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Two_Line_Same(ByVal LCode1 As Integer, ByVal LCode2 As Integer) As Boolean

        Dim f As Boolean = False
        If Check_Time_Of_Two_Lines(LCode1, LCode2) = True Then
            If Check_Points_Of_Two_Lines(LCode1, LCode2) = True Then
                f = True
            End If
        End If
        Return f
    End Function
    ''' <summary>
    ''' 二つのラインの時間設定・線種が同じならtrueを返す
    ''' </summary>
    ''' <param name="LCode1"></param>
    ''' <param name="LCode2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Time_Of_Two_Lines(ByVal LCode1 As Integer, ByVal LCode2 As Integer) As Boolean

        Dim f As Boolean
        If MPLine(LCode1).NumOfTime = MPLine(LCode2).NumOfTime Then
            For i As Integer = 0 To MPLine(LCode1).NumOfTime - 1
                If MPLine(LCode1).LineTimeSTC(i).Equals(MPLine(LCode2).LineTimeSTC(i)) = True Then
                    f = True
                Else
                    f = False
                    Exit For
                End If
            Next
        Else
            f = False
        End If
        Return f
    End Function
    ''' <summary>
    ''' 二つのライン番号のラインが全く同じ位置のものであるかどうかをチェック同じならtrueを返す
    ''' </summary>
    ''' <param name="LC1"></param>
    ''' <param name="LC2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Points_Of_Two_Lines(ByVal LC1 As Long, ByVal LC2 As Long) As Boolean

        Dim PNum1 As Integer = MPLine(LC1).NumOfPoint
        Dim PNum2 As Integer = MPLine(LC2).NumOfPoint
        Dim f2 As Boolean = False
        If PNum1 = PNum2 Then
            Dim f As Boolean = MPLine(LC1).Circumscribed_Rectangle.Equals(MPLine(LC2).Circumscribed_Rectangle)
            If f = True Then
                If Check_Line_Loop(LC1) = True And Check_Line_Loop(LC2) = True Then
                    'ループの場合
                    '最初に座標が一致するポイントを取得
                    Dim s2 As Integer = -1
                    For i As Integer = 0 To PNum2 - 1
                        If MPLine(LC1).PointSTC(0).Equals(MPLine(LC2).PointSTC(i)) = True Then
                            s2 = i
                            i = PNum2
                        End If
                    Next
                    If s2 = -1 Then
                        f2 = False
                    Else
                        Dim s2p As Integer
                        If s2 = 0 Then
                            If MPLine(LC1).PointSTC(1).Equals(MPLine(LC2).PointSTC(1)) = True Then
                                s2p = 1
                            Else
                                s2p = -1
                            End If
                        Else
                            If MPLine(LC1).PointSTC(1).Equals(MPLine(LC2).PointSTC(s2 - 1)) = True Then
                                s2p = -1
                            Else
                                s2p = 1
                            End If
                        End If
                        f2 = True
                        Dim i As Integer = 0
                        Dim j As Integer = s2
                        Do While f2 = True And i < PNum1
                            f2 = MPLine(LC1).PointSTC(i).Equals(MPLine(LC2).PointSTC(j))
                            i = i + 1
                            j = j + s2p
                            If j < 0 Then
                                j = PNum2 - 2
                            ElseIf j >= PNum2 Then
                                j = 1
                            End If
                        Loop
                    End If
                Else
                    'ループでない場合
                    If MPLine(LC1).PointSTC(0).Equals(MPLine(LC2).PointSTC(0)) = True Then
                        f2 = True
                        For i As Integer = 1 To PNum1 - 1
                            If MPLine(LC1).PointSTC(i).Equals(MPLine(LC2).PointSTC(i)) = False Then
                                f2 = False
                                Exit For
                            End If
                        Next
                    ElseIf MPLine(LC1).PointSTC(0).Equals(MPLine(LC2).PointSTC(PNum1 - 1)) Then
                        f2 = True
                        For i As Integer = 1 To PNum1 - 1
                            If MPLine(LC1).PointSTC(i).Equals(MPLine(LC2).PointSTC(PNum1 - 1 - i)) = False Then
                                f2 = False
                                Exit For
                            End If
                        Next
                    End If
                End If
            End If
        End If
        Return f2
    End Function
    ''' <summary>
    ''' ラインがループの場合trueを返す
    ''' </summary>
    ''' <param name="LCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_Line_Loop(ByVal LCode As Integer) As Boolean
        'ラインがループかどうかを調べる
        With MPLine(LCode)
            Return .PointSTC(0).Equals(.PointSTC(.NumOfPoint - 1))
        End With
    End Function


    ''' <summary>
    ''' 指定したオブジェクト番号のオブジェクトを、集成オブジェクトの構成要素として使用しているオブジェクトの一覧を取得
    ''' </summary>
    ''' <param name="O_Code">調べるオブジェクト番号</param>
    ''' <param name="Aggr_Object_Used">使用している集成オブジェクト番号のList(Of Integer)（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Aggregation_Object(ByVal O_Code As Integer) As List(Of Integer)

        Dim ObData As New List(Of Integer)
        If O_Code = -1 Then
            Return ObData
        End If
        Dim f As Boolean = False
        For i As Integer = 0 To Me.Map.OBKNum - 1
            If Me.ObjectKind(i).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                f = True
                Exit For
            End If
        Next
        If f = False Then
            Return ObData
        End If

        Dim n As Integer = 0
        For i As Integer = 0 To Me.Map.Kend - 1
            With Me.MPObj(i)
                If Me.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                    For j As Integer = 0 To .NumOfLine - 1
                        If .LineCodeSTC(j).LineCode = O_Code Then
                            ObData.Add(i)
                            Exit For
                        End If
                    Next
                End If
            End With
        Next
        Return ObData
    End Function


    ''' <summary>
    ''' 地図ファイル中のオブジェクト名の重複をチェック、時間考慮無しなので複数の同一名称オブジェクトも取得
    ''' 重複していなければ-1を、重複している場合はそのコードを返す
    ''' </summary>
    ''' <param name="Ex_Code">比較しないオブジェクトコード</param>
    ''' <param name="Name"></param>
    ''' <param name="code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function Check_ObjectName_OverLap_In_MapFile_NoTime(ByVal Ex_Code As Integer, ByVal Name As String, ByRef code() As Integer) As Integer


        Dim Ocode() As Integer
        ReDim Ocode(0)
        Dim n As Integer = 0
        If Name = "" Then
            Return 0
        End If
        For i As Integer = 0 To Me.Map.Kend - 1
            If i <> Ex_Code Then
                For j As Integer = 0 To Me.MPObj(i).NumOfNameTime - 1
                    With Me.MPObj(i).NameTimeSTC(j)
                        For k As Integer = 0 To .NamesList.Length - 1
                            If .NamesList(k) = Name Then
                                ReDim Preserve Ocode(n)
                                Ocode(n) = i
                                n += 1
                                j = Me.MPObj(i).NumOfNameTime
                                Exit For
                            End If
                        Next
                    End With
                Next
            End If
        Next
        code = Ocode
        Return n
    End Function
    ''' <summary>
    ''' オブジェクト番号のList(Of Integer)中のオブジェクトの形状が指定された形状だけだった場合はTrueを返す
    ''' </summary>
    ''' <param name="ObjectCode">オブジェクト番号のList(Of Integer)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Check_Same_ObjectShape_in_Multi_Objects(ByRef ObjectCode As List(Of Integer), ByVal shape As enmShape) As Boolean
        Dim OCode() As Integer = ObjectCode.ToArray
        Return Check_Same_ObjectShape_in_Multi_Objects(OCode.GetLength(0), OCode, shape)
    End Function
    ''' <summary>
    ''' 配列中のオブジェクトの形状が指定された形状だけだった場合はTrueを返す
    ''' </summary>
    ''' <param name="Num"></param>
    ''' <param name="ObjectCode">オブジェクト番号の配列</param>
    ''' <param name="shape"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Check_Same_ObjectShape_in_Multi_Objects(ByVal Num As Integer, ByRef ObjectCode() As Integer, ByVal shape As enmShape) As Boolean

        For i As Integer = 0 To Num - 1
            If Me.MPObj(ObjectCode(i)).Shape <> shape Then
                Return False
            End If
        Next
        Return True
    End Function


    ''' <summary>
    ''' 配列中のオブジェクトのオブジェクトグループが一種類だけだった場合はTrue複数はFalseを返す
    ''' </summary>
    ''' <param name="Num"></param>
    ''' <param name="ObjectCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_ObjectKind_for_Conbine(ByVal Num As Integer, ByRef ObjectCode() As Integer) As Boolean
        Dim k As Integer = Me.MPObj(ObjectCode(0)).Kind
        For i As Integer = 1 To Num - 1
            If Me.MPObj(ObjectCode(i)).Kind <> k Then
                Return False
            End If
        Next
        Return True

    End Function
    ''' <summary>
    ''' 重複したオブジェクト名をチェックして、重複しているなら-で数字を付ける
    ''' 対象は最初のスタックのNamelist(0)のみ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Check_and_Rename_of_OverLapped_Objectname()

        Dim ObjSort As New clsSortingSearch(VariantType.String)

        For i As Integer = 0 To Me.Map.Kend - 1
            ObjSort.Add(Me.MPObj(i).NameTimeSTC(0).NamesList(0))
        Next
        ObjSort.AddEnd()

        '同じ名前の一覧を取得
        Dim SameName() As String
        Dim sameNameNum As Integer = ObjSort.getSameValue_Alley(SameName)

        For i As Integer = 0 To sameNameNum - 1
            '同じ名前のオブジェクト番号を取得
            Dim SameNameObjList() As Integer
            Dim ObjNum As Integer = ObjSort.getSearchData_Allay(SameName(i), SameNameObjList)
            '後ろに-番号を付ける
            For j As Integer = 0 To ObjNum - 1
                With Me.MPObj(SameNameObjList(j)).NameTimeSTC(0)
                    .NamesList(0) = .NamesList(0) & "-" & CStr(j + 1)
                End With
            Next
        Next
    End Sub
    Public Function Get_MultiObject_Boundary(ByRef ObjNumber As List(Of Integer), ByVal Time As strYMD, _
                                             ByRef Boundary_LineCode() As Integer, ByRef RECT As RectangleF) As Integer

        Dim Values() As Integer = ObjNumber.ToArray
        Return Get_MultiObject_Boundary(Values, Values.GetUpperBound(0) + 1, Time, Boundary_LineCode, RECT)

        Return Get_MultiObject_Boundary
    End Function
    ''' <summary>
    ''' 複数のオブジェクトで共有するラインを除外した、全体としての輪郭線のライン番号とその数を返す
    ''' </summary>
    ''' <param name="ObjNumber">オブジェクト番号の配列</param>
    ''' <param name="ObjNum">オブジェクト数</param>
    ''' <param name="Time">時期</param>
    ''' <param name="Boundary_LineCode">ライン番号の配列（戻り値）</param>
    ''' <param name="RECT">全体の外接四角形（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_MultiObject_Boundary(ByVal ObjNumber() As Integer, ByVal ObjNum As Integer, ByVal Time As strYMD, _
                                             ByRef Boundary_LineCode() As Integer, ByRef RECT As RectangleF) As Integer

        Dim KBSUB() As Integer
        Dim E_Line() As EnableMPLine_Data
        Dim Poly_Rect As RectangleF
        Dim Ken_Boundary_Line() As Integer

        Dim Ken_Boundary_n As Integer = 0
        ReDim KBSUB(Me.Map.ALIN - 1)
        Poly_Rect = Me.MPObj(ObjNumber(0)).Circumscribed_Rectangle
        For i As Integer = 0 To ObjNum - 1
            Poly_Rect = spatial.Get_Circumscribed_Rectangle(Me.MPObj(ObjNumber(i)).Circumscribed_Rectangle, Poly_Rect)
            Dim n As Integer = Get_EnableMPLine(E_Line, Me.MPObj(ObjNumber(i)), Time)
            For j As Integer = 0 To n - 1
                KBSUB(E_Line(j).LineCode) = 1 - KBSUB(E_Line(j).LineCode)
            Next
        Next
        ReDim Ken_Boundary_Line(Me.Map.ALIN - 1)
        Ken_Boundary_n = 0
        For i As Integer = 0 To Me.Map.ALIN - 1
            If KBSUB(i) = 1 Then
                Ken_Boundary_Line(Ken_Boundary_n) = i
                Ken_Boundary_n += 1
            End If
        Next
        ReDim Preserve Ken_Boundary_Line(Ken_Boundary_n)

        RECT = Poly_Rect
        Boundary_LineCode = Ken_Boundary_Line
        Return Ken_Boundary_n

    End Function
    ''' <summary>
    ''' 指定したラインのポイントを削除してスムージングするルーチン
    ''' </summary>
    ''' <param name="Line">ライン</param>
    ''' <param name="s_distance">基準距離</param>
    ''' <remarks></remarks>
    Public Sub Smoothing_Line_by_LineCode(ByRef Line As strLine_Data, ByVal s_distance As Single)
        '
        'L_code:対象ラインコード
        's_distance:これ以下の距離のポイントはくっつける
        'Mode:0/スケールに応じた面積　1:スケールは考慮しない

        Dim FirstPointNum As Integer
        Dim PointXY() As PointF
        Dim PointXY2() As PointF

        FirstPointNum = Line.NumOfPoint

        If FirstPointNum <= 3 Then Exit Sub

        PointXY = Line.PointSTC.Clone

        Dim newP = Smoothing_Line(PointXY, FirstPointNum, PointXY2, s_distance)

        For i As Integer = 0 To newP - 1
            Line.PointSTC(i) = PointXY2(i)
        Next
        Line.NumOfPoint = newP
        ReDim Preserve Line.PointSTC(newP - 1)

    End Sub
    ''' <summary>
    ''' 線のポイントを指定した距離に応じて削除、座標と数を返すルーチン
    ''' </summary>
    ''' <param name="PointXY"> 線の座標</param>
    ''' <param name="FirstPointNum">当初のポイント数</param>
    ''' <param name="Out_Point">出力座標</param>
    ''' <param name="s_distanceas">基準距離</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Smoothing_Line(ByVal PointXY() As PointF, ByVal FirstPointNum As Integer, ByRef Out_Point() As PointF, ByVal s_distanceas As Single) As Integer

        If FirstPointNum <= 3 Then
            Out_Point = PointXY
            Return FirstPointNum
        End If

        Dim LoopF As Boolean
        If PointXY(0).Equals(PointXY(FirstPointNum - 1)) = True Then
            LoopF = True
        Else
            LoopF = False
        End If

        Dim Push_point(FirstPointNum - 1) As PointF
        Dim ts As Integer = FirstPointNum
        Dim n As Integer = 0
        Dim Cng_f As Boolean

        Do
            Cng_f = False
            For k As Integer = 0 To 1
                FirstPointNum = ts
                If k = 1 Then
                    Push_point(1) = PointXY(1)
                End If
                n = 1 + k
                If LoopF = True And FirstPointNum <= 8 Then
                    Exit Do
                End If
                For j As Integer = 1 + k To FirstPointNum - 3 Step 2
                    Dim D As Single
                    If Me.Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                        D = spatial.Distance_Ido_Kedo_XY(PointXY(j).X, PointXY(j).Y, PointXY(j + 1).X, PointXY(j + 1).Y, Me.Map.Zahyo)
                    Else
                        D = spatial.get_Distance(PointXY(j), PointXY(j + 1)) / Me.Map.SCL
                    End If
                    If D < s_distanceas Then
                        Push_point(n).X = (PointXY(j).X + PointXY(j + 1).X) / 2
                        Push_point(n).Y = (PointXY(j).Y + PointXY(j + 1).Y) / 2
                        n += 1
                        Cng_f = True
                    Else
                        Push_point(n) = PointXY(j)
                        Push_point(n + 1) = PointXY(j + 1)
                        n += 2
                    End If
                Next
                If (FirstPointNum Mod 2 = 1 And k = 0) Or (FirstPointNum Mod 2 = 0 And k = 1) Then
                    Push_point(n) = PointXY(FirstPointNum - 2)
                    n += 1
                End If
                Push_point(0) = PointXY(0)
                Push_point(n) = PointXY(FirstPointNum - 1)
                n += 1
                For j As Integer = 0 To n - 1
                    PointXY(j) = Push_point(j)
                Next
                ts = n
            Next k
        Loop While Cng_f = True


        Out_Point = PointXY
        Return ts

    End Function
    ''' <summary>
    ''' オブジェクトの使用するライン、または集成オブジェクトの使用するオブジェクトの重複をチェックし、重複していたら修正するして戻す
    ''' </summary>
    ''' <param name="ObjDataOrigin">オブジェクト（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function check_Line_or_Aggrobj_DoubleUse(ByRef ObjDataOrigin As clsMapData.strObj_Data) As Boolean

        Dim ObjData As clsMapData.strObj_Data = ObjDataOrigin

        Dim f As Boolean
        With ObjData

            Dim n As Integer = .NumOfLine
            Dim ck(n) As Integer
            For i = 0 To n - 1
                ck(i) = -1
            Next

            f = False
            For i As Integer = 0 To n - 1
                If ck(i) = -1 Then
                    Dim c As Integer = .LineCodeSTC(i).LineCode
                    For j As Integer = i + 1 To .NumOfLine - 1
                        If c = .LineCodeSTC(j).LineCode And ck(j) = -1 Then
                            '重複していた場合
                            f = True
                            ck(j) = i
                            Dim nt2 As Integer = .LineCodeSTC(j).NumOfTime
                            '構成期間を設定する
                            If nt2 >= 1 Then
                                Dim nt1 As Integer = .LineCodeSTC(i).NumOfTime
                                ReDim Preserve .LineCodeSTC(i).Times(nt1 + nt2 - 1)
                                .LineCodeSTC(i).NumOfTime = nt1 + nt2
                                For k As Integer = 0 To nt2 - 1
                                    .LineCodeSTC(i).Times(nt1 + k) = .LineCodeSTC(j).Times(k)
                                Next
                            End If
                        End If
                    Next
                End If
            Next

            If f = True Then
                Dim n2 As Integer = 0
                For i As Integer = 0 To n - 1
                    If ck(i) = -1 Then
                        .LineCodeSTC(n2) = .LineCodeSTC(i)
                        n2 += 1
                    End If
                Next
                .NumOfLine = n2
                ReDim Preserve .LineCodeSTC(n2)
            End If

        End With

        If f = False Then
            Return True
        Else
            ObjDataOrigin = ObjData
            Return False
        End If

    End Function
    ''' <summary>
    ''' 線種を一つ追加する
    ''' </summary>
    ''' <param name="LineKindName">線種名</param>
    ''' <param name="LPat">ラインパターン</param>
    ''' <param name="LMesh">メッシュタイプ</param>
    ''' <remarks></remarks>
    Public Sub Add_OneLineKind(ByVal LineKindName As String, ByRef LPat As Line_Property, ByVal LMesh As enmMesh_Number)

        ReDim Preserve Me.LineKind(Map.LpNum)
        Me.LineKind(Map.LpNum) = Get_OneLineKind_Parameter(LineKindName, LPat, LMesh)
        Map.LpNum += 1
        For i As Integer = 0 To Map.OBKNum - 1
            ReDim Preserve ObjectKind(i).UseLineType(Map.LpNum - 1)
        Next
    End Sub

    Public Function Get_OneLineKind_Parameter(ByVal LineKindName As String, ByRef LPat As Line_Property, ByVal LMesh As enmMesh_Number) As LineKind_Data
        Dim Lkind As LineKind_Data
        With Lkind
            ReDim .ObjGroup(0)
            .Name = LineKindName
            .ObjGroup(0).Pattern = LPat
            .Mesh = LMesh
            .NumofObjectGroup = 1
        End With
        Return Lkind
    End Function
    ''' <summary>
    ''' オブジェクトグループの代表点の色の初期値を決める(同時に全部)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Set_First_ObjectKind_Color()

        For i As Integer = 0 To Map.OBKNum - 1
            ObjectKind(i).Color = Set_First_ObjectKind_Color_Solo(i)
        Next
    End Sub
    ''' <summary>
    ''' オブジェクトグループの代表点の色の初期値を決める（一つずつ）
    ''' </summary>
    ''' <param name="ObkCode">オブジェクトグループ番号</param>
    ''' <returns>色構造体</returns>
    ''' <remarks></remarks>
    Public Function Set_First_ObjectKind_Color_Solo(ByVal ObkCode As Integer) As colorARGB

        Dim Object_Color(5) As Integer

        Object_Color(0) = QBColor(10)
        Object_Color(1) = QBColor(9)
        Object_Color(2) = QBColor(11)
        Object_Color(3) = QBColor(13)
        Object_Color(4) = QBColor(14)
        Object_Color(5) = QBColor(8)

        Dim col As Integer = (Object_Color(ObkCode Mod 6) + Object_Color(((ObkCode \ 6) + ObkCode Mod 6) Mod 6)) / 2
        Return New colorARGB(255, ColorTranslator.FromWin32(col).ToArgb)
    End Function
    ''' <summary>
    ''' 単純な点オブジェクトを設定
    ''' </summary>
    ''' <param name="ObjKind"></param>
    ''' <param name="Name"></param>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="DefAttData"></param>
    ''' <remarks></remarks>
    Public Sub Get_Part_of_simple_point_object(ByVal ObjKind As Integer, ByVal Name As String, ByVal X As Single, ByVal Y As Single, ByVal DefAttData() As String)
        '

        Dim Onum As Integer = Me.Map.Kend
        CheckMPOb_Dim(Onum)
        MPObj(Onum) = Init_One_Object(ObjKind)

        With MPObj(Onum)
            .Number = Onum
            .Kind = ObjKind
            .Shape = enmShape.PointShape
            For i As Integer = 0 To ObjectKind(ObjKind).DefTimeAttDataNum - 1
                .DefTimeAttValue(i).Data(0).Value = DefAttData(i)
            Next
            With .NameTimeSTC(0)
                ReDim .NamesList(ObjectKind(ObjKind).ObjectNameNum - 1)
                .NamesList(0) = Name
            End With
            With .CenterPSTC(0).Position
                .X = X
                .Y = Y
            End With
        End With

        With Map
            .Kend += 1
        End With

    End Sub
    Public Sub CheckMPOb_Dim(ByVal n As Integer)
        If Me.MPObj.GetUpperBound(0) < n Then
            ReDim Preserve Me.MPObj(n)
        End If
    End Sub
    Public Sub CheckMPLine_Dim(ByVal n As Integer)
        If Me.MPLine.GetUpperBound(0) < n Then
            ReDim Preserve Me.MPLine(n)
        End If
    End Sub
    ''' <summary>
    ''' 複数のライン間で交点を求め、分割
    ''' </summary>
    ''' <param name="CutLineList">ライン番号のList</param>
    ''' <param name="Same_LineKind_Cut_F">複数の線種が含まれる場合、同一線種の交差で切断する場合true。ただし、時間設定で同一ラインに複数の線種が設定してある場合は、最初の線種が使用される。</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CutLine_by_CrossPoint(ByVal CutLineList As List(Of Integer), ByVal Same_LineKind_Cut_F As Boolean) As Boolean
        '単精度座標の浮動小数点演算に伴う誤差をなくすために数値化
        For i As Integer = 0 To Me.Map.ALIN - 1
            With Me.MPLine(i)
                For j = 0 To .NumOfPoint - 1
                    With .PointSTC(j)
                        .X = CSng(CDec(.X))
                        .Y = CSng(CDec(.Y))
                    End With
                Next
                With .Circumscribed_Rectangle
                    Me.MPLine(i).Circumscribed_Rectangle = RectangleF.FromLTRB(CSng(CDec(.Left)), CSng(CDec(.Top)), CSng(CDec(.Right)), CSng(CDec(.Bottom)))
                End With
            End With
        Next

        '同一座標の連続を削除
        For Each i As Integer In CutLineList
            DeleteSamePoints_inLine(i)
            'If Me.MPLine(i).NumOfPoint <= 1 Then
            '    Taisho_Line(i) = False
            'End If
        Next

        Dim CutLineListNum As Integer = CutLineList.Count
        'ポイントの多い順に作業すると多少速くなるのでソートする
        Dim pnumd As New List(Of Integer)
        Dim Psort As New clsSortingSearch
        Psort.AddInit(VariantType.Integer)
        For i As Integer = 0 To CutLineListNum - 1
            Psort.Add(Me.MPLine(CutLineList.Item(i)).NumOfPoint)
        Next
        Psort.AddEnd()
        For i As Integer = 0 To CutLineListNum - 1
            pnumd.Add(CutLineList.Item(Psort.DataPositionRev(i)))
        Next

        Dim ii As Integer = 0
        Do
            Dim L1 As Integer = pnumd.Item(ii)
            Dim ikind As Integer = Me.MPLine(L1).LineTimeSTC(0).Kind
            For j As Integer = 0 To CutLineListNum - 1
                Dim L2 As Integer = pnumd(j)
                Dim jkind As Integer = MPLine(L2).LineTimeSTC(0).Kind
                If L1 <> L2 And (ikind <> jkind Or Same_LineKind_Cut_F = True) Then
                    Dim CP1 As Integer
                    Dim CP2 As Integer
                    Dim AM_Cross1() As Cross_Line_Data
                    Dim AM_Cross2() As Cross_Line_Data
                    Dim f As Boolean = spatial.Check_Two_Line_Cross(Me.MPLine(L1).PointSTC, Me.MPLine(L2).PointSTC,
                                                                    Me.MPLine(L1).NumOfPoint, Me.MPLine(L2).NumOfPoint,
                                                                    Me.MPLine(L1).Circumscribed_Rectangle, Me.MPLine(L2).Circumscribed_Rectangle,
                                                                    CP1, CP2,
                                                                    AM_Cross1, AM_Cross2)
                    If f = True Then
                        '交差していたら
                        'まずiラインの切断
                        Dim ODALIN1 As Integer = Map.ALIN
                        If CP1 > 0 Then
                            Cut_Line_Object_Shori(L1, ODALIN1, CP1)
                            Cut_Line(L1, CP1, AM_Cross1)
                        End If
                        'jのラインの切断
                        If CP2 > 0 Then
                            Dim ODALIN2 As Integer = Map.ALIN
                            Cut_Line_Object_Shori(L2, ODALIN2, CP2)
                            Cut_Line(L2, CP2, AM_Cross2)
                        End If
                        Dim Add_n As Integer = Map.ALIN - ODALIN1
                        CutLineListNum = CutLineListNum + Add_n
                        For k As Integer = 0 To Add_n - 1
                            pnumd.Add(ODALIN1 + k)
                        Next

                    End If
                End If
            Next
            ii += 1
        Loop While ii < CutLineListNum
        Call Erase_Irregular_Line()
        Check_ALl_Line_Connect()
        Return True

    End Function
    Private Sub Topology_Line_Object_Shori(ByVal Search_LineCode As Integer, ByVal Add_LineCode As Integer)
        '位相構造化したラインを使用するオブジェクトの修正
        Dim Add_LineCode_Stac() As Integer

        ReDim Add_LineCode_Stac(0)
        Add_LineCode_Stac(0) = Add_LineCode
        Call Object_LineCode_Add(Search_LineCode, 1, Add_LineCode_Stac)
    End Sub

    Private Sub Cut_Line_Object_Shori(ByVal Search_LineCode As Integer, ByVal ODALIN As Integer, ByVal num As Integer)
        '切断したラインを使用するオブジェクトの修正
        Dim Add_LineCode() As Integer

        ReDim Add_LineCode(num - 1)
        For i As Integer = 0 To num - 1
            Add_LineCode(i) = ODALIN + i
        Next
        Object_LineCode_Add(Search_LineCode, num, Add_LineCode)
    End Sub
    Private Sub Object_LineCode_Add(ByVal Search_LineCode As Integer, ByVal AddLineNum As Integer, Add_LineCode() As Integer)
        '切断したラインを使用するオブジェクトの修正

        For i As Integer = 0 To Map.Kend - 1
            With Me.MPObj(i)
                If Me.ObjectKind(.Kind).ObjectType = enmObjectGoupType_Data.NormalObject Then
                    Dim n As Integer = .NumOfLine
                    For j As Integer = 0 To n - 1
                        If .LineCodeSTC(j).LineCode = Search_LineCode Then
                            Move_LineCodeStac(i, n + AddLineNum, n)
                            For k As Integer = 0 To AddLineNum - 1
                                .LineCodeSTC(k + n) = .LineCodeSTC(j)
                                .LineCodeSTC(k + n).LineCode = Add_LineCode(k)
                            Next
                            Exit For
                        End If
                    Next
                End If
            End With
        Next

    End Sub
    Private Sub Cut_Line(ByVal LNumber As Integer, ByVal CP As Integer, ByVal AM_Cross() As Cross_Line_Data)


        Dim Am_Cross_S() As Cross_Line_Data, Cross_Temp As Cross_Line_Data


        '指定された位置でラインを切断

        '直前交点ポイントでソート
        Dim BpointSort As New clsSortingSearch
        BpointSort.AddInit(VariantType.Integer)
        For i As Integer = 0 To CP - 1
            BpointSort.Add(AM_Cross(i).BeforPoint)
        Next
        BpointSort.AddEnd()

        ReDim Am_Cross_S(CP - 1)
        For i As Integer = 0 To CP - 1
            Am_Cross_S(i) = AM_Cross(BpointSort.DataPosition(i))
        Next

        Dim inp As Integer = Me.MPLine(LNumber).NumOfPoint
        Dim PushMPPoint2(inp - 1) As PointF

        PushMPPoint2 = Me.MPLine(LNumber).PointSTC.Clone

        For i As Integer = 0 To CP - 2
            Dim i2 As Integer = 0
            Do
                i2 += 1
                If i + i2 = CP Then
                    Exit Do
                End If
            Loop While Am_Cross_S(i).BeforPoint = Am_Cross_S(i + i2).BeforPoint
            If i2 >= 2 Then
                'ポイント間に二つ以上の交点がある場合は、前のポイントからの距離順に並べる
                Dim Dis(i2 - 1) As Single
                With PushMPPoint2(Am_Cross_S(i).BeforPoint)
                    For j As Integer = 0 To i2 - 1
                        Dis(j) = spatial.get_Distance(.X, .Y, Am_Cross_S(i + j).Point.X, Am_Cross_S(i + j).Point.Y)
                    Next
                End With
                For j As Integer = 0 To i2 - 2
                    For k As Integer = j + 1 To i2 - 1
                        If Dis(k) < Dis(j) Then
                            clsGeneric.SWAP(Dis(k), Dis(j))
                            Cross_Temp = Am_Cross_S(i + k)
                            Am_Cross_S(i + k) = Am_Cross_S(i + j)
                            Am_Cross_S(i + j) = Cross_Temp
                        End If
                    Next
                Next
            End If
        Next

        Dim PushLine As strLine_Data = Me.MPLine(LNumber).Clone

        Dim SP As Integer = 0
        Dim np As Integer = 0
        '交点の数+1に切断
        ReDim PushLine.PointSTC(inp + 2)
        For i As Integer = 0 To CP
            Dim esp As Integer
            If i <> CP Then
                esp = Am_Cross_S(i).BeforPoint
            Else
                esp = inp - 1
            End If
            For j As Integer = SP To esp
                PushLine.PointSTC(np) = PushMPPoint2(j)
                np += 1
            Next
            If i <> CP Then
                PushLine.PointSTC(np) = Am_Cross_S(i).Point
                np += 1
            End If
            PushLine.NumOfPoint = np
            ReDim Preserve PushLine.PointSTC(np - 1)
            If i = 0 Then
                '最初のパーツは元のラインに
                Save_Line(PushLine, False, False, True)
            Else
                '二番目以降は新しいラインに
                PushLine.Number = -1
                Save_Line(PushLine, False, False, True)
            End If
            If i <> CP Then
                np = 0
                SP = Am_Cross_S(i).BeforPoint + 1
                ReDim PushLine.PointSTC(inp + 2)
                If Am_Cross_S(i).Point.Equals(PushMPPoint2(SP)) = False Then
                    PushLine.PointSTC(np) = Am_Cross_S(i).Point
                    np += 1
                End If
            End If
        Next

    End Sub

    ''' <summary>
    ''' ライン中の同一座標の連続を削除
    ''' </summary>
    ''' <param name="Linenum">ライン番号</param>
    ''' <remarks></remarks>
    Private Sub DeleteSamePoints_inLine(ByVal Linenum As Integer)

        With Me.MPLine(Linenum)
            If .NumOfPoint > 0 Then
                Dim ReMovePoint(.NumOfPoint - 1) As PointF
                ReMovePoint(0) = .PointSTC(0)
                Dim k As Integer = 1
                For j As Integer = 1 To .NumOfPoint - 1
                    If .PointSTC(j - 1).Equals(.PointSTC(j)) <> True Then
                        ReMovePoint(k) = .PointSTC(j)
                        k += 1
                    End If
                Next
                If .NumOfPoint <> k Then
                    ReDim Preserve ReMovePoint(k - 1)
                    .PointSTC = ReMovePoint.Clone
                    .NumOfPoint = k
                End If
            End If
        End With
    End Sub
    ''' <summary>
    ''' 指定された線の共通部分を抽出して、位相構造化する（全ライン）。変更があった場合trueを返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function TopologyStructure_SameLine() As Boolean
        Dim LList As New List(Of Integer)
        For i As Integer = 0 To Map.ALIN - 1
            LList.Add(i)
        Next
        Return TopologyStructure_SameLine(LList)
    End Function

    ''' <summary>
    ''' 指定された線の共通部分を抽出して、位相構造化する。変更があった場合trueを返す
    ''' </summary>
    ''' <param name="TopologyLineList">ライン番号のlist</param>
    ''' <remarks></remarks>
    Public Overloads Function TopologyStructure_SameLine(ByVal TopologyLineList As List(Of Integer)) As Boolean

        Dim Result As Boolean = False
        TopologyLineList.Sort()

        ' Screen.MousePointer = 11
        For Each i As Integer In TopologyLineList
            DeleteSamePoints_inLine(i)
        Next

        Dim icount = 0
        '        ProgressLabel.Visible = True
        Do
            '            ProgressLabel.Start(Map.ALIN, "位相構造化処理中")
            '           ProgressLabel.SetValue i

            Dim i As Integer = TopologyLineList.Item(icount)
            Dim jcount As Integer = icount + 1
            Do While jcount < TopologyLineList.Count
                Dim j As Integer = TopologyLineList.Item(jcount)
                Dim f As Boolean
                Do
                    Dim ODALIN1 As Integer = Map.ALIN
                    f = TopologyStructure_Two_SameLine(i, j)
                    If f = True Then
                        If ODALIN1 > Map.ALIN Then
                            '二つのラインが全く同じで、片方が削除された場合
                            TopologyLineList.RemoveAt(jcount)
                            For k As Integer = 0 To TopologyLineList.Count - 1
                                If TopologyLineList.Item(k) > j Then
                                    TopologyLineList.Item(k) -= 1
                                End If
                            Next
                            Exit Do
                        ElseIf ODALIN1 < Map.ALIN Then
                            'ラインが増えた場合
                            For k As Integer = ODALIN1 To Map.ALIN - 1
                                TopologyLineList.Add(k)
                            Next
                        Else
                            f = False
                        End If
                        Result = True
                    End If
                Loop While f = True
                jcount += 1
            Loop
            icount += 1
        Loop While icount < TopologyLineList.Count
        Return Result
        'ProgressLabel.Visible = False

        'Screen.MousePointer = 0

    End Function
    ''' <summary>
    ''' '二つの線ラインの共通部分を抽出して、位相構造化する。共通部分があればtrueを返す
    ''' </summary>
    ''' <param name="LCode1">ライン番号１</param>
    ''' <param name="LCode2">ライン番号２</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TopologyStructure_Two_SameLine(ByVal LCode1 As Integer, ByVal LCode2 As Integer) As Boolean


        If spatial.Compare_Two_Rectangle_Position(MPLine(LCode1).Circumscribed_Rectangle, MPLine(LCode2).Circumscribed_Rectangle, 0.0001) = cstRectangle_Cross.cstOuter Then
            'ラインが重ならない場合
            Return False
            Exit Function
        End If

        '時間設定が同じかチェック
        If MPLine(LCode1).NumOfTime <> MPLine(LCode2).NumOfTime Then
            Return False

        Else
            For i As Integer = 0 To MPLine(LCode1).NumOfTime - 1
                If MPLine(LCode1).LineTimeSTC(i).Equals(MPLine(LCode2).LineTimeSTC(i)) = False Then
                    '時間設定・線種が異なる場合
                    Return False
                End If
            Next
        End If


        If Check_Points_Of_Two_Lines(LCode1, LCode2) = True Then
            '全く同じラインだった場合
            For i As Integer = 0 To Map.Kend - 1
                With Me.MPObj(i)
                    If Me.ObjectKind(.Kind).ObjectType = enmObjectGoupType_Data.NormalObject Then
                        For j As Integer = 0 To .NumOfLine - 1
                            With .LineCodeSTC(j)
                                If .LineCode = LCode2 Then
                                    .LineCode = LCode1
                                End If
                            End With
                        Next
                    End If
                End With
            Next
            Erase_Line(LCode2, False)
            Return True
            Exit Function
        End If

        Dim TwoRect As RectangleF = RectangleF.Union(MPLine(LCode1).Circumscribed_Rectangle, MPLine(LCode2).Circumscribed_Rectangle)

        Dim PNum1 As Integer, PNum2 As Integer
        Dim XYstac1() As PointF
        Dim XYstac2() As PointF
        With MPLine(LCode1)
            PNum1 = .NumOfPoint
            XYstac1 = .PointSTC
        End With
        With MPLine(LCode2)
            PNum2 = .NumOfPoint
            XYstac2 = .PointSTC
        End With

        '    最初に座標が一致するポイントを取得
        Dim PointIndex As New clsSpatialIndexSearch, PointTag As Long, DumV As Long
        With TwoRect
            PointIndex.Init(SpatialPointType.SinglePoint, False, .Left, .Top, .Right, .Bottom)
        End With
        PointIndex.AddSinglePoint_Allay(PNum2, XYstac2, -1)
        PointIndex.AddEnd()

        Dim f As Boolean = False
        For i As Integer = 0 To PNum1 - 1
            Dim j As Integer = PointIndex.GetSamePointNumber(XYstac1(i).X, XYstac1(i).Y, PointTag, DumV)
            If j <> -1 Then
                f = TopologyStructure_Two_SameLine_Check(LCode1, LCode2, PNum1, PNum2, i, j, XYstac1, XYstac2)
                If f = True Then
                    Exit For
                End If
            End If
        Next
        Return f

    End Function
    Private Function TopologyStructure_Two_SameLine_Check(ByVal LCode1 As Integer, ByVal LCode2 As Integer,
                                                          ByVal PNum1 As Integer, ByVal PNum2 As Integer,
                                                          ByVal S1 As Integer, ByVal s2 As Integer,
                                                          ByRef XYstac1() As PointF, ByRef XYstac2() As PointF) As Boolean

        Dim NewPnum1a As Integer, NewPnum2a As Integer
        Dim NewPnum1b As Integer, NewPnum2b As Integer
        Dim NewXYstac1a() As PointF
        Dim NewXYstac1b() As PointF
        Dim NewXYstac2a() As PointF
        Dim NewXYstac2b() As PointF
        Dim JointPnum As Long
        Dim NewXYstacJoint() As PointF
        Dim nRev1 As Integer
        Dim f As Boolean
        Dim ip As Integer, jp As Integer

        Dim Start1 As Integer, Start2 As Integer

        '同一方向で、同じ座標が続くか調べる
        Dim naH1 As Integer, naH2 As Integer
        naH1 = TopologyStructure_Two_SameLine_sub(S1, s2, 1, 1, PNum1, PNum2, XYstac1, XYstac2)
        If naH1 = 1 Then
            '同一方向で続いていない場合、線2を逆方向にたどる
            naH1 = TopologyStructure_Two_SameLine_sub(S1, s2, 1, -1, PNum1, PNum2, XYstac1, XYstac2)
            naH2 = -naH1
        Else
            naH2 = naH1
        End If


        Dim Loop1F As Boolean = XYstac1(0).Equals(XYstac1(PNum1 - 1))
        If S1 = 0 And Loop1F = True Then
            Dim j As Integer
            '線1がループで､始点が一致箇所の場合
            If naH1 = 1 Then
                '始点からはたどれない場合は終点から逆方向へ
                nRev1 = -TopologyStructure_Two_SameLine_sub(PNum1 - 1, s2, -1, 1, PNum1, PNum2, XYstac1, XYstac2)
                If nRev1 = -1 Then
                    TopologyStructure_Two_SameLine_Check = False
                    Exit Function
                End If

                naH2 = -nRev1
                If nRev1 = -1 Then
                    '同一方向で続いていない場合、線2を逆方向にたどる
                    nRev1 = -TopologyStructure_Two_SameLine_sub(PNum1 - 1, s2, -1, -1, PNum1, PNum2, XYstac1, XYstac2)
                    naH2 = nRev1
                End If
                JointPnum = Math.Abs(nRev1)
                j = PNum1 - JointPnum
                If PNum1 = Math.Abs(nRev1) Then
                    '１周分続く場合
                    naH1 = PNum1
                Else
                    TopologyStructure_Two_SameLine_Cutsub(PNum1 - 1, nRev1, PNum1, NewPnum1a, NewPnum1b, XYstac1, NewXYstac1a, NewXYstac1b)
                End If
                TopologyStructure_Two_SameLine_Cutsub(s2, naH2, PNum2, NewPnum2a, NewPnum2b, XYstac2, NewXYstac2a, NewXYstac2b)
            Else
                If PNum1 = naH1 Then
                    '１周分続く場合
                    JointPnum = naH1
                    TopologyStructure_Two_SameLine_Cutsub(s2, naH2, PNum2, NewPnum2a, NewPnum2b, XYstac2, NewXYstac2a, NewXYstac2b)
                Else
                    '始点からも、終点からもたどれる場合
                    If naH2 < 0 Then
                        jp = 1
                    Else
                        jp = -1
                    End If
                    nRev1 = TopologyStructure_Two_SameLine_sub(PNum1 - 1, s2, -1, jp, PNum1, PNum2, XYstac1, XYstac2)
                    Start1 = naH1 - 1

                    Dim Len1 As Integer = naH1 + nRev1 - 1
                    TopologyStructure_Two_SameLine_Cutsub(Start1, -Len1, PNum1, NewPnum1a, NewPnum1b, XYstac1, NewXYstac1a, NewXYstac1b)
                    Start2 = s2 + naH2 + 1
                    Dim Len2 As Integer = Len1
                    If naH2 > 0 Then
                        Len2 = -Len2
                    End If
                    TopologyStructure_Two_SameLine_Cutsub(Start2, Len2, PNum2, NewPnum2a, NewPnum2b, XYstac2, NewXYstac2a, NewXYstac2b)
                    JointPnum = naH1 + nRev1 - 1
                    j = PNum1 - nRev1
                End If
            End If

            ReDim NewXYstacJoint(JointPnum - 1)
            For i As Integer = 0 To JointPnum - 1
                NewXYstacJoint(i) = XYstac1(j)
                j += 1
                If j >= PNum1 Then
                    j = 1
                End If
            Next

        Else
            If naH1 = 1 Then
                Return False
                Exit Function
            End If
            JointPnum = naH1
            ReDim NewXYstacJoint(JointPnum - 1)
            Dim j As Integer = S1
            For i As Integer = 0 To JointPnum - 1
                NewXYstacJoint(i) = XYstac1(j)
                j += 1
                If j > PNum1 Then
                    j = 1
                End If
            Next
            TopologyStructure_Two_SameLine_Cutsub(S1, naH1, PNum1, NewPnum1a, NewPnum1b, XYstac1, NewXYstac1a, NewXYstac1b)
            TopologyStructure_Two_SameLine_Cutsub(s2, naH2, PNum2, NewPnum2a, NewPnum2b, XYstac2, NewXYstac2a, NewXYstac2b)
        End If

        'ラインを保存
        Dim PushLine As strLine_Data
        If Math.Abs(naH1) <> PNum1 And NewPnum1a <> 1 Then 'NewPnum1a<>1は、特殊なパターンでラインの点が1つになってしまう場合があるため
            PushLine = MPLine(LCode1).Clone
            PushLine.NumOfPoint = NewPnum1a
            PushLine.PointSTC = NewXYstac1a.Clone
            Save_Line(PushLine, False, False, True)
        End If

        If Math.Abs(naH2) <> PNum2 And NewPnum2a <> 1 Then 'NewPnum1a<>2は、特殊なパターンでラインの点が1つになってしまう場合があるため
            PushLine = MPLine(LCode2).Clone
            PushLine.NumOfPoint = NewPnum2a
            PushLine.PointSTC = NewXYstac2a.Clone
            Save_Line(PushLine, False, False, True)
        End If


        If JointPnum <> PNum1 And JointPnum <> PNum2 Then
            PushLine = MPLine(LCode1).Clone
            PushLine.Number = -1
            PushLine.NumOfPoint = JointPnum
            PushLine.PointSTC = NewXYstacJoint.Clone
            Save_Line(PushLine, False, False, True)
            Topology_Line_Object_Shori(LCode1, Map.ALIN - 1)
            Topology_Line_Object_Shori(LCode2, Map.ALIN - 1)
        Else
            If JointPnum = PNum1 Then
                Topology_Line_Object_Shori(LCode2, LCode1)
            ElseIf JointPnum = PNum2 Then
                Topology_Line_Object_Shori(LCode1, LCode2)
            End If
        End If

        If NewPnum1b > 0 Then
            PushLine = MPLine(LCode1).Clone
            PushLine.NumOfPoint = NewPnum1b
            PushLine.Number = -1
            PushLine.PointSTC = NewXYstac1b.Clone
            Save_Line(PushLine, False, False, True)
            Topology_Line_Object_Shori(LCode1, Map.ALIN - 1)
        End If

        If NewPnum2b > 0 Then
            PushLine = MPLine(LCode2).Clone
            PushLine.NumOfPoint = NewPnum2b
            PushLine.Number = -1
            PushLine.PointSTC = NewXYstac2b.Clone
            Save_Line(PushLine, False, False, True)
            Topology_Line_Object_Shori(LCode2, Map.ALIN - 1)
        End If
        Return True
    End Function

    Private Sub TopologyStructure_Two_SameLine_Cutsub(ByVal Start_JointPoint As Integer, ByVal JointNum As Integer, _
                                    ByVal OldPNum As Integer, ByRef NewPnumA As Integer, ByRef NewPnumB As Integer, _
                                    ByRef OldXY() As PointF, ByRef NewXYA() As PointF, ByRef NewXYB() As PointF)
        '一致する箇所でラインを分断する

        Dim LoopF As Boolean = OldXY(0).Equals(OldXY(OldPNum - 1))

        NewPnumB = -1
        If LoopF = True Then
            '線がループの場合
            Dim Start As Integer
            NewPnumA = OldPNum - Math.Abs(JointNum) + 1
            ReDim NewXYA(NewPnumA - 1)
            If OldPNum < JointNum + Start_JointPoint Then
                '共有部分が始点終点を挟む場合１
                Start = JointNum - (OldPNum - Start_JointPoint)
                For i As Integer = Start To Start_JointPoint
                    NewXYA(i - Start) = OldXY(i)
                Next
            ElseIf JointNum + Start_JointPoint < 0 Then
                '共有部分が始点終点を挟む場合２
                For i As Integer = Start_JointPoint To OldPNum + (JointNum + Start_JointPoint)
                    NewXYA(i - Start_JointPoint) = OldXY(i)
                Next
            ElseIf Start_JointPoint < 0 And JointNum + Start_JointPoint > 0 Then
                '共有部分が始点終点を挟む場合3
                Dim j As Integer = 0
                For i As Integer = JointNum + Start_JointPoint - 1 To OldPNum - 1 + Start_JointPoint
                    NewXYA(j) = OldXY(i)
                    j += 1
                Next
            Else
                '共有部分が始点終点を挟まない場合
                If JointNum > 0 Then
                    '順方向
                    Dim j As Integer = 0
                    For i As Integer = Start_JointPoint + JointNum - 1 To OldPNum - 2
                        NewXYA(j) = OldXY(i)
                        j += 1
                    Next
                    For i As Integer = 0 To Start_JointPoint
                        NewXYA(j) = OldXY(i)
                        j += 1
                    Next
                Else
                    '逆方向
                    Dim j As Integer = 0
                    For i As Integer = Start_JointPoint To OldPNum - 2
                        NewXYA(j) = OldXY(i)
                        j += 1
                    Next
                    For i As Integer = 0 To Start_JointPoint + JointNum + 1
                        NewXYA(j) = OldXY(i)
                        j += 1
                    Next
                End If
            End If
        Else
            '線がループでない場合
            Dim End2 As Integer
            Dim Start2 As Integer
            If JointNum < 0 Then
                Start2 = Start_JointPoint + JointNum + 1
                End2 = Start_JointPoint
            Else
                Start2 = Start_JointPoint
                End2 = Start_JointPoint + JointNum - 1
            End If
            If Start2 = 0 Or End2 = OldPNum - 1 Then
                If OldPNum = JointNum Then
                    '全体が共有されている場合
                    NewPnumA = OldPNum
                    NewXYA = OldXY.Clone
                Else
                    '始点又は終点まで共有されている場合
                    NewPnumA = OldPNum - Math.Abs(JointNum) + 1
                    ReDim NewXYA(NewPnumA - 1)
                    Dim j As Integer = 0
                    If Start2 <> 0 Then
                        For i As Integer = 0 To Start2
                            NewXYA(j) = OldXY(i)
                            j += 1
                        Next
                    End If
                    If End2 <> OldPNum - 1 Then
                        For i As Integer = End2 To OldPNum - 1
                            NewXYA(j) = OldXY(i)
                            j += 1
                        Next
                    End If
                End If
            Else
                '始点終点が共有されていない場合は線を１本増やす
                NewPnumA = Start2 + 1
                ReDim NewXYA(NewPnumA - 1)
                For i As Integer = 0 To Start2
                    NewXYA(i) = OldXY(i)
                Next

                NewPnumB = OldPNum - End2
                ReDim NewXYB(NewPnumB - 1)
                For i As Integer = End2 To OldPNum - 1
                    NewXYB(i - End2) = OldXY(i)
                Next

            End If
        End If



    End Sub
    Private Function TopologyStructure_Two_SameLine_sub(ByVal S1 As Integer, s2 As Long,
                                                        ByVal ip As Integer, ByVal jp As Integer,
                                                       ByVal PNum1 As Integer, ByVal PNum2 As Integer,
                                                       ByRef XYstac1() As PointF, ByRef XYstac2() As PointF) As Integer


        '一致するポイントを追跡する
        Dim i As Integer = S1
        Dim j As Integer = s2


        Dim Loop1F As Boolean = XYstac1(0).Equals(XYstac1(PNum1 - 1))
        Dim Loop2F As Boolean = XYstac2(0).Equals(XYstac2(PNum2 - 1))

        Dim n As Integer = 0
        Do While XYstac1(i).Equals(XYstac2(j)) = True
            i += ip
            j += jp
            n += 1
            If i >= PNum1 Then
                If Loop1F = True Then
                    i = 1
                Else
                    Exit Do
                End If
            End If
            If j >= PNum2 Then
                If Loop2F = True Then
                    j = 1
                    jp = 1
                Else
                    Exit Do
                End If
            End If
            If i < 0 Then
                If Loop1F = True Then
                    i = PNum1 - 2
                Else
                    Exit Do
                End If
            End If
            If j < 0 Then
                If Loop2F = True Then
                    j = PNum2 - 2
                Else
                    Exit Do
                End If
            End If
        Loop
        Return n
    End Function
    ''' <summary>
    ''' オブジェクトグループの追加
    ''' </summary>
    ''' <param name="Name">オブジェクトグループ名</param>
    ''' <param name="Shape">オブジェクトグループ形状</param>
    ''' <param name="Mesh">メッシュの場合のサイズ</param>
    ''' <param name="type">通常／集成</param>
    ''' <remarks></remarks>
    Public Sub Add_OneObjectGroup_Parameter(ByVal Name As String, ByVal Shape As enmShape,
                                        ByVal Mesh As enmMesh_Number, ByVal type As enmObjectGoupType_Data)
        Dim Okind As strObjectGroup_Data = Get_OneObjectGroup_Parameter(Name, Shape, Map.OBKNum, Map.LpNum, Mesh, type)
        ReDim Preserve ObjectKind(Me.Map.OBKNum)
        ObjectKind(Me.Map.OBKNum) = Okind
        ReDim Preserve ObjectKind(Map.OBKNum).UseLineType(Math.Max(Map.LpNum - 1, 0))
        For i As Integer = 0 To Me.Map.OBKNum - 1
            If ObjectKind(i).ObjectType = enmObjectGoupType_Data.AggregationObject Then
                ReDim Preserve ObjectKind(i).UseObjectGroup(Map.OBKNum)
            End If
        Next
        Map.OBKNum += 1
    End Sub
    Public Sub Add_OneObjectGroup_Parameter(ByVal NewObGroup As strObjectGroup_Data)

        Add_OneObjectGroup_Parameter(NewObGroup.Name, NewObGroup.Shape, NewObGroup.Mesh, NewObGroup.ObjectType)

    End Sub
    ''' <summary>
    ''' 新規オブジェクトグループパラメータの取得
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="Shape"></param>
    ''' <param name="Mesh"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_OneObjectGroup_Parameter(ByVal Name As String, ByVal Shape As enmShape,
                                                 ByVal ObkNum As Integer, ByVal LpNum As Integer,
                                            ByVal Mesh As enmMesh_Number, ByVal type As enmObjectGoupType_Data) As strObjectGroup_Data
        Dim Okind As strObjectGroup_Data
        With Okind
            .Color = Set_First_ObjectKind_Color_Solo(ObkNum)
            .Mesh = Mesh
            .Name = Name
            .Shape = Shape
            .ObjectType = type
            .DefTimeAttDataNum = 0
            .ObjectNameNum = 1
            ReDim .ObjectNameList(0)
            .ObjectNameList(0) = "オブジェクト名1"
            If type = enmObjectGoupType_Data.AggregationObject Then
                ReDim Preserve .UseLineType(Math.Max(ObkNum, 0))
            Else
                ReDim Preserve .UseLineType(Math.Max(LpNum - 1, 0))
            End If
        End With
        Return Okind
    End Function
    ''' <summary>
    ''' 選択したオブジェクトグループ同士が同じかどうかを調べる
    ''' </summary>
    ''' <param name="ObjSel">選択したオブジェクトグループにtrue</param>
    ''' <param name="Emes">エラーメッセージ（戻り値）</param>
    ''' <param name="check_objType">オブジェクトのタイプをチェックする場合true</param>
    ''' <param name="check_objNameListNum">オブジェクト名リストの数をチェックする場合true</param>
    ''' <returns>同じならtrue</returns>
    ''' <remarks></remarks>
    Public Function Check_Selected_ObjectGroup_Same(ByVal ObjSel() As Boolean, ByRef Emes As String, ByVal check_objType As Boolean, ByVal check_objNameListNum As Boolean) As Boolean

        Dim f As Boolean = True
        Dim SeFlOb As Integer = -1
        For i As Integer = 0 To Me.Map.OBKNum - 1
            If ObjSel(i) = True Then
                If SeFlOb = -1 Then
                    SeFlOb = i
                Else
                    If Me.ObjectKind(i).Shape <> Me.ObjectKind(SeFlOb).Shape Then
                        Emes = "異なる形状のオブジェクトグループが選択されています。"
                        f = False
                        Exit For
                    End If
                    If check_objType = True Then
                        If Me.ObjectKind(i).ObjectType <> Me.ObjectKind(SeFlOb).ObjectType Then
                            Emes = "異なるオブジェクトのタイプのオブジェクトグループが選択されています。"
                            f = False
                            Exit For
                        End If
                    End If
                    If check_objNameListNum = True Then
                        If Me.ObjectKind(i).ObjectNameNum <> Me.ObjectKind(SeFlOb).ObjectNameNum Then
                            Emes = "オブジェクト名リスト数が異なるオブジェクトグループが選択されています。"
                            f = False
                            Exit For
                        Else
                            For j As Integer = 0 To Me.ObjectKind(i).ObjectNameNum - 1
                                If Me.ObjectKind(i).ObjectNameList(j) <> Me.ObjectKind(SeFlOb).ObjectNameList(j) Then
                                    Emes = "オブジェクト名リストの名称が異なるオブジェクトグループが選択されています。"
                                    f = False
                                    i = Me.Map.OBKNum - 1
                                End If
                            Next
                        End If
                    End If
                    If Me.ObjectKind(i).DefTimeAttDataNum <> Me.ObjectKind(SeFlOb).DefTimeAttDataNum Then
                        Emes = "初期属性数が異なるオブジェクトグループが選択されています。"
                        f = False
                        Exit For
                    Else
                        For j As Integer = 0 To Me.ObjectKind(i).DefTimeAttDataNum - 1
                            If Me.ObjectKind(i).DefTimeAttSTC(j).attData.Title <> Me.ObjectKind(SeFlOb).DefTimeAttSTC(j).attData.Title Or _
                               Me.ObjectKind(i).DefTimeAttSTC(j).attData.Unit <> Me.ObjectKind(SeFlOb).DefTimeAttSTC(j).attData.Unit Then
                                Emes = "初期属性のタイトルまたは単位が異なるオブジェクトグループが選択されています。"
                                f = False
                                i = Me.Map.OBKNum - 1
                                Exit For
                            End If
                        Next
                    End If
                End If
            End If
        Next
        Return f
    End Function
    ''' <summary>
    ''' 保存前のエラーチェック trueでOK
    ''' </summary>
    ''' <param name="Emes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ErrorCheck_Mapfile(ByRef Emes As String) As Boolean


        For i As Integer = 0 To Map.Kend - 1
            With MPObj(i)
                For j As Integer = 0 To .NumOfNameTime - 1
                    With .NameTimeSTC(j)
                        For k As Integer = 0 To .NamesList.Length - 1
                            .NamesList(k) = clsGeneric.Remove_SpaceTabCRLF(.NamesList(k))
                        Next
                    End With
                Next
            End With
        Next

        Erase_Irregular_Line()
        Check_ALl_Line_Connect()
        Dim ef As Boolean = False
        'If Map.Kend = 0 Then
        '    MsgBox("オブジェクトが作成してありません。", MsgBoxStyle.Exclamation)
        '    Return False
        'End If

        '10ではスケール設定は使わない
        'If Map.SCL <= 0 And Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
        '    If MsgBox("スケールが設定してありません。このままでは距離や面積の計測はできません。" & vbCrLf & "設定しないまま保存しますか？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Map.SCL = 1
        '        Map.SCL_U = enmScaleUnit.kilometer
        '    Else
        '        MsgBox("＜設定＞＜スケール設定＞でスケールを指定して下さい。", vbExclamation)
        '        Return False
        '    End If
        'End If



        ef = False
        Emes = "以下のオブジェクトの形状は、オブジェクトグループの設定と異なります。" & vbCrLf & vbCrLf

        For i As Integer = 0 To Map.Kend - 1
            With MPObj(i)
                .Shape = Check_Obj_Shape_AllTime(MPObj(i))
                If .Shape <> ObjectKind(.Kind).Shape And ObjectKind(.Kind).Shape <> -1 Then
                    Emes += "オブジェクト「" & .NameTimeSTC(.NumOfNameTime - 1).connectNames & "」" & vbCrLf
                    ef = True
                End If
            End With
        Next

        Call Check_All_Obj_MaxMin()
        If ef = True Then
            Dim tx As String = "オブジェクトグループの設定と異なる形状のオブジェクトが存在します。" + vbCrLf + "保存作業を続けますか？"
            If MsgBox(tx, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return False
            End If
        End If

        ef = False
        Emes = "同一オブジェクト名が存在します。オブジェクト編集でオブジェクト名が重ならないように修正してください。" & vbCrLf & vbCrLf

        Dim ObjNameSearch As New clsObjectNameSearch(Me, False)
        With ObjNameSearch
            For i As Integer = 0 To .NumofData - 2
                If .DataPositionValue(i) = .DataPositionValue(i + 1) Then
                    Dim j As Integer = i
                    Do While .DataPositionValue(j) = .DataPositionValue(j + 1)
                        j += 1
                        If j = .NumofData - 1 Then
                            Exit Do
                        End If
                    Loop
                    For k As Integer = i To j - 1
                        Dim k3 As Integer = .DataPosition(k)
                        Dim Stack3 As clsObjectNameSearch.ObjNameAndTime_Info = .Object_Name_Stac(k3)
                        For k2 As Integer = k + 1 To j
                            Dim k4 As Integer = .DataPosition(k2)
                            Dim Stack4 As clsObjectNameSearch.ObjNameAndTime_Info = .Object_Name_Stac(k4)
                            If Stack3.ObjCode <> Stack4.ObjCode Then
                                If clsTime.Check_Duration_OK(Stack3.SETime, Stack4.SETime) = True Then
                                    Emes += "「" & .DataPositionValue(i) & "」" & vbCrLf
                                    k2 = j
                                    k = j - 1
                                    i = j
                                    ef = True
                                End If
                            End If
                        Next
                    Next
                End If
            Next
        End With

        If ef = True Then
            Dim tx As String = "同一オブジェクト名が存在します。 保存作業を続けますか？"
            If MsgBox(tx, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return False
            End If
        End If

        ef = False
        Emes = ""
        Dim LKF As Boolean = True
        Dim LKF2 As Boolean = True
        Dim elc As String = "線種に問題のあるライン番号" & vbCrLf
        Dim elco As String = "使用オブジェクトグループに問題のある集成オブジェクト" & vbCrLf
        For ii As Integer = 0 To Map.Kend - 1
            With MPObj(ii)
                Dim OName As String = .NameTimeSTC(.NumOfNameTime - 1).connectNames
                If ObjectKind(.Kind).ObjectType = enmObjectGoupType_Data.NormalObject Then
                    For i As Integer = 0 To .NumOfLine - 1
                        With .LineCodeSTC(i)
                            Dim lc As Integer = .LineCode
                            If MPLine(lc).NumOfTime = 1 Then
                                If ObjectKind(MPObj(ii).Kind).UseLineType(MPLine(lc).LineTimeSTC(0).Kind) = False Then
                                    elc += lc & "（" & OName & "）" & vbCrLf
                                    LKF = False
                                End If
                            Else
                                Dim f As Boolean = False
                                If .NumOfTime = 0 Then
                                    For k As Integer = 0 To MPLine(lc).NumOfTime - 1
                                        With MPLine(lc).LineTimeSTC(k)
                                            If ObjectKind(MPObj(ii).Kind).UseLineType(.Kind) = True Then
                                                f = True
                                                Exit For
                                            End If
                                        End With
                                    Next
                                Else
                                    For j As Integer = 0 To .NumOfTime - 1
                                        Dim set1 As Start_End_Time_data = .Times(j)
                                        For k As Integer = 0 To MPLine(lc).NumOfTime - 1
                                            With MPLine(lc).LineTimeSTC(k)
                                                If ObjectKind(MPObj(ii).Kind).UseLineType(.Kind) = True Then
                                                    If clsTime.Check_Duration_OK(set1, .SETime) = True Then
                                                        f = True
                                                        Exit For
                                                    End If
                                                End If
                                            End With
                                        Next
                                    Next
                                End If
                                If f = False Then
                                    LKF = False
                                    elc += lc & "（" & OName$ & "）" & vbCrLf
                                End If
                            End If
                        End With
                    Next
                Else
                    For i As Integer = 0 To .NumOfLine - 1
                        With MPObj(.LineCodeSTC(i).LineCode)
                            If ObjectKind(MPObj(ii).Kind).UseObjectGroup(.Kind) = False Then
                                elco += .NameTimeSTC(.NumOfNameTime - 1).connectNames & "（" & OName$ & "）" & vbCrLf
                                LKF2 = False
                            End If
                        End With
                    Next
                End If
            End With
        Next
        If LKF = False Then
            Dim tx As String = "使用できない線種を使用しているオブジェクトがあります。" + vbCrLf + "保存作業を続けますか？"
            If MsgBox(tx, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return False
            End If
        End If

        If LKF2 = False Then
            Dim tx As String = "使用できないオブジェクトを使用している集成オブジェクトがあります。" + vbCrLf + "保存作業を続けますか？"
            If MsgBox(tx, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return False
            End If
        End If

        Return True
    End Function

    ''' <summary>
    ''' 地図データで時間属性を使用しているかどうかをチェック
    ''' </summary>
    ''' <param name="MLine">ラインで使用（オプション戻り値）</param>
    ''' <param name="ObjName">オブジェクト名で使用（オプション戻り値）</param>
    ''' <param name="ObjLine">オブジェクトの使用するラインで使用（オプション戻り値）</param>
    ''' <param name="defAtt_f">初期属性で使用（オプション戻り値）</param>
    ''' <returns>使用していたらtrue</returns>
    ''' <remarks></remarks>
    Public Function Check_Time_Mode_of_Map(Optional ByRef MLine As Boolean = False,
                                                 Optional ByRef ObjName As Boolean = False,
                                                 Optional ByRef ObjLine As Boolean = False,
                                                 Optional ByRef defAtt_f As Boolean = False) As Boolean

        MLine = False
        ObjName = False
        ObjLine = False
        defAtt_f = False
        Dim f As Boolean = False

        For i As Integer = 0 To Map.ALIN - 1
            For j As Integer = 0 To MPLine(i).NumOfTime - 1
                With MPLine(i).LineTimeSTC(j).SETime
                    If .EndTime.nullFlag = False Or .StartTime.nullFlag = False Then
                        f = True
                        MLine = True
                        i = Map.ALIN
                        Exit For
                    End If
                End With
            Next
        Next

        For i As Integer = 0 To Map.Kend - 1
            For j As Integer = 0 To MPObj(i).NumOfNameTime - 1
                With MPObj(i).NameTimeSTC(j).SETime
                    If .EndTime.nullFlag = False Or .StartTime.nullFlag = False Then
                        f = True
                        ObjName = True
                        i = Map.Kend
                        Exit For
                    End If
                End With
            Next
        Next

        For i As Integer = 0 To Map.Kend - 1
            With MPObj(i)
                For j As Integer = 0 To .NumOfLine - 1
                    With .LineCodeSTC(j)
                        If .NumOfTime <> 0 Then
                            f = True
                            ObjLine = True
                            i = Map.Kend
                            Exit For
                        End If
                    End With
                Next
                For j As Integer = 0 To ObjectKind(.Kind).DefTimeAttDataNum - 1
                    If .DefTimeAttValue(j).Data.GetUpperBound(0) >= 1 Then
                        f = True
                        defAtt_f = True
                        i = Map.Kend
                    End If
                Next
            End With
        Next

        For i As Integer = 0 To Me.Map.OBKNum - 1
            With Me.ObjectKind(i)
                For j As Integer = 0 To .DefTimeAttDataNum - 1
                    With .DefTimeAttSTC(j)

                    End With
                Next
            End With
        Next
        Return f
    End Function
    ''' <summary>
    ''' 指定したオブジェクトの使用するラインが、他のオブジェクトでも使用されているかどうかチェック
    ''' </summary>
    ''' <param name="ObjArray">オブジェクトのList</param>
    ''' <returns>使用されていないならtrue</returns>
    ''' <remarks></remarks>
    Public Function Check_ObjectUseLine_UsedOtherObject(ByRef ObjArray As List(Of strObj_Data))
        Dim UseLineCheck(Map.ALIN - 1) As Boolean
        Dim OCode As New List(Of Integer)
        For Each EObj As strObj_Data In ObjArray
            With EObj
                If ObjectKind(.Kind).ObjectType = enmObjectGoupType_Data.NormalObject Then
                    OCode.Add(.Number)
                    For j As Integer = 0 To .NumOfLine - 1
                        UseLineCheck(.LineCodeSTC(j).LineCode) = True
                    Next
                End If
            End With
        Next

        Dim f As Boolean = True
        For i As Integer = 0 To Map.Kend - 1
            With MPObj(i)
                If ObjectKind(.Kind).ObjectType = enmObjectGoupType_Data.NormalObject Then
                    If OCode.IndexOf(i) = -1 Then
                        For j As Integer = 0 To .NumOfLine - 1
                            If UseLineCheck(.LineCodeSTC(j).LineCode) = True Then
                                f = False
                                i = Map.Kend
                                Exit For
                            End If
                        Next
                    End If
                End If
            End With

        Next
        Return f
    End Function
    ''' <summary>
    ''' 全オブジェクトのオブジェクト名clsMapData.Object_Names_Data配列をList(Of Object_Names_Dataに入れて返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_All_ObjectName() As List(Of Object_NameTimeStac_Data())
        Dim OriginObjName As New List(Of Object_NameTimeStac_Data())
        For i As Integer = 0 To Me.Map.Kend - 1
            With Me.MPObj(i)
                Dim OName(.NumOfNameTime - 1) As clsMapData.Object_NameTimeStac_Data
                For j As Integer = 0 To .NumOfNameTime - 1
                    OName(j) = .NameTimeSTC(j).Clone
                Next
                OriginObjName.Add(OName)
            End With
        Next
        Return OriginObjName
    End Function
    ''' <summary>
    ''' 同一オブジェクト名のオブジェクトの結合(全オブジェクト)
    ''' </summary>
    ''' <param name="CombineObjectName">結合したオブジェクト名一覧</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CombineSameNameObjecs(ByRef CombineObjectName As String) As Integer
        Dim obj(Map.Kend - 1) As Boolean
        clsGeneric.FillArray(obj, True)
        Return CombineSameNameObjecs(obj, CombineObjectName)
    End Function
    ''' <summary>
    ''' 同一オブジェクト名のオブジェクトの結合(指定オブジェクト)
    ''' </summary>
    ''' <param name="ObjectEnable">結合対象のオブジェクトはtrue</param>
    ''' <param name="CombineObjectName">結合したオブジェクト名一覧</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CombineSameNameObjecs(ByVal ObjectEnable() As Boolean, ByRef CombineObjectName As String) As Integer

        Dim SameObj() As Integer

        Dim obn As Integer = 0
        Dim Stn As Integer = 0
        CombineObjectName = ""
        ReDim SameObj(10)
        Dim n As Integer
        If Map.Time_Mode = True Then
            '時間設定されているオブジェクトは対象外
            For i As Integer = 0 To Map.Kend - 1
                If Me.MPObj(i).NumOfNameTime > 1 Or Me.MPObj(i).NameTimeSTC(0).SETime.StartTime.nullFlag = False Or
                        Me.MPObj(i).NameTimeSTC(0).SETime.EndTime.nullFlag = False Then
                    ObjectEnable(i) = False
                End If
            Next
        End If

        Do
            If ObjectEnable(obn) = True Then
                Dim NobjList() As String = MPObj(obn).NameTimeSTC(0).NamesList.Clone
                SameObj(0) = obn
                n = 1
                For i As Integer = obn + 1 To Map.Kend - 1
                    If ObjectEnable(i) = True Then
                        With MPObj(i).NameTimeSTC(0)
                            For j As Integer = 0 To .NamesList.Length - 1
                                If .NamesList(j) <> "" Then
                                    If Array.IndexOf(NobjList, .NamesList(j)) <> -1 Then
                                        If ObjectKind(MPObj(obn).Kind).ObjectType = ObjectKind(MPObj(i).Kind).ObjectType Then
                                            If UBound(SameObj) < n Then
                                                ReDim Preserve SameObj(n + 10)
                                            End If
                                            SameObj(n) = i
                                            n += 1
                                        End If
                                    End If
                                End If
                            Next
                        End With
                    End If
                Next
                If n >= 2 Then
                    If Check_ObjectKind_for_Conbine(n, SameObj) = True Then
                        ReDim Preserve SameObj(n - 1)
                        clsGeneric.DeletePartArray(ObjectEnable, SameObj)
                        Dim PushObj As strObj_Data = Combine_Objects(NobjList, n, SameObj, clsTime.GetNullYMD)
                        Erase_MultiObjects(n, SameObj, False)
                        PushObj.Shape = Check_Obj_Shape(PushObj, clsTime.GetNullYMD)
                        Save_Object(PushObj, True)
                        ReDim Preserve ObjectEnable(Map.Kend - 1)
                        ObjectEnable(Map.Kend - 1) = False
                        CombineObjectName += Join(NobjList, "/") + ":" + n.ToString + vbCrLf
                        Stn += 1
                    Else
                        For j As Integer = 0 To n - 1
                            ObjectEnable(SameObj(j)) = False
                        Next
                        CombineObjectName += MPObj(obn).NameTimeSTC(0).connectNames + ":" + "同一オブジェクト名は存在しましたが、オブジェクトグループが異なるため結合できません。" + vbCrLf
                        obn += 1
                    End If
                Else
                    obn += 1
                End If
            Else
                obn += 1
            End If
        Loop Until obn = Map.Kend
        CombineSameNameObjecs = Stn
    End Function
    ''' <summary>
    ''' 線種名のリストを取得して配列で返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_LineKindNameList() As String()
        Dim LKName(Me.Map.LpNum - 1) As String
        For i As Integer = 0 To Me.Map.LpNum - 1
            LKName(i) = Me.LineKind(i).Name
        Next
        Return LKName

    End Function
    ''' <summary>
    ''' オブジェクトグループ名のリストを配列で取得する
    ''' </summary>
    ''' <returns>文字列配列</returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_ObjectGroupNameList() As String()
        Dim ObjG(Me.Map.OBKNum - 1) As String
        For i As Integer = 0 To Me.Map.OBKNum - 1
            ObjG(i) = Me.ObjectKind(i).Name
        Next
        Return ObjG
    End Function
    ''' <summary>
    ''' 指定したタイプのオブジェクトグループ名のリストを取得する
    ''' </summary>
    ''' <param name="GroupType">オブジェクトグループのタイプ</param>
    ''' <returns>文字列配列、存在しない場合はNothing</returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_ObjectGroupNameList(ByVal GroupType As enmObjectGoupType_Data) As String()
        Dim ObjG(Me.Map.OBKNum - 1) As String
        Dim n As Integer = 0
        For i As Integer = 0 To Me.Map.OBKNum - 1
            If Me.ObjectKind(i).ObjectType = GroupType Then
                ObjG(n) = Me.ObjectKind(i).Name
                n += 1
            End If
        Next
        If n = 0 Then
            ObjG = Nothing
        Else
            ReDim Preserve ObjG(n - 1)
        End If
        Return ObjG
    End Function
    ''' <summary>
    ''' 指定したタイプのオブジェクトグループ中のリストの位置がオブジェクトグループ全体の中で何番目か返す。
    ''' </summary>
    ''' <param name="ListIndex">リストの位置</param>
    ''' <param name="GroupType">オブジェクトグループのタイプ</param>
    ''' <returns>位置。存在しない場合は-1</returns>
    ''' <remarks></remarks>
    Public Function Get_ObjectGroupPosition_by_Type(ByVal ListIndex As Integer, ByVal GroupType As enmObjectGoupType_Data) As Integer
        Dim n As Integer = 0
        For i As Integer = 0 To Me.Map.OBKNum - 1
            If Me.ObjectKind(i).ObjectType = GroupType Then
                If n = ListIndex Then
                    Return i
                End If
                n += 1
            End If
        Next
        Return -1
    End Function
    ''' <summary>
    ''' 同じオブジェクトグループ名の番号を返す見つからなかった場合-1
    ''' </summary>
    ''' <param name="Name">チェックするオブジェクトグループ名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_ObjectGroupNumber_By_Name(ByVal Name As String) As Integer
        For i As Integer = 0 To Me.Map.OBKNum - 1
            If Me.ObjectKind(i).Name = Name Then
                Return i
            End If
        Next
        Return -1
    End Function

    ''' <summary>
    ''' 同じオブジェクトグループ名が存在する場合true
    ''' </summary>
    ''' <param name="Name">チェックするオブジェクトグループ名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_ObjectGroupNameExist(ByVal Name As String) As Boolean
        For i As Integer = 0 To Me.Map.OBKNum - 1
            If Me.ObjectKind(i).Name = Name Then
                Return True
            End If
        Next
        Return False
    End Function
    ''' <summary>
    ''' 同じ線種名が存在する場合true
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_LineKindNameExist(ByVal Name As String) As Boolean
        For i As Integer = 0 To Me.Map.LpNum - 1
            If Me.LineKind(i).Name = Name Then
                Return True
            End If
        Next
        Return False
    End Function
    ''' <summary>
    ''' 指定したラインのポイント間の平均距離または中央値を取得
    ''' </summary>
    ''' <param name="LCode">ライン番号のList(Of Integer)</param>
    ''' <param name="Get_v">取得する値:0/平均値　1:中央値を取得</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Interval_of_LinePoint(ByRef LCode As List(Of Integer), ByVal Get_v As Integer) As Single

        Dim Num As Integer = LCode.Count
        Dim max_n As Integer = 0
        For i As Integer = 0 To Num - 1
            max_n += MPLine(LCode.Item(i)).NumOfPoint - 1
        Next
        Dim Interval_D2(max_n - 1) As Single
        'ラインが多い場合はポイント間で間引きながら数える
        Dim stp As Integer = (Num \ 1000) + 1

        Dim n As Integer = 0
        For i As Integer = 0 To Num - 1
            Get_Interval_of_One_LinePoint(LCode.Item(i), n, stp, Interval_D2)
        Next

        Dim inv As Single
        Select Case Get_v
            Case 0
                Dim D As Single = 0
                For i As Integer = 0 To n - 1
                    D += Interval_D2(i)
                Next
                inv = D / 2
            Case 1
                Dim Sdata As New clsSortingSearch
                Sdata.AddRange(n, Interval_D2)
                inv = Sdata.DataPositionValue_Single(n \ 2)
        End Select
        If Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
        Else
            inv = inv / Map.SCL
        End If
        Return inv
    End Function
    ''' <summary>
    ''' 指定ラインのポイント間の距離を求める
    ''' </summary>
    ''' <param name="LCode">ラインコード</param>
    ''' <param name="n"></param>
    ''' <param name="stp"></param>
    ''' <param name="Interval_D2"></param>
    ''' <remarks></remarks>
    Private Sub Get_Interval_of_One_LinePoint(ByVal LCode As Integer, ByRef n As Integer, ByVal stp As Integer, ByRef Interval_D2() As Single)

        With MPLine(LCode)
            If Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                For i As Integer = 0 To .NumOfPoint - 2 Step stp
                    Interval_D2(n) = spatial.Distance_Ido_Kedo_XY(.PointSTC(i).X, .PointSTC(i).Y, .PointSTC(i + 1).X, .PointSTC(i + 1).Y, Me.Map.Zahyo)
                    n += 1
                Next
            Else
                For i As Integer = 0 To .NumOfPoint - 2 Step stp
                    Interval_D2(n) = spatial.get_Distance(.PointSTC(i), .PointSTC(i + 1))
                    n += 1
                Next
            End If
        End With
    End Sub
    ''' <summary>
    ''' 指定したラインコードがループでない場合は－１、ループの場合は面積を返す
    ''' </summary>
    ''' <param name="L_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_LoopLine_Menseki(ByVal L_Code As Integer) As Single

        Dim men As Single

        Dim PN As Integer = MPLine(L_Code).NumOfPoint
        If PN = 0 Then
            Return -1
        End If

        With MPLine(L_Code)
            Dim PE As Integer = .NumOfPoint - 1
            If .PointSTC(PE).X = .PointSTC(0).X And .PointSTC(PE).Y = .PointSTC(0).Y Then
                Dim pxy(PN) As PointF
                For j As Integer = 0 To PN - 1
                    pxy(j) = .PointSTC(j)
                Next
                pxy(PN) = .PointSTC(1)
                men = spatial.Get_Hairetu_Menseki(PN, pxy, Me.Map)
            Else
                men = -1
            End If
        End With
        Return men
    End Function
    ''' <summary>
    ''' 測地系変換、平面直角から緯度経度変換
    ''' </summary>
    ''' <param name="pattern">0:ITRF94toTokyo97(世界測地系から日本測地系)  1:Tokyo97toITRF94(日本測地系から世界測地系)  2:平面直角から緯度経度</param>
    ''' <remarks></remarks>
    Public Sub Conv_Tokyo97_ITRF94(ByVal pattern As Integer)
        With Map
            Select Case pattern
                Case 0
                    If .Zahyo.System = enmZahyo_System_Info.Zahyo_System_tokyo Then
                        Return
                    End If
                Case 1
                    If .Zahyo.System = enmZahyo_System_Info.Zahyo_System_World Then
                        Return
                    End If
                Case 2
                    If .Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                        Return
                    End If
            End Select

        End With

        Dim CenterP() As PointF
        Dim Mpp() As PointF

        Dim Ellip12 As Integer
        Dim Kei As Integer

        If pattern = 2 Then
            Kei = Map.Zahyo.HeimenTyokkaku_KEI_Number
            If Map.Zahyo.System = enmZahyo_System_Info.Zahyo_System_tokyo Then
                Ellip12 = 1
            ElseIf Map.Zahyo.System = enmZahyo_System_Info.Zahyo_System_World Then
                Ellip12 = 2
            End If
        End If

        ReDim Mpp(Map.ALIN * 10 - 1)
        ReDim CenterP(Map.Kend - 1)

        Dim ppn As Integer = 0
        For i As Integer = 0 To Map.ALIN - 1
            With MPLine(i)
                For j As Integer = 0 To .NumOfPoint - 1
                    Dim pxy As PointF = spatial.Get_Reverse_XY(.PointSTC(j), Map.Zahyo)

                    Dim x2 As Double, y2 As Double
                    Select Case pattern
                        Case 0
                            Call ITRF94toTokyo97(pxy.Y, pxy.X, y2, x2)
                        Case 1
                            Call Tokyo97toITRF94(pxy.Y, pxy.X, y2, x2)
                        Case 2
                            Call doCalcXy2bl(Ellip12, Kei, pxy.Y, pxy.X, y2, x2)
                    End Select
                    If UBound(Mpp) < ppn Then
                        ReDim Preserve Mpp(ppn + 500)
                    End If
                    Mpp(ppn).X = CSng(x2)
                    Mpp(ppn).Y = CSng(y2)
                    ppn += 1
                Next
            End With
        Next


        Dim cpn As Integer = 0
        For i As Integer = 0 To Map.Kend - 1
            With MPObj(i)
                For j As Integer = 0 To .NumOfCenterP - 1
                    Dim x2 As Double, y2 As Double
                    Dim pxy As PointF = spatial.Get_Reverse_XY(.CenterPSTC(j).Position, Map.Zahyo)
                    Select Case pattern
                        Case 0
                            Call ITRF94toTokyo97(pxy.Y, pxy.X, y2, x2)
                        Case 1
                            Call Tokyo97toITRF94(pxy.Y, pxy.X, y2, x2)
                        Case 2
                            Call doCalcXy2bl(Ellip12, Kei, pxy.Y, pxy.X, y2, x2)
                    End Select
                    If UBound(CenterP) < cpn Then
                        ReDim Preserve CenterP(cpn + 100)
                    End If
                    CenterP(cpn).X = CSng(x2)
                    CenterP(cpn).Y = CSng(y2)
                    cpn += 1
                Next
            End With
        Next

        Dim XY_Rect As RectangleF
        If Map.ALIN > 0 Then
            XY_Rect = New RectangleF(Mpp(0), New Size(0, 0))
        Else
            XY_Rect = New RectangleF(CenterP(0), New Size(0, 0))
        End If

        For i As Integer = 0 To ppn - 1
            XY_Rect = spatial.Get_Circumscribed_Rectangle(Mpp(i), XY_Rect)
        Next
        For i As Integer = 0 To cpn - 1
            XY_Rect = spatial.Get_Circumscribed_Rectangle(CenterP(i), XY_Rect)
        Next

        With Map
            .SCL_U = enmScaleUnit.kilometer
            .SCL = 1
            Select Case pattern
                Case 0
                    .Zahyo.System = enmZahyo_System_Info.Zahyo_System_tokyo
                Case 1
                    .Zahyo.System = enmZahyo_System_Info.Zahyo_System_World
                Case 2
                    .Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido
                    .Zahyo.Projection = clsSettings.Data.default_Projection
            End Select
            .Zahyo.CenterXY = spatial.Get_CenterPoint_of_Rect(XY_Rect)
        End With
        ppn = 0
        For i As Integer = 0 To Map.ALIN - 1
            With MPLine(i)
                For j As Integer = 0 To .NumOfPoint - 1
                    .PointSTC(j) = spatial.Get_Converted_XY(Mpp(ppn), Map.Zahyo)
                    ppn += 1
                Next
            End With
        Next



        cpn = 0
        For i As Integer = 0 To Map.Kend - 1
            With MPObj(i)
                For j = 0 To .NumOfCenterP - 1
                    .CenterPSTC(j).Position = spatial.Get_Converted_XY(CenterP(cpn), Map.Zahyo)
                    cpn += 1
                Next
            End With
        Next

        Checl_All_Line_Maxmin()

        Check_All_Obj_MaxMin()

        Map.Circumscribed_Rectangle = Get_Mapfile_Rectangle()
        Map.MapCompass.Position = Get_Compass_Position_First_Position()
    End Sub
    ''' <summary>
    ''' 緯度経度の平行移動、緯度が90度を超える場合は変換せずfalseを返す
    ''' </summary>
    ''' <param name="LatPlus"></param>
    ''' <param name="LonPlus"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LatLonMove(ByVal LatPlus As Single, ByVal LonPlus As Single) As Boolean

        Dim prect As RectangleF = spatial.Get_Reverse_Rect(Map.Circumscribed_Rectangle, Map.Zahyo)
        Dim y1 As Single = prect.Top + LatPlus
        Dim y2 As Single = prect.Bottom + LatPlus
        If 90 < Math.Abs(y1) Or 90 < Math.Abs(y2) Then
            Return False
        End If

        Dim OMAP As strMap_data = Map
        With Map.Zahyo.CenterXY
            .X += LonPlus
            .Y += +LatPlus
        End With

        Dim cmpxy As PointF = spatial.Get_Reverse_XY(Map.MapCompass.Position, OMAP.Zahyo)
        cmpxy.X += LonPlus
        cmpxy.Y += LatPlus
        Map.MapCompass.Position = spatial.Get_Converted_XY(cmpxy, Map.Zahyo)


        For i As Integer = 0 To Map.ALIN - 1
            With MPLine(i)
                For j As Integer = 0 To .NumOfPoint - 1
                    Dim pxy As PointF = spatial.Get_Reverse_XY(.PointSTC(j), OMAP.Zahyo)
                    pxy.X += +LonPlus
                    pxy.Y += LatPlus
                    .PointSTC(j) = spatial.Get_Converted_XY(pxy, Map.Zahyo)
                Next
            End With
        Next


        For i As Integer = 0 To Map.Kend - 1
            With MPObj(i)
                For j As Integer = 0 To .NumOfCenterP - 1
                    With .CenterPSTC(j)
                        Dim pxy As PointF = spatial.Get_Reverse_XY(.Position, OMAP.Zahyo)
                        pxy.X += +LonPlus
                        pxy.Y += LatPlus
                        .Position = spatial.Get_Converted_XY(pxy, Map.Zahyo)
                    End With
                Next
            End With
        Next

        Checl_All_Line_Maxmin()

        Check_All_Obj_MaxMin()

        Map.Circumscribed_Rectangle = Get_Mapfile_Rectangle()

        Return True


    End Function
    ''' <summary>
    ''' 投影法変換
    ''' </summary>
    ''' <param name="centerLat">中央経線</param>
    ''' <param name="newProjection">新しい投影法</param>
    ''' <remarks></remarks>
    Public Sub ProjectionConvert(ByVal centerLon As Single, ByVal newProjection As enmProjection_Info)
        Dim OMAP As strMap_data = Map

        If Map.Zahyo.Projection = newProjection And Map.Zahyo.CenterXY.X = centerLon Then
            Return
        End If
        Map.Zahyo.Projection = newProjection
        Map.Zahyo.CenterXY.X = centerLon

        Dim cmpxy As PointF = spatial.Get_Reverse_XY(Map.MapCompass.Position, Map.Zahyo)
        Map.MapCompass.Position = spatial.Get_Converted_XY(cmpxy, Map.Zahyo)

        For i As Integer = 0 To Map.ALIN - 1
            With MPLine(i)
                For j As Integer = 0 To .NumOfPoint - 1
                    Dim pxy As PointF = spatial.Get_Reverse_XY(.PointSTC(j), OMAP.Zahyo)
                    .PointSTC(j) = spatial.Get_Converted_XY(pxy, Map.Zahyo)
                Next
            End With
        Next


        For i As Integer = 0 To Map.Kend - 1
            With MPObj(i)
                For j As Integer = 0 To .NumOfCenterP - 1
                    Dim pxy As PointF = spatial.Get_Reverse_XY(.CenterPSTC(j).Position, OMAP.Zahyo)
                    .CenterPSTC(j).Position = spatial.Get_Converted_XY(pxy, Map.Zahyo)
                Next
            End With
        Next

        Checl_All_Line_Maxmin()

        Check_All_Obj_MaxMin()

        Map.Circumscribed_Rectangle = Get_Mapfile_Rectangle()
        Map.MapCompass.Position = Get_Compass_Position_First_Position()
    End Sub
    ''' <summary>
    ''' 方位記号の初期値設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub init_Compass_First()
        With Map.MapCompass
            With .dirWord
                .North = ""
                .East = ""
                .West = ""
                .South = ""
            End With
            .Mark = clsBase.Mark
            .Font = clsBase.Font
            With .Mark
                .ShapeNumber = clsSettings.Data.Compass_Mark
                .PrintMark = enmMarkPrintType.Mark
                .Line.BasicLine.SolidLine.Width = 0.3
                .Tile.Line.BasicLine.SolidLine.Color = New colorARGB(Color.Black)
                .WordFont.Body.Size = clsSettings.Data.Compass_Mark_Size
            End With
            .Visible = True
            .Position = Get_Compass_Position_First_Position()
        End With
    End Sub
    ''' <summary>
    ''' 方位記号表示位置の初期値を地図の左上に設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_Compass_Position_First_Position() As PointF
        With Map.Circumscribed_Rectangle
            Dim pxy As PointF
            pxy.X = .Left + (.Right - .Left) / 20
            pxy.Y = .Top + (.Bottom - .Top) / 20
            Return pxy
        End With
    End Function
    ''' <summary>
    ''' 地図中の時間設定の期間を求める
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_duration_of_AllMapTimeSetting() As Start_End_Time_data
        Dim se As Start_End_Time_data = clsTime.GetNullStartEndYMD
        If Map.Time_Mode = True Then
            For i As Integer = 0 To Map.Kend - 1
                With MPObj(i)
                    For j As Integer = 0 To .NumOfNameTime - 1
                        se = Get_duration_of_AllMapTimeSetting_sub(se, .NameTimeSTC(j).SETime)
                    Next
                    For j As Integer = 0 To .NumOfSuc - 1
                        With .SucSTC(j)
                            If se.StartTime.nullFlag = False Then
                                se.StartTime = .Time
                            Else
                                se.StartTime = clsTime.getEarlier(se.StartTime, .Time)
                            End If

                            If se.EndTime.nullFlag = False Then
                                se.EndTime = .Time
                            Else
                                se.EndTime = clsTime.getLatter(se.EndTime, .Time)
                            End If

                        End With
                    Next
                    For j As Integer = 0 To .NumOfLine - 1
                        For k As Integer = 0 To .LineCodeSTC(j).NumOfTime - 1
                            se = Get_duration_of_AllMapTimeSetting_sub(se, .LineCodeSTC(j).Times(k))
                        Next
                    Next
                End With
            Next

            For i As Integer = 0 To Map.ALIN - 1
                With MPLine(i)
                    For j As Integer = 0 To .NumOfTime - 1
                        se = Get_duration_of_AllMapTimeSetting_sub(se, .LineTimeSTC(j).SETime)
                    Next
                End With
            Next
        End If
        Return se
    End Function
    Private Function Get_duration_of_AllMapTimeSetting_sub(ByVal SETime1 As Start_End_Time_data, ByVal SETime2 As Start_End_Time_data) As Start_End_Time_data
        With SETime1
            If SETime2.StartTime.nullFlag = False Then
                If .StartTime.nullFlag = True Then
                    .StartTime = SETime2.StartTime
                Else
                    .StartTime = clsTime.getEarlier(.StartTime, SETime2.StartTime)
                End If
            End If
            If SETime2.EndTime.nullFlag = False Then
                If .EndTime.nullFlag = True Then
                    .EndTime = SETime2.EndTime
                Else
                    .EndTime = clsTime.getLatter(.EndTime, SETime2.EndTime)
                End If
            End If
        End With
        Return SETime1
    End Function
    ''' <summary>
    ''' 地図データの挿入
    ''' </summary>
    ''' <param name="InsertMapData"></param>
    ''' <remarks></remarks>
    Public Sub InsertMapData(ByRef InsertMapData As clsMapData, ByVal objNameHeader As String)
        Dim OMap As strMap_data = Me.Map
        With Map
            .ALIN += InsertMapData.Map.ALIN
            .Time_Mode = .Time_Mode Or InsertMapData.Map.Time_Mode
            .Kend += InsertMapData.Map.Kend
            .OBKNum += InsertMapData.Map.OBKNum
            .LpNum += InsertMapData.Map.LpNum
            ReDim Preserve MPLine(Math.Max(.ALIN - 1, 0))
            ReDim Preserve MPObj(.Kend)
            ReDim Preserve ObjectKind(.OBKNum - 1)
            ReDim Preserve LineKind(.LpNum - 1)
        End With

        '線種の設定
        For i As Integer = 0 To InsertMapData.Map.LpNum - 1
            With InsertMapData.LineKind(i)
                If .NumofObjectGroup >= 2 Then
                    'オブジェクトグループ連動型線種の場合
                    For j As Integer = 1 To .NumofObjectGroup - 1
                        .ObjGroup(j).GroupNumber = .ObjGroup(j).GroupNumber + OMap.OBKNum
                    Next
                End If
            End With
            LineKind(i + OMap.LpNum) = InsertMapData.LineKind(i).Clone
            LineKind(i + OMap.LpNum).Name = objNameHeader + LineKind(i + OMap.LpNum).Name
        Next

        'オブジェクトグループの設定
        For i As Integer = 0 To OMap.OBKNum - 1
            With ObjectKind(i)
                If .ObjectType = enmObjectGoupType_Data.AggregationObject Then
                    ReDim Preserve .UseObjectGroup(Map.OBKNum - 1)
                Else
                    ReDim Preserve .UseLineType(Map.LpNum - 1)
                End If
            End With
        Next
        For i As Integer = 0 To InsertMapData.Map.OBKNum - 1
            ObjectKind(i + OMap.OBKNum) = InsertMapData.ObjectKind(i).Clone
            With ObjectKind(i + OMap.OBKNum)
                .Name = objNameHeader + .Name
                Dim r_Use() As Boolean
                If .ObjectType = enmObjectGoupType_Data.AggregationObject Then
                    r_Use = .UseObjectGroup
                    ReDim .UseObjectGroup(Map.OBKNum - 1)
                    For j As Integer = 0 To InsertMapData.Map.OBKNum - 1
                        .UseObjectGroup(j + OMap.OBKNum) = r_Use(j)
                    Next
                Else
                    r_Use = .UseLineType
                    ReDim .UseLineType(Map.LpNum - 1)
                    For j As Integer = 0 To InsertMapData.Map.LpNum - 1
                        .UseLineType(j + OMap.LpNum) = r_Use(j)
                    Next
                End If
            End With
        Next

        InsertMapData.Convert_ZahyoMode(Map.Zahyo)
        For i As Integer = 0 To InsertMapData.Map.Kend - 1
            MPObj(i + OMap.Kend) = InsertMapData.MPObj(i).Clone
            With MPObj(i + OMap.Kend)
                .Number += OMap.Kend
                For j As Integer = 0 To .NumOfNameTime - 1
                    With .NameTimeSTC(j)
                        For k As Integer = 0 To .NamesList.Length - 1
                            .NamesList(k) = objNameHeader + .NamesList(k)
                        Next
                    End With
                Next
                .Kind += OMap.OBKNum
                For j As Integer = 0 To .NumOfCenterP - 1
                    .CenterPSTC(j).Position = .CenterPSTC(j).Position
                Next
                For j As Integer = 0 To .NumOfLine - 1
                    If ObjectKind(.Kind).ObjectType = enmObjectGoupType_Data.NormalObject Then
                        With .LineCodeSTC(j)
                            .LineCode += OMap.ALIN
                        End With
                    Else
                        With .LineCodeSTC(j)
                            .LineCode += OMap.Kend
                        End With
                    End If
                Next
                For j As Integer = 0 To .NumOfSuc - 1
                    .SucSTC(j).ObjectCode += OMap.Kend
                Next
            End With
        Next


        For i As Integer = 0 To InsertMapData.Map.ALIN - 1
            MPLine(i + OMap.ALIN) = InsertMapData.MPLine(i).Clone
            With MPLine(i + OMap.ALIN)
                .Number += OMap.ALIN
                For j As Integer = 0 To .NumOfTime - 1
                    With .LineTimeSTC(j)
                        .Kind += OMap.LpNum
                    End With
                Next
                For j As Integer = 0 To .NumOfPoint - 1
                    .PointSTC(j) = .PointSTC(j)
                Next
            End With
        Next


        For i As Integer = OMap.ALIN To Map.ALIN - 1
            Check_Line_Maxmin(i, False)
        Next
        For i As Integer = OMap.Kend To Map.Kend - 1
            Check_Obj_Maxmin(MPObj(i), False)
        Next
        Map.Circumscribed_Rectangle = Get_Mapfile_Rectangle()

        Map.Comment += InsertMapData.Map.Comment
    End Sub
    ''' <summary>
    ''' 地図データを指定の座標モードに変換
    ''' </summary>
    ''' <param name="newMapZahyo"></param>
    ''' <remarks></remarks>
    Public Sub Convert_ZahyoMode(ByVal newMapZahyo As Zahyo_info)
        With Map
            .MapCompass.Position = spatial.Get_Reverse_and_Convert_XY(.MapCompass.Position, Map.Zahyo, newMapZahyo)
            For i As Integer = 0 To .ALIN - 1
                With MPLine(i)
                    For j As Integer = 0 To .NumOfPoint - 1
                        .PointSTC(j) = spatial.Get_Reverse_and_Convert_XY(.PointSTC(j), Map.Zahyo, newMapZahyo)
                    Next
                End With
            Next
            For i As Integer = 0 To .Kend - 1
                With MPObj(i)
                    For j As Integer = 0 To .NumOfCenterP - 1
                        .CenterPSTC(j).Position = spatial.Get_Reverse_and_Convert_XY(.CenterPSTC(j).Position, Map.Zahyo, newMapZahyo)
                    Next
                End With
            Next
            .Zahyo = newMapZahyo
            Checl_All_Line_Maxmin()
            Check_All_Obj_MaxMin()

            .Circumscribed_Rectangle = Get_Mapfile_Rectangle()
        End With
    End Sub
    ''' <summary>
    ''' 地図データの座標を、挿新しい地図データの座標に変換
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="InsertMapMap"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Trans_MapPoint_Zahyo(ByVal P As PointF, ByVal newMapZahyo As Zahyo_info) As PointF

        If newMapZahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
            Return P
        Else
            Dim X2C As Double, Y2C As Double
            Dim X3C As Double, Y3C As Double
            Dim P2 As PointF = spatial.Get_Reverse_XY(P, Map.Zahyo)
            If newMapZahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido And Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                If newMapZahyo.System <> Map.Zahyo.System Then
                    '二つとも緯度経度座標で、測地系が違う場合
                    Select Case Map.Zahyo.System
                        Case enmZahyo_System_Info.Zahyo_System_tokyo
                            Call Tokyo97toITRF94(P2.Y, P2.X, Y2C, X2C)
                        Case enmZahyo_System_Info.Zahyo_System_World
                            Call ITRF94toTokyo97(P2.Y, P2.X, Y2C, X2C)
                    End Select
                    P2.X = CSng(X2C)
                    P2.Y = CSng(Y2C)
                End If
            ElseIf Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_HeimenTyokkaku And newMapZahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                '元が平面直角、新規が緯度経度の場合、
                With Map.Zahyo
                    Dim Ellip12 As Integer
                    Dim Kei As Integer = .HeimenTyokkaku_KEI_Number
                    If .System = enmZahyo_System_Info.Zahyo_System_tokyo Then
                        Ellip12 = 1
                    ElseIf .System = enmZahyo_System_Info.Zahyo_System_World Then
                        Ellip12 = 2
                    End If
                    Call doCalcXy2bl(Ellip12, Kei, P2.Y, P2.X, Y2C, X2C)
                End With
                If newMapZahyo.System <> Map.Zahyo.System Then
                    'さらに測地系が違う場合
                    Select Case Map.Zahyo.System
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
    ''' Y座標を反転
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub YReverse()
        With Map.Circumscribed_Rectangle
            .Y = -.Bottom
        End With
        For i As Integer = 0 To Map.ALIN - 1
            With MPLine(i)
                For j As Integer = 0 To .NumOfPoint - 1
                    With .PointSTC(j)
                        .Y = -.Y
                    End With
                Next
                With .Circumscribed_Rectangle
                    .Y = -.Bottom
                End With
            End With
        Next

        For i As Integer = 0 To Map.Kend - 1
            With MPObj(i)
                For j As Integer = 0 To .NumOfCenterP - 1
                    With .CenterPSTC(j).Position
                        .Y = -.Y
                    End With
                Next
                With .Circumscribed_Rectangle
                    .Y = -.Bottom
                End With
            End With
        Next

    End Sub
    ''' <summary>
    ''' オブジェクト名リストを追加
    ''' </summary>
    ''' <param name="OBKNum"></param>
    ''' <param name="ObjectNameList">オブジェクト名リスト名</param>
    ''' <remarks></remarks>
    Public Sub Add_one_ObjectNameList(ByVal OBKNum As Integer, ByVal ObjectNameList As String)
        With ObjectKind(OBKNum)
            ReDim Preserve .ObjectNameList(.ObjectNameNum)
            .ObjectNameList(.ObjectNameNum) = ObjectNameList
            .ObjectNameNum += 1
        End With
    End Sub
    ''' <summary>
    ''' 初期属性データ項目を追加（時間属性設定なし）
    ''' </summary>
    ''' <param name="OBKNum"></param>
    ''' <param name="title"></param>
    ''' <param name="Unit"></param>
    ''' <remarks></remarks>
    Public Sub Add_one_DefAttDataSet(ByVal OBKNum As Integer, ByVal title As String, ByVal Unit As String, ByVal Note As String)

        With ObjectKind(OBKNum)
            ReDim Preserve .DefTimeAttSTC(.DefTimeAttDataNum)
            With .DefTimeAttSTC(.DefTimeAttDataNum)
                With .attData
                    .Title = title
                    .Unit = Unit
                    .Note = Note
                End With
            End With
            .DefTimeAttDataNum += 1
        End With

    End Sub

    ''' <summary>
    ''' オブジェクトグループごとの使用ライン線種を設定する
    ''' </summary>
    ''' <param name="ObjectUseLineInfo">オブジェクト名+tab+使用ライン線種名1+tab+使用ライン線種名2+cr+・・・・</param>
    ''' <remarks></remarks>
    Public Sub CheckLine_Kind_UsedBy_ObjectKind(ByVal ObjectUseLineInfo As String)

        For i As Integer = 0 To Map.OBKNum - 1
            ReDim ObjectKind(i).UseLineType(Math.Max(Map.LpNum - 1, 0))
        Next

        Dim OL() As String = ObjectUseLineInfo.Split(vbCr)
        For i As Integer = 0 To OL.Length - 1
            Dim str_ar() As String = OL(i).Split(vbTab)
            If UBound(str_ar) >= 1 Then
                For j As Integer = 0 To Map.OBKNum - 1
                    If ObjectKind(j).Name = str_ar(0) Then
                        For k As Integer = 0 To Map.LpNum - 1
                            For k2 As Integer = 1 To str_ar.Length - 1
                                If LineKind(k).Name = str_ar(k2) Then
                                    ObjectKind(j).UseLineType(k) = True
                                    Exit For
                                End If
                            Next
                        Next
                    End If
                Next
            End If
        Next
    End Sub
    ''' <summary>
    ''' 座標値が緯度経度そのままの地図データを、投影変換後の座標に変換する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MapLatLon_Zahyo_convert()
        Dim XY_Rect As RectangleF = Get_Mapfile_Rectangle()

        With Map
            .SCL = 1
            .SCL_U = enmScaleUnit.kilometer
            .Zahyo.CenterXY = spatial.Get_CenterPoint_of_Rect(XY_Rect)
        End With

        For i As Integer = 0 To Map.ALIN - 1
            With MPLine(i)
                For j As Integer = 0 To .NumOfPoint - 1
                    .PointSTC(j) = spatial.Get_Converted_XY(.PointSTC(j), Map.Zahyo)
                Next
            End With
            Check_Line_Maxmin(i, False)
        Next

        For i As Integer = 0 To Map.Kend - 1

            With MPObj(i)
                Dim CP As PointF
                Select Case .Shape
                    Case enmShape.PointShape
                        CP = MPObj(i).CenterPSTC(0).Position
                        CP = spatial.Get_Converted_XY(CP, Map.Zahyo)
                    Case enmShape.PolygonShape
                        Dim f As Boolean = GetObjGraviityXY(MPObj(i), CP, clsTime.GetYMD(0, 0, 0))
                    Case enmShape.LineShape
                        With MPLine(.LineCodeSTC(0).LineCode)
                            CP = .PointSTC(.NumOfPoint \ 2)
                        End With
                End Select
                .CenterPSTC(0).Position = CP
            End With
            Check_Obj_Maxmin(MPObj(i), False)
        Next
        Map.Circumscribed_Rectangle = Get_Mapfile_Rectangle()
    End Sub

    Public Sub GetObjectGravity_All()
        For i As Integer = 0 To Map.Kend - 1
            With MPObj(i)
                Dim CP As PointF
                Select Case .Shape
                    Case enmShape.PolygonShape
                        Dim f As Boolean = GetObjGraviityXY(MPObj(i), CP, clsTime.GetYMD(0, 0, 0))
                End Select
                .CenterPSTC(0).Position = CP
            End With
            Check_Obj_Maxmin(MPObj(i), False)
        Next
    End Sub
    ''' <summary>
    ''' オブジェクトグループ連動型も一つとして数えて線種の数を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_TotalLineKind_Num() As Integer
        Dim PatNum As Integer = 0
        For i As Integer = 0 To Me.Map.LpNum - 1
            PatNum += Me.LineKind(i).NumofObjectGroup
        Next
        Return PatNum
    End Function
    ''' <summary>
    ''' 線種で、オブジェクトグループ連動型も一つとして数えて情報を返す
    ''' </summary>
    ''' <param name="LPC"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_TotalLineKind(ByRef LPC() As clsMapData.LPatSek_Info) As Integer
        Dim PatNum As Integer = Get_TotalLineKind_Num()

        ReDim LPC(PatNum - 1)
        Dim n As Integer = 0
        For i As Integer = 0 To Me.Map.LpNum - 1
            With Me.LineKind(i)
                For j As Integer = 0 To .NumofObjectGroup - 1
                    With LPC(n)
                        .Pat = Me.LineKind(i).ObjGroup(j).Pattern
                        .LKind = i
                        .LkindPatNum = j
                        If j = 0 Then
                            .Name = Me.LineKind(i).Name
                        Else
                            .Name = "-" & Me.ObjectKind(Me.LineKind(i).ObjGroup(j).GroupNumber).Name
                        End If
                    End With
                    n += 1
                Next
            End With
        Next
        Return PatNum
    End Function
    ''' <summary>
    ''' Get_TotalLineKindのラインパターンを地図データの線種に設定する
    ''' </summary>
    ''' <param name="LPC"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Sub Set_TotalLineKind(ByRef LPC() As clsMapData.LPatSek_Info)

        Dim n As Integer = 0
        For i As Integer = 0 To Me.Map.LpNum - 1
            With Me.LineKind(i)
                For j As Integer = 0 To .NumofObjectGroup - 1
                    .ObjGroup(j).Pattern = LPC(n).Pat
                    n += 1
                Next
            End With
        Next
    End Sub
    ''' <summary>
    ''' オブジェクト番号で指定、'線オブジェクトと面・点オブジェクトの距離は、最も近い線の位置と点・面の代表点、点・面オブジェクト間の距離は代表点間の距離、
    ''' </summary>
    ''' <param name="O_Code1"></param>
    ''' <param name="O_Code2"></param>
    ''' <param name="Time1"></param>
    ''' <param name="Time2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Distance_Object(ByVal O_Code1 As Integer, ByVal O_Code2 As Integer, _
                                       ByVal Time1 As strYMD, ByVal Time2 As strYMD) As Single

        Dim P1 As PointF
        Dim P2 As PointF
        If MPObj(O_Code2).Shape = enmShape.LineShape Then
            clsGeneric.SWAP(O_Code1, O_Code2)
            clsGeneric.SWAP(Time1, Time2)
        End If

        Dim d As Single
        If MPObj(O_Code1).Shape = enmShape.LineShape Then
            '一方が線オブジェクトの場合
            Get_Enable_CenterP(P2, O_Code2, Time2)
            d = Get_Distance_Between_ObjectLine_and_Point(O_Code1, Time1, P2)
        Else
            Get_Enable_CenterP(P1, O_Code1, Time1)
            Get_Enable_CenterP(P2, O_Code2, Time2)
            If Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                d = spatial.Distance_Ido_Kedo_XY(P1, P2, Map.Zahyo)
            Else
                d = spatial.get_Distance(P1, P2) / Map.SCL
            End If
        End If
        Return d
    End Function
    ''' <summary>
    ''' オブジェクト番号と座標で指定、'線オブジェクトと面・点オブジェクトの距離は、最も近い線の位置と点・面の代表点、点・面オブジェクト間の距離は代表点間の距離、
    ''' </summary>
    ''' <param name="CP"></param>
    ''' <param name="O_Code1"></param>
    ''' <param name="Time1"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Distance_Object(ByVal CP As PointF, ByVal O_Code1 As Integer, ByVal Time1 As strYMD) As Single

        Dim P1 As PointF

        Dim d As Single
        If MPObj(O_Code1).Shape = enmShape.LineShape Then
            '一方が線オブジェクトの場合
            Get_Enable_CenterP(P1, O_Code1, Time1)
            d = Get_Distance_Between_ObjectLine_and_Point(O_Code1, Time1, CP)
        Else
            Get_Enable_CenterP(P1, O_Code1, Time1)
            If Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                d = spatial.Distance_Ido_Kedo_XY(P1, CP, Map.Zahyo)
            Else
                d = spatial.get_Distance(P1, CP) / Map.SCL
            End If
        End If
        Return d
    End Function

    ''' <summary>
    ''' オブジェクトの線とある地点との距離を求める
    ''' </summary>
    ''' <param name="Ocode"></param>
    ''' <param name="Time"></param>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Distance_Between_ObjectLine_and_Point(ByVal Ocode As Integer, ByVal Time As strYMD, ByVal P As PointF) As Single

        Dim ELine() As clsMapData.EnableMPLine_Data

        Dim n As Integer = Me.Get_EnableMPLine(ELine, Me.MPObj(Ocode), Time)

        Return Distance_PointMPLineAllay(P, n, ELine)

    End Function

    Public Function Distance_PointMPLineAllay(ByVal P As PointF, _
                                    ByVal MPLineNum As Integer, ByRef LCode() As clsMapData.EnableMPLine_Data) As Single


        Dim mind As Single
        Dim f As Boolean = False
        For i As Integer = 0 To MPLineNum - 1
            Dim lc As Integer = LCode(i).LineCode
            With Me.MPLine(lc)
                Dim ln As Integer = .NumOfPoint
                For j As Integer = 0 To ln - 2

                    Dim nearP As PointF
                    Dim DD As Single = spatial.Distance_PointLine(P, .PointSTC(j), .PointSTC(j + 1), nearP)
                    If Me.Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                        DD = spatial.Distance_Ido_Kedo_XY(P, nearP, Me.Map.Zahyo)
                    End If
                    If f = False Then
                        mind = DD
                        f = True
                    Else
                        If DD < mind Then
                            mind = DD
                        End If
                    End If
                Next
            End With
        Next
        If Me.Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
            Return mind
        Else
            Return mind / Me.Map.SCL
        End If
    End Function

End Class



