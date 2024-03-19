Imports System.Runtime.InteropServices
Public Class frmMED_MeshContour
    Dim ObjectUseLineInfo As String
    Dim CloseCancelF As Boolean
    Dim ContourMap As New clsMapData
    Dim GlobalRange As strLatLonBox
    Dim FolderFile As KibanFolder_Info

    Dim High_M() As Double
    Dim Height_Num As Integer
    Dim FrameObjectStart As Integer
    Dim PolygonObjectStart As Integer

    Dim MapData As clsMapData
    Dim ScrData As Screen_info
    Dim PrintedLine() As Boolean
    Dim mousePointingSituation As mousePointingSituations
    Dim mouseDownPosition As Point
    Private Enum enmMouseRangeMode
        noPointSet = 0
        startPointSet = 1
        EndPointSet = 2
    End Enum
    Private Structure strTileMapViewInfo
        Public visible As Boolean
        Public ViewData As strTileMapViewDataInfo
    End Structure
    Dim mouseRangeMode As enmMouseRangeMode
    Dim mouseRangeStartPoint As PointF
    Dim mouseRangeEndPoint As PointF
    Dim mouseRangeMovingPoint As PointF

    Dim picMapImageOperation As clsPictureBoxDragOrWheelImageChange


    Dim WorldMap As clsMapData
    Dim WorldScrData As Screen_info
    Dim JapanMap As clsMapData
    Dim JapanScrData As Screen_info
    Dim TileMap As clsTileMapService

    Dim TileMapView As strTileMapViewInfo

    Private Enum enmMeshArea
        Japan = 0
        World = 1
    End Enum
    Private Enum enmMeshName
        suchi50m
        suchi250m
        suchi1km
        kiban10m
        kiban5m
        SRTM30
        SRTM3
        AsterGdem
        ETOPO5
    End Enum
    Private Structure KibanFolder_Info
        Public fnum As Integer
        Public File_List() As String
        Public File_List2() As Integer
    End Structure

    Private Structure MeshDataInfo
        Public name As enmMeshName
        Public Title As String
        Public Area As enmMeshArea
        Public JapanMeshSystem As enmMesh_Number
        Public JapanMeshSize As Size
        Public WorldPxPerDegree As Integer
        Public Folder As String
    End Structure
    Dim MeshDataSet() As MeshDataInfo
    Dim SelectedMeshData As MeshDataInfo
    Private Sub frmMED_MeshContour_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Select Case e.CloseReason
            Case CloseReason.None
                If CloseCancelF = True Then
                    CloseCancelF = False
                    e.Cancel = True
                Else
                    e.Cancel = False
                End If
            Case Else
        End Select
    End Sub
    Public Overloads Function ShowDialog(ByVal _TileMap As clsTileMapService) As Windows.Forms.DialogResult
        TileMap = _TileMap
        Return Me.ShowDialog
    End Function

    Public Function getResult() As clsMapData
        Return ContourMap
    End Function
    Private Function getJapeneseMeshFileName(ByVal MeshCode As Integer) As String
        Dim a As String = CStr(MeshCode)
        Dim ix As Integer = Array.IndexOf(FolderFile.File_List2, MeshCode)
        If ix <> -1 Then
            Return FolderFile.File_List(ix)
        Else
            Return ""
        End If
    End Function
    Private Function Get_Suchi_Kiban_Mesh_File() As Boolean

        Dim meshw As Single, meshh As Single

        Dim folder_path As String = SelectedMeshData.Folder
        Dim w As Integer = SelectedMeshData.JapanMeshSize.Width
        Dim H As Integer = SelectedMeshData.JapanMeshSize.Height
        Select Case SelectedMeshData.name
            Case enmMeshName.suchi50m
                meshw = (450 / 200) / 3600
                meshh = -(300 / 200) / 3600
                With FolderFile
                    Try
                        .File_List = System.IO.Directory.GetFiles(folder_path, "*.mem", IO.SearchOption.AllDirectories)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                        Return False
                    End Try
                    .fnum = .File_List.Length
                    ReDim .File_List2(.fnum)
                    For i As Integer = 0 To .fnum - 1
                        .File_List2(i) = Val(Mid(System.IO.Path.GetFileName(.File_List(i)), 1, 6))
                    Next
                End With
            Case enmMeshName.suchi250m
                meshw = 11.25 / 3600
                meshh = -7.5 / 3600
                With FolderFile
                    .File_List = System.IO.Directory.GetFiles(folder_path, "*.sem", IO.SearchOption.TopDirectoryOnly)
                    .fnum = .File_List.Length
                    ReDim .File_List2(.fnum)
                    For i As Integer = 0 To .fnum - 1
                        .File_List2(i) = Val(Mid(System.IO.Path.GetFileName(.File_List(i)), 1, 4))
                    Next
                End With
            Case enmMeshName.suchi1km
                meshw = 45 / 3600
                meshh = -30 / 3600
                With FolderFile
                    .File_List = System.IO.Directory.GetFiles(folder_path, "*.tem", IO.SearchOption.TopDirectoryOnly)
                    .fnum = .File_List.Length
                    ReDim .File_List2(.fnum)
                    For i As Integer = 0 To .fnum - 1
                        .File_List2(i) = Val(Mid(System.IO.Path.GetFileName(.File_List(i)), 1, 4))
                    Next
                End With
            Case enmMeshName.kiban10m
                meshw = (450 / w) / 3600
                meshh = -(300 / H) / 3600
                With FolderFile
                    .File_List = System.IO.Directory.GetFiles(folder_path, "*.xml", IO.SearchOption.TopDirectoryOnly)
                    .fnum = .File_List.Length
                    ReDim .File_List2(.fnum)
                    For i As Integer = 0 To .fnum - 1
                        Dim fname As String = System.IO.Path.GetFileName(.File_List(i))
                        If UCase(Microsoft.VisualBasic.Left(fname, 6)) = "FG-GML" And
                            UCase(Mid(fname, 16, 5)) = "DEM10" Then
                            .File_List2(i) = Val(Mid(fname, 8, 4)) * 100 + Val(Mid(fname, 13, 2))
                        Else
                            .File_List(i) = ""
                        End If
                    Next
                End With
            Case enmMeshName.kiban5m
                meshw = (45 / w) / 3600
                meshh = -(30 / H) / 3600
                With FolderFile
                    .File_List = System.IO.Directory.GetFiles(folder_path, "*.xml")
                    .fnum = .File_List.Length
                    ReDim .File_List2(.fnum)
                    For i As Integer = 0 To .fnum - 1
                        Dim fname As String = System.IO.Path.GetFileName(.File_List(i))
                        If UCase(Microsoft.VisualBasic.Left(fname, 6)) = "FG-GML" _
                            And UCase(Mid(fname, 19, 4)) = "DEM5" Then
                            .File_List2(i) = Val(Mid(fname, 8, 4)) * 10000 + Val(Mid(fname, 13, 2)) * 100 + Val(Mid(fname, 16, 2))
                        Else
                            .File_List(i) = ""
                        End If
                    Next
                End With
        End Select

        Dim meshNumber As enmMesh_Number = SelectedMeshData.JapanMeshSystem
        Dim NWMesh As Integer = spatial.Get_MeshCode_from_LatLon(GlobalRange.NorthWest, meshNumber)
        Dim SEMesh As Integer = spatial.Get_MeshCode_from_LatLon(GlobalRange.SouthEast, meshNumber)
        Dim MeshArea As Size = spatial.Get_MeshCode_Size_fromTwoMesh(NWMesh, SEMesh, meshNumber)

        Dim MeshGetNum As Integer = 0
        Dim MeshGetCode(MeshArea.Height * MeshArea.Width) As Integer
        ProgressLabel.Start(MeshArea.Height * MeshArea.Width, "標高メッシュデータ読み込み中", False)
        Dim firstMeshCode As Integer = NWMesh
        Dim getone As Boolean = False
        For i As Integer = 0 To MeshArea.Height - 1
            For j As Integer = 0 To MeshArea.Width - 1
                Dim MCode As Integer = spatial.Get_MeshCodeOffset(firstMeshCode, j, -i, meshNumber)
                ProgressLabel.SetValue(i * MeshArea.Width + j + 1)
                My.Application.DoEvents()
                Dim meshSize As strLatLonBox = spatial.Get_Ido_Kedo_from_MeshCode(CStr(MCode), meshNumber)
                Dim meshSizeNorth As strLatLonBox = spatial.Get_Ido_Kedo_from_MeshCode(CStr(spatial.Get_MeshCodeOffset(MCode, 0, 1, meshNumber)), meshNumber)
                Dim meshSizeEast As strLatLonBox = spatial.Get_Ido_Kedo_from_MeshCode(CStr(spatial.Get_MeshCodeOffset(MCode, 1, 0, meshNumber)), meshNumber)
                'meshSize.Heightを使わないのは、誤差が生じて図郭間でラインが接合しないため
                Dim MeshHeight As Single = meshSizeNorth.NorthWest.Latitude - meshSize.NorthWest.Latitude
                Dim MeshWidth As Single = meshSizeEast.NorthWest.Longitude - meshSize.NorthWest.Longitude
                meshSize.Offset(meshw / 2, -meshh / 2)
                Dim ContourMesh As New clsMeshContour
                ContourMesh.SetMeshInfo(w + 1, H + 1, MeshWidth, MeshHeight, meshSize.NorthWest.Longitude, meshSize.SouthWest.Latitude)
                Dim GetF As Boolean
                '右側と下側のデータも読み込んで接合できるようにする
                For ki As Integer = 0 To 1

                    Dim whh30 As Integer
                    If ki = 0 Then
                        whh30 = H
                    Else
                        whh30 = 1
                    End If
                    For kk As Integer = 0 To 1
                        Dim mf As String = getJapeneseMeshFileName(spatial.Get_MeshCodeOffset(MCode, kk, ki, meshNumber))
                        Dim whw30 As Integer
                        If mf <> "" Then
                            If kk = 0 Then
                                whw30 = w
                            Else
                                whw30 = 1
                            End If
                            Dim Alti(,) As Single
                            Select Case SelectedMeshData.name
                                Case enmMeshName.suchi50m, enmMeshName.suchi250m, enmMeshName.suchi1km
                                    Alti = Mesh_SuchuTizu(mf, w, H)
                                Case enmMeshName.kiban5m, enmMeshName.kiban10m
                                    Alti = Mesh_Kiban(mf, w, H)
                            End Select
                            Dim xps As Integer = kk * w
                            Dim yps As Integer = ki * H
                            For k As Integer = 0 To whh30 - 1
                                For k2 As Integer = 0 To whw30 - 1
                                    ContourMesh.SetMeshValue(xps + k2, yps + k, Alti(k2, k))
                                Next
                            Next
                            GetF = True
                        Else
                            If ki = 0 And kk = 0 Then
                                ki = 1
                                kk = 1
                                GetF = False
                            End If
                        End If
                    Next
                Next

                If GetF = True Then
                    getone = True
                    Dim Con_Point() As PointF
                    Dim Con_LineStac() As clsMeshContour.ContourLineStacInfo
                    Dim ConLineN As Integer

                    Dim Frame_Point() As PointF
                    Dim Frame_LineStac() As Integer
                    Dim FrameLineN As Integer

                    ConLineN = ContourMesh.Execute_Mesh(Height_Num, High_M, Con_LineStac, Con_Point)
                    Call Convert_Mpline_fromMeshData(ConLineN, Con_LineStac, Con_Point)

                    If j = 0 Or Array.IndexOf(FolderFile.File_List2, spatial.Get_MeshCodeOffset(MCode, -1, 0, meshNumber)) = -1 Then
                        FrameLineN = ContourMesh.Execute_FrameGet(0, Height_Num, High_M, Frame_LineStac, Frame_Point)
                        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
                    End If
                    If i = 0 Or Array.IndexOf(FolderFile.File_List2, spatial.Get_MeshCodeOffset(MCode, 0, 1, meshNumber)) = -1 Then
                        FrameLineN = ContourMesh.Execute_FrameGet(3, Height_Num, High_M, Frame_LineStac, Frame_Point)
                        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
                    End If
                    If j = MeshArea.Width - 1 Or Array.IndexOf(FolderFile.File_List2, spatial.Get_MeshCodeOffset(MCode, 1, 0, meshNumber)) = -1 Then
                        FrameLineN = ContourMesh.Execute_FrameGet(2, Height_Num, High_M, Frame_LineStac, Frame_Point)
                        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
                    End If
                    If i = MeshArea.Height - 1 Or Array.IndexOf(FolderFile.File_List2, spatial.Get_MeshCodeOffset(MCode, 0, -1, meshNumber)) = -1 Then
                        FrameLineN = ContourMesh.Execute_FrameGet(1, Height_Num, High_M, Frame_LineStac, Frame_Point)
                        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
                    End If
                End If
            Next

        Next
        ProgressLabel.Finish()

        Return getone
    End Function
    Private Function Mesh_SuchuTizu(ByVal Fname As String, ByVal w As Integer, ByVal H As Integer) As Single(,)
        '数値地図メッシュファイルから標高読み込み

        Dim Alti(w - 1, H - 1) As Single

        ReDim Alti(w - 1, H - 1)
        Dim sr As New System.IO.StreamReader(Fname, System.Text.Encoding.GetEncoding("shift_jis"))
        Dim header As String = sr.ReadLine()
        Dim DataExists As String = clsGeneric.MidB(header, 226, H)
        For i As Integer = 0 To H - 1
            If Mid(DataExists, i + 1, 1) = "1" Then
                Dim alitiData As String = sr.ReadLine()
                For j As Integer = 0 To w - 1
                    Alti(j, H - 1 - i) = Val(Mid(alitiData, j * 5 + 10, 5)) / 10
                Next
            Else
                For j As Integer = 0 To w - 1
                    Alti(j, H - 1 - i) = -9999.9
                Next
            End If
        Next
        sr.Close()
        Return Alti
    End Function
    Private Function Mesh_Kiban(ByVal Fname As String, ByVal w As Integer, ByVal H As Integer) As Single(,)
        '基盤地図メッシュファイルから標高読み込み


        Dim Alti(w - 1, H - 1) As Single
        Dim MDIM(w * H - 1) As Single
        Dim n As Integer = 0
        Dim sx As Double, sy As Double
        Dim fname2 As String = System.IO.Path.GetFileNameWithoutExtension(Fname)
        Dim fdate As Integer = Val(Microsoft.VisualBasic.Right(fname2, 8))
        Dim encodode As System.Text.Encoding
        If fdate >= 20161001 Then
            encodode = System.Text.Encoding.GetEncoding("utf-8")
        Else
            encodode = System.Text.Encoding.GetEncoding("shift_jis")
        End If
        Dim sr As New System.IO.StreamReader(Fname, encodode)
        Do Until sr.EndOfStream
            Dim gdata As String = sr.ReadLine()
            Dim f As Boolean = True
            Dim xmlTag As String = UCase(Replace(gdata.Trim(), vbTab, ""))
            If xmlTag = "<GML:TUPLELIST>" Then
                Dim gdata2 As String
                Do
                    gdata2 = sr.ReadLine()
                    Dim ic As Integer = InStr(gdata2, ",")
                    If ic <> 0 Then
                        MDIM(n) = Val(Mid(gdata2, ic + 1))
                        n += 1
                    End If
                Loop While Trim(UCase(gdata2)) <> "</GML:TUPLELIST>"
            ElseIf Microsoft.VisualBasic.Left(xmlTag, 16) = "<GML:STARTPOINT>" Then
                Call Split_SpaceXY(gdata, sx, sy)
            End If
        Loop
        sr.Close()
        Dim X As Integer = sx
        Dim Y As Integer = sy
        For i As Integer = 0 To n - 1
            Alti(X, H - 1 - Y) = MDIM(i)
            X += 1
            If X = w Then
                X = 0
                Y += 1
            End If
        Next
        Return Alti
    End Function
    Private Sub Split_SpaceXY(ByVal xmlLine As String, ByRef X As Double, ByRef Y As Double)

        Dim s As String = Get_JPGIS_XML_Strings(xmlLine, ">", "<")
        Dim SP As Integer = InStr(s, " ")
        X = Val(Mid$(s, 1, SP - 1))
        Y = Val(Mid$(s, SP + 1))

    End Sub

    Private Function Get_JPGIS_XML_Strings(ByVal xmlLine As String, ByVal Stagmark As String, ByVal Etagmark As String) As String
        '指定した文字で囲まれた文字列を取り出す

        Dim i1 As Integer = InStr(xmlLine, Stagmark)
        Dim i2 As Integer = InStrRev(xmlLine, Etagmark)
        If i1 = 0 Or i2 = 0 Or i2 < i1 Then
            Return ""
        Else
            Return Mid(xmlLine, i1 + 1, i2 - i1 - 1)
            '        If left$(Get_Strings, 1) = "_" Then
            '            Get_Strings = Mid$(Get_Strings, 2)
            '        End If
        End If
    End Function


    Private Function Get_ASTERGDEM_Mesh_File() As Boolean

        Dim f As Boolean

        Dim srtm_ex As String = "tif"

        Dim XYSize As Size = Get_SRTM_WHDegree()

        ProgressLabel.Start(XYSize.Width * XYSize.Height, "標高メッシュデータ読み込み中", False)
        Dim ASTERGDEMPxPerDegree = SelectedMeshData.WorldPxPerDegree
        Dim xi As Integer = 0

        For i As Integer = GlobalRange.NorthWest.Longitude To GlobalRange.SouthEast.Longitude - 1

            Dim yi As Integer = 0
            For j As Integer = GlobalRange.NorthWest.Latitude - 1 To GlobalRange.SouthEast.Latitude Step -1
                ProgressLabel.SetValue(xi * XYSize.Height + yi + 1)
                My.Application.DoEvents()
                Dim mf As String = clsGeneric.Get_IdoKedo_Strings_NSWE(New strLatLon(j, i)) & "_dem." & srtm_ex
                Dim AsterV1Name As String = SelectedMeshData.Folder & "\ASTGTM_" & mf
                Dim AsterV2Name As String = SelectedMeshData.Folder & "\ASTGTM2_" & mf
                Dim AsterV3Name As String = SelectedMeshData.Folder & "\ASTGTMV003_" & mf
                Dim AsterName As String = ""
                If System.IO.File.Exists(AsterV2Name) = True Then
                    AsterName = SelectedMeshData.Folder & "\ASTGTM2_"
                ElseIf System.IO.File.Exists(AsterV1Name) = True Then
                    AsterName = SelectedMeshData.Folder & "\ASTGTM_"
                ElseIf System.IO.File.Exists(AsterV3Name) = True Then
                    AsterName = SelectedMeshData.Folder & "\ASTGTMV003_"
                End If
                If AsterName <> "" Then
                    Dim ContourMesh As New clsMeshContour
                    ContourMesh.SetMeshInfo(ASTERGDEMPxPerDegree, ASTERGDEMPxPerDegree, 1, -1, i, j + 1)
                    Dim Alti() As Byte
                    Dim fget As Boolean = Get_MeshFile_FileStream(AsterName & mf, Alti, ASTERGDEMPxPerDegree ^ 2 * 2 + 8)
                    If fget = True Then
                        Dim lackCell As New ArrayList
                        For k As Integer = 0 To ASTERGDEMPxPerDegree - 1
                            Dim ad2 As Integer = k * ASTERGDEMPxPerDegree * 2
                            For k2 As Integer = 0 To ASTERGDEMPxPerDegree - 1
                                Dim ad As Integer = ad2 + k2 * 2 + 8
                                If Alti(ad + 1) = 255 Then
                                    ContourMesh.SetLack(k2, k, True)
                                    lackCell.Add(New Point(k2, k))
                                Else
                                    ContourMesh.SetMeshValue(k2, k, Alti(ad + 1) * 256 + Alti(ad))
                                End If
                            Next
                        Next
                        If lackCell.Count > 0 Then
                            Dim lackoff As Integer = 0
                            '欠損値を周辺のポイントの平均値に置き換える
                            For k As Integer = 0 To lackCell.Count - 1
                                Dim lackXY As Point = CType(lackCell.Item(k), Point)
                                Dim v As Single = 0
                                Dim vn As Integer = 0
                                For ky As Integer = -1 To 1
                                    For kx As Integer = -1 To 1
                                        Dim filp As Point = New Point(lackXY.X + kx, lackXY.Y + ky)
                                        If 0 <= filp.X And filp.X < ASTERGDEMPxPerDegree And
                                            0 <= filp.Y And filp.Y < ASTERGDEMPxPerDegree Then
                                            If ContourMesh.GetLack(filp.X, filp.Y) = False Then
                                                v += ContourMesh.GetMeshValue(filp.X, filp.Y)
                                                vn += 1
                                            End If
                                        End If
                                    Next
                                Next
                                If vn > 0 Then
                                    ContourMesh.SetLack(lackXY.X, lackXY.Y, False)
                                    ContourMesh.SetMeshValue(lackXY.X, lackXY.Y, Int(v / vn))
                                    lackoff += 1
                                End If
                            Next
                            '   MsgBox(lackCell.Count.ToString + "/" + lackoff.ToString)
                        End If
                    End If
                    Dim Con_Point() As PointF
                    Dim Con_LineStac() As clsMeshContour.ContourLineStacInfo
                    Dim ConLineN As Integer
                    Dim Frame_Point() As PointF
                    Dim Frame_LineStac() As Integer
                    Dim FrameLineN As Integer

                    ConLineN = ContourMesh.Execute_Mesh(Height_Num, High_M, Con_LineStac, Con_Point)
                    Call Convert_Mpline_fromMeshData(ConLineN, Con_LineStac, Con_Point)
                    f = False
                    If i = GlobalRange.NorthWest.Longitude Or System.IO.File.Exists(AsterName & clsGeneric.Get_IdoKedo_Strings_NSWE(New strLatLon(j, i - 1)) & "_dem." & srtm_ex) = False Then
                        FrameLineN = ContourMesh.Execute_FrameGet(0, Height_Num, High_M, Frame_LineStac, Frame_Point)
                        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
                    End If
                    If j = GlobalRange.NorthWest.Latitude - 1 Or System.IO.File.Exists(AsterName & clsGeneric.Get_IdoKedo_Strings_NSWE(New strLatLon(j + 1, i)) & "_dem." & srtm_ex) = False Then
                        FrameLineN = ContourMesh.Execute_FrameGet(1, Height_Num, High_M, Frame_LineStac, Frame_Point)
                        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
                    End If
                    If i = GlobalRange.SouthEast.Longitude - 1 Or System.IO.File.Exists(AsterName & clsGeneric.Get_IdoKedo_Strings_NSWE(New strLatLon(j, i + 1)) & "_dem." & srtm_ex) = False Then
                        FrameLineN = ContourMesh.Execute_FrameGet(2, Height_Num, High_M, Frame_LineStac, Frame_Point)
                        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
                    End If
                    If j = GlobalRange.SouthEast.Latitude Or System.IO.File.Exists(AsterName & clsGeneric.Get_IdoKedo_Strings_NSWE(New strLatLon(j - 1, i)) & "_dem." & srtm_ex) = False Then
                        FrameLineN = ContourMesh.Execute_FrameGet(3, Height_Num, High_M, Frame_LineStac, Frame_Point)
                        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
                    End If
                End If
                yi += 1
            Next
            xi += 1
        Next

        ProgressLabel.Finish()


        Return True
    End Function

    Private Function Get_SRTM_Mesh_File() As Boolean



        Dim srtm_ex As String


        Select Case SelectedMeshData.name
            Case enmMeshName.SRTM30
                srtm_ex = "srtm30mdr"
            Case enmMeshName.SRTM3
                srtm_ex = "hgt"
        End Select
        Dim wh As Integer = SelectedMeshData.WorldPxPerDegree
        If SelectedMeshData.name = enmMeshName.SRTM30 Then
            wh += 1
        End If
        Dim XYSize As Size = Get_SRTM_WHDegree()


        ProgressLabel.Start(XYSize.Width * XYSize.Height, "標高メッシュデータ読み込み中", False)

        Dim xi As Integer = 0
        For i As Integer = GlobalRange.NorthWest.Longitude To GlobalRange.SouthEast.Longitude - 1
            Dim yi As Integer = 0
            For j As Integer = GlobalRange.NorthWest.Latitude - 1 To GlobalRange.SouthEast.Latitude Step -1
                ProgressLabel.SetValue(xi * XYSize.Height + yi + 1)
                My.Application.DoEvents()
                Dim mf As String = SelectedMeshData.Folder & "\" & clsGeneric.Get_IdoKedo_Strings_NSWE(New strLatLon(j, i)) & "." & srtm_ex
                Dim ContourMesh As New clsMeshContour
                If System.IO.File.Exists(mf) = True Then
                    ContourMesh.SetMeshInfo(wh, wh, 1, -1, i, j + 1)
                    If SelectedMeshData.name = enmMeshName.SRTM3 Then
                        Dim Alti() As Byte
                        Dim fget As Boolean = Get_MeshFile_FileStream(mf, Alti, wh ^ 2 * 2)
                        For k As Integer = 0 To wh - 1
                            For k2 As Integer = 0 To wh - 1
                                Dim ad As Integer = k * wh * 2 + k2 * 2
                                If Alti(ad) = 128 Or Alti(ad) = 255 Then
                                    ContourMesh.SetMeshValue(k2, k, 0)
                                Else
                                    ContourMesh.SetMeshValue(k2, k, Alti(ad) * 256 + Alti(ad + 1))
                                End If
                            Next
                        Next
                    Else
                        'SRTM30の場合は東側、南側、南東側メッシュファイルも読み込み、1列・行分のデータを追加
                        For ki As Integer = 0 To 1
                            Dim whh30 As Integer
                            If ki = 0 Then
                                whh30 = SelectedMeshData.WorldPxPerDegree
                            Else
                                whh30 = 1
                            End If
                            For kk As Integer = 0 To 1
                                Dim mf2 As String = SelectedMeshData.Folder & "\" & clsGeneric.Get_IdoKedo_Strings_NSWE(New strLatLon(j - ki, i + kk)) & "." & srtm_ex
                                Dim fget As Boolean = False
                                Dim whw30 As Integer
                                If kk = 0 Then
                                    whw30 = SelectedMeshData.WorldPxPerDegree
                                Else
                                    whw30 = 1
                                End If
                                Dim xp30 As Integer = kk * SelectedMeshData.WorldPxPerDegree
                                Dim yp30 As Integer = ki * SelectedMeshData.WorldPxPerDegree
                                Dim Alti() As Byte
                                If System.IO.File.Exists(mf2) = True Then
                                    If ki = 0 Then
                                        fget = Get_MeshFile_FileStream(mf2, Alti, SelectedMeshData.WorldPxPerDegree ^ 2 * 2)
                                    Else
                                        fget = Get_MeshFile_FileStream(mf2, Alti, SelectedMeshData.WorldPxPerDegree * 2)
                                    End If
                                    For k As Integer = 0 To whh30 - 1
                                        For k2 As Integer = 0 To whw30 - 1
                                            Dim ad As Integer = k * SelectedMeshData.WorldPxPerDegree * 2 + k2 * 2
                                            If Alti(ad) >= 128 Then
                                                ContourMesh.SetMeshValue(xp30 + k2, yp30 + k, -(255 - Alti(ad)) * 256 - (256 - Alti(ad + 1)))
                                            Else
                                                ContourMesh.SetMeshValue(xp30 + k2, yp30 + k, Alti(ad) * 256 + Alti(ad + 1))
                                            End If
                                        Next
                                    Next
                                End If
                                If fget = False Then
                                    For k As Integer = 0 To whh30 - 1
                                        For k2 As Integer = 0 To whw30 - 1
                                            ContourMesh.SetLack(xp30 + k2, yp30 + k, True)
                                        Next
                                    Next
                                End If
                            Next
                        Next
                    End If

                    Dim Con_Point() As PointF
                    Dim Con_LineStac() As clsMeshContour.ContourLineStacInfo
                    Dim ConLineN As Integer
                    Dim Frame_Point() As PointF
                    Dim Frame_LineStac() As Integer
                    Dim FrameLineN As Integer


                    ConLineN = ContourMesh.Execute_Mesh(Height_Num, High_M, Con_LineStac, Con_Point)
                    Call Convert_Mpline_fromMeshData(ConLineN, Con_LineStac, Con_Point)
                    If i = GlobalRange.NorthWest.Longitude Or System.IO.File.Exists(SelectedMeshData.Folder & "\" & clsGeneric.Get_IdoKedo_Strings_NSWE(New strLatLon(j, i - 1)) & "." & srtm_ex) = False Then
                        FrameLineN = ContourMesh.Execute_FrameGet(0, Height_Num, High_M, Frame_LineStac, Frame_Point)
                        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
                    End If
                    If j = GlobalRange.NorthWest.Latitude - 1 Or System.IO.File.Exists(SelectedMeshData.Folder & "\" & clsGeneric.Get_IdoKedo_Strings_NSWE(New strLatLon(j + 1, i)) & "." & srtm_ex) = False Then
                        FrameLineN = ContourMesh.Execute_FrameGet(1, Height_Num, High_M, Frame_LineStac, Frame_Point)
                        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
                    End If
                    If i = GlobalRange.SouthEast.Longitude - 1 Or System.IO.File.Exists(SelectedMeshData.Folder & "\" & clsGeneric.Get_IdoKedo_Strings_NSWE(New strLatLon(j, i + 1)) & "." & srtm_ex) = False Then
                        FrameLineN = ContourMesh.Execute_FrameGet(2, Height_Num, High_M, Frame_LineStac, Frame_Point)
                        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
                    End If
                    If j = GlobalRange.SouthEast.Latitude Or System.IO.File.Exists(SelectedMeshData.Folder & "\" & clsGeneric.Get_IdoKedo_Strings_NSWE(New strLatLon(j - 1, i)) & "." & srtm_ex) = False Then
                        FrameLineN = ContourMesh.Execute_FrameGet(3, Height_Num, High_M, Frame_LineStac, Frame_Point)
                        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
                    End If
                End If
                yi += 1
            Next
            xi += 1
        Next

        ProgressLabel.Finish()


        Return True
    End Function

    ''' <summary>
    ''' ETOPO5データの取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_ETOPO5_Mesh_File() As Boolean
        Dim Mesh(4320 * 2160 - 1) As Short
        Dim fname As String = SelectedMeshData.Folder + "\ETOPO5.DOS"


        Dim fs As System.IO.FileStream
        Try
            fs = New System.IO.FileStream(fname, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
        Dim fileSize As Integer = CInt(fs.Length) ' ファイルのサイズ
        Dim buf(fileSize - 1) As Byte ' データ格納用配列

        fs.Read(buf, 0, fileSize)
        fs.Close()
        Dim pnt As IntPtr = Marshal.AllocHGlobal(fileSize)
        Marshal.Copy(buf, 0, pnt, fileSize) 'Byte()→IntPtr
        Marshal.Copy(pnt, Mesh, 0, fileSize \ 2) 'IntPtr→Integer()
        Marshal.FreeHGlobal(pnt)

        'Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        ''ImageオブジェクトのGraphicsオブジェクトを作成する
        'Dim g As Graphics = Graphics.FromImage(canvas)
        'For i As Integer = 0 To 2159 Step 10
        '    For j As Integer = 0 To 4319 Step 10
        '        Dim v As Short = (Mesh(j + i * 4320) + 10000) / 15000 * 255
        '        v = Math.Min(v, 255)
        '        'If v <> 0 Then Stop
        '        'Console.Write(v)
        '        Dim Pen As New Pen(Color.FromArgb(255, v, v, v), 1)
        '        g.DrawRectangle(Pen, j \ 10, i \ 10, 1, 1)
        '    Next
        'Next


        Dim XYSize As Size = Get_SRTM_WHDegree()

        Dim ContourMesh As New clsMeshContour
        Dim ETOPO5PxPerDegree As Integer = SelectedMeshData.WorldPxPerDegree
        ContourMesh.SetMeshInfo(XYSize.Width * ETOPO5PxPerDegree, XYSize.Height * ETOPO5PxPerDegree, XYSize.Width, XYSize.Height,
                                GlobalRange.NorthWest.Longitude, GlobalRange.SouthEast.Latitude)

        ProgressLabel.Start(XYSize.Width * ETOPO5PxPerDegree, "標高メッシュデータ読み込み中", False)
        Dim sk As Integer = GlobalRange.NorthWest.Longitude
        For i As Integer = 0 To XYSize.Width * ETOPO5PxPerDegree - 1 Step ETOPO5PxPerDegree
            ProgressLabel.SetValue(i + 1)
            My.Application.DoEvents()
            Dim sk2 As Integer
            If sk < 0 Then
                sk2 = (sk + 360) * ETOPO5PxPerDegree
            Else
                sk2 = sk * ETOPO5PxPerDegree
            End If
            For k As Integer = 0 To ETOPO5PxPerDegree - 1
                For j As Integer = 0 To XYSize.Height * ETOPO5PxPerDegree - 1
                    Dim EtopoX As Integer = sk2 + k
                    Dim ETopoY As Integer = (-GlobalRange.SouthEast.Latitude + 90) * ETOPO5PxPerDegree - j
                    Dim n As Integer = EtopoX + ETopoY * 4320
                    ContourMesh.SetMeshValue(i + k, j, Mesh(n))

                    'Dim v As Short
                    'Dim Pen As SolidBrush
                    'If Mesh(n) < 0 Then
                    '    v = 0
                    '    Pen = New SolidBrush(Color.FromArgb(255, v, v, 255))
                    'Else
                    '    v = (Mesh(n)) / 4500 * 255
                    '    v = Math.Min(v, 255)
                    '    Pen = New SolidBrush(Color.FromArgb(255, v, v, v))
                    'End If
                    'g.FillRectangle(Pen, (i + k), j, 1, 1)
                Next
            Next
            sk += 1
            If sk >= 180 Then
                sk = -180
            End If
        Next
        'g.Dispose()
        'PictureBox1.Image = canvas
        'PictureBox1.Refresh()

        Dim Con_Point() As PointF
        Dim Con_LineStac() As clsMeshContour.ContourLineStacInfo
        Dim ConLineN As Integer
        Dim Frame_Point() As PointF
        Dim Frame_LineStac() As Integer
        Dim FrameLineN As Integer


        ConLineN = ContourMesh.Execute_Mesh(Height_Num, High_M, Con_LineStac, Con_Point)
        Call Convert_Mpline_fromMeshData(ConLineN, Con_LineStac, Con_Point)
        FrameLineN = ContourMesh.Execute_FrameGet(0, Height_Num, High_M, Frame_LineStac, Frame_Point)
        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
        FrameLineN = ContourMesh.Execute_FrameGet(1, Height_Num, High_M, Frame_LineStac, Frame_Point)
        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
        FrameLineN = ContourMesh.Execute_FrameGet(2, Height_Num, High_M, Frame_LineStac, Frame_Point)
        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
        FrameLineN = ContourMesh.Execute_FrameGet(3, Height_Num, High_M, Frame_LineStac, Frame_Point)
        Call Convert_Mpline_fromFrameData(FrameLineN, Frame_LineStac, Frame_Point)
        ProgressLabel.Finish()
        Return True
    End Function
    Private Function Get_MeshFile_FileStream(Fname As String, ByRef Alti() As Byte, ByVal ByteSize As Integer) As Boolean

        Dim fs As System.IO.FileStream
        Try
            fs = New System.IO.FileStream(Fname, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Dim fileSize As Integer = CInt(fs.Length) ' ファイルのサイズ
            ReDim Alti(ByteSize - 1)  ' データ格納用配列

            fs.Read(Alti, 0, ByteSize)
            fs.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            fs.Close()
            Return False
        End Try
        Return True
    End Function



    ''' <summary>
    ''' 緯度経度等高線から地図ファイルの座標へ変換、ライン・オブジェクトの設定
    ''' </summary>
    ''' <param name="ConLineN"></param>
    ''' <param name="Con_LineStac"></param>
    ''' <param name="Con_Point"></param>
    ''' <remarks></remarks>
    Private Sub Convert_Mpline_fromMeshData(ByVal ConLineN As Integer, ByRef Con_LineStac() As clsMeshContour.ContourLineStacInfo,
                                            ByRef Con_Point() As PointF)

        Dim ContourN() As Integer

        Dim FAlin As Integer = ContourMap.Map.ALIN

        ReDim ContourN(Height_Num - 1)
        For i As Integer = 0 To ConLineN - 1
            ContourN(Con_LineStac(i).Number) += 1
        Next


        'ProgressLabel.Visible = True
        'ProgressLabel.Start(Height_Num, "メッシュ標高抽出処理中")

        For i As Integer = 0 To Height_Num - 1
            'ProgressLabel.SetValue i
            If ContourN(i) > 0 Then
                Dim newObj As clsMapData.strObj_Data = ContourMap.MPObj(i)
                For j As Integer = 0 To ConLineN - 1
                    If Con_LineStac(j).Number = i Then
                        Dim s As Integer = Con_LineStac(j).PointStac
                        Dim n As Integer = Con_LineStac(j).PointNum
                        Dim newLine As clsMapData.strLine_Data = ContourMap.Init_One_Line(i)
                        With newLine
                            .NumOfPoint = n
                            .LineTimeSTC(0).Kind = i
                            ReDim .PointSTC(n - 1)
                            For k As Integer = 0 To n - 1
                                .PointSTC(k) = spatial.Get_Converted_XY(Con_Point(k + s), ContourMap.Map.Zahyo)
                            Next
                        End With
                        ContourMap.Save_Line(newLine, False, False, False)

                        With newObj
                            .NumOfLine += 1
                            ReDim Preserve .LineCodeSTC(.NumOfLine - 1)
                            .LineCodeSTC(.NumOfLine - 1).LineCode = ContourMap.Map.ALIN - 1
                        End With
                    End If
                Next
                With newObj
                    If .NumOfLine > 0 Then
                        Dim CP As PointF
                        With ContourMap.MPLine(.LineCodeSTC(0).LineCode)
                            CP = .PointSTC(.NumOfPoint \ 2)
                        End With
                        .CenterPSTC(0).Position = CP
                    End If
                End With
                ContourMap.Save_Object(newObj, False)
            End If
        Next
        'ProgressLabel.Visible = False

    End Sub
    ''' <summary>
    ''' 枠線データから座標変換、ライン作成・オブジェクトへの追加
    ''' </summary>
    ''' <param name="FrameLineN"></param>
    ''' <param name="Frame_LineContour"></param>
    ''' <param name="FrameLine_Point"></param>
    ''' <remarks></remarks>
    Private Sub Convert_Mpline_fromFrameData(ByVal FrameLineN As Integer, ByVal Frame_LineContour() As Integer,
                                             ByVal FrameLine_Point() As PointF)


        Dim LK As Integer = ContourMap.Map.LpNum - 1
        For i As Integer = 0 To FrameLineN - 2
            Dim newLine As clsMapData.strLine_Data = ContourMap.Init_One_Line(LK)
            With newLine
                .NumOfPoint = 2
                ReDim .PointSTC(1)
                .PointSTC(0) = spatial.Get_Converted_XY(FrameLine_Point(i), ContourMap.Map.Zahyo)
                .PointSTC(1) = spatial.Get_Converted_XY(FrameLine_Point(i + 1), ContourMap.Map.Zahyo)
            End With
            ContourMap.Save_Line(newLine, False, False, False)

            Dim j As Integer = Frame_LineContour(i)
            '既存の等高線の枠線オブジェクトに追加する
            With ContourMap.MPObj(FrameObjectStart + j + 1)
                ReDim Preserve .LineCodeSTC(.NumOfLine)
                With .LineCodeSTC(.NumOfLine)
                    .LineCode = newLine.Number
                    .NumOfTime = 0
                End With
                If .NumOfLine = 0 Then
                    .CenterPSTC(0).Position = ContourMap.MPLine(newLine.Number).PointSTC(0)
                End If
                .NumOfLine += 1
            End With
        Next
    End Sub
    ''' <summary>
    ''' 世界データの経度・緯度幅を取得
    ''' </summary>
    ''' <remarks>Size構造体</remarks>
    Private Function Get_SRTM_WHDegree() As Size
        Dim w As Integer
        Dim h As Integer
        With GlobalRange
            Dim i As Integer
            i = .NorthWest.Longitude
            'w = 0
            'Do
            '    i += 1
            '    w += 1
            '    If i = 180 Then
            '        i = -180
            '    End If
            'Loop Until i = .SouthEast.Longitude
            w = .SouthEast.Longitude - .NorthWest.Longitude
            h = Math.Abs(.NorthWest.Latitude - .SouthEast.Latitude)
        End With
        Return New Size(w, h)
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Height_Num = 0 Then
            MsgBox("取得する等高線を指定してください。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
        If FolderSelector.Folder = "" Then
            MsgBox("フォルダを指定してください。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
        If System.IO.Directory.Exists(FolderSelector.Folder) = False Then
            MsgBox("フォルダが存在しません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
        If mouseRangeMode <> enmMouseRangeMode.EndPointSet Then
            MsgBox("取得範囲を指定してください。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
        MeshDataSet(getSelectedMeshDataIndex).Folder = FolderSelector.Folder
        SelectedMeshData = getSelectedMeshData()

        With clsSettings.Data.Directory
            Select Case SelectedMeshData.name
                Case enmMeshName.suchi50m
                    .SuchiTizu50Mesh = SelectedMeshData.Folder
                Case enmMeshName.suchi250m
                    .SuchiTizu250Mesh = SelectedMeshData.Folder
                Case enmMeshName.suchi1km
                    .SuchiTizu1kMesh = SelectedMeshData.Folder
                Case enmMeshName.kiban5m
                    .Kiban5mMesh = SelectedMeshData.Folder
                Case enmMeshName.kiban10m
                    .Kiban10mMesh = SelectedMeshData.Folder
                Case enmMeshName.SRTM30
                    .SRTM30Plus = SelectedMeshData.Folder
                Case enmMeshName.SRTM3
                    .SRTM3 = SelectedMeshData.Folder
                Case enmMeshName.AsterGdem
                    .ASTERGDEM = SelectedMeshData.Folder
                Case enmMeshName.ETOPO5
                    .ETOPO5 = SelectedMeshData.Folder
            End Select
        End With

        Select Case SelectedMeshData.Area
            Case enmMeshArea.Japan
                If mouseRangeEndPoint.X < mouseRangeStartPoint.X Then
                    GlobalRange.NorthWest.Longitude = mouseRangeEndPoint.X
                    GlobalRange.SouthEast.Longitude = mouseRangeStartPoint.X
                Else
                    GlobalRange.NorthWest.Longitude = mouseRangeStartPoint.X
                    GlobalRange.SouthEast.Longitude = mouseRangeEndPoint.X
                End If
                If mouseRangeEndPoint.Y < mouseRangeStartPoint.Y Then
                    GlobalRange.NorthWest.Latitude = mouseRangeStartPoint.Y
                    GlobalRange.SouthEast.Latitude = mouseRangeEndPoint.Y
                Else
                    GlobalRange.NorthWest.Latitude = mouseRangeEndPoint.Y
                    GlobalRange.SouthEast.Latitude = mouseRangeStartPoint.Y
                End If
            Case enmMeshArea.World
                Dim SP As Point, EP As Point
                getRangeWorldFloor(mouseRangeStartPoint, mouseRangeEndPoint, SP, EP)
                If SP.Y < EP.Y Then
                    clsGeneric.SWAP(SP.Y, EP.Y)
                End If
                If EP.X < SP.X Then
                    EP.X = EP.X + 360
                End If
                With GlobalRange
                    .NorthWest = New strLatLon(SP)
                    .SouthEast = New strLatLon(EP)
                End With
        End Select


        Call init_Obk_LKind()
        With ContourMap.Map
            .Comment = SelectedMeshData.Title + "より作成"
            Select Case SelectedMeshData.name
                Case enmMeshName.suchi50m, enmMeshName.suchi250m, enmMeshName.suchi1km
                    .Zahyo.System = enmZahyo_System_Info.Zahyo_System_tokyo
                Case Else
                    .Zahyo.System = enmZahyo_System_Info.Zahyo_System_World
            End Select
            .Zahyo.Projection = clsSettings.Data.default_Projection
            .Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido
            .SCL = 1
            .SCL_U = enmScaleUnit.kilometer
            .Zahyo.CenterXY = spatial.Get_CenterPoint_of_Rect(GlobalRange.toRectangleF)
            .FileName = SelectedMeshData.Title + "Contour"
            .FullPath = ""
        End With
        ContourMap.NoDataFlag = False
        Dim f As Boolean
        Select Case SelectedMeshData.Area
            Case enmMeshArea.Japan
                f = Get_Suchi_Kiban_Mesh_File()
            Case enmMeshArea.World

                Select Case SelectedMeshData.name
                    Case enmMeshName.AsterGdem
                        f = Get_ASTERGDEM_Mesh_File()
                    Case enmMeshName.SRTM3, enmMeshName.SRTM30
                        f = Get_SRTM_Mesh_File()
                    Case enmMeshName.ETOPO5
                        f = Get_ETOPO5_Mesh_File()
                End Select
        End Select
        If ContourMap.Map.ALIN = 0 Then
            MsgBox("指定したデータ・範囲のファイルが存在しません。", MsgBoxStyle.Exclamation)
            f = False
        End If
        If f = False Then
            ContourMap.NoDataFlag = True
            CloseCancelF = True
            Return
        End If
        ProgressLabel.Start(8, "データ処理中", False)
        ProgressLabel.SetValue(1)
        ContourMap.Check_ALl_Line_Connect()
        ProgressLabel.SetValue(2)
        ContourMap.Checl_All_Line_Maxmin()

        ProgressLabel.SetValue(3)
        Call PolygonContourMake()

        ProgressLabel.SetValue(4)
        ContourMap.Check_All_Obj_MaxMin()

        ProgressLabel.SetValue(5)
        ContourMap.Erase_Irregular_Object()
        ProgressLabel.SetValue(6)
        ContourMap.CheckLine_Kind_UsedBy_ObjectKind(ObjectUseLineInfo)

        ProgressLabel.SetValue(7)
        ContourMap.Erase_Non_Use_Linekind()
        ContourMap.Map.Circumscribed_Rectangle = ContourMap.Get_Mapfile_Rectangle
        ContourMap.init_Compass_First()
        ProgressLabel.Finish()
    End Sub
    ''' <summary>
    ''' オブジェクトグループ・線種・オブジェクトの作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub init_Obk_LKind()

        With ContourMap
            .Map.OBKNum = 0
            '等高線の線形状オブジェクトグループ
            .Add_OneObjectGroup_Parameter("等高線", enmShape.LineShape, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
            .Add_one_DefAttDataSet(0, "標高", "CAT", "")
            ObjectUseLineInfo += .ObjectKind(0).Name + vbTab

            For i As Integer = 0 To Height_Num - 1
                .Add_OneLineKind(CStr(High_M(i)) & "m等高線", clsBase.Line, enmMesh_Number.mhNonMesh)
                ObjectUseLineInfo += CStr(High_M(i)) & "m等高線" + vbTab
            Next
            ObjectUseLineInfo += vbCr

            '等高線領域枠線の線形状オブジェクトグループ
            .Add_OneObjectGroup_Parameter("枠線", enmShape.LineShape, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
            .Add_OneLineKind("等高線領域枠線", clsBase.Line, enmMesh_Number.mhNonMesh)
            ObjectUseLineInfo += .ObjectKind(.Map.OBKNum - 1).Name + vbTab & "等高線領域枠線"
            ObjectUseLineInfo += vbCr

            '等高線面領域オブジェクトグループ
            .Add_OneObjectGroup_Parameter("等高線（面）", enmShape.PolygonShape, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
            Dim Obk As Integer = .Map.OBKNum - 1
            .Add_one_DefAttDataSet(Obk, "標高", "CAT", "")
            .Add_one_DefAttDataSet(Obk, "最低標高", "m", "")
            ObjectUseLineInfo += "等高線（面）" & vbTab
            For i As Integer = 0 To .Map.LpNum - 1
                ObjectUseLineInfo += vbTab & .LineKind(i).Name
            Next
            ObjectUseLineInfo += vbCr
        End With

        '等高線の線形状オブジェクト
        For i As Integer = 0 To Height_Num - 1
            Dim newObj As clsMapData.strObj_Data = ContourMap.Init_One_Object(0)
            With newObj
                .Shape = enmShape.LineShape
                .NameTimeSTC(0).NamesList(0) = CStr(High_M(i)) & "m等高線"
                .DefTimeAttValue(0).Data(0).Value = CStr(High_M(i)) & "m等高線"
            End With
            ContourMap.Save_Object(newObj, False)
        Next

        ''等高線領域枠線の線形状オブジェクト
        FrameObjectStart = ContourMap.Map.Kend
        For i As Integer = -1 To Height_Num - 1
            Dim fObject As clsMapData.strObj_Data = ContourMap.Init_One_Object(1)
            With fObject
                .Shape = enmShape.LineShape
                With .NameTimeSTC(0)
                    Select Case i
                        Case -1
                            .NamesList(0) = "～" & CStr(High_M(0)) & "m"
                        Case Height_Num - 1
                            .NamesList(0) = CStr(High_M(i)) & "m～"
                        Case Else
                            .NamesList(0) = CStr(High_M(i)) & "～" & CStr(High_M(i + 1)) & "m"
                    End Select
                End With
            End With
            ContourMap.Save_Object(fObject, False)
        Next

        '等高線面領域オブジェクト
        PolygonObjectStart = ContourMap.Map.Kend
        For i As Integer = -1 To Height_Num - 1
            Dim polyObj As clsMapData.strObj_Data = ContourMap.Init_One_Object(2)
            With polyObj
                .Shape = enmShape.PolygonShape
                With .NameTimeSTC(0)
                    Select Case i
                        Case -1
                            .NamesList(0) = "～" & CStr(High_M(0)) & "m（面）"
                        Case Height_Num - 1
                            .NamesList(0) = CStr(High_M(i)) & "m～（面）"
                        Case Else
                            .NamesList(0) = CStr(High_M(i)) & "～" & CStr(High_M(i + 1)) & "m（面）"
                    End Select
                End With
                ContourMap.Save_Object(polyObj, False)
            End With
        Next
    End Sub
    ''' <summary>
    ''' 面形状等高線オブジェクト作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PolygonContourMake()

        For i As Integer = 0 To Height_Num
            With ContourMap.MPObj(PolygonObjectStart + i)
                Dim oname As String = .NameTimeSTC(0).NamesList(0)
                .DefTimeAttValue(0).Data(0).Value = Microsoft.VisualBasic.Left(oname, Len(oname) - 3)
                If i <> 0 Then
                    .DefTimeAttValue(1).Data(0).Value = High_M(i - 1).ToString
                Else
                    .DefTimeAttValue(1).Data(0).Value = "-10000"
                End If
                'まず枠線オブジェクトから使用ラインをコピー
                .NumOfLine = ContourMap.MPObj(FrameObjectStart + i).NumOfLine
                If .NumOfLine <> 0 Then
                    .LineCodeSTC = ContourMap.MPObj(FrameObjectStart + i).LineCodeSTC.Clone
                End If
                If i <> 0 Then
                    '一番下位でない場合は、1つ下の等高線線オブジェクトから使用ラインをコピーして追加
                    Dim conLineObj As clsMapData.strObj_Data = ContourMap.MPObj(i - 1)
                    ReDim Preserve .LineCodeSTC(.NumOfLine + conLineObj.NumOfLine)
                    For j As Integer = 0 To ContourMap.MPObj(i - 1).NumOfLine - 1
                        .LineCodeSTC(j + .NumOfLine) = conLineObj.LineCodeSTC(j)
                    Next
                    .NumOfLine += conLineObj.NumOfLine
                End If
                If i <> Height_Num Then
                    '一番上位でない場合は、同位置の等高線線オブジェクトから使用ラインをコピーして追加
                    Dim conLineObj As clsMapData.strObj_Data = ContourMap.MPObj(i)
                    ReDim Preserve .LineCodeSTC(.NumOfLine + conLineObj.NumOfLine)
                    For j As Integer = 0 To conLineObj.NumOfLine - 1
                        .LineCodeSTC(j + .NumOfLine) = conLineObj.LineCodeSTC(j)
                    Next
                    .NumOfLine += conLineObj.NumOfLine
                End If
                Dim CutP As PointF
                Dim sp As enmShape
                sp = ContourMap.Check_Obj_Shape(ContourMap.MPObj(PolygonObjectStart + i), clsTime.GetYMD(0, 0, 0), CutP)
                .Shape = sp
                With .CenterPSTC(0)
                    If sp = enmShape.PolygonShape Then
                        ContourMap.GetObjGraviityXY(ContourMap.MPObj(PolygonObjectStart + i), .Position, clsTime.GetYMD(0, 0, 0))
                    Else
                        .Position = CutP
                    End If
                End With

            End With
        Next
    End Sub

    Private Sub frmMED_MeshContour_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_MeshContour", Me)
        e.Cancel = True
    End Sub

    Private Sub frmMED_MeshContour_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AcceptButton = btnOK
        ReDim MeshDataSet(8)
        Dim Mdata As MeshDataInfo
        With Mdata
            .name = enmMeshName.suchi50m
            .Title = "数値地図50mメッシュ"
            .Area = enmMeshArea.Japan
            .JapanMeshSystem = enmMesh_Number.mhSecond
            .JapanMeshSize = New Size(200, 200)
            .WorldPxPerDegree = -1
            .Folder = clsSettings.Data.Directory.SuchiTizu50Mesh
        End With
        MeshDataSet(0) = Mdata
        With Mdata
            .name = enmMeshName.suchi250m
            .Title = "数値地図250mメッシュ"
            .Area = enmMeshArea.Japan
            .JapanMeshSystem = enmMesh_Number.mhFirst
            .JapanMeshSize = New Size(320, 320)
            .WorldPxPerDegree = -1
            .Folder = clsSettings.Data.Directory.SuchiTizu250Mesh
        End With
        MeshDataSet(1) = Mdata
        With Mdata
            .name = enmMeshName.suchi1km
            .Title = "数値地図1kmメッシュ"
            .Area = enmMeshArea.Japan
            .JapanMeshSystem = enmMesh_Number.mhFirst
            .JapanMeshSize = New Size(80, 80)
            .WorldPxPerDegree = -1
            .Folder = clsSettings.Data.Directory.SuchiTizu1kMesh
        End With
        MeshDataSet(2) = Mdata
        With Mdata
            .name = enmMeshName.kiban5m
            .Title = "基盤地図情報5mメッシュ"
            .Area = enmMeshArea.Japan
            .JapanMeshSystem = enmMesh_Number.mhThird
            .JapanMeshSize = New Size(225, 150)
            .WorldPxPerDegree = -1
            .Folder = clsSettings.Data.Directory.Kiban5mMesh
        End With
        MeshDataSet(3) = Mdata
        With Mdata
            .name = enmMeshName.kiban10m
            .Title = "基盤地図情報10mメッシュ"
            .Area = enmMeshArea.Japan
            .JapanMeshSystem = enmMesh_Number.mhSecond
            .JapanMeshSize = New Size(1125, 750)
            .WorldPxPerDegree = -1
            .Folder = clsSettings.Data.Directory.Kiban10mMesh
        End With
        MeshDataSet(4) = Mdata
        With Mdata
            .name = enmMeshName.SRTM30
            .Title = "SRTM30/30Plus（変換後）"
            .Area = enmMeshArea.World
            .JapanMeshSystem = -1
            .JapanMeshSize = New Size(0, 0)
            .WorldPxPerDegree = 120
            .Folder = clsSettings.Data.Directory.SRTM30Plus
        End With
        MeshDataSet(5) = Mdata
        With Mdata
            .name = enmMeshName.SRTM3
            .Title = "SRTM3"
            .Area = enmMeshArea.World
            .JapanMeshSystem = -1
            .JapanMeshSize = New Size(0, 0)
            .WorldPxPerDegree = 1201
            .Folder = clsSettings.Data.Directory.SRTM3
        End With
        MeshDataSet(6) = Mdata
        With Mdata
            .name = enmMeshName.AsterGdem
            .Title = "ASTER GDEM"
            .Area = enmMeshArea.World
            .JapanMeshSystem = -1
            .JapanMeshSize = New Size(0, 0)
            .WorldPxPerDegree = 3601
            .Folder = clsSettings.Data.Directory.ASTERGDEM
        End With
        MeshDataSet(7) = Mdata
        With Mdata
            .name = enmMeshName.ETOPO5
            .Title = "ETOPO5"
            .Area = enmMeshArea.World
            .JapanMeshSystem = -1
            .JapanMeshSize = New Size(0, 0)
            .WorldPxPerDegree = 12
            .Folder = clsSettings.Data.Directory.ETOPO5
        End With
        MeshDataSet(8) = Mdata

        Dim exeFolder As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        WorldMap = New clsMapData(exeFolder + "\world_indexfile.mpfz")
        JapanMap = New clsMapData(exeFolder + "\japan_indexfile.mpfz")
        With cboMeshData
            With .Items
                .Clear()
                For i As Integer = 0 To MeshDataSet.Length - 1
                    .Add(MeshDataSet(i).Title)
                Next
            End With
            Me.Tag = "OFF"
            .SelectedIndex = 3
            Me.Tag = ""
        End With

        Me.Tag = "OFF"
        With cboBackImage
            With .Items
                .Add("背景画像なし")
                .Add("地理院地図（標準地図）")
                .Add("オープンストリートマップ")
            End With
            .SelectedIndex = 0
        End With
        Me.Tag = ""

        With TileMapView
            .visible = False
            With .ViewData
                .TileMapDataSet = TileMap.getTileMap_by_Name("地理院地図（標準地図）")
                .AlphaValue = 255
                .LastUserFolder = ""
                .LastWorldFileFolder = ""
                .TransparentF = False
            End With
        End With

        lblPos.Text = ""
    End Sub

    Private Sub frmMED_MeshContour_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        WorldScrData.init(picMap, New ScreenMargin(3, 3, 3, 3, False), WorldMap.Map.Circumscribed_Rectangle, enmBasePosition.Screen, True)
        JapanScrData.init(picMap, New ScreenMargin(3, 3, 3, 3, False), JapanMap.Map.Circumscribed_Rectangle, enmBasePosition.Screen, True)
        mousePointingSituation = mousePointingSituations.up
        SelectedMeshData = getSelectedMeshData()
        If SelectedMeshData.Area = enmMeshArea.Japan Then
            MapData = JapanMap
            ScrData = JapanScrData
        Else
            MapData = WorldMap
            ScrData = WorldScrData
        End If
        FolderSelector.Folder = SelectedMeshData.Folder
        printMap()
    End Sub
    Private Function getSelectedMeshDataIndex() As Integer
        For i As Integer = 0 To MeshDataSet.Length - 1
            If cboMeshData.Text = MeshDataSet(i).Title Then
                Return i
            End If
        Next
    End Function

    Private Function getSelectedMeshData() As MeshDataInfo
        For i As Integer = 0 To MeshDataSet.Length - 1
            If cboMeshData.Text = MeshDataSet(i).Title Then
                Return MeshDataSet(i)
            End If
        Next
    End Function
    ''' <summary>
    ''' 地図描画
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub printMap()
        picMapImageOperation = New clsPictureBoxDragOrWheelImageChange(picMap)
        ScrData.Set_PictureBox_and_CulculateMul(picMap)
        '描画先とするImageオブジェクトを作成する
        Dim canvas As New Bitmap(picMap.Width, picMap.Height)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)
        If TileMapView.visible = True Then
            With TileMapView.ViewData
                TileMap.PrintTMS(g, .TileMapDataSet, .TransparentF, .AlphaValue, clsSettings.Data.BackImageSpeed, MapData, ScrData)
            End With
        End If
        Dim lonlatLine1 As Line_Property = clsBase.Line
        lonlatLine1.BasicLine.SolidLine.Color.setColor(Color.FromArgb(&HA0, &HA0, &HF0))
        Dim lonlatLine2 As Line_Property = clsBase.Line
        lonlatLine2.BasicLine.SolidLine.Color.setColor(Color.FromArgb(&H20, &H20, &HA0))
        lonlatLine2.BasicLine.SolidLine.Width = 0.5
        Dim westP As PointF = spatial.Get_Reverse_XY(New PointF(ScrData.ScrView.Left, ScrData.ScrRectangle.Top), MapData.Map.Zahyo)
        Dim eastP As PointF = spatial.Get_Reverse_XY(New PointF(ScrData.ScrView.Right, ScrData.ScrRectangle.Bottom), MapData.Map.Zahyo)
        Dim w As Single = eastP.X - westP.X
        If SelectedMeshData.Area = enmMeshArea.Japan Then
            '日本のメッシュデータ
            If SelectedMeshData.name = enmMeshName.kiban5m Then
                If w < 1 Then
                    '5mメッシュの場合は3次メッシュ
                    Dim thirdMeshLine As Line_Property = clsBase.Line
                    thirdMeshLine.BasicLine.SolidLine.Color.setColor(Color.FromArgb(&HA0, &HF0, &HF0))
                    Dim westP2 As PointF
                    Dim eastP2 As PointF
                    westP2.X = Int(westP.X / (7.5 / 60)) * 7.5 / 60
                    westP2.Y = Int(westP.Y / (5 / 60) + 1) * 5 / 60
                    eastP2.X = Int(eastP.X / (7.5 / 60) + 1) * 7.5 / 60
                    eastP2.Y = Int(eastP.Y / (5 / 60)) * 5 / 60
                    For x As Single = westP2.X To eastP2.X Step 45 / 3600
                        Dim pa As Point = ScrData.getSxSy(New PointF(x, westP2.Y), MapData.Map)
                        Dim pb As Point = ScrData.getSxSy(New PointF(x, eastP2.Y), MapData.Map)
                        clsDrawLine.Line(g, thirdMeshLine, pa, pb, ScrData, clsBase.PictureNoUse)
                    Next
                    For y As Single = eastP2.Y To westP2.Y Step 30 / 3600
                        Dim pa As Point = ScrData.getSxSy(New PointF(westP2.X, y), MapData.Map)
                        Dim pb As Point = ScrData.getSxSy(New PointF(eastP2.X, y), MapData.Map)
                        clsDrawLine.Line(g, thirdMeshLine, pa, pb, ScrData, clsBase.PictureNoUse)
                    Next
                End If
            End If
            '1次メッシュ経線の表示
            For i As Integer = 123 To 154
                Dim pa As Point = ScrData.getSxSy(New PointF(i, 20), MapData.Map)
                Dim pb As Point = ScrData.getSxSy(New PointF(i, 46), MapData.Map)
                Dim Lpat As Line_Property
                If i Mod 5 = 0 Then
                    Lpat = lonlatLine2
                Else
                    Lpat = lonlatLine1
                End If
                clsDrawLine.Line(g, Lpat, pa, pb, ScrData, clsBase.PictureNoUse)
            Next
            '1次メッシュ緯線の表示
            For i As Integer = 0 To 39
                Dim lat As Single = i * 4 / 6 + 20
                Dim Lpat As Line_Property
                If lat Mod 10 = 0 Then
                    Lpat = lonlatLine2
                Else
                    Lpat = lonlatLine1
                End If
                Dim pa As Point = ScrData.getSxSy(New PointF(123, lat), MapData.Map)
                Dim pb As Point = ScrData.getSxSy(New PointF(154, lat), MapData.Map)
                clsDrawLine.Line(g, Lpat, pa, pb, ScrData, clsBase.PictureNoUse)
            Next

        Else
            '世界のメッシュデータ
            Dim st As Integer
            Dim st2 As Integer
            Select Case True
                Case w < 45
                    st = 1
                    st2 = 5
                Case w < 90
                    st = 3
                    st2 = 15
                Case w < 135
                    st = 5
                    st2 = 45
                Case Else
                    st = 10
                    st2 = 90
            End Select
            '経線の表示
            For i As Integer = -180 To 180 Step st
                Dim Lpat As Line_Property
                If i Mod st2 = 0 Then
                    Lpat = lonlatLine2
                Else
                    Lpat = lonlatLine1
                End If
                Dim pa As Point = ScrData.getSxSy(New Point(i, -90), MapData.Map)
                Dim pb As Point = ScrData.getSxSy(New Point(i, 90), MapData.Map)
                clsDrawLine.Line(g, Lpat, pa, pb, ScrData, clsBase.PictureNoUse)
            Next
            '緯線の表示
            For i As Integer = -90 To 90 Step st
                Dim Lpat As Line_Property
                If i Mod st2 = 0 Then
                    Lpat = lonlatLine2
                Else
                    Lpat = lonlatLine1
                End If
                Dim pa As Point = ScrData.getSxSy(New Point(-180, i), MapData.Map)
                Dim pb As Point = ScrData.getSxSy(New Point(180, i), MapData.Map)
                clsDrawLine.Line(g, Lpat, pa, pb, ScrData, clsBase.PictureNoUse)
            Next
        End If

        '地図の表示
        For i As Integer = 0 To MapData.Map.ALIN - 1
            Dim xy() As Point
            Dim f As Boolean = True
            If SelectedMeshData.Area = enmMeshArea.Japan Then
                '日本の場合はメッシュライン表示
                Dim m As enmMesh_Number = MapData.LineKind(MapData.MPLine(i).LineTimeSTC(0).Kind).Mesh
                Select Case SelectedMeshData.name
                    Case enmMeshName.kiban5m, enmMeshName.kiban10m, enmMeshName.suchi50m
                        If m = enmMesh_Number.mhFirst Then
                            f = False
                        End If
                    Case Else
                        If m = enmMesh_Number.mhSecond Then
                            f = False
                        End If
                End Select
            End If
            If f = True Then
                With MapData.MPLine(i)
                    xy = ScrData.getSxSy(.NumOfPoint, .PointSTC, False, True)
                End With
                clsDrawLine.Line(g, clsBase.Line, xy.Length, xy, ScrData, clsBase.PictureNoUse)
            End If
        Next
        If mouseRangeMode = enmMouseRangeMode.EndPointSet Then
            printSelectRange(g)
        End If
        'リソースを解放する
        g.Dispose()
        If picMap.Image Is Nothing = False Then
            picMap.Image.Dispose()
        End If
        picMap.Image = canvas
        picMap.Refresh()
    End Sub
    Private Sub printSelectRange(ByRef g As Graphics)
        Select Case mouseRangeMode
            Case enmMouseRangeMode.noPointSet
            Case enmMouseRangeMode.startPointSet
                Select Case SelectedMeshData.Area
                    Case enmMeshArea.Japan
                        printSelectRangeJapan(g, mouseRangeMovingPoint)
                    Case enmMeshArea.World
                        printSelectRangeWorld(g, mouseRangeMovingPoint)
                End Select
            Case enmMouseRangeMode.EndPointSet
                Select Case SelectedMeshData.Area
                    Case enmMeshArea.Japan
                        printSelectRangeJapan(g, mouseRangeEndPoint)
                    Case enmMeshArea.World
                        printSelectRangeWorld(g, mouseRangeEndPoint)
                End Select
        End Select
    End Sub
    Private Sub printSelectRangeJapan(ByRef g As Graphics, ByVal endp As PointF)
        Dim Brush As New SolidBrush(Color.FromArgb(150, 255, 200, 100))
        Dim Pen As New Pen(Color.Red)

        Dim rect As RectangleF = spatial.Get_Circumscribed_Rectangle(mouseRangeStartPoint, endp)
        Dim sp As PointF = New PointF(rect.Left, rect.Top)
        Dim ep As PointF = New PointF(rect.Right, rect.Bottom)
        Dim SMesh As strLatLonBox
        Dim EMesh As strLatLonBox
        Dim meshSize As enmMesh_Number = SelectedMeshData.JapanMeshSystem

        SMesh = spatial.Get_Ido_Kedo_from_MeshCode(spatial.Get_MeshCode_from_LatLon(New strLatLon(sp), meshSize), meshSize)
        EMesh = spatial.Get_Ido_Kedo_from_MeshCode(spatial.Get_MeshCode_from_LatLon(New strLatLon(ep), meshSize), meshSize)
        Dim SSpoint As Point = ScrData.getSxSy(New PointF(Math.Min(SMesh.NorthWest.Longitude, EMesh.NorthWest.Longitude), Math.Max(SMesh.NorthWest.Latitude, EMesh.NorthWest.Latitude)), MapData.Map)
        Dim SEpoint As Point = ScrData.getSxSy(New PointF(Math.Max(SMesh.SouthEast.Longitude, EMesh.SouthEast.Longitude), Math.Min(SMesh.SouthEast.Latitude, EMesh.SouthEast.Latitude)), MapData.Map)
        'Dim SSpoint As Point = ScrData.getSxSy(SMesh.NorthWest.toPointF, MapData.Map)
        'Dim SEpoint As Point = ScrData.getSxSy(EMesh.SouthEast.toPointF, MapData.Map)
        Dim rect2 As Rectangle = spatial.Get_Circumscribed_Rectangle(SSpoint, SEpoint)
        g.FillRectangle(Brush, rect2)
        g.DrawRectangle(Pen, rect2)
        Brush.Dispose()
        Pen.Dispose()
    End Sub
    Private Sub printSelectRangeWorld(ByRef g As Graphics, ByVal ep As PointF)
        Dim Brush As New SolidBrush(Color.FromArgb(150, 255, 200, 100))
        Dim Pen As New Pen(Color.Red)
        If Int(mouseRangeStartPoint.X) = Int(ep.X) And Int(mouseRangeStartPoint.Y) = Int(ep.Y) Or
             mouseRangeStartPoint.X < ep.X Then
            '世界地図で、始点が終点よりも右側の場合または、整数値で緯度経度が同じ場合
            Dim S1 As Point
            Dim e1 As Point
            printSelectRangeWorld_Sub(mouseRangeStartPoint, ep, S1, e1)
            Dim rect As Rectangle = spatial.Get_Circumscribed_Rectangle(S1, e1)
            g.FillRectangle(Brush, rect)
            g.DrawRectangle(Pen, rect)
        Else
            '世界地図で、始点が終点よりも左側の場合
            Dim S1 As Point
            Dim e1 As Point
            printSelectRangeWorld_Sub(mouseRangeStartPoint, New PointF(179, ep.Y), S1, e1)
            Dim rect As Rectangle = spatial.Get_Circumscribed_Rectangle(S1, e1)
            g.FillRectangle(Brush, rect)
            g.DrawRectangle(Pen, rect)
            printSelectRangeWorld_Sub(New PointF(-180, mouseRangeStartPoint.Y), ep, S1, e1)
            rect = spatial.Get_Circumscribed_Rectangle(S1, e1)
            g.FillRectangle(Brush, rect)
            g.DrawRectangle(Pen, rect)
        End If
        Brush.Dispose()
        Pen.Dispose()

    End Sub
    Private Sub printSelectRangeWorld_Sub(ByVal OriginS As PointF, ByVal OriginE As PointF, ByRef SP As Point, ByRef EP As Point)
        Dim SSP As Point, EEP As Point
        getRangeWorldFloor(OriginS, OriginE, SSP, EEP)
        SP = ScrData.getSxSy(SSP, MapData.Map)
        EP = ScrData.getSxSy(EEP, MapData.Map)

    End Sub
    Private Sub getRangeWorldFloor(ByVal OriginS As PointF, ByVal OriginE As PointF, ByRef SP As Point, ByRef EP As Point)
        If OriginS.Y < OriginE.Y Then
            SP = New Point(Math.Floor(OriginS.X), Math.Floor(OriginS.Y))
            EP = New Point(Math.Floor(OriginE.X) + 1, Math.Floor(OriginE.Y) + 1)
        Else
            SP = New Point(Math.Floor(OriginS.X), Math.Floor(OriginS.Y) + 1)
            EP = New Point(Math.Floor(OriginE.X) + 1, Math.Floor(OriginE.Y))
        End If
    End Sub
    Private Sub picMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            mousePointingSituation = mousePointingSituations.down
            mouseDownPosition = e.Location

        End If
    End Sub

    Private Sub picMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseMove


        Static mousePreviousPosition As Point

        Select Case mousePointingSituation
            Case mousePointingSituations.up
                Select Case mouseRangeMode
                    '範囲指定中
                    Case enmMouseRangeMode.startPointSet
                        Dim g As Graphics = picMap.CreateGraphics()
                        picMap.Refresh()
                        printSelectRange(g)
                        g.Dispose()
                End Select
                mouseRangeMovingPoint = spatial.Get_Reverse_XY(ScrData.getSRXY(e.Location), MapData.Map.Zahyo)
                Select Case SelectedMeshData.Area
                    Case enmMeshArea.Japan
                        Dim mcode As Integer = spatial.Get_MeshCode_from_LatLon(New strLatLon(mouseRangeMovingPoint), SelectedMeshData.JapanMeshSystem)
                        lblPos.Text = "メッシュコード:" + mcode.ToString
                    Case enmMeshArea.World
                        Dim PSt As strPointStrings = clsGeneric.Get_PositionCoordinate_Strings(mouseRangeMovingPoint, MapData.Map.Zahyo)
                        lblPos.Text = PSt.y.ToString + " " + PSt.x.ToString
                End Select
                picMap.Focus()
            Case mousePointingSituations.down
                'マウスダウンの直後
                If e.Location.Equals(mouseDownPosition) = False Then
                    '前の座標から移動した場合
                    'ドラッグ用に、現在の地図画面をbackCanvasに待避
                    picMapImageOperation.getPictureImage()
                    mousePreviousPosition = e.Location
                    mousePointingSituation = mousePointingSituations.downAndMove
                End If
            Case mousePointingSituations.downAndMove
                'マウスダウンとドラッグ開始後
                If e.Location.Equals(mousePreviousPosition) = False Then
                    picMapImageOperation.DragPicture(e.Location, mouseDownPosition)
                    mousePreviousPosition = e.Location
                End If
        End Select
        mouseRangeMovingPoint = spatial.Get_Reverse_XY(ScrData.getSRXY(e.Location), MapData.Map.Zahyo)

    End Sub

    Private Sub picMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseUp
        Dim mouseUpPosition As Point = e.Location
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left
                '左クリックの場合－－－－－－－－－－－－－－－－
                Select Case mousePointingSituation
                    Case mousePointingSituations.downAndMove
                        picMapImageOperation.DisposeBackCanvasPictureImage()
                        Dim StartP As PointF = ScrData.getSRXY(mouseDownPosition)
                        Dim EndP As PointF = ScrData.getSRXY(mouseUpPosition)
                        ScrData.ScrView.Offset(StartP.X - EndP.X, StartP.Y - EndP.Y)
                        printMap()
                    Case mousePointingSituations.down
                        '左クリックの場合、範囲指定
                        Select Case mouseRangeMode
                            Case enmMouseRangeMode.noPointSet, enmMouseRangeMode.EndPointSet
                                mouseRangeMode = enmMouseRangeMode.startPointSet
                                mouseRangeStartPoint = spatial.Get_Reverse_XY(ScrData.getSRXY(mouseUpPosition), MapData.Map.Zahyo)
                                mouseRangeMovingPoint = mouseRangeStartPoint
                            Case enmMouseRangeMode.startPointSet
                                mouseRangeEndPoint = spatial.Get_Reverse_XY(ScrData.getSRXY(mouseUpPosition), MapData.Map.Zahyo)
                                mouseRangeMode = enmMouseRangeMode.EndPointSet
                        End Select
                        printMap()
                End Select

            Case Windows.Forms.MouseButtons.Right
                '右クリックは元に戻す
                Select Case mousePointingSituation
                    Case mousePointingSituations.downAndMove
                        picMapImageOperation.DisposeBackCanvasPictureImage()
                        printMap()
                    Case mousePointingSituations.up
                        Select Case mouseRangeMode
                            Case enmMouseRangeMode.startPointSet, enmMouseRangeMode.EndPointSet
                                mouseRangeMode = enmMouseRangeMode.noPointSet
                        End Select
                        printMap()
                End Select
        End Select
        mousePointingSituation = mousePointingSituations.up
    End Sub

    Private Sub picMap_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseWheel
        picMapImageOperation.pictureBoxMouseWheel(e.Location, e.Delta, ScrData)
        printMap()

    End Sub

    Private Sub cboMeshData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMeshData.SelectedIndexChanged
        If Me.Tag <> "OFF" Then
            Dim OS As MeshDataInfo = SelectedMeshData
            SelectedMeshData = getSelectedMeshData()
            FolderSelector.Folder = SelectedMeshData.Folder
            If OS.Area <> SelectedMeshData.Area Then
                If SelectedMeshData.Area = enmMeshArea.Japan Then
                    MapData = JapanMap
                    ScrData = JapanScrData
                Else
                    MapData = WorldMap
                    ScrData = WorldScrData
                End If

            End If
            printMap()
        End If
    End Sub



    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtAltitude.Text = "" Then
            Return
        End If
        If clsGeneric.Check_Suji(txtAltitude.Text) = True Then
            ReDim Preserve High_M(Height_Num)
            High_M(Height_Num) = Val(txtAltitude.Text)
            Height_Num += 1
            setContourList()
            txtAltitude.Text = ""
        Else
            MsgBox("数字以外の文字が含まれています。", MsgBoxStyle.Exclamation)
        End If
        txtAltitude.Focus()
    End Sub
    Private Sub setContourList()
        Array.Sort(High_M)
        With lbContour.Items
            .Clear()
            For i As Integer = 0 To Height_Num - 1
                .Add(High_M(i))
            Next
        End With

    End Sub
    Private Sub btnClipBoard_Click(sender As Object, e As EventArgs) Handles btnClipBoard.Click
        Dim clipText As String = Clipboard.GetText
        If clipText = "" Then
            Dim msgText1 As String = "クリップボードにデータがありません。"
            MsgBox(msgText1, MsgBoxStyle.Exclamation)
            Return
        End If
        clipText = clipText.Replace(vbCrLf, vbTab)
        Dim STR() As String = clipText.Split(vbTab)
        Dim V As New ArrayList
        For i As Integer = 0 To STR.Length - 1
            If clsGeneric.Check_Suji(STR(i)) = True Then
                V.Add(STR(i))
            End If
        Next
        If V.Count = 0 Then
            MsgBox("適切な値がありませんでした。", MsgBoxStyle.Exclamation)
            Return
        Else
            ReDim High_M(V.Count - 1)
            Height_Num = V.Count
            For i As Integer = 0 To Height_Num - 1
                High_M(i) = Val(V.Item(i))
            Next
        End If
        setContourList()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim del As Integer = lbContour.SelectedIndex
        If del = -1 Then
            Return
        End If
        lbContour.Items.RemoveAt(del)
        clsGeneric.ListIndex_Reset(lbContour, del)
        For i As Integer = del To Height_Num - 2
            High_M(i) = High_M(i + 1)
        Next
        Height_Num -= 1
    End Sub

    Private Sub btnAllClear_Click(sender As Object, e As EventArgs) Handles btnAllClear.Click
        lbContour.Items.Clear()
        Height_Num = 0

    End Sub


    Private Sub cboBackImage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBackImage.SelectedIndexChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim T As String
        Select Case cboBackImage.SelectedIndex
            Case 0
                TileMapView.Visible = False
            Case 1
                T = "地理院地図（標準地図）"
                TileMapView.Visible = True
            Case 2
                T = "オープンストリートマップ"
                TileMapView.Visible = True
        End Select
        If TileMapView.Visible = True Then
            With TileMapView.ViewData
                .TileMapDataSet = TileMap.getTileMap_by_Name(T)
                .AlphaValue = 255
                .LastUserFolder = ""
                .LastWorldFileFolder = ""
                .TransparentF = False
            End With
        End If
        printMap()
    End Sub

    Private Sub txtAltitude_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAltitude.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtAltitude.Text <> "" Then
                btnAdd.PerformClick()
            Else
                btnOK.Focus()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub txtAltitude_Enter(sender As Object, e As EventArgs) Handles txtAltitude.Enter
        Me.AcceptButton = Nothing
    End Sub
    Private Sub txtAltitude_Leave(sender As Object, e As EventArgs) Handles txtAltitude.Leave
        Me.AcceptButton = btnOK
    End Sub

    Private Sub btnSRTM30Convert_Click(sender As Object, e As EventArgs) Handles btnSRTM30Convert.Click
        Dim form As New frmMED_SRTM30Divide
        form.ShowDialog(Me)
        form.Dispose()
    End Sub
End Class