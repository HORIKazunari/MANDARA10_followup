Public Class frmMain_PainrColor
    Private Const picn As Integer = 29
    Private colorBox() As System.Windows.Forms.PictureBox
    Dim ClassN As Integer
    Dim colorPat() As List(Of Color)
    Dim selectPic As Integer
    Dim ConvColor As List(Of colorARGB())
    Public Overloads Function ShowDialog(ByVal _ClassN As Integer) As Windows.Forms.DialogResult
        ClassN = _ClassN
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)

        Return Me.ShowDialog

    End Function
    Public Function GetResults() As colorARGB()
        Return ConvColor(selectPic)
    End Function
    Private Sub setcolor()
        ConvColor = New List(Of colorARGB())
        For i As Integer = 0 To picn - 1
            Dim canvas As New Bitmap(Me.colorBox(i).Width, Me.colorBox(i).Height)
            Dim g As Graphics = Graphics.FromImage(canvas)
            Dim ColData() As colorARGB
            Dim colcol(colorPat(i).Count - 1) As colorARGB
            For j As Integer = 0 To colorPat(i).Count - 1
                colcol(j) = New colorARGB(colorPat(i).Item(j))
            Next
            Dim colnum As Integer = colorPat(i).Count
            If colnum <= ClassN Then
                Me.colorBox(i).Visible = True
                Select Case colnum
                    Case 2
                        ColData = clsGeneric.TwoColorGradation(colcol(0), colcol(1), ClassN)
                    Case 3
                        Dim cp As Integer = ClassN \ 2
                        ColData = clsGeneric.ThreeColorGradation(colcol(0), colcol(1), colcol(2), ClassN, cp)
                    Case Else
                        ReDim ColData(ClassN - 1)
                        Dim pos(colnum - 1) As Integer
                        For j As Integer = 0 To colnum - 2
                            pos(j) = Int((j / (colnum - 1)) * ClassN)
                        Next
                        pos(colnum - 1) = ClassN - 1
                        Dim tcol() As colorARGB
                        For j As Integer = 0 To colnum - 2
                            tcol = clsGeneric.TwoColorGradation(colcol(j), colcol(j + 1), pos(j + 1) - pos(j) + 1)
                            For k As Integer = 0 To tcol.Length - 1
                                ColData(pos(j) + k) = tcol(k)
                            Next
                        Next
                End Select

                For j As Integer = 0 To ClassN - 1
                    Dim left As Integer = Me.colorBox(i).Width * (j / ClassN)
                    Dim right As Integer = Me.colorBox(i).Width * ((j + 1) / ClassN)
                    Dim col As Integer = 0
                    g.FillRectangle(New SolidBrush(ColData(j).getColor), New Rectangle(New Point(left, 0), New Point(right - left, Me.colorBox(i).Height)))
                Next
                ConvColor.Add(ColData)
                Me.colorBox(i).Image = canvas
                g.Dispose()
            Else
                Me.colorBox(i).Visible = False
            End If

        Next
    End Sub
    Private Sub frmMain_PainrColor_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim picw As Integer = Me.ClientSize.Width * 0.8
        Dim pich As Integer = Me.ClientSize.Height / (picn + 1)
        Dim topMargin As Integer = pich / 2
        Dim leftMargin = picw * 0.1

        ReDim colorPat(picn - 1)
        For i As Integer = 0 To picn - 1
            colorPat(i) = New List(Of Color)
        Next
        Dim blue As Color = Color.FromArgb(0, 65, 255)
        Dim red As Color = Color.FromArgb(255, 40, 0)
        Dim yellow As Color = Color.FromArgb(255, 230, 0)
        Dim green As Color = Color.FromArgb(0, &H77, &H10)
        Dim n = 0
        colorPat(n).AddRange({Color.Black, Color.White}) : n += 1
        colorPat(n).AddRange({blue, Color.White}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(&H8, &H51, &H9C), Color.FromArgb(&HEF, &HF3, &HFF)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(&H54, &H27, &H8F), Color.FromArgb(&HF2, &HF0, &HF7)}) : n += 1
        colorPat(n).AddRange({red, Color.White}) : n += 1
        colorPat(n).AddRange({red, Color.FromArgb(&H56, &H86, &H36)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(&HEC, &H34, &H4), Color.FromArgb(&HFF, &HDE, &HC3)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(&H99, &H34, &H4), Color.FromArgb(&HFF, &HFF, &HC4)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(&HA6, &H36, &H3), Color.FromArgb(&HFE, &HED, &HDE)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(&HA5, &HF, &H15), Color.FromArgb(&HFE, &HE5, &HD9)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(&HB0, &H0, &H26), Color.FromArgb(&HFF, &HFF, &HB2)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(&H0, &H62, &H2C), Color.FromArgb(&HED, &HF8, &HE9)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(0, &H37, &H0), Color.FromArgb(&HE6, &HE6, &H96)}) : n += 1
        colorPat(n).AddRange({red, blue}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(&HB0, &H0, &H26), Color.FromArgb(&HFF, &HFF, &HB2), Color.FromArgb(&HBF, &HBF, &HFF)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(255, 191, 191), Color.FromArgb(&HFF, &HFF, &HB2), Color.FromArgb(&HBF, &HBF, &HFF)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(255, 128, 0), Color.FromArgb(&HFF, &HFF, &HB2), Color.FromArgb(&HBF, &HBF, &HFF)}) : n += 1
        colorPat(n).AddRange({red, Color.White, blue}) : n += 1
        colorPat(n).AddRange({red, Color.FromArgb(255, 255, 191), blue}) : n += 1
        colorPat(n).AddRange({red, yellow, blue}) : n += 1
        colorPat(n).AddRange({red, yellow, green}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(255, &H80, 0), Color.FromArgb(255, &HFF, &HBF), Color.FromArgb(&H55, &HBF, &H55)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(&HEC, &H34, &H4), Color.FromArgb(&HFF, &HDE, &HC3), green}) : n += 1
        colorPat(n).AddRange({red, yellow, Color.Green, blue}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(255, &H80, 0), Color.FromArgb(255, &HFF, &HBF), Color.FromArgb(&H55, &HBF, &H55), Color.FromArgb(&HBF, &HBF, &HFF)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(255, &H80, 0), Color.FromArgb(255, &HFF, &HBF), Color.FromArgb(&H55, &HBF, &H55), Color.FromArgb(85, 85, 191)}) : n += 1
        colorPat(n).AddRange({red, yellow, Color.Green, blue, Color.FromArgb(0, 0, 50)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(180, 0, 104), red, yellow, Color.Green, blue, Color.FromArgb(0, 0, 50)}) : n += 1
        colorPat(n).AddRange({Color.FromArgb(180, 0, 104), red, yellow, Color.Green, Color.FromArgb(185, 235, 255), blue, Color.FromArgb(0, 0, 50)}) : n += 1


        Me.colorBox = New PictureBox(picn - 1) {}
        For i As Integer = 0 To picn - 1
            Me.colorBox(i) = New System.Windows.Forms.PictureBox
            With Me.colorBox(i)
                .Width = picw
                .Height = pich - 1
                .BorderStyle = BorderStyle.Fixed3D
                .Top = pich * i + topMargin
                .Left = leftMargin
                .Tag = i
                AddHandler .MouseMove, AddressOf ColorBoxMouseMove
                AddHandler .MouseLeave, AddressOf ColorBoxMouseLeave
                AddHandler .Click, AddressOf ColorBoxMouseClick
            End With
        Next
        Me.Controls.AddRange(Me.colorBox)
        setcolor()
        btnOK.Top = Me.Bottom + 5
        btnCancel.Top = btnOK.Top
    End Sub
    Private Sub ColorBoxMouseMove(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim pcol As PictureBox = TryCast(sender, PictureBox)
        pcol.BorderStyle = BorderStyle.FixedSingle

    End Sub
    Private Sub ColorBoxMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim pcol As PictureBox = TryCast(sender, PictureBox)
        pcol.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub ColorBoxMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        selectPic = sender.tag
        btnOK.PerformClick()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

    End Sub
End Class