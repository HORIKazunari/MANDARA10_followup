Public Class frmMain_ContourViewSettings
    Dim attData As clsAttrData
    Dim LayerNum As Integer
    Dim DataNum As Integer


    Dim LayerShape As enmShape
    Dim LastLPat As Line_Property




    Public Sub SetData(ByRef _attData As clsAttrData)
        Me.Tag = "OFF"
        attData = _attData
        LayerNum = attData.TotalData.LV1.SelectedLayer
        DataNum = attData.LayerData(LayerNum).atrData.SelectedIndex
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD
            cboContourDetail.SelectedIndex = .Detailed
            chkInPolygon.Checked = .Draw_in_Polygon_F
            chkSpline.Checked = .Spline_flag
            Select Case .Interval_Mode
                Case clsAttrData.enmContourIntervalMode.ClassPaint
                    rbClassPaintMode.Checked = True
                Case clsAttrData.enmContourIntervalMode.ClassHatch
                    rbClassHatchMode.Checked = True
                Case clsAttrData.enmContourIntervalMode.RegularInterval
                    rbRegularInterval.Checked = True
                Case clsAttrData.enmContourIntervalMode.SeparateSettings
                    rbSeparateSettings.Checked = True
            End Select
            IntervalModeGBVisible()
            With .Regular
                attData.Draw_Sample_LineBox(picPaitHatchLine, .Line_Pat)
                txtMinValue.Text = .bottom
                txtMaxValue.Text = .top
                txtIntervalValue.Text = .Interval
                txtThickMinValue.Text = .SP_Bottom
                txtThickMaxValue.Text = .SP_Top
                txtThickIntervalValue.Text = .SP_interval
                txtHeavyLineValue.Text = .EX_Value
                attData.Draw_Sample_LineBox(picNormalContour, .Line_Pat)
                attData.Draw_Sample_LineBox(picThickContour, .SP_Line_Pat)
                attData.Draw_Sample_LineBox(picHeavyContour, .EX_Line_Pat)
                chkHeavyLine.Checked = .EX_Value_Flag
            End With
            lbSepaContour.Items.Clear()
            For i As Integer = 0 To .IrregularNum - 1
                lbSepaContour.Items.Add(.Irregular(i).Value)
            Next
            If .IrregularNum > 0 Then
                lbSepaContour.SelectedIndex = 0
            End If
            SepaControlVisible()
            LastLPat = .Regular.Line_Pat
        End With

        Me.Tag = ""
    End Sub

    Private Sub frmMain_ContourViewSettings_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim frm As frmMain
            frm = CType(Me.Owner, frmMain)
            frm.btnDraw.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

 
    Private Sub frmMain_ContourViewSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gbSeparatelySettings.Location = gbPaintHatchContour.Location
        gbRegularInterval.Location = gbPaintHatchContour.Location
        Me.Width = gbRegularInterval.Left + gbRegularInterval.Width + 25
        With cboContourDetail.Items
            .Clear()
            .Add("非常に細かい")
            .Add("細かい")
            .Add("少し細かい")
            .Add("普通")
            .Add("粗い")
        End With
    End Sub

    Private Sub rbClassPaintMode_CheckedChanged(sender As Object, e As EventArgs) Handles rbClassPaintMode.CheckedChanged,
                rbClassHatchMode.CheckedChanged, rbRegularInterval.CheckedChanged, rbSeparateSettings.CheckedChanged
        If attData Is Nothing Then Return
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD
            Select Case True
                Case rbClassPaintMode.Checked
                    .Interval_Mode = clsAttrData.enmContourIntervalMode.ClassPaint
                Case rbClassHatchMode.Checked
                    .Interval_Mode = clsAttrData.enmContourIntervalMode.ClassHatch
                Case rbRegularInterval.Checked
                    .Interval_Mode = clsAttrData.enmContourIntervalMode.RegularInterval
                Case rbSeparateSettings.Checked
                    .Interval_Mode = clsAttrData.enmContourIntervalMode.SeparateSettings
            End Select
            IntervalModeGBVisible()
        End With
        CType(Me.Owner, frmMain).Check_Print_err()

    End Sub
    Private Sub IntervalModeGBVisible()
        Select Case attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD.Interval_Mode
            Case clsAttrData.enmContourIntervalMode.ClassPaint,clsAttrData.enmContourIntervalMode.ClassHatch
                gbPaintHatchContour.Visible = True
                gbRegularInterval.Visible = False
                gbSeparatelySettings.Visible = False
            Case clsAttrData.enmContourIntervalMode.RegularInterval
                gbPaintHatchContour.Visible = False
                gbRegularInterval.Visible = True
                gbSeparatelySettings.Visible = False
            Case clsAttrData.enmContourIntervalMode.SeparateSettings
                gbPaintHatchContour.Visible = False
                gbRegularInterval.Visible = False
                gbSeparatelySettings.Visible = True
        End Select
    End Sub
    Private Sub picPaitHatchLine_Click(sender As Object, e As EventArgs) Handles picPaitHatchLine.Click, picNormalContour.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD
            If attData.Select_Line_Pattern(.Regular.Line_Pat, True) = True Then
                attData.Draw_Sample_LineBox(picPaitHatchLine, .Regular.Line_Pat)
                attData.Draw_Sample_LineBox(picNormalContour, .Regular.Line_Pat)
            End If
        End With
    End Sub

    Private Sub picThickContour_Click(sender As Object, e As EventArgs) Handles picThickContour.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD
            attData.Select_Line_Pattern(picThickContour, .Regular.SP_Line_Pat, True)
        End With
    End Sub

    Private Sub picHeavyContour_Click(sender As Object, e As EventArgs) Handles picHeavyContour.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD
            attData.Select_Line_Pattern(picHeavyContour, .Regular.EX_Line_Pat, True)
        End With
    End Sub

    Private Sub chkHeavyLine_CheckedChanged(sender As Object, e As EventArgs) Handles chkHeavyLine.CheckedChanged
        Dim f As Boolean = chkHeavyLine.Checked
        attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD.Regular.EX_Value_Flag = f
    End Sub

    Private Sub lbSepaContour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbSepaContour.SelectedIndexChanged
        Dim n As Integer = lbSepaContour.SelectedIndex
        If n <> -1 Then
            With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD.Irregular(n)
                attData.Draw_Sample_LineBox(picSepaLinePat, .Line_Pat)
                txtSepaContour.Text = .Value
                SepaControlVisible()
            End With
        End If
    End Sub

    Private Sub btnAddContour_Click(sender As Object, e As EventArgs) Handles btnAddContour.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD

            Dim n As Integer = .IrregularNum
            ReDim Preserve .Irregular(n)
            With .Irregular(n)
                .Value = 0
                .Line_Pat = LastLPat
                lbSepaContour.Items.Add(.Value)
                lbSepaContour.SelectedIndex = n
            End With
            .IrregularNum += 1
            SepaControlVisible()
            txtSepaContour.Focus()
        End With
    End Sub

    Private Sub txtSepaContour_LostFocus(sender As Object, e As EventArgs) Handles txtSepaContour.LostFocus
        Dim n As Integer = lbSepaContour.SelectedIndex
        If n = -1 Then
            Return
        End If
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD
            Dim maxn As Integer = .IrregularNum
            With .Irregular(n)
                .Value = Val(txtSepaContour.Text)
                txtSepaContour.Text = .Value
                lbSepaContour.Items(n) = .Value
            End With
        End With
    End Sub



    Private Sub btnAllClear_Click(sender As Object, e As EventArgs) Handles btnAllClear.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD
            .IrregularNum = 0
            lbSepaContour.Items.Clear()
            SepaControlVisible()
        End With
    End Sub

    Private Sub picSepaLinePat_Click(sender As Object, e As EventArgs) Handles picSepaLinePat.Click
        Dim n As Integer = lbSepaContour.SelectedIndex
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD.Irregular(n)
            If attData.Select_Line_Pattern(picSepaLinePat, .Line_Pat, True) = True Then
                LastLPat = .Line_Pat
            End If
        End With

    End Sub

    Private Sub btnDeleteContour_Click(sender As Object, e As EventArgs) Handles btnDeleteContour.Click
        Dim n As Integer = lbSepaContour.SelectedIndex
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD
            For i As Integer = n To .IrregularNum - 2
                .Irregular(i) = .Irregular(i + 1)
            Next
            .IrregularNum -= 1
            lbSepaContour.Items.RemoveAt(n)
            SepaControlVisible()
            If .IrregularNum <> 0 Then
                If n <= .IrregularNum - 1 Then
                    lbSepaContour.SelectedIndex = n
                Else
                    lbSepaContour.SelectedIndex = n - 1
                End If
            End If
        End With
    End Sub
    Private Sub SepaControlVisible()
        Dim v As Boolean
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD
            v = (.IrregularNum <> 0)
        End With
        gbSelectedContour.Visible = v
        btnAllClear.Enabled = v
        bynAttangeSepaContour.Enabled = v
    End Sub
    Private Sub txValue_TextChanged(sender As Object, e As EventArgs) Handles txtMinValue.LostFocus, txtMaxValue.LostFocus,
                    txtIntervalValue.LostFocus, txtThickMinValue.LostFocus, txtThickMaxValue.LostFocus,
                    txtThickIntervalValue.LostFocus, txtHeavyLineValue.LostFocus

        Dim txt As TextBox = CType(sender, TextBox)
        Dim v As Double = Val(txt.Text)
        txt.Text = v
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD.Regular
            Select Case txt.Name
                Case "txtMinValue"
                    .bottom = v
                Case "txtMaxValue"
                    .top = v
                Case "txtIntervalValue"
                    .Interval = v
                Case "txtThickMinValue"
                    .SP_Bottom = v
                Case "txtThickMaxValue"
                    .SP_Top = v
                Case "txtThickIntervalValue"
                    .SP_interval = v
                Case "txtHeavyLineValue"
                    .EX_Value = v
            End Select
        End With
        CType(Me.Owner, frmMain).Check_Print_err()
    End Sub

    Private Sub cboContourDetail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboContourDetail.SelectedIndexChanged
        attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD.Detailed = cboContourDetail.SelectedIndex
    End Sub

    Private Sub chkInPolygon_CheckedChanged(sender As Object, e As EventArgs) Handles chkInPolygon.CheckedChanged
        attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD.Draw_in_Polygon_F = chkInPolygon.Checked
    End Sub

    Private Sub chkSpline_CheckedChanged(sender As Object, e As EventArgs) Handles chkSpline.CheckedChanged
        attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD.Spline_flag = chkSpline.Checked
    End Sub


    Private Sub bynAttangeSepaContour_Click(sender As Object, e As EventArgs) Handles bynAttangeSepaContour.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings.ContourMD
            Dim maxn As Integer = .IrregularNum
            If maxn > 0 Then
                Dim ss As New clsSortingSearch(VariantType.Double)
                Dim Lpat(maxn - 1) As clsAttrData.strContour_Data_Irregular_interval
                For i As Integer = 0 To maxn - 1
                    ss.Add(.Irregular(i).Value)
                    Lpat(i) = .Irregular(i)
                Next
                ss.AddEnd()
                For i As Integer = 0 To maxn - 1
                    Dim j As Integer = ss.DataPositionRev(i)
                    .Irregular(i) = Lpat(j)
                    lbSepaContour.Items(i) = .Irregular(i).Value
                Next
                lbSepaContour.SelectedIndex = 0
            End If
        End With
    End Sub


    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnClassValueSet_Click(sender As Object, e As EventArgs) Handles btnClassValueSet.Click
        With attData.LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings

            .ContourMD.IrregularNum = .Div_Num - 1
            ReDim .ContourMD.Irregular(.Div_Num - 2)
            lbSepaContour.Items.Clear()
            For i As Integer = 0 To .Div_Num - 2
                .ContourMD.Irregular(i).Value = .Class_Div(i).Value
                .ContourMD.Irregular(i).Line_Pat = LastLPat
                lbSepaContour.Items.Add(.Class_Div(i).Value)
            Next
            lbSepaContour.SelectedIndex = 0
            SepaControlVisible()
            txtSepaContour.Focus()
        End With
    End Sub


    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "contourMode")
    End Sub


End Class