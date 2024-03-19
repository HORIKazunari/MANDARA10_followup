Public Class frmMain_ObjectLimitaion
    Dim CloseCancelF As Boolean
    Dim attData As clsAttrData
    Dim LayerNum As Integer
    Dim ObjectCheck As New List(Of Boolean())
    Dim LayerObjVisible() As Boolean
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
    Public Overloads Function ShowDialog(ByRef _attData As clsAttrData) As Windows.Forms.DialogResult
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        attData = _attData
        LayerNum = attData.TotalData.LV1.SelectedLayer

        Me.Tag = "OFF"
        With attData
            If .LayerData(LayerNum).Type = clsAttrData.enmLayerType.Trip Then
                LayerNum = attData.Get_Trip_Definition_Layer_Number
            End If
            For i As Integer = 0 To .TotalData.LV1.Lay_Maxn - 1
                If .LayerData(i).Type = clsAttrData.enmLayerType.Trip Then
                    Dim objVisible(0) As Boolean
                    ObjectCheck.Add(objVisible)
                Else
                    Dim n As Integer = attData.Get_ObjectNum(i)
                    Dim objVisible(n - 1) As Boolean
                    For j As Integer = 0 To n - 1
                        objVisible(j) = .LayerData(i).atrObject.atrObjectData(j).Visible
                    Next
                    ObjectCheck.Add(objVisible)
                End If
            Next
            chkObjectLimitaion.Checked = .TotalData.ViewStyle.ObjectLimitationF
            chkInvisibleObjectBoundary.Checked = .TotalData.ViewStyle.InVisibleObjectBoundaryF
        End With
        attData.Set_LayerName_to(cboLayer, LayerNum, True, True, True, True, True, False)
        cboLayer.SelectedIndex = LayerNum
        Me.Tag = ""
        SetCheckBox()
        Return Me.ShowDialog
    End Function
    Public Function GetResults()
        For i As Integer = 0 To cbObj.Items.Count - 1
            LayerObjVisible(i) = cbObj.GetItemChecked(i)
        Next

        With attData
            .TotalData.ViewStyle.ObjectLimitationF = chkObjectLimitaion.Checked
            .TotalData.ViewStyle.InVisibleObjectBoundaryF = chkInvisibleObjectBoundary.Checked
            For i As Integer = 0 To ObjectCheck.Count - 1
                If .LayerData(i).Type <> clsAttrData.enmLayerType.Trip Then
                    Dim LV As Boolean() = ObjectCheck(i)
                    For j As Integer = 0 To LV.Length - 1
                        .LayerData(i).atrObject.atrObjectData(j).Visible = LV(j)
                    Next
                End If
            Next
        End With
    End Function

    Private Sub cboLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayer.SelectedIndexChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        For i As Integer = 0 To cbObj.Items.Count - 1
            LayerObjVisible(i) = cbObj.GetItemChecked(i)
        Next
        LayerNum = cboLayer.SelectedIndex
        SetCheckBox()
    End Sub
    Private Sub SetCheckBox()
        LayerObjVisible = ObjectCheck(LayerNum)
        cbObj.BeginUpdate()
        cbObj.Items.Clear()
        For i As Integer = 0 To LayerObjVisible.Length - 1
            cbObj.Items.Add(attData.Get_KenObjName(LayerNum, i))
            cbObj.SetItemChecked(i, LayerObjVisible(i))
        Next
        cbObj.EndUpdate()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub chkObjectLimitaion_CheckedChanged(sender As Object, e As EventArgs) Handles chkObjectLimitaion.CheckedChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkInvisibleObjectBoundary.CheckedChanged

    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_ObjectLimitaion", Me)
    End Sub


    Private Sub cbObj_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbObj.SelectedIndexChanged
        chkObjectLimitaion.Checked = True
    End Sub
End Class