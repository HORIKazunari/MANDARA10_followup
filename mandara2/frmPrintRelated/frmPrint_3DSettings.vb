Public Class frmPrint_3DSettings
    Dim attrData As clsAttrData
    Dim prop As Boolean
    Public Sub Set_Data(ByRef _attrData As clsAttrData, _prop As Boolean)
        Dim frm As frmPrint = CType(Me.Owner, frmPrint)
        Me.Top = frm.Bottom - Me.Height * 0.8
        Me.Left = frm.Left - 50
        prop = _prop
        attrData = _attrData
        SetWorldXY_3DpicSize()
        With attrData.TotalData.ViewStyle.ScrData.ThreeDMode
            .Set3D_F = True
        End With
        setValue()
        frm.printMapScreen(True)

    End Sub

    Private Sub txtTurnX_LostFocus(sender As Object, e As EventArgs) Handles txtTurnX.LostFocus, txtTurnY.LostFocus, txtTurnZ.LostFocus,
        txtExpansion.LostFocus

        Dim a As Integer = Val(sender.text)

        With attrData.TotalData.ViewStyle.ScrData.ThreeDMode
            Select Case sender.name
                Case "txtTurnX"
                    .Pitch = a
                Case "txtTurnY"
                    .Head = a
                Case "txtTurnZ"
                    .Bank = a
                Case "txtExpansion"
                    .Expand = a
            End Select
        End With
        Me.Tag = "OFF"
        setValue()
        Me.Tag = ""
    End Sub


    Private Sub frmPrint_3DSettings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        attrData.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F = False
        Dim frm As frmPrint
        frm = CType(Me.Owner, frmPrint)
        frm.mnuSet3d.Checked = False
        If prop = True Then
            frm.mnuPropertyWindow.Checked = True
        End If
        frm.printMapScreen(True)
    End Sub



    Private Sub HScrollBarX_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBarX.Scroll, HScrollBarY.Scroll, HScrollBarZ.Scroll, HScrollBarEx.Scroll
        If Me.Tag = "" Then
            With attrData.TotalData.ViewStyle.ScrData.ThreeDMode
                .Pitch = HScrollBarX.Value
                .Head = HScrollBarY.Value
                .Bank = HScrollBarZ.Value
                .Expand = HScrollBarEx.Value
            End With
            setValue()
        End If


    End Sub
    Private Sub setValue()
        Me.Tag = "OFF"
        With attrData.TotalData.ViewStyle.ScrData.ThreeDMode
            txtTurnX.Text = .Pitch
            txtTurnY.Text = .Head
            txtTurnZ.Text = .Bank
            txtExpansion.Text = .Expand
            HScrollBarX.Value = .Pitch
            HScrollBarY.Value = .Head
            HScrollBarZ.Value = .Bank
            HScrollBarEx.Value = .Expand
        End With
        Me.Tag = ""
        prt3DSample()
 
    End Sub
    Public Sub prt3DSample()
        Dim Ra As Single = pic3D.Width / attrData.TotalData.ViewStyle.ScrData.frmPrint_FormSize.Width

        Dim TurnCenter As PointF
        With attrData.TotalData.ViewStyle.ScrData.MapRectangle
            TurnCenter = New PointF((.Right + .Left) / 2, (.Bottom + .Top) / 2)
        End With
        pic3D.Refresh()
        Dim g As Graphics = pic3D.CreateGraphics

        With attrData.TotalData.ViewStyle.ScrData.ScrView
            Dim HP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(TurnCenter)
            HP.X *= Ra
            HP.Y *= Ra
            Dim P1 As PointF = .Location
            Dim STP As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(P1)
            STP.X *= Ra
            STP.Y *= Ra
            g.DrawLine(New Pen(Color.Red, 1), HP, STP)

            Dim P2 As PointF = New PointF(.Right, .Top)
            Dim STP2 As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(P2)
            STP2.X *= Ra
            STP2.Y *= Ra
            g.DrawLine(New Pen(Color.Black, 2), STP, STP2)
            g.DrawLine(New Pen(Color.Red, 1), STP2, HP)

            Dim P3 As PointF = New PointF(.Right, .Bottom)
            Dim STP3 As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(P3)
            STP3.X *= Ra
            STP3.Y *= Ra
            g.DrawLine(New Pen(Color.Black, 1), STP2, STP3)
            g.DrawLine(New Pen(Color.Red, 1), STP3, HP)

            Dim P4 As PointF = New PointF(.Left, .Bottom)
            Dim STP4 As Point = attrData.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(P4)
            STP4.X *= Ra
            STP4.Y *= Ra
            g.DrawLine(New Pen(Color.Black, 1), STP4, STP3)
            g.DrawLine(New Pen(Color.Red, 1), STP4, HP)
            g.DrawLine(New Pen(Color.Black, 2), STP, STP4)
        End With

    End Sub
    Public Sub SetWorldXY_3DpicSize()
        Dim a As Integer
        Dim b As Integer, a2 As Integer, B2 As Integer
        Dim a3 As Single, b3 As Single, a4 As Single, b4

        With attrData.TotalData.ViewStyle.ScrData.frmPrint_FormSize
            a = .Width
            b = .Height
        End With
        a2 = PanelPic.Width
        B2 = PanelPic.Height
        If a > a2 Then
            a3 = a2
            b3 = b * a2 / a
        Else
            a3 = a
            b3 = b
        End If
        If b3 > B2 Then
            a4 = a3 * B2 / b3
            b4 = B2
        Else
            a4 = a3
            b4 = b3
        End If
        With pic3D
            .Width = a4
            .Height = b4
            .Top = PanelPic.Height / 2 - b4 / 2
        End With
        prt3DSample()
    End Sub

    Private Sub frmPrint_3DSettings_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        prt3DSample()
    End Sub



    Private Sub btnRedraw_Click(sender As Object, e As EventArgs) Handles btnRedraw.Click
        Dim frm As frmPrint = CType(Me.Owner, frmPrint)
        frm.printMapScreen(True)
    End Sub
End Class