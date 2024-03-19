Public Class frmMED_makeMesh
    Dim CloseCancelF As Boolean
    Dim MeshDivisionNum(6) As enmMesh_Number
    Dim Check_Polygon_S As List(Of Integer)
    Dim MapData As clsMapData
    Dim EditTime As strYMD
    Dim Exsistent_ObjectName_n As Integer
    Dim Exsistent_MeshObject As clsSortingSearch
    Dim Ken_Boundary_Line() As Integer, Ken_Boundary_n As Long

    Private Enum enmMeshObjectShapeInfo
        PolygonWithTopology = 0
        Rectangle = 1
        Point = 2
    End Enum
    Private Structure MeshMake_Info
        Dim MeshCodeNumber As String
        Dim ObjNum As Integer
    End Structure

    Private Sub frmMED_makeMesh_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal Objects As List(Of Integer), ByRef MPData As clsMapData, _
                                         ByVal Time As strYMD) As Windows.Forms.DialogResult

        Me.MapData = MPData
        Check_Polygon_S = Objects
        EditTime = Time
        Return Me.ShowDialog(Owner)
    End Function

    Private Sub frmMED_makeMesh_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_makeMesh")
        e.Cancel = True
    End Sub



    Private Sub frmMED_makeMesh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MeshDivisionNum(enmMesh_Number.mhFirst) = 1
        MeshDivisionNum(enmMesh_Number.mhSecond) = 1
        MeshDivisionNum(enmMesh_Number.mhThird) = 1
        MeshDivisionNum(enmMesh_Number.mhHalf) = 2
        MeshDivisionNum(enmMesh_Number.mhQuarter) = 4
        MeshDivisionNum(enmMesh_Number.mhOne_Eighth) = 8
        MeshDivisionNum(enmMesh_Number.mhOne_Tenth) = 10

    End Sub
    Private Function getMeshSize() As enmMesh_Number

        Dim Msize As enmMesh_Number
        Select Case True
            Case rbMesh1.Checked
                Msize = enmMesh_Number.mhFirst
            Case rbMesh2.Checked
                Msize = enmMesh_Number.mhSecond
            Case rbMesh3.Checked
                Msize = enmMesh_Number.mhThird
            Case rbMesh1_2.Checked
                Msize = enmMesh_Number.mhHalf
            Case rbMesh1_4.Checked
                Msize = enmMesh_Number.mhQuarter
            Case rbMesh1_8.Checked
                Msize = enmMesh_Number.mhOne_Eighth
            Case rbMesh1_10.Checked
                Msize = enmMesh_Number.mhOne_Tenth
        End Select

        Return Msize
    End Function
    Private Function getMeshShape() As enmMeshObjectShapeInfo

        Dim MeshShape As enmMeshObjectShapeInfo
        Select Case True
            Case rbPolygon.Checked
                MeshShape = enmMeshObjectShapeInfo.PolygonWithTopology
            Case rbRect.Checked
                MeshShape = enmMeshObjectShapeInfo.Rectangle
            Case rbPoint.Checked
                MeshShape = enmMeshObjectShapeInfo.Point
        End Select

        Return MeshShape
    End Function
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Dim Msize As enmMesh_Number = getMeshSize()
        Dim MeshShape As enmMeshObjectShapeInfo = getMeshShape()

        '選択オブジェクトの外接領域を取得
        Dim Map_IDOKEDO_RECT As RectangleF = MapData.MPObj(Check_Polygon_S.Item(0)).Circumscribed_Rectangle
        For Each objcode As Integer In Check_Polygon_S
            With MapData.MPObj(objcode)
                Map_IDOKEDO_RECT = spatial.Get_Circumscribed_Rectangle(.Circumscribed_Rectangle, Map_IDOKEDO_RECT)
            End With
        Next
        Map_IDOKEDO_RECT = spatial.Get_Reverse_Rect(Map_IDOKEDO_RECT, MapData.Map.Zahyo)
        Select Case True
            Case rbMethodPolygonIn.Checked, rbMethodAllArea.Checked
                If rbMethodAllArea.Checked = True Then
                    Ken_Boundary_n = 0
                Else
                    'ポリゴンの外周線を取得
                    Dim Poly_Rect As RectangleF
                    Ken_Boundary_n = MapData.Get_MultiObject_Boundary(Check_Polygon_S, EditTime, Ken_Boundary_Line, Poly_Rect)
                End If
                Dim n As Integer = MakeMesh3(Msize, MeshShape, Map_IDOKEDO_RECT)
                If n = 0 Then
                    Dim msgtext As String = "メッシュは作成されませんでした。"
                    MsgBox(msgtext, MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Exit Sub
                End If
            Case rbMethodClipboard.Checked
                Ken_Boundary_n = 0
                Dim f As Boolean = GetMeshFromClipboard()
                If f = False Then
                    CloseCancelF = True
                    Exit Sub
                Else
                End If
        End Select
        MapData.Map.Circumscribed_Rectangle = MapData.Get_Mapfile_Rectangle()

    End Sub

    Private Function MakeMesh3(ByVal Mesh_Size As enmMesh_Number, ByVal MeshShape As enmMeshObjectShapeInfo, ByVal Map_IDOKEDO_RECT As RectangleF) As Integer


        Dim OGN As Integer, LPN As Integer
        Dim Xplus As Single, YPlus As Single
        init_mesh(LPN, OGN, Xplus, YPlus, Mesh_Size, MeshShape)

        '西端の経度を取得
        Dim x2 As Single, y2 As Single
        x2 = 120
        Dim i As Integer = 0
        Do
            i += 1
        Loop While x2 + i * Xplus < Map_IDOKEDO_RECT.Left
        x2 += (i - 1) * Xplus
        '南端の緯度を取得
        y2 = 20
        i = 0
        Do
            i += 1
        Loop While y2 + i * YPlus < Map_IDOKEDO_RECT.Top
        y2 += (i - 1) * YPlus

        Dim meshXNum As Integer, meshYNum As Integer
        With Map_IDOKEDO_RECT
            meshXNum = Int(.Width / Xplus) + 2
            meshYNum = Int(.Height / YPlus) + 2
        End With

        'ポリゴン内部にメッシュ作成

        ProgressLabel.Start(meshYNum, "メッシュオブジェクト設定１", False)


        'メッシュの四隅の座標がポリゴン内にはいるかチェック
        Dim Mesh_Center(,) As Boolean
        Check_MeshKado_PolygonIn(Mesh_Center, x2, y2, meshXNum, meshYNum, Xplus, YPlus)


        '    オブジェクトのライン上のメッシュをチェック
        ProgressLabel.Start(Ken_Boundary_n, "メッシュオブジェクト設定２", False)

        For i = 0 To Ken_Boundary_n - 1
            If i Mod 10 = 0 Then
                ProgressLabel.SetValue(i)
            End If
            Dim lc As Integer = Ken_Boundary_Line(i)
            For j As Integer = 0 To MapData.MPLine(lc).NumOfPoint - 1
                Dim revP As PointF
                revP = spatial.Get_Reverse_XY(MapData.MPLine(lc).PointSTC(j), MapData.Map.Zahyo)
                Dim mex As Integer, mey As Integer
                mex = Int((revP.X - x2) / Xplus)
                mey = Int((revP.Y - y2) / YPlus)
                If 0 <= mex And mex <= meshXNum - 1 And 0 <= mey And mey <= meshYNum - 1 Then
                    Mesh_Center(mex, mey) = True
                End If
            Next
        Next

        'チェックしたメッシュをオブジェクトに

        Dim Okend As Integer = MapData.Map.Kend
        MeshObject_make(Mesh_Size, MeshShape, Mesh_Center, OGN, LPN, meshXNum, meshYNum, Xplus, YPlus, x2, y2)

        MakeMesh3 = MapData.Map.Kend - Okend

        ProgressLabel.Finish()


    End Function
    Private Sub MeshObject_make(ByVal Mesh_Size As enmMesh_Number, ByVal MeshShape As enmMeshObjectShapeInfo, ByVal Mesh_Center(,) As Boolean, ByVal ObjK As Integer, _
                                ByVal LPN As Integer, ByVal xn As Integer, ByVal yn As Integer, _
                            ByVal Xplus As Double, ByVal YPlus As Double, ByVal XStart As Single, ByVal YStart As Single)
        '５／２８新

        Dim Xn2 As Integer = xn * MeshDivisionNum(Mesh_Size)
        Dim Yn2 As Integer = yn * MeshDivisionNum(Mesh_Size)
        Dim MeshObjMake(Xn2 - 1, Yn2 - 1) As MeshMake_Info

        Dim Xplus2 As Double = Xplus / MeshDivisionNum(Mesh_Size)
        Dim YPlus2 As Double = YPlus / MeshDivisionNum(Mesh_Size)

        ProgressLabel.Start(Yn2 + 1, "メッシュオブジェクト設定３", False)
        ProgressLabel.SetValue(1)
        'メッシュコード名の取得()
        For i As Integer = 0 To yn - 1
            For j As Integer = 0 To xn - 1
                If Mesh_Center(j, i) = True Then
                    Set_Mesh_Object_Mesh0528(Mesh_Size, MeshShape, MeshObjMake, Xplus, YPlus, XStart, YStart, j, i)
                End If
            Next
        Next

        'メッシュオブジェクトの作成
        For i As Integer = 0 To Yn2 - 1
            If i Mod 10 = 0 Then
                ProgressLabel.SetValue(i + 1)
            End If
            For j As Integer = 0 To Xn2 - 1
                If MeshObjMake(j, i).MeshCodeNumber <> "" Then
                    Set_Mesh_Object_Mesh_Line_Sub0528(Mesh_Size, MeshShape, MeshObjMake, ObjK, LPN, Xplus2, YPlus2, XStart, YStart, j, i)
                End If
            Next
        Next
        ProgressLabel.Finish()

    End Sub
    ''' <summary>
    ''' メッシュコード名を２次元配列に取得
    ''' </summary>
    ''' <param name="Mesh_Size"></param>
    ''' <param name="MeshShape"></param>
    ''' <param name="MeshObjMake"></param>
    ''' <param name="Xplus"></param>
    ''' <param name="YPlus"></param>
    ''' <param name="XStart"></param>
    ''' <param name="YStart"></param>
    ''' <param name="Xpos"></param>
    ''' <param name="YPos"></param>
    ''' <remarks></remarks>
    Private Sub Set_Mesh_Object_Mesh0528(ByVal Mesh_Size As enmMesh_Number, ByVal MeshShape As enmMeshObjectShapeInfo, ByVal MeshObjMake(,) As MeshMake_Info, _
                            ByVal Xplus As Double, ByVal YPlus As Double, ByVal XStart As Single, ByVal YStart As Single, ByVal Xpos As Integer, ByVal YPos As Integer)
 
        Dim Mesh_Center(,) As Boolean


        Dim CMX As Single = XStart + Xplus * (Xpos + 0.5)
        Dim CMY As Single = YStart + YPlus * (YPos + 0.5)

        Dim M1Code As String = CStr(Int(CMY * 1.5)) & CStr(Int(CMX - 100))
        Dim M2Code As String = CStr(Int((CMY * 1.5 - Int(CMY * 1.5)) * 8)) & CStr(Int((CMX - Int(CMX)) * 8))
        Dim M3Code As String = CStr(Int((CMY * 3600 Mod 300) / 300 * 10)) & CStr(Int((CMX * 3600 Mod 450) / 450 * 10))
        Dim M123Code As String = M1Code + M2Code + M3Code

        Dim Dx As Single = CMX - Xplus / 2
        Dim Dy As Single = CMY - YPlus / 2
        Dim XposD As Integer = Xpos * MeshDivisionNum(Mesh_Size)
        Dim YposD As Integer = YPos * MeshDivisionNum(Mesh_Size)
        Select Case Mesh_Size
            Case enmMesh_Number.mhFirst, enmMesh_Number.mhSecond, enmMesh_Number.mhThird
                Dim MeshOBName As String = ""
                Select Case Mesh_Size
                    Case enmMesh_Number.mhFirst
                        MeshOBName = M1Code
                    Case enmMesh_Number.mhSecond
                        MeshOBName = M1Code & M2Code
                    Case enmMesh_Number.mhThird
                        MeshOBName = M1Code & M2Code & M3Code
                End Select
                If Check_Exsistent_MeshObjects(MeshOBName) = True Then
                    MeshObjMake(Xpos, YPos).MeshCodeNumber = MeshOBName
                End If
            Case enmMesh_Number.mhHalf
                Dim Xplus2 As Single, YPlus2 As Single
                Xplus2 = Xplus / 2
                YPlus2 = YPlus / 2
                Call Check_MeshKado_PolygonIn(Mesh_Center, Dx, Dy, 2, 2, Xplus2, YPlus2)
                For i As Integer = 0 To 1
                    For j As Integer = 0 To 1
                        If Mesh_Center(j, i) = True Then
                            Dim MeshOBName As String = M123Code + CStr(i * 2 + (j + 1))
                            If Check_Exsistent_MeshObjects(MeshOBName) = True Then
                                MeshObjMake(XposD + j, YposD + i).MeshCodeNumber = MeshOBName
                            End If
                        End If
                    Next
                Next
            Case enmMesh_Number.mhQuarter
                Dim Xplus2 As Single, YPlus2 As Single
                Xplus2 = Xplus / 4
                YPlus2 = YPlus / 4
                Call Check_MeshKado_PolygonIn(Mesh_Center, Dx, Dy, 4, 4, Xplus2, YPlus2)
                For i As Integer = 0 To 1
                    For j As Integer = 0 To 1
                        Dim MeshOBName1 As String = M123Code + CStr(i * 2 + (j + 1))
                        For i2 As Integer = 0 To 1
                            For j2 As Integer = 0 To 1
                                If Mesh_Center(j * 2 + j2, i * 2 + i2) = True Then
                                    Dim MeshOBName As String = MeshOBName1 + CStr(i2 * 2 + (j2 + 1))
                                    If Check_Exsistent_MeshObjects(MeshOBName) = True Then
                                        MeshObjMake(XposD + j * 2 + j2, YposD + i * 2 + i2).MeshCodeNumber = MeshOBName
                                    End If
                                End If
                            Next
                        Next
                    Next
                Next
            Case enmMesh_Number.mhOne_Eighth
                Dim Xplus2 As Single, YPlus2 As Single
                Xplus2 = Xplus / 8
                YPlus2 = YPlus / 8
                Call Check_MeshKado_PolygonIn(Mesh_Center, Dx, Dy, 8, 8, Xplus2, YPlus2)
                For i As Integer = 0 To 1
                    For j As Integer = 0 To 1
                        Dim X As Double, Y As Double
                        X = Dx + j * Xplus / 2
                        Y = Dy + i * YPlus / 2
                        For i2 As Integer = 0 To 1
                            For j2 As Integer = 0 To 1
                                Dim MeshOBName1 As String = M123Code + CStr(i * 2 + (j + 1)) + CStr(i2 * 2 + (j2 + 1))
                                For i3 As Integer = 0 To 1
                                    For j3 As Integer = 0 To 1
                                        If Mesh_Center(j * 4 + j2 * 2 + j3, i * 4 + i2 * 2 + i3) = True Then
                                            Dim MeshOBName As String = MeshOBName1 + CStr(i3 * 2 + (j3 + 1))
                                            If Check_Exsistent_MeshObjects(MeshOBName) = True Then
                                                MeshObjMake(XposD + j * 4 + j2 * 2 + j3, YposD + i * 4 + i2 * 2 + i3).MeshCodeNumber = MeshOBName
                                            End If
                                        End If
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Case enmMesh_Number.mhOne_Tenth
                Dim Xplus2 As Single, YPlus2 As Single
                Xplus2 = Xplus / 10
                YPlus2 = YPlus / 10
                Call Check_MeshKado_PolygonIn(Mesh_Center, Dx, Dy, 10, 10, Xplus2, YPlus2)
                Dim a$
                a$ = M1Code & M2Code & M3Code
                For i As Integer = 0 To 9
                    For j As Integer = 0 To 9
                        If Mesh_Center(j, i) = True Then
                            Dim MeshOBName As String = M123Code + CStr(i) + CStr(j)
                            If Check_Exsistent_MeshObjects(MeshOBName) = True Then
                                MeshObjMake(XposD + j, YposD + i).MeshCodeNumber = MeshOBName
                            End If
                        End If
                    Next
                Next
        End Select
    End Sub
    ''' <summary>
    ''' メッシュオブジェクトを作る
    ''' </summary>
    ''' <param name="Mesh_Size"></param>
    ''' <param name="MeshShape"></param>
    ''' <param name="MeshObjMake"></param>
    ''' <param name="ObjK"></param>
    ''' <param name="LPN"></param>
    ''' <param name="Xplus"></param>
    ''' <param name="YPlus"></param>
    ''' <param name="XStart"></param>
    ''' <param name="YStart"></param>
    ''' <param name="Xpos"></param>
    ''' <param name="YPos"></param>
    ''' <remarks></remarks>
    Private Sub Set_Mesh_Object_Mesh_Line_Sub0528(ByVal Mesh_Size As enmMesh_Number, ByVal MeshShape As enmMeshObjectShapeInfo, _
                    ByVal MeshObjMake(,) As MeshMake_Info, ByVal ObjK As Integer, ByVal LPN As Integer, ByVal Xplus As Double, ByVal YPlus As Double, _
                    ByVal XStart As Double, ByVal YStart As Double, ByVal Xpos As Integer, ByVal YPos As Integer)

        Dim CenterMeshXY As PointF
        Dim ConvXY() As PointF
        Dim PBox As RectangleF

        If MeshShape = enmMeshObjectShapeInfo.PolygonWithTopology Or MeshShape = enmMeshObjectShapeInfo.Rectangle Then
            ReDim ConvXY(3)
            Dim xy As PointF
            xy.X = XStart + Xplus * Xpos
            xy.Y = YStart + YPlus * YPos
            ConvXY(0) = spatial.Get_Converted_XY(xy, MapData.Map.Zahyo)
            xy.X = XStart + Xplus * (Xpos + 1)
            xy.Y = YStart + YPlus * YPos
            ConvXY(1) = spatial.Get_Converted_XY(xy, MapData.Map.Zahyo)
            xy.X = XStart + Xplus * (Xpos + 1)
            xy.Y = YStart + YPlus * (YPos + 1)
            ConvXY(2) = spatial.Get_Converted_XY(xy, MapData.Map.Zahyo)
            xy.X = XStart + Xplus * Xpos
            xy.Y = YStart + YPlus * (YPos + 1)
            ConvXY(3) = spatial.Get_Converted_XY(xy, MapData.Map.Zahyo)
            PBox = RectangleF.FromLTRB(ConvXY(0).X, ConvXY(3).Y, ConvXY(1).X, ConvXY(0).Y)
        End If


        CenterMeshXY = spatial.Get_Converted_XY(New PointF(XStart + Xplus * (Xpos + 0.5), YStart + YPlus * (YPos + 0.5)), MapData.Map.Zahyo)
        MapData.Get_Part_of_simple_point_object(ObjK, MeshObjMake(Xpos, YPos).MeshCodeNumber, CenterMeshXY.X, CenterMeshXY.Y, {""})

        Dim kd As Integer = MapData.Map.Kend - 1
        MeshObjMake(Xpos, YPos).ObjNum = kd

        Select Case MeshShape
            Case enmMeshObjectShapeInfo.PolygonWithTopology
                '位相構造ポリゴン
                With MapData.MPObj(kd)
                    .Shape = enmShape.PolygonShape
                    .NumOfLine = 4
                    ReDim .LineCodeSTC(3)
                    .Circumscribed_Rectangle = PBox
                End With
                For i As Integer = 0 To 3
                    MakeTopologyMesh(MeshObjMake, kd, LPN, ConvXY, Xpos, YPos, i)
                Next
            Case enmMeshObjectShapeInfo.Rectangle
                '位相構造無しのポリゴン
                With MapData.MPObj(kd)
                    .Shape = enmShape.PolygonShape
                    .NumOfLine = 1
                    ReDim .LineCodeSTC(0)
                    .LineCodeSTC(0).LineCode = MapData.Map.ALIN
                    .Circumscribed_Rectangle = PBox
                End With
                With MapData.Map
                    MapData.CheckMPLine_Dim(.ALIN)
                    MapData.MPLine(.ALIN) = MapData.Init_One_Line(LPN)
                    With MapData.MPLine(.ALIN)
                        .NumOfPoint = 5
                        ReDim .PointSTC(.NumOfPoint - 1)
                        For j As Integer = 0 To 3
                            .PointSTC(j) = ConvXY(j)
                        Next
                        .PointSTC(4) = ConvXY(0)
                        .Circumscribed_Rectangle = PBox
                    End With
                    .ALIN += 1
                End With
            Case enmMeshObjectShapeInfo.Point
                'ポイントの場合
                MapData.MPObj(kd).Shape = enmShape.PointShape
                MapData.MPObj(kd).Circumscribed_Rectangle = New RectangleF(CenterMeshXY.X, CenterMeshXY.Y, 0, 0)
        End Select
    End Sub
    Private Sub MakeTopologyMesh(ByVal MeshObjMake(,) As MeshMake_Info, ByVal kd As Integer, ByVal LPN As Integer, ByVal ConvXY() As PointF, _
                        ByVal Xpos As Integer, ByVal YPos As Integer, ByVal CheckP As Integer)
        '位相構造ポリゴンを作成


        Dim ConvXY0 As PointF, ConvXY1 As PointF, refOcode As Integer
        Dim CheckPRef(3) As Integer

        CheckPRef(0) = 2
        CheckPRef(1) = 3
        CheckPRef(2) = 0
        CheckPRef(3) = 1

        '５／２８新
        Dim f As Boolean = False
        Select Case CheckP
            Case 0
                If Xpos = 0 Then
                    f = True
                ElseIf MeshObjMake(Xpos - 1, YPos).MeshCodeNumber = "" Then
                    f = True
                Else
                    refOcode = MeshObjMake(Xpos - 1, YPos).ObjNum
                End If
            Case 1
                If YPos = 0 Then
                    f = True
                ElseIf MeshObjMake(Xpos, YPos - 1).MeshCodeNumber = "" Then
                    f = True
                Else
                    refOcode = MeshObjMake(Xpos, YPos - 1).ObjNum
                End If
            Case 2
                '右と下は常に作成
                f = True
            Case 3
                f = True
        End Select
        If f = True Then
            Select Case CheckP
                Case 0
                    ConvXY0 = ConvXY(0)
                    ConvXY1 = ConvXY(3)
                Case 1
                    ConvXY0 = ConvXY(0)
                    ConvXY1 = ConvXY(1)
                Case 2
                    ConvXY0 = ConvXY(1)
                    ConvXY1 = ConvXY(2)
                Case 3
                    ConvXY0 = ConvXY(2)
                    ConvXY1 = ConvXY(3)
            End Select
            MapData.MPObj(kd).LineCodeSTC(CheckP).LineCode = MapData.Map.ALIN
            With MapData.Map
                MapData.CheckMPLine_Dim(.ALIN)
                MapData.MPLine(.ALIN) = MapData.Init_One_Line(LPN)
                With MapData.MPLine(.ALIN)
                    .NumOfPoint = 2
                    ReDim .PointSTC(.NumOfPoint - 1)
                    .PointSTC(0) = ConvXY0
                    .PointSTC(1) = ConvXY1
                    .Circumscribed_Rectangle = RectangleF.FromLTRB(Math.Min(ConvXY0.X, ConvXY1.X), Math.Min(ConvXY0.Y, ConvXY1.Y), _
                                                                   Math.Max(ConvXY0.X, ConvXY1.X), Math.Max(ConvXY0.Y, ConvXY1.Y))
                End With
                MapData.Map.ALIN += 1
            End With
        Else
            With MapData.MPObj(refOcode).LineCodeSTC(CheckPRef(CheckP))
                MapData.MPObj(kd).LineCodeSTC(CheckP).LineCode = .LineCode
                MapData.MPObj(kd).LineCodeSTC(CheckP).NumOfTime = .NumOfTime
                MapData.MPObj(kd).LineCodeSTC(CheckP).Times = Nothing
            End With
        End If

    End Sub
    ''' <summary>
    ''' メッシュがオブジェクト内部に入るかどうかチェックする
    ''' </summary>
    ''' <param name="Mesh_Center">メッシュの配列（戻り値）</param>
    ''' <param name="XStart"></param>
    ''' <param name="YStart"></param>
    ''' <param name="xn"></param>
    ''' <param name="yn"></param>
    ''' <param name="Xplus"></param>
    ''' <param name="YPlus"></param>
    ''' <remarks></remarks>
    Private Sub Check_MeshKado_PolygonIn(ByRef Mesh_Center(,) As Boolean, ByVal XStart As Single, ByVal YStart As Single, ByVal xn As Integer, ByVal yn As Integer, _
                        ByVal Xplus As Single, ByVal YPlus As Single)

        ReDim Mesh_Center(xn - 1, yn - 1)

        If Ken_Boundary_n = 0 Then
            For i As Integer = 0 To yn - 1
                For j As Integer = 0 To xn - 1
                    Mesh_Center(j, i) = True
                Next
            Next
            Exit Sub
        Else
            '中央
            Dim i As Integer = 0
            Do
                Dim Cross_x() As Single, crn As Integer
                Dim cvP As PointF = spatial.Get_Converted_XY(New PointF(XStart, YStart + YPlus / 2 + i * YPlus), MapData.Map.Zahyo)
                MapData.Check_Point_in_Polygon_LineCode(cvP.X, cvP.Y, Ken_Boundary_n, Ken_Boundary_Line, crn, Cross_x)
                Dim j As Integer = 0
                Dim y3 As Single, x3 As Single
                y3 = YStart + i * YPlus + YPlus / 2
                'If crn > 2 Then Stop
                Do
                    x3 = XStart + j * Xplus + Xplus / 2
                    Dim cvP2 As PointF = spatial.Get_Converted_XY(New PointF(x3, y3), MapData.Map.Zahyo)
                    For k As Integer = 0 To crn - 2 Step 2
                        If Cross_x(k) <= cvP2.X And cvP2.X <= Cross_x(k + 1) Then
                            Mesh_Center(j, i) = True
                        End If
                    Next
                    j += 1
                Loop While j <> xn
                i += 1
            Loop While i <> yn

            '四隅
            Dim Mesh_Kado(xn, yn) As Boolean
            i = 0
            Do
                Dim y3 As Single = YStart + i * YPlus
                Dim rvP As PointF = spatial.Get_Converted_XY(New PointF(XStart, y3), MapData.Map.Zahyo)
                Dim Cross_x() As Single, crn As Integer
                MapData.Check_Point_in_Polygon_LineCode(rvP.X, rvP.Y, Ken_Boundary_n, Ken_Boundary_Line, crn, Cross_x)
                Dim j As Integer = 0
                Do
                    Dim x3 As Single = XStart + j * Xplus
                    Dim rvP2 As PointF = spatial.Get_Converted_XY(New PointF(x3, y3), MapData.Map.Zahyo)
                    For k As Integer = 0 To crn - 2 Step 2
                        If Cross_x(k) <= rvP2.X And rvP2.X <= Cross_x(k + 1) Then
                            Mesh_Kado(j, i) = True
                        End If
                    Next
                    j += 1
                Loop While j <> xn + 1
                i += 1
            Loop While i <> yn + 1

            For i = 0 To yn - 1
                For j As Integer = 0 To xn - 1
                    If Mesh_Center(j, i) = False Then
                        If Mesh_Kado(j, i) = True Or Mesh_Kado(j + 1, i) = True Or Mesh_Kado(j, i + 1) = True Or Mesh_Kado(j + 1, i + 1) = True Then
                            Mesh_Center(j, i) = True
                        End If
                    End If
                Next
            Next

        End If


    End Sub
    Private Function Check_Exsistent_MeshObjects(ByVal OName As String) As Boolean


        If Exsistent_ObjectName_n = 0 Then
            Check_Exsistent_MeshObjects = True
            Exit Function
        End If
        Dim Posi As Integer = Exsistent_MeshObject.SearchData_One(Val(OName))
        If Posi = -1 Then
            Return True
        Else
            Return False
        End If

    End Function


    ''' <summary>
    ''' メッシュオブジェクトの初期値を取得
    ''' </summary>
    ''' <param name="LinePN">メッシュの線種番号（戻り値）</param>
    ''' <param name="ObjectGN">メッシュのオブジェクトグループ番号（戻り値）</param>
    ''' <param name="Xplus">メッシュの経度幅（戻り値）</param>
    ''' <param name="YPlus">メッシュの緯度幅（戻り値）</param>
    ''' <param name="Mesh_Size">メッシュの種類</param>
    ''' <param name="MeshShape">メッシュの形状</param>
    ''' <remarks></remarks>
    Private Sub init_mesh(ByRef LinePN As Integer, ByRef ObjectGN As Integer, ByRef Xplus As Single, ByRef YPlus As Single, _
                        ByVal Mesh_Size As enmMesh_Number, ByVal MeshShape As enmMeshObjectShapeInfo)

        Dim NewObGroup As clsMapData.strObjectGroup_Data
        Dim Exsistent_Objects() As Integer
        Dim OKNM As String = clsGeneric.ConvertMeshTypeEnumString(Mesh_Size)

        Select Case Mesh_Size
            Case enmMesh_Number.mhFirst
                Xplus = 450 * 8 / 3600
                YPlus = 300 * 8 / 3600
            Case enmMesh_Number.mhSecond
                Xplus = 450 / 3600
                YPlus = 300 / 3600
            Case enmMesh_Number.mhThird
                Xplus = 45 / 3600
                YPlus = 30 / 3600
            Case enmMesh_Number.mhHalf  '３次メッシュよりも小さいメッシュは３次メッシュを分割して作成するので、ここでは３次メッシュのサイズ
                Xplus = 45 / 3600
                YPlus = 30 / 3600
            Case enmMesh_Number.mhQuarter
                Xplus = 45 / 3600
                YPlus = 30 / 3600
            Case enmMesh_Number.mhOne_Eighth
                Xplus = 45 / 3600
                YPlus = 30 / 3600
            Case enmMesh_Number.mhOne_Tenth
                Xplus = 45 / 3600
                YPlus = 30 / 3600
        End Select

        '既存オブジェクトグループに同一メッシュがあるかをチェック
        ObjectGN = -1
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            If MapData.ObjectKind(i).Mesh = Mesh_Size Then
                ObjectGN = i
                Exit For
            End If
        Next

        If ObjectGN = -1 Then
            '既存オブジェクトグループにに同一メッシュが無い場合
            With NewObGroup
                If MeshShape = 0 Or MeshShape = 1 Then
                    .Shape = enmShape.PolygonShape
                Else
                    .Shape = enmShape.PointShape
                End If
                .Name = OKNM
                .Mesh = Mesh_Size
            End With
            MapData.Add_OneObjectGroup_Parameter(NewObGroup)
            Exsistent_ObjectName_n = 0
            ObjectGN = MapData.Map.OBKNum - 1
        Else
            '存在する場合はオブジェクト名を取得して並び替えておく
            Exsistent_ObjectName_n = MapData.Get_Objects_by_Group(ObjectGN, Exsistent_Objects, clsTime.GetNullYMD)

            Exsistent_MeshObject = New clsSortingSearch(VariantType.Double)
            For i As Integer = 0 To Exsistent_ObjectName_n - 1
                Exsistent_MeshObject.Add(Val(MapData.MPObj(Exsistent_Objects(i)).NameTimeSTC(0).NamesList(0)))
            Next
            Exsistent_MeshObject.AddEnd()
        End If

        If MeshShape = 0 Or MeshShape = 1 Then
            '既存線種に同一メッシュがあるかをチェック
            LinePN = -1
            For i As Integer = 0 To MapData.Map.LpNum - 1
                If MapData.LineKind(i).Mesh = Mesh_Size Then
                    LinePN = i
                    Exit For
                End If
            Next
            If LinePN = -1 Then
                ''既存線種に同一メッシュが無い場合
                MapData.Add_OneLineKind(OKNM & "枠", clsBase.BlancLine, Mesh_Size)
                MapData.ObjectKind(MapData.Map.OBKNum - 1).UseLineType(MapData.Map.LpNum - 1) = True
                LinePN = MapData.Map.LpNum - 1
            End If
        End If

    End Sub

    Private Function GetMeshFromClipboard() As Boolean

        Dim clipText As String = Clipboard.GetText
        If clipText = "" Then
            Dim msgText1 As String = "クリップボードにデータがありません。"
            MsgBox(msgText1, MsgBoxStyle.Exclamation)
            Return False
            Exit Function
        End If

        Dim msgText As String = "クリップボードのメッシュコードをもとにメッシュを作成します。"
        If MsgBox(msgText, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Return False
            Exit Function
        End If

        Dim MeshSTR() As String = Split(clipText.Replace(vbCrLf, vbTab), vbTab)
        Dim Mesh_Size As enmMesh_Number = getMeshSize()

        Dim MeshShape As enmMeshObjectShapeInfo = getMeshShape()
        Dim n As Integer = MeshSTR.GetUpperBound(0) + 1

        Dim OGN As Integer, LPN As Integer
        Dim Xplus As Single, YPlus As Single
        init_mesh(LPN, OGN, Xplus, YPlus, Mesh_Size, MeshShape)


        Dim CodeLen As Integer = clsGeneric.getMeshCodeLength(Mesh_Size)
        Dim MeshCode(n - 1) As String
        Dim MCDBox(n - 1) As strLatLonBox
        Dim MeshOuter As strLatLonBox
        Dim n2 As Integer = 0
        For i As Integer = 0 To n - 1
            If MeshSTR(i) <> "" Then
                If Len(MeshSTR(i)) <> CodeLen Then
                    Dim msgtext1 = "指定された種類のメッシュでないデータが含まれています。" + vbCrLf + MeshSTR(i)
                    MsgBox(msgtext1, vbExclamation)
                    Return False
                    Exit Function
                Else
                    If Check_Exsistent_MeshObjects(MeshSTR(i)) = True Then
                        MeshCode(n2) = MeshSTR(i)
                        MCDBox(n2) = spatial.Get_Ido_Kedo_from_MeshCode(MeshSTR(i), Mesh_Size)
                        If n2 = 0 Then
                            MeshOuter = MCDBox(n2)
                        Else
                            MeshOuter = spatial.Get_Circumscribed_Rectangle(MCDBox(n2), MeshOuter)
                        End If
                        n2 += 1
                    End If
                End If
            End If
        Next
        Dim mxySize As SizeF = spatial.Get_MeshCode_Size_IdoKedo(Mesh_Size)
        Dim xn As Integer = Int(MeshOuter.Width / mxySize.Width) + 1
        Dim yn As Integer = Int(MeshOuter.Height / mxySize.Height) + 1
        Dim MeshObjMake(xn - 1, yn - 1) As MeshMake_Info

        For i As Integer = 0 To n2 - 1
            With MCDBox(i)
                Dim X As Integer = Int((.CenterPoint.Longitude - MeshOuter.NorthWest.Longitude) / Xplus)
                Dim Y As Integer = Int((.CenterPoint.Latitude - MeshOuter.SouthEast.Latitude) / YPlus)
                MeshObjMake(X, Y).MeshCodeNumber = MeshCode(i)
            End With
        Next

        'メッシュオブジェクトの作成
        For i As Integer = 0 To yn - 1
            For j As Integer = 0 To xn - 1
                If MeshObjMake(j, i).MeshCodeNumber <> "" Then
                    Set_Mesh_Object_Mesh_Line_Sub0528(Mesh_Size, MeshShape, MeshObjMake, OGN, LPN, Xplus, YPlus, MeshOuter.NorthWest.Longitude, MeshOuter.SouthEast.Latitude, j, i)
                End If
            Next
        Next
        Return True
    End Function
End Class