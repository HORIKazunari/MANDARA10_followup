Public Class clsTime
    Public Shared Function Check_Duration_OK(ByVal duration1 As Start_End_Time_data, ByVal duration2 As Start_End_Time_data) As Boolean
        '期間１と期間２が重なっている場合にtrue

        If duration1.EndTime.nullFlag = False And duration2.StartTime.nullFlag = False Then
            If DateTime.Compare(clsTime.getDateTime(duration1.EndTime), clsTime.getDateTime(duration2.StartTime)) <= 0 Then
                Return False
            End If
        End If

        If duration2.EndTime.nullFlag = False And duration1.StartTime.nullFlag = False Then
            If DateTime.Compare(clsTime.getDateTime(duration2.EndTime), clsTime.getDateTime(duration1.StartTime)) <= 0 Then
                Return False
            End If
        End If
        Return True
    End Function

    ''' <summary>
    ''' '期間１が期間２に含まれている場合にtrueを返す
    ''' </summary>
    ''' <param name="duration1">期間１</param>
    ''' <param name="duration2">期間２</param>

    Public Shared Function Check_Duration_Inclusion(ByVal duration1 As Start_End_Time_data, ByVal duration2 As Start_End_Time_data) As Boolean
        '期間１が期間２に含まれている場合にtrue
        Select Case duration2.StartTime.nullFlag
            Case True '期間2の開始未設定
                If duration2.EndTime.nullFlag = True Then
                    Return True '期間2が開始・終了とも未設定の場合
                Else
                    If duration1.EndTime.nullFlag = True Then
                        Return False
                    Else
                        If DateTime.Compare(clsTime.getDateTime(duration1.EndTime), clsTime.getDateTime(duration2.EndTime)) <= 0 Then
                            Return True '期間2の開始が未設定で、期間2の終了が期間1よりも後の場合
                        Else
                            Return False
                        End If
                    End If
                End If
            Case False '期間2の開始設定あり
                If duration1.StartTime.nullFlag = True Then
                    Return False
                Else
                    If DateTime.Compare(clsTime.getDateTime(duration1.StartTime), clsTime.getDateTime(duration2.StartTime)) <= 0 Then
                        Return False
                    Else
                        If duration2.EndTime.nullFlag = True Then
                            Return True '期間1の開始が2より後で、期間2の終了が未設定の場合
                        Else
                            If DateTime.Compare(clsTime.getDateTime(duration1.EndTime), clsTime.getDateTime(duration2.EndTime)) <= 0 Then
                                Return True ''期間1の開始が2より後で、期間1の終了が期間2の終了よりも前の場合
                            Else
                                Return False
                            End If
                        End If
                    End If
                End If
        End Select
    End Function

    ''' <summary>
    ''' '期間１と期間２が重なっている場合にtrueを返す
    ''' </summary>
    ''' <param name="duration1">期間１</param>
    ''' <param name="duration2">期間２</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function checkDurationOverlapped(ByVal duration1 As Start_End_Time_data, ByVal duration2 As Start_End_Time_data) As Boolean

        If duration1.EndTime.nullFlag = False And duration2.StartTime.nullFlag = False Then
            If DateTime.Compare(clsTime.getDateTime(duration1.EndTime), clsTime.getDateTime(duration2.StartTime)) < 0 Then
                'd1の終了日がd2の開始日よりも前の場合はfalse
                Return False
            End If
        End If

        If duration2.EndTime.nullFlag = False And duration1.StartTime.nullFlag = False Then
            If DateTime.Compare(clsTime.getDateTime(duration2.EndTime), clsTime.getDateTime(duration1.StartTime)) < 0 Then
                'd2の終了日がd1の開始日よりも前の場合はfalse
                Return False
            End If
        End If
        Return True
    End Function

    ''' <summary>
    ''' 二つのstrYMDを比較して早い方を返す
    ''' </summary>
    ''' <param name="YMD1">時期1</param>
    ''' <param name="YMD2">時期2</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getEarlier(ByVal YMD1 As strYMD, ByVal YMD2 As strYMD) As strYMD
        If clsTime.YMDtoValue(YMD1) < clsTime.YMDtoValue(YMD2) Then
            Return YMD1
        Else
            Return YMD2
        End If
    End Function
    ''' <summary>
    ''' 二つのstrYMDを比較して遅い方を返す
    ''' </summary>
    ''' <param name="YMD1">時期1</param>
    ''' <param name="YMD2">時期2</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getLatter(ByVal YMD1 As strYMD, ByVal YMD2 As strYMD) As strYMD
        If clsTime.YMDtoValue(YMD1) > clsTime.YMDtoValue(YMD2) Then
            Return YMD1
        Else
            Return YMD2
        End If
    End Function
    ''' <summary>
    '''指定した年・月の日数を取得
    ''' </summary>
    ''' <param name="year">年</param>
    ''' <param name="month">月</param>
    Public Shared Function DaysInMonth(ByVal year As Integer, ByVal month As Integer) As Integer
        Return DateTime.DaysInMonth(year, month)
    End Function

    ''' <summary>
    ''' 現時点が指定の期間に含まれているかどうかをチェックし、含まれている場合にtrue
    ''' </summary>
    ''' <param name="duration">期間</param>
    Public Shared Function checkDurationIn(ByVal duration As Start_End_Time_data, ByVal Point As strYMD) As Boolean

        If Point.nullFlag = True Or (duration.StartTime.nullFlag = True And duration.EndTime.nullFlag) Then
            Return True
        Else
            Dim time As DateTime = clsTime.getDateTime(Point)
            Select Case duration.StartTime.nullFlag
                Case True
                    Dim etime As DateTime = clsTime.getDateTime(duration.EndTime)
                    If DateTime.Compare(time, etime) <= 0 Then
                        Return True
                    Else
                        Return False
                    End If
                Case False
                    Dim stime As DateTime = clsTime.getDateTime(duration.StartTime)
                    If duration.EndTime.nullFlag = True Then
                        If DateTime.Compare(stime, time) <= 0 Then
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        Dim etime As DateTime = clsTime.getDateTime(duration.EndTime)
                        If DateTime.Compare(stime, time) <= 0 And _
                             DateTime.Compare(time, etime) <= 0 Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
            End Select
        End If
    End Function
    ''' ------------------------------------------------------------------------------
    ''' <summary>
    '''     指定した年・月・日が正しい日付であるかどうかを返します。</summary>
    ''' <param name="iYear">
    '''     検査対象となる年。</param>
    ''' <param name="iMonth">
    '''     検査対象となる月。</param>
    ''' <param name="iDay">
    '''     検査対象となる日。</param>
    ''' <returns>
    '''     指定した年・月・日が正しい日付であれば True。それ以外は False。</returns>
    ''' ------------------------------------------------------------------------------
    Public Overloads Shared Function Check_YMD_Correct(ByVal iYear As Integer, ByVal iMonth As Integer, ByVal iDay As Integer) As Boolean
        If (DateTime.MinValue.Year > iYear) OrElse (iYear > DateTime.MaxValue.Year) Then
            Return False
        End If

        If (DateTime.MinValue.Month > iMonth) OrElse (iMonth > DateTime.MaxValue.Month) Then
            Return False
        End If

        Dim iLastDay As Integer = DateTime.DaysInMonth(iYear, iMonth)

        If (DateTime.MinValue.Day > iDay) OrElse (iDay > iLastDay) Then
            Return False
        End If

        Return True
    End Function
    ''' <summary>
    ''' 指定した年・月・日が正しい日付であるかどうかを返す。Nullの場合はtrueを返す
    ''' </summary>
    ''' <param name="ymd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function Check_YMD_Correct(ByVal ymd As strYMD) As Boolean
        If ymd.nullFlag = False Then
            Return Check_YMD_Correct(ymd.Year, ymd.Month, ymd.Day)
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' 開始時期と終了時期の重複等をチェック、事前に時期早い→遅いに並べておく必要
    ''' </summary>
    ''' <param name="n"></param>
    ''' <param name="Times"></param>
    ''' <param name="ERmessage">エラーメッセージ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Check_TimeSeries_Overlap(ByVal n As Integer, ByVal Times() As Start_End_Time_data, ByRef ERmessage As String) As Boolean


        Dim e1 As Boolean = False, e2 As Boolean = False, e3 As Boolean = False

        ERmessage = ""
        For i As Integer = 0 To n - 1
            If i <> 0 And Times(i).StartTime.nullFlag = True And e1 = False Then
                ERmessage = ERmessage & "開始時期が未設定にできるのは最初の時期だけです。" & vbCrLf
                e1 = True
            End If
            If i <> n - 1 And Times(i).EndTime.nullFlag = True And e2 = False Then
                ERmessage = ERmessage & "終了時期が未設定にできるのは最後の時期だけです。" & vbCrLf
                e2 = True
            End If
            If i >= 1 Then
                If clsTime.YMDtoValue(Times(i - 1).EndTime) >= clsTime.YMDtoValue(Times(i).StartTime) And e3 = False Then
                    ERmessage = ERmessage & "期間設定が重なっています。" & vbCrLf
                    e3 = True
                End If
            End If
        Next
        If e1 = False And e2 = False And e3 = False Then
            Return True
        Else
            Return False
        End If
    End Function



    Public Shared Function Check_Time_Of_Two_Lines(ByVal Lcode1 As Integer, ByVal Lcode2 As Integer, _
                                                   ByRef MapData As clsMapData) As Boolean
        '二つのラインの時間設定・線種が同じならtrueを返す

        Dim L1Time As clsMapData.Line_Time_Data
        Dim L2Time As clsMapData.Line_Time_Data

        Dim f As Boolean = False
        Dim l1n As Integer = MapData.MPLine(Lcode1).NumOfTime
        If l1n = MapData.MPLine(Lcode2).NumOfTime Then
            For i As Integer = 0 To l1n - 1
                L1Time = MapData.MPLine(Lcode1).LineTimeSTC(i)
                L2Time = MapData.MPLine(Lcode2).LineTimeSTC(i)
                If L1Time.Kind = L2Time.Kind And L1Time.SETime.Equals(L2Time.SETime) = True Then
                    f = True
                Else
                    f = False
                    Exit For
                End If
            Next
        End If
        Return f
    End Function
    ''' <summary>
    ''' '昨日を示すのstrYMD構造体を返す。nullの場合はnullを返す。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getYesterday(ByVal YMD As strYMD) As strYMD
        If YMD.nullFlag = False Then
            Dim d2 As DateTime = New System.DateTime(YMD.Year, YMD.Month, YMD.Day).AddDays(-1)
            Return GetYMD(d2)
        Else
            Return GetNullYMD()
        End If
    End Function
    ''' <summary>
    ''' '翌日を示すのstrYMD構造体を返す。nullの場合はnullを返す。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getTomorrow(ByVal YMD As strYMD) As strYMD
        If YMD.nullFlag = False Then
            Dim d2 As DateTime = New System.DateTime(YMD.Year, YMD.Month, YMD.Day).AddDays(1)
            Return GetYMD(d2)
        Else
            Return GetNullYMD()
        End If
    End Function
    ''' <summary>
    ''' '現在の日付が、指定の日付と1日違いの場合にtrueを返す。nullが含まれる場合はfalse
    ''' </summary>
    ''' <param name="Time1">指定の日付</param>
    ''' <param name="Time2">指定の日付</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function checkTwoTimesIsSeries(ByVal Time1 As strYMD, ByVal Time2 As strYMD) As Boolean

        If Time1.nullFlag = True Or Time2.nullFlag = True Then
            Return False
        Else
            Dim d2 As DateTime = New System.DateTime(Time1.Year, Time1.Month, Time1.Day).AddDays(-1)
            Dim d3 As DateTime = New System.DateTime(Time1.Year, Time1.Month, Time1.Day).AddDays(1)
            Dim d As Date = getDateTime(Time2)
            If d.Equals(d2) = True Or d.Equals(d3) = True Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    ''' <summary>
    ''' YMDをDateTime型に変換
    ''' </summary>
    ''' <param name="Time"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function YMDtoDateTime(ByVal Time As strYMD) As DateTime
        Return New System.DateTime(Time.Year, Time.Month, Time.Day)
    End Function
    ''' <summary>
    ''' 指定の日付の間の日数を数える。Time1がTime2より後の場合は負の値
    ''' </summary>
    ''' <param name="Time1"></param>
    ''' <param name="Time2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getDifference(ByVal Time1 As strYMD, ByVal Time2 As strYMD) As Integer
        Dim d1 As Date = YMDtoDateTime(Time1)
        Dim d2 As Date = YMDtoDateTime(Time2)
        Return DateDiff(DateInterval.Day, d1, d2)
    End Function

    ''' <summary>
    ''' 年月日をyyyy/mm/ddの文字列にして返す。nullの場合は「未設定」
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function YMDtoString(ByVal YMD As strYMD) As String
        If YMD.nullFlag = True Then
            Return "未設定"
        Else
            Dim d As Date = getDateTime(YMD)
            Return d.ToString("yyyy/MM/dd")
        End If
    End Function
    ''' <summary>
    ''' 年月日を文字列にして返す。nullの場合は「未設定」
    ''' </summary>
    ''' <param name="format">フォーマット文字列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function YMDtoString(ByVal YMD As strYMD, ByVal format As String) As String
        If YMD.nullFlag = True Then
            Return "未設定"
        Else
            Dim d As Date = getDateTime(YMD)
            Return d.ToString(format)
        End If
    End Function



    ''' <summary>
    ''' 'DateTime構造体として取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getDateTime(ByVal YMD As strYMD) As System.DateTime

        Return New System.DateTime(YMD.Year, YMD.Month, YMD.Day)
    End Function

    Public Shared Function StartEndtoString(ByVal StartEnd As Start_End_Time_data) As String
        Dim txs As String = ""

        If StartEnd.StartTime.nullFlag = True Then
            txs = "開始"
        End If
        txs += YMDtoString(StartEnd.StartTime) + "-"

        If StartEnd.EndTime.nullFlag = True Then
            txs += "終了"
        End If
        txs += YMDtoString(StartEnd.EndTime)
        Return txs

    End Function
    ''' <summary>
    ''' 年月日から作成する
    ''' </summary>
    ''' <param name="Year"></param>
    ''' <param name="Month"></param>
    ''' <param name="Day"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetYMD(ByVal Year As Short, ByVal Month As Byte, ByVal Day As Byte) As strYMD
        Dim YMD As strYMD
        YMD.Year = Year
        YMD.Month = Month
        YMD.Day = Day
        Return YMD
    End Function
    ''' <summary>
    ''' DateTime構造体から作成する
    ''' </summary>
    ''' <param name="DateTime"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetYMD(ByVal DateTime As System.DateTime) As strYMD
        Dim YMD As strYMD
        YMD.Year = DateTime.Year
        YMD.Month = DateTime.Month
        YMD.Day = DateTime.Day
        Return YMD
    End Function

    ''' <summary>
    ''' 古いMANDARAの時間変数から年月日に変換
    ''' </summary>
    ''' <param name="oldTimeValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetYMD(ByVal oldTimeValue As Integer) As strYMD
        Dim YMD As strYMD
        Dim Days_per_one_Month(13) As Integer
        Days_per_one_Month(1) = 31
        Days_per_one_Month(3) = 31
        Days_per_one_Month(4) = 30
        Days_per_one_Month(5) = 31
        Days_per_one_Month(6) = 30
        Days_per_one_Month(7) = 31
        Days_per_one_Month(8) = 31
        Days_per_one_Month(9) = 30
        Days_per_one_Month(10) = 31
        Days_per_one_Month(11) = 30
        Days_per_one_Month(12) = 31
        If oldTimeValue = -1 Then
            YMD.Year = 0
            YMD.Month = 0
            YMD.Day = 0
        Else
            YMD.Year = oldTimeValue \ 10000
            If System.DateTime.IsLeapYear(YMD.Year) = True Then
                Days_per_one_Month(2) = 29
                Days_per_one_Month(13) = 366
            Else
                Days_per_one_Month(2) = 28
                Days_per_one_Month(13) = 365
            End If

            Dim DD As Integer = oldTimeValue Mod 10000
            Dim i As Integer = 1
            Dim d2 As Integer = 0
            Do
                d2 += Days_per_one_Month(i)
                i += 1
            Loop While d2 < DD
            YMD.Month = i - 1
            YMD.Day = DD - (d2 - Days_per_one_Month(i - 1))
        End If
        Return YMD
    End Function

    ''' <summary>
    ''' yyyy/MM/ddまたはyyyy.MM.ddまたはyyyyMMddの文字から時期を設定
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetYMD(ByVal Value As String) As strYMD
        Dim YMD As strYMD
        If Value = "未設定" Or Value = "" Then
            YMD = clsTime.GetNullYMD
        Else
            Dim sp() As String
            If InStr(Value, "/") <> 0 Then
                sp = Split(Value, "/")
            ElseIf InStr(Value, ".") <> 0 Then
                sp = Split(Value, ".")
            Else
                ReDim sp(2)
                sp(0) = Mid(Value, 1, 4)
                sp(1) = Mid(Value, 5, 2)
                sp(2) = Mid(Value, 7, 2)
            End If
            For i As Integer = 0 To sp.Length - 1
                Select Case i
                    Case 0
                        YMD.Year = Val(sp(0))
                    Case 1
                        YMD.Month = Val(sp(1))
                    Case 2
                        YMD.Day = Val(sp(2))
                End Select
            Next

        End If
        Return YMD
    End Function
    ''' <summary>
    '''  toValue()で出した値を元に、時期を設定
    ''' </summary>
    ''' <param name="value">20131116のような年月日をそのまま数値にした値</param>
    ''' <remarks></remarks>
    Public Shared Function GetYMDfromValue(ByVal value As Integer) As strYMD
        Dim YMD As strYMD
        Dim s As String = Right("00000000" + value.ToString, 8)
        YMD.Year = Val(s.Substring(0, 4))
        YMD.Month = Val(s.Substring(4, 2))
        YMD.Day = Val(s.Substring(6, 2))
        Return YMD
    End Function
    ''' <summary>
    '''NullのYMDを作成する
    ''' </summary>
    ''' <param name="DateTime"></param>
    ''' <remarks></remarks>
    Public Shared Function GetNullYMD() As strYMD
        Dim YMD As strYMD
        YMD.Year = 0
        YMD.Month = 0
        YMD.Day = 0
        Return YMD
    End Function
    ''' <summary>
    ''' 20131116のような年月日をそのまま数値にした値を返す。nullValueの場合は0
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function YMDtoValue(ByVal YMD As strYMD) As Integer
        Return YMD.Day + YMD.Month * 100 + YMD.Year * 10000
    End Function
    ''' <summary>
    ''' Start_End_Time_dataを設定
    ''' </summary>
    ''' <param name="StartTime"></param>
    ''' <param name="EndTime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetStartEndYMD(ByVal StartTime As strYMD, ByVal EndTime As strYMD) As Start_End_Time_data
        Dim se As Start_End_Time_data
        se.StartTime = StartTime
        se.EndTime = EndTime
        Return se
    End Function

    ''' <summary>
    ''' 開始・終了時期設定nullにする
    ''' </summary>
    ''' <param name="StartTime"></param>
    ''' <param name="EndTime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetNullStartEndYMD() As Start_End_Time_data
        Dim se As Start_End_Time_data
        se.StartTime = GetNullYMD()
        se.EndTime = GetNullYMD()
        Return se
    End Function

    ''' <summary>
    ''' 開始終了文字列から自身の値を設定 yyyy/MM/dd-yyyy/MM/dd
    ''' </summary>
    ''' <param name="Value">文字列</param>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetStartEndYMD(ByVal SEValueSTR As String) As Start_End_Time_data
        Dim se As Start_End_Time_data
        Dim sp() As String = SEValueSTR.Split("-")
        If sp(0) = "開始未設定" Then
            se.StartTime = clsTime.GetNullYMD
        Else
            se.StartTime = clsTime.GetYMD(sp(0))
        End If
        If sp(1) = "終了未設定" Then
            se.EndTime = clsTime.GetNullYMD
        Else
            se.EndTime = clsTime.GetYMD(sp(1))
        End If
        Return se
    End Function
    ''' <summary>
    ''' セパレータ以降の文字を開始終了文字列に設定して値を設定
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <param name="Separater">セパレータ</param>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetStartEndYMD(ByVal Value As String, ByVal Separater As String) As Start_End_Time_data
        Dim se As Start_End_Time_data
        Dim n As Integer = Value.IndexOf(Separater) + 1
        se = GetStartEndYMD(Value.Substring(n))
        Return se
    End Function
    ''' <summary>
    ''' 開始時期が終了時期よりも早い場合はtrue、そうでない場合はfalse
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckStartEndTime(ByVal seTime As Start_End_Time_data) As Boolean
        If seTime.StartTime.nullFlag = True Or seTime.EndTime.nullFlag = True Then
            Return True
        Else
            If clsTime.YMDtoValue(seTime.StartTime) < clsTime.YMDtoValue(seTime.EndTime) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
End Class
