Public Class frmPrint_GoogleMapsFileOut
    Private Structure LayerGoogleOutDataInfo
        Public MappingDataNum As Long
        Public MappindPaintData() As Boolean
        Public MappindMarkData() As Boolean
        Public InfoData() As Boolean
        Public Opacity As Integer
        Public LineWidth As Integer
        Public LineColor As colorARGB
        Public LegendVisible As Boolean
        Public LayerVisible As Boolean
    End Structure
    Private Class LeafTile_Info
        Public Name As String
        Public id As String
        Public Overrides Function ToString() As String
            Return Name
        End Function
        Public Sub New(ByVal name1 As String, ByVal id1 As String)
            Name = name1
            id = id1
        End Sub
    End Class
    Dim LeafTile As New List(Of LeafTile_Info)
    Dim LayerGoogleOutData() As LayerGoogleOutDataInfo
    Private Structure SelMappingDataInfo
        Public Number As Integer
        Public Mode As String
    End Structure
    Private Structure lbZorderInfo
        Public LayerName As String
        Public LayerIndex As Integer
        Public Overrides Function ToString() As String
            Return LayerName
        End Function
    End Structure
    Dim SelectedLayer As Integer

    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData
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
    Private Sub setTileData()
        chkGPS.Visible = rbLeaflet.Checked
        If LeafTile.Count = 0 Then
            Return
        End If
        lbMaptype.Items.Clear()
        If rbGoogle.Checked = True Then
            With lbMaptype
                .Items.Add("Googleマップ")
                .Items.Add("Googleマップ写真")
                .Items.Add("Googleマップラベル")
                .Items.Add("Googleマップ地形")
                .Items.Add("地理院地図")
                .Items.Add("地理院地図色別標高地図")
                .Items.Add("地理院地図（写真）")
                .Items.Add("地理院地図（白地図）")
                .Items.Add("国土画像情報(1974-78年)")
                .Items.Add("国土画像情報(1988-90年)")
                .Items.Add("東日本大震災被災地直後オルソ画像")
                .Items.Add("東日本大震災復興オルソ画像")
                .Items.Add("オープンストリートマップ")
                .Items.Add("歴史的農業環境WMS配信サービス(関東平野)")
                .Items.Add("白地背景")
                For i As Integer = 0 To 5
                    .SetSelected(i, True)
                Next
            End With
        Else
            For Each Ob As LeafTile_Info In LeafTile
                lbMaptype.Items.Add(Ob)
            Next
            lbMaptype.SetSelected(0, True)
        End If
    End Sub
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData) As Windows.Forms.DialogResult
        attrData = _attrData

        With cboMaxZoomLevel
            .Items.Add("指定なし")
            For i As Integer = 10 To 21
                .Items.Add(i)
            Next
            .SelectedIndex = 0
        End With
        cboCompress.SelectedIndex = 0
        LeafTile.Add(New LeafTile_Info("地理院地図", "k_cj4"))
        LeafTile.Add(New LeafTile_Info("淡色地図", "pale"))
        LeafTile.Add(New LeafTile_Info("色別標高図", "relief"))
        LeafTile.Add(New LeafTile_Info("陰影起伏図", "hillshademap"))
        LeafTile.Add(New LeafTile_Info("傾斜量図", "slopemap"))
        LeafTile.Add(New LeafTile_Info("白地図", "whitemap"))
        LeafTile.Add(New LeafTile_Info("治水地形分類図初版", "k_LCMFC01"))
        LeafTile.Add(New LeafTile_Info("治水地形分類図更新版", "k_LCMFC02"))
        LeafTile.Add(New LeafTile_Info("都市圏活断層図", "k_afm"))
        LeafTile.Add(New LeafTile_Info("土地条件図初期整備版", "k_LCM25K"))
        LeafTile.Add(New LeafTile_Info("火山土地条件図", "k_vlcd"))
        LeafTile.Add(New LeafTile_Info("地理院最新写真", "k_ortho"))
        LeafTile.Add(New LeafTile_Info("写真1974-78", "k_nlii1"))
        LeafTile.Add(New LeafTile_Info("写真1979-83", "k_nlii2"))
        LeafTile.Add(New LeafTile_Info("写真1984-87", "k_nlii3"))
        LeafTile.Add(New LeafTile_Info("写真1988-90", "k_nlii4"))
        LeafTile.Add(New LeafTile_Info("写真1936", "k_ort_RIKU10"))
        LeafTile.Add(New LeafTile_Info("写真1945-50", "k_ort_USA10"))
        LeafTile.Add(New LeafTile_Info("写真1961-64", "k_ort_old10"))
        LeafTile.Add(New LeafTile_Info("東日本大震災震災直後画像", "k_toho1"))
        LeafTile.Add(New LeafTile_Info("東日本大震災震災後2011", "k_toho2"))
        LeafTile.Add(New LeafTile_Info("東日本大震災震災後2012", "k_toho3"))
        LeafTile.Add(New LeafTile_Info("東日本大震災震災後2013", "k_toho4"))
        LeafTile.Add(New LeafTile_Info("沖縄米軍作成1948", "OkinawaAMS48"))
        LeafTile.Add(New LeafTile_Info("シームレス地質図", "GSJseamless"))
        LeafTile.Add(New LeafTile_Info("明治期迅速測図", "habs"))
        LeafTile.Add(New LeafTile_Info("人口密度(2005年)", "pop_density2005"))
        LeafTile.Add(New LeafTile_Info("人口密度(2010年)", "pop_density2010"))
        LeafTile.Add(New LeafTile_Info("人口密度(2015年)", "pop_density2015"))
        LeafTile.Add(New LeafTile_Info("埼玉県用途地域", "SaitamaZoning"))
        LeafTile.Add(New LeafTile_Info("オープンストリートマップ", "osm"))
        LeafTile.Add(New LeafTile_Info("白地", "blanc"))

        setTileData()

        Dim layn As Integer = attrData.TotalData.LV1.Lay_Maxn
        ReDim LayerGoogleOutData(layn - 1)
        tabLayer.TabPages.Clear()
        For i As Integer = 0 To layn - 1
            Dim myTabPage As New TabPage()
            myTabPage.Text = (i + 1).ToString + ":" + attrData.Get_LayerName(i)
            tabLayer.TabPages.Add(myTabPage)
            Dim n As Integer = attrData.Get_DataNum(i)
            With LayerGoogleOutData(i)
                .MappingDataNum = 0
                ReDim .MappindPaintData(n - 1)
                ReDim .MappindMarkData(n - 1)
                ReDim .InfoData(n - 1)
                .Opacity = 8
                .LineColor = New colorARGB(Color.Black)
                If attrData.LayerData(i).Shape = enmShape.LineShape Then
                    .LineWidth = 3
                Else
                    .LineWidth = 1
                End If
                .LegendVisible = True
                .LayerVisible = True
            End With
        Next
        txtMapTitle.Text = ""

        With cboPolyOutline
            .Items.Add("輪郭線なし")
            .Items.Add("1ピクセル")
            .Items.Add("2ピクセル")
            .Items.Add("3ピクセル")
            .Items.Add("4ピクセル")
            .Items.Add("5ピクセル")
        End With

        With cboToka
            For i As Integer = 0 To 10
                Select Case i
                    Case 0
                        .Items.Add(CStr(i * 10) & "%(透明)")
                    Case 10
                        .Items.Add(CStr(i * 10) & "%(不透明)")
                    Case Else
                        .Items.Add(CStr(i * 10) & "%")
                End Select
            Next
        End With
        SelectedLayer = -1
        tabLayer.SelectedIndex = -1
        tabLayer.SelectedIndex = 0

        pnlLayer.Parent = tabLayer.TabPages.Item(0)
        chkMapSize.Checked = False
        chkDoubleMap.Checked = True
        Return Me.ShowDialog

    End Function


    Private Sub frmGoogleMapsFileOut_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "frmPrint_GoogleMapsFileOut", Me)
    End Sub

    Private Sub tabLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabLayer.SelectedIndexChanged
        Dim Layernum As Integer = tabLayer.SelectedIndex
        If Layernum = -1 Then
            Return
        End If
        If SelectedLayer <> -1 Then
            Call getTablayerData(SelectedLayer)
        End If
        lbMappitPaintMode.Tag = "nonclick"
        lbMappingMarkSizeMode.Tag = "nonclick"
        attrData.Set_DataTitle_to_ListBox(lbMappitPaintMode, Layernum, True, True, True, False)
        attrData.Set_DataTitle_to_ListBox(lbMappingMarkSizeMode, Layernum, True, True, False, False)
        attrData.Set_DataTitle_to_ListBox(lbInfoData, Layernum, True, True, True, True)

        Select Case attrData.LayerData(Layernum).Shape
            Case enmShape.PolygonShape
                gbLine.Visible = True
                picPolyLineColor.Enabled = True
                cboPolyOutline.SelectedIndex = 1
            Case enmShape.LineShape
                gbLine.Visible = False
                picPolyLineColor.Enabled = False
                cboPolyOutline.SelectedIndex = 3
            Case enmShape.PointShape
                gbLine.Visible = False
        End Select

        With LayerGoogleOutData(Layernum)
            For i As Integer = 0 To attrData.Get_DataNum(Layernum) - 1
                lbMappitPaintMode.SetSelected(i, .MappindPaintData(i))
                lbMappingMarkSizeMode.SetSelected(i, .MappindMarkData(i))
                lbInfoData.SetSelected(i, .InfoData(i))
            Next
            cboToka.SelectedIndex = .Opacity
            cboPolyOutline.SelectedIndex = .LineWidth
            picPolyLineColor.BackColor = .LineColor.getColor
            chkLegendVisible.Checked = .LegendVisible
            chkLayerVisible.Checked = .LayerVisible
        End With
        lbMappitPaintMode.Tag = ""
        lbMappingMarkSizeMode.Tag = ""
        SelectedLayer = Layernum
        pnlLayer.Parent = tabLayer.TabPages.Item(SelectedLayer)
    End Sub
    Private Sub getTablayerData(ByVal Layernum As Integer)
        With LayerGoogleOutData(Layernum)
            For i As Integer = 0 To attrData.Get_DataNum(Layernum) - 1
                .MappindPaintData(i) = lbMappitPaintMode.GetSelected(i)
                .MappindMarkData(i) = lbMappingMarkSizeMode.GetSelected(i)
                .InfoData(i) = lbInfoData.GetSelected(i)
            Next
            .MappingDataNum = lbMappitPaintMode.SelectedIndices.Count + lbMappingMarkSizeMode.SelectedIndices.Count
            .Opacity = cboToka.SelectedIndex
            .LineWidth = cboPolyOutline.SelectedIndex
            .LineColor = New colorARGB(picPolyLineColor.BackColor)
            .LegendVisible = chkLegendVisible.Checked
            .LayerVisible = chkLayerVisible.Checked
        End With

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If clsGeneric.Check_Folder_Exists(KtgisFileSelector1.Path) = False Then
            CloseCancelF = True
            Return
        End If

        If lbMaptype.SelectedIndices.Count = 0 Then
            MsgBox("マップタイプを最低1つ指定してください。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If

        getTablayerData(SelectedLayer)

        If lbLayerZOrder.Items.Count = 0 Then
            MsgBox("出力するデータを指定してください。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
        Cursor.Current = Cursors.WaitCursor
        Dim okf As Boolean
        If JSfile_Out(KtgisFileSelector1.Path) = True Then
            If rbGoogle.Checked = True Then
                okf = Google_Map(KtgisFileSelector1.Path)
            Else
                okf = Leaflet_Map(KtgisFileSelector1.Path)
            End If
        End If
        Cursor.Current = Cursors.Default

        If okf = True Then
            If MsgBox(KtgisFileSelector1.Path & "を保存しました。" & vbCrLf & "このファイルを開きますか？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                System.Diagnostics.Process.Start(KtgisFileSelector1.Path)
            End If
        End If
        CloseCancelF = True
    End Sub
    ''' <summary>
    ''' Leaflet_Map利用
    ''' </summary>
    ''' <param name="file_Path"></param>
    ''' <param name="RetFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Leaflet_Map(ByVal file_Path As String) As Boolean
        'HTML部分を出力
        Dim T As New System.Text.StringBuilder
        Dim MainDataTitle As String = txtMapTitle.Text
        Dim Out_js_file_Path As String = clsGeneric.GetFileDirPlusFileName(file_Path, System.IO.Path.GetFileNameWithoutExtension(file_Path) & "_data.js")

        'ヘッダ出力
        T.Append("<!DOCTYPE html>" & vbCrLf)
        T.Append("<html>" & vbCrLf & "  <head>" & vbCrLf)
        T.Append("    <title>" & MainDataTitle & "</title>" & vbCrLf)
        T.Append("    <meta http-equiv='content-type' content='text/html; charset=UTF-8'/>" & vbCrLf)
        T.Append("    <meta name='viewport' content='width=device-width,initial-scale=1.0'/>" & vbCrLf)
        T.Append("    <script src='https://ktgis.net/leaflet1.3.1/leaflet.js'></script>" & vbCrLf)
        T.Append("    <link rel='stylesheet' href='https://ktgis.net/leaflet1.3.1/leaflet.css' />" & vbCrLf)
        T.Append("    <script src='https://ktgis.net/leaflet1.3.1/L.Map.Sync.js'></script>" & vbCrLf)
        T.Append("    <script src='https://ktgis.net/mandara/mandara2leaflet3.js'></script>" & vbCrLf)
        T.Append("    <script src='https://ktgis.net/mandara/leaflet_tiles.js'></script>" & vbCrLf)
        T.Append("    <script src='" & System.IO.Path.GetFileName(Out_js_file_Path) & "'></script>" & vbCrLf)

        'body部分の出力
        T.Append("  </head>" & vbCrLf & "  <body onload='initialize()' style='overflow:hidden'>" & vbCrLf)
        '情報ボックス用div
        T.Append("    <div id='twoMapScreenDiv'><input id='twoMapScreenCheck' type='checkbox' checked onchange='twoMapScreenChange()' />2画面表示<br />" & vbCrLf)
        T.Append("    <input id='twoMapScreenSync' type='checkbox' checked onchange='twoMapScreenSyncChange()' />2画面連動<br /></div>" & vbCrLf)
        T.Append("    <div id='leftside' style='z-index:5; font-size:14px; position: absolute; padding:0px;border:solid; border-width:1px'></div>" & vbCrLf)
        T.Append("    <div id ='titlebox' style='font-size: 17px; text-align: center ; position: absolute'>" & vbCrLf)
        T.Append("      " & MainDataTitle & "<br>" & vbCrLf)
        T.Append("    </div>" & vbCrLf)
        T.Append("    <div id='mapcanvas0' style='z-index: 0;border:solid; border-width:1px ; position: absolute'></div>" & vbCrLf)
        T.Append("    <div id='mapcanvas1' style='z-index: 0;border:solid; border-width:1px ; position: absolute'></div>" & vbCrLf)
        T.Append("    <div id='notebox' style='position: absolute'>" & vbCrLf)
        T.Append("      <!-- ここに地図下に表示される注記を追加できます。 -->" & vbCrLf)
        T.Append("    </div>" & vbCrLf)
        T.Append("  </body>" & vbCrLf)
        T.Append("</html>" & vbCrLf)

        Dim sw2 As System.IO.StreamWriter
        Try
            sw2 = New System.IO.StreamWriter(file_Path, False, System.Text.Encoding.GetEncoding("utf-8"))
            sw2.Write(T.ToString)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        Finally
            sw2.Close()
        End Try
        Return True
    End Function
    ''' <summary>
    ''' Google Maps API利用
    ''' </summary>
    ''' <param name="file_Path"></param>
    ''' <param name="RetFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Google_Map(ByVal file_Path As String) As Boolean
        'HTML部分を出力
        Dim T As New System.Text.StringBuilder
        Dim MainDataTitle As String = txtMapTitle.Text
        Dim Out_js_file_Path As String = clsGeneric.GetFileDirPlusFileName(file_Path, System.IO.Path.GetFileNameWithoutExtension(file_Path) & "_data.js")

        'ヘッダ出力
        T.Append("<!DOCTYPE html>" & vbCrLf)
        T.Append("<html>" & vbCrLf & "  <head>" & vbCrLf)
        T.Append("    <title>" & MainDataTitle & "</title>" & vbCrLf)
        T.Append("    <meta http-equiv='content-type' content='text/html; charset=UTF-8'/>" & vbCrLf)
        T.Append("    <meta name='viewport' content='width=device-width,initial-scale=1.0'/>" & vbCrLf)
        T.Append("    <script type='text/javascript' src='https://maps.googleapis.com/maps/api/js?libraries=geometry&v=3&region=JP'></script>" & vbCrLf)
        T.Append("    <script src='http://ktgis.net/mandara/mandara2googlemap10_v22.js'></script>" & vbCrLf)
        T.Append("    <script src='http://ktgis.net/mandara/GoogleMapsCustomMapType.js'></script>" & vbCrLf)
        T.Append("    <script type='text/javascript' src='" & System.IO.Path.GetFileName(Out_js_file_Path) & "'></script>" & vbCrLf)

        'body部分の出力
        T.Append("  </head>" & vbCrLf & "  <body onload='initialize()' style='overflow:hidden'>" & vbCrLf)
        '情報ボックス用div
        T.Append("    <div id='box' style='z-index:30; visibility:hidden; border:solid; border-width:1px;border-radius:5px ; background-color:#ffffff;padding:3px; opacity:0.8; position: absolute'></div>" & vbCrLf)
        T.Append("    <div id='twoMapScreenDiv'><input id='twoMapScreenCheck' type='checkbox' checked onchange='twoMapScreenChange()' />2画面表示</div>" & vbCrLf)
        T.Append("    <div id='leftside' style='z-index:5; font-size:14px; position: absolute; padding:0px;border:solid; border-width:1px'></div>" & vbCrLf)
        T.Append("    <div id ='titlebox' style='font-size: 17px; text-align: center'>" & vbCrLf)
        T.Append("      " & MainDataTitle & "<br>" & vbCrLf)
        T.Append("    </div>" & vbCrLf)
        T.Append("    <div id='mapcanvas0' style='z-index: 0;border:solid; border-width:1px ; position: absolute'></div>" & vbCrLf)
        T.Append("    <div id='mapcanvas1' style='z-index: 0;border:solid; border-width:1px ; position: absolute'></div>" & vbCrLf)
        T.Append("    <div id='notebox' style='position: absolute'>" & vbCrLf)
        T.Append("      <!-- ここに地図下に表示される注記を追加できます。 -->" & vbCrLf)
        T.Append("    </div>" & vbCrLf)
        T.Append("  </body>" & vbCrLf)
        T.Append("</html>" & vbCrLf)

        Dim sw2 As System.IO.StreamWriter
        Try
            sw2 = New System.IO.StreamWriter(file_Path, False, System.Text.Encoding.GetEncoding("utf-8"))
            sw2.Write(T.ToString)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        Finally
            sw2.Close()
        End Try
        Return True
    End Function
    ''' <summary>
    ''' JSファイル出力
    ''' </summary>
    ''' <param name="file_Path"></param>
    ''' <param name="RetFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function JSfile_Out(ByVal file_Path As String) As Boolean

        Dim DBQ As String = Chr(34)
        Dim googleF As Boolean = rbGoogle.Checked

        Dim MainDataTitle As String = txtMapTitle.Text
        Dim MapW As Integer
        Dim MapH As Integer
        If chkMapSize.Checked = True Then
            MapW = 0
            MapH = 0
        Else
            MapW = Val(txtMapWidth.Text)
            MapH = Val(txtMapHeight.Text)
        End If
        Dim GetLayerNum As Integer = lbLayerZOrder.Items.Count
        Dim GetLayer(GetLayerNum - 1) As Integer
        For i As Integer = 0 To GetLayerNum - 1
            Dim ldt As lbZorderInfo = DirectCast(lbLayerZOrder.Items(i), lbZorderInfo)
            GetLayer(i) = ldt.LayerIndex
        Next

        '全体データ出力
        Dim T As New System.Text.StringBuilder
        If (googleF = True) Then
            T.Append("var overMap = new overMapInfo;" & vbCrLf)
        Else
            T.Append("var overMap = new Object();" & vbCrLf)
        End If
        T.Append("overMap.layerNum = " & GetLayerNum & ";" & vbCrLf)
        If cboMaxZoomLevel.Text = "指定なし" Then
            T.Append("overMap.maxZoom = -1;" & vbCrLf)
        Else
            T.Append("overMap.maxZoom = " & cboMaxZoomLevel.Text & ";" & vbCrLf)
        End If
        T.Append("overMap.minZoom = 0; //最小ズームレベル（0で世界全体）" & vbCrLf)
        T.Append("overMap.defoZoom = -1; //最初に表示されるズームレベル（-1の場合、全体が表示されるように自動設定）" & vbCrLf)
        T.Append("overMap.legendFont = " & DBQ & "13px " & "'メイリオ','ＭＳ Ｐゴシック'" & DBQ & "; //凡例のフォント" & vbCrLf)
        If (googleF = True) Then
            T.Append("overMap.addgoogleROADMAP = " & LCase(lbMaptype.GetSelected(0)) & ";" & vbCrLf)
            T.Append("overMap.addgoogleSATELLITE = " & LCase(lbMaptype.GetSelected(1)) & ";" & vbCrLf)
            T.Append("overMap.addgoogleHYBRID = " & LCase(lbMaptype.GetSelected(2)) & ";" & vbCrLf)
            T.Append("overMap.addgoogleTERRAIN = " & LCase(lbMaptype.GetSelected(3)) & ";" & vbCrLf)
            T.Append("overMap.addGSIMap = " & LCase(lbMaptype.GetSelected(4)) & ";" & vbCrLf)
            T.Append("overMap.addGSIReliefMap = " & LCase(lbMaptype.GetSelected(5)) & ";" & vbCrLf)
            T.Append("overMap.addGSIOrtho = " & LCase(lbMaptype.GetSelected(6)) & ";" & vbCrLf)
            T.Append("overMap.addGSIWhiteMap = " & LCase(lbMaptype.GetSelected(7)) & ";" & vbCrLf)
            T.Append("overMap.addNLII1Ortho = " & LCase(lbMaptype.GetSelected(8)) & ";" & vbCrLf)
            T.Append("overMap.addNLII4Ortho = " & LCase(lbMaptype.GetSelected(9)) & ";" & vbCrLf)
            T.Append("overMap.addTohoku1Ortho = " & LCase(lbMaptype.GetSelected(10)) & ";" & vbCrLf)
            T.Append("overMap.addTohoku2Ortho = " & LCase(lbMaptype.GetSelected(11)) & ";" & vbCrLf)
            T.Append("overMap.addOpenStreenMap = " & LCase(lbMaptype.GetSelected(12)) & ";" & vbCrLf)
            T.Append("overMap.addhabs = " & LCase(lbMaptype.GetSelected(13)) & ";" & vbCrLf)
            T.Append("overMap.addBlanc = " & LCase(lbMaptype.GetSelected(14)) & ";" & vbCrLf)
        Else
            'leaflet
            Dim idlist As New List(Of String)
            Dim opaList As New List(Of String)
            For Each ob As LeafTile_Info In lbMaptype.SelectedItems
                idlist.Add("'" + ob.id + "'")
                opaList.Add("1")
            Next
            Dim tx As String = String.Join(",", idlist.ToArray)
            Dim opa As String = String.Join(",", opaList.ToArray)
            T.Append("overMap.tileLayer = [" + tx + "]; //背景に選択できるタイルマップ" & vbCrLf)
            T.Append("overMap.tileLayerOpacity = [" + opa + "]; //背景のタイルマップごとの透過度" & vbCrLf)
            T.Append("overMap.overLayTile = []; //背景に重ね合わせるタイル" & vbCrLf)
            T.Append("overMap.overLayTileOpacity = []; //背景に重ね合わせるタイルごとの透過度" & vbCrLf)
            T.Append("overMap.GPS  = " + LCase(chkGPS.Checked.ToString) + "; //GPS機能の使用" & vbCrLf)
        End If
        T.Append("overMap.mapWidth = " & MapW & "; //地図の幅ピクセル（0の場合は画面サイズに合わせる）" & vbCrLf)
        T.Append("overMap.mapHeight = " & MapH & "; //地図の高さピクセル" & vbCrLf)
        T.Append("overMap.top = 0; //地図の左上の位置" & vbCrLf)
        T.Append("overMap.left = 5; //地図の左上の位置" & vbCrLf)
        T.Append("overMap.titleHeight = 30; //地図のタイトルの高さ" & vbCrLf)
        T.Append("overMap.sideBarWidth = 150;  //左サイドバーの幅" & vbCrLf)
        T.Append("overMap.screenLayerStrings ='レイヤ: ' ; //レイヤの表示" & vbCrLf)
        T.Append("overMap.screenMissingValueStrings = '" & attrData.TotalData.ViewStyle.Missing_Data.Text & "'; //欠損値の凡例文字" & vbCrLf)
        T.Append("overMap.screenOpacityStrings = '透過度:'; //透過度の文字" & vbCrLf)
        T.Append("overMap.screenOneLayerStrings = '表示/非表示'; //表示／非表示ボタンの文字" & vbCrLf)
        T.Append("overMap.screenLegendVisibilityStrings = '凡例表示'; //凡例表示ボタンの文字" & vbCrLf)
        T.Append("overMap.circleMDplusText = '" & clsSettings.Data.LegendPlusWord + "'; //記号モードで正の場合の凡例文字" & vbCrLf) 'ここは10では修正必要
        T.Append("overMap.circleMDminusText = '" & clsSettings.Data.LegendMinusWord + "'; //記号モードで負の場合の凡例文字" & vbCrLf)
        T.Append("overMap.doubleWindowEnabled = " & LCase(chkDoubleMap.Checked.ToString) + "; //2画面を可能にするか" & vbCrLf)
        T.Append("overMap.doubleWindowsFlag = false; //最初から2画面か" & vbCrLf)
        T.Append("overMap.sidebar_leftMapBGcol = 'ffffe0'; //左画面用サイドバーの背景色" & vbCrLf)
        T.Append("overMap.sidebar_rightMapBGcol = 'e0ffff'; //右画面用サイドバーの背景色" & vbCrLf)
        T.Append("layIniData = new Array();" & vbCrLf)


        '選択されたレイヤのzオーダー順に出力
        For iLay As Integer = 0 To GetLayerNum - 1
            Dim Layernum As Integer = GetLayer(iLay)
            Dim DataNum As Integer = attrData.Get_DataNum(Layernum) '-----
            Dim obn As Integer = attrData.Get_ObjectNum(Layernum)
            Dim datamax As Integer = attrData.Get_DataNum(Layernum)
            Dim DrawObjectCode(obn) As Integer
            Dim SelInfoData(datamax - 1) As Integer

            Dim SelInfoData_n As Integer = 0
            For i As Integer = 0 To datamax - 1
                If LayerGoogleOutData(Layernum).InfoData(i) = True Then
                    SelInfoData(SelInfoData_n) = i
                    SelInfoData_n += 1
                End If
            Next

            Dim SelMappingData(datamax - 1) As SelMappingDataInfo
            Dim SelMappingData_n As Integer = 0
            Dim MarkMdF As Boolean = False
            For i As Integer = 0 To datamax - 1
                If LayerGoogleOutData(Layernum).MappindPaintData(i) = True Or LayerGoogleOutData(Layernum).MappindMarkData(i) = True Then
                    SelMappingData(SelMappingData_n).Number = i
                    If LayerGoogleOutData(Layernum).MappindPaintData(i) = True Then
                        SelMappingData(SelMappingData_n).Mode = "paint"
                    Else
                        SelMappingData(SelMappingData_n).Mode = "mark"
                        MarkMdF = True
                    End If
                    SelMappingData_n += 1
                End If
            Next

            Dim DrawObject_num As Integer = 0
            For i As Integer = 0 To obn - 1
                If attrData.Check_screen_Kencode_In(Layernum, i) = True Then
                    If attrData.Check_Condition(Layernum, i) = True Then
                        DrawObjectCode(DrawObject_num) = i
                        DrawObject_num += 1
                    End If
                End If
            Next
            'データ部分のjavaScriptを出力

            'レイヤ情報　オブジェクト数、ライン色、ライン幅の出力
            Dim iniDataS As String = "layIniData[" & CStr(iLay) & "]"
            T.Append(iniDataS & " = new layIniInfo();" & vbCrLf)
            T.Append(iniDataS & ".name = '" & attrData.LayerData(Layernum).Name & "';" & vbCrLf)
            T.Append(iniDataS & ".shape = ")
            Dim layerShape As enmShape = attrData.LayerData(Layernum).Shape
            Select Case layerShape
                Case enmShape.PointShape
                    T.Append("'point';" & vbCrLf)
                Case enmShape.LineShape
                    T.Append("'line';" & vbCrLf)
                Case enmShape.PolygonShape
                    T.Append("'polygon';" & vbCrLf)
            End Select
            T.Append(iniDataS & ".zindex = " & iLay & ";" & vbCrLf)
            T.Append(iniDataS & ".obj_Num = " & DrawObject_num & ";" & vbCrLf)
            T.Append(iniDataS & ".lineColor = '" & clsGeneric.convHTMLColor(LayerGoogleOutData(Layernum).LineColor) & "';" & vbCrLf)
            Select Case layerShape
                Case enmShape.PointShape, enmShape.PolygonShape
                    T.Append(iniDataS & ".lineWidth = " & LayerGoogleOutData(Layernum).LineWidth & ";" & vbCrLf)
                Case enmShape.LineShape
                    T.Append(iniDataS & ".lineWidth = " & attrData.Get_Length_On_Screen(attrData.LayerData(Layernum).LayerModeViewSettings.PointLineShape.LineWidth) & ";" & vbCrLf)
            End Select
            T.Append(iniDataS & ".pointObjectRadius = " & attrData.LayerData(Layernum).LayerModeViewSettings.PointLineShape.PointMark.WordFont.Body.Size & ";" & vbCrLf)
            T.Append(iniDataS & ".opacity = " & LayerGoogleOutData(Layernum).Opacity / 10 & ";" & vbCrLf)
            T.Append(iniDataS & ".visible = " & LCase(LayerGoogleOutData(Layernum).LayerVisible) & ";" & vbCrLf)
            T.Append(iniDataS & ".legendVisible = " & LCase(LayerGoogleOutData(Layernum).LegendVisible) & ";" & vbCrLf)
            T.Append(iniDataS & ".mappingData = 0;" & vbCrLf) 'defMappingDataを指定したい場合は出力したファイルを修正する

            Dim PStac(obn) As Integer
            If layerShape <> enmShape.PointShape Then
                T.Append(iniDataS & ".encodedPoints = [" & vbCrLf)
                'ラインごとのエンコード化座標を出力
                Dim poly_num As Integer = 0
                Dim compress As Integer = cboCompress.SelectedIndex + 1
                For i As Integer = 0 To DrawObject_num - 1
                    DrawObjectCode(DrawObject_num) = i
                    PStac(i) = poly_num
                    Dim atx As String = Get_PolygonLine_Object_Coords(Layernum, DrawObjectCode(i), poly_num, PStac, compress)
                    If i <> DrawObject_num - 1 Then
                        atx += ","
                    End If
                    T.Append(" " & atx & vbCrLf)
                Next
                T.Append("];" & vbCrLf)
                PStac(DrawObject_num) = poly_num
            End If

            '地図化データ項目
            T.Append(iniDataS & ".selectedMappingData = [")
            For i As Integer = 0 To SelMappingData_n - 1
                T.Append("'" & getDataTitleUnit(Layernum, SelMappingData(i).Number))
                T.Append(SelMappingData(i).Mode)
                If i = SelMappingData_n - 1 Then
                    T.Append("'];" & vbCrLf)
                Else
                    T.Append("',")
                End If
            Next
            '凡例情報出力
            T.Append(iniDataS & ".legend = [" & vbCrLf)
            T.Append(Legend_Data_Out(Layernum, SelMappingData_n, SelMappingData))

            '情報ウィンドウ表示データ項目
            T.Append(iniDataS & ".selectedInfoData = [")
            If SelInfoData_n = 0 Then
                T.Append("];" & vbCrLf)
            Else
                For i As Integer = 0 To SelInfoData_n - 1
                    T.Append("'" & getDataTitleUnit(Layernum, SelInfoData(i)))
                    If i = SelInfoData_n - 1 Then
                        T.Append("'];" & vbCrLf)
                    Else
                        T.Append("',")
                    End If
                Next
            End If

            'オブジェクトの名称と主題図データを出力(タブ区切り)
            T.Append(iniDataS & ".objData = [" & vbCrLf)
            For i As Integer = 0 To DrawObject_num - 1
                'オブジェクト名
                T.Append("  '" & attrData.Get_KenObjName(Layernum, DrawObjectCode(i)) & "\t")
                If layerShape <> enmShape.PointShape Then
                    'ラインスタックポインタ
                    T.Append(CStr(PStac(i)) & "\t")
                    'ライン数
                    T.Append(CStr(PStac(i + 1) - PStac(i)) & "\t")
                End If
                If layerShape = enmShape.PointShape Or (MarkMdF = True And layerShape = enmShape.PolygonShape) Then
                    '点形状の場合およびペイントモードで記号表示を使用する場合は、記号表示位置を出力
                    With attrData.LayerData(Layernum).atrObject.atrObjectData(DrawObjectCode(i))
                        Dim CP As PointF = spatial.Get_Reverse_XY(.Symbol, attrData.TotalData.ViewStyle.Zahyo)
                        CP = spatial.Get_World_IdoKedo(CP, attrData.TotalData.ViewStyle.Zahyo).toPointF
                        T.Append(CP.X & "\t" & CP.Y & "\t")
                    End With
                End If
                '地図化データ項目
                For j As Integer = 0 To SelMappingData_n - 1
                    Dim v As String
                    If attrData.Get_DataType(Layernum, SelMappingData(j).Number) = enmAttDataType.Category Then
                        v = attrData.Get_Categoly(Layernum, SelMappingData(j).Number, DrawObjectCode(i)).ToString
                    Else
                        v = attrData.Get_Data_Value(Layernum, SelMappingData(j).Number, DrawObjectCode(i), "\n")
                    End If
                    T.Append(v)
                    If j <> SelMappingData_n - 1 Then
                        T.Append("\t")
                    End If
                Next
                If SelInfoData_n > 0 Then
                    T.Append("\t")
                End If

                '情報ウィンドウ出力データ項目
                For j As Integer = 0 To SelInfoData_n - 1
                    Dim v As String = attrData.Get_Data_Value(Layernum, SelInfoData(j), DrawObjectCode(i), "\n")
                    T.Append(v)
                    If j <> SelInfoData_n - 1 Then
                        T.Append("\t")
                    End If
                Next
                T.Append("'")
                If i = DrawObject_num - 1 Then
                    T.Append(vbCrLf & "];" & vbCrLf)
                Else
                    T.Append("," & vbCrLf)
                End If
            Next
        Next


        file_Path = clsGeneric.ReplaceFileExtention(file_Path, "html")

        Dim Out_js_file_Path As String = clsGeneric.GetFileDirPlusFileName(file_Path, System.IO.Path.GetFileNameWithoutExtension(file_Path) & "_data.js")
        Dim sw As System.IO.StreamWriter
        Try
            sw = New System.IO.StreamWriter(Out_js_file_Path, False, System.Text.Encoding.GetEncoding("utf-8"))
            sw.Write(T.ToString)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        Finally
            sw.Close()
        End Try
        T.Clear()



        Return True
    End Function
    Private Function Legend_Data_Out(ByVal Layernum As Integer, ByVal SelMappingData_n As Integer, ByRef SelMappingData() As SelMappingDataInfo) As String
        '凡例情報出力

        Dim T As New System.Text.StringBuilder
        Dim LayerShape As enmShape = attrData.LayerData(Layernum).Shape
        For i As Integer = 0 To SelMappingData_n - 1
            Dim DataNum As Integer = SelMappingData(i).Number
            With attrData.LayerData(Layernum).atrData.Data(DataNum)
                Dim dtype As enmAttDataType = attrData.Get_DataType(Layernum, DataNum)
                Dim div_num As Integer = .SoloModeViewSettings.Div_Num
                T.Append(" '")
                If SelMappingData(i).Mode = "paint" Then
                    'ペイントモードの凡例階級区分値・色
                    Dim LL As Integer = 1
                    Dim RR As Integer = 0
                    Dim vn As Integer
                    Dim n As Integer
                    If dtype = enmAttDataType.Category Then
                        n = 0
                        vn = div_num - 1
                    Else
                        n = 1
                        vn = div_num - 2
                    End If
                    For j As Integer = 0 To div_num - 1 - n
                        Dim L As Integer
                        Dim r As Integer
                        Dim a As Double = .SoloModeViewSettings.Class_Div(j).Value
                        clsGeneric.Figure_Arrange(a, L, r)
                        If L = 0 Then L = 1
                        If a < 0 Then L += 1
                        LL = Math.Max(LL, L)
                        RR = Math.Max(RR, r)
                    Next

                    For j As Integer = 0 To div_num - 1
                        Dim inColor As colorARGB = .SoloModeViewSettings.Class_Div(j).PaintColor
                        T.Append(clsGeneric.convHTMLColor(inColor) & "\t")
                    Next
                    For j As Integer = 0 To vn
                        Dim fu As String
                        With .SoloModeViewSettings.Class_Div(j)
                            If dtype = enmAttDataType.Category Then
                                fu = .Cat_Name
                            Else
                                fu = clsGeneric.Figure_Using(.Value, LL, RR, attrData.TotalData.ViewStyle.MapLegend.Base.Comma_f)
                            End If
                        End With
                        T.Append(fu)
                        If j <> vn Then
                            T.Append("\t")
                        End If
                    Next
                Else
                    '記号の大きさモード
                    '最大値,最大サイズ,内部色,負の値の有無、負の場合の内部色
                    With .SoloModeViewSettings.MarkSizeMD
                        T.Append(CStr(.MaxValue) + "\t")
                        If LayerShape = enmShape.LineShape Then
                            T.Append(CStr(.LineShape.LineWidth) & "\t")
                            T.Append(clsGeneric.convHTMLColor(.LineShape.Color) & "\t")
                        Else
                            T.Append(CStr(.Mark.WordFont.Body.Size) & "\t")
                            T.Append(clsGeneric.convHTMLColor(.Mark.WordFont.Body.Color) & "\t")
                        End If
                    End With
                    T.Append(LCase(Str(.Statistics.Min < 0)) & "\t" + _
                                clsGeneric.convHTMLColor(.SoloModeViewSettings.MarkCommon.MinusTile.Line.BasicLine.SolidLine.Color) & "\t")
                    '凡例値
                    Dim Legend_Val() As Double
                    Dim LegendVn As Integer = clsAccessory.Get_CircleModeLegendValue(attrData, Layernum, DataNum, Legend_Val)
                    T.Append(LegendVn & "\t")
                    For j As Integer = 0 To LegendVn - 1
                        Dim fw As String = clsGeneric.Figure_Using_Solo(Legend_Val(j), attrData.TotalData.ViewStyle.MapLegend.Base.Comma_f)
                        T.Append(fw)
                        If j <> LegendVn - 1 Then
                            T.Append("\t")
                        End If
                    Next
                    T.Append("\t" & .SoloModeViewSettings.MarkCommon.LegendMinusWord)
                    T.Append("\t" & .SoloModeViewSettings.MarkCommon.LegendPlusWord)
                End If
                If i = SelMappingData_n - 1 Then
                    T.Append("'" & vbCrLf & "];" & vbCrLf)
                Else
                    T.Append("'," & vbCrLf)
                End If
            End With
        Next
        Return T.ToString
    End Function
    Private Function getDataTitleUnit(ByVal Layernum As Integer, ByVal DataNum As Integer) As String
        Dim T As New System.Text.StringBuilder
        T.Append(attrData.Get_DataTitle(Layernum, DataNum, False) & "\t")
        Select Case attrData.Get_DataType(Layernum, DataNum)
            Case enmAttDataType.Normal
                T.Append(attrData.Get_DataUnit_With_Kakko(Layernum, DataNum))
            Case enmAttDataType.Category
                T.Append("CAT")
            Case enmAttDataType.Strings
                T.Append("STR")
        End Select
        T.Append("\t")
        Return T.ToString
    End Function

    Private Function Get_PolygonLine_Object_Coords(ByVal Layernum As Integer, ByVal Obj As Integer,
                                                   ByRef poly_num As Integer, ByRef PStac() As Integer, ByVal compress As Integer) As String
        Dim TotalInOut() As Integer

        Dim ELine() As clsMapData.EnableMPLine_Data
        Dim Pon As Integer
        Dim Arrange_LineCode(,) As Integer
        Dim Fringe() As clsMapData.Fringe_Line_Info

        Dim MapData As clsMapData = attrData.LayerData(Layernum).MapFileData
        Dim meshp() As PointF
        If attrData.LayerData(Layernum).Type = clsAttrData.enmLayerType.Mesh Then
            meshp = attrData.LayerData(Layernum).atrObject.atrObjectData(Obj).MeshPoint.Clone
            Pon = 1
        ElseIf attrData.LayerData(Layernum).Shape = enmShape.PolygonShape Then
            Pon = attrData.Boundary_Kencode_Arrange(Layernum, Obj, Arrange_LineCode, Fringe)
            Dim In_Out(,) As Byte = MapData.Object_Polygon_InOut(Pon, Arrange_LineCode, Fringe, TotalInOut)
        Else
            Pon = attrData.Get_Enable_KenCode_MPLine(ELine, Layernum, Obj)
        End If

        Dim PN As Integer
        Dim T As New System.Text.StringBuilder
        For j As Integer = 0 To Pon - 1
            Dim pxy() As PointF
            If attrData.LayerData(Layernum).Type = clsAttrData.enmLayerType.Mesh Then
                ReDim pxy(4)
                For k As Integer = 0 To 3
                    Dim CP As PointF = spatial.Get_Reverse_XY(meshp(k), attrData.TotalData.ViewStyle.Zahyo)
                    CP = spatial.Get_World_IdoKedo(CP, attrData.TotalData.ViewStyle.Zahyo).toPointF
                    pxy(k) = CP
                Next
                pxy(4) = pxy(0)
                PN = 5
            ElseIf attrData.LayerData(Layernum).Shape = enmShape.PolygonShape Then
                Dim poxy() As PointF
                PN = MapData.Get_Object_Polygon_Coords(j, 2, Arrange_LineCode, Fringe, poxy, False, compress, True)
                ReDim pxy(PN - 1)
                Dim D As Integer = spatial.Get_Polygon_Direction(PN, poxy)
                If (TotalInOut(j) Mod 2 = 1 And D = 1) Or (TotalInOut(j) Mod 2 = 0 And D = -1) Then
                    '中抜けポリゴンで時計回り、そうでなくて反時計回りの場合は座標を入れ替える
                    For k As Integer = 0 To PN - 1
                        pxy(k) = poxy(PN - 1 - k)
                    Next
                Else
                    pxy = poxy.Clone
                End If
            Else
                PN = MapData.Get_Coords_by_LineCode(ELine(j).LineCode, 2, 1, pxy, compress, True)

            End If
            T.Append("'")
            Dim oAccum_Ido As Integer
            Dim oAccum_Kedo As Integer
            For k As Integer = 0 To PN - 1
                Dim Ido As Single
                Dim Kedo As Single
                Dim Accum_Ido As Integer
                Dim Accum_Kedo As Integer
                If k = 0 Then
                    Ido = pxy(k).Y
                    Kedo = pxy(k).X
                    Accum_Ido = Ido * 10 ^ 5
                    Accum_Kedo = Kedo * 10 ^ 5
                Else
                    Ido = pxy(k).Y - pxy(k - 1).Y
                    Kedo = pxy(k).X - pxy(k - 1).X
                    Accum_Ido += CInt(Ido * 10 ^ 5)
                    Accum_Kedo += CInt(Kedo * 10 ^ 5)
                    '累積した緯度経度と実際の位置がずれてきた場合、調整する
                    If Math.Abs(Accum_Ido - CInt(pxy(k).Y * 10 ^ 5)) >= 2 Or Math.Abs(Accum_Kedo - CInt(pxy(k).X * 10 ^ 5)) >= 2 Then
                        Ido = pxy(k).Y - oAccum_Ido / 10 ^ 5
                        Kedo = pxy(k).X - oAccum_Kedo / 10 ^ 5
                        Accum_Ido = pxy(k).Y * 10 ^ 5
                        Accum_Kedo = pxy(k).X * 10 ^ 5
                    End If
                End If
                T.Append(encodeing(Ido))
                T.Append(encodeing(Kedo))
                oAccum_Ido = Accum_Ido
                oAccum_Kedo = Accum_Kedo
            Next
            T.Append("'")
            If j <> Pon - 1 Then
                T.Append("," & vbCrLf)
            End If
        Next
        poly_num += Pon

        Return T.ToString()
    End Function
    ''' <summary>
    ''' Google Maps APIのエンコーディングアルゴリズムによる文字列への変換
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function encodeing(Value As Single) As String


        Dim b As Integer = (CInt(Value * 10 ^ 5)) * 2
        If b < 0 Then
            b = Not b
        End If
        Dim ctx As String = Microsoft.VisualBasic.Right(New String("0"c, 30) + Convert.ToString(b, 2), 30)

        Dim bit5(5) As Integer
        For i As Integer = 0 To 5
            bit5(5 - i) = Convert.ToInt32(Mid(ctx, i * 5 + 1, 5), 2)
        Next

        Dim end_bit As Integer = 5
        Do While bit5(end_bit) = 0
            end_bit -= 1
            If end_bit = -1 Then
                Exit Do
            End If
        Loop

        For i As Integer = 0 To end_bit - 1
            bit5(i) += 32
        Next

        Dim encode As String = ""
        If end_bit = -1 Then
            encode = "?"
        Else
            For i As Integer = 0 To end_bit
                bit5(i) = bit5(i) + 63
                encode += Chr(bit5(i))
            Next
            encode = Replace(encode, "\", "\\")
        End If
        Return encode
    End Function
    Private Sub picPolyLineColor_Click(sender As Object, e As EventArgs) Handles picPolyLineColor.Click
        Dim col As colorARGB = New colorARGB(picPolyLineColor.BackColor)
        If clsGeneric.Color_Set(col) = True Then
            picPolyLineColor.BackColor = col.getColor
        End If
    End Sub


    Private Sub lbMappingMarkSizeMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbMappingMarkSizeMode.SelectedIndexChanged, lbMappitPaintMode.SelectedIndexChanged
        Dim lb As ListBoxEx = DirectCast(sender, ListBoxEx)
        If lb.Tag <> "" Then
            Return
        End If
        Dim lb2 As ListBoxEx
        Select Case lb.Name
            Case "lbMappingMarkSizeMode"
                lb2 = lbMappitPaintMode
            Case "lbMappitPaintMode"
                lb2 = lbMappingMarkSizeMode
        End Select
        For i As Integer = 0 To lb.Items.Count - 1
            If lb.GetSelected(i) = True Then
                lb2.Tag = "nonclick"
                lb2.SetSelected(i, False)
                lb2.Tag = ""
            End If
        Next

        Dim LayerCaption As String = tabLayer.TabPages.Item(SelectedLayer).Text
        Dim LP As Integer = -1
        For i As Integer = 0 To lbLayerZOrder.Items.Count - 1
            Dim Ldata As lbZorderInfo = DirectCast(lbLayerZOrder.Items(i), lbZorderInfo)
            If LayerCaption = Ldata.LayerName Then
                LP = i
                Exit For
            End If
        Next
        Dim n As Integer = lb.SelectedIndices.Count + lb2.SelectedIndices.Count
        If n > 0 And LP = -1 Then
            Dim Ldata As lbZorderInfo
            Ldata.LayerName = LayerCaption
            Ldata.LayerIndex = SelectedLayer
            lbLayerZOrder.Items.Add(Ldata)
        ElseIf n = 0 And LP >= 0 Then
            lbLayerZOrder.Items.RemoveAt(LP)
        End If

    End Sub


    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click, btnDown.Click
        Dim n As Integer = lbLayerZOrder.SelectedIndex
        If n = -1 Then
            Return
        End If
        Dim Ldata As lbZorderInfo = DirectCast(lbLayerZOrder.Items(n), lbZorderInfo)
        Dim nn As Integer
        Select Case sender.name
            Case "btnUp"
                If n = 0 Then
                    Return
                End If
                lbLayerZOrder.Items.RemoveAt(n)
                nn = n - 1
            Case "btnDown"
                If n = lbLayerZOrder.Items.Count - 1 Then
                    Return
                End If
                lbLayerZOrder.Items.RemoveAt(n)
                nn = n + 1
        End Select
        lbLayerZOrder.Items.Insert(nn, Ldata)
        lbLayerZOrder.SelectedIndex = nn
        lbLayerZOrder.Focus()
    End Sub

    Private Sub chkMapSize_CheckedChanged(sender As Object, e As EventArgs) Handles chkMapSize.CheckedChanged
        If chkMapSize.Checked = True Then
            txtMapWidth.Enabled = False
            txtMapHeight.Enabled = False
        Else
            txtMapWidth.Enabled = True
            txtMapHeight.Enabled = True
        End If
    End Sub


    Private Sub rbGoogle_CheckedChanged(sender As Object, e As EventArgs) Handles rbGoogle.CheckedChanged, rbLeaflet.CheckedChanged
        setTileData()

    End Sub
End Class