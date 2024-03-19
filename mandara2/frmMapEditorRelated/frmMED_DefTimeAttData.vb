Public Class frmMED_DefTimeAttData
    Public Structure MpObjTimeDef_info
        Public DefTimeAttValue() As clsMapData.strDefTimeAttData_Info
    End Structure
    Public Structure ObjGroupTimeDef_info
        Public DefTimeAttDataNum As Integer
        Public DefTimeAttSTC() As clsMapData.strMPObjDefTimeAttData_Info
    End Structure

    Private Structure undo_AddDataItem
        Public Caption As String
        Public Group As Integer
        Public AddNum As Integer
    End Structure
    Private Structure undo_EditDataItem
        Public Caption As String
        Public Group As Integer
        Public EditData As Integer
        Public oldData As clsMapData.strMPObjDefTimeAttData_Info
    End Structure

    Private Structure undo_TimeChange
        Public Caption As String
        Public oldTime As strYMD
    End Structure

    Private Structure undo_DeleteDataItem
        Public Caption As String
        Public Group As Integer
        Public EditData As Integer
        Public oldData As clsMapData.strMPObjDefTimeAttData_Info
        Public ObjData() As clsMapData.strDefTimeAttData_Info
    End Structure
    Private Structure undo_SetDataValue
        Public Caption As String
        Public Group As Integer
        Public EditData As Integer
        Public ObjData() As clsMapData.strDefTimeAttData_Info
    End Structure
    Private Structure undo_ObjectData
        Public Caption As String
        Public EditData As Integer
        Public Group As Integer
        Public ObjCode As Integer
        Public ObjData As clsMapData.strDefTimeAttData_Info
    End Structure

    Dim UndoStac As New List(Of Object)

    Dim CloseCancelF As Boolean
    Dim MapData As clsMapData
    Dim defObj() As MpObjTimeDef_info
    Dim defGroup() As ObjGroupTimeDef_info
    Dim SelectedObjectGroup As Integer
    Dim SelectedObjCode() As Integer
    Dim SelectedObjNum As Integer
    Dim SelectTime As strYMD

    Dim searchObjName As String
    Private Sub frmMED_DefPointAttData_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef MData As clsMapData) As Windows.Forms.DialogResult
        SelectTime = clsTime.GetNullYMD
        MapData = MData
        With MapData
            ReDim defGroup(.Map.OBKNum - 1)
            For i As Integer = 0 To .Map.OBKNum - 1
                defGroup(i).DefTimeAttDataNum = .ObjectKind(i).DefTimeAttDataNum
                If .ObjectKind(i).DefTimeAttSTC Is Nothing = False Then
                    defGroup(i).DefTimeAttSTC = .ObjectKind(i).DefTimeAttSTC.Clone
                End If
            Next

            ReDim defObj(.Map.Kend - 1)
            For i As Integer = 0 To .Map.Kend - 1
                If .MPObj(i).DefTimeAttValue Is Nothing = False Then
                    defObj(i).DefTimeAttValue = clsGeneric.DefTimeAttValueClone(.MPObj(i).DefTimeAttValue)
                End If
            Next
            cboObjectKind.Items.Clear()
            cboObjectKind.Items.AddRange(.Get_ObjectGroupNameList)
        End With
        Me.Tag = "OFF"
        dbdtpEditTime.Value = SelectTime
        Me.Tag = ""
        cboObjectKind.SelectedIndex = 0
        UndoArray_Clear()
        Return Me.ShowDialog(Owner)
    End Function
    ''' <summary>
    ''' 結果を取得
    ''' </summary>
    ''' <param name="MapData"></param>
    ''' <remarks></remarks>
    Public Overloads Sub getResults(ByRef MapData As clsMapData)
        With MapData
            For i As Integer = 0 To .Map.OBKNum - 1
                With .ObjectKind(i)
                    .DefTimeAttDataNum = defGroup(i).DefTimeAttDataNum
                    If defGroup(i).DefTimeAttSTC Is Nothing = True Then
                        If .DefTimeAttSTC Is Nothing = False Then
                            Erase .DefTimeAttSTC
                        End If
                    Else
                        .DefTimeAttSTC = defGroup(i).DefTimeAttSTC.Clone
                    End If
                End With
            Next
            For i As Integer = 0 To .Map.Kend - 1
                With .MPObj(i)
                    If defObj(i).DefTimeAttValue Is Nothing = True Then
                        If .DefTimeAttValue Is Nothing = False Then
                            Erase .DefTimeAttValue
                        End If
                    Else
                        .DefTimeAttValue = clsGeneric.DefTimeAttValueClone(defObj(i).DefTimeAttValue.Clone)
                    End If
                End With
            Next
        End With
    End Sub
    ''' <summary>
    ''' オブジェクトグルーブボックスの変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboObjectKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboObjectKind.SelectedIndexChanged
        SelectedObjectGroup = cboObjectKind.SelectedIndex

        showKtgrid()
    End Sub
    ''' <summary>
    ''' グリッドに初期時点属性を追加する
    ''' </summary>
    ''' <param name="attn"></param>
    ''' <remarks></remarks>
    Private Sub addPointData(ByVal attn As Integer)

        Dim maxx As Integer = getPointDataNum(attn)
        With defGroup(SelectedObjectGroup).DefTimeAttSTC(attn).attData
            ktgrid.AddLayer(.Title, attn, maxx * 2 + 1, SelectedObjNum)
        End With
        setKtgridYSData(attn)
        For j As Integer = 0 To SelectedObjNum - 1
            ktgrid.FixedXSData(attn, 1, j) = MapData.MPObj(SelectedObjCode(j)).NameTimeSTC(0).connectNames
            setGridEachData(attn, j, defObj(SelectedObjCode(j)).DefTimeAttValue(attn).Data)
        Next

    End Sub
    ''' <summary>
    ''' セルに時間と値を設定する
    ''' </summary>
    ''' <param name="attn">初期時間属性データ番号</param>
    ''' <param name="GridY">オブジェクトの位置</param>
    ''' <param name="Data">初期時点属性データの値配列</param>
    ''' <remarks></remarks>
    Private Sub setGridEachData(ByVal attn As Integer, ByVal GridY As Integer, ByRef Data() As clsMapData.strDefTimeAttDataEach_Info)
        Dim n As Integer = 0
        ktgrid.DefaultGridWidth = 125
        If Data Is Nothing = False Then
            For k As Integer = 0 To Data.Length - 1
                Dim timetx As String = ""
                Select Case defGroup(SelectedObjectGroup).DefTimeAttSTC(attn).Type
                    Case clsMapData.enmDefTimeAttDataType.PointData
                        timetx = clsTime.YMDtoString(Data(k).Span.StartTime)
                    Case clsMapData.enmDefTimeAttDataType.SpanData
                        timetx = clsTime.StartEndtoString(Data(k).Span)
                        ktgrid.GridWidth(attn, k * 2) = 160
                End Select
                ktgrid.GridData(attn, k * 2, GridY) = timetx
                ktgrid.GridData(attn, k * 2 + 1, GridY) = Data(k).Value
                n += 2
            Next
        End If
        For i As Integer = n To ktgrid.Xsize(attn) - 1
            ktgrid.GridData(attn, i, GridY) = ""
        Next
    End Sub
    ''' <summary>
    ''' 新規初期時点属性
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuAddData_Click(sender As Object, e As EventArgs) Handles mnuAddData.Click
        Dim newDefPointAtt As clsMapData.strMPObjDefTimeAttData_Info
        Dim atitle(Math.Max(0, defGroup(SelectedObjectGroup).DefTimeAttDataNum - 1)) As String
        For i As Integer = 0 To defGroup(SelectedObjectGroup).DefTimeAttDataNum - 1
            atitle(i) = defGroup(SelectedObjectGroup).DefTimeAttSTC(i).attData.Title
        Next
        With newDefPointAtt
            .Type = clsMapData.enmDefTimeAttDataType.PointData
            .ExtraValue = clsMapData.enmDefPointAttDataExtraValue.interpolation_NearestValue
            .attData.Title = clsGeneric.Get_New_Numbering_Strings("新しい初期時間属性データ", atitle)
            .attData.Unit = ""
            .attData.MissingF = False
            .attData.Note = ""
        End With
        Dim form As New frmMED_DefTimeAttDataItem
        If form.ShowDialog(Me, newDefPointAtt) = Windows.Forms.DialogResult.OK Then
            Dim UndoData As undo_AddDataItem
            UndoData.Caption = "データ項目追加"
            UndoData.Group = SelectedObjectGroup
            UndoData.AddNum = 1
            UndoStac.Add(UndoData)
            SetUndoMenu()

            newDefPointAtt = form.getResults
            Dim n As Integer = defGroup(SelectedObjectGroup).DefTimeAttDataNum
            addDefData(SelectedObjectGroup, newDefPointAtt)
            addPointData(n)
            ktgrid.Show()
            ktgrid.Visible = True
            ktgrid.Layer = n
            ktgrid.Refresh()
        End If
        form.Dispose()

    End Sub
    ''' <summary>
    ''' 指定したオブジェクトグループにデータ項目を追加
    ''' </summary>
    ''' <param name="ObjG"></param>
    ''' <param name="newDefPointAtt"></param>
    ''' <remarks></remarks>
    Private Sub addDefData(ByVal ObjG As Integer, ByVal newDefPointAtt As clsMapData.strMPObjDefTimeAttData_Info)

        Dim n As Integer = defGroup(ObjG).DefTimeAttDataNum + 1

        With defGroup(ObjG)
            .DefTimeAttDataNum = n
            ReDim Preserve .DefTimeAttSTC(n - 1)
            .DefTimeAttSTC(n - 1) = newDefPointAtt
        End With
        Dim ObjCode() As Integer
        Dim ObjN As Integer = MapData.Get_Objects_by_Group(ObjG, ObjCode)
        For j As Integer = 0 To ObjN - 1
            ReDim Preserve defObj(ObjCode(j)).DefTimeAttValue(n - 1)
        Next
    End Sub
    ''' <summary>
    ''' 初期属性データ項目修正
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuEditData_Click(sender As Object, e As EventArgs) Handles mnuEditData.Click
        If defGroup(SelectedObjectGroup).DefTimeAttDataNum = 0 Then
            MsgBox("指定のオブジェクトグループには初期時間属性データ項目がありません。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim form As New frmMED_DefTimeAttDataItem
        Dim attn As Integer = ktgrid.Layer
        If form.ShowDialog(Me, defGroup(SelectedObjectGroup).DefTimeAttSTC(attn)) = Windows.Forms.DialogResult.OK Then
            Dim UndoData As undo_EditDataItem
            With UndoData
                .Caption = "データ項目修正"
                .EditData = attn
                .Group = SelectedObjectGroup
                .oldData = defGroup(SelectedObjectGroup).DefTimeAttSTC(attn)
            End With
            UndoStac.Add(UndoData)
            SetUndoMenu()

            defGroup(SelectedObjectGroup).DefTimeAttSTC(attn) = form.getResults
            setKtgridYSData(attn)
            For j As Integer = 0 To SelectedObjNum - 1
                setGridEachData(attn, j, defObj(SelectedObjCode(j)).DefTimeAttValue(attn).Data)
            Next
            ktgrid.Refresh()
        End If
        form.Dispose()
    End Sub
    Private Sub setKtgridYSData(ByVal attn As Integer)
        Dim dtype As enmAttDataType
        Dim TimeTx As String = ""
        With defGroup(SelectedObjectGroup).DefTimeAttSTC(attn)
            Select Case .Type
                Case clsMapData.enmDefTimeAttDataType.PointData
                    TimeTx = "時期"
                Case clsMapData.enmDefTimeAttDataType.SpanData
                    TimeTx = "期間"
            End Select
            dtype = clsGeneric.getAttDataType_From_TitleUnit(.attData.Title, .attData.Unit)
        End With
        For i As Integer = 0 To ktgrid.Xsize(attn) - 2 Step 2
            ktgrid.FixedYSData(attn, i, 0) = TimeTx
            ktgrid.FixedYSData(attn, i + 1, 0) = "値"
            ktgrid.GridAlligntment(attn, i) = HorizontalAlignment.Left
            Select Case dtype
                Case enmAttDataType.Normal
                    ktgrid.GridAlligntment(attn, i + 1) = HorizontalAlignment.Right
                Case Else
                    ktgrid.GridAlligntment(attn, i + 1) = HorizontalAlignment.Left
            End Select
        Next
        ktgrid.FixedYSData(attn, ktgrid.Xsize(attn) - 1, 0) = ""
    End Sub
    ''' <summary>
    ''' セルをクリックして入力画面に
    ''' </summary>
    ''' <param name="Layer"></param>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="Value"></param>
    ''' <param name="Top"></param>
    ''' <param name="Left"></param>
    ''' <param name="Width"></param>
    ''' <param name="Height"></param>
    ''' <remarks></remarks>
    Private Sub ktgrid_Click_DataGrid(Layer As Integer, X As Integer, Y As Integer, Value As String, Top As Single, Left As Single, Width As Single, Height As Single) Handles ktgrid.Click_DataGrid

        Dim form As New frmMED_DefTimeAttDataObjectEdit
        If form.ShowDialog(Me, MapData, MapData.MPObj(SelectedObjCode(Y)), defGroup(SelectedObjectGroup).DefTimeAttSTC(Layer), defObj(SelectedObjCode(Y)).DefTimeAttValue(Layer).Data) = Windows.Forms.DialogResult.OK Then
            Dim undodata As undo_ObjectData
            With undodata
                .Caption = "オブジェクトの属性"
                .Group = SelectedObjectGroup
                .ObjCode = SelectedObjCode(Y)
                .EditData = Layer
                If defObj(SelectedObjCode(Y)).DefTimeAttValue(Layer).Data Is Nothing = False Then
                    .ObjData.Data = defObj(SelectedObjCode(Y)).DefTimeAttValue(Layer).Data.Clone
                End If
            End With
            UndoStac.Add(undodata)
            SetUndoMenu()

            defObj(SelectedObjCode(Y)).DefTimeAttValue(Layer).Data = form.getResult
            Dim maxx As Integer = getPointDataNum(Layer)
            ktgrid.Xsize(Layer) = maxx * 2 + 1
            setKtgridYSData(Layer)
            setGridEachData(Layer, Y, defObj(SelectedObjCode(Y)).DefTimeAttValue(Layer).Data)
            ktgrid.Refresh()
        End If
        form.Dispose()

    End Sub
    ''' <summary>
    ''' データ値一括設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuSettingValue_Click(sender As Object, e As EventArgs) Handles mnuSettingValue.Click
        Dim odefn As Integer = defGroup(SelectedObjectGroup).DefTimeAttDataNum
        If odefn = 0 Then
            MsgBox("初期時間属性データがありません。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim Layer As Integer = ktgrid.Layer
        Dim time As strYMD = dbdtpEditTime.Value
        Dim form As New frmMED_DefTimeAttData_ValueSet
        If form.ShowDialog(Me, MapData, SelectedObjectGroup, Layer, defGroup(SelectedObjectGroup).DefTimeAttSTC(Layer), time) = Windows.Forms.DialogResult.OK Then
            Dim undodata As undo_SetDataValue
            With undodata
                .Caption = "データ値一括設定"
                .EditData = Layer
                .Group = SelectedObjectGroup
                Dim ObjCode() As Integer
                Dim ObjN As Integer = MapData.Get_Objects_by_Group(SelectedObjectGroup, ObjCode)
                ReDim .ObjData(ObjN - 1)
                For i As Integer = 0 To ObjN - 1
                    If defObj(ObjCode(i)).DefTimeAttValue(Layer).Data Is Nothing = False Then
                        .ObjData(i).Data = defObj(ObjCode(i)).DefTimeAttValue(Layer).Data.Clone
                    End If
                Next
            End With
            UndoStac.Add(undodata)
            SetUndoMenu()

            form.getResults(defObj)
            Dim maxx As Integer = getPointDataNum(Layer)
            ktgrid.Xsize(Layer) = maxx * 2 + 1
            setKtgridYSData(Layer)
            For j As Integer = 0 To SelectedObjNum - 1
                setGridEachData(Layer, j, defObj(SelectedObjCode(j)).DefTimeAttValue(Layer).Data)
            Next
            ktgrid.Refresh()
            clsGeneric.MessageBox(FormStartPosition.CenterParent, "データ値を一括設定しました。", MessageBoxButtons.OK, MessageBoxIcon.None)
        End If

    End Sub
    ''' <summary>
    ''' 現在のオブジェクトグループで、指定したデータの設定時間数の最大値を求める
    ''' </summary>
    ''' <param name="attrDatan"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getPointDataNum(ByVal attrDatan As Integer) As Integer
        Dim mx As Integer = 0
        For i As Integer = 0 To SelectedObjNum - 1
            With defObj(SelectedObjCode(i)).DefTimeAttValue(attrDatan)
                If .Data Is Nothing = False Then
                    mx = Math.Max(mx, .Data.Length)
                End If
            End With
        Next
        Return mx
    End Function

    ''' <summary>
    ''' 時期限定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dbdtpEditTime_ValueChanged(sender As Object, e As EventArgs) Handles dbdtpEditTime.ValueChanged
        If Me.Tag = "" Then
            Dim undodata As undo_TimeChange
            undodata.Caption = "時間限定"
            undodata.oldTime = SelectTime
            UndoStac.Add(undodata)
            SetUndoMenu()

            SelectTime = dbdtpEditTime.Value
            showKtgrid()
        End If
    End Sub
    Private Sub showKtgrid()
        SelectedObjNum = MapData.Get_Objects_by_Group(SelectedObjectGroup, SelectedObjCode, SelectTime)
        ktgrid.init("初期時間属性", "オブジェクト", "時間属性", 2, 1, 1, 0, False, True, False, False, False, False, False, False, True, False)
        If defGroup(SelectedObjectGroup).DefTimeAttDataNum = 0 Then
            ktgrid.Visible = False
        Else
            ktgrid.Visible = True
            For i As Integer = 0 To defGroup(SelectedObjectGroup).DefTimeAttDataNum - 1
                addPointData(i)
            Next
            ktgrid.Layer = 0
            ktgrid.Show()
        End If

    End Sub
    ''' <summary>
    ''' データ項目削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuDeleteData_Click(sender As Object, e As EventArgs) Handles mnuDeleteData.Click
        Dim defn As Integer = defGroup(SelectedObjectGroup).DefTimeAttDataNum
        If defn = 0 Then
            MsgBox("選択したオブジェクトグループには初期時間属性データがありません。", MsgBoxStyle.Exclamation)
            Return
        End If
        If MsgBox(ktgrid.LayerName(ktgrid.Layer) & "を削除します。", vbYesNoCancel) = MsgBoxResult.Yes Then
            Dim ObjCode() As Integer
            Dim ObjN As Integer = MapData.Get_Objects_by_Group(SelectedObjectGroup, ObjCode)
            Dim attn As Integer = ktgrid.Layer
            Dim undodata As undo_DeleteDataItem
            With undodata
                .Caption = "データ項目削除"
                .EditData = attn
                .Group = SelectedObjectGroup
                .oldData = defGroup(SelectedObjectGroup).DefTimeAttSTC(attn)
                ReDim .ObjData(ObjN - 1)
                For i As Integer = 0 To ObjN - 1
                    If defObj(ObjCode(i)).DefTimeAttValue(attn).Data Is Nothing = False Then
                        .ObjData(i).Data = defObj(ObjCode(i)).DefTimeAttValue(attn).Data.Clone
                    End If
                Next
            End With
            UndoStac.Add(undodata)
            SetUndoMenu()

            defGroup(SelectedObjectGroup).DefTimeAttDataNum -= 1
            For i As Integer = 0 To ObjN - 1
                Dim n As Integer = ObjCode(i)
                If defn = 1 Then
                    Erase defObj(n).DefTimeAttValue
                Else
                    For j As Integer = attn To defn - 2
                        If defObj(n).DefTimeAttValue(j + 1).Data Is Nothing = True Then
                            If defObj(n).DefTimeAttValue(j).Data Is Nothing = False Then
                                Erase defObj(n).DefTimeAttValue(j).Data
                            End If
                        Else
                            defObj(n).DefTimeAttValue(j).Data = defObj(ObjCode(i)).DefTimeAttValue(j + 1).Data.Clone
                        End If
                    Next
                End If
            Next
            If defn > 1 Then
                For i As Integer = attn To defn - 2
                    With defGroup(SelectedObjectGroup).DefTimeAttSTC(i)
                        .Type = defGroup(SelectedObjectGroup).DefTimeAttSTC(i + 1).Type
                        .attData = defGroup(SelectedObjectGroup).DefTimeAttSTC(i + 1).attData
                        .ExtraValue = defGroup(SelectedObjectGroup).DefTimeAttSTC(i + 1).ExtraValue
                    End With
                Next
                ktgrid.RemoveLayer(attn)
                attn = ktgrid.Layer
            Else
                showKtgrid()
            End If
        End If
    End Sub

    Private Sub mnuDeleteValue_Click(sender As Object, e As EventArgs) Handles mnuDeleteValue.Click
        If MsgBox(ktgrid.LayerName(ktgrid.Layer) + "のデータ値を削除します。", vbYesNoCancel) = MsgBoxResult.Yes Then
            Dim ObjCode() As Integer
            Dim ObjN As Integer = MapData.Get_Objects_by_Group(SelectedObjectGroup, ObjCode)
            Dim attn As Integer = ktgrid.Layer

            Dim undodata As undo_SetDataValue
            With undodata
                .Caption = "データ値削除"
                .EditData = attn
                .Group = SelectedObjectGroup
                ReDim .ObjData(ObjN - 1)
                For i As Integer = 0 To ObjN - 1
                    If defObj(ObjCode(i)).DefTimeAttValue(attn).Data Is Nothing = False Then
                        .ObjData(i).Data = defObj(ObjCode(i)).DefTimeAttValue(attn).Data.Clone
                    End If
                Next
            End With
            UndoStac.Add(undodata)
            SetUndoMenu()

            For i As Integer = 0 To ObjN - 1
                Dim n As Integer = ObjCode(i)
                Erase defObj(n).DefTimeAttValue(attn).Data
            Next
            ktgrid.Xsize(attn) = 1
            setKtgridYSData(attn)
            For j As Integer = 0 To SelectedObjNum - 1
                setGridEachData(attn, j, defObj(SelectedObjCode(j)).DefTimeAttValue(attn).Data)
            Next

            ktgrid.Refresh()
        End If
    End Sub

    Private Sub txtObjNameSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObjNameSearch.KeyDown
        If e.KeyData = Keys.Enter And txtObjNameSearch.Text <> "" Then
            searchObjName = txtObjNameSearch.Text
            searchName(enmDirection.Forward)
        End If
    End Sub
    ''' <summary>
    ''' テキストボックスでEnter押されたときにBeepが鳴らないようにする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtObjNameSearchKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtObjNameSearch.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            e.Handled = True
        End If
    End Sub

    Private Sub searchName(ByVal dir As enmDirection)
        Dim stx As String = "*" + searchObjName + "*"
        Dim p As Integer = ktgrid.TopCell
        Dim startP As Integer = p
        Dim n As Integer = 0
        Dim f As Boolean = False
        Do
            Select Case dir
                Case enmDirection.Forward
                    p += 1
                    If p = SelectedObjNum Then
                        p = 0
                    End If
                Case enmDirection.Reverse
                    p -= 1
                    If p = -1 Then
                        p = SelectedObjNum - 1
                    End If
            End Select
            Dim code As Integer = SelectedObjCode(p)
            For i As Integer = 0 To MapData.MPObj(code).NumOfNameTime - 1
                With MapData.MPObj(code).NameTimeSTC(i)
                    For j As Integer = 0 To .NamesList.Length - 1
                        If .NamesList(j) Like stx Then
                            f = True
                            Exit Do
                        End If
                    Next
                End With
            Next
        Loop While p <> startP
        If f = True Then
            ktgrid.TopCell(p)
            ktgrid.Refresh()

        End If
    End Sub

    Private Sub btnBefore_Click(sender As Object, e As EventArgs) Handles btnBefore.Click
        If txtObjNameSearch.Text <> "" Then
            searchObjName = txtObjNameSearch.Text
            searchName(enmDirection.Reverse)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If txtObjNameSearch.Text <> "" Then
            searchObjName = txtObjNameSearch.Text
            searchName(enmDirection.Forward)
        End If
    End Sub

    Private Sub mnuCopySelectedData_Click(sender As Object, e As EventArgs) Handles mnuCopySelectedData.Click
        Dim obg As String() = MapData.Get_ObjectGroupNameList
        Dim n As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("コピー先選択", obg)
        If n <> -1 Then
            Dim UndoData As undo_AddDataItem
            UndoData.Caption = "データ項目コピー"
            UndoData.Group = n
            UndoData.AddNum = 1
            UndoStac.Add(UndoData)
            SetUndoMenu()

            addDefData(n, defGroup(SelectedObjectGroup).DefTimeAttSTC(ktgrid.Layer))
            MsgBox(defGroup(SelectedObjectGroup).DefTimeAttSTC(ktgrid.Layer).attData.Title + "を" + obg(n) & "にコピーしました。")
            If n = SelectedObjectGroup Then
                addPointData(ktgrid.LayerMax - 1)
                ktgrid.Show()
            End If
            cboObjectKind.SelectedIndex = n
        End If

    End Sub

    Private Sub mnuCopyAllData_Click(sender As Object, e As EventArgs) Handles mnuCopyAllData.Click
        Dim obg As String() = MapData.Get_ObjectGroupNameList
        obg(SelectedObjectGroup) = "*" + obg(SelectedObjectGroup)
        Dim n As Integer = clsGeneric.Show_ComboboxForm_and_GetResult("コピー先選択", obg)
        If n <> -1 Then
            Dim inn As Integer = defGroup(n).DefTimeAttDataNum
            Dim UndoData As undo_AddDataItem
            UndoData.Caption = "全データ項目コピー"
            UndoData.Group = n
            UndoData.AddNum = inn
            UndoStac.Add(UndoData)
            SetUndoMenu()

            For i As Integer = 0 To defGroup(SelectedObjectGroup).DefTimeAttDataNum - 1

                addDefData(n, defGroup(SelectedObjectGroup).DefTimeAttSTC(i))
            Next
            MsgBox("全データ項目を" + obg(n) & "にコピーしました。")
            cboObjectKind.SelectedIndex = n
        End If

    End Sub

    Private Sub mnuUndo_Click(sender As Object, e As EventArgs) Handles mnuUndo.Click
        Undo()
    End Sub

    Public Function Undo() As Boolean
        Dim undon As Integer = UndoStac.Count - 1
        Dim ScrData_initF As Boolean = False
        If undon = -1 Then
            Return ScrData_initF
        End If
        Dim UndoObj = UndoStac.Item(undon)
        Select Case True
            Case TypeOf UndoObj Is undo_AddDataItem
                'データ追加のアンドゥ
                Dim UndoData As undo_AddDataItem = CType(UndoObj, undo_AddDataItem)
                Dim ObjG As Integer = UndoData.Group
                Dim datan As Integer = defGroup(ObjG).DefTimeAttDataNum
                Dim ObjCode() As Integer
                Dim ObjN As Integer = MapData.Get_Objects_by_Group(ObjG, ObjCode)
                If datan - UndoData.AddNum = 0 Then
                    Erase defGroup(ObjG).DefTimeAttSTC
                    For j As Integer = 0 To ObjN - 1
                        Erase defObj(ObjCode(j)).DefTimeAttValue
                    Next
                Else
                    ReDim Preserve defGroup(ObjG).DefTimeAttSTC(datan - UndoData.AddNum - 1)
                    For j As Integer = 0 To ObjN - 1
                        ReDim Preserve defObj(ObjCode(j)).DefTimeAttValue(datan - UndoData.AddNum - 1)
                    Next
                End If

                defGroup(ObjG).DefTimeAttDataNum = datan - UndoData.AddNum
                If ObjG = SelectedObjectGroup Then
                    If datan - UndoData.AddNum = 0 Then
                        ktgrid.Visible = False
                    Else
                        For i As Integer = 0 To UndoData.AddNum - 1
                            ktgrid.RemoveLayer(datan - i - 1)
                        Next
                        ktgrid.Refresh()
                    End If
                End If
            Case TypeOf UndoObj Is undo_EditDataItem
                'データの修正アンドゥ
                Dim UndoData As undo_EditDataItem = CType(UndoObj, undo_EditDataItem)
                With UndoData
                    defGroup(.Group).DefTimeAttSTC(.EditData) = .oldData
                    If .Group = SelectedObjectGroup And .EditData = ktgrid.Layer Then
                        setKtgridYSData(.EditData)
                        For j As Integer = 0 To SelectedObjNum - 1
                            setGridEachData(.EditData, j, defObj(SelectedObjCode(j)).DefTimeAttValue(.EditData).Data)
                        Next
                        ktgrid.Refresh()
                    End If
                End With
            Case TypeOf UndoObj Is undo_TimeChange
                '時間限定
                Dim UndoData As undo_TimeChange = CType(UndoObj, undo_TimeChange)
                Me.Tag = "OFF"
                dbdtpEditTime.Value = UndoData.oldTime
                SelectTime = UndoData.oldTime
                showKtgrid()
                Me.Tag = ""
            Case TypeOf UndoObj Is undo_DeleteDataItem
                'データ削除
                Dim UndoData As undo_DeleteDataItem = CType(UndoObj, undo_DeleteDataItem)
                With UndoData
                    Dim defn As Integer = defGroup(.Group).DefTimeAttDataNum
                    ReDim Preserve defGroup(.Group).DefTimeAttSTC(defn)
                    defGroup(.Group).DefTimeAttDataNum += 1
                    For i As Integer = defn To .EditData + 1 Step -1
                        defGroup(.Group).DefTimeAttSTC(i) = defGroup(.Group).DefTimeAttSTC(i - 1)
                    Next
                    defGroup(.Group).DefTimeAttSTC(.EditData) = .oldData
                    Dim ObjCode() As Integer
                    Dim ObjN As Integer = MapData.Get_Objects_by_Group((.Group), ObjCode)
                    For i As Integer = 0 To ObjN - 1
                        ReDim Preserve defObj(ObjCode(i)).DefTimeAttValue(defn)
                        For j As Integer = defn To .EditData + 1 Step -1
                            If defObj(ObjCode(i)).DefTimeAttValue(j - 1).Data Is Nothing Then
                                If defObj(ObjCode(i)).DefTimeAttValue(j).Data Is Nothing = False Then
                                    Erase defObj(ObjCode(i)).DefTimeAttValue(j).Data
                                End If
                            Else
                                defObj(ObjCode(i)).DefTimeAttValue(j).Data = defObj(ObjCode(i)).DefTimeAttValue(j - 1).Data.Clone
                            End If
                        Next
                        If .ObjData(i).Data Is Nothing = False Then
                            defObj(ObjCode(i)).DefTimeAttValue(.EditData).Data = .ObjData(i).Data.Clone
                        End If
                    Next
                    If .Group = SelectedObjectGroup Then
                        showKtgrid()
                    End If
                End With
            Case TypeOf UndoObj Is undo_SetDataValue
                'データ値一括設定/データ値削除
                Dim UndoData As undo_SetDataValue = CType(UndoObj, undo_SetDataValue)
                With UndoData
                    Dim ObjCode() As Integer
                    Dim ObjN As Integer = MapData.Get_Objects_by_Group((.Group), ObjCode)
                    For i As Integer = 0 To ObjN - 1
                        If .ObjData(i).Data Is Nothing = False Then
                            defObj(ObjCode(i)).DefTimeAttValue(.EditData).Data = .ObjData(i).Data.Clone
                        Else
                            defObj(ObjCode(i)).DefTimeAttValue(.EditData).Data = Nothing
                        End If
                    Next
                    If .Group = SelectedObjectGroup Then
                        Dim maxx As Integer = getPointDataNum(.EditData)
                        ktgrid.Xsize(.EditData) = maxx * 2 + 1
                        setKtgridYSData(.EditData)
                        For j As Integer = 0 To SelectedObjNum - 1
                            setGridEachData(.EditData, j, defObj(SelectedObjCode(j)).DefTimeAttValue(.EditData).Data)
                        Next
                        ktgrid.Refresh()
                    End If

                End With
            Case TypeOf UndoObj Is undo_ObjectData
                'オブジェクトの属性
                Dim UndoData As undo_ObjectData = CType(UndoObj, undo_ObjectData)
                With UndoData
                    If .ObjData.Data Is Nothing = True Then
                        If defObj(.ObjCode).DefTimeAttValue(.EditData).Data Is Nothing = False Then
                            Erase defObj(.ObjCode).DefTimeAttValue(.EditData).Data
                        End If
                    Else
                        defObj(.ObjCode).DefTimeAttValue(.EditData).Data = .ObjData.Data.Clone
                    End If
                    Dim maxx As Integer = getPointDataNum(.EditData)
                    ktgrid.Xsize(.EditData) = maxx * 2 + 1
                    setKtgridYSData(.EditData)
                    For j As Integer = 0 To SelectedObjNum - 1
                        setGridEachData(.EditData, j, defObj(SelectedObjCode(j)).DefTimeAttValue(.EditData).Data)
                    Next
                    ktgrid.Refresh()
                End With
        End Select
        UndoStac.RemoveAt(undon)
        If undon > 10 Then
            UndoStac.RemoveAt(0)
        End If
        SetUndoMenu()
    End Function
    Private Sub SetUndoMenu()
        Dim n As Integer = UndoStac.Count
        If n = 0 Then
            mnuUndo.Enabled = False
            mnuUndo.Text = "元に戻す(&U)"
        Else
            mnuUndo.Text = "元に戻す(&U)（" & UndoStac.Item(n - 1).caption & "）"
            mnuUndo.Enabled = True
        End If

    End Sub
    Private Sub UndoArray_Clear()
        UndoStac.Clear()
        UndoStac.TrimExcess()
        SetUndoMenu()
    End Sub



    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_DefTimeAttData", Me)
    End Sub


    Private Sub mnuData_Click(sender As Object, e As EventArgs) Handles mnuData.Click

    End Sub
End Class