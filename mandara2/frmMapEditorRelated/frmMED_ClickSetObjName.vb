Public Class frmMED_ClickSetObjName
    Public Shared newObjName As List(Of String())
    Public Shared ChangeObjNameFlag As Boolean = False
    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        Dim clipText As String = Clipboard.GetText
        If clipText = "" Then
            Dim msgText1 As String = "クリップボードにデータがありません。"
            MsgBox(msgText1, MsgBoxStyle.Exclamation)
            Return
        End If

        If Microsoft.VisualBasic.Right(clipText, 2) = vbCrLf Then
            clipText = Mid(clipText, 1, Len(clipText) - 2)
        End If
        Dim STR() As String = Split(clipText, vbCrLf)
        newObjName = New List(Of String())


        For i As Integer = 0 To STR.Length - 1
            Dim sp() As String = Split(STR(i), vbTab)
            Dim name As New List(Of String)
            For j As Integer = 0 To sp.Length - 1
                If sp(j) <> "" Then
                    name.Add(sp(j))
                End If
            Next
            newObjName.Add(name.ToArray)
        Next

        lbObjName.Items.Clear()
        For i As Integer = 0 To STR.GetLength(0) - 1
            lbObjName.Items.Add(Join(newObjName(i), "/"))
        Next
        lbObjName.SelectedIndex = 0
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmMED_ClickSetObjName_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ClickSetObjName", Me)
        e.Cancel = True
    End Sub
End Class