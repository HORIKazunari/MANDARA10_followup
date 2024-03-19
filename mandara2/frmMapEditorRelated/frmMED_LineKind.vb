Public Class frmMED_LineKind

    Dim MapData As clsMapData
    Dim LineKind() As clsMapData.LineKind_Data
    Dim Change_Line() As Integer
    Dim newLpNum As Integer
    Dim Push_UseLine_by_ObjectKind(,) As Boolean
    Dim attrData As clsAttrData



    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef MData As clsMapData, ByRef _attrData As clsAttrData) As Windows.Forms.DialogResult
        MapData = MData
        attrData = _attrData
        ReDim LineKind(MapData.Map.LpNum - 1)
        For i As Integer = 0 To MapData.Map.LpNum - 1
            LineKind(i) = MData.LineKind(i).Clone
        Next
        newLpNum = MData.Map.LpNum

        ReDim Change_Line(newLpNum - 1)
        ReDim Push_UseLine_by_ObjectKind(MapData.Map.OBKNum - 1, newLpNum - 1)

        For i As Integer = 0 To MapData.Map.OBKNum - 1
            If MapData.ObjectKind(i).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                For j As Integer = 0 To newLpNum - 1
                    Push_UseLine_by_ObjectKind(i, j) = MapData.ObjectKind(i).UseLineType(j)
                Next
            End If
        Next

        For i As Integer = 0 To newLpNum - 1
            Change_Line(i) = i
        Next

        With lbLineKind
            .Items.Clear()
            .Items.AddRange(MapData.Get_LineKindNameList)
            .SelectedIndex = 0
        End With
        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResult(ByRef newLineKindNum As Integer, ByRef old2newLineKindNumber() As Integer, ByRef UseLine_by_ObjectKind(,) As Boolean) As clsMapData.LineKind_Data()
        ReDim old2newLineKindNumber(MapData.Map.LpNum - 1)
        For i As Integer = 0 To MapData.Map.LpNum - 1
            old2newLineKindNumber(i) = -1
        Next
        For i As Integer = 0 To newLpNum - 1
            If Change_Line(i) <> -1 Then
                old2newLineKindNumber(Change_Line(i)) = i
            End If
        Next
        UseLine_by_ObjectKind = Push_UseLine_by_ObjectKind.Clone
        newLineKindNum = newLpNum
        Return LineKind
    End Function

    Private Sub frmMED_LineKind_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_LineKind", Me)
        e.Cancel = True
    End Sub

    Private Sub frmMED_LineKind_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lbLineKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbLineKind.SelectedIndexChanged
        Dim L As Integer = lbLineKind.SelectedIndex
        If L = -1 Then
            Exit Sub
        End If
        txtNewName.Tag = "off"
        txtNewName.Text = lbLineKind.SelectedItem
        txtNewName.Tag = ""
        gbSet.Text = lbLineKind.SelectedItem
        With LineKind(L)
            clsDrawLine.Draw_Sample_LineBox(picLine, .ObjGroup(0).Pattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
            If .Mesh = enmMesh_Number.mhNonMesh Then
                txtNewName.Enabled = True
                rbLineKindObjectGroup.Enabled = True
            Else
                txtNewName.Enabled = False
                rbLineKindObjectGroup.Enabled = False
            End If
            rbLineKindNormal.Checked = False
            rbLineKindObjectGroup.Checked = False
            If .NumofObjectGroup = 1 Then
                rbLineKindNormal.Checked = True
            Else
                rbLineKindObjectGroup.Checked = True
            End If
        End With
    End Sub
    Private Sub btnUpword_Click(sender As Object, e As EventArgs) Handles _
                        btnUpword.Click, btnDownword.Click
        Dim L As Integer = lbLineKind.SelectedIndex
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
                If L = lbLineKind.Items.Count - 1 Then Exit Sub
                n = L + 1
        End Select
        With lbLineKind.Items
            .RemoveAt(L)
            .Insert(n, LineKind(L).Name)
        End With

        Dim TLK As clsMapData.LineKind_Data = LineKind(n).Clone
        LineKind(n) = LineKind(L).Clone
        LineKind(L) = TLK.Clone
        clsGeneric.SWAP(Change_Line(n), Change_Line(L))

        For i = 0 To MapData.Map.OBKNum - 1
            If MapData.ObjectKind(i).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                clsGeneric.SWAP(Push_UseLine_by_ObjectKind(i, n), Push_UseLine_by_ObjectKind(i, L))
            End If
        Next

        lbLineKind.SelectedIndex = n
    End Sub


    Private Sub btnOK_Click_1(sender As Object, e As EventArgs) Handles btnOK.Click

    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAddLineKind_Click(sender As Object, e As EventArgs) Handles btnAddLineKind.Click
        newLpNum += 1
        ReDim Preserve LineKind(newLpNum - 1)
        ReDim Preserve Push_UseLine_by_ObjectKind(MapData.Map.OBKNum - 1, newLpNum - 1)

        Dim w(lbLineKind.Items.Count - 1) As String
        For i As Integer = 0 To lbLineKind.Items.Count - 1
            w(i) = lbLineKind.Items(i)
        Next
        Dim nog As String = clsGeneric.Get_New_Numbering_Strings("新規", w)
        LineKind(newLpNum - 1) = MapData.Get_OneLineKind_Parameter(nog, clsBase.Line, enmMesh_Number.mhNonMesh)
        With lbLineKind
            .Items.Add(nog)
            .SelectedIndex = .Items.Count - 1
            txtNewName.Focus()
        End With
        ReDim Preserve Change_Line(newLpNum - 1)
        Change_Line(newLpNum - 1) = -1
    End Sub

    Private Sub btnDeleteLineKind_Click(sender As Object, e As EventArgs) Handles btnDeleteLineKind.Click
 
        If newLpNum = 1 Then
            MsgBox("線種は最低１つは必要です。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim L As Integer = lbLineKind.SelectedIndex
        If L = -1 Then
            Exit Sub
        End If

        Dim L2 As Integer = Change_Line(L)

        Dim f As Boolean = True
        If L2 <> -1 Then
            Dim LNum_by_Lkind() As Integer = MapData.Get_LineKind_Use_Number()

            If LNum_by_Lkind(L2) <> 0 Then
                MsgBox("選択した線種は" & LNum_by_Lkind(L2) & "箇所で使用されているので、削除できません", vbExclamation)
                Exit Sub
            End If
        End If
        For i As Integer = L + 1 To newLpNum - 1
            LineKind(i - 1) = LineKind(i).Clone
            For j As Integer = 0 To MapData.Map.OBKNum - 1
                Push_UseLine_by_ObjectKind(j, i - 1) = Push_UseLine_by_ObjectKind(j, i)
            Next
        Next

        For i As Integer = L To newLpNum - 2
            Change_Line(i) = Change_Line(i + 1)
        Next
        newLpNum -= 1
        ReDim Preserve Change_Line(newLpNum - 1)

        lbLineKind.Items.RemoveAt(L)
        clsGeneric.ListIndex_Reset(lbLineKind, L)
    End Sub

    Private Sub txtNewName_TextChanged(sender As Object, e As EventArgs) Handles txtNewName.TextChanged
        If txtNewName.Tag = "off" Then
            Exit Sub
        End If
        Dim i As Integer = lbLineKind.SelectedIndex
        LineKind(i).Name = txtNewName.Text
        lbLineKind.Items(i) = txtNewName.Text
        gbSet.Text = txtNewName.Text
    End Sub

    Private Sub rbLineKindNormal_CheckedChanged(sender As Object, e As EventArgs) Handles rbLineKindNormal.CheckedChanged, rbLineKindObjectGroup.CheckedChanged
        Dim L As Integer = lbLineKind.SelectedIndex
        With LineKind(L)
            Select Case True
                Case rbLineKindNormal.Checked
                    .NumofObjectGroup = 1
                    lbObjG.Items.Clear()
                    gbObjectGroup.Enabled = False
                    lblPattern.Text = "パターン"
                Case rbLineKindObjectGroup.Checked
                    gbObjectGroup.Enabled = True
                    lbObjG.Items.Clear()
                    For i As Integer = 1 To .NumofObjectGroup - 1
                        lbObjG.Items.Add(CStr(i) & ":" & MapData.ObjectKind(.ObjGroup(i).GroupNumber).Name)
                    Next
                    If lbObjG.Items.Count > 0 Then
                        lbObjG.SelectedIndex = 0
                    End If
                    lblPattern.Text = "基本パターン"
            End Select

        End With

    End Sub

    Private Sub btnObjGAdd_Click(sender As Object, e As EventArgs) Handles btnObjGAdd.Click

        Dim L As Integer = lbLineKind.SelectedIndex
        Dim ObjL As New List(Of String)
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            ObjL.Add(MapData.ObjectKind(i).Name)
        Next
        Dim n As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("オブジェクトグループ", ObjL)
        If n <> -1 Then
            Dim adn As Integer = lbObjG.Items.Count + 1
            lbObjG.Items.Add(CStr(adn) & ":" & ObjL(n))
            With LineKind(L)
                ReDim Preserve .ObjGroup(adn)

                .ObjGroup(adn).GroupNumber = n
                .ObjGroup(adn).UseOnly = False
                .ObjGroup(adn).Pattern = .ObjGroup(adn - 1).Pattern
                .NumofObjectGroup += 1
            End With
            lbObjG.SelectedIndex = adn - 1
        End If
    End Sub

    Private Sub btnObjDelete_Click(sender As Object, e As EventArgs) Handles btnObjDelete.Click
        If lbObjG.Items.Count = 0 Then Exit Sub

        Dim n As Integer = lbObjG.SelectedIndex + 1
        If n = 0 Then Exit Sub

        Dim L As Integer = lbLineKind.SelectedIndex
        lbObjG.Items.RemoveAt(n - 1)
        With LineKind(L)
            For i As Integer = n + 1 To .NumofObjectGroup - 1
                .ObjGroup(i - 1) = .ObjGroup(i)
            Next
            .NumofObjectGroup -= 1
            ReDim Preserve .ObjGroup(.NumofObjectGroup - 1)
            For i As Integer = 1 To .NumofObjectGroup - 1
                lbObjG.Items(i - 1) = CStr(i) & ":" & MapData.ObjectKind(.ObjGroup(i).GroupNumber).Name
            Next
        End With
        clsGeneric.ListIndex_Reset(lbObjG, n - 1)
    End Sub

    Private Sub btnObjUpward_Click(sender As Object, e As EventArgs) Handles btnObjUpward.Click, btnObjDownward.Click
        Dim L As Integer = lbLineKind.SelectedIndex
        Dim n As Integer = lbObjG.SelectedIndex + 1
        Dim newN As Integer

        Select Case sender.name
            Case "btnObjUpward"
                If n = 1 Then Exit Sub
                newN = n - 1
            Case "btnObjDownward"
                If n = lbObjG.Items.Count Then Exit Sub
                newN = n + 1
        End Select
        With LineKind(L)
            Dim TObk As New clsMapData.strLKOjectGroup_Info
            TObk = .ObjGroup(newN)
            .ObjGroup(newN) = .ObjGroup(n)
            .ObjGroup(n) = TObk
            For i As Integer = 1 To .NumofObjectGroup - 1
                lbObjG.Items(i - 1) = CStr(i) & ":" & MapData.ObjectKind(.ObjGroup(i).GroupNumber).Name
            Next
        End With
        lbObjG.SelectedIndex = newN - 1
    End Sub

    Private Sub lbObjG_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbObjG.SelectedIndexChanged
        Dim L As Integer = lbLineKind.SelectedIndex
        Dim n As Integer = lbObjG.SelectedIndex + 1
        cbObjG.Checked = LineKind(L).ObjGroup(n).UseOnly
        clsDrawLine.Draw_Sample_LineBox(picObjGLine, LineKind(L).ObjGroup(n).Pattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
    End Sub

    Private Sub cbObjG_CheckedChanged(sender As Object, e As EventArgs) Handles cbObjG.CheckedChanged
        Dim L As Integer = lbLineKind.SelectedIndex
        Dim n As Integer = lbObjG.SelectedIndex + 1
        LineKind(L).ObjGroup(n).UseOnly = cbObjG.Checked
    End Sub

    Private Sub picLine_Click(sender As Object, e As EventArgs) Handles picLine.Click
        Dim L As Integer = lbLineKind.SelectedIndex
        If clsGeneric.Line_Pattern_select(LineKind(L).ObjGroup(0).Pattern, True, attrData) = True Then
            clsDrawLine.Draw_Sample_LineBox(picLine, LineKind(L).ObjGroup(0).Pattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End If

    End Sub

    Private Sub picObjGLine_Click(sender As Object, e As EventArgs) Handles picObjGLine.Click
        Dim L As Integer = lbLineKind.SelectedIndex
        Dim n As Integer = lbObjG.SelectedIndex + 1
        If clsGeneric.Line_Pattern_select(LineKind(L).ObjGroup(n).Pattern, True, attrData) = True Then
            clsDrawLine.Draw_Sample_LineBox(picObjGLine, LineKind(L).ObjGroup(n).Pattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End If
    End Sub


    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub gbSet_Enter(sender As Object, e As EventArgs) Handles gbSet.Enter

    End Sub
End Class