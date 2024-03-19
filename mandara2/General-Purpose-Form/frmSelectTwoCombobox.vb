Public Class frmSelectTwoCombobox
    Dim List2 As List(Of String())
    Dim List2SelectedIndexDefault As Integer
    Public Overloads Function showdialog(ByVal Title As String, ByVal List1Title As String, ByVal List2Title As String,
                                         ByRef List1() As String, ByRef _List2 As List(Of String()),
                                         ByVal List1SelectedIndex As Integer, ByVal List2SelectedIndex As Integer) As Windows.Forms.DialogResult
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        Me.Text = Title
        lblList1.Text = List1Title
        lblList2.Text = List2Title
        List2 = _List2
        With cboList1.Items
            .Clear()
            .AddRange(List1)
        End With
        List2SelectedIndexDefault = List2SelectedIndex
        Me.Tag = "show"
        cboList1.SelectedIndex = List1SelectedIndex
        Me.Tag = ""
        Return Me.ShowDialog()
    End Function
    Public Sub GetResults(ByRef List1SelectedIndex As Integer, ByRef List2SelectedIndex As Integer)
        List1SelectedIndex = cboList1.SelectedIndex
        List2SelectedIndex = cboList2.SelectedIndex
    End Sub

    Private Sub cboList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboList1.SelectedIndexChanged
        Dim n As Integer = cboList1.SelectedIndex
        With cboList2.Items
            .Clear()
            .AddRange(List2(n))
            If Me.Tag = "show" Then
                cboList2.SelectedIndex = List2SelectedIndexDefault
            End If
        End With
    End Sub


    Private Sub cboList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboList2.SelectedIndexChanged
        If Me.Tag <> "show" Then
            btnOK.PerformClick()
        End If
    End Sub
End Class