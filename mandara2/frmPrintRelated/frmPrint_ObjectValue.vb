Public Class frmPrint_ObjectValue
    Dim attrData As clsAttrData
    Dim dt As clsAttrData.strValueShow_Info
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData) As Windows.Forms.DialogResult
        cboDecimalNumber.Items.Clear()
        For i As Integer = 0 To 4
            cboDecimalNumber.Items.Add(i)
        Next
        With _attrData.TotalData.ViewStyle.ValueShow
            dt.ObjNameFont = .ObjNameFont
            dt.ValueFont = .ValueFont
            chkName.Checked = .ObjNameVisible
            chkValue.Checked = .ValueVisible
            chkDecimalSepaF.Checked = .DecimalSepaF
            cboDecimalNumber.SelectedIndex = .DecimalNumber
        End With
        attrData = _attrData
        Return Me.ShowDialog
    End Function
    Public Function GetResults() As clsAttrData.strValueShow_Info
        With dt
            .ObjNameVisible = chkName.Checked
            .ValueVisible = chkValue.Checked
            .DecimalSepaF = chkDecimalSepaF.Checked
            .DecimalNumber = cboDecimalNumber.SelectedIndex
        End With
        Return dt
    End Function

    Private Sub btnNameFont_Click(sender As Object, e As EventArgs) Handles btnNameFont.Click
        clsGeneric.Font_select(dt.ObjNameFont, attrData)
    End Sub

    Private Sub btnValueFont_Click(sender As Object, e As EventArgs) Handles btnValueFont.Click
        clsGeneric.Font_select(dt.ValueFont, attrData)

    End Sub
End Class