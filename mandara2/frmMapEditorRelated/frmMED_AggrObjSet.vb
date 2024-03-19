Public Class frmMED_AggrObjSet
    Dim CloseCancelF As Boolean
    Dim UpperClassObjK As List(Of Integer)
    Dim MapData As clsMapData
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal UpperClassObjKind As List(Of Integer), ByRef MPData As clsMapData)
        Me.UpperClassObjK = UpperClassObjKind
        Me.MapData = MPData
        With cboUpperClassObjK
            .Items.Clear()
            For Each i As Integer In Me.UpperClassObjK
                .Items.Add(MapData.ObjectKind(i).Name)
            Next
            .SelectedIndex = 0
        End With
        Return (Me.ShowDialog(Owner))
    End Function
    ''' <summary>
    ''' まとめる集成オブジェクトの情報を返す
    ''' </summary>
    ''' <param name="ObjKind">オブジェクトグループ番号</param>
    ''' <param name="ExistingObjectCode">既存オブジェクトの場合、オブジェクト番号</param>
    ''' <returns>trueの場合新規オブジェクト、falseの場合既存オブジェクト</returns>
    ''' <remarks></remarks>
    Public Function getResult(ByRef ObjKind As Integer, ByRef ExistingObjectCode As Integer) As Boolean
        ObjKind = Me.UpperClassObjK(cboUpperClassObjK.SelectedIndex)
        ExistingObjectCode = Val(lblObjName.Tag)
        Return rbNewObject.Checked
    End Function



    Private Sub frmMED_AggrObjSet_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub cboUpperClassObjK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUpperClassObjK.SelectedIndexChanged
        lblObjName.Text = "未設定"
        lblObjName.Tag = -1
        cboUpperClassObjK.Tag = UpperClassObjK.Item(cboUpperClassObjK.SelectedIndex)
    End Sub

    Private Sub cboUpperClassObjK_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboUpperClassObjK.SelectedIndexChanged

    End Sub

    Private Sub btnObjSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObjSelect.Click
        Dim SearchObject As New frmSearch_Object
        Dim init_para As New frmSearch_Object.init_parameter_data(MapData)
        init_para.Time = frmMapEditor.EditList.EditTime
        If frmMapEditor.EditList.EditTime.nullFlag = False Then
            init_para.TimeChangeEnabled = False
        End If
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            init_para.ObjectGroupChecked(i) = False
        Next
        For Each i As Integer In Me.UpperClassObjK
            init_para.ObjectGroupChecked(i) = True
        Next
        init_para.ObjectTypeChangeEnabled = False
        init_para.ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject
        init_para.MultiSelect = False

        If SearchObject.ShowDialog(frmMapEditor, MapData, init_para) = Windows.Forms.DialogResult.OK Then
            Dim Scode As Integer = SearchObject.getSelectedObjectNumber
            Dim name As String
            MapData.Get_Enable_ObjectName(MapData.MPObj(Scode), frmMapEditor.EditList.EditTime, False, name)
            lblObjName.Tag = Scode
            lblObjName.Text = name
        End If
        SearchObject.Dispose()
    End Sub

    Private Sub rbAddExistedObject_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles rbAddExistedObject.CheckedChanged, rbNewObject.CheckedChanged
        If rbAddExistedObject.Checked = True Then
            btnObjSelect.Enabled = True
        Else
            btnObjSelect.Enabled = False
        End If
    End Sub

    Private Sub frmMED_AggrObjSet_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_AggrObjSet")
    End Sub

    Private Sub frmMED_AggrObjSet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        rbAddExistedObject.Checked = True

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If rbAddExistedObject.Checked = True Then
            If lblObjName.Tag = -1 Then
                Dim txtMSG As String = "既存オブジェクトを指定してください。"
                MsgBox(txtMSG, MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Exit Sub
            End If

        End If
    End Sub
End Class