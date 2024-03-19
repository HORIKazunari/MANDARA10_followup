Public Class frmLpatBasicSelect
    Private LineBox() As System.Windows.Forms.PictureBox
    Private LineName() As System.Windows.Forms.Label
    Private UserLineBox() As System.Windows.Forms.PictureBox
    Private UserLineName() As System.Windows.Forms.TextBox
    Private RecentLineBox() As System.Windows.Forms.PictureBox
    Private RecentLineName() As System.Windows.Forms.Label
    Private Const cstLineSampleNum = 21
    Private Const cstUserLineNum = 10
    Private Const cstRecentLinenum = 10
    Dim attrData As clsAttrData
    Dim LinePattern As Line_Property
    Dim LineBasicPat() As Line_Property
    Private Sub frmLpatBasicSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnOK.Top = Me.Height + 50
        Dim picwsub As Integer = 70
        Dim picw As Integer = 90
        Dim pich As Integer = 20
        Dim LineNameList As String() = {"実線", "破線", "点線", "一点鎖線", "二点鎖線", "透明", "太線", "極太線",
                                    "二重線", "幅広二重線", "極幅広二重線", "三重線", "幅広三重線", "JR線",
                                      "線路", "地下鉄", "丸線", "四角線", "丸", "四角", "横線"}
        ReDim LineBasicPat(cstLineSampleNum - 1)
        LineBasicPat(0) = clsBase.Line
        LineBasicPat(1) = clsBase.BrokenLine
        LineBasicPat(2) = clsBase.DotLine
        LineBasicPat(3) = clsBase.Chain1Line
        LineBasicPat(4) = clsBase.Chain2Line
        LineBasicPat(5) = clsBase.BlancLine
        LineBasicPat(6) = clsBase.BoldLine
        LineBasicPat(7) = clsBase.BoldExLine
        LineBasicPat(8) = clsBase.DoubleLine
        LineBasicPat(9) = clsBase.DoubleWideLine
        LineBasicPat(10) = clsBase.DoubleWideExLine
        LineBasicPat(11) = clsBase.TripleLine
        LineBasicPat(12) = clsBase.TripleWideLine
        LineBasicPat(13) = clsBase.JRLine
        LineBasicPat(14) = clsBase.RailLine
        LineBasicPat(15) = clsBase.UndergroundRailLine
        LineBasicPat(16) = clsBase.CircleLine
        LineBasicPat(17) = clsBase.RectLine
        LineBasicPat(18) = clsBase.CircleDotLine
        LineBasicPat(19) = clsBase.RectDotLine
        LineBasicPat(20) = clsBase.SideLine

        Me.LineBox = New PictureBox(cstLineSampleNum - 1) {}
        Me.LineName = New Label(cstLineSampleNum - 1) {}
        pnlLineSample.Height = (pich + 5) * (cstLineSampleNum) + 20
        pnlLineSample.Width = Panel.Width - 25
        For i As Integer = 0 To cstLineSampleNum - 1
            Me.LineBox(i) = New System.Windows.Forms.PictureBox
            With Me.LineBox(i)
                .Parent = pnlLineSample
                .Top = i * (pich + 5) + 10
                .Left = 10
                .Width = picw
                .Height = pich
                '.BorderStyle = BorderStyle.Fixed3D
                .BackColor = Color.White
                .Tag = i
            End With
            clsDrawLine.Draw_Sample_LineBox(Me.LineBox(i), LineBasicPat(i), attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
            AddHandler LineBox(i).Click, AddressOf LineBoxMouseClick
            Me.LineName(i) = New System.Windows.Forms.Label
            With Me.LineName(i)
                .Parent = pnlLineSample
                .Top = i * (pich + 5) + 10 + 5
                .Left = 10 + picw + 10
                .BackColor = Color.White
                .Text = LineNameList(i)
            End With
        Next

        Me.UserLineBox = New PictureBox(cstUserLineNum - 1) {}
        Me.UserLineName = New TextBox(cstUserLineNum - 1) {}
        pnlUserLine.Height = (pich + 2) * (cstUserLineNum) + 20
        pnlUserLine.Width = PanelUser.Width - 25
        For i As Integer = 0 To cstUserLineNum - 1
            Me.UserLineBox(i) = New System.Windows.Forms.PictureBox
            With Me.UserLineBox(i)
                .Parent = pnlUserLine
                .Top = i * (pich + 2) + 10
                .Left = 10
                .Width = picwsub
                .Height = pich
                '.BorderStyle = BorderStyle.Fixed3D
                .BackColor = Color.White
                .Tag = i
                AddHandler .Click, AddressOf UserLineBoxMouseClick
            End With
            clsDrawLine.Draw_Sample_LineBox(Me.UserLineBox(i), clsSettings.Line.UserLinePat(i).Lpat, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
            Me.UserLineName(i) = New System.Windows.Forms.TextBox
            With Me.UserLineName(i)
                .Parent = pnlUserLine
                .Top = i * (pich + 2) + 10
                .Left = 10 + picwsub + 5
                .BackColor = Color.White
                .Height = pich
                .Width = pnlUserLine.Width - .Left - 5
                .Text = clsSettings.Line.UserLinePat(i).LpatName
                AddHandler .LostFocus, AddressOf UserLineTextBoxLeave
                .Tag = i
            End With
        Next

        Me.RecentLineBox = New PictureBox(cstRecentLinenum - 1) {}
        Me.RecentLineName = New Label(cstRecentLinenum - 1) {}
        pnlRecentLine.Height = (pich + 5) * (cstRecentLinenum) + 20
        pnlRecentLine.Width = PanelRecent.Width - 25
        For i As Integer = 0 To cstRecentLinenum - 1
            Me.RecentLineBox(i) = New System.Windows.Forms.PictureBox
            With Me.RecentLineBox(i)
                .Parent = pnlRecentLine
                .Top = i * (pich + 2) + 10
                .Left = 10
                .Width = picwsub
                .Height = pich
                .BackColor = Color.White
                .Tag = i
                AddHandler .Click, AddressOf RecentLineBoxMouseClick
            End With
            clsDrawLine.Draw_Sample_LineBox(Me.RecentLineBox(i), clsSettings.Line.RecentLinePat(i), attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
            Me.RecentLineName(i) = New System.Windows.Forms.Label
            With Me.RecentLineName(i)
                .Parent = pnlRecentLine
                .Top = i * (pich + 2) + 10 + 5
                .Left = 10 + picwsub + 5
                .BackColor = Color.White
                .Height = pich
                Dim tx As String = ""
                For j As Integer = 0 To cstLineSampleNum - 1
                    If LineBasicPat(j).Equals(clsSettings.Line.RecentLinePat.Item(i)) = True Then
                        tx = LineNameList(j)
                        Exit For
                    End If
                Next
                For j As Integer = 0 To cstUserLineNum - 1
                    If clsSettings.Line.UserLinePat(j).Lpat.Equals(clsSettings.Line.RecentLinePat.Item(i)) = True Then
                        tx = clsSettings.Line.UserLinePat(j).LpatName
                        Exit For
                    End If
                Next
                .Text = tx
            End With
        Next

    End Sub
    Public Overloads Function ShowDialog(ByVal LinePat As Line_Property, ByVal detail_Flag As Boolean,
                                         ByRef _attrData As clsAttrData) As Windows.Forms.DialogResult
        attrData = _attrData
        LinePattern = LinePat
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Center)
        btnDetail.Visible = detail_Flag
        Return Me.ShowDialog()
    End Function

    Public Function getResult() As Line_Property
        Dim f As Boolean = False
        For i As Integer = 0 To cstRecentLinenum - 1
            If clsSettings.Line.RecentLinePat(i).Equals(LinePattern) = True Then
                If i <> 0 Then
                    clsSettings.Line.RecentLinePat.Insert(0, LinePattern)
                    clsSettings.Line.RecentLinePat.RemoveAt(i + 1)
                End If
                f = True
                Exit For
            End If
        Next
        If f = False Then
            clsSettings.Line.RecentLinePat.Insert(0, LinePattern)
            clsSettings.Line.RecentLinePat.RemoveAt(cstRecentLinenum)
        End If
        Return LinePattern
    End Function
    Private Sub LineBoxMouseClick(ByVal sender As Object, ByVal e As System.EventArgs)

        LinePattern = clsGeneric.Set_Same_Color_to_LinePat(LineBasicPat(sender.tag), New colorARGB(picColor.BackColor))
        btnOK.PerformClick()
    End Sub
    Private Sub RecentLineBoxMouseClick(ByVal sender As Object, ByVal e As System.EventArgs)
        LinePattern = clsSettings.Line.RecentLinePat(sender.tag)
        btnOK.PerformClick()
    End Sub
    Private Sub UserLineBoxMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim pic As PictureBox = CType(sender, PictureBox)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            LinePattern = clsSettings.Line.UserLinePat(pic.Tag).Lpat
            btnOK.PerformClick()
        Else
            Dim form As New frmMakeLinePattern
            Dim uLpat As clsSettings.UserLine_Info = clsSettings.Line.UserLinePat.Item(pic.Tag)
            If form.ShowDialog(uLpat.Lpat, attrData) = Windows.Forms.DialogResult.OK Then
                uLpat.Lpat = form.getResult
                clsSettings.Line.UserLinePat.Item(pic.Tag) = uLpat
                clsDrawLine.Draw_Sample_LineBox(pic, uLpat.Lpat, attrData.TotalData.ViewStyle.ScrData, attrData.TotalData.BasePicture)
                form.Dispose()
            End If
            form.Dispose()
        End If
    End Sub
    Private Sub UserLineTextBoxLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tx As TextBox = CType(sender, TextBox)
        Dim uLpat As clsSettings.UserLine_Info = clsSettings.Line.UserLinePat.Item(tx.Tag)
        uLpat.LpatName = tx.Text
        clsSettings.Line.UserLinePat.Item(tx.Tag) = uLpat
    End Sub
    Private Sub picColor_Click(sender As Object, e As EventArgs) Handles picColor.Click
        Dim col As colorARGB = New colorARGB(picColor.BackColor)
        If clsGeneric.Color_Set(col) = True Then
            picColor.BackColor = col.getColor
        End If
    End Sub

    Private Sub btnDetail_Click(sender As Object, e As EventArgs) Handles btnDetail.Click
        Dim form As New frmMakeLinePattern
        If form.ShowDialog(LinePattern, attrData) = Windows.Forms.DialogResult.OK Then
            LinePattern = form.getResult
            form.Dispose()
            btnOK.PerformClick()
        End If
        form.Dispose()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class