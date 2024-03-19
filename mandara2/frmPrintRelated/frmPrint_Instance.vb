Public Class frmPrint_Instance
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
    Public Overloads Function ShowDialog() As Windows.Forms.DialogResult
        Return Me.ShowDialog

    End Function
    Public Function GetResults()

    End Function
End Class