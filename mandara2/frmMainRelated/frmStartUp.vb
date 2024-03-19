
Public Class frmStartUp
    Public Enum enmRetCommand
        Clipboard = 0
        File = 1
        Recent = 2
        NewData = 3
        White = 4
        Shape = 5
        MapEditor = 6
    End Enum
    Dim CloseCancelF As Boolean
    Dim fileDrop As Boolean
    Dim dropfile As String
    Private Sub frmStartUp_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Dim fileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        dropfile = fileName(0)
        fileDrop = True
        btnOK.PerformClick()
    End Sub

    Private Sub frmStartUp_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If
    End Sub
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

    Public Function GetResults(ByRef RecentFile As String) As enmRetCommand
        If fileDrop = True Then
            RecentFile = dropfile
            Return enmRetCommand.Recent
        Else
            Select Case True
                Case rbClipBoard.Checked
                    Return enmRetCommand.Clipboard
                Case rbDataFile.Checked
                    Return enmRetCommand.File
                Case rbRecent.Checked
                    Dim n As Integer = lbRecentFile.SelectedIndex
                    Dim FileHistory() As String = clsSettings.Data.MDRFileHistory.Split("|")
                    RecentFile = FileHistory(n)
                    Return enmRetCommand.Recent
                Case rbNewData.Checked
                    Return enmRetCommand.NewData
                Case rbWhiteMap.Checked
                    Return enmRetCommand.White
                Case rbShapeFile.Checked
                    Return enmRetCommand.Shape
                Case rbMapEditor.Checked
                    Return enmRetCommand.MapEditor
            End Select
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnVersion.Click

        Dim form As New frmVersionInfo
        form.ShowDialog()
        form.Dispose()
    End Sub

    Private Sub frmStartUp_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim FileHistory() As String = clsSettings.Data.MDRFileHistory.Split("|")
        For i As Integer = 0 To FileHistory.Length - 1
            lbRecentFile.Items.Add(System.IO.Path.GetFileName(FileHistory(i)))
        Next
        lbRecentFile.SelectedIndex = -1
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If rbRecent.Checked = True Then
            Dim n As Integer = lbRecentFile.SelectedIndex
            If n = -1 Then
                MsgBox("最近使ったファイルを選択して下さい。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
            End If
        End If
    End Sub

    Private Sub lbRecentFile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbRecentFile.Enter
        rbRecent.Checked = True
    End Sub

    Private Sub lbRecentFile_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lbRecentFile.DoubleClick
        btnOK.PerformClick()
    End Sub



    Private Sub rbNewData_CheckedChanged(sender As Object, e As MouseEventArgs) Handles rbNewData.MouseDown, rbClipBoard.MouseDown, rbDataFile.MouseDown,
        rbWhiteMap.MouseDown, rbShapeFile.MouseDown, rbMapEditor.MouseDown
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            If e.Clicks = 2 Then
                btnOK.PerformClick()
            End If
        End If
    End Sub



    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmStartUp")
    End Sub

End Class