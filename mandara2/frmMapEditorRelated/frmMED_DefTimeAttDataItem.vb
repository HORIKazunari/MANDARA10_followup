Public Class frmMED_DefTimeAttDataItem
    Dim CloseCancelF As Boolean
    Dim DefTimeAttData As clsMapData.strMPObjDefTimeAttData_Info
    Private Sub frmMED_DefTimeAttDataItem_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal _DefTimeAttData As clsMapData.strMPObjDefTimeAttData_Info) As Windows.Forms.DialogResult
        DefTimeAttData = _DefTimeAttData
        cboUnit.Items.Clear()
        cboUnit.Items.AddRange({"通常のデータ", "カテゴリーデータ", "文字データ"})
        cboExtra.Items.Clear()
        cboExtra.Items.AddRange({"欠損値", "近い時期の値", "内挿+欠損値", "内挿+近い時期の値"})
        With DefTimeAttData
            If .Type = clsMapData.enmDefTimeAttDataType.PointData Then
                rbPoint.Checked = True
            Else
                rbSpan.Checked = True
            End If
            cboUnit.SelectedIndex = clsGeneric.getAttDataType_From_TitleUnit(.attData.Title, .attData.Unit)
            cboExtra.SelectedIndex = .ExtraValue
            txtTitle.Text = .attData.Title
            txtUnit.Text = .attData.Unit
            txtNote.Text = .attData.Note
            chkMissingValue.Checked = .attData.MissingF
        End With
        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResults() As clsMapData.strMPObjDefTimeAttData_Info
        With DefTimeAttData
            If rbPoint.Checked = True Then
                .Type = clsMapData.enmDefTimeAttDataType.PointData
            Else
                .Type = clsMapData.enmDefTimeAttDataType.SpanData
            End If
            .ExtraValue = cboExtra.SelectedIndex
            .attData.Unit = txtUnit.Text
            .attData.Title = txtTitle.Text
            .attData.Note = txtNote.Text
            .attData.MissingF = chkMissingValue.Checked
        End With
        Return DefTimeAttData
    End Function

    Private Sub cboUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUnit.SelectedIndexChanged
        Select Case cboUnit.SelectedIndex
            Case enmAttDataType.Normal
                txtUnit.Enabled = True
            Case enmAttDataType.Category
                txtUnit.Enabled = False
                txtUnit.Text = "CAT"
            Case enmAttDataType.Strings
                txtUnit.Enabled = False
                txtUnit.Text = "STR"
        End Select
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If txtTitle.Text = "" Then
            MsgBox("タイトルを入力して下さい。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
        End If
        If rbPoint.Checked = True Then
            If cboUnit.SelectedIndex <> enmAttDataType.Normal Then
                If cboExtra.SelectedIndex >= 2 Then
                    MsgBox("時点データの場合、通常のデータ以外は、所定時期以外を指定した場合の処理に内挿を選べません。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                End If
            End If
        End If

    End Sub

    Private Sub frmMED_DefTimeAttDataItem_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_DefTimeAttDataItem", Me)
        e.Cancel = True
    End Sub

    Private Sub rbPoint_CheckedChanged(sender As Object, e As EventArgs) Handles rbPoint.CheckedChanged, rbSpan.CheckedChanged
        cboExtra.Enabled = rbPoint.Checked
    End Sub
End Class