Public Class frmMark_Select
    Private MarkBox() As System.Windows.Forms.PictureBox
    Private MarkLabel() As System.Windows.Forms.Label
    Dim MKSelectedIndex As Integer
    Dim ScrData As Screen_info
    Dim basePic As BasePicture_Info
    Public Overloads Function ShowDialog(ByRef ScData As Screen_info, ByRef _basePic As BasePicture_Info) As Windows.Forms.DialogResult
        ScrData = ScData
        basePic = _basePic
        Dim picw As Integer = 40
        Dim pich As Integer = 40
        Dim lblH As Integer = 15

        Dim Mark_Num = clsDrawMarkFan.Mark_Num

        Dim TotalW = picw + 7 * picw * 1.1 + 4
        Dim TotalH = ((Mark_Num \ 7) + 1) * (pich + lblH) * 1.1 + picw + btnCancel.Height * 1.2
        Me.Width = TotalW
        Me.Height = TotalH
        Me.MarkBox = New PictureBox(Mark_Num - 1) {}
        Me.MarkLabel = New Label(Mark_Num - 1) {}
        For i As Integer = 0 To Mark_Num - 1
            Me.MarkBox(i) = New System.Windows.Forms.PictureBox
            With Me.MarkBox(i)
                .Width = picw
                .Height = pich
                .BorderStyle = BorderStyle.Fixed3D
                .Left = picw / 2 + (i Mod 7) * picw * 1.1
                .Top = (i \ 7) * (pich + lblH) * 1.1 + picw / 2
                .BackColor = Color.White
                .Tag = i
            End With
            AddHandler MarkBox(i).MouseMove, AddressOf MarkBoxMouseMove
            AddHandler MarkBox(i).MouseLeave, AddressOf MarkBoxMouseLeave
            AddHandler MarkBox(i).Click, AddressOf MarkBoxMouseClick
            Me.MarkLabel(i) = New System.Windows.Forms.Label
            With Me.MarkLabel(i)
                .Width = picw
                .Height = lblH
                .Left = picw / 2 + (i Mod 7) * picw * 1.1
                .Top = (i \ 7) * (pich + lblH) * 1.1 + picw / 2 + pich
                .Font = New Font(Me.Font.FontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel)
                .Text = clsDrawMarkFan.Mark_Caption(i)
                .TextAlign = ContentAlignment.TopCenter
            End With
        Next
        Me.Controls.AddRange(Me.MarkBox)
        Me.Controls.AddRange(Me.MarkLabel)

        Dim dd As String = ""
        For i As Integer = 0 To 55
            dd += "'#" + Mid(Convert.ToString(MarkBox(i).BackColor.ToArgb, 16), 3) + "'" + ","
        Next
        btnOK.Top = Me.Height + 50


        For i As Integer = 0 To clsDrawMarkFan.Mark_Num - 1
            Dim MK As Mark_Property = clsBase.Mark
            MK.ShapeNumber = i
            clsDrawMarkFan.Draw_Mark_Sample_Box(MarkBox(i), MK, ScrData, basePic)
        Next

        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        Return Me.ShowDialog()
    End Function
    Public Function getResult() As Integer

        Return MKSelectedIndex
    End Function

    Private Sub frmMark_Select_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub MarkBoxMouseMove(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim pcol As PictureBox = TryCast(sender, PictureBox)
        pcol.BorderStyle = BorderStyle.FixedSingle

    End Sub
    Private Sub MarkBoxMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim pcol As PictureBox = TryCast(sender, PictureBox)
        pcol.BorderStyle = BorderStyle.Fixed3D
    End Sub
    Private Sub MarkBoxMouseClick(ByVal sender As Object, ByVal e As System.EventArgs)
        MKSelectedIndex = sender.tag
        btnOK.PerformClick()
    End Sub
End Class