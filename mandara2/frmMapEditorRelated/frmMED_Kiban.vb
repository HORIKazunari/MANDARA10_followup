Public Class frmMED_Kiban
    Dim Kiban As New clsKiban
    Dim KibanData As List(Of clsKiban.strKiban_Info)
    Dim CloseCancelF As Boolean
    Dim KibanTypeFileName() As String
    Dim GetKibanType() As Boolean
    Dim MapData As clsMapData
    Dim realGet As List(Of String)
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
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef _MapData As clsMapData) As Windows.Forms.DialogResult
        MapData = _MapData
        KibanData = Kiban.GetKibanList


        Me.Tag = "OFF"
        ReDim KibanTypeFileName(KibanData.Count - 1)
        clbType.EventStop = True
        For i As Integer = 0 To KibanData.Count - 1
            KibanTypeFileName(i) = KibanData(i).Tag
            clbType.Items.Add(KibanData(i).Name)
        Next
        clbType.EventStop = False

        clsGeneric.AddProjectionName2ComboBoxEx(cbProjection)

        With cbProjection
            If MapData.NoDataFlag = True Then
                .SelectedIndex = .Items.IndexOf(clsGeneric.getStringProjectionEnum(clsSettings.Data.default_Projection))
            Else
                If MapData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
                    gbProjection.Visible = False
                Else
                    .SelectedIndex = .Items.IndexOf(clsGeneric.getStringProjectionEnum(MapData.Map.Zahyo.Projection))
                    cbProjection.Enabled = False
                End If
            End If
        End With
        KibanFolder.Folder = clsSettings.Data.Directory.Kiban
        Me.Tag = ""
        GetKibanFolder()
        Return Me.ShowDialog
    End Function
    ''' <summary>
    ''' 結果
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResult() As clsMapData
        Return MapData
    End Function



    Private Sub KibanFolder_Changed() Handles KibanFolder.Changed
        GetKibanFolder()
    End Sub

    Private Sub GetKibanFolder()
        If Me.Tag = "OFF" Then
            Return
        End If
        lbFile.Items.Clear()
        Dim folder_path As String = KibanFolder.Folder
        Dim File_List() As String
        Try
            File_List = System.IO.Directory.GetFiles(folder_path, "*.xml", IO.SearchOption.TopDirectoryOnly)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return
        End Try

        clsSettings.Data.Directory.Kiban = folder_path
        realGet = New List(Of String)
        For i As Integer = 0 To File_List.Length - 1
            Dim name As String = System.IO.Path.GetFileName(File_List(i))
            Dim parts() As String = name.Split("-")
            If parts.Length = 6 Then
                Dim tp As String = parts(3)
                Dim idx As Integer = Array.IndexOf(KibanTypeFileName, tp)
                If idx <> -1 Then
                    If GetKibanType(idx) = True Then
                        realGet.Add(name)
                    End If
                End If
            Else

            End If
        Next
        lbFile.Items.Clear()
        lbFile.Items.AddRange(realGet.ToArray)
    End Sub

    Private Sub clbType_changed(sender As Object, e As CheckedListBoxExChangeEventArgs) Handles clbType.changed
        ReDim GetKibanType(clbType.Items.Count - 1)
        For i As Integer = 0 To clbType.Items.Count - 1
            GetKibanType(i) = e.ItemCheck(i)
        Next

        GetKibanFolder()
    End Sub
    Private Sub GetKibanMap()
        Dim Projection As enmProjection_Info = clsGeneric.getProjectionEnum_fromStrings(cbProjection.Text)
        Dim GetFile As New List(Of String)
        For i As Integer = 0 To lbFile.SelectedIndices.Count - 1
            Dim fname As String = KibanFolder.Folder + "\" + realGet(lbFile.SelectedIndices(i))
            GetFile.Add(fname)
        Next
        MapData = Kiban.Get_KibanFiles(GetFile, Projection, ProgressBar)
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If realGet.Count = 0 Then
            MsgBox("取得する基盤地図情報のファイルがありません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        Else
            If lbFile.SelectedIndices.Count = 0 Then
                MsgBox("取得する基盤地図情報のファイルを選択して下さい。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Return
            End If
        End If
        GetKibanMap()
    End Sub

    Private Sub frmMED_Kiban_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_Kiban", Me)
        e.Cancel = True
    End Sub
End Class