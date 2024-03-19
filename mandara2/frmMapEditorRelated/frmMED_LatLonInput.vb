Public Class frmMED_LatLonInput
    Dim CloseCancelF As Boolean
    Dim LatPlus As Single
    Dim LonPlus As Single
    Dim Type As Integer
    Private Sub frmMED_LatLonInput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    ''' <param name="Owner"></param>
    ''' <param name="defoLat"></param>
    ''' <param name="defoLon"></param>
    ''' <param name="_Type">0:緯度経度　　 1:XY</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal defoLat As Single, ByVal defoLon As Single, ByVal _Type As Integer) As Windows.Forms.DialogResult
        txtLat.Text = defoLat.ToString
        txtLon.Text = defoLon.ToString
        Type = _Type
        If Type = 0 Then
            Me.Text = "緯度経度平行移動"
            lblXdegree.Text = "度"
            lblYdegree.Text = "度"
            lblX.Text = "経度"
            lblY.Text = "緯度"
        Else
            Me.Text = "平行移動"
            lblXdegree.Text = ""
            lblYdegree.Text = ""
            lblX.Text = "X"
            lblY.Text = "Y"
        End If
        Return Me.ShowDialog(Owner)
    End Function
    Public Function getResult() As PointF

        Return New PointF(LonPlus, LatPlus)
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim LatV As String = txtLat.Text
        Dim LonV As String = txtLon.Text
        Dim msg As String = ""
        If clsGeneric.Check_Suji(LatV) = False Or clsGeneric.Check_Suji(LonV) = False Then
            MsgBox("半角数字以外の文字が含まれています。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
        LatPlus = Val(LatV)
        LonPlus = Val(LonV)
        If 90 < Math.Abs(LatPlus) And Type = 0 Then
            MsgBox("緯度は-90から90度の範囲で設定してください。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
    End Sub
End Class