Public Class frmMain_SetPositionFromData
    Public Enum enmChangeMode
        symbol
        label
    End Enum
    Dim CloseCancelF As Boolean
    Dim attrData As clsAttrData
    Dim ChangePos As enmChangeMode
    Dim Layer As Integer
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
    Public Overloads Function ShowDialog(ByRef attr As clsAttrData, ByVal _Layer As Integer, ByRef Change As enmChangeMode) As Windows.Forms.DialogResult
        attrData = attr
        Layer = _Layer
        ChangePos = Change
        cboLat.Items.Clear()
        cboLon.Items.Clear()
        Dim tx(attr.Get_DataNum(Layer)) As String
        tx(0) = "変更なし"
        For i As Integer = 0 To attr.Get_DataNum(Layer) - 1
            tx(i + 1) = attr.LayerData(Layer).atrData.Data(i).Title
            Select Case attr.LayerData(Layer).atrData.Data(i).DataType
                Case enmAttDataType.Strings, enmAttDataType.Category
                    tx(i + 1) = "*" + tx(i + 1)
            End Select
        Next
        cboLat.Items.AddRange(tx)
        cboLon.Items.AddRange(tx)
        cboLat.SelectedIndex = 0
        cboLon.SelectedIndex = 0
        Select Case ChangePos
            Case enmChangeMode.label
                Me.Text = "ラベル表示位置の座標設定"
            Case enmChangeMode.symbol
                Me.Text = "記号表示位置の座標設定"
        End Select
        lbLayer.Text = "設定レイヤ:" + attrData.LayerData(Layer).Name
        Return Me.ShowDialog

    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim lat As Integer = cboLat.SelectedIndex - 1
        Dim lon As Integer = cboLon.SelectedIndex - 1
        If lat = -1 And lon = -1 Then
            MsgBox("選択されていません。", MsgBoxStyle.Exclamation)
            CloseCancelF = True
            Return
        End If
        If lat <> -1 Then
            With attrData.LayerData(Layer).atrData.Data(lat)
                If .Statistics.Max > 90 Or .Statistics.Min < -90 Then
                    MsgBox(.Title + "の最大値・最小値が90/-90を超えています。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
            End With
        End If
        If lon <> -1 Then
            With attrData.LayerData(Layer).atrData.Data(lon)
                If .Statistics.Max > 180 Or .Statistics.Min < -180 Then
                    MsgBox(.Title + "の最大値・最小値が180/-180を超えています。", MsgBoxStyle.Exclamation)
                    CloseCancelF = True
                    Return
                End If
            End With
        End If

        Dim n As Integer = attrData.Get_ObjectNum(Layer)
        Dim OriPos(n - 1) As PointF
        Dim zahyo As clsMapData.Zahyo_info = attrData.TotalData.ViewStyle.Zahyo

        For i As Integer = 0 To n - 1
            With attrData.LayerData(Layer).atrObject.atrObjectData(i)
                Select Case ChangePos
                    Case enmChangeMode.label
                        OriPos(i) = spatial.Get_Reverse_XY(.Label, zahyo)
                    Case enmChangeMode.symbol
                        OriPos(i) = spatial.Get_Reverse_XY(.Symbol, zahyo)
                End Select
            End With
        Next

        If lat <> -1 Then
            Dim Data() As clsAttrData.strObjLocation_and_Data_info = attrData.Get_Data_Cell_Array_Without_MissingValue(Layer, lat)
            For i As Integer = 0 To Data.Length - 1
                OriPos(Data(i).ObjLocation).Y = Val(Data(i).DataValue)
            Next
        End If

        If lon <> -1 Then
            Dim Data() As clsAttrData.strObjLocation_and_Data_info = attrData.Get_Data_Cell_Array_Without_MissingValue(Layer, lon)
            For i As Integer = 0 To Data.Length - 1
                OriPos(Data(i).ObjLocation).X = Val(Data(i).DataValue)
            Next
        End If

        For i As Integer = 0 To n - 1
            With attrData.LayerData(Layer).atrObject.atrObjectData(i)
                Dim P As PointF = spatial.Get_Converted_XY(OriPos(i), zahyo)
                Select Case ChangePos
                    Case enmChangeMode.label
                        .Label = P
                    Case enmChangeMode.symbol
                        .Symbol = P
                End Select
            End With
        Next

        MsgBox(Me.Text & "を行いました。")
    End Sub
End Class