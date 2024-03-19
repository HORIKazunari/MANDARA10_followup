﻿Public Structure strYMD
    '日付構造体

    Public Year As Short
    Public Month As Byte
    Public Day As Byte


    ''' <summary>
    ''' nullかどうか取得する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function nullFlag() As Boolean
        If Me.Day = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Structure

''' <summary>
''' 開始終了の構造体
''' </summary>
''' <remarks></remarks>
Public Structure Start_End_Time_data
    Public StartTime As strYMD
    Public EndTime As strYMD

End Structure


Public Class frmMED_AggrObjUseTime
    Dim Lcs As Integer
    Dim Obj As clsMapData.strObj_Data

    Dim SETime() As Start_End_Time_data


    Dim CloseCancelF As Boolean
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal LineCodeStacPosition As Integer, ByVal mpObj As clsMapData.strObj_Data, ByRef MapData As clsMapData) As Windows.Forms.DialogResult

        Obj = mpObj.Clone
        '構成オブジェクトの使用期間をリストに入れる
        Lcs = LineCodeStacPosition
        Me.Tag = "off"
        With Obj.LineCodeSTC(Lcs)
            If .NumOfTime = 0 Then
                .NumOfTime = 1
                ReDim .Times(0)
                .Times(0) = clsTime.GetNullStartEndYMD
            End If
            ReDim SETime(.NumOfTime)
            lbList.Items.Clear()
            For i As Integer = 0 To .NumOfTime - 1
                SETime(i) = .Times(i)
                lbList.Items.Add(clsTime.StartEndtoString(SETime(i)))
            Next
        End With
        Me.Tag = "on"
        lbList.SelectedIndex = 0

        'オフジェクトの他の構成オブジェクトの使用期間を参照リストに入れる
        Dim se As New ArrayList
        Dim so As New clsSortingSearch(VariantType.Integer)
        For i As Integer = 0 To Obj.NumOfLine - 1
            Dim n As Integer = Obj.LineCodeSTC(i).NumOfTime
            If n <> 0 And i <> Lcs Then
                For j As Integer = 0 To n - 1
                    If se.Contains(Obj.LineCodeSTC(i).Times(j)) = False Then
                        se.Add(Obj.LineCodeSTC(i).Times(j))
                        so.Add(clsTime.YMDtoValue(Obj.LineCodeSTC(i).Times(j).StartTime))
                    End If
                Next
            End If
        Next
        so.AddEnd()
        lbTimeRef.Items.Clear()
        For i As Integer = 0 To so.NumofData - 1
            Dim s As String = se.Item(so.DataPosition(i)).ToString
            lbTimeRef.Items.Add(se.Item(so.DataPosition(i)).ToString)
        Next
        lbTimeRef.SelectedIndex = lbTimeRef.Items.Count - 1

        '構成オブジェクトの有効期間参照
        lblLineNO.Text = MapData.MPObj(Obj.LineCodeSTC(Lcs).LineCode).NameTimeSTC(0).connectNames
        lbLineRef.Items.Clear()

        With MapData.MPObj(Obj.LineCodeSTC(Lcs).LineCode)
            For i As Integer = 0 To .NumOfNameTime - 1
                lbLineRef.Items.Add(clsTime.StartEndtoString(.NameTimeSTC(i).SETime))
            Next
            lbLineRef.SelectedIndex = lbLineRef.Items.Count - 1
        End With

        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResult() As clsMapData.strObj_Data
        Return Obj
    End Function
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



    Private Sub lbList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbList.SelectedIndexChanged
        If Me.Tag = "off" Then
            Exit Sub
        End If
        Dim L As Integer = lbList.SelectedIndex
        Me.Tag = "off"
        dbdtpStartTime.Value = SETime(L).StartTime
        dbdtpEndTime.Value = SETime(L).EndTime
        Me.Tag = "on"
    End Sub

    Private Sub dbdtpStartTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbdtpStartTime.ValueChanged, dbdtpEndTime.ValueChanged
        If Me.Tag = "off" Then
            Exit Sub
        End If
        Dim L As Integer = lbList.SelectedIndex
        With SETime(L)
            .StartTime = dbdtpStartTime.Value
            .EndTime = dbdtpEndTime.Value
        End With
        Me.Tag = "off"
        lbList.Items(L) = clsTime.StartEndtoString(SETime(L))
        Me.Tag = "on"
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim L As Integer = lbList.SelectedIndex
        With SETime(L)
            .StartTime = dbdtpStartTime.Value
            .EndTime = dbdtpEndTime.Value
        End With
        lbList.Items(L) = clsTime.StartEndtoString(SETime(L))

        Dim n As Integer = lbList.Items.Count + 1
        ReDim Preserve SETime(n - 1)
        SETime(n - 1) = clsTime.GetNullStartEndYMD
        lbList.Items.Add(clsTime.StartEndtoString(SETime(n - 1)))
        lbList.SelectedIndex = n - 1

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim L As Integer = lbList.SelectedIndex
        If L = -1 Then Exit Sub
        Dim n As Integer = lbList.Items.Count - 1
        If n = 0 Then
            Dim msgText = "期間設定は最低一つは必要です。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
        Else
            For i As Integer = L + 1 To n
                SETime(i - 1) = SETime(i)
            Next
            Me.Tag = "off"
            lbList.Items.RemoveAt(L)
            Me.Tag = "on"
            lbList.SelectedIndex = Math.Max(L - 1, 0)
        End If
    End Sub

    Private Sub btnSetLineRefTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetLineRefTime.Click
        Dim L As Integer = lbLineRef.SelectedIndex
        If L = -1 Then
            Exit Sub
        End If

        Dim SEtime As Start_End_Time_data
        SEtime = clsTime.GetStartEndYMD(lbLineRef.Items(L), "】")
        dbdtpStartTime.Value = SEtime.StartTime
        dbdtpEndTime.Value = SEtime.EndTime

    End Sub

    Private Sub btnSetRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetRef.Click
        Dim L As Integer = lbTimeRef.SelectedIndex
        If L = -1 Then
            Exit Sub
        End If

        Dim SEtime As Start_End_Time_data
        SEtime = clsTime.GetStartEndYMD(lbTimeRef.Items(L))
        dbdtpStartTime.Value = SEtime.StartTime
        dbdtpEndTime.Value = SEtime.EndTime

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Dim SET2() As Start_End_Time_data
        Dim f As Boolean, E_Mes As String
        Dim So As New clsSortingSearch(VariantType.Integer)

        Dim n As Integer = lbList.Items.Count
        For i As Integer = 0 To n - 1
            So.Add(clsTime.YMDtoValue(SETime(i).StartTime))
        Next
        So.AddEnd()

        ReDim SET2(n)
        For i As Integer = 0 To n - 1
            SET2(i) = SETime(So.DataPosition(i))
        Next

        Me.Tag = "off"
        lbList.Items.Clear()
        For i As Integer = 0 To n - 1
            SETime(i) = SET2(i)
            lbList.Items.Add(clsTime.StartEndtoString(SETime(i)))
        Next
        Me.Tag = "on"
        lbList.SelectedIndex = 0

        For i As Integer = 0 To n - 1
            If clsTime.CheckStartEndTime(SETime(i)) = False Then
                Dim msgText = "開始時期は終了時期よりも前である必要があります。"
                MsgBox(msgText, MsgBoxStyle.Exclamation)
                lbList.SelectedIndex = i
                CloseCancelF = True
                Exit Sub
            End If
        Next
        If clsTime.Check_TimeSeries_Overlap(n, SETime, E_Mes) = False Then
            MsgBox(E_Mes, vbExclamation)
            CloseCancelF = True
            Exit Sub
        Else
            With Obj.LineCodeSTC(Lcs)
                .NumOfTime = n
                ReDim .Times(Math.Max(n - 1, 0))
                For i As Integer = 0 To n - 1
                    .Times(i) = SETime(i)
                Next
            End With
        End If
    End Sub

    Private Sub frmMED_AggrObjUseTime_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_AggrObjUseTime")
    End Sub

    Private Sub frmMED_AggrObjUseTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class