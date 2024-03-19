Public Class frmMED_ChengeLineKind_in_Multiobject
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal HeaderLeftText As String, ByVal DataCount As Integer, _
                     ByVal LeftText() As String, ByVal Value() As Integer, ByVal ComboBoxColumn As DataGridViewComboBoxColumn, _
                     ByVal Muse_F As Boolean, Optional ByVal CenterX As Integer = -1) As Windows.Forms.DialogResult
        dgvComboBox.SetData(HeaderLeftText, DataCount, LeftText, Value, ComboBoxColumn)
        chkKyoyuLine.Enabled = Muse_F
        Return (Me.ShowDialog(Owner))
    End Function
    Public Function getResult(ByRef KyoyuLineChangeF As Boolean) As Integer()
        KyoyuLineChangeF = chkKyoyuLine.Checked
        Return dgvComboBox.GetValue
    End Function



    Private Sub frmMED_ChengeLineKind_in_Multiobject_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ChengeLineKind_in_Multiobject")
        e.Cancel = True
    End Sub
End Class