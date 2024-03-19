Public Class frmArrow
    Dim CloseCancelF As Boolean
    Private Sub frmMED_GetPointObject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Private Arrow As Arrow_Data
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Arrow"></param>
    ''' <param name="Start_Arrow_Caption"></param>
    ''' <param name="End_Arrow_Caption"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal _Arrow As Arrow_Data,
                                         ByVal Start_Arrow_Caption As String, ByVal End_Arrow_Caption As String) As Windows.Forms.DialogResult
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        Dim w As Integer = picLine.Width
        Dim h As Integer = picLine.Height
        Dim XY(2) As Point
        XY(0).X = w * 0.6
        XY(0).Y = h * 0.2
        XY(1).X = w * 0.9
        XY(1).Y = h / 2
        XY(2).X = w * 0.6
        XY(2).Y = h * 0.8
        With picLine
            Dim canvas As New Bitmap(w, h)
            Dim g As Graphics = Graphics.FromImage(canvas)
            Dim pen As New Pen(Color.Black, 2)
            g.DrawLine(pen, New Point(w * 0.1, h / 2), XY(1))
            g.DrawLines(pen, XY)
            g.Dispose()
            .Image = canvas
            .Refresh()
        End With

        With picFill
            Dim canvas As New Bitmap(w, h)
            Dim g As Graphics = Graphics.FromImage(canvas)
            Dim pen As New Pen(Color.Black, 2)
            g.DrawLine(pen, New Point(w * 0.1, h / 2), XY(1))
            g.FillPolygon(New SolidBrush(Color.Black), XY)
            g.Dispose()
            .Image = canvas
            .Refresh()
        End With

        Arrow = _Arrow
        If Start_Arrow_Caption <> "" Then
            cbArrowStart.Text = Start_Arrow_Caption
        Else
            cbArrowStart.Visible = False
            cbArrowEnd.Left = cbArrowStart.Left
        End If
        If End_Arrow_Caption <> "" Then
            cbArrowEnd.Text = End_Arrow_Caption
        Else
            cbArrowEnd.Visible = False
        End If

        With Arrow
            cbArrowStart.Checked = .Start_Arrow_F
            cbArrowEnd.Checked = .End_Arrow_F
            If .ArrowHeadType = enmArrowHeadType.Line Then
                rbLine.Checked = True
            Else
                rbFill.Checked = True
            End If
            txtAngle.Text = .Angle
            txtLineWidth1.Text = .LWidthRatio
            txtLineWidth2.Text = .WidthPlus
        End With
        Return Me.ShowDialog()
    End Function
    Public Function getResult() As Arrow_Data
        With Arrow
            If rbLine.Checked = True Then
                .ArrowHeadType = enmArrowHeadType.Line
            Else
                .ArrowHeadType = enmArrowHeadType.Fill
            End If
            .Start_Arrow_F = cbArrowStart.Checked
            .End_Arrow_F = cbArrowEnd.Checked
            .Angle = Val(txtAngle.Text)
            .LWidthRatio = Val(txtLineWidth1.Text)
            .WidthPlus = Val(txtLineWidth2.Text)
        End With
        Return Arrow
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim mes As String = ""

        CloseCancelF = False
        If Val(txtAngle.Text) < 30 Or Val(txtAngle.Text) > 180 Then
            mes = "角度は30°から180度の間で指定してください。" & vbCrLf

        End If
        If Val(txtLineWidth1.Text) < 1 Or Val(txtLineWidth1.Text) > 2 Then
            mes = "線幅の比は1から2の間で指定してください。" & vbCrLf
        End If
        If Val(txtLineWidth2.Text) < 0 Or Val(txtLineWidth2.Text) > 5 Then
            mes = "線幅の加算量は0から5の間で指定してください。" & vbCrLf
        End If
        If mes <> "" Then
            MsgBox(mes, MsgBoxStyle.Exclamation)
            CloseCancelF = True
        End If
    End Sub

    Private Sub picLine_Click(sender As Object, e As EventArgs) Handles picLine.Click
        rbLine.Checked = True
    End Sub

    Private Sub picFill_Click(sender As Object, e As EventArgs) Handles picFill.Click
        rbFill.Checked = True
    End Sub

    Private Sub frmArrow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class