Public Class frmVersionInfo
    Dim ver As String
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

    End Sub

    Private Sub frmVersionInfo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim AppTitle As String = _
    CType(Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(),
        GetType(System.Reflection.AssemblyTitleAttribute)), System.Reflection.AssemblyTitleAttribute).Title
        Me.Text = AppTitle + " バージョン情報"


        Dim verinfo As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo( _
                                                System.Reflection.Assembly.GetExecutingAssembly().Location)
        ver = verinfo.ProductVersion
        lblTitle.Text = AppTitle + " ver." + ver + " for Windows 7/8/8.1/10"
        lblVersion.Text = verinfo.LegalCopyright
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(sender.text)
    End Sub

    Private Sub btnCheckVersion_Click(sender As Object, e As EventArgs) Handles btnCheckVersion.Click

        Dim url As String = "http://ktgis.net/mandara/version10.txt"
        Dim wc As New System.Net.WebClient()
        wc.Encoding = System.Text.Encoding.UTF8
        Dim newver As String
        Try
            newver = wc.DownloadString(url)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return
        Finally
            wc.Dispose()
        End Try

        If newver = ver Then
            MsgBox("現在のバージョンは最新です。")
        Else
            If MsgBox("最新は" + newver + "です。更新しますか？", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                If MsgBox("更新のため、MANDARAを終了します。", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    Dim update As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\MANDARA10Update.exe"
                    Try
                        System.Diagnostics.Process.Start(update)
                        Application.Exit()
                    Catch ex As Exception
                        MsgBox("MANDARA10Update.exeが実行できません。更新できませんでした。", MsgBoxStyle.Exclamation)
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub lblVersion_Click(sender As Object, e As EventArgs) Handles lblVersion.Click

    End Sub
End Class