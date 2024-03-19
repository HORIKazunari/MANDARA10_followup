Public Class frmPrint_FigureList
    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData
    Dim FigList As List(Of Object)
    Dim EditIndex As Integer
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
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData) As Windows.Forms.DialogResult
        EditIndex = -1
        attrData = _attrData
        FigList = New List(Of Object)
        attrData.Set_LayerName_to(cboLayer, -1)
        cboLayer.Items.Insert(0, "全レイヤ")
        With attrData.TotalData
            For i As Integer = 0 To .FigureStac.Count - 1

                Dim data(3) As String
                Dim FigStac As Object = attrData.TotalData.FigureStac(i)
                Select Case True
                    Case TypeOf FigStac Is clsAttrData.strFig_Word_Data
                        Dim FigData As clsAttrData.strFig_Word_Data = DirectCast(FigStac, clsAttrData.strFig_Word_Data)
                        FigList.Add(FigData)
                    Case TypeOf FigStac Is clsAttrData.strFig_Line_Data
                        Dim FigData As clsAttrData.strFig_Line_Data = DirectCast(FigStac, clsAttrData.strFig_Line_Data)
                        Dim FigDataCopy As clsAttrData.strFig_Line_Data
                        With FigData
                            FigDataCopy.Arrow = .Arrow
                            FigDataCopy.Circumscribed_Rectangle = .Circumscribed_Rectangle
                            FigDataCopy.Data = .Data
                            FigDataCopy.FillFlag = .FillFlag
                            FigDataCopy.NumOfPoint = .NumOfPoint
                            FigDataCopy.Patttern = .Patttern
                            FigDataCopy.Points = .Points.Clone
                            FigDataCopy.Spline = .Spline
                            FigDataCopy.Tile = .Tile
                        End With
                        FigList.Add(FigDataCopy)
                    Case TypeOf FigStac Is clsAttrData.strFig_Rectangle_Data
                        Dim FigData As clsAttrData.strFig_Rectangle_Data = DirectCast(FigStac, clsAttrData.strFig_Rectangle_Data)
                        FigList.Add(FigData)
                    Case TypeOf FigStac Is clsAttrData.strFig_Circle_data
                        Dim FigData As clsAttrData.strFig_Circle_data = DirectCast(FigStac, clsAttrData.strFig_Circle_data)
                        FigList.Add(FigData)
                    Case TypeOf FigStac Is clsAttrData.strFig_Point_Data
                        Dim FigData As clsAttrData.strFig_Point_Data = DirectCast(FigStac, clsAttrData.strFig_Point_Data)
                        Dim FigDataCopy As clsAttrData.strFig_Point_Data
                        With FigData
                            FigDataCopy.Caption = .Caption
                            FigDataCopy.Caption_F = .Caption_F
                            FigDataCopy.CaptionPosition = .CaptionPosition
                            FigDataCopy.Data = .Data
                            FigDataCopy.Font = .Font
                            FigDataCopy.Mark = .Mark
                            FigDataCopy.NumOfPoint = .NumOfPoint
                            FigDataCopy.Points = .Points.Clone
                        End With
                        FigList.Add(FigDataCopy)
                    Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                        Dim FigData As clsAttrData.strFig_gazo_data = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                        FigList.Add(FigData)
                End Select
            Next
        End With
        setListView(0)
        Show_FigList_Property()
        Return Me.ShowDialog

    End Function
    Private Sub setListView(ByVal selectIndex As Integer)
        Dim ListData(FigList.Count) As String
        Dim Header() As String = {"種類", "データ", "表示レイヤ", "表示データ項目"}
        ListData(0) = Join(Header, vbTab)
        For i As Integer = 0 To FigList.Count - 1
            Dim data(3) As String
            Dim FigStac As Object = FigList(i)
            Select Case True
                Case TypeOf FigStac Is clsAttrData.strFig_Word_Data
                    Dim FigData As clsAttrData.strFig_Word_Data = DirectCast(FigStac, clsAttrData.strFig_Word_Data)
                    With FigData
                        data(0) = "文字"
                        data(1) = .Caption
                        dataWord(data, .Data.Layer, .Data.Data)
                    End With
                Case TypeOf FigStac Is clsAttrData.strFig_Line_Data
                    Dim FigData As clsAttrData.strFig_Line_Data = DirectCast(FigStac, clsAttrData.strFig_Line_Data)
                    With FigData
                        data(0) = "線"
                        Dim tx As String = .NumOfPoint.ToString() + "ポイント"
                        If .Points(0).Equals(.Points(.NumOfPoint - 1)) = True Then
                            tx += "|ループ"
                        End If
                        If .FillFlag = True Then
                            tx += "|塗りつぶし"
                        End If
                        data(1) = tx
                        dataWord(data, .Data.Layer, .Data.Data)
                    End With
                Case TypeOf FigStac Is clsAttrData.strFig_Rectangle_Data
                    Dim FigData As clsAttrData.strFig_Rectangle_Data = DirectCast(FigStac, clsAttrData.strFig_Rectangle_Data)
                    With FigData
                        data(0) = "四角形"
                        dataWord(data, .Data.Layer, .Data.Data)
                    End With
                Case TypeOf FigStac Is clsAttrData.strFig_Circle_data
                    Dim FigData As clsAttrData.strFig_Circle_data = DirectCast(FigStac, clsAttrData.strFig_Circle_data)
                    With FigData
                        data(0) = "円"
                        dataWord(data, .Data.Layer, .Data.Data)
                    End With
                Case TypeOf FigStac Is clsAttrData.strFig_Point_Data
                    Dim FigData As clsAttrData.strFig_Point_Data = DirectCast(FigStac, clsAttrData.strFig_Point_Data)
                    With FigData
                        data(0) = "点"
                        data(1) = .NumOfPoint.ToString() + "ポイント"
                        If .Caption_F = True Then
                            data(1) += "|" + .Caption
                        End If
                        dataWord(data, .Data.Layer, .Data.Data)

                    End With
                Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                    Dim FigData As clsAttrData.strFig_gazo_data = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                    With FigData
                        data(0) = "画像"
                        data(1) = "番号" + .PictureNumber.ToString
                        dataWord(data, .Data.Layer, .Data.Data)
                    End With
            End Select
            ListData(i + 1) = Join(data, vbTab)
        Next
        ListView.SetData(ListData, {VariantType.String, VariantType.String, VariantType.String, VariantType.String}, {False, False, False, False}, True)
        If FigList.Count = 0 Then
            gbItemData.Visible = False
        Else
            gbItemData.Visible = True
            ListView.Items(selectIndex).Selected = True
        End If
        ListView.Select()

    End Sub
    Private Sub dataWord(ByRef datastr() As String, ByVal LayerNum As Integer, ByVal DataNum As Integer)
        Dim l As Integer = LayerNum - 1
        Dim d As Integer = DataNum - 1
        If l = -1 Then
            datastr(2) = "全レイヤ"
            datastr(3) = "全データ"
        Else
            datastr(2) = attrData.LayerData(l).Name
            If d = -1 Then
                datastr(3) = "全データ"
            Else
                datastr(3) = attrData.Get_DataTitle(l, d, True)
            End If
        End If

    End Sub
    ''' <summary>
    ''' レイヤが変更されてデータ項目を変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayer.SelectedIndexChanged
        If Me.Tag <> "OFF" Then
            Dim LayerNum As Integer = cboLayer.SelectedIndex - 1
            Me.Tag = "OFF"
            If LayerNum = -1 Then
                cboData.Items.Clear()
                cboData.Items.Add("全データ")
            Else
                attrData.Set_DataTitle_to_cboBox(cboData, LayerNum, 0)
                cboData.Items.Insert(0, "全データ")
            End If
            cboData.SelectedIndex = 0
            ChangeLayerData()
            Me.Tag = ""
        End If
    End Sub
    Private Sub cboData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboData.SelectedIndexChanged
        If Me.Tag <> "OFF" Then
            ChangeLayerData()
        End If
    End Sub
    Private Sub ChangeLayerData()
        Dim Index As Integer = ListView.SelectedItems(0).Index
        Dim L As Integer = cboLayer.SelectedIndex
        Dim D As Integer = cboData.SelectedIndex
        Dim FigStac As Object = FigList(Index)
        Select Case True
            Case TypeOf FigStac Is clsAttrData.strFig_Word_Data
                Dim FigData As clsAttrData.strFig_Word_Data = DirectCast(FigStac, clsAttrData.strFig_Word_Data)
                FigData.Data.Layer = L
                FigData.Data.Data = D
                FigList(Index) = FigData
            Case TypeOf FigStac Is clsAttrData.strFig_Line_Data
                Dim FigData As clsAttrData.strFig_Line_Data = DirectCast(FigStac, clsAttrData.strFig_Line_Data)
                FigData.Data.Layer = L
                FigData.Data.Data = D
                FigList(Index) = FigData
            Case TypeOf FigStac Is clsAttrData.strFig_Rectangle_Data
                Dim FigData As clsAttrData.strFig_Rectangle_Data = DirectCast(FigStac, clsAttrData.strFig_Rectangle_Data)
                FigData.Data.Layer = L
                FigData.Data.Data = D
                FigList(Index) = FigData
            Case TypeOf FigStac Is clsAttrData.strFig_Circle_data
                Dim FigData As clsAttrData.strFig_Circle_data = DirectCast(FigStac, clsAttrData.strFig_Circle_data)
                FigData.Data.Layer = L
                FigData.Data.Data = D
                FigList(Index) = FigData
            Case TypeOf FigStac Is clsAttrData.strFig_Point_Data
                Dim FigData As clsAttrData.strFig_Point_Data = DirectCast(FigStac, clsAttrData.strFig_Point_Data)
                FigData.Data.Layer = L
                FigData.Data.Data = D
                FigList(Index) = FigData
            Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                Dim FigData As clsAttrData.strFig_gazo_data = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                FigData.Data.Layer = L
                FigData.Data.Data = D
                FigList(Index) = FigData
        End Select
        Dim DataS(3) As String
        dataWord(DataS, FigList(Index).Data.Layer, FigList(Index).Data.Data)
        ListView.Items(Index).SubItems(3).Text = DataS(2)
        ListView.Items(Index).SubItems(4).Text = DataS(3)
    End Sub
    ''' <summary>
    ''' 変更を取得。編集で終了した場合、戻り値に編集する項目番号が入り、そうでない場合は-1を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResults() As Integer
        attrData.TotalData.FigureStac.Clear()
        attrData.TotalData.FigureStac = FigList
        Return EditIndex
    End Function
    Private Sub ListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView.SelectedIndexChanged
        If ListView.SelectedItems.Count = 0 Then
            gbItemData.Visible = False
            Return
        End If
        gbItemData.Visible = True
        Show_FigList_Property()
    End Sub
    Private Sub Show_FigList_Property()
        Dim Index As Integer = ListView.SelectedItems(0).Index

        Me.Tag = "OFF"
        cboLayer.SelectedIndex = FigList(Index).Data.Layer
        cboData.Items.Clear()
        If FigList(Index).Data.Layer <> 0 Then
            attrData.Set_DataTitle_to_cboBox(cboData, FigList(Index).Data.Layer - 1, 0)
        End If
        cboData.Items.Insert(0, "全データ")
        cboData.SelectedIndex = FigList(Index).Data.Data
        Me.Tag = ""


    End Sub
    Private Sub ListView_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView.KeyDown
        Select Case e.KeyData
            Case Keys.Delete
                btnErase.PerformClick()
            Case Keys.Up
                btnPositionUp.PerformClick()
            Case Keys.Down
                btnPositionDown.PerformClick()
        End Select
        e.Handled = True
    End Sub

    Private Sub btnPositionUp_Click(sender As Object, e As EventArgs) Handles btnPositionUp.Click
        If ListView.SelectedItems.Count = 0 Or ListView.Items.Count = 1 Then
            Return
        End If
        Dim Index As Integer = ListView.SelectedItems(0).Index
        Dim swapIndex As Integer = Index - 1
        If swapIndex = -1 Then
            swapIndex = FigList.Count - 1
        End If
        Dim popData As Object = FigList(Index)
        FigList(Index) = FigList(swapIndex)
        FigList(swapIndex) = popData
        setListView(swapIndex)
    End Sub

    Private Sub btnPositionDown_Click(sender As Object, e As EventArgs) Handles btnPositionDown.Click
        If ListView.SelectedItems.Count = 0 Or ListView.Items.Count = 1 Then
            Return
        End If
        Dim Index As Integer = ListView.SelectedItems(0).Index
        Dim swapIndex As Integer = Index + 1
        If swapIndex = FigList.Count Then
            swapIndex = 0
        End If
        Dim popData As Object = FigList(Index)
        FigList(Index) = FigList(swapIndex)
        FigList(swapIndex) = popData
        setListView(swapIndex)
    End Sub
    Private Sub btnErase_Click(sender As Object, e As EventArgs) Handles btnErase.Click
        If ListView.SelectedItems.Count = 0 Then
            Return
        End If
        If MsgBox("選択した図形をクリアします。", MsgBoxStyle.YesNo, "MANDARA") = MsgBoxResult.Yes Then
            Dim Index As Integer = ListView.SelectedItems(0).Index
            FigList.RemoveAt(Index)
            ListView.Items.RemoveAt(Index)
            If ListView.Items.Count = 0 Then
                Return
            Else
                If Index = ListView.Items.Count Then
                    ListView.Items(Index - 1).Selected = True
                Else
                    ListView.Items(Index).Selected = True
                End If
            End If
            ListView.Select()
        End If
    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EditIndex = ListView.SelectedItems(0).Index
        btnOK.PerformClick()
    End Sub
    Private Sub frmPrint_FigureList_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "frmPrint_FigureList", Me)
    End Sub
End Class