Public Class frmMED_ChangeAllObjectName
    Dim MapData As clsMapData
    Dim replace_Check As Boolean
    Dim OriginObjName As New List(Of clsMapData.Object_NameTimeStac_Data())
    Dim objectEnabled() As Boolean

    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef mpData As clsMapData, ByRef objectEnabledInfo() As Boolean) As Windows.Forms.DialogResult

        Me.Tag = "off"
        MapData = mpData
        objectEnabled = objectEnabledInfo
        OriginObjName = mpData.Get_All_ObjectName()

        ResetGrdid(10)
        ProgressBar.Visible = False
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

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        clsGeneric.Set_ClipIdoKedo_to_KtgisGrid(ktGrid)
    End Sub
    Private Sub ResetGrdid(ByVal Rows As Integer)
        With ktGrid
            .init("データ", "行", "列", 1, 0, 1, 0, True, True, True, True, False, True, False, False, False, False)
            .AddLayer("", 0, 2, Rows)
            .FixedYSData(0, 0, 0) = "現在のオブジェクト名"
            .FixedYSData(0, 1, 0) = "新しいオブジェクト名"
            .GridWidth(0, 0) = (.Width - .FixedXSWidth(0, 0)) / 2 - 10
            .GridWidth(0, 1) = (.Width - .FixedXSWidth(0, 0)) / 2 - 10
            .GridAlligntment(0, 0) = HorizontalAlignment.Left
            .GridAlligntment(0, 1) = HorizontalAlignment.Left
            .Show()
        End With
    End Sub

    Private Sub ktGrid_Change_Data() Handles ktGrid.Change_Data

    End Sub

    Private Sub btmCheck_Click(sender As Object, e As EventArgs) Handles btmCheck.Click

        Dim OName(,) As String = ktGrid.GridData(0)
        Dim ONameExist() As Boolean
        Dim n As Integer = OName.GetLength(1)
        ReDim ONameExist(n - 1)
        For i As Integer = 0 To MapData.Map.Kend - 1
            If objectEnabled(i) = True Or cbEditingObject.Checked = False Then
                With MapData.MPObj(i)
                    For j As Integer = 0 To .NumOfNameTime - 1
                        With .NameTimeSTC(j)
                            For k As Integer = 0 To n - 1
                                If OName(0, k) <> "" Then
                                    If Array.IndexOf(.NamesList, k) <> -1 Then
                                        ONameExist(k) = True
                                    End If
                                End If
                            Next
                        End With
                    Next
                End With
            End If
        Next
        Dim NoMatchList As List(Of Integer) = clsGeneric.Get_Specified_Value_Array(ONameExist, n, False)
        Dim mes As String
        If NoMatchList.Count = 0 Then
            MsgBox("対応する現オブジェクト名がありません。")
        ElseIf NoMatchList.Count = n Then
            MsgBox("すべて変換可能です。")
        Else
            mes = "以下は一致する現オブジェクト名が見つかりません。" + vbCrLf
            For Each i As Integer In NoMatchList
                mes += (i + 1).ToString + ":" + OName(0, i) + vbCrLf
            Next
            clsGeneric.Message(Me, "オブジェクト名一括変換チェック", mes, True, True)
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim OName(,) As String = ktGrid.GridData(0)
        Dim ONameExist() As Boolean
        Dim n As Integer = OName.GetLength(1)
        ReDim ONameExist(n - 1)
        ProgressBar.Visible = True
        ProgressBar.Maximum = MapData.Map.Kend
        Me.Cursor = Cursors.WaitCursor
        For i As Integer = 0 To MapData.Map.Kend - 1
            If i Mod 20 = 0 Then
                ProgressBar.Value = i
            End If
            If objectEnabled(i) = True Or cbEditingObject.Checked = False Then
                With MapData.MPObj(i)
                    For j As Integer = 0 To .NumOfNameTime - 1
                        With .NameTimeSTC(j)
                            For k As Integer = 0 To n - 1
                                If OName(0, k) <> "" Then
                                    Dim ip As Integer = Array.IndexOf(.NamesList, OName(0, k))
                                    If ip <> -1 Then
                                        .NamesList(ip) = OName(1, k)
                                        ONameExist(k) = True
                                    End If
                                End If
                            Next
                        End With
                    Next
                End With
            End If
        Next
        Dim NoMatchList As List(Of Integer) = clsGeneric.Get_Specified_Value_Array(ONameExist, n, False)
        Me.Cursor = Cursors.Default
        ProgressBar.Visible = False

        Dim mes As String
        If NoMatchList.Count = 0 Then
            MsgBox("すべて変換しました。")
            replace_Check = True
        ElseIf NoMatchList.Count = n Then
            MsgBox("対応する現オブジェクト名がありませんでした。", MsgBoxStyle.Exclamation)
            replace_Check = False
        Else
            mes = "以下は対応する現オブジェクト名が見つかりませんでした。" + vbCrLf
            For Each i As Integer In NoMatchList
                mes += (i + 1).ToString + ":" + OName(0, i) + vbCrLf
            Next
            clsGeneric.Message(Me, "オブジェクト名一括変換チェック", mes, True, True)
            replace_Check = True
        End If

    End Sub

    Private Sub frmMED_ChangeAllObjectName_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ChangeAllObjectName", Me)
        e.Cancel = True
    End Sub

End Class