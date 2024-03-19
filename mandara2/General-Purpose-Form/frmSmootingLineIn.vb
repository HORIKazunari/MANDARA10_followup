Public Class frmSmootingLineIn
    Dim CloseCancelF As Boolean
    Dim ConvScaleValue As Single
    Private Sub frmSmootingLineIn_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal ThinningPrint_F As Boolean, ByVal _def_PointInterval As Single,
                                         ByVal LoopAreaF As Boolean, ByVal _def_LoopSize As Single,
                                         ByVal exp_visible_f As Boolean, ByVal ScaleUnit As enmScaleUnit) As Windows.Forms.DialogResult
        ConvScaleValue = clsGeneric.Convert_ScaleUnit(enmScaleUnit.kilometer, ScaleUnit)
        Dim def_PointInterval As Single = _def_PointInterval * ConvScaleValue
        Dim def_LoopSize As Single = _def_LoopSize * ConvScaleValue
        Dim LRdeci As strDecimalPointNumber
        LRdeci = clsGeneric.Get_Figure_Arrange(def_PointInterval)
        If LRdeci.Left_Of_Decimal_Point + LRdeci.Right_Of_Decimal_Point > 5 Then
            LRdeci.Right_Of_Decimal_Point = 5 - LRdeci.Left_Of_Decimal_Point
            If LRdeci.Right_Of_Decimal_Point < 0 Then
                LRdeci.Right_Of_Decimal_Point = 0
            End If
        End If
        cbLoop.Checked = LoopAreaF
        cbPoint.Checked = ThinningPrint_F
        txtPointInterval.Text = clsGeneric.Figure_Using(def_PointInterval, Math.Max(LRdeci.Left_Of_Decimal_Point, 1), LRdeci.Right_Of_Decimal_Point, False)
        txtLoopSize.Text = def_LoopSize
        lbUnit1.Text = clsGeneric.getScaleUnitStrings(ScaleUnit)
        lbAreaUnit.Text = clsGeneric.getScaleUnitAreaStrings(ScaleUnit)
        lbExplanation.Visible = exp_visible_f
        Return Me.ShowDialog(Owner)
    End Function
    ''' <summary>
    ''' 結果
    ''' </summary>
    ''' <param name="PointInterval">-1の場合取得しない</param>
    ''' <param name="LoopSize">-1の場合取得しない</param>
    ''' <remarks></remarks>
    Public Sub getResult(ByRef ThinningPrint_F As Boolean, ByRef PointInterval As Single, ByRef LoopAreaF As Boolean, ByRef LoopSize As Single)

        ThinningPrint_F = cbPoint.Checked
        PointInterval = Val(txtPointInterval.Text) / ConvScaleValue
        If PointInterval = 0 Then
            ThinningPrint_F = False
        End If
        LoopAreaF = cbLoop.Checked
        LoopSize = Val(txtLoopSize.Text) / ConvScaleValue
        If LoopSize = 0 Then
            LoopAreaF = False
        End If
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If cbLoop.Checked = True Then
            If Val(txtLoopSize.Text) <= 0 Then
                MsgBox("ループ最小取得サイズは0より大きい値を指定してください。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Return
            End If
        End If
        If cbPoint.Checked = True Then
            If Val(txtPointInterval.Text) <= 0 Then
                MsgBox("ポイント取得間隔は0より大きい値を指定してください。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Return
            End If
        End If
    End Sub


    Private Sub txtPointInterval_Enter(sender As Object, e As EventArgs) Handles txtPointInterval.Enter
        cbPoint.Checked = True
    End Sub

    Private Sub txtLoopSize_Enter(sender As Object, e As EventArgs) Handles txtLoopSize.Enter
        cbLoop.Checked = True
    End Sub

    Private Sub frmSmootingLineIn_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SubWindow, "frmSmootingLineIn", Me)
    End Sub
End Class