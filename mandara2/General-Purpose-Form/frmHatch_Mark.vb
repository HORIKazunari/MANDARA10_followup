Public Class frmHatch_Mark
Dim attrData As clsAttrData
    Dim TMark As Tile_Mark_Property
    Dim InnerColor As colorARGB
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="TileMark"></param>
    ''' <param name="Inner_Color"></param>
    ''' <param name="_attrData">basePic.pictureが-1の場合は画像選択しない</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal TileMark As Tile_Mark_Property, ByVal Inner_Color As colorARGB,
                                         ByRef _attrData As clsAttrData, ByVal pictureFlag As Boolean) As Windows.Forms.DialogResult
        attrData = _attrData
        TMark = TileMark
        If attrData.TotalData.BasePicture.PictureNum = -1 Or pictureFlag = False Then
            '_basePic.pictureが-1の場合は画像選択しない
            rbPicture.Enabled = False
        End If
        InnerColor = Inner_Color
        cboFontName.Items.Clear()
        With cboFontName
            For i As Integer = 0 To clsFontList_inPC.FontFamilyList.GetLength(0) - 1
                cboFontName.Items.Add(clsFontList_inPC.FontFamilyList(i).Name)
            Next
        End With
        With TMark
            cboFontName.Text = .WordFontName
            txtKakudo.Text = .Kakudo
            txtWordMark.Text = .wordmark
            Select Case .PrintMark
                Case enmMarkPrintType.Mark
                    rbMark.Checked = True
                Case enmMarkPrintType.Word
                    rbWord.Checked = True
                Case enmMarkPrintType.Picture
                    rbPicture.Checked = True
            End Select
        End With
        Call Draw_Sample()

        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        Return Me.ShowDialog()
    End Function
    Public Function getResult() As Tile_Mark_Property
        TMark.wordmark = txtWordMark.Text
        TMark.WordFontName = cboFontName.Text
        Select Case True
            Case rbMark.Checked
                TMark.PrintMark = enmMarkPrintType.Mark
            Case rbWord.Checked
                TMark.PrintMark = enmMarkPrintType.Word
            Case rbPicture.Checked
                TMark.PrintMark = enmMarkPrintType.Picture
        End Select
        Return TMark
    End Function

    Private Sub txtKakudo_LostFocus(sender As Object, e As EventArgs) Handles txtKakudo.LostFocus
        Dim V As Integer = Val(txtKakudo.Text)
        txtKakudo.Text = V
        TMark.Kakudo = V
        Draw_Sample()
    End Sub



    Private Sub Draw_Sample()


        Select Case True
            Case rbMark.Checked
                Dim MK As Mark_Property = clsBase.Mark
                With TMark
                    MK.ShapeNumber = .ShapeNumber
                    MK.WordFont.Body.Name = .WordFontName
                    MK.PrintMark = .PrintMark
                    MK.PictureNumber = .PictureNumber
                    MK.Line.BasicLine.SolidLine.Color = .Mark_Line_Color
                End With
                clsDrawMarkFan.TileMark_Print_Sample_Box(picMark, TMark, InnerColor, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)

                picFrameLine.BackColor = TMark.Mark_Line_Color.getColor
            Case rbWord.Checked
            Case rbPicture.Checked
                'With picGazo
                '    .Cls()
                '    X = .ScaleWidth / 2
                '    Y = .ScaleHeight / 2
                '    If Push.HatchMark.PictureNumber = -1 Then
                '        .Font = General_Option.SetFont
                '        .fontsize = 9
                '        .ForeColor = 0
                '        w2 = .TextWidth("×")
                '        h2 = .TextHeight("×")
                '        .CurrentX = X - w2 / 2
                '        .CurrentY = Y - h2 / 2
                '        picGazo.Print "×"
                '    Else
                '        Call Gazo_Print(Push.HatchMark.PictureNumber, X, Y, mn(.ScaleWidth, .ScaleHeight) / 2 * 0.9, 0, False, 0, Base.BlancLine, .hdc, False, 1)
                '    End If
                'End With
                Dim picmk As Mark_Property = clsBase.Mark
                If TMark.PictureNumber = -1 Then
                    picmk.PrintMark = enmMarkPrintType.Word
                    picmk.wordmark = "×"
                    picmk.WordFont.Body.Color = New colorARGB(Color.Black)
                Else
                    picmk.PictureNumber = TMark.PictureNumber
                End If
                clsDrawMarkFan.Draw_Mark_Sample_Box(picGazo, picmk, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)

        End Select
    End Sub

    Private Sub rbMark_CheckedChanged(sender As Object, e As EventArgs) Handles rbMark.CheckedChanged, rbWord.CheckedChanged, rbPicture.CheckedChanged
        pnlMark.Visible = rbMark.Checked
        pnlPicture.Visible = rbPicture.Checked
        pnlWord.Visible = rbWord.Checked
        Draw_Sample()
    End Sub

    Private Sub picMark_Click(sender As Object, e As EventArgs) Handles picMark.Click
        Dim form As New frmMark_Select
        If form.ShowDialog(attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture) = Windows.Forms.DialogResult.OK Then
            TMark.ShapeNumber = form.getResult
            Draw_Sample()
        End If
        form.Dispose()
    End Sub

    Private Sub picFrameLine_Click_1(sender As Object, e As EventArgs) Handles picFrameLine.Click
        If clsGeneric.Color_Set(TMark.Mark_Line_Color) = True Then
            picFrameLine.BackColor = TMark.Mark_Line_Color.getColor
            Draw_Sample()
        End If
    End Sub


    Private Sub txtWordMark_TextChanged(sender As Object, e As EventArgs) Handles txtWordMark.TextChanged

    End Sub

    Private Sub cboFontName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFontName.SelectedIndexChanged
        txtWordMark.Font = New Font(cboFontName.Text, txtWordMark.Font.Size, FontStyle.Regular)
    End Sub

    Private Sub picGazo_Click(sender As Object, e As EventArgs) Handles picGazo.Click
        Dim n As Integer = clsGeneric.Select_Picture(attrData, TMark.PictureNumber)
        If n <> -1 Then
            TMark.PictureNumber = n
            Draw_Sample()
        End If
    End Sub

    Private Sub btnGazoClear_Click(sender As Object, e As EventArgs) Handles btnGazoClear.Click
        TMark.PictureNumber = -1
        Draw_Sample()
    End Sub
End Class