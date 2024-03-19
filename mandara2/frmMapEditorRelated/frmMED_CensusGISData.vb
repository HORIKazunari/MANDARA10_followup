Public Class frmMED_CensusGISData
    Dim CloseCancelF As Boolean
    Dim File_List() As String
    Dim MapData As clsMapData
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
    Public Overloads Function Show(ByVal frmSetteiF As Boolean) As Windows.Forms.DialogResult
        ktFolder.Folder = clsSettings.Data.Directory.CensusGIS
        FileSelect.InitFolder = clsSettings.Data.Directory.CensusGIS
        If frmSetteiF = True Then
            rbDefATT.Checked = True
            grAttrData.Enabled = False
        End If
        Return Me.ShowDialog()

    End Function
    Public Function GetResults() As clsMapData
        Return MapData
    End Function


    Private Sub Get_TokeiGIS_Folder()
        cbArea.Items.Clear()
        Dim folder_path As String = ktFolder.Folder
        Dim File_List() As String
        Try
            File_List = System.IO.Directory.GetFiles(folder_path, "*.shp", IO.SearchOption.TopDirectoryOnly)
        Catch ex As Exception
            Return
        End Try
        clsSettings.Data.Directory.CensusGIS = folder_path
        Dim FileN As Integer = File_List.Length
        For i As Integer = 0 To FileN - 1
            cbArea.Items.Add(System.IO.Path.GetFileName(File_List(i)))
        Next
    End Sub

    Private Sub ktFolder_Changed() Handles ktFolder.Changed
        Get_TokeiGIS_Folder()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim zahyo As clsMapData.Zahyo_info
        Dim GCODE() As String
        Dim Year As String

        If rbCSV.Checked = True Then
            If clsGeneric.Check_Folder_Exists(FileSelect.Path) = False Then
                CloseCancelF = True
                Return
            End If
        End If

        Me.Cursor = Cursors.WaitCursor

        If CheckFiles(GCODE, zahyo, Year) = False Then
            CloseCancelF = True
            Me.Cursor = Cursors.Default
            Return
        End If
        zahyo.Projection = enmProjection_Info.prjMercator
        ProgressBar1.Visible = True
        If Get_TokeiMap(ktFolder.Folder, Year, cbArea.CheckedIndices.Count, GCODE, zahyo) = True Then
            Dim defAttNum As Integer = MapData.ObjectKind(0).DefTimeAttDataNum
            If Get_TokeiData(ktFolder.Folder, cbArea.CheckedIndices.Count, GCODE) = True Then
                If rbCSV.Checked = True Then
                    If outCSV(defAttNum) = True Then
                        If MsgBox("出力したCSVファイルを開きますか？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            System.Diagnostics.Process.Start(FileSelect.Path)
                        End If
                    End If
                End If
            End If
        Else
            CloseCancelF = True
        End If
        ProgressBar1.Visible = False
        Me.Cursor = Cursors.Default



    End Sub
    Private Function CheckFiles(ByRef GCODE() As String, ByRef getZahyo As clsMapData.Zahyo_info, ByRef Year As String) As Boolean
        Dim n As Integer = cbArea.CheckedIndices.Count
        If n = 0 Then
            MsgBox("取得市区町村を選択して下さい。", MsgBoxStyle.Exclamation)
            Return False
        End If
        Dim folder As String = ktFolder.Folder
        Dim DYear As String = ""
        Dim Ozahyo As clsMapData.Zahyo_info
        ReDim GCODE(n - 1)

        For i As Integer = 0 To n - 1
            Dim zahyo As clsMapData.Zahyo_info
            Dim fname As String = cbArea.Items(cbArea.CheckedIndices(i))
            If i <> 0 Then
                If Microsoft.VisualBasic.Left(fname, 3) <> DYear Then
                    MsgBox("同じ年次のファイルを指定してください。", MsgBoxStyle.Exclamation)
                    Return False
                End If
            End If
            If Len(fname) = 11 Then
                GCODE(i) = Mid(fname, 6, 2)
            Else
                GCODE(i) = Mid(fname, 6, 5)
            End If
            DYear = Microsoft.VisualBasic.Left(fname, 3)
            Dim shxfilename = folder & "\" & System.IO.Path.GetFileNameWithoutExtension(fname) & ".shx"
            If System.IO.File.Exists(shxfilename) = False Then
                MsgBox(shxfilename & "が見つかりません。", MsgBoxStyle.Exclamation)
                Return False
            End If

            Dim dbffilename = folder & "\" & System.IO.Path.GetFileNameWithoutExtension(fname) & ".dbf"
            If System.IO.File.Exists(dbffilename) = False Then
                MsgBox(dbffilename & "が見つかりません。", MsgBoxStyle.Exclamation)
                Return False
            End If

            Dim prjfilename = folder & "\" & System.IO.Path.GetFileNameWithoutExtension(fname) & ".prj"
            If System.IO.File.Exists(prjfilename) = False Then
                MsgBox(prjfilename & "が見つかりません。", MsgBoxStyle.Exclamation)
                Return False
            End If
            clsShapefile.Check_prj_file(prjfilename, zahyo)
            If i <> 0 Then
                If zahyo.System <> Ozahyo.System Then
                    MsgBox("測地系が異なるシェープファイルです。", MsgBoxStyle.Exclamation)
                    Return False
                End If
                If zahyo.Mode <> Ozahyo.Mode Then
                    MsgBox("緯度経度または平面直角座標系で揃えてください。", MsgBoxStyle.Exclamation)
                    Return False
                End If
                If zahyo.Mode = enmZahyo_mode_info.Zahyo_HeimenTyokkaku Then
                    If zahyo.HeimenTyokkaku_KEI_Number <> Ozahyo.HeimenTyokkaku_KEI_Number Then
                        MsgBox("平面直角座標系の系番号を揃えてください。", MsgBoxStyle.Exclamation)
                        Return False
                    End If
                End If
            End If
            Ozahyo = zahyo
        Next
        getZahyo = Ozahyo
        Year = DYear
        Return True
    End Function
    ''' <summary>
    ''' CSVファイルに出力
    ''' </summary>
    ''' <param name="defAttNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function outCSV(ByVal defAttNum As Integer) As Boolean

        Dim T As New System.Text.StringBuilder()
        T.Append("MAP" & vbCrLf)
        T.Append("LAYER,統計GIS国勢調査小地域データ" & vbCrLf)
        Dim ttl As String = "TITLE,都道府県名,郡市・特別区・政令指定都市名,区町村名,町丁・字等名称,KEYCODE"
        Dim UNT As String = "UNIT,STR,STR,STR,STR,STR"
        Dim MIS As String = "DATA_MISSING,OFF,OFF,OFF,OFF,OFF"
        Dim NOTE As String = "NOTE,,,,,"
        Dim Kecode_p As Integer = 0
        Dim Pref_p As Integer = 0
        Dim GST_p As Integer = 0
        Dim CSS_p As Integer = 0
        Dim S_Name_p As Integer = 0
        Dim datan As Integer
        With MapData.ObjectKind(0)
            datan = .DefTimeAttDataNum - defAttNum
            For i As Integer = defAttNum To .DefTimeAttDataNum - 1
                With .DefTimeAttSTC(i).attData
                    ttl += "," + .Title
                    UNT += "," + .Unit
                    If .MissingF = True Then
                        MIS += ",ON"
                    Else
                        MIS += ",OFF"
                    End If
                    NOTE += "," + .Note

                End With
            Next
            For i As Integer = 0 To defAttNum - 1
                Select Case .DefTimeAttSTC(i).attData.Title
                    Case "KEY_CODE"
                        Kecode_p = i
                    Case "PREF_NAME"
                        Pref_p = i
                    Case "GST_NAME"
                        GST_p = i
                    Case "CSS_NAME"
                        CSS_p = i
                    Case "S_NAME"
                        S_Name_p = i
                End Select
            Next

        End With
        T.Append(ttl & vbCrLf)
        T.Append(UNT & vbCrLf)
        T.Append(MIS & vbCrLf)
        T.Append(NOTE & vbCrLf)
        Dim code As New clsSortingSearch(Microsoft.VisualBasic.vbString)
        Dim mtx(datan + 5, MapData.Map.Kend - 1) As String
        Dim gn As Integer = 0
        For i As Integer = 0 To MapData.Map.Kend - 1
            With MapData.MPObj(i)
                mtx(0, gn) = .NameTimeSTC(0).NamesList(0)
                mtx(1, gn) = .DefTimeAttValue(Pref_p).Data(0).Value '県
                mtx(2, gn) = .DefTimeAttValue(GST_p).Data(0).Value '郡市・特別区・政令指定都市名
                mtx(3, gn) = .DefTimeAttValue(CSS_p).Data(0).Value '区町村名
                mtx(4, gn) = .DefTimeAttValue(S_Name_p).Data(0).Value '町丁字
                mtx(5, gn) = .DefTimeAttValue(Kecode_p).Data(0).Value 'キーコード
                code.Add(.DefTimeAttValue(Kecode_p).Data(0).Value)
                For j As Integer = 0 To datan - 1
                    mtx(j + 6, gn) = .DefTimeAttValue(j + defAttNum).Data(0).Value
                Next
                gn += 1
            End With
        Next
        code.AddEnd()
        For i As Integer = 0 To gn - 1
            Dim n As Integer = code.DataPosition(i)
            Dim tx As String = ""
            For j As Integer = 0 To datan + 5
                tx += mtx(j, n)
                If j <> datan + 5 Then
                    tx += ","
                Else
                    tx += vbCrLf
                End If
            Next
            T.Append(tx)
        Next

        'csvファイル出力
        Dim file_Path = FileSelect.Path
        Try
            Dim sw As New System.IO.StreamWriter(file_Path, False, System.Text.Encoding.GetEncoding("utf-8"))
            sw.Write(T.ToString)
            sw.Close()
        Catch ex As Exception
            Return False
        End Try
        '初期属性データの追加分を削除
        With MapData
            .ObjectKind(0).DefTimeAttDataNum = defAttNum
            ReDim Preserve .ObjectKind(0).DefTimeAttSTC(defAttNum - 1)
            For i As Integer = 0 To .Map.Kend - 1
                With .MPObj(i)
                    ReDim Preserve .DefTimeAttValue(defAttNum - 1)
                End With
            Next
        End With
        Return True
    End Function
    ''' <summary>
    ''' 統計txtファイル取得
    ''' </summary>
    ''' <param name="Folder"></param>
    ''' <param name="n"></param>
    ''' <param name="GCODE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_TokeiData(ByVal Folder As String, ByVal n As Integer, ByRef GCODE() As String) As Boolean

        Dim File_List() As String = System.IO.Directory.GetFiles(Folder, "*.txt", IO.SearchOption.TopDirectoryOnly)
        Dim FileN As Integer = File_List.Length
        If FileN = 0 Then
            MsgBox("属性テキストファイルがありません。")
            Return False
        End If
        Dim FileNameList(FileN - 1) As String

        For i As Integer = 0 To FileN - 1
            FileNameList(i) = System.IO.Path.GetFileName(File_List(i))
        Next
        Dim ObjNameS As New clsSortingSearch(VariantType.String)
        For i As Integer = 0 To MapData.Map.Kend - 1
            Dim EM As String = MapData.MPObj(i).NameTimeSTC(0).NamesList(0)
            If rbCode.Checked = True Then
                ObjNameS.Add(EM)
            Else
                ObjNameS.Add(Mid(EM, InStr(EM, "/") + 1))
            End If
        Next
        ObjNameS.AddEnd()


        Dim GCODE2(GCODE.Length - 1) As String
        '取得対象に揃っているtxtファイルを探す
        Dim DataGetn(150) As Integer
        For i As Integer = 0 To FileN - 1
            If Microsoft.VisualBasic.Left(UCase(FileNameList(i)), 3) = "TBL" Then
                Dim cd As String = Mid(System.IO.Path.GetFileNameWithoutExtension(FileNameList(i)), 12)
                For j As Integer = 0 To n - 1
                    If cd = Microsoft.VisualBasic.Left(GCODE(j), Len(cd)) Then
                        GCODE2(j) = cd
                        Dim Datai As Integer = Val(Mid(FileNameList(i), 5, 6))
                        If UBound(DataGetn) < Datai Then
                            ReDim Preserve DataGetn(Datai + 100)
                        End If
                        DataGetn(Datai) += 1
                    End If
                Next
            End If
        Next

        Dim getData As New List(Of Integer)
        For i As Integer = 0 To UBound(DataGetn)
            If DataGetn(i) = n Then
                getData.Add(i)
            End If
        Next
        If getData.Count = 0 Then
            MsgBox("選択市区町村分そろった属性テキストファイルがありません。", MsgBoxStyle.Exclamation)
            Return False
        End If
        ProgressLabel.Visible = True

        ProgressBar1.Maximum = getData.Count
        Dim UseFile As String = ""
        Dim newDefNum As Integer
        Dim oldnum As Integer
        For i As Integer = 0 To getData.Count - 1
            ProgressBar1.Value = i
            Dim DplusNum As Integer
            For j As Integer = 0 To n - 1
                Dim fileData As String = "T" + Microsoft.VisualBasic.Right("000000" & CStr(getData(i)), 6)
                Dim filename As String = "\tbl" & fileData & "C" & GCODE2(j) & ".txt"
                UseFile = UseFile & "tblT" & filename & vbCrLf
                filename = Folder & filename
                Dim sr As New System.IO.StreamReader(filename, System.Text.Encoding.GetEncoding("shift_jis"))
                Dim a1 As String = sr.ReadLine
                Dim a2 As String = sr.ReadLine
                Dim hitokugassanf() As Boolean
                If j = 0 Then
                    Dim DTopTitle() As String = Split(a1, ",")
                    Dim DTitle() As String = Split(a2, ",")
                    ReDim hitokugassanf(DTitle.Length - 1)
                    DplusNum = UBound(DTitle) + 1 - 5
                    With MapData.ObjectKind(0)
                        oldnum = .DefTimeAttDataNum
                        .DefTimeAttDataNum += DplusNum
                        newDefNum = .DefTimeAttDataNum
                        ReDim Preserve .DefTimeAttSTC(.DefTimeAttDataNum - 1)
                        For k As Integer = 0 To DplusNum - 1
                            If DTitle(5 + k) = "" Then
                                DTitle(5 + k) = DTopTitle(5 + k)
                            End If
                            With .DefTimeAttSTC(oldnum + k).attData
                                .Title = clsGeneric.Convert_DoubleByteWord_to_Single(DTitle(5 + k))
                                .MissingF = "TRUE"
                                Select Case UCase(.Title)
                                    Case "HTKSAKI"
                                        .Title = "秘匿先" + fileData
                                        .Unit = "STR"
                                        .MissingF = False
                                        hitokugassanf(k) = True
                                    Case "GASSAN"
                                        .Title = "合算" + fileData
                                        .Unit = "STR"
                                        .MissingF = False
                                        hitokugassanf(k) = True
                                End Select
                                .Note = fileData
                            End With
                        Next
                    End With
                End If
                Dim ZeroF As Boolean = rbZero.Checked
                Do Until sr.EndOfStream
                    Dim a As String = sr.ReadLine
                    a = Replace(a, "-", "0")
                    If ZeroF = True Then
                        a = Replace(a, "X", "0")
                    Else
                        a = Replace(a, "X", "")
                    End If
                    Dim DData() As String = Split(a, ",")
                    Dim Onum As Integer = ObjNameS.SearchData_One(DData(0))
                    If Onum <> -1 Then
                        With MapData.MPObj(Onum)
                            ReDim Preserve .DefTimeAttValue(newDefNum - 1)
                            For k As Integer = 0 To DplusNum - 1
                                Dim v As String = DData(5 + k)
                                If v = "" Then
                                    If ZeroF = True And hitokugassanf(k) = False Then
                                        v = "0"
                                    End If
                                End If
                                With .DefTimeAttValue(k + oldnum)
                                    ReDim .Data(0)
                                    .Data(0).Value = v
                                End With
                            Next
                        End With
                    End If
                Loop
                sr.Close()
            Next
        Next
        If rbName.Checked = True Then
            '町名で
            'キーコードを外しても同一小地域名が無い場合は，キーコードを外す
            Dim oname As New clsSortingSearch(vbString)
            For j As Integer = 0 To MapData.Map.Kend - 1
                Dim s As String = MapData.MPObj(j).NameTimeSTC(0).NamesList(0)
                s = Microsoft.VisualBasic.Left(s, s.IndexOf("/"))
                oname.Add(s)
            Next
            oname.AddEnd()
            Dim cn As Integer = 1
            Dim oname1 As String = oname.DataPositionValue_string(0)
            Dim oname1Pos As Integer = oname.DataPosition(0)
            Dim cn2 As Integer = 1
            Do
                Dim oname2 As String = oname.DataPositionValue_string(cn)
                If oname1 <> oname2 Then
                    If cn2 = 1 Then
                        MapData.MPObj(oname1Pos).NameTimeSTC(0).NamesList(0) = oname1
                    End If
                    oname1 = oname2
                    oname1Pos = oname.DataPosition(cn)
                    cn2 = 1
                    cn += 1
                Else
                    cn2 += 1
                    cn += 1
                End If
            Loop While cn <= MapData.Map.Kend - 1
            If cn2 = 1 Then
                MapData.MPObj(oname1Pos).NameTimeSTC(0).NamesList(0) = oname1
            End If
        End If
        '属性の追加されなかったオブジェクト（県外からの抜け地）を削除
        With MapData
            For i As Integer = .Map.Kend - 1 To 0 Step -1
                If .MPObj(i).DefTimeAttValue.Length < .ObjectKind(0).DefTimeAttDataNum Then
                    Dim delLine As New List(Of Integer)
                    With .MPObj(i)
                        For j As Integer = 0 To .NumOfLine - 1
                            delLine.Add(.LineCodeSTC(j).LineCode)
                        Next
                    End With
                    MapData.Erase_MultiLine(delLine, False, False, False)
                    MapData.EraseObject(i, False)
                End If
            Next

        End With
        Return True
    End Function
    ''' <summary>
    ''' 統計GISシェープファイル取得と変換
    ''' </summary>
    ''' <param name="Folder"></param>
    ''' <param name="DYear"></param>
    ''' <param name="n"></param>
    ''' <param name="GCODE"></param>
    ''' <param name="Zahyo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_TokeiMap(ByVal Folder As String, ByVal DYear As String, ByVal n As Integer, ByRef GCODE() As String, ByVal Zahyo As clsMapData.Zahyo_info) As Boolean
        '
        Dim Oalin As Long, Taisho_Line() As Boolean
        Dim Combinef() As Boolean

        MapData = New clsMapData()
        Dim UseFile As String = ""
        ProgressBar1.Maximum = n + 1
        ProgressLabel.Visible = True
        For i As Integer = 0 To n - 1
            ProgressBar1.Value = i + 1
            Dim filename As String = Folder & "\" & DYear & "ka" & GCODE(i) & ".shp"
            UseFile += DYear & "ka" & GCODE(i) & ".shp" & vbCrLf
            Dim newMapData As clsMapData = clsShapefile.Get_ShapeFile(filename, "", True, Zahyo, 932, False, ProgressLabel)
            If newMapData Is Nothing = True Then
                ProgressLabel.Visible = False
                Return False
            End If

            Dim Ken_P As Integer
            Dim Si_p As Integer
            Dim tyoson_p As Integer
            Dim Tyoutyou_p As Integer
            Dim Kecode_p As Integer
            Dim HCODE_p As Integer
            With newMapData.ObjectKind(0)
                For j As Integer = 0 To .DefTimeAttDataNum - 1
                    Select Case .DefTimeAttSTC(j).attData.Title
                        Case "KEN_NAME"
                            Ken_P = j
                        Case "GST_NAME"
                            Si_p = j
                        Case "CSS_NAME"
                            tyoson_p = j
                        Case "MOJI"
                            Tyoutyou_p = j
                        Case "KEY_CODE"
                            Kecode_p = j
                        Case "HCODE"
                            HCODE_p = j
                    End Select
                    .DefTimeAttSTC(j).attData.Note = "DBF"
                Next
            End With

            If chkWaterArea.Checked = False Then
                Dim delObj As New List(Of Integer)
                Dim delLine As New List(Of Integer)
                For j As Integer = 0 To newMapData.Map.Kend - 1
                    With newMapData.MPObj(j)
                        If .DefTimeAttValue(HCODE_p).Data(0).Value = "8154" Then
                            delObj.Add(j)
                            For k As Integer = 0 To .NumOfLine - 1
                                delLine.Add(.LineCodeSTC(k).LineCode)
                            Next
                        End If
                    End With
                Next
                If delObj.Count > 0 Then
                    newMapData.Erase_MultiObjects(delObj, False)
                    newMapData.Erase_MultiLine(delLine, False, False, True)
                End If
            End If
            If GCODE(i).Length = 2 Then
                '県単位のシェープファイルの場合は，市区町村単位に位相構造化
                Dim cd(newMapData.Map.Kend - 1) As String
                For j As Integer = 0 To newMapData.Map.Kend - 1
                    cd(j) = (Microsoft.VisualBasic.Left(newMapData.MPObj(j).DefTimeAttValue(Kecode_p).Data(0).Value, 5))
                Next
                Dim cdtype() As String = clsGeneric.Get_EachValueArray(cd)
                ProgressLabel.Visible = True
                ProgressLabel.Start(cdtype.Length, "位相構造化", True)
                For k As Integer = 0 To cdtype.Length - 1
                    ProgressLabel.SetValue(k)
                    My.Application.DoEvents()
                    Dim LIndex As New List(Of Integer)
                    Dim cds As String = cdtype(k)
                    For k2 As Integer = 0 To newMapData.Map.Kend - 1
                        With newMapData.MPObj(k2)
                            If cds = Microsoft.VisualBasic.Left(.DefTimeAttValue(Kecode_p).Data(0).Value, 5) Then
                                For k3 As Integer = 0 To .NumOfLine - 1
                                    LIndex.Add(.LineCodeSTC(k3).LineCode)
                                Next
                            End If
                        End With
                    Next
                    newMapData.TopologyStructure_SameLine(LIndex)
                Next
                ProgressLabel.Visible = False
            Else
                newMapData.TopologyStructure_SameLine()
            End If
            For j As Integer = 0 To newMapData.Map.Kend - 1
                With newMapData.MPObj(j)
                    Dim w0 As String = .DefTimeAttValue(Ken_P).Data(0).Value
                    Dim w1 As String = .DefTimeAttValue(Si_p).Data(0).Value
                    Dim w2 As String = .DefTimeAttValue(tyoson_p).Data(0).Value
                    Dim w3 As String = .DefTimeAttValue(Tyoutyou_p).Data(0).Value
                    If w1 = "0" Then
                        w1 = ""
                    End If
                    If w2 = "0" Then
                        w2 = ""
                    End If
                    If rbCode.Checked = True Then
                        .NameTimeSTC(0).NamesList(0) = .DefTimeAttValue(Kecode_p).Data(0).Value
                    Else
                        If cbAddPrefName.Checked = False Then
                            w0 = ""
                        End If
                        .NameTimeSTC(0).NamesList(0) = w0 & w1 & w2 & w3 & "/" & .DefTimeAttValue(Kecode_p).Data(0).Value
                    End If
                End With
            Next
            Dim conbj As String = ""
            newMapData.CombineSameNameObjecs(conbj)

            If i = 0 Then
                MapData = newMapData.Clone
                MapData.Map.FileName = System.IO.Path.ChangeExtension(MapData.Map.FileName, ".mpfz")
            Else
                MapData.InsertMapData(newMapData, "")
            End If
        Next
        Dim bl(n - 1) As Boolean
        clsGeneric.FillArray(bl, True)

        With MapData
            .Combine_Linekinds(bl, "町丁・字等境界", clsBase.Line)
            .Combine_Objectkinds(bl, "統計GIS小地域")
            .init_Compass_First()
            .countNumOfLineUse()
            .Add_OneLineKind("市区町村外周線", clsBase.BoldLine, enmMesh_Number.mhNonMesh)
            For i As Integer = 0 To .Map.ALIN - 1
                With .MPLine(i)
                    If .NumOfLineUse = 1 Then
                        .LineTimeSTC(0).Kind = 1
                    End If
                End With
            Next
            .CheckLine_Kind_UsedBy_ObjectKind(.ObjectKind(0).Name + vbTab + .LineKind(0).Name + vbTab + .LineKind(1).Name)
        End With
        MapData.Map.Comment += "統計GIS国勢調査小地域データ" + DYear + "年"
        ProgressLabel.Visible = False
        Return True
    End Function

    Private Sub frmMED_CensusGISData_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmMED_CensusGISData", Me)
        e.Cancel = True
    End Sub


    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub
End Class