Public Class frmHelpBrowser

    Public Overloads Sub Show(ByVal URi As String)
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Center)
        Dim ur As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\help\" + URi

        WebBrowser1.Navigate(New Uri(ur))
        Me.Show()
        Me.Focus()
    End Sub

    Private Sub btnBefore_Click(sender As Object, e As EventArgs) Handles btnBefore.Click, btnNext.Click
        Select Case sender.name
            Case "btnBefore"
                WebBrowser1.GoBack()
            Case "btnNext"
                Try
                    WebBrowser1.GoForward()
                Catch ex As Exception
                End Try
        End Select


    End Sub
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        btnBefore.Enabled = WebBrowser1.CanGoBack
        btnNext.Enabled = WebBrowser1.CanGoForward
        lblTitle.Text = WebBrowser1.DocumentTitle
    End Sub
End Class