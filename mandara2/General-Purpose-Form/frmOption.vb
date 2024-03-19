Public Class frmOption
    Dim ScrData As Screen_info
    Dim MapCompassMK As Mark_Property
    Dim basePic As BasePicture_Info
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef _ScrData As Screen_info,
                                         ByRef _basePic As BasePicture_Info) As Windows.Forms.DialogResult
        ScrData = _ScrData
        basePic = _basePic
        cbSinKyuCharacter.Checked = clsSettings.Data.SinKyuCharacter
        cbKatakanaCheck.Checked = clsSettings.Data.KatakanaCheck
        With cboBaseFont
            .Items.Clear()
            For i As Integer = 0 To clsFontList_inPC.FontFamilyList.GetLength(0) - 1
                .Items.Add(clsFontList_inPC.FontFamilyList(i).Name)
            Next
            .Text = clsSettings.Data.SetFont
        End With
        If clsSettings.Data.Ido_Kedo_Print_Pattern = enmLatLonPrintPattern.DegreeMinuteSecond Then
            rbLatLonDMS.Checked = True
        Else
            rbLatLonDecimal.Checked = True
        End If

        tracBarBackImageSpeed.Value = clsSettings.Data.BackImageSpeed
        chkAntiAlias.Checked = clsSettings.Data.AntiAlias

        If clsSettings.Data.Directory.MapFolder_Default = enmMapFolder_Default_info.MapFolder Then
            rbMapFolderMAP.Checked = True
        Else
            rbMapFolderLastSelected.Checked = True
        End If

        MapCompassMK = clsBase.Mark
        MapCompassMK.ShapeNumber = clsSettings.Data.Compass_Mark
        clsDrawMarkFan.Draw_Mark_Sample_Box(picCompass, MapCompassMK, ScrData, basePic)



        With cboCompassSize
            With .Items
                .Clear()
                For si As Single = 0.5 To 5 Step 0.5
                    .Add(FormatNumber(si, 1))
                Next
                For i As Integer = 6 To 20
                    .Add(FormatNumber(i, 1))
                Next
            End With
            .Text = clsSettings.Data.Compass_Mark_Size
        End With

        clsGeneric.AddProjectionName2ComboBoxEx(cboDefProjection)

        With cboDefoHanreiColor
            .Items.Clear()
            .Items.Add("グレー系統")
            .Items.Add("赤系統")
            .Items.Add("青系統")
            .SelectedIndex = clsSettings.Data.defoHanreiColor
        End With


        With clsSettings.Data.MapEditor
            picMED_Backcolor.BackColor = .Backcolor.getColor
            picMED_LineColor.BackColor = .LineColor.getColor
            picMED_LineColorDisabled.BackColor = .LineColorDisabled.getColor
            picMED_LineColorSelected.BackColor = .LineColorSelected.getColor
            picMED_LineColorPoints.BackColor = .LineColorPoints.getColor
            picMED_ObjectLineColor.BackColor = .ObjectLineColor.getColor
            picMED_ObjectLineColorDisabled.BackColor = .ObjectLineColorDisabled.getColor
            picMED_ObjectTimeLineColor.BackColor = .ObjectTimeLineColor.getColor
            txtMEDObjectNameMaxNumber.Text = .ObjectNamePrinting_Maxmun
            picMED_ObjectNameColor.BackColor = .ObjectNameColor.getColor
        End With
        cboDefProjection.Text = clsGeneric.getStringProjectionEnum(clsSettings.Data.default_Projection)

        With cboObjectNameSize
            With .Items
                .Clear()
                For i As Integer = 5 To 20
                    .Add(i)
                Next
            End With
            .Text = clsSettings.Data.MapEditor.ObjectNameSize
        End With

        Return Me.ShowDialog(Owner)
    End Function

    Public Sub getResult()

    End Sub

    Private Sub frmOption_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmOption", Me)
    End Sub

    Private Sub frmOption_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAddCompatibleCharacter_Click(sender As Object, e As EventArgs) Handles btnAddCompatibleCharacter.Click
        With ktGridCompatibleCharacter

            .AddObject(0, .Ysize(0), 1)
            .Show()
        End With
    End Sub

    Private Sub btnDeleteCompatibleCharacter_Click(sender As Object, e As EventArgs) Handles btnDeleteCompatibleCharacter.Click
        With ktGridCompatibleCharacter
            Dim n As Integer = 0
            Dim rect As Rectangle = .SelectedArea(0)
            If rect.Height = 0 Then
                MsgBox("削除する項目を選択して下さい。")
                Return
            ElseIf .Ysize(0) <= rect.Height Then
                MsgBox("すべて削除することはできません。" + vbCrLf + "削除したい項目を空白にして下さい。")
                Return
            End If
            .RemoveObject(0, rect.Y, rect.Height)
            .Show()
        End With
    End Sub

    Private Sub picturebox_Click(sender As Object, e As EventArgs) Handles picMED_Backcolor.Click, picMED_LineColorDisabled.Click,
                picMED_LineColorDisabled.Click, picMED_LineColorSelected.Click, picMED_LineColorPoints.Click, picMED_ObjectLineColor.Click,
                picMED_ObjectLineColorDisabled.Click, picMED_ObjectTimeLineColor.Click, picMED_ObjectNameColor.Click, picMED_LineColor.Click
        Dim p As PictureBox = CType(sender, PictureBox)
        Dim col As colorARGB = New colorARGB(p.BackColor)
        '違うWindowsを出すと、フォーカスがTabIndex0に移動し、スクロールしてしまう。Tabindex0のコントロールが、ラベル等フォーカスを受け付けない
        'コントロールに設定しておく必要がある
        p.Focus()
        If clsGeneric.Color_Set(col) = True Then
            p.BackColor = col.getColor
        End If
    End Sub

    Private Sub picCompass_Click(sender As Object, e As EventArgs) Handles picCompass.Click

        Dim form As New frmMark_Select
        If form.ShowDialog(ScrData, basePic) = Windows.Forms.DialogResult.OK Then
            MapCompassMK.ShapeNumber = form.getResult
            clsDrawMarkFan.Draw_Mark_Sample_Box(picCompass, MapCompassMK, ScrData, basePic)
        End If
        form.Dispose()
    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        With ktGridCompatibleCharacter
            Dim data(,) As String = .GridData(0)
            Dim WC(.Ysize(0) - 1) As String
            Dim n = 0
            For i As Integer = 0 To .Ysize(0) - 1
                If data(0, i) <> "" Then
                    WC(n) = data(0, i)
                    n += 1
                End If
            Next
            clsSettings.Data.ObjectName_Word_Compatible = String.Join("|", WC, 0, n)
        End With
        clsSettings.Data.SinKyuCharacter = cbSinKyuCharacter.Checked
        clsSettings.Data.KatakanaCheck = cbKatakanaCheck.Checked
        clsSettings.Data.SetFont = cboBaseFont.Text
        clsSettings.Data.BackImageSpeed = tracBarBackImageSpeed.Value
        clsSettings.Data.AntiAlias = chkAntiAlias.Checked
        clsSettings.Data.defoHanreiColor = cboDefoHanreiColor.SelectedIndex

        Select Case True
            Case rbLatLonDMS.Checked
                clsSettings.Data.Ido_Kedo_Print_Pattern = enmLatLonPrintPattern.DegreeMinuteSecond
            Case rbLatLonDecimal.Checked
                clsSettings.Data.Ido_Kedo_Print_Pattern = enmLatLonPrintPattern.DecimalDegree
        End Select

        Select Case True
            Case rbMapFolderMAP.Checked
                clsSettings.Data.Directory.MapFolder_Default = enmMapFolder_Default_info.MapFolder
            Case rbMapFolderLastSelected.Checked
                clsSettings.Data.Directory.MapFolder_Default = enmMapFolder_Default_info.LastAccesedFolder
        End Select

        clsSettings.Data.Compass_Mark = MapCompassMK.ShapeNumber
        clsSettings.Data.default_Projection = clsGeneric.getProjectionEnum_fromStrings(cboDefProjection.Text)

        clsSettings.Data.Compass_Mark_Size = Val(cboCompassSize.Text)

        With clsSettings.Data.MapEditor
            .Backcolor.setColor(picMED_Backcolor.BackColor)
            .LineColor.setColor(picMED_LineColor.BackColor)
            .LineColorDisabled.setColor(picMED_LineColorDisabled.BackColor)
            .LineColorSelected.setColor(picMED_LineColorSelected.BackColor)
            .LineColorPoints.setColor(picMED_LineColorPoints.BackColor)
            .ObjectLineColor.setColor(picMED_ObjectLineColor.BackColor)
            .ObjectLineColorDisabled.setColor(picMED_ObjectLineColorDisabled.BackColor)
            .ObjectTimeLineColor.setColor(picMED_ObjectTimeLineColor.BackColor)

            .ObjectNamePrinting_Maxmun = Val(txtMEDObjectNameMaxNumber.Text)
            .ObjectNameColor.setColor(picMED_ObjectNameColor.BackColor)
        End With

        clsSettings.Data.MapEditor.ObjectNameSize = Val(cboObjectNameSize.Text)
    End Sub

    Private Sub frmOption_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With ktGridCompatibleCharacter
            .init("データ", "行", "列", 1, 0, 0, 0, False, False, True, False, False, False, False, False, False, False)
            Dim Word_Compatible() As String = clsSettings.Data.ObjectName_Word_Compatible.Split("|")
            Dim n As Integer = Word_Compatible.Length
            .AddLayer("", 0, 1, n)
            .GridWidth(0, 0) = ktGridCompatibleCharacter.Width - .FixedXSWidth(0, 0) - 20
            .GridAlligntment(0, 0) = HorizontalAlignment.Left
            For i As Integer = 0 To n - 1
                .GridData(0, 0, i) = Word_Compatible(i)
            Next
            .Show()
        End With
    End Sub

    Private Sub pnlOption_Paint(sender As Object, e As PaintEventArgs) Handles pnlOption.Paint

    End Sub


End Class