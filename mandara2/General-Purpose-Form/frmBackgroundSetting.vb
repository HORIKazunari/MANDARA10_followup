Public Class frmBackgroundSetting
    Dim back As BackGround_Box_Property

    Dim attrData As clsAttrData
    Public Overloads Function ShowDialog(ByVal _Back As BackGround_Box_Property, ByRef _attrData As clsAttrData) As Windows.Forms.DialogResult
        back = _Back
        attrData = _attrData
        With cboRoundSize
            .Items.Clear()
            For si As Single = 0 To 5 Step 0.5
                .Items.Add(Format(si, "0.0"))
            Next
            .Text = back.Round
        End With
        With cboPadding
            .Items.Clear()
            For si As Single = 0 To 5 Step 0.5
                .Items.Add(Format(si, "0.0"))
            Next
            .Text = back.Padding
        End With
        clsDrawTile.Draw_Sample_TileBox(picBackTile, back.Tile, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        clsDrawLine.Draw_Sample_LineBox(picLine, back.Line, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        Return Me.ShowDialog()
    End Function
    Public Function getResult() As BackGround_Box_Property
        back.Round = Val(cboRoundSize.Text)
        back.Padding = Val(cboPadding.Text)
        Return back
    End Function

    Private Sub picBackTile_Click(sender As Object, e As EventArgs) Handles picBackTile.Click
        If clsGeneric.Tile_Set(back.Tile, attrData) = True Then
            clsDrawTile.Draw_Sample_TileBox(picBackTile, back.Tile, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End If
    End Sub

    Private Sub picLine_Click(sender As Object, e As EventArgs) Handles picLine.Click
        If clsGeneric.Line_Pattern_select(back.Line, True, attrData) = True Then
            clsDrawLine.Draw_Sample_LineBox(picLine, back.Line, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
        End If
    End Sub
End Class