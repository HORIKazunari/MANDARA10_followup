Public Class frmSelectList

    Public Overloads Function ShowDialog(ByVal Title As String, ByVal Items As ArrayList) As Windows.Forms.DialogResult

        Me.Text = Title
        Dim Values() As String

        Values = DirectCast(Items.ToArray(GetType(String)), String())
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        setList(Values)
        Return Me.ShowDialog()
    End Function
    Public Overloads Function ShowDialog(ByVal Title As String, ByVal Items() As String) As Windows.Forms.DialogResult

        Me.Text = Title
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        setList(Items)
        Return Me.ShowDialog()
    End Function
    Public Function GetResult() As Integer
        Return cbList.SelectedIndex
    End Function
    Private Sub setList(ByVal Items() As String)

        cbList.Items.Clear()
        cbList.Items.AddRange(Items)
        cbList.MaxDropDownItems = Math.Min(cbList.Items.Count, 15)
    End Sub
    Private Sub frmSelectList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cbList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbList.Click

    End Sub

    Private Sub cbList_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbList.DropDownClosed
        If cbList.SelectedIndex = -1 Then
            btnCancel.PerformClick()
        End If
    End Sub

    Private Sub cbList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbList.SelectedIndexChanged
        btnOK.PerformClick()
    End Sub
 

    Private Sub frmSelectList_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        cbList.DroppedDown = True
    End Sub


End Class