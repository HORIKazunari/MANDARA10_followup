Public Class frmMED_ChangeLineKind_in_MultiLineNoTime
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal HeaderLeftText As String, ByVal DataCount As Integer, _
                 ByVal LeftText() As String, ByVal Value() As Integer, ByVal ComboBoxColumn As DataGridViewComboBoxColumn, _
                  Optional ByVal CenterX As Integer = -1) As Windows.Forms.DialogResult
        dgvComboBox.SetData(HeaderLeftText, DataCount, LeftText, Value, ComboBoxColumn)
        Return (Me.ShowDialog(Owner))
    End Function
    Public Function getResult() As Integer()
        Return dgvComboBox.GetValue
    End Function

    Private Sub frmMED_ChangeLineKind_in_MultiLineNoTime_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ChangeLineKind_in_MultiLineNoTime")
        e.Cancel = True
    End Sub
End Class