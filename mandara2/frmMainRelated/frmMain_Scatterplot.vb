Public Class frmMain_Scatterplot
    Private Structure Axis_info
        Public minValue As Double
        Public maxValue As Double
        Public stepVlue As Double
    End Structure
    Private Structure plotpoint_info
        Public x As Integer
        Public y As Integer
        Public objNumber As Integer
        Public xValue As Double
        Public yValue As Double
        Public oname As String
    End Structure
    Dim attrData As clsAttrData
    Dim LayerNum As Integer
    Dim gSize As Integer = 320
    Dim gXSize As Integer = 300
    Dim gTop As Integer = 25
    Dim gLeft As Integer = 55
    Dim Xax As Axis_info
    Dim Yax As Axis_info
    Dim plotObject As New List(Of plotpoint_info)
    Dim mk As New Mark_Property


    Public Overloads Sub ShowDialog(ByRef _attrData As clsAttrData)
        attrData = _attrData
        LayerNum = attrData.TotalData.LV1.SelectedLayer
        lblPicGraph.Visible = False
        mk = clsBase.Mark
        mk.WordFont.Body.Size = 4
        mk.Tile.Line.BasicLine.SolidLine.Color = New colorARGB(255, 255, 40, 0)
        attrData.Draw_Sample_Mark_Box(picMark, mk)
        Dim d As Integer = attrData.LayerData(LayerNum).atrData.SelectedIndex
        If attrData.Check_Condition_UMU(LayerNum) = False And attrData.TotalData.ViewStyle.ObjectLimitationF = False Then
            chkConditionUse.Enabled = False
            chkConditionUse.Checked = False
        End If
        attrData.Set_DataTitle_to_cboBox(cboXData, LayerNum, d, True, True, False, False)
        attrData.Set_DataTitle_to_cboBox(cboYData, LayerNum, d, True, True, False, False)
        DrawGraph()
        Me.ShowDialog()
    End Sub

    Private Sub DrawGraph()
        picGraph.Tag = "ON"
        If picGraph.Width = 0 Or picGraph.Height = 0 Then
            Return
        End If
        Dim canvas As New Bitmap(picGraph.Width, picGraph.Height)
        Dim g As Graphics = Graphics.FromImage(canvas)
        gSize = picGraph.Height - gTop - 45
        gXSize = picGraph.Width - 40 - 90

        If gXSize <= 0 Or gSize <= 0 Then
            Return
        End If
        frameDraw(g)
        plotData(g)

        g.Dispose()
        If picGraph.Image Is Nothing = False Then
            picGraph.Image.Dispose()
        End If
        picGraph.Image = canvas
        picGraph.Refresh()
    End Sub
    Private Sub plotData(ByRef g As Graphics)
        Dim xn As Integer = cboXData.SelectedIndex
        Dim yn As Integer = cboYData.SelectedIndex
        If yn = -1 Or xn = -1 Then
            Return
        End If

        Dim xAdd As Double = 0
        Dim yAdd As Double = 0
        Dim STDWsize As Single = Math.Sqrt(gXSize * gSize)
        Dim r As Integer = mk.WordFont.Body.Size * STDWsize / 100 / 2

        plotObject = New List(Of plotpoint_info)
        

        Dim xValue() As Double
        Dim xMisF() As Boolean
        xValue = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, xn)
        xMisF = attrData.Get_Missing_Value_DataArray(LayerNum, xn)
        Dim yValue() As Double
        Dim yMisF() As Boolean
        yValue = attrData.Get_Data_Cell_Array_With_MissingValue(LayerNum, yn)
        yMisF = attrData.Get_Missing_Value_DataArray(LayerNum, yn)

        If chkConditionUse.Checked = True Then
            For i As Integer = 0 To attrData.LayerData(LayerNum).atrObject.ObjectNum - 1
                If attrData.Check_Condition(LayerNum, i) = False Then
                    xMisF(i) = True
                    yMisF(i) = True
                End If
            Next
        End If
        Dim scr As Screen_info
        scr.SampleBoxFlag = True
        For i As Integer = 0 To attrData.LayerData(LayerNum).atrObject.ObjectNum - 1
 
            If xMisF(i) = False And yMisF(i) = False Then
                Dim xv As Integer = (xValue(i) - Xax.minValue) / (Xax.maxValue - Xax.minValue) * gXSize + gLeft
                Dim yv As Integer = gTop + gSize - (yValue(i) - Yax.minValue) / (Yax.maxValue - Yax.minValue) * gSize
                clsDrawMarkFan.Mark_Print(g, New Point(xv, yv), r, mk, scr, attrData.TotalData.BasePicture)
                Dim pdata As plotpoint_info
                With pdata
                    .x = xv
                    .y = yv
                    .objNumber = i
                    .xValue = xValue(i)
                    .yValue = yValue(i)
                    .oname = attrData.Get_KenObjName(LayerNum, i)
                End With
                xAdd += xValue(i)
                yAdd += yValue(i)
                plotObject.Add(pdata)
            End If
        Next

        Dim realN As Integer = plotObject.Count
        Dim xAve As Double = xAdd / realN
        Dim yAve As Double = yAdd / realN
        Dim cvar As Double = 0
        Dim xvar As Double = 0
        Dim yvar As Double = 0
        For i As Integer = 0 To attrData.LayerData(LayerNum).atrObject.ObjectNum - 1
            If xMisF(i) = False And yMisF(i) = False Then
                cvar += (xValue(i) - xAve) * (yValue(i) - yAve)
                xvar += (xValue(i) - xAve) ^ 2
                yvar += (yValue(i) - yAve) ^ 2
            End If
        Next

        Dim cor As Single = cvar / (Math.Sqrt(xvar) * Math.Sqrt(yvar))
        Dim stx As String = ""
        stx += "相関係数: " + cor.ToString() + vbCrLf

        If cbReg.Checked = True Then
            Dim a As Single = cvar / xvar
            Dim b As Single = yAve - a * xAve
            stx += "回帰線: " + vbCrLf
            If b > 0 Then
                stx += "Y = " + a.ToString + "X + " + b.ToString() + vbCrLf
            Else
                stx += "Y = " + a.ToString + "X - " + Math.Abs(b).ToString() + vbCrLf
            End If
            stx += "決定係数: " + CSng(cor ^ 2).ToString + vbCrLf
            Dim marginRect As Rectangle = New Rectangle(gLeft, gTop, gXSize, gSize)
            g.SetClip(marginRect)
            Dim y1 As Double = a * Xax.minValue + b
            Dim y2 As Double = a * Xax.maxValue + b
            Dim ry1 As Integer = gTop + gSize - (y1 - Yax.minValue) / (Yax.maxValue - Yax.minValue) * gSize
            Dim ry2 As Integer = gTop + gSize - (y2 - Yax.minValue) / (Yax.maxValue - Yax.minValue) * gSize
            Dim pen As New Pen(Color.Gray, 2)
            g.DrawLine(pen, gLeft, ry1, gLeft + gXSize, ry2)
        End If
        txtStatBox.Text = stx
    End Sub

    Private Sub frameDraw(ByRef g As Graphics)
        g.Clear(Color.White)
        If cboYData.SelectedIndex = -1 Or cboXData.SelectedIndex = -1 Then
            Return
        End If

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

        Dim yValuetextW As Integer = g.MeasureString(Yax.maxValue.ToString(), fnt).Width
        yValuetextW = Math.Max(g.MeasureString(Yax.minValue.ToString(), fnt).Width, yValuetextW)
        gLeft = Math.Max(55, yValuetextW + 30)
        Dim pen As New Pen(Color.Black, 1)
        g.DrawRectangle(pen, gLeft, gTop, gXSize, gSize)
        Dim xDivisions As Integer = (Xax.maxValue - Xax.minValue) / Xax.stepVlue
        For i As Integer = 0 To xDivisions - 1
            Dim v As Double = Xax.minValue + Xax.stepVlue * i
            Dim xp As Integer = (Xax.stepVlue * i) / (Xax.maxValue - Xax.minValue) * gXSize
            g.DrawLine(pen, New Point(gLeft + xp, gTop + gSize), New Point(gLeft + xp, gTop + gSize + 5))
            g.DrawString(v.ToString(), fnt, Brushes.Black, gLeft + xp, gTop + gSize + 5, stfc)
        Next
        g.DrawLine(pen, New Point(gLeft + gXSize, gTop + gSize), New Point(gLeft + gXSize, gTop + gSize + 5))
        g.DrawString(Xax.maxValue.ToString(), fnt, Brushes.Black, gLeft + gXSize, gTop + gSize + 5, stfc)

        Dim yDivisions As Integer = (Yax.maxValue - Yax.minValue) / Yax.stepVlue
        For i As Integer = 0 To yDivisions - 1
            Dim v As Double = Yax.minValue + Yax.stepVlue * i
            Dim yp As Integer = (Yax.stepVlue * i) / (Yax.maxValue - Yax.minValue) * gSize
            g.DrawLine(pen, New Point(gLeft, gTop + gSize - yp), New Point(gLeft - 5, gTop + gSize - yp))
            g.DrawString(v.ToString(), fnt, Brushes.Black, gLeft - 5, gTop + gSize - yp, stfl)
        Next
        g.DrawLine(pen, New Point(gLeft, gTop), New Point(gLeft - 5, gTop))
        g.DrawString(Yax.maxValue.ToString(), fnt, Brushes.Black, gLeft - 5, gTop, stfl)


        '0の軸
        Dim pen2 As New Pen(Brushes.Black, 1)
        pen2.DashStyle = Drawing2D.DashStyle.Dash
        If Yax.maxValue > 0 And Yax.minValue < 0 Then
            Dim yv As Integer = gTop + gSize - (-Yax.minValue) / (Yax.maxValue - Yax.minValue) * gSize
            g.DrawLine(pen2, New Point(gLeft, yv), New Point(gLeft + gXSize, yv))
        End If

        If Xax.maxValue > 0 And Xax.minValue < 0 Then
            Dim xv As Integer = (-Xax.minValue) / (Xax.maxValue - Xax.minValue) * gXSize + gLeft
            g.DrawLine(pen2, New Point(xv, gTop), New Point(xv, gTop + gSize))
        End If

        '軸タイトル
        Dim ny As Integer = cboYData.SelectedIndex
        Dim ttl As String = attrData.LayerData(LayerNum).atrData.Data(ny).Title
        g.DrawString(ttl, fnt, Brushes.Black, New Point(15, gTop + gSize / 2), stfV)

        Dim nx As Integer = cboXData.SelectedIndex
        Dim xtx As String = attrData.Get_DataTitle(LayerNum, nx, False)
        g.DrawString(xtx, fnt, Brushes.Black, New Point(gLeft + gXSize / 2, gTop + gSize + 25), stfc)

        '軸単位
        Dim uy = attrData.Get_DataUnit_With_Kakko(LayerNum, ny)
        If uy <> "" Then
            g.DrawString(uy, fnt, Brushes.Black, New Point(gLeft, gTop - 20), stfc)
        End If
        Dim ux = attrData.Get_DataUnit_With_Kakko(LayerNum, nx)
        If ux <> "" Then
            g.DrawString(ux, fnt, Brushes.Black, New Point(gLeft + gXSize + 10, gTop + gSize + 25), stfc)
        End If


        stfc.Dispose()
        stfl.Dispose()
        stfV.Dispose()
    End Sub

    Private Sub cboYData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboYData.SelectedIndexChanged
        Dim n As Integer = cboYData.SelectedIndex
        If n <> -1 Then
            With attrData.LayerData(LayerNum).atrData.Data(n).Statistics
                Dim Max As Double = .Max
                Dim Min As Double = .Min
                Dim ST As Double = 0
                clsGeneric.WIC(5, Max, Min, ST)
                With Yax
                    .maxValue = Max
                    .minValue = Min
                    .stepVlue = ST
                End With
            End With
        End If
        DrawGraph()
    End Sub

    Private Sub cboXData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboXData.SelectedIndexChanged
        Dim n As Integer = cboXData.SelectedIndex
        If n <> -1 Then
            With attrData.LayerData(LayerNum).atrData.Data(n).Statistics
                Dim Max As Double = .Max
                Dim Min As Double = .Min
                Dim ST As Double = 0
                clsGeneric.WIC(5, Max, Min, ST)
                With Xax
                    .maxValue = Max
                    .minValue = Min
                    .stepVlue = ST
                End With
            End With
        End If
        DrawGraph()
    End Sub

    Private Sub btnCopyGraph_Click(sender As Object, e As EventArgs) Handles btnCopyGraph.Click
        'Metafileオブジェクトを作成する
        If cboYData.SelectedIndex = -1 Or cboXData.SelectedIndex = -1 Then
            Return
        End If


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
        plotData(emfg)

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

    Private Sub picGraph_Click(sender As Object, e As EventArgs) Handles picGraph.Click

    End Sub

    Private Sub picGraph_MouseMove(sender As Object, e As MouseEventArgs) Handles picGraph.MouseMove
        Dim n As Integer = plotObject.Count
        If n = 0 Then
            Return
        End If
        Dim STDWsize As Single = Math.Sqrt(gXSize * gSize)
        Dim r As Integer = mk.WordFont.Body.Size * STDWsize / 100 / 2

        Dim dis(n - 1) As Single
        For i As Integer = 0 To n - 1
            Dim pdata As plotpoint_info = plotObject.Item(i)
            dis(i) = spatial.get_Distance(e.Location.X, e.Location.Y, pdata.x, pdata.y)
        Next
        Dim sort_dis = New clsSortingSearch
        sort_dis.AddRange(plotObject.Count, dis)
        Dim nearList As New List(Of Integer)
        Dim top_d As Single = sort_dis.DataPositionValue_Single(0)
        If top_d > r Then
            lblPicGraph.Visible = False
            Return
        End If
        nearList.Add(sort_dis.DataPosition(0))
        For i As Integer = 1 To n - 1
            Dim d As Single = sort_dis.DataPositionValue_Single(i)
            If d = top_d Then
                nearList.Add(sort_dis.DataPosition(i))
            Else
                Exit For
            End If
        Next
        Dim tx As String = ""
        For i As Integer = 0 To nearList.Count - 1
            Dim nnum As Integer = nearList(i)
            With plotObject.Item(nnum)
                tx += .oname + vbCrLf
                tx += " x: " + .xValue.ToString() + vbCrLf
                tx += " y: " + .yValue.ToString() + vbCrLf
            End With
        Next
        With lblPicGraph
            .Text = tx
            .Left = e.Location.X + 10 + picGraph.Left
            .Top = e.Location.Y - lblPicGraph.Height * 1.5 + picGraph.Top
            .Visible = True
        End With
    End Sub


    Private Sub picMark_Click(sender As Object, e As EventArgs) Handles picMark.Click
        Dim mk2 As Mark_Property
        If clsGeneric.Mark_Set(mk, attrData) = True Then
            attrData.Draw_Sample_Mark_Box(picMark, mk)
            DrawGraph()
        End If
    End Sub

 

    Private Sub cbReg_CheckedChanged(sender As Object, e As EventArgs) Handles cbReg.CheckedChanged
        DrawGraph()
    End Sub

    Private Sub frmMain_Scatterplot_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_Scatterplot", Me)

    End Sub



    Private Sub frmMain_Scatterplot_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If picGraph.Tag = "ON" Then
            DrawGraph()
        End If
    End Sub

    Private Sub frmMain_Scatterplot_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub chkConditionUse_CheckedChanged(sender As Object, e As EventArgs) Handles chkConditionUse.CheckedChanged
        DrawGraph()
    End Sub
End Class