

Public Class clsSpatialIndexSearch
    Private Enum Add_or_Remove
        Add_Obj = 1
        Remove_Obj = 2
    End Enum

    Private Structure Object_Info
        Public ObjectNumber As Integer 'メッシュ内のオブジェクト番号
        Public ObjectPointNumber As Integer 'オブジェクト内のポイント番号
    End Structure

    Private Structure IndexContents_Info
        Public ObjectNumber As List(Of Object_Info)
    End Structure
    Dim MeshIndex(,) As IndexContents_Info
    Dim XYSize As Integer
    Dim meshw As Single
    Dim meshh As Single

    Private Structure ObjectXY_Info
        Public Pnum As Integer
        Public Point() As PointF
        Public Tag As Integer
        Public RemoveF As Boolean
    End Structure
    Private ObjectXY() As ObjectXY_Info

    Private ObjectType As SpatialPointType


    Private MeshRect As RectangleF
    Private RectSetF As Boolean
    Private AddEndF As Boolean

    Private ObjectNum As Integer
    Private ExtraRange As Single
    Private ExtraRangeF As Boolean

    Private LineCutNum As Integer

    Public Sub Init(ByVal ObjType As SpatialPointType, ByVal ExtraRangeFlag As Boolean, _
            Optional ByVal X1 As Single = 0, Optional ByVal Y1 As Single = 0, Optional ByVal x2 As Single = 0, Optional ByVal y2 As Single = 0, _
            Optional ByVal ExtraRange_Size As Single = 0)
        '初期化メソッド
        'X1Y1全体の大きさ。省略した場合はあとで計算

        ObjectType = ObjType
        ObjectNum = 0
        ReDim ObjectXY(100)
        ExtraRange = ExtraRange_Size
        ExtraRangeF = ExtraRangeFlag

        If X1 = 0 And x2 = 0 And Y1 = 0 And y2 = 0 Then
            RectSetF = False
        Else
            MeshRect = RectangleF.FromLTRB(Math.Min(X1, x2) - ExtraRange, Math.Min(Y1, y2) - ExtraRange, Math.Max(X1, x2) + ExtraRange, Math.Max(Y1, y2) + ExtraRange)
            RectSetF = True
        End If
        AddEndF = False
    End Sub
    Private Function BoxData_AddExtraRange(ByRef PBox As RectangleF) As RectangleF
        '四角形に幅をプラスする
        With PBox
            Return RectangleF.FromLTRB(.Left - ExtraRange, .Top - ExtraRange, .Right + ExtraRange, .Bottom + ExtraRange)
        End With

    End Function
    ''' <summary>
    ''' ポイントの追加を終了してメッシュに配分する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddEnd()
        '


        If ObjectNum = 0 Then
            Return
        End If

        Dim n As Integer = 0
        For i As Integer = 0 To ObjectNum - 1
            n += ObjectXY(i).Pnum
        Next
        Select Case ObjectType
            Case SpatialPointType.SinglePoint
                If n > 100 Then
                    XYSize = Int(Math.Sqrt(n) / 2)
                Else
                    XYSize = Int(Math.Sqrt(n))
                End If
                If ExtraRange = 0 Then
                    XYSize = XYSize * 2
                End If
            Case SpatialPointType.SPILine
                XYSize = Int(Math.Sqrt(n) / 4)
                LineCutNum = Int((n / ObjectNum))
                LineCutNum = Math.Max(LineCutNum, 50)
            Case SpatialPointType.SPIRect
                XYSize = Int(Math.Sqrt(n))
        End Select
        XYSize = Math.Max(XYSize, 2)

        ReDim MeshIndex(XYSize, XYSize)


        If RectSetF = False Then
            '初期値に大きさが指定してない場合はここで追加
            MeshRect = New RectangleF(ObjectXY(0).Point(0).X, ObjectXY(0).Point(0).Y, 0, 0)
            For i As Integer = 0 To ObjectNum - 1
                With ObjectXY(i)
                    For j As Integer = 0 To .Pnum - 1
                        MeshRect = spatial.Get_Circumscribed_Rectangle(.Point(j), MeshRect)
                    Next
                End With
            Next
            MeshRect = BoxData_AddExtraRange(MeshRect)
        End If

        With MeshRect
            If CDec(.Right) = CDec(.Left) Then
                meshw = 1
            Else
                meshw = (.Right - .Left) / XYSize
            End If
            If CDec(.Top) = CDec(.Bottom) Then
                meshh = 1
            Else
                meshh = (.Bottom - .Top) / XYSize
            End If
        End With
        If ExtraRange > Math.Min(meshw, meshh) Then
            'ExtraRange = Math.Min(meshw, meshh)
        End If
        For i As Integer = 0 To ObjectNum - 1
            If ObjectXY(i).RemoveF = False Then
                Select Case ObjectType
                    Case SpatialPointType.SinglePoint
                        Call AddMeshPoint(i, Add_or_Remove.Add_Obj)
                    Case SpatialPointType.SPILine
                        Call AddMeshLine(i)
                    Case SpatialPointType.SPIRect
                        Call AddMeshRect(i, Add_or_Remove.Add_Obj)
                End Select
            End If
        Next
        AddEndF = True
    End Sub
    Public Sub Refresh()
        RectSetF = False
        Call AddEnd()
    End Sub
    Private Sub AddMeshLine(ByVal ObjNum As Integer)


        For i As Integer = 0 To ObjectXY(ObjNum).Pnum - 1 Step LineCutNum
            Add_Mesh_LineSub(ObjNum, i, Add_or_Remove.Add_Obj)
        Next
    End Sub
    Private Sub Add_Mesh_LineSub(ByVal ObjNum As Integer, ByVal StartP As Integer, ByVal AddorRemove As Add_or_Remove)


        Dim ex As Integer = StartP + LineCutNum
        If ObjectXY(ObjNum).Pnum < ex Then
            ex = ObjectXY(ObjNum).Pnum
        End If
        Dim PBox As RectangleF = New RectangleF(ObjectXY(ObjNum).Point(StartP), New Size(0, 0))

        For i As Integer = StartP To ex - 1
            PBox = spatial.Get_Circumscribed_Rectangle(ObjectXY(ObjNum).Point(i), PBox)
        Next
        PBox = BoxData_AddExtraRange(PBox)
        Dim RBox As Rectangle
        Dim f As Boolean = GetRangeXY(PBox, RBox)
        If f = True Then
            With RBox
                For i As Integer = .Left To .Right
                    For j As Integer = .Top To .Bottom
                        If AddorRemove = Add_or_Remove.Add_Obj Then
                            Add_Mesh_PointSub(i, j, ObjNum, StartP)
                        Else
                            RemoveObject_sub(i, j, ObjNum)
                        End If
                    Next
                Next
            End With
        End If

    End Sub
    Private Sub AddMeshRect(ByVal ObjNum As Integer, ByVal AddorRemove As Add_or_Remove)

        Dim RBox As Rectangle
        Dim PBox As RectangleF = BoxData_AddExtraRange(spatial.Get_Rectangle(ObjectXY(ObjNum).Point(0), ObjectXY(ObjNum).Point(1)))
        Dim f As Boolean = GetRangeXY(PBox, RBox)
        If f = True Then
            With RBox
                For i As Integer = .Left To .Right
                    For j As Integer = .Top To .Bottom
                        If AddorRemove = Add_or_Remove.Add_Obj Then
                            Call Add_Mesh_PointSub(i, j, ObjNum, 0)
                        Else
                            Call RemoveObject_sub(i, j, ObjNum)
                        End If
                    Next
                Next
            End With
        End If
    End Sub
    Private Sub AddMeshPoint(ByVal ObjNum As Integer, ByVal AddorRemove As Add_or_Remove)
        For k As Integer = 0 To ObjectXY(ObjNum).Pnum - 1
            If ExtraRangeF = False Then
                '大きさのないポイントを追加
                Dim X As Integer, Y As Integer
                Dim exf As Boolean = GetConPointXY(ObjectXY(ObjNum).Point(k), X, Y)
                If exf = True Then
                    If AddorRemove = Add_or_Remove.Add_Obj Then
                        Call Add_Mesh_PointSub(X, Y, ObjNum, k)
                    Else
                        Call RemoveObject_sub(X, Y, ObjNum)
                    End If
                End If
            Else
                '大きさのあるポイントを追加
                Dim RBox As Rectangle
                Dim exf As Boolean = GetExtraRange_XY(ObjectXY(ObjNum).Point(k), RBox)
                If exf = True Then
                    With RBox
                        For i As Integer = .Left To .Right
                            For j As Integer = .Top To .Bottom
                                If AddorRemove = Add_or_Remove.Add_Obj Then
                                    Call Add_Mesh_PointSub(i, j, ObjNum, k)
                                Else
                                    Call RemoveObject_sub(i, j, ObjNum)
                                End If
                            Next
                        Next
                    End With
                End If
            End If
        Next
    End Sub
    Private Sub Add_Mesh_PointSub(ByVal X As Integer, ByVal Y As Integer, ByVal ObjNum As Integer, ByVal Pointnum As Integer)
        With MeshIndex(X, Y)

            If .ObjectNumber Is Nothing = True Then
                .ObjectNumber = New List(Of Object_Info)
            End If
            Dim odata As Object_Info
            odata.ObjectNumber = ObjNum
            odata.ObjectPointNumber = Pointnum
            .ObjectNumber.Add(odata)
        End With
    End Sub
    Private Function GetConPointXY(ByVal inXY As PointF, ByRef X As Integer, ByRef Y As Integer) As Boolean
        'メッシュ領域に入るかチェック
        With inXY
            X = Int((.x - MeshRect.Left) / meshw)
            Y = Int((.y - MeshRect.Top) / meshh)
        End With
        If X < 0 Or Y < 0 Or X > XYSize Or Y > XYSize Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function GetExtraRange_XY(ByVal XY As PointF, ByRef OutPutRect As Rectangle) As Boolean
        Dim PBox As RectangleF
        With XY
            PBox = RectangleF.FromLTRB(.X - ExtraRange, .Y - ExtraRange, .X + ExtraRange, .Y + ExtraRange)
        End With
        Return GetRangeXY(PBox, OutPutRect)
    End Function
    Private Function GetRangeXY(ByVal InPBox As RectangleF, ByRef OutRBox As Rectangle) As Boolean
        Dim X1 As Integer, x2 As Integer, Y1 As Integer, y2 As Integer
        If spatial.Compare_Two_Rectangle_Position(InPBox, MeshRect) <> cstRectangle_Cross.cstOuter Then
            With InPBox
                X1 = Int((.Left - MeshRect.Left) / meshw)
                Y1 = Int((.Top - MeshRect.Top) / meshh)
                X1 = clsGeneric.m_min_max(X1, 0, XYSize)
                Y1 = clsGeneric.m_min_max(Y1, 0, XYSize)
                x2 = Int((.Right - MeshRect.Left) / meshw)
                y2 = Int((.Bottom - MeshRect.Top) / meshh)
                x2 = clsGeneric.m_min_max(x2, 0, XYSize)
                y2 = clsGeneric.m_min_max(y2, 0, XYSize)
            End With
            OutRBox = Rectangle.FromLTRB(X1, Y1, x2, y2)
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub Add_Point_Sub(ByVal Pnum As Integer, ByVal XY() As PointF, ByVal TagData As Integer)

        If UBound(ObjectXY) < ObjectNum Then
            ReDim Preserve ObjectXY(ObjectNum * 2)
        End If

        With ObjectXY(ObjectNum)
            .Pnum = Pnum
            .Tag = TagData
            .Point = XY.Clone

        End With
        If AddEndF = True Then
            'メッシュ作成後に追加した場合
            Select Case ObjectType
                Case SpatialPointType.SinglePoint
                    Call AddMeshPoint(ObjectNum, Add_or_Remove.Add_Obj)
                Case SpatialPointType.SPILine
                    Call AddMeshLine(ObjectNum)
                Case SpatialPointType.SPIRect
                    Call AddMeshRect(ObjectNum, Add_or_Remove.Add_Obj)
            End Select
        End If
        ObjectNum += 1
    End Sub
    ''' <summary>
    ''' 複数地点オブジェクトを追加
    ''' </summary>
    ''' <param name="Pnum"></param>
    ''' <param name="XY"></param>
    ''' <param name="TagData"></param>
    ''' <remarks></remarks>
    Public Sub AddMultiPoint(ByVal Pnum As Integer, ByVal XY() As PointF, ByVal TagData As Integer)
        '
        If ObjectType <> SpatialPointType.SinglePoint Then
            MsgBox("点以外はできません。", vbExclamation)
            Exit Sub
        End If
        Call Add_Point_Sub(Pnum, XY, TagData)


    End Sub
    ''' <summary>
    ''' 2地点オブジェクトを追加
    ''' </summary>
    ''' <param name="XY1"></param>
    ''' <param name="XY2"></param>
    ''' <param name="TagData"></param>
    ''' <remarks></remarks>
    Friend Sub AddDoublePoint(ByVal XY1 As PointF, ByVal XY2 As PointF, ByVal TagData As Integer)
        Dim XY() As PointF
        '

        If ObjectType <> SpatialPointType.SinglePoint Then
            MsgBox("点以外はできません。", vbExclamation)
            Exit Sub
        End If
        ReDim XY(1)
        XY(0) = XY1
        XY(1) = XY2
        Call Add_Point_Sub(2, XY, TagData)

    End Sub
    ''' <summary>
    ''' 1地点オブジェクトを追加
    ''' </summary>
    ''' <param name="XY"></param>
    ''' <param name="TagData"></param>
    ''' <remarks></remarks>
    Public Sub AddSinglePoint(ByVal XY As PointF, ByVal TagData As Integer)
        Dim XY2() As PointF
        '

        If ObjectType <> SpatialPointType.SinglePoint Then
            MsgBox("点以外はできません。", vbExclamation)
            Exit Sub
        End If
        ReDim XY2(0)
        XY2(0) = XY
        Call Add_Point_Sub(1, XY2, TagData)

    End Sub
    ''' <summary>
    ''' 1地点オブジェクトを配列で追加
    ''' </summary>
    ''' <param name="Num"></param>
    ''' <param name="XY"></param>
    ''' <param name="TagData"></param>
    ''' <remarks></remarks>
    Public Sub AddSinglePoint_Allay(ByVal Num As Integer, ByVal XY() As PointF, ByVal TagData As Integer)
        '
        Dim i As Integer
        Dim XYS() As PointF

        If ObjectType <> SpatialPointType.SinglePoint Then
            MsgBox("点以外はできません。", vbExclamation)
            Exit Sub
        End If

        ReDim XYS(0)

        For i = 0 To Num - 1
            XYS(0) = XY(i)
            Call Add_Point_Sub(1, XYS, TagData)
        Next

    End Sub
    ''' <summary>
    ''' 同じ地点を求め、番号を返す 存在しない場合は-1を返す
    ''' </summary>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="PointNumber"></param>
    ''' <param name="Tag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSamePointNumber(ByVal X As Single, ByVal Y As Single, ByRef PointNumber As Integer, ByRef Tag As Integer) As Integer
    

        If ObjectType <> SpatialPointType.SinglePoint Then
            MsgBox("点以外はできません。", vbExclamation)
            Return -1
        End If
        If ExtraRangeF = True Then
            MsgBox("GetSamePointNumberは大きさのあるポイントには実装されていません。")
            Return -1
        End If

        If ObjectNum = 0 Then
            Return -1
        End If

        Dim XY As PointF
        XY.x = X
        XY.Y = Y
        Dim sx As Integer, sy As Integer

        Dim exf As Boolean = GetConPointXY(XY, sx, sy)
        If exf = False Then
            Return -1
        End If
        Dim gn As Integer = -1
        With MeshIndex(sx, sy)
            If .ObjectNumber Is Nothing = False Then
                For i As Integer = 0 To .ObjectNumber.Count - 1
                    Dim n As Integer = .ObjectNumber(i).ObjectNumber
                    Dim np As Integer = .ObjectNumber(i).ObjectPointNumber
                    With ObjectXY(n).Point(np)
                        If .X = X Then
                            If .Y = Y Then
                                gn = n
                                PointNumber = np
                                Tag = ObjectXY(n).Tag
                                Exit For
                            End If
                        End If
                    End With
                Next
            End If
        End With
        Return gn
    End Function
    ''' <summary>
    ''' 同じ地点を求め、番号を返す 存在しない場合は-1を返す
    ''' </summary>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="ObjNumber"></param>
    ''' <param name="PNumber"></param>
    ''' <param name="Tags"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSamePointNumberAlley(ByVal X As Single, ByVal Y As Single, ByRef ObjNumber() As Integer, ByRef PNumber() As Integer, ByRef Tags() As Integer) As Integer

        If ObjectType <> SpatialPointType.SinglePoint Then
            MsgBox("点以外はできません。", vbExclamation)
            Return -1
        End If
        If ExtraRangeF = True Then
            MsgBox("GetSamePointNumberは大きさのあるポイントには実装されていません。")
            Return -1
        End If

        If ObjectNum = 0 Then
            Return -1
        End If

        Dim sx As Integer, sy As Integer

        Dim exf As Boolean, XY As PointF
        XY.x = X
        XY.y = Y
        exf = GetConPointXY(XY, sx, sy)
        If exf = False Then
            GetSamePointNumberAlley = -1
            Exit Function
        End If
        Dim obn As Integer = 0
        With MeshIndex(sx, sy)
            If .ObjectNumber Is Nothing = False Then
                Dim Num As Integer = .ObjectNumber.Count
                ReDim ObjNumber(Num - 1)
                ReDim Tags(Num - 1)
                ReDim PNumber(Num - 1)
                For i As Integer = 0 To Num - 1
                    Dim n As Integer = .ObjectNumber(i).ObjectNumber
                    Dim np As Integer = .ObjectNumber(i).ObjectPointNumber
                    With ObjectXY(n).Point(np)
                        If .X = X Then
                            If .Y = Y Then
                                ObjNumber(obn) = n
                                PNumber(obn) = np
                                Tags(obn) = ObjectXY(n).Tag
                                obn += 1
                            End If
                        End If
                    End With
                Next
            End If
        End With
        Return obn
    End Function
    Public Function GetNearestLineNumber(ByVal X As Single, ByVal Y As Single, ByVal BaseDistance As Single, _
                                         ByRef Onumber() As Integer, ByRef PNumber() As Integer, ByRef Tags() As Integer, _
                                        Optional ByRef Distance As Single = 0, Optional ByRef NearestP() As PointF = Nothing) As Integer


        If ObjectType <> SpatialPointType.SPILine Then
            MsgBox("線以外はできません。", vbExclamation)
            Return 0
        End If
        If ObjectNum = 0 Then
            Return 0
        End If

        If ObjectNum = 0 Then
            Return 0
        End If

        Dim sx As Integer, sy As Integer
        Dim ObStac(0) As Integer
        Dim PStac(0) As Integer
        Dim NearP(0) As PointF

        Dim XY As PointF = New PointF(X, Y)
        Dim exf As Boolean = GetConPointXY(XY, sx, sy)
        If exf = False Then
            Return 0
        End If

        Dim NearObjNum As Integer = -1



        Dim mind As Single = Math.Min(ExtraRange, BaseDistance)
        Dim same_N As Integer = 0
        With MeshIndex(sx, sy)
            If .ObjectNumber Is Nothing = False Then
                For i As Integer = 0 To .ObjectNumber.Count - 1
                    Dim Onum As Integer = .ObjectNumber(i).ObjectNumber
                    Dim SP As Integer = .ObjectNumber(i).ObjectPointNumber
                    Dim EP As Integer = SP + LineCutNum
                    If ObjectXY(Onum).Pnum < EP Then
                        EP = ObjectXY(Onum).Pnum
                    End If
                    Dim thisMin As Single = Math.Min(ExtraRange, BaseDistance)
                    Dim thisNearP As PointF
                    Dim thisNearPSub As PointF
                    Dim thisNearObjPoint As Integer = -1
                    '線分集合ごとに最短距離を求める
                    For j As Integer = SP To EP - 2
                        Dim D As Single
                        With ObjectXY(Onum)
                            D = spatial.Distance_PointLine(X, Y, .Point(j).X, .Point(j).Y, .Point(j + 1).X, .Point(j + 1).Y, thisNearPSub.X, thisNearPSub.Y)
                        End With
                        If D < thisMin Then
                            thisMin = D
                            thisNearP = thisNearPSub
                            thisNearObjPoint = j
                        End If
                    Next
                    If thisMin <= mind And thisNearObjPoint <> -1 Then
                        '線分集合の最短最小値がそれ以前の最短距離以下の場合
                        If thisMin = mind Then
                            ReDim Preserve ObStac(same_N)
                            ReDim Preserve PStac(same_N)
                            ReDim Preserve NearP(same_N)
                        Else
                            same_N = 0
                            ReDim ObStac(same_N)
                            ReDim PStac(same_N)
                            ReDim NearP(same_N)
                        End If
                        ObStac(same_N) = Onum
                        PStac(same_N) = thisNearObjPoint
                        NearP(same_N) = thisNearP
                        same_N += 1
                        mind = thisMin
                    End If
                Next
            End If
        End With
        If same_N > 0 Then
            Distance = mind
            Onumber = ObStac.Clone
            PNumber = PStac.Clone
            NearestP = NearP.Clone
        End If

        ReDim Tags(same_N)
        For i As Integer = 0 To same_N - 1
            Tags(i) = ObjectXY(ObStac(i)).Tag
        Next

        Return same_N
    End Function
    ''' <summary>
    ''' 最も近い地点を求め、数と番号（配列）を返す（複数出力） 存在しない場合は0を返す
    ''' </summary>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="BaseDistance"></param>
    ''' <param name="Onumber"></param>
    ''' <param name="PNumber"></param>
    ''' <param name="Tags"></param>
    ''' <param name="MinDistance">最小距離</param>
    ''' <param name="ExceptionNumber">除外番号（オプション）</param>
    ''' <param name="ExceptionTag">除外タグArrayList（オプション）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNearestPointNumber(ByVal X As Single, ByVal Y As Single, ByVal BaseDistance As Single, _
                                          ByRef Onumber() As Integer, ByRef PNumber() As Integer, ByRef Tags() As Integer,
                                          ByRef MinDistance As Single,
                                    Optional ByVal ExceptionNumber As Integer = -1, Optional ByVal ExceptionTag As ArrayList = Nothing) As Integer


        If ExceptionTag Is Nothing = True Then
            ExceptionTag = New ArrayList
        End If
        If ObjectType <> SpatialPointType.SinglePoint Then
            MsgBox("点以外はできません。", vbExclamation)
            Return 0
        End If

        If ExtraRangeF = False Then
            MsgBox("GetSamePointNumberは大きさのないポイントには実装されていません。")
            Return 0
        End If

        If ObjectNum = 0 Then
            Return 0
        End If


        Dim ObStac(0) As Integer, PStac(0) As Integer
        Dim sx As Integer, sy As Integer
        Dim XY As PointF
        XY.X = X
        XY.Y = Y
        Dim exf As Boolean = GetConPointXY(XY, sx, sy)
        If exf = False Then
            Return 0
        End If

        Dim mind As Single = Math.Min(ExtraRange, BaseDistance)
        Dim o_mind As Single = mind - 1
        Dim same_N As Integer = 0
        With MeshIndex(sx, sy)
            If .ObjectNumber Is Nothing = False Then
                For i As Integer = 0 To .ObjectNumber.Count - 1
                    Dim n As Integer = .ObjectNumber(i).ObjectNumber
                    Dim np As Integer = .ObjectNumber(i).ObjectPointNumber
                    If n <> ExceptionNumber And (ExceptionTag.IndexOf(ObjectXY(n).Tag) = -1) Then
                        With ObjectXY(n).Point(np)
                            Dim D As Single = spatial.get_Distance(X, Y, .X, .Y)
                            If D <= mind Then
                                If D = o_mind Then
                                    ReDim Preserve ObStac(same_N)
                                    ReDim Preserve PStac(same_N)
                                Else
                                    same_N = 0
                                    ReDim ObStac(same_N)
                                    ReDim PStac(same_N)
                                End If
                                ObStac(same_N) = n
                                PStac(same_N) = np
                                same_N = same_N + 1
                                mind = D
                                MinDistance = D
                                o_mind = mind
                            End If
                        End With
                    End If
                Next
            End If
        End With
        Onumber = ObStac
        PNumber = PStac
        ReDim Tags(same_N)
        For i As Integer = 0 To same_N - 1
            Tags(i) = ObjectXY(ObStac(i)).Tag
        Next
        Return same_N
    End Function
    ''' <summary>
    ''' 近い地点を近い順に返す、数と番号（配列）を返す（複数出力） 存在しない場合は-1を返す
    ''' </summary>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="BaseDistance"></param>
    ''' <param name="Onumber"></param>
    ''' <param name="PNumber"></param>
    ''' <param name="Tags"></param>
    ''' <param name="Distance"></param>
    ''' <param name="ExceptionNumber"></param>
    ''' <param name="ExceptionTag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNearPointNumber(ByVal X As Single, ByVal Y As Single, ByVal BaseDistance As Single, ByRef Onumber() As Integer, ByRef PNumber() As Integer,
                            ByRef Tags() As Integer, ByRef Distance() As Single,
                            Optional ByVal ExceptionNumber As Integer = -1, Optional ByVal ExceptionTag As ArrayList = Nothing) As Integer

        If ObjectType <> SpatialPointType.SinglePoint Then
            MsgBox("点以外はできません。", vbExclamation)
            Return 0
        End If

        If ExtraRangeF = False Then
            MsgBox("GetSamePointNumberは大きさのないポイントには実装されていません。")
            Return 0
        End If

        If ObjectNum = 0 Then
            Return 0
            Exit Function
        End If

        If ExceptionTag Is Nothing = True Then
            ExceptionTag = New ArrayList
        End If

        Dim XY As PointF
        XY.X = X
        XY.Y = Y
        Dim sx As Integer, sy As Integer
        Dim exf As Boolean = GetConPointXY(XY, sx, sy)
        If exf = False Then
            Return 0
            Exit Function
        End If

        Dim mind As Single = Math.Min(ExtraRange, BaseDistance)
        Dim dn As Integer = 0
        If MeshIndex(sx, sy).ObjectNumber Is Nothing = False Then
            dn = MeshIndex(sx, sy).ObjectNumber.Count
        End If
        ReDim Distance(dn)
        Dim ObStac(dn) As Integer
        Dim PStac(dn) As Integer
        Dim get_N As Integer = 0
        With MeshIndex(sx, sy)
            For i As Integer = 0 To dn - 1
                Dim n As Integer = .ObjectNumber(i).ObjectNumber
                Dim np As Integer = .ObjectNumber(i).ObjectPointNumber
                If n <> ExceptionNumber And (ExceptionTag.IndexOf(ObjectXY(n).Tag) = -1) Then
                    With ObjectXY(n).Point(np)
                        Dim D As Single = spatial.get_Distance(X, Y, .X, .Y)
                        If D < mind Then
                            Distance(get_N) = D
                            ObStac(get_N) = n
                            PStac(get_N) = np
                            get_N += 1
                        End If
                    End With
                End If
            Next
        End With
        Onumber = ObStac
        PNumber = PStac
        ReDim Tags(get_N)
        For i As Integer = 0 To get_N - 1
            Tags(i) = ObjectXY(ObStac(i)).Tag
        Next
        Return get_N
    End Function
    ''' <summary>
    ''' 指定した点が入る四角領域を取得
    ''' </summary>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="Onumber"></param>
    ''' <param name="Tags"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRectIn(ByVal X As Single, ByVal Y As Single, ByRef Onumber() As Integer, ByRef Tags() As Integer) As Integer
        '

        If ObjectType <> SpatialPointType.SPIRect Then
            MsgBox("四角以外はできません。", vbExclamation)
            Return 0
        End If


        If ObjectNum = 0 Then
            Return 0
        End If


        Dim XY As PointF
        Dim sx As Integer, sy As Integer
        XY.X = X
        XY.Y = Y
        Dim exf As Boolean = GetConPointXY(XY, sx, sy)
        If exf = False Then
            Return 0
        End If

        Dim same_N As Integer = 0
        Dim ObStac(same_N) As Integer
        With MeshIndex(sx, sy)
            If .ObjectNumber Is Nothing = False Then
                For i As Integer = 0 To .ObjectNumber.Count - 1
                    Dim n As Integer = .ObjectNumber(i).ObjectNumber
                    With ObjectXY(n)
                        Dim PBox As RectangleF = spatial.Get_Rectangle(.Point(0), .Point(1))
                        If spatial.Check_PointInBox(X, Y, 0, PBox) = True Then
                            ReDim Preserve ObStac(same_N)
                            ObStac(same_N) = n
                            same_N += 1
                        End If
                    End With
                Next
            End If
        End With
        Onumber = ObStac
        ReDim Tags(same_N)
        For i As Integer = 0 To same_N - 1
            Tags(i) = ObjectXY(ObStac(i)).Tag
        Next
        Return same_N

    End Function
    ''' <summary>
    ''' 指定した領域と重なる四角領域を取得
    ''' </summary>
    ''' <param name="XY1"></param>
    ''' <param name="XY2"></param>
    ''' <param name="Onumber"></param>
    ''' <param name="Tags"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRectOverlap(ByVal XY1 As PointF, ByVal XY2 As PointF, ByRef Onumber() As Integer, ByRef Tags() As Integer) As Integer
        '
 
        If ObjectType <> SpatialPointType.SPIRect Then
            MsgBox("四角以外はできません。", vbExclamation)
            Return 0
        End If

        If ObjectNum = 0 Then
            GetRectOverlap = 0
            Exit Function
        End If


        Dim QBox As RectangleF = spatial.Get_Rectangle(XY1, XY2)
        Dim Q2box As Rectangle
        Dim f As Boolean = GetRangeXY(QBox, Q2box)

        If f = False Then
            Return 0
            Exit Function
        End If

        Dim OSub(ObjectNum - 1) As Boolean
        Dim same_N As Integer = 0
        Dim ObStac(same_N) As Integer
        With Q2box
            For sx As Integer = .Left To .Right
                For sy As Integer = .Top To .Bottom
                    With MeshIndex(sx, sy)
                        If .ObjectNumber Is Nothing = False Then
                            For i As Integer = 0 To .ObjectNumber.Count - 1
                                Dim n As Integer = .ObjectNumber(i).ObjectNumber
                                If OSub(n) = False Then
                                    With ObjectXY(n)
                                        OSub(n) = True
                                        Dim PBox As RectangleF = spatial.Get_Rectangle(.Point(0), .Point(1))
                                        If spatial.Compare_Two_Rectangle_Position(QBox, PBox) <> cstRectangle_Cross.cstOuter Then
                                            ReDim Preserve ObStac(same_N)
                                            ObStac(same_N) = n
                                            same_N += 1
                                        End If
                                    End With
                                End If
                            Next
                        End If
                    End With
                Next
            Next
        End With
        Onumber = ObStac
        ReDim Tags(same_N)
        For i As Integer = 0 To same_N - 1
            Tags(i) = ObjectXY(ObStac(i)).Tag
        Next
        Return same_N

    End Function
    ''' <summary>
    ''' '指定したオブジェクト番号を検索インデックスから削除
    ''' </summary>
    ''' <param name="Number"></param>
    ''' <remarks></remarks>
    Public Sub RemoveObject(ByVal Number As Integer)

        ObjectXY(Number).RemoveF = True
        Select Case ObjectType
            Case SpatialPointType.SinglePoint
                Call AddMeshPoint(Number, Add_or_Remove.Remove_Obj)
            Case SpatialPointType.SPILine
                For i As Integer = 0 To ObjectXY(Number).Pnum - 1 Step LineCutNum
                    Call Add_Mesh_LineSub(Number, i, Add_or_Remove.Remove_Obj)
                Next
            Case SpatialPointType.SPIRect
                Call AddMeshRect(Number, Add_or_Remove.Remove_Obj)
        End Select
    End Sub
    Private Sub RemoveObject_sub(ByVal X As Integer, ByVal Y As Integer, ByVal Number As Integer)

        With MeshIndex(X, Y)
            Dim i As Integer = 0
            Do Until .ObjectNumber(i).ObjectNumber = Number
                i += 1
            Loop
            .ObjectNumber.RemoveAt(i)
        End With

    End Sub
    ''' <summary>
    ''' 指定したタグのオブジェクトの検索インデックスを削除
    ''' </summary>
    ''' <param name="TagNumber"></param>
    ''' <remarks></remarks>
    Public Sub RemoveObject_byTag(ByVal TagNumber As Integer)

        For i As Integer = 0 To ObjectNum - 1
            If ObjectXY(i).Tag = TagNumber Then
                If ObjectXY(i).RemoveF = False Then
                    Call RemoveObject(i)
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' 線オブジェクト追加
    ''' </summary>
    ''' <param name="Pnum"></param>
    ''' <param name="XY"></param>
    ''' <param name="TagData"></param>
    ''' <remarks></remarks>
    Public Sub AddLine(ByVal Pnum As Integer, ByVal XY() As PointF, ByVal TagData As Integer)
        '

        If ObjectType <> SpatialPointType.SPILine Then
            MsgBox("線以外はできません。", vbExclamation)
            Exit Sub
        End If

        Call Add_Point_Sub(Pnum, XY, TagData)

    End Sub
    ''' <summary>
    ''' タグの値を変化させる
    ''' </summary>
    ''' <param name="ChangeValue"></param>
    ''' <param name="StartRangeValue"></param>
    ''' <param name="LastRangeValue"></param>
    ''' <remarks></remarks>
    Private Sub ChangeTagValue(ByVal ChangeValue As Integer, ByVal StartRangeValue As Integer, ByVal LastRangeValue As Integer)
        '
        Dim i As Integer

        For i = 0 To ObjectNum - 1
            If clsGeneric.Check_Two_Value_In(ObjectXY(i).Tag, StartRangeValue, LastRangeValue) <> chvValue_on_twoValue.chvOuter Then
                ObjectXY(i).Tag = ObjectXY(i).Tag + ChangeValue
            End If
        Next

    End Sub
    ''' <summary>
    ''' 四角オブジェクトを追加
    ''' </summary>
    ''' <param name="XY1"></param>
    ''' <param name="XY2"></param>
    ''' <param name="TagData"></param>
    ''' <remarks></remarks>
    Public Sub AddRect(ByVal XY1 As PointF, ByVal XY2 As PointF, ByVal TagData As Integer)
        Dim XY() As PointF
        '

        If ObjectType <> SpatialPointType.SPIRect Then
            MsgBox("四角以外はできません。", vbExclamation)
            Exit Sub
        End If
        ReDim XY(1)
        XY(0) = XY1
        XY(1) = XY2
        Call Add_Point_Sub(2, XY, TagData)

    End Sub
    ''' <summary>
    ''' 四角オブジェクトを追加
    ''' </summary>
    ''' <param name="RectBox"></param>
    ''' <param name="TagData"></param>
    ''' <remarks></remarks>
    Public Sub AddRect(ByVal RectBox As RectangleF, ByVal TagData As Integer)
        Dim XY() As PointF
        '

        If ObjectType <> SpatialPointType.SPIRect Then
            MsgBox("四角以外はできません。", vbExclamation)
            Exit Sub
        End If
        ReDim XY(1)
        XY(0).X = RectBox.Left
        XY(0).Y = RectBox.Top
        XY(1).X = RectBox.Right
        XY(1).Y = RectBox.Bottom
        Call Add_Point_Sub(2, XY, TagData)

    End Sub

End Class
