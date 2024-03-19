Public Class frmMakeLinePattern
    Dim LinePattern As Line_Property

    Dim attrData As clsAttrData
    Private Sub frmMakeLinePattern_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Overloads Function ShowDialog(ByRef LinePat As Line_Property, ByRef _attrData As clsAttrData) As Windows.Forms.DialogResult
        attrData = _attrData
        LinePattern = LinePat
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Center)
        Init_LData()
        Return Me.ShowDialog()
    End Function

    Public Function getResult() As Line_Property

        Return LinePattern
    End Function
    Private Sub Init_LData()
        Select Case LinePattern.BasicLine.pattern
            Case enmLinePattern.InVisible
                rbBlancLine.Checked = True
            Case enmLinePattern.Solid
                rbSolidLine.Checked = True
            Case enmLinePattern.BROKEN
                rbBrokenLine.Checked = True
        End Select
        cbCrossLine.Checked = LinePattern.CrossLine.XLine_f
        cbDoubleLine.Checked = LinePattern.ParallelLine.P_Line_f
        clsDrawLine.Draw_Sample_LineBox(picSample, LinePattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
    End Sub
    Private Sub btnBasicLine_Click(sender As Object, e As EventArgs) Handles btnBasicLine.Click

        If clsGeneric.Line_Pattern_select(LinePattern, False, attrData) = True Then
            Init_LData()
        End If
    End Sub

    Private Sub rbBrokenLine_CheckedChanged(sender As Object, e As EventArgs) Handles rbBrokenLine.CheckedChanged,
                                                rbSolidLine.CheckedChanged, rbBlancLine.CheckedChanged
        Select Case True
            Case rbBrokenLine.Checked
                btnBrokenSet.Enabled = True
                btnSolidSet.Enabled = False
                LinePattern.BasicLine.pattern = enmLinePattern.BROKEN
            Case rbSolidLine.Checked
                btnBrokenSet.Enabled = False
                btnSolidSet.Enabled = True
                LinePattern.BasicLine.pattern = enmLinePattern.Solid
            Case rbBlancLine.Checked
                btnBrokenSet.Enabled = False
                btnSolidSet.Enabled = False
                LinePattern.BasicLine.pattern = enmLinePattern.InVisible
        End Select
        clsDrawLine.Draw_Sample_LineBox(picSample, LinePattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
    End Sub

    Private Sub cbDoubleLine_CheckedChanged(sender As Object, e As EventArgs) Handles cbDoubleLine.CheckedChanged
        LinePattern.ParallelLine.P_Line_f = cbDoubleLine.Checked
        btnDoubleSet.Enabled = cbDoubleLine.Checked
        clsDrawLine.Draw_Sample_LineBox(picSample, LinePattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
    End Sub

    Private Sub cbCrossLine_CheckedChanged(sender As Object, e As EventArgs) Handles cbCrossLine.CheckedChanged
        LinePattern.CrossLine.XLine_f = cbCrossLine.Checked
        btnCrossSet.Enabled = cbCrossLine.Checked
        clsDrawLine.Draw_Sample_LineBox(picSample, LinePattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)

    End Sub

    Private Sub btnSolidSet_Click(sender As Object, e As EventArgs) Handles btnSolidSet.Click
        Dim form As New frmMakeLineSolidPattern
        If form.ShowDialog(LinePattern.BasicLine) = Windows.Forms.DialogResult.OK Then
            LinePattern.BasicLine = form.getResult()
            clsDrawLine.Draw_Sample_LineBox(picSample, LinePattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End If
        form.Dispose()

    End Sub

    Private Sub btnEdge_Click(sender As Object, e As EventArgs) Handles btnEdge.Click
        If clsGeneric.LineEdgePattern_Set(LinePattern.Edge_Connect_Pattern) = True Then
            clsDrawLine.Draw_Sample_LineBox(picSample, LinePattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End If
    End Sub

    Private Sub btnDoubleSet_Click(sender As Object, e As EventArgs) Handles btnDoubleSet.Click
        Dim form As New frmMakeLineParallelPattern
        If form.ShowDialog(LinePattern) = Windows.Forms.DialogResult.OK Then
            LinePattern = form.getResult()
            clsDrawLine.Draw_Sample_LineBox(picSample, LinePattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End If
        form.Dispose()
    End Sub

    Private Sub btnBrokenSet_Click(sender As Object, e As EventArgs) Handles btnBrokenSet.Click
        Dim form As New frmMakeLineBrokenPattern
        If form.ShowDialog(LinePattern.BasicLine) = Windows.Forms.DialogResult.OK Then
            LinePattern.BasicLine = form.getResult()
            clsDrawLine.Draw_Sample_LineBox(picSample, LinePattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End If
        form.Dispose()
    End Sub

    Private Sub btnCrossSet_Click(sender As Object, e As EventArgs) Handles btnCrossSet.Click
        Dim form As New frmMakeLineCrossPattern
        If form.ShowDialog(LinePattern.CrossLine, attrData) = Windows.Forms.DialogResult.OK Then
            LinePattern.CrossLine = form.getResult()
            clsDrawLine.Draw_Sample_LineBox(picSample, LinePattern, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End If
        form.Dispose()
    End Sub
End Class