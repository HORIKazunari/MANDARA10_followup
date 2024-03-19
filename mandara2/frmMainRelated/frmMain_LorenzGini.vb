Public Class frmMain_LorenzGini
    Dim attrData As clsAttrData
    Dim LayerNum As Integer
    Dim gSize As Integer = 300
    Dim gTop = 20
    Dim gLeft = 55
    Dim areaCulc() As Double
    Dim areaCulcMisF() As Boolean

    Public Overloads Sub ShowDialog(ByRef _attrData As clsAttrData)
        attrData = _attrData
        LayerNum = attrData.TotalData.LV1.SelectedLayer
        Dim items As String() = getDataTitleName()
        cboXData.Items.Clear()
        cboXData.Items.AddRange(items)
        rbNoX.Checked = True
        lbYData.Items.Clear()
        lbYData.Items.AddRange(items)
        lbYData.SelectedIndex = attrData.LayerData(LayerNum).atrData.SelectedIndex
        If attrData.LayerData(LayerNum).Shape <> enmShape.PolygonShape Then
            rbArea.Enabled = False
        Else
            rbArea.Checked = True
        End If
        If attrData.Check_Condition_UMU(LayerNum) = False And attrData.TotalData.ViewStyle.ObjectLimitationF = False Then
            chkConditionUse.Enabled = False
            chkConditionUse.Checked = False
        End If
        DrawGraph()
        Me.ShowDialog()
    End Sub

    Private Function getDataTitleName() As String()

        With attrData.LayerData(LayerNum).atrData
            Dim n As Integer = attrData.Get_DataNum(LayerNum)
            Dim items(n - 1) As String
            For i As Integer = 0 To n - 1
                With .Data(i)
                    Dim hd As String = "*"
                    If .DataType = enmAttDataType.Normal Then
                        If .Statistics.Min >= 0 Then
                            hd = CStr(i + 1)
                        End If
                    End If
                    items(i) = hd & ":" + .Title
                End With
            Next
            Return items
        End With
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles rbArea.CheckedChanged, rbData.CheckedChanged, rbNoX.CheckedChanged, cboXData.SelectedIndexChanged, lbYData.SelectedIndexChanged
        DrawGraph()
    End Sub
    Private Sub DrawGraph()
        Dim canvas As New Bitmap(picGraph.Width, picGraph.Height)
        Dim g As Graphics = Graphics.FromImage(canvas)
        frameDraw(g)

        Dim f As Boolean = True
        If lbYData.SelectedIndices.Count = 0 Then
            f = False
        End If
        If rbData.Checked Then
            Dim n As Integer = cboXData.SelectedIndex
            If cboXData.SelectedIndex = -1 Then
                f = False
            End If
        End If
        If f = True Then
            culcuData(g)
        End If
        g.Dispose()
        If picGraph.Image Is Nothing = False Then
            picGraph.Image.Dispose()
        End If
        picGraph.Image = canvas
        picGraph.Refresh()
    End Sub

    Private Sub frameDraw(ByRef g As Graphics)
        g.Clear(Color.White)
        Dim pen As New Pen(Color.Black, 1)
        g.DrawRectangle(pen, gLeft, gTop, gSize, gSize)
        Dim fnt As New Font("MS UI Gothic", 10)
        Dim stfc As New StringFormat()
        stfc.Alignment = StringAlignment.Center
        Dim stfl As New StringFormat()
        stfl.Alignment = StringAlignment.Far
        stfl.LineAlignment = StringAlignment.Center
        Dim stfV As New StringFormat()
        stfV.Alignment = StringAlignment.Center
        stfV.LineAlignment = StringAlignment.Center
        stfV.FormatFlags = StringFormatFlags.DirectionVertical
        For i As Integer = 0 To 5
            Dim v = i * 20
            Dim uy As Single = gTop + gSize - i / 5 * gSize
            g.DrawLine(pen, New Point(gLeft, uy), New Point(gLeft - 5, uy))
            Dim ux As Single = gLeft + i / 5 * gSize
            g.DrawLine(pen, New Point(ux, gTop + gSize), New Point(ux, gTop + gSize + 5))
            Dim vx = ""
            Select Case i
                Case 0
                    vx = "0"
                Case 1
                    vx = "0.2"
                Case 2
                    vx = "0.4"
                Case 3
                    vx = "0.6"
                Case 4
                    vx = "0.8"
                Case 5
                    vx = "1.0"
            End Select
            g.DrawString(vx, fnt, Brushes.Black, ux, gTop + gSize + 5, stfc)
            g.DrawString(vx, fnt, Brushes.Black, gLeft - 5, uy, stfl)
        Next
        If lbYData.SelectedIndices.Count = 1 Then
            Dim n As Integer = lbYData.SelectedIndices(0)
            Dim ttl = attrData.LayerData(LayerNum).atrData.Data(n).Title
            g.DrawString(ttl, fnt, Brushes.Black, New Point(15, gTop + gSize / 2), stfV)
        End If
        Dim xtx As String = ""
        Select Case True
            Case rbNoX.Checked
            Case rbArea.Checked
                xtx = "面積"
            Case rbData.Checked
                Dim n As Integer = cboXData.SelectedIndex
                If n <> -1 Then
                    xtx = attrData.Get_DataTitle(LayerNum, n, False)
                End If
        End Select
        If xtx <> "" Then
            g.DrawString(xtx, fnt, Brushes.Black, New Point(gLeft + gSize / 2, gTop + gSize + 25), stfc)
        End If
        stfc.Dispose()
        stfl.Dispose()
        stfV.Dispose()
    End Sub
    Private Sub culcuData(ByRef g As Graphics)
        Dim xValue() As Double
        Dim xMisF() As Boolean
        Dim o_n As Integer = attrData.Get_ObjectNum(LayerNum)
        Select Case True
            Case rbNoX.Checked
                ReDim xValue(o_n - 1)
                ReDim xMisF(o_n - 1)
                clsGeneric.FillArray(xValue, 1)
                clsGeneric.FillArray(xMisF, False)
            Case rbArea.Checked
                If areaCulc Is Nothing = True Then
                    ReDim areaCulc(o_n - 1)
                    ReDim areaCulcMisF(o_n - 1)
                    clsGeneric.FillArray(areaCulcMisF, False)
                    For i As Integer = 0 To o_n - 1
                        areaCulc(i) = attrData.GetObjMenseki(LayerNum, i)
                        If areaCulc(i) = -1 Then
                            areaCulcMisF(i) = True
                        End If
                    Next
                End If
                xValue = areaCulc
                xMisF = areaCulcMisF
            Case rbData.Checked
                Dim xn As Integer = cboXData.SelectedIndex
                xValue = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, xn)
                xMisF = attrData.Get_Missing_Value_DataArray(LayerNum, xn)
        End Select
        Dim checkCnditon(o_n - 1) As Boolean
        If chkConditionUse.Checked = True Then
            For i As Integer = 0 To attrData.LayerData(LayerNum).atrObject.ObjectNum - 1
                checkCnditon(i) = attrData.Check_Condition(LayerNum, i)
            Next
        Else
            clsGeneric.FillArray(checkCnditon, True)
        End If

        g.DrawLine(New Pen(Color.Black, 1), New Point(gLeft, gTop + gSize), New Point(gLeft + gSize, gTop))
        Dim n As Integer = lbYData.SelectedIndices.Count
        Dim col(5) As Brush
        col(0) = New SolidBrush(Color.Black)
        col(1) = New SolidBrush(Color.Red)
        col(2) = New SolidBrush(Color.LightSkyBlue)
        col(3) = New SolidBrush(Color.LightGreen)
        col(4) = New SolidBrush(Color.YellowGreen)
        col(5) = New SolidBrush(Color.Purple)
        Dim fnt As New Font("MS UI Gothic", 10)
        Dim ly As Integer = gTop + 10
        Dim ListData As New List(Of String)
        ListData.Add("データ項目" + vbTab + "ジニ係数")
        For i As Integer = 0 To n - 1
            Dim pen As New Pen(col(i Mod 6), 2)
            If i > 6 Then
                pen.DashStyle = Drawing2D.DashStyle.Dot
            End If
            Dim yn = lbYData.SelectedIndices(i)
            Dim yvalue = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, yn)
            Dim yMisF = attrData.Get_Missing_Value_DataArray(LayerNum, yn)
            Dim acumDataNum As Integer = 0
            Dim sumX As Double = 0
            Dim sumY As Double = 0
            Dim sortV = New clsSortingSearch(VariantType.Double)
            Dim selObj(o_n) As Integer
            For j As Integer = 0 To o_n - 1
                If xMisF(j) = False And yMisF(j) = False And checkCnditon(j) = True Then
                    sortV.Add(yvalue(j) / xValue(j))
                    sumY += yvalue(j)
                    sumX += xValue(j)
                    selObj(acumDataNum) = j
                    acumDataNum += 1
                End If
            Next
            sortV.AddEnd()
            Dim acumXpoint As Double = 0
            Dim acumYpoint As Double = 0
            Dim oacumYpoint As Double = 0
            Dim ox As Integer = gLeft
            Dim oy As Integer = gTop + gSize
            Dim sumArea As Double = 0
            For j As Integer = 0 To acumDataNum - 1
                Dim selO As Integer = selObj(sortV.DataPosition(j))
                acumXpoint += xValue(selO) / sumX
                acumYpoint += yvalue(selO) / sumY
                Dim x As Integer = gLeft + acumXpoint * gSize
                Dim y As Integer = gTop + gSize - acumYpoint * gSize
                g.DrawLine(pen, New Point(ox, oy), New Point(x, y))
                ox = x
                oy = y
                Dim area As Double = (oacumYpoint + acumYpoint) * (xValue(selO) / sumX) / 2
                sumArea += area
                oacumYpoint = acumYpoint
            Next
            If n > 1 Then
                '凡例
                Dim lx As Integer = gLeft + gSize + 10
                Dim lw As Integer = picGraph.Width - (lx + 5 + 5)
                g.DrawLine(pen, New Point(lx, ly), New Point(lx + 50, ly))
                Dim ttl As String = attrData.Get_DataTitle(LayerNum, yn, False)
                Dim w As Single = g.MeasureString(ttl, fnt).Width
                Dim hint As Integer = Int(w / lw) + 1
                Dim rec = New RectangleF(lx + 5, ly + 5, lw, 15 * hint)
                g.DrawString(ttl, fnt, Brushes.Black, rec)
                ly += 15 + 15 * hint
            End If
            Dim gini As Single = (0.5 - sumArea) / 0.5
            ListData.Add(attrData.Get_DataTitle(LayerNum, yn, False) + vbTab + gini.ToString())
        Next
        Dim VariType() As VariantType = {VariantType.String, VariantType.Single}
        ListViewEX.SetData(ListData, VariType, {False, False}, False)
    End Sub
    Private Sub cboXData_Click(sender As Object, e As EventArgs) Handles cboXData.Click
        rbData.Checked = True
    End Sub


    Private Sub btnCopyGraph_Click(sender As Object, e As EventArgs) Handles btnCopyGraph.Click
        'Metafileオブジェクトを作成する
        Dim bmp As New Bitmap(10, 10)
        Dim bmpg As Graphics = Graphics.FromImage(bmp)
        Dim hdc As IntPtr = bmpg.GetHdc()
        Dim rec As New Rectangle(0, 0, picGraph.Width, picGraph.Height)
        Dim meta As New System.Drawing.Imaging.Metafile(hdc, rec,
                            Imaging.MetafileFrameUnit.Pixel, System.Drawing.Imaging.EmfType.EmfPlusOnly)
        bmpg.ReleaseHdc(hdc)


        'Metafileに描画する
        Dim emfg As Graphics = Graphics.FromImage(meta)

        frameDraw(emfg)
        Dim f As Boolean = True
        If lbYData.SelectedIndices.Count = 0 Then
            f = False
        End If
        If rbData.Checked Then
            Dim n As Integer = cboXData.SelectedIndex
            If cboXData.SelectedIndex = -1 Then
                f = False
            End If
        End If
        If f = True Then
            culcuData(emfg)
        End If

        emfg.Dispose()

        'クリップボードに保存
        clsEMFMetafileCopy.PutEnhMetafileOnClipboard(Me.Handle, meta)
        '後片付け
        meta.Dispose()
        bmpg.Dispose()
        bmp.Dispose()
    End Sub

    Private Sub btnImageCopy_Click(sender As Object, e As EventArgs) Handles btnImageCopy.Click
        Dim bmp2 As New Bitmap(picGraph.Width, picGraph.Height)
        Dim g As Graphics = Graphics.FromImage(bmp2)
        g.Clear(Color.White)
        g.DrawImage(picGraph.Image, New Point(0, 0))
        Clipboard.SetImage(bmp2)
        'bmp.Dispose()・・・これをやると貼り付けられない
        g.Dispose()
    End Sub

    Private Sub btnTextCopy_Click(sender As Object, e As EventArgs) Handles btnTextCopy.Click
        ListViewEX.copyData()
    End Sub

    Private Sub frmMail_LorenzGini_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_Lorenz", Me)
    End Sub


    Private Sub chkConditionUse_CheckedChanged(sender As Object, e As EventArgs) Handles chkConditionUse.CheckedChanged
        DrawGraph()
    End Sub
End Class