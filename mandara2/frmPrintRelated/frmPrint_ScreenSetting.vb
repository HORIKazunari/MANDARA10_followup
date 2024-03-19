Public Class frmPrint_ScreenSetting
    Dim CloseCancelF As Boolean
    Dim Setting As List(Of clsAttrData.strScreen_Setting_Data_Info)
    Dim attr As clsAttrData
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
    Public Overloads Function ShowDialog(ByRef _attr As clsAttrData) As Windows.Forms.DialogResult
        attr = _attr
        Setting = New List(Of clsAttrData.strScreen_Setting_Data_Info)
        lbList.Items.Clear()
        For i As Integer = 0 To attr.TotalData.ViewStyle.Screen_Setting.Count - 1
            Dim itm As clsAttrData.strScreen_Setting_Data_Info
            With attr.TotalData.ViewStyle.Screen_Setting(i)
                itm.Accessory_Base = .Accessory_Base
                itm.AttMapCompass = .AttMapCompass
                itm.DataNote = .DataNote
                itm.frmPrint_FormSize = .frmPrint_FormSize
                itm.MapLegend = .MapLegend
                itm.MapLegend.Base.LegendXY = .MapLegend.Base.LegendXY.Clone
                itm.MapScale = .MapScale
                itm.MapTitle = .MapTitle
                itm.Screen_Margin = .Screen_Margin
                itm.ScrView = .ScrView
                itm.ThreeDMode = .ThreeDMode
                itm.title = .title
            End With
            Setting.Add(itm)
            lbList.Items.Add(itm.title)
        Next
        Return Me.ShowDialog

    End Function
    Public Function GetResults(ByRef SetData As List(Of clsAttrData.strScreen_Setting_Data_Info)) As Integer
        SetData = Setting
        Return lbList.SelectedIndex
    End Function

    Private Sub brnDelete_Click(sender As Object, e As EventArgs) Handles brnDelete.Click
        Dim i As Integer = lbList.SelectedIndex
        If i = -1 Then
            Return
        End If
        lbList.Items.RemoveAt(i)
        clsGeneric.ListIndex_Reset(lbList, i)
        Setting.RemoveAt(i)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtName.Text = "" Then
            MsgBox("名称を指定してください。", MsgBoxStyle.Exclamation)
        Else
            Dim itm As clsAttrData.strScreen_Setting_Data_Info
            With attr.TotalData.ViewStyle
                itm.title = txtName.Text
                With .ScrData
                    itm.frmPrint_FormSize = .frmPrint_FormSize
                    itm.Screen_Margin = .Screen_Margin
                    itm.ScrView = .ScrView
                    itm.ThreeDMode = .ThreeDMode
                    itm.Accessory_Base = .Accessory_Base
                End With
                itm.MapScale = .MapScale
                itm.MapTitle = .MapTitle
                itm.MapLegend = .MapLegend
                itm.MapLegend.Base.LegendXY = .MapLegend.Base.LegendXY.Clone
                itm.AttMapCompass = .AttMapCompass
                itm.DataNote = .DataNote
            End With
            lbList.Items.Add(itm.title)
            Setting.Add(itm)
            lbList.SelectedIndex = -1
            MsgBox(itm.title + "を登録しました。")
            btnOK.PerformClick()
        End If

    End Sub
    Private Sub Help_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "frmPrint_ScreenSetting", Me)
    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

    End Sub
End Class