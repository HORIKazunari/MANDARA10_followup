Public Class frmMain_ShowViewer
    Public Structure strLayerInfo
        Public Name As String
        Public MapfileName As String
        Public UseObjectKind() As Boolean
        Public Time As strYMD
        Public Shape As enmShape
    End Structure
    Dim CloseCancelF As Boolean
    Private MapData As New Dictionary(Of String, clsMapData)
    Private LayerData As New List(Of strLayerInfo)
    Dim TileMap As clsTileMapService


    Private Sub frmMain_ShowViewer_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_ShowViewer", Me)

    End Sub
    Public Overloads Function ShowDialog(ByVal defoMapFilePath As String, ByVal _TileMap As clsTileMapService) As Windows.Forms.DialogResult
        gbLayer.Enabled = False
        TileMap = _TileMap
        If defoMapFilePath <> "" Then
            AddMapFile(defoMapFilePath)
        End If
        Return Me.ShowDialog
    End Function


    Private Sub frmMain_ShowViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub btnAddMapFile_Click(sender As Object, e As EventArgs) Handles btnAddMapFile.Click
        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = clsGeneric.Get_MapFolder
        ofd.Filter = "MANDARA地図ファイル(*.mpf?)|*.mpf?|圧縮地図ファイル(*.mpfz)|*.mpfz|非圧縮ファイル(*.mpfx)|*.mpfx|旧地図ファイル(*.mpf)|*.mpf"
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim fname As String = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName)
            Dim mfile As String() = MapData.Keys.ToArray
            If Array.IndexOf(mfile, fname) <> -1 Then
                MsgBox(fname + "は既に読み込まれています。", MsgBoxStyle.Exclamation)
                Return
            End If
            AddMapFile(ofd.FileName)

        End If
    End Sub
    Private Sub AddMapFile(ByVal MapFileName As String)
        Dim fname As String = System.IO.Path.GetFileNameWithoutExtension(MapFileName)
        Dim mfile As String() = MapData.Keys.ToArray
        Cursor.Current = Cursors.WaitCursor
        Dim mData As clsMapData = New clsMapData(MapFileName)
        Cursor.Current = Cursors.Default
        If MapData.Count > 0 Then
            Dim z As clsMapData.Zahyo_info = MapData(mfile(0)).Map.Zahyo
            Dim emes As String
            If spatial.Check_Zahyo_Projection_Convert_Enabled(z, mData.Map.Zahyo, emes) = False Then
                MsgBox(emes, MsgBoxStyle.Exclamation)
                Return
            End If
        End If
        mData.Map.FileName = fname
        mData.Map.FullPath = MapFileName
        MapData.Add(fname, mData)
        lstMapFile.Items.Add(fname)
        cboMapFile.Items.Add(fname)
        gbLayer.Enabled = True
        If lstLayer.Items.Count = 0 Then
            gbLayerSetting.Enabled = False
        Else
            gbLayerSetting.Enabled = True
        End If
        Me.Tag = "OFF"
        cboMapFile.SelectedIndex = cboMapFile.Items.Count - 1
        AddLayer()
    End Sub
    Private Sub btnAddLayer_Click(sender As Object, e As EventArgs) Handles btnAddLayer.Click
        AddLayer()
    End Sub
    Private Sub AddLayer()
        Dim n As Integer = LayerData.Count
        Dim d As strLayerInfo
        Dim okn As Integer
        Me.Tag = "OFF"
        With d
            .Time = clsTime.GetYMD(Date.Today)
            .MapfileName = cboMapFile.Text
            .Name = "レイヤ" + .MapfileName
            okn = MapData(.MapfileName).Map.OBKNum
            ReDim .UseObjectKind(okn - 1)
        End With
        With chkObjKind
            .Items.Clear()
            For i As Integer = 0 To okn - 1
                .Items.Add(MapData(d.MapfileName).ObjectKind(i).Name)
            Next
        End With
        LayerData.Add(d)
        lstLayer.Items.Add(d.Name)
        Me.Tag = ""
        lstLayer.SelectedIndex = n
        gbLayerSetting.Enabled = True
    End Sub

    Private Sub lstLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLayer.SelectedIndexChanged
        If Me.Tag = "OFF" Then Return
        Dim n As Integer = lstLayer.SelectedIndex
        If n = -1 Then
            If lstLayer.Items.Count = 0 Then
                gbLayerSetting.Enabled = False
            Else
                lstLayer.SelectedIndex = 0
            End If
            Return
        End If
        Dim d As strLayerInfo = LayerData.Item(n)
        Me.Tag = "OFF"
        With d
            cboMapFile.Text = .MapfileName
            txtLayerName.Text = .Name
            Dim okn As Integer = MapData(.MapfileName).Map.OBKNum
            ReDim .UseObjectKind(okn - 1)
        End With
        checkTime()
        resetObjKind()
        Me.Tag = ""
    End Sub

    Private Sub btnDeleteMapFile_Click(sender As Object, e As EventArgs) Handles btnDeleteMapFile.Click
        Dim n As Integer = lstMapFile.SelectedIndex
        If n = -1 Then
            Return
        End If
        Dim mfile As String() = MapData.Keys.ToArray
        Dim delMapfile As String = mfile(n)
        For Each layd In LayerData
            If layd.MapfileName = delMapfile Then
                MsgBox(delMapfile + "は使用されています。", MsgBoxStyle.Exclamation)
                Return
            End If
        Next
        MapData.Remove(delMapfile)
        lstMapFile.Items.RemoveAt(n)
        cboMapFile.Items.RemoveAt(n)
    End Sub



    Private Sub DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker.ValueChanged
        If Me.Tag = "OFF" Then Return
        setValue()
    End Sub
    Private Sub setValue()
        Dim n As Integer = lstLayer.SelectedIndex
        If n = -1 Then Return
        Dim d As strLayerInfo = LayerData.Item(n)
        With d
            .MapfileName = cboMapFile.Text
            .Time = clsTime.GetYMD(DateTimePicker.Value)
            .Name = txtLayerName.Text
            For i As Integer = 0 To chkObjKind.Items.Count - 1
                .UseObjectKind(i) = chkObjKind.GetItemChecked(i)
            Next
        End With
        LayerData.Item(n) = d
    End Sub

    Private Sub txtLayerName_TextChanged(sender As Object, e As EventArgs) Handles txtLayerName.TextChanged
        If Me.Tag = "OFF" Then Return
        setValue()
        Dim n As Integer = lstLayer.SelectedIndex
        If n <> -1 Then
            Me.Tag = "OFF"
            lstLayer.Items(n) = txtLayerName.Text
            Me.Tag = ""
        End If
    End Sub

    Private Sub cboMapFile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMapFile.SelectedIndexChanged
        If Me.Tag = "OFF" Then Return
        Dim n As Integer = lstLayer.SelectedIndex
        If n = -1 Then Return
        Dim d As strLayerInfo = LayerData.Item(n)
        Dim okn As Integer
        With d
            .MapfileName = cboMapFile.Text
            okn = MapData(.MapfileName).Map.OBKNum
            ReDim .UseObjectKind(okn - 1)
        End With
        LayerData.Item(n) = d
        checkTime()
        resetObjKind()
    End Sub

    Private Sub chkObjKind_SelectedIndexChanged(sender As Object, ByVal e As EventArgs) Handles chkObjKind.Leave
        If Me.Tag = "OFF" Then Return
        setValue()
    End Sub
    Private Sub resetObjKind()
        Dim n As Integer = lstLayer.SelectedIndex
        If n = -1 Then Return

        Dim d As strLayerInfo = LayerData.Item(n)
        Dim okn As Integer = MapData(d.MapfileName).Map.OBKNum
        With chkObjKind
            .Items.Clear()
            For i As Integer = 0 To okn - 1
                Dim str As String = MapData(d.MapfileName).ObjectKind(i).Name
                str += "(" + clsGeneric.ConvertShapeEnumString(MapData(d.MapfileName).ObjectKind(i).Shape) + ")"
                .Items.Add(str)
                .SetItemChecked(i, d.UseObjectKind(i))
            Next
        End With
    End Sub
    Private Sub checkTime()
        Dim n As Integer = lstLayer.SelectedIndex
        If n = -1 Then Return
        Dim d As strLayerInfo = LayerData.Item(n)
        With d
            If MapData(.MapfileName).Map.Time_Mode = True Then
                DateTimePicker.Enabled = True
                DateTimePicker.Value = clsTime.getDateTime(.Time)
            Else
                DateTimePicker.Enabled = False
            End If
        End With
    End Sub


    Private Sub btnDeleteLayer_Click(sender As Object, e As EventArgs) Handles btnDeleteLayer.Click
        Dim n As Integer = lstLayer.SelectedIndex
        If n = -1 Then Return
        LayerData.RemoveAt(n)
        lstLayer.Items.RemoveAt(n)
        clsGeneric.ListIndex_Reset(lstLayer, n)
    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        For i As Integer = 0 To LayerData.Count - 1
            Dim LD As strLayerInfo = LayerData.Item(i)
            With LD

                Dim f1 As Boolean = False
                For j As Integer = 0 To .UseObjectKind.Length - 1
                    If .UseObjectKind(j) = True Then
                        .Shape = MapData(.MapfileName).ObjectKind(j).Shape
                        f1 = True
                        Exit For
                    End If
                Next
                If f1 = False Then
                    MsgBox("レイヤ" + .Name + "で表示するオブジェクトクループが設定されていません。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                Dim emes As String = ""
                If MapData(.MapfileName).Check_Selected_ObjectGroup_Same(.UseObjectKind, emes, False, False) = False Then
                    MsgBox(emes, MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                If MapData(.MapfileName).Map.Time_Mode = False Then
                    .Time = clsTime.GetNullYMD
                End If
            End With
            LayerData.Item(i) = LD
        Next
    End Sub
    Public Function GetResult() As clsAttrData
        Dim attrData As New clsAttrData(TileMap)
        attrData.SetMapViewerData(MapData, LayerData, False)

        Return attrData
    End Function


End Class