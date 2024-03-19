Public Class frmPrint_LinePattern
    Dim attrData As clsAttrData
    ''' <summary>
    ''' 個別地図ファイルの線種clsMapData.LPatSek_Infoを配列で入れる
    ''' </summary>
    ''' <remarks></remarks>
    Dim NewLineKind As New List(Of clsMapData.LPatSek_Info())
    Dim MapFileList() As String
    Dim MeshLpat As Line_Property
    Private picLineBox() As System.Windows.Forms.PictureBox
    Private lblLineName() As System.Windows.Forms.Label
    Private Const LineKindHeight = 30


    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData)
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        attrData = _attrData
        MapFileList = attrData.GetMapFileName()
        For i As Integer = 0 To MapFileList.Length - 1
             Dim LK() As clsMapData.LPatSek_Info
            attrData.SetMapFile(MapFileList(i)).Get_TotalLineKind(LK)
            NewLineKind.Add(LK)
        Next
        cboLinePattern.Items.AddRange(MapFileList)
        cboLinePattern.SelectedIndex = 0
        MeshLpat = attrData.TotalData.ViewStyle.MeshLine
        Dim f As Boolean
        For i As Integer = 0 To attrData.TotalData.LV1.Lay_Maxn - 1
            If attrData.LayerData(i).Type = clsAttrData.enmLayerType.Mesh Then
                f = True
                Exit For
            End If
        Next
        If f = True Then
            pnlMeshLine.Visible = True
            attrData.Draw_Sample_LineBox(picMeshLine, MeshLpat)
            pnlLinePattern.Height = pnlMeshLine.Top - pnlLinePattern.Top - 5
        Else
            pnlMeshLine.Visible = False
            pnlLinePattern.Height = pnlMeshLine.Top + pnlMeshLine.Height - pnlLinePattern.Top
        End If
        Return Me.ShowDialog()
    End Function



    Private Sub showLinePattern()
        Dim LeftMargin = SystemInformation.VerticalScrollBarWidth + 3
        If Me.picLineBox Is Nothing = False Then
            For Each p As PictureBox In Me.picLineBox
                RemoveHandler p.Click, AddressOf picLineBoxClick
                Me.pnlLineList.Controls.Remove(p)
            Next
            For Each t As Label In Me.lblLineName
                Me.pnlLineList.Controls.Remove(t)
            Next
        End If

        Dim Mpindex As Integer = cboLinePattern.SelectedIndex
        Dim lnum As Integer = NewLineKind.Item(Mpindex).Length
        pnlLineList.Width = pnlLinePattern.Width - LeftMargin
        pnlLineList.Height = lnum * LineKindHeight + 10
        Me.picLineBox = New PictureBox(lnum - 1) {}
        Me.lblLineName = New Label(lnum - 1) {}
        For i As Integer = 0 To lnum - 1
            Me.picLineBox(i) = New System.Windows.Forms.PictureBox
            Me.lblLineName(i) = New System.Windows.Forms.Label
            With Me.picLineBox(i)
                .Parent = pnlLineList
                .Top = i * LineKindHeight + 3
                .Height = LineKindHeight - 6
                .Left = pnlLineList.Width - 60
                .Width = 55
                .Tag = i
                .BorderStyle = BorderStyle.Fixed3D
                AddHandler .Click, AddressOf picLineBoxClick
                attrData.Draw_Sample_LineBox(Me.picLineBox(i), NewLineKind.Item(Mpindex)(i).Pat)
            End With
            With Me.lblLineName(i)
                .Parent = pnlLineList
                .Top = i * LineKindHeight + 3
                .Left = 3
                .AutoSize = False
                .Width = Me.picLineBox(i).Left - 6
                .Height = Me.picLineBox(i).Height
                .Text = NewLineKind.Item(Mpindex)(i).Name
            End With
        Next

    End Sub
    Private Sub picLineBoxClick(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim Mpindex As Integer = cboLinePattern.SelectedIndex
        If attrData.Select_Line_Pattern(NewLineKind.Item(Mpindex)(sender.tag).Pat, True) = True Then
            attrData.Draw_Sample_LineBox(Me.picLineBox(sender.tag), NewLineKind.Item(Mpindex)(sender.tag).Pat)
        End If

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        For i As Integer = 0 To MapFileList.Length - 1
            Dim LK() As clsMapData.LPatSek_Info = DirectCast(NewLineKind.Item(i), clsMapData.LPatSek_Info())
            attrData.SetMapFile(MapFileList(i)).Set_TotalLineKind(LK)
            attrData.TotalData.ViewStyle.MeshLine = MeshLpat
        Next
    End Sub

    Private Sub picMeshLine_Click(sender As Object, e As EventArgs) Handles picMeshLine.Click
        attrData.Select_Line_Pattern(picMeshLine, MeshLpat, True)
    End Sub

    Private Sub cboLinePattern_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLinePattern.SelectedIndexChanged

        showLinePattern()
    End Sub
    Private Sub Help_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "frmPrint_LinePattern", Me)
    End Sub
End Class