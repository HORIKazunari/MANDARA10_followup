Public Class frmMain_ExchangeObjectName
    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData
    Dim LayerNum As Integer
    Dim USeMap As clsMapData
    Dim selObjG As Integer()
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
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData) As Windows.Forms.DialogResult
        attrData = _attrData
        LayerNum = attrData.TotalData.LV1.SelectedLayer
        lblLayer.Text = "レイヤ：" + attrData.LayerData(LayerNum).Name

        USeMap = attrData.LayerData(LayerNum).MapFileData
        Dim obkn As Integer = USeMap.Map.OBKNum
        Dim UseObjectKind(obkn - 1) As Boolean
        For i As Integer = 0 To attrData.Get_ObjectNum(LayerNum) - 1
            With attrData.LayerData(LayerNum).atrObject.atrObjectData(i)
                If .Objectstructure = enmKenCodeObjectstructure.MapObj Then
                    Dim k As Integer = USeMap.MPObj(.MpObjCode).Kind
                    UseObjectKind(k) = True
                End If
            End With
        Next

        Dim n As Integer = clsGeneric.Get_Specified_Value_Array(UseObjectKind, obkn, True, selObjG)
        For i As Integer = 0 To n - 1
            cboObjectGroup.Items.Add(USeMap.ObjectKind(selObjG(i)).Name)
        Next
        cboObjectGroup.SelectedIndex = 0

        Return Me.ShowDialog

    End Function
    Public Function GetResults(ByRef ObjG As Integer, ByRef ObjNameListNum As Integer)
        ObjG = selObjG(cboObjectGroup.SelectedIndex)
        ObjNameListNum = cboObjectNameList.SelectedIndex
    End Function

    Private Sub cboObjectGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboObjectGroup.SelectedIndexChanged
        cboObjectNameList.Items.Clear()
        Dim n As Integer = selObjG(cboObjectGroup.SelectedIndex)
        cboObjectNameList.Items.AddRange(USeMap.ObjectKind(n).ObjectNameList)
        cboObjectNameList.SelectedIndex = 0
    End Sub

    Private Sub frmMain_ExchangeObjectName_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_ExchangeObjectName", Me)
    End Sub
End Class