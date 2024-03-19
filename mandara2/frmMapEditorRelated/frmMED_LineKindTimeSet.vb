Public Class frmMED_LineKindTimeSet
    Dim CloseCancelF As Boolean
    Dim EditLineTimeSTC() As clsMapData.Line_Time_Data
    Dim NumOfTime As Integer
    Dim SETime_Ref As New ArrayList ' Start_End_Time_data
    Dim Mapdata As clsMapData
    Dim LastSelLineKind As Integer

    Private Sub frmMED_LineCodeTime_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub sort_Time()

        Dim So As New clsSortingSearch(VariantType.Integer)

        Dim n As Integer = NumOfTime
        For i As Integer = 0 To n - 1
            So.Add(clsTime.YMDtoValue(EditLineTimeSTC(i).SETime.StartTime))
        Next
        So.AddEnd()

        Dim P3(n - 1) As clsMapData.Line_Time_Data

        Dim L As Integer = lbLineList.SelectedIndex
        Dim NewLine As Integer
        For i As Integer = 0 To n - 1
            P3(i) = EditLineTimeSTC(So.DataPosition(i))
            If So.DataPosition(i) = L Then
                NewLine = i
            End If
        Next
        Me.Tag = "off"
        lbLineList.Items.Clear()
        For i As Integer = 0 To n - 1
            EditLineTimeSTC(i) = P3(i)
            lbLineList.Items.Add(clsGeneric.getTimeList(P3(i), Mapdata))
        Next
        Me.Tag = "on"
        lbLineList.SelectedIndex = NewLine
    End Sub
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal Line As clsMapData.strLine_Data, ByRef MpData As clsMapData, ByVal lineMode As frmMapEditor.editingModes)
        Mapdata = MpData
        EditLineTimeSTC = Line.LineTimeSTC.Clone
        NumOfTime = Line.NumOfTime
        Me.Tag = "off"
        cboLineKind.Items.Clear()
        For i As Integer = 0 To Mapdata.Map.LpNum - 1
            cboLineKind.Items.Add(Mapdata.LineKind(i).Name)
        Next
        cboLineKind.SelectedIndex = 0
        Me.Tag = "on"
        sort_Time()
        If lineMode = frmMapEditor.editingModes.LineEditingMode Then
            gbTimeRef.Visible = True
            Dim Lcode() As Integer
            Dim RLineN As Integer = MapData.Get_Connect_Line(Line, Lcode)
            lbTimeRef.Items.Clear()

            For i As Integer = 0 To RLineN - 1
                With Mapdata.MPLine(Lcode(i))
                    For j As Integer = 0 To .NumOfTime - 1
                        Dim s As strYMD = .LineTimeSTC(j).SETime.StartTime
                        Dim E As strYMD = .LineTimeSTC(j).SETime.EndTime
                        If s.nullFlag = False Or E.nullFlag = False Then
                            Dim newSE As Start_End_Time_data = clsTime.GetStartEndYMD(s, E)
                            If SETime_Ref.Contains(clsTime.GetStartEndYMD(s, E)) = False Then
                                SETime_Ref.Add(newSE)
                                lbTimeRef.Items.Add(clsTime.StartEndtoString(newSE))
                            End If
                        End If
                    Next
                End With
            Next

            lbTimeRef.SelectedIndex = lbTimeRef.Items.Count - 1
        Else
            gbTimeRef.Visible = False
        End If
        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResult(ByRef numOfLineTimeStac As Integer, ByRef LastLKing As Integer) As clsMapData.Line_Time_Data()
        numOfLineTimeStac = NumOfTime
        LastLKing = LastSelLineKind
        Return EditLineTimeSTC
    End Function

    Private Sub btnSetRef_Click(sender As Object, e As EventArgs) Handles btnSetRef.Click
        Dim L As Integer = lbTimeRef.SelectedIndex
        If L = -1 Then
            Exit Sub
        End If

        Dim SEtime As Start_End_Time_data
        SEtime = clsTime.GetStartEndYMD(lbTimeRef.Items(L))
        dbdtpStartTime.Value = SEtime.StartTime
        dbdtpEndTime.Value = SEtime.EndTime
    End Sub

    Private Sub lbLineList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbLineList.SelectedIndexChanged
        If Me.Tag = "off" Then
            Exit Sub
        End If
        Dim L As Integer = lbLineList.SelectedIndex
        Me.Tag = "off"
        LastSelLineKind = EditLineTimeSTC(L).Kind
        cboLineKind.SelectedIndex = EditLineTimeSTC(L).Kind
        dbdtpStartTime.Value = EditLineTimeSTC(L).SETime.StartTime
        dbdtpEndTime.Value = EditLineTimeSTC(L).SETime.EndTime
        Me.Tag = "on"
    End Sub

    Private Sub dbdtpStartTime_ValueChanged(sender As Object, e As EventArgs) _
                    Handles dbdtpStartTime.ValueChanged, dbdtpEndTime.ValueChanged, cboLineKind.SelectedIndexChanged
        If Me.Tag = "off" Then
            Exit Sub
        End If
        Dim L As Integer = lbLineList.SelectedIndex
        With EditLineTimeSTC(L).SETime
            .StartTime = dbdtpStartTime.Value
            .EndTime = dbdtpEndTime.Value
        End With
        EditLineTimeSTC(L).Kind = cboLineKind.SelectedIndex
        LastSelLineKind = EditLineTimeSTC(L).Kind
        Me.Tag = "off"
        lbLineList.Items(L) = clsGeneric.getTimeList(EditLineTimeSTC(L), Mapdata)
        Me.Tag = "on"
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click


        Dim n As Integer = NumOfTime + 1
        NumOfTime = n
        ReDim Preserve EditLineTimeSTC(n - 1)
        With EditLineTimeSTC(n - 1)
            .Kind = EditLineTimeSTC(n - 2).Kind
            .SETime = clsTime.GetNullStartEndYMD
            If n = 1 Then
            Else
                .SETime.StartTime = clsTime.getTomorrow(EditLineTimeSTC(n - 2).SETime.EndTime)
            End If
        End With
        lbLineList.Items.Add(clsGeneric.getTimeList(EditLineTimeSTC(n - 1), Mapdata))
        lbLineList.SelectedIndex = n - 1
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim L As Integer = lbLineList.SelectedIndex
        If L = -1 Then Exit Sub
        Dim n As Integer = NumOfTime - 1
        If n = 0 Then
            Dim msgText = "期間設定は最低一つは必要です。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
        Else
            NumOfTime = n
            For i As Integer = L + 1 To n
                EditLineTimeSTC(i - 1) = EditLineTimeSTC(i)
            Next
            Me.Tag = "off"
            lbLineList.Items.RemoveAt(L)
            Me.Tag = "on"
            lbLineList.SelectedIndex = Math.Max(L - 1, 0)
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        sort_Time()

        Dim SETime(NumOfTime - 1) As Start_End_Time_data
        For i As Integer = 0 To NumOfTime - 1
            SETime(i) = EditLineTimeSTC(i).SETime
        Next
        Dim ERmessage As String = ""
        If clsTime.Check_TimeSeries_Overlap(NumOfTime, SETime, ERmessage) = False Then
            MsgBox(ERmessage, MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Exit Sub
        End If
    End Sub

    Private Sub dbdtpEndTime_ValueChanged(sender As Object, e As EventArgs) Handles dbdtpEndTime.ValueChanged

    End Sub

    Private Sub frmMED_LineKindTimeSet_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_LineKindTimeSet")
        e.Cancel = True
    End Sub
End Class