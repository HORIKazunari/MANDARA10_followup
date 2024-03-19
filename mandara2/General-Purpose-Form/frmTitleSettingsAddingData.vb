Public Class frmTitleSettingsAddingData

    Dim CloseCancelF As Boolean
    Private Sub frmFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Public Overloads Function ShowDialog(ByVal TTL As String, ByVal UNT As String, ByVal Note As String, ByVal CancefFlag As Boolean, Optional ByVal LabelStr As String = "") As Windows.Forms.DialogResult
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        If CancefFlag = False Then
            btnCancel.Visible = False
            btnCancel.Enabled = False
            Me.ControlBox = False
            btnOK.Left = btnCancel.Left
        End If
        lblLabel.Text = LabelStr
        txtTitle.Text = TTL
        txtUnit.Text = UNT
        If UCase(UNT) = "CAT" Or UCase(UNT) = "STR" Then
            txtUnit.Enabled = False
        End If
        txtNote.Text = Note

        Return Me.ShowDialog(Owner)
    End Function
    Public Sub getResult(ByRef TTL As String, ByRef UNT As String, ByRef Note As String)
        TTL = txtTitle.Text
        UNT = txtUnit.Text
        Note = txtNote.Text
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If txtTitle.Text = "" Then
            MsgBox("タイトルを設定してください。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
    End Sub
End Class