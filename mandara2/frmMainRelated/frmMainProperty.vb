Public Class frmMain_Property
    Private AttrData As clsAttrData
    Public Overloads Sub ShowDialog(ByVal Owner As IWin32Window, ByRef _AttrData As clsAttrData)
        AttrData = _AttrData
        txtComment.Text = AttrData.TotalData.LV1.Comment
        Dim LData As New List(Of String)
        LData.Add("項目" + vbTab + "値")

        With AttrData
            LData.Add("地図ファイル数" + vbTab + .GetNumOfMapFile.ToString)
            Dim mf As String() = .GetMapFileName
            Dim mfx As String = String.Join("/", mf)
            LData.Add("地図ファイル" + vbTab + mfx)
            LData.Add("レイヤ数" + vbTab + .TotalData.LV1.Lay_Maxn.ToString)
            LData.Add("" + vbTab + "")
            For i As Integer = 0 To .TotalData.LV1.Lay_Maxn - 1
                With .LayerData(i)
                    LData.Add("レイヤ" + vbTab + .Name)
                    LData.Add("地図ファイル" + vbTab + .MapFileName)
                    LData.Add("種類" + vbTab + clsGeneric.ConvertStringLayerTypeString(.Type))
                    LData.Add("形状" + vbTab + clsGeneric.ConvertShapeEnumString(.Shape))
                    LData.Add("時間" + vbTab + clsTime.YMDtoString(.Time))
                    LData.Add("コメント" + vbTab + .Comment)
                    LData.Add("オブジェクト数" + vbTab + .atrObject.ObjectNum.ToString)
                    LData.Add("データ項目数" + vbTab + .atrData.Count.ToString)
                    LData.Add("ダミーオブジェクト数" + vbTab + .Dummy.Count.ToString)
                End With
                LData.Add("" + vbTab + "")
            Next
        End With

        ListViewEX.SetData(LData, {Microsoft.VisualBasic.VariantType.String, Microsoft.VisualBasic.VariantType.String}, {False, False}, False)
        Me.ShowDialog(Owner)

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        AttrData.TotalData.LV1.Comment = txtComment.Text
    End Sub
End Class