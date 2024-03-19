Public Class frmPrint_SizeChange
    Dim CloseCancelF As Boolean
    Dim Old_Value As Integer
    Dim First_M As Integer
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
    Public Overloads Function ShowDialog(ByVal PresentSize As Size) As Windows.Forms.DialogResult
        txtWidth.Text = PresentSize.Width
        txtHeight.Text = PresentSize.Height
        First_M = PresentSize.Width * PresentSize.Height
        Return Me.ShowDialog

    End Function
    Public Sub GetResults(ByRef newSize As Size, ByRef position As Integer)
        Dim yoko As Integer = Val(txtWidth.Text)
        Dim tate As Integer = Val(txtHeight.Text)
        newSize = New Size(yoko, tate)
        Select Case True
            Case rbPositionnoChange.Checked
                position = 0
            Case rbPositionCenter.Checked
                position = 1
            Case rbPosition00.Checked
                position = 2
        End Select
    End Sub

    Private Sub txtWidth_Enter(sender As Object, e As EventArgs) Handles txtWidth.Enter, txtWidth.Enter
        Old_Value = Val(sender.Text)

    End Sub

    Private Sub txtWidth_Leave(sender As Object, e As EventArgs) Handles txtWidth.Leave, txtHeight.Leave
        Dim tx As TextBox = CType(sender, TextBox)
        Dim v As Integer = Val(tx.Text)
        tx.Text = v
        If v <> Old_Value And chkAspectRation.Checked = True Then
            Select Case tx.Name
                Case "txtWidth"
                    Dim ov2 As Integer = Val(txtHeight.Text)
                    Dim r As Single = ov2 / Old_Value
                    Dim V2 As Integer = r * v
                    txtHeight.Text = V2
                Case "txtHeight"
                    Dim ov2 As Integer = Val(txtWidth.Text)
                    Dim r As Single = ov2 / Old_Value
                    Dim V2 As Integer = r * v
                    txtWidth.Text = V2
            End Select

        End If
    End Sub

    Private Sub btnHorizontal_Click(sender As Object, e As EventArgs) Handles btnHorizontal.Click, btnVartical.Click
        Dim btn As Button = CType(sender, Button)
        Dim yoko As Integer = Val(txtWidth.Text)
        Dim tate As Integer = Val(txtHeight.Text)

        Select Case btn.Name
            Case "btnHorizontal"
                yoko = tate * 1.41
            Case "btnVartical"
                tate = yoko * 1.41
        End Select
        Dim newSize As Size = spatial.Get_RectSize_by_Menseki(New Size(yoko, tate), First_M)
        txtWidth.Text = newSize.Width
        txtHeight.Text = newSize.Height
    End Sub
    Private Sub Help_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "frmPrint_SizeChange", Me)
    End Sub

End Class