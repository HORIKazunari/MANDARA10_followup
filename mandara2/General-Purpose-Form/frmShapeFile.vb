Public Class frmShapeFile

    Dim CloseCancelF As Boolean
    Dim MapData As clsMapData
    Dim prj As enmProjection_Info
    Dim ShapeFiles As New List(Of clsShapefile.shapefile_info)

    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef _MapData As clsMapData, ByVal integrateText As String) As Windows.Forms.DialogResult
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
                If MapData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
                    gbProjection.Visible = False
                Else
                    .SelectedIndex = .Items.IndexOf(clsGeneric.getStringProjectionEnum(MapData.Map.Zahyo.Projection))
                    cbProjection.Enabled = False
                End If
            End If
        End With
        chkIntegrate.Text = integrateText
        gbShapeFileInfo.Text = ""
        pnlInfo.Visible = False
        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResult(ByRef topology_f As Boolean, ByRef integrateF As Boolean) As clsShapefile.shapefile_info()
        Dim n As Integer = ShapeFiles.Count
        Dim shf(n - 1) As clsShapefile.shapefile_info
        For i As Integer = 0 To n - 1
            shf(i) = ShapeFiles(i)
            shf(i).Zahyo.Projection = clsGeneric.getProjectionEnum_fromStrings(cbProjection.Text)
        Next
        topology_f = chkTopology.Checked
        integrateF = chkIntegrate.Checked
        Return shf
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim sfd As New OpenFileDialog
        sfd.InitialDirectory = clsSettings.Data.Directory.Shapefile
        sfd.Filter = "shapeファイル(*.shp)|*.shp"
        sfd.Multiselect = True
        sfd.Title = "シェープファイル読み込み"
        If sfd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim n As Integer = sfd.FileNames.Length
            Dim onum As Integer = lbFile.Items.Count
            For i As Integer = 0 To ShapeFiles.Count - 1
                For j As Integer = 0 To n - 1
                    If System.IO.Path.GetFileName(sfd.FileNames(j)) = ShapeFiles(i).FileName Then
                        MsgBox(ShapeFiles(i).FileName + "は既に読み込まれています。", MsgBoxStyle.Exclamation)
                        Return
                    End If
                Next
            Next
            For i As Integer = 0 To n - 1
                Dim ShapeData As clsShapefile.shapefile_info
                With ShapeData
                    .FullPath = sfd.FileNames(i)
                    .FileName = System.IO.Path.GetFileName(.FullPath)
                    Dim prj As String = clsGeneric.ReplaceFileExtention(.FullPath, "prj")
                    .prj_file_exist = System.IO.File.Exists(prj)
                    .shx_file_exist = System.IO.File.Exists(clsGeneric.ReplaceFileExtention(.FullPath, "shx"))
                    Dim dbf As String = clsGeneric.ReplaceFileExtention(.FullPath, "dbf")
                    .dbf_file_exist = System.IO.File.Exists(dbf)
                    .DBFfieldNumber = 0
                    If .dbf_file_exist = True Then
                        clsShapefile.Get_DBFFiledNumber(dbf, .DBFfieldNumber)
                    End If
                    .encodingnumber = 932 'デフォルトはSHIFT_JIS
                    .Shape = enmShape.NotDeffinition
                    clsShapefile.Get_ShapfileShape(.FullPath, .Shape)
                    If .prj_file_exist = True Then
                        clsShapefile.Check_prj_file(prj, .Zahyo)
                    Else
                        .Zahyo.System = enmZahyo_System_Info.Zahyo_System_World
                        '.Zahyo.Projection = clsSettings.Data.default_Projection
                    End If
                End With
                ShapeFiles.Add(ShapeData)
                lbFile.Items.Add(ShapeData.FileName)
            Next
            lbFile.SelectedIndex = onum
            clsSettings.Data.Directory.Shapefile = System.IO.Path.GetDirectoryName(sfd.FileNames(0))
        End If
        sfd.Dispose()
    End Sub

    Private Sub lbFile_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lbFile.MouseMove
        Dim i As Integer = lbFile.IndexFromPoint(New Point(e.X, e.Y))
        If i <> -1 Then
            If ShapeFiles(i).FullPath <> ToolTip1.GetToolTip(lbFile) Then
                ToolTip1.SetToolTip(lbFile, ShapeFiles(i).FullPath)
            End If
        Else
            ToolTip1.SetToolTip(lbFile, "")
        End If
    End Sub

    Private Sub lbFile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbFile.SelectedIndexChanged
        setShapefileInfomation()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim n As Integer = lbFile.SelectedIndex
        If n <> -1 Then
            ShapeFiles.RemoveAt(n)
            lbFile.Items.RemoveAt(n)
            If lbFile.Items.Count = 0 Then
                gbShapeFileInfo.Text = ""
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
        ShapeFiles.Clear()
        lbFile.Items.Clear()
        gbShapeFileInfo.Text = ""
        pnlInfo.Visible = False
    End Sub
    ''' <summary>
    ''' ファイルごとの情報表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setShapefileInfomation()
        Me.Tag = "OFF"
        pnlInfo.Visible = True
        gbShapeFileInfo.Text = ""
        Dim n As Integer = lbFile.SelectedIndex
        If n <> -1 Then
            With ShapeFiles(n)
                gbShapeFileInfo.Text = .FileName
                txtFullPath.Text = .FullPath
                If .shx_file_exist = True Then
                    lbSHX.Text = "shxファイル：あり"
                Else
                    lbSHX.Text = "shxファイル：なし"
                End If
                If .dbf_file_exist = True Then
                    lbDBF.Text = "dbfファイル：あり" + vbCrLf + "データ項目数：" + .DBFfieldNumber.ToString()

                Else
                    lbDBF.Text = "dbfファイル：なし"
                End If
                If .prj_file_exist = True Then
                    lbPRJ.Text = "prjファイル：あり"
                Else
                    lbPRJ.Text = "prjファイル：なし"
                End If
                lblShape.Text = "形状：" + clsGeneric.ConvertShapeEnumString(.Shape)
                cbKeiNumber.SelectedIndex = 0
                With .Zahyo
                    gbMode.Enabled = True
                    Select Case .Mode
                        Case enmZahyo_mode_info.Zahyo_No_Mode
                        Case enmZahyo_mode_info.Zahyo_Ido_Keido
                            If ShapeFiles(n).prj_file_exist = True Then
                                gbMode.Enabled = False
                            End If
                            rbLatLon.Checked = True
                        Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                            If ShapeFiles(n).prj_file_exist = True Then
                                gbMode.Enabled = False
                            End If
                            rbJapanZone.Checked = True
                            cbKeiNumber.SelectedIndex = .HeimenTyokkaku_KEI_Number - 1
                    End Select
                    gbSystem.Enabled = True
                    Select Case .System
                        Case enmZahyo_System_Info.Zahyo_System_No
                            rbD_Other.Checked = True
                        Case enmZahyo_System_Info.Zahyo_System_tokyo
                            If ShapeFiles(n).prj_file_exist = True Then
                                gbSystem.Enabled = False
                            End If
                            rbD_Tokyo.Checked = True
                        Case enmZahyo_System_Info.Zahyo_System_World
                            If ShapeFiles(n).prj_file_exist = True Then
                                gbSystem.Enabled = False
                            End If
                            rbD_World.Checked = True
                    End Select
                End With
                setCboEncoding(.encodingnumber)
            End With
        End If
        Me.Tag = ""
    End Sub
    Private Sub set_presentData()
        Dim n As Integer = lbFile.SelectedIndex
        If n <> -1 And Me.Tag <> "OFF" Then
            Dim sfile As clsShapefile.shapefile_info = ShapeFiles(n)
            With sfile.Zahyo
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
                Dim ecode As clsEncodings = DirectCast(cboEncoding.SelectedItem, clsEncodings)
                sfile.encodingnumber = ecode.eis.CodePage
                If chkCommonChange.Checked = True Then
                    For i As Integer = 0 To ShapeFiles.Count - 1
                        Dim cfile As clsShapefile.shapefile_info = ShapeFiles(i)
                        If i <> n Then
                            If cfile.prj_file_exist = False Or .Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
                                cfile.Zahyo.Mode = sfile.Zahyo.Mode
                                cfile.Zahyo.HeimenTyokkaku_KEI_Number = sfile.Zahyo.HeimenTyokkaku_KEI_Number
                            End If
                            If cfile.prj_file_exist = False Or .System = enmZahyo_System_Info.Zahyo_System_No Then
                                cfile.Zahyo.System = sfile.Zahyo.System
                            End If
                        End If
                        cfile.encodingnumber = sfile.encodingnumber
                        ShapeFiles(i) = cfile
                    Next
                End If
            End With
            ShapeFiles(n) = sfile
        End If
    End Sub
    Private Sub frmShapeFile_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim msgTx As String = ""
        If ShapeFiles.Count = 0 Then
            MsgBox("シェープファイルが選択されていません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return

        End If

        Dim n As Integer = ShapeFiles.Count
        Dim shf(n - 1) As clsShapefile.shapefile_info
        For i As Integer = 0 To n - 1
            shf(i) = ShapeFiles(i)
        Next

        For i As Integer = 0 To n - 1
            With shf(i)
                If .shx_file_exist = False Then
                    msgTx += .FileName + "はshxファイルが見つかりません。"
                End If
            End With
        Next
        If msgTx <> "" Then
            MsgBox(msgTx, MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If

        Dim refMapZahyo As clsMapData.Zahyo_info
        Dim hd As String
        Dim stt As Integer
        If MapData.NoDataFlag = False Then
            refMapZahyo = MapData.Map.Zahyo
            hd = "現在の地図データ"
            stt = 0
        Else
            refMapZahyo = shf(0).Zahyo
            hd = "先頭のシェープファイル"
            stt = 1
        End If


        For i As Integer = stt To ShapeFiles.Count - 1
            With shf(i)
                Select Case refMapZahyo.Mode
                    Case enmZahyo_mode_info.Zahyo_No_Mode
                        If .Zahyo.Mode <> enmZahyo_mode_info.Zahyo_No_Mode Then
                            MsgBox(hd + "には座標系が設定されていないので、座標系の設定してあるシェープファイルを追加できません。", MsgBoxStyle.Exclamation)
                            CloseCancelF = True
                            Return
                        End If
                    Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                        If .Zahyo.Mode <> enmZahyo_mode_info.Zahyo_HeimenTyokkaku Or
                                    refMapZahyo.HeimenTyokkaku_KEI_Number <> .Zahyo.HeimenTyokkaku_KEI_Number Then
                            MsgBox(hd + "は平面直角座標系なので、平面直角座標系で系番号が同じシェープファイルしか追加できません。", MsgBoxStyle.Exclamation)
                            CloseCancelF = True
                            Return
                        End If
                    Case enmZahyo_mode_info.Zahyo_Ido_Keido
                        If .Zahyo.Mode = enmZahyo_mode_info.Zahyo_No_Mode Then
                            MsgBox(hd + "は緯度経度座標系なので、座標系の設定していないシェープファイルは追加できません。", MsgBoxStyle.Exclamation)
                            CloseCancelF = True
                            Return
                        End If
                End Select
            End With
        Next

        If chkIntegrate.Checked = True Then
            For i As Integer = 1 To n - 1
                If ShapeFiles(i).Shape <> ShapeFiles(0).Shape Then
                    MsgBox("シェープファイルの形状が混在しているのでまとめられません。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                If ShapeFiles(i).DBFfieldNumber <> ShapeFiles(0).DBFfieldNumber Then
                    MsgBox("シェープファイルのデータ項目数が異なるのでまとめられません。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
            Next
        End If
    End Sub

    Private Sub cbKeiNumber_Enter(sender As Object, e As EventArgs) Handles cbKeiNumber.Enter
        rbJapanZone.Checked = True
    End Sub


    Private Sub rbLatLon_CheckedChanged(sender As Object, e As EventArgs) Handles rbLatLon.CheckedChanged,
        rbJapanZone.CheckedChanged, rbOther.CheckedChanged, rbD_Tokyo.CheckedChanged, rbD_World.CheckedChanged,
        rbD_Other.CheckedChanged, cbKeiNumber.SelectedIndexChanged
        set_presentData()
    End Sub

    Private Sub frmShapeFile_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.SubWindow, "frmShapeFile", Me)
    End Sub

    Private Sub frmShapeFile_Load(sender As Object, e As EventArgs) Handles Me.Load
        clsGeneric.SetEncodings_to_Cbobox(cboEncoding)
    End Sub
    Private Sub setCboEncoding(ByVal encodingnumber As Integer)
        For i As Integer = 0 To cboEncoding.Items.Count - 1
            Dim ecode As clsEncodings = DirectCast(cboEncoding.Items(i), clsEncodings)
            Dim ecodenum = ecode.eis.CodePage
            If ecodenum = encodingnumber Then
                cboEncoding.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub cboEncoding_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEncoding.SelectedIndexChanged

        set_presentData()
    End Sub
End Class