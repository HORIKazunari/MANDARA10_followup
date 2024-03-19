Public Class frmMain_ConditionSettingSub
    Dim attrData As clsAttrData
    Dim ConItem As clsAttrData.strCondition_DataSet_Info
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData, ByRef _ConItem As clsAttrData.strCondition_DataSet_Info) As DialogResult
        ConItem = _ConItem
        attrData = _attrData
        Me.Tag = "OFF"
        attrData.Set_LayerName_to(cboLayer, ConItem.Layer, True, True, True, True, True, False)
        Me.Tag = ""
        txtTitle.Text = ConItem.Name
        With ConItem
            .Layer = _ConItem.Layer
            .Name = _ConItem.Name
            .Enabled = _ConItem.Enabled
            .Condition_Class = New List(Of clsAttrData.strCondition_Data_Info)
            For i As Integer = 0 To _ConItem.Condition_Class.Count - 1
                Dim DT As clsAttrData.strCondition_Data_Info
                With DT
                    .And_OR = _ConItem.Condition_Class(i).And_OR
                    .Condition = New List(Of clsAttrData.strCondition_Limitation_Info)
                    For j As Integer = 0 To _ConItem.Condition_Class(i).Condition.Count - 1
                        Dim Lim As clsAttrData.strCondition_Limitation_Info = _ConItem.Condition_Class(i).Condition(j)
                        .Condition.Add(Lim)
                    Next
                End With
                .Condition_Class.Add(DT)
            Next
            TabControl.TabPages.Clear()
            For i As Integer = 0 To .Condition_Class.Count - 1
                Dim myTabPage As New TabPage()
                Dim tx As String = "第" + (i + 1).ToString + "段階"
                TabControl.TabPages.Add(tx)
            Next
            TabControl.SelectedIndex = 0
            SetItemPanel()
        End With
        Return Me.ShowDialog()
    End Function
    Public Function GetResult() As clsAttrData.strCondition_DataSet_Info
        ConItem.Name = txtTitle.Text
        ConItem.Enabled = True
        Return ConItem
    End Function

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged
        SetItemPanel()
    End Sub
    Private Sub SetItemPanel()
        Dim n As Integer = TabControl.SelectedIndex
        If n = -1 Then
            Return
        End If
        With ConItem.Condition_Class(n)
            If .And_OR = clsAttrData.enmConditionAnd_Or._And Then
                rbAND.Checked = True
            Else
                rbOR.Checked = True
            End If
            attrData.Set_DataTitle_to_cboBox(cboData, ConItem.Layer, 0)
            ListViewSet()
        End With

    End Sub
    Private Sub ListViewSet()
        Dim n As Integer = TabControl.SelectedIndex
        With ConItem.Condition_Class(n)
            Dim ItemData(.Condition.Count) As String
            ItemData(0) = "データ項目" + vbTab + "条件値" + vbTab + "条件"
            For i As Integer = 0 To .Condition.Count - 1
                With .Condition(i)
                    ItemData(i + 1) = attrData.Get_DataTitle(ConItem.Layer, .Data, False) + vbTab + .Val + vbTab + clsGeneric.getConditionSTring(.Condition)
                End With
            Next
            ListView.SetData(ItemData, {VariantType.String, VariantType.String, VariantType.String}, {False, False, False}, False)
        End With
    End Sub


    Private Sub btnAddLevel_Click(sender As Object, e As EventArgs) Handles btnAddLevel.Click
        Dim n As Integer = ConItem.Condition_Class.Count
        Dim tx As String = "第" + (n + 1).ToString + "段階"
        TabControl.TabPages.Add(tx)
        Dim cdt As clsAttrData.strCondition_Data_Info
        cdt.And_OR = clsAttrData.enmConditionAnd_Or._And
        cdt.Condition = New List(Of clsAttrData.strCondition_Limitation_Info)
        ConItem.Condition_Class.Add(cdt)
        TabControl.SelectedIndex = n
    End Sub

    Private Sub btnDeleteLevel_Click(sender As Object, e As EventArgs) Handles btnDeleteLevel.Click
        If ConItem.Condition_Class.Count = 1 Then
            MsgBox("これ以上削除できません。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim n As Integer = TabControl.SelectedIndex
        If MsgBox(TabControl.SelectedTab.Text & "を削除します。", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            Dim newn As Integer
            If n = TabControl.TabPages.Count - 1 Then
                newn = n - 1
            Else
                newn = n
            End If
            TabControl.TabPages.RemoveAt(n)
            ConItem.Condition_Class.RemoveAt(n)
            For i As Integer = n To TabControl.TabPages.Count - 1
                TabControl.TabPages.Item(i).Text = "第" + (i + 1).ToString + "段階"
            Next
            TabControl.SelectedIndex = newn
            ListViewSet()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim n As Integer = TabControl.SelectedIndex
        Dim Lim As clsAttrData.strCondition_Limitation_Info
        Lim.Data = cboData.SelectedIndex
        Lim.Val = txtValue.Text
        Select Case True
            Case rbLess.Checked
                Lim.Condition = clsAttrData.enmCondition.Less
            Case rbLessEqual.Checked
                Lim.Condition = clsAttrData.enmCondition.LessEqual
            Case rbEqual.Checked
                Lim.Condition = clsAttrData.enmCondition.Equal
            Case rbGreaterEqual.Checked
                Lim.Condition = clsAttrData.enmCondition.GreaterEqual
            Case rbGreater.Checked
                Lim.Condition = clsAttrData.enmCondition.Greater
            Case rbNotEqual.Checked
                Lim.Condition = clsAttrData.enmCondition.NotEqual
            Case rbInclude.Checked
                Lim.Condition = clsAttrData.enmCondition.Include
            Case rbExclude.Checked
                Lim.Condition = clsAttrData.enmCondition.Exclude
            Case rbHead.Checked
                Lim.Condition = clsAttrData.enmCondition.Head
            Case rbFoot.Checked
                Lim.Condition = clsAttrData.enmCondition.Foot
            Case Else
                MsgBox("条件を指定して下さい。", MsgBoxStyle.Exclamation)
                Return
        End Select
        Select Case attrData.Get_DataType(ConItem.Layer, Lim.Data)
            Case enmAttDataType.Normal, enmAttDataType.Departure, enmAttDataType.Arrival
                If clsGeneric.Check_Suji(Lim.Val) = False Then
                    MsgBox("数値以外の文字が含まれています。", MsgBoxStyle.Exclamation)
                    Return
                End If
        End Select
        ConItem.Condition_Class(n).Condition.Add(Lim)
        ListViewSet()
        txtValue.Text = ""
        For Each c As RadioButton In gbCondition.Controls
            c.Checked = False
        Next
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim n As Integer = TabControl.SelectedIndex
        If ListView.SelectedIndices.Count = 0 Then
            Return
        End If
        Dim i As Integer = ListView.SelectedIndices(0)
        If i = -1 Then
            MsgBox("項目を選択して下さい。", MsgBoxStyle.Exclamation)
        Else
            ConItem.Condition_Class(n).Condition.RemoveAt(i)
            ListViewSet()
        End If
    End Sub

    Private Sub cboLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayer.SelectedIndexChanged
        If Me.Tag <> "" Then
            Return
        End If
        If MsgBox("レイヤを変更すると設定がクリアされます。", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            ConItem.Layer = cboLayer.SelectedIndex
            ConItem.Condition_Class.Clear()
            Dim cdt As clsAttrData.strCondition_Data_Info
            cdt.And_OR = clsAttrData.enmConditionAnd_Or._And
            cdt.Condition = New List(Of clsAttrData.strCondition_Limitation_Info)
            ConItem.Condition_Class.Add(cdt)
            TabControl.TabPages.Clear()
            TabControl.TabPages.Add("第1段階")
            TabControl.SelectedIndex = 0
            SetItemPanel()
        Else
            Me.Tag = "OFF"
            cboLayer.SelectedIndex = ConItem.Layer
            Me.Tag = ""
        End If
    End Sub

    Private Sub rbOR_CheckedChanged(sender As Object, e As EventArgs) Handles rbOR.CheckedChanged, rbAND.CheckedChanged
        Dim n As Integer = TabControl.SelectedIndex
        Dim cdt As clsAttrData.strCondition_Data_Info = ConItem.Condition_Class(n)
        If rbOR.Checked = True Then
            cdt.And_OR = clsAttrData.enmConditionAnd_Or._Or
        Else
            cdt.And_OR = clsAttrData.enmConditionAnd_Or._And
        End If
        ConItem.Condition_Class(n) = cdt
    End Sub

  
    Private Sub frmMain_ConditionSettingSub_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_ConditionSettingSub", Me)
    End Sub

    Private Sub btnDataValue_Click(sender As Object, e As EventArgs) Handles btnDataValue.Click
        Dim cdata() As clsAttrData.strObjLocation_and_Data_info = attrData.Get_Data_Cell_Array_Without_MissingValue(ConItem.Layer, cboData.SelectedIndex)
        Dim datav(cdata.Length - 1) As String

        For i As Integer = 0 To cdata.Length - 1
            datav(i) = attrData.LayerData(ConItem.Layer).atrObject.atrObjectData(cdata(i).ObjLocation).Name + ":" + cdata(i).DataValue
        Next
        Dim selected As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("データ値参照", datav)
        If selected <> -1 Then
            txtValue.Text = cdata(selected).DataValue
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If ConItem.Condition_Class.Count = 1 Then
            If ConItem.Condition_Class(0).Condition.Count = 0 Then
                btnAdd.PerformClick()
            End If
        End If
    End Sub
End Class