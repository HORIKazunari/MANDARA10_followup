Public Class frmPrint_LinkEdit
    Dim CloseCancelF As Boolean
    Dim attr As clsAttrData
    Dim Layernum As Integer
    Dim ObjNum As Integer
    Public Link As List(Of clsAttrData.strURL_Data)


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
    Public Overloads Function ShowDialog(ByRef _attr As clsAttrData, ByVal _lay As Integer, ByVal _obj As Integer) As Windows.Forms.DialogResult
        ObjNum = _obj
        Layernum = _lay
        attr = _attr
        lbLink.Items.Clear()
        With attr.LayerData(Layernum).atrObject.atrObjectData(ObjNum)
            Link = New List(Of clsAttrData.strURL_Data)()
            For i As Integer = 0 To .HyperLinkNum - 1
                Dim dt As clsAttrData.strURL_Data = .HyperLink(i)
                Link.Add(dt)
                lbLink.Items.Add(dt.Name + "/" + dt.Address)
            Next
            If .HyperLinkNum <> 0 Then
                lbLink.SelectedIndex = 0
                gbLinkEdit.Visible = True
            Else
                gbLinkEdit.Visible = False
            End If
        End With
        Return Me.ShowDialog

    End Function
    Private Sub lbLink_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbLink.SelectedIndexChanged
        Dim i As Integer = lbLink.SelectedIndex
        If i = -1 Then
            Return
        Else
            Dim dt As clsAttrData.strURL_Data = Link(i)
            txtName.Text = dt.Name
            txtURL.Text = dt.Address
        End If

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        For Each dt As clsAttrData.strURL_Data In Link
            If dt.Address = "" Or dt.Name = "" Then
                MsgBox("リンクの名称またはURLの設定していない項目があります。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Return
            End If
        Next
        With attr.LayerData(Layernum).atrObject.atrObjectData(ObjNum)
            .HyperLinkNum = Link.Count
            If .HyperLinkNum = 0 Then
                Erase .HyperLink
            Else
                ReDim .HyperLink(.HyperLinkNum - 1)
                For i As Integer = 0 To .HyperLinkNum - 1
                    .HyperLink(i) = Link(i)
                Next
            End If
        End With
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged, txtURL.TextChanged
        Dim i As Integer = lbLink.SelectedIndex
        Dim dt As clsAttrData.strURL_Data = Link(i)
        dt.Name = txtName.Text
        dt.Address = txtURL.Text
        Link(i) = dt
        lbLink.Items(i) = dt.Name + "/" + dt.Address
    End Sub

    Private Sub btnLinkAdd_Click(sender As Object, e As EventArgs) Handles btnLinkAdd.Click
        Dim dt As clsAttrData.strURL_Data
        dt.Name = ""
        dt.Address = ""
        Link.Add(dt)
        lbLink.Items.Add("/")
        lbLink.SelectedIndex = Link.Count - 1
        gbLinkEdit.Visible = True
    End Sub

    Private Sub btnLinkDelete_Click(sender As Object, e As EventArgs) Handles btnLinkDelete.Click
        Dim i As Integer = lbLink.SelectedIndex
        If i <> -1 Then
            Link.RemoveAt(i)
            lbLink.Items.RemoveAt(i)
            If lbLink.Items.Count = 0 Then
                gbLinkEdit.Visible = False
            Else
                clsGeneric.ListIndex_Reset(lbLink, i)
            End If
        End If
    End Sub

    Private Sub btnFileSelect_Click(sender As Object, e As EventArgs) Handles btnFileSelect.Click
        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        ofd.FileName = ""
        If ofd.ShowDialog() = DialogResult.OK Then
            txtURL.Text = ofd.FileName
        End If

    End Sub
End Class