Public Class frmMED_DefAttShow
    Dim CloseCancelF As Boolean
    Dim Mapdata As clsMapData
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal defAttVisibleData As clsMapEditorOperation.strDefAttVisible, ByRef _Mapdata As clsMapData) As Windows.Forms.DialogResult
        Mapdata = _Mapdata
        lblTimeNote.Visible = Mapdata.Map.Time_Mode
        cbVisible.Checked = True
        picColor.BackColor = clsSettings.Data.MapEditor.DefAttrColor.getColor
        txtSize.Text = clsSettings.Data.MapEditor.DefAttrSize
        Dim obkname() As String = Mapdata.Get_ObjectGroupNameList()
        cbObjectGroup.Items.AddRange(obkname)
        cbObjectGroup.SelectedIndex = Math.Min(defAttVisibleData.ObjectKind, cbObjectGroup.Items.Count - 1)
        cbDefAttData.SelectedIndex = Math.Min(defAttVisibleData.DataItem, cbDefAttData.Items.Count - 1)
        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResult() As clsMapEditorOperation.strDefAttVisible
        Dim data As clsMapEditorOperation.strDefAttVisible
        data.Visible = cbVisible.Checked
        data.ObjectKind = cbObjectGroup.SelectedIndex
        data.DataItem = cbDefAttData.SelectedIndex
        clsSettings.Data.MapEditor.DefAttrSize = Val(txtSize.Text)
        clsSettings.Data.MapEditor.DefAttrColor.setColor(picColor.BackColor)
        Return data
    End Function

    Private Sub frmMED_DefAttShow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If cbVisible.Checked = True Then
            If cbObjectGroup.SelectedIndex = -1 Or cbDefAttData.SelectedIndex = -1 Then
                MsgBox("表示初期属性データ項目が選択されていません。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
            End If
        End If
    End Sub

    Private Sub cbObjectGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbObjectGroup.SelectedIndexChanged
        Dim n As Integer = cbObjectGroup.SelectedIndex
        cbDefAttData.Items.Clear()
        With Mapdata.ObjectKind(n)
            For i As Integer = 0 To .DefTimeAttDataNum - 1
                cbDefAttData.Items.Add(.DefTimeAttSTC(i).attData.Title)
            Next
            If .DefTimeAttDataNum > 0 Then
                cbDefAttData.SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub picColor_Click(sender As Object, e As EventArgs) Handles picColor.Click
        Dim col As colorARGB = New colorARGB(picColor.BackColor)
        If clsGeneric.Color_Set(col) = True Then
            picColor.BackColor = col.getColor
        End If
    End Sub

    Private Sub frmMED_DefAttShow_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_DefAttShow", Me)
        e.Cancel = True
    End Sub


End Class