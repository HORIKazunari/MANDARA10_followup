Public Class clsMED_Undo
    ''' <summary>
    ''' 全データの待避
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure Undo_AllMapData
        Public Caption As String
        Public MapData As clsMapData
        Public EditOBJKList() As Boolean
        Public EditLKList() As Boolean
    End Structure
    Private Structure Undo_Replace_ITRF94_Tokyo97
        Public Caption As String
    End Structure
    Private Structure Undo_ZahyoConvert
        '座標変換
        Public Caption As String
        Public AllObjects() As Undo_ZahyoConvert_Obj
        Public AllLines() As Undo_ZahyoConvert_Line
        Public mapZahyo As clsMapData.strMap_data
    End Structure
    Private Structure Undo_ZahyoConvert_Obj
        Public CenterP() As PointF
        Public cirrect As RectangleF
    End Structure
    Public Structure Undo_ZahyoConvert_Line
        Public LinePoint() As PointF
        Public cirrect As RectangleF
    End Structure
    Public Structure Undo_SmoothingLine
        'ポイントループ間引き
        Public Caption As String
        Public AllObjects() As clsMapData.strObj_Data
        Public AllLines() As clsMapData.strLine_Data
        Public mapRect As RectangleF
    End Structure
    Public Structure Undo_CombineSameObjectName
        ' 同一オブジェクト名のオブジェクトの結合/時間情報の一括設定
        Public Caption As String
        Public AllObjects() As clsMapData.strObj_Data
    End Structure
    Public Structure Undo_ReplaceObjectName
        'オブジェクト名置換
        Public Caption As String
        Public OriginObjName As List(Of clsMapData.Object_NameTimeStac_Data())
    End Structure

    Private Structure Undo_SettingCompass
        '方位設定
        Public Caption As String
        Public Compass As clsMapData.strCompass_Attri
    End Structure
    Private Structure Undo_SettingLineKind
        '線種設定のUndo情報
        Public Caption As String
        Public ObjKind() As clsMapData.strObjectGroup_Data
        Public LKind() As clsMapData.LineKind_Data
        Public MpLineKind As ArrayList
        Public EditList() As Boolean
    End Structure
    Private Structure Undo_SettingObjectGroup
        'オブジェクトグループ設定のUndo情報
        Public Caption As String
        Public ObjKind() As clsMapData.strObjectGroup_Data
        Public LKind() As clsMapData.LineKind_Data
        Public MpObjKind() As Integer
        Public EditList() As Boolean
    End Structure
    Private Structure Undo_EditingDefAttData
        '初期属性データ編集のUndo情報
        Public Caption As String
        Public ObjKind() As clsMapData.strObjectGroup_Data
        Public ObjDefAttData As List(Of clsMapData.strDefTimeAttData_Info()) '初期属性の文字列配列のコレクション
    End Structure

    Private Structure Undo_Object_andLine_Drag
        'オブジェクトをラインごとドラッグした場合のUndo情報
        Public Caption As String
        Public KenD As Integer
        Public Objects() As clsMapData.strObj_Data
        Public Lines() As clsMapData.strLine_Data
        Public mapRect As RectangleF
    End Structure
    Private Structure Undo_RegistObject
        '既存オブジェクトを修正した場合のUndo情報
        Public Caption As String
        Public RegistObjects() As clsMapData.strObj_Data
        Public mapRect As RectangleF
    End Structure

    Private Structure Undo_AddObject
        '新規オブジェクトを追加した場合のUndo情報
        Public Caption As String
        Public AddObjectsNumber() As Integer
        Public mapRect As RectangleF
    End Structure
    Private Structure Undo_EraseObjects
        '複数オブジェクトを削除した場合のUndo情報
        Public Caption As String
        Public ErasedObjects() As clsMapData.strObj_Data
        Public UseAggrObject() As Undo_EraseObjects_UseAggrObjectInfo
        Public mapRect As RectangleF
    End Structure
    Private Structure Undo_EraseObjects_UseAggrObjectInfo
        Public AggrObjCode As Integer
        Public UseObjNumber As Integer
        Public LStacData As clsMapData.LineCodeStac_Data
    End Structure
    Private Structure Undo_EraseObjects_with_UseLines
        '複数オブジェクトを使用ラインごと削除した場合のUndo情報
        Public Caption As String
        Public ErasedObjects() As clsMapData.strObj_Data
        Public ErasedLines() As clsMapData.strLine_Data
        Public mapRect As RectangleF
    End Structure
    Private Structure Undo_RegistLines
        '既存ラインを修正した場合のUndo情報
        Public Caption As String
        Public RegistLines() As clsMapData.strLine_Data
        Public mapRect As RectangleF
    End Structure

    Private Structure Undo_AddLine
        '新規ラインを追加した場合のUndo情報
        Public Caption As String
        Public AddLinesNumber() As Integer
        Public mapRect As RectangleF
    End Structure
    Private Structure Undo_EraseLines_UseObjectInfo
        Public ObjCode As Integer
        Public UseLineNumber As Integer
        Public LStacData As clsMapData.LineCodeStac_Data
    End Structure
    Private Structure Undo_EraseLines
        '複数ラインを削除した場合のUndo情報
        Public Caption As String
        Public ErasedLines() As clsMapData.strLine_Data
        Public UseObject() As Undo_EraseLines_UseObjectInfo
        Public mapRect As RectangleF
    End Structure
    Private Structure Undo_LineDivide_and_Node_Linecodestac_info
        Public LineCode() As Integer
        Public Shape As enmShape
    End Structure

    Private Structure Undo_LineDivide_and_Node
        'ラインの分割&結節点
        Public Caption As String
        Public Kend As Integer
        Public Alin As Integer
        Public MpLine() As clsMapData.strLine_Data
        Public MpObjLineCodeStac() As Undo_LineDivide_and_Node_Linecodestac_info
    End Structure
    Private Structure Undo_MakeMeshObject
        'メッシュオブジェクトの作成
        Public Caption As String
        Public AddStartLineNumber As Integer
        Public AddStartObjectNumber As Integer
        Public AddNewObjectKindFlag As Boolean
        Public AddNewLineKindFlag As Boolean
        Public mapRect As RectangleF
    End Structure
    Private Structure Undo_ObjectNameListChange
        'オブジェクト名リストの変更
        Public Caption As String
        Public ObjKind() As clsMapData.strObjectGroup_Data
        Public OriginObjName As List(Of clsMapData.Object_NameTimeStac_Data())
    End Structure
    Dim UndoStac As New List(Of Object)


    Dim MapData As clsMapData
    Dim _MapEditor As frmMapEditor
    Public Sub New(ByRef frmMEditor As frmMapEditor, ByRef MData As clsMapData)
        _MapEditor = frmMEditor
        MapData = MData
        UndoArray_Clear()
    End Sub
    ''' <summary>
    ''' Undoを実行
    ''' </summary>
    ''' <returns>ScrData.initを行う必要がある場合true</returns>
    ''' <remarks></remarks>
    Public Function Undo() As Boolean

        Dim n As Integer = UndoStac.Count - 1
        Dim ScrData_initF As Boolean = False
        If n = -1 Then
            Return ScrData_initF
        End If
        Dim UndoObj = UndoStac.Item(n)
        Select Case True
            Case TypeOf UndoObj Is Undo_RegistObject
                'オブジェクトの保存Undo
                Dim UndoData As Undo_RegistObject = CType(UndoObj, Undo_RegistObject)
                For i As Integer = 0 To UndoData.RegistObjects.GetUpperBound(0)
                    MapData.Save_Object(UndoData.RegistObjects(i), False)
                Next
                MapData.Map.Circumscribed_Rectangle = UndoData.mapRect
            Case TypeOf UndoObj Is Undo_AddObject
                'オブジェクトの追加Undo
                Dim UndoData As Undo_AddObject = CType(UndoObj, Undo_AddObject)
                MapData.Erase_MultiObjects(UndoData.AddObjectsNumber.GetLength(0), UndoData.AddObjectsNumber, False)
                MapData.Map.Circumscribed_Rectangle = UndoData.mapRect
            Case TypeOf UndoObj Is Undo_EraseObjects
                'オブジェクトの削除Undo
                Dim UndoData As Undo_EraseObjects = CType(UndoObj, Undo_EraseObjects)
                MapData.Insert_Object(UndoData.ErasedObjects)
                MapData.Map.Circumscribed_Rectangle = UndoData.mapRect
                If UndoData.UseAggrObject Is Nothing = False Then
                    For i As Integer = 0 To UndoData.UseAggrObject.GetUpperBound(0)
                        With MapData.MPObj(UndoData.UseAggrObject(i).AggrObjCode)
                            If .NumOfLine = 0 Then
                                ReDim .LineCodeSTC(0)
                            Else
                                ReDim Preserve .LineCodeSTC(.NumOfLine)
                            End If
                            .LineCodeSTC(.NumOfLine) = UndoData.UseAggrObject(i).LStacData.Clone
                            .NumOfLine += 1
                            .Shape = MapData.Check_Obj_Shape_AllTime(MapData.MPObj(UndoData.UseAggrObject(i).AggrObjCode))
                        End With
                    Next
                End If
            Case TypeOf UndoObj Is Undo_RegistLines
                'ラインの保存Undo
                Dim UndoData As Undo_RegistLines = CType(UndoObj, Undo_RegistLines)
                For i As Integer = 0 To UndoData.RegistLines.GetUpperBound(0)
                    MapData.Save_Line(UndoData.RegistLines(i), True, True, False)
                Next
                MapData.Map.Circumscribed_Rectangle = UndoData.mapRect
            Case TypeOf UndoObj Is Undo_AddLine
                'ラインの追加Undo
                Dim UndoData As Undo_AddLine = CType(UndoObj, Undo_AddLine)
                MapData.Erase_MultiLine(UndoData.AddLinesNumber.GetLength(0), UndoData.AddLinesNumber, True, True, False)
                MapData.Map.Circumscribed_Rectangle = UndoData.mapRect
            Case TypeOf UndoObj Is Undo_EraseLines
                'ラインの削除Undo
                Dim UndoData As Undo_EraseLines = CType(UndoObj, Undo_EraseLines)
                MapData.Insert_Line(UndoData.ErasedLines)
                If UndoData.UseObject Is Nothing = False Then
                    For i As Integer = 0 To UndoData.UseObject.GetUpperBound(0)
                        With MapData.MPObj(UndoData.UseObject(i).ObjCode)
                            If .NumOfLine = 0 Then
                                ReDim .LineCodeSTC(0)
                            Else
                                ReDim Preserve .LineCodeSTC(.NumOfLine)
                            End If
                            .LineCodeSTC(.NumOfLine) = UndoData.UseObject(i).LStacData.Clone
                            .NumOfLine += 1
                            .Shape = MapData.Check_Obj_Shape_AllTime(MapData.MPObj(UndoData.UseObject(i).ObjCode))
                        End With
                    Next
                End If
                MapData.Map.Circumscribed_Rectangle = UndoData.mapRect
            Case TypeOf UndoObj Is Undo_LineDivide_and_Node
                'ライン分割&結節点、交点で分割、位相構造化Undo
                Dim UndoData As Undo_LineDivide_and_Node = CType(UndoObj, Undo_LineDivide_and_Node)
                With UndoData
                    ReDim MapData.MPLine(.Alin - 1)
                    For i As Integer = 0 To .Alin - 1
                        MapData.MPLine(i) = .MpLine(i).Clone
                    Next
                    For i As Integer = 0 To MapData.Map.Kend - 1
                        With MapData.MPObj(i)
                            If MapData.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                                .Shape = UndoData.MpObjLineCodeStac(i).Shape
                                If UndoData.MpObjLineCodeStac(i).LineCode Is Nothing Then
                                Else
                                    Dim lcn As Integer = UndoData.MpObjLineCodeStac(i).LineCode.GetLength(0)
                                    If lcn >= 1 Then
                                        .NumOfLine = lcn
                                        ReDim Preserve .LineCodeSTC(lcn - 1)
                                        For j As Integer = 0 To lcn - 1
                                            .LineCodeSTC(j).LineCode = UndoData.MpObjLineCodeStac(i).LineCode(j)
                                        Next
                                    End If
                                End If
                            End If
                        End With
                    Next
                    MapData.Map.ALIN = .Alin
                End With
            Case TypeOf UndoObj Is Undo_EraseObjects_with_UseLines
                '複数オブジェクトを使用ラインごと削除Undo
                Dim UndoData As Undo_EraseObjects_with_UseLines = CType(UndoObj, Undo_EraseObjects_with_UseLines)
                MapData.Insert_Line(UndoData.ErasedLines)
                MapData.Insert_Object(UndoData.ErasedObjects)
                MapData.Map.Circumscribed_Rectangle = UndoData.mapRect
            Case TypeOf UndoObj Is Undo_MakeMeshObject
                'メッシュオブジェクトの作成
                Dim UndoData As Undo_MakeMeshObject = CType(UndoObj, Undo_MakeMeshObject)
                With UndoData
                    Dim LCodeList As New List(Of Integer)
                    For i As Integer = .AddStartLineNumber To MapData.Map.ALIN - 1
                        LCodeList.Add(i)
                    Next
                    MapData.Erase_MultiLine(LCodeList, True, False, False)
                    Dim OCodeList As New List(Of Integer)
                    For i As Integer = .AddStartObjectNumber To MapData.Map.Kend - 1
                        OCodeList.Add(i)
                    Next
                    MapData.Erase_MultiObjects(OCodeList, False)
                    If .AddNewObjectKindFlag = True Then
                        _MapEditor.clbObjectKindEdit.Items.RemoveAt(MapData.Map.OBKNum - 1)
                        MapData.Erase_ObjectKind(MapData.Map.OBKNum - 1, False)
                    End If
                    If .AddNewLineKindFlag = True Then
                        _MapEditor.clbLineKindEdit.Items.RemoveAt(MapData.Map.LpNum - 1)
                        MapData.Erase_LineKind(MapData.Map.LpNum - 1)
                    End If
                End With
                MapData.Map.Circumscribed_Rectangle = UndoData.mapRect
            Case TypeOf UndoObj Is Undo_EditingDefAttData
                '初期属性データ編集
                Dim UndoData As Undo_EditingDefAttData = CType(UndoObj, Undo_EditingDefAttData)
                With UndoData
                    For i As Integer = 0 To MapData.Map.OBKNum - 1
                        MapData.ObjectKind(i) = .ObjKind(i).Clone
                    Next
                    For i As Integer = 0 To MapData.Map.Kend - 1
                        With MapData.MPObj(i)
                            If MapData.ObjectKind(.Kind).DefTimeAttDataNum > 0 Then
                                MapData.MPObj(i).DefTimeAttValue = CType(UndoData.ObjDefAttData.Item(i), clsMapData.strDefTimeAttData_Info())
                            Else
                                .DefTimeAttValue = Nothing
                            End If
                        End With
                    Next
                End With
            Case TypeOf UndoObj Is Undo_ObjectNameListChange
                'オブジェクト名リスト変更
                Dim UndoData As Undo_ObjectNameListChange = CType(UndoObj, Undo_ObjectNameListChange)
                With UndoData
                    For i As Integer = 0 To MapData.Map.OBKNum - 1
                        MapData.ObjectKind(i) = .ObjKind(i).Clone
                    Next
                    For i As Integer = 0 To MapData.Map.Kend - 1
                        With MapData.MPObj(i)
                            .NameTimeSTC = CType(UndoData.OriginObjName.Item(i), clsMapData.Object_NameTimeStac_Data())
                            .NumOfNameTime = .NameTimeSTC.Length
                        End With
                    Next
                End With
            Case TypeOf UndoObj Is Undo_SettingObjectGroup
                'オブジェクトグループ設定、オブジェクトグループ統合
                Dim UndoData As Undo_SettingObjectGroup = CType(UndoObj, Undo_SettingObjectGroup)
                With UndoData
                    Dim obknum As Integer = .ObjKind.GetLength(0)
                    MapData.Map.OBKNum = obknum
                    ReDim MapData.ObjectKind(obknum - 1)
                    For i As Integer = 0 To obknum - 1
                        MapData.ObjectKind(i) = .ObjKind(i).Clone
                    Next
                    For i As Integer = 0 To MapData.Map.LpNum - 1
                        MapData.LineKind(i) = .LKind(i).Clone
                    Next
                    For i As Integer = 0 To MapData.Map.Kend - 1
                        MapData.MPObj(i).Kind = .MpObjKind(i)
                    Next
                    _MapEditor.EditList.ObjectKind = .EditList.Clone
                    _MapEditor.setEditPanelObjectKind()
                End With
            Case TypeOf UndoObj Is Undo_SettingLineKind
                '線種設定、線種統合
                Dim UndoData As Undo_SettingLineKind = CType(UndoObj, Undo_SettingLineKind)
                With UndoData
                    Dim lpnum As Integer = .LKind.GetLength(0)
                    MapData.Map.LpNum = lpnum
                    ReDim MapData.LineKind(lpnum - 1)
                    For i As Integer = 0 To lpnum - 1
                        MapData.LineKind(i) = .LKind(i).Clone
                    Next
                    For i As Integer = 0 To MapData.Map.OBKNum - 1
                        MapData.ObjectKind(i) = .ObjKind(i).Clone
                    Next
                    For i As Integer = 0 To MapData.Map.ALIN - 1
                        Dim LKind() As Integer = CType(UndoData.MpLineKind.Item(i), Integer())
                        With MapData.MPLine(i)
                            For j As Integer = 0 To .NumOfTime - 1
                                .LineTimeSTC(j).Kind = LKind(j)
                            Next
                        End With
                    Next
                    _MapEditor.EditList.LineKind = .EditList.Clone
                    _MapEditor.setEditPanelLineKind()
                End With
            Case TypeOf UndoObj Is Undo_SettingCompass
                '方位設定
                Dim UndoData As Undo_SettingCompass = CType(UndoObj, Undo_SettingCompass)
                With UndoData
                    MapData.Map.MapCompass = .Compass
                End With
            Case TypeOf UndoObj Is Undo_Object_andLine_Drag
                'オブジェクト編集モードでラインごとドラッグ
                Dim UndoData As Undo_Object_andLine_Drag = CType(UndoObj, Undo_Object_andLine_Drag)
                With UndoData
                    For i As Integer = 0 To .Lines.GetUpperBound(0)
                        MapData.Save_Line(.Lines(i), False, False, False)
                    Next
                    ReDim Preserve MapData.MPObj(.KenD - 1)
                    MapData.Map.Kend = .KenD
                    For i As Integer = 0 To .Objects.GetUpperBound(0)
                        If .Objects(i).Number <> -1 Then
                            MapData.Save_Object(.Objects(i), False)
                        End If
                    Next
                End With
                MapData.Map.Circumscribed_Rectangle = UndoData.mapRect
            Case TypeOf UndoObj Is Undo_ReplaceObjectName
                'オブジェクト名置換
                Dim UndoData As Undo_ReplaceObjectName = CType(UndoObj, Undo_ReplaceObjectName)
                With UndoData
                    For i As Integer = 0 To MapData.Map.Kend - 1
                        Dim oname() As clsMapData.Object_NameTimeStac_Data = .OriginObjName.Item(i)
                        With MapData.MPObj(i)
                            For j As Integer = 0 To .NumOfNameTime - 1
                                .NameTimeSTC(j) = oname(j).Clone
                            Next
                        End With
                    Next
                End With
            Case TypeOf UndoObj Is Undo_CombineSameObjectName
                ' 同一オブジェクト名のオブジェクトの結合
                Dim UndoData As Undo_CombineSameObjectName = CType(UndoObj, Undo_CombineSameObjectName)
                With UndoData
                    Dim kenn As Integer = .AllObjects.GetUpperBound(0) + 1
                    MapData.Map.Kend = kenn
                    ReDim MapData.MPObj(kenn - 1)
                    For i As Integer = 0 To kenn - 1
                        MapData.MPObj(i) = .AllObjects(i).Clone
                    Next
                End With
            Case TypeOf UndoObj Is Undo_SmoothingLine
                ' ポイントループ間引き
                Dim UndoData As Undo_SmoothingLine = CType(UndoObj, Undo_SmoothingLine)
                With UndoData
                    Dim kenn As Integer = .AllObjects.GetUpperBound(0) + 1
                    MapData.Map.Kend = kenn
                    ReDim MapData.MPObj(kenn - 1)
                    For i As Integer = 0 To kenn - 1
                        MapData.MPObj(i) = .AllObjects(i).Clone
                    Next
                    Dim Alinn As Integer = .AllLines.GetUpperBound(0) + 1
                    MapData.Map.ALIN = Alinn
                    ReDim MapData.MPLine(Alinn - 1)
                    For i As Integer = 0 To Alinn - 1
                        MapData.MPLine(i) = .AllLines(i).Clone
                    Next
                    MapData.Map.Circumscribed_Rectangle = .mapRect
                End With
            Case TypeOf UndoObj Is Undo_ZahyoConvert
                ' 座標変換
                Dim UndoData As Undo_ZahyoConvert = CType(UndoObj, Undo_ZahyoConvert)
                With UndoData
                    MapData.Map = .mapZahyo
                    For i As Integer = 0 To MapData.Map.Kend - 1
                        With MapData.MPObj(i)
                            .Circumscribed_Rectangle = UndoData.AllObjects(i).cirrect
                            For j As Integer = 0 To .NumOfCenterP - 1
                                .CenterPSTC(j).Position = UndoData.AllObjects(i).CenterP(j)
                            Next
                        End With
                    Next
                    For i As Integer = 0 To MapData.Map.ALIN - 1
                        With MapData.MPLine(i)
                            .Circumscribed_Rectangle = UndoData.AllLines(i).cirrect
                            .PointSTC = UndoData.AllLines(i).LinePoint.Clone
                        End With
                    Next
                End With
                ScrData_initF = True
            Case TypeOf UndoObj Is Undo_Replace_ITRF94_Tokyo97
                ' 座標変換
                Select Case MapData.Map.Zahyo.System
                    Case enmZahyo_System_Info.Zahyo_System_World
                        MapData.Map.Zahyo.System = enmZahyo_System_Info.Zahyo_System_tokyo
                    Case enmZahyo_System_Info.Zahyo_System_tokyo
                        MapData.Map.Zahyo.System = enmZahyo_System_Info.Zahyo_System_World
                End Select
            Case TypeOf UndoObj Is Undo_AllMapData
                '地図ファイル挿入
                Dim UndoData As Undo_AllMapData = CType(UndoObj, Undo_AllMapData)
                UndoData.MapData.CopyTo(MapData)
                _MapEditor.EditList.ObjectKind = UndoData.EditOBJKList.Clone
                _MapEditor.EditList.LineKind = UndoData.EditLKList.Clone
                _MapEditor.EditList.AggregationF = MapData.Check_AggregateObjectType_Exists
                _MapEditor.setEditPanel()
                ScrData_initF = True
        End Select
        UndoStac.RemoveAt(n)
        If n > 10 Then
            UndoStac.RemoveAt(0)
        End If
        SetUndoMenu()
        Return ScrData_initF
    End Function
    Private Sub SetUndoMenu()
        Dim n As Integer = UndoStac.Count
        If n = 0 Then
            _MapEditor.mnuUndo.Enabled = False
            _MapEditor.mnuUndo.Text = "元に戻す(&Z)"
        Else
            _MapEditor.mnuUndo.Text = "元に戻す(&Z)（" & UndoStac.Item(n - 1).caption & "）"
            _MapEditor.mnuUndo.Enabled = True
        End If

    End Sub
    Private Sub UndoArray_Clear()
        UndoStac.Clear()
        UndoStac.TrimExcess()
        SetUndoMenu()
    End Sub
    ''' <summary>
    ''' オブジェクト番号から複数オブジェクトの保存
    ''' </summary>
    ''' <param name="MObjCode">オブジェクト番号のArrayList</param>
    ''' <remarks></remarks>
    Public Sub SetUndo_SaveObject(ByVal menuCaption As String, ByRef MObjCode As List(Of Integer),
                                  ByVal MapRect As RectangleF)
        Dim UndoData As Undo_RegistObject
        With UndoData
            .Caption = menuCaption
            ReDim .RegistObjects(MObjCode.Count - 1)
            For i As Integer = 0 To MObjCode.Count - 1
                .RegistObjects(i) = MapData.MPObj(MObjCode.Item(i)).Clone
            Next
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    ''' <summary>
    ''' オブジェクト構造体配列から複数オブジェクトの保存
    ''' </summary>
    ''' <param name="MObjCode">オブジェクト構造体配列</param>
    ''' <remarks></remarks>
    Public Sub SetUndo_SaveObject(ByVal menuCaption As String, ByRef MObj() As clsMapData.strObj_Data,
                                  ByVal MapRect As RectangleF)
        Dim UndoData As Undo_RegistObject
        With UndoData
            .Caption = menuCaption
            ReDim .RegistObjects(MObj.GetLength(0) - 1)
            For i As Integer = 0 To MObj.GetLength(0) - 1
                .RegistObjects(i) = MObj(i).Clone
            Next
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    ''' <summary>
    ''' オブジェクト構造体から単独オブジェクトの保存
    ''' </summary>
    ''' <param name="MObj"></param>
    ''' <param name="menuCaption"></param>
    ''' <remarks></remarks>
    Public Sub SetUndo_SaveObject(ByVal menuCaption As String, ByRef MObj As clsMapData.strObj_Data,
                                  ByVal MapRect As RectangleF)
        Dim UndoData As Undo_RegistObject
        With UndoData
            .Caption = menuCaption
            ReDim .RegistObjects(0)
            .RegistObjects(0) = MObj.Clone
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_AddObject(ByVal menuCaption As String, ByVal ObjCode As Integer,
                                  ByVal MapRect As RectangleF)
        Dim UndoData As Undo_AddObject
        With UndoData
            .Caption = menuCaption
            ReDim .AddObjectsNumber(0)
            .AddObjectsNumber(0) = ObjCode
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_AddObject(ByVal menuCaption As String, ByVal ObjCode() As Integer,
                                  ByVal MapRect As RectangleF)
        Dim UndoData As Undo_AddObject
        With UndoData
            .Caption = menuCaption
            .AddObjectsNumber = ObjCode.Clone
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_EraseObject(ByRef MObj As clsMapData.strObj_Data,
                                  ByVal MapRect As RectangleF)
        Dim UndoData As Undo_EraseObjects
        With UndoData
            .Caption = "オブジェクトの削除"
            ReDim .ErasedObjects(0)
            .ErasedObjects(0) = MObj.Clone
            .mapRect = MapRect
            SetUndo_EraseObjectSub(.UseAggrObject, MObj)
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    ''' <summary>
    ''' 複数オブジェクトの削除
    ''' </summary>
    ''' <param name="mnuCaption"></param>
    ''' <param name="EditingMultiObject"></param>
    ''' <param name="MapRect"></param>
    ''' <remarks></remarks>
    Public Sub SetUndo_EraseObjects(ByVal mnuCaption As String, ByRef EditingMultiObject As List(Of Integer),
                              ByVal MapRect As RectangleF)

        Dim UndoData As Undo_EraseObjects
        With UndoData
            .Caption = mnuCaption
            ReDim .ErasedObjects(EditingMultiObject.Count - 1)
            For i As Integer = 0 To EditingMultiObject.Count - 1
                .ErasedObjects(i) = MapData.MPObj(EditingMultiObject.Item(i)).Clone
                SetUndo_EraseObjectSub(.UseAggrObject, MapData.MPObj(EditingMultiObject.Item(i)))
            Next
            UndoStac.Add(UndoData)
            SetUndoMenu()
            .mapRect = MapRect
        End With
    End Sub
    Private Sub SetUndo_EraseObjectSub(ByRef UseObj() As Undo_EraseObjects_UseAggrObjectInfo, ByRef MObj As clsMapData.strObj_Data)
        Dim n As Integer = 0
        If UseObj Is Nothing = False Then
            n = UseObj.GetLength(0)
        End If
        For i As Integer = 0 To MapData.Map.Kend - 1
            With MapData.MPObj(i)
                If MapData.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.AggregationObject Then
                    For j As Integer = 0 To .NumOfLine - 1
                        If .LineCodeSTC(j).LineCode = MObj.Number Then
                            ReDim Preserve UseObj(n)
                            UseObj(n).AggrObjCode = i
                            UseObj(n).UseObjNumber = MObj.Number
                            UseObj(n).LStacData = .LineCodeSTC(j).Clone
                            n += 1
                        End If
                    Next
                End If
            End With
        Next

    End Sub
    Public Sub SetUndo_SaveLine(ByVal mnuCaption As String, ByRef MLineCode As List(Of Integer),
                                  ByVal MapRect As RectangleF)
        Dim UndoData As Undo_RegistLines
        With UndoData
            .Caption = mnuCaption
            ReDim .RegistLines(MLineCode.Count - 1)
            For i As Integer = 0 To MLineCode.Count - 1
                .RegistLines(i) = MapData.MPLine(MLineCode.Item(i)).Clone
            Next
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_SaveLine(ByRef MLine As clsMapData.strLine_Data,
                                  ByVal MapRect As RectangleF)
        Dim UndoData As Undo_RegistLines
        With UndoData
            .Caption = "ラインの登録"
            ReDim .RegistLines(0)
            .RegistLines(0) = MLine.Clone
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_AddLine(ByVal LineCode As Integer,
                                  ByVal MapRect As RectangleF)
        Dim UndoData As Undo_AddLine
        With UndoData
            .Caption = "ラインの新規登録"
            ReDim .AddLinesNumber(0)
            .AddLinesNumber(0) = LineCode
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_EraseLine(ByRef MLine As List(Of Integer),
                                  ByVal MapRect As RectangleF)
        Dim UndoData As New Undo_EraseLines
        With UndoData
            .Caption = "複数ラインの削除"
            ReDim .ErasedLines(MLine.Count - 1)
            For i As Integer = 0 To MLine.Count - 1
                .ErasedLines(i) = MapData.MPLine(MLine.Item(i)).Clone
                SetUndo_EraseLineSub(.UseObject, MapData.MPLine(MLine.Item(i)))
            Next
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_EraseLine(ByRef MLine As clsMapData.strLine_Data,
                                  ByVal MapRect As RectangleF)
        Dim UndoData As New Undo_EraseLines
        With UndoData
            .Caption = "ラインの削除"
            ReDim .ErasedLines(0)
            .ErasedLines(0) = MLine.Clone
            SetUndo_EraseLineSub(.UseObject, MLine)
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Private Sub SetUndo_EraseLineSub(ByRef UseObj() As Undo_EraseLines_UseObjectInfo, ByRef MLine As clsMapData.strLine_Data)
        Dim n As Integer = 0
        If UseObj Is Nothing = False Then
            n = UseObj.GetLength(0)
        End If
        For i As Integer = 0 To MapData.Map.Kend - 1
            With MapData.MPObj(i)
                If MapData.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                    For j As Integer = 0 To .NumOfLine - 1
                        If .LineCodeSTC(j).LineCode = MLine.Number Then
                            ReDim Preserve UseObj(n)
                            UseObj(n).ObjCode = i
                            UseObj(n).UseLineNumber = MLine.Number
                            UseObj(n).LStacData = .LineCodeSTC(j).Clone
                            n += 1
                        End If
                    Next
                End If
            End With
        Next

    End Sub
    Public Sub SetUndo_LineDivide_and_Node(ByVal mnuCaption As String)
        Dim UndoData As Undo_LineDivide_and_Node
        With UndoData
            .Caption = mnuCaption
            .Alin = MapData.Map.ALIN
            Dim n As Integer = MapData.Map.ALIN
            'ラインはすべてコピーする
            ReDim .MpLine(n - 1)
            For i As Integer = 0 To n - 1
                .MpLine(i) = MapData.MPLine(i).Clone
            Next
            'オブジェクトはラインコードスタックと形状のみコピーする
            ReDim UndoData.MpObjLineCodeStac(MapData.Map.Kend - 1)
            For i As Integer = 0 To MapData.Map.Kend - 1
                With MapData.MPObj(i)
                    If MapData.ObjectKind(.Kind).ObjectType = clsMapData.enmObjectGoupType_Data.NormalObject Then
                        If .NumOfLine > 0 Then
                            ReDim UndoData.MpObjLineCodeStac(i).LineCode(.NumOfLine - 1)
                            For j As Integer = 0 To .NumOfLine - 1
                                UndoData.MpObjLineCodeStac(i).LineCode(j) = .LineCodeSTC(j).LineCode
                            Next
                        End If
                        UndoData.MpObjLineCodeStac(i).Shape = .Shape
                    End If
                End With
            Next
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub Set_Undo_SettingObjectGroup(ByVal mnuCaption As String)
        'オブジェクトグループ設定、オブジェクトグループ統合
        Dim UndoData As Undo_SettingObjectGroup
        With UndoData
            .Caption = mnuCaption
            ReDim .ObjKind(MapData.Map.OBKNum - 1)
            For i As Integer = 0 To MapData.Map.OBKNum - 1
                .ObjKind(i) = MapData.ObjectKind(i).Clone
            Next
            .EditList = _MapEditor.EditList.ObjectKind.Clone
            ReDim .LKind(MapData.Map.LpNum - 1)
            For i As Integer = 0 To MapData.Map.LpNum - 1
                .LKind(i) = MapData.LineKind(i).Clone
            Next
            ReDim .MpObjKind(MapData.Map.Kend - 1)
            For i As Integer = 0 To MapData.Map.Kend - 1
                .MpObjKind(i) = MapData.MPObj(i).Kind
            Next
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub Set_Undo_SettingLineKind(ByVal mnuCaption As String)
        '線種設定、線種統合
        Dim UndoData As Undo_SettingLineKind
        With UndoData
            .Caption = mnuCaption
            ReDim .ObjKind(MapData.Map.OBKNum - 1)
            For i As Integer = 0 To MapData.Map.OBKNum - 1
                .ObjKind(i) = MapData.ObjectKind(i).Clone
            Next
            .EditList = _MapEditor.EditList.LineKind.Clone
            ReDim .LKind(MapData.Map.LpNum - 1)
            For i As Integer = 0 To MapData.Map.LpNum - 1
                .LKind(i) = MapData.LineKind(i).Clone
            Next
            .MpLineKind = New ArrayList
            For i As Integer = 0 To MapData.Map.ALIN - 1
                With MapData.MPLine(i)
                    Dim LKind(.NumOfTime - 1) As Integer
                    For j As Integer = 0 To .NumOfTime - 1
                        LKind(j) = .LineTimeSTC(j).Kind
                    Next
                    UndoData.MpLineKind.Add(LKind)
                End With
            Next
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub Set_UndoSettingObject_andLine_Drag(ByVal mnuCaption As String, ByRef MLineCode As List(Of Integer), ByRef MObjCode As List(Of Integer),
                                  ByVal MapRect As RectangleF)
        'ラインごとオブジェクトの移動
        Dim UndoData As Undo_Object_andLine_Drag
        With UndoData
            .Caption = mnuCaption
            .KenD = MapData.Map.Kend
            ReDim .Lines(MLineCode.Count - 1)
            For i As Integer = 0 To MLineCode.Count - 1
                .Lines(i) = MapData.MPLine(MLineCode.Item(i)).Clone
            Next
            ReDim .Objects(MObjCode.Count - 1)
            For i As Integer = 0 To MObjCode.Count - 1
                If MObjCode.Item(i) = -1 Then
                    '新規作成の場合、Undo時には使われない
                Else
                    .Objects(i) = MapData.MPObj(MObjCode.Item(i)).Clone
                End If
            Next
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_Compass(ByVal mnuCaption As String)
        Dim UndoData As Undo_SettingCompass
        UndoData.Caption = "方位の移動"
        UndoData.Compass = MapData.Map.MapCompass
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub

    Public Sub SetUndo_Change_Using_Line_Kind(ByRef Change_Line_List() As Integer, ByRef OriginUseLineKindNumber() As Integer,
                                              reValue() As Integer, ByVal KyoyuLineChangeF As Boolean)
        Dim UndoData As Undo_RegistLines
        UndoData.Caption = "複数オブジェクトの使用ライン線種変更"
        ReDim UndoData.RegistLines(0)
        Dim RegistLines_n As Integer = 0
        For i As Integer = 0 To MapData.Map.ALIN - 1
            If Change_Line_List(i) >= 1 Then
                If Change_Line_List(i) = 1 Or (Change_Line_List(i) >= 2 And KyoyuLineChangeF = True) Then
                    For j As Integer = 0 To MapData.MPLine(i).NumOfTime - 1
                        Dim lkn As Integer = Array.IndexOf(OriginUseLineKindNumber, MapData.MPLine(i).LineTimeSTC(j).Kind)
                        ReDim Preserve UndoData.RegistLines(RegistLines_n)
                        UndoData.RegistLines(RegistLines_n) = MapData.MPLine(i).Clone
                        RegistLines_n += 1
                        MapData.MPLine(i).LineTimeSTC(j).Kind = reValue(lkn)
                    Next
                End If
            End If
        Next
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_Make_MeshObject(ByVal mnuCaption As String, ByVal beforeKend As Integer, ByVal beforeAlin As Integer,
                                       ByVal AddNewObjectKindFlag As Boolean, ByVal AddNewLineKindFlag As Boolean,
                                  ByVal MapRect As RectangleF)

        Dim UndoData As Undo_MakeMeshObject
        With UndoData
            .Caption = mnuCaption
            .AddStartLineNumber = beforeAlin
            .AddStartObjectNumber = beforeKend
            .AddNewLineKindFlag = AddNewLineKindFlag
            .AddNewObjectKindFlag = AddNewObjectKindFlag
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_EditingDefAttData()
        Dim UndoData As Undo_EditingDefAttData
        With UndoData
            .Caption = "初期属性データ編集"
            ReDim .ObjKind(MapData.Map.OBKNum - 1)
            For i As Integer = 0 To MapData.Map.OBKNum - 1
                .ObjKind(i) = MapData.ObjectKind(i).Clone
            Next
            .ObjDefAttData = New List(Of clsMapData.strDefTimeAttData_Info())
            For i As Integer = 0 To MapData.Map.Kend - 1
                With MapData.MPObj(i)
                    Dim n As Integer = MapData.ObjectKind(.Kind).DefTimeAttDataNum
                    If n = 0 Then
                        UndoData.ObjDefAttData.Add(Nothing)
                    Else
                        UndoData.ObjDefAttData.Add(clsGeneric.DefTimeAttValueClone(.DefTimeAttValue))
                    End If
                End With
            Next
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()

    End Sub
    Public Sub SetUndo_EraseObjects_with_UseLines(ByRef EraseObj As ArrayList, EraseLine As ArrayList,
                                  ByVal MapRect As RectangleF)
        Dim UndoData As Undo_EraseObjects_with_UseLines
        With UndoData
            .Caption = "複数オブジェクトを使用ラインごと削除"
            ReDim .ErasedObjects(EraseObj.Count - 1)
            For i As Integer = 0 To EraseObj.Count - 1
                Dim mobj As clsMapData.strObj_Data = CType(EraseObj.Item(i), clsMapData.strObj_Data)
                .ErasedObjects(i) = mobj.Clone
            Next
            ReDim .ErasedLines(EraseLine.Count - 1)
            For i As Integer = 0 To EraseLine.Count - 1
                Dim mline As clsMapData.strLine_Data = CType(EraseLine.Item(i), clsMapData.strLine_Data)
                .ErasedLines(i) = mline.Clone
            Next
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_ReplaceObjectName(ByVal mnuCaption As String, ByRef ObjNameArray As List(Of clsMapData.Object_NameTimeStac_Data()))
        Dim UndoData As Undo_ReplaceObjectName
        With UndoData
            .Caption = mnuCaption
            .OriginObjName = ObjNameArray
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_ObjectNameListChange(ByVal mnuCaption As String)
        Dim UndoData As Undo_ObjectNameListChange
        With UndoData
            .Caption = mnuCaption
            ReDim .ObjKind(MapData.Map.OBKNum - 1)
            For i As Integer = 0 To MapData.Map.OBKNum - 1
                .ObjKind(i) = MapData.ObjectKind(i).Clone
            Next
            .OriginObjName = MapData.Get_All_ObjectName
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_CombineSameObjectName(ByVal mnuCaption As String, ByRef Obj() As clsMapData.strObj_Data)
        Dim UndoData As Undo_CombineSameObjectName
        With UndoData
            .Caption = mnuCaption
            Dim n As Integer = Obj.GetUpperBound(0)
            ReDim .AllObjects(n)
            For i As Integer = 0 To n
                .AllObjects(i) = Obj(i).Clone
            Next
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_SmoothingLine(ByVal mnuCaption As String, ByRef Obj() As clsMapData.strObj_Data, ByRef Lines() As clsMapData.strLine_Data,
                                     ByVal MapRect As RectangleF)
        Dim UndoData As Undo_SmoothingLine
        With UndoData
            .Caption = mnuCaption
            Dim n As Integer = Obj.GetUpperBound(0)
            ReDim .AllObjects(n)
            For i As Integer = 0 To n
                .AllObjects(i) = Obj(i).Clone
            Next
            Dim n2 As Integer = Lines.GetUpperBound(0)
            ReDim .AllLines(n2)
            For i As Integer = 0 To n2
                .AllLines(i) = Lines(i).Clone
            Next
            .mapRect = MapRect
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_ZahyoConvert(ByVal mnuCaption As String, ByRef mapdata As clsMapData)
        Dim UndoData As Undo_ZahyoConvert
        With UndoData
            .Caption = mnuCaption
            .mapZahyo = mapdata.Map
            ReDim .AllObjects(mapdata.Map.Kend - 1)
            For i As Integer = 0 To mapdata.Map.Kend - 1
                With mapdata.MPObj(i)
                    ReDim UndoData.AllObjects(i).CenterP(.NumOfCenterP - 1)
                    For j As Integer = 0 To .NumOfCenterP - 1
                        UndoData.AllObjects(i).CenterP(j) = .CenterPSTC(j).Position
                    Next
                    UndoData.AllObjects(i).cirrect = .Circumscribed_Rectangle
                End With
            Next
            ReDim .AllLines(Math.Max(mapdata.Map.ALIN - 1, 0))
            For i As Integer = 0 To mapdata.Map.ALIN - 1
                With mapdata.MPLine(i)
                    UndoData.AllLines(i).LinePoint = .PointSTC.Clone
                    UndoData.AllLines(i).cirrect = .Circumscribed_Rectangle
                End With
            Next
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_Replace_ITRF94_Tokyo97(ByVal mnuCaption As String)
        Dim UndoData As Undo_Replace_ITRF94_Tokyo97
        UndoData.Caption = mnuCaption
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub
    Public Sub SetUndo_AllMapData(ByVal mnuCaption As String)
        Dim UndoData As Undo_AllMapData
        With UndoData
            .Caption = mnuCaption
            .MapData = MapData.Clone
            .EditOBJKList = _MapEditor.EditList.ObjectKind.Clone
            .EditLKList = _MapEditor.EditList.LineKind.Clone
        End With
        UndoStac.Add(UndoData)
        SetUndoMenu()
    End Sub

    ''' <summary>
    ''' 最後のUndoを取り消す
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RemoveLastUndo()
        UndoStac.RemoveAt(UndoStac.Count - 1)
        SetUndoMenu()
    End Sub

End Class
