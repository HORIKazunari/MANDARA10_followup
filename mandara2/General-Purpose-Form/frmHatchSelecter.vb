Public Class frmHatchSelecter
    Dim attrData As clsAttrData
    Dim Tile As Tile_Property
    Public Overloads Function ShowDialog(ByVal TileO As Tile_Property, ByRef _attrData As clsAttrData) As Windows.Forms.DialogResult
        attrData = _attrData

        Tile = TileO
        Me.Tag = "LOAD"
        cboSize.Items.Clear()
        cboSize.Items.Add("最小")
        cboSize.Items.Add("0.05")
        For si As Single = 0.1 To 1.01 Step 0.1
            cboSize.Items.Add(FormatNumber(si, 1))
        Next
        For i As Integer = 2 To 5
            cboSize.Items.Add(FormatNumber(i, 1))
        Next
        cboDensity.Items.Clear()
        For si As Single = 0.5 To 2.5 Step 0.5
            cboDensity.Items.Add(FormatNumber(si, 1))
        Next
        With Tile
            picColor.BackColor = .Line.BasicLine.SolidLine.Color.getColor
            rbTransparency.Checked = Not .BGColFlag
            rbNonTransparency.Checked = .BGColFlag
            If .Line.BasicLine.SolidLine.Width = 0 Then
                cboSize.SelectedIndex = 0
            Else
                cboSize.Text = .Line.BasicLine.SolidLine.Width
            End If
            picBGCol.BackColor = .BGCOLOR.getColor
            cboDensity.Text = .Density
        End With

        rbPoint.Checked = (Tile.TileCode = enmTilePattern.Point)
        rbHorizontalLine.Checked = (Tile.TileCode = enmTilePattern.HorizontalLine)
        rbVerticalLine.Checked = (Tile.TileCode = enmTilePattern.VerticalLine)
        rbDiagonalLineRightUp.Checked = (Tile.TileCode = enmTilePattern.DiagonalLineRightUp)
        rbDiagonalLineRightDown.Checked = (Tile.TileCode = enmTilePattern.DiagonalLineRightDown)
        rbCrossLine.Checked = (Tile.TileCode = enmTilePattern.CrossLine)
        rbSaltire.Checked = (Tile.TileCode = enmTilePattern.Saltire)
        rbBlank.Checked = (Tile.TileCode = enmTilePattern.Blank)
        rbPaint.Checked = (Tile.TileCode = enmTilePattern.Paint)
        rbMark.Checked = (Tile.TileCode = enmTilePattern.Mark)

        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        Me.Tag = ""
        Draw_Sample()
        Return Me.ShowDialog()
    End Function
    Public Function getResult() As Tile_Property

        Return Tile
    End Function

    Private Sub rbPoint_CheckedChanged(sender As Object, e As EventArgs) Handles rbPoint.CheckedChanged,
        rbHorizontalLine.CheckedChanged, rbVerticalLine.CheckedChanged, rbDiagonalLineRightUp.CheckedChanged,
        rbDiagonalLineRightDown.CheckedChanged, rbCrossLine.CheckedChanged, rbSaltire.CheckedChanged,
        rbBlank.CheckedChanged, rbPaint.CheckedChanged, rbMark.CheckedChanged
        Select Case sender.Name
            Case "rbBlank", "rbPaint"
                gbMark.Visible = False
                gbLine.Visible = False
                gbPointSize.Visible = False
                gbDensity.Visible = False
                gbBack.Visible = False
                gbMark.Visible = False
                If sender.name = "rbBlank" Then
                    gbCol.Visible = False
                Else
                    gbCol.Visible = True
                End If
            Case "rbPoint", "rbMark"
                gbMark.Visible = False
                gbCol.Visible = True
                gbDensity.Visible = True
                gbPointSize.Visible = True
                gbLine.Visible = False
                gbBack.Visible = True
                If sender.name = "rbMark" Then
                    gbMark.Visible = True
                    Dim MK As Mark_Property = clsBase.Mark
                    MK.ShapeNumber = Tile.TileMark.ShapeNumber
                    clsDrawMarkFan.Draw_Mark_Sample_Box(picMark, MK, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
                    If Tile.Line.BasicLine.SolidLine.Width = 0 Then
                        Tile.Line.BasicLine.SolidLine.Width = Tile.Density / 2
                    End If
                Else
                    gbMark.Visible = False
                End If
                If Tile.Line.BasicLine.SolidLine.Width = 0 Then
                    cboSize.SelectedIndex = 0
                Else
                    cboSize.Text = Tile.Line.BasicLine.SolidLine.Width
                End If
            Case Else
                gbMark.Visible = False
                gbPointSize.Visible = False
                gbLine.Visible = True
                gbDensity.Visible = True
                gbBack.Visible = True
                gbCol.Visible = False
        End Select

        Select Case True
            Case rbPoint.Checked
                Tile.TileCode = enmTilePattern.Point
            Case rbHorizontalLine.Checked
                Tile.TileCode = enmTilePattern.HorizontalLine
            Case rbVerticalLine.Checked
                Tile.TileCode = enmTilePattern.VerticalLine
            Case rbDiagonalLineRightUp.Checked
                Tile.TileCode = enmTilePattern.DiagonalLineRightUp
            Case rbDiagonalLineRightDown.Checked
                Tile.TileCode = enmTilePattern.DiagonalLineRightDown
            Case rbCrossLine.Checked
                Tile.TileCode = enmTilePattern.CrossLine
            Case rbSaltire.Checked
                Tile.TileCode = enmTilePattern.Saltire
            Case rbBlank.Checked
                Tile.TileCode = enmTilePattern.Blank
            Case rbPaint.Checked
                Tile.TileCode = enmTilePattern.Paint
            Case rbMark.Checked
                Tile.TileCode = enmTilePattern.Mark
        End Select
        Draw_Sample()
    End Sub

    Private Sub cboDensity_LostFocus(sender As Object, e As EventArgs) Handles cboDensity.LostFocus, cboDensity.SelectedIndexChanged
        Tile.Density = Val(cboDensity.Text)
        Draw_Sample()
    End Sub

    Private Sub Draw_Sample()
        Dim MK As Mark_Property

        If Me.Tag = "LOAD" Then Exit Sub

        clsDrawLine.Draw_Sample_LineBox(picLine, Tile.Line, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        MK = clsBase.Mark
        With Tile.TileMark
            MK.ShapeNumber = .ShapeNumber
            MK.PrintMark = .PrintMark
            MK.PictureNumber = .PictureNumber
            MK.WordFont = clsBase.Font
            MK.WordFont.Body.Name = .WordFontName
            MK.wordmark = .wordmark
            MK.WordFont.Body.Kakudo = .Kakudo
        End With
        clsDrawMarkFan.TileMark_Print_Sample_Box(picMark, Tile.TileMark, Tile.Line.BasicLine.SolidLine.Color, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        'clsDrawMarkFan.Mark_Print_Sample_Box(picMark, MK, ScrData)
        clsDrawTile.Draw_Sample_TileBox(picSample, Tile, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
    End Sub

    Private Sub picBGCol_Click(sender As Object, e As EventArgs) Handles picBGCol.Click

        If clsGeneric.Color_Set(Tile.BGCOLOR) = True Then
            picBGCol.BackColor = Tile.BGCOLOR.getColor
            rbNonTransparency.Checked = True
            Draw_Sample()
        End If
    End Sub

    Private Sub rbTransparency_CheckedChanged(sender As Object, e As EventArgs) Handles rbTransparency.CheckedChanged, rbNonTransparency.CheckedChanged
        Tile.BGColFlag = rbNonTransparency.Checked
        Draw_Sample()
    End Sub

    Private Sub picColor_Click(sender As Object, e As EventArgs) Handles picColor.Click
        Dim c As New colorARGB(picColor.BackColor)
        If clsGeneric.Color_Set(c) = True Then
            Tile.Line.Set_Same_Color_to_LinePat(c)
            picColor.BackColor = c.getColor
            Draw_Sample()
        End If
    End Sub

    Private Sub picLine_Click(sender As Object, e As EventArgs) Handles picLine.Click
        If clsGeneric.Line_Pattern_select(Tile.Line, True, attrData) = True Then
            picColor.BackColor = Tile.Line.BasicLine.SolidLine.Color.getColor
            Draw_Sample()
        End If
    End Sub


    Private Sub picMark_Click(sender As Object, e As EventArgs) Handles picMark.Click
        If clsGeneric.TileMark_Set(Tile.TileMark, Tile.Line.BasicLine.SolidLine.Color, attrData, True) = True Then

            Draw_Sample()
        End If
    End Sub

    Private Sub cboSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSize.SelectedIndexChanged, cboSize.LostFocus
        Tile.Line.BasicLine.SolidLine.Width = Val(cboSize.Text)
        cboSize.Text = Tile.Line.BasicLine.SolidLine.Width
        Draw_Sample()
    End Sub
End Class