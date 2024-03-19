Public Class clsVB6File
    ''' <summary>
    ''' 単精度のxy座標
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure SingleXY_v1275
        Public x As Single
        Public y As Single
    End Structure
    ''' <summary>
    ''' '単精度の四角形のプロパティ（汎用）
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Box_Data_single_v11
        Public left As Single 'x最小値　
        Public top As Single 'y最小値
        Public right As Single 'x最大値
        Public bottom As Single 'y最大値

    End Structure

    '線のプロパティ（汎用）---------------------------------
    ''' <summary>
    ''' VB6破線のパターン
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure OptionalLine_Data_info_v11
        Public Use_F As Boolean
        Public Print_f As Boolean
        Public Length As Single
        Public Width As Single
        Public Color As Integer
    End Structure
    ''' <summary>
    ''' VB6ハッチ内部や線種内の記号
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Tile_Mark_v11
        Public PrintMark As Short
        Public Shape As Short
        Public wordmark As String
        Public WordFontName As String
        Public PictureNumber As Integer
        Public Kakudo As Integer
        Public Mark_Line_Color As Integer
    End Structure

    ''' <summary>
    ''' VB6交差線のパターン
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Optional_X_Line_Data_info_v11
        Public Use_F As Boolean
        Public pattern As Short '0:線  1:円  2:四角 3:記号
        Public Length As Single
        Public Width As Single
        Public Color As Integer
        Public Interval As Single
        Public Mark As Tile_Mark_v11
    End Structure


    Public Structure SolidLine_Data_Info_v11
        Public Color As Integer
        Public Width As Single
    End Structure

    Public Structure Line_Basic_Data_Info_v11
        Public pattern As Short 'パターン／-1:透明　0:実践　1:破線
        Public SolidLine As SolidLine_Data_Info_v11
        Public CenterLine() As OptionalLine_Data_info_v11
        Public Sub init()
            ReDim CenterLine(5)
        End Sub
    End Structure


    Public Structure Parallel_Line_Data_info_v11
        Public P_Line_f As Boolean '二重線にする
        Public Interval As Single
        Public InnerColor_f As Boolean
        Public InnerColor As Integer
        Public Center_Line_f As Boolean
        Public CenterLine_ParaLine_f As Boolean
        Public P_CenterLine As Line_Basic_Data_Info_v11
    End Structure

    Public Structure Cross_Line_Data_Info_v11
        Public Sub init()
            ReDim XLine(5)
        End Sub
        Public XLine_f As Boolean '交差線を描く
        Public XLine() As Optional_X_Line_Data_info_v11
    End Structure

    Public Structure Edge_Connect_Pattern_Data_Info_v11
        Public Edge_Pattern As Integer '線端形状まるめる 0'まる　1四角 2たいら
        Public Join_Pattern As Integer
        Public MiterLimitValue As Single
    End Structure

    ''' <summary>
    ''' VB6線種
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Line_Property_v11
        Public BasicLine As Line_Basic_Data_Info_v11
        Public CrossLine As Cross_Line_Data_Info_v11
        Public ParallelLine As Parallel_Line_Data_info_v11
        Public Edge_Connect_Pattern As Edge_Connect_Pattern_Data_Info_v11
    End Structure
    '---------------------------------
    ''' <summary>
    ''' VB6模様のプロパティ（汎用）
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Tile_Property_v11
        Public TileCode As Short
        Public Line As Line_Property_v11
        Public Density As Single
        Public BGColFlag As Boolean
        Public BGCOLOR As Integer
        Public Mark As Tile_Mark_v11
    End Structure


    Public Structure Font_Body_Property_v11
        Public Color As Integer
        Public Size As Single
        Public italic As Boolean
        Public bold As Boolean
        Public Underline As Boolean
        Public Name As String
        Public Kakudo As Integer
    End Structure
    Public Structure Font_Back_Property_v11
        Public Tile As Tile_Property_v11
        Public Line As Line_Property_v11
    End Structure
    ''' <summary>
    ''' VB6フォントのプロパティ（汎用））
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Font_Property_v11
        Public Body As Font_Body_Property_v11
        Public Tile As Tile_Property_v11
        Public frameLine As Line_Property_v11
    End Structure

    Public Structure FontFringe_Info
        Public FringeSize As Integer
        Public FringeColor As Integer
    End Structure
    ''' <summary>
    ''' VB6記号のプロパティ（汎用）
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Mark_Property_v11
        Public PrintMark As Short
        Public Shape As Short
        Public Tile As Tile_Property_v11
        Public Line As Line_Property_v11
        Public wordmark As String
        Public WordFont As Font_Property_v11
        Public PictureNumber As Integer
    End Structure
    ''' <summary>
    ''' VB6方位の設定（地図・属性データ）
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Compass_Attri_v11
        Public Visible As Boolean
        Public X As Single
        Public Y As Single
        Public Mark As Mark_Property_v11
        Public Nstr As String
        Public Sstr As String
        Public Wstr As String
        Public Estr As String
        Public Font As Font_Property_v11
    End Structure
    Private Structure halfLineKind_Data_v11  '線種名とパターン（地図データ）
        Public Name As String
        Public NumofOjectGroup As Integer '1の場合は通常の線種、2以上の場合はオブジェクトグループ連動
        Public ObjGroup() As clsOldMapFile.LKOjectGroup_Info_v11
    End Structure
    ''' <summary>
    ''' VB6記号プロパティを取得
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getMarkPropertyV11(ByVal n As Integer) As Mark_Property_v11
        Dim mk As Mark_Property_v11

        FileGet(n, mk.PrintMark)
        FileGet(n, mk.Shape)
        mk.Tile = getTilePropertyV11(n)
        mk.Line = getLinePropertyV11(n)
        mk.wordmark = getStringsV11(n)
        mk.WordFont = getFontPropertyV11(n)
        FileGet(n, mk.PictureNumber)
        Return mk
    End Function
    ''' <summary>
    ''' VB6フォントプロパティを取得
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getFontPropertyV11(ByVal n As Integer) As Font_Property_v11
        '
        Dim ft As Font_Property_v11
        FileGet(n, ft.Body)
        ft.Tile = getTilePropertyV11(n)
        ft.frameLine = getLinePropertyV11(n)
        Return ft
    End Function
    ''' <summary>
    ''' 文字列取得
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getStringsV11(ByVal n As Integer) As String
        '
        Dim wordbyte As Short
        FileGet(n, wordbyte)
        Dim word As String = ""
        If wordbyte > 0 Then
            word = Space(wordbyte)
            FileGet(n, word)
        End If
        Return word
    End Function
    ''' <summary>
    ''' VB6のバリアント型を文字列で取得
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getVariantType(ByVal n As Integer) As String
        Dim Datatype As Short
        Dim st As String = ""
        FileGet(n, Datatype)
        Select Case Datatype
            Case 0, 1
                'emptyまたはnull
                st = ""
            Case 2
                Dim v As Short
                FileGet(n, v)
                st = Str(v)
            Case 3
                Dim v As Integer
                FileGet(n, v)
                st = Str(v)
            Case 4
                Dim v As Single
                FileGet(n, v)
                st = Str(v)
            Case 5
                Dim v As Double
                FileGet(n, v)
                st = Str(v)
            Case 8
                st = getStringsV11(n)
            Case 11
                Dim v As Boolean
                FileGet(n, v)
                st = Str(v)
            Case 17
                Dim v As Byte
                FileGet(n, v)
                st = Str(v)
        End Select
        Return st
    End Function
    ''' <summary>
    ''' 線種を取得
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getLineKindV11(ByVal n As Integer) As clsOldMapFile.LineKind_Data_v11
        Dim hf As New halfLineKind_Data_v11
        Dim lineKindv11 As clsOldMapFile.LineKind_Data_v11
        With lineKindv11
            FileGet(n, hf)
            .Name = hf.Name
            .NumofOjectGroup = hf.NumofOjectGroup
            .ObjGroup = hf.ObjGroup.Clone
            Dim s As Short
            FileGet(n, s)
            If s = 0 Then '2013/12/5発見のエラーに対応
                ReDim .Pat(0)
            Else
                Dim dn As Long
                FileGet(n, dn)
                ReDim .Pat(dn - 1)
                For j As Integer = 0 To dn - 1
                    .Pat(j) = clsVB6File.getLinePropertyV11(n)
                Next
            End If
            FileGet(n, .Mesh)
            FileGet(n, .Edited)
        End With
        Return lineKindv11
    End Function

    ''' <summary>
    ''' タイルプロパティを取得
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getTilePropertyV11(ByVal n As Integer) As Tile_Property_v11
        Dim tl As Tile_Property_v11
        FileGet(n, tl.TileCode)
        tl.Line = getLinePropertyV11(n)
        FileGet(n, tl.Density)
        FileGet(n, tl.BGColFlag)
        FileGet(n, tl.BGCOLOR)
        FileGet(n, tl.Mark)
        Return tl
    End Function
    ''' <summary>
    ''' ラインプロパティを取得
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getLinePropertyV11(ByVal n As Integer) As Line_Property_v11
        '
        Dim ln As Line_Property_v11
        ln.BasicLine.init()
        ln.CrossLine.init()
        ln.ParallelLine.P_CenterLine.init()
        FileGet(n, ln.BasicLine.pattern)
        FileGet(n, ln.BasicLine.SolidLine)
        For i As Integer = 0 To 5
            FileGet(n, ln.BasicLine.CenterLine(i))
        Next
        FileGet(n, ln.CrossLine.XLine_f)
        For i As Integer = 0 To 5
            FileGet(n, ln.CrossLine.XLine(i))
        Next
        FileGet(n, ln.ParallelLine.P_Line_f)
        FileGet(n, ln.ParallelLine.Interval)
        FileGet(n, ln.ParallelLine.InnerColor_f)
        FileGet(n, ln.ParallelLine.InnerColor)
        FileGet(n, ln.ParallelLine.Center_Line_f)
        FileGet(n, ln.ParallelLine.CenterLine_ParaLine_f)
        FileGet(n, ln.ParallelLine.P_CenterLine.pattern)
        FileGet(n, ln.ParallelLine.P_CenterLine.SolidLine)
        For i As Integer = 0 To 5
            FileGet(n, ln.ParallelLine.P_CenterLine.CenterLine(i))
        Next
        FileGet(n, ln.Edge_Connect_Pattern)
        Return ln
    End Function
    ''' <summary>
    ''' 構造体中の一次元配列のサイズを取得
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getArrayNumberInType(ByVal n As Integer) As Integer
        Dim ub As Short = 0
        Dim head As Short
        FileGet(n, head) '配列の次元数
        If head > 0 Then
            FileGet(n, ub)
            Dim Data(ub - 1) As Boolean
            For k As Integer = 0 To 5
                Dim bt As Byte
                FileGet(n, bt)
            Next
        End If
        Return ub
    End Function

    Public Shared Function convertFrmPrintSize(ByVal oldFrm As clsOldMDRFile.Box_Position_and_Size_v1275) As Rectangle

        Dim left As Integer = oldFrm.left / Microsoft.VisualBasic.Compatibility.VB6.TwipsPerPixelX()
        Dim top As Integer = oldFrm.top / Microsoft.VisualBasic.Compatibility.VB6.TwipsPerPixelY
        Dim width As Integer = oldFrm.Width / Microsoft.VisualBasic.Compatibility.VB6.TwipsPerPixelX()
        Dim height As Integer = oldFrm.Height / Microsoft.VisualBasic.Compatibility.VB6.TwipsPerPixelY()
        height = height - SystemInformation.BorderSize.Height - SystemInformation.MenuHeight - SystemInformation.CaptionHeight
        width = width - SystemInformation.BorderSize.Width * 2
        Dim newRec As Rectangle = New Rectangle(left, top, width, height)
        Return newRec
    End Function

    ''' <summary>
    ''' 方位取得
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getCompassAttri(ByVal n As Integer) As Compass_Attri_v11
        Dim MapCompasssv11 As Compass_Attri_v11
        FileGet(n, MapCompasssv11.Visible)
        FileGet(n, MapCompasssv11.X)
        FileGet(n, MapCompasssv11.Y)
        MapCompasssv11.Mark = clsVB6File.getMarkPropertyV11(n)
        MapCompasssv11.Nstr = clsVB6File.getStringsV11(n)
        MapCompasssv11.Sstr = clsVB6File.getStringsV11(n)
        MapCompasssv11.Wstr = clsVB6File.getStringsV11(n)
        MapCompasssv11.Estr = clsVB6File.getStringsV11(n)
        MapCompasssv11.Font = clsVB6File.getFontPropertyV11(n)
        Return MapCompasssv11
    End Function
    Public Shared Function convertThreeDMode(ByRef oldThreeD As clsOldMDRFile.ThreeDMode_Set_v1275) As strThreeDMode_Set
        Dim ThreeDMode As strThreeDMode_Set
        With ThreeDMode
            .Bank = oldThreeD.Bank
            .Expand = oldThreeD.Expand
            .Head = oldThreeD.Head
            .Pitch = oldThreeD.Pitch
            .Set3D_F = oldThreeD.Set3D_F
        End With

        Return ThreeDMode
    End Function
    Public Shared Function convertMapTitle(ByRef oldMapTitle As clsOldMDRFile.Title_Attri_v1275) As clsAttrData.strTitle_Attri
        Dim MapTitle As clsAttrData.strTitle_Attri
        With MapTitle
            Dim oldTT As clsOldMDRFile.Title_Attri_v1275 = oldMapTitle
            .MaxWidth = 50
            .Font = clsVB6File.convertFontProperty(oldTT.Font)
            .Position = New PointF(oldTT.X, oldTT.Y)
            .Visible = oldTT.Visible
        End With
        Return MapTitle
    End Function
    Public Shared Function convertMapSCL(ByRef oldMapSCL As clsOldMDRFile.Scale_Attri_v1275) As clsAttrData.strScale_Attri
        Dim MapScale As clsAttrData.strScale_Attri
        With MapScale
            Dim oldSC As clsOldMDRFile.Scale_Attri_v1275 = oldMapSCL
            .BarAuto = oldSC.BarAuto
            .BarDistance = oldSC.BarDistance
            .BarPattern = oldSC.BarPattern
            .BarKugiriNum = oldSC.BarKugiriNum
            .Back.Line = clsVB6File.convertLineProperty(oldSC.BGLine)
            .Back.Tile = clsVB6File.convertTileProperty(oldSC.BGTile)
            .Back.Round = 0
            .Back.Padding = 1
            .Font = clsVB6File.convertFontProperty(oldSC.Font)
            .Position = New PointF(oldSC.X, oldSC.Y)
            .Visible = oldSC.Visible
            .Unit = enmScaleUnit.kilometer
        End With
        Return MapScale
    End Function
    Public Shared Function convertMapLegend(ByRef oldMapLegend As clsOldMDRFile.Legend_Attri_v1275,
                                            ByRef oldLegendXY() As SingleXY_v1275, ByVal En_Graph_Pattern As Integer) As clsAttrData.strLegend_Attri
        Dim MapLegend As clsAttrData.strLegend_Attri
        With MapLegend
            Dim oldML As clsOldMDRFile.Legend_Attri_v1275 = oldMapLegend
            With .Base
                .Back.Line = clsVB6File.convertLineProperty(oldML.Base.BGLine)
                .Back.Tile = clsVB6File.convertTileProperty(oldML.Base.BGTile)
                .Back.Round = 0
                .Back.Padding = 1
                .Font = clsVB6File.convertFontProperty(oldML.Base.Font)
                .Legend_Num = oldML.Base.Legend_Num
                ReDim .LegendXY(.Legend_Num - 1)
                For i As Integer = 0 To .Legend_Num - 1
                    .LegendXY(i) = clsVB6File.convertSingleXY(oldLegendXY(i))
                Next
                .Visible = oldML.Base.Visible
            End With
            With .ClassMD
                .ClassMarkFrame_Visible = oldML.ClassMD.ClassMarkFrame_Visible
                .PaintMode_Line = clsVB6File.convertLineProperty(oldML.ClassMD.PaintMode_Line)
                .PaintMode_Method = oldML.ClassMD.PaintMode_Method
                .PaintMode_Width = oldML.ClassMD.PaintMode_Width
                .SeparateGapSize = 0.2
                .SeparateClassWords = oldML.ClassMD.SeparateClassWords
            End With
            .En_Graph_Pattern = En_Graph_Pattern
            With .Line_DummyKind
                .Back.Line = clsVB6File.convertLineProperty(oldML.Line_DummyKind.BGLine)
                .Back.Tile = clsVB6File.convertTileProperty(oldML.Line_DummyKind.BGTile)
                .Back.Round = 0
                .Back.Padding = 1
                .Dummy_Point_Visible = oldML.Line_DummyKind.Dummy_Point_Visible
                .Line_Pattern = oldML.Line_DummyKind.Line_Pattern
                .Line_Visible = oldML.Line_DummyKind.Line_Visible
                .Line_Visible_Number_STR = oldML.Line_DummyKind.Line_Visible_Number_STR
            End With
            With .MarkMD
                .CircleMD_CircleMini_F = oldML.MarkMD.CircleMD_CircleMini_F
                .MultiEnMode_Line = clsVB6File.convertLineProperty(oldML.MarkMD.MultiEnMode_Line)
            End With
        End With
        Return MapLegend
    End Function
    Public Shared Function convertCompassProperty(ByRef oldCompass As Compass_Attri_v11) As clsMapData.strCompass_Attri
        Dim MapCompass As clsMapData.strCompass_Attri
        With oldCompass
            MapCompass.dirWord.East = .Estr
            MapCompass.dirWord.West = .Wstr
            MapCompass.dirWord.North = .Nstr
            MapCompass.dirWord.South = .Sstr
            MapCompass.Visible = .Visible
            MapCompass.Font = clsVB6File.convertFontProperty(.Font)
            MapCompass.Mark = clsVB6File.convertMarkProperty(.Mark)
            MapCompass.Position.X = .X
            MapCompass.Position.Y = .Y
        End With
        Return MapCompass
    End Function
    Public Shared Function convertLineEdgeProperty(ByRef oldLineEdge As Edge_Connect_Pattern_Data_Info_v11) As LineEdge_Connect_Pattern_Data_Info
        Dim Edge As LineEdge_Connect_Pattern_Data_Info
        With oldLineEdge
            Select Case .Edge_Pattern
                Case 0
                    Edge.Edge_Pattern = enmEdge_Pattern.Round
                Case 1
                    Edge.Edge_Pattern = enmEdge_Pattern.Rectangle
                Case 2
                    Edge.Edge_Pattern = enmEdge_Pattern.Flat
            End Select
            Select Case .Join_Pattern
                Case 0
                    Edge.Join_Pattern = enmJoinPattern.Round
                Case 1
                    Edge.Join_Pattern = enmJoinPattern.Bevel
                Case 2
                    Edge.Join_Pattern = enmJoinPattern.Miter
            End Select
            Edge.MiterLimitValue = .MiterLimitValue
        End With
        Return Edge
    End Function
    Public Shared Function convertLineProperty(ByRef oldLine As Line_Property_v11) As Line_Property
        'v11の線種プロパティを新しいものに変換
        Dim newLine As Line_Property = clsBase.Line
        With oldLine
            newLine.Edge_Connect_Pattern = convertLineEdgeProperty(.Edge_Connect_Pattern)
            With .BasicLine
                newLine.BasicLine.pattern = .pattern
                newLine.BasicLine.SolidLine.Color = New colorARGB(255, ColorTranslator.FromWin32(.SolidLine.Color).ToArgb)
                newLine.BasicLine.SolidLine.Width = .SolidLine.Width
                For i As Integer = 0 To 5
                    Dim clParts As OptionalLine_Data_info
                    With .CenterLine(i)
                        clParts.Color = New colorARGB(255, ColorTranslator.FromWin32(.Color).ToArgb)
                        clParts.Length = .Length
                        clParts.Print_f = .Print_f
                        clParts.Use_F = .Use_F
                        clParts.Width = .Width
                    End With
                    newLine.BasicLine.Set_CenterLineParts(i, clParts)
                Next
            End With
            With .CrossLine
                newLine.CrossLine.XLine_f = .XLine_f
                For i As Integer = 0 To 5
                    Dim crlParts As Optional_X_Line_Data_info
                    With .XLine(i)
                        crlParts.Color = New colorARGB(255, ColorTranslator.FromWin32(.Color).ToArgb)
                        crlParts.Interval = .Interval
                        crlParts.Length = .Length
                        crlParts.pattern = .pattern
                        crlParts.TileMark = convertTileMarkProperty(.Mark)
                        If crlParts.pattern = enmLineCrossPattern.Mark Then
                            If crlParts.TileMark.PrintMark = enmMarkPrintType.Picture Then
                                '次世代MANDARAでは線の中に画像を入れないようにする
                                crlParts.TileMark.PrintMark = enmMarkPrintType.Mark
                            End If
                        End If
                        crlParts.Use_F = .Use_F
                        crlParts.Width = .Width
                    End With
                    newLine.CrossLine.Set_CrossLineParts(i, crlParts)
                Next
            End With
            With .ParallelLine
                newLine.ParallelLine.Center_Line_f = .Center_Line_f
                newLine.ParallelLine.CenterLine_ParaLine_f = .CenterLine_ParaLine_f
                newLine.ParallelLine.InnerColor = New colorARGB(255, ColorTranslator.FromWin32(.InnerColor).ToArgb)
                newLine.ParallelLine.InnerColor_f = .InnerColor
                newLine.ParallelLine.Interval = .Interval
                With .P_CenterLine
                    For i As Integer = 0 To 5
                        Dim clParts As OptionalLine_Data_info
                        With .CenterLine(i)
                            clParts.Color = New colorARGB(255, ColorTranslator.FromWin32(.Color).ToArgb)
                            clParts.Length = .Length
                            clParts.Print_f = .Print_f
                            clParts.Use_F = .Use_F
                            clParts.Width = .Width
                        End With
                        newLine.ParallelLine.P_CenterLine.Set_CenterLineParts(i, clParts)
                    Next
                    newLine.ParallelLine.P_CenterLine.pattern = .pattern
                    With .SolidLine
                        newLine.ParallelLine.P_CenterLine.SolidLine.Color = New colorARGB(255, ColorTranslator.FromWin32(.Color).ToArgb)
                        newLine.ParallelLine.P_CenterLine.SolidLine.Width = .Width
                    End With
                End With
                newLine.ParallelLine.P_Line_f = .P_Line_f
            End With
        End With
        Return newLine
    End Function
    ''' <summary>
    ''' vb6のタイルプロパティを新しいものに変換
    ''' </summary>
    ''' <param name="oldTile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function convertTileProperty(ByRef oldTile As Tile_Property_v11) As Tile_Property
        '
        Dim newTile As Tile_Property = clsBase.Tile
        With oldTile
            newTile.BGColFlag = .BGColFlag
            newTile.BGCOLOR = New colorARGB(255, ColorTranslator.FromWin32(.BGCOLOR).ToArgb)
            newTile.Density = .Density
            newTile.Line = convertLineProperty(.Line)
            newTile.TileMark = convertTileMarkProperty(.Mark)
            newTile.TileCode = .TileCode
        End With
        Return newTile
    End Function
    ''' <summary>
    ''' vb6のフォントプロパティを新しいものに変換
    ''' </summary>
    ''' <param name="oldFont"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function convertFontProperty(ByRef oldFont As Font_Property_v11) As Font_Property
        '
        Dim newFont As Font_Property = clsBase.Font
        With oldFont
            With .Body
                newFont.Body.bold = .bold
                newFont.Body.Color = New colorARGB(255, ColorTranslator.FromWin32(.Color).ToArgb)
                newFont.Body.italic = .italic
                newFont.Body.Kakudo = .Kakudo
                newFont.Body.Name = .Name
                newFont.Body.Size = .Size
                newFont.Body.Underline = .Underline
                newFont.Body.FringeF = False
                newFont.Body.FringeColor = New colorARGB(Color.White)
                newFont.Body.FringeWidth = 60
            End With
            newFont.Back.Line = convertLineProperty(.frameLine)
            newFont.Back.Tile = convertTileProperty(.Tile)
            newFont.Back.Round = 0
            newFont.Back.Padding = 0
        End With
        Return newFont
    End Function
    ''' <summary>
    ''' 文字の縁取りの変換
    ''' </summary>
    ''' <param name="oldFringe"></param>
    ''' <param name="newFont"></param>
    ''' <remarks></remarks>
    Private Shared Sub convertFontFringe(ByVal oldFringe As FontFringe_Info, ByRef newFont As Font_Property)
        newFont.Body.FringeColor = New colorARGB(255, ColorTranslator.FromWin32(oldFringe.FringeColor).ToArgb)
        Select Case oldFringe.FringeSize
            Case 0
                newFont.Body.FringeF = False
            Case 1
                newFont.Body.FringeF = True
                newFont.Body.FringeWidth = 60
            Case 2
                newFont.Body.FringeF = True
                newFont.Body.FringeF = 10
        End Select
    End Sub
    ''' <summary>
    ''' vb6の記号プロパティを新しいものに変換
    ''' </summary>
    ''' <param name="oldMark"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function convertMarkProperty(ByRef oldMark As Mark_Property_v11) As Mark_Property
        '
        Dim newMark As Mark_Property = clsBase.Mark
        With oldMark
            newMark.Line = convertLineProperty(.Line)
            newMark.ShapeNumber = .Shape
            newMark.PictureNumber = .PictureNumber
            newMark.PrintMark = .PrintMark
            newMark.WordFont = convertFontProperty(.WordFont)
            newMark.wordmark = .wordmark
            newMark.Tile = convertTileProperty(.Tile)
            newMark.PictureAlpahValue = 255
        End With
        Return newMark
    End Function
    ''' <summary>
    ''' vb6のタイル記号プロパティを新しいものに変換
    ''' </summary>
    ''' <param name="oldTileMark"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function convertTileMarkProperty(ByRef oldTileMark As Tile_Mark_v11) As Tile_Mark_Property
        '
        Dim newTileMark As New Tile_Mark_Property
        With oldTileMark
            newTileMark.Kakudo = .Kakudo
            newTileMark.Mark_Line_Color = New colorARGB(255, ColorTranslator.FromWin32(.Mark_Line_Color).ToArgb)
            newTileMark.PictureNumber = .PictureNumber
            newTileMark.PrintMark = .PrintMark
            newTileMark.ShapeNumber = .Shape
            newTileMark.WordFontName = .WordFontName
            newTileMark.wordmark = .wordmark
        End With
        Return newTileMark
    End Function

    Public Shared Function convertBoxDataSingle(ByVal BoxDataSingle As Box_Data_single_v11) As RectangleF
        With BoxDataSingle
            Return RectangleF.FromLTRB(.left, .top, .right, .bottom)
        End With
    End Function

    Public Shared Function convertSingleXY(ByVal singleXY As SingleXY_v1275) As PointF
        Return New PointF(singleXY.x, singleXY.y)
    End Function

    Public Shared Function convertArrow(ByRef oldArrow As clsOldMDRFile.Arrow_Data_v1275) As Arrow_Data
        Dim Arrow As Arrow_Data
        With Arrow
            .Angle = oldArrow.Kakudo
            .ArrowHeadType = oldArrow.type
            .End_Arrow_F = oldArrow.End_Arrow_F
            .LWidthRatio = oldArrow.LWidthRatio
            .Start_Arrow_F = oldArrow.Start_Arrow_F
            .WidthPlus = oldArrow.WidthPlus
        End With
        Return Arrow
    End Function

    Public Shared Function convertInnerData(ByRef oldInnerData As clsOldMDRFile.Inner_Data_Info_v1275) As clsAttrData.strInner_Data_Info
        Dim InData As clsAttrData.strInner_Data_Info
        With InData
            .Data = oldInnerData.Data
            .Flag = oldInnerData.Flag
            .Mode = oldInnerData.Mode

        End With
        Return InData
    End Function
    Private Shared Function Get_Data_Cell_Array(ByVal DataNum As Long, ByVal Layernum As Long, ByRef oldMDR As clsOldMDRFile.MDR_1275) As String()
        'データ項目のデータを配列で取得
        Dim attrstac As Integer = oldMDR.Layer(Layernum).Data.Stac + DataNum
        Dim stacn As Integer = oldMDR.attData(attrstac).DTA.DataCellStac
        Dim DataType_Number As Integer = oldMDR.attData(attrstac).DTA.DataType
        Dim dtSubtype As Integer = oldMDR.attData(attrstac).DTA.DataSubType
        Dim n As Integer = oldMDR.Layer(Layernum).ObjectPos.Object_n
        Dim m(n - 1) As String
        Select Case DataType_Number
            Case 0
                For i As Integer = 0 To n - 1
                    Select Case dtSubtype
                        Case 0
                            m(i) = Str(oldMDR.DataByteCell(stacn + i))
                        Case 1
                            m(i) = Str(oldMDR.DataIntegerCell(stacn + i))
                        Case 2
                            m(i) = Str(oldMDR.DataLongCell(stacn + i))
                        Case 3
                            m(i) = Str(oldMDR.DataSingleCell(stacn + i))
                        Case 4
                            m(i) = Str(oldMDR.DataDoubleCell(stacn + i))
                    End Select
                Next
            Case 1
                Dim dstc As Integer = oldMDR.attData(attrstac).DTA.Div_Stac
                For i As Integer = 0 To n - 1
                    Dim v As Integer = oldMDR.DataByteCell(stacn + i)
                    m(i) = oldMDR.Class_Div(dstc + v).Cat_Name
                Next
            Case 2
                For i As Integer = 0 To n - 1
                    m(i) = oldMDR.DataString(stacn + i)
                Next
        End Select

        Dim Mis_Num As Integer = oldMDR.attData(attrstac).DTA.Missing_num
        Dim Mis_stac As Integer = oldMDR.attData(attrstac).DTA.Missing_Stac


        For i As Integer = 0 To Mis_Num - 1
            m(oldMDR.Missing_DataStac(i + Mis_stac)) = ""
        Next
        Return m
    End Function
    ''' <summary>
    ''' MDRのバイナリ画像データをBITMAPに変換
    ''' </summary>
    ''' <param name="MDRBinaryData"></param>
    ''' <param name="Width"></param>
    ''' <param name="Height"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function CreateBitMapFromMDRBinaryData(ByRef MDRBinaryData As Byte(), ByVal Width As Integer, ByVal Height As Integer) As Bitmap
        Dim img_base As New Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        Dim pixelSize_base As Integer = 3
        Dim bmpDate_base As Drawing.Imaging.BitmapData = img_base.LockBits(New Rectangle(0, 0, img_base.Width, img_base.Height), _
                                         Drawing.Imaging.ImageLockMode.ReadWrite, img_base.PixelFormat)
        Dim ptr_base As IntPtr = bmpDate_base.Scan0
        Dim pixels_base As Byte() = New Byte(bmpDate_base.Stride * img_base.Height - 1) {}
        System.Runtime.InteropServices.Marshal.Copy(ptr_base, pixels_base, 0, pixels_base.Length)
        For y As Integer = 0 To Height - 1
            For x As Integer = 0 To Width - 1
                Dim pos As Integer = y * bmpDate_base.Stride + x * pixelSize_base
                Dim opos As Integer = y * Width * 3 + x * 3
                pixels_base(pos + 2) = MDRBinaryData(opos + 2)
                pixels_base(pos + 1) = MDRBinaryData(opos + 1)
                pixels_base(pos) = MDRBinaryData(opos)

            Next
        Next
        'ピクセルデータを元に戻す
        System.Runtime.InteropServices.Marshal.Copy(pixels_base, 0, ptr_base, pixels_base.Length)

        'ロックを解除する
        img_base.UnlockBits(bmpDate_base)
        Return img_base
    End Function

    ''' <summary>
    ''' 旧MDRデータを現在の属性データに変換
    ''' </summary>
    ''' <param name="oldMDRData"></param>
    ''' <remarks></remarks>
    Public Shared Sub CONVERT_From_oldMDRFile(ByRef oldMDRData As clsOldMDRFile.MDR_1275, newData As clsAttrData, ByRef ObjectErrorMessage As String)
        With newData.TotalData
            With .LV1
                .Comment = oldMDRData.TotalData.LV1.Comment
                .Lay_Maxn = oldMDRData.TotalData.LV1.Lay_Maxn
                .Print_Mode_Total = oldMDRData.TotalData.LV1.Print_Mode_Total
                .SelectedLayer = oldMDRData.TotalData.LV1.Layn
            End With
            With .ViewStyle
                .initViewStyle(newData.TileMap.getTileMap_by_Name("地理院地図（標準地図）"))
                .AttMapCompass = clsVB6File.convertCompassProperty(oldMDRData.TotalData.ViewStyle.AttMapCompass)
                With .ScrData
                    Dim oldSCR As clsOldMDRFile.Screen_info_v1275 = oldMDRData.TotalData.ScrData
                    If oldMDRData.TotalData.ViewStyle.Accessory_Base_Set_Screen = True Then
                        .Accessory_Base = enmBasePosition.Screen
                    Else
                        .Accessory_Base = enmBasePosition.Map
                    End If
                    .frmPrint_FormSize = convertFrmPrintSize(oldSCR.frmPrint_FormSize)
                    .GSMul = oldSCR.GSMul
                    .MapRectangle = clsVB6File.convertBoxDataSingle(oldSCR.MapRectangle)
                    .MapScreen_Scale = Rectangle.FromLTRB(oldSCR.MapScreen_Scale.left, oldSCR.MapScreen_Scale.top, oldSCR.MapScreen_Scale.right, oldSCR.MapScreen_Scale.top)
                    .PrinterMG = oldSCR.PrinterMG
                    With .Screen_Margin
                        .Top = oldSCR.Screen_Margin.top
                        .Right = oldSCR.Screen_Margin.right
                        .Left = oldSCR.Screen_Margin.left
                        .Bottom = oldSCR.Screen_Margin.bottom
                        .ClipF = False
                    End With
                    With .ScreenMG
                        .Mul = oldSCR.ScreenMG.Mul
                        .Xplus = oldSCR.ScreenMG.Xplus
                        .YPlus = oldSCR.ScreenMG.YPlus
                    End With
                    .ScrRectangle = clsVB6File.convertBoxDataSingle(oldSCR.ScrRectangle)
                    .ScrView = clsVB6File.convertBoxDataSingle(oldSCR.ScrView)
                    '.STDWsize=
                    .ThreeDMode = clsVB6File.convertThreeDMode(oldMDRData.TotalData.ViewStyle.ThreeDMode)
                End With
                .Dummy_Size_Flag = oldMDRData.TotalData.ViewStyle.Dummy_Size_Flag
                '点ダミーオブジェクトの記号
                .DummyObjectPointMark = New Dictionary(Of String, clsAttrData.strDummyObjectPointMark_Info())
                Dim ObjG As Dictionary(Of String, String()) = newData.GetAllObjectGroupName
                Dim objg0name() As String = ObjG(oldMDRData.TotalData.LV1.MapFile.ToUpper)
                Dim PointObjG As Dictionary(Of String, String()) = newData.GetAllPointObjectGroup
                For Each pair As KeyValuePair(Of String, String()) In PointObjG
                    If pair.Value.Length > 0 Then
                        Dim d(pair.Value.Length - 1) As clsAttrData.strDummyObjectPointMark_Info
                        For i As Integer = 0 To pair.Value.Length - 1
                            With d(i)
                                .ObjectKindName = pair.Value(i)
                                Dim n As Integer = Array.IndexOf(objg0name, pair.Value(i))
                                If n <> -1 Then
                                    .Mark = clsVB6File.convertMarkProperty(oldMDRData.Dummy_Object_Mark(n))
                                Else
                                    .Mark = clsBase.Mark
                                End If
                            End With
                        Next
                        .DummyObjectPointMark.Add(pair.Key, d)
                    End If
                Next

                With .LatLonLine_Print
                    Dim oldIdoKedo As clsOldMDRFile.IdoKeido_Print_Info_v1275 = oldMDRData.TotalData.ViewStyle.IdoKeido_Print
                    .Lat_Interval = oldIdoKedo.Ido_Interval
                    .Lon_Interval = oldIdoKedo.Kedo_Interval
                    .LPat = clsVB6File.convertLineProperty(oldIdoKedo.LPat)
                    If oldIdoKedo.Order = -1 Then
                        oldIdoKedo.Order = 0
                    End If
                    .Order = oldIdoKedo.Order
                    .Visible = oldIdoKedo.Visible
                End With
                .MapLegend = clsVB6File.convertMapLegend(oldMDRData.TotalData.ViewStyle.MapLegend, oldMDRData.LegendXY, oldMDRData.TotalData.ViewStyle.MapLegend.En_Graph_Pattern)
                .MapLegend.Base.Comma_f = oldMDRData.TotalData.ViewStyle.Comma_f
                .MapLegend.ClassMD.ClassBoundaryLine.LPat = clsVB6File.convertLineProperty(oldMDRData.TotalData.ViewStyle.ClassBoundaryLine.LPat)
                .MapLegend.ClassMD.ClassBoundaryLine.Visible = oldMDRData.TotalData.ViewStyle.ClassBoundaryLine.Visible

                With .MapLegend.OverLay_Legend_Title
                    .MaxWidth = oldMDRData.TotalData.ViewStyle.OverLay_Legend_Title.MaxWidth
                    .Print_f = oldMDRData.TotalData.ViewStyle.OverLay_Legend_Title.Print_f
                End With
                .MapPrint_Flag = oldMDRData.TotalData.ViewStyle.MapPrint_Flag
                .MapScale = clsVB6File.convertMapSCL(oldMDRData.TotalData.ViewStyle.MapScale)
                .MapTitle = clsVB6File.convertMapTitle(oldMDRData.TotalData.ViewStyle.MapTitle)
                If .ScrData.Accessory_Base = enmBasePosition.Screen Then
                    With .DataNote.Position
                        .X = 0.8
                        .Y = 0.8
                    End With
                Else
                    With .DataNote.Position
                        .X = newData.TotalData.ViewStyle.ScrData.MapRectangle.Left + newData.TotalData.ViewStyle.ScrData.MapRectangle.Width
                        .Y = newData.TotalData.ViewStyle.ScrData.MapRectangle.Bottom - newData.TotalData.ViewStyle.ScrData.MapRectangle.Height * 0.2
                    End With
                End If

                With .Missing_Data
                    Dim oldMD As clsOldMDRFile.Missing_set_v1275 = oldMDRData.TotalData.ViewStyle.Missing_Data
                    .BlockMark = clsVB6File.convertMarkProperty(oldMD.BlockMark)
                    .ClassMark = clsVB6File.convertMarkProperty(oldMD.ClassMark)
                    .HatchTile = clsVB6File.convertTileProperty(oldMD.HatchTile)
                    .Label = oldMD.Label
                    .LineShape = clsVB6File.convertLineProperty(oldMD.LineShape)
                    .Mark = clsVB6File.convertMarkProperty(oldMD.Mark)
                    .MarkBar = clsBase.Mark
                    .PaintTile = clsVB6File.convertTileProperty(oldMD.PaintTile)
                    .Print_Flag = oldMD.Print_Flag
                    .Text = oldMD.Text
                    .TurnMark = clsVB6File.convertMarkProperty(oldMD.TurnMark)
                End With
                .PointPaint_Order = oldMDRData.TotalData.ViewStyle.PointPaint_Order
                With .Screen_Back
                    .MapAreaFrameLine = clsBase.BlancLine
                    .ScreenFrameLine = clsVB6File.convertLineProperty(oldMDRData.TotalData.ViewStyle.Screen_Back.LinePat)
                    .MapAreaBack = clsVB6File.convertTileProperty(oldMDRData.TotalData.ViewStyle.Screen_Back.TileBack)
                    .ScreenAreaBack = .MapAreaBack
                    .ObjectInner = clsVB6File.convertTileProperty(oldMDRData.TotalData.ViewStyle.Screen_Back.TileInner)
                End With
                .Screen_Setting = New List(Of clsAttrData.strScreen_Setting_Data_Info)
                For i As Integer = 0 To oldMDRData.TotalData.StacSize.Screen_Setting_Num - 1
                    Dim oldSS As clsOldMDRFile.Screen_Setting_Info_v1275 = oldMDRData.Screen_Setting_DataSet(i)
                    Dim d As clsAttrData.strScreen_Setting_Data_Info
                    With d
                        If oldSS.Accessory_Base_Set_Screen = True Then
                            .Accessory_Base = enmBasePosition.Screen
                        Else
                            .Accessory_Base = enmBasePosition.Map
                        End If
                        .AttMapCompass = clsVB6File.convertCompassProperty(oldSS.AttMapCompass)
                        .frmPrint_FormSize = convertFrmPrintSize(oldSS.frmPrint_FormSize)
                        .MapLegend = clsVB6File.convertMapLegend(oldSS.MapLegend, oldMDRData.LegendXY, oldMDRData.TotalData.ViewStyle.MapLegend.En_Graph_Pattern)
                        .MapLegend.Base.LegendXY = Get_SingleXY_From_StringXY(oldSS.LegendXstr, oldSS.LegendYstr)
                        .MapLegend.ClassMD.CategorySeparate_f = False
                        .MapScale = clsVB6File.convertMapSCL(oldSS.MapScale)
                        .MapTitle = clsVB6File.convertMapTitle(oldSS.MapTitle)
                        With .Screen_Margin
                            .Top = oldSS.Screen_Margin.top
                            .Right = oldSS.Screen_Margin.right
                            .Left = oldSS.Screen_Margin.left
                            .Bottom = oldSS.Screen_Margin.bottom
                            .ClipF = False
                        End With
                        .ScrView = clsVB6File.convertBoxDataSingle(oldSS.ScrView)
                        .ThreeDMode = clsVB6File.convertThreeDMode(oldSS.ThreeDMode)
                        .title = oldSS.title
                    End With
                    .Screen_Setting.Add(d)
                Next
                With .SouByou
                    Dim oldIdoKedo As clsOldMDRFile.SouByou_Info_v1275 = oldMDRData.TotalData.ViewStyle.SouByou
                    .Auto = False
                    .AutoDegree = 2
                    .LoopSize = oldIdoKedo.LoopSize
                    .PointInterval = oldIdoKedo.PointInterval
                    .Spline_F = oldIdoKedo.Spline_F
                    .ThinningPrint_F = oldIdoKedo.ThinningPint_F
                    .LoopAreaF = oldIdoKedo.ThinningPint_F
                End With
                With .SymbolLine
                    .Visible = oldMDRData.TotalData.ViewStyle.SymbolLine.Visible
                    .Line = clsVB6File.convertLineProperty(oldMDRData.TotalData.ViewStyle.SymbolLine.Line)
                End With
                With .TileMapView
                    Dim oldTM As clsOldMDRFile.WebMapServide_Info_v1275 = oldMDRData.TotalData.ViewStyle.WMS
                    .ViewData.AlphaValue = (100 - oldTM.Alpha) * 2.55
                    .DrawTiming = oldTM.Timing
                    .Visible = False
                    .ViewData.TransparentF = False
                    .ViewData.TileMapDataSet = newData.TileMap.getTileMap_by_Name("地理院地図（標準地図）")
                End With
                With .Trip_Line
                    Dim oldTM As clsOldMDRFile.Trip_Line_Data_v1275 = oldMDRData.TotalData.ViewStyle.Trip_Line
                    .EndPoint_Mark = clsVB6File.convertMarkProperty(oldTM.EndPoint_Mark)
                    .Frame_Line = clsVB6File.convertLineProperty(oldTM.Frame_Line)
                    .Frame_Print = oldTM.Frame_Print
                    .Height = oldTM.Height
                    .Overlap_Mode = oldTM.Overlap_Mode
                    .Start_End_Print = oldTM.Start_End_Print
                    .StartPoint_Mark = clsVB6File.convertMarkProperty(oldTM.StartPoint_Mark)
                    .Stay_Line = clsVB6File.convertLineProperty(oldTM.Stay_Line)
                    .TimeLegend_Font = clsVB6File.convertFontProperty(oldTM.TimeLegend_Font)
                    .TimeLegend_Position = oldTM.TimeLegend_Position
                    .Trip_Line = clsVB6File.convertLineProperty(oldTM.Trip_Line)
                    .VerticalLine = clsVB6File.convertLineProperty(oldTM.VerticalLine)
                    .ZeroLine = clsVB6File.convertLineProperty(oldTM.ZeroLine)
                    .ZeroLineF = oldTM.ZeroLineF
                    .ZeroPoint_Mark = clsVB6File.convertMarkProperty(oldTM.ZeroPoint_Mark)
                    .ZeroPointF = oldTM.ZeroPointF
                End With
                .Zahyo = newData.GetPrestigeZahyoMode
            End With

            .Condition = New List(Of clsAttrData.strCondition_DataSet_Info)
            For i As Integer = 0 To oldMDRData.TotalData.StacSize.ConditionDataSetNum - 1
                Dim d As clsAttrData.strCondition_DataSet_Info
                With d
                    .Enabled = oldMDRData.Condition_DataSet(i).Enabled
                    .Layer = oldMDRData.Condition_DataSet(i).Layer
                    .Name = oldMDRData.Condition_DataSet(i).Name
                    .Condition_Class = New List(Of clsAttrData.strCondition_Data_Info)
                    For j As Integer = 0 To 4
                        Dim dt As clsAttrData.strCondition_Data_Info
                        With dt
                            .Condition = New List(Of clsAttrData.strCondition_Limitation_Info)
                            .And_OR = oldMDRData.Condition_Class(j, i).And_OR
                            Dim dtItem As clsAttrData.strCondition_Limitation_Info
                            For k As Integer = 0 To oldMDRData.Condition_Class(j, i).Num - 1
                                With dtItem
                                    .Condition = oldMDRData.Condition(k, j, i).Condition
                                    .Data = oldMDRData.Condition(k, j, i).Data
                                    .Val = oldMDRData.Condition(k, j, i).Val
                                End With
                            Next
                            dt.Condition.Add(dtItem)
                        End With
                        If dt.Condition.Count > 0 Then
                            .Condition_Class.Add(dt)
                        End If
                    Next
                End With
                .Condition.Add(d)
            Next

            With .TotalMode
                With .OverLay
                    .SelectedIndex = oldMDRData.TotalData.LV1.OverLay.OverN
                    .DataSet = New List(Of clsAttrData.strOverLay_Dataset_Info)
                    Dim aoi As Integer = -1
                    For i As Integer = 0 To oldMDRData.TotalData.LV1.OverLay.Number - 1
                        Dim DataSetSub As clsAttrData.strOverLay_Dataset_Info
                        With DataSetSub
                            Dim old As clsOldMDRFile.OverLay_Dataset_Info_v1275 = oldMDRData.OverLay_DataSet(i)
                            .SelectedIndex = 0
                            .title = old.title
                            .DataItem = New List(Of clsAttrData.strOverLay_DataSet_Item_Info)
                            .Note = ""
                            If old.AlwaysPrint_Flag = True Then
                                aoi = i
                            End If
                            For j As Integer = 0 To old.Number - 1
                                Dim d As clsAttrData.strOverLay_DataSet_Item_Info
                                With d
                                    Dim oldd As clsOldMDRFile.OvetLay_DataSet_Item_Info_v1275 = oldMDRData.OverLay_DataStac(old.Stac + j)
                                    .DataNumber = oldd.DatN
                                    .Layer = oldd.Layer
                                    .Legend_Print_Flag = oldd.Legend_Print_Flag
                                    .Mode = oldd.Mode
                                    .Print_Mode_Layer = oldd.Print_Mode_Layer
                                End With
                                .DataItem.Add(d)
                            Next
                        End With
                        .DataSet.Add(DataSetSub)
                    Next
                    .Always_Overlay_Index = aoi
                End With
                With .Series
                    .SelectedIndex = oldMDRData.TotalData.LV1.Series.SeriN
                    .DataSet = New List(Of clsAttrData.strSeries_Dataset_Info)
                    For i As Integer = 0 To oldMDRData.TotalData.LV1.Series.Number - 1
                        Dim DataSetSub As clsAttrData.strSeries_Dataset_Info
                        With DataSetSub
                            Dim old As clsOldMDRFile.Series_Dataset_Info_v1275 = oldMDRData.Series_DataSet(i)
                            .SelectedIndex = 0
                            .title = old.title
                            .DataItem = New List(Of clsAttrData.strSeries_DataSet_Item_Info)
                            For j As Integer = 0 To old.Number - 1
                                Dim d As clsAttrData.strSeries_DataSet_Item_Info
                                With d
                                    Dim oldd As clsOldMDRFile.Series_DataSet_Item_Info_v1275 = oldMDRData.Series_DataStac(old.Stac + j)
                                    .Data = oldd.Data
                                    .Layer = oldd.Layer
                                    .Print_Mode_Layer = oldd.Print_Mode_Layer
                                    .Print_Mode_Total = oldd.Print_Mode_Total
                                    .SoloMode = oldd.Mode
                                End With
                                .DataItem.Add(d)
                            Next
                        End With
                        .DataSet.Add(DataSetSub)
                    Next
                End With
            End With
            .FigureStac = New List(Of Object)
            '図形の設定
            newData.TotalData.ViewStyle.FigureVisible = oldMDRData.TotalData.ViewStyle.Fig.Visible

            For i As Integer = 0 To oldMDRData.TotalData.ViewStyle.Fig.Number - 1
                Dim wk As Integer = oldMDRData.Figure(i).Index
                Dim FigData As clsAttrData.strFigure_data
                FigData.Layer = oldMDRData.Figure(i).Layer
                FigData.Data = oldMDRData.Figure(i).Data
                Select Case oldMDRData.Figure(i).Figure_code
                    Case 0
                        Dim word_fig As clsAttrData.strFig_Word_Data
                        With word_fig
                            .Caption = oldMDRData.Fig_Word(wk).Caption
                            .Font = convertFontProperty(oldMDRData.Fig_Word(wk).Font)
                            convertFontFringe(oldMDRData.Fig_Word(wk).FontFringe, .Font)
                            .Scattered_Mode_F = oldMDRData.Fig_Word(wk).Individual_Mode_F
                            .StringPos = Get_SingleXY_From_StringXY(oldMDRData.Fig_Word(wk).Xstr, oldMDRData.Fig_Word(wk).Ystr)
                            .Data = FigData
                        End With
                        .FigureStac.Add(word_fig)
                    Case 1
                        Dim Line_fig As clsAttrData.strFig_Line_Data
                        With Line_fig
                            .Arrow = convertArrow(oldMDRData.Fig_Line(wk).Arrow)
                            .Circumscribed_Rectangle = convertBoxDataSingle(oldMDRData.Fig_Line(wk).Circumscribed_Rectangle)
                            .FillFlag = oldMDRData.Fig_Line(wk).FillFlag
                            .NumOfPoint = oldMDRData.Fig_Line(wk).NumOfPoint
                            .Patttern = convertLineProperty(oldMDRData.Fig_Line(wk).Pat)
                            ReDim .Points(.NumOfPoint - 1)
                            For j As Integer = 0 To .NumOfPoint - 1
                                .Points(j) = convertSingleXY(oldMDRData.Fig_Line_XY(oldMDRData.Fig_Line(wk).PointStac + j))
                            Next
                            .Spline = oldMDRData.Fig_Line(wk).Spline
                            .Tile = convertTileProperty(oldMDRData.Fig_Line(wk).Tile)
                            .Data = FigData
                        End With
                        .FigureStac.Add(Line_fig)
                    Case 2
                        Dim circle_fig As clsAttrData.strFig_Circle_data
                        With circle_fig
                            .Position = New PointF(oldMDRData.Fig_Circle(wk).X, oldMDRData.Fig_Circle(wk).Y)
                            .Printcenter = oldMDRData.Fig_Circle(wk).Printcenter
                            .XR = oldMDRData.Fig_Circle(wk).XR
                            .YR = oldMDRData.Fig_Circle(wk).YR
                            .Mark = convertMarkProperty(oldMDRData.Fig_Circle(wk).Mark)
                            .LinePat = convertLineProperty(oldMDRData.Fig_Circle(wk).Pat)
                            .Tile = convertTileProperty(oldMDRData.Fig_Circle(wk).Tile)
                            .Angle = oldMDRData.Fig_Circle(wk).Angle
                            .Data = FigData
                        End With
                        .FigureStac.Add(circle_fig)
                    Case 3
                        Dim point_fig As clsAttrData.strFig_Point_Data
                        With point_fig
                            .Caption = oldMDRData.Fig_Point(wk).Caption
                            .Caption_F = oldMDRData.Fig_Point(wk).Caption_F
                            .CaptionPosition = New PointF(oldMDRData.Fig_Point(wk).CaptionX, oldMDRData.Fig_Point(wk).CaptionY)
                            .Font = convertFontProperty(oldMDRData.Fig_Point(wk).Font)
                            .Mark = convertMarkProperty(oldMDRData.Fig_Point(wk).Mark)
                            .NumOfPoint = oldMDRData.Fig_Point(wk).NumOfPoint
                            ReDim .Points(.NumOfPoint - 1)
                            For j As Integer = 0 To .NumOfPoint - 1
                                .Points(j) = convertSingleXY(oldMDRData.Fig_Point_XY(oldMDRData.Fig_Point(wk).PointStac + j))
                            Next
                            .Data = FigData
                        End With
                        .FigureStac.Add(point_fig)
                    Case 4
                        Dim gazo_fig As clsAttrData.strFig_gazo_data
                        With gazo_fig
                            .Angle = oldMDRData.Fig_Gazo(wk).Angle
                            .Back = oldMDRData.Fig_Gazo(wk).Back
                            .Inner_Color = New colorARGB(255, ColorTranslator.FromWin32(oldMDRData.Fig_Gazo(wk).Inner_Color).ToArgb)
                            .InnerCol_F = oldMDRData.Fig_Gazo(wk).InnerCol_F
                            .LinePat = convertLineProperty(oldMDRData.Fig_Gazo(wk).LinePat)
                            .PictureNumber = oldMDRData.Fig_Gazo(wk).PictureNumber
                            .Position = New PointF(oldMDRData.Fig_Gazo(wk).X, oldMDRData.Fig_Gazo(wk).Y)
                            .Size = oldMDRData.Fig_Gazo(wk).Size
                            .Data = FigData
                            .AlphaValue = 255
                        End With
                        .FigureStac.Add(gazo_fig)
                End Select
            Next

            With .BasePicture
                '画像の設定
                .PictureNum = oldMDRData.TotalData.StacSize.PictureNum
                If .PictureNum > 0 Then
                    For i As Integer = 0 To .PictureNum - 1
                        Dim picP As Picture_Property
                        With picP
                            .Alternate_Color = New colorARGB(255, ColorTranslator.FromWin32(oldMDRData.BasePicture(i).Alternate_Color).ToArgb)
                            .Alternate_f = oldMDRData.BasePicture(i).Alternate_f
                            .Size.Height = oldMDRData.BasePicture(i).Height
                            .Size.Width = oldMDRData.BasePicture(i).Width
                            .TransParency_f = oldMDRData.BasePicture(i).TransParency_f
                            .TransParency_Color = New colorARGB(255, ColorTranslator.FromWin32(oldMDRData.BasePicture(i).TransParency_Color).ToArgb)
                            Dim img As New Bitmap(.Size.Width, .Size.Height)
                            Dim g As Graphics = Graphics.FromImage(img)
                            g.FillRectangle(New SolidBrush(Color.FromArgb(200, 230, 230, 230)), g.VisibleClipBounds)
                            g.Dispose()
                            .SetBitmap(img)
                            '10.0.1.6以降使用しない
                            '      .SetBitmap(CreateBitMapFromMDRBinaryData(oldMDRData.BasePicture(i).bitmapbyte, .Size.Width, .Size.Height))
                        End With
                        .PictureData.Add(picP)
                    Next
                    ObjectErrorMessage += "旧属性データファイル(MDRファイル)の画像は読み込めません。" + vbCrLf
                End If
            End With

        End With

        ReDim newData.LayerData(newData.TotalData.LV1.Lay_Maxn - 1)
        For i As Integer = 0 To newData.TotalData.LV1.Lay_Maxn - 1
            newData.LayerData(i).Set_MapFileData(newData.SetMapFile(oldMDRData.TotalData.LV1.MapFile))
            With newData.LayerData(i)
                .initLayerData()
                Dim ObkNum As Integer = .MapFileData.Map.OBKNum
                .MapFileName = oldMDRData.TotalData.LV1.MapFile
                .Name = oldMDRData.Layer(i).Name
                .Comment = ""
                .Print_Mode_Layer = oldMDRData.Layer(i).Print_Mode_Layer
                .Time = clsTime.GetYMD(oldMDRData.Layer(i).Time)
                Select Case oldMDRData.Layer(i).Shape
                    Case 0, 1, 2
                        .Shape = oldMDRData.Layer(i).Shape
                        .Type = clsAttrData.enmLayerType.Normal
                    Case 3
                        .Type = clsAttrData.enmLayerType.Trip_Definition
                        .Shape = enmShape.NotDeffinition
                    Case 4
                        .Type = clsAttrData.enmLayerType.Trip
                        .TripType = clsAttrData.enmTripPositionType.ObjectSet
                        .Shape = enmShape.NotDeffinition
                End Select
                With .Dummy
                    .Count = oldMDRData.Layer(i).NumOfDummy
                    If .Count > 0 Then
                        ReDim .DummyObj(.Count - 1)
                        For j As Integer = 0 To .Count - 1
                            With .DummyObj(j)
                                .Name = oldMDRData.Layer(i).DummySTC(j).Name
                                .code = oldMDRData.Layer(i).DummySTC(j).code
                            End With
                        Next
                    End If
                End With
                With .DummyGroup
                    ReDim .DummyObjG(ObkNum - 1)
                    Dim n As Integer = 0
                    For j As Integer = 0 To Math.Min(ObkNum, oldMDRData.Layer(i).Dummy_ObjectKindUse.Length) - 1
                        If oldMDRData.Layer(i).Dummy_ObjectKindUse(j) = True Then
                            .DummyObjG(n) = j
                            n += 1
                        End If
                    Next
                    ReDim Preserve .DummyObjG(Math.Max(n - 1, n))
                    .Count = n
                End With
                Dim TripDataObjCode() As String
                Dim TripDataArrivalTime() As String
                Dim TripDataDepartureTime() As String
                If .Type = clsAttrData.enmLayerType.Trip Then
                    TripDataObjCode = clsVB6File.Get_Data_Cell_Array(0, i, oldMDRData)
                    TripDataArrivalTime = clsVB6File.Get_Data_Cell_Array(1, i, oldMDRData)
                    TripDataDepartureTime = clsVB6File.Get_Data_Cell_Array(2, i, oldMDRData)
                End If
                With .atrObject
                    Dim old As clsOldMDRFile.Layer_Object_INfo_v1275 = oldMDRData.Layer(i).ObjectPos
                    Dim oldKenSTC As Integer = oldMDRData.Layer(i).ObjectPos.Stac
                    .NumOfSyntheticObj = old.NumOfSyntheticObj
                    If .NumOfSyntheticObj > 0 Then
                        Dim oldSTC As Integer = old.FirstSyntheticObj_Code
                        ReDim .MPSyntheticObj(.NumOfSyntheticObj - 1)
                        For j As Integer = 0 To .NumOfSyntheticObj - 1
                            Dim oldSyn As clsOldMDRFile.Synthetic_Object_Data_v1275 = oldMDRData.MPSyntheticObj(oldSTC + j)
                            With .MPSyntheticObj(j)
                                .CenterP = New PointF(oldSyn.CIX, oldSyn.CIY)
                                .Circumscribed_Rectangle = clsVB6File.convertBoxDataSingle(oldSyn.Circumscribed_Rectangle)
                                .Kind = oldSyn.Kind
                                .Name = oldSyn.Name
                                .NumOfObject = oldSyn.NumOfObject
                                ReDim .Objects(.NumOfObject - 1)
                                For k As Integer = 0 To .NumOfObject - 1
                                    With .Objects(k)
                                        .code = oldSyn.Objects(k).code
                                        .Draw_F = oldSyn.Objects(k).Draw_F
                                        .Name = oldSyn.Objects(k).Name
                                    End With
                                    .SETime.StartTime = clsTime.GetYMD(oldSyn.StartTime)
                                    .SETime.EndTime = clsTime.GetYMD(oldSyn.EndTime)
                                    .Shape = oldSyn.Shape
                                Next
                            End With
                        Next
                    End If

                    .ObjectNum = old.Object_n
                    Dim SyntheticObjCount As Integer = 0
                    If newData.LayerData(i).Type = clsAttrData.enmLayerType.Trip Then
                        ReDim .TripObjData(.ObjectNum - 1)
                    Else
                        ReDim .atrObjectData(.ObjectNum - 1)
                    End If
                    For j As Integer = 0 To .ObjectNum - 1
                        Dim oldKen As clsOldMDRFile.KenCode_data_info = oldMDRData.KenCode(oldKenSTC + j)
                        Select Case newData.LayerData(i).Type
                            Case clsAttrData.enmLayerType.Trip_Definition
                                With .atrObjectData(j)
                                    .Name = oldKen.Type.Name
                                    .Visible = True
                                End With
                            Case clsAttrData.enmLayerType.Trip
                                Dim subname As String = oldKen.Type.Name
                                With .TripObjData(j)
                                    .TripPersonName = Mid(subname, 1, InStr(subname, vbTab) - 1)
                                    .TripPersonCode = oldKen.Type.code
                                    If TripDataObjCode(j) = "" Then
                                        .PositionObjCode = -1
                                    Else
                                        .PositionObjCode = Val(TripDataObjCode(j))
                                    End If
                                    .PositionObjName = Mid(subname, InStr(subname, vbTab) + 1)
                                    If TripDataArrivalTime(j) = "" Then
                                        .PositionObjCode = -1
                                    Else
                                        .ArrivalTime = Get_YMD_from_Series(Val(TripDataArrivalTime(j)))
                                    End If
                                    If TripDataDepartureTime(j) = "" Then
                                        .PositionObjCode = -1
                                    Else
                                        .DepartureTime = Get_YMD_from_Series(Val(TripDataDepartureTime(j)))
                                    End If
                                End With
                            Case Else
                                With .atrObjectData(j)
                                    .Name = oldKen.Type.Name
                                    .Visible = True
                                    .Symbol = clsVB6File.convertSingleXY(oldKen.Type.Symbol)
                                    .Objectstructure = oldKen.Type.ObjectType
                                    If .Objectstructure = enmKenCodeObjectstructure.SyntheticObj Then
                                        .MpObjCode = SyntheticObjCount
                                        .CenterPoint = newData.LayerData(i).atrObject.MPSyntheticObj(SyntheticObjCount).CenterP
                                        SyntheticObjCount += 1
                                    Else
                                        .MpObjCode = oldKen.Type.code
                                        newData.LayerData(i).MapFileData.Get_Enable_CenterP(.CenterPoint, .MpObjCode, newData.LayerData(i).Time)
                                    End If
                                    .Label = clsVB6File.convertSingleXY(oldKen.Type.Label)
                                    If oldKen.URL.Address > "" Then
                                        Dim Cutad() As String = Split(oldKen.URL.Address, vbTab)
                                        Dim CutNamr() As String = Split(oldKen.URL.Name, vbTab)
                                        .HyperLinkNum = Cutad.Length
                                        ReDim .HyperLink(.HyperLinkNum - 1)
                                        For k As Integer = 0 To .HyperLinkNum - 1
                                            With .HyperLink(k)
                                                .Address = Cutad(k)
                                                If CutNamr.Length > k Then
                                                    .Name = CutNamr(k)
                                                End If
                                            End With
                                        Next
                                    Else
                                        .HyperLinkNum = 0
                                    End If
                                End With
                        End Select
                    Next
                End With

                With .atrData
                    .Count = oldMDRData.Layer(i).Data.Dat_maxn
                    .SelectedIndex = oldMDRData.Layer(i).Data.DatN
                    ReDim .Data(.Count - 1)
                    For j As Integer = 0 To .Count - 1
                        With .Data(j)
                            Dim old As clsOldMDRFile.Attribute_of_Data_v1275 = oldMDRData.attData(oldMDRData.Layer(i).Data.Stac + j)
                            .Title = old.DTA.title
                            .Unit = old.DTA.Unit
                            .Note = ""
                            .ModeData = old.ModeData.Mode
                            .MissingValueNum = old.DTA.Missing_num
                            .MissingF = (.MissingValueNum <> 0)
                            .EnableValueNum = old.DTA.Number
                            .DataType = clsGeneric.getAttDataType_From_TitleUnit(.Title, .Unit)
                            If .DataType = enmAttDataType.Strings Then
                                .ModeData = enmSoloMode_Number.StringMode
                            End If
                            With .Statistics
                                .Ave = old.DTA.Ave
                                .Max = old.DTA.Max
                                .Min = old.DTA.Min
                                .sa = old.DTA.sa
                                .STD = old.DTA.STD
                                .Sum = old.DTA.Sum
                            End With
                            With .SoloModeViewSettings
                                .Div_Num = old.DTA.Div_Num
                                .Div_Method = old.DTA.Div_Method
                                ReDim .Class_Div(.Div_Num - 1)
                                For k As Integer = 0 To .Div_Num - 1
                                    Dim oldc As clsOldMDRFile.Class_Div_data_v1275 = oldMDRData.Class_Div(old.DTA.Div_Stac + k)
                                    With .Class_Div(k)
                                        .Cat_Name = oldc.Cat_Name
                                        .Value = oldc.Value
                                        .ClassMark = clsVB6File.convertMarkProperty(oldc.ClassMark)
                                        .ODLinePat = clsVB6File.convertLineProperty(oldc.ODLinePat)
                                        .PaintColor = New colorARGB(255, ColorTranslator.FromWin32(oldc.PaintColor).ToArgb)
                                        .TilePat = clsVB6File.convertTileProperty(oldc.TilePat)
                                    End With
                                Next
                                .ClassMarkMD = clsVB6File.convertInnerData(old.SoloMode.ClassMarkMD)
                                With .ClassODMD

                                    .o_Layer = old.SoloMode.ODMD.o_Layer
                                    If old.SoloMode.ODMD.O_object > newData.LayerData(i).atrObject.ObjectNum Then
                                        .O_object = old.SoloMode.ODMD.O_object - newData.LayerData(i).atrObject.ObjectNum
                                        .Dummy_ObjectFlag = True
                                    Else
                                        .O_object = old.SoloMode.ODMD.O_object
                                        .Dummy_ObjectFlag = False
                                    End If
                                    .Arrow = clsVB6File.convertArrow(old.SoloMode.ODMD.Arrow)
                                End With
                                With .ClassPaintMD
                                    .Color_Mode = old.SoloMode.PaintMD.Color_Mode
                                    .color1 = New colorARGB(255, ColorTranslator.FromWin32(old.SoloMode.PaintMD.color1).ToArgb)
                                    .color2 = New colorARGB(255, ColorTranslator.FromWin32(old.SoloMode.PaintMD.color1).ToArgb)
                                    .color3 = New colorARGB(255, ColorTranslator.FromWin32(old.SoloMode.PaintMD.color1).ToArgb)
                                End With
                                With .ContourMD
                                    .Draw_in_Polygon_F = old.SoloMode.ContourMD.Draw_in_Polygon_F
                                    .Detailed = old.SoloMode.ContourMD.Detailed + 1
                                    .Interval_Mode = old.SoloMode.ContourMD.Interval_Mode
                                    .IrregularNum = 0
                                    ReDim .Irregular(9)
                                    For k As Integer = 0 To 9
                                        Dim v As String = old.SoloMode.ContourMD.Irregular.Value(k)
                                        If v <> "" Then
                                            With .Irregular(.IrregularNum)
                                                .Value = Val(v)
                                                .Line_Pat = clsVB6File.convertLineProperty(old.SoloMode.ContourMD.Irregular.Line_Pat(k))
                                            End With
                                            .IrregularNum += 1
                                        End If
                                    Next
                                    ReDim Preserve .Irregular(Math.Max(.IrregularNum - 1, 0))
                                    With .Regular
                                        .bottom = old.SoloMode.ContourMD.Regular.bottom
                                        .top = old.SoloMode.ContourMD.Regular.top
                                        .EX_Line_Pat = clsVB6File.convertLineProperty(old.SoloMode.ContourMD.Regular.EX_Line_Pat)
                                        Dim v As String = old.SoloMode.ContourMD.Regular.EX_Value
                                        .Interval = old.SoloMode.ContourMD.Regular.Interval
                                        .Line_Pat = clsVB6File.convertLineProperty(old.SoloMode.ContourMD.Regular.Line_Pat)
                                        .EX_Value = Val(v)
                                        .EX_Value_Flag = (v <> "")
                                        .EX_Line_Pat = clsVB6File.convertLineProperty(old.SoloMode.ContourMD.Regular.EX_Line_Pat)
                                        .SP_Bottom = old.SoloMode.ContourMD.Regular.SP_Bottom
                                        .SP_interval = old.SoloMode.ContourMD.Regular.SP_interval
                                        .SP_Top = old.SoloMode.ContourMD.Regular.top
                                        .SP_Line_Pat = clsVB6File.convertLineProperty(old.SoloMode.ContourMD.Regular.SP_Line_Pat)
                                    End With
                                    .Spline_flag = old.SoloMode.ContourMD.Spline_flag
                                End With
                                With .MarkCommon
                                    .Inner_Data = clsVB6File.convertInnerData(old.SoloMode.BlockMD.Inner_Data)
                                    .MinusTile = clsVB6File.convertTileProperty(old.SoloMode.BlockMD.MinusTile)
                                    .MinusLineColor = New colorARGB(255, ColorTranslator.FromWin32(old.SoloMode.CircleMD.MinusTile.Line.BasicLine.SolidLine.Color).ToArgb)
                                    .LegendPlusWord = oldMDRData.TotalData.ViewStyle.MapLegend.MarkMD.CirclrMD_Plus_Text
                                    .LegendMinusWord = oldMDRData.TotalData.ViewStyle.MapLegend.MarkMD.CirclrMD_Minus_Text
                                End With
                                With .MarkBlockMD
                                    .ArrangeB = old.SoloMode.BlockMD.ArrangeB
                                    .HasuVisible = old.SoloMode.BlockMD.Hasu
                                    .Mark = clsVB6File.convertMarkProperty(old.SoloMode.BlockMD.Mark)
                                    .Overlap = old.SoloMode.BlockMD.Overlap
                                    .Value = old.SoloMode.BlockMD.Value
                                    .LegendBlockModeWord = oldMDRData.TotalData.ViewStyle.MapLegend.MarkMD.BlockMode_Text
                                End With
                                With .MarkSizeMD
                                    With .LineShape
                                        .Color = New colorARGB(255, ColorTranslator.FromWin32(old.SoloMode.CircleMD.Mark.Tile.Line.BasicLine.SolidLine.Color).ToArgb)
                                        .LineEdge = clsVB6File.convertLineEdgeProperty(old.SoloMode.CircleMD.Mark.Line.Edge_Connect_Pattern)
                                        .LineWidth = old.SoloMode.CircleMD.Mark.WordFont.Body.Size
                                    End With
                                    .Mark = clsVB6File.convertMarkProperty(old.SoloMode.CircleMD.Mark)
                                    .MaxValue = old.SoloMode.CircleMD.MaxValue
                                    .MaxValueMode = old.SoloMode.CircleMD.MaxValueMode
                                    .Value = old.SoloMode.CircleMD.Value.Clone
                                End With
                                With .MarkTurnMD
                                    .DegreeLap = old.SoloMode.TurnMD.DegreeLap
                                    .Dirction = old.SoloMode.TurnMD.Dirction
                                    .Mark = clsVB6File.convertMarkProperty(old.SoloMode.TurnMD.Mark)
                                End With
                                With .MarkBarMD
                                    .InnerTile = clsBase.PaintTile(New colorARGB(Color.Gray))
                                    .FrameLinePat = clsBase.Line
                                    .ScaleLineInterval = old.SoloMode.BlockMD.Value
                                    .MaxHeight = 10
                                    .MaxValueMode = clsAttrData.enmMarkSizeValueMode.inDataItem.inDataItem
                                    .MaxValue = old.DTA.Max
                                    .scaleLinePat = clsBase.Line
                                    .scaleLinePat.BasicLine.SolidLine.Color = clsBase.ColorWhite
                                    .Width = 2
                                    .ThreeD = True
                                End With

                                With .StringMD
                                    .Font = clsBase.Font
                                    .Font.Body.Size = 3
                                    .maxWidth = 10
                                    .WordTurnF = True
                                End With
                            End With
                            Dim n As Integer = newData.LayerData(i).atrObject.ObjectNum
                            .Value = clsVB6File.Get_Data_Cell_Array(j, i, oldMDRData)
                        End With
                    Next
                End With
                With .LayerModeViewSettings
                    With .PointLineShape
                        .LineWidth = oldMDRData.Layer(i).PLMark.WordFont.Body.Size
                        .LineEdge = convertLineEdgeProperty(oldMDRData.Layer(i).PLMark.Line.Edge_Connect_Pattern)
                        .PointMark = convertMarkProperty(oldMDRData.Layer(i).PLMark)
                    End With
                    With .GraphMode
                        Dim old As clsOldMDRFile.Layer_Graph_Trip_Label_Mode_Info_v1275 = oldMDRData.Layer(i).LayerMode.Graph
                        .Count = old.NumOfDataSet
                        .SelectedIndex = old.DataSet
                        ReDim .DataSet(.Count - 1)
                        For j As Integer = 0 To .Count - 1
                            Dim oldGra As clsOldMDRFile.Graph_Data_v1275 = oldMDRData.GraphMode_DataSet(old.Stac + j)
                            With .DataSet(j)
                                Select Case oldGra.MultiMode
                                    Case 0
                                        If oldGra.En_Obi.Shape = 0 Then
                                            .GraphMode = enmGraphMode.PieGraph
                                        Else
                                            .GraphMode = enmGraphMode.StackedBarGraph
                                        End If
                                    Case 1
                                        If oldGra.Oresen_Bou.Shape = 0 Then
                                            .GraphMode = enmGraphMode.LineGraph
                                        Else
                                            .GraphMode = enmGraphMode.BarGraph
                                        End If
                                End Select
                                .title = oldGra.title
                                With .En_Obi
                                    .BoaderLine = clsVB6File.convertLineProperty(oldGra.En_Obi.BoaderLine)
                                    .EnSize = oldGra.En_Obi.EnSize
                                    .EnSizeMode = oldGra.En_Obi.EnSizeMode
                                    .MaxValue = oldGra.En_Obi.MaxValue
                                    .MaxValueMode = oldGra.En_Obi.MaxValueMode
                                    .RMAX = oldGra.En_Obi.RMAX
                                    .RMIN = oldGra.En_Obi.RMIN
                                    .StackedBarDirection = oldGra.En_Obi.TateYoko
                                    .AspectRatio = oldGra.En_Obi.Tanpen
                                    .Value1 = oldGra.En_Obi.Value(0)
                                    .Value2 = oldGra.En_Obi.Value(1)
                                    .Value3 = oldGra.En_Obi.Value(2)
                                End With
                                With .Oresen_Bou
                                    .Size = oldGra.Oresen_Bou.EnSize
                                    .Line = clsVB6File.convertLineProperty(oldGra.Oresen_Bou.Line)
                                    .AspectRatio = oldGra.Oresen_Bou.Tanpen
                                    .BorderLine = clsVB6File.convertLineProperty(oldGra.Oresen_Bou.WakuLine)
                                    .BackgroundTile = clsVB6File.convertTileProperty(oldGra.Oresen_Bou.WakuTile)
                                    .YMax = oldGra.Oresen_Bou.YMax
                                    .Ymin = oldGra.Oresen_Bou.Ymin
                                    .Ystep = oldGra.Oresen_Bou.Ystep
                                End With
                                ReDim .Data(11)
                                .Count = 0
                                For k As Integer = 0 To 11
                                    If oldGra.DatN(k) <> 0 Then
                                        .Data(.Count).DataNumner = oldGra.DatN(k) - 1
                                        .Data(.Count).Tile = clsVB6File.convertTileProperty(oldGra.Tile(k))
                                        .Count += 1
                                    End If
                                Next
                                ReDim Preserve .Data(Math.Max(.Count - 1, 0))
                            End With
                        Next
                    End With
                    With .LabelMode
                        Dim old As clsOldMDRFile.Layer_Graph_Trip_Label_Mode_Info_v1275 = oldMDRData.Layer(i).LayerMode.Label
                        .Count = old.NumOfDataSet
                        .SelectedIndex = old.DataSet
                        ReDim .DataSet(.Count - 1)
                        For j As Integer = 0 To .Count - 1
                            Dim oldLbl As clsOldMDRFile.Label_Data_v1275 = oldMDRData.LabelMode_DataSet(old.Stac + j)
                            With .DataSet(j)
                                .DataName_Print_Flag = oldLbl.DataName_Print_Falg
                                .DataValue_Font = clsVB6File.convertFontProperty(oldLbl.DataValue_Font)
                                convertFontFringe(oldLbl.FontFringe, .DataValue_Font)
                                .DataValue_Print_Flag = oldLbl.DataValue_Print_Falg
                                .DataValue_TurnFlag = oldLbl.DataValue_TurnFlag
                                .DataValue_Unit_Flag = oldLbl.DataValue_Unit_Flag
                                .Dummy_Object_Flag = oldLbl.Dummy_Object_Flag
                                .Dummy_Object_Font = clsVB6File.convertFontProperty(oldLbl.Dummy_Object_Font)
                                convertFontFringe(oldLbl.FontFringe, .Dummy_Object_Font)
                                .Dummy_Object_Group_Flag = oldLbl.Dummy_Object_Group_Flag
                                .Dummy_Object_Group_Font = clsVB6File.convertFontProperty(oldLbl.Dummy_Object_Group_Font)
                                convertFontFringe(oldLbl.FontFringe, .Dummy_Object_Group_Font)
                                .Dummy_Object_Group_Name1priority = (oldLbl.Dummy_Object_Group_Name1_or_2 = 1)
                                .Location_Mark = clsVB6File.convertMarkProperty(oldLbl.Location_Mark)
                                .Location_Mark_Flag = oldLbl.Location_Mark_Flag
                                .ObjectName_Font = clsVB6File.convertFontProperty(oldLbl.ObjectName_Font)
                                convertFontFringe(oldLbl.FontFringe, .ObjectName_Font)
                                .ObjectName_Print_Flag = oldLbl.ObjectName_Print_Falg
                                .ObjectName_Turn_Flag = oldLbl.ObjectName_Turn_Falg
                                .SelectedIndexOfDataItem = 0
                                .title = oldLbl.title
                                .BorderDataTile = clsVB6File.convertTileProperty(oldLbl.WakuDataTile)
                                .BorderLine = clsVB6File.convertLineProperty(oldLbl.WakuLine)
                                .BorderObjectTile = clsVB6File.convertTileProperty(oldLbl.WakuObjectTile)
                                .Width = oldLbl.Width
                                If oldLbl.Print_Data = "" Then
                                    .CountOfDataItem = 0
                                Else
                                    Dim L_Data_S() As String = Split(oldLbl.Print_Data, vbTab)
                                    .CountOfDataItem = L_Data_S.Length
                                    ReDim .DataItem(.CountOfDataItem - 1)
                                    For k As Integer = 0 To .CountOfDataItem - 1
                                        .DataItem(k) = Val(L_Data_S(k))
                                    Next
                                End If
                            End With

                        Next
                    End With
                    With .TripMode
                        Dim old As clsOldMDRFile.Layer_Graph_Trip_Label_Mode_Info_v1275 = oldMDRData.Layer(i).LayerMode.Trip
                        .Count = old.NumOfDataSet
                        .SelectedIndex = old.DataSet
                        ReDim .DataSet(.Count - 1)
                        For j As Integer = 0 To .Count - 1
                            Dim oldTrip As clsOldMDRFile.Trip_Data_v1275 = oldMDRData.TripMode_DataSet(old.Stac + j)
                            With .DataSet(j)
                                .Definition_Layer_Data = oldTrip.Definition_Layer_Data
                                .Definition_Layer_Data_Mode = oldTrip.Definition_Layer_Data_Mode
                                .EndTime = Get_YMD_from_Series(oldTrip.EndTime)
                                .Mode = oldTrip.Mode
                                .Move_Data = oldTrip.Move_Data
                                .Move_Data_Mode = oldTrip.Move_Data_Mode
                                .StartTime = Get_YMD_from_Series(oldTrip.StartTime)
                                .Stay_Data = oldTrip.Stay_Data
                                .Stay_Data_Mode = oldTrip.Stay_Data_Mode
                                .title = oldTrip.title
                            End With
                        Next
                    End With
                End With
            End With
        Next

        Dim TripDefLay As Integer = newData.Get_Trip_Definition_Layer_Number
        If TripDefLay <> -1 Then
            Dim triDefiName As clsSortingSearch = newData.Get_TripSubjectSoringClass()
            For i As Integer = 0 To oldMDRData.TotalData.StacSize.TripModeStacNum - 1
                Dim oldTrip As clsOldMDRFile.Trip_Data_v1275 = oldMDRData.TripMode_DataSet(i)
                If oldTrip.Print_Subject <> "" Then
                    Dim SpSubject() As String = Split(oldTrip.Print_Subject, vbTab)
                    Dim f As Boolean = oldTrip.Print_Or_nonPrint
                    If f = False Then
                        For j As Integer = 0 To SpSubject.Length - 1
                            Dim n As Integer = triDefiName.SearchData_One(SpSubject(j))
                            If n <> -1 Then
                                newData.LayerData(TripDefLay).atrObject.atrObjectData(n).Visible = False
                            End If
                        Next
                    Else
                        ObjectErrorMessage += "移動主体の表示設定に反映されていない部分があります。" + vbCrLf
                    End If
                End If
            Next
        End If

        With newData
            Dim Mp As clsMapData = .SetMapFile("")
            If Check_LineKind_Change(Mp, oldMDRData.O_Lpnum, oldMDRData.O_LP) = False Then
                ObjectErrorMessage += "地図ファイルの線種が変更になっています。" + vbCrLf
            End If
        End With
    End Sub
    ''' <summary>
    ''' MDR内の線種と地図ファイル内の線種の対応
    ''' </summary>
    ''' <param name="MapData"></param>
    ''' <param name="O_Lpnum"></param>
    ''' <param name="O_LP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Check_LineKind_Change(ByRef MapData As clsMapData, ByVal O_Lpnum As Integer, ByRef O_LP() As clsOldMapFile.LineKind_Data_v11) As Boolean

        Dim f2 As Boolean = True
        For i As Integer = 0 To O_Lpnum - 1
            With O_LP(i)
                Dim f As Boolean = False
                For j As Integer = 0 To MapData.Map.LpNum - 1
                    If .Name = MapData.LineKind(j).Name And .NumofOjectGroup = MapData.LineKind(j).NumofObjectGroup Then
                        MapData.LineKind(j).Mesh = .Mesh
                        MapData.LineKind(j).NumofObjectGroup = .NumofOjectGroup
                        If .NumofOjectGroup = 1 Then
                            MapData.LineKind(j).ObjGroup(0).GroupNumber = 0
                            MapData.LineKind(j).ObjGroup(0).Pattern = convertLineProperty(.Pat(0))
                            MapData.LineKind(j).ObjGroup(0).UseOnly = False
                        Else
                            For k As Integer = 0 To .NumofOjectGroup - 1
                                MapData.LineKind(j).ObjGroup(k).GroupNumber = .ObjGroup(k).GroupNumber
                                MapData.LineKind(j).ObjGroup(k).Pattern = convertLineProperty(.Pat(k))
                                MapData.LineKind(j).ObjGroup(k).UseOnly = .ObjGroup(k).UseOnly
                            Next
                        End If
                        f = True
                        Exit For
                    End If
                Next
                If f = False Then
                    f2 = False
                End If
            End With
        Next

        Return f2

    End Function
    ''' <summary>
    ''' 西暦１年１月１日を０とした連続時間変数から年月日時間を逆算する'使用するのは移動データの場合
    ''' </summary>
    ''' <param name="Num"></param>
    ''' <param name="years"></param>
    ''' <param name="months"></param>
    ''' <param name="dates"></param>
    ''' <param name="hours"></param>
    ''' <param name="minute"></param>
    ''' <remarks></remarks>
    Private Shared Function Get_YMD_from_Series(ByVal Num As Double) As DateTime


        Dim Y As Integer
        Dim n As Integer
        Dim i As Integer = 0
        Dim n2 As Integer = 0
        Do
            n = 365
            i += 1
            If (i Mod 4) = 0 And i <> 0 Then
                If (i Mod 100) = 0 Then
                    If (i Mod 400) = 0 Then
                        n = 366
                    End If
                Else
                    n = 366
                End If
            End If
            n2 += n
        Loop While n2 <= Num
        Dim years As Integer = i
        Dim num2 As Integer = Int(Num - (n2 - n))
        Dim T As Double = Num - (n2 - n) - num2
        Dim months As Integer, dates As Integer
        Get_YMD_From_TimeData(num2 + 1 + years * 10000, Y, months, dates)
        Dim mi As Double = T * 1440
        Dim hours As Integer = mi \ 60
        Dim minutes As Integer = Int(mi Mod 60)
        Return New DateTime(years, months, dates, hours, minutes, 0)
    End Function
    Private Shared Sub Get_YMD_From_TimeData(ByVal n As Integer, ByRef Y As Integer, ByRef m As Integer, ByRef D As Integer)

        '時間変数から年月日に戻す
        If n = -1 Then
            Y = -1 : m = 0 : D = 0
        Else
            Dim Days_per_one_Month() As Integer = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31, 365}
            Y = n \ 10000
            Check_Leap_Year(Y, Days_per_one_Month)
            Dim DD As Integer = Int(n Mod 10000)
            Dim i As Integer = 1
            Dim d2 As Integer = 0
            Do
                d2 += Days_per_one_Month(i)
                i += 1
            Loop While d2 < DD
            m = i - 1
            D = DD - (d2 - Days_per_one_Month(i - 1))
        End If
    End Sub
    Private Shared Function Check_Leap_Year(ByVal Y As Integer, ByRef Days_per_one_Month() As Integer) As Boolean
        '指定した西暦が閏年の場合はtrueを返す
        '閏年の場合は２月を29日に、そうでない場合は28日に設定

        '閏年であるかは以下の方法で確認できます｡
        '1調べる年が 4 で割り切れる場合は手順 2 へ、そうでない場合は手順 5 へ進む。
        '2その年が 100 で割り切れる場合は手順 3 へ、そうでない場合は手順 4 へ進む。
        '3その年が 400 で割り切れる場合は手順 4 へ、そうでない場合は手順 5 へ進む。
        '4その年は閏年になります (この年は 366 日です)。
        '5その年は閏年ではありません (この年は 365 日です)。

        Days_per_one_Month(2) = 28
        Days_per_one_Month(13) = 365
        If (Y Mod 4) = 0 Then
            If (Y Mod 100) = 0 Then
                If (Y Mod 400) = 0 Then
                    Check_Leap_Year = True
                    Days_per_one_Month(2) = 29
                    Days_per_one_Month(13) = 366
                Else
                    Check_Leap_Year = False
                End If
            Else
                Check_Leap_Year = True
                Days_per_one_Month(2) = 29
                Days_per_one_Month(13) = 366
            End If
        Else
            Check_Leap_Year = False
        End If

    End Function
    ''' <summary>
    ''' ax ayのタブ区切り座標から、座標列の数を求め、XY().XYに代入する
    ''' </summary>
    ''' <param name="ax"></param>
    ''' <param name="ay"></param>
    ''' <param name="XY"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Get_SingleXY_From_StringXY(ByVal ax As String, ByVal ay As String) As PointF()

        Dim Xst() As String = Split(ax, vbTab)
        Dim Yst() As String = Split(ay, vbTab)
        Dim XY As PointF()
        Dim n As Integer = Xst.Length
        If n > 0 Then
            ReDim XY(n - 1)
            For i As Integer = 0 To n - 1
                XY(i).X = Val(Xst(i))
                XY(i).Y = Val(Yst(i))
            Next
        End If
        Return XY
    End Function
End Class
