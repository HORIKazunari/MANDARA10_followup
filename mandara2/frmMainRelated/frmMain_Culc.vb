Public Class frmMain_Culc
    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData
    Dim LayerNum As Integer
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
    Public Overloads Sub ShowDialog(ByRef _attrData As clsAttrData)
        attrData = _attrData
        LayerNum = attrData.TotalData.LV1.SelectedLayer
        attrData.Set_DataTitle_to_cboBox(cboDensityData, LayerNum, 0, True, True, False, False)
        attrData.Set_DataTitle_to_cboBox(cboDenominatorData, LayerNum, 0, True, True, False, False)
        attrData.Set_DataTitle_to_cboBox(cbonumeratorData, LayerNum, 0, True, True, False, False)
        attrData.Set_DataTitle_to_cboBox(cboStartData, LayerNum, 0, True, True, False, False)
        attrData.Set_DataTitle_to_cboBox(cboEndData, LayerNum, 0, True, True, False, False)
        attrData.Set_DataTitle_to_cboBox(cboDif1, LayerNum, 0, True, True, False, False)
        attrData.Set_DataTitle_to_cboBox(cboDif2, LayerNum, 0, True, True, False, False)
        attrData.Set_DataTitle_to_ListBox(lbSumData, LayerNum, True, True, False, False)
        attrData.Set_DataTitle_to_cboBox(cboMulti1, LayerNum, 0, True, True, False, False)
        attrData.Set_DataTitle_to_cboBox(cboMulti2, LayerNum, 0, True, True, False, False)
        cboDif2.Items.Insert(0, "数値入力")
        cboMulti2.Items.Insert(0, "数値入力")
        cboDenominatorData.Items.Insert(0, "数値入力")
        cbonumeratorData.Items.Insert(0, "数値入力")
        Select Case attrData.LayerData(LayerNum).Shape
            Case enmShape.PolygonShape
                rbDensity.Enabled = True
            Case enmShape.LineShape
                rbDensity.Enabled = False
            Case Else
                rbDensity.Enabled = False
        End Select
        rbSum.Checked = True


        Me.ShowDialog()

    End Sub



    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim n As Integer = attrData.Get_ObjectNum(LayerNum)
        Dim Data_Val_STR(n - 1) As String
        Dim Title As String = ""

        Dim note As String = ""
        Dim MisF As Boolean = False
        Dim Unit As String = ""

        CloseCancelF = True
        Select Case True
            Case rbSum.Checked
                Dim seln As Integer = lbSumData.SelectedIndices.Count
                If seln = 0 Then
                    MsgBox("加算するデータを選択して下さい。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                Dim plusVal As Double = Val(txtPlusInput.Text)

                Dim sumv(n - 1) As Double
                Dim sumf(n - 1) As Boolean
                Title = ""
                For i As Integer = 0 To seln - 1
                    Dim dt As Integer = lbSumData.SelectedIndices(i)
                    Unit = attrData.Get_DataUnit(LayerNum, dt)
                    Title += attrData.Get_DataTitle(LayerNum, dt, False)
                    If i <> seln - 1 Then
                        Title += "＋"
                    End If
                    Dim v() As Double = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, dt)
                    Dim mis() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, dt)
                    For j As Integer = 0 To n - 1
                        If mis(j) = False Then
                            sumv(j) += v(j)
                            sumf(j) = True
                        End If
                    Next
                Next
                For i As Integer = 0 To n - 1
                    If sumf(i) = True Then
                        Data_Val_STR(i) = CStr(sumv(i) + plusVal)
                    Else
                        Data_Val_STR(i) = ""
                        MisF = True
                    End If
                Next
                If plusVal <> 0 Then
                    Title += "＋" + plusVal.ToString
                End If
                Title += "（和）"
                note = "各データ項目の和"
            Case rbDifference.Checked
                Dim dt1 As Integer = cboDif1.SelectedIndex
                Dim dt2 As Integer = cboDif2.SelectedIndex - 1
                If dt1 = -1 Or dt2 = -2 Then
                    MsgBox("データ項目を選択して下さい。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                Dim inputValue As Double = Val(txtMinusInput.Text)
                If dt2 = -1 Then
                    If inputValue = 0 Then
                        MsgBox("数値を入力して下さい。", MsgBoxStyle.Exclamation)
                        CloseCancelF = True
                        Return
                    End If
                End If
                Dim v1() As Double = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, dt1)
                Dim mis1() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, dt1)
                Dim v2() As Double
                Dim mis2() As Boolean
                setDataArray(LayerNum, dt2, inputValue, v2, mis2)

                For i As Integer = 0 To n - 1
                    If mis1(i) = True Or mis2(i) = True Then
                        Data_Val_STR(i) = ""
                        MisF = True
                    Else
                        Data_Val_STR(i) = CStr(v1(i) - v2(i))
                    End If
                Next
                Title = attrData.Get_DataTitle(LayerNum, dt1, False) + "－"
                Unit = attrData.Get_DataUnit(LayerNum, dt1)
                note = attrData.Get_DataTitle(LayerNum, dt1, False) + "から"
                If dt2 <> -1 Then
                    Title += attrData.Get_DataTitle(LayerNum, dt2, False) + "(差)"
                    If attrData.Get_DataUnit(LayerNum, dt1) <> attrData.Get_DataUnit(LayerNum, dt2) Then
                        Unit = ""
                    End If
                    note += attrData.Get_DataTitle(LayerNum, dt2, False) + "を引いた値。"
                Else
                    Title += inputValue.ToString + "(差)"
                    note += inputValue.ToString + "を引いた値。"
                End If
            Case rbMultipli.Checked
                Dim dt1 As Integer = cboMulti1.SelectedIndex
                Dim dt2 As Integer = cboMulti2.SelectedIndex - 1
                If dt1 = -1 Or dt2 = -2 Then
                    MsgBox("データ項目を選択して下さい。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                Dim inputValue As Double = Val(txtMultiInput.Text)
                If dt2 = -1 Then
                    If inputValue = 0 Then
                        MsgBox("数値を入力して下さい。", MsgBoxStyle.Exclamation)
                        CloseCancelF = True
                        Return
                    End If
                End If
                Dim v1() As Double = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, dt1)
                Dim mis1() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, dt1)
                Dim v2() As Double
                Dim mis2() As Boolean
                setDataArray(LayerNum, dt2, inputValue, v2, mis2)

                For i As Integer = 0 To n - 1
                    If mis1(i) = True Or mis2(i) = True Then
                        Data_Val_STR(i) = ""
                        MisF = True
                    Else
                        Data_Val_STR(i) = CStr(CDbl(v1(i) * v2(i)))
                    End If
                Next
                Title = attrData.Get_DataTitle(LayerNum, dt1, False) + "×"
                Unit = attrData.Get_DataUnit(LayerNum, dt1)
                note = attrData.Get_DataTitle(LayerNum, dt1, False) + "に"
                If dt2 <> -1 Then
                    Title += attrData.Get_DataTitle(LayerNum, dt2, False) + "(積)"
                    If attrData.Get_DataUnit(LayerNum, dt1) <> attrData.Get_DataUnit(LayerNum, dt2) Then
                        Unit = ""
                    End If
                    note += attrData.Get_DataTitle(LayerNum, dt2, False) + "をかけた値。"
                Else
                    Title += inputValue.ToString + "(差)"
                    note += inputValue.ToString + "をかけた値。"
                End If

            Case rbDensity.Checked
                Dim dt As Integer = cboDensityData.SelectedIndex
                If dt = -1 Then
                    MsgBox("データ項目を選択して下さい。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                Dim v() As Double = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, dt)
                Dim mis() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, dt)
                For i As Integer = 0 To n - 1
                    Dim area As Single = attrData.GetObjMenseki(LayerNum, i)
                    If area = 0 Or mis(i) = True Then
                        Data_Val_STR(i) = ""
                        MisF = True
                    Else
                        Dim dv As Double = CDbl(v(i) / area)
                        Data_Val_STR(i) = CStr(Val(clsGeneric.Figure_Using(dv, attrData.LayerData(LayerNum).atrData.Data(dt).Statistics.AfterDecimalNum + 1)))
                    End If
                Next
                Title = attrData.Get_DataTitle(LayerNum, dt, False) + "（密度）"
                Unit = attrData.Get_DataUnit(LayerNum, dt) + "/" + clsGeneric.getScaleUnitAreaStrings(enmScaleUnit.kilometer)
                note = attrData.Get_DataTitle(LayerNum, dt, False) & "を面積で除した値。"
            Case rbRatio.Checked
                Dim dt1 As Integer = cbonumeratorData.SelectedIndex - 1
                Dim dt2 As Integer = cboDenominatorData.SelectedIndex - 1
                If dt1 = -2 Or dt2 = -2 Then
                    MsgBox("データ項目を選択して下さい。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                If dt1 = -1 And dt2 = -1 Then
                    MsgBox("数値同士ではできません。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                Dim inputValue1 As Double = Val(txtnumeratorData.Text)
                Dim inputValue2 As Double = Val(txtDenominatorDataBox.Text)

                If (dt1 = -1 And inputValue1 = 0) Or (dt2 = -1 And inputValue2 = 0) Then
                    MsgBox("数値を設定して下さい", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If


                Dim v1() As Double
                Dim mis1() As Boolean
                setDataArray(LayerNum, dt1, inputValue1, v1, mis1)

                Dim v2() As Double
                Dim mis2() As Boolean
                setDataArray(LayerNum, dt2, inputValue2, v2, mis2)

                Dim per As Boolean = chkPercent.Checked
                Dim keta As Integer
                With attrData.LayerData(LayerNum).atrData
                    Dim dt1AfterDecimalNum As Integer
                    Dim dt2AfterDecimalNum As Integer
                    Dim dt1BeforeDecimalNum As Integer
                    Dim dt2BeforeDecimalNum As Integer
                    If dt1 <> -1 Then
                        dt1AfterDecimalNum = .Data(dt1).Statistics.AfterDecimalNum
                        dt1BeforeDecimalNum = .Data(dt1).Statistics.BeforeDecimalNum
                    Else
                        clsGeneric.Figure_Arrange(inputValue1, dt1BeforeDecimalNum, dt1AfterDecimalNum)
                    End If
                    If dt2 <> -1 Then
                        dt2AfterDecimalNum = .Data(dt2).Statistics.AfterDecimalNum
                        dt2BeforeDecimalNum = .Data(dt2).Statistics.BeforeDecimalNum
                    Else
                        clsGeneric.Figure_Arrange(inputValue2, dt2BeforeDecimalNum, dt2AfterDecimalNum)
                    End If
                    keta = Math.Max(dt1AfterDecimalNum, dt2AfterDecimalNum) + 1
                    keta = Math.Max(keta, dt1BeforeDecimalNum)
                    keta = Math.Max(keta, dt2BeforeDecimalNum)
                End With
                For i As Integer = 0 To n - 1
                    Dim keta2 As Integer = keta
                    If mis1(i) = True Or mis2(i) = True Or v2(i) = 0 Then
                        Data_Val_STR(i) = ""
                        MisF = True
                    Else
                        Dim dv As Double = v1(i) / v2(i)
                        If per = True Then
                            dv *= 100
                        End If
                        If Math.Abs(dv) < 1 And v1(i) <> 0 Then
                            '1未満の場合は，0が続かなくなった箇所から桁数を数える
                            Dim vv As Double = Math.Abs(dv)
                            Dim nketa As Integer = 1
                            Do
                                vv = vv * 10
                                nketa += 1
                            Loop While vv < 1
                            keta2 += nketa - 1
                        End If
                        Data_Val_STR(i) = CStr(Val(clsGeneric.Figure_Using(dv, keta2)))
                    End If
                Next
                Unit = ""
                If chkPercent.Checked = True Then
                    Unit = "％"
                End If

                If dt1 <> -1 Then
                    Title = attrData.Get_DataTitle(LayerNum, dt1, False) + "÷"
                    note += attrData.Get_DataTitle(LayerNum, dt1, False) + "を"
                Else
                    Title += inputValue1.ToString + "÷"
                    note += inputValue1.ToString + "を"
                End If

                If dt2 <> -1 Then
                    Title += attrData.Get_DataTitle(LayerNum, dt2, False)
                    note += attrData.Get_DataTitle(LayerNum, dt2, False) + "で除した値。"
                Else
                    Title += inputValue2.ToString
                    note += inputValue2.ToString + "で除した値。"
                End If


            Case rbRateOfChange.Checked
                Dim dt1 As Integer = cboStartData.SelectedIndex
                Dim dt2 As Integer = cboEndData.SelectedIndex
                If dt1 = -1 Or dt2 = -1 Then
                    MsgBox("データ項目を選択して下さい。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
                Dim v1() As Double = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, dt1)
                Dim mis1() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, dt1)
                Dim v2() As Double = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, dt2)
                Dim mis2() As Boolean = attrData.Get_Missing_Value_DataArray(LayerNum, dt2)
                For i As Integer = 0 To n - 1
                    If mis1(i) = True Or mis2(i) = True Or v1(i) = 0 Then
                        Data_Val_STR(i) = ""
                        MisF = True
                    Else
                        Dim dv As Double = (v2(i) - v1(i)) / v1(i) * 100
                        Data_Val_STR(i) = CStr(Val(clsGeneric.Figure_Using(dv, 3)))
                    End If
                Next
                Title = "増減率(" + attrData.Get_DataTitle(LayerNum, dt1, False) + "～" + attrData.Get_DataTitle(LayerNum, dt2, False) + ")"
                Unit = "％"
                note = attrData.Get_DataTitle(LayerNum, dt1, False) + "から" + attrData.Get_DataTitle(LayerNum, dt2, False) + "までの増減率。"
        End Select
        Dim form As New frmTitleSettingsAddingData
        If form.ShowDialog(Title, Unit, note, True, "計算後の新しいデータ項目") = Windows.Forms.DialogResult.OK Then
            form.getResult(Title, Unit, note)
            attrData.Add_One_Data_Value(LayerNum, Title, Unit, note, Data_Val_STR, MisF)
            MsgBox("データ項目：" + Title + " を追加しました。")
        End If
        form.Dispose()
    End Sub
    ''' <summary>
    ''' 計算するデータを配列に設定
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="data"></param>
    ''' <param name="inputValue"></param>
    ''' <param name="dataArray"></param>
    ''' <param name="misArray"></param>
    ''' <remarks></remarks>
    Private Sub setDataArray(ByVal LayerNum As Integer, ByVal data As Integer, ByVal inputValue As Double, ByRef dataArray() As Double, ByRef misArray() As Boolean)
        If data <> -1 Then
            dataArray = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, data)
            misArray = attrData.Get_Missing_Value_DataArray(LayerNum, data)
        Else
            Dim objn As Integer = attrData.LayerData(LayerNum).atrObject.ObjectNum
            ReDim dataArray(objn - 1)
            ReDim misArray(objn - 1)
            clsGeneric.FillArray(dataArray, inputValue)
            clsGeneric.FillArray(misArray, False)
        End If

    End Sub
    Private Sub frmMain_Culc_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_Culc", Me)

    End Sub

    Private Sub txtMinusInput_LostFocus(sender As Object, e As EventArgs) Handles txtMinusInput.LostFocus, txtPlusInput.LostFocus, txtMinusInput.LostFocus, txtnumeratorData.LostFocus, txtDenominatorDataBox.LostFocus
        If sender.text <> "" Then
            sender.text = Val(sender.text)
        End If

    End Sub

    Private Sub cboDif1_Enter(sender As Object, e As EventArgs) Handles cboDif1.Enter, cboDif2.Enter, txtMinusInput.Enter
        rbDifference.Checked = True
    End Sub

    Private Sub cboMulti1_Enter(sender As Object, e As EventArgs) Handles cboMulti1.Enter, cboMulti2.Enter, txtMultiInput.Enter
        rbMultipli.Checked = True

    End Sub

    Private Sub lbSumData_Enter(sender As Object, e As EventArgs) Handles lbSumData.Enter, txtPlusInput.Enter
        rbSum.Checked = True

    End Sub

    Private Sub cboStartData_Enter(sender As Object, e As EventArgs) Handles cboStartData.Enter, cboEndData.Enter
        rbRateOfChange.Checked = True
    End Sub

    Private Sub cboDensityData_Enter(sender As Object, e As EventArgs) Handles cboDensityData.Enter
        rbDensity.Checked = True
    End Sub

    Private Sub cboDenominatorData_Enter(sender As Object, e As EventArgs) Handles cboDenominatorData.Enter, cbonumeratorData.Enter, chkPercent.Enter, txtDenominatorDataBox.Enter, txtnumeratorData.Enter
        rbRatio.Checked = True
    End Sub

End Class