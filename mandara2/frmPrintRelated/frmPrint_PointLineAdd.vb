Public Class frmPrint_PointLineAdd
    Dim CloseCancelF As Boolean
    Dim KData() As PointF

    Private Sub frmMED_GetPointObject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.None
                If CloseCancelF = True Then
                    CloseCancelF = False
                    e.Cancel = True
                Else
                    e.Cancel = False
                End If
            Case Else
        End Select
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="headTxt">ヘッダのテキスト</param>
    ''' <param name="PresentZahyo">現在の測地系</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal headTxt As String, ByVal PresentZahyoSystem As enmZahyo_System_Info) As Windows.Forms.DialogResult

        Me.Text = headTxt

        lblPresentZahyoSystem.Text = "現在の測地系：" + vbCrLf + clsGeneric.getSokutikeiStrings(PresentZahyoSystem)
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        ResetGrdid(10)
        Return Me.ShowDialog()
    End Function
    Public Function getResult() As PointF()
        Return KData
    End Function

    Private Sub ResetGrdid(ByVal Rows As Integer)
        With ktGrid
            .init("データ", "行", "列", 1, 1, 1, 0, True, True, True, True, False, True, False, False, False, False)
            .AddLayer("", 0, 2, Rows)
            If rbLatLon.Checked = True Then
                .FixedYSData(0, 0, 0) = "緯度"
                .FixedYSData(0, 1, 0) = "経度"
            Else
                .FixedYSData(0, 0, 0) = "経度"
                .FixedYSData(0, 1, 0) = "緯度"
            End If
            .FixedXSWidth(0, 0) = 35
            .GridWidth(0, 0) = (.Width - .FixedXSWidth(0, 0)) / 2 - 10
            .GridWidth(0, 1) = .GridWidth(0, 0)
            .GridAlligntment(0, 0) = HorizontalAlignment.Right
            .GridAlligntment(0, 1) = HorizontalAlignment.Right
            .Show()
        End With
    End Sub

    Private Sub rbLatLon_CheckedChanged(sender As Object, e As EventArgs) Handles rbLatLon.CheckedChanged, rbLonLat.CheckedChanged
        If Me.Tag = "off" Or Me.Visible = False Then
            Return
        End If
        With ktGrid
            If rbLatLon.Checked = True Then
                .FixedYSData(0, 0, 0) = "緯度"
                .FixedYSData(0, 1, 0) = "経度"
            Else
                .FixedYSData(0, 0, 0) = "経度"
                .FixedYSData(0, 1, 0) = "緯度"
            End If
            .Refresh()
        End With
    End Sub
    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click

        clsGeneric.Set_ClipIdoKedo_to_KtgisGrid(ktGrid, 0, rbLatLon.Checked)

    End Sub

    Private Sub btmCheck_Click(sender As Object, e As EventArgs) Handles btmCheck.Click
        If CheckData() = True Then
            MsgBox("エラーは見つかりませんでした。")
        End If
    End Sub
    Private Function CheckData() As Boolean
        Dim n As Integer = ktGrid.Ysize(0)
        If n = 0 Then
            MsgBox("データがありません。", MsgBoxStyle.Exclamation)
            Return False
        End If
        ReDim KData(n - 1)
        Dim Msg As String = ""
        Dim ST(,) As String = ktGrid.GridData(0)
        Dim datan As Integer = 0
        For i As Integer = 0 To n - 1
            If ST(0, i) = "" And ST(1, i) = "" Then
            Else
                Dim hdmes As String = (i + 1).ToString + ":"
                If clsGeneric.Check_IdoKedo_Value(ST(0, i), ST(1, i), rbLatLon.Checked, KData(datan).Y, KData(datan).X, hdmes, Msg) = True Then
                    datan += 1
                End If
            End If
        Next
        If datan = 0 Then
            Msg += "データがありません"
        End If
        If Msg <> "" Then
            clsGeneric.Message(Me, "データに問題があります", Msg, True, False)
            Return False
        Else
            ReDim Preserve KData(datan - 1)
            Return True
        End If
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If CheckData() = False Then
            CloseCancelF = True
            Return
        End If
        CloseCancelF = False
    End Sub

    Private Sub frmPrint_PointLineAdd_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.OutputWindow, "frmPrint_PointLineAdd", Me)
        e.Cancel = True
    End Sub
End Class