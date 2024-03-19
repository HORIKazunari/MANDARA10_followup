Imports System.Drawing
Imports System.IO
Public Class frmPrint_SeriesFileOut
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
    Public Overloads Function ShowDialog(_attr As clsAttrData) As Windows.Forms.DialogResult
        attr = _attr
        txtHTML.Text = "index.html"
        txtComaInterval.Text = "0.5"
        txtLastComa.Text = "0.5"
        txtFirstComa.Text = "0.5"
        rbImage.Checked = True
        rbPNG.Checked = True
        txtBaseImageFileName.Text = "image"
        FolderSelect.Folder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        GIFFileSelect.InitFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)

        Dim frm As frmPrint = CType(Me.Owner, frmPrint)

        Return Me.ShowDialog

    End Function
    Public Function GetResults()

    End Function


    Private Sub rbImage_CheckedChanged(sender As Object, e As EventArgs) Handles rbImage.CheckedChanged, rbWebImageAnime.CheckedChanged,
        rbWebImageChange.CheckedChanged, rbAnimatedGIF.CheckedChanged
        gbImageFormat.Visible = False
        GIFFileSelect.Visible = False
        FolderSelect.Visible = False
        gbHtml.Visible = False
        gbComaInterval.Visible = False
        gbBaseImageFileName.Visible = False
        rbEMF.Enabled = False
        Select Case True
            Case rbImage.Checked
                gbImageFormat.Visible = True
                FolderSelect.Visible = True
                gbBaseImageFileName.Visible = True
                rbEMF.Enabled = True
            Case rbWebImageAnime.Checked
                gbImageFormat.Visible = True
                FolderSelect.Visible = True
                gbBaseImageFileName.Visible = True
                gbComaInterval.Visible = True
                gbHtml.Visible = True
                rbPNG.Checked = True
            Case rbWebImageChange.Checked
                gbImageFormat.Visible = True
                FolderSelect.Visible = True
                gbHtml.Visible = True
                gbBaseImageFileName.Visible = True
                rbPNG.Checked = True
            Case rbAnimatedGIF.Checked
                GIFFileSelect.Visible = True
                gbComaInterval.Visible = True
        End Select

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If txtBaseImageFileName.Text = "" And gbBaseImageFileName.Visible = True Then
            MsgBox("ベース画像ファイル名を設定してください。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
        If gbHtml.Visible = True Then
            If System.IO.File.Exists(FolderSelect.Folder + "\" + txtHTML.Text) = True Then
                If MsgBox(txtHTML.Text + "を上書きします。", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                    CloseCancelF = True
                    Return
                End If
            End If
        End If
        If rbAnimatedGIF.Checked = True Then
            If clsGeneric.Check_Folder_Exists(GIFFileSelect.Path) = False Then
                CloseCancelF = True
                Return
            End If
        End If
        Dim oldKoma As Integer = attr.TempData.Series_temp.Koma
        Dim frm As frmPrint = CType(Me.Owner, frmPrint)
        Dim setn As Integer = attr.TotalData.TotalMode.Series.SelectedIndex
        Dim n As Integer = attr.TotalData.TotalMode.Series.DataSet(setn).DataItem.Count
        Dim picSize As Size = attr.TotalData.ViewStyle.ScrData.frmPrint_FormSize.Size
        Dim giffile As String
        If rbAnimatedGIF.Checked = False Then
            For i As Integer = 0 To n - 1
                Dim ImageFormat As System.Drawing.Imaging.ImageFormat
                Dim FileName As String = FolderSelect.Folder & "\" & Get_Out_FileName(i, n, ImageFormat)
                attr.TempData.Series_temp.Koma = i
                If rbEMF.Checked = False Or rbAnimatedGIF.Checked = True Then
                    Dim canvas As New Bitmap(picSize.Width, picSize.Height)
                    Dim g As Graphics = Graphics.FromImage(canvas)
                    If rbJpeg.Checked = True Or rbBMP.Checked = True Then
                        g.FillRectangle(New SolidBrush(Color.White), New Rectangle(0, 0, canvas.Width, canvas.Height))
                    End If
                    frm.Series_Mapping(g, ToolStripProgressBar, True)
                    g.Dispose()
                    canvas.Save(FileName, ImageFormat)
                    canvas.Dispose()
                Else
                    clsGeneric.SaveEMFFile(FileName, attr, ToolStripProgressBar, frm)
                End If

            Next
        Else
            Dim Canvas(n - 1) As Bitmap
            For i As Integer = 0 To n - 1
                Dim ImageFormat As System.Drawing.Imaging.ImageFormat
                Dim FileName As String = FolderSelect.Folder & "\" & Get_Out_FileName(i, n, ImageFormat)
                attr.TempData.Series_temp.Koma = i
                Canvas(i) = New Bitmap(picSize.Width, picSize.Height)
                Dim g As Graphics = Graphics.FromImage(Canvas(i))
                g.FillRectangle(New SolidBrush(Color.White), New Rectangle(0, 0, Canvas(i).Width, Canvas(i).Height))
                frm.Series_Mapping(g, ToolStripProgressBar, True)
                g.Dispose()
            Next
            giffile = clsGeneric.ReplaceFileExtention(GIFFileSelect.Path, "gif")
            SaveAnimatedGif(giffile, Canvas, Val(txtFirstComa.Text) * 100, Val(txtComaInterval.Text) * 100, Val(txtLastComa.Text) * 100, 0)
            For i As Integer = 0 To n - 1
                Canvas(i).Dispose()
            Next
        End If
        attr.TempData.Series_temp.Koma = oldKoma
        Select Case True
            Case rbWebImageAnime.Checked
                Out_WebAnimation()
                System.Diagnostics.Process.Start(FolderSelect.Folder)
            Case rbWebImageChange.Checked
                Out_WebImageChange()
                System.Diagnostics.Process.Start(FolderSelect.Folder)
            Case rbImage.Checked
                MsgBox(FolderSelect.Folder + "に出力しました。")
                System.Diagnostics.Process.Start(FolderSelect.Folder)
            Case rbAnimatedGIF.Checked
                MsgBox(giffile + "に出力しました。")
                System.Diagnostics.Process.Start(giffile)
        End Select
    End Sub
    Private Function Out_WebAnimation() As Boolean
   

        Dim picSize As Size = attr.TotalData.ViewStyle.ScrData.frmPrint_FormSize.Size

        Dim setn As Integer = attr.TotalData.TotalMode.Series.SelectedIndex
        Dim n As Integer = attr.TotalData.TotalMode.Series.DataSet(setn).DataItem.Count
        Dim Num As String = n.ToString
        Dim fna As String
        If Microsoft.VisualBasic.Right(FolderSelect.Folder, 1) = "\" Then
            fna = FolderSelect.Folder & txtHTML.Text
        Else
            fna = FolderSelect.Folder & "\" & txtHTML.Text
        End If

        Dim T As New System.Text.StringBuilder()

        Dim ImageFormat As System.Drawing.Imaging.ImageFormat
        T.Append("<HTML>" + vbCrLf)
        T.Append("<HEAD>" + vbCrLf)
        T.Append("<SCRIPT language='JavaScript'>" + vbCrLf)
        T.Append("<!--" + vbCrLf)
        T.Append("" + vbCrLf)
        T.Append("a1=new Array();w1=new Array();c1=0;for(i=0;i<" & Num$ & ";i++){a1[i]=new Image()}" + vbCrLf)
        For i As Integer = 0 To n - 1
            T.Append("a1[" & i & "].src='" & Get_Out_FileName(i, n, ImageFormat) & "';" + vbCrLf)
            Dim dtime As String
            Select Case i
                Case 0
                    dtime = txtFirstComa.Text
                Case n - 1
                    dtime = txtLastComa.Text
                Case Else
                    dtime = txtComaInterval.Text
            End Select
            T.Append("w1[" & i & "]=" & Val(dtime) * 1000 & ";" + vbCrLf)
        Next
        T.Append("function fa1(){document.anm1.src=a1[c1].src;setTimeout('fa1()',w1[c1]);c1++;if(c1>=a1.length){c1=0;}}" + vbCrLf)
        T.Append("//-->" + vbCrLf)
        T.Append("</SCRIPT>" + vbCrLf)
        T.Append("</HEAD>" + vbCrLf)
        T.Append("<BODY onLoad='fa1()'>" + vbCrLf)
        T.Append("<TABLE>" + vbCrLf)
        T.Append("<TR>" + vbCrLf)
        T.Append("<TD>" + vbCrLf)
        T.Append("<img src='" & Get_Out_FileName(0, n, ImageFormat) & "' name='anm1' width=" & CStr(picSize.Width) & " height=" & CStr(picSize.Height) & ">" + vbCrLf)
        T.Append("</TD>" + vbCrLf)
        T.Append("</TR>" + vbCrLf)
        T.Append("<TR>" + vbCrLf)
        T.Append("<TD ALIGN=CENTER>" + vbCrLf)
        T.Append(attr.TotalData.TotalMode.Series.DataSet(setn).title + vbCrLf)
        T.Append("</TD>" + vbCrLf)
        T.Append("</TR>" + vbCrLf)
        T.Append("<BR>" + vbCrLf)
        T.Append("</TABLE>" + vbCrLf)
        T.Append("</BODY>" + vbCrLf)
        T.Append("</HTML>" + vbCrLf)

        Try
            Dim sw As New System.IO.StreamWriter(fna, False, System.Text.Encoding.GetEncoding("utf-8"))
            sw.Write(T.ToString)
            sw.Close()
            MsgBox(FolderSelect.Folder + "に出力しました。")
            System.Diagnostics.Process.Start(FolderSelect.Folder)
        Catch ex As Exception
            MsgBox(fna & "が作成できませんでした。", MsgBoxStyle.Exclamation)
        End Try


    End Function

    Private Function Out_WebImageChange() As Boolean
        Dim picSize As Size = attr.TotalData.ViewStyle.ScrData.frmPrint_FormSize.Size


        Dim setn As Integer = attr.TotalData.TotalMode.Series.SelectedIndex
        Dim n As Integer = attr.TotalData.TotalMode.Series.DataSet(setn).DataItem.Count
        Dim Num As String = n.ToString
        Dim fna As String
        If Microsoft.VisualBasic.Right(FolderSelect.Folder, 1) = "\" Then
            fna = FolderSelect.Folder & txtHTML.Text
        Else
            fna = FolderSelect.Folder & "\" & txtHTML.Text
        End If

        Dim T As New System.Text.StringBuilder()
        Dim DBQ As String = Chr(34)
        Dim ImageFormat As System.Drawing.Imaging.ImageFormat
        T.Append("<HTML>" + vbCrLf)
        T.Append("<HEAD>" + vbCrLf)
        T.Append("<meta http-equiv=" & DBQ & "Content-Type" & DBQ & " content=" & DBQ & "text/html" & ";" & " charset=shift_jis" & DBQ & ">" + vbCrLf)
        T.Append("<SCRIPT language='JavaScript'>" + vbCrLf)
        T.Append("<!--" + vbCrLf)
        T.Append("" + vbCrLf)
        T.Append("a1=new Array();for(i=0;i<" & Num$ & ";i++){" + vbCrLf + "a1[i]=new Image();" + vbCrLf + "}" + vbCrLf)
        For i As Integer = 0 To n - 1
            T.Append("a1[" & i & "].src='" & Get_Out_FileName(i, n, ImageFormat) & "';" + vbCrLf)
        Next
        T.Append("function cngImage(num){document.img01.src=a1[num].src;}" + vbCrLf)
        T.Append("//-->" + vbCrLf)
        T.Append("</SCRIPT>" + vbCrLf)
        T.Append("<STYLE type=text/css>" + vbCrLf)
        T.Append("A:link{ color : blue}" + vbCrLf)
        T.Append("A:active{ color : blue}" + vbCrLf)
        T.Append("A:visited{ color : blue}" + vbCrLf)
        T.Append("A:hover{color: red}" + vbCrLf)
        T.Append("</STYLE>" + vbCrLf)
        T.Append("</HEAD>" + vbCrLf)
        T.Append("<BODY>" + vbCrLf)
        T.Append("<TABLE>" + vbCrLf)
        T.Append("<TR>" + vbCrLf)
        T.Append("<TD>" + vbCrLf)
        T.Append("<img src='" & Get_Out_FileName(0, n, ImageFormat) & "' name='img01' width=" & CStr(picSize.Width) & " height=" & CStr(picSize.Height) & ">" + vbCrLf)
        T.Append("</TD>" + vbCrLf)
        T.Append("<TD>" + vbCrLf)
        With attr.TotalData.TotalMode.Series.DataSet(setn)
            For i As Integer = 0 To n - 1
                Dim TTL As String
                With .DataItem(i)
                    Select Case .Print_Mode_Total
                        Case enmTotalMode_Number.DataViewMode
                            Select Case .Print_Mode_Layer
                                Case enmLayerMode_Number.SoloMode
                                    TTL = attr.Get_DataTitle(.Layer, .Data, False)
                                Case enmLayerMode_Number.GraphMode
                                    TTL = attr.LayerData(.Layer).LayerModeViewSettings.GraphMode.DataSet(.Data).title
                                Case enmLayerMode_Number.LabelMode
                                Case enmLayerMode_Number.TripMode
                            End Select
                        Case enmTotalMode_Number.OverLayMode
                            TTL = attr.TotalData.TotalMode.OverLay.DataSet(.Data).title
                    End Select
                End With
                T.Append("<A href='javascript:void(0)' onmouseover='cngImage(" + i.ToString + ")'>" & TTL & "</A><BR>" + vbCrLf)
            Next
        End With

        T.Append("</TD>" + vbCrLf)
        T.Append("</TR>" + vbCrLf)
        T.Append("<TR>" + vbCrLf)
        T.Append("<TD COLSPAN=2 ALIGN=CENTER>" + vbCrLf)
        T.Append(attr.TotalData.TotalMode.Series.DataSet(setn).title)
        T.Append("</TD>" + vbCrLf)
        T.Append("</TR>" + vbCrLf)
        T.Append("</TABLE>" + vbCrLf)
        T.Append("</BODY>" + vbCrLf)
        T.Append("</HTML>" + vbCrLf)

        Try
            Dim sw As New System.IO.StreamWriter(fna, False, System.Text.Encoding.GetEncoding("utf-8"))
            sw.Write(T.ToString)
            sw.Close()
            MsgBox(FolderSelect.Folder + "に出力しました。")
            System.Diagnostics.Process.Start(FolderSelect.Folder)
        Catch ex As Exception
            MsgBox(fna & "が作成できませんでした。", MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function Get_Out_FileName(ByVal Number As Integer, ByVal Max_n As Integer, ByRef ImageFormat As System.Drawing.Imaging.ImageFormat) As String
        Dim form As System.Drawing.Imaging.ImageFormat
        Dim ext As String
        Select Case True
            Case rbPNG.Checked
                ext = "png"
                ImageFormat = System.Drawing.Imaging.ImageFormat.Png
            Case rbBMP.Checked
                ext = "bmp"
                ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp
            Case rbJpeg.Checked
                ext = "jpg"
                ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
            Case rbEMF.Checked
                ext = "emf"
                ImageFormat = System.Drawing.Imaging.ImageFormat.Emf
        End Select
        Dim k As Integer = Len(CStr(Max_n))
        Return txtBaseImageFileName.Text & "_" & Microsoft.VisualBasic.Right(New String("0", k) & CStr(Number), k) & "." & ext

    End Function


    ''' <summary>
    ''' 複数の画像をGIFアニメーションとして保存する
    ''' </summary>
    ''' <param name="fileName">保存先のファイルのパス。</param>
    ''' <param name="baseImages">GIFアニメにする画像。</param>
    ''' <param name="delayTime">遅延時間（100分の1秒単位）。</param>
    ''' <param name="loopCount">繰り返す回数。0で無限。</param>
    Public Shared Sub SaveAnimatedGif(ByVal fileName As String, _
                                      ByVal baseImages As Bitmap(), _
                                      ByVal firstComaDelayTime As UInt16, ByVal MidiComaDelayTime As UInt16, ByVal LastComaDelayTime As UInt16,
                                      ByVal loopCount As UInt16)
        '書き込み先のファイルを開く
        Dim writerFs As New FileStream(fileName, _
            FileMode.Create, FileAccess.Write, FileShare.None)
        'BinaryWriterで書き込む
        Dim writer As New BinaryWriter(writerFs)

        Dim ms As New MemoryStream()
        Dim hasGlobalColorTable As Boolean = False
        Dim colorTableSize As Integer = 0

        Dim imagesCount As Integer = baseImages.Length
        For i As Integer = 0 To imagesCount - 1
            '画像をGIFに変換して、MemoryStreamに入れる
            Dim bmp As Bitmap = baseImages(i)
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
            ms.Position = 0

            If i = 0 Then
                'ヘッダを書き込む
                'Header
                writer.Write(ReadBytes(ms, 6))

                'Logical Screen Descriptor
                Dim screenDescriptor As Byte() = ReadBytes(ms, 7)
                'Global Color Tableがあるか確認
                If (screenDescriptor(4) And &H80) <> 0 Then
                    'Color Tableのサイズを取得
                    colorTableSize = screenDescriptor(4) And &H7
                    hasGlobalColorTable = True
                Else
                    hasGlobalColorTable = False
                End If
                'Global Color Tableを使わない
                '広域配色表フラグと広域配色表の寸法を消す
                screenDescriptor(4) = CByte(screenDescriptor(4) And &H78)
                writer.Write(screenDescriptor)

                'Application Extension
                writer.Write(GetApplicationExtension(loopCount))
            Else
                'HeaderとLogical Screen Descriptorをスキップ
                ms.Position += 6 + 7
            End If

            Dim colorTable As Byte() = Nothing
            If hasGlobalColorTable Then
                'Color Tableを取得
                colorTable = ReadBytes(ms, CInt(Math.Pow(2, colorTableSize + 1)) * 3)
            End If

            'Graphics Control Extension
            Dim delayTime As UInt16
            Select Case i
                Case 0
                    delayTime = firstComaDelayTime
                Case imagesCount - 1
                    delayTime = LastComaDelayTime
                Case Else
                    delayTime = MidiComaDelayTime
            End Select
            writer.Write(GetGraphicControlExtension(delayTime))
            '基のGraphics Control Extensionをスキップ
            If ms.GetBuffer()(ms.Position) = &H21 Then
                ms.Position += 8
            End If

            'Image Descriptor
            Dim imageDescriptor As Byte() = ReadBytes(ms, 10)
            If Not hasGlobalColorTable Then
                'Local Color Tableを持っているか確認
                If (imageDescriptor(9) And &H80) = 0 Then
                    Throw New Exception("Not found color table.")
                End If
                'Color Tableのサイズを取得
                colorTableSize = imageDescriptor(9) And 7
                'Color Tableを取得
                colorTable = ReadBytes(ms, CInt(Math.Pow(2, colorTableSize + 1)) * 3)
            End If
            '狭域配色表フラグ (Local Color Table Flag) と狭域配色表の寸法を追加
            imageDescriptor(9) = CByte(imageDescriptor(9) Or &H80 Or colorTableSize)
            writer.Write(imageDescriptor)

            'Local Color Tableを書き込む
            writer.Write(colorTable)

            'Image Dataを書き込む (終了部は書き込まない)
            writer.Write(ReadBytes(ms, CInt(ms.Length - ms.Position - 1)))

            If i = imagesCount - 1 Then
                '終了部 (Trailer)
                writer.Write(CByte(&H3B))
            End If

            'MemoryStreamをリセット
            ms.SetLength(0)
        Next

        '後始末
        ms.Close()
        writer.Close()
        writerFs.Close()
    End Sub

    ''' <summary>
    ''' MemoryStreamの現在の位置から指定されたサイズのバイト配列を読み取る
    ''' </summary>
    ''' <param name="ms">読み取るMemoryStream</param>
    ''' <param name="count">読み取るバイトのサイズ</param>
    ''' <returns>読み取れたバイト配列</returns>
    Private Shared Function ReadBytes(ByVal ms As MemoryStream, _
                                      ByVal count As Integer) As Byte()
        Dim bs As Byte() = New Byte(count - 1) {}
        ms.Read(bs, 0, count)
        Return bs
    End Function

    ''' <summary>
    ''' Netscape Application Extensionブロックを返す。
    ''' </summary>
    ''' <param name="loopCount">繰り返す回数。0で無限。</param>
    ''' <returns>Netscape Application Extensionブロックのbyte配列。</returns>
    Private Shared Function GetApplicationExtension(ByVal loopCount As UInt16) _
            As Byte()
        Dim bs As Byte() = New Byte(18) {}

        '拡張導入符 (Extension Introducer)
        bs(0) = &H21
        'アプリケーション拡張ラベル (Application Extension Label)
        bs(1) = &HFF
        'ブロック寸法 (Block Size)
        bs(2) = &HB
        'アプリケーション識別名 (Application Identifier)
        bs(3) = CByte(AscW("N"c))
        bs(4) = CByte(AscW("E"c))
        bs(5) = CByte(AscW("T"c))
        bs(6) = CByte(AscW("S"c))
        bs(7) = CByte(AscW("C"c))
        bs(8) = CByte(AscW("A"c))
        bs(9) = CByte(AscW("P"c))
        bs(10) = CByte(AscW("E"c))
        'アプリケーション確証符号 (Application Authentication Code)
        bs(11) = CByte(AscW("2"c))
        bs(12) = CByte(AscW("."c))
        bs(13) = CByte(AscW("0"c))
        'データ副ブロック寸法 (Data Sub-block Size)
        bs(14) = &H3
        '詰め込み欄 [ネットスケープ拡張コード (Netscape Extension Code)]
        bs(15) = &H1
        '繰り返し回数 (Loop Count)
        Dim loopCountBytes As Byte() = BitConverter.GetBytes(loopCount)
        bs(16) = loopCountBytes(0)
        bs(17) = loopCountBytes(1)
        'ブロック終了符 (Block Terminator)
        bs(18) = &H0

        Return bs
    End Function

    ''' <summary>
    ''' Graphic Control Extensionブロックを返す。
    ''' </summary>
    ''' <param name="delayTime">遅延時間（100分の1秒単位）。</param>
    ''' <returns>Graphic Control Extensionブロックのbyte配列。</returns>
    Private Shared Function GetGraphicControlExtension(ByVal delayTime As UInt16) _
            As Byte()
        Dim bs As Byte() = New Byte(7) {}

        '拡張導入符 (Extension Introducer)
        bs(0) = &H21
        'グラフィック制御ラベル (Graphic Control Label)
        bs(1) = &HF9
        'ブロック寸法 (Block Size, Byte Size)
        bs(2) = &H4
        '詰め込み欄 (Packed Field)
        '透過色指標を使う時は+1
        '消去方法:そのまま残す+4、背景色でつぶす+8、直前の画像に戻す+12
        bs(3) = &H0
        '遅延時間 (Delay Time)
        Dim delayTimeBytes As Byte() = BitConverter.GetBytes(delayTime)
        bs(4) = delayTimeBytes(0)
        bs(5) = delayTimeBytes(1)
        '透過色指標 (Transparency Index, Transparent Color Index)
        bs(6) = &H0
        'ブロック終了符 (Block Terminator)
        bs(7) = &H0

        Return bs
    End Function
    Private Sub Help_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "frmPrint_SeriesFileOut", Me)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub
End Class