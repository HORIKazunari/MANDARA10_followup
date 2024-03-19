Public Class frmGridGPX
    Dim CloseCancelF As Boolean
    Dim GPXData As List(Of clsGPX.GPX_Info)
    Private Sub frmFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Public Function GetResults(ByRef LayerName As String, ByRef SubName As String, ByRef ElevationF As Boolean,
                               ByRef TimeIntervalF As Boolean, ByRef DistanceIntervalF As Boolean, ByRef SpeedF As Boolean) As List(Of clsGPX.GPX_Info)
        LayerName = txtLayerName.Text
        SubName = txtName.Text
        ElevationF = chkElevation.Checked
        TimeIntervalF = chkInterval.Checked
        DistanceIntervalF = chkDistance.Checked
        SpeedF = chkSpeed.Checked
        Return GPXData
    End Function

    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = clsSettings.Data.Directory.GPX
        ofd.Filter = "GPXファイル(*.gpx)|*.gpx"
        If ofd.ShowDialog() = DialogResult.OK Then
            GPXData = New List(Of clsGPX.GPX_Info)
            Dim cgp As New clsGPX
            Dim f As Boolean = cgp.Get_GPXFile(ofd.FileName, GPXData)
            If f = True Then
                clsSettings.Data.Directory.GPX = System.IO.Path.GetDirectoryName(ofd.FileName)
                ResetGrdid(GPXData.Count)
                With ktGrid
                    For i As Integer = 0 To GPXData.Count - 1
                        Dim gp As clsGPX.GPX_Info = CType(GPXData(i), clsGPX.GPX_Info)
                        .GridData(0, 0, i) = gp.Time.ToString("yyyyMMddHHmmss")
                        .GridData(0, 1, i) = clsGeneric.SingleToString(gp.Position.Longitude)
                        .GridData(0, 2, i) = clsGeneric.SingleToString(gp.Position.Latitude)
                        .GridData(0, 3, i) = gp.Elevation.ToString
                    Next
                    .Refresh()
                End With
                txtLayerName.Text = System.IO.Path.GetFileName(ofd.FileName)
            End If
        End If
    End Sub
    Private Sub ResetGrdid(ByVal Rows As Integer)
        With ktGrid
            .init("データ", "行", "列", 1, 0, 1, 0, False, True, False, False, False, True, False, False, False, False)
            .AddLayer("", 0, 4, Rows)
            .FixedYSData(0, 0, 0) = "時間"
            .FixedYSData(0, 1, 0) = "経度"
            .FixedYSData(0, 2, 0) = "緯度"
            .FixedYSData(0, 3, 0) = "標高"
            Dim w As Integer = (.Width - .FixedXSWidth(0, 0)) / 4 - 10
            .DefaultGridWidth = w
            .GridAlligntment(0, 0) = HorizontalAlignment.Right
            .GridAlligntment(0, 1) = HorizontalAlignment.Right
            .GridAlligntment(0, 2) = HorizontalAlignment.Right
            .GridAlligntment(0, 3) = HorizontalAlignment.Right
            .Show()
        End With
    End Sub

    Private Sub frmGridGPX_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.PropertyData, "frmGridGPX", Me)

    End Sub

    Private Sub frmGridGPX_Load(sender As Object, e As EventArgs) Handles Me.Load
        With ktGrid
            .init("データ", "行", "列", 1, 0, 1, 0, False, True, False, False, False, True, False, False, False, False)
            .AddLayer("", 0, 4, 1)
            .Show()
        End With
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If GPXData Is Nothing = True Then
            MsgBox("GPXファイルを読み込んで下さい。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
        End If
    End Sub
End Class