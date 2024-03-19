Public Class frmMED_ObjectTimeNameList
    Private Structure NameListInfo
        Public Name As String
        Public Origin As Integer
        Public Overrides Function toString() As String
            Return Name
        End Function
    End Structure
    Dim CloseCancelF As Boolean
    Dim ObjectGroup As clsMapData.strObjectGroup_Data
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
    Public Overloads Function ShowDialog(ByRef _ObjectGroup As clsMapData.strObjectGroup_Data) As Windows.Forms.DialogResult
        ObjectGroup = _ObjectGroup.Clone
        lblGroupName.Text = "オブジェクトグループ：" + ObjectGroup.Name
        For i As Integer = 0 To ObjectGroup.ObjectNameNum - 1
            Dim itm As NameListInfo
            itm.Name = ObjectGroup.ObjectNameList(i)
            itm.Origin = i
            lbName.Items.Add(itm)
        Next
        lbName.SelectedIndex = 0
        Return Me.ShowDialog

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Convert">-1は新規、0以上は変更前のオブジェクト名リストの位置</param>
    ''' <param name="NameList">変更後のリストの名称</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResults(ByRef Convert() As Integer, ByRef NameList() As String) As clsMapData.strObjectGroup_Data
        Dim n As Integer = lbName.Items.Count
        ReDim Convert(n - 1)
        ReDim NameList(n - 1)
        For i As Integer = 0 To n - 1
            Dim itm As NameListInfo = CType(lbName.Items(i), NameListInfo)
            NameList(i) = itm.Name
            Convert(i) = itm.Origin
        Next
    End Function

    Private Sub lbName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbName.SelectedIndexChanged
        If lbName.SelectedIndex < 0 Or lbName.Tag = "OFF" Then
            Return
        End If
        Dim itm As NameListInfo = CType(lbName.SelectedItem, NameListInfo)
        txtName.Tag = "OFF"
        txtName.Text = itm.Name
        txtName.Tag = ""
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lbName.Items.Count = 1 Then
            MsgBox("これ以上削除できません。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim n As Integer = lbName.SelectedIndex
        lbName.Items.RemoveAt(n)
        clsGeneric.ListIndex_Reset(lbName, n)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim itm As NameListInfo
        Dim tx(lbName.Items.Count - 1) As String
        For i As Integer = 0 To lbName.Items.Count - 1
            tx(i) = lbName.Items(i).ToString
        Next
        itm.Name = clsGeneric.Get_New_Numbering_Strings("オブジェクト名", tx)
        itm.Origin = -1
        lbName.Items.Add(itm)
        lbName.SelectedIndex = lbName.Items.Count - 1
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        If lbName.SelectedIndex < 0 Or txtName.Tag = "OFF" Then
            Return
        End If
        Dim itm As NameListInfo = CType(lbName.SelectedItem, NameListInfo)
        itm.Name = txtName.Text
        lbName.Tag = "OFF"
        lbName.Items(lbName.SelectedIndex) = itm
        lbName.Tag = ""

    End Sub

    Private Sub btnCategoryUp_Click(sender As Object, e As EventArgs) Handles btnCategoryUp.Click
        If lbName.Items.Count = 1 Then
            Return
        End If
        Dim n As Integer = lbName.SelectedIndex
        Dim n2 As Integer = n - 1
        If n2 = -1 Then
            n2 = lbName.Items.Count - 1
        End If
        swapList(n, n2)
        lbName.SelectedIndex = n2
    End Sub
    Private Sub btnCategoryDown_Click(sender As Object, e As EventArgs) Handles btnCategoryDown.Click
        If lbName.Items.Count = 1 Then
            Return
        End If
        Dim n As Integer = lbName.SelectedIndex
        Dim n2 As Integer = n + 1
        If n2 = lbName.Items.Count Then
            n2 = 0
        End If
        swapList(n, n2)
        lbName.SelectedIndex = n2

    End Sub
    Private Sub swapList(ByVal d1 As Integer, ByVal d2 As Integer)
        Dim itm1 As NameListInfo = CType(lbName.Items(d1), NameListInfo)
        Dim itm2 As NameListInfo = CType(lbName.Items(d2), NameListInfo)
        lbName.Items(d1) = itm2
        lbName.Items(d2) = itm1

    End Sub

    Private Function n() As Integer
        Throw New NotImplementedException
    End Function

    Private Sub frmMED_ObjectTimeNameList_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ObjectTimeNameList", Me)
        e.Cancel = True
    End Sub
End Class