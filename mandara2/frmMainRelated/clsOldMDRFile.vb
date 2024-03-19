Public Class clsOldMDRFile

    Public Structure RGBQUAD
        Public rgbBlue As Byte
        Public rgbGreen As Byte
        Public rgbRed As Byte
        Public rgbReserved As Byte
    End Structure

    Public Structure RECT_v1275
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    Public Structure Synthetic_ObjectName_and_Code_v1275 '合成オブジェクト名とコード（属性データ）
        Public code As Integer
        Public Name As String
        Public Draw_F As Boolean
    End Structure

    Public Structure Synthetic_Object_Data_v1275 '合成オブジェクト（属性・地図データ）
        Public Kind As Integer
        Public NumOfObject As Integer
        Public Name As String
        Public StartTime As Integer
        Public EndTime As Integer
        Public CIX As Single
        Public CIY As Single
        Public Shape As Short
        Public Circumscribed_Rectangle As clsVB6File.Box_Data_single_v11
        Public Objects() As Synthetic_ObjectName_and_Code_v1275
    End Structure



    Public Structure ObjectName_and_Code_v1275 'オブジェクト名とコード（属性データ）
        Public code As Integer
        Public Name As String
        Public Label As clsVB6File.SingleXY_v1275
    End Structure



    Public Structure ObjectName_and_Code_and_SymbolX_v1275 'オブジェクト名とコード、シンボル位置（属性データ）
        Public code As Integer
        Public Name As String
        Public ObjectType As Integer 'kenCodeObjectprivate structureの内容
        Public Symbol As clsVB6File.SingleXY_v1275
        Public Label As clsVB6File.SingleXY_v1275
    End Structure

    Public Structure URL_Data_v1275
        Public Name As String
        Public Address As String
    End Structure

    Public Structure KenCode_data_info
        Public Type As ObjectName_and_Code_and_SymbolX_v1275
        Public URL As URL_Data_v1275
    End Structure

    Public Structure EnableMPLine_Data_v1275 '利用可能なライン（属性・地図データ）
        Public LineCode As Integer
        Public Kind As Integer
    End Structure

    Public Structure Layer_Graph_Trip_Label_Mode_Info_v1275 'レイヤのグラフモードのプロパティ
        Public DataSet As Integer
        Public Stac As Integer
        Public NumOfDataSet As Integer
    End Structure


    Public Structure Layer_Mode_Info_v1275
        Public Graph As Layer_Graph_Trip_Label_Mode_Info_v1275
        Public Label As Layer_Graph_Trip_Label_Mode_Info_v1275
        Public Trip As Layer_Graph_Trip_Label_Mode_Info_v1275
    End Structure



    Public Structure Layer_Object_INfo_v1275 'レイヤのオブジェクトのプロパティ
        Public Object_n As Integer
        Public Stac As Integer
        Public FirstSyntheticObj_Code As Integer
        Public NumOfSyntheticObj As Integer
    End Structure

    Public Structure Layer_Data_Info_v1275 'レイヤのデータ項目のプロパティ
        Public DatN As Integer
        Public Stac As Integer
        Public Dat_maxn As Integer
    End Structure


    Public Structure Layer_Data_v1275 'レイヤデータ（属性データ）
        Public Name As String
        Public Shape As Short
        Public Time As Integer
        Public Data As Layer_Data_Info_v1275
        Public Print_Mode_Layer As Integer '0:単独 1:グラフ 2:ラベル 3:移動
        Public ObjectPos As Layer_Object_INfo_v1275
        Public NumOfDummy As Integer
        Public PLMark As clsVB6File.Mark_Property_v11 '点線オブジェクトのペイントモード
        Public LayerMode As Layer_Mode_Info_v1275
        Public Dummy_ObjectKindUse() As Boolean
        Public DummySTC() As ObjectName_and_Code_v1275
        Public PolygonDummy_ClipSet_F As Boolean
    End Structure

    Public Structure LKOjectGroup_Info_v1275
        Public GroupNumber As Integer
        Public UseOnly As Boolean
    End Structure
    Public Structure LineKind_Data_v1275 '線種名とパターン（地図データ）
        Public Name As String
        Public NumofOjectGroup As Integer '1の場合は通常の線種、2以上の場合はオブジェクトグループ連動
        Public ObjGroup() As LKOjectGroup_Info_v1275
        Public Pat() As clsVB6File.Line_Property_v11
        Public Mesh As Integer
        Public Edited As Boolean
    End Structure

    Public Structure LPatSek_Info_v1275 '線種をオブジェクトグループ連動を個別に数えた場合に使用
        Public LKind As Integer
        Public LkindPatNum As Integer
        Public Name As String
        Public Pat As clsVB6File.Line_Property_v11
    End Structure


    Public Enum ObjectGoupType_Data_v1275
        NormalObject = 0
        AggregationObject = 1
    End Enum

    Public Structure MPObjDefAttData_Info_v1275 '初期属性データ（地図データ）
        Public title As String
        Public Unit As String
    End Structure

    Public Structure ObjectKind_Data_v1275 'オブジェクトグループデータ（地図データ）
        Public ObjectType As Integer 'ObjectGoupprivate structure_Dataの内容
        Public Name As String
        Public Shape As Short
        Public Mesh As Integer
        Public Color As Integer
        Public Edited As Boolean
        Public DefAttDataNum As Integer
        Public DefAttSTC() As MPObjDefAttData_Info_v1275
        Public UseLineprivate As Boolean 'NormalObjectで使用
        Public UseObjectGroup() As Boolean 'AggregationObjectで使用するオブジェクトグループ
    End Structure

    Public Structure ThreeDMode_Set_v1275 '3Dモードの回転に使用（属性データ）
        Public Set3D_F As Boolean
        Public Pitch As Short
        Public Head As Short
        Public Bank As Short
        Public Expand As Short
    End Structure


    Public Structure Arrow_Data_v1275
        Public Start_Arrow_F As Boolean
        Public End_Arrow_F As Boolean
        Public type As Short
        Public Kakudo As Single
        Public LWidthRatio As Single
        Public WidthPlus As Single
    End Structure


    Public Structure Graph_Data_En_v1275 '複数表示（円）（属性データ）
        Public EnSizeMode As Short
        Public EnSize As Single
        ''' <summary>
        ''' 元は2
        ''' </summary>
        ''' <remarks></remarks>
        Public Value() As Double
        Public BoaderLine As clsVB6File.Line_Property_v11
        Public Tanpen As Single
        Public TateYoko As Short
        Public RMAX As Double
        Public RMIN As Double
        Public title As String
        Public Shape As Short
        Public MaxValueMode As Short
        Public MaxValue As Double
    End Structure

    Public Structure Graph_Data_Oresen_v1275 '複数表示（折れ線）（属性データ）
        Public EnSize As Single
        Public Line As clsVB6File.Line_Property_v11
        Public Tanpen As Single
        Public YMax As Double
        Public Ymin As Double
        Public Ystep As Double
        Public title As String
        Public Shape As Short
        Public WakuTile As clsVB6File.Tile_Property_v11
        Public WakuLine As clsVB6File.Line_Property_v11
    End Structure


    Public Structure Graph_Data_v1275 'グラフモードの構造体
        Public title As String
        Public MultiMode As Integer
        Public Datnum As Short
        ''' <summary>
        ''' 元は配列11
        ''' </summary>
        ''' <remarks></remarks>
        Public DatN() As Integer
        Public Tile() As clsVB6File.Tile_Property_v11
        Public En_Obi As Graph_Data_En_v1275
        Public Oresen_Bou As Graph_Data_Oresen_v1275
    End Structure

    Public Structure Trip_Data_v1275 '移動データの構造体
        Public title As String
        Public Mode As Integer
        Public StartTime As Double
        Public EndTime As Double
        Public Definition_Layer_Data As Integer
        Public Definition_Layer_Data_Mode As Integer
        Public Stay_Data As Integer
        Public Move_Data As Integer
        Public Stay_Data_Mode As Integer
        Public Move_Data_Mode As Integer
        Public Print_Or_nonPrint As Boolean 'true=Print
        Public Print_Subject As String
    End Structure

    Public Structure Label_Data_v1275 'ラベルモード
        Public title As String
        Public Location_Mark_Flag As Boolean
        Public Location_Mark As clsVB6File.Mark_Property_v11
        Public Width As Single
        Public DataValue_Font As clsVB6File.Font_Property_v11
        Public DataValue_Unit_Flag As Boolean
        Public DataValue_TurnFlag As Boolean
        Public DataValue_Print_Falg As Boolean
        Public DataName_Print_Falg As Boolean
        Public Print_Data As String '表示するデータ項目の番号をタブ区切りで
        Public ObjectName_Font As clsVB6File.Font_Property_v11
        Public ObjectName_Print_Falg As Boolean
        Public ObjectName_Turn_Falg As Boolean
        Public Dummy_Object_Font As clsVB6File.Font_Property_v11
        Public Dummy_Object_Flag As Boolean
        Public Dummy_Object_Group_Font As clsVB6File.Font_Property_v11
        Public Dummy_Object_Group_Name1_or_2 As Integer '1の場合オブジェクト名１を優先
        Public Dummy_Object_Group_Flag As Boolean
        Public WakuObjectTile As clsVB6File.Tile_Property_v11
        Public WakuDataTile As clsVB6File.Tile_Property_v11
        Public WakuLine As clsVB6File.Line_Property_v11
        Public FontFringe As clsVB6File.FontFringe_Info
    End Structure




    Public Structure Magnification_v1275
        Public Xplus As Single
        Public YPlus As Single
        Public Mul As Single
    End Structure

    Public Structure Datainfo2_v1275
        Public title As String
        Public Unit As String
        Public DataType As Integer 'Dataprivate structure_Number 'integer
        Public DataSubType As Integer 'DataSubprivate structure_Number 'integer
        Public Max As Double
        Public Min As Double
        Public Ave As Double
        Public STD As Double
        Public Sum As Double
        Public sa As Double
        Public Number As Integer
        Public Missing_num As Integer
        Public Div_Method As Integer
        Public Div_Num As Integer
        Public Div_Stac As Integer
        Public Missing_Stac As Integer
        Public DataCellStac As Integer ' データ型に対応した配列のポインタ
    End Structure
    Public Structure Mode_Info_v1275
        Public Enable_Mode As String
        Public Mode As Integer
    End Structure

    Public Structure Inner_Data_Info_v1275 '記号の数，大きさ，階級記号，線モードの内部色設定
        Public Flag As Boolean
        Public Data As Integer
        Public Mode As Short
    End Structure

    Public Structure Paint_Data_v1275 'ペイントモード設定値（属性データ）
        Public color1 As Integer
        Public color2 As Integer
        Public color3 As Integer
        Public Color_Mode As Short
    End Structure



    Public Structure Circle_Data_v1275 '円記号モード設定（属性データ）
        Public MinusTile As clsVB6File.Tile_Property_v11
        Public MaxValueMode As Short
        Public MaxValue As Double
        Public Value() As Double
        Public Mark As clsVB6File.Mark_Property_v11
        Public Inner_Data As Inner_Data_Info_v1275
    End Structure

    Public Structure Block_Data_v1275 'ブロックモード設定（属性データ）
        Public MinusTile As clsVB6File.Tile_Property_v11
        Public Value As Double
        Public ArrangeB As Short
        Public Hasu As Short
        Public Mark As clsVB6File.Mark_Property_v11
        Public Inner_Data As Inner_Data_Info_v1275
        Public Overlap As Integer
    End Structure


    Public Structure Contour_Data_Regular_interval_v1275 '等値線モード設定（属性データ）
        Public bottom As Double
        Public Interval As Double
        Public top As Double
        Public Line_Pat As clsVB6File.Line_Property_v11
        Public SP_Bottom As Double
        Public SP_interval As Double
        Public SP_Top As Double
        Public SP_Line_Pat As clsVB6File.Line_Property_v11
        ''' <summary>
        ''' EX_ValueはVariant型
        ''' </summary>
        ''' <remarks></remarks>
        Public EX_Value As String
        Public EX_Line_Pat As clsVB6File.Line_Property_v11
    End Structure
    Public Structure Contour_Data_Irregular_interval_v1275
        ''' <summary>
        ''' もともとは9でVariant型
        ''' </summary>
        ''' <remarks></remarks>
        Public Value() As String
        Public Line_Pat() As clsVB6File.Line_Property_v11
    End Structure
    Public Structure Contour_Data_v1275
        Public Interval_Mode As Integer
        Public Draw_in_Polygon_F As Boolean
        Public Spline_flag As Boolean
        Public Detailed As Integer
        Public Regular As Contour_Data_Regular_interval_v1275
        Public Irregular As Contour_Data_Irregular_interval_v1275
    End Structure
    Public Structure ODMode_data_v1275 '線引きモード（属性データ）
        Public o_Layer As Integer
        Public O_object As Integer
        Public Arrow As Arrow_Data_v1275
    End Structure

    Public Structure TurnMode_Data_v1275 '回転モード
        Public Dirction As Integer '0:反時計回り　1:時計回り
        Public Mark As clsVB6File.Mark_Property_v11
        Public DegreeLap As Double '一周の値
        Public Inner_Data As Inner_Data_Info_v1275
    End Structure

    Public Structure SoloMode_Data_v1275 '単独表示モードのプロパティを保持する構造体（属性データ）
        Public PaintMD As Paint_Data_v1275
        Public CircleMD As Circle_Data_v1275
        Public BlockMD As Block_Data_v1275
        Public ContourMD As Contour_Data_v1275
        Public ODMD As ODMode_data_v1275
        Public ClassMarkMD As Inner_Data_Info_v1275
        Public TurnMD As TurnMode_Data_v1275
    End Structure

    Public Structure Attribute_of_Data_v1275 'データ項目に関するプロパティを保持する構造体（属性データ）
        Public DTA As Datainfo2_v1275 '平均値などデータの代表値
        Public ModeData As Mode_Info_v1275 '表示モード
        Public SoloMode As SoloMode_Data_v1275 '単独表示モードごとのプロパティ
    End Structure

    Public Structure Box_Position_and_Size_v1275
        Public left As Single 'この順序は変えてはいけない
        Public top As Single
        Public Width As Single
        Public Height As Single
    End Structure

    Public Structure Screen_info_v1275
        Public FirstScreenMGMul As Single '全体が表示してある場合の拡大係数(MDRには保存しない)
        Public GSMul As Single '地図サイズに対するウィンドウサイズの比(MDRには保存しない)
        Public ScrView As clsVB6File.Box_Data_single_v11 '旧wx1など
        Public ScrRectangle As clsVB6File.Box_Data_single_v11 '旧S_Wx1など
        Public MapRectangle As clsVB6File.Box_Data_single_v11 '旧F_Wx1など
        Public MapScreen_Scale As RECT_v1275 '.Left=0.Top=0.bottom=Scalebottom.Top=scaleTop
        Public ScreenMG As Magnification '旧mul,xp,yp
        Public PrinterMG As Magnification '旧Prtmul,xp,yp
        Public Screen_Margin As clsVB6File.Box_Data_single_v11 '画面のマージン
        Public frmPrint_FormSize As Box_Position_and_Size_v1275 'frmPrintのウィンドウ自体の位置とサイズ
    End Structure


    Public Structure Missing_set_v1275 '欠損値の設定（属性データ）
        Public Print_Flag As Boolean
        Public Text As String
        Public PaintTile As clsVB6File.Tile_Property_v11
        Public HatchTile As clsVB6File.Tile_Property_v11
        Public Mark As clsVB6File.Mark_Property_v11
        Public BlockMark As clsVB6File.Mark_Property_v11
        Public ClassMark As clsVB6File.Mark_Property_v11
        Public TurnMark As clsVB6File.Mark_Property_v11
        Public Label As String
        Public LineShape As clsVB6File.Line_Property_v11
    End Structure

    Public Structure OverLay_Basic_Info_v1275
        Public Number As Integer
        Public OverN As Integer
    End Structure

    Public Structure Series_Basic_Info_v1275
        Public Number As Integer
        Public SeriN As Integer
    End Structure

    Public Structure Basic_Data_v1275 '属性データ基本値（属性データ）
        Public Lay_Maxn As Integer
        Public Layn As Integer
        Public Print_Mode_Total As Integer '0:データ表示 1:重ね合わせ　2:連続
        Public MapFile As String
        Public DefN As Integer
        Public OverLay As OverLay_Basic_Info_v1275
        Public Series As Series_Basic_Info_v1275
        Public Comment As String
        Public MDRM_Flag As Boolean '地図ファイル付きデータファイルの場合はTrue
    End Structure

    Public Structure Total_Data_Info_v1275  '属性データ全体に関わるデータ（属性データ）
        Public LV1 As Basic_Data_v1275
        Public ScrData As Screen_info_v1275
        Public ViewStyle As ViewStyle_Info_v1275
        Public StacSize As attStacSize_Info_v1275
    End Structure

    Public Structure Screen_Back_data_v1275 '画面の背景設定（属性データ）
        Public LinePat As clsVB6File.Line_Property_v11
        Public TileBack As clsVB6File.Tile_Property_v11
        Public TileInner As clsVB6File.Tile_Property_v11
    End Structure

    Public Structure Scale_Attri_v1275 'スケール設定（属性データ）
        Public Visible As Boolean
        Public X As Single
        Public Y As Single
        Public Font As clsVB6File.Font_Property_v11
        Public BarPattern As Integer
        Public BarAuto As Boolean
        Public BarDistance As Single
        Public BarKugiriNum As Integer
        Public BGTile As clsVB6File.Tile_Property_v11
        Public BGLine As clsVB6File.Line_Property_v11
    End Structure

    Public Structure Title_Attri_v1275 'タイトル設定（属性データ）
        Public Visible As Boolean
        Public X As Single
        Public Y As Single
        Public Font As clsVB6File.Font_Property_v11
    End Structure

    Public Structure Legend_Base_Attri_v1275
        Public Visible As Boolean
        Public Legend_Num As Integer
        Public Font As clsVB6File.Font_Property_v11
        Public BGTile As clsVB6File.Tile_Property_v11
        Public BGLine As clsVB6File.Line_Property_v11
    End Structure
    Public Structure Legend_Class_Attri_v1275
        Public PaintMode_Line As clsVB6File.Line_Property_v11
        Public PaintMode_Method As Integer
        Public PaintMode_Width As Single
        Public ClassMarkFrame_Visible As Boolean
        Public SeparateClassWords As Integer
    End Structure
    Public Structure Legend_Mark_Attri_v1275
        Public CircleMD_CircleMini_F As Boolean
        Public CirclrMD_Plus_Text As String
        Public CirclrMD_Minus_Text As String
        Public MultiEnMode_Line As clsVB6File.Line_Property_v11
        Public BlockMode_Text As String
    End Structure

    Public Structure Legend_Line_Dummy_Attri_v1275
        Public Line_Visible As Boolean
        Public Line_Visible_Number_STR As String '線種ごとに表示するかどうか、１は表示０は非表示で連続文字列
        Public Line_Pattern As Integer
        Public Dummy_Point_Visible As Boolean
        Public BGTile As clsVB6File.Tile_Property_v11
        Public BGLine As clsVB6File.Line_Property_v11
    End Structure

    Public Structure Legend_Attri_v1275 '凡例設定（属性データ）
        Public Base As Legend_Base_Attri_v1275
        Public ClassMD As Legend_Class_Attri_v1275
        Public MarkMD As Legend_Mark_Attri_v1275
        Public Line_DummyKind As Legend_Line_Dummy_Attri_v1275
        Public En_Graph_Pattern As Integer
    End Structure

    Public Structure Picture_Property_v1275 '画像の基本値
        Public Width As Integer
        Public Height As Integer
        Public TransParency_f As Boolean
        Public TransParency_Color As Integer
        Public Alternate_f As Boolean
        Public Alternate_Color As Integer
        Public bitmapbyte() As Byte
    End Structure


    Public Structure Figure_Property_v1275 '図形の基本値（属性データ）
        Public Number As Integer
        Public Visible As Boolean
        Public Word_n As Integer
        Public line_n As Integer
        Public line_AP As Integer
        Public Circle_n As Integer
        Public Point_n As Integer
        Public Point_AP As Integer
        Public Gazo_n As Integer
    End Structure



    Public Structure attStacSize_Info_v1275 '属性データ全体に関係するスタック数を保持（属性データ）
        Public DataStringStacNum As Integer
        Public DataByteStacNum As Integer
        Public DataintegerStacNum As Integer
        Public DataLongStacNum As Integer
        Public DataSingleStacNum As Integer
        Public DataDoubleStacNum As Integer
        Public attDataStacNum As Integer
        Public GraphModeStacNum As Integer
        Public TripModeStacNum As Integer
        Public LabelModeStacNum As Integer
        Public OverLayModeStacNum As Integer
        Public SeriesModeStacNum As Integer
        Public NumOfSymtheticObject As Integer
        Public ClassStacNum As Integer
        Public KenCodeStacNum As Integer
        Public ODBesierStacNum As Integer
        Public MissingStacNum As Integer
        Public PictureNum As Integer
        Public ConditionDataSetNum As Integer
        Public Screen_Setting_Num As Integer
    End Structure

    Public Structure Symbol_Lien_Data_v1275 '代表点と記号表示位置を結ぶデータ（属性データ）
        Public Visible As Boolean
        Public Line As clsVB6File.Line_Property_v11
    End Structure
    ''' <summary>
    ''' 移動表示モードで使う各種ラインの設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Trip_Line_Data_v1275
        Public Stay_Line As clsVB6File.Line_Property_v11
        Public Trip_Line As clsVB6File.Line_Property_v11
        Public Height As Single
        Public Frame_Print As Boolean
        Public Frame_Line As clsVB6File.Line_Property_v11
        Public TimeLegend_Position As Integer
        Public TimeLegend_Font As clsVB6File.Font_Property_v11
        Public Start_End_Print As Boolean
        Public StartPoint_Mark As clsVB6File.Mark_Property_v11
        Public EndPoint_Mark As clsVB6File.Mark_Property_v11
        Public ZeroPointF As Boolean
        Public ZeroLineF As Boolean
        Public ZeroPoint_Mark As clsVB6File.Mark_Property_v11
        Public ZeroLine As clsVB6File.Line_Property_v11
        Public Overlap_Mode As Boolean
        Public VerticalLineF As Boolean
        Public VerticalLine As clsVB6File.Line_Property_v11
    End Structure

    Public Structure OverLay_Legend_Title_Info_v1275
        Public Print_f As Boolean
        Public MaxWidth As Single
    End Structure

    Public Structure IdoKeido_Print_Info_v1275
        Public Visible As Boolean
        Public Order As Integer
        Public Ido_Interval As Single
        Public Kedo_Interval As Single
        Public LPat As clsVB6File.Line_Property_v11
    End Structure

    Public Structure SouByou_Info_v1275
        Public ThinningPint_F As Boolean
        Public PointInterval As Single
        Public LoopSize As Single
        Public Spline_F As Boolean
    End Structure

    Public Structure WebMapServide_Info_v1275
        Public Visible As Boolean
        Public WMS As Integer
        Public Alpha As Integer
        Public Timing As Integer
        Public OrthoNumber As Integer
        Public KJMapDataSet As Integer
        Public KJMapTime As Integer
        Public UserGazoFolder As String
    End Structure

    Public Structure ClassBoundaryLine_Info_v1275
        Public Visible As Boolean
        Public LPat As clsVB6File.Line_Property_v11
    End Structure
    ''' <summary>
    ''' '飾りの設定を保持（属性データ）
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure ViewStyle_Info_v1275
        Public Accessory_Base_Set_Screen As Boolean
        Public Comma_f As Boolean
        Public MapScale As Scale_Attri_v1275
        Public MapTitle As Title_Attri_v1275
        Public AttMapCompass As clsVB6File.Compass_Attri_v11
        Public MapLegend As Legend_Attri_v1275
        Public Fig As Figure_Property_v1275
        Public ThreeDMode As ThreeDMode_Set_v1275
        Public Missing_Data As Missing_set_v1275
        Public Screen_Back As Screen_Back_data_v1275
        Public SymbolLine As Symbol_Lien_Data_v1275
        Public Trip_Line As Trip_Line_Data_v1275
        Public PointPaint_Order As Integer
        Public Dummy_Size_Flag As Boolean
        Public MapPrint_Flag As Boolean
        Public OverLay_Legend_Title As OverLay_Legend_Title_Info_v1275
        Public IdoKeido_Print As IdoKeido_Print_Info_v1275
        Public SouByou As SouByou_Info_v1275
        Public WMS As WebMapServide_Info_v1275
        Public ClassBoundaryLine As ClassBoundaryLine_Info_v1275
    End Structure
    ''' <summary>
    ''' '画面設定保存用
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Screen_Setting_Info_v1275
        Public title As String
        Public frmPrint_FormSize As Box_Position_and_Size_v1275
        Public ThreeDMode As ThreeDMode_Set_v1275
        Public ScrView As clsVB6File.Box_Data_single_v11
        Public Screen_Margin As clsVB6File.Box_Data_single_v11
        Public Accessory_Base_Set_Screen As Boolean
        Public MapScale As Scale_Attri_v1275
        Public MapTitle As Title_Attri_v1275
        Public AttMapCompass As clsVB6File.Compass_Attri_v11
        Public MapLegend As Legend_Attri_v1275
        Public LegendXstr As String
        Public LegendYstr As String
    End Structure


    Public Structure OvetLay_DataSet_Item_Info_v1275
        Public Layer As Integer
        Public DatN As Integer
        Public Print_Mode_Layer As Integer
        Public Mode As Integer
        Public Legend_Print_Flag As Boolean
    End Structure

    Public Structure OverLay_Dataset_Info_v1275 '重ね合わせモードに関するデータ
        Public title As String
        Public Number As Integer
        Public Stac As Integer
        Public AlwaysPrint_Flag As Boolean
    End Structure

    Public Structure Series_Dataset_Info_v1275 '連続表示モードに関するデータ
        Public title As String
        Public Number As Integer
        Public Stac As Integer
    End Structure

    Public Structure Series_DataSet_Item_Info_v1275 '連続表示モード
        Public Layer As Integer
        Public Data As Integer
        Public Print_Mode_Total As Integer
        Public Print_Mode_Layer As Integer
        Public Mode As Integer
    End Structure

    Public Structure ODBezier_Data_v1275
        Public Layer As Integer
        Public ObjectPos As Integer
        Public Data As Integer
        Public X As Single
        Public Y As Single
    End Structure



    Public Structure Class_Div_data_v1275 '階級区分データ（属性データ）
        Public Value As Double
        Public Cat_Name As String
        Public PaintColor As Integer
        Public TilePat As clsVB6File.Tile_Property_v11
        Public ClassMark As clsVB6File.Mark_Property_v11
        Public ODLinePat As clsVB6File.Line_Property_v11
    End Structure


    Public Structure Condition_DataSet_Info_v1275 ''属性検索データセット
        Public Enabled As Boolean
        Public Layer As Integer
        Public Name As String
    End Structure

    Public Structure Condition_Info_v1275 'データセット
        Public Num As Integer
        Public And_OR As Integer
    End Structure

    Public Structure Limitation_Info_v1275 '属性検索の条件データ
        Public Data As Integer
        Public Condition As Integer
        Public Val As String
    End Structure


    ' 図形------------------------------
    Public Structure Fig_Word_Data_v1275
        Public Caption As String
        Public Individual_Mode_F As Boolean
        Public Xstr As String '文字列の文字数分の座標を文字型でタブ区切り
        Public Ystr As String
        Public Font As clsVB6File.Font_Property_v11
        Public FontFringe As clsVB6File.FontFringe_Info
    End Structure
    Public Structure Fig_Line_Data_v1275
        Public NumOfPoint As Short
        Public PointStac As Integer
        Public Arrow As Arrow_Data_v1275
        Public FillFlag As Boolean
        Public Spline As Boolean
        Public Circumscribed_Rectangle As clsVB6File.Box_Data_single_v11
        Public Pat As clsVB6File.Line_Property_v11
        Public Tile As clsVB6File.Tile_Property_v11
    End Structure
    Public Structure Fig_Circle_data_v1275
        Public X As Single
        Public Y As Single
        Public XR As Single
        Public YR As Single
        Public Angle As Single
        Public Printcenter As Boolean
        Public Mark As clsVB6File.Mark_Property_v11
        Public Pat As clsVB6File.Line_Property_v11
        Public Tile As clsVB6File.Tile_Property_v11
    End Structure
    Public Structure Fig_Point_Data_v1275
        Public NumOfPoint As Short
        Public PointStac As Integer
        Public Mark As clsVB6File.Mark_Property_v11
        Public CaptionX As Single
        Public CaptionY As Single
        Public Caption_F As Boolean
        Public Caption As String
        Public Font As clsVB6File.Font_Property_v11
    End Structure
    Public Structure Fig_gazo_data_v1275
        Public X As Single
        Public Y As Single
        Public PictureNumber As Integer
        Public Size As Single
        Public LinePat As clsVB6File.Line_Property_v11
        Public Back As Boolean
        Public InnerCol_F As Boolean
        Public Inner_Color As Integer
        Public Angle As Integer
    End Structure
    Public Structure Figure_data_v1275
        Public Figure_code As Short
        Public Index As Integer
        Public Layer As Integer
        Public Data As Integer
        Public printed As Boolean
    End Structure

    Public Structure defObjInfo
        Public defName As String
        Public CenterP As PointF
    End Structure
    Public Structure MDR_1275
        Public TotalData As Total_Data_Info_v1275
        Public Layer() As Layer_Data_v1275
        Public KenCode() As KenCode_data_info
        Public attData() As Attribute_of_Data_v1275
        Public GraphMode_DataSet() As Graph_Data_v1275
        Public TripMode_DataSet() As Trip_Data_v1275
        Public LabelMode_DataSet() As Label_Data_v1275
        Public MapCompass As clsVB6File.Compass_Attri_v11
        Public Screen_Setting_DataSet() As Screen_Setting_Info_v1275

        Public LegendXY() As clsVB6File.SingleXY_v1275
        Public OverLay_DataSet() As OverLay_Dataset_Info_v1275
        Public OverLay_DataStac() As OvetLay_DataSet_Item_Info_v1275

        Public ODBezier_DataStac() As ODBezier_Data_v1275
        Public DataByteCell() As Byte
        Public DataIntegerCell() As Short
        Public DataLongCell() As Integer
        Public DataSingleCell() As Single
        Public DataDoubleCell() As Double
        Public Missing_DataStac() As Integer
        Public DataString() As String
        Public Series_DataSet() As Series_Dataset_Info_v1275
        Public Series_DataStac() As Series_DataSet_Item_Info_v1275

        Public Class_Div() As Class_Div_data_v1275
        Public Condition_DataSet() As Condition_DataSet_Info_v1275
        Public Condition_Class(,) As Condition_Info_v1275 '２次元（条件の段階（４で固定）,条件スタック）
        Public Condition(,,) As Limitation_Info_v1275 '３次元／（個別の条件（９）、条件の段階（４）、条件スタック）

        Public DefMPobj() As defObjInfo
        Public O_ObkNum As Integer
        Public ObkName() As String
        Public ObkShape() As Short
        Public O_Lpnum As Integer
        Public O_LP() As clsOldMapFile.LineKind_Data_v11

        Public MPSyntheticObj() As Synthetic_Object_Data_v1275

        Public Figure() As Figure_data_v1275
        Public Fig_Word() As Fig_Word_Data_v1275
        Public Fig_Line() As Fig_Line_Data_v1275
        Public Fig_Line_XY() As clsVB6File.SingleXY_v1275
        Public Fig_Circle() As Fig_Circle_data_v1275
        Public Fig_Point() As Fig_Point_Data_v1275
        Public Fig_Point_XY() As clsVB6File.SingleXY_v1275
        Public Fig_Gazo() As Fig_gazo_data_v1275
        Public BasePicture() As Picture_Property_v1275
        Public Dummy_Object_Mark() As clsVB6File.Mark_Property_v11
    End Structure

    Public Shared Function Get_OldMDRFile(ByVal MDRFilePath As String, ByRef MDR1275Data As MDR_1275, ByRef mapData As clsMapData,
                                          ByRef ProgressBar As ProgressBar) As Boolean

        Try
            Dim f As Boolean = getMDRFile(MDRFilePath, MDR1275Data, mapData, ProgressBar)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try


        Return True
    End Function

    ''' <summary>
    ''' 古いMDRファ府いる読み込み（1275未満）
    ''' </summary>
    ''' <param name="MDRFilePath"></param>
    ''' <param name="MDRData"></param>
    ''' <param name="mapData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getMDRFile(ByVal MDRFilePath As String, ByRef MDRData As MDR_1275, ByRef mapData As clsMapData,
                                       ByRef ProgressBar As ProgressBar) As Boolean
        Dim MDR_FileNumner As Short
        Dim fi As New System.IO.FileInfo(MDRFilePath)
        Dim Flen As Long = fi.Length

        Dim n As Integer = FreeFile()
        FileOpen(n, MDRFilePath, OpenMode.Binary, OpenAccess.Read, OpenShare.LockWrite)
        FileGet(n, MDR_FileNumner)
        If MDR_FileNumner < 1275 Then
            FileClose(n)
            Throw New Exception("このMDRファイルは古いバージョンなので読み込めません。")
            Return False
        End If
        With MDRData
            ProgressBar.Value = Seek(n) / Flen * 100

            FileGet(n, .TotalData.LV1)
            FileGet(n, .TotalData.StacSize)
            With .TotalData
                ReDim MDRData.Series_DataSet(.LV1.Series.Number)
                ReDim MDRData.Layer(.LV1.Lay_Maxn)
                ReDim MDRData.OverLay_DataSet(.LV1.OverLay.Number)
                With .StacSize
                    ReDim MDRData.Condition_DataSet(.ConditionDataSetNum)
                    ReDim MDRData.Condition_Class(4, .ConditionDataSetNum)
                    ReDim MDRData.Condition(9, 4, .ConditionDataSetNum)
                    ReDim MDRData.DataByteCell(.DataByteStacNum)
                    ReDim MDRData.DataIntegerCell(.DataintegerStacNum)
                    ReDim MDRData.DataLongCell(.DataLongStacNum)
                    ReDim MDRData.DataSingleCell(.DataSingleStacNum)
                    ReDim MDRData.DataDoubleCell(.DataDoubleStacNum)
                    ReDim MDRData.DataString(.DataStringStacNum)
                    ReDim MDRData.Class_Div(.ClassStacNum)
                    ReDim MDRData.OverLay_DataStac(.OverLayModeStacNum)
                    ReDim MDRData.Series_DataStac(.SeriesModeStacNum)
                    ReDim MDRData.ODBezier_DataStac(.ODBesierStacNum)
                    ReDim MDRData.MPSyntheticObj(.NumOfSymtheticObject)
                    ReDim MDRData.KenCode(.KenCodeStacNum)
                    ReDim MDRData.attData(.attDataStacNum)
                    ReDim MDRData.Missing_DataStac(.MissingStacNum)
                    ReDim MDRData.Screen_Setting_DataSet(.Screen_Setting_Num)
                    ReDim MDRData.GraphMode_DataSet(.GraphModeStacNum)
                    ReDim MDRData.TripMode_DataSet(.TripModeStacNum)
                    ReDim MDRData.LabelMode_DataSet(.LabelModeStacNum)
                    ReDim MDRData.BasePicture(.PictureNum)
                End With
                With .LV1
                    ReDim MDRData.DefMPobj(.DefN)
                    For i As Integer = 0 To .DefN - 1
                        With MDRData.DefMPobj(i)
                            .defName = clsVB6File.getStringsV11(MDR_FileNumner)
                            FileGet(n, .CenterP.X)
                            FileGet(n, .CenterP.Y)
                        End With
                    Next
                    If .MDRM_Flag = True Then
                        '地図ファイル付属形式の場合は地図データをここで取得する
                        With mapData
                            clsOldMapFile.get_OldMapFile2(n, .Map, .ObjectKind, .MPObj, .LineKind, .MPLine)
                            .NoDataFlag = False
                        End With
                    Else
                        ''通常のMDRファイルの場合は後で地図ファイルを読み込む
                    End If
                End With
            End With
            ProgressBar.Value = Seek(n) / Flen * 100

            FileGet(n, .O_ObkNum)
            ReDim .ObkName(.O_ObkNum - 1)
            ReDim .ObkShape(.O_ObkNum - 1)
            For i As Integer = 0 To .O_ObkNum - 1
                .ObkName(i) = clsVB6File.getStringsV11(n)
                FileGet(n, .ObkShape(i))
            Next

            For L As Integer = 0 To .TotalData.LV1.Lay_Maxn - 1
                With .Layer(L)
                    .Name = clsVB6File.getStringsV11(n)
                    FileGet(n, .Shape)
                    FileGet(n, .Time)
                    FileGet(n, .Data)
                    FileGet(n, .Print_Mode_Layer)
                    FileGet(n, .ObjectPos)
                    FileGet(n, .NumOfDummy)
                    .PLMark = clsVB6File.getMarkPropertyV11(n)
                    FileGet(n, .LayerMode)
                    Dim ub As Integer = clsVB6File.getArrayNumberInType(n)
                    If ub > 0 Then
                        ReDim .Dummy_ObjectKindUse(ub - 1)
                        For k As Integer = 0 To ub - 1
                            FileGet(n, .Dummy_ObjectKindUse(k))
                        Next
                    End If
                    ub = clsVB6File.getArrayNumberInType(n)
                    If ub > 0 Then
                        ReDim .DummySTC(ub - 1)
                        For k As Integer = 0 To ub - 1
                            FileGet(n, .DummySTC(k))
                        Next
                    End If
                    FileGet(n, .PolygonDummy_ClipSet_F)
                End With
            Next
            ProgressBar.Value = Seek(n) / Flen * 100

            ReDim .Dummy_Object_Mark(.O_ObkNum - 1)
            For i As Integer = 0 To .O_ObkNum - 1
                .Dummy_Object_Mark(i) = clsVB6File.getMarkPropertyV11(n)
            Next

            FileGet(n, .O_Lpnum)
            ReDim .O_LP(.O_Lpnum - 1)
            For i As Integer = 0 To .O_Lpnum - 1
                .O_LP(i) = clsVB6File.getLineKindV11(n)
            Next

            FileGet(n, .TotalData.ScrData.MapRectangle)

            '合成オブジェクト
            With .TotalData.StacSize
                For i As Integer = 0 To .NumOfSymtheticObject - 1
                    FileGet(n, MDRData.MPSyntheticObj(i))
                Next
            End With

            'グラフモードデータ
            With .TotalData.StacSize
                For i As Integer = 0 To .GraphModeStacNum - 1
                    With MDRData.GraphMode_DataSet(i)
                        ReDim .DatN(11)
                        ReDim .Tile(11)
                        .title = clsVB6File.getStringsV11(n)
                        FileGet(n, .MultiMode)
                        FileGet(n, .Datnum)
                        For k As Integer = 0 To 11
                            FileGet(n, .DatN(k))
                        Next
                        For k As Integer = 0 To 11
                            .Tile(k) = clsVB6File.getTilePropertyV11(n)
                        Next
                        With .En_Obi
                            FileGet(n, .EnSizeMode)
                            FileGet(n, .EnSize)
                            ReDim .Value(2)
                            For k As Integer = 0 To 2
                                FileGet(n, .Value(k))
                            Next
                            .BoaderLine = clsVB6File.getLinePropertyV11(n)
                            FileGet(n, .Tanpen)
                            FileGet(n, .TateYoko)
                            FileGet(n, .RMAX)
                            FileGet(n, .RMIN)
                            .title = clsVB6File.getStringsV11(n)
                            FileGet(n, .Shape)
                            FileGet(n, .MaxValueMode)
                            FileGet(n, .MaxValue)
                        End With
                        With .Oresen_Bou
                            FileGet(n, .EnSize)
                            .Line = clsVB6File.getLinePropertyV11(n)
                            FileGet(n, .Tanpen)
                            FileGet(n, .YMax)
                            FileGet(n, .Ymin)
                            FileGet(n, .Ystep)
                            .title = clsVB6File.getStringsV11(n)
                            FileGet(n, .Shape)
                            .WakuTile = clsVB6File.getTilePropertyV11(n)
                            .WakuLine = clsVB6File.getLinePropertyV11(n)
                        End With
                    End With
                Next
                '移動モードデータ
                For i As Integer = 0 To .TripModeStacNum - 1
                    FileGet(n, MDRData.TripMode_DataSet(i))
                Next
                'ラベルモードデータ

                For i As Integer = 0 To .LabelModeStacNum - 1
                    With MDRData.LabelMode_DataSet(i)
                        .title = clsVB6File.getStringsV11(n)
                        FileGet(n, .Location_Mark_Flag)
                        .Location_Mark = clsVB6File.getMarkPropertyV11(n)
                        FileGet(n, .Width)
                        .DataValue_Font = clsVB6File.getFontPropertyV11(n)
                        FileGet(n, .DataValue_Unit_Flag)
                        FileGet(n, .DataValue_TurnFlag)
                        FileGet(n, .DataValue_Print_Falg)
                        FileGet(n, .DataName_Print_Falg)
                        .Print_Data = clsVB6File.getStringsV11(n)
                        .ObjectName_Font = clsVB6File.getFontPropertyV11(n)
                        FileGet(n, .ObjectName_Print_Falg)
                        FileGet(n, .ObjectName_Turn_Falg)
                        .Dummy_Object_Font = clsVB6File.getFontPropertyV11(n)
                        FileGet(n, .Dummy_Object_Flag)
                        .Dummy_Object_Group_Font = clsVB6File.getFontPropertyV11(n)
                        FileGet(n, .Dummy_Object_Group_Name1_or_2)
                        FileGet(n, .Dummy_Object_Group_Flag)
                        .WakuObjectTile = clsVB6File.getTilePropertyV11(n)
                        .WakuDataTile = clsVB6File.getTilePropertyV11(n)
                        .WakuLine = clsVB6File.getLinePropertyV11(n)
                        FileGet(n, .FontFringe)
                    End With
                Next
                '重ね合わせモードデータ
                For i As Integer = 0 To MDRData.TotalData.LV1.OverLay.Number - 1
                    FileGet(n, MDRData.OverLay_DataSet(i))
                Next
                For i As Integer = 0 To .OverLayModeStacNum - 1
                    FileGet(n, MDRData.OverLay_DataStac(i))
                Next

                '連続表示モードデータ
                For i As Integer = 0 To MDRData.TotalData.LV1.Series.Number - 1
                    FileGet(n, MDRData.Series_DataSet(i))
                Next
                For i As Integer = 0 To .SeriesModeStacNum - 1
                    FileGet(n, MDRData.Series_DataStac(i))
                Next

                '階級区分データ
                For i As Integer = 0 To .ClassStacNum - 1
                    If i Mod 10 = 0 Then
                        ProgressBar.Value = Seek(n) / Flen * 100
                    End If
                    With MDRData.Class_Div(i)
                        FileGet(n, .Value)
                        .Cat_Name = clsVB6File.getStringsV11(n)
                        FileGet(n, .PaintColor)
                        .TilePat = clsVB6File.getTilePropertyV11(n)
                        .ClassMark = clsVB6File.getMarkPropertyV11(n)
                        .ODLinePat = clsVB6File.getLinePropertyV11(n)
                    End With
                Next
                'オブジェクトに付属するデータを
                For i As Integer = 0 To .KenCodeStacNum - 1
                    FileGet(n, MDRData.KenCode(i))
                Next

                'データ項目に関するデータを
                For i As Integer = 0 To .attDataStacNum - 1
                    If i Mod 100 = 0 Then
                        ProgressBar.Value = Seek(n) / Flen * 100
                    End If
                    With MDRData.attData(i)
                        FileGet(n, .DTA)
                        With .SoloMode
                            FileGet(n, .PaintMD)
                            With .CircleMD
                                .MinusTile = clsVB6File.getTilePropertyV11(n)
                                FileGet(n, .MaxValueMode)
                                FileGet(n, .MaxValue)
                                ReDim .Value(4)
                                For j As Integer = 0 To 4
                                    FileGet(n, .Value(j))
                                Next
                                .Mark = clsVB6File.getMarkPropertyV11(n)
                                FileGet(n, .Inner_Data)
                            End With
                            With .BlockMD
                                .MinusTile = clsVB6File.getTilePropertyV11(n)
                                FileGet(n, .Value)
                                FileGet(n, .ArrangeB)
                                FileGet(n, .Hasu)
                                .Mark = clsVB6File.getMarkPropertyV11(n)
                                FileGet(n, .Inner_Data)
                                FileGet(n, .Overlap)
                            End With
                            With .ContourMD
                                FileGet(n, .Interval_Mode)
                                FileGet(n, .Draw_in_Polygon_F)
                                FileGet(n, .Spline_flag)
                                FileGet(n, .Detailed)
                                With .Regular
                                    FileGet(n, .bottom)
                                    FileGet(n, .Interval)
                                    FileGet(n, .top)
                                    .Line_Pat = clsVB6File.getLinePropertyV11(n)
                                    FileGet(n, .SP_Bottom)
                                    FileGet(n, .SP_interval)
                                    FileGet(n, .SP_Top)
                                    .SP_Line_Pat = clsVB6File.getLinePropertyV11(n)
                                    .EX_Value = clsVB6File.getVariantType(n)
                                    .EX_Line_Pat = clsVB6File.getLinePropertyV11(n)
                                End With
                                With .Irregular
                                    ReDim .Value(9)
                                    For j As Integer = 0 To 9
                                        .Value(j) = clsVB6File.getVariantType(n)
                                    Next
                                    ReDim .Line_Pat(9)
                                    For j As Integer = 0 To 9
                                        .Line_Pat(j) = clsVB6File.getLinePropertyV11(n)
                                    Next
                                End With
                            End With
                            FileGet(n, .ODMD)
                            FileGet(n, .ClassMarkMD)
                            With .TurnMD
                                FileGet(n, .Dirction)
                                .Mark = clsVB6File.getMarkPropertyV11(n)
                                FileGet(n, .DegreeLap)
                                FileGet(n, .Inner_Data)
                            End With
                        End With
                        FileGet(n, .ModeData)

                    End With
                Next
                ProgressBar.Value = Seek(n) / Flen * 100

                For i As Integer = 0 To .DataByteStacNum - 1
                    FileGet(n, MDRData.DataByteCell(i))
                Next
                For i As Integer = 0 To .DataintegerStacNum - 1
                    FileGet(n, MDRData.DataIntegerCell(i))
                Next
                For i As Integer = 0 To .DataLongStacNum - 1
                    FileGet(n, MDRData.DataLongCell(i))
                Next
                For i As Integer = 0 To .DataSingleStacNum - 1
                    FileGet(n, MDRData.DataSingleCell(i))
                Next
                For i As Integer = 0 To .DataDoubleStacNum - 1
                    FileGet(n, MDRData.DataDoubleCell(i))
                Next
                For i As Integer = 0 To .DataStringStacNum - 1
                    MDRData.DataString(i) = clsVB6File.getStringsV11(n)
                Next
                ProgressBar.Value = Seek(n) / Flen * 100
                My.Application.DoEvents()

                '線モードのベジェ曲線データ
                For i As Integer = 0 To .ODBesierStacNum - 1
                    FileGet(n, MDRData.ODBezier_DataStac(i))
                Next

                '欠損値データ
                For i As Integer = 0 To .MissingStacNum - 1
                    FileGet(n, MDRData.Missing_DataStac(i))
                Next

                '属性検索条件
                For i As Integer = 0 To .ConditionDataSetNum - 1
                    FileGet(n, MDRData.Condition_DataSet(i))
                    For j As Integer = 0 To 4
                        FileGet(n, MDRData.Condition_Class(j, i))
                        For k As Integer = 0 To 9
                            FileGet(n, MDRData.Condition(k, j, i))
                        Next
                    Next
                Next
            End With

            '画像
            ProgressBar.Value = Seek(n) / Flen * 100

            For i As Integer = 0 To .TotalData.StacSize.PictureNum - 1
                With .BasePicture(i)
                    FileGet(n, .Width)
                    FileGet(n, .Height)
                    FileGet(n, .TransParency_f)
                    FileGet(n, .TransParency_Color)
                    FileGet(n, .Alternate_f)
                    FileGet(n, .Alternate_Color)
                    Dim b_size As Integer = .Width * .Height * 3
                    ReDim .bitmapbyte(b_size - 1)
                    Dim Comp_Size As Integer
                    FileGet(n, Comp_Size)
                    If Comp_Size > 0 Then
                        Dim Compress_Image(Comp_Size - 1) As Byte
                        For j As Integer = 0 To Comp_Size - 1
                            FileGet(n, Compress_Image(j))
                        Next
                        '10.0.1.6以降使用しない
                        '  clsALZS.ALZS_Expand(Compress_Image(0), Comp_Size, .bitmapbyte(0), 0, 0)
                    Else
                        For j As Integer = 0 To b_size - 1
                            FileGet(n, .bitmapbyte(j))
                        Next
                    End If
                End With
            Next
            ProgressBar.Value = Seek(n) / Flen * 100

            '図形
            FileGet(n, .TotalData.ViewStyle.Fig)
            With .TotalData.ViewStyle.Fig
                ReDim MDRData.Figure(.Number)
                ReDim MDRData.Fig_Word(.Word_n)
                ReDim MDRData.Fig_Line(.line_n)
                ReDim MDRData.Fig_Line_XY(.line_AP)
                ReDim MDRData.Fig_Circle(.Circle_n)
                ReDim MDRData.Fig_Point(.Point_n)
                ReDim MDRData.Fig_Point_XY(.Point_AP)
                ReDim MDRData.Fig_Gazo(.Gazo_n)
                For i As Integer = 0 To .Number - 1
                    FileGet(n, MDRData.Figure(i))

                Next

                For i = 0 To .Word_n - 1
                    With MDRData.Fig_Word(i)
                        .Caption = clsVB6File.getStringsV11(n)
                        FileGet(n, .Individual_Mode_F)
                        .Xstr = clsVB6File.getStringsV11(n)
                        .Ystr = clsVB6File.getStringsV11(n)
                        .Font = clsVB6File.getFontPropertyV11(n)
                        FileGet(n, .FontFringe)
                    End With
                Next

                For i = 0 To .line_n - 1
                    With MDRData.Fig_Line(i)
                        FileGet(n, .NumOfPoint)
                        FileGet(n, .PointStac)
                        FileGet(n, .Arrow)
                        FileGet(n, .FillFlag)
                        FileGet(n, .Spline)
                        FileGet(n, .Circumscribed_Rectangle)
                        .Pat = clsVB6File.getLinePropertyV11(n)
                        .Tile = clsVB6File.getTilePropertyV11(n)
                    End With
                Next
                For i = 0 To .line_AP - 1
                    FileGet(n, MDRData.Fig_Line_XY(i))
                Next

                For i = 0 To .Circle_n - 1
                    With MDRData.Fig_Circle(i)
                        FileGet(n, .X)
                        FileGet(n, .Y)
                        FileGet(n, .XR)
                        FileGet(n, .YR)
                        FileGet(n, .Angle)
                        FileGet(n, .Printcenter)
                        .Mark = clsVB6File.getMarkPropertyV11(n)
                        .Pat = clsVB6File.getLinePropertyV11(n)
                        .Tile = clsVB6File.getTilePropertyV11(n)
                    End With
                Next

                For i = 0 To .Point_n - 1
                    With MDRData.Fig_Point(i)
                        FileGet(n, .NumOfPoint)
                        FileGet(n, .PointStac)
                        .Mark = clsVB6File.getMarkPropertyV11(n)
                        FileGet(n, .CaptionX)
                        FileGet(n, .CaptionY)
                        FileGet(n, .Caption_F)
                        .Caption = clsVB6File.getStringsV11(n)
                        .Font = clsVB6File.getFontPropertyV11(n)
                    End With
                Next
                For i = 0 To .Point_AP - 1
                    FileGet(n, MDRData.Fig_Point_XY(i))
                Next

                For i = 0 To .Gazo_n - 1
                    With MDRData.Fig_Gazo(i)
                        FileGet(n, .X)
                        FileGet(n, .Y)
                        FileGet(n, .PictureNumber)
                        FileGet(n, .Size)
                        .LinePat = clsVB6File.getLinePropertyV11(n)
                        FileGet(n, .Back)
                        FileGet(n, .InnerCol_F)
                        FileGet(n, .Inner_Color)
                        FileGet(n, .Angle)
                    End With
                Next
            End With
            '飾り
            With .TotalData
                With .ScrData
                    FileGet(n, .frmPrint_FormSize)
                    FileGet(n, .ScreenMG)
                    FileGet(n, .ScrView)
                    FileGet(n, .Screen_Margin)
                End With
                With .ViewStyle
                    FileGet(n, .Accessory_Base_Set_Screen)
                    FileGet(n, .Comma_f)
                    FileGet(n, .ThreeDMode)
                    .MapLegend = getMapLegend(n)
                    With .MapLegend
                        ReDim MDRData.LegendXY(.Base.Legend_Num - 1)
                        For i = 0 To .Base.Legend_Num - 1
                            FileGet(n, MDRData.LegendXY(i))
                        Next
                    End With
                    .MapScale = getMapScale(n)
                    .MapTitle = getMapTitle(n)
                    .AttMapCompass = clsVB6File.getCompassAttri(n)
                    With .Screen_Back
                        .LinePat = clsVB6File.getLinePropertyV11(n)
                        .TileBack = clsVB6File.getTilePropertyV11(n)
                        .TileInner = clsVB6File.getTilePropertyV11(n)
                    End With
                    With .Missing_Data
                        FileGet(n, .Print_Flag)
                        .Text = clsVB6File.getStringsV11(n)
                        .PaintTile = clsVB6File.getTilePropertyV11(n)
                        .HatchTile = clsVB6File.getTilePropertyV11(n)
                        .Mark = clsVB6File.getMarkPropertyV11(n)
                        .BlockMark = clsVB6File.getMarkPropertyV11(n)
                        .ClassMark = clsVB6File.getMarkPropertyV11(n)
                        .TurnMark = clsVB6File.getMarkPropertyV11(n)
                        .Label = clsVB6File.getStringsV11(n)
                        .LineShape = clsVB6File.getLinePropertyV11(n)
                    End With
                    With .SymbolLine
                        FileGet(n, .Visible)
                        .Line = clsVB6File.getLinePropertyV11(n)
                    End With
                    With .Trip_Line
                        .Stay_Line = clsVB6File.getLinePropertyV11(n)
                        .Trip_Line = clsVB6File.getLinePropertyV11(n)
                        FileGet(n, .Height)
                        FileGet(n, .Frame_Print)
                        .Frame_Line = clsVB6File.getLinePropertyV11(n)
                        FileGet(n, .TimeLegend_Position)
                        .TimeLegend_Font = clsVB6File.getFontPropertyV11(n)
                        FileGet(n, .Start_End_Print)
                        .StartPoint_Mark = clsVB6File.getMarkPropertyV11(n)
                        .EndPoint_Mark = clsVB6File.getMarkPropertyV11(n)
                        FileGet(n, .ZeroPointF)
                        FileGet(n, .ZeroLineF)
                        .ZeroPoint_Mark = clsVB6File.getMarkPropertyV11(n)
                        .ZeroLine = clsVB6File.getLinePropertyV11(n)
                        FileGet(n, .Overlap_Mode)
                        FileGet(n, .VerticalLineF)
                        .VerticalLine = clsVB6File.getLinePropertyV11(n)
                    End With
                    FileGet(n, .PointPaint_Order)
                    FileGet(n, .Dummy_Size_Flag)
                    FileGet(n, .MapPrint_Flag)
                    With .IdoKeido_Print
                        FileGet(n, .Visible)
                        FileGet(n, .Order)
                        FileGet(n, .Ido_Interval)
                        FileGet(n, .Kedo_Interval)
                        .LPat = clsVB6File.getLinePropertyV11(n)
                    End With
                    FileGet(n, .SouByou)
                    FileGet(n, .OverLay_Legend_Title)
                    FileGet(n, .WMS)
                    With .ClassBoundaryLine
                        FileGet(n, .Visible)
                        .LPat = clsVB6File.getLinePropertyV11(n)
                    End With
                End With
                ProgressBar.Value = Seek(n) / Flen * 100

                For i = 0 To .StacSize.Screen_Setting_Num - 1
                    With MDRData.Screen_Setting_DataSet(i)
                        .title = clsVB6File.getStringsV11(n)
                        FileGet(n, .frmPrint_FormSize)
                        FileGet(n, .ThreeDMode)
                        FileGet(n, .ScrView)
                        FileGet(n, .Screen_Margin)
                        FileGet(n, .Accessory_Base_Set_Screen)
                        .MapScale = getMapScale(n)
                        .MapTitle = getMapTitle(n)
                        .AttMapCompass = clsVB6File.getCompassAttri(n)
                        .MapLegend = getMapLegend(n)
                        .LegendXstr = clsVB6File.getStringsV11(n)
                        .LegendYstr = clsVB6File.getStringsV11(n)
                    End With
                Next

            End With

        End With
        FileClose(n)
    End Function
    Private Shared Function getMapLegend(ByVal n As Integer) As Legend_Attri_v1275
        Dim lg As Legend_Attri_v1275
        With lg
            With .Base
                FileGet(n, .Visible)
                FileGet(n, .Legend_Num)
                .Font = clsVB6File.getFontPropertyV11(n)
                .BGTile = clsVB6File.getTilePropertyV11(n)
                .BGLine = clsVB6File.getLinePropertyV11(n)
            End With
            With .ClassMD
                .PaintMode_Line = clsVB6File.getLinePropertyV11(n)
                FileGet(n, .PaintMode_Method)
                FileGet(n, .PaintMode_Width)
                FileGet(n, .ClassMarkFrame_Visible)
                FileGet(n, .SeparateClassWords)
            End With
            With .MarkMD
                FileGet(n, .CircleMD_CircleMini_F)
                .CirclrMD_Plus_Text = clsVB6File.getStringsV11(n)
                .CirclrMD_Minus_Text = clsVB6File.getStringsV11(n)
                .MultiEnMode_Line = clsVB6File.getLinePropertyV11(n)
                .BlockMode_Text = clsVB6File.getStringsV11(n)
            End With
            With .Line_DummyKind
                FileGet(n, .Line_Visible)
                .Line_Visible_Number_STR = clsVB6File.getStringsV11(n)
                FileGet(n, .Line_Pattern)
                FileGet(n, .Dummy_Point_Visible)
                .BGTile = clsVB6File.getTilePropertyV11(n)
                .BGLine = clsVB6File.getLinePropertyV11(n)
            End With
            FileGet(n, .En_Graph_Pattern)

        End With
        Return lg
    End Function
    Private Shared Function getMapTitle(ByVal n As Integer) As Title_Attri_v1275
        Dim ttl As Title_Attri_v1275
        With ttl
            FileGet(n, .Visible)
            FileGet(n, .X)
            FileGet(n, .Y)
            .Font = clsVB6File.getFontPropertyV11(n)
        End With
        Return ttl
    End Function
    Private Shared Function getMapScale(ByVal n As Integer) As Scale_Attri_v1275
        Dim SC As Scale_Attri_v1275
        With SC
            FileGet(n, .Visible)
            FileGet(n, .X)
            FileGet(n, .Y)
            .Font = clsVB6File.getFontPropertyV11(n)
            FileGet(n, .BarPattern)
            FileGet(n, .BarAuto)
            FileGet(n, .BarDistance)
            FileGet(n, .BarKugiriNum)
            .BGTile = clsVB6File.getTilePropertyV11(n)
            .BGLine = clsVB6File.getLinePropertyV11(n)
        End With
        Return SC
    End Function
End Class
