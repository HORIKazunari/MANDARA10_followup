Public Class frmMED_GetLine

    Dim CloseCancelF As Boolean
    Dim beforeAlin As Integer
    Dim MapData As clsMapData
    Private Structure Pdata_Info
        Public Ido As Single
        Public Kedo As Single
        Public space As Boolean
    End Structure
    Private Structure LineAreaInfo
        Public StartPoint As Integer
        Public num As Integer
    End Structure
    Dim KData() As Pdata_Info
    Dim LineData() As LineAreaInfo
    Dim LineNum As Integer

    Private Sub frmMED_GetLine_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

        With cboLineKind
            .Items.Clear()
            .Items.AddRange(MapData.Get_LineKindNameList)
            .SelectedIndex = 0
        End With
        ResetGrdid(10)
        Return Me.ShowDialog(Owner)
    End Function
    Public Sub getResult(ByRef _beforeAlin As Integer, ByRef AddLineKindFlag As Boolean)
        AddLineKindFlag = rbNewLineKind.Checked
        _beforeAlin = beforeAlin
    End Sub

    Private Sub ResetGrdid(ByVal Rows As Integer)
        With ktGrid
            .init("データ", "行", "列", 1, 0, 1, 0, True, True, True, True, False, True, False, False, False, False)
            .AddLayer("", 0, 2, Rows)
            If rbLatLon.Checked = True Then
                .FixedYSData(0, 0, 0) = "緯度"
                .FixedYSData(0, 1, 0) = "経度"
            Else
                .FixedYSData(0, 0, 0) = "経度"
                .FixedYSData(0, 1, 0) = "緯度"
            End If
            .FixedXSWidth(0, 0) = 35
            .GridWidth(0, 0) = (.Width - .FixedXSWidth(0, 0)) / 2 - 10
            .GridWidth(0, 1) = .GridWidth(0, 0)
            .GridAlligntment(0, 0) = HorizontalAlignment.Right
            .GridAlligntment(0, 1) = HorizontalAlignment.Right
            .Show()
        End With
    End Sub

    Private Sub txtNewObjGroupName_Enter(sender As Object, e As EventArgs) Handles txtNewLineKindName.Enter
        rbNewLineKind.Checked = True
    End Sub


    Private Sub cboLineKind_Enter(sender As Object, e As EventArgs) Handles cboLineKind.Enter
        rbExistingLineKind.Checked = True
    End Sub

    Private Sub rbLatLon_CheckedChanged(sender As Object, e As EventArgs) Handles rbLatLon.CheckedChanged
        If Me.Visible = False Then
            Return
        End If
        With ktGrid
            If rbLatLon.Checked = True Then
                .FixedYSData(0, 0, 0) = "緯度"
                .FixedYSData(0, 1, 0) = "経度"
            Else
                .FixedYSData(0, 0, 0) = "経度"
                .FixedYSData(0, 1, 0) = "緯度"
            End If
            .Refresh()
        End With
    End Sub

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        clsGeneric.Set_ClipIdoKedo_to_KtgisGrid(ktGrid, 0, rbLatLon.Checked)
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

        beforeAlin = MapData.Map.ALIN
        Dim ST(,) As String = ktGrid.GridData(0)

        ReDim KData(n - 1)

        Dim OptSortV0 As Boolean = rbLatLon.Checked

        Dim n2 As Integer = 0
        Dim Msg As String = ""
        If rbNewLineKind.Checked = True Then
            If txtNewLineKindName.Text = "" Then
                Msg += "新しい線種名を設定してください。" + vbCrLf
            Else
                If MapData.Check_LineKindNameExist(txtNewLineKindName.Text) = True Then
                    Msg += "同一線種名が存在します。" + vbCrLf

                End If
            End If
        End If
        LineNum = 0
        Dim firstF As Boolean = True
        For i As Integer = 0 To n - 1
            Dim hdmes As String = (i + 1).ToString + ":"
            With KData(i)
                If ST(0, i) = "" And ST(1, i) = "" Then
                    If firstF = False Then
                        LineData(LineNum).num = i - LineData(LineNum).StartPoint
                        LineNum += 1
                    End If
                    firstF = True
                    .space = True
                Else
                    If firstF = True Then
                        ReDim Preserve LineData(LineNum)
                        LineData(LineNum).StartPoint = i
                        firstF = False
                    End If
                    clsGeneric.Check_IdoKedo_Value(ST(0, i), ST(1, i), rbLatLon.Checked, .Ido, .Kedo, hdmes, Msg)
                End If
            End With
        Next
        If firstF = False Then
            ReDim Preserve LineData(LineNum)
            LineData(LineNum).num = n - LineData(LineNum).StartPoint
            LineNum += 1
        End If
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
            Return
        Else
            Dim LkGroup As Integer
            If rbNewLineKind.Checked = True Then
                MapData.Add_OneLineKind(txtNewLineKindName.Text, clsBase.Line, enmMesh_Number.mhNonMesh)
                LkGroup = MapData.Map.LpNum - 1
            Else
                LkGroup = cboLineKind.SelectedIndex
            End If
            For i As Integer = 0 To LineNum - 1
                Dim newLine As clsMapData.strLine_Data = MapData.Init_One_Line(LkGroup)
                With LineData(i)
                    newLine.NumOfPoint = .num
                    ReDim newLine.PointSTC(.num - 1)
                    For j As Integer = 0 To .num - 1
                        With KData(j + .StartPoint)
                            newLine.PointSTC(j) = spatial.Get_Converted_XY(New PointF(.Kedo, .Ido), MapData.Map.Zahyo)
                        End With
                    Next
                End With
                MapData.Save_Line(newLine, True, False, True)
            Next
        End If
    End Sub

    Private Sub frmMED_GetLine_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_GetLine", Me)

        e.Cancel = True
    End Sub
End Class