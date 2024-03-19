Public Class frmMED_ObjectNameTimeSet
    Dim NameTimeStac() As clsMapData.Object_NameTimeStac_Data
    Dim numOfNametime As Integer
    Dim CloseCancelF As Boolean = False
    Dim Objectkind() As clsMapData.strObjectGroup_Data
    Dim ObjGroup As Integer
    Dim selectList As Integer
    ''' <summary>
    ''' オブジェクト名期間設定のデータセット
    ''' </summary>
    ''' <param name="num"></param>
    ''' <param name="ObjectNameTimeStac"></param>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef _Objectkind() As clsMapData.strObjectGroup_Data, ByVal _ObjGroup As Integer, ByVal num As Integer, ByVal ObjectNameTimeStac() As clsMapData.Object_NameTimeStac_Data) As Windows.Forms.DialogResult
        Objectkind = _Objectkind
        ObjGroup = _ObjGroup
        numOfNametime = num
        lbList.Items.Clear()
        ReDim NameTimeStac(num - 1)
        For i As Integer = 0 To num - 1
            NameTimeStac(i) = ObjectNameTimeStac(i).Clone
            lbList.Items.Add(clsGeneric.getTimeList(NameTimeStac(i)))
        Next
        selectList = -1
        lbList.SelectedIndex = 0
        Return Me.ShowDialog(Owner)
    End Function
    ''' <summary>
    ''' オブジェクト名期間設定とその数の取得
    ''' </summary>
    ''' <param name="gNameTimeStac">スタック戻り値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNameTimeStac(ByRef gNameTimeStac() As clsMapData.Object_NameTimeStac_Data) As Integer
        gNameTimeStac = NameTimeStac
        Return numOfNametime
    End Function



    Private Sub lbList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbList.SelectedIndexChanged
        If Me.Tag = "off" Then
            Return
        End If
        If selectList <> -1 Then
            If getPresentData() = False Then
                Return
            End If
        End If
        selectList = lbList.SelectedIndex
        Me.Tag = "off"
        clsGeneric.setObjectNameToKTGrid(ktObjectName, Objectkind, ObjGroup, NameTimeStac(selectList).NamesList)
        dbdtpStartTime.Value = NameTimeStac(selectList).SETime.StartTime
        dbdtpEndTime.Value = NameTimeStac(selectList).SETime.EndTime
        Me.Tag = "on"
    End Sub

    Private Function getPresentData() As Boolean
        Dim L As Integer = selectList
        With NameTimeStac(L)
            If clsGeneric.getObjectNameFromKtgrid(ktObjectName, .NamesList) = False Then
                MsgBox("オブジェクト名が設定されていません。", MsgBoxStyle.Exclamation)
                Return False
            End If
            .SETime.StartTime = dbdtpStartTime.Value
            .SETime.EndTime = dbdtpEndTime.Value
        End With
        Me.Tag = "off"
        lbList.Items(L) = clsGeneric.getTimeList(NameTimeStac(L))
        Me.Tag = "on"
        Return True
    End Function

    Private Sub btnCopyName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyName.Click

        Dim L As Integer = selectList
        If L = -1 Or numOfNametime = 1 Then
        Else
            Dim L2 As Integer
            If L = 0 Then
                L2 = numOfNametime - 1
            Else
                L2 = L - 1
            End If
            NameTimeStac(L).NamesList = NameTimeStac(L2).NamesList.Clone
            clsGeneric.setObjectNameToKTGrid(ktObjectName, Objectkind, ObjGroup, NameTimeStac(L2).NamesList)
            Me.Tag = "off"
            lbList.Items(L) = clsGeneric.getTimeList(NameTimeStac(L))
            Me.Tag = "on"
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If getPresentData() = False Then
            Return
        End If

        Dim n As Integer = numOfNametime + 1
        numOfNametime = n
        ReDim Preserve NameTimeStac(n - 1)
        With NameTimeStac(n - 1)
            ReDim .NamesList(Objectkind(ObjGroup).ObjectNameNum - 1)
            .SETime = clsTime.GetNullStartEndYMD
            If n = 1 Then
            Else
                .SETime.StartTime = clsTime.getTomorrow(NameTimeStac(n - 2).SETime.EndTime)
            End If
        End With
        selectList = -1
        lbList.Items.Add(clsGeneric.getTimeList(NameTimeStac(n - 1)))
        lbList.SelectedIndex = n - 1
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim L As Integer = selectList
        If L = -1 Then Exit Sub
        Dim n As Integer = numOfNametime - 1
        If n = 0 Then
            Dim msgText = "期間設定は最低一つは必要です。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
        Else
            numOfNametime = n
            For i As Integer = L + 1 To n
                NameTimeStac(i - 1) = NameTimeStac(i)
            Next
            Me.Tag = "off"
            lbList.Items.RemoveAt(L)
            Me.Tag = "on"
            selectList = -1
            lbList.SelectedIndex = Math.Max(L - 1, 0)
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If getPresentData() = False Then
            CloseCancelF = True
            Return
        End If
        sort_Time()


        Dim n As Integer = numOfNametime
        Dim SETime(n) As Start_End_Time_data
        For i As Integer = 0 To n - 1
            With NameTimeStac(i)
                SETime(i) = .SETime
                If clsTime.CheckStartEndTime(.SETime) = False Then
                    Dim msgText = "開始時期は終了時期よりも前である必要があります。"
                    MsgBox(msgText, MsgBoxStyle.Exclamation)
                    selectList = i
                    lbList.SelectedIndex = i
                    CloseCancelF = True
                    Return
                End If
            End With
        Next
        Dim E_Mes As String = ""
        If clsTime.Check_TimeSeries_Overlap(n, SETime, E_Mes) = False Then
            MsgBox(E_Mes, vbExclamation)
            CloseCancelF = True
            Return
        End If

        For i As Integer = 1 To n - 1
            If clsTime.getTomorrow(NameTimeStac(i - 1).SETime.EndTime).Equals(NameTimeStac(i).SETime.StartTime) = False Then
                If MsgBox("オブジェクト名の期間が連続していません。よろしいですか？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    CloseCancelF = True
                    Return
                Else
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub txtObjectName1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbdtpStartTime.ValueChanged, dbdtpEndTime.ValueChanged
        If Me.Tag = "on" Then
            getPresentData()
        End If
    End Sub

    Private Sub sort_Time()


        Dim So As New clsSortingSearch
        Dim L As Integer = lbList.SelectedIndex

        Dim n As Integer = numOfNametime

        So.AddInit(VariantType.Integer)
        For i As Integer = 0 To n - 1
            So.Add(clsTime.YMDtoValue(NameTimeStac(i).SETime.StartTime))
        Next
        So.AddEnd()

        Dim P3(n - 1) As clsMapData.Object_NameTimeStac_Data
        Dim NewLine As Integer
        For i As Integer = 0 To n - 1
            P3(i) = NameTimeStac(So.DataPosition(i))
            If So.DataPosition(i) = L Then
                NewLine = i
            End If
        Next
        Me.Tag = "off"
        lbList.Items.Clear()
        For i As Integer = 0 To n - 1
            NameTimeStac(i) = P3(i)
            lbList.Items.Add(clsGeneric.getTimeList(P3(i)))
        Next
        Me.Tag = "on"
        selectList = -1
        lbList.SelectedIndex = NewLine
    End Sub

    Private Sub frmMED_ObjectNameTimeSet_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        ktObjectName.Refresh()
    End Sub

    Private Sub frmMED_ObjectNameTimeSet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmMED_ObjectNameTimeSet_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ObjectNameTimeSet")
        e.Cancel = True
    End Sub
End Class