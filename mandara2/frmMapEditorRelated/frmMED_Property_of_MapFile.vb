Public Class frmMED_Property_of_MapFile
    Dim MapData As clsMapData
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByRef MPData As clsMapData) As Windows.Forms.DialogResult
        MapData = MPData
        txtComment.Text = MapData.Map.Comment
        cbCompass.Checked = MapData.Map.MapCompass.Visible
        cbDistance.Checked = MapData.Map.Detail.DistanceMeasurable
        cbScale.Checked = MapData.Map.Detail.ScaleVisible

        Dim LData As New List(Of String)
        With MapData
            With .Map
                LData.Add("項目" + vbTab + "値")
                LData.Add("地図ファイル名" + vbTab + .FileName)
                LData.Add("パス" + vbTab + .FullPath)
                If .Time_Mode = True Then
                    LData.Add("時空間モード" + vbTab + "on")
                    Dim setime As Start_End_Time_data = MapData.Get_duration_of_AllMapTimeSetting()
                    LData.Add("最も古い時間設定" + vbTab + setime.StartTime.toString)
                    LData.Add("最も新しい時間設定" + vbTab + setime.EndTime.toString)
                Else
                    LData.Add("時空間モード" + vbTab + "off")
                End If
                LData.Add("座標系" + vbTab + clsGeneric.getZahyouKeiStrings(.Zahyo))
                LData.Add("測地系" + vbTab + clsGeneric.getSokutikeiStrings(.Zahyo.System))
                Select Case .Zahyo.Mode
                    Case enmZahyo_mode_info.Zahyo_No_Mode
                        LData.Add("スケール値" + vbTab + .SCL.ToString)
                        LData.Add("スケール単位" + vbTab + clsGeneric.getScaleUnitStrings(.SCL_U))

                    Case enmZahyo_mode_info.Zahyo_Ido_Keido
                        LData.Add("投影法" + vbTab + clsGeneric.getStringProjectionEnum(.Zahyo.Projection))
                End Select
                LData.Add("" + vbTab + "")
                LData.Add("オブジェクトグループ数" + vbTab + .OBKNum.ToString)
                Dim aggrObj() As String = MapData.Get_ObjectGroupNameList(clsMapData.enmObjectGoupType_Data.AggregationObject)
                If aggrObj Is Nothing Then
                    LData.Add("　うち集成オブジェクトグループ" + vbTab + "0")
                Else
                    LData.Add("　うち集成オブジェクトグループ" + vbTab + aggrObj.Length.ToString)
                End If
                LData.Add("オブジェクト数" + vbTab + .Kend.ToString)
                LData.Add("線種数" + vbTab + .LpNum.ToString)
                LData.Add("ライン数" + vbTab + .ALIN.ToString)
                LData.Add("ポイント数" + vbTab + MapData.Get_All_MpLinePoint.ToString)
                LData.Add("" + vbTab + "")
            End With
            LData.Add("オブジェクトグループ名" + vbTab + "オブジェクト数")
            Dim ObjGname() As String = .Get_ObjectGroupNameList()
            Dim objgN() As Integer = .Get_ObjectKind_Use_Number()
            For i As Integer = 0 To .Map.OBKNum - 1
                LData.Add(ObjGname(i) + vbTab + objgN(i).ToString)
            Next
            LData.Add("" + vbTab + "")
            LData.Add("線種名" + vbTab + "ライン数")
            Dim LKname() As String = .Get_LineKindNameList()
            Dim LKN() As Integer = .Get_LineKind_Use_Number()
            For i As Integer = 0 To .Map.LpNum - 1
                LData.Add(LKname(i) + vbTab + LKN(i).ToString)
            Next

        End With

        ListViewEX.SetData(LData, {Microsoft.VisualBasic.VariantType.String, Microsoft.VisualBasic.VariantType.String}, {False, False}, False)


        Return Me.ShowDialog(Owner)
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        MapData.Map.Comment = txtComment.Text
        MapData.Map.MapCompass.Visible = cbCompass.Checked
        MapData.Map.Detail.DistanceMeasurable = cbDistance.Checked
        MapData.Map.Detail.ScaleVisible = cbScale.Checked
    End Sub

    Private Sub frmMED_Property_of_MapFile_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        e.Cancel = True
        clsGeneric.HelpShow(enmHelpFile.MapEditor, "frmPrint_Property", Me)
    End Sub
End Class