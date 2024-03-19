Public Class frmMain_ConditionSettings
    Dim attrData As clsAttrData
    Dim DefoLay As Integer
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData) As DialogResult
        attrData = _attrData
        DefoLay = attrData.TotalData.LV1.SelectedLayer
        clbList.Items.Clear()
        With attrData.TotalData.Condition
            For i As Integer = 0 To .Count - 1
                Dim tx As String = "【" + attrData.LayerData(.Item(i).Layer).Name + "】" + .Item(i).Name
                clbList.Items.Add(tx)
                clbList.SetItemChecked(i, .Item(i).Enabled)
            Next
        End With
        chkInvisibleObjectBoundary.Checked = attrData.TotalData.ViewStyle.InVisibleObjectBoundaryF
        Return Me.ShowDialog()
    End Function


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim cttl(attrData.TotalData.Condition.Count - 1) As String
        For i As Integer = 0 To attrData.TotalData.Condition.Count - 1
            cttl(i) = attrData.TotalData.Condition(i).Name
        Next

        Dim form As New frmMain_ConditionSettingSub
        Dim ConItem As clsAttrData.strCondition_DataSet_Info
        ConItem.Layer = DefoLay
        ConItem.Name = clsGeneric.Get_New_Numbering_Strings("属性検索条件", cttl)
        ConItem.Condition_Class = New List(Of clsAttrData.strCondition_Data_Info)
        Dim cdt As clsAttrData.strCondition_Data_Info
        cdt.And_OR = clsAttrData.enmConditionAnd_Or._And
        cdt.Condition = New List(Of clsAttrData.strCondition_Limitation_Info)
        ConItem.Condition_Class.Add(cdt)
        ConItem.Enabled = True
        If form.ShowDialog(attrData, ConItem) = Windows.Forms.DialogResult.OK Then
            Dim Con As clsAttrData.strCondition_DataSet_Info = form.GetResult()
            attrData.TotalData.Condition.Add(Con)
            clbList.Items.Add("【" + attrData.LayerData(Con.Layer).Name + "】" + Con.Name)
            clbList.SetItemChecked(clbList.Items.Count - 1, attrData.TotalData.Condition.Item(clbList.Items.Count - 1).Enabled)
        End If
        form.Dispose()
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Dim n As Integer = clbList.SelectedIndex
        If n = -1 Then
            MsgBox("条件設定を選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim form As New frmMain_ConditionSettingSub
        Dim ConItem As clsAttrData.strCondition_DataSet_Info = attrData.TotalData.Condition.Item(n)
        If form.ShowDialog(attrData, ConItem) = Windows.Forms.DialogResult.OK Then
            attrData.TotalData.Condition.Item(n) = form.GetResult()
            With attrData.TotalData.Condition.Item(n)
                clbList.Items(n) = "【" + attrData.LayerData(.Layer).Name + "】" + .Name
                clbList.SetItemChecked(n, .Enabled)
            End With
        End If
        form.Dispose()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim n As Integer = clbList.SelectedIndex
        If n = -1 Then
            MsgBox("条件設定を選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If
        If MsgBox(clbList.Items(n) & "を削除します。", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            clbList.Items.RemoveAt(n)
            attrData.TotalData.Condition.RemoveAt(n)
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        For i As Integer = 0 To clbList.Items.Count - 1
            Dim cdt As clsAttrData.strCondition_DataSet_Info = attrData.TotalData.Condition.Item(i)
            cdt.Enabled = clbList.GetItemChecked(i)
            attrData.TotalData.Condition.Item(i) = cdt
        Next
        attrData.TotalData.ViewStyle.InVisibleObjectBoundaryF = chkInvisibleObjectBoundary.Checked
    End Sub

    Private Sub ctnCheck_Click(sender As Object, e As EventArgs) Handles ctnCheck.Click
        For i As Integer = 0 To clbList.Items.Count - 1
            Dim cdt As clsAttrData.strCondition_DataSet_Info = attrData.TotalData.Condition.Item(i)
            cdt.Enabled = clbList.GetItemChecked(i)
            attrData.TotalData.Condition.Item(i) = cdt
        Next


        Dim tx As String = ""
        For i As Integer = 0 To attrData.TotalData.LV1.Lay_Maxn - 1
            tx += attrData.Get_Condition_Ok_Num_Info(i)
        Next
        clsGeneric.Message(Me, "属性検索", tx, True, True)
    End Sub

    Private Sub btnAllCheck_Click(sender As Object, e As EventArgs) Handles btnAllCheck.Click
        For i As Integer = 0 To clbList.Items.Count - 1
            clbList.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub btnAllUnChecked_Click(sender As Object, e As EventArgs) Handles btnAllUnChecked.Click
        For i As Integer = 0 To clbList.Items.Count - 1
            clbList.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub frmMain_ConditionSettings_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_ConditionSettings", Me)

    End Sub
End Class