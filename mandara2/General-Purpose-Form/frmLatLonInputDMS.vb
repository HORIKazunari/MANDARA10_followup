Public Class frmLatLonInputDMS
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="P"></param>
    ''' <param name="BoxF">北緯／南緯／東経／西経の表示非表示</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal P As strLatLon, ByVal BoxF As Boolean) As Windows.Forms.DialogResult
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        If P.Latitude >= 0 Then
            rbNorth.Checked = True
        Else
            rbSouth.Checked = True
        End If
        If P.Longitude >= 0 Then
            rbEast.Checked = True
        Else
            rbWest.Checked = True
        End If
        Dim LatLonDMS As strLatLonDegreeMinuteSecond = P.toDegreeMinuteSecond
        With LatLonDMS
            With .LatitudeDMS
                txtLatDegree.Text = Math.Abs(.Degree)
                txtLatMinute.Text = .Minute
                txtLatSecond.Text = .Second
                If .Degree < 0 Then
                    rbSouth.Checked = True
                Else
                    rbNorth.Checked = True
                End If
            End With
            With .LongitudeDMS
                txtLonDegree.Text = Math.Abs(.Degree)
                txtLonMinute.Text = .Minute
                txtLonSecond.Text = .Second
                If .Degree < 0 Then
                    rbWest.Checked = True
                Else
                    rbEast.Checked = True
                End If
            End With
        End With
        pnlNorthSouth.Visible = BoxF
        pnlEastWest.Visible = BoxF

        Return Me.ShowDialog()
    End Function
    Public Function getResults() As strLatLon
        Dim LatLonDMS As strLatLonDegreeMinuteSecond
        With LatLonDMS
            With .LatitudeDMS
                .Degree = Val(txtLatDegree.Text)
                .Minute = Val(txtLatMinute.Text)
                .Second = Val(txtLatSecond.Text)
                If rbSouth.Checked = True Then
                    .Degree = -.Degree
                End If
            End With
            With .LongitudeDMS
                .Degree = Val(txtLonDegree.Text)
                .Minute = Val(txtLonMinute.Text)
                .Second = Val(txtLonSecond.Text)
                If rbWest.Checked = True Then
                    .Degree = -.Degree
                End If
            End With
        End With

        Dim P As strLatLon = New strLatLon(LatLonDMS)

        Return P
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub pnlEastWest_Paint(sender As Object, e As PaintEventArgs) Handles pnlEastWest.Paint

    End Sub
End Class