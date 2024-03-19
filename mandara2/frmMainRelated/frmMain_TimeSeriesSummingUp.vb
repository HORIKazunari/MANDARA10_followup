Public Class frmMain_TimeSeriesSummingUp
    Private Structure newDataInfo
        Public oldLay As Integer
        Public oldDataNum As Integer
    End Structure
    Dim CloseCancelF As Boolean
    Dim attr As clsAttrData
    Dim MapData As clsMapData

    Private Structure EnableLayerData_Info
        Public Title As String
        Public MapFileName As String
        Public LayerNumber As Integer
        Public Overrides Function ToString() As String
            Return Title
        End Function
    End Structure

    Private Structure EnableData_Info
        Public Title As String
        Public DataNumber As Integer
        Public Checked As Boolean
        Public Overrides Function ToString() As String
            Return Title
        End Function
    End Structure

    Private Structure DataItem_Conv_Info
        Public oldDataNum As Integer
        Public newDataNum As Integer
    End Structure
    Dim Selected_Data As New List(Of List(Of DataItem_Conv_Info))

    Private cbData() As CheckedListBox
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
    Public Overloads Function ShowDialog(ByRef _attr As clsAttrData) As Windows.Forms.DialogResult
        attr = _attr
        clbLayer.Items.Clear()
        Dim layn As New List(Of Integer)
        For i As Integer = 0 To attr.TotalData.LV1.Lay_Maxn - 1
            Dim d As EnableLayerData_Info
            If attr.LayerData(i).Time.nullFlag = False And attr.LayerData(i).atrObject.NumOfSyntheticObj = 0 And attr.LayerData(i).Type = clsAttrData.enmLayerType.Normal Then
                d.LayerNumber = i
                d.MapFileName = attr.LayerData(i).MapFileName
                d.Title = attr.LayerData(i).Name + "【" + d.MapFileName + "/" + clsTime.YMDtoString(attr.LayerData(i).Time) + "】"
                clbLayer.Items.Add(d)
                layn.Add(i)
            End If
        Next
        Me.cbData = New CheckedListBox(layn.Count - 1) {}
        For i As Integer = 0 To layn.Count - 1
            Dim Dtitle() As String = attr.getDataTitleName(layn(i), True, True, False, False)
            Me.cbData(i) = New CheckedListBox
            With Me.cbData(i)
                .Location = New Point(28, 162)
                .Size = New Size(304, 186)
                .Tag = i
                .CheckOnClick = True
            End With
            For j As Integer = 0 To Dtitle.Length - 1
                If Microsoft.VisualBasic.Left(Dtitle(j), 1) = "*" Then
                Else
                    Dim dt As EnableData_Info
                    dt.Title = Dtitle(j)
                    dt.DataNumber = j
                    Me.cbData(i).Items.Add(dt)
                End If
            Next
        Next
        Me.Controls.AddRange(Me.cbData)
        clbLayer.SelectedIndex = 0
        txtNewLayerName.Text = attr.Get_NewLayer_Name("時系列集計レイヤ")
        Return Me.ShowDialog

    End Function
    Public Function GetResults()

    End Function

    Private Sub clbLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbLayer.SelectedIndexChanged
        Dim L As Integer = clbLayer.SelectedIndex
        lblData.Text = "【" + attr.LayerData(L).Name + "】" + "取得するデータ項目"
        For i As Integer = 0 To clbLayer.Items.Count - 1
            Me.cbData(i).Visible = (i = L)
        Next
    End Sub

    ''' <summary>
    ''' オブジェクトの最大公約数計算
    ''' </summary>
    ''' <param name="ln"></param>
    ''' <param name="Synthetic_Object">地図ファイル中の全オブジェクトで、対象期間中にひとまとまりになる場合は、その番号を(０から）そうでない場合（期間内で編入などが無い場合）は-1を返す</param>
    ''' <param name="ST"></param>
    ''' <param name="et"></param>
    ''' <param name="Cul_Layer"></param>
    ''' <param name="MPSyntheticObj">作成した合成オブジェクト</param>
    ''' <param name="Er_Message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_Synthetic_Object(ByVal ln As Integer, ByRef Synthetic_Object() As Integer, ByVal ST As strYMD, ByVal et As strYMD,
                                          ByRef Cul_Layer() As Integer, ByRef MPSyntheticObj() As clsAttrData.strSynthetic_Object_Data,
                                          ByRef Er_Message As String) As Integer
        '

        Er_Message = ""
        ReDim Synthetic_Object(MapData.Map.Kend - 1)

        For i As Integer = 0 To MapData.Map.Kend - 1
            Synthetic_Object(i) = -2
        Next


        Dim Synthetic_N As Integer = 0
        For i As Integer = 0 To ln - 1
            Dim L As Integer = Cul_Layer(i)
            For j As Integer = 0 To attr.LayerData(L).atrObject.ObjectNum - 1
                With attr.LayerData(L).atrObject.atrObjectData(j)
                    If Synthetic_Object(.MpObjCode) = -2 Then
                        Dim ob() As Integer
                        Dim n As Integer = Get_Related_Time_Object(.MpObjCode, ST, et, ob)
                        If n = 1 And .MpObjCode = ob(0) Then
                            '変化無しの場合
                            Synthetic_Object(ob(0)) = -1
                        Else
                            '変化がある場合は関係オブジェクトにSynthetic_Nを通し番号で付ける
                            For jj As Integer = 0 To n - 1
                                Synthetic_Object(ob(jj)) = Synthetic_N
                            Next
                            Synthetic_N += 1
                        End If
                    End If
                End With
            Next
        Next


        ReDim MPSyntheticObj(Synthetic_N - 1)
        Dim k As Integer = 0
        Do While k < Synthetic_N
            With MPSyntheticObj(k)
                .NumOfObject = 0
                .SETime.StartTime = ST
                .SETime.EndTime = et
                For i As Integer = 0 To ln - 1 'レイヤの数だけループ
                    Dim L As Integer = Cul_Layer(i)
                    For j As Integer = 0 To attr.LayerData(L).atrObject.ObjectNum - 1   'レイヤのオブジェクト数だけループ
                        Dim Kcd As Integer = attr.Get_KenObjCode(L, j)
                        If Synthetic_Object(Kcd) = k Then
                            'レイヤのオブジェクトが継承に関係ある場合
                            Dim f As Boolean = True
                            Dim etso As Integer = -1
                            For i2 As Integer = 0 To .NumOfObject - 1
                                If .Objects(i2).code = Kcd Then
                                    '既に継承オブジェクトに入っている場合
                                    etso = i2
                                    f = False
                                    Exit For
                                End If
                            Next
                            If f = True Then
                                '継承オブジェクトに追加
                                ReDim Preserve .Objects(.NumOfObject)
                                With .Objects(.NumOfObject)
                                    .code = Kcd
                                    .Name = attr.Get_KenObjName(L, j)
                                    .Draw_F = False
                                End With
                                etso = .NumOfObject
                                .NumOfObject += 1
                            End If
                            If attr.LayerData(L).Time.Equals(et) = True Then
                                With .Objects(etso)
                                    .Draw_F = True
                                    Dim retOname() As String
                                    MapData.Get_Enable_ObjectName(.code, et, False, retOname)
                                    .Name = retOname(0)
                                End With
                            End If
                        End If
                    Next
                Next
                Dim Pos As PointF = New PointF(0, 0)
                Dim n As Integer = 0
                For i As Integer = 0 To .NumOfObject - 1
                    Dim possub As PointF
                    Dim f As Boolean = MapData.Get_Enable_CenterP(possub, .Objects(i).code, et)
                    If f = True Then
                        '最後の時点で残っている場合
                        Pos.X += possub.X
                        Pos.Y += possub.Y
                        n += 1
                    End If
                Next
                If n = 0 Then
                    '最終時点でオブジェクトが無い場合は継承オブジェクトから排除
                    For i As Integer = 0 To .NumOfObject - 1
                        Er_Message += .Objects(i).Name
                        If i = .NumOfObject - 1 Then
                            Er_Message += vbCrLf
                        Else
                            Er_Message += "/"
                        End If
                    Next
                    For i As Integer = 0 To MapData.Map.Kend - 1
                        If Synthetic_Object(i) = k Then
                            Synthetic_Object(i) = -3
                        ElseIf Synthetic_Object(i) > k Then
                            Synthetic_Object(i) -= 1
                        End If
                    Next
                    Synthetic_N -= 1
                Else
                    '正式に継承オブジェクトにする

                    .CenterP.X = Pos.X / n
                    .CenterP.Y = Pos.Y / n
                    Dim j As Integer = .Objects(0).code
                    .Circumscribed_Rectangle = MapData.MPObj(j).Circumscribed_Rectangle
                    .Kind = MapData.MPObj(j).Kind
                    .Shape = MapData.MPObj(j).Shape
                    .Name = "合成/" & .Objects(0).Name
                    For i As Integer = 1 To .NumOfObject - 1
                        Dim jj As Integer = .Objects(i).code
                        .Name += "/" + .Objects(i).Name
                        .Circumscribed_Rectangle = spatial.Get_Circumscribed_Rectangle(MapData.MPObj(jj).Circumscribed_Rectangle, .Circumscribed_Rectangle)
                    Next
                    k += 1
                End If
            End With
        Loop
        Return k
    End Function

    Private Function Get_Related_Time_Object(ByVal Base_Object As Integer, ByVal Start_Time As strYMD, _
            ByVal End_Time As strYMD, ByRef RelatedObject() As Integer) As Integer

        Dim f As Boolean

        Dim Search_Object(20) As Integer

        Search_Object(0) = Base_Object
        Dim Search_Num As Integer = 1
        Dim n As Integer = 0
        Do
            With MapData.MPObj(Search_Object(n))
                For i As Integer = 0 To .NumOfSuc - 1
                    With .SucSTC(i)
                        If clsTime.YMDtoValue(.Time) >= clsTime.YMDtoValue(Start_Time) And clsTime.YMDtoValue(.Time) <= clsTime.YMDtoValue(End_Time) Then
                            f = Get_Related_Time_Object_Check(.ObjectCode, Search_Object, Search_Num)
                        End If
                    End With
                Next

                Dim H_Data() As clsMapData.Hennyu_Data
                Dim hn As Integer = MapData.Get_Hennyu_Object(MapData.MPObj(Search_Object(n)), H_Data)
                For i As Integer = 0 To hn - 1
                    With H_Data(i)
                        If clsTime.YMDtoValue(.Time) >= clsTime.YMDtoValue(Start_Time) And clsTime.YMDtoValue(.Time) <= clsTime.YMDtoValue(End_Time) Then
                            f = Get_Related_Time_Object_Check(.code, Search_Object, Search_Num)
                        End If
                    End With
                Next
            End With
            n += 1
        Loop While n < Search_Num
        RelatedObject = Search_Object
        Return n
    End Function
    Private Function Get_Related_Time_Object_Check(s_Code As Integer, ByRef Search_Object() As Integer, ByRef Search_Num As Integer) As Integer

        Dim f As Boolean = True
        For i As Integer = 0 To Search_Num - 1
            If Search_Object(i) = s_Code Then
                f = False
                Exit For
            End If
        Next
        If f = True Then
            If UBound(Search_Object) < Search_Num Then
                ReDim Preserve Search_Object(Search_Num + 20)
            End If
            Search_Object(Search_Num) = s_Code
            Search_Num += 1
        End If

        Return f
    End Function


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click




        Dim Cul_Layer() As Integer
        Dim ln As Integer
        Dim ST As strYMD
        Dim et As strYMD
        Dim New_Lay_DatN As Integer
        Dim f As Boolean = Check_OK(ln, ST, et, New_Lay_DatN, Cul_Layer)
        If f = False Then
            CloseCancelF = True
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim B_Lay As Integer
        For i As Integer = 0 To ln - 1
            Dim L As Integer = Cul_Layer(i)
            If et.Equals(attr.LayerData(L).Time) = True Then
                B_Lay = L
                Exit For
            End If
        Next

        'オブジェクトの最大公約数計算
        'Synthetic_Object()／地図ファイル中の全オブジェクトで、対象期間中にひとまとまりになる場合は、その番号を(０から）
        '                 そうでない場合（期間内で編入などが無い場合）は-1を返す
        'Synthetic_N/期間内で計算され、形成された合成オブジェクトの数
        Dim MPSyntheticObj() As clsAttrData.strSynthetic_Object_Data
        Dim Synthetic_Object() As Integer
        Dim Er_Message As String
        Dim Synthetic_N As Integer = Get_Synthetic_Object(ln, Synthetic_Object, ST, et, Cul_Layer, MPSyntheticObj, Er_Message)

        '新しいレイヤの設定準備
        Dim NewLay As Integer = attr.TotalData.LV1.Lay_Maxn

        '新しいレイヤの設定

        Dim mxObj As Integer = 0
        For i As Integer = 0 To ln - 1
            Dim L As Integer = Cul_Layer(i)
            mxObj = Math.Max(mxObj, attr.Get_ObjectNum(L))
        Next

        'オブジェクトの数を数える
        Dim SubKencode(mxObj) As clsAttrData.strObject_Data_Info
        Dim New_Lay_Object_N As Integer = 0
        Dim Fcheck(New_Lay_DatN, mxObj) As Boolean
        Dim MisA(New_Lay_DatN, mxObj) As Boolean
        Dim Data_V(New_Lay_DatN - 1, mxObj) As Double
        Dim Data_OB(mxObj) As String

        For i As Integer = 0 To ln - 1
            Dim L As Integer = Cul_Layer(i)
            For j As Integer = 0 To attr.Get_ObjectNum(L) - 1
                Dim O_Code As Integer = attr.Get_KenObjCode(L, j)
                Dim ObjType As enmKenCodeObjectstructure
                If Synthetic_Object(O_Code) <> -3 Then
                    ObjType = enmKenCodeObjectstructure.MapObj
                    If Synthetic_Object(O_Code) <> -1 Then
                        O_Code = Synthetic_Object(O_Code)
                        ObjType = enmKenCodeObjectstructure.SyntheticObj
                    End If
                    Dim O_Number As Integer = -1
                    For k As Integer = 0 To New_Lay_Object_N - 1
                        If SubKencode(k).MpObjCode = O_Code Then
                            If SubKencode(k).Objectstructure = ObjType Then
                                '既に同じオブジェクトが新規レイヤに登録してある場合はその位置を取得
                                O_Number = k
                                Exit For
                            End If
                        End If
                    Next
                    If O_Number = -1 Then
                        '新規レイヤのオブジェクトを増やす
                        O_Number = New_Lay_Object_N
                        With SubKencode(O_Number)
                            .MpObjCode = O_Code
                            .Objectstructure = ObjType
                            '最初のデータ項目にオブジェクトの種類を入れる（通常か合成か）
                            Select Case ObjType
                                Case enmKenCodeObjectstructure.MapObj
                                    .Name = attr.Get_KenObjName(L, j)
                                    Data_OB(O_Number) = "通常のオブジェクト"
                                    '最終時点の代表点を取得
                                    MapData.Get_Enable_CenterP(.CenterPoint.X, .CenterPoint.Y, MapData.MPObj(O_Code), attr.LayerData(B_Lay).Time)
                                Case enmKenCodeObjectstructure.SyntheticObj
                                    .Name = MPSyntheticObj(O_Code).Name
                                    Data_OB(O_Number) = "合成オブジェクト"
                                    .CenterPoint = MPSyntheticObj(O_Code).CenterP
                            End Select
                            .Symbol = .CenterPoint
                            .Label = .CenterPoint
                        End With
                        'とりあえず、２つめ以降のデータ項目のデータに欠損値と０を入れる
                        For k As Integer = 0 To New_Lay_DatN - 1
                            Data_V(k, O_Number) = 0
                            MisA(k, O_Number) = True
                        Next
                        New_Lay_Object_N += 1
                    End If
                    If L = B_Lay And ObjType = enmKenCodeObjectstructure.MapObj Then
                        SubKencode(O_Number).Name = attr.Get_KenObjName(L, j)
                    End If
                    '集計するデータ項目の処理
                    Dim GetD As List(Of DataItem_Conv_Info) = Selected_Data(i)
                    For k As Integer = 0 To GetD.Count - 1
                        Dim newd As Integer = GetD(k).newDataNum
                        Dim oldn As Integer = GetD(k).oldDataNum
                        Fcheck(newd, j) = True
                        If attr.Check_Missing_Value(L, oldn, j) = True Then
                        Else
                            MisA(newd, O_Number) = False
                            Select Case ObjType
                                Case enmKenCodeObjectstructure.MapObj
                                    Data_V(newd, O_Number) = Val(attr.Get_Data_Value(L, oldn, j, ""))
                                Case enmKenCodeObjectstructure.SyntheticObj
                                    Data_V(newd, O_Number) += Val(attr.Get_Data_Value(L, oldn, j, ""))
                            End Select
                        End If
                    Next
                End If
            Next
        Next

        attr.Add_one_Layer(txtNewLayerName.Text, clsAttrData.enmLayerType.Normal, enmMesh_Number.mhNonMesh,
                    attr.LayerData(B_Lay).Shape, attr.LayerData(B_Lay).MapFileName, attr.LayerData(B_Lay).Time, enmZahyo_System_Info.Zahyo_System_No, "時系列集計によるレイヤ",
                     New_Lay_Object_N, SubKencode)

        'データ項目登録
        attr.Add_One_Data_Value(NewLay, "オブジェクトの分類", "CAT", "", Data_OB, False)

        '集計するデータ項目のタイトル設定

        Dim newDataItem(New_Lay_DatN - 1) As newDataInfo
        For i As Integer = 0 To ln - 1
            Dim L As Integer = Cul_Layer(i)
            Dim GetD As List(Of DataItem_Conv_Info) = Selected_Data(i)
            For j As Integer = 0 To GetD.Count - 1
                Dim newd As Integer = GetD(j).newDataNum
                newDataItem(newd).oldLay = L
                newDataItem(newd).oldDataNum = GetD(j).oldDataNum
            Next
        Next
        For i As Integer = 0 To New_Lay_DatN - 1
            Dim Data_Val_STR(New_Lay_Object_N - 1) As String
            For j As Integer = 0 To New_Lay_Object_N - 1
                If MisA(i, j) = True Or Fcheck(i, j) = False Then
                    Data_Val_STR(j) = ""
                Else
                    Data_Val_STR(j) = CStr(Data_V(i, j))
                End If
            Next

            With newDataItem(i)
                Dim TTL As String = attr.Get_DataTitle(.oldLay, .oldDataNum, False) & "【" & attr.LayerData(.oldLay).Name & "】"
                Dim UNT As String = attr.Get_DataUnit(.oldLay, .oldDataNum)
                Dim destD = attr.LayerData(NewLay).atrData.Count - 1
                attr.Add_One_Data_Value(NewLay, TTL, UNT, "", Data_Val_STR, True)
                attr.Set_Legend(NewLay, destD, attr.LayerData(.oldLay).atrData.Data(.oldDataNum), True, True, True, True, True, True, True, True, True, True, True, False, True)
                attr.LayerData(NewLay).atrData.Data(destD).SoloModeViewSettings.MarkCommon.Inner_Data.Data = destD
            End With
        Next


        '新しいレイヤの設定準備

        With attr.LayerData(NewLay)
            .atrObject.MPSyntheticObj = MPSyntheticObj
            .atrObject.NumOfSyntheticObj = Synthetic_N
            .Dummy.Count = attr.LayerData(B_Lay).Dummy.Count
            If .Dummy.Count > 0 Then
                .Dummy.DummyObj = attr.LayerData(B_Lay).Dummy.DummyObj.Clone
            End If
            .DummyGroup.Count = attr.LayerData(B_Lay).DummyGroup.Count
            If .DummyGroup.Count > 0 Then
                .DummyGroup.DummyObjG = attr.LayerData(B_Lay).DummyGroup.DummyObjG.Clone
            End If
        End With

        attr.LinePatternCheck()
        attr.PrtObjectSpatialIndex()

        Me.Cursor = Cursors.Default

        MsgBox("集計が終了しました。" & vbCrLf & "結果は" & attr.LayerData(NewLay).Name & "に入っています。")

        If Er_Message <> "" Then
            clsGeneric.Message(Me, "問題がありました", "以下のオブジェクトは最終時点までつながっていません。" & vbCrLf & Er_Message, True, True)
        End If

        If Synthetic_N = 0 Then
            MsgBox("合成オブジェクトは作成されませんでした。")
        End If
    End Sub
    Private Function Check_OK(ByRef ln As Integer, ByRef ST As strYMD, ByRef et As strYMD,
                              ByRef DataN As Integer, ByRef Cul_Layer() As Integer) As Boolean

        If clbLayer.CheckedItems.Count < 2 Then
            MsgBox("レイヤは二つ以上選択してください。", MsgBoxStyle.Exclamation)
            Return False
        End If
        DataN = 0
        Dim CulLay As New List(Of Integer)
        Dim endt As Integer = -1
        Dim startt As Integer = clsTime.YMDtoValue(clsTime.GetYMD(9999, 1, 1))
        Dim mapfilename As String
        For i As Integer = 0 To clbLayer.CheckedIndices.Count - 1
            Dim sel As Integer = clbLayer.CheckedIndices(i)
            Dim d As EnableLayerData_Info = CType(clbLayer.Items(sel), EnableLayerData_Info)
            CulLay.Add(d.LayerNumber)
            If i = 0 Then
                mapfilename = attr.LayerData(d.LayerNumber).MapFileName
                MapData = attr.LayerData(d.LayerNumber).MapFileData
            Else
                If mapfilename <> attr.LayerData(d.LayerNumber).MapFileName Then
                    MsgBox("選択したレイヤの使用する地図ファイルが異なります。", MsgBoxStyle.Exclamation)
                    Return False
                End If
            End If
            startt = Math.Min(clsTime.YMDtoValue(attr.LayerData(d.LayerNumber).Time), startt)
            endt = Math.Max(clsTime.YMDtoValue(attr.LayerData(d.LayerNumber).Time), endt)
            Dim GetData As New List(Of DataItem_Conv_Info)
            For j As Integer = 0 To cbData(sel).CheckedIndices.Count - 1
                Dim dt As DataItem_Conv_Info
                Dim dto As EnableData_Info = DirectCast(cbData(sel).CheckedItems(j), EnableData_Info)
                dt.oldDataNum = dto.DataNumber
                dt.newDataNum = DataN
                GetData.Add(dt)
                DataN += 1
            Next
            Selected_Data.Add(GetData)
        Next
        ST = clsTime.GetYMDfromValue(startt)
        et = clsTime.GetYMDfromValue(endt)

        If DataN = 0 Then
            MsgBox("集計するデータ項目を指定して下さい。", MsgBoxStyle.Exclamation)
            Return False
        End If

        Cul_Layer = CulLay.ToArray
        ln = CulLay.Count
        Return True
    End Function

    Private Sub frmMain_TimeSeriesSummingUp_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_TimeSeriesSummingUp", Me)
    End Sub
End Class