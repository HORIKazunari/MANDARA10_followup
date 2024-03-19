Public Class frmMED_ObjectTimeNameEdit
    Private Structure Obj_Info
        Public NameTimeStac() As clsMapData.Object_NameTimeStac_Data
        Public Kind As Integer
        Public GroupPos As Integer
    End Structure
    Dim CloseCancelF As Boolean
    Dim MapData As clsMapData
    Dim Obj() As Obj_Info
    Dim Group() As clsMapData.strObjectGroup_Data
    Dim GridReverseObjCode As New List(Of Integer())
    Dim SearchSTR As String
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
    Public Overloads Function ShowDialog(ByRef _MapData As clsMapData) As Windows.Forms.DialogResult
        MapData = _MapData
        With MapData
            ReDim Group(.Map.OBKNum - 1)
            ReDim Obj(.Map.Kend - 1)
            For i As Integer = 0 To .Map.OBKNum - 1
                Group(i) = .ObjectKind(i).Clone
                Dim ObjCode() As Integer
                Dim ObjNum As Integer = MapData.Get_Objects_by_Group(i, ObjCode, clsTime.GetNullYMD)
                GridReverseObjCode.Add(ObjCode)
            Next
            Dim objectKindStac(.Map.OBKNum - 1) As Integer
            For i As Integer = 0 To .Map.Kend - 1
                With .MPObj(i)
                    Obj(i).NameTimeStac = .NameTimeSTC.Clone
                    If .NumOfNameTime <> .NameTimeSTC.Length Then
                        ReDim Preserve Obj(i).NameTimeStac(.NumOfNameTime - 1)
                    End If
                    Obj(i).Kind = .Kind
                    Obj(i).GroupPos = objectKindStac(.Kind)
                    objectKindStac(.Kind) += 1
                End With
            Next
        End With

        KtGrid.init("オブジェクトグループ", "オブジェクト", "オブジェクト名", 1, 1, 1, 0, False, True, False, False, False, False, False, False, True, False)
        KtGrid.DefaultGridWidth = 160
        For i As Integer = 0 To Group.Length - 1
            Dim objlist() As Integer = GridReverseObjCode(i)
            Dim mx As Integer = 0
            For j As Integer = 0 To objlist.Length - 1
                mx = Math.Max(Obj(objlist(j)).NameTimeStac.Length, mx)
            Next
            KtGrid.AddLayer(Group(i).Name, i, mx * 2, objlist.Length)
            setGridLayer(objlist, i)
        Next
        KtGrid.Show()
        Return Me.ShowDialog

    End Function
    Private Sub setGridLayer(ByRef objlist() As Integer, ByVal Layer As Integer)
        Dim mx As Integer = KtGrid.Xsize(Layer) \ 2
        KtGrid.FixedUpperLeftData(Layer, 0, 0) = "オブジェクト番号"
        For j As Integer = 0 To mx - 1
            KtGrid.FixedYSData(Layer, j * 2, 0) = "期間"
            KtGrid.FixedYSData(Layer, j * 2 + 1, 0) = "オブジェクト名"
            KtGrid.GridAlligntment(Layer, j * 2) = HorizontalAlignment.Left
            KtGrid.GridAlligntment(Layer, j * 2 + 1) = HorizontalAlignment.Left
        Next
        For j As Integer = 0 To objlist.Length - 1
            KtGrid.FixedXSData(Layer, 0, j) = objlist(j).ToString
            With Obj(objlist(j))
                setGridObjStac(Layer, j, .NameTimeStac)
            End With
        Next
    End Sub
    Private Sub setGridObjStac(ByVal GroupNum As Integer, ByVal Y As Integer, ByRef NameTimeStac() As clsMapData.Object_NameTimeStac_Data)

        For k As Integer = 0 To NameTimeStac.Length - 1
            Dim s As String = clsTime.StartEndtoString(NameTimeStac(k).SETime)
            KtGrid.GridData(GroupNum, k * 2, Y) = s
            KtGrid.GridData(GroupNum, k * 2 + 1, Y) = NameTimeStac(k).connectNames
        Next

    End Sub
    Public Function GetResults()
        With MapData
            For i As Integer = 0 To .Map.OBKNum - 1
                With .ObjectKind(i)
                    .ObjectNameNum = Group(i).ObjectNameNum
                    .ObjectNameList = Group(i).ObjectNameList.Clone
                End With
            Next
            For i As Integer = 0 To .Map.Kend - 1
                With .MPObj(i)
                    .NumOfNameTime = Obj(i).NameTimeStac.Length
                    ReDim .NameTimeSTC(.NumOfNameTime - 1)
                    For j As Integer = 0 To .NumOfNameTime - 1
                        .NameTimeSTC(j) = Obj(i).NameTimeStac(j).Clone
                    Next
                End With
            Next
        End With
    End Function


    ''' <summary>
    ''' セルをクリックして入力画面に
    ''' </summary>
    ''' <param name="Layer"></param>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="Value"></param>
    ''' <param name="Top"></param>
    ''' <param name="Left"></param>
    ''' <param name="Width"></param>
    ''' <param name="Height"></param>
    ''' <remarks></remarks>
    Private Sub ktgrid_Click_DataGrid(Layer As Integer, X As Integer, Y As Integer, Value As String, Top As Single, Left As Single, Width As Single, Height As Single) Handles KtGrid.Click_DataGrid

        Dim form As New frmMED_ObjectNameTimeSet
        Dim Ocode As Integer = GridReverseObjCode(Layer)(Y)
        If form.ShowDialog(Me, Group, Obj(Ocode).Kind, Obj(Ocode).NameTimeStac.Length, Obj(Ocode).NameTimeStac) = Windows.Forms.DialogResult.OK Then
            form.GetNameTimeStac(Obj(Ocode).NameTimeStac)
            Dim n As Integer = Obj(Ocode).NameTimeStac.Length
            If n > KtGrid.Xsize(Layer) \ 2 Then
                KtGrid.AddDataItem(Layer, KtGrid.Xsize(Layer), (n * 2 - KtGrid.Xsize(Layer)))
            End If
            setGridObjStac(Layer, Y, Obj(Ocode).NameTimeStac)
            KtGrid.Refresh()
        End If
        form.Dispose()

    End Sub


    Private Sub btnObjNameListEdit_Click(sender As Object, e As EventArgs) Handles btnObjNameListEdit.Click
        Dim gn As Integer = KtGrid.Layer
        Dim form As New frmMED_ObjectTimeNameList
        If form.ShowDialog(Group(gn)) = Windows.Forms.DialogResult.OK Then
            Dim Convert() As Integer
            Dim NameList() As String
            form.GetResults(Convert, NameList)
            Dim n As Integer = Convert.Length
            Group(gn).ObjectNameNum = n
            Group(gn).ObjectNameList = NameList.Clone

            Dim objlist() As Integer = GridReverseObjCode(gn)
            For i As Integer = 0 To objlist.Length - 1
                With Obj(objlist(i))
                    For j As Integer = 0 To .NameTimeStac.Length - 1
                        Dim nt As clsMapData.Object_NameTimeStac_Data = .NameTimeStac(j).Clone
                        ReDim .NameTimeStac(j).NamesList(n - 1)
                        For k As Integer = 0 To n - 1
                            If Convert(k) = -1 Then
                            Else
                                .NameTimeStac(j).NamesList(k) = nt.NamesList(Convert(k))
                            End If
                        Next
                    Next
                End With
            Next
            setGridLayer(objlist, gn)
            KtGrid.Refresh()
        End If
        form.Dispose()
    End Sub
    Private Sub btnBefore_Click(sender As Object, e As EventArgs) Handles btnBefore.Click

        KtGrid.FindRev(SearchSTR, KTGISUserControl.KTGISGrid.enmMatchingMode.PartialtMatching)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        KtGrid.Find(SearchSTR, KTGISUserControl.KTGISGrid.enmMatchingMode.PartialtMatching)
    End Sub
    Private Sub txtObjNameSearch_TextChanged(sender As Object, e As EventArgs) Handles txtObjNameSearch.TextChanged
        SearchSTR = txtObjNameSearch.Text
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ObjectTimeNameEdit", Me)

    End Sub
End Class