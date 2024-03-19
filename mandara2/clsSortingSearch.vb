Public Class clsSortingSearch
    '並べ替えと検索のクラス
    Dim SortNumber() As Integer
    Dim Sortrr_lng() As Integer
    Dim Sortrr_Single() As Single
    Dim Sortrr_Double() As Double
    Dim Sortrr_String() As String
    Dim DataNum As Integer
    Dim DataType As VariantType
    Dim AddCount As Integer

    Public ReadOnly Property NumofData() As Integer
        Get
            NumofData = DataNum
        End Get
    End Property

    Public ReadOnly Property SameValue_Number() As Integer
        'データ中に同じ値がどれだけあるか返す
        Get
            Select Case DataType
                Case VariantType.Integer
                    Dim sv() As Integer
                    Return Get_Same_value(sv)
                Case VariantType.Single
                    Dim sv() As Single
                    Return Get_Same_value(sv)
                Case VariantType.Double
                    Dim sv() As Double
                    Return Get_Same_value(sv)
                Case VariantType.String
                    Dim sv() As String
                    Return Get_Same_value(sv)
            End Select
        End Get
    End Property
    Public ReadOnly Property EachValue_Number() As Integer
        'データ中に値の種類ががどれだけあるか返す
        Get
            Select Case DataType
                Case VariantType.Integer
                    Dim sv() As Integer
                    Return Get_Each_value(sv)
                Case vbSingle
                    Dim sv() As Single
                    Return Get_Each_value(sv)
                Case vbDouble
                    Dim sv() As Double
                    Return Get_Each_value(sv)
                Case vbString
                    Dim sv() As String
                    Return Get_Each_value(sv)
            End Select
        End Get
    End Property
    ''' <summary>
    ''' データ中に値の種類ががどれだけあるか返す
    ''' </summary>
    ''' <param name="EachValue">個別の値も配列で返す</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function getEachValue_Alley(ByRef EachValue() As Integer) As Integer
        Return Get_Each_value(EachValue)
    End Function
    Public Overloads Function getEachValue_Alley(ByRef EachValue() As Single) As Integer
        'データ中に値の種類ががどれだけあるか返す
        'その値も配列で返す
        Return Get_Each_value(EachValue)
    End Function
    Public Overloads Function getEachValue_Alley(ByRef EachValue() As Double) As Integer
        'データ中に値の種類ががどれだけあるか返す
        'その値も配列で返す
        Return Get_Each_value(EachValue)
    End Function
    Public Overloads Function getEachValue_Alley(ByRef EachValue() As String) As Integer
        'データ中に値の種類ががどれだけあるか返す
        'その値も配列で返す
        Return Get_Each_value(EachValue)
    End Function
    Public Overloads Function getSameValue_Alley(ByRef SameValue() As Integer) As Integer
        'データ中に同じ値がどれだけあるか返す
        'その値も配列で返す
        Return Get_Same_value(SameValue)
    End Function
    Public Overloads Function getSameValue_Alley(ByRef SameValue() As Single) As Integer
        'データ中に同じ値がどれだけあるか返す
        'その値も配列で返す
        Return Get_Same_value(SameValue)
    End Function
    Public Overloads Function getSameValue_Alley(ByRef SameValue() As Double) As Integer
        'データ中に同じ値がどれだけあるか返す
        'その値も配列で返す
        Return Get_Same_value(SameValue)
    End Function
    Public Overloads Function getSameValue_Alley(ByRef SameValue() As String) As Integer
        'データ中に同じ値がどれだけあるか返す
        'その値も配列で返す
        Return Get_Same_value(SameValue)
    End Function
    ''' <summary>
    ''' 検索値と同じ値の数と位置を配列に返す
    ''' </summary>
    ''' <param name="SearchValue">検索値</param>
    ''' <param name="DataNumberAlley">同じ値の位置（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function getSearchData_Allay(ByVal SearchValue As Integer, ByRef DataNumberAlley() As Integer) As Integer
        Dim EQn As Integer, DPosition As Integer
        Dim i As Integer
        DPosition = Search_Data_Multi(SearchValue, EQn)
        If DPosition <> -1 Then
            ReDim DataNumberAlley(EQn - 1)
            For i = 0 To EQn - 1
                DataNumberAlley(i) = SortNumber(DPosition + i)
            Next
        Else
            EQn = -1
        End If
        Return EQn
    End Function
    ''' <summary>
    ''' 検索値と同じ値の数と位置を配列に返す
    ''' </summary>
    ''' <param name="SearchValue">検索値</param>
    ''' <param name="DataNumberAlley">同じ値の位置（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function getSearchData_Allay(ByVal SearchValue As Single, ByRef DataNumberAlley() As Integer) As Integer
        Dim EQn As Integer, DPosition As Integer
        Dim i As Integer
        DPosition = Search_Data_Multi(SearchValue, EQn)
        If DPosition <> -1 Then
            ReDim DataNumberAlley(EQn - 1)
            For i = 0 To EQn - 1
                DataNumberAlley(i) = SortNumber(DPosition + i)
            Next
        Else
            EQn = -1
        End If
        Return EQn
    End Function
    ''' <summary>
    ''' 検索値と同じ値の数と位置を配列に返す
    ''' </summary>
    ''' <param name="SearchValue">検索値</param>
    ''' <param name="DataNumberAlley">同じ値の位置（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function getSearchData_Allay(ByVal SearchValue As Double, ByRef DataNumberAlley() As Integer) As Integer
        Dim EQn As Integer, DPosition As Integer
        Dim i As Integer
        DPosition = Search_Data_Multi(SearchValue, EQn)
        If DPosition <> -1 Then
            ReDim DataNumberAlley(EQn - 1)
            For i = 0 To EQn - 1
                DataNumberAlley(i) = SortNumber(DPosition + i)
            Next
        Else
            EQn = -1
        End If
        Return EQn
    End Function
    ''' <summary>
    ''' 検索値と同じ値の数と位置を配列に返す
    ''' </summary>
    ''' <param name="SearchValue">検索値</param>
    ''' <param name="DataNumberAlley">同じ値の位置（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function getSearchData_Allay(ByVal SearchValue As String, ByRef DataNumberAlley() As Integer) As Integer
        Dim EQn As Integer, DPosition As Integer
        Dim i As Integer
        DPosition = Search_Data_Multi(SearchValue, EQn)
        If DPosition <> -1 Then
            ReDim DataNumberAlley(EQn - 1)
            For i = 0 To EQn - 1
                DataNumberAlley(i) = SortNumber(DPosition + i)
            Next
        Else
            EQn = -1
        End If
        Return EQn
    End Function
    ''' <summary>
    ''' 一つの値だけ検索してその見つかった最初の位置を返す
    ''' </summary>
    ''' <param name="SearchValue"></param>
    ''' <SearchValue>検索値</valSearchValueue>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads ReadOnly Property SearchData_One(ByVal SearchValue As Integer) As Integer
        Get
            Dim EQn As Integer, DPosition As Integer
            DPosition = Search_Data_Multi(SearchValue, EQn)
            If DPosition = -1 Then
                Return -1
            Else
                Return SortNumber(DPosition)
            End If
        End Get
    End Property
    ''' <summary>
    ''' 一つの値だけ検索してその見つかった最初の位置を返す
    ''' </summary>
    ''' <param name="SearchValue"></param>
    ''' <SearchValue>検索値</SearchValue>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads ReadOnly Property SearchData_One(ByVal SearchValue As Single) As Integer
        Get
            Dim EQn As Integer, DPosition As Integer
            DPosition = Search_Data_Multi(SearchValue, EQn)
            If DPosition = -1 Then
                Return -1
            Else
                Return SortNumber(DPosition)
            End If
        End Get
    End Property
    ''' <summary>
    ''' 一つの値だけ検索してその見つかった最初の位置を返す
    ''' </summary>
    ''' <param name="SearchValue"></param>
    ''' <SearchValue>検索値</SearchValue>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads ReadOnly Property SearchData_One(ByVal SearchValue As Double) As Integer
        Get
            Dim EQn As Integer, DPosition As Integer
            DPosition = Search_Data_Multi(SearchValue, EQn)
            If DPosition = -1 Then
                Return -1
            Else
                Return SortNumber(DPosition)
            End If
        End Get
    End Property
    ''' <summary>
    ''' 一つの値だけ検索してその見つかった最初の位置を返す。見つからなかった場合は-1
    ''' </summary>
    ''' <param name="SearchValue"></param>
    ''' <SearchValue>検索値</SearchValue>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads ReadOnly Property SearchData_One(ByVal SearchValue As String) As Integer
        Get
            Dim EQn As Integer, DPosition As Integer
            DPosition = Search_Data_Multi(SearchValue, EQn)
            If DPosition = -1 Then
                Return -1
            Else
                Return SortNumber(DPosition)
            End If
        End Get
    End Property
    ''' <summary>
    ''' 指定した順位のデータ番号を返す
    ''' </summary>
    ''' <param name="Num"></param>
    ''' <Num>順位</Num>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataPosition(ByVal Num As Integer) As Integer
        Get
            Return SortNumber(Num)
        End Get
    End Property
    ''' <summary>
    ''' 指定した逆順位のデータ番号を返す
    ''' </summary>
    ''' <param name="Num"></param>
    ''' <value>逆方向の順位</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataPositionRev(ByVal Num As Integer) As Integer
        '
        Get
            Return SortNumber(DataNum - Num - 1)
        End Get
    End Property
    ''' <summary>
    ''' 指定した順位のデータ値を返す(integer)
    ''' </summary>
    ''' <param name="Num">順位</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataPositionValue_Integer(ByVal Num As Integer) As Integer
        Get
            Return Sortrr_lng(Num)
        End Get
    End Property
    ''' <summary>
    ''' 指定した順位のデータ値を返す(Single)
    ''' </summary>
    ''' <param name="Num">順位</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataPositionValue_Single(ByVal Num As Integer) As Single
        '指定した順位のデータ値を返す
        Get
            Return Sortrr_Single(Num)
        End Get
    End Property
    ''' <summary>
    ''' 指定した順位のデータ値を返す(Double)
    ''' </summary>
    ''' <param name="Num">順位</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataPositionValue_Double(ByVal Num As Integer) As Double
        '指定した順位のデータ値を返す
        Get
            Return Sortrr_Double(Num)
        End Get
    End Property
    ''' <summary>
    ''' 指定した順位のデータ値を返す(String)
    ''' </summary>
    ''' <param name="Num">順位</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataPositionValue_string(ByVal Num As Integer) As String
        '指定した順位のデータ値を返す
        Get
            Return Sortrr_String(Num)
        End Get
    End Property
    ''' <summary>
    ''' 指定した逆順位のデータ値を返す(Integer)
    ''' </summary>
    ''' <param name="Num">逆順位</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataPositionRevValue_integer(ByVal Num As Integer) As Integer
        '指定した逆順位のデータ値を返す（変数の種類ごとにプロパティ）
        Get
            Dim n As Integer = DataNum - Num - 1
            Return Sortrr_lng(n)
        End Get
    End Property
    ''' <summary>
    ''' 指定した逆順位のデータ値を返す(Single)
    ''' </summary>
    ''' <param name="Num">逆順位</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataPositionRevValue_Single(ByVal Num As Integer) As Single
        '指定した逆順位のデータ値を返す
        Get
            Dim n As Integer = DataNum - Num - 1
            Return Sortrr_Single(n)
        End Get
    End Property
    ''' <summary>
    ''' 指定した逆順位のデータ値を返す(Double)
    ''' </summary>
    ''' <param name="Num">逆順位</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataPositionRevValue_double(ByVal Num As Integer) As Double
        '指定した逆順位のデータ値を返す
        Get
            Dim n As Integer = DataNum - Num - 1
            Return Sortrr_Double(n)
        End Get
    End Property
    ''' <summary>
    ''' 指定した逆順位のデータ値を返す(String)
    ''' </summary>
    ''' <param name="Num">逆順位</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataPositionRevValue_string(ByVal Num As Integer) As String
        '指定した逆順位のデータ値を返す
        Get
            Dim n As Integer = DataNum - Num - 1
            Return Sortrr_String(n)
        End Get
    End Property
    Public Sub New()

    End Sub
    ''' <summary>
    ''' データの種類を設定（VariantType.Integer、Single、Double、String）
    ''' </summary>
    ''' <param name="DataValueType"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal DataValueType As VariantType)
        AddInit(DataValueType)
    End Sub
    ''' <summary>
    ''' データの種類を設定（VariantType.Integer、Single、Double、String）
    ''' </summary>
    ''' <param name="DataValueType">VariantType.Integer、Single、Double、String</param>
    ''' <remarks></remarks>
    Public Sub AddInit(ByVal DataValueType As VariantType)
        '
        Select Case DataValueType
            Case VariantType.Integer
                ReDim Sortrr_lng(100)
            Case VariantType.Single
                ReDim Sortrr_Single(100)
            Case VariantType.Double
                ReDim Sortrr_Double(100)
            Case VariantType.String
                ReDim Sortrr_String(100)
            Case Else
                Err.Raise(513)
        End Select
        DataType = DataValueType
        AddCount = 0
    End Sub
    ''' <summary>
    ''' 一つずつ追加
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overloads Sub Add(ByVal Value As Integer)
        If DataType <> VariantType.Integer Then
            Err.Raise(513)
        End If
        If UBound(Sortrr_lng) < AddCount Then
            ReDim Preserve Sortrr_lng(AddCount * 2)
        End If
        Sortrr_lng(AddCount) = Value
        AddCount += 1
    End Sub
    ''' <summary>
    ''' 一つずつ追加
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overloads Sub Add(ByVal Value As Single)
        If DataType <> VariantType.Single Then
            Err.Raise(513)
        End If
        If UBound(Sortrr_Single) < AddCount Then
            ReDim Preserve Sortrr_Single(AddCount * 2)
        End If
        Sortrr_Single(AddCount) = Value
        AddCount += 1
    End Sub
    Public Overloads Sub Add(ByVal Value As Double)
        If DataType <> VariantType.Double Then
            Err.Raise(513)
        End If
        If UBound(Sortrr_Double) < AddCount Then
            ReDim Preserve Sortrr_Double(AddCount * 2)
        End If
        Sortrr_Double(AddCount) = Value
        AddCount += 1
    End Sub
    ''' <summary>
    ''' 一つずつ追加
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overloads Sub Add(ByVal Value As String)
        If DataType <> VariantType.String Then
            Err.Raise(513)
        End If
        If UBound(Sortrr_String) < AddCount Then
            ReDim Preserve Sortrr_String(AddCount * 2)
        End If
        Sortrr_String(AddCount) = Value
        AddCount += 1
    End Sub
    ''' <summary>
    ''' Addで一つずつ追加した場合に終了するして並べ替えを実行
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddEnd()
        DataNum = AddCount
        Select Case DataType
            Case VariantType.Integer
                SortNumber = Sorting_lng(DataNum)
            Case VariantType.Single
                SortNumber = Sorting_single(DataNum)
            Case VariantType.Double
                SortNumber = Sorting_double(DataNum)
            Case VariantType.String
                SortNumber = Sorting_string(DataNum)
        End Select
    End Sub
    ''' <summary>
    ''' 配列でまとめて追加。この場合、それだけで完了する、initも不要
    ''' </summary>
    ''' <param name="n">数</param>
    ''' <param name="Source_Data">配列</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddRange(ByVal n As Integer, ByVal Source_Data() As Integer)
        DataNum = n
        Sortrr_lng = Source_Data.Clone
        SortNumber = Sorting_lng(n)
        DataType = VariantType.Integer
    End Sub
    ''' <summary>
    ''' 配列でまとめて追加。この場合、それだけで完了する、initも不要
    ''' </summary>
    ''' <param name="n">数</param>
    ''' <param name="Source_Data">配列</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddRange(ByVal n As Integer, ByVal Source_Data() As Single)
        DataNum = n
        Sortrr_Single = Source_Data.Clone
        SortNumber = Sorting_single(n)
        DataType = VariantType.Single
    End Sub
    ''' <summary>
    ''' 配列でまとめて追加。この場合、それだけで完了する、initも不要
    ''' </summary>
    ''' <param name="n">数</param>
    ''' <param name="Source_Data">配列</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddRange(ByVal n As Integer, ByVal Source_Data() As Double)
        DataNum = n
        Sortrr_Double = Source_Data.Clone
        SortNumber = Sorting_double(n)
        DataType = VariantType.Double
    End Sub
    ''' <summary>
    ''' 配列でまとめて追加。この場合、それだけで完了する、initも不要
    ''' </summary>
    ''' <param name="n">数</param>
    ''' <param name="Source_Data">配列</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddRange(ByVal n As Integer, ByVal Source_Data() As String)
        DataNum = n
        Sortrr_String = Source_Data.Clone
        SortNumber = Sorting_string(n)
        DataType = VariantType.String
    End Sub

    Private Function Sorting_lng(ByVal n As Integer) As Integer()
        '===========================================================
        'ShelSort 指定された配列の整数をシェルソート
        '             （改良挿入法）でソートする
        ' 0 1 2 3 4 5 にソート
        '---------引数----------------------------------------------
        'sortrr()   ここのデータをソートする
        'sortrr_n()   ソート前の配列番号
        'n    要素の数
        '===========================================================

        Dim i As Integer, j As Integer, k As Integer
        Dim gap As Integer '数列のとび
        Dim sortrr_n() As Integer
        Dim TempD As Integer

        ReDim sortrr_n(n)
        For i = 0 To n - 1 : sortrr_n(i) = i : Next

        gap = n \ 2 'とびの初期値
        'とびが１のとき、普通の基本挿入法
        Do While gap > 0
            '数列番号－０からgapまで
            k = 0
            Do While k < gap
                '数列kの要素と比べる最初の要素
                j = k + gap
                '数列kに挿入していく
                Do While j < n '配列数まで
                    'まず数列kの右端の要素と比べる
                    i = j - gap
                    Do While i >= k '数列kの最初の要素まで
                        If Sortrr_lng(i + gap) < Sortrr_lng(i) Then
                            TempD = Sortrr_lng(i + gap)
                            Sortrr_lng(i + gap) = Sortrr_lng(i)
                            Sortrr_lng(i) = TempD
                            TempD = sortrr_n(i)
                            sortrr_n(i) = sortrr_n(i + gap)
                            sortrr_n(i + gap) = TempD
                        Else
                            Exit Do
                        End If
                        '１つずつ左にずれる
                        i = i - gap
                    Loop
                    '１つずつ右にずれる
                    j = j + gap
                Loop
                '次の数列に
                k = k + 1
            Loop
            'とびの変更
            gap = gap \ 2
        Loop
        Return sortrr_n
    End Function
    Private Function Sorting_single(ByVal n As Integer) As Integer()
        '===========================================================
        'ShelSort 指定された配列の整数をシェルソート
        '             （改良挿入法）でソートする
        ' 0 1 2 3 4 5 にソート
        '---------引数----------------------------------------------
        'sortrr()   ここのデータをソートする
        'sortrr_n()   ソート前の配列番号
        'n    要素の数
        '===========================================================

        Dim i As Integer, j As Integer, k As Integer
        Dim temp
        Dim gap As Integer '数列のとび
        Dim sortrr_n() As Integer
        Dim TempD As Single

        ReDim sortrr_n(n)
        For i = 0 To n - 1 : sortrr_n(i) = i : Next

        gap = n \ 2 'とびの初期値
        'とびが１のとき、普通の基本挿入法
        Do While gap > 0
            '数列番号－０からgapまで
            k = 0
            Do While k < gap
                '数列kの要素と比べる最初の要素
                j = k + gap
                '数列kに挿入していく
                Do While j < n '配列数まで
                    'まず数列kの右端の要素と比べる
                    i = j - gap
                    Do While i >= k '数列kの最初の要素まで
                        If Sortrr_Single(i + gap) < Sortrr_Single(i) Then
                            TempD = Sortrr_Single(i + gap)
                            Sortrr_Single(i + gap) = Sortrr_Single(i)
                            Sortrr_Single(i) = TempD
                            TempD = sortrr_n(i)
                            sortrr_n(i) = sortrr_n(i + gap)
                            sortrr_n(i + gap) = TempD
                        Else
                            Exit Do
                        End If
                        '１つずつ左にずれる
                        i = i - gap
                    Loop
                    '１つずつ右にずれる
                    j = j + gap
                Loop
                '次の数列に
                k = k + 1
            Loop
            'とびの変更
            gap = gap \ 2
        Loop
        Return sortrr_n
    End Function
    Private Function Sorting_double(ByVal n As Integer) As Integer()
        '===========================================================
        'ShelSort 指定された配列の整数をシェルソート
        '             （改良挿入法）でソートする
        ' 0 1 2 3 4 5 にソート
        '---------引数----------------------------------------------
        'sortrr()   ここのデータをソートする
        'sortrr_n()   ソート前の配列番号
        'n    要素の数
        '===========================================================

        Dim i As Integer, j As Integer, k As Integer
        Dim gap As Integer '数列のとび
        Dim sortrr_n() As Integer
        Dim TempD As Double

        ReDim sortrr_n(n)
        For i = 0 To n - 1 : sortrr_n(i) = i : Next


        gap = n \ 2 'とびの初期値
        'とびが１のとき、普通の基本挿入法
        Do While gap > 0
            '数列番号－０からgapまで
            k = 0
            Do While k < gap
                '数列kの要素と比べる最初の要素
                j = k + gap
                '数列kに挿入していく
                Do While j < n '配列数まで
                    'まず数列kの右端の要素と比べる
                    i = j - gap
                    Do While i >= k '数列kの最初の要素まで
                        If Sortrr_Double(i + gap) < Sortrr_Double(i) Then
                            TempD = Sortrr_Double(i + gap)
                            Sortrr_Double(i + gap) = Sortrr_Double(i)
                            Sortrr_Double(i) = TempD
                            TempD = sortrr_n(i)
                            sortrr_n(i) = sortrr_n(i + gap)
                            sortrr_n(i + gap) = TempD
                        Else
                            Exit Do
                        End If
                        '１つずつ左にずれる
                        i = i - gap
                    Loop
                    '１つずつ右にずれる
                    j = j + gap
                Loop
                '次の数列に
                k = k + 1
            Loop
            'とびの変更
            gap = gap \ 2
        Loop
        Return sortrr_n
    End Function
    Private Function Sorting_string(ByVal n As Integer) As Integer()
        '===========================================================
        'ShelSort 指定された配列の整数をシェルソート
        '             （改良挿入法）でソートする
        ' 0 1 2 3 4 5 にソート
        '---------引数----------------------------------------------
        'sortrr()   ここのデータをソートする
        'sortrr_n()   ソート前の配列番号
        'n    要素の数
        '===========================================================

        Dim i As Integer, j As Integer, k As Integer
        Dim gap As Integer '数列のとび
        Dim sortrr_n() As Integer
        Dim TempD As String

        ReDim sortrr_n(n)
        'ReDim sortrr_String(n - 1)
        For i = 0 To n - 1
            sortrr_n(i) = i
        Next


        gap = n \ 2 'とびの初期値
        'とびが１のとき、普通の基本挿入法
        Do While gap > 0
            '数列番号－０からgapまで
            k = 0
            Do While k < gap
                '数列kの要素と比べる最初の要素
                j = k + gap
                '数列kに挿入していく
                Do While j < n '配列数まで
                    'まず数列kの右端の要素と比べる
                    i = j - gap
                    Do While i >= k '数列kの最初の要素まで
                        If Sortrr_String(i + gap) < Sortrr_String(i) Then
                            TempD = Sortrr_String(i + gap)
                            Sortrr_String(i + gap) = Sortrr_String(i)
                            Sortrr_String(i) = TempD
                            TempD = sortrr_n(i)
                            sortrr_n(i) = sortrr_n(i + gap)
                            sortrr_n(i + gap) = TempD
                        Else
                            Exit Do
                        End If
                        '１つずつ左にずれる
                        i = i - gap
                    Loop
                    '１つずつ右にずれる
                    j = j + gap
                Loop
                '次の数列に
                k = k + 1
            Loop
            'とびの変更
            gap = gap \ 2
        Loop
        Return sortrr_n
    End Function
    Private Function Search_Data_Multi(ByVal SearchValue As Integer, ByRef Num_of_Equal_Data As Integer) As Integer

        '-------------------------
        'SearchValue／探し出すデータ
        'Search_Data_Multi／データの見つかった最初の位置
        'Num_of_Equal_Data／同じ値のデータの個数
        '-------------------------

        Dim f As Boolean, H As Integer, oh As Integer, ooh As Integer
        Dim mxx As Integer
        Dim rv As Integer = -1

        Num_of_Equal_Data = 0
        If DataNum = 0 Then
            Return -1
        End If
        f = True
        mxx = DataNum - 1
        oh = mxx + 1
        ooh = -1
        H = mxx \ 2
        Do While Sortrr_lng(H) <> SearchValue
            If SearchValue < Sortrr_lng(H) Then
                oh = H : H = (ooh + H) \ 2
                If oh = H Then f = False : Exit Do
            Else
                ooh = H : H = (oh + H) \ 2
                If ooh = H Then f = False : Exit Do
            End If
        Loop

        If f = False Then
            rv = -1
        Else
            If H > 0 Then
                Do While Sortrr_lng(H - 1) = SearchValue
                    H = H - 1
                    If H = 0 Then
                        Exit Do
                    End If
                Loop
            End If
            rv = H

            If H < DataNum Then
                Do While Sortrr_lng(H) = SearchValue
                    H = H + 1
                    If H = DataNum Then
                        Exit Do
                    End If
                Loop
            End If
            Num_of_Equal_Data = H - rv
        End If
        Return rv
    End Function
    Private Function Search_Data_Multi(ByVal SearchValue As Single, ByRef Num_of_Equal_Data As Integer) As Integer

        '-------------------------
        'SearchValue／探し出すデータ
        'Search_Data_Multi／データの見つかった最初の位置
        'Num_of_Equal_Data／同じ値のデータの個数
        '-------------------------

        Dim f As Boolean, H As Integer, oh As Integer, ooh As Integer
        Dim mxx As Integer
        Dim rv As Integer = -1

        Num_of_Equal_Data = 0
        If DataNum = 0 Then
            Return -1
        End If
        f = True
        mxx = DataNum - 1
        oh = mxx + 1
        ooh = -1
        H = mxx \ 2
        Do While Sortrr_Single(H) <> SearchValue
            If SearchValue < Sortrr_Single(H) Then
                oh = H : H = (ooh + H) \ 2
                If oh = H Then f = False : Exit Do
            Else
                ooh = H : H = (oh + H) \ 2
                If ooh = H Then f = False : Exit Do
            End If
        Loop

        If f = False Then
            rv = -1
        Else
            If H > 0 Then
                Do While Sortrr_Single(H - 1) = SearchValue
                    H = H - 1
                    If H = 0 Then
                        Exit Do
                    End If
                Loop
            End If
            rv = H

            If H < DataNum Then
                Do While Sortrr_Single(H) = SearchValue
                    H = H + 1
                    If H = DataNum Then
                        Exit Do
                    End If
                Loop
            End If
            Num_of_Equal_Data = H - rv
        End If
        Return rv
    End Function
    Private Function Search_Data_Multi(ByVal SearchValue As Double, ByRef Num_of_Equal_Data As Integer) As Integer

        '-------------------------
        'SearchValue／探し出すデータ
        'Search_Data_Multi／データの見つかった最初の位置
        'Num_of_Equal_Data／同じ値のデータの個数
        '-------------------------

        Dim f As Boolean, H As Integer, oh As Integer, ooh As Integer
        Dim mxx As Integer
        Dim rv As Integer = -1

        Num_of_Equal_Data = 0
        If DataNum = 0 Then
            Return -1
        End If
        f = True
        mxx = DataNum - 1
        oh = mxx + 1
        ooh = -1
        H = mxx \ 2
        Do While Sortrr_Double(H) <> SearchValue
            If SearchValue < Sortrr_Double(H) Then
                oh = H : H = (ooh + H) \ 2
                If oh = H Then f = False : Exit Do
            Else
                ooh = H : H = (oh + H) \ 2
                If ooh = H Then f = False : Exit Do
            End If
        Loop

        If f = False Then
            rv = -1
        Else
            If H > 0 Then
                Do While Sortrr_Double(H - 1) = SearchValue
                    H = H - 1
                    If H = 0 Then
                        Exit Do
                    End If
                Loop
            End If
            rv = H

            If H < DataNum Then
                Do While Sortrr_Double(H) = SearchValue
                    H = H + 1
                    If H = DataNum Then
                        Exit Do
                    End If
                Loop
            End If
            Num_of_Equal_Data = H - rv
        End If
        Return rv

    End Function

    Private Function Search_Data_Multi(ByVal SearchValue As String, ByRef Num_of_Equal_Data As Integer) As Integer

        '-------------------------
        'SearchValue／探し出すデータ
        'Search_Data_Multi／データの見つかった最初の位置
        'Num_of_Equal_Data／同じ値のデータの個数
        '-------------------------

        Dim f As Boolean, H As Integer, oh As Integer, ooh As Integer
        Dim mxx As Integer
        Dim rv As Integer = -1

        Num_of_Equal_Data = 0
        If DataNum = 0 Then
            Return -1
        End If
        f = True
        mxx = DataNum - 1
        oh = mxx + 1
        ooh = -1
        H = mxx \ 2
        Do While Sortrr_String(H) <> SearchValue
            If SearchValue < Sortrr_String(H) Then
                oh = H : H = (ooh + H) \ 2
                If oh = H Then f = False : Exit Do
            Else
                ooh = H : H = (oh + H) \ 2
                If ooh = H Then f = False : Exit Do
            End If
        Loop

        If f = False Then
            rv = -1
        Else
            If H > 0 Then
                Do While Sortrr_String(H - 1) = SearchValue
                    H = H - 1
                    If H = 0 Then
                        Exit Do
                    End If
                Loop
            End If
            rv = H

            If H < DataNum Then
                Do While Sortrr_String(H) = SearchValue
                    H += 1
                    If H = DataNum Then
                        Exit Do
                    End If
                Loop
            End If
            Num_of_Equal_Data = H - rv
        End If
        Return rv
    End Function
    Private Function Get_Same_value(ByRef SameV() As Integer) As Integer
        '同じ値を返す
        Dim SV() As Integer

        Dim f As Boolean = False
        Dim n As Integer = 0
        For i As Integer = 1 To DataNum - 1
            If Sortrr_lng(i - 1) = Sortrr_lng(i) And f = False Then
                f = True
                ReDim Preserve SV(n)
                SV(n) = Sortrr_lng(i)
                n += 1
            Else
                f = False
            End If
        Next
        SameV = SV
        Return n

    End Function

    Private Function Get_Same_value(ByRef SameV() As Single) As Integer
        '同じ値を返す

        Dim SV() As Single

        Dim f As Boolean = False
        Dim n As Integer = 0
        For i As Integer = 1 To DataNum - 1
            If Sortrr_Single(i - 1) = Sortrr_Single(i) And f = False Then
                f = True
                ReDim Preserve SV(n)
                SV(n) = Sortrr_Single(i)
                n += 1
            Else
                f = False
            End If
        Next
        SameV = SV
        Return n

    End Function
    Private Function Get_Same_value(ByRef SameV() As Double) As Integer
        '同じ値を返す

        Dim SV() As Double


        Dim f As Boolean = False
        Dim n As Integer = 0
        For i As Integer = 1 To DataNum - 1
            If Sortrr_Double(i - 1) = Sortrr_Double(i) And f = False Then
                f = True
                ReDim Preserve SV(n)
                SV(n) = Sortrr_Double(i)
                n += 1
            Else
                f = False
            End If
        Next
        SameV = SV
        Return n

    End Function
    Private Function Get_Same_value(ByRef SameV() As String) As Integer
        '同じ値を返す

        Dim SV() As String

        Dim f As Boolean = False
        Dim n As Integer = 0
        For i As Integer = 1 To DataNum - 1
            If Sortrr_String(i - 1) = Sortrr_String(i) And f = False Then
                f = True
                ReDim Preserve SV(n)
                SV(n) = Sortrr_String(i)
                n += 1
            Else
                f = False
            End If
        Next

        SameV = SV
        Return n
    End Function
    ''' <summary>
    ''' 重複しない個別の値とその数を返す
    ''' </summary>
    ''' <param name="EachV"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_Each_value(ByRef EachV() As Integer) As Integer
        Dim SV(DataNum - 1) As Integer
        Dim n As Integer = 0
        For i As Integer = 1 To DataNum - 1
            If Sortrr_lng(i - 1) <> Sortrr_lng(i) Then
                SV(n) = Sortrr_lng(i - 1)
                n += 1
            End If
        Next
        SV(n) = Sortrr_lng(DataNum - 1)
        n += 1
        ReDim Preserve SV(n - 1)
        EachV = SV
        Return n
    End Function
    ''' <summary>
    ''' 重複しない個別の値とその数を返す
    ''' </summary>
    ''' <param name="EachV"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_Each_value(ByRef EachV() As Single) As Integer
        Dim SV(DataNum - 1) As Single
        Dim n As Integer = 0
        For i As Integer = 1 To DataNum - 1
            If Sortrr_Single(i - 1) <> Sortrr_Single(i) Then
                SV(n) = Sortrr_Single(i - 1)
                n += 1
            End If
        Next
        SV(n) = Sortrr_Single(DataNum - 1)
        n += 1
        ReDim Preserve SV(n - 1)
        EachV = SV
        Return n
    End Function
    ''' <summary>
    ''' 重複しない個別の値とその数を返す
    ''' </summary>
    ''' <param name="EachV"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_Each_value(ByRef EachV() As Double) As Integer

        Dim SV(DataNum - 1) As Double

        Dim n As Integer = 0
        For i As Integer = 1 To DataNum - 1
            If Sortrr_Double(i - 1) <> Sortrr_Double(i) Then
                SV(n) = Sortrr_Double(i - 1)
                n += 1
            End If
        Next
        SV(n) = Sortrr_Double(DataNum - 1)
        n += 1
        ReDim Preserve SV(n - 1)
        EachV = SV
        Return n
    End Function
    ''' <summary>
    ''' 重複しない個別の値とその数を返す
    ''' </summary>
    ''' <param name="EachV"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_Each_value(ByRef EachV() As String) As Integer
        '重複しない個別の値とその数を返す

        Dim SV(DataNum - 1) As String
        Dim n As Integer = 0
        For i As Integer = 1 To DataNum - 1
            If Sortrr_String(i - 1) <> Sortrr_String(i) Then
                SV(n) = Sortrr_String(i - 1)
                n += 1
            End If
        Next
        SV(n) = Sortrr_String(DataNum - 1)
        n += 1
        ReDim Preserve SV(n - 1)
        EachV = SV
        Return n
    End Function
End Class
