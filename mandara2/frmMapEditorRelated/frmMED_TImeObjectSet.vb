Public Class frmMED_TimeObjectSet
    Private Enum ObjType_enum
        NewObject = 0
        Gappei = 1
        Start = 2
        Hennnyu = 3
        ChangeName = 4
        EndObj = 5
        Keisho = 6
        HennnyuChangeName = 7
        ChangeNameRev = 8
        ChangeGroup = 9
    End Enum

    Private Structure NewObject_Info '新設0
        Public Time As strYMD
        Public ObjGroup As Integer
        Public ObjnameList() As String
        Public P As PointF
    End Structure

    Private Structure StartObject_Info '開始2
        Public Time As strYMD
        Public NameStacPos As Integer
        Public ObjCode As Integer
    End Structure

    Private Structure Gappei_Info '合併1
        Public Time As strYMD
        Public OriginObjCode As List(Of Integer)
        Public DestObjNameList() As String
        Public ObjGroup As Integer
    End Structure


    Private Structure Hennnyu_Info '編入3
        Public Time As strYMD
        Public OriginObjCode As List(Of Integer)
        Public DestObjCode As Integer
    End Structure

    Private Structure HennnyuChangeName_Info '編入名称変更7
        Public Time As strYMD
        Public OriginObjCode As List(Of Integer)
        Public DestObj As String
        Public DestObjCode As Integer
        Public DestObjNameList() As String
    End Structure
    Private Structure ChangeName_Info '名称変更4
        Public Time As strYMD
        Public NameTimeStacPoint As Integer
        Public DestObjCode As Integer
        Public NewObjNameList() As String
    End Structure
    Private Structure ChangeNameRev_Info '名称変更8（新から旧）
        Public Time As strYMD
        Public NameTimeStacPoint As Integer
        Public NewObjCode As Integer
        Public oldObjNameList() As String
    End Structure

    Private Structure EndObj_Info '終了5
        Public Time As strYMD
        Public NameTimeStacPoint As Integer
        Public EndObj_Code As Integer
        Public KeishoObjCode As List(Of Integer)
    End Structure


    Private Structure Keisho_Info '継承6
        Public Time As strYMD
        Public Obj As String
        Public ObjCode As Integer
        Public KeishoObjCode As List(Of Integer)
    End Structure

    Private Structure ChangeObjGroup_Info 'オブジェクトグループ変更9
        Public Time As strYMD
        Public OriginObjCode As Integer
        Public NewObjGroup As Integer
        Public NewObjNameList() As String
    End Structure

    Dim AllData As ArrayList
    Dim AllFunction As List(Of Integer)

    Dim CloseCancelF As Boolean
    Dim MapData As clsMapData

    Dim SaveOb() As clsMapData.strObj_Data
    Private Sub frmFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Public Overloads Function ShowDialog(ByRef mpData As clsMapData) As Windows.Forms.DialogResult
        MapData = mpData
        ResetGrdid(10)
        Return Me.ShowDialog

    End Function
    Public Function GetResults()
        Dim data_n As Integer = AllFunction.Count
        For i As Integer = 0 To data_n - 1
            Select Case AllFunction(i)
                Case 0
                    '新規作成
                    Dim Data As NewObject_Info = DirectCast(AllData(i), NewObject_Info)
                    With Data
                        MapData.Add_OnePointObject(.ObjGroup, .ObjnameList, .P)
                        MapData.MPObj(MapData.Map.Kend - 1).NameTimeSTC(0).SETime.StartTime = .Time
                    End With
                Case 1
                    '合併
                    Dim Data As Gappei_Info = DirectCast(AllData(i), Gappei_Info)
                    With Data
                        Dim newObj As clsMapData.strObj_Data = MapData.Combine_TimeObjects(.OriginObjCode, .Time, 0, True, True, 0, True, .DestObjNameList, "")
                        If newObj.Kind <> -1 Then
                            MapData.Save_Object(newObj, True)
                        End If
                    End With
                Case 2
                    ' 開始オブジェクト
                    Dim Data As StartObject_Info = DirectCast(AllData(i), StartObject_Info)
                    With Data
                        MapData.MPObj(.ObjCode).NameTimeSTC(.NameStacPos).SETime.StartTime = .Time
                    End With
                Case 3
                    ' 編入オブジェクト
                    Dim Data As Hennnyu_Info = DirectCast(AllData(i), Hennnyu_Info)
                    With Data
                        .OriginObjCode.Add(.DestObjCode)
                        Dim n As Integer = .OriginObjCode.Count - 1
                        Dim newObj As clsMapData.strObj_Data = MapData.Combine_TimeObjects(.OriginObjCode, .Time, 1, True, True, n, False, Nothing, "")
                        If newObj.Kind <> -1 Then
                            MapData.Save_Object(newObj, True)
                        End If
                    End With
                Case 4
                    '継承オブジェクト
                    Dim Data As Keisho_Info = DirectCast(AllData(i), Keisho_Info)
                    With Data
                        Dim plu As Integer = .KeishoObjCode.Count
                        Dim suc As Integer = MapData.MPObj(.ObjCode).NumOfSuc
                        ReDim Preserve MapData.MPObj(.ObjCode).SucSTC(suc + plu - 1)
                        MapData.MPObj(.ObjCode).NumOfSuc += plu
                        For j As Integer = 0 To plu - 1
                            Dim obj As Integer = .KeishoObjCode(j)
                            MapData.MPObj(.ObjCode).SucSTC(suc + j).ObjectCode = obj
                            MapData.MPObj(.ObjCode).SucSTC(suc + j).Time = .Time
                        Next
                    End With
                Case 5
                    '名称変更（通常）
                    Dim Data As ChangeName_Info = DirectCast(AllData(i), ChangeName_Info)
                    With MapData.MPObj(Data.DestObjCode)
                        Dim n As Integer = .NumOfNameTime
                        ReDim Preserve .NameTimeSTC(n)
                        For j As Integer = n To Data.NameTimeStacPoint + 1 Step -1
                            .NameTimeSTC(j) = .NameTimeSTC(j - 1).Clone
                        Next
                        .NameTimeSTC(Data.NameTimeStacPoint).SETime.EndTime = clsTime.getYesterday(Data.Time)
                        With .NameTimeSTC(Data.NameTimeStacPoint + 1)
                            .SETime.StartTime = Data.Time
                            .SETime.EndTime = clsTime.GetNullYMD
                            .NamesList = Data.NewObjNameList
                        End With
                        .NumOfNameTime += 1
                    End With
                Case 6
                    '名称変更（逆）
                    Dim Data As ChangeNameRev_Info = DirectCast(AllData(i), ChangeNameRev_Info)
                    With MapData.MPObj(Data.NewObjCode)
                        Dim n As Integer = .NumOfNameTime
                        ReDim Preserve .NameTimeSTC(n)
                        For j As Integer = n To Data.NameTimeStacPoint + 1 Step -1
                            .NameTimeSTC(j) = .NameTimeSTC(j - 1).Clone
                        Next
                        .NameTimeSTC(Data.NameTimeStacPoint + 1).SETime.StartTime = Data.Time
                        With .NameTimeSTC(Data.NameTimeStacPoint)
                            .SETime.StartTime = clsTime.GetNullYMD
                            .SETime.EndTime = clsTime.getYesterday(Data.Time)
                            .NamesList = Data.oldObjNameList
                        End With
                        .NumOfNameTime += 1
                    End With
                Case 7
                    '編入名称変更
                    Dim Data As HennnyuChangeName_Info = DirectCast(AllData(i), HennnyuChangeName_Info)
                    With Data
                        .OriginObjCode.Add(.DestObjCode)
                        Dim n As Integer = .OriginObjCode.Count - 1
                        Dim newObj As clsMapData.strObj_Data = MapData.Combine_TimeObjects(.OriginObjCode, .Time, 1, True, True, n, True, .DestObjNameList, "")
                        If newObj.Kind <> -1 Then
                            MapData.Save_Object(newObj, True)
                        End If

                    End With
                Case 8
                    '終了オブジェクト
                    Dim Data As EndObj_Info = DirectCast(AllData(i), EndObj_Info)
                    With Data
                        MapData.MPObj(.EndObj_Code).NameTimeSTC(.NameTimeStacPoint).SETime.EndTime = .Time
                        If .KeishoObjCode Is Nothing = False Then
                            Dim plu As Integer = .KeishoObjCode.Count
                            Dim suc As Integer = MapData.MPObj(.EndObj_Code).NumOfSuc
                            ReDim Preserve MapData.MPObj(.EndObj_Code).SucSTC(suc + plu - 1)
                            MapData.MPObj(.EndObj_Code).NumOfSuc += plu
                            Dim TTime As strYMD = clsTime.getTomorrow(.Time)
                            For j As Integer = 0 To plu - 1
                                Dim obj As Integer = .KeishoObjCode(j)
                                MapData.MPObj(.EndObj_Code).SucSTC(suc + j).ObjectCode = obj
                                MapData.MPObj(.EndObj_Code).SucSTC(suc + j).Time = TTime
                            Next
                        End If
                    End With
                Case 9
                    'オブジェクトグループ変更
                    Dim Data As ChangeObjGroup_Info = DirectCast(AllData(i), ChangeObjGroup_Info)
                    ChangeObjGroup(Data)

            End Select
        Next
    End Function
    ''' <summary>
    ''' オブジェクトグループ変更
    ''' </summary>
    ''' <param name="Data"></param>
    ''' <remarks></remarks>
    Private Sub ChangeObjGroup(ByVal Data As ChangeObjGroup_Info)
        Dim yd As strYMD = clsTime.getYesterday(Data.Time)
        Dim Obj As clsMapData.strObj_Data = MapData.Init_One_Object(Data.NewObjGroup)
        With MapData.MPObj(Data.OriginObjCode)
            Dim suc As Integer = .NumOfSuc
            ReDim Preserve .SucSTC(suc)
            With .SucSTC(suc)
                .Time = Data.Time
                .ObjectCode = MapData.Map.Kend
            End With
            .NumOfSuc += 1
            MapData.Get_Enable_CenterP(Obj.CenterPSTC(0).Position, Data.OriginObjCode, yd)
            If MapData.ObjectKind(Obj.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                Dim agrObj() As Integer
                Dim n As Integer = MapData.Get_EnableObj_used_AggregateObject(MapData.MPObj(Data.OriginObjCode), yd, agrObj)
                Obj.NumOfLine = n
                ReDim Obj.LineCodeSTC(n - 1)
                For i As Integer = 0 To n - 1
                    Obj.LineCodeSTC(i).NumOfTime = 0
                    Obj.LineCodeSTC(i).LineCode = agrObj(i)
                Next
            Else
                Dim U_Line() As clsMapData.EnableMPLine_Data
                Dim n As Integer = MapData.Get_EnableMPLine(U_Line, Data.OriginObjCode, yd)
                Obj.NumOfLine = n
                ReDim Obj.LineCodeSTC(n - 1)
                For i As Integer = 0 To n - 1
                    Obj.LineCodeSTC(i).NumOfTime = 0
                    Obj.LineCodeSTC(i).LineCode = U_Line(i).LineCode
                Next
            End If
            .NameTimeSTC(.NumOfNameTime - 1).SETime.EndTime = yd
            Obj.NameTimeSTC(0).NamesList = Data.NewObjNameList.Clone
            Obj.NameTimeSTC(0).SETime.StartTime = Data.Time
            Obj.Shape = .Shape
            MapData.Save_Object(Obj, True)
        End With
    End Sub
    Private Sub ResetGrdid(ByVal Rows As Integer)
        With ktGrid
            .init("時間情報の一括設定", "行", "列", 1, 0, 1, 0, True, True, True, True, False, True, False, False, False, False)

            .AddLayer("", 0, 5, Rows)
            .FixedYSData(0, 0, 0) = "機能名"
            .FixedYSData(0, 1, 0) = "時期"
            .FixedYSData(0, 2, 0) = "パラメータ1"
            .FixedYSData(0, 3, 0) = "パラメータ2"
            .FixedYSData(0, 4, 0) = "パラメータ3"
            For i As Integer = 0 To 4
                .GridWidth(0, i) = Int((.Width - .FixedXSWidth(0, 0)) / 5) - 1
                .GridAlligntment(0, i) = HorizontalAlignment.Left
            Next
            .Show()
        End With
    End Sub

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        If clsGeneric.Set_ClipIdoKedo_to_KtgisGrid(ktGrid) = True Then
            checkData()
        End If

    End Sub
    Private Function checkData() As Boolean
        Dim funcStr() As String = {"新設", "合併", "開始", "編入", "継承", "名称変更", "名称変更逆", "編入名称変更", "終了", "オブジェクトグループ変更"}
        Dim n As Integer = ktGrid.Ysize(0)
        If n = 0 Then
            MsgBox("データがありません。", MsgBoxStyle.Exclamation)
            Return False
        End If

        AllData = New ArrayList
        AllFunction = New List(Of Integer)
        Dim Msg As String = ""
        For i As Integer = 0 To n - 1
            For j As Integer = 0 To ktGrid.Xsize(0) - 1
                ktGrid.GridColor(0, j, i) = ktGrid.GridColor
            Next
            Dim hd As String = (i + 1).ToString + ":"
            Dim Func As String = ktGrid.GridData(0, 0, i)
            Dim TiM As String = ktGrid.GridData(0, 1, i)
            Dim ST1 As String = ktGrid.GridData(0, 2, i)
            Dim ST2 As String = ktGrid.GridData(0, 3, i)
            Dim ST3 As String = ktGrid.GridData(0, 4, i)
            Dim time As strYMD
            Dim time_ef As Boolean = False
            If Len(TiM) < 8 Then
                Msg += hd + TiM + "時期が不正です。" + vbCrLf
                ktGrid.GridColor(0, 1, i) = Color.Yellow
                time_ef = True
            Else
                time = clsTime.GetYMD(TiM)
                If clsTime.Check_YMD_Correct(time) = False Then
                    ktGrid.GridColor(0, 1, i) = Color.Yellow
                    Msg += hd + TiM + "時期が不正です。" + vbCrLf
                    ktGrid.GridColor(0, 1, i) = Color.Yellow
                    time_ef = True
                End If
            End If
            If time_ef = False Then
                Dim funcNumber As Integer = Array.IndexOf(funcStr, Func)
                AllFunction.Add(funcNumber)
                Select Case funcNumber
                    Case -1
                        Msg += hd + Func + "の機能はありません。" + vbCrLf
                        ktGrid.GridColor(0, 0, i) = Color.Yellow
                    Case 0
                        NewObjCheck(i, time, ST1, ST2, ST3, Msg)
                    Case 1
                        GappeiObjCheck(i, time, ST1, ST2, ST3, Msg)
                    Case 2
                        StartCheck(i, time, ST1, Msg)
                    Case 3
                        HennyuObjCheck(i, time, ST1, ST2, Msg)
                    Case 4
                        KeishoCheck(i, time, ST1, ST2, Msg)
                    Case 5
                        ChangeNameCheck(i, time, ST1, ST2, Msg)
                    Case 6
                        ChangeNameRevCheck(i, time, ST1, ST2, Msg)
                    Case 7
                        HennnyuChangeNameCheck(i, time, ST1, ST2, ST3, Msg)
                    Case 8
                        EndObjCheck(i, time, ST1, ST2, Msg)
                    Case 9
                        ChangeGroupCheck(i, time, ST1, ST2, ST3, Msg)
                End Select
            End If
        Next
        ktGrid.Refresh()
        If Msg <> "" Then
            clsGeneric.Message(Me, "データに問題があります", Msg, True, False)
            Return False
        Else
            btnOK.Focus()
            Return True
        End If
    End Function
    ''' <summary>
    ''' 合併オブジェクトチェック
    ''' </summary>
    ''' <param name="Gyo"></param>
    ''' <param name="T"></param>
    ''' <param name="GappeiObjname"></param>
    ''' <param name="destName"></param>
    ''' <param name="destObjGroup"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Private Sub GappeiObjCheck(ByVal Gyo As Integer, ByVal T As strYMD, ByVal GappeiObjname As String,
                        ByVal destName As String, ByVal destObjGroup As String, ByRef Msg As String)
        '
        Dim Data As Gappei_Info
        Dim hd As String = (Gyo + 1).ToString + ":"
        Dim emes As String = ""
        If GappeiObjname = "" Then
            emes += hd + "合併オブジェクト名が指定されていません。" + vbCrLf
            ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
        Else
            Dim errObj As String = ""
            If CheckSplitObjectName(GappeiObjname, T, Data.OriginObjCode, errObj) = False Then
                emes += hd + errObj + ":合併オブジェクトが見つかりません。" + vbCrLf
                ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
            End If
        End If

        If destName = "" Then
            emes += hd + "合併後のオブジェクト名が指定されていません。" + vbCrLf
            ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
        End If

        If emes = "" Then
            If destObjGroup <> "" Then
                Data.ObjGroup = MapData.Get_ObjectGroupNumber_By_Name(destObjGroup)
                If Data.ObjGroup = -1 Then
                    emes += hd + destObjGroup + ":オブジェクトグループが見つかりません。" + vbCrLf
                    ktGrid.GridColor(0, 4, Gyo) = Color.Yellow
                End If
            Else
                Data.ObjGroup = MapData.MPObj(Data.OriginObjCode(0)).Kind
            End If
        End If

        If emes = "" Then
            With Data
                If checkObjectNameListNum(destName, MapData.MPObj(.ObjGroup).Kind, emes, hd, .DestObjNameList) = True Then
                    .Time = T
                    AllData.Add(Data)
                End If
            End With
        End If

        Msg += emes
    End Sub
    ''' <summary>
    ''' '名称変更チェック（通常）
    ''' </summary>
    ''' <param name="Gyo"></param>
    ''' <param name="T"></param>
    ''' <param name="oldname"></param>
    ''' <param name="newname"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Private Sub ChangeNameCheck(ByVal Gyo As Integer, ByVal T As strYMD, ByVal oldname As String, newname As String, ByRef Msg As String)

        Dim hd As String = (Gyo + 1).ToString + ":"
        Dim emes As String = ""
        Dim cd1 As Integer
        Dim StacP As Integer
        If oldname = "" Then
            emes += hd + "変更オブジェクト名が指定されていません。" + vbCrLf
            ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
        Else
            cd1 = MapData.Check_ObjectName_OverLap_In_MapFile(-1, oldname, clsTime.GetStartEndYMD(T, T), StacP)
            If cd1 = -1 Then
                emes += hd + oldname + "変更オブジェクト名が見つかりません。" + vbCrLf
                ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
            End If
        End If
        Dim Data As ChangeName_Info
        If newname = "" Then
            emes += hd + "新しいオブジェクト名が指定されていません。" + vbCrLf
            ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
        Else
            If emes = "" Then
                If checkObjectNameListNum(newname, MapData.MPObj(cd1).Kind, emes, hd, Data.NewObjNameList) = True Then
                    With Data
                        .NameTimeStacPoint = StacP
                        .DestObjCode = cd1
                        .Time = T
                    End With
                    AllData.Add(Data)
                End If
            End If
        End If
        Msg += emes
    End Sub
    ''' <summary>
    ''' 名称変更チェック（逆）新しい名称が決まっていて、古い名称を設定
    ''' </summary>
    ''' <param name="Gyo"></param>
    ''' <param name="T"></param>
    ''' <param name="newname"></param>
    ''' <param name="oldname"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Private Sub ChangeNameRevCheck(ByVal Gyo As Integer, ByVal T As strYMD, ByVal oldname As String, newname As String, ByRef Msg As String)
        '
        Dim hd As String = (Gyo + 1).ToString + ":"
        Dim emes As String = ""
        Dim StacP As Integer
        Dim cd1 As Integer
        If newname = "" Then
            emes += hd + "変更後オブジェクト名が指定されていません。" + vbCrLf
            ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
        Else
            cd1 = MapData.Check_ObjectName_OverLap_In_MapFile(-1, newname, clsTime.GetStartEndYMD(T, T))
            If cd1 = -1 Then
                emes += hd + newname + "変更後オブジェクト名が見つかりません。" + vbCrLf
                ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
            Else
                Dim Data As ChangeNameRev_Info
                If oldname = "" Then
                    emes += hd + "変更前オブジェクト名が指定されていません。" + vbCrLf
                    ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
                Else
                    If checkObjectNameListNum(oldname, MapData.MPObj(cd1).Kind, emes, hd, Data.oldObjNameList) = True Then
                        With Data
                            .NewObjCode = cd1
                            .Time = T
                        End With
                        AllData.Add(Data)
                    End If
                End If
            End If
        End If
        Msg += emes

    End Sub
    ''' <summary>
    ''' 終了オブジェクトチェック
    ''' </summary>
    ''' <param name="Gyo"></param>
    ''' <param name="T"></param>
    ''' <param name="EndObjname"></param>
    ''' <param name="KeishoName"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Private Sub EndObjCheck(ByVal Gyo As Integer, ByVal T As strYMD, ByVal EndObjname As String, ByVal KeishoName As String, ByRef Msg As String)
        '
        Dim hd As String = (Gyo + 1).ToString + ":"
        Dim emes As String = ""

        Dim cd2 As Integer
        Dim StacPoint As Integer
        If EndObjname = "" Then
            emes += hd + "終了オブジェクト名が指定されていません。" + vbCrLf
            ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
        Else
            cd2 = MapData.Check_ObjectName_OverLap_In_MapFile(-1, EndObjname, clsTime.GetStartEndYMD(T, T), StacPoint)
            If cd2 = -1 Then
                emes += hd + EndObjname + "終了オブジェクト名が見つかりません。" + vbCrLf
                ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
            End If
        End If
        If emes = "" Then
            Dim Data As EndObj_Info
            If KeishoName <> "" Then
                Dim Tday As strYMD = clsTime.getTomorrow(T)
                Dim errObj As String = ""
                If CheckSplitObjectName(KeishoName, Tday, Data.KeishoObjCode, errObj) = False Then
                    emes += hd + errObj + ":継承先オブジェクトが見つかりません。" + vbCrLf
                    ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
                End If
            End If
            If emes = "" Then
                Data.NameTimeStacPoint = StacPoint
                Data.EndObj_Code = cd2
                Data.Time = T
                AllData.Add(Data)
            End If
        End If
        Msg += emes
    End Sub
    ''' <summary>
    ''' 編入名称変更オブジェクトチェック
    ''' </summary>
    ''' <param name="Gyo"></param>
    ''' <param name="T"></param>
    ''' <param name="HennyuObjname"></param>
    ''' <param name="destName"></param>
    ''' <param name="newname"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Private Sub HennnyuChangeNameCheck(ByVal Gyo As Integer, ByVal T As strYMD, ByVal HennyuObjname As String, ByVal destName As String,
                                       ByVal newname As String, ByRef Msg As String)
        '
        Dim hd As String = (Gyo + 1).ToString + ":"
        Dim emes As String = ""

        If HennyuObjname = "" Then
            emes += hd + "編入元オブジェクト名が指定されていません。" + vbCrLf
            ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
        End If

        Dim cd2 As Integer = MapData.Check_ObjectName_OverLap_In_MapFile(-1, destName, clsTime.GetStartEndYMD(T, T))
        If cd2 = -1 Then
            emes += hd + HennyuObjname + "編入先オブジェクト名が見つかりません。" + vbCrLf
            ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
        End If
        If newname = "" Then
            emes += hd + "変更後のオブジェクト名が指定されていません。" + vbCrLf
            ktGrid.GridColor(0, 4, Gyo) = Color.Yellow
        End If
        If emes = "" Then
            Dim oricode As New List(Of Integer)
            Dim errObj As String = ""
            If CheckSplitObjectName(HennyuObjname, T, oricode, errObj) = False Then
                emes += hd + errObj + ":編入元オブジェクトが見つかりません。" + vbCrLf
                ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
            End If
            If emes = "" Then
                For i As Integer = 0 To oricode.Count - 2
                    If MapData.ObjectKind(MapData.MPObj(oricode(i)).Kind).ObjectType <> MapData.ObjectKind(MapData.MPObj(oricode(i + 1)).Kind).ObjectType Then
                        emes += hd + "編入元オブジェクトに通常/集成オブジェクトが混在。" + vbCrLf
                        ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
                        Exit For
                    End If
                Next
                If emes = "" Then
                    If MapData.ObjectKind(MapData.MPObj(oricode(0)).Kind).ObjectType <> MapData.ObjectKind(MapData.MPObj(cd2).Kind).ObjectType Then
                        emes += hd + "編入元オブジェクトと編入先オブジェクトのタイプが異なります。" + vbCrLf
                        ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
                        ktGrid.GridColor(0, 4, Gyo) = Color.Yellow
                    End If
                    If emes = "" Then
                        Dim Data As HennnyuChangeName_Info
                        If checkObjectNameListNum(newname, MapData.MPObj(cd2).Kind, emes, hd, Data.DestObjNameList) = True Then
                            With Data
                                .Time = T
                                .DestObj = destName
                                .DestObjCode = cd2
                                .OriginObjCode = oricode
                            End With
                            AllData.Add(Data)
                        Else
                            ktGrid.GridColor(0, 4, Gyo) = Color.Yellow
                        End If
                    End If
                End If
            End If
        End If
        Msg += emes
    End Sub

    ''' <summary>
    ''' 編入オブジェクトチェック
    ''' </summary>
    ''' <param name="Gyo"></param>
    ''' <param name="T"></param>
    ''' <param name="HennyuObjname"></param>
    ''' <param name="destName"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Private Sub HennyuObjCheck(ByVal Gyo As Integer, ByVal T As strYMD, ByVal HennyuObjname As String, ByVal destName As String, ByRef Msg As String)

        Dim hd As String = (Gyo + 1).ToString + ":"
        Dim Data As Hennnyu_Info
        Dim errObj As String = ""
        Dim emes As String = ""
        If HennyuObjname = "" Then
            emes += hd + "編入元オブジェクト名が指定されていません。" + vbCrLf
            ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
        Else
            If CheckSplitObjectName(HennyuObjname, T, Data.OriginObjCode, errObj) = False Then
                emes += hd + errObj + ":編入元オブジェクトが見つかりません。" + vbCrLf
                ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
            End If
        End If

        Dim cd2 As Integer
        If destName = "" Then
            emes += hd + "編入先オブジェクト名が指定されていません。" + vbCrLf
            ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
        Else
            cd2 = MapData.Check_ObjectName_OverLap_In_MapFile(-1, destName, clsTime.GetStartEndYMD(T, T))
            If cd2 = -1 Then
                emes += hd + HennyuObjname + "編入先オブジェクト名が見つかりません。" + vbCrLf
                ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
            End If
        End If
        If emes = "" Then
            With Data
                .DestObjCode = cd2
                .Time = T
            End With
            AllData.Add(Data)
        End If

        Msg += emes
    End Sub
    ''' <summary>
    ''' 'オブジェクトグループ変更チェック
    ''' </summary>
    ''' <param name="Gyo"></param>
    ''' <param name="T"></param>
    ''' <param name="OriginObjname"></param>
    ''' <param name="NewObjName"></param>
    ''' <param name="NewObjGroup"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Private Sub ChangeGroupCheck(ByVal Gyo As Integer, ByVal T As strYMD, ByVal OriginObjname As String, _
                            ByVal NewObjName As String, ByVal NewObjGroup As String, ByRef Msg As String)


        Dim hd As String = (Gyo + 1).ToString + ":"
        Dim emes As String = ""
        Dim cd1 As Integer
        If OriginObjname = "" Then
            emes += hd + "元オブジェクトが指定されていません。" + vbCrLf
            ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
        Else
            Dim yd As strYMD = clsTime.getYesterday(T)
            cd1 = MapData.Check_ObjectName_OverLap_In_MapFile(-1, OriginObjname, clsTime.GetStartEndYMD(yd, yd))
            If cd1 = -1 Then
                emes += hd + OriginObjname + ":オブジェクト名が見つかりません。" + vbCrLf
                ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
            End If
        End If
        If emes = "" Then
            Dim newObjGNumber As Integer
            If NewObjGroup = "" Then
                emes += hd + "新しいオブジェクトグループが指定されていません。" + vbCrLf
                ktGrid.GridColor(0, 4, Gyo) = Color.Yellow
            Else
                newObjGNumber = MapData.Get_ObjectGroupNumber_By_Name(NewObjGroup)
                If newObjGNumber = -1 Then
                    emes += hd + NewObjGroup + ":指定したオブジェクトグループが見つかりません。" + vbCrLf
                    ktGrid.GridColor(0, 4, Gyo) = Color.Yellow
                End If
            End If
            If emes = "" Then
                If NewObjName = "" Then
                    emes += hd + "新しいオブジェクト名が指定されていません。" + vbCrLf
                    ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
                Else
                    Dim Data As ChangeObjGroup_Info
                    With Data
                        If checkObjectNameListNum(NewObjName, newObjGNumber, emes, hd, .NewObjNameList) = False Then
                            ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
                        Else
                            .Time = T
                            .OriginObjCode = cd1
                            .NewObjGroup = newObjGNumber
                        End If
                    End With
                    AllData.Add(Data)
                End If
            End If
        End If
        Msg += emes

    End Sub
    ''' <summary>
    ''' 開始オブジェクトチェック
    ''' </summary>
    ''' <param name="Gyo"></param>
    ''' <param name="T"></param>
    ''' <param name="ObjName"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Private Sub StartCheck(ByVal Gyo As Integer, ByVal T As strYMD, ByVal ObjName As String, ByRef Msg As String)
        '
        Dim hd As String = (Gyo + 1).ToString + ":"
        Dim stacPos As Integer
        Dim cd As Integer = MapData.Check_ObjectName_OverLap_In_MapFile(-1, ObjName, clsTime.GetStartEndYMD(T, T), stacPos)
        If cd = -1 Then
            Dim emes As String = ""
            emes += hd + ObjName + ":オブジェクト名が見つかりません。" + vbCrLf
            ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
            Msg += emes
        Else
            Dim Data As StartObject_Info
            With Data
                .NameStacPos = stacPos
                .Time = T
                .ObjCode = cd
            End With
            AllData.Add(Data)
        End If

    End Sub
    ''' <summary>
    ''' 継承オブジェクトチェック
    ''' </summary>
    ''' <param name="Gyo"></param>
    ''' <param name="T"></param>
    ''' <param name="ObjName"></param>
    ''' <param name="KeishoName"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Private Sub KeishoCheck(ByVal Gyo As Integer, ByVal T As strYMD, ByVal ObjName As String, ByVal KeishoName As String, ByRef Msg As String)

        Dim hd As String = (Gyo + 1).ToString + ":"
        Dim emes As String = ""
        Dim YDay As strYMD = clsTime.getYesterday(T)
        Dim cd1 As Integer = MapData.Check_ObjectName_OverLap_In_MapFile(-1, ObjName, clsTime.GetStartEndYMD(YDay, YDay))
        If cd1 = -1 Then
            emes += hd + ObjName + ":オブジェクト名が見つかりません。" + vbCrLf
            ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
        End If
        If KeishoName = "" Then
            emes += hd + "継承先オブジェクトが指定されていません。" + vbCrLf
        Else
            Dim Data As Keisho_Info
            Dim errObj As String = ""
            If CheckSplitObjectName(KeishoName, T, Data.KeishoObjCode, errObj) = False Then
                emes += hd + errObj + ":継承先オブジェクトが見つかりません。" + vbCrLf
                ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
            End If
            If emes = "" Then
                With Data
                    .Time = T
                    .Obj = ObjName
                    .ObjCode = cd1
                End With
                AllData.Add(Data)
            End If
        End If
        Msg += emes

    End Sub
    ''' <summary>
    ''' '新設オブジェクトチェック
    ''' </summary>
    ''' <param name="Gyo"></param>
    ''' <param name="T"></param>
    ''' <param name="OBG"></param>
    ''' <param name="newname"></param>
    ''' <param name="XYS"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Private Sub NewObjCheck(ByVal Gyo As Integer, ByVal T As strYMD, ByVal OBG As String, ByVal newname As String, ByVal XYS As String,
                             ByRef Msg As String)

        Dim emes As String = ""
        Dim hd As String = (Gyo + 1).ToString + ":"
        Dim i As Integer = MapData.Get_ObjectGroupNumber_By_Name(OBG$)
        If i = -1 Then
            ktGrid.GridColor(0, 2, Gyo) = Color.Yellow
            emes += hd + OBG + "はオブジェクトグループに含まれません。" + vbCrLf
        End If
        Dim Data As NewObject_Info
        Dim SP() As String = Split(XYS, "|")
        If UBound(SP) = -1 Then
            emes += hd + XYS + "座標は|で区切って下さい。" + vbCrLf
            ktGrid.GridColor(0, 4, Gyo) = Color.Yellow
        Else
            With Data
                .Time = T
                .ObjGroup = i
                .P = spatial.Get_Converted_XY(New PointF(Val(SP(0)), Val(SP(1))), MapData.Map.Zahyo)
                If checkObjectNameListNum(newname, i, emes, hd, .ObjnameList) = False Then
                    ktGrid.GridColor(0, 3, Gyo) = Color.Yellow
                End If
            End With
        End If
        If emes = "" Then
            AllData.Add(Data)
        Else
            Msg += emes
        End If

    End Sub
    ''' <summary>
    ''' オブジェクト名リストがグループのリスト数に収まっているか調べる
    ''' </summary>
    ''' <param name="NameList">|で区切ったオブジェクト名リスト</param>
    ''' <param name="ObjGroup">オブジェクトグループ</param>
    ''' <param name="emes">エラーメッセージ（戻り値）</param>
    ''' <param name="emesHD">エラーメッセージのヘッダ</param>
    ''' <param name="splitNameList">分割されたオブシェクト名（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkObjectNameListNum(ByVal NameList As String, ByVal ObjGroup As Integer, ByRef emes As String, ByRef emesHD As String,
                                            ByRef splitNameList() As String) As Boolean
        Dim spn() As String = Split(NameList, "|")
        If MapData.ObjectKind(ObjGroup).ObjectNameNum < spn.Length Then
            emes += emesHD + NameList + ":オブジェクト名の数がオブジェクトグループの設定より多くなっています。" + vbCrLf
            Return False
        Else
            ReDim splitNameList(MapData.ObjectKind(ObjGroup).ObjectNameNum - 1)
            For j As Integer = 0 To spn.Length - 1
                splitNameList(j) = spn(j)
            Next
            Return True
        End If
    End Function
    ''' <summary>
    ''' オブジェクト名を|で分割して、コードをListに入れる
    ''' </summary>
    ''' <param name="ObjNames">オブジェクト名の文字列</param>
    ''' <param name="Time"></param>
    ''' <param name="ObjNameArray">オブジェクト名の配列（戻り値）</param>
    ''' <param name="ObjCode">オブジェクト番号のList（戻り値）</param>
    ''' <param name="ErrorObj">見つからなかったオブジェクト名（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckSplitObjectName(ByVal ObjNames As String, ByVal Time As strYMD, ByRef ObjCode As List(Of Integer), ByRef ErrorObj As String) As Boolean
        Dim ObjNameArray() As String = Split(ObjNames, "|")
        ObjCode = New List(Of Integer)
        For i As Integer = 0 To ObjNameArray.Length - 1
            Dim cd1 As Integer = MapData.Check_ObjectName_OverLap_In_MapFile(-1, ObjNameArray(i), clsTime.GetStartEndYMD(Time, Time))
            If cd1 = -1 Then
                ErrorObj = ObjNameArray(i)
                Return False
            Else
                ObjCode.Add(cd1)
            End If
        Next
        Return True
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If checkData() = False Then
            CloseCancelF = True
        End If
    End Sub

    Private Sub btmCheck_Click(sender As Object, e As EventArgs) Handles btmCheck.Click
        If checkData() = True Then
            MsgBox("設定可能です。")
        End If
    End Sub

    Private Sub frmMED_TimeObjectSet_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_TimeObjectSet", Me)

    End Sub

End Class