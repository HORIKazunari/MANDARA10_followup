Public Class frmPrint_TileMapOut
    Dim CloseCancelF As Boolean
    Dim attr As clsAttrData
    Dim StopButton As Boolean
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
        FolderSelect.Folder = clsSettings.Data.Directory.TileOut
        With cboMaxZoom
            For i As Integer = 0 To 21
                .Items.Add(i)
            Next
            .SelectedIndex = 15
        End With
        With cboMinZoom
            For i As Integer = 0 To 21
                .Items.Add(i)
            Next
            .SelectedIndex = 15
        End With
        rbPNG.Checked = True
        ProgressBar.Visible = False
        btnStop.Visible = False
        ToolStripProgressBar.Visible = False
        rbPresentArea.Checked = True
        lblProg.Visible = False
        Return Me.ShowDialog
    End Function


    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        StopButton = True
    End Sub

    Private Sub btnFileCount_Click(sender As Object, e As EventArgs) Handles btnFileCount.Click

        If cboMaxZoom.SelectedIndex < cboMinZoom.SelectedIndex Then
            MsgBox("最大ズームレベルは最小ズームレベルよりも大きく設定して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim WN As PointF
        Dim ES As PointF
        With attr.TotalData.ViewStyle
            If rbPresentArea.Checked = True Then
                WN = spatial.Get_Reverse_XY(New PointF(.ScrData.ScrRectangle.Left, .ScrData.ScrRectangle.Top), .Zahyo)
                ES = spatial.Get_Reverse_XY(New PointF(.ScrData.ScrRectangle.Right, .ScrData.ScrRectangle.Bottom), .Zahyo)
            Else
                WN = spatial.Get_Reverse_XY(New PointF(.ScrData.MapRectangle.Left, .ScrData.MapRectangle.Top), .Zahyo)
                ES = spatial.Get_Reverse_XY(New PointF(.ScrData.MapRectangle.Right, .ScrData.MapRectangle.Bottom), .Zahyo)
            End If
        End With

        Dim latlonBox As New strLatLonBox(New strLatLon(WN), New strLatLon(ES))

        Dim n As Long = 0
        For zm As Integer = cboMinZoom.SelectedIndex To cboMaxZoom.SelectedIndex
            n += clsTileMapService.Get_TileMap_Image_Number(zm, latlonBox)
        Next
        MsgBox("最大で" & n.ToString & "ファイルが生成されます。")
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        clsSettings.Data.Directory.TileOut = FolderSelect.Folder

        If cboMaxZoom.SelectedIndex < cboMinZoom.SelectedIndex Then
            MsgBox("最大ズームレベルは最小ズームレベルよりも大きく設定して下さい。", vbExclamation)
            CloseCancelF = True
            Return
        End If

        Cursor = Cursors.WaitCursor
        btnStop.Visible = True
        StopButton = False
        btnOK.Enabled = False
        btnCancel.Enabled = False
        GroupBox1.Enabled = False
        btnStop.Visible = True
        Dim ext As String
        If rbPNG.Checked = True Then
            ext = "png"
        Else
            ext = "jpg"
        End If
        Dim WestKedo As Single, NorthIdo As Single
        Dim EastKedo As Single, SouthIDo As Single
        Dim WN As PointF
        Dim ES As PointF
        With attr.TotalData.ViewStyle
            If rbPresentArea.Checked = True Then
                WN = spatial.Get_Reverse_XY(New PointF(.ScrData.ScrRectangle.Left, .ScrData.ScrRectangle.Top), .Zahyo)
                ES = spatial.Get_Reverse_XY(New PointF(.ScrData.ScrRectangle.Right, .ScrData.ScrRectangle.Bottom), .Zahyo)
            Else
                WN = spatial.Get_Reverse_XY(New PointF(.ScrData.MapRectangle.Left, .ScrData.MapRectangle.Top), .Zahyo)
                ES = spatial.Get_Reverse_XY(New PointF(.ScrData.MapRectangle.Right, .ScrData.MapRectangle.Bottom), .Zahyo)
            End If
        End With
        Dim latlonBox As New strLatLonBox(New strLatLon(WN), New strLatLon(ES))

        ProgressBar.Visible = True
        Dim f As Boolean = TileMapOut(FolderSelect.Folder, cboMaxZoom.SelectedIndex, cboMinZoom.SelectedIndex, latlonBox, ext)

        If f = True Then
            OutputSampleHTML(FolderSelect.Folder, cboMaxZoom.SelectedIndex, cboMinZoom.SelectedIndex, latlonBox, ext)
        End If
        ProgressBar.Visible = False
        GroupBox1.Enabled = True
        btnOK.Enabled = True
        btnCancel.Enabled = True
        btnStop.Visible = False
        Cursor = Cursors.Default

        If f = True Then
            MsgBox("タイルマップを出力しました。")
            System.Diagnostics.Process.Start(FolderSelect.Folder)
        Else
            MsgBox("タイルマップは出力できませんでした。", MsgBoxStyle.Exclamation)
        End If
        CloseCancelF = True
    End Sub
    Private Function TileMapOut(ByVal Folder As String, ByVal MaxZoom As Long, ByVal MinZoom As Long, _
                            ByVal latlonBox As strLatLonBox, ByVal ext As String) As Boolean
        'タイルマップ形式で出力


        Dim ScrData As Screen_info
        Dim MapScaleV As Boolean
        Dim MapTitleV As Boolean
        Dim MapLegendBaseV As Boolean
        Dim AttMapCompassV As Boolean
        Dim noteV As Boolean
        Dim AccessoryGroupBoxV As Boolean

        With attr.TotalData.ViewStyle
            ScrData = .ScrData
            With .ScrData.Screen_Margin
                .Left = 0
                .Right = 0
                .Top = 0
                .Bottom = 0
            End With
            MapScaleV = .MapScale.Visible
            MapTitleV = .MapTitle.Visible
            MapLegendBaseV = .MapLegend.Base.Visible
            AttMapCompassV = .AttMapCompass.Visible
            AccessoryGroupBoxV = .AccessoryGroupBox.Visible
            noteV = .DataNote.Visible
            .MapScale.Visible = False
            .MapTitle.Visible = False
            .MapLegend.Base.Visible = False
            .AttMapCompass.Visible = False
            .DataNote.Visible = False
            .AccessoryGroupBox.Visible = False
        End With


        Dim stp As Integer = 6 '6x6のタイル分を一回で描画。
        picMap.Size = New Size(256 * stp, 256 * stp)

        ProgressBar.Visible = True
        lblProg.Visible = True
        '最大ズームでタイルマップ作成
        Dim zm As Integer = MaxZoom
        Dim TP1 As Point = clsTileMapService.Get_TileMap_Image_Code(zm, latlonBox.NorthWest)
        Dim TP2 As Point = clsTileMapService.Get_TileMap_Image_Code(zm, latlonBox.SouthEast)
        Dim zfol As String = Folder & "\" & CStr(zm)
        If System.IO.Directory.Exists(zfol) = False Then
            If clsGeneric.MakeFolder(zfol) = False Then
                MsgBox("フォルダを作成できませんでした", MsgBoxStyle.Exclamation)
                ResetScreen(MapScaleV, MapTitleV, MapLegendBaseV, AttMapCompassV, ScrData, noteV, AccessoryGroupBoxV)
                TileMapOut = False
                Exit Function
            End If
        End If
        ProgressBar.Maximum = (TP2.X - TP1.X + 1)
        For IX As Integer = TP1.X To TP2.X Step stp
            ProgressBar.Value = (IX - TP1.X + 1)
            lblProg.Text = (IX - TP1.X + 1).ToString + "/" + (TP2.X - TP1.X + 1).ToString
            lblProg.Refresh()
            For iy As Integer = TP1.Y To TP2.Y Step stp
                My.Application.DoEvents()
                If StopButton = True Then
                    ResetScreen(MapScaleV, MapTitleV, MapLegendBaseV, AttMapCompassV, ScrData, noteV, AccessoryGroupBoxV)
                    Return False
                End If
                Dim TileNWLatLonBox As strLatLonBox
                Dim TileSWLatLonBox As strLatLonBox
                clsTileMapService.Get_TileMap_IdoKedo(zm, IX, iy, TileNWLatLonBox)
                clsTileMapService.Get_TileMap_IdoKedo(zm, IX + stp - 1, iy + stp - 1, TileSWLatLonBox)

                Dim CP1 As PointF = spatial.Get_Converted_XY(TileNWLatLonBox.NorthWest.toPointF, attr.TotalData.ViewStyle.Zahyo)
                Dim CP2 As PointF = spatial.Get_Converted_XY(TileSWLatLonBox.SouthEast.toPointF, attr.TotalData.ViewStyle.Zahyo)
                attr.TotalData.ViewStyle.ScrData.ScrView = spatial.Get_Circumscribed_Rectangle(CP1, CP2)
                attr.TotalData.ViewStyle.ScrData.Set_PictureBox_and_CulculateMul(picMap)
                Dim canvas As New Bitmap(picMap.Width, picMap.Height)
                Dim g As Graphics = Graphics.FromImage(canvas)
                If ext = "jpg" Then
                    g.FillRectangle(New SolidBrush(Color.White), New Rectangle(0, 0, picMap.Width, picMap.Height))
                End If
                clsPrintMap.ShowMap(g, ToolStripProgressBar, attr)
                g.Dispose()

                For IX2 As Integer = 0 To stp - 1
                    If IX + IX2 <= TP2.X Then
                        Dim MakeFolderF As Boolean = False
                        Dim ffolname As String = zfol & "\" & CStr(IX + IX2)
                        If System.IO.Directory.Exists(ffolname) = False Then
                            MakeFolderF = True
                        End If
                        For IY2 As Integer = 0 To stp - 1
                            If iy + IY2 <= TP2.Y Then
                                Dim TileCanvas As Bitmap = New Bitmap(256, 256, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                                Dim Tileg As Graphics = Graphics.FromImage(TileCanvas)
                                Dim SourceP As New Point(IX2 * 256, IY2 * 256)
                                Tileg.DrawImage(canvas, 0, 0, New Rectangle(SourceP, New Size(256, 256)), GraphicsUnit.Pixel)
                                Dim savef As Boolean = False
                                If ext = "png" Then
                                    Dim bmpData As System.Drawing.Imaging.BitmapData = TileCanvas.LockBits(New Rectangle(0, 0, TileCanvas.Width, TileCanvas.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, TileCanvas.PixelFormat)
                                    Dim ptr As IntPtr = bmpData.Scan0
                                    Dim pixels As Byte() = New Byte(bmpData.Stride * TileCanvas.Height - 1) {}
                                    System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, pixels.Length)
                                    For i As Integer = 3 To pixels.GetUpperBound(0) Step 12 '本来は4だが高速化のため12
                                        If pixels(i) <> 0 Then
                                            savef = True
                                            Exit For
                                        End If
                                    Next
                                    TileCanvas.UnlockBits(bmpData)
                                Else
                                    savef = True
                                End If

                                If savef = True Then
                                    If MakeFolderF = True Then
                                        If clsGeneric.MakeFolder(ffolname) = False Then
                                            MsgBox("フォルダを作成できませんでした", MsgBoxStyle.Exclamation)
                                            ResetScreen(MapScaleV, MapTitleV, MapLegendBaseV, AttMapCompassV, ScrData, noteV, AccessoryGroupBoxV)
                                            Return False
                                        End If
                                        MakeFolderF = False
                                    End If
                                    Dim Fname As String = ffolname & "\" & CStr(iy + IY2) & "." & ext
                                    Dim f As Boolean
                                    If ext = "png" Then
                                        TileCanvas.Save(Fname, System.Drawing.Imaging.ImageFormat.Png)
                                    ElseIf ext = "jpg" Then
                                        TileCanvas.Save(Fname, System.Drawing.Imaging.ImageFormat.Jpeg)
                                    End If
                                End If
                                Tileg.Dispose()
                                TileCanvas.Dispose()
                            End If
                        Next
                    End If
                Next
                canvas.Dispose()
            Next
        Next

        '子ズームレベルのタイルを参照して、親ズームレベルのタイルを作成
        ProgressBar.Maximum = (MaxZoom - 1 - MinZoom + 2)
        For i As Integer = MaxZoom - 1 To MinZoom Step -1
            ProgressBar.Value = MaxZoom - i
            lblProg.Text = (MaxZoom - i).ToString + "/" + (MaxZoom - 1 - MinZoom + 2).ToString
            lblProg.Refresh()
            My.Application.DoEvents()
            zfol = Folder & "\" & CStr(i)
            If System.IO.Directory.Exists(zfol) = False Then
                If clsGeneric.MakeFolder(zfol) = False Then
                    MsgBox("フォルダを作成できませんでした", MsgBoxStyle.Exclamation)
                    ResetScreen(MapScaleV, MapTitleV, MapLegendBaseV, AttMapCompassV, ScrData, noteV, AccessoryGroupBoxV)
                    Return False
                End If
            End If
            Dim UP1 As Point = clsTileMapService.Get_TileMap_Image_Code(i, latlonBox.NorthWest)
            Dim UP2 As Point = clsTileMapService.Get_TileMap_Image_Code(i, latlonBox.SouthEast)
            For j As Integer = UP1.X To UP2.X
                My.Application.DoEvents()
                If StopButton = True Then
                    ResetScreen(MapScaleV, MapTitleV, MapLegendBaseV, AttMapCompassV, ScrData, noteV, AccessoryGroupBoxV)
                    Return False
                End If
                Dim ffolname As String = zfol & "\" & CStr(j)
                Dim MakeFolderF As Boolean = False
                If System.IO.Directory.Exists(ffolname) = False Then
                    MakeFolderF = True
                End If
                For k As Integer = UP1.Y To UP2.Y
                    Dim UpCanvas As Bitmap = New Bitmap(256, 256)
                    Dim Upg As Graphics = Graphics.FromImage(UpCanvas)
                    Dim noFileF As Boolean = True
                    For childX As Integer = 0 To 1
                        For childY As Integer = 0 To 1
                            Dim dldfile As String = Folder & "\" & CStr(i + 1) + "\" + CStr(j * 2 + childX) & "\" & CStr(k * 2 + childY) & "." & ext
                            If System.IO.File.Exists(dldfile) = True Then
                                noFileF = False
                                Dim bmp As New Bitmap(dldfile)
                                Dim DesRect As New Rectangle(New Point(childX * 128, childY * 128), New Size(128, 128))
                                Upg.DrawImage(bmp, DesRect)
                                bmp.Dispose()
                            End If
                        Next
                    Next
                    If noFileF = False Then
                        If MakeFolderF = True Then
                            If clsGeneric.MakeFolder(ffolname) = False Then
                                MsgBox("フォルダを作成できませんでした", MsgBoxStyle.Exclamation)
                                ResetScreen(MapScaleV, MapTitleV, MapLegendBaseV, AttMapCompassV, ScrData, noteV, AccessoryGroupBoxV)
                                Return False
                            End If
                            MakeFolderF = False
                        End If
                        Dim Fname As String = ffolname & "\" & CStr(k) & "." & ext
                        If ext = "png" Then
                            UpCanvas.Save(Fname, System.Drawing.Imaging.ImageFormat.Png)
                        ElseIf ext = "jpg" Then
                            UpCanvas.Save(Fname, System.Drawing.Imaging.ImageFormat.Jpeg)
                        End If
                    End If
                    Upg.Dispose()
                    UpCanvas.Dispose()
                Next
            Next
        Next

        Call ResetScreen(MapScaleV, MapTitleV, MapLegendBaseV, AttMapCompassV, ScrData, noteV, AccessoryGroupBoxV)
        Return True
    End Function
    Private Sub ResetScreen(ByVal MapScaleV As Boolean, ByVal MapTitleV As Boolean, ByVal MapLegendBaseV As Boolean, _
            ByVal AttMapCompassV As Boolean, ByRef oldScrData As Screen_info, noteV As Boolean, AccessoryGroupBoxV As Boolean)
        With attr.TotalData.ViewStyle
            .MapScale.Visible = MapScaleV
            .MapTitle.Visible = MapTitleV
            .MapLegend.Base.Visible = MapLegendBaseV
            .AttMapCompass.Visible = AttMapCompassV
            .DataNote.Visible = noteV
            .AccessoryGroupBox.Visible = AccessoryGroupBoxV
            .ScrData = oldScrData
        End With
        lblProg.Visible = False
    End Sub
    Private Function OutputSampleHTML(ByVal Folder As String, ByVal MaxZoom As Integer, ByVal MinZoom As Integer, _
                            ByVal latlonBox As strLatLonBox, ByVal ext As String) As Boolean
        Const adTypeText = 2, adSaveCreateOverwrite = 2
        Dim objStream_html As Object

        Dim T As New System.Text.StringBuilder()

        Dim cido As Single = (latlonBox.NorthWest.Latitude + latlonBox.SouthEast.Latitude) / 2
        Dim ckedo As Single = (latlonBox.NorthWest.Longitude + latlonBox.SouthEast.Longitude) / 2
        Dim czoom As Integer= (MaxZoom + MinZoom) \ 2

        T.Append("<!DOCTYPE html>" & vbCrLf)
        T.Append("<html>" & vbCrLf & "  <head>" & vbCrLf)
        T.Append("    <title>Google Maps APIタイルマップサンプル</title>" & vbCrLf)
        T.Append("    <meta http-equiv='content-type' content='text/html; charset=UTF-8'/>" & vbCrLf)
        T.Append("    <script type='text/javascript' src='https://maps.googleapis.com/maps/api/js?libraries=geometry&v=3&sensor=false'></script>" & vbCrLf)
        T.Append("    <script>" + vbCrLf)
        T.Append("      function myMapType() {" + vbCrLf)
        T.Append("        myMapType.prototype.tileSize = new google.maps.Size(256,256);" + vbCrLf)
        T.Append("        myMapType.prototype.getTile = function( tileXY, zoom, ownerDocument ) {" + vbCrLf)
        T.Append("          var tileImage = ownerDocument.createElement('img');" + vbCrLf)
        T.Append("          var src =   zoom + '/' + tileXY.x + '/' + tileXY.y + '." & ext & "';" + vbCrLf)
        T.Append("          tileImage.setAttribute('src', src);" + vbCrLf)
        T.Append("          tileImage.style.opacity = 0.8;" + vbCrLf)
        T.Append("          return tileImage;" + vbCrLf)
        T.Append("        };" + vbCrLf)
        T.Append("      }" + vbCrLf)
        T.Append("      function init_google_map() {" + vbCrLf)
        T.Append("        var mapOptions = {" + vbCrLf)
        T.Append("          zoom:" & czoom & "," & vbCrLf)
        T.Append("          center: new google.maps.LatLng(" & cido & "," & ckedo & ")" + vbCrLf)
        T.Append("        };" + vbCrLf)
        T.Append("        var map = new google.maps.Map( document.getElementById('map_canvas'),mapOptions);" + vbCrLf)
        T.Append("        map.overlayMapTypes.insertAt(0,new myMapType);" + vbCrLf)
        T.Append("      }" + vbCrLf)
        T.Append("    </script>" + vbCrLf)
        T.Append("    <style>" & vbCrLf)
        T.Append("      body { margin:0; padding:0; }" & vbCrLf)
        T.Append("      #map_canvas { position:absolute; top:0; bottom:0; width:100%; }" & vbCrLf)
        T.Append("   </style>" & vbCrLf)
        T.Append("  </head>" & vbCrLf)
        T.Append("  <body onload='init_google_map()'>" & vbCrLf)
        T.Append("    <div id='map_canvas'></div>" & vbCrLf)
        T.Append("    </div>" & vbCrLf)
        T.Append("  </body>" & vbCrLf)
        T.Append("</html>" & vbCrLf)
        Dim Googlefile_Path As String = Folder & "\google_maps_api_sample.html"
        Dim sw As New System.IO.StreamWriter(Googlefile_Path, False, System.Text.Encoding.GetEncoding("utf-8"))
        sw.Write(T.ToString)
        sw.Close()

        T.Clear()
        T.Append("<!DOCTYPE html>" & vbCrLf)
        T.Append("<html>" & vbCrLf & "  <head>" & vbCrLf)
        T.Append("    <title>リーフレットタイルマップサンプル</title>" & vbCrLf)
        T.Append("    <meta http-equiv='content-type' content='text/html; charset=UTF-8'/>" & vbCrLf)
        T.Append("    <link rel='stylesheet' href='http://cdn.leafletjs.com/leaflet/v0.7.7/leaflet.css' />" & vbCrLf)
        T.Append("    <script src='http://cdn.leafletjs.com/leaflet/v0.7.7/leaflet.js'></script>" & vbCrLf)
        T.Append("    <script>" + vbCrLf)
        T.Append("      function init() {" + vbCrLf)
        T.Append("        var map = L.map('map',{center:[" & cido & "," & ckedo & "],zoom:" & czoom & "})" + vbCrLf)
        T.Append("        L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png').addTo(map);" + vbCrLf)
        T.Append("        var options = {" + vbCrLf)
        T.Append("          opacity: 0.8," & vbCrLf)
        T.Append("          minZoom: " & MinZoom & "," & vbCrLf)
        T.Append("          maxZoom:" & MaxZoom & vbCrLf)
        T.Append("        };" + vbCrLf)
        T.Append("        L.tileLayer('{z}/{x}/{y}." & ext & "', options).addTo(map)" + vbCrLf)
        T.Append("      }" + vbCrLf)
        T.Append("    </script>" + vbCrLf)
        T.Append("    <style>" & vbCrLf)
        T.Append("      body { margin:0; padding:0; }" & vbCrLf)
        T.Append("      #map { position:absolute; top:0; bottom:0; width:100%; }" & vbCrLf)
        T.Append("    </style>" & vbCrLf)
        T.Append("  </head>" & vbCrLf)
        T.Append("  <body onload='init()'>" & vbCrLf)
        T.Append("    <div id='map'></div>" & vbCrLf)
        T.Append("    </div>" & vbCrLf)
        T.Append("  </body>" & vbCrLf)
        T.Append("</html>" & vbCrLf)

        Dim leafletfile_Path As String = Folder & "\leaflet_sample.html"
        Dim sw2 As New System.IO.StreamWriter(leafletfile_Path, False, System.Text.Encoding.GetEncoding("utf-8"))
        sw2.Write(T.ToString)
        sw2.Close()


    End Function
    Private Sub Help_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "frmPrint_TileMapOut", Me)
    End Sub

End Class