Public Class frmLatLonInput10
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
        txtLat.Text = Math.Abs(P.Latitude)
        txtLon.Text = Math.Abs(P.Longitude)
        pnlNorthSouth.Visible = BoxF
        pnlEastWest.Visible = BoxF
        Return Me.ShowDialog()
    End Function
    Public Function getResults() As strLatLon
        Dim P As strLatLon
        P.Latitude = Val(txtLat.Text)
        P.Longitude = Val(txtLon.Text)
        If rbWest.Checked = True Then
            P.Longitude = -P.Longitude
        End If
        If rbSouth.Checked = True Then
            P.Latitude = -P.Latitude
        End If
        Return P
    End Function
End Class