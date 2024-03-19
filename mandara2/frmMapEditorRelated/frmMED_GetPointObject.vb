Public Class frmMED_GetPointObject
    Dim CloseCancelF As Boolean
    Dim beforeKend As Integer
    Dim MapData As clsMapData
    Private Structure Pdata_Info
        Public OName As String
        Public Ocode As Integer
        Public Ido As Single
        Public Kedo As Single
    End Structure
    Dim KData() As Pdata_Info
    Dim Kdatan As Integer
    Dim ObjNameSearch As clsObjectNameSearch


    Private Sub frmMED_GetPointObject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef mpData As clsMapData) As Windows.Forms.DialogResult

        MapData = mpData

        Dim aggrObjName() As String = MapData.Get_ObjectGroupNameList(clsMapData.enmObjectGoupType_Data.NormalObject)
        With cboObjectKind
            .Items.Clear()
            .Items.AddRange(aggrObjName)
            .SelectedIndex = 0
        End With
        ObjNameSearch = New clsObjectNameSearch(MapData, False)
        ResetGrdid(10)
        Return Me.ShowDialog(Owner)
    End Function
    Public Sub getResult(ByRef _beforeKend As Integer, ByRef AddObjGFlag As Boolean)
        AddObjGFlag = rbNewObjGroup.Checked
        _beforeKend = beforeKend
    End Sub

    Private Sub ResetGrdid(ByVal Rows As Integer)
        With ktGrid
            .init("データ", "行", "列", 1, 0, 1, 0, True, True, True, True, False, True, False, False, False, False)
            .AddLayer("", 0, 3, Rows)
            .FixedYSData(0, 0, 0) = "オブジェクト名"
            If rbLatLon.Checked = True Then
                .FixedYSData(0, 1, 0) = "緯度"
                .FixedYSData(0, 2, 0) = "経度"
            Else
                .FixedYSData(0, 1, 0) = "経度"
                .FixedYSData(0, 2, 0) = "緯度"
            End If
            .GridWidth(0, 0) = 125
            .GridWidth(0, 1) = (.Width - .FixedXSWidth(0, 0) - .GridWidth(0, 0)) / 2 - 10
            .GridWidth(0, 2) = .GridWidth(0, 1)
            .GridAlligntment(0, 0) = HorizontalAlignment.Left
            .GridAlligntment(0, 1) = HorizontalAlignment.Right
            .GridAlligntment(0, 2) = HorizontalAlignment.Right
            .Show()
        End With
    End Sub

    Private Sub rbLatLon_CheckedChanged(sender As Object, e As EventArgs) Handles rbLatLon.CheckedChanged, rbLonLat.CheckedChanged
        If Me.Tag = "off" Or Me.Visible = False Then
            Return
        End If
        With ktGrid
            If rbLatLon.Checked = True Then
                .FixedYSData(0, 1, 0) = "緯度"
                .FixedYSData(0, 2, 0) = "経度"
            Else
                .FixedYSData(0, 1, 0) = "経度"
                .FixedYSData(0, 2, 0) = "緯度"
            End If
            .Refresh()
        End With
    End Sub
    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click

        clsGeneric.Set_ClipIdoKedo_to_KtgisGrid(ktGrid, 1, rbLatLon.Checked)

    End Sub
    Private Sub btmCheck_Click(sender As Object, e As EventArgs) Handles btmCheck.Click
        If CheckData() = True Then
            MsgBox("設定可能です。")
        End If
    End Sub
    Private Function CheckData() As Boolean


        Dim n As Integer = ktGrid.Ysize(0)
        If n = 0 Then
            MsgBox("データがありません。", MsgBoxStyle.Exclamation)
            Return False
        End If

        beforeKend = MapData.Map.Kend
        Dim ST(,) As String = ktGrid.GridData(0)

        ReDim KData(n - 1)

        Dim OptSortV0 As Boolean = rbLatLon.Checked

        Kdatan = 0
        Dim Msg As String = ""
        If rbNewObjGroup.Checked = True Then
            If txtNewObjGroupName.Text = "" Then
                Msg += "新しいオブジェクトグループ名を設定してください。" + vbCrLf
            Else
                If MapData.Check_ObjectGroupNameExist(txtNewObjGroupName.Text) = True Then
                    Msg += "同一オブジェクトグループ名が存在します。" + vbCrLf

                End If
            End If
        End If
        For i As Integer = 0 To n - 1
            Dim hdmes As String = (i + 1).ToString + ":"
            With KData(Kdatan)
                .OName = ST(0, i)
                If .OName <> "" Then
                    .Ocode = ObjNameSearch.Get_KenToCode(.OName, clsTime.GetNullYMD)
                    If .Ocode <> -1 Then
                        Msg += hdmes + "【" + .OName + "】オブジェクト名が既に使用されています。" + vbCrLf
                    Else
                        If clsGeneric.Check_IdoKedo_Value(ST(1, i), ST(2, i), rbLatLon.Checked, .Ido, .Kedo, hdmes, Msg) = True Then
                            Kdatan += 1
                        End If
                    End If
                End If
            End With
        Next
        If Msg <> "" Then
            clsGeneric.Message(Me, "データに問題があります", Msg, True, False)
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If CheckData() = False Then
            CloseCancelF = True
            Exit Sub
        End If

        Dim SetKind As Integer
        If rbNewObjGroup.Checked = True Then
            SetKind = MapData.Map.OBKNum
            MapData.Add_OneObjectGroup_Parameter(txtNewObjGroupName.Text, enmShape.PointShape, enmMesh_Number.mhNonMesh, clsMapData.enmObjectGoupType_Data.NormalObject)
        Else
            SetKind = MapData.Get_ObjectGroupPosition_by_Type(cboObjectKind.SelectedIndex, clsMapData.enmObjectGoupType_Data.NormalObject)
            If MapData.ObjectKind(SetKind).Shape <> enmShape.PointShape Then
                Dim txt As String = "指定したオブジェクトグループの形状は" + clsGeneric.ConvertShapeEnumString(MapData.ObjectKind(SetKind).Shape) + "です。" +
                    vbCrLf + "このまま登録しますか?"
                If MsgBox(txt, vbYesNo) = vbNo Then
                    CloseCancelF = True
                    Exit Sub
                End If
            End If
        End If

        For i As Integer = 0 To Kdatan - 1
            With KData(i)
                Dim p As PointF = spatial.Get_Converted_XY(New PointF(.Kedo, .Ido), MapData.Map.Zahyo)
                Dim name() As String = {.OName}
                MapData.Add_OnePointObject(SetKind, name, p)
            End With
        Next
    End Sub

    Private Sub cboObjectKind_Enter(sender As Object, e As EventArgs) Handles cboObjectKind.Enter
        rbExistingObjGroup.Checked = True
    End Sub


    Private Sub txtNewObjGroupName_Enter(sender As Object, e As EventArgs) Handles txtNewObjGroupName.Enter
        rbNewObjGroup.Checked = True
    End Sub


    Private Sub frmMED_GetPointObject_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_GetPointObject", Me)
        e.Cancel = True
    End Sub
End Class