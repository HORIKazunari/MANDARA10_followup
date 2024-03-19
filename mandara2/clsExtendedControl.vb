'拡張コントロールいろいろ

Public Class DataGridViewControlComboBox
    'データグリッドコントロールを使って、二列、右側がコンボボックスのコントロールを作成
    Inherits System.Windows.Forms.DataGridView
    Friend WithEvents ComboBoxEx1 As mandara10.ComboBoxEx
    Public Sub New()
        Me.AllowUserToAddRows = False
        Me.AllowUserToDeleteRows = False
        Me.AllowUserToOrderColumns = False
        Me.ClipboardCopyMode = False

    End Sub
    Public Sub SetData(ByVal HeaderLeftText As String, ByVal DataCount As Integer, _
                     ByVal LeftText() As String, ByVal Value() As Integer, ByVal ComboBoxColumn As DataGridViewComboBoxColumn, Optional ByVal CenterX As Integer = -1)
        Me.Rows.Clear()
        Me.Columns.Clear()
        Me.ScrollBars = ScrollBars.Vertical
        Dim leftcolumn As New DataGridViewTextBoxColumn
        leftcolumn.HeaderText = HeaderLeftText
        leftcolumn.ReadOnly = True
        leftcolumn.SortMode = DataGridViewColumnSortMode.NotSortable
        ComboBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.Columns.Add(leftcolumn)
        Me.Columns.Add(ComboBoxColumn)
        Me.Rows.Add(DataCount)
        For i As Integer = 0 To DataCount - 1
            Me.Item(0, i).Value = LeftText(i)
            Me.Item(1, i).Value = ComboBoxColumn.Items(Value(i))
        Next
        Dim w As Integer = Me.Width - Me.RowHeadersWidth
        If Me.Controls(1).Visible = True Then
            w = w - 25
        End If
        If CenterX = -1 Then
            Me.Columns(0).Width = w / 2
            Me.Columns(1).Width = w / 2
        Else
            Me.Columns(0).Width = CenterX
            Me.Columns(1).Width = w - CenterX
        End If
        Me.CurrentCell = Me.Item(1, 0)
    End Sub
    Public Function GetValue() As Integer()
        Dim n As Integer = Me.RowCount
        Dim value(n - 1) As Integer
        Dim g As DataGridViewComboBoxColumn = Me.Columns(1)
        For i As Integer = 0 To n - 1
            Dim v As String = Me.Item(1, i).Value
            value(i) = g.Items.IndexOf(v)
        Next
        Return value
    End Function
    Private Sub dgvGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellEnter
        If e.ColumnIndex = 1 Then
            SendKeys.Send("{F4}")
        End If
    End Sub

    Private Sub InitializeComponent()
        Me.ComboBoxEx1 = New mandara10.ComboBoxEx()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.AsteriskSelectEnabled = False
        Me.ComboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.IntegralHeight = False
        Me.ComboBoxEx1.Location = New System.Drawing.Point(0, 0)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(121, 23)
        Me.ComboBoxEx1.TabIndex = 0
        '
        'DataGridViewControlComboBox
        '
        Me.RowTemplate.Height = 24
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class
Public Class ComboBoxEx
    'コンボボックスで、文字列の長さに応じてドロップダウンの幅を変える拡張コンボボックス
    Inherits System.Windows.Forms.ComboBox
    Private _AsteriskSelectEnabled As Boolean
    Private lastSelectedIndex As Integer
    Private ToolTip1 As ToolTip
    Public Sub New()
        Me.IntegralHeight = False 'MaxDropDownItemsプロパティを有効にするため
        Me._AsteriskSelectEnabled = False
        Me.DropDownStyle = ComboBoxStyle.DropDownList
        Me.lastSelectedIndex = -1
        ToolTip1 = New ToolTip()
        ToolTip1.InitialDelay = 1
    End Sub
    Private Sub ComboBoxEx_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DropDown
        Dim maxSize As Integer = 0
        For Each item As Object In Me.Items
            ' ComboBoxのフォントを使ってサイズ計測
            maxSize = Math.Max(maxSize, TextRenderer.MeasureText(item.ToString, Me.Font).Width)
        Next

        ' リストがMaxDropDownItemsより多い場合はスクロールバーが出るため、その分を追加する（固定20px）
        If Me.MaxDropDownItems < Me.Items.Count Then
            maxSize += 20
        End If

        ' 現在の設定より大きければ置換
        If Me.DropDownWidth < maxSize Then
            Me.DropDownWidth = maxSize
        End If

    End Sub
    ''' <summary>
    ''' 先頭がアスタリスクの場合選択不可にするかどうか先頭がアスタリスクの場合選択不可にするかどうか。trueの場合選択不可、falseの場合選択不可
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AsteriskSelectEnabled() As Boolean
        Get
            Return _AsteriskSelectEnabled
        End Get
        Set(value As Boolean)
            _AsteriskSelectEnabled = value
        End Set
    End Property

    Private Sub ComboBoxEx_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Me.SelectedIndexChanged
        Dim t As String = Microsoft.VisualBasic.Left(Me.Text, 1)
        If t = "*" And Me.AsteriskSelectEnabled = False Then
            Me.SelectedIndex = lastSelectedIndex
        Else
            lastSelectedIndex = Me.SelectedIndex
        End If
        ToolTip1.SetToolTip(Me, Me.Text)
    End Sub
