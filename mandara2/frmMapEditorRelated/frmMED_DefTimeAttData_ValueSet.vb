Public Class frmMED_DefTimeAttData_ValueSet
    Private Structure Kdata_Info
        Public ObjCode As Integer
        Public Span As Start_End_Time_data
        Public Value As String
    End Structure
    Dim CloseCancelF As Boolean
    Dim defPointAttData As clsMapData.strMPObjDefTimeAttData_Info
    Dim DataType As enmAttDataType
    Dim TimeAttDataType As clsMapData.enmDefTimeAttDataType
    Dim ObjNameSearch As clsObjectNameSearch
    Dim ObjectGroupN As Integer
    Dim MapData As clsMapData
    Dim kdata() As Kdata_Info
    Dim defPointAttData_n As Integer
    Dim Time As strYMD
    Private Sub frmMED_DefPointAttData_ValueSet_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef _MapData As clsMapData, ByVal _ObjectGroupN As Integer,
                                         ByVal _defPointAttData_n As Integer, ByVal _defPointAttData As clsMapData.strMPObjDefTimeAttData_Info,
                                         ByVal _time As strYMD) As Windows.Forms.DialogResult
        defPointAttData = _defPointAttData
        ObjectGroupN = _ObjectGroupN
        MapData = _MapData
        Time = _time
        defPointAttData_n = _defPointAttData_n
        lblObjectGroup.Text = "オブジェクトグループ:" + _MapData.ObjectKind(ObjectGroupN).Name
        lblType.Text = clsGeneric.getDefTimeAttrDataTypeStrings(_defPointAttData.Type)
        lblTime.Text = "オブジェクト名の検索時期：" + clsTime.YMDtoString(Time)
        TimeAttDataType = _defPointAttData.Type
        With _defPointAttData.attData
            lblTitle.Text = "タイトル:" + .Title
            lblUnit.Text = "単位:" + .Unit
            If .MissingF = True Then
                lblMissing.Text = "空白は欠損値"
            Else
                lblMissing.Text = "空白は0"
            End If
            DataType = clsGeneric.getAttDataType_From_TitleUnit(.Title, .Unit)
        End With
        ObjNameSearch = New clsObjectNameSearch(MapData, False)
        ResetGrdid(10)
        Return Me.ShowDialog(Owner)
    End Function
    Public Sub getResults(ByRef defObj() As frmMED_DefTimeAttData.MpObjTimeDef_info)
        Dim change_Obj(MapData.Map.Kend - 1) As Boolean
        For i As Integer = 0 To kdata.Length - 1
            With kdata(i)
                Dim n As Integer = -1
                Dim datavaln As Integer
                If defObj(.ObjCode).DefTimeAttValue(defPointAttData_n).Data Is Nothing Then
                    n = 0
                    ReDim defObj(.ObjCode).DefTimeAttValue(defPointAttData_n).Data(0)
                Else
                    datavaln = defObj(.ObjCode).DefTimeAttValue(defPointAttData_n).Data.Length
                    For j As Integer = 0 To datavaln - 1
                        Dim spn As Start_End_Time_data = defObj(.ObjCode).DefTimeAttValue(defPointAttData_n).Data(j).Span
                        Dim Value As String = defObj(.ObjCode).DefTimeAttValue(defPointAttData_n).Data(j).Value
                        If .Span.Equals(spn) = True Or ((Value = .Value Or Value = "") And spn.StartTime.nullFlag = True And spn.EndTime.nullFlag = True) Then
                            '同じ時期・期間設定のデータ値があった場合は、上書きする
                            n = j
                            Exit For
                        Else
                            If TimeAttDataType = clsMapData.enmDefTimeAttDataType.SpanData Then
                                If clsTime.checkDurationOverlapped(.Span, spn) = True Then
                                    '期間未設定のデータ値があり、追加分に設定があった場合、既存のデータ値の期間を修正
                                    If spn.EndTime.nullFlag = True And .Span.StartTime.nullFlag = False Then
                                        If (spn.StartTime.Equals(.Span.StartTime)) Then
                                            '起点が同じ場合は終点を変更して上書き
                                            spn.EndTime = .Span.StartTime
                                            n = j
                                            Exit For
                                        Else
                                            spn.EndTime = clsTime.getYesterday(.Span.StartTime)
                                        End If
                                    End If
                                    If spn.StartTime.nullFlag = True And .Span.EndTime.nullFlag = False Then
                                        spn.StartTime = clsTime.getTomorrow(.Span.StartTime)
                                    End If
                                    defObj(.ObjCode).DefTimeAttValue(defPointAttData_n).Data(j).Span = spn
                                End If
                            End If
                        End If
                    Next
                End If
                If n = -1 Then
                    n = datavaln
                    ReDim Preserve defObj(.ObjCode).DefTimeAttValue(defPointAttData_n).Data(n)
                End If
                defObj(.ObjCode).DefTimeAttValue(defPointAttData_n).Data(n).Value = .Value
                defObj(.ObjCode).DefTimeAttValue(defPointAttData_n).Data(n).Span = .Span
                change_Obj(.ObjCode) = True
            End With
        Next
        For i As Integer = 0 To MapData.Map.Kend - 1
            If change_Obj(i) = True Then
                clsGeneric.Sort_strDefPointAttDataEach_Info(defObj(i).DefTimeAttValue(defPointAttData_n).Data)
            End If
        Next
    End Sub

    Private Sub ResetGrdid(ByVal Rows As Integer)
        With ktGrid
            .init("データ", "行", "列", 1, 0, 1, 0, True, True, True, True, False, True, False, False, False, False)

            Dim align As HorizontalAlignment
            If DataType = enmAttDataType.Normal Then
                align = HorizontalAlignment.Right
            Else
                align = HorizontalAlignment.Left
            End If
            Select Case TimeAttDataType
                Case clsMapData.enmDefTimeAttDataType.PointData
                    .AddLayer("", 0, 3, Rows)
                    .FixedYSData(0, 0, 0) = "オブジェクト名"
                    .FixedYSData(0, 1, 0) = "時期"
                    .FixedYSData(0, 2, 0) = "値"
                    .GridWidth(0, 0) = 125
                    .GridWidth(0, 1) = (.Width - .FixedXSWidth(0, 0) - .GridWidth(0, 0)) / 2 - 10
                    .GridWidth(0, 2) = .GridWidth(0, 1)
                    .GridAlligntment(0, 2) = align
                Case clsMapData.enmDefTimeAttDataType.SpanData
                    .AddLayer("", 0, 4, Rows)
                    .FixedYSData(0, 0, 0) = "オブジェクト名"
                    .FixedYSData(0, 1, 0) = "開始時期"
                    .FixedYSData(0, 2, 0) = "終了時期"
                    .FixedYSData(0, 3, 0) = "値"
                    .GridWidth(0, 0) = 125
                    .GridWidth(0, 1) = (.Width - .FixedXSWidth(0, 0) - .GridWidth(0, 0)) / 3 - 10
                    .GridWidth(0, 2) = .GridWidth(0, 1)
                    .GridWidth(0, 3) = .GridWidth(0, 1)
                    .GridAlligntment(0, 2) = HorizontalAlignment.Right
                    .GridAlligntment(0, 3) = align
            End Select
            .GridAlligntment(0, 0) = HorizontalAlignment.Left
            .GridAlligntment(0, 1) = HorizontalAlignment.Right
            .Show()
        End With
    End Sub

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        If clsGeneric.Set_ClipIdoKedo_to_KtgisGrid(ktGrid) = True Then
            CheckData()
        End If
    End Sub

    Private Sub btmCheck_Click(sender As Object, e As EventArgs) Handles btmCheck.Click
        If CheckData() = True Then
            MsgBox("設定可能です。")
        End If
    End Sub
    Private Function CheckData() As Boolean


        Dim n As Integer = ktGrid.Ysize(0)
        If n = 0 Then
            MsgBox("データがありません。", MsgBoxStyle.Exclamation)
            Return False
        End If

        ReDim kdata(n - 1)
        Dim Msg As String = ""
        For i As Integer = 0 To n - 1
            Dim hdmes As String = (i + 1).ToString + ":"
            ktGrid.GridColor(0, 0, i) = ktGrid.GridColor
            ktGrid.GridColor(0, 1, i) = ktGrid.GridColor
            With kdata(i)
                Dim oname As String = ktGrid.GridData(0, 0, i)
                Dim ef As Boolean = False
                Dim lpn As Integer = 0
                Select Case TimeAttDataType
                    Case clsMapData.enmDefTimeAttDataType.PointData
                        .Value = ktGrid.GridData(0, 2, i)
                        lpn = 1
                    Case clsMapData.enmDefTimeAttDataType.SpanData
                        .Value = ktGrid.GridData(0, 3, i)
                        lpn = 2
                End Select
                Dim gtime As strYMD
                For j As Integer = 0 To lpn - 1
                    Dim TiM As String = ktGrid.GridData(0, 1 + j, i)
                    If Len(TiM) < 8 And TimeAttDataType = clsMapData.enmDefTimeAttDataType.PointData Then
                        Msg += "【" + oname + "】" + TiM + "時期が不正です。" + vbCrLf
                        ktGrid.GridColor(0, 1 + j, i) = Color.Yellow
                        ef = True
                    Else
                        gtime = clsTime.GetYMD(TiM)
                        If clsTime.Check_YMD_Correct(gtime) = False Then
                            ktGrid.GridColor(0, 1 + j, i) = Color.Yellow
                            Msg += "【" + oname + "】" + TiM + "時期が不正です。" + vbCrLf
                            ef = True
                        End If
                        If j = 0 Then
                            .Span.StartTime = gtime
                        Else
                            .Span.EndTime = gtime
                        End If
                    End If
                Next

                If ef = False Then
                    Dim Obj() As Integer
                    Dim objn As Integer = ObjNameSearch.Get_KenToCode(oname, Time, Obj)
                    Dim cor_obj As New List(Of Integer)
                    For j As Integer = 0 To objn - 1
                        If MapData.MPObj(Obj(j)).Kind = ObjectGroupN Then
                            cor_obj.Add(Obj(j))
                        End If
                    Next
                    If objn = 0 Then
                        Msg += "【" + oname + "】オブジェクト名がみつかりません。" + vbCrLf
                        ktGrid.GridColor(0, 0, i) = Color.Yellow
                    Else
                        Select Case cor_obj.Count
                            Case 0
                                Msg += "【" + oname + "】オブジェクトグループが異なります。" + vbCrLf
                                ktGrid.GridColor(0, 0, i) = Color.Yellow
                            Case 1
                                .ObjCode = cor_obj(0)
                            Case Else
                                Msg += "【" + oname + "】オブジェクト名に複数候補があります。"
                                If Time.nullFlag = True Then
                                    Msg = "時期を限定して下さい。"
                                End If
                                Msg += vbCrLf
                                ktGrid.GridColor(0, 0, i) = Color.Yellow
                        End Select
                    End If
                End If
            End With
        Next
        If Msg <> "" Then
            ktGrid.Refresh()
            clsGeneric.Message(Me, "データに問題があります", Msg, True, False)
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If CheckData() = False Then
            CloseCancelF = True
        End If

    End Sub

    Private Sub frmMED_DefTimeAttData_ValueSet_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_DefTimeAttData_ValueSet", Me)
        e.Cancel = True
    End Sub

    
End Class