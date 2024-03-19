Public Class frmMED_ObjectCPTimeSet
    Dim centerPStac() As clsMapData.Object_CenterPoint_Data
    Dim numOfCenterP As Integer
    Dim shift_Value As Single
    Dim CloseCancelF As Boolean
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal num As Integer, _
                                         ByVal ObjectCenterPStac() As clsMapData.Object_CenterPoint_Data, _
                                         ByVal XYshift_value As Single) As Windows.Forms.DialogResult
        centerPStac = ObjectCenterPStac.Clone
        numOfCenterP = num
        shift_Value = XYshift_value
        sort_Time()
        lbList.SelectedIndex = 0
        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResult(ByRef ObjectCenterPStac() As clsMapData.Object_CenterPoint_Data) As Integer
        ObjectCenterPStac = centerPStac
        Return numOfCenterP
    End Function
    Private Sub sort_Time()

        Dim So As New clsSortingSearch(VariantType.Integer)
        Dim P3() As clsMapData.Object_CenterPoint_Data

        For i As Integer = 0 To numOfCenterP - 1
            So.Add(clsTime.YMDtoValue(centerPStac(i).SETime.StartTime))
        Next
        So.AddEnd()

        Me.Tag = "off"
        ReDim P3(numOfCenterP - 1)
        For i As Integer = 0 To numOfCenterP - 1
            P3(i) = centerPStac(So.DataPosition(i))
        Next
        lbList.Items.Clear()
        For i As Integer = 0 To numOfCenterP - 1
            centerPStac(i) = P3(i)
            lbList.Items.Add(clsGeneric.getTimeList(P3(i), i))
        Next
        Me.Tag = "on"
    End Sub

    Private Sub lbList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbList.SelectedIndexChanged
        If Me.Tag = "off" Then
            Exit Sub
        End If
        Dim L As Integer = lbList.SelectedIndex
        Me.Tag = "off"
        dbdtpStartTime.Value = centerPStac(L).SETime.StartTime
        dbdtpEndTime.Value = centerPStac(L).SETime.EndTime
        Me.Tag = "on"
    End Sub

    Private Sub dbdtpStartTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbdtpStartTime.ValueChanged, dbdtpEndTime.ValueChanged
        If Me.Tag = "on" Then
            Me.Tag = "off"
            Dim L As Integer = lbList.SelectedIndex
            centerPStac(L).SETime.StartTime = dbdtpStartTime.Value
            centerPStac(L).SETime.EndTime = dbdtpEndTime.Value
            lbList.Items(L) = clsGeneric.getTimeList(centerPStac(L), L)
            Me.Tag = "on"
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim n As Integer = numOfCenterP + 1
        numOfCenterP = n
        ReDim Preserve centerPStac(n - 1)
        With centerPStac(n - 1)
            .SETime = clsTime.GetNullStartEndYMD
            .Position = PointF.Add(centerPStac(n - 2).Position, New SizeF(shift_Value, shift_Value))
            If n <> 1 Then
                .SETime.StartTime = clsTime.getTomorrow(centerPStac(n - 2).SETime.EndTime)
            End If
        End With
        lbList.Items.Add(clsGeneric.getTimeList(centerPStac(n - 1), n - 1))
        lbList.SelectedIndex = n - 1

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim L As Integer = lbList.SelectedIndex
        If L = -1 Then Exit Sub
        Dim n As Integer = numOfCenterP - 1
        If n = 0 Then
            Dim msgText = "代表点は最低一つは必要です。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        numOfCenterP = n
        For i As Integer = L + 1 To n
            centerPStac(i - 1) = centerPStac(i)
        Next
        ReDim Preserve centerPStac(n - 1)
        lbList.SelectedIndex = L - 1
        lbList.Items.RemoveAt(L)

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        sort_Time()


        Dim n As Integer = numOfCenterP
        Dim SETime(n) As Start_End_Time_data
        For i As Integer = 0 To n - 1
            With centerPStac(i)
                SETime(i) = .SETime
                If clsTime.CheckStartEndTime(.SETime) = False Then
                    Dim msgText = "開始時期は終了時期よりも前である必要があります。"
                    MsgBox(msgText, MsgBoxStyle.Exclamation)
                    lbList.SelectedIndex = i
                    CloseCancelF = True
                    Exit Sub
                End If
            End With
        Next
        Dim E_Mes As String = ""
        If clsTime.Check_TimeSeries_Overlap(n, SETime, E_Mes) = False Then
            MsgBox(E_Mes, vbExclamation)
            CloseCancelF = True
            Exit Sub
        End If

        For i As Integer = 1 To n - 1
            If clsTime.getTomorrow(centerPStac(i - 1).SETime.EndTime).Equals(centerPStac(i).SETime.StartTime) = False Then
                If MsgBox("オブジェクト名の期間が連続していません。よろしいですか？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    CloseCancelF = True
                    lbList.SelectedIndex = i
                    Exit Sub
                Else
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub frmMED_ObjectCPTimeSet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmMED_ObjectCPTimeSet_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ObjectCPTimeSet")
        e.Cancel = True
    End Sub
End Class