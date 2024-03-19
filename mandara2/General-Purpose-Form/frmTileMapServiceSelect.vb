Public Class frmTileMapServiceSelect
    Dim CloseCancelF As Boolean
    Dim TileMap As clsTileMapService
    Dim TileMapDataSet As strTileMapData_Info
    Dim TileDataSet As Dictionary(Of String, strTileMapData_Info())


    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal TileMapView As strTileMapViewDataInfo,
                                     ByVal Visible As Boolean,
                 ByRef _TileMap As clsTileMapService) As Windows.Forms.DialogResult
        cbVisible.Visible = True
        cbVisible.Checked = Visible
        gbDrawTiming.Visible = False
        TileMap = _TileMap
        TileMapDataSet = TileMapView.TileMapDataSet
        setDefaultValue(TileMapView)

        Return Me.ShowDialog(Owner)

    End Function
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal TileMapView As strTileMapViewDataInfo,
             ByRef _TileMap As clsTileMapService) As Windows.Forms.DialogResult
        cbVisible.Visible = False
        gbDrawTiming.Visible = False
        TileMap = _TileMap
        TileMapDataSet = TileMapView.TileMapDataSet
        setDefaultValue(TileMapView)
        Return Me.ShowDialog(Owner)
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Owner"></param>
    ''' <param name="TileMapView"></param>
    ''' <param name="_TileMap"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal TileMapView As strTileMapViewDataInfo,
                                         ByVal Visible As Boolean, ByVal DrawTiming As enmDrawTiming,
                     ByRef _TileMap As clsTileMapService) As Windows.Forms.DialogResult

        cbVisible.Visible = True
        cbVisible.Checked = Visible
        gbDrawTiming.Visible = True
        If DrawTiming = enmDrawTiming.BeforeDataDraw Then
            rbBeforeDraw.Checked = True
        Else
            rbAfterDraw.Checked = True
        End If
        TileMap = _TileMap
        TileMapDataSet = TileMapView.TileMapDataSet
        setDefaultValue(TileMapView)
        Return Me.ShowDialog(Owner)
    End Function
    Private Sub setDefaultValue(ByVal TileMapView As strTileMapViewDataInfo)
        With TileMapView
            hsbAlphaValue.Value = .AlphaValue
            FolderSelectorWorldFile.Folder = .LastWorldFileFolder
            FolderSelectorUser.Folder = .LastUserFolder
            chkTransparent.Checked = .TransparentF
        End With

        setTileDataSet()


        Select Case TileMapDataSet.Name
            Case "ユーザー定義"
                rbUser.Checked = True
                FolderSelectorUser.Folder = TileMapDataSet.URL
            Case "ワールドファイル"
                rbWorldFile.Checked = True
                FolderSelectorWorldFile.Folder = TileMapDataSet.URL
            Case Else
                rbTileMap.Checked = True
                Dim tagList As List(Of String) = TileMap.getTileMapTagList()
                Dim n As Integer = Array.IndexOf(tagList.ToArray, TileMapDataSet.Tag)
                cboTileTag.SelectedIndex = n
                cboTileDataSet.Text = TileMapDataSet.Name
        End Select

    End Sub
    Private Sub setTileDataSet()
        TileDataSet = New Dictionary(Of String, strTileMapData_Info())
        Dim tagList As List(Of String) = TileMap.getTileMapTagList()
        cboTileTag.Items.Clear()
        cboTileTag.Items.AddRange(tagList.ToArray)
        For Each t As String In tagList
            Dim dataList() As strTileMapData_Info = TileMap.getTileMapList(t)
            TileDataSet.Add(t, dataList)
        Next
    End Sub
    Public Sub getResult(ByRef TileMapView As strTileMapViewDataInfo)
        With TileMapView
            .AlphaValue = hsbAlphaValue.Value
            .LastWorldFileFolder = FolderSelectorWorldFile.Folder
            .LastUserFolder = FolderSelectorUser.Folder
            .TileMapDataSet = TileMapDataSet
            .TransparentF = chkTransparent.Checked
        End With

    End Sub
    Public Sub getResult(ByRef TileMapView As strTileMapViewDataInfo, ByRef Visible As Boolean)
        Visible = cbVisible.Checked
        With TileMapView
            .AlphaValue = hsbAlphaValue.Value
            .LastWorldFileFolder = FolderSelectorWorldFile.Folder
            .LastUserFolder = FolderSelectorUser.Folder
            .TileMapDataSet = TileMapDataSet
            .TransparentF = chkTransparent.Checked
        End With

    End Sub
    Public Sub getResult(ByRef TileMapView As strTileMapViewDataInfo, ByRef Visible As Boolean, ByRef DrawTiming As enmDrawTiming)
        Visible = cbVisible.Checked
        If rbBeforeDraw.Checked = True Then
            DrawTiming = enmDrawTiming.BeforeDataDraw
        Else
            DrawTiming = enmDrawTiming.AfterDataDraw
        End If
        With TileMapView
            .AlphaValue = hsbAlphaValue.Value
            .LastWorldFileFolder = FolderSelectorWorldFile.Folder
            .LastUserFolder = FolderSelectorUser.Folder
            .TileMapDataSet = TileMapDataSet
            .TransparentF = chkTransparent.Checked
        End With

    End Sub

    Private Sub cboTileDataSet_Enter(sender As Object, e As EventArgs) Handles cboTileDataSet.Enter, cboTileTag.Enter
        rbTileMap.Checked = True
        cbVisible.Checked = True
    End Sub





    Private Sub rbGSIMap_Enter(sender As Object, e As EventArgs) Handles rbTileMap.Enter, rbUser.EnabledChanged, rbWorldFile.Enter
        cbVisible.Checked = True

    End Sub

    Private Sub frmTileMapServiceSelect_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        Select Case True
            Case rbTileMap.Checked
                If cboTileDataSet.Text = "" Then
                    MsgBox("タイルマップサービスを指定して下さい。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                Else
                    TileMapDataSet = TileMap.getTileMap_by_Name(cboTileDataSet.Text)
                End If
            Case rbUser.Checked
                If FolderSelectorUser.Folder = "" Then
                    MsgBox("ユーザー画像フォルダを指定して下さい。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                Else
                    With TileMapDataSet
                        .Name = "ユーザー定義"
                        .Copyright = ""
                        .URL = FolderSelectorUser.Folder
                    End With
                    If TileMapDataSet.setUserImageFileList() = False Then
                        CloseCancelF = True
                        Return
                    End If
                End If
            Case rbWorldFile.Checked
                If FolderSelectorWorldFile.Folder = "" Then
                    MsgBox("ワールドファイル付き画像ファイルのフォルダを指定して下さい。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                With TileMapDataSet
                    .Name = "ワールドファイル"
                    .Copyright = ""
                    .URL = FolderSelectorWorldFile.Folder
                End With
                If TileMapDataSet.setWorldImageFileList() = False Then
                    CloseCancelF = True
                    Return
                End If
        End Select

    End Sub



    Private Sub FolderSelectorUser_Enter(sender As Object, e As System.EventArgs) Handles FolderSelectorUser.Enter
        rbUser.Checked = True
    End Sub


    Private Sub FolderSelectorWorldFile_Enter(sender As Object, e As EventArgs) Handles FolderSelectorWorldFile.Enter
        rbWorldFile.Checked = True
    End Sub

    Private Sub cboTileTag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTileTag.SelectedIndexChanged
        cboTileDataSet.Items.Clear()
        Dim d() As strTileMapData_Info = TileDataSet(cboTileTag.Text)
        For i As Integer = 0 To d.Length - 1
            cboTileDataSet.Items.Add(d(i).Name)
        Next
        cboTileDataSet.SelectedIndex = 0
    End Sub


    Private Sub btnUserTile_Click(sender As Object, e As EventArgs) Handles btnUserTile.Click
        Dim form As New frmUserTileMap
        If form.ShowDialog(Me, TileMap) = Windows.Forms.DialogResult.OK Then
            Dim oldc As Integer = cboTileTag.SelectedIndex
            form.GetResults()
            setTileDataSet()
            Dim tagList As List(Of String) = TileMap.getTileMapTagList()
            cboTileTag.Items.Clear()
            cboTileTag.Items.AddRange(tagList.ToArray)
            Dim n As Integer = Array.IndexOf(tagList.ToArray, "ユーザー設定タイルマップ")
            If n <> -1 Then
                cboTileTag.SelectedIndex = n
            Else
                cboTileTag.SelectedIndex = Math.Min(oldc, cboTileTag.Items.Count - 1)
            End If
        End If
        form.Dispose()
    End Sub

    Private Sub frmTileMapServiceSelect_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SubWindow, "frmTileMapServiceSelect", Me)

    End Sub
End Class