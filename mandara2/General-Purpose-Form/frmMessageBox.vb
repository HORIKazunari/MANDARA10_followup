Public Class frmMessageBox
    Dim Style As MessageBoxButtons
    Dim bt As DialogResult
    Public Overloads Function ShowDialog(ByVal StartPos As FormStartPosition, ByVal Mes As String, ByVal _Style As MessageBoxButtons, ByVal mIcon As MessageBoxIcon) As DialogResult
        Me.StartPosition = StartPos
        If StartPos = FormStartPosition.Manual Then
            clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        End If
        Style = _Style
        lblMessage.Text = Mes
        Dim bmp As New Bitmap(picIcon.Width, picIcon.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        Select Case mIcon
            Case MessageBoxIcon.Asterisk
                g.DrawIcon(SystemIcons.Asterisk, 0, 0)
            Case MessageBoxIcon.Error
                g.DrawIcon(SystemIcons.Error, 0, 0)
            Case MessageBoxIcon.Exclamation
                g.DrawIcon(SystemIcons.Exclamation, 0, 0)
            Case MessageBoxIcon.Hand
                g.DrawIcon(SystemIcons.Hand, 0, 0)
            Case MessageBoxIcon.Information
                g.DrawIcon(SystemIcons.Information, 0, 0)
            Case MessageBoxIcon.None
                lblMessage.Left = picIcon.Left
                lblMessage.Width += picIcon.Width
                picIcon.Visible = False
            Case MessageBoxIcon.Question
                g.DrawIcon(SystemIcons.Question, 0, 0)
            Case MessageBoxIcon.Stop
            Case MessageBoxIcon.Warning
                g.DrawIcon(SystemIcons.Warning, 0, 0)
        End Select
        g.Dispose()
        picIcon.Image = bmp

        Select Case Style
            Case MessageBoxButtons.OK
                btn3.Visible = False
                btnOK.Text = "OK(&O)"
                btnCancel.Visible = False
                btnOK.DialogResult = Windows.Forms.DialogResult.OK
                btnOK.Location = btn3.Location
            Case MessageBoxButtons.OKCancel
                btn3.Visible = False
                btnOK.DialogResult = Windows.Forms.DialogResult.OK
                btnOK.Text = "OK(&O)"
                btnCancel.Text = "キャンセル(&C)"
                btnCancel.DialogResult = Windows.Forms.DialogResult.Cancel
                btnOK.Location = btnCancel.Location
                btnCancel.Location = btn3.Location
            Case MessageBoxButtons.RetryCancel
                btn3.Visible = False
                btnOK.Text = "再試行(&R)"
                btnOK.DialogResult = Windows.Forms.DialogResult.Retry
                btnCancel.Text = "キャンセル(&C)"
                btnCancel.DialogResult = Windows.Forms.DialogResult.Cancel
                btnOK.Location = btnCancel.Location
                btnCancel.Location = btn3.Location
            Case MessageBoxButtons.YesNo
                btnOK.Text = "はい(&Y)"
                btnCancel.Text = "いいえ(&N)"
                btn3.Visible = False
                btnOK.DialogResult = Windows.Forms.DialogResult.Yes
                btnCancel.DialogResult = Windows.Forms.DialogResult.No
                btnOK.Location = btnCancel.Location
                btnCancel.Location = btn3.Location
            Case MessageBoxButtons.YesNoCancel
                btnOK.Text = "はい(&Y)"
                btnCancel.Text = "いいえ(&N)"
                btn3.Text = "キャンセル(&C)"
                btnOK.DialogResult = Windows.Forms.DialogResult.Yes
                btnCancel.DialogResult = Windows.Forms.DialogResult.No
                btn3.DialogResult = Windows.Forms.DialogResult.Cancel
            Case MessageBoxButtons.AbortRetryIgnore
                btnOK.Text = "中止(&A)"
                btnCancel.Text = "再試行(&R)"
                btn3.Text = "無視(I)"
                btnOK.DialogResult = Windows.Forms.DialogResult.Abort
                btnCancel.DialogResult = Windows.Forms.DialogResult.Retry
                btn3.DialogResult = Windows.Forms.DialogResult.Ignore
        End Select
        Return Me.ShowDialog()
    End Function



End Class