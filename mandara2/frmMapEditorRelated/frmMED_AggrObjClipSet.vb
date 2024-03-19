Public Class frmMED_AggrObjClipSet
    Dim CloseCancelF As Boolean
    Dim MapData As clsMapData

    Private Structure Conv_Info
        Public OName As String
        Public AggrName As String
        Public AggrNumber As Integer
    End Structure
    Private Structure AggrObj_Info
        Public Name As String
        Public subObjNum As Integer
        Public SubObj() As Integer
    End Structure
    Dim ConvertAggr() As Conv_Info
    Dim ConvNum As Integer
    Dim AggrObj() As AggrObj_Info
    Dim AggrObjNum As Integer
    Dim AddObj() As Integer

    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef mpData As clsMapData) As Windows.Forms.DialogResult

        MapData = mpData

        Dim aggrObjName() As String = MapData.Get_ObjectGroupNameList(clsMapData.enmObjectGoupType_Data.AggregationObject)
        With cboObjectKind
            .Items.Clear()
            .Items.AddRange(aggrObjName)
            .SelectedIndex = 0
        End With
        ResetGrdid(10)
        Return Me.ShowDialog(Owner)
    End Function
    Private Sub ResetGrdid(ByVal Rows As Integer)
        With ktGrid
            .init("データ", "行", "列", 1, 0, 1, 0, True, True, True, True, False, True, False, False, False, False)
            .AddLayer("", 0, 2, Rows)
            .FixedYSData(0, 0, 0) = "元オブジェクト"
            .FixedYSData(0, 1, 0) = "集成オブジェクト"
            .GridWidth(0, 0) = (.Width - .FixedXSWidth(0, 0)) / 2 - 10
            .GridWidth(0, 1) = (.Width - .FixedXSWidth(0, 0)) / 2 - 10
            .GridAlligntment(0, 0) = HorizontalAlignment.Left
            .GridAlligntment(0, 1) = HorizontalAlignment.Left
            .Show()
        End With
    End Sub
    Public Function getResult() As Integer()

        Return AddObj
    End Function
    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        clsGeneric.Set_ClipIdoKedo_to_KtgisGrid(ktGrid)
    End Sub

    Private Sub btmCheck_Click(sender As Object, e As EventArgs) Handles btmCheck.Click
        If CheckData() = True Then
            MsgBox("設定可能です。")
        End If
    End Sub
    Private Function CheckData() As Boolean

        Dim SetKind As Integer = MapData.Get_ObjectGroupPosition_by_Type(cboObjectKind.SelectedIndex, clsMapData.enmObjectGoupType_Data.AggregationObject)
        Dim ST(,) As String = ktGrid.GridData(0)

        Dim n As Integer = ktGrid.Ysize(0)
        If n = 0 Then
            MsgBox("データがありません。", MsgBoxStyle.Exclamation)
            Return False
        End If

        Dim Gken(MapData.Map.Kend - 1) As Boolean
        Dim Msg As String = ""
        ReDim ConvertAggr(n - 1)
        ReDim AggrObj(n - 1)
        AggrObjNum = 0
        For i As Integer = 0 To n - 1
            Dim hdmes As String = (i + 1).ToString + ":"
            With ConvertAggr(i)
                .OName = ST(0, i)
                .AggrName = ST(1, i)
                .AggrNumber = -1
                If .AggrName = "" Then
                    Msg += hdmes + "集成オブジェクト設定なし" + vbCrLf
                Else
                    Dim Ocode() As Integer
                    Dim Get_N As Integer = MapData.Check_ObjectName_OverLap_In_MapFile_NoTime(-1, .OName, Ocode)
                    If Get_N = -1 Then
                        Msg += hdmes + "【" + .OName + "】" + "元オブジェクト該当無し" + vbCrLf
                    Else
                        Dim n2 As Integer = 0
                        Dim n3 As Integer = 0
                        For j As Integer = 0 To Get_N - 1
                            If MapData.ObjectKind(SetKind).UseObjectGroup(MapData.MPObj(Ocode(j)).Kind) = False Then
                                Ocode(j) = -1
                                n2 += 1
                            ElseIf Gken(Ocode(j)) = True Then
                                Ocode(j) = -1
                                n3 += 1
                            End If
                        Next
                        If n2 + n3 = Get_N Then
                            If n2 <> 0 Then
                                Msg += hdmes + "【" + .OName + "】" + "元グループが要素外" + vbCrLf
                            ElseIf n3 <> 0 Then
                                Msg += hdmes + "【" + .OName + "】" + "元オブジェクトが既にリストにあり" + vbCrLf
                            End If
                        Else
                            Dim k As Integer = AggrObjNum
                            For j As Integer = 0 To AggrObjNum - 1
                                If AggrObj(j).Name = .AggrName Then
                                    k = j
                                    Exit For
                                End If
                            Next
                            If k = AggrObjNum Then
                                If MapData.Check_ObjectName_OverLap_In_MapFile(-1, .AggrName, clsTime.GetStartEndYMD(clsTime.GetNullYMD, clsTime.GetNullYMD)) = -1 Then
                                    AggrObj(k).Name = .AggrName
                                    ReDim AggrObj(k).SubObj(Get_N - 1)
                                    Dim n4 As Integer = 0
                                    For j As Integer = 0 To Get_N - 1
                                        If Ocode(j) <> -1 Then
                                            AggrObj(k).SubObj(n4) = Ocode(j)
                                            Gken(Ocode(j)) = True
                                            n4 += 1
                                        End If
                                    Next
                                    AggrObj(k).subObjNum = n4
                                    AggrObjNum = AggrObjNum + 1
                                    .AggrNumber = k
                                Else
                                    Msg += hdmes + "【" + .OName + "】" + "集成オブジェクト名が重複" + vbCrLf
                                End If
                            Else
                                Dim n4 As Integer = AggrObj(k).subObjNum
                                ReDim Preserve AggrObj(k).SubObj(n4 + Get_N - 1)
                                For j As Integer = 0 To Get_N - 1
                                    If Ocode(j) <> -1 Then
                                        AggrObj(k).SubObj(n4) = Ocode(j)
                                        Gken(Ocode(j)) = True
                                        n4 += 1
                                    End If
                                Next
                                AggrObj(k).subObjNum = n4
                                .AggrNumber = k
                                'OK
                            End If
                        End If
                    End If
                End If
            End With
        Next
        If Msg <> "" Then
            clsGeneric.Message(Me, "データに問題があります", Msg, True, True)
            Return False
        Else
            Return True
        End If
    End Function


    Private Sub frmMED_AggrObjClipSet_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If CheckData() = False Then
            CloseCancelF = True
            Exit Sub
        End If

        Dim SetKind As Integer = MapData.Get_ObjectGroupPosition_by_Type(cboObjectKind.SelectedIndex, clsMapData.enmObjectGoupType_Data.AggregationObject)


        ReDim AddObj(AggrObjNum - 1)
        For i As Integer = 0 To AggrObjNum - 1
            Dim PushObj As clsMapData.strObj_Data = MapData.Init_One_Object(SetKind)
            With PushObj
                .Kind = SetKind
                .Shape = MapData.ObjectKind(SetKind).Shape
                .NumOfLine = AggrObj(i).subObjNum
                ReDim .LineCodeSTC(.NumOfLine - 1)
                Dim cx As Single = 0
                Dim cy As Single = 0
                For j As Integer = 0 To .NumOfLine - 1
                    With .LineCodeSTC(j)
                        .LineCode = AggrObj(i).SubObj(j)
                        .NumOfTime = 0
                    End With
                    With MapData.MPObj(AggrObj(i).SubObj(j)).CenterPSTC(0).Position
                        cx += .X
                        cy += .Y
                    End With
                Next
                .CenterPSTC(0).Position.X = cx / .NumOfLine
                .CenterPSTC(0).Position.Y = cy / .NumOfLine
                .NameTimeSTC(0).NamesList(0) = AggrObj(i).Name
            End With
            MapData.Save_Object(PushObj, True)
            AddObj(i) = PushObj.Number
        Next
        MsgBox(AggrObjNum & "個の集成オブジェクトを作成しました。")
    End Sub

    Private Sub frmMED_AggrObjClipSet_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_AggrObjClipSet", Me)
        e.Cancel = True
    End Sub
End Class