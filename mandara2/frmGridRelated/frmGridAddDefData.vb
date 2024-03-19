Public Class frmGridAddDefData
    Dim CloseCancelF As Boolean
    Dim attr As clsAttrData
    Dim ktGrid As KTGISUserControl.KTGISGrid
    Dim GridLayerData As frmGrid.GridLayerData_Info
    Dim PresentLayerObjGroup As List(Of Integer)
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
    Public Overloads Function ShowDialog(ByRef _attr As clsAttrData, ByRef _Grid As KTGISUserControl.KTGISGrid, ByVal _GridLayerData As frmGrid.GridLayerData_Info) As Windows.Forms.DialogResult
        ktGrid = _Grid
        attr = _attr
        GridLayerData = _GridLayerData
        Dim pLayer As Integer = ktGrid.Layer
        Dim FXS(,) As String = ktGrid.FixedXSData(pLayer)
        Dim ys As Integer = FXS.GetLength(1)
        Dim LayerNum As Integer = ktGrid.Layer
        Dim LayerType As clsAttrData.enmLayerType = CType(ktGrid.LayerData(LayerNum, GridLayerData.Type), clsAttrData.enmLayerType)
        Dim mpFileName As String = ktGrid.LayerData(LayerNum, GridLayerData.MapFile).ToString
        Dim mpFile As clsMapData = attr.SetMapFile(mpFileName)
        lbPresentLayer.Text = ktGrid.LayerName(LayerNum)


        '現在のレイヤに追加
        If LayerType = clsAttrData.enmLayerType.Normal Then
            Dim L_Time As strYMD
            If mpFile.Map.Time_Mode = False Then
                L_Time = clsTime.GetNullYMD
            Else
                L_Time = CType(ktGrid.LayerData(LayerNum, GridLayerData.Time), strYMD)
            End If


            Dim Okind(ys - 1) As Integer
            For i As Integer = 0 To ys - 1
                Okind(i) = -1
                Dim oname As String = FXS(1, i)
                If oname Is Nothing = False Then
                    If oname <> "" Then
                        Dim code As Integer = attr.Get_ObjectCode_from_ObjName(mpFileName, oname, L_Time)
                        If code <> -1 Then
                            Okind(i) = mpFile.MPObj(code).Kind
                        End If
                    End If
                End If
            Next
            Dim valgroup() As Integer = clsGeneric.Get_EachValueArray(Okind)
            PresentLayerObjGroup = New List(Of Integer)
            cboPLayObjectGroup.Items.Clear()
            For i As Integer = 0 To valgroup.Length - 1
                If valgroup(i) <> -1 Then
                    PresentLayerObjGroup.Add(valgroup(i))
                    cboPLayObjectGroup.Items.Add(mpFile.ObjectKind(valgroup(i)).Name)
                End If
            Next
            If PresentLayerObjGroup.Count <> 0 Then
                cboPLayObjectGroup.SelectedIndex = 0
            Else
                gbAddPresentLayer.Enabled = False
                rbAddPresentLayer.Enabled = False
            End If
        Else
            gbAddPresentLayer.Enabled = False
            rbAddPresentLayer.Enabled = False
        End If
        rbAddNewLayer.Checked = True

        '新しいレイヤに追加
        Dim Lname(ktGrid.LayerMax - 1) As String
        For i As Integer = 0 To ktGrid.LayerMax - 1
            Lname(i) = ktGrid.LayerName(i)
        Next
        txtNewLayerName.Text = clsGeneric.Get_New_Numbering_Strings("新しいレイヤ", Lname)

        cboNewLayerMapFile.Items.Clear()
        cboNewLayerMapFile.Items.AddRange(attr.GetMapFileName())
        cboNewLayerMapFile.SelectedIndex = 0

        Return Me.ShowDialog

    End Function
    ''' <summary>
    ''' 戻り値がtrueの場合現在のレイヤに追加、falseの場合新しいレイヤに追加
    ''' </summary>
    ''' <param name="FYDataValue">ヘッダのデータ</param>
    ''' <param name="DataValue">データの中身</param>
    ''' <param name="MapFile">新しいレイヤに追加の場合のレイヤの地図ファイルparam>
    ''' <param name="LayName">新しいレイヤに追加の場合のレイヤの名前</param>
    ''' <param name="LayTime">新しいレイヤに追加の場合のレイヤの時間</param>
    ''' <param name="shp">新しいレイヤに追加の場合のオブジェクト形状</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResults(ByRef FYDataValue(,) As String, ByRef DataValue(,) As String, ByRef LayMapFile As String,
                               ByRef LayName As String, ByRef LayTime As strYMD, ByRef shp As enmShape) As Boolean
        Dim fydataV(,) As String
        Dim DataV(,) As String
        Dim RetF As Boolean
        Select Case True
            Case rbAddPresentLayer.Checked
                '現在のレイヤのオブジェクトに追加
                Dim LayerNum As Integer = ktGrid.Layer
                Dim mpFileName As String = ktGrid.LayerData(LayerNum, GridLayerData.MapFile).ToString
                Dim mpFile As clsMapData = attr.SetMapFile(mpFileName)
                Dim FXS(,) As String = ktGrid.FixedXSData(LayerNum)
                Dim ys As Integer = ktGrid.Ysize(LayerNum)
                Dim L_Time As strYMD
                If mpFile.Map.Time_Mode = False Then
                    L_Time = clsTime.GetNullYMD
                Else
                    L_Time = CType(ktGrid.LayerData(LayerNum, GridLayerData.Time), strYMD)
                End If
                Dim oGroup As Integer = PresentLayerObjGroup(cboPLayObjectGroup.SelectedIndex)
                Dim xs As Integer = lbPlayDefData.SelectedIndices.Count

                ReDim fydataV(xs - 1, 3)
                ReDim DataV(xs - 1, ys - 1)


                Dim misF As Boolean = False
                For i As Integer = 0 To ys - 1
                    Dim oname As String = FXS(1, i)
                    Dim f As Boolean = False
                    If oname Is Nothing = False Then
                        If oname <> "" Then
                            Dim code As Integer = attr.Get_ObjectCode_from_ObjName(mpFileName, oname, L_Time)
                            If code <> -1 Then
                                If mpFile.MPObj(code).Kind = oGroup Then
                                    For j As Integer = 0 To xs - 1
                                        Dim V As String
                                        mpFile.Get_DefTimeAttrValue(code, lbPlayDefData.SelectedIndices(j), L_Time, V)
                                        DataV(j, i) = V
                                        f = True
                                    Next
                                End If
                            End If
                        End If
                    End If
                    If f = False Then
                        misF = True
                    End If
                Next

                For i As Integer = 0 To xs - 1
                    With mpFile.ObjectKind(oGroup).DefTimeAttSTC(lbPlayDefData.SelectedIndices(i)).attData
                        If misF = True Then
                            fydataV(i, 0) = clsGeneric.ConvertMissingValueBoolString(misF)
                        Else
                            fydataV(i, 0) = clsGeneric.ConvertMissingValueBoolString(.MissingF)
                        End If
                        fydataV(i, 1) = .Title
                        fydataV(i, 2) = .Unit
                        fydataV(i, 3) = .Note
                    End With
                Next
                RetF = True
            Case rbAddNewLayer.Checked
                '新しいレイヤに追加
                Dim oGroup As Integer = cboNewLayObjGroup.SelectedIndex
                Dim MapFileName As String = cboNewLayerMapFile.Text
                Dim mpFile As clsMapData = attr.SetMapFile(MapFileName)
                Dim xs As Integer = lbNewLayerDefData.SelectedIndices.Count
                Dim okObj() As Integer
                Dim n As Integer = mpFile.Get_Objects_by_Group(oGroup, okObj)
                ReDim DataV(xs, n - 1)
                ReDim fydataV(xs - 1, 3)
                Dim L_Time As strYMD
                If mpFile.Map.Time_Mode = False Then
                    L_Time = clsTime.GetNullYMD
                Else
                    L_Time = clsTime.GetYMD(DateTimePickerNewLayer.Value)
                End If
                Dim obn As Integer = 0
                Dim misf(xs - 1) As Boolean
                For i As Integer = 0 To n - 1
                    Dim obName() As String
                    If mpFile.Get_Enable_ObjectName(okObj(i), L_Time, False, obName) = True Then
                        DataV(0, obn) = obName(0)
                        For j As Integer = 0 To xs - 1
                            Dim value As String
                            Dim attf As Boolean = mpFile.Get_DefTimeAttrValue(okObj(i), lbNewLayerDefData.SelectedIndices(j), L_Time, value)
                            If attf = False Then
                                value = ""
                                misf(j) = True
                            End If
                            DataV(j + 1, obn) = value
                        Next
                        obn += 1
                    End If
                Next

                For i As Integer = 0 To xs - 1
                    With mpFile.ObjectKind(oGroup).DefTimeAttSTC(lbNewLayerDefData.SelectedIndices(i)).attData
                        If misf(i) = True Then
                            fydataV(i, 0) = clsGeneric.ConvertMissingValueBoolString(misf(i))
                        Else
                            fydataV(i, 0) = clsGeneric.ConvertMissingValueBoolString(.MissingF)
                        End If
                        fydataV(i, 1) = .Title
                        fydataV(i, 2) = .Unit
                        fydataV(i, 3) = .Note
                    End With
                Next
                ReDim Preserve DataV(xs, obn - 1)
                LayName = txtNewLayerName.Text
                LayMapFile = MapFileName
                LayTime = L_Time
                shp = mpFile.ObjectKind(oGroup).Shape
                RetF = False
        End Select
        FYDataValue = fydataV
        DataValue = DataV
        Return RetF
    End Function

    Private Sub frmGridAddDefData_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.PropertyData, "frmGridAddDefData", Me)

    End Sub

    Private Sub cboPLayObjectGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPLayObjectGroup.SelectedIndexChanged
        Dim Obg As Integer = PresentLayerObjGroup(cboPLayObjectGroup.SelectedIndex)
        Dim LayerNum As Integer = ktGrid.Layer
        Dim mpFileName As String = ktGrid.LayerData(LayerNum, GridLayerData.MapFile).ToString
        Dim mpFile As clsMapData = attr.SetMapFile(mpFileName)

        lbPlayDefData.Items.Clear()
        For i As Integer = 0 To mpFile.ObjectKind(Obg).DefTimeAttDataNum - 1
            lbPlayDefData.Items.Add(mpFile.ObjectKind(Obg).DefTimeAttSTC(i).attData.Title)
        Next
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Select Case True
            Case rbAddPresentLayer.Checked
                If lbPlayDefData.SelectedIndices.Count = 0 Then
                    MsgBox("追加する初期属性データ項目を選択して下さい。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                End If
            Case rbAddNewLayer.Checked
                If lbNewLayerDefData.SelectedIndices.Count = 0 Then
                    MsgBox("追加する初期属性データ項目を選択して下さい。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                End If
        End Select
    End Sub



    Private Sub rbAddNewLayer_CheckedChanged(sender As Object, e As EventArgs) Handles rbAddNewLayer.CheckedChanged, rbAddPresentLayer.CheckedChanged
        If rbAddPresentLayer.Checked = True Then
            gbAddPresentLayer.Enabled = True
            gbAddNewLayer.Enabled = False
        Else
            gbAddPresentLayer.Enabled = False
            gbAddNewLayer.Enabled = True
        End If
    End Sub


    Private Sub cboNewLayerMapFile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNewLayerMapFile.SelectedIndexChanged
        Dim mpFile As clsMapData = attr.SetMapFile(cboNewLayerMapFile.Text)
        pnlTime.Enabled = mpFile.Map.Time_Mode
        With mpFile
            cboNewLayObjGroup.Items.Clear()
            For i As Integer = 0 To .Map.OBKNum - 1
                cboNewLayObjGroup.Items.Add(.ObjectKind(i).Name)
            Next
            cboNewLayObjGroup.SelectedIndex = 0
        End With
    End Sub

    Private Sub cboNewLayObjGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNewLayObjGroup.SelectedIndexChanged
        Dim Obg As Integer = cboNewLayObjGroup.SelectedIndex
        Dim mpFile As clsMapData = attr.SetMapFile(cboNewLayerMapFile.Text)

        lbNewLayerDefData.Items.Clear()
        For i As Integer = 0 To mpFile.ObjectKind(Obg).DefTimeAttDataNum - 1
            lbNewLayerDefData.Items.Add(mpFile.ObjectKind(Obg).DefTimeAttSTC(i).attData.Title)
        Next
    End Sub

    Private Sub frmGridAddDefData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class