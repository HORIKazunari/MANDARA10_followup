Public Class frmMED_SRTM30Divide
    Private Enum enmDtype
        SRTM30 = 0
        SRTM30Plus = 1
    End Enum

    Private Enum SRTM30Data
        NormalWpx = 4800
        NormalHpx = 6000
        AntarcticWpx = 7200
        AntarcticHpx = 3600
        NormalWdg = 40
        AntarcticWdg = 60
        NormalHdg = 50
        AntarcticHdg = 30
        AntarcticIdo = -60
    End Enum
    Dim CloseCancelF As Boolean
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

    Private Sub frmMED_SRTM30Divide_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_SRTM30Divide", Me)
        e.Cancel = True
    End Sub


    Private Sub frmMED_SRTM30Divide_Load(sender As Object, e As EventArgs) Handles Me.Load
        inputFolder.Folder = My.Application.Info.DirectoryPath
        outputFolder.Folder = My.Application.Info.DirectoryPath
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim f_ext As String = ""
        Dim Dtype As enmDtype
        If rbSRTM30Plus.Checked = True Then
            Dtype = enmDtype.SRTM30Plus
            f_ext = ".srtm"
        Else
            Dtype = enmDtype.SRTM30
            f_ext = ".DEM"
        End If

        Dim File_List() As String = System.IO.Directory.GetFiles(inputFolder.Folder)

        ProgressBar1.Visible = True
        ProgressBar1.Maximum = File_List.Length + 1
        Dim f As Boolean
        Dim n As Integer = 0
        For i As Integer = 0 To File_List.Length - 1
            ProgressBar1.Value = i + 1
            My.Application.DoEvents()
            If UCase(System.IO.Path.GetExtension(File_List(i))) = UCase(f_ext) Then
                n += 1
                f = Convert_file(File_List(i))
                If f = False Then
                    Exit For
                End If
            End If
        Next
        ProgressBar1.Visible = False
        If n = 0 Then
            Dim tx As String
            If Dtype = enmDtype.SRTM30 Then
                tx = "SRTM30"
            Else
                tx = "SRTM30Plus"
            End If
            MsgBox(tx + "のファイルが見つかりません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
        Else
            If f = True Then
                MsgBox("変換が終了しました。")
            Else
                MsgBox("変換できませんでした。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
            End If
        End If
    End Sub
    Private Function Convert_file(filename As String) As Boolean
        Dim NIdo As Integer
        Dim WKedo As Integer
        Get_IdoKedo_Value_WENS(System.IO.Path.GetFileNameWithoutExtension(filename), NIdo, WKedo)

        Dim w As Integer
        Dim H As Integer
        Dim kedoW As Integer
        Dim IdoH As Integer

        If NIdo = -60 Then
            w = SRTM30Data.AntarcticWpx
            H = SRTM30Data.AntarcticHpx
            KedoW = SRTM30Data.AntarcticWdg
            IdoH = SRTM30Data.AntarcticHdg
        Else
            w = SRTM30Data.NormalWpx
            H = SRTM30Data.NormalHpx
            KedoW = SRTM30Data.NormalWdg
            IdoH = SRTM30Data.NormalHdg
        End If


        Dim fs As New System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim Mesh(fs.Length - 1) As Byte
        fs.Read(Mesh, 0, Mesh.Length)
        fs.Close()

        ProgressBar2.Visible = True
        ProgressBar2.Maximum = IdoH + 2
        ProgressBar2.Value = 1
        Dim PxPerDegree As Integer = 120
        Dim Mesh2(PxPerDegree * PxPerDegree * 2 - 1) As Byte
        Dim f As Boolean = True
        For i As Integer = 0 To IdoH - 1
            ProgressBar2.Value = i + 2
            For j As Integer = 0 To kedoW - 1
                For ky As Integer = 0 To PxPerDegree - 1
                    For kx As Integer = 0 To PxPerDegree - 1
                        Dim p As Integer = ((i * w * PxPerDegree + ky * w) + (j * PxPerDegree + kx)) * 2
                        Dim P2 As Integer = (ky * PxPerDegree + kx) * 2
                        Mesh2(P2) = Mesh(p)
                        Mesh2(P2 + 1) = Mesh(p + 1)
                    Next
                Next
                Dim OIdo As Integer = NIdo - i - 1
                Dim OKedo As Integer = WKedo + j
                Dim OutFilename As String = outputFolder.Folder + "\" + clsGeneric.Get_IdoKedo_Strings_NSWE(New strLatLon(OIdo, OKedo))
                OutFilename += ".srtm30mdr"
                Try
                    Dim fos As New System.IO.FileStream(OutFilename, IO.FileMode.Create)
                    fos.Write(Mesh2, 0, Mesh2.Length)
                    fos.Close()
                Catch ex As Exception
                    f = False
                    MsgBox(ex.Message)
                    i = IdoH
                    Exit For
                End Try
            Next
        Next
        ProgressBar2.Visible = False
        Return f
    End Function
    Private Sub Get_IdoKedo_Value_WENS(ByVal WENS As String, ByRef Ido As Integer, ByRef Kedo As Integer)
        'E130N50を緯度経度に分割
        Dim NIdo As Integer, WKedo As Integer
        WKedo = Val(Mid(WENS, 2, 3))
        NIdo = Val(Mid(WENS, 6, 2))
        If UCase(Microsoft.VisualBasic.Left(WENS, 1)) = "W" Then
            WKedo = -WKedo
        End If
        If UCase(Mid(WENS, 5, 1)) = "S" Then
            NIdo = -NIdo
        End If
        Ido = NIdo
        Kedo = WKedo
    End Sub
End Class