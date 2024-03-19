Public Class frmMain_LayerObjectCombine
    Private Structure newDataInfo
        Public oldLay As Integer
        Public oldDataNum As Integer
    End Structure
    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData
    Dim Enable_Layer() As Boolean
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
        Dim layn As Integer = attrData.TotalData.LV1.Lay_Maxn
        ReDim Enable_Layer(layn - 1)
        clbLayer.Items.Clear()
        For i As Integer = 0 To layn - 1
            With attrData.LayerData(i)
                Dim tx As String = attrData.LayerData(i).Name
                If attrData.LayerData(i).Time.nullFlag = False Then
                    tx += "【" & clsTime.YMDtoString(.Time) & "】"
                End If
                If .atrObject.NumOfSyntheticObj > 0 Or .Type = clsAttrData.enmLayerType.Trip Or .Type = clsAttrData.enmLayerType.Trip_Definition Then
                    tx = "*" & tx
                    Enable_Layer(i) = False
                Else
                    Enable_Layer(i) = True
                End If
                clbLayer.Items.Add(tx)
            End With
        Next
        txtNewLayerName.Text = attrData.Get_NewLayer_Name()

        Return Me.ShowDialog

    End Function
    Public Function GetResults()

    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim n As Integer = clbLayer.CheckedIndices.Count
        If n = 0 Or n = 1 Then
            MsgBox("複数のレイヤを選択して下さい。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
        Dim etype As Integer = -1
        Dim MapFile As String
        Dim LayType As clsAttrData.enmLayerType
        For i As Integer = 0 To n - 2
            Dim j As Integer = clbLayer.CheckedIndices(i) + 1
            With attrData.LayerData(clbLayer.CheckedIndices(i))
                If .Time.Equals(attrData.LayerData(j).Time) = False Then
                    etype = 1
                    Exit For
                End If
                If .Shape <> attrData.LayerData(j).Shape Then
                    etype = 2
                    Exit For
                End If
                If .Type <> attrData.LayerData(j).Type Then
                    etype = 3
                    Exit For
                End If
                If .MapFileName <> attrData.LayerData(j).MapFileName Then
                    etype = 4
                    Exit For
                End If
                If .Type = clsAttrData.enmLayerType.Mesh Or .Type = clsAttrData.enmLayerType.DefPoint Then
                    If .ReferenceSystem <> attrData.LayerData(j).ReferenceSystem Then
                        etype = 5
                        Exit For
                    End If
                End If
                MapFile = .MapFileName
                LayType = .Type
            End With
        Next
        Select Case etype
            Case 1
                MsgBox("時期の違うレイヤが含まれています。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Return
            Case 2
                MsgBox("形状の違うレイヤが含まれています。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Return
            Case 3
                MsgBox("種類の違うレイヤが含まれています。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Return
            Case 4
                MsgBox("異なる地図ファイルを使用するレイヤが含まれています。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Return
            Case 5
                MsgBox("異なる測地系を使用する地点定義レイヤまたはメッシュレイヤが含まれています。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Return
        End Select

        Dim Get_Layer_n As Integer = n

        Dim New_Lay_ObjN As Integer
        Dim V As Double

        Dim New_Lay_DatN As Integer = 0
        Dim objMax As Integer = attrData.SetMapFile(MapFile).Map.Kend
        Dim Check_Ken_Num As New Dictionary(Of String, Integer)
        For i As Integer = 0 To Get_Layer_n - 1
            Dim Layernum As Integer = clbLayer.CheckedIndices(i)
            For j As Integer = 0 To attrData.Get_ObjectNum(Layernum) - 1
                Dim key As String
                Select Case LayType
                    Case clsAttrData.enmLayerType.Normal
                        key = attrData.Get_KenObjCode(Layernum, j).ToString
                    Case clsAttrData.enmLayerType.DefPoint, clsAttrData.enmLayerType.Mesh
                        key = attrData.Get_KenObjName(Layernum, j)
                End Select
                If Check_Ken_Num.ContainsKey(key) = False Then
                    Check_Ken_Num.Add(key, 1)
                Else
                    Dim keyv As Integer = Check_Ken_Num(key) + 1
                    Check_Ken_Num(key) = keyv
                End If
            Next
            New_Lay_DatN += attrData.Get_DataNum(Layernum)
        Next
        'オブジェクトの数を数える
        Dim Check_Ken_OK As New Dictionary(Of String, Boolean)
        Dim Get_Object_Mode As Integer
        If rbRemove.Checked = True Then
            Get_Object_Mode = 0
        Else
            Get_Object_Mode = 1
        End If
        Dim New_Lay_Object_N As Integer = 0
        For Each kp As KeyValuePair(Of String, Integer) In Check_Ken_Num
            If Get_Object_Mode = 1 Or (Get_Object_Mode = 0 And kp.Value = Get_Layer_n) Then
                If Check_Ken_OK.ContainsKey(kp.Key) = False Then
                    Check_Ken_OK.Add(kp.Key, True)
                End If
                New_Lay_Object_N += 1
            End If
        Next
        If New_Lay_Object_N = 0 Then
            MsgBox("新しいレイヤにはオブジェクトが作成されません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        '新しいレイヤの設定準備
        Dim NewLay As Integer = attrData.TotalData.LV1.Lay_Maxn
        Dim B_Lay As Integer = clbLayer.CheckedIndices(0)



        '取得するデータ項目

        Dim newDataItem(New_Lay_DatN - 1) As newDataInfo
        Dim Data_Val_STR(New_Lay_DatN - 1, New_Lay_Object_N - 1) As String
        Dim get_obj(New_Lay_Object_N - 1) As clsAttrData.strObject_Data_Info
        '集計するデータ項目のタイトル設定
        Dim datan As Integer = 0
        For i As Integer = 0 To Get_Layer_n - 1
            Dim Layernum As Integer = clbLayer.CheckedIndices(i)
            With attrData
                For j As Integer = 0 To .Get_DataNum(Layernum) - 1
                    newDataItem(datan).oldLay = Layernum
                    newDataItem(datan).oldDataNum = j
                    datan += 1
                Next
            End With
        Next


        'データ取得

        Dim Exsistent_MeshObject As clsSortingSearch
        New_Lay_ObjN = 0
        Dim D As Integer = 0
        For i As Integer = 0 To Get_Layer_n - 1
            Dim Layernum As Integer = clbLayer.CheckedIndices(i)
            If i <> 0 Then
                Exsistent_MeshObject = New clsSortingSearch(VariantType.String)
                For j As Integer = 0 To New_Lay_ObjN - 1
                    Select Case LayType
                        Case clsAttrData.enmLayerType.Normal
                            Exsistent_MeshObject.Add(get_obj(j).MpObjCode.ToString)
                        Case clsAttrData.enmLayerType.Mesh, clsAttrData.enmLayerType.DefPoint
                            Exsistent_MeshObject.Add(get_obj(j).Name)
                    End Select
                Next
                Exsistent_MeshObject.AddEnd()
            End If
            For j As Integer = 0 To attrData.Get_ObjectNum(Layernum) - 1
                Dim key As String
                Select Case LayType
                    Case clsAttrData.enmLayerType.Normal
                        key = attrData.Get_KenObjCode(Layernum, j).ToString
                    Case clsAttrData.enmLayerType.DefPoint, clsAttrData.enmLayerType.Mesh
                        key = attrData.Get_KenObjName(Layernum, j)
                End Select

                If Check_Ken_OK.ContainsKey(key) = True Then
                    Dim O_Number As Integer
                    If i = 0 Then
                        O_Number = -1
                    Else
                        '同じオブジェクトが既に使用されているかをチェック
                        O_Number = Exsistent_MeshObject.SearchData_One(key)
                    End If
                    If O_Number = -1 Then
                        '新規レイヤのオブジェクトを増やす
                        O_Number = New_Lay_ObjN
                        With attrData.LayerData(Layernum).atrObject.atrObjectData(j)
                            get_obj(O_Number).CenterPoint = .CenterPoint
                            get_obj(O_Number).HyperLink = .HyperLink.Clone
                            get_obj(O_Number).HyperLinkNum = .HyperLinkNum
                            get_obj(O_Number).Label = .Label
                            get_obj(O_Number).MeshPoint = .MeshPoint
                            get_obj(O_Number).MeshRect = .MeshRect
                            get_obj(O_Number).MpObjCode = .MpObjCode
                            get_obj(O_Number).Name = .Name
                            get_obj(O_Number).Objectstructure = .Objectstructure
                            get_obj(O_Number).Symbol = .Symbol
                        End With
                        New_Lay_ObjN += 1
                    End If
                    For k As Integer = 0 To attrData.Get_DataNum(Layernum) - 1
                        Data_Val_STR(D + k, O_Number) = attrData.Get_Data_Value(Layernum, k, j, "")
                    Next
                End If
            Next
            D += attrData.Get_DataNum(Layernum)
            If i <> 0 Then
                Exsistent_MeshObject = Nothing
            End If

        Next
        With attrData.LayerData(B_Lay)
            attrData.Add_one_Layer(txtNewLayerName.Text, .Type, .MeshType, .Shape, .MapFileName, .Time, .ReferenceSystem, "レイヤ間オブジェクト集計機能で作成", New_Lay_Object_N, get_obj)
        End With
        For i As Integer = 0 To Get_Layer_n - 1
            Dim Layernum As Integer = clbLayer.CheckedIndices(i)
            For j As Integer = 0 To attrData.LayerData(Layernum).Dummy.Count - 1
                With attrData.LayerData(Layernum).Dummy.DummyObj(j)
                    attrData.LayerData(NewLay).Dummy.AddDummy(.code, .Name)
                End With
            Next
            For j As Integer = 0 To attrData.LayerData(Layernum).DummyGroup.Count - 1
                attrData.LayerData(NewLay).DummyGroup.AddDummyObjG(attrData.LayerData(Layernum).DummyGroup.DummyObjG(j))
            Next
        Next
        For i As Integer = 0 To New_Lay_DatN - 1
            Dim Data_Val_STR2(New_Lay_Object_N - 1) As String
            For j As Integer = 0 To New_Lay_Object_N - 1
                Data_Val_STR2(j) = Data_Val_STR(i, j)
            Next

            With newDataItem(i)
                Dim TTL As String = attrData.Get_DataTitle(.oldLay, .oldDataNum, False) & "【" & attrData.LayerData(.oldLay).Name & "】"
                Dim UNT As String = attrData.Get_DataUnit(.oldLay, .oldDataNum)
                Dim Note As String = attrData.Get_DataNote(.oldLay, .oldDataNum)
                attrData.Add_One_Data_Value(NewLay, TTL, UNT, Note, Data_Val_STR2, True)
                attrData.Set_Legend(NewLay, attrData.LayerData(NewLay).atrData.Count - 1, attrData.LayerData(.oldLay).atrData.Data(.oldDataNum), True, True, True, True, True, True, True, True, True, True, True, False, True)
            End With
        Next

        '新しいレイヤの設定準備


        attrData.LinePatternCheck()
        attrData.PrtObjectSpatialIndex()

        Me.Cursor = Cursors.Default
        MsgBox("集計が終了しました。結果は" & txtNewLayerName.Text & "に入っています。")

    End Sub

    Private Sub frmMain_LayerObjectCombine_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_LayerObjectCombine", Me)
    End Sub
End Class