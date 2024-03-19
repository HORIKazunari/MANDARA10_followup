Public Class frmPrint_PrintOut
    Dim attrData As clsAttrData
    Dim pd As New System.Drawing.Printing.PrintDocument
    Dim picMapSize As Size
    Dim PrintArea As Rectangle
    Dim MaxWidth As Integer
    Dim SizeRate As Single
    Dim pdlg As New PrintDialog
    Dim picMapAreaNewSize As Size  '移動位置の保存用変数

    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef _attrData As clsAttrData,
                                         ByRef _picMap As PictureBox, ByRef _pd As System.Drawing.Printing.PrintDocument) As Windows.Forms.DialogResult
        Me.Tag = "OFF"
        attrData = _attrData
        For i As Integer = 100 To 10 Step -10
            cboSize.Items.Add(i)
        Next
        cboSize.SelectedIndex = 0
        SizeRate = 1
        picPaper.Parent = picOuter
        picPrintArea.Parent = picPaper
        picMapArea.Parent = picPrintArea
        pd = _pd
        pdlg.Document = pd
        Me.Tag = ""
        picMapSize = _picMap.Size
        picMapArea.SizeMode = PictureBoxSizeMode.StretchImage
        picMapArea.Image = _picMap.Image
        Return (Me.ShowDialog(Owner))

    End Function
    Public Sub getResults(ByRef Mul As Single, ByRef Xplus As Single, ByRef YPlus As Single)
        Mul = (MaxWidth * SizeRate) / picMapSize.Width
        Xplus = PrintArea.Width * (picMapArea.Left / picPrintArea.Width)
        YPlus = PrintArea.Height * (picMapArea.Top / picPrintArea.Height)
    End Sub
    Private Sub btnPrinterSettings_Click(sender As Object, e As EventArgs) Handles btnPrinterSettings.Click

        '印刷の選択ダイアログを表示する
        If pdlg.ShowDialog() = DialogResult.OK Then
            Me.Tag = "OFF"
            cboSize.SelectedIndex = 0
            Me.Tag = ""
            SizeRate = 1
            PaperSizeSet()
        End If
    End Sub


    Sub PaperSizeSet()
        Dim pxs As Integer, pys As Integer, fxs As Integer, fys As Integer
        Dim PaperSize As Size

        lblPrinter.Text = pd.PrinterSettings.PrinterName
        With pd.PrinterSettings.DefaultPageSettings
            Dim PResoX = .PrinterResolution.X / 100
            Dim PResoY = .PrinterResolution.Y / 100

            Dim w As Integer = .Bounds.Width * PResoX
            Dim h As Integer = .Bounds.Height * PResoY
            PaperSize = New Size(w, h)
            If .Landscape = True Then
                With .PrintableArea
                    PrintArea = New Rectangle(New Point(.Left * PResoX, .Top * PResoY), New Size(.Height * PResoX, .Width * PResoY))
                End With
            Else
                With .PrintableArea
                    PrintArea = New Rectangle(New Point(.Left * PResoX, .Top * PResoY), New Size(.Width * PResoX, .Height * PResoY))
                End With
            End If
        End With

        Dim w2 As Integer
        Dim h2 As Integer
        If PaperSize.Width >= PaperSize.Height Then
            w2 = picOuter.Width
            h2 = w2 * (PaperSize.Height / PaperSize.Width)
        Else
            h2 = picOuter.Height
            w2 = h2 * (PaperSize.Width / PaperSize.Height)
        End If
        With picPaper
            .Width = w2
            .Height = h2
            .Left = picOuter.Width / 2 - w2 / 2
            .Top = picOuter.Height / 2 - h2 / 2
        End With

        With picPrintArea
            .Width = picPaper.Width * (PrintArea.Width / PaperSize.Width)
            .Height = picPaper.Height * (PrintArea.Height / PaperSize.Height)
            .Left = picPaper.Width * (PrintArea.Left / PaperSize.Width)
            .Top = picPaper.Height * (PrintArea.Top / PaperSize.Height)
        End With

        Dim FN = picMapSize.Width / picMapSize.Height
        Dim fnp = PrintArea.Width / PrintArea.Height

        Dim MaxHeight As Integer
        Dim Xplus As Integer
        Dim Yplus As Integer
        If FN >= fnp Then
            MaxWidth = PrintArea.Width
            MaxHeight = MaxWidth * (picMapSize.Height / picMapSize.Width)
            Xplus = 0
            Yplus = (PrintArea.Height - MaxHeight) / 2
        Else
            MaxHeight = PrintArea.Height
            MaxWidth = MaxHeight * (picMapSize.Width / picMapSize.Height)
            Xplus = (PrintArea.Width - MaxWidth) / 2
            Yplus = 0
        End If
        With picMapArea
            .Width = picPrintArea.Width * (MaxWidth / PrintArea.Width) * SizeRate
            .Height = picPrintArea.Height * (MaxHeight / PrintArea.Height) * SizeRate
            .Left = picPrintArea.Width * (Xplus / PrintArea.Width)
            .Top = picPrintArea.Height * (Yplus / PrintArea.Height)
        End With

    End Sub


    Private Sub frmPrint_PrintOut_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        PaperSizeSet()
    End Sub

    Private Sub cboSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSize.SelectedIndexChanged
        If Me.Tag = "OFF" Then
            Return
        End If
        SizeRate = Val(cboSize.Text) / 100
        PaperSizeSet()
    End Sub


    Private Sub picMapArea_MouseDown(sender As Object, e As MouseEventArgs) Handles picMapArea.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            'ドラッグ開始時点の位置を取得
            picMapAreaNewSize = New Size(e.X, e.Y)

        End If
    End Sub

    Private Sub picMapArea_MouseMove(sender As Object, e As MouseEventArgs) Handles picMapArea.MouseMove
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            'ドラッグ中の位置情報を取得して、その位置に表示

            picMapArea.Location = Point.op_Subtraction(picPrintArea.PointToClient(System.Windows.Forms.Cursor.Position), picMapAreaNewSize)
        End If
    End Sub


End Class