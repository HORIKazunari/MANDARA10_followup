Public Class frmProjectionConvert
    Dim CloseCancelF As Boolean
    Dim Zahyo As clsMapData.Zahyo_info
    Dim cx As Single
    Dim prj As enmProjection_Info
    Dim Circumscribed_Rectangle As RectangleF
    Private Sub txtLat_Enter(sender As Object, e As EventArgs) Handles txtCenterLat.Enter
        rbManual.Checked = True
    End Sub
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal _Zahyo As clsMapData.Zahyo_info, ByVal MapRect As RectangleF) As Windows.Forms.DialogResult
        Zahyo = _Zahyo
        Circumscribed_Rectangle = MapRect
        lbGenzai.Text = clsGeneric.getStringProjectionEnum(Zahyo.Projection)
        rbCenterNoChange.Text = "変更なし(" & Zahyo.CenterXY.X & "度)"
        rbCenterNoChange.Checked = True
        For Each rb As Object In gbProjection.Controls
            If TypeOf rb Is RadioButton Then
                If rb.Text = lbGenzai.Text Then
                    rb.Checked = True
                End If
            End If
        Next
        Return Me.ShowDialog(Owner)
    End Function
    Public Sub getResult(ByRef centerLat As Single, ByRef newProjection As enmProjection_Info)
        centerLat = cx
        newProjection = prj

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Select Case True
            Case rbCenterNoChange.Checked
                cx = Zahyo.CenterXY.X
            Case rbMapCenter.Checked
                Dim mrect As RectangleF = spatial.Get_Reverse_Rect(Circumscribed_Rectangle, Zahyo)
                cx = (mrect.right + mrect.left) / 2
            Case rbManual.Checked
                Dim cLonW As String = txtCenterLat.Text
                If clsGeneric.Check_Suji(cLonW) = False Then
                    MsgBox("中央経線の経度の指定が正しくありません。", vbExclamation)
                    CloseCancelF = True
                    Return
                End If
                cx = Val(cLonW)

        End Select
        For Each rb As Object In gbProjection.Controls
            If TypeOf rb Is RadioButton Then
                If rb.Checked = True Then
                    prj = clsGeneric.getProjectionEnum_fromStrings(rb.Text)
                End If
            End If
        Next
    End Sub

    Private Sub frmProjectionConvert_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SubWindow, "frmProjectionConvert", Me)
    End Sub
End Class