Public Class frmMessage
    Public Enum MessageType
        text = 1
        list = 2
        grid = 3
    End Enum
    Dim CloseCancelF As Boolean
    Dim ViewMode As MessageType
    Dim GridData(,) As String

    Private Sub frmMessage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    ''' <summary>
    ''' リストビュー形式でデータを表示
    ''' </summary>
    ''' <param name="Owner">オーナーフォーム</param>
    ''' <param name="Title">タイトル</param>
    ''' <param name="ListData">表示する配列データ・横方向はタブ区切り</param>
    ''' <param name="VariType">ヘッダの列数分の配列、VariTypeはStringとそれ以外しかない</param>
    ''' <param name="SortingFlag">ヘッダの列数分の配列で、並べ替えをするか。Falseの場合列の並べ替えは無し、ヘッダの列数分の配列</param>
    ''' <param name="RowNumberFlag">trueにすると左端に行番号がつく</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal Title As String, ByVal ListData As List(Of String), _
                                         ByRef VariType() As VariantType, ByRef SortingFlag() As Boolean, ByVal RowNumberFlag As Boolean) As Windows.Forms.DialogResult
        Me.Text = Title
        btnCancel.Visible = True
        TextBox.Visible = False
        ListViewEX.Visible = True
        btnCancel.Visible = False
        ktGrid.Visible = False
        ViewMode = MessageType.list
        ListViewEX.SetData(ListData, VariType, SortingFlag, RowNumberFlag)
        Return Me.ShowDialog(Owner)
    End Function
    ''' <summary>
    ''' テキスト形式でメッセージを表示
    ''' </summary>
    ''' <param name="Owner">オーナーフォーム</param>
    ''' <param name="Title">タイトル</param>
    ''' <param name="Message">メッセージテキスト</param>
    ''' <param name="ReadOnlyF">読み取り専用の場合true</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal Title As String, ByVal Message As String, ByVal ReadOnlyF As Boolean) As Windows.Forms.DialogResult
        Me.Text = Title
        btnCancel.Visible = True
        ListViewEX.Visible = False
        TextBox.Text = Message
        TextBox.Select(0, 0)
        TextBox.ReadOnly = ReadOnlyF
        TextBox.Visible = True
        ktGrid.Visible = False
        ViewMode = MessageType.text
        Return Me.ShowDialog(Owner)
    End Function
    ''' <summary>
    ''' グリッド形式でメッセージを表示
    ''' </summary>
    ''' <param name="Owner"></param>
    ''' <param name="Title"></param>
    ''' <param name="GrridData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal Owner As IWin32Window, ByVal Title As String, ByVal _GridData(,) As String) As Windows.Forms.DialogResult
        Me.Text = Title
        GridData = _GridData
        TextBox.Visible = False
        ktGrid.Visible = True
        ListViewEX.Visible = False
        ktGrid.init("", "行", "列", 1, 1, 1, 1, False, False, False, False, False, False, False, False, False, False)
        Dim xs As Integer = GridData.GetLength(0)
        Dim ys As Integer = GridData.GetLength(1)
        ktGrid.DefaultGridAlligntment = HorizontalAlignment.Left
        ktGrid.AddLayer("", 0, xs, ys)
        ktGrid.FixedXSWidth(0, 0) = 30
        For i As Integer = 0 To xs - 1
            For j As Integer = 0 To ys - 1
                ktGrid.GridData(0, i, j) = GridData(i, j)
            Next
        Next
        ktGrid.Show()
        ViewMode = MessageType.grid
        Return Me.ShowDialog(Owner)
    End Function
    ''' <summary>
    ''' ViewMode = MessageType.textの時はテキストを返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getResult() As String
        If ViewMode = MessageType.text Then
            Return TextBox.Text
        End If
    End Function
    ''' <summary>
    ''' テキスト形式でメッセージをモーダレス表示
    ''' </summary>
    ''' <param name="Owner">オーナーフォーム</param>
    ''' <param name="Title">タイトル</param>
    ''' <param name="Message">メッセージテキスト</param>
    ''' <param name="ReadOnlyF">読み取り専用の場合true</param>
    ''' <remarks></remarks>
    Public Overloads Sub Show(ByRef Owner As Form, ByVal Title As String, ByVal Message As String, ByVal ReadOnlyF As Boolean)
        Me.Text = Title
        btnCancel.Visible = False
        ktGrid.Visible = False
        ListViewEX.Visible = False
        TextBox.ReadOnly = ReadOnlyF
        TextBox.Text = Message
        TextBox.Select(0, 0)
        TextBox.Visible = True

        ViewMode = MessageType.text
        Me.Owner = Owner
        CenterMe()
        Me.Show()
    End Sub
    ''' <summary>
    ''' リストビュー形式でデータをモーダレス表示
    ''' </summary>
    ''' <param name="Owner">オーナーフォーム</param>
    ''' <param name="Title">タイトル</param>
    ''' <param name="ListData">表示する配列データ・横方向はタブ区切り</param>
    ''' <param name="VariType">ヘッダの列数分の配列、VariTypeはStringとそれ以外しかない</param>
    ''' <param name="SortingFlag">ヘッダの列数分の配列で、並べ替えをするか。Falseの場合列の並べ替えは無し、ヘッダの列数分の配列</param>
    ''' <param name="RowNumberFlag">trueにすると左端に行番号がつく</param>
    ''' <remarks></remarks>
    Public Overloads Sub Show(ByVal Owner As Form, ByVal Title As String, ByVal ListData As List(Of String), _
                                         ByRef VariType() As VariantType, ByRef SortingFlag() As Boolean, ByVal RowNumberFlag As Boolean)
        Me.Text = Title
        ktGrid.Visible = False
        btnCancel.Visible = True
        TextBox.Visible = False
        ListViewEX.Visible = True
        btnCancel.Visible = False
        ViewMode = MessageType.list
        ListViewEX.SetData(ListData, VariType, SortingFlag, RowNumberFlag)
        Me.Owner = Owner
        CenterMe()
        Me.Show()
    End Sub
    ''' <summary>
    ''' 'モードレスフォームの場合はオーナーフォームの中央に設定するにはマニュアルで設定してやる
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CenterMe()
        Me.StartPosition = FormStartPosition.Manual
        Me.Left = Owner.Left + (Owner.Width - Me.Width) \ 2
        Me.Top = Owner.Top + (Owner.Height - Me.Height) \ 2
    End Sub
    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Select Case ViewMode
            Case MessageType.text
                Clipboard.SetText(TextBox.Text)
            Case MessageType.list
                ListViewEX.copyData()
            Case MessageType.grid
                With GridData
                    Dim xs As Integer = .GetLength(0)
                    Dim Ys As Integer = .GetLength(1)
                    Dim a As String = Me.Text + vbCrLf
                    For i As Integer = 0 To Ys - 1
                        For j As Integer = 0 To xs - 1
                            a += GridData(j, i)
                            If j = xs - 1 Then
                                a += vbCrLf
                            Else
                                a += vbTab
                            End If
                        Next
                    Next
                    Clipboard.SetText(a)
                End With
        End Select
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.Modal = False Then
            Me.close
        End If
    End Sub
End Class