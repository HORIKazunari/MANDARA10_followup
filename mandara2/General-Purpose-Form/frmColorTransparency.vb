Public Class frmColorTransparency
    Public Overloads Function ShowDialog(ftrans As Integer) As Windows.Forms.DialogResult


        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        hsbTransparency.Value = ftrans
        txtAlpha.Text = ftrans
        Return Me.ShowDialog()
    End Function
    Public Function getResult() As Integer
        Return hsbTransparency.Value
    End Function
    Private Sub hsbTransparency_Scroll(sender As Object, e As EventArgs) Handles hsbTransparency.ValueChanged
        txtAlpha.Text = hsbTransparency.Value
    End Sub



    Private Sub txtAlpha_TextChanged(sender As Object, e As EventArgs) Handles txtAlpha.LostFocus
        hsbTransparency.Value = Val(txtAlpha.Text)

    End Sub
End Class