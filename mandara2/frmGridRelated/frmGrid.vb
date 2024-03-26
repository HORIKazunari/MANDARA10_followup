'
' GIS Software MANDARA
' Source Code File name  frmGird.vb
'
' (C) 2016 - 2022 TANI Kenji
' License of this code is  CC BY-SA 4.0
'
' 2024  Errors and Warnings Collection by HORI Kazunari
'
Public Class frmGrid
    Dim CloseCancelF As Boolean
    Public Structure Layer_Data_Info
        Public Data As Integer
        Public Layer As Integer
    End Structure
    Private Structure Layer_Data_InfoCheck
        Public Data As Integer
        Public Layer As Integer
        Public Value As Double
    End Structure
    Public Structure GridLayerData_Info
        Public MapFile As String
        Public Type As String
        Public Shape As String
        Public Time As String
        Public OldIndex As String
        Public Mesh As String
        Public SyntheticObjF As String
        Public Comment As String
        Public ReferenceSystem As String
    End Structure
    Private GridLayerData As GridLayerData_Info
    Dim Change_Data As Boolean
    Dim ZahyoOk As Boolean
    Private newAttrData As clsAttrData
    Dim SearchSTR As String
    Dim cbx As Integer
    Dim cby As Integer
    Dim cbl As Integer
    Dim D_CheckDataValue As List(Of Double())
    Dim oldAttr As clsAttrData
    Dim newDataFlag As Boolean
    Public Overloads Function ShowDialog(ByRef _attrData As clsAttrData, ByRef TileMap As clsTileMapService) As DialogResult
        setIniform()
        newAttrData = New clsAttrData(TileMap)

        If _attrData.TotalData.LV1.Lay_Maxn = 0 Then
            newDataFlag = True
        Else
            newDataFlag = False
        End If

        ktGrid.init("レイヤ", "オブジェクト", "属性データ", 2, 1, 6, 3, True, True, True, True, True, True, True, False, True, True)
        If newDataFlag = True Then
            ktGrid.AddLayer("新しいレイヤ", 0, 5, 50)
            ktGrid.LayerData(0, GridLayerData.Shape) = enmShape.NotDeffinition
            ktGrid.LayerData(0, GridLayerData.Time) = clsTime.GetNullYMD
            ktGrid.LayerData(0, GridLayerData.OldIndex) = -1
            ktGrid.LayerData(0, GridLayerData.Type) = clsAttrData.enmLayerType.Normal
            ktGrid.LayerData(0, GridLayerData.Mesh) = enmMesh_Number.mhNonMesh
            ktGrid.LayerData(0, GridLayerData.SyntheticObjF) = False
            ktGrid.LayerData(0, GridLayerData.ReferenceSystem) = enmZahyo_System_Info.Zahyo_System_World
            ktGrid.LayerData(0, GridLayerData.Comment) = ""
            For i As Integer = 0 To ktGrid.Xsize(0) - 1
                ktGrid.FixedYSData(0, i, 2) = clsGeneric.ConvertMissingValueBoolString(False)
            Next
            clsGeneric.Set_First_GridCellWidthHeight(ktGrid, 0)
            With newAttrData.TotalData.LV1
                .DataSourceType = enmDataSource.DataEdit
                .FileName = "DataEditor"
                .FullPath = "DataEditor"
            End With
            btnRemoveMapFile.Enabled = False
            btnReplaceMapFile.Enabled = False
            btnObjectNameCopy.Enabled = False
            btnAddDefAttr.Enabled = False
            btnGPX.Enabled = False
            ktGrid.Visible = False
            gbFind.Enabled = False
        Else
            oldAttr = _attrData
            With _attrData
                Dim Mapfiles() As String = .GetMapFileName
                If Mapfiles Is Nothing = False Then
                    lbMapFile.Items.AddRange(Mapfiles)
                    For i As Integer = 0 To Mapfiles.Count - 1
                        newAttrData.AddExistingMapData(.SetMapFile(Mapfiles(i)), Mapfiles(i))
                    Next
                    lbMapFile.SelectedIndex = 0
                End If
                D_CheckDataValue = New List(Of Double())

                For i As Integer = 0 To .TotalData.LV1.Lay_Maxn - 1
                    With .LayerData(i)
                        Dim Datan As Integer = .atrData.Count
                        Dim URLMax As Integer
                        If .Type = clsAttrData.enmLayerType.Trip Or .Type = clsAttrData.enmLayerType.Trip_Definition Then
                            URLMax = 0
                        Else
                            URLMax = _attrData.Get_MaxURLNum(i)
                        End If
                        Dim TripPlus As Integer = 0
                        Dim DefPointPlus As Integer = 0
                        Select Case .Type
                            Case clsAttrData.enmLayerType.DefPoint
                                DefPointPlus = 2
                            Case clsAttrData.enmLayerType.Trip
                                If .TripType = clsAttrData.enmTripPositionType.ObjectSet Then
                                    TripPlus = 3
                                Else
                                    TripPlus = 4
                                End If
                        End Select
                        Dim d(Datan - 1) As Double
                        For j As Integer = 0 To .atrData.Count - 1
                            d(j) = Get_Data_Property_Value(_attrData, i, j)
                        Next
                        D_CheckDataValue.Add(d)
                        Dim SideE As Boolean = True
                        Dim SyntheticObjF As Boolean = False
                        If .atrObject.NumOfSyntheticObj > 0 Then
                            '合成オブジェクトはオブジェクト名を変更しない
                            SyntheticObjF = True
                            SideE = False
                        End If
                        ktGrid.AddLayer(.Name, i, Math.Max(1, .atrData.Count) + TripPlus + DefPointPlus + URLMax * 2, Math.Max(.atrObject.ObjectNum, 1),
                                        True, True, True, SideE, True, SideE, True, False)
                        Select Case .Type
                            Case clsAttrData.enmLayerType.DefPoint
                                ktGrid.FixedYSData(i, 0, 3) = "LON"
                                ktGrid.FixedYSData(i, 1, 3) = "LAT"
                            Case clsAttrData.enmLayerType.Trip
                                If .TripType = clsAttrData.enmTripPositionType.ObjectSet Then
                                    ktGrid.FixedYSData(i, 0, 3) = "PLACE"
                                Else
                                    ktGrid.FixedYSData(i, 0, 3) = "LON"
                                    ktGrid.FixedYSData(i, 1, 3) = "LAT"
                                End If
                                ktGrid.FixedYSData(i, TripPlus - 2, 3) = "ARRIVAL"
                                ktGrid.FixedYSData(i, TripPlus - 1, 3) = "DEPARTURE"
                        End Select
                        For j As Integer = 0 To Datan - 1
                            With .atrData.Data(j)
                                ktGrid.FixedYSData(i, TripPlus + DefPointPlus + j, 2) = clsGeneric.ConvertMissingValueBoolString(.MissingF)
                                ktGrid.FixedYSData(i, TripPlus + DefPointPlus + j, 3) = .Title
                                ktGrid.FixedYSData(i, TripPlus + DefPointPlus + j, 4) = .Unit
                                ktGrid.FixedYSData(i, TripPlus + DefPointPlus + j, 5) = .Note
                            End With
                        Next
                        For k As Integer = 0 To .atrObject.ObjectNum - 1
                            ktGrid.FixedXSData(i, 1, k) = _attrData.Get_KenObjName(i, k)
                            Select Case .Type
                                Case clsAttrData.enmLayerType.DefPoint
                                    With .atrObject.atrObjectData(k)
                                        ktGrid.GridData(i, 0, k) = clsGeneric.SingleToString(.defPoint.Longitude)
                                        ktGrid.GridData(i, 1, k) = clsGeneric.SingleToString(.defPoint.Latitude)
                                    End With
                                Case clsAttrData.enmLayerType.Trip
                                    If .TripType = clsAttrData.enmTripPositionType.ObjectSet Then
                                        With .atrObject.TripObjData(k)
                                            ktGrid.GridData(i, 0, k) = .PositionObjName
                                        End With
                                    Else
                                        With .atrObject.TripObjData(k)
                                            ktGrid.GridData(i, 0, k) = clsGeneric.SingleToString(.LatLon.Longitude)
                                            ktGrid.GridData(i, 1, k) = clsGeneric.SingleToString(.LatLon.Latitude)
                                        End With
                                    End If
                                    With .atrObject.TripObjData(k)
                                        ktGrid.GridData(i, TripPlus - 2, k) = .ArrivalTime.ToString("yyyyMMddHHmmss")
                                        ktGrid.GridData(i, TripPlus - 1, k) = .DepartureTime.ToString("yyyyMMddHHmmss")
                                    End With
                            End Select
                            For j As Integer = 0 To .atrData.Count - 1
                                ktGrid.GridData(i, TripPlus + DefPointPlus + j, k) = .atrData.Data(j).Value(k)
                            Next
                            If .Type <> clsAttrData.enmLayerType.Trip And .Type <> clsAttrData.enmLayerType.Trip_Definition Then
                                With .atrObject.atrObjectData(k)
                                    For j As Integer = 0 To .HyperLinkNum - 1
                                        ktGrid.GridData(i, TripPlus + DefPointPlus + Datan + j * 2, k) = .HyperLink(j).Name
                                        ktGrid.GridData(i, TripPlus + DefPointPlus + Datan + j * 2 + 1, k) = .HyperLink(j).Address
                                    Next
                                End With
                            End If
                        Next
                        For j As Integer = 0 To URLMax - 1
                            ktGrid.FixedYSData(i, .atrData.Count + j * 2, 3) = "URL_NAME"
                            ktGrid.FixedYSData(i, .atrData.Count + j * 2 + 1, 3) = "URL"
                        Next
                        clsGeneric.Check_DataKind_and_Allignment(ktGrid, i, .Type)
                        ktGrid.LayerData(i, GridLayerData.MapFile) = .MapFileName
                        ktGrid.LayerData(i, GridLayerData.Shape) = .Shape
                        ktGrid.LayerData(i, GridLayerData.Time) = .Time
                        ktGrid.LayerData(i, GridLayerData.OldIndex) = i
                        ktGrid.LayerData(i, GridLayerData.Type) = .Type
                        ktGrid.LayerData(i, GridLayerData.Mesh) = .MeshType
                        ktGrid.LayerData(i, GridLayerData.SyntheticObjF) = SyntheticObjF
                        ktGrid.LayerData(i, GridLayerData.ReferenceSystem) = .ReferenceSystem
                        ktGrid.LayerData(i, GridLayerData.Comment) = .Comment
                        clsGeneric.Set_First_GridCellWidthHeight(ktGrid, i)
                    End With
                Next
                With .TotalData.LV1
                    newAttrData.TotalData.LV1.DataSourceType = .DataSourceType
                    newAttrData.TotalData.LV1.FileName = .FileName
                    newAttrData.TotalData.LV1.FullPath = .FullPath
                    newAttrData.TotalData.LV1.Comment = .Comment
                End With
            End With
        End If
        'ktGrid.GridColor(0, 0, 2) = Color.Blue
        ktGrid.Show()
        SetMapFileList_to_CboBox()
        If _attrData.TotalData.LV1.SelectedLayer <> 0 Then
            ktGrid.SetGridPosition(_attrData.TotalData.LV1.SelectedLayer, 0, 0)
        Else
            Check_DataKind(0)
            Set_LayerTypeShape()
        End If
        ErrorCheck()
        Return Me.ShowDialog()
    End Function
    ''' 
    ''' 
    ''' 
    ''' 
    ''' 
    ''' 
    ''' 
    ''' 
    Private Function Get_Data_Property_Value(ByRef _attrData As clsAttrData, ByVal Layernum As Integer, ByVal DataNum As Integer) As Double
        With _attrData.LayerData(Layernum)
            Select Case .atrData.Data(DataNum).DataType
                Case enmAttDataType.Normal
                    '平均値
                    Return .atrData.Data(DataNum).Statistics.Ave
                Case enmAttDataType.Category
                    Dim freq() As Integer = Nothing ' freqを初期化
                    Dim n As Integer = 0
                    _attrData.Get_ClassFrequency(Layernum, DataNum, False, freq, False)
                    For i As Integer = 0 To freq.Length - 1
                        n += freq(i)
                    Next
                    '度数分布の平均
                    Return n / freq.Length
                Case enmAttDataType.Strings
                    Dim n As Integer = 0
                    For i As Integer = 0 To .atrObject.ObjectNum - 1
                        n += Len(_attrData.Get_Data_Value(Layernum, DataNum, i, ""))
                    Next
                    '文字列の長さの平均値
                    Return n / .atrObject.ObjectNum
            End Select
        End With
    End Function
    ''' データエラーのチェック
    ''' 
    Private Function ErrorCheck() As Boolean
        Dim errorMes As New List(Of String)
        lbError.Items.Clear()
        If ErrorCheckLayerMapFile(errorMes) = True Then
            lbError.Items.AddRange(errorMes.ToArray)
            Return True
        End If
        For i As Integer = 0 To ktGrid.LayerMax - 1
            Check_ObjectNameLayer(i, errorMes)
        Next
        lbError.Items.AddRange(errorMes.ToArray)
        If errorMes.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' 
    ''' レイヤ全体にかかわる項目エラーのチェック
    ''' 
    ''' 
    ''' 
    Private Function ErrorCheckLayerMapFile(ByRef errorMes As List(Of String)) As Boolean
        If newAttrData.GetNumOfMapFile = 0 Then
            errorMes.Add("地図ファイルが指定されていません。")
            Return True
        End If
        Dim mfileList() As String = newAttrData.GetMapFileName
        Dim eMes As New List(Of String)
        Dim Trip_Def_Layer_num As Integer = 0
        Dim TripLay As Boolean = False
        For i As Integer = 0 To ktGrid.LayerMax - 1
            Dim laytype As clsAttrData.enmLayerType = CType(ktGrid.LayerData(i, GridLayerData.Type), clsAttrData.enmLayerType)
            Dim mpFile As clsMapData
            If laytype <> clsAttrData.enmLayerType.Trip_Definition Then
                Dim mpFileName As String = ktGrid.LayerData(i, GridLayerData.MapFile).ToString
                mpFile = newAttrData.SetMapFile(mpFileName)
                Dim mpn As Integer = Array.IndexOf(mfileList, mpFileName.ToUpper)
                If mpn <> -1 Then
                    mfileList(mpn) = ""
                End If

            End If
            Dim layName As String = ktGrid.LayerName(i)
            Dim kk As Integer = 0
            Dim FYGrid(,) As String = ktGrid.FixedYSData(i)
            Dim LatN As Integer = 0
            Dim LonN As Integer = 0
            Dim DepartureGet As Integer = 0
            Dim ArrivalGet As Integer = 0
            Dim PlaceGet As Integer = 0

            For j As Integer = 0 To ktGrid.Xsize(i) - 1
                Dim f As Boolean
                Dim ttl As String = UCase(FYGrid(j, 3))
                If ttl <> "URL" And ttl <> "URL_NAME" Then
                    If FYGrid(j, 3) = "" Then
                        f = False
                        For jj As Integer = 0 To ktGrid.Ysize(i) - 1
                            If ktGrid.GridData(i, j, jj) <> "" Then
                                f = True
                                Exit For
                            End If
                        Next
                    Else
                        f = True
                    End If
                    Select Case ttl
                        Case "LAT"
                            LatN += 1
                        Case "LON"
                            LonN += 1
                        Case "PLACE"
                            PlaceGet += 1
                        Case "ARRIVAL"
                            ArrivalGet += 1
                        Case "DEPARTURE"
                            DepartureGet += 1
                    End Select
                End If
                If f = True Then
                    kk += 1
                End If
            Next
            If kk = 0 Then
                errorMes.Add(layName + "：データ項目がありません。")
            End If


            Dim L_Time As strYMD
            Dim zahyo As enmZahyo_mode_info
            If laytype <> clsAttrData.enmLayerType.Trip_Definition Then
                L_Time = CType(ktGrid.LayerData(i, GridLayerData.Time), strYMD)
                zahyo = mpFile.Map.Zahyo.Mode
                If mpFile.Map.Time_Mode = True And L_Time.nullFlag = True Then
                    eMes.Add(layName + "：時期設定が必要です。")
                End If
            End If
            Dim SyntheticObjF As Boolean = CType(ktGrid.LayerData(i, GridLayerData.SyntheticObjF), Boolean)
            Select Case laytype
                Case clsAttrData.enmLayerType.Trip
                    If PlaceGet = 1 Or (LatN = 1 And LonN = 1) Then
                        If LatN <> 0 Or LonN <> 0 Then
                            If zahyo <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
                                eMes.Add(layName + "：緯度経度座標系の地図ファイルでないので移動データレイヤの緯度経度データは設定できません。")
                            End If
                        End If
                    Else
                        eMes.Add(layName + "：移動データレイヤの位置指定のタグ（LAT,LON,PLACE）が指定されていません。")
                    End If
                    If ktGrid.Xsize(i) < 3 Then
                        eMes.Add(layName + "：移動データレイヤのデータ項目数は３以上必要です。")
                    End If
                    If ArrivalGet <> 1 Then
                        eMes.Add(layName + "：移動データレイヤの到着時間タグ（ARRIVAL）が指定されていないか、複数指定されています。" + vbCrLf)
                    End If
                    If DepartureGet <> 1 Then
                        eMes.Add(layName + "：移動データレイヤの出発時間タグ（DEPARTURE）が指定されていないか、複数指定されています。" + vbCrLf)
                    End If
                    TripLay = True
                Case clsAttrData.enmLayerType.Trip_Definition
                    Trip_Def_Layer_num = 1
                Case clsAttrData.enmLayerType.DefPoint
                    If LatN = 0 Then
                        eMes.Add(layName + "：地点定義レイヤではLATタグで地点の緯度を指定して下さい。")
                    ElseIf LatN >= 2 Then
                        eMes.Add(layName + "：地点定義レイヤではLATタグを複数箇所で指定しないで下さい。")
                    End If
                    If LonN = 0 Then
                        eMes.Add(layName + "：地点定義レイヤではLONタグで地点の経度を指定して下さい。")
                    ElseIf LonN >= 2 Then
                        eMes.Add(layName + "：地点定義レイヤではLONタグを複数箇所で指定しないで下さい。")
                    End If
                    If zahyo = enmZahyo_mode_info.Zahyo_No_Mode Then
                        eMes.Add(layName + "：緯度経度座標系の地図ファイルでないので地点定義レイヤには設定できません。")
                    End If
                Case clsAttrData.enmLayerType.Mesh
                    If zahyo = enmZahyo_mode_info.Zahyo_No_Mode Then
                        eMes.Add(layName + "：緯度経度座標系の地図ファイルでないのでメッシュレイヤには設定できません。")
                    End If
            End Select
        Next
        For i As Integer = 0 To mfileList.Length - 1
            If mfileList(i) <> "" Then
                eMes.Add("地図ファイル" + mfileList(i) + "は使われていません。")
            End If
        Next
        If TripLay = True And Trip_Def_Layer_num = 0 Then
            eMes.Add("移動レイヤがありますが、移動主体定義レイヤが存在しません。")
        End If
        If Trip_Def_Layer_num >= 2 Then
            eMes.Add("移動主体定義レイヤは一つしか設定できません。")
        End If
        If eMes.Count = 0 Then
            Return False
        Else
            errorMes.AddRange(eMes)
            Return True
        End If
    End Function
    Private Sub SetMapFileList_to_CboBox()
        With cboLayerMapFile.Items
            .Clear()
            Dim Mapfiles() As String = newAttrData.GetMapFileName
            If Mapfiles Is Nothing = True Then
                Return
            End If
            For i As Integer = 0 To Mapfiles.Length - 1
                .Add(Mapfiles(i))
            Next
        End With
    End Sub
    ''' <summary>
    ''' レイヤ情報の画面セット
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Set_LayerTypeShape()
        gbLayerMapFile.Visible = False
        gbLayerType.Visible = False
        gbShape.Visible = False
        gbMeshType.Visible = False
        gbDateTime.Visible = False
        gbLayerComment.Visible = False
        gbReferenceSystem.Visible = False
        If newAttrData.GetNumOfMapFile = 0 Then
            Return
        End If
        With ktGrid
            Dim LayerNum As Integer = .Layer
            Dim layMap As String = CType(.LayerData(LayerNum, GridLayerData.MapFile), String)
            '            If layMap <> "" Then
            cboLayerMapFile.Text = layMap
            Dim LayType As clsAttrData.enmLayerType = CType(.LayerData(LayerNum, GridLayerData.Type), clsAttrData.enmLayerType)
            Dim LayShape As enmShape = CType(.LayerData(LayerNum, GridLayerData.Shape), enmShape)
            Dim MeshType As enmMesh_Number = CType(.LayerData(LayerNum, GridLayerData.Mesh), enmMesh_Number)
            Dim ReferenceSystm As enmZahyo_System_Info = CType(.LayerData(LayerNum, GridLayerData.ReferenceSystem), enmZahyo_System_Info)
            With cboAttDataType
                .Items.Clear()
                .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.Normal))
                .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.Category))
                .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.Strings))
                .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.URL))
                .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.URL_Name))
                If LayType = clsAttrData.enmLayerType.DefPoint Or LayType = clsAttrData.enmLayerType.Trip Then
                    .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.Lon))
                    .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.Lat))
                End If
                If LayType = clsAttrData.enmLayerType.Trip Then
                    .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.Place))
                    .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.Arrival))
                    .Items.Add(clsGeneric.ConvertAttDataTypeString(enmAttDataType.Departure))
                End If
            End With
            Dim tx As String = clsGeneric.ConvertStringLayerTypeString(LayType)
            cboLayerType.Text = tx
            cboLayerShape.Text = clsGeneric.ConvertShapeEnumString(LayShape)
            cboMesh.Text = clsGeneric.ConvertMeshTypeEnumString(MeshType)
            Select Case ReferenceSystm
                Case enmZahyo_System_Info.Zahyo_System_tokyo
                    rbTokyo.Checked = True
                Case enmZahyo_System_Info.Zahyo_System_World
                    rbWorld.Checked = True
            End Select
            Dim T As strYMD = CType(.LayerData(LayerNum, GridLayerData.Time), strYMD)
            If T.nullFlag = False Then
                DateTimePickerLayer.Value = clsTime.getDateTime(T)
                gbDateTime.Visible = True
            Else
                gbDateTime.Visible = False
            End If
            gbLayerType.Visible = True
            gbLayerComment.Visible = True
            Dim SymtheF As Boolean = CType(.LayerData(LayerNum, GridLayerData.SyntheticObjF), Boolean)
            If SymtheF = True Then
                gbLayerMapFile.Visible = True
                gbShape.Visible = True
                gbMeshType.Visible = False
                gbLayerType.Enabled = False
                gbLayerMapFile.Enabled = False
                gbDateTime.Enabled = False
                gbShape.Enabled = False
            Else
                gbDateTime.Enabled = True
                gbLayerType.Enabled = True
                gbLayerMapFile.Enabled = True
                gbShape.Enabled = True
                Select Case LayType
                    Case clsAttrData.enmLayerType.Normal
                        gbLayerMapFile.Visible = True
                        gbShape.Visible = True
                    Case clsAttrData.enmLayerType.DefPoint
                        gbLayerMapFile.Visible = True
                        gbReferenceSystem.Visible = True
                    Case clsAttrData.enmLayerType.Mesh
                        gbLayerMapFile.Visible = True
                        gbShape.Visible = True
                        gbMeshType.Visible = True
                        gbReferenceSystem.Visible = True
                    Case clsAttrData.enmLayerType.Trip
                        gbLayerMapFile.Visible = True
                        gbReferenceSystem.Visible = True
                    Case clsAttrData.enmLayerType.Trip_Definition
                        gbLayerMapFile.Visible = False
                        gbDateTime.Visible = False
                End Select
            End If
            txtLayerComment.Text = CType(.LayerData(LayerNum, GridLayerData.Comment), String)
        End With
    End Sub
    ''' <summary>
    ''' データ項目タイトルの設定
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <remarks></remarks>
    Private Sub Check_DataKind(ByVal Layernum As Integer)
        Dim ttl As String


        For i As Integer = 0 To ktGrid.Xsize(Layernum) - 1
            Dim lType As clsAttrData.enmLayerType = CType(ktGrid.LayerData(Layernum, GridLayerData.Type), clsAttrData.enmLayerType)

            ttl = "通常のデータ"
            Dim titleCell As String = UCase(ktGrid.FixedYSData(Layernum, i, 3))
            Dim unitCell As String = UCase(ktGrid.FixedYSData(Layernum, i, 4))

            If titleCell = "URL_NAME" Then
                ttl = clsGeneric.ConvertAttDataTypeString(enmAttDataType.URL_Name)
            ElseIf titleCell = "URL" Then
                ttl = clsGeneric.ConvertAttDataTypeString(enmAttDataType.URL)
            ElseIf unitCell = "CAT" Then
                ttl = clsGeneric.ConvertAttDataTypeString(enmAttDataType.Category)
            ElseIf unitCell = "STR" Then
                ttl = clsGeneric.ConvertAttDataTypeString(enmAttDataType.Strings)
            Else
                Select Case lType
                    Case clsAttrData.enmLayerType.DefPoint
                        Select Case titleCell
                            Case "LON"
                                ttl = clsGeneric.ConvertAttDataTypeString(enmAttDataType.Lon)
                            Case "LAT"
                                ttl = clsGeneric.ConvertAttDataTypeString(enmAttDataType.Lat)
                        End Select
                    Case clsAttrData.enmLayerType.Trip
                        Select Case titleCell
                            Case "LON"
                                ttl = clsGeneric.ConvertAttDataTypeString(enmAttDataType.Lon)
                            Case "LAT"
                                ttl = clsGeneric.ConvertAttDataTypeString(enmAttDataType.Lat)
                            Case "ARRIVAL"
                                ttl = clsGeneric.ConvertAttDataTypeString(enmAttDataType.Arrival)
                            Case "DEPARTURE"
                                ttl = clsGeneric.ConvertAttDataTypeString(enmAttDataType.Departure)
                            Case "PLACE"
                                ttl = clsGeneric.ConvertAttDataTypeString(enmAttDataType.Place)
                        End Select
                End Select

            End If
            ktGrid.FixedYSData(Layernum, i, 1) = ttl

        Next

    End Sub

    Private Sub ktGrid_Add_Layer(InsertPoint As Integer) Handles ktGrid.Add_Layer

        With ktGrid
            Dim w(.LayerMax - 1) As String
            For i As Integer = 0 To ktGrid.LayerMax - 1
                w(i) = ktGrid.LayerName(i)
            Next

            ktGrid.LayerData(InsertPoint, GridLayerData.Shape) = enmShape.NotDeffinition
            ktGrid.LayerData(InsertPoint, GridLayerData.Time) = clsTime.GetYMD(DateTime.Today)
            ktGrid.LayerData(InsertPoint, GridLayerData.OldIndex) = -1
            ktGrid.LayerData(InsertPoint, GridLayerData.Type) = clsAttrData.enmLayerType.Normal
            ktGrid.LayerData(InsertPoint, GridLayerData.Mesh) = enmMesh_Number.mhNonMesh
            ktGrid.LayerData(InsertPoint, GridLayerData.ReferenceSystem) = enmZahyo_System_Info.Zahyo_System_World
            ktGrid.LayerData(InsertPoint, GridLayerData.SyntheticObjF) = False
            If lbMapFile.Items.Count > 0 Then
                ktGrid.LayerData(InsertPoint, GridLayerData.MapFile) = lbMapFile.Items(0)
            End If
            Dim datan As Integer = ktGrid.Xsize(InsertPoint)
            For i As Integer = 0 To datan - 1
                ktGrid.FixedYSData(InsertPoint, i, 2) = clsGeneric.ConvertMissingValueBoolString(False)
            Next
            ktGrid.LayerData(InsertPoint, GridLayerData.Comment) = ""
            clsGeneric.Set_First_GridCellWidthHeight(ktGrid, InsertPoint)
            ktGrid.Layer = InsertPoint
            Call Check_DataKind(InsertPoint)
            ktGrid.Refresh()
        End With
        ErrorCheck()
    End Sub

    Private Sub ktGrid_Change_Data() Handles ktGrid.Change_Data
        Change_Data = True
        ErrorCheck()
    End Sub

    Private Sub ktGrid_Change_FixedUpperLeft() Handles ktGrid.Change_FixedUpperLeft
        Change_Data = True
    End Sub

    Private Sub ktGrid_Change_FixedXS() Handles ktGrid.Change_FixedXS
        Change_Data = True
        ErrorCheck()
    End Sub

    Private Sub ktGrid_Change_FixedYS1() Handles ktGrid.Change_FixedYS
        clsGeneric.Check_DataKind_and_Allignment(ktGrid, ktGrid.Layer, ktGrid.LayerData(ktGrid.Layer, GridLayerData.Type))

        ktGrid.Refresh()
        ErrorCheck()
    End Sub

    Private Sub ktGrid_Change_Layer(LayerNameChange As Boolean, LayerMove As Boolean, LayerDelete As Boolean) Handles ktGrid.Change_Layer
        Change_Data = True
        If LayerDelete = True Then
            Call Set_LayerTypeShape()
        End If
    End Sub


    Private Sub ktGrid_Change_LayerSelect(Layer As Integer, PreviousLayer As Integer) Handles ktGrid.Change_LayerSelect
        Set_LayerTypeShape()
        ErrorCheck()
    End Sub



    Private Sub cboAttDataType_Enter(sender As Object, e As EventArgs) Handles cboAttDataType.Enter, cboMissingValue.Enter
        sender.DroppedDown = True
    End Sub

    Private Sub cboAttDataType_LostFocus(sender As Object, e As EventArgs) Handles cboAttDataType.LostFocus
        cboAttDataType.Visible = False
        ktGrid.FixedYSData(cbl, cbx, cby) = cboAttDataType.Text
        Dim dtype As enmAttDataType = clsGeneric.ConvertAttDataTypeString(cboAttDataType.Text)
        Dim Title As String = ktGrid.FixedYSData(cbl, cbx, 3)
        Dim Unit As String = ktGrid.FixedYSData(cbl, cbx, 4)
        clsGeneric.SetTitleUnit_from_AttDataType(dtype, Title, Unit)
        ktGrid.FixedYSData(cbl, cbx, 3) = Title
        ktGrid.FixedYSData(cbl, cbx, 4) = Unit
        clsGeneric.Check_DataKind_and_Allignment(ktGrid, ktGrid.Layer, ktGrid.LayerData(ktGrid.Layer, GridLayerData.Type))

        ktGrid.Refresh()
        ErrorCheck()
    End Sub

    Private Sub cboMissingValue_LostFocus(sender As Object, e As EventArgs) Handles cboMissingValue.LostFocus
        cboMissingValue.Visible = False
        ktGrid.FixedYSData(cbl, cbx, cby) = cboMissingValue.Text
        ktGrid.Refresh()
    End Sub

    Private Sub setIniform()
        SplitContainerOuter.SplitterDistance = gbMapfile.Top + gbMapfile.Height + gbMapfile.Top
        SplitContainerUpper.SplitterDistance = btnCancel.Left + btnCancel.Width * 1.5
        SplitContainerUpper.Panel1MinSize = SplitContainerUpper.SplitterDistance
        SplitContainerLayer.SplitterDistance = SplitContainerLayer.Width - (gbLayerMapFile.Width + gbLayerMapFile.Left * 2)
        ktGrid.MsgBoxTitle = Me.GetType.Assembly.GetName.Name

        With GridLayerData
            .MapFile = "MapFile"
            .Type = "Type"
            .Shape = "Shape"
            .Time = "Time"
            .OldIndex = "OldIndex"
            .Mesh = "Mesh"
            .SyntheticObjF = "Synthetic"
            .Comment = "Comment"
            .ReferenceSystem = "ReferenceSystem"
        End With
        Change_Data = False
        cboAttDataType.Parent = SplitContainerLayer.Panel1
        cboAttDataType.Visible = False
        With cboMissingValue
            .Items.Clear()
            .Items.Add(clsGeneric.ConvertMissingValueBoolString(True))
            .Items.Add(clsGeneric.ConvertMissingValueBoolString(False))
            .Parent = SplitContainerLayer.Panel1
            .Visible = False
        End With
        With cboLayerType
            .Items.Clear()
            .Items.Add(clsGeneric.ConvertStringLayerTypeString(clsAttrData.enmLayerType.Normal))
            .Items.Add(clsGeneric.ConvertStringLayerTypeString(clsAttrData.enmLayerType.DefPoint))
            .Items.Add(clsGeneric.ConvertStringLayerTypeString(clsAttrData.enmLayerType.Mesh))
            .Items.Add(clsGeneric.ConvertStringLayerTypeString(clsAttrData.enmLayerType.Trip_Definition))
            .Items.Add(clsGeneric.ConvertStringLayerTypeString(clsAttrData.enmLayerType.Trip))
        End With
        With cboLayerShape.Items
            .Clear()
            .Add(clsGeneric.ConvertShapeEnumString(enmShape.NotDeffinition))
            .Add(clsGeneric.ConvertShapeEnumString(enmShape.PointShape))
            .Add(clsGeneric.ConvertShapeEnumString(enmShape.LineShape))
            .Add(clsGeneric.ConvertShapeEnumString(enmShape.PolygonShape))
        End With
        With cboMesh.Items
            .Clear()
            .Add(clsGeneric.ConvertMeshTypeEnumString(enmMesh_Number.mhFirst))
            .Add(clsGeneric.ConvertMeshTypeEnumString(enmMesh_Number.mhSecond))
            .Add(clsGeneric.ConvertMeshTypeEnumString(enmMesh_Number.mhThird))
            .Add(clsGeneric.ConvertMeshTypeEnumString(enmMesh_Number.mhHalf))
            .Add(clsGeneric.ConvertMeshTypeEnumString(enmMesh_Number.mhQuarter))
            .Add(clsGeneric.ConvertMeshTypeEnumString(enmMesh_Number.mhOne_Eighth))
            .Add(clsGeneric.ConvertMeshTypeEnumString(enmMesh_Number.mhOne_Tenth))
        End With
    End Sub
    Private Sub btnGPXEnabledCheck()
        Dim mfile As String() = newAttrData.GetMapFileName
        btnGPX.Enabled = False
        For i As Integer = 0 To mfile.Length - 1
            If newAttrData.SetMapFile(mfile(i)).Map.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                btnGPX.Enabled = True
            End If

        Next
    End Sub
    Private Sub btnAddMapfile_Click(sender As Object, e As EventArgs) Handles btnAddMapfile.Click
        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = clsGeneric.Get_MapFolder
        ofd.Filter = "MANDARA地図ファイル(*.mpf?)|*.mpf?|圧縮地図ファイル(*.mpfz)|*.mpfz|非圧縮ファイル(*.mpfx)|*.mpfx|旧地図ファイル(*.mpf)|*.mpf"
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim fname As String = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName)
            If newAttrData.GetNumOfMapFile > 0 Then
                Dim mfile As String() = newAttrData.GetMapFileName
                If Array.IndexOf(mfile, fname.ToUpper) <> -1 Then
                    MsgBox(fname + "は既に読み込まれています。", MsgBoxStyle.Exclamation)
                    Return
                End If
            End If
            Dim mData As clsMapData
            Try
                Cursor.Current = Cursors.WaitCursor
                mData = New clsMapData(ofd.FileName)
            Catch ex As Exception
                MsgBox(ex.Message)
                Return
            Finally
                Cursor.Current = Cursors.Default
            End Try
            If newAttrData.GetNumOfMapFile > 0 Then
                Dim z As clsMapData.Zahyo_info = newAttrData.SetMapFile("").Map.Zahyo
                Dim emes As String
                If spatial.Check_Zahyo_Projection_Convert_Enabled(z, mData.Map.Zahyo, emes) = False Then
                    MsgBox(emes, MsgBoxStyle.Exclamation)
                    Return
                End If

            End If
            newAttrData.AddExistingMapData(mData, fname)
            lbMapFile.Items.Add(fname)
            cboLayerMapFile.Items.Add(fname)
            btnRemoveMapFile.Enabled = True
            btnReplaceMapFile.Enabled = True
            btnObjectNameCopy.Enabled = True
            btnAddDefAttr.Enabled = True
            ktGrid.Visible = True
            gbFind.Enabled = True
            btnGPXEnabledCheck()

            If newAttrData.GetNumOfMapFile = 1 Then
                For i As Integer = 0 To ktGrid.LayerMax - 1
                    ktGrid.LayerData(i, GridLayerData.MapFile) = fname
                Next
                Set_LayerTypeShape()
            End If
            ErrorCheck()
        End If

    End Sub

    Private Sub ktGrid_Click_FixedYS2(Layer As Integer, X As Integer, Y As Integer, Value As String, Top As Single, Left As Single, Width As Single, Height As Single) Handles ktGrid.Click_FixedYS2
        cbx = X
        cby = Y
        cbl = Layer

        Select Case Y
            Case 1
                With cboAttDataType
                    .Left = Left
                    .Top = Top
                    .Width = Width
                    .Height = Height
                    .BringToFront()
                    .Visible = True
                    .Text = ktGrid.FixedYSData(cbl, cbx, cby)
                    .Focus()
                End With
            Case 2
                With cboMissingValue
                    .Left = Left
                    .Top = Top
                    .Width = Width
                    .Height = Height
                    .BringToFront()
                    .Text = ktGrid.FixedYSData(cbl, cbx, cby)
                    .Visible = True
                    .Focus()
                End With

        End Select
    End Sub


    Private Sub btnRemoveMapFile_Click(sender As Object, e As EventArgs) Handles btnRemoveMapFile.Click
        Dim sel As Integer = lbMapFile.SelectedIndex
        If sel = -1 Then
            MsgBox("地図ファイルを選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim fname As String = lbMapFile.SelectedItem.ToString
        For i As Integer = 0 To ktGrid.LayerMax - 1
            If ktGrid.LayerData(i, GridLayerData.MapFile).ToString.ToUpper = fname.ToUpper Then
                MsgBox(fname + "は使用されています。", MsgBoxStyle.Exclamation)
                Return
            End If
        Next
        newAttrData.RemoveMapData(fname)
        lbMapFile.Items.RemoveAt(sel)
        cboLayerMapFile.Items.RemoveAt(sel)
        Set_LayerTypeShape()
    End Sub


    Private Sub cboLayerMapFile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayerMapFile.SelectedIndexChanged
        With ktGrid
            .LayerData(.Layer, GridLayerData.MapFile) = cboLayerMapFile.Text
            Dim LTime As strYMD = CType(.LayerData(.Layer, GridLayerData.Time), strYMD)
            If newAttrData.SetMapFile(cboLayerMapFile.Text).Map.Time_Mode = True And LTime.nullFlag = True Then
                .LayerData(.Layer, GridLayerData.Time) = clsTime.GetYMD(Date.Today)
                gbDateTime.Visible = True
            ElseIf newAttrData.SetMapFile(cboLayerMapFile.Text).Map.Time_Mode = False And LTime.nullFlag = False Then
                .LayerData(.Layer, GridLayerData.Time) = clsTime.GetNullYMD
                gbDateTime.Visible = False
            End If
            ErrorCheck()
        End With
    End Sub

    Private Sub cboLayerType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayerType.SelectedIndexChanged
        With ktGrid
            Dim ltype As clsAttrData.enmLayerType = clsGeneric.ConvertStringLayerTypeString(cboLayerType.Text)
            .LayerData(.Layer, GridLayerData.Type) = ltype
            Check_DataKind(.Layer)
            .LayerData(.Layer, GridLayerData.MapFile) = cboLayerMapFile.Text
            Select Case ltype
                Case clsAttrData.enmLayerType.Trip_Definition
                    .LayerData(.Layer, GridLayerData.MapFile) = ""
                Case clsAttrData.enmLayerType.DefPoint
                    .LayerData(.Layer, GridLayerData.Shape) = enmShape.PointShape
                Case clsAttrData.enmLayerType.Mesh
                    .LayerData(.Layer, GridLayerData.Shape) = enmShape.PolygonShape
                    If CType(.LayerData(.Layer, GridLayerData.Mesh), enmMesh_Number) = enmMesh_Number.mhNonMesh Then
                        .LayerData(.Layer, GridLayerData.Mesh) = enmMesh_Number.mhThird
                    End If
            End Select
            Set_LayerTypeShape()
            .Refresh()
        End With
        ErrorCheck()
    End Sub

    Private Sub btnObjectNameCopy_Click(sender As Object, e As EventArgs) Handles btnObjectNameCopy.Click
        With ktGrid
            Dim init_para As New frmCopyObjectName.init_parameter_data(newAttrData.SetMapFile(.LayerData(.Layer, GridLayerData.MapFile).ToString))
            init_para.Time = .LayerData(.Layer, GridLayerData.Time)
            Dim form = New frmCopyObjectName
            form.ShowDialog(Me, newAttrData.SetMapFile(.LayerData(.Layer, GridLayerData.MapFile).ToString), init_para)
            form.Dispose()
        End With
    End Sub

    ''' <summary>
    ''' レイヤごとのオブジェクト名をチェックする
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_ObjectNameLayer(ByVal LayerNum As Integer, ByRef errorMes As List(Of String)) As Boolean
        Dim eMes As New List(Of String)
        Dim Enable_Obj As Integer = 0

        Dim L_Name As String = ktGrid.LayerName(LayerNum)
        Dim LayerType As clsAttrData.enmLayerType = CType(ktGrid.LayerData(LayerNum, GridLayerData.Type), clsAttrData.enmLayerType)
        Dim SyntheticObjF As Boolean = CType(ktGrid.LayerData(LayerNum, GridLayerData.SyntheticObjF), Boolean)
        Dim mpFileName As String
        Dim mpFile As clsMapData
        If LayerType <> clsAttrData.enmLayerType.Trip_Definition Then
            mpFileName = ktGrid.LayerData(LayerNum, GridLayerData.MapFile).ToString
            mpFile = newAttrData.SetMapFile(mpFileName)
        End If

        If SyntheticObjF = False Then
            Dim L_Time As strYMD
            Dim LAY_Time As Boolean = True
            If LayerType = clsAttrData.enmLayerType.Trip_Definition Then
                L_Time = clsTime.GetNullYMD
            ElseIf mpFile.Map.Time_Mode = False Then
                L_Time = clsTime.GetNullYMD
            Else
                L_Time = CType(ktGrid.LayerData(LayerNum, GridLayerData.Time), strYMD)
            End If
            Dim MeshCodeLen As Integer = 0
            If LayerType = clsAttrData.enmLayerType.Mesh Then
                MeshCodeLen = clsGeneric.getMeshCodeLength(CType(ktGrid.LayerData(LayerNum, GridLayerData.Mesh), enmMesh_Number))
            End If

            Dim Object_Use_Check() As Boolean
            If LayerType <> clsAttrData.enmLayerType.Trip_Definition Then
                ReDim Object_Use_Check(mpFile.Map.Kend - 1)
            End If
            Dim FXGrid(,) As String = ktGrid.FixedXSData(LayerNum)
            Dim SH(CType([Enum].GetValues(GetType(enmShape)), Integer()).Max) As Integer
            For j As Integer = 0 To ktGrid.Ysize(LayerNum) - 1
                Dim ObjName As String = FXGrid(1, j)
                If ObjName <> "" Then
                    Select Case LayerType
                        Case clsAttrData.enmLayerType.Normal
                            Dim code As Integer = newAttrData.Get_ObjectCode_from_ObjName(mpFileName, ObjName, L_Time)
                            If code = -1 Then
                                Dim em2 As String = ""
                                For k As Integer = 0 To mpFile.Map.Kend - 1
                                    For k2 As Integer = 0 To mpFile.MPObj(k).NumOfNameTime - 1
                                        With mpFile.MPObj(k).NameTimeSTC(k2)
                                            If Array.IndexOf(.NamesList, ObjName) <> -1 Then
                                                em2 += clsGeneric.getTimeList(mpFile.MPObj(k).NameTimeSTC(k2)) & vbCrLf
                                            End If
                                        End With
                                    Next
                                Next
                                If em2 <> "" Then
                                    If LAY_Time = True Then
                                        eMes.Add(L_Name & "：「" & ObjName & "」は時期が違っています。正しい有効期間は" & vbCrLf & em2 & "です。")
                                    End If
                                Else
                                    eMes.Add(L_Name & "：「" & ObjName & "」は地図ファイル中に存在しません。")
                                End If
                            Else
                                If Object_Use_Check(code) = True Then
                                    eMes.Add(L_Name & "：「" & ObjName & "」は複数回使用されています。")
                                Else
                                    Object_Use_Check(code) = True
                                    SH(mpFile.MPObj(code).Shape) += 1
                                    Enable_Obj += 1
                                End If
                            End If
                        Case clsAttrData.enmLayerType.Mesh
                            If Len(ObjName) <> MeshCodeLen Then
                                eMes.Add(L_Name & "：「" + ObjName + "」はメッシュサイズが設定と異なります。")
                            Else
                                Enable_Obj += 1
                            End If
                        Case clsAttrData.enmLayerType.Trip, clsAttrData.enmLayerType.Trip_Definition, clsAttrData.enmLayerType.DefPoint
                            Enable_Obj += 1
                    End Select
                End If
            Next
            If Enable_Obj = 0 Then
                eMes.Add(L_Name & "：有効なオブジェクトがありません。")
            Else
                If LayerType = clsAttrData.enmLayerType.Normal Then
                    Dim enableShale As enmShape = clsGeneric.checkShape(SH)
                    Dim LayShape As enmShape = CType(ktGrid.LayerData(LayerNum, GridLayerData.Shape), enmShape)
                    Select Case LayShape
                        Case enmShape.PolygonShape
                            If enableShale <> enmShape.PolygonShape Then
                                eMes.Add(L_Name & "：面形状に設定できません。")
                            End If
                        Case enmShape.LineShape
                            If enableShale = enmShape.PointShape Then
                                eMes.Add(L_Name & "：線形状に設定できません。")
                            End If
                    End Select
                End If
            End If
            If eMes.Count = 0 Then
                Return False
            Else
                errorMes.AddRange(eMes)
                Return True
            End If
        End If
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If ErrorCheck() = True Then
            MsgBox("エラーがあります", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If

        Cursor.Current = Cursors.WaitCursor
        Dim emes As String
        Dim f As Boolean = Get_E_Data(emes)
        If f = False Then
            MsgBox(emes, MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If

        newAttrData.Check_LayerShape()
        Cursor.Current = Cursors.Default

        Dim Trip_err_Message As String
        If newAttrData.Check_Trip_Data(Trip_err_Message) = False Then
            If Trip_err_Message <> "" Then
                clsGeneric.Message(Me, "移動データに問題があります", Trip_err_Message, False, True)
            End If
            CloseCancelF = True
            Return
        End If

        If newDataFlag = True Then
            newAttrData.initTotalData_andOther()
            newAttrData.attrGridZahyoSet()

        Else
            newAttrData.TotalData.ViewStyle = oldAttr.TotalData.ViewStyle
            newAttrData.attrGridZahyoSet()
            If newAttrData.TotalData.ViewStyle.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
                newAttrData.TotalData.ViewStyle.TileMapView.Visible = False
            End If
            ZahyoOk = spatial.Check_Zahyo_Projection_Convert_Enabled(newAttrData.TotalData.ViewStyle.Zahyo, oldAttr.TotalData.ViewStyle.Zahyo, "")
            If ZahyoOk = True Then
                oldAttr.Convert_Zahyo(newAttrData.TotalData.ViewStyle.Zahyo)
            End If
            Check_Data()
            Reset_SCRView_Size()

            newAttrData.LinePatternCheck()
            newAttrData.PrtObjectSpatialIndex()

        End If
    End Sub
    ''' <summary>
    ''' '既存データの編集の場合、グリッド上中のデータと以前のデータを比較
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Check_Data()
        Dim R_Conv As New List(Of Layer_Data_Info())
        Dim r_md As Integer = 0
        For i As Integer = 0 To oldAttr.TotalData.LV1.Lay_Maxn - 1
            Dim datan As Integer = oldAttr.LayerData(i).atrData.Count
            Dim d(datan - 1) As Layer_Data_Info
            For j As Integer = 0 To datan - 1
                d(j).Layer = -1
                d(j).Data = -1
            Next
            R_Conv.Add(d)
        Next

        'グリッド上のデータに対応する旧データを設定
        Dim Conv As List(Of Layer_Data_Info()) = Get_Data_Refference()
        For i As Integer = 0 To newAttrData.TotalData.LV1.Lay_Maxn - 1
            For j As Integer = 0 To newAttrData.LayerData(i).atrData.Count - 1
                With Conv(i)(j)
                    If .Layer <> -1 Then
                        Dim d As frmGrid.Layer_Data_Info() = R_Conv(.Layer)
                        d(.Data).Layer = i
                        d(.Data).Data = j
                        R_Conv(.Layer) = d
                    End If
                End With
            Next
        Next

        Dim R_Layer_Convert(oldAttr.TotalData.LV1.Lay_Maxn - 1) As Integer
        For i As Integer = 0 To oldAttr.TotalData.LV1.Lay_Maxn - 1
            R_Layer_Convert(i) = -1
        Next
        For i As Integer = 0 To newAttrData.TotalData.LV1.Lay_Maxn - 1
            Dim L As Integer = CType(ktGrid.LayerData(i, GridLayerData.OldIndex), Integer)
            If L <> -1 Then
                R_Layer_Convert(L) = i
            End If
        Next



        '新しいデータの凡例をD_、D2にセット

        Dim TDL As Integer = newAttrData.Get_Trip_Definition_Layer_Number()
        For i As Integer = 0 To newAttrData.TotalData.LV1.Lay_Maxn - 1
            With newAttrData.LayerData(i)
                Dim L As Integer = CType(ktGrid.LayerData(i, GridLayerData.OldIndex), Integer)
                If L = -1 Then
                    .Print_Mode_Layer = enmLayerMode_Number.SoloMode
                    '新しいレイヤの場合
                Else
                    .Print_Mode_Layer = oldAttr.LayerData(L).Print_Mode_Layer
                    'グリッドのレイヤに対応する旧レイヤがある場合
                    'グラフモードの凡例をもってくる
                    Select Case .Type
                        Case clsAttrData.enmLayerType.Trip, clsAttrData.enmLayerType.Trip_Definition
                        Case clsAttrData.enmLayerType.Normal, clsAttrData.enmLayerType.Mesh, clsAttrData.enmLayerType.DefPoint
                            Call Check_Kencode_XY(i, L)
                    End Select

                    '.Shape = oldAttr.LayerData(L).Shape
                    .LayerModeViewSettings.PointLineShape = oldAttr.LayerData(L).LayerModeViewSettings.PointLineShape

                    If .MapFileName = oldAttr.LayerData(L).MapFileName And .Time.Equals(oldAttr.LayerData(L).Time) Then
                        .Dummy = oldAttr.LayerData(L).Dummy
                    Else
                        Dim dumn As Integer = oldAttr.LayerData(L).Dummy.Count
                        If dumn > 0 Then
                            Dim dumnewn As Integer = 0
                            ReDim .Dummy.DummyObj(dumn - 1)
                            For j As Integer = 0 To dumn - 1
                                Dim ocode As Integer = newAttrData.Get_ObjectCode_from_ObjName(i, oldAttr.LayerData(L).Dummy.DummyObj(j).Name)
                                If ocode <> -1 Then
                                    .Dummy.DummyObj(dumnewn).code = ocode
                                    .Dummy.DummyObj(dumnewn).Name = oldAttr.LayerData(L).Dummy.DummyObj(dumn - 1).Name
                                    dumnewn += 1
                                End If
                            Next
                            .Dummy.Count = dumnewn
                            If dumnewn = 0 Then
                                Erase .Dummy.DummyObj
                            Else
                                ReDim Preserve .Dummy.DummyObj(dumnewn - 1)
                            End If
                        End If
                    End If
                    If .MapFileName = oldAttr.LayerData(L).MapFileName Then
                        .DummyGroup = oldAttr.LayerData(L).DummyGroup
                    Else
                        .DummyGroup.Count = 0
                        Erase .DummyGroup.DummyObjG
                    End If
                    With .LayerModeViewSettings.GraphMode
                        .Count = oldAttr.LayerData(L).LayerModeViewSettings.GraphMode.Count
                        ReDim .DataSet(.Count - 1)
                        For k As Integer = 0 To .Count - 1
                            .DataSet(k) = oldAttr.LayerData(L).LayerModeViewSettings.GraphMode.DataSet(k)
                            Dim newDataC As Integer = 0
                            With .DataSet(k)
                                For j As Integer = 0 To .Count - 1
                                    Dim a As Integer = .Data(j).DataNumner
                                    Dim b As Integer = R_Conv(L)(a).Data
                                    If b <> -1 Then
                                        .Data(newDataC) = oldAttr.LayerData(L).LayerModeViewSettings.GraphMode.DataSet(k).Data(j)
                                        .Data(newDataC).DataNumner = b
                                        newDataC += 1
                                    End If
                                Next
                                .Count = newDataC
                                If newDataC = 0 Then
                                    Erase .Data
                                Else
                                    ReDim Preserve .Data(newDataC - 1)
                                End If
                            End With
                        Next
                    End With
                    '移動データ
                    With .LayerModeViewSettings.TripMode
                        .Count = oldAttr.LayerData(L).LayerModeViewSettings.TripMode.Count
                        ReDim .DataSet(.Count - 1)
                        For k As Integer = 0 To .Count - 1
                            .DataSet(k) = oldAttr.LayerData(L).LayerModeViewSettings.TripMode.DataSet(k)
                            With .DataSet(k)
                                If TDL = -1 Then
                                    If .Mode = clsAttrData.enmTripMode.TripDefinitionLayerDataMode Then
                                        .Mode = clsAttrData.enmTripMode.Blanc
                                        .Definition_Layer_Data = 0
                                    End If
                                Else
                                    Dim a As Integer = R_Conv(TDL)(.Definition_Layer_Data).Data
                                    If a = -1 Then
                                        a = 0
                                    End If
                                    .Definition_Layer_Data = a
                                End If
                                If .Stay_Data >= 2 Then
                                    Dim a As Integer = R_Conv(L)(.Stay_Data - 2).Data
                                    .Stay_Data = a + 2
                                End If
                                If .Move_Data >= 2 Then
                                    Dim a As Integer = R_Conv(L)(.Move_Data - 2).Data
                                    .Move_Data = a + 2
                                End If
                                If .ZData >= 1 Then
                                    Dim a As Integer = R_Conv(L)(.ZData - 1).Data
                                    .ZData = a + 1
                                End If
                            End With
                        Next
                    End With
                    'ラベルデータ
                    With .LayerModeViewSettings.LabelMode
                        .Count = oldAttr.LayerData(L).LayerModeViewSettings.LabelMode.Count
                        ReDim .DataSet(.Count - 1)
                        For k As Integer = 0 To .Count - 1
                            .DataSet(k) = oldAttr.LayerData(L).LayerModeViewSettings.LabelMode.DataSet(k)
                            With .DataSet(k)
                                Dim a As Integer = 0
                                For j As Integer = 0 To .CountOfDataItem - 1
                                    Dim kk As Integer = R_Conv(L)(oldAttr.LayerData(L).LayerModeViewSettings.LabelMode.DataSet(k).DataItem(j)).Data
                                    If kk <> -1 Then
                                        .DataItem(a) = kk
                                        a += 1
                                    End If
                                Next
                                .CountOfDataItem = a
                                If a = 0 Then
                                    Erase .DataItem
                                Else
                                    ReDim Preserve .DataItem(a - 1)
                                End If
                            End With
                        Next
                    End With
                End If

                Dim shapeNoChange As Boolean = True
                If L <> -1 Then
                    If newAttrData.LayerData(i).Shape <> oldAttr.LayerData(L).Shape Then
                        shapeNoChange = False
                    End If
                End If

                For j As Integer = 0 To .atrData.Count - 1

                    If Conv(i)(j).Data = -1 Or newAttrData.Get_DataType(i, j) = enmAttDataType.Strings Then
                        'グリッドのデータに対応する旧データがない場合、または文字モード
                    Else
                        'グリッドのデータに対応する旧データがある場合、
                        '旧データの凡例を持ってくる
                        Dim DD As Integer = Conv(i)(j).Data
                        Dim dL As Integer = Conv(i)(j).Layer

                        Dim O_Data As clsAttrData.strData_info = oldAttr.LayerData(dL).atrData.Data(DD)
                        If newAttrData.Check_Enable_SoloMode(O_Data.ModeData, i, j) = True Then
                            .atrData.Data(j).ModeData = O_Data.ModeData
                        End If

                        newAttrData.Set_Legend(i, j, O_Data, True, shapeNoChange, shapeNoChange, True, shapeNoChange, True, True, shapeNoChange, True, True, True, True, (i = dL))

                        If .MapFileName <> oldAttr.LayerData(dL).MapFileName Then
                            '地図ファイルが変更された場合に線モードのチェック
                            With .atrData.Data(j)
                                .SoloModeViewSettings.ClassODMD.O_object = 0
                                .SoloModeViewSettings.ClassODMD.o_Layer = i
                                For kk As Integer = 0 To newAttrData.TotalData.LV1.Lay_Maxn - 1
                                    For k As Integer = 0 To newAttrData.LayerData(kk).atrObject.ObjectNum - 1
                                        If InStr(.Title, newAttrData.Get_KenObjName(kk, k)) <> 0 Then
                                            .SoloModeViewSettings.ClassODMD.O_object = k
                                            .SoloModeViewSettings.ClassODMD.o_Layer = kk
                                            kk = newAttrData.TotalData.LV1.Lay_Maxn
                                            Exit For
                                        End If
                                    Next
                                Next
                            End With
                        Else
                            '地図ファイルが変更されていない場合の線モードのチェック
                            Dim odl As Integer, odo As Integer, oob As Integer
                            With O_Data.SoloModeViewSettings.ClassODMD
                                odl = .o_Layer
                                odo = .O_object
                                oob = oldAttr.Get_KenObjCode(odl, odo) ' D_Kencode(odo + D_Layer(odl).Object.Stac).Object.code
                            End With
                            With .atrData.Data(j).SoloModeViewSettings.ClassODMD
                                If R_Layer_Convert(odl) <> -1 Then
                                    .o_Layer = R_Layer_Convert(odl)
                                    .O_object = 0
                                    If .Dummy_ObjectFlag = False Then
                                        For k As Integer = 0 To newAttrData.Get_ObjectNum(.o_Layer) - 1
                                            If newAttrData.Get_KenObjCode(.o_Layer, k) = oob Then
                                                .O_object = k
                                                Exit For
                                            End If
                                        Next
                                    End If
                                Else
                                    .o_Layer = i
                                    .O_object = 0
                                End If
                            End With
                        End If
                        '記号の大きさモードの内部塗りつぶしデータ項目のチェック
                        If newAttrData.LayerData(i).Type <> clsAttrData.enmLayerType.Trip Then
                            With .atrData.Data(j).SoloModeViewSettings
                                If L = -1 Then
                                    With .MarkCommon.Inner_Data
                                        .Data = j
                                        .Flag = False
                                    End With
                                Else
                                    .MarkCommon.Inner_Data = O_Data.SoloModeViewSettings.MarkCommon.Inner_Data
                                    With .MarkCommon.Inner_Data
                                        Dim k As Integer = R_Conv(L)(.Data).Data
                                        If k = -1 Then
                                            .Data = j
                                            .Flag = False
                                        Else
                                            .Data = k
                                        End If
                                    End With
                                End If
                            End With
                        End If
                    End If
                Next
            End With

        Next


        '---------------------線モードのベジェ曲線をチェック
        For L As Integer = 0 To oldAttr.TotalData.LV1.Lay_Maxn - 1
            If oldAttr.LayerData(L).Type = clsAttrData.enmLayerType.Normal Or oldAttr.LayerData(L).Type = clsAttrData.enmLayerType.Mesh Then
                For i As Integer = 0 To oldAttr.LayerData(L).ODBezier_DataStac.Count - 1
                    Dim d As clsAttrData.ODBezier_Data = oldAttr.LayerData(L).ODBezier_DataStac(i)
                    If ZahyoOk = True Then
                        Dim aD As Integer = R_Conv(L)(d.Data).Data
                        Dim aL As Integer = R_Conv(L)(d.Data).Layer
                        If aD <> -1 And aL <> -1 Then
                            Dim oldObj As String = oldAttr.Get_KenObjName(L, d.ObjectPos)
                            Dim newObj As Integer = newAttrData.Search_ObjName(aL, oldObj)
                            If aD <> -1 And aL <> -1 And newObj <> -1 Then
                                d.Data = aD
                                d.ObjectPos = newObj
                            End If
                            newAttrData.LayerData(aL).ODBezier_DataStac.Add(d)
                        End If
                    End If
                Next
            End If
        Next

        'ProgressLabel.SetValue newAttrData.TotalData.LV1.Lay_Maxn * 2 + 2

        '---------------------図形のデータ項目番号をチェック
        For i As Integer = 0 To oldAttr.TotalData.FigureStac.Count - 1
            Dim FigStac As Object = oldAttr.TotalData.FigureStac(i)
            Dim PrintData As clsAttrData.strFigure_data
            Select Case True
                Case TypeOf FigStac Is clsAttrData.strFig_Word_Data
                    Dim FigData As clsAttrData.strFig_Word_Data = DirectCast(FigStac, clsAttrData.strFig_Word_Data)
                    PrintData = FigData.Data
                Case TypeOf FigStac Is clsAttrData.strFig_Line_Data
                    Dim FigData As clsAttrData.strFig_Line_Data = DirectCast(FigStac, clsAttrData.strFig_Line_Data)
                    PrintData = FigData.Data
                Case TypeOf FigStac Is clsAttrData.strFig_Circle_data
                    Dim FigData As clsAttrData.strFig_Circle_data = DirectCast(FigStac, clsAttrData.strFig_Circle_data)
                    PrintData = FigData.Data
                Case TypeOf FigStac Is clsAttrData.strFig_Point_Data
                    Dim FigData As clsAttrData.strFig_Point_Data = DirectCast(FigStac, clsAttrData.strFig_Point_Data)
                    PrintData = FigData.Data
                Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                    Dim FigData As clsAttrData.strFig_gazo_data = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                    PrintData = FigData.Data
            End Select
            If ZahyoOk = True Then
                Dim dl As Integer = PrintData.Layer - 1
                Dim DD As Integer = PrintData.Data - 1
                Dim ddl As Integer = 0
                Dim ddd As Integer = 0
                If dl <> -1 Then
                    ddl = R_Layer_Convert(dl) + 1
                    If DD <> -1 Then
                        If DD = oldAttr.Get_DataNum(dl) + 1 Then
                            ddd = newAttrData.Get_DataNum(dl) + 1
                        Else
                            ddd = R_Conv(dl)(DD).Data + 1
                        End If
                    End If
                End If
                PrintData.Layer = ddl
                PrintData.Data = ddd
                Select Case True
                    Case TypeOf FigStac Is clsAttrData.strFig_Word_Data
                        Dim FigData As clsAttrData.strFig_Word_Data = DirectCast(FigStac, clsAttrData.strFig_Word_Data)
                        FigData.Data = PrintData
                        newAttrData.TotalData.FigureStac.Add(FigData)
                    Case TypeOf FigStac Is clsAttrData.strFig_Line_Data
                        Dim FigData As clsAttrData.strFig_Line_Data = DirectCast(FigStac, clsAttrData.strFig_Line_Data)
                        FigData.Data = PrintData
                        newAttrData.TotalData.FigureStac.Add(FigData)
                    Case TypeOf FigStac Is clsAttrData.strFig_Circle_data
                        Dim FigData As clsAttrData.strFig_Circle_data = DirectCast(FigStac, clsAttrData.strFig_Circle_data)
                        FigData.Data = PrintData
                        newAttrData.TotalData.FigureStac.Add(FigData)
                    Case TypeOf FigStac Is clsAttrData.strFig_Point_Data
                        Dim FigData As clsAttrData.strFig_Point_Data = DirectCast(FigStac, clsAttrData.strFig_Point_Data)
                        FigData.Data = PrintData
                        newAttrData.TotalData.FigureStac.Add(FigData)
                    Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                        Dim FigData As clsAttrData.strFig_gazo_data = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                        FigData.Data = PrintData
                        newAttrData.TotalData.FigureStac.Add(FigData)
                End Select
            End If
        Next

        '重ね合わせモードのデータをチェック
        With newAttrData.TotalData.TotalMode.OverLay
            .initDataSet()
            .Always_Overlay_Index = oldAttr.TotalData.TotalMode.OverLay.Always_Overlay_Index
            .SelectedIndex = oldAttr.TotalData.TotalMode.OverLay.SelectedIndex
            If oldAttr.TotalData.TotalMode.OverLay.DataSet.Count <> 0 Then
                .DataSet.Clear()
            End If
        End With
        For i As Integer = 0 To oldAttr.TotalData.TotalMode.OverLay.DataSet.Count - 1
            Dim OverDataset As clsAttrData.strOverLay_Dataset_Info
            With OverDataset
                .initData()
                .title = oldAttr.TotalData.TotalMode.OverLay.DataSet(i).title
                Dim f As Boolean
                For j As Integer = 0 To oldAttr.TotalData.TotalMode.OverLay.DataSet(i).DataItem.Count - 1
                    Dim overDt As clsAttrData.strOverLay_DataSet_Item_Info = oldAttr.TotalData.TotalMode.OverLay.DataSet(i).DataItem(j)
                    With overDt
                        f = False
                        Select Case .Print_Mode_Layer
                            Case enmLayerMode_Number.SoloMode
                                Dim aD As Integer = R_Conv(.Layer)(.DataNumber).Data
                                Dim aL As Integer = R_Conv(.Layer)(.DataNumber).Layer
                                If aD = -1 Or aL = -1 Then
                                    f = False
                                Else
                                    .DataNumber = aD
                                    .Layer = aL
                                    f = True
                                End If
                            Case enmLayerMode_Number.GraphMode, enmLayerMode_Number.LabelMode, enmLayerMode_Number.TripMode
                                Dim aL As Integer = R_Layer_Convert(.Layer)
                                If aL = -1 Then
                                    f = False
                                Else
                                    .Layer = aL
                                    f = True
                                End If
                        End Select
                    End With
                    If f = True Then
                        OverDataset.DataItem.Add(overDt)
                    End If
                Next
                .SelectedIndex = Math.Min(oldAttr.TotalData.TotalMode.OverLay.DataSet(i).SelectedIndex, .DataItem.Count - 1)
            End With
            newAttrData.TotalData.TotalMode.OverLay.DataSet.Add(OverDataset)
        Next
        newAttrData.TotalData.TotalMode.OverLay.SelectedIndex = oldAttr.TotalData.TotalMode.OverLay.SelectedIndex

        '連続表示モードのデータをチェック
        With newAttrData.TotalData.TotalMode.Series
            .initDataSet()
            If oldAttr.TotalData.TotalMode.Series.DataSet.Count <> 0 Then
                .DataSet.Clear()
            End If
            .SelectedIndex = oldAttr.TotalData.TotalMode.Series.SelectedIndex
        End With
        For i As Integer = 0 To oldAttr.TotalData.TotalMode.Series.DataSet.Count - 1
            Dim SeriesDataset As clsAttrData.strSeries_Dataset_Info
            SeriesDataset.initData()
            With SeriesDataset
                .initData()
                .title = oldAttr.TotalData.TotalMode.Series.DataSet(i).title
                For j As Integer = 0 To oldAttr.TotalData.TotalMode.Series.DataSet(i).DataItem.Count - 1
                    Dim seriesDt As clsAttrData.strSeries_DataSet_Item_Info = oldAttr.TotalData.TotalMode.Series.DataSet(i).DataItem(j)
                    Dim f As Boolean = False
                    With seriesDt
                        Select Case .Print_Mode_Total
                            Case enmTotalMode_Number.DataViewMode
                                Select Case .Print_Mode_Layer
                                    Case enmLayerMode_Number.SoloMode
                                        Dim aD As Integer = R_Conv(.Layer)(.Data).Data
                                        Dim aL As Integer = R_Conv(.Layer)(.Data).Layer
                                        If aD = -1 Or aL = -1 Then
                                            f = False
                                        Else
                                            .Data = aD
                                            .Layer = aL
                                            f = True
                                        End If
                                    Case enmLayerMode_Number.GraphMode, enmLayerMode_Number.LabelMode, enmLayerMode_Number.TripMode
                                        Dim aL As Integer = R_Layer_Convert(.Layer)
                                        If aL = -1 Then
                                            f = False
                                        Else
                                            .Layer = aL
                                            f = True
                                        End If
                                End Select
                            Case enmTotalMode_Number.OverLayMode
                        End Select
                    End With
                    If f = True Then
                        SeriesDataset.DataItem.Add(seriesDt)
                    End If
                Next
                .SelectedIndex = Math.Min(oldAttr.TotalData.TotalMode.Series.DataSet(i).SelectedIndex, .DataItem.Count - 1)
            End With
            newAttrData.TotalData.TotalMode.Series.DataSet.Add(SeriesDataset)
        Next
        newAttrData.TotalData.TotalMode.Series.SelectedIndex = oldAttr.TotalData.TotalMode.Series.SelectedIndex

        'ProgressLabel.SetValue TotalData.LV1.Lay_Maxn * 2 + 3
        '属性検索データをチェック
        newAttrData.TotalData.Condition = New List(Of clsAttrData.strCondition_DataSet_Info)
        For i As Integer = 0 To oldAttr.TotalData.Condition.Count - 1
            Dim oldL As Integer = oldAttr.TotalData.Condition(i).Layer
            Dim L As Integer = R_Layer_Convert(oldL)

            'レイヤが削除された場合は属性検索は削除
            If L <> -1 Then
                Dim conDataset As clsAttrData.strCondition_DataSet_Info
                With oldAttr.TotalData.Condition(i)
                    conDataset.Enabled = .Enabled
                    conDataset.Layer = L
                    conDataset.Name = .Name
                    conDataset.Condition_Class = New List(Of clsAttrData.strCondition_Data_Info)
                    For j As Integer = 0 To .Condition_Class.Count - 1
                        Dim dt As clsAttrData.strCondition_Data_Info
                        dt.And_OR = .Condition_Class(j).And_OR
                        dt.Condition = New List(Of clsAttrData.strCondition_Limitation_Info)
                        For k As Integer = 0 To .Condition_Class(j).Condition.Count - 1
                            Dim dtItem As clsAttrData.strCondition_Limitation_Info = .Condition_Class(j).Condition(k)
                            Dim D As Integer = R_Conv(oldL)(dtItem.Data).Data
                            If D <> -1 Then
                                dtItem.Data = D
                                dt.Condition.Add(dtItem)
                            End If
                        Next
                        'データが無くなった場合でも、コレクションは残す
                        conDataset.Condition_Class.Add(dt)
                    Next
                End With
                newAttrData.TotalData.Condition.Add(conDataset)
            End If
        Next

        '選択するデータ項目をチェックする
        For i As Integer = 0 To newAttrData.TotalData.LV1.Lay_Maxn - 1
            Dim L As Integer = Val(ktGrid.LayerData(i, GridLayerData.OldIndex))
            Dim d As Integer = 0
            If L = -1 Then
            Else
                d = R_Conv(L)(oldAttr.LayerData(L).atrData.SelectedIndex).Data
                If d = -1 Then
                    d = 0
                End If
            End If
            newAttrData.LayerData(i).atrData.SelectedIndex = d
        Next

        '選択するレイヤをチェックする
        Dim Layn As Integer = R_Layer_Convert(oldAttr.TotalData.LV1.SelectedLayer)
        If Layn = -1 Then
            newAttrData.TotalData.LV1.SelectedLayer = 0
        Else
            newAttrData.TotalData.LV1.SelectedLayer = Layn
        End If
        newAttrData.TotalData.LV1.Print_Mode_Total = oldAttr.TotalData.LV1.Print_Mode_Total

        'ProgressLabel.Visible = False


    End Sub
    ''' <summary>
    ''' 古いシンボル位置・ラベル位置で変更してあるものがあったら新しい箇所にコピーする
    ''' </summary>
    ''' <param name="NewL"></param>
    ''' <param name="OldL"></param>
    ''' <remarks></remarks>
    Private Sub Check_Kencode_XY(ByVal NewL As Integer, ByVal OldL As Integer)
        '
        Dim time As strYMD = newAttrData.LayerData(NewL).Time
        With newAttrData.LayerData(NewL)
            If .Type = clsAttrData.enmLayerType.Normal Then
                If .MapFileName <> oldAttr.LayerData(OldL).MapFileName Then
                    With .atrObject
                        For i As Integer = 0 To .ObjectNum - 1
                            With .atrObjectData(i)
                                newAttrData.LayerData(NewL).MapFileData.Get_Enable_CenterP(.CenterPoint, .MpObjCode, time)
                                .Symbol = .CenterPoint
                                .Label = .CenterPoint
                                .Visible = True
                            End With
                        Next
                    End With
                    Return
                End If
            End If
        End With

        Dim oldObjn As Integer = oldAttr.Get_ObjectNum(OldL)
        Dim sortoldObjName As New clsSortingSearch()
        sortoldObjName.AddInit(VariantType.String)
        For i As Integer = 0 To oldObjn - 1
            sortoldObjName.Add(oldAttr.Get_KenObjName(OldL, i))
        Next
        sortoldObjName.AddEnd()

        For i As Integer = 0 To newAttrData.Get_ObjectNum(NewL) - 1
            Dim objName As String = newAttrData.Get_KenObjName(NewL, i)
            Dim oldN As Integer = sortoldObjName.SearchData_One(objName)
            With newAttrData.LayerData(NewL).atrObject.atrObjectData(i)
                Select Case newAttrData.LayerData(NewL).Type
                    Case clsAttrData.enmLayerType.Normal
                        If oldN = -1 Or ZahyoOk = False Then
                            newAttrData.LayerData(NewL).MapFileData.Get_Enable_CenterP(.CenterPoint, .MpObjCode, time)
                            .Symbol = .CenterPoint
                            .Label = .CenterPoint
                            .Visible = True
                        Else
                            .CenterPoint = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).CenterPoint
                            .Symbol = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).Symbol
                            .Label = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).Label
                            .Visible = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).Visible
                        End If
                    Case clsAttrData.enmLayerType.Mesh
                        If oldN = -1 Or ZahyoOk = False Then
                        Else
                            .CenterPoint = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).CenterPoint
                            .Symbol = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).Symbol
                            .Label = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).Label
                            .MeshRect = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).MeshRect
                            .MeshPoint = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).MeshPoint.Clone
                            .Visible = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).Visible
                        End If

                    Case clsAttrData.enmLayerType.DefPoint
                        If oldN = -1 Or ZahyoOk = False Then
                        Else
                            If .defPoint.Equals(oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).defPoint) Then
                                .CenterPoint = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).CenterPoint
                                .Symbol = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).Symbol
                                .Label = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).Label
                                .Visible = oldAttr.LayerData(OldL).atrObject.atrObjectData(oldN).Visible
                            End If
                        End If
                End Select
            End With

        Next

    End Sub



    ''' <summary>
    ''' グリッド上のデータに対応する旧データを設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_Data_Refference() As List(Of Layer_Data_Info())

        Dim D_LayerNum = oldAttr.TotalData.LV1.Lay_Maxn

        Dim CheckedData As New List(Of Boolean())
        For i As Integer = 0 To D_LayerNum - 1
            Dim d(oldAttr.LayerData(i).atrData.Count - 1) As Boolean
            CheckedData.Add(d)
        Next

        Dim Conv As New List(Of Layer_Data_Info())
        For i As Integer = 0 To newAttrData.TotalData.LV1.Lay_Maxn - 1
            Dim datn As Integer = newAttrData.LayerData(i).atrData.Count
            Dim Dconv(datn - 1) As Layer_Data_Info
            Dim Dconv2(datn - 1) As Integer
            For j As Integer = 0 To newAttrData.LayerData(i).atrData.Count - 1
                Dconv(j) = Check_Data2(i, j, 1, CheckedData)
            Next
            Conv.Add(Dconv)
        Next
        For i As Integer = 0 To newAttrData.TotalData.LV1.Lay_Maxn - 1
            Dim Dconv() As Layer_Data_Info = Conv(i)
            For j As Integer = 0 To newAttrData.LayerData(i).atrData.Count - 1
                If Dconv(j).Layer = -1 Then
                    Dconv(j) = Check_Data2(i, j, 2, CheckedData)
                End If
            Next
            Conv(i) = Dconv
        Next

        Dim form As New frmGridDataRefference
        form.ShowDialog(Conv, newAttrData, oldAttr)
        Conv = form.getResult
        form.Dispose()
        Return Conv
    End Function
    ''' <summary>
    ''' 平均値・合計値などがグリッド上のデータと同じ旧データを探す
    ''' </summary>
    ''' <param name="D"></param>
    ''' <param name="L"></param>
    ''' <param name="CheckLevel">CheckLevelが1の場合は、同一名称・単位のデータ項目チェックのみ</param>
    ''' <param name="CheckedData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_Data2(ByVal L As Integer, ByVal D As Integer, ByVal CheckLevel As Integer,
                    ByRef CheckedData As List(Of Boolean())) As Layer_Data_Info
        '平均値・合計値などがグリッド上のデータと同じ旧データを探す
        '

        Dim CheckDataRet As Layer_Data_Info
        Dim G_DTA As clsAttrData.strData_info = newAttrData.LayerData(L).atrData.Data(D)


        Dim Old_Lay As Integer = CType(ktGrid.LayerData(L, GridLayerData.OldIndex), Integer)

        If Old_Lay = -1 Then
            CheckDataRet.Layer = -1
            CheckDataRet.Data = -1
            Return CheckDataRet
        End If

        '同一名称・単位のデータ項目をチェック
        Dim KouhoTitle As New List(Of Layer_Data_Info)
        For i As Integer = 0 To oldAttr.TotalData.LV1.Lay_Maxn - 1
            For j As Integer = 0 To oldAttr.LayerData(i).atrData.Count - 1
                Dim O_DTA As clsAttrData.strData_info = oldAttr.LayerData(i).atrData.Data(j)
                If O_DTA.Title = G_DTA.Title And O_DTA.Unit = G_DTA.Unit Then
                    Dim dt As Layer_Data_Info
                    dt.Layer = i
                    dt.Data = j
                    KouhoTitle.Add(dt)
                End If
            Next
        Next

        If KouhoTitle.Count >= 1 Then
            Dim j As Integer = 0
            Dim n As Integer = 0
            For i = 0 To KouhoTitle.Count - 1
                If Old_Lay = KouhoTitle(i).Layer Then
                    n = i
                    j += 1
                End If
            Next
            If j = 1 Then
                '過去同一レイヤだった候補が１つある場合は確定
                Dim BeL As Integer = KouhoTitle(n).Layer
                Dim BeD As Integer = KouhoTitle(n).Data
                CheckDataRet.Layer = BeL
                CheckDataRet.Data = BeD
                Dim dt() As Boolean = CheckedData(BeL)
                dt(BeD) = True
                CheckedData(BeL) = dt
                Return CheckDataRet
            End If
        End If
        If CheckLevel = 1 Then
            CheckDataRet.Layer = -1
            CheckDataRet.Data = -1
            Return CheckDataRet
        End If

        Dim Data_Prop_Value As Double = Get_Data_Property_Value(newAttrData, L, D)

        Dim Kouho As New List(Of Layer_Data_InfoCheck)
        Dim Sort_KouhoV As New clsSortingSearch

        For i As Integer = 0 To oldAttr.TotalData.LV1.Lay_Maxn - 1
            For j As Integer = 0 To oldAttr.LayerData(i).atrData.Count - 1

                Dim O_DTA As clsAttrData.strData_info = oldAttr.LayerData(i).atrData.Data(j)
                If O_DTA.DataType = G_DTA.DataType Then
                    Dim OV As Double = D_CheckDataValue(i)(j)
                    Dim GV As Double = Data_Prop_Value
                    If GV = 0 Then
                        GV += 1
                        OV += 1
                    End If
                    Dim av As Double = Math.Abs(OV / GV - 1)
                    If av <= 0.3 Then
                        Dim dt As Layer_Data_InfoCheck
                        With dt
                            .Layer = i 'レイヤ
                            .Data = j 'データ項目
                            .Value = av
                        End With
                        Kouho.Add(dt)
                    End If
                End If
            Next
        Next i
        Dim BL As Integer
        Dim BD As Integer
        Select Case Kouho.Count
            Case 0
                BL = -1
                BD = -1
            Case 1
                BL = Kouho(0).Layer
                BD = Kouho(0).Data
            Case Else
                BD = -1
                BL = -1
                Dim i2 As Integer = 0
                With Sort_KouhoV
                    .AddInit(vbDouble)
                    For i As Integer = 0 To Kouho.Count - 1
                        .Add(Kouho(i).Value)
                    Next
                    .AddEnd()
                    Do
                        i2 += 1
                        If i2 = Kouho.Count Then
                            Exit Do
                        End If
                    Loop Until .DataPositionValue_Double(i2) <> .DataPositionValue_Double(0)
                End With

                If i2 = 1 Then
                    With Kouho(Sort_KouhoV.DataPosition(0))
                        BL = .Layer
                        BD = .Data
                    End With
                Else
                    For j As Integer = 0 To i2 - 1
                        Dim O_DTA As clsAttrData.strData_info = oldAttr.LayerData(Kouho(j).Layer).atrData.Data(Kouho(j).Data)
                        If O_DTA.Title = G_DTA.Title And O_DTA.Unit = G_DTA.Unit Then
                            BL = Kouho(j).Layer
                            BD = Kouho(j).Data
                            Exit For
                        End If
                    Next
                    If BD = -1 Then
                        With Kouho(Sort_KouhoV.DataPosition(0))
                            BL = .Layer
                            BD = .Data
                        End With
                    End If
                End If
        End Select
        Sort_KouhoV = Nothing
        If BL <> -1 Then
            If CheckedData(BL)(BD) = True Then
                BD = -1
                BL = -1
            Else
                Dim dt() As Boolean = CheckedData(BL)
                dt(BD) = True
                CheckedData(BL) = dt
            End If
        End If
        CheckDataRet.Layer = BL
        CheckDataRet.Data = BD
        Return CheckDataRet
    End Function
    Private Sub Reset_SCRView_Size()

        newAttrData.Check_Vector_Object()

        'ダミー点オブジェクトの記号
        newAttrData.initDummuyPointObjectMark()
        With newAttrData.TotalData.ViewStyle
            Dim oldDummy As Dictionary(Of String, clsAttrData.strDummyObjectPointMark_Info()) = oldAttr.TotalData.ViewStyle.DummyObjectPointMark
            If .DummyObjectPointMark.Count > 0 Then
                Dim newMapfile() As String = newAttrData.GetMapFileName
                Dim oldMapfile() As String = oldAttr.GetMapFileName
                For i As Integer = 0 To newMapfile.Count - 1
                    Dim n As Integer = Array.IndexOf(oldMapfile, newMapfile(i))
                    If n <> -1 Then
                        If .DummyObjectPointMark.ContainsKey(newMapfile(i)) = True Then
                            Dim d() As clsAttrData.strDummyObjectPointMark_Info = .DummyObjectPointMark(newMapfile(i))
                            For j As Integer = 0 To d.Length - 1
                                With d(j)
                                    .ObjectKindName = oldDummy(newMapfile(i))(j).ObjectKindName
                                    .Mark = oldDummy(newMapfile(i))(j).Mark
                                End With
                            Next
                            .DummyObjectPointMark(newMapfile(i)) = d
                        End If
                    End If
                Next
            End If
        End With

        With newAttrData.TotalData.BasePicture
            .PictureNum = oldAttr.TotalData.BasePicture.PictureNum
            .PictureData = oldAttr.TotalData.BasePicture.PictureData
        End With
        Dim TTS As Screen_info = oldAttr.TotalData.ViewStyle.ScrData
        If TTS.MapRectangle.Equals(newAttrData.TotalData.ViewStyle.ScrData.MapRectangle) = True Then
            newAttrData.TotalData.ViewStyle.ScrData = TTS
            '地図領域が同じ場合はここまで
            Return
        End If

        If ZahyoOk = False Then
            newAttrData.TotalData.ViewStyle.ScrData.ScrView = newAttrData.TotalData.ViewStyle.ScrData.MapRectangle
        Else
            With newAttrData.TotalData.ViewStyle.ScrData
                Dim O_SCRView As RectangleF = oldAttr.TotalData.ViewStyle.ScrData.ScrView
                Dim OP1 As PointF = O_SCRView.Location
                Dim OP2 As PointF = New PointF(O_SCRView.Right, O_SCRView.Bottom)
                With .ScrView
                    If OP1.X < .Left Then
                        OP1.X = .Left
                    End If
                    If OP2.X > .Right Then
                        OP2.X = .Right
                    End If
                    If OP1.Y < .Top Then
                        OP1.Y = .Top
                    End If
                    If OP2.Y > .Bottom Then
                        OP2.Y = .Bottom
                    End If
                    If OP2.X - OP1.X <= 0 Then
                        OP2.X = .Right
                        OP1.X = .Left
                    End If
                    If OP2.Y - OP1.Y <= 0 Then
                        OP1.Y = .Top
                        OP2.Y = .Bottom
                    End If
                End With
                .ScrView = RectangleF.FromLTRB(OP1.X, OP1.Y, OP2.X, OP2.Y)
            End With

            If newAttrData.TotalData.ViewStyle.ScrData.Accessory_Base = enmBasePosition.Map Then
                Dim WAKU As RectangleF
                Dim MapRect As RectangleF
                Dim sz As SizeF
                With newAttrData.TotalData.ViewStyle.ScrData
                    MapRect = .MapRectangle
                    WAKU = .MapRectangle
                    sz = .MapRectangle.Size
                    WAKU.Inflate(sz.Width * 0.1, sz.Height * 0.1)
                End With

                With newAttrData.TotalData.ViewStyle.MapLegend.Base
                    For i As Integer = 0 To .Legend_Num - 1
                        If .LegendXY(i).X < WAKU.Left Or .LegendXY(i).X > WAKU.Right Or
                            .LegendXY(i).Y < WAKU.Top Or .LegendXY(i).Y > WAKU.Bottom Then
                            .LegendXY(i).X = MapRect.Right + (1 - i) * WAKU.Width / 50
                            .LegendXY(i).Y = (MapRect.Top + MapRect.Bottom) / 2 + (1 - i) * sz.Height / 50 ' + wy2) / 2 + (1 - i) * h / 50
                        End If
                    Next
                End With
                With newAttrData.TotalData.ViewStyle.MapTitle.Position
                    If .X < WAKU.Left Or .X > WAKU.Right Or
                        .Y < WAKU.Top Or .Y > WAKU.Bottom Then
                        .X = (MapRect.Left + MapRect.Right) / 2
                        .Y = MapRect.Bottom + sz.Height / 20
                    End If
                End With
                With newAttrData.TotalData.ViewStyle.MapScale.Position
                    If .X < WAKU.Left Or .X > WAKU.Right Or
                        .Y < WAKU.Top Or .Y > WAKU.Bottom Then
                        .X = MapRect.Left + sz.Width * 4 / 5
                        .Y = MapRect.Bottom + sz.Height / 30
                    End If
                End With
                With newAttrData.TotalData.ViewStyle.AttMapCompass.Position
                    If .X < WAKU.Left Or .X > WAKU.Right Or
                        .Y < WAKU.Top Or .Y > WAKU.Bottom Then
                        If .X >= MapRect.Right + sz.Width * 0.3 Then .X = MapRect.Right - sz.Width * 0.1
                        If .X <= MapRect.Left - sz.Width * 0.3 Then .X = MapRect.Left + sz.Width * 0.1
                        If .Y >= MapRect.Bottom + sz.Height * 0.3 Then .Y = MapRect.Bottom - sz.Height * 0.1
                        If .Y <= MapRect.Top - sz.Height * 0.3 Then .Y = MapRect.Top + sz.Height * 0.1
                    End If
                End With
            End If
        End If

    End Sub
    ''' <summary>
    ''' 'グリッド上のデータを取得
    ''' </summary>
    ''' <remarks></remarks>
    Private Function Get_E_Data(ByRef emes As String)

        Dim L As Integer = ktGrid.LayerMax
        newAttrData.TotalData.LV1.Lay_Maxn = 0

        For i As Integer = 0 To L - 1
            Dim LayYMax As Integer = ktGrid.Ysize(i)
            Dim LayXMax As Integer = ktGrid.Xsize(i)
            Dim YChange(LayYMax - 1) As Integer
            Dim LayYMaxReal As Integer = 0
            For j As Integer = 0 To LayYMax - 1
                If ktGrid.FixedXSData(i, 1, j) = "" Then
                    YChange(j) = -1
                Else
                    YChange(j) = LayYMaxReal
                    LayYMaxReal += 1
                End If
            Next
            Dim LType As clsAttrData.enmLayerType = CType(ktGrid.LayerData(i, GridLayerData.Type), clsAttrData.enmLayerType)
            Dim LSP As enmShape = CType(ktGrid.LayerData(i, GridLayerData.Shape), enmShape)
            Dim Lmesh As enmMesh_Number = CType(ktGrid.LayerData(i, GridLayerData.Mesh), enmMesh_Number)
            Dim Lmapfile As String = CType(ktGrid.LayerData(i, GridLayerData.MapFile), String)
            Dim LTime As strYMD = CType(ktGrid.LayerData(i, GridLayerData.Time), strYMD)
            Dim OldLay As Integer = CType(ktGrid.LayerData(i, GridLayerData.OldIndex), Integer)
            Dim SyntheticObjF As Boolean = CType(ktGrid.LayerData(i, GridLayerData.SyntheticObjF), Boolean)
            Dim RefSystem As enmZahyo_System_Info = CType(ktGrid.LayerData(i, GridLayerData.ReferenceSystem), enmZahyo_System_Info)
            Dim LayComment As String = CType(ktGrid.LayerData(i, GridLayerData.Comment), String)

            Dim Get_Obj(LayYMaxReal - 1) As clsAttrData.strObject_Data_Info
            Dim GetTripObj() As clsAttrData.strTripObjData_Info
            Dim GetTripDefinitionName() As String
            Select Case LType
                Case clsAttrData.enmLayerType.Trip
                    ReDim GetTripObj(LayYMaxReal - 1)
                Case clsAttrData.enmLayerType.Trip_Definition
                    ReDim GetTripDefinitionName(LayYMaxReal - 1)
                Case Else
                    ReDim Get_Obj(LayYMaxReal - 1)
            End Select

            If SyntheticObjF = True Then
                '時系列集計したレイヤの場合は，変更前のオブジェクトコード・合成オブジェクトデータを設定する

                For j As Integer = 0 To oldAttr.LayerData(OldLay).atrObject.ObjectNum - 1
                    With Get_Obj(j)
                        .Objectstructure = oldAttr.LayerData(OldLay).atrObject.atrObjectData(j).Objectstructure
                        .MpObjCode = oldAttr.LayerData(OldLay).atrObject.atrObjectData(j).MpObjCode
                        .Name = oldAttr.LayerData(OldLay).atrObject.atrObjectData(j).Name
                    End With

                Next
            Else
                For j As Integer = 0 To LayYMax - 1
                    If YChange(j) <> -1 Then
                        Dim tx As String = ktGrid.FixedXSData(i, 1, j)
                        Dim UseMap As clsMapData = newAttrData.SetMapFile(Lmapfile)
                        Select Case LType
                            Case clsAttrData.enmLayerType.Trip_Definition
                                GetTripDefinitionName(YChange(j)) = tx

                            Case clsAttrData.enmLayerType.Trip
                                With GetTripObj(YChange(j))
                                    .TripPersonName = tx
                                End With
                            Case clsAttrData.enmLayerType.Mesh
                                With Get_Obj(YChange(j))
                                    .Objectstructure = enmKenCodeObjectstructure.MapObj
                                    .Name = tx
                                    .MpObjCode = -2
                                End With
                            Case clsAttrData.enmLayerType.Normal
                                With Get_Obj(YChange(j))
                                    .Objectstructure = enmKenCodeObjectstructure.MapObj
                                    .Name = tx
                                    .MpObjCode = newAttrData.Get_ObjectCode_from_ObjName(Lmapfile, tx, LTime)
                                    UseMap.Get_Enable_CenterP(.CenterPoint, .MpObjCode, LTime)
                                    .Symbol = .CenterPoint
                                    .Label = .CenterPoint
                                End With
                            Case clsAttrData.enmLayerType.DefPoint
                                With Get_Obj(YChange(j))
                                    .Objectstructure = enmKenCodeObjectstructure.MapObj
                                    .Name = tx
                                End With
                        End Select
                    End If
                Next
            End If
            Select Case LType
                Case clsAttrData.enmLayerType.Trip_Definition
                    newAttrData.Add_one_Layer(ktGrid.LayerName(i), LayComment, LayYMaxReal, GetTripDefinitionName)
                Case clsAttrData.enmLayerType.Trip
                    newAttrData.Add_one_Layer(ktGrid.LayerName(i), Lmapfile, LTime, RefSystem, LayComment, LayYMaxReal, GetTripObj)
                Case Else
                    newAttrData.Add_one_Layer(ktGrid.LayerName(i), LType, Lmesh, LSP, Lmapfile, LTime, RefSystem, LayComment, LayYMaxReal, Get_Obj)
            End Select

            With newAttrData.LayerData(i)
                .Type = LType
                If SyntheticObjF = True Then
                    Dim n As Integer = oldAttr.LayerData(OldLay).atrObject.NumOfSyntheticObj
                    .atrObject.NumOfSyntheticObj = n
                    If n > 0 Then
                        ReDim .atrObject.MPSyntheticObj(.atrObject.NumOfSyntheticObj - 1)
                    End If
                    For j As Integer = 0 To n - 1
                        .atrObject.MPSyntheticObj(j) = oldAttr.LayerData(OldLay).atrObject.MPSyntheticObj(j)
                    Next
                    .Shape = oldAttr.LayerData(OldLay).Shape
                Else
                    If LSP = enmShape.NotDeffinition Then
                        .Shape = newAttrData.Check_LayerShape_Sub(i, "")
                    Else
                        .Shape = LSP
                    End If
                End If
                Dim DN_Str(LayXMax - 1, LayYMax - 1) As String
                Dim TTL(LayXMax - 1) As String
                Dim UNT(LayXMax - 1) As String
                Dim Mis(LayXMax - 1) As Boolean
                Dim Note(LayXMax - 1) As String
                ReDim UNT(LayXMax - 1)
                ReDim TTL(LayXMax - 1)
                ReDim DN_Str(LayXMax - 1, LayYMaxReal - 1)
                For j As Integer = 0 To LayXMax - 1
                    TTL(j) = ktGrid.FixedYSData(i, j, 3)
                    UNT(j) = ktGrid.FixedYSData(i, j, 4)
                    Mis(j) = clsGeneric.ConvertMissingValueBoolString(ktGrid.FixedYSData(i, j, 2))
                    Note(j) = ktGrid.FixedYSData(i, j, 5)
                Next
                For j As Integer = 0 To LayYMax - 1
                    If YChange(j) <> -1 Then
                        For k As Integer = 0 To LayXMax - 1
                            DN_Str(k, YChange(j)) = ktGrid.GridData(i, k, j)
                        Next
                    End If
                Next
                Dim getf As Boolean = newAttrData.Set_STRData_To_Cell(i, LayXMax, TTL, UNT, Mis, Note, DN_Str, emes)
                If getf = False Then
                    Return False
                End If
                Select Case .Type
                    Case clsAttrData.enmLayerType.Normal, clsAttrData.enmLayerType.Mesh, clsAttrData.enmLayerType.DefPoint
                        .LayerModeViewSettings.GraphMode.initDataSet()
                        .LayerModeViewSettings.LabelMode.initDataSet()
                End Select

            End With
        Next
        Return True
    End Function
    Public Function getResult() As clsAttrData
        Return newAttrData
    End Function
    Private Sub frmGrid_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub cboMesh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMesh.SelectedIndexChanged
        With ktGrid
            .LayerData(.Layer, GridLayerData.Mesh) = clsGeneric.ConvertMeshTypeEnumString(cboMesh.Text)
        End With
        ErrorCheck()
    End Sub

    Private Sub cboLayerShape_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayerShape.SelectedIndexChanged
        With ktGrid
            .LayerData(.Layer, GridLayerData.Shape) = clsGeneric.ConvertShapeEnumString(cboLayerShape.Text)
        End With
        ErrorCheck()
    End Sub

    Private Sub btnReplaceMapFile_Click(sender As Object, e As EventArgs) Handles btnReplaceMapFile.Click
        Dim sel As Integer = lbMapFile.SelectedIndex
        If sel = -1 Then
            MsgBox("地図ファイルを選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim repFname As String = lbMapFile.SelectedItem.ToString

        For i As Integer = 0 To ktGrid.LayerMax - 1
            Dim synf As Boolean = CType(ktGrid.LayerData(i, GridLayerData.SyntheticObjF), Boolean)
            If synf = True And ktGrid.LayerData(i, GridLayerData.MapFile).ToString = repFname Then
                MsgBox("時系列集計されたレイヤで使われているので、差し替えできません。", MsgBoxStyle.Exclamation)
                Return
            End If
        Next


        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = clsGeneric.Get_MapFolder
        ofd.Filter = "MANDARA地図ファイル(*.mpf?)|*.mpf?|圧縮地図ファイル(*.mpfz)|*.mpfz|非圧縮ファイル(*.mpfx)|*.mpfx|旧地図ファイル(*.mpf)|*.mpf"
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim fname As String = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName)
            If newAttrData.GetNumOfMapFile > 0 Then
                Dim mfile As String() = newAttrData.GetMapFileName
                If Array.IndexOf(mfile, fname.ToUpper) <> -1 Then
                    MsgBox(fname + "は既に読み込まれています。", MsgBoxStyle.Exclamation)
                    Return
                End If
            End If
            Dim mData As clsMapData
            Try
                Cursor.Current = Cursors.WaitCursor
                mData = New clsMapData(ofd.FileName)
            Catch ex As Exception
                MsgBox(ex.Message)
                Return
            Finally
                Cursor.Current = Cursors.Default
            End Try
            newAttrData.RemoveMapData(repFname)
            If newAttrData.GetNumOfMapFile > 0 Then
                Dim z As clsMapData.Zahyo_info = newAttrData.SetMapFile("").Map.Zahyo
                Dim emes As String
                If spatial.Check_Zahyo_Projection_Convert_Enabled(z, mData.Map.Zahyo, emes) = False Then
                    MsgBox(emes, MsgBoxStyle.Exclamation)
                    Return
                End If

            End If
            newAttrData.AddExistingMapData(mData, fname)
            lbMapFile.Items.RemoveAt(sel)
            lbMapFile.Items.Add(fname)
            cboLayerMapFile.Items.RemoveAt(sel)
            cboLayerMapFile.Items.Add(fname)
            For i As Integer = 0 To ktGrid.LayerMax - 1
                Dim oldFname As String = ktGrid.LayerData(i, GridLayerData.MapFile).ToString
                If oldFname = repFname Then
                    ktGrid.LayerData(i, GridLayerData.MapFile) = fname
                    Dim LTime As strYMD = CType(ktGrid.LayerData(i, GridLayerData.Time), strYMD)
                    If newAttrData.SetMapFile(fname).Map.Time_Mode = True And LTime.nullFlag = True Then
                        ktGrid.LayerData(i, GridLayerData.Time) = clsTime.GetYMD(Date.Today)
                    ElseIf newAttrData.SetMapFile(fname).Map.Time_Mode = False And LTime.nullFlag = False Then
                        ktGrid.LayerData(i, GridLayerData.Time) = clsTime.GetNullYMD
                    End If
                End If
            Next
            Set_LayerTypeShape()

            ErrorCheck()
        End If

    End Sub




    Private Sub DateTimePickerLayer_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerLayer.ValueChanged
        ktGrid.LayerData(ktGrid.Layer, GridLayerData.Time) = clsTime.GetYMD(DateTimePickerLayer.Value)
        ErrorCheck()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchSTR = InputBox("検索文字列", , SearchSTR)
        If SearchSTR <> "" Then

            ktGrid.Find(SearchSTR, KTGISUserControl.KTGISGrid.enmMatchingMode.PartialtMatching)
        End If
    End Sub

    Private Sub btnBefore_Click(sender As Object, e As EventArgs) Handles btnBefore.Click
        ktGrid.FindRev(SearchSTR, KTGISUserControl.KTGISGrid.enmMatchingMode.PartialtMatching)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ktGrid.Find(SearchSTR, KTGISUserControl.KTGISGrid.enmMatchingMode.PartialtMatching)
    End Sub

    Private Sub txtLayerComment_Leave(sender As Object, e As EventArgs) Handles txtLayerComment.Leave
        ktGrid.LayerData(ktGrid.Layer, GridLayerData.Comment) = txtLayerComment.Text
    End Sub

    Private Sub btnGPX_Click(sender As Object, e As EventArgs) Handles btnGPX.Click
        Dim form As New frmGridGPX
        If form.ShowDialog() = Windows.Forms.DialogResult.OK Then


            Dim LayerName As String
            Dim SubName As String
            Dim ElevationF As Boolean
            Dim TimeIntervalF As Integer
            Dim DistanceIntervalF As Boolean
            Dim SpeedF As Boolean
            Dim ElevationN As Integer
            Dim TimeIntervalN As Integer
            Dim DistanceIntervalN As Integer
            Dim SpeedN As Integer
            Dim GPXData As List(Of clsGPX.GPX_Info) = form.GetResults(LayerName, SubName, ElevationF, TimeIntervalF, DistanceIntervalF, SpeedF)
            Dim n As Integer = 4
            If ElevationF = True Then
                ElevationN = n
                n += 1
            End If
            If TimeIntervalF = True Then
                TimeIntervalN = n
                n += 1
            End If
            If DistanceIntervalF = True Then
                DistanceIntervalN = n
                n += 1
            End If
            If SpeedF = True Then
                SpeedN = n
                n += 1
            End If
            Dim ip As Integer = ktGrid.LayerMax
            With ktGrid
                .AddLayer(LayerName, ip, n, GPXData.Count, True, True, True, True, True, True, True, False)
                .FixedYSData(ip, 0, 3) = "LON"
                .FixedYSData(ip, 1, 3) = "LAT"
                .FixedYSData(ip, 2, 3) = "ARRIVAL"
                .FixedYSData(ip, 3, 3) = "DEPARTURE"
                If ElevationF = True Then
                    .FixedYSData(ip, ElevationN, 3) = "GPS標高"
                    .FixedYSData(ip, ElevationN, 4) = "m"
                End If
                If TimeIntervalF = True Then
                    .FixedYSData(ip, TimeIntervalN, 3) = "時間間隔"
                    .FixedYSData(ip, TimeIntervalN, 4) = "秒"
                End If
                If DistanceIntervalF = True Then
                    .FixedYSData(ip, DistanceIntervalN, 3) = "距離間隔"
                    .FixedYSData(ip, DistanceIntervalN, 4) = "km"
                End If
                If SpeedF = True Then
                    .FixedYSData(ip, SpeedN, 3) = "速度"
                    .FixedYSData(ip, SpeedN, 4) = "km/h"
                End If
                Dim ogp As clsGPX.GPX_Info
                For i As Integer = 0 To GPXData.Count - 1
                    Dim gp As clsGPX.GPX_Info = CType(GPXData(i), clsGPX.GPX_Info)
                    .GridData(ip, 0, i) = clsGeneric.SingleToString(gp.Position.Longitude)
                    .GridData(ip, 1, i) = clsGeneric.SingleToString(gp.Position.Latitude)
                    .GridData(ip, 2, i) = gp.Time.ToString("yyyyMMddHHmmss")
                    .GridData(ip, 3, i) = gp.Time.ToString("yyyyMMddHHmmss")
                    .FixedXSData(ip, 1, i) = SubName
                    If ElevationF = True Then
                        .GridData(ip, ElevationN, i) = gp.Elevation
                    End If
                    If i <> 0 Then
                        If TimeIntervalF = True Then
                            Dim T As TimeSpan = gp.Time - ogp.Time
                            .GridData(ip, TimeIntervalN, i) = T.TotalSeconds
                        End If
                        If DistanceIntervalF = True Then
                            Dim T As TimeSpan = gp.Time - ogp.Time
                            Dim d As Single = spatial.Distance_Ido_Kedo(gp.Position.Latitude, gp.Position.Longitude, ogp.Position.Latitude, ogp.Position.Longitude)
                            .GridData(ip, DistanceIntervalN, i) = d
                        End If
                        If SpeedF = True Then
                            Dim T As TimeSpan = gp.Time - ogp.Time
                            Dim d As Single = spatial.Distance_Ido_Kedo(gp.Position.Latitude, gp.Position.Longitude, ogp.Position.Latitude, ogp.Position.Longitude)
                            .GridData(ip, SpeedN, i) = CSng(d / T.TotalHours)
                        End If
                    End If
                    ogp = gp
                Next
                clsGeneric.Check_DataKind_and_Allignment(ktGrid, ip, clsAttrData.enmLayerType.Trip)
                .LayerData(ip, GridLayerData.MapFile) = lbMapFile.Items(0)
                .LayerData(ip, GridLayerData.Shape) = enmShape.NotDeffinition
                Dim sday As clsGPX.GPX_Info = CType(GPXData(0), clsGPX.GPX_Info)
                .LayerData(ip, GridLayerData.Time) = clsTime.GetYMD(sday.Time.Year, sday.Time.Month, sday.Time.Day)
                .LayerData(ip, GridLayerData.OldIndex) = -1
                .LayerData(ip, GridLayerData.Type) = clsAttrData.enmLayerType.Trip
                .LayerData(ip, GridLayerData.Mesh) = enmMesh_Number.mhNonMesh
                .LayerData(ip, GridLayerData.SyntheticObjF) = False
                .LayerData(ip, GridLayerData.ReferenceSystem) = enmZahyo_System_Info.Zahyo_System_World
                .LayerData(ip, GridLayerData.Comment) = LayerName + "から取得したGPSデータより作成"
                clsGeneric.Set_First_GridCellWidthHeight(ktGrid, ip)
            End With
            MsgBox(LayerName + "レイヤを追加しました。")
            ktGrid.Layer = ip
            ktGrid.Refresh()

        End If
    End Sub

    Private Sub rbWorld_CheckedChanged(sender As Object, e As EventArgs) Handles rbWorld.CheckedChanged, rbTokyo.CheckedChanged
        With ktGrid
            If rbTokyo.Checked = True Then
                .LayerData(.Layer, GridLayerData.ReferenceSystem) = enmZahyo_System_Info.Zahyo_System_tokyo
            Else
                .LayerData(.Layer, GridLayerData.ReferenceSystem) = enmZahyo_System_Info.Zahyo_System_World
            End If
        End With
    End Sub


    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        clsGeneric.HelpShow(enmHelpFile.PropertyData, "propertyEditorWindows", Me)
    End Sub

    Private Sub btnAddDefAttr_Click(sender As Object, e As EventArgs) Handles btnAddDefAttr.Click
        Dim form As New frmGridAddDefData
        If form.ShowDialog(newAttrData, ktGrid, GridLayerData) = Windows.Forms.DialogResult.OK Then
            Dim fydataV(,) As String
            Dim DataV(,) As String
            Dim LayMapfile As String
            Dim LayTime As strYMD
            Dim LayName As String
            Dim shp As enmShape
            Dim preLayerF As Boolean = form.GetResults(fydataV, DataV, LayMapfile, LayName, LayTime, shp)
            Dim xs As Integer = fydataV.GetLength(0)
            Dim ys As Integer = DataV.GetLength(1)
            Dim layer As Integer
            If preLayerF = True Then
                layer = ktGrid.Layer
                Dim insertP As Integer = ktGrid.Xsize(layer)
                ktGrid.AddDataItem(layer, insertP, xs)
                For i As Integer = 0 To xs - 1
                    For j As Integer = 0 To 3
                        ktGrid.FixedYSData(layer, i + insertP, j + 2) = fydataV(i, j)
                    Next
                Next
                For i As Integer = 0 To xs - 1
                    For j As Integer = 0 To ys - 1
                        ktGrid.GridData(layer, i + insertP, j) = DataV(i, j)
                    Next
                Next
            Else
                layer = ktGrid.LayerMax
                ktGrid.AddLayer(LayName, ktGrid.LayerMax, xs, ys,
                                        True, True, True, True, True, True, True, False)
                For i As Integer = 0 To xs - 1
                    For j As Integer = 0 To 3
                        ktGrid.FixedYSData(layer, i, j + 2) = fydataV(i, j)
                    Next
                Next
                For i As Integer = 0 To ys - 1
                    ktGrid.FixedXSData(layer, 1, i) = DataV(0, i)
                    For j As Integer = 1 To xs
                        ktGrid.GridData(layer, j - 1, i) = DataV(j, i)
                    Next
                Next
                ktGrid.LayerData(layer, GridLayerData.MapFile) = LayMapfile
                ktGrid.LayerData(layer, GridLayerData.Shape) = shp
                ktGrid.LayerData(layer, GridLayerData.Time) = LayTime
                ktGrid.LayerData(layer, GridLayerData.OldIndex) = -1
                ktGrid.LayerData(layer, GridLayerData.Type) = clsAttrData.enmLayerType.Normal
                ktGrid.LayerData(layer, GridLayerData.Mesh) = enmMesh_Number.mhNonMesh
                ktGrid.LayerData(layer, GridLayerData.SyntheticObjF) = False
                ktGrid.LayerData(layer, GridLayerData.ReferenceSystem) = enmZahyo_System_Info.Zahyo_System_World
                ktGrid.LayerData(layer, GridLayerData.Comment) = LayMapfile & "の初期属性データから作成"
                clsGeneric.Set_First_GridCellWidthHeight(ktGrid, layer)
                ktGrid.Layer = layer
            End If
            Check_DataKind(layer)
            ktGrid.Refresh()
            ErrorCheck()
        End If
        form.Dispose()
    End Sub


    Private Sub SplitContainerUpper_Resize(sender As Object, e As EventArgs) Handles SplitContainerUpper.Resize, SplitContainerUpper.SplitterMoved
        '本来は不要だが、文字のサイズが100%より大きいと、RIGHT,BOTTOMのアンカーがきかなくなるため設定
        btnHelp.Top = 7
        btnHelp.Left = btnHelp.Parent.Width - btnHelp.Width - 10
        lbError.Width = lbError.Parent.Width - lbError.Left * 2
        lbError.Height = lbError.Parent.Height - lbError.Top - 10
    End Sub
End Class