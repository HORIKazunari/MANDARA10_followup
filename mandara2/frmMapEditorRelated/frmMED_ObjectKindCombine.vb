Public Class frmMED_ObjectKindCombine
    Dim MapData As clsMapData
    Dim CloseCancelF As Boolean = False
    Private Sub frmMED_ObjectKindCombine_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Public Overloads Function ShowDialog(ByRef mpData As clsMapData) As Windows.Forms.DialogResult

        MapData = mpData
        clbBase.Items.Clear()
        clbBase.Items.AddRange(MapData.Get_ObjectGroupNameList)
        Return Me.ShowDialog()
    End Function

    Public Function getResult(ByRef ObjectKindName As String) As Boolean()
        Dim Combinef(MapData.Map.OBKNum - 1) As Boolean
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            Combinef(i) = clbBase.GetItemChecked(i)
        Next
        ObjectKindName = txtName.Text
        Return Combinef
    End Function

    Private Sub clbBase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbBase.SelectedIndexChanged
        Static Count As Boolean = False
        Dim i As Integer = clbBase.SelectedIndex
        If MapData.ObjectKind(i).Mesh <> enmMesh_Number.mhNonMesh And clbBase.GetItemChecked(i) = True Then
            MsgBox("メッシュのオブジェクトグループは結合できません。", vbExclamation)
            clbBase.SetItemChecked(i, False)
            Exit Sub
        End If
        If Count = False And txtName.Text = "" Then
            txtName.Text = clbBase.Items(i)
            Count = True
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If txtName.Text = "" Then
            MsgBox("統合後の名称を設定してください。", vbExclamation)
            CloseCancelF = True
            Exit Sub
        End If

        If clbBase.CheckedItems.Count <= 1 Then
            MsgBox("二つ以上選択してください。", vbExclamation)
            CloseCancelF = True
            Exit Sub
        End If

        Dim Combinef(MapData.Map.OBKNum - 1) As Boolean
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            Combinef(i) = clbBase.GetItemChecked(i)
        Next
        Dim ErrMes As String = ""
        If MapData.Check_Selected_ObjectGroup_Same(Combinef, ErrMes, True, True) = False Then
            MsgBox(ErrMes, vbExclamation)
            CloseCancelF = True
            Exit Sub
        End If

        Dim mes As String = clbBase.CheckedItems.Count & "つを統合します。"
        If MsgBox(mes, vbYesNo) = vbNo Then
            CloseCancelF = True
            Exit Sub
        End If
    End Sub

    Private Sub frmMED_ObjectKindCombine_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ObjectKindCombine", Me)
        e.Cancel = True
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class