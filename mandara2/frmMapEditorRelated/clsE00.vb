Public Class clsE00
    Public Structure E00file_info
        Public FileName As String
        Public FullPath As String
        Public Zahyo As clsMapData.Zahyo_info
    End Structure
    Private Structure pat_data_info
        Public Name As String
        Public StartP As Long
        Public len As Long
    End Structure

    Public Shared Function Get_e00File(ByVal filename As String, ByVal ObjNameHeader As String,
                                   ByVal MapZahyo As clsMapData.Zahyo_info, ByRef _MapData As clsMapData,
                                  ByRef ProgressLabel As KTGISUserControl.KTGISProgressLabel) As Boolean
        Dim MapData As clsMapData
        MapData = New clsMapData()
        MapData.Map.Zahyo = MapZahyo
        MapData.NoDataFlag = False
        With MapData
            With .Map
                .FileName = System.IO.Path.GetFileName(filename)
                .FullPath = ""
            End With
            ReDim .MPObj(100)
            ReDim .MPLine(0)
        End With
        Dim f As Boolean = Get_e00File(filename, ObjNameHeader, MapData, ProgressLabel)
        If f = True Then
            MapData.NoDataFlag = False
            Zahyo_convert(MapData)
            _MapData = MapData
        End If
        Return f
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
    Private Shared Function Get_e00File(ByVal filename As String, ByVal ObjNameHeader As String, ByRef MapData As clsMapData,
                                        ByRef ProgressLabel As KTGISUserControl.KTGISProgressLabel) As Boolean


        Dim PAT_data_n As Integer
        Dim PAT_Object_n As Integer
        Dim PAT_Data() As pat_data_info

        Dim attData(,) As String
        Dim TTL() As String

        Dim ShapeS As enmShape

        Dim FileOnName As String = System.IO.Path.GetFileName(filename)

        Dim PAL_F As Boolean = False
        Dim LAB_F As Boolean = False
        Dim ARC_F As Boolean = False
        Dim CNT_F As Boolean = False
        Dim fileData As List(Of String)
        Dim f As Boolean = e00_fileRead(filename, fileData)
        If f = False Then
            Return False
        End If

        Dim maxn As Integer = fileData.Count

        ProgressLabel.Visible = True
        ProgressLabel.Start(maxn, "読み込み中", False)

        Dim filePoint As Integer = 0
        Dim Lab_Points As New List(Of PointF)
        Do While filePoint < maxn
            ProgressLabel.SetValue(filePoint)
            Dim wsh() As String = clsGeneric.String_Cut(fileData(filePoint), " ")
            filePoint += 1
            If wsh Is Nothing = False Then
                Select Case Microsoft.VisualBasic.Right(wsh(0), 4)
                    Case ".PAT", ".AAT"
                        wsh(0) = Microsoft.VisualBasic.Right(wsh(0), 4)
                End Select
                Select Case wsh(0)
                    Case "LAB"
                        Dim Precision As Integer = Val(wsh(1))
                        LAB_F = True
                        Do
                            Dim tx As String = fileData(filePoint)
                            filePoint += 1
                            If Val(Mid(tx, 1, 10)) = "-1" Then
                                Exit Do
                            Else
                                Dim P As PointF
                                With P
                                    Select Case Precision
                                        Case 2
                                            .X = Val(Mid(tx, 21, 14))
                                            .Y = Val(Mid(tx, 35, 14))
                                        Case 3
                                            .X = Val(Mid(tx, 21, 21))
                                            .Y = Val(Mid(tx, 42, 21))
                                    End Select
                                End With
                                Lab_Points.Add(P)
                                Select Case Precision
                                    Case 2
                                        filePoint += 1
                                    Case 3
                                        filePoint += 2
                                End Select
                            End If
                        Loop
                    Case "ARC"
                        Dim Precision As Integer = Val(wsh(1))
                        ARC_F = True
                        Do
                            Dim ws() As String = clsGeneric.String_Cut(fileData(filePoint), " ")
                            filePoint += 1
                            If ws(0) = "-1" Then
                                Exit Do
                            Else
                                Dim NumPoints As Integer = Val(ws(6))
                                Dim a2 As String = ""
                                Select Case Precision
                                    Case 2
                                        For i As Integer = 1 To (NumPoints + (NumPoints Mod 2)) \ 2
                                            a2 += RTrim(fileData(filePoint))
                                            filePoint += 1
                                        Next
                                    Case 3
                                        For i As Integer = 1 To NumPoints
                                            a2 += RTrim(fileData(filePoint))
                                            filePoint += 1
                                        Next
                                End Select
                                With MapData
                                    If UBound(MapData.MPLine) < .Map.ALIN Then
                                        ReDim Preserve MapData.MPLine(.Map.ALIN * 2)
                                    End If
                                    .MPLine(.Map.ALIN) = .Init_One_Line(0)
                                    With .MPLine(.Map.ALIN)
                                        .NumOfPoint = NumPoints
                                        .LineTimeSTC(0).Kind = 0
                                        ReDim .PointSTC(NumPoints - 1)
                                        Select Case Precision
                                            Case 2
                                                For i As Integer = 0 To NumPoints - 1
                                                    With .PointSTC(i)
                                                        .X = Val(Mid(a2, i * 28 + 1, 14))
                                                        .Y = Val(Mid(a2, i * 28 + 14 + 1, 14))
                                                    End With
                                                Next
                                            Case 3
                                                For i As Integer = 0 To NumPoints - 1
                                                    With .PointSTC(i)
                                                        .X = CSng(Val(Mid(a2, i * 42 + 1, 21)))
                                                        .Y = CSng(Val(Mid(a2, i * 42 + 22, 21)))
                                                    End With
                                                Next
                                        End Select
                                    End With
                                    .Map.ALIN += 1
                                End With
                            End If
                        Loop
                    Case "CNT" 'ポリゴンの重心
                        '取得しているが、実際は使用していない

                        CNT_F = True
                        Dim CNT_n As Integer = 0
                        Dim Precision As Integer = wsh(1)
                        Dim PolygonCentroidCoordinates(100) As PointF
                        Dim PolygonCentroidCoordinates_f(100) As Boolean
                        Do
                            Dim tx As String = fileData(filePoint)
                            filePoint += 1
                            Dim NumPoints As Integer = Val(Mid(tx, 1, 10))
                            If NumPoints = "-1" Then
                                Exit Do
                            ElseIf NumPoints >= 1 Then
                                Dim cp As PointF
                                Select Case Precision
                                    Case 2
                                        cp.X = Val(Mid(tx, 11, 14))
                                        cp.Y = Val(Mid(tx, 25, 14))
                                    Case 3
                                        cp.X = Val(Mid(tx, 11, 21))
                                        cp.Y = Val(Mid(tx, 33, 21))
                                End Select
                                Dim a2 As String = ""
                                For i As Integer = 1 To (NumPoints \ 8) + 1
                                    Dim a3 As String = fileData(filePoint)
                                    filePoint += 1
                                    a2 += a3
                                Next
                                For i As Integer = 0 To NumPoints - 1
                                    Dim j As Integer = Val(Mid(a2, i * 10 + 1, 10))
                                    CNT_n = Math.Max(CNT_n, j)
                                    If UBound(PolygonCentroidCoordinates) < j Then
                                        ReDim Preserve PolygonCentroidCoordinates(j + 100)
                                        ReDim Preserve PolygonCentroidCoordinates_f(j + 100)
                                    End If
                                    PolygonCentroidCoordinates(j) = cp
                                    PolygonCentroidCoordinates_f(j) = True
                                Next
                            End If
                        Loop
                    Case "PAL" 'ポリゴンの位相構造
                        ShapeS = enmShape.PolygonShape
                        With MapData
                            .Add_OneObjectGroup_Parameter(FileOnName, ShapeS, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
                            .Add_OneLineKind(FileOnName, clsBase.Line, enmMesh_Number.mhNonMesh)
                            .ObjectKind(0).UseLineType(0) = True
                        End With
                        Dim Precision As Integer = wsh(1)
                        PAL_F = True
                        Do
                            Dim tx As String = fileData(filePoint)
                            filePoint += 1
                            Dim NumArcs As Integer = Val(Mid(tx, 1, 10))
                            If Precision = 3 Then
                                filePoint += 1
                            End If
                            If NumArcs = -1 Then
                                Exit Do
                            Else
                                Dim a2 As String = ""
                                For i As Integer = 1 To (NumArcs + (NumArcs Mod 2)) \ 2
                                    Dim a As String = fileData(filePoint)
                                    filePoint += 1
                                    a2 += " " & a
                                Next
                                Dim ws() As String = clsGeneric.String_Cut(a2, " ")
                                Dim n As Integer = 0
                                Dim LCode(NumArcs) As Integer
                                For i As Integer = 0 To NumArcs - 1
                                    If Val(ws(i * 3)) <> 0 Then
                                        LCode(n) = Math.Abs(Val(ws(i * 3))) - 1
                                        n += 1
                                    End If
                                Next
                                With MapData
                                    If .MPObj.Length <= .Map.Kend Then
                                        ReDim Preserve .MPObj(.Map.Kend * 2)
                                    End If
                                    .MPObj(.Map.Kend) = .Init_One_Object(0)
                                    With .MPObj(.Map.Kend)
                                        .Number = MapData.Map.Kend
                                        .Kind = 0
                                        .Shape = ShapeS
                                        .NumOfLine = n
                                        With .NameTimeSTC(0)
                                            ReDim .NamesList(0)
                                            .NamesList(0) = ObjNameHeader + MapData.Map.Kend.ToString
                                        End With
                                        ReDim Preserve .LineCodeSTC(.NumOfLine - 1)
                                        For i As Integer = 0 To n - 1
                                            .LineCodeSTC(i).LineCode = LCode(i)
                                        Next
                                    End With
                                    .Map.Kend += 1
                                End With
                            End If
                        Loop
                        ReDim Preserve MapData.MPObj(MapData.Map.Kend - 1)
                    Case ".AAT" 'アークの属性
                        Dim tlen As Integer
                        Get_INFO_Files(fileData(filePoint - 1), PAT_data_n, PAT_Object_n, PAT_Data, fileData, filePoint, tlen)
                        PAT_data_n -= 7
                        ReDim attData(PAT_data_n - 1, PAT_Object_n - 1)
                        ReDim TTL(PAT_data_n - 1)
                        For i As Integer = 0 To PAT_data_n - 1
                            TTL(i) = PAT_Data(i + 7).Name
                        Next
                        For i As Integer = 0 To PAT_Object_n - 1
                            Dim tx As String = ""
                            Dim lenb As Integer
                            Do
                                Dim pt As String = fileData(filePoint)
                                filePoint += 1
                                'Dim ptLenb As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(pt)
                                'Dim mlen As Integer = ((ptLenb \ 80) + 1) * 80
                                'pt += New String(" ", mlen - ptLenb)
                                tx += pt

                                lenb = System.Text.Encoding.GetEncoding(932).GetByteCount(tx)
                            Loop While lenb < tlen

                            For j As Integer = 0 To PAT_data_n + 7 - 1
                                If j >= 7 Then
                                    With PAT_Data(j)
                                        Dim a As String = Trim(MidB(tx, .StartP, .len))
                                        attData(j - 7, i) = a
                                    End With
                                End If
                            Next
                        Next

                    Case ".PAT" 'ポリゴン、ポイントの属性
                        Dim tlen As Integer
                        Get_INFO_Files(fileData(filePoint - 1), PAT_data_n, PAT_Object_n, PAT_Data, fileData, filePoint, tlen)
                        ReDim attData(PAT_data_n - 1, PAT_Object_n - 1)
                        ReDim TTL(PAT_data_n - 1)
                        TTL(0) = PAT_Data(2).Name
                        TTL(1) = PAT_Data(3).Name
                        TTL(2) = PAT_Data(0).Name
                        TTL(3) = PAT_Data(1).Name
                        For i As Integer = 4 To PAT_data_n - 1
                            TTL(i) = PAT_Data(i).Name
                        Next
                        For i As Integer = 0 To PAT_Object_n - 1
                            Dim tx As String = ""
                            Dim lenb As Integer
                            Do
                                Dim pt As String = fileData(filePoint)
                                filePoint += 1
                                'Dim ptLenb As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(pt)
                                'Dim mlen As Integer = ((ptLenb \ 80) + 1) * 80
                                'pt += New String(" ", mlen - ptLenb)
                                tx += pt
                                lenb = System.Text.Encoding.GetEncoding(932).GetByteCount(tx)
                            Loop While lenb < tlen
                            attData(0, i) = Trim(MidB(tx, PAT_Data(2).StartP, PAT_Data(2).len))
                            attData(1, i) = Trim(MidB(tx, PAT_Data(3).StartP, PAT_Data(3).len))
                            attData(2, i) = Trim(MidB(tx, PAT_Data(0).StartP, PAT_Data(0).len))
                            attData(3, i) = Trim(MidB(tx, PAT_Data(1).StartP, PAT_Data(1).len))
                            For j As Integer = 4 To PAT_data_n - 1
                                With PAT_Data(j)
                                    attData(j, i) = Trim(MidB(tx, .StartP, .len))
                                End With
                            Next
                        Next

                End Select

            End If

        Loop



        If ARC_F = True And PAL_F = False Then
            ShapeS = enmShape.LineShape
            With MapData
                .Add_OneObjectGroup_Parameter(FileOnName, ShapeS, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
                .Add_OneLineKind(FileOnName, clsBase.Line, enmMesh_Number.mhNonMesh)
                .ObjectKind(0).UseLineType(0) = True
                .Map.Kend = MapData.Map.ALIN
                ReDim .MPObj(MapData.Map.ALIN - 1)
                For i As Integer = 0 To MapData.Map.ALIN - 1
                    .MPObj(i) = .Init_One_Object(0)
                    With .MPObj(i)
                        .Number = i
                        .Kind = 0
                        .Shape = ShapeS
                        .NumOfLine = 1
                        ReDim .LineCodeSTC(0)
                        .LineCodeSTC(0).LineCode = i
                        With .NameTimeSTC(0)
                            ReDim .NamesList(0)
                            .NamesList(0) = ObjNameHeader + i.ToString
                        End With
                    End With
                Next
            End With
        ElseIf LAB_F = True And PAL_F = False Then
            ShapeS = enmShape.PointShape
            MapData.Add_OneObjectGroup_Parameter(FileOnName, ShapeS, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
            With MapData
                .Map.Kend = Lab_Points.Count
                ReDim .MPObj(Lab_Points.Count - 1)
                For i As Integer = 0 To Lab_Points.Count - 1
                    .MPObj(i) = .Init_One_Object(0)
                    With .MPObj(i)
                        .Number = i
                        With .NameTimeSTC(0)
                            ReDim .NamesList(0)
                            .NamesList(0) = ObjNameHeader + i.ToString
                        End With
                        .Kind = 0
                        .Shape = ShapeS
                        .CenterPSTC(0).Position = Lab_Points.Item(i)
                    End With
                Next
            End With
        Else

        End If



        '初期属性データの設定


        Dim UNT() As String = clsGeneric.Check_DataType(PAT_data_n, PAT_Object_n, attData)

        For i As Integer = 0 To PAT_data_n - 1
            MapData.Add_one_DefAttDataSet(0, TTL(i), UNT(i), "")
        Next

        For i As Integer = 0 To PAT_Object_n - 1
            With MapData.MPObj(i)
                ReDim .DefTimeAttValue(PAT_data_n - 1)
                For j As Integer = 0 To PAT_data_n - 1
                    ReDim .DefTimeAttValue(j).Data(0)
                    .DefTimeAttValue(j).Data(0).Value = attData(j, i)
                Next
            End With
        Next

        ProgressLabel.Visible = False
        Return True


    End Function
    ''' <summary>
    ''' INFOセクションを読み込む
    ''' </summary>
    ''' <param name="adata"></param>
    ''' <param name="NumOfAttributes"></param>
    ''' <param name="NumofDataRecords"></param>
    ''' <param name="PAT_Data"></param>
    ''' <param name="inner_lp"></param>
    ''' <param name="fileData"></param>
    ''' <param name="filePoint"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Get_INFO_Files(ByVal adata As String, ByRef NumOfAttributes As Integer, ByRef NumofDataRecords As Integer,
                                    ByRef PAT_Data() As pat_data_info, ByRef fileData As List(Of String),
                                    ByRef filePoint As Integer, ByRef TotalLen As Integer)
        Dim NumofTotalAttrubutes As Integer


        NumOfAttributes = Val(Mid(adata, 35, 4))
        NumofTotalAttrubutes = Val(Mid(adata, 39, 4)) 'Deleted Attributeを含む属性総数
        NumofDataRecords = Val(Mid(adata, 47, 10))
        ReDim PAT_Data(NumOfAttributes - 1)
        Dim j As Integer = 1
        Dim n As Integer = 0
        For i As Integer = 0 To NumofTotalAttrubutes - 1
            Dim a As String = fileData(filePoint)
            filePoint += 1
            If Val(Mid(a, 65, 5)) <> -1 Then
                With PAT_Data(n)
                    .Name = Trim(Mid(a, 1, 16))
                    Dim tp As Integer = Val(Mid(a, 17, 3))
                    Dim tp2 As Integer = Val(Mid(a, 35, 3))
                    .StartP = j
                    Select Case tp2
                        Case 10
                            .len = 8
                        Case 20, 30
                            .len = tp
                        Case 40
                            .len = 14
                        Case 50
                            If tp = 4 Then
                                .len = 11
                            Else
                                .len = 6
                            End If
                        Case 60
                            If tp = 4 Then
                                .len = 14
                            Else
                                .len = 24
                            End If
                    End Select
                    j += .len
                End With
                n += 1
            End If
        Next
        TotalLen = j
    End Function

    Public Shared Function MidB(ByVal stTarget As String, ByVal iStart As Integer, ByVal iByteSize As Integer) As String
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncoding.GetBytes(stTarget)

        Return hEncoding.GetString(btBytes, iStart - 1, iByteSize)
    End Function
    Private Shared Function e00_fileRead(ByVal filename As String, ByRef fileLine As List(Of String)) As Boolean
        Dim bs() As Byte
        Try
            Dim fs As New System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            ReDim bs(fs.Length - 1)
            fs.Read(bs, 0, bs.Length)
            fs.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try

        Dim tline As New List(Of String)
        Dim p As Integer = 0
        Dim obt As New List(Of Byte)
        Do
            Dim bt As Byte() = getline(bs, p)
            If bt(bt.GetUpperBound(0)) > 128 Then
                obt.AddRange(bt)
            Else
                obt.AddRange(bt)
                Dim tx As String = System.Text.Encoding.GetEncoding(932).GetString(obt.ToArray)
                tline.Add(tx)
                If tline.Count > 12746 Then
                    tx = tx
                End If
                If tx <> "" Then
                End If
                obt.Clear()
            End If
        Loop While p < bs.Length
        fileLine = tline
        Return True




    End Function
    Private Shared Function getline(ByRef sby() As Byte, ByRef p As Integer) As Byte()
        Dim fp As Integer = p
        Do While (sby(p)) <> 13 And (sby(p) <> 10)
            p += 1
        Loop
        p += 1
        Dim n As Integer = p - fp - 1
        'Dim bt As Byte() = New Byte(n - 1) {}
        Dim bt(79) As Byte
        Array.Copy(sby, fp, bt, 0, n)
        For i As Integer = n To 79
            bt(i) = 32
        Next
        If p <> sby.Length Then
            If sby(p - 1) = 13 And sby(p) = 10 Then '改行コードがCR+LFの場合
                p += 1
            End If
        End If
        Return bt
    End Function
End Class
