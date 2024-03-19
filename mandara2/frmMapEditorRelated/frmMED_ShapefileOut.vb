Public Class frmMED_ShapefileOut
    Dim CloseCancelF As Boolean
    Dim MapData As clsMapData
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef mpData As clsMapData, ByVal Time As strYMD) As Windows.Forms.DialogResult

        MapData = mpData

        With cboObjectKind
            .Items.Clear()
            .Items.AddRange(MapData.Get_ObjectGroupNameList)
            .SelectedIndex = 0
        End With
        DateTimePicker.Visible = MapData.Map.Time_Mode
        If MapData.Map.Time_Mode = True Then
            If Time.nullFlag = True Then
                DateTimePicker.Value = DateTime.Today
            Else
                DateTimePicker.Value = clsTime.getDateTime(Time)
            End If
        End If
        Return Me.ShowDialog(Owner)
    End Function
    Public Sub getResult()

    End Sub

    Private Sub frmMED_ShapefileOut_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim Time As strYMD = clsTime.GetYMD(DateTimePicker.Value)
        Dim OBG As Integer = cboObjectKind.SelectedIndex

        If fileSelect.Path = "" Then
            MsgBox("出力シェープファイル名を指定してください。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If


        Dim Objs() As Integer
        Dim n As Integer = MapData.Get_Objects_by_Group(OBG, Objs, Time)
        If n = 0 Then
            MsgBox("該当するオブジェクトがありません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If

        Dim mxname As Integer = MapData.ObjectKind(OBG).ObjectNameNum

        Dim Data_Item_n As Integer = mxname + MapData.ObjectKind(OBG).DefTimeAttDataNum
        Dim Data_Title(Data_Item_n - 1) As String
        Dim Data_STR_F(Data_Item_n - 1) As Boolean
        Dim StrData(Data_Item_n - 1, n) As String

        For i As Integer = 0 To mxname - 1
            Data_Title(i) = MapData.ObjectKind(OBG).ObjectNameList(i)
            Data_STR_F(i) = True
        Next

        With MapData.ObjectKind(OBG)
            For i As Integer = 0 To .DefTimeAttDataNum - 1
                With .DefTimeAttSTC(i).attData
                    Data_Title(i + mxname) = .Title
                    If clsGeneric.check_Moji(Data_Title(i + mxname)) = True Then
                        Data_Title(i + mxname) = "Data" & CStr(i + 1)
                    Else
                        If Len(Data_Title(i + mxname)) > 10 Then
                            Data_Title(i + mxname) = Microsoft.VisualBasic.Left(Data_Title(i + mxname), 10)
                        End If
                    End If
                    If UCase(.Unit) = "STR" Or UCase(.Unit) = "CAT" Then
                        Data_STR_F(i + mxname) = True
                    End If
                End With
            Next
        End With

        For i As Integer = 0 To n - 1
            Dim oname() As String
            Dim Obj As clsMapData.strObj_Data = MapData.MPObj(Objs(i))
            MapData.Get_Enable_ObjectName(Obj, Time, True, oname)
            For j As Integer = 0 To mxname - 1
                StrData(j, i) = oname(j)
            Next
            For j As Integer = 0 To MapData.ObjectKind(OBG).DefTimeAttDataNum - 1
                MapData.Get_DefTimeAttrValue(Objs(i), j, Time, StrData(j + mxname, i))
            Next
        Next
        Dim ecode As clsEncodings = DirectCast(cboEncoding.SelectedItem, clsEncodings)
        Dim encodingnumber = ecode.eis.CodePage

        Cursor = Cursors.WaitCursor
        Dim f As Boolean = clsShapefile.ShapeFileOut(MapData, fileSelect.Path, n, Objs, Time, Data_Item_n, Data_Title, Data_STR_F, StrData, encodingnumber)
        Cursor = Cursors.Default
        If f = True Then
            MsgBox(fileSelect.Path & "に出力しました。")
        Else
            MsgBox(fileSelect.Path & "は保存できませんでした。")
        End If
    End Sub

    Private Sub frmMED_ShapefileOut_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_ShapefileOut", Me)
    End Sub

    Private Sub frmMED_ShapefileOut_Load(sender As Object, e As EventArgs) Handles Me.Load
        clsGeneric.SetEncodings_to_Cbobox(cboEncoding)
        cboEncoding.SelectedIndex = 0
    End Sub
End Class