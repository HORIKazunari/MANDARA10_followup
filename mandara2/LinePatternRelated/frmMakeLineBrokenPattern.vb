Public Class frmMakeLineBrokenPattern
    Dim LinePattern As Line_Basic_Data_Info
    Private lblParts() As System.Windows.Forms.Label
    Private cbUsePart() As System.Windows.Forms.CheckBox
    Private cboPartsLength() As System.Windows.Forms.ComboBox
    Private cbPartsPrint() As System.Windows.Forms.CheckBox
    Private picColor() As System.Windows.Forms.PictureBox
    Private cboPartsWidth() As System.Windows.Forms.ComboBox



    Public Overloads Function ShowDialog(ByVal LinePat As Line_Basic_Data_Info) As Windows.Forms.DialogResult
        Dim partsHeight As Integer = 25
        LinePattern = LinePat
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Center)
        Me.lblParts = New System.Windows.Forms.Label(5) {}
        cbUsePart = New System.Windows.Forms.CheckBox(5) {}
        cboPartsLength = New System.Windows.Forms.ComboBox(5) {}
        cbPartsPrint = New System.Windows.Forms.CheckBox(5) {}
        Me.picColor = New System.Windows.Forms.PictureBox(5) {}
        cboPartsWidth = New System.Windows.Forms.ComboBox(5) {}

        Dim tp As Integer = lblUseParts.Top + lblUseParts.Height + 5
        Me.SuspendLayout()
        For i As Integer = 0 To 5
            Me.lblParts(i) = New System.Windows.Forms.Label
            cbUsePart(i) = New System.Windows.Forms.CheckBox
            cboPartsLength(i) = New System.Windows.Forms.ComboBox
            cbPartsPrint(i) = New System.Windows.Forms.CheckBox
            Me.picColor(i) = New System.Windows.Forms.PictureBox
            cboPartsWidth(i) = New System.Windows.Forms.ComboBox
            With Me.lblParts(i)
                .Top = tp
                .Left = 10
                .Text = "パーツ" + CStr(i + 1)
                .Width = 50
            End With
            With cbUsePart(i)
                .Top = tp
                .Left = lblUseParts.Left + lblUseParts.Width / 2 - 10
                .Width = 20
                .Tag = i
                AddHandler .CheckedChanged, AddressOf cbUsePart_CheckedChanged
            End With
            With cboPartsLength(i)
                .Top = tp
                .Left = lblPartLenth.Left
                .Width = lblPartsPrint.Left - lblPartLenth.Left - 5
                .Enabled = False
            End With
            With cbPartsPrint(i)
                .Top = tp
                .Left = lblPartsPrint.Left + 10
                .Width = 20
                .Tag = i
                AddHandler .CheckedChanged, AddressOf cbPartsPrint_CheckedChanged
                .Enabled = False
            End With
            With Me.picColor(i)
                .Top = tp
                .Left = lblColor.Left
                .Width = lblPartsWidth.Left - lblColor.Left - 5
                .Height = partsHeight
                .BorderStyle = BorderStyle.Fixed3D
                .Enabled = False
                .Visible = True
                AddHandler .Click, AddressOf picColor_Click
            End With
            With cboPartsWidth(i)
                .Top = tp
                .Left = lblPartsWidth.Left
                .Enabled = False
                .Width = cboPartsLength(i).Width
                .Visible = True
            End With

            tp += partsHeight + 10
        Next
        btnOK.Top = tp
        btnCancel.Top = tp
        Me.ClientSize = New Size(Me.ClientSize.Width, tp + btnCancel.Height + 10)

        For i As Integer = 0 To 5
            cboPartsWidth(i).Items.Add("最小")
            For si As Single = 0.1 To 0.9 Step 0.2
                Dim wd As String = FormatNumber(si, 1)
                cboPartsLength(i).Items.Add(wd)
                cboPartsWidth(i).Items.Add(wd)
            Next
            For j As Integer = 1 To 5
                Dim wd As String = FormatNumber(j, 1)
                cboPartsLength(i).Items.Add(wd)
                cboPartsWidth(i).Items.Add(wd)
            Next
        Next
        Me.Controls.AddRange(Me.lblParts)
        Me.Controls.AddRange(Me.cbUsePart)
        Me.Controls.AddRange(Me.cboPartsLength)
        Me.Controls.AddRange(Me.cbPartsPrint)
        Me.Controls.AddRange(Me.picColor)
        Me.Controls.AddRange(Me.cboPartsWidth)
        Me.ResumeLayout(False)

        With LinePattern
            For i As Integer = 0 To 5
                Dim part As OptionalLine_Data_info = .Get_CenterLineParts(i)
                With part
                    cbUsePart(i).Checked = .Use_F
                    cboPartsLength(i).Text = .Length
                    If .Width = 0 Then
                        cboPartsWidth(i).SelectedIndex = 0
                    Else
                        cboPartsWidth(i).Text = .Width
                    End If
                    cbPartsPrint(i).Checked = Not .Print_f
                    picColor(i).BackColor = .Color.getColor
                End With
            Next
        End With


        Return Me.ShowDialog()
    End Function

    Public Function getResult() As Line_Basic_Data_Info
        With LinePattern
            For i As Integer = 0 To 5
                Dim part As OptionalLine_Data_info
                With part
                    .Use_F = cbUsePart(i).Checked
                    .Length = Val(cboPartsLength(i).Text)
                    If cboPartsWidth(i).SelectedIndex = 0 Then
                        .Width = 0
                    Else
                        .Width = Val(cboPartsWidth(i).Text)
                    End If
                    .Print_f = Not cbPartsPrint(i).Checked

                    .Color = New colorARGB(picColor(i).BackColor)
                End With
                .Set_CenterLineParts(i, part)
            Next
        End With
        Return LinePattern
    End Function

    Private Sub picColor_Click(sender As Object, e As EventArgs)
        Dim col As colorARGB = New colorARGB(CType(sender, System.Windows.Forms.PictureBox).BackColor)
        If clsGeneric.Color_Set(col) = True Then
            sender.BackColor = col.getColor
        End If
    End Sub
    Private Sub cbUsePart_CheckedChanged(sender As Object, e As EventArgs)
        Dim i As Integer = sender.tag
        Dim v As Boolean = CType(sender, System.Windows.Forms.CheckBox).Checked

        cboPartsLength(i).Enabled = v
        cbPartsPrint(i).Enabled = v
        picColor(i).Enabled = v
        cboPartsWidth(i).Enabled = v
    End Sub
    Private Sub cbPartsPrint_CheckedChanged(sender As Object, e As EventArgs)
        Dim i As Integer = sender.tag
        Dim v As Boolean = Not CType(sender, System.Windows.Forms.CheckBox).Checked

        picColor(i).Visible = v
        cboPartsWidth(i).Visible = v
    End Sub

End Class