End Class


Public Class ListViewEX
    'ListViewコントロールの拡張並べ替え、コピー
    Inherits System.Windows.Forms.ListView

    Private Structure HeaderInfo
        Public title As String
        Public VariType As VariantType
        Public SortFlag As Boolean
        Public Sorting As Integer
    End Structure
    Dim ContextMenuStrip1 As New ContextMenuStrip
    Dim Header() As HeaderInfo
    Dim ListView_Data(,) As String
    Dim HeaderNum As Integer
    Dim DataNum As Integer

    Sub New()
        '詳細表示にする
        Me.View = View.Details
        Me.GridLines = True
    End Sub


    ''' <summary>
    ''' 列がクリックされた時、クリックされた列を設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Me_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)

        If Header(e.Column).SortFlag = True Then
            addDataToListView(e.Column)
        End If
    End Sub
    Private Sub addDataToListView(Optional ByVal sorting_column As Integer = -1)
        With Me
            If sorting_column = -1 Then
                '並べ替え無しの場合
                .Items.Clear()
                For i = 0 To DataNum - 1
                    Dim itemx As New ListViewItem
                    itemx.Text = ListView_Data(0, i)
                    For j = 1 To HeaderNum - 1
                        itemx.SubItems.Add(ListView_Data(j, i))
                    Next
                    .Items.Add(itemx)
                Next
            Else
                '並べ替えの場合
                Dim s_pat As Integer
                Dim Sdata As New clsSortingSearch
                If Header(sorting_column).VariType <> VariantType.String Then
                    Sdata.AddInit(vbDouble)
                    For i = 0 To DataNum - 1
                        Sdata.Add(Val(ListView_Data(sorting_column, i)))
                    Next
                Else
                    Sdata.AddInit(vbString)
                    For i = 0 To DataNum - 1
                        Sdata.Add(ListView_Data(sorting_column, i))
                    Next
                End If
                Sdata.AddEnd()
                With Header(sorting_column)
                    Select Case .Sorting
                        Case -1, 1
                            s_pat = 0
                        Case 0
                            s_pat = 1
                    End Select
                    .Sorting = s_pat
                End With

                .Items.Clear()
                For i As Integer = 0 To DataNum - 1
                    Dim k As Integer
                    If s_pat = 0 Then
                        k = Sdata.DataPosition(i)
                    Else
                        k = Sdata.DataPositionRev(i)
                    End If
                    Dim itemx As New ListViewItem
                    itemx.Text = ListView_Data(0, k)
                    For j = 1 To HeaderNum - 1
                        itemx.SubItems.Add(ListView_Data(j, k))
                    Next
                    .Items.Add(itemx)
                Next
            End If
        End With
    End Sub
    ''' <summary>
    ''' リストビューEXコントロールにデータをList(Of String)でセットする
    ''' </summary>
    ''' <param name="ListData">表示するList(Of String)データ・横方向はタブ区切り</param>
    ''' <param name="VariType">ヘッダの列数分の配列、VariTypeはStringとそれ以外しかない</param>
    ''' <param name="SortingFlag">ヘッダの列数分の配列で、並べ替えをするか。Falseの場合列の並べ替えは無し、ヘッダの列数分の配列</param>
    ''' <param name="RowNumberFlag">trueにすると左端に行番号がつく</param>
    ''' <remarks></remarks>
    Public Overloads Sub SetData(ByRef ListData As List(Of String), ByRef VariType() As VariantType, ByRef SortingFlag() As Boolean, _
                       ByVal RowNumberFlag As Boolean)
        Dim Values() As String = ListData.ToArray
        setDataMain(Values, VariType, SortingFlag, RowNumberFlag)
    End Sub
    ''' <summary>
    ''' リストビューEXコントロールにデータを配列でセットする
    ''' </summary>
    ''' <param name="ListData">表示する配列データ・横方向はタブ区切り</param>
    ''' <param name="VariType">ヘッダの列数分の配列、VariTypeはStringとそれ以外しかない</param>
    ''' <param name="SortingFlag">ヘッダの列数分の配列で、並べ替えをするか。Falseの場合列の並べ替えは無し、ヘッダの列数分の配列</param>
    ''' <param name="RowNumberFlag">trueにすると左端に行番号がつく</param>
    ''' <remarks></remarks>
    Public Overloads Sub SetData(ByRef ListData() As String, ByRef VariType() As VariantType, ByRef SortingFlag() As Boolean, _
                       ByVal RowNumberFlag As Boolean)

        setDataMain(ListData, VariType, SortingFlag, RowNumberFlag)


    End Sub
    ''' <summary>
    ''' リストビューEXコントロールにデータをセットするメイン
    ''' </summary>
    ''' <param name="ListData"></param>
    ''' <param name="VariType"></param>
    ''' <param name="SortingFlag"></param>
    ''' <param name="RowNumberFlag"></param>
    ''' <remarks></remarks>
    Private Sub setDataMain(ByRef ListData() As String, ByRef VariType() As VariantType, ByRef SortingFlag() As Boolean, _
                       ByVal RowNumberFlag As Boolean)
        Dim hst = ListData(0)
        If hst.Split(vbTab).GetUpperBound(0) <> VariType.GetUpperBound(0) Or hst.Split(vbTab).GetUpperBound(0) <> SortingFlag.GetUpperBound(0) _
             Or VariType.GetUpperBound(0) <> SortingFlag.GetUpperBound(0) Then
            Throw New ApplicationException("ListDataのヘッダ、VariType、SortingFlagの数が違います。")
        End If

        With Me
            'ColumnClickイベントハンドラの追加
            AddHandler .ColumnClick, AddressOf Me_ColumnClick

            'ヘッダの追加()
            If RowNumberFlag = True Then
                HeaderNum += 1
                hst = vbTab + hst
            End If
            Dim hd As String() = hst.Split(vbTab)
            HeaderNum = hd.GetUpperBound(0) + 1
            ReDim Header(HeaderNum - 1)
            .BeginUpdate()
            .Columns.Clear()
            For i As Integer = 0 To HeaderNum - 1
                Header(i).title = hd(i)
                Header(i).Sorting = -1
                If RowNumberFlag = True Then
                    If i = 0 Then
                        Header(i).Sorting = 0
                        Header(i).SortFlag = True
                        Header(i).VariType = VariantType.Integer
                    Else
                        Header(i).SortFlag = SortingFlag(i - 1)
                        Header(i).VariType = VariType(i - 1)
                    End If
                Else
                    Header(i).SortFlag = SortingFlag(i)
                    Header(i).VariType = VariType(i)
                End If

                Dim columnHead As New ColumnHeader
                columnHead.Text = Header(i).title
                Select Case Header(i).VariType
                    Case VariantType.String
                        columnHead.TextAlign = HorizontalAlignment.Left
                    Case Else
                        columnHead.TextAlign = HorizontalAlignment.Right
                End Select
                .Columns.Add(columnHead)
            Next
        End With


        'データの内部への移行
        DataNum = ListData.GetUpperBound(0)
        ReDim ListView_Data(HeaderNum - 1, DataNum - 1)
        For i As Integer = 0 To DataNum - 1
            Dim hst2 As String = ListData(i + 1)
            If RowNumberFlag = True Then
                hst2 = (i + 1).ToString + vbTab + hst2
            End If
            Dim hd As String() = hst2.Split(vbTab)
            For j As Integer = 0 To Math.Min(HeaderNum - 1, hd.GetUpperBound(0))
                ListView_Data(j, i) = hd(j)
            Next
        Next
        '表示
        addDataToListView()
        If DataNum < 1000 Then
            Me.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        End If
        Me.EndUpdate()

        'メニュー項目を追加
        ContextMenuStrip1.Items.Clear()
        ContextMenuStrip1.Items.Add("コピー(&C)", Nothing, AddressOf copyData)
        ContextMenuStrip1.Items.Add("最初の順番に戻す(&O)", Nothing, AddressOf ResetOrder)
        '関連づける
        Me.ContextMenuStrip = ContextMenuStrip1
    End Sub
    ''' <summary>
    ''' クリップボードにコピー
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub copyData()

        Dim tx As New System.Text.StringBuilder()
        For i As Integer = 0 To HeaderNum - 1
            tx.Append(Me.Columns.Item(i).Text)
            If i <> HeaderNum - 1 Then
                tx.Append(vbTab)
            Else
                tx.Append(vbCrLf)
            End If
        Next
        For i As Integer = 0 To DataNum - 1
            For j As Integer = 0 To HeaderNum - 1
                tx.Append(Me.Items(i).SubItems(j).Text)
                If j <> HeaderNum - 1 Then
                    tx.Append(vbTab)
                Else
                    tx.Append(vbCrLf)
                End If
            Next
        Next
        Clipboard.SetText(tx.ToString)
    End Sub
    Private Sub ResetOrder()
        '最初の並びに戻す
        addDataToListView()
    End Sub
