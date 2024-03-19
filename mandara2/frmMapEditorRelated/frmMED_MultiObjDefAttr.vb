Public Class frmMED_MultiObjDefAttr
    Public Structure MpObjTimeDef_info
        Public DefTimeAttValue() As clsMapData.strDefTimeAttData_Info
    End Structure
    Public Structure ObjGroupTimeDef_info
        Public DefTimeAttDataNum As Integer
        Public DefTimeAttSTC() As clsMapData.strMPObjDefTimeAttData_Info
    End Structure

    Dim Sel_Obk As Integer
    Dim SelObjectCode() As Integer
    Dim SelObjNum As Integer
    Dim MapData As clsMapData

    Dim defObj() As MpObjTimeDef_info
    Dim defGroup As ObjGroupTimeDef_info

    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef EditingMultiObject As List(Of Integer), ByRef MData As clsMapData) As Windows.Forms.DialogResult
        Sel_Obk = MData.MPObj(EditingMultiObject.Item(0)).Kind
        SelObjectCode = EditingMultiObject.ToArray
        MapData = MData
        SelObjNum = EditingMultiObject.Count

        If MapData.Map.Time_Mode = False Then
            KtGrid.init("オブジェクトグループ", "オブジェクト", "初期属性データ", 2, 1, 5, 3, True, True, True, False, False, False, False, False, False, False)
            With MapData.ObjectKind(Sel_Obk)
                KtGrid.AddLayer("Data", 0, .DefTimeAttDataNum, SelObjNum)
                For i As Integer = 0 To .DefTimeAttDataNum - 1
                    With .DefTimeAttSTC(i).attData
                        KtGrid.FixedYSData(0, i, 2) = clsGeneric.ConvertMissingValueBoolString(.MissingF)
                        KtGrid.FixedYSData(0, i, 3) = .Title
                        KtGrid.FixedYSData(0, i, 4) = .Unit
                    End With
                Next
                clsGeneric.Check_DataKind_and_Allignment(KtGrid, 0, clsAttrData.enmLayerType.Normal)
            End With
            For i As Integer = 0 To SelObjNum - 1
                With MapData.MPObj(EditingMultiObject.Item(i))
                    KtGrid.FixedXSData(0, 1, i) = .NameTimeSTC(0).connectNames
                    For j As Integer = 0 To MapData.ObjectKind(.Kind).DefTimeAttDataNum - 1
                        KtGrid.GridData(0, j, i) = .DefTimeAttValue(j).Data(0).Value
                    Next
                End With
            Next
        Else
            With MapData
                defGroup.DefTimeAttDataNum = .ObjectKind(Sel_Obk).DefTimeAttDataNum
                If .ObjectKind(Sel_Obk).DefTimeAttSTC Is Nothing = False Then
                    defGroup.DefTimeAttSTC = .ObjectKind(Sel_Obk).DefTimeAttSTC.Clone
                End If

                ReDim defObj(SelObjNum - 1)
                For i As Integer = 0 To SelObjNum - 1
                    If .MPObj(SelObjectCode(i)).DefTimeAttValue Is Nothing = False Then
                        defObj(i).DefTimeAttValue = clsGeneric.DefTimeAttValueClone(.MPObj(SelObjectCode(i)).DefTimeAttValue)
                    End If
                Next
            End With
            setTimeData()
        End If
        KtGrid.Show()
        Return Me.ShowDialog(Owner)
    End Function

    ''' <summary>
    ''' 非時間データはグリッドの文字を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getResult() As String(,)
        Return KtGrid.GridData(0)
    End Function

    ''' <summary>
    ''' 時間データの場合はMAPDATAに値を設定する
    ''' </summary>
    ''' <param name="_MapData"></param>
    ''' <remarks></remarks>
    Public Sub getResult(ByRef _MapData As clsMapData)
        With _MapData
            For i As Integer = 0 To SelObjNum - 1
                With .MPObj(SelObjectCode(i))
                    If defObj(i).DefTimeAttValue Is Nothing = True Then
                        If .DefTimeAttValue Is Nothing = False Then
                            Erase .DefTimeAttValue
                        End If
                    Else
                        .DefTimeAttValue = clsGeneric.DefTimeAttValueClone(defObj(i).DefTimeAttValue)
                    End If
                End With
            Next
        End With

    End Sub
    Private Sub setTimeData()
        KtGrid.init("初期時間属性", "オブジェクト", "時間属性", 2, 1, 1, 0, False, True, False, False, False, False, False, False, True, False)

        For i As Integer = 0 To defGroup.DefTimeAttDataNum - 1
            addPointData(i)
        Next
        KtGrid.Layer = 0
        KtGrid.Show()


    End Sub
    ''' <summary>
    ''' グリッドに初期時点属性を追加する
    ''' </summary>
    ''' <param name="attn"></param>
    ''' <remarks></remarks>
    Private Sub addPointData(ByVal attn As Integer)

        Dim maxx As Integer = getTimeDataMaxNum(attn)
        With defGroup.DefTimeAttSTC(attn).attData
            KtGrid.AddLayer(.Title, attn, maxx * 2 + 1, SelObjNum)
        End With
        setKtgridYSData(attn)
        For j As Integer = 0 To SelObjNum - 1
            KtGrid.FixedXSData(attn, 1, j) = MapData.MPObj(SelObjectCode(j)).NameTimeSTC(0).connectNames
            setGridEachData(attn, j, defObj(j).DefTimeAttValue(attn).Data)
        Next
        KtGrid.Layer = attn

    End Sub


    ''' <summary>
    ''' 指定したデータの設定時間数の最大値を求める
    ''' </summary>
    ''' <param name="attrDatan"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getTimeDataMaxNum(ByVal attrDatan As Integer) As Integer
        Dim mx As Integer = 0
        For i As Integer = 0 To SelObjNum - 1
            With defObj(i).DefTimeAttValue(attrDatan)
                If .Data Is Nothing = False Then
                    mx = Math.Max(mx, .Data.Length)
                End If
            End With
        Next
        Return mx
    End Function
    Private Sub setKtgridYSData(ByVal attn As Integer)
        Dim dtype As enmAttDataType
        Dim TimeTx As String = ""
        With defGroup.DefTimeAttSTC(attn)
            Select Case .Type
                Case clsMapData.enmDefTimeAttDataType.PointData
                    TimeTx = "時期"
                Case clsMapData.enmDefTimeAttDataType.SpanData
                    TimeTx = "期間"
            End Select
            dtype = clsGeneric.getAttDataType_From_TitleUnit(.attData.Title, .attData.Unit)
        End With
        For i As Integer = 0 To KtGrid.Xsize(attn) - 2 Step 2
            KtGrid.FixedYSData(attn, i, 0) = TimeTx
            KtGrid.FixedYSData(attn, i + 1, 0) = "値"
            KtGrid.GridAlligntment(attn, i) = HorizontalAlignment.Left
            Select Case dtype
                Case enmAttDataType.Normal
                    KtGrid.GridAlligntment(attn, i + 1) = HorizontalAlignment.Right
                Case Else
                    KtGrid.GridAlligntment(attn, i + 1) = HorizontalAlignment.Left
            End Select
        Next
        KtGrid.FixedYSData(attn, KtGrid.Xsize(attn) - 1, 0) = ""
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
        KtGrid.DefaultGridWidth = 125
        If Data Is Nothing = False Then
            For k As Integer = 0 To Data.Length - 1
                Dim timetx As String = ""
                Select Case defGroup.DefTimeAttSTC(attn).Type
                    Case clsMapData.enmDefTimeAttDataType.PointData
                        timetx = clsTime.YMDtoString(Data(k).Span.StartTime)
                    Case clsMapData.enmDefTimeAttDataType.SpanData
                        timetx = clsTime.StartEndtoString(Data(k).Span)
                        KtGrid.GridWidth(attn, k * 2) = 160
                End Select
                KtGrid.GridData(attn, k * 2, GridY) = timetx
                KtGrid.GridData(attn, k * 2 + 1, GridY) = Data(k).Value
                n += 2
            Next
        End If
        For i As Integer = n To KtGrid.Xsize(attn) - 1
            KtGrid.GridData(attn, i, GridY) = ""
        Next
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
    Private Sub ktgrid_Click_DataGrid(Layer As Integer, X As Integer, Y As Integer, Value As String, Top As Single, Left As Single, Width As Single, Height As Single) Handles KtGrid.Click_DataGrid

        If MapData.Map.Time_Mode = True Then
            Dim form As New frmMED_DefTimeAttDataObjectEdit
            If form.ShowDialog(Me, MapData, MapData.MPObj(SelObjectCode(Y)), defGroup.DefTimeAttSTC(Layer), defObj(Y).DefTimeAttValue(Layer).Data) = Windows.Forms.DialogResult.OK Then
                defObj(Y).DefTimeAttValue(Layer).Data = form.getResult
                Dim maxx As Integer = getTimeDataMaxNum(Layer)
                KtGrid.Xsize(Layer) = maxx * 2 + 1
                setKtgridYSData(Layer)
                setGridEachData(Layer, Y, defObj(Y).DefTimeAttValue(Layer).Data)
                KtGrid.Refresh()
            End If
            form.Dispose()
        End If

    End Sub
End Class