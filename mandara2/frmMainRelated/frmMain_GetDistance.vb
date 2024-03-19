Public Class frmMain_GetDistance

    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData
    Dim LayerNum As Integer
    Private Enum DisType
        Point = 0
        LayerObject = 1
        LayerDummy = 2
        MapObject = 3
    End Enum

    Private Structure pos_info
        Public xy As PointF
        Public type As DisType
        Public lay As Integer
        Public objpos As Integer
        Public MapFile As String
        Public Time As strYMD
    End Structure
    Dim pos As New List(Of pos_info)
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
        attrData = _attrData
        LayerNum = attrData.TotalData.LV1.SelectedLayer
        If attrData.TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
            btnLatLon.Enabled = True
        Else
            btnLatLon.Enabled = False
        End If
        clsGeneric.SetScaleUnit_to_Cbobox(cboScaleUnit)
        cboScaleUnit.Text = clsGeneric.getScaleUnitStrings(enmScaleUnit.kilometer)
        ProgressBar.Visible = False
        Return Me.ShowDialog

    End Function
    Public Function GetResults()

    End Function

    Private Sub btnLayerObject_Click(sender As Object, e As EventArgs) Handles btnLayerObject.Click
        Dim form As New frmMain_LayeObjectSelect
        If form.ShowDialog(attrData, SelectionMode.MultiExtended, True, LayerNum, Nothing, False) = Windows.Forms.DialogResult.OK Then
            Dim sel() As Integer
            Dim Lay As Integer
            Dim DummyF As Boolean
            form.getResult(Lay, sel, DummyF)
            For i As Integer = 0 To sel.Length - 1
                Dim tx As String = ""
                If Lay <> LayerNum Then
                    tx = attrData.LayerData(Lay).Name + ":"
                End If
                If DummyF = False Then
                    tx += attrData.Get_KenObjName(Lay, sel(i))
                    Dim posd As pos_info
                    posd.type = DisType.LayerObject
                    posd.lay = Lay
                    posd.objpos = sel(i)
                    pos.Add(posd)
                Else
                    With attrData.LayerData(Lay).Dummy.DummyObj(sel(i))
                        tx += .Name
                        Dim posd As pos_info
                        posd.type = DisType.LayerDummy
                        posd.lay = Lay
                        posd.objpos = .code
                        pos.Add(posd)
                    End With
                End If
                lbList.Items.Add(tx)
            Next
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim n As Integer = lbList.SelectedIndices.Count
        If n = 0 Then
            MsgBox("削除対象を選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If
        For i As Integer = lbList.Items.Count - 1 To 0 Step -1
            If lbList.GetSelected(i) = True Then
                lbList.Items.RemoveAt(i)
                pos.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub btnLatLon_Click(sender As Object, e As EventArgs) Handles btnLatLon.Click
        Dim latlon As strLatLon
        If clsGeneric.Get_LatLon(latlon, clsSettings.Data.Ido_Kedo_Print_Pattern, True) = True Then
            Dim s As strPointStrings = clsGeneric.Get_LatLon_Strings(latlon, True)
            lbList.Items.Add(s.x + "/" + s.y)
            Dim posd As pos_info
            posd.xy = latlon.toPointF
            posd.type = DisType.Point
            pos.Add(posd)
        End If


    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim n As Integer = lbList.Items.Count
        If n = 0 Then
            MsgBox("距離の取得元がありません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim objn As Integer = attrData.LayerData(LayerNum).atrObject.ObjectNum
        ProgressBar.Visible = True
        ProgressBar.Maximum = n * objn
        Dim ProgN As Integer = 0
        Dim dis(n - 1, objn - 1) As Single
        Dim allD As Single
 

        For i As Integer = 0 To n - 1
            For j As Integer = 0 To objn - 1
                Dim d As Single
                Select Case pos(i).type
                    Case DisType.Point
                        Dim P As PointF = spatial.Get_Converted_XY(pos(i).xy, attrData.TotalData.ViewStyle.Zahyo)
                        d = attrData.Distance_Kencode_Point(LayerNum, j, P)
                    Case DisType.LayerObject
                        d = attrData.Distance_Kencode_Object(j, pos(i).objpos, LayerNum, pos(i).lay)
                    Case DisType.LayerDummy
                        With attrData.LayerData(LayerNum)
                            If .Type = clsAttrData.enmLayerType.DefPoint Or .Type = clsAttrData.enmLayerType.Mesh Then
                                d = .MapFileData.Distance_Object(.atrObject.atrObjectData(j).CenterPoint, pos(i).objpos, .Time)
                            Else
                                d = .MapFileData.Distance_Object(attrData.Get_KenObjCode(LayerNum, j), pos(i).objpos, .Time, .Time)
                            End If
                        End With
                    Case DisType.MapObject
                        d = attrData.Distance_Kencode_MPObject(LayerNum, j, pos(i).MapFile, pos(i).objpos, pos(i).Time)
                End Select
                dis(i, j) = d
                allD += dis(i, j)
                If ProgN Mod 50 = 0 Then
                    ProgressBar.Value = ProgN
                End If
                ProgN += 1
            Next
        Next

        ProgressBar.Visible = False
        Me.Cursor = Cursors.Default
        Dim Unit As mandara10.enmScaleUnit = clsGeneric.getScaleUnit_from_Strings(cboScaleUnit.Text)
        Dim ScaleRatio As Single = clsGeneric.Convert_ScaleUnit(enmScaleUnit.kilometer, Unit)
        Select Case True
            Case rbNearestDistance.Checked
                '最小距離取得
                Dim form As New frmTitleSettingsAddingData
                Dim tx As String = "最も近い距離"
                Dim unt As String = clsGeneric.getScaleUnitStrings(Unit)
                Dim Note As String = "距離測定機能で作成"
                If form.ShowDialog(tx, unt, Note, False, "最も近い地点との距離のデータ項目名") = Windows.Forms.DialogResult.OK Then
                    form.getResult(tx, unt, Note)
                    Dim Min_Dis(objn - 1) As Single
                    Dim Min_Dis_ObjName(objn - 1) As String
                    For i As Integer = 0 To objn - 1
                        Min_Dis(i) = allD
                        Min_Dis_ObjName(i) = ""
                        For j As Integer = 0 To n - 1
                            If LayerNum = pos(j).lay And i = pos(j).objpos And pos(j).type = DisType.LayerObject Then
                            Else
                                '同一オブジェクトでなければ
                                If Min_Dis(i) > dis(j, i) Then
                                    Min_Dis(i) = dis(j, i)
                                    Min_Dis_ObjName(i) = lbList.Items(j)
                                ElseIf Min_Dis(i) = dis(j, i) Then
                                    Min_Dis_ObjName(i) += "/" & lbList.Items(j)
                                End If
                            End If
                        Next
                    Next

                    Dim Data_Val_STR(objn - 1) As String
                    For i As Integer = 0 To objn - 1
                        Data_Val_STR(i) = Min_Dis_ObjName(i)
                    Next
                    attrData.Add_One_Data_Value(LayerNum, "最も近い地点／オブジェクト", "CAT", "距離測定機能で作成", Data_Val_STR, False)
                    For i As Integer = 0 To objn - 1
                        Data_Val_STR(i) = CStr(Min_Dis(i) * ScaleRatio)
                    Next
                    attrData.Add_One_Data_Value(LayerNum, tx, unt, Note, Data_Val_STR, False)
                    form.Dispose()
                End If

            Case rbEveryDistance.Checked
                '全ての距離取得

                Dim Data_Val_STR(objn - 1) As String
                For j As Integer = 0 To n - 1
                    For i As Integer = 0 To objn - 1
                        Data_Val_STR(i) = CStr(dis(j, i) * ScaleRatio)
                    Next
                    attrData.Add_One_Data_Value(LayerNum, lbList.Items(j) & "との距離", clsGeneric.getScaleUnitStrings(Unit), "距離測定機能で作成", Data_Val_STR, False)
                Next
        End Select
    End Sub

    Private Sub btnObject_Click(sender As Object, e As EventArgs) Handles btnObject.Click
        Dim form As New frmMain_SelMapObject
        If form.ShowDialog(attrData, SelectionMode.MultiExtended) = Windows.Forms.DialogResult.OK Then
            Dim SelObj() As Integer
            Dim Time As strYMD
            Dim MapFIle As String
            form.GetResults(MapFIle, SelObj, Time)
            For i As Integer = 0 To SelObj.Length - 1
                Dim posd As pos_info
                posd.type = DisType.MapObject
                posd.MapFile = MapFIle
                posd.Time = Time
                posd.objpos = SelObj(i)
                pos.Add(posd)
                Dim oname As String = ""
                attrData.SetMapFile(MapFIle).Get_Enable_ObjectName(SelObj(i), Time, False, oname)
                lbList.Items.Add(oname)
            Next
        End If
        form.Dispose()
    End Sub

    Private Sub frmMain_GetDistance_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_GetDistance", Me)

    End Sub
End Class