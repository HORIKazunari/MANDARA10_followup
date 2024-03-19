Public Class frmMED_DefTimeAttDataObjectEdit
    Dim defPData() As clsMapData.strDefTimeAttDataEach_Info
    Dim data_n As Integer
    Dim TimeAttDataType As clsMapData.enmDefTimeAttDataType
    Dim DataType As enmAttDataType
    Dim CloseCancelF As Boolean
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
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef MapData As clsMapData, ByRef Obj As clsMapData.strObj_Data, ByRef _defPDataItem As clsMapData.strMPObjDefTimeAttData_Info,
                                          ByRef _defPData() As clsMapData.strDefTimeAttDataEach_Info) As Windows.Forms.DialogResult

        For i As Integer = 0 To Obj.NumOfNameTime - 1
            lbObjName.Items.Add(clsGeneric.getTimeList(Obj.NameTimeSTC(i)))
        Next
        If _defPData Is Nothing = True Then
            'data_n = 1
            gbSetting.Enabled = False
            gbTimeRef.Enabled = False
        Else
            defPData = _defPData.Clone
            data_n = defPData.Length
            gbSetting.Enabled = True
            gbTimeRef.Enabled = True
        End If

        lblType.Text = clsGeneric.getDefTimeAttrDataTypeStrings(_defPDataItem.Type)
        TimeAttDataType = _defPDataItem.Type
        With _defPDataItem.attData

            lblTitle.Text = "タイトル:" + .Title
            lblUnit.Text = "単位:" + .Unit
            If .MissingF = True Then
                lblMissing.Text = "空白は欠損値"
            Else
                lblMissing.Text = "空白は0"
            End If
            DataType = clsGeneric.getAttDataType_From_TitleUnit(.Title, .Unit)
        End With

        lbTimeRef.Items.Clear()
        Select Case TimeAttDataType
            Case clsMapData.enmDefTimeAttDataType.PointData
                lblTime1.Text = "時期"
                lblTime2.Visible = False
                ddtpTime2.Visible = False

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
                For i As Integer = 0 To Obj.NumOfSuc - 1
                    TimeRef.Add(clsTime.YMDtoValue(Obj.SucSTC(i).Time))
                Next

                If MapData.ObjectKind(Obj.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
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


                For i As Integer = 0 To TimeRef.NumofData - 1
                    Dim f As Boolean = True
                    If i <> 0 Then
                        If TimeRef.DataPositionValue_Integer(i) = TimeRef.DataPositionValue_Integer(i - 1) Then
                            f = False
                        End If
                    End If
                    If f = True Then
                        Dim a As strYMD = clsTime.GetYMDfromValue(TimeRef.DataPositionValue_Integer(i))
                        lbTimeRef.Items.Add(clsTime.YMDtoString(a))
                    End If
                Next
            Case clsMapData.enmDefTimeAttDataType.SpanData
                lblTime1.Text = "開始"
                lblTime2.Visible = True
                ddtpTime2.Visible = True

                For i As Integer = 0 To Obj.NumOfNameTime - 1
                    lbTimeRef.Items.Add(clsTime.StartEndtoString(Obj.NameTimeSTC(i).SETime))
                Next
        End Select

        If lbTimeRef.Items.Count > 0 Then
            lbTimeRef.SelectedIndex = 0
        End If

        sort_Time()
        lbList.SelectedIndex = lbList.Items.Count - 1
        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResult() As clsMapData.strDefTimeAttDataEach_Info()
        Return defPData
    End Function

    Private Sub sort_Time()

        lbList.Items.Clear()
        If data_n = 0 Then
            Return
        End If
        clsGeneric.Sort_strDefPointAttDataEach_Info(defPData)

        For i As Integer = 0 To data_n - 1
            Dim tx As String = getTimeString(defPData(i))
            lbList.Items.Add(tx)
        Next
    End Sub

    Private Sub btnSetRef_Click(sender As Object, e As EventArgs) Handles btnSetRef.Click
        Dim n As Integer = lbTimeRef.SelectedIndex
        If n = -1 Then
            MsgBox("選択されていません。", MsgBoxStyle.Exclamation)
            Return
        End If
        Select Case TimeAttDataType
            Case clsMapData.enmDefTimeAttDataType.PointData
                ddtpTime1.Value = clsTime.GetYMD(lbTimeRef.Items(n))
            Case clsMapData.enmDefTimeAttDataType.SpanData
                Dim t As Start_End_Time_data = clsTime.GetStartEndYMD(lbTimeRef.Items(n))
                ddtpTime1.Value = t.StartTime
                ddtpTime2.Value = t.EndTime
        End Select

    End Sub

    Private Sub ddtpTime1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddtpTime1.ValueChanged

        If Me.Tag = "" Then
            Dim L As Integer = lbList.SelectedIndex
            defPData(L).Span.StartTime = ddtpTime1.Value
            Me.Tag = "off"
            lbList.Items(L) = getTimeString(defPData(L))
            Me.Tag = ""
        End If
    End Sub
    Private Sub ddtpTime2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddtpTime2.ValueChanged

        If Me.Tag = "" Then
            Dim L As Integer = lbList.SelectedIndex
            defPData(L).Span.EndTime = ddtpTime2.Value
            Me.Tag = "off"
            lbList.Items(L) = getTimeString(defPData(L))
            Me.Tag = ""
        End If
    End Sub

    Private Sub lbList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbList.SelectedIndexChanged
        Dim L As Integer = lbList.SelectedIndex
        If Me.Tag = "" And L <> -1 Then
            With defPData(L)
                txtValue.Text = .Value
                ddtpTime1.Value = .Span.StartTime
                If TimeAttDataType = clsMapData.enmDefTimeAttDataType.SpanData Then
                    ddtpTime2.Value = .Span.EndTime
                End If
            End With
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        gbSetting.Enabled = True
        gbTimeRef.Enabled = True
        data_n += 1
        ReDim Preserve defPData(data_n - 1)
        defPData(data_n - 1) = getInitdefPData()
        If TimeAttDataType = clsMapData.enmDefTimeAttDataType.SpanData And data_n >= 2 Then
            defPData(data_n - 1).Span.StartTime = clsTime.getTomorrow(defPData(data_n - 2).Span.EndTime)
        End If
        lbList.Items.Add(getTimeString(defPData(data_n - 1)))
        lbList.SelectedIndex = data_n - 1

    End Sub
    Private Function getTimeString(ByVal defPData As clsMapData.strDefTimeAttDataEach_Info) As String
        With defPData
            Select Case TimeAttDataType
                Case clsMapData.enmDefTimeAttDataType.PointData
                    Return "【" + clsTime.YMDtoString(.Span.StartTime) + "】" + .Value
                Case clsMapData.enmDefTimeAttDataType.SpanData
                    Return "【" + clsTime.StartEndtoString(.Span) + "】" + .Value
            End Select
        End With

    End Function
    Private Function getInitdefPData() As clsMapData.strDefTimeAttDataEach_Info
        Dim defPData As clsMapData.strDefTimeAttDataEach_Info
        Select Case TimeAttDataType
            Case clsMapData.enmDefTimeAttDataType.PointData
                defPData.Span.StartTime = clsTime.GetYMD(Date.Today)
            Case clsMapData.enmDefTimeAttDataType.SpanData
                defPData.Span = clsTime.GetNullStartEndYMD
        End Select
        defPData.Value = ""
        Return defPData
    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim L As Integer = lbList.SelectedIndex
        If L = -1 Then Exit Sub
        Dim n As Integer = data_n - 1
        data_n = n
        If n > 0 Then
            For i = L + 1 To n
                defPData(i - 1) = defPData(i)
            Next
            ReDim Preserve defPData(n - 1)
            Me.Tag = "off"
            lbList.Items.RemoveAt(L)
            Me.Tag = ""
            clsGeneric.ListIndex_Reset(lbList, L)
        Else
            Erase defPData
            lbList.Items.RemoveAt(L)
            gbSetting.Enabled = True
            gbTimeRef.Enabled = True
            Me.Tag = "off"
            txtValue.Text = ""
            Me.Tag = ""
        End If
    End Sub

    Private Sub txtValue_LostFocus(sender As Object, e As EventArgs) Handles txtValue.LostFocus
        Select Case DataType
            Case enmAttDataType.Normal
                Dim tx As String = txtValue.Text
                If tx <> "" Then
                    txtValue.Text = Val(tx).ToString
                End If
        End Select
    End Sub

    Private Sub txtValue_TextChanged(sender As Object, e As EventArgs) Handles txtValue.TextChanged

        If Me.Tag = "" Then
            Dim L As Integer = lbList.SelectedIndex
            defPData(L).Value = txtValue.Text
            Me.Tag = "off"
            lbList.Items(L) = getTimeString(defPData(L))
            Me.Tag = ""
        End If
    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If data_n = 0 Then
            MsgBox("データ値が設定してありません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
        Else
            Dim defsel = lbList.SelectedIndex
            sort_Time()
            Select Case TimeAttDataType
                Case clsMapData.enmDefTimeAttDataType.PointData
                    If data_n = 1 Then
                        If defPData(0).Span.StartTime.nullFlag = True Then
                            Erase defPData
                            Return
                        End If
                    End If
                    For i As Integer = 0 To data_n - 1
                        If defPData(i).Span.StartTime.nullFlag = True Then
                            MsgBox("時期未設定では登録できません。", MsgBoxStyle.Exclamation)
                            lbList.SelectedIndex = defsel
                            CloseCancelF = True
                        End If
                        If i > 0 Then
                            If defPData(i).Span.StartTime.Equals(defPData(i - 1).Span.StartTime) = True Then
                                MsgBox("同じ時期には設定できません。", MsgBoxStyle.Exclamation)
                                lbList.SelectedIndex = defsel
                                CloseCancelF = True
                            End If
                        End If
                    Next
                Case clsMapData.enmDefTimeAttDataType.SpanData
                    Dim SETime(data_n) As Start_End_Time_data
                    For i As Integer = 0 To data_n - 1
                        With defPData(i)
                            SETime(i) = .Span
                            If clsTime.CheckStartEndTime(.Span) = False Then
                                Dim msgText = "開始時期は終了時期よりも前である必要があります。"
                                MsgBox(msgText, MsgBoxStyle.Exclamation)
                                lbList.SelectedIndex = i
                                CloseCancelF = True
                                Return
                            End If
                        End With
                    Next
                    Dim E_Mes As String = ""
                    If clsTime.Check_TimeSeries_Overlap(data_n, SETime, E_Mes) = False Then
                        MsgBox(E_Mes, vbExclamation)
                        lbList.SelectedIndex = defsel
                        CloseCancelF = True
                        Return
                    End If

                    For i As Integer = 1 To data_n - 1
                        If clsTime.getTomorrow(defPData(i - 1).Span.EndTime).Equals(defPData(i).Span.StartTime) = False Then
                            If MsgBox("オブジェクト名の期間が連続していません。よろしいですか？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                lbList.SelectedIndex = defsel
                                CloseCancelF = True
                                Return
                            Else
                                Exit For
                            End If
                        End If
                    Next
            End Select
        End If

    End Sub

    Private Sub frmMED_DefTimeAttDataObjectEdit_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_DefTimeAttDataObjectEdit", Me)
        e.Cancel = True
    End Sub

    Private Sub frmMED_DefTimeAttDataObjectEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class