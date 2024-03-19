Public Class frmCopyObjectName
    Public Class init_parameter_data
        Public ObjName As String
        Public Time As strYMD
        Public TimeChangeEnabled As Boolean
        Public pointShapeChecked As Boolean
        Public lineShapeChecked As Boolean
        Public polygonShapeChecked As Boolean
        Public ShapeChangeEnabled As Boolean
        Public ObjectGroupChecked() As Boolean
        Public ObjectGroupEnabled As Boolean
        Public Sub New(ByRef MapData As clsMapData)
            Me.ObjName = ""
            Me.Time = clsTime.GetNullYMD
            Me.TimeChangeEnabled = True
            Me.pointShapeChecked = True
            Me.lineShapeChecked = True
            Me.polygonShapeChecked = True
            Me.ShapeChangeEnabled = True
            ReDim Me.ObjectGroupChecked(MapData.Map.OBKNum - 1)
            clsGeneric.FillArray(Me.ObjectGroupChecked, True)
            Me.ObjectGroupEnabled = True
        End Sub
    End Class
    Private Structure condidateInfo
        Public ObjCode As Integer
        Public TimeStac As Integer
    End Structure
    Dim selectedObjectNumber As Integer
    Dim selectedObjectNumbers() As Integer
    Dim candidateObject As New List(Of condidateInfo)
    Dim MapData As clsMapData
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef mpData As clsMapData, ByVal initParapeter As init_parameter_data) As Windows.Forms.DialogResult

        Me.Tag = "off"
        MapData = mpData

        clbObjectKindEdit.BeginUpdate()
        clbObjectKindEdit.EventStop = True
        clbObjectKindEdit.Items.Clear()
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            clbObjectKindEdit.Items.Add(MapData.ObjectKind(i).Name, initParapeter.ObjectGroupChecked(i))
        Next
        clbObjectKindEdit.EndUpdate()
        clbObjectKindEdit.EventStop = False
        clbObjectKindEdit.Enabled = initParapeter.ObjectGroupEnabled

        lbList.SelectionMode = SelectionMode.MultiExtended

        cbPointShapeEdit.Checked = initParapeter.pointShapeChecked
        cbLineShapeEdit.Checked = initParapeter.lineShapeChecked
        cbPolygonShapeEdit.Checked = initParapeter.polygonShapeChecked
        gbObjShapeEdit.Enabled = initParapeter.ShapeChangeEnabled

        If MapData.Map.Time_Mode = True Then
            gbTime.Visible = True
            gbTime.Enabled = initParapeter.TimeChangeEnabled
            dbdtpTime.Value = initParapeter.Time
        Else
            gbTime.Visible = False
            dbdtpTime.Value = clsTime.GetNullYMD
        End If

        tbName.Text = initParapeter.ObjName
        Me.Tag = "on"
        Return Me.ShowDialog(Owner)
    End Function
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim SelF() As Boolean

        ReDim SelF(MapData.Map.Kend)
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
        Dim ChkShapeBoxSelected(2) As Boolean

        ChkShapeBoxSelected(enmShape.PointShape) = cbPointShapeEdit.Checked
        ChkShapeBoxSelected(enmShape.LineShape) = cbLineShapeEdit.Checked
        ChkShapeBoxSelected(enmShape.PolygonShape) = cbPolygonShapeEdit.Checked

        candidateObject = New List(Of condidateInfo)
        Dim Time As strYMD = dbdtpTime.Value
        For Smode As Integer = 0 To 1
            For i As Integer = 0 To MapData.Map.Kend - 1
                With MapData.MPObj(i)
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
                                                If objComp(k) Is Nothing = False Then
                                                    If (objComp(k).IndexOf(tx, StringComparison.OrdinalIgnoreCase)) <> -1 Then
                                                        okf = True
                                                    End If
                                                End If
                                            Next
                                    End Select
                                    If okf = True Then
                                        SelF(i) = True
                                        Dim obj As condidateInfo
                                        obj.ObjCode = i
                                        obj.TimeStac = j
                                        candidateObject.Add(obj)
                                    End If
                                End If
                            End With
                        Next
                    End If
                End With
            Next
        Next
        lbList.Items.Clear()
        lbList.BeginUpdate()
        Dim n As Integer = candidateObject.Count
        If n = 0 Then
            Dim msgText = "検索条件に当てはまるオブジェクトは見つかりませんでした。"
            MsgBox(msgText, MsgBoxStyle.Exclamation)
        Else
            Dim Values As New List(Of String)
            Dim NameSort As New clsSortingSearch

            For i As Integer = 0 To n - 1
                Dim oname As String = MapData.MPObj(candidateObject(i).ObjCode).NameTimeSTC(candidateObject(i).TimeStac).NamesList(0)
                Values.Add(oname)
            Next
            NameSort.AddRange(Values.Count, Values.ToArray)

            For i As Integer = 0 To n - 1
                Dim j As Integer = NameSort.DataPosition(i)
                With MapData.MPObj(candidateObject(i).ObjCode).NameTimeSTC(candidateObject(i).TimeStac)
                    lbList.Items.Add(.connectNames)
                End With
            Next
            lbList.Focus()
            If n = 1 Then
                lbList.SelectedIndex = 0
            End If
            lbList.AllSelect()
        End If
        lbList.EndUpdate()
    End Sub

    Private Sub cbPolygonShapeEdit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        cbPolygonShapeEdit.CheckedChanged, cbLineShapeEdit.CheckedChanged, cbPointShapeEdit.CheckedChanged,
        clbObjectKindEdit.SelectedIndexChanged, dbdtpTime.ValueChanged
        If Me.Tag = "on" And tbName.Text <> "" Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnObjName1_Click(sender As Object, e As EventArgs) Handles btnObjName1.Click
        If candidateObject.Count = 0 Then
            MsgBox("検索条件に当てはまるオブジェクトがありません。", MsgBoxStyle.Exclamation)
            Return
        End If
        If lbList.SelectedIndices.Count = 0 Then
            MsgBox("コピーするオブジェクト名を選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim maxOname As Integer = 0
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            If clbObjectKindEdit.GetItemChecked(i) = True Then
                With MapData.ObjectKind(i)
                    maxOname = Math.Max(maxOname, .ObjectNameList.Length)
                End With
            End If
        Next

        Dim copyObjname(maxOname - 1) As String
        For i As Integer = 0 To MapData.Map.OBKNum - 1
            If clbObjectKindEdit.GetItemChecked(i) = True Then
                With MapData.ObjectKind(i)
                    maxOname = Math.Max(maxOname, .ObjectNameList.Length)
                    For j As Integer = 0 To .ObjectNameList.Length - 1
                        If copyObjname(j) = "" Then
                            copyObjname(j) = .ObjectNameList(j)
                        Else
                            copyObjname(j) += "/" + .ObjectNameList(j)
                        End If
                    Next
                End With
            End If
        Next
        Dim sel As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("コピーするオブジェクト名リスト", copyObjname)

        If sel = -1 Then
            Return
        End If
        Dim sb As New System.Text.StringBuilder()
        Dim getn As Integer = 0
        For i As Integer = 0 To candidateObject.Count - 1
            If lbList.GetSelected(i) = True Then
                With MapData.MPObj(candidateObject(i).ObjCode).NameTimeSTC(candidateObject(i).TimeStac)
                    If sel < .NamesList.Length Then
                        sb.Append(.NamesList(sel))
                        sb.Append(vbCrLf)
                        getn += 1
                    End If
                End With
            End If
        Next
        Dim s3 As String = sb.ToString()
        Clipboard.SetText(s3)
        Dim mes As String
        If lbList.SelectedIndices.Count = getn Then
            mes = "オブジェクト名をクリップボードにコピーしました。"
        Else
            mes = lbList.SelectedIndices.Count.ToString + "のうち" + getn.ToString + "のオブジェクト名をクリップボードにコピーしました。"
        End If
        MsgBox(mes)
    End Sub


    Private Sub frmCopyObjectName_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.SubWindow, "frmCopyObjectName", Me)
        e.Cancel = True
    End Sub
End Class