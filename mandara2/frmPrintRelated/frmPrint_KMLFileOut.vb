Public Class frmPrint_KMLFileOut
    Dim CloseCancelF As Boolean

    Dim attr As clsAttrData
    Dim Layernum As Integer
    Dim Datanum As Integer
    Dim Mode As enmSoloMode_Number
    Dim Shape As enmShape

    Dim DBQ As String = Chr(34)
    Dim CR As String = vbCrLf
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
    Public Overloads Function ShowDialog(_attr As clsAttrData) As Windows.Forms.DialogResult
        attr = _attr
        With cboPolyOutline.Items
            .Clear()
            .Add("輪郭線なし")
            .Add("1ピクセル")
            .Add("2ピクセル")
            .Add("3ピクセル")
            .Add("4ピクセル")
            .Add("5ピクセル")
        End With
        cboPolyOutline.SelectedIndex = 1

        cboPoint.Items.AddRange({"○", "□", "◇", "△", "▽"})
        Layernum = attr.TotalData.LV1.SelectedLayer
        Datanum = attr.LayerData(Layernum).atrData.SelectedIndex
        Mode = attr.LayerData(Layernum).atrData.Data(Datanum).ModeData
        Shape = attr.LayerData(Layernum).Shape

        If attr.LayerData(Layernum).Shape = enmShape.LineShape Then
            picPolyLineColor.Visible = False
            lblPolyInner.Visible = False
        Else
            picPolyLineColor.Visible = True
            lblPolyInner.Visible = True
        End If

        If Shape = enmShape.PointShape Or (Mode = enmSoloMode_Number.MarkSizeMode And Shape = enmShape.PolygonShape) Then
            gbPointShape.Enabled = True
            cboPoint.SelectedIndex = 0
        Else
            gbPointShape.Enabled = False
        End If

        If Mode = enmSoloMode_Number.ClassPaintMode Then
            chkLegend.Enabled = True
            chkLegend.Checked = True
        Else
            chkLegend.Enabled = False
            chkLegend.Checked = False
        End If

        FileSelect.InitFolder = clsSettings.Data.Directory.KML

        attr.Set_DataTitle_to_cboBox(cboAltiData, Layernum, Datanum, True, True, False, False)
        attr.Set_DataTitle_to_ListBox(lbData, Layernum, True, True, True, True)

        gbHeight.Enabled = False
        Return Me.ShowDialog

    End Function
    Public Function GetResults()

    End Function

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles rbSeaLevel.CheckedChanged

    End Sub


    Private Sub chkHeight_CheckedChanged(sender As Object, e As EventArgs) Handles chkHeight.CheckedChanged
        gbHeight.Enabled = chkHeight.Checked
    End Sub

    Private Sub picPolyLineColor_Click(sender As Object, e As EventArgs) Handles picPolyLineColor.Click
        Dim col As colorARGB = New colorARGB(picPolyLineColor.BackColor)
        attr.Select_Color(picPolyLineColor, col)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If clsGeneric.Check_Folder_Exists(FileSelect.Path) = False Then
            CloseCancelF = True
            Return
        End If


        If chkHeight.Checked = True Then
            Dim AltiData As Integer = cboAltiData.SelectedIndex
            If AltiData = -1 Then
                MsgBox("高さデータが選択されていません。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Return
            End If
            Dim Layernum As Integer = attr.TotalData.LV1.SelectedLayer
            If attr.Get_DataType(Layernum, AltiData) <> enmAttDataType.Normal Then
                MsgBox("カテゴリーデータ・文字列データは高さデータに設定できません。", MsgBoxStyle.Exclamation)
                CloseCancelF = True
                Return
            ElseIf attr.Get_DataMin(Layernum, AltiData) < 0 Then
                If MsgBox("高さデータに負の値が含まれています。このまま出力しますか?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                    CloseCancelF = True
                    Return
                End If
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim RetFile As String = ""
        Dim okf As Boolean = KML_Map(FileSelect.Path, RetFile)
        clsSettings.Data.Directory.KML = System.IO.Path.GetDirectoryName(RetFile)

        Me.Cursor = Cursors.Default
        If okf = True Then
            If MsgBox(RetFile & "を保存しました。このファイルを開きますか？", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                System.Diagnostics.Process.Start(RetFile)
            End If
        End If
        CloseCancelF = True
    End Sub
    Private Function KML_Map(ByVal file_Path As String, ByRef RetFile As String) As Boolean

        Dim AltiData As Integer = -1
        Dim Cell_Value() As Double
        Dim Missing_AltiArray() As Boolean
        Dim mxValue As Double = 0
        If chkHeight.Checked = True Then
            AltiData = cboAltiData.SelectedIndex
            Cell_Value = attr.Get_Data_Cell_Array_With_MissingValue(Layernum, AltiData)
            Missing_AltiArray = attr.Get_Missing_Value_DataArray(Layernum, AltiData)
            mxValue = attr.Get_DataMax(Layernum, AltiData)
        End If
        Dim Missing_DataArray() As Boolean = attr.Get_Missing_Value_DataArray(Layernum, Datanum)


        Dim Cate_words() As String = attr.Get_ClassDIV_Words(Layernum, Datanum, False)
        Dim DVN As Integer = attr.Get_DivNum(Layernum, Datanum)
        Dim Category_Array() As Integer = attr.Get_Categoly(Layernum, Datanum)
        Dim Mis_Num As Integer = attr.LayerData(Layernum).atrData.Data(Datanum).MissingValueNum
        Dim TTLE As String = attr.Get_DataTitle(Layernum, Datanum, False)
        Dim toka As Integer = hsbTransparency.Value
        Dim MisPrintF As Boolean = attr.TotalData.ViewStyle.Missing_Data.Print_Flag

        If Mis_Num > 0 And MisPrintF = True And Shape <> enmShape.LineShape Then
            DVN += 1
            For i As Integer = 0 To UBound(Category_Array)
                If Category_Array(i) = -1 Then
                    Category_Array(i) = DVN - 1
                End If
            Next
        End If

        Dim T As New System.Text.StringBuilder()
        T.Append("<?xml version=" & DBQ & "1.0" & DBQ & " encoding=" & DBQ & "UTF-8" & DBQ & "?>" & CR)
        T.Append("<kml xmlns=" & DBQ & "http://earth.google.com/kml/2.1" & DBQ & ">" & CR)
        T.Append("<Document>" & CR)
        T.Append("<name>" & TTLE & "</name>" & CR)
        Dim PolyLineCol As New colorARGB(picPolyLineColor.BackColor)
        Dim OutL As Integer
        If cboPolyOutline.SelectedIndex = 0 Then
            OutL = 0
        Else
            OutL = 1
        End If

        'スタイル
        With attr.LayerData(Layernum).atrData.Data(Datanum).SoloModeViewSettings
            If Shape = enmShape.LineShape Then
                For i As Integer = 0 To DVN - 1
                    T.Append(Get_LineStyle("LineCol" & CStr(i), .Class_Div(i).PaintColor, toka))
                Next
            Else
                Select Case Mode
                    Case enmSoloMode_Number.ClassPaintMode
                        For i As Integer = 0 To DVN - 1
                            If Mis_Num > 0 And i = DVN - 1 And MisPrintF = True Then
                                T.Append(Get_PolygonStyle("PolyCol" & CStr(i), 0, clsBase.ColorBlack, OutL, PolyLineCol, toka))
                            Else
                                T.Append(Get_PolygonStyle("PolyCol" & CStr(i), 1, .Class_Div(i).PaintColor, OutL, PolyLineCol, toka))
                            End If
                        Next
                    Case enmSoloMode_Number.MarkSizeMode
                        With .MarkSizeMD.Mark
                            T.Append(Get_PolygonStyle("PolyColPlus", 1, .Tile.Line.BasicLine.SolidLine.Color, OutL, PolyLineCol, toka))
                        End With
                        If attr.Get_DataMin(Layernum, Datanum) < 0 Then
                            With .MarkCommon.MinusTile
                                T.Append(Get_PolygonStyle("PolyColMinus", 1, .Line.BasicLine.SolidLine.Color, OutL, PolyLineCol, toka))
                            End With
                        End If
                End Select
            End If
        End With


        Dim mxalti As Double = Val(txtMaxAltitude.Text) * 1000

        Select Case Mode
            Case enmSoloMode_Number.ClassPaintMode
                '階級区分ごとにオブジェクトの座標出力
                For ic As Integer = 0 To DVN - 1
                    T.Append("<Folder>" & CR)
                    T.Append("<name>" & Cate_words(ic) & "</name>" & CR)
                    For i As Integer = 0 To attr.Get_ObjectNum(Layernum) - 1
                        If Category_Array(i) = ic Then
                            If attr.Check_Condition(Layernum, i) = True Then
                                Dim Alti As Single = 0
                                If AltiData <> -1 Then
                                    If Missing_DataArray(i) = True Or Missing_AltiArray(i) = True Then
                                    Else
                                        If mxValue <> 0 Then
                                            Alti = Cell_Value(i) / mxValue * mxalti
                                        End If
                                    End If
                                End If
                                Dim tx As String = Get_Object_Coords(Layernum, Datanum, i, ic, Alti, False)
                                If tx <> "" Then
                                    T.Append(tx)
                                End If
                            End If
                        End If
                    Next
                    T.Append("</Folder>" & CR)
                Next
            Case enmSoloMode_Number.MarkSizeMode
                T.Append("<Folder>" & CR)
                T.Append("<name>記号の大きさ</name>" & CR)
                For i As Integer = 0 To attr.Get_ObjectNum(Layernum) - 1
                    If attr.Check_Condition(Layernum, i) = True Then
                        Dim Alti As Single = 0
                        If AltiData <> -1 Then
                            If Missing_DataArray(i) = True Or Missing_AltiArray(i) = True Then
                            Else
                                If mxValue <> 0 Then
                                    Alti = Cell_Value(i) / mxValue * mxalti
                                End If
                            End If
                        End If
                        Dim tx As String = Get_Object_Coords(Layernum, Datanum, i, 0, Alti, False)
                        If tx <> "" Then
                            T.Append(tx)
                        End If
                    End If
                Next
                T.Append("</Folder>" & CR)
        End Select

        If chkObjectNameMarker.Checked = True Then
            T.Append("<Folder>" & CR)
            T.Append("<name>オブジェクト名</name>" & CR)
            For i As Integer = 0 To attr.Get_ObjectNum(Layernum) - 1
                If Category_Array(i) <> -1 Then
                    If attr.Check_Condition(Layernum, i) = True Then
                        Dim Alti As Single = 0
                        If AltiData <> -1 Then
                            If Missing_DataArray(i) = True Then
                            Else
                                If mxValue <> 0 Then
                                    Alti = Cell_Value(i) / mxValue * mxalti
                                End If
                            End If
                        End If
                        Dim tx As String = Get_Object_Coords(Layernum, Datanum, i, -1, Alti, True)
                        If tx <> "" Then
                            T.Append(tx)
                        End If
                    End If
                End If
            Next
            T.Append("</Folder>" & CR)
        End If

        file_Path = clsGeneric.ReplaceFileExtention(file_Path, "kml")

        '凡例出力
        If chkLegend.Checked = True Then
            Dim OutLengendFileName As String = System.IO.Path.GetFileNameWithoutExtension(file_Path) & "_legend.png"
            T.Append("<Folder>" & CR)
            T.Append("<name>凡例</name>" & CR)
            T.Append("<ScreenOverlay>" & CR)
            T.Append("<Icon>" & CR)
            T.Append("<href>" & System.IO.Path.GetFileName(OutLengendFileName) & "</href>" & CR)
            T.Append("</Icon>" & CR)
            T.Append("<color>" & Microsoft.VisualBasic.Right("00" & Hex(toka), 2) & "FFFFFF</color>" & CR)
            T.Append("<overlayXY x=" & DBQ & "0" & DBQ & " y=" & DBQ & "1" & DBQ & " xunits=" & DBQ & "fraction" & DBQ & " yunits=" & DBQ & "fraction" & DBQ & "/>" & CR)
            T.Append("<screenXY x=" & DBQ & "0" & DBQ & " y=" & DBQ & "1" & DBQ & " xunits=" & DBQ & "fraction" & DBQ & " yunits=" & DBQ & "fraction" & DBQ & "/>" & CR)
            T.Append("</ScreenOverlay>" & CR)
            T.Append("</Folder>" & CR)

            Call Output_LegendImage(clsGeneric.GetFileDirPlusFileName(file_Path, OutLengendFileName))
        End If

        '終了処理
        T.Append("</Document>" & CR)
        T.Append("</kml>" & CR)

        Try
            Dim sw As New System.IO.StreamWriter(file_Path, False, System.Text.Encoding.GetEncoding("utf-8"))
            sw.Write(T.ToString)
            sw.Close()
            RetFile = file_Path
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub Output_LegendImage(ByVal OutLengendFileName As String)
        Dim picSize As Size = attr.TotalData.ViewStyle.ScrData.frmPrint_FormSize.Size
        Dim canvas As New Bitmap(picSize.Width, picSize.Height)
        Dim g As Graphics = Graphics.FromImage(canvas)
        g.FillRectangle(New SolidBrush(Color.White), New Rectangle(0, 0, canvas.Width, canvas.Height))
        If attr.Check_Screen_In(attr.TempData.Accessory_Temp.MapLegend_W(0).Rect) = True Then
            clsAccessory.Legend_print(g, attr, 0, False)
        End If
        g.Dispose()

        Dim rect As Rectangle = attr.TempData.Accessory_Temp.MapLegend_W(0).Rect
        Dim LegendCanvas As New Bitmap(rect.Width, rect.Height)
        Dim LegendG As Graphics = Graphics.FromImage(LegendCanvas)
        LegendG.DrawImage(canvas, 0, 0, rect, GraphicsUnit.Pixel)
        LegendCanvas.Save(OutLengendFileName, System.Drawing.Imaging.ImageFormat.Png)
        LegendG.Dispose()
        LegendCanvas.Dispose()
        canvas.Dispose()
    End Sub
    Private Function Get_Object_Coords(ByVal Layernum As Integer, ByVal DataNum As Integer, ByVal Obj As Integer, ByVal ic As Integer,
                                       ByVal Alti As Single, ByVal Obj_Name_F As Boolean) As String


        Dim xx As Single, yy As Single
        Dim TA As New System.Text.StringBuilder()
        Dim TB As New System.Text.StringBuilder()



        Dim A_Data As Integer = cboAltiData.SelectedIndex
        Dim A_Mode As Integer
        If chkHeight.Checked = False Then
            A_Mode = 0
        Else
            If rbGround.Checked = True Then
                A_Mode = 1
            Else
                A_Mode = 2
            End If
        End If

        Dim Al_Str As String

        Select Case A_Mode
            Case 0
                Al_Str = "clampToGround"
            Case 1
                Al_Str = "relativeToGround"
            Case 2
                Al_Str = "absolute"
        End Select

        Dim Extr_Str As String
        If chkExtrude.Checked = True Then
            Extr_Str = "1"
        Else
            Extr_Str = "0"
        End If
        Dim DatacellV As Double = Val(attr.Get_Data_Value(Layernum, DataNum, Obj, ""))

        Dim CdataF As Boolean = True
        If chkDataValue.Checked = False And chkDataItem.Checked = False And chkObjectName.Checked = False And chkUnit.Visible = False Then
            CdataF = False
        End If

        Dim KName As String = attr.Get_KenObjName(Layernum, Obj)
        Dim w2 As String = ""
        If CdataF = True Then
            w2 = "<![CDATA["
            If chkDataItem.Checked = True Then
                w2 += attr.Get_DataTitle(Layernum, DataNum, False) & ": "
            End If
            If chkDataValue.Checked = True Then
                If chkDataItem.Checked = True Then
                    w2 += ":"
                End If
                w2 += attr.Get_Data_Value(Layernum, DataNum, Obj, attr.TotalData.ViewStyle.Missing_Data.Text)
            End If
            If chkUnit.Checked = True Then
                w2 += attr.Get_DataUnit_With_Kakko(Layernum, DataNum)
            End If
            w2 += "<br>"
            If A_Mode <> 0 And A_Data <> DataNum Then
                If chkDataItem.Checked = True Then
                    w2 += attr.Get_DataTitle(Layernum, A_Data, False) & ": "
                End If
                If chkDataValue.Checked = True Then
                    If chkDataItem.Checked = True Then
                        w2 += ":"
                    End If
                    w2 += attr.Get_Data_Value(Layernum, A_Data, Obj, attr.TotalData.ViewStyle.Missing_Data.Text)
                End If
                If chkUnit.Checked = True Then
                    w2 += attr.Get_DataUnit_With_Kakko(Layernum, A_Data)
                End If
                w2 += "<br>"
            End If
        End If

        If attr.Check_screen_Kencode_In(Layernum, Obj) = True Then
            'オブジェクト名
            TA.Append("<Placemark>" & CR)
            If chkObjectName.Checked = True Then
                TA.Append("<name>" & KName & "</name>" & CR)
            End If
            If CdataF = True Then
                TA.Append("<description>" & w2 & "]]>" & CR & "</description>" & CR)
            End If
            Dim LineHeader As String = TA.ToString & "<styleUrl>#LineCol" & CStr(ic) & "</styleUrl>" & CR
            Select Case Mode
                Case enmSoloMode_Number.ClassPaintMode
                    TA.Append("<styleUrl>#PolyCol" & CStr(ic) & "</styleUrl>" & CR)
                Case enmSoloMode_Number.MarkSizeMode
                    If DatacellV > 0 Then
                        TA.Append("<styleUrl>#PolyColPlus</styleUrl>" & CR)
                    Else
                        TA.Append("<styleUrl>#PolyColMinus</styleUrl>" & CR)
                    End If
            End Select
            Dim PolyPoint_HD As String = TA.ToString


            If Obj_Name_F = True Then

                TB.Append("<Placemark>" & CR)
                TB.Append("<name>" & KName & "</name>" & CR)
                TB.Append("<description>" & CR & w2 & "<br>" & CR)
                For i = 0 To attr.Get_DataNum(Layernum) - 1
                    If lbData.GetSelected(i) = True Then
                        TB.Append(attr.Get_DataTitle(Layernum, i, False) & ": " & attr.Get_Data_Value(Layernum, i, Obj, attr.TotalData.ViewStyle.Missing_Data.Text) & attr.Get_DataUnit_With_Kakko(Layernum, i) & "<BR>" & CR)
                    End If
                Next
                TB.Append("]]></description>" & CR)
                If chkObjectNameMarker.Checked = True Then
                    If chkObjectNameRegion.Checked = True Then
                        TB.Append(Get_Mpobj_RegionLatLonBox(Obj, Layernum, Val(txtObjectNameLodMin.Text), Val(txtObjectNameLodMax.Text)))
                    End If
                    TB.Append("<Point>" & CR)
                    TB.Append("<altitudeMode>" & Al_Str & "</altitudeMode>" & CR)
                    TB.Append("<extrude>0</extrude>" & CR)
                    Dim Sp As PointF
                    With attr.LayerData(Layernum).atrObject.atrObjectData(Obj)
                        Sp = spatial.Get_Reverse_XY(.Symbol, attr.TotalData.ViewStyle.Zahyo)
                    End With
                    Dim laolon As strLatLon = spatial.Get_World_IdoKedo(Sp, attr.TotalData.ViewStyle.Zahyo)
                    Dim poxy(0) As PointF
                    poxy(0) = laolon.toPointF
                    TB.Append(Get_Cooodinate_Str(1, poxy, A_Mode, Alti, False))
                    TB.Append("</Point>" & CR)
                    TB.Append("</Placemark>" & CR)
                End If
            Else
                If Mode = enmSoloMode_Number.MarkSizeMode Or Shape = enmShape.PointShape Then
                    TB.Append(PolyPoint_HD)
                    If chkRegion.Checked = True Then
                        TB.Append(Get_Mpobj_RegionLatLonBox(Obj, Layernum, Val(txtRegionLodMin.Text), Val(txtRegionLodMax.Text)))
                    End If
                    TB.Append("<Polygon>" & CR)
                    TB.Append("<altitudeMode>" & Al_Str & "</altitudeMode>" & CR)
                    TB.Append("<extrude>" & Extr_Str & "</extrude>" & CR)
                    TB.Append("<outerBoundaryIs>" & CR)
                    TB.Append("<LinearRing>" & CR)
                    Dim r As Single

                    If Mode = enmSoloMode_Number.ClassPaintMode Then
                        r = attr.LayerData(Layernum).LayerModeViewSettings.PointLineShape.PointMark.WordFont.Body.Size
                    Else
                        With attr.LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.MarkSizeMD
                            r = .Mark.WordFont.Body.Size * (Math.Sqrt(Math.Abs(DatacellV)) / Math.Sqrt(.MaxValue))
                        End With
                    End If
                    If r <> 0 Then
                        TB.Append(Get_PointLayer_Shape_Str(Obj, r, A_Mode, Alti))
                    End If
                    TB.Append("</LinearRing>" & CR)
                    TB.Append("</outerBoundaryIs>" & CR)
                    TB.Append("</Polygon>" & CR)
                    TB.Append("</Placemark>" & CR)
                Else
                    Select Case Shape
                        Case enmShape.LineShape
                            Dim ELine() As clsMapData.EnableMPLine_Data
                            Dim n As Integer = attr.Get_Enable_KenCode_MPLine(ELine, Layernum, Obj)
                            TB.Append(LineHeader)
                            If chkRegion.Checked = True Then
                                TB.Append(Get_Mpobj_RegionLatLonBox(Obj, Layernum, Val(txtRegionLodMin.Text), Val(txtRegionLodMax.Text)))
                            End If
                            If n >= 2 Then
                                TB.Append("<MultiGeometry>" & CR)
                            End If

                            Dim poxy() As PointF
                            For i As Integer = 0 To n - 1
                                TB.Append("<LineString>" & CR)
                                TB.Append("<altitudeMode>" & Al_Str & "</altitudeMode>" & CR)
                                TB.Append("<extrude>" & Extr_Str & "</extrude>" & CR)
                                Dim np As Integer = attr.LayerData(Layernum).MapFileData.Get_Coords_by_LineCode(ELine(i).LineCode, 2, 1, poxy, 1)
                                TB.Append(Get_Cooodinate_Str(np, poxy, A_Mode, Alti, False))
                                TB.Append("</LineString>" & CR)
                            Next
                            If n >= 2 Then
                                TB.Append("</MultiGeometry>" & CR)
                            End If
                            TB.Append("</Placemark>" & CR)
                        Case enmShape.PolygonShape

                            TB.Append(PolyPoint_HD)
                            If attr.LayerData(Layernum).Type = clsAttrData.enmLayerType.Mesh Then
                                Dim poxy() As PointF
                                TB.Append("<Polygon>" & CR)
                                TB.Append("<altitudeMode>" & Al_Str & "</altitudeMode>" & CR)
                                TB.Append("<extrude>" & Extr_Str & "</extrude>" & CR)
                                TB.Append("<outerBoundaryIs>" & CR)
                                TB.Append("<LinearRing>" & CR)

                                Dim meshP() As PointF = attr.LayerData(Layernum).atrObject.atrObjectData(Obj).MeshPoint
                                Dim meshlatlon(4) As PointF
                                For i As Integer = 0 To 3
                                    meshlatlon(i) = spatial.Get_Reverse_XY(meshP(i), attr.TotalData.ViewStyle.Zahyo)
                                    meshlatlon(i) = spatial.Get_World_IdoKedo(meshlatlon(i), attr.TotalData.ViewStyle.Zahyo).toPointF()
                                Next
                                meshlatlon(4) = meshlatlon(0)
                                TB.Append(Get_Cooodinate_Str(4, meshlatlon, A_Mode, Alti, True))

                                TB.Append("</LinearRing>" & CR)
                                TB.Append("</outerBoundaryIs>" & CR)
                                TB.Append("</Polygon>" & CR)

                            Else
                                Dim Fringe() As clsMapData.Fringe_Line_Info
                                Dim TotalInOut() As Integer

                                Dim Arrange_LineCode(,) As Integer
                                Dim Pon As Integer = attr.Boundary_Kencode_Arrange(Layernum, Obj, Arrange_LineCode, Fringe)
                                Dim In_Out(,) As Byte = attr.LayerData(Layernum).MapFileData.Object_Polygon_InOut(Pon, Arrange_LineCode, Fringe, TotalInOut)
                                Dim Rea_Ponn As Integer = 0
                                For i As Integer = 0 To Pon - 1
                                    If TotalInOut(i) = 0 Then
                                        Rea_Ponn += 1
                                    End If
                                Next

                                If chkRegion.Checked = True Then
                                    TB.Append(Get_Mpobj_RegionLatLonBox(Obj, Layernum, Val(txtRegionLodMin.Text), Val(txtRegionLodMax.Text)))
                                End If
                                If Rea_Ponn >= 2 Then
                                    TB.Append("<MultiGeometry>" & CR)
                                End If
                                For i As Integer = 0 To Pon - 1
                                    If TotalInOut(i) Mod 2 = 0 Then
                                        Dim poxy() As PointF
                                        TB.Append("<Polygon>" & CR)
                                        TB.Append("<altitudeMode>" & Al_Str & "</altitudeMode>" & CR)
                                        TB.Append("<extrude>" & Extr_Str & "</extrude>" & CR)
                                        TB.Append("<outerBoundaryIs>" & CR)
                                        TB.Append("<LinearRing>" & CR)
                                        Dim L As Integer = attr.LayerData(Layernum).MapFileData.Get_Object_Polygon_Coords(i, 2, Arrange_LineCode, Fringe, poxy, False, 1)
                                        TB.Append(Get_Cooodinate_Str(L, poxy, A_Mode, Alti, True))
                                        TB.Append("</LinearRing>" & CR)
                                        TB.Append("</outerBoundaryIs>" & CR)
                                        Dim inF_F As Boolean = False
                                        For j As Integer = 0 To Pon - 1
                                            If j <> i And TotalInOut(j) = 1 And In_Out(j, i) = 1 Then
                                                If inF_F = False Then
                                                    TB.Append("<innerBoundaryIs>" & CR)
                                                    inF_F = True
                                                End If
                                                Dim L2 As Integer = attr.LayerData(Layernum).MapFileData.Get_Object_Polygon_Coords(j, 2, Arrange_LineCode, Fringe, poxy, False, 1)
                                                TB.Append("<LinearRing>" & CR)
                                                TB.Append(Get_Cooodinate_Str(L2, poxy, A_Mode, Alti, True))
                                                TB.Append("</LinearRing>" & CR)
                                            End If
                                Next
                                        If inF_F = True Then
                                            TB.Append("</innerBoundaryIs>" & CR)
                                        End If
                                        TB.Append("</Polygon>" & CR)
                                    End If
                                Next
                                If Rea_Ponn >= 2 Then
                                    TB.Append("</MultiGeometry>" & CR)
                                End If
                            End If
                            TB.Append("</Placemark>" & CR)
                    End Select
                End If
            End If
        End If
        Return TB.ToString
    End Function
    Private Function Get_PointLayer_Shape_Str(ByVal Obj As Integer, ByVal r As Single, ByVal A_Mode As Integer, ByVal Altitude As Single) As String

        Dim XY() As PointF

        Dim z As clsMapData.Zahyo_info = attr.TotalData.ViewStyle.Zahyo

        Dim OSP As PointF = attr.LayerData(Layernum).atrObject.atrObjectData(Obj).Symbol
        Dim sp As PointF = spatial.Get_Reverse_XY(OSP, z)
        Dim splatlon As strLatLon = spatial.Get_World_IdoKedo(sp, z)

        Dim r2 As Single = attr.Get_Length_On_Screen(r) / attr.TotalData.ViewStyle.ScrData.ScreenMG.Mul / 2
        Dim rDis As Single = r2 * spatial.Get_Scale_Baititu_IdoKedo(OSP, z)
        Dim rlatlon As strLatLon = spatial.Get_Ido_Kedo_Rage_by_Distance(rDis, splatlon.Latitude)
        Dim n As Integer
        Select Case cboPoint.SelectedIndex
            Case 0
                If rlatlon.Longitude > 0 And rlatlon.Latitude > 0 Then
                    clsDrawMarkFan.Get_DAEN_IdoKedo(splatlon.Longitude, splatlon.Latitude, rlatlon.Longitude, rlatlon.Latitude, 0, n, XY)
                End If
            Case 1
                ReDim XY(4)
                With splatlon
                    XY(0).X = .Longitude - rlatlon.Longitude
                    XY(0).Y = .Latitude - rlatlon.Latitude
                    XY(1).X = .Longitude + rlatlon.Longitude
                    XY(1).Y = .Latitude - rlatlon.Latitude
                    XY(2).X = .Longitude + rlatlon.Longitude
                    XY(2).Y = .Latitude + rlatlon.Latitude
                    XY(3).X = .Longitude - rlatlon.Longitude
                    XY(3).Y = .Latitude + rlatlon.Latitude
                End With
                XY(4) = XY(0)
                n = 5
            Case 2
                ReDim XY(4)
                With splatlon
                    XY(0).X = .Longitude
                    XY(0).Y = .Latitude - rlatlon.Latitude
                    XY(1).X = .Longitude + rlatlon.Longitude
                    XY(1).Y = .Latitude
                    XY(2).X = .Longitude
                    XY(2).Y = .Latitude + rlatlon.Latitude
                    XY(3).X = .Longitude - rlatlon.Longitude
                    XY(3).Y = .Latitude
                End With
                XY(4) = XY(0)
                n = 5
            Case 3
                ReDim XY(3)
                With splatlon
                    XY(0).X = .Longitude
                    XY(0).Y = .Latitude + rlatlon.Latitude
                    XY(1).X = .Longitude + rlatlon.Longitude
                    XY(1).Y = .Latitude - rlatlon.Latitude
                    XY(2).X = .Longitude - rlatlon.Longitude
                    XY(2).Y = .Latitude - rlatlon.Latitude
                End With
                XY(3) = XY(0)
                n = 4
            Case 4
                ReDim XY(3)
                With splatlon
                    XY(0).X = .Longitude
                    XY(0).Y = .Latitude - rlatlon.Latitude
                    XY(1).X = .Longitude + rlatlon.Longitude
                    XY(1).Y = .Latitude + rlatlon.Latitude
                    XY(2).X = .Longitude - rlatlon.Longitude
                    XY(2).Y = .Latitude + rlatlon.Latitude

                End With
                XY(3) = XY(0)
                n = 4
        End Select
        If n > 0 Then
            Return Get_Cooodinate_Str(n, XY, A_Mode, Altitude, True)
        Else
            Return ""
        End If
    End Function
    Private Function Get_Mpobj_RegionLatLonBox(ByVal Obj As Integer, ByVal Layernum As Integer, ByVal minPix As Single, ByVal maxPix As Single) As String
        Dim xx As Single, yy As Single
        Dim ObjRect As RectangleF = attr.Get_Kencode_Object_Circumscribed_Rectangle(Layernum, Obj)
        Dim z As clsMapData.Zahyo_info = attr.TotalData.ViewStyle.Zahyo

        Dim ObjLatLonBox As strLatLonBox
        With ObjRect
            Dim p As PointF = spatial.Get_Reverse_XY(.Location, z)
            Dim NW As strLatLon = spatial.Get_World_IdoKedo(p, z)
            Dim p2 As PointF = spatial.Get_Reverse_XY(New PointF(.Right, .Bottom), z)
            Dim SE As strLatLon = spatial.Get_World_IdoKedo(p2, z)
            ObjLatLonBox = New strLatLonBox(NW, SE)
        End With

        If Shape = enmShape.PointShape Then

            Dim OSP As PointF = attr.LayerData(Layernum).atrObject.atrObjectData(Obj).Symbol
            Dim sp As PointF = spatial.Get_Reverse_XY(OSP, z)
            Dim splatlon As strLatLon = spatial.Get_World_IdoKedo(sp, z)
            Dim r As Single = attr.Get_Length_On_Screen(attr.LayerData(Layernum).LayerModeViewSettings.PointLineShape.PointMark.WordFont.Body.Size) / attr.TotalData.ViewStyle.ScrData.ScreenMG.Mul / 2
            Dim rDis As Single = r * spatial.Get_Scale_Baititu_IdoKedo(OSP, z)
            Dim rlatlon As strLatLon = spatial.Get_Ido_Kedo_Rage_by_Distance(rDis, splatlon.Latitude)
            With ObjLatLonBox
                .NorthWest.Latitude += rlatlon.Latitude
                .SouthEast.Latitude -= rlatlon.Latitude
                .NorthWest.Longitude -= rlatlon.Longitude
                .SouthEast.Longitude += rlatlon.Longitude
            End With
        End If

        Dim tx As String = ""
        tx += "<Region>" & CR
        tx += "<LatLonAltBox>" & CR
        With ObjLatLonBox
            tx += "<north>" & CStr(.NorthWest.Latitude) & "</north>" & CR
            tx += "<west>" & CStr(.NorthWest.Longitude) & "</west>" & CR
            tx += "<south>" & CStr(.SouthEast.Latitude) & "</south>" & CR
            tx += "<east>" & CStr(.SouthEast.Longitude) & "</east>" & CR
        End With
        tx += "</LatLonAltBox>" & CR
        tx += "<Lod>" & CR
        tx += "<minLodPixels>" & CStr(minPix) & "</minLodPixels>" & CR
        tx += "<maxLodPixels>" & CStr(maxPix) & "</maxLodPixels>" & CR
        tx += "</Lod>" & CR
        tx += "</Region>" & CR
        Return tx

    End Function
    Private Function Get_Cooodinate_Str(ByVal n As Long, ByRef XY() As PointF, ByVal A_Mode As Integer, ByVal Altitude As Single, ByVal PolygonF As Boolean) As String

        Dim T As New System.Text.StringBuilder()

        Dim XY2() As PointF

        If PolygonF = True Then
            Dim D As Integer = spatial.Get_Polygon_Direction(n, XY)
            If D = 1 Then
                XY2 = XY
            Else
                ReDim XY2(n - 1)
                For i As Integer = 0 To n - 1
                    XY2(n - 1 - i) = XY(i)
                Next
            End If
        Else
            XY2 = XY.Clone
        End If
        For i As Integer = 1 To n - 1
            If XY2(i - 1).X * XY2(i).X < 0 And XY2(i - 1).X > 90 Then
                For j As Integer = 0 To n - 1
                    If XY2(j).X < 0 Then
                        XY2(j).X = 360 + XY2(j).X
                    End If
                Next
                Exit For
            End If
        Next

        T.Append("<coordinates>" & CR)
        For i As Integer = 0 To n - 1
            T.Append(clsGeneric.SingleToString(XY2(i).X) & "," & clsGeneric.SingleToString(XY2(i).Y))
            If A_Mode <> 0 Then
                T.Append("," & CStr(Altitude))
            End If
            T.Append(CR)
        Next
        T.Append("</coordinates>" & CR)
        Return T.ToString
    End Function

    Private Function Get_PolygonStyle(ByVal ID As String, ByVal PolyFill As Integer, ByVal PolyColor As colorARGB,
                                      ByVal OutLine As Integer, ByVal LineColor As colorARGB, ByVal toka As Integer) As String
        PolyColor.a = toka
        LineColor.a = toka
        Dim tx As String = "<Style id=" & DBQ & ID & DBQ & ">" & CR
        tx += "<LineStyle>" & CR
        tx += "<color>" & clsGeneric.convKMLColor(LineColor) & "</color>" & CR
        tx += "<width>" & CStr(cboPolyOutline.SelectedIndex) & "</width>" & CR
        tx += "</LineStyle>" & CR
        tx += "<PolyStyle>" & CR
        tx += "<color>" & clsGeneric.convKMLColor(PolyColor) & "</color>" & CR
        tx += "<fill>" & CStr(PolyFill) & "</fill>"
        tx += "<outline>" & CStr(OutLine) & "</outline>"
        tx += "</PolyStyle>" & CR
        tx += "</Style>" & CR
        Return tx
    End Function
    Private Function Get_LineStyle(ByVal ID As String, ByVal LineColor As colorARGB, ByVal toka As Integer) As String
        LineColor.a = toka
        Dim tx As String = "<Style id=" & DBQ & ID & DBQ & ">" & CR
        tx += "<LineStyle>" & CR
        tx += "<color>" & clsGeneric.convKMLColor(LineColor) & "</color>" & CR
        tx += "<width>" & CStr(cboPolyOutline.SelectedIndex) & "</width>" & CR
        tx += "</LineStyle>" & CR
        tx += "</Style>" & CR
        Return tx
    End Function

    Private Sub frmPrint_KMLFileOut_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "frmPrint_KMLFileOut", Me)
    End Sub
End Class