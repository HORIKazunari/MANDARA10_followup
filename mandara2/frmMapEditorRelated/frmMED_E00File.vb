Public Class frmMED_E00File
    Dim CloseCancelF As Boolean
    Dim MapData As clsMapData
    Dim E00Files As New List(Of clsE00.E00file_info)
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
        With cbKeiNumber
            .Items.Clear()
            For i As Integer = 1 To 19
                .Items.Add(i)
            Next
        End With
        With cbProjection
            clsGeneric.AddProjectionName2ComboBoxEx(cbProjection)
            If MapData.NoDataFlag = True Then
                .SelectedIndex = .Items.IndexOf(clsGeneric.getStringProjectionEnum(clsSettings.Data.default_Projection))
            Else
                .SelectedIndex = .Items.IndexOf(clsGeneric.getStringProjectionEnum(MapData.Map.Zahyo.Projection))
                cbProjection.Enabled = False
            End If
        End With

        gbE00FileInfo.Text = ""
        pnlInfo.Visible = False
        Return Me.ShowDialog

    End Function
    Public Function GetResults() As clsE00.E00file_info()
        Dim n As Integer = E00Files.Count
        Dim e00(n - 1) As clsE00.E00file_info
        For i As Integer = 0 To n - 1
            e00(i) = E00Files(i)
            e00(i).Zahyo.Projection = clsGeneric.getProjectionEnum_fromStrings(cbProjection.Text)
        Next
        Return e00
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim sfd As New OpenFileDialog
        sfd.InitialDirectory = clsSettings.Data.Directory.E00File
        sfd.Filter = "e00ファイル(*.e00)|*.e00"
        sfd.Multiselect = True
        sfd.Title = "e00ファイル読み込み"
        If sfd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim n As Integer = sfd.FileNames.Length
            Dim onum As Integer = lbFile.Items.Count
            For i As Integer = 0 To E00Files.Count - 1
                If System.IO.Path.GetFileName(sfd.FileNames(i)) = E00Files(i).FileName Then
                    MsgBox(E00Files(i).FileName + "は既に読み込まれています。", MsgBoxStyle.Exclamation)
                    Return
                End If
            Next
            For i As Integer = 0 To n - 1
                Dim E00File As clsE00.E00file_info
                With E00File
                    .FullPath = sfd.FileNames(i)
                    .FileName = System.IO.Path.GetFileName(.FullPath)
                    .Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido
                    .Zahyo.System = enmZahyo_System_Info.Zahyo_System_World
                End With
                E00Files.Add(E00File)
                lbFile.Items.Add(E00File.FileName)
            Next
            If lbFile.SelectedIndex = -1 Then
                lbFile.SelectedIndex = onum
            End If
            clsSettings.Data.Directory.E00File = System.IO.Path.GetDirectoryName(sfd.FileNames(0))
        End If
        sfd.Dispose()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim n As Integer = lbFile.SelectedIndex
        If n <> -1 Then
            E00Files.RemoveAt(n)
            lbFile.Items.RemoveAt(n)
            If lbFile.Items.Count = 0 Then
                gbE00FileInfo.Text = ""
                pnlInfo.Visible = False
            Else
                If lbFile.Items.Count = n Then
                    n -= 1
                End If
                lbFile.SelectedIndex = n
            End If

        End If

    End Sub

    Private Sub btnDeleteAll_Click(sender As Object, e As EventArgs) Handles btnDeleteAll.Click
        E00Files.Clear()
        lbFile.Items.Clear()
        gbE00FileInfo.Text = ""
        pnlInfo.Visible = False
    End Sub

    Private Sub rbLatLon_CheckedChanged(sender As Object, e As EventArgs) Handles rbLatLon.CheckedChanged,
        rbJapanZone.CheckedChanged, rbOther.CheckedChanged, rbD_Tokyo.CheckedChanged, rbD_World.CheckedChanged,
        rbD_Other.CheckedChanged, cbKeiNumber.SelectedIndexChanged
        set_presentData()
    End Sub
    Private Sub cbKeiNumber_Enter(sender As Object, e As EventArgs) Handles cbKeiNumber.Enter
        rbJapanZone.Checked = True
    End Sub
    Private Sub set_presentData()
        Dim n As Integer = lbFile.SelectedIndex
        If n <> -1 And Me.Tag <> "OFF" Then
            Dim efile As clsE00.E00file_info = E00Files(n)
            With efile.Zahyo
                Select Case True
                    Case rbLatLon.Checked
                        .Mode = enmZahyo_mode_info.Zahyo_Ido_Keido
                    Case rbJapanZone.Checked
                        .Mode = enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                    Case rbOther.Checked
                        .Mode = enmZahyo_mode_info.Zahyo_No_Mode
                End Select

                Select Case True
                    Case rbD_Tokyo.Checked
                        .System = enmZahyo_System_Info.Zahyo_System_tokyo
                    Case rbD_World.Checked
                        .System = enmZahyo_System_Info.Zahyo_System_World
                    Case rbD_Other.Checked
                        .System = enmZahyo_System_Info.Zahyo_System_No
                End Select
                .HeimenTyokkaku_KEI_Number = cbKeiNumber.SelectedIndex + 1
            End With
            E00Files(n) = efile
        End If
    End Sub
    ''' <summary>
    ''' ファイルごとの情報表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setE00fileInfomation()
        Me.Tag = "OFF"
        pnlInfo.Visible = True
        gbE00FileInfo.Text = ""
        Dim n As Integer = lbFile.SelectedIndex
        If n <> -1 Then
            With E00Files(n)
                gbE00FileInfo.Text = .FileName
                cbKeiNumber.SelectedIndex = 0
                With .Zahyo
                    gbMode.Enabled = True
                    Select Case .Mode
                        Case enmZahyo_mode_info.Zahyo_No_Mode
                        Case enmZahyo_mode_info.Zahyo_Ido_Keido
                            rbLatLon.Checked = True
                        Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                            rbJapanZone.Checked = True
                            cbKeiNumber.SelectedIndex = .HeimenTyokkaku_KEI_Number - 1
                    End Select
                    gbSystem.Enabled = True
                    Select Case .System
                        Case enmZahyo_System_Info.Zahyo_System_No
                            rbD_Other.Checked = True
                        Case enmZahyo_System_Info.Zahyo_System_tokyo
                            rbD_Tokyo.Checked = True
                        Case enmZahyo_System_Info.Zahyo_System_World
                            rbD_World.Checked = True
                    End Select
                End With
            End With
        End If
        Me.Tag = ""
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim msgTx As String = ""
        If E00Files.Count = 0 Then
            MsgBox("e00ファイルが選択されていません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return

        End If

        Dim n As Integer = E00Files.Count
        Dim shf(n - 1) As clsE00.E00file_info
        For i As Integer = 0 To n - 1
            shf(i) = E00Files(i)
        Next



        Dim refMapZahyo As clsMapData.Zahyo_info
        Dim hd As String
        Dim stt As Integer
        If MapData.NoDataFlag = False Then
            refMapZahyo = MapData.Map.Zahyo
            hd = "現在の地図データ"
            stt = 0
        Else
            refMapZahyo = shf(0).Zahyo
            hd = "先頭のe00ファイル"
            stt = 1
        End If


        For i As Integer = stt To E00Files.Count - 1
            With shf(i)
                Select Case refMapZahyo.Mode
                    Case enmZahyo_mode_info.Zahyo_No_Mode
                        If .Zahyo.Mode <> enmZahyo_mode_info.Zahyo_No_Mode Then
                            MsgBox(hd + "には座標系が設定されていないので、座標系の設定してあるe00ファイルを追加できません。", MsgBoxStyle.Exclamation)
                            CloseCancelF = True
                            Return
                        End If
                    Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                        If .Zahyo.Mode <> enmZahyo_mode_info.Zahyo_HeimenTyokkaku Or
                                    refMapZahyo.HeimenTyokkaku_KEI_Number <> .Zahyo.HeimenTyokkaku_KEI_Number Then
                            MsgBox(hd + "は平面直角座標系なので、平面直角座標系で系番号が同じe00ファイルを追加できません。", MsgBoxStyle.Exclamation)
                            CloseCancelF = True
                            Return
                        End If
                    Case enmZahyo_mode_info.Zahyo_Ido_Keido
                        If .Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
                            MsgBox(hd + "は緯度経度座標系なので、座標系の設定していないe00ファイルを追加できません。", MsgBoxStyle.Exclamation)
                            CloseCancelF = True
                            Return
                        End If
                End Select
            End With
        Next

    End Sub

    Private Sub lbFile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbFile.SelectedIndexChanged
        sete00fileInfomation()
    End Sub
    Private Sub lbFile_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lbFile.MouseMove
        Dim i As Integer = lbFile.IndexFromPoint(New Point(e.X, e.Y))
        If i <> -1 Then
            If E00Files(i).FullPath <> ToolTip1.GetToolTip(lbFile) Then
                ToolTip1.SetToolTip(lbFile, E00Files(i).FullPath)
            End If
        Else
            ToolTip1.SetToolTip(lbFile, "")
        End If
    End Sub

    Private Sub frmMED_E00File_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_E00File", Me)
        e.Cancel = True
    End Sub
End Class