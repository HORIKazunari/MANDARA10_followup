Public Class frmColor
    Private colorBox() As System.Windows.Forms.PictureBox
    Private UserColorBox() As System.Windows.Forms.PictureBox
    Private RecentColorBox() As System.Windows.Forms.PictureBox
    Dim ClickColor As Color

    Private Sub btnDetailColor_Click(sender As Object, e As EventArgs) Handles btnDetailColor.Click

        'ColorDialogクラスのインスタンスを作成
        Dim cd As New ColorDialog()

        'はじめに選択されている色を設定
        'cd.Color = PictureBox1.BackColor
        '色の作成部分を表示可能にする
        'デフォルトがTrueのため必要はない
        cd.AllowFullOpen = True
        '純色だけに制限しない
        'デフォルトがFalseのため必要はない
        cd.SolidColorOnly = False
        '[作成した色]に指定した色（RGB値）を表示する
        cd.CustomColors = New Integer() {&H33, &H66, &H99, _
            &HCC, &H3300, &H3333, &H3366, &H3399, &H33CC, _
            &H6600, &H6633, &H6666, &H6699, &H66CC, _
            &H9900, &H9933}

        'ダイアログを表示する
        If cd.ShowDialog(Me) = DialogResult.OK Then
            '選択された色の取得
            setPicBackColor(cd.Color)
            btnOK.PerformClick()
        End If
    End Sub

    Public Overloads Function ShowDialog(ByVal Col As colorARGB) As Windows.Forms.DialogResult


        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        setPicBackColor(Col.getColor)
        hsbTransparency.Value = Col.a
        txtAlpha.Text = Col.a
        Return Me.ShowDialog()
    End Function
    Public Function getResult() As colorARGB
        Dim c As New colorARGB(picBackColor.BackColor)
        c.a = hsbTransparency.Value
        Dim f As Boolean = False
        For i As Integer = 0 To 7
            If clsSettings.Color.RecentColor(i).Equals(c) = True Then
                If i <> 0 Then
                    clsSettings.Color.RecentColor.Insert(0, c)
                    clsSettings.Color.RecentColor.RemoveAt(i + 1)
                End If
                f = True
                Exit For
            End If
        Next
        If f = False Then
            clsSettings.Color.RecentColor.Insert(0, c)
            clsSettings.Color.RecentColor.RemoveAt(8)
        End If
        Return c
    End Function


    Private Sub frmColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim picw As Integer = btnOK.Width * 0.45 '31
        Dim pich As Integer = 21
        Dim topMargin As Integer = picw / 2 ' lblUser.Top + lblUser.Height * 1.1
        Dim leftMargin = picw / 2
        Me.colorBox = New PictureBox(55) {}
        For i As Integer = 0 To 55
            Me.colorBox(i) = New System.Windows.Forms.PictureBox
            With Me.colorBox(i)
                .Width = picw
                .Height = pich
                .BorderStyle = BorderStyle.Fixed3D
                .Tag = i
                AddHandler .MouseMove, AddressOf ColorBoxMouseMove
                AddHandler .MouseLeave, AddressOf ColorBoxMouseLeave
                AddHandler .Click, AddressOf ColorBoxMouseClick
            End With
        Next
        For i As Integer = 0 To 6
            With Me.colorBox(i)
                .Left = leftMargin
                .Top = i * pich * 1.1 + topMargin
                .BackColor = ColorTranslator.FromOle(QBColor(9 + i))
            End With
        Next
        Dim col2() As Color = {Color.FromArgb(255, 0, &H40, &H80),
                               Color.FromArgb(255, 0, &HA0, &H40),
                               Color.FromArgb(255, &H50, &HA0, &H60),
                               Color.FromArgb(255, &HFF, &H28, &H0),
                               Color.FromArgb(255, &HFF, &H80, &HFF),
                               Color.FromArgb(255, &HFF, &H80, &H0),
                               Color.FromArgb(255, 0, 0, 0)}
        For i As Integer = 7 To 13
            With Me.colorBox(i)
                .Left = leftMargin + (i \ 7) * picw * 1.1
                .Top = (i Mod 7) * pich * 1.1 + topMargin
                .BackColor = col2(i - 7)
            End With
        Next
        colorBox(13).BackColor = Color.Black
        Dim n As Integer = 14

        For i As Integer = 1 To 6
            Dim b As Boolean = ((i And 1) = 1)
            Dim r As Boolean = ((i And 2) = 2)
            Dim g As Boolean = ((i And 4) = 4)
            Dim bcol As Byte = 0
            Dim gcol As Byte = 0
            Dim rcol As Byte = 0
            For j = 0 To 2
                If b = True Then bcol = 255 * (j + 1) / 4
                If r = True Then rcol = 255 * (j + 1) / 4
                If g = True Then gcol = 255 * (j + 1) / 4
                With Me.colorBox(n)
                    .BackColor = Color.FromArgb(255, rcol, gcol, bcol)
                    .Left = picw / 2 + (n \ 7) * picw * 1.1
                    .Top = (n Mod 7) * pich * 1.1 + topMargin
                End With
                n += 1
            Next
            For j As Integer = 0 To 2
                If b = False Then bcol = 255 * (j + 1) / 3
                If r = False Then rcol = 255 * (j + 1) / 3
                If g = False Then gcol = 255 * (j + 1) / 3
                With Me.colorBox(n)
                    .BackColor = Color.FromArgb(255, rcol, gcol, bcol)
                    .Left = picw / 2 + (n \ 7) * picw * 1.1
                    .Top = (n Mod 7) * pich * 1.1 + topMargin
                End With
                n += 1
            Next

            With Me.colorBox(n)
                .BackColor = Color.FromArgb(255, 256 * (7 - i) / 7, 256 * (7 - i) / 7, 256 * (7 - i) / 7)
                .Left = picw / 2 + (n \ 7) * picw * 1.1
                .Top = (n Mod 7) * pich * 1.1 + topMargin
            End With

            n += 1
        Next
        For i As Integer = 0 To Me.colorBox.Length - 1
            With Me.colorBox(i).BackColor
                ToolTip1.SetToolTip(Me.colorBox(i), String.Format("argb={0},{1},{2},{3}", .A, .R, .G, .B))
            End With
        Next
        Me.Controls.AddRange(Me.colorBox)

        'ユーザー定義
        Dim userLeft As Integer = picw / 2 + (n \ 7) * picw * 1.1
        gbUser.Left = userLeft
        gbUser.Top = topMargin
        gbUser.Height = 3 * pich * 1.1 + topMargin
        gbUser.Width = 4 * picw * 1.1 + leftMargin * 2
        Me.UserColorBox = New PictureBox(7) {}
        For i As Integer = 0 To 7
            Me.UserColorBox(i) = New System.Windows.Forms.PictureBox
            With Me.UserColorBox(i)
                .BackColor = clsSettings.Color.UserColor(i).getColor
                .Width = picw
                .Height = pich
                .BorderStyle = BorderStyle.Fixed3D
                .Tag = i
                .Parent = gbUser
                .Left = leftMargin + (i Mod 4) * picw * 1.1
                .Top = topMargin * 2 + (i \ 4) * pich * 1.1
                AddHandler .MouseMove, AddressOf ColorBoxMouseMove
                AddHandler .MouseLeave, AddressOf ColorBoxMouseLeave
                AddHandler .Click, AddressOf UserColorBoxMouseClick

            End With
            With clsSettings.Color.UserColor(i)
                ToolTip1.SetToolTip(Me.UserColorBox(i), String.Format("argb={0},{1},{2},{3}", .a, .r, .g, .b))
            End With
        Next

        '最近使った色
        gbRecent.Left = userLeft
        gbRecent.Height = 3 * pich * 1.1
        gbRecent.Top = 7 * pich * 1.1 + topMargin - gbRecent.Height
        gbRecent.Width = 4 * picw * 1.1 + leftMargin * 2
        Me.RecentColorBox = New PictureBox(7) {}
        For i As Integer = 0 To 7
            Me.RecentColorBox(i) = New System.Windows.Forms.PictureBox
            With Me.RecentColorBox(i)
                .BackColor = clsSettings.Color.RecentColor(i).getColor
                .Width = picw
                .Height = pich
                .BorderStyle = BorderStyle.Fixed3D
                .Tag = i
                .Parent = gbRecent
                .Left = leftMargin + (i Mod 4) * picw * 1.1
                .Top = topMargin + (i \ 4) * pich * 1.1
                AddHandler .MouseMove, AddressOf ColorBoxMouseMove
                AddHandler .MouseLeave, AddressOf ColorBoxMouseLeave
                AddHandler .Click, AddressOf RecentColorBoxMouseClick
            End With
            With clsSettings.Color.RecentColor(i)
                ToolTip1.SetToolTip(Me.RecentColorBox(i), String.Format("argb={0},{1},{2},{3}", .a, .r, .g, .b))
            End With
        Next

        pnlButtons.Top = 7 * pich * 1.1 + picw / 2
        pnlButtons.Width = picw / 2 + gbRecent.Left + gbRecent.Width
        Me.ClientSize = New Size(pnlButtons.Width, pnlButtons.Top + pnlButtons.Height)
        Dim dd As String = ""
        For i As Integer = 0 To 55
            dd += "'#" + Mid(Convert.ToString(colorBox(i).BackColor.ToArgb, 16), 3) + "'" + ","
        Next
    End Sub
    Private Sub ColorBoxMouseMove(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim pcol As PictureBox = TryCast(sender, PictureBox)
        pcol.BorderStyle = BorderStyle.FixedSingle

    End Sub
    Private Sub ColorBoxMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim pcol As PictureBox = TryCast(sender, PictureBox)
        pcol.BorderStyle = BorderStyle.Fixed3D
    End Sub
    Private Sub RecentColorBoxMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        setPicBackColor(sender.BackColor)
        hsbTransparency.Value = sender.BackColor.A
    End Sub
    Private Sub ColorBoxMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        setPicBackColor(sender.BackColor)
        btnOK.PerformClick()
    End Sub
    Private Sub UserColorBoxMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim pic As PictureBox = CType(sender, PictureBox)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            setPicBackColor(pic.BackColor)
            btnOK.PerformClick()
        Else
            Dim cd As New ColorDialog()
            cd.AllowFullOpen = True
            cd.SolidColorOnly = False
            cd.CustomColors = New Integer() {&H33, &H66, &H99, _
                &HCC, &H3300, &H3333, &H3366, &H3399, &H33CC, _
                &H6600, &H6633, &H6666, &H6699, &H66CC, _
                &H9900, &H9933}

            'ダイアログを表示する
            If cd.ShowDialog(Me) = DialogResult.OK Then
                pic.BackColor = cd.Color
                Dim n As Integer = pic.Tag
                clsSettings.Color.UserColor.Item(n) = New colorARGB(cd.Color)
            End If
        End If
    End Sub

    Private Sub hsbTransparency_Scroll(sender As Object, e As EventArgs) Handles hsbTransparency.ValueChanged
        Dim col As Color = picBackColor.BackColor
        setPicBackColor(Color.FromArgb(hsbTransparency.Value, col.R, col.G, col.B))
        txtAlpha.Text = hsbTransparency.Value
    End Sub

    Private Sub setPicBackColor(ByRef col As Color)
        picBackColor.BackColor = col
        With Me.picBackColor.BackColor
            ToolTip1.SetToolTip(Me.picBackColor, String.Format("argb={0},{1},{2},{3}", .A, .R, .G, .B))
        End With
    End Sub



    Private Sub txtAlpha_TextChanged(sender As Object, e As EventArgs) Handles txtAlpha.LostFocus
        hsbTransparency.Value = Val(txtAlpha.Text)

    End Sub

End Class