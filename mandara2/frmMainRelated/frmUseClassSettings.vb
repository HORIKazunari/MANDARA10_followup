Public Class frmUserClassSettings
    Dim CloseCancelF As Boolean
    Dim solo As clsAttrData.strSoloModeViewSettings_Data
    Dim mode As enmSoloMode_Number
    Dim delf As Boolean = False
    Dim delList As List(Of Integer)
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
    Public Overloads Function ShowDialog(ByVal soloMode As enmSoloMode_Number, ByRef asolo As clsAttrData.strSoloModeViewSettings_Data) As Windows.Forms.DialogResult
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        solo = asolo
        mode = soloMode
        delList = New List(Of Integer)
        gbRegist.Text = "分割数" & solo.Div_Num & "の登録パターン（" + clsGeneric.getSolomodeStrings(mode) + "）"
        lbSettings.Items.Clear()
        With clsSettings.UserClass
            Select Case mode
                Case enmSoloMode_Number.ClassPaintMode
                    For Each Ob As clsSettings.User_ColorChart_Info In .Color
                        If Ob.Color.Count = solo.Div_Num Then
                            lbSettings.Items.Add(Ob)
                        End If
                    Next
                Case enmSoloMode_Number.ClassHatchMode
                    For Each Ob As clsSettings.User_TileChart_Info In .Tile
                        If Ob.Tile.Count = solo.Div_Num Then
                            lbSettings.Items.Add(Ob)
                        End If
                    Next
                Case enmSoloMode_Number.ClassMarkMode
                    For Each Ob As clsSettings.User_MarkChart_Info In .Mark
                        If Ob.Mark.Count = solo.Div_Num Then
                            lbSettings.Items.Add(Ob)
                        End If
                    Next
                Case enmSoloMode_Number.ClassODMode
                    For Each Ob As clsSettings.User_LineChart_Info In .Line
                        If Ob.Line.Count = solo.Div_Num Then
                            lbSettings.Items.Add(Ob)
                        End If
                    Next

            End Select
        End With
        Return Me.ShowDialog

    End Function
    Public Function GetResults() As Object
        If lbSettings.SelectedIndex = -1 Then
            Return Nothing
        Else
            Dim retPattern As Object = lbSettings.SelectedItem
            Return retPattern
        End If

    End Function


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtName.Text = "" Then
            MsgBox("名称を設定してください。", MsgBoxStyle.Exclamation)
            Return
        End If
        With clsSettings.UserClass
            Select Case mode
                Case enmSoloMode_Number.ClassPaintMode
                    Dim adata As clsSettings.User_ColorChart_Info
                    adata.Name = txtName.Text
                    adata.Color = New List(Of colorARGB)
                    For i As Integer = 0 To solo.Div_Num - 1
                        adata.Color.Add(solo.Class_Div(i).PaintColor)
                    Next
                    .Color.Add(adata)
                Case enmSoloMode_Number.ClassHatchMode
                    Dim adata As clsSettings.User_TileChart_Info
                    adata.Name = txtName.Text
                    adata.Tile = New List(Of Tile_Property)
                    For i As Integer = 0 To solo.Div_Num - 1
                        adata.Tile.Add(solo.Class_Div(i).TilePat)
                    Next
                    .Tile.Add(adata)
                Case enmSoloMode_Number.ClassMarkMode
                    Dim adata As clsSettings.User_MarkChart_Info
                    adata.Name = txtName.Text
                    adata.Mark = New List(Of Mark_Property)
                    For i As Integer = 0 To solo.Div_Num - 1
                        adata.Mark.Add(solo.Class_Div(i).ClassMark)
                    Next
                    .Mark.Add(adata)
                Case enmSoloMode_Number.ClassODMode
                    Dim adata As clsSettings.User_LineChart_Info
                    adata.Name = txtName.Text
                    adata.Line = New List(Of Line_Property)
                    For i As Integer = 0 To solo.Div_Num - 1
                        adata.Line.Add(solo.Class_Div(i).ODLinePat)
                    Next
                    .Line.Add(adata)

            End Select
        End With
        MsgBox(txtName.Text + "を登録しました。")
        btnCancel.PerformClick()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If lbSettings.SelectedIndex = -1 And delf = False Then
            MsgBox("設定を選択してください。", vbExclamation)
            CloseCancelF = True
            Return
        End If
        If delf = True Then
            With clsSettings.UserClass
                For Each i As Integer In delList
                    Select Case mode
                        Case enmSoloMode_Number.ClassPaintMode
                            .Color.RemoveAt(i)
                        Case enmSoloMode_Number.ClassHatchMode
                            .Tile.RemoveAt(i)
                        Case enmSoloMode_Number.ClassMarkMode
                            .Mark.RemoveAt(i)
                        Case enmSoloMode_Number.ClassODMode
                            .Line.RemoveAt(i)
                    End Select
                Next
            End With
        End If
    End Sub

    Private Sub frmUserClassSettings_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmUserClassSettings", Me)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim n As Integer = lbSettings.SelectedIndex
        If n <> -1 Then
            lbSettings.Items.RemoveAt(n)
            delList.Add(n)
            delf = True
        End If
    End Sub
End Class