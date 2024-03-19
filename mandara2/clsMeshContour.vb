Public Class clsMeshContour
    Public Structure ContourLineStacInfo
        Public Number As Integer
        Public PointStac As Integer
        Public PointNum As Integer
    End Structure
    Private Const ConValuePlus = 0.0001
    '等値線取得クラス
    Private Structure Quad_Mesh_Info
        Public Positon As Rectangle
        Public Max As Single
        Public Min As Single
        Public LackF As Boolean
    End Structure
    Private Quad_MeshData() As Quad_Mesh_Info
    Private Mesh(,) As Single
    Private Lack_Mesh(,) As Boolean
    'Mesh()　数値入りのメッシュデータ
    'Lack_Mesh()　trueのメッシュの場合は計算から除外

    Private XMeshNum As Integer
    Private YMeshNum As Integer
    Private XMeshSize As Single
    Private YMeshSize As Single
    Private Xplus As Single
    Private YPlus As Single
    ''' <summary>
    ''' メッシュの初期化
    ''' </summary>
    ''' <param name="XMesh_Num">横メッシュ数</param>
    ''' <param name="YMesh_Num">縦メッシュ数</param>
    ''' <param name="Xmesh_Size">横メッシュの全体幅</param>
    ''' <param name="YMesh_Size">縦メッシュの全体高さ</param>
    ''' <param name="X_plus">左上の座標</param>
    ''' <param name="Y_Plus">右上の座標</param>
    ''' <remarks></remarks>
    Public Sub SetMeshInfo(ByVal XMesh_Num As Integer, ByVal YMesh_Num As Integer, ByVal Xmesh_Size As Single, ByVal YMesh_Size As Single,
                           ByVal X_plus As Single, ByVal Y_Plus As Single)


        XMeshNum = XMesh_Num
        YMeshNum = YMesh_Num
        XMeshSize = Xmesh_Size
        YMeshSize = YMesh_Size
        Xplus = X_plus
        YPlus = Y_Plus


        ReDim Mesh(XMeshNum - 1, YMeshNum - 1)


        ReDim Lack_Mesh(XMeshNum - 1, YMeshNum - 1)
    End Sub

    Public Sub SetMeshValue(ByVal X As Integer, ByVal Y As Integer, ByVal V As Double)
        Mesh(X, Y) = V
    End Sub


    Public Sub SetLack(ByVal X As Integer, ByVal Y As Integer, ByVal V As Boolean)
        Lack_Mesh(X, Y) = V
    End Sub
    Public Function GetLack(ByVal X As Integer, ByVal Y As Integer) As Boolean
        Return Lack_Mesh(X, Y)
    End Function

    Public Function GetMeshValue(ByVal X As Integer, ByVal Y As Integer) As Double
        Return Mesh(X, Y)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ContourNum">取得する等値線の数</param>
    ''' <param name="Contour_High_M">等高線の値の配列</param>
    ''' <param name="Con_LineStac">ContourLineStacInfo構造体の配列</param>
    ''' <param name="Con_Point">座標列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function Execute_Mesh(ByVal ContourNum As Integer, ByVal Contour_High_M() As Double,
                                 ByRef Con_LineStac() As ContourLineStacInfo, ByRef Con_Point() As PointF) As Integer

        '出力
        '戻り値：線の数
        'Con_LineStac() (0)等高線番号　(1)点スタックの始め　(2)点の数～　線の数分繰り返す
        'Con_Point() xy座標
        Dim High_CN(ContourNum - 1) As Integer
        Dim con(1, ContourNum - 1, 500) As PointF

        'ProgressLabel.Visible = True
        'ProgressLabel.Start(ContourNum + 1, "等値線計算中1")
        Dim max_PartitiopnLevel As Integer = Get_PartitiopnLevel(XMeshNum, YMeshNum)
        Call Set_MeshQuadTree(Mesh, Lack_Mesh, XMeshNum, YMeshNum, max_PartitiopnLevel)
        For k As Integer = 0 To ContourNum - 1
            'ProgressLabel.SetValue k + 1
            'DoEvents()

            Dim PCell() As Integer
            Dim n As Integer
            Dim High As Double = Contour_High_M(k) + ConValuePlus
            Call Get_Quad_MeshCell(High, PCell, 0, 0, n, max_PartitiopnLevel)
            For i As Integer = 0 To n - 1
                With Quad_MeshData(PCell(i)).Positon
                    For j As Integer = .Left To .Right
                        For k2 As Integer = .Top To .Bottom
                            If Lack_Mesh(j, k2) = False Then
                                Call Mesh_Sub(con, Mesh, j, k2, k, High, High_CN)
                            End If
                        Next
                    Next
                End With
            Next
        Next


        '    'テストのために使う
        '    For k = 0 To ContourNum - 1
        '        High = High_M(k) + 0.0001
        '        ProgressLabel.SetValue k
        '        cn = 0
        '        For i = 0 To XMeshNum - 2
        '            For j = 0 To YMeshNum - 2
        '                If Lack_Mesh(i, j) = False Then
        '                    Call Mesh_Sub(con(), Mesh(), i, j, k, High, High_CN())
        '                End If
        '            Next j
        '        Next i
        '    Next

        ' Debug.Print max_PartitiopnLevel; n; Timer - T
        'ProgressLabel.Visible = False


        Dim caap As Integer = 0
        Dim all_Pon As Integer = 0
        Dim ConPNum As Integer = 0


        ReDim Con_LineStac(0)
        ReDim Con_Point(0)


        'ProgressLabel.Visible = True
        'ProgressLabel.Start(ContourNum + 1, "等値線計算中2")

        For i As Integer = 0 To ContourNum - 1
            'ProgressLabel.SetValue i + 1
            'DoEvents()

            Dim NL As Integer = High_CN(i)
            If 0 < NL Then
                Dim PointIndex As clsSpatialIndexSearch
                Dim PointTag As Integer
                Dim Pointnum As Integer
                PointIndex = New clsSpatialIndexSearch
                Dim Arrange_LineCode(NL, 1) As Integer
                Dim Fringe(NL) As clsMapData.Fringe_Line_Info
                Dim Get_Linef(NL) As Boolean
                PointIndex.Init(SpatialPointType.SinglePoint, False, 0, 0, XMeshNum, YMeshNum)
                For j As Integer = 0 To NL - 1
                    PointIndex.AddDoublePoint(con(0, i, j), con(1, i, j), j)
                Next
                PointIndex.AddEnd()

                Dim fnl As Integer = 0
                Dim Pon As Integer = 0
                Dim Contf As Boolean = False
                Do While fnl < NL
                    Dim stxy As PointF
                    Dim exy As PointF
                    Dim Reverse_f As Boolean
                    Dim js As Integer = 0
                    If Contf = False Then
                        For j As Integer = 0 To NL - 1
                            '始点の探索
                            If Get_Linef(j) = False Then
                                Arrange_LineCode(Pon, 0) = fnl
                                Arrange_LineCode(Pon, 1) = 1
                                Get_Linef(j) = True
                                Fringe(fnl).code = j
                                Fringe(fnl).Direction = 1
                                fnl += 1
                                stxy = con(0, i, j)
                                exy = con(1, i, j)
                                PointIndex.RemoveObject(j)
                                Reverse_f = False
                                js = j
                                Exit For
                            End If
                        Next
                    End If
                    Contf = False
                    '始点Xチェック
                    Dim LineNO2 As Integer = PointIndex.GetSamePointNumber(exy.X, exy.Y, Pointnum, PointTag)
                    If LineNO2 <> -1 Then
                        Contf = True
                        Get_Linef(PointTag) = True
                        Arrange_LineCode(Pon, 1) = Arrange_LineCode(Pon, 1) + 1
                        Fringe(fnl).code = PointTag
                        If Pointnum = 0 Then
                            exy = con(1, i, PointTag)
                            Fringe(fnl).Direction = 1 '順方向
                        Else
                            exy = con(0, i, PointTag)
                            Fringe(fnl).Direction = -1 '逆方向
                        End If
                        PointIndex.RemoveObject(PointTag)
                        fnl += 1
                    End If


                    If exy.Equals(stxy) = True Then
                        Contf = False
                        Pon += 1
                    Else
                        If Contf = False Then
                            If Reverse_f = False Then
                                '始点も終点もチェックしてない場合は、初期の始点と終点を入れ替えて繰り返す
                                Reverse_f = True
                                Dim k2 As Integer = Arrange_LineCode(Pon, 0)
                                Dim Kn As Integer = Arrange_LineCode(Pon, 1)
                                Dim Fringe_Sub(Kn - 1) As clsMapData.Fringe_Line_Info
                                For k As Integer = 0 To Kn - 1
                                    Fringe_Sub(k) = Fringe(k2 + k)
                                Next
                                For k As Integer = 0 To Kn - 1
                                    Fringe(k2 + k) = Fringe_Sub(Kn - k - 1)
                                    Fringe(k2 + k).Direction = -Fringe(k2 + k).Direction
                                Next
                                stxy = con(1, i, js)
                                exy = con(0, i, js)
                                Contf = True
                            Else
                                Contf = False
                                Pon += 1
                            End If
                        End If
                    End If
                Loop
                PointIndex = Nothing

                If Contf = True Then
                    Pon += 1
                End If

                ReDim Preserve Con_LineStac(all_Pon + Pon)

                For j As Integer = 0 To Pon - 1
                    caap += Arrange_LineCode(j, 1) + 1
                Next
                ReDim Preserve Con_Point(caap)
                For j As Integer = 0 To Pon - 1
                    With Con_LineStac(all_Pon + j)
                        .Number = i
                        .PointStac = ConPNum
                        .PointNum = Arrange_LineCode(j, 1) + 1
                    End With
                    Dim k2 As Integer = Arrange_LineCode(j, 0)
                    With Fringe(k2)
                        If .Direction = 1 Then
                            Con_Point(ConPNum) = con(0, i, .code)
                            Con_Point(ConPNum + 1) = con(1, i, .code)
                        Else
                            Con_Point(ConPNum) = con(1, i, .code)
                            Con_Point(ConPNum + 1) = con(0, i, .code)
                        End If
                    End With
                    ConPNum += 2
                    For k As Integer = 1 To Arrange_LineCode(j, 1) - 1
                        With Fringe(k2 + k)
                            If .Direction = 1 Then
                                Con_Point(ConPNum) = con(1, i, .code)
                            Else
                                Con_Point(ConPNum) = con(0, i, .code)
                            End If
                        End With
                        ConPNum += 1
                    Next
                Next
                all_Pon += Pon
            End If
        Next

        For i As Integer = 0 To ConPNum - 1
            With Con_Point(i)
                .X = Xplus + .X / (XMeshNum - 1) * XMeshSize
                .Y = YPlus + .Y / (YMeshNum - 1) * YMeshSize
            End With
        Next
        'ProgressLabel.Visible = False
        Return all_Pon

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="GetSide">0左 1上 2右 3下</param>
    ''' <param name="ContourNum">取得する等値線の数</param>
    ''' <param name="Contour_High_M">等高線の値の配列</param>
    ''' <param name="Frame_LineContour">等高線番号(戻り値)</param>
    ''' <param name="Frame_Point">xy座標(戻り値)</param>
    ''' <returns>線の数</returns>
    ''' <remarks></remarks>
    Friend Function Execute_FrameGet(ByVal GetSide As Integer, ByVal ContourNum As Integer, ByVal Contour_High_M() As Double, _
                            ByRef Frame_LineContour() As Integer, ByRef Frame_Point() As PointF) As Integer

        Dim sx As Integer, sy As Integer, ex As Integer, EY As Integer

        For i As Integer = 0 To ContourNum - 2
            '等高線が低→高に並べ替えてある必要
            If Contour_High_M(i + 1) < Contour_High_M(i) Then
                Return -1
            End If
        Next

        Select Case GetSide
            Case 0
                sx = 0
                sy = 0
                ex = 0
                EY = YMeshNum - 1
            Case 1
                sx = 0
                sy = 0
                ex = XMeshNum - 1
                EY = 0
            Case 2
                sx = XMeshNum - 1
                sy = 0
                ex = XMeshNum - 1
                EY = YMeshNum - 1
            Case 3
                sx = 0
                sy = YMeshNum - 1
                ex = XMeshNum - 1
                EY = YMeshNum - 1
        End Select


        Dim vn As Integer
        Dim VP() As PointF
        Dim VPC() As Integer

        Select Case GetSide
            Case 0
                vn = GetFrameSub(ContourNum, Contour_High_M, sx, sy, 0, 1, YMeshNum, VP, VPC)
            Case 1
                vn = GetFrameSub(ContourNum, Contour_High_M, sx, sy, 1, 0, XMeshNum, VP, VPC)
            Case 2
                vn = GetFrameSub(ContourNum, Contour_High_M, ex, sy, 0, 1, YMeshNum, VP, VPC)
            Case 3
                vn = GetFrameSub(ContourNum, Contour_High_M, sx, EY, 1, 0, XMeshNum, VP, VPC)
        End Select

        For i As Integer = 0 To vn - 1
            With VP(i)
                .X = Xplus + .X / (XMeshNum - 1) * XMeshSize
                .Y = YPlus + .Y / (YMeshNum - 1) * YMeshSize
            End With
        Next
        Frame_LineContour = VPC
        Frame_Point = VP
        Return vn
    End Function
    Private Function GetFrameSub(ByVal ContourNum As Integer, ByVal Contour_High_M() As Double,
                                 ByVal sx As Integer, ByVal sy As Integer, ByVal Xplus As Integer, ByVal YPlus As Integer,
                                 ByVal LoopNum As Integer, ByRef Vpoint() As PointF, ByRef Vcon() As Integer) As Integer


        Dim SepV(10) As Single
        Dim VPC(10) As Integer

        '始終点のコンターの位置を取得
        Dim SPN As Integer = -1
        For i As Integer = ContourNum - 1 To 0 Step -1
            If Contour_High_M(i) + ConValuePlus <= Mesh(sx, sy) Then
                SPN = i
                Exit For
            End If
        Next
        SepV(0) = 0
        VPC(0) = SPN

        Dim ex As Integer = sx + (LoopNum - 1) * Xplus
        Dim EY As Integer = sy + (LoopNum - 1) * YPlus
        Dim EPN As Integer = -1
        For i As Integer = ContourNum - 1 To 0 Step -1
            If Contour_High_M(i) + ConValuePlus <= Mesh(ex, EY) Then
                EPN = i
                Exit For
            End If
        Next
        SepV(1) = LoopNum - 1
        VPC(1) = EPN

        'コンターの区切り箇所を取得
        Dim VPN As Integer = 2
        For i As Integer = 0 To LoopNum - 2
            Dim V1 As Single = Mesh(sx + i * Xplus, sy + i * YPlus)
            Dim V2 As Single = Mesh(sx + (i + 1) * Xplus, sy + (i + 1) * YPlus)
            For j As Integer = 0 To ContourNum - 1
                'Doubleにしないとうまくいかないケースがある
                Dim High As Double = Contour_High_M(j) + ConValuePlus
                Dim VH1 As Double = CDbl(V1) - High
                Dim VH2 As Double = CDbl(V2) - High
                If ((VH1 <= 0 And VH2 >= 0) Or (VH1 >= 0 And VH2 <= 0)) And V1 <> V2 Then
                    If UBound(SepV) <= VPN Then
                        ReDim Preserve SepV(VPN + 10)
                        ReDim Preserve VPC(VPN + 10)
                    End If
                    SepV(VPN) = i + Math.Abs(VH1 / (V1 - V2))
                    If V1 < V2 Then
                        VPC(VPN) = j
                    Else
                        VPC(VPN) = j - 1
                    End If
                    VPN += 1
                End If
            Next
        Next

        Dim SepVSort As New clsSortingSearch
        SepVSort.AddRange(VPN, SepV)
        Dim VPC2(VPN) As Integer
        Dim VP(VPN) As PointF

        'コンターを並べ替える
        Dim n As Integer = 0
        For i As Integer = 0 To VPN - 1
            Dim j As Integer = SepVSort.DataPosition(i)
            Dim f As Boolean = False
            If i = 0 Then
                f = True
            Else
                If SepVSort.DataPositionValue_Single(i - 1) <> SepVSort.DataPositionValue_Single(i) Then
                    f = True
                End If
            End If
            If f = True Then
                VPC2(n) = VPC(j)
                If Xplus = 1 Then
                    VP(n).X = SepV(j)
                    VP(n).Y = sy
                Else
                    VP(n).X = sx
                    VP(n).Y = SepV(j)
                End If
                n += 1
            Else
                If i <> VPN - 1 Then
                    n -= 1
                End If
            End If
        Next

        Vpoint = VP
        Vcon = VPC2
        Return n
    End Function
    Private Sub Mesh_Sub(ByRef con(,,) As PointF, ByRef Mesh(,) As Single, ByVal mi As Integer, ByVal mj As Integer,
                         ByVal HK As Integer, High As Double, High_CN() As Integer)



        'メッシュ内で横切る等値線を取得

        Dim V1 As Double = Mesh(mi, mj)
        Dim V2 As Double = Mesh(mi + 1, mj)
        Dim V3 As Double = Mesh(mi, mj + 1)
        Dim V4 As Double = Mesh(mi + 1, mj + 1)


        '取得する等高線の値とメッシュの４すみを比較
        Dim VH1 As Double = V1 - High
        Dim VH2 As Double = V2 - High
        Dim VH3 As Double = V3 - High
        Dim VH4 As Double = V4 - High
        Dim Q As Integer = 0
        Dim C12 As Integer = 0
        Dim C24 As Integer = 0
        Dim C34 As Integer = 0
        Dim C13 As Integer = 0
        If ((VH1 <= 0 And VH2 >= 0) Or (VH1 >= 0 And VH2 <= 0)) And V1 <> V2 Then C12 = 1 : Q += 1
        If ((VH2 <= 0 And VH4 >= 0) Or (VH2 >= 0 And VH4 <= 0)) And V2 <> V4 Then C24 = 1 : Q += 1
        If ((VH4 <= 0 And VH3 >= 0) Or (VH4 >= 0 And VH3 <= 0)) And V3 <> V4 Then C34 = 1 : Q += 1
        If ((VH1 <= 0 And VH3 >= 0) Or (VH1 >= 0 And VH3 <= 0)) And V1 <> V3 Then C13 = 1 : Q += 1



        Select Case Q
            Case 2
                R2220(mi, mj, C12, C34, C24, C13, VH1, VH2, VH3, VH4, V1, V2, V3, V4, HK, High_CN, con)
            Case 4
                If V2 = High And V3 = High Then
                    C12 = 1 : C13 = 1
                    R2220(mi, mj, C12, C34, C24, C13, VH1, VH2, VH3, VH4, V1, V2, V3, V4, HK, High_CN, con)
                Else
                    C34 = 0 : C13 = 0 : C12 = 1 : C24 = 1
                    R2220(mi, mj, C12, C34, C24, C13, VH1, VH2, VH3, VH4, V1, V2, V3, V4, HK, High_CN, con)
                    C12 = 0 : C24 = 0 : C34 = 1 : C13 = 1
                    R2220(mi, mj, C12, C34, C24, C13, VH1, VH2, VH3, VH4, V1, V2, V3, V4, HK, High_CN, con)
                End If
            Case 3
                If C12 = 1 And C24 = 1 And V2 = High Then C12 = 0
                If C12 = 1 And C13 = 1 And V1 = High Then C12 = 0
                If C24 = 1 And C34 = 1 And V4 = High Then C24 = 0
                If C34 = 1 And C13 = 1 And V3 = High Then C13 = 0
                R2220(mi, mj, C12, C34, C24, C13, VH1, VH2, VH3, VH4, V1, V2, V3, V4, HK, High_CN, con)
        End Select



    End Sub
    Private Sub R2220(ByVal mi As Integer, ByVal mj As Integer,
                      ByVal C12 As Integer, ByVal C34 As Integer, ByVal C24 As Integer, ByVal C13 As Integer,
                      ByVal VH1 As Double, ByVal VH2 As Double, ByVal VH3 As Double, ByVal VH4 As Double,
                      ByVal V1 As Double, ByVal V2 As Double, ByVal V3 As Double, ByVal V4 As Double,
                      ByVal HK As Integer, ByRef High_CN() As Integer, ByRef con(,,) As PointF)
        Dim po(4) As PointF
        Dim T As Integer = 0
        If C12 = 1 Then
            po(T).Y = mj
            po(T).X = mi + Math.Abs(VH1 / (V1 - V2))
            T += 1
        End If
        If C34 = 1 Then
            po(T).Y = mj + 1
            po(T).X = mi + Math.Abs(VH3 / (V3 - V4))
            T += 1
        End If
        If C24 = 1 Then
            po(T).X = mi + 1
            po(T).Y = mj + Math.Abs(VH2 / (V2 - V4))
            T += 1
        End If
        If C13 = 1 Then
            po(T).X = mi
            po(T).Y = mj + Math.Abs(VH1 / (V1 - V3))
            T += 1
        End If
        If T < 2 Then
            Return 'Tはほぼ常に２で２未満のことはない
        End If
        Dim Pon As Integer = High_CN(HK)
        If UBound(con, 3) < Pon Then
            ReDim Preserve con(1, UBound(con, 2), Pon + 500)
        End If

        'con(0, HK, Pon).X = Val(CStr(CSng((po(0).X))))
        'con(0, HK, Pon).Y = Val(CStr(CSng((po(0).Y))))
        'con(1, HK, Pon).X = Val(CStr(CSng((po(1).X))))
        'con(1, HK, Pon).Y = Val(CStr(CSng((po(1).Y))))

        con(0, HK, Pon) = po(0)
        con(1, HK, Pon) = po(1)
        If con(0, HK, Pon).X = con(1, HK, Pon).X And con(0, HK, Pon).Y = con(1, HK, Pon).Y Then
            '二つの座標が同じになってしまう場合は含めない
        Else
            High_CN(HK) = Pon + 1
        End If
    End Sub

    Private Function TohiSuretu_no_Wa(ByVal shokou As Integer, ByVal kouhi As Integer, ByVal n As Integer) As Integer
        Return shokou * (1 - kouhi ^ n) / (1 - kouhi)
    End Function
    Private Function Get_MortonNumberXY(ByVal X As Integer, ByVal Y As Integer, ByVal SpaceLevel As Integer, ByVal max_PartitiopnLevel As Integer) As Integer
        'メッシュの四分木データ作成 As integer
        '点の座標値から所属するモートン空間番号を出す

        Dim zero As String = New String("0", max_PartitiopnLevel)
        Dim x2 As String = Right(zero & Convert.ToString(X, 2), max_PartitiopnLevel)
        Dim y2 As String = Right(zero & Convert.ToString(Y, 2), max_PartitiopnLevel)

        Dim Num As String = ""
        For i As Integer = 1 To max_PartitiopnLevel
            Num += Mid(y2, i, 1) + Mid(x2, i, 1)
        Next
        Return Convert.ToInt32(Num, 2) + TohiSuretu_no_Wa(1, 4, SpaceLevel)
    End Function
    Private Sub Set_MeshQuadTree(ByRef Mesh(,) As Single, ByRef Lack_Mesh(,) As Boolean,
                                      ByVal xw As Integer, ByVal yw As Integer, ByVal max_PartitiopnLevel As Integer)
        'メッシュの四分木データ作成


        Dim mxv As Single, mnv As Single

        Dim stp As Integer = 2 ^ (max_PartitiopnLevel - 1)
        Dim w As Integer = xw \ stp
        Dim H As Integer = yw \ stp

        ReDim Quad_MeshData(TohiSuretu_no_Wa(1, 4, max_PartitiopnLevel) - 1)
        For i As Integer = 0 To stp - 1
            Dim h2 As Integer
            If i = stp - 1 Then
                h2 = H + (yw Mod stp)
            Else
                h2 = H + 1 '1メッシュ分重複を持たせる
            End If
            For j As Integer = 0 To stp - 1
                Dim w2 As Integer
                If j = stp - 1 Then
                    w2 = w + (xw Mod stp)
                Else
                    w2 = w + 1  '1メッシュ分重複を持たせる
                End If
                Dim f As Boolean = True
                For ky As Integer = 0 To h2 - 1
                    Dim py As Integer = i * H + ky
                    For kx As Integer = 0 To w2 - 1
                        Dim px As Integer = j * w + kx
                        If Lack_Mesh(px, py) = False Then
                            If f = True Then
                                mxv = Mesh(px, py)
                                mnv = mxv
                                f = False
                            Else
                                If mxv < Mesh(px, py) Then
                                    mxv = Mesh(px, py)
                                ElseIf Mesh(px, py) < mnv Then
                                    mnv = Mesh(px, py)
                                End If
                            End If
                        End If
                    Next
                Next
                Dim mon As Integer = Get_MortonNumberXY(j, i, max_PartitiopnLevel - 1, max_PartitiopnLevel)
                With Quad_MeshData(mon)
                    .LackF = f
                    .Max = mxv
                    .Min = mnv
                    .Positon = New Rectangle(j * w, i * H, w2 - 2, h2 - 2)
                End With
            Next
        Next


        For k As Integer = max_PartitiopnLevel - 1 To 1 Step -1
            Dim SP As Integer = TohiSuretu_no_Wa(1, 4, k)
            Dim SP2 As Integer = TohiSuretu_no_Wa(1, 4, k - 1)
            For i As Integer = 0 To 4 ^ k - 1 Step 4
                Dim f As Boolean = True
                For j As Integer = 0 To 3
                    With Quad_MeshData(SP + i + j)
                        If .LackF = False Then
                            If f = True Then
                                mxv = .Max
                                mnv = .Min
                                f = False
                            Else
                                If mxv < .Max Then
                                    mxv = .Max
                                End If
                                If .Min < mnv Then
                                    mnv = .Min
                                End If
                            End If
                        End If
                    End With
                Next
                With Quad_MeshData(SP2 + i \ 4)
                    .LackF = f
                    .Max = mxv
                    .Min = mnv
                End With
            Next
        Next


    End Sub

    Private Sub Get_Quad_MeshCell(ByVal V As Single, ByRef Qcell() As Integer, ByVal SpaceLevel As Integer, ByVal Scell As Integer, ByRef n As Integer, ByVal max_PartitiopnLevel As Integer)
        '四分木から等値せんにかかるメッシュを抜き出す再帰処理


        If SpaceLevel = 0 Then
            ReDim Qcell(TohiSuretu_no_Wa(1, 4, max_PartitiopnLevel) - 1)
            n = 0
            With Quad_MeshData(0)
                If clsGeneric.Check_Two_Value_In(V, .Min, .Max) <> chvValue_on_twoValue.chvOuter And .LackF = False Then
                    Call Get_Quad_MeshCell(V, Qcell, SpaceLevel + 1, 0, n, max_PartitiopnLevel)
                End If
            End With
        Else
            Dim SP As Integer = TohiSuretu_no_Wa(1, 4, SpaceLevel)
            For i As Integer = 0 To 3
                With Quad_MeshData(SP + Scell + i)
                    If clsGeneric.Check_Two_Value_In(V, .Min, .Max) <> chvValue_on_twoValue.chvOuter And .LackF = False Then
                        If SpaceLevel = max_PartitiopnLevel - 1 Then
                            Qcell(n) = SP + Scell + i
                            n += 1
                        Else
                            Call Get_Quad_MeshCell(V, Qcell, SpaceLevel + 1, (Scell + i) * 4, n, max_PartitiopnLevel)
                        End If
                    End If
                End With
            Next
        End If
    End Sub
    Private Function Get_PartitiopnLevel(ByVal xs As Integer, ByVal Ys As Integer) As Integer
        '四分位の最大分割段階を決める
        Dim n As Integer
        Dim mS As Integer = Math.Min(xs, Ys)
        Dim i As Integer = 1
        Do
            n = mS \ (2 ^ i)
            i += 1
        Loop Until n < 20
        If i = 2 Then
            i = 3
        End If
        Return i - 1
    End Function


End Class
