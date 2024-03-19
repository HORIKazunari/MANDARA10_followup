Public Class frmMain_LayeObjectSelect
    Dim attData As clsAttrData

    Dim CloseCancelF As Boolean
    Private Sub frmMED_LineCodeTime_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Public Overloads Function ShowDialog(ByRef _attData As clsAttrData, ByVal SelectionMode As SelectionMode, ByVal Dummy_Select_EnableF As Boolean,
             Optional ByVal DefLayerNum As Integer = 0, Optional ByVal DefSelectObjectNumber() As Integer = Nothing,
             Optional ByVal Dummy_SelectF As Boolean = False) As Windows.Forms.DialogResult
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        attData = _attData
        Me.Tag = "OFF"
        lbObject.SelectionMode = SelectionMode
        chkDumyObjectSelect.Checked = Dummy_SelectF
        chkDumyObjectSelect.Visible = Dummy_Select_EnableF
        attData.Set_LayerName_to(cboLayer, DefLayerNum)
        attData.Set_ObjectName_to_ListBoxEx(lbObject, DefLayerNum, DefSelectObjectNumber)
        Me.Tag = ""
        Return Me.ShowDialog
    End Function
    Public Sub getResult(ByRef LayerNum As Integer, ByRef SelectedObjects() As Integer, ByRef Dummy_SelectF As Boolean)
        LayerNum = cboLayer.SelectedIndex
        Dummy_SelectF = chkDumyObjectSelect.Checked
        Dim n As Integer = lbObject.SelectedIndices.Count
        If n = 0 Then
            SelectedObjects = Nothing
        Else
            ReDim SelectedObjects(n - 1)
            For i As Integer = 0 To n - 1
                SelectedObjects(i) = lbObject.SelectedIndices(i)
            Next
        End If
    End Sub

    Private Sub cboLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayer.SelectedIndexChanged, chkDumyObjectSelect.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim L As Integer = cboLayer.SelectedIndex
        If chkDumyObjectSelect.Checked = True Then
            attData.Set_DummyObjectName_to_ListBoxEx(lbObject, L)
        Else
            attData.Set_ObjectName_to_ListBoxEx(lbObject, L)
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim n As Integer = lbObject.SelectedIndices.Count
        If n = 0 Then
            MsgBox("オブジェクトを選択して下さい。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
        End If
    End Sub

    Private Sub frmMain_LayeObjectSelect_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim frm As frmMain
            frm = CType(Me.Owner, frmMain)
            frm.btnDraw.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub
End Class