End Class

Public Class DbDateTimePicker
    '日付未指定の状態も使えるDateTimePicker
    Inherits System.Windows.Forms.DateTimePicker
    Public Sub New()
        ImeMode = Windows.Forms.ImeMode.Disable
        ShowCheckBox = True
    End Sub

    Public Shadows Property Value() As strYMD
        Get
            Dim v As strYMD
            If MyBase.Checked Then
                'チェックされていたら値を返す
                v = clsTime.GetYMD(MyBase.Value)
                Return v
            Else
                'チェックされていなかったら未設定を返す
                v = clsTime.GetNullYMD
                Return v
            End If
        End Get
        Set(ByVal value As strYMD) 'strYMDを渡す
            Try
                If value.Day = 0 Then '日付が0だったらチェックを外す
                    MyBase.Checked = False
                Else
                    MyBase.Value = clsTime.getDateTime(value)
                    MyBase.Checked = True
                End If
            Catch ex As Exception
                MyBase.Value = clsTime.getDateTime(value)
                MyBase.Checked = True
            End Try
            MyBase.OnValueChanged(New EventArgs)
        End Set
    End Property
End Class

''' <summary>
''' 'CheckedListBoxを継承して、右クリックメニューで選択・非選択にできるようにした
''' '動的に調べる場合は、changedイベントで変化を調べる
''' 'CheckedListBoxExChangeEventArgsクラスも必要
''' </summary>
''' <remarks></remarks>
Public Class CheckedListBoxEx

    Inherits CheckedListBox
    Dim ContextMenuStrip1 As New ContextMenuStrip
    Dim eventStopf As Boolean = True
    Private ToolTip1 As ToolTip
    Public Event changed(ByVal sender As Object, ByVal e As CheckedListBoxExChangeEventArgs)

    Sub New()
        'メニュー項目を追加
        ContextMenuStrip1.Items.Add("すべて選択(&S)", Nothing, AddressOf AllSelect)
        ContextMenuStrip1.Items.Add("選択解除(&C)", Nothing, AddressOf AllClear)
        'コントロールに関連づける
        Me.ContextMenuStrip = ContextMenuStrip1
        Me.CheckOnClick = True
        ToolTip1 = New ToolTip()
        ToolTip1.InitialDelay = 1
    End Sub

    ''' <summary>
    ''' trueでイベントを発生させない。falseにした場合、changedイベントを発生
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EventStop() As Boolean
        Get
            Return eventStopf
        End Get
        Set(ByVal value As Boolean)
            eventStopf = value
            If value = False Then
                'イベントストップを解除した場合、changedイベントを発生
                Dim e2 As New CheckedListBoxExChangeEventArgs(Me.Items.Count)
                For i As Integer = 0 To Me.Items.Count - 1
                    e2.setValue(i, Me.GetItemChecked(i))
                Next
                Dim cv As New CheckState
                RaiseEvent changed(Me, e2)
            End If
        End Set
    End Property
    ''' <summary>
    ''' 全選択
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AllSelect()
        '全選択
        eventStopf = True 'ItemCheckイベントの解除
        For i As Integer = 0 To Me.Items.Count - 1
            Me.SetItemChecked(i, True)
        Next
        eventStopf = False 'ItemCheckイベントの復活
        Dim e2 As New CheckedListBoxExChangeEventArgs(Me.Items.Count)
        '現在の各アイテムのチェック状況をm_ItemCheckにセット
        For i As Integer = 0 To Me.Items.Count - 1
            e2.setValue(i, True)
        Next
        'changedイベントを発生させる
        Dim cv As New CheckState
        RaiseEvent changed(Me, e2)
    End Sub
    ''' <summary>
    ''' 選択解除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AllClear()
        '選択解除
        eventStopf = True
        For i As Integer = 0 To Me.Items.Count - 1
            Me.SetItemChecked(i, False)
        Next
        eventStopf = False
        Dim e2 As New CheckedListBoxExChangeEventArgs(Me.Items.Count)
        For i As Integer = 0 To Me.Items.Count - 1
            e2.setValue(i, False)
        Next
        RaiseEvent changed(Me, e2)
    End Sub
    Private Sub me_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles Me.ItemCheck
        If eventStopf = False Then
            Dim e2 As New CheckedListBoxExChangeEventArgs(Me.Items.Count)
            For i As Integer = 0 To Me.Items.Count - 1
                e2.setValue(i, Me.GetItemChecked(i))
            Next
            e2.setValue(e.Index, e.NewValue = CheckState.Checked)
            RaiseEvent changed(Me, e2)
        End If
    End Sub

    Private Sub CheckedListBoxEx_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim clb As CheckedListBoxEx = CType(sender, CheckedListBoxEx)
        Dim i As Integer = clb.IndexFromPoint(New Point(e.X, e.Y))
        If i <> -1 Then
            Dim ItemText As String = clb.Items(i)
            If ItemText <> ToolTip1.GetToolTip(clb) Then
                ToolTip1.SetToolTip(clb, ItemText)
            End If
        End If
    End Sub
