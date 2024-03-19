Public Class frmMED_ObjectKind
    Dim CloseCancelF As Boolean

    Dim ObkNum_by_Obkkind() As Integer
    Dim Conv_Obkind() As Integer
    Dim MapData As clsMapData

    Dim ObjectKind() As clsMapData.strObjectGroup_Data
    Dim newObkNum As Integer

    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef MData As clsMapData) As Windows.Forms.DialogResult
        MapData = MData
        ObkNum_by_Obkkind = MapData.Get_ObjectKind_Use_Number()
        ReDim ObjectKind(MapData.Map.OBKNum - 1)
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            ObjectKind(i) = MData.ObjectKind(i).Clone
        Next
        newObkNum = MData.Map.OBKNum

        With clbUseLineKind
            .Items.Clear()
            .Items.AddRange(MapData.Get_LineKindNameList)
        End With
        With clbUseObjectGroup
            .Items.Clear()
            .Items.AddRange(MapData.Get_ObjectGroupNameList)
            .SelectedIndex = 0
        End With

        With lbObjectKind
            .Items.Clear()
            .Items.AddRange(MapData.Get_ObjectGroupNameList)
            .SelectedIndex = 0
        End With

        ReDim Conv_Obkind(newObkNum - 1)
        For i As Integer = 0 To newObkNum - 1
            Conv_Obkind(i) = i
        Next
        Return Me.ShowDialog(Owner)
    End Function


    Public Function getResult(ByRef newObjGroupNum As Integer, ByRef old2newObjGroupNumber() As Integer) As clsMapData.strObjectGroup_Data()
        ReDim old2newObjGroupNumber(MapData.Map.OBKNum - 1)
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            old2newObjGroupNumber(i) = -1
        Next
        For i As Integer = 0 To newObkNum - 1
            If Conv_Obkind(i) <> -1 Then
                old2newObjGroupNumber(Conv_Obkind(i)) = i
            End If
        Next
        newObjGroupNum = newObkNum
        Return ObjectKind
    End Function

    Private Sub frmMED_ObjectKind_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub rbObjectTypeNormal_CheckedChanged(sender As Object, e As EventArgs) Handles rbObjectTypeNormal.CheckedChanged, rbObjectTypeAggrigation.CheckedChanged
        Dim L As Integer = lbObjectKind.SelectedIndex
        Dim cngf As Boolean = False
        Dim NType As clsMapData.enmObjectGoupType_Data
        Select Case True
            Case rbObjectTypeNormal.Checked
                If ObjectKind(L).ObjectType <> clsMapData.enmObjectGoupType_Data.NormalObject Then
                    cngf = True
                    NType = clsMapData.enmObjectGoupType_Data.NormalObject
                End If
            Case rbObjectTypeAggrigation.Checked
                If ObjectKind(L).ObjectType <> clsMapData.enmObjectGoupType_Data.AggregationObject Then
                    cngf = True
                    NType = clsMapData.enmObjectGoupType_Data.AggregationObject
                End If
        End Select
        If cngf = True Then
            Dim L2 As Integer = Conv_Obkind(L)
            If L2 <> -1 Then
                If ObkNum_by_Obkkind(L2) <> 0 Then
                    MsgBox("選択したオブジェクトグループはまだ使用されているので、タイプを変更できません", vbExclamation)
                    Select Case ObjectKind(L).ObjectType
                        Case clsMapData.enmObjectGoupType_Data.NormalObject
                            rbObjectTypeNormal.Checked = True
                        Case clsMapData.enmObjectGoupType_Data.AggregationObject
                            rbObjectTypeAggrigation.Checked = True
                    End Select
                    Exit Sub
                End If
            End If
            With ObjectKind(L)
                .ObjectType = NType
                Select Case .ObjectType
                    Case clsMapData.enmObjectGoupType_Data.NormalObject
                        Erase .UseObjectGroup
                        ReDim .UseLineType(MapData.Map.LpNum - 1)
                        clbUseLineKind.ClearSelected()
                    Case clsMapData.enmObjectGoupType_Data.AggregationObject
                        ReDim .UseObjectGroup(newObkNum - 1)
                        Erase .UseLineType
                        clbUseObjectGroup.ClearSelected()
                End Select
            End With
        End If
        Select Case ObjectKind(L).ObjectType
            Case clsMapData.enmObjectGoupType_Data.NormalObject
                gbUseLineKind.Visible = True
                gbUseObjectGroup.Visible = False
            Case clsMapData.enmObjectGoupType_Data.AggregationObject
                gbUseLineKind.Visible = False
                gbUseObjectGroup.Visible = True
        End Select

    End Sub



    Private Sub lbObjectKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbObjectKind.SelectedIndexChanged
        Dim L As Integer = lbObjectKind.SelectedIndex
        If L = -1 Then
            Exit Sub
        End If
        txtNewName.Tag = "off"
        txtNewName.Text = lbObjectKind.SelectedItem
        txtNewName.Tag = ""
        gbSet.Text = lbObjectKind.SelectedItem
        With ObjectKind(L)
            picColor.BackColor = .Color.getColor
            Select Case .Shape
                Case enmShape.PointShape
                    rbPoint.Checked = True
                Case enmShape.LineShape
                    rbLine.Checked = True
                Case enmShape.PolygonShape
                    rbPolygon.Checked = True
                Case enmShape.NotDeffinition
                    rbNoShape.Checked = True
            End Select
            If .Mesh = enmMesh_Number.mhNonMesh Then
                txtNewName.Enabled = True
                gbObjShape.Enabled = True
            Else
                txtNewName.Enabled = False
                gbObjShape.Enabled = False
            End If
            Select Case .ObjectType
                Case clsMapData.enmObjectGoupType_Data.NormalObject
                    rbObjectTypeNormal.Checked = True
                    With clbUseLineKind
                        .SelectedIndex = -1
                        For i As Integer = 0 To MapData.Map.LpNum - 1
                            .SetItemChecked(i, ObjectKind(L).UseLineType(i))
                        Next
                        .SelectedIndex = -1
                    End With
                Case clsMapData.enmObjectGoupType_Data.AggregationObject
                    rbObjectTypeAggrigation.Checked = True
                    With clbUseObjectGroup
                        .SelectedIndex = -1
                        For i As Integer = 0 To newObkNum - 1
                            .SetItemChecked(i, ObjectKind(L).UseObjectGroup(i))
                        Next
                        .SelectedIndex = -1
                    End With
            End Select
        End With
    End Sub

    Private Sub btnUpword_Click(sender As Object, e As EventArgs) Handles _
                            btnUpword.Click, btnDownword.Click
        Dim L As Integer = lbObjectKind.SelectedIndex
        If L = -1 Then
            Exit Sub
        End If

        Dim n As Integer
        Select Case sender.name
            Case "btnUpword"
                If L = 0 Then
                    Exit Sub
                End If
                n = L - 1
            Case "btnDownword"
                If L = lbObjectKind.Items.Count - 1 Then Exit Sub
                n = L + 1
        End Select
        With lbObjectKind.Items
            .RemoveAt(L)
            .Insert(n, ObjectKind(L).Name)
        End With
        With clbUseObjectGroup.Items
            .RemoveAt(L)
            .Insert(n, ObjectKind(L).Name)
        End With
        Dim TObk As clsMapData.strObjectGroup_Data = ObjectKind(n).Clone
        ObjectKind(n) = ObjectKind(L).Clone
        ObjectKind(L) = TObk.Clone
        clsGeneric.SWAP(Conv_Obkind(n), Conv_Obkind(L))

        For i As Integer = 0 To MapData.Map.OBKNum - 1
            With ObjectKind(i)
                If .ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                    clsGeneric.SWAP(.UseObjectGroup(n), .UseObjectGroup(L))
                End If
            End With
        Next
        lbObjectKind.SelectedIndex = n
    End Sub

    Private Sub btnAddGroup_Click(sender As Object, e As EventArgs) Handles btnAddGroup.Click
        Dim w() As String

        ReDim w(lbObjectKind.Items.Count - 1)
        For i As Integer = 0 To lbObjectKind.Items.Count - 1
            w(i) = lbObjectKind.Items(i)
        Next
        Dim nog As String = clsGeneric.Get_New_Numbering_Strings("新規", w)
        ReDim Preserve ObjectKind(newObkNum)
        ObjectKind(newObkNum) = MapData.Get_OneObjectGroup_Parameter(nog, enmShape.PointShape,
                                            newObkNum, MapData.Map.LpNum,
                                            enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
        For i As Integer = 0 To newObkNum - 1
            If ObjectKind(i).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                ReDim Preserve ObjectKind(i).UseObjectGroup(newObkNum)
            End If
        Next
        newObkNum += 1

        With lbObjectKind
            .Items.Add(nog)
            .SelectedIndex = .Items.Count - 1
            txtNewName.Focus()
        End With
        clbUseObjectGroup.Items.Add(nog)
        ReDim Preserve Conv_Obkind(newObkNum - 1)
        Conv_Obkind(newObkNum - 1) = -1
    End Sub

    Private Sub txtNewName_TextChanged(sender As Object, e As EventArgs) Handles txtNewName.TextChanged
        If txtNewName.Tag = "off" Then
            Exit Sub
        End If
        Dim i As Integer = lbObjectKind.SelectedIndex
        ObjectKind(i).Name = txtNewName.Text
        lbObjectKind.Items(i) = txtNewName.Text
        clbUseObjectGroup.Items(i) = txtNewName.Text
    End Sub

    Private Sub rbNoShape_CheckedChanged(sender As Object, e As EventArgs) Handles _
                        rbNoShape.CheckedChanged, rbPoint.CheckedChanged, rbLine.CheckedChanged, rbPolygon.CheckedChanged
        Dim i As Integer = lbObjectKind.SelectedIndex
        Select Case True
            Case rbNoShape.Checked
                ObjectKind(i).Shape = enmShape.NotDeffinition
            Case rbPoint.Checked
                ObjectKind(i).Shape = enmShape.PointShape
            Case rbLine.Checked
                ObjectKind(i).Shape = enmShape.LineShape
            Case rbPolygon.Checked
                ObjectKind(i).Shape = enmShape.PolygonShape
        End Select

    End Sub

    Private Sub picColor_Click(sender As Object, e As EventArgs) Handles picColor.Click
        Dim i As Integer = lbObjectKind.SelectedIndex
        If clsGeneric.Color_Set(ObjectKind(i).Color) = True Then
            picColor.BackColor = ObjectKind(i).Color.getColor
        End If
    End Sub

    Private Sub clbUseObjectGroup_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles clbUseObjectGroup.ItemCheck
        Dim i As Integer = clbUseObjectGroup.SelectedIndex
        If i <> -1 Then
            Dim L As Integer = lbObjectKind.SelectedIndex
            Dim f As Boolean = e.NewValue
            ObjectKind(L).UseObjectGroup(i) = f
            Dim ef As Boolean = False
            If f = True Then
                If i = L Then
                    Dim msgText As String = "自分自身は選択できません。"
                    MsgBox(msgText, MsgBoxStyle.Exclamation)
                    ef = True
                ElseIf ObjectKind(i).Shape = -1 Then
                    Dim msgText As String = "形状の指定されていないオブジェクトグループは選択できません。"
                    MsgBox(msgText, MsgBoxStyle.Exclamation)
                    ef = True
                Else
                    For j As Integer = 0 To newObkNum - 1
                        If ObjectKind(L).UseObjectGroup(j) = True And j <> i Then
                            If ObjectKind(i).Shape <> ObjectKind(j).Shape Then
                                MsgBox("選択したオブジェクトグループの形状が異なっています。", vbExclamation)
                                ef = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
            If ef = True Then
                e.NewValue = CheckState.Unchecked
                ObjectKind(L).UseObjectGroup(i) = False
            End If

        End If
    End Sub

  




    Private Sub btnDeleteGroup_Click(sender As Object, e As EventArgs) Handles btnDeleteGroup.Click
 

        If newObkNum = 1 Then
            Dim msgText As String = "オブジェクトグループは最低一つ必要です。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim L As Integer = lbObjectKind.SelectedIndex

        Dim L2 As Integer = Conv_Obkind(L)
        Dim f As Boolean = True
        If L2 <> -1 Then
            If ObkNum_by_Obkkind(L2) <> 0 Then
                Dim msgText As String = "選択したオブジェクトグループはまだ使用されているので、削除できません。"
                MsgBox(msgText, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        Dim ef As Boolean = False
        For i As Integer = 0 To newObkNum - 1
            With ObjectKind(i)
                If .ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject And i <> L Then
                    For j = 0 To newObkNum - 1
                        If .UseObjectGroup(j) = True And j = L Then
                            ef = True
                        End If
                    Next
                End If
            End With
        Next
        If ef = True Then
            Dim msgText As String = "選択したオブジェクトグループは集成オブジェクトで使用されているので、削除できません。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        ReDim Preserve Conv_Obkind(newObkNum - 1)
        For i As Integer = L To newObkNum - 2
            Conv_Obkind(i) = Conv_Obkind(i + 1)
        Next


        MapData.Erase_ObjectKind_Main(L, newObkNum, ObjectKind)

        lbObjectKind.Items.RemoveAt(L)
        clbUseObjectGroup.Items.RemoveAt(L)
        clsGeneric.ListIndex_Reset(lbObjectKind, L)
    End Sub






    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim SS As New clsSortingSearch(VariantType.String)
        For i As Integer = 0 To newObkNum - 1
            SS.Add(ObjectKind(i).Name)
        Next
        SS.AddEnd()
        If SS.SameValue_Number <> 0 Then
            Dim msgText As String = "同じオブジェクトグループ名が存在しています。"
            MsgBox(msgText, vbExclamation)
            CloseCancelF = True
            Return
        End If
    End Sub

    Private Sub clbUseLineKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbUseLineKind.SelectedIndexChanged
        Dim i = clbUseLineKind.SelectedIndex
        If i <> -1 Then
            Dim L As Integer = lbObjectKind.SelectedIndex
            ObjectKind(L).UseLineType(i) = clbUseLineKind.GetItemChecked(i)
        End If
    End Sub


    Private Sub frmMED_ObjectKind_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ObjectKind", Me)
        e.Cancel = True
    End Sub

 

End Class