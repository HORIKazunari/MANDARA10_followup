Imports System.Runtime.Serialization

''' <summary>
''' 画面上に固定または地図領域に固定
''' </summary>
''' <remarks></remarks>
Public Enum enmBasePosition
    ''' <summary>
    ''' Accessory_Base_Set_Screen_Flag=false飾り等のサイズを地図領域に比例
    ''' </summary>
    ''' <remarks></remarks>
    Map = 0
    ''' <summary>
    ''' Accessory_Base_Set_Screen_Flag=true飾り等のサイズを地図領域でなくpictureboxの大きさに比例させる場合
    ''' </summary>
    ''' <remarks></remarks>
    Screen = 1
End Enum
Public Enum enmScaleUnit
    centimeter = 0
    meter = 1
    kilometer = 2
    inch = 3
    feet = 4
    yard = 5
    mile = 6
    syaku = 7
    ken = 8
    ri = 9
    kairi = 10
End Enum
Public Enum enmMoveDirection
    NextPos = 1
    PreviousPos = -1
End Enum
''' <summary>
''' 階級区分の分割方法
''' </summary>
''' <remarks></remarks>
Public Enum enmDivisionMethod
    Free = 0
    Quantile = 1
    AreaQuantile = 2
    StandardDeviation = 3
    EqualInterval = 4
End Enum
Public Enum enmKenCodeObjectstructure
    MapObj = 0   '地図ファイル中のオブジェクトの場合
    SyntheticObj = 1 '時系列集計による合成オブジェクトの場合
End Enum
''' <summary>
''' 記号モードなど最大サイズの値
''' </summary>
''' <remarks></remarks>
Public Enum enmMarkMaxValueType
    SelectedDataMax = 0
    UserSettingValue = 1
End Enum
''' <summary>
''' 円グラフ、帯グラフの最大サイズ
''' </summary>
''' <remarks></remarks>
Public Enum enmGraphMaxSize
    Fixed = 0
    Changeable = 1
End Enum
''' <summary>
''' 帯グラフの方向
''' </summary>
''' <remarks></remarks>
Public Enum enmStackedBarChart_Direction
    Vertical = 0
    Horizontal = 1
End Enum
''' <summary>
''' 折れ線・棒グラフの最大最小値
''' </summary>
''' <remarks></remarks>
Public Enum enmBarLineMaxMinMode
    Auto = 0
    Manual = 1
End Enum
''' <summary>
''' 単独表示モードの列挙型
''' </summary>
''' <remarks></remarks>
Public Enum enmSoloMode_Number
    noMode = -1
    ClassPaintMode = 0
    MarkSizeMode = 1
    MarkBlockMode = 2
    ContourMode = 3
    ClassHatchMode = 4
    ClassMarkMode = 5
    ClassODMode = 6
    MarkTurnMode = 7
    MarkBarMode = 8
    StringMode = 9
End Enum
''' <summary>
''' 全体の表示モード
''' </summary>
''' <remarks></remarks>
Public Enum enmTotalMode_Number
    ''' <summary>
    ''' データ表示モード
    ''' </summary>
    ''' <remarks></remarks>
    DataViewMode = 0
    ''' <summary>
    ''' 重ね合わせモード
    ''' </summary>
    ''' <remarks></remarks>
    OverLayMode = 1
    ''' <summary>
    ''' 連続表示モード
    ''' </summary>
    ''' <remarks></remarks>
    SeriesMode = 2
End Enum
''' <summary>
''' データ表示モード
''' </summary>
''' <remarks></remarks>
Public Enum enmLayerMode_Number
    ''' <summary>
    ''' データ無し
    ''' </summary>
    ''' <remarks></remarks>
    NoData = -1
    ''' <summary>
    ''' 単独表示モード
    ''' </summary>
    ''' <remarks></remarks>
    SoloMode = 0
    ''' <summary>
    ''' グラフ表示モード
    ''' </summary>
    ''' <remarks></remarks>
    GraphMode = 1
    ''' <summary>
    ''' ラベル表示モード
    ''' </summary>
    ''' <remarks></remarks>
    LabelMode = 2
    ''' <summary>
    ''' 移動表示モード
    ''' </summary>
    ''' <remarks></remarks>
    TripMode = 3
End Enum
Public Enum enmGraphMode
    PieGraph = 0
    StackedBarGraph = 1
    LineGraph = 2
    BarGraph = 3
End Enum
''' <summary>
''' 階級区分モードの凡例
''' </summary>
''' <remarks></remarks>
Public Enum enmClassMode_Meshod
    ''' <summary>
    ''' 通常表示（くっついている）
    ''' </summary>
    ''' <remarks></remarks>
    Noral = 0
    ''' <summary>
    ''' 分離表示（隙間がある）
    ''' </summary>
    ''' <remarks></remarks>
    Separated = 1
End Enum

''' <summary>
''' 階級区分凡例分離表示のさいの表記法
''' </summary>
''' <remarks></remarks>
Public Enum enmSeparateClassWords
    Japanese = 0
    English = 1
End Enum

Public Enum enmMultiEnGraphPattern
    multiCircle = 0
    oneCircle = 1
End Enum
''' <summary>
''' データセット数と選択データセットの組み合わせプロパティ
''' </summary>
''' <remarks></remarks>
Public Structure strNumOfDataSet_and_SelectedDataSet  '
    Public SelectedDataSet As Integer
    Public NumOfDataSet As Integer
End Structure
''' <summary>
''' 読み込んでいるデータ
''' </summary>
''' <remarks></remarks>
Public Enum enmDataSource
    NoData = -1
    Clipboard = 0
    CSV = 1
    DataEdit = 2
    MDR = 3
    MDRM = 4
    MDRZ = 5
    MDRMZ = 6
    Viwer = 7
    Shapefile = 8
End Enum
Public Class clsAttrData
    Public Enum enmTripDrawType
        PaintMode = 0
        OdMode = 1
    End Enum
    Public Enum enmTripMode
        Blanc = 0
        TripDefinitionLayerDataMode = 1
        TripLayerDataMode = 2
    End Enum
    Public Enum enmPrint_Enable
        Printable = 0
        Printable_with_Error = 2
        UnPrintable = 1
    End Enum


    ''' <summary>
    ''' ペイントモードの色設定方法の列挙型
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enmPaintColorSettingModeInfo
        twoColor = 0
        threeeColor = 1
        SoloColor = 2
        multiColor = 3
    End Enum
    ''' <summary>
    ''' レイヤの種類の列挙型
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enmLayerType
        Normal = 0
        Trip_Definition = 1
        Trip = 2
        Mesh = 3
        DefPoint = 4
    End Enum
    ''' <summary>
    ''' 属性データの取得方法の列挙型
    ''' </summary>
    ''' <remarks></remarks>
    Private Enum enmDataGetMethod
        Clipboard = 0
        CSV = 1
        MDRZ = 2
        Shapefile = 3
        AttDataEditor = 4
    End Enum
    ''' <summary>
    ''' データ保存の際に線種を保存するために使用
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strSaveLinePat_Info
        Public MapNum As Integer
        Public MapFileName() As String
        Public LpatNumByMapfile() As Integer
        Public Lpat As List(Of clsMapData.LineKind_Data)
    End Structure
    ''' <summary>
    ''' データ項目データ取得で、欠損値以外の値を取得する際に使用
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strObjLocation_and_Data_info
        Public ObjLocation As Integer
        Public DataValue As String
    End Structure
    Public Structure strTileMapViewInfo
        Public Visible As Boolean
        Public ViewData As strTileMapViewDataInfo
        Public DrawTiming As enmDrawTiming
    End Structure
    Private Structure strLayerReadingInfo
        Public Name As String
        Public MapFile As String
        Public Time As strYMD
        Public Type As enmLayerType
        Public MeshType As enmMesh_Number
        ''' <summary>
        ''' ポイント、メッシュ、移動データの測地系指定
        ''' </summary>
        ''' <remarks></remarks>
        Public ReferenceSystem As enmZahyo_System_Info
        Public Shape As enmShape
        Public TTL() As String
        Public UNT() As String
        Public DTMis() As Boolean
        Public Note() As String
        Public ObjectDataStac As List(Of String())
        Public Dummy_Temp As List(Of String())
        Public Dummy_OBKTemp As List(Of String())
        Public Comment_Temp As String
        ''' <summary>
        ''' レイヤの初期化。タイプはNormal形状はNotDefinition
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub init()
            If TTL Is Nothing = False Then
                Erase TTL
            End If
            If UNT Is Nothing = False Then
                Erase UNT
            End If
            If DTMis Is Nothing = False Then
                Erase DTMis
            End If
            If Note Is Nothing = False Then
                Erase Note
            End If
            Dummy_Temp = New List(Of String())
            Dummy_OBKTemp = New List(Of String())
            ObjectDataStac = New List(Of String())
            Comment_Temp = ""
            MapFile = ""
            Name = ""
            Time = clsTime.GetNullYMD
            Type = enmLayerType.Normal
            Shape = enmShape.NotDeffinition
            MeshType = enmMesh_Number.mhNonMesh
        End Sub
    End Structure

    Public Structure strURL_Data
        Public Name As String
        Public Address As String
    End Structure
    Public Structure strObject_Data_Info 'オブジェクト名とコード、シンボル位置（属性データ）
        Public MpObjCode As Integer
        Public Name As String
        Public Objectstructure As enmKenCodeObjectstructure
        Public HyperLinkNum As Integer
        Public HyperLink() As strURL_Data
        Public CenterPoint As PointF
        Public Symbol As PointF
        Public Label As PointF
        Public defPoint As strLatLon
        Public MeshRect As RectangleF
        Public MeshPoint() As PointF
        Public Visible As Boolean
        Public Function Clone() As strObject_Data_Info
            Dim newObj As strObject_Data_Info
            With newObj
                .MpObjCode = Me.MpObjCode
                .Name = Me.Name
                .Objectstructure = Me.Objectstructure
                .HyperLinkNum = Me.HyperLinkNum
                If Me.HyperLink Is Nothing = False Then
                    .HyperLink = Me.HyperLink.Clone
                End If
                .CenterPoint = Me.CenterPoint
                .Symbol = Me.Symbol
                .Label = Me.Label
                .defPoint = Me.defPoint
                .MeshRect = Me.MeshRect
                If Me.MeshPoint Is Nothing = False Then
                    .MeshPoint = Me.MeshPoint.Clone
                End If
                .Visible = Me.Visible
            End With
            Return newObj
        End Function

    End Structure
    Public Structure strObject_Info
        Public ObjectNum As Integer
        Public NumOfSyntheticObj As Integer
        ''' <summary>
        ''' 移動データレイヤの場合はatrObjectData作成しない
        ''' </summary>
        ''' <remarks></remarks>
        Public atrObjectData() As strObject_Data_Info
        Public MPSyntheticObj() As strSynthetic_Object_Data
        ''' <summary>
        ''' 移動データレイヤの場合のみTripObjData配列作成
        ''' </summary>
        ''' <remarks></remarks>
        Public TripObjData() As strTripObjData_Info
    End Structure

    Public Structure strStatisticInfo
        Public Max As Double
        Public Min As Double
        Public Ave As Double
        Public STD As Double
        Public Sum As Double
        Public sa As Double
        ''' <summary>
        ''' 整数の桁数
        ''' </summary>
        ''' <remarks></remarks>
        Public BeforeDecimalNum As Integer
        ''' <summary>
        ''' 小数点以下の桁数
        ''' </summary>
        ''' <remarks></remarks>
        Public AfterDecimalNum As Integer
    End Structure


    Public Structure strSynthetic_ObjectName_and_Code '合成オブジェクト名とコード（属性データ）
        Public code As Integer
        Public Name As String
        Public Draw_F As Boolean
    End Structure

    Public Structure strSynthetic_Object_Data   '合成オブジェクト（属性・地図データ）
        Public Kind As Integer
        Public NumOfObject As Integer
        Public Name As String
        Public CenterP As PointF
        Public SETime As Start_End_Time_data
        Public Shape As enmShape
        Public Circumscribed_Rectangle As RectangleF
        Public Objects() As strSynthetic_ObjectName_and_Code
    End Structure

    Public Enum enmLatLonLine_Order
        Back = 0
        Front = 1
    End Enum

    Public Enum enmInner_Data_Info_Mode
        ClassPaint = 0
        ClassHatch = 1
    End Enum

    Public Structure strInner_Data_Info  '記号の数，大きさ，階級記号，線モードの内部色設定
        Public Flag As Boolean
        Public Data As Integer
        Public Mode As enmInner_Data_Info_Mode
    End Structure

    Public Structure strClassPaint_Data  'ペイントモード設定値（属性データ）
        Public color1 As colorARGB
        Public color2 As colorARGB
        Public color3 As colorARGB
        Public Color_Mode As enmPaintColorSettingModeInfo
    End Structure


    Public Enum enmMarkSizeValueMode
        inDataItem = 0
        UserDefinition = 1
    End Enum
    ''' <summary>
    ''' 記号モード共通
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strMarkCommon_Data
        Public Inner_Data As strInner_Data_Info
        Public MinusTile As Tile_Property
        Public MinusLineColor As colorARGB
        Public LegendMinusWord As String
        Public LegendPlusWord As String
    End Structure
    Public Structure strMarkSizeModeLineShapeData
        Public LineWidth As Single
        Public LineEdge As LineEdge_Connect_Pattern_Data_Info
        Public Color As colorARGB
    End Structure
    Public Structure strMarkSize_Data  '記号の大きさモード設定（属性データ）
        Public MaxValueMode As enmMarkSizeValueMode
        Public MaxValue As Double
        Public Value() As Double '4
        Public Mark As Mark_Property
        Public LineShape As strMarkSizeModeLineShapeData
    End Structure
    Public Enum MarkBarShape
        bar = 0
        triangle = 1
    End Enum

    ''' <summary>
    ''' 記号の棒モード
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strMarkBar_Data
        Public BarShape As MarkBarShape
        Public Width As Single
        Public MaxHeight As Single
        Public MaxValueMode As enmMarkSizeValueMode
        Public MaxValue As Double
        Public InnerTile As Tile_Property
        Public FrameLinePat As Line_Property
        Public ThreeD As Boolean
        Public ScaleLineInterval As Double
        Public ScaleLineVisible As Boolean
        Public scaleLinePat As Line_Property
    End Structure
    ''' <summary>
    ''' 文字モード
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strString_Data
        Public Font As Font_Property
        Public maxWidth As Single
        Public WordTurnF As Boolean
    End Structure

    Public Enum enmMarkBlockArrange
        Block = 0
        Vertical = 1
        Horizontal = 2
        PolygonRandom = 3
    End Enum
    Public Structure strMarkBlock_Data  '記号の数モード設定（属性データ）
        Public Value As Double
        Public ArrangeB As enmMarkBlockArrange
        Public HasuVisible As Boolean
        Public Mark As Mark_Property
        Public Overlap As Integer
        Public LegendBlockModeWord As String
    End Structure
    Public Enum enmMarkTurnDirection
        AntiClockwise = 0
        Clockwise = 1
    End Enum
    Public Structure strMarkTurnMode_Data  '記号の回転モード
        Public Dirction As enmMarkTurnDirection '0:反時計回り　1:時計回り
        Public Mark As Mark_Property
        Public DegreeLap As Double '一周の値
    End Structure


    Public Structure strContour_Data_Regular_interval  '等値線モード設定（属性データ）
        Public bottom As Double
        Public Interval As Double
        Public top As Double
        Public Line_Pat As Line_Property
        Public SP_Bottom As Double
        Public SP_interval As Double
        Public SP_Top As Double
        Public SP_Line_Pat As Line_Property
        Public EX_Value_Flag As Boolean
        Public EX_Value As Double
        Public EX_Line_Pat As Line_Property
    End Structure
    Public Structure strContour_Data_Irregular_interval
        Public Value As Double
        Public Line_Pat As Line_Property
    End Structure
    Public Enum enmContourIntervalMode
        RegularInterval = 0
        SeparateSettings = 1
        ClassPaint = 2
        ClassHatch = 3
    End Enum
    Public Structure strContour_Data
        Public Interval_Mode As enmContourIntervalMode
        Public Draw_in_Polygon_F As Boolean
        Public Spline_flag As Boolean
        Public Detailed As Integer
        Public Regular As strContour_Data_Regular_interval
        Public IrregularNum As Integer
        Public Irregular() As strContour_Data_Irregular_interval
    End Structure
    Public Structure strContour_Line_property
        Public Flag As Boolean
        Public Layernum As Integer
        Public DataNum As Integer
        Public Value As Double
        Public NumOfPoint As Integer
        Public PointStac As Integer
        Public Circumscribed_Rectangle As RectangleF
    End Structure


    Public Structure strClassODMode_data  '線引きモード（属性データ）
        Public o_Layer As Integer
        Public O_object As Integer
        Public Dummy_ObjectFlag As Boolean
        Public Arrow As Arrow_Data
    End Structure


    Public Structure strClass_Div_data  '階級区分データ（属性データ）
        Public Value As Double
        Public Cat_Name As String
        Public PaintColor As colorARGB
        Public TilePat As Tile_Property
        Public ClassMark As Mark_Property
        Public ODLinePat As Line_Property
    End Structure


    ''' <summary>
    ''' データ項目ごとの単独表示モードのプロパティを保持する構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strSoloModeViewSettings_Data
        Public Div_Num As Integer
        Public Div_Method As enmDivisionMethod
        Public ClassPaintMD As strClassPaint_Data
        Public MarkCommon As strMarkCommon_Data
        Public MarkSizeMD As strMarkSize_Data
        Public MarkBlockMD As strMarkBlock_Data
        Public MarkBarMD As strMarkBar_Data
        Public StringMD As strString_Data
        Public ContourMD As strContour_Data
        Public ClassODMD As strClassODMode_data
        Public ClassMarkMD As strInner_Data_Info
        Public MarkTurnMD As strMarkTurnMode_Data
        Public Class_Div() As strClass_Div_data
    End Structure

    ''' <summary>
    ''' データ項目の情報
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strData_info
        Public Title As String
        Public Unit As String
        Public MissingF As Boolean
        Public Note As String
        Public DataType As enmAttDataType
        ''' <summary>
        ''' 欠損値のデータ数
        ''' </summary>
        ''' <remarks></remarks>
        Public MissingValueNum As Integer
        ''' <summary>
        ''' 欠損値を除いたデータ項目中のデータ数
        ''' </summary>
        ''' <remarks></remarks>
        Public EnableValueNum As Integer
        Public Statistics As strStatisticInfo
        ''' <summary>
        '''  表示モード
        ''' </summary>
        ''' <remarks></remarks>
        Public ModeData As enmSoloMode_Number
        Public SoloModeViewSettings As strSoloModeViewSettings_Data  '単独表示モードごとのプロパティ
        Public Value() As String
        ''' <summary>
        ''' クローン
        ''' </summary>
        ''' <param name="NoValueFlag">Value配列はコピーしない場合true</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Clone(ByVal NoValueFlag As Boolean) As strData_info
            Dim DT As strData_info
            With DT
                .Title = Me.Title
                .Unit = Me.Unit
                .MissingF = Me.MissingF
                .Note = Me.Note
                .DataType = Me.DataType
                .MissingValueNum = Me.MissingValueNum
                .EnableValueNum = Me.EnableValueNum
                .Statistics = Me.Statistics
                .ModeData = Me.ModeData
                With .SoloModeViewSettings
                    .Div_Num = Me.SoloModeViewSettings.Div_Num
                    .Div_Method = Me.SoloModeViewSettings.Div_Method
                    ReDim .Class_Div(Me.SoloModeViewSettings.Class_Div.Length - 1)
                    For i As Integer = 0 To Me.SoloModeViewSettings.Class_Div.Length - 1
                        .Class_Div(i) = Me.SoloModeViewSettings.Class_Div(i)
                    Next
                    .ClassMarkMD = Me.SoloModeViewSettings.ClassMarkMD
                    .ClassODMD = Me.SoloModeViewSettings.ClassODMD
                    .ClassPaintMD = Me.SoloModeViewSettings.ClassPaintMD
                    With .ContourMD
                        Dim meCon As strContour_Data = Me.SoloModeViewSettings.ContourMD
                        .Detailed = meCon.Detailed
                        .Draw_in_Polygon_F = meCon.Draw_in_Polygon_F
                        .Interval_Mode = meCon.Interval_Mode
                        If meCon.Irregular Is Nothing = False Then
                            .Irregular = meCon.Irregular.Clone
                        End If
                        .IrregularNum = meCon.IrregularNum
                        .Regular = meCon.Regular
                        .Spline_flag = meCon.Spline_flag
                    End With
                    .MarkCommon = Me.SoloModeViewSettings.MarkCommon
                    .MarkBarMD = Me.SoloModeViewSettings.MarkBarMD
                    .MarkBlockMD = Me.SoloModeViewSettings.MarkBlockMD
                    With .MarkSizeMD
                        Dim meMs As strMarkSize_Data = Me.SoloModeViewSettings.MarkSizeMD
                        .LineShape = meMs.LineShape
                        .Mark = meMs.Mark
                        .MaxValue = meMs.MaxValue
                        .MaxValueMode = meMs.MaxValueMode
                        If meMs.Value Is Nothing = False Then
                            .Value = meMs.Value.Clone
                        End If
                    End With
                    .MarkTurnMD = Me.SoloModeViewSettings.MarkTurnMD
                    .StringMD = Me.SoloModeViewSettings.StringMD
                End With
                If NoValueFlag = False Then
                    .Value = Me.Value.Clone
                End If
            End With
            Return DT
        End Function
    End Structure
    Public Structure stratrData_Info
        ''' <summary>
        ''' データ項目数
        ''' </summary>
        ''' <remarks></remarks>
        Public Count As Integer
        ''' <summary>
        ''' 選択中のデータ項目番号
        ''' </summary>
        ''' <remarks></remarks>
        Public SelectedIndex As Integer
        Public Data() As strData_info

    End Structure
    ''' <summary>
    ''' 移動データの個別オブジェクト
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strTripObjData_Info
        Public TripPersonName As String
        Public TripPersonCode As Integer
        ''' <summary>
        ''' レイヤのTripTypeがObjectSetの場合
        ''' </summary>
        ''' <remarks></remarks>
        Public PositionObjName As String
        Public PositionObjCode As Integer
        ''' <summary>
        ''' レイヤのTripTypeがLatLonの場合
        ''' </summary>
        ''' <remarks></remarks>
        Public LatLon As strLatLon
        Public ArrivalTime As DateTime
        Public DepartureTime As DateTime

    End Structure

    Public Structure strGraph_Data_En  '複数表示（円）（属性データ）
        Public EnSizeMode As enmGraphMaxSize
        Public EnSize As Single
        Public Value1 As Double
        Public Value2 As Double
        Public Value3 As Double
        Public BoaderLine As Line_Property
        Public AspectRatio As Single
        Public StackedBarDirection As enmStackedBarChart_Direction
        Public RMAX As Double
        Public RMIN As Double
        Public MaxValueMode As enmMarkMaxValueType
        Public MaxValue As Double
    End Structure

    Public Structure strGraph_Data_Oresen  '複数表示（折れ線）（属性データ）
        Public Size As Single
        Public Line As Line_Property
        Public AspectRatio As Single
        Public YmaxMinMode As enmBarLineMaxMinMode
        Public YMax As Double
        Public Ymin As Double
        Public Ystep As Double
        Public BackgroundTile As Tile_Property
        Public BorderLine As Line_Property
    End Structure
    Public Structure GraphModeDataItem
        Dim DataNumner As Integer
        Dim Tile As Tile_Property
    End Structure
    ''' <summary>
    ''' グラフモードの個別データセットの構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strGraph_Data
        Public title As String
        Public GraphMode As enmGraphMode
        Public Count As Integer
        Public Data() As GraphModeDataItem
        Public En_Obi As strGraph_Data_En
        Public Oresen_Bou As strGraph_Data_Oresen
        Public Function Clone() As strGraph_Data
            Dim RData As strGraph_Data
            With RData
                .GraphMode = Me.GraphMode
                .title = Me.title
                .Count = Me.Count
                If 0 < .Count Then
                    ReDim .Data(.Count - 1)
                    For i As Integer = 0 To .Count - 1
                        .Data(i) = Me.Data(i)
                    Next
                End If
                .En_Obi = Me.En_Obi
                .Oresen_Bou = Me.Oresen_Bou
            End With
            Return RData
        End Function
        ''' <summary>
        ''' グラフモードの個別アイテム初期設定
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub initData()
            Me.title = ""
            Me.Count = 0
            Erase Me.Data
            Me.GraphMode = enmGraphMode.PieGraph
            With Me.En_Obi
                .EnSize = 10
                .EnSizeMode = enmGraphMaxSize.Changeable
                .BoaderLine = clsBase.Line
                .AspectRatio = 0.5
                .StackedBarDirection = 0
                .MaxValueMode = enmMarkMaxValueType.SelectedDataMax
            End With

            With Me.Oresen_Bou
                .Size = 10
                .Line = clsBase.Line
                .AspectRatio = 1.5
                .YmaxMinMode = enmBarLineMaxMinMode.Auto
                .BackgroundTile = clsBase.Tile
                .BackgroundTile.BGColFlag = True
                .BackgroundTile.Line.BasicLine.SolidLine.Color = New colorARGB(Color.White)
                .BorderLine = clsBase.Line
            End With
        End Sub


    End Structure
    ''' <summary>
    ''' グラフモード全体の構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strGraphMode_DataSetting_Info
        Public Count As Integer
        Public SelectedIndex As Integer
        Public DataSet() As strGraph_Data
        Public Function Clone()
            Dim RData As strGraphMode_DataSetting_Info
            With RData
                .Count = Me.Count
                .SelectedIndex = Me.SelectedIndex
                If 0 < .Count Then
                    ReDim .DataSet(.Count - 1)
                    For i As Integer = 0 To .Count - 1
                        .DataSet(i) = Me.DataSet(i)
                    Next
                End If
            End With
            Return RData
        End Function
        Public Sub initDataSet()
            ReDim Me.DataSet(0)
            Me.Count = 0
            Me.SelectedIndex = 0
            Me.AddDataSet()
        End Sub
        Public Sub AddDataSet()
            Dim n As Integer = Me.Count
            ReDim Preserve Me.DataSet(n)
            Me.DataSet(n).initData()
            Me.Count += 1
        End Sub
        Public Sub RemoveDataSet(ByVal Index As Integer)
            Dim n As Integer = Me.Count
            If n - 1 < Index Then
                MsgBox(Index.ToString + "はデータ数を超えています。", MsgBoxStyle.Exclamation)
                Return
            Else
                If Index < Me.SelectedIndex Then
                    Me.SelectedIndex -= 1
                End If
                For i As Integer = Index To n - 2
                    Me.DataSet(i) = Me.DataSet(i + 1).Clone
                Next
                ReDim Preserve Me.DataSet(n - 2)
            End If
            Me.Count -= 1
        End Sub
    End Structure
    ''' <summary>
    ''' 移動データモード全体の構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strTripMode_Data_Info
        Public Count As Integer
        Public SelectedIndex As Integer
        Public DataSet() As strTrip_Data
        Public Function Clone()
            Dim RData As strTripMode_Data_Info
            With RData
                .Count = Me.Count
                .SelectedIndex = Me.SelectedIndex
                If 0 < .Count Then
                    ReDim .DataSet(.Count - 1)
                    For i As Integer = 0 To .Count - 1
                        .DataSet(i) = Me.DataSet(i)
                    Next
                End If
            End With
            Return RData
        End Function
        Public Sub initDataSet(ByVal StartTime As DateTime, ByVal EndTime As DateTime)
            ReDim Me.DataSet(0)
            Me.Count = 0
            Me.SelectedIndex = 0
            Me.AddDataSet(StartTime, EndTime)
        End Sub
        Public Sub AddDataSet(ByVal StartTime As DateTime, ByVal EndTime As DateTime)
            Dim n As Integer = Me.Count
            ReDim Preserve Me.DataSet(n)
            Me.DataSet(n).initData(StartTime, EndTime)
            Me.Count += 1
        End Sub
        Public Sub RemoveDataSet(ByVal Index As Integer)
            Dim n As Integer = Me.Count
            If n - 1 < Index Then
                MsgBox(Index.ToString + "はデータ数を超えています。", MsgBoxStyle.Exclamation)
                Return
            Else
                If Index < Me.SelectedIndex Then
                    Me.SelectedIndex -= 1
                End If
                For i As Integer = Index To n - 2
                    Me.DataSet(i) = Me.DataSet(i + 1)
                Next
                ReDim Preserve Me.DataSet(n - 2)
            End If
            Me.Count -= 1
        End Sub
    End Structure
    ''' <summary>
    ''' 移動データモードの個別アイテム初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strTrip_Data  '
        Public title As String
        Public Mode As enmTripMode
        Public StartTime As DateTime
        Public EndTime As DateTime
        Public Definition_Layer_Data As Integer
        Public Definition_Layer_Data_Mode As enmTripDrawType
        Public Stay_Data As Integer
        Public Move_Data As Integer
        Public Stay_Data_Mode As enmTripDrawType
        Public Move_Data_Mode As enmTripDrawType
        ''' <summary>
        ''' ZData=0で時間が高さ、それ以降はデータ項目
        ''' </summary>
        ''' <remarks></remarks>
        Public ZData As Integer
        ''' <summary>
        ''' true=Print
        ''' </summary>
        ''' <remarks></remarks>

        ''' <summary>
        ''' 移動データモードの個別アイテム初期設定
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub initData(ByVal StartTime As DateTime, ByVal EndTime As DateTime)
            With Me
                title = ""
                .Mode = enmTripMode.Blanc
                .StartTime = StartTime
                .EndTime = EndTime
                .Definition_Layer_Data = 0
                .Definition_Layer_Data_Mode = enmTripDrawType.PaintMode
                .Move_Data = 1
                .Move_Data_Mode = enmTripDrawType.PaintMode
                .Stay_Data = 1
                .Stay_Data_Mode = enmTripDrawType.PaintMode
                .ZData = 0
            End With
        End Sub

    End Structure
    ''' <summary>
    ''' ラベルモードの個別データセットの構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strLabel_Data '
        Public title As String
        Public Location_Mark_Flag As Boolean
        Public Location_Mark As Mark_Property
        Public Width As Single
        Public SelectedIndexOfDataItem As Integer
        Public CountOfDataItem As Integer
        Public DataItem() As Integer
        Public DataValue_Font As Font_Property
        Public DataValue_Unit_Flag As Boolean
        Public DataValue_TurnFlag As Boolean
        Public DataValue_Print_Flag As Boolean
        Public DataName_Print_Flag As Boolean
        Public ObjectName_Font As Font_Property
        Public ObjectName_Print_Flag As Boolean
        Public ObjectName_Turn_Flag As Boolean
        Public Dummy_Object_Font As Font_Property
        Public Dummy_Object_Flag As Boolean
        Public Dummy_Object_Group_Font As Font_Property
        Public Dummy_Object_Group_Name1priority As Boolean
        Public Dummy_Object_Group_Flag As Boolean
        Public BorderObjectTile As Tile_Property
        Public BorderDataTile As Tile_Property
        Public BorderLine As Line_Property
        Public Function Clone() As strLabel_Data
            Dim RData As strLabel_Data
            With RData
                .title = Me.title
                .Location_Mark_Flag = Me.Location_Mark_Flag
                .Location_Mark = Me.Location_Mark
                .Width = Me.Width
                .SelectedIndexOfDataItem = Me.SelectedIndexOfDataItem
                .CountOfDataItem = Me.CountOfDataItem
                If Me.DataItem Is Nothing = False Then
                    .DataItem = Me.DataItem.Clone
                End If
                .DataValue_Font = Me.DataValue_Font
                .DataValue_Unit_Flag = Me.DataValue_Unit_Flag
                .DataValue_TurnFlag = Me.DataValue_TurnFlag
                .DataValue_Print_Flag = Me.DataValue_Print_Flag
                .DataName_Print_Flag = Me.DataName_Print_Flag
                .ObjectName_Font = Me.ObjectName_Font
                .ObjectName_Print_Flag = Me.ObjectName_Print_Flag
                .ObjectName_Turn_Flag = Me.ObjectName_Turn_Flag
                .Dummy_Object_Font = Me.Dummy_Object_Font
                .Dummy_Object_Flag = Me.Dummy_Object_Flag
                .Dummy_Object_Group_Font = Me.Dummy_Object_Group_Font
                .Dummy_Object_Group_Name1priority = Me.Dummy_Object_Group_Name1priority
                .Dummy_Object_Group_Flag = Me.Dummy_Object_Group_Flag
                .BorderObjectTile = Me.BorderObjectTile
                .BorderDataTile = Me.BorderDataTile
                .BorderLine = Me.BorderLine
            End With
            Return RData
        End Function
        ''' <summary>
        ''' ラベルモードの個別データの初期化
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub initData()

            Me.CountOfDataItem = 0
            Me.SelectedIndexOfDataItem = -1

            With Me
                .title = ""
                .Location_Mark = clsBase.Mark
                .Location_Mark.WordFont.Body.Size = 1
                .Location_Mark_Flag = False
                .Width = 10

                .DataValue_Font = clsBase.Font
                .DataValue_Font.Body.Size = 2
                .DataValue_Font.Body.FringeF = True
                .DataValue_TurnFlag = True
                .DataValue_Unit_Flag = True
                .DataValue_Print_Flag = True
                .DataName_Print_Flag = True

                .ObjectName_Font = clsBase.Font
                .ObjectName_Font.Body.Size = 2
                .ObjectName_Font.Body.FringeF = True
                .ObjectName_Turn_Flag = True
                .ObjectName_Print_Flag = True

                .Dummy_Object_Flag = False
                .Dummy_Object_Font = .ObjectName_Font
                .Dummy_Object_Group_Flag = False
                .Dummy_Object_Group_Font = .ObjectName_Font
                .Dummy_Object_Group_Name1priority = True
                .BorderLine = clsBase.BlancLine
                .BorderDataTile = clsBase.BlancTile
                .BorderObjectTile = clsBase.BlancTile
                Erase .DataItem
            End With
        End Sub
        Public Sub AddData(ByVal DataItemIndex As Integer)
            Dim n As Integer = Me.CountOfDataItem
            ReDim Preserve Me.DataItem(n)
            Me.DataItem(n) = DataItemIndex
            Me.CountOfDataItem += 1
        End Sub
        Public Sub RemoveData(ByVal Index As Integer)
            Dim n As Integer = Me.CountOfDataItem
            If n - 1 < Index Then
                MsgBox(Index.ToString + "はデータ数を超えています。", MsgBoxStyle.Exclamation)
                Return
            Else
                If Index < Me.SelectedIndexOfDataItem Then
                    Me.SelectedIndexOfDataItem -= 1
                End If
                For i As Integer = Index To n - 2
                    Me.DataItem(i) = Me.DataItem(i + 1)
                Next
                ReDim Preserve Me.DataItem(n - 2)
            End If
            Me.CountOfDataItem -= 1
        End Sub
        Public Sub MoveData(ByVal dir As enmMoveDirection)
            If Me.SelectedIndexOfDataItem = -1 Then
                MsgBox("SelectedIndexが指定されていません。")
            End If
            Dim tmpDT As Object
            Select Case dir
                Case enmMoveDirection.NextPos
                    If Me.SelectedIndexOfDataItem = Me.CountOfDataItem - 1 Then
                        Return
                    End If
                    tmpDT = Me.DataItem(SelectedIndexOfDataItem + 1)
                    Me.DataItem(SelectedIndexOfDataItem + 1) = Me.DataItem(SelectedIndexOfDataItem)
                    Me.DataItem(SelectedIndexOfDataItem) = tmpDT
                    Me.SelectedIndexOfDataItem += 1
                Case enmMoveDirection.PreviousPos
                    If Me.SelectedIndexOfDataItem = 0 Then
                        Return
                    End If
                    tmpDT = Me.DataItem(SelectedIndexOfDataItem - 1)
                    Me.DataItem(SelectedIndexOfDataItem - 1) = Me.DataItem(Me.SelectedIndexOfDataItem)
                    Me.DataItem(SelectedIndexOfDataItem) = tmpDT
                    Me.SelectedIndexOfDataItem -= 1
            End Select
        End Sub
    End Structure

    ''' <summary>
    ''' ラベルモード全体の構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strLabelMode_Data_info
        Public Count As Integer
        Public SelectedIndex As Integer
        Public DataSet() As strLabel_Data
        Public Function Clone()
            Dim RData As strLabelMode_Data_info
            With RData
                .Count = Me.Count
                .SelectedIndex = Me.SelectedIndex
                If 0 < .Count Then
                    ReDim .DataSet(.Count - 1)
                    For i As Integer = 0 To .Count - 1
                        .DataSet(i) = Me.DataSet(i)
                    Next
                End If
            End With
            Return RData
        End Function
        ''' <summary>
        ''' ラベルモードの初期化
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub initDataSet()
            Me.Count = 0
            Me.SelectedIndex = 0
            Erase Me.DataSet
            Me.AddDataSet()
        End Sub
        Public Sub AddDataSet()
            Dim n As Integer = Me.Count
            ReDim Preserve Me.DataSet(n)
            Me.DataSet(n).initData()
            Me.Count += 1
        End Sub
        Public Sub RemoveDataSet(ByVal Index As Integer)
            Dim n As Integer = Me.Count
            If n - 1 < Index Then
                MsgBox(Index.ToString + "はデータ数を超えています。", MsgBoxStyle.Exclamation)
                Return
            Else
                If Index < Me.SelectedIndex Then
                    Me.SelectedIndex -= 1
                End If
                For i As Integer = Index To n - 2
                    Me.DataSet(i) = Me.DataSet(i + 1).Clone
                Next
                ReDim Preserve Me.DataSet(n - 2)
            End If
            Me.Count -= 1
        End Sub
    End Structure
    Public Structure strLayerPointLineShape_Data
        Public LineWidth As Single
        Public LineEdge As LineEdge_Connect_Pattern_Data_Info
        Public PointMark As Mark_Property

    End Structure
    Public Structure strLayerModeViewSetting_Data
        Public TripMode As strTripMode_Data_Info
        Public LabelMode As strLabelMode_Data_info
        Public GraphMode As strGraphMode_DataSetting_Info
        ''' <summary>
        ''' 点オブジェクトのペイントモードの記号・線オブジェクトのペイントモードの線幅等設定
        ''' </summary>
        ''' <remarks></remarks>
        Public PointLineShape As strLayerPointLineShape_Data
        ''' <summary>
        ''' ダミーオブジェクトをクリッピング領域に設定
        ''' </summary>
        ''' <remarks></remarks>
        Public PolygonDummy_ClipSet_F As Boolean


    End Structure
    Public Structure strDummyObjectName_and_Code 'オブジェクト名とコード（属性データ）
        Public code As Integer
        Public Name As String
    End Structure
    ''' <summary>
    ''' ダミーオブジェクトの構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strDummyObjectInfo
        Public Count As Integer
        Public DummyObj() As strDummyObjectName_and_Code

        Public Sub initDummy()
            Erase DummyObj
            Me.Count = 0
        End Sub
        Public Sub AddDummy(ByVal Code As Integer, ByVal Name As String)
            Dim n As Integer = Me.Count
            ReDim Preserve DummyObj(n)
            DummyObj(n).Name = Name
            DummyObj(n).code = Code
            Me.Count += 1
        End Sub
        Public Sub MoveDummy(ByVal Index As Integer, ByVal dir As enmMoveDirection)
            Dim tmpDT As strDummyObjectName_and_Code
            Select Case dir
                Case enmMoveDirection.NextPos
                    If Index >= Me.Count - 1 Then
                        Return
                    End If
                    tmpDT = Me.DummyObj(Index + 1)
                    Me.DummyObj(Index + 1) = Me.DummyObj(Index)
                    Me.DummyObj(Index) = tmpDT
                Case enmMoveDirection.PreviousPos
                    If Index = 0 Then
                        Return
                    End If
                    tmpDT = Me.DummyObj(Index - 1)
                    Me.DummyObj(Index - 1) = Me.DummyObj(Index)
                    Me.DummyObj(Index) = tmpDT
            End Select
        End Sub
        Public Sub RemoveDummy(ByVal Index As Integer)
            Dim n As Integer = Me.Count
            If n - 1 < Index Then
                Return
            Else
                For i As Integer = Index To n - 2
                    Me.DummyObj(i) = Me.DummyObj(i + 1)
                Next
                ReDim Preserve Me.DummyObj(n - 2)
            End If
            Me.Count -= 1
        End Sub
    End Structure


    ''' <summary>
    ''' ダミーオブジェクトグループの構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strDummyObjectGroupInfo

        Public Count As Integer
        Public DummyObjG() As Integer

        Public Sub initDummyObjG()
            Erase DummyObjG
            Me.Count = 0
        End Sub
        ''' <summary>
        ''' 指定のオブジェクトグループがダミーオブジェクトに含まれているか
        ''' </summary>
        ''' <param name="ObjGIndex"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Check_DummyObjGExists(ByVal ObjGIndex As Integer) As Boolean
            If Count > 0 Then
                For i As Integer = 0 To DummyObjG.Count - 1
                    If DummyObjG(i) = ObjGIndex Then
                        Return True
                    End If
                Next
            End If
            Return False
        End Function
        Public Sub AddDummyObjG(ByVal ObjGIndex As Integer)
            Dim n As Integer = Me.Count
            ReDim Preserve DummyObjG(n)
            DummyObjG(n) = ObjGIndex

            Me.Count += 1
        End Sub
        Public Sub MoveDummyObjG(ByVal Index As Integer, ByVal dir As enmMoveDirection)
            Dim tmpDT As Integer
            Select Case dir
                Case enmMoveDirection.NextPos
                    If Index >= Me.Count - 1 Then
                        Return
                    End If
                    tmpDT = Me.DummyObjG(Index + 1)
                    Me.DummyObjG(Index + 1) = Me.DummyObjG(Index)
                    Me.DummyObjG(Index) = tmpDT
                Case enmMoveDirection.PreviousPos
                    If Index = 0 Then
                        Return
                    End If
                    tmpDT = Me.DummyObjG(Index - 1)
                    Me.DummyObjG(Index - 1) = Me.DummyObjG(Index)
                    Me.DummyObjG(Index) = tmpDT
            End Select
        End Sub
        Public Sub RemoveDummyObjG(ByVal Index As Integer)
            Dim n As Integer = Me.Count
            If n - 1 < Index Then
                Return
            Else
                For i As Integer = Index To n - 2
                    Me.DummyObjG(i) = Me.DummyObjG(i + 1)
                Next
                ReDim Preserve Me.DummyObjG(n - 2)
            End If
            Me.Count -= 1
        End Sub
    End Structure
    Public Structure ODBezier_Data
        ''' <summary>
        ''' レイヤ内のオブジェクトの位置
        ''' </summary>
        ''' <remarks></remarks>
        Public ObjectPos As Integer
        ''' <summary>
        ''' データ項目
        ''' </summary>
        ''' <remarks></remarks>
        Public Data As Integer
        ''' <summary>
        ''' コントロールポイント
        ''' </summary>
        ''' <remarks></remarks>
        Public Point As PointF
    End Structure
    Public Structure TripTimeSpan_Info
        Public StartTime As DateTime
        Public EndTime As DateTime
    End Structure
    Public Enum enmTripPositionType
        ObjectSet = 0
        LatLon = 1
    End Enum
    Public Structure strLayerDataInfo

        Public Name As String
        Public MapFileName As String
        Private MapFileDataA As clsMapData
        Private MapFileObjectNameSearch As clsObjectNameSearch
        Public Shape As enmShape
        Public Type As enmLayerType
        Public MeshType As enmMesh_Number
        Public ReferenceSystem As enmZahyo_System_Info
        Public Time As strYMD
        Public Comment As String
        Public TripTimeSpan As TripTimeSpan_Info
        Public TripType As enmTripPositionType
        ''' <summary>
        ''' オブジェクトの情報
        ''' </summary>
        ''' <remarks></remarks>
        Public atrObject As strObject_Info
        ''' <summary>
        ''' データ項目の情報
        ''' </summary>
        ''' <remarks></remarks>
        Public atrData As stratrData_Info
        Public Dummy As strDummyObjectInfo
        Public DummyGroup As strDummyObjectGroupInfo
        Public Print_Mode_Layer As enmLayerMode_Number '0:単独 1:グラフ 2:ラベル 3:移動
        ''' <summary>
        ''' グラフ表示、ラベル表示、移動表示、点線オブジェクトのペイントモードの記号
        ''' </summary>
        ''' <remarks></remarks>
        Public LayerModeViewSettings As strLayerModeViewSetting_Data

        Public PrtSpatialIndex As clsSpatialIndexSearch
        Private ObjectGRelatedLine As Integer()
        Public ODBezier_DataStac As List(Of ODBezier_Data)
        ''' <summary>
        ''' オブジェクトグループ連動型線種のデータにアクセス
        ''' </summary>
        ''' <param name="Lcode"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ObjectGroupRelatedLine(ByVal Lcode As Integer) As Integer
            Get
                Return ObjectGRelatedLine(Lcode)
            End Get
            Set(value As Integer)
                ObjectGRelatedLine(Lcode) = value
            End Set
        End Property
        ''' <summary>
        ''' 地図ファイルデータの取得
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function MapFileData() As clsMapData

            Return MapFileDataA

        End Function
        ''' <summary>
        ''' 地図ファイルデータの設定
        ''' </summary>
        ''' <param name="MapData"></param>
        ''' <remarks></remarks>
        Public Sub Set_MapFileData(ByRef MapData As clsMapData)

            MapFileDataA = MapData
        End Sub
        ''' <summary>
        ''' 地図ファイルのオブジェクト名検索クラスをセットする
        ''' </summary>
        ''' <param name="ObjectNameSearch"></param>
        ''' <remarks></remarks>
        Public Sub SetMapFileObjectNameSearchClass(ByRef ObjectNameSearch As clsObjectNameSearch)
            Me.MapFileObjectNameSearch = ObjectNameSearch
        End Sub
        ''' <summary>
        ''' 地図ファイル中のオブジェクト名からオブジェクト番号を返す。見つからなかった場合は-1を返す
        ''' </summary>
        ''' <param name="ObjName"></param>
        ''' <param name="Time"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ObjectNameSearch(ByVal ObjName As String, ByVal Time As strYMD) As Integer
            Return Me.MapFileObjectNameSearch.Get_KenToCode(ObjName, Time)
        End Function
        Public Sub initLayerData_from_mdrz()
            If Me.MapFileData.Map.ALIN > 0 Then
                ReDim ObjectGRelatedLine(Me.MapFileData.Map.ALIN - 1)
            End If
        End Sub
        Public Sub initLayerData()
            If Me.MapFileData Is Nothing = False Then
                If Me.MapFileData.Map.ALIN > 0 Then
                    ReDim ObjectGRelatedLine(Me.MapFileData.Map.ALIN - 1)
                End If
            End If
            Select Case Me.Type
                Case enmLayerType.Normal, enmLayerType.Mesh, enmLayerType.DefPoint
                    Me.Print_Mode_Layer = enmLayerMode_Number.SoloMode
                    With Me.LayerModeViewSettings
                        .LabelMode.initDataSet()
                        .GraphMode.initDataSet()
                        .PolygonDummy_ClipSet_F = False
                        With .PointLineShape
                            .PointMark = clsBase.Mark
                            .PointMark.WordFont.Body.Size = 3
                            .LineWidth = 1
                            With .LineEdge
                                .Edge_Pattern = enmEdge_Pattern.Round
                                .Join_Pattern = enmJoinPattern.Round
                                .MiterLimitValue = 10
                            End With
                        End With
                    End With
                    ODBezier_DataStac = New List(Of ODBezier_Data)
                Case enmLayerType.Trip
                    Me.Print_Mode_Layer = enmLayerMode_Number.TripMode
                    With Me.LayerModeViewSettings.PointLineShape
                        .PointMark = clsBase.Mark
                        .PointMark.WordFont.Body.Size = 2
                    End With
                Case enmLayerType.Trip_Definition
                    Me.Print_Mode_Layer = enmLayerMode_Number.SoloMode
            End Select
        End Sub

        ''' <summary>
        ''' 線モードのベジェ曲線用の参照地点を返す。該当しない場合はfalseを返す
        ''' </summary>
        ''' <param name="ObjPos"></param>
        ''' <param name="DataNum"></param>
        ''' <param name="RefPoint">参照地点(戻り値)</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Get_OD_Bezier_RefPoint(ByVal ObjPos As Integer, ByVal DataNum As Integer, ByRef RefPoint As PointF) As Boolean
            For i As Integer = 0 To ODBezier_DataStac.Count - 1
                With ODBezier_DataStac(i)
                    If .Data = DataNum And .ObjectPos = ObjPos Then
                        RefPoint = .Point
                        Return True
                    End If
                End With
            Next
            Return False
        End Function
        ''' <summary>
        ''' 線モードのベジェ曲線用の参照地点を削除
        ''' </summary>
        ''' <param name="ObjPos"></param>
        ''' <param name="DataNum"></param>
        ''' <remarks></remarks>
        Public Sub Remove_OD_Bezier(ByVal ObjPos As Integer, ByVal DataNum As Integer)
            For i As Integer = 0 To ODBezier_DataStac.Count - 1
                With ODBezier_DataStac(i)
                    If .Data = DataNum And .ObjectPos = ObjPos Then
                        ODBezier_DataStac.RemoveAt(i)
                        Return
                    End If
                End With
            Next
        End Sub
        ''' <summary>
        ''' 線モードのベジェ曲線用の参照地点を追加。存在する場合は変更
        ''' </summary>
        ''' <param name="ObjPos"></param>
        ''' <param name="DataNum"></param>
        ''' <param name="RefPoint"></param>
        ''' <remarks></remarks>
        Public Sub Add_OD_Bezier(ByVal ObjPos As Integer, ByVal DataNum As Integer, ByVal RefPoint As PointF)
            For i As Integer = 0 To ODBezier_DataStac.Count - 1
                Dim d As ODBezier_Data = ODBezier_DataStac(i)
                With d
                    If .Data = DataNum And .ObjectPos = ObjPos Then
                        .Point = RefPoint
                        ODBezier_DataStac(i) = d
                        Return
                    End If
                End With
            Next
            Dim newD As ODBezier_Data
            With newD
                .Data = DataNum
                .ObjectPos = ObjPos
                .Point = RefPoint
            End With
            ODBezier_DataStac.Add(newD)
        End Sub
        ''' <summary>
        ''' 通常のデータの最初の位置を返す。存在しない場合は-1を返す
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getFirstNormalDataItem() As Integer
            With Me.atrData
                For i As Integer = 0 To .Count - 1
                    If .Data(i).DataType = enmAttDataType.Normal Then
                        Return i
                    End If
                Next
            End With
            Return -1
        End Function
    End Structure

    ''' <summary>
    ''' レイヤデータ
    ''' </summary>
    ''' <remarks></remarks>
    Public LayerData() As strLayerDataInfo
    '----------------------------------------------------------------------------------------------------------------------------

    ''' <summary>
    ''' '欠損値の設定（属性データ）
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strMissing_set
        Public Print_Flag As Boolean
        Public Text As String
        Public PaintTile As Tile_Property
        Public HatchTile As Tile_Property
        Public Mark As Mark_Property
        Public BlockMark As Mark_Property
        Public ClassMark As Mark_Property
        Public TurnMark As Mark_Property
        Public MarkBar As Mark_Property
        Public Label As String
        Public LineShape As Line_Property
    End Structure
    ''' <summary>
    ''' '代表点と記号表示位置を結ぶデータ（属性データ）
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strSymbol_Lien_Data
        Public Visible As Boolean
        Public Line As Line_Property
    End Structure
    ''' <summary>
    ''' 移動モードで使う各種ラインの設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strTrip_Line_Data
        Public Stay_Line As Line_Property
        Public Trip_Line As Line_Property
        Public Height As Single
        Public Frame_Print As Boolean
        Public Frame_Line As Line_Property
        Public TimeLegend_Position As Integer
        Public TimeLegend_Font As Font_Property
        Public Start_End_Print As Boolean
        Public StartPoint_Mark As Mark_Property
        Public EndPoint_Mark As Mark_Property
        Public ZeroPointF As Boolean
        Public ZeroLineF As Boolean
        Public ZeroPoint_Mark As Mark_Property
        Public ZeroLine As Line_Property
        Public Overlap_Mode As Boolean
        Public VerticalLineF As Boolean
        Public VerticalLine As Line_Property
    End Structure

    Public Structure strOverLay_Legend_Title_Info
        Public Print_f As Boolean
        Public MaxWidth As Single
    End Structure

    Public Structure strLatLonLine_Print_Info
        Public Visible As Boolean
        Public Order As enmLatLonLine_Order
        Public Lat_Interval As Single
        Public Lon_Interval As Single
        Public LPat As Line_Property
        Public OuterPat As Line_Property
        Public Equator As Line_Property
    End Structure

    Public Structure strSouByou_Info
        Public Auto As Boolean
        Public AutoDegree As Integer '(1-5の値)
        Public ThinningPrint_F As Boolean
        Public PointInterval As Single
        Public LoopAreaF As Boolean
        Public LoopSize As Single
        Public Spline_F As Boolean
    End Structure



    Public Structure strClassBoundaryLine_Info
        Public Visible As Boolean
        Public LPat As Line_Property
    End Structure



    Public Structure strBasic_Data '属性データ基本値（属性データ）
        Public Lay_Maxn As Integer
        ''' <summary>
        ''' 選択中のレイヤ番号
        ''' </summary>
        ''' <remarks></remarks>
        Public SelectedLayer As Integer
        Public Print_Mode_Total As enmTotalMode_Number '0:データ表示 1:重ね合わせ　2:連続
        Public Comment As String
        Public MDRFileVersion As Single
        Public FileName As String
        Public FullPath As String
        Public DataSourceType As enmDataSource
    End Structure


    Public Structure strScreen_Back_data  '画面の背景設定（属性データ）
        Public MapAreaFrameLine As Line_Property
        Public ScreenFrameLine As Line_Property
        Public ScreenAreaBack As Tile_Property
        Public MapAreaBack As Tile_Property
        Public ObjectInner As Tile_Property
    End Structure
    Public Enum enmPointOnjectDrawOrder
        ObjectOrder = 0
        LowerToUpperCategory = 1
        UpperToLowerCategory = 2
    End Enum
    Public Enum enmScaleBarPattern
        Thin = 0
        Bold = 1
        Slim = 2
    End Enum
    Public Structure strScale_Attri  'スケール設定（属性データ）
        Public Visible As Boolean
        Public Position As PointF
        Public Font As Font_Property
        Public BarPattern As enmScaleBarPattern
        Public BarAuto As Boolean
        Public BarDistance As Single
        Public BarKugiriNum As Integer
        Public Back As BackGround_Box_Property
        Public Unit As enmScaleUnit
    End Structure
    Public Structure strNote_Attri  '注釈設定（属性データ）
        Public Visible As Boolean
        Public Position As PointF
        Public MaxWidth As Single
        Public Font As Font_Property
    End Structure
    Public Structure strTitle_Attri  'タイトル設定（属性データ）
        Public Visible As Boolean
        Public Position As PointF
        Public MaxWidth As Single
        Public Font As Font_Property
    End Structure

    Public Structure strLegend_Base_Attri
        Public Visible As Boolean
        Public Legend_Num As Integer
        Public Font As Font_Property
        Public Back As BackGround_Box_Property
        Public LegendXY() As PointF
        Public Comma_f As Boolean
        Public ModeValueInScreenFlag As Boolean
    End Structure
    Public Structure strLegend_Class_Attri
        Public PaintMode_Line As Line_Property
        Public PaintMode_Method As enmClassMode_Meshod
        Public PaintMode_Width As Single
        Public ClassMarkFrame_Visible As Boolean
        Public SeparateClassWords As enmSeparateClassWords
        Public SeparateGapSize As Single
        Public ClassBoundaryLine As strClassBoundaryLine_Info
        Public FrequencyPrint As Boolean
        Public CategorySeparate_f As Boolean
    End Structure
    Public Structure strLegend_Mark_Attri
        Public CircleMD_CircleMini_F As Boolean
        Public MultiEnMode_Line As Line_Property
    End Structure
    Public Enum enmCircleMDLegendLine
        Zigzag = 0
        Straight = 1
    End Enum
    Public Structure strLegend_Line_Dummy_Attri
        Public Line_Visible As Boolean
        Public Line_Visible_Number_STR As String '線種ごとに表示するかどうか、１は表示０は非表示で連続文字列
        Public Line_Pattern As enmCircleMDLegendLine
        Public Dummy_Point_Visible As Boolean
        Public Back As BackGround_Box_Property
    End Structure

    Public Structure strLegend_Attri  '凡例設定（属性データ）
        Public Base As strLegend_Base_Attri
        Public OverLay_Legend_Title As strOverLay_Legend_Title_Info
        Public ClassMD As strLegend_Class_Attri
        Public MarkMD As strLegend_Mark_Attri
        Public Line_DummyKind As strLegend_Line_Dummy_Attri
        Public En_Graph_Pattern As enmMultiEnGraphPattern
    End Structure
    ''' <summary>
    ''' 飾り設定グループボックス
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strAccessoryGroupBox_Info
        Public Visible As Boolean
        Public Back As BackGround_Box_Property
        Public Title As Boolean
        Public Comapss As Boolean
        Public Scale As Boolean
        Public Legend As Boolean
        Public Note As Boolean
        Public LinePattern As Boolean
        Public ObjectGroup As Boolean
    End Structure
    Public Structure strDummyObjectPointMark_Info
        Public ObjectKindName As String
        Public Mark As Mark_Property
    End Structure

    ''' <summary>
    ''' 値・オブジェクト名表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strValueShow_Info
        Public ValueVisible As Boolean
        Public ValueFont As Font_Property
        Public DecimalSepaF As Boolean
        Public DecimalNumber As Integer
        Public ObjNameVisible As Boolean
        Public ObjNameFont As Font_Property
    End Structure
    ''' <summary>
    ''' '飾りの設定を保持（属性データ）
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strViewStyle_Info
        Public ScrData As Screen_info
        Public MapScale As strScale_Attri
        Public MapTitle As strTitle_Attri
        Public DataNote As strNote_Attri
        Public AttMapCompass As clsMapData.strCompass_Attri
        Public MapLegend As strLegend_Attri
        Public FigureVisible As Boolean
        Public AccessoryGroupBox As strAccessoryGroupBox_Info
        Public Missing_Data As strMissing_set
        Public Screen_Back As strScreen_Back_data
        Public SymbolLine As strSymbol_Lien_Data
        Public Trip_Line As strTrip_Line_Data
        Public PointPaint_Order As enmPointOnjectDrawOrder
        Public Dummy_Size_Flag As Boolean
        Public MeshLine As Line_Property
        Public TileLicenceFont As Font_Property
        Public ObjectLimitationF As Boolean
        Public InVisibleObjectBoundaryF As Boolean
        ''' <summary>
        ''' Key:地図ファイル、Value:点オブジェクトのダミー表示時記号
        ''' </summary>
        ''' <remarks></remarks>
        Public DummyObjectPointMark As Dictionary(Of String, strDummyObjectPointMark_Info())
        Public MapPrint_Flag As Boolean

        Public LatLonLine_Print As strLatLonLine_Print_Info
        Public SouByou As strSouByou_Info
        Public TileMapView As strTileMapViewInfo

        Public Screen_Setting As List(Of strScreen_Setting_Data_Info)
        Public ValueShow As strValueShow_Info
        Public Zahyo As clsMapData.Zahyo_info

        ''' <summary>
        ''' 表示設定の初期化
        ''' </summary>
        ''' <param name="TileMapDefault"></param>
        ''' <remarks></remarks>
        Public Sub initViewStyle(ByVal TileMapDefault As strTileMapData_Info)
            '欠損値
            With Me.Missing_Data
                .Print_Flag = True
                .Text = "欠損値"
                .PaintTile = clsBase.Tile
                .PaintTile.TileCode = 6
                .HatchTile = clsBase.Tile
                .HatchTile.Line.BasicLine.SolidLine.Color = clsBase.ColorWhite
                .Mark = clsBase.Mark
                .Mark.ShapeNumber = 6
                .BlockMark = clsBase.Mark
                .BlockMark.Tile.Line.BasicLine.SolidLine.Color = clsBase.ColorWhite
                .BlockMark.ShapeNumber = 6
                .ClassMark = clsBase.Mark
                .ClassMark.wordmark = "NA"
                .ClassMark.WordFont.Body.Color = New colorARGB(Color.Black)
                .ClassMark.PrintMark = 1
                .BlockMark.Tile.Line.BasicLine.SolidLine.Color = clsBase.ColorWhite
                .BlockMark.ShapeNumber = 6
                .LineShape = clsBase.DotLine
                .TurnMark = .Mark
                .MarkBar = .Mark
                .Label = "欠損値"
            End With

            With Me
                .SymbolLine.Visible = False
                .SymbolLine.Line = clsBase.Line
                .Dummy_Size_Flag = True
                With .SouByou
                    .Auto = True
                    .AutoDegree = 2
                    .LoopSize = 0
                    .PointInterval = 0
                    .Spline_F = False
                    .ThinningPrint_F = False
                    .LoopAreaF = False
                End With
                With .TileMapView
                    .Visible = False
                    .ViewData.TileMapDataSet = TileMapDefault
                    .ViewData.AlphaValue = 255
                    .ViewData.LastUserFolder = ""
                    .ViewData.LastWorldFileFolder = ""
                    .ViewData.TransparentF = False
                    .DrawTiming = enmDrawTiming.BeforeDataDraw
                End With

            End With
            With Me.ScrData
                With .Screen_Margin
                    .Left = 0.8 * 0.05 * 100
                    .Right = 20
                    .Top = 0.9 * 0.05 * 100
                    .Bottom = 10
                    .ClipF = False
                End With
                '3Dモード
                With .ThreeDMode
                    .Set3D_F = False
                    .Pitch = 65
                    .Head = 0
                    .Bank = 0
                    .Expand = 100
                End With
                .Accessory_Base = enmBasePosition.Screen
            End With


            With Me
                .MapPrint_Flag = True
                .FigureVisible = True
                With .MapLegend
                    With .Base
                        .Visible = True
                        .Comma_f = True
                        .Font = clsBase.Font
                        .Font.Body.Size = 3.5
                        .Back = clsBase.BlankBackground
                        .ModeValueInScreenFlag = False
                        With .Back
                            .Tile.Line.BasicLine.SolidLine.Color = New colorARGB(255, 200, 200, 200)
                            With .Line
                                .Edge_Connect_Pattern.Edge_Pattern = enmEdge_Pattern.Rectangle
                                .Edge_Connect_Pattern.Join_Pattern = enmJoinPattern.Miter
                            End With
                        End With
                        .Legend_Num = 1
                        ReDim .LegendXY(0)
                    End With
                    With .OverLay_Legend_Title
                        .Print_f = True
                        .MaxWidth = 30
                    End With
                    With .ClassMD
                        .PaintMode_Line = clsBase.Line
                        .PaintMode_Line.Edge_Connect_Pattern.Edge_Pattern = 1
                        .PaintMode_Line.Edge_Connect_Pattern.Join_Pattern = 2
                        .PaintMode_Method = enmClassMode_Meshod.Noral
                        .CategorySeparate_f = True
                        .PaintMode_Width = 1.2
                        .SeparateGapSize = 0.2
                        .ClassMarkFrame_Visible = False
                        .SeparateClassWords = enmSeparateClassWords.Japanese
                        .FrequencyPrint = False
                        With .ClassBoundaryLine
                            .Visible = False
                            .LPat = clsBase.BoldLine
                        End With
                    End With
                    With .MarkMD
                        .MultiEnMode_Line = clsBase.Line
                        .CircleMD_CircleMini_F = True
                    End With
                    With .Line_DummyKind
                        .Line_Visible = False
                        .Line_Visible_Number_STR = "" 'ここの設定は後で
                        .Line_Pattern = enmCircleMDLegendLine.Zigzag
                        .Back = clsBase.BlankBackground
                    End With
                    .En_Graph_Pattern = 0
                End With
                With .AccessoryGroupBox
                    .Visible = False
                    .Back = clsBase.BlankBackground
                    .Back.Tile.TileCode = enmTilePattern.Paint
                    .Back.Tile.Line.BasicLine.SolidLine.Color = New colorARGB(200, 255, 255, 255)
                    .Back.Line.BasicLine.pattern = enmLinePattern.Solid
                    .Legend = True
                    .Title = True
                    .Comapss = True
                    .Scale = True
                    .ObjectGroup = True
                    .LinePattern = True
                    .Note = True
                End With
                With .MapTitle
                    .Visible = True
                    .MaxWidth = 70
                    .Font = clsBase.Font
                    .Font.Body.Size = 5
                    .Font.Back.Tile = clsBase.BlancTile
                    .Font.Back.Tile.Line.BasicLine.SolidLine.Color = clsBase.ColorWhite
                    .Font.Back.Line = clsBase.BlancLine
                    .Font.Back.Round = 1
                    .Font.Back.Padding = 1
                End With
                With .MapScale
                    .Visible = True
                    .Font = clsBase.Font
                    .Font.Body.Size = 3.5
                    .BarAuto = True
                    .BarPattern = 0
                    .BarDistance = 0
                    .BarKugiriNum = 2
                    .Back = clsBase.BlankBackground
                    .Back.Tile.Line.BasicLine.SolidLine.Color = clsBase.ColorWhite
                    .Back.Line = clsBase.BlancLine
                    .Unit = enmScaleUnit.kilometer
                End With
                With .DataNote
                    .Visible = True
                    .MaxWidth = 20
                    .Font = clsBase.Font
                    .Font.Body.Size = 2.5
                End With
                With .LatLonLine_Print
                    '緯度経度地図データの場合は，initTotalData_andOtherで設定
                    .Visible = False
                    .Order = 0
                    .LPat = clsBase.DotLine
                    .Lat_Interval = 1
                    .Lon_Interval = 1
                    .OuterPat = clsBase.Line
                    .Equator = clsBase.Line
                End With
                With .ValueShow
                    .ObjNameVisible = False
                    .ObjNameFont = clsBase.Font
                    With .ObjNameFont
                        .Body.Size = 2
                        .Body.FringeF = True
                        .Body.FringeColor = clsBase.ColorWhite
                    End With
                    .ValueVisible = False
                    .ValueFont = clsBase.Font
                    .DecimalSepaF = False
                    .DecimalNumber = 0
                    With .ValueFont
                        .Body.Size = 2
                        .Body.FringeF = True
                        .Body.FringeColor = clsBase.ColorWhite
                    End With
                End With
                With .Trip_Line
                    .Stay_Line = clsBase.BoldLine
                    .Trip_Line = clsBase.BoldLine
                    .Height = 40
                    .Frame_Print = True
                    .Frame_Line = clsBase.Line
                    .TimeLegend_Font = clsBase.Font
                    .TimeLegend_Font.Body.Size = 2
                    .TimeLegend_Position = 1
                    .Start_End_Print = True
                    .StartPoint_Mark = clsBase.Mark
                    .EndPoint_Mark = clsBase.Mark
                    With .StartPoint_Mark
                        .WordFont.Body.Size = 0.8
                        .Line.BasicLine.SolidLine.Color = clsBase.ColorRed
                        .Tile.Line.BasicLine.SolidLine.Color = clsBase.ColorRed
                    End With
                    With .EndPoint_Mark
                        .WordFont.Body.Size = 0.8
                        .Line.BasicLine.SolidLine.Color = clsBase.ColorBlue
                        .Tile.Line.BasicLine.SolidLine.Color = clsBase.ColorBlue
                    End With
                    .ZeroLineF = False
                    .ZeroPointF = False
                    .ZeroLine = clsBase.Line
                    .ZeroLine.BasicLine.SolidLine.Color = New colorARGB(255, &HA0, &HA0, &HA0)
                    .ZeroPoint_Mark = clsBase.Mark
                    .ZeroPoint_Mark.WordFont.Body.Size = 0.3
                    .Overlap_Mode = True
                    .VerticalLineF = False
                    .VerticalLine = clsBase.Line
                    .VerticalLine.BasicLine.SolidLine.Color = New colorARGB(255, &HC0, &HC0, &HC0)
                End With
                .PointPaint_Order = enmPointOnjectDrawOrder.LowerToUpperCategory
                .MeshLine = clsBase.BlancLine
            End With

            With Me.Screen_Back
                .MapAreaFrameLine = clsBase.BlancLine
                .ScreenFrameLine = clsBase.BlancLine
                .MapAreaBack = clsBase.BlancTile
                .ScreenAreaBack = clsBase.BlancTile
                .MapAreaBack.Line.BasicLine.SolidLine.Color = New colorARGB(255, 0, 100, 200)
                .ScreenAreaBack.Line.BasicLine.SolidLine.Color = New colorARGB(255, 0, 100, 200)
                .ObjectInner = clsBase.BlancTile
                .ObjectInner.Line.BasicLine.SolidLine.Color = New colorARGB(255, 255, 255, 255)
            End With

            Me.Screen_Setting = New List(Of strScreen_Setting_Data_Info)

            TileLicenceFont = clsBase.Font
            With TileLicenceFont
                .Body.Size = 2.0
                With .Back
                    .Tile.TileCode = enmTilePattern.Paint
                    .Tile.Line.BasicLine.SolidLine.Color = New colorARGB(200, 255, 255, 255)
                End With
            End With
            Me.ObjectLimitationF = False
            Me.InVisibleObjectBoundaryF = True
        End Sub


    End Structure
    Public Enum enmCondition
        Less = 0
        LessEqual = 1
        Equal = 2
        GreaterEqual = 3
        Greater = 4
        NotEqual = 5
        Include = 6
        Exclude = 7
        Head = 8
        Foot = 9
    End Enum

    Public Structure strCondition_Limitation_Info '属性検索の条件データ
        Public Data As Integer
        Public Condition As enmCondition
        Public Val As String
    End Structure
    Public Enum enmConditionAnd_Or
        _And = 0
        _Or = 1
    End Enum
    Public Structure strCondition_Data_Info  'データセット
        Public And_OR As enmConditionAnd_Or
        Public Condition As List(Of strCondition_Limitation_Info) '（個別の条件）
    End Structure
    Public Structure strCondition_DataSet_Info ''属性検索データセット
        Public Enabled As Boolean
        Public Layer As Integer
        Public Name As String
        Public Condition_Class As List(Of strCondition_Data_Info) '（条件の段階別の条件スタック）
    End Structure



    Public Structure strScreen_Setting_Data_Info '画面設定保存用
        Public title As String
        Public frmPrint_FormSize As Rectangle
        Public ScrView As RectangleF
        Public Screen_Margin As ScreenMargin
        Public Accessory_Base As enmBasePosition
        Public MapScale As strScale_Attri
        Public MapTitle As strTitle_Attri
        Public DataNote As strNote_Attri
        Public AttMapCompass As clsMapData.strCompass_Attri
        Public MapLegend As strLegend_Attri

        Public ThreeDMode As strThreeDMode_Set
    End Structure


    Public Structure strOverLay_DataSet_Item_Info
        Public Layer As Integer
        Public DataNumber As Integer
        Public Print_Mode_Layer As enmLayerMode_Number
        Public Mode As enmSoloMode_Number
        Public Legend_Print_Flag As Boolean
        Public TileMapf As Boolean
        Public TileData As strTileMapViewDataInfo
    End Structure
    ''' <summary>
    ''' 重ね合わせモードの個別データセットに関するデータ
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strOverLay_Dataset_Info
        Public title As String
        Public SelectedIndex As Integer
        Public DataItem As List(Of strOverLay_DataSet_Item_Info)
        Public Note As String
        Public Sub initData()
            Me.SelectedIndex = -1
            Me.title = ""
            Me.DataItem = New List(Of strOverLay_DataSet_Item_Info)
            Me.Note = ""
        End Sub


    End Structure
    ''' <summary>
    ''' 重ね合わせモード全体のデータ
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strOverLayMOde_Dataset_Info
        Public SelectedIndex As Integer
        Public DataSet As List(Of strOverLay_Dataset_Info)
        ''' <summary>
        ''' 常に重ねる設定のデータセット・存在しない場合は-1
        ''' </summary>
        ''' <remarks></remarks>
        Public Always_Overlay_Index As Integer
        Public MarkModePosFixFlag As Boolean
        Public Sub initDataSet()
            Me.Always_Overlay_Index = -1
            Me.SelectedIndex = 0
            Me.MarkModePosFixFlag = False
            DataSet = New List(Of strOverLay_Dataset_Info)
            Me.AddDataSet()
        End Sub
        Public Sub AddDataSet()
            Dim d As strOverLay_Dataset_Info
            d.initData()
            Me.DataSet.Add(d)
        End Sub

    End Structure
    Structure strSeries_DataSet_Item_Info '連続表示モード
        Public Layer As Integer
        Public Data As Integer
        Public Print_Mode_Total As enmTotalMode_Number
        Public Print_Mode_Layer As enmLayerMode_Number
        Public SoloMode As enmSoloMode_Number
    End Structure
    ''' <summary>
    ''' 連続表示モードの個別データセットの構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strSeries_Dataset_Info '
        Public title As String
        Public SelectedIndex As Integer
        Public DataItem As List(Of strSeries_DataSet_Item_Info)

        Public Sub initData()
            Me.SelectedIndex = -1
            Me.title = ""
            Me.DataItem = New List(Of strSeries_DataSet_Item_Info)
        End Sub
        Public Sub AddData(ByVal LayerIndex As Integer, ByVal DataIndex As Integer, ByVal TotalDataViewMode As enmTotalMode_Number,
                           ByVal LayerDataVieMode As enmLayerMode_Number, ByVal SoloViewMode As enmSoloMode_Number)
            Dim d As strSeries_DataSet_Item_Info
            With d
                .Layer = LayerIndex
                .Data = DataIndex
                .Print_Mode_Total = TotalDataViewMode
                .Print_Mode_Layer = LayerDataVieMode
                .SoloMode = SoloViewMode
            End With
            Me.DataItem.Add(d)
        End Sub
    End Structure


    ''' <summary>
    ''' 連続表示モード全体の構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strSeriesMode_Dataset_Info
        Public SelectedIndex As Integer
        Public DataSet As List(Of strSeries_Dataset_Info)
        Public Sub initDataSet()
            Me.DataSet = New List(Of strSeries_Dataset_Info)
            Me.AddDataSet()
        End Sub
        Public Sub AddDataSet()
            Dim d As strSeries_Dataset_Info
            d.initData()
            Me.DataSet.Add(d)
        End Sub
    End Structure


    Public Structure strTotalMode_Info
        Public OverLay As strOverLayMOde_Dataset_Info
        Public Series As strSeriesMode_Dataset_Info
    End Structure

    Public Structure strFigure_data
        Public Layer As Integer
        Public Data As Integer
    End Structure

    Public Structure strFig_Word_Data
        Public Data As strFigure_data
        Public Caption As String
        Public Scattered_Mode_F As Boolean
        Public StringPos() As PointF '文字列の文字数分の座標
        Public Font As Font_Property
        Public Screen_Setf As Boolean '画面に固定フラグ
    End Structure
    Public Structure strFig_Line_Data
        Public Data As strFigure_data
        Public NumOfPoint As Short
        Public Points() As PointF
        Public Arrow As Arrow_Data
        Public FillFlag As Boolean
        Public Spline As Boolean
        Public Circumscribed_Rectangle As RectangleF
        Public Patttern As Line_Property
        Public Tile As Tile_Property
    End Structure
    Public Structure strFig_Rectangle_Data
        Public Data As strFigure_data
        Public Point0 As PointF
        Public Point1 As PointF
        Public Back As BackGround_Box_Property
    End Structure
    Public Structure strFig_Circle_data
        Public Data As strFigure_data
        Public Position As PointF
        Public XR As Single
        Public YR As Single
        Public Angle As Single
        Public Printcenter As Boolean
        Public Mark As Mark_Property
        Public LinePat As Line_Property
        Public Tile As Tile_Property
    End Structure
    Public Structure strFig_Point_Data
        Public Data As strFigure_data
        Public NumOfPoint As Short
        Public Points() As PointF
        Public Mark As Mark_Property
        Public CaptionPosition As PointF
        Public Caption_F As Boolean
        Public Caption As String
        Public Font As Font_Property
    End Structure
    Public Structure strFig_gazo_data
        Public Data As strFigure_data
        Public Position As PointF
        Public PictureNumber As Integer
        Public Size As Single
        Public LinePat As Line_Property
        Public Back As Boolean
        Public InnerCol_F As Boolean
        Public Inner_Color As colorARGB
        Public Angle As Single
        Public AlphaValue As Integer
    End Structure

    <DataContract> _
    <KnownType(GetType(strFig_Word_Data)),
    KnownType(GetType(strFig_Line_Data)),
    KnownType(GetType(strFig_Rectangle_Data)),
    KnownType(GetType(strFig_Circle_data)),
    KnownType(GetType(strFig_Point_Data)),
    KnownType(GetType(strFig_gazo_data))> _
    Public Structure Total_Data_Info  '属性データ全体に関わるデータ（属性データ）
        <DataMember> _
        Public LV1 As strBasic_Data
        <DataMember> _
        Public TotalMode As strTotalMode_Info
        <DataMember> _
        Public ViewStyle As strViewStyle_Info
        <DataMember> _
        Public FigureStac As List(Of Object)
        <DataMember> _
        Public Condition As List(Of strCondition_DataSet_Info)
        <DataMember> _
        Public BasePicture As BasePicture_Info

        Public Sub initTotalData(ByVal TileMapDefault As strTileMapData_Info)
            With TotalMode
                .OverLay.initDataSet()
                .Series.initDataSet()
            End With
            BasePicture.PictureNum = 0
            ViewStyle.initViewStyle(TileMapDefault)
            FigureStac = New List(Of Object)
            Condition = New List(Of clsAttrData.strCondition_DataSet_Info)
        End Sub
    End Structure
    Public Structure strSeries_Temporaly_Data_Info
        Public Printing_Flag As Boolean
        Public Koma As Integer
        Public title As String
    End Structure

    Public Structure Overlay_Temporaly_Data_Info
        Public Printing_Number As Integer
        Public OverLay_Printing_Flag As Boolean  '記号やブロックを重ね合わせる際に標示位置をずらすのに使用
        Public OverLay_EMode_N As Integer '記号モードをずらす際に使用するが、10では使用しない
        Public OverLay_EMode_Now As Integer
        Public Always_Ove_DataStac As List(Of strOverLay_DataSet_Item_Info)
    End Structure
    Public Structure ContourModeTemp_Temporaly_Data_Info
        Public ContourDataResetF As Boolean
        Public ContourMesh As clsMeshContour
        Public Contour_Object() As strContour_Line_property
        Public Contour_Point() As PointF  '描いた等値線のデータ
        Public Contour_All_Number As Integer '描いた等値線の全体数
        Public Contour_All_Point As Integer '描いた等値線のポイント数

    End Structure
    Public Structure Trip_XY_info
        Public Number As Integer
        Public StayP1 As Point
        Public StayP2 As Point
        Public TripP1 As Point
        Public TripP2 As Point
        Public Stay_F As Boolean
        Public Trip_F As Boolean
        Public Start_F As Boolean
        Public End_F As Boolean
    End Structure
    Public Structure Stay_Object_Check_Info '移動データの3Dモード時に、滞在地点が同じ場合にずらす時に使用
        Public Count As Integer
        Public Flag As Boolean
        Public point As PointF
    End Structure
    Public Structure TripModeTemp_DataInfo
        Public Trip_StartTime As DateTime '移動データを表示する際の開始時間と終了時間
        Public Trip_EndTime As DateTime
        Public Stay_Object_Check() As Stay_Object_Check_Info
        Public Trip_Print_XY() As Trip_XY_info
    End Structure
    Public Structure Legend2_Atri
        Public LineKind_Flag As Boolean
        Public PointObject_Flag As Boolean
        Public Layn As Integer
        Public DatN As Integer
        Public Print_Mode_Layer As enmLayerMode_Number
        Public SoloMode As enmSoloMode_Number
        Public GraphMode As enmGraphMode
        Public title As String
        Public Rect As Rectangle
    End Structure
    Public Structure AccessoryTemp_Infp
        Public MapScale_Rect As Rectangle
        Public MapTitle_Rect As Rectangle
        Public DataNote_Rect As Rectangle
        Public MapLegend_W() As Legend2_Atri
        Public MapCompass_Rect As Rectangle
        Public GroupBox_Rect As Rectangle
        Public Legend_No_Max As Integer
        Public Push_titleXY As PointF
        Public Push_LegendXY As PointF
        Public Edit_Legend As Integer
        Public Push_CompassXY As PointF
        Public Push_ScaleXY As PointF
        Public Push_DataNoteXY As PointF
        Public OriginalGroupBoxRect As Rectangle
        Public Function Clone() As AccessoryTemp_Infp
            Dim tac As AccessoryTemp_Infp
            With tac
                .MapScale_Rect = Me.MapScale_Rect
                .DataNote_Rect = Me.DataNote_Rect
                .MapTitle_Rect = Me.MapTitle_Rect
                .MapCompass_Rect = Me.MapCompass_Rect
                .Legend_No_Max = Me.Legend_No_Max
                .Edit_Legend = Me.Edit_Legend
                .Push_CompassXY = Me.Push_CompassXY
                .Push_LegendXY = Me.Push_LegendXY
                .Push_ScaleXY = Me.Push_ScaleXY
                .Push_DataNoteXY = Me.Push_DataNoteXY
                .Push_titleXY = Me.Push_titleXY
                .MapLegend_W = Me.MapLegend_W.Clone
            End With
            Return tac
        End Function
    End Structure
    Public Structure strObjectKindUsed_Info
        Public Mark As Mark_Property
        Public ObjectKindName As String
        Public MapFileName As String
        Public ObjectKindNumber As Integer
    End Structure

    Public Structure DotMapTemp_Info '記号の数のドットマップの地図座標位置
        Public DotMapTempResetF As Boolean
        Public DotMapPoint As Dictionary(Of Integer, PointF())
    End Structure

    Public Structure ModeValueInScreen_Stac_Info
        Public setF As Boolean
        Public LayerNum As Integer
        Public DataNum As Integer
        Public divValue() As Double
        Public MarkSize_MaxValueMode As clsAttrData.enmMarkSizeValueMode
        Public MarkSize_MaxValue As Double
        Public MarkBar_MaxValueMode As clsAttrData.enmMarkSizeValueMode
        Public MarkBar_MaxValue As Double
    End Structure
    ''' <summary>
    ''' 一時データ
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strTemp
        Public Series_temp As strSeries_Temporaly_Data_Info
        Public OverLay_Temp As Overlay_Temporaly_Data_Info
        Public ContourMode_Temp As ContourModeTemp_Temporaly_Data_Info
        Public DotMap_Temp As DotMapTemp_Info
        Public Trip_Temp As TripModeTemp_DataInfo
        Public Accessory_Temp As AccessoryTemp_Infp
        Public FigurePrinted() As Boolean
        Public ObjectPrintedCheckFlag()() As Boolean
        Public PointObjectKindUsedStack As Stack(Of strObjectKindUsed_Info)
        Public ModeValueInScreen_Stac As ModeValueInScreen_Stac_Info
        ''' <summary>
        ''' 地図の緯度経度の領域
        ''' </summary>
        ''' <remarks></remarks>
        Public MapAreaLatLon As RectangleF
        Public SoubyouLayerEnable() As Boolean
        Public SoubyouLoopLineArea As Dictionary(Of Integer, Single())
        Public SoubyouLoopAreaCriteria As Single
        Public SoubyouLinePointIntervalCriteria As Single
    End Structure
    Public TempData As strTemp

    ''' <summary>
    ''' いったん座標を変換したラインの座標を速度向上のため描画中はMPSubLineに保持しておく
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure strGetLinePointAPI_Info
        Public GetF As Boolean
        Public Drawn As Boolean
        Public ReverseF As Boolean
        Public Point() As Point
    End Structure
    Private MPSubLine As New Dictionary(Of String, strGetLinePointAPI_Info())

    ''' <summary>
    ''' ■■全体データ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    ''' </summary>
    ''' <remarks></remarks>
    Public TotalData As Total_Data_Info
    Private MapData As clsAttrMapData
    Public TileMap As clsTileMapService

    ' ■■関数■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    ''' <summary>
    ''' 属性データ編集から座標系を設定する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function attrGridZahyoSet() As Boolean
        Me.TotalData.ViewStyle.Zahyo = MapData.GetPrestigeZahyoMode
        Return Me.MapData.EqualizeZahyoMode(TotalData.ViewStyle.Zahyo, "")
    End Function
    ''' <summary>
    ''' 指定した地図ファイルを削除
    ''' </summary>
    ''' <param name="MapFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RemoveMapData(ByVal MapFileName As String)
        Me.MapData.RemoveMapData(MapFileName)
    End Function
    ''' <summary>
    ''' 既存地図ファイル追加
    ''' </summary>
    ''' <param name="MapData"></param>
    ''' <param name="MapFileName"></param>
    ''' <remarks></remarks>
    Public Sub AddExistingMapData(ByRef MapData As clsMapData, ByVal MapFileName As String)
        If Me.MapData Is Nothing = True Then
            Me.MapData = New clsAttrMapData
        End If
        Me.MapData.AddExistingMapData(MapData, MapFileName)
    End Sub

    ''' <summary>
    ''' 同じ名前の地図ファイルが存在する場合、別名をつけて返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getUniqueMapFileName(ByVal checkMfile As String) As String
        Dim ExtMfile() As String = Me.GetMapFileName
        If Array.IndexOf(ExtMfile, checkMfile.ToUpper) = -1 Then
            Return checkMfile
        Else
            Dim Omfile As String
            Dim n As Integer = 1
            Do
                Omfile = checkMfile + n.ToString
                n += 1
            Loop Until Array.IndexOf(ExtMfile, Omfile.ToUpper) = -1
            Return Omfile
        End If
    End Function


    ''' <summary>
    ''' データ挿入
    ''' </summary>
    ''' <param name="InsertData"></param>
    ''' <param name="AddMapFileNameF">レイヤ名に地図ファイルを追加する場合true</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ADD_AttrData(ByRef InsertData As clsAttrData, ByVal AddMapFileNameF As Boolean, ByRef ErrorMessage As String) As Boolean

        If spatial.Check_Zahyo_Projection_Convert_Enabled(Me.TotalData.ViewStyle.Zahyo, InsertData.TotalData.ViewStyle.Zahyo, ErrorMessage) = False Then
            Return False
        End If


        Dim Mfile() As String = InsertData.GetMapFileName
        Dim ExtMfile() As String = Me.GetMapFileName
        Dim LayerPlus As Integer = Me.TotalData.LV1.Lay_Maxn
        If InsertData.TotalData.LV1.DataSourceType = enmDataSource.MDRM Or InsertData.TotalData.LV1.DataSourceType = enmDataSource.MDRMZ Then
            For i As Integer = 0 To Mfile.Length - 1
                Dim newMFname As String = getUniqueMapFileName(Mfile(i))
                Me.MapData.AddExistingMapData(InsertData.SetMapFile(Mfile(i)), newMFname)
                For j As Integer = 0 To InsertData.TotalData.LV1.Lay_Maxn - 1
                    If InsertData.LayerData(j).MapFileName.ToUpper = Mfile(i).ToUpper Then
                        InsertData.LayerData(j).MapFileName = newMFname
                    End If
                Next
            Next
        Else
            For i As Integer = 0 To Mfile.Length - 1
                If Array.IndexOf(ExtMfile, Mfile(i)) = -1 Then
                    Me.MapData.AddExistingMapData(InsertData.SetMapFile(Mfile(i)), (Mfile(i)))
                End If
            Next
        End If

        InsertData.Convert_Zahyo(Me.TotalData.ViewStyle.Zahyo)
        Me.MapData.EqualizeZahyoMode(Me.TotalData.ViewStyle.Zahyo, "")
        InsertData.Renumbering_Picture_Use(0, TotalData.BasePicture.PictureNum)

        If InsertData.TotalData.LV1.Comment <> "" Then
            Me.TotalData.LV1.Comment += vbCrLf + InsertData.TotalData.LV1.FileName + "を挿入" + vbCrLf +
                            InsertData.TotalData.LV1.Comment

        End If
        'レイヤのコピー
        Dim nLayer As Integer = Me.TotalData.LV1.Lay_Maxn + InsertData.TotalData.LV1.Lay_Maxn
        ReDim Preserve Me.LayerData(nLayer - 1)
        For i As Integer = 0 To InsertData.TotalData.LV1.Lay_Maxn - 1
            With InsertData.LayerData(i)
                If .Name = "" And InsertData.TotalData.LV1.Lay_Maxn > 1 Then
                    .Name = (i + 1).ToString
                End If
                If AddMapFileNameF = True Then
                    If .Name <> "" Then
                        If InsertData.TotalData.LV1.FileName <> "" Then
                            .Name = InsertData.TotalData.LV1.FileName + "：" + .Name
                        End If
                    Else
                        .Name = InsertData.TotalData.LV1.FileName
                    End If
                End If
                For j As Integer = 0 To .atrData.Count - 1
                    .atrData.Data(j).SoloModeViewSettings.ClassODMD.o_Layer += LayerPlus
                Next
            End With
            Me.LayerData(Me.TotalData.LV1.Lay_Maxn + i) = InsertData.LayerData(i)
            Me.LayerData(Me.TotalData.LV1.Lay_Maxn + i).Set_MapFileData(Me.MapData.SetMapFile(InsertData.LayerData(i).MapFileName))
        Next
        Me.TotalData.LV1.Lay_Maxn = nLayer

        With InsertData.TotalData.TotalMode
            '重ね合わせモード
            For i As Integer = 0 To .OverLay.DataSet.Count - 1
                With .OverLay.DataSet(i)
                    For j As Integer = 0 To .DataItem.Count - 1
                        Dim d As strOverLay_DataSet_Item_Info = .DataItem(j)
                        d.Layer += LayerPlus
                        .DataItem(j) = d
                    Next
                End With
            Next
            If .OverLay.DataSet.Count = 1 And .OverLay.DataSet(0).DataItem.Count = 0 And .OverLay.DataSet(0).title = "" Then
            Else
                Me.TotalData.TotalMode.OverLay.DataSet.AddRange(.OverLay.DataSet)
            End If

            '連続表示モード
            For i As Integer = 0 To .Series.DataSet.Count - 1
                With .Series.DataSet(i)
                    For j As Integer = 0 To .DataItem.Count - 1
                        Dim d As strSeries_DataSet_Item_Info = .DataItem(j)
                        d.Layer += LayerPlus
                        .DataItem(j) = d
                    Next
                End With
            Next
            If .Series.DataSet.Count = 1 And .Series.DataSet(0).DataItem.Count = 0 And .Series.DataSet(0).title = "" Then
            Else
                Me.TotalData.TotalMode.Series.DataSet.AddRange(InsertData.TotalData.TotalMode.Series.DataSet)
            End If
        End With

        '表示設定のコピー
        With InsertData.TotalData.ViewStyle
            Me.TotalData.ViewStyle.Screen_Setting.AddRange(.Screen_Setting)
        End With

        For i As Integer = 0 To Mfile.Length - 1
            If Array.IndexOf(ExtMfile, Mfile(i)) = -1 Then
                If InsertData.TotalData.ViewStyle.DummyObjectPointMark.Count > 0 Then
                    Me.TotalData.ViewStyle.DummyObjectPointMark.Add(Mfile(i), InsertData.TotalData.ViewStyle.DummyObjectPointMark(Mfile(i)))
                End If
            End If
        Next

        '画像の変換
        With InsertData.TotalData.BasePicture
            Me.TotalData.BasePicture.PictureData.AddRange(.PictureData)
            Me.TotalData.BasePicture.PictureNum += .PictureNum
        End With

        With InsertData.TotalData
            '条件設定の変換
            For i As Integer = 0 To .Condition.Count - 1
                Dim d As strCondition_DataSet_Info = .Condition.Item(i)
                With d
                    .Layer += LayerPlus
                End With
                .Condition.Item(i) = d
            Next
        End With
        Me.TotalData.Condition.AddRange(InsertData.TotalData.Condition)

        '図形モードの変換
        For wi As Integer = 0 To InsertData.TotalData.FigureStac.Count - 1
            Dim FigStac As Object = InsertData.TotalData.FigureStac(wi)
            Select Case True
                Case TypeOf FigStac Is clsAttrData.strFig_Word_Data
                    Dim FigData As clsAttrData.strFig_Word_Data = DirectCast(FigStac, clsAttrData.strFig_Word_Data)
                    If FigData.Data.Layer <> 0 Then
                        FigData.Data.Layer += LayerPlus
                    End If
                    Me.TotalData.FigureStac.Add(FigData)
                Case TypeOf FigStac Is clsAttrData.strFig_Line_Data
                    Dim FigData As clsAttrData.strFig_Line_Data = DirectCast(FigStac, clsAttrData.strFig_Line_Data)
                    If FigData.Data.Layer <> 0 Then
                        FigData.Data.Layer += LayerPlus
                    End If
                    Me.TotalData.FigureStac.Add(FigData)
                Case TypeOf FigStac Is clsAttrData.strFig_Rectangle_Data
                    Dim FigData As clsAttrData.strFig_Rectangle_Data = DirectCast(FigStac, clsAttrData.strFig_Rectangle_Data)
                    If FigData.Data.Layer <> 0 Then
                        FigData.Data.Layer += LayerPlus
                    End If
                    Me.TotalData.FigureStac.Add(FigData)
                Case TypeOf FigStac Is clsAttrData.strFig_Circle_data
                    Dim FigData As clsAttrData.strFig_Circle_data = DirectCast(FigStac, clsAttrData.strFig_Circle_data)
                    If FigData.Data.Layer <> 0 Then
                        FigData.Data.Layer += LayerPlus
                    End If
                    Me.TotalData.FigureStac.Add(FigData)
                Case TypeOf FigStac Is clsAttrData.strFig_Point_Data
                    Dim FigData As clsAttrData.strFig_Point_Data = DirectCast(FigStac, clsAttrData.strFig_Point_Data)
                    If FigData.Data.Layer <> 0 Then
                        FigData.Data.Layer += LayerPlus
                    End If
                    Me.TotalData.FigureStac.Add(FigData)
                Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                    Dim FigData As clsAttrData.strFig_gazo_data = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                    If FigData.Data.Layer <> 0 Then
                        FigData.Data.Layer += LayerPlus
                    End If
                    Me.TotalData.FigureStac.Add(FigData)
            End Select
        Next

        Check_Vector_Object()
        LinePatternCheck()
        PrtObjectSpatialIndex()
        Return True
    End Function
    ''' <summary>
    ''' データ中の座標を変換する
    ''' </summary>
    ''' <param name="newZahyo"></param>
    ''' <remarks></remarks>
    Public Sub Convert_Zahyo(ByVal newZahyo As clsMapData.Zahyo_info)
        Dim oldZahyo As clsMapData.Zahyo_info = Me.TotalData.ViewStyle.Zahyo
        For i As Integer = 0 To TotalData.LV1.Lay_Maxn - 1
            With LayerData(i)
                If .Type <> enmLayerType.Trip And .Type <> enmLayerType.Trip_Definition Then
                    '記号・ラベル表示位置
                    For j As Integer = 0 To .atrObject.ObjectNum - 1
                        With .atrObject.atrObjectData(j)
                            .CenterPoint = spatial.Get_Reverse_and_Convert_XY(.CenterPoint, oldZahyo, newZahyo)
                            .Symbol = spatial.Get_Reverse_and_Convert_XY(.Symbol, oldZahyo, newZahyo)
                            .Label = spatial.Get_Reverse_and_Convert_XY(.Label, oldZahyo, newZahyo)
                        End With
                    Next
                    'ODの参照点
                    For j As Integer = 0 To .ODBezier_DataStac.Count - 1
                        Dim d As ODBezier_Data = .ODBezier_DataStac(j)
                        d.Point = spatial.Get_Reverse_and_Convert_XY(d.Point, oldZahyo, newZahyo)
                        .ODBezier_DataStac(j) = d
                    Next
                End If
                If .Type = enmLayerType.Mesh Then
                    For j As Integer = 0 To .atrObject.ObjectNum - 1
                        With .atrObject.atrObjectData(j)
                            For k As Integer = 0 To 3
                                .MeshPoint(k) = spatial.Get_Reverse_and_Convert_XY(.MeshPoint(k), oldZahyo, newZahyo)
                            Next
                            .MeshRect = spatial.Get_Circumscribed_Rectangle(.MeshPoint, 0, 4)
                        End With
                    Next
                End If
            End With
        Next

        '図形モード
        For i As Integer = 0 To TotalData.FigureStac.Count - 1
            Dim FigStac As Object = TotalData.FigureStac(i)
            Select Case True
                Case TypeOf FigStac Is clsAttrData.strFig_Word_Data
                    Dim FigData As clsAttrData.strFig_Word_Data = DirectCast(FigStac, clsAttrData.strFig_Word_Data)
                    With FigData
                        For j As Integer = 0 To .StringPos.Length - 1
                            .StringPos(j) = spatial.Get_Reverse_and_Convert_XY(.StringPos(j), oldZahyo, newZahyo)
                        Next
                        TotalData.FigureStac(i) = FigData
                    End With
                Case TypeOf FigStac Is clsAttrData.strFig_Line_Data
                    Dim FigData As clsAttrData.strFig_Line_Data = DirectCast(FigStac, clsAttrData.strFig_Line_Data)
                    With FigData
                        For j As Integer = 0 To .NumOfPoint - 1
                            .Points(j) = spatial.Get_Reverse_and_Convert_XY(.Points(j), oldZahyo, newZahyo)
                        Next
                        TotalData.FigureStac(i) = FigData
                    End With
                Case TypeOf FigStac Is clsAttrData.strFig_Circle_data
                    Dim FigData As clsAttrData.strFig_Circle_data = DirectCast(FigStac, clsAttrData.strFig_Circle_data)
                    With FigData
                        .Position = spatial.Get_Reverse_and_Convert_XY(.Position, oldZahyo, newZahyo)
                    End With
                    TotalData.FigureStac(i) = FigData
                Case TypeOf FigStac Is clsAttrData.strFig_Point_Data
                    Dim FigData As clsAttrData.strFig_Point_Data = DirectCast(FigStac, clsAttrData.strFig_Point_Data)
                    With FigData
                        For j As Integer = 0 To .NumOfPoint - 1
                            .Points(j) = spatial.Get_Reverse_and_Convert_XY(.Points(j), oldZahyo, newZahyo)
                        Next
                        TotalData.FigureStac(i) = FigData
                    End With
                Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                    Dim FigData As clsAttrData.strFig_gazo_data = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                    With FigData
                        .Position = spatial.Get_Reverse_and_Convert_XY(.Position, oldZahyo, newZahyo)
                        TotalData.FigureStac(i) = FigData
                    End With
            End Select
        Next
    End Sub
    ''' <summary>
    ''' 選択画像の番号を振り直す
    ''' </summary>
    ''' <param name="CheckIndex">指定した数字以上の画像番号について</param>
    ''' <param name="PlusValue">指定した値を加える</param>
    ''' <remarks></remarks>
    Public Sub Renumbering_Picture_Use(ByVal CheckIndex As Integer, ByVal PlusValue As Integer)


        For i As Integer = 0 To Me.TotalData.FigureStac.Count - 1
            Dim FigStac As Object = Me.TotalData.FigureStac(i)
            Select Case True
                Case TypeOf FigStac Is clsAttrData.strFig_Word_Data
                    Dim FigData As clsAttrData.strFig_Word_Data = DirectCast(FigStac, clsAttrData.strFig_Word_Data)
                    Check_FontMark_PicureNumber(FigData.Font, CheckIndex, PlusValue)
                    Me.TotalData.FigureStac.Item(i) = FigData
                Case TypeOf FigStac Is clsAttrData.strFig_Line_Data
                    Dim FigData As clsAttrData.strFig_Line_Data = DirectCast(FigStac, clsAttrData.strFig_Line_Data)
                    Check_TileMark_PicureNumber(FigData.Tile, CheckIndex, PlusValue)
                    Me.TotalData.FigureStac.Item(i) = FigData
                Case TypeOf FigStac Is clsAttrData.strFig_Circle_data
                    Dim FigData As clsAttrData.strFig_Circle_data = DirectCast(FigStac, clsAttrData.strFig_Circle_data)
                    Check_Mark_PicureNumber(FigData.Mark, CheckIndex, PlusValue)
                    Check_TileMark_PicureNumber(FigData.Tile, CheckIndex, PlusValue)
                    Me.TotalData.FigureStac.Item(i) = FigData
                Case TypeOf FigStac Is clsAttrData.strFig_Point_Data
                    Dim FigData As clsAttrData.strFig_Point_Data = DirectCast(FigStac, clsAttrData.strFig_Point_Data)
                    Check_Mark_PicureNumber(FigData.Mark, CheckIndex, PlusValue)
                    Check_FontMark_PicureNumber(FigData.Font, CheckIndex, PlusValue)
                    Me.TotalData.FigureStac.Item(i) = FigData
                Case TypeOf FigStac Is clsAttrData.strFig_gazo_data
                    Dim FigData As clsAttrData.strFig_gazo_data = DirectCast(FigStac, clsAttrData.strFig_gazo_data)
                    If FigData.PictureNumber > CheckIndex Then
                        FigData.PictureNumber -= 1
                    End If
                    Me.TotalData.FigureStac.Item(i) = FigData
            End Select
        Next


        For i As Integer = 0 To Me.TotalData.LV1.Lay_Maxn - 1
            For j As Integer = 0 To Me.LayerData(i).atrData.Count - 1
                With Me.LayerData(i).atrData.Data(j)
                    If .DataType = enmAttDataType.Normal Then
                        Check_TileMark_PicureNumber(.SoloModeViewSettings.MarkCommon.MinusTile, CheckIndex, PlusValue)
                        Check_Mark_PicureNumber(.SoloModeViewSettings.MarkBlockMD.Mark, CheckIndex, PlusValue)
                        Check_Mark_PicureNumber(.SoloModeViewSettings.MarkSizeMD.Mark, CheckIndex, PlusValue)
                        Check_Mark_PicureNumber(.SoloModeViewSettings.MarkTurnMD.Mark, CheckIndex, PlusValue)
                    End If
                    If .DataType = enmAttDataType.Normal Or .DataType = enmAttDataType.Category Then
                        For k As Integer = 0 To .SoloModeViewSettings.Div_Num - 1
                            Check_TileMark_PicureNumber(.SoloModeViewSettings.Class_Div(k).TilePat, CheckIndex, PlusValue)
                            Check_Mark_PicureNumber(.SoloModeViewSettings.Class_Div(k).ClassMark, CheckIndex, PlusValue)
                        Next
                    End If
                End With
            Next
            If Me.LayerData(i).Shape = enmShape.PointShape Then
                Check_Mark_PicureNumber(Me.LayerData(i).LayerModeViewSettings.PointLineShape.PointMark, CheckIndex, PlusValue)
            End If
            With Me.LayerData(i).LayerModeViewSettings.LabelMode
                For j As Integer = 0 To .Count - 1
                    With .DataSet(j)
                        Check_Mark_PicureNumber(.Location_Mark, CheckIndex, PlusValue)
                        Check_TileMark_PicureNumber(.BorderObjectTile, CheckIndex, PlusValue)
                        Check_TileMark_PicureNumber(.BorderDataTile, CheckIndex, PlusValue)
                        Check_FontMark_PicureNumber(.ObjectName_Font, CheckIndex, PlusValue)
                        Check_FontMark_PicureNumber(.DataValue_Font, CheckIndex, PlusValue)
                        Check_FontMark_PicureNumber(.Dummy_Object_Font, CheckIndex, PlusValue)
                        Check_FontMark_PicureNumber(.Dummy_Object_Group_Font, CheckIndex, PlusValue)
                    End With
                Next
            End With

            With Me.LayerData(i).LayerModeViewSettings.GraphMode
                For j As Integer = 0 To .Count - 1
                    With .DataSet(j)
                        Call Check_TileMark_PicureNumber(.Oresen_Bou.BackgroundTile, CheckIndex, PlusValue)
                    End With
                Next
            End With
        Next
        With Me.TotalData.ViewStyle
            Check_Mark_PicureNumber(.Missing_Data.BlockMark, CheckIndex, PlusValue)
            Check_Mark_PicureNumber(.Missing_Data.Mark, CheckIndex, PlusValue)
            Check_Mark_PicureNumber(.Missing_Data.ClassMark, CheckIndex, PlusValue)
            Check_Mark_PicureNumber(.Missing_Data.TurnMark, CheckIndex, PlusValue)
            Check_TileMark_PicureNumber(.Missing_Data.HatchTile, CheckIndex, PlusValue)
            Check_TileMark_PicureNumber(.Missing_Data.PaintTile, CheckIndex, PlusValue)
            Check_Mark_PicureNumber(.AttMapCompass.Mark, CheckIndex, PlusValue)
            With .Trip_Line
                Check_Mark_PicureNumber(.StartPoint_Mark, CheckIndex, PlusValue)
                Check_Mark_PicureNumber(.EndPoint_Mark, CheckIndex, PlusValue)
                Check_FontMark_PicureNumber(.TimeLegend_Font, CheckIndex, PlusValue)
            End With
            Check_TileMark_PicureNumber(.MapLegend.Base.Back.Tile, CheckIndex, PlusValue)
            Check_TileMark_PicureNumber(.MapScale.Back.Tile, CheckIndex, PlusValue)
            Check_FontMark_PicureNumber(.MapTitle.Font, CheckIndex, PlusValue)
            Check_FontMark_PicureNumber(.MapLegend.Base.Font, CheckIndex, PlusValue)
            Check_FontMark_PicureNumber(.MapScale.Font, CheckIndex, PlusValue)
            Check_FontMark_PicureNumber(.DataNote.Font, CheckIndex, PlusValue)
            Check_TileMark_PicureNumber(.Screen_Back.MapAreaBack, CheckIndex, PlusValue)
            Check_TileMark_PicureNumber(.Screen_Back.ScreenAreaBack, CheckIndex, PlusValue)
            Check_TileMark_PicureNumber(.Screen_Back.ObjectInner, CheckIndex, PlusValue)
            Check_TileMark_PicureNumber(.AccessoryGroupBox.Back.Tile, CheckIndex, PlusValue)
        End With
        With Me.TotalData.ViewStyle.Screen_Setting
            For i As Integer = 0 To .Count - 1
                Dim d As clsAttrData.strScreen_Setting_Data_Info = .Item(i)
                With d
                    Check_TileMark_PicureNumber(.MapScale.Back.Tile, CheckIndex, PlusValue)
                    Check_Mark_PicureNumber(.AttMapCompass.Mark, CheckIndex, PlusValue)
                    Check_FontMark_PicureNumber(.MapTitle.Font, CheckIndex, PlusValue)
                    Check_FontMark_PicureNumber(.MapLegend.Base.Font, CheckIndex, PlusValue)
                    Check_TileMark_PicureNumber(.MapLegend.Base.Back.Tile, CheckIndex, PlusValue)
                    Check_FontMark_PicureNumber(.MapScale.Font, CheckIndex, PlusValue)
                    Check_FontMark_PicureNumber(.DataNote.Font, CheckIndex, PlusValue)
                End With
                .Item(i) = d
            Next
        End With
    End Sub
    Private Sub Check_Mark_PicureNumber(ByRef MK As Mark_Property, ByVal CheckIndex As Integer, ByVal PlusValue As Integer)
        With MK
            If .PictureNumber >= CheckIndex Then
                .PictureNumber += PlusValue
            End If
        End With


    End Sub
    Private Sub Check_TileMark_PicureNumber(ByRef TileMK As Tile_Property, ByVal CheckIndex As Integer, ByVal PlusValue As Integer)
        With TileMK.TileMark
            If .PictureNumber >= CheckIndex Then
                .PictureNumber += PlusValue
            End If
        End With

    End Sub
    Private Sub Check_FontMark_PicureNumber(ByRef FontTileMK As Font_Property, ByVal CheckIndex As Integer, ByVal PlusValue As Integer)
        With FontTileMK.Back.Tile.TileMark
            If .PictureNumber >= CheckIndex Then
                .PictureNumber += PlusValue
            End If
        End With

    End Sub
    ''' <summary>
    ''' 階級区分の度数分布を求める。区分値が不正の場合はfalseを返す
    ''' </summary>
    ''' <param name="LayerNum">レイヤ</param>
    ''' <param name="DataNum">データ項目</param>
    ''' <param name="ConditionCheck">条件設定をチェックする場合true</param>
    ''' <param name="Freqency">度数分布（戻り値）</param>
    ''' <param name="MissFreq">欠損値の数（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_ClassFrequency(ByVal LayerNum As Integer, ByVal DataNum As Integer, ByVal ConditionCheck As Boolean, ByRef Freqency() As Integer, ByRef MissFreq As Integer) As Boolean
        Dim DDType As enmAttDataType = Me.Get_DataType(LayerNum, DataNum)
        With LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            If DDType = enmAttDataType.Category Then
            Else
                For i As Integer = 0 To .Div_Num - 3
                    Dim v As Double = .Class_Div(i + 1).Value
                    If .Class_Div(i).Value <= v Then
                        Return False
                    End If
                Next
            End If
            Dim cate() As Integer = Me.Get_Categoly(LayerNum, DataNum)
            MissFreq = 0
            ReDim Freqency(.Div_Num - 1)
            For i As Integer = 0 To cate.Length - 1
                Dim f As Boolean = True
                If ConditionCheck = True Then
                    f = Me.Check_Condition(LayerNum, i)
                End If
                If f = True Then
                    If cate(i) = -1 Then
                        MissFreq += 1
                    Else
                        Freqency(cate(i)) += 1
                    End If
                End If
            Next
            Return True
        End With
    End Function
    ''' 
    ''' <summary>
    ''' 地図デーセットをセットする
    ''' </summary>
    ''' <param name="MapFileName">空白の場合、最初に読み込まれた地図</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetMapFile(ByVal MapFileName As String) As clsMapData
        Return Me.MapData.SetMapFile(MapFileName)
    End Function
    ''' <summary>
    ''' mdrz/mdrmzファイル保存
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="progressbar"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveMDRZFile(ByVal FileName As String, ByRef progressbar As ProgressBar) As Boolean


        Dim ext As String = LCase(System.IO.Path.GetExtension(FileName))
        Dim MapFileList() As String = Me.GetMapFileName()

        Dim progMax As Integer = 2 + 1 + Me.TotalData.LV1.Lay_Maxn + Me.TotalData.BasePicture.PictureNum + 1
        Select Case ext
            Case ".mdrz"
                progMax += 1
            Case ".mdrmz"
                progMax += MapFileList.Length
        End Select
        progressbar.Maximum = progMax
        progressbar.Value = 1
        progressbar.Visible = True

        '一時フォルダを作成
        Dim tmpFolderName As String = clsGeneric.MakeTempFolder_forZip()
        If tmpFolderName = "" Then
            progressbar.Visible = False
            Return False
        End If
        progressbar.Value += 1

        'Total_Dataの保存 Dictionaryを使っているのでDataContractSerializerオブジェクトを作成
        Dim serializer As New DataContractSerializer(GetType(Total_Data_Info)) 'オブジェクトの型を指定する
        Dim settings As New System.Xml.XmlWriterSettings()
        settings.Encoding = New System.Text.UTF8Encoding(False)
        Dim xw As System.Xml.XmlWriter = System.Xml.XmlWriter.Create(tmpFolderName + "\total.xml", settings)
        serializer.WriteObject(xw, Me.TotalData)
        xw.Close()


        progressbar.Value += 1

        'LayerDataの保存
        For i As Integer = 0 To Me.TotalData.LV1.Lay_Maxn - 1
            Dim serLayer As New System.Xml.Serialization.XmlSerializer(GetType(strLayerDataInfo))
            Dim fsLayer As New System.IO.FileStream(tmpFolderName + "\Layer" + i.ToString + ".xml", System.IO.FileMode.Create)
            serLayer.Serialize(fsLayer, Me.LayerData(i))
            fsLayer.Close()
            progressbar.Value += 1
        Next

        '線種の保存
        Select Case ext
            Case ".mdrz"
                '通常は線種のみ保存
                Dim saveLPat As New strSaveLinePat_Info
                saveLPat.MapNum = MapFileList.Length
                saveLPat.MapFileName = MapFileList.Clone
                ReDim saveLPat.LpatNumByMapfile(saveLPat.MapNum - 1)
                saveLPat.Lpat = New List(Of clsMapData.LineKind_Data)
                For i As Integer = 0 To MapFileList.Length - 1
                    Dim LK() As clsMapData.LPatSek_Info
                    Dim n As Integer = Me.SetMapFile(MapFileList(i)).Map.LpNum
                    saveLPat.LpatNumByMapfile(i) = n
                    For j As Integer = 0 To n - 1
                        saveLPat.Lpat.Add(Me.SetMapFile(MapFileList(i)).LineKind(j))
                    Next
                Next
                Dim serLPat As New System.Xml.Serialization.XmlSerializer(GetType(strSaveLinePat_Info))
                Dim fsLpat As New System.IO.FileStream(tmpFolderName + "\LPat.xml", System.IO.FileMode.Create)
                serLPat.Serialize(fsLpat, saveLPat)
                fsLpat.Close()
                progressbar.Value += 1
            Case ".mdrmz"
                '地図ファイル附属形式の場合は地図ファイルごと保存
                For i As Integer = 0 To MapFileList.Length - 1
                    Dim mpFile As clsMapData = Me.SetMapFile(MapFileList(i))
                    Dim fname As String = System.IO.Path.GetFileNameWithoutExtension(mpFile.Map.FileName) + ".mpfx"
                    Dim f As Boolean = mpFile.SaveMapFile(tmpFolderName + "\" + fname)
                    progressbar.Value += 1
                Next
        End Select

        '画像をpngで保存
        If Me.TotalData.BasePicture.PictureNum <> 0 Then
            For i As Integer = 0 To Me.TotalData.BasePicture.PictureNum - 1
                Me.TotalData.BasePicture.PictureData.Item(i).GetBitmap.Save(tmpFolderName + "\picture" + i.ToString + ".png", System.Drawing.Imaging.ImageFormat.Png)
                progressbar.Value += 1
            Next
        End If

        clsGeneric.CompressFolder_and_DeleteTempFolder(tmpFolderName, FileName)
        progressbar.Visible = False
        Return True
    End Function
    ''' <summary>
    ''' 地図ファイル数を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNumOfMapFile() As Integer
        If MapData Is Nothing Then
            Return 0
        Else
            Return MapData.GetNumOfMapFile
        End If
    End Function
    ''' <summary>
    ''' 読み込んだ地図ファイルのファイル名の配列を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMapFileName() As String()
        If MapData Is Nothing = True Then
            Return Nothing
        Else
            Return MapData.GetMapFileName
        End If
    End Function
    ''' <summary>
    ''' データ読み込み後の共通初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initTotalData_andOther()
        Dim DourceType As enmDataSource = Me.TotalData.LV1.DataSourceType

        If DourceType = enmDataSource.CSV Or DourceType = enmDataSource.Clipboard Or DourceType = enmDataSource.Viwer Or
            DourceType = enmDataSource.Shapefile Or DourceType = enmDataSource.DataEdit Then
            Me.TotalData.initTotalData(Me.TileMap.getTileMap_by_Name("地理院地図（標準地図）"))
            With Me.TotalData.ViewStyle
                .AttMapCompass = Me.SetMapFile("").Map.MapCompass
                .MapScale.Visible = Me.SetMapFile("").Map.Detail.ScaleVisible
                .MapScale.Unit = Me.SetMapFile("").Map.SCL_U
            End With
            If Me.Get_Trip_Definition_Layer_Number <> -1 Then
                Me.TotalData.ViewStyle.Dummy_Size_Flag = False
                Dim tripLa As List(Of Integer) = Me.Get_Trip_Layer()
                If tripLa.Count > 0 Then
                    Me.TotalData.LV1.SelectedLayer = tripLa(0)
                End If
            End If
            Me.Check_Vector_Object() '地図領域の範囲を計算
            If Me.TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                '緯度経度の場合の経緯線設定
                Dim w As Single = Me.TempData.MapAreaLatLon.Width
                With Me.TotalData.ViewStyle.LatLonLine_Print
                    If w < 30 Then
                    ElseIf w < 60 Then
                        .Lat_Interval = 2
                        .Lon_Interval = 2
                    ElseIf w < 90 Then
                        .Visible = True
                        .Lat_Interval = 5
                        .Lon_Interval = 5
                    ElseIf w < 180 Then
                        .Visible = True
                        .Lat_Interval = 10
                        .Lon_Interval = 10
                    Else
                        .Visible = True
                        .Lat_Interval = 15
                        .Lon_Interval = 15
                    End If
                End With
            End If
            initDummuyPointObjectMark()
        Else
            Me.TempData.MapAreaLatLon = get_DataLatLonBox()
        End If
        Me.LinePatternCheck()
        Me.PrtObjectSpatialIndex()


    End Sub
    ''' <summary>
    ''' ダミー点オブジェクトの記号を初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initDummuyPointObjectMark()
        With Me.TotalData.ViewStyle
            .MapLegend.Line_DummyKind.Line_Visible_Number_STR = New String("1", Me.GetAllMapLineKindNum)
            .DummyObjectPointMark = New Dictionary(Of String, strDummyObjectPointMark_Info())
            Dim PointObjG As Dictionary(Of String, String()) = Me.GetAllPointObjectGroup
            For Each pair As KeyValuePair(Of String, String()) In PointObjG
                If pair.Value.Length > 0 Then
                    Dim d(pair.Value.Length - 1) As strDummyObjectPointMark_Info
                    For i As Integer = 0 To pair.Value.Length - 1
                        With d(i)
                            .ObjectKindName = pair.Value(i)
                            .Mark = clsBase.Mark
                        End With
                    Next
                    .DummyObjectPointMark.Add(pair.Key, d)
                End If
            Next
        End With

    End Sub
    ''' <summary>
    ''' メニューのファイルを開くから呼び出される
    ''' </summary>
    ''' <param name="ClipBoardFlag"></param>
    ''' <param name="FileFullPath"></param>
    ''' <param name="ObjectErrorMessage"></param>
    ''' <param name="ProgressBar"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function OpenNewMandaraFile(ByVal ClipBoardFlag As Boolean, ByVal FileFullPath As String,
                                       ByRef ObjectErrorMessage As String, ByRef ProgressBar As ProgressBar) As Boolean
        Dim f As Boolean
        If ClipBoardFlag = True Then
            f = Me.SetDataFromClipBoard(ObjectErrorMessage, ProgressBar)
            Me.TotalData.LV1.DataSourceType = enmDataSource.Clipboard
            Me.TotalData.LV1.FileName = "Clipboard"
            Me.TotalData.LV1.FullPath = "Clipboard"
        Else
            Dim ext As String = LCase(System.IO.Path.GetExtension(FileFullPath))
            Select Case ext
                Case ".csv"
                    f = Me.SetDataFromCSV(FileFullPath, ObjectErrorMessage, ProgressBar)
                    Me.TotalData.LV1.DataSourceType = enmDataSource.CSV
                Case ".mdr"
                    f = Me.SetDataFromOldMDR(FileFullPath, ObjectErrorMessage, ProgressBar)
                    Me.TotalData.LV1.DataSourceType = enmDataSource.MDR
                    Check_MDRZ_MDR_ObjectExists(ObjectErrorMessage)
                Case ".mdrm"
                    f = Me.SetDataFromOldMDR(FileFullPath, ObjectErrorMessage, ProgressBar)
                    Me.TotalData.LV1.DataSourceType = enmDataSource.MDRM
                Case ".mdrz"
                    f = Me.SetDataFromMDRZ(FileFullPath, ObjectErrorMessage, ProgressBar)
                    If f = True Then
                        Me.TotalData.LV1.DataSourceType = enmDataSource.MDRZ
                        Check_MDRZ_MDR_ObjectExists(ObjectErrorMessage)
                    End If
                Case ".mdrmz"
                    f = Me.SetDataFromMDRZ(FileFullPath, ObjectErrorMessage, ProgressBar)
                    Me.TotalData.LV1.DataSourceType = enmDataSource.MDRMZ
            End Select
            If f = True Then
                Me.TotalData.LV1.FileName = System.IO.Path.GetFileName(FileFullPath)
                Me.TotalData.LV1.FullPath = FileFullPath
                If ext <> ".csv" Then
                    For i As Integer = 0 To Me.TotalData.LV1.Lay_Maxn - 1
                        'MDRファイル、2017/5/19以前に保存したMDRZファイルの、データの有効桁数を計算する
                        If Me.TotalData.ViewStyle.SouByou.AutoDegree = 0 Then
                            Me.TotalData.ViewStyle.SouByou.AutoDegree = 2
                        End If
                        With Me.LayerData(i)
                            For j As Integer = 0 To .atrData.Count - 1
                                With .atrData.Data(j)
                                    Dim EDataNum As Integer = .EnableValueNum
                                    If .DataType = enmAttDataType.Normal Then
                                        If .Statistics.AfterDecimalNum = 0 And .Statistics.BeforeDecimalNum = 0 Then
                                            Dim BeforeDecimal As Integer = 0
                                            Dim AfterDecimal As Integer = 0
                                            Dim EnableDT() As strObjLocation_and_Data_info = Get_Data_Cell_Array_Without_MissingValue(i, j)
                                            For k As Integer = 0 To EDataNum - 1
                                                Dim v As Double = Val(EnableDT(i).DataValue)
                                                Dim b As Integer, a As Integer
                                                clsGeneric.Figure_Arrange(v, b, a)
                                                BeforeDecimal = Math.Max(BeforeDecimal, b)
                                                AfterDecimal = Math.Max(AfterDecimal, a)
                                            Next
                                            With .Statistics
                                                .AfterDecimalNum = AfterDecimal
                                                .BeforeDecimalNum = BeforeDecimal
                                                .Ave = Val(clsGeneric.Figure_Using(.Ave, AfterDecimal + 1))
                                                .STD = Val(clsGeneric.Figure_Using(.STD, AfterDecimal + 1))
                                            End With
                                        End If
                                    End If
                                End With
                            Next
                        End With
                    Next
                End If
            End If
        End If
        If f = True Then
            Me.initTotalData_andOther()
        End If
        Return f
    End Function
    ''' <summary>
    ''' クリップボードから読み込み
    ''' </summary>
    ''' <param name="ObjectErrorMessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetDataFromClipBoard(ByRef ObjectErrorMessage As String, ByRef ProgressBar As ProgressBar) As Boolean
        Dim clipText As String = Clipboard.GetText
        If clipText = "" Then
            Dim msgText1 As String = "クリップボードにデータがありません。"
            MsgBox(msgText1, MsgBoxStyle.Exclamation)
            Return False
        End If
        If Microsoft.VisualBasic.Right(clipText, 2) = vbCrLf Then
            clipText = Mid(clipText, 1, Len(clipText) - 2)
        End If
        Dim STR() As String = Split(clipText, vbCrLf)
        ObjectErrorMessage = ""
        Dim f As Boolean = ReadAttrDataOneLine(STR, vbTab, ObjectErrorMessage, ProgressBar)
        If f = True Then
            TotalData.ViewStyle.Zahyo = MapData.GetPrestigeZahyoMode
            Dim mes As String = ""
            If MapData.EqualizeZahyoMode(TotalData.ViewStyle.Zahyo, mes) = False Then
                ObjectErrorMessage += "地図ファイルの座標系・測地系を統一できません。" + vbCrLf + mes
                f = False
            End If
        End If
        Return f
    End Function
    ''' <summary>
    ''' 旧MDRファイルから読み込み
    ''' </summary>
    ''' <param name="MDRFileName"></param>
    ''' <param name="ObjectErrorMessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetDataFromOldMDR(ByVal MDRFileName As String, ByRef ObjectErrorMessage As String, ByRef ProgressBar As ProgressBar) As Boolean
        MapData = New clsAttrMapData
        Dim MapData2 As New clsMapData
        Dim oldMDRData As clsOldMDRFile.MDR_1275
        ProgressBar.Maximum = 130
        ProgressBar.Visible = True
        Dim f As Boolean = clsOldMDRFile.Get_OldMDRFile(MDRFileName, oldMDRData, MapData2, ProgressBar)
        If f = False Then
            ProgressBar.Visible = False
            Return False
        End If


        ProgressBar.Value = 110
        If oldMDRData.TotalData.LV1.MDRM_Flag = False Then
            If Me.MapData.OpenMapFile(oldMDRData.TotalData.LV1.MapFile, True) = False Then
                ProgressBar.Visible = False
                Return False
            End If
        Else
            Me.MapData.AddExistingMapData(MapData2, oldMDRData.TotalData.LV1.MapFile)
        End If
        ProgressBar.Value = 120
        clsVB6File.CONVERT_From_oldMDRFile(oldMDRData, Me, ObjectErrorMessage)
        ProgressBar.Visible = False

        Return True
    End Function
    ''' <summary>
    ''' MDRZ、MDRファイルを読み込んだ際、地図ファイルのオブジェクト名と一致するかチェックする
    ''' </summary>
    ''' <param name="ObjectErrorMessage"></param>
    ''' <remarks></remarks>
    Private Sub Check_MDRZ_MDR_ObjectExists(ByRef ObjectErrorMessage As String)
        For i As Integer = 0 To Me.TotalData.LV1.Lay_Maxn - 1
            If Me.LayerData(i).Type = enmLayerType.Normal Then
                'オブジェクト名のチェック
                Dim fname As String = Me.LayerData(i).MapFileName
                Dim MP As clsMapData = Me.LayerData(i).MapFileData
                Dim altObjOCde As Integer = -1
                Dim altObjName As String = ""
                For j As Integer = 0 To MP.Map.Kend - 1
                    For k As Integer = 0 To MP.MPObj(j).NumOfNameTime - 1
                        If clsTime.checkDurationIn(MP.MPObj(j).NameTimeSTC(k).SETime, Me.LayerData(i).Time) = True Then
                            altObjOCde = j
                            altObjName = MP.MPObj(j).NameTimeSTC(k).NamesList(0)
                            j = MP.Map.Kend - 1
                            Exit For
                        End If
                    Next
                Next
                For j As Integer = 0 To Me.LayerData(i).atrObject.ObjectNum - 1
                    Dim Obj As strObject_Data_Info = Me.LayerData(i).atrObject.atrObjectData(j)
                    Dim ocode As Integer = Obj.MpObjCode
                    Dim objname As String = Obj.Name
                    Select Case Obj.Objectstructure
                        Case enmKenCodeObjectstructure.MapObj
                            Dim okf As Boolean = False
                            If ocode < MP.Map.Kend Then
                                For k As Integer = 0 To MP.MPObj(ocode).NumOfNameTime - 1
                                    With MP.MPObj(ocode).NameTimeSTC(k)
                                        If Array.IndexOf(.NamesList, objname) <> -1 Then
                                            If clsTime.checkDurationIn(.SETime, Me.LayerData(i).Time) = True Then
                                                okf = True
                                            End If
                                        End If
                                    End With
                                Next
                            End If
                            Dim newcode As Integer
                            If okf = False Then
                                newcode = Me.Get_ObjectCode_from_ObjName(i, objname)
                                If newcode = -1 Then
                                    ObjectErrorMessage += "レイヤ" + Me.LayerData(i).Name + "：" + objname + "は地図ファイル" + fname + "中に見つかりません。" + vbCrLf
                                    ObjectErrorMessage += "この属性データファイルを保存した後に、地図ファイルが修正されたためと考えられます。" + vbCrLf
                                    ObjectErrorMessage += "暫定的に" + altObjName + "に置き換えます。" + vbCrLf
                                    ObjectErrorMessage += "属性データ編集で修正するか、地図データを修正してください。" + vbCrLf + vbCrLf
                                    Me.LayerData(i).atrObject.atrObjectData(j).MpObjCode = altObjOCde
                                Else
                                    Me.LayerData(i).atrObject.atrObjectData(j).MpObjCode = newcode
                                End If
                            Else
                                newcode = ocode
                            End If
                            If newcode <> -1 Then
                                Dim cp As PointF
                                MP.Get_Enable_CenterP(cp, newcode, Me.LayerData(i).Time)
                                Dim ocp As PointF = Obj.CenterPoint
                                With Me.LayerData(i).atrObject.atrObjectData(j)
                                    .CenterPoint = cp
                                    If ocp.Equals(.Label) Then
                                        .Label = cp
                                    End If
                                    If ocp.Equals(.Symbol) Then
                                        .Symbol = cp
                                    End If
                                End With
                            End If
                        Case enmKenCodeObjectstructure.SyntheticObj
                            Dim okf As Boolean = False
                            With Me.LayerData(i).atrObject.MPSyntheticObj(ocode)
                                For k As Integer = 0 To .NumOfObject - 1
                                    Dim ocode2 As Integer = .Objects(k).code
                                    Dim objname2 As String = .Objects(k).Name
                                    If ocode2 < MP.Map.Kend Then
                                        For k2 As Integer = 0 To MP.MPObj(ocode2).NumOfNameTime - 1
                                            With MP.MPObj(ocode2).NameTimeSTC(k2)
                                                If Array.IndexOf(.NamesList, objname2) <> -1 Then
                                                    '合成オブジェクトの構成要素は時間チェックしない
                                                    okf = True
                                                End If
                                            End With
                                        Next
                                    End If
                                    If okf = False Then
                                        '地図ファイルが変わって一致しない場合
                                        Dim newcode1 As Integer = Me.Get_ObjectCode_from_ObjName(Me.LayerData(i).MapFileName, objname2, .SETime.StartTime)
                                        Dim newcode2 As Integer = Me.Get_ObjectCode_from_ObjName(Me.LayerData(i).MapFileName, objname2, .SETime.EndTime)

                                        If newcode1 = -1 And newcode2 = -1 Then
                                            ObjectErrorMessage += "レイヤ" + Me.LayerData(i).Name + "：合成オブジェクト" + objname + "の構成要素" + objname2 + "は地図ファイル" + fname + "中に見つかりません。" + vbCrLf
                                            ObjectErrorMessage += "この属性データファイルを保存した後に、地図ファイルが修正されたためと考えられます。" + vbCrLf
                                            ObjectErrorMessage += "暫定的に" + altObjName + "に置き換えます。" + vbCrLf
                                            ObjectErrorMessage += "時系列集計をやり直すか、地図データを修正してください。" + vbCrLf + vbCrLf
                                            .Objects(k).code = altObjOCde
                                        Else
                                            If newcode2 = -1 Then
                                                .Objects(k).code = newcode1
                                            Else
                                                '終了時に存在するオブジェクトを最優先
                                                .Objects(k).code = newcode2
                                            End If
                                        End If
                                    End If
                                Next
                            End With
                    End Select
                Next
            End If
        Next
    End Sub
    ''' <summary>
    ''' MDRZファイルから読み込み
    ''' </summary>
    ''' <param name="MDRFileName"></param>
    ''' <param name="ObjectErrorMessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetDataFromMDRZ(ByVal MDRFileName As String, ByRef ObjectErrorMessage As String,
                                    ByRef progressbar As ProgressBar) As Boolean

        '一時フォルダを作成
        Dim tmpFolderName As String = clsGeneric.MakeTempFolder_forZip()
        If tmpFolderName = "" Then
            Return False
        End If

        progressbar.Maximum = 5
        progressbar.Value = 1
        progressbar.Visible = True
        System.IO.Compression.ZipFile.ExtractToDirectory(MDRFileName, tmpFolderName)

        Dim FileCount As Integer = System.IO.Directory.GetFiles(tmpFolderName).Length



        'Total_Dataの読み込み
        Dim serializer As New DataContractSerializer(GetType(Total_Data_Info))
        Dim xr As System.Xml.XmlReader = System.Xml.XmlReader.Create(tmpFolderName + "\total.xml")
        Me.TotalData = DirectCast(serializer.ReadObject(xr), Total_Data_Info)
        xr.Close()
        With Me.TotalData.ViewStyle.DataNote
            '2020/6/30のエラーへの対応
            If .MaxWidth = 0 Then
                .Visible = True
                .MaxWidth = 20
                .Font = clsBase.Font
                .Font.Body.Size = 2.5
                .Position = Me.TotalData.ViewStyle.MapLegend.Base.LegendXY(0)
            End If
        End With
        '2020/6/30のエラーへの対応
        For i As Integer = 0 To Me.TotalData.ViewStyle.Screen_Setting.Count - 1
            Dim itm As clsAttrData.strScreen_Setting_Data_Info = Me.TotalData.ViewStyle.Screen_Setting(i)
            With itm.DataNote
                If .MaxWidth = 0 Then
                    .Visible = True
                    .MaxWidth = 20
                    .Font = clsBase.Font
                    .Font.Body.Size = 2.5
                    .Position = Me.TotalData.ViewStyle.MapLegend.Base.LegendXY(0)
                End If
                Me.TotalData.ViewStyle.Screen_Setting(i) = itm
            End With
        Next

        progressbar.Value += 1

        With Me.TotalData.ViewStyle.LatLonLine_Print
            If .OuterPat.Edge_Connect_Pattern.MiterLimitValue = 0 Then
                .OuterPat = clsBase.Line
            End If
            If .Equator.Edge_Connect_Pattern.MiterLimitValue = 0 Then
                .Equator = clsBase.Line
            End If
        End With
        'LayerDataの読み込み
        ReDim Me.LayerData(Me.TotalData.LV1.Lay_Maxn - 1)
        For i As Integer = 0 To Me.TotalData.LV1.Lay_Maxn - 1
            Dim serLayer As New System.Xml.Serialization.XmlSerializer(GetType(strLayerDataInfo))
            Dim fsLayer As New System.IO.FileStream(tmpFolderName + "\Layer" + i.ToString + ".xml", System.IO.FileMode.Open)
            Me.LayerData(i) = CType(serLayer.Deserialize(fsLayer), strLayerDataInfo)
            fsLayer.Close()
        Next
        progressbar.Value += 1

        '地図ファイルの読み込み
        Me.MapData = New clsAttrMapData
        Dim getMapFileList As New List(Of String)
        Dim cngOldFname As New List(Of String)
        Dim cngNewFname As New List(Of String)
        For i As Integer = 0 To Me.TotalData.LV1.Lay_Maxn - 1
            If Me.LayerData(i).Type <> enmLayerType.Trip_Definition Then

                Dim fname As String = Me.LayerData(i).MapFileName
                Dim fnameNoExt As String = System.IO.Path.GetFileNameWithoutExtension(fname)
                If getMapFileList.IndexOf(fname) = -1 Then
                    Dim fnameExt As String = System.IO.Path.GetExtension(fname)
                    Dim fname2 = fname
                    If fnameExt = "" Then
                        fname2 += ".mpfx"
                    End If
                    Dim f As Boolean
                    If System.IO.File.Exists(tmpFolderName + "\" + fname2) = True Then
                        f = Me.MapData.OpenMapFile(tmpFolderName + "\" + fname2, False)
                    Else
                        Dim oriname As String = fname
                        f = Me.MapData.OpenMapFile(fname, False)
                        If f = True Then
                            If oriname <> fname Then
                                cngOldFname.Add(oriname)
                                cngNewFname.Add(fname)
                                '地図ファイルが見つからず、新しく指定した場合
                                Me.LayerData(i).MapFileName = fname
                                For j As Integer = 1 + 1 To Me.TotalData.LV1.Lay_Maxn - 1
                                    If Me.LayerData(j).MapFileName = oriname Then
                                        Me.LayerData(j).MapFileName = fname
                                    End If
                                Next
                                fnameNoExt = System.IO.Path.GetExtension(fname)
                            End If
                        Else
                            progressbar.Visible = False
                            Return False
                        End If
                    End If
                    If f = False Then
                        ObjectErrorMessage = "地図ファイル" + fname + "を読み込めませんでした。" + vbCrLf
                        progressbar.Visible = False
                        Return False
                    End If
                    getMapFileList.Add(fnameNoExt)
                End If
                Me.LayerData(i).Set_MapFileData(Me.MapData.SetMapFile(fnameNoExt))
                Me.LayerData(i).initLayerData_from_mdrz()

            End If
        Next
        Dim mes As String = ""
        If MapData.EqualizeZahyoMode(TotalData.ViewStyle.Zahyo, mes) = False Then
            ObjectErrorMessage += "地図ファイルの座標系・測地系を統一できません。" + vbCrLf + mes
            progressbar.Visible = False
            Return False
        End If
        progressbar.Value += 1

        If checkDummyPointOGChange() = True Then
            ObjectErrorMessage += "地図ファイル中の点オブジェクトグループに変更があります。" + vbCrLf
        End If
        '線種の読み込み
        If System.IO.File.Exists(tmpFolderName + "\LPat.xml") = True Then
            Dim serLPat As New System.Xml.Serialization.XmlSerializer(GetType(strSaveLinePat_Info))
            Dim fsLpat As New System.IO.FileStream(tmpFolderName + "\LPat.xml", System.IO.FileMode.Open)
            Dim saveLPat As strSaveLinePat_Info = CType(serLPat.Deserialize(fsLpat), strSaveLinePat_Info)
            fsLpat.Close()
            With saveLPat
                Dim ct As Integer = 0
                For i As Integer = 0 To .MapNum - 1
                    Dim cngFNum As Integer = cngOldFname.IndexOf(.MapFileName(i))
                    If cngFNum <> -1 Then
                        .MapFileName(i) = cngNewFname(cngFNum)
                    End If
                    If getMapFileList.IndexOf(.MapFileName(i)) = -1 Then
                    Else
                        Dim mpk As Integer = Me.SetMapFile(.MapFileName(i)).Map.LpNum
                        Dim setN As Integer = 0
                        '線種名が地図ファイルと属性データファイルと同じものを探し、セットする
                        For j As Integer = 0 To mpk - 1
                            Dim mapLkind As clsMapData.LineKind_Data = Me.SetMapFile(.MapFileName(i)).LineKind(j)
                            For k As Integer = 0 To .LpatNumByMapfile(i) - 1
                                If .Lpat.Item(ct + k).Name = mapLkind.Name Then
                                    If mapLkind.NumofObjectGroup <> .Lpat.Item(ct + k).NumofObjectGroup Then
                                    Else
                                        Me.SetMapFile(.MapFileName(i)).LineKind(j) = .Lpat.Item(ct + k).Clone
                                        setN += 1
                                        Exit For
                                    End If
                                End If
                            Next
                        Next
                        If setN <> mpk Or setN <> .LpatNumByMapfile(i) Then
                            ObjectErrorMessage = "地図ファイル" + .MapFileName(i) + "の線種が変更されています。" + vbCrLf
                        End If
                        ct += .LpatNumByMapfile(i)
                    End If
                Next
            End With
        End If

        '画像pngを読み込み
        progressbar.Value += 1
        If Me.TotalData.BasePicture.PictureNum <> 0 Then
            For i As Integer = 0 To Me.TotalData.BasePicture.PictureNum - 1
                Dim p As Picture_Property = Me.TotalData.BasePicture.PictureData.Item(i), Picture_Property
                p.SetBitmap(clsGeneric.CreateImage(tmpFolderName + "\picture" + i.ToString + ".png"))
                Me.TotalData.BasePicture.PictureData.Item(i) = p
            Next
        End If

        '作成した一時フォルダを削除
        System.IO.Directory.Delete(tmpFolderName, True)
        progressbar.Visible = False
        Return True
    End Function
    ''' <summary>
    ''' ダミー点オブジェクトの地図ファイル変更関連記号形状チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkDummyPointOGChange() As Boolean
        Dim changef As Boolean = False
        Dim MapFileList() As String = Me.TotalData.ViewStyle.DummyObjectPointMark.Keys.ToArray()
        Dim PointObjG As Dictionary(Of String, String()) = Me.GetAllPointObjectGroup
        For Each pair As KeyValuePair(Of String, String()) In PointObjG
            If pair.Value.Length > 0 Then
                Dim existobk As clsAttrData.strDummyObjectPointMark_Info()
                Dim existobkf As Boolean = False
                If Me.TotalData.ViewStyle.DummyObjectPointMark.ContainsKey(pair.Key) = True Then
                    existobk = Me.TotalData.ViewStyle.DummyObjectPointMark(pair.Key)
                    existobkf = True
                End If
                Me.TotalData.ViewStyle.DummyObjectPointMark.Remove(pair.Key)
                Dim d(pair.Value.Length - 1) As strDummyObjectPointMark_Info
                For i As Integer = 0 To pair.Value.Length - 1
                    Dim f As Boolean = False
                    If existobkf = True Then
                        For j As Integer = 0 To existobk.Length - 1
                            If existobk(j).ObjectKindName = pair.Value(i) Then
                                '既存ファイル中のダミー点オブジェクト記号が存在
                                With d(i)
                                    .ObjectKindName = pair.Value(i)
                                    .Mark = existobk(j).Mark
                                End With
                                f = True
                                Exit For
                            End If
                        Next
                    End If
                    If f = False Then
                        With d(i)
                            .ObjectKindName = pair.Value(i)
                            .Mark = clsBase.Mark
                        End With
                        changef = True
                    End If
                Next
                Me.TotalData.ViewStyle.DummyObjectPointMark.Add(pair.Key, d)
            End If
        Next
        Return changef
    End Function
    ''' <summary>
    ''' CSVファイルから読み込み
    ''' </summary>
    ''' <param name="ObjectErrorMessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetDataFromCSV(ByVal CsvFileName As String, ByRef ObjectErrorMessage As String, ByRef ProgressBar As ProgressBar) As Boolean
        Dim sr As System.IO.StreamReader
        Try
            sr = New System.IO.StreamReader(CsvFileName, System.Text.Encoding.GetEncoding("shift_jis"))
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Dim st As New List(Of String)
        Do Until sr.EndOfStream
            st.Add(sr.ReadLine())
        Loop
        sr.Close()
        Dim STR() As String = st.ToArray
        ObjectErrorMessage = ""
        Dim f As Boolean = ReadAttrDataOneLine(STR, ",", ObjectErrorMessage, ProgressBar)
        If f = True Then
            TotalData.ViewStyle.Zahyo = MapData.GetPrestigeZahyoMode
            Dim mes As String = ""
            If MapData.EqualizeZahyoMode(TotalData.ViewStyle.Zahyo, mes) = False Then
                ObjectErrorMessage += "地図ファイルの座標系・測地系を統一できません。" + vbCrLf + mes
                f = False
            End If
        End If
        Return f
    End Function
    ''' <summary>
    ''' Clipboard,CSVのデータを一行ずつ処理して読み込む
    ''' </summary>
    ''' <param name="STR"></param>
    ''' <param name="Splitter"></param>
    ''' <param name="ObjectErrorMessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ReadAttrDataOneLine(ByVal STR() As String, ByVal Splitter As String, ByRef ObjectErrorMessage As String, ByRef ProgressBar As ProgressBar) As Boolean
        Dim Map_readed As Boolean = False
        Dim TotalMissing As Boolean = False
        Dim LayerReading As strLayerReadingInfo
        Dim LayerTypeTripDefinitionExists As Boolean = False
        Dim lay As Integer = -1
        Dim OK_Flag As Boolean = True
        Dim SetData_Err_Message As String = ""

        ObjectErrorMessage = ""
        Dim LayerError As String = ""
        MapData = New clsAttrMapData
        ProgressBar.Maximum = STR.Length
        ProgressBar.Value = 0
        ProgressBar.Visible = True
        For i As Integer = 0 To STR.Length - 1
            If i Mod 100 = 0 Then
                ProgressBar.Value = i
            End If
            Dim CutS() As String = clsGeneric.String_Cut(STR(i), Splitter)
            If CutS Is Nothing = False Then
                Dim CutN As Integer = CutS.Length
                Select Case UCase(CutS(0))
                    Case ""
                    Case "MAP"
                        If Map_readed = True Then
                            ObjectErrorMessage += "MAPタグは一カ所しかつけることはできません。" + vbCrLf
                            ProgressBar.Visible = False
                            Return False
                        End If
                        For j As Integer = 1 To CutN - 1
                            If CutS(j) = "" Then
                                Exit For
                            Else
                                Dim mrf As Boolean = MapData.OpenMapFile(CutS(j), False)
                                If mrf = True Then
                                    Map_readed = True
                                Else
                                    ProgressBar.Visible = False
                                    Return False
                                End If
                            End If
                        Next
                        If Map_readed = False Then
                            Dim mrf As Boolean = MapData.OpenMapFile("", False)
                            If mrf = True Then
                                Map_readed = True
                            Else
                                ProgressBar.Visible = False
                                Return False
                            End If
                        End If
                        LayerReading.init()
                    Case "COMMENT"
                        If Map_readed = False Then
                            Exit For
                        End If
                        If 2 <= CutN Then
                            If lay = -1 Then
                                TotalData.LV1.Comment += CutS(1) + vbCrLf
                            End If
                            LayerReading.Comment_Temp += CutS(1)
                        End If
                    Case "END"
                        MsgBox("このバージョンでは、DUMMY-END、DUMMY_GROUP-ENDタグのENDタグは使用しません。", MsgBoxStyle.Exclamation)
                        ProgressBar.Visible = False
                        Return False
                    Case "DUMMY"
                        If Map_readed = False Then
                            Exit For
                        End If
                        LayerReading.Dummy_Temp.Add(CutS)
                    Case "DUMMY_GROUP"
                        If Map_readed = False Then
                            Exit For
                        End If
                        LayerReading.Dummy_OBKTemp.Add(CutS)
                    Case "TITLE"
                        If Map_readed = False Then
                            Exit For
                        End If
                        If lay = -1 Then
                            lay = 0
                        End If
                        LayerReading.TTL = CutS.Clone
                    Case "UNIT"
                        If Map_readed = False Then
                            Exit For
                        End If
                        If lay = -1 Then
                            lay = 0
                        End If
                        LayerReading.UNT = CutS.Clone
                    Case "DATA_MISSING"
                        If Map_readed = False Then
                            Exit For
                        End If
                        If lay = -1 Then
                            lay = 0
                        End If
                        ReDim LayerReading.DTMis(CutN - 1)
                        For j As Integer = 0 To CutN - 1
                            If UCase(CutS(j)) = "ON" Then
                                LayerReading.DTMis(j) = True
                            End If
                        Next
                    Case "NOTE"
                        If Map_readed = False Then
                            Exit For
                        End If
                        If lay = -1 Then
                            lay = 0
                        End If
                        LayerReading.Note = CutS.Clone
                    Case "SHAPE"
                        If Map_readed = False Then
                            Exit For
                        End If
                        If 2 <= CutN Then
                            Select Case UCase(CutS(1))
                                Case "POINT"
                                    LayerReading.Shape = enmShape.PointShape
                                Case "LINE"
                                    LayerReading.Shape = enmShape.LineShape
                                Case "POLYGON"
                                    LayerReading.Shape = enmShape.PolygonShape
                                Case Else
                                    LayerError += "SHAPEタグで" + CutS(1) + "は無効です。"
                            End Select
                        End If
                    Case "TYPE"
                        If Map_readed = False Then
                            Exit For
                        End If
                        If 2 <= CutN Then
                            Select Case UCase(CutS(1))
                                Case "NORMAL"
                                    LayerReading.Type = enmLayerType.Normal
                                Case "TRIP_DEFINITION"
                                    If LayerTypeTripDefinitionExists = True Then
                                        ObjectErrorMessage += "移動主体定義レイヤは１つしか設定できません。" + vbCrLf
                                        ProgressBar.Visible = False
                                        Return False
                                    End If
                                    LayerReading.Type = enmLayerType.Trip_Definition
                                    LayerTypeTripDefinitionExists = True
                                Case "TRIP"
                                    LayerReading.Type = enmLayerType.Trip
                                    LayerReading.ReferenceSystem = enmZahyo_System_Info.Zahyo_System_World
                                    If 3 <= CutN Then
                                        Dim Sys As String = CutS(2)
                                        Select Case Sys
                                            Case "日本"
                                                LayerReading.ReferenceSystem = enmZahyo_System_Info.Zahyo_System_tokyo
                                            Case "世界", ""
                                                LayerReading.ReferenceSystem = enmZahyo_System_Info.Zahyo_System_World
                                            Case Else
                                                LayerError += "TYPE TRIPの測地系指定で" + Sys + "は無効です。"
                                        End Select
                                    End If
                                Case "POINT"
                                    LayerReading.Type = enmLayerType.DefPoint
                                    LayerReading.Shape = enmShape.PointShape
                                    LayerReading.ReferenceSystem = enmZahyo_System_Info.Zahyo_System_World
                                    If 3 <= CutN Then
                                        Dim Sys As String = CutS(2)
                                        Select Case Sys
                                            Case "日本"
                                                LayerReading.ReferenceSystem = enmZahyo_System_Info.Zahyo_System_tokyo
                                            Case "世界", ""
                                                LayerReading.ReferenceSystem = enmZahyo_System_Info.Zahyo_System_World
                                            Case Else
                                                LayerError += "TYPE POINTの測地系指定で" + Sys + "は無効です。"
                                        End Select
                                    End If
                                Case "MESH"
                                    LayerReading.Type = enmLayerType.Mesh
                                    If 3 <= CutN Then
                                        Dim MT As String = CutS(2)
                                        Select Case MT
                                            Case "1"
                                                LayerReading.MeshType = enmMesh_Number.mhFirst
                                            Case "2"
                                                LayerReading.MeshType = enmMesh_Number.mhSecond
                                            Case "3", "1km"
                                                LayerReading.MeshType = enmMesh_Number.mhThird
                                            Case "1/2", "4", "500m"
                                                LayerReading.MeshType = enmMesh_Number.mhHalf
                                            Case "1/4", "5", "250m"
                                                LayerReading.MeshType = enmMesh_Number.mhQuarter
                                            Case "1/8"
                                                LayerReading.MeshType = enmMesh_Number.mhOne_Eighth
                                            Case "1/10"
                                                LayerReading.MeshType = enmMesh_Number.mhOne_Tenth
                                            Case Else
                                                ObjectErrorMessage += "メッシュの種類の設定が不正です。" + CutS(2) + vbCrLf
                                                ProgressBar.Visible = False
                                                Return False
                                        End Select
                                        If LayerReading.Shape = enmShape.NotDeffinition Then
                                            LayerReading.Shape = enmShape.PolygonShape
                                        End If
                                        LayerReading.ReferenceSystem = enmZahyo_System_Info.Zahyo_System_World
                                        If 4 <= CutN Then
                                            Dim Sys As String = CutS(3)
                                            Select Case Sys
                                                Case "日本"
                                                    LayerReading.ReferenceSystem = enmZahyo_System_Info.Zahyo_System_tokyo
                                                Case "世界", ""
                                                    LayerReading.ReferenceSystem = enmZahyo_System_Info.Zahyo_System_World
                                                Case Else
                                                    LayerError += "TYPE MESHの測地系指定で" + Sys + "は無効です。"
                                            End Select
                                        End If
                                    End If
                                Case Else
                                    ObjectErrorMessage += "TYPEタグで" + CutS(1) + "は無効です。" + vbCrLf
                                    ProgressBar.Visible = False
                                    Return False
                            End Select
                        End If

                    Case "LAYER"
                        If Map_readed = False Then
                            Exit For
                        End If
                        lay += 1
                        If 1 <= lay Then
                            SetData_Err_Message = ""
                            If LayerReading.TTL Is Nothing Or LayerReading.ObjectDataStac Is Nothing Then
                                MsgBox("レイヤのデータがありません：" + LayerReading.Name)
                                ProgressBar.Visible = False
                                Return False
                            End If
                            OK_Flag = OK_Flag And Set_Data_from_String(LayerReading, TotalMissing, SetData_Err_Message)
                            LayerError += SetData_Err_Message
                            If LayerError <> "" Then
                                ObjectErrorMessage += "エラー／レイヤ:"
                                If LayerReading.Name = "" Then
                                    ObjectErrorMessage += (TotalData.LV1.Lay_Maxn).ToString + vbCrLf
                                Else
                                    ObjectErrorMessage += LayerReading.Name + vbCrLf
                                End If
                                ObjectErrorMessage += LayerError + vbCrLf
                            End If
                        End If
                        LayerError = ""
                        LayerReading.init()
                        LayerReading.Time = clsTime.GetNullYMD
                        If 2 <= CutN Then
                            LayerReading.Name = CutS(1)
                        End If
                        If 3 <= CutN Then
                            Select Case CutS(2).ToUpper
                                Case "TRIP_DEFINITION", "TRIP"
                                    MsgBox("このバージョンでは、TRIP_DEFINITION、TRIPはTYPEタグで使用して下さい。", MsgBoxStyle.Exclamation)
                                    ProgressBar.Visible = False
                                    Return False
                                Case Else
                                    LayerReading.MapFile = CutS(2)
                            End Select
                        End If
                        With LayerReading
                            If .MapFile <> "" Then
                                If Me.MapData.SetMapFile(.MapFile) Is Nothing Then
                                    MsgBox("レイヤ" + .Name + "の地図ファイル" + "を指定してください。")
                                    If Me.MapData.OpenMapFile(.MapFile, False) = False Then
                                        ObjectErrorMessage += "レイヤ" + .Name + "の地図ファイルが指定されていません。" + vbCrLf
                                        ProgressBar.Visible = False
                                        Return False
                                    Else
                                        Me.MapData.SetMapFile(.MapFile)
                                        MsgBox("地図ファイルが見つかりました。")
                                    End If
                                End If
                            End If

                        End With

                    Case "TIME"
                        If Map_readed = False Then
                            Exit For
                        End If
                        If lay = -1 Then
                            lay = 0
                        End If
                        If LayerReading.Time.nullFlag = True Then
                            If 2 <= CutN Then
                                Dim cngTimeF As Boolean = False
                                CutS(1).Replace(",", "")
                                Dim Y As Integer = Val(CutS(1))
                                If DateTime.MinValue.Year > Y Then
                                    Y = DateTime.MinValue.Year
                                    cngTimeF = True
                                End If
                                Dim m As Integer = 1
                                Dim d As Integer = 1
                                If CutN >= 3 Then
                                    m = Val(CutS(2))
                                    If m <= 0 Then
                                        m = 1
                                        cngTimeF = True
                                    ElseIf m > 12 Then
                                        m = 12
                                        cngTimeF = True
                                    End If
                                End If
                                If CutN >= 4 Then
                                    Dim iDaysInMonth As Integer = DateTime.DaysInMonth(Y, m)
                                    d = Val(CutS(3))
                                    If d <= 0 Then
                                        d = 1
                                        cngTimeF = True
                                    ElseIf d > iDaysInMonth Then
                                        d = iDaysInMonth
                                        cngTimeF = True
                                    End If
                                End If
                                If Y <> -1 Then
                                    If clsTime.Check_YMD_Correct(Y, m, d) = False Then
                                        ProgressBar.Visible = False
                                        MsgBox("TIMEタグの時期設定が不正です。", MsgBoxStyle.Exclamation)
                                        Return False
                                    End If
                                    LayerReading.Time = clsTime.GetYMD(Y, m, d)
                                    If cngTimeF = True Then
                                        LayerError += "TIMEタグの時期は修正されました:" + clsTime.YMDtoString(LayerReading.Time) + vbCrLf
                                    End If
                                End If
                            Else
                                LayerError += "TIMEタグに時間設定がありません。" + vbCrLf
                            End If
                        Else
                            LayerError += "1つのレイヤには1箇所しかTIMEタグは使用できません。" + vbCrLf
                        End If
                    Case "MISSING"
                        If Map_readed = False Then
                            Exit For
                        End If
                        If 2 <= CutN Then
                            If UCase(CutS(1)) = "ON" Then
                                TotalMissing = True
                            Else
                                TotalMissing = False
                            End If
                        End If
                    Case Else
                        If lay = -1 And Map_readed = False Then
                            '地図ファイルの指定が無く、titleタグ等もない場合は戻る
                            ProgressBar.Visible = False
                            Return False
                        End If
                        If Me.MapData.SetMapFile(LayerReading.MapFile).Map.Time_Mode = True And
                                    LayerReading.Type <> enmLayerType.Trip_Definition Then
                            If LayerReading.Time.nullFlag = True Then
                                LayerError += "使用する地図ファイルは、時空間モードで作成されています。" & vbCrLf & "レイヤごとにTIMEタグを使用して属性データの時期を指定してください。" + vbCrLf
                                ObjectErrorMessage += LayerError
                                ProgressBar.Visible = False
                                Return False
                            End If
                        End If
                        If Map_readed = True Then
                            If lay = -1 Then lay = 0
                            LayerReading.ObjectDataStac.Add(CutS)
                        Else
                            MsgBox("使用する地図ファイルを指定してください。")
                            If Me.MapData.OpenMapFile("", False) = False Then
                                ProgressBar.Visible = False
                                Return False
                            Else
                                If lay = -1 Then
                                    lay = 0
                                End If
                                LayerReading.ObjectDataStac.Add(CutS)
                            End If
                        End If
                End Select

            End If
        Next
        ProgressBar.Visible = False

        If Map_readed = False Then
            ObjectErrorMessage += "データの先頭にMAPタグが見つかりません。" + vbCrLf
            Return False
        End If
        SetData_Err_Message = ""
        OK_Flag = OK_Flag And Set_Data_from_String(LayerReading, TotalMissing, SetData_Err_Message)
        LayerError += SetData_Err_Message

        If LayerError <> "" Then
            ObjectErrorMessage += "エラー／レイヤ:"
            If LayerReading.Name = "" Then
                ObjectErrorMessage += (TotalData.LV1.Lay_Maxn).ToString + vbCrLf
            Else
                ObjectErrorMessage += LayerReading.Name + vbCrLf
            End If
            ObjectErrorMessage += LayerError + vbCrLf
        End If

        If lay = -1 Then
            Return False
        End If

        If TotalData.LV1.Lay_Maxn = 0 Then
            Return False
        End If

        Dim mfileList() As String = MapData.GetMapFileName
        For i As Integer = 0 To TotalData.LV1.Lay_Maxn - 1
            Dim mpn As Integer = Array.IndexOf(mfileList, LayerData(i).MapFileName.ToUpper)
            If mpn <> -1 Then
                mfileList(mpn) = ""
            End If
        Next
        For i As Integer = 0 To mfileList.Count - 1
            If mfileList(i) <> "" Then
                MapData.RemoveMapData(mfileList(i))
                ObjectErrorMessage += "地図ファイル " + mfileList(i) + " はレイヤで使われていないので読み込みませんでした。" + vbCrLf + vbCrLf
            End If
        Next

        If OK_Flag = True Then
            Dim Trip_err_Message As String = ""
            If Check_Trip_Data(Trip_err_Message) = False Then
                ObjectErrorMessage += "移動データに問題があります。" + vbCrLf + vbCrLf + Trip_err_Message + vbCrLf + vbCrLf
                OK_Flag = False
            End If

        End If


        Return OK_Flag

    End Function
    ''' <summary>
    ''' オブジェクトからオブジェクトコードを返す。見つからない場合は-1を返す。
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="ObjName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_ObjectCode_from_ObjName(ByVal Layernum As Integer, ByVal ObjName As String) As Integer
        Dim MapFileObjectNameSearch As clsObjectNameSearch = MapData.SetObject_Name_Search(Me.LayerData(Layernum).MapFileName)
        Return MapFileObjectNameSearch.Get_KenToCode(ObjName, Me.LayerData(Layernum).Time)
    End Function
    ''' <summary>
    ''' オブジェクトからオブジェクトコードを返す。見つからない場合は-1を返す。
    ''' </summary>
    ''' <param name="MapFile">地図ファイル名</param>
    ''' <param name="ObjName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_ObjectCode_from_ObjName(ByVal MapFile As String, ByVal ObjName As String, ByVal Time As strYMD) As Integer
        Dim MapFileObjectNameSearch As clsObjectNameSearch = MapData.SetObject_Name_Search(MapFile)
        Return MapFileObjectNameSearch.Get_KenToCode(ObjName, Time)

    End Function
    ''' <summary>
    ''' 文字列からデータに変換
    ''' </summary>
    ''' <param name="LayerReading"></param>
    ''' <param name="TotalMissing"></param>
    ''' <remarks></remarks>
    Private Function Set_Data_from_String(ByRef LayerReading As strLayerReadingInfo, ByVal TotalMissing As Boolean,
                                     ByRef E_Mes As String) As Boolean

        Dim layn As Integer = TotalData.LV1.Lay_Maxn

        Dim MapFileData As clsMapData = MapData.SetMapFile(LayerReading.MapFile)
        Dim MapFileObjectNameSearch As clsObjectNameSearch = MapData.SetObject_Name_Search(LayerReading.MapFile)
        Dim Object_Use_Check(MapFileData.Map.Kend - 1) As Boolean
        Dim MxData As Integer
        Dim No_Object_Name As New List(Of String)
        Dim Over_Lap_Object As New List(Of String)

        With LayerReading
            MxData = 0
            If .TTL Is Nothing = False Then
                MxData = Math.Max(.TTL.Length, MxData)
            End If
            If .UNT Is Nothing = False Then
                MxData = Math.Max(.UNT.Length, MxData)
            End If
            If .DTMis Is Nothing = False Then
                MxData = Math.Max(MxData, .DTMis.Length)
            End If
            If .Note Is Nothing = False Then
                MxData = Math.Max(MxData, .Note.Length)
            End If
            For i As Integer = 0 To .ObjectDataStac.Count - 1
                MxData = Math.Max(MxData, .ObjectDataStac.Item(i).Length)
            Next
            ReDim Preserve .TTL(MxData - 1), .UNT(MxData - 1), .Note(MxData - 1)
        End With
        If MxData = 0 Then
            E_Mes = "タグ・オブジェクトが存在しません。" + vbCrLf
            Return False
        End If
        Dim DN_Str(MxData - 2, LayerReading.ObjectDataStac.Count - 1) As String
        Dim Get_Obj() As strObject_Data_Info
        Dim GetTripObj() As strTripObjData_Info
        Dim GetTripDefinitionName() As String
        Select Case LayerReading.Type
            Case enmLayerType.Trip_Definition
                ReDim GetTripDefinitionName(LayerReading.ObjectDataStac.Count - 1)
            Case enmLayerType.Trip
                ReDim GetTripObj(LayerReading.ObjectDataStac.Count - 1)
            Case Else
                ReDim Get_Obj(LayerReading.ObjectDataStac.Count - 1)
        End Select

        Dim Object_num As Integer = 0
        Dim MeshCodeLen As Integer = 0
        If LayerReading.Type = enmLayerType.Mesh Then
            MeshCodeLen = clsGeneric.getMeshCodeLength(LayerReading.MeshType)
        End If
        For i As Integer = 0 To LayerReading.ObjectDataStac.Count - 1
            Dim CutS() As String = LayerReading.ObjectDataStac.Item(i)
            Dim OBName As String = CutS(0)
            Dim code As Integer
            Select Case LayerReading.Type
                Case enmLayerType.Normal
                    code = MapFileObjectNameSearch.Get_KenToCode(OBName, LayerReading.Time)
                    If code = -1 Then
                        No_Object_Name.Add(OBName)
                    Else
                        If Object_Use_Check(code) = True Then
                            '既にレイヤ内でオブジェクトが使用されている
                            Over_Lap_Object.Add(OBName)
                            code = -1
                        Else
                            Object_Use_Check(code) = True
                        End If
                    End If
                Case enmLayerType.Mesh
                    If Len(OBName) <> MeshCodeLen Then
                        No_Object_Name.Add(OBName)
                        code = -1
                    Else
                        code = -2 ' Val(OBName)10桁以上になるとintegerに入らない
                    End If
                Case enmLayerType.Trip
                    With GetTripObj(Object_num)
                        .TripPersonName = OBName
                    End With
                    code = 0
                Case enmLayerType.Trip_Definition
                    GetTripDefinitionName(Object_num) = OBName
                    code = 0
                Case Else
                    code = 0
            End Select
            If code <> -1 Then
                If LayerReading.Type = enmLayerType.Mesh Or LayerReading.Type = enmLayerType.Normal Or LayerReading.Type = enmLayerType.DefPoint Then
                    With Get_Obj(Object_num)
                        .MpObjCode = code
                        .Name = OBName
                        If LayerReading.Type = enmLayerType.Normal Then
                            MapFileData.Get_Enable_CenterP(.CenterPoint, code, LayerReading.Time)
                            .Symbol = .CenterPoint
                            .Label = .Symbol
                            .Visible = True
                        End If
                    End With
                End If
                'データ２次元配列に設定
                For j As Integer = 1 To MxData - 1
                    Dim T As String = ""
                    If j < CutS.Length Then
                        T = CutS(j)
                    End If
                    DN_Str(j - 1, Object_num) = T
                Next
                Object_num += 1
            End If
        Next
        If MapFileData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
            Select Case LayerReading.Type
                Case enmLayerType.Mesh
                    E_Mes = "メッシュレイヤの場合は、緯度経度情報つきの地図ファイルを使用して下さい。" + vbCrLf
                    Return False
                Case enmLayerType.DefPoint
                    E_Mes = "地点定義レイヤの場合は、緯度経度情報つきの地図ファイルを使用して下さい。" + vbCrLf
                    Return False
            End Select
        End If
        If 0 < No_Object_Name.Count Then
            Select Case LayerReading.Type
                Case enmLayerType.Mesh
                    E_Mes += "以下のメッシュコードは指定のメッシュと異なります。" + vbCrLf
                Case enmLayerType.Normal
                    E_Mes += "以下のオブジェクトは地図ファイルに含まれていません。" + vbCrLf
            End Select
            For i As Integer = 0 To Math.Min(50, No_Object_Name.Count) - 1
                E_Mes += No_Object_Name.Item(i) + vbCrLf
            Next
            If 50 < No_Object_Name.Count Then
                E_Mes += "ほか" & No_Object_Name.Count - 50 & "オブジェクト" + vbCrLf

            End If
            E_Mes += vbCrLf
        End If
        If 0 < Over_Lap_Object.Count Then
            E_Mes += "以下のオブジェクトは同一レイヤ内に複数含まれていました。" _
                + "最初に出てきたものが採用されています。" + vbCrLf
            E_Mes += String.Join(vbCrLf, Over_Lap_Object.ToArray)
        End If

        If Object_num = 0 Then
            E_Mes = "有効なオブジェクトがありません。"
            Return False
        End If


        With LayerReading
            Select Case LayerReading.Type
                Case enmLayerType.Trip
                    Call Add_one_Layer(.Name, .MapFile, .Time, .ReferenceSystem, .Comment_Temp, Object_num, GetTripObj)
                Case enmLayerType.Trip_Definition
                    Call Add_one_Layer(.Name, .Comment_Temp, Object_num, GetTripDefinitionName)
                Case Else
                    Call Add_one_Layer(.Name, .Type, .MeshType, .Shape, .MapFile, .Time, .ReferenceSystem, .Comment_Temp, Object_num, Get_Obj)
            End Select
            '実際に可能なレイヤ形状と指定形状をチェック
            Dim Laye_Shape_Emes As String = Check_LayerShape()
            If Laye_Shape_Emes <> "" Then
                E_Mes += Laye_Shape_Emes + vbCrLf
            End If
        End With
        If LayerReading.DTMis Is Nothing Then
            With LayerReading
                ReDim .DTMis(MxData - 1)
                clsGeneric.FillArray(.DTMis, TotalMissing)
                For i As Integer = 0 To MxData - 1
                    .DTMis(i) = TotalMissing
                Next
            End With
        End If
        For i As Integer = 0 To MxData - 2
            With LayerReading
                .TTL(i) = .TTL(i + 1)
                .UNT(i) = .UNT(i + 1)
                .DTMis(i) = .DTMis(i + 1)
                .Note(i) = .Note(i + 1)
            End With
        Next
        With LayerReading
            Dim DummmyObjNames As New List(Of String)

            With .Dummy_Temp
                For i As Integer = 0 To .Count - 1
                    Dim DCS() As String = .Item(i)
                    For j As Integer = 1 To DCS.Length - 1
                        If DCS(j) <> "" Then
                            DummmyObjNames.Add(Trim(DCS(j)))
                        End If
                    Next
                Next
            End With
            Dim DummmyObjNamesList() As String = DummmyObjNames.ToArray

            Dim DummmyObjGroupNames As New List(Of String)
            With .Dummy_OBKTemp
                For i As Integer = 0 To .Count - 1
                    Dim DCS() As String = .Item(i)
                    For j As Integer = 1 To DCS.Length - 1
                        If DCS(j) <> "" Then
                            DummmyObjGroupNames.Add(Trim(DCS(j)))
                        End If
                    Next
                Next
            End With
            Dim DummmyObjGroupNamesList() As String = DummmyObjGroupNames.ToArray

            Dim NowLay As Integer = TotalData.LV1.Lay_Maxn - 1
            Dim Emes As String = Set_Dummy_and_Group(NowLay, DummmyObjNamesList, DummmyObjGroupNamesList)
            If Emes <> "" Then
                E_Mes += "ダミーオブジェクト指定で地図ファイルに含まれないものがあります。" + vbCrLf + Emes
            End If
            Dim f As Boolean = Set_STRData_To_Cell(NowLay, MxData - 1, .TTL, .UNT, .DTMis, .Note, DN_Str, E_Mes)
            Return f
        End With
    End Function
    ''' <summary>
    ''' レイヤ単位で文字列配列に入れたデータを設定する
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <param name="TTL"></param>
    ''' <param name="UNT"></param>
    ''' <param name="DTMissing"></param>
    ''' <param name="DN_Str"></param>
    ''' <remarks></remarks>
    Public Function Set_STRData_To_Cell(ByVal Layernum As Integer, ByVal DataNum As Integer, ByRef TTL() As String,
                                   ByRef UNT() As String, ByRef DTMissing() As Boolean, ByRef Note() As String,
                                   ByRef DN_Str(,) As String, ByRef ErrorMes As String) As Boolean
        Dim ObjNum As Integer = LayerData(Layernum).atrObject.ObjectNum
        'Title行から、URLデータかどうかを判別
        Dim DataItemNotF(DataNum - 1) As Boolean
        Dim URLData(DataNum - 1) As Integer
        Dim URL_NameData(DataNum - 1) As Integer
        Dim URLDataNum As Integer = 0
        Dim URL_NameDataNum As Integer = 0
        Dim LatPosition As Integer = -1
        Dim LonPosition As Integer = -1

        Dim DepartureGet As Integer = -1
        Dim ArrivalGet As Integer = -1
        Dim PlaceGet As Integer = -1
        For i As Integer = 0 To DataNum - 1
            Dim Uttl As String = UCase(TTL(i))
            If Uttl = "URL" Then
                DataItemNotF(i) = True
                URLData(URLDataNum) = i
                URLDataNum += 1
            ElseIf Uttl = "URL_NAME" Then
                DataItemNotF(i) = True
                URL_NameData(URL_NameDataNum) = i
                URL_NameDataNum += 1
            Else
                Select Case LayerData(Layernum).Type
                    Case enmLayerType.Trip
                        '移動データのデータは通常のデータに入れない
                        Select Case Uttl
                            Case "LAT"
                                If LatPosition = -1 Then
                                    LatPosition = i
                                End If
                                DataItemNotF(i) = True
                            Case "LON"
                                If LonPosition = -1 Then
                                    LonPosition = i
                                End If
                                DataItemNotF(i) = True
                            Case "PLACE"
                                If PlaceGet = -1 Then
                                    PlaceGet = i
                                End If
                                DataItemNotF(i) = True
                            Case "ARRIVAL"
                                If ArrivalGet = -1 Then
                                    ArrivalGet = i
                                End If
                                DataItemNotF(i) = True
                            Case "DEPARTURE"
                                If DepartureGet = -1 Then
                                    DepartureGet = i
                                End If
                                DataItemNotF(i) = True
                        End Select
                    Case enmLayerType.DefPoint
                        '地点定義レイヤ
                        If Uttl = "LAT" Then
                            If LatPosition = -1 Then
                                LatPosition = i
                            End If
                            DataItemNotF(i) = True
                        ElseIf Uttl = "LON" Then
                            If LonPosition = -1 Then
                                LonPosition = i
                            End If
                            DataItemNotF(i) = True
                        End If
                End Select
            End If
        Next

        'リンク
        If LayerData(Layernum).Type <> enmLayerType.Trip And LayerData(Layernum).Type <> enmLayerType.Trip_Definition Then
            For i As Integer = 0 To ObjNum - 1
                With LayerData(Layernum).atrObject.atrObjectData(i)
                    .HyperLinkNum = 0
                    If 0 < URL_NameDataNum Then
                        ReDim .HyperLink(URL_NameDataNum - 1)
                        For j As Integer = 0 To URLDataNum - 1
                            Dim T As String = DN_Str(URLData(j), i)
                            If T <> "" Then
                                .HyperLink(.HyperLinkNum).Address = T
                                .HyperLink(.HyperLinkNum).Name = DN_Str(URL_NameData(j), i)
                                .HyperLinkNum += 1
                            End If
                        Next
                    End If
                    ReDim Preserve .HyperLink(Math.Max(0, .HyperLinkNum - 1))
                End With
            Next
        End If

        '移動データの処理
        With Me.LayerData(Layernum)
            If .Type = enmLayerType.Trip Then
                Dim posTagF As Boolean = False
                If LatPosition <> -1 And LonPosition <> -1 Then
                    LayerData(Layernum).TripType = enmTripPositionType.LatLon
                    posTagF = True
                ElseIf PlaceGet <> -1 Then
                    LayerData(Layernum).TripType = enmTripPositionType.ObjectSet
                    posTagF = True
                Else
                    ErrorMes += "移動データレイヤの位置指定のタグ（LAT,LON,PLACE）が指定されていません。" + vbCrLf
                End If
                If ArrivalGet = -1 Then
                    ErrorMes += "移動データレイヤの到着時間タグ（ARRIVAL）が指定されていません。" + vbCrLf
                End If
                If DepartureGet = -1 Then
                    ErrorMes += "移動データレイヤの出発時間タグ（DEPARTURE）が指定されていません。" + vbCrLf
                End If
                If ArrivalGet = -1 Or DepartureGet = -1 Or posTagF = False Then
                    Return False
                End If

                For j As Integer = 0 To .atrObject.ObjectNum - 1
                    With .atrObject.TripObjData(j)
                        If LayerData(Layernum).TripType = enmTripPositionType.ObjectSet Then
                            .PositionObjName = DN_Str(PlaceGet, j)
                        Else
                            .PositionObjName = ""
                            Dim lonV As Single = Val(DN_Str(LonPosition, j))
                            Dim latV As Single = Val(DN_Str(LatPosition, j))
                            .LatLon = New strLatLon(latV, lonV)
                        End If
                        .PositionObjName += vbTab + Trim(DN_Str(ArrivalGet, j)) + vbTab + Trim(DN_Str(DepartureGet, j)) '後でCheck_Trip_Dataから中身を調べる
                    End With
                Next
            End If
        End With


        'メッシュレイヤの処理
        With Me.LayerData(Layernum)
            If .Type = enmLayerType.Mesh Then
                For j As Integer = 0 To .atrObject.ObjectNum - 1
                    With .atrObject.atrObjectData(j)
                        Dim RPoint(3) As PointF
                        Dim RectLatLon As strLatLonBox
                        Dim Rect As RectangleF
                        spatial.Get_MeshCode_Rectangle(.Name, Me.LayerData(Layernum).MeshType, Me.LayerData(Layernum).ReferenceSystem, Me.SetMapFile("").Map.Zahyo, RectLatLon, Rect, RPoint)
                        .CenterPoint = spatial.Get_Converted_XY(RectLatLon.CenterPoint.toPointF, Me.SetMapFile("").Map.Zahyo)
                        .Symbol = .CenterPoint
                        .Label = .CenterPoint
                        .MeshRect = Rect
                        .MeshPoint = RPoint.Clone
                        .Visible = True
                    End With
                Next
            End If
        End With

        '地点定義レイヤの処理
        With Me.LayerData(Layernum)
            If .Type = enmLayerType.DefPoint Then

                If LonPosition = -1 Then
                    ErrorMes += "地点定義レイヤの経度（LONタグ）が指定されていません。" + vbCrLf
                End If
                If LatPosition = -1 Then
                    ErrorMes += "地点定義レイヤの経度（LATタグ）が指定されていません。" + vbCrLf
                End If
                If LonPosition = -1 Or LatPosition = -1 Then
                    Return False
                End If
                Dim valE As Boolean = False
                For j As Integer = 0 To .atrObject.ObjectNum - 1
                    With .atrObject.atrObjectData(j)
                        Dim lonV As Single = Val(DN_Str(LonPosition, j))
                        Dim latV As Single = Val(DN_Str(LatPosition, j))
                        If Math.Abs(latV) >= 90 Then
                            ErrorMes += "地点定義レイヤの緯度で90度を超えている地点があります。(" + .Name + ")" + vbCrLf
                            valE = True
                        End If
                        .defPoint = New strLatLon(latV, lonV)
                        Dim conp As strLatLon = spatial.ConvertRefSystemLatLon(.defPoint, Me.LayerData(Layernum).ReferenceSystem, Me.SetMapFile("").Map.Zahyo.System)
                        .CenterPoint = spatial.Get_Converted_XY(conp.toPointF, Me.SetMapFile("").Map.Zahyo)
                        .Symbol = .CenterPoint
                        .Label = .CenterPoint
                        .Visible = True
                    End With
                Next
                If valE = True Then
                    Return False
                End If
            End If
        End With

        'データ項目の追加
        Dim addErMes As New System.Text.StringBuilder()

        Dim Data_Val_STR(ObjNum - 1) As String
        Dim emesnum = 0
        For i As Integer = 0 To DataNum - 1
            If DataItemNotF(i) = False Then
                For j As Integer = 0 To ObjNum - 1
                    Data_Val_STR(j) = DN_Str(i, j)
                Next
                Dim Dtype As enmAttDataType = clsGeneric.getAttDataType_From_TitleUnit(TTL(i), UNT(i))
                If Dtype = enmAttDataType.Normal Then
                    For j As Integer = 0 To ObjNum - 1
                        If Data_Val_STR(j) <> "" Then
                            Data_Val_STR(j) = Data_Val_STR(j).Replace(",", "")
                        End If
                        Dim sujif As Boolean = clsGeneric.Check_Suji(Data_Val_STR(j))
                        If sujif = False Then
                            If Data_Val_STR(j) = "" Then
                                If DTMissing(i) = False Then
                                    If TTL(i) <> "" Or UNT(i) <> "" Then
                                        If emesnum < 50 Then
                                            addErMes.Append("欠損値設定でないデータ項目に空白データがあります。0に設定されます。(" + TTL(i) + ")" + vbCrLf)
                                        End If
                                        emesnum += 1
                                        Data_Val_STR(j) = "0"
                                    End If
                                End If
                            Else
                                If emesnum < 50 Then
                                    addErMes.Append("数字以外のデータがあります。欠損値に設定されます。(" + TTL(i) + ":" + Data_Val_STR(j) + ")" + vbCrLf)
                                End If
                                emesnum += 1
                                DTMissing(i) = True
                                Data_Val_STR(j) = ""
                            End If
                        End If
                    Next
                End If
                If Add_One_Data_Value(Layernum, TTL(i), UNT(i), Note(i), Data_Val_STR, DTMissing(i)) = False Then
                    If TTL(i) <> "" Then
                        addErMes.Append(TTL(i) & "はデータ値がないため取得できませんでした。" + vbCrLf)
                    End If
                End If
            End If

        Next
        If addErMes.Length <> 0 Then
            ErrorMes += addErMes.ToString
        End If
        If Me.Get_DataNum(Layernum) = 0 And Me.LayerData(Layernum).Type <> enmLayerType.Trip Then
            ReDim Data_Val_STR(ObjNum - 1)
            '属性が無い場合は自動で1つ追加する
            Me.Add_One_Data_Value(Layernum, "地図表示", "CAT", "", Data_Val_STR, False)
            Select Case Me.LayerData(Layernum).Shape
                Case enmShape.PointShape
                    Me.LayerData(Layernum).atrData.Data(0).SoloModeViewSettings.Class_Div(0).PaintColor = New colorARGB(255, 255, 255, 191)
                Case enmShape.PolygonShape
                    Me.LayerData(Layernum).atrData.Data(0).SoloModeViewSettings.Class_Div(0).PaintColor = New colorARGB(Color.White)
            End Select
            ErrorMes += "有効なデータ項目がなかったため、「地図表示」データ項目を自動生成しました。"
        End If
        Return True
    End Function
    ''' <summary>
    ''' データ項目の追加
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="TTL"></param>
    ''' <param name="UNT"></param>
    ''' <param name="Dn_Val_str"></param>
    ''' <param name="Missing_F"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add_One_Data_Value(ByVal Layernum As Integer, ByVal TTL As String, ByVal UNT As String, ByVal Note As String,
            ByRef Dn_Val_str() As String, ByVal Missing_F As Boolean) As Boolean

        Dim ObjNum As Integer = LayerData(Layernum).atrObject.ObjectNum
        If (TTL = "" And UNT = "") Or (UCase(UNT) <> "STR" And UCase(UNT) <> "CAT") Then
            Dim f As Boolean = False
            For i As Integer = 0 To ObjNum - 1
                If Dn_Val_str(i) <> "" Then
                    f = True
                    Exit For
                End If
            Next
            If f = False Then
                Return False
            End If
        End If
        Dim DataNum As Integer = Me.Get_DataNum(Layernum)
        Dim Dtype As enmAttDataType = clsGeneric.getAttDataType_From_TitleUnit(TTL, UNT)
        With LayerData(Layernum).atrData
            ReDim Preserve .Data(DataNum)
            With .Data(DataNum)
                .MissingF = Missing_F
                .Unit = UNT
                .Title = TTL
                .Note = Note
                .DataType = Dtype
                .SoloModeViewSettings.Div_Num = 0
            End With
            If Dtype = enmAttDataType.Normal Then
                Dim n As Integer = Dn_Val_str.Length
                ReDim .Data(DataNum).Value(n - 1)
                For i As Integer = 0 To Dn_Val_str.Length - 1
                    .Data(DataNum).Value(i) = Strings.Replace(Dn_Val_str(i), ",", "")
                    .Data(DataNum).Value(i) = Strings.Replace(Dn_Val_str(i), " ", "")
                Next
            Else
                .Data(DataNum).Value = Dn_Val_str.Clone
            End If
        End With

        Call CulcuOne(Layernum, DataNum) 'データの統計情報取得
        Call SetIniHanrei(Layernum, DataNum)
        LayerData(Layernum).atrData.Count += 1

        Return True
    End Function
    ''' <summary>
    ''' 移動主体定義レイヤの主体名を検索用クラスに入れて返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_TripSubjectSoringClass() As clsSortingSearch
        Dim Trip_Defi_Layer As Integer = Me.Get_Trip_Definition_Layer_Number
        Dim triDefiName As New clsSortingSearch(VariantType.String)
        For i As Integer = 0 To Me.LayerData(Trip_Defi_Layer).atrObject.ObjectNum - 1
            triDefiName.Add(Me.LayerData(Trip_Defi_Layer).atrObject.atrObjectData(i).Name)
        Next
        triDefiName.AddEnd()
        Return triDefiName
    End Function
    ''' <summary>
    ''' 移動データレイヤのデータ設定
    ''' </summary>
    ''' <param name="E_Message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Trip_Data(ByRef E_Message As String) As Boolean


        Dim Check_Data As Boolean = True
        Dim Trip_Defi_Layer As Integer = Me.Get_Trip_Definition_Layer_Number
        Dim f As Boolean = False
        For i As Integer = 0 To TotalData.LV1.Lay_Maxn - 1
            If Me.LayerData(i).Type = enmLayerType.Trip Then
                f = True
            End If
        Next
        Dim triDefiName As clsSortingSearch
        If Trip_Defi_Layer <> -1 And f = False Then
            E_Message += "移動データレイヤが作成されていません。" + vbCrLf
            Check_Data = False
        Else
            If Trip_Defi_Layer <> -1 Then
                triDefiName = Me.Get_TripSubjectSoringClass()
            End If
        End If
        For i As Integer = 0 To TotalData.LV1.Lay_Maxn - 1
            If Me.LayerData(i).Type = enmLayerType.Trip Then
                If LayerData(i).MapFileData.Map.Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido And LayerData(i).TripType = enmTripPositionType.LatLon Then
                    E_Message += "移動レイヤがの位置がLAT,LON指定の場合は、緯度経度の地図ファイルを指定して下さい。" + vbCrLf
                    Check_Data = False
                End If
                'チェック
                Dim obn As Integer = Me.LayerData(i).atrObject.ObjectNum
                Dim stf As Boolean = False, etf As Boolean = False
                Dim st As DateTime, et As DateTime
                For k As Integer = 0 To obn - 1
                    With Me.LayerData(i).atrObject.TripObjData(k)

                        Dim TripData() As String = Split(.PositionObjName, vbTab)
                        Dim TripObjName As String = .TripPersonName
                        .PositionObjName = TripData(0)
                        Select Case Len(TripData(1))
                            Case 12
                                TripData(1) += "00"
                            Case 14
                            Case Else
                                E_Message += TripObjName + TripData(2) + ":出発時間に問題があります。" + vbCrLf
                        End Select
                        Select Case Len(TripData(2))
                            Case 12
                                TripData(2) += "00"
                            Case 14
                            Case Else
                                E_Message += TripObjName + TripData(1) + ":到着時間に問題があります。" + vbCrLf
                        End Select

                        Dim n As Integer
                        If Trip_Defi_Layer = -1 Then
                            n = -1
                        Else
                            n = triDefiName.SearchData_One(TripObjName)
                            If n = -1 Then
                                E_Message += TripObjName + " は移動主体定義レイヤに含まれていません。" + vbCrLf
                                Check_Data = False
                            End If
                        End If
                        .TripPersonCode = n

                        Select Case LayerData(i).TripType
                            Case enmTripPositionType.ObjectSet
                                .PositionObjCode = Me.LayerData(i).ObjectNameSearch(.PositionObjName, Me.LayerData(i).Time)
                                If .PositionObjCode = -1 Then
                                    E_Message += .PositionObjName + "は地図データのオブジェクトに存在しません。" + vbCrLf
                                    Check_Data = False
                                End If
                            Case enmTripPositionType.LatLon
                                If Math.Abs(.LatLon.Latitude) > 90 Then
                                    E_Message += .LatLon.Latitude.ToString + ":緯度の値が90°を超えています。" + vbCrLf
                                    Check_Data = False
                                End If
                        End Select

                        If Len(TripData(1)) = 14 Then
                            Dim ArTime As Long = CLng(TripData(1))
                            If clsGeneric.Convert_Long_Time_to_DateTime(ArTime, .ArrivalTime) = False Then
                                .PositionObjCode = -1
                                E_Message += TripObjName + TripData(1) + ":到着時間に問題があります。" + vbCrLf
                                Check_Data = False
                            Else
                                If stf = False Then
                                    st = .ArrivalTime
                                    stf = True
                                Else
                                    If .ArrivalTime < st Then
                                        st = .ArrivalTime
                                    End If
                                End If
                            End If

                        End If
                        If Len(TripData(2)) = 14 Then
                            Dim DepaTime As Long = CLng(TripData(2))
                            If clsGeneric.Convert_Long_Time_to_DateTime(DepaTime, .DepartureTime) = False Then
                                .PositionObjCode = -1
                                E_Message += TripObjName + TripData(2) + ":出発時間に問題があります。" + vbCrLf
                                Check_Data = False
                            Else
                                If etf = False Then
                                    et = .DepartureTime
                                    etf = True
                                Else
                                    If et < .DepartureTime Then
                                        et = .DepartureTime
                                    End If
                                End If
                            End If
                        End If
                        If .PositionObjCode <> -1 Then
                            If .ArrivalTime > .DepartureTime Then
                                E_Message += TripObjName + TripData(1) + "/" + TripData(2) + ":は到着時間が出発時間よりも遅くなっています。" + vbCrLf
                                Check_Data = False
                            End If
                        End If
                    End With
                Next
                If Check_Data = False Then
                    Return False
                End If
                Me.LayerData(i).TripTimeSpan.StartTime = st
                Me.LayerData(i).TripTimeSpan.EndTime = et



                Dim Sorted_Trip(obn) As Integer
                Dim O_sort As New clsSortingSearch(VariantType.String)
                Dim DataCount As Integer = Me.LayerData(i).atrData.Count
                If DataCount > 0 Then
                    Dim Data_cell_Stac(DataCount - 1, obn - 1) As String
                    Dim KenCode_Stac(obn - 1) As strTripObjData_Info
                    '移動オブジェクトの並び替え（名前、到着時間順）
                    For j As Integer = 0 To obn - 1
                        O_sort.Add(Me.LayerData(i).atrObject.TripObjData(j).TripPersonName)
                        KenCode_Stac(j) = Me.LayerData(i).atrObject.TripObjData(j)
                        For j2 As Integer = 0 To DataCount - 1
                            Data_cell_Stac(j2, j) = Me.Get_Data_Value(i, j2, j, "")
                        Next
                    Next
                    O_sort.AddEnd()
                    Dim ct = 0
                    Do
                        Dim j As Integer = ct
                        If j < obn - 1 Then
                            Do While O_sort.DataPositionValue_string(j) = O_sort.DataPositionValue_string(j + 1)
                                j += 1
                                If j = obn - 1 Then
                                    Exit Do
                                End If
                            Loop
                        End If

                        Dim T_sort As New clsSortingSearch(VariantType.Double)
                        Dim n As Integer = j - ct + 1
                        For j2 As Integer = 0 To n - 1
                            With Me.LayerData(i).atrObject.TripObjData(O_sort.DataPosition(j2 + ct))
                                If .PositionObjCode <> -1 Then
                                    T_sort.Add(CDbl(clsGeneric.Convert_DateTime_to_Long_Time(.ArrivalTime)))
                                Else
                                    T_sort.Add(CDbl(-1))
                                End If
                            End With
                        Next
                        T_sort.AddEnd()
                        For j2 As Integer = 0 To n - 1
                            Sorted_Trip(j2 + ct) = O_sort.DataPosition(ct + T_sort.DataPosition(j2))
                        Next
                        ct = j + 1
                    Loop While ct < obn
                    With Me.LayerData(i)
                        For j As Integer = 0 To obn - 1
                            .atrObject.TripObjData(j) = KenCode_Stac(Sorted_Trip(j))
                            For j2 = 0 To DataCount - 1
                                .atrData.Data(j2).Value(j) = Data_cell_Stac(j2, Sorted_Trip(j))
                            Next
                        Next
                    End With
                End If
                With Me.LayerData(i)
                    .LayerModeViewSettings.TripMode.initDataSet(.TripTimeSpan.StartTime, .TripTimeSpan.EndTime)
                End With
            End If
        Next

        Return Check_Data
    End Function
    ''' <summary>
    ''' 移動主体レイヤ(移動レイヤ)の全主体名と数を取得
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="Sub_Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Trip_Subjects_Name(ByVal LayerNum As Integer, ByRef Sub_Name() As String) As Integer
        '移動主体レイヤの全主体名と数を取得

        Dim obn As Integer = Me.LayerData(LayerNum).atrObject.ObjectNum
        Dim Name1 As New clsSortingSearch(VariantType.String)

        For i As Integer = 0 To obn - 1
            Name1.Add(Me.Get_KenObjName(LayerNum, i))
        Next
        Name1.AddEnd()
        Dim n As Integer = Name1.getEachValue_Alley(Sub_Name)
        Return n
    End Function

    Private Function Get_Att_Missing_Num(ByVal LayerNum As Integer, ByVal DataNum As Integer) As Integer
        With LayerData(LayerNum).atrData.Data(DataNum)
            If .MissingF = False Then
                Return 0
            Else
                Return clsGeneric.Count_Specified_Value_Array(.Value, "")
            End If
        End With
    End Function


    ''' <summary>
    ''' レイヤ・データ・オブジェクトを指定して値を取得
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <param name="Obj"></param>
    ''' <param name="Missing_word">欠損値だった場合に返す文字列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Data_Value(ByVal Layernum As Integer, ByVal DataNum As Integer, ByVal Obj As Integer, ByVal Missing_word As String) As String
        With LayerData(Layernum).atrData.Data(DataNum)
            Dim v As String = .Value(Obj)
            If .MissingF = False Then
                Return v
            Else
                If v = "" Then
                    Return Missing_word
                Else
                    Return v
                End If
            End If

        End With
    End Function
    ''' <summary>
    ''' 欠損値を除いた配列でデータ項目の値を取得
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Data_Cell_Array_Without_MissingValue(ByVal LayerNum As Integer, ByVal DataNum As Integer) As strObjLocation_and_Data_info()
        Dim ObjNum As Integer = LayerData(LayerNum).atrObject.ObjectNum
        Dim DT(ObjNum - 1) As strObjLocation_and_Data_info
        With LayerData(LayerNum).atrData.Data(DataNum)
            If .EnableValueNum = 0 Then
                Return Nothing
            End If
            If .MissingF = False Or .MissingValueNum = 0 Then
                For i As Integer = 0 To ObjNum - 1
                    DT(i).ObjLocation = i
                    DT(i).DataValue = .Value(i)
                Next
            Else
                Dim n As Integer = 0
                For i As Integer = 0 To ObjNum - 1
                    If .Value(i) <> "" Then
                        DT(n).ObjLocation = i
                        DT(n).DataValue = .Value(i)
                        n += 1
                    End If
                Next
                ReDim Preserve DT(n - 1)
            End If
            Return DT
        End With
    End Function
    ''' <summary>
    ''' データ項目のデータを配列で取得、欠損値は最小値-1に、カテゴリーデータの場合はカテゴリーの位置
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Data_Cell_Array_With_MissingValue(ByVal LayerNum As Integer, ByVal DataNum As Integer) As Double()
        Dim ObjNum As Integer = LayerData(LayerNum).atrObject.ObjectNum
        Dim DT(ObjNum - 1) As Double
        With LayerData(LayerNum).atrData.Data(DataNum)
            If .EnableValueNum = 0 Then
                Return Nothing
            End If
            Select Case .DataType
                Case enmAttDataType.Category
                    Dim DT_i() As Integer = Get_Categoly(LayerNum, DataNum)
                    For i As Integer = 0 To ObjNum - 1
                        DT(i) = CDbl(DT_i(i))
                    Next
                Case enmAttDataType.Normal
                    For i As Integer = 0 To ObjNum - 1
                        If .Value(i) <> "" Or .MissingF = False Then
                            DT(i) = Val(.Value(i))
                        Else
                            DT(i) = .Statistics.Min - 1
                        End If
                    Next
                Case Else
                    'カテゴリーとノーマル以外は想定していない
            End Select
        End With
        Return DT
    End Function
    ''' <summary>
    ''' データ項目のデータを文字列配列で取得
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <param name="MissValueWord"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Data_Cell_Array_With_MissingValue(ByVal LayerNum As Integer, ByVal DataNum As Integer, ByVal MissValueWord As String) As String()
        Dim ObjNum As Integer = LayerData(LayerNum).atrObject.ObjectNum
        Dim DT(ObjNum - 1) As String
        With LayerData(LayerNum).atrData.Data(DataNum)
            If .EnableValueNum = 0 Then
                Return Nothing
            End If
            For i As Integer = 0 To ObjNum - 1
                DT(i) = Get_Data_Value(LayerNum, DataNum, i, MissValueWord)
            Next
        End With
        Return DT
    End Function
    Public Function Check_Missing_Value(ByVal LayerNum As Integer, ByVal DataNum As Integer, ByVal ObjectPosition As Integer) As Boolean
        With LayerData(LayerNum).atrData.Data(DataNum)
            If .MissingValueNum = 0 Or .MissingF = False Then
                Return False
            Else
                If .Value(ObjectPosition) = "" Then
                    Return True
                Else
                    Return False
                End If
            End If
        End With
    End Function
    ''' <summary>
    ''' データ項目のデータが欠損値だった場合にTRUEが入る配列を返す
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Missing_Value_DataArray(ByVal LayerNum As Integer, ByVal DataNum As Integer) As Boolean()
        Dim ObjNum As Integer = LayerData(LayerNum).atrObject.ObjectNum
        Dim DT(ObjNum - 1) As Boolean

        With LayerData(LayerNum).atrData.Data(DataNum)
            If .MissingValueNum = 0 Or .MissingF = False Then
                Return DT
            End If
            For i As Integer = 0 To ObjNum - 1
                If .Value(i) = "" Then
                    DT(i) = True
                End If
            Next
        End With
        Return DT
    End Function

    ''' <summary>
    ''' 'データ項目の平均、合計、標準偏差等を計算
    ''' </summary>
    ''' <param name="L"></param>
    ''' <param name="D"></param>
    ''' <remarks></remarks>
    Private Sub CulcuOne(ByVal L As Integer, ByVal D As Integer)


        Dim ObjNum As Integer = LayerData(L).atrObject.ObjectNum
        With LayerData(L).atrData.Data(D)
            .MissingValueNum = Get_Att_Missing_Num(L, D)
            .EnableValueNum = ObjNum - .MissingValueNum
            Select Case .DataType
                Case enmAttDataType.Strings
                    With .Statistics

                    End With
                Case enmAttDataType.Category
                Case enmAttDataType.Normal
                    Dim EDataNum As Integer = .EnableValueNum
                    If 0 < EDataNum Then
                        Dim EnableDT() As strObjLocation_and_Data_info = Get_Data_Cell_Array_Without_MissingValue(L, D)
                        Dim Add As Double = 0
                        Dim Add2 As Double = 0
                        Dim Max As Double = Val(EnableDT(0).DataValue)
                        Dim Min As Double = Max
                        Dim BeforeDecimal As Integer = 0
                        Dim AfterDecimal As Integer = 0
                        For i As Integer = 0 To EDataNum - 1
                            Dim v As Double = Val(EnableDT(i).DataValue)
                            Add += v
                            Add2 += +v * v
                            Max = Math.Max(Max, v)
                            Min = Math.Min(Min, v)
                            Dim b As Integer, a As Integer
                            clsGeneric.Figure_Arrange(v, b, a)
                            BeforeDecimal = Math.Max(BeforeDecimal, b)
                            AfterDecimal = Math.Max(AfterDecimal, a)
                        Next
                        With .Statistics
                            .Max = Max
                            .Min = Min
                            .Sum = Add
                            .AfterDecimalNum = AfterDecimal
                            .BeforeDecimalNum = BeforeDecimal
                            .Ave = Add / EDataNum
                            .Ave = Val(clsGeneric.Figure_Using(.Ave, AfterDecimal + 1))
                            .sa = Max - Min
                            .STD = Math.Sqrt(Add2 / EDataNum - .Ave * .Ave)
                            .STD = Val(clsGeneric.Figure_Using(.STD, AfterDecimal + 1))
                        End With
                    End If
            End Select

        End With


    End Sub
    ''' <summary>
    ''' 指定したレイヤ・データ項目で指定した単独表示モードが表示可能か調べる
    ''' </summary>
    ''' <param name="Solo_md"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Enable_SoloMode(ByVal Solo_md As enmSoloMode_Number, ByVal Layernum As Integer, ByVal DataNum As Integer) As Boolean

        Select Case LayerData(Layernum).atrData.Data(DataNum).DataType
            Case enmAttDataType.Strings
                If Solo_md <> enmSoloMode_Number.StringMode Then
                    Return False
                End If
            Case enmAttDataType.Category
                Select Case Solo_md
                    Case enmSoloMode_Number.MarkSizeMode, enmSoloMode_Number.MarkBlockMode, enmSoloMode_Number.ContourMode, enmSoloMode_Number.MarkTurnMode, enmSoloMode_Number.MarkBarMode
                        Return False
                End Select
        End Select

        Select Case LayerData(Layernum).Type
            Case enmLayerType.Normal, enmLayerType.Mesh
                If LayerData(Layernum).Shape = enmShape.LineShape Then
                    Select Case Solo_md
                        Case enmSoloMode_Number.ClassHatchMode, enmSoloMode_Number.ClassMarkMode, enmSoloMode_Number.MarkBlockMode, enmSoloMode_Number.ContourMode, enmSoloMode_Number.MarkTurnMode, enmSoloMode_Number.MarkBarMode
                            Return False
                    End Select
                End If
            Case enmLayerType.Trip
                Select Case Solo_md
                    Case enmSoloMode_Number.ClassHatchMode, enmSoloMode_Number.ClassMarkMode, enmSoloMode_Number.MarkSizeMode, enmSoloMode_Number.MarkBlockMode, enmSoloMode_Number.ContourMode, enmSoloMode_Number.MarkTurnMode, enmSoloMode_Number.MarkBarMode, enmSoloMode_Number.StringMode
                        Return False
                End Select
            Case enmLayerType.Trip_Definition
                Select Case Solo_md
                    Case enmSoloMode_Number.ClassHatchMode, enmSoloMode_Number.ClassMarkMode, enmSoloMode_Number.MarkSizeMode, enmSoloMode_Number.MarkBlockMode, enmSoloMode_Number.ContourMode, enmSoloMode_Number.MarkTurnMode, enmSoloMode_Number.MarkBarMode, enmSoloMode_Number.StringMode
                        Return False
                End Select
        End Select

        Return True

    End Function
    ''' <summary>
    ''' データ項目の初期凡例の設定
    ''' </summary>
    ''' <param name="L"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Private Sub SetIniHanrei(ByVal L As Integer, ByVal DataNum As Integer)

        Dim colorType As clsHanrei_Defo_Color.colors_info = clsHanrei_Defo_Color.Color(clsSettings.Data.defoHanreiColor)

        Dim DType As enmAttDataType = LayerData(L).atrData.Data(DataNum).DataType
        'If DType = enmAttDataType.Strings Then
        '    LayerData(L).atrData.Data(DataNum).ModeData = enmSoloMode_Number.noMode
        '    Return
        'End If

        If LayerData(L).atrData.Data(DataNum).EnableValueNum = 0 Then
            Return
        End If


        Dim DataMax As Double = LayerData(L).atrData.Data(DataNum).Statistics.Max
        Dim DataMin As Double = LayerData(L).atrData.Data(DataNum).Statistics.Min

        '単独表示の初期値を設定
        With LayerData(L).atrData.Data(DataNum)

            'ペイント
            With .SoloModeViewSettings.ClassPaintMD
                If LayerData(L).Type = enmLayerType.Trip_Definition Then
                    .color1 = New colorARGB(&HFF, &HFF, 0, 0)
                    .color2 = New colorARGB(&HFF, 0, 0, &HFF)
                Else
                    .color1 = colorType.PaintModeClass1
                    If LayerData(L).Shape = enmShape.LineShape Then
                        .color2 = New colorARGB(&HE0, &HE0, &HE0, &HE0)
                    Else
                        .color2 = colorType.PaintModeClass2
                    End If
                End If
            End With

            'タイトルと単位によって記号モードとペイントモードを振り分ける
            Dim Class_Mode_Title() As String = {"率", "割合", "密度", "Rate", "density", "average", "平均", "比",
                                                "Ratio ", "あたり", "当たり", "時間", "距離", "distance", "標高", "水深", "%", "％"}
            Dim Class_Mode_unit() As String = {"パーセント", "％", "%", " per ", "/", "‰", "パーミル", "／", "percent"}
            Dim m As enmSoloMode_Number = enmSoloMode_Number.MarkSizeMode
            Dim meshF As Boolean = False
            Select Case LayerData(L).Type
                Case enmLayerType.DefPoint
                Case enmLayerType.Trip
                Case enmLayerType.Trip_Definition
                Case enmLayerType.Mesh
                    meshF = True
                Case enmLayerType.Normal
                    If LayerData(L).MapFileData.ObjectKind(LayerData(L).MapFileData.MPObj(LayerData(L).atrObject.atrObjectData(0).MpObjCode).Kind).Mesh <> enmMesh_Number.mhNonMesh Then
                        meshF = True
                    End If
            End Select

            If DType = enmAttDataType.Strings Then
                m = enmSoloMode_Number.StringMode
            ElseIf DType = enmAttDataType.Category Or LayerData(L).Shape <> enmShape.PolygonShape Or .Unit = "" Or meshF = True Then
                m = enmSoloMode_Number.ClassPaintMode
            Else
                For i As Integer = 0 To Class_Mode_Title.Length - 1
                    If InStr(UCase(.Title), UCase(Class_Mode_Title(i))) <> 0 Then
                        m = enmSoloMode_Number.ClassPaintMode
                        Exit For
                    End If
                Next
                For i As Integer = 0 To Class_Mode_unit.Length - 1
                    If InStr(UCase(.Unit), UCase(Class_Mode_unit(i))) <> 0 Then
                        m = enmSoloMode_Number.ClassPaintMode
                        Exit For
                    End If
                Next
            End If
            .ModeData = m

            .SoloModeViewSettings.Div_Method = enmDivisionMethod.Free
            If DType = enmAttDataType.Category Then
                'カテゴリーデータの階級区分
                Dim cateData() As strObjLocation_and_Data_info = Get_Data_Cell_Array_Without_MissingValue(L, DataNum)
                Dim n As Integer = cateData.Length
                Dim CateValue(n - 1) As String
                For i As Integer = 0 To n - 1
                    CateValue(i) = cateData(i).DataValue
                Next
                Array.Sort(CateValue)
                Dim CateNum As Integer = clsGeneric.Remove_Same_String(n, CateValue)
                .Statistics.sa = CateNum
                With .SoloModeViewSettings
                    .Div_Num = CateNum
                    ReDim .Class_Div(CateNum - 1)
                    For i As Integer = 0 To CateNum - 1
                        .Class_Div(i).Cat_Name = CateValue(i)
                    Next
                    .ClassPaintMD.Color_Mode = enmPaintColorSettingModeInfo.SoloColor
                End With
            Else
                '通常のデータの階級区分値
                Dim zn(100) As Double
                '               zn(-1) = 0
                .SoloModeViewSettings.ClassPaintMD.Color_Mode = enmPaintColorSettingModeInfo.twoColor
                Dim DVN As Integer = 0
                Dim Max As Double = DataMax
                Dim Min As Double = DataMin
                Dim ST As Double = 0
                clsGeneric.WIC(5, Max, Min, ST)

                For dk As Double = Min To Max Step ST
                    If (dk > DataMin And dk < DataMax) Or DataMax = DataMin Then
                        zn(DVN) = Val(CStr(dk))
                        DVN += 1
                    End If
                Next
                If DVN = 0 Then
                    zn(0) = (DataMin + DataMax) / 2 - (DataMax - DataMin) / 4
                    zn(1) = (DataMin + DataMax) / 2 + (DataMax - DataMin) / 4
                    DVN = 2
                End If
                With .SoloModeViewSettings
                    ReDim .Class_Div(DVN)
                End With
                For k As Integer = DVN - 1 To 0 Step -1
                    .SoloModeViewSettings.Class_Div(DVN - 1 - k).Value = zn(k)
                Next
                .SoloModeViewSettings.Div_Num = DVN + 1

                If LayerData(L).Type <> enmLayerType.Trip Then
                    '記号の大きさモードの凡例値
                    Dim h1 As Integer, h2 As Integer, h3 As Integer
                    Max = DataMax
                    Min = DataMin
                    ST = 0
                    If Max <> Min Then
                        If Min < 0 Then
                            Min = 0
                            Max = Math.Max(Math.Abs(DataMax), Math.Abs(DataMin))
                        End If
                        Dim a As Double = Min
                        Dim b As Double = Max
                        clsGeneric.WIC(10, Max, Min, ST)
                        DVN = 0
                        For dk As Double = Min To Max Step ST
                            If a < dk And dk < b Then
                                zn(DVN) = dk
                                DVN += 1
                            End If
                        Next
                        Select Case DVN
                            Case 2
                                h1 = 1 : h2 = 0 : h3 = -1
                            Case 3
                                h1 = 2 : h2 = 1 : h3 = 0
                            Case 4
                                h1 = 3 : h2 = 1 : h3 = 0
                            Case 5
                                h1 = 4 : h2 = 2 : h3 = 0
                            Case 6
                                h1 = 5 : h2 = 2 : h3 = 0
                            Case Else
                                h1 = DVN - 1 : h2 = DVN \ 2 - 1 : h3 = 0
                        End Select
                    Else
                        For j As Integer = 0 To 3
                            zn(j) = 0
                        Next
                    End If

                    With .SoloModeViewSettings.MarkSizeMD
                        ReDim .Value(4)
                        .Value(0) = zn(h1)
                        If h2 <> -1 Then
                            .Value(1) = zn(h2)
                        Else
                            .Value(1) = 0
                        End If
                        Dim a As Double = 0
                        If h3 <> -1 Then
                            If zn(h3) = 0 Then
                                a = zn(h2) / 2
                            Else
                                a = zn(h3)
                            End If
                        End If
                        .Value(2) = a
                        .Value(3) = 0
                        .Value(4) = 0
                        .MaxValueMode = 0
                        .MaxValue = Math.Max(Math.Abs(DataMax), Math.Abs(DataMin))
                        If LayerData(L).Shape = enmShape.LineShape Then
                            With .LineShape
                                .LineWidth = 1
                                .Color = colorType.MarkLineShapeColor
                                .LineEdge = clsBase.Line.Edge_Connect_Pattern
                            End With
                        Else
                            .Mark = clsBase.Mark
                            .Mark.Tile.Line.BasicLine.SolidLine.Color = colorType.MarkColor
                            .Mark.Tile.BGColFlag = True
                            .Mark.WordFont.Body.Size = 10
                        End If
                    End With

                    '記号の数モードの凡例値
                    Max = Math.Max(Math.Abs(DataMax), Math.Abs(DataMin))
                    Min = 0
                    ST = 0
                    clsGeneric.WIC(10, Max, Min, ST)

                    With .SoloModeViewSettings.MarkBlockMD
                        If ST < 1 And Min >= 1 Then
                            .Value = 1
                        Else
                            .Value = ST
                        End If
                        .ArrangeB = enmMarkBlockArrange.Block
                        .HasuVisible = False
                        .Mark = clsBase.Mark
                        .Mark.Tile.Line.BasicLine.SolidLine.Color = colorType.MarkColor
                        .Mark.Tile.BGColFlag = True
                        .Mark.WordFont.Body.Size = 2
                        .Overlap = 0
                        .LegendBlockModeWord = ""
                    End With

                    With .SoloModeViewSettings.ClassMarkMD
                        .Data = DataNum
                        .Flag = False
                        .Mode = 0
                    End With

                    With .SoloModeViewSettings.MarkTurnMD
                        .Dirction = 0
                        .DegreeLap = 360
                        .Mark = clsBase.Mark
                        .Mark.ShapeNumber = 14
                        .Mark.Tile.Line.BasicLine.SolidLine.Color = colorType.MarkColor
                        .Mark.Tile.BGColFlag = True
                        .Mark.WordFont.Body.Size = 5
                    End With

                    With .SoloModeViewSettings.MarkBarMD
                        .BarShape = MarkBarShape.bar
                        .InnerTile = clsBase.PaintTile(colorType.MarkBarColor)
                        .FrameLinePat = clsBase.Line
                        .ScaleLineInterval = ST
                        .MaxHeight = 10
                        .MaxValueMode = enmMarkSizeValueMode.inDataItem
                        .MaxValue = DataMax
                        .scaleLinePat = clsBase.Line
                        .scaleLinePat.BasicLine.SolidLine.Color = clsBase.ColorWhite
                        .ScaleLineVisible = True
                        .Width = 1.5
                        .ThreeD = True
                    End With


                End If
            End If
            With .SoloModeViewSettings.MarkCommon
                .MinusTile = clsBase.Tile
                .MinusTile.BGColFlag = True
                .MinusLineColor = colorType.MarkCommonMinusColor
                With .Inner_Data
                    .Flag = False
                    .Data = DataNum
                        .Mode = 0
                End With
                .LegendMinusWord = ""
                .LegendPlusWord = ""
            End With
            With .SoloModeViewSettings.StringMD
                .Font = clsBase.Font
                .Font.Body.Size = 3
                .Font.Body.FringeF = True
                .maxWidth = 20
                .WordTurnF = True
            End With

            Twocolort(L, DataNum)
            If DType = enmAttDataType.Normal And LayerData(L).Shape <> enmShape.LineShape Then
                Dim Attribute_Data As strSoloModeViewSettings_Data = .SoloModeViewSettings
                With .SoloModeViewSettings.ContourMD
                    .Interval_Mode = 2
                    .Detailed = 3
                    .Draw_in_Polygon_F = True
                    .Spline_flag = True

                    With .Regular
                        .bottom = Attribute_Data.Class_Div(Attribute_Data.Div_Num - 2).Value
                        .Interval = (Attribute_Data.Class_Div(Attribute_Data.Div_Num - 3).Value - .bottom) / 2
                        .Line_Pat = clsBase.Line
                        .top = DataMax
                        .SP_Bottom = .bottom
                        .SP_interval = .Interval * 5
                        .SP_Line_Pat = clsBase.Line
                        .SP_Line_Pat.BasicLine.SolidLine.Color = clsBase.ColorBlue
                        .SP_Top = .top
                        .EX_Value_Flag = False
                        .EX_Value = 0
                        .EX_Line_Pat = clsBase.Line
                        .EX_Line_Pat.BasicLine.SolidLine.Color = clsBase.ColorRed
                    End With
                    .IrregularNum = 0
                End With
            End If
            Call Set_Class_Div(L, DataNum, 0)

            If LayerData(L).Type <> enmLayerType.Trip And LayerData(L).Type <> enmLayerType.Trip_Definition Then
                With .SoloModeViewSettings.ClassODMD
                    .O_object = 0
                    .o_Layer = L
                    .Arrow = clsBase.Arrow
                    For kk As Integer = 0 To TotalData.LV1.Lay_Maxn - 1
                        If LayerData(kk).Type <> enmLayerType.Trip And LayerData(kk).Type <> enmLayerType.Trip_Definition Then
                            For k As Integer = 0 To LayerData(kk).atrObject.ObjectNum - 1
                                If InStr(LayerData(L).atrData.Data(DataNum).Title, LayerData(kk).atrObject.atrObjectData(k).Name) <> 0 Then
                                    .O_object = k
                                    .o_Layer = kk
                                    kk = TotalData.LV1.Lay_Maxn
                                    Exit For
                                End If
                            Next
                        End If
                    Next
                End With

            End If

        End With

    End Sub
    ''' <summary>
    ''' 階級区分設定
    ''' </summary>
    ''' <param name="lay_num"></param>
    ''' <param name="DNum"></param>
    ''' <param name="setStartPos">設定を始める区分位置</param>
    ''' <remarks></remarks>
    Public Sub Set_Class_Div(ByVal lay_num As Integer, ByVal DNum As Integer, ByVal setStartPos As Integer)


        Dim att_DTA As strSoloModeViewSettings_Data = LayerData(lay_num).atrData.Data(DNum).SoloModeViewSettings
        Dim n As Integer = att_DTA.Div_Num

        For j As Integer = setStartPos To n - 1
            With LayerData(lay_num).atrData.Data(DNum).SoloModeViewSettings.Class_Div(j)
                .ClassMark = clsBase.Mark
                .ClassMark.wordmark = ChrW(AscW("Ａ") + j Mod 26)
                .ClassMark.WordFont.Body.Size = 5
                .ClassMark.PrintMark = 1
                .ClassMark.Tile = clsBase.Tile
                .ClassMark.WordFont = clsBase.Font
                .TilePat = clsBase.Tile
                If setStartPos = 0 Then
                    If j <= 8 Then
                        .TilePat = clsBase.ClassTile(clsGeneric.m_min_max(n, 1, 9), j)
                    Else
                        .TilePat = clsBase.Tile
                        .TilePat.TileCode = enmTilePattern.Blank
                    End If
                Else
                    .TilePat.TileCode = enmTilePattern.Blank
                End If

                Dim w As Single
                If LayerData(lay_num).Type = enmLayerType.Trip_Definition Then
                    w = 0.5
                Else
                    w = 1
                End If
                Dim col As colorARGB = .PaintColor
                If col.Equals(New colorARGB(Color.White)) Then
                    col = New colorARGB(255, 200, 200, 200)
                End If
                .ODLinePat = clsBase.Line
                .ODLinePat.Set_Same_ColorWidth_to_LinePat(col, w)
                If LayerData(lay_num).Type <> enmLayerType.Trip And LayerData(lay_num).Type <> enmLayerType.Trip_Definition Then
                    .ODLinePat.Edge_Connect_Pattern.Edge_Pattern = enmEdge_Pattern.Flat
                End If
                If j = n - 1 And LayerData(lay_num).atrData.Data(DNum).DataType = enmAttDataType.Normal And
                    (LayerData(lay_num).Shape = enmShape.PolygonShape Or LayerData(lay_num).Shape = enmShape.PointShape) Then
                    .ODLinePat.BasicLine.pattern = enmLinePattern.InVisible
                End If
            End With
        Next

    End Sub
    ''' <summary>
    ''' 2色グラテーション設定
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNum"></param>
    ''' <remarks></remarks>
    Public Sub Twocolort(ByVal LayerNum As Integer, ByVal DataNum As Integer)

        With LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            Dim n As Integer = .Div_Num
            If n = 1 Then
                .Class_Div(0).PaintColor = .ClassPaintMD.color1
            Else
                Dim ColData() As colorARGB = clsGeneric.TwoColorGradation(.ClassPaintMD.color1, .ClassPaintMD.color2, n)
                For i As Integer = 0 To n - 1
                    .Class_Div(i).PaintColor = ColData(i)
                Next
            End If
        End With

    End Sub
    ''' <summary>
    ''' 3色グラデーション
    ''' </summary>
    ''' <param name="Color_cng_n"></param>
    ''' <remarks></remarks>
    Public Sub Threecolor(ByVal LayerNum As Integer, ByVal DataNum As Integer, ByVal Color_cng_n As Integer)


        With LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings

            Dim n As Integer = .Div_Num
            Dim ColData() As colorARGB
            With .ClassPaintMD
                ColData = clsGeneric.ThreeColorGradation(.color1, .color3, .color2, n, Color_cng_n)
            End With
            For i As Integer = 0 To n - 1
                .Class_Div(i).PaintColor = ColData(i)
            Next
        End With

    End Sub
    ''' <summary>
    ''' 複数グラデーション
    ''' </summary>
    ''' <param name="Color_cng_n"></param>
    ''' <param name="GradationPoint4"></param>
    ''' <param name="col"></param>
    ''' <remarks></remarks>
    Public Sub FourColor(ByVal LayerNum As Integer, ByVal DataNum As Integer, ByVal Color_cng_n As Integer, ByVal GradationPoint4 As Integer, ByVal col As colorARGB)
        Dim ColData() As colorARGB

        If Color_cng_n = GradationPoint4 Then
            Return
        End If

        With LayerData(LayerNum).atrData.Data(DataNum).SoloModeViewSettings
            If Color_cng_n < GradationPoint4 Then
                Dim n As Integer = GradationPoint4 + 1
                With .ClassPaintMD
                    ColData = clsGeneric.TwoColorGradation(.color1, col, Color_cng_n + 1)
                End With
                For i As Integer = 0 To Color_cng_n
                    .Class_Div(i).PaintColor = ColData(i)
                Next
                With .ClassPaintMD
                    ColData = clsGeneric.TwoColorGradation(col, .color3, n - Color_cng_n)
                End With
                For i As Integer = Color_cng_n To n - 1
                    .Class_Div(i).PaintColor = ColData(i - Color_cng_n)
                Next
            Else
                Dim n As Integer = Color_cng_n - GradationPoint4 + 1
                With .ClassPaintMD
                    ColData = clsGeneric.TwoColorGradation(.color3, col, n)
                End With
                For i As Integer = 0 To n - 1
                    .Class_Div(GradationPoint4 + i).PaintColor = ColData(i)
                Next
                n = .Div_Num - Color_cng_n
                With .ClassPaintMD
                    ColData = clsGeneric.TwoColorGradation(col, .color2, n)
                End With
                For i As Integer = 0 To n - 1
                    .Class_Div(Color_cng_n + i).PaintColor = ColData(i)
                Next

            End If
        End With

    End Sub

    ''' <summary>
    ''' 階級区分値の指定
    ''' </summary>
    ''' <param name="DataNum"></param>
    ''' <param name="Layernum"></param>
    ''' <remarks></remarks>
    Public Sub Set_Div_Value(ByVal Layernum As Integer, ByVal DataNum As Integer)

        With LayerData(Layernum).atrData.Data(DataNum)
            Dim V As enmDivisionMethod = .SoloModeViewSettings.Div_Method
            Dim EDataNum As Integer = .EnableValueNum
            Dim div_num As Integer = .SoloModeViewSettings.Div_Num
            Dim dtype As enmAttDataType = .DataType
            Dim Div_Value(div_num - 1) As Double

            Select Case V
                Case enmDivisionMethod.Free
                    Return
                Case enmDivisionMethod.Quantile, enmDivisionMethod.AreaQuantile '分位数
                    Dim EnableDT() As strObjLocation_and_Data_info = Get_Data_Cell_Array_Without_MissingValue(Layernum, DataNum)
                    Dim SortV As New clsSortingSearch(VariantType.Double)
                    For i As Integer = 0 To EDataNum - 1
                        SortV.Add(Val(EnableDT(i).DataValue))
                    Next
                    SortV.AddEnd()
                    If V = enmDivisionMethod.Quantile Then
                        Dim divvStp As Single = SortV.NumofData / div_num
                        Dim i As Integer = 0
                        Dim divv As Single = divvStp
                        Do
                            Div_Value(i) = SortV.DataPositionRevValue_double(Int(divv) - 1)
                            divv += divvStp
                            i += 1
                        Loop While divv < SortV.NumofData
                    Else
                        '面積分位数
                        Dim Mense(EDataNum - 1) As Single
                        Dim AddMense As Single = 0
                        For i As Integer = 0 To EDataNum - 1
                            Mense(i) = GetObjMenseki(Layernum, EnableDT(i).ObjLocation)
                            AddMense += Mense(i)
                        Next
                        Dim n As Integer = 0

                        Dim Addv As Single = 0
                        Dim divvStp As Single = AddMense / div_num
                        Dim divv As Single = divvStp
                        For i As Integer = 0 To SortV.NumofData - 1
                            Dim j As Integer = SortV.DataPositionRev(i)
                            Addv += Mense(j)
                            If Addv >= divv Then
                                Div_Value(n) = SortV.DataPositionRevValue_double(i)
                                divv += divvStp
                                n += 1
                                Addv = Addv - Mense(j)
                                i = i - 1
                            End If
                        Next
                    End If
                    SortV = Nothing
                Case enmDivisionMethod.StandardDeviation '標準偏差
                    With .Statistics
                        Div_Value(0) = .Ave + .STD
                        Div_Value(1) = .Ave + .STD / 2
                        Div_Value(2) = .Ave
                        Div_Value(3) = .Ave - .STD / 2
                        Div_Value(4) = .Ave - .STD
                        For i As Integer = 0 To 4
                            Div_Value(i) = Val(clsGeneric.Figure_Using(Div_Value(i), .AfterDecimalNum + 1))
                        Next
                    End With
                Case enmDivisionMethod.EqualInterval '等間隔
                    With .Statistics
                        Dim a As Double = .sa / div_num
                        For i As Integer = 0 To div_num - 1
                            Div_Value(i) = .Max - a * (i + 1)
                        Next
                        For i As Integer = 0 To div_num - 1
                            Div_Value(i) = Val(clsGeneric.Figure_Using(Div_Value(i), .AfterDecimalNum + 1))
                        Next
                    End With

            End Select
            For i As Integer = 0 To div_num - 1
                .SoloModeViewSettings.Class_Div(i).Value = Div_Value(i)
            Next

        End With
    End Sub
    ''' <summary>
    ''' オブジェクトの重心取得、できなかった場合はFalse
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="ObjNumber"></param>
    ''' <param name="GPoint">重心（戻り値）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_ObjectGravityPoint(ByVal LayerNum As Integer, ByVal ObjNumber As Integer, ByRef GPoint As PointF) As Boolean
        If LayerData(LayerNum).Type = enmLayerType.Mesh Then
            With LayerData(LayerNum).atrObject.atrObjectData(ObjNumber)
                Dim px As Single = .MeshPoint(0).X
                Dim py As Single = .MeshPoint(0).Y
                For i As Integer = 1 To 4
                    px += .MeshPoint(i).X
                    py += .MeshPoint(i).Y
                Next
                px /= 4
                py /= 4
                GPoint = New Point(px, py)
                Return True
            End With
        Else
            Dim Arrange_LineCode(,) As Integer, Fringe() As clsMapData.Fringe_Line_Info
            Dim Pon As Integer = Boundary_Kencode_Arrange(LayerNum, ObjNumber, Arrange_LineCode, Fringe)
            If Pon <= 0 Then
                Return False
            Else
                Dim px As Single
                Dim py As Single
                LayerData(LayerNum).MapFileData.Menseki_Sub(px, py, Pon, Arrange_LineCode, Fringe)
                GPoint = New Point(px, py)
                Return True
            End If
        End If
    End Function
    ''' <summary>
    ''' オブジェクトの面積取得
    ''' </summary>
    ''' <param name="LayerNum">レイヤ</param>
    ''' <param name="ObjNumber">オブジェクトの位置</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetObjMenseki(ByVal LayerNum As Integer, ByVal ObjNumber As Integer) As Single

        Dim Arrange_LineCode(,) As Integer, Fringe() As clsMapData.Fringe_Line_Info
        If LayerData(LayerNum).Type = enmLayerType.Mesh Then
            Dim p() As PointF = LayerData(LayerNum).atrObject.atrObjectData(ObjNumber).MeshPoint.Clone
            ReDim Preserve p(5)
            p(4) = p(0)
            p(5) = p(1)
            Dim men As Single = spatial.Get_Hairetu_Menseki(5, p, LayerData(LayerNum).MapFileData.Map)
            Return men
        Else
            Dim Pon As Integer = Boundary_Kencode_Arrange(LayerNum, ObjNumber, Arrange_LineCode, Fringe)
            If Pon <= 0 Then
                Return -1
            Else
                Return LayerData(LayerNum).MapFileData.Menseki_Sub(Pon, Arrange_LineCode, Fringe)
            End If
        End If

    End Function
    ''' <summary>
    ''' オブジェクトの周長を求める
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="ObjNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_ObjectLength(ByVal Layernum As Integer, ByVal ObjNum As Integer) As Single
        '

        Dim ELine() As clsMapData.EnableMPLine_Data

        Dim NL As Integer

        Select Case LayerData(Layernum).atrObject.atrObjectData(ObjNum).Objectstructure
            Case enmKenCodeObjectstructure.MapObj
                Dim O_Code As Integer = Get_KenObjCode(Layernum, ObjNum)
                NL = LayerData(Layernum).MapFileData.Get_EnableMPLine(ELine, O_Code, LayerData(Layernum).Time)
            Case enmKenCodeObjectstructure.SyntheticObj
                NL = Get_Enable_KenCode_MPLine(ELine, ObjNum, Layernum)
        End Select

        If NL = 0 Then
            Return -1
        End If

        Dim D As Single = 0
        For i As Integer = 0 To NL - 1
            With LayerData(Layernum).MapFileData.MPLine(ELine(i).LineCode)
                If TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                    For j As Integer = 0 To .NumOfPoint - 2
                        D += spatial.Distance_Ido_Kedo_XY(.PointSTC(j).X, .PointSTC(j).Y, .PointSTC(j + 1).X, .PointSTC(j + 1).Y, TotalData.ViewStyle.Zahyo)
                    Next
                Else
                    For j As Integer = 0 To .NumOfPoint - 2
                        D += spatial.get_Distance(.PointSTC(j), .PointSTC(j + 1))
                    Next
                End If
            End With
        Next
        If TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
        Else
            D = D / LayerData(Layernum).MapFileData.Map.SCL
        End If
        Return D
    End Function

    ''' <summary>
    ''' データ項目の中央値を求める
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="DataNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_MedianValue(ByVal Layernum As Integer, ByVal DataNum As Integer) As Double

        Dim ST As New clsSortingSearch(VariantType.Double)

        Dim MV() As strObjLocation_and_Data_info = Get_Data_Cell_Array_Without_MissingValue(Layernum, DataNum)
        For i As Integer = 0 To MV.Length - 1
            ST.Add(CDbl(Val(MV(i).DataValue)))
        Next
        ST.AddEnd()
        Dim n As Integer = MV.Length
        If n Mod 2 = 1 Then
            '奇数個の場合
            Return ST.DataPositionRevValue_double(n \ 2)
        Else
            '偶数個の場合
            Return (ST.DataPositionRevValue_double(n \ 2 - 1) + ST.DataPositionRevValue_double(n \ 2)) / 2
        End If
    End Function
    ''' <summary>
    ''' レイヤ名を取得する。レイヤが1つでレイヤ名が空白の場合は""を返す
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="CR_F"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Layer_Name(ByVal Layernum As Integer, Optional ByVal CR_F As Boolean = False) As String
        If TotalData.LV1.Lay_Maxn = 1 And LayerData(Layernum).Name = "" Then
            Return ""
        Else
            Get_Layer_Name = "レイヤ:" & LayerData(Layernum).Name & vbCrLf
            If CR_F = True Then
                Get_Layer_Name = Get_Layer_Name & vbCrLf
            End If
        End If
    End Function

    ''' <summary>
    ''' 重ね合わせデータセットの内容を自動で並べ替える
    ''' </summary>
    ''' <param name="DataSetNumber"></param>
    ''' <remarks></remarks>
    Public Sub Sort_OverLay_Data(ByVal DataSetNumber As Integer)

        Dim d As strOverLay_Dataset_Info = Me.TotalData.TotalMode.OverLay.DataSet(DataSetNumber)
        d.DataItem = Sort_OverLay_Data_Sub(d.DataItem)
        Me.TotalData.TotalMode.OverLay.DataSet(DataSetNumber) = d
    End Sub

    ''' <summary>
    ''' 重ね合わせモードにセットするデータを並べ替える（一つのstrOverLay_DataSet_Item_Infoデータセット）
    ''' </summary>
    ''' <param name="Ov_Data">引数・戻り値</param>
    ''' <remarks></remarks>
    Public Function Sort_OverLay_Data_Sub(ByRef Ov_Data As List(Of strOverLay_DataSet_Item_Info)) As List(Of strOverLay_DataSet_Item_Info)


        Dim PicUpMode(16) As String
        Dim PicUpShape(16) As enmShape

        Dim n As Integer = -1
        n += 1 : PicUpShape(n) = enmShape.PolygonShape : PicUpMode(n) = "0"
        n += 1 : PicUpShape(n) = enmShape.PolygonShape : PicUpMode(n) = "4"
        n += 1 : PicUpShape(n) = enmShape.PolygonShape : PicUpMode(n) = "3"
        n += 1 : PicUpShape(n) = enmShape.LineShape : PicUpMode(n) = "016"
        n += 1 : PicUpShape(n) = enmShape.PolygonShape : PicUpMode(n) = "125678"
        n += 1 : PicUpShape(n) = enmShape.PolygonShape : PicUpMode(n) = "9A"
        n += 1 : PicUpShape(n) = enmShape.PolygonShape : PicUpMode(n) = "B"
        n += 1 : PicUpShape(n) = enmShape.LineShape : PicUpMode(n) = "2349"
        n += 1 : PicUpShape(n) = enmShape.PointShape : PicUpMode(n) = "3"
        n += 1 : PicUpShape(n) = enmShape.PointShape : PicUpMode(n) = "0"
        n += 1 : PicUpShape(n) = enmShape.PointShape : PicUpMode(n) = "1245678"
        n += 1 : PicUpShape(n) = enmShape.PointShape : PicUpMode(n) = "9A"
        n += 1 : PicUpShape(n) = enmShape.PointShape : PicUpMode(n) = "B"
        n += 1 : PicUpShape(n) = enmShape.NotDeffinition : PicUpMode(n) = "D"
        n += 1 : PicUpShape(n) = enmShape.PolygonShape : PicUpMode(n) = "C"
        n += 1 : PicUpShape(n) = enmShape.LineShape : PicUpMode(n) = "C"
        n += 1 : PicUpShape(n) = enmShape.PointShape : PicUpMode(n) = "C"

        Dim Sub_Over As New List(Of strOverLay_DataSet_Item_Info)


        For i As Integer = 0 To UBound(PicUpMode)
            For j As Integer = 0 To Ov_Data.Count - 1
                With Ov_Data(j)
                    If .TileMapf = False Then
                        If Me.LayerData(.Layer).Shape = PicUpShape(i) Then
                            Select Case .Print_Mode_Layer
                                Case enmLayerMode_Number.SoloMode
                                    If InStr(PicUpMode(i), CStr(.Mode)) <> 0 Then
                                        Sub_Over.Add(Ov_Data(j))
                                    End If
                                Case enmLayerMode_Number.GraphMode
                                    If InStr(PicUpMode(i), "A") <> 0 Then
                                        With Me.LayerData(.Layer).LayerModeViewSettings.GraphMode.DataSet(.DataNumber)
                                            If .GraphMode = enmGraphMode.PieGraph Or .GraphMode = enmGraphMode.StackedBarGraph Or .GraphMode = enmGraphMode.BarGraph Then
                                                Sub_Over.Add(Ov_Data(j))
                                            End If
                                        End With
                                    ElseIf InStr(PicUpMode(i), "B") <> 0 Then
                                        With Me.LayerData(.Layer).LayerModeViewSettings.GraphMode.DataSet(.DataNumber)
                                            If .GraphMode = enmGraphMode.LineGraph Then
                                                Sub_Over.Add(Ov_Data(j))
                                            End If
                                        End With
                                    End If
                                Case enmLayerMode_Number.LabelMode
                                    If InStr(PicUpMode(i), "C") <> 0 Then
                                        Sub_Over.Add(Ov_Data(j))
                                    End If
                                Case enmLayerMode_Number.TripMode
                                    If InStr(PicUpMode(i), "D") <> 0 Then
                                        Sub_Over.Add(Ov_Data(j))
                                    End If
                            End Select
                        End If
                    End If
                End With
            Next
        Next

        For i As Integer = 0 To Ov_Data.Count - 1
            If Ov_Data(i).TileMapf = True Then
                Sub_Over.Insert(i, Ov_Data(i))
            End If
        Next

        Return Sub_Over
    End Function

    Public Function Boundary_Kencode_Arrange(ByVal Layernum As Integer, ByVal ObjNum As Integer,
                                             ByRef Arrange_LineCode(,) As Integer, ByRef Fringe() As clsMapData.Fringe_Line_Info) As Integer

        Dim ELine() As clsMapData.EnableMPLine_Data
        Dim NL As Integer

        Dim O_Code As Integer = LayerData(Layernum).atrObject.atrObjectData(ObjNum).MpObjCode
        Select Case LayerData(Layernum).atrObject.atrObjectData(ObjNum).Objectstructure
            Case enmKenCodeObjectstructure.MapObj
                Return LayerData(Layernum).MapFileData.Boundary_Arrange(O_Code, LayerData(Layernum).Time, Arrange_LineCode, Fringe)
            Case enmKenCodeObjectstructure.SyntheticObj
                NL = Get_Enable_KenCode_MPLine(ELine, Layernum, ObjNum)
                Return LayerData(Layernum).MapFileData.Boundary_Arrange_Sub(NL, ELine, Arrange_LineCode, Fringe)
        End Select

    End Function
    ''' <summary>
    ''' 指定されたオブジェクトで、指定された時期に使用可能なライン数と番号を返す
    ''' </summary>
    ''' <param name="Enable_LCode"></param>
    ''' <param name="ObjNum"></param>
    ''' <param name="Layernum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Enable_KenCode_MPLine(ByRef Enable_LCode() As clsMapData.EnableMPLine_Data, ByVal Layernum As Integer, ByVal ObjNum As Integer) As Integer



        Select Case LayerData(Layernum).atrObject.atrObjectData(ObjNum).Objectstructure
            Case enmKenCodeObjectstructure.MapObj
                Dim O_Code As Integer = LayerData(Layernum).atrObject.atrObjectData(ObjNum).MpObjCode
                Return LayerData(Layernum).MapFileData.Get_EnableMPLine(Enable_LCode, O_Code, LayerData(Layernum).Time)
            Case enmKenCodeObjectstructure.SyntheticObj
                Return Get_EnableMPLine_SyntheticObject(Enable_LCode, Layernum, ObjNum)
        End Select
    End Function
    ''' <summary>
    ''' 合成オブジェクトの外周線を返す
    ''' </summary>
    ''' <param name="ELineStock"></param>
    ''' <param name="ObjNum"></param>
    ''' <param name="Layernum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_EnableMPLine_SyntheticObject(ByRef ELineStock() As clsMapData.EnableMPLine_Data, ByVal Layernum As Integer, ByVal ObjNum As Integer) As Integer


        Dim SO_Code As Integer = LayerData(Layernum).atrObject.atrObjectData(ObjNum).MpObjCode
        Dim Time As strYMD = LayerData(Layernum).Time


        ReDim ELineStock(50)
        Dim SObjectLineN As Integer = 0
        With LayerData(Layernum).atrObject.MPSyntheticObj(SO_Code)
            For i As Integer = 0 To .NumOfObject - 1
                If .Objects(i).Draw_F = True Then
                    Dim c As Integer = .Objects(i).code
                    If c <> -1 Then
                        Dim ELine() As clsMapData.EnableMPLine_Data
                        Dim LineN As Integer = LayerData(Layernum).MapFileData.Get_EnableMPLine(ELine, c, Time)
                        For j As Integer = 0 To LineN - 1
                            If UBound(ELineStock) < SObjectLineN Then
                                ReDim Preserve ELineStock(SObjectLineN + 20)
                            End If
                            ELineStock(SObjectLineN) = ELine(j)
                            SObjectLineN += 1
                        Next
                    End If
                End If
            Next
        End With
        ReDim Preserve ELineStock(SObjectLineN - 1)

        Return clsGeneric.Get_Outer_Mpline_AggregatedObj(SObjectLineN, ELineStock, LayerData(Layernum).Shape)
    End Function
    ''' <summary>
    ''' レイヤとそのでのオブジェクト位置から代表点を取得
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="ObjNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_CenterP(ByVal Layernum As Integer, ByVal ObjNum As Integer) As PointF
        '
        With LayerData(Layernum).atrObject.atrObjectData(ObjNum)
            Return .CenterPoint
        End With

    End Function
    ''' <summary>
    ''' レイヤのオブジェクト位置からオブジェクトの外周を取得
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="ObjNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Kencode_Object_Circumscribed_Rectangle(ByVal Layernum As Integer, ByVal ObjNum As Integer) As RectangleF
        With LayerData(Layernum)
            Select Case .Type
                Case enmLayerType.Mesh
                    Return .atrObject.atrObjectData(ObjNum).MeshRect
                Case enmLayerType.DefPoint
                    Dim pt(2) As PointF
                    With .atrObject.atrObjectData(ObjNum)
                        pt(0) = .CenterPoint
                        pt(1) = .Symbol
                        pt(2) = .Label
                    End With
                    Dim rect As RectangleF = spatial.Get_Circumscribed_Rectangle(pt, 0, 3)
                    Return rect
            End Select
            Dim code As Integer = .atrObject.atrObjectData(ObjNum).MpObjCode

            Select Case .atrObject.atrObjectData(ObjNum).Objectstructure
                Case enmKenCodeObjectstructure.MapObj
                    Return .MapFileData.MPObj(code).Circumscribed_Rectangle
                Case enmKenCodeObjectstructure.SyntheticObj
                    With .atrObject.MPSyntheticObj(code)
                        Return .Circumscribed_Rectangle
                    End With
            End Select
        End With
    End Function
    ''' <summary>
    ''' レイヤの地図ファイルのオブジェクト番号からオブジェクトの外周を取得
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="ObjCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Object_Circumscribed_Rectangle(ByVal Layernum As Integer, ByVal ObjCode As Integer) As RectangleF
        Return LayerData(Layernum).MapFileData.MPObj(ObjCode).Circumscribed_Rectangle
    End Function
    ''' <summary>
    ''' 指定の画面座標の中心点と半径の領域が画面に入る場合はtrue
    ''' </summary>
    ''' <param name="CenterP"></param>
    ''' <param name="R"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Screen_In(ByVal CenterP As Point, ByVal R As Integer) As Boolean
        If spatial.Compare_Two_Rectangle_Position(CenterP, R, Me.TotalData.ViewStyle.ScrData.MapScreen_Scale) <> cstRectangle_Cross.cstOuter Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' 指定の画面座標の四角形が画面に入る場合はtrue
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Screen_In(ByVal Rect As Rectangle) As Boolean
        If spatial.Compare_Two_Rectangle_Position(Rect, Me.TotalData.ViewStyle.ScrData.MapScreen_Scale) <> cstRectangle_Cross.cstOuter Then
            Return True
        Else
            Return False
        End If
    End Function


    ''' <summary>
    ''' オブジェクトが画面内に入るかどうかチェック
    ''' </summary>
    ''' <param name="Layernum">レイヤ</param>
    ''' <param name="ObjNum">オブジェクトの位置</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_screen_Kencode_In(ByVal Layernum As Integer, ByVal ObjNum As Integer) As Boolean
        Dim rect As RectangleF = Get_Kencode_Object_Circumscribed_Rectangle(Layernum, ObjNum)
        If Me.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F = True Then
            Dim turnRect As Rectangle = Me.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(rect)
            Dim screct As New Rectangle(0, 0, TotalData.ViewStyle.ScrData.frmPrint_FormSize.Width, TotalData.ViewStyle.ScrData.frmPrint_FormSize.Height)
            Dim relation As cstRectangle_Cross = spatial.Compare_Two_Rectangle_Position(turnRect, screct)
            If relation = cstRectangle_Cross.cstOuter Then
                Return False
            Else
                If relation = cstRectangle_Cross.cstInclusion Then
                    Return False
                Else
                    Return True
                End If
            End If
        Else
            If spatial.Compare_Two_Rectangle_Position(rect, TotalData.ViewStyle.ScrData.ScrRectangle) = cstRectangle_Cross.cstOuter Then
                Return False
            Else
                Return True
            End If
        End If
    End Function
    ''' <summary>
    ''' オブジェクトが画面内に入るかどうかチェック
    ''' </summary>
    ''' <param name="LayerNum">レイヤ</param>
    ''' <param name="ObjCode">地図ファイル中のオブジェクト番号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Screen_Objcode_In(ByVal LayerNum As Integer, ByVal ObjCode As Integer) As Boolean
        Dim rect As RectangleF = LayerData(LayerNum).MapFileData.MPObj(ObjCode).Circumscribed_Rectangle
        If Me.TotalData.ViewStyle.ScrData.ThreeDMode.Set3D_F = True Then
            Dim turnRect As Rectangle = Me.TotalData.ViewStyle.ScrData.Get_SxSy_With_3D(rect)
            Dim screct As New Rectangle(0, 0, TotalData.ViewStyle.ScrData.frmPrint_FormSize.Width, TotalData.ViewStyle.ScrData.frmPrint_FormSize.Height)
            Dim relation As cstRectangle_Cross = spatial.Compare_Two_Rectangle_Position(turnRect, screct)
            If relation = cstRectangle_Cross.cstOuter Then
                Return False
            Else
                If relation = cstRectangle_Cross.cstInclusion Then
                    Return False
                Else
                    Return True
                End If
            End If
        Else
        If spatial.Compare_Two_Rectangle_Position(rect, TotalData.ViewStyle.ScrData.ScrRectangle) = cstRectangle_Cross.cstOuter Then
            Return False
        Else
            Return True
        End If
        End If

    End Function
    ''' <summary>
    ''' レイヤにダミーオブジェクトとグループを設定する
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="Dummy"></param>
    ''' <param name="DummyGroup"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Set_Dummy_and_Group(ByVal LayerNum As Integer, ByRef Dummy() As String, ByRef DummyGroup() As String) As String
        If LayerData(LayerNum).Type = enmLayerType.Trip_Definition Then
            Return ""
        End If
        Dim DummyEmes As String = ""
        If Dummy Is Nothing = False Then
            Dim DN As Integer = Dummy.Length
            Dim LT As strYMD = LayerData(LayerNum).Time
            With LayerData(LayerNum).Dummy
                .initDummy()
                For i As Integer = 0 To DN - 1
                    Dim k As Integer = LayerData(LayerNum).ObjectNameSearch(Dummy(i), LT)
                    If k <> -1 Then
                        .AddDummy(k, Dummy(i))
                    Else
                        If DummyEmes <> "" Then
                            DummyEmes += "/"
                        End If
                        DummyEmes += Dummy(i)
                    End If
                Next
            End With

        End If

        Dim DummyGroupEmes As String = ""
        If DummyGroup Is Nothing = False Then
            Dim DGN As Integer = DummyGroup.Length
            With LayerData(LayerNum).DummyGroup
                .initDummyObjG()
                For i As Integer = 0 To DGN - 1
                    Dim N As Integer = LayerData(LayerNum).MapFileData.Get_ObjectGroupNumber_By_Name(DummyGroup(i))
                    If N <> -1 Then
                        .AddDummyObjG(N)
                    Else
                        If DummyGroupEmes <> "" Then
                            DummyGroupEmes += "/"
                        End If
                        DummyGroupEmes += DummyGroup(i)
                    End If
                Next
            End With

        End If
        If DummyEmes <> "" And DummyGroupEmes <> "" Then
            DummyEmes += vbCrLf
        End If
        Dim Emes As String = DummyEmes + DummyGroupEmes


        Return Emes
    End Function
    ''' <summary>
    ''' 移動主体定義レイヤの追加
    ''' </summary>
    ''' <param name="LayerName"></param>
    ''' <param name="LayerMapFile"></param>
    ''' <param name="LayerTime"></param>
    ''' <param name="comment"></param>
    ''' <param name="ObjectNum"></param>
    ''' <param name="TripObjData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Add_one_Layer(ByVal LayerName As String, ByVal comment As String, ByVal ObjectNum As Integer, ByRef TripDefinitonName() As String)
        Dim NewLay As Integer

        NewLay = TotalData.LV1.Lay_Maxn
        ReDim Preserve LayerData(NewLay)
        With LayerData(NewLay)
            .Name = LayerName
            .Type = enmLayerType.Trip_Definition
            .Shape = enmShape.NotDeffinition
            With .atrData
                .Count = 0
            End With
            With .atrObject
                .ObjectNum = ObjectNum
                .NumOfSyntheticObj = 0
                ReDim .atrObjectData(.ObjectNum - 1)
                For i As Integer = 0 To .ObjectNum - 1
                    .atrObjectData(i).Name = TripDefinitonName(i)
                    .atrObjectData(i).Visible = True
                Next
            End With
            .initLayerData()
        End With
        TotalData.LV1.Lay_Maxn += 1
    End Function
    ''' <summary>
    ''' 移動レイヤの追加
    ''' </summary>
    ''' <param name="LayerName"></param>
    ''' <param name="LayerMapFile"></param>
    ''' <param name="LayerTime"></param>
    ''' <param name="comment"></param>
    ''' <param name="ObjectNum"></param>
    ''' <param name="TripObjData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Add_one_Layer(ByVal LayerName As String, ByVal LayerMapFile As String, ByVal LayerTime As strYMD, ByVal LayerSystem As enmZahyo_System_Info, ByVal comment As String,
                    ByVal ObjectNum As Integer, ByRef TripObjData() As strTripObjData_Info)
        Dim NewLay As Integer

        NewLay = TotalData.LV1.Lay_Maxn
        ReDim Preserve LayerData(NewLay)
        With LayerData(NewLay)
            If LayerMapFile = "" Then
                LayerMapFile = MapData.GetPrestigeMapFileName
            End If
            .MapFileName = LayerMapFile
            .Set_MapFileData(Me.MapData.SetMapFile(LayerMapFile))
            .SetMapFileObjectNameSearchClass(Me.MapData.SetObject_Name_Search(LayerMapFile))
            .Name = LayerName
            .Type = enmLayerType.Trip
            .ReferenceSystem = LayerSystem
            .MeshType = enmMesh_Number.mhNonMesh
            .Shape = enmShape.NotDeffinition
            .Time = LayerTime
            .Comment = comment
            '.Dummy.
            With .atrData
                .Count = 0
            End With
            With .atrObject
                .ObjectNum = ObjectNum
                ReDim .TripObjData(.ObjectNum - 1)
                For i As Integer = 0 To .ObjectNum - 1
                    .TripObjData(i) = TripObjData(i)
                Next
            End With
            .initLayerData()
        End With

        TotalData.LV1.Lay_Maxn += 1
    End Function
    ''' <summary>
    ''' レイヤの追加（移動レイヤを除く）
    ''' </summary>
    ''' <param name="LayerName"></param>
    ''' <param name="LayerType"></param>
    ''' <param name="LayeMeshType"></param>
    ''' <param name="LayerShape"></param>
    ''' <param name="LayerMapFile"></param>
    ''' <param name="LayerTime"></param>
    ''' <param name="LayerSystem"></param>
    ''' <param name="ObjectNum"></param>
    ''' <param name="ObjData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Add_one_Layer(ByVal LayerName As String, ByVal LayerType As enmLayerType, ByVal LayerMeshType As enmMesh_Number,
                                  ByVal LayerShape As Integer, ByVal LayerMapFile As String,
                                  ByVal LayerTime As strYMD, ByVal LayerSystem As enmZahyo_System_Info, ByVal comment As String,
                        ByVal ObjectNum As Integer, ByRef ObjData() As strObject_Data_Info)
        'レイヤの追加
        Dim NewLay As Integer

        NewLay = TotalData.LV1.Lay_Maxn
        ReDim Preserve LayerData(NewLay)
        With LayerData(NewLay)
            If LayerMapFile = "" Then
                LayerMapFile = MapData.GetPrestigeMapFileName
            End If
            .MapFileName = LayerMapFile
            .Set_MapFileData(Me.MapData.SetMapFile(LayerMapFile))
            .SetMapFileObjectNameSearchClass(Me.MapData.SetObject_Name_Search(LayerMapFile))
            .Name = LayerName
            .Type = LayerType
            .ReferenceSystem = LayerSystem
            .MeshType = LayerMeshType
            .Shape = LayerShape
            .Time = LayerTime
            .Comment = comment
            '.Dummy.
            With .atrData
                .Count = 0
            End With
            With .atrObject
                .ObjectNum = ObjectNum
                .NumOfSyntheticObj = 0
                ReDim .atrObjectData(.ObjectNum - 1)
                For i As Integer = 0 To .ObjectNum - 1
                    .atrObjectData(i) = ObjData(i)
                Next
            End With
            .initLayerData()
        End With

        TotalData.LV1.Lay_Maxn += 1


    End Function
    ''' <summary>
    ''' 地図ファイルをセット
    ''' </summary>
    ''' <param name="MapFIleName">空白の場合、最初に読み込まれた地図ファイル</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetMapFile(ByVal MapFIleName) As clsMapData
        Return Me.MapData.SetMapFile(MapFIleName)
    End Function
    Public Function GetPrestigeZahyoMode() As clsMapData.Zahyo_info
        Return Me.MapData.GetPrestigeZahyoMode
    End Function
    Public Sub New(ByRef _TileMap As clsTileMapService)
        With TotalData
            With .LV1
                .Comment = ""
                .Lay_Maxn = 0
                .SelectedLayer = 0
                .DataSourceType = enmDataSource.NoData
            End With
            With .TotalMode
                With .OverLay
                    .SelectedIndex = 0
                End With
                With .Series
                    .SelectedIndex = 0
                End With

            End With
            .FigureStac = New List(Of Object)
            .BasePicture.PictureNum = 0
            .BasePicture.PictureData = New List(Of Picture_Property)
        End With
        Me.TileMap = _TileMap
    End Sub

    Public Function Select_Color(ByRef pictureBox As PictureBox, ByRef COl As colorARGB) As Boolean
        Dim f As Boolean = clsGeneric.Color_Set(COl)
        If f = True Then
            pictureBox.BackColor = COl.getColor
        End If
        Return f
    End Function
    ''' <summary>
    ''' 記号選択
    ''' </summary>
    ''' <param name="Mark"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Select_Mark(ByRef Mark As Mark_Property) As Boolean
        Return clsGeneric.Mark_Set(Mark, Me)
    End Function
    ''' <summary>
    ''' 記号選択と記号ピクチャーボックスの更新
    ''' </summary>
    ''' <param name="pictureBox"></param>
    ''' <param name="Mark"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Select_Mark(ByRef pictureBox As PictureBox, ByRef Mark As Mark_Property) As Boolean
        Dim f As Boolean = clsGeneric.Mark_Set(Mark, Me)
        If f = True Then
            Me.Draw_Sample_Mark_Box(pictureBox, Mark)
        End If
        Return f
    End Function
    ''' <summary>
    ''' タイル選択
    ''' </summary>
    ''' <param name="T"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Select_Tile(ByRef T As Tile_Property) As Boolean
        Return clsGeneric.Tile_Set(T, Me)
    End Function
    ''' <summary>
    ''' タイル選択とタイルピクチャーボックスの更新
    ''' </summary>
    ''' <param name="T"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Select_Tile(ByRef pictureBox As PictureBox, ByRef T As Tile_Property) As Boolean
        Dim f As Boolean = clsGeneric.Tile_Set(T, Me)
        If f = True Then
            Me.Draw_Sample_TileBox(pictureBox, T)
        End If
        Return f
    End Function
    ''' <summary>
    ''' タイル選択とタイルピクチャーボックスの更新
    ''' </summary>
    ''' <param name="T"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Select_Background(ByRef pictureBox As PictureBox, ByRef bk As BackGround_Box_Property) As Boolean
        Dim f As Boolean = clsGeneric.BackGround_Setting(bk, Me)
        If f = True Then
            Me.Draw_Sample_BackgroundBox(pictureBox, bk)
        End If
        Return f
    End Function
    ''' <summary>
    ''' 線種選択
    ''' </summary>
    ''' <param name="LinePat"></param>
    ''' <param name="DetailFlag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Select_Line_Pattern(ByRef LinePat As Line_Property, ByVal DetailFlag As Boolean) As Boolean
        Return clsGeneric.Line_Pattern_select(LinePat, True, Me)
    End Function
    ''' <summary>
    ''' 線種選択とラインパターンピクチャーボックスの更新
    ''' </summary>
    ''' <param name="pictureBox"></param>
    ''' <param name="LinePat"></param>
    ''' <param name="DetailFlag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Select_Line_Pattern(ByRef pictureBox As PictureBox, ByRef LinePat As Line_Property, ByVal DetailFlag As Boolean) As Boolean
        Dim f As Boolean = clsGeneric.Line_Pattern_select(LinePat, True, Me)
        If f = True Then
            Me.Draw_Sample_LineBox(pictureBox, LinePat)
        End If
        Return f
    End Function
    ''' <summary>
    ''' フォント選択
    ''' </summary>
    ''' <param name="Font"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Select_Font(ByRef Font As Font_Property) As Boolean
        Return clsGeneric.Font_select(Font, Me)
    End Function

    ''' <summary>
    ''' パーセントのサイズが，画面上で何ピクセルかを取得/TotalData.ViewStyle.ScrData.Get_Length_On_Screenのショートカット
    ''' </summary>
    ''' <param name="Percentage"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Get_Length_On_Screen(ByVal Percentage As Single) As Integer
        Get
            With Me.TotalData.ViewStyle.ScrData
                If .SampleBoxFlag = False Then
                    Dim RR As Single = .STDWsize * Percentage / 100 * .ScreenMG.Mul * .GSMul
                    If .OutputDevide = enmOutputDevice.Printer Then
                        RR = RR * .PrinterMG.Mul
                    End If
                    Return CInt(RR)
                Else
                    Return CInt(.STDWsize * Percentage / 100 * .FirstScreenMGMul)
                End If
            End With
        End Get
    End Property

    ''' <summary>
    ''' 最大値に占める指定値の割合に面積比例する画面半径を返す/TotalData.ViewStyle.ScrData.Radiusのショートカット
    ''' </summary>
    ''' <param name="R_Percent">最大半径</param>
    ''' <param name="Value">指定値</param>
    ''' <param name="max_Value">最大値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Radius(ByVal R_Percent As Single, ByVal Value As Double, ByVal max_Value As Double) As Integer
        Return Me.TotalData.ViewStyle.ScrData.Radius(R_Percent, Value, max_Value)
    End Function
    ''' <summary>
    ''' 文字列表示
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="Word"></param>
    ''' <param name="Pos"></param>
    ''' <param name="Font_P"></param>
    ''' <param name="HorizonalAlignment"></param>
    ''' <param name="VerticalAlignment"></param>
    ''' <remarks></remarks>
    Public Function Draw_Print(ByRef g As Graphics, ByVal Word As String, ByVal Pos As Point, ByVal Font_P As Font_Property, _
                            ByVal HorizonalAlignment As enmHorizontalAlignment, ByVal VerticalAlignment As enmVerticalAlignment) As Boolean
        Return clsDraw.print(g, Word, Pos, Font_P, HorizonalAlignment, VerticalAlignment, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Function
    ''' <summary>
    ''' 記号描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="Position"></param>
    ''' <param name="r"></param>
    ''' <param name="Mark"></param>
    ''' <remarks></remarks>
    Public Sub Draw_Mark(ByRef g As Graphics, ByVal Position As Point, ByVal r As Integer, ByRef Mark As Mark_Property)
        clsDrawMarkFan.Mark_Print(g, Position, r, Mark, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub

    ''' <summary>
    ''' Backgroundの余白部分のピクセル数を取得
    ''' </summary>
    ''' <param name="back"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_PaddingPixcel(ByVal back As BackGround_Box_Property) As Integer
        With back
            If .Line.Check_Line_PrintPattern = False And .Tile.TileCode = enmTilePattern.Blank Then
                Return 0
            Else
                Return TotalData.ViewStyle.ScrData.Get_Length_On_Screen(.Padding)
            End If
        End With
    End Function
    ''' <summary>
    ''' 扇形描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="CP"></param>
    ''' <param name="r"></param>
    ''' <param name="start_p"></param>
    ''' <param name="end_p"></param>
    ''' <param name="LPat"></param>
    ''' <param name="TilePat"></param>
    ''' <remarks></remarks>
    Sub Draw_Fan(ByRef g As Graphics, ByVal CP As Point, ByVal r As Integer,
                 ByVal start_p As Double, ByVal end_p As Double, ByRef LPat As Line_Property, ByRef TilePat As Tile_Property)
        clsDrawMarkFan.Draw_Fan(g, CP, r, start_p, end_p, LPat, TilePat, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub
    ''' <summary>
    ''' 楕円描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="Position"></param>
    ''' <param name="XR"></param>
    ''' <param name="YR"></param>
    ''' <param name="Kakudo"></param>
    ''' <param name="L"></param>
    ''' <param name="T"></param>
    ''' <param name="Real_Circle_F"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Draw_DAEN(ByRef g As Graphics, ByVal Position As Point, ByVal XR As Integer, ByVal YR As Integer,
                       ByVal Kakudo As Single, ByRef L As Line_Property, ByRef T As Tile_Property, ByVal Real_Circle_F As Boolean) As Boolean
        Return clsDrawMarkFan.Draw_DAEN(g, Position, XR, YR, Kakudo, L, T, Real_Circle_F, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Function
    Public Sub Draw_Poly_Inner(ByRef g As Graphics, ByRef pxy() As Point, ByRef nPolyP() As Integer, ByVal polyn As Integer,
                                  ByRef T As Tile_Property)
        clsDrawTile.Draw_Poly_Inner(g, pxy, nPolyP, polyn, T, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub

    ''' <summary>
    ''' リージョンを設定してタイル塗りつぶし
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="BoundaryRect">外接四角形</param>
    ''' <param name="pxy">座標列</param>
    ''' <param name="nPolyP">ポリゴンの数</param>
    ''' <param name="polyn">ポリゴンごとのスタック座標位置の配列</param>
    ''' <param name="TilePat">タイルパターン</param>
    ''' <remarks></remarks>
    Public Sub Draw_Tile_Region(ByRef g As Graphics, ByVal BoundaryRect As Rectangle,
            ByRef pxy() As Point, ByRef nPolyP() As Integer, ByVal polyn As Integer, ByRef TilePat As Tile_Property)

        clsDrawTile.Draw_Tile_Region(g, BoundaryRect, pxy, nPolyP, polyn, TilePat, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub
    ''' <summary>
    ''' タイル四角形描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="BoundaryRect"></param>
    ''' <param name="Kakudo"></param>
    ''' <param name="LinePat"></param>
    ''' <param name="TilePat"></param>
    ''' <remarks></remarks>
    Public Sub Draw_Tile_Box(ByRef g As Graphics, ByVal BoundaryRect As Rectangle, ByVal Kakudo As Single,
                                    ByRef LinePat As Line_Property, ByRef TilePat As Tile_Property)
        clsDrawTile.Draw_Tile_Box(g, BoundaryRect, Kakudo, LinePat, TilePat, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub
    ''' <summary>
    ''' 角丸四角形の描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="BoundaryRect"></param>
    ''' <param name="Back"></param>
    ''' <param name="Kakudo"></param>
    ''' <remarks></remarks>
    Public Sub Draw_Tile_RoundBox(ByRef g As Graphics, ByVal BoundaryRect As Rectangle, ByVal Back As BackGround_Box_Property, ByVal Kakudo As Single)
        clsDrawTile.Draw_Tile_RoundBox(g, BoundaryRect, Back, Kakudo, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub
    ''' <summary>
    ''' 矢印の描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="P">矢の先端の座標</param>
    ''' <param name="BeforPoint">矢の先端の座標の1つ前の座標</param>
    ''' <param name="LPat"></param>
    ''' <param name="DArrow"></param>
    ''' <remarks></remarks>
    Public Sub Draw_Arrow(ByVal g As Graphics, ByVal P As PointF, ByVal BeforPoint As PointF,
                     ByRef LPat As Line_Property, ByRef DArrow As Arrow_Data)
        clsDrawLine.Arrow(g, P, BeforPoint, LPat, DArrow, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub

    ''' <summary>
    ''' ライン描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="LinePat"></param>
    ''' <param name="nPoints"></param>
    ''' <param name="pxy"></param>
    ''' <remarks></remarks>
    Public Overloads Sub Draw_Line(ByRef g As Graphics, ByRef LinePat As Line_Property, ByVal nPoints As Integer, ByRef pxy() As Point)
        clsDrawLine.Line(g, LinePat, nPoints, pxy, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub
    ''' <summary>
    ''' ライン描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="LinePat"></param>
    ''' <param name="P1"></param>
    ''' <param name="P2"></param>
    ''' <remarks></remarks>
    Public Overloads Sub Draw_Line(ByRef g As Graphics, ByRef LinePat As Line_Property, ByVal P1 As Point, ByVal P2 As Point)
        clsDrawLine.Line(g, LinePat, P1, P2, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub
    ''' <summary>
    ''' ライン描画
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="LinePat"></param>
    ''' <param name="x1"></param>
    ''' <param name="y1"></param>
    ''' <param name="x2"></param>
    ''' <param name="y2"></param>
    ''' <remarks></remarks>
    Public Overloads Sub Draw_Line(ByRef g As Graphics, ByRef LinePat As Line_Property, ByVal x1 As Integer, ByVal y1 As Integer,
                                   ByVal x2 As Integer, ByVal y2 As Integer)
        clsDrawLine.Line(g, LinePat, New Point(x1, y1), New Point(x2, y2), Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub
    ''' <summary>
    ''' サンプルラインボックスにラインを描画
    ''' </summary>
    ''' <param name="picBox">ピクチャーボックス</param>
    ''' <param name="LinePat">ラインパターン</param>
    ''' <remarks></remarks>
    Public Sub Draw_Sample_LineBox(ByRef picBox As PictureBox, ByRef LinePat As Line_Property)
        clsDrawLine.Draw_Sample_LineBox(picBox, LinePat, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub
    ''' <summary>
    ''' サンプル記号ボックスに記号を描画
    ''' </summary>
    ''' <param name="picBox">ピクチャーボックス</param>
    ''' <param name="Mark">記号</param>
    ''' <remarks></remarks>
    Public Sub Draw_Sample_Mark_Box(ByRef picBox As PictureBox, ByRef Mark As Mark_Property)
        clsDrawMarkFan.Draw_Mark_Sample_Box(picBox, Mark, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)

    End Sub
    ''' <summary>
    ''' 枠線付き背景を描画
    ''' </summary>
    ''' <param name="picBox"></param>
    ''' <param name="Back"></param>
    ''' <remarks></remarks>
    Public Sub Draw_Sample_BackgroundBox(ByRef picBox As PictureBox, ByRef Back As BackGround_Box_Property)
        clsDrawTile.Darw_Sample_BackGroundBox(picBox, Back, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub
    ''' <summary>
    ''' サンプルタイルボックスにタイルを描画
    ''' </summary>
    ''' <param name="picBox">ピクチャーボックス</param>
    ''' <param name="Tile">タイル</param>
    ''' <remarks></remarks>
    Public Sub Draw_Sample_TileBox(ByRef picBox As PictureBox, ByRef Tile As Tile_Property)
        clsDrawTile.Draw_Sample_TileBox(picBox, Tile, Me.TotalData.ViewStyle.ScrData, Me.TotalData.BasePicture)
    End Sub
    ''' <summary>
    ''' タイトル一覧をコンボボックスexに入れる。Number_Print_F=trueの場合は、データの種類毎に選択可否可能
    ''' </summary>
    ''' <param name="cbox">コンボボックスex</param>
    ''' <param name="LayerNum">レイヤ</param>
    ''' <param name="SelectedIndex">初期選択番号</param>
    ''' <param name="Number_Print_F">タイトルの前に番号を振る</param>
    ''' <param name="Normal_F">通常のデータを選択可に</param>
    ''' <param name="Category_f">カテゴリーデータを選択可に</param>
    ''' <param name="String_f">文字列データを選択可に</param>
    ''' <param name="Special_Astarisk_Num">特別にアスタリスクにする番号</param>
    ''' <remarks></remarks>
    Public Sub Set_DataTitle_to_cboBox(ByRef cbox As ComboBoxEx, ByVal LayerNum As Integer, ByVal SelectedIndex As Integer,
                                       Optional ByVal Number_Print_F As Boolean = True,
                                       Optional ByVal Normal_F As Boolean = True, Optional ByVal Category_f As Boolean = True,
                                      Optional ByVal String_f As Boolean = True, Optional ByVal Special_Astarisk_Num As Integer = -1)
        cbox.Items.Clear()
        Dim items As String() = getDataTitleName(LayerNum, Number_Print_F, Normal_F, Category_f, String_f, Special_Astarisk_Num)
        cbox.Items.AddRange(items)
        cbox.MaxDropDownItems = 20
        If SelectedIndex >= cbox.Items.Count Then
            SelectedIndex = cbox.Items.Count - 1
        End If
        cbox.SelectedIndex = SelectedIndex
    End Sub
    ''' <summary>
    ''' タイトル一覧をListボックスexに入れる。Number_Print_F=trueの場合は、データの種類毎に選択可否可能
    ''' </summary>
    ''' <param name="cbox">コンボボックスex</param>
    ''' <param name="LayerNum">レイヤ</param>
    ''' <param name="Number_Print_F">タイトルの前に番号を振る</param>
    ''' <param name="Normal_F">通常のデータを選択可に</param>
    ''' <param name="Category_f">カテゴリーデータを選択可に</param>
    ''' <param name="String_f">文字列データを選択可に</param>
    ''' <param name="Special_Astarisk_Num">特別にアスタリスクにする番号</param>
    ''' <remarks></remarks>
    Public Sub Set_DataTitle_to_ListBox(ByRef Lbox As ListBoxEx, ByVal LayerNum As Integer,
                                       Optional ByVal Number_Print_F As Boolean = True,
                                       Optional ByVal Normal_F As Boolean = True, Optional ByVal Category_f As Boolean = True,
                                      Optional ByVal String_f As Boolean = True, Optional ByVal Special_Astarisk_Num As Integer = -1)
        Lbox.Items.Clear()
        Dim items As String() = getDataTitleName(LayerNum, Number_Print_F, Normal_F, Category_f, String_f, Special_Astarisk_Num)
        Lbox.Items.AddRange(items)
    End Sub
    ''' <summary>
    ''' データ項目をリストボックス選択フォームから選択して返す
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="PreSelected">既定値の配列(戻り値)</param>
    ''' <param name="Number_Print_F"></param>
    ''' <param name="Normal_F"></param>
    ''' <param name="Category_f"></param>
    ''' <param name="String_f"></param>
    ''' <param name="Special_Astarisk_Num"></param>
    ''' <remarks></remarks>
    Public Function Get_DataSelect_from_ListBoxSelectForm(ByVal LayerNum As Integer, ByRef PreSelected() As Boolean,
                                       Optional ByVal Number_Print_F As Boolean = True,
                                       Optional ByVal Normal_F As Boolean = True, Optional ByVal Category_f As Boolean = True,
                                      Optional ByVal String_f As Boolean = True, Optional ByVal Special_Astarisk_Num As Integer = -1) As Boolean
        Dim items As String() = getDataTitleName(LayerNum, Number_Print_F, Normal_F, Category_f, String_f, Special_Astarisk_Num)
        Dim f As Boolean = clsGeneric.Show_ListBoxForm_and_GetResult("データ項目選択", items, PreSelected, frmSelectListBox.enmListType.ListBox)
        Return f
    End Function
    ''' <summary>
    ''' データ項目をコンボボックス選択フォームから選択して返す
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="Number_Print_F">タイトルの前に番号を振る</param>
    ''' <param name="Normal_F">通常のデータを選択可に</param>
    ''' <param name="Category_f">カテゴリーデータを選択可に</param>
    ''' <param name="String_f">文字列データを選択可に</param>
    ''' <param name="Special_Astarisk_Num">特別にアスタリスクにする番号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_DataSelect_fromComboBoxForm(ByVal LayerNum As Integer,
                                       Optional ByVal Number_Print_F As Boolean = True,
                                       Optional ByVal Normal_F As Boolean = True, Optional ByVal Category_f As Boolean = True,
                                      Optional ByVal String_f As Boolean = True, Optional ByVal Special_Astarisk_Num As Integer = -1) As Integer
        Dim items As String() = getDataTitleName(LayerNum, Number_Print_F, Normal_F, Category_f, String_f, Special_Astarisk_Num)

        Return clsGeneric.Show_ComboboxForm_and_GetResult("データ項目", items)
    End Function
    ''' <summary>
    ''' データ項目のタイトルを取得する。Number_Print_F=trueの場合は、データの種類毎に選択可否可能
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="Number_Print_F">タイトルの前に番号を振る</param>
    ''' <param name="Normal_F">通常のデータを選択可に</param>
    ''' <param name="Category_f">カテゴリーデータを選択可に</param>
    ''' <param name="String_f">文字列データを選択可に</param>
    ''' <param name="Special_Astarisk_Num">特別にアスタリスクにする番号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getDataTitleName(ByVal LayerNum As Integer,
                                       Optional ByVal Number_Print_F As Boolean = True,
                                       Optional ByVal Normal_F As Boolean = True, Optional ByVal Category_f As Boolean = True,
                                      Optional ByVal String_f As Boolean = True, Optional ByVal Special_Astarisk_Num As Integer = -1) As String()

        With Me.LayerData(LayerNum).atrData
            Dim n As Integer = Me.Get_DataNum(LayerNum)
            Dim items(n - 1) As String
            For i As Integer = 0 To n - 1
                With .Data(i)
                    Dim itm As String = .Title
                    Dim hd As String = ""
                    If Number_Print_F = True Then
                        If i = Special_Astarisk_Num Then
                            hd = "*"
                        Else
                            hd = CStr(i + 1)
                            Select Case .DataType
                                Case enmAttDataType.Normal
                                    If Normal_F = False Then
                                        hd = "*"
                                    End If
                                Case enmAttDataType.Category
                                    If Category_f = False Then
                                        hd = "*"
                                    End If
                                Case enmAttDataType.Strings
                                    If String_f = False Then
                                        hd = "*"
                                    End If
                            End Select
                        End If
                        itm = hd & ":" + itm
                    End If
                    items(i) = itm
                End With
            Next
            Return items
        End With
    End Function
    ''' <summary>
    ''' レイヤ一覧をコンボボックスexに入れる
    ''' </summary>
    ''' <param name="cbox"></param>
    ''' <param name="SelectedIndex"></param>
    ''' <remarks></remarks>
    Public Sub Set_LayerName_to(ByRef cbox As ComboBoxEx, ByVal SelectedIndex As Integer)
        cbox.Items.Clear()
        For i As Integer = 0 To Me.TotalData.LV1.Lay_Maxn - 1
            cbox.Items.Add(Me.LayerData(i).Name)
        Next
        cbox.MaxDropDownItems = 20
        cbox.SelectedIndex = SelectedIndex
    End Sub
    ''' <summary>
    ''' レイヤ一覧をコンボボックスexに入れる
    ''' </summary>
    ''' <param name="cbox"></param>
    ''' <param name="SelectedIndex"></param>
    ''' <remarks></remarks>
    Public Sub Set_LayerName_to(ByRef cbox As ComboBoxEx, ByVal SelectedIndex As Integer, ByVal NormalF As Boolean, ByVal syntheticF As Boolean, ByVal PointF As Boolean, ByVal MeshF As Boolean, ByVal TripDefinitionF As Boolean, ByVal TripF As Boolean)
        cbox.AsteriskSelectEnabled = False
        cbox.Items.Clear()
        For i As Integer = 0 To Me.TotalData.LV1.Lay_Maxn - 1
            Dim f As Boolean
            Select Case Me.LayerData(i).Type
                Case enmLayerType.Normal
                    If Me.LayerData(i).atrObject.NumOfSyntheticObj > 0 Then
                        If NormalF = True And syntheticF = True Then
                            f = True
                        Else
                            f = False
                        End If
                    Else
                        f = NormalF
                    End If
                Case enmLayerType.DefPoint
                    f = PointF
                Case enmLayerType.Mesh
                    f = MeshF
                Case enmLayerType.Trip_Definition
                    f = TripDefinitionF
                Case enmLayerType.Trip
                    f = TripF
            End Select
            If f = True Then
                cbox.Items.Add(Me.LayerData(i).Name)
            Else
                cbox.Items.Add("*" + Me.LayerData(i).Name)
            End If
        Next
        cbox.MaxDropDownItems = 20
        cbox.SelectedIndex = SelectedIndex
    End Sub
    ''' <summary>
    ''' レイヤ一覧をCheckedListBoxExに入れる
    ''' </summary>
    ''' <param name="cbox"></param>
    ''' <param name="SelectedIndex"></param>
    ''' <remarks></remarks>
    Public Sub Set_LayerName_to(ByRef clb As CheckedListBoxEx, ByVal SelectedIndex As Integer)
        clb.Items.Clear()
        For i As Integer = 0 To Me.TotalData.LV1.Lay_Maxn - 1
            clb.Items.Add(Me.LayerData(i).Name)
        Next
        clb.SelectedIndex = SelectedIndex
    End Sub
    ''' <summary>
    ''' リストボックスexにレイヤ内のオブジェクト一覧と初期設定を入れる
    ''' </summary>
    ''' <param name="lbox">リストボックスex</param>
    ''' <param name="LayerNum">レイヤ番号</param>
    ''' <param name="SelectedObjects">デフォルトで選択するオブジェクト(オプション)</param>
    ''' <remarks></remarks>
    Public Sub Set_ObjectName_to_ListBoxEx(ByRef lbox As ListBoxEx, ByVal LayerNum As Integer, Optional ByVal SelectedObjects() As Integer = Nothing)
        lbox.Items.Clear()
        lbox.BeginUpdate()
        With LayerData(LayerNum).atrObject
            For i As Integer = 0 To .ObjectNum - 1
                lbox.Items.Add(.atrObjectData(i).Name)
            Next
            If SelectedObjects Is Nothing = False Then
                For i As Integer = 0 To SelectedObjects.Length - 1
                    lbox.SetSelected(SelectedObjects(i), True)
                Next
            End If
        End With
        lbox.EndUpdate()
    End Sub
    ''' <summary>
    ''' リストボックスexにレイヤ内のダミーオブジェクト一覧と初期設定を入れる
    ''' </summary>
    ''' <param name="lbox">リストボックスex</param>
    ''' <param name="LayerNum">レイヤ番号</param>
    ''' <param name="SelectedObjects">デフォルトで選択するオブジェクト(オプション)</param>
    ''' <remarks></remarks>
    Public Sub Set_DummyObjectName_to_ListBoxEx(ByRef lbox As ListBoxEx, ByVal LayerNum As Integer, Optional ByVal SelectedObjects() As Integer = Nothing)
        lbox.Items.Clear()
        lbox.BeginUpdate()
        With LayerData(LayerNum).Dummy
            For i As Integer = 0 To .Count - 1
                lbox.Items.Add(.DummyObj(i).Name)
            Next
            If SelectedObjects Is Nothing = False Then
                For i As Integer = 0 To SelectedObjects.Length - 1
                    lbox.SetSelected(SelectedObjects(i), True)
                Next
            End If
        End With
        lbox.EndUpdate()
    End Sub
    ''' <summary>
    ''' データの緯度経度の領域を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function get_DataLatLonBox() As RectangleF

        Dim IdoKedoRect As RectangleF
        Dim Zahyo = TotalData.ViewStyle.Zahyo
        If Zahyo.Mode <> enmZahyo_mode_info.Zahyo_Ido_Keido Then
            Return IdoKedoRect
        End If
        Select Case Zahyo.Projection
            Case enmProjection_Info.prjMercator, enmProjection_Info.prjMiller, enmProjection_Info.prjSeikyoEntou, enmProjection_Info.prjLambertSeisekiEntou
                IdoKedoRect = spatial.Get_Reverse_Rect(TotalData.ViewStyle.ScrData.MapRectangle, Zahyo)
                Return IdoKedoRect
        End Select

        Dim pf As PointF = LayerData(0).atrObject.atrObjectData(0).CenterPoint
        Dim pf2 = spatial.Get_Reverse_XY(pf, Zahyo)
        Dim LLRect As RectangleF = New RectangleF(pf2, New Size(0, 0))
        Dim LineCheck As New Dictionary(Of String, Boolean())
        For i As Integer = 0 To TotalData.LV1.Lay_Maxn - 1
            With LayerData(i)
                If .Type <> enmLayerType.Trip_Definition Then
                    Dim MapFileData As clsMapData = LayerData(i).MapFileData
                    If Not LineCheck.ContainsKey(LayerData(i).MapFileName) Then
                        Dim LineL(MapFileData.Map.ALIN) As Boolean
                        LineCheck.Add(LayerData(i).MapFileName, LineL)
                    End If
                    Dim LC() As Boolean = LineCheck(LayerData(i).MapFileName)
                    Dim LayerTime As strYMD = .Time
                    If TotalData.ViewStyle.Dummy_Size_Flag = True Then
                        'ダミー領域も範囲に含む場合
                        Dim dmObj As New List(Of Integer)
                        If .DummyGroup.Count > 0 Then
                            Dim ObjGIndex(MapFileData.Map.OBKNum - 1) As Boolean
                            For j As Integer = 0 To .DummyGroup.Count - 1
                                ObjGIndex(.DummyGroup.DummyObjG(j)) = True
                            Next
                            For j As Integer = 0 To MapFileData.Map.Kend - 1
                                With MapFileData.MPObj(j)
                                    If ObjGIndex(.Kind) = True Then
                                        dmObj.Add(j)
                                    End If
                                End With
                            Next
                        End If
                        For j As Integer = 0 To .Dummy.Count - 1
                            Dim ocode As Integer = .Dummy.DummyObj(j).code
                            dmObj.Add(ocode)
                        Next
                        For j As Integer = 0 To dmObj.Count - 1
                            If (MapFileData.MPObj(j).Shape = enmShape.PointShape) Then
                                Dim cp As PointF
                                MapFileData.Get_Enable_CenterP(cp, dmObj(j), LayerTime)
                                Dim cp2 As PointF = spatial.Get_Reverse_XY(cp, Zahyo)
                                LLRect = spatial.Get_Circumscribed_Rectangle(cp2, LLRect)
                            Else
                                Dim ELine() As clsMapData.EnableMPLine_Data
                                Dim n As Integer = MapFileData.Get_EnableMPLine(ELine, dmObj(j), LayerTime)
                                For k As Integer = 0 To n - 1
                                    If LC(ELine(k).LineCode) = False Then
                                        getLinelatLon(MapFileData, ELine(k).LineCode, LLRect)
                                        LC(ELine(k).LineCode) = True
                                    End If
                                Next
                            End If
                        Next
                    End If
                    Select Case .Type
                        Case enmLayerType.Trip
                            For j As Integer = 0 To .atrObject.ObjectNum - 1
                                Dim p As PointF
                                Select Case .TripType
                                    Case enmTripPositionType.ObjectSet
                                        With .atrObject.TripObjData(j)
                                            Dim c As Integer = .PositionObjCode
                                            If c >= 0 Then
                                                MapFileData.Get_Enable_CenterP(p, c, LayerTime)
                                            End If
                                        End With
                                    Case enmTripPositionType.LatLon
                                        With .atrObject.TripObjData(j)
                                            p = .LatLon.toPointF
                                        End With
                                End Select
                                Dim cp2 As PointF = spatial.Get_Reverse_XY(p, Zahyo)
                                LLRect = spatial.Get_Circumscribed_Rectangle(cp2, LLRect)
                            Next
                        Case enmLayerType.Mesh
                            For j As Integer = 0 To .atrObject.ObjectNum - 1
                                Dim Meshcode As String = .atrObject.atrObjectData(j).Name
                                Dim RectLatLon As strLatLonBox = spatial.Get_Ido_Kedo_from_MeshCode(Meshcode, .MeshType)
                                LLRect = spatial.Get_Circumscribed_Rectangle(RectLatLon.toRectangleF(), LLRect)
                            Next
                        Case enmLayerType.DefPoint
                            For j As Integer = 0 To .atrObject.ObjectNum - 1
                                Dim p As PointF = spatial.Get_Reverse_XY(.atrObject.atrObjectData(j).CenterPoint, Zahyo)
                                LLRect = spatial.Get_Circumscribed_Rectangle(p, LLRect)
                            Next
                        Case enmLayerType.Normal
                            For j As Integer = 0 To .atrObject.ObjectNum - 1
                                If .Shape = enmShape.PointShape Then
                                    Dim p As PointF = spatial.Get_Reverse_XY(.atrObject.atrObjectData(j).CenterPoint, Zahyo)
                                    LLRect = spatial.Get_Circumscribed_Rectangle(p, LLRect)
                                Else
                                    Dim ELine() As clsMapData.EnableMPLine_Data
                                    Dim n As Integer = Me.Get_Enable_KenCode_MPLine(ELine, i, j)
                                    For k As Integer = 0 To n - 1
                                        Dim cd As Integer = ELine(k).LineCode
                                        If LC(cd) = False Then
                                            getLinelatLon(MapFileData, cd, LLRect)
                                            LC(cd) = True
                                        End If
                                    Next
                                End If
                            Next
                    End Select
                    LineCheck(LayerData(i).MapFileName) = LC
                End If
            End With
        Next

        Return LLRect

    End Function
    Private Sub getLinelatLon(ByRef mapdata As clsMapData, ByVal LineNumber As Integer, ByRef rect As RectangleF)
        With mapdata.MPLine(LineNumber)
            Dim LP(.NumOfPoint - 1) As PointF
            For i As Integer = 0 To .NumOfPoint - 1
                LP(i) = spatial.Get_Reverse_XY(.PointSTC(i), TotalData.ViewStyle.Zahyo)
            Next
            Dim rectf As RectangleF = spatial.Get_Circumscribed_Rectangle(LP, 0, .NumOfPoint)
            rect = spatial.Get_Circumscribed_Rectangle(rect, rectf)
        End With
    End Sub
    ''' 
    ''' 表示領域の最大サイズを求めてMapRectangleに格納する
    ''' 
    ''' 
    Public Sub Check_Vector_Object()
        Dim FirstF As Boolean = False
        Dim ScrRect As RectangleF
        For i As Integer = 0 To TotalData.LV1.Lay_Maxn - 1
            With LayerData(i)
                If .Type <> enmLayerType.Trip_Definition Then
                    Dim MapFileData As clsMapData = .MapFileData
                    Dim LayerTime As strYMD = .Time
                    If TotalData.ViewStyle.Dummy_Size_Flag = True Then
                        'ダミー領域も範囲に含む場合
                        Dim ObjGIndex(.DummyGroup.Count - 1) As Integer
                        For j As Integer = 0 To .DummyGroup.Count - 1
                            ObjGIndex(j) = .DummyGroup.DummyObjG(j)
                        Next
                        For j As Integer = 0 To MapFileData.Map.Kend - 1
                            With MapFileData.MPObj(j)
                                If Array.IndexOf(ObjGIndex, .Kind) <> -1 Then
                                    Dim cxy As PointF
                                    If MapFileData.Get_Enable_CenterP(cxy, j, LayerTime) = True Then
                                        If FirstF = False Then
                                            ScrRect = .Circumscribed_Rectangle
                                            FirstF = True
                                        Else
                                            ScrRect = spatial.Get_Circumscribed_Rectangle(.Circumscribed_Rectangle, ScrRect)
                                        End If
                                    End If
                                End If
                            End With
                        Next
                        For j As Integer = 0 To .Dummy.Count - 1
                            Dim ocode As Integer = .Dummy.DummyObj(j).code
                            If FirstF = False Then
                                Dim cxy As PointF
                                If MapFileData.Get_Enable_CenterP(cxy, ocode, LayerTime) = True Then
                                    If FirstF = False Then
                                        ScrRect = New RectangleF(cxy, New Size(0, 0))
                                        FirstF = True
                                    End If
                                End If
                            End If
                            ScrRect = spatial.Get_Circumscribed_Rectangle(MapFileData.MPObj(ocode).Circumscribed_Rectangle, ScrRect)
                        Next
                    End If
                    Select Case .Type
                        Case enmLayerType.Trip
                            For j As Integer = 0 To .atrObject.ObjectNum - 1
                                Dim p As PointF
                                Select Case .TripType
                                    Case enmTripPositionType.ObjectSet
                                        With .atrObject.TripObjData(j)
                                            Dim c As Integer = .PositionObjCode
                                            If c >= 0 Then
                                                MapFileData.Get_Enable_CenterP(p, c, LayerTime)
                                            End If
                                        End With
                                    Case enmTripPositionType.LatLon
                                        With .atrObject.TripObjData(j)
                                            p = spatial.Get_Converted_XY(.LatLon.toPointF, MapFileData.Map.Zahyo)
                                        End With
                                End Select
                                If FirstF = False Then
                                    ScrRect = New RectangleF(p, New Size(0, 0))
                                    FirstF = True
                                Else
                                    ScrRect = spatial.Get_Circumscribed_Rectangle(p, ScrRect)
                                End If
                            Next
                        Case enmLayerType.Mesh
                            For j As Integer = 0 To .atrObject.ObjectNum - 1
                                Dim Rect As RectangleF = .atrObject.atrObjectData(j).MeshRect
                                If FirstF = False Then
                                    ScrRect = Rect
                                    FirstF = True
                                End If
                                ScrRect = spatial.Get_Circumscribed_Rectangle(Rect, ScrRect)
                            Next
                        Case enmLayerType.DefPoint
                            For j As Integer = 0 To .atrObject.ObjectNum - 1
                                Dim Rect As RectangleF = New RectangleF(.atrObject.atrObjectData(j).CenterPoint, New Size(0, 0))
                                If FirstF = False Then
                                    ScrRect = Rect
                                    FirstF = True
                                End If
                                ScrRect = spatial.Get_Circumscribed_Rectangle(Rect, ScrRect)
                            Next
                        Case enmLayerType.Normal
                            For j As Integer = 0 To .atrObject.ObjectNum - 1
                                Dim ocode As Integer = .atrObject.atrObjectData(j).MpObjCode
                                Select Case .atrObject.atrObjectData(j).Objectstructure
                                    Case enmKenCodeObjectstructure.MapObj
                                        If FirstF = False Then
                                            ScrRect = New RectangleF(.atrObject.atrObjectData(j).CenterPoint, New Size(0, 0))
                                            FirstF = True
                                        End If
                                        ScrRect = spatial.Get_Circumscribed_Rectangle(MapFileData.MPObj(ocode).Circumscribed_Rectangle, ScrRect)
                                    Case enmKenCodeObjectstructure.SyntheticObj
                                        With .atrObject.MPSyntheticObj(ocode)
                                            ScrRect = spatial.Get_Circumscribed_Rectangle(.Circumscribed_Rectangle, ScrRect)
                                        End With
                                End Select
                            Next
                    End Select

                End If
            End With
        Next
        If ScrRect.Width = 0 Then
            ScrRect.X = ScrRect.X - 1
            ScrRect.Width = 2
        End If
        If ScrRect.Height = 0 Then
            ScrRect.Y = ScrRect.Y - 1
            ScrRect.Height = 2

        End If
        TotalData.ViewStyle.ScrData.MapRectangle = ScrRect

        Me.TempData.MapAreaLatLon = get_DataLatLonBox()
    End Sub
    ''' <summary>
    ''' レイヤの形状を実際のオブジェクトの形状に基づいて設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Check_LayerShape() As String
        Dim EMes As String = ""
        For i As Integer = 0 To TotalData.LV1.Lay_Maxn - 1
            With LayerData(i)
                Select Case .Type
                    Case enmLayerType.Normal
                        Dim sp As enmShape = Check_LayerShape_Sub(i, EMes)
                        Select Case .Type
                            Case enmLayerType.Normal
                                Select Case .Shape
                                    Case enmShape.NotDeffinition
                                        .Shape = sp
                                    Case enmShape.PolygonShape
                                        If sp <> enmShape.PolygonShape Then
                                            EMes += "面形状に指定されましたが、" + clsGeneric.ConvertShapeEnumString(sp) + "形状に設定されました。" + vbCrLf
                                            .Shape = sp
                                        End If
                                    Case enmShape.LineShape
                                        If sp = enmShape.PointShape Then
                                            EMes += "線形状に指定されましたが、" + clsGeneric.ConvertShapeEnumString(sp) + "形状に設定されました。" + vbCrLf
                                            .Shape = sp
                                        End If
                                    Case enmShape.PointShape
                                End Select
                        End Select
                    Case enmLayerType.DefPoint
                        .Shape = enmShape.PointShape
                    Case enmLayerType.Mesh
                        If .Shape = enmShape.NotDeffinition Then
                            .Shape = enmShape.PolygonShape
                        End If
                End Select
            End With
        Next
        Return EMes
    End Function
    Public Function Check_LayerShape_Sub(ByVal LayerNum As Integer, ByRef EMes As String) As enmShape
        Dim shapemax As Integer = CType([Enum].GetValues(GetType(enmShape)), Integer()).Max
        Dim SH(shapemax) As Integer
        With LayerData(LayerNum)
            Select Case .Type
                Case enmLayerType.Mesh
                    Return enmShape.PolygonShape
                Case enmLayerType.Trip, enmLayerType.Trip_Definition
                    Return enmShape.NotDeffinition
            End Select

            For j As Integer = 0 To .atrObject.ObjectNum - 1
                Dim D As enmShape
                With .atrObject.atrObjectData(j)
                    If .Objectstructure = enmKenCodeObjectstructure.MapObj Then
                        D = LayerData(LayerNum).MapFileData.MPObj(.MpObjCode).Shape
                    Else
                        D = LayerData(LayerNum).atrObject.MPSyntheticObj(.MpObjCode).Shape
                    End If
                End With
                SH(D) += 1
            Next

            Dim shcount As Integer = 0
            Dim shmax As Integer = SH(0)
            Dim shmaxN As enmShape = enmShape.PointShape
            For j As Integer = 0 To shapemax
                If SH(j) > 0 Then
                    shcount += 1
                    If shmax < SH(j) Then
                        shmax = SH(j)
                        shmaxN = j
                    End If
                End If
            Next
            If shcount > 1 Then
                EMes += "レイヤ：" + .Name + vbCrLf
                EMes += "オブジェクトの形状が混在しています。" + vbCrLf
                EMes += "最も多い形状：" + clsGeneric.ConvertShapeEnumString(shmaxN) + vbCrLf
                EMes += "それ以外の形状のオブジェクト" + vbCrLf
                For j As Integer = 0 To .atrObject.ObjectNum - 1
                    Dim D As enmShape
                    With .atrObject.atrObjectData(j)
                        If .Objectstructure = enmKenCodeObjectstructure.MapObj Then
                            D = LayerData(LayerNum).MapFileData.MPObj(.MpObjCode).Shape
                        Else
                            D = LayerData(LayerNum).atrObject.MPSyntheticObj(.MpObjCode).Shape
                        End If
                    End With
                    If D <> shmaxN Then
                        EMes += .atrObject.atrObjectData(j).Name + "(" + clsGeneric.ConvertShapeEnumString(D) + ")" + vbCrLf
                    End If
                Next
            End If
            Return clsGeneric.checkShape(SH)
        End With
    End Function
    ''' <summary>
    ''' オブジェクトグループ連動型線種の線種決定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LinePatternCheck()
        For Lay As Integer = 0 To TotalData.LV1.Lay_Maxn - 1
            If LayerData(Lay).Type <> enmLayerType.Trip_Definition Then
                Dim MapFileData As clsMapData = LayerData(Lay).MapFileData
                For i As Integer = 0 To MapFileData.Map.LpNum - 1
                    With MapFileData.LineKind(i)
                        If .NumofObjectGroup >= 2 Then
                            For j As Integer = 1 To .NumofObjectGroup - 1
                                Dim Ltmp(MapFileData.Map.ALIN - 1) As Boolean
                                If .ObjGroup(j).UseOnly = False Or
                                    (.ObjGroup(j).UseOnly = True And LayerData(Lay).DummyGroup.Check_DummyObjGExists(.ObjGroup(j).GroupNumber) = True) Then
                                    'データで使われていなくても地図ファイル中で使われていればOK
                                    For k As Integer = 0 To MapFileData.Map.Kend - 1
                                        If MapFileData.MPObj(k).Kind = .ObjGroup(j).GroupNumber Then
                                            'オブジェクトが線種の使用オブジェクトとグループが同じ
                                            Dim ELine() As clsMapData.EnableMPLine_Data
                                            Dim n As Integer = MapFileData.Get_EnableMPLine(ELine, k, LayerData(Lay).Time)
                                            For k2 As Integer = 0 To n - 1
                                                If ELine(k2).Kind = i Then
                                                    Ltmp(ELine(k2).LineCode) = True
                                                End If
                                            Next
                                        End If
                                    Next
                                Else
                                    'データで使われている場合に限る
                                    For k As Integer = 0 To LayerData(Lay).atrObject.ObjectNum - 1
                                        Dim obk As Integer
                                        If LayerData(Lay).atrObject.atrObjectData(k).Objectstructure = enmKenCodeObjectstructure.MapObj Then
                                            obk = MapFileData.MPObj(LayerData(Lay).atrObject.atrObjectData(k).MpObjCode).Kind
                                        Else
                                            obk = LayerData(Lay).atrObject.MPSyntheticObj(LayerData(Lay).atrObject.atrObjectData(k).MpObjCode).Kind
                                        End If
                                        If obk = .ObjGroup(j).GroupNumber Then
                                            Dim ELine() As clsMapData.EnableMPLine_Data
                                            Dim n As Integer = Get_Enable_KenCode_MPLine(ELine, Lay, k)
                                            For k2 As Integer = 0 To n - 1
                                                If ELine(k2).Kind = i Then
                                                    Ltmp(ELine(k2).LineCode) = True
                                                End If
                                            Next
                                        End If
                                    Next
                                End If
                                For k As Integer = 0 To MapFileData.Map.ALIN - 1
                                    If Ltmp(k) = True And LayerData(Lay).ObjectGroupRelatedLine(k) = 0 Then
                                        LayerData(Lay).ObjectGroupRelatedLine(k) = j
                                    End If
                                Next
                            Next
                        End If
                    End With
                Next

            End If

        Next
    End Sub
    ''' <summary>
    ''' ある地点がオブジェクト内部に入るかどうかを調べる
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="ObjNum"></param>
    ''' <param name="MapP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Point_in_Kencode_OneObject(ByVal Layernum As Integer, ByVal ObjNum As Integer, ByVal MapP As PointF) As Boolean
        If LayerData(Layernum).Type = clsAttrData.enmLayerType.Mesh Then
            Dim meshP() As PointF = LayerData(Layernum).atrObject.atrObjectData(ObjNum).MeshPoint
            ReDim Preserve meshP(4)
            meshP(4) = meshP(0)
            Dim ap As New List(Of PointF())
            ap.Add(meshP)
            Return spatial.check_Point_in_Polygon(MapP, ap)
        Else
            Select Case LayerData(Layernum).atrObject.atrObjectData(ObjNum).Objectstructure
                Case enmKenCodeObjectstructure.MapObj
                    Dim O_Code As Integer = LayerData(Layernum).atrObject.atrObjectData(ObjNum).MpObjCode
                    Dim Time As strYMD = LayerData(Layernum).Time
                    Return LayerData(Layernum).MapFileData.Check_Point_in_OneObject(O_Code, MapP.X, MapP.Y, Time)
                Case enmKenCodeObjectstructure.SyntheticObj
                    Dim f As Boolean = Check_Point_in_Kencode_oneObject_Box(Layernum, ObjNum, MapP.X, MapP.Y)
                    If f = True Then
                        Dim ELine() As clsMapData.EnableMPLine_Data
                        Dim n As Integer = Get_Enable_KenCode_MPLine(ELine, Layernum, ObjNum)
                        Dim Fringe_Line(n) As Integer
                        For j As Integer = 0 To n - 1
                            Fringe_Line(j) = ELine(j).LineCode
                        Next
                        Return LayerData(Layernum).MapFileData.Check_Point_in_Polygon_LineCode(MapP.X, MapP.Y, n, Fringe_Line)
                    End If
            End Select
        End If

    End Function
    ''' <summary>
    ''' 'ある地点がオブジェクトの外接四角形に入るかどうかを調べる
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="ObjNum"></param>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_Point_in_Kencode_oneObject_Box(ByVal Layernum As Integer, ByVal ObjNum As Integer,
                                                          ByVal X As Single, ByVal Y As Single) As Boolean

        Dim f As Boolean



        Dim O_Code As Integer = LayerData(Layernum).atrObject.atrObjectData(ObjNum).MpObjCode
        Select Case LayerData(Layernum).atrObject.atrObjectData(ObjNum).Objectstructure
            Case enmKenCodeObjectstructure.MapObj
                f = LayerData(Layernum).MapFileData.Check_Point_in_oneObject_Box(O_Code, X, Y)
            Case enmKenCodeObjectstructure.SyntheticObj
                f = False
                With LayerData(Layernum).atrObject.MPSyntheticObj(O_Code)
                    For i As Integer = 0 To .NumOfObject - 1
                        If .Shape <> enmShape.PointShape Then
                            If spatial.Check_PointInBox(X, Y, 0, .Circumscribed_Rectangle) = True Then
                                f = True
                            End If
                        End If
                    Next
                End With
                Check_Point_in_Kencode_oneObject_Box = f
        End Select
    End Function
    ''' <summary>
    ''' レイヤごとに自動間引きができるかどうかチェック
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub check_AutoSoubyou_Enable()
        ReDim Me.TempData.SoubyouLayerEnable(TotalData.LV1.Lay_Maxn - 1)
        Me.TempData.SoubyouLoopLineArea = New Dictionary(Of Integer, Single())
        For i As Integer = 0 To TotalData.LV1.Lay_Maxn - 1
            With LayerData(i)
                If .Type <> enmLayerType.Trip_Definition Then
                    Dim LoopLineArea(.MapFileData.Map.ALIN - 1) As Single
                    'ダミーオブジェクトグループのチェック
                    Dim ObjGIndex(.MapFileData.Map.OBKNum - 1) As Boolean
                    For j As Integer = 0 To .DummyGroup.Count - 1
                        ObjGIndex(.DummyGroup.DummyObjG(j)) = True
                    Next
                    For j As Integer = 0 To .MapFileData.Map.Kend - 1
                        If ObjGIndex(.MapFileData.MPObj(j).Kind) = True Then
                            Dim ELine() As clsMapData.EnableMPLine_Data
                            Dim n As Integer = .MapFileData.Get_EnableMPLine(ELine, j, .Time)
                            For k As Integer = 0 To n - 1
                                Dim Lcode As Integer = ELine(k).LineCode
                                If LoopLineArea(Lcode) = 0 Then
                                    Dim men As Single = .MapFileData.Get_LoopLine_Menseki(Lcode)
                                    LoopLineArea(Lcode) = men
                                    Me.TempData.SoubyouLayerEnable(i) = True
                                End If
                            Next
                        End If
                    Next
                    'ダミーオブジェクトのチェック
                    For j As Integer = 0 To .Dummy.Count - 1
                        Dim c As Integer = .Dummy.DummyObj(j).code
                        If .MapFileData.MPObj(c).Shape <> enmShape.PointShape Then
                            Dim ELine() As clsMapData.EnableMPLine_Data
                            Dim n As Integer = .MapFileData.Get_EnableMPLine(ELine, c, .Time)
                            For k As Integer = 0 To n - 1
                                Dim Lcode As Integer = ELine(k).LineCode
                                If LoopLineArea(Lcode) = 0 Then
                                    Dim men As Single = .MapFileData.Get_LoopLine_Menseki(Lcode)
                                    LoopLineArea(Lcode) = men
                                    Me.TempData.SoubyouLayerEnable(i) = True
                                End If
                            Next
                            Exit For
                        End If
                    Next
                    If .Type = enmLayerType.Normal Then
                        Select Case .Shape
                            Case enmShape.PointShape
                            Case enmShape.LineShape
                                Me.TempData.SoubyouLayerEnable(i) = True
                            Case enmShape.PolygonShape
                                Dim LUse(.MapFileData.Map.ALIN - 1) As Integer
                                For j As Integer = 0 To Math.Min(.atrObject.ObjectNum, 100) - 1
                                    Dim ELine() As clsMapData.EnableMPLine_Data
                                    Dim n As Integer = Me.Get_Enable_KenCode_MPLine(ELine, i, j)
                                    For k As Integer = 0 To n - 1
                                        LUse(ELine(k).LineCode) += 1
                                        If LUse(ELine(k).LineCode) = 2 Then
                                            Me.TempData.SoubyouLayerEnable(i) = True
                                            j = .atrObject.ObjectNum
                                            Exit For
                                        End If
                                    Next
                                Next
                                If Me.TempData.SoubyouLayerEnable(i) = True Then
                                    'ループオブジェクトの中で、最後に残す一番面積の大きいループを決める
                                    For j As Integer = 0 To .atrObject.ObjectNum - 1
                                        Dim ELine() As clsMapData.EnableMPLine_Data
                                        Dim n As Integer = Me.Get_Enable_KenCode_MPLine(ELine, i, j)
                                        Dim Loop_mens = New clsSortingSearch(VariantType.Single)
                                        Dim LoopOnlyf As Boolean = True
                                        For k As Integer = 0 To n - 1
                                            Dim Lcode As Integer = ELine(k).LineCode
                                            Dim men As Single = LoopLineArea(Lcode)
                                            If men = 0 Then
                                                men = .MapFileData.Get_LoopLine_Menseki(Lcode)
                                                LoopLineArea(Lcode) = men
                                            End If
                                            If men = -1 Then
                                                LoopOnlyf = False
                                            Else
                                                Loop_mens.Add(men)
                                            End If
                                        Next
                                        If LoopOnlyf = True Then
                                            Loop_mens.AddEnd()
                                            Dim lnum As Integer = Loop_mens.DataPositionRev(0)
                                            LoopLineArea(ELine(lnum).LineCode) = -2
                                        End If
                                    Next
                                End If
                        End Select
                    End If
                    Me.TempData.SoubyouLoopLineArea.Add(i, LoopLineArea)
                End If
            End With
        Next
    End Sub

        ''' <summary>
        ''' レイヤごとのオブジェクトの空間インデックス作成
        ''' </summary>
        ''' <remarks></remarks>
    Public Sub PrtObjectSpatialIndex()

        Dim mrect As RectangleF = TotalData.ViewStyle.ScrData.MapRectangle
        For i As Integer = 0 To TotalData.LV1.Lay_Maxn - 1
            LayerData(i).PrtSpatialIndex = New clsSpatialIndexSearch
            With mrect
                Dim obn As Integer = LayerData(i).atrObject.ObjectNum
                Select Case LayerData(i).Shape
                    Case enmShape.PointShape
                        Dim XYSize As Single
                        If obn > 100 Then
                            XYSize = Math.Sqrt(obn) / 2
                        Else
                            XYSize = Math.Sqrt(obn)
                        End If
                        LayerData(i).PrtSpatialIndex.Init(SpatialPointType.SinglePoint, True, .Left, .Top, .Right, .Bottom, (.Right - .Left) / XYSize)
                        For j As Integer = 0 To obn - 1
                            LayerData(i).PrtSpatialIndex.AddSinglePoint(LayerData(i).atrObject.atrObjectData(j).CenterPoint, j)
                        Next
                    Case enmShape.LineShape

                        Dim XYSize As Single = Math.Sqrt(obn) / 4
                        LayerData(i).PrtSpatialIndex.Init(SpatialPointType.SPILine, True, .Left, .Top, .Right, .Bottom, (.Right - .Left) / XYSize)
                        For j As Integer = 0 To obn - 1
                            If LayerData(i).Type = enmLayerType.Mesh Then
                                LayerData(i).PrtSpatialIndex.AddLine(4, LayerData(i).atrObject.atrObjectData(j).MeshPoint, j)
                            Else
                                Dim ELine() As clsMapData.EnableMPLine_Data
                                Dim n As Integer = Get_Enable_KenCode_MPLine(ELine, i, j)
                                For k As Integer = 0 To n - 1
                                    With LayerData(i).MapFileData.MPLine(ELine(k).LineCode)
                                        LayerData(i).PrtSpatialIndex.AddLine(.NumOfPoint, .PointSTC, j)
                                    End With
                                Next
                            End If
                        Next
                    Case enmShape.PolygonShape
                        LayerData(i).PrtSpatialIndex.Init(SpatialPointType.SPIRect, False, .Left, .Top, .Right, .Bottom)
                        For j As Integer = 0 To obn - 1
                            Dim ObjRect As RectangleF = Get_Kencode_Object_Circumscribed_Rectangle(i, j)
                            LayerData(i).PrtSpatialIndex.AddRect(ObjRect, j)
                        Next
                End Select
            End With
            LayerData(i).PrtSpatialIndex.AddEnd()
        Next

    End Sub
        ''' <summary>
        ''' 移動主体定義レイヤの位置を取得、見つからない場合は-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_Trip_Definition_Layer_Number() As Integer
        Dim n As Integer = -1
        For i As Integer = 0 To Me.TotalData.LV1.Lay_Maxn - 1
            If Me.LayerData(i).Type = enmLayerType.Trip_Definition Then
                n = i
            End If
        Next
        Return n
    End Function
        ''' <summary>
        ''' 移動データレイヤの位置をListで返す
        ''' </summary>
        ''' <param name="LayNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_Trip_Layer() As List(Of Integer)
        Dim la As New List(Of Integer)
        Dim n As Integer = -1
        For i As Integer = 0 To Me.TotalData.LV1.Lay_Maxn - 1
            If Me.LayerData(i).Type = enmLayerType.Trip Then
                la.Add(i)
            End If
        Next
        Return la
    End Function
        ''' <summary>
        ''' データ項目のタイプを取得
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="DataNum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_DataType(ByVal Layernum As Integer, ByVal DataNum As Integer) As enmAttDataType
        Return Me.LayerData(Layernum).atrData.Data(DataNum).DataType
    End Function
        ''' <summary>
        ''' データ項目の注を取得
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="DataNum"></param>
        ''' <param name="PreFixDataNumberFlag">データ項目の位置をヘッダにつける</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Overloads Function Get_DataNote(ByVal Layernum As Integer, ByVal DataNum As Integer) As String
        Return Me.LayerData(Layernum).atrData.Data(DataNum).Note
    End Function
        ''' <summary>
        ''' データ項目のタイトルを取得
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="DataNum"></param>
        ''' <param name="PreFixDataNumberFlag">データ項目の位置をヘッダにつける</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Overloads Function Get_DataTitle(ByVal Layernum As Integer, ByVal DataNum As Integer, ByVal PreFixDataNumberFlag As Boolean) As String
        Dim tx As String = Me.LayerData(Layernum).atrData.Data(DataNum).Title
        If PreFixDataNumberFlag = True Then
            tx = CStr(DataNum + 1) + ":" + tx
        End If
        Return tx
    End Function
        ''' <summary>
        ''' データ項目のタイトルをレイヤ一括で取得
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="PreFixDataNumberFlag"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Overloads Function Get_DataTitle(ByVal Layernum As Integer, ByVal PreFixDataNumberFlag As Boolean) As String()
        With LayerData(Layernum).atrData
            Dim ttl(.Count - 1) As String
            For i As Integer = 0 To .Count - 1
                ttl(i) = .Data(i).Title
                If PreFixDataNumberFlag = True Then
                    ttl(i) = CStr(i + 1) + ":" + ttl(i)
                End If
            Next
            Return ttl
        End With
    End Function
        ''' <summary>
        ''' データ項目の単位を取得
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="DataNum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Overloads Function Get_DataUnit(ByVal Layernum As Integer, ByVal DataNum As Integer) As String
        Return Me.LayerData(Layernum).atrData.Data(DataNum).Unit
    End Function
        ''' <summary>
        ''' データ項目の単位をレイヤ一括で取得
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Overloads Function Get_DataUnit(ByVal Layernum As Integer) As String()
        With LayerData(Layernum).atrData
            Dim unt(.Count - 1) As String
            For i As Integer = 0 To .Count - 1
                unt(i) = .Data(i).Unit
            Next
            Return unt
        End With
    End Function
        ''' <summary>
        ''' データ項目の単位を取得
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="DataNum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_DataUnit_With_Kakko(ByVal Layernum As Integer, ByVal DataNum As Integer) As String
        Dim tx As String = ""
        If Me.LayerData(Layernum).atrData.Data(DataNum).DataType = enmAttDataType.Normal Then
            tx = Get_DataUnit(Layernum, DataNum)
            If tx <> "" Then
                tx = "(" + tx + ")"
            End If
        End If
        Return tx
    End Function

        ''' <summary>
        ''' データ項目の最大値を取得
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="DataNum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_DataMax(ByVal Layernum As Integer, ByVal DataNum As Integer) As Double
        Return Me.LayerData(Layernum).atrData.Data(DataNum).Statistics.Max
    End Function
        ''' <summary>
        ''' データ項目の最小値を取得
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="DataNum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_DataMin(ByVal Layernum As Integer, ByVal DataNum As Integer) As Double
        Return Me.LayerData(Layernum).atrData.Data(DataNum).Statistics.Min
    End Function
        ''' <summary>
        ''' レイヤのデータ項目数を取得
        ''' </summary>
        ''' <param name="LayerNum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_DataNum(ByVal LayerNum As Integer) As Integer
        Return Me.LayerData(LayerNum).atrData.Count
    End Function
        ''' <summary>
        ''' データ項目の欠損値の数を取得
        ''' </summary>
        ''' <param name="LayerNum"></param>
        ''' <param name="DataNum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_DataMissingNum(ByVal LayerNum As Integer, ByVal DataNum As Integer) As Integer
        Return Me.LayerData(LayerNum).atrData.Data(DataNum).MissingValueNum
    End Function
        ''' <summary>
        ''' 単独表示モードのモードを取得/設定
        ''' </summary>
        ''' <param name="LayerNum"></param>
        ''' <param name="DataNum"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Property SoloMode(ByVal LayerNum As Integer, ByVal DataNum As Integer) As enmSoloMode_Number
        Get
        Return Me.LayerData(LayerNum).atrData.Data(DataNum).ModeData
        End Get
        Set(value As enmSoloMode_Number)
        Me.LayerData(LayerNum).atrData.Data(DataNum).ModeData = value
        End Set
    End Property
        ''' <summary>
        ''' 指定したレイヤのデータ項目・オブジェクトの階級区分の際の位置を取得する。欠損値の場合は-1を返す
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="DataNum"></param>
        ''' <param name="Objectnum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_Categoly(ByVal Layernum As Integer, ByVal DataNum As Integer, ByVal Objectnum As Integer) As Integer

        With LayerData(Layernum).atrData.Data(DataNum)
            Dim Div_Num As Integer = .SoloModeViewSettings.Div_Num
            Dim sj As Integer
            If .MissingF = True And .Value(Objectnum) = "" Then
                sj = -1
            Else
                Select Case .DataType
                    Case enmAttDataType.Normal
                        sj = Div_Num - 1
                        Dim H As Double = Val(.Value(Objectnum))
                        For j As Integer = 0 To Div_Num - 2
                            If H >= .SoloModeViewSettings.Class_Div(j).Value Then
                                sj = j
                                Exit For
                            End If
                        Next
                    Case enmAttDataType.Category
                        For j As Integer = 0 To Div_Num - 1
                            If .Value(Objectnum) = .SoloModeViewSettings.Class_Div(j).Cat_Name Then
                                sj = j
                                Exit For
                            End If
                        Next
                End Select
            End If
            Return sj
        End With
    End Function
        ''' <summary>
        ''' 指定したレイヤのデータ項目の全オブジェクトの階級区分の際の位置を配列で取得する。欠損値は-1
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="DataNum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_Categoly(ByVal Layernum As Integer, ByVal DataNum As Integer) As Integer()

        Dim obn As Integer = LayerData(Layernum).atrObject.ObjectNum
        Dim Category_Array(obn - 1) As Integer

        For i As Integer = 0 To obn - 1
            Category_Array(i) = Get_Categoly(Layernum, DataNum, i)
        Next

        Return Category_Array
    End Function
        ''' <summary>
        ''' データ項目の階級区分の文字を取得
        ''' </summary>
        ''' <param name="DataNum"></param>
        ''' <param name="Layernum"></param>
        ''' <param name="Reverse_Flag"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Function Get_ClassDIV_Words(ByVal Layernum As Integer, ByVal DataNum As Integer, ByVal Reverse_Flag As Boolean) As String()
        '
        Dim V_DVN As Integer

        Dim DVN As Integer = Get_Class_Div_Number(V_DVN, Layernum, DataNum)
        Dim w(DVN - 1) As String

        With LayerData(Layernum).atrData.Data(DataNum)
            For i As Integer = 0 To V_DVN - 1
                Dim i2 As Integer
                Dim a As String
                Dim oa As String
                If Reverse_Flag = True Then
                    i2 = V_DVN - 1 - i
                Else
                    i2 = i
                End If
                If .DataType = enmAttDataType.Normal Then
                    If i <> DVN Then
                        a = CStr(.SoloModeViewSettings.Class_Div(i).Value)
                    End If
                    Select Case i
                        Case 0
                            w(i2) = a & "≦ x"
                        Case V_DVN - 1
                            w(i2) = "x ＜" & oa & .Unit
                        Case Else
                            w(i2) = a & "≦ x ＜" & oa
                    End Select
                    oa = a
                Else
                    w(i2) = .SoloModeViewSettings.Class_Div(i).Cat_Name
                End If
            Next
            If .MissingValueNum > 0 Then
                w(DVN - 1) = "欠損値"
            End If
        End With

        Return w
    End Function


        ''' <summary>
        ''' データ項目の階級区分数を取得（欠損値がある場合は+1）
        ''' </summary>
        ''' <param name="V_DVN">最大のカテゴリーの番号（欠損値がある場合に関数の戻り値と異なる）</param>
        ''' <param name="DataNum"></param>
        ''' <param name="Layernum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Function Get_Class_Div_Number(ByRef V_DVN As Integer, ByVal Layernum As Integer, ByVal DataNum As Integer) As Integer
        '
        'V_DVN:
        Dim DVN As Long

        DVN = Get_DivNum(Layernum, DataNum)

        V_DVN = DVN
        If Get_Att_Missing_Num(Layernum, DataNum) > 0 Then
            DVN += 1
        End If
        Return DVN
    End Function
        ''' <summary>
        ''' 指定したレイヤのデータ項目の階級区分数を取得
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="DataNum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Function Get_DivNum(ByVal Layernum As Integer, ByVal DataNum As Integer) As Long

        Return LayerData(Layernum).atrData.Data(DataNum).SoloModeViewSettings.Div_Num

    End Function
        ''' <summary>
        ''' レイヤ名を取得
        ''' </summary>
        ''' <param name="LayerNum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Overloads Function Get_LayerName(ByVal LayerNum As Integer) As String
        Dim LN As String = LayerData(LayerNum).Name

        Return LN
    End Function
        ''' <summary>
        ''' レイヤ名を一括取得
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Overloads Function Get_LayerName() As String()
        Dim n As Integer = TotalData.LV1.Lay_Maxn
        Dim Ln(n - 1) As String
        For i As Integer = 0 To n - 1
            Ln(i) = LayerData(i).Name
        Next
        Return Ln
    End Function
        ''' <summary>
        ''' レイヤ内のオブジェクトのオブジェクト名を取得
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="Objectnum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_KenObjName(ByVal Layernum As Integer, ByVal Objectnum As Integer) As String
        Select Case LayerData(Layernum).Type
            Case enmLayerType.Trip
                Return LayerData(Layernum).atrObject.TripObjData(Objectnum).TripPersonName
            Case Else
                Return LayerData(Layernum).atrObject.atrObjectData(Objectnum).Name
        End Select
    End Function
        ''' <summary>
        ''' レイヤ内のオブジェクトのオブジェクト番号(地図ファイル中)を取得
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="Objectnum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_KenObjCode(ByVal Layernum As Integer, ByVal Objectnum As Integer) As Integer
        Select Case LayerData(Layernum).Type
            Case enmLayerType.Trip
                Return LayerData(Layernum).atrObject.TripObjData(Objectnum).TripPersonCode
            Case enmLayerType.Trip_Definition
            Case Else
                Return LayerData(Layernum).atrObject.atrObjectData(Objectnum).MpObjCode
        End Select
    End Function
        ''' <summary>
        ''' 指定したレイヤに指定したオブジェクト名が存在する場合はその位置、存在しない場合は-1を返す
        ''' </summary>
        ''' <param name="serachObjName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Search_ObjName(ByVal Layernum As Integer, ByVal searchObjName As String) As Integer
        For i As Integer = 0 To LayerData(Layernum).atrObject.ObjectNum - 1
            With LayerData(Layernum).atrObject.atrObjectData(i)
                If .Name = searchObjName Then
                    Return i
                End If
            End With
        Next
        Return -1
    End Function
        ''' <summary>
        ''' レイヤのオブジェクト数を求める
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_ObjectNum(ByVal Layernum As Integer) As Integer
        Return LayerData(Layernum).atrObject.ObjectNum
    End Function

        ''' <summary>
        ''' 単独表示モードで選択中のデータ項目のタイトルを返す
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_SelectedDataTitle() As String
        Dim L As Integer = TotalData.LV1.SelectedLayer
        Dim D As Integer = LayerData(L).atrData.SelectedIndex
        Return LayerData(L).atrData.Data(D).Title
    End Function


        Private LineKindUse() As Boolean
        ''' <summary>
        ''' 計算済み座標と使用線種をリセットする
        ''' </summary>
        ''' <remarks></remarks>
    Public Sub ResetMPSubLineXY()
        MPSubLine.Clear()
        Dim FList() As String = MapData.GetMapFileName
        For i As Integer = 0 To MapData.GetNumOfMapFile - 1
            Dim MPSubLinePointXY(MapData.SetMapFile(FList(i)).Map.ALIN - 1) As strGetLinePointAPI_Info
            MPSubLine.Add(FList(i), MPSubLinePointXY)
        Next
        ReDim LineKindUse(Me.GetAllMapLineKindNum - 1)
        Me.TempData.PointObjectKindUsedStack = New Stack(Of strObjectKindUsed_Info)
    End Sub
        ''' <summary>
        ''' 点ダミーオブジェクトの凡例表示用に記録する
        ''' </summary>
        ''' <param name="MapFilename"></param>
        ''' <param name="ObjKindNumber"></param>
        ''' <param name="MK"></param>
        ''' <remarks></remarks>
    Public Sub AddPointObjectKindUsed(ByVal MapFilename As String, ByVal ObjKindNumber As Integer, ByVal MK As Mark_Property)
        For Each Ob As strObjectKindUsed_Info In Me.TempData.PointObjectKindUsedStack
            If Ob.MapFileName = MapFilename And Ob.ObjectKindNumber = ObjKindNumber Then
                '記録済み
                Return
            End If
        Next
        Dim newObk As strObjectKindUsed_Info
        With newObk
            .MapFileName = MapFilename
            .ObjectKindNumber = ObjKindNumber
            .Mark = MK
            .ObjectKindName = Me.SetMapFile(MapFilename).ObjectKind(ObjKindNumber).Name
        End With
        Me.TempData.PointObjectKindUsedStack.Push(newObk)
    End Sub
        ''' <summary>
        ''' オブジェクトの表示チェックをクリア
        ''' </summary>
        ''' <remarks></remarks>
    Public Sub ResetObjectPrintedCheckFlag()

        Me.TempData.ObjectPrintedCheckFlag = New Boolean(TotalData.LV1.Lay_Maxn - 1)() {}

        For i As Integer = 0 To TotalData.LV1.Lay_Maxn - 1
            Me.TempData.ObjectPrintedCheckFlag(i) = New Boolean(Me.LayerData(i).atrObject.ObjectNum - 1) {}
        Next

    End Sub
        ''' <summary>
        ''' MPSubLine.Drawnの値をfalseにする
        ''' </summary>
        ''' <param name="MapFileName">地図ファイル</param>
        ''' <remarks></remarks>
    Public Sub ResetMPSubLineDrawn(ByVal MapFileName As String)

        Dim LinePoint As strGetLinePointAPI_Info() = MPSubLine(MapFileName.ToUpper)
        For i As Integer = 0 To LinePoint.Length - 1
            LinePoint(i).Drawn = False
        Next
        MPSubLine(MapFileName.ToUpper) = LinePoint
    End Sub
    Public Property MpLineDrawn(ByVal MapFileName As String, ByVal LineCode As Integer) As Boolean
        Get
        Return MPSubLine(MapFileName.ToUpper)(LineCode).Drawn
        End Get
        Set(value As Boolean)
        Dim LinePoint As strGetLinePointAPI_Info() = MPSubLine(MapFileName.ToUpper)
        LinePoint(LineCode).Drawn = value
        MPSubLine(MapFileName.ToUpper) = LinePoint
        End Set
    End Property
        ''' <summary>
        ''' 線種の使用チェック
        ''' </summary>
        ''' <param name="MapFileName"></param>
        ''' <param name="lineKindNum"></param>
        ''' <param name="PatternNum"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Property LineKindUseChecked(ByVal MapFileName As String, ByVal lineKindNum As Integer, ByVal PatternNum As Integer) As Boolean
        Get
        Dim n As Integer = MapData.GetLineKindPosition(MapFileName, lineKindNum, PatternNum)
        Return LineKindUse(n)
        End Get
        Set(value As Boolean)
        Dim n As Integer = MapData.GetLineKindPosition(MapFileName, lineKindNum, PatternNum)
        LineKindUse(n) = value

        End Set
    End Property
        ''' <summary>
        ''' 線種の使用状況を習得
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_LineKindUsedList() As Boolean()
        Return LineKindUse
    End Function
        ''' <summary>
        ''' 地図データの保存してある計算済み座標を取得する
        ''' </summary>
        ''' <param name="MapFileName"></param>
        ''' <param name="LineCode"></param>
        ''' <param name="XY"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Get_MPSubLineXY(ByVal MapFileName As String, ByVal LineCode As Integer, ByRef XY() As Point, ByVal ReverseF As Boolean) As Boolean
        Dim LinePoint As strGetLinePointAPI_Info() = MPSubLine(MapFileName.ToUpper)
        Dim MPSubLinePointXY As strGetLinePointAPI_Info = LinePoint(LineCode)
        With MPSubLinePointXY
            If .GetF = True Then
                If ReverseF = .ReverseF Then
                    XY = MPSubLinePointXY.Point.Clone
                Else
                    '反転コピー
                    With MPSubLinePointXY
                        Dim np = .Point.Length - 1
                        ReDim XY(np)
                        For i As Integer = 0 To np
                            XY(i) = .Point(np - i)
                        Next
                    End With
                End If
            End If
            Return .GetF
        End With
    End Function
        ''' <summary>
        ''' 変換した座標を計算済み座標に登録
        ''' </summary>
        ''' <param name="MapFileName"></param>
        ''' <param name="LineCode"></param>
        ''' <param name="XY"></param>
        ''' <param name="ReverseF"></param>
        ''' <remarks></remarks>
    Public Sub Set_MPSubLineXY(ByVal MapFileName As String, ByVal LineCode As Integer, ByRef XY() As Point, ByVal ReverseF As Boolean)

        Dim LinePoint As strGetLinePointAPI_Info() = MPSubLine(MapFileName.ToUpper)
        With LinePoint(LineCode)
            .GetF = True
            .ReverseF = ReverseF
            .Point = XY.Clone
        End With
        MPSubLine(MapFileName.ToUpper) = LinePoint
    End Sub

        ''' <summary>
        ''' 属性検索条件･オブジェクト限定のチェック
        ''' </summary>
        ''' <param name="Layernum"></param>
        ''' <param name="Obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function Check_Condition(ByVal Layernum As Integer, ByVal Obj As Integer) As Boolean

        If Obj = -1 Then
            '移動データで主体定義が無い場合
            Return True
        End If
        If Me.LayerData(Layernum).atrObject.atrObjectData(Obj).Visible = False And Me.TotalData.ViewStyle.ObjectLimitationF = True Then
            Return False
        End If

        Dim af As Boolean = True
        With TotalData.Condition
            For ic As Integer = 0 To .Count - 1
                Dim d As strCondition_DataSet_Info = .Item(ic)
                If d.Enabled = True And d.Layer = Layernum Then
                    For i As Integer = 0 To d.Condition_Class.Count - 1
                        With d.Condition_Class(i)
                            If .And_OR = enmConditionAnd_Or._And Then
                                af = True
                            Else
                                af = False
                            End If
                            For j As Integer = 0 To .Condition.Count - 1
                                Dim f As Boolean
                                With .Condition(j)
                                    Dim V As String = Get_Data_Value(Layernum, .Data, Obj, vbTab)
                                    If V = vbTab Then
                                        '欠損値の場合
                                        f = False
                                    Else
                                        Select Case Get_DataType(Layernum, .Data)
                                            Case enmAttDataType.Category, enmAttDataType.Strings
                                                f = False
                                                Select Case .Condition
                                                    Case enmCondition.Less
                                                        If V < .Val Then f = True
                                                    Case enmCondition.LessEqual
                                                        If V <= .Val Then f = True
                                                    Case enmCondition.Equal
                                                        If V = .Val Then f = True
                                                    Case enmCondition.GreaterEqual
                                                        If V >= .Val Then f = True
                                                    Case enmCondition.Greater
                                                        If V > .Val Then f = True
                                                    Case enmCondition.NotEqual
                                                        If V <> .Val Then f = True
                                                    Case enmCondition.Include
                                                        If V.IndexOf(.Val) <> -1 Then f = True
                                                    Case enmCondition.Exclude
                                                        If V.IndexOf(.Val) = -1 Then f = True
                                                    Case enmCondition.Head
                                                        If Microsoft.VisualBasic.Left(V, Len(.Val)) = .Val Then f = True
                                                    Case enmCondition.Foot
                                                        If Microsoft.VisualBasic.Right(V, Len(.Val)) = .Val Then f = True
                                                End Select
                                            Case Else
                                                Dim av As Double = Val(V)
                                                f = False
                                                Select Case .Condition
                                                    Case enmCondition.Less
                                                        If av < .Val Then f = True
                                                    Case enmCondition.LessEqual
                                                        If av <= .Val Then f = True
                                                    Case enmCondition.Equal
                                                        If av = .Val Then f = True
                                                    Case enmCondition.GreaterEqual
                                                        If av >= .Val Then f = True
                                                    Case enmCondition.Greater
                                                        If av > .Val Then f = True
                                                    Case enmCondition.NotEqual
                                                        If av <> .Val Then f = True
                                                    Case enmCondition.Include
                                                        If V.IndexOf(.Val) <> -1 Then f = True
                                                    Case enmCondition.Exclude
                                                        If V.IndexOf(.Val) = -1 Then f = True
                                                    Case enmCondition.Head
                                                        If Microsoft.VisualBasic.Left(V, Len(.Val)) = .Val Then f = True
                                                    Case enmCondition.Foot
                                                        If Microsoft.VisualBasic.Right(V, Len(.Val)) = .Val Then f = True
                                                End Select
                                        End Select
                                    End If
                                End With
                                If .And_OR = enmConditionAnd_Or._And Then
                                    If f = False Then
                                        af = False
                                        Exit For
                                    End If
                                Else
                                    If f = True Then
                                        af = True
                                        Exit For
                                    End If
                                End If
                            Next
                        End With
                        If af = False Then
                            Exit For
                        End If
                    Next
                End If
                If af = False Then
                    Exit For

                End If
            Next

            Return af
        End With
    End Function
    ''' <summary>
    ''' 階級記号、記号の大きさモードなどの内部データ設定の際に、内部データの色またはハッチを返す
    ''' </summary>
    ''' <param name="InnerData"></param>
    ''' <param name="Layernum"></param>
    ''' <param name="CategoryPos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_InnerTile(ByVal InnerData As strInner_Data_Info, ByVal Layernum As Integer, ByVal CategoryPos As Integer) As Tile_Property
        Dim T As Tile_Property

        With InnerData
            Select Case .Mode
                Case enmInner_Data_Info_Mode.ClassPaint
                    If CategoryPos = -1 Then
                        T = TotalData.ViewStyle.Missing_Data.PaintTile
                    Else
                        T = clsBase.Tile
                        T.Line.BasicLine.SolidLine.Color = LayerData(Layernum).atrData.Data(.Data).SoloModeViewSettings.Class_Div(CategoryPos).PaintColor
                    End If
                Case enmInner_Data_Info_Mode.ClassHatch
                    If CategoryPos = -1 Then
                        T = TotalData.ViewStyle.Missing_Data.HatchTile
                    Else
                        T = LayerData(Layernum).atrData.Data(.Data).SoloModeViewSettings.Class_Div(CategoryPos).TilePat
                    End If
            End Select
        End With
        Return T
    End Function

    ''' <summary>
    ''' 設定した状態で描画可能か調べる
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_PrintError(ByRef Message As String) As enmPrint_Enable

        Dim LV1E As Boolean = False
        Dim LV2E As Boolean = False

        Dim Layernum As Integer = Me.TotalData.LV1.SelectedLayer
        Dim DataNum As Integer = Me.LayerData(Layernum).atrData.SelectedIndex

        Dim mes As String = ""
        Select Case Me.TotalData.LV1.Print_Mode_Total
            Case enmTotalMode_Number.DataViewMode
                Select Case Me.LayerData(Layernum).Print_Mode_Layer
                    Case enmLayerMode_Number.SoloMode
                        If Me.LayerData(Layernum).Type = enmLayerType.Trip_Definition Then
                            mes += "移動主体定義レイヤを表示することは出来ません。" + vbCrLf
                            LV1E = True
                        ElseIf Me.LayerData(Layernum).Type = enmLayerType.Trip Then
                            mes += "移動データレイヤを単独表示モードで表示することは出来ません。" + vbCrLf
                            LV1E = True
                        ElseIf Me.Get_DataNum(Layernum) = 0 Then
                            mes += "データがありません。" + vbCrLf
                            LV1E = True
                        Else
                            With Me.LayerData(Layernum).atrData.Data(DataNum)
                                Dim DataMax As Double = .Statistics.Max
                                Dim DataMin As Double = .Statistics.Min
                                Dim md As enmSoloMode_Number = .ModeData
                                If md = enmSoloMode_Number.ContourMode And
                                        (.SoloModeViewSettings.ContourMD.Interval_Mode = enmContourIntervalMode.ClassPaint Or
                                         .SoloModeViewSettings.ContourMD.Interval_Mode = enmContourIntervalMode.ClassHatch) Then
                                    md = enmSoloMode_Number.ClassPaintMode
                                End If
                                Select Case md
                                    Case enmSoloMode_Number.ClassPaintMode, enmSoloMode_Number.ClassHatchMode, enmSoloMode_Number.ClassMarkMode, enmSoloMode_Number.ClassODMode
                                        Dim ef As Integer = 0
                                        If Me.Get_DataType(Layernum, DataNum) = enmAttDataType.Normal Then
                                            For i As Integer = 0 To .SoloModeViewSettings.Div_Num - 2
                                                Dim v As Double = .SoloModeViewSettings.Class_Div(i).Value
                                                If v > DataMax Or v < DataMin Then
                                                    ef = 2
                                                End If
                                                If i <> 0 Then
                                                    If .SoloModeViewSettings.Class_Div(i - 1).Value <= v Then
                                                        ef = 1
                                                    End If
                                                End If
                                            Next
                                        End If
                                        If ef = 2 Then
                                            mes += "区分値の最小値または最大値の値が、データの最小値～最大値の値を越えています。" + vbCrLf
                                            LV2E = True
                                        End If
                                        If ef = 1 Then
                                            mes += "区分値が不正です" + vbCrLf
                                            LV1E = True
                                        End If
                                    Case enmSoloMode_Number.MarkSizeMode
                                    Case enmSoloMode_Number.ContourMode
                                        With .SoloModeViewSettings.ContourMD
                                            Select Case .Interval_Mode
                                                Case enmContourIntervalMode.RegularInterval
                                                    With .Regular
                                                        If .Interval <= 0 Then
                                                            mes += "通常の等値線：間隔は0よりも大きくして下さい。" + vbCrLf
                                                            LV1E = True
                                                        End If
                                                        If .bottom > DataMax Or .top < DataMin Then
                                                            mes += "通常の等値線：下限値または上限値が不正です。" + vbCrLf
                                                            LV1E = True
                                                        End If
                                                        If .top < .bottom Then
                                                            mes += "通常の等値線：下限値が上限値よりも大きくなっています。"
                                                            LV1E = True
                                                        End If

                                                        If .SP_interval <= 0 Then
                                                            mes += "強調する等値線：間隔は0よりも大きくして下さい。" + vbCrLf
                                                            LV1E = True
                                                        End If
                                                        If .SP_Bottom > DataMax Or .SP_Top < DataMin Then
                                                            mes += "強調する等値線：下限値または上限値が不正です。" + vbCrLf
                                                            LV1E = True
                                                        End If
                                                        If .SP_Top < .SP_Bottom Then
                                                            mes += "強調する等値線：下限値が上限値よりも大きくなっています。"
                                                            LV1E = True
                                                        End If
                                                        If .EX_Value_Flag = True And (.EX_Value > DataMax Or .top < .EX_Value) Then
                                                            mes += "一本だけ強調する等値線の値が不正です。"
                                                            LV2E = True
                                                        End If
                                                        If LV1E = False Then
                                                            Dim contn As Integer = Int((Math.Max(.top, DataMax) - Math.Min(.bottom, DataMin)) / .Interval)
                                                            If contn > 100 Then
                                                                mes += "等値線が" & contn & "本ほど描かれます。" + vbCrLf
                                                                LV2E = True
                                                            End If
                                                        End If
                                                    End With
                                                Case enmContourIntervalMode.SeparateSettings
                                                    If .IrregularNum = 0 Then
                                                        mes += "等値線の値を設定してください。" + vbCrLf
                                                        LV1E = True
                                                    Else
                                                        For i As Integer = 0 To .IrregularNum - 1
                                                            If .Irregular(i).Value > DataMax Or .Irregular(i).Value < DataMin Then
                                                                mes += "区分値が不正です。" + vbCrLf
                                                                LV2E = True
                                                            End If
                                                        Next
                                                    End If
                                            End Select
                                        End With

                                End Select
                            End With
                        End If
                    Case enmLayerMode_Number.GraphMode
                        Dim dset As Integer = Me.LayerData(Layernum).LayerModeViewSettings.GraphMode.SelectedIndex
                        With Me.LayerData(Layernum).LayerModeViewSettings.GraphMode.DataSet(dset)
                            If .GraphMode = enmGraphMode.PieGraph Or .GraphMode = enmGraphMode.StackedBarGraph Then
                                For i As Integer = 0 To .Count - 1
                                    Dim a As Integer = .Data(i).DataNumner
                                    If Me.LayerData(Layernum).atrData.Data(a).Statistics.Min < 0 Then
                                        mes += "選択データに負の数が含まれています。" + vbCrLf
                                        LV1E = True
                                        Exit For
                                    End If
                                Next
                            End If
                            If .Count <= 1 Then
                                mes += "選択データが足りません。" + vbCrLf
                                LV1E = True
                            End If
                        End With
                    Case enmLayerMode_Number.LabelMode
                    Case enmLayerMode_Number.TripMode
                        With Me.LayerData(Layernum).LayerModeViewSettings.TripMode
                            With .DataSet(.SelectedIndex)
                                If .EndTime <= .StartTime Then
                                    mes += "表示期間が正しくありません。" + vbCrLf
                                    LV1E = True
                                End If
                            End With
                        End With
                End Select
            Case enmTotalMode_Number.OverLayMode
                With Me.TotalData.TotalMode.OverLay
                    With .DataSet(.SelectedIndex)
                        If .DataItem.Count = 0 Then
                            mes += "重ね合わせデータが設定されていません。" + vbCrLf
                            LV1E = True
                        End If
                    End With
                End With
            Case enmTotalMode_Number.SeriesMode
                With Me.TotalData.TotalMode.Series
                    With .DataSet(.SelectedIndex)
                        If .DataItem.Count = 0 Then
                            mes += "連続表示データが設定されていません。" + vbCrLf
                            LV1E = True
                        End If
                    End With
                End With
        End Select

        Message = mes
        If LV1E = True Then
            Return enmPrint_Enable.UnPrintable
        Else
            If LV2E = True Then
                Return enmPrint_Enable.Printable_with_Error
            End If
        End If
        Return enmPrint_Enable.Printable

    End Function
    ''' <summary>
    ''' 飾りの初期位置指定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Set_Acc_First_Position()

        Dim mr As RectangleF = Me.TotalData.ViewStyle.ScrData.MapRectangle
        Dim w As Single = mr.Width
        Dim H As Single = mr.Height

        With Me.TotalData.ViewStyle
            For i As Integer = 0 To .MapLegend.Base.Legend_Num - 1
                With .MapLegend.Base.LegendXY(i)
                    .X = mr.Right + (i - i) * w / 50
                    .Y = mr.Top + H / 2 + (1 - i) * H / 50
                End With
            Next
            With .MapTitle.Position
                .X = (mr.Left + mr.Right) / 2
                .Y = mr.Bottom + H / 20
            End With
            With .MapScale.Position
                .X = mr.Left + w * 4 / 5
                .Y = mr.Bottom + H / 30
            End With
            With .DataNote.Position
                .X = mr.Left + w
                .Y = mr.Bottom - H * 0.2
            End With


            With .AttMapCompass.Position
                If .X >= mr.Right + w * 0.3 Then
                    .X = mr.Right - w * 0.1
                End If
                If .X <= mr.Left - w * 0.3 Then
                    .X = mr.Left + w * 0.1
                End If
                If .Y >= mr.Bottom + H * 0.3 Then
                    .Y = mr.Bottom - H * 0.1
                End If
                If .Y <= mr.Top - H * 0.3 Then
                    .Y = mr.Top + H * 0.1
                End If
            End With

            If .ScrData.Accessory_Base = enmBasePosition.Screen Then
                Change_Acc_Position_by_Accessory_Base_Set_Screen()
            End If
        End With

    End Sub
    ''' <summary>
    ''' 飾りをウインドウに固定する際の飾り位置をチェック・修正
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Change_Acc_Position_by_Accessory_Base_Set_Screen()

        Dim tp As Single, lft As Single, H As Single, w As Single
        With Me.TotalData.ViewStyle
            With .ScrData.ScrRectangle
                lft = .Left
                tp = .Top
                w = .Width
                H = .Height
            End With
            With .MapTitle.Position
                .X = clsGeneric.m_min_max((.X - lft) / w, 0.1!, 0.9!)
                .Y = clsGeneric.m_min_max((.Y - tp) / H, 0.1!, 0.95!)
            End With
            With .MapScale.Position
                .X = clsGeneric.m_min_max((.X - lft) / w, 0.1!, 0.8!)
                .Y = clsGeneric.m_min_max((.Y - tp) / H, 0.1!, 0.95!)
            End With
            With .DataNote.Position
                .X = clsGeneric.m_min_max((.X - lft) / w, 0.1!, 0.9!)
                .Y = clsGeneric.m_min_max((.Y - tp) / H, 0.1!, 0.95!)
            End With

            With .AttMapCompass.Position
                .X = clsGeneric.m_min_max((.X - lft) / w, 0.1!, 0.9!)
                .Y = clsGeneric.m_min_max((.Y - tp) / H, 0.1!, 0.9!)
            End With
            With .MapLegend.Base
                For i As Integer = 0 To .Legend_Num - 1
                    With .LegendXY(i)
                        .X = clsGeneric.m_min_max((.X - lft) / w, 0.1!, 0.8!)
                        .Y = clsGeneric.m_min_max((.Y - tp) / H, 0.1!, 0.8!)
                    End With
                Next
            End With

        End With
    End Sub
    ''' <summary>
    ''' 読み込んだ地図ファイルの全線種（オブジェクト連動型を含む）一覧を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_AllMapLineKind() As clsMapData.LPatSek_Info()
        Return Me.MapData.GetAllMapLineKind

    End Function
    ''' <summary>
    ''' 読み込んだ地図ファイルの全線種名（オブジェクト連動型を含む）一覧を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllMapLineKindName() As String()
        Return Me.MapData.GetAllMapLineKindName
    End Function
    ''' <summary>
    ''' 読み込んだ地図ファイルの全線種数（オブジェクト連動型を含む）を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllMapLineKindNum() As Integer
        Return Me.MapData.GetAllMapLineKindNum

    End Function

    ''' <summary>
    ''' 点オブジェクトグループのオブジェクト名のDictionary（地図ファイル名,オブジェクトグループ名）を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllPointObjectGroup() As Dictionary(Of String, String())
        Return Me.MapData.GetAllPointObjectGroup
    End Function

    ''' <summary>
    ''' 全オブジェクトグループのオブジェクト名のDictionary（地図ファイル名,オブジェクトグループ名）を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllObjectGroupName() As Dictionary(Of String, String())
        Return Me.MapData.GetAllObjectGroupName
    End Function


    ''' <summary>
    ''' 白地図・初期属性データ表示から読み込み
    ''' </summary>
    ''' <param name="MapDataList"></param>
    ''' <param name="LayerData"></param>
    ''' <param name="DeleteDefDataFlag">取得した初期属性データを地図データ中から削除する場合true</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetMapViewerData(ByRef MapDataList As Dictionary(Of String, clsMapData),
                                     ByRef LayerData As List(Of frmMain_ShowViewer.strLayerInfo), ByVal DeleteDefDataFlag As Boolean) As Boolean
        Me.MapData = New clsAttrMapData
        For Each pair As KeyValuePair(Of String, clsMapData) In MapDataList
            Me.MapData.AddExistingMapData(pair.Value, pair.Key)
        Next
        TotalData.ViewStyle.Zahyo = MapData.GetPrestigeZahyoMode
        Dim mes As String = ""
        MapData.EqualizeZahyoMode(TotalData.ViewStyle.Zahyo, mes)

        Dim LayN As Integer = 0
        Dim noAttrData As Boolean = True
        For Each layData As frmMain_ShowViewer.strLayerInfo In LayerData
            With layData
                Dim Get_Obj() As strObject_Data_Info
                Dim objn As Integer = 0
                Dim UseMap As clsMapData = Me.SetMapFile(.MapfileName)
                ReDim Get_Obj(UseMap.Map.Kend - 1)
                Dim fobk As Integer
                For i As Integer = 0 To UseMap.Map.Kend - 1
                    If layData.UseObjectKind(UseMap.MPObj(i).Kind) = True Then
                        fobk = UseMap.MPObj(i).Kind
                        Dim objName As String()
                        If UseMap.Get_Enable_ObjectName(i, .Time, False, objName) = True Then
                            Dim CP As PointF
                            UseMap.Get_Enable_CenterP(CP, i, .Time)
                            With Get_Obj(objn)
                                .MpObjCode = i
                                .Name = objName(0)
                                .Objectstructure = enmKenCodeObjectstructure.MapObj
                                .CenterPoint = CP
                                .Symbol = CP
                                .Label = CP
                                .Visible = True
                            End With
                            objn += 1
                        End If
                    End If
                Next
                ReDim Preserve Get_Obj(objn - 1)
                Dim layshape As enmShape = .Shape
                If layshape = enmShape.NotDeffinition Then
                    layshape = UseMap.MPObj(Get_Obj(0).MpObjCode).Shape
                End If
                Me.Add_one_Layer(.Name, enmLayerType.Normal, enmMesh_Number.mhNonMesh, layshape, .MapfileName, .Time, enmZahyo_System_Info.Zahyo_System_No, UseMap.Map.Comment, objn, Get_Obj)

                Dim Data_Val_STR(objn - 1) As String
                If UseMap.ObjectKind(fobk).DefTimeAttDataNum = 0 Then
                    '初期属性が無い場合の色の設定
                    Me.Add_One_Data_Value(LayN, "地図表示", "CAT", "", Data_Val_STR, False)
                    If .Shape <> enmShape.LineShape Then
                        Me.LayerData(LayN).atrData.Data(0).SoloModeViewSettings.Class_Div(0).PaintColor = New colorARGB(Color.White)
                    End If
                Else
                    noAttrData = False
                    Dim nDX As Integer = UseMap.ObjectKind(fobk).DefTimeAttDataNum
                    Dim misf As Boolean = False
                    For j As Integer = 0 To nDX - 1
                        For k As Integer = 0 To objn - 1
                            If UseMap.Get_DefTimeAttrValue(Get_Obj(k).MpObjCode, j, .Time, Data_Val_STR(k)) = False Then
                                misf = True
                            End If
                        Next
                        With UseMap.ObjectKind(fobk).DefTimeAttSTC(j).attData
                            If .MissingF = True And misf = False Then
                                misf = True
                            End If
                            Me.Add_One_Data_Value(LayN, .Title, .Unit, .Note, Data_Val_STR, misf)
                        End With
                    Next
                    If DeleteDefDataFlag = True Then
                        UseMap.DeleteAllDefAttrData(fobk)
                    End If
                End If
            End With
            LayN += 1
        Next


        Me.TotalData.LV1.DataSourceType = enmDataSource.Viwer
        Me.TotalData.LV1.FileName = LayerData.Item(0).MapfileName
        Me.TotalData.LV1.FullPath = Me.TotalData.LV1.FileName
        Me.initTotalData_andOther()

        If noAttrData = True Then
            Me.TotalData.ViewStyle.MapLegend.Base.Visible = False
            Me.TotalData.ViewStyle.MapTitle.Visible = False
        End If

        Return True
    End Function
    ''' <summary>
    ''' レイヤ内のURLリンクの最大数を求める
    ''' </summary>
    ''' <param name="Layer"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_MaxURLNum(ByVal Layernum As Integer) As Integer
        With Me.LayerData(Layernum)
            Dim mx As Integer = 0
            For i As Integer = 0 To .atrObject.ObjectNum - 1
                mx = Math.Max(mx, .atrObject.atrObjectData(i).HyperLinkNum)
            Next
            Return mx
        End With
    End Function


    ''' <summary>
    ''' 通常データ、カテゴリーデータの凡例を指定したデータ項目にコピーする
    ''' </summary>
    ''' <param name="D_Layer"></param>
    ''' <param name="D_DataNum"></param>
    ''' <param name="O_Data"></param>
    ''' <param name="ClassPaintF"></param>
    ''' <param name="MarkSizeF"></param>
    ''' <param name="MarkBlockF"></param>
    ''' <param name="ContourF"></param>
    ''' <param name="ClassHatchF"></param>
    ''' <param name="ClassMarkF"></param>
    ''' <param name="ClassODF"></param>
    ''' <param name="MarkTurnF"></param>
    ''' <param name="StringModeF"></param>
    ''' <param name="MarkBarF"></param>
    ''' <param name="ClassODOriginCopyF"></param>
    ''' <remarks></remarks>
    Public Sub Set_Legend(ByVal D_Layer As Integer, ByVal D_DataNum As Integer, ByRef O_Data As strData_info,
                ByVal ClassPaintF As Boolean, ByVal MarkSizeF As Boolean, ByVal MarkSizeValueCopyF As Boolean, ByVal MarkBlockF As Boolean,
                ByVal ContourF As Boolean, ByVal ClassHatchF As Boolean, ByVal ClassMarkF As Boolean, ByVal ClassODF As Boolean,
                ByVal MarkTurnF As Boolean, ByVal StringModeF As Boolean, ByVal MarkBarF As Boolean, ByVal ClassODOriginCopyF As Boolean,
                ByVal copyMarkCommonInnerDataF As Boolean)


        With LayerData(D_Layer).atrData.Data(D_DataNum).SoloModeViewSettings
            If ClassPaintF = True Or ClassHatchF = True Or ClassMarkF = True Or ClassODF = True Then
                If O_Data.DataType = enmAttDataType.Normal Then
                    '通常のデータの場合
                    Dim p As Integer = O_Data.SoloModeViewSettings.Div_Num
                    ReDim .Class_Div(p - 1)
                    .Div_Num = O_Data.SoloModeViewSettings.Div_Num
                    .Div_Method = O_Data.SoloModeViewSettings.Div_Method
                    If .Div_Method = enmDivisionMethod.Free Then
                        For j As Integer = 0 To p - 2
                            .Class_Div(j).Value = O_Data.SoloModeViewSettings.Class_Div(j).Value
                        Next
                    Else
                        Set_Div_Value(D_Layer, D_DataNum)
                    End If
                    If ClassPaintF = True Then
                        .ClassPaintMD = O_Data.SoloModeViewSettings.ClassPaintMD
                        For j As Integer = 0 To p - 1
                            .Class_Div(j).PaintColor = O_Data.SoloModeViewSettings.Class_Div(j).PaintColor
                        Next
                    End If
                    If ClassHatchF = True Then
                        For j As Integer = 0 To p - 1
                            .Class_Div(j).TilePat = O_Data.SoloModeViewSettings.Class_Div(j).TilePat
                        Next
                    End If
                    If ClassMarkF = True Then
                        .ClassMarkMD = O_Data.SoloModeViewSettings.ClassMarkMD
                        For j As Integer = 0 To p - 1
                            .Class_Div(j).ClassMark = O_Data.SoloModeViewSettings.Class_Div(j).ClassMark
                        Next
                    End If
                    If ClassODF = True Then
                        If ClassODOriginCopyF = True Then
                            .ClassODMD = O_Data.SoloModeViewSettings.ClassODMD
                        Else
                            .ClassODMD.Arrow = O_Data.SoloModeViewSettings.ClassODMD.Arrow
                        End If
                        For j As Integer = 0 To p - 1
                            .Class_Div(j).ODLinePat = O_Data.SoloModeViewSettings.Class_Div(j).ODLinePat
                        Next
                    End If
                ElseIf O_Data.DataType = enmAttDataType.Category Then
                    'カテゴリーデータの場合
                    If ClassPaintF = True Then
                        .ClassPaintMD = O_Data.SoloModeViewSettings.ClassPaintMD
                    End If
                    If ClassMarkF = True Then
                        .ClassMarkMD = O_Data.SoloModeViewSettings.ClassMarkMD
                    End If
                    If ClassODF = True Then
                        .ClassODMD = O_Data.SoloModeViewSettings.ClassODMD
                    End If
                    Dim P1 As Integer = O_Data.SoloModeViewSettings.Div_Num
                    Dim O_CateStr(P1 - 1) As String
                    For j As Integer = 0 To P1 - 1
                        O_CateStr(j) = O_Data.SoloModeViewSettings.Class_Div(j).Cat_Name
                    Next

                    Dim P2 As Integer = .Div_Num
                    Dim Con_Class_Div_Temp(P2 - 1) As strClass_Div_data
                    For j As Integer = 0 To P2 - 1
                        Con_Class_Div_Temp(j) = .Class_Div(j)
                    Next
                    Dim Con_CateStr(P2 - 1) As String
                    For j As Integer = 0 To P2 - 1
                        Con_CateStr(j) = .Class_Div(j).Cat_Name
                    Next

                    Dim okf(P2 - 1) As Boolean
                    Dim caten As Integer = 0
                    For j As Integer = 0 To P1 - 1
                        Dim k As Integer = Array.IndexOf(Con_CateStr, O_CateStr(j))
                        If k <> -1 Then
                            Dim o_Class_Div_Temp As strClass_Div_data = O_Data.SoloModeViewSettings.Class_Div(j)
                            With .Class_Div(caten)
                                .Cat_Name = o_Class_Div_Temp.Cat_Name
                                If ClassPaintF = True Then
                                    .PaintColor = o_Class_Div_Temp.PaintColor
                                End If
                                If ClassHatchF = True Then
                                    .TilePat = o_Class_Div_Temp.TilePat
                                End If
                                If ClassMarkF = True Then
                                    .ClassMark = o_Class_Div_Temp.ClassMark
                                End If
                                If ClassODF = True Then
                                    .ODLinePat = o_Class_Div_Temp.ODLinePat
                                End If
                            End With
                            caten += 1
                            okf(k) = True
                        End If
                    Next
                    For j As Integer = 0 To P2 - 1
                        If okf(j) = False Then
                            .Class_Div(caten) = Con_Class_Div_Temp(j)
                            caten += 1
                        End If
                    Next
                    If ClassODF = True Then
                        If ClassODOriginCopyF = True Then
                            .ClassODMD = O_Data.SoloModeViewSettings.ClassODMD
                        Else
                            .ClassODMD.Arrow = O_Data.SoloModeViewSettings.ClassODMD.Arrow
                        End If
                    End If

                End If
            End If
            If MarkSizeF = True Or MarkBlockF = True Or MarkTurnF = True Or StringModeF = True Or MarkBarF = True Then
                With .MarkCommon
                    If copyMarkCommonInnerDataF = True Then
                        .Inner_Data = O_Data.SoloModeViewSettings.MarkCommon.Inner_Data
                    End If
                    .LegendMinusWord = O_Data.SoloModeViewSettings.MarkCommon.LegendMinusWord
                    .LegendPlusWord = O_Data.SoloModeViewSettings.MarkCommon.LegendPlusWord
                    .MinusLineColor = O_Data.SoloModeViewSettings.MarkCommon.MinusLineColor
                    .MinusTile = O_Data.SoloModeViewSettings.MarkCommon.MinusTile
                End With
            End If
            If MarkSizeF = True Then
                .MarkSizeMD.MaxValueMode = O_Data.SoloModeViewSettings.MarkSizeMD.MaxValueMode
                If .MarkSizeMD.MaxValueMode = enmMarkSizeValueMode.UserDefinition Then
                    .MarkSizeMD.MaxValue = O_Data.SoloModeViewSettings.MarkSizeMD.MaxValue
                End If
                .MarkSizeMD.Mark = O_Data.SoloModeViewSettings.MarkSizeMD.Mark
                If MarkSizeValueCopyF = True Then
                    If O_Data.SoloModeViewSettings.MarkSizeMD.Value Is Nothing = False Then
                        .MarkSizeMD.Value = O_Data.SoloModeViewSettings.MarkSizeMD.Value.Clone
                    End If
                End If
            End If
            If MarkBlockF = True Then
                .MarkBlockMD = O_Data.SoloModeViewSettings.MarkBlockMD
            End If
            If ContourF = True Then
                Dim o_con As strContour_Data = O_Data.SoloModeViewSettings.ContourMD

                With .ContourMD
                    .Detailed = o_con.Detailed
                    .Draw_in_Polygon_F = o_con.Draw_in_Polygon_F
                    .Interval_Mode = o_con.Interval_Mode
                    If o_con.Irregular Is Nothing = False Then
                        .Irregular = o_con.Irregular.Clone
                    End If
                    .IrregularNum = o_con.IrregularNum
                    .Regular = o_con.Regular
                    .Spline_flag = o_con.Spline_flag
                End With
            End If
            If MarkTurnF = True Then
                .MarkTurnMD = O_Data.SoloModeViewSettings.MarkTurnMD
            End If
            If StringModeF = True Then
                .StringMD = O_Data.SoloModeViewSettings.StringMD
            End If
            If MarkBarF = True Then
                .MarkBarMD = O_Data.SoloModeViewSettings.MarkBarMD
            End If
        End With
    End Sub
    ''' <summary>
    ''' オブジェクト名とデータ項目を文字列で取得
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <param name="DataNumber"></param>
    ''' <param name="objNumber"></param>
    ''' <param name="SeparataString">データ項目名と値を分ける文字列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getOneObjectPanelLabelString(ByVal LayerNum As Integer,
                                                 ByVal DataNumber As Integer, ByVal objNumber As Integer, ByVal SeparataString As String) As String

        Dim SoloProperty As String = Get_DataTitle(LayerNum, DataNumber, False) + SeparataString +
                          Get_Data_Value(LayerNum, DataNumber, objNumber, TotalData.ViewStyle.Missing_Data.Text) +
                            Get_DataUnit_With_Kakko(LayerNum, DataNumber)
        Dim inData As Integer = -1
        With LayerData(LayerNum)
            Select Case .atrData.Data(DataNumber).ModeData
                Case enmSoloMode_Number.ClassMarkMode
                    If .atrData.Data(DataNumber).SoloModeViewSettings.ClassMarkMD.Flag = True Then
                        inData = .atrData.Data(DataNumber).SoloModeViewSettings.ClassMarkMD.Data
                    End If
                Case enmSoloMode_Number.MarkSizeMode, enmSoloMode_Number.MarkBlockMode, enmSoloMode_Number.MarkTurnMode
                    If .atrData.Data(DataNumber).SoloModeViewSettings.MarkCommon.Inner_Data.Flag = True Then
                        inData = .atrData.Data(DataNumber).SoloModeViewSettings.MarkCommon.Inner_Data.Data
                    End If
            End Select
        End With
        If inData <> -1 Then
            '内部データの値
            SoloProperty += vbCrLf + Get_DataTitle(LayerNum, inData, False) + SeparataString +
                Get_Data_Value(LayerNum, inData, objNumber, TotalData.ViewStyle.Missing_Data.Text) +
                Get_DataUnit_With_Kakko(LayerNum, inData)
        End If
        Return SoloProperty
    End Function
    ''' <summary>
    ''' 指定したレイヤに条件設定または表示オブジェクト限定が有効に設定されているかを調べる
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Check_Condition_UMU(ByVal Layernum As Integer) As Boolean

        If Me.LayerData(Layernum).Type = enmLayerType.Trip Then
            Layernum = Me.Get_Trip_Definition_Layer_Number
        End If

        For i As Integer = 0 To TotalData.Condition.Count - 1
            If TotalData.Condition.Item(i).Enabled = True And TotalData.Condition.Item(i).Layer = Layernum Then
                Return True
            End If
        Next

        If Check_ObjectLimitation(Layernum) = True Then
            Return True
        End If

        Return False
    End Function
    ''' <summary>
    ''' 指定したレイヤに表示オブジェクト限定が有効に設定されているかを調べる
    ''' </summary>
    ''' <param name="LayerNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Check_ObjectLimitation(ByVal LayerNum As Integer) As Boolean
        If TotalData.ViewStyle.ObjectLimitationF = True Then
            For i As Integer = 0 To Me.Get_ObjectNum(LayerNum) - 1
                If Me.LayerData(LayerNum).atrObject.atrObjectData(i).Visible = False Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function
    ''' <summary>
    ''' 表示オブジェクト限定、属性検索条件に合うオブジェクト数を数えて文字列で出力
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Condition_Ok_Num_Info(ByVal Layernum As Integer) As String

        Dim T As String = Get_Layer_Name(Layernum)
        If Me.LayerData(Layernum).Type <> enmLayerType.Trip Then
            T += "全オブジェクト数:" & Get_ObjectNum(Layernum).ToString + vbCrLf
            T += "条件に適合するオブジェクト数:" & Get_Condition_Ok_Num(Layernum).ToString + vbCrLf + vbCrLf
        End If
        Return T

    End Function
    ''' <summary>
    ''' 表示オブジェクト限定、属性検索条件に合うオブジェクト数を数える
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Condition_Ok_Num(ByVal Layernum As Integer) As Long


        Dim n As Integer = 0
        For j As Integer = 0 To Get_ObjectNum(Layernum) - 1
            If TotalData.ViewStyle.ObjectLimitationF = False Or Me.LayerData(Layernum).atrObject.atrObjectData(j).Visible = True Then
                If Check_Condition(Layernum, j) = True Then
                    n += 1
                End If
            End If
        Next
        Return n

    End Function
    ''' <summary>
    ''' 指定レイヤの条件設定情報を文字列で出力
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Condition_Info(ByVal Layernum As Integer) As String
        '

        Dim ST1 As String = "表示オブジェクト限定:"

        If Check_ObjectLimitation(Layernum) = True Then
            ST1 += "あり"
        Else
            ST1 += "なし"
        End If

        Dim st2 As String = ""
        For ic As Integer = 0 To TotalData.Condition.Count - 1
            With TotalData.Condition(ic)
                If .Enabled = True And .Layer = Layernum Then
                    st2 += Get_Layer_Name(Layernum)
                    st2 += .Name & vbCrLf
                    For i As Integer = 0 To TotalData.Condition(ic).Condition_Class.Count - 1
                        With .Condition_Class(i)
                            If .Condition.Count > 0 Then
                                st2 += "第" & (i + 1).ToString & "段階" & vbCrLf
                                For j As Integer = 0 To .Condition.Count - 1
                                    With .Condition(j)
                                        st2 += "データ項目：" & Get_DataTitle(Layernum, .Data, False) & "／"
                                        st2 += .Val + "／"
                                        st2 += clsGeneric.getConditionString(.Condition)
                                    End With
                                    If j <> .Condition.Count - 1 Then
                                        If .And_OR = enmConditionAnd_Or._And Then
                                            st2 += "　かつ"
                                        Else
                                            st2 += "　または"
                                        End If
                                    End If
                                    st2 += vbCrLf
                                Next
                            End If
                        End With
                    Next
                    st2 += vbCrLf
                End If
            End With
        Next
        If st2 <> "" Then
            st2 = "属性検索設定" + vbCrLf + vbCrLf + st2
        Else
            st2 = "属性検索設定なし" + vbCrLf
        End If

        Dim ST As String = ST1 & vbCrLf + vbCrLf + st2 + vbCrLf
        Return ST
    End Function
    ''' <summary>
    ''' オブジェクトと座標の距離
    ''' </summary>
    ''' <param name="Layernum"></param>
    ''' <param name="Obj"></param>
    ''' <param name="Point"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Distance_Kencode_Point(ByVal Layernum As Integer, ByVal Obj As Integer, ByVal Point As PointF) As Single
        Dim v As Single
        If LayerData(Layernum).Shape = enmShape.LineShape Then
            '線オブジェクトの場合
            v = Get_Distance_Kencode_Between_ObjectLine_and_Point(Layernum, Obj, Point)
        Else
            Dim p1 As PointF = Get_CenterP(Layernum, Obj)
            If TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                Dim PS As PointF = spatial.Get_Reverse_XY(Point, TotalData.ViewStyle.Zahyo)
                Dim P2 As PointF = spatial.Get_Reverse_XY(p1, TotalData.ViewStyle.Zahyo)
                v = spatial.Distance_Ido_Kedo(New strLatLon(PS), New strLatLon(P2))
            Else
                v = spatial.get_Distance(Point, p1) / SetMapFile("").Map.SCL
            End If
        End If
        Return v

    End Function
    ''' <summary>
    ''' KecnCodeと地図ファイルのオブジェクトの間で指定/線オブジェクトと面・点オブジェクトの距離は、最も近い線の位置と点・面の代表点、点・面オブジェクト間の距離は代表点間の距離、線と線の場合は、o_Code2側か線、o_Code1側が点として扱われる
    ''' </summary>
    ''' <param name="ObjNum1"></param>
    ''' <param name="ObjNum2"></param>
    ''' <param name="LayNum1"></param>
    ''' <param name="LayNum2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Distance_Kencode_MPObject(ByVal LayNum1 As Integer, ByVal ObjNum1 As Integer, ByVal MapFile As String, ByVal ObjCode2 As Integer, ByVal Time As strYMD) As Single

        Dim P1 As PointF
        Dim P2 As PointF
        Dim d As Single
        If SetMapFile(MapFile).MPObj(ObjCode2).Shape = enmShape.LineShape Then
            If LayerData(LayNum1).Shape <> enmShape.LineShape Then
                P1 = Get_CenterP(LayNum1, ObjNum1)
                d = SetMapFile(MapFile).Get_Distance_Between_ObjectLine_and_Point(ObjCode2, Time, P1)
            Else
                SetMapFile(MapFile).Get_Enable_CenterP(P1, ObjCode2, Time)
                If TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                    d = spatial.Distance_Ido_Kedo_XY(P1, P2, TotalData.ViewStyle.Zahyo)
                Else
                    d = spatial.get_Distance(P1, P2) / SetMapFile("").Map.SCL
                End If
            End If
        Else
            If LayerData(LayNum1).Shape = enmShape.LineShape Then
                P1 = Get_CenterP(LayNum1, ObjNum1)
                d = Get_Distance_Kencode_Between_ObjectLine_and_Point(LayNum1, ObjNum1, P2)
            Else
                P1 = Get_CenterP(LayNum1, ObjNum1)
                SetMapFile(MapFile).Get_Enable_CenterP(P2, ObjCode2, Time)
                If TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                    d = spatial.Distance_Ido_Kedo_XY(P1, P2, TotalData.ViewStyle.Zahyo)
                Else
                    d = spatial.get_Distance(P1, P2) / SetMapFile("").Map.SCL
                End If
            End If
        End If
        Return d
    End Function
    ''' <summary>
    ''' KecnCodeで指定/線オブジェクトと面・点オブジェクトの距離は、最も近い線の位置と点・面の代表点、点・面オブジェクト間の距離は代表点間の距離、線と線の場合は、o_Code2側か線、o_Code1側が点として扱われる
    ''' </summary>
    ''' <param name="ObjNum1"></param>
    ''' <param name="ObjNum2"></param>
    ''' <param name="LayNum1"></param>
    ''' <param name="LayNum2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Distance_Kencode_Object(ByVal ObjNum1 As Integer, ByVal ObjNum2 As Integer, ByVal LayNum1 As Integer, ByVal LayNum2 As Integer) As Single

        Dim P1 As PointF
        Dim P2 As PointF

        If LayerData(LayNum2).Shape = enmShape.LineShape Then
            clsGeneric.SWAP(ObjNum1, ObjNum2)
            clsGeneric.SWAP(LayNum1, LayNum2)
        End If
        Dim d As Single
        If LayerData(LayNum1).Shape = enmShape.LineShape Then
            '一方が線オブジェクトの場合
            P2 = Get_CenterP(LayNum2, ObjNum2)
            d = Get_Distance_Kencode_Between_ObjectLine_and_Point(LayNum1, ObjNum1, P2)
        Else
            P1 = Get_CenterP(LayNum1, ObjNum1)
            P2 = Get_CenterP(LayNum2, ObjNum2)
            If TotalData.ViewStyle.Zahyo.Mode = enmZahyo_mode_info.Zahyo_Ido_Keido Then
                d = spatial.Distance_Ido_Kedo_XY(P1.X, P1.Y, P2.X, P2.Y, TotalData.ViewStyle.Zahyo)
            Else
                d = spatial.get_Distance(P1, P2) / SetMapFile("").Map.SCL
            End If
        End If
        Return d
    End Function
    ''' <summary>
    ''' オブジェクトの線とある地点との距離を求める
    ''' </summary>
    ''' <param name="LayNum"></param>
    ''' <param name="ObjNum"></param>
    ''' <param name="P"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Distance_Kencode_Between_ObjectLine_and_Point(ByVal LayNum As Integer, ByVal ObjNum As Integer, ByVal P As PointF) As Single
        '


        Dim ELine() As clsMapData.EnableMPLine_Data

        Dim Time As strYMD = LayerData(LayNum).Time
        Dim Ocode As Integer = Get_KenObjCode(LayNum, ObjNum)
        Dim n As Integer = Get_Enable_KenCode_MPLine(ELine, LayNum, ObjNum)

        Dim d As Single = LayerData(LayNum).MapFileData.Distance_PointMPLineAllay(P, n, ELine)
        Return d
    End Function
    ''' <summary>
    ''' 新しいレイヤ名を設定
    ''' </summary>
    ''' <param name="layerName">レイヤ名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_NewLayer_Name(Optional ByVal layerName As String = "新しいレイヤ") As String
        Dim n As Integer = TotalData.LV1.Lay_Maxn
        Dim w(n - 1) As String
        For i As Integer = 0 To n - 1
            w(i) = LayerData(i).Name
        Next
        Return clsGeneric.Get_New_Numbering_Strings(layerName, w)
    End Function
    ''' <summary>
    ''' オブジェクトを削除（移動レイヤ、移動主体定義レイヤ、合成オブジェクト使用レイヤは削除不可）
    ''' </summary>
    ''' <param name="LayerDelNum">レイヤごとの削除数の配列。削除しない場合は0</param>
    ''' <param name="ObjectDeleteCheck">オブジェクトの数だけの配列で、削除する場合Trueを、全レイヤ分Listに格納</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Sub DeleteObjects(ByVal LayerDelNum() As Integer, ByRef ObjectDeleteCheck As List(Of Boolean()))
        Dim LayMax As Integer = Me.TotalData.LV1.Lay_Maxn

        '線モードの起点オブジェクトをチェックするために新旧対応リスト作成
        Dim ConvObj = New List(Of Integer())
        For i As Integer = 0 To LayMax - 1
            With Me.LayerData(i)
                Dim oldObjN As Integer = .atrObject.ObjectNum
                Dim ObjConv() As Integer
                If LayerDelNum(i) > 0 Then
                    ReDim ObjConv(oldObjN - 1)
                    Dim obn As Boolean() = ObjectDeleteCheck(i)
                    Dim n As Integer = 0
                    For j As Integer = 0 To obn.Count - 1
                        If obn(j) = False Then
                            ObjConv(j) = n
                            n += 1
                        Else
                            ObjConv(j) = 0
                        End If
                    Next
                End If
                ConvObj.Add(ObjConv)
            End With
        Next

        For i As Integer = 0 To LayMax - 1
            If LayerDelNum(i) > 0 Then
                With Me.LayerData(i)
                    Dim obn As Boolean() = ObjectDeleteCheck(i)
                    Dim GetList As New List(Of Integer)
                    For j As Integer = 0 To .atrObject.ObjectNum - 1
                        If obn(j) = False Then
                            GetList.Add(j)
                        End If
                    Next
                    Dim newObjN As Integer = GetList.Count
                    .atrObject.ObjectNum = newObjN
                    For j As Integer = 0 To newObjN - 1
                        Dim fromObj As Integer = GetList(j)
                        If fromObj <> j Then
                            .atrObject.atrObjectData(j) = .atrObject.atrObjectData(fromObj).Clone
                        End If
                        For k As Integer = 0 To Me.Get_DataNum(i) - 1
                            .atrData.Data(k).Value(j) = .atrData.Data(k).Value(fromObj)
                        Next
                    Next
                    ReDim Preserve .atrObject.atrObjectData(newObjN - 1)

                    For k As Integer = 0 To Me.Get_DataNum(i) - 1
                        Dim oldData As clsAttrData.strData_info = Me.LayerData(i).atrData.Data(k).Clone(True)
                        Dim oldMode As enmSoloMode_Number = .atrData.Data(k).ModeData
                        ReDim Preserve .atrData.Data(k).Value(newObjN - 1)
                        Me.CulcuOne(i, k)
                        Me.SetIniHanrei(i, k)
                        Me.Set_Legend(i, k, oldData, True, True, True, True, True, True, True, True, True, True, True, True, True)
                        .atrData.Data(k).ModeData = oldMode
                        If oldData.DataType <> enmAttDataType.Strings Then
                            With .atrData.Data(k).SoloModeViewSettings.ClassODMD
                                If .Dummy_ObjectFlag = False Then
                                    If LayerDelNum(.o_Layer) > 0 Then
                                        .O_object = ConvObj(.o_Layer)(.O_object)
                                    End If
                                End If
                            End With
                        End If
                    Next
                End With
            End If
        Next

    End Sub
End Class





Public Class clsAttrMapData
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Structure strAttrMap
        Public FileName As String
        Public FullPath As String
        Public Mapdata As clsMapData
    End Structure
    Private Prestage_MapFileName As String
    Private attrMapData As Dictionary(Of String, clsMapData)
    Private Object_Name_Search As Dictionary(Of String, clsObjectNameSearch)
    ''' 
    ''' 地図ファイルを開く
    ''' 
    ''' 
    ''' 拡張子MPFを優先する場合 true
    ''' 
    ''' 
    Public Function OpenMapFile(ByRef MapFileName As String, ByVal mpf_priority As Boolean) As Boolean
        Dim MFile As String = Get_MapFIleFullPath(MapFileName, mpf_priority)
        If MFile = "" Then
            Return False
        End If
        Dim fname As String = System.IO.Path.GetFileNameWithoutExtension(MFile)
        If Array.IndexOf(Me.attrMapData.Keys.ToArray, MapFileName.ToUpper) <> -1 Then
            MsgBox("同一の地図ファイル名は読み込めません。", vbExclamation)
            Return False
        End If

        Try
            Dim MapData As New clsMapData(MFile)

            attrMapData.Add(fname.ToUpper, MapData)
            If attrMapData.Count = 1 Then
                Me.Prestage_MapFileName = fname.ToUpper
            End If
            Dim ons As clsObjectNameSearch = New clsObjectNameSearch(MapData, True)
            Object_Name_Search.Add(fname.ToUpper, ons)
            MapFileName = fname
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function
    ''' <summary>
    ''' 属性データから地図ファイルを指定して、フルパスを返す
    ''' </summary>
    ''' <param name="MapFileName"></param>
    ''' <param name="mpf_priority">拡張子MPFを優先する場合true</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_MapFIleFullPath(ByVal MapFileName As String, Optional ByVal mpf_priority As Boolean = False) As String
        Dim MFile As String
        Dim ext As String = System.IO.Path.GetExtension(MapFileName)
        Dim Folder As String = ""
        If MapFileName <> "" Then
            Folder = System.IO.Path.GetDirectoryName(MapFileName)
        End If
        If Folder = "" Then
            MFile = clsGeneric.Get_MapFolder() + "\" + MapFileName
        Else
            MFile = MapFileName
        End If
        Dim fmpexists As Boolean = True
        If ext = "" Then
            Dim f1 As Boolean = System.IO.File.Exists(MFile + ".mpfz")
            Dim f2 As Boolean = System.IO.File.Exists(MFile + ".mpfx")
            Dim f3 As Boolean = System.IO.File.Exists(MFile + ".mpf")
            If mpf_priority = False Then
                If f1 = True Then
                    MFile += ".mpfz"
                ElseIf f2 = True Then
                    MFile += ".mpfx"
                ElseIf f3 = True Then
                    MFile += ".mpf"
                Else
                    fmpexists = False
                End If
            Else
                If f3 = True Then
                    MFile += ".mpf"
                ElseIf f1 = True Then
                    MFile += ".mpfz"
                ElseIf f2 = True Then
                    MFile += ".mpfx"
                Else
                    fmpexists = False
                End If
            End If
        Else
            fmpexists = System.IO.File.Exists(MFile)
        End If
        If fmpexists = False Then
            If MapFileName = "" Then
                MsgBox("地図ファイルを指定してください。")
            Else
                MsgBox(MapFileName + "が見つかりません。地図ファイルを指定してください。")
            End If
            Dim ofd As New OpenFileDialog
            ofd.InitialDirectory = clsGeneric.Get_MapFolder
            ofd.FileName = MapFileName
            ofd.Filter = "MANDARA地図ファイル(*.mpf?)|*.mpf?|圧縮地図ファイル(*.mpfz)|*.mpfz|非圧縮ファイル(*.mpfx)|*.mpfx|旧地図ファイル(*.mpf)|*.mpf"
            If ofd.ShowDialog() = DialogResult.OK Then
                clsSettings.Data.Directory.Mapfile = System.IO.Path.GetDirectoryName(ofd.FileName)
                MFile = ofd.FileName
                fmpexists = True
            Else
                Return ""
            End If
        End If
        Return MFile
    End Function
    Public Sub AddExistingMapData(ByRef MapData As clsMapData, ByVal MapFileName As String)
        attrMapData.Add(MapFileName.ToUpper, MapData)
        Object_Name_Search.Add(MapFileName.ToUpper, New clsObjectNameSearch(MapData, True))
        If attrMapData.Count = 1 Then
            Me.Prestage_MapFileName = MapFileName.ToUpper
        End If
    End Sub
    ''' <summary>
    ''' 地図デーセットをレイヤにセットする
    ''' </summary>
    ''' <param name="MapFileName">空白の場合、最初に読み込まれた地図</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetMapFile(ByVal MapFileName As String) As clsMapData
        If MapFileName = "" Then
            Return attrMapData(Prestage_MapFileName)
        End If
        Try
            Return attrMapData(MapFileName.ToUpper)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function SetObject_Name_Search(ByVal MapFileName As String) As clsObjectNameSearch
        If MapFileName = "" Then
            Return Object_Name_Search(Prestage_MapFileName)
        End If
        Return Object_Name_Search(MapFileName.ToUpper)
    End Function

    ''' <summary>
    ''' 優先地図ファイル名取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPrestigeMapFileName() As String
        Return Prestage_MapFileName
    End Function
    ''' <summary>
    ''' 優先地図ファイル名設定
    ''' </summary>
    ''' <param name="Filename"></param>
    ''' <remarks></remarks>
    Public Sub SetPrestigeMapFileName(ByVal Filename As String)
        Prestage_MapFileName = Filename
    End Sub

    ''' <summary>
    ''' 読み込んだ地図ファイル数を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNumOfMapFile() As Integer
        Return attrMapData.Count
    End Function
    ''' <summary>
    ''' 読み込んだ地図ファイル名の配列を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMapFileName() As String()
        Dim fname As String() = attrMapData.Keys.ToArray
        Return fname
    End Function
    ''' <summary>
    ''' 最初の地図ファイル名の座標プロパティ取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPrestigeZahyoMode() As clsMapData.Zahyo_info
        Return attrMapData(Prestage_MapFileName).Map.Zahyo
    End Function

    ''' <summary>
    ''' 読み込んだ地図ファイルの全線種（オブジェクト連動型を含む）一覧を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllMapLineKind() As clsMapData.LPatSek_Info()
        Dim LK() As clsMapData.LPatSek_Info
        Dim n As Integer = 0
        For Each pair As KeyValuePair(Of String, clsMapData) In attrMapData
            Dim cmap As clsMapData = pair.Value
            Dim LK2 As clsMapData.LPatSek_Info()
            Dim LKAllN As Integer = cmap.Get_TotalLineKind(LK2)
            ReDim Preserve LK(n + LKAllN - 1)
            For j As Integer = 0 To LKAllN - 1
                LK(n) = LK2(j)
                n += 1
            Next
        Next
        Return LK
    End Function

    ''' <summary>
    ''' 読み込んだ地図ファイルの全線種名（オブジェクト連動型を含む）一覧を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllMapLineKindName() As String()
        Dim STR() As String
        Dim n As Integer = 0
        For Each pair As KeyValuePair(Of String, clsMapData) In attrMapData
            Dim cmap As clsMapData = pair.Value
            Dim LK As clsMapData.LPatSek_Info()
            Dim LKAllN As Integer = cmap.Get_TotalLineKind(LK)
            ReDim Preserve STR(n + LKAllN - 1)
            For j As Integer = 0 To LKAllN - 1
                STR(n) = pair.Key + ":" + LK(j).Name
                n += 1
            Next
        Next
        Return STR
    End Function
    ''' <summary>
    ''' 点オブジェクトグループのオブジェクト名のDictionary（地図ファイル名,オブジェクトグループ名）を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllPointObjectGroup() As Dictionary(Of String, String())
        Dim AllPOBJG As New Dictionary(Of String, String())
        For Each pair As KeyValuePair(Of String, clsMapData) In attrMapData
            Dim PointObk As New List(Of String)
            Dim cmap As clsMapData = pair.Value
            For i As Integer = 0 To cmap.Map.OBKNum - 1
                If cmap.ObjectKind(i).Shape = enmShape.PointShape Then
                    PointObk.Add(cmap.ObjectKind(i).Name)
                End If
            Next
            If PointObk.Count > 0 Then
                AllPOBJG.Add(pair.Key, PointObk.ToArray())
            End If
        Next
        Return AllPOBJG
    End Function
    ''' <summary>
    ''' 全オブジェクトグループのオブジェクト名のDictionary（地図ファイル名,オブジェクトグループ名）を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllObjectGroupName() As Dictionary(Of String, String())
        Dim AllOBJG As New Dictionary(Of String, String())
        For Each pair As KeyValuePair(Of String, clsMapData) In attrMapData
            Dim PointObk As New List(Of String)
            Dim cmap As clsMapData = pair.Value
            For i As Integer = 0 To cmap.Map.OBKNum - 1
                PointObk.Add(cmap.ObjectKind(i).Name)
            Next
            AllOBJG.Add(pair.Key, PointObk.ToArray())
        Next
        Return AllOBJG

    End Function

    ''' <summary>
    ''' 地図ファイル名、線種、グループで、線種位置番号を求める
    ''' </summary>
    ''' <param name="MapFileName"></param>
    ''' <param name="lineKindNum"></param>
    ''' <param name="PatternNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLineKindPosition(ByVal MapFileName As String, ByVal lineKindNum As Integer, ByVal PatternNum As Integer) As Integer
        Dim n As Integer = 0
        For Each pair As KeyValuePair(Of String, clsMapData) In attrMapData
            Dim cmap As clsMapData = pair.Value
            If pair.Key <> MapFileName.ToUpper Then
                n += cmap.Get_TotalLineKind_Num
            Else
                For j = 0 To lineKindNum - 1
                    n += cmap.LineKind(j).NumofObjectGroup
                Next
                n += PatternNum
                Return n
            End If
        Next
        Return -1
    End Function
    ''' <summary>
    ''' 読み込んだ地図ファイルの全線種数（オブジェクト連動型を含む）を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllMapLineKindNum() As Integer
        Dim n As Integer = 0
        For Each pair As KeyValuePair(Of String, clsMapData) In attrMapData
            Dim cmap As clsMapData = pair.Value
            n += cmap.Get_TotalLineKind_Num()
        Next
        Return n
    End Function
    ''' <summary>
    ''' 読み込んだ地図ファイルの投影法等座標設定を同じにする
    ''' </summary>
    ''' <param name="Zahyo"></param>
    ''' <param name="Emes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EqualizeZahyoMode(ByVal Zahyo As clsMapData.Zahyo_info, ByRef Emes As String) As Boolean
        Emes = ""
        Dim f As Boolean = True
        For Each pair As KeyValuePair(Of String, clsMapData) In attrMapData

            Dim cmap As clsMapData = pair.Value
            Dim mes As String = ""
            If spatial.Check_Zahyo_Projection_Convert_Enabled(Zahyo, cmap.Map.Zahyo, mes) = False Then
                Emes += pair.Key.ToString + ":" + mes + vbCrLf
                f = False
            End If
        Next
        If f = True Then
            For Each pair2 As KeyValuePair(Of String, clsMapData) In attrMapData
                Dim cmap As clsMapData = pair2.Value
                If cmap.Map.Zahyo.Equals(Zahyo) = False Then
                    cmap.Convert_ZahyoMode(Zahyo)
                End If
            Next
        End If
        Return f
    End Function
    ''' <summary>
    ''' 指定した地図ファイルを削除
    ''' </summary>
    ''' <param name="MapFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Sub RemoveMapData(ByVal MapFileName As String)
        If MapFileName = "" Then
            MapFileName = Me.Prestage_MapFileName
        End If
        Me.attrMapData.Remove(MapFileName)
        Me.Object_Name_Search.Remove(MapFileName)
        If MapFileName = Me.Prestage_MapFileName Then
            If Me.attrMapData.Count = 0 Then
                Me.Prestage_MapFileName = ""
            Else
                Me.Prestage_MapFileName = attrMapData.Keys(0)
            End If
        End If
    End Sub
    Public Sub New()
        attrMapData = New Dictionary(Of String, clsMapData)
        Object_Name_Search = New Dictionary(Of String, clsObjectNameSearch)
    End Sub

End Class
