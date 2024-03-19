Public Class frmMakeLineCrossPattern
    Dim LinePattern As Cross_Line_Data_Info
    Dim attrData As clsAttrData

    Private lblParts() As System.Windows.Forms.Label
    Private cbUsePart() As System.Windows.Forms.CheckBox
    Private cboShape() As System.Windows.Forms.ComboBox
    Private cboPartsInterval() As System.Windows.Forms.ComboBox
    Private cboPartsLength() As System.Windows.Forms.ComboBox
    Private picColor() As System.Windows.Forms.PictureBox
    Private cboPartsWidth() As System.Windows.Forms.ComboBox
    Private btnMark() As System.Windows.Forms.Button
    Public Overloads Function ShowDialog(ByVal LinePat As Cross_Line_Data_Info, ByRef _attrData As clsAttrData) As Windows.Forms.DialogResult
        Dim partsHeight As Integer = 25
        LinePattern = LinePat
        attrData = _attrData
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Center)
        lblParts = New System.Windows.Forms.Label(5) {}
        cbUsePart = New System.Windows.Forms.CheckBox(5) {}
        cboShape = New System.Windows.Forms.ComboBox(5) {}
        cboPartsInterval = New System.Windows.Forms.ComboBox(5) {}
        cboPartsLength = New System.Windows.Forms.ComboBox(5) {}
        picColor = New System.Windows.Forms.PictureBox(5) {}
        cboPartsWidth = New System.Windows.Forms.ComboBox(5) {}
        btnMark = New System.Windows.Forms.Button(5) {}

        Dim tp As Integer = lblUseParts.Top + lblUseParts.Height + 5
        Me.SuspendLayout()
        For i As Integer = 0 To 5
            Me.lblParts(i) = New System.Windows.Forms.Label
            cbUsePart(i) = New System.Windows.Forms.CheckBox
            cboShape(i) = New System.Windows.Forms.ComboBox
            cboPartsInterval(i) = New System.Windows.Forms.ComboBox
            cboPartsLength(i) = New System.Windows.Forms.ComboBox
            picColor(i) = New System.Windows.Forms.PictureBox
            cboPartsWidth(i) = New System.Windows.Forms.ComboBox
            btnMark(i) = New System.Windows.Forms.Button
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
            With cboShape(i)
                .Top = tp
                .Left = lblXlineShape.Left
                .Width = lblXPartsInterval.Left - lblXlineShape.Left - 5
                .DropDownStyle = ComboBoxStyle.DropDownList
                .Tag = i
                AddHandler .SelectedIndexChanged, AddressOf cboShape_SelectedIndexChanged
                .Enabled = False
            End With
            With cboPartsInterval(i)
                .Top = tp
                .Left = lblXPartsInterval.Left
                .Width = lblXPartsInterval.Width
                .Tag = i
                .Enabled = False
            End With
            With cboPartsLength(i)
                .Top = tp
                .Left = lblXPartsLength.Left + 10
                .Width = cboPartsInterval(i).Width
                .Tag = i
                .Enabled = False
            End With

            With Me.picColor(i)
                .Top = tp
                .Left = lblColor.Left
                .Width = lblPartsWidth.Left - lblColor.Left - 5
                .Height = partsHeight
                .BorderStyle = BorderStyle.Fixed3D
                .Enabled = False
                .Tag = i
                AddHandler .Click, AddressOf picColor_Click
            End With
            With cboPartsWidth(i)
                .Top = tp
                .Left = lblPartsWidth.Left + 15
                .Enabled = False
                .Width = cboPartsLength(i).Width
            End With
            With btnMark(i)
                .Top = tp
                .Left = lblPartsWidth.Left + 15
                .Enabled = False
                .Width = cboPartsLength(i).Width
                .Text = "記号"
                .Tag = i
                AddHandler .Click, AddressOf btnMark_click
            End With
            tp += partsHeight + 10
        Next
        btnOK.Top = tp
        btnCancel.Top = tp
        Me.ClientSize = New Size(Me.ClientSize.Width, tp + btnCancel.Height + 10)
        For i As Integer = 0 To 5
            cboShape(i).Items.Add("線")
            cboShape(i).Items.Add("円")
            cboShape(i).Items.Add("四角")
            cboShape(i).Items.Add("記号")
            cboPartsWidth(i).Items.Add("最小")
            For si As Single = 0.1 To 0.9 Step 0.2
                Dim wd As String = FormatNumber(si, 1)
                cboPartsInterval(i).Items.Add(wd)
                cboPartsLength(i).Items.Add(wd)
                cboPartsWidth(i).Items.Add(wd)
            Next
            For j As Integer = 1 To 5
                Dim wd As String = FormatNumber(j, 1)
                cboPartsInterval(i).Items.Add(wd)
                cboPartsLength(i).Items.Add(wd)
                cboPartsWidth(i).Items.Add(wd)
            Next
        Next
        Me.Controls.AddRange(Me.lblParts)
        Me.Controls.AddRange(Me.cbUsePart)
        Me.Controls.AddRange(Me.cboShape)
        Me.Controls.AddRange(Me.cboPartsInterval)
        Me.Controls.AddRange(Me.cboPartsLength)
        Me.Controls.AddRange(Me.picColor)
        Me.Controls.AddRange(Me.cboPartsWidth)
        Me.Controls.AddRange(Me.btnMark)
        Me.ResumeLayout(False)

        With LinePattern
            For i As Integer = 0 To 5
                Dim part As Optional_X_Line_Data_info = .Get_CrossLineParts(i)
                With part
                    cbUsePart(i).Checked = .Use_F
                    cboPartsLength(i).Text = .Length
                    cboShape(i).SelectedIndex = .pattern
                    cboPartsInterval(i).Text = .Interval
                    cboPartsLength(i).Text = .Length
                    If .Width = 0 Then
                        cboPartsWidth(i).SelectedIndex = 0
                    Else
                        cboPartsWidth(i).Text = .Width
                    End If
                    picColor(i).BackColor = .Color.getColor
                End With
            Next
        End With

        Return Me.ShowDialog()
    End Function

    Public Function getResult() As Cross_Line_Data_Info
        With LinePattern
            For i As Integer = 0 To 5
                Dim part As Optional_X_Line_Data_info = LinePattern.Get_CrossLineParts(i)
                With part
                    .Use_F = cbUsePart(i).Checked
                    .pattern = cboShape(i).SelectedIndex
                    .Interval = Val(cboPartsInterval(i).Text)
                    .Length = Val(cboPartsLength(i).Text)
                    If cboPartsWidth(i).SelectedIndex = 0 Then
                        .Width = 0
                    Else
                        .Width = Val(cboPartsWidth(i).Text)
                    End If
                    .Color = New colorARGB(picColor(i).BackColor)
                End With
                .Set_CrossLineParts(i, part)
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
        cboShape(i).Enabled = v
        cboPartsInterval(i).Enabled = v
        cboPartsLength(i).Enabled = v
        picColor(i).Enabled = v
        cboPartsWidth(i).Enabled = v
        btnMark(i).Enabled = v
    End Sub
    Private Sub cboShape_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim i As Integer = sender.tag
        Select Case cboShape(i).SelectedIndex
            Case enmLineCrossPattern.Line
                btnMark(i).Visible = False
                cboPartsWidth(i).Visible = True
            Case enmLineCrossPattern.Mark
                btnMark(i).Visible = True
                cboPartsWidth(i).Visible = False
                lblPartsWidth.Visible = True
            Case Else
                btnMark(i).Visible = False
                cboPartsWidth(i).Visible = False
        End Select
    End Sub
    Private Sub btnMark_click(sender As Object, e As EventArgs)
        Dim i As Integer = sender.tag
        Dim part As Optional_X_Line_Data_info = LinePattern.Get_CrossLineParts(i)
        If clsGeneric.TileMark_Set(part.TileMark, New colorARGB(picColor(i).BackColor), attrData, False) = True Then
            LinePattern.Set_CrossLineParts(i, part)
        End If
    End Sub
End Class