Public Class frmMakeLineEdgePattern

    Dim LineEdgePattern As LineEdge_Connect_Pattern_Data_Info

    Public Overloads Function ShowDialog(ByVal LineEdgePat As LineEdge_Connect_Pattern_Data_Info) As Windows.Forms.DialogResult

        LineEdgePattern = LineEdgePat
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Center)
        With LineEdgePattern
            Select Case .Edge_Pattern
                Case enmEdge_Pattern.Round
                    rbRound.Checked = True
                Case enmEdge_Pattern.Rectangle
                    rbRect.Checked = True
                Case enmEdge_Pattern.Flat
                    rbFlat.Checked = True
            End Select
            Select Case .Join_Pattern
                Case enmJoinPattern.Round
                    rbRoundJoin.Checked = True
                Case enmJoinPattern.Bevel
                    rbBevel.Checked = True
                Case enmJoinPattern.Miter
                    rbMiter.Checked = True
            End Select
            txtMiterDir.Text = .MiterLimitValue
        End With
        Return Me.ShowDialog()
    End Function

    Public Function getResult() As LineEdge_Connect_Pattern_Data_Info
        With LineEdgePattern
            Select Case True
                Case rbRound.Checked
                    .Edge_Pattern = enmEdge_Pattern.Round
                Case rbRect.Checked
                    .Edge_Pattern = enmEdge_Pattern.Rectangle
                Case rbFlat.Checked
                    .Edge_Pattern = enmEdge_Pattern.Flat
            End Select
            Select Case True
                Case rbRoundJoin.Checked
                    .Join_Pattern = enmJoinPattern.Round
                Case rbBevel.Checked
                    .Join_Pattern = enmJoinPattern.Bevel
                Case rbMiter.Checked
                    .Join_Pattern = enmJoinPattern.Miter
            End Select
            .MiterLimitValue = Val(txtMiterDir.Text)
        End With
        Return LineEdgePattern
    End Function


End Class