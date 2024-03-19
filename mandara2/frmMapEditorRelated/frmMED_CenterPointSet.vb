Public Class frmMED_CenterPointSet
    Dim CloseCancelF As Boolean
    Dim MapData As clsMapData
    Private Structure Pdata_Info
        Public OName As String
        Public Ocode As Integer
        Public Ido As Single
        Public Kedo As Single
        Public Enabled As Boolean
    End Structure
    Dim KData() As Pdata_Info
    Dim Kdatan As Integer
    Dim UndoArray() As clsMapData.strObj_Data

    Dim ObjNameSearch As clsObjectNameSearch

    Private Sub frmMED_CenterPointSet_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

        Me.Tag = "off"
        MapData = mpData
        dbdtpTime.Visible = MapData.Map.Time_Mode

        'ResetGrdid(10)
        ObjNameSearch = New clsObjectNameSearch(MapData, False)
        Me.Tag = ""
        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResult() As clsMapData.strObj_Data()

        Return UndoArray
    End Function
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
            .GridWidth(0, 0) = 150
            .GridWidth(0, 1) = (.Width - .FixedXSWidth(0, 0) - .GridWidth(0, 0) - 18) / 2
            .GridWidth(0, 2) = .GridWidth(0, 1)
            .GridAlligntment(0, 0) = HorizontalAlignment.Left
            .GridAlligntment(0, 1) = HorizontalAlignment.Right
            .GridAlligntment(0, 2) = HorizontalAlignment.Right

            .Show()
        End With
    End Sub

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        clsGeneric.Set_ClipIdoKedo_to_KtgisGrid(ktGrid, 1, rbLatLon.Checked)
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


    Private Sub btmCheck_Click(sender As Object, e As EventArgs) Handles btmCheck.Click
        If CheckData() = True Then
            MsgBox("設定可能です。")
        End If
    End Sub
    Private Function CheckData() As Boolean

        Dim Gtime As strYMD

        If MapData.Map.Time_Mode = True Then
            If dbdtpTime.Value.nullFlag = True Then
                MsgBox("時期設定を行ってください。", vbExclamation)
                Return False
            Else
                Gtime = dbdtpTime.Value
            End If
        End If

        Dim n As Integer = ktGrid.Ysize(0)
        If n = 0 Then
            MsgBox("データがありません。", MsgBoxStyle.Exclamation)
            Return False
        End If


        Dim ST(,) As String = ktGrid.GridData(0)

        ReDim KData(n - 1)

        Dim OptSortV0 As Boolean = rbLatLon.Checked

        Dim Msg As String = ""
        Kdatan = 0
        For i As Integer = 0 To n - 1
            Dim hdmes As String = (i + 1).ToString + ":"
            With KData(Kdatan)
                If ST(0, i) <> "" Then
                    .OName = ST(0, i)
                    .Ocode = ObjNameSearch.Get_KenToCode(.OName, Gtime)
                    If .Ocode = -1 Then
                        Msg += hdmes + "該当オブジェクト名がありません" + vbCrLf
                    Else
                        If clsGeneric.Check_IdoKedo_Value(ST(1, i), ST(2, i), rbLatLon.Checked, .Ido, .Kedo, hdmes, Msg) = True Then
                            Kdatan += 1
                        End If
                    End If

                End If
            End With
        Next
        If Msg <> "" Then
            clsGeneric.Message(Me, "データに問題があります", Msg, True, True)
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If CheckData() = False Then
            CloseCancelF = True
            Return
        End If
        ReDim UndoArray(Kdatan - 1)
        For i As Integer = 0 To Kdatan - 1
            With KData(i)
                UndoArray(i) = MapData.MPObj(.Ocode).Clone
                MapData.MPObj(.Ocode).CenterPSTC(0).Position = spatial.Get_Converted_XY(New PointF(.Kedo, .Ido), MapData.Map.Zahyo)
                MapData.Check_Obj_Maxmin(MapData.MPObj(.Ocode), True)
            End With
        Next
 
        MapData.Map.Circumscribed_Rectangle = MapData.Get_Mapfile_Rectangle()

    End Sub

    Private Sub frmMED_CenterPointSet_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_CenterPointSet", Me)
        e.Cancel = True
    End Sub

    Private Sub frmMED_CenterPointSet_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ResetGrdid(10)
    End Sub
End Class