Public Class frmSyntheticObject
    Dim SyntheticObjName As New List(Of String())
    Dim SynLay As New List(Of Integer)
    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData

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
    Public Overloads Function ShowDialog(ByRef _attr As clsAttrData, ByVal defLayer As Integer, ByVal defObj As Integer) As Windows.Forms.DialogResult
        attrData = _attr
        cboSynLayer.Items.Clear()
        For i As Integer = 0 To attrData.TotalData.LV1.Lay_Maxn - 1
            With attrData.LayerData(i)
                If .atrObject.NumOfSyntheticObj > 0 Then
                    SynLay.Add(i)
                    cboSynLayer.Items.Add(.Name)
                    With .atrObject
                        Dim LayObjName(.NumOfSyntheticObj - 1) As String
                        For j As Integer = 0 To .NumOfSyntheticObj - 1
                            LayObjName(j) = .MPSyntheticObj(j).Name
                        Next
                        SyntheticObjName.Add(LayObjName)
                    End With
                End If
            End With
        Next
        If defLayer = -1 Then
            defLayer = 0
        Else
            defLayer = SynLay.IndexOf(defLayer)
            If defLayer = -1 Then
                defObj = 0
                defLayer = 0
            End If
        End If
        If defObj = -1 Then
            defObj = 0
        End If
        cboSynLayer.SelectedIndex = defLayer
        lbSynObjects.SelectedIndex = defObj
        Return Me.ShowDialog

    End Function


    Private Sub frmSyntheticObject_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.SubWindow, "frmSyntheticObject")
        e.Cancel = True
    End Sub

    Private Sub cboSynLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSynLayer.SelectedIndexChanged
        Dim n As Integer = cboSynLayer.SelectedIndex
        lbSynObjects.Items.Clear()
        lbSynObjects.Items.AddRange(SyntheticObjName(n))
        lbSynObjects.SelectedIndex = 0
    End Sub

    Private Sub lbSynObjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbSynObjects.SelectedIndexChanged
        If lbSynObjects.Tag = "OFF" Then
            Return
        End If
        Dim n As Integer = lbSynObjects.SelectedIndex
        txtObjName.Tag = "OFF"
        lbIncludingObject.Items.Clear()
        If n <> -1 Then
            Dim L As Integer = cboSynLayer.SelectedIndex
            txtObjName.Text = SyntheticObjName(L)(n)
            Dim L2 As Integer = SynLay(L)
            With attrData.LayerData(L2).atrObject.MPSyntheticObj(n)
                For i As Integer = 0 To .NumOfObject - 1
                    lbIncludingObject.Items.Add(.Objects(i).Name)
                Next
            End With
        Else
            txtObjName.Text = ""
        End If
        txtObjName.Tag = ""
    End Sub

    Private Sub txtObjName_TextChanged(sender As Object, e As EventArgs) Handles txtObjName.TextChanged
        If txtObjName.Tag = "OFF" Then
            Return
        End If
        Dim n As Integer = lbSynObjects.SelectedIndex
        If n <> -1 Then
            lbSynObjects.Tag = "OFF"
            Dim L As Integer = cboSynLayer.SelectedIndex
            lbSynObjects.Items(n) = txtObjName.Text
            Dim name() As String = SyntheticObjName(L)
            name(n) = txtObjName.Text
            lbSynObjects.Tag = ""
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        For i As Integer = 0 To SynLay.Count - 1
            Dim name() As String = SyntheticObjName(i)
            Dim L As Integer = SynLay(i)
            For j As Integer = 0 To name.Length - 1
                attrData.LayerData(L).atrObject.MPSyntheticObj(j).Name = name(j)
            Next
            With attrData.LayerData(L).atrObject
                For j As Integer = 0 To .ObjectNum - 1
                    With .atrObjectData(j)
                        If .Objectstructure = enmKenCodeObjectstructure.SyntheticObj Then
                            .Name = name(.MpObjCode)
                        End If
                    End With
                Next
            End With
        Next
    End Sub
End Class