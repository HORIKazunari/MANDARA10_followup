Public Class frmMain_ShapefileOut
    Dim CloseCancelF As Boolean
    Dim Attr As clsAttrData
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
    Public Overloads Function ShowDialog(ByRef _Attr As clsAttrData) As Windows.Forms.DialogResult
        Attr = _Attr
        Attr.Set_LayerName_to(cboLayer, Attr.TotalData.LV1.SelectedLayer, True, False, True, True, False, False)

        Return Me.ShowDialog

    End Function
    Public Function GetResults()

    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If clsGeneric.Check_Folder_Exists(fileSelect.Path) = False Then
            CloseCancelF = True
            Return
        End If

        Dim Layernum As Integer = cboLayer.SelectedIndex
        If Layernum = -1 Then
            MsgBox("出力レイヤを選択してください。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
        Dim TempSData() As String

        Dim Ltype As clsAttrData.enmLayerType = Attr.LayerData(Layernum).Type

        Dim n As Integer = Attr.LayerData(Layernum).atrObject.ObjectNum

        Dim Data_Item_n As Integer = Attr.Get_DataNum(Layernum)  '一つめはオブジェクト名
        Dim Data_Title(Data_Item_n) As String
        Dim Data_STR_F(Data_Item_n) As Boolean
        Data_Title(0) = "ObjName"
        Data_STR_F(0) = True
        For i As Integer = 0 To Data_Item_n - 1
            Data_Title(i + 1) = Attr.Get_DataTitle(Layernum, i, False)
            If clsGeneric.check_Moji(Data_Title(i + 1)) = True Then
                Data_Title(i + 1) = "Data" & CStr(i + 1)
            Else
                If Len(Data_Title(i + 1)) > 10 Then
                    Data_Title(i + 1) = Microsoft.VisualBasic.Left(Data_Title(i + 1), 10)
                End If
            End If
            If Attr.Get_DataType(Layernum, i) <> enmAttDataType.Normal Then
                Data_STR_F(i + 1) = True
            Else
                Data_STR_F(i + 1) = False
            End If
        Next

        Dim StrData(Data_Item_n, n - 1) As String
        Dim TempVData(n - 1) As String
        For i As Integer = 0 To Data_Item_n - 1
            TempSData = Attr.Get_Data_Cell_Array_With_MissingValue(Layernum, i, Attr.TotalData.ViewStyle.Missing_Data.Text)
            For j As Integer = 0 To n - 1
                StrData(i + 1, j) = TempSData(j)
            Next
        Next
        For i As Integer = 0 To n - 1
            StrData(0, i) = Attr.Get_KenObjName(Layernum, i)
        Next

        Dim ecode As clsEncodings = DirectCast(cboEncoding.SelectedItem, clsEncodings)
        Dim encodingnumber = ecode.eis.CodePage


        Cursor = Cursors.WaitCursor
        Dim f As Boolean
        Select Case Ltype
            Case clsAttrData.enmLayerType.DefPoint
                Dim XY(n - 1) As PointF
                For i As Integer = 0 To n - 1
                    XY(i) = Attr.LayerData(Layernum).atrObject.atrObjectData(i).Symbol
                Next
                f = clsShapefile.defPointShapeFileOut(Attr.LayerData(Layernum).MapFileData.Map.Zahyo, fileSelect.Path, n, XY,
                                                              Data_Item_n + 1, Data_Title, Data_STR_F, StrData, encodingnumber)
            Case clsAttrData.enmLayerType.Mesh
                Dim XY(n * 4 - 1) As PointF
                Dim meshRect(n - 1) As RectangleF
                For i As Integer = 0 To n - 1
                    With Attr.LayerData(Layernum).atrObject.atrObjectData(i)
                        For j As Integer = 0 To 3
                            XY(i * 4 + j) = .MeshPoint(j)
                        Next
                        meshRect(i) = .MeshRect
                    End With
                Next
                f = clsShapefile.meshShapeFileOut(Attr.LayerData(Layernum).MapFileData.Map.Zahyo, Attr.LayerData(Layernum).Shape, fileSelect.Path, n, XY, meshRect,
                                                              Data_Item_n + 1, Data_Title, Data_STR_F, StrData, encodingnumber)
            Case clsAttrData.enmLayerType.Normal
                Dim Objs(n - 1) As Integer
                For i As Integer = 0 To n - 1
                    Objs(i) = Attr.Get_KenObjCode(Layernum, i)
                Next
                f = clsShapefile.ShapeFileOut(Attr.LayerData(Layernum).MapFileData, fileSelect.Path, n, Objs,
                                                             Attr.LayerData(Layernum).Time, Data_Item_n + 1, Data_Title, Data_STR_F, StrData, encodingnumber)
        End Select
        Cursor = Cursors.Default
        If f = True Then
            MsgBox(fileSelect.Path & "に出力しました。")
        Else
            MsgBox(fileSelect.Path & "は保存できませんでした。")
        End If

    End Sub

    Private Sub frmMain_ShapefileOut_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked

        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.SettingWindow, "frmMain_ShapefileOut", Me)
    End Sub


    Private Sub frmMain_ShapefileOut_Load(sender As Object, e As EventArgs) Handles Me.Load
        clsGeneric.SetEncodings_to_Cbobox(cboEncoding)
        cboEncoding.SelectedIndex = 0
    End Sub
End Class