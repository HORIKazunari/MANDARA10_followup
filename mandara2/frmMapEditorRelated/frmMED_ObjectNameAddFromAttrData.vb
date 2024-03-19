Public Class frmMED_ObjectNameAddFromAttrData
    Dim CloseCancelF As Boolean
    Dim MapData As clsMapData
    Dim OriginObjName As New List(Of clsMapData.Object_NameTimeStac_Data())
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
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef _MapData As clsMapData, ByVal defoObjG As Integer) As Windows.Forms.DialogResult
        MapData = _MapData
        OriginObjName = MapData.Get_All_ObjectName()
        With MapData
            For i As Integer = 0 To .Map.OBKNum - 1
                cboObjectKind.Items.Add(.ObjectKind(i).Name)
            Next
            cboObjectKind.SelectedIndex = defoObjG
        End With
        Return Me.ShowDialog(Owner)

    End Function
    Public Sub GetResults(ByRef ObjGroup As Integer, ByRef DataNum As Integer)
        ObjGroup = cboObjectKind.SelectedIndex
        DataNum = cboData.SelectedIndex
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim OBG As Integer = cboObjectKind.SelectedIndex
        Dim DataNum As Integer = cboData.SelectedIndex
        If DataNum = -1 Then
            MsgBox("データ項目が選択されていません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
        End If

 
    End Sub

    Private Sub cboObjectKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboObjectKind.SelectedIndexChanged
        Dim n As Integer = cboObjectKind.SelectedIndex
        With MapData
            cboData.Items.Clear()
            For i As Integer = 0 To .ObjectKind(n).DefTimeAttDataNum - 1
                cboData.Items.Add((i + 1).ToString + ":" + .ObjectKind(n).DefTimeAttSTC(i).attData.Title)
            Next
        End With

    End Sub

    Private Sub frmMED_ObjectNameAddFromAttrData_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ObjectNameAddFromAttrData", Me)
        e.Cancel = True
    End Sub
End Class