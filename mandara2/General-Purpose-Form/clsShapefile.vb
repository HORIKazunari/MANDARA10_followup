
Public Class clsShapefile
    Public Structure shapefile_info
        Public FileName As String
        Public FullPath As String
        Public Shape As enmShape
        Public DBFfieldNumber As Integer
        Public Zahyo As clsMapData.Zahyo_info
        Public prj_file_exist As Boolean
        Public dbf_file_exist As Boolean
        Public shx_file_exist As Boolean
        Public encodingnumber As Integer
    End Structure

    Private Structure IndexFileData_info
        Public offset As Integer
        Public contentsLength As Integer
    End Structure
    Private Structure XY_Genten_Info
        Public CenterB As Double
        Public CenterL As Double
    End Structure
    Private Structure XYMaxMin_Double
        Public XMin As Double
        Public Ymin As Double
        Public Xmax As Double
        Public YMax As Double
    End Structure
    Private Structure XY_Double
        Public X As Double
        Public Y As Double
    End Structure

    Private Shared Function Get_Big_Integer(ByVal Filenumber As Integer) As Integer
        Dim LG As Integer

        Dim b(3) As Byte
        FileGet(Filenumber, b)
        Array.Reverse(b)
        LG = System.BitConverter.ToInt32(b, 0)
        Return LG
    End Function
    Private Shared Function Get_Big_Integer(ByRef byteArray() As Byte, ByVal Position As Integer) As Integer
 
        Dim b(3) As Byte
        For i As Integer = 0 To 3
            b(3 - i) = byteArray(Position + i)
        Next
        Dim LG As Integer = System.BitConverter.ToInt32(b, 0)
        Return LG
    End Function
    Private Shared Function Get_SHXFile(ByVal filename As String, ByRef IndexData() As IndexFileData_info) As Boolean

        Dim Shape_File_Box As XYMaxMin_Double
        Dim ShapeType As Integer
        Dim db As Double
        Dim LG As Integer

        Dim Fname As String = clsGeneric.ReplaceFileExtention(filename, "shx")
        If System.IO.File.Exists(Fname) = False Then
            MsgBox(Fname & "が見つかりません。", MsgBoxStyle.Exclamation)
            Return False
        End If
        Dim n As Integer = FreeFile()
        FileOpen(n, Fname, OpenMode.Binary, OpenAccess.Read, OpenShare.LockWrite)

        LG = Get_Big_Integer(n)  'ﾌｧｲﾙコード「9994」
        For i As Integer = 1 To 5
            FileGet(n, LG)
        Next
        LG = Get_Big_Integer(n)
        FileGet(n, LG) 'バージョン「1000」
        FileGet(n, ShapeType)
        FileGet(n, Shape_File_Box)
        FileGet(n, db)
        FileGet(n, db)
        FileGet(n, db)
        FileGet(n, db)
        Dim indexN As Integer = 0
        ReDim IndexData(1000)
        Do
            If UBound(IndexData) < indexN Then
                ReDim Preserve IndexData(indexN + 1000)
            End If
            IndexData(indexN).offset = Get_Big_Integer(n)
            IndexData(indexN).contentsLength = Get_Big_Integer(n)
            If IndexData(indexN).offset <> 0 Then
                indexN += 1
            End If
        Loop While EOF(n) = False
        FileClose(n)
        ReDim Preserve IndexData(indexN - 1)

        Return True
    End Function
    Private Shared Function Get_SHXFile_Binary(ByVal filename As String, ByRef IndexData() As IndexFileData_info) As Boolean

        Dim Shape_File_Box As XYMaxMin_Double
        Dim ShapeType As Integer
        Dim db As Double
        Dim LG As Integer

        Dim Fname As String = clsGeneric.ReplaceFileExtention(filename, "shx")
        Dim bs() As Byte
        If clsGeneric.Get_BinaryFile_asByte(Fname, bs) = False Then
            Return False
        End If

        Dim n As Integer = (bs.Length - 100) \ 8
        ReDim IndexData(n - 1)
        Dim nn As Integer = 0
        For i As Integer = 0 To n - 1
            IndexData(nn).offset = Get_Big_Integer(bs, i * 8 + 100)
            IndexData(nn).contentsLength = Get_Big_Integer(bs, i * 8 + 100 + 4)
            If IndexData(nn).offset <> 0 Then
                nn += 1
            End If
        Next
        ReDim Preserve IndexData(nn - 1)

        Return True

    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="filename">ファイル名</param>
    ''' <param name="ObjNameHeader">オブジェクト名のヘッダ文字列</param>
    ''' <param name="dbfGetF">dbfファイルを取得する場合true</param>
    ''' <param name="MapZahyo">地図座標参照系</param>
    ''' <param name="UnitCheckFlag">数値をチェックして文字列、カテゴリーを分ける場合true</param>
    ''' <param name="encodenumber">dbfデータの文字コード番号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_ShapeFile(ByVal filename As String, ByVal ObjNameHeader As String,
                                  ByVal dbfGetF As Boolean, ByVal MapZahyo As clsMapData.Zahyo_info, ByVal UnitCheckFlag As Boolean, ByVal encodenumber As Integer,
                                  ByRef ProgressLabel As KTGISUserControl.KTGISProgressLabel) As clsMapData
        Dim MapData As New clsMapData

        Dim f As Boolean = Get_ShapeFile_sub_Binary(filename, ObjNameHeader, MapData, ProgressLabel)

        If f = True Then
            MapData.Map.Zahyo = MapZahyo
            MapData.Map.FileName = System.IO.Path.GetFileName(filename)
            MapData.Map.FullPath = ""
            MapData.NoDataFlag = False
            Zahyo_convert(MapData)

            If dbfGetF = True Then
                '地図データに初期属性として設定
                Dim Title() As String, Unit() As String, Data(,) As String
                Dim dbfgf = Get_ShapeDBF(filename, Title, Unit, Data, UnitCheckFlag, encodenumber, ProgressLabel)
                If dbfgf = True Then
                    Dim nX As Integer = Data.GetUpperBound(0) + 1
                    Dim ny As Integer = Data.GetUpperBound(1) + 1
                    For i As Integer = 0 To nX - 1
                        MapData.Add_one_DefAttDataSet(0, Title(i), Unit(i), "")
                    Next

                    For i As Integer = 0 To ny - 1
                        With MapData.MPObj(i)
                            ReDim .DefTimeAttValue(nX - 1)
                            For j As Integer = 0 To nX - 1
                                ReDim .DefTimeAttValue(j).Data(0)
                                .DefTimeAttValue(j).Data(0).Value = Data(j, i)
                            Next
                        End With
                    Next
                Else
                    f = False
                End If
            End If
        End If

        If f = False Then
            MapData = Nothing
        End If
        Return MapData
    End Function
    ''' <summary>
    ''' DBFファイルのデータ項目数を返す
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <param name="FieldNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_DBFFiledNumber(ByVal filename As String, ByRef FieldNum As Integer) As Boolean
        If System.IO.File.Exists(filename) = False Then
            Return False
        End If
        Try
            Dim fs As New System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Dim ByteArray(20) As Byte
            fs.Read(ByteArray, 0, 20)
            fs.Close()
            Dim Header_Byte As Short = BitConverter.ToInt16(ByteArray, 8)
            FieldNum = (Header_Byte - 33) \ 32
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' シェープファイルの形状を返す
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <param name="shape"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_ShapfileShape(ByVal filename As String, ByRef shape As enmShape) As Boolean
        If System.IO.File.Exists(filename) = False Then
            Return False
        End If
        Try
            Dim fs As New System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Dim ByteArray(40) As Byte
            fs.Read(ByteArray, 0, 40)
            fs.Close()
            Dim ShapeType As Integer = BitConverter.ToInt32(ByteArray, 32)

            Select Case ShapeType
                Case 1, 11, 21
                    shape = enmShape.PointShape
                Case 3, 13, 23
                    shape = enmShape.LineShape
                Case 5, 15, 25
                    shape = enmShape.PolygonShape
                Case Else
                    Return False
            End Select
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Shared Function Get_ShapeFile_sub_Binary(ByVal filename As String, ByVal ObjNameHeader As String,
                                          ByRef MapData As clsMapData,
                                          ByRef ProgressLabel As KTGISUserControl.KTGISProgressLabel) As Boolean

        Dim indexFileData() As IndexFileData_info

        Dim f As Boolean
        f = Get_SHXFile_Binary(filename, indexFileData)
        If f = False Then
            Return False
        End If

        If indexFileData.Length = 0 Then
            MsgBox(filename & "にはデータが含まれていません。", MsgBoxStyle.Exclamation)
            Return False
        End If
        Dim ShapeS As enmShape

        Dim NumPoints As Integer
        Dim ShapeType As Integer
        Dim PointIndex() As Integer
        Dim Points() As XY_Double
        Dim C_Point As XY_Double
        Dim RecordNumber As Integer


        Dim bs() As Byte
        If clsGeneric.Get_BinaryFile_asByte(filename, bs) = False Then
            Return False
        End If


        ShapeType = BitConverter.ToInt32(bs, 32)

        Select Case ShapeType
            Case 1, 11, 21
                ShapeS = enmShape.PointShape
            Case 3, 13, 23
                ShapeS = enmShape.LineShape
            Case 5, 15, 25
                ShapeS = enmShape.PolygonShape
            Case Else
                MsgBox(filename & "のシェープタイプは読み込めません。", MsgBoxStyle.Exclamation)
                Return False
        End Select

        Dim Obk As Integer
        Dim LK As Integer
        With MapData
            Obk = .Map.OBKNum
            LK = .Map.LpNum
            .Add_OneObjectGroup_Parameter(System.IO.Path.GetFileName(filename), ShapeS, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
            If ShapeS <> enmShape.PointShape Then
                Dim lp As Line_Property = clsBase.Line
                If indexFileData.Length > 500 Then
                    lp = clsBase.BlancLine
                End If
                .Add_OneLineKind(System.IO.Path.GetFileName(filename), lp, enmMesh_Number.mhNonMesh)
                .ObjectKind(Obk).UseLineType(0) = True
            End If
            ReDim .MPObj(indexFileData.Length - 1)
        End With


        ProgressLabel.Visible = True
        ProgressLabel.Start(indexFileData.Length, System.IO.Path.GetFileName(filename) & "読み込み中", False)

        Dim n As Integer = 0
        Do
            'レコードヘッダ
            If RecordNumber Mod 2 = 0 Then
                ProgressLabel.SetValue(n)
            End If
            Dim pos As Integer = indexFileData(n).offset * 2
            RecordNumber = Get_Big_Integer(bs, pos)  'レコード番号
            If RecordNumber = 0 Then
                Exit Do
            End If
            pos += 4
            Dim cl = Get_Big_Integer(bs, pos) 'コンテンツ長さ
            pos += 4
            Dim ShapeType1 = BitConverter.ToInt32(bs, pos) 'シェープタイプ
            pos += 4
            If cl > 2 Then 'コンテンツ長さが2より短い場合は処理しない
                Dim AlinS As Integer = MapData.Map.ALIN
                Dim NumParts As Integer = 0
                Select Case ShapeType
                    Case 1, 11 'Point
                        C_Point.X = BitConverter.ToDouble(bs, pos)
                        C_Point.Y = BitConverter.ToDouble(bs, pos + 8)
                    Case 3, 5, 13, 15, 23, 25 'Line,Polygon
                        pos += 8 * 4
                        NumParts = BitConverter.ToInt32(bs, pos)
                        NumPoints = BitConverter.ToInt32(bs, pos + 4)
                        pos += 8
                        ReDim PointIndex(NumParts)
                        ReDim Points(NumPoints)
                        For i As Integer = 0 To NumParts - 1
                            PointIndex(i) = BitConverter.ToInt32(bs, pos)
                            pos += 4
                        Next
                        For i As Integer = 0 To NumPoints - 1
                            Points(i).X = System.BitConverter.ToDouble(bs, pos)
                            Points(i).Y = System.BitConverter.ToDouble(bs, pos + 8)
                            pos += 16
                        Next
                        PointIndex(NumParts) = NumPoints

                        For i As Integer = 0 To NumParts - 1
                            Dim newLine As clsMapData.strLine_Data = MapData.Init_One_Line(LK)
                            With newLine
                                .NumOfPoint = PointIndex(i + 1) - PointIndex(i)
                                .LineTimeSTC(0).Kind = LK
                                ReDim .PointSTC(.NumOfPoint - 1)
                                For j As Integer = 0 To .NumOfPoint - 1
                                    With .PointSTC(j)
                                        .X = Points(PointIndex(i) + j).X
                                        .Y = Points(PointIndex(i) + j).Y
                                    End With
                                Next
                            End With
                            MapData.Save_Line(newLine, False, False, False)
                        Next

                End Select

                Dim newObj As clsMapData.strObj_Data = MapData.Init_One_Object(Obk)
                With newObj
                    .Kind = Obk
                    .Shape = ShapeS
                    With .NameTimeSTC(0)
                        .NamesList(0) = ObjNameHeader & RecordNumber
                    End With

                    Select Case .Shape
                        Case enmShape.PointShape
                            .CenterPSTC(0).Position.X = C_Point.X
                            .CenterPSTC(0).Position.Y = C_Point.Y
                        Case Else
                            .NumOfLine = NumParts
                            ReDim .LineCodeSTC(.NumOfLine - 1)
                            For j As Integer = 0 To .NumOfLine - 1
                                .LineCodeSTC(j).LineCode = AlinS + j
                                .LineCodeSTC(j).NumOfTime = 0
                            Next
                            If NumParts > 0 Then
                                .CenterPSTC(0).Position = MapData.MPLine(.LineCodeSTC(0).LineCode).PointSTC(0)
                            End If
                    End Select
                    MapData.Save_Object(newObj, False)
                End With


            End If
            n += 1
        Loop While n < indexFileData.Length

        ProgressLabel.Visible = False
        Return True
    End Function
    Private Shared Function Get_ShapeFile_sub(ByVal filename As String, ByVal ObjNameHeader As String,
                                              ByRef MapData As clsMapData,
                                              ByRef ProgressLabel As KTGISUserControl.KTGISProgressLabel) As Boolean
        'シェープファイル読み込み

        Dim LG As Integer
        Dim db As Double

        Dim ShapeS As enmShape
        Dim Contents_Box As XYMaxMin_Double

        Dim NumPoints As Integer
        Dim Shape_File_Box As XYMaxMin_Double
        Dim ShapeType As Integer
        Dim PointIndex() As Integer
        Dim Points() As XY_Double
        Dim C_Point As XY_Double
        Dim RecordNumber As Integer


        Dim indexFileData() As IndexFileData_info

        Dim f As Boolean
        f = Get_SHXFile(filename, indexFileData)
        If f = False Then
            Return False
        End If


        Dim filenum As Integer = FreeFile()
        FileOpen(filenum, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.LockWrite)
        LG = Get_Big_Integer(filenum)  'ﾌｧｲﾙコード「9994」
        For i As Integer = 1 To 5
            FileGet(filenum, LG)
        Next
        LG = Get_Big_Integer(filenum)
        FileGet(filenum, LG) 'バージョン「1000」
        FileGet(filenum, ShapeType)
        FileGet(filenum, Shape_File_Box)
        FileGet(filenum, db)
        FileGet(filenum, db)
        FileGet(filenum, db)
        FileGet(filenum, db)
        Select Case ShapeType
            Case 1, 11, 21
                ShapeS = enmShape.PointShape
            Case 3, 13, 23
                ShapeS = enmShape.LineShape
            Case 5, 15, 25
                ShapeS = enmShape.PolygonShape
            Case Else
                MsgBox(filename & "のシェープタイプは読み込めません。", MsgBoxStyle.Exclamation)
                FileClose(filenum)
                Return False
        End Select
        ProgressLabel.Visible = True
        ProgressLabel.Start(LOF(filenum), System.IO.Path.GetFileName(filename) & "読み込み中", False)
        Dim Obk As Integer
        Dim LK As Integer
        With MapData
            Obk = .Map.OBKNum
            LK = .Map.LpNum
            .Add_OneObjectGroup_Parameter(System.IO.Path.GetFileName(filename), ShapeS, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
            If ShapeS <> enmShape.PointShape Then
                .Add_OneLineKind(System.IO.Path.GetFileName(filename), clsBase.Line, enmMesh_Number.mhNonMesh)
                .ObjectKind(Obk).UseLineType(0) = True
            End If
        End With

        Dim n As Integer = 0
        Do
            'レコードヘッダ
            If RecordNumber Mod 2 = 0 Then
                ProgressLabel.SetValue(Loc(filenum))
            End If
            Seek(filenum, indexFileData(n).offset * 2 + 1)
            RecordNumber = Get_Big_Integer(filenum)  'レコード番号
            If RecordNumber = 0 Then
                Exit Do
            End If
            LG = Get_Big_Integer(filenum)  'コンテンツ長さ
            FileGet(filenum, LG) 'シェープタイプ

            Dim AlinS As Integer = MapData.Map.ALIN
            Dim NumParts As Integer = 0
            Select Case ShapeType
                Case 1, 11, 21 'Point
                    FileGet(filenum, C_Point)
                    Select Case ShapeType
                        Case 11
                            FileGet(filenum, db)
                            FileGet(filenum, db)
                        Case 21
                            FileGet(filenum, db)
                    End Select
                Case 3, 5, 13, 15, 23, 25 'Line,Polygon
                    FileGet(filenum, Contents_Box)
                    FileGet(filenum, NumParts)
                    FileGet(filenum, NumPoints)
                    ReDim PointIndex(NumParts)
                    ReDim Points(NumPoints)
                    For i As Integer = 0 To NumParts - 1
                        FileGet(filenum, PointIndex(i))
                    Next
                    Dim bt(NumPoints * 16 - 1) As Byte
                    FileGet(filenum, bt)
                    For i As Integer = 0 To NumPoints - 1
                        Points(i).X = System.BitConverter.ToDouble(bt, 16 * i)
                        Points(i).Y = System.BitConverter.ToDouble(bt, 16 * i + 8)
                    Next
                    Select Case ShapeType
                        Case 13, 15
                            For j As Integer = 0 To 1
                                FileGet(filenum, db)
                                FileGet(filenum, db)
                                For i As Integer = 0 To NumPoints - 1
                                    FileGet(filenum, db)
                                Next
                            Next
                        Case 23, 25
                            FileGet(filenum, db)
                            FileGet(filenum, db)
                            For i As Integer = 0 To NumPoints - 1
                                FileGet(filenum, db)
                            Next
                    End Select
                    PointIndex(NumParts) = NumPoints

                    For i As Integer = 0 To NumParts - 1
                        Dim newLine As clsMapData.strLine_Data = MapData.Init_One_Line(LK)
                        With newLine
                            .NumOfPoint = PointIndex(i + 1) - PointIndex(i)
                            .LineTimeSTC(0).Kind = LK
                            ReDim .PointSTC(.NumOfPoint - 1)
                            For j As Integer = 0 To .NumOfPoint - 1
                                With .PointSTC(j)
                                    .X = Points(PointIndex(i) + j).X
                                    .Y = Points(PointIndex(i) + j).Y
                                End With
                            Next
                        End With
                        MapData.Save_Line(newLine, False, False, False)
                    Next

            End Select

            Dim newObj As clsMapData.strObj_Data = MapData.Init_One_Object(Obk)
            With newObj
                .Kind = Obk
                .Shape = ShapeS
                With .NameTimeSTC(0)
                    .NamesList(0) = ObjNameHeader & RecordNumber
                End With

                Select Case .Shape
                    Case enmShape.PointShape
                        .CenterPSTC(0).Position.X = C_Point.X
                        .CenterPSTC(0).Position.Y = C_Point.Y
                    Case Else
                        .NumOfLine = NumParts
                        ReDim .LineCodeSTC(.NumOfLine - 1)
                        For j As Integer = 0 To .NumOfLine - 1
                            .LineCodeSTC(j).LineCode = AlinS + j
                            .LineCodeSTC(j).NumOfTime = 0
                        Next
                        .CenterPSTC(0).Position = MapData.MPLine(.LineCodeSTC(0).LineCode).PointSTC(0)
                End Select
                MapData.Save_Object(newObj, False)
            End With

            n += 1
        Loop While n < indexFileData.Length
        FileClose(filenum)

        ProgressLabel.Visible = False
        Return True
    End Function

    Private Shared Sub Zahyo_convert(ByRef MapData As clsMapData)


        Select Case MapData.Map.Zahyo.Mode
            Case enmZahyo_mode_info.Zahyo_Ido_Keido
                MapData.Checl_All_Line_Maxmin()
                MapData.MapLatLon_Zahyo_convert()

            Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                MapData.YReverse()
                MapData.Checl_All_Line_Maxmin()
                MapData.Check_All_Obj_MaxMin()
                MapData.GetObjectGravity_All()
                With MapData.Map
                    .SCL = 1000
                    .SCL_U = enmScaleUnit.kilometer
                End With
                MapData.Map.Circumscribed_Rectangle = MapData.Get_Mapfile_Rectangle
            Case enmZahyo_mode_info.Zahyo_No_Mode
                MapData.Checl_All_Line_Maxmin()
                MapData.Check_All_Obj_MaxMin()
                MapData.GetObjectGravity_All()
                With MapData.Map
                    .SCL = 1
                    .SCL_U = enmScaleUnit.kilometer
                End With
                MapData.Map.Circumscribed_Rectangle = MapData.Get_Mapfile_Rectangle
        End Select
    End Sub
    ''' <summary>
    ''' DBFファイル取得
    ''' </summary>
    ''' <param name="filename">シェープファイルのパス</param>
    ''' <param name="Title">データ項目のタイトル（戻り値）</param>
    ''' <param name="Unit">データ項目の単位（戻り値）</param>
    ''' <param name="Data">データ値の二次元配列（戻り値）</param>
    ''' <param name="UnitCheckFlag">数値をチェックして文字列、カテゴリーを分ける場合true</param>
    ''' <param name="encodenumber">dbfデータの文字コード番号</param>
    '''     ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Get_ShapeDBF(ByVal filename As String,
                                 ByRef Title() As String, ByRef Unit() As String, ByRef Data(,) As String, ByVal UnitCheckFlag As Boolean,
                                 ByVal encodenumber As Integer, ByRef ProgressLabel As KTGISUserControl.KTGISProgressLabel) As Boolean


        Dim dbf_f As String
        Dim DBFFile As New clsDBF

        dbf_f = clsGeneric.ReplaceFileExtention(filename, "dbf")

        If DBFFile.LoadDBF_Binary(dbf_f, encodenumber, ProgressLabel) = False Then
            Return False
        End If
        'If DBFFile.LoadDBF(dbf_f, ProgressLabel) = False Then
        '    Return False
        'End If
        Dim nX As Integer = DBFFile.FieldNumber
        Dim nY As Integer = DBFFile.RecordNumber
        Data = DBFFile.DataValue_Allay

        ReDim Title(DBFFile.FieldNumber - 1)
        For i As Integer = 0 To nX - 1
            Title(i) = DBFFile.FieldName(i)
        Next
        If UnitCheckFlag = False Then
            ReDim Unit(DBFFile.FieldNumber - 1)
            For i As Integer = 0 To nX - 1
                If DBFFile.FieldStringData_Flag(i) = True Then
                    Unit(i) = "STR"
                End If
            Next
        Else
            Unit = clsGeneric.Check_DataType(nX, nY, Data)
        End If



        DBFFile = Nothing

        '    Case "DBFDATA"
        '        '属性データに設定
        '        Dim n As Integer = 0
        '        For i As Integer = 0 To OBj_SubNum - 1
        '            n += Layer(i).Object.Object_n
        '        Next

        '        Call Add_one_Layer(ObjectKind(OBj_SubNum).Name, ObjectKind(OBj_SubNum).Shape, -1, nY, 0, False)
        '        For i As Integer = 0 To nY - 1
        '            With KenCode(i + Layer(OBj_SubNum).Object.Stac).Object
        '                .Name = MPObj(n + i).NameTimeSTC(0).Name1
        '                .code = n + i
        '                Call Get_Enable_CenterP(.Symbol.X, .Symbol.Y, .code, -1)
        '                .Label = .Symbol
        '            End With
        '        Next
        '        Call frmSettei.Set_STRData_To_Cell(OBj_SubNum, nX, nY, False, TTL, UNT, DN_Str)
        '        Call init_Multimode(OBj_SubNum)
        'End Select

        Get_ShapeDBF = True
    End Function
    ''' <summary>
    ''' prjファイル座標系・測地系等データ取得
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <param name="MapZahyo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_prj_file(ByVal filename As String, ByRef MapZahyo As clsMapData.Zahyo_info) As Boolean

        With MapZahyo
            .Mode = enmZahyo_mode_info.Zahyo_No_Mode
            .System = enmZahyo_System_Info.Zahyo_System_No
        End With

        Dim Fname As String = clsGeneric.ReplaceFileExtention(filename, "prj")

        Dim FData As String
        Try
            Dim sr As New System.IO.StreamReader(Fname, System.Text.Encoding.GetEncoding("shift_jis"))
            FData = UCase(sr.ReadToEnd())
            sr.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try


        If InStr(FData, "UNDEFINED") <> 0 Then
            Return False
        End If

        If (InStr(FData, "D_TOKYO") <> 0) Then
            '日本測地系
            MapZahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido
            MapZahyo.System = enmZahyo_System_Info.Zahyo_System_tokyo
        End If

        If (InStr(FData, "D_JGD_2000") <> 0) Or (InStr(FData, "D_JGD_2011") <> 0) Or
            ((InStr(FData, "D_WGS84") <> 0) Or (InStr(FData, "D_WGS_1984") <> 0)) Then
            '世界測地系
            MapZahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido
            MapZahyo.System = enmZahyo_System_Info.Zahyo_System_World
        End If
        If (InStr(FData, "JAPAN_ZONE_") <> 0) Then
            '平面直角
            MapZahyo.Mode = enmZahyo_mode_info.Zahyo_HeimenTyokkaku
            MapZahyo.HeimenTyokkaku_KEI_Number = Val(Mid(FData, InStr(FData, "JAPAN_ZONE_") + 11, 2))
        Else
            Dim HC As String = "Japan_Plane_Rectangular_CS_"
            Dim heimen_Code(19) As String

            heimen_Code(1) = HC + "I"
            heimen_Code(2) = HC + "II"
            heimen_Code(3) = HC + "III"
            heimen_Code(4) = HC + "IV"
            heimen_Code(5) = HC + "V"
            heimen_Code(6) = HC + "VI"
            heimen_Code(7) = HC + "VII"
            heimen_Code(8) = HC + "VIII"
            heimen_Code(9) = HC + "IX"
            heimen_Code(10) = HC + "X"
            heimen_Code(11) = HC + "XI"
            heimen_Code(12) = HC + "XII"
            heimen_Code(13) = HC + "XIII"
            heimen_Code(14) = HC + "XIV"
            heimen_Code(15) = HC + "XV"
            heimen_Code(16) = HC + "XVI"
            heimen_Code(17) = HC + "XVII"
            heimen_Code(18) = HC + "XVII"
            heimen_Code(19) = HC + "XIX"
            For i As Integer = 19 To 1 Step -1
                If (InStr(FData, UCase(heimen_Code(i))) <> 0) Then '平面直角
                    MapZahyo.Mode = enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                    MapZahyo.HeimenTyokkaku_KEI_Number = i
                    Exit For
                End If
            Next
        End If
        Return True

    End Function
    ''' <summary>
    ''' メッシュレイヤの出力
    ''' </summary>
    ''' <param name="Zahyo"></param>
    ''' <param name="filename"></param>
    ''' <param name="Objn"></param>
    ''' <param name="points">1メッシュ5ポイント×オブジェクト数</param>
    ''' <param name="meshRect"></param>
    ''' <param name="Data_Item_n"></param>
    ''' <param name="Data_Title"></param>
    ''' <param name="Data_STR_F"></param>
    ''' <param name="StrData"></param>
    ''' <param name="encodenumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function meshShapeFileOut(ByVal Zahyo As clsMapData.Zahyo_info, ByVal shape As enmShape, ByVal filename As String, ByVal Objn As Integer, ByRef points() As PointF, ByRef meshRect() As RectangleF,
                            ByVal Data_Item_n As Integer, ByRef Data_Title() As String, ByRef Data_STR_F() As Boolean,
                            ByRef StrData(,) As String, ByVal encodenumber As Integer) As Boolean
        Dim f As Boolean = False
        If clsGeneric.KillFile_if_exists(filename) = True Then
            Dim filename_shx As String = clsGeneric.ReplaceFileExtention(filename, "shx")
            If clsGeneric.KillFile_if_exists(filename_shx) = True Then
                f = meahOut(Zahyo, shape, filename, Objn, points, meshRect)
                If f = True Then
                    Dim filename_dbf As String = clsGeneric.ReplaceFileExtention(filename, "dbf")
                    If clsGeneric.KillFile_if_exists(filename_dbf) = True Then
                        Call DBF_Out(filename_dbf, Objn, Data_Item_n, Data_Title, Data_STR_F, StrData, encodenumber)
                    End If
                End If
            End If
        End If
        If f = True Then
            If Zahyo.Mode <> enmZahyo_mode_info.Zahyo_No_Mode Then
                f = ShapeFileOut_prj(filename, Zahyo)
            End If
        End If
        If f = False Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Shared Function meahOut(ByVal Zahyo As clsMapData.Zahyo_info, ByVal shape As enmShape, ByVal filename As String, ByVal Objn As Integer, ByRef points() As PointF, ByRef meshRect() As RectangleF) As Boolean
        Dim Obj_Index(Objn - 1) As Integer
        Dim Obj_Length(Objn - 1) As Integer

        Dim ShapeType As Integer
        If shape = enmShape.PolygonShape Then
            ShapeType = 5
        Else
            ShapeType = 3
        End If

        Dim Flen As Integer = 50
        Dim Bounding_box As RectangleF = meshRect(0)
        Dim Parts As Integer = 1
        Dim PLN As Integer = 5
        For i As Integer = 0 To Objn - 1
            Bounding_box = spatial.Get_Circumscribed_Rectangle(meshRect(i), Bounding_box)
            Obj_Index(i) = Flen
            Obj_Length(i) = (2 + 4 * 4 + 2 + 2 + 2 * Parts + 4 * 2 * PLN)
            Flen += (2 + 2) + Obj_Length(i)
        Next
        Bounding_box = spatial.Get_Reverse_Rect(Bounding_box, Zahyo)

        'SHP
        Dim filenumber As Integer = FreeFile()
        Try
            FileOpen(filenumber, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.LockReadWrite)
        Catch ex As Exception
            Return False
        End Try

        Dim PointIndex(0) As Integer
        PointIndex(0) = 0
        Call Put_HeaderPart(Flen, ShapeType, Bounding_box, filenumber)
        For i As Integer = 0 To Objn - 1
            Dim pxy(4) As PointF
            For j As Integer = 0 To 3
                pxy(j) = points(i * 4 + j)
            Next
            pxy(4) = points(i * 4)
            Dim Bounding_Obj = spatial.Get_Reverse_Rect(meshRect(i), Zahyo)
            Call Put_Poly_Shape_XY(Zahyo, ShapeType, i + 1, Parts, PLN, PointIndex, pxy, Bounding_Obj, filenumber)

        Next
        FileClose(filenumber)
        Dim filename_shx As String = clsGeneric.ReplaceFileExtention(filename, "shx")  'shx
        If SHX_Out(filename_shx, Objn, ShapeType, Bounding_box, Obj_Index, Obj_Length) = False Then
            Return False
        End If

        Return True
    End Function
    ''' <summary>
    ''' 地点定義レイヤの出力
    ''' </summary>
    ''' <param name="Zahyo"></param>
    ''' <param name="filename"></param>
    ''' <param name="Objn"></param>
    ''' <param name="points"></param>
    ''' <param name="Data_Item_n"></param>
    ''' <param name="Data_Title"></param>
    ''' <param name="Data_STR_F"></param>
    ''' <param name="StrData"></param>
    ''' <param name="encodenumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function defPointShapeFileOut(ByVal Zahyo As clsMapData.Zahyo_info, ByVal filename As String, ByVal Objn As Integer, ByRef points() As PointF, _
                            ByVal Data_Item_n As Integer, ByRef Data_Title() As String, ByRef Data_STR_F() As Boolean,
                            ByRef StrData(,) As String, ByVal encodenumber As Integer) As Boolean
        Dim f As Boolean = False
        If clsGeneric.KillFile_if_exists(filename) = True Then
            Dim filename_shx As String = clsGeneric.ReplaceFileExtention(filename, "shx")
            If clsGeneric.KillFile_if_exists(filename_shx) = True Then
                f = shpPointOut(Zahyo, filename, Objn, points)
                If f = True Then
                    Dim filename_dbf As String = clsGeneric.ReplaceFileExtention(filename, "dbf")
                    If clsGeneric.KillFile_if_exists(filename_dbf) = True Then
                        Call DBF_Out(filename_dbf, Objn, Data_Item_n, Data_Title, Data_STR_F, StrData, encodenumber)
                    End If
                End If
            End If
        End If
        If f = True Then
            If Zahyo.Mode <> enmZahyo_mode_info.Zahyo_No_Mode Then
                f = ShapeFileOut_prj(filename, Zahyo)
            End If
        End If
        If f = False Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' シェープファイル出力
    ''' </summary>
    ''' <param name="MapData">地図データ</param>
    ''' <param name="filename">ファイル名</param>
    ''' <param name="Objn">出力するオブジェクト数</param>
    ''' <param name="Objs">オブジェクト番号</param>
    ''' <param name="Time">時間</param>
    ''' <param name="Data_Item_n">データ項目数</param>
    ''' <param name="Data_Title">データ項目のタイトル配列</param>
    ''' <param name="Data_STR_F">データ項目が文字列の場合trueにする配列</param>
    ''' <param name="StrData">属性データの二次元配列(データ項目,オブジェクト)</param>
    ''' <param name="encodenumber">dbfデータの文字コード番号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ShapeFileOut(ByRef MapData As clsMapData, ByVal filename As String, ByVal Objn As Integer, ByRef Objs() As Integer, ByVal Time As strYMD, _
                            ByVal Data_Item_n As Integer, ByRef Data_Title() As String, ByRef Data_STR_F() As Boolean,
                            ByRef StrData(,) As String, ByVal encodenumber As Integer) As Boolean
        Dim ObjShape(2) As Integer


        If Objn = 0 Then
            MsgBox("オブジェクトがありません。", MsgBoxStyle.Exclamation)
            Return False
        End If

        Dim SP As enmShape = MapData.MPObj(Objs(0)).Shape
        For i As Integer = 1 To Objn - 1
            If SP <> MapData.MPObj(Objs(i)).Shape Then
                MsgBox("オブジェクトの形状が統一されていません。", MsgBoxStyle.Exclamation)
                Return False
            End If
        Next

        Dim f As Boolean = False
        If clsGeneric.KillFile_if_exists(filename) = True Then
            Dim filename_shx As String = clsGeneric.ReplaceFileExtention(filename, "shx")
            If clsGeneric.KillFile_if_exists(filename_shx) = True Then
                Select Case SP
                    Case enmShape.PointShape
                        f = ShapeFileOut_Point(MapData, filename, Objn, Objs, Time)
                    Case enmShape.LineShape
                        f = ShapeFileOut_Line(MapData, filename, Objn, Objs, Time)
                    Case enmShape.PolygonShape
                        f = ShapeFileOut_Polygon(MapData, filename, Objn, Objs, Time)
                End Select
                If f = True Then

                    Dim filename_dbf As String = clsGeneric.ReplaceFileExtention(filename, "dbf")
                    If clsGeneric.KillFile_if_exists(filename_dbf) = True Then
                        Call DBF_Out(filename_dbf, Objn, Data_Item_n, Data_Title, Data_STR_F, StrData, encodenumber)
                    End If
                End If
            End If
        End If
        If f = True Then
            If MapData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_No_Mode Then
                f = ShapeFileOut_prj(filename, MapData.Map.Zahyo)
            End If
        End If
        If f = False Then
            Return False
        Else
            Return True
        End If
    End Function


    Private Shared Function ShapeFileOut_prj(ByVal filename As String, ByVal MapZahyo As clsMapData.Zahyo_info) As Boolean
        Dim XY_Genten(19) As XY_Genten_Info
        'prjファイル出力

        '平面直角座標系原点
        XY_Genten(1).CenterB = 33
        XY_Genten(1).CenterL = 129.5
        XY_Genten(2).CenterB = 33
        XY_Genten(2).CenterL = 131
        XY_Genten(3).CenterB = 36
        XY_Genten(3).CenterL = 132 + 10 / 60
        XY_Genten(4).CenterB = 33
        XY_Genten(4).CenterL = 133.5
        XY_Genten(5).CenterB = 36
        XY_Genten(5).CenterL = 134 + 20 / 60
        XY_Genten(6).CenterB = 36
        XY_Genten(6).CenterL = 136
        XY_Genten(7).CenterB = 36
        XY_Genten(7).CenterL = 137 + 10 / 60
        XY_Genten(8).CenterB = 36
        XY_Genten(8).CenterL = 138.5
        XY_Genten(9).CenterB = 36
        XY_Genten(9).CenterL = 139 + 50 / 60
        XY_Genten(10).CenterB = 40
        XY_Genten(10).CenterL = 140 + 50 / 60
        XY_Genten(11).CenterB = 44
        XY_Genten(11).CenterL = 140 + 15 / 60
        XY_Genten(12).CenterB = 44
        XY_Genten(12).CenterL = 142 + 15 / 60
        XY_Genten(13).CenterB = 44
        XY_Genten(13).CenterL = 144 + 15 / 60
        XY_Genten(14).CenterB = 26
        XY_Genten(14).CenterL = 142
        XY_Genten(15).CenterB = 26
        XY_Genten(15).CenterL = 127.5
        XY_Genten(16).CenterB = 26
        XY_Genten(16).CenterL = 124
        XY_Genten(17).CenterB = 26
        XY_Genten(17).CenterL = 131
        XY_Genten(18).CenterB = 20
        XY_Genten(18).CenterL = 136
        XY_Genten(19).CenterB = 26
        XY_Genten(19).CenterL = 154

        Dim OutSTR As String
        With MapZahyo
            Select Case .Mode
                Case enmZahyo_mode_info.Zahyo_Ido_Keido
                    Select Case .System
                        Case enmZahyo_System_Info.Zahyo_System_tokyo
                            OutSTR = "GEOGCS[*GCS_Tokyo*,DATUM[*D_Tokyo*,SPHEROID[*Bessel_1841*,6377397.155,299.1528128]],PRIMEM[*Greenwich*,0.0],UNIT[*Degree*,0.0174532925199433]]"
                        Case enmZahyo_System_Info.Zahyo_System_World
                            OutSTR = "GEOGCS[*GCS_JGD_2000*,DATUM[*D_JGD_2000*,SPHEROID[*GRS_1980*,6378137.0,298.257222101]],PRIMEM[*Greenwich*,0.0],UNIT[*Degree*,0.0174532925199433]]"
                    End Select
                Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                    Dim KNum As Integer = .HeimenTyokkaku_KEI_Number
                    Select Case .System
                        Case enmZahyo_System_Info.Zahyo_System_tokyo
                            OutSTR = "PROJCS[*Japan_Zone_" & CStr(KNum) & "*,GEOGCS[*GCS_Tokyo*,DATUM[*D_Tokyo*,SPHEROID[*Bessel_1841*,6377397.155,299.1528128]],PRIMEM[*Greenwich*,0.0],UNIT[*Degree*,0.0174532925199433]],PROJECTION[*Transverse_Mercator*],PARAMETER[*False_Easting*,0.0],PARAMETER[*False_Northing*,0.0],PARAMETER[*Central_Meridian*," & CStr(XY_Genten(KNum).CenterL) & "],PARAMETER[*Scale_Factor*,0.9999],PARAMETER[*Latitude_Of_Origin*," & CStr(XY_Genten(.HeimenTyokkaku_KEI_Number).CenterB) & "],UNIT[*Meter*,1.0]]"
                        Case enmZahyo_System_Info.Zahyo_System_World
                            OutSTR = "PROJCS[*JGD_2000_Japan_Zone_" & CStr(KNum) & "*,GEOGCS[*GCS_JGD_2000*,DATUM[*D_JGD_2000*,SPHEROID[*GRS_1980*,6378137.0,298.257222101]],PRIMEM[*Greenwich*,0.0],UNIT[*Degree*,0.0174532925199433]],PROJECTION[*Transverse_Mercator*],PARAMETER[*False_Easting*,0.0],PARAMETER[*False_Northing*,0.0],PARAMETER[*Central_Meridian*," & CStr(XY_Genten(KNum).CenterL) & "],PARAMETER[*Scale_Factor*,0.9999],PARAMETER[*Latitude_Of_Origin*," & CStr(XY_Genten(.HeimenTyokkaku_KEI_Number).CenterB) & "],UNIT[*Meter*,1.0]]"
                    End Select
            End Select
        End With
        OutSTR = Replace(OutSTR, "*", Chr(&H22))
        Dim filename_prj As String = clsGeneric.ReplaceFileExtention(filename, "prj")
        Dim sw As New System.IO.StreamWriter(filename_prj, False, System.Text.Encoding.GetEncoding("shift_jis"))
        sw.WriteLine(OutSTR)
        sw.Close()
        Return True
    End Function
    Private Shared Function ShapeFileOut_Polygon(ByRef MapData As clsMapData, ByVal filename As String, ByVal Objn As Integer, ByRef Objs() As Integer, ByVal Time As strYMD) As Boolean
        'Polygon形状シェープファイル出力

        Dim Obj_Index() As Integer, Obj_Length() As Integer, Each_Points() As Integer

        Dim Bounding_Obj_box() As RectangleF
        Dim Bounding_box As RectangleF

        Dim Flen As Integer


        Dim ShapeType As Integer = 5
        Call Get_Shape_Line_Polygon_Bounding_etc(MapData, ShapeType, Objn, Time, Objs, Flen, Obj_Index, Obj_Length, Each_Points, Bounding_Obj_box, Bounding_box)

        'shp
        Dim filenumber As Integer = FreeFile()
        Try
            FileOpen(filenumber, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.LockReadWrite)
        Catch ex As Exception
            Return False
        End Try

        Call Put_HeaderPart(Flen, ShapeType, Bounding_box, filenumber)
        For i As Integer = 0 To Objn - 1
            Dim Arrange_LineCode(,) As Integer, Fringe() As clsMapData.Fringe_Line_Info
            Dim Pon As Integer = MapData.Boundary_Arrange(MapData.MPObj(Objs(i)), Time, Arrange_LineCode, Fringe)
            If Pon = -1 Then
                Dim Oname As String()
                MapData.Get_Enable_ObjectName(MapData.MPObj(Objs(i)), Time, True, Oname)
                MsgBox(Join(Oname, "/") & "は面形状になっていません。", MsgBoxStyle.Exclamation)
                FileClose(filenumber)
                Return False
            End If
            Dim In_Out(,) As Byte, TotalInOut() As Integer
            In_Out = MapData.Object_Polygon_InOut(Pon, Arrange_LineCode, Fringe, TotalInOut)
            Dim pxy(Each_Points(i) - 1) As PointF

            Dim PointIndex(Pon - 1) As Integer
            Dim PLN As Integer = 0
            For j As Integer = 0 To Pon - 1
                PointIndex(j) = PLN
                Dim poxy() As PointF
                Dim PN As Integer = MapData.Get_Object_Polygon_Coords(j, 0, Arrange_LineCode, Fringe, poxy, True, 1)
                If PN >= 2 Then
                    Dim D As Integer = spatial.Get_Polygon_Direction(PN, poxy)
                    If (TotalInOut(j) Mod 2 = 1 And D = 1) Or (TotalInOut(j) Mod 2 = 0 And D = -1) Then
                        '中抜けポリゴンで時計回り、そうでなくて反時計回りの場合は座標を入れ替える
                        For k As Integer = 0 To PN - 1
                            pxy(k + PLN) = poxy(PN - 1 - k)
                        Next
                    Else
                        For k As Integer = 0 To PN - 1
                            pxy(k + PLN) = poxy(k)
                        Next
                    End If
                    PLN += PN
                End If
            Next

            Call Put_Poly_Shape_XY(MapData.Map.Zahyo, ShapeType, i + 1, Pon, PLN, PointIndex, pxy, Bounding_Obj_box(i), filenumber)

        Next

        FileClose(filenumber)

        Dim filename_shx As String = clsGeneric.ReplaceFileExtention(filename, "shx")  'shx
        If SHX_Out(filename_shx, Objn, ShapeType, Bounding_box, Obj_Index, Obj_Length) = False Then
            Return False
        End If


        Return True
    End Function
    Private Shared Sub Put_Poly_Shape_XY(ByRef Zahyo As clsMapData.Zahyo_info, ByVal ShapeType As Integer, ByVal ObID As Integer, ByVal Pon As Integer,
                                         ByVal PLN As Integer, PointIndex() As Integer, pxy() As PointF, Bounding_Obj_box As RectangleF, ByVal FileNum As Integer)


        Call Put_Big_integer(FileNum, ObID)
        Call Put_Big_integer(FileNum, CLng(2 + 4 * 4 + 2 + 2 + 2 * Pon + 4 * 2 * PLN))
        FilePut(FileNum, ShapeType)
        Call Put_Double_XY_from_Single_XY_Box(Bounding_Obj_box, FileNum)
        FilePut(FileNum, Pon)
        FilePut(FileNum, PLN)
        For j As Integer = 0 To Pon - 1
            FilePut(FileNum, PointIndex(j))
        Next
        For j As Integer = 0 To PLN - 1
            Dim XY As PointF = spatial.Get_Reverse_XY(pxy(j), Zahyo)
            Call Put_Double_XY_from_Single_XY(XY, FileNum)
        Next

    End Sub
    Private Shared Sub Get_Shape_Line_Polygon_Bounding_etc(ByRef MapData As clsMapData, ByVal ShapeType As Integer,
                            ByVal Objn As Integer, ByVal Time As strYMD, ByRef Objs() As Integer,
                            ByRef Flen As Integer, ByRef Obj_Index() As Integer, ByRef Obj_Length() As Integer,
                            ByRef Each_Points() As Integer, ByRef Bounding_Obj_box() As RectangleF, ByRef Bounding_box As RectangleF)
        'ポリゴンとポリライン出力の際に、
        'バウンディングボックス、インデックスファイル要素等を求める


        ReDim Bounding_Obj_box(Objn - 1)
        ReDim Obj_Index(Objn - 1)
        ReDim Obj_Length(Objn - 1)
        ReDim Each_Points(Objn - 1)
        Dim Bounding_temp_box As RectangleF

        Flen = 50
        For i As Integer = 0 To Objn - 1
            Dim Parts As Integer
            Obj_Index(i) = Flen
            Dim L_Code() As Integer
            Dim NL As Integer
            Select Case ShapeType
                Case 3 'PolyLine
                    Dim ELine() As clsMapData.EnableMPLine_Data
                    NL = MapData.Get_EnableMPLine(ELine, MapData.MPObj(Objs(i)), Time)
                    ReDim L_Code(NL - 1)
                    For j = 0 To NL - 1
                        L_Code(j) = ELine(j).LineCode
                    Next
                    Parts = NL
                Case 5  'Polygon
                    Dim Arrange_LineCode(,) As Integer, Fringe() As clsMapData.Fringe_Line_Info
                    Parts = MapData.Boundary_Arrange(MapData.MPObj(Objs(i)), Time, Arrange_LineCode, Fringe)
                    NL = UBound(Fringe) + 1
                    ReDim L_Code(NL - 1)
                    For j As Integer = 0 To NL - 1
                        L_Code(j) = Fringe(j).code
                    Next
            End Select

            Dim PLN As Integer
            Dim Bounding_temp_obj_box As RectangleF

            With MapData.MPLine(L_Code(0))
                Bounding_temp_obj_box = .Circumscribed_Rectangle
                PLN = .NumOfPoint
            End With
            For j As Integer = 1 To NL - 1
                With MapData.MPLine(L_Code(j))
                    Bounding_temp_obj_box = spatial.Get_Circumscribed_Rectangle(.Circumscribed_Rectangle, Bounding_temp_obj_box)
                    PLN += .NumOfPoint
                End With
            Next
            If i = 0 Then
                Bounding_temp_box = Bounding_temp_obj_box
            Else
                Bounding_temp_box = spatial.Get_Circumscribed_Rectangle(Bounding_temp_obj_box, Bounding_temp_box)
            End If
            Bounding_Obj_box(i) = spatial.Get_Reverse_Rect(Bounding_temp_obj_box, MapData.Map.Zahyo)
            Each_Points(i) = PLN
            Obj_Length(i) = (2 + 4 * 4 + 2 + 2 + 2 * Parts + 4 * 2 * PLN)
            Flen += (2 + 2) + Obj_Length(i)
        Next
        Bounding_box = spatial.Get_Reverse_Rect(Bounding_temp_box, MapData.Map.Zahyo)

    End Sub
    Private Shared Function ShapeFileOut_Line(ByRef MapData As clsMapData, ByVal filename As String, ByVal Objn As Integer, ByRef Objs() As Integer, ByVal Time As strYMD) As Boolean
        'PolyLine形状シェープファイル出力


        Dim Bounding_Obj_box() As RectangleF
        Dim Bounding_box As RectangleF

        Dim Flen As Integer


        Dim ShapeType As Integer = 3

        Dim Obj_Index() As Integer, Obj_Length() As Integer, Each_Points() As Integer
        Call Get_Shape_Line_Polygon_Bounding_etc(MapData, ShapeType, Objn, Time, Objs, Flen, Obj_Index, Obj_Length, Each_Points, Bounding_Obj_box, Bounding_box)

        'SHP
        Dim filenumber As Integer = FreeFile()
        Try
            FileOpen(filenumber, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.LockReadWrite)
        Catch ex As Exception
            Return False
        End Try

        Call Put_HeaderPart(Flen, ShapeType, Bounding_box, filenumber)
        For i As Integer = 0 To Objn - 1
            Dim ELine() As clsMapData.EnableMPLine_Data
            Dim NL As Integer = MapData.Get_EnableMPLine(ELine, MapData.MPObj(Objs(i)), Time)
            Dim PointIndex(NL - 1) As Integer
            Dim pxy(Each_Points(i) - 1) As PointF
            Dim PLN As Integer = 0
            For j As Integer = 0 To NL - 1
                PointIndex(j) = PLN
                Dim poxy() As PointF
                Dim PN As Integer = MapData.Get_Coords_by_LineCode(ELine(j).LineCode, 0, 1, poxy, 1)
                For k = 0 To PN - 1
                    pxy(k + PLN) = poxy(k)
                Next
                PLN += PN
            Next

            Call Put_Poly_Shape_XY(MapData.Map.Zahyo, ShapeType, i + 1, NL, PLN, PointIndex, pxy, Bounding_Obj_box(i), 1)

        Next

        FileClose(filenumber)

        Dim filename_shx As String = clsGeneric.ReplaceFileExtention(filename, "shx")  'shx
        If SHX_Out(filename_shx, Objn, ShapeType, Bounding_box, Obj_Index, Obj_Length) = False Then
            Return False
        End If


        Return True
    End Function

    Private Shared Function ShapeFileOut_Point(ByRef MapData As clsMapData, ByVal filename As String, ByVal Objn As Integer, ByRef Objs() As Integer, ByVal Time As strYMD) As Boolean
        '点形状シェープファイル出力

        Dim XY(Objn - 1) As PointF
        For i As Integer = 0 To Objn - 1
            Dim CP As PointF
            MapData.Get_Enable_CenterP(CP.X, CP.Y, MapData.MPObj(Objs(i)), Time)
            XY(i) = CP
        Next
        Dim f As Boolean = shpPointOut(MapData.Map.Zahyo, filename, Objn, XY)
        Return True
    End Function
    Private Shared Function shpPointOut(ByVal Zahyo As clsMapData.Zahyo_info, ByVal filename As String, ByVal Objn As Integer, ByRef XY() As PointF) As Boolean

        Dim ShapeType As Integer = 1
        Dim Flen As Integer = Objn * (2 + 2 + 2 + 4 + 4) + 50
        Dim Bounding_box As RectangleF
        For i As Integer = 0 To Objn - 1
            XY(i) = spatial.Get_Reverse_XY(XY(i), Zahyo)
            If i = 0 Then
                Bounding_box = New RectangleF(XY(0), New Size(0, 0))
            Else
                Bounding_box = spatial.Get_Circumscribed_Rectangle(XY(i), Bounding_box)
            End If
        Next

        'shp
        Dim filenumber As Integer = FreeFile()
        Try
            FileOpen(filenumber, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.LockReadWrite)
        Catch ex As Exception
            Return False
        End Try
        Call Put_HeaderPart(Flen, ShapeType, Bounding_box, filenumber)

        For i As Integer = 0 To Objn - 1
            Call Put_Big_integer(filenumber, CLng(i + 1))
            Call Put_Big_integer(filenumber, CLng(2 + 4 + 4))
            FilePut(filenumber, ShapeType)
            Call Put_Double_XY_from_Single_XY(XY(i), filenumber)
        Next
        FileClose(filenumber)

        Dim filename_shx As String = clsGeneric.ReplaceFileExtention(filename, "shx")    'shx
        Dim Obj_Index(Objn - 1) As Integer
        Dim Obj_Length(Objn - 1) As Integer
        For i As Integer = 0 To Objn - 1
            Obj_Index(i) = 50 + i * 14
            Obj_Length(i) = 10
        Next
        If SHX_Out(filename_shx, Objn, ShapeType, Bounding_box, Obj_Index, Obj_Length) = False Then
            Return False
        End If


        Return True
    End Function

    Private Shared Sub Put_Double_XY_from_Single_XY(XY As PointF, ByVal FileNum As Integer)
        Dim x2 As Single, y2 As Single
        '倍精度にして保存
        FilePut(FileNum, CDbl(XY.X))
        FilePut(FileNum, CDbl(XY.Y))
    End Sub
    Private Shared Sub Put_Double_XY_from_Single_XY_Box(Box As RectangleF, ByVal FileNum As Integer)

        '倍精度にして保存
        With Box
            FilePut(FileNum, CDbl(.Left))
            FilePut(FileNum, CDbl(.Top))
            FilePut(FileNum, CDbl(.Right))
            FilePut(FileNum, CDbl(.Bottom))
        End With
    End Sub
    Private Shared Function SHX_Out(ByVal filename As String, ByVal Objn As Integer, ByVal ShapeType As Integer, ByRef Bounding_box As RectangleF, ByRef Obj_Index() As Integer, ByRef Obj_Length() As Integer) As Boolean
        'SHX インデックスファイル保存

        Dim fnum As Integer = FreeFile()
        Try
            FileOpen(fnum, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.LockReadWrite)
        Catch ex As Exception
            Return False
        End Try

        Dim Flen As Integer = 4 * Objn + 50
        Call Put_HeaderPart(Flen, ShapeType, Bounding_box, fnum)
        For i As Integer = 0 To Objn - 1
            Call Put_Big_integer(fnum, Obj_Index(i))
            Call Put_Big_integer(fnum, Obj_Length(i))
        Next
        FileClose(fnum)
        Return True

    End Function
    Private Shared Sub DBF_Out(ByVal filename As String, ByVal Objn As Integer,
                    ByVal Data_Item_n As Integer, ByRef Data_Title() As String, ByRef Data_STR_F() As Boolean,
                    ByRef StrData(,) As String, ByVal encodenumber As Integer)

        Dim DBFFile As New clsDBF

        DBFFile.Init(Data_Item_n, Objn)
        For i As Integer = 0 To Data_Item_n - 1
            DBFFile.FieldStringData_Flag(i) = Data_STR_F(i)
            DBFFile.FieldName(i) = Data_Title(i)
        Next
        DBFFile.DataValueSet_Allay(StrData)
        DBFFile.SaveDBF(filename, encodenumber)

        DBFFile = Nothing

    End Sub
    Private Shared Sub Put_HeaderPart(ByVal Flen As Integer, ByVal ShapeType As Integer, Bounding_box As RectangleF, ByVal FileNum As Integer)
        'Shapeのヘッダ部分




        Dim V As Integer = 1000
        Call Put_Big_integer(FileNum, 9994)
        Call Put_Big_integer(FileNum, 0)
        Call Put_Big_integer(FileNum, 0)
        Call Put_Big_integer(FileNum, 0)
        Call Put_Big_integer(FileNum, 0)
        Call Put_Big_integer(FileNum, 0)
        Call Put_Big_integer(FileNum, Flen)
        FilePut(FileNum, V)
        FilePut(FileNum, ShapeType)
        Call Put_Double_XY_from_Single_XY_Box(Bounding_box, FileNum)
        Dim db As Double = 0.0#
        FilePut(FileNum, db)
        FilePut(FileNum, db)
        FilePut(FileNum, db)
        FilePut(FileNum, db)

    End Sub
    Private Shared Sub Put_Big_integer(ByVal Filenumber As Integer, ByVal Num As Integer)


        Dim tp As String = Right("00000000" & Hex(Num), 8)
        For i As Integer = 0 To 3
            Dim Bt As Byte = Val("&H" & Mid(tp, i * 2 + 1, 2))
            FilePut(Filenumber, Bt)
        Next

    End Sub
End Class

Public Class clsDBF
    Private Structure Field_Info
        Public Name As String
        Public StringData_Flag As Boolean
        Public Length As Byte
        Public PointLen As Byte
    End Structure
    Private Structure DBF_Info
        Public VerData As Byte
        Public RecordNumber As Integer
        Public FieldNumber As Integer
        Public Year As Byte
        Public Month As Byte
        Public dbfDate As Byte
        Public Header_Byte As Short
        Public Record_Byte As Short
    End Structure
    Dim DataSet As DBF_Info
    Dim FieldDT() As Field_Info
    Dim DataStr(,) As String
    Public Sub Init(ByVal FieldNum As Integer, RecordNum As Integer)
        DataSet.FieldNumber = FieldNum
        DataSet.RecordNumber = RecordNum

        ReDim FieldDT(FieldNum - 1)
        ReDim DataStr(FieldNum - 1, RecordNum - 1)
    End Sub
    Public Property FieldNumber() As Integer
        Get
            Return DataSet.FieldNumber
        End Get
        Set(value As Integer)

        End Set
    End Property

    Public Property RecordNumber() As Integer
        Get
            Return DataSet.RecordNumber
        End Get
        Set(value As Integer)

        End Set
    End Property

    Public Property FieldName(ByVal Num As Integer) As String
        Get
            Return FieldDT(Num).Name
        End Get
        Set(value As String)
            FieldDT(Num).Name = value
        End Set
    End Property
    Public Property FieldStringData_Flag(ByVal Num As Integer) As Boolean
        Get
            Return FieldDT(Num).StringData_Flag
        End Get
        Set(value As Boolean)
            FieldDT(Num).StringData_Flag = value
        End Set
    End Property
    Public Function DataValue(ByVal FieldNum As Integer, RecordNum As Integer) As String
        Return DataStr(FieldNum, RecordNum)

    End Function

    Public Function DataValue_Allay() As String(,)
        Return DataStr

    End Function
    Public Sub DataValueSet(ByVal FieldNum As Integer, RecordNum As Integer, ByRef DataV As String)
        DataStr(FieldNum, RecordNum) = DataV
    End Sub
    Public Sub DataValueSet_Allay(ByRef DataV(,) As String)
        DataStr = DataV.Clone
    End Sub

    Public Function LoadDBF_Binary(ByRef FilePath As String, ByVal encodenumber As Integer, ByRef ProgressLabel As KTGISUserControl.KTGISProgressLabel) As Boolean
        Dim bs() As Byte
        If clsGeneric.Get_BinaryFile_asByte(FilePath, bs) = False Then
            Return False
        End If
        ProgressLabel.Visible = True
        Dim pos As Integer

        '最終更新日
        With DataSet
            .VerData = bs(0) 'Ver=3  = VerData And 7 
            .Year = bs(1) 'Year-1900
            .Month = bs(2)
            .dbfDate = bs(3)
            .RecordNumber = BitConverter.ToInt32(bs, 4)
            .Header_Byte = BitConverter.ToInt16(bs, 8)
            .Record_Byte = BitConverter.ToInt16(bs, 10)  'sum(FieldDT().Length)+1
            .FieldNumber = (.Header_Byte - 33) \ 32
        End With
        pos = 12
        pos += 4
        pos += 12
        pos += 4

        'フィールド記述子配列読み込み
        ReDim FieldDT(DataSet.FieldNumber - 1)

        For i As Integer = 0 To DataSet.FieldNumber - 1
            With FieldDT(i)
                .Name = Trim(Get_WCharData_Binary(bs, pos, 11, encodenumber))
                .Name = Replace(.Name, Chr(0), "_")
                pos += 11
                Dim fieldType As Char = Chr(bs(pos))
                Select Case fieldType
                    Case "C", "D", "M", "L"
                        .StringData_Flag = True
                    Case "F", "N"
                        .StringData_Flag = False
                End Select
                pos += 1
                pos += 4
                .Length = bs(pos)
                .PointLen = bs(pos + 1)
                pos += 2
                pos += 3
                pos += 10
                pos += 1
            End With
        Next
        pos += 1 '&HD
        ProgressLabel.SetValue(DataSet.FieldNumber)

        'データベースレコード読み込み
        ReDim DataStr(DataSet.FieldNumber - 1, DataSet.RecordNumber - 1)
        For i As Integer = 0 To DataSet.RecordNumber - 1
            If i Mod 10 = 0 Then
                ProgressLabel.SetValue(i)
            End If
            pos += 1 '削除されていなければ半角空白(&h20)、削除されていればアスタリスク(&h2A)
            For j As Integer = 0 To DataSet.FieldNumber - 1
                DataStr(j, i) = Trim(Get_WCharData_Binary(bs, pos, FieldDT(j).Length, encodenumber))
                pos += FieldDT(j).Length
            Next
        Next

        ProgressLabel.Visible = False
        Return True
    End Function
 
    Private Function Get_WCharData_Binary(ByRef bt() As Byte, ByVal Position As Integer, ByVal GetLen As Integer, ByVal encodenumber As Integer) As String
        '指定された文字コードでバイナリデータを文字列に変換して返す

        Dim ubt(GetLen - 1) As Byte
        For i As Integer = 0 To GetLen - 1
            ubt(i) = bt(i + Position)
        Next
        Dim str = System.Text.Encoding.GetEncoding(encodenumber).GetString(ubt)
        Dim retstr As String = ""
        For i As Integer = str.Length To 1 Step -1
            If Asc(Mid(str, i)) <> 0 Then
                retstr = Mid(str, 1, i)
                Exit For
            End If
        Next
        Return retstr
    End Function


    ''' <summary>
    ''' dbfファイル出力
    ''' </summary>
    ''' <param name="filename">ファイル名</param>
    ''' <param name="encodenumber">dbfデータの文字コード番号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveDBF(ByRef FilePath As String, ByVal encodenumber As Integer) As Boolean

        Dim BData As Byte

        Dim BData0 As Byte = 0
        Dim filenum As Integer = FreeFile()
        Try
            FileOpen(filenum, FilePath, OpenMode.Binary, OpenAccess.Write, OpenShare.LockReadWrite)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Call Check_FieldLength(encodenumber)

        BData = 3
        FilePut(filenum, BData)
        With DataSet
            .Year = Today.Year - 1900
            .Month = Today.Month
            .dbfDate = Today.Day
            .Header_Byte = .FieldNumber * 32 + 33
            .Record_Byte = 0
            For i As Integer = 0 To .FieldNumber - 1
                .Record_Byte = .Record_Byte + FieldDT(i).Length
            Next
            .Record_Byte = .Record_Byte + 1
            FilePut(filenum, .Year)
            FilePut(filenum, .Month)
            FilePut(filenum, .dbfDate)

            FilePut(filenum, .RecordNumber)
            FilePut(filenum, .Header_Byte)
            FilePut(filenum, .Record_Byte)
        End With
        For i As Integer = 12 To 31
            FilePut(filenum, BData0)
        Next

        'フィールド記述子

        For i As Integer = 0 To DataSet.FieldNumber - 1
            With FieldDT(i)
                Call Put_Strings(filenum, .Name, 11, Chr(0), encodenumber)
                If .StringData_Flag = True Then
                    BData = Asc("C")
                Else
                    BData = Asc("N")
                End If
                FilePut(filenum, BData)
                FilePut(filenum, BData0)
                FilePut(filenum, BData0)
                FilePut(filenum, BData0)
                FilePut(filenum, BData0)

                FilePut(filenum, .Length)
                FilePut(filenum, .PointLen) '小数点以下の桁数

                For j As Integer = 18 To 30
                    FilePut(filenum, BData0)
                Next
                FilePut(filenum, BData0)
            End With
        Next
        BData = &HD
        FilePut(filenum, BData)  '&HD
        'データベースレコード
        For i As Integer = 0 To DataSet.RecordNumber - 1
            BData = &H20
            FilePut(filenum, BData)
            For j As Integer = 0 To DataSet.FieldNumber - 1
                Dim DT As String = Conv_ValStr(DataStr(j, i), j)
                Call Put_Strings(filenum, DT, FieldDT(j).Length, " ", encodenumber)
            Next
        Next
        BData = &H1A
        FilePut(filenum, BData) 'ターミネータ　&h1A
        FileClose(filenum)
        Return True

    End Function

    Private Sub Put_Strings(ByVal Filenumber As Integer, ByRef DT As String, ByVal MaxLength As Integer, ByRef NullSTR As String, ByVal encodenumber As Integer)

        Dim bytesData As Byte() = System.Text.Encoding.GetEncoding(encodenumber).GetBytes(DT)
        Dim bn As Integer = bytesData.Length
        ReDim Preserve bytesData(MaxLength - 1)
        For i As Integer = bn To MaxLength - 1
            bytesData(i) = Asc(NullSTR)
        Next
        For i As Integer = 0 To MaxLength - 1
            FilePut(Filenumber, bytesData(i))
        Next


    End Sub

    Private Function Conv_ValStr(ByVal DataStr As String, ByVal FieldNum As Integer) As String



        With FieldDT(FieldNum)
            If .StringData_Flag = True Then
                Return DataStr
            Else
                Dim DV As Double = Val(DataStr)
                Dim a As String = FormatNumber(DV, .PointLen, vbTrue, vbFalse, vbFalse)
                Conv_ValStr = New String(" ", .Length - Len(a)) + a
            End If
        End With
    End Function
    Private Sub Check_FieldLength(ByVal encodenumber As Integer)


        Dim Minv As Double, V As Double
        Dim DTCode As String

        For i As Integer = 0 To DataSet.FieldNumber - 1
            If FieldDT(i).StringData_Flag = True Then
                '文字コードによるフィールドのバイト数チェックする
                Dim flen As Integer = 0
                For j As Integer = 0 To DataSet.RecordNumber - 1
                    Dim bytesData As Byte() = System.Text.Encoding.GetEncoding(encodenumber).GetBytes(DataStr(i, j))
                    flen = Math.Max(flen, bytesData.Length)
                Next
                If flen = 0 Then
                    flen = 1
                End If
                FieldDT(i).Length = flen
                FieldDT(i).PointLen = 0
            Else
                Minv = Val(DataStr(i, 0))
                Dim fa As strDecimalPointNumber = clsGeneric.Get_Figure_Arrange(Minv)
                For j As Integer = 1 To DataSet.RecordNumber - 1
                    V = Val(DataStr(i, j))
                    Dim fa2 As strDecimalPointNumber = clsGeneric.Get_Figure_Arrange(V)
                    fa.Left_Of_Decimal_Point = Math.Max(fa.Left_Of_Decimal_Point, fa2.Left_Of_Decimal_Point)
                    fa.Right_Of_Decimal_Point = Math.Max(fa.Right_Of_Decimal_Point, fa2.Right_Of_Decimal_Point)
                    If Minv > V Then
                        Minv = V
                    End If
                Next
                If fa.Left_Of_Decimal_Point = 0 Then
                    fa.Left_Of_Decimal_Point = 1
                End If
                If Minv < 0 Then
                    fa.Left_Of_Decimal_Point += 1
                End If
                If fa.Right_Of_Decimal_Point > 0 Then
                    fa.Left_Of_Decimal_Point += 1
                End If
                FieldDT(i).Length = fa.Right_Of_Decimal_Point + fa.Left_Of_Decimal_Point
                FieldDT(i).PointLen = fa.Right_Of_Decimal_Point
            End If
        Next
    End Sub

End Class

