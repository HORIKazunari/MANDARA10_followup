Public Class frmPictureSelector
    Dim attrData As clsAttrData
    Dim SelectNumber As Integer
    Private picBox() As System.Windows.Forms.PictureBox
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData, ByVal FirstSelect As Integer) As Windows.Forms.DialogResult
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        attrData = _attrData
        SelectNumber = FirstSelect
        With cboTransRange
            .Items.Clear()
            For i As Integer = 0 To 10
                .Items.Add(i)
            Next
        End With
        DrawPictureList()
        Return Me.ShowDialog()
    End Function
    Public Function getResult() As Integer
        Return SelectNumber
    End Function
    Private Sub DrawPictureList()
        If Me.picBox Is Nothing = False Then
            For Each p As PictureBox In Me.picBox
                RemoveHandler p.Click, AddressOf picBoxClick
                Me.pnlPictureList.Controls.Remove(p)
            Next
        End If
        Dim HorNum As Integer = 3
        With attrData.TotalData.BasePicture

            Dim n As Integer = .PictureNum
            If n = 0 Then
                Return
            End If
            pnlPictureList.Width = pnlPictureBase.Width - SystemInformation.VerticalScrollBarWidth - 3
            Dim Boxsize As Integer = (pnlPictureList.Width - 5 * (HorNum + 1)) \ HorNum
            pnlPictureList.Height = ((n \ HorNum) + 1) * (Boxsize + 5) + 5
            Me.picBox = New PictureBox(n - 1) {}

            For i As Integer = 0 To n - 1
                Me.picBox(i) = New System.Windows.Forms.PictureBox
                With Me.picBox(i)
                    .Parent = pnlPictureList
                    .Top = (i \ HorNum) * (Boxsize + 5) + 5
                    .Height = Boxsize - 6
                    .Left = (i Mod HorNum) * (Boxsize + 5) + 5
                    .Width = Boxsize
                    .Tag = i
                    .BorderStyle = BorderStyle.FixedSingle
                    AddHandler .Click, AddressOf picBoxClick
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Image = attrData.TotalData.BasePicture.PictureData.Item(i).GetBitmap
                End With
            Next
            SelectPicture()
            pnlTransparency.BorderStyle = BorderStyle.FixedSingle
            pnlInnerColor.BorderStyle = BorderStyle.None
            If SelectNumber <> -1 Then
                Me.picBox(SelectNumber).Focus()

            End If
        End With
    End Sub

    Private Sub picBoxClick(ByVal sender As Object, ByVal e As System.EventArgs)
        SelectNumber = sender.tag

        For i As Integer = 0 To attrData.TotalData.BasePicture.PictureNum - 1
            Me.picBox(i).BorderStyle = BorderStyle.FixedSingle
        Next
        SelectPicture()
    End Sub
    Private Sub SelectPicture()
        Dim f As Boolean = False
        Dim tx As String
        If SelectNumber <> -1 Then
            Me.picBox(SelectNumber).BorderStyle = BorderStyle.Fixed3D
            picSelectedImage.Image = attrData.TotalData.BasePicture.PictureData.Item(SelectNumber).GetBitmap
            Dim picP As Picture_Property = DirectCast(attrData.TotalData.BasePicture.PictureData(SelectNumber), Picture_Property)
            With picP
                chkTransparencyColor.Checked = .TransParency_f
                chkInnerColor.Checked = .Alternate_f
                picTransparancyColor.BackColor = .TransParency_Color.getColor
                picInnerColor.BackColor = .Alternate_Color.getColor
                tx = "幅:" & .Size.Width.ToString & "ピクセル" + vbCrLf + "高さ:" + .Size.Height.ToString & "ピクセル" + vbCrLf
                Dim tx2 As String = Check_Picture_Use(SelectNumber)
                If tx2 <> "" Then
                    tx += "この画像は以下の図形で使用されています" + vbCrLf + tx2
                End If
                cboTransRange.Text = .TransRange
            End With
            f = True

        End If
        txtInfo.Text = tx
        pnlInfo.Visible = f
    End Sub
    Private Function Check_Picture_Use(ByVal Num As Integer) As String
        Dim a2 As String = ""
        Dim a As String = ""
        For i As Integer = 0 To attrData.TotalData.FigureStac.Count - 1
            Dim FigStac As Object = attrData.TotalData.FigureStac(i)
            Select Case True
                Case TypeOf FigStac Is clsAttrData.strFig_Word_Data
                    Dim FigData As clsAttrData.strFig_Word_Data = DirectCast(FigStac, clsAttrData.strFig_Word_Data)
                    If Check_Use_FontMark_PicureNumber(FigData.Font, Num) = True Then
                        a2 += "図形モード：文字／図形番号：" & CStr(i) & vbCrLf
                    End If
                Case TypeOf FigStac Is clsAttrData.strFig_Line_Data
                    Dim FigData As clsAttrData.strFig_Line_Data = DirectCast(FigStac, clsAttrData.strFig_Line_Data)
                    If Check_Use_TileMark_PicureNumber(FigData.Tile, Num) = True Then
                        a2 += "図形モード：線／図形番号：" & CStr(i) & vbCrLf
                    End If
                Case TypeOf FigStac Is clsAttrData.strFig_Circle_data
                    Dim FigData As clsAttrData.strFig_Circle_data = DirectCast(FigStac, clsAttrData.strFig_Circle_data)
                    If Check_Use_Mark_PicureNumber(FigData.Mark, Num) Or _
                         Check_Use_TileMark_PicureNumber(FigData.Tile, Num) = True Then
                        a2 += "図形モード：円／図形番号：" & CStr(i) & vbCrLf
                    End If
                Case TypeOf FigStac Is clsAttrData.strFig_Point_Data
                    Dim FigData As clsAttrData.strFig_Point_Data = DirectCast(FigStac, clsAttrData.strFig_Point_Data)
                    If Check_Use_Mark_PicureNumber(FigData.Mark, Num) = True Or _
                         Check_Use_FontMark_PicureNumber(FigData.Font, Num) = True Then
                        a2 += "図形モード：点／図形番号：" & CStr(i) & vbCrLf
                    End If
                Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                    Dim FigData As clsAttrData.strFig_gazo_data = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                    If FigData.PictureNumber = Num Then
                        a2 += "図形モード：画像／図形番号：" & CStr(i) & vbCrLf
                    End If
            End Select
        Next
        a = a & a2

        a2 = ""
        For i As Integer = 0 To attrData.TotalData.LV1.Lay_Maxn - 1
            For j As Integer = 0 To attrData.LayerData(i).atrData.Count - 1
                With attrData.LayerData(i).atrData.Data(j)
                    If .DataType = enmAttDataType.Normal Then
                        If Check_Use_TileMark_PicureNumber(.SoloModeViewSettings.MarkCommon.MinusTile, Num) = True Then
                            a2 += "データ項目：" & .Title & "／記号モードの負の値" & vbCrLf
                        End If
                        If Check_Use_Mark_PicureNumber(.SoloModeViewSettings.MarkBlockMD.Mark, Num) = True Then
                            a2 += "データ項目：" & .Title & "／記号の数モード" & vbCrLf
                        End If
                        If Check_Use_Mark_PicureNumber(.SoloModeViewSettings.MarkSizeMD.Mark, Num) = True  Then
                            a2 += "データ項目：" & .Title & "／記号の大きさモード" & vbCrLf
                        End If
                        If Check_Use_Mark_PicureNumber(.SoloModeViewSettings.MarkTurnMD.Mark, Num) = True Then
                            a2 += "データ項目：" & .Title & "／記号の数モード" & vbCrLf
                        End If
                    End If
                    If .DataType = enmAttDataType.Normal Or .DataType = enmAttDataType.Category Then
                        For k As Integer = 0 To .SoloModeViewSettings.Div_Num - 1
                            If Check_Use_TileMark_PicureNumber(.SoloModeViewSettings.Class_Div(k).TilePat, Num) = True Then
                                a2 += "データ項目：" & .Title & "／ハッチモード" & vbCrLf
                            End If
                            If Check_Use_Mark_PicureNumber(.SoloModeViewSettings.Class_Div(k).ClassMark, Num) = True Then
                                a2 += "データ項目：" & .Title & "／階級記号モード" & vbCrLf
                            End If
                        Next
                    End If
                End With
            Next
            If attrData.LayerData(i).Shape = enmShape.PointShape Then
                If Check_Use_Mark_PicureNumber(attrData.LayerData(i).LayerModeViewSettings.PointLineShape.PointMark, Num) = True Then
                    a2 += "点オブジェクトの表示記号" & vbCrLf
                End If
            End If
            With attrData.LayerData(i).LayerModeViewSettings.LabelMode
                For j As Integer = 0 To .Count - 1
                    With .DataSet(j)
                        If Check_Use_Mark_PicureNumber(.Location_Mark, Num) = True Or _
                             Check_Use_TileMark_PicureNumber(.BorderObjectTile, Num) = True Or _
                             Check_Use_TileMark_PicureNumber(.BorderDataTile, Num) = True Or _
                             Check_Use_FontMark_PicureNumber(.ObjectName_Font, Num) = True Or _
                             Check_Use_FontMark_PicureNumber(.DataValue_Font, Num) = True Or _
                             Check_Use_FontMark_PicureNumber(.Dummy_Object_Font, Num) = True Or _
                             Check_Use_FontMark_PicureNumber(.Dummy_Object_Group_Font, Num) = True Then
                            a2 += "ラベル表示モード：データセット：" & .title & vbCrLf
                        End If
                    End With
                Next
            End With

            With attrData.LayerData(i).LayerModeViewSettings.GraphMode
                For j As Integer = 0 To .Count - 1
                    With .DataSet(j)
                        If Check_Use_TileMark_PicureNumber(.Oresen_Bou.BackgroundTile, Num) = True Then
                            a2 += "グラフ表示モード：データセット：" & .title & vbCrLf
                        End If
                    End With
                Next
            End With
        Next
        a = a & a2

        a2 = ""
        With attrData.TotalData.ViewStyle
            If Check_Use_Mark_PicureNumber(.Missing_Data.BlockMark, Num) = True Or _
                 Check_Use_Mark_PicureNumber(.Missing_Data.Mark, Num) = True Or _
                 Check_Use_Mark_PicureNumber(.Missing_Data.ClassMark, Num) = True Or _
                 Check_Use_Mark_PicureNumber(.Missing_Data.TurnMark, Num) = True Or _
                 Check_Use_TileMark_PicureNumber(.Missing_Data.HatchTile, Num) = True Or _
                 Check_Use_TileMark_PicureNumber(.Missing_Data.PaintTile, Num) = True Then
                a2 += "欠損値の凡例" & vbCrLf
            End If
            If Check_Use_Mark_PicureNumber(.AttMapCompass.Mark, Num) = True Then
                a2 += "方位記号" & vbCrLf
            End If
            With .Trip_Line
                If Check_Use_Mark_PicureNumber(.StartPoint_Mark, Num) = True Or _
                     Check_Use_Mark_PicureNumber(.EndPoint_Mark, Num) = True Or _
                     Check_Use_FontMark_PicureNumber(.TimeLegend_Font, Num) = True Then
                    a2 += "移動データオプション" & vbCrLf
                End If
            End With
            If Check_Use_TileMark_PicureNumber(.MapLegend.Base.Back.Tile, Num) = True Or _
                 Check_Use_FontMark_PicureNumber(.MapLegend.Base.Font, Num) = True Then
                a2 += "凡例のフォント・背景" & vbCrLf
            End If
            If Check_Use_TileMark_PicureNumber(.MapScale.Back.Tile, Num) = True Or _
                 Check_Use_FontMark_PicureNumber(.MapScale.Font, Num) = True Then
                a2 += "スケールのフォント・背景" & vbCrLf
            End If
            If Check_Use_FontMark_PicureNumber(.MapTitle.Font, Num) = True Then
                a2 += "タイトルのフォント" & vbCrLf
            End If
            If Check_Use_TileMark_PicureNumber(.Screen_Back.ScreenAreaBack, Num) = True Or _
                 Check_Use_TileMark_PicureNumber(.Screen_Back.MapAreaBack, Num) = True Or
                 Check_Use_TileMark_PicureNumber(.Screen_Back.ObjectInner, Num) Then
                a2 += "地図の背景" & vbCrLf
            End If
        End With
        For Each d As clsAttrData.strScreen_Setting_Data_Info In attrData.TotalData.ViewStyle.Screen_Setting
            With d
                If Check_Use_TileMark_PicureNumber(.MapScale.Back.Tile, Num) = True Or _
                     Check_Use_Mark_PicureNumber(.AttMapCompass.Mark, Num) = True Or _
                     Check_Use_FontMark_PicureNumber(.MapTitle.Font, Num) = True Or _
                     Check_Use_FontMark_PicureNumber(.MapLegend.Base.Font, Num) = True Or _
                     Check_Use_TileMark_PicureNumber(.MapLegend.Base.Back.Tile, Num) = True Or _
                     Check_Use_FontMark_PicureNumber(.MapScale.Font, Num) = True Then
                    a2 += "画面設定：" & .title & vbCrLf
                End If
            End With
        Next

        a += a2

        Return a
    End Function

  
    Private Function Check_Use_Mark_PicureNumber(ByRef MK As Mark_Property, ByVal CheckNum As Integer) As Boolean
        Dim f As Boolean
        f = False
        With MK
            If .PictureNumber = CheckNum Then
                f = True
            End If
        End With
        Return f
    End Function
    Private Function Check_Use_TileMark_PicureNumber(ByRef TileMK As Tile_Property, ByVal CheckNum As Integer) As Boolean
        Dim f As Boolean
        f = False
        With TileMK.TileMark
            If .PictureNumber = CheckNum Then
                f = True
            End If
        End With
        Return f
    End Function
    Private Function Check_Use_FontMark_PicureNumber(ByRef FontTileMK As Font_Property, ByVal CheckNum As Integer) As Boolean
        Dim f As Boolean
        f = False
        With FontTileMK.Back.Tile.TileMark
            If .PictureNumber = CheckNum Then
                f = True
            End If
        End With
        Return f
    End Function
    Private Sub picInnerColor_Click(sender As Object, e As EventArgs) Handles picInnerColor.Click
        pnlTransparency.BorderStyle = BorderStyle.None
        pnlInnerColor.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub picTransparancyColor_Click(sender As Object, e As EventArgs) Handles picTransparancyColor.Click
        pnlTransparency.BorderStyle = BorderStyle.FixedSingle
        pnlInnerColor.BorderStyle = BorderStyle.None

    End Sub

    Private Sub btnAddFromFile_Click(sender As Object, e As EventArgs) Handles btnAddFromFile.Click
        Dim ofd As New OpenFileDialog
        If clsSettings.Data.Directory.ImageFile = "" Then
            clsSettings.Data.Directory.ImageFile = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        End If
        ofd.InitialDirectory = clsSettings.Data.Directory.ImageFile
        ofd.Filter = "画像ファイル(*.bmp;*.jpg;*.gif;*.png;*.tif)|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif"
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim bmp As Bitmap
            If clsGeneric.Get_BitMap_FromFile(ofd.FileName, bmp) = True Then
                setNewImage(bmp)
            End If
            clsSettings.Data.Directory.ImageFile = System.IO.Path.GetDirectoryName(ofd.FileName)
        End If
    End Sub

    Private Sub btnAddFromClipBoard_Click(sender As Object, e As EventArgs) Handles btnAddFromClipBoard.Click
        Dim clipImage As Bitmap
        Try
            clipImage = DirectCast(Clipboard.GetImage, Bitmap)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
        If clipImage Is Nothing = True Then
            MsgBox("クリップボードから画像を取得できません。", MsgBoxStyle.Exclamation)
        Else
            setNewImage(clipImage)
        End If
    End Sub
    Private Sub setNewImage(ByRef bmp As Bitmap)
        With attrData.TotalData.BasePicture
            .PictureNum += 1
            Dim picP As Picture_Property
            With picP
                .Size = New Size(bmp.Width, bmp.Height)
                .TransParency_Color = New colorARGB(Color.White)
                .Alternate_Color = New colorARGB(Color.White)
                .TransParency_f = False
                .TransRange = 5
                .Alternate_f = False
                .SetBitmap(bmp)
            End With
            .PictureData.Add(picP)
            SelectNumber = .PictureNum - 1
        End With
        DrawPictureList()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim tx As String = Check_Picture_Use(SelectNumber)
        If tx <> "" Then
            MsgBox("この画像は使用されているので削除できません。", MsgBoxStyle.Exclamation)
            Return
        End If
        If MsgBox("選択した画像を削除します。", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            attrData.Renumbering_Picture_Use(SelectNumber + 1, -1)
            With attrData.TotalData.BasePicture
                .PictureNum -= 1
                .PictureData.RemoveAt(SelectNumber)
                If SelectNumber = .PictureNum Then
                    SelectNumber -= 1
                End If
            End With
            DrawPictureList()
        End If
    End Sub


    Private Sub picSelectedImage_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picSelectedImage.MouseDown
        Dim b As Bitmap = picSelectedImage.Image
        If b Is Nothing = True Then
            Return
        End If
        Dim color As Color = b.GetPixel(e.X, e.Y)
        Dim picP As Picture_Property = CType(attrData.TotalData.BasePicture.PictureData(SelectNumber), Picture_Property)
        With picP
            Select Case True
                Case pnlTransparency.BorderStyle = BorderStyle.FixedSingle
                    .TransParency_Color = New colorARGB(color)
                    .TransParency_f = True
                Case pnlInnerColor.BorderStyle = BorderStyle.FixedSingle
                    .Alternate_Color = New colorARGB(color)
                    .Alternate_f = True
            End Select
            attrData.TotalData.BasePicture.PictureData(SelectNumber) = picP
        End With
        SelectPicture()
    End Sub

    Private Sub chkTransparencyColor_CheckedChanged(sender As Object, e As EventArgs) Handles chkTransparencyColor.CheckedChanged
        Dim picP As Picture_Property = DirectCast(attrData.TotalData.BasePicture.PictureData(SelectNumber), Picture_Property)
        picP.TransParency_f = chkTransparencyColor.Checked
        attrData.TotalData.BasePicture.PictureData(SelectNumber) = picP
    End Sub

    Private Sub chkInnerColor_CheckedChanged(sender As Object, e As EventArgs) Handles chkInnerColor.CheckedChanged
        Dim picP As Picture_Property = DirectCast(attrData.TotalData.BasePicture.PictureData(SelectNumber), Picture_Property)
        picP.Alternate_f = chkInnerColor.Checked
        attrData.TotalData.BasePicture.PictureData(SelectNumber) = picP

    End Sub

    Private Sub cboTransRange_LostFocus(sender As Object, e As EventArgs) Handles cboTransRange.LostFocus
        Dim v As Single = Val(cboTransRange.Text)
        If v < 0 Then
            v = 0
        ElseIf v > 10 Then
            v = 10
        End If
        Dim picP As Picture_Property = DirectCast(attrData.TotalData.BasePicture.PictureData(SelectNumber), Picture_Property)
        picP.TransRange = v
        attrData.TotalData.BasePicture.PictureData(SelectNumber) = picP
    End Sub

    Private Sub frmPictureSelector_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SubWindow, "frmPictureSelector", Me)

    End Sub
End Class