Public Class frmMain_CopyDataItemSettings
    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData
    Private Sub MeFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData, ByVal LayerNum As Integer, ByVal DataNum As Integer) As DialogResult
        attrData = _attrData
        Me.Tag = "OFF"
        attrData.Set_LayerName_to(cboCopyLayer, LayerNum)
        cboCopyData.SelectedIndex = DataNum
        attrData.Set_LayerName_to(cboDestinationLayer, LayerNum)
        If attrData.TotalData.LV1.Lay_Maxn = 1 And attrData.LayerData(0).Name = "" Then
            lblOLay.Visible = False
            lblDlay.Visible = False
            cboCopyLayer.Visible = False
            cboDestinationLayer.Visible = False
            lblOData.Location = lblOLay.Location
            cboCopyData.Location = cboCopyLayer.Location
        End If
        Me.Tag = ""
        setDestDataItem()
        Return Me.ShowDialog()
    End Function

    Private Sub cboCopyLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCopyLayer.SelectedIndexChanged
        attrData.Set_DataTitle_to_cboBox(cboCopyData, cboCopyLayer.SelectedIndex, 0)
    End Sub

    Private Sub cboDestinationLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDestinationLayer.SelectedIndexChanged
        setDestDataItem()
    End Sub
    Private Sub setDestDataItem()
        If Me.Tag = "" Then
            Dim OLayer As Integer = cboCopyLayer.SelectedIndex
            Dim Dlyaer As Integer = cboDestinationLayer.SelectedIndex
            Dim OData As Integer = cboCopyData.SelectedIndex
            Dim Otype As enmAttDataType = attrData.LayerData(OLayer).atrData.Data(OData).DataType
            Dim astn As Integer = -1
            If OLayer = Dlyaer Then
                astn = OData
            End If
            attrData.Set_DataTitle_to_ListBox(lbDestinationData, Dlyaer, True, Otype = enmAttDataType.Normal, Otype = enmAttDataType.Category, Otype = enmAttDataType.Strings, astn)
        End If
    End Sub

    Private Sub cboCopyData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCopyData.SelectedIndexChanged
        setDestDataItem()

    End Sub
    Public Sub getResults(ByRef _attrData As clsAttrData)

        Dim OLayer As Integer = cboCopyLayer.SelectedIndex
        Dim Dlyaer As Integer = cboDestinationLayer.SelectedIndex
        Dim OData As Integer = cboCopyData.SelectedIndex

        Dim ClassCopyF As Boolean = chkClassMode.Checked
        Dim MarkCopyF As Boolean = chkMarkMode.Checked
        Dim ContourCopyF As Boolean = chkContour.Checked
        Dim ODOriginCopyF As Boolean = chkODOriginCopy.Checked
        Dim MarkSizeValueCopyF As Boolean = chkODMarkSizeValueCopy.Checked

        For i As Integer = 0 To lbDestinationData.SelectedIndices.Count - 1
            Dim n As Integer = lbDestinationData.SelectedIndices(i)
            _attrData.Set_Legend(Dlyaer, n, _attrData.LayerData(OLayer).atrData.Data(OData), ClassCopyF, MarkCopyF, MarkSizeValueCopyF, MarkCopyF,
                                 ContourCopyF, ClassCopyF, ClassCopyF, ClassCopyF, MarkCopyF, MarkCopyF, MarkCopyF, ODOriginCopyF, (Dlyaer = OLayer))


        Next

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If lbDestinationData.SelectedIndices.Count = 0 Then
            MsgBox("コピー先が選択されていません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
        End If
    End Sub


    Private Sub frmMain_CopyDataItemSettings_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_CopyDataItemSettings", Me)
    End Sub


End Class