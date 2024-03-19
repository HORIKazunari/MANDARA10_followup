Public Class frmMED_DefAttData
    Dim cbx As Integer
    Dim cby As Integer
    Dim cbl As Integer
    Dim newMapData As New clsMapData
    Dim CloseCancelF As Boolean
    Dim SearchSTR As String
    Public Overloads Function ShowDialog(ByRef MData As clsMapData) As Windows.Forms.DialogResult


        newMapData = MData.Clone
        Dim OBKNum() As Integer = newMapData.Get_ObjectKind_Use_Number
        Me.Width = Screen.GetBounds(Me).Width * 0.8
        Me.Height = Screen.GetBounds(Me).Height * 0.8
        clsGeneric.CenterForm(Me)


        'オブジェクトグループごとに初期属性データ項目をグリッド
        KtGrid.init("オブジェクトグループ", "オブジェクト", "初期属性データ", 2, 1, 6, 3, True, True, True, False, True, False, True, False, True, False)
        With newMapData
            For i As Integer = 0 To .Map.OBKNum - 1
                With .ObjectKind(i)
                    KtGrid.AddLayer(.Name, i, Math.Max(1, .DefTimeAttDataNum), Math.Max(OBKNum(i), 1))
                    For j As Integer = 0 To .DefTimeAttDataNum - 1
                        With .DefTimeAttSTC(j).attData
                            KtGrid.FixedYSData(i, j, 2) = clsGeneric.ConvertMissingValueBoolString(.MissingF)
                            KtGrid.FixedYSData(i, j, 3) = .Title
                            KtGrid.FixedYSData(i, j, 4) = .Unit
                            KtGrid.FixedYSData(i, j, 5) = .Note
                        End With
                    Next
                    clsGeneric.Set_First_GridCellWidthHeight(KtGrid, i)
                    clsGeneric.Check_DataKind_and_Allignment(KtGrid, i, clsAttrData.enmLayerType.Normal)
                End With
            Next

            'オブジェクトの初期属性をグリッドに設定
            Dim ObjGridAdd(.Map.OBKNum - 1) As Integer
            For i As Integer = 0 To .Map.Kend - 1
                With .MPObj(i)
                    KtGrid.FixedXSData(.Kind, 1, ObjGridAdd(.Kind)) = .NameTimeSTC(0).connectNames
                    For j As Integer = 0 To newMapData.ObjectKind(.Kind).DefTimeAttDataNum - 1
                        KtGrid.GridData(.Kind, j, ObjGridAdd(.Kind)) = .DefTimeAttValue(j).Data(0).Value
                    Next
                    ObjGridAdd(.Kind) += 1
                End With
            Next
            KtGrid.Show()

        End With

        With cboAttDataType
            .Items.Clear()
            .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.Normal))
            .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.Category))
            .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.Strings))
            .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.URL))
            .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.URL_Name))
            .Parent = SplitContainer1.Panel2
            .Visible = False
        End With
        With cboMissingValue
            .Items.Clear()
            .Items.Add(clsGeneric.ConvertMissingValueBoolString(True))
            .Items.Add(clsGeneric.ConvertMissingValueBoolString(False))
            .Parent = SplitContainer1.Panel2
            .Visible = False
        End With

        Return Me.ShowDialog()
    End Function
    Public Function getResult() As clsMapData
        'データ項目名の設定
        With newMapData
            For i As Integer = 0 To .Map.OBKNum - 1
                With .ObjectKind(i)
                    .DefTimeAttDataNum = 0
                    ReDim .DefTimeAttSTC(KtGrid.Xsize(i) - 1)
                    For j As Integer = 0 To KtGrid.Xsize(i) - 1
                        If KtGrid.FixedYSData(i, j, 3) <> "" Then
                            With .DefTimeAttSTC(.DefTimeAttDataNum).attData
                                .Title = KtGrid.FixedYSData(i, j, 3)
                                .Unit = KtGrid.FixedYSData(i, j, 4)
                                .Note = KtGrid.FixedYSData(i, j, 5)
                                .MissingF = clsGeneric.ConvertMissingValueBoolString(KtGrid.FixedYSData(i, j, 2))
                            End With
                            .DefTimeAttDataNum += 1
                        End If
                    Next
                    If .DefTimeAttDataNum > 0 And .DefTimeAttDataNum <> KtGrid.Xsize(i) Then
                        ReDim Preserve .DefTimeAttSTC(.DefTimeAttDataNum - 1)
                    End If
                End With
            Next


            Dim ObjGridAdd(.Map.OBKNum - 1) As Integer
            For i As Integer = 0 To .Map.Kend - 1
                With .MPObj(i)
                    Dim defN As Integer = newMapData.ObjectKind(.Kind).DefTimeAttDataNum
                    If defN > 0 Then
                        ReDim .DefTimeAttValue(defN - 1)
                        Dim n As Integer = 0
                        For j As Integer = 0 To KtGrid.Xsize(.Kind) - 1
                            If KtGrid.FixedYSData(.Kind, j, 3) <> "" Then
                                ReDim .DefTimeAttValue(n).Data(0)
                                .DefTimeAttValue(n).Data(0).Value = KtGrid.GridData(.Kind, j, ObjGridAdd(.Kind))
                                n += 1
                            End If
                        Next
                        ObjGridAdd(.Kind) += 1
                    Else
                        Erase .DefTimeAttValue
                    End If
                End With
            Next
            Return newMapData
        End With
    End Function
    Private Sub KtGrid_Change_FixedYS() Handles KtGrid.Change_FixedYS
        clsGeneric.Check_DataKind_and_Allignment(KtGrid, KtGrid.Layer, clsAttrData.enmLayerType.Normal)
        KtGrid.Refresh()
    End Sub

    Private Sub KtGrid_Click_FixedYS2(Layer As Integer, X As Integer, Y As Integer, Value As String, Top As Single, Left As Single, Width As Single, Height As Single) Handles KtGrid.Click_FixedYS2
        cbx = X
        cby = Y
        cbl = Layer
        Select Case Y
            Case 1
                With cboAttDataType
                    .Left = Left
                    .Top = Top
                    .Width = Width
                    .Height = Height
                    .BringToFront()
                    .Visible = True
                    .Text = KtGrid.FixedYSData(cbl, cbx, cby)
                    .Focus()
                End With
            Case 2
                With cboMissingValue
                    .Left = Left
                    .Top = Top
                    .Width = Width
                    .Height = Height
                    .BringToFront()
                    .Text = KtGrid.FixedYSData(cbl, cbx, cby)
                    .Visible = True
                    .Focus()
                End With

        End Select
    End Sub

    Private Sub KtGrid_Load(sender As Object, e As EventArgs) Handles KtGrid.Load

    End Sub

    Private Sub cboAttDataType_Enter(sender As Object, e As EventArgs) Handles cboAttDataType.Enter, cboMissingValue.Enter
        sender.DroppedDown = True
    End Sub

    Private Sub cboAttDataType_LostFocus(sender As Object, e As EventArgs) Handles cboAttDataType.LostFocus
        cboAttDataType.Visible = False
        KtGrid.FixedYSData(cbl, cbx, cby) = cboAttDataType.Text
        Dim dtype As enmAttDataType = clsGeneric.ConvertAttDataTypeString(cboAttDataType.Text)
        Dim Title As String = KtGrid.FixedYSData(cbl, cbx, 3)
        Dim Unit As String = KtGrid.FixedYSData(cbl, cbx, 4)
        clsGeneric.SetTitleUnit_from_AttDataType(dtype, Title, Unit)
        KtGrid.FixedYSData(cbl, cbx, 3) = Title
        KtGrid.FixedYSData(cbl, cbx, 4) = Unit
        clsGeneric.Check_DataKind_and_Allignment(KtGrid, KtGrid.Layer, clsAttrData.enmLayerType.Normal)

        KtGrid.Refresh()

    End Sub

    Private Sub cboMissingValue_LostFocus(sender As Object, e As EventArgs) Handles cboMissingValue.LostFocus
        cboMissingValue.Visible = False
        KtGrid.FixedYSData(cbl, cbx, cby) = cboMissingValue.Text
        KtGrid.Refresh()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'データが入力してあり、タイトルがない場合をチェック
        Dim tx As String = ""
        For i As Integer = 0 To KtGrid.LayerMax - 1
            For j As Integer = 0 To KtGrid.Xsize(i) - 1
                Dim Title = KtGrid.FixedYSData(i, j, 3)
                If Title = "" Then
                    For k As Integer = 0 To KtGrid.Ysize(i) - 1
                        If KtGrid.GridData(i, j, k) <> "" Then
                            tx += KtGrid.LayerName(i) + ":" + (j + 1).ToString + "列" + vbCrLf
                        End If
                    Next
                End If
            Next
        Next
        If tx <> "" Then
            If MsgBox("タイトルが入力されていないデータがあります。初期属性データには登録されません。", MsgBoxStyle.OkOnly) <> MsgBoxResult.Ok Then
                clsGeneric.Message(frmMapEditor, "タイトルがないデータ", tx, True, True)
                CloseCancelF = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub frmMED_DefAttData_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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



    Private Sub btnBefore_Click(sender As Object, e As EventArgs) Handles btnBefore.Click
        SearchSTR = txtSearch.Text
        KtGrid.FindRev(SearchSTR, KTGISUserControl.KTGISGrid.enmMatchingMode.PartialtMatching)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        SearchSTR = txtSearch.Text
        KtGrid.Find(SearchSTR, KTGISUserControl.KTGISGrid.enmMatchingMode.PartialtMatching)
    End Sub

    Private Sub btnGetCenterPoint_Click(sender As Object, e As EventArgs) Handles btnGetCenterPoint.Click

 
        Dim OBGNum As Integer = KtGrid.Layer

        Dim DNum As Integer = KtGrid.Xsize(OBGNum)
        If DNum = 1 And KtGrid.FixedYSData(OBGNum, 0, 3) = "" And KtGrid.FixedYSData(OBGNum, 0, 4) = "" Then
            Dim f As Boolean = True
            For i As Integer = 0 To KtGrid.Ysize(OBGNum) - 1
                If KtGrid.GridData(OBGNum, 0, i) <> "" Then
                    f = False
                    Exit For
                End If
            Next
            If f = True Then
                DNum = 0
            End If
        End If

        KtGrid.AddDataItem(OBGNum, DNum, 1)
        If DNum <> 0 Then
            KtGrid.AddDataItem(OBGNum, DNum, 1)
        End If

        Dim TTL1 As String, TTL2 As String, UNT As String
        Select Case newMapData.Map.Zahyo.Mode
            Case enmZahyo_mode_info.Zahyo_No_Mode
                TTL1 = "代表点Ｘ"
                TTL2 = "代表点Ｙ"
                UNT = ""
            Case enmZahyo_mode_info.Zahyo_Ido_Keido
                TTL1 = "代表点経度"
                TTL2 = "代表点緯度"
                UNT = "度"
            Case enmZahyo_mode_info.Zahyo_HeimenTyokkaku
                TTL1 = "代表点Ｙ"
                TTL2 = "代表点Ｘ"
                UNT = ""
        End Select


        With KtGrid
            .FixedYSData(OBGNum, DNum, 2) = clsGeneric.ConvertMissingValueBoolString(True)
            .FixedYSData(OBGNum, DNum + 1, 2) = clsGeneric.ConvertMissingValueBoolString(True)
            .FixedYSData(OBGNum, DNum, 3) = TTL1
            .FixedYSData(OBGNum, DNum + 1, 3) = TTL2
            .FixedYSData(OBGNum, DNum, 4) = UNT
            .FixedYSData(OBGNum, DNum + 1, 4) = UNT
            clsGeneric.Check_DataKind_and_Allignment(KtGrid, OBGNum, clsAttrData.enmLayerType.Normal)
            Dim j As Integer = 0
            For i As Integer = 0 To newMapData.Map.Kend - 1
                If newMapData.MPObj(i).Kind = OBGNum Then
                    Dim OXY As PointF
                    Dim f As Boolean = newMapData.Get_Enable_CenterP(OXY.X, OXY.Y, newMapData.MPObj(i), clsTime.GetNullYMD)
                    Dim P As PointF
                    P = spatial.Get_Reverse_XY(OXY, newMapData.Map.Zahyo)
                    If f = True Then
                        .GridData(OBGNum, DNum, j) = P.X
                        .GridData(OBGNum, DNum + 1, j) = P.Y
                    Else
                        .GridData(OBGNum, DNum, j) = ""
                        .GridData(OBGNum, DNum + 1, j) = ""
                    End If
                    j += 1
                End If
            Next
            .Refresh()

        End With
        MsgBox("代表点を取得しました。")
    End Sub

    Private Sub btnGetArea_Click(sender As Object, e As EventArgs) Handles btnGetArea.Click

        Dim OBGNum As Integer = KtGrid.Layer
        If newMapData.ObjectKind(OBGNum).Shape <> enmShape.PolygonShape Then
            MsgBox("選択中のオブジェクトグループは面形状ではありません。", MsgBoxStyle.Exclamation)
            Exit Sub
        End If


        Dim DNum As Integer = KtGrid.Xsize(OBGNum)
        If DNum = 1 And KtGrid.FixedYSData(OBGNum, 0, 3) = "" And KtGrid.FixedYSData(OBGNum, 0, 4) = "" Then
            Dim f As Boolean = True
            For i As Integer = 0 To KtGrid.Ysize(OBGNum) - 1
                If KtGrid.GridData(OBGNum, 0, i) <> "" Then
                    f = False
                    Exit For
                End If
            Next
            If f = True Then
                DNum = 0
            End If
        End If

        With KtGrid
            If DNum <> 0 Then
                .AddDataItem(OBGNum, DNum, 1)
            End If

            .FixedYSData(OBGNum, DNum, 3) = "面積"
            .FixedYSData(OBGNum, DNum, 2) = clsGeneric.ConvertMissingValueBoolString(True)

            .FixedYSData(OBGNum, DNum, 4) = clsGeneric.getScaleUnitAreaStrings(newMapData.Map.SCL_U)
            clsGeneric.Check_DataKind_and_Allignment(KtGrid, OBGNum, clsAttrData.enmLayerType.Normal)
            Dim j As Integer = 0
            For i As Integer = 0 To newMapData.Map.Kend - 1
                If newMapData.MPObj(i).Kind = OBGNum Then
                    Dim gx As Single, gy As Single
                    Dim m As Single = newMapData.Menseki(newMapData.MPObj(i), gx, gy, clsTime.GetNullYMD)
                    If m <> -1 Then
                        .GridData(OBGNum, DNum, j) = CDec(m)
                    Else
                        .GridData(OBGNum, DNum, j) = ""
                    End If
                    j += 1
                End If
            Next
            KtGrid.Refresh()
        End With
        MsgBox("面積を取得しました。")
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click

        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_DefAttData", Me)
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyData = Keys.Enter Then
            btnNext.PerformClick()
        End If
    End Sub
    ''' <summary>
    ''' テキストボックスでEnter押されたときにBeepが鳴らないようにする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtSearchKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter)  Then
            e.Handled = True
        End If
    End Sub
End Class