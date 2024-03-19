Public Class frmPrint_DummyObjectGroup
    Dim attrData As clsAttrData
    Dim Dummy() As clsAttrData.strDummyObjectInfo
    Dim DummyObjectPointMark As New Dictionary(Of String, clsAttrData.strDummyObjectPointMark_Info())
    Dim DummyOBGroup() As clsAttrData.strDummyObjectGroupInfo
    Dim MapFileList() As String
    Private picPointObjectMarkBox() As System.Windows.Forms.PictureBox
    Private lblObjectGroupName() As System.Windows.Forms.Label
    Private Const LineKindHeight = 30
    Dim PolygonDummy_ClipSet_F() As Boolean

    Dim LayerNum As Integer
    Dim LayMax As Integer
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData)
        Me.AcceptButton = btnOK
        attrData = _attrData
        LayerNum = attrData.TotalData.LV1.SelectedLayer
        LayMax = attrData.TotalData.LV1.Lay_Maxn
        ReDim Dummy(LayMax - 1)
        ReDim DummyOBGroup(LayMax - 1)
        ReDim PolygonDummy_ClipSet_F(LayMax - 1)
        For i As Integer = 0 To LayMax - 1
            With attrData.LayerData(i)
                Dummy(i) = .Dummy
                DummyOBGroup(i).Count = .DummyGroup.Count
                If DummyOBGroup(i).Count > 0 Then
                    DummyOBGroup(i).DummyObjG = .DummyGroup.DummyObjG.Clone
                End If
                PolygonDummy_ClipSet_F(i) = .LayerModeViewSettings.PolygonDummy_ClipSet_F
            End With
        Next
        Me.Tag = "OFF"
        attrData.Set_LayerName_to(cboLayer, LayerNum)
        setDummyObjectList()

        If attrData.TotalData.ViewStyle.DummyObjectPointMark.Count > 0 Then
            For Each d As KeyValuePair(Of String, clsAttrData.strDummyObjectPointMark_Info()) In attrData.TotalData.ViewStyle.DummyObjectPointMark
                DummyObjectPointMark.Add(d.Key, d.Value)
            Next

            MapFileList = attrData.TotalData.ViewStyle.DummyObjectPointMark.Keys.ToArray()
            cboMapFile.Items.AddRange(MapFileList)
            cboMapFile.SelectedIndex = 0
            gbPointOBJGMark.Enabled = True
        Else
            gbPointOBJGMark.Enabled = False
        End If
        chkDummy_Size.Checked = attrData.TotalData.ViewStyle.Dummy_Size_Flag
        Me.Tag = ""

        Return Me.ShowDialog()
    End Function
    Public Sub getResults(ByRef _Dummy() As clsAttrData.strDummyObjectInfo,
                          ByRef _DummyGroup() As clsAttrData.strDummyObjectGroupInfo,
                          ByRef _PolygonDummy_ClipSet_F() As Boolean,
                          ByRef _Dummy_Size_Flag As Boolean,
                          ByRef _DummyObjectPointMark As Dictionary(Of String, clsAttrData.strDummyObjectPointMark_Info()))
        _Dummy = Dummy
        _DummyGroup = DummyOBGroup
        _PolygonDummy_ClipSet_F = PolygonDummy_ClipSet_F
        _Dummy_Size_Flag = chkDummy_Size.Checked
        _DummyObjectPointMark = DummyObjectPointMark
    End Sub
    Private Sub setDummyObjectList()
        lstDummyObject.Items.Clear()
        chklDummyGroup.Items.Clear()
        Select Case attrData.LayerData(LayerNum).Type
            Case clsAttrData.enmLayerType.Trip_Definition
                gbDummyObject.Enabled = False
                gbDummyObjectGroup.Enabled = False
                chkDummyClip.Enabled = False
                Return
            Case Else
                gbDummyObject.Enabled = True
                gbDummyObjectGroup.Enabled = True
                chkDummyClip.Enabled = True
        End Select

        With lstDummyObject
            For i As Integer = 0 To Dummy(LayerNum).Count - 1
                .Items.Add(Dummy(LayerNum).DummyObj(i).Name)
            Next

        End With

        chklDummyGroup.EventStop = True
        With attrData.LayerData(LayerNum).MapFileData
            For i As Integer = 0 To .Map.OBKNum - 1
                chklDummyGroup.Items.Add(.ObjectKind(i).Name)
            Next
        End With
        With DummyOBGroup(LayerNum)
            For i As Integer = 0 To .Count - 1
                chklDummyGroup.SetItemChecked(.DummyObjG(i), True)
            Next
        End With
        chklDummyGroup.EventStop = False

        If attrData.LayerData(LayerNum).Type = clsAttrData.enmLayerType.Normal Or attrData.LayerData(LayerNum).Type = clsAttrData.enmLayerType.Mesh Or attrData.LayerData(LayerNum).Type = clsAttrData.enmLayerType.DefPoint Then
            chkDummyClip.Checked = PolygonDummy_ClipSet_F(LayerNum)
            chkDummyClip.Enabled = True
        Else
            chkDummyClip.Checked = False
            chkDummyClip.Enabled = False
        End If


    End Sub

    Private Sub lstDummyObject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDummyObject.SelectedIndexChanged

    End Sub

    Private Sub cboLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayer.SelectedIndexChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        LayerNum = cboLayer.SelectedIndex
        setDummyObjectList()
    End Sub

    Private Sub btnDeleteDummyObject_Click(sender As Object, e As EventArgs) Handles btnDeleteDummyObject.Click
        Dim n As Integer = lstDummyObject.SelectedIndex
        If n = -1 Then
            Return
        End If
        lstDummyObject.Items.RemoveAt(n)
        clsGeneric.ListIndex_Reset(lstDummyObject, n)
        For i As Integer = n To Dummy(LayerNum).Count - 2
            Dummy(LayerNum).DummyObj(i) = Dummy(LayerNum).DummyObj(i + 1)
        Next
        Dummy(LayerNum).Count -= 1
        If Dummy(LayerNum).Count <> 0 Then
            ReDim Preserve Dummy(LayerNum).DummyObj(Dummy(LayerNum).Count - 1)
        End If
    End Sub

    Private Sub btnAddDummyObject_Click(sender As Object, e As EventArgs) Handles btnAddDummyObject.Click
        Dim txt As String = txtDummy.Text
        If txt = "" Then
            MsgBox("オブジェクト名を入力して下さい。")
        End If
        Dim str As New List(Of String)
        str.Add(txt)
        Dim OKCodeName As List(Of clsAttrData.strDummyObjectName_and_Code) = AddDummyObject(str)
        If OKCodeName.Count = 1 Then
            txtDummy.Text = ""
            txtDummy.Focus()
        End If
    End Sub
    Private Function AddDummyObject(ByRef str As List(Of String)) As List(Of clsAttrData.strDummyObjectName_and_Code)
        Dim emes As String = ""
        Dim emesUsed As String = ""
        Dim OKCodeName As New List(Of clsAttrData.strDummyObjectName_and_Code)
        For Each objName As String In str
            If objName <> "" Then
                Dim code As Integer = attrData.Get_ObjectCode_from_ObjName(LayerNum, objName)
                If code = -1 Then
                    emes += "/" + objName
                Else
                    Dim f As Boolean = True
                    For j As Integer = 0 To Dummy(LayerNum).Count - 1
                        If Dummy(LayerNum).DummyObj(j).code = code Then
                            emesUsed += "/" + objName
                            f = False
                            Exit For
                        End If
                    Next
                    If f = True Then
                        Dim d As clsAttrData.strDummyObjectName_and_Code
                        d.code = code
                        d.Name = objName
                        OKCodeName.Add(d)
                    End If
                End If
            End If
        Next
        Dim PlusN As Integer = OKCodeName.Count
        If PlusN > 0 Then
            Dim n As Integer = Dummy(LayerNum).Count
            ReDim Preserve Dummy(LayerNum).DummyObj(n + PlusN)
            Dim dn As Integer = 0
            For Each d In OKCodeName
                With Dummy(LayerNum).DummyObj(Dummy(LayerNum).Count + dn)
                    .Name = d.Name
                    .code = d.code
                End With
                dn += 1
                lstDummyObject.Items.Add(d.Name)
            Next
            Dummy(LayerNum).Count += PlusN
        End If
        If emes <> "" Then
            MsgBox("以下のオブジェクトは見つかりません。" + emes, MsgBoxStyle.Exclamation)
        End If
        If emesUsed <> "" Then
            MsgBox("以下のオブジェクトは既にダミーオブジェクトに入っています。" + emesUsed, MsgBoxStyle.Exclamation)
        End If
        Return OKCodeName
    End Function
    Private Sub txtDummy_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDummy.KeyDown
        If e.KeyData = Keys.Enter Then
            btnAddDummyObject.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtDummy_Enter(sender As Object, e As EventArgs) Handles txtDummy.Enter
        Me.AcceptButton = Nothing
    End Sub
    Private Sub txtDummy_Leave(sender As Object, e As EventArgs) Handles txtDummy.Leave
        Me.AcceptButton = btnOK
    End Sub

    Private Sub btnAddFromClipboard_Click(sender As Object, e As EventArgs) Handles btnAddFromClipboard.Click
        Dim sdata As String = Clipboard.GetText
        If sdata = "" Then
            Dim msgText1 As String = "クリップボードにデータがありません。"
            MsgBox(msgText1, MsgBoxStyle.Exclamation)
            Return
        End If
        Dim eaxhSTR() As String = clsGeneric.Get_EachValueArray(Split(sdata.Replace(vbCrLf, vbTab), vbTab))
        Dim str As New List(Of String)
        str.AddRange(eaxhSTR)

        Dim OKCodeName As List(Of clsAttrData.strDummyObjectName_and_Code) = AddDummyObject(str)
    End Sub

    Private Sub chklDummyGroup_leave(sender As Object, e As CheckedListBoxExChangeEventArgs) Handles chklDummyGroup.changed
        Dim n As Integer = chklDummyGroup.Items.Count
        With DummyOBGroup(LayerNum)
            ReDim .DummyObjG(n - 1)
            .Count = 0
            For i As Integer = 0 To n - 1
                If e.ItemCheck(i) = True Then
                    .DummyObjG(.Count) = i
                    .Count += 1
                End If
            Next
            If .Count > 0 Then
                ReDim Preserve .DummyObjG(.Count - 1)
            Else
                .DummyObjG = Nothing
            End If
        End With

    End Sub

    Private Sub showPointMark()
        Dim LeftMargin = SystemInformation.VerticalScrollBarWidth + 3
        If Me.picPointObjectMarkBox Is Nothing = False Then
            For Each p As PictureBox In Me.picPointObjectMarkBox
                RemoveHandler p.Click, AddressOf picPointObjectMarkBoxClick
                Me.pnlPointObjGroup.Controls.Remove(p)
            Next
            For Each t As Label In Me.lblObjectGroupName
                Me.pnlPointObjGroup.Controls.Remove(t)
            Next
        End If

        Dim Mpindex As Integer = cboMapFile.SelectedIndex
        Dim DOPMark() As clsAttrData.strDummyObjectPointMark_Info = DummyObjectPointMark(cboMapFile.Text)
        Dim DOPnum As Integer = DOPMark.Length
        pnlPointObjGroup.Left = 0
        pnlPointObjGroup.Width = pnlPointObjGroupContainer.Width - LeftMargin
        pnlPointObjGroup.Height = DOPnum * LineKindHeight + 10
        Me.picPointObjectMarkBox = New PictureBox(DOPnum - 1) {}
        Me.lblObjectGroupName = New Label(DOPnum - 1) {}
        For i As Integer = 0 To DOPnum - 1
            Me.picPointObjectMarkBox(i) = New System.Windows.Forms.PictureBox
            Me.lblObjectGroupName(i) = New System.Windows.Forms.Label
            With Me.picPointObjectMarkBox(i)
                .Parent = pnlPointObjGroup
                .Top = i * LineKindHeight + 3
                .Height = LineKindHeight - 6
                .Left = pnlPointObjGroup.Width - 60
                .Width = 55
                .Tag = i
                .BorderStyle = BorderStyle.Fixed3D
                AddHandler .Click, AddressOf picPointObjectMarkBoxClick
                attrData.Draw_Sample_Mark_Box(Me.picPointObjectMarkBox(i), DOPMark(i).Mark)
            End With
            With Me.lblObjectGroupName(i)
                .Parent = pnlPointObjGroup
                .Top = i * LineKindHeight + 3
                .Left = 3
                .AutoSize = False
                .Width = Me.picPointObjectMarkBox(i).Left - 6
                .Height = Me.picPointObjectMarkBox(i).Height
                .Text = DOPMark(i).ObjectKindName
            End With
        Next

    End Sub
    Private Sub picPointObjectMarkBoxClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim DOPMark() As clsAttrData.strDummyObjectPointMark_Info = DummyObjectPointMark(cboMapFile.Text)
        attrData.Select_Mark(picPointObjectMarkBox(sender.tag), DOPMark(sender.tag).Mark)
        DummyObjectPointMark(cboMapFile.Text) = DOPMark
    End Sub

    Private Sub cboMapFile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMapFile.SelectedIndexChanged
        showPointMark()
    End Sub




    Private Sub chkDummyClip_Leave(sender As Object, e As EventArgs) Handles chkDummyClip.Leave
        PolygonDummy_ClipSet_F(LayerNum) = chkDummyClip.Checked
    End Sub

    Private Sub btnObjCopyPanel_Click(sender As Object, e As EventArgs) Handles btnObjCopyPanel.Click
        Dim init_para As New frmCopyObjectName.init_parameter_data(attrData.LayerData(LayerNum).MapFileData)
        init_para.Time = attrData.LayerData(LayerNum).Time
        Dim form = New frmCopyObjectName
        form.ShowDialog(Me, attrData.LayerData(LayerNum).MapFileData, init_para)
        form.Dispose()
    End Sub
    Private Sub frmPrint_KMLFileOut_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "frmPrint_DummyObjectGroup", Me)
    End Sub
End Class