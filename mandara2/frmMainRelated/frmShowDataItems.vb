Public Class frmShowDataItems
    Public Overloads Function ShowDialog(ByRef attr As clsAttrData) As DialogResult
        Dim s As System.Windows.Forms.Screen = System.Windows.Forms.Screen.FromControl(Me)
        Me.Width = s.Bounds.Width / 1.5
        Me.Height = s.Bounds.Height / 1.5
        ktGrid.init("レイヤ", "データ項目", "", 2, 1, 2, 1, False, True, False, False, False, False, False, False, True, False)
        ktGrid.DefaultFixedYSAllignment = HorizontalAlignment.Center
        ktGrid.DefaultGridWidth = 90
        Dim data As String() = {"オブジェクト数", "非欠損値オブジェクト", "欠損値オブジェクト", "データの種類", "単位", "カテゴリー数",
                                "最大値", "最小値", "合計値", "平均値", "中央値", "標準偏差", "分散"}
        For i As Integer = 0 To attr.TotalData.LV1.Lay_Maxn - 1
            With attr.LayerData(i)
                ktGrid.AddLayer(.Name, i, data.Length, .atrData.Count, False, True, False, False, False, False, False, False)
                ktGrid.FixedUpperLeftData(i, 1, 1) = "データ項目"
                For j As Integer = 0 To data.Length - 1
                    ktGrid.FixedYSData(i, j, 1) = data(j)
                Next
                Dim onum = .atrObject.ObjectNum
                ktGrid.FixedYSHeight(i, 1) = 38
                For j As Integer = 0 To .atrData.Count - 1
                    ktGrid.GridHeight(i, j) = 20
                    ktGrid.GridAlligntment(i, 3) = HorizontalAlignment.Left
                    ktGrid.GridAlligntment(i, 4) = HorizontalAlignment.Left
                    ktGrid.GridWidth(i, 0) = 60
                    ktGrid.GridWidth(i, 1) = 60
                    ktGrid.GridWidth(i, 2) = 60
                    ktGrid.GridWidth(i, 5) = 50
                    With .atrData.Data(j)
                        ktGrid.FixedXSData(i, 1, j) = .Title
                        ktGrid.GridData(i, 0, j) = onum
                        ktGrid.GridData(i, 1, j) = onum - .MissingValueNum
                        ktGrid.GridData(i, 2, j) = .MissingValueNum
                        ktGrid.GridData(i, 3, j) = clsGeneric.ConvertAttDataTypeString(.DataType)
                        ktGrid.GridData(i, 4, j) = .Unit
                        Select Case .DataType
                            Case enmAttDataType.Category
                                ktGrid.GridData(i, 5, j) = .SoloModeViewSettings.Div_Num
                            Case enmAttDataType.Strings
                            Case enmAttDataType.Normal
                                ktGrid.GridData(i, 6, j) = .Statistics.Max
                                ktGrid.GridData(i, 7, j) = .Statistics.Min
                                ktGrid.GridData(i, 8, j) = .Statistics.Sum
                                ktGrid.GridData(i, 9, j) = .Statistics.Ave
                                ktGrid.GridData(i, 10, j) = attr.Get_MedianValue(i, j).ToString
                                ktGrid.GridData(i, 11, j) = .Statistics.STD
                                ktGrid.GridData(i, 12, j) = .Statistics.STD ^ 2
                        End Select
                    End With
                Next
            End With
        Next
        ktGrid.Show()
        ktGrid.SetGridPosition(attr.TotalData.LV1.SelectedLayer, 0, 0)
        Return Me.ShowDialog()
    End Function

End Class