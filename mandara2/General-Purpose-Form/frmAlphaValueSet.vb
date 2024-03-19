Public Class frmAlphaValueSet
    Public Function SetDialog(ByVal AlphaValue As Integer) As Windows.Forms.DialogResult
        Me.Tag = "OFF"
        hsbTransparency.Value = AlphaValue
        txtAlphaValue.Text = AlphaValue
        Me.Tag = ""
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        Return Me.ShowDialog()
    End Function
    Public Function GetResult() As Integer
        Return hsbTransparency.Value
    End Function

    Private Sub hsbAlphaValue_Scroll(sender As Object, e As ScrollEventArgs) Handles hsbTransparency.Scroll
        If Me.Tag = "" Then
            txtAlphaValue.Text = hsbTransparency.Value
        End If
    End Sub

    Private Sub txtAlphaValue_TextChanged(sender As Object, e As EventArgs) Handles txtAlphaValue.Leave
        If Me.Tag = "" Then
            Me.Tag = "OFF"
            Dim v As Integer = Val(txtAlphaValue.Text)
            hsbTransparency.Value = v
            txtAlphaValue.Text = v
            Me.Tag = ""
        End If
    End Sub
End Class