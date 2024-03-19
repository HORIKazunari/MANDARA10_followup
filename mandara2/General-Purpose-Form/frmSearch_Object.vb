Public Class frmSearch_Object
    Public Class init_parameter_data
        Public MultiSelect As Boolean
        Public ObjName As String
        Public Time As strYMD
        Public TimeChangeEnabled As Boolean
        Public ObjectType As clsMapData.enmObjectGoupType_Data
        Public ObjectTypeChangeEnabled As Boolean
        Public pointShapeChecked As Boolean
        Public lineShapeChecked As Boolean
        Public polygonShapeChecked As Boolean
        Public ShapeChangeEnabled As Boolean
        Public ObjectGroupChecked() As Boolean
        Public ObjectGroupEnabled As Boolean
        Public Sub New(ByRef MapData As clsMapData)
            Me.MultiSelect = False
            Me.ObjName = ""
            Me.Time = clsTime.GetNullYMD
            Me.TimeChangeEnabled = True
            Me.ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject
            Me.ObjectTypeChangeEnabled = True
            Me.pointShapeChecked = True
            Me.lineShapeChecked = True
            Me.polygonShapeChecked = True
            Me.ShapeChangeEnabled = True
            ReDim Me.ObjectGroupChecked(MapData.Map.OBKNum - 1)
            clsGeneric.FillArray(Me.ObjectGroupChecked, True)
            Me.ObjectGroupEnabled = True
        End Sub
    End Class
    Dim selectedObjectNumber As Integer
    Dim selectedObjectNumbers() As Integer
    Dim condidateObject As New ArrayList
    Dim MapData As clsMapData
    Dim CloseCancelF As Boolean
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

        If initParapeter.MultiSelect = True Then
            lbList.SelectionMode = SelectionMode.MultiExtended
        Else
            lbList.SelectionMode = SelectionMode.One
        End If

        If initParapeter.ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
            rbObjTypeEditNormal.Checked = True
        Else
            rbObjTypeEditAggregation.Checked = True
        End If
        gbObjTypeEdit.Enabled = initParapeter.ObjectTypeChangeEnabled

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
    Public Function getSelectedObjectNumber() As Integer
        Return selectedObjectNumber
    End Function
    Public Function getSelectedObjectNumbers() As Integer()
        Return selectedObjectNumbers
    End Function


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click


        Dim OType As clsMapData.enmObjectGoupType_Data

        Dim SelF() As Boolean

        condidateObject.Clear()
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

        If rbObjTypeEditNormal.Checked = True Then
            OType = clsMapData.enmObjectGoupType_Data.NormalObject
        Else
            OType = clsMapData.enmObjectGoupType_Data.AggregationObject
        End If

        Dim Time As strYMD = dbdtpTime.Value
        lbList.Items.Clear()

        For Smode As Integer = 0 To 1
            For i As Integer = 0 To MapData.Map.Kend - 1
                With MapData.MPObj(i)
                    If SelF(i) = False And clbObjectKindEdit.GetItemChecked(.Kind) = True And ChkShapeBoxSelected(.Shape) = True And _
                            MapData.ObjectKind(.Kind).ObjectType = OType Then
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
                                        condidateObject.Add(i)
                                        lbList.Items.Add(.connectNames)
                                    End If
                                End If
                            End With
                        Next
                    End If
                End With
            Next
        Next

        Select Case condidateObject.Count
            Case 0
                Dim msgText = "検索条件に当てはまるオブジェクトは見つかりませんでした。"
                MsgBox(msgText, MsgBoxStyle.Exclamation)
            Case 1
                lbList.SelectedIndex = 0
                btnOK.Focus()
            Case Else
                lbList.Focus()
        End Select
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click


        Dim n As Integer = lbList.SelectedIndices.Count
        If n = 0 Then
            CloseCancelF = True
            Exit Sub
        Else
            Dim selObj(n - 1) As Integer
            For i As Integer = 0 To n - 1
                selObj(i) = condidateObject(lbList.SelectedIndices(i))
            Next
            If lbList.SelectionMode = SelectionMode.One Then
                selectedObjectNumber = selObj(0)
            Else
                selectedObjectNumbers = selObj
            End If
        End If
    End Sub

    Private Sub frmSearch_Object_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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



    Private Sub lbList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbList.DoubleClick
        btnOK.PerformClick()
    End Sub

 

    Private Sub cbPolygonShapeEdit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
            cbPolygonShapeEdit.CheckedChanged, cbLineShapeEdit.CheckedChanged, cbPointShapeEdit.CheckedChanged, clbObjectKindEdit.SelectedIndexChanged, rbObjTypeEditAggregation.CheckedChanged, rbObjTypeEditNormal.CheckedChanged
        If Me.Tag = "on" And tbName.Text <> "" Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub frmSearch_Object_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmSearch_Object", Me)
        e.Cancel = True
    End Sub
End Class