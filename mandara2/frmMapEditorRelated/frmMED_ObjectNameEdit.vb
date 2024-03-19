Public Class frmMED_ObjectNameEdit
    Dim CloseCancelF As Boolean
    Dim SearchSTR As String
    Dim MapData As clsMapData
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
    Public Overloads Function ShowDialog(ByRef MData As clsMapData) As Windows.Forms.DialogResult
        MapData = MData
        Dim OBKNum() As Integer = MapData.Get_ObjectKind_Use_Number
        KtGrid.init("オブジェクトグループ", "オブジェクト", "オブジェクト名リスト", 1, 1, 2, 1, True, True, True, False, True, False, True, False, True, False)
        With MapData
            For i As Integer = 0 To .Map.OBKNum - 1
                With .ObjectKind(i)
                    KtGrid.AddLayer(.Name, i, .ObjectNameNum, Math.Max(OBKNum(i), 1))
                    For j As Integer = 0 To .ObjectNameNum - 1
                        KtGrid.FixedYSData(i, j, 1) = .ObjectNameList(j)
                        KtGrid.GridAlligntment(i, j) = HorizontalAlignment.Left
                    Next
                End With
            Next
            Dim ObjGridAdd(.Map.OBKNum - 1) As Integer
            For i As Integer = 0 To .Map.Kend - 1
                With .MPObj(i)
                    For j As Integer = 0 To .NameTimeSTC(0).NamesList.Length - 1
                        KtGrid.GridData(.Kind, j, ObjGridAdd(.Kind)) = .NameTimeSTC(0).NamesList(j)
                    Next
                    ObjGridAdd(.Kind) += 1
                End With
            Next
            KtGrid.Show()
        End With
        Return Me.ShowDialog

    End Function
    Public Function GetResults()
        With MapData
            For i As Integer = 0 To .Map.OBKNum - 1
                With .ObjectKind(i)
                    .ObjectNameNum = KtGrid.Xsize(i)
                    ReDim .ObjectNameList(.ObjectNameNum - 1)
                    For j As Integer = 0 To .ObjectNameNum - 1
                        .ObjectNameList(j) = KtGrid.FixedYSData(i, j, 1)
                    Next
                End With
            Next
            Dim ObjGridAdd(.Map.OBKNum - 1) As Integer
            For i As Integer = 0 To .Map.Kend - 1
                With .MPObj(i)
                    Dim n As Integer = MapData.ObjectKind(.Kind).ObjectNameNum
                    ReDim .NameTimeSTC(0).NamesList(n - 1)
                    Dim y As Integer = ObjGridAdd(.Kind)
                    For j As Integer = 0 To n - 1
                        .NameTimeSTC(0).NamesList(j) = KtGrid.GridData(.Kind, j, y)
                    Next
                    ObjGridAdd(.Kind) += 1
                End With
            Next
        End With
    End Function



    Private Sub btnBefore_Click(sender As Object, e As EventArgs) Handles btnBefore.Click

        KtGrid.FindRev(SearchSTR, KTGISUserControl.KTGISGrid.enmMatchingMode.PartialtMatching)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        KtGrid.Find(SearchSTR, KTGISUserControl.KTGISGrid.enmMatchingMode.PartialtMatching)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            If KtGrid.Xsize(i) = 0 Then
                MsgBox("オブジェクト名がありません。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
            End If
        Next
    End Sub

    Private Sub btnGetFromDefData_Click(sender As Object, e As EventArgs) Handles btnGetFromDefData.Click
        Dim form = New frmMED_ObjectNameAddFromAttrData
        If form.ShowDialog(Me, MapData, KtGrid.Layer) = DialogResult.OK Then
            Dim OBG As Integer
            Dim DataNum As Integer
            form.GetResults(OBG, DataNum)
            Dim title As String = MapData.ObjectKind(OBG).DefTimeAttSTC(DataNum).attData.Title
            Dim ObjNameN As Integer = KtGrid.Xsize(OBG)
            KtGrid.AddDataItem(OBG, ObjNameN, 1)
            KtGrid.FixedYSData(OBG, ObjNameN, 1) = title
            Dim y As Integer = 0
            For i As Integer = 0 To MapData.Map.Kend - 1
                With MapData.MPObj(i)
                    If .Kind = OBG Then
                        Dim v As String = ""
                        Dim time As strYMD = clsTime.GetNullYMD
                        MapData.Get_DefTimeAttrValue(i, DataNum, time, v)
                        KtGrid.GridData(OBG, ObjNameN, y) = v
                        y += 1
                    End If
                End With
            Next
            KtGrid.Layer = OBG
            MsgBox(MapData.ObjectKind(OBG).Name + "のオブジェクト名に" + title + "の値を追加しました。")
            KtGrid.Refresh()
        End If

        form.Dispose()
    End Sub

    Private Sub txtObjNameSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObjNameSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnNext.PerformClick()
        End If
    End Sub

    Private Sub txtObjNameSearch_TextChanged(sender As Object, e As EventArgs) Handles txtObjNameSearch.TextChanged
        SearchSTR = txtObjNameSearch.Text
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ObjectNameEdit", Me)
    End Sub
End Class