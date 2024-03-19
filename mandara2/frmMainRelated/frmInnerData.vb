Public Class frmInnerData
    Dim CloseCancelF As Boolean
    Private Sub frmMED_LineCodeTime_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef attrData As clsAttrData) As Windows.Forms.DialogResult
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        Dim LayerNum As Integer = attrData.TotalData.LV1.SelectedLayer
        Dim DataNum As Integer = attrData.LayerData(LayerNum).atrData.SelectedIndex
        Dim Hatch_Enabelad As Boolean
        Dim Indata As clsAttrData.strInner_Data_Info
        With attrData.LayerData(LayerNum).atrData.Data(DataNum)
            Select Case .ModeData
                Case enmSoloMode_Number.ClassMarkMode
                    Indata = .SoloModeViewSettings.ClassMarkMD
                    Hatch_Enabelad = True
                    For i As Integer = 0 To .SoloModeViewSettings.Div_Num - 1
                        If .SoloModeViewSettings.Class_Div(i).ClassMark.PrintMark <> enmMarkPrintType.Mark Then
                            Hatch_Enabelad = False
                        End If
                    Next
                Case enmSoloMode_Number.MarkSizeMode, enmSoloMode_Number.MarkBlockMode, enmSoloMode_Number.MarkTurnMode, enmSoloMode_Number.MarkBarMode
                    Indata = .SoloModeViewSettings.MarkCommon.Inner_Data
                    If .SoloModeViewSettings.MarkSizeMD.Mark.PrintMark = enmMarkPrintType.Mark And
                            attrData.LayerData(LayerNum).Shape <> enmShape.LineShape Then
                        Hatch_Enabelad = True
                    Else
                        Hatch_Enabelad = False
                    End If
                Case enmSoloMode_Number.StringMode
                    Indata = .SoloModeViewSettings.MarkCommon.Inner_Data
                    Hatch_Enabelad = False
            End Select

        End With
        rbHatch.Enabled = Hatch_Enabelad
        If Indata.Mode = clsAttrData.enmInner_Data_Info_Mode.ClassPaint Then
            rbPaint.Checked = True
        Else
            rbHatch.Checked = True
        End If
        attrData.Set_DataTitle_to_cboBox(cboData, LayerNum, Indata.Data, True, True, True, False)
        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResults() As clsAttrData.strInner_Data_Info
        Dim Indata As clsAttrData.strInner_Data_Info
        With Indata
            If rbPaint.Checked = True Then
                .Mode = clsAttrData.enmInner_Data_Info_Mode.ClassPaint
            Else
                .Mode = clsAttrData.enmInner_Data_Info_Mode.ClassHatch
            End If
            .Data = cboData.SelectedIndex
            .Flag = chkInnerData.Checked
        End With
        Return Indata
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If cboData.SelectedIndex = -1 Then
            MsgBox("データ項目を選択してください。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
        End If
    End Sub

    Private Sub rbPaint_CheckedChanged(sender As Object, e As EventArgs) Handles rbPaint.CheckedChanged, rbHatch.CheckedChanged
        chkInnerData.Checked = True
    End Sub

    Private Sub cboData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboData.SelectedIndexChanged
        chkInnerData.Checked = True
    End Sub

    Private Sub frmInnerData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class