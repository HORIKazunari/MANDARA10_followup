Public Class frmMED_LineKindCombine
    Dim newLinePattern As Line_Property
    Dim ScrData As Screen_info
    Dim MapData As clsMapData
    Dim basePic As BasePicture_Info
    Dim CloseCancelF As Boolean = False

    Private Sub frmMED_LineKindCombine_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub picLine_Click(sender As Object, e As EventArgs) Handles picLine.Click
        Dim attr As New clsAttrData(Nothing)
        attr.TotalData.ViewStyle.ScrData = ScrData
        attr.TotalData.BasePicture = basePic
        If clsGeneric.Line_Pattern_select(newLinePattern, True, attr) = True Then
            clsDrawLine.Draw_Sample_LineBox(picLine, newLinePattern, ScrData, basePic)
        End If
    End Sub

    Public Overloads Function ShowDialog(ByVal ScData As Screen_info, ByRef mpData As clsMapData, ByRef _basePic As BasePicture_Info) As Windows.Forms.DialogResult
        ScrData = ScData
        MapData = mpData
        basePic = _basePic
        clbBase.Items.Clear()
        clbBase.Items.AddRange(MapData.Get_LineKindNameList)
        newLinePattern = clsBase.Line
        clsDrawLine.Draw_Sample_LineBox(picLine, newLinePattern, ScrData, basePic)
        Return Me.ShowDialog()
    End Function

    Public Function getResult(ByRef LinePatName As String, ByRef Lpat As Line_Property) As Boolean()
        Dim Combinef(MapData.Map.LpNum - 1) As Boolean
        For i As Integer = 0 To MapData.Map.LpNum - 1
            Combinef(i) = clbBase.GetItemChecked(i)
        Next
        LinePatName = txtName.Text
        Lpat = newLinePattern
        Return Combinef
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If txtName.Text = "" Then
            MsgBox("統合後の名称を設定してください。", vbExclamation)
            CloseCancelF = True
            Exit Sub
        End If

        If clbBase.CheckedItems.Count <= 1 Then
            MsgBox("二つ以上選択してください。", vbExclamation)
            CloseCancelF = True
            Exit Sub
        End If

        Dim mes As String = clbBase.CheckedItems.Count & "つを統合します。"
        If MsgBox(mes, vbYesNo) = vbNo Then
            CloseCancelF = True
            Exit Sub

        End If


    End Sub



    Private Sub clbBase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbBase.SelectedIndexChanged
        Static Count As Boolean

        Dim i As Integer = clbBase.SelectedIndex
        If MapData.LineKind(i).Mesh <> enmMesh_Number.mhNonMesh And clbBase.GetItemChecked(i) = True Then
            MsgBox("メッシュラインは結合できません。", vbExclamation)
            clbBase.SetItemChecked(i, False)
            Exit Sub
        End If
        If MapData.LineKind(i).NumofObjectGroup >= 2 And clbBase.GetItemChecked(i) = True Then
            MsgBox("オブジェクトグループ連動型は結合できません。", vbExclamation)
            clbBase.SetItemChecked(i, False)
            Exit Sub
        End If
        If Count = False And txtName.Text = "" Then
            txtName.Text = clbBase.Items(i)
            newLinePattern = MapData.LineKind(i).ObjGroup(0).Pattern
            clsDrawLine.Draw_Sample_LineBox(picLine, newLinePattern, ScrData, basePic)
            Count = True
        End If
    End Sub

    Private Sub frmMED_LineKindCombine_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_LineKindCombine", Me)
        e.Cancel = True
    End Sub
End Class