Public Class frmMED_ReplaceObjectName
    Private Structure rep_obj_data
        Public code As Integer
        Public name_num As Integer
        Public nameStac As Integer
    End Structure
    Dim Rep_Obj() As rep_obj_data
    Dim s_tx As String

    Dim MapData As clsMapData
    Dim OriginObjName As New List(Of clsMapData.Object_NameTimeStac_Data())
    Dim replace_Check As Boolean
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef mpData As clsMapData) As Windows.Forms.DialogResult

        Me.Tag = "off"
        MapData = mpData
        OriginObjName = mpData.Get_All_ObjectName()

        With clbObjectKind
            .BeginUpdate()
            .EventStop = True
            .Items.Clear()
            For i As Integer = 0 To MapData.Map.OBKNum - 1
                .Items.Add(MapData.ObjectKind(i).Name, True)
            Next
            .EndUpdate()
            .EventStop = False
        End With
        replace_Check = False
        Me.Tag = "on"
        Return Me.ShowDialog(Owner)
    End Function
    ''' <summary>
    ''' 置換が行われたかどうかの結果
    ''' </summary>
    ''' <param name="UndoObjName">置換が行われた場合、変換前のオブジェクト名のObject_Names_Dataの入った配列の入ったArrayListを返す</param>
    ''' <returns>置換が行われた場合Trueを返す</returns>
    ''' <remarks></remarks>
    Public Function getResult(ByRef UndoObjName As List(Of clsMapData.Object_NameTimeStac_Data())) As Boolean
        If replace_Check = True Then
            UndoObjName = OriginObjName
        End If
        Return replace_Check
    End Function

    Private Sub btnReplace_Click(sender As Object, e As EventArgs) Handles btnReplace.Click
        Dim n As Integer = lbList.Items.Count
        If n = 0 Then
            return
        End If
        If lbList.SelectedItems.Count = 0 Then
            MsgBox("置換するオブジェクト名を選択してください。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim Rep_Word As String = txtReplaceStrings.Text
        For i As Integer = 0 To n - 1
            If lbList.GetSelected(i) = True Then
                With Rep_Obj(i)
                    With MapData.MPObj(.code).NameTimeSTC(.name_num)
                        .NamesList(Rep_Obj(i).nameStac) = Replace(.NamesList(Rep_Obj(i).nameStac), s_tx, Rep_Word)
                    End With
                End With
            End If
        Next
        replace_Check = True
        MsgBox("選択したオブジェクト名を置換しました。")
        btnSearch.PerformClick()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim S_ObjectGroup() As Boolean


        ReDim S_ObjectGroup(MapData.Map.OBKNum)
        ReDim Rep_Obj(MapData.Map.Kend)

        s_tx = txtSearchStrings.Text
        If s_tx = "" Then
            MsgBox("検索文字列を入力してください。", MsgBoxStyle.Exclamation)
        End If

        For i As Integer = 0 To MapData.Map.OBKNum - 1
            S_ObjectGroup(i) = clbObjectKind.GetItemChecked(i)
        Next
        lbList.Items.Clear()
        Dim n As Integer = 0
        For i As Integer = 0 To MapData.Map.Kend - 1
            If S_ObjectGroup(MapData.MPObj(i).Kind) = True Then
                With MapData.MPObj(i)
                    For j As Integer = 0 To .NumOfNameTime - 1
                        With .NameTimeSTC(j)
                            For k As Integer = 0 To .NamesList.Length - 1
                                If InStr(.NamesList(k), s_tx) <> 0 Then
                                    lbList.Items.Add(.NamesList(k))
                                    With Rep_Obj(n)
                                        .code = i
                                        .name_num = j
                                        .nameStac = k
                                    End With
                                    n += 1
                                End If
                            Next
                        End With
                    Next
                End With
            End If
        Next
        ReDim Preserve Rep_Obj(n)
    End Sub

    Private Sub btnReplaceAll_Click(sender As Object, e As EventArgs) Handles btnReplaceAll.Click



        Dim n As Integer = lbList.Items.Count
        If n = 0 Then
            Return
        End If
        Dim Rep_Word As String = txtReplaceStrings.Text
        For i As Integer = 0 To n - 1
            With Rep_Obj(i)
                With MapData.MPObj(.code).NameTimeSTC(.name_num)
                    .NamesList(Rep_Obj(i).nameStac) = Replace(.NamesList(Rep_Obj(i).nameStac), s_tx, Rep_Word)
                End With
            End With
        Next
        replace_Check = True
        MsgBox("すべての文字を置換しました。")
        lbList.Items.Clear()
    End Sub

    Private Sub frmMED_ReplaceObjectName_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ReplaceObjectName", Me)
        e.Cancel = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub
End Class