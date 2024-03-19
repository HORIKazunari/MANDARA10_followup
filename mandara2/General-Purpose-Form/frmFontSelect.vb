Public Class frmFontSelect

    Dim FontData As Font_Property
    Dim ScrData As Screen_info

    Dim attrData As clsAttrData
    Dim basePic As BasePicture_Info
    Public Overloads Function ShowDialog(ByVal FontOrigin As Font_Property, ByRef _attrData As clsAttrData) As Windows.Forms.DialogResult
        FontData = FontOrigin
        attrData = _attrData
        ScrData = _attrData.TotalData.ViewStyle.ScrData

        ScrData.SampleBoxFlag = True
        Me.Tag = "OFF"
        cboFontName.Items.Clear()
        With cboFontName
            For i As Integer = 0 To clsFontList_inPC.FontFamilyList.GetLength(0) - 1
                cboFontName.Items.Add(clsFontList_inPC.FontFamilyList(i).Name)
            Next
        End With

        With cboFontSize
            .Items.Clear()
            For si As Single = 0.5 To 5 Step 0.5
                .Items.Add(Format(si, "0.0"))
            Next
            For i As Integer = 6 To 20
                .Items.Add(Format(i, "0.0"))
            Next
        End With
        With cboFringeWidth.Items
            .Clear()
            For i As Integer = 20 To 100 Step 20
                .Add(i)
            Next
        End With
        With FontData.Body
            cboFontName.Text = .Name
            cbBold.Checked = .bold
            cbItalic.Checked = .italic
            cbUnderLine.Checked = .Underline
            cboFontSize.Text = .Size
            txtKakudo.Text = .Kakudo
            picColor.BackColor = .Color.getColor
            cboFringeWidth.Text = .FringeWidth
            picFringeColor.BackColor = .FringeColor.getColor
            cbFringe.Checked = .FringeF
        End With
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        Me.Tag = ""
        Draw_Sample()
        Return Me.ShowDialog()
    End Function
    Public Function getResult() As Font_Property

        Return FontData
    End Function
    Private Sub Draw_Sample()
        If Me.Tag = "OFF" Then
            Return
        End If
        clsDrawTile.Darw_Sample_BackGroundBox(picBack, FontData.Back, ScrData, basePic)
        Dim Canvas As Bitmap = New Bitmap(picSample.Width - 4, picSample.Height - 4)
        Dim g As Graphics = Graphics.FromImage(Canvas)
        g.Clear(picSample.BackColor)
        FontData.Body.Size = FontData.Body.Size * 10
        clsDraw.print(g, "Fontフォントの設定", New Point(0, picSample.Height / 2 - 2), FontData, enmHorizontalAlignment.Left, enmVerticalAlignment.Center, ScrData, basePic)
        FontData.Body.Size = FontData.Body.Size / 10
        picSample.Image = Canvas
        g.Dispose()
        picSample.Refresh()


    End Sub

    Private Sub picColor_Click(sender As Object, e As EventArgs) Handles picColor.Click
        If clsGeneric.Color_Set(FontData.Body.Color) = True Then
            picColor.BackColor = FontData.Body.Color.getColor
            Draw_Sample()
        End If

    End Sub

    Private Sub picBack_Click(sender As Object, e As EventArgs) Handles picBack.Click
        If clsGeneric.BackGround_Setting(FontData.Back, attrData) = True Then
            Draw_Sample()
        End If
    End Sub



    Private Sub cbUnderLine_CheckedChanged(sender As Object, e As EventArgs) Handles cbUnderLine.CheckedChanged, cbBold.CheckedChanged, cbItalic.CheckedChanged, cbFringe.CheckedChanged
        With FontData.Body
            .bold = cbBold.Checked
            .italic = cbItalic.Checked
            .Underline = cbUnderLine.Checked
            .FringeF = cbFringe.Checked
        End With
        Draw_Sample()

    End Sub

    Private Sub cboFontSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFontSize.SelectedIndexChanged, cboFontSize.LostFocus
        FontData.Body.Size = Val(cboFontSize.Text)
        cboFontSize.Text = FontData.Body.Size
        Draw_Sample()
    End Sub

    Private Sub cboFontName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFontName.SelectedIndexChanged
        FontData.Body.Name = cboFontName.Text
        Draw_Sample()
    End Sub

    Private Sub txtKakudo_LostFocus(sender As Object, e As EventArgs) Handles txtKakudo.LostFocus
        Dim V As Integer = Val(txtKakudo.Text)
        txtKakudo.Text = V
        FontData.Body.Kakudo = V
        Draw_Sample()
    End Sub

 
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

    End Sub

    Private Sub picFringeColor_Click(sender As Object, e As EventArgs) Handles picFringeColor.Click
        If clsGeneric.Color_Set(FontData.Body.FringeColor) = True Then
            picFringeColor.BackColor = FontData.Body.FringeColor.getColor
            cbFringe.Checked = True
            Draw_Sample()
        End If
    End Sub

    Private Sub cboFringeWidth_Enter(sender As Object, e As EventArgs) Handles cboFringeWidth.Enter
        cbFringe.Checked = True

    End Sub

    Private Sub cboFringeWidth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFringeWidth.SelectedIndexChanged, cboFringeWidth.LostFocus
        FontData.Body.FringeWidth = Val(cboFringeWidth.Text)
        cboFringeWidth.Text = FontData.Body.FringeWidth
        Draw_Sample()
    End Sub
End Class