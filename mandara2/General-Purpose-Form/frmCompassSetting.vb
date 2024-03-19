Public Class frmCompassSetting
    Private MCompass As clsMapData.strCompass_Attri
    Dim attr As New clsAttrData(Nothing)
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef CompassData As clsMapData.strCompass_Attri, ByRef ScData As Screen_info) As Windows.Forms.DialogResult
        MCompass = CompassData
        attr.TotalData.ViewStyle.ScrData = ScData
        attr.TotalData.BasePicture = clsBase.PictureNoUse
        With MCompass
            With .dirWord
                txtNorth.Text = .North
                txtSouth.Text = .South
                txtEast.Text = .East
                txtWest.Text = .West
            End With
            cbCompassVisible.Checked = .Visible
            clsDrawMarkFan.Draw_Mark_Sample_Box(picCompass, .Mark, attr.TotalData.ViewStyle.ScrData, clsBase.PictureNoUse)
        End With
        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResult() As clsMapData.strCompass_Attri
        With MCompass
            With .dirWord
                .North = txtNorth.Text
                .South = txtSouth.Text
                .East = txtEast.Text
                .West = txtWest.Text
            End With
            .Visible = cbCompassVisible.Checked
        End With
        Return MCompass
    End Function

    Private Sub picCompass_Click(sender As Object, e As EventArgs) Handles picCompass.Click
        If clsGeneric.Mark_Set(MCompass.Mark, attr) = True Then
            clsDrawMarkFan.Draw_Mark_Sample_Box(picCompass, MCompass.Mark, attr.TotalData.ViewStyle.ScrData, clsBase.PictureNoUse)
        End If
    End Sub

    Private Sub btnFont_Click(sender As Object, e As EventArgs) Handles btnFont.Click


        clsGeneric.Font_select(MCompass.Font, attr)
    End Sub

    Private Sub frmCompassSetting_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.SubWindow, "frmCompassSetting")
        e.Cancel = True
    End Sub
End Class