End Class
Public Class CheckedListBoxExChangeEventArgs
    'CheckedListBoxExコントロールにChangeイベントで返すEventArgsを設定
    Inherits EventArgs 'この１行でEventArgsのすべての機能を実装します。これが「継承」です。

    Dim m_ItemCheck() As Boolean
    Dim NewValue As CheckState

    Public ReadOnly Property ItemCheck(ByVal n As Integer) As Boolean
        Get
            Return m_ItemCheck(n)
        End Get

    End Property

    Public Sub New(ByVal n As Integer)
        ReDim m_ItemCheck(n - 1)
    End Sub
    Public Sub setValue(ByVal n As Integer, ByVal value As Boolean)
        m_ItemCheck(n) = value
        'Me.set = value
    End Sub

End Class

''' <summary>
''' ListBoxを継承して、右クリックメニューで全選択・非選択にできるようにした
''' </summary>
''' <remarks></remarks>
Public Class ListBoxEx
    Inherits ListBox
    Dim ContextMenuStrip1 As New ContextMenuStrip
    Dim SelMode As Windows.Forms.SelectionMode
    Private ToolTip1 As ToolTip
    Private _AsteriskSelectEnabled As Boolean
    Private ToolTipItems() As String


    Sub New()
        'メニュー項目を追加
        ContextMenuStrip1.Items.Add("すべて選択(&S)", Nothing, AddressOf AllSelect)
        ContextMenuStrip1.Items.Add("選択解除(&C)", Nothing, AddressOf AllClear)

        'コントロールに関連づける
        Me.ContextMenuStrip = ContextMenuStrip1
        Me.SelMode = MyBase.SelectionMode
        Me._AsteriskSelectEnabled = False
        If Me.SelMode = Windows.Forms.SelectionMode.One Then
            Me.ContextMenuStrip = Nothing
        Else
            Me.ContextMenuStrip = ContextMenuStrip1
        End If
        ToolTip1 = New ToolTip()
        ToolTip1.InitialDelay = 1
    End Sub
    ''' <summary>
    ''' 先頭がアスタリスクの場合選択不可にするかどうか。trueの場合選択不可、falseの場合選択不可
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AsteriskSelectEnabled() As Boolean
        Get
            Return _AsteriskSelectEnabled
        End Get
        Set(value As Boolean)
            _AsteriskSelectEnabled = value
        End Set
    End Property
    ''' <summary>
    ''' 全選択
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AllSelect()
        'ループでSetSelectedをやると遅いのでこの方法で
        Me.Select()
        SendKeys.SendWait("^{END}+^{HOME}")
    End Sub
    ''' <summary>
    ''' 選択解除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AllClear()

        Me.ClearSelected()

    End Sub


    Public Overloads Property SelectionMode() As Windows.Forms.SelectionMode
        Get
            Return Me.SelMode
        End Get
        Set(ByVal Md As Windows.Forms.SelectionMode)
            Me.SelMode = Md
            If Md = Windows.Forms.SelectionMode.One Then
                Me.ContextMenuStrip = Nothing
            Else
                Me.ContextMenuStrip = ContextMenuStrip1
            End If
            MyBase.SelectionMode = Md
        End Set
    End Property


    Private Sub ListBoxEx_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Dim lb As ListBoxEx = CType(sender, ListBoxEx)
        Dim i As Integer = lb.IndexFromPoint(New Point(e.X, e.Y))
        If i <> -1 Then
            Dim ItemText As String = lb.Items(i).ToString
            If ItemText <> ToolTip1.GetToolTip(lb) Then
                ToolTip1.SetToolTip(lb, ItemText)
            End If
        End If
    End Sub

    Private Sub ListBoxEx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Me.SelectedValueChanged
        If Me._AsteriskSelectEnabled = True Then
            Return
        End If
        For i As Integer = 0 To Me.Items.Count - 1
            If Me.GetSelected(i) = True Then
                Dim t As String = Microsoft.VisualBasic.Left(Me.Items(i).ToString, 1)
                If t = "*" Then
                    Me.SetSelected(i, False)
                End If

            End If
        Next
    End Sub
