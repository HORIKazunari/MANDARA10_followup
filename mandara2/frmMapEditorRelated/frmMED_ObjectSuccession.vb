Public Class frmMED_ObjectSuccession
    Dim Obj As clsMapData.strObj_Data
    Dim mpData As clsMapData

    Dim RefObject As New ArrayList
    Dim CloseCancelF As Boolean

    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal mpObj As clsMapData.strObj_Data, ByRef MapData As clsMapData) As Windows.Forms.DialogResult
        Obj = mpObj.Clone
        mpData = MapData

        Dim TimeRef As New clsSortingSearch(VariantType.Integer)

        Dim n As Integer = 0
        For i As Integer = 0 To Obj.NumOfNameTime - 1
            Dim T2 As strYMD = clsTime.getTomorrow(Obj.NameTimeSTC(i).SETime.EndTime)
            If T2.nullFlag = False Then
                If i <> Obj.NumOfNameTime - 1 Then
                    If T2.Equals(Obj.NameTimeSTC(i + 1).SETime.StartTime) Then
                        TimeRef.Add(clsTime.YMDtoValue(T2))
                    End If
                Else
                    TimeRef.Add(clsTime.YMDtoValue(T2))
                End If
            End If
        Next

        If mpData.ObjectKind(Obj.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
            For j As Integer = 0 To Obj.NumOfLine - 1
                With Obj.LineCodeSTC(j)
                    For i As Integer = 0 To .NumOfTime - 1
                        Dim T2 As strYMD = clsTime.getTomorrow(.Times(i).EndTime)
                        If T2.nullFlag = False Then
                            TimeRef.Add(clsTime.YMDtoValue(T2))
                        End If
                    Next
                End With
            Next
        End If
        TimeRef.AddEnd()

        lbTimeRef.Items.Clear()
        For i As Integer = 0 To TimeRef.NumofData - 1
            Dim a As strYMD=clsTime.GetYMDfromValue(TimeRef.DataPositionValue_Integer(i))
            lbTimeRef.Items.Add(clsTime.YMDtoString(a))
        Next

        With Obj
            If .NumOfSuc = 0 Then
                .NumOfSuc = 1
                ReDim Preserve .SucSTC(0)
                .SucSTC(0).Time = clsTime.GetNullYMD
                .SucSTC(0).ObjectCode = -1
            End If
        End With

        sort_Time()
        lbList.SelectedIndex = lbList.Items.Count - 1
        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResult() As clsMapData.strObj_Data
        Return Obj
    End Function
    Private Sub sort_Time()

        Dim So As New clsSortingSearch(VariantType.Integer)
        Dim P3() As clsMapData.Object_Succession_Data

        Dim n As Integer = Obj.NumOfSuc

        For i As Integer = 0 To n - 1
            So.Add(clsTime.YMDtoValue(Obj.SucSTC(i).Time))
        Next
        So.AddEnd()

        ReDim P3(n)
        For i = 0 To n - 1
            P3(i) = Obj.SucSTC(So.DataPosition(i))
        Next
        Me.Tag = "off"
        lbList.Items.Clear()
        For i As Integer = 0 To n - 1
            Obj.SucSTC(i) = P3(i)
            lbList.Items.Add(clsGeneric.getTimeList(Obj.SucSTC(i), mpData))
        Next
        Me.Tag = "on"
    End Sub

    Private Sub lbList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbList.SelectedIndexChanged
        Dim Name12 As String = ""
        Dim L As Integer = lbList.SelectedIndex
        If Me.Tag = "on" And L <> -1 Then
            With Obj.SucSTC(L)
                If .ObjectCode <> -1 Then
                    mpData.Get_Enable_ObjectName(mpData.MPObj(.ObjectCode), .Time, False, Name12)
                Else
                    Name12 = "未設定"
                End If
                lblObjName.Text = Name12
                ddtpTime.Value = .Time
            End With
            Set_Ob_Ref()
        End If
    End Sub

    Private Sub btnSetRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetRef.Click
        Dim L As Integer = lbTimeRef.SelectedIndex
        If L = -1 Then
            If lbTimeRef.Items.Count = 1 Then
                L = 0
            Else
                Dim msgText = "時期参照のリストを選択してください。"
                MsgBox(msgText, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        Dim T As strYMD = clsTime.GetYMD(lbTimeRef.Items(L))

        Dim L2 As Integer = lbList.SelectedIndex
        If L2 = -1 And Obj.NumOfSuc <> 0 Then
        Else
            If Obj.NumOfSuc = 0 Then
                btnAdd.PerformClick()
                L2 = 0
            End If
            Obj.SucSTC(L2).Time = T
            Me.Tag = "off"
            lbList.Items(L2) = clsGeneric.getTimeList(Obj.SucSTC(L2), mpData)
            Me.Tag = "on"
            ddtpTime.Value = Obj.SucSTC(L2).Time
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        With Obj
            Dim n As Integer = .NumOfSuc + 1
            Obj.NumOfSuc = n
            ReDim Preserve .SucSTC(n - 1)
            With .SucSTC(n - 1)
                .Time = clsTime.GetNullYMD
                .ObjectCode = -1
            End With
            lbList.Items.Add(clsGeneric.getTimeList(.SucSTC(n - 1), mpData))
            lbList.SelectedIndex = n - 1
        End With
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim L As Integer = lbList.SelectedIndex
        If L = -1 Then Exit Sub
        With Obj
            Dim n As Integer = .NumOfSuc - 1
            If n > 0 Then
                .NumOfSuc = n
                For i = L + 1 To n
                    .SucSTC(i - 1) = .SucSTC(i)
                Next
                ReDim Preserve .SucSTC(n - 1)
                lbList.Items.RemoveAt(L)
                lbList.SelectedIndex = L - 1
            Else
                ReDim Preserve .SucSTC(0)
                .SucSTC(0).Time = clsTime.GetNullYMD
                .SucSTC(0).ObjectCode = -1
                Me.Tag = "off"
                lbList.SelectedIndex = -1
                Me.Tag = "on"
                lbList.SelectedIndex = 0
                lbList.Items(0) = clsGeneric.getTimeList(Obj.SucSTC(0), mpData)
            End If
        End With
    End Sub

    Private Sub ddtpTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddtpTime.ValueChanged

        If Me.Tag = "on" Then
            Dim L As Integer = lbList.SelectedIndex
            Obj.SucSTC(L).Time = ddtpTime.Value
            Me.Tag = "off"
            lbList.Items(L) = clsGeneric.getTimeList(Obj.SucSTC(L), mpData)
            Me.Tag = "on"
            Set_Ob_Ref()
        End If
    End Sub



    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        sort_Time()

        If Obj.NumOfSuc = 1 And Obj.SucSTC(0).Time.nullFlag = True And Obj.SucSTC(0).ObjectCode = -1 Then
            Dim msgText = "継承設定は行われません。よろしいですか?"
            If MsgBox(msgText, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                CloseCancelF = True
                Exit Sub
            Else
                Obj.NumOfSuc = 0
                Erase Obj.SucSTC
            End If
            Exit Sub
        End If
        For i As Integer = 0 To Obj.NumOfSuc - 1
            If Obj.SucSTC(i).Time.nullFlag = True Then
                lbList.SelectedIndex = i
                Dim msgText = "時期が設定していない箇所があります。"
                MsgBox(msgText, MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Exit Sub
            End If
            If Obj.SucSTC(i).ObjectCode = -1 Then
                lbList.SelectedIndex = i
                Dim msgText = "オブジェクトが設定されていない箇所があります。"
                MsgBox(msgText, MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Exit Sub
            End If
            Dim inTimeF As Boolean = False
            For j As Integer = 0 To Obj.NumOfNameTime - 1
                Dim objNameTime As Start_End_Time_data = Obj.NameTimeSTC(j).SETime
                objNameTime.EndTime = clsTime.getTomorrow(objNameTime.EndTime)
                If clsTime.checkDurationIn(objNameTime, Obj.SucSTC(i).Time) = True Then
                    inTimeF = True
                End If
            Next
            If inTimeF = False Then
                lbList.SelectedIndex = i
                Dim msgText = "時期設定がオブジェクト名の存在期間から外れています。"
                MsgBox(msgText, MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Exit Sub
            End If
        Next

    End Sub

    Private Sub Set_Ob_Ref()


        Dim L As Integer = lbList.SelectedIndex
        If L = -1 Then Exit Sub

        Dim cx As Single, cy As Single
        Dim n12 As String = ""

        lbObjRef.Items.Clear()
        RefObject.Clear()


        Dim TM As strYMD = Obj.SucSTC(L).Time
        If TM.nullFlag = True Then
            Exit Sub
        End If

        '継承日に設定中のオブジェクトを内部に含むオブジェクトを検索
        'オブジェクトの合併・編入の場合
        For i As Integer = 0 To mpData.Map.Kend - 1
            If i <> Obj.Number And Obj.Kind = mpData.MPObj(i).Kind And _
                    mpData.Check_Point_in_OneObject(mpData.MPObj(i), cx, cy, TM) = True And _
                    mpData.Get_Enable_ObjectName(mpData.MPObj(i), TM, False, n12) = True Then
                lbObjRef.Items.Add(n12)
                RefObject.Add(i)
            End If
        Next

        '継承日に設定中のオブジェクトの内部に存在するオブジェクトを検索
        'オブジェクトの分離の場合
        Dim TM2 As strYMD = clsTime.getYesterday(TM)
        For i As Integer = 0 To mpData.Map.Kend - 1
            If i <> Obj.Number And Obj.Kind = mpData.MPObj(i).Kind Then
                If mpData.Get_Enable_CenterP(cx, cy, mpData.MPObj(i), TM) = True And _
                        RefObject.Contains(i) = False And _
                        mpData.Check_Point_in_OneObject(Obj, cx, cy, TM2) = True Then
                    mpData.Get_Enable_ObjectName(mpData.MPObj(i), TM, False, n12)
                    lbObjRef.Items.Add(n12)
                    RefObject.Add(i)
                End If
            End If
        Next

        '編集中のオブジェクトが使用しているラインを共有するオブジェクトの抽出
        If mpData.ObjectKind(Obj.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
            '通常のオブジェクト
            Dim ELCODE() As clsMapData.EnableMPLine_Data
            Dim ML As Integer = mpData.Get_EnableMPLine(ELCODE, Obj, TM2)
            For i As Integer = 0 To mpData.Map.Kend - 1
                If mpData.ObjectKind(mpData.MPObj(i).Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject And _
                        i <> Obj.Number And _
                        RefObject.Contains(i) = False Then
                    For j As Integer = 0 To mpData.MPObj(i).NumOfLine - 1
                        With mpData.MPObj(i).LineCodeSTC(j)
                            For k As Integer = 0 To ML - 1
                                If .LineCode = ELCODE(k).LineCode Then
                                    If mpData.Get_Enable_ObjectName(mpData.MPObj(i), TM, False, n12) = True Then
                                        lbObjRef.Items.Add(n12)
                                        RefObject.Add(i)
                                        j = mpData.MPObj(i).NumOfLine
                                        Exit For
                                    End If
                                End If
                            Next
                        End With
                    Next
                End If
            Next
        Else
            '集成オブジェクト
            For i As Integer = 0 To mpData.Map.Kend - 1
                If mpData.ObjectKind(mpData.MPObj(i).Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject And _
                        i <> Obj.Number And _
                        RefObject.Contains(i) = False Then
                    For j As Integer = 0 To mpData.MPObj(i).NumOfLine - 1
                        With mpData.MPObj(i).LineCodeSTC(j)
                            For k As Integer = 0 To Obj.NumOfLine - 1
                                If .LineCode = Obj.LineCodeSTC(k).LineCode Then
                                    If mpData.Get_Enable_ObjectName(mpData.MPObj(i), TM, False, n12) = True Then
                                        lbObjRef.Items.Add(n12)
                                        RefObject.Add(i)
                                        j = mpData.MPObj(i).NumOfLine
                                        Exit For
                                    End If
                                End If
                            Next
                        End With
                    Next
                End If
            Next
        End If

    End Sub

    Private Sub btnSetObjRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetObjRef.Click
        Dim L As Integer = lbList.SelectedIndex
        If L = -1 Then Exit Sub

        If Obj.SucSTC(L).Time.nullFlag = True Then
            Dim msgText = "時期を先に設定してください。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim L2 As Integer = lbObjRef.SelectedIndex
        If L2 = -1 Then Exit Sub
        With Obj.SucSTC(L)
            .ObjectCode = RefObject(L2)
        End With
        lbList.Items(L) = clsGeneric.getTimeList(Obj.SucSTC(L), mpData)
        lbList.SelectedIndex = -1
        lbList.SelectedIndex = L
        btnOK.Focus()
    End Sub

    Private Sub frmMED_ObjectSuccession_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmMED_ObjectSuccession_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ObjectSuccession")
        e.Cancel = True
    End Sub

    Private Sub frmMED_ObjectSuccession_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblObjSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblObjSet.Click

        Dim L As Integer = lbList.SelectedIndex
        If L = -1 Then Exit Sub

        If Obj.SucSTC(L).Time.nullFlag = True Then
            Dim msgText = "時期を先に設定してください。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim SearchObject As New frmSearch_Object
        Dim init_para As New frmSearch_Object.init_parameter_data(mpData)
        init_para.Time = Obj.SucSTC(L).Time
        init_para.ObjectType = mpData.ObjectKind(Obj.Kind).ObjectType
        init_para.TimeChangeEnabled = False

        If SearchObject.ShowDialog(Me, mpData, init_para) = Windows.Forms.DialogResult.OK Then
            Obj.SucSTC(L).ObjectCode = SearchObject.getSelectedObjectNumber
            lbList.Items(L) = clsGeneric.getTimeList(Obj.SucSTC(L), mpData)
        End If
        SearchObject.Dispose()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

    End Sub
End Class