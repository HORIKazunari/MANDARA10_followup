Public Class frmMED_TimeObjectCombine
    Dim New_Obj_Time As strYMD

    Dim CloseCancelF As Boolean
    Private Sub frmMED_LineCodeTime_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal CombineObjects As List(Of Integer), ByRef MapData As clsMapData) As Windows.Forms.DialogResult

        lstObjects.Items.Clear()
        For Each ct As Integer In CombineObjects
            With MapData.MPObj(ct)
                lstObjects.Items.Add(.NameTimeSTC(.NumOfNameTime - 1).connectNames)
            End With
        Next
        New_Obj_Time = clsTime.GetNullYMD
        dbdtpCombineTime.Value = New_Obj_Time
        rbNewObject.Checked = True
        Dim objG As Integer = MapData.MPObj(CombineObjects(0)).Kind
        Dim onamelistnum As Integer = MapData.ObjectKind(objG).ObjectNameNum
        Dim oname(onamelistnum - 1) As String
        clsGeneric.setObjectNameToKTGrid(ktObjectName, MapData.ObjectKind, objG, oname)
        Return Me.ShowDialog(Owner)
    End Function
    Public Sub getResult(ByRef LiveObject As Integer, ByRef Connect_Mode As Integer, ByRef Change_ObjName_F As Boolean, ByRef S_time As strYMD, _
                         ByRef End_F As Boolean, ByRef suc_f As Boolean, ByRef O_name As String())
        LiveObject = lstObjects.SelectedIndex

        If rbNewObject.Checked = True Then
            Connect_Mode = 0
        Else
            Connect_Mode = 1
        End If
        If cbObjectNameChange.Checked = True Then
            Change_ObjName_F = False
        Else
            Change_ObjName_F = True
        End If

        S_time = dbdtpCombineTime.Value

        End_F = cbObjectEnd.Checked

        suc_f = cbObjSuccess.Checked
        clsGeneric.getObjectNameFromKtgrid(ktObjectName, O_name)
    End Sub


    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Dim msgText As String = ""
        If dbdtpCombineTime.Value.nullFlag = True And (rbIncorporationObject.Checked = True Or cbObjectEnd.Checked = True Or cbObjSuccess.Checked = True) Then
            msgText = "結合時期を設定してください。"
        End If

        If lstObjects.SelectedIndex = -1 Then
            If rbIncorporationObject.Checked = True Then
                msgText = "編入先オブジェクトを指定してください。"
            Else
                If cbObjectNameChange.Checked = True Then
                    msgText = "新設オブジェクトの代表点オブジェクトを指定してください。"
                Else
                    Dim oname As String()
                    If clsGeneric.getObjectNameFromKtgrid(ktObjectName, oname) = False Then
                        msgText = "オブジェクト名を指定して下さい。"
                    End If
                End If
            End If
        End If
        If msgText <> "" Then
            MsgBox(msgText, MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Exit Sub
        End If
        CloseCancelF = False
    End Sub

    Private Sub rbNewObject_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbNewObject.CheckedChanged
        cbObjectNameChange.Checked = False
        cbObjectNameChange.Text = "新設オブジェクトの代表点オブジェクトと同じ"
        gbDest.Text = "新設オブジェクトの代表点"
    End Sub

    Private Sub frmMED_TimeObjectCombine_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_TimeObjectCombine")
        e.Cancel = True
    End Sub

    Private Sub frmMED_TimeObjectCombine_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rbIncorporationObject_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbIncorporationObject.CheckedChanged
        cbObjectNameChange.Checked = True
        cbObjectNameChange.Text = "変更しない"
        gbDest.Text = "編入先オブジェクト"
    End Sub


End Class