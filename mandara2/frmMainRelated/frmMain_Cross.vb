Public Class frmMain_Cross
    Private Enum enmAddMode
        ObjNumber = 0
        ObjectList = 1
        HorizontalData = 2
        Data = 3
    End Enum
    Private Enum enmAddDataMode
        sum = 0
        Average = 1
        Standard = 2
        ObjectNumber = 3
        Value = 4
    End Enum
    Dim CloseCancelF As Boolean
    Dim attr As clsAttrData
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
    Public Overloads Function ShowDialog(ByRef _attr As clsAttrData) As Windows.Forms.DialogResult
        attr = _attr
        attr.Set_LayerName_to(cboLayer, attr.TotalData.LV1.SelectedLayer, True, True, True, True, True, True)
        rbObjNumber.Checked = True

        Return Me.ShowDialog

    End Function
    Private Sub cboLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayer.SelectedIndexChanged
        Dim L As Integer = cboLayer.SelectedIndex
        attr.Set_DataTitle_to_ListBox(lbOriginData, L, True, True, True, False)
        lbOriginData.SelectedIndex = 0
        attr.Set_DataTitle_to_cboBox(cboZData, L, 0, True, True, True, False)
        attr.Set_DataTitle_to_cboBox(cboData, L, 0, True, True, True, True)
        lbHorizonalData.Items.Clear()
        lbVerticalData.Items.Clear()
        If attr.Check_Condition_UMU(L) = False And attr.TotalData.ViewStyle.ObjectLimitationF = False Then
            chkConditionUse.Enabled = False
            chkConditionUse.Checked = False
        End If
        cboZData.Items.Insert(0, "なし")
        cboZData.SelectedIndex = 0
    End Sub

    Private Sub rbObjNumber_CheckedChanged(sender As Object, e As EventArgs) Handles rbObjNumber.CheckedChanged,
                        rbObjectList.CheckedChanged, rbHorizontalData.CheckedChanged, rbData.CheckedChanged
        Dim f2 As Boolean = False
        Dim f3 As Boolean = False
        Select Case True
            Case rbHorizontalData.Checked
                f2 = True
            Case rbData.Checked
                f3 = True
        End Select
        gbHorizonalData.Visible = f2
        gbData.Visible = f3
    End Sub

    Private Sub btnVerticalIn_Click(sender As Object, e As EventArgs) Handles btnVerticalIn.Click, btnHorizonalIn.Click
        Dim Lb As ListBoxEx
        If sender.name = "btnVerticalIn" Then
            Lb = lbVerticalData
        Else
            Lb = lbHorizonalData
        End If
        For i As Integer = 0 To lbOriginData.Items.Count - 1
            If lbOriginData.GetSelected(i) = True Then
                Dim o_t = lbOriginData.Items(i)
                Dim f As Boolean = True
                For j As Integer = 0 To Lb.Items.Count - 1
                    If o_t = Lb.Items(j) Then
                        f = False
                        Exit For
                    End If
                Next
                If f = True Then
                    Lb.Items.Add(o_t)
                End If
            End If
        Next
    End Sub

    Private Sub btnVerticalOut_Click(sender As Object, e As EventArgs) Handles btnVerticalOut.Click, btnHorizonalOut.Click
        Dim Lb As ListBoxEx
        If sender.name = "btnVerticalOut" Then
            Lb = lbVerticalData
        Else
            Lb = lbHorizonalData
        End If

        With Lb
            For i As Integer = .Items.Count - 1 To 0 Step -1
                If .GetSelected(i) = True Then
                    .Items.RemoveAt(i)
                End If
            Next
        End With
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

 
        Dim Layernum As Integer = cboLayer.SelectedIndex

        Dim Add_Mode As enmAddMode
        Select Case True
            Case rbObjNumber.Checked
                Add_Mode = enmAddMode.ObjNumber
            Case rbObjectList.Checked
                Add_Mode = enmAddMode.ObjectList
            Case rbHorizontalData.Checked
                Add_Mode = enmAddMode.HorizontalData
            Case rbData.Checked
                Add_Mode = enmAddMode.Data
        End Select
        Dim Data_Xn As Integer = lbHorizonalData.Items.Count
        Dim Data_Yn As Integer = lbVerticalData.Items.Count
        If Data_Yn = 0 Then
            MsgBox("縦方向のデータ項目を選択してください。", MsgBoxStyle.Exclamation)
            Return
        End If
        If Data_Xn = 0 And Add_Mode = enmAddMode.Data Then
            MsgBox("横方向のデータ項目を選択するか、横方向データ項目集計を選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim Add_Data_Mode As enmAddDataMode
        If Add_Mode = enmAddMode.HorizontalData Then
            Select Case True
                Case rbHSum.Checked
                    Add_Data_Mode = enmAddDataMode.sum
                Case rbHAverage.Checked
                    Add_Data_Mode = enmAddDataMode.Average
                Case rbHStandard.Checked
                    Add_Data_Mode = enmAddDataMode.Standard
                Case rbHObjectNumber.Checked
                    Add_Data_Mode = enmAddDataMode.ObjectNumber
            End Select
        End If

        Dim Add_Data As Integer
        If Add_Mode = enmAddMode.Data Then
            Add_Data = cboData.SelectedIndex
            Select Case True
                Case rbDSum.Checked
                    Add_Data_Mode = enmAddDataMode.sum
                Case rbDAverage.Checked
                    Add_Data_Mode = enmAddDataMode.Average
                Case rbDStandard.Checked
                    Add_Data_Mode = enmAddDataMode.Standard
                Case rbDobjectNumber.Checked
                    Add_Data_Mode = enmAddDataMode.ObjectNumber
                Case rbDValue.Checked
                    Add_Data_Mode = enmAddDataMode.Value
            End Select
            Dim dtype As enmAttDataType = attr.Get_DataType(Layernum, Add_Data)
            If (dtype = enmAttDataType.Category Or dtype = enmAttDataType.Strings) And Add_Data_Mode <> enmAddDataMode.Value And Add_Data_Mode <> enmAddDataMode.ObjectNumber Then
                MsgBox("集計するデータ項目は「データの数値」以外選択できません。。", MsgBoxStyle.Exclamation)
                Return
            End If
        End If

        If Data_Xn = 0 And Add_Mode = enmAddMode.HorizontalData Then
            MsgBox("横方向のデータ項目を選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim Data_Xnumber(Data_Xn) As Integer
        Dim Data_Ynumber(Data_Yn) As Integer
        Dim Data_XAccum(Data_Xn) As Integer
        Dim Data_YAccum(Data_Yn) As Integer

        For j As Integer = 0 To lbVerticalData.Items.Count - 1
            Dim a As String = lbVerticalData.Items(j)
            Dim k As Integer = InStr(a, ":")
            Data_Ynumber(j) = Val(Microsoft.VisualBasic.Left(a, k - 1)) - 1
        Next
        For j As Integer = 0 To lbHorizonalData.Items.Count - 1
            Dim a As String = lbHorizonalData.Items(j)
            Dim k As Integer = InStr(a, ":")
            Data_Xnumber(j) = Val(Microsoft.VisualBasic.Left(a, k - 1)) - 1
        Next

        Dim f As Boolean = True
        Dim emes As String = "横方向のデータ項目にカテゴリーデータが含まれています。" + vbCrLf
        If Add_Mode = enmAddMode.HorizontalData Then
            For i As Integer = 0 To Data_Xn - 1
                If attr.Get_DataType(Layernum, Data_Xnumber(i)) = enmAttDataType.Category Then
                    f = False
                    emes += attr.Get_DataTitle(Layernum, Data_Xnumber(i), False) + vbCrLf
                End If
            Next
        End If
        If f = False Then
            MsgBox(emes, MsgBoxStyle.Exclamation)
            Return
        End If

        Dim XKeiF As Boolean = False
        If Add_Mode <> enmAddMode.HorizontalData And Add_Mode <> enmAddMode.ObjectList Then
            If Add_Mode = enmAddMode.Data And Add_Data_Mode = enmAddDataMode.Value Then
            Else
                XKeiF = True
            End If
        End If

        Dim YKeiF As Boolean = False
        If Add_Mode <> enmAddMode.ObjectList Then
            If Add_Mode = enmAddMode.Data And Add_Data_Mode = enmAddDataMode.Value Then
            Else
                YKeiF = True
            End If
        End If

        Dim nX As Integer = 0
        If Data_Xn = 0 Then
            Data_Xn = 1
            Data_Xnumber(0) = -1
            nX = 2
        Else
            If Add_Mode = enmAddMode.HorizontalData Then
                nX = Data_Xn + 1
            Else
                nX = 1
                For i As Integer = 0 To Data_Xn - 1
                    Dim V_DVN As Integer
                    nX += attr.Get_Class_Div_Number(V_DVN, Layernum, Data_Xnumber(i))
                    If XKeiF = True Then
                        nX += 1
                    End If
                Next
            End If
        End If
        Dim nY As Integer = 1
        For i As Integer = 0 To Data_Yn - 1
            Dim V_DVN As Integer
            nY += attr.Get_Class_Div_Number(V_DVN, Layernum, Data_Ynumber(i))
            If YKeiF = True Then
                nY += 1
            End If
        Next

        Dim ZdataNum As Integer = cboZData.SelectedIndex - 1
        Dim nZ As Integer
        If ZdataNum <= -1 Then
            nZ = 1
        Else
            Dim V_DVN As Integer
            nZ = attr.Get_Class_Div_Number(V_DVN, Layernum, ZdataNum)
            If YKeiF = True Then
                nZ += 1
            End If
        End If



        Dim Cross_String(nX, nY, nZ) As String

        '横方向の区分の文字列設定
        For k As Integer = 0 To nZ - 1
            Dim n As Integer = 2
            For i As Integer = 0 To Data_Xn - 1
                If Data_Xnumber(0) = -1 Then
                    Data_XAccum(i) = 2
                Else
                    Data_XAccum(i) = n
                    If Add_Mode <> enmAddMode.HorizontalData Then
                        Cross_String(n, 0, k) = attr.Get_DataTitle(Layernum, Data_Xnumber(i), False)
                        Dim revF As Boolean = True
                        If attr.Get_DataType(Layernum, Data_Xnumber(i)) = enmAttDataType.Category Then
                            revF = False
                        End If
                        Dim Cross_S() As String = attr.Get_ClassDIV_Words(Layernum, Data_Xnumber(i), revF)
                        For j As Integer = 0 To UBound(Cross_S)
                            Cross_String(n, 1, k) = Cross_S(j)
                            n += 1
                        Next
                    Else
                        Cross_String(n, 0, k) = ""
                        Cross_String(n, 1, k) = attr.Get_DataTitle(Layernum, Data_Xnumber(i), False)
                        n += 1
                    End If
                End If
                If XKeiF = True Then
                    Cross_String(n, 1, k) = "計"
                    n += 1
                End If
            Next
        Next
        '縦方向の区分の文字列設定
        For k As Integer = 0 To nZ - 1
            Dim n As Integer
            If Data_Ynumber(0) = -1 Then
                Data_YAccum(0) = 2
            Else
                n = 2
            End If
            For i As Integer = 0 To Data_Yn - 1
                Data_YAccum(i) = n
                Cross_String(0, n, k) = attr.Get_DataTitle(Layernum, Data_Ynumber(i), False)
                Dim revF As Boolean = True
                If attr.Get_DataType(Layernum, Data_Ynumber(i)) = enmAttDataType.Category Then
                    revF = False
                End If
                Dim Cross_S() As String = attr.Get_ClassDIV_Words(Layernum, Data_Ynumber(i), revF)
                For j As Integer = 0 To UBound(Cross_S)
                    Cross_String(1, n, k) = Cross_S(j)
                    n += 1
                Next
                If YKeiF = True Then
                    Cross_String(1, n, k) = "計"
                    n += 1
                End If
            Next
        Next

        '集計表の一部を計算し，全体に挿入
        For i As Integer = 0 To Data_Yn - 1
            For j As Integer = 0 To Data_Xn - 1
                Dim Cross_S2(,,) As String = Cross_AddUp(Data_Xnumber(j), Data_Ynumber(i), ZdataNum, Layernum, Add_Mode, Add_Data, Add_Data_Mode)
                For k As Integer = 0 To UBound(Cross_S2, 1)
                    For k2 As Integer = 0 To UBound(Cross_S2, 2)
                        For k3 As Integer = 0 To UBound(Cross_S2, 3)
                            Cross_String(Data_XAccum(j) + k, Data_YAccum(i) + k2, k3) = Cross_S2(k, k2, k3)
                        Next
                    Next
                Next
            Next
        Next

        Dim ClipTx As String
        Select Case Add_Mode
            Case enmAddMode.ObjNumber
                ClipTx = "含まれるオブジェクト数"
            Case enmAddMode.ObjectList
                ClipTx = "含まれるオブジェクト一覧"
            Case enmAddMode.HorizontalData
                ClipTx = "横方向データ項目集計"
            Case enmAddMode.Data
                ClipTx = "データ項目集計"
        End Select
        ClipTx += vbCrLf
        If Add_Mode = enmAddMode.Data Then
            Dim a As String = attr.Get_DataTitle(Layernum, Add_Data, False)
            ClipTx += "集計データ項目" & vbTab & a$ & vbCrLf
            ClipTx += "集計内容" & vbTab & Add_Data_Mode_String(Add_Data_Mode) & vbCrLf
        ElseIf Add_Mode = enmAddMode.HorizontalData Then
            ClipTx += "集計内容" & vbTab & Add_Data_Mode_String(Add_Data_Mode) & vbCrLf
        End If

        Dim CrossNZ() As String
        If ZdataNum <> -1 Then
            Dim revF As Boolean = True
            If attr.Get_DataType(Layernum, ZdataNum) = enmAttDataType.Category Then
                revF = False
            End If
            CrossNZ = attr.Get_ClassDIV_Words(Layernum, ZdataNum, revF)
        End If

        For k As Integer = 0 To nZ - 1
            If ZdataNum <> -1 Then
                If k = nZ - 1 And YKeiF = True Then
                    ClipTx += "全体" & vbCrLf
                Else
                    ClipTx += attr.Get_DataTitle(Layernum, ZdataNum, False) & ":" & CrossNZ(k) & vbCrLf
                End If
            End If
            Dim b As String = ""
            For i As Integer = 0 To nY
                Dim a As String = ""
                For j As Integer = 0 To nX
                    a += Cross_String(j, i, k)
                    If j <> nX Then
                        a += vbTab
                    Else
                        a += vbCrLf
                    End If
                Next
                ClipTx += a
            Next
            If chkConditionUse.Checked = True Then
                ClipTx += attr.Get_Condition_Info(Layernum)
                ClipTx += attr.Get_Condition_Ok_Num_Info(Layernum)
            End If
        Next
        Clipboard.Clear()
        Clipboard.SetText(ClipTx)
        clsGeneric.Message(Me, "クロス集計", ClipTx)
    End Sub
    Private Function Add_Data_Mode_String(ByVal Add_Data_Mode As enmAddDataMode) As String
        Dim tx As String
        Select Case Add_Data_Mode
            Case enmAddDataMode.sum
                tx = "合計値"
            Case enmAddDataMode.Average
                tx = "平均値"
            Case enmAddDataMode.Standard
                tx = "標準偏差"
            Case enmAddDataMode.ObjectNumber
                tx = "オブジェクト数"
            Case enmAddDataMode.Value
                tx = "値"
        End Select
        Return tx
    End Function
    Private Function Cross_AddUp(ByVal XdataNum As Integer, ByVal YdataNum As Integer, ByVal ZdataNum As Integer, ByVal Layernum As Integer, _
        ByVal Add_Mode As enmAddMode, ByVal Add_Data As Integer, ByVal Add_Data_Mode As enmAddDataMode) As String(,,)



        Dim VY_DVN As Integer, VZ_DVN As Integer


        Dim AddYoko() As Double, Add2Yoko() As Double

        Dim KeiF As Boolean = False
        If Add_Mode <> enmAddMode.ObjectList Then
            If Add_Mode = enmAddMode.Data And Add_Data_Mode = enmAddDataMode.Value Then
            Else
                KeiF = True
            End If
        End If

        Dim DVNX As Integer
        Dim O_DVNX As Integer
        Dim VX_DVN As Integer
        If XdataNum = -1 Or Add_Mode = enmAddMode.HorizontalData Then
            DVNX = 1
            O_DVNX = 1
        Else
            DVNX = attr.Get_Class_Div_Number(VX_DVN, Layernum, XdataNum)
            O_DVNX = DVNX
            If KeiF = True Then
                DVNX += 1
            End If
        End If
        Dim O_DVNY As Integer
        Dim DVNY As Integer = attr.Get_Class_Div_Number(VY_DVN, Layernum, YdataNum)
        O_DVNY = DVNY
        If KeiF = True Then
            DVNY += 1
        End If

        Dim DVNZ As Integer
        If ZdataNum <= -1 Then
            DVNZ = 1
        Else
            DVNZ = attr.Get_Class_Div_Number(VZ_DVN, Layernum, ZdataNum)
        End If

        Dim freq(DVNX - 1, DVNY - 1, DVNZ) As Integer
        Dim w(DVNX - 1, DVNY - 1, DVNZ) As String
        Dim Add(,,) As Double
        Dim Add2(,,) As Double
        If Add_Mode = enmAddMode.Data Or Add_Mode = enmAddMode.HorizontalData Then
            If Add_Data_Mode = enmAddDataMode.sum Or Add_Data_Mode = enmAddDataMode.Average Or Add_Data_Mode = enmAddDataMode.Standard Then
                ReDim Add(DVNX, DVNY, DVNZ)
                ReDim Add2(DVNX, DVNY, DVNZ)
            End If
        End If

        Dim DtatTypeX As enmAttDataType
        Dim DtatTypeY As enmAttDataType = attr.Get_DataType(Layernum, YdataNum)
        Dim DtatTypeZ As enmAttDataType

        Dim Category_Array_Y() As Integer = attr.Get_Categoly(Layernum, YdataNum)
        Dim Category_Array_X() As Integer
        Dim Category_Array_Z() As Integer
        If XdataNum <> -1 And Add_Mode <> enmAddMode.HorizontalData Then
            Category_Array_X = attr.Get_Categoly(Layernum, XdataNum)
            DtatTypeX = attr.Get_DataType(Layernum, XdataNum)
        End If
        If ZdataNum >= 0 Then
            Category_Array_Z = attr.Get_Categoly(Layernum, ZdataNum)
            DtatTypeZ = attr.Get_DataType(Layernum, ZdataNum)
        End If

        For i As Integer = 0 To attr.Get_ObjectNum(Layernum) - 1
            Dim f As Boolean
            If chkConditionUse.Checked = True Then
                If attr.Check_Condition(Layernum, i) = True Then
                    f = True
                Else
                    f = False
                End If
            Else
                f = True
            End If

            If f = True Then
                Dim cx2 As Integer
                If XdataNum = -1 Or Add_Mode = enmAddMode.HorizontalData Then
                    cx2 = 0
                Else
                    Dim cx As Integer = Category_Array_X(i)
                    If cx = -1 Then
                        cx2 = O_DVNX - 1
                    Else
                        If DtatTypeX = enmAttDataType.Category Then
                            cx2 = cx
                        Else
                            cx2 = VX_DVN - 1 - cx
                        End If
                    End If
                End If

                Dim cy As Integer = Category_Array_Y(i)
                Dim cy2 As Integer
                If cy = -1 Then
                    cy2 = O_DVNY - 1
                Else
                    If DtatTypeY = enmAttDataType.Category Then
                        cy2 = cy
                    Else
                        cy2 = VY_DVN - 1 - cy
                    End If
                End If

                Dim cz2 As Integer
                If ZdataNum <= -1 Then
                    cz2 = 0
                Else
                    Dim cz As Integer = Category_Array_Z(i)
                    If cz = -1 Then
                        cz2 = DVNZ - 1
                    Else
                        If DtatTypeZ = enmAttDataType.Category Then
                            cz2 = cz
                        Else
                            cz2 = VZ_DVN - 1 - cz
                        End If
                    End If
                End If

                Select Case Add_Mode
                    Case enmAddMode.ObjNumber
                        freq(cx2, cy2, cz2) += 1
                        freq(cx2, DVNY - 1, cz2) += 1
                        If XdataNum <> -1 Then
                            freq(DVNX - 1, cy2, cz2) += 1
                            freq(DVNX - 1, DVNY - 1, cz2) += 1
                            freq(DVNX - 1, cy2, DVNZ) += 1
                            freq(DVNX - 1, DVNY - 1, DVNZ) += 1
                        End If
                        freq(cx2, cy2, DVNZ) += 1
                        freq(cx2, DVNY - 1, DVNZ) += 1
                    Case enmAddMode.ObjectList
                        If w(cx2, cy2, cz2) <> "" Then
                            w(cx2, cy2, cz2) += "/"
                        End If
                        w(cx2, cy2, cz2) += attr.Get_KenObjName(Layernum, i)
                    Case enmAddMode.HorizontalData
                        If attr.Check_Missing_Value(Layernum, XdataNum, i) = False Then
                            freq(cx2, cy2, cz2) += 1
                            freq(cx2, DVNY - 1, cz2) += 1
                            freq(cx2, cy2, DVNZ) += 1
                            freq(cx2, DVNY - 1, DVNZ) += 1
                            If Add_Data_Mode <> enmAddDataMode.ObjectNumber Then
                                Dim V As Double = Val(attr.Get_Data_Value(Layernum, XdataNum, i, ""))
                                Add(cx2, cy2, cz2) += V
                                Add(cx2, DVNY - 1, cz2) += V
                                Add(cx2, cy2, DVNZ) += V
                                Add(cx2, DVNY - 1, DVNZ) += V
                                Add2(cx2, cy2, cz2) += V ^ 2
                                Add2(cx2, DVNY - 1, cz2) += V ^ 2
                                Add2(cx2, cy2, DVNZ) += V ^ 2
                                Add2(cx2, DVNY - 1, DVNZ) += V ^ 2
                            End If
                        End If
                    Case enmAddMode.Data
                        If attr.Check_Missing_Value(Layernum, Add_Data, i) = False Then
                            Dim VS As String = attr.Get_Data_Value(Layernum, Add_Data, i, "")
                            Select Case Add_Data_Mode
                                Case enmAddDataMode.sum, enmAddDataMode.Average, enmAddDataMode.Standard, enmAddDataMode.ObjectNumber
                                    freq(cx2, cy2, cz2) += 1
                                    freq(cx2, DVNY - 1, cz2) += 1
                                    freq(DVNX - 1, cy2, cz2) += 1
                                    freq(DVNX - 1, DVNY - 1, cz2) += 1
                                    freq(cx2, cy2, DVNZ) += 1
                                    freq(cx2, DVNY - 1, DVNZ) += 1
                                    freq(DVNX - 1, cy2, DVNZ) += 1
                                    freq(DVNX - 1, DVNY - 1, DVNZ) += 1
                                    If Add_Data_Mode <> enmAddDataMode.ObjectNumber Then
                                        Dim V As Double = Val(VS)
                                        Add(cx2, cy2, cz2) += V
                                        Add(DVNX - 1, cy2, cz2) += V
                                        Add(cx2, DVNY - 1, cz2) += V
                                        Add(DVNX - 1, DVNY - 1, cz2) += V
                                        Add(cx2, cy2, DVNZ) += V
                                        Add(DVNX - 1, cy2, DVNZ) += V
                                        Add(cx2, DVNY - 1, DVNZ) += V
                                        Add(DVNX - 1, DVNY - 1, DVNZ) += V
                                        Add2(cx2, cy2, cz2) += V ^ 2
                                        Add2(DVNX - 1, cy2, cz2) += V ^ 2
                                        Add2(cx2, DVNY - 1, cz2) += V ^ 2
                                        Add2(DVNX - 1, DVNY - 1, cz2) += V ^ 2
                                        Add2(cx2, cy2, DVNZ) += V ^ 2
                                        Add2(DVNX - 1, cy2, DVNZ) += V ^ 2
                                        Add2(cx2, DVNY - 1, DVNZ) += V ^ 2
                                        Add2(DVNX - 1, DVNY - 1, DVNZ) += V ^ 2
                                    End If
                                Case enmAddDataMode.Value
                                    If w(cx2, cy2, cz2) <> "" Then
                                        w(cx2, cy2, cz2) += "/"
                                    End If
                                    w(cx2, cy2, cz2) += VS
                            End Select
                        End If
                End Select
            End If
        Next

        For i As Integer = 0 To DVNX - 1
            For j As Integer = 0 To DVNY - 1
                For k As Integer = 0 To DVNZ
                    Select Case Add_Mode
                        Case enmAddMode.ObjNumber
                            w(i, j, k) = CStr(freq(i, j, k))
                        Case enmAddMode.HorizontalData, enmAddMode.Data
                            Select Case Add_Data_Mode
                                Case enmAddDataMode.sum
                                    If freq(i, j, k) <> 0 Then
                                        w(i, j, k) = CStr(Add(i, j, k))
                                    End If
                                Case enmAddDataMode.Average
                                    If freq(i, j, k) <> 0 Then
                                        Dim v As Double = Add(i, j, k) / freq(i, j, k)
                                        w(i, j, k) = CStr(Val(clsGeneric.Figure_Using(v, attr.LayerData(Layernum).atrData.Data(XdataNum).Statistics.AfterDecimalNum + 1)))
                                    End If
                                Case enmAddDataMode.Standard
                                    If freq(i, j, k) <> 0 Then
                                        Dim v As Double = Math.Sqrt(Add2(i, j, k) / freq(i, j, k) - (Add(i, j, k) / freq(i, j, k)) ^ 2)
                                        w(i, j, k) = CStr(Val(clsGeneric.Figure_Using(v, attr.LayerData(Layernum).atrData.Data(XdataNum).Statistics.AfterDecimalNum + 1)))
                                    End If
                                Case enmAddDataMode.ObjectNumber
                                    w(i, j, k) = CStr(freq(i, j, k))
                                Case enmAddDataMode.Value
                            End Select
                    End Select
                Next
            Next
        Next
        Return w
    End Function


    Private Sub frmMain_Cross_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_Cross", Me)

    End Sub

    Private Sub gbData_Enter(sender As Object, e As EventArgs) Handles gbData.Enter

    End Sub
End Class