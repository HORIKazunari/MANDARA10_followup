Public Class frmMain_Buffer
    Private Enum bufMode
        Distance = 0
        ObjectInPolygon = 1
        ParentObject = 2
    End Enum
    Private Enum registMode
        average = 0
        sum = 1
        standard = 2
        max = 3
        min = 4
    End Enum
    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData
    Dim LayerNum As Integer
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
        With cboRegistMethod
            .Items.Clear()
            .Items.Add("平均値")
            .Items.Add("合計")
            .Items.Add("標準偏差")
            .Items.Add("最大値")
            .Items.Add("最小値")
            .SelectedIndex = 0
        End With

        attrData = _attrData
        LayerNum = attrData.TotalData.LV1.SelectedLayer
        txtBuffer.Enabled = False

        rbBufModeDistance.Enabled = attrData.LayerData(LayerNum).MapFileData.Map.Detail.DistanceMeasurable
        txtBuffer.Enabled = rbBufModeDistance.Enabled
        If attrData.LayerData(LayerNum).Shape = enmShape.PolygonShape Then
            rbBufModeObjectInPolygon.Enabled = True
            rbBufModeObjectInPolygon.Checked = True
        Else
            rbBufModeObjectInPolygon.Enabled = False
            If rbBufModeDistance.Enabled = True Then
                rbBufModeDistance.Checked = True
            Else
                MsgBox("レイヤで使用する地図データに、距離の計測ができない設定がしてあります。", MsgBoxStyle.Exclamation)
                Return Windows.Forms.DialogResult.Cancel
            End If
        End If
        ProgressBar.Visible = False
        If attrData.TotalData.LV1.Lay_Maxn >= 2 Then
            lblHandledLayer.Visible = True
            cboHandledLayer.Visible = True
        Else
            lblHandledLayer.Visible = False
            cboHandledLayer.Visible = False
        End If
        attrData.Set_LayerName_to(cboHandledLayer, LayerNum)
        clsGeneric.SetScaleUnit_to_Cbobox(cboScaleUnit)
        cboScaleUnit.Text = clsGeneric.getScaleUnitStrings(enmScaleUnit.kilometer)
        Return Me.ShowDialog

    End Function
    Public Function GetResults()

    End Function

    Private Sub cboHandledLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboHandledLayer.SelectedIndexChanged

        Dim L As Integer = cboHandledLayer.SelectedIndex
        If attrData.LayerData(L).atrObject.NumOfSyntheticObj <> 0 Then
            'MsgBox("時系列集計されたレイヤは指定できません。", MsgBoxStyle.Exclamation)
            'Dim i As Integer = 0
            'Do While attrData.LayerData(i).atrObject.NumOfSyntheticObj <> 0
            '    i += 1
            'Loop
            'cboHandledLayer.SelectedIndex = i
            'Return
        End If
        setDataList()
    End Sub
    Private Sub setDataList()
        Dim L As Integer = cboHandledLayer.SelectedIndex
        If L = -1 Then
            Return
        End If
        Select Case True
            Case rbBufModeDistance.Checked, rbBufModeObjectInPolygon.Checked
                attrData.Set_DataTitle_to_ListBox(lbRegistData, L, True, True, True, False)
            Case rbBufModeParentObject.Checked
                attrData.Set_DataTitle_to_ListBox(lbRegistData, L, True, True, True, True)
        End Select
    End Sub
    Private Sub rbBufModeDistance_CheckedChanged(sender As Object, e As EventArgs) Handles rbBufModeDistance.CheckedChanged
        txtBuffer.Enabled = rbBufModeDistance.Enabled
        chkObjectData.Enabled = rbBufModeDistance.Enabled
        chkObjectCount.Enabled = rbBufModeDistance.Enabled
    End Sub

    Private Sub rbBufModeParentObject_CheckedChanged(sender As Object, e As EventArgs) Handles rbBufModeParentObject.CheckedChanged, rbBufModeDistance.CheckedChanged,
                            rbBufModeObjectInPolygon.CheckedChanged
        Select Case True

            Case rbBufModeDistance.Checked, rbBufModeObjectInPolygon.Checked
                chkObjectCount.Enabled = True
                chkObjNameOut.Enabled = True
                chkClipBoardOut.Enabled = True
                pnlCountMethod.Enabled = True
                txtBuffer.Enabled = True
                chkObjectData.Text = "含まれるオブジェクトの属性データ集計"
                lblObjectData.Text = "集計データ項目"
            Case rbBufModeParentObject.Checked
                chkObjectCount.Enabled = False
                chkObjNameOut.Enabled = False
                chkClipBoardOut.Enabled = True
                txtBuffer.Enabled = False
                pnlCountMethod.Enabled = False
                chkObjectData.Text = "検索対象レイヤのオブジェクトの属性データ取得"
                lblObjectData.Text = "取得データ項目"
        End Select
        setDataList()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If CheckError() = True Then
            CloseCancelF = True
            Return
        End If
        If Buffering() = False Then
            CloseCancelF = True
            Return
        End If
    End Sub
    Private Function CheckError() As Boolean


        Dim ef As Boolean = False
        Dim efm As String = ""

        Dim L2 As Integer = cboHandledLayer.SelectedIndex

        If rbBufModeDistance.Checked = True Or rbBufModeObjectInPolygon.Checked = True Then
            If chkObjNameOut.Checked = False And chkObjectCount.Checked = False And chkObjectData.Checked = False Then
                efm += "出力項目を指定してください。" & vbCrLf
                ef = True
            End If
        End If
        Dim Dis As Single = Val(txtBuffer.Text)
        If Dis <= 0 And rbBufModeDistance.Checked = True Then
            efm += "バッファ距離を指定してください。" & vbCrLf
            ef = True
        End If
        If chkObjectData.Checked = True Then
            If lbRegistData.SelectedIndices.Count = 0 Then
                efm += "集計データ項目が選択されていません。" & vbCrLf
                ef = True
            End If
        End If
        If rbBufModeParentObject.Checked = True And attrData.LayerData(L2).Shape <> enmShape.PolygonShape Then
            efm += "検索対象レイヤは面形状のものを指定してください。" & vbCrLf
            ef = True
        End If
        If ef = True Then
            MsgBox(efm, MsgBoxStyle.Exclamation)
        End If
        Return ef
    End Function
    Private Structure normal_data
        Public add As Double
        Public add2 As Double
        Public max As Double
        Public min As Double
    End Structure
    Private Structure category_data
        Public CateCount As Integer()
    End Structure
    Private Function Buffering() As Boolean


        Dim L1 As Integer = LayerNum
        Dim L2 As Integer = cboHandledLayer.SelectedIndex
        Dim ObjnL1 As Integer = attrData.Get_ObjectNum(L1)
        Dim ObjnL2 As Integer = attrData.Get_ObjectNum(L2)

        Dim BufferMode As bufMode
        Select Case True
            Case rbBufModeDistance.Checked
                BufferMode = bufMode.Distance
            Case rbBufModeObjectInPolygon.Checked
                BufferMode = bufMode.ObjectInPolygon
            Case rbBufModeParentObject.Checked
                BufferMode = bufMode.ParentObject
        End Select

        Dim Buf2_Obj_Str() As String
        If rbBufModeParentObject.Checked = True Then
            ReDim Buf2_Obj_Str(ObjnL1 - 1)
        End If

        Dim F_ObjectCount As Boolean
        Dim ObjCount_STR() As String
        Dim ObjName_STR() As String
        Dim ObjName_Clip_STR() As String
        If chkObjectCount.Checked = True And chkObjectCount.Enabled = True Then
            F_ObjectCount = True
            ReDim ObjCount_STR(ObjnL1 - 1)
        Else
            F_ObjectCount = False
        End If
        Dim F_objNameOut As Boolean
        If chkObjNameOut.Checked = True And chkObjNameOut.Enabled = True Then
            ReDim ObjName_STR(ObjnL1 - 1)
            F_objNameOut = True
        Else
            F_objNameOut = False
        End If
        Dim F_objNameClipOut As Boolean
        Dim sb As New System.Text.StringBuilder()
        If chkClipBoardOut.Checked = True And chkClipBoardOut.Enabled = True Then
            F_objNameClipOut = True
        Else
            F_objNameClipOut = False
        End If

        Dim Rdn As Integer
        Dim F_ObjectData As Boolean
        Dim RegistMode As registMode
        Dim AggData As List(Of Object)
        Dim Add() As Double
        Dim Add2() As Double
        Dim Inner_Object_Num() As Integer
        Dim Inner_Object_Name() As String
        Dim Shukei_V(,) As String
        Dim Add_Data() As Integer
        If chkObjectData.Checked = True Then
            RegistMode = cboRegistMethod.SelectedIndex
            F_ObjectData = True
            'Select Case True
            '    Case rbRegAverage.Checked
            '        RegistMode = frmMain_Buffer.registMode.average
            '    Case rbRegSum.Checked
            '        RegistMode = frmMain_Buffer.registMode.sum
            '    Case rbRegStd.Checked
            '        RegistMode = frmMain_Buffer.registMode.standard
            'End Select
            Rdn = lbRegistData.SelectedIndices.Count
            ReDim Add_Data(Rdn - 1)
            lbRegistData.SelectedIndices.CopyTo(Add_Data, 0)
            Dim PlusDataNum As Integer = 0
            For i As Integer = 0 To Rdn - 1
                If attrData.Get_DataType(L2, Add_Data(i)) = enmAttDataType.Category And (BufferMode = bufMode.Distance Or BufferMode = bufMode.ObjectInPolygon) Then
                    Dim pn As Integer = attrData.Get_DivNum(L2, Add_Data(i))
                    PlusDataNum += pn + 1
                Else
                    PlusDataNum += 1
                End If
            Next
            'ReDim Add(Rdn - 1)
            'ReDim Add2(Rdn - 1)
            ReDim Inner_Object_Num(Rdn - 1)
            ReDim Shukei_V(PlusDataNum - 1, ObjnL1 - 1)
        Else
            F_ObjectData = False
        End If


        '----main
        Me.Cursor = Cursors.WaitCursor
        ProgressBar.Maximum = ObjnL1
        Dim ClipOut As String = ""
        Dim bufUnit As mandara10.enmScaleUnit = clsGeneric.getScaleUnit_from_Strings(cboScaleUnit.Text)
        Dim ScaleRatio As Single = clsGeneric.Convert_ScaleUnit(enmScaleUnit.kilometer, bufUnit)
        Dim Dis As Single = Val(txtBuffer.Text)
        Dim chkConF As Boolean = chkConditionUse.Checked

        For i As Integer = 0 To ObjnL1 - 1  '現在のレイヤのオブジェクトの数
            If i Mod 2 = 0 Then
                ProgressBar.Value = i
            End If
            Dim BFN As Integer = 0
            Dim InObjNameList As New List(Of String)
            If F_ObjectData = True Then
                AggData = New List(Of Object)
                For k As Integer = 0 To Rdn - 1
                    If attrData.Get_DataType(L2, Add_Data(k)) = enmAttDataType.Category And (BufferMode = bufMode.Distance Or BufferMode = bufMode.ObjectInPolygon) Then
                        Dim cdata As category_data
                        Dim pn As Integer = attrData.Get_DivNum(L2, Add_Data(k))
                        ReDim cdata.CateCount(pn)
                        AggData.Add(cdata)
                    Else
                        Dim ndata As normal_data
                        ndata.add = 0
                        ndata.add2 = 0
                        ndata.max = attrData.LayerData(L2).atrData.Data(Add_Data(k)).Statistics.Min
                        ndata.min = attrData.LayerData(L2).atrData.Data(Add_Data(k)).Statistics.Max
                        AggData.Add(ndata)
                    End If
                    'Add(k) = 0
                    'Add2(k) = 0
                    Inner_Object_Num(k) = 0
                Next
            End If

            Dim CP As PointF
            If rbBufModeParentObject.Checked = True Then
                CP = attrData.Get_CenterP(L1, i)
            End If
            For j As Integer = 0 To ObjnL2 - 1 '検索対象レイヤのオブジェクトの数
                Dim concheck As Boolean = True
                If chkConF = True Then
                    concheck = attrData.Check_Condition(L2, j)
                End If
                If concheck = True Then
                    Dim f As Boolean
                    Select Case BufferMode
                        Case bufMode.Distance
                            'オブジェクト間の距離測定
                            Dim D As Single = attrData.Distance_Kencode_Object(i, j, L1, L2)
                            If D <= Dis / ScaleRatio Then
                                f = True
                            Else
                                f = False
                            End If
                        Case bufMode.ObjectInPolygon
                            'オブジェクトの内外判定
                            Dim OP As PointF = attrData.Get_CenterP(L2, j)
                            f = attrData.Check_Point_in_Kencode_OneObject(L1, i, OP)
                        Case bufMode.ParentObject
                            f = attrData.Check_Point_in_Kencode_OneObject(L2, j, CP)
                    End Select
                    If f = True Then
                        Select Case BufferMode
                            Case bufMode.Distance, bufMode.ObjectInPolygon
                                'バッファ距離を設定して内部のオブジェクトを探索する
                                '面領域内部のオブジェクトを探索する
                                BFN += 1
                                If F_objNameOut = True Then
                                    InObjNameList.Add(attrData.Get_KenObjName(L2, j))
                                End If
                                If F_ObjectData = True Then
                                    'データの集計
                                    For k As Integer = 0 To Rdn - 1
                                        If attrData.Get_DataType(L2, Add_Data(k)) = enmAttDataType.Category Then
                                            Dim ct As Integer = attrData.Get_Categoly(L2, Add_Data(k), j)
                                            Dim cdata As category_data = DirectCast(AggData(k), category_data)
                                            If ct <> -1 Then
                                                cdata.CateCount(ct) += 1
                                            Else
                                                cdata.CateCount(cdata.CateCount.Length - 1) += 1
                                            End If
                                        Else
                                            If attrData.Check_Missing_Value(L2, Add_Data(k), j) = False Then
                                                Dim V As Double = Val(attrData.Get_Data_Value(L2, Add_Data(k), j, ""))
                                                Dim nd As normal_data = DirectCast(AggData(k), normal_data)
                                                nd.add += V
                                                nd.add2 += V ^ 2
                                                If nd.max < V Then nd.max = V
                                                If V < nd.min Then nd.min = V
                                                AggData(k) = nd
                                                Inner_Object_Num(k) += 1
                                            End If
                                        End If
                                    Next
                                End If
                            Case bufMode.ParentObject
                                '元レイヤのオブジェクトを含むオブジェクトを検索する
                                Buf2_Obj_Str(i) = attrData.Get_KenObjName(L2, j)
                                If F_ObjectData = True Then
                                    'データの集計
                                    For k As Integer = 0 To Rdn - 1
                                        Shukei_V(k, i) = attrData.Get_Data_Value(L2, Add_Data(k), j, "")
                                    Next
                                End If
                                Exit For
                        End Select
                    End If
                End If
            Next
            If F_objNameOut = True Then
                ObjName_STR(i) = String.Join("/", InObjNameList.ToArray)
            End If
            If F_objNameClipOut = True Then
                sb.Append(attrData.Get_KenObjName(L1, i) & vbTab & BFN.ToString & vbTab & String.Join(vbTab, InObjNameList.ToArray) + vbCrLf)
            End If
            If F_ObjectCount = True Then
                ObjCount_STR(i) = CStr(BFN)
            End If

            If F_ObjectData = True And (BufferMode = bufMode.Distance Or BufferMode = bufMode.ObjectInPolygon) Then
                '含まれるオブジェクトの属性データ集計
                Dim n As Integer = 0
                For k As Integer = 0 To Rdn - 1
                    If attrData.Get_DataType(L2, Add_Data(k)) = enmAttDataType.Category Then
                        Dim cdata As category_data = DirectCast(AggData(k), category_data)
                        For k2 As Integer = 0 To cdata.CateCount.Length - 1
                            Shukei_V(n, i) = CStr(cdata.CateCount(k2))
                            n += 1
                        Next
                    Else
                        If Inner_Object_Num(k) = 0 Then
                            '含まれるオブジェクトがない場合は欠損値
                            Shukei_V(n, i) = ""
                        Else
                            Dim nd As normal_data = DirectCast(AggData(k), normal_data)
                            Dim V As Double
                            Select Case RegistMode
                                Case frmMain_Buffer.registMode.average
                                    V = nd.add / Inner_Object_Num(k)
                                Case frmMain_Buffer.registMode.sum
                                    V = nd.add
                                Case frmMain_Buffer.registMode.standard
                                    V = Math.Sqrt(nd.add2 / Inner_Object_Num(k) - (nd.add / Inner_Object_Num(k)) ^ 2)
                                Case frmMain_Buffer.registMode.max
                                    V = nd.max
                                Case frmMain_Buffer.registMode.min
                                    V = nd.min
                            End Select
                            Shukei_V(n, i) = CStr(V)
                        End If
                        n += 1
                    End If
                Next
            End If
        Next


        ProgressBar.Visible = False
        Me.Cursor = Cursors.Default
        '-----

        Dim Note As String = "空間検索機能で作成"
        If chkConF = True And attrData.Check_Condition_UMU(L2) = True Then
            Note += vbCrLf + attrData.Get_Condition_Info(L2)
        End If

        If BufferMode = bufMode.ParentObject Then
            Dim TTL As String
            Dim UNT As String
            TTL = attrData.LayerData(L2).Name & "レイヤに含まれているオブジェクト"
            UNT = "CAT"
            attrData.Add_One_Data_Value(L1, TTL, UNT, Note, Buf2_Obj_Str, True)
        Else
            Dim TTL As String
            Dim UNT As String
            Dim form As New frmTitleSettingsAddingData
            If F_ObjectCount = True Then
                If BufferMode = bufMode.Distance Then
                    TTL = "バッファ" & CStr(Dis) & cboScaleUnit.Text & "に含まれるオブジェクト数"
                Else
                    TTL = attrData.LayerData(L2).Name & "のオブジェクト数"
                End If
                UNT = ""
                If form.ShowDialog(TTL, UNT, Note, False, "含まれるオブジェクト数のカウント") = Windows.Forms.DialogResult.OK Then
                    form.getResult(TTL, UNT, Note)
                    attrData.Add_One_Data_Value(L1, TTL, "", Note, ObjCount_STR, False)
                End If
            End If
            If F_objNameOut = True Then
                If BufferMode = bufMode.Distance Then
                    TTL = "バッファ" & CStr(Dis) & cboScaleUnit.Text & "に含まれるオブジェクト名"
                Else
                    TTL = "含まれる" & attrData.LayerData(L2).Name & "のオブジェクト名"
                End If
                UNT = "STR"
                If form.ShowDialog(TTL, UNT, Note, False, "含まれるオブジェクト名") = Windows.Forms.DialogResult.OK Then
                    form.getResult(TTL, UNT, Note)
                    attrData.Add_One_Data_Value(L1, TTL, UNT, Note, ObjName_STR, False)
                End If
            End If
        End If

        If F_ObjectData = True Then
            Dim TTL As String
            Dim UNT As String
            Dim n As Integer
            For i As Integer = 0 To Rdn - 1
                Dim k As Integer = Add_Data(i)
                TTL = attrData.LayerData(L2).Name & "：" & attrData.Get_DataTitle(L2, k, False)
                UNT = attrData.Get_DataUnit(L2, k)
                If BufferMode = bufMode.Distance Then
                    TTL += ":バッファ" & CStr(Dis) & cboScaleUnit.Text
                End If
                If BufferMode = bufMode.Distance Or BufferMode = bufMode.ObjectInPolygon Then
                    If attrData.Get_DataType(L2, k) = enmAttDataType.Category Then
                        Dim PData As clsAttrData.strData_info = attrData.LayerData(L2).atrData.Data(k)
                        Dim Class_div() As clsAttrData.strClass_Div_data = PData.SoloModeViewSettings.Class_Div
                        Dim ctn = attrData.Get_DivNum(L2, k)
                        If attrData.Get_DataMissingNum(L2, k) <> 0 Then
                            ctn += 1
                        End If
                        For j As Integer = 0 To ctn - 1
                            Dim fu As String
                            If attrData.Get_DataMissingNum(L2, k) <> 0 And j = ctn - 1 Then
                                fu = "欠損値"
                            Else
                                fu = Class_div(j).Cat_Name
                            End If
                            Dim TTL2 = TTL + "：" + fu
                            Dim Data_Val_STR(ObjnL1 - 1) As String
                            For k2 As Integer = 0 To ObjnL1 - 1
                                Data_Val_STR(k2) = Shukei_V(n + j, k2)
                            Next
                            attrData.Add_One_Data_Value(L1, TTL2, "", Note, Data_Val_STR, True)
                        Next
                        n += attrData.Get_DivNum(L2, k) + 1
                    Else
                        TTL += "：" + cboRegistMethod.Text
                        'Select Case RegistMode
                        '    Case 0
                        '        TTL += "：平均値"
                        '    Case 1
                        '        TTL += "：合計値"
                        '    Case 2
                        '        TTL += "：標準偏差"
                        '        UNT = ""
                        'End Select
                        Dim Data_Val_STR(ObjnL1 - 1) As String
                        For j As Integer = 0 To ObjnL1 - 1
                            Data_Val_STR(j) = Shukei_V(n, j)
                        Next
                        attrData.Add_One_Data_Value(L1, TTL, UNT, Note, Data_Val_STR, True)
                        If RegistMode = frmMain_Buffer.registMode.average Then
                            attrData.Set_Legend(L1, attrData.LayerData(L1).atrData.Count - 1, attrData.LayerData(L2).atrData.Data(k), True, True, True, True, True, True, True, True, True, True, True, False, True)
                        End If
                        n += 1
                    End If
                Else
                    Dim Data_Val_STR(ObjnL1 - 1) As String
                    For j As Integer = 0 To ObjnL1 - 1
                        Data_Val_STR(j) = Shukei_V(i, j)
                    Next
                    attrData.Add_One_Data_Value(L1, TTL, UNT, Note, Data_Val_STR, True)
                    attrData.Set_Legend(L1, attrData.LayerData(L1).atrData.Count - 1, attrData.LayerData(L2).atrData.Data(k), True, True, True, True, True, True, True, True, True, True, True, False, True)
                End If
            Next
        End If

        If F_objNameClipOut = True Then
            Clipboard.SetText(sb.ToString)
        End If


        Return True
    End Function


    Private Sub lbRegistData_Click(sender As Object, e As EventArgs) Handles lbRegistData.Click
        chkObjectData.Checked = True
    End Sub

    Private Sub frmMain_Buffer_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_Buffer", Me)
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub


End Class