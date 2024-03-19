Public Class frmMakeLineParallelPattern
    Dim LinePattern As Line_Property

    Public Overloads Function ShowDialog(ByVal LinePat As Line_Property) As Windows.Forms.DialogResult

        LinePattern = LinePat
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Center)
        For si As Single = 0.1 To 0.95 Step 0.1
            cboPartsWidth.Items.Add(FormatNumber(si, 1))
        Next
        For si As Single = 1 To 3 Step 0.5
            cboPartsWidth.Items.Add(FormatNumber(si, 1))
        Next

        With LinePattern.ParallelLine
            cboPartsWidth.Text = .Interval
            cbCenterLine.Checked = .Center_Line_f
            cbInnerCol.Checked = .InnerColor_f
            picCol.BackColor = .InnerColor.getColor
            cbCenterLinePat.Checked = .CenterLine_ParaLine_f
            Select Case .P_CenterLine.pattern
                Case enmLinePattern.Solid
                    rbSolidLine.Checked = True
                Case enmLinePattern.BROKEN
                    rbBrokenLine.Checked = True
            End Select
        End With
        Return Me.ShowDialog()
    End Function

    Public Function getResult() As Line_Property
        With LinePattern.ParallelLine
            .Interval = Val(cboPartsWidth.Text)
            .Center_Line_f = cbCenterLine.Checked
            .InnerColor_f = cbInnerCol.Checked
            .InnerColor = New colorARGB(picCol.BackColor)
            .CenterLine_ParaLine_f = cbCenterLinePat.Checked
            Select Case True
                Case rbSolidLine.Checked
                    .P_CenterLine.pattern = enmLinePattern.Solid
                Case rbBrokenLine.Checked
                    .P_CenterLine.pattern = enmLinePattern.BROKEN
            End Select
        End With
        Return LinePattern
    End Function

    Private Sub rbSolidLine_CheckedChanged(sender As Object, e As EventArgs) Handles rbSolidLine.CheckedChanged, rbBrokenLine.CheckedChanged
        Select True
            Case rbSolidLine.Checked
                btnSolidSet.Enabled = True
                btnBrokenSet.Enabled = False
                LinePattern.ParallelLine.P_CenterLine.pattern = enmLinePattern.Solid
            Case rbBrokenLine.Checked
                btnSolidSet.Enabled = False
                btnBrokenSet.Enabled = True
                LinePattern.ParallelLine.P_CenterLine.pattern = enmLinePattern.BROKEN
        End Select

    End Sub

    Private Sub cbInnerCol_CheckedChanged(sender As Object, e As EventArgs) Handles cbInnerCol.CheckedChanged
        picCol.Enabled = cbInnerCol.Checked
    End Sub

    Private Sub cbCenterLinePat_CheckedChanged(sender As Object, e As EventArgs) Handles cbCenterLinePat.CheckedChanged
        gbCenterLinePat.Enabled = Not cbCenterLinePat.Checked
    End Sub

    Private Sub btnSolidSet_Click(sender As Object, e As EventArgs) Handles btnSolidSet.Click
        Dim form As New frmMakeLineSolidPattern
        If form.ShowDialog(LinePattern.ParallelLine.P_CenterLine) = Windows.Forms.DialogResult.OK Then
            LinePattern.ParallelLine.P_CenterLine = form.getResult()
        End If
        form.Dispose()
    End Sub

    Private Sub picCol_Click(sender As Object, e As EventArgs) Handles picCol.Click
        Dim col As colorARGB = New colorARGB(picCol.BackColor)
        If clsGeneric.Color_Set(col) = True Then
            picCol.BackColor = col.getColor
        End If
    End Sub

    Private Sub btnBrokenSet_Click(sender As Object, e As EventArgs) Handles btnBrokenSet.Click
        Dim form As New frmMakeLineBrokenPattern
        If form.ShowDialog(LinePattern.ParallelLine.P_CenterLine) = Windows.Forms.DialogResult.OK Then
            LinePattern.ParallelLine.P_CenterLine = form.getResult()
        End If
        form.Dispose()
    End Sub
End Class