Public Class frmUserTileMap
    Dim CloseCancelF As Boolean
    Dim UserTile As List(Of strTileMapData_Info)
    Dim TileMap As clsTileMapService
    Dim selectNum As Integer
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
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef _TileMap As clsTileMapService) As Windows.Forms.DialogResult
        cboMaxZoom.Items.Clear()
        cboMinZoom.Items.Clear()
        For i As Integer = 0 To 20
            cboMaxZoom.Items.Add(i)
            cboMinZoom.Items.Add(i)
        Next
        cboExt.Items.Clear()
        cboExt.Items.AddRange({".png", ".jpg", ".jpeg", ".bmp"})
        TileMap = _TileMap
        Dim _UserTile As strTileMapData_Info() = TileMap.getTileMapList("ユーザー設定タイルマップ")
        UserTile = New List(Of strTileMapData_Info)
        If _UserTile Is Nothing = False Then
            UserTile.AddRange(_UserTile)
        End If
        list.Items.Clear()
        If UserTile.Count = 0 Then
            gbSetting.Visible = False
            btnUpword.Enabled = False
            btnDownword.Enabled = False
            selectNum = -1
        Else
            For i As Integer = 0 To UserTile.Count - 1
                list.Items.Add(UserTile(i).Name)
            Next
            list.SelectedIndex = 0
        End If
        Return Me.ShowDialog

    End Function
    Public Function GetResults() As clsTileMapService
        TileMap.RemoveTileMapListByTag("ユーザー設定タイルマップ")
        For i As Integer = 0 To UserTile.Count - 1
            TileMap.AddTileMap(UserTile(i))
        Next
    End Function


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim uname As String = ""
        If UserTile.Count = 0 Then
            uname = "ユーザー定義タイル1"
        Else
            Dim name(UserTile.Count - 1) As String
            For i As Integer = 0 To UserTile.Count - 1
                name(i) = UserTile(i).Name
            Next
            uname = clsGeneric.Get_New_Numbering_Strings("ユーザー定義タイル", name)
        End If
        Dim Tile As strTileMapData_Info
        With Tile
            .Name = uname
            .ReverseF = False
            .ZoomLevelMin = 10
            .zoomLevelMax = 15
            .XYZOrder = enmXYZOrder.ZXY
            .URL = ""
            .Tag = "ユーザー設定タイルマップ"
            .exp = ".png"
            .CommentaryURL = ""
            .Copyright = ""
        End With
        UserTile.Add(Tile)
        list.Items.Add(Tile.Name)
        list.SelectedIndex = UserTile.Count - 1
    End Sub
    Private Sub setSettingBox()
        gbSetting.Visible = True
        btnDownword.Enabled = True
        btnUpword.Enabled = True
        Me.Tag = "OFF"
        With UserTile(selectNum)
            txtCopyright.Text = .Copyright
            txtName.Text = .Name
            txtLegendURL.Text = .CommentaryURL
            txtURL.Text = .URL
            cboMaxZoom.SelectedIndex = .zoomLevelMax
            cboMinZoom.SelectedIndex = .ZoomLevelMin
            cboExt.Text = .exp
            Select Case .XYZOrder
                Case enmXYZOrder.ZXY
                    rbZXY.Checked = True
                Case enmXYZOrder.ZYX
                    rbZYX.Checked = True
            End Select
            If .ReverseF = True Then
                rbOrignSW.Checked = True
            Else
                rbOrifinNW.Checked = True
            End If
        End With
        Me.Tag = ""
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        UserTile.RemoveAt(selectNum)
        Me.Tag = "OFF"
        list.Items.RemoveAt(selectNum)
        Me.Tag = ""
        If UserTile.Count = 0 Then
            gbSetting.Visible = False
            btnDownword.Enabled = False
            btnUpword.Enabled = False
            selectNum = -1
        Else
            Dim newselectNum As Integer = selectNum
            If newselectNum >= UserTile.Count Then
                newselectNum = UserTile.Count - 1
            End If
            list.SelectedIndex = newselectNum
        End If

    End Sub

    Private Sub list_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles list.SelectedIndexChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        selectNum = list.SelectedIndex
        If selectNum = -1 Then
            gbSetting.Visible = False
            btnDownword.Enabled = False
            btnUpword.Enabled = False
        Else
            setSettingBox()
        End If
    End Sub

    Private Sub btnUpword_Click(sender As Object, e As EventArgs) Handles btnUpword.Click
        Dim newselectNum As Integer = selectNum - 1
        If newselectNum = -1 Then
            newselectNum = UserTile.Count - 1
        End If
        Dim tile As strTileMapData_Info = UserTile(selectNum)
        UserTile.RemoveAt(selectNum)
        UserTile.Insert(newselectNum, tile)
        list.Items.RemoveAt(selectNum)
        list.Items.Insert(newselectNum, tile.Name)
        list.SelectedIndex = newselectNum
    End Sub

    Private Sub btnDownword_Click(sender As Object, e As EventArgs) Handles btnDownword.Click
        Dim newselectNum As Integer = selectNum + 1
        If newselectNum = UserTile.Count Then
            newselectNum = 0
        End If
        Dim tile As strTileMapData_Info = UserTile(selectNum)
        UserTile.RemoveAt(selectNum)
        UserTile.Insert(newselectNum, tile)
        list.Items.RemoveAt(selectNum)
        list.Items.Insert(newselectNum, tile.Name)
        list.SelectedIndex = newselectNum
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.LostFocus
        If Me.Tag = "OFF" Or selectNum = -1 Then
            Return
        End If
        Dim tile As strTileMapData_Info = UserTile(selectNum)
        With tile
            .Name = txtName.Text
            Me.Tag = "OFF"
            list.Items(selectNum) = .Name
            Me.Tag = ""
        End With
        UserTile(selectNum) = tile
    End Sub

    Private Sub txtURL_TextChanged(sender As Object, e As EventArgs) Handles txtURL.LostFocus
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim tile As strTileMapData_Info = UserTile(selectNum)
        With tile
            .URL = txtURL.Text
        End With
        UserTile(selectNum) = tile

    End Sub

    Private Sub rbOrifinNW_CheckedChanged(sender As Object, e As EventArgs) Handles rbOrifinNW.CheckedChanged, rbOrignSW.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim tile As strTileMapData_Info = UserTile(selectNum)
        With tile
            If rbOrifinNW.Checked = True Then
                .ReverseF = False
            Else
                .ReverseF = True
            End If
        End With
        UserTile(selectNum) = tile

    End Sub

    Private Sub rbZXY_CheckedChanged(sender As Object, e As EventArgs) Handles rbZXY.CheckedChanged, rbZXY.CheckedChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim tile As strTileMapData_Info = UserTile(selectNum)
        With tile
            If rbZXY.Checked = True Then
                .XYZOrder = enmXYZOrder.ZXY
            Else
                .XYZOrder = enmXYZOrder.ZYX
            End If
        End With
        UserTile(selectNum) = tile
    End Sub

    Private Sub cboMaxZoom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMaxZoom.SelectedIndexChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim tile As strTileMapData_Info = UserTile(selectNum)
        With tile
            .zoomLevelMax = cboMaxZoom.SelectedIndex
        End With
        UserTile(selectNum) = tile
    End Sub

    Private Sub cboMinZoom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMinZoom.SelectedIndexChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim tile As strTileMapData_Info = UserTile(selectNum)
        With tile
            .ZoomLevelMin = cboMinZoom.SelectedIndex
        End With
        UserTile(selectNum) = tile
    End Sub

    Private Sub cboExt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboExt.SelectedIndexChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim tile As strTileMapData_Info = UserTile(selectNum)
        With tile
            .exp = cboExt.Text
        End With
        UserTile(selectNum) = tile
    End Sub

    Private Sub txtLegendURL_TextChanged(sender As Object, e As EventArgs) Handles txtLegendURL.TextChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim tile As strTileMapData_Info = UserTile(selectNum)
        With tile
            .CommentaryURL = txtLegendURL.Text
        End With
        UserTile(selectNum) = tile
    End Sub

    Private Sub txtCopyright_TextChanged(sender As Object, e As EventArgs) Handles txtCopyright.TextChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        Dim tile As strTileMapData_Info = UserTile(selectNum)
        With tile
            .Copyright = txtCopyright.Text
        End With
        UserTile(selectNum) = tile
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        For i As Integer = 0 To UserTile.Count - 1
            With UserTile(i)
                If .zoomLevelMax < .ZoomLevelMin Then
                    MsgBox(UserTile(i).Name + "はズームレベルの最大値が最小値より小さくなっています。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                If .Name = "" Then
                    MsgBox("名称が設定されていない箇所があります。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                If .URL = "" Then
                    MsgBox("URLが設定されていない箇所があります。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                For j As Integer = i + 1 To UserTile.Count - 1
                    If .Name = UserTile(j).Name Then
                        MsgBox(UserTile(i).Name + "は同一の名称が複数あります。", MsgBoxStyle.Exclamation)
                        CloseCancelF = True
                        Return
                    End If
                Next
            End With
        Next
    End Sub


    Private Sub frmUserTileMap_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SubWindow, "frmUserTileMap", Me)

    End Sub
End Class