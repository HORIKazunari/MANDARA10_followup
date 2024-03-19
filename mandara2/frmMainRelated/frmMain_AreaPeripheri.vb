Public Class frmMain_AreaPeripheri
    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData
    Dim LayerNum As Integer
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

        Select Case attrData.LayerData(LayerNum).Shape
            Case enmShape.PolygonShape
                rbArea.Enabled = True
                rbPeripheri.Enabled = True
                rbArea.Checked = True
            Case enmShape.LineShape
                rbArea.Enabled = False
                rbPeripheri.Enabled = True
                rbPeripheri.Checked = True
            Case Else
                rbArea.Enabled = False
                rbPeripheri.Enabled = False
        End Select
        clsGeneric.SetScaleUnit_to_Cbobox(cboScaleUnit)
        cboScaleUnit.Text = clsGeneric.getScaleUnitStrings(enmScaleUnit.kilometer)

        Return Me.ShowDialog

    End Function
    Public Function GetResults()

    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim n As Integer = attrData.Get_ObjectNum(LayerNum)
        Dim Data_Val_STR(n - 1) As String
        Dim Title As String = ""

        Dim note As String = ""
        Dim MisF As Boolean = False
        Dim ScaleUnit As mandara10.enmScaleUnit = clsGeneric.getScaleUnit_from_Strings(cboScaleUnit.Text)
        Dim ScaleRatio As Single = clsGeneric.Convert_ScaleUnit(enmScaleUnit.kilometer, ScaleUnit)
        Dim SUnit As String = clsGeneric.getScaleUnitStrings(ScaleUnit)
        Dim Unit As String = ""

        Select True
            Case rbArea.Checked
                For i As Integer = 0 To n - 1
                    Dim v As Single = attrData.GetObjMenseki(LayerNum, i) * ScaleRatio ^ 2
                    Data_Val_STR(i) = CStr(v)
                Next
                Title = "計測面積"
                Unit = clsGeneric.getScaleUnitAreaStrings(ScaleUnit)
            Case rbPeripheri.Checked
                For i As Integer = 0 To n - 1
                    Dim v As Single = attrData.Get_ObjectLength(LayerNum, i) * ScaleRatio
                    Data_Val_STR(i) = CStr(v)
                Next
                Title = "計測周長"
                Unit = SUnit
        End Select
        Dim form As New frmTitleSettingsAddingData
        If form.ShowDialog(Title, Unit, note, True) = Windows.Forms.DialogResult.OK Then
            form.getResult(Title, Unit, note)
            attrData.Add_One_Data_Value(LayerNum, Title, Unit, note, Data_Val_STR, MisF)
            form.Dispose()
        Else
            form.Dispose()
            btnCancel.PerformClick()
        End If
    End Sub
    Private Sub frmMain_AreaPeripheri_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_AreaPeripheri", Me)

    End Sub

    Private Sub frmMain_AreaPeripheri_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class