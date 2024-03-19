Public Class frmSelectListBox
    Public Enum enmListType
        ListBox = 0
        CheckedListBox = 1
    End Enum
    Dim ListBoxF As Boolean
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Lists">アイテムの文字列配列</param>
    ''' <param name="PreSelected">アイテムの選択状態の初期状態の配列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal Title As String, ByRef Lists() As String, ByVal PreSelected() As Boolean, ByVal ListType As enmListType)
        clsGeneric.set_FormPosition_toMousePosition(Me, VisualStyles.VerticalAlignment.Top)
        Me.Text = Title
        Select Case ListType
            Case enmListType.ListBox
                CheckedListBoxEx.Visible = False
                With ListBoxEx
                    .Visible = True
                    .Items.Clear()
                    .Items.AddRange(Lists)
                    For i As Integer = 0 To Lists.Length - 1
                        .SetSelected(i, PreSelected(i))
                    Next
                End With
                ListBoxF = True
            Case enmListType.CheckedListBox
                ListBoxEx.Visible = False
                With CheckedListBoxEx
                    .Visible = True
                    .Items.Clear()
                    .Items.AddRange(Lists)
                    For i As Integer = 0 To Lists.Length - 1
                        .SetItemChecked(i, PreSelected(i))
                    Next
                End With
                ListBoxF = False
        End Select
        Return Me.ShowDialog()
    End Function
    ''' <summary>
    ''' リストの選択状況を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResults()
        Dim Sel() As Boolean
        If ListBoxF = True Then
            Dim n As Integer = Me.ListBoxEx.Items.Count
            ReDim Sel(n - 1)
            For i As Integer = 0 To n - 1
                Sel(i) = ListBoxEx.GetSelected(i)
            Next
        Else
            Dim n As Integer = Me.CheckedListBoxEx.Items.Count
            ReDim Sel(n - 1)
            For i As Integer = 0 To n - 1
                Sel(i) = CheckedListBoxEx.GetItemChecked(i)
            Next
        End If
        Return Sel
    End Function
End Class