Public Class frmMark_Set

    Dim Mark As Mark_Property
    Dim attrData As clsAttrData
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="MarkO"></param>
    ''' <param name="ScData"></param>
    ''' <param name="_basePic">_basePic.pictureが-1の場合は画像選択しない</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal MarkO As Mark_Property, ByRef _attrData As clsAttrData) As Windows.Forms.DialogResult
        attrData = _attrData
        Mark = MarkO
        If attrData.TotalData.BasePicture.PictureNum = -1 Then
            '_basePic.pictureが-1の場合は画像選択しない
            rbPicture.Enabled = False
        End If
        cboSize.Items.Clear()
        cboSize.Items.Add(FormatNumber(0.2, 1))
        For si As Single = 0.5 To 5 Step 0.5
            cboSize.Items.Add(FormatNumber(si, 1))
        Next
        For i As Integer = 6 To 20
            cboSize.Items.Add(FormatNumber(i, 1))
        Next

        With Mark
            cboSize.Text = .WordFont.Body.Size
            txtWordMark.Font = New Font(.WordFont.Body.Name, txtWordMark.Font.Size)
            txtWordMark.Text = .wordmark
            txtKakudo.Text = .WordFont.Body.Kakudo
            Select Case .PrintMark
                Case enmMarkPrintType.Mark
                    rbMark.Checked = True
                Case enmMarkPrintType.Word
                    rbWord.Checked = True
                Case enmMarkPrintType.Picture
                    rbPicture.Checked = True

            End Select
            clsDrawLine.Draw_Sample_LineBox(picFrameLine, .Line, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End With
        Draw_Sample()
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        Return Me.ShowDialog()
    End Function
    Public Function getResult() As Mark_Property
        Mark.wordmark = txtWordMark.Text
        Mark.WordFont.Body.Size = Val(cboSize.Text)

        Return Mark
    End Function

    Private Sub Draw_Sample()
        Select Case True
            Case rbMark.Checked
                clsDrawMarkFan.Draw_Mark_Sample_Box(picMark, Mark, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
                clsDrawTile.Draw_Sample_TileBox(picInnerTile, Mark.Tile, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
                picInnerColor.Visible = False
                picInnerTile.Visible = True
            Case rbWord.Checked
                picInnerColor.BackColor = Mark.Tile.Line.BasicLine.SolidLine.Color.getColor
                txtWordMark.ForeColor = Mark.Tile.Line.BasicLine.SolidLine.Color.getColor
                picInnerColor.Visible = True
                picInnerTile.Visible = False
            Case rbPicture.Checked
                Dim picmk As Mark_Property = clsBase.Mark
                picInnerColor.BackColor = Mark.Tile.Line.BasicLine.SolidLine.Color.getColor
                picInnerColor.Visible = True
                picInnerTile.Visible = False
                If Mark.PictureNumber = -1 Then
                    picmk.PrintMark = enmMarkPrintType.Word
                    picmk.wordmark = "×"
                    picmk.WordFont.Body.Color = New colorARGB(Color.Black)
                Else
                    picmk = Mark
                End If
                clsDrawMarkFan.Draw_Mark_Sample_Box(picGazo, picmk, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End Select
        
        clsDrawTile.Darw_Sample_BackGroundBox(picBack, Mark.WordFont.Back, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        clsDrawLine.Draw_Sample_LineBox(picFrameLine, Mark.Line, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
    End Sub

    Private Sub rbMark_CheckedChanged(sender As Object, e As EventArgs) Handles rbMark.CheckedChanged, rbWord.CheckedChanged, rbPicture.CheckedChanged
        pnlMark.Visible = rbMark.Checked
        pnlPicture.Visible = rbPicture.Checked
        pnlWord.Visible = rbWord.Checked
        Select Case True
            Case rbMark.Checked
                Mark.PrintMark = enmMarkPrintType.Mark
            Case rbWord.Checked
                Mark.PrintMark = enmMarkPrintType.Word
            Case rbPicture.Checked
                Mark.PrintMark = enmMarkPrintType.Picture
        End Select
        Draw_Sample()
    End Sub


    Private Sub picBGColor_Click(sender As Object, e As EventArgs) Handles picBack.Click
        If clsGeneric.BackGround_Setting(Mark.WordFont.Back, attrData) = True Then
            Draw_Sample()
        End If
    End Sub

    Private Sub txtKakudo_LostFocus(sender As Object, e As EventArgs) Handles txtKakudo.LostFocus
        Dim V As Integer = Val(txtKakudo.Text)
        txtKakudo.Text = V
        Mark.WordFont.Body.Kakudo = V
        Draw_Sample()
    End Sub



    Private Sub picFrameLine_Click(sender As Object, e As EventArgs) Handles picFrameLine.Click
        If clsGeneric.Line_Pattern_select(Mark.Line, True, attrData) = True Then
            Draw_Sample()
        End If
    End Sub

    Private Sub cboSize_LostFocus(sender As Object, e As EventArgs) Handles cboSize.LostFocus, cboSize.SelectedIndexChanged
        Dim a As Single = Val(cboSize.Text)
        If a <= 0 Then a = 0.5
        If a > 30 Then a = 30
        cboSize.Text = a
        Mark.WordFont.Body.Size = a
        Draw_Sample()
    End Sub


    Private Sub picInnerColor_Click(sender As Object, e As EventArgs) Handles picInnerColor.Click
        If clsGeneric.Color_Set(Mark.Tile.Line.BasicLine.SolidLine.Color) = True Then
            Mark.WordFont.Body.Color = Mark.Tile.Line.BasicLine.SolidLine.Color
            Draw_Sample()
        End If
    End Sub

    Private Sub picInnerTile_Click(sender As Object, e As EventArgs) Handles picInnerTile.Click
        If clsGeneric.Tile_Set(Mark.Tile, attrData) = True Then
            clsDrawTile.Draw_Sample_TileBox(picInnerTile, Mark.Tile, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
            Mark.WordFont.Body.Color = Mark.Tile.Line.BasicLine.SolidLine.Color
            Draw_Sample()
        End If

    End Sub

    Private Sub picMark_Click(sender As Object, e As EventArgs) Handles picMark.Click
        Dim form As New frmMark_Select
        If form.ShowDialog(attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture) = Windows.Forms.DialogResult.OK Then
            Mark.ShapeNumber = form.getResult
            Draw_Sample()
        End If
        form.Dispose()
    End Sub

    Private Sub btnFont_Click(sender As Object, e As EventArgs) Handles btnFont.Click
        If clsGeneric.Font_select(Mark.WordFont, attrData) = True Then
            cboSize.Text = Mark.WordFont.Body.Size
            Mark.Tile.Line.BasicLine.SolidLine.Color = Mark.WordFont.Body.Color
            Draw_Sample()
        End If
    End Sub

    Private Sub picGazo_Click(sender As Object, e As EventArgs) Handles picGazo.Click
        Dim n As Integer = clsGeneric.Select_Picture(attrData, Mark.PictureNumber)
        If n <> -1 Then
            Mark.PictureNumber = n
            Draw_Sample()
        End If
    End Sub

    Private Sub btnGazoClear_Click(sender As Object, e As EventArgs) Handles btnGazoClear.Click
        Mark.PictureNumber = -1
        Draw_Sample()
    End Sub

    Private Sub btnImageAlphaValue_Click(sender As Object, e As EventArgs) Handles btnImageAlphaValue.Click
        If clsGeneric.Set_AlphaValueForm(Mark.PictureAlpahValue) = True Then
            Draw_Sample()
        End If
    End Sub
End Class