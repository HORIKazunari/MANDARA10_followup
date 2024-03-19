Public Class frmMakeLineSolidPattern
    Dim LinePattern As Line_Basic_Data_Info

    Public Overloads Function ShowDialog(ByVal LinePat As Line_Basic_Data_Info) As Windows.Forms.DialogResult

        LinePattern = LinePat
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Center)
        cbLineWidth.Items.Add("最小")
        For si As Single = 0.1 To 0.9 Step 0.1
            cbLineWidth.Items.Add(FormatNumber(si, 1))
        Next
        For j As Integer = 1 To 5
            cbLineWidth.Items.Add(FormatNumber(j, 1))
        Next

        picColor.BackColor = LinePat.SolidLine.Color.getColor
        With LinePat.SolidLine
            If .Width = 0 Then
                cbLineWidth.SelectedIndex = 0
            Else
                cbLineWidth.Text = FormatNumber(.Width, 1)
            End If
        End With
        Return Me.ShowDialog()
    End Function

    Public Function getResult() As Line_Basic_Data_Info
        LinePattern.SolidLine.Color = New colorARGB(picColor.BackColor)
        LinePattern.SolidLine.Width = Val(cbLineWidth.Text)
        Return LinePattern
    End Function

    Private Sub picColor_Click(sender As Object, e As EventArgs) Handles picColor.Click
        Dim col As colorARGB = New colorARGB(picColor.BackColor)
        If clsGeneric.Color_Set(col) = True Then
            picColor.BackColor = col.getColor
        End If
    End Sub
End Class