End Class

''' <summary>
''' クリックすると全選択されるテキストボックス
''' </summary>
''' <remarks></remarks>
Public Class TextBoxFocusAllSelect
    Inherits TextBox
    Private m_bFlag As Boolean = False
    Private Sub TextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Enter
        Me.SelectAll()
        If Control.MouseButtons <> Windows.Forms.MouseButtons.None Then
            m_bFlag = True
        End If
    End Sub
    Private Sub TextBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
             Handles Me.MouseDown
        If m_bFlag Then
            Me.SelectAll()
            m_bFlag = False
        End If
    End Sub
End Class


''' <summary>
''' 数字入力テキストボックス
''' </summary>
''' <remarks></remarks>
Public Class TextNumberBox
    Inherits TextBox
    Private m_bFlag As Boolean = False
    Private _NumberPointF As Boolean = True
    Private _MaxValue As Double
    Private _MinValue As Double
    Private _MaxValueFlag As Boolean
    Private _MinValueFlag As Boolean
    Private _ValueErrorMessageFlag As Boolean

    Private defText As String
    Public Sub New()
        Me.ImeMode = Windows.Forms.ImeMode.Disable
        Me._MaxValueFlag = False
        Me._MinValueFlag = False
        Me._ValueErrorMessageFlag = True
        Me.TextAlign = HorizontalAlignment.Right
    End Sub
    Private Sub TextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Enter
        Me.SelectAll()
        defText = Me.Text
        If Control.MouseButtons <> Windows.Forms.MouseButtons.None Then
            m_bFlag = True
        End If
    End Sub
    Private Sub TextBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
             Handles Me.Click
        If m_bFlag = True Then
            Me.SelectAll()
            m_bFlag = False
        End If
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        '0～9と、バックスペース以外の時は、イベントをキャンセルする
        If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) AndAlso _
                e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "-"c Then
            If e.KeyChar = "."c And _NumberPointF = True Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub check_Value(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        Dim v As Double = Val(Me.Text)
        Dim etx As String
        If Me._ValueErrorMessageFlag = True Then
            If _MinValueFlag = True And _MaxValueFlag = True Then
                etx = _MinValue.ToString + "以上" + _MaxValue.ToString + "以下の値を入力して下さい。"
            ElseIf _MinValueFlag = True Then
                etx = _MinValue.ToString + "以上の値を入力して下さい。"
            ElseIf _MinValueFlag = True Then
                etx = _MaxValue.ToString + "以下の値を入力して下さい。"
            End If
        End If
        If _MinValueFlag = True Then
            If v < _MinValue Then
                If Me._ValueErrorMessageFlag = True Then
                    MsgBox(etx, vbExclamation)
                End If
                Me.Text = defText
                e.Cancel = True
            End If
        End If
        If _MaxValueFlag = True Then
            If v > _MaxValue Then
                If Me._ValueErrorMessageFlag = True Then
                    MsgBox(etx, vbExclamation)
                End If
                Me.Text = defText
                e.Cancel = True
            End If
        End If

    End Sub
    ''' <summary>
    ''' 数字入力trueの場合、小数点の使用
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NumberPoint() As Boolean
        Get
            Return _NumberPointF
        End Get
        Set(value As Boolean)
            _NumberPointF = value
        End Set
    End Property

    ''' <summary>
    ''' 最大値チェック
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MaxValueFlag As Boolean
        Get
            Return _MaxValueFlag
        End Get
        Set(value As Boolean)
            _MaxValueFlag = value
        End Set
    End Property
    Public Property MaxValue As Double
        Get
            Return _MaxValue
        End Get
        Set(value As Double)
            _MaxValue = value
        End Set
    End Property
    ''' <summary>
    ''' 最小値チェック
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MinValueFlag As Boolean
        Get
            Return _MinValueFlag
        End Get
        Set(value As Boolean)
            _MinValueFlag = value
        End Set
    End Property
    Public Property MinValue As Double
        Get
            Return _MinValue
        End Get
        Set(value As Double)
            _MinValue = value
        End Set
    End Property

    ''' <summary>
    ''' 最大値・最小値を超えた場合のエラーメッセージ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ValueErrorMessageFlag As Boolean
        Get
            Return _ValueErrorMessageFlag
        End Get
        Set(value As Boolean)
            _ValueErrorMessageFlag = value
        End Set
    End Property
End Class








