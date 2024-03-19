Public Class frmMain_SelMapObject
    Dim CloseCancelF As Boolean
    Dim MapFileList() As String
    Dim attrData As clsAttrData
    Dim SelMapfile As String
    Dim candidateObject As New List(Of Integer)
    Private Sub frmFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData, ByVal SelectMode As SelectionMode) As Windows.Forms.DialogResult
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        attrData = _attrData
        MapFileList = attrData.GetMapFileName()
        cboMapFile.Items.AddRange(MapFileList)
        cboMapFile.SelectedIndex = 0
        lbList.SelectionMode = SelectMode

        Return Me.ShowDialog

    End Function
    Public Function GetResults(ByRef MapFileName As String, ByRef SelectObjects() As Integer, ByRef Time As strYMD)

        MapFileName = SelMapfile
        If gbTime.Enabled = False Then
            Time = clsTime.GetNullYMD
        Else
            Time = dbdtpTime.Value
        End If
        Dim n As Integer = lbList.SelectedIndices.Count
        ReDim SelectObjects(n - 1)
        For i As Integer = 0 To n - 1
            SelectObjects(i) = candidateObject(lbList.SelectedIndices(i))
        Next
    End Function

    Private Sub change_mapfile()
        SelMapfile = cboMapFile.Text
        clbObjectKindEdit.BeginUpdate()
        clbObjectKindEdit.EventStop = True
        clbObjectKindEdit.Items.Clear()
        With attrData.SetMapFile(SelMapfile)
            For i As Integer = 0 To .Map.OBKNum - 1
                clbObjectKindEdit.Items.Add(.ObjectKind(i).Name, True)
            Next
            gbTime.Enabled = .Map.Time_Mode
        End With
        clbObjectKindEdit.EndUpdate()
        clbObjectKindEdit.EventStop = False
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click


        candidateObject.Clear()
        lbList.Items.Clear()
        Dim tx0 As String = tbName.Text
        Dim tx As String = ""
        For i As Integer = 1 To tx0.Length
            Select Case Asc(Mid(tx0, i, 1))
                Case 10, 13, 8
                Case Else
                    tx += Mid(tx0, i, 1)
            End Select
        Next
        tbName.Text = tx
        clsGeneric.ObjName_Kanji_Compatible(tx)
        Dim tx2 As String = tx & "*"
        Dim tx3 As String = "*" & tx2
        Dim ChkShapeBoxSelected(2) As Boolean

        ChkShapeBoxSelected(enmShape.PointShape) = cbPointShapeEdit.Checked
        ChkShapeBoxSelected(enmShape.LineShape) = cbLineShapeEdit.Checked
        ChkShapeBoxSelected(enmShape.PolygonShape) = cbPolygonShapeEdit.Checked


        lbList.BeginUpdate()
        Dim Time As strYMD = dbdtpTime.Value
        With attrData.SetMapFile(SelMapfile)
            Dim SelF(.Map.Kend) As Boolean
            For Smode As Integer = 0 To 2
                For i As Integer = 0 To .Map.Kend - 1
                    With .MPObj(i)
                        If SelF(i) = False And clbObjectKindEdit.GetItemChecked(.Kind) = True And ChkShapeBoxSelected(.Shape) = True Then
                            Dim f As Boolean = False
                            For j As Integer = 0 To .NumOfNameTime - 1
                                With .NameTimeSTC(j)
                                    If clsTime.checkDurationIn(.SETime, Time) = True Then
                                        Dim objComp As String() = .NamesList.Clone
                                        For k As Integer = 0 To .NamesList.Length - 1
                                            clsGeneric.ObjName_Kanji_Compatible(objComp(k))
                                        Next
                                        Dim okf As Boolean = False
                                        Select Case Smode
                                            Case 0
                                                If Array.IndexOf(objComp, tx) <> -1 Then
                                                    okf = True
                                                End If
                                            Case 1
                                                For k As Integer = 0 To .NamesList.Length - 1
                                                    If (objComp(k) Like tx2) Then
                                                        okf = True
                                                    End If
                                                Next
                                            Case 2
                                                For k As Integer = 0 To .NamesList.Length - 1
                                                    If (objComp(k) Like tx3) Then
                                                        okf = True
                                                    End If
                                                Next
                                        End Select
                                        If okf = True Then
                                            SelF(i) = True
                                            candidateObject.Add(i)
                                            lbList.Items.Add(.connectNames)
                                        End If
                                    End If
                                End With
                            Next
                        End If
                    End With
                Next
            Next
        End With
        lbList.EndUpdate()
        Dim n As Integer = candidateObject.Count
        If n = 0 Then
            Dim msgText = "検索条件に当てはまるオブジェクトは見つかりませんでした。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
        Else
            lbList.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbPolygonShapeEdit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        cbPolygonShapeEdit.CheckedChanged, cbLineShapeEdit.CheckedChanged, cbPointShapeEdit.CheckedChanged,
        clbObjectKindEdit.SelectedIndexChanged, dbdtpTime.ValueChanged
        If Me.Tag = "" And tbName.Text <> "" Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub cboMapFile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMapFile.SelectedIndexChanged
        Me.Tag = "OFF"
        change_mapfile()
        Me.Tag = ""
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If lbList.SelectedIndices.Count = 0 Then
            MsgBox("オブジェクトが選択されていません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
    End Sub
End Class