//今昔マップ on the web:時系列地形図閲覧サイトデータセット
//このコードの改変および再配布を禁止します
//問い合わせ先：埼玉大学教育学部　谷謙二（人文地理学研究室）
//2013/9/15

var dataset_group = [{ num: 3, name: "三大都市圏" }, { num: 2, name: "広域5万図" }, { num: 7, name: "北海道" },{ num: 10, name: "東北" },
    { num: 10, name: "中部・近畿" }, { num: 11, name: "中国・四国" }, { num: 13, name: "九州・沖縄" }];
var kjmapDataSetList = new Array();
var RightMapGroup = [];
RightMapGroup['xxPic'] = "過去空中写真";
RightMapGroup['xxOldMap'] = "過去の地図";
RightMapGroup['xxTopo'] = "地形";
RightMapGroup['xxDisasterPic'] = "災害空中写真";
RightMapGroup['xxHazard'] = "ハザードマップ";
RightMapGroup['xxPopulation'] = "人口";
RightMapGroup['xxKjKanto'] = "今昔マップ関東編";
RightMapGroup['xxOther'] = "その他";
//'xxPic','xxOldMap','xxDisasterPic','xxHazard', 'xxTopo', 'xxPopulation','xxOther'
kjmapDataSetList.push({
   name: "首都圏",
   folderName: "tokyo50",
   certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平27情複、第1088号）",
   centerLat: 35.681287,
   centerLon: 139.763231,
   firstZoom:14,
   useRightMapType: ['xxPic','k_ort_RIKU10', 'k_ort_USA10', 'k_ort_old10', 'k_nlii1', 'k_nlii2', 'k_nlii3', 'k_nlii4','nendophoto2007-2009','xxDisasterPic','r1sakura','r1tamagawa','xxOldMap','habs','xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'k_LCM25K','k_LCM25K_2012','GSJseamless',  'xxHazard',  'hazard_flood', 'hazard_morido','xxPopulation','pop_density2010', 'pop_density2015','xxOther', 'KantoZoning2019','xxKjKanto','kjmapKanto0','kjmapKanto1','kjmapKanto2','kjmapKanto3']
});
kjmapDataSetList.push({
    name: "中京圏",
    folderName: "chukyo",
   certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平27情複、第1088号）",
    centerLat: 35.172883,
    centerLon: 136.889812,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_USA10', 'k_ort_old10', 'k_nlii1', 'k_nlii2', 'k_nlii4', 'nendophoto2007-2009','xxTopo','k_LCMFC02', 'k_afm', 'k_LCM25K','k_LCM25K_2012','GSJseamless','xxHazard', 'hazard_flood','hazard_morido','xxPopulation','pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "京阪神圏",
    folderName: "keihansin",
   certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平27情複、第1088号）",
    centerLat: 34.698777,
    centerLon: 135.49781,
    firstZoom:14,
    useRightMapType: ['xxPic','ort_osaka1928','ort_osaka1942','k_ort_USA10', 'k_ort_old10', 'k_nlii1', 'k_nlii2', 'k_nlii3', 'k_nlii4','nendophoto2007-2009', 'xxTopo','k_LCMFC01', 'k_LCMFC02', 'k_afm', 'k_LCM25K','k_LCM25K_2012', 'GSJseamless','xxHazard', 'hazard_flood', 'hazard_morido','xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "東北地方太平洋岸",
    folderName: "tohoku_pacific_coast",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平27情複、第1088号）",
    centerLat: 38.260091,
    centerLon: 140.883064,
    firstZoom:9,
    useRightMapType: ['xxPic','k_ort_USA10', 'k_ort_old10', 'k_nlii1', 'k_nlii3','xxDisasterPic','k_toho1', 'k_toho2', 'k_toho3', 'k_toho4','r1marumori', 'xxTopo','k_LCMFC01', 'k_LCMFC02', 'k_afm', 'k_LCM25K','k_LCM25K_2012', 'GSJseamless','xxHazard', 'hazard_flood', 'hazard_morido','xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "関東",
    folderName: "kanto",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平27情複、第1088号）",
    centerLat: 35.905879,
    centerLon: 139.62161,
    firstZoom:9,
    useRightMapType: ['xxPic','k_ort_USA10', 'k_ort_old10', 'k_nlii1', 'k_nlii2', 'k_nlii3', 'k_nlii4','xxDisasterPic','r1sakura','r1mobara', 'r1chikuma', 'r1tamagawa','r1tokigawa','r1nakagawa','r1kujigawa','r1kujigawa_daigo','k_kinugawaN', 'k_kinugawaS', 'atami20210706', 'xxOldMap', 'habs','xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'k_LCM25K','k_LCM25K_2012','GSJseamless','xxHazard', 'hazard_flood', 'hazard_morido','xxPopulation', 'pop_density2010', 'pop_density2015','xxOther', 'KantoZoning2019']
});
kjmapDataSetList.push({
   name: "札幌",
   folderName: "sapporo",
   certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平27情複、第1088号）",
   centerLat: 43.062057,
   centerLon: 141.354231,
   firstZoom:14,
   useRightMapType: ['xxPic','k_ort_USA10', 'k_ort_old10', 'k_nlii1', 'k_nlii3','xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm','GSJseamless','xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation','pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
   name: "旭川",
   folderName: "asahikawa",
   certification: "「測量法に基づく国土地理院長承認（複製）R 1JHf 1053」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
   centerLat: 43.776,
   centerLon: 142.354,
   firstZoom:14,
   useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1', 'nendophoto2008','xxTopo','k_LCMFC01', 'k_LCMFC02', 'GSJseamless','xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
   name: "釧路",
   folderName: "kushiro",
   certification: "「測量法に基づく国土地理院長承認（複製）R 2JHf 640」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
   centerLat: 42.98431,
   centerLon: 144.37537,
   firstZoom:14,
   useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1','nendophoto2011', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'GSJseamless','xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
   name: "帯広",
   folderName: "obihiro",
   certification: "「測量法に基づく国土地理院長承認（複製）R 2JHf 640」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
   centerLat: 42.92526,
   centerLon: 143.18443,
   firstZoom:14,
   useRightMapType: [ 'xxPic','k_ort_old10', 'k_nlii1', 'nendophoto2008','xxTopo','k_LCMFC01', 'k_LCMFC02', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
   name: "苫小牧",
   folderName: "tomakomai",
   certification: "「測量法に基づく国土地理院長承認（複製）R 2JHf 640」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
   centerLat: 42.651641,
   centerLon: 141.61749,
   firstZoom:12,
   useRightMapType: [ 'xxPic','k_ort_old10', 'k_nlii1','xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido','pop_density2010', 'pop_density2015']
});

kjmapDataSetList.push({
   name: "室蘭",
   folderName: "muroran",
   certification: "「測量法に基づく国土地理院長承認（複製）R 3JHf 184」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
   centerLat: 42.35296,
   centerLon: 140.99148,
   firstZoom:12,
   useRightMapType: ['xxPic', 'k_ort_old10', 'k_nlii1','xxTopo', 'GSJseamless',  'xxHazard', 'hazard_flood', 'hazard_morido','pop_density2010', 'pop_density2015']
});

kjmapDataSetList.push({
   name: "函館",
   folderName: "hakodate",
   certification: "「測量法に基づく国土地理院長承認（複製）R 1JHf 1053」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
   centerLat: 41.788,
   centerLon: 140.73,
   firstZoom:14,
   useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1', 'xxTopo', 'k_LCM25K','k_LCM25K_2012', 'k_afm', 'GSJseamless','xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "青森",
    folderName: "aomori",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第620号）",
    centerLat: 40.82563,
    centerLon: 140.7383,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'xxTopo', 'k_afm','k_LCM25K_2012', 'GSJseamless','xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "弘前",
    folderName: "hirosaki",
    certification: "測量法に基づく国土地理院長承認（複製）R 2JHf 490　本製品を複製する場合には、国土地理院の長の承認を得なければならない。",
    centerLat: 40.60731,
    centerLon: 140.46582,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'nendophoto2011','xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido','xxPopulation', 'pop_density2010', 'pop_density2015']
});

kjmapDataSetList.push({
    name: "盛岡",
    folderName: "morioka",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第859号）",
    centerLat: 39.706,
    centerLon: 141.153,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm','GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "岩手県南",
    folderName: "iwatekennan",
    certification: "測量法に基づく国土地理院長承認（複製）R 3JHf 270　本製品を複製する場合には、国土地理院の長の承認を得なければならない。",
    centerLat: 39.14005,
    centerLon: 141.13964,
    firstZoom:12,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm','GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
   name: "仙台",
   folderName: "sendai",
   certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平27情複、第1088号）",
   centerLat: 38.260563,
   centerLon: 140.877571,
   firstZoom:14,
   useRightMapType: ['xxPic','k_ort_USA10', 'k_ort_old10', 'k_nlii1', 'k_nlii3', 'nendophoto2008','xxDisasterPic', 'k_toho1', 'k_toho2', 'k_toho3', 'k_toho4','xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'k_LCM25K','k_LCM25K_2012', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "秋田",
    folderName: "akita",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第859号）",
    centerLat: 39.722,
    centerLon: 140.122,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1','xxTopo','k_LCMFC01', 'k_LCMFC02','k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido','xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "山形",
    folderName: "yamagata",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の 2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第1448号）",
    centerLat: 38.248,
    centerLon: 140.328,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1','nendophoto2007','xxTopo', 'k_LCMFC01', 'k_LCMFC02','k_afm', 'GSJseamless','xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "庄内",
    folderName: "syonai",
    certification: "測量法に基づく国土地理院長承認（複製）R3JHf28　本製品を複製する場合には、国土地理院の長の承認を得なければならない。",
    centerLat: 38.911,
    centerLon: 139.8401,
    firstZoom:12,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1','nendophoto2009','xxTopo', 'k_LCMFC01', 'k_LCMFC02','k_afm','GSJseamless',  'xxHazard', 'hazard_flood', 'hazard_morido','xxPopulation', 'pop_density2010', 'pop_density2015']
});

kjmapDataSetList.push({
   name: "福島",
   folderName: "fukushima",
    certification: "測量法に基づく国土地理院長承認（複製）R 1JHf 1288　本製品を複製する場合には、国土地理院の長の承認を得なければならない",
   centerLat: 37.7538,
   centerLon: 140.456571,
   firstZoom:14,
   useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1', 'nendophoto2007','xxTopo','k_LCMFC01', 'k_LCMFC02', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
   name: "会津",
   folderName: "aizu",
    certification: "測量法に基づく国土地理院長承認（複製）R 2JHf 490　本製品を複製する場合には、国土地理院の長の承認を得なければならない。",
   centerLat: 37.48794,
   centerLon: 139.92943,
   firstZoom:14,
   useRightMapType: ['xxPic', 'k_ort_old10','k_nlii1', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'GSJseamless',  'xxHazard', 'hazard_flood', 'hazard_morido','xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "新潟",
    folderName: "niigata",
   certification: "測量法に基づく国土地理院長承認（複製）R 3JHf 270　本製品を複製する場合には、国土地理院の長の承認を得なければならない。",
    centerLat: 37.918,
    centerLon: 139.047,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_USA10', 'k_ort_old10', 'k_nlii1','xxDisasterPic','niigata_eq','xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'k_LCM25K','k_LCM25K_2012', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido','xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "金沢・富山",
    folderName: "kanazawa",
   certification: "この地図は、国土地理院長の承認を得て、同院発行の 2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第1448号）",
    centerLat: 36.645,
    centerLon: 136.916,
    firstZoom:10,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_LCM25K','k_LCM25K_2012', 'k_afm','GSJseamless',  'xxHazard', 'hazard_flood', 'hazard_morido','xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "福井",
    folderName: "fukui",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第859号）",
    centerLat: 36.0622,
    centerLon: 136.222,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1','nendophoto2008','xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_LCM25K','k_LCM25K_2012', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "長野",
    folderName: "nagano",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第859号）",
    centerLat: 36.646385,
    centerLon: 138.2004551,
    firstZoom:14,
    useRightMapType: ['xxPic','k_nlii1','xxDisasterPic', 'r1chikuma', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02',  'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido','xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "松本",
    folderName: "matsumoto",
   certification: "「測量法に基づく国土地理院長承認（複製）R 1JHf 1053」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
    centerLat: 36.23749,
    centerLon: 137.9617,
    firstZoom:14,
    useRightMapType: ['xxPic','k_nlii1', 'xxTopo','k_LCMFC01', 'k_LCMFC02', 'k_LCM25K','k_LCM25K_2012', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "浜松・豊橋",
    folderName: "hamamatsu",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平27情複、第1088号）",
    centerLat: 34.733,
    centerLon: 137.59,
    firstZoom:11,
    useRightMapType: ['xxPic','k_ort_USA10','k_ort_old10', 'k_nlii1', 'k_nlii2', 'k_nlii4', 'nendophoto2008-2009','xxTopo','k_LCMFC01', 'k_LCMFC02', 'k_LCM25K','k_LCM25K_2012', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "津",
    folderName: "tsu",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　令元情複、第235号）",
    centerLat: 34.72243,
    centerLon: 136.50972,
    firstZoom:12,
    useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1', 'k_nlii2','xxTopo',  'k_LCMFC01', 'k_LCMFC02', 'k_LCM25K','k_LCM25K_2012', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "近江",
    folderName: "omi",
    certification: "「測量法に基づく国土地理院長承認（複製）R 3JHf 184」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
    centerLat: 35.26917,
    centerLon: 136.26133,
    firstZoom:12,
    useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1', 'k_nlii2', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_LCM25K','k_LCM25K_2012', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "姫路",
    folderName: "himeji",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平29情複、第1092号）",
    centerLat: 34.82,
    centerLon: 134.69,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1', 'k_nlii2', 'k_nlii3','xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'k_LCM25K','k_LCM25K_2012', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "和歌山",
    folderName: "wakayama",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の 2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第432号）",
    centerLat: 34.23,
    centerLon: 135.172,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1', 'k_nlii2', 'k_nlii3','xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_LCM25K', 'k_LCM25K_2012','k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "鳥取",
    folderName: "tottori",
   certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第1039号）",
    centerLat: 35.4993,
    centerLon: 134.2139,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02',  'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "松江・米子",
    folderName: "matsue",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の 2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　令元情複、第112号）",
    centerLat: 35.46,
    centerLon: 133.06,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "岡山・福山",
    folderName: "okayama",
    certification: "測量法に基づく国土地理院長承認（複製）R 1JHf 1288　本製品を複製する場合には、国土地理院の長の承認を得なければならない",
    centerLat: 34.64,
    centerLon: 133.841,
    firstZoom:12,
    useRightMapType: ['xxPic','k_ort_USA10', 'k_ort_old10', 'k_nlii1', 'k_nlii2', 'xxDisasterPic','h30gouu_okayama','h30gouu_fukuyama','h30gouu_mihara13','h30gouu_mihara15','xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_LCM25K','k_LCM25K_2012', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "広島",
    folderName: "hiroshima",
    certification: "測量法に基づく国土地理院長承認（複製）R 2JHf 589　本製品を複製する場合には、国土地理院の長の承認を得なければならない",
    centerLat: 34.396362,
    centerLon: 132.452602,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_USA10', 'k_ort_old10', 'k_nlii1', 'k_nlii2', 'k_nlii4', 'xxDisasterPic','k_hiroshimaDisaster', 'h30gouu_hiroshima','h30gouu_higashihiroshima','h30gouu_kuretobu', 'h30gouu_takehara','xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'k_LCM25K','k_LCM25K_2012', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "周南",
    folderName: "shunan",
   certification: "測量法に基づく国土地理院長承認（複製）R 3JHf 482　本製品を複製する場合には、国土地理院の長の承認を得なければならない",
    centerLat: 34.05159,
    centerLon: 131.80641,
    firstZoom:13,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'xxTopo', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "山口",
    folderName: "yamaguchi",
   certification: "この地図は、国土地理院長の承認を得て、同院発行の2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　令元情複、第235号）",
    centerLat: 34.08565,
    centerLon: 131.39568,
    firstZoom:12,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "徳島",
    folderName: "tokushima",
   certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第1039号）",
    centerLat: 34.0836,
    centerLon: 134.552,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1',  'xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_LCM25K','k_LCM25K_2012', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "高松",
    folderName: "takamatsu",
   certification: "この地図は、国土地理院長の承認を得て、同院発行の 2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第620号）",
    centerLat: 34.3458,
    centerLon: 134.0494,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'k_nlii2', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_LCM25K','k_LCM25K_2012', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "松山",
    folderName: "matsuyama",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の 2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第234号）",
    centerLat: 33.84,
    centerLon: 132.76,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02','k_LCM25K_2012', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "東予",
    folderName: "toyo",
    certification: "測量法に基づく国土地理院長承認（複製）R3JHf28　本製品を複製する場合には、国土地理院の長の承認を得なければならない。",
    centerLat: 33.95421,
    centerLon: 133.285875,
    firstZoom:11,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1','k_nlii2','xxTopo',  'k_LCM25K_2012', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "高知",
    folderName: "kochi",
   certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第1039号）",
    centerLat: 33.5627,
    centerLon: 133.5413,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1', 'xxTopo',  'k_LCMFC01', 'k_LCMFC02', 'k_LCM25K','k_LCM25K_2012', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "福岡・北九州",
    folderName: "fukuoka",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平27情複、第1088号）",
    centerLat: 33.739,
    centerLon: 130.613,
    firstZoom:10,
    useRightMapType: ['xxPic','k_ort_USA10', 'k_ort_old10', 'k_nlii1', 'k_nlii4','xxOldMap', 'QQmapkokura','QQmapfukuoka','QQmapshimonoseki10000-01', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'k_LCM25K', 'k_LCM25K_2012', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido',  'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "佐賀・久留米",
    folderName: "saga",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の 2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　令元情複、第112号）",
    centerLat: 33.2053,
    centerLon: 130.38466,
    firstZoom:12,
    useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1', 'k_nlii4', 'xxTopo',  'k_LCMFC01', 'k_LCMFC02', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});

kjmapDataSetList.push({
    name: "長崎",
    folderName: "nagasaki",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の 2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第234号）",
    centerLat: 32.746,
    centerLon: 129.876,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02', 'k_LCM25K_2012','k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "佐世保",
    folderName: "sasebo",
   certification: "「測量法に基づく国土地理院長承認（複製）R 1JHf 1053」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
    centerLat: 33.156,
    centerLon: 129.733,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'xxTopo',  'GSJseamless','xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "大牟田・島原",
    folderName: "omuta",
   certification: "「測量法に基づく国土地理院長承認（複製）R 3JHf 404」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
    centerLat: 33.0319,
    centerLon: 130.434837,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'xxTopo',  'GSJseamless','xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "熊本",
    folderName: "kumamoto",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平28情複、第1336号）",
    centerLat: 32.80553,
    centerLon: 130.70628,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_USA10', 'k_ort_old10', 'k_nlii1', 'xxDisasterPic', 'k_kumaN', 'k_kumaS', 'xxTopo','k_LCMFC01', 'k_LCMFC02','k_LCM25K_2012', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "八代",
    folderName: "yatsushiro",
    certification: "「測量法に基づく国土地理院長承認（複製）R 3JHf 404」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
    centerLat: 32.50802,
    centerLon: 130.60289,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_USA10', 'k_ort_old10', 'k_nlii1', 'xxDisasterPic', 'k_kumaS', 'xxTopo','k_LCMFC01', 'k_LCMFC02','k_LCM25K_2012', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "大分",
    folderName: "oita",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の 2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第234号）",
    centerLat: 33.235,
    centerLon: 131.606,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1','xxTopo',  'k_LCMFC01', 'k_LCMFC02','k_LCM25K_2012', 'k_afm', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "延岡",
    folderName: "nobeoka",
   certification: "「測量法に基づく国土地理院長承認（複製）R 3JHf 404」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
    centerLat: 32.58078,
    centerLon: 131.66398,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1','nendophoto2010', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02','k_LCM25K_2012', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});

kjmapDataSetList.push({
    name: "宮崎",
    folderName: "miyazaki",
   certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第1039号）",
    centerLat: 31.9091,
    centerLon: 131.424,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1','nendophoto2010', 'xxTopo', 'k_LCMFC01', 'k_LCMFC02','k_LCM25K_2012', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "都城",
    folderName: "miyakonojyou",
    certification: "「測量法に基づく国土地理院長承認（複製）R 2JHf 640」「本製品を複製する場合には、国土地理院の長の承認を得なければならない。」",
    centerLat: 31.71882,
    centerLon:131.06501,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10', 'k_nlii1','xxTopo',  'k_LCMFC01', 'k_LCMFC02', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "鹿児島",
    folderName: "kagoshima",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の 5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平30情複、第197号）",
    centerLat: 31.58,
    centerLon: 130.55,
    firstZoom:14,
    useRightMapType: ['xxPic','k_ort_old10','k_nlii1', 'nendophoto2010','xxTopo', 'k_vlcd', 'GSJseamless', 'xxHazard', 'hazard_flood', 'hazard_morido', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
kjmapDataSetList.push({
    name: "沖縄本島南部",
    folderName: "okinawas",
    certification: "この地図は、国土地理院長の承認を得て、同院発行の5万分1地形図、2万5千分1地形図及び2万分1正式図を複製したものである。（承認番号　平27情複、第1088号）",
    centerLat: 26.212319,
    centerLon: 127.680960,
    firstZoom:14,
    useRightMapType: ['xxPic','k_nlii1', 'xxOldMap','OkinawaAMS48','xxTopo',  'OkinawaAMS48DEM','GSJseamless', 'xxPopulation', 'pop_density2010', 'pop_density2015']
});
var kjmapDataSet = new Object();
kjmapDataSet['tokyo50'] = new Object();
dataset = kjmapDataSet['tokyo50'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1896, end:1909, scale:'1/20000', mapList: [
    {name:'拝島',north:35.7365539447165,west:139.299692289037,south:35.6698974550839,east:139.399686436082,note:'明治39年測図42年製版',list:''},
    {name:'八王子',north:35.6698947992986,west:139.299694948591,south:35.6032382888653,east:139.399689093953,note:'明治39年測図42年製版',list:''},
    {name:'上溝',north:35.6032356373567,west:139.299697599397,south:35.536579116109,east:139.399691743081,note:'明治39年測図42年製版',list:''},
    {name:'当麻',north:35.5365764688809,west:139.299700241483,south:35.4699199468051,east:139.399694383495,note:'明治39年測図41年製版',list:''},
    {name:'厚木',north:35.4699173038611,west:139.299702874879,south:35.4032607609471,east:139.399697015225,note:'明治39年測図',list:''},
    {name:'伊勢原',north:35.4032581222909,west:139.299705499612,south:35.336601568525,east:139.399699638298,note:'明治39年測図',list:''},
    {name:'大磯駅',north:35.3365989341603,west:139.299708115713,south:35.269942379529,east:139.399702252743,note:'明治20年測図29年修正',list:''},
    {name:'府中',north:35.7365566047748,west:139.399683769439,south:35.6699001179342,east:139.499677933325,note:'明治39年測図42年製版',list:''},
    {name:'連光寺',north:35.6698974550839,west:139.399686436082,south:35.6032409474276,east:139.499680598253,note:'明治39年測図42年製版',list:''},
    {name:'原町田',north:35.6032382888653,west:139.399689093953,south:35.5365817703795,east:139.499683254416,note:'明治39年測図42年製版',list:''},
    {name:'長津田',north:35.536579116109,west:139.399691743081,south:35.4699225967801,east:139.49968590184,note:'明治39年測図41年製版',list:''},
    {name:'用田',north:35.4699199468051,west:139.399694383495,south:35.4032634066228,east:139.499688540558,note:'明治39年測図42年製版',list:''},
    {name:'藤沢',north:35.4032607609471,west:139.399697015225,south:35.3366042098978,east:139.499691170596,note:'明治39年測図42年製版',list:''},
    {name:'江ノ島',north:35.336601568525,west:139.399699638298,south:35.2699450165951,east:139.499693791983,note:'明治20年測図41年鉄道補入',list:''},
    {name:'志木',north:35.8698775802953,west:139.499669885652,south:35.8032211078548,east:139.599664069909,note:'明治39年測図42年製版',list:''},
    {name:'膝折',north:35.8032184293598,west:139.499672577054,south:35.7365619461125,east:139.599666759552,note:'明治39年測図42年製版',list:''},
    {name:'田無',north:35.7365592719095,west:139.499675259602,south:35.6699027878416,east:139.599669440347,note:'明治39年測図42年製版',list:''},
    {name:'下布田',north:35.6699001179342,west:139.499677933325,south:35.6032436130354,east:139.599672112325,note:'明治39年測図42年製版',list:''},
    {name:'荏田',north:35.6032409474276,west:139.499680598253,south:35.5365844316841,east:139.599674775513,note:'明治39年測図42年製版',list:''},
    {name:'小机',north:35.5365817703795,west:139.499683254416,south:35.4699252537778,east:139.59967742994,note:'明治39年測図41年製版',list:''},
    {name:'保土谷',north:35.4699225967801,west:139.49968590184,south:35.4032660593099,east:139.599680075637,note:'明治39年測図41年製版',list:''},
    {name:'戸塚',north:35.4032634066228,west:139.499688540558,south:35.3366068582706,east:139.599682712632,note:'明治36年測図',list:''},
    {name:'鎌倉',north:35.3366042098978,west:139.499691170596,south:35.2699476606499,east:139.599685340952,note:'明治36年測図39年製版',list:''},
    {name:'浦和',north:35.8698802630785,west:139.599661371387,south:35.8032237934213,east:139.699655572584,note:'明治39年測図42年製版',list:''},
    {name:'白子',north:35.8032211078548,west:139.599664069909,south:35.7365646273757,east:139.699658269315,note:'明治42年測図大正2年製版',list:''},
    {name:'中野',north:35.7365619461125,west:139.599666759552,south:35.6699054647977,east:139.699660957174,note:'明治42年測図大正2年製版',list:''},
    {name:'世田ヶ谷',north:35.6699027878416,west:139.599669440347,south:35.6032462856807,east:139.699663636192,note:'明治42年測図大正2年製版',list:''},
    {name:'溝口',north:35.6032436130354,west:139.599672112325,south:35.5365871000149,east:139.699666306398,note:'明治39年測図42年製版',list:''},
    {name:'神奈川',north:35.5365844316841,west:139.599674775513,south:35.4699279177903,east:139.69966896782,note:'明治39年測図41年製版',list:''},
    {name:'横浜',north:35.4699252537778,west:139.59967742994,south:35.4032687190004,east:139.699671620488,note:'明治39年測図41年製版',list:''},
    {name:'杉田',north:35.4032660593099,west:139.599680075637,south:35.3366095136354,east:139.699674264432,note:'明治36年測図38年製版',list:''},
    {name:'横須賀',north:35.3366068582706,west:139.599682712632,south:35.2699503116852,east:139.699676899678,note:'明治39年測図40年製版',list:''},
    {name:'鳩谷',north:35.8698829529446,west:139.699652866952,south:35.8032264860512,east:139.799647085106,note:'明治39年測図42年製版',list:''},
    {name:'王子',north:35.8032237934213,west:139.699655572584,south:35.7365673156909,east:139.799649788916,note:'明治42年測図大正3年鉄道補入大正6年製版',list:''},
    {name:'東京首部',north:35.7365646273757,west:139.699658269315,south:35.6699081487945,east:139.799652483831,note:'明治42年測図',list:''},
    {name:'東京南部',north:35.6699054647977,west:139.699660957174,south:35.6032489653554,east:139.799655169882,note:'明治42年測図大正4年製版',list:''},
    {name:'大森',north:35.6032462856807,west:139.699663636192,south:35.5365897753637,east:139.799657847097,note:'明治39年測図41年製版',list:''},
    {name:'川崎',north:35.5365871000149,west:139.699666306398,south:35.4699305888095,east:139.799660515506,note:'明治39年測図41年製版',list:''},
    {name:'草加',north:35.8698856498853,west:139.799644372371,south:35.8032291857361,east:139.899638607501,note:'明治39年測図42年製版',list:''},
    {name:'千住',north:35.8032264860512,west:139.799647085106,south:35.7365700110499,east:139.899641318382,note:'明治42年測図大正2年製版',list:''},
    {name:'東京東部',north:35.7365673156909,west:139.799649788916,south:35.6699108398238,east:139.899644020345,note:'明治42年測図大正3年製版',list:''},
    {name:'州崎',north:35.6699081487945,west:139.799652483831,south:35.6032516520513,east:139.89964671342,note:'明治42年測図大正2年製版',list:''},
    {name:'小金',north:35.8698883538924,west:139.899635887672,south:35.803231892468,east:139.999630139794,note:'明治36年測図40年製版',list:''},
    {name:'国府台',north:35.8032291857361,west:139.899638607501,south:35.7365727134446,east:139.999632857738,note:'明治36年測図40年製版',list:''},
    {name:'船橋',north:35.7365700110499,west:139.899641318382,south:35.6699135378775,east:139.99963556674,note:'明治36年測図40年製版',list:''},
    {name:'沖割原',north:35.6699108398238,west:139.899644020345,south:35.6032543457601,east:139.999638266831,note:'明治36年測図38年製版',list:''},
    {name:'手賀',north:35.8698910649577,west:139.999627412879,south:35.8032346062385,east:140.099621682011,note:'明治36年測図39年製版',list:''},
    {name:'白井',north:35.803231892468,west:139.999630139794,south:35.7365754228666,east:140.099624407009,note:'明治36年測図39年製版',list:''},
    {name:'習志野',north:35.7365727134446,west:139.999632857738,south:35.6699162429472,east:140.099627123043,note:'明治36年測図40年製版42年補測43年改版',list:''},
    {name:'検見川',north:35.6699135378775,west:139.99963556674,south:35.6032570464738,east:140.099629830142,note:'明治36年測図42年補測',list:''},
    {name:'養老川口',north:35.6032543457601,west:139.999638266831,south:35.5365978434365,east:140.099632528337,note:'明治36年測図38年製版',list:''},
    {name:'木下',north:35.8698937830729,west:140.099618948019,south:35.8032373270395,east:140.199613234178,note:'明治39年測図40年製版',list:''},
    {name:'神崎',north:35.8032346062385,west:140.099621682011,south:35.7365781393078,east:140.199615966223,note:'明治37年測図40年製版',list:''},
    {name:'下津原',north:35.7365754228666,west:140.099624407009,south:35.6699189550248,east:140.199618689279,note:'明治36年測図38年製版42年補測43年改版',list:''},
    {name:'千葉',north:35.6699162429472,west:140.099627123043,south:35.603259754184,east:140.199621403379,note:'明治36年測図38年製版42年修正43年改版',list:''},
    {name:'曽我堅',north:35.6032570464738,west:140.099629830142,south:35.5366005467756,east:140.19962410855,note:'明治36年測図40年製版',list:''}
]});
dataset.age.push({
  folderName:'00', start:1917, end:1924, scale:'1/25000', mapList: [
    {name:'飯能',north:35.9198652494796,west:139.249689192069,south:35.8365446631398,east:139.374681873506,note:'大正12年測図・昭和1.12.28発行',list:'76-9-4-1'},
    {name:'川越',north:35.93097,west:139.374678513478,south:35.8365480039746,east:139.499671221352,note:'大正12年測図・大正15.5.30発行',list:'76-9-2-1'},
    {name:'与野',north:35.9198719333939,west:139.499667850162,south:35.8365513558802,east:139.624660584508,note:'大正13年測図・昭和1.12.28発行',list:''},
    {name:'浦和',north:35.9198752919984,west:139.624657202174,south:35.8365547188407,east:139.749649963026,note:'大正13年測図・昭和1.12.28発行',list:'76-5-2-3'},
    {name:'青梅',north:35.8365413333917,west:139.249692540921,south:35.753220730232,east:139.374685219723,note:'大正12年測図・大正15.4.30発行',list:'76-10-3-1'},
    {name:'所沢',north:35.8365446631398,west:139.374681873506,south:35.7532240643827,east:139.499674578683,note:'大正10年測図・大正14.5.30発行',list:'76-10-1-1'},
    {name:'志木',north:35.8365480039746,west:139.499671221352,south:35.7532274095821,east:139.624663952939,note:'大正6年測図・大正8.12.28発行',list:'76-6-3-1'},
    {name:'赤羽',north:35.8365513558802,west:139.624660584508,south:35.7532307658142,east:139.74965334254,note:'大正6年測図・大正8.12.28発行',list:'76-6-1-1'},
    {name:'草加',north:35.8365547188407,west:139.749649963026,south:35.7532341330632,east:139.874642747537,note:'大正6年測図・大正8.12.28発行',list:'76-2-3-1'},
    {name:'松戸',north:35.83655809284,west:139.874639356956,south:35.7532375113128,east:139.999632167981,note:'大正6年測図・大正8.12.28発行',list:'76-2-1-1'},
    {name:'白井',north:35.8365614778622,west:139.999628766349,south:35.7532409005472,east:140.124621603921,note:'大正10年測図・大正14.7.30発行',list:'67-14-3-1'},
    {name:'小林',north:35.8365648738911,west:140.124618191255,south:35.7532443007502,east:140.249611055409,note:'大正10年測図・大正14.5.30発行',list:'67-14-1-1'},
    {name:'拝島',north:35.7532174071459,west:139.249695876007,south:35.6698967871417,east:139.374688552186,note:'大正10年測図・大正13.10.30発行',list:'76-10-4-1'},
    {name:'府中',north:35.753220730232,west:139.374685219723,south:35.669900114601,east:139.499677922215,note:'大正10年測図・大正13.10.30発行',list:'76-10-2-1'},
    {name:'田無',north:35.7532240643827,west:139.499674578683,south:35.6699034530868,east:139.624667307524,note:'大正6年測図・大正8.12.28発行',list:''},
    {name:'東京西部',north:35.7532274095821,west:139.624663952939,south:35.6699068025833,east:139.749656708162,note:'大正5年測図8年鉄補・大正8.10.30発行',list:'76-6-2-13'},
    {name:'東京首部',north:35.7532307658142,west:139.74965334254,south:35.6699101630744,east:139.874646124181,note:'大正6年測図8年鉄補・大正8.10.30発行',list:'76-2-4-14'},
    {name:'船橋',north:35.7532341330632,west:139.874642747537,south:35.6699135345442,east:139.99963555563,note:'大正6年測図・大正8.12.28発行',list:'76-2-2-1'},
    {name:'習志野',north:35.7532375113128,west:139.999632167981,south:35.6699169169767,east:140.12462500256,note:'大正10年測図・大正14.4.30発行',list:'67-14-4-1'},
    {name:'佐倉',north:35.7532409005472,west:140.124621603921,south:35.6699203103557,east:140.24961446502,note:'大正10年測図・大正14.5.30発行',list:'67-14-2-1'},
    {name:'八王子',north:35.6698934707246,west:139.249699197385,south:35.5865728338514,east:139.374691870951,note:'大正10年測図・大正14.3.30発行',list:'76-11-3-1'},
    {name:'豊田',north:35.6698967871417,west:139.374688552186,south:35.5865761546121,east:139.499681252004,note:'大正10年測図・大正14.2.28発行',list:'76-11-1-1'},
    {name:'溝口',north:35.669900114601,west:139.499677922215,south:35.5865794863771,east:139.624670648321,note:'大正6年測図・大正8.12.28発行',list:'76-7-3-1'},
    {name:'東京西南部',north:35.6699034530868,west:139.624667307524,south:35.5865828291305,east:139.749660059951,note:'大正6年測図8年鉄補・大正8.9.30発行',list:''},
    {name:'東京南部',north:35.6699068025833,west:139.749656708162,south:35.5865861828565,east:139.874649486946,note:'大正6年測図・大正8.9.30発行',list:'76-3-3-1'},
    {name:'猫實',north:35.6699101630744,west:139.874646124181,south:35.5865895475391,east:139.999638929355,note:'大正6年測図・大正8.7.30発行',list:'76-3-1-8'},
    {name:'千葉西部',north:35.6699135345442,west:139.99963555563,south:35.5865929231622,east:140.124628387229,note:'大正10年測図・大正13.4.30発行',list:'67-15-3-1'},
    {name:'千葉東部',north:35.6699169169767,west:140.12462500256,south:35.5865963097099,east:140.249617860618,note:'大正10年測図・大正14.5.30発行',list:'67-15-1-1'},
    {name:'上溝',north:35.5865695241108,west:139.249702505111,south:35.503248870344,east:139.374695176076,note:'大正10年測図・大正14.2.28発行',list:'76-11-4-1'},
    {name:'原町田',north:35.5865728338514,west:139.374691870951,south:35.5032521843988,east:139.499684568108,note:'大正10年測図・大正14.2.28発行',list:'76-11-2-1'},
    {name:'川崎',north:35.5865794863771,west:139.624670648321,south:35.5032588454388,east:139.749663397965,note:'大正11年修正・大正14.2.25発行',list:'76-7-2-1'},
    {name:'五井',north:35.5865895475391,west:139.999638929355,south:35.5032689190867,east:140.124631757987,note:'大正10年測図・大正13.1.30発行',list:'67-15-4-1'},
    {name:'曽我野',north:35.5865929231622,west:140.124628387229,south:35.5032722987957,east:140.249621242259,note:'大正10年測図・大正14.3.30発行',list:'67-15-2-1'},
    {name:'厚木',north:35.5032455672871,west:139.249705799242,south:35.4199248966023,east:139.374698467618,note:'大正10年測図・大正14.3.25発行',list:'76-12-3-1'},
    {name:'座間',north:35.503248870344,west:139.374695176076,south:35.419928203944,east:139.499687870583,note:'大正10年測図・大正13.12.25発行',list:'76-12-1-1'},
    {name:'横浜西部',north:35.5032521843988,west:139.499684568108,south:35.4199315222454,east:139.62467728878,note:'大正11年測図・大正14.1.30発行',list:'76-8-3-1'},
    {name:'横浜東部',north:35.5032555094357,west:139.624673975387,south:35.4199348514909,east:139.749666722259,note:'大正11年測図・大正14.1.30発行',list:'76-8-1-12'},
    {name:'伊勢原',north:35.4199216002363,west:139.249709079834,south:35.3366009126092,east:139.374701745632,note:'大正10年測図・大正13.12.25発行',list:'76-12-4-1'},
    {name:'藤沢',north:35.4199248966023,west:139.374698467618,south:35.3366042132304,east:139.499691159485,note:'大正10年測図・大正14.5.25発行',list:'76-12-2-1'},
    {name:'戸塚',north:35.419928203944,west:139.499687870583,south:35.3366075247892,east:139.624680588555,note:'大正10年測図・大正14.3.25発行',list:'76-8-4-1'},
    {name:'本牧',north:35.4199315222454,west:139.62467728878,south:35.3366108472699,east:139.749670032891,note:'大正10年測図・大正12.9.25発行',list:'76-8-2-1'},
    {name:'大磯',north:35.3365976229412,west:139.249712346944,south:35.2532769183475,east:139.374705010174,note:'大正10年測図・大正12.11.25発行',list:'77-9-3-1'},
    {name:'江ノ島',north:35.3366009126092,west:139.374701745632,south:35.2532802122411,east:139.499694434871,note:'大正10年測図・大正12.11.25発行',list:'77-9-1-1'},
    {name:'鎌倉',north:35.3366042132304,west:139.499691159485,south:35.2532835170501,east:139.624683874769,note:'大正10年測図・大正13.6.25発行',list:'77-5-3-1'}
]});
dataset.age.push({
  folderName:'01', start:1927, end:1939, scale:'1/25000', mapList: [
    {name:'飯能',north:35.9198652494796,west:139.249689192069,south:35.8365446631398,east:139.374681873506,note:'昭和14年部修・昭和15.11.30発行',list:'76-9-4-3',war:true},
    {name:'川越',north:35.93097,west:139.374678513478,south:35.8365480039746,east:139.499671221352,note:'大正12年測図昭和2年鉄補・昭和4.1.30発行',list:'76-9-2-2'},
    {name:'浦和',north:35.9198752919984,west:139.624657202174,south:35.8365547188407,east:139.749649963026,note:'大正13年測図昭和4年鉄補・昭和22.4.30発行',list:''},
    {name:'越ヶ谷',north:35.9198786616799,west:139.749646569563,south:35.83655809284,east:139.874639356956,note:'昭和3年測図・昭和5.12.28発行',list:'76-1-4-1'},
    {name:'流山',north:35.9198820424223,west:139.874635952381,south:35.8365614778622,east:139.999628766349,note:'昭和3年測図・昭和5.12.28発行',list:'76-1-2-1'},
    {name:'取手',north:35.9198854342096,west:139.999625350678,south:35.8365648738911,east:140.124618191255,note:'昭和3年測図・昭和5.1.30発行',list:'67-13-4-1'},
    {name:'龍ヶ崎',north:35.9198888370256,west:140.124614764503,south:35.8365682809106,east:140.249607631725,note:'昭和3年測図・昭和5.4.30発行',list:'67-13-2-1'},
    {name:'青梅',north:35.8365413333917,west:139.249692540921,south:35.753220730232,east:139.374685219723,note:'昭和12年修正・昭和22.5.30発行',list:'76-10-3-3'},
    {name:'所沢',north:35.8365446631398,west:139.374681873506,south:35.7532240643827,east:139.499674578683,note:'昭和12年修正・昭和22.5.30発行',list:'76-10-1-6'},
    {name:'志木',north:35.8365480039746,west:139.499671221352,south:35.7532274095821,east:139.624663952939,note:'昭和7年要修・昭和7.10.30発行',list:'76-6-3-3'},
    {name:'赤羽',north:35.8365513558802,west:139.624660584508,south:35.7532307658142,east:139.74965334254,note:'昭和7年要修・昭和7.10.30発行',list:'76-6-1-4'},
    {name:'草加',north:35.8365547188407,west:139.749649963026,south:35.7532341330632,east:139.874642747537,note:'昭和4年二修・昭和6.12.28発行',list:'76-2-3-3'},
    {name:'松戸',north:35.83655809284,west:139.874639356956,south:35.7532375113128,east:139.999632167981,note:'昭和7年要修・昭和7.10.30発行',list:'76-2-1-4'},
    {name:'拝島',north:35.7532174071459,west:139.249695876007,south:35.6698967871417,east:139.374688552186,note:'昭和12年修正・昭和22.5.30発行',list:'76-10-4-5'},
    {name:'府中',north:35.753220730232,west:139.374685219723,south:35.669900114601,east:139.499677922215,note:'昭和5年二部・昭和5.7.30発行',list:'76-10-2-3'},
    {name:'吉祥寺',north:35.7532240643827,west:139.499674578683,south:35.6699034530868,east:139.624667307524,note:'昭和2年修正・昭和4.8.30発行',list:'76-6-4-1'},
    {name:'東京西部',north:35.7532274095821,west:139.624663952939,south:35.6699068025833,east:139.749656708162,note:'昭和4年二修・昭和6.6.30発行',list:'76-6-2-1'},
    {name:'東京首部',north:35.7532307658142,west:139.74965334254,south:35.6699101630744,east:139.874646124181,note:'昭和5年測図・昭和7.6.30発行',list:'76-2-4-1'},
    {name:'船橋',north:35.7532341330632,west:139.874642747537,south:35.6699135345442,east:139.99963555563,note:'昭和7年要修・昭和7.10.30発行',list:'76-2-2-4'},
    {name:'習志野',north:35.7532375113128,west:139.999632167981,south:35.6699169169767,east:140.12462500256,note:'昭和4年部修・昭和7.10.30発行',list:'67-14-4-3'},
    {name:'佐倉',north:35.7532409005472,west:140.124621603921,south:35.6699203103557,east:140.24961446502,note:'昭和4年部修・昭和7.7.30発行',list:'67-14-2-3'},
    {name:'八王子',north:35.6698934707246,west:139.249699197385,south:35.5865728338514,east:139.374691870951,note:'昭和4年部修5年鉄補・昭和22.5.30発行',list:'76-11-3-3'},
    {name:'豊田',north:35.6698967871417,west:139.374688552186,south:35.5865761546121,east:139.499681252004,note:'大正10年測図昭和4年鉄補・昭和5.12.28発行',list:'76-11-1-3'},
    {name:'溝口',north:35.669900114601,west:139.499677922215,south:35.5865794863771,east:139.624670648321,note:'昭和7年要修・昭和7.10.30発行',list:'76-7-3-4'},
    {name:'東京西南部',north:35.6699034530868,west:139.624667307524,south:35.5865828291305,east:139.749660059951,note:'昭和4年二修・昭和6.6.30発行',list:'76-7-1-2'},
    {name:'東京南部',north:35.6699068025833,west:139.749656708162,south:35.5865861828565,east:139.874649486946,note:'昭和7年要修・昭和7.10.30発行',list:'76-3-3-3'},
    {name:'浦安',north:35.6699101630744,west:139.874646124181,south:35.5865895475391,east:139.999638929355,note:'昭和7年要修・昭和7.10.30発行',list:'76-3-1-2'},
    {name:'千葉西部',north:35.6699135345442,west:139.99963555563,south:35.5865929231622,east:140.124628387229,note:'昭和5年部修・昭和7.8.30発行',list:'67-15-3-3'},
    {name:'千葉東部',north:35.6699169169767,west:140.12462500256,south:35.5865963097099,east:140.249617860618,note:'昭和4年部修・昭和7.3.30発行',list:'67-15-1-2'},
    {name:'原町田',north:35.5865728338514,west:139.374691870951,south:35.5032521843988,east:139.499684568108,note:'大正10年測図昭和4年鉄補・昭和5.12.28発行',list:'76-11-2-3'},
    {name:'荏田',north:35.5865761546121,west:139.499681252004,south:35.5032555094357,east:139.624673975387,note:'昭和7年要修・昭和7.11.30発行',list:'76-7-4-1'},
    {name:'川崎',north:35.5865794863771,west:139.624670648321,south:35.5032588454388,east:139.749663397965,note:'昭和7年要修・昭和7.10.30発行',list:'76-7-2-2'},
    {name:'穴守',north:35.5865828291305,west:139.749660059951,south:35.5032621923923,east:139.87465283589,note:'昭和7年要修・昭和7.10.30発行',list:'76-3-4-1'},
    {name:'五井',north:35.5865895475391,west:139.999638929355,south:35.5032689190867,east:140.124631757987,note:'大正10年測図昭和2年鉄補・昭和3.2.28発行',list:'67-15-4-2'},
    {name:'厚木',north:35.5032455672871,west:139.249705799242,south:35.4199248966023,east:139.374698467618,note:'大正10年測図昭和2年鉄補・昭和3.12.28発行',list:'76-12-3-3'},
    {name:'座間',north:35.503248870344,west:139.374695176076,south:35.419928203944,east:139.499687870583,note:'大正10年測図昭和2年鉄補・昭和3.11.30発行',list:'76-12-1-3'},
    {name:'横浜西部',north:35.5032521843988,west:139.499684568108,south:35.4199315222454,east:139.62467728878,note:'昭和6年修正・昭和7.12.28発行',list:'76-8-3-4'},
    {name:'横浜東部',north:35.5032555094357,west:139.624673975387,south:35.4199348514909,east:139.749666722259,note:'昭和6年修正・昭和7.12.28発行',list:'76-8-1-14'},
    {name:'伊勢原',north:35.4199216002363,west:139.249709079834,south:35.3366009126092,east:139.374701745632,note:'昭和12年二修・昭和16.3.25発行',list:'76-12-4-6'},
    {name:'藤沢',north:35.4199248966023,west:139.374698467618,south:35.3366042132304,east:139.499691159485,note:'昭和12年二修・昭和22.5.30発行',list:'76-12-2-6'},
    {name:'戸塚',north:35.419928203944,west:139.499687870583,south:35.3366075247892,east:139.624680588555,note:'昭和6年修正・昭和8.9.30発行',list:'76-8-4-4'},
    {name:'本牧',north:35.4199315222454,west:139.62467728878,south:35.3366108472699,east:139.749670032891,note:'昭和6年修正・昭和8.11.30発行',list:'76-8-2-3'},
    {name:'平塚',north:35.3365976229412,west:139.249712346944,south:35.2532769183475,east:139.374705010174,note:'昭和14年二修・昭和22.6.30発行',list:'77-9-3-4'},
    {name:'江ノ島',north:35.3366009126092,west:139.374701745632,south:35.2532802122411,east:139.499694434871,note:'昭和14年二修・昭和22.8.30発行',list:'77-9-1-4'}
]});
dataset.age.push({
  folderName:'02', start:1944, end:1954, scale:'1/25000', mapList: [
    {name:'岩槻',north:36.003199217954,west:139.624653805877,south:35.9198786616799,east:139.749646569563,note:'昭和28年測量・昭和31.11.30発行',list:'76-5-1-1'},
    {name:'野田市',north:36.0032025943492,west:139.749643162092,south:35.9198820424223,east:139.874635952381,note:'昭和28年測量・昭和31.11.30発行',list:'76-1-3-1'},
    {name:'守谷',north:36.0032059818273,west:139.874632533752,south:35.9198854342096,east:139.999625350678,note:'昭和27年測量・昭和29.1.30発行',list:'76-1-1-3'},
    {name:'藤代',north:36.0032093803722,west:139.999621920906,south:35.9198888370256,east:140.124614764503,note:'昭和27年測量・昭和28.12.28発行',list:'67-13-3-1'},
    {name:'牛久',north:36.0032127899679,west:140.124611323606,south:35.9198922508541,east:140.249604193909,note:'昭和27年測量・昭和28.12.28発行',list:'67-13-1-1'},
    {name:'飯能',north:35.9198652494796,west:139.249689192069,south:35.8365446631398,east:139.374681873506,note:'昭和24年修正・昭和27.8.30発行',list:'76-9-4-5'},
    {name:'川越',north:35.93097,west:139.374678513478,south:35.8365480039746,east:139.499671221352,note:'昭和24年修正27年資修・昭和31.11.30発行',list:'76-9-2-4'},
    {name:'与野',north:35.9198719333939,west:139.499667850162,south:35.8365513558802,east:139.624660584508,note:'昭和24年修正・昭和27.8.30発行',list:''},
    {name:'浦和',north:35.9198752919984,west:139.624657202174,south:35.8365547188407,east:139.749649963026,note:'昭和24年二修27年資修・昭和27.10.30発行',list:''},
    {name:'越ガ谷',north:35.9198786616799,west:139.749646569563,south:35.83655809284,east:139.874639356956,note:'昭和24年二修・昭和27.8.30発行',list:'76-1-4-3'},
    {name:'流山',north:35.9198820424223,west:139.874635952381,south:35.8365614778622,east:139.999628766349,note:'昭和24年二修27年資修・昭和27.8.30発行',list:'76-1-2-3'},
    {name:'取手',north:35.9198854342096,west:139.999625350678,south:35.8365648738911,east:140.124618191255,note:'昭和24年二修・昭和31.11.30発行',list:'67-13-4-3'},
    {name:'龍ヶ崎',north:35.9198888370256,west:140.124614764503,south:35.8365682809106,east:140.249607631725,note:'昭和24年修正・昭和31.11.30発行',list:'67-13-2-3'},
    {name:'青梅',north:35.8365413333917,west:139.249692540921,south:35.753220730232,east:139.374685219723,note:'昭和24年二修27年資修・昭和27.11.30発行',list:'76-10-3-5'},
    {name:'所沢',north:35.8365446631398,west:139.374681873506,south:35.7532240643827,east:139.499674578683,note:'昭和12年修正23年資修・昭和23.8.30発行',list:'76-10-1-7'},
    {name:'志木',north:35.8365480039746,west:139.499671221352,south:35.7532274095821,east:139.624663952939,note:'昭和20年部修・昭和22.7.30発行',list:'76-6-3-4'},
    {name:'赤羽',north:35.8365513558802,west:139.624660584508,south:35.7532307658142,east:139.74965334254,note:'昭和20年部修・昭和22.7.30発行',list:'76-6-1-5'},
    {name:'草加',north:35.8365547188407,west:139.749649963026,south:35.7532341330632,east:139.874642747537,note:'昭和20年部修・昭和22.8.30発行',list:'76-2-3-6'},
    {name:'松戸',north:35.83655809284,west:139.874639356956,south:35.7532375113128,east:139.999632167981,note:'昭和19年部修・昭和22.5.30発行',list:'76-2-1-6'},
    {name:'白井',north:35.8365614778622,west:139.999628766349,south:35.7532409005472,east:140.124621603921,note:'昭和27年二修・昭和31.11.30発行',list:'67-14-3-3'},
    {name:'小林',north:35.8365648738911,west:140.124618191255,south:35.7532443007502,east:140.249611055409,note:'昭和27年二修・昭和31.11.30発行',list:'67-14-1-3'},
    {name:'拝島',north:35.7532174071459,west:139.249695876007,south:35.6698967871417,east:139.374688552186,note:'昭和24年二修・昭和27.11.30発行',list:'76-10-4-6'},
    {name:'立川',north:35.753220730232,west:139.374685219723,south:35.669900114601,east:139.499677922215,note:'昭和12年修正22年資修・昭和22.4.30発行',list:'76-10-2-5'},
    {name:'吉祥寺',north:35.7532240643827,west:139.499674578683,south:35.6699034530868,east:139.624667307524,note:'昭和20年部修・昭和22.7.30発行',list:'76-6-4-3'},
    {name:'東京西部',north:35.7532274095821,west:139.624663952939,south:35.6699068025833,east:139.749656708162,note:'昭和20年部修・昭和22.7.30発行',list:'76-6-2-4'},
    {name:'東京首部',north:35.7532307658142,west:139.74965334254,south:35.6699101630744,east:139.874646124181,note:'昭和20年部修22年資修・昭和22.7.30発行',list:'76-2-4-4'},
    {name:'船橋',north:35.7532341330632,west:139.874642747537,south:35.6699135345442,east:139.99963555563,note:'昭和20年部修・昭和22.5.30発行',list:''},
    {name:'習志野',north:35.7532375113128,west:139.999632167981,south:35.6699169169767,east:140.12462500256,note:'昭和27年二修・昭和29.7.30発行',list:'67-14-4-6'},
    {name:'佐倉',north:35.7532409005472,west:140.124621603921,south:35.6699203103557,east:140.24961446502,note:'昭和27年二修・昭和31.11.30発行',list:'67-14-2-5'},
    {name:'八王子',north:35.6698934707246,west:139.249699197385,south:35.5865728338514,east:139.374691870951,note:'昭和2年部修23年資修・昭和23.8.30発行',list:'76-11-3-4'},
    {name:'武蔵府中',north:35.6698967871417,west:139.374688552186,south:35.5865761546121,east:139.499681252004,note:'昭和29年修正・昭和32.3.30発行',list:'76-11-1-6'},
    {name:'溝口',north:35.669900114601,west:139.499677922215,south:35.5865794863771,east:139.624670648321,note:'昭和20年部修28年資修・昭和28.12.28発行',list:'76-7-3-22'},
    {name:'東京西南部',north:35.6699034530868,west:139.624667307524,south:35.5865828291305,east:139.749660059951,note:'昭和20年部修・昭和22.7.30発行',list:'76-7-1-4'},
    {name:'東京南部',north:35.6699068025833,west:139.749656708162,south:35.5865861828565,east:139.874649486946,note:'昭和20年部修・昭和22.7.30発行',list:'76-3-3-5'},
    {name:'浦安',north:35.6699101630744,west:139.874646124181,south:35.5865895475391,east:139.999638929355,note:'昭和20年部修・昭和22.5.30発行',list:'76-3-1-4'},
    {name:'千葉西部',north:35.6699135345442,west:139.99963555563,south:35.5865929231622,east:140.124628387229,note:'昭和27年三修・昭和31.2.28発行',list:'67-15-3-6'},
    {name:'千葉東部',north:35.6699169169767,west:140.12462500256,south:35.5865963097099,east:140.249617860618,note:'昭和27年二修・昭和31.11.30発行',list:'67-15-1-5'},
    {name:'上溝',north:35.5865695241108,west:139.249702505111,south:35.503248870344,east:139.374695176076,note:'大正10年測図昭和24年資修・昭和24.7.30発行',list:'76-11-4-3'},
    {name:'原町田',north:35.5865728338514,west:139.374691870951,south:35.5032521843988,east:139.499684568108,note:'昭和29年修正・昭和32.2.28発行',list:'76-11-2-5'},
    {name:'荏田',north:35.5865761546121,west:139.499681252004,south:35.5032555094357,east:139.624673975387,note:'昭和20年部修・昭和22.8.30発行',list:'76-7-4-2'},
    {name:'川崎',north:35.5865794863771,west:139.624670648321,south:35.5032588454388,east:139.749663397965,note:'昭和20年部修・昭和22.7.30発行',list:'76-7-2-3'},
    {name:'穴守',north:35.5865828291305,west:139.749660059951,south:35.5032621923923,east:139.87465283589,note:'昭和20年部修・昭和22.9.30発行',list:'76-3-4-3'},
    {name:'五井',north:35.5865895475391,west:139.999638929355,south:35.5032689190867,east:140.124631757987,note:'昭和27年修正・昭和31.11.30発行',list:'67-15-4-4'},
    {name:'厚木',north:35.5032455672871,west:139.249705799242,south:35.4199248966023,east:139.374698467618,note:'昭和29年修正・昭和32.6.30発行',list:'76-12-3-6'},
    {name:'座間',north:35.503248870344,west:139.374695176076,south:35.419928203944,east:139.499687870583,note:'昭和29年修正・昭和32.3.30発行',list:'76-12-1-5'},
    {name:'横浜西部',north:35.5032521843988,west:139.499684568108,south:35.4199315222454,east:139.62467728878,note:'昭和20年部修・昭和22.9.30発行',list:'76-8-3-5'},
    {name:'横浜東部',north:35.5032555094357,west:139.624673975387,south:35.4199348514909,east:139.749666722259,note:'昭和20年部修・昭和22.7.30発行',list:'76-8-1-3'},
    {name:'伊勢原',north:35.4199216002363,west:139.249709079834,south:35.3366009126092,east:139.374701745632,note:'昭和29年三修・昭和32.6.30発行',list:'76-12-4-9'},
    {name:'藤沢',north:35.4199248966023,west:139.374698467618,south:35.3366042132304,east:139.499691159485,note:'昭和29年二修・昭和32.4.30発行',list:'76-12-2-8'},
    {name:'戸塚',north:35.419928203944,west:139.499687870583,south:35.3366075247892,east:139.624680588555,note:'昭和20年部修・昭和22.8.30発行',list:'76-8-4-5'},
    {name:'本牧',north:35.4199315222454,west:139.62467728878,south:35.3366108472699,east:139.749670032891,note:'昭和20年部修・昭和22.8.30発行',list:'76-8-2-4'},
    {name:'平塚',north:35.3365976229412,west:139.249712346944,south:35.2532769183475,east:139.374705010174,note:'昭和29年三修・昭和32.10.30発行',list:'77-9-3-5'},
    {name:'江ノ島',north:35.3366009126092,west:139.374701745632,south:35.2532802122411,east:139.499694434871,note:'昭和29年三修・昭和31.11.30発行',list:'77-9-1-6'},
    {name:'鎌倉',north:35.3366042132304,west:139.499691159485,south:35.2532835170501,east:139.624683874769,note:'大正10年測図昭和22年資修・昭和22.8.30発行',list:'77-5-3-2'},
    {name:'横須賀',north:35.3366075247892,west:139.624680588555,south:35.2532868327585,east:139.749673329917,note:'大正10年測図昭和22年資修・昭和23.1.30発行',list:'77-5-1-2'}
]});
dataset.age.push({
  folderName:'03', start:1965, end:1968, scale:'1/25000', mapList: [
    {name:'越生',north:36.003189078297,west:139.246797187739,south:35.9198685086489,east:139.371789871211,note:'昭和42年改測・昭和44.1.30発行',list:'76-9-3-2'},
    {name:'川越北部',north:36.0031924210896,west:139.371786497571,south:35.9198718559039,east:139.496779207541,note:'昭和42年改測・昭和44.1.30発行',list:'76-9-1-2'},
    {name:'上尾',north:36.0031957750136,west:139.496775822695,south:35.9198752142522,east:139.621768559198,note:'昭和42年改測・昭和44.3.30発行',list:'76-5-3-2'},
    {name:'岩槻',north:36.003199140053,west:139.62176516316,south:35.9198785836779,east:139.746757926232,note:'昭和42年改測・昭和44.3.30発行',list:'76-5-1-2'},
    {name:'野田市',north:36.0032025161917,west:139.746754519019,south:35.9198819641648,east:139.871747308692,note:'昭和43年修正・昭和45.4.30発行',list:'76-1-3-2'},
    {name:'守谷',north:36.0032059034139,west:139.871743890321,south:35.919885355697,east:139.996736706631,note:'昭和43年修正・昭和45.4.30発行',list:'76-1-1-4'},
    {name:'藤代',north:36.0032093017033,west:139.996733277116,south:35.9198887582583,east:140.121726120097,note:'昭和43年修正・昭和44.11.30発行',list:'67-13-3-2'},
    {name:'牛久',north:36.0032127110437,west:140.121722679457,south:35.9198921718326,east:140.246715549142,note:'昭和43年修正・昭和45.4.30発行',list:'67-13-1-3'},
    {name:'飯能',north:35.9198651725031,west:139.246800550155,south:35.8365445860604,east:139.371793230981,note:'昭和42年改測・昭和44.2.28発行',list:'76-9-4-6'},
    {name:'川越南部',north:35.9198685086489,west:139.371789871211,south:35.8365479266391,east:139.496782578473,note:'昭和42年改測・昭和44.3.30発行',list:'76-9-2-6'},
    {name:'与野',north:35.9198718559039,west:139.496779207541,south:35.8365512782891,east:139.621771941275,note:'昭和42年改測・昭和44.1.30発行',list:'76-5-4-4'},
    {name:'浦和',north:35.9198752142522,west:139.621768559198,south:35.8365546409943,east:139.746761319438,note:'昭和42年改測・昭和44.2.28発行',list:'76-5-2-6'},
    {name:'越谷',north:35.9198785836779,west:139.746757926232,south:35.8365580147387,east:139.871750713011,note:'昭和42年改測・昭和44.11.30発行',list:'76-1-4-4'},
    {name:'流山',north:35.9198819641648,west:139.871747308692,south:35.8365613995063,east:139.996740122046,note:'昭和42年改測・昭和43.10.30発行',list:'76-1-2-5'},
    {name:'取手',north:35.919885355697,west:139.996736706631,south:35.836564795281,east:140.121729546593,note:'昭和42年改測・昭和44.3.30発行',list:'67-13-4-4'},
    {name:'龍ヶ崎',north:35.9198887582583,west:140.121726120097,south:35.8365682020467,east:140.246718986702,note:'昭和42年改測・昭和44.1.30発行',list:'67-13-2-5'},
    {name:'青梅',north:35.8365412565687,west:139.246803898748,south:35.7532206533069,east:139.371796576941,note:'昭和41年改測・昭和42.10.10発行',list:'76-10-3-7'},
    {name:'所沢',north:35.8365445860604,west:139.371793230981,south:35.753223987202,east:139.496785935548,note:'昭和41年改測・昭和42.10.10発行',list:'76-10-1-9'},
    {name:'志木',north:35.8365479266391,west:139.496782578473,south:35.7532273321462,east:139.62177530945,note:'昭和41年改測・昭和42.10.10発行',list:'76-6-3-7'},
    {name:'赤羽',north:35.8365512782891,west:139.621771941275,south:35.7532306881236,east:139.746764698695,note:'昭和41年改測・昭和42.10.10発行',list:'76-6-1-9'},
    {name:'草加',north:35.8365546409943,west:139.746761319438,south:35.753234055118,east:139.871754103336,note:'昭和40年改測・昭和42.10.10発行',list:'76-2-3-9'},
    {name:'松戸',north:35.8365580147387,west:139.871750713011,south:35.7532374331137,east:139.996743523422,note:'昭和40年改測・昭和42.10.10発行',list:'76-2-1-10'},
    {name:'白井',north:35.8365613995063,west:139.996740122046,south:35.7532408220944,east:140.121732959004,note:'昭和42年改測・昭和44.2.28発行',list:'67-14-3-4'},
    {name:'小林',north:35.836564795281,west:140.121729546593,south:35.7532442220441,east:140.246722410132,note:'昭和42年改測・昭和44.1.30発行',list:'67-14-1-5'},
    {name:'拝島',north:35.7532173304766,west:139.246807233577,south:35.6698967103709,east:139.371799909148,note:'昭和41年改測・昭和42.10.10発行',list:'76-10-4-8'},
    {name:'立川',north:35.7532206533069,west:139.371796576941,south:35.6699000375752,east:139.496789278825,note:'昭和41年改測・昭和42.10.10発行',list:'76-10-2-10'},
    {name:'吉祥寺',north:35.753223987202,west:139.496785935548,south:35.6699033758063,east:139.62177866378,note:'昭和41年改測・昭和42.10.10発行',list:'76-6-4-8'},
    {name:'東京西部',north:35.7532273321462,west:139.62177530945,south:35.6699067250485,east:139.746768064063,note:'昭和41年改測・昭和42.10.10発行',list:'76-6-2-6'},
    {name:'東京首部',north:35.7532306881236,west:139.746764698695,south:35.6699100852857,east:139.871757479726,note:'昭和40年改測・昭和42.6.30発行',list:'76-2-4-7'},
    {name:'船橋',north:35.753234055118,west:139.871754103336,south:35.669913456502,east:139.996746910817,note:'昭和40年改測・昭和42.10.10発行',list:'76-2-2-10'},
    {name:'習志野',north:35.7532374331137,west:139.996743523422,south:35.6699168386813,east:140.121736357389,note:'昭和42年改測・昭和44.1.30発行',list:'67-14-4-8'},
    {name:'佐倉',north:35.7532408220944,west:140.121732959004,south:35.6699202318075,east:140.24672581949,note:'昭和42年改測・昭和44.3.30発行',list:'67-14-2-6'},
    {name:'八王子',north:35.6698933942092,west:139.246810554698,south:35.5865727572352,east:139.371803227658,note:'昭和41年改測・昭和42.10.10発行',list:'76-11-3-7'},
    {name:'武蔵府中',north:35.6698967103709,west:139.371799909148,south:35.5865760777413,east:139.496792608359,note:'昭和41年改測・昭和42.10.10発行',list:'76-11-1-7'},
    {name:'溝口',north:35.6699000375752,west:139.496789278825,south:35.5865794092522,east:139.621782004322,note:'昭和41年改測・昭和42.10.10発行',list:'76-7-3-7'},
    {name:'東京西南部',north:35.6699033758063,west:139.62177866378,south:35.5865827517518,east:139.746771415598,note:'昭和41年改測・昭和42.10.10発行',list:'76-7-1-6'},
    {name:'東京南部',north:35.6699067250485,west:139.746768064063,south:35.5865861052244,east:139.871760842237,note:'昭和41年改測・昭和42.10.10発行',list:'76-3-3-7'},
    {name:'浦安',north:35.6699100852857,west:139.871757479726,south:35.5865894696539,east:139.996750284289,note:'昭和41年改測・昭和42.10.10発行',list:'76-3-1-5'},
    {name:'千葉西部',north:35.669913456502,west:139.996746910817,south:35.5865928450244,east:140.121739741805,note:'昭和42年改測・昭和43.10.30発行',list:'67-15-3-7'},
    {name:'千葉東部',north:35.6699168386813,west:140.121736357389,south:35.5865962313198,east:140.246729214835,note:'昭和42年改測・昭和43.11.30発行',list:'67-15-1-6'},
    {name:'上溝',north:35.5865694477494,west:139.246813862169,south:35.5032487938825,east:139.371806532529,note:'昭和41年改測・昭和42.10.10発行',list:'76-11-4-5'},
    {name:'原町田',north:35.5865727572352,west:139.371803227658,south:35.5032521076833,east:139.496795924209,note:'昭和41年改測・昭和42.10.10発行',list:'76-11-2-6'},
    {name:'荏田',north:35.5865760777413,west:139.496792608359,south:35.5032554324665,east:139.621785331136,note:'昭和41年改測・昭和42.10.10発行',list:'76-7-4-3'},
    {name:'川崎',north:35.5865794092522,west:139.621782004322,south:35.5032587682164,east:139.746774753359,note:'昭和41年改測・昭和42.10.10発行',list:'76-7-2-6'},
    {name:'東京国際空港',north:35.5865827517518,west:139.746771415598,south:35.503262114917,east:139.871764190929,note:'昭和41年改測・昭和42.10.10発行',list:'76-3-4-4'},
    {name:'五井',north:35.5865894696539,west:139.996750284289,south:35.5032688411067,east:140.121743112312,note:'昭和42年改測・昭和43.12.28発行',list:'67-15-4-6'},
    {name:'蘇我',north:35.5865928450244,west:140.121739741805,south:35.5032722205639,east:140.246732596225,note:'昭和42年改測・昭和43.10.30発行',list:'67-15-2-4'},
    {name:'厚木',north:35.5032454910799,west:139.246817156045,south:35.4199248202957,east:139.371809823818,note:'昭和41年改測・昭和42.10.10発行',list:'76-12-3-7'},
    {name:'座間',north:35.5032487938825,west:139.371806532529,south:35.4199281273838,east:139.496799226432,note:'昭和41年改測・昭和42.10.10発行',list:'76-12-1-6'},
    {name:'横浜西部',north:35.5032521076833,west:139.496795924209,south:35.4199314454322,east:139.621788644276,note:'昭和41年改測・昭和42.9.30発行',list:'76-8-3-9'},
    {name:'横浜東部',north:35.5032554324665,west:139.621785331136,south:35.4199347744249,east:139.746778077401,note:'昭和41年改測・昭和42.10.10発行',list:'76-8-1-5'},
    {name:'奈良輪',north:35.503262114917,west:139.871764190929,south:35.4199414651803,east:139.996756989696,note:'昭和43年修正・昭和45.3.30発行',list:'76-4-1-2'},
    {name:'姉崎',north:35.5032654725524,west:139.996753643896,south:35.4199448269111,east:140.121746468966,note:'昭和43年修正・昭和44.12.28発行',list:'67-16-3-2'},
    {name:'伊勢原',north:35.4199215241835,west:139.246820436385,south:35.3366008364576,east:139.37181310158,note:'昭和41年改測・昭和42.10.10発行',list:'76-12-4-10'},
    {name:'藤沢',north:35.4199248202957,west:139.371809823818,south:35.3366041368259,east:139.496802515082,note:'昭和41年改測・昭和42.10.10発行',list:'76-12-2-9'},
    {name:'戸塚',north:35.4199281273838,west:139.496799226432,south:35.3366074481321,east:139.6217919438,note:'昭和41年改測・昭和42.9.30発行',list:'76-8-4-10'},
    {name:'本牧',north:35.4199314454322,west:139.621788644276,south:35.3366107703605,east:139.746781387782,note:'昭和41年改測・昭和42.10.10発行',list:'76-8-2-6'},
    {name:'平塚',north:35.3365975470429,west:139.246823703242,south:35.2532768423511,east:139.371816365871,note:'昭和41年改測・昭和42.10.10発行',list:'77-9-3-6'},
    {name:'江ノ島',north:35.3366008364576,west:139.37181310158,south:35.2532801359923,east:139.496805790218,note:'昭和41年改測・昭和42.10.10発行',list:'77-9-1-7'},
    {name:'鎌倉',north:35.3366041368259,west:139.496802515082,south:35.2532834405491,east:139.621795229763,note:'昭和41年改測・昭和42.10.10発行',list:'77-5-3-7'},
    {name:'横須賀',north:35.3366074481321,west:139.6217919438,south:35.2532867560059,east:139.746784684559,note:'昭和41年改測・昭和42.10.10発行',list:'77-5-1-5'}
]});
dataset.age.push({
  folderName:'04', start:1975, end:1978, scale:'1/25000', mapList: [
    {name:'越生',north:36.003189078297,west:139.246797187739,south:35.9198685086489,east:139.371789871211,note:'昭和52年二改・昭和53.9.30発行',list:'76-9-3-5'},
    {name:'川越北部',north:36.0031924210896,west:139.371786497571,south:35.9198718559039,east:139.496779207541,note:'昭和52年改測・昭和54.2.28発行',list:'76-9-1-5'},
    {name:'上尾',north:36.0031957750136,west:139.496775822695,south:35.9198752142522,east:139.621768559198,note:'昭和51年二改・昭和53.1.30発行',list:'76-5-3-7'},
    {name:'岩槻',north:36.003199140053,west:139.62176516316,south:35.9198785836779,east:139.746757926232,note:'昭和51年二改・昭和52.7.30発行',list:'76-5-1-6'},
    {name:'野田市',north:36.0032025161917,west:139.746754519019,south:35.9198819641648,east:139.871747308692,note:'昭和51年二改・昭和53.1.30発行',list:'76-1-3-5'},
    {name:'守谷',north:36.0032059034139,west:139.871743890321,south:35.919885355697,east:139.996736706631,note:'昭和51年二改・昭和52.12.28発行',list:'76-1-1-7'},
    {name:'藤代',north:36.0032093017033,west:139.996733277116,south:35.9198887582583,east:140.121726120097,note:'昭和52年改測・昭和53.10.30発行',list:'67-13-3-3'},
    {name:'牛久',north:36.0032127110437,west:140.121722679457,south:35.9198921718326,east:140.246715549142,note:'昭和52年改測・昭和53.12.28発行',list:'67-13-1-4'},
    {name:'飯能',north:35.9198651725031,west:139.246800550155,south:35.8365445860604,east:139.371793230981,note:'昭和52年二改・昭和55.2.28発行',list:'76-9-4-9'},
    {name:'川越南部',north:35.9198685086489,west:139.371789871211,south:35.8365479266391,east:139.496782578473,note:'昭和52年二改・昭和54.2.28発行',list:'76-9-2-9'},
    {name:'与野',north:35.9198718559039,west:139.496779207541,south:35.8365512782891,east:139.621771941275,note:'昭和51年二改・昭和53.6.30発行',list:'76-5-4-8'},
    {name:'浦和',north:35.9198752142522,west:139.621768559198,south:35.8365546409943,east:139.746761319438,note:'昭和51年二改・昭和53.1.30発行',list:'76-5-2-9'},
    {name:'越谷',north:35.9198785836779,west:139.746757926232,south:35.8365580147387,east:139.871750713011,note:'昭和51年二改・昭和52.12.28発行',list:'76-1-4-8'},
    {name:'流山',north:35.9198819641648,west:139.871747308692,south:35.8365613995063,east:139.996740122046,note:'昭和51年二改・昭和53.3.30発行',list:'76-1-2-9'},
    {name:'取手',north:35.919885355697,west:139.996736706631,south:35.836564795281,east:140.121729546593,note:'昭和52年修正・昭和54.2.28発行',list:'67-13-4-7'},
    {name:'龍ヶ崎',north:35.9198887582583,west:140.121726120097,south:35.8365682020467,east:140.246718986702,note:'昭和52年修正・昭和53.8.30発行',list:'67-13-2-7'},
    {name:'青梅',north:35.8365412565687,west:139.246803898748,south:35.7532206533069,east:139.371796576941,note:'昭和51年二改・昭和52.6.30発行',list:'76-10-3-11'},
    {name:'所沢',north:35.8365445860604,west:139.371793230981,south:35.753223987202,east:139.496785935548,note:'昭和51年二改・昭和52.7.30発行',list:'76-10-1-13'},
    {name:'志木',north:35.8365479266391,west:139.496782578473,south:35.7532273321462,east:139.62177530945,note:'昭和51年二改・昭和52.12.28発行',list:'76-6-3-11'},
    {name:'赤羽',north:35.8365512782891,west:139.621771941275,south:35.7532306881236,east:139.746764698695,note:'昭和51年二改・昭和53.1.30発行',list:'76-6-1-13'},
    {name:'草加',north:35.8365546409943,west:139.746761319438,south:35.753234055118,east:139.871754103336,note:'昭和51年二改・昭和52.12.28発行',list:'76-2-3-13'},
    {name:'松戸',north:35.8365580147387,west:139.871750713011,south:35.7532374331137,east:139.996743523422,note:'昭和51年二改・昭和53.1.30発行',list:'76-2-1-13'},
    {name:'白井',north:35.8365613995063,west:139.996740122046,south:35.7532408220944,east:140.121732959004,note:'昭和53年二改・昭和54.11.30発行',list:'67-14-3-8'},
    {name:'小林',north:35.836564795281,west:140.121729546593,south:35.7532442220441,east:140.246722410132,note:'昭和53年改測・昭和55.1.30発行',list:'67-14-1-8'},
    {name:'拝島',north:35.7532173304766,west:139.246807233577,south:35.6698967103709,east:139.371799909148,note:'昭和51年二改・昭和52.5.30発行',list:'76-10-4-13'},
    {name:'立川',north:35.7532206533069,west:139.371796576941,south:35.6699000375752,east:139.496789278825,note:'昭和51年二改・昭和52.5.30発行',list:'76-10-2-15'},
    {name:'吉祥寺',north:35.753223987202,west:139.496785935548,south:35.6699033758063,east:139.62177866378,note:'昭和51年二改・昭和53.2.28発行',list:'76-6-4-12'},
    {name:'東京西部',north:35.7532273321462,west:139.62177530945,south:35.6699067250485,east:139.746768064063,note:'昭和51年二改・昭和52.12.28発行',list:'76-6-2-10'},
    {name:'東京首部',north:35.7532306881236,west:139.746764698695,south:35.6699100852857,east:139.871757479726,note:'昭和51年二改・昭和53.2.28発行',list:'76-2-4-11'},
    {name:'船橋',north:35.753234055118,west:139.871754103336,south:35.669913456502,east:139.996746910817,note:'昭和51年二改・昭和52.10.30発行',list:'76-2-2-13'},
    {name:'習志野',north:35.7532374331137,west:139.996743523422,south:35.6699168386813,east:140.121736357389,note:'昭和53年二改・昭和55.1.30発行',list:'67-14-4-12'},
    {name:'佐倉',north:35.7532408220944,west:140.121732959004,south:35.6699202318075,east:140.24672581949,note:'昭和53年二改・昭和55.1.30発行',list:'67-14-2-10'},
    {name:'八王子',north:35.6698933942092,west:139.246810554698,south:35.5865727572352,east:139.371803227658,note:'昭和50年二改・昭和52.1.30発行',list:'76-11-3-12'},
    {name:'武蔵府中',north:35.6698967103709,west:139.371799909148,south:35.5865760777413,east:139.496792608359,note:'昭和50年二改・昭和52.1.30発行',list:'76-11-1-12'},
    {name:'溝口',north:35.6699000375752,west:139.496789278825,south:35.5865794092522,east:139.621782004322,note:'昭和51年二改・昭和53.2.28発行',list:'76-7-3-12'},
    {name:'東京西南部',north:35.6699033758063,west:139.62177866378,south:35.5865827517518,east:139.746771415598,note:'昭和51年二改・昭和53.2.28発行',list:'76-7-1-11'},
    {name:'東京南部',north:35.6699067250485,west:139.746768064063,south:35.5865861052244,east:139.871760842237,note:'昭和51年二改・昭和53.1.30発行',list:'76-3-3-11'},
    {name:'浦安',north:35.6699100852857,west:139.871757479726,south:35.5865894696539,east:139.996750284289,note:'昭和51年二改・昭和53.3.30発行',list:'76-3-1-10'},
    {name:'千葉西部',north:35.669913456502,west:139.996746910817,south:35.5865928450244,east:140.121739741805,note:'昭和53年二改・昭和55.1.30発行',list:'67-15-3-11'},
    {name:'千葉東部',north:35.6699168386813,west:140.121736357389,south:35.5865962313198,east:140.246729214835,note:'昭和53年改測・昭和55.3.30発行',list:'67-15-1-10'},
    {name:'上溝',north:35.5865694477494,west:139.246813862169,south:35.5032487938825,east:139.371806532529,note:'昭和50年二改・昭和52.3.30発行',list:'76-11-4-9'},
    {name:'原町田',north:35.5865727572352,west:139.371803227658,south:35.5032521076833,east:139.496795924209,note:'昭和50年二改・昭和52.1.30発行',list:'76-11-2-11'},
    {name:'荏田',north:35.5865760777413,west:139.496792608359,south:35.5032554324665,east:139.621785331136,note:'昭和51年二改・昭和53.3.30発行',list:'76-7-4-8'},
    {name:'川崎',north:35.5865794092522,west:139.621782004322,south:35.5032587682164,east:139.746774753359,note:'昭和51年二改・昭和53.2.28発行',list:'76-7-2-10'},
    {name:'東京国際空港',north:35.5865827517518,west:139.746771415598,south:35.503262114917,east:139.871764190929,note:'昭和51年二改・昭和51.1.30発行',list:'76-3-4-7'},
    {name:'五井',north:35.5865894696539,west:139.996750284289,south:35.5032688411067,east:140.121743112312,note:'昭和53年二改・昭和55.8.30発行',list:'67-15-4-10'},
    {name:'蘇我',north:35.5865928450244,west:140.121739741805,south:35.5032722205639,east:140.246732596225,note:'昭和53年二改・昭和54.11.30発行',list:'67-15-2-8'},
    {name:'厚木',north:35.5032454910799,west:139.246817156045,south:35.4199248202957,east:139.371809823818,note:'昭和51年二改・昭和53.2.28発行',list:'76-12-3-12'},
    {name:'座間',north:35.5032487938825,west:139.371806532529,south:35.4199281273838,east:139.496799226432,note:'昭和51年二改・昭和52.12.28発行',list:'76-12-1-11'},
    {name:'横浜西部',north:35.5032521076833,west:139.496795924209,south:35.4199314454322,east:139.621788644276,note:'昭和51年二改・昭和53.11.30発行',list:'76-8-3-14'},
    {name:'横浜東部',north:35.5032554324665,west:139.621785331136,south:35.4199347744249,east:139.78077,note:'昭和51年二改・昭和53.2.28発行',list:'76-8-1-9'},
    {name:'奈良輪',north:35.503262114917,west:139.871764190929,south:35.4199414651803,east:139.996756989696,note:'昭和53年改測・昭和55.1.30発行',list:'76-4-1-5'},
    {name:'姉崎',north:35.5032654725524,west:139.996753643896,south:35.4199448269111,east:140.121746468966,note:'昭和53年改測・昭和54.12.28発行',list:'67-16-3-5'},
    {name:'伊勢原',north:35.4199215241835,west:139.246820436385,south:35.3366008364576,east:139.37181310158,note:'昭和51年二改・昭和53.2.28発行',list:'76-12-4-14'},
    {name:'藤沢',north:35.4199248202957,west:139.371809823818,south:35.3366041368259,east:139.496802515082,note:'昭和51年二改・昭和52.10.30発行',list:'76-12-2-13'},
    {name:'戸塚',north:35.4199281273838,west:139.496799226432,south:35.3366074481321,east:139.6217919438,note:'昭和51年二改・昭和53.10.30発行',list:'76-8-4-14'},
    {name:'本牧',north:35.4199314454322,west:139.621788644276,south:35.3366107703605,east:139.746781387782,note:'昭和51年二改・昭和53.2.28発行',list:'76-8-2-11'},
    {name:'平塚',north:35.3365975470429,west:139.246823703242,south:35.2532768423511,east:139.371816365871,note:'昭和53年二改・昭和55.3.30発行',list:'77-9-3-10'},
    {name:'江の島',north:35.3366008364576,west:139.37181310158,south:35.2532801359923,east:139.496805790218,note:'昭和53年二改・昭和54.12.28発行',list:'77-9-1-11'},
    {name:'鎌倉',north:35.3366041368259,west:139.496802515082,south:35.2532834405491,east:139.621795229763,note:'昭和53年二改・昭和55.4.30発行',list:'77-5-3-11'},
    {name:'横須賀',north:35.3366074481321,west:139.6217919438,south:35.2532867560059,east:139.746784684559,note:'昭和53年二改・昭和55.5.30発行',list:'77-5-1-9'}
]});
dataset.age.push({
  folderName:'05', start:1983, end:1987, scale:'1/25000', mapList: [
    {name:'越生',north:36.003189078297,west:139.246797187739,south:35.9198685086489,east:139.371789871211,note:'昭和61年修正・昭和62.2.28発行',list:'76-9-3-7'},
    {name:'川越北部',north:36.0031924210896,west:139.371786497571,south:35.9198718559039,east:139.496779207541,note:'昭和61年修正・昭和62.7.30発行',list:'76-9-1-7'},
    {name:'上尾',north:36.0031957750136,west:139.496775822695,south:35.9198752142522,east:139.621768559198,note:'昭和59年修正・昭和61.1.30発行',list:'76-5-3-9'},
    {name:'岩槻',north:36.003199140053,west:139.62176516316,south:35.9198785836779,east:139.746757926232,note:'昭和59年修正・昭和6011.30発行',list:'76-5-1-8'},
    {name:'野田市',north:36.0032025161917,west:139.746754519019,south:35.9198819641648,east:139.871747308692,note:'昭和59年修正・昭和60.11.30発行',list:'76-1-3-7'},
    {name:'守谷',north:36.0032059034139,west:139.871743890321,south:35.919885355697,east:139.996736706631,note:'昭和59年修正・昭和61.2.28発行',list:'76-1-1-9'},
    {name:'藤代',north:36.0032093017033,west:139.996733277116,south:35.9198887582583,east:140.121726120097,note:'昭和60年修正・昭和61.4.30発行',list:'67-13-3-5'},
    {name:'牛久',north:36.0032127110437,west:140.121722679457,south:35.9198921718326,east:140.246715549142,note:'昭和60年修正・昭和61.6.30発行',list:'67-13-1-6'},
    {name:'飯能',north:35.9198651725031,west:139.246800550155,south:35.8365445860604,east:139.371793230981,note:'昭和61年修正・昭和62.10.30発行',list:'76-9-4-11'},
    {name:'川越南部',north:35.9198685086489,west:139.371789871211,south:35.8365479266391,east:139.496782578473,note:'昭和61年修正・昭和62.12.28発行',list:'76-9-2-11'},
    {name:'与野',north:35.9198718559039,west:139.496779207541,south:35.8365512782891,east:139.621771941275,note:'昭和59年修正・昭和61.12.28発行',list:'76-5-4-10'},
    {name:'浦和',north:35.9198752142522,west:139.621768559198,south:35.8365546409943,east:139.746761319438,note:'昭和59年修正・昭和61.1.30発行',list:'76-5-2-11'},
    {name:'越谷',north:35.9198785836779,west:139.746757926232,south:35.8365580147387,east:139.871750713011,note:'昭和59年修正・昭和60.12.28発行',list:'76-1-4-10'},
    {name:'流山',north:35.9198819641648,west:139.871747308692,south:35.8365613995063,east:139.996740122046,note:'昭和59年修正・昭和60.11.30発行',list:'76-1-2-11'},
    {name:'取手',north:35.919885355697,west:139.996736706631,south:35.836564795281,east:140.121729546593,note:'昭和60年修正・昭和61.5.30発行',list:'67-13-4-9'},
    {name:'龍ヶ崎',north:35.9198887582583,west:140.121726120097,south:35.8365682020467,east:140.246718986702,note:'昭和60年修正・昭和62.1.30発行',list:'67-13-2-9'},
    {name:'青梅',north:35.8365412565687,west:139.246803898748,south:35.7532206533069,east:139.371796576941,note:'昭和58年修正・昭和60.2.28発行',list:'76-10-3-13'},
    {name:'所沢',north:35.8365445860604,west:139.371793230981,south:35.753223987202,east:139.496785935548,note:'昭和58年修正・30955発行',list:'76-10-1-15'},
    {name:'志木',north:35.8365479266391,west:139.496782578473,south:35.7532273321462,east:139.62177530945,note:'昭和60年修正・昭和62.7.30発行',list:'76-6-3-13'},
    {name:'赤羽',north:35.8365512782891,west:139.621771941275,south:35.7532306881236,east:139.746764698695,note:'昭和60年修正・昭和62.4.30発行',list:'76-6-1-15'},
    {name:'草加',north:35.8365546409943,west:139.746761319438,south:35.753234055118,east:139.871754103336,note:'昭和60年修正・昭和62.2.28発行',list:'76-2-3-15'},
    {name:'松戸',north:35.8365580147387,west:139.871750713011,south:35.7532374331137,east:139.996743523422,note:'昭和60年修正・昭和62.8.30発行',list:'76-2-1-15'},
    {name:'白井',north:35.8365613995063,west:139.996740122046,south:35.7532408220944,east:140.121732959004,note:'昭和62年修正・昭和63.5.30発行',list:'67-14-3-10'},
    {name:'小林',north:35.836564795281,west:140.121729546593,south:35.7532442220441,east:140.246722410132,note:'昭和62年修正・昭和63.10.30発行',list:'67-14-1-10'},
    {name:'拝島',north:35.7532173304766,west:139.246807233577,south:35.6698967103709,east:139.371799909148,note:'昭和58年修正・昭和59.12.28発行',list:'76-10-4-15'},
    {name:'立川',north:35.7532206533069,west:139.371796576941,south:35.6699000375752,east:139.496789278825,note:'昭和58年修正・昭和60.2.28発行',list:'76-10-2-17'},
    {name:'吉祥寺',north:35.753223987202,west:139.496785935548,south:35.6699033758063,east:139.62177866378,note:'昭和59年修正・昭和61.1.30発行',list:'76-6-4-14'},
    {name:'東京西部',north:35.7532273321462,west:139.62177530945,south:35.6699067250485,east:139.746768064063,note:'昭和59年修正・昭和61.2.28発行',list:'76-6-2-12'},
    {name:'東京首部',north:35.7532306881236,west:139.746764698695,south:35.6699100852857,east:139.871757479726,note:'昭和59年修正・昭和61.3.30発行',list:'76-2-4-13'},
    {name:'船橋',north:35.753234055118,west:139.871754103336,south:35.669913456502,east:139.996746910817,note:'昭和60年修正・昭和62.4.30発行',list:'76-2-2-15B'},
    {name:'習志野',north:35.7532374331137,west:139.996743523422,south:35.6699168386813,east:140.121736357389,note:'昭和62年修正・昭和63.8.30発行',list:'67-14-4-14'},
    {name:'佐倉',north:35.7532408220944,west:140.121732959004,south:35.6699202318075,east:140.24672581949,note:'昭和62年修正・昭和63.11.30発行',list:'67-14-2-12'},
    {name:'八王子',north:35.6698933942092,west:139.246810554698,south:35.5865727572352,east:139.371803227658,note:'昭和58年修正・昭和60.2.28発行',list:'76-11-3-14'},
    {name:'武蔵府中',north:35.6698967103709,west:139.371799909148,south:35.5865760777413,east:139.496792608359,note:'昭和58年修正・昭和60.1.30発行',list:'76-11-1-14'},
    {name:'溝口',north:35.6699000375752,west:139.496789278825,south:35.5865794092522,east:139.621782004322,note:'昭和60年修正・昭和62.5.30発行',list:'76-7-3-15'},
    {name:'東京西南部',north:35.6699033758063,west:139.62177866378,south:35.5865827517518,east:139.746771415598,note:'昭和60年修正・昭和62.5.30発行',list:'76-7-1-13'},
    {name:'東京南部',north:35.6699067250485,west:139.746768064063,south:35.5865861052244,east:139.871760842237,note:'昭和60年修正・昭和62.4.30発行',list:'76-3-3-13B'},
    {name:'浦安',north:35.6699100852857,west:139.871757479726,south:35.5865894696539,east:139.996750284289,note:'昭和60年修正・昭和62.4.30発行',list:'76-3-1-12'},
    {name:'千葉西部',north:35.669913456502,west:139.996746910817,south:35.5865928450244,east:140.121739741805,note:'昭和62年修正・昭和63.9.30発行',list:'67-15-3-13'},
    {name:'千葉東部',north:35.6699168386813,west:140.121736357389,south:35.5865962313198,east:140.246729214835,note:'昭和62年修正・昭和63.9.30発行',list:'67-15-1-12'},
    {name:'上溝',north:35.5865694477494,west:139.246813862169,south:35.5032487938825,east:139.371806532529,note:'昭和58年修正・昭和59.10.30発行',list:'76-11-4-11'},
    {name:'原町田',north:35.5865727572352,west:139.371803227658,south:35.5032521076833,east:139.496795924209,note:'昭和58年修正・昭和60.2.28発行',list:'76-11-2-13'},
    {name:'荏田',north:35.5865760777413,west:139.496792608359,south:35.5032554324665,east:139.621785331136,note:'昭和60年修正・昭和62.5.30発行',list:'76-7-4-12'},
    {name:'川崎',north:35.5865794092522,west:139.621782004322,south:35.5032587682164,east:139.746774753359,note:'昭和60年修正・昭和62.7.30発行',list:'76-7-2-15'},
    {name:'東京国際空港',north:35.5865827517518,west:139.746771415598,south:35.503262114917,east:139.871764190929,note:'昭和60年修正・昭和62.1.30発行',list:'76-3-4-12'},
    {name:'五井',north:35.5865894696539,west:139.996750284289,south:35.5032688411067,east:140.121743112312,note:'昭和62年修正・昭和63.5.30発行',list:'67-15-4-12'},
    {name:'蘇我',north:35.5865928450244,west:140.121739741805,south:35.5032722205639,east:140.246732596225,note:'昭和62年修正・昭和63.5.30発行',list:'67-15-2-10'},
    {name:'厚木',north:35.5032454910799,west:139.246817156045,south:35.4199248202957,east:139.371809823818,note:'昭和59年修正・昭和61.5.30発行',list:'76-12-3-14'},
    {name:'座間',north:35.5032487938825,west:139.371806532529,south:35.4199281273838,east:139.496799226432,note:'昭和59年修正・昭和61.9.30発行',list:'76-12-1-13'},
    {name:'横浜西部',north:35.5032521076833,west:139.496795924209,south:35.4199314454322,east:139.621788644276,note:'昭和59年修正・昭和61.1.30発行',list:'76-8-3-16'},
    {name:'横浜東部',north:35.5032554324665,west:139.621785331136,south:35.4199347744249,east:139.746778077401,note:'昭和59年修正・昭和60.10.30発行',list:'76-8-1-11'},
    {name:'東扇島',north:35.5032587682164,west:139.746774753359,south:35.4199381143463,east:139.871767525858,note:'昭和62年修正・昭和63.6.30発行',list:'76-4-3-2B'},
    {name:'奈良輪',north:35.503262114917,west:139.871764190929,south:35.4199414651803,east:139.996756989696,note:'昭和62年修正・昭和63.6.30発行',list:'76-4-1-7'},
    {name:'姉崎',north:35.5032654725524,west:139.996753643896,south:35.4199448269111,east:140.121746468966,note:'昭和62年修正・32293発行',list:'67-16-3-7'},
    {name:'伊勢原',north:35.4199215241835,west:139.246820436385,south:35.3366008364576,east:139.37181310158,note:'昭和59年修正・昭和61.5.30発行',list:'76-12-4-16'},
    {name:'藤沢',north:35.4199248202957,west:139.371809823818,south:35.3366041368259,east:139.496802515082,note:'昭和59年修正・昭和61.11.30発行',list:'76-12-2-15'},
    {name:'戸塚',north:35.4199281273838,west:139.496799226432,south:35.3366074481321,east:139.6217919438,note:'昭和59年修正・昭和61.2.28発行',list:'76-8-4-16C'},
    {name:'本牧',north:35.4199314454322,west:139.621788644276,south:35.3366107703605,east:139.746781387782,note:'昭和59年修正・昭和61.4.30発行',list:'76-8-2-13'},
    {name:'平塚',north:35.3365975470429,west:139.246823703242,south:35.2532768423511,east:139.371816365871,note:'昭和58年修正・昭和59.10.30発行',list:'77-9-3-11'},
    {name:'江の島',north:35.3366008364576,west:139.37181310158,south:35.2532801359923,east:139.496805790218,note:'昭和58年修正・昭和60.2.28発行',list:'77-9-1-12'},
    {name:'鎌倉',north:35.3366041368259,west:139.496802515082,south:35.2532834405491,east:139.621795229763,note:'昭和58年修正・昭和60.1.30発行',list:'77-5-3-12'},
    {name:'横須賀',north:35.3366074481321,west:139.6217919438,south:35.2532867560059,east:139.746784684559,note:'昭和58年修正・昭和59.9.30発行',list:'77-5-1-10'}
]});
dataset.age.push({
  folderName:'06', start:1992, end:1995, scale:'1/25000', mapList: [
    {name:'越生',north:36.003189078297,west:139.246797187739,south:35.9198685086489,east:139.371789871211,note:'平成5年修正・平成6.6.1発行',list:'76-9-3-8'},
    {name:'川越北部',north:36.0031924210896,west:139.371786497571,south:35.9198718559039,east:139.496779207541,note:'平成5年修正・平成6.5.1発行',list:'76-9-1-9'},
    {name:'上尾',north:36.0031957750136,west:139.496775822695,south:35.9198752142522,east:139.621768559198,note:'平成6年修正・平成7.10.1発行',list:'76-5-3-11'},
    {name:'岩槻',north:36.003199140053,west:139.62176516316,south:35.9198785836779,east:139.746757926232,note:'平成6年修正・平成7.6.1発行',list:'76-5-1-10'},
    {name:'野田市',north:36.0032025161917,west:139.746754519019,south:35.9198819641648,east:139.871747308692,note:'平成6年修正・平成7.6.1発行',list:'76-1-3-9'},
    {name:'守谷',north:36.0032059034139,west:139.871743890321,south:35.919885355697,east:139.996736706631,note:'平成6年修正・平成7.6.1発行',list:'76-1-1-11'},
    {name:'藤代',north:36.0032093017033,west:139.996733277116,south:35.9198887582583,east:140.121726120097,note:'平成7年修正・平成8.4.1発行',list:'67-13-3-7'},
    {name:'牛久',north:36.0032127110437,west:140.121722679457,south:35.9198921718326,east:140.246715549142,note:'平成7年修正・平成8.4.1発行',list:'67-13-1-8'},
    {name:'飯能',north:35.9198651725031,west:139.246800550155,south:35.8365445860604,east:139.371793230981,note:'平成5年修正・平成6.5.1発行',list:'76-9-4-12'},
    {name:'川越南部',north:35.9198685086489,west:139.371789871211,south:35.8365479266391,east:139.496782578473,note:'平成5年修正・平成6.5.1発行',list:'76-9-2-12'},
    {name:'与野',north:35.9198718559039,west:139.496779207541,south:35.8365512782891,east:139.621771941275,note:'平成6年修正・平成7.5.1発行',list:'76-5-4-12'},
    {name:'浦和',north:35.9198752142522,west:139.621768559198,south:35.8365546409943,east:139.746761319438,note:'平成6年修正・平成7.6.1発行',list:'76-5-2-15'},
    {name:'越谷',north:35.9198785836779,west:139.746757926232,south:35.8365580147387,east:139.871750713011,note:'平成6年修正・平成7.6.1発行',list:'76-1-4-14'},
    {name:'流山',north:35.9198819641648,west:139.871747308692,south:35.8365613995063,east:139.996740122046,note:'平成6年修正・平成7.6.1発行',list:'76-1-2-13'},
    {name:'取手',north:35.919885355697,west:139.996736706631,south:35.836564795281,east:140.121729546593,note:'平成7年修正・平成8.4.1発行',list:'67-13-4-11'},
    {name:'龍ヶ崎',north:35.9198887582583,west:140.121726120097,south:35.8365682020467,east:140.246718986702,note:'平成7年修正・平成8.4.1発行',list:'67-13-2-11'},
    {name:'青梅',north:35.8365412565687,west:139.246803898748,south:35.7532206533069,east:139.371796576941,note:'平成5年修正・平成6.5.1発行',list:'76-10-3-15'},
    {name:'所沢',north:35.8365445860604,west:139.371793230981,south:35.753223987202,east:139.496785935548,note:'平成5年修正・平成6.11.1発行',list:'76-10-1-17'},
    {name:'志木',north:35.8365479266391,west:139.496782578473,south:35.7532273321462,east:139.62177530945,note:'平成5年修正・平成6.11.1発行',list:'76-6-3-15'},
    {name:'赤羽',north:35.8365512782891,west:139.621771941275,south:35.7532306881236,east:139.746764698695,note:'平成5年修正・平成6.9.1発行',list:'76-6-1-18'},
    {name:'草加',north:35.8365546409943,west:139.746761319438,south:35.753234055118,east:139.871754103336,note:'平成5年修正・平成6.12.1発行',list:'76-2-3-17'},
    {name:'松戸',north:35.8365580147387,west:139.871750713011,south:35.7532374331137,east:139.996743523422,note:'平成5年修正・平成6.12.1発行',list:'76-2-1-18'},
    {name:'白井',north:35.8365613995063,west:139.996740122046,south:35.7532408220944,east:140.121732959004,note:'平成4年修正・平成5.6.1発行',list:'67-14-3-12'},
    {name:'小林',north:35.836564795281,west:140.121729546593,south:35.7532442220441,east:140.246722410132,note:'平成4年修正・平成5.6.1発行',list:'67-14-1-11'},
    {name:'拝島',north:35.7532173304766,west:139.246807233577,south:35.6698967103709,east:139.371799909148,note:'平成5年修正・平成6.7.1発行',list:'76-10-4-18'},
    {name:'立川',north:35.7532206533069,west:139.371796576941,south:35.6699000375752,east:139.496789278825,note:'平成5年修正・平成6.12.1発行',list:'76-10-2-19'},
    {name:'吉祥寺',north:35.753223987202,west:139.496785935548,south:35.6699033758063,east:139.62177866378,note:'平成5年修正・平成6.8.1発行',list:'76-6-4-17'},
    {name:'東京西部',north:35.7532273321462,west:139.62177530945,south:35.6699067250485,east:139.746768064063,note:'平成5年修正・平成7.1.1発行',list:'76-6-2-16'},
    {name:'東京首部',north:35.7532306881236,west:139.746764698695,south:35.6699100852857,east:139.871757479726,note:'平成5年修正・平成6.12.1発行',list:'76-2-4-18'},
    {name:'船橋',north:35.753234055118,west:139.871754103336,south:35.669913456502,east:139.996746910817,note:'平成5年修正・平成6.10.1発行',list:'76-2-2-18'},
    {name:'習志野',north:35.7532374331137,west:139.996743523422,south:35.6699168386813,east:140.121736357389,note:'平成4年修正・平成5.6.1発行',list:'67-14-4-15'},
    {name:'佐倉',north:35.7532408220944,west:140.121732959004,south:35.6699202318075,east:140.24672581949,note:'平成4年修正・平成5.6.1発行',list:'67-14-2-13'},
    {name:'八王子',north:35.6698933942092,west:139.246810554698,south:35.5865727572352,east:139.371803227658,note:'平成5年修正・平成6.7.1発行',list:'76-11-3-17'},
    {name:'武蔵府中',north:35.6698967103709,west:139.371799909148,south:35.5865760777413,east:139.496792608359,note:'平成5年修正・平成6.9.1発行',list:'76-11-1-17'},
    {name:'溝口',north:35.6699000375752,west:139.496789278825,south:35.5865794092522,east:139.621782004322,note:'平成5年修正・平成6.8.1発行',list:'76-7-3-17'},
    {name:'東京西南部',north:35.6699033758063,west:139.62177866378,south:35.5865827517518,east:139.746771415598,note:'平成5年修正・平成6.9.1発行',list:'76-7-1-15'},
    {name:'東京南部',north:35.6699067250485,west:139.746768064063,south:35.5865861052244,east:139.871760842237,note:'平成5年修正・平成6.9.1発行',list:'76-3-3-15'},
    {name:'浦安',north:35.6699100852857,west:139.871757479726,south:35.5865894696539,east:139.996750284289,note:'平成5年修正・平成6.8.1発行',list:'76-3-1-14'},
    {name:'千葉西部',north:35.669913456502,west:139.996746910817,south:35.5865928450244,east:140.121739741805,note:'平成4年修正・平成5.6.1発行',list:'67-15-3-14'},
    {name:'千葉東部',north:35.6699168386813,west:140.121736357389,south:35.5865962313198,east:140.246729214835,note:'平成4年修正・平成5.6.1発行',list:'67-15-1-13'},
    {name:'上溝',north:35.5865694477494,west:139.246813862169,south:35.5032487938825,east:139.371806532529,note:'平成5年修正・平成6.7.1発行',list:'76-11-4-13'},
    {name:'原町田',north:35.5865727572352,west:139.371803227658,south:35.5032521076833,east:139.496795924209,note:'平成5年修正・平成6.12.1発行',list:'76-11-2-15'},
    {name:'荏田',north:35.5865760777413,west:139.496792608359,south:35.5032554324665,east:139.621785331136,note:'平成5年修正・平成6.6.1発行',list:'76-7-4-14'},
    {name:'川崎',north:35.5865794092522,west:139.621782004322,south:35.5032587682164,east:139.746774753359,note:'平成5年修正・平成6.6.1発行',list:'76-7-2-17'},
    {name:'東京国際空港',north:35.5865827517518,west:139.746771415598,south:35.503262114917,east:139.871764190929,note:'平成5年修正・平成6.5.1発行',list:'76-3-4-14'},
    {name:'五井',north:35.5865894696539,west:139.996750284289,south:35.5032688411067,east:140.121743112312,note:'平成4年修正・平成5.6.1発行',list:'67-15-4-13'},
    {name:'蘇我',north:35.5865928450244,west:140.121739741805,south:35.5032722205639,east:140.246732596225,note:'平成4年修正・平成5.6.1発行',list:'67-15-2-11'},
    {name:'厚木',north:35.5032454910799,west:139.246817156045,south:35.4199248202957,east:139.371809823818,note:'平成7年修正・平成8.9.1発行',list:'76-12-3-16'},
    {name:'座間',north:35.5032487938825,west:139.371806532529,south:35.4199281273838,east:139.496799226432,note:'平成7年修正・平成8.8.1発行',list:'76-12-1-16'},
    {name:'横浜西部',north:35.5032521076833,west:139.496795924209,south:35.4199314454322,east:139.621788644276,note:'平成5年修正・平成6.6.1発行',list:'76-8-3-19'},
    {name:'横浜東部',north:35.5032554324665,west:139.621785331136,south:35.4199347744249,east:139.746778077401,note:'平成5年修正・平成6.6.1発行',list:'76-8-1-16'},
    {name:'東扇島',north:35.5032587682164,west:139.746774753359,south:35.4199381143463,east:139.871767525858,note:'平成6年部修・平成9.12.18発行',list:'76-4-3-4'},
    {name:'奈良輪',north:35.503262114917,west:139.871764190929,south:35.4199414651803,east:139.996756989696,note:'平成4年修正・平成5.3.1発行',list:'76-4-1-8'},
    {name:'姉崎',north:35.5032654725524,west:139.996753643896,south:35.4199448269111,east:140.121746468966,note:'平成4年修正・平成5.3.1発行',list:'67-16-3-8'},
    {name:'伊勢原',north:35.4199215241835,west:139.246820436385,south:35.3366008364576,east:139.37181310158,note:'平成7年修正・平成8.6.1発行',list:'76-12-4-18'},
    {name:'藤沢',north:35.4199248202957,west:139.371809823818,south:35.3366041368259,east:139.496802515082,note:'平成7年修正・平成8.7.1発行',list:'76-12-2-17'},
    {name:'戸塚',north:35.4199281273838,west:139.496799226432,south:35.3366074481321,east:139.6217919438,note:'平成5年修正・平成6.6.1発行',list:'76-8-4-18'},
    {name:'本牧',north:35.4199314454322,west:139.621788644276,south:35.3366107703605,east:139.746781387782,note:'平成5年修正・平成6.6.1発行',list:'76-8-2-15'},
    {name:'平塚',north:35.3365975470429,west:139.246823703242,south:35.2532768423511,east:139.371816365871,note:'平成7年修正・平成8.7.1発行',list:'77-9-3-13'},
    {name:'江の島',north:35.3366008364576,west:139.37181310158,south:35.2532801359923,east:139.496805790218,note:'平成7年修正・平成8.7.1発行',list:''},
    {name:'鎌倉',north:35.3366041368259,west:139.496802515082,south:35.2532834405491,east:139.621795229763,note:'平成5年修正・平成6.9.1発行',list:'77-5-3-14'},
    {name:'横須賀',north:35.3366074481321,west:139.6217919438,south:35.2532867560059,east:139.746784684559,note:'平成5年修正・平成6.9.1発行',list:'77-5-1-12'}
]});
dataset.age.push({
  folderName:'07', start:1998, end:2005, scale:'1/25000', mapList: [
    {name:'越生',north:36.003189078297,west:139.246797187739,south:35.9198685086489,east:139.371789871211,note:'平成11年修正・平成12.8.1発行',list:''},
    {name:'川越北部',north:36.0031924210896,west:139.371786497571,south:35.9198718559039,east:139.496779207541,note:'平成11年修正・平成12.7.1発行',list:''},
    {name:'上尾',north:36.0031957750136,west:139.496775822695,south:35.9198752142522,east:139.621768559198,note:'平成15年更新・平成15.11.13発行',list:''},
    {name:'岩槻',north:36.003199140053,west:139.62176516316,south:35.9198785836779,east:139.746757926232,note:'平成15年更新・平成15.11.13発行',list:''},
    {name:'野田市',north:36.0032025161917,west:139.746754519019,south:35.9198819641648,east:139.871747308692,note:'平成11年修正・平成13.1.1発行',list:''},
    {name:'守谷',north:36.0032059034139,west:139.871743890321,south:35.919885355697,east:139.996736706631,note:'平成17年更新・平成17.8.24発行',list:''},
    {name:'藤代',north:36.0032093017033,west:139.996733277116,south:35.9198887582583,east:140.121726120097,note:'平成17年更新・平成17.8.24発行',list:''},
    {name:'牛久',north:36.0032127110437,west:140.121722679457,south:35.9198921718326,east:140.246715549142,note:'平成12年修正・平成13.5.1発行',list:''},
    {name:'飯能',north:35.9198651725031,west:139.246800550155,south:35.8365445860604,east:139.371793230981,note:'平成11年修正・平成12.8.1発行',list:''},
    {name:'川越南部',north:35.9198685086489,west:139.371789871211,south:35.8365479266391,east:139.496782578473,note:'平成11年修正・平成12.12.1発行',list:''},
    {name:'与野',north:35.9198718559039,west:139.496779207541,south:35.8365512782891,east:139.621771941275,note:'平成15年更新・平成15.11.13発行',list:''},
    {name:'浦和',north:35.9198752142522,west:139.621768559198,south:35.8365546409943,east:139.746761319438,note:'平成15年更新・平成15.11.13発行',list:''},
    {name:'越谷',north:35.9198785836779,west:139.746757926232,south:35.8365580147387,east:139.871750713011,note:'平成13年部修・平成13.6.1発行',list:''},
    {name:'流山',north:35.9198819641648,west:139.871747308692,south:35.8365613995063,east:139.996740122046,note:'平成11年修正・平成12.12.1発行',list:''},
    {name:'取手',north:35.919885355697,west:139.996736706631,south:35.836564795281,east:140.121729546593,note:'平成12年修正・平成13.9.1発行',list:''},
    {name:'龍ヶ崎',north:35.9198887582583,west:140.121726120097,south:35.8365682020467,east:140.246718986702,note:'平成12年修正・平成13.5.1発行',list:''},
    {name:'青梅',north:35.8365412565687,west:139.246803898748,south:35.7532206533069,east:139.371796576941,note:'平成13年修正・平成14.9.1発行',list:''},
    {name:'所沢',north:35.8365445860604,west:139.371793230981,south:35.753223987202,east:139.496785935548,note:'平成10年修正・平成11.6.1発行',list:''},
    {name:'志木',north:35.8365479266391,west:139.496782578473,south:35.7532273321462,east:139.62177530945,note:'平成13年修正・平成13.5.1発行',list:''},
    {name:'赤羽',north:35.8365512782891,west:139.621771941275,south:35.7532306881236,east:139.746764698695,note:'平成13年修正・平成13.5.1発行',list:''},
    {name:'草加',north:35.8365546409943,west:139.746761319438,south:35.753234055118,east:139.871754103336,note:'平成10年修正・平成11.10.1発行',list:''},
    {name:'松戸',north:35.8365580147387,west:139.871750713011,south:35.7532374331137,east:139.996743523422,note:'平成10年修正・平成11.9.1発行',list:''},
    {name:'白井',north:35.8365613995063,west:139.996740122046,south:35.7532408220944,east:140.121732959004,note:'平成9年修正・平成10.12.1発行',list:''},
    {name:'小林',north:35.836564795281,west:140.121729546593,south:35.7532442220441,east:140.246722410132,note:'平成12年部修・平成12.7.21発行',list:''},
    {name:'拝島',north:35.7532173304766,west:139.246807233577,south:35.6698967103709,east:139.371799909148,note:'平成13年修正・平成14.8.1発行',list:''},
    {name:'立川',north:35.7532206533069,west:139.371796576941,south:35.6699000375752,east:139.496789278825,note:'平成11年部修・平成12.7.1発行',list:''},
    {name:'吉祥寺',north:35.753223987202,west:139.496785935548,south:35.6699033758063,east:139.62177866378,note:'平成13年修正・平成14.9.1発行',list:''},
    {name:'東京西部',north:35.7532273321462,west:139.62177530945,south:35.6699067250485,east:139.746768064063,note:'平成13年修正・平成14.9.1発行',list:''},
    {name:'東京首部',north:35.7532306881236,west:139.746764698695,south:35.6699100852857,east:139.871757479726,note:'平成13年部修・平成14.3.1発行',list:''},
    {name:'船橋',north:35.753234055118,west:139.871754103336,south:35.669913456502,east:139.996746910817,note:'平成10年修正・平成11.6.1発行',list:''},
    {name:'習志野',north:35.7532374331137,west:139.996743523422,south:35.6699168386813,east:140.121736357389,note:'平成9年修正・平成10.8.1発行',list:''},
    {name:'佐倉',north:35.7532408220944,west:140.121732959004,south:35.6699202318075,east:140.24672581949,note:'平成16年更新・平成17.5.1発行',list:''},
    {name:'八王子',north:35.6698933942092,west:139.246810554698,south:35.5865727572352,east:139.371803227658,note:'平成10年修正・平成11.11.1発行',list:''},
    {name:'武蔵府中',north:35.6698967103709,west:139.371799909148,south:35.5865760777413,east:139.496792608359,note:'平成11年部修・平成12.6.1発行',list:''},
    {name:'溝口',north:35.6699000375752,west:139.496789278825,south:35.5865794092522,east:139.621782004322,note:'平成13年修正・平成14.7.1発行',list:''},
    {name:'東京西南部',north:35.6699033758063,west:139.62177866378,south:35.5865827517518,east:139.746771415598,note:'平成13年修正・平成15.1.1発行',list:''},
    {name:'東京南部',north:35.6699067250485,west:139.746768064063,south:35.5865861052244,east:139.871760842237,note:'平成13年部修・平成13.10.1発行',list:''},
    {name:'浦安',north:35.6699100852857,west:139.871757479726,south:35.5865894696539,east:139.996750284289,note:'平成10年修正・平成11.12.1発行',list:''},
    {name:'千葉西部',north:35.669913456502,west:139.996746910817,south:35.5865928450244,east:140.121739741805,note:'平成16年更新・平成17.2.1発行',list:''},
    {name:'千葉東部',north:35.6699168386813,west:140.121736357389,south:35.5865962313198,east:140.246729214835,note:'平成9年修正・平成10.4.1発行',list:''},
    {name:'上溝',north:35.5865694477494,west:139.246813862169,south:35.5032487938825,east:139.371806532529,note:'平成10年修正・平成12.1.1発行',list:''},
    {name:'原町田',north:35.5865727572352,west:139.371803227658,south:35.5032521076833,east:139.496795924209,note:'平成10年修正・平成11.10.1発行',list:''},
    {name:'荏田',north:35.5865760777413,west:139.496792608359,south:35.5032554324665,east:139.621785331136,note:'平成14年部修・平成14.6.1発行',list:''},
    {name:'川崎',north:35.5865794092522,west:139.621782004322,south:35.5032587682164,east:139.746774753359,note:'平成10年修正・平成11.6.1発行',list:''},
    {name:'東京国際空港',north:35.5865827517518,west:139.746771415598,south:35.503262114917,east:139.871764190929,note:'平成13年修正・平成15.10.1発行',list:''},
    {name:'五井',north:35.5865894696539,west:139.996750284289,south:35.5032688411067,east:140.121743112312,note:'平成16年更新・平成17.2.1発行',list:''},
    {name:'蘇我',north:35.5865928450244,west:140.121739741805,south:35.5032722205639,east:140.246732596225,note:'平成12年部修・平成12.9.1発行',list:''},
    {name:'厚木',north:35.5032454910799,west:139.246817156045,south:35.4199248202957,east:139.371809823818,note:'平成13年修正・平成14.10.1発行',list:''},
    {name:'座間',north:35.5032487938825,west:139.371806532529,south:35.4199281273838,east:139.496799226432,note:'平成13年修正・平成14.7.1発行',list:''},
    {name:'横浜西部',north:35.5032521076833,west:139.496795924209,south:35.4199314454322,east:139.621788644276,note:'平成10年修正・平成11.8.1発行',list:''},
    {name:'横浜東部',north:35.5032554324665,west:139.621785331136,south:35.4199347744249,east:139.746778077401,note:'平成10年修正・平成11.10.1発行',list:''},
    {name:'東扇島',north:35.5032587682164,west:139.746774753359,south:35.4199381143463,east:139.871767525858,note:'平成9年修正・平成9.12.18発行',list:''},
    {name:'奈良輪',north:35.503262114917,west:139.871764190929,south:35.4199414651803,east:139.996756989696,note:'平成16年更新・平成17.2.1発行',list:''},
    {name:'姉崎',north:35.5032654725524,west:139.996753643896,south:35.4199448269111,east:140.121746468966,note:'平成9年修正・平成10.11.1発行',list:''},
    {name:'伊勢原',north:35.4199215241835,west:139.246820436385,south:35.3366008364576,east:139.37181310158,note:'平成13年修正・平成14.10.1発行',list:''},
    {name:'藤沢',north:35.4199248202957,west:139.371809823818,south:35.3366041368259,east:139.496802515082,note:'平成13年修正・平成14.10.1発行',list:''},
    {name:'戸塚',north:35.4199281273838,west:139.496799226432,south:35.3366074481321,east:139.6217919438,note:'平成13年修正・平成14.10.1発行',list:''},
    {name:'本牧',north:35.4199314454322,west:139.621788644276,south:35.3366107703605,east:139.746781387782,note:'平成13年修正・平成15.6.1発行',list:''},
    {name:'平塚',north:35.3365975470429,west:139.246823703242,south:35.2532768423511,east:139.371816365871,note:'平成13年修正・平成14.10.1発行',list:''},
    {name:'江の島',north:35.3366008364576,west:139.37181310158,south:35.2532801359923,east:139.496805790218,note:'平成13年修正・平成14.10.1発行',list:''},
    {name:'鎌倉',north:35.3366041368259,west:139.496802515082,south:35.2532834405491,east:139.621795229763,note:'平成10年修正・平成11.10.1発行',list:''},
    {name:'横須賀',north:35.3366074481321,west:139.6217919438,south:35.2532867560059,east:139.746784684559,note:'平成10年修正・平成11.8.1発行',list:''}
]});
kjmapDataSet['chukyo'] = new Object();
dataset = kjmapDataSet['chukyo'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1888, end:1898, scale:'1/20000', mapList: [
    {name:'池野村',north:35.4698461880518,west:136.499944477614,south:35.4031895607851,east:136.599938157337,note:'明治24年測図・明治27.3.31発行',list:''},
    {name:'垂井',north:35.4031871218575,west:136.499946903303,south:35.3365304841631,east:136.599940582234,note:'明治24年測図・明治27.3.31発行',list:''},
    {name:'高田町',north:35.3365280492022,west:136.499949321013,south:35.2698714110667,east:136.599942999156,note:'明治24年測図・明治26.10.28発行',list:''},
    {name:'下池',north:35.2698689800759,west:136.49995173077,south:35.2032123214893,east:136.599945408128,note:'明治24年測図・明治26.10.28発行',list:''},
    {name:'阿下喜',north:35.2032098944719,west:136.499954132602,south:35.1365532254207,east:136.599947809177,note:'明治24年測図・明治26.11.29発行',list:''},
    {name:'大泉原村',north:35.1365508023802,west:136.499956526534,south:35.0698941328512,east:136.599950202328,note:'明治24年測図・明治26.12.28発行',list:''},
    {name:'菰野',north:35.0698917137909,west:136.499958912592,south:35.003235023774,east:136.599952587608,note:'明治24年測図・明治26.12.28発行',list:''},
    {name:'桜村',north:35.0032326086975,west:136.499961290801,south:34.9365759081793,east:136.599954965042,note:'明治23年測図・明治26.6.30発行',list:''},
    {name:'神戸町',north:34.9365734970898,west:136.499963661188,south:34.8699167960572,east:136.599957334655,note:'明治22年測図・明治26.3.31発行',list:''},
    {name:'白子町',north:34.8699143889581,west:136.499966023778,south:34.8032576674011,east:136.599959696474,note:'明治23年測図・明治26.3.31発行',list:''},
    {name:'北方町',north:35.4698486309427,west:136.599935724437,south:35.403192006949,east:136.699929420357,note:'明治24年測図・明治26.12.28発行',list:''},
    {name:'大垣',north:35.4031895607851,west:136.599938157337,south:35.3365329263486,east:136.699931852435,note:'明治24年測図・明治26.12.28発行',list:''},
    {name:'船着村',north:35.3365304841631,west:136.599940582234,south:35.2698738492703,east:136.699934276513,note:'明治24年測図・明治26.11.29発行',list:''},
    {name:'高須',north:35.2698714110667,west:136.599942999156,south:35.2032147557076,east:136.699936692618,note:'明治24年測図・明治26.11.29発行',list:''},
    {name:'太田村',north:35.2032123214893,west:136.599945408128,south:35.1365556556503,east:136.699939100776,note:'明治24年測図・明治26.12.28発行',list:''},
    {name:'深谷村',north:35.1365532254207,west:136.599947809177,south:35.0698965590887,east:136.699941501014,note:'明治24年測図・明治26.12.28発行',list:''},
    {name:'桑名',north:35.0698941328512,west:136.599950202328,south:35.003237446016,east:136.699943893356,note:'明治24年測図・明治26.12.28発行',list:''},
    {name:'四日市',north:35.003235023774,west:136.599952587608,south:34.9365783264225,east:136.69994627783,note:'明治31年測図・明治31.9.30発行',list:''},
    {name:'塩浜村',north:34.9365759081793,west:136.599954965042,south:34.8699192102981,east:136.69994865446,note:'明治23年測図・明治26.3.31発行',list:''},
    {name:'若松村',north:34.8699167960572,west:136.599957334655,south:34.8032600776363,east:136.699951023272,note:'明治23年測図・明治26.2.28発行',list:''},
    {name:'岐阜',north:35.4698510810816,west:136.699926980253,south:35.4031944603417,east:136.79992069239,note:'明治24年測図・明治26.11.29発行',list:''},
    {name:'笠松町',north:35.403192006949,west:136.699929420357,south:35.3365353757511,east:136.79992313164,note:'明治24年測図・明治27.3.28発行',list:''},
    {name:'竹鼻町',north:35.3365329263486,west:136.699931852435,south:35.2698762946792,east:136.799925562868,note:'明治24年測図・明治26.9.29発行',list:''},
    {name:'稲沢町',north:35.2698738492703,west:136.699934276513,south:35.2032171971194,east:136.799927986099,note:'明治24年測図・明治26.8.29発行',list:''},
    {name:'津島町',north:35.2032147557076,west:136.699936692618,south:35.1365580930617,east:136.799930401359,note:'明治31年修正・明治31.5.30発行',list:''},
    {name:'蟹江町',north:35.1365556556503,west:136.699939100776,south:35.0698989924961,east:136.799932808675,note:'明治31年修正・明治31.7.30発行',list:''},
    {name:'木曽河口',north:35.0698965590887,west:136.699941501014,south:35.0032398754162,east:136.799935208074,note:'明治24年測図・明治26.12.28発行',list:''},
    {name:'芥見村',north:35.469853538461,west:136.799918245089,south:35.4031969209557,east:136.899911973462,note:'明治24年測図・明治26.10.28発行',list:''},
    {name:'各務原',north:35.4031944603417,west:136.79992069239,south:35.3365378323632,east:136.899914419878,note:'明治24年測図・明治26.12.28発行',list:''},
    {name:'一宮町',north:35.3365353757511,west:136.79992313164,south:35.2698787472858,east:136.899916858247,note:'明治24年測図・明治26.10.28発行',list:''},
    {name:'清州',north:35.2698762946792,west:136.799925562868,south:35.2032196457172,east:136.899919288596,note:'明治24年測図・明治26.7.29発行',list:''},
    {name:'枇杷島',north:35.2032171971194,west:136.799927986099,south:35.1365605376473,east:136.899921710952,note:'明治31年修正・明治31.7.30発行',list:''},
    {name:'下之一色村',north:35.1365580930617,west:136.799930401359,south:35.0699014330661,east:136.89992412534,note:'明治24年測図・明治26.12.28発行',list:''},
    {name:'横須賀町',north:35.0698989924961,west:136.799932808675,south:35.0032423119671,east:136.899926531786,note:'明治24年測図・明治26.9.29発行',list:''},
    {name:'八幡村',north:35.0032398754162,west:136.799935208074,south:34.9365831843403,east:136.899928930317,note:'明治23年測図・明治26.6.30発行',list:''},
    {name:'常滑',north:34.9365807518119,west:136.79993759958,south:34.8699240601759,east:136.899931320958,note:'明治23年測図・明治26.3.31発行',list:''},
    {name:'上野間村',north:34.8699216316734,west:136.799939983219,south:34.8032649194674,east:136.899933703736,note:'明治23年測図・明治26.10.28発行',list:''},
    {name:'鵜沼',north:35.4698560030736,west:136.899909518973,south:35.4031993887836,east:136.9999032636,note:'明治24年測図・明治26.12.28発行',list:''},
    {name:'犬山',north:35.4031969209557,west:136.899911973462,south:35.3365402961773,east:136.999905717174,note:'明治24年測図・明治26.12.28発行',list:''},
    {name:'小牧',north:35.3365378323632,west:136.899914419878,south:35.2698812070829,east:136.999908162677,note:'明治24年測図・明治26.7.29発行',list:''},
    {name:'勝川村',north:35.2698787472858,west:136.899916858247,south:35.2032221014937,east:136.999910600138,note:'明治24年測図・明治26.7.29発行',list:''},
    {name:'名古屋',north:35.2032196457172,west:136.899919288596,south:35.1365629893998,east:136.999913029581,note:'明治24年測図・明治26.7.29発行',list:''},
    {name:'熱田',north:35.1365605376473,west:136.899921710952,south:35.0699038807911,east:136.999915451033,note:'明治24年測図・明治26.7.29発行',list:''},
    {name:'大高村',north:35.0699014330661,west:136.89992412534,south:35.0032447556612,east:136.99991786452,note:'明治24年測図・明治26.10.28発行',list:''},
    {name:'刈谷町',north:35.0032423119671,west:136.899926531786,south:34.9365856240002,east:136.999920270069,note:'明治23年測図・明治26.3.31発行',list:''},
    {name:'半田',north:34.9365831843403,west:136.899928930317,south:34.8699264957981,east:136.999922667705,note:'明治23年測図26・明治.12.28発行',list:''},
    {name:'武豊村',north:34.8699240601759,west:136.899931320958,south:34.8032673510484,east:136.999925057454,note:'明治23年測図・明治26.2.28発行',list:''},
    {name:'内津村',north:35.3365402961773,west:136.999905717174,south:35.2698836740629,east:137.099899476185,note:'明治24測図・明治26.7.29発行',list:''},
    {name:'水野村',north:35.2698812070829,west:136.999908162677,south:35.2032245644414,east:137.099901920749,note:'明治24測図・明治26.7.29発行',list:''},
    {name:'長湫村',north:35.2032221014937,west:136.999910600138,south:35.1365654483116,east:137.099904357272,note:'明治24測図・明治26.10.28発行',list:''},
    {name:'平針村',north:35.1365629893998,west:136.999913029581,south:35.0699063356638,east:137.099906785781,note:'明治24測図・明治26.6.30発行',list:''},
    {name:'知立',north:35.0699038807911,west:136.999915451033,south:35.0032472064913,east:137.099909206302,note:'明治24測図・明治26.6.30発行',list:''},
    {name:'箕輪村',north:35.0032447556612,west:136.99991786452,south:34.9365880707841,east:137.099911618861,note:'明治23測図・明治26.2.28発行',list:''},
    {name:'桜井村',north:34.9365856240002,west:136.999920270069,south:34.8699289385325,east:137.099914023485,note:'明治23測図・明治26.1.28発行',list:''},
    {name:'西尾',north:34.8699264957981,west:136.999922667705,south:34.80326978973,east:137.099916420198,note:'明治23測図・明治26.2.28発行',list:''},
    {name:'多治見',north:35.3365427671861,west:137.099897023555,south:35.2698861482182,east:137.199890798797,note:'明治24測図・明治26.5.29発行',list:''},
    {name:'瀬戸',north:35.2698836740629,west:137.099899476185,south:35.2032270345526,east:137.199893250457,note:'明治24測図・明治26.6.30発行',list:''},
    {name:'広沢村',north:35.2032245644414,west:137.099901920749,south:35.1365679143754,east:137.199895694053,note:'明治24測図・明治26.9.29発行',list:''},
    {name:'挙母',north:35.1365654483116,west:137.099904357272,south:35.0699087976766,east:137.199898129611,note:'明治24測図・明治26.6.30発行',list:''},
    {name:'上野村',north:35.0699063356638,west:137.099906785781,south:35.0032496644497,east:137.199900557158,note:'明治24測図・明治26.5.29発行',list:''},
    {name:'岡崎',north:35.0032472064913,west:137.099909206302,south:34.9365905246847,east:137.199902976721,note:'明治23測図・明治26.10.28発行',list:''},
    {name:'福岡村',north:34.9365880707841,west:137.099911618861,south:34.8699313883719,east:137.199905388324,note:'明治23測図・明治26.2.28発行',list:''},
    {name:'深溝村',north:34.8699289385325,west:137.099914023485,south:34.8032722355046,east:137.199907791995,note:'明治23測図・明治26.2.28発行',list:''}
]});
dataset.age.push({
  folderName:'00', start:1920, end:1920, scale:'1/25000', mapList: [
    {name:'池野',north:35.5031757137291,west:136.499943250659,south:35.4198549392078,east:136.624935353214,note:'大正9年測図・大正12.4.30発行',list:'95-8-3-1'},
    {name:'北方',north:35.5031787709519,west:136.624932306074,south:35.419858001546,east:136.749924433964,note:'大正9年測図・大正12.5.30発行',list:'95-8-1-1'},
    {name:'岐阜',north:35.5031818395059,west:136.749921375558,south:35.419861075178,east:136.874913528819,note:'大正9年測図・大正12.4.30発行',list:'95-4-3-1'},
    {name:'美濃関',north:35.5031849193767,west:136.874910459162,south:35.4198641600891,east:136.999902637832,note:'大正9年測図・大正11.12.28発行',list:'95-4-1-1'},
    {name:'大垣',north:35.4198518881779,west:136.499946286519,south:35.3365310973652,east:136.624938387831,note:'大正9年測図・大正13.5.30発行',list:'95-8-4-1'},
    {name:'墨俣',north:35.4198549392078,west:136.624935353214,south:35.3365341534808,east:136.7499274798,note:'大正9年測図・大正13.8.30発行',list:'95-8-2-1'},
    {name:'各務ヶ原',north:35.419858001546,west:136.749924433964,south:35.3365372208673,east:136.87491658586,note:'大正9年測図・大正12.5.30発行',list:'95-4-4-1'},
    {name:'犬山',north:35.419861075178,west:136.874913528819,south:35.33654029951,east:136.999905706064,note:'大正9年測図・大正12.5.30発行',list:'95-4-2-1'},
    {name:'養老',north:35.3365280525349,west:136.499949309902,south:35.2532072454067,east:136.624941409977,note:'大正9年測図・大正13.11.30発行',list:'96-5-3-1'},
    {name:'竹鼻',north:35.3365310973652,west:136.624938387831,south:35.2532102952931,east:136.749930513119,note:'大正9年測図・大正13.7.30発行',list:'96-5-1-1'},
    {name:'一宮',north:35.3365341534808,west:136.7499274798,south:35.2532133564274,east:136.874919630337,note:'大正9年測図・大正13.3.30発行',list:'96-1-3-1'},
    {name:'小牧',north:35.3365372208673,west:136.87491658586,south:35.253216428795,east:136.999908761685,note:'大正9年測図・大正13.3.30発行',list:'96-1-1-1'},
    {name:'豊岡',north:35.33654029951,west:136.999905706064,south:35.2532195123812,east:137.124897907214,note:'大正9年測図・大正12.5.30発行',list:'91-13-3-1'},
    {name:'駒野',north:35.2532042067826,west:136.49995232086,south:35.169883383315,east:136.624944419702,note:'大正9年測図・大正13.9.30発行',list:'96-5-4-1'},
    {name:'津島',north:35.2532072454067,west:136.624941409977,south:35.1698864269655,east:136.749933533971,note:'大正9年測図・大正13.10.30発行',list:'96-5-2-1'},
    {name:'清洲',north:35.2532102952931,west:136.749930513119,south:35.1698894818409,east:136.874922662303,note:'大正9年測図・大正12.11.30発行',list:'96-1-4-1'},
    {name:'名古屋北部',north:35.2532133564274,west:136.874919630337,south:35.1698925479266,east:136.999911804749,note:'大正9年測図・大正12.11.30発行',list:'96-1-2-1'},
    {name:'瀬戸',north:35.253216428795,west:136.999908761685,south:35.169895625208,east:137.124900961362,note:'大正9年測図・大正12.12.28発行',list:'91-13-4-1'},
    {name:'阿下喜',north:35.1698803509038,west:136.499955319444,south:35.0865595110728,east:136.624947417058,note:'大正9年測図・大正13.12.28発行',list:'96-6-3-1'},
    {name:'弥富',north:35.169883383315,west:136.624944419702,south:35.0865625484807,east:136.749936542409,note:'大正9年測図・大正13.10.30発行',list:'96-6-1-1'},
    {name:'蟹江',north:35.1698864269655,west:136.749933533971,south:35.0865655970905,east:136.874925681808,note:'大正9年測図・大正13.7.30発行',list:'96-2-3-1'},
    {name:'名古屋南部',north:35.1698894818409,west:136.874922662303,south:35.0865686568877,east:136.999914835307,note:'大正9年測図・大正12.12.28発行',list:'96-2-1-1'},
    {name:'平針',north:35.1698925479266,west:136.999911804749,south:35.0865717278576,east:137.124904002958,note:'大正9年測図・大正13.1.30発行',list:'91-14-3-1'},
    {name:'越戸',north:35.169895625208,west:137.124900961362,south:35.0865748099856,east:137.249893184813,note:'大正9年測図・大正12.11.30発行',list:'91-14-1-1'},
    {name:'菰野',north:35.0865564848811,west:136.499958305704,south:35.0032356286628,east:136.624950402095,note:'大正9年測図・大正13.12.28発行',list:'96-6-4-1'},
    {name:'桑名',north:35.0865595110728,west:136.624947417058,south:35.0032386598215,east:136.749939538482,note:'大正9年測図・大正13.12.28発行',list:'96-6-2-1'},
    {name:'飛島',north:35.0865625484807,west:136.749936542409,south:35.0032417021591,east:136.874928688903,note:'大正9年測図・大正11.3.30発行',list:'96-2-4-1'},
    {name:'鳴海',north:35.0865655970905,west:136.874925681808,south:35.0032447556609,east:136.99991785341,note:'大正9年測図・大正13.11.30発行',list:'96-2-2-1'},
    {name:'知立',north:35.0865686568877,west:136.999914835307,south:35.0032478203126,east:137.124907032054,note:'大正9年測図・大正13.3.30発行',list:'91-14-4-1'},
    {name:'挙母',north:35.0865717278576,west:137.124904002958,south:35.0032508960994,east:137.249896224887,note:'大正9年測図・大正12.6.30発行',list:'91-14-2-1'},
    {name:'日永',north:35.0032326086972,west:136.499961279691,south:34.9199117360678,east:136.624953374865,note:'大正9年測図・大正13.8.30発行',list:'96-7-3-1'},
    {name:'四日市',north:35.0032356286628,west:136.624950402095,south:34.9199147609707,east:136.749942522242,note:'大正9年測図・大正11.5.30発行',list:'96-7-1-1'},
    {name:'大野',north:35.0032386598215,west:136.749939538482,south:34.9199177970294,east:136.874931683639,note:'大正9年測図・大正11.5.30発行',list:'96-3-3-1'},
    {name:'刈谷',north:35.0032417021591,west:136.874928688903,south:34.9199208442293,east:136.999920859109,note:'大正9年測図・大正12.5.30発行',list:'96-3-1-1'},
    {name:'安城',north:35.0032447556609,west:136.99991785341,south:34.919923902556,east:137.124910048701,note:'大正9年測図・大正12.4.30発行',list:'91-15-3-1'},
    {name:'岡崎',north:35.0032478203126,west:137.124907032054,south:34.9199269719949,east:137.249899252467,note:'大正9年測図・大正12.11.30発行',list:'91-15-1-1'},
    {name:'神戸',north:34.919908722335,west:136.499964241455,south:34.8365878332707,east:136.624956335416,note:'大正9年測図・大正13.5.30発行',list:'96-7-4-1'},
    {name:'南五味塚',north:34.9199117360678,west:136.624953374865,south:34.8365908519112,east:136.749945493739,note:'大正9年測図・大正11.8.30発行',list:'96-7-2-1'},
    {name:'常滑',north:34.9199147609707,west:136.749942522242,south:34.8365938816843,east:136.874934666067,note:'大正9年測図・大正11.5.30発行',list:'96-3-4-1'},
    {name:'半田',north:34.9199177970294,west:136.874931683639,south:34.8365969225757,east:136.999923852454,note:'大正9年測図・大正12.4.30発行',list:'96-3-2-1'},
    {name:'西尾',north:34.9199208442293,west:136.999920859109,south:34.8365999745707,east:137.124913052949,note:'大正9年測図・大正12.5.30発行',list:'91-15-4-1'},
    {name:'幸田',north:34.919923902556,west:137.124910048701,south:34.836603037655,east:137.249902267604,note:'大正9年測図・大正12.11.30発行',list:'91-15-2-1'}
]});
dataset.age.push({
  folderName:'01', start:1932, end:1932, scale:'1/25000', mapList: [
    {name:'池野',north:35.5031757137291,west:136.499943250659,south:35.4198549392078,east:136.624935353214,note:'昭和7年修正・昭和10.7.30発行',list:'95-8-3-3'},
    {name:'北方',north:35.5031787709519,west:136.624932306074,south:35.419858001546,east:136.749924433964,note:'昭和7年修正・昭和22.9.30発行',list:'95-8-1-4'},
    {name:'岐阜',north:35.5031818395059,west:136.749921375558,south:35.419861075178,east:136.874913528819,note:'昭和7年修正・昭和10.9.30発行',list:'95-4-3-3'},
    {name:'美濃関',north:35.5031849193767,west:136.874910459162,south:35.4198641600891,east:136.999902637832,note:'昭和7年修正・昭和10.7.30発行',list:'95-4-1-3'},
    {name:'大垣',north:35.4198518881779,west:136.499946286519,south:35.3365310973652,east:136.624938387831,note:'昭和7年修正・昭和10.9.30発行',list:'95-8-4-3'},
    {name:'墨俣',north:35.4198549392078,west:136.624935353214,south:35.3365341534808,east:136.7499274798,note:'昭和7年修正・昭和22.9.30発行',list:'95-8-2-3'},
    {name:'各務ヶ原',north:35.419858001546,west:136.749924433964,south:35.3365372208673,east:136.87491658586,note:'昭和7年修正・昭和10.7.30発行',list:'95-4-4-3'},
    {name:'犬山',north:35.419861075178,west:136.874913528819,south:35.33654029951,east:136.999905706064,note:'昭和7年修正・昭和10.8.30発行',list:'95-4-2-3'},
    {name:'養老',north:35.3365280525349,west:136.499949309902,south:35.2532072454067,east:136.624941409977,note:'昭和7年修正・昭和10.8.30発行',list:'96-5-3-2'},
    {name:'竹鼻',north:35.3365310973652,west:136.624938387831,south:35.2532102952931,east:136.749930513119,note:'昭和7年修正・昭和10.9.30発行',list:'96-5-1-4'},
    {name:'一宮',north:35.3365341534808,west:136.7499274798,south:35.2532133564274,east:136.874919630337,note:'昭和7年修正・昭和10.8.30発行',list:'96-1-3-3'},
    {name:'小牧',north:35.3365372208673,west:136.87491658586,south:35.253216428795,east:136.999908761685,note:'昭和7年修正・昭和10.10.30発行',list:'96-1-1-2'},
    {name:'駒野',north:35.2532042067826,west:136.49995232086,south:35.169883383315,east:136.624944419702,note:'昭和7年修正・昭和10.7.30発行',list:'96-5-4-2'},
    {name:'津島',north:35.2532072454067,west:136.624941409977,south:35.1698864269655,east:136.749933533971,note:'昭和7年修正・昭和10.6.30発行',list:'96-5-2-2'},
    {name:'清洲',north:35.2532102952931,west:136.749930513119,south:35.1698894818409,east:136.874922662303,note:'昭和7年修正・昭和8.6.30発行',list:''},
    {name:'名古屋北部',north:35.2532133564274,west:136.874919630337,south:35.1698925479266,east:136.999911804749,note:'昭和7年修正・昭和8.5.30発行',list:'96-1-2-3'},
    {name:'阿下喜',north:35.1698803509038,west:136.499955319444,south:35.0865595110728,east:136.624947417058,note:'昭和7年修正・昭和10.8.30発行',list:'96-6-3-2'},
    {name:'弥富',north:35.169883383315,west:136.624944419702,south:35.0865625484807,east:136.749936542409,note:'昭和7年修正・昭和10.6.30発行',list:'96-6-1-3'},
    {name:'蟹江',north:35.1698864269655,west:136.749933533971,south:35.0865655970905,east:136.874925681808,note:'昭和7年修正・昭和8.5.30発行',list:'96-2-3-3'},
    {name:'名古屋南部',north:35.1698894818409,west:136.874922662303,south:35.0865686568877,east:136.999914835307,note:'昭和7年修正・昭和8.5.30発行',list:'96-2-1-3'},
    {name:'菰野',north:35.0865564848811,west:136.499958305704,south:35.0032356286628,east:136.624950402095,note:'昭和7年修正・昭和10.7.30発行',list:'96-6-4-2'},
    {name:'桑名',north:35.0865595110728,west:136.624947417058,south:35.0032386598215,east:136.749939538482,note:'昭和7年修正・昭和10.6.30発行',list:'96-6-2-3'},
    {name:'飛島',north:35.0865625484807,west:136.749936542409,south:35.0032417021591,east:136.874928688903,note:'昭和7年修正・昭和9.12.28発行',list:'96-2-4-2'},
    {name:'鳴海',north:35.0865655970905,west:136.874925681808,south:35.0032447556609,east:136.99991785341,note:'昭和7年修正・昭和10.10.30発行',list:'96-2-2-3'}
]});
dataset.age.push({
  folderName:'02', start:1937, end:1938, scale:'1/25000', mapList: [
    {name:'一宮',north:35.3365341534808,west:136.7499274798,south:35.2532133564274,east:136.874919630337,note:'昭和13年三修・昭和15.11.30発行',list:'96-1-3-4',war:true},
    {name:'小牧',north:35.3365372208673,west:136.87491658586,south:35.253216428795,east:136.999908761685,note:'昭和13年二修・昭和16.2.28発行',list:'96-1-1-3'},
    {name:'清洲',north:35.2532102952931,west:136.749930513119,south:35.1698894818409,east:136.874922662303,note:'昭和13年三修・昭和22.9.30発行',list:'96-1-4-4'},
    {name:'名古屋北部',north:35.2532133564274,west:136.874919630337,south:35.1698925479266,east:136.999911804749,note:'昭和13年三修・昭和22.9.30発行',list:'96-1-2-4'},
    {name:'蟹江',north:35.1698864269655,west:136.749933533971,south:35.0865655970905,east:136.874925681808,note:'昭和13年三修・昭和22.9.30発行',list:'96-2-3-4'},
    {name:'名古屋南部',north:35.1698894818409,west:136.874922662303,south:35.0865686568877,east:136.999914835307,note:'昭和13年三修・昭和22.9.30発行',list:'96-2-1-4'},
    {name:'菰野',north:35.0865564848811,west:136.499958305704,south:35.0032356286628,east:136.624950402095,note:'昭和12年三修・昭和13.2.28発行',list:'96-6-4-3'},
    {name:'桑名',north:35.0865595110728,west:136.624947417058,south:35.0032386598215,east:136.749939538482,note:'昭和12年三修・昭和15.6.30発行',list:'96-6-2-4',war:true},
    {name:'鳴海',north:35.0865655970905,west:136.874925681808,south:35.0032447556609,east:136.99991785341,note:'昭和13年三修・昭和22.9.30発行',list:'96-2-2-4'},
    {name:'四日市西部',north:35.0032326086972,west:136.499961279691,south:34.9199117360678,east:136.624953374865,note:'昭和12年二修・昭和15.3.30発行',list:'96-7-3-4',war:true},
    {name:'四日市東部',north:35.0032356286628,west:136.624950402095,south:34.9199147609707,east:136.749942522242,note:'昭和12年二修・昭和14.2.28発行',list:'96-7-1-4'},
    {name:'神戸',north:34.919908722335,west:136.499964241455,south:34.8365878332707,east:136.624956335416,note:'昭和12年二修・昭和22.9.30発行',list:'96-7-4-3'},
    {name:'南五味塚',north:34.9199117360678,west:136.624953374865,south:34.8365908519112,east:136.749945493739,note:'昭和12年二修・昭和22.9.30発行',list:'96-7-2-3'}
]});
dataset.age.push({
  folderName:'03', start:1947, end:1947, scale:'1/25000', mapList: [
    {name:'池野',north:35.5031757137291,west:136.499943250659,south:35.4198549392078,east:136.624935353214,note:'昭和22年二修・昭和23.11.30発行',list:'95-8-3-5'},
    {name:'北方',north:35.5031787709519,west:136.624932306074,south:35.419858001546,east:136.749924433964,note:'昭和22年二修・昭和24.2.28発行',list:'95-8-1-6'},
    {name:'岐阜北部',north:35.5031818395059,west:136.749921375558,south:35.419861075178,east:136.874913528819,note:'昭和22年二修・昭和23.11.30発行',list:'95-4-3-5'},
    {name:'美濃関',north:35.5031849193767,west:136.874910459162,south:35.4198641600891,east:136.999902637832,note:'昭和22年二修・昭和22.9.30発行',list:'95-4-1-4'},
    {name:'大垣',north:35.4198518881779,west:136.499946286519,south:35.3365310973652,east:136.624938387831,note:'昭和22年修正・昭和24.1.30発行',list:'95-8-4-5'},
    {name:'墨俣',north:35.4198549392078,west:136.624935353214,south:35.3365341534808,east:136.7499274798,note:'昭和22年二修・昭和24.2.28発行',list:'95-8-2-5'},
    {name:'岐阜南部',north:35.419858001546,west:136.749924433964,south:35.3365372208673,east:136.87491658586,note:'昭和22年二修・昭和24.6.30発行',list:'95-4-4-5'},
    {name:'犬山',north:35.419861075178,west:136.874913528819,south:35.33654029951,east:136.999905706064,note:'昭和22年二修・昭和23.11.30発行',list:'95-4-2-5'},
    {name:'一宮',north:35.3365341534808,west:136.7499274798,south:35.2532133564274,east:136.874919630337,note:'昭和22年四修・昭和25.3.30発行',list:'96-1-3-6'},
    {name:'清洲',north:35.2532102952931,west:136.749930513119,south:35.1698894818409,east:136.874922662303,note:'昭和22年四修・昭和23.12.28発行',list:'96-1-4-5'},
    {name:'名古屋北部',north:35.2532133564274,west:136.874919630337,south:35.1698925479266,east:136.999911804749,note:'昭和22年四修・昭和24.4.30発行',list:'96-1-2-5'},
    {name:'弥富',north:35.169883383315,west:136.624944419702,south:35.0865625484807,east:136.749936542409,note:'昭和22年要修・昭和22.9.30発行',list:'96-6-1-4'},
    {name:'蟹江',north:35.1698864269655,west:136.749933533971,south:35.0865655970905,east:136.874925681808,note:'昭和22年四修・昭和30.5.30発行',list:'96-2-3-5'},
    {name:'名古屋南部',north:35.1698894818409,west:136.874922662303,south:35.0865686568877,east:136.999914835307,note:'昭和22年四修・昭和25.4.30発行',list:'96-2-1-5'},
    {name:'桑名',north:35.0865595110728,west:136.624947417058,south:35.0032386598215,east:136.749939538482,note:'昭和22年要修・昭和22.9.30発行',list:'96-6-2-5'},
    {name:'飛島',north:35.0865625484807,west:136.749936542409,south:35.0032417021591,east:136.874928688903,note:'昭和22年二修・昭和23.11.30発行',list:'96-2-4-4'}
]});
dataset.age.push({
  folderName:'04', start:1959, end:1960, scale:'1/25000', mapList: [
    {name:'養老',north:35.336527982299,west:136.4970606736,south:35.2532071750535,east:136.622052773092,note:'昭和34年三修・昭和39.4.30発行',list:'96-5-3-5'},
    {name:'竹鼻',north:35.3365310268683,west:136.622049751205,south:35.2532102246798,east:136.747041875909,note:'昭和34年三修・昭和40.5.30発行',list:'96-5-1-7'},
    {name:'駒野',north:35.2532041366899,west:136.497063684299,south:35.1698833131057,east:136.62205578256,note:'昭和34年三修・昭和40.5.30発行',list:'96-5-4-4'},
    {name:'津島',north:35.2532071750535,west:136.622052773092,south:35.1698863564966,east:136.747044896505,note:'昭和34年三修・昭和40.3.30発行',list:'96-5-2-5'},
    {name:'阿下喜',north:35.1698802809544,west:136.497066682625,south:35.0865594410074,east:136.62205877966,note:'昭和34年三修・昭和39.11.30発行',list:'96-6-3-5'},
    {name:'弥富',north:35.1698833131057,west:136.62205578256,south:35.0865624781564,east:136.747047904687,note:'昭和34年三修・昭和39.4.30発行',list:'96-6-1-7'},
    {name:'豊田北部',north:35.1698955539623,west:137.122012322916,south:35.0865747386284,east:137.247004545782,note:'昭和34年二修・昭和36.11.30発行',list:'91-14-1-5'},
    {name:'菰野',north:35.0865564150751,west:136.497069668629,south:35.0032355587416,east:136.622061764442,note:'昭和34年四修・昭和40.3.30発行',list:'96-6-4-6'},
    {name:'桑名',north:35.0865594410074,west:136.62205877966,south:35.0032385896418,east:136.747050900505,note:'昭和34年四修・昭和40.5.30発行',list:'96-6-2-9'},
    {name:'飛島',north:35.0865624781564,west:136.747047904687,south:35.0032416317212,east:136.872040050601,note:'昭和34年五修・昭和36.7.30発行',list:'96-2-4-6'},
    {name:'鳴海',north:35.0865655265074,west:136.872037043761,south:35.0032446849652,east:136.997029214782,note:'昭和34年五修・昭和36.6.30発行',list:'96-2-2-6'},
    {name:'知立',north:35.0865685860462,west:136.997026196933,south:35.0032477493593,east:137.122018393099,note:'昭和34年二修・昭和36.7.30発行',list:'91-14-4-6'},
    {name:'豊田南部',north:35.086571656758,west:137.122015364257,south:35.003250824889,east:137.247007585603,note:'昭和34年二修・昭和37.3.30発行',list:'91-14-2-6'},
    {name:'四日市西部',north:35.0032325390349,west:136.49707264236,south:34.9199116662909,east:136.622064736957,note:'昭和34年三修・昭和40.5.30発行',list:'96-7-3-7'},
    {name:'四日市東部',north:35.0032355587416,west:136.622061764442,south:34.9199146909359,east:136.747053884011,note:'昭和34年三修・昭和38.10.30発行',list:'96-7-1-6'},
    {name:'大野',north:35.0032385896418,west:136.747050900505,south:34.9199177267369,east:136.872043045084,note:'昭和34年二修・昭和37.6.30発行',list:'96-3-3-3'},
    {name:'刈谷',north:35.0032416317212,west:136.872040050601,south:34.9199207736795,east:136.997032220227,note:'昭和34年修正・昭和36.10.30発行',list:'96-3-1-4'},
    {name:'安城',north:35.0032446849652,west:136.997029214782,south:34.9199238317492,east:137.122021409493,note:'昭和34年二修35年資修・昭和36.7.30発行',list:''},
    {name:'岡崎',north:35.0032477493593,west:137.122018393099,south:34.9199269009314,east:137.247010612931,note:'昭和34年二修・昭和36.7.30発行',list:'91-15-1-6'},
    {name:'神戸',north:34.9199086528164,west:136.49707560387,south:34.8365877636383,east:136.622067697255,note:'昭和34年三修・昭和40.5.30発行',list:'96-7-4-5'},
    {name:'南五味塚',north:34.9199116662909,west:136.622064736957,south:34.8365907820214,east:136.747056855255,note:'昭和34年三修・昭和40.5.30発行',list:'96-7-2-4'},
    {name:'常滑',north:34.9199146909359,west:136.747053884011,south:34.8365938115374,east:136.87204602726,note:'昭和34年二修・昭和36.11.30発行',list:'96-3-4-3'},
    {name:'半田',north:34.9199177267369,west:136.872043045084,south:34.8365968521719,east:136.99703521332,note:'昭和34年二修・昭和36.10.30発行',list:'96-3-2-7'},
    {name:'西尾',north:34.9199207736795,west:136.997032220227,south:34.8365999039105,east:137.122024413489,note:'昭和34年二修・昭和36.7.30発行',list:'91-15-4-5'},
    {name:'幸田',north:34.9199238317492,west:137.122021409493,south:34.8366029667386,east:137.247013627816,note:'昭和34年二修・昭和36.6.30発行',list:'91-15-2-5'}
]});
dataset.age.push({
  folderName:'05', start:1968, end:1973, scale:'1/25000', mapList: [
    {name:'池野',north:35.5031756432074,west:136.497054614878,south:35.4198548685674,east:136.622046716848,note:'昭和45年改測・昭和47.9.30発行',list:'95-8-3-6'},
    {name:'北方',north:35.5031787001681,west:136.622043669968,south:35.4198579306444,east:136.747035797272,note:'昭和45年改測・昭和47.6.30発行',list:'95-8-1-7'},
    {name:'岐阜北部',north:35.5031817684604,west:136.747032739126,south:35.4198610040155,east:136.8720248918,note:'昭和45年改測・昭和47.1.30発行',list:'95-4-3-7'},
    {name:'美濃関',north:35.5031848480698,west:136.872021822404,south:35.4198640886661,east:136.997014000486,note:'昭和45年改測・昭和48.2.28発行',list:'95-4-1-5'},
    {name:'美濃加茂',north:35.5031879389816,west:136.997010919852,south:35.4198671845816,east:137.12200312338,note:'昭和48年測量・昭和50.2.28発行',list:'90-16-3-1'},
    {name:'御嵩',north:35.503191041181,west:137.122000031524,south:35.4198702917471,east:137.246992260534,note:'昭和48年測量・昭和50.2.28発行',list:'90-16-1-1'},
    {name:'大垣',north:35.419851817799,west:136.497057650477,south:35.3365310268683,east:136.622049751205,note:'昭和45年改測・昭和47.6.30発行',list:'95-8-4-6'},
    {name:'岐阜西部',north:35.4198548685674,west:136.622046716848,south:35.3365340827233,east:136.747038842849,note:'昭和45年改測・昭和47.4.30発行',list:'95-8-2-7'},
    {name:'岐阜',north:35.4198579306444,west:136.747035797272,south:35.3365371498495,east:136.872027948583,note:'昭和45年改測・昭和47.7.30発行',list:'95-4-4-7'},
    {name:'犬山',north:35.4198610040155,west:136.8720248918,south:35.3365402282322,east:136.997017068459,note:'昭和45年改測・昭和46.11.30発行',list:'95-4-2-7'},
    {name:'小泉',north:35.4198640886661,west:136.997014000486,south:35.3365433178569,east:137.122006202529,note:'昭和48年測量・昭和50.2.28発行',list:'90-16-4-1'},
    {name:'土岐',north:35.4198671845816,west:137.12200312338,south:35.3365464187087,east:137.246995350845,note:'昭和48年測量・昭和50.2.28発行',list:'90-16-2-1'},
    {name:'養老',north:35.336527982299,west:136.4970606736,south:35.2532071750535,east:136.622052773092,note:'昭和43年改測・昭和46.12.28発行',list:'96-5-3-6'},
    {name:'竹鼻',north:35.3365310268683,west:136.622049751205,south:35.2532102246798,east:136.747041875909,note:'昭和43年改測・昭和45.10.30発行',list:'96-5-1-8'},
    {name:'一宮',north:35.3365340827233,west:136.747038842849,south:35.2532132855543,east:136.872030992802,note:'昭和43年改測・昭和46.3.30発行',list:'96-1-3-8'},
    {name:'小牧',north:35.3365371498495,west:136.872027948583,south:35.2532163576624,east:136.997020123823,note:'昭和43年改測・昭和46.3.30発行',list:'96-1-1-7'},
    {name:'高蔵寺',north:35.3365402282322,west:136.997017068459,south:35.2532194409896,east:137.122009269023,note:'昭和43年改測・昭和46.2.28発行',list:'91-13-3-4'},
    {name:'多治見',north:35.3365433178569,west:137.122006202529,south:35.253222535521,east:137.246998428455,note:'昭和43年測量・昭和45.8.30発行',list:'91-13-1-1'},
    {name:'駒野',north:35.2532041366899,west:136.497063684299,south:35.1698833131057,east:136.62205578256,note:'昭和43年改測・昭和46.4.30発行',list:'96-5-4-5'},
    {name:'津島',north:35.2532071750535,west:136.622052773092,south:35.1698863564966,east:136.747044896505,note:'昭和43年改測・昭和46.4.30発行',list:'96-5-2-6'},
    {name:'清洲',north:35.2532102246798,west:136.747041875909,south:35.1698894111127,east:136.872034024511,note:'昭和43年改測・昭和46.3.30発行',list:'96-1-4-7'},
    {name:'名古屋北部',north:35.2532132855543,west:136.872030992802,south:35.1698924769395,east:136.997023166631,note:'昭和43年改測・昭和46.3.30発行',list:'96-1-2-8'},
    {name:'瀬戸',north:35.2532163576624,west:136.997020123823,south:35.1698955539623,east:137.122012322916,note:'昭和43年改測・昭和46.2.28発行',list:'91-13-4-5'},
    {name:'猿投山',north:35.2532194409896,west:137.122009269023,south:35.1698986421666,east:137.247001493417,note:'昭和43年測量・昭和45.8.30発行',list:'91-13-2-1'},
    {name:'阿下喜',north:35.1698802809544,west:136.497066682625,south:35.0865594410074,east:136.62205877966,note:'昭和43年改測・昭和46.4.30発行',list:'96-6-3-6'},
    {name:'弥富',north:35.1698833131057,west:136.62205578256,south:35.0865624781564,east:136.747047904687,note:'昭和43年改測・昭和46.11.30発行',list:'96-6-1-8'},
    {name:'蟹江',north:35.1698863564966,west:136.747044896505,south:35.0865655265074,east:136.872037043761,note:'昭和43年改測・昭和46.2.28発行',list:'96-2-3-7'},
    {name:'名古屋南部',north:35.1698894111127,west:136.872034024511,south:35.0865685860462,east:136.997026196933,note:'昭和43年改測・昭和46.2.28発行',list:'96-2-1-6'},
    {name:'平針',north:35.1698924769395,west:136.997023166631,south:35.086571656758,east:137.122015364257,note:'昭和43年改測・昭和46.2.28発行',list:'91-14-3-5'},
    {name:'豊田北部',north:35.1698955539623,west:137.122012322916,south:35.0865747386284,east:137.247004545782,note:'昭和43年改測・昭和46.2.28発行',list:'91-14-1-6'},
    {name:'菰野',north:35.0865564150751,west:136.497069668629,south:35.0032355587416,east:136.622061764442,note:'昭和43年修正・昭和46.1.30発行',list:'96-6-4-7'},
    {name:'桑名',north:35.0865594410074,west:136.62205877966,south:35.0032385896418,east:136.747050900505,note:'昭和43年修正・昭和45.9.30発行',list:'96-6-2-10'},
    {name:'飛島',north:35.0865624781564,west:136.747047904687,south:35.0032416317212,east:136.872040050601,note:'昭和44年改測・昭和46.10.30発行',list:'96-2-4-7'},
    {name:'鳴海',north:35.0865655265074,west:136.872037043761,south:35.0032446849652,east:136.997029214782,note:'昭和43年改測・昭和46.2.28発行',list:'96-2-2-7'},
    {name:'知立',north:35.0865685860462,west:136.997026196933,south:35.0032477493593,east:137.122018393099,note:'昭和43年改測・昭和46.6.30発行',list:'91-14-4-7'},
    {name:'豊田南部',north:35.086571656758,west:137.122015364257,south:35.003250824889,east:137.247007585603,note:'昭和44年改測・昭和46.12.28発行',list:'91-14-2-7'},
    {name:'四日市西部',north:35.0032325390349,west:136.49707264236,south:34.9199116662909,east:136.622064736957,note:'昭和43年修正・昭和45.4.30発行',list:'96-7-3-8'},
    {name:'四日市東部',north:35.0032355587416,west:136.622061764442,south:34.9199146909359,east:136.747053884011,note:'昭和43年修正・昭和45.9.30発行',list:'96-7-1-7'},
    {name:'大野',north:35.0032385896418,west:136.747050900505,south:34.9199177267369,east:136.872043045084,note:'昭和44年改測・昭和47.2.28発行',list:'96-3-3-4'},
    {name:'刈谷',north:35.0032416317212,west:136.872040050601,south:34.9199207736795,east:136.997032220227,note:'昭和44年改測・昭和46.1.30発行',list:'96-3-1-5'},
    {name:'安城',north:35.0032446849652,west:136.997029214782,south:34.9199238317492,east:137.122021409493,note:'昭和44年改測・昭和46.11.30発行',list:'91-15-3-6'},
    {name:'岡崎',north:35.0032477493593,west:137.122018393099,south:34.9199269009314,east:137.247010612931,note:'昭和44年改測・昭和46.6.30発行',list:'91-15-1-7'},
    {name:'神戸',north:34.9199086528164,west:136.49707560387,south:34.8365877636383,east:136.622067697255,note:'昭和44年改測・昭和46.5.30発行',list:'96-7-4-6'},
    {name:'南五味塚',north:34.9199116662909,west:136.622064736957,south:34.8365907820214,east:136.747056855255,note:'昭和44年改測・昭和46.5.30発行',list:'96-7-2-5'},
    {name:'常滑',north:34.9199146909359,west:136.747053884011,south:34.8365938115374,east:136.87204602726,note:'昭和44年改測・昭和47.2.28発行',list:'96-3-4-4'},
    {name:'半田',north:34.9199177267369,west:136.872043045084,south:34.8365968521719,east:136.99703521332,note:'昭和44年改測・昭和46.2.28発行',list:'96-3-2-8'},
    {name:'西尾',north:34.9199207736795,west:136.997032220227,south:34.8365999039105,east:137.122024413489,note:'昭和44年改測・昭和46.6.30発行',list:'91-15-4-6'},
    {name:'幸田',north:34.9199238317492,west:137.122021409493,south:34.8366029667386,east:137.247013627816,note:'昭和44年改測・昭和47.3.30発行',list:'91-15-2-6'}
]});
dataset.age.push({
  folderName:'06', start:1976, end:1980, scale:'1/25000', mapList: [
    {name:'池野',north:35.5031756432074,west:136.497054614878,south:35.4198548685674,east:136.622046716848,note:'昭和51年修正・昭和52.12.28発行',list:'95-8-3-8'},
    {name:'北方',north:35.5031787001681,west:136.622043669968,south:35.4198579306444,east:136.747035797272,note:'昭和51年修正・昭和53.3.30発行',list:'95-8-1-9'},
    {name:'岐阜北部',north:35.5031817684604,west:136.747032739126,south:35.4198610040155,east:136.8720248918,note:'昭和51年修正・昭和52.11.30発行',list:'95-4-3-9'},
    {name:'美濃関',north:35.5031848480698,west:136.872021822404,south:35.4198640886661,east:136.997014000486,note:'昭和51年修正・昭和53.4.30発行',list:'95-4-1-7B'},
    {name:'美濃加茂',north:35.5031879389816,west:136.997010919852,south:35.4198671845816,east:137.12200312338,note:'昭和53年修正・昭和55.9.30発行',list:'90-16-3-2'},
    {name:'御嵩',north:35.503191041181,west:137.122000031524,south:35.4198702917471,east:137.246992260534,note:'昭和53年修正・昭和55.8.30発行',list:'90-16-1-2'},
    {name:'大垣',north:35.419851817799,west:136.497057650477,south:35.3365310268683,east:136.622049751205,note:'昭和51年修正・昭和52.12.28発行',list:'95-8-4-8'},
    {name:'岐阜西部',north:35.4198548685674,west:136.622046716848,south:35.3365340827233,east:136.747038842849,note:'昭和51年修正・昭和53.2.28発行',list:'95-8-2-9'},
    {name:'岐阜',north:35.4198579306444,west:136.747035797272,south:35.3365371498495,east:136.872027948583,note:'昭和51年修正・昭和53.2.28発行',list:'95-4-4-9'},
    {name:'犬山',north:35.4198610040155,west:136.8720248918,south:35.3365402282322,east:136.997017068459,note:'昭和51年修正・昭和52.11.30発行',list:'95-4-2-9'},
    {name:'小泉',north:35.4198640886661,west:136.997014000486,south:35.3365433178569,east:137.122006202529,note:'昭和53年修正・昭和54.11.30発行',list:'90-16-4-2'},
    {name:'土岐',north:35.4198671845816,west:137.12200312338,south:35.3365464187087,east:137.246995350845,note:'昭和53年修正・昭和54.11.30発行',list:'90-16-2-2'},
    {name:'養老',north:35.336527982299,west:136.4970606736,south:35.2532071750535,east:136.622052773092,note:'昭和54年二改・昭和56.3.30発行',list:'96-5-3-9'},
    {name:'竹鼻',north:35.3365310268683,west:136.622049751205,south:35.2532102246798,east:136.747041875909,note:'昭和54年二改・昭和56.8.30発行',list:'96-5-1-11'},
    {name:'一宮',north:35.3365340827233,west:136.747038842849,south:35.2532132855543,east:136.872030992802,note:'昭和55年二改・昭和57.7.30発行',list:'96-1-3-11'},
    {name:'小牧',north:35.3365371498495,west:136.872027948583,south:35.2532163576624,east:136.997020123823,note:'昭和55年二改・昭和57.8.30発行',list:'96-1-1-10'},
    {name:'高蔵寺',north:35.3365402282322,west:136.997017068459,south:35.2532194409896,east:137.122009269023,note:'昭和52年修正・昭和54.1.30発行',list:'91-13-3-7'},
    {name:'多治見',north:35.3365433178569,west:137.122006202529,south:35.253222535521,east:137.246998428455,note:'昭和52年修正・昭和55.1.30発行',list:'91-13-1-3'},
    {name:'駒野',north:35.2532041366899,west:136.497063684299,south:35.1698833131057,east:136.62205578256,note:'昭和54年二改・昭和56.5.30発行',list:'96-5-4-7'},
    {name:'津島',north:35.2532071750535,west:136.622052773092,south:35.1698863564966,east:136.747044896505,note:'昭和54年二改・昭和56.8.30発行',list:'96-5-2-10'},
    {name:'清洲',north:35.2532102246798,west:136.747041875909,south:35.1698894111127,east:136.872034024511,note:'昭和55年二改・昭和57.7.30発行',list:'96-1-4-10'},
    {name:'名古屋北部',north:35.2532132855543,west:136.872030992802,south:35.1698924769395,east:136.997023166631,note:'昭和55年二改・昭和57.2.28発行',list:'96-1-2-11'},
    {name:'瀬戸',north:35.2532163576624,west:136.997020123823,south:35.1698955539623,east:137.122012322916,note:'昭和52年修正・昭和54.1.30発行',list:'91-13-4-8'},
    {name:'猿投山',north:35.2532194409896,west:137.122009269023,south:35.1698986421666,east:137.247001493417,note:'昭和52年修正・昭和54.3.30発行',list:'91-13-2-3'},
    {name:'阿下喜',north:35.1698802809544,west:136.497066682625,south:35.0865594410074,east:136.62205877966,note:'昭和54年二改・昭和56.6.30発行',list:'96-6-3-8'},
    {name:'弥富',north:35.1698833131057,west:136.62205578256,south:35.0865624781564,east:136.747047904687,note:'昭和54年二改・昭和56.8.30発行',list:'96-6-1-11'},
    {name:'蟹江',north:35.1698863564966,west:136.747044896505,south:35.0865655265074,east:136.872037043761,note:'昭和55年二改・昭和57.1.30発行',list:'96-2-3-10'},
    {name:'名古屋南部',north:35.1698894111127,west:136.872034024511,south:35.0865685860462,east:136.997026196933,note:'昭和55年二改・昭和56.10.30発行',list:'96-2-1-9'},
    {name:'平針',north:35.1698924769395,west:136.997023166631,south:35.086571656758,east:137.122015364257,note:'昭和52年修正・昭和54.1.30発行',list:'91-14-3-8'},
    {name:'豊田北部',north:35.1698955539623,west:137.122012322916,south:35.0865747386284,east:137.247004545782,note:'昭和52年修正・昭和53.12.28発行',list:'91-14-1-10'},
    {name:'菰野',north:35.0865564150751,west:136.497069668629,south:35.0032355587416,east:136.622061764442,note:'昭和52年二改・昭和53.9.30発行',list:'96-6-4-10'},
    {name:'桑名',north:35.0865594410074,west:136.62205877966,south:35.0032385896418,east:136.747050900505,note:'昭和52年二改・昭和53.9.30発行',list:'96-6-2-13'},
    {name:'飛島',north:35.0865624781564,west:136.747047904687,south:35.0032416317212,east:136.872040050601,note:'昭和55年二改・昭和57.6.30発行',list:'96-2-4-10'},
    {name:'鳴海',north:35.0865655265074,west:136.872037043761,south:35.0032446849652,east:136.997029214782,note:'昭和55年二改・昭和57.8.30発行',list:'96-2-2-10'},
    {name:'知立',north:35.0865685860462,west:136.997026196933,south:35.0032477493593,east:137.122018393099,note:'昭和52年修正・昭和54.2.28発行',list:'91-14-4-10'},
    {name:'豊田南部',north:35.086571656758,west:137.122015364257,south:35.003250824889,east:137.247007585603,note:'昭和52年修正・昭和54.2.28発行',list:'91-14-2-10'},
    {name:'四日市西部',north:35.0032325390349,west:136.49707264236,south:34.9199116662909,east:136.622064736957,note:'昭和55年二改・昭和56.12.28発行',list:'96-7-3-11'},
    {name:'四日市東部',north:35.0032355587416,west:136.622061764442,south:34.9199146909359,east:136.747053884011,note:'昭和55年二改・昭和57.5.30発行',list:'96-7-1-10'},
    {name:'大野',north:35.0032385896418,west:136.747050900505,south:34.9199177267369,east:136.872043045084,note:'昭和55年二改・昭和57.7.30発行',list:'96-3-3-7'},
    {name:'刈谷',north:35.0032416317212,west:136.872040050601,south:34.9199207736795,east:136.997032220227,note:'昭和55年二改・昭和57.3.30発行',list:'96-3-1-9'},
    {name:'安城',north:35.0032446849652,west:136.997029214782,south:34.9199238317492,east:137.122021409493,note:'昭和52年修正・昭和53.10.30発行',list:'91-15-3-9'},
    {name:'岡崎',north:35.0032477493593,west:137.122018393099,south:34.9199269009314,east:137.247010612931,note:'昭和52年修正・昭和53.11.30発行',list:'91-15-1-10'},
    {name:'鈴鹿',north:34.9199086528164,west:136.49707560387,south:34.8365877636383,east:136.622067697255,note:'昭和55年二改・昭和57.1.30発行',list:'96-7-4-9'},
    {name:'南五味塚',north:34.9199116662909,west:136.622064736957,south:34.8365907820214,east:136.747056855255,note:'昭和55年二改・昭和57.1.30発行',list:'96-7-2-8'},
    {name:'常滑',north:34.9199146909359,west:136.747053884011,south:34.8365938115374,east:136.87204602726,note:'昭和55年二改・昭和57.5.30発行',list:'96-3-4-8'},
    {name:'半田',north:34.9199177267369,west:136.872043045084,south:34.8365968521719,east:136.99703521332,note:'昭和55年二改・昭和57.3.30発行',list:'96-3-2-11'},
    {name:'西尾',north:34.9199207736795,west:136.997032220227,south:34.8365999039105,east:137.122024413489,note:'昭和52年修正・昭和53.11.30発行',list:'91-15-4-9'},
    {name:'幸田',north:34.9199238317492,west:137.122021409493,south:34.8366029667386,east:137.247013627816,note:'昭和52年修正・昭和53.9.30発行',list:'91-15-2-8'}
]});
dataset.age.push({
  folderName:'07', start:1984, end:1989, scale:'1/25000', mapList: [
    {name:'池野',north:35.5031756432074,west:136.497054614878,south:35.4198548685674,east:136.622046716848,note:'昭和63年修正・昭和63.12.28発行',list:'95-8-3-10'},
    {name:'北方',north:35.5031787001681,west:136.622043669968,south:35.4198579306444,east:136.747035797272,note:'昭和63年修正・平成1.3.30発行',list:'95-8-1-11'},
    {name:'岐阜北部',north:35.5031817684604,west:136.747032739126,south:35.4198610040155,east:136.8720248918,note:'昭和62年修正・昭和63.12.28発行',list:'95-4-3-11'},
    {name:'美濃関',north:35.5031848480698,west:136.872021822404,south:35.4198640886661,east:136.997014000486,note:'昭和62年修正・平成1.1.30発行',list:'95-4-1-9'},
    {name:'美濃加茂',north:35.5031879389816,west:136.997010919852,south:35.4198671845816,east:137.12200312338,note:'昭和61年修正・昭和63.2.28発行',list:'90-16-3-3C'},
    {name:'御嵩',north:35.503191041181,west:137.122000031524,south:35.4198702917471,east:137.246992260534,note:'昭和61年修正・昭和62.12.28発行',list:'90-16-1-3'},
    {name:'大垣',north:35.419851817799,west:136.497057650477,south:35.3365310268683,east:136.622049751205,note:'昭和63年修正・昭和63.12.28発行',list:'95-8-4-10'},
    {name:'岐阜西部',north:35.4198548685674,west:136.622046716848,south:35.3365340827233,east:136.747038842849,note:'昭和63年修正・昭和63.12.28発行',list:'95-8-2-11'},
    {name:'岐阜',north:35.4198579306444,west:136.747035797272,south:35.3365371498495,east:136.872027948583,note:'昭和62年修正・昭和63.12.28発行',list:'95-4-4-11'},
    {name:'犬山',north:35.4198610040155,west:136.8720248918,south:35.3365402282322,east:136.997017068459,note:'昭和62年修正・平成1.1.30発行',list:'95-4-2-11'},
    {name:'小泉',north:35.4198640886661,west:136.997014000486,south:35.3365433178569,east:137.122006202529,note:'昭和61年修正・昭和63.1.30発行',list:'90-16-4-3'},
    {name:'土岐',north:35.4198671845816,west:137.12200312338,south:35.3365464187087,east:137.246995350845,note:'昭和61年修正・昭和62.12.28発行',list:'90-16-2-3'},
    {name:'養老',north:35.336527982299,west:136.4970606736,south:35.2532071750535,east:136.622052773092,note:'昭和59年修正・昭和61.11.30発行',list:'96-5-3-10'},
    {name:'竹鼻',north:35.3365310268683,west:136.622049751205,south:35.2532102246798,east:136.747041875909,note:'昭和59年修正・昭和61.11.30発行',list:'96-5-1-12'},
    {name:'一宮',north:35.3365340827233,west:136.747038842849,south:35.2532132855543,east:136.872030992802,note:'昭和61年修正・昭和62.9.30発行',list:'96-1-3-12'},
    {name:'小牧',north:35.3365371498495,west:136.872027948583,south:35.2532163576624,east:136.997020123823,note:'昭和61年修正・昭和62.10.30発行',list:'96-1-1-11'},
    {name:'高蔵寺',north:35.3365402282322,west:136.997017068459,south:35.2532194409896,east:137.122009269023,note:'昭和61年修正・昭和62.9.30発行',list:'91-13-3-9'},
    {name:'多治見',north:35.3365433178569,west:137.122006202529,south:35.253222535521,east:137.246998428455,note:'昭和61年修正・昭和63.2.28発行',list:'91-13-1-5'},
    {name:'駒野',north:35.2532041366899,west:136.497063684299,south:35.1698833131057,east:136.62205578256,note:'昭和59年修正・昭和61.10.30発行',list:'96-5-4-8'},
    {name:'津島',north:35.2532071750535,west:136.622052773092,south:35.1698863564966,east:136.747044896505,note:'昭和59年修正・昭和61.12.28発行',list:'96-5-2-11'},
    {name:'清洲',north:35.2532102246798,west:136.747041875909,south:35.1698894111127,east:136.872034024511,note:'昭和61年修正・昭和62.12.28発行',list:'96-1-4-11'},
    {name:'名古屋北部',north:35.2532132855543,west:136.872030992802,south:35.1698924769395,east:136.997023166631,note:'昭和61年修正・昭和62.6.30発行',list:'96-1-2-12'},
    {name:'瀬戸',north:35.2532163576624,west:136.997020123823,south:35.1698955539623,east:137.122012322916,note:'昭和61年修正・昭和63.3.30発行',list:'91-13-4-10'},
    {name:'猿投山',north:35.2532194409896,west:137.122009269023,south:35.1698986421666,east:137.247001493417,note:'昭和61年修正・昭和62.10.30発行',list:'91-13-2-5'},
    {name:'阿下喜',north:35.1698802809544,west:136.497066682625,south:35.0865594410074,east:136.62205877966,note:'昭和59年修正・昭和62.3.30発行',list:'96-6-3-9'},
    {name:'弥富',north:35.1698833131057,west:136.62205578256,south:35.0865624781564,east:136.747047904687,note:'昭和59年修正・昭和62.1.30発行',list:'96-6-1-12'},
    {name:'蟹江',north:35.1698863564966,west:136.747044896505,south:35.0865655265074,east:136.872037043761,note:'昭和61年修正・昭和62.8.30発行',list:'96-2-3-11'},
    {name:'名古屋南部',north:35.1698894111127,west:136.872034024511,south:35.0865685860462,east:136.997026196933,note:'昭和61年修正・昭和62.6.30発行',list:'96-2-1-10'},
    {name:'平針',north:35.1698924769395,west:136.997023166631,south:35.086571656758,east:137.122015364257,note:'昭和61年修正・昭和62.8.30発行',list:'91-14-3-10'},
    {name:'豊田北部',north:35.1698955539623,west:137.122012322916,south:35.0865747386284,east:137.247004545782,note:'昭和61年修正・昭和62.6.30発行',list:'91-14-1-12'},
    {name:'菰野',north:35.0865564150751,west:136.497069668629,south:35.0032355587416,east:136.622061764442,note:'昭和59年修正・昭和61.12.28発行',list:'96-6-4-11'},
    {name:'桑名',north:35.0865594410074,west:136.62205877966,south:35.0032385896418,east:136.747050900505,note:'昭和59年修正・昭和62.3.30発行',list:'96-6-2-14'},
    {name:'飛島',north:35.0865624781564,west:136.747047904687,south:35.0032416317212,east:136.872040050601,note:'昭和61年修正・昭和62.12.28発行',list:'96-2-4-11'},
    {name:'鳴海',north:35.0865655265074,west:136.872037043761,south:35.0032446849652,east:136.997029214782,note:'昭和61年修正・昭和62.4.30発行',list:'96-2-2-11'},
    {name:'知立',north:35.0865685860462,west:136.997026196933,south:35.0032477493593,east:137.122018393099,note:'昭和61年修正・昭和62.7.30発行',list:'91-14-4-12'},
    {name:'豊田南部',north:35.086571656758,west:137.122015364257,south:35.003250824889,east:137.247007585603,note:'昭和61年修正・昭和63.2.28発行',list:'91-14-2-12'},
    {name:'四日市西部',north:35.0032325390349,west:136.49707264236,south:34.9199116662909,east:136.622064736957,note:'平成1年修正・平成2.8.1発行',list:'96-7-3-12'},
    {name:'四日市東部',north:35.0032355587416,west:136.622061764442,south:34.9199146909359,east:136.747053884011,note:'平成1年修正・平成2.9.1発行',list:'96-7-1-11'},
    {name:'大野',north:35.0032385896418,west:136.747050900505,south:34.9199177267369,east:136.872043045084,note:'昭和63年修正・平成1.12.1発行',list:'96-3-3-8'},
    {name:'刈谷',north:35.0032416317212,west:136.872040050601,south:34.9199207736795,east:136.997032220227,note:'昭和63年修正・平成2.1.1発行',list:'96-3-1-10'},
    {name:'安城',north:35.0032446849652,west:136.997029214782,south:34.9199238317492,east:137.122021409493,note:'昭和62年修正・昭和63.5.30発行',list:'91-15-3-11'},
    {name:'岡崎',north:35.0032477493593,west:137.122018393099,south:34.9199269009314,east:137.247010612931,note:'昭和62年修正・昭和63.6.30発行',list:'91-15-1-12'},
    {name:'鈴鹿',north:34.9199086528164,west:136.49707560387,south:34.8365877636383,east:136.622067697255,note:'平成1年修正・平成2.8.1発行',list:'96-7-4-10'},
    {name:'南五味塚',north:34.9199116662909,west:136.622064736957,south:34.8365907820214,east:136.747056855255,note:'平成1年修正・平成2.9.1発行',list:'96-7-2-9'},
    {name:'常滑',north:34.9199146909359,west:136.747053884011,south:34.8365938115374,east:136.87204602726,note:'昭和63年修正・平成2.4.1発行',list:'96-3-4-9'},
    {name:'半田',north:34.9199177267369,west:136.872043045084,south:34.8365968521719,east:136.99703521332,note:'昭和63年修正・平成1.12.1発行',list:'96-3-2-12'},
    {name:'西尾',north:34.9199207736795,west:136.997032220227,south:34.8365999039105,east:137.122024413489,note:'昭和62年修正・昭和63.8.30発行',list:'91-15-4-12'},
    {name:'幸田',north:34.9199238317492,west:137.122021409493,south:34.8366029667386,east:137.247013627816,note:'昭和62年修正・昭和63.6.30発行',list:'91-15-2-10'}
]});
dataset.age.push({
  folderName:'08', start:1992, end:1996, scale:'1/25000', mapList: [
    {name:'池野',north:35.5031756432074,west:136.497054614878,south:35.4198548685674,east:136.622046716848,note:'平成6年修正・平成7.7.1発行',list:'95-8-3-11'},
    {name:'北方',north:35.5031787001681,west:136.622043669968,south:35.4198579306444,east:136.747035797272,note:'平成6年修正・平成7.7.1発行',list:'95-8-1-12'},
    {name:'岐阜北部',north:35.5031817684604,west:136.747032739126,south:35.4198610040155,east:136.8720248918,note:'平成4年修正・平成5.10.1発行',list:'95-4-3-12'},
    {name:'美濃関',north:35.5031848480698,west:136.872021822404,south:35.4198640886661,east:136.997014000486,note:'平成4年修正・平成5.10.1発行',list:'95-4-1-10'},
    {name:'美濃加茂',north:35.5031879389816,west:136.997010919852,south:35.4198671845816,east:137.12200312338,note:'平成5年修正・平成6.10.1発行',list:'90-16-3-4'},
    {name:'御嵩',north:35.503191041181,west:137.122000031524,south:35.4198702917471,east:137.246992260534,note:'平成5年修正・平成6.9.1発行',list:'90-16-1-4'},
    {name:'大垣',north:35.419851817799,west:136.497057650477,south:35.3365310268683,east:136.622049751205,note:'平成6年修正・平成7.12.1発行',list:'95-8-4-11'},
    {name:'岐阜西部',north:35.4198548685674,west:136.622046716848,south:35.3365340827233,east:136.747038842849,note:'平成6年修正・平成7.5.1発行',list:'95-8-2-12'},
    {name:'岐阜',north:35.4198579306444,west:136.747035797272,south:35.3365371498495,east:136.872027948583,note:'平成4年修正・平成5.4.1発行',list:'95-4-4-12'},
    {name:'犬山',north:35.4198610040155,west:136.8720248918,south:35.3365402282322,east:136.997017068459,note:'平成4年修正・平成5.4.1発行',list:'95-4-2-12'},
    {name:'小泉',north:35.4198640886661,west:136.997014000486,south:35.3365433178569,east:137.122006202529,note:'平成5年修正・平成6.11.1発行',list:'90-16-4-4'},
    {name:'土岐',north:35.4198671845816,west:137.12200312338,south:35.3365464187087,east:137.246995350845,note:'平成5年修正・平成6.8.1発行',list:'90-16-2-4'},
    {name:'養老',north:35.336527982299,west:136.4970606736,south:35.2532071750535,east:136.622052773092,note:'平成4年修正・平成5.10.1発行',list:'96-5-3-11'},
    {name:'竹鼻',north:35.3365310268683,west:136.622049751205,south:35.2532102246798,east:136.747041875909,note:'平成4年修正・平成5.11.1発行',list:'96-5-1-13'},
    {name:'一宮',north:35.3365340827233,west:136.747038842849,south:35.2532132855543,east:136.872030992802,note:'平成4年修正・平成5.4.1発行',list:'96-1-3-13'},
    {name:'小牧',north:35.3365371498495,west:136.872027948583,south:35.2532163576624,east:136.997020123823,note:'平成4年修正・平成5.4.1発行',list:'96-1-1-12'},
    {name:'高蔵寺',north:35.3365402282322,west:136.997017068459,south:35.2532194409896,east:137.122009269023,note:'平成7年修正・平成8.6.1発行',list:'91-13-3-12'},
    {name:'多治見',north:35.3365433178569,west:137.122006202529,south:35.253222535521,east:137.246998428455,note:'平成7年修正・平成8.9.1発行',list:'91-13-1-7'},
    {name:'駒野',north:35.2532041366899,west:136.497063684299,south:35.1698833131057,east:136.62205578256,note:'平成4年修正・平成5.10.1発行',list:'96-5-4-10'},
    {name:'津島',north:35.2532071750535,west:136.622052773092,south:35.1698863564966,east:136.747044896505,note:'平成4年修正・平成5.10.1発行',list:'96-5-2-13'},
    {name:'清洲',north:35.2532102246798,west:136.747041875909,south:35.1698894111127,east:136.872034024511,note:'平成4年修正・平成5.4.1発行',list:'96-1-4-12'},
    {name:'名古屋北部',north:35.2532132855543,west:136.872030992802,south:35.1698924769395,east:136.997023166631,note:'平成4年修正・平成5.4.1発行',list:'96-1-2-14'},
    {name:'瀬戸',north:35.2532163576624,west:136.997020123823,south:35.1698955539623,east:137.122012322916,note:'平成7年修正・平成8.9.1発行',list:'91-13-4-13'},
    {name:'猿投山',north:35.2532194409896,west:137.122009269023,south:35.1698986421666,east:137.247001493417,note:'平成7年修正・平成8.9.1発行',list:'91-13-2-7'},
    {name:'阿下喜',north:35.1698802809544,west:136.497066682625,south:35.0865594410074,east:136.62205877966,note:'平成5年修正・平成6.12.1発行',list:'96-6-3-10'},
    {name:'弥富',north:35.1698833131057,west:136.62205578256,south:35.0865624781564,east:136.747047904687,note:'平成5年修正・平成6.12.1発行',list:'96-6-1-14'},
    {name:'蟹江',north:35.1698863564966,west:136.747044896505,south:35.0865655265074,east:136.872037043761,note:'平成8年修正・平成9.11.1発行',list:'96-2-3-13'},
    {name:'名古屋南部',north:35.1698894111127,west:136.872034024511,south:35.0865685860462,east:136.997026196933,note:'平成8年修正・平成9.5.1発行',list:'96-2-1-14'},
    {name:'平針',north:35.1698924769395,west:136.997023166631,south:35.086571656758,east:137.122015364257,note:'平成8年修正・平成9.9.1発行',list:'91-14-3-14'},
    {name:'豊田北部',north:35.1698955539623,west:137.122012322916,south:35.0865747386284,east:137.247004545782,note:'平成8年修正・平成9.9.1発行',list:'91-14-1-15'},
    {name:'菰野',north:35.0865564150751,west:136.497069668629,south:35.0032355587416,east:136.622061764442,note:'平成5年修正・平成6.12.1発行',list:'96-6-4-12'},
    {name:'桑名',north:35.0865594410074,west:136.62205877966,south:35.0032385896418,east:136.747050900505,note:'平成5年修正・平成6.12.1発行',list:'96-6-2-15'},
    {name:'飛島',north:35.0865624781564,west:136.747047904687,south:35.0032416317212,east:136.872040050601,note:'平成8年修正・平成9.9.1発行',list:'96-2-4-13'},
    {name:'鳴海',north:35.0865655265074,west:136.872037043761,south:35.0032446849652,east:136.997029214782,note:'平成8年修正・平成9.7.1発行',list:'96-2-2-13'},
    {name:'知立',north:35.0865685860462,west:136.997026196933,south:35.0032477493593,east:137.122018393099,note:'平成8年修正・平成9.8.1発行',list:'91-14-4-14'},
    {name:'豊田南部',north:35.086571656758,west:137.122015364257,south:35.003250824889,east:137.247007585603,note:'平成8年修正・平成9.11.1発行',list:'91-14-2-14'},
    {name:'四日市西部',north:35.0032325390349,west:136.49707264236,south:34.9199116662909,east:136.622064736957,note:'平成6年修正・平成7.8.1発行',list:'96-7-3-13'},
    {name:'四日市東部',north:35.0032355587416,west:136.622061764442,south:34.9199146909359,east:136.747053884011,note:'平成6年修正・平成7.4.1発行',list:'96-7-1-12'},
    {name:'大野',north:35.0032385896418,west:136.747050900505,south:34.9199177267369,east:136.872043045084,note:'平成8年修正・平成9.10.1発行',list:'96-3-3-9'},
    {name:'刈谷',north:35.0032416317212,west:136.872040050601,south:34.9199207736795,east:136.997032220227,note:'平成8年修正・平成9.11.1発行',list:'96-3-1-12'},
    {name:'安城',north:35.0032446849652,west:136.997029214782,south:34.9199238317492,east:137.122021409493,note:'平成5年修正・平成6.8.1発行',list:'91-15-3-12'},
    {name:'岡崎',north:35.0032477493593,west:137.122018393099,south:34.9199269009314,east:137.247010612931,note:'平成5年修正・平成6.8.1発行',list:'91-15-1-13'},
    {name:'鈴鹿',north:34.9199086528164,west:136.49707560387,south:34.8365877636383,east:136.622067697255,note:'平成6年修正・平成7.4.1発行',list:'96-7-4-11'},
    {name:'鈴鹿',north:34.9199116662909,west:136.622064736957,south:34.8365907820214,east:136.747056855255,note:'平成6年修正・平成7.4.1発行',list:''},
    {name:'常滑',north:34.9199146909359,west:136.747053884011,south:34.8365938115374,east:136.87204602726,note:'平成8年修正・平成9.11.1発行',list:'96-3-4-10'},
    {name:'半田',north:34.9199177267369,west:136.872043045084,south:34.8365968521719,east:136.99703521332,note:'平成8年修正・平成9.11.1発行',list:'96-3-2-14'},
    {name:'西尾',north:34.9199207736795,west:136.997032220227,south:34.8365999039105,east:137.122024413489,note:'平成5年修正・平成6.8.1発行',list:'91-15-4-13'},
    {name:'幸田',north:34.9199238317492,west:137.122021409493,south:34.8366029667386,east:137.247013627816,note:'平成5年修正・平成6.8.1発行',list:'91-15-2-11'}
]});
kjmapDataSet['keihansin'] = new Object();
dataset = kjmapDataSet['keihansin'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1892, end:1910, scale:'1/20000', mapList: [
    {name:'前開',north:34.7365610055593,west:135.000101904413,south:34.6699042240326,east:135.100095340001,note:'明治43年測図・大正2.1.30発行',list:''},
    {name:'舞子',north:34.6699019363814,west:135.000104138601,south:34.6032451345229,east:135.100097573875,note:'明治43年測図・大正2.1.30発行',list:''},
    {name:'稲田',north:34.9365404970418,west:135.100086330529,south:34.8698837498802,east:135.200079782721,note:'明治43年測図・大正1.12.28発行',list:''},
    {name:'屏風辻',north:34.8698814435261,west:135.100088594041,south:34.8032246760535,east:135.200082045887,note:'明治43年測図・大正2.1.30発行',list:''},
    {name:'丹生山',north:34.803222373526,west:135.100090850108,south:34.7365655957291,east:135.200084301608,note:'明治43年測図・大正2.2.28発行',list:''},
    {name:'神戸',north:34.7365632970315,west:135.100093098753,south:34.6699065188971,east:135.200086549907,note:'明治43年測図・大正2.2.28発行',list:''},
    {name:'須磨',north:34.6699042240326,west:135.100095340001,south:34.6032474255511,east:135.200088790811,note:'明治43年測図・大正2.1.30発行',list:''},
    {name:'三田',north:34.9365428072193,west:135.200077512087,south:34.8698860634767,east:135.300070979956,note:'明治43年測図・大正2.4.30発行',list:''},
    {name:'道場川原',north:34.8698837498802,west:135.200079782721,south:34.8032269858113,east:135.300073250214,note:'明治43年測図・大正2.2.28発行',list:''},
    {name:'有馬',north:34.8032246760535,west:135.200082045887,south:34.736567901645,east:135.300075513003,note:'明治43年測図・明治44.10.30発行',list:''},
    {name:'御影',north:34.7365655957291,west:135.200084301608,south:34.6699088209679,east:135.300077768349,note:'明治43年測図・明治44.10.30発行',list:''},
    {name:'尾崎',north:34.4032701163331,west:135.200095469379,south:34.3366132796359,east:135.300088934256,note:'明治43年測図・大正8.2.28発行',list:''},
    {name:'廣根',north:34.9365451246513,west:135.300068702206,south:34.8698883843086,east:135.400062185772,note:'明治42年測図・大正1.10.30発行',list:''},
    {name:'生瀬',north:34.8698860634767,west:135.300070979956,south:34.8032293027925,east:135.400064463115,note:'明治42年測図・明治44.10.30発行',list:''},
    {name:'甲山',north:34.8032269858113,west:135.300073250214,south:34.7365702147723,east:135.400066732967,note:'明治42年測図・明治44.10.30発行',list:''},
    {name:'西ノ宮',north:34.736567901645,west:135.300075513003,south:34.6699111302381,east:135.400068995351,note:'明治42年測図・明治44.9.30発行',list:''},
    {name:'春木',north:34.536590620052,west:135.300082256804,south:34.4699338174728,east:135.400075737941,note:'明治42年測図・明治45.5.30発行',list:''},
    {name:'岸和田',north:34.4699315197934,west:135.300084489962,south:34.4032746968006,east:135.400077970697,note:'明治42年測図・大正1.10.30発行',list:''},
    {name:'日根野',north:34.4032724029913,west:135.300086715771,south:34.3366155695719,east:135.400080196106,note:'明治43年測図・明治44.10.30発行',list:''},
    {name:'妙見山',north:34.9365474493306,west:135.400059900913,south:34.8698907123688,east:135.500053400197,note:'明治42年測図・大正1.10.30発行',list:''},
    {name:'池田',north:34.8698883843086,west:135.400062185772,south:34.8032316269901,east:135.500055684618,note:'明治42年測図・明治44.10.30発行',list:''},
    {name:'伊丹',north:34.8032293027925,west:135.400064463115,south:34.736572535104,east:135.500057961525,note:'明治42年測図・明治44.10.30発行',list:''},
    {name:'大阪西北部',north:34.7365702147723,west:135.400066732967,south:34.6699134467006,east:135.50006023094,note:'明治42年測図・明治44.10.30発行',list:''},
    {name:'大阪西南部',north:34.6699111302381,west:135.400068995351,south:34.6032543417735,east:135.50006249289,note:'明治42年測図・大正1.11.30発行',list:''},
    {name:'堺',north:34.6032520291834,west:135.400071250292,south:34.5365952303126,east:135.500064747398,note:'明治42年測図・大正1.11.30発行',list:''},
    {name:'信太山',north:34.5365929215982,west:135.400073497814,south:34.4699361223083,east:135.500066994488,note:'明治42年測図・大正1.8.30発行',list:''},
    {name:'内畑',north:34.4699338174728,west:135.400075737941,south:34.4032769977541,east:135.500069234183,note:'明治42年測図・大正1.11.30発行',list:''},
    {name:'牛瀧',north:34.4032746968006,west:135.400077970697,south:34.33661786664,east:135.500071466509,note:'明治43年測図・大正2.4.30発行',list:''},
    {name:'亀岡',north:35.0698679195502,west:135.500046501598,south:35.0032111966615,east:135.600040017559,note:'明治42年測図・大正1.11.30発行',list:''},
    {name:'法貴',north:35.0032088536406,west:135.500048808712,south:34.936552120403,east:135.600042324201,note:'明治42年測図・大正1.11.30発行',list:''},
    {name:'大岩',north:34.9365497812502,west:135.500051108236,south:34.8698930476503,east:135.600044623256,note:'明治42年測図・明治44.10.30発行',list:''},
    {name:'茨木',north:34.8698907123688,west:135.500053400197,south:34.8032339583969,east:135.600046914749,note:'明治41年測図・明治44.10.30発行',list:''},
    {name:'吹田',north:34.8032316269901,west:135.500055684618,south:34.7365748626329,east:135.600049198704,note:'明治41年測図・明治44.9.30発行',list:''},
    {name:'大阪東北部',north:34.736572535104,west:135.500057961525,south:34.6699157703483,east:135.600051475144,note:'明治41年測図・明治44.10.30発行',list:''},
    {name:'大阪東南部',north:34.6699134467006,west:135.50006023094,south:34.6032566615368,east:135.600053744096,note:'明治41年測図・大正1.10.30発行',list:''},
    {name:'金田',north:34.6032543417735,west:135.50006249289,south:34.5365975461883,east:135.600056005583,note:'明治41年測図・大正1.9.30発行',list:''},
    {name:'狭山',north:34.5365952303126,west:135.500064747398,south:34.4699384342931,east:135.600058259628,note:'明治41年測図・大正1.11.30発行',list:''},
    {name:'嵯峨',north:35.0698702664359,west:135.600037703303,south:35.0032135469204,east:135.700031235081,note:'明治42年測図・大正1.11.30発行',list:''},
    {name:'大原野',north:35.0032111966615,west:135.600040017559,south:34.9365544667818,east:135.700033548835,note:'明治42年測図・大正1.9.30発行',list:''},
    {name:'山崎',north:34.936552120403,west:135.600042324201,south:34.8698953901458,east:135.700035854978,note:'明治42年測図・明治44.9.30発行',list:''},
    {name:'高槻',north:34.8698930476503,west:135.600044623256,south:34.8032362970058,east:135.700038153535,note:'明治41年測図・明治44.10.30発行',list:''},
    {name:'星田',north:34.8032339583969,west:135.600046914749,south:34.7365771973519,east:135.700040444531,note:'明治41年測図・明治44.10.30発行',list:''},
    {name:'生駒山',north:34.7365748626329,west:135.600049198704,south:34.6699181011743,east:135.70004272799,note:'明治41年測図・大正1.8.30発行',list:''},
    {name:'信貴山',north:34.6699157703483,west:135.600051475144,south:34.6032589884663,east:135.700045003936,note:'明治41年測図・大正1.10.30発行',list:''},
    {name:'古市',north:34.6032566615368,west:135.600053744096,south:34.5365998692181,east:135.700047272395,note:'明治41年測図・明治44.2.28発行',list:''},
    {name:'富田林',north:34.5365975461883,west:135.600056005583,south:34.46994075342,east:135.700049533389,note:'明治41年測図・明治44.3.30発行',list:''},
    {name:'京都北部',north:35.0698726205715,west:135.700028913692,south:35.0032159044102,east:135.800022461307,note:'明治42年測図・大正1.8.30発行',list:''},
    {name:'京都南部',north:35.0032135469204,west:135.700031235081,south:34.9365568203797,east:135.800024782165,note:'明治42年測図・大正1.8.15発行',list:''},
    {name:'淀',north:34.9365544667818,west:135.700033548835,south:34.8698977398484,east:135.800027095388,note:'明治42年測図・明治45.6.30発行',list:''},
    {name:'田邊',north:34.8698953901458,west:135.700035854978,south:34.8032386428098,east:135.800029401003,note:'明治41年測図・明治45.5.30発行',list:''},
    {name:'高山',north:34.8032362970058,west:135.700038153535,south:34.7365795392541,east:135.800031699033,note:'明治41年測図・明治45.5.30発行',list:''},
    {name:'西大寺',north:34.7365771973519,west:135.700040444531,south:34.6699204391713,east:135.800033989502,note:'明治41年測図・明治45.3.30発行',list:''},
    {name:'郡山',north:34.6699181011743,west:135.70004272799,south:34.6032613225549,east:135.800036272437,note:'明治41年測図・明治45.6.30発行',list:''},
    {name:'田原本',north:34.6032589884663,west:135.700045003936,south:34.5366021993951,east:135.80003854786,note:'明治41年測図・明治44.8.30発行',list:''},
    {name:'高田',north:34.5365998692181,west:135.700047272395,south:34.469943079682,east:135.800040815797,note:'明治41年測図・明治43.11.30発行',list:''},
    {name:'大津',north:35.06987498195,west:135.80002013279,south:35.0032182691237,east:135.900013696262,note:'明治42年測図・明治45.4.30発行',list:''},
    {name:'膳所',north:35.0032159044102,west:135.800022461307,south:34.9365591811892,east:135.900016024217,note:'明治42年測図・大正1.8.25発行',list:''},
    {name:'宇治',north:34.9365568203797,west:135.800024782165,south:34.8699000967507,east:135.900018344514,note:'明治42年測図・明治45.5.30発行',list:''},
    {name:'郷之口',north:34.8698977398484,west:135.800027095388,south:34.8032409958017,east:135.900020657179,note:'明治41年測図・明治45.1.30発行',list:''},
    {name:'木津',north:34.8032386428098,west:135.800029401003,south:34.7365818883321,east:135.900022962236,note:'明治41年測図・明治45.3.30発行',list:''},
    {name:'奈良',north:34.7365795392541,west:135.800031699033,south:34.6699227843322,east:135.900025259709,note:'明治41年測図・明治45.5.30発行',list:''},
    {name:'櫟本',north:34.6699204391713,west:135.800033989502,south:34.6032636637955,east:135.900027549625,note:'明治41年測図・明治45.1.30発行',list:''},
    {name:'丹波市',north:34.6032613225549,west:135.800036272437,south:34.536604536712,east:135.900029832006,note:'明治41年測図・明治43.7.30発行',list:''},
    {name:'櫻井',north:34.5366021993951,west:135.80003854786,south:34.469945413072,east:135.900032106878,note:'明治41年測図・明治43.11.30発行',list:''},
    {name:'草津',north:35.0698773505641,west:135.900011360624,south:35.0032206410536,east:136.000004939973,note:'明治25年測図・明治28.5.29発行',list:''},
    {name:'瀬田',north:35.0032182691237,west:135.900013696262,south:34.9365615492034,east:136.000007275018,note:'明治25年測図・明治28.1.31発行',list:''}
]});
dataset.age.push({
  folderName:'00', start:1922, end:1923, scale:'1/25000', mapList: [
    {name:'亀岡',north:35.0865008953339,west:135.500045913624,south:35.0031799980259,east:135.625037811117,note:'大正11年測図・大正14.11.30発行',list:'100-6-4-1'},
    {name:'京都西北部',north:35.0865038312793,west:135.62503491488,south:35.0031829392375,east:135.750026837101,note:'大正11年測図・大正14.8.30発行',list:'100-6-2-1'},
    {name:'京都東北部',north:35.0865067785547,west:135.750023929715,south:35.0031858917418,east:135.875015876704,note:'大正11年測図・大正15.1.30発行',list:'100-2-4-1'},
    {name:'草津',north:35.0865097371461,west:135.875012958184,south:35.0031888555246,east:136.000004929978,note:'大正11年測図・大正14.7.30発行',list:'100-2-2-1'},
    {name:'法貴',north:35.0031770681208,west:135.5000487987,south:34.9198561546396,east:135.625040695452,note:'大正11年測図・大正14.12.28発行',list:'100-7-3-1'},
    {name:'京都西南部',north:35.0031799980259,west:135.625037811117,south:34.919859089781,east:135.750029732538,note:'大正11年測図・大正14.11.30発行',list:'100-7-1-1'},
    {name:'京都東南部',north:35.0031829392375,west:135.750026837101,south:34.9198620361918,east:135.87501878323,note:'大正11年測図・大正14.10.30発行',list:'100-3-3-1'},
    {name:'瀬田',north:35.0031858917418,west:135.875015876704,south:34.9198649938578,east:136.000007847578,note:'大正11年測図・大正14.11.30発行',list:'100-3-1-1'},
    {name:'三田',north:34.9198445270454,west:135.125084682112,south:34.8365235815238,east:135.250076504528,note:'大正12年測図・大正15.7.30発行',list:'100-15-2-4'},
    {name:'武田尾',north:34.9198474169705,west:135.2500736653,south:34.8365264767672,east:135.37506551221,note:'大正12年測図・昭和2.1.30発行',list:'100-11-4-1'},
    {name:'広根',north:34.9198503182204,west:135.375062661885,south:34.8365293832983,east:135.500054533327,note:'大正12年測図・昭和2.4.30発行',list:'100-11-2-1'},
    {name:'高槻',north:34.9198532307814,west:135.500051671918,south:34.8365323011032,east:135.625043567931,note:'大正11年測図・大正14.10.30発行',list:'100-7-4-1'},
    {name:'淀',north:34.9198561546396,west:135.625040695452,south:34.836535230168,east:135.750032616075,note:'大正11年測図・大正14.10.30発行',list:'100-7-2-1'},
    {name:'宇治',north:34.919859089781,west:135.750029732538,south:34.8365381704788,east:135.875021677809,note:'大正11年測図・大正14.8.30発行',list:'100-3-4-1'},
    {name:'有馬',north:34.8365206975817,west:135.125087510228,south:34.7531997359289,east:135.250079332086,note:'大正12年測図・昭和1.12.28発行',list:'100-16-1-1'},
    {name:'伊丹',north:34.8365264767672,west:135.37506551221,south:34.7532055256544,east:135.500057382976,note:'大正12年測図・昭和2.9.30発行',list:'100-12-1-1'},
    {name:'吹田',north:34.8365293832983,west:135.500054533327,south:34.7532084373996,east:135.625046428605,note:'大正12年測図・昭和2.1.30発行',list:'100-8-3-1'},
    {name:'枚方',north:34.8365323011032,west:135.625043567931,south:34.7532113603814,east:135.750035487759,note:'大正11年測図・大正14.11.30発行',list:'100-8-1-1'},
    {name:'田辺',north:34.836535230168,west:135.750032616075,south:34.7532142945858,east:135.875024560491,note:'大正11年測図・大正14.10.30発行',list:'100-4-3-1'},
    {name:'前開',north:34.753193991315,west:135.000101334672,south:34.6698730082114,east:135.125093131636,note:'大正12年測図・大正15.11.30発行',list:'100-16-4-1'},
    {name:'神戸首部',north:34.7531968579761,west:135.125090326721,south:34.6698758801685,east:135.250082148022,note:'大正12年測図・昭和2.1.30発行',list:'100-16-2-1'},
    {name:'生駒山',north:34.7532084373996,west:135.625046428605,south:34.669887480404,east:135.75003834764,note:'大正11年測図・大正15.1.30発行',list:'100-8-2-1'},
    {name:'奈良',north:34.7532113603814,west:135.750035487759,south:34.6698904084955,east:135.875027431324,note:'大正11年測図・大正14.10.30発行',list:'100-4-4-1'},
    {name:'須磨',north:34.6698701475224,west:135.000104128555,south:34.5865491482705,east:135.125095925022,note:'大正12年測図・昭和2.6.30発行',list:'101-13-3-1'},
    {name:'神戸南部',north:34.6698730082114,west:135.125093131636,south:34.5865520142257,east:135.250084952381,note:'大正12年測図・大正15.11.30発行',list:'101-13-1-1'},
    {name:'大阪東南部',north:34.6698816578324,west:135.500060220911,south:34.586560679422,east:135.625052114723,note:'大正10年測図・大正14.9.30発行',list:'101-5-3-1'},
    {name:'信貴山',north:34.6698845635116,west:135.625049277519,south:34.5865635902186,east:135.750041195764,note:'大正11年測図・大正14.12.28発行',list:'101-5-1-1'},
    {name:'郡山',north:34.669887480404,west:135.75003834764,south:34.5865665121909,east:135.875030290356,note:'大正11年測図・大正14.9.30発行',list:'101-1-3-1'},
    {name:'古市',north:34.5865577798152,west:135.50006304718,south:34.5032367851139,east:135.625054940262,note:'大正11年測図・大正14.12.28発行',list:'101-5-4-1'},
    {name:'大和高田',north:34.586560679422,west:135.625052114723,south:34.5032396898082,east:135.75004403218,note:'大正11年測図・大正15.2.28発行',list:'101-5-2-1'},
    {name:'桜井',north:34.5865635902186,west:135.750041195764,south:34.503242605655,east:135.875033137634,note:'大正11年測図・大正14.11.30発行',list:'101-1-4-1'},
    {name:'富田林',north:34.5032338915858,west:135.50006586183,south:34.4199128805701,east:135.625057754185,note:'大正11年測図・大正13.6.30発行',list:'101-6-3-1'},
    {name:'新庄',north:34.5032367851139,west:135.625054940262,south:34.4199157791559,east:135.750046856934,note:'大正11年測図・大正13.6.30発行',list:'101-6-1-1'},
    {name:'畝傍山',north:34.5032396898082,west:135.75004403218,south:34.4199186888707,east:135.875035973206,note:'大正11年測図・大正13.8.30発行',list:'101-2-3-1'},
    {name:'箱作',north:34.4199013977915,west:135.125101477388,south:34.3365803551313,east:135.250093296475,note:'大正11年測図・大正13.8.25発行',list:'101-14-2-1'},
    {name:'樽井',north:34.4199042517241,west:135.250090526562,south:34.3365832142034,east:135.375082369791,note:'大正11年測図・大正14.6.30発行',list:'101-10-4-1'}
]});
dataset.age.push({
  folderName:'01', start:1927, end:1935, scale:'1/25000', mapList: [
    {name:'京都西北部',north:35.0865038312793,west:135.62503491488,south:35.0031829392375,east:135.750026837101,note:'昭和6年部修・昭和7.12.28発行',list:'100-6-2-3'},
    {name:'京都東北部',north:35.0865067785547,west:135.750023929715,south:35.0031858917418,east:135.875015876704,note:'昭和6年部修・昭和7.12.28発行',list:'100-2-4-3'},
    {name:'草津',north:35.0865097371461,west:135.875012958184,south:35.0031888555246,east:136.000004929978,note:'昭和2年部修・昭和22.10.30発行',list:'100-2-2-3'},
    {name:'京都西南部',north:35.0031799980259,west:135.625037811117,south:34.919859089781,east:135.750029732538,note:'昭和6年部修・昭和7.12.28発行',list:'100-7-1-3'},
    {name:'京都東南部',north:35.0031829392375,west:135.750026837101,south:34.9198620361918,east:135.87501878323,note:'昭和6年部修・昭和7.10.30発行',list:'100-3-3-3'},
    {name:'瀬田',north:35.0031858917418,west:135.875015876704,south:34.9198649938578,east:136.000007847578,note:'昭和2年部修・昭和4.10.30発行',list:'100-3-1-2'},
    {name:'淀',north:34.9198561546396,west:135.625040695452,south:34.836535230168,east:135.750032616075,note:'昭和6年部修・昭和7.10.30発行',list:'100-7-2-4'},
    {name:'有馬',north:34.8365206975817,west:135.125087510228,south:34.7531997359289,east:135.250079332086,note:'昭和10年二修・昭和12.5.30発行',list:'100-16-1-4'},
    {name:'宝塚',north:34.8365235815238,west:135.250076504528,south:34.7532026251595,east:135.37506835082,note:'昭和7年要修・昭和22.8.30発行',list:'100-12-3-1'},
    {name:'伊丹',north:34.8365264767672,west:135.37506551221,south:34.7532055256544,east:135.500057382976,note:'昭和4年修正・昭和7.9.30発行',list:'100-12-1-2'},
    {name:'吹田',north:34.8365293832983,west:135.500054533327,south:34.7532084373996,east:135.625046428605,note:'昭和4年修正・昭和7.11.30発行',list:'100-8-3-3'},
    {name:'枚方',north:34.8365323011032,west:135.625043567931,south:34.7532113603814,east:135.750035487759,note:'昭和4年修正・昭和22.8.30発行',list:'100-8-1-3'},
    {name:'前開',north:34.753193991315,west:135.000101334672,south:34.6698730082114,east:135.125093131636,note:'昭和10年二修・昭和12.4.30発行',list:'100-16-4-2'},
    {name:'神戸首部',north:34.7531968579761,west:135.125090326721,south:34.6698758801685,east:135.250082148022,note:'昭和10年二修・昭和14.3.30発行',list:'100-16-2-4'},
    {name:'西宮',north:34.7531997359289,west:135.250079332086,south:34.6698787633801,east:135.375071177762,note:'昭和4年修正・昭和7.1.30発行',list:'100-12-4-14'},
    {name:'大阪西北部',north:34.7532026251595,west:135.37506835082,south:34.6698816578324,east:135.500060220911,note:'昭和7年部修・昭和9.10.30発行',list:'100-12-2-1',war:true},
    {name:'大阪東北部',north:34.7532055256544,west:135.500057382976,south:34.6698845635116,east:135.625049277519,note:'昭和4年修正・昭和7.10.30発行',list:'100-8-4-3'},
    {name:'生駒山',north:34.7532084373996,west:135.625046428605,south:34.669887480404,east:135.75003834764,note:'昭和4年修正・昭和22.8.30発行',list:'100-8-2-4'},
    {name:'須磨',north:34.6698701475224,west:135.000104128555,south:34.5865491482705,east:135.125095925022,note:'昭和9年二修・昭和11.1.30発行',list:'101-13-3-3'},
    {name:'神戸南部',north:34.6698730082114,west:135.125093131636,south:34.5865520142257,east:135.250084952381,note:'昭和7年修正・昭和11.3.30発行',list:'101-13-1-3'},
    {name:'大阪西南部',north:34.6698787633801,west:135.375071177762,south:34.5865577798152,east:135.50006304718,note:'昭和7年部修・昭和22.8.30発行',list:'101-9-1-1'},
    {name:'大阪東南部',north:34.6698816578324,west:135.500060220911,south:34.586560679422,east:135.625052114723,note:'昭和7年部修・昭和22.8.30発行',list:'101-5-3-5'},
    {name:'堺',north:34.5865548914118,west:135.375073993083,south:34.5032338915858,east:135.50006586183,note:'昭和4年修正・昭和22.8.30発行',list:'101-9-2-1'},
    {name:'古市',north:34.5865577798152,west:135.50006304718,south:34.5032367851139,east:135.625054940262,note:'昭和4年修正・昭和7.9.30発行',list:'101-5-4-3'},
    {name:'岸和田',north:34.5032281380832,west:135.250087745213,south:34.4199071168405,east:135.375079589051,note:'昭和9年二修・昭和22.8.30発行',list:'101-10-3-1'},
    {name:'岸和田東部',north:34.5032310092376,west:135.375076796831,south:34.4199099931271,east:135.500068664908,note:'昭和9年二修・昭和22.8.30発行',list:'101-10-1-1'},
    {name:'富田林',north:34.5032338915858,west:135.50006586183,south:34.4199128805701,east:135.625057754185,note:'昭和7年二修・昭和10.12.28発行',list:'101-6-3-2'},
    {name:'御所',north:34.5032367851139,west:135.625054940262,south:34.4199157791559,east:135.750046856934,note:'昭和6年修正・昭和10.11.30発行',list:'101-6-1-2'},
    {name:'箱作',north:34.4199013977915,west:135.125101477388,south:34.3365803551313,east:135.250093296475,note:'昭和9年二修・昭和11.7.25発行',list:'101-14-2-3'},
    {name:'樽井',north:34.4199042517241,west:135.250090526562,south:34.3365832142034,east:135.375082369791,note:'昭和9年二修・昭和22.8.30発行',list:'101-10-4-3'},
    {name:'内畑',north:34.4199071168405,west:135.375079589051,south:34.3365860844221,east:135.500071456461,note:'昭和9年二修・昭和22.8.30発行',list:'101-10-2-1'}
]});
dataset.age.push({
  folderName:'02', start:1947, end:1950, scale:'1/25000', mapList: [
    {name:'三田',north:34.9198445270454,west:135.125084682112,south:34.8365235815238,east:135.250076504528,note:'大正12年測図昭和25年資修・昭和25.3.30発行',list:'100-15-2-1'},
    {name:'有馬',north:34.8365206975817,west:135.125087510228,south:34.7531997359289,east:135.250079332086,note:'昭和22年三修・昭和24.4.30発行',list:'100-16-1-6'},
    {name:'宝塚',north:34.8365235815238,west:135.250076504528,south:34.7532026251595,east:135.37506835082,note:'昭和22年三修・昭和23.12.28発行',list:'100-12-3-2'},
    {name:'枚方',north:34.8365323011032,west:135.625043567931,south:34.7532113603814,east:135.750035487759,note:'昭和22年二修・昭和24.5.30発行',list:'100-8-1-4'},
    {name:'前開',north:34.753193991315,west:135.000101334672,south:34.6698730082114,east:135.125093131636,note:'昭和22年三修・昭和24.11.30発行',list:'100-16-4-4'},
    {name:'神戸首部',north:34.7531968579761,west:135.125090326721,south:34.6698758801685,east:135.250082148022,note:'昭和22年三修・昭和24.11.30発行',list:'100-16-2-6'},
    {name:'西宮',north:34.7531997359289,west:135.250079332086,south:34.6698787633801,east:135.375071177762,note:'昭和22年二修・昭和24.2.28発行',list:'100-12-4-3'},
    {name:'大阪東北部',north:34.7532055256544,west:135.500057382976,south:34.6698845635116,east:135.625049277519,note:'昭和22年三修・昭和23.11.30発行',list:'100-8-4-6'},
    {name:'生駒山',north:34.7532084373996,west:135.625046428605,south:34.669887480404,east:135.75003834764,note:'昭和22年二修・昭和24.6.30発行',list:'100-8-2-5'},
    {name:'神戸南部',north:34.6698730082114,west:135.125093131636,south:34.5865520142257,east:135.250084952381,note:'昭和22年三修・昭和24.1.30発行',list:'101-13-1-5'},
    {name:'大阪西南部',north:34.6698787633801,west:135.375071177762,south:34.5865577798152,east:135.50006304718,note:'昭和22年三修・昭和24.2.28発行',list:'101-9-1-2'},
    {name:'大阪東南部',north:34.6698816578324,west:135.500060220911,south:34.586560679422,east:135.625052114723,note:'昭和22年三修・昭和26.11.30発行',list:'101-5-3-6'},
    {name:'信貴山',north:34.6698845635116,west:135.625049277519,south:34.5865635902186,east:135.750041195764,note:'昭和22年二修・昭和26.4.30発行',list:'101-5-1-5'},
    {name:'堺',north:34.5865548914118,west:135.375073993083,south:34.5032338915858,east:135.50006586183,note:'昭和22年二修・昭和24.4.30発行',list:'101-9-2-2'},
    {name:'大和高田',north:34.586560679422,west:135.625052114723,south:34.5032396898082,east:135.75004403218,note:'昭和22年二修・昭和26.3.30発行',list:'101-5-2-4'},
    {name:'岸和田西部',north:34.5032281380832,west:135.250087745213,south:34.4199071168405,east:135.375079589051,note:'昭和22年三修・昭和24.5.30発行',list:'101-10-3-2'},
    {name:'岸和田東部',north:34.5032310092376,west:135.375076796831,south:34.4199099931271,east:135.500068664908,note:'昭和22年三修・昭和24.1.30発行',list:'101-10-1-2'},
    {name:'樽井',north:34.4199042517241,west:135.250090526562,south:34.3365832142034,east:135.375082369791,note:'昭和22年三修・昭和24.2.28発行',list:'101-10-4-5'},
    {name:'内畑',north:34.4199071168405,west:135.375079589051,south:34.3365860844221,east:135.500071456461,note:'昭和22年三修・昭和23.12.28発行',list:'101-10-2-2'}
]});
dataset.age.push({
  folderName:'03', start:1954, end:1956, scale:'1/25000', mapList: [
    {name:'草津',north:35.0865097371461,west:135.875012958184,south:35.0031888555246,east:136.000004929978,note:'昭和29年修正・昭和31.11.30発行',list:''},
    {name:'瀬田',north:35.0031858917418,west:135.875015876704,south:34.9198649938578,east:136.000007847578,note:'昭和29年修正・昭和31.11.30発行',list:''},
    {name:'武田尾',north:34.9198474169705,west:135.2500736653,south:34.8365264767672,east:135.37506551221,note:'大正12年測図昭和30年資修・昭和30.8.30発行',list:''},
    {name:'大阪東北部',north:34.7532055256544,west:135.500057382976,south:34.6698845635116,east:135.625049277519,note:'昭和22年三修32年資修・昭和32.4.30発行',list:''},
    {name:'大阪西北部',north:34.7532026251595,west:135.37506835082,south:34.6698816578324,east:135.500060220911,note:'昭和22年三修30年資修・昭和30.4.30発行',list:''},
    {name:'須磨',north:34.6698701475224,west:135.000104128555,south:34.5865491482705,east:135.125095925022,note:'昭和22年三修31年資修・昭和31.12.28発行',list:''},
    {name:'大阪西南部',north:34.6698787633801,west:135.375071177762,south:34.5865577798152,east:135.50006304718,note:'昭和22年三修昭和29年資修・昭和30.1.30発行',list:''},
    {name:'大阪東南部',north:34.6698816578324,west:135.500060220911,south:34.586560679422,east:135.625052114723,note:'昭和22年三修昭和32年資修・昭和32.8.30発行',list:''},
    {name:'堺',north:34.5865548914118,west:135.375073993083,south:34.5032338915858,east:135.50006586183,note:'昭和22年二修29年資修・昭和29.3.30発行',list:''},
    {name:'古市',north:34.5865577798152,west:135.50006304718,south:34.5032367851139,east:135.625054940262,note:'昭和22年二修31年資修・昭和31.12.28発行',list:''},
    {name:'尾崎',north:34.4199013977915,west:135.125101477388,south:34.3365803551313,east:135.250093296475,note:'昭和22年三修32年資修・昭和32.5.30発行',list:''}
]});
dataset.age.push({
  folderName:'03x', start:1961, end:1964, scale:'1/25000', mapList: [
    {name:'亀岡',north:35.086500827615,west:135.497157279088,south:35.0031799301848,east:135.622149176011,note:'昭和36年修正・昭和40.4.30発行',list:''},
    {name:'京都西北部',north:35.0865037632984,west:135.622146280031,south:35.0031828711353,east:135.747138201681,note:'昭和36年修正・昭和40.4.30発行',list:''},
    {name:'京都東北部',north:35.0865067103121,west:135.747135294552,south:35.0031858233787,east:135.872127240968,note:'昭和36年修正・昭和40.4.30発行',list:''},
    {name:'法貴',north:35.0031770005413,west:135.497160163906,south:34.9198560869385,east:135.622152060088,note:'昭和36年修正・昭和40.4.30発行',list:''},
    {name:'京都西南部',north:35.0031799301848,west:135.622149176011,south:34.9198590218194,east:135.747141096861,note:'昭和39年修正・昭和40.4.30発行',list:''},
    {name:'京都東南部',north:35.0031828711353,west:135.747138201681,south:34.9198619679698,east:135.872130147237,note:'昭和39年修正・昭和40.4.30発行',list:''},
    {name:'広根',north:34.9198502510416,west:135.372174027146,south:34.8365293159979,east:135.497165898021,note:'昭和36年修正・昭和40.4.30発行',list:''},
    {name:'淀',north:34.9198560869385,west:135.622152060088,south:34.8365351623471,east:135.747143980142,note:'昭和39年修正・昭和40.4.30発行',list:''},
    {name:'宇治',north:34.9198590218194,west:135.747141096861,south:34.8365381023981,east:135.872133041562,note:'和36年修正・昭和40.4.30発行',list:''}
]});
dataset.age.push({
  folderName:'04', start:1967, end:1970, scale:'1/25000', mapList: [
    {name:'亀岡',north:35.086500827615,west:135.497157279088,south:35.0031799301848,east:135.622149176011,note:'昭和45年修正・昭和47.5.30発行',list:'100-6-4-6'},
    {name:'京都西北部',north:35.0865037632984,west:135.622146280031,south:35.0031828711353,east:135.747138201681,note:'昭和42年改測・昭和45.5.30発行',list:'100-6-2-8'},
    {name:'京都東北部',north:35.0865067103121,west:135.747135294552,south:35.0031858233787,east:135.872127240968,note:'昭和42年改測・昭和46.1.30発行',list:'100-2-4-7'},
    {name:'草津',north:35.0865096686421,west:135.872124322705,south:35.0031887869011,east:135.997116293925,note:'昭和42年改測・昭和46.1.30発行',list:'100-2-2-6'},
    {name:'法貴',north:35.0031770005413,west:135.497160163906,south:34.9198560869385,east:135.622152060088,note:'昭和43年改測・昭和45.9.30発行',list:'100-7-3-5'},
    {name:'京都西南部',north:35.0031799301848,west:135.622149176011,south:34.9198590218194,east:135.747141096861,note:'昭和45年修正・昭和47.4.30発行',list:'100-7-1-8'},
    {name:'京都東南部',north:35.0031828711353,west:135.747138201681,south:34.9198619679698,east:135.872130147237,note:'昭和45年修正・昭和47.4.30発行',list:'100-3-3-8'},
    {name:'瀬田',north:35.0031858233787,west:135.872127240968,south:34.9198649253759,east:135.99711921127,note:'昭和42年改測・昭和45.7.30発行',list:'100-3-1-5'},
    {name:'三田',north:34.9198444603901,west:135.122196047991,south:34.836523514745,east:135.247187869842,note:'昭和42年改測・昭和44.7.30発行',list:'100-15-2-5'},
    {name:'武田尾',north:34.9198473500533,west:135.247185030871,south:34.8365264097275,east:135.372176877215,note:'昭和42年改測・昭和44.8.30発行',list:'100-11-4-4'},
    {name:'広根',north:34.9198502510416,west:135.372174027146,south:34.8365293159979,east:135.497165898021,note:'昭和42年改測・昭和44.8.30発行',list:'100-11-2-6'},
    {name:'高槻',north:34.9198531633413,west:135.497163036867,south:34.8365322335424,east:135.622154932312,note:'昭和42年改測・昭和45.3.30発行',list:'100-7-4-7'},
    {name:'淀',north:34.9198560869385,west:135.622152060088,south:34.8365351623471,east:135.747143980142,note:'昭和45年修正・昭和46.8.30発行',list:'100-7-2-11'},
    {name:'宇治',north:34.9198590218194,west:135.747141096861,south:34.8365381023981,east:135.872133041562,note:'昭和42年改測・昭和45.3.30発行',list:'100-3-4-7'},
    {name:'有馬',north:34.8365206310643,west:135.122198875851,south:34.7531996692888,east:135.247190697145,note:'昭和42年改測・昭和44.8.30発行',list:'100-16-1-9'},
    {name:'宝塚',north:34.836523514745,west:135.247187869842,south:34.753202558259,east:135.372179715569,note:'昭和42年改測・昭和44.3.30発行',list:'100-12-3-5'},
    {name:'伊丹',north:34.8365264097275,west:135.372176877215,south:34.7532054584937,east:135.497168747414,note:'昭和42年修正・昭和44.3.30発行',list:'100-12-1-6'},
    {name:'吹田',north:34.8365293159979,west:135.497165898021,south:34.7532083699791,east:135.622157792731,note:'昭和42年改測・昭和44.2.28発行',list:'100-8-3-9'},
    {name:'枚方',north:34.8365322335424,west:135.622154932312,south:34.7532112927013,east:135.747146851572,note:'昭和45年修正・昭和47.4.30発行',list:'100-8-1-9'},
    {name:'田辺',north:34.8365351623471,west:135.747143980142,south:34.7532142266465,east:135.87213592399,note:'昭和42年改測・昭和43.11.30発行',list:'100-4-3-5'},
    {name:'前開',north:34.7531939251968,west:134.997212700346,south:34.6698729419705,east:135.122204496749,note:'昭和42年改測・昭和44.8.30発行',list:'100-16-4-5'},
    {name:'神戸首部',north:34.7531967915969,west:135.122201692088,south:34.6698758136673,east:135.247193512826,note:'昭和42年改測・昭和44.8.30発行',list:'100-16-2-7'},
    {name:'西宮',north:34.7531996692888,west:135.247190697145,south:34.6698786966189,east:135.372182542257,note:'昭和42年改測・昭和44.3.30発行',list:'100-12-4-7'},
    {name:'大阪西北部',north:34.753202558259,west:135.372179715569,south:34.6698815908116,east:135.497171585095,note:'昭和42年改測・昭和44.3.30発行',list:'100-12-2-5'},
    {name:'大阪東北部',north:34.7532054584937,west:135.497168747414,south:34.6698844962315,east:135.622160641392,note:'昭和42年改測・昭和44.3.30発行',list:'100-8-4-9'},
    {name:'生駒山',north:34.7532083699791,west:135.622157792731,south:34.6698874128649,east:135.747149711199,note:'昭和42年改測・昭和44.3.30発行',list:'100-8-2-8'},
    {name:'奈良',north:34.7532112927013,west:135.747146851572,south:34.6698903406978,east:135.87213879457,note:'昭和42年改測・昭和44.2.28発行',list:'100-4-4-8'},
    {name:'須磨',north:34.669870081542,west:134.997215493974,south:34.586549082168,east:135.12220728988,note:'昭和42年改測・昭和44.8.30発行',list:'101-13-3-5'},
    {name:'神戸南部',north:34.6698729419705,west:135.122204496749,south:34.5865519478635,east:135.247196316932,note:'昭和45年修正・昭和47.10.30発行',list:'101-13-1-7'},
    {name:'大阪西南部',north:34.6698786966189,west:135.372182542257,south:34.5865577129345,east:135.497174411111,note:'昭和42年改測・昭和44.3.30発行',list:'101-9-1-4'},
    {name:'大阪東南部',north:34.6698815908116,west:135.497171585095,south:34.5865606122825,east:135.622163478343,note:'昭和42年改測・昭和44.3.30発行',list:'101-5-3-9'},
    {name:'信貴山',north:34.6698844962315,west:135.622160641392,south:34.5865635228206,east:135.747152559072,note:'昭和42年改測・昭和44.3.30発行',list:'101-5-1-8'},
    {name:'郡山',north:34.6698874128649,west:135.747149711199,south:34.5865664445349,east:135.87214165335,note:'昭和42年改測・昭和44.2.28発行',list:'101-1-3-5'},
    {name:'堺',north:34.5865548247902,west:135.372185357325,south:34.5032338248452,east:135.49717722551,note:'昭和42年改測・昭和44.3.30発行',list:'101-9-2-5'},
    {name:'古市',north:34.5865577129345,west:135.497174411111,south:34.5032367181151,east:135.622166303631,note:'昭和42年改測・昭和44.3.30発行',list:'101-5-4-8'},
    {name:'大和高田',north:34.5865606122825,west:135.622163478343,south:34.5032396225516,east:135.747155395236,note:'昭和42年改測・昭和44.1.30発行',list:'101-5-2-6'},
    {name:'桜井',north:34.5865635228206,west:135.747152559072,south:34.5032425381407,east:135.872144500377,note:'昭和42年改測・昭和44.2.28発行',list:'101-1-4-7'},
    {name:'岸和田西部',north:34.5032280718601,west:135.247199109511,south:34.4199070504983,east:135.37219095279,note:'昭和42年改測・昭和44.3.30発行',list:'101-10-3-3'},
    {name:'岸和田東部',north:34.5032309427557,west:135.37218816082,south:34.4199099265269,east:135.497180028337,note:'昭和42年改測・昭和44.3.30発行',list:'101-10-1-3'},
    {name:'富田林',north:34.5032338248452,west:135.49717722551,south:34.4199128137123,east:135.622169117304,note:'昭和42年改測・昭和44.3.30発行',list:'101-6-3-6'},
    {name:'御所',north:34.5032367181151,west:135.622166303631,south:34.4199157120407,east:135.74715821974,note:'昭和42年改測・昭和44.3.30発行',list:'101-6-1-5'},
    {name:'畝傍山',north:34.5032396225516,west:135.747155395236,south:34.4199186214984,east:135.872147335699,note:'昭和42年修正・昭和44.1.30発行',list:'101-2-3-6'},
    {name:'尾崎',north:34.4199013319663,west:135.122212841742,south:34.3365802891868,east:135.247204660271,note:'昭和42年改測・昭和44.3.30発行',list:''},
    {name:'樽井',north:34.4199041856403,west:135.247201890608,south:34.3365831480012,east:135.372193733279,note:'昭和42年改測・昭和44.2.28発行',list:'101-10-4-7'},
    {name:'内畑',north:34.4199070504983,west:135.37219095279,south:34.3365860179624,east:135.49718281964,note:'昭和42年改測・昭和44.1.30発行',list:'101-10-2-4'}
]});
dataset.age.push({
  folderName:'05', start:1975, end:1979, scale:'1/25000', mapList: [
    {name:'亀岡',north:35.086500827615,west:135.497157279088,south:35.0031799301848,east:135.622149176011,note:'昭和54年二改・昭和56.8.30発行',list:'100-6-4-8'},
    {name:'京都西北部',north:35.0865037632984,west:135.622146280031,south:35.0031828711353,east:135.747138201681,note:'昭和54年二改・昭和56.6.30発行',list:'100-6-2-10'},
    {name:'京都東北部',north:35.0865067103121,west:135.747135294552,south:35.0031858233787,east:135.872127240968,note:'昭和54年二改・昭和55.10.30発行',list:'100-2-4-11'},
    {name:'草津',north:35.0865096686421,west:135.872124322705,south:35.0031887869011,east:135.997116293925,note:'昭和54年二改・昭和56.7.30発行',list:'100-2-2-9'},
    {name:'法貴',north:35.0031770005413,west:135.497160163906,south:34.9198560869385,east:135.622152060088,note:'昭和54年二改・昭和56.4.30発行',list:'100-7-3-7'},
    {name:'京都西南部',north:35.0031799301848,west:135.622149176011,south:34.9198590218194,east:135.747141096861,note:'昭和54年二改・昭和56.2.28発行',list:'100-7-1-10'},
    {name:'京都東南部',north:35.0031828711353,west:135.747138201681,south:34.9198619679698,east:135.872130147237,note:'昭和54年二改・昭和56.9.30発行',list:'100-3-3-11'},
    {name:'瀬田',north:35.0031858233787,west:135.872127240968,south:34.9198649253759,east:135.99711921127,note:'昭和54年二改・昭和56.4.30発行',list:'100-3-1-9'},
    {name:'三田',north:34.9198444603901,west:135.122196047991,south:34.836523514745,east:135.247187869842,note:'昭和53年修正・昭和55.4.30発行',list:'100-15-2-7'},
    {name:'武田尾',north:34.9198473500533,west:135.247185030871,south:34.8365264097275,east:135.372176877215,note:'昭和53年修正・昭和54.11.30発行',list:'100-11-4-6'},
    {name:'広根',north:34.9198502510416,west:135.372174027146,south:34.8365293159979,east:135.497165898021,note:'昭和53年修正・昭和54.10.30発行',list:'100-11-2-8'},
    {name:'高槻',north:34.9198531633413,west:135.497163036867,south:34.8365322335424,east:135.622154932312,note:'昭和54年二改・昭和56.7.30発行',list:'100-7-4-11'},
    {name:'淀',north:34.9198560869385,west:135.622152060088,south:34.8365351623471,east:135.747143980142,note:'昭和54年二改・昭和56.6.30発行',list:'100-7-2-13'},
    {name:'宇治',north:34.9198590218194,west:135.747141096861,south:34.8365381023981,east:135.872133041562,note:'昭和50年修正・昭和51.9.30発行',list:'100-3-4-10'},
    {name:'有馬',north:34.8365206310643,west:135.122198875851,south:34.7531996692888,east:135.247190697145,note:'昭和52年二改・昭和53.12.28発行',list:'100-16-1-12'},
    {name:'宝塚',north:34.836523514745,west:135.247187869842,south:34.753202558259,east:135.372179715569,note:'昭和52年二改・昭和53.10.30発行',list:'100-12-3-9'},
    {name:'伊丹',north:34.8365264097275,west:135.372176877215,south:34.7532054584937,east:135.497168747414,note:'昭和52年二改・昭和53.11.30発行',list:'100-12-1-11'},
    {name:'吹田',north:34.8365293159979,west:135.497165898021,south:34.7532083699791,east:135.622157792731,note:'昭和53年二改・昭和55.1.30発行',list:'100-8-3-14'},
    {name:'枚方',north:34.8365322335424,west:135.622154932312,south:34.7532112927013,east:135.747146851572,note:'昭和53年二改・昭和54.12.28発行',list:'100-8-1-12'},
    {name:'田辺',north:34.8365351623471,west:135.747143980142,south:34.7532142266465,east:135.87213592399,note:'昭和50年修正・昭和51.9.30発行',list:'100-4-3-7'},
    {name:'前開',north:34.7531939251968,west:134.997212700346,south:34.6698729419705,east:135.122204496749,note:'昭和52年二改・昭和55.2.28発行',list:'100-16-4-8'},
    {name:'神戸首部',north:34.7531967915969,west:135.122201692088,south:34.6698758136673,east:135.247193512826,note:'昭和52年二改・昭和54.9.30発行',list:'100-16-2-10'},
    {name:'西宮',north:34.7531996692888,west:135.247190697145,south:34.6698786966189,east:135.372182542257,note:'昭和52年二改・昭和53.11.30発行',list:'100-12-4-11'},
    {name:'大阪西北部',north:34.753202558259,west:135.372179715569,south:34.6698815908116,east:135.497171585095,note:'昭和52年二改・昭和53.12.28発行',list:'100-12-2-10'},
    {name:'大阪東北部',north:34.7532054584937,west:135.497168747414,south:34.6698844962315,east:135.622160641392,note:'昭和53年二改・昭和55.1.30発行',list:'100-8-4-14'},
    {name:'生駒山',north:34.7532083699791,west:135.622157792731,south:34.6698874128649,east:135.747149711199,note:'昭和53年二改・昭和55.6.30発行',list:'100-8-2-12'},
    {name:'奈良',north:34.7532112927013,west:135.747146851572,south:34.6698903406978,east:135.87213879457,note:'昭和50年修正・昭和51.11.30発行',list:'100-4-4-11'},
    {name:'須磨',north:34.669870081542,west:134.997215493974,south:34.586549082168,east:135.12220728988,note:'昭和52年二改・昭和53.11.30発行',list:'101-13-3-9'},
    {name:'神戸南部',north:34.6698729419705,west:135.122204496749,south:34.5865519478635,east:135.247196316932,note:'昭和52年二改・昭和53.11.30発行',list:'101-13-1-9'},
    {name:'大阪西南部',north:34.6698786966189,west:135.372182542257,south:34.5865577129345,east:135.497174411111,note:'昭和52年二改・昭和53.12.28発行',list:'101-9-1-8'},
    {name:'大阪東南部',north:34.6698815908116,west:135.497171585095,south:34.5865606122825,east:135.622163478343,note:'昭和53年二改・昭和55.6.30発行',list:''},
    {name:'信貴山',north:34.6698844962315,west:135.622160641392,south:34.5865635228206,east:135.747152559072,note:'昭和53年二改・昭和55.9.30発行',list:'101-5-1-12'},
    {name:'大和郡山',north:34.6698874128649,west:135.747149711199,south:34.5865664445349,east:135.87214165335,note:'昭和50年修正・昭和52.5.30発行',list:'101-1-3-8'},
    {name:'堺',north:34.5865548247902,west:135.372185357325,south:34.5032338248452,east:135.49717722551,note:'昭和52年二改・昭和53.11.30発行',list:'101-9-2-9'},
    {name:'古市',north:34.5865577129345,west:135.497174411111,south:34.5032367181151,east:135.622166303631,note:'昭和53年二改・昭和55.3.30発行',list:'101-5-4-13'},
    {name:'大和高田',north:34.5865606122825,west:135.622163478343,south:34.5032396225516,east:135.747155395236,note:'昭和53年二改・昭和55.7.30発行',list:'101-5-2-10'},
    {name:'桜井',north:34.5865635228206,west:135.747152559072,south:34.5032425381407,east:135.872144500377,note:'昭和50年修正・昭和52.6.30発行',list:'101-1-4-10'},
    {name:'岸和田西部',north:34.5032280718601,west:135.247199109511,south:34.4199070504983,east:135.37219095279,note:'昭和52年修正・昭和54.10.30発行',list:'101-10-3-4'},
    {name:'岸和田東部',north:34.5032309427557,west:135.37218816082,south:34.4199099265269,east:135.497180028337,note:'昭和52年修正・昭和54.1.30発行',list:'101-10-1-6'},
    {name:'富田林',north:34.5032338248452,west:135.49717722551,south:34.4199128137123,east:135.622169117304,note:'昭和52年修正・昭和53.8.30発行',list:'101-6-3-9'},
    {name:'御所',north:34.5032367181151,west:135.622166303631,south:34.4199157120407,east:135.74715821974,note:'昭和52年修正・昭和54.1.30発行',list:'101-6-1-7'},
    {name:'畝傍山',north:34.5032396225516,west:135.747155395236,south:34.4199186214984,east:135.872147335699,note:'昭和52年修正・昭和53.8.30発行',list:'101-2-3-8'},
    {name:'尾崎',north:34.4199013319663,west:135.122212841742,south:34.3365802891868,east:135.247204660271,note:'昭和56年修正・昭和53.8.30発行',list:''},
    {name:'樽井',north:34.4199041856403,west:135.247201890608,south:34.3365831480012,east:135.372193733279,note:'昭和52年修正・昭和54.1.30発行',list:'101-10-4-9'},
    {name:'内畑',north:34.4199070504983,west:135.37219095279,south:34.3365860179624,east:135.49718281964,note:'昭和52年修正・昭和53.8.30発行',list:'101-10-2-6'}
]});
dataset.age.push({
  folderName:'06', start:1983, end:1988, scale:'1/25000', mapList: [
    {name:'亀岡',north:35.086500827615,west:135.497157279088,south:35.0031799301848,east:135.622149176011,note:'昭和61年修正・昭和63.3.30発行',list:'100-6-4-10'},
    {name:'京都西北部',north:35.0865037632984,west:135.622146280031,south:35.0031828711353,east:135.747138201681,note:'昭和61年修正・昭和62.7.30発行',list:'100-6-2-12'},
    {name:'京都東北部',north:35.0865067103121,west:135.747135294552,south:35.0031858233787,east:135.872127240968,note:'昭和61年修正・昭和62.7.30発行',list:'100-2-4-13'},
    {name:'草津',north:35.0865096686421,west:135.872124322705,south:35.0031887869011,east:135.997116293925,note:'昭和61年修正・昭和63.3.30発行',list:'100-2-2-11'},
    {name:'法貴',north:35.0031770005413,west:135.497160163906,south:34.9198560869385,east:135.622152060088,note:'昭和61年修正・昭和63.3.30発行',list:'100-7-3-9'},
    {name:'京都西南部',north:35.0031799301848,west:135.622149176011,south:34.9198590218194,east:135.747141096861,note:'昭和61年修正・昭和62.4.30発行',list:'100-7-1-12'},
    {name:'京都東南部',north:35.0031828711353,west:135.747138201681,south:34.9198619679698,east:135.872130147237,note:'昭和61年修正・昭和62.7.30発行',list:'100-3-3-13'},
    {name:'瀬田',north:35.0031858233787,west:135.872127240968,south:34.9198649253759,east:135.99711921127,note:'昭和61年修正・昭和62.9.30発行',list:'100-3-1-12'},
    {name:'三田',north:34.9198444603901,west:135.122196047991,south:34.836523514745,east:135.247187869842,note:'昭和62年修正・昭和63.9.30発行',list:'100-15-2-9'},
    {name:'武田尾',north:34.9198473500533,west:135.247185030871,south:34.8365264097275,east:135.372176877215,note:'昭和62年修正・昭和63.8.30発行',list:'100-11-4-8'},
    {name:'広根',north:34.9198502510416,west:135.372174027146,south:34.8365293159979,east:135.497165898021,note:'昭和62年修正・昭和63.6.30発行',list:'100-11-2-10'},
    {name:'高槻',north:34.9198531633413,west:135.497163036867,south:34.8365322335424,east:135.622154932312,note:'昭和61年修正・昭和63.1.30発行',list:'100-7-4-13'},
    {name:'淀',north:34.9198560869385,west:135.622152060088,south:34.8365351623471,east:135.747143980142,note:'昭和61年修正・昭和62.1.30発行',list:'100-7-2-15'},
    {name:'宇治',north:34.9198590218194,west:135.747141096861,south:34.8365381023981,east:135.872133041562,note:'昭和61年修正・昭和62.10.30発行',list:'100-3-4-13'},
    {name:'有馬',north:34.8365206310643,west:135.122198875851,south:34.7531996692888,east:135.247190697145,note:'昭和60年修正・昭和62.1.30発行',list:'100-16-1-14'},
    {name:'宝塚',north:34.836523514745,west:135.247187869842,south:34.753202558259,east:135.372179715569,note:'昭和60年修正・昭和61.11.30発行',list:'100-12-3-13'},
    {name:'伊丹',north:34.8365264097275,west:135.372176877215,south:34.7532054584937,east:135.497168747414,note:'昭和60年修正・昭和61.4.30発行',list:'100-12-1-13'},
    {name:'吹田',north:34.8365293159979,west:135.497165898021,south:34.7532083699791,east:135.622157792731,note:'昭和60年修正・昭和61.7.30発行',list:'100-8-3-16'},
    {name:'枚方',north:34.8365322335424,west:135.622154932312,south:34.7532112927013,east:135.747146851572,note:'昭和60年修正・昭和61.10.30発行',list:'100-8-1-14'},
    {name:'田辺',north:34.8365351623471,west:135.747143980142,south:34.7532142266465,east:135.87213592399,note:'昭和58年修正・昭和60.1.30発行',list:'100-4-3-8'},
    {name:'前開',north:34.7531939251968,west:134.997212700346,south:34.6698729419705,east:135.122204496749,note:'昭和60年修正・昭和62.1.30発行',list:'100-16-4-10'},
    {name:'神戸首部',north:34.7531967915969,west:135.122201692088,south:34.6698758136673,east:135.247193512826,note:'昭和60年修正・昭和62.1.30発行',list:'100-16-2-12'},
    {name:'西宮',north:34.7531996692888,west:135.247190697145,south:34.6698786966189,east:135.372182542257,note:'昭和60年修正・昭和61.4.30発行',list:'100-12-4-13'},
    {name:'大阪西北部',north:34.753202558259,west:135.372179715569,south:34.6698815908116,east:135.497171585095,note:'昭和60年修正・昭和61.9.30発行',list:'100-12-2-12'},
    {name:'大阪東北部',north:34.7532054584937,west:135.497168747414,south:34.6698844962315,east:135.622160641392,note:'昭和60年修正・昭和61.7.30発行',list:'100-8-4-16'},
    {name:'生駒山',north:34.7532083699791,west:135.622157792731,south:34.6698874128649,east:135.747149711199,note:'昭和60年修正・昭和61.6.30発行',list:'100-8-2-14'},
    {name:'奈良',north:34.7532112927013,west:135.747146851572,south:34.6698903406978,east:135.87213879457,note:'昭和58年二改・昭和59.5.30発行',list:'100-4-4-12'},
    {name:'須磨',north:34.669870081542,west:134.997215493974,south:34.586549082168,east:135.12220728988,note:'昭和60年修正・昭和62.3.30発行',list:'101-13-3-12'},
    {name:'神戸南部',north:34.6698729419705,west:135.122204496749,south:34.5865519478635,east:135.247196316932,note:'昭和60年修正・昭和62.1.30発行',list:'101-13-1-11'},
    {name:'大阪西南部',north:34.6698786966189,west:135.372182542257,south:34.5865577129345,east:135.497174411111,note:'昭和62年修正・昭和63.7.30発行',list:'101-9-1-13'},
    {name:'大阪東南部',north:34.6698815908116,west:135.497171585095,south:34.5865606122825,east:135.622163478343,note:'昭和62年修正・昭和63.7.30発行',list:'101-5-3-16'},
    {name:'信貴山',north:34.6698844962315,west:135.622160641392,south:34.5865635228206,east:135.747152559072,note:'昭和62年修正・昭和63.5.30発行',list:'101-5-1-14'},
    {name:'大和郡山',north:34.6698874128649,west:135.747149711199,south:34.5865664445349,east:135.87214165335,note:'昭和58年二改・昭和59.6.30発行',list:'101-1-3-9'},
    {name:'堺',north:34.5865548247902,west:135.372185357325,south:34.5032338248452,east:135.49717722551,note:'昭和62年修正・昭和63.10.30発行',list:'101-9-2-13'},
    {name:'古市',north:34.5865577129345,west:135.497174411111,south:34.5032367181151,east:135.622166303631,note:'昭和62年修正・昭和63.7.30発行',list:'101-5-4-15'},
    {name:'大和高田',north:34.5865606122825,west:135.622163478343,south:34.5032396225516,east:135.747155395236,note:'昭和62年修正・昭和63.6.30発行',list:'101-5-2-12'},
    {name:'桜井',north:34.5865635228206,west:135.747152559072,south:34.5032425381407,east:135.872144500377,note:'昭和58年二改・昭和59.6.30発行',list:'101-1-4-11'},
    {name:'岸和田西部',north:34.5032280718601,west:135.247199109511,south:34.4199070504983,east:135.37219095279,note:'昭和59年修正・昭和61.8.30発行',list:'101-10-3-7'},
    {name:'岸和田東部',north:34.5032309427557,west:135.37218816082,south:34.4199099265269,east:135.497180028337,note:'昭和59年修正・昭和61.6.30発行',list:'101-10-1-8'},
    {name:'富田林',north:34.5032338248452,west:135.49717722551,south:34.4199128137123,east:135.622169117304,note:'昭和59年修正・昭和62.1.30発行',list:'101-6-3-10'},
    {name:'御所',north:34.5032367181151,west:135.622166303631,south:34.4199157120407,east:135.74715821974,note:'昭和59年修正・昭和61.12.28発行',list:'101-6-1-8'},
    {name:'畝傍山',north:34.5032396225516,west:135.747155395236,south:34.4199186214984,east:135.872147335699,note:'昭和59年修正・昭和61.10.30発行',list:'101-2-3-9'},
    {name:'尾崎',north:34.4199013319663,west:135.122212841742,south:34.3365802891868,east:135.247204660271,note:'昭和59年修正・昭和61.5.30発行',list:''},
    {name:'樽井',north:34.4199041856403,west:135.247201890608,south:34.3365831480012,east:135.372193733279,note:'昭和59年修正・昭和61.8.30発行',list:'101-10-4-11'},
    {name:'内畑',north:34.4199070504983,west:135.37219095279,south:34.3365860179624,east:135.49718281964,note:'昭和59年修正・昭和61.8.30発行',list:'101-10-2-9'}
]});
dataset.age.push({
  folderName:'07', start:1993, end:1997, scale:'1/25000', mapList: [
    {name:'亀岡',north:35.086500827615,west:135.497157279088,south:35.0031799301848,east:135.622149176011,note:'平成8年修正・平成9.5.1発行',list:'100-6-4-13'},
    {name:'京都西北部',north:35.0865037632984,west:135.622146280031,south:35.0031828711353,east:135.747138201681,note:'平成9年部修・平成9.10.12発行',list:'100-6-2-15'},
    {name:'京都東北部',north:35.0865067103121,west:135.747135294552,south:35.0031858233787,east:135.872127240968,note:'平成9年部修・平成9.10.12発行',list:'100-2-4-16'},
    {name:'草津',north:35.0865096686421,west:135.872124322705,south:35.0031887869011,east:135.997116293925,note:'平成8年修正・平成9.9.1発行',list:'100-2-2-13'},
    {name:'法貴',north:35.0031770005413,west:135.497160163906,south:34.9198560869385,east:135.622152060088,note:'平成8年修正・平成9.8.1発行',list:'100-7-3-11'},
    {name:'京都西南部',north:35.0031799301848,west:135.622149176011,south:34.9198590218194,east:135.747141096861,note:'平成8年修正・平成9.2.1発行',list:'100-7-1-14'},
    {name:'京都東南部',north:35.0031828711353,west:135.747138201681,south:34.9198619679698,east:135.872130147237,note:'平成9年部修・平成9.10.12発行',list:'100-3-3-17'},
    {name:'瀬田',north:35.0031858233787,west:135.872127240968,south:34.9198649253759,east:135.99711921127,note:'平成8年修正・平成9.7.1発行',list:'100-3-1-14'},
    {name:'三田',north:34.9198444603901,west:135.122196047991,south:34.836523514745,east:135.247187869842,note:'平成8年部修・平成8.11.14発行',list:'100-15-2-11'},
    {name:'武田尾',north:34.9198473500533,west:135.247185030871,south:34.8365264097275,east:135.372176877215,note:'平成9年修正・平成10.12.1発行',list:'100-11-4-10'},
    {name:'広根',north:34.9198502510416,west:135.372174027146,south:34.8365293159979,east:135.497165898021,note:'平成9年修正・平成10.4.2発行',list:'100-11-2-12'},
    {name:'高槻',north:34.9198531633413,west:135.497163036867,south:34.8365322335424,east:135.622154932312,note:'平成8年修正・平成9.6.1発行',list:'100-7-4-15'},
    {name:'淀',north:34.9198560869385,west:135.622152060088,south:34.8365351623471,east:135.747143980142,note:'平成8年修正・平成9.3.1発行',list:'100-7-2-17'},
    {name:'宇治',north:34.9198590218194,west:135.747141096861,south:34.8365381023981,east:135.872133041562,note:'平成8年修正・平成9.7.1発行',list:'100-3-4-15'},
    {name:'有馬',north:34.8365206310643,west:135.122198875851,south:34.7531996692888,east:135.247190697145,note:'平成8年部修・平成8.11.14発行',list:'100-16-1-18'},
    {name:'宝塚',north:34.836523514745,west:135.247187869842,south:34.753202558259,east:135.372179715569,note:'平成7年修正・平成8.2.1発行',list:'100-12-3-16'},
    {name:'伊丹',north:34.8365264097275,west:135.372176877215,south:34.7532054584937,east:135.497168747414,note:'平成7年修正・平成8.2.1発行',list:'100-12-1-16'},
    {name:'吹田',north:34.8365293159979,west:135.497165898021,south:34.7532083699791,east:135.622157792731,note:'平成7年修正・平成8.6.1発行',list:'100-8-3-19'},
    {name:'枚方',north:34.8365322335424,west:135.622154932312,south:34.7532112927013,east:135.747146851572,note:'平成7年修正・平成8.6.1発行',list:'100-8-1-16'},
    {name:'田辺',north:34.8365351623471,west:135.747143980142,south:34.7532142266465,east:135.87213592399,note:'平成9年部修・平成9.10.1発行',list:'100-4-3-11'},
    {name:'前開',north:34.7531939251968,west:134.997212700346,south:34.6698729419705,east:135.122204496749,note:'平成7年修正・平成8.2.1発行',list:'100-16-4-13'},
    {name:'神戸首部',north:34.7531967915969,west:135.122201692088,south:34.6698758136673,east:135.247193512826,note:'平成8年部修・平成8.9.30発行',list:'100-16-2-16'},
    {name:'西宮',north:34.7531996692888,west:135.247190697145,south:34.6698786966189,east:135.372182542257,note:'平成7年修正・平成8.2.1発行',list:'100-12-4-17'},
    {name:'大阪西北部',north:34.753202558259,west:135.372179715569,south:34.6698815908116,east:135.497171585095,note:'平成8年部修・平成8.9.30発行',list:'100-12-2-18'},
    {name:'大阪東北部',north:34.7532054584937,west:135.497168747414,south:34.6698844962315,east:135.622160641392,note:'平成7年修正・平成8.6.1発行',list:'100-8-4-19'},
    {name:'生駒山',north:34.7532083699791,west:135.622157792731,south:34.6698874128649,east:135.747149711199,note:'平成7年修正・平成8.8.1発行',list:'100-8-2-16'},
    {name:'奈良',north:34.7532112927013,west:135.747146851572,south:34.6698903406978,east:135.87213879457,note:'平成8年部修・平成8.6.1発行',list:'100-4-4-15'},
    {name:'須磨',north:34.669870081542,west:134.997215493974,south:34.586549082168,east:135.12220728988,note:'平成8年部修・平成8.9.30発行',list:'101-13-3-16'},
    {name:'神戸南部',north:34.6698729419705,west:135.122204496749,south:34.5865519478635,east:135.247196316932,note:'平成7年修正・平成8.2.1発行',list:'101-13-1-14'},
    {name:'大阪西南部',north:34.6698786966189,west:135.372182542257,south:34.5865577129345,east:135.497174411111,note:'平成7年修正・平成8.7.1発行',list:'101-9-1-15'},
    {name:'大阪東南部',north:34.6698815908116,west:135.497171585095,south:34.5865606122825,east:135.622163478343,note:'平成7年修正・平成8.8.1発行',list:'101-5-3-18'},
    {name:'信貴山',north:34.6698844962315,west:135.622160641392,south:34.5865635228206,east:135.747152559072,note:'平成7年修正・平成8.8.1発行',list:'101-5-1-16'},
    {name:'大和郡山',north:34.6698874128649,west:135.747149711199,south:34.5865664445349,east:135.87214165335,note:'平成6年修正・平成7.6.1発行',list:'101-1-3-12'},
    {name:'堺',north:34.5865548247902,west:135.372185357325,south:34.5032338248452,east:135.49717722551,note:'平成7年修正・平成8.12.1発行',list:'101-9-2-15'},
    {name:'古市',north:34.5865577129345,west:135.497174411111,south:34.5032367181151,east:135.622166303631,note:'平成7年修正・平成8.4.1発行',list:'101-5-4-17'},
    {name:'大和高田',north:34.5865606122825,west:135.622163478343,south:34.5032396225516,east:135.747155395236,note:'平成7年修正・平成8.8.1発行',list:'101-5-2-15'},
    {name:'桜井',north:34.5865635228206,west:135.747152559072,south:34.5032425381407,east:135.872144500377,note:'平成6年修正・平成7.7.1発行',list:'101-1-4-13'},
    {name:'岸和田西部西端',north:34.5032252121723,west:135.122210071529,south:34.4199041856403,east:135.247201890608,note:'平成5年修正・平成6.9.1発行',list:''},
    {name:'岸和田西部',north:34.5032280718601,west:135.247199109511,south:34.4199070504983,east:135.37219095279,note:'平成5年修正・平成6.9.1発行',list:'101-10-3-11'},
    {name:'岸和田東部',north:34.5032309427557,west:135.37218816082,south:34.4199099265269,east:135.497180028337,note:'平成5年修正・平成6.10.1発行',list:'101-10-1-11'},
    {name:'富田林',north:34.5032338248452,west:135.49717722551,south:34.4199128137123,east:135.622169117304,note:'平成6年修正・平成7.4.1発行',list:'101-6-3-12'},
    {name:'御所',north:34.5032367181151,west:135.622166303631,south:34.4199157120407,east:135.74715821974,note:'平成9年部修・平成9.9.1発行',list:'101-6-1-11'},
    {name:'畝傍山',north:34.5032396225516,west:135.747155395236,south:34.4199186214984,east:135.872147335699,note:'平成6年修正・平成7.7.1発行',list:'101-2-3-11'},
    {name:'尾崎',north:34.4199013319663,west:135.122212841742,south:34.3365802891868,east:135.247204660271,note:'平成5年修正・平成6.9.1発行',list:''},
    {name:'樽井',north:34.4199041856403,west:135.247201890608,south:34.3365831480012,east:135.372193733279,note:'平成5年修正・平成6.10.1発行',list:'101-10-4-14'},
    {name:'内畑',north:34.4199070504983,west:135.37219095279,south:34.3365860179624,east:135.49718281964,note:'平成5年修正・平成6.9.1発行',list:'101-10-2-12'}
]});
kjmapDataSet['tohoku_pacific_coast'] = new Object();
dataset = kjmapDataSet['tohoku_pacific_coast'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1901, end:1916, scale:'1/50000', mapList: [
    {name:'鮫',north:40.669382064209,west:141.499270852723,south:40.5027429207499,east:141.749257699912,note:'大正3年測図・大正4.7.30 発行',list:'55-5-1'},
    {name:'階上岳',north:40.5027350902577,west:141.499279821227,south:40.3360958832915,east:141.749266648054,note:'大正3年測図・大正6.5.30発行',list:''},
    {name:'八木',north:40.5027429207499,west:141.749257699912,south:40.3361037349308,east:141.999244650197,note:'大正3年測図・大正4.7.30 発行',list:'55-6-1'},
    {name:'久慈',north:40.3360958832915,west:141.749266648054,south:40.1694566335099,east:141.999253577604,note:'大正3年測図・大正4.7.30 発行',list:'55-3-1'},
    {name:'野田',north:40.1694488085688,west:141.74927552157,south:40.0028094946002,east:141.999262430636,note:'大正3年測図・大正4.7.30 発行',list:'55-4-1'},
    {name:'岩泉',north:40.0028016964252,west:141.749284321159,south:39.8361623180456,east:141.999271209986,note:'大正3年測図・大正4.7.30 発行',list:'56-1-1'},
    {name:'田老',north:39.8361545467047,west:141.749293047512,south:39.6695228949488,east:142.249258200062,note:'大正5年測図・大正7.7.30  発行',list:'56-2-1'},
    {name:'宮古',north:39.6695073592521,west:141.749301701309,south:39.5028678513831,east:141.999288550373,note:'大正5年測図・大正7.7.30 発行',list:'56-3-1'},
    {name:'?崎',north:39.6695151036914,west:141.99927991634,south:39.5028756155086,east:142.249266886051,note:'大正5年測図・大正7.6.30 発行',list:'56-3東-1'},
    {name:'大槌',north:39.5028601339127,west:141.749310283221,south:39.3362205609672,east:141.999297112751,note:'大正5年測図・大正7.7.30 発行',list:'56-4-1'},
    {name:'霞露ヶ岳',north:39.5028678513831,west:141.999288550373,south:39.3362282978931,east:142.249275499954,note:'大正5年測図・大正7.6.30 発行',list:'56-4東-1'},
    {name:'釜石',north:39.3362128705329,west:141.749318793912,south:39.1695732322909,east:141.999305604132,note:'大正2年測図・大正5.3.30 発行',list:'57-1-1'},
    {name:'盛',north:39.1695579521019,west:141.499348931727,south:39.0029182290405,east:141.749335604231,note:'大正2年測図・大正5.5.30 発行',list:'57-6-1'},
    {name:'綾里',north:39.1695655689596,west:141.749327234034,south:39.0029258652022,east:141.999314025164,note:'大正2年測図・大正5.5.30 発行',list:'57-2-1'},
    {name:'気仙沼',north:39.0029106391878,west:141.49935725093,south:38.8362708506243,east:141.74934390514,note:'大正2年測図・大正5.5.30 発行',list:'57-7-1'},
    {name:'志津川',north:38.8362557713483,west:141.249387164458,south:38.6696158979149,east:141.499373683363,note:'大正2年測図・大正4.5.30 発行',list:'57-12-1'},
    {name:'津谷',north:38.8362632878425,west:141.499365501268,south:38.6696234335599,east:141.749352137388,note:'大正2年測図・大正5.5.30 発行',list:'57-8-1'},
    {name:'登米',north:38.6696084083915,west:141.249395296244,south:38.502968469255,east:141.49938179783,note:'大正2年測図・大正4.5.30 発行',list:'58-9-1'},
    {name:'大須',north:38.6696158979149,west:141.499373683363,south:38.5029759776975,east:141.749360301594,note:'大正2年測図・大正5.3.30 発行',list:'58-5-1'},
    {name:'吉岡',north:38.5029462202248,west:140.74944668541,south:38.3363061768697,east:140.99943293848,note:'明治34年測図・明治41.3.30発行',list:'63-2-1B'},
    {name:'松島',north:38.5029535903771,west:140.999424990149,south:38.3363135663266,east:141.249411358783,note:'大正1年測図・大正5.2.28発行',list:'58-14-2'},
    {name:'石巻',north:38.5029610067675,west:141.249403360818,south:38.3363210017132,east:141.499389845275,note:'大正2年測図・大正4.5.30 発行',list:'58-10-1'},
    {name:'江ノ嶋',north:38.502968469255,west:141.49938179783,south:38.3363284828878,east:141.749368398368,note:'大正2年測図・大正5.3.30 発行',list:'58-6-1'},
    {name:'仙台',north:38.3362988334831,west:140.749454583957,south:38.1696587244609,east:140.999440821208,note:'明治40年測図・明治45.5.30発行',list:'63-3-3'},
    {name:'塩竈',north:38.3363061768697,west:140.99943293848,south:38.1696660869199,east:141.249419290734,note:'大正1年測図・大正6.6.3発行',list:'58-15-18'},
    {name:'網地',north:38.3363135663266,west:141.249411358783,south:38.1696734951407,east:141.499397826299,note:'大正2年測図・大正4.11.30発行',list:''},
    {name:'金華山',north:38.3363210017132,west:141.499389845275,south:38.1696809489823,east:141.749376428312,note:'大正2年測図・大正4.11.30発行',list:'58-7-1'},
    {name:'岩沼',north:38.1696514079038,west:140.749462417311,south:38.0030112330022,east:140.999448638915,note:'明治40年測図・明治44.11.30発行',list:'63-4-2'},
    {name:'角田',north:38.0030039433385,west:140.749470186052,south:37.8363637023458,east:140.999456392177,note:'明治41年測図・明治45.5.30発行',list:'64-1-2'},
    {name:'中村',north:37.836356439639,west:140.749477890751,south:37.6697234134262,east:141.249442696337,note:'明治41年測図・明治45.4.30発行',list:'64-2-2'},
    {name:'原町',north:37.6697088966584,west:140.749485531974,south:37.5030685228536,east:140.999471707631,note:'明治41年測図・明治44.7.30発行',list:'64-3-2'},
    {name:'井田川浦',north:37.669716132345,west:140.999464081562,south:37.5030757766815,east:141.249450370027,note:'明治41年測図・明治43.7.30発行',list:'64-3東-1'},
    {name:'浪江',north:37.5030613142503,west:140.749493110277,south:37.3364208737261,east:140.999479270938,note:'明治41年測図・明治44.4.30発行',list:'64-4-1'},
    {name:'富岡',north:37.5030685228536,west:140.999471707631,south:37.3364281002375,east:141.249457980562,note:'明治41年測図・明治43.12.15発行',list:'64-4東-1'},
    {name:'川前',north:37.336413692269,west:140.749500626211,south:37.1697731848179,east:140.999486772027,note:'明治41年測図・明治44.11.30発行',list:'65-1-1'},
    {name:'井出',north:37.3364208737261,west:140.999479270938,south:37.1697803839498,east:141.249465528492,note:'明治41年測図・明治43.5.30発行',list:'65-1東-1'},
    {name:'平',north:37.1697660305696,west:140.749508080317,south:37.0031326276747,east:141.249473014358,note:'明治41年測図・明治44.11.30発行',list:'65-2-1'},
    {name:'小名浜',north:37.0031183290081,west:140.749515473131,south:36.8364776870847,east:140.999501589703,note:'明治41年測図・明治44.5.30発行',list:'65-3-1'}
]});
dataset.age.push({
  folderName:'01', start:1949, end:1953, scale:'1/50000', mapList: [
    {name:'鮫',north:40.669382064209,west:141.499270852723,south:40.5027429207499,east:141.749257699912,note:'昭和28年応修・昭和28.12.28 発行',list:'55-5-5'},
    {name:'階上岳',north:40.5027350902577,west:141.499279821227,south:40.3360958832915,east:141.749266648054,note:'昭和28年応修・昭和34.1.30発行',list:''},
    {name:'八木',north:40.5027429207499,west:141.749257699912,south:40.3361037349308,east:141.999244650197,note:'昭和28年応修・昭和29.2.28 発行',list:'55-6-6'},
    {name:'久慈',north:40.3360958832915,west:141.749266648054,south:40.1694566335099,east:141.999253577604,note:'昭和28年応修・昭和29.2.28 発行',list:'55-3-5'},
    {name:'陸中野田',north:40.1694488085688,west:141.74927552157,south:40.0028094946002,east:141.999262430636,note:'昭和28年応修・昭和29.3.30 発行',list:'55-4-3'},
    {name:'岩泉',north:40.0028016964252,west:141.749284321159,south:39.8361623180456,east:141.999271209986,note:'昭和28年応修・昭和28.6.30 発行',list:'56-1-4'},
    {name:'田老',north:39.8361545467047,west:141.749293047512,south:39.6695228949488,east:142.249258200062,note:'昭和27年応修・昭和28.6.30  発行',list:'56-2-3'},
    {name:'宮古',north:39.6695073592521,west:141.749301701309,south:39.5028678513831,east:141.999288550373,note:'昭和28年応修・昭和28.6.30 発行',list:'56-3-3'},
    {name:'?崎',north:39.6695151036914,west:141.99927991634,south:39.5028756155086,east:142.249266886051,note:'昭和27年応修・昭和28.1.30 発行',list:'56-3東-3'},
    {name:'大槌',north:39.5028601339127,west:141.749310283221,south:39.3362205609672,east:141.999297112751,note:'昭和27年応修・昭和28.3.30 発行',list:'56-4-2'},
    {name:'霞露ヶ岳',north:39.5028678513831,west:141.999288550373,south:39.3362282978931,east:142.249275499954,note:'昭和27年応修・昭和35.10.30 発行',list:'56-4東-3'},
    {name:'釜石',north:39.3362128705329,west:141.749318793912,south:39.1695732322909,east:141.999305604132,note:'昭和27年応修・昭和28.6.30 発行',list:'57-1-4'},
    {name:'盛',north:39.1695579521019,west:141.499348931727,south:39.0029182290405,east:141.749335604231,note:'昭和26年応修・昭和27.8.30 発行',list:'57-6-5'},
    {name:'綾里',north:39.1695655689596,west:141.749327234034,south:39.0029258652022,east:141.999314025164,note:'昭和27年応修・昭和28.3.30 発行',list:'57-2-4'},
    {name:'気仙沼',north:39.0029106391878,west:141.49935725093,south:38.8362708506243,east:141.74934390514,note:'昭和27年応修・昭和27.12.28 発行',list:'57-7-5'},
    {name:'志津川',north:38.8362557713483,west:141.249387164458,south:38.6696158979149,east:141.499373683363,note:'昭和26年応修・昭和27.7.30 発行',list:'57-12-6'},
    {name:'津谷',north:38.8362632878425,west:141.499365501268,south:38.6696234335599,east:141.749352137388,note:'昭和27年応修・昭和28.1.30 発行',list:'57-8-4'},
    {name:'登米',north:38.6696084083915,west:141.249395296244,south:38.502968469255,east:141.49938179783,note:'昭和26年応修・昭和27.8.30 発行',list:'58-9-6'},
    {name:'大須',north:38.6696158979149,west:141.499373683363,south:38.5029759776975,east:141.749360301594,note:'昭和27年応修・昭和27.12.28 発行',list:'58-5-4'},
    {name:'吉岡',north:38.5029462202248,west:140.74944668541,south:38.3363061768697,east:140.99943293848,note:'昭和26年応修・昭和27.7.30発行',list:'63-2-5'},
    {name:'松島',north:38.5029535903771,west:140.999424990149,south:38.3363135663266,east:141.249411358783,note:'昭和27年応修・昭和27.6.30発行',list:'58-14-8'},
    {name:'石巻',north:38.5029610067675,west:141.249403360818,south:38.3363210017132,east:141.499389845275,note:'昭和27年応修・昭和27.7.30 発行',list:'58-10-6'},
    {name:'寄磯',north:38.502968469255,west:141.49938179783,south:38.3363284828878,east:141.749368398368,note:'昭和27年応修・昭和27.12.28 発行',list:'58-6-4'},
    {name:'仙台',north:38.3362988334831,west:140.749454583957,south:38.1696587244609,east:140.999440821208,note:'昭和27年応修・昭和27.8.30発行',list:'63-3-9'},
    {name:'塩竈',north:38.3363061768697,west:140.99943293848,south:38.1696660869199,east:141.249419290734,note:'昭和26年応修・昭和27.7.30発行',list:'58-15-8'},
    {name:'網地嶋',north:38.3363135663266,west:141.249411358783,south:38.1696734951407,east:141.499397826299,note:'昭和26年応修・昭和27.7.30発行',list:'58-7-10'},
    {name:'金華山',north:38.3363210017132,west:141.499389845275,south:38.1696809489823,east:141.749376428312,note:'昭和24年二修・昭和26.9.30発行',list:''},
    {name:'岩沼',north:38.1696514079038,west:140.749462417311,south:38.0030112330022,east:140.999448638915,note:'昭和26年応修・昭和27.7.30発行',list:'63-4-5'},
    {name:'角田',north:38.0030039433385,west:140.749470186052,south:37.8363637023458,east:140.999456392177,note:'昭和27年応修・昭和27.12.28発行',list:'64-1-7'},
    {name:'相馬中村',north:37.836356439639,west:140.749477890751,south:37.6697234134262,east:141.249442696337,note:'昭和27年応修・昭和28.3.30発行',list:'64-2-7'},
    {name:'原町',north:37.6697088966584,west:140.749485531974,south:37.5030685228536,east:140.999471707631,note:'昭和28年応修・昭和28.5.30発行',list:'64-3-6'},
    {name:'大甕',north:37.669716132345,west:140.999464081562,south:37.5030757766815,east:141.249450370027,note:'昭和27年応修・昭和27.12.28発行',list:'64-3東-4'},
    {name:'浪江',north:37.5030613142503,west:140.749493110277,south:37.3364208737261,east:140.999479270938,note:'昭和28年応修・昭和28.4.30発行',list:'64-4-5'},
    {name:'磐城富岡',north:37.5030685228536,west:140.999471707631,south:37.3364281002375,east:141.249457980562,note:'昭和27年応修・昭和28.3.30発行',list:'64-4東-5'},
    {name:'川前',north:37.336413692269,west:140.749500626211,south:37.1697731848179,east:140.999486772027,note:'昭和28年応修・昭和28.5.30発行',list:'65-1-6'},
    {name:'井出',north:37.3364208737261,west:140.999479270938,south:37.1697803839498,east:141.249465528492,note:'昭和27年応修・昭和28.2.28発行',list:'65-1東-5'},
    {name:'平',north:37.1697660305696,west:140.749508080317,south:37.0031326276747,east:141.249473014358,note:'昭和27年応修・昭和28.3.30発行',list:'65-2-8'},
    {name:'小名浜',north:37.0031183290081,west:140.749515473131,south:36.8364776870847,east:140.999501589703,note:'昭和26年応修・昭和29.10.30発行',list:'65-3-7'}
]});
dataset.age.push({
  folderName:'02', start:1969, end:1982, scale:'1/50000', mapList: [
    {name:'八戸東部',north:40.669381973699,west:141.496382220497,south:40.5027428299911,east:141.746369066253,note:'昭和53年修正・昭和54.10.30発行',list:''},
    {name:'階上岳',north:40.5027350000518,west:141.496391188365,south:40.3361036439294,east:141.99635601511,note:'昭和49年修正・昭和51.3.30発行',list:''},
    {name:'久慈',north:40.3360957928394,west:141.746378013766,south:40.169456542818,east:141.996364941895,note:'昭和49年修正・昭和50.12.28発行',list:''},
    {name:'陸中野田',north:40.1694487184243,west:141.746386886658,south:40.0028094042184,east:141.99637379431,note:'昭和49年修正・昭和50.8.30発行',list:''},
    {name:'岩泉',north:40.0028016065891,west:141.746395685629,south:39.8361622279749,east:141.996382573049,note:'昭和49年修正・昭和51.3.30発行',list:''},
    {name:'田老',north:39.8361544571777,west:141.746404411368,south:39.6695228046497,east:142.246369561723,note:'昭和49年修正・昭和52.3.30発行',list:''},
    {name:'宮古',north:39.669507270035,west:141.746413064557,south:39.5028677619367,east:141.996399912228,note:'昭和54年修正・昭和55.12.28発行',list:''},
    {name:'?ヶ崎',north:39.6695150139324,west:141.996391278797,south:39.5028755255239,east:142.246378247113,note:'昭和44年集・昭和46.2.28発行',list:''},
    {name:'大槌',north:39.5028600450063,west:141.746421645866,south:39.3362204718341,east:141.99640847401,note:'昭和48年修正・昭和50.3.30発行',list:''},
    {name:'霞露ヶ岳',north:39.5028677619367,west:141.996399912228,south:39.3362282082237,east:142.246386860421,note:'昭和44年集・昭和46.1.30発行',list:''},
    {name:'釜石',north:39.3362127819379,west:141.746430155959,south:39.169573143472,east:141.9964169648,note:'昭和48年修正・昭和50.3.30発行',list:''},
    {name:'盛',north:39.1695578643571,west:141.496460293961,south:39.0029181410708,east:141.746446965096,note:'昭和54年修正・昭和56.9.30発行',list:''},
    {name:'綾里',north:39.1695654806769,west:141.746438595487,south:39.0029257766982,east:141.996425385245,note:'昭和50年修正・昭和52.6.30発行',list:''},
    {name:'気仙沼',north:39.0029105517541,west:141.496468612575,south:38.8362707629683,east:141.746455265422,note:'昭和48年修正・昭和50.3.30発行',list:''},
    {name:'志津川',north:38.8362556847621,west:141.24649852629,south:38.6696158111057,east:141.496485043841,note:'昭和51年修正・昭和52.12.28発行',list:''},
    {name:'津谷',north:38.8362632007206,west:141.496476862327,south:38.6696233462185,east:141.746463497091,note:'昭和51年修正・昭和53.5.30発行',list:''},
    {name:'登米',north:38.669608322116,west:141.246506657494,south:38.5029683827591,east:141.496493157733,note:'昭和51年修正・昭和52.11.30発行',list:''},
    {name:'大須',north:38.6696158111057,west:141.496485043841,south:38.5029758906714,east:141.746471660723,note:'昭和44年集・昭和46.1.30発行',list:''},
    {name:'吉岡',north:38.5029461353294,west:140.746558047606,south:38.3363060917494,east:140.996544299342,note:'昭和54年二・昭和56.8.30発行',list:''},
    {name:'松島',north:38.5029535049465,west:140.996536351585,south:38.3363134806748,east:141.246522718882,note:'昭和55年集・昭和56.5.30発行',list:''},
    {name:'石巻',north:38.5029609208035,west:141.24651472149,south:38.3363209155314,east:141.496501204608,note:'昭和50年修正・昭和52.3.30発行',list:''},
    {name:'寄磯',north:38.5029683827591,west:141.496493157733,south:38.3363283961778,east:141.746479756928,note:'昭和44年集・昭和46.4.30発行',list:''},
    {name:'仙台',north:38.336298748896,west:140.746565945577,south:38.1696586396516,east:140.9965521815,note:'昭和53年二・昭和55.1.30発行',list:''},
    {name:'塩竈',north:38.3363060917494,west:140.996544299342,south:38.1696660015809,east:141.246530650265,note:'昭和53年二・昭和55.4.30発行',list:''},
    {name:'金華山',north:38.3363171923705,west:141.371511953446,south:38.169680862589,east:141.746487786308,note:'昭和47年修正・昭和48.5.30発行',list:''},
    {name:'岩沼',north:38.1696513236258,west:140.746573778359,south:38.0030111485046,east:140.996559998642,note:'昭和53年二・昭和55.9.30発行',list:''},
    {name:'角田',north:38.0030038593702,west:140.746581546533,south:37.8363636181607,east:140.996567751344,note:'昭和52年修正・昭和53.11.30発行',list:''},
    {name:'相馬中村',north:37.8363563559813,west:140.746589250671,south:37.6697233290305,east:141.246554054193,note:'昭和53年修正・昭和54.2.28発行',list:''},
    {name:'原町',north:37.6697088133119,west:140.746596891336,south:37.5030684392956,east:140.996583065691,note:'昭和48年修正・昭和49.9.30発行',list:''},
    {name:'大甕',north:37.6697160484731,west:140.996575440173,south:37.5030756926017,east:141.246561727333,note:'昭和49年修正・昭和50.3.30発行',list:''},
    {name:'浪江',north:37.5030612312157,west:140.746604469086,south:37.3364207904828,east:140.996590628451,note:'昭和47年修正・昭和50.2.28発行',list:''},
    {name:'磐城富岡',north:37.5030684392956,west:140.996583065691,south:37.3364280164743,east:141.246569337323,note:'昭和49年修正・昭和49.8.30発行',list:''},
    {name:'川前',north:37.3364136095471,west:140.746611984472,south:37.16977310189,east:140.996598128998,note:'昭和52年修正・昭和53.9.30発行',list:''},
    {name:'井出',north:37.3364207904828,west:140.996590628451,south:37.169780300504,east:141.246576884712,note:'昭和52年修正・昭和53.11.30発行',list:''},
    {name:'平',north:37.1697659481612,west:140.746619438034,south:37.003132544547,east:141.246584370043,note:'昭和52年修正・昭和54.1.30発行',list:''},
    {name:'小名浜',north:37.0031182469138,west:140.746626830309,south:36.8364776047897,east:140.996612945603,note:'昭和57年修正・昭和57.10.30発行',list:''}
]});
dataset.age.push({
  folderName:'03', start:1990, end:2008, scale:'1/50000', mapList: [
    {name:'八戸東部',north:40.669381973699,west:141.496382220497,south:40.5027428299911,east:141.746369066253,note:'平成12年修正・平成13.12.1発行',list:''},
    {name:'階上岳',north:40.5027350000518,west:141.496391188365,south:40.3361036439294,east:141.99635601511,note:'平成20年要修・平成21.6.1発行',list:''},
    {name:'久慈',north:40.3360957928394,west:141.746378013766,south:40.169456542818,east:141.996364941895,note:'平成14年修正・平成16.1.1発行',list:''},
    {name:'陸中野田',north:40.1694487184243,west:141.746386886658,south:40.0028094042184,east:141.99637379431,note:'平成14年修正・平成15.9.1発行',list:''},
    {name:'岩泉',north:40.0028016065891,west:141.746395685629,south:39.8361622279749,east:141.996382573049,note:'平成14年要修・平成15.7.1発行',list:''},
    {name:'田老',north:39.8361544571777,west:141.746404411368,south:39.6695228046497,east:142.246369561723,note:'平成14年要修・平成15.6.1発行',list:''},
    {name:'宮古',north:39.669507270035,west:141.746413064557,south:39.5028677619367,east:141.996399912228,note:'平成18年要修・平成20.3.1発行',list:''},
    {name:'?ヶ崎',north:39.6695150139324,west:141.996391278797,south:39.5028755255239,east:142.246378247113,note:'平成14年修正・平成15.7.1発行',list:''},
    {name:'大槌',north:39.5028600450063,west:141.746421645866,south:39.3362204718341,east:141.99640847401,note:'平成14年要修・平成16.3.1発行',list:''},
    {name:'霞露ヶ岳',north:39.5028677619367,west:141.996399912228,south:39.3362282082237,east:142.246386860421,note:'平成14年修正・平成15.11.1発行',list:''},
    {name:'釜石',north:39.3362127819379,west:141.746430155959,south:39.169573143472,east:141.9964169648,note:'平成14年要修・平成15.3.1発行',list:''},
    {name:'盛',north:39.1695578643571,west:141.496460293961,south:39.0029181410708,east:141.746446965096,note:'平成11年要修・平成11.12.1発行',list:''},
    {name:'綾里',north:39.1695654806769,west:141.746438595487,south:39.0029257766982,east:141.996425385245,note:'平成11年要修・平成12.10.1発行',list:''},
    {name:'気仙沼',north:39.0029105517541,west:141.496468612575,south:38.8362707629683,east:141.746455265422,note:'平成6年修正・平成7.11.1発行',list:''},
    {name:'志津川',north:38.8362556847621,west:141.24649852629,south:38.6696158111057,east:141.496485043841,note:'平成9年修正・平成11.2.1発行',list:''},
    {name:'津谷',north:38.8362632007206,west:141.496476862327,south:38.6696233462185,east:141.746463497091,note:'平成9年修正・平成11.2.1発行',list:''},
    {name:'登米',north:38.669608322116,west:141.246506657494,south:38.5029683827591,east:141.496493157733,note:'平成9年修正・平成11.1.1発行',list:''},
    {name:'大須',north:38.6696158111057,west:141.496485043841,south:38.5029758906714,east:141.746471660723,note:'平成9年修正・平成11.2.1発行',list:''},
    {name:'吉岡',north:38.5029461353294,west:140.746558047606,south:38.3363060917494,east:140.996544299342,note:'平成7年修正・平成8.5.1発行',list:''},
    {name:'松島',north:38.5029535049465,west:140.996536351585,south:38.3363134806748,east:141.246522718882,note:'平成14年修正・平成15.8.1発行',list:''},
    {name:'石巻',north:38.5029609208035,west:141.24651472149,south:38.3363209155314,east:141.496501204608,note:'平成14年修正・平成15.6.1発行',list:''},
    {name:'寄磯',north:38.5029683827591,west:141.496493157733,south:38.3363283961778,east:141.746479756928,note:'平成15年修正・平成16.12.1発行',list:''},
    {name:'仙台',north:38.336298748896,west:140.746565945577,south:38.1696586396516,east:140.9965521815,note:'平成13年要修・平成14.6.1発行',list:''},
    {name:'塩竈',north:38.3363060917494,west:140.996544299342,south:38.1696660015809,east:141.246530650265,note:'平成4年修正・平成5.2.1発行',list:''},
    {name:'金華山',north:38.3363171923705,west:141.371511953446,south:38.169680862589,east:141.746487786308,note:'平成13年修正・平成14.7.1発行',list:''},
    {name:'岩沼',north:38.1696513236258,west:140.746573778359,south:38.0030111485046,east:140.996559998642,note:'平成9年修正・平成10.7.1発行',list:''},
    {name:'角田',north:38.0030038593702,west:140.746581546533,south:37.8363636181607,east:140.996567751344,note:'平成2年修正・平成3.2.1発行',list:''},
    {name:'相馬中村',north:37.8363563559813,west:140.746589250671,south:37.6697233290305,east:141.246554054193,note:'平成4年修正・平成5.10.1発行',list:''},
    {name:'原町',north:37.6697088133119,west:140.746596891336,south:37.5030684392956,east:140.996583065691,note:'平成6年修正・平成6.12.1発行',list:''},
    {name:'大甕',north:37.6697160484731,west:140.996575440173,south:37.5030756926017,east:141.246561727333,note:'平成5年修正・平成6.3.1発行',list:''},
    {name:'浪江',north:37.5030612312157,west:140.746604469086,south:37.3364207904828,east:140.996590628451,note:'平成4年修正・平成4.6.1発行',list:''},
    {name:'磐城富岡',north:37.5030684392956,west:140.996583065691,south:37.3364280164743,east:141.246569337323,note:'平成13年修正・平成15.2.1発行',list:''},
    {name:'川前',north:37.3364136095471,west:140.746611984472,south:37.16977310189,east:140.996598128998,note:'平成14年修正・平成14.10.1発行',list:''},
    {name:'井出',north:37.3364207904828,west:140.996590628451,south:37.169780300504,east:141.246576884712,note:'平成13年修正・平成14.7.1発行',list:''},
    {name:'平',north:37.1697659481612,west:140.746619438034,south:37.003132544547,east:141.246584370043,note:'平成19年修正・平成21.1.1発行',list:''},
    {name:'小名浜',north:37.0031182469138,west:140.746626830309,south:36.8364776047897,east:140.996612945603,note:'平成19年修正・平成21.2.1発行',list:''}
]});
kjmapDataSet['kanto'] = new Object();
dataset = kjmapDataSet['kanto'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1894, end:1915, scale:'1/50000', mapList: [
    {name:'棚倉',north:37.1697505891802,west:140.249550889594,south:37.0031099754583,east:140.499536799089,note:'明治42年測図・明治43.6.30発行',list:'65-10-1'},
    {name:'塙',north:37.0031029383126,west:140.249558188793,south:36.8364622577195,east:140.499544084786,note:'明治42年測図・明治44.7.30発行',list:'65-11-1'},
    {name:'大子',north:36.8364552475628,west:140.249565427998,south:36.6698145098931,east:140.499551310622,note:'明治42年測図・明治44.7.30発行',list:'65-12-1'},
    {name:'白河',north:37.1697435703964,west:139.999572389709,south:37.0031029383126,east:140.249558188793,note:'明治42年測図・明治43.5.30発行',list:'65-14-1'},
    {name:'大田原',north:37.0030959462837,west:139.999579641893,south:36.8364552475628,east:140.249565427998,note:'明治42年測図・明治43.5.30発行',list:'65-15-1'},
    {name:'喜連川',north:36.8364482823498,west:139.999586834468,south:36.6698075267865,east:140.249572607724,note:'明治42年測図・明治43.5.30発行',list:'65-16-1'},
    {name:'大津',north:36.8364693126867,west:140.749522805238,south:36.6698286098851,east:140.999508907401,note:'明治41年測図・大正1.9.30発行',list:'65-4-11'},
    {name:'竹貫',north:37.1697576532534,west:140.499529453012,south:37.0031170575869,east:140.749515473187,note:'明治41年測図・明治44.7.30発行',list:'65-6-1'},
    {name:'小川',north:37.0031099754583,west:140.499536799089,south:36.8364693126867,east:140.749522805238,note:'明治41年測図・明治44.4.30発行',list:'65-7-1'},
    {name:'高萩',north:36.8364622577195,west:140.499544084786,south:36.6698215376372,east:140.749530077046,note:'明治42年測図',list:'65-8-1'},
    {name:'水戸',north:36.5031597558438,west:140.249579728479,south:36.3365188734157,east:140.49956558475,note:'明治36年測図・明治39.6.30発行',list:'66-10-1'},
    {name:'石岡',north:36.3365119445921,west:140.249586790765,south:36.1698710044806,east:140.499572634044,note:'明治36年測図・明治39.6.30発行',list:'66-11-1'},
    {name:'玉造',north:36.1698641028894,west:140.249593795076,south:36.0032230848966,east:140.499579625484,note:'明治36年測図・明治39.6.30発行',list:'66-12-1'},
    {name:'烏山',north:36.6698005884502,west:139.999593967947,south:36.5031597558438,east:140.249579728479,note:'明治39年測図・明治41.1.30発行',list:'66-13-9'},
    {name:'真岡',north:36.5031528444449,west:139.999601042836,south:36.3365119445921,east:140.249586790765,note:'明治38年測図・明治40.10.30発行',list:'66-14-1'},
    {name:'真壁',north:36.3365050601908,west:139.999608059632,south:36.1698641028894,east:140.249593795076,note:'明治38年測図・明治42.6.30発行',list:'66-15-16'},
    {name:'土浦',north:36.1698572455459,west:139.999615018826,south:36.003216210598,east:140.249600741902,note:'明治38年測図・明治41.12.28発行',list:'66-16-20'},
    {name:'太田',north:36.6698145098931,west:140.499551310622,south:36.503173712299,east:140.749537289127,note:'明治39年測図・明治40.12.28発行',list:'66-5-1'},
    {name:'湊',north:36.5031667118393,west:140.499558477108,south:36.3365258465299,east:140.749544441989,note:'明治38年測図・明治40.5.30発行',list:'66-6-1'},
    {name:'磯浜',north:36.3365188734157,west:140.49956558475,south:36.1698779501883,east:140.749551536133,note:'明治36年測図・明治41.12.28発行',list:'66-7-16'},
    {name:'鉾田',north:36.1698710044806,west:140.499572634044,south:36.0032300031371,east:140.749558572054,note:'明治36年測図・明治39.6.30発行',list:'66-8-1'},
    {name:'大宮',north:36.6698075267865,west:140.249572607724,south:36.5031667118393,east:140.499558477108,note:'明治38年測図・明治40.4.30発行',list:'66-9-1'},
    {name:'成田',north:35.8365682775776,west:140.249607631725,south:35.6699271332219,east:140.499593436735,note:'明治37年測図・明治42.6.30発行',list:'67-10-1'},
    {name:'東金',north:35.6699203136887,west:140.24961446502,south:35.5032790908566,east:140.499600257499,note:'明治36年測図・明治42.11.30発行',list:'67-11-1'},
    {name:'茂原',north:35.5032722987957,west:140.249621242259,south:35.3366310072899,east:140.499607022312,note:'明治36年測図・明治39.6.30発行',list:'67-12-1'},
    {name:'龍ヶ崎',north:36.0032093803722,west:139.999621920906,south:35.8365682775776,east:140.249607631725,note:'明治36年測図・明治42.4.30発行',list:'67-13-1'},
    {name:'佐倉',north:35.8365614745293,west:139.99962876635,south:35.6699203136887,east:140.24961446502,note:'明治37年測図・明治42.11.30発行',list:'67-14-1'},
    {name:'千葉',north:35.6699135378772,west:139.99963555563,south:35.5032722987957,east:140.249621242259,note:'明治36年測図・明治42.6.30発行',list:'67-15-1'},
    {name:'姉崎',north:35.5032655502803,west:139.999642289214,south:35.3366242427606,east:140.249627963904,note:'明治36年測図・明治39.12.28発行',list:'67-16-1'},
    {name:'銚子',north:35.8365820152364,west:140.749565550241,south:35.6699409029333,east:140.999551568739,note:'明治36年測図・明治39.6.30発行',list:'67-2-1'},
    {name:'鹿島',north:36.0032230848966,west:140.499579625484,south:35.8365827067098,east:140.774563452782,note:'明治36年測図・明治39.6.30発行',list:'67-5-1'},
    {name:'八日市場',north:35.8365751245235,west:140.499586559555,south:35.6699339963469,east:140.749572471175,note:'明治36年測図・明治39.10.30発行',list:'67-6-1'},
    {name:'木戸',north:35.6699271332219,west:140.499593436735,south:35.5032859263338,east:140.749579335334,note:'明治36年測図・明治42.1.30発行',list:'67-7-13'},
    {name:'佐原',north:36.003216210598,west:140.249600741902,south:35.8365751245235,east:140.499586559555,note:'明治39年測図・明治42.4.30発行',list:'67-9-1'},
    {name:'勝浦',north:35.1699761554461,west:140.249634630414,south:35.003334726008,east:140.499620385925,note:'明治36年測図・明治38.12.28発行',list:'68-10-1'},
    {name:'大多喜',north:35.3366175216003,west:139.999648967564,south:35.1699761554461,east:140.249634630414,note:'明治36年測図・明治39.6.30発行',list:'68-13-1'},
    {name:'天津',north:35.1699694616998,west:139.999655591133,south:35.0033280167192,east:140.249641242241,note:'明治36年測図・明治39.6.30発行',list:'68-14-1'},
    {name:'大原',north:35.3366242427606,west:140.249627963904,south:35.1699828923847,east:140.499613731636,note:'明治36年測図・明治39.6.30発行',list:'68-9-1'},
    {name:'檜枝岐',north:37.1697227871129,west:139.249637267163,south:37.0030820981076,east:139.499622736643,note:'大正1年測図・大正4.8.30発行',list:'74-10-2'},
    {name:'燧ヶ岳',north:37.003075242224,west:139.249644377474,south:36.8364344872844,east:139.49962983555,note:'大正1年測図・大正2.4.30発行',list:'74-11-1'},
    {name:'男体山',north:36.8364276576945,west:139.249651429343,south:36.669786846616,east:139.49963687613,note:'大正1年測図・大正2.4.30発行',list:'74-12-1'},
    {name:'八海山',north:37.1697159508137,west:138.999659017312,south:37.003075242224,east:139.249644377474,note:'大正1年測図・大正3.3.30発行',list:'74-14-1'},
    {name:'藤原',north:37.0030684319841,west:138.999666080059,south:36.8364276576945,east:139.249651429343,note:'大正1年測図・大正2.4.30発行',list:'74-15-1'},
    {name:'追貝',north:36.8364208735734,west:138.999673084757,south:36.6697800433795,east:139.249658423272,note:'大正1年測図・大正2.4.30発行',list:'74-16-1'},
    {name:'那須岳',north:37.1697365970356,west:139.74959395295,south:37.0030959462837,east:139.999579641893,note:'明治42年測図・明治43.7.30発行',list:'74-2-1'},
    {name:'塩原',north:37.0030889995046,west:139.749601157979,south:36.8364482823498,east:139.999586834468,note:'明治40年測図・明治43.7.30発行',list:'74-3-1'},
    {name:'矢板',north:36.8364413622131,west:139.749608303788,south:36.6698005884502,east:139.999593967947,note:'明治42年測図・明治43.5.30発行',list:'74-4-1'},
    {name:'糸沢',north:37.1697296692305,west:139.499615578905,south:37.0030889995046,east:139.749601157979,note:'大正1年測図・大正3.3.30発行',list:'74-6-1'},
    {name:'川治',north:37.0030820981076,west:139.499622736643,south:36.8364413622131,east:139.749608303788,note:'大正1年測図・大正2.4.30発行',list:'74-7-1'},
    {name:'日光',north:36.8364344872844,west:139.49962983555,south:36.6697936950164,east:139.749615390885,note:'大正1年測図・大正2.4.30発行',list:'74-8-1'},
    {name:'宇都宮',north:36.6697936950164,west:139.749615390885,south:36.5031528444449,east:139.999601042836,note:'明治42年補測・明治42.8.30発行',list:'75-1-1'},
    {name:'桐生及足利',north:36.503132379138,west:139.249665359756,south:36.3364914251783,east:139.499650784298,note:'明治40年測図・明治42.7.30発行',list:'75-10-1'},
    {name:'深谷',north:36.3364846748266,west:139.249672239284,south:36.1698436641232,east:139.499657652863,note:'明治40年測図・明治43.2.28発行',list:'75-11-1'},
    {name:'熊谷',north:36.1698369403024,west:139.249679062338,south:36.003195852658,east:139.499664465057,note:'明治40年測図・明治43.1.30発行',list:'75-12-1'},
    {name:'沼田',north:36.6697732854363,west:138.999680031901,south:36.503132379138,east:139.249665359756,note:'明治40年測図・明治43.4.30発行',list:'75-13-1'},
    {name:'前橋',north:36.5031256474318,west:138.999686921986,south:36.3364846748266,east:139.249672239284,note:'明治40年測図・明治44.11.30発行',list:'75-14-2'},
    {name:'高崎',north:36.3364779694161,west:138.999693755495,south:36.1698369403024,east:139.249679062338,note:'明治40年測図・明治44.11.30発行',list:'75-15-2'},
    {name:'寄居',north:36.1698302612462,west:138.999700532907,south:36.0031891554269,east:139.249685829394,note:'明治40年測図・明治43.7.30発行',list:'75-16-1'},
    {name:'壬生',north:36.5031459777739,west:139.749622419772,south:36.3365050601908,east:139.999608059632,note:'明治40年測図・明治42.8.30発行',list:'75-2-1'},
    {name:'結城',north:36.3364982203428,west:139.749629390945,south:36.1698572455459,east:139.999615018826,note:'明治40年測図・明治42.7.30発行',list:'75-3-1'},
    {name:'水海道',north:36.1698504325806,west:139.74963630489,south:36.0032093803722,east:139.999621920906,note:'明治40年測図・明治45.3.30発行',list:'75-4-15'},
    {name:'鹿沼',north:36.669786846616,west:139.49963687613,south:36.5031459777739,east:139.749622419772,note:'明治40年測図・明治43.3.30発行',list:'75-5-1'},
    {name:'栃木',north:36.5031391559617,west:139.499643858882,south:36.3364982203428,east:139.749629390945,note:'明治40年測図・明治42.12.28発行',list:'75-6-1'},
    {name:'古河',north:36.3364914251783,west:139.499650784298,south:36.1698504325806,east:139.74963630489,note:'明治40年測図・明治42.12.28発行',list:'75-7-1'},
    {name:'鴻巣',north:36.1698436641232,west:139.499657652863,south:36.0032025943492,east:139.749643162092,note:'明治40年測図・明治42.8.30発行',list:'75-8-1'},
    {name:'足尾',north:36.6697800433795,west:139.249658423272,south:36.5031391559617,east:139.499643858882,note:'明治40年測図・明治43.1.30発行',list:'75-9-1'},
    {name:'粕壁',north:36.0032025943492,west:139.749643162092,south:35.8365614745293,east:139.99962876635,note:'明治39年測図・明治43.10.30発行',list:'76-1-1'},
    {name:'青梅',north:35.8365413300588,west:139.249692540921,south:35.6699001179339,east:139.499677922215,note:'明治41年測図',list:'76-10-1'},
    {name:'八王子',north:35.6698934740576,west:139.249699197385,south:35.5032521843988,east:139.499684568108,note:'明治39年測図・明治43.7.30発行',list:'76-11-1'},
    {name:'藤沢',north:35.5032455672871,west:139.249705799242,south:35.3366042098975,east:139.499691159485,note:'明治42年測図・大正2.4.30発行',list:'76-12-2'},
    {name:'秩父大宮',north:36.0031825027833,west:138.999707254697,south:35.8365413300588,east:139.249692540921,note:'明治40年測図・明治43.7.30発行',list:'76-13-1'},
    {name:'五日市',north:35.836534703886,west:138.999713921329,south:35.6698934740576,east:139.249699197385,note:'明治40年測図・明治43.7.30発行',list:'76-14-1'},
    {name:'上野原',north:35.6698868744136,west:138.999720533266,south:35.5032455672871,east:139.249705799242,note:'明治29年修正・明治31.12.25発行',list:'76-15-1'},
    {name:'松田惣領',north:35.5032389942295,west:138.999727090961,south:35.3365976196082,east:139.249712346944,note:'明治29年修正・明治31.12.25発行',list:'76-16-1'},
    {name:'東京東北部',north:35.8365547155077,west:139.749649963026,south:35.6699135378772,east:139.99963555563,note:'明治42年測図・大正8.1.30発行',list:'76-2-2'},
    {name:'東京東南部',north:35.6699068059162,west:139.749656708162,south:35.5032655502803,east:139.999642289214,note:'明治42年測図',list:'76-3-1'},
    {name:'木更津',north:35.5032588454388,west:139.749663397965,south:35.3366175216003,east:139.999648967564,note:'明治36年測図・明治44.3.8発行',list:'76-4-1'},
    {name:'大宮',north:36.003195852658,west:139.499664465057,south:35.8365547155077,east:139.749649963026,note:'明治39年測図・明治43.8.30発行',list:'76-5-1'},
    {name:'東京西北部',north:35.8365480006416,west:139.499671221352,south:35.6699068059162,east:139.749656708162,note:'明治45年部修大正4年鉄補・大正8.1.30発行',list:'76-6-1'},
    {name:'東京西南部',north:35.6699001179339,west:139.499677922215,south:35.5032588454388,east:139.749663397965,note:'明治45年縮図',list:'76-7-1'},
    {name:'横浜',north:35.5032521843988,west:139.499684568108,south:35.3366108439369,east:139.749670032891,note:'明治45年部修・明治45.7.25発行',list:'76-8-1'},
    {name:'川越',north:36.0031891554269,west:139.249685829394,south:35.8365480006416,east:139.499671221352,note:'明治40年測図・明治43.4.30発行',list:'76-9-1'},
    {name:'富津',north:35.3366108439369,west:139.749670032891,south:35.1699694616998,east:139.999655591133,note:'明治36年測図・明治43.4.2発行',list:'77-1-1'},
    {name:'小田原',north:35.3365910731946,west:138.999733594865,south:35.1699496408829,east:139.249718840938,note:'明治29年修正・明治31.12.25発行',list:'77-13-1'},
    {name:'熱海',north:35.1699431211704,west:138.999740045419,south:35.003301610977,east:139.249725281665,note:'明治29年修正・明治31.12.25発行',list:'77-14-1'},
    {name:'玖須美',north:35.0032951180227,west:138.999746443062,south:34.8366535397539,east:139.249731669558,note:'明治29年修正・明治31.12.25発行',list:'77-15-1'},
    {name:'那古',north:35.1699628112729,west:139.749676613393,south:35.0033213504453,east:139.999662160371,note:'明治36年測図・明治39.6.30発行',list:'77-2-1'},
    {name:'北條',north:35.0033147273131,west:139.749683139919,south:34.8366731977009,east:139.999668675723,note:'明治36年測図・明治38.6.30発行',list:'77-3-1'},
    {name:'横須賀',north:35.3366042098975,west:139.499691159485,south:35.1699628112729,east:139.749676613393,note:'明治36年測図・明治44.10.21発行',list:'77-5-1'},
    {name:'三崎',north:35.169956204292,west:139.499697696796,south:35.0033147273131,east:139.749683139919,note:'明治36年修正・明治43.3.26発行',list:'77-6-1'},
    {name:'平塚',north:35.3365976196082,west:139.249712346944,south:35.169956204292,east:139.499697696796,note:'明治27年修正・明治31.12.25発行',list:'77-9-1'},
    {name:'高田東部',north:37.1696957181234,west:138.249724634951,south:37.0030549489532,east:138.499709668841,note:'明治44年測図・大正4.11.30発行',list:'82-10-2'},
    {name:'飯山',north:37.0030482764187,west:138.249731554207,south:36.8364074422528,east:138.499716578796,note:'明治44年測図・大正3.11.30発行',list:'82-11-2'},
    {name:'中野',north:36.8364007953089,west:138.249738416593,south:36.6697599059432,east:138.499723431976,note:'大正1年測図・大正4.10.30発行',list:'82-12-2'},
    {name:'十日町',north:37.1697091604631,west:138.749680828936,south:37.0030684319841,east:138.999666080059,note:'明治44年測図・大正3.7.30発行',list:'82-2-2'},
    {name:'湯沢',north:37.0030616675176,west:138.749687843987,south:36.8364208735734,east:138.999673084757,note:'大正1年測図・大正3.5.30発行',list:'82-3-1'},
    {name:'四万',north:36.8364141350501,west:138.749694801379,south:36.6697732854363,east:138.999680031901,note:'大正1年測図・大正3.5.30発行',list:'82-4-1'},
    {name:'松之山温泉',north:37.1697024161902,west:138.499702701621,south:37.0030616675176,east:138.749687843987,note:'明治44年測図・大正3.11.30発行',list:'82-6-2'},
    {name:'苗場山',north:37.0030549489532,west:138.499709668841,south:36.8364141350501,east:138.749694801379,note:'大正1年測図・大正4.6.30発行',list:'82-7-2'},
    {name:'岩菅山',north:36.8364074422528,west:138.499716578796,south:36.669766572915,east:138.749701701607,note:'大正1年測図・大正3.2.28発行',list:'82-8-1'},
    {name:'中之条',north:36.669766572915,west:138.749701701607,south:36.5031256474318,east:138.999686921986,note:'大正1年測図・大正3.12.28発行',list:'83-1-1'},
    {name:'上田',north:36.5031057242943,west:138.249751972697,south:36.3364646939282,east:138.49973696995,note:'大正1年測図・大正4.1.30発行',list:'83-10-1'},
    {name:'小諸',north:36.3364581241033,west:138.249758667373,south:36.169817037935,east:138.499743655694,note:'大正1年測図・大正4.3.30発行',list:'83-11-1'},
    {name:'蓼科山',north:36.1698104939316,west:138.249765307091,south:36.0031693317644,east:138.499750286568,note:'大正1年測図・大正4.3.30発行',list:'83-12-1'},
    {name:'榛名山',north:36.5031189609711,west:138.74970854516,south:36.3364779694161,east:138.999693755495,note:'明治40年測図・大正2.11.30発行',list:'83-2-1'},
    {name:'富岡',north:36.3364713090743,west:138.74971533252,south:36.1698302612462,east:138.999700532907,note:'明治40年測図・大正3.2.28発行',list:'83-3-1'},
    {name:'万場',north:36.1698236270817,west:138.749722064163,south:36.0031825027833,east:138.999707254697,note:'大正1年測図・大正4.5.30発行',list:'83-4-1'},
    {name:'草津',north:36.6697599059432,west:138.499723431976,south:36.5031189609711,east:138.74970854516,note:'大正1年測図・大正4.1.30発行',list:'83-5-1'},
    {name:'軽井沢',north:36.5031123198831,west:138.499730228868,south:36.3364713090743,east:138.74971533252,note:'大正1年測図・大正4.1.30発行',list:'83-6-1'},
    {name:'御代田',north:36.3364646939282,west:138.49973696995,south:36.1698236270817,east:138.749722064163,note:'大正1年測図・大正4.3.30発行',list:'83-7-1'},
    {name:'十石峠',north:36.169817037935,west:138.499743655694,south:36.0031758948539,east:138.749728740558,note:'大正1年測図・大正3.11.30発行',list:'83-8-1'},
    {name:'須坂',north:36.669753284648,west:138.249745222596,south:36.5031123198831,east:138.499730228868,note:'大正1年測図・大正2.2.28発行',list:'83-9-1'},
    {name:'三峰',north:36.0031758948539,west:138.749728740558,south:35.836534703886,east:138.999713921329,note:'明治43年測図・大正2.4.30発行',list:'84-1-1'},
    {name:'韮崎',north:35.8365150930853,west:138.249778423507,south:35.6698738083241,east:138.499763385537,note:'明治43年測図・大正4.5.30発行',list:'84-10-1'},
    {name:'鰍沢',north:35.6698673421272,west:138.249784901112,south:35.5032259807763,east:138.499769854536,note:'明治43年測図・大正4.6.30発行',list:'84-11-1'},
    {name:'身延',north:35.5032195406282,west:138.249791325578,south:35.3365781124914,east:138.499776270471,note:'明治43年測図・大正4.2.28発行',list:'84-12-1'},
    {name:'丹波',north:35.8365281222495,west:138.749735362169,south:35.6698868744136,east:138.999720533266,note:'明治43年測図・大正2.3.30発行',list:'84-2-1'},
    {name:'谷村',north:35.6698803191275,west:138.749741929452,south:35.5032389942295,east:138.999727090961,note:'明治29年修正・明治32.02.28発行',list:'84-3-1'},
    {name:'山中湖',north:35.5032324653512,west:138.749748442862,south:35.3365910731946,east:138.999733594865,note:'明治29年修正・明治32.02.28発行',list:'84-4-1AB'},
    {name:'金峰山',north:36.0031693317644,west:138.499750286568,south:35.8365281222495,east:138.749735362169,note:'明治43年測図・大正2.6.30発行',list:'84-5-1'},
    {name:'塩山',north:35.8365215852745,west:138.499756863031,south:35.6698803191275,east:138.749741929452,note:'明治43年測図・大正4.4.30発行',list:'84-6-1'},
    {name:'甲府市',north:35.6698738083241,west:138.499763385537,south:35.5032324653512,east:138.749748442862,note:'明治29年修正・明治32.02.28発行',list:'84-7-1'},
    {name:'富士山',north:35.5032259807763,west:138.499769854536,south:35.336584570781,east:138.749754902842,note:'明治29年修正・明治32.02.28発行',list:'84-8-1'},
    {name:'八ヶ岳',north:36.0031628136396,west:138.249771892317,south:35.8365215852745,east:138.499756863031,note:'明治43年測図・大正2.6.30発行',list:'84-9-1'},
    {name:'御殿場',north:35.336584570781,west:138.749754902842,south:35.1699431211704,east:138.999740045419,note:'明治29年修正・明治32.06.30発行',list:'85-1-21'},
    {name:'清水町',north:35.169923825449,west:138.249804016845,south:35.0032822631593,east:138.499788944889,note:'明治29年修正・明治42.7.20発行',list:'85-10-1'},
    {name:'静岡市',north:35.0032759014949,west:138.24981028451,south:34.8366342718402,east:138.49979520423,note:'明治28年修正・明治42.7.20発行',list:'85-11-1'},
    {name:'沼津町',north:35.1699366452786,west:138.749761309834,south:35.0032951180227,east:138.999746443062,note:'明治28年修正・明治32.06.30発行',list:'85-2-1'},
    {name:'修善寺',north:35.0032886687092,west:138.749767664271,south:34.8366470736147,east:138.999752788225,note:'明治29年修正・明治32.06.30発行',list:'85-3-1'},
    {name:'大宮',north:35.3365781124914,west:138.499776270471,south:35.1699366452786,east:138.749761309834,note:'明治29年修正・明治32.06.30発行',list:'85-5-1'},
    {name:'吉原町',north:35.1699302133307,west:138.499782633778,south:35.0032886687092,east:138.749767664271,note:'明治28年修正・明治42.7.20発行',list:'85-6-1'},
    {name:'駒越',north:35.0032822631593,west:138.499788944889,south:34.836640650936,east:138.749773966583,note:'明治27年修正・明治32.06.30発行',list:'85-7-1'},
    {name:'南部',north:35.3365716984485,west:138.249797697344,south:35.1699302133307,east:138.499782633778,note:'明治41年測図・明治45.5.30発行',list:'85-9-1'}
]});
dataset.age.push({
  folderName:'01', start:1928, end:1945, scale:'1/50000', mapList: [
    {name:'棚倉',north:37.1697505891802,west:140.249550889594,south:37.0031099754583,east:140.499536799089,note:'昭和8年要修・昭和11.8.30発行',list:'65-10-3'},
    {name:'塙',north:37.0031029383126,west:140.249558188793,south:36.8364622577195,east:140.499544084786,note:'昭和8年要修・昭和11.5.30発行',list:'65-11-2'},
    {name:'大子',north:36.8364552475628,west:140.249565427998,south:36.6698145098931,east:140.499551310622,note:'昭和8年要修・昭和11.1.30発行',list:'65-12-4'},
    {name:'白河',north:37.1697435703964,west:139.999572389709,south:37.0031029383126,east:140.249558188793,note:'昭和8年部修・昭和11.1.30発行',list:'65-14-5'},
    {name:'大田原',north:37.0030959462837,west:139.999579641893,south:36.8364552475628,east:140.249565427998,note:'昭和4年修正・昭和8.4.30発行',list:'65-15-4'},
    {name:'喜連川',north:36.8364482823498,west:139.999586834468,south:36.6698075267865,east:140.249572607724,note:'昭和4年二修・昭和8.5.30発行',list:'65-16-4'},
    {name:'大津',north:36.8364693126867,west:140.749522805238,south:36.6698286098851,east:140.999508907401,note:'昭和8年修正・昭和11.4.30発行',list:'65-4-2AB',war:true},
    {name:'竹貫',north:37.1697576532534,west:140.499529453012,south:37.0031170575869,east:140.749515473187,note:'昭和8年要修・昭和11.5.30発行',list:'65-6-2'},
    {name:'小川',north:37.0031099754583,west:140.499536799089,south:36.8364693126867,east:140.749522805238,note:'昭和8年要修・昭和11.3.30発行',list:'65-7-2'},
    {name:'高萩',north:36.8364622577195,west:140.499544084786,south:36.6698215376372,east:140.749530077046,note:'昭和8年要修・昭和11.1.30発行',list:'65-8-3'},
    {name:'水戸',north:36.5031597558438,west:140.249579728479,south:36.3365188734157,east:140.49956558475,note:'昭和15年二修・昭和22.4.30発行',list:'66-10-8'},
    {name:'石岡',north:36.3365119445921,west:140.249586790765,south:36.1698710044806,east:140.499572634044,note:'昭和15年二修・昭和22.4.30発行',list:'66-11-6'},
    {name:'玉造',north:36.1698641028894,west:140.249593795076,south:36.0032230848966,east:140.499579625484,note:'昭和19年部修・昭和22.5.30発行',list:'66-12-5'},
    {name:'烏山',north:36.6698005884502,west:139.999593967947,south:36.5031597558438,east:140.249579728479,note:'昭和15年二修・昭和22.4.30発行',list:'66-13-11'},
    {name:'真岡',north:36.5031528444449,west:139.999601042836,south:36.3365119445921,east:140.249586790765,note:'昭和15年修正・昭和22.1.30発行',list:'66-14-6'},
    {name:'真壁',north:36.3365050601908,west:139.999608059632,south:36.1698641028894,east:140.249593795076,note:'昭和15年二修・昭和18.6.30発行',list:'66-15-17',war:true},
    {name:'土浦',north:36.1698572455459,west:139.999615018826,south:36.003216210598,east:140.249600741902,note:'昭和19年部修・昭和22.7.30発行',list:'66-16-4'},
    {name:'日立',north:36.6698145098931,west:140.499551310622,south:36.503173712299,east:140.749537289127,note:'昭和15年三修・昭和22.4.30発行',list:'66-5-5'},
    {name:'那珂湊',north:36.5031667118393,west:140.499558477108,south:36.3365258465299,east:140.749544441989,note:'昭和15年修正・昭和22.6.30発行',list:'66-6-8'},
    {name:'磯浜',north:36.3365188734157,west:140.49956558475,south:36.1698779501883,east:140.749551536133,note:'昭和15年修正・昭和18.6.30発行',list:'66-7-17',war:true},
    {name:'鉾田',north:36.1698710044806,west:140.499572634044,south:36.0032300031371,east:140.749558572054,note:'昭和19年部修・昭和21.11.30発行',list:'66-8-5'},
    {name:'常陸大宮',north:36.6698075267865,west:140.249572607724,south:36.5031667118393,east:140.499558477108,note:'昭和15年二修・昭和22.4.30発行',list:'66-9-6'},
    {name:'成田',north:35.8365682775776,west:140.249607631725,south:35.6699271332219,east:140.499593436735,note:'昭和19年部修・昭和22.5.30発行',list:'67-10-7'},
    {name:'東金',north:35.6699203136887,west:140.24961446502,south:35.5032790908566,east:140.499600257499,note:'昭和19年部修・昭和21.11.30発行',list:'67-11-6'},
    {name:'茂原',north:35.5032722987957,west:140.249621242259,south:35.3366310072899,east:140.499607022312,note:'昭和19年部修・昭和21.11.30発行',list:'67-12-3'},
    {name:'龍ヶ崎',north:36.0032093803722,west:139.999621920906,south:35.8365682775776,east:140.249607631725,note:'昭和19年部修・昭和22.5.30発行',list:'67-13-4'},
    {name:'佐倉',north:35.8365614745293,west:139.99962876635,south:35.6699203136887,east:140.24961446502,note:'昭和19年部修・昭和21.10.30発行',list:'67-14-6'},
    {name:'千葉',north:35.6699135378772,west:139.99963555563,south:35.5032722987957,east:140.249621242259,note:'昭和19年部修・昭和22.5.30発行',list:'67-15-7'},
    {name:'姉崎',north:35.5032655502803,west:139.999642289214,south:35.3366242427606,east:140.249627963904,note:'昭和19年部修・昭和22.5.30発行',list:'67-16-7'},
    {name:'銚子',north:35.8365820152364,west:140.749565550241,south:35.6699409029333,east:140.999551568739,note:'昭和19年部修・昭和22.5.30発行',list:'67-2-6'},
    {name:'潮来',north:36.0032230848966,west:140.499579625484,south:35.8365827067098,east:140.774563452782,note:'昭和19年部修・昭和22.5.30発行',list:'67-5-5'},
    {name:'八日市場',north:35.8365751245235,west:140.499586559555,south:35.6699339963469,east:140.749572471175,note:'昭和19年部修・昭和22.5.30発行',list:'67-6-6'},
    {name:'木戸',north:35.6699271332219,west:140.499593436735,south:35.5032859263338,east:140.749579335334,note:'昭和19年部修・昭和21.11.30発行',list:'67-7-3'},
    {name:'佐原',north:36.003216210598,west:140.249600741902,south:35.8365751245235,east:140.499586559555,note:'昭和19年部修・昭和22.5.30発行',list:'67-9-5'},
    {name:'勝浦',north:35.1699761554461,west:140.249634630414,south:35.003334726008,east:140.499620385925,note:'昭和19年部修・昭和22.5.30発行',list:'68-10-5'},
    {name:'大多喜',north:35.3366175216003,west:139.999648967564,south:35.1699761554461,east:140.249634630414,note:'昭和19年部修・昭和22.5.30発行',list:'68-13-7'},
    {name:'鴨川',north:35.1699694616998,west:139.999655591133,south:35.0033280167192,east:140.249641242241,note:'昭和19年部修・昭和22.5.30発行',list:'68-14-4'},
    {name:'上総大原',north:35.3366242427606,west:140.249627963904,south:35.1699828923847,east:140.499613731636,note:'昭和19年部修・昭和22.7.30発行',list:'68-9-6'},
    {name:'檜枝岐',north:37.1697227871129,west:139.249637267163,south:37.0030820981076,east:139.499622736643,note:'昭和8年要修・昭和11.1.30発行',list:'74-10-5'},
    {name:'燧ヶ岳',north:37.003075242224,west:139.249644377474,south:36.8364344872844,east:139.49962983555,note:'昭和6年要修・昭和8.1.30発行',list:'74-11-3'},
    {name:'男体山',north:36.8364276576945,west:139.249651429343,south:36.669786846616,east:139.49963687613,note:'昭和4年要修・昭和6.7.30発行',list:'74-12-3'},
    {name:'八海山',north:37.1697159508137,west:138.999659017312,south:37.003075242224,east:139.249644377474,note:'昭和6年要修・昭和8.2.28発行',list:'74-14-3'},
    {name:'藤原',north:37.0030684319841,west:138.999666080059,south:36.8364276576945,east:139.249651429343,note:'昭和6年要修・昭和8.8.30発行',list:'74-15-14'},
    {name:'追貝',north:36.8364208735734,west:138.999673084757,south:36.6697800433795,east:139.249658423272,note:'昭和4年要修・昭和7.3.30発行',list:'74-16-3'},
    {name:'那須岳',north:37.1697365970356,west:139.74959395295,south:37.0030959462837,east:139.999579641893,note:'昭和8年要修・昭和11.3.30発行',list:'74-2-2'},
    {name:'塩原',north:37.0030889995046,west:139.749601157979,south:36.8364482823498,east:139.999586834468,note:'昭和4年修正・昭和7.4.30発行',list:'74-3-5'},
    {name:'矢板',north:36.8364413622131,west:139.749608303788,south:36.6698005884502,east:139.999593967947,note:'昭和4年二修・昭和7.6.30発行',list:'74-4-4'},
    {name:'糸沢',north:37.1697296692305,west:139.499615578905,south:37.0030889995046,east:139.749601157979,note:'昭和8年要修・昭和11.1.30発行',list:'74-6-3'},
    {name:'川治',north:37.0030820981076,west:139.499622736643,south:36.8364413622131,east:139.749608303788,note:'昭和8年要修・昭和11.5.30発行',list:'74-7-5'},
    {name:'日光',north:36.8364344872844,west:139.49962983555,south:36.6697936950164,east:139.749615390885,note:'昭和4年修正8年鉄補・昭和10.4.30発行',list:'74-8-6'},
    {name:'宇都宮',north:36.6697936950164,west:139.749615390885,south:36.5031528444449,east:139.999601042836,note:'昭和4年二修8年鉄補・昭和9.6.30発行',list:'75-1-5'},
    {name:'桐生及足利',north:36.503132379138,west:139.249665359756,south:36.3364914251783,east:139.499650784298,note:'昭和9年要修・昭和15.12.28発行',list:'75-10-17',war:true},
    {name:'深谷',north:36.3364846748266,west:139.249672239284,south:36.1698436641232,east:139.499657652863,note:'昭和14年要修・昭和15.9.30発行',list:'75-11-19',war:true},
    {name:'熊谷',north:36.1698369403024,west:139.249679062338,south:36.003195852658,east:139.499664465057,note:'昭和14年部修・昭和15.9.30発行',list:'75-12-18',war:true},
    {name:'沼田',north:36.6697732854363,west:138.999680031901,south:36.503132379138,east:139.249665359756,note:'昭和4年修正・昭和7.6.30発行',list:'75-13-11'},
    {name:'前橋',north:36.5031256474318,west:138.999686921986,south:36.3364846748266,east:139.249672239284,note:'昭和9年要修・昭和15.11.30発行',list:'75-14-22',war:true},
    {name:'高崎',north:36.3364779694161,west:138.999693755495,south:36.1698369403024,east:139.249679062338,note:'昭和9年要修・昭和15.7.30発行',list:'75-15-6',war:true},
    {name:'寄居',north:36.1698302612462,west:138.999700532907,south:36.0031891554269,east:139.249685829394,note:'昭和14年部修・昭和21.10.30発行',list:'75-16-5'},
    {name:'壬生',north:36.5031459777739,west:139.749622419772,south:36.3365050601908,east:139.999608059632,note:'昭和9年要修・昭和15.10.30発行',list:'75-2-6'},
    {name:'結城',north:36.3364982203428,west:139.749629390945,south:36.1698572455459,east:139.999615018826,note:'昭和9年要修・昭和15.11.30発行',list:'75-3-5',war:true},
    {name:'水海道',north:36.1698504325806,west:139.74963630489,south:36.0032093803722,east:139.999621920906,note:'昭和9年要修・昭和15.9.30発行',list:'75-4-16',war:true},
    {name:'鹿沼',north:36.669786846616,west:139.49963687613,south:36.5031459777739,east:139.749622419772,note:'昭和4年要修・昭和6.8.30発行',list:'75-5-2',war:true},
    {name:'栃木',north:36.5031391559617,west:139.499643858882,south:36.3364982203428,east:139.749629390945,note:'昭和9年要修・昭和16.2.28発行',list:'75-6-6'},
    {name:'古河',north:36.3364914251783,west:139.499650784298,south:36.1698504325806,east:139.74963630489,note:'昭和9年要修・昭和15.12.28発行',list:'75-7-4'},
    {name:'鴻巣',north:36.1698436641232,west:139.499657652863,south:36.0032025943492,east:139.749643162092,note:'昭和9年要修・昭和21.9.25発行',list:'75-8-2'},
    {name:'足尾',north:36.6697800433795,west:139.249658423272,south:36.5031391559617,east:139.499643858882,note:'昭和4年要修・昭和6.8.30発行',list:'75-9-3'},
    {name:'野田',north:36.0032025943492,west:139.749643162092,south:35.8365614745293,east:139.99962876635,note:'昭和3年修正・昭和21.10.30発行',list:'76-1-5'},
    {name:'青梅',north:35.8365413300588,west:139.249692540921,south:35.6699001179339,east:139.499677922215,note:'昭和20年部修・昭和22.5.30発行',list:'76-10-9'},
    {name:'八王子',north:35.6698934740576,west:139.249699197385,south:35.5032521843988,east:139.499684568108,note:'昭和20年部修・昭和22.5.30発行',list:'76-11-8'},
    {name:'藤沢',north:35.5032455672871,west:139.249705799242,south:35.3366042098975,east:139.499691159485,note:'昭和20年部修・昭和22.5.30発行',list:'76-12-11'},
    {name:'秩父',north:36.0031825027833,west:138.999707254697,south:35.8365413300588,east:139.249692540921,note:'昭和4年要修・昭和21.9.30発行',list:'76-13-5'},
    {name:'五日市',north:35.836534703886,west:138.999713921329,south:35.6698934740576,east:139.249699197385,note:'昭和4年要修・昭和22.6.30発行',list:'76-14-3'},
    {name:'上野原',north:35.6698868744136,west:138.999720533266,south:35.5032455672871,east:139.249705799242,note:'昭和4年三修・昭和22.6.30発行',list:'76-15-4'},
    {name:'秦野',north:35.5032389942295,west:138.999727090961,south:35.3365976196082,east:139.249712346944,note:'昭和20年部修・昭和21.10.30発行',list:'76-16-5'},
    {name:'東京東北部',north:35.8365547155077,west:139.749649963026,south:35.6699135378772,east:139.99963555563,note:'昭和7年要修・昭和7.12.28発行',list:'76-2-7'},
    {name:'東京東南部',north:35.6699068059162,west:139.749656708162,south:35.5032655502803,east:139.999642289214,note:'昭和7年要修・昭和7.11.30発行',list:'76-3-7'},
    {name:'木更津',north:35.5032588454388,west:139.749663397965,south:35.3366175216003,east:139.999648967564,note:'昭和19年部修・昭和21.11.30発行',list:'76-4-6'},
    {name:'大宮',north:36.003195852658,west:139.499664465057,south:35.8365547155077,east:139.749649963026,note:'大正13年修正昭和4年鉄補・昭和21.9.25発行',list:'76-5-4'},
    {name:'東京西北部',north:35.8365480006416,west:139.499671221352,south:35.6699068059162,east:139.749656708162,note:'昭和7年要修・昭和9.7.30発行',list:'76-6-22',war:true},
    {name:'東京西南部',north:35.6699001179339,west:139.499677922215,south:35.5032588454388,east:139.749663397965,note:'昭和7年要修・昭和9.7.30発行',list:'76-7-26'},
    {name:'横浜',north:35.5032521843988,west:139.499684568108,south:35.3366108439369,east:139.749670032891,note:'昭和7年二修・昭和9.9.25発行',list:'76-8-5'},
    {name:'川越',north:36.0031891554269,west:139.249685829394,south:35.8365480006416,east:139.499671221352,note:'昭和14年二部・昭和16.4.30発行',list:'76-9-6',war:true},
    {name:'富津',north:35.3366108439369,west:139.749670032891,south:35.1699694616998,east:139.999655591133,note:'昭和19年部修・昭和22.5.30発行',list:'77-1-8'},
    {name:'小田原',north:35.3365910731946,west:138.999733594865,south:35.1699496408829,east:139.249718840938,note:'昭和20年部修・昭和23.5.30発行',list:'77-13-10'},
    {name:'熱海',north:35.1699431211704,west:138.999740045419,south:35.003301610977,east:139.249725281665,note:'昭和20年部修・昭和22.5.30発行',list:'77-14-7'},
    {name:'伊東',north:35.0032951180227,west:138.999746443062,south:34.8366535397539,east:139.249731669558,note:'昭和19年部修・昭和21.11.30発行',list:'77-15-3'},
    {name:'那古',north:35.1699628112729,west:139.749676613393,south:35.0033213504453,east:139.999662160371,note:'昭和19年部修・昭和22.5.30発行',list:'77-2-7'},
    {name:'館山',north:35.0033147273131,west:139.749683139919,south:34.8366731977009,east:139.999668675723,note:'昭和19年部修・昭和22.7.30発行',list:'77-3-5'},
    {name:'横須賀',north:35.3366042098975,west:139.499691159485,south:35.1699628112729,east:139.749676613393,note:'昭和19年部修・昭和22.5.30発行',list:'77-5-4'},
    {name:'三崎',north:35.169956204292,west:139.499697696796,south:35.0033147273131,east:139.749683139919,note:'昭和19年部修・昭和22.5.30発行',list:'77-6-4'},
    {name:'平塚',north:35.3365976196082,west:139.249712346944,south:35.169956204292,east:139.499697696796,note:'昭和20年部修・昭和22.5.30発行',list:'77-9-8'},
    {name:'高田東部',north:37.1696957181234,west:138.249724634951,south:37.0030549489532,east:138.499709668841,note:'昭和5年修正・昭和8.12.28発行',list:'82-10-13'},
    {name:'飯山',north:37.0030482764187,west:138.249731554207,south:36.8364074422528,east:138.499716578796,note:'昭和5年修正・昭和8.11.30発行',list:'82-11-14',war:true},
    {name:'中野',north:36.8364007953089,west:138.249738416593,south:36.6697599059432,east:138.499723431976,note:'昭和12年二修・昭和13.5.30発行',list:'82-12-15',war:true},
    {name:'十日町',north:37.1697091604631,west:138.749680828936,south:37.0030684319841,east:138.999666080059,note:'昭和6年修正・昭和10.5.30発行',list:'82-2-11'},
    {name:'越後湯沢',north:37.0030616675176,west:138.749687843987,south:36.8364208735734,east:138.999673084757,note:'昭和6年要修・昭和21.12.28発行',list:'82-3-4'},
    {name:'四万',north:36.8364141350501,west:138.749694801379,south:36.6697732854363,east:138.999680031901,note:'昭和4年要修・昭和21.12.28発行',list:'82-4-3'},
    {name:'松之山温泉',north:37.1697024161902,west:138.499702701621,south:37.0030616675176,east:138.749687843987,note:'昭和6年修正・昭和9.8.30発行',list:'82-6-14'},
    {name:'苗場山',north:37.0030549489532,west:138.499709668841,south:36.8364141350501,east:138.749694801379,note:'昭和6年要修・昭和8.2.28発行',list:'82-7-10',war:true},
    {name:'岩菅山',north:36.8364074422528,west:138.499716578796,south:36.669766572915,east:138.749701701607,note:'昭和6年要修・昭和8.2.28発行',list:'82-8-12'},
    {name:'中之条',north:36.669766572915,west:138.749701701607,south:36.5031256474318,east:138.999686921986,note:'昭和4年要修・昭和7.3.30発行',list:'83-1-2'},
    {name:'上田',north:36.5031057242943,west:138.249751972697,south:36.3364646939282,east:138.49973696995,note:'昭和12年二修・昭和12.8.30発行',list:'83-10-4'},
    {name:'小諸',north:36.3364581241033,west:138.249758667373,south:36.169817037935,east:138.499743655694,note:'昭和4年修正・昭和8.3.30発行',list:'83-11-4'},
    {name:'蓼科山',north:36.1698104939316,west:138.249765307091,south:36.0031693317644,east:138.499750286568,note:'昭和4年要修・昭和7.7.30発行',list:'83-12-3'},
    {name:'榛名山',north:36.5031189609711,west:138.74970854516,south:36.3364779694161,east:138.999693755495,note:'昭和9年要修・昭和15.11.30発行',list:'83-2-16',war:true},
    {name:'富岡',north:36.3364713090743,west:138.74971533252,south:36.1698302612462,east:138.999700532907,note:'昭和9年要修・昭和15.8.30発行',list:'83-3-4',war:true},
    {name:'万場',north:36.1698236270817,west:138.749722064163,south:36.0031825027833,east:138.999707254697,note:'昭和9年要修・昭和15.7.30発行',list:'83-4-3',war:true},
    {name:'草津',north:36.6697599059432,west:138.499723431976,south:36.5031189609711,east:138.74970854516,note:'昭和12年修正・昭和12.8.30発行',list:'83-5-4',war:true},
    {name:'軽井沢',north:36.5031123198831,west:138.499730228868,south:36.3364713090743,east:138.74971533252,note:'昭和12年修正・昭和12.8.30発行',list:'83-6-5'},
    {name:'御代田',north:36.3364646939282,west:138.49973696995,south:36.1698236270817,east:138.749722064163,note:'昭和12年修正・昭和12.12.28発行',list:'83-7-3'},
    {name:'十石峠',north:36.169817037935,west:138.499743655694,south:36.0031758948539,east:138.749728740558,note:'昭和4年要修・昭和7.7.30発行',list:'83-8-2'},
    {name:'須坂',north:36.669753284648,west:138.249745222596,south:36.5031123198831,east:138.499730228868,note:'昭和12年二修・昭和12.8.30発行',list:'83-9-6'},
    {name:'三峰',north:36.0031758948539,west:138.749728740558,south:35.836534703886,east:138.999713921329,note:'昭和4年要修・昭和22.1.30発行',list:'84-1-2'},
    {name:'韮崎',north:35.8365150930853,west:138.249778423507,south:35.6698738083241,east:138.499763385537,note:'昭和4年二修・昭和8.1.30発行',list:'84-10-2'},
    {name:'鰍沢',north:35.6698673421272,west:138.249784901112,south:35.5032259807763,east:138.499769854536,note:'昭和4年修正・昭和7.11.30発行',list:'84-11-3'},
    {name:'身延',north:35.5032195406282,west:138.249791325578,south:35.3365781124914,east:138.499776270471,note:'昭和3年修正・昭和7.6.30発行',list:'84-12-3'},
    {name:'丹波',north:35.8365281222495,west:138.749735362169,south:35.6698868744136,east:138.999720533266,note:'昭和4年要修・昭和21.12.28発行',list:'84-2-2'},
    {name:'谷村',north:35.6698803191275,west:138.749741929452,south:35.5032389942295,east:138.999727090961,note:'昭和4年三修・昭和7.8.30発行',list:'84-3-5'},
    {name:'山中湖',north:35.5032324653512,west:138.749748442862,south:35.3365910731946,east:138.999733594865,note:'昭和4年要修・昭和5.5.30発行',list:'84-4-4'},
    {name:'金峰山',north:36.0031693317644,west:138.499750286568,south:35.8365281222495,east:138.749735362169,note:'昭和4年要修・昭和7.2.28発行',list:'84-5-2'},
    {name:'御岳昇仙峡',north:35.8365215852745,west:138.499756863031,south:35.6698803191275,east:138.749741929452,note:'昭和4年修正・昭和7.10.30発行',list:'84-6-2'},
    {name:'甲府',north:35.6698738083241,west:138.499763385537,south:35.5032324653512,east:138.749748442862,note:'昭和4年三修・昭和7.12.28発行',list:'84-7-5'},
    {name:'富士山',north:35.5032259807763,west:138.499769854536,south:35.336584570781,east:138.749754902842,note:'昭和3年二修・昭和5.5.30発行',list:'84-8-2'},
    {name:'八ヶ岳',north:36.0031628136396,west:138.249771892317,south:35.8365215852745,east:138.499756863031,note:'昭和4年要修・昭和7.8.30発行',list:'84-9-2'},
    {name:'御殿場',north:35.336584570781,west:138.749754902842,south:35.1699431211704,east:138.999740045419,note:'昭和18年二修・昭和22.9.30発行',list:'85-1-8'},
    {name:'清水市',north:35.169923825449,west:138.249804016845,south:35.0032822631593,east:138.499788944889,note:'昭和15年二修・昭和21.11.30発行',list:'85-10-4'},
    {name:'静岡',north:35.0032759014949,west:138.24981028451,south:34.8366342718402,east:138.49979520423,note:'昭和5年部修・昭和7.3.30発行',list:'85-11-5'},
    {name:'沼津',north:35.1699366452786,west:138.749761309834,south:35.0032951180227,east:138.999746443062,note:'昭和7年二部・昭和8.5.30発行',list:'85-2-5'},
    {name:'修善寺',north:35.0032886687092,west:138.749767664271,south:34.8366470736147,east:138.999752788225,note:'昭和19年部修・昭和21.11.30発行',list:'85-3-4'},
    {name:'富士宮',north:35.3365781124914,west:138.499776270471,south:35.1699366452786,east:138.749761309834,note:'昭和19年部修・昭和21.11.30発行',list:'85-5-5'},
    {name:'吉原',north:35.1699302133307,west:138.499782633778,south:35.0032886687092,east:138.749767664271,note:'昭和19年部修・昭和21.11.30発行',list:'85-6-4'},
    {name:'駒越',north:35.0032822631593,west:138.499788944889,south:34.836640650936,east:138.749773966583,note:'昭和15年二修・昭和21.11.30発行',list:'85-7-13'},
    {name:'南部',north:35.3365716984485,west:138.249797697344,south:35.1699302133307,east:138.499782633778,note:'昭和3年修正・昭和6.12.28発行',list:'85-9-3'}
]});
dataset.age.push({
  folderName:'02', start:1972, end:1982, scale:'1/50000', mapList: [
    {name:'棚倉',north:37.1697505078153,west:140.246662248789,south:37.003109893883,east:140.496648157006,note:'昭和50年集・昭和52.3.30発行',list:'65-10-13'},
    {name:'塙',north:37.0031028572579,west:140.246669547445,south:36.8364621764571,east:140.496655442167,note:'昭和47年集・昭和49.5.30発行',list:'65-11-8AB'},
    {name:'大子',north:36.8364551668189,west:140.246676786113,south:36.6698144289443,east:140.496662667471,note:'昭和52年修正・昭和54.2.28発行',list:'65-12-12AB'},
    {name:'白河',north:37.1697434895557,west:139.996683749636,south:37.0031028572579,east:140.246669547445,note:'昭和50年集・昭和52.3.30発行',list:'65-14-13'},
    {name:'大田原',north:37.0030958657511,west:139.996691001275,south:36.8364551668189,east:140.246676786113,note:'昭和52年修正・昭和54.3.30発行',list:'65-15-11'},
    {name:'喜連川',north:36.8364482021261,west:139.996698193311,south:36.6698074463542,east:140.246683965305,note:'昭和54年修正・昭和54.12.28発行',list:'65-16-11'},
    {name:'大津',north:36.8364692309072,west:140.746634161881,south:36.6698285279077,east:140.996620262772,note:'昭和52年修正・昭和55.2.28発行',list:'65-4-9'},
    {name:'竹貫',north:37.169757571366,west:140.496640811471,south:37.0031169754926,east:140.746626830365,note:'昭和52年集・昭和53.11.30発行',list:'65-6-7'},
    {name:'川部',north:37.003109893883,west:140.496648157006,south:36.8364692309072,east:140.746634161881,note:'昭和48年集・昭和48.9.30発行',list:'65-7-8BC'},
    {name:'高萩',north:36.8364621764571,west:140.496655442167,south:36.6698214561733,east:140.746641433159,note:'昭和57年修正・昭和58.1.30発行',list:'65-8-12AB'},
    {name:'水戸',north:36.5031596757238,west:140.246691085531,south:36.3365187930961,east:140.496676940548,note:'昭和52年修正・昭和52.11.30発行',list:'66-10-14BC'},
    {name:'石岡',north:36.3365118647851,west:140.246698147292,south:36.1698709244767,east:140.496683989323,note:'昭和53年二・昭和55.6.30発行',list:'66-11-12'},
    {name:'玉造',north:36.169864023396,west:140.246705151082,south:36.003223005209,east:140.496690980249,note:'昭和54年二・昭和55.11.30発行',list:'66-12-10'},
    {name:'烏山',north:36.6698005085361,west:139.996705326255,south:36.5031596757238,east:140.246691085531,note:'昭和54年修正・昭和55.6.30発行',list:'66-13-8AB'},
    {name:'真岡',north:36.503152764841,west:139.996712400613,south:36.3365118647851,east:140.246698147292,note:'昭和53年修正・昭和53.11.30発行',list:'66-14-13'},
    {name:'真壁',north:36.3365049808978,west:139.996719416882,south:36.169864023396,east:140.246705151082,note:'昭和54年二・昭和55.11.30発行',list:'66-15-11'},
    {name:'土浦',north:36.1698571665646,west:139.996726375555,south:36.003216131419,east:140.246712097392,note:'昭和54年二・昭和54.11.30発行',list:'66-16-15AB'},
    {name:'日立',north:36.6698144289443,west:140.496662667471,south:36.5031736311514,east:140.746648644714,note:'昭和51年修正・昭和52.12.28発行',list:'66-5-12'},
    {name:'那珂湊',north:36.5031666312047,west:140.49666983343,south:36.3365257656992,east:140.746655797054,note:'昭和57年修正・昭和57.11.30発行',list:'66-6-15'},
    {name:'磯浜',north:36.3365187930961,west:140.496676940548,south:36.1698778696754,east:140.74666289068,note:'昭和53年二・昭和55.10.30発行',list:'66-7-10'},
    {name:'鉾田',north:36.1698709244767,west:140.496683989323,south:36.0032299229425,east:140.746669926088,note:'昭和54年二・昭和56.3.30発行',list:'66-8-10'},
    {name:'常陸大宮',north:36.6698074463542,west:140.246683965305,south:36.5031666312047,east:140.49666983343,note:'昭和54年修正・昭和55.11.30発行',list:'66-9-12AB'},
    {name:'成田',north:35.8365681987137,west:140.246718986703,south:35.6699270541692,east:140.496704790483,note:'昭和53年修正・昭和53.6.30発行',list:'67-10-16'},
    {name:'東金',north:35.6699202351405,west:140.24672581949,south:35.5032790121224,east:140.496711610744,note:'昭和52年修正・昭和52.11.30発行',list:'67-11-12'},
    {name:'茂原',north:35.5032722205639,west:140.246732596225,south:35.3366309288748,east:140.496718375059,note:'昭和52年修正・昭和52.12.28発行',list:'67-12-9'},
    {name:'龍ヶ崎',north:36.0032093017033,west:139.996733277116,south:35.8365681987137,east:140.246718986703,note:'昭和53年二・昭和54.12.28発行',list:'67-13-10'},
    {name:'佐倉',north:35.8365613961733,west:139.996740122046,south:35.6699202351405,east:140.24672581949,note:'昭和54年二・昭和56.10.30発行',list:'67-14-14'},
    {name:'千葉',north:35.6699134598349,west:139.996746910817,south:35.5032722205639,east:140.246732596225,note:'昭和55年二・昭和56.4.30発行',list:'67-15-14'},
    {name:'姉崎',north:35.5032654725524,west:139.996753643896,south:35.3366241648459,east:140.24673931737,note:'昭和55年二・昭和56.7.30発行',list:'67-16-13'},
    {name:'銚子',north:35.8365819353609,west:140.746676903766,south:35.6699408228762,east:140.996662921028,note:'昭和52年修正・昭和53.3.30発行',list:'67-2-12'},
    {name:'潮来',north:36.003223005209,west:140.496690980249,south:35.8365826267839,east:140.771674806234,note:'昭和52年修正・昭和53.2.28発行',list:'67-5-14'},
    {name:'八日市場',north:35.836575045153,west:140.496697913809,south:35.6699339167913,east:140.746683824195,note:'昭和52年修正・昭和53.3.30発行',list:'67-6-14'},
    {name:'木戸',north:35.6699270541692,west:140.496704790483,south:35.5032858470987,east:140.746690687853,note:'昭和52年修正・昭和53.5.30発行',list:'67-7-7'},
    {name:'佐原',north:36.003216131419,west:140.246712097392,south:35.836575045153,east:140.496697913809,note:'昭和54年二・昭和55.8.30発行',list:'67-9-13'},
    {name:'勝浦',north:35.1699760778493,west:140.246745983385,south:35.0033346482332,east:140.496731737688,note:'昭和56年修正・昭和57.1.30発行',list:'68-10-12'},
    {name:'大多喜',north:35.3366174441875,west:139.996760321745,south:35.1699760778493,east:140.246745983385,note:'昭和55年修正・昭和57.4.30発行',list:'68-13-14'},
    {name:'鴨川',north:35.1699693846027,west:139.996766944817,south:35.0033279394408,east:140.24675259472,note:'昭和56年修正・昭和57.2.28発行',list:'68-14-12AB'},
    {name:'上総大原',north:35.3366241648459,west:140.24673931737,south:35.1699828142894,east:140.496725083888,note:'昭和56年修正・昭和57.4.30発行',list:'68-9-13'},
    {name:'檜枝岐',north:37.1697227078537,west:139.246748629257,south:37.0030820186239,east:139.496734097472,note:'昭和47年修正・昭和48.6.30発行',list:'74-10-10BC'},
    {name:'燧ヶ岳',north:37.0030751632669,west:139.246755739019,south:36.8364344081055,east:139.496741195836,note:'昭和54年修正・昭和55.1.30発行',list:'74-11-12BC'},
    {name:'男体山',north:36.8364275790403,west:139.246762790343,south:36.6697867677426,east:139.496748235877,note:'昭和55年二・昭和56.3.30発行',list:'74-12-12'},
    {name:'八海山',north:37.1697158720848,west:138.996770380118,south:37.0030751632669,east:139.246755739019,note:'昭和47年修正・昭和48.5.30発行',list:'74-14-8BC'},
    {name:'藤原',north:37.0030683535553,west:138.996777442315,south:36.8364275790403,east:139.246762790343,note:'昭和54年修正・昭和55.1.30発行',list:'74-15-11'},
    {name:'追貝',north:36.8364207954453,west:138.996784446467,south:36.6697799650288,east:139.246769783732,note:'昭和54年修正・昭和55.4.30発行',list:'74-16-10'},
    {name:'那須岳',north:37.1697365167205,west:139.746705313604,south:37.0030958657511,east:139.996691001275,note:'昭和54年修正・昭和55.9.30発行',list:'74-2-10AB'},
    {name:'塩原',north:37.0030889194957,west:139.746712518087,south:36.8364482021261,east:139.996698193311,note:'昭和52年修正・昭和54.3.30発行',list:'74-3-13'},
    {name:'矢板',north:36.8364412825111,west:139.746719663355,south:36.6698005085361,east:139.996705326255,note:'昭和52年修正・昭和53.6.30発行',list:'74-4-13'},
    {name:'糸沢',north:37.1697295894426,west:139.496726940281,south:37.0030889194957,east:139.746712518087,note:'昭和48年集・昭和50.8.30発行',list:'74-6-13'},
    {name:'川治',north:37.0030820186239,west:139.496734097472,south:36.8364412825111,east:139.746719663355,note:'昭和54年修正・昭和54.12.28発行',list:'74-7-14'},
    {name:'日光',north:36.8364344081055,west:139.496741195836,south:36.6697936156218,east:139.746726749915,note:'昭和54年二・昭和56.6.30発行',list:'74-8-16AB'},
    {name:'宇都宮',north:36.6697936156218,west:139.746726749915,south:36.503152764841,east:139.996712400613,note:'昭和54年二・昭和56.7.30発行',list:'75-1-15'},
    {name:'桐生及足利',north:36.5031323010915,west:139.246776719681,south:36.3364913469181,east:139.496762142982,note:'昭和52年修正・昭和53.2.28発行',list:'75-10-12AB'},
    {name:'深谷',north:36.3364845970849,west:139.246783598678,south:36.1698435861705,east:139.496769011022,note:'昭和52年修正・昭和52.12.28発行',list:'75-11-13AB'},
    {name:'熊谷',north:36.1698368628663,west:139.246790421205,south:36.0031957750136,east:139.496775822695,note:'昭和54年二・昭和55.2.28発行',list:'75-12-13'},
    {name:'沼田',north:36.6697732076097,west:138.99679139307,south:36.5031323010915,east:139.246776719681,note:'昭和53年修正・昭和54.11.30発行',list:'75-13-9'},
    {name:'前橋',north:36.5031255699074,west:138.996798282617,south:36.3364845970849,east:139.246783598678,note:'昭和56年二・昭和58.1.30発行',list:'75-14-16'},
    {name:'高崎',north:36.3364778921945,west:138.996805115594,south:36.1698368628663,east:139.246790421205,note:'昭和57年二・昭和58.1.30発行',list:'75-15-15'},
    {name:'寄居',north:36.1698301843281,west:138.996811892478,south:36.003189078297,east:139.246797187739,note:'昭和55年修正・昭和57.4.30発行',list:'75-16-13'},
    {name:'壬生',north:36.5031458986877,west:139.74673377827,south:36.3365049808978,east:139.996719416882,note:'昭和55年二・昭和56.9.30発行',list:'75-2-12'},
    {name:'小山',north:36.3364981415655,west:139.746740748914,south:36.1698571665646,east:139.996726375555,note:'昭和52年修正・昭和52.12.28発行',list:'75-3-14AB'},
    {name:'水海道',north:36.1698503541129,west:139.746747662336,south:36.0032093017033,east:139.996733277116,note:'昭和57年修正・昭和57.10.30発行',list:'75-4-12AB'},
    {name:'鹿沼',north:36.6697867677426,west:139.496748235877,south:36.5031458986877,east:139.74673377827,note:'昭和54年修正・昭和55.5.30発行',list:'75-5-9AB'},
    {name:'栃木',north:36.5031390773946,west:139.496755218095,south:36.3364981415655,east:139.746740748914,note:'昭和52年修正・昭和52.9.30発行',list:'75-6-15AB'},
    {name:'古河',north:36.3364913469181,west:139.496762142982,south:36.1698503541129,east:139.746747662336,note:'昭和47年修正・昭和48.4.30発行',list:'75-7-13'},
    {name:'鴻巣',north:36.1698435861705,west:139.496769011022,south:36.0032025161917,east:139.746754519019,note:'昭和57年修正・昭和58.1.30発行',list:'75-8-13'},
    {name:'足尾',north:36.6697799650288,west:139.246769783732,south:36.5031390773946,east:139.496755218095,note:'昭和54年修正・昭和55.4.30発行',list:'75-9-10'},
    {name:'野田',north:36.0032025161917,west:139.746754519019,south:35.8365613961733,east:139.996740122046,note:'昭和55年修正・昭和56.9.30発行',list:'76-1-16'},
    {name:'青梅',north:35.8365412532358,west:139.246803898748,south:35.6699000409081,east:139.496789278824,note:'昭和55年修正・昭和56.3.30発行',list:'76-10-20AB'},
    {name:'八王子',north:35.6698933975422,west:139.246810554698,south:35.5032521076833,east:139.496795924209,note:'昭和55年修正・昭和56.4.30発行',list:'76-11-17BC'},
    {name:'藤沢',north:35.5032454910799,west:139.246817156045,south:35.3366041334929,east:139.496802515083,note:'昭和56年修正・昭和57.6.30発行',list:'76-12-22'},
    {name:'秩父',north:36.0031824261694,west:138.996818613744,south:35.8365412532358,east:139.246803898748,note:'昭和51年修正・昭和52.12.28発行',list:'76-13-17AB'},
    {name:'五日市',north:35.836534627577,west:138.996825279857,south:35.6698933975422,east:139.246810554698,note:'昭和51年修正・昭和52.2.28発行',list:'76-14-14'},
    {name:'上野原',north:35.6698867984101,west:138.996831891278,south:35.5032454910799,east:139.246817156045,note:'昭和51年修正・昭和52.3.30発行',list:'76-15-15BC'},
    {name:'秦野',north:35.5032389185321,west:138.996838448463,south:35.33659754371,east:139.246823703243,note:'昭和55年修正・昭和55.12.28発行',list:'76-16-14AB'},
    {name:'東京東北部',north:35.8365546376613,west:139.746761319438,south:35.6699134598349,east:139.996746910817,note:'昭和52年二・昭和54.1.30発行',list:'76-2-19AB'},
    {name:'東京東南部',north:35.6699067283815,west:139.746768064063,south:35.5032654725524,east:139.996753643896,note:'昭和56年修正・昭和57.4.30発行',list:'76-3-18'},
    {name:'木更津',north:35.5032587682164,west:139.746774753359,south:35.3366174441875,east:139.996760321745,note:'昭和54年二・昭和57.3.30発行',list:'76-4-11'},
    {name:'大宮',north:36.0031957750136,west:139.496775822695,south:35.8365546376613,east:139.746761319438,note:'昭和55年修正・昭和55.10.30発行',list:'76-5-12'},
    {name:'東京西北部',north:35.8365479233062,west:139.496782578473,south:35.6699067283815,east:139.746768064063,note:'昭和52年二・昭和54.4.30発行',list:'76-6-16AB'},
    {name:'東京西南部',north:35.6699000409081,west:139.496789278824,south:35.5032587682164,east:139.746774753359,note:'昭和56年修正・昭和57.3.30発行',list:'76-7-20'},
    {name:'横浜',north:35.5032521076833,west:139.496795924209,south:35.3366107670275,east:139.746781387783,note:'昭和52年二・昭和53.11.30発行',list:'76-8-15AB'},
    {name:'川越',north:36.003189078297,west:139.246797187739,south:35.8365479233062,east:139.496782578473,note:'昭和57年修正・昭和57.11.30発行',list:'76-9-17AB'},
    {name:'富津',north:35.3366107670275,west:139.746781387783,south:35.1699693846027,east:139.996766944817,note:'昭和55年修正・昭和57.4.30発行',list:'77-1-14AB'},
    {name:'小田原',north:35.336590997804,west:138.996844951859,south:35.1699495652942,east:139.246830196735,note:'昭和55年修正・昭和55.12.28発行',list:'77-13-23AB'},
    {name:'熱海',north:35.1699430460874,west:138.996851401911,south:35.0033015356985,east:139.246836636965,note:'昭和53年修正・昭和54.11.30発行',list:'77-14-16'},
    {name:'伊東',north:35.0032950432478,west:138.996857799055,south:34.8366534647864,east:139.246843024365,note:'昭和52年修正・昭和54.11.30発行',list:'77-15-13'},
    {name:'那古',north:35.1699627346772,west:139.746787967786,south:35.0033212736647,east:139.996773513563,note:'昭和56年修正・昭和56.12.28発行',list:'77-2-14AB'},
    {name:'館山',north:35.0033146510317,west:139.746794493817,south:34.8366731212374,east:139.996780028425,note:'昭和56年修正・昭和57.2.28発行',list:'77-3-10'},
    {name:'横須賀',north:35.3366041334929,west:139.496802515083,south:35.1699627346772,east:139.746787967786,note:'昭和55年二・昭和56.3.30発行',list:'77-5-12'},
    {name:'三崎',north:35.1699561281991,west:139.496809051893,south:35.0033146510317,east:139.746794493817,note:'昭和54年二・昭和56.10.30発行',list:'77-6-12'},
    {name:'平塚',north:35.33659754371,west:139.246823703243,south:35.1699561281991,east:139.496809051893,note:'昭和54年二・昭和56.1.30発行',list:'77-9-18'},
    {name:'高田東部',north:37.169695640994,west:138.246835999866,south:37.0030548715852,east:138.496821032505,note:'昭和56年修正・昭和57.5.30発行',list:'82-10-10AB'},
    {name:'飯山',north:37.0030481995834,west:138.246842918568,south:36.8364073651815,east:138.496827941911,note:'昭和55年修正・昭和56.4.30発行',list:'82-11-12'},
    {name:'中野',north:36.8364007187683,west:138.246849780403,south:36.6697598291694,east:138.496834794547,note:'昭和55年修正・昭和56.6.30発行',list:'82-12-12AB'},
    {name:'十日町',north:37.1697090822659,west:138.74679219245,south:37.0030683535553,east:138.996777442315,note:'昭和47年修正・昭和48.6.30発行',list:'82-2-8'},
    {name:'越後湯沢',north:37.0030615896185,west:138.746799206949,south:36.8364207954453,east:138.996784446467,note:'昭和49年集・昭和52.3.30発行',list:'82-3-10'},
    {name:'四万',north:36.8364140574497,west:138.746806163794,south:36.6697732076097,east:138.99679139307,note:'昭和49年集・昭和52.2.28発行',list:'82-4-9BC'},
    {name:'松之山温泉',north:37.1697023385262,west:138.496814065838,south:37.0030615896185,east:138.746799206949,note:'昭和47年修正・昭和48.3.30発行',list:'82-6-11'},
    {name:'苗場山',north:37.0030548715852,west:138.496821032505,south:36.8364140574497,east:138.746806163794,note:'昭和49年集・昭和52.3.30発行',list:'82-7-8'},
    {name:'岩菅山',north:36.8364073651815,west:138.496827941911,south:36.669766495614,east:138.746813063479,note:'昭和49年集・昭和51.10.30発行',list:'82-8-8AB'},
    {name:'中之条',north:36.669766495614,west:138.746813063479,south:36.5031255699074,east:138.996798282617,note:'昭和48年集・昭和51.1.30発行',list:'83-1-9'},
    {name:'上田',north:36.503105648345,west:138.24686333542,south:36.3364646177511,east:138.496848331445,note:'昭和54年修正・昭和55.7.30発行',list:'83-10-12CD'},
    {name:'小諸',north:36.3364580484507,west:138.246870029559,south:36.1698169620573,east:138.496855016658,note:'昭和54年修正・昭和56.1.30発行',list:'83-11-14'},
    {name:'蓼科山',north:36.1698104185764,west:138.246876668745,south:36.0031692561868,east:138.496861647005,note:'昭和50年集・昭和51.10.30発行',list:'83-12-11'},
    {name:'榛名山',north:36.5031188839702,west:138.746819906494,south:36.3364778921945,east:138.996805115594,note:'昭和49年修正・昭和49.11.30発行',list:'83-2-12'},
    {name:'富岡',north:36.3364712323743,west:138.74682669332,south:36.1698301843281,east:138.996811892478,note:'昭和47年修正・昭和48.5.30発行',list:'83-3-10AB'},
    {name:'万場',north:36.1698235506831,west:138.746833424432,south:36.0031824261694,east:138.996818613744,note:'昭和50年集・昭和51.8.30発行',list:'83-4-10'},
    {name:'草津',north:36.6697598291694,west:138.496834794547,south:36.5031188839702,east:138.746819906494,note:'昭和48年集・昭和50.2.28発行',list:'83-5-13AB'},
    {name:'軽井沢',north:36.5031122434073,west:138.496841590899,south:36.3364712323743,east:138.74682669332,note:'昭和54年修正・昭和55.6.30発行',list:'83-6-17BC'},
    {name:'御代田',north:36.3364646177511,west:138.496848331445,south:36.1698235506831,east:138.746833424432,note:'昭和54年修正・昭和56.3.30発行',list:'83-7-14'},
    {name:'十石峠',north:36.1698169620573,west:138.496855016658,south:36.0031758187575,east:138.746840100302,note:'昭和50年集・昭和52.3.30発行',list:'83-8-8AB'},
    {name:'須坂',north:36.6697532084027,west:138.24685658586,south:36.5031122434073,east:138.496841590899,note:'昭和55年修正・昭和55.12.28発行',list:'83-9-13AB'},
    {name:'三峰',north:36.0031758187575,west:138.746840100302,south:35.836534627577,east:138.996825279857,note:'昭和49年集・昭和51.2.28発行',list:'84-1-12'},
    {name:'韮崎',north:35.8365150183267,west:138.246889784108,south:35.6698737333486,east:138.496874744934,note:'昭和51年集・昭和52.9.30発行',list:'84-10-12'},
    {name:'鰍沢',north:35.6698672676679,west:138.246896261193,south:35.5032259061028,east:138.496881213419,note:'昭和54年修正・昭和56.7.30発行',list:'84-11-13'},
    {name:'身延',north:35.5032194664688,west:138.246902685144,south:35.3365780381206,east:138.496887628844,note:'昭和48年集・昭和48.9.30発行',list:'84-12-12CD'},
    {name:'丹波',north:35.8365280464559,west:138.746846721392,south:35.6698867984101,east:138.996831891278,note:'昭和49年集・昭和51.8.30発行',list:'84-2-14'},
    {name:'都留',north:35.6698802436373,west:138.746853288159,south:35.5032389185321,east:138.996838448463,note:'昭和53年修正・昭和53.11.30発行',list:'84-3-16BC'},
    {name:'山中湖',north:35.503232390165,west:138.746859801056,south:35.336590997804,east:138.996844951859,note:'昭和53年修正・昭和53.11.30発行',list:'84-4-16AB'},
    {name:'金峰山',north:36.0031692561868,west:138.496861647005,south:35.8365280464559,east:138.746846721392,note:'昭和50年集・昭和51.11.30発行',list:'84-5-9'},
    {name:'御岳昇仙峡',north:35.8365215099976,west:138.496868222946,south:35.6698802436373,east:138.746853288159,note:'昭和55年修正・昭和56.8.30発行',list:'84-6-15'},
    {name:'甲府',north:35.6698737333486,west:138.496874744934,south:35.503232390165,east:138.746859801056,note:'昭和53年修正・昭和55.5.30発行',list:'84-7-17'},
    {name:'富士山',north:35.5032259061028,west:138.496881213419,south:35.3365844958997,east:138.746866260528,note:'昭和52年修正・昭和53.5.30発行',list:'84-8-12'},
    {name:'八ヶ岳',north:36.0031627385824,west:138.246883253442,south:35.8365215099976,east:138.496868222946,note:'昭和52年集・昭和53.1.30発行',list:'84-9-10AB'},
    {name:'御殿場',north:35.3365844958997,west:138.746866260528,south:35.1699430460874,east:138.996851401911,note:'昭和51年修正・昭和52.10.30発行',list:'85-1-19'},
    {name:'清水',north:35.1699237518915,west:138.246915375393,south:35.0032821893959,east:138.496900302255,note:'昭和56年修正・昭和57.10.30発行',list:'85-10-13'},
    {name:'静岡',north:35.0032758282392,west:138.246921642555,south:34.8366341983813,east:138.496906561099,note:'昭和51年修正・昭和53.1.30発行',list:'85-11-16'},
    {name:'沼津',north:35.1699365707026,west:138.746872667015,south:35.0032950432478,east:138.996857799055,note:'昭和51年修正・昭和52.10.30発行',list:'85-2-17'},
    {name:'修善寺',north:35.0032885944394,west:138.746879020953,south:34.8366469991486,east:138.996864143724,note:'昭和53年修正・昭和54.1.30発行',list:'85-3-11'},
    {name:'富士宮',north:35.3365780381206,west:138.496887628844,south:35.1699365707026,east:138.746872667015,note:'昭和51年修正・昭和52.10.30発行',list:'85-5-13'},
    {name:'吉原',north:35.1699301392632,west:138.496893991645,south:35.0032885944394,east:138.746879020953,note:'昭和51年修正・昭和52.2.28発行',list:'85-6-11'},
    {name:'駒越',north:35.0032821893959,west:138.496900302255,south:34.8366405769729,east:138.74688532277,note:'昭和51年修正・昭和53.5.30発行',list:'85-7-9'},
    {name:'南部',north:35.3365716245898,west:138.246909056399,south:35.1699301392632,east:138.496893991645,note:'昭和56年修正・昭和57.11.30発行',list:'85-9-10'}
]});
dataset.age.push({
  folderName:'03', start:1988, end:2008, scale:'1/50000', mapList: [
    {name:'棚倉',north:37.1697505078153,west:140.246662248789,south:37.003109893883,east:140.496648157006,note:'平成14年修正・平成15.4.1発行',list:'65-10-16'},
    {name:'塙',north:37.0031028572579,west:140.246669547445,south:36.8364621764571,east:140.496655442167,note:'平成13年修正・平成14.8.1発行',list:'65-11-11'},
    {name:'大子',north:36.8364551668189,west:140.246676786113,south:36.6698144289443,east:140.496662667471,note:'平成14年修正・平成15.1.1発行',list:'65-12-15'},
    {name:'白河',north:37.1697434895557,west:139.996683749636,south:37.0031028572579,east:140.246669547445,note:'平成5年修正・平成6.8.1発行',list:'65-14-16AB'},
    {name:'大田原',north:37.0030958657511,west:139.996691001275,south:36.8364551668189,east:140.246676786113,note:'平成7年修正・平成8.1.1発行',list:'65-15-14B'},
    {name:'喜連川',north:36.8364482021261,west:139.996698193311,south:36.6698074463542,east:140.246683965305,note:'平成4年修正・平成5.2.1発行',list:'65-16-12AB'},
    {name:'大津',north:36.8364692309072,west:140.746634161881,south:36.6698285279077,east:140.996620262772,note:'平成13年修正・平成15.3.1発行',list:'65-4-13'},
    {name:'竹貫',north:37.169757571366,west:140.496640811471,south:37.0031169754926,east:140.746626830365,note:'平成13年修正・平成14.6.1発行',list:'65-6-11'},
    {name:'川部',north:37.003109893883,west:140.496648157006,south:36.8364692309072,east:140.746634161881,note:'平成14年修正・平成14.9.1発行',list:'65-7-13'},
    {name:'高萩',north:36.8364621764571,west:140.496655442167,south:36.6698214561733,east:140.746641433159,note:'平成14年修正・平成15.4.1発行',list:'65-8-16'},
    {name:'水戸',north:36.5031596757238,west:140.246691085531,south:36.3365187930961,east:140.496676940548,note:'平成13年修正・平成14.8.1発行',list:'66-10-19'},
    {name:'石岡',north:36.3365118647851,west:140.246698147292,south:36.1698709244767,east:140.496683989323,note:'平成13年修正・平成14.8.1発行',list:'66-11-17'},
    {name:'玉造',north:36.169864023396,west:140.246705151082,south:36.003223005209,east:140.496690980249,note:'平成11年修正・平成11.9.1発行',list:'66-12-14B'},
    {name:'烏山',north:36.6698005085361,west:139.996705326255,south:36.5031596757238,east:140.246691085531,note:'平成7年修正・平成8.8.1発行',list:'66-13-12AB'},
    {name:'真岡',north:36.503152764841,west:139.996712400613,south:36.3365118647851,east:140.246698147292,note:'平成8年修正・平成8.9.1発行',list:'66-14-16AB'},
    {name:'真壁',north:36.3365049808978,west:139.996719416882,south:36.169864023396,east:140.246705151082,note:'平成8年修正・平成8.12.1発行',list:'66-15-15B'},
    {name:'土浦',north:36.1698571665646,west:139.996726375555,south:36.003216131419,east:140.246712097392,note:'平成17年要修・平成17.8.24発行',list:'66-16-22'},
    {name:'日立',north:36.6698144289443,west:140.496662667471,south:36.5031736311514,east:140.746648644714,note:'平成5年修正・平成6.8.1発行',list:'66-5-15B'},
    {name:'ひたちなか',north:36.5031666312047,west:140.49666983343,south:36.3365257656992,east:140.746655797054,note:'平成12年修正・平成13.11.1発行',list:'66-6-19'},
    {name:'磯浜',north:36.3365187930961,west:140.496676940548,south:36.1698778696754,east:140.74666289068,note:'平成8年修正・平成8.11.1発行',list:'66-7-15'},
    {name:'鉾田',north:36.1698709244767,west:140.496683989323,south:36.0032299229425,east:140.746669926088,note:'平成8年修正・平成9.8.1発行',list:'66-8-13B'},
    {name:'常陸大宮',north:36.6698074463542,west:140.246683965305,south:36.5031666312047,east:140.49666983343,note:'平成14年修正・平成15.4.1発行',list:'66-9-16'},
    {name:'成田',north:35.8365681987137,west:140.246718986703,south:35.6699270541692,east:140.496704790483,note:'平成13年修正・平成14.3.1発行',list:'67-10-22AB'},
    {name:'東金',north:35.6699202351405,west:140.24672581949,south:35.5032790121224,east:140.496711610744,note:'平成12年修正・平成12.10.1発行',list:'67-11-17B'},
    {name:'茂原',north:35.5032722205639,west:140.246732596225,south:35.3366309288748,east:140.496718375059,note:'平成18年修正・平成20.2.1発行',list:'67-12-16'},
    {name:'龍ヶ崎',north:36.0032093017033,west:139.996733277116,south:35.8365681987137,east:140.246718986703,note:'平成17年要修・平成17.8.24発行',list:'67-13-16'},
    {name:'佐倉',north:35.8365613961733,west:139.996740122046,south:35.6699202351405,east:140.24672581949,note:'平成9年修正・平成10.9.1発行',list:'67-14-18B'},
    {name:'千葉',north:35.6699134598349,west:139.996746910817,south:35.5032722205639,east:140.246732596225,note:'平成12年修正・平成12.9.1発行',list:'67-15-20B'},
    {name:'姉崎',north:35.5032654725524,west:139.996753643896,south:35.3366241648459,east:140.24673931737,note:'平成19年修正・平成20.9.1発行',list:'67-16-23'},
    {name:'銚子',north:35.8365819353609,west:140.746676903766,south:35.6699408228762,east:140.996662921028,note:'平成13年修正・平成14.7.1発行',list:'67-2-17'},
    {name:'潮来',north:36.003223005209,west:140.496690980249,south:35.8365826267839,east:140.771674806234,note:'平成13年修正・平成13.7.1発行',list:'67-5-19B'},
    {name:'八日市場',north:35.836575045153,west:140.496697913809,south:35.6699339167913,east:140.746683824195,note:'平成14年修正・平成15.6.1発行',list:'67-6-19'},
    {name:'木戸',north:35.6699270541692,west:140.496704790483,south:35.5032858470987,east:140.746690687853,note:'平成10年修正・平成11.11.1発行',list:'67-7-14'},
    {name:'佐原',north:36.003216131419,west:140.246712097392,south:35.836575045153,east:140.496697913809,note:'平成9年修正・平成11.8.1発行',list:'67-9-18B'},
    {name:'勝浦',north:35.1699760778493,west:140.246745983385,south:35.0033346482332,east:140.496731737688,note:'平成13年修正・平成15.3.1発行',list:'68-10-16'},
    {name:'大多喜',north:35.3366174441875,west:139.996760321745,south:35.1699760778493,east:140.246745983385,note:'平成18年修正・平成19.12.1発行',list:'68-13-18'},
    {name:'鴨川',north:35.1699693846027,west:139.996766944817,south:35.0033279394408,east:140.24675259472,note:'平成14年修正・平成15.6.1発行',list:'68-14-15'},
    {name:'上総大原',north:35.3366241648459,west:140.24673931737,south:35.1699828142894,east:140.496725083888,note:'平成18年修正・平成20.4.1発行',list:'68-9-16'},
    {name:'檜枝岐',north:37.1697227078537,west:139.246748629257,south:37.0030820186239,east:139.496734097472,note:'平成13年修正・平成15.1.1発行',list:'74-10-13'},
    {name:'燧ヶ岳',north:37.0030751632669,west:139.246755739019,south:36.8364344081055,east:139.496741195836,note:'平成3年修正・平成5.7.1発行',list:'74-11-13AB'},
    {name:'男体山',north:36.8364275790403,west:139.246762790343,south:36.6697867677426,east:139.496748235877,note:'平成5年修正・平成6.1.1発行',list:'74-12-13B'},
    {name:'八海山',north:37.1697158720848,west:138.996770380118,south:37.0030751632669,east:139.246755739019,note:'平成19年要修・平成19.8.1発行',list:'74-14-12'},
    {name:'藤原',north:37.0030683535553,west:138.996777442315,south:36.8364275790403,east:139.246762790343,note:'平成3年修正・平成5.9.1発行',list:'74-15-12B'},
    {name:'追貝',north:36.8364207954453,west:138.996784446467,south:36.6697799650288,east:139.246769783732,note:'平成14年修正・平成15.4.1発行',list:'74-16-13'},
    {name:'那須岳',north:37.1697365167205,west:139.746705313604,south:37.0030958657511,east:139.996691001275,note:'平成3年修正・平成5.3.1発行',list:'74-2-11D'},
    {name:'塩原',north:37.0030889194957,west:139.746712518087,south:36.8364482021261,east:139.996698193311,note:'平成7年修正・平成8.1.1発行',list:'74-3-16B'},
    {name:'矢板',north:36.8364412825111,west:139.746719663355,south:36.6698005085361,east:139.996705326255,note:'平成4年修正・平成5.5.1発行',list:'74-4-15B'},
    {name:'糸沢',north:37.1697295894426,west:139.496726940281,south:37.0030889194957,east:139.746712518087,note:'平成14年修正・平成14.8.1発行',list:'74-6-17'},
    {name:'川治',north:37.0030820186239,west:139.496734097472,south:36.8364412825111,east:139.746719663355,note:'平成1年修正・平成2.12.1発行',list:'74-7-15C'},
    {name:'日光',north:36.8364344081055,west:139.496741195836,south:36.6697936156218,east:139.746726749915,note:'平成14年修正・平成15.7.1発行',list:'74-8-20AB'},
    {name:'宇都宮',north:36.6697936156218,west:139.746726749915,south:36.503152764841,east:139.996712400613,note:'平成7年修正・平成8.4.1発行',list:'75-1-18B'},
    {name:'桐生及足利',north:36.5031323010915,west:139.246776719681,south:36.3364913469181,east:139.496762142982,note:'平成8年修正・平成11.6.1発行',list:'75-10-15B'},
    {name:'深谷',north:36.3364845970849,west:139.246783598678,south:36.1698435861705,east:139.496769011022,note:'平成9年修正・平成10.9.1発行',list:'75-11-17B'},
    {name:'熊谷',north:36.1698368628663,west:139.246790421205,south:36.0031957750136,east:139.496775822695,note:'平成13年修正・平成14.8.1発行',list:'75-12-19'},
    {name:'沼田',north:36.6697732076097,west:138.99679139307,south:36.5031323010915,east:139.246776719681,note:'平成14年修正・平成15.3.1発行',list:'75-13-13'},
    {name:'前橋',north:36.5031255699074,west:138.996798282617,south:36.3364845970849,east:139.246783598678,note:'平成9年要修・平成10.3.1発行',list:'75-14-20B'},
    {name:'高崎',north:36.3364778921945,west:138.996805115594,south:36.1698368628663,east:139.246790421205,note:'平成10年修正・平成10.12.1発行',list:'75-15-19B'},
    {name:'寄居',north:36.1698301843281,west:138.996811892478,south:36.003189078297,east:139.246797187739,note:'平成4年修正・平成5.4.1発行',list:'75-16-15AB'},
    {name:'壬生',north:36.5031458986877,west:139.74673377827,south:36.3365049808978,east:139.996719416882,note:'平成11年修正・平成12.2.1発行',list:'75-2-16B'},
    {name:'小山',north:36.3364981415655,west:139.746740748914,south:36.1698571665646,east:139.996726375555,note:'平成8年修正・平成9.4.1発行',list:'75-3-17B'},
    {name:'水海道',north:36.1698503541129,west:139.746747662336,south:36.0032093017033,east:139.996733277116,note:'平成7年修正・平成9.4.1発行',list:'75-4-14B'},
    {name:'鹿沼',north:36.6697867677426,west:139.496748235877,south:36.5031458986877,east:139.74673377827,note:'平成5年修正・平成5.12.1発行',list:'75-5-10C'},
    {name:'栃木',north:36.5031390773946,west:139.496755218095,south:36.3364981415655,east:139.746740748914,note:'平成11年修正・平成11.6.1発行',list:'75-6-18B'},
    {name:'古河',north:36.3364913469181,west:139.496762142982,south:36.1698503541129,east:139.746747662336,note:'平成9年修正・平成11.2.1発行',list:'75-7-15C'},
    {name:'鴻巣',north:36.1698435861705,west:139.496769011022,south:36.0032025161917,east:139.746754519019,note:'平成19年修正・平成20.10.1発行',list:'75-8-22'},
    {name:'足尾',north:36.6697799650288,west:139.246769783732,south:36.5031390773946,east:139.496755218095,note:'昭和63年修正・平成1.3.30発行',list:'75-9-11D'},
    {name:'野田',north:36.0032025161917,west:139.746754519019,south:35.8365613961733,east:139.996740122046,note:'平成17年要修・平成17.8.24発行',list:'76-1-21'},
    {name:'青梅',north:35.8365412532358,west:139.246803898748,south:35.6699000409081,east:139.496789278824,note:'平成9年要修・平成9.7.1発行',list:'76-10-24B'},
    {name:'八王子',north:35.6698933975422,west:139.246810554698,south:35.5032521076833,east:139.496795924209,note:'平成19年修正・平成21.1.1発行',list:'76-11-24'},
    {name:'藤沢',north:35.5032454910799,west:139.246817156045,south:35.3366041334929,east:139.496802515083,note:'平成9年修正・平成9.7.1発行',list:'76-12-26B'},
    {name:'秩父',north:36.0031824261694,west:138.996818613744,south:35.8365412532358,east:139.246803898748,note:'平成9年修正・平成10.9.1発行',list:'76-13-20AB'},
    {name:'五日市',north:35.836534627577,west:138.996825279857,south:35.6698933975422,east:139.246810554698,note:'平成9年修正・平成9.7.1発行',list:'76-14-17B'},
    {name:'上野原',north:35.6698867984101,west:138.996831891278,south:35.5032454910799,east:139.246817156045,note:'平成20年修正・平成21.5.1発行',list:'76-15-21'},
    {name:'秦野',north:35.5032389185321,west:138.996838448463,south:35.33659754371,east:139.246823703243,note:'平成8年修正・平成9.8.1発行',list:'76-16-17AB'},
    {name:'東京東北部',north:35.8365546376613,west:139.746761319438,south:35.6699134598349,east:139.996746910817,note:'平成17年要修・平成17.8.24発行',list:'76-2-26'},
    {name:'東京東南部',north:35.6699067283815,west:139.746768064063,south:35.5032654725524,east:139.996753643896,note:'平成18年修正・平成19.12.1発行',list:'76-3-26'},
    {name:'木更津',north:35.5032587682164,west:139.746774753359,south:35.3366174441875,east:139.996760321745,note:'平成19年修正・平成20.2.1発行',list:'76-4-18'},
    {name:'大宮',north:36.0031957750136,west:139.496775822695,south:35.8365546376613,east:139.746761319438,note:'平成15年修正・平成16.8.1発行',list:'76-5-16'},
    {name:'東京西北部',north:35.8365479233062,west:139.496782578473,south:35.6699067283815,east:139.746768064063,note:'平成9年要修・平成9.12.1発行',list:'76-6-21B'},
    {name:'東京西南部',north:35.6699000409081,west:139.496789278824,south:35.5032587682164,east:139.746774753359,note:'平成7年修正・平成8.1.1発行',list:'76-7-23B'},
    {name:'横浜',north:35.5032521076833,west:139.496795924209,south:35.3366107670275,east:139.746781387783,note:'平成12年修正・平成13.5.1発行',list:'76-8-21B'},
    {name:'川越',north:36.003189078297,west:139.246797187739,south:35.8365479233062,east:139.496782578473,note:'平成8年要修・平成9.8.1発行',list:'76-9-20B'},
    {name:'富津',north:35.3366107670275,west:139.746781387783,south:35.1699693846027,east:139.996766944817,note:'平成12年要修・平成12.11.1発行',list:'77-1-17B'},
    {name:'小田原',north:35.336590997804,west:138.996844951859,south:35.1699495652942,east:139.246830196735,note:'平成8年修正・平成9.7.1発行',list:'77-13-26B'},
    {name:'熱海',north:35.1699430460874,west:138.996851401911,south:35.0033015356985,east:139.246836636965,note:'平成8年修正・平成9.3.1発行',list:'77-14-19AB'},
    {name:'伊東',north:35.0032950432478,west:138.996857799055,south:34.8366534647864,east:139.246843024365,note:'平成11年修正・平成12.6.1発行',list:'77-15-16B'},
    {name:'那古',north:35.1699627346772,west:139.746787967786,south:35.0033212736647,east:139.996773513563,note:'平成19年修正・平成21.2.1発行',list:'77-2-20'},
    {name:'館山',north:35.0033146510317,west:139.746794493817,south:34.8366731212374,east:139.996780028425,note:'平成13年修正・平成15.2.1発行',list:'77-3-13'},
    {name:'横須賀',north:35.3366041334929,west:139.496802515083,south:35.1699627346772,east:139.746787967786,note:'平成12年修正・平成12.10.1発行',list:'77-5-16B'},
    {name:'三崎',north:35.1699561281991,west:139.496809051893,south:35.0033146510317,east:139.746794493817,note:'平成12年修正・平成14.3.1発行',list:'77-6-16'},
    {name:'平塚',north:35.33659754371,west:139.246823703243,south:35.1699561281991,east:139.496809051893,note:'平成9年修正・平成10.3.1発行',list:'77-9-22B'},
    {name:'高田東部',north:37.169695640994,west:138.246835999866,south:37.0030548715852,east:138.496821032505,note:'平成19年修正・平成19.11.1発行',list:'82-10-16'},
    {name:'飯山',north:37.0030481995834,west:138.246842918568,south:36.8364073651815,east:138.496827941911,note:'平成14年修正・平成15.8.1発行',list:'82-11-15'},
    {name:'中野',north:36.8364007187683,west:138.246849780403,south:36.6697598291694,east:138.496834794547,note:'平成18年修正・平成19.12.1発行',list:'82-12-19'},
    {name:'十日町',north:37.1697090822659,west:138.74679219245,south:37.0030683535553,east:138.996777442315,note:'平成19年修正・平成20.5.1発行',list:'82-2-16'},
    {name:'越後湯沢',north:37.0030615896185,west:138.746799206949,south:36.8364207954453,east:138.996784446467,note:'平成19年要修・平成20.3.1発行',list:'82-3-16'},
    {name:'四万',north:36.8364140574497,west:138.746806163794,south:36.6697732076097,east:138.99679139307,note:'平成4年修正・平成5.12.1発行',list:'82-4-11B'},
    {name:'松之山温泉',north:37.1697023385262,west:138.496814065838,south:37.0030615896185,east:138.746799206949,note:'平成19年修正・平成19.10.1発行',list:'82-6-16'},
    {name:'苗場山',north:37.0030548715852,west:138.496821032505,south:36.8364140574497,east:138.746806163794,note:'平成19年要修・平成19.8.1発行',list:'82-7-12'},
    {name:'岩菅山',north:36.8364073651815,west:138.496827941911,south:36.669766495614,east:138.746813063479,note:'平成12年修正・平成13.8.1発行',list:'82-8-11B'},
    {name:'中之条',north:36.669766495614,west:138.746813063479,south:36.5031255699074,east:138.996798282617,note:'平成9年修正・平成10.8.1発行',list:'83-1-12B'},
    {name:'上田',north:36.503105648345,west:138.24686333542,south:36.3364646177511,east:138.496848331445,note:'平成9年要修・平成10.2.1発行',list:'83-10-16B'},
    {name:'小諸',north:36.3364580484507,west:138.246870029559,south:36.1698169620573,east:138.496855016658,note:'平成19年要修・平成20.7.1発行',list:'83-11-23'},
    {name:'蓼科山',north:36.1698104185764,west:138.246876668745,south:36.0031692561868,east:138.496861647005,note:'平成18年修正・平成19.12.1発行',list:'83-12-16'},
    {name:'榛名山',north:36.5031188839702,west:138.746819906494,south:36.3364778921945,east:138.996805115594,note:'平成9年要修・平成10.3.1発行',list:'83-2-17B'},
    {name:'富岡',north:36.3364712323743,west:138.74682669332,south:36.1698301843281,east:138.996811892478,note:'平成6年修正・平成7.4.1発行',list:'83-3-14B'},
    {name:'万場',north:36.1698235506831,west:138.746833424432,south:36.0031824261694,east:138.996818613744,note:'平成9年修正・平成10.12.1発行',list:'83-4-13B'},
    {name:'草津',north:36.6697598291694,west:138.496834794547,south:36.5031188839702,east:138.746819906494,note:'平成9年修正・平成11.1.1発行',list:'83-5-16B'},
    {name:'軽井沢',north:36.5031122434073,west:138.496841590899,south:36.3364712323743,east:138.74682669332,note:'平成9年要修・平成10.2.1発行',list:'83-6-22B'},
    {name:'御代田',north:36.3364646177511,west:138.496848331445,south:36.1698235506831,east:138.746833424432,note:'平成9年要修・平成10.3.1発行',list:'83-7-19B'},
    {name:'十石峠',north:36.1698169620573,west:138.496855016658,south:36.0031758187575,east:138.746840100302,note:'昭和63年修正・平成2.9.1発行',list:'83-8-9C'},
    {name:'須坂',north:36.6697532084027,west:138.24685658586,south:36.5031122434073,east:138.496841590899,note:'平成6年修正・平成7.5.1発行',list:'83-9-17AB'},
    {name:'三峰',north:36.0031758187575,west:138.746840100302,south:35.836534627577,east:138.996825279857,note:'平成14年修正・平成15.7.1発行',list:'84-1-15'},
    {name:'韮崎',north:35.8365150183267,west:138.246889784108,south:35.6698737333486,east:138.496874744934,note:'平成18年修正・平成20.1.1発行',list:'84-10-16'},
    {name:'鰍沢',north:35.6698672676679,west:138.246896261193,south:35.5032259061028,east:138.496881213419,note:'平成19年要修・平成21.1.1発行',list:'84-11-18'},
    {name:'身延',north:35.5032194664688,west:138.246902685144,south:35.3365780381206,east:138.496887628844,note:'平成9年修正・平成10.6.1発行',list:'84-12-16B'},
    {name:'丹波',north:35.8365280464559,west:138.746846721392,south:35.6698867984101,east:138.996831891278,note:'平成11年修正・平成12.8.1発行',list:'84-2-17B'},
    {name:'都留',north:35.6698802436373,west:138.746853288159,south:35.5032389185321,east:138.996838448463,note:'平成7年修正・平成8.6.1発行',list:'84-3-20B'},
    {name:'山中湖',north:35.503232390165,west:138.746859801056,south:35.336590997804,east:138.996844951859,note:'平成2年修正・平成4.1.1発行',list:'84-4-17B'},
    {name:'金峰山',north:36.0031692561868,west:138.496861647005,south:35.8365280464559,east:138.746846721392,note:'平成19年修正・平成20.11.1発行',list:'84-5-14'},
    {name:'御岳昇仙峡',north:35.8365215099976,west:138.496868222946,south:35.6698802436373,east:138.746853288159,note:'平成19年修正・平成21.1.1発行',list:'84-6-20'},
    {name:'甲府',north:35.6698737333486,west:138.496874744934,south:35.503232390165,east:138.746859801056,note:'平成19年修正・平成21.1.1発行',list:'84-7-25'},
    {name:'富士山',north:35.5032259061028,west:138.496881213419,south:35.3365844958997,east:138.746866260528,note:'平成2年修正・平成3.4.1発行',list:'84-8-15EF'},
    {name:'八ヶ岳',north:36.0031627385824,west:138.246883253442,south:35.8365215099976,east:138.496868222946,note:'平成3年修正・平成4.3.1発行',list:'84-9-12C'},
    {name:'御殿場',north:35.3365844958997,west:138.746866260528,south:35.1699430460874,east:138.996851401911,note:'平成4年修正・平成5.11.1発行',list:'85-1-23'},
    {name:'清水',north:35.1699237518915,west:138.246915375393,south:35.0032821893959,east:138.496900302255,note:'平成18年修正・平成20.1.1発行',list:'85-10-19'},
    {name:'静岡',north:35.0032758282392,west:138.246921642555,south:34.8366341983813,east:138.496906561099,note:'平成18年要修・平成19.12.1発行',list:'85-11-23'},
    {name:'沼津',north:35.1699365707026,west:138.746872667015,south:35.0032950432478,east:138.996857799055,note:'平成8年修正・平成9.8.1発行',list:'85-2-23B'},
    {name:'修善寺',north:35.0032885944394,west:138.746879020953,south:34.8366469991486,east:138.996864143724,note:'平成9年修正・平成10.12.1発行',list:'85-3-13B'},
    {name:'富士宮',north:35.3365780381206,west:138.496887628844,south:35.1699365707026,east:138.746872667015,note:'平成4年修正・平成5.12.1発行',list:'85-5-16B'},
    {name:'吉原',north:35.1699301392632,west:138.496893991645,south:35.0032885944394,east:138.746879020953,note:'平成8年修正・平成10.1.1発行',list:'85-6-15B'},
    {name:'駒越',north:35.0032821893959,west:138.496900302255,south:34.8366405769729,east:138.74688532277,note:'平成3年修正・平成5.12.1発行',list:'85-7-11B'},
    {name:'南部',north:35.3365716245898,west:138.246909056399,south:35.1699301392632,east:138.496893991645,note:'平成19年修正・平成20.11.1発行',list:'85-9-16'}
]});
kjmapDataSet['sapporo'] = new Object();
dataset = kjmapDataSet['sapporo'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1916, end:1916, scale:'1/25000', mapList: [
    {name:'小樽西部',north:43.2523838512217,west:140.874179743435,south:43.1690647292574,east:140.99917316149,note:'大正5年測図・大正8.2.28発行',list:''},
    {name:'小樽東部',north:43.2523879101688,west:140.99916810011,south:43.1690687946787,east:141.124161551684,note:'大正5年測図・大正7.11.30発行',list:''},
    {name:'石倉山',north:43.1690647292574,west:140.99917316149,south:43.0857455989517,east:141.124166607177,note:'大正5年測図・大正7.9.30発行',list:''},
    {name:'銭函',north:43.1690687946787,west:141.124161551684,south:43.0857496707802,east:141.24915503083,note:'大正5年測図・大正7.12.30発行',list:''},
    {name:'茨戸',north:43.1690728727735,west:141.249149959615,south:43.0857537552434,east:141.374143472251,note:'大正5年測図・大正7.9.30発行',list:''},
    {name:'丘珠',north:43.1690769635224,west:141.374138385336,south:43.0857578523218,east:141.499131931494,note:'大正5年測図・大正7.6.30発行',list:''},
    {name:'江別',north:43.1690810669061,west:141.499126828904,south:43.0857619619961,east:141.624120408613,note:'大正5年測図・大正7.6.30発行',list:''},
    {name:'札幌',north:43.0857496707802,west:141.24915503083,south:43.002430538348,east:141.374148537439,note:'大正5年測図・大正7.11.30発行',list:''},
    {name:'月寒',north:43.0857537552434,west:141.374143472251,south:43.0024346291124,east:141.49913701229,note:'大正5年測図・大正7.8.30発行',list:''},
    {name:'野幌',north:43.0857578523218,west:141.499131931494,south:43.0024387324531,east:141.624125504993,note:'大正5年測図・大正7.5.30発行',list:''},
    {name:'石山',north:43.0024264601794,west:141.249160080386,south:42.9191073128151,east:141.37415358101,note:'大正5年測図・大正7.11.30発行',list:''},
    {name:'輪厚',north:43.002430538348,west:141.374148537439,south:42.9191113972565,east:141.499142071402,note:'大正5年測図・大正8.2.28発行',list:''},
    {name:'中之沢',north:43.0024346291124,west:141.49913701229,south:42.9191154942549,east:141.624130579623,note:'大正5年測図・大正7.6.30発行',list:''}
]});
dataset.age.push({
  folderName:'01', start:1935, end:1935, scale:'1/25000', mapList: [
    {name:'小樽西部',north:43.2523838512217,west:140.874179743435,south:43.1690647292574,east:140.99917316149,note:'昭和10年修正・昭和12.4.30発行',list:''},
    {name:'小樽東部',north:43.2523879101688,west:140.99916810011,south:43.1690687946787,east:141.124161551684,note:'昭和10年修正・昭和12.1.30発行',list:''},
    {name:'銭函',north:43.1690687946787,west:141.124161551684,south:43.0857496707802,east:141.24915503083,note:'昭和10年修正・昭和12.2.28発行',list:''},
    {name:'茨戸',north:43.1690728727735,west:141.249149959615,south:43.0857537552434,east:141.374143472251,note:'昭和10年修正・昭和12.1.30発行',list:''},
    {name:'丘珠',north:43.1690769635224,west:141.374138385336,south:43.0857578523218,east:141.499131931494,note:'昭和10年修正・昭和23.1.30発行',list:''},
    {name:'江別',north:43.1690810669061,west:141.499126828904,south:43.0857619619961,east:141.624120408613,note:'昭和10年修正・昭和12.3.30発行',list:''},
    {name:'札幌',north:43.0857496707802,west:141.24915503083,south:43.002430538348,east:141.374148537439,note:'昭和10年修正・昭和12.3.30発行',list:''},
    {name:'月寒',north:43.0857537552434,west:141.374143472251,south:43.0024346291124,east:141.49913701229,note:'昭和10年修正・昭和12.3.30発行',list:''},
    {name:'野幌',north:43.0857578523218,west:141.499131931494,south:43.0024387324531,east:141.624125504993,note:'昭和10年修正・昭和23.1.30発行',list:''},
    {name:'石切山',north:43.0024264601794,west:141.249160080386,south:42.9191073128151,east:141.37415358101,note:'昭和10年修正・昭和12.1.30発行',list:''},
    {name:'輪厚',north:43.002430538348,west:141.374148537439,south:42.9191113972565,east:141.499142071402,note:'昭和10年修正・昭和11.9.30発行',list:'',war:true},
    {name:'石狩広島',north:43.0024346291124,west:141.49913701229,south:42.9191154942549,east:141.624130579623,note:'昭和10年修正・昭和12.5.30発行',list:''}
]});
dataset.age.push({
  folderName:'02', start:1950, end:1952, scale:'1/25000', mapList: [
    {name:'小樽西部',north:43.2523837575654,west:140.871291123846,south:43.169064635451,east:140.996284541126,note:'昭和25年二修・昭和25.10.30発行',list:''},
    {name:'小樽東部',north:43.2523878162184,west:140.996279480112,south:43.1690687005791,east:141.121272930911,note:'昭和25年二修・昭和25.10.30発行',list:''},
    {name:'銭函',north:43.2523918875842,west:141.121267854082,south:43.1690727783812,east:141.246261338431,note:'昭和25年二修・昭和31.11.30発行',list:''},
    {name:'石狩',north:43.2523959716434,west:141.24625624581,south:43.169076868838,east:141.371249763741,note:'昭和25年測量・昭和28.3.30発行',list:''},
    {name:'太美',north:43.2524000683766,west:141.371244655352,south:43.1690809719299,east:141.496238206895,note:'昭和25年測量・昭和28.3.30発行',list:''},
    {name:'石狩当別',north:43.2524041777644,west:141.496233082764,south:43.1690850876373,east:141.621226667949,note:'昭和25年測量・昭和27.10.30発行',list:''},
    {name:'張碓',north:43.169064635451,west:140.996284541126,south:43.0857455049968,east:141.12127798604,note:'昭和25年二修・昭和31.11.30発行',list:''},
    {name:'銭函',north:43.1690687005791,west:141.121272930911,south:43.085749576533,east:141.246266409283,note:'昭和25年二修・昭和31.11.30発行',list:''},
    {name:'茨戸',north:43.1690727783812,west:141.246261338431,south:43.0857536607044,east:141.371254850293,note:'昭和25年二修・昭和28.4.30発行',list:''},
    {name:'丘珠',north:43.169076868838,west:141.371249763741,south:43.0857577574915,east:141.496243309123,note:'昭和25年二修・昭和27.10.30発行',list:''},
    {name:'江別',north:43.1690809719299,west:141.496238206895,south:43.0857618668749,east:141.621231785829,note:'昭和25年二修・昭和27.10.30発行',list:''},
    {name:'札幌',north:43.085749576533,west:141.246266409283,south:43.0024304439547,east:141.37125991512,note:'昭和25年二修27年資修・昭和28.6.30発行',list:''},
    {name:'月寒',north:43.0857536607044,west:141.371254850293,south:43.0024345344282,east:141.496248389559,note:'昭和25年二修・昭和28.7.30発行',list:''},
    {name:'野幌',north:43.0857577574915,west:141.496243309123,south:43.0024386374785,east:141.621236881849,note:'昭和25年二修昭和27年資修・昭和28.4.30発行',list:''},
    {name:'石山',north:43.0024263660775,west:141.246271458478,south:42.9191072185677,east:141.371264958332,note:'昭和25年二修・昭和28.2.28発行',list:''},
    {name:'厚別',north:43.0024304439547,west:141.37125991512,south:42.9191113027187,east:141.496253448312,note:'昭和25年二修・昭和27.10.30発行',list:''},
    {name:'石狩広島',north:43.0024345344282,west:141.496248389559,south:42.9191153994271,east:141.62124195612,note:'昭和25年二修・昭和27.10.30発行',list:''}
]});
dataset.age.push({
  folderName:'03', start:1975, end:1976, scale:'1/25000', mapList: [
    {name:'小樽西部',north:43.2523837575654,west:140.871291123846,south:43.169064635451,east:140.996284541126,note:'昭和51年二改・昭和52.10.30発行',list:''},
    {name:'小樽東部',north:43.2523878162184,west:140.996279480112,south:43.1690687005791,east:141.121272930911,note:'昭和51年二改・昭和53.1.30発行',list:''},
    {name:'銭函',north:43.2523918875842,west:141.121267854082,south:43.1690727783812,east:141.246261338431,note:'昭和51年二改・昭和53.8.30発行',list:''},
    {name:'石狩',north:43.2523959716434,west:141.24625624581,south:43.169076868838,east:141.371249763741,note:'昭和51年二改・昭和53.10.30発行',list:''},
    {name:'太美',north:43.2524000683766,west:141.371244655352,south:43.1690809719299,east:141.496238206895,note:'昭和51年二改・昭和54.1.30発行',list:''},
    {name:'石狩当別',north:43.2524041777644,west:141.496233082764,south:43.1690850876373,east:141.621226667949,note:'昭和51年二改・昭和54.3.30発行',list:''},
    {name:'張碓',north:43.169064635451,west:140.996284541126,south:43.0857455049968,east:141.12127798604,note:'昭和51年三改・昭和53.1.30発行',list:''},
    {name:'銭函',north:43.1690687005791,west:141.121272930911,south:43.085749576533,east:141.246266409283,note:'昭和51年二改・昭和53.8.30発行',list:''},
    {name:'札幌北部',north:43.1690727783812,west:141.246261338431,south:43.0857536607044,east:141.371254850293,note:'昭和50年三改・昭和52.11.30発行',list:''},
    {name:'札幌東北部',north:43.169076868838,west:141.371249763741,south:43.0857577574915,east:141.496243309123,note:'昭和50年三改・昭和52.3.30発行',list:''},
    {name:'江別',north:43.1690809719299,west:141.496238206895,south:43.0857618668749,east:141.621231785829,note:'昭和52年二改・昭和54.10.30発行',list:''},
    {name:'札幌',north:43.085749576533,west:141.246266409283,south:43.0024304439547,east:141.37125991512,note:'昭和50年三改・昭和52.3.30発行',list:''},
    {name:'札幌東部',north:43.0857536607044,west:141.371254850293,south:43.0024345344282,east:141.496248389559,note:'昭和50年三改・昭和52.3.30発行',list:''},
    {name:'野幌',north:43.0857577574915,west:141.496243309123,south:43.0024386374785,east:141.621236881849,note:'昭和52年二改・昭和54.10.28発行',list:''},
    {name:'石山',north:43.0024263660775,west:141.246271458478,south:42.9191072185677,east:141.371264958332,note:'昭和50年三改・昭和52.2.28発行',list:''},
    {name:'清田',north:43.0024304439547,west:141.37125991512,south:42.9191113027187,east:141.496253448312,note:'昭和50年三改・昭和53.3.30発行',list:''},
    {name:'石狩広島',north:43.0024345344282,west:141.496248389559,south:42.9191153994271,east:141.62124195612,note:'昭和50年二改・昭和52.3.30発行',list:''}
]});
dataset.age.push({
  folderName:'04', start:1995, end:1998, scale:'1/25000', mapList: [
    {name:'小樽西部',north:43.2523837575654,west:140.871291123846,south:43.169064635451,east:140.996284541126,note:'平成9年修正・平成10.6.1発行',list:''},
    {name:'小樽東部',north:43.2523878162184,west:140.996279480112,south:43.1690687005791,east:141.121272930911,note:'平成10年部修・平成11.6.1発行',list:''},
    {name:'銭函',north:43.2523918875842,west:141.121267854082,south:43.1690727783812,east:141.246261338431,note:'平成9年修正・平成10.5.1発行',list:''},
    {name:'石狩',north:43.2523959716434,west:141.24625624581,south:43.169076868838,east:141.371249763741,note:'平成8年修正・平成9.8.1発行',list:''},
    {name:'太美',north:43.2524000683766,west:141.371244655352,south:43.1690809719299,east:141.496238206895,note:'平成8年修正・平成9.7.1発行',list:''},
    {name:'石狩当別',north:43.2524041777644,west:141.496233082764,south:43.1690850876373,east:141.621226667949,note:'平成7年修正・平成8.5.1発行',list:''},
    {name:'張碓',north:43.169064635451,west:140.996284541126,south:43.0857455049968,east:141.12127798604,note:'平成9年部修・平成10.4.1発行',list:''},
    {name:'銭函',north:43.1690687005791,west:141.121272930911,south:43.085749576533,east:141.246266409283,note:'平成9年修正・平成10.5.1発行',list:''},
    {name:'札幌北部',north:43.1690727783812,west:141.246261338431,south:43.0857536607044,east:141.371254850293,note:'平成10年部修・平成11.4.1発行',list:''},
    {name:'札幌東北部',north:43.169076868838,west:141.371249763741,south:43.0857577574915,east:141.496243309123,note:'平成10年部修・平成11.1.1発行',list:''},
    {name:'江別',north:43.1690809719299,west:141.496238206895,south:43.0857618668749,east:141.621231785829,note:'平成7年修正・平成8.12.1発行',list:''},
    {name:'札幌',north:43.085749576533,west:141.246266409283,south:43.0024304439547,east:141.37125991512,note:'平成10年部修・平成11.4.1発行',list:''},
    {name:'札幌東部',north:43.0857536607044,west:141.371254850293,south:43.0024345344282,east:141.496248389559,note:'平成9年部修・平成10.2.1発行',list:''},
    {name:'野幌',north:43.0857577574915,west:141.496243309123,south:43.0024386374785,east:141.621236881849,note:'平成8年部修・平成10.4.1発行',list:''},
    {name:'石山',north:43.0024263660775,west:141.246271458478,south:42.9191072185677,east:141.371264958332,note:'平成8年修正・平成9.6.1発行',list:''},
    {name:'清田',north:43.0024304439547,west:141.37125991512,south:42.9191113027187,east:141.496253448312,note:'平成9年部修・平成10.6.1発行',list:''},
    {name:'石狩広島',north:43.0024345344282,west:141.496248389559,south:42.9191153994271,east:141.62124195612,note:'平成8年部修・平成9.3.1発行',list:''}
]});
kjmapDataSet['asahikawa'] = new Object();
dataset = kjmapDataSet['asahikawa'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1916, end:1917, scale:'1/25000', mapList: [
    {name:'永山',north:43.8356959032488,west:142.374003941115,south:43.7523769647749,east:142.498997813051,note:'大正5年測図・大正8.1.30発行',list:'39-10-1-1'},
    {name:'邊別',north:43.7523727160609,west:142.374009334974,south:43.6690537626736,east:142.499003199671,note:'大正5年測図・大正7.9.30発行',list:'39-10-2-1'},
    {name:'旭川',north:43.8356916607778,west:142.249015497543,south:43.7523727160609,east:142.374009334974,note:'大正5年測図・大正7.11.30発行',list:'39-10-3-1'},
    {name:'雨紛',north:43.7523684799573,west:142.249020875356,south:43.6690495203551,east:142.374014705642,note:'大正5年測図・大正7.11.30発行',list:'39-10-4-1'},
    {name:'比布',north:43.9190190919389,west:142.373998523946,south:43.835700158349,east:142.498992403173,note:'大正6年測図・大正8.11.30発行',list:'39-9-2-1'},
    {name:'オサラッペ',north:43.9190148431098,west:142.249010096489,south:43.8356959032488,east:142.374003941115,note:'大正6年測図・大正8.12.28発行',list:'39-9-4-1'}
]});
dataset.age.push({
  folderName:'01', start:1950, end:1952, scale:'1/25000', mapList: [
    {name:'永山',north:43.8356959032488,west:142.374003941115,south:43.7523769647749,east:142.498997813051,note:'昭和25年修正・昭和28.8.30発行',list:'39-10-1-5'},
    {name:'西神楽',north:43.7523727160609,west:142.374009334974,south:43.6690537626736,east:142.499003199671,note:'昭和25年修正・昭和28.7.30発行',list:'39-10-2-4'},
    {name:'旭川',north:43.8356916607778,west:142.249015497543,south:43.7523727160609,east:142.374009334974,note:'昭和27年測量・昭和31.11.30発行',list:'39-10-3-4'},
    {name:'雨紛',north:43.7523684799573,west:142.249020875356,south:43.6690495203551,east:142.374014705642,note:'昭和25年修正・昭和31.11.30発行',list:'39-10-4-3'},
    {name:'比布',north:43.9190190919389,west:142.373998523946,south:43.835700158349,east:142.498992403173,note:'昭和25年修正・昭和28.6.30発行',list:'39-9-2-3'},
    {name:'オサラッペ',north:43.9190148431098,west:142.249010096489,south:43.8356959032488,east:142.374003941115,note:'昭和25年修正・昭和31.11.30発行',list:'39-9-4-3'}
]});
dataset.age.push({
  folderName:'02', start:1972, end:1974, scale:'1/25000', mapList: [
    {name:'永山',north:43.8356958050576,west:142.37111530799,south:43.7523768664398,east:142.496109179128,note:'昭和47年改測・昭和48.8.30発行',list:'39-10-1-6'},
    {name:'西神楽',north:43.7523726180171,west:142.371120701478,south:43.6690536644865,east:142.49611456538,note:'昭和47年改測・昭和48.8.30発行',list:'39-10-2-6'},
    {name:'旭川',north:43.8356915628787,west:142.246126864844,south:43.7523726180171,east:142.371120701478,note:'昭和47年改測・昭和49.1.30発行',list:'39-10-3-5'},
    {name:'雨紛',north:43.7523683822051,west:142.246132242286,south:43.6690494224588,east:142.371126071777,note:'昭和49年修正・昭和51.9.30発行',list:'39-10-4-6'},
    {name:'比布',north:43.9190189936005,west:142.371109891192,south:43.8357000598661,east:142.49610376962,note:'昭和47年改測・昭和49.2.28発行',list:'39-9-2-4'},
    {name:'鷹栖',north:43.9190147450639,west:142.246121464163,south:43.8356958050576,east:142.37111530799,note:'昭和47年改測・昭和48.8.30発行',list:'39-9-4-5'}
]});
dataset.age.push({
  folderName:'03', start:1986, end:1986, scale:'1/25000', mapList: [
    {name:'永山',north:43.8356958050576,west:142.37111530799,south:43.7523768664398,east:142.496109179128,note:'昭和61年修正・昭和62.9.30発行',list:'39-10-1-8B'},
    {name:'西神楽',north:43.7523726180171,west:142.371120701478,south:43.6690536644865,east:142.49611456538,note:'昭和61年修正・昭和62.5.30発行',list:'39-10-2-8B'},
    {name:'旭川',north:43.8356915628787,west:142.246126864844,south:43.7523726180171,east:142.371120701478,note:'昭和61年修正・昭和62.5.30発行',list:'39-10-3-8B'},
    {name:'雨紛',north:43.7523683822051,west:142.246132242286,south:43.6690494224588,east:142.371126071777,note:'昭和61年修正・昭和62.9.30発行',list:'39-10-4-8B'},
    {name:'比布',north:43.9190189936005,west:142.371109891192,south:43.8357000598661,east:142.49610376962,note:'昭和61年修正・昭和62.10.30発行',list:'39-9-2-5B'},
    {name:'鷹栖',north:43.9190147450639,west:142.246121464163,south:43.8356958050576,east:142.37111530799,note:'昭和61年修正・昭和62.10.30発行',list:'39-9-4-6B'}
]});
dataset.age.push({
  folderName:'04', start:1999, end:2001, scale:'1/25000', mapList: [
    {name:'永山',north:43.8356958050576,west:142.37111530799,south:43.7523768664398,east:142.496109179128,note:'平成13年部修・平成14.9.1発行',list:'39-10-1-12'},
    {name:'西神楽',north:43.7523726180171,west:142.371120701478,south:43.6690536644865,east:142.49611456538,note:'平成11年部修・平成12.4.1発行',list:'39-10-2-11B'},
    {name:'旭川',north:43.8356915628787,west:142.246126864844,south:43.7523726180171,east:142.371120701478,note:'平成13年部修・平成14.9.1発行',list:'39-10-3-13'},
    {name:'雨紛',north:43.7523683822051,west:142.246132242286,south:43.6690494224588,east:142.371126071777,note:'平成11年部修・平成12.10.1発行',list:'39-10-4-11'},
    {name:'比布',north:43.9190189936005,west:142.371109891192,south:43.8357000598661,east:142.49610376962,note:'平成13年部修・平成14.9.1発行',list:'39-9-2-7'},
    {name:'鷹栖',north:43.9190147450639,west:142.246121464163,south:43.8356958050576,east:142.37111530799,note:'平成13年部修・平成14.9.1発行',list:'39-9-4-8'}
]});
kjmapDataSet['kushiro'] = new Object();
dataset = kjmapDataSet['kushiro'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1897, end:1897, scale:'1/50000', mapList: [
    {name:'鳥取',north:43.1742939948942,west:144.251926617053,south:43.0076560306823,east:144.501915296251,note:'明治30年製版',list:'32-10-10'},
    {name:'釧路',north:43.0076472671924,west:144.251937479743,south:42.8410092404882,east:144.501926126128,note:'明治30年製版',list:'32-11-8'}
]});
dataset.age.push({
  folderName:'01', start:1922, end:1922, scale:'1/50000', mapList: [
    {name:'大樂毛',north:43.1688444547399,west:144.246427463914,south:43.0022064880155,east:144.496416139026,note:'大正11年測図',list:'32-10-1'},
    {name:'釧路',north:43.0021977264766,west:144.246438322237,south:42.8355596972569,east:144.496426964565,note:'大正11年測図・大正12.6.30発行',list:'32-11-1'}
]});
dataset.age.push({
  folderName:'02', start:1958, end:1958, scale:'1/25000', mapList: [
    {name:'遠矢',north:43.0858554166243,west:144.37098290595,south:43.0025364331951,east:144.495977256377,note:'昭和33年測量・昭和36.1.30発行',list:'32-10-2-1'},
    {name:'釧路港',north:43.0025276716876,west:144.245999439841,south:42.9192086672883,east:144.370993747995,note:'昭和33年測量・昭和40.10.30発行',list:'32-11-3-1'},
    {name:'釧路',north:43.0025320463849,west:144.370988338565,south:42.919213047318,east:144.495982680752,note:'昭和33年測量・昭和36.1.30発行',list:'32-11-1-1'},
    {name:'大楽毛',north:43.0858510351747,west:144.24599402226,south:43.0025320463849,east:144.370988338565,note:'昭和33年測量・昭和40.10.30発行',list:'32-10-4-1'}
]});
dataset.age.push({
  folderName:'03', start:1981, end:1981, scale:'1/25000', mapList: [
    {name:'釧路',north:43.0025320463849,west:144.370988338565,south:42.919213047318,east:144.495982680752,note:'昭和56年改測・昭和58.2.28発行',list:'32-11-1-4'},
    {name:'大楽毛',north:43.0858510351747,west:144.24599402226,south:43.0025320463849,east:144.370988338565,note:'昭和56年改測・昭和57.10.30発行',list:'32-10-4-4'},
    {name:'遠矢',north:43.0858554166243,west:144.37098290595,south:43.0025364331951,east:144.495977256377,note:'昭和56年改測・昭和58.1.30発行',list:'32-10-2-4'},
    {name:'釧路港',north:43.0025276716876,west:144.245999439841,south:42.9192086672883,east:144.370993747995,note:'昭和56年改測・昭和58.1.30発行',list:'32-11-3-4'}
]});
dataset.age.push({
  folderName:'04', start:2001, end:2001, scale:'1/25000', mapList: [
    {name:'釧路',north:43.0025320463849,west:144.370988338565,south:42.919213047318,east:144.495982680752,note:'平成13年部修・平成14.5.1発行',list:'32-11-1-8'},
    {name:'大楽毛',north:43.0858510351747,west:144.24599402226,south:43.0025320463849,east:144.370988338565,note:'平成13年修正・平成14.12.1発行',list:'32-10-4-7'},
    {name:'遠矢',north:43.0858554166243,west:144.37098290595,south:43.0025364331951,east:144.495977256377,note:'平成13年修正・平成14.4.1発行',list:'32-10-2-8'},
    {name:'釧路港',north:43.0025276716876,west:144.245999439841,south:42.9192086672883,east:144.370993747995,note:'平成13年部修・平成14.6.1発行',list:'32-11-3-8'}
]});
kjmapDataSet['obihiro'] = new Object();
dataset = kjmapDataSet['obihiro'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1896, end:1896, scale:'1/50000', mapList: [
    {name:'帯廣',north:43.0078843985037,west:143.009438845517,south:42.8412462622683,east:143.259426818786,note:'明治29年製版',list:'35-15-10'}
]});
dataset.age.push({
  folderName:'01', start:1930, end:1930, scale:'1/50000', mapList: [
    {name:'帯廣',north:43.0017346952086,west:142.996390412916,south:42.8350965555118,east:143.246378378075,note:'昭和5年部修・昭和7.10.30発行',list:'35-15-3'}
]});
dataset.age.push({
  folderName:'02', start:1956, end:1957, scale:'1/25000', mapList: [
    {name:'芽室',north:42.9191612897234,west:142.996116734194,south:42.8358422044733,east:143.121110696331,note:'昭和32年測量・昭和33.11.30発行',list:'35-15-4-1'},
    {name:'帯広北部',north:43.0024888479099,west:143.121100201588,south:42.9191697937426,east:143.246094204681,note:'昭和31年測量・昭和33.11.30発行',list:'35-15-1-1'},
    {name:'帯広南部',north:42.9191655355833,west:143.121105460172,south:42.8358464560315,east:143.246099455973,note:'昭和32年測量・昭和33.11.30発行',list:'35-15-2-1'},
    {name:'祥栄',north:43.0024845954772,west:142.996111490834,south:42.9191655355833,east:143.121105460172,note:'昭和32年測量・昭和33.11.30発行',list:'35-15-3-1'}
]});
dataset.age.push({
  folderName:'03', start:1985, end:1985, scale:'1/25000', mapList: [
    {name:'芽室',north:42.9191612897234,west:142.996116734194,south:42.8358422044733,east:143.121110696331,note:'昭和60年改測・昭和62.3.30発行',list:'35-15-4-4'},
    {name:'帯広北部',north:43.0024888479099,west:143.121100201588,south:42.9191697937426,east:143.246094204681,note:'昭和60年改測・昭和62.1.30発行',list:'35-15-1-5'},
    {name:'帯広南部',north:42.9191655355833,west:143.121105460172,south:42.8358464560315,east:143.246099455973,note:'昭和60年改測・昭和61.7.30発行',list:'35-15-2-5'},
    {name:'祥栄',north:43.0024845954772,west:142.996111490834,south:42.9191655355833,east:143.121105460172,note:'昭和60年改測・昭和61.8.30発行',list:'35-15-3-5'}
]});
dataset.age.push({
  folderName:'04', start:1998, end:2000, scale:'1/25000', mapList: [
    {name:'芽室',north:42.9191612897234,west:142.996116734194,south:42.8358422044733,east:143.121110696331,note:'平成12年修正・平成13.7.1発行',list:'35-15-4-6'},
    {name:'帯広北部',north:43.0024888479099,west:143.121100201588,south:42.9191697937426,east:143.246094204681,note:'平成11年修正・平成12.6.1発行',list:'35-15-1-9B'},
    {name:'帯広南部',north:42.9191655355833,west:143.121105460172,south:42.8358464560315,east:143.246099455973,note:'平成11年修正・平成12.11.1発行',list:'35-15-2-8'},
    {name:'祥栄',north:43.0024845954772,west:142.996111490834,south:42.9191655355833,east:143.121105460172,note:'平成10年部修・平成11.11.1発行',list:'35-15-3-8B'}
]});
kjmapDataSet['tomakomai'] = new Object();
dataset = kjmapDataSet['tomakomai'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1896, end:1896, scale:'1/50000', mapList: [
    {name:'苫小牧',north:42.663142150058,west:141.492158131055,south:42.4965037445561,east:141.742145239689,note:'明治29年製版',list:'47-5-9'},
    {name:'千歳',north:42.8297886510678,west:141.492148125063,south:42.6631503160566,east:141.742135257826,note:'明治29年製版',list:'46-8-8'},
    {name:'長都',north:42.9964351273183,west:141.492138033253,south:42.8297968425616,east:141.742125190485,note:'明治29年製版',list:'46-7-10'}
]});
dataset.age.push({
  folderName:'01', start:1935, end:1935, scale:'1/50000', mapList: [
    {name:'千歳',north:42.8357881534007,west:141.499147120051,south:42.6691498212488,east:141.749134257404,note:'昭和10年修正・昭和12.1.30発行',list:'46-8-3'},
    {name:'惠庭',north:43.0024346291127,west:141.4991370234,south:42.835796347213,east:141.749124185254,note:'昭和10年修正・昭和11.9.30発行',list:'46-7-3'},
    {name:'苫小牧',north:42.6691416529334,west:141.499157130838,south:42.502503250293,east:141.74914424403,note:'昭和10年修正・昭和12.4.30発行',list:'47-5-3'}
]});
dataset.age.push({
  folderName:'02', start:1954, end:1955, scale:'1/25000', mapList: [
    {name:'沼ノ端',north:42.752468897275,west:141.621252039856,south:42.669149726574,east:141.746245621313,note:'昭和29年測量・昭和34.10.30発行',list:'46-8-2-1'},
    {name:'千歳',north:42.8357921493667,west:141.621247008753,south:42.7524729937719,east:141.746240596336,note:'昭和30年測量・昭和34.11.30発行',list:'46-8-1-1'},
    {name:'恵庭',north:42.9191113060517,west:141.496253448312,south:42.8357921493667,east:141.621247008753,note:'昭和30年二測・昭和34.10.30発行',list:'46-7-4-6'},
    {name:'長都沼',north:42.9191154027601,west:141.62124195612,south:42.8357962522428,east:141.746235549871,note:'昭和30年二測・昭和34.10.30発行',list:'46-7-2-2'},
    {name:'馬追沼',north:43.0024386374785,west:141.621236881849,south:42.9191195120064,east:141.74623048181,note:'昭和29年測量・昭和34.10.30発行',list:'46-7-1-2'},
    {name:'苫小牧',north:42.6691415588355,west:141.496268495571,south:42.5858223569172,east:141.621262037904,note:'昭和30年測量・昭和34.11.30発行',list:'47-5-3-1'},
    {name:'勇払',north:42.669145636465,west:141.621257049537,south:42.5858264406294,east:141.746250624912,note:'昭和29年測量・昭和34.10.30発行',list:'47-5-1-1'}
]});
dataset.age.push({
  folderName:'03', start:1983, end:1984, scale:'1/25000', mapList: [
    {name:'沼の端',north:42.752468897275,west:141.621252039856,south:42.669149726574,east:141.746245621313,note:'昭和58年修正・昭和59.9.30発行',list:'46-8-2-5'},
    {name:'千歳',north:42.8357921493667,west:141.621247008753,south:42.7524729937719,east:141.746240596336,note:'昭和58年修正・昭和59.10.30発行',list:'46-8-1-6'},
    {name:'恵庭',north:42.9191113060517,west:141.496253448312,south:42.8357921493667,east:141.621247008753,note:'昭和59年修正・昭和60.7.30発行',list:'46-7-4-11B'},
    {name:'長都',north:42.9191154027601,west:141.62124195612,south:42.8357962522428,east:141.746235549871,note:'昭和59年修正・昭和60.9.30発行',list:'46-7-2-8'},
    {name:'南長沼',north:43.0024386374785,west:141.621236881849,south:42.9191195120064,east:141.74623048181,note:'昭和59年修正・昭和61.1.30発行',list:'46-7-1-7'},
    {name:'苫小牧',north:42.6691415588355,west:141.496268495571,south:42.5858223569172,east:141.621262037904,note:'昭和58年修正・昭和59.8.30発行',list:'47-5-3-6'},
    {name:'勇払',north:42.669145636465,west:141.621257049537,south:42.5858264406294,east:141.746250624912,note:'昭和58年修正・昭和59.5.30発行',list:'47-5-1-6'}
]});
dataset.age.push({
  folderName:'04', start:1993, end:1999, scale:'1/25000', mapList: [
    {name:'ウトナイ湖',north:42.752468897275,west:141.621252039856,south:42.669149726574,east:141.746245621313,note:'平成9年部修・平成10.8.1発行',list:'46-8-2-7B'},
    {name:'千歳',north:42.8357921493667,west:141.621247008753,south:42.7524729937719,east:141.746240596336,note:'平成10年修正・平成11.11.1発行',list:'46-8-1-10B'},
    {name:'恵庭',north:42.9191113060517,west:141.496253448312,south:42.8357921493667,east:141.621247008753,note:'平成11年部修・平成12.4.1発行',list:'46-7-4-15B'},
    {name:'長都',north:42.9191154027601,west:141.62124195612,south:42.8357962522428,east:141.746235549871,note:'平成11年部修・平成12.4.1発行',list:'46-7-2-11B'},
    {name:'南長沼',north:43.0024386374785,west:141.621236881849,south:42.9191195120064,east:141.74623048181,note:'平成5年修正・平成6.4.1発行',list:'46-7-1-9C'},
    {name:'苫小牧',north:42.6691415588355,west:141.496268495571,south:42.5858223569172,east:141.621262037904,note:'平成10年修正・平成11.6.1発行',list:'47-5-3-8B'},
    {name:'勇払',north:42.669145636465,west:141.621257049537,south:42.5858264406294,east:141.746250624912,note:'平成11年部修・平成11.9.1発行',list:'47-5-1-8B'}
]});
kjmapDataSet['hakodate'] = new Object();
dataset = kjmapDataSet['hakodate'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1915, end:1915, scale:'1/25000', mapList: [
    {name:'赤川',north:41.9192080744739,west:140.749269370025,south:41.8358886996194,east:140.874262668058,note:'大正4年測図・昭和23.3.30発行',list:'51-1-4-2'},
    {name:'桔梗',north:41.9192041409211,west:140.624280802362,south:41.835884759969,east:140.749274068354,note:'大正4年測図・昭和23.5.30発行',list:'51-5-2-2'},
    {name:'陣屋',north:41.9192002198221,west:140.499292251867,south:41.8358808327337,east:140.624285485851,note:'大正4年測図・昭和23.4.30発行',list:'51-5-4-2'},
    {name:'函館',north:41.8358808327337,west:140.624285485851,south:41.7525614465768,east:140.749278746836,note:'大正4年測図・大正6.3.15発行',list:'51-6-1-1'},
    {name:'立待﨑',north:41.7525575256675,west:140.624290149555,south:41.6692381242781,east:140.749283405567,note:'大正4年測図・昭和23.4.30発行',list:'51-6-2-2'},
    {name:'茂辺地',north:41.8358769179321,west:140.499296920494,south:41.7525575256675,east:140.624290149555,note:'大正4年測図・大正6.3.22発行',list:'51-6-3-1'}
]});
dataset.age.push({
  folderName:'01', start:1951, end:1955, scale:'1/25000', mapList: [
    {name:'赤川',north:41.9192079834243,west:140.746380734046,south:41.8358886084294,east:140.871374031338,note:'昭和30年測量・昭和34.10.30発行',list:'51-1-4-3'},
    {name:'五稜郭',north:41.835884759969,west:140.749274068354,south:41.7525653798813,east:140.874267361295,note:'昭和26年修正・昭和28.8.30発行',list:'51-2-3-3'},
    {name:'桔梗',north:41.9192041409211,west:140.624280802362,south:41.835884759969,east:140.749274068354,note:'昭和26年修正・昭和28.4.30発行',list:'51-5-2-3'},
    {name:'陣屋',north:41.9192002198221,west:140.499292251867,south:41.8358808327337,east:140.624285485851,note:'昭和26年修正・昭和31.11.30発行',list:'51-5-4-3'},
    {name:'函館',north:41.8358808327337,west:140.624285485851,south:41.7525614465768,east:140.749278746836,note:'昭和26年修正・昭和31.11.30発行',list:'51-6-1-5'},
    {name:'立待﨑',north:41.7525575256675,west:140.624290149555,south:41.6692381242781,east:140.749283405567,note:'昭和26年修正・昭和31.11.30発行',list:'51-6-2-3'},
    {name:'茂辺地',north:41.8358769179321,west:140.499296920494,south:41.7525575256675,east:140.624290149555,note:'昭和26年修正・昭和31.11.30発行',list:'51-6-3-4'}
]});
dataset.age.push({
  folderName:'02', start:1968, end:1968, scale:'1/25000', mapList: [
    {name:'赤川',north:41.9192079834243,west:140.746380734046,south:41.8358886084294,east:140.871374031338,note:'昭和43年修正・昭和45.3.30発行',list:'51-1-4-4'},
    {name:'五稜郭',north:41.8358846690657,west:140.746385432032,south:41.7525652888381,east:140.871378724235,note:'昭和43年修正・昭和45.3.30発行',list:'51-2-3-5'},
    {name:'七飯',north:41.9192040501591,west:140.62139216678,south:41.8358846690657,east:140.746385432032,note:'昭和43年修正・昭和45.3.30発行',list:'51-5-2-5'},
    {name:'陣屋',north:41.9192001293481,west:140.496403616681,south:41.8358807421175,east:140.621396849926,note:'昭和43年修正・昭和44.12.28発行',list:'51-5-4-5'},
    {name:'函館',north:41.8358807421175,west:140.621396849926,south:41.7525613558199,east:140.746390110173,note:'昭和43年修正・昭和44.12.28発行',list:'51-6-1-7'},
    {name:'立待岬',north:41.7525574351973,west:140.621401513288,south:41.6692380336678,east:140.746394768564,note:'昭和43年修正・昭和45.3.30発行',list:'51-6-2-5'},
    {name:'茂辺地',north:41.8358768276035,west:140.496408284964,south:41.7525574351973,east:140.621401513288,note:'昭和43年修正・昭和45.1.30発行',list:'51-6-3-6'}
]});
dataset.age.push({
  folderName:'03', start:1986, end:1989, scale:'1/25000', mapList: [
    {name:'赤川',north:41.9192079834243,west:140.746380734046,south:41.8358886084294,east:140.871374031338,note:'昭和61年修正・昭和62.10.30発行',list:'51-1-4-7B'},
    {name:'五稜郭',north:41.8358846690657,west:140.746385432032,south:41.7525652888381,east:140.871378724235,note:'平成1年修正・平成2.7.1発行',list:'51-2-3-9'},
    {name:'七飯',north:41.9192040501591,west:140.62139216678,south:41.8358846690657,east:140.746385432032,note:'平成1年修正・平成2.9.1発行',list:'51-5-2-8'},
    {name:'陣屋',north:41.9192001293481,west:140.496403616681,south:41.8358807421175,east:140.621396849926,note:'平成1年修正・平成2.8.1発行',list:'51-5-4-8B'},
    {name:'函館',north:41.8358807421175,west:140.621396849926,south:41.7525613558199,east:140.746390110173,note:'平成1年修正・平成2.4.1発行',list:'51-6-1-11'},
    {name:'立待岬',north:41.7525574351973,west:140.621401513288,south:41.6692380336678,east:140.746394768564,note:'平成1年修正・平成2.4.1発行',list:'51-6-2-9'},
    {name:'茂辺地',north:41.8358768276035,west:140.496408284964,south:41.7525574351973,east:140.621401513288,note:'平成1年修正・平成2.4.1発行',list:'51-6-3-10'}
]});
dataset.age.push({
  folderName:'04', start:1996, end:2001, scale:'1/25000', mapList: [
    {name:'赤川',north:41.9192079834243,west:140.746380734046,south:41.8358886084294,east:140.871374031338,note:'平成13年修正・平成15.5.1発行',list:'51-1-4-9'},
    {name:'五稜郭',north:41.8358846690657,west:140.746385432032,south:41.7525652888381,east:140.871378724235,note:'平成11年部修・平成11.12.1発行',list:'51-2-3-11B'},
    {name:'七飯',north:41.9192040501591,west:140.62139216678,south:41.8358846690657,east:140.746385432032,note:'平成12年部修・平成12.5.1発行',list:'51-5-2-10B'},
    {name:'陣屋',north:41.9192001293481,west:140.496403616681,south:41.8358807421175,east:140.621396849926,note:'平成13年修正・平成15.9.1発行',list:'51-5-4-9'},
    {name:'函館',north:41.8358807421175,west:140.621396849926,south:41.7379043868942,east:140.746390931035,note:'平成8年修正・平成9.8.1発行',list:'51-6-1-12B'},
    {name:'茂辺地',north:41.8358768276035,west:140.496408284964,south:41.7525574351973,east:140.621401513288,note:'平成13年修正・平成15.6.1発行',list:'51-6-3-11'}
]});
kjmapDataSet['aomori'] = new Object();
dataset = kjmapDataSet['aomori'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1912, end:1912, scale:'1/25000', mapList: [
    {name:'淺虫',north:40.9193277894298,west:140.749324461079,south:40.836008229885,east:140.874317700225,note:'大正元年測図・大正4.6.30発行',list:'59-3-4-2'},
    {name:'青森東部',north:40.8360043669465,west:140.749328927501,south:40.7526848018235,east:140.874322161949,note:'大正元年測図・大正4.10.30発行',list:'59-4-3-2'},
    {name:'油川',north:40.9193239322459,west:140.624335719402,south:40.8360043669465,east:140.749328927501,note:'大正元年測図・大正4.6.30発行',list:'59-7-2-2'},
    {name:'青森西部',north:40.8360005161814,west:140.624340171717,south:40.7526809453325,east:140.749333375197,note:'大正元年測図・大正4.6.30発行',list:'59-8-1-2'}
]});
dataset.age.push({
  folderName:'01', start:1939, end:1955, scale:'1/25000', mapList: [
    {name:'淺虫',north:40.9193277894298,west:140.749324461079,south:40.836008229885,east:140.874317700225,note:'昭和14年修正・昭和22.11.30発行',list:'59-3-4-3'},
    {name:'青森東部',north:40.8360043669465,west:140.749328927501,south:40.7526848018235,east:140.874322161949,note:'大正元年測図昭和30年資修・昭和30.9.30発行',list:'59-4-3-7'},
    {name:'油川',north:40.9193239322459,west:140.624335719402,south:40.8360043669465,east:140.749328927501,note:'昭和14年修正・昭和22.11.30発行',list:'59-7-2-3'},
    {name:'青森西部',north:40.8360005161814,west:140.624340171717,south:40.7526809453325,east:140.749333375197,note:'昭和14年修正・昭和22.11.30発行',list:'59-8-1-3'}
]});
dataset.age.push({
  folderName:'02', start:1970, end:1970, scale:'1/25000', mapList: [
    {name:'浅虫',north:40.919327700148,west:140.746435821081,south:40.8360081404706,east:140.87142905951,note:'昭和45年改測・昭和47.3.30発行',list:'59-3-4-4'},
    {name:'青森東部',north:40.8360042778133,west:140.746440287178,south:40.7526847125583,east:140.871433520909,note:'昭和45年改測・昭和47.2.28発行',list:'59-4-3-4'},
    {name:'油川',north:40.9193238432461,west:140.621447079796,south:40.8360042778133,east:140.746440287178,note:'昭和45年改測・昭和46.9.30発行',list:'59-7-2-4'},
    {name:'青森西部',north:40.8360004273297,west:140.621451531784,south:40.752680856348,east:140.746444734549,note:'昭和45年改測・昭和46.7.30発行',list:'59-8-1-5'}
]});
dataset.age.push({
  folderName:'03', start:1984, end:1989, scale:'1/25000', mapList: [
    {name:'浅虫',north:40.919327700148,west:140.746435821081,south:40.8360081404706,east:140.87142905951,note:'平成1年修正・昭和47.3.30発行',list:'59-3-4-6C'},
    {name:'青森東部',north:40.8360042778133,west:140.746440287178,south:40.7526847125583,east:140.871433520909,note:'昭和62年修正・昭和63.7.30発行',list:'59-4-3-8B'},
    {name:'油川',north:40.9193238432461,west:140.621447079796,south:40.8360042778133,east:140.746440287178,note:'昭和59年修正・昭和62.1.30発行',list:'59-7-2-6D'},
    {name:'青森西部',north:40.8360004273297,west:140.621451531784,south:40.752680856348,east:140.746444734549,note:'昭和62年修正・昭和63.7.30発行',list:'59-8-1-8'}
]});
dataset.age.push({
  folderName:'04', start:2003, end:2011, scale:'1/25000', mapList: [
    {name:'浅虫',north:40.919327700148,west:140.746435821081,south:40.8360081404706,east:140.87142905951,note:'平成15年更新・平成17.1.1発行',list:'59-3-4-7'},
    {name:'青森東部',north:40.8360042778133,west:140.746440287178,south:40.7526847125583,east:140.871433520909,note:'平成23年更新・平成24.3.1発行',list:'59-4-3-11'},
    {name:'油川',north:40.9193238432461,west:140.621447079796,south:40.8360042778133,east:140.746440287178,note:'平成23年更新・平成24.3.1発行',list:'59-7-2-8'},
    {name:'青森西部',north:40.8360004273297,west:140.621451531784,south:40.752680856348,east:140.746444734549,note:'平成23年更新・平成24.3.1発行',list:'59-8-1-10'}
]});
kjmapDataSet['hirosaki'] = new Object();
dataset = kjmapDataSet['hirosaki'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1912, end:1912, scale:'1/25000', mapList: [
    {name:'五所川原',north:40.8359928512445,west:140.374362710753,south:40.7526732688279,east:140.499355852397,note:'明治45年測図・大正5.3.30発行',list:'59-12-1-2'},
    {name:'板柳',north:40.7526694488509,west:140.37436711624,south:40.669349850915,east:140.499360253455,note:'明治45年測図・大正5.4.30発行',list:'59-12-2-2'},
    {name:'浪岡',north:40.7526732688279,west:140.499355852397,south:40.6693536766665,east:140.624349020434,note:'明治45年測図・大正4.10.30発行',list:'59-8-4-2'},
    {name:'黒石',north:40.669349850915,west:140.499360253455,south:40.5860302331783,east:140.624353417014,note:'明治45年測図・大正4.10.30発行',list:'60-5-3-2'},
    {name:'大鰐',north:40.5860264138503,west:140.499364636083,south:40.5027067905079,east:140.624357795192,note:'明治45年測図・大正4.12.28発行',list:'60-5-4-2'},
    {name:'弘前',north:40.6693460373326,west:140.374371503267,south:40.5860264138503,east:140.499364636083,note:'明治45年測図・大正5.2.28発行',list:'60-9-1-2'},
    {name:'久渡寺',north:40.586022606671,west:140.374375871922,south:40.5027029776116,east:140.499369000368,note:'明治45年測図・大正4.12.28発行',list:'60-9-2-2'}
]});
dataset.age.push({
  folderName:'01', start:1939, end:1939, scale:'1/25000', mapList: [
    {name:'五所川原',north:40.8359928512445,west:140.374362710753,south:40.7526732688279,east:140.499355852397,note:'昭和14年修正・昭和22.11.30発行',list:'59-12-1-5'},
    {name:'板柳',north:40.7526694488509,west:140.37436711624,south:40.669349850915,east:140.499360253455,note:'昭和14年修正・昭和22.11.30発行',list:'59-12-2-4'},
    {name:'浪岡',north:40.7526732688279,west:140.499355852397,south:40.6693536766665,east:140.624349020434,note:'昭和14年修正・昭和22.11.30発行',list:'59-8-4-3'},
    {name:'黒石',north:40.669349850915,west:140.499360253455,south:40.5860302331783,east:140.624353417014,note:'昭和14年修正・昭和22.11.30発行',list:'60-5-3-5'},
    {name:'大鰐',north:40.5860264138503,west:140.499364636083,south:40.5027067905079,east:140.624357795192,note:'昭和14年修正・昭和22.11.30発行',list:'60-5-4-4'},
    {name:'弘前',north:40.6693460373326,west:140.374371503267,south:40.5860264138503,east:140.499364636083,note:'昭和14年修正・昭和22.11.30発行',list:'60-9-1-5'},
    {name:'久渡寺',north:40.586022606671,west:140.374375871922,south:40.5027029776116,east:140.499369000368,note:'昭和14年修正・昭和17.7.30発行',list:'60-9-2-6',war:true}
]});
dataset.age.push({
  folderName:'02', start:1970, end:1971, scale:'1/25000', mapList: [
    {name:'五所川原',north:40.8359927629572,west:140.371474071599,south:40.752673180406,east:140.496467212528,note:'昭和45年改測・昭和47.3.30発行',list:'59-12-1-6'},
    {name:'板柳',north:40.7526693607109,west:140.371478476759,south:40.6693497626411,east:140.496471613263,note:'昭和45年改測・昭和47.1.30発行',list:'59-12-2-5'},
    {name:'浪岡',north:40.752673180406,west:140.496467212528,south:40.6693535881115,east:140.621460379853,note:'昭和45年改測・昭和47.3.30発行',list:'59-8-4-4'},
    {name:'黒石',north:40.6693497626411,west:140.496471613263,south:40.5860301447721,east:140.621464776111,note:'昭和46年改測・昭和48.2.28発行',list:'60-5-3-7'},
    {name:'大鰐',north:40.5860263257246,west:140.496475995568,south:40.5027067022505,east:140.621469153968,note:'昭和46年改測・昭和48.2.28発行',list:'60-5-4-5'},
    {name:'弘前',north:40.6693459493402,west:140.371482863462,south:40.5860263257246,east:140.496475995568,note:'昭和46年改測・昭和48.2.28発行',list:'60-9-1-7'},
    {name:'久渡寺',north:40.5860225188263,west:140.371487231794,south:40.5027028896343,east:140.496480359531,note:'昭和46年改測・昭和47.9.30発行',list:'60-9-2-3'}
]});
dataset.age.push({
  folderName:'03', start:1980, end:1986, scale:'1/25000', mapList: [
    {name:'五所川原',north:40.8359927629572,west:140.371474071599,south:40.752673180406,east:140.496467212528,note:'昭和61年修正・昭和63.3.30発行',list:'59-12-1-8B'},
    {name:'板柳',north:40.7526693607109,west:140.371478476759,south:40.6693497626411,east:140.496471613263,note:'昭和61年修正・昭和63.3.30発行',list:'59-12-2-8B'},
    {name:'浪岡',north:40.752673180406,west:140.496467212528,south:40.6693535881115,east:140.621460379853,note:'昭和55年修正・昭和57.4.30発行',list:'59-8-4-6'},
    {name:'黒石',north:40.6693497626411,west:140.496471613263,south:40.5860301447721,east:140.621464776111,note:'昭和56年修正・昭和57.11.30発行',list:'60-5-3-9B'},
    {name:'大鰐',north:40.5860263257246,west:140.496475995568,south:40.5027067022505,east:140.621469153968,note:'昭和56年修正・昭和58.1.30発行',list:'60-5-4-7B'},
    {name:'弘前',north:40.6693459493402,west:140.371482863462,south:40.5860263257246,east:140.496475995568,note:'昭和56年修正・昭和57.10.30発行',list:'60-9-1-9B'},
    {name:'久渡寺',north:40.5860225188263,west:140.371487231794,south:40.5027028896343,east:140.496480359531,note:'昭和56年修正・昭和57.10.30発行',list:'60-9-2-5'}
]});
dataset.age.push({
  folderName:'04', start:1994, end:1997, scale:'1/25000', mapList: [
    {name:'五所川原',north:40.8359927629572,west:140.371474071599,south:40.752673180406,east:140.496467212528,note:'平成9年二改・平成10.10.1発行',list:'59-12-1-9B'},
    {name:'板柳',north:40.7526693607109,west:140.371478476759,south:40.6693497626411,east:140.496471613263,note:'平成9年二改・平成10.10.1発行',list:'59-12-2-9B'},
    {name:'浪岡',north:40.752673180406,west:140.496467212528,south:40.6693535881115,east:140.621460379853,note:'平成7年修正・平成8.6.1発行',list:'59-8-4-8B'},
    {name:'黒石',north:40.6693497626411,west:140.496471613263,south:40.5860301447721,east:140.621464776111,note:'平成6年修正・平成7.8.1発行',list:'60-5-3-11B'},
    {name:'大鰐',north:40.5860263257246,west:140.496475995568,south:40.5027067022505,east:140.621469153968,note:'平成6年修正・平成7.12.1発行',list:'60-5-4-9B'},
    {name:'弘前',north:40.6693459493402,west:140.371482863462,south:40.5860263257246,east:140.496475995568,note:'平成6年修正・平成7.3.1発行',list:'60-9-1-11B'},
    {name:'久渡寺',north:40.5860225188263,west:140.371487231794,south:40.5027028896343,east:140.496480359531,note:'平成6年修正・平成7.12.1発行',list:'60-9-2-8B'}
]});
kjmapDataSet['morioka'] = new Object();
dataset = kjmapDataSet['morioka'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1911, end:1912, scale:'1/25000', mapList: [
    {name:'川又',north:39.8361340501126,west:141.124347951021,south:39.7528143117793,east:141.249341221659,note:'明治44年測図・大正5.1.30発行',list:'56-14-1-2'},
    {name:'盛岡',north:39.7528104976939,west:141.124352220754,south:39.6694907433329,east:141.249345486836,note:'明治44年測図・大正5.4.30発行',list:'56-14-2-2'},
    {name:'姥屋敷',north:39.8361302412921,west:140.999358980245,south:39.7528104976939,east:141.124352220754,note:'明治45年測図・大正4.12.28発行',list:'56-14-3-2'},
    {name:'厨川村',north:39.7528066954617,west:140.999363236678,south:39.6694869358646,east:141.124356472707,note:'明治44年測図・大正5.4.30発行',list:'56-14-4-2'},
    {name:'矢幅',north:39.6694869358646,west:141.124356472707,south:39.5861671554494,east:141.249349734263,note:'明治44年測図・大正5.2.28発行',list:'56-15-1-2'},
    {name:'日詰',north:39.5861633546064,west:141.124360706964,south:39.502843568107,east:141.249353964019,note:'明治44年測図・大正5.3.30発行',list:'56-15-2-2'},
    {name:'城内山',north:39.6694831402289,west:140.999367475387,south:39.5861633546064,east:141.124360706964,note:'明治44年測図・大正5.2.28発行',list:'56-15-3-2'},
    {name:'志和',north:39.5861595655755,west:140.999371696455,south:39.5028397738977,east:141.124364923606,note:'明治44年測図・大正5.1.30発行',list:'56-15-4-2'}
]});
dataset.age.push({
  folderName:'01', start:1939, end:1939, scale:'1/25000', mapList: [
    {name:'川又',north:39.8361340501126,west:141.124347951021,south:39.7528143117793,east:141.249341221659,note:'昭和14年修正',list:'56-14-1-3'},
    {name:'盛岡',north:39.7528104976939,west:141.124352220754,south:39.6694907433329,east:141.249345486836,note:'昭和14年修正・昭和16.7.30発行',list:'56-14-2-5',war:true},
    {name:'姥屋敷',north:39.8361302412921,west:140.999358980245,south:39.7528104976939,east:141.124352220754,note:'昭和14年修正・昭和22.11.30発行',list:'56-14-3-3'},
    {name:'日詰',north:39.5861633546064,west:141.124360706964,south:39.502843568107,east:141.249353964019,note:'昭和14年修正・昭和22.11.30発行',list:'56-15-2-3'},
    {name:'城内山',north:39.6694831402289,west:140.999367475387,south:39.5861633546064,east:141.124360706964,note:'昭和14年修正・昭和22.11.30発行',list:'56-15-3-3'},
    {name:'志和',north:39.5861595655755,west:140.999371696455,south:39.5028397738977,east:141.124364923606,note:'昭和14年修正・昭和22.11.30発行',list:'56-15-4-3'}
]});
dataset.age.push({
  folderName:'02', start:1968, end:1969, scale:'1/25000', mapList: [
    {name:'鷹高',north:39.8361339619521,west:141.12145930573,south:39.7528142234975,east:141.246452575671,note:'昭和44年改測・昭和46.5.30発行',list:'56-14-1-5'},
    {name:'盛岡',north:39.7528104096859,west:141.121463575155,south:39.6694906552043,east:141.246456840543,note:'昭和44年改測・昭和46.4.30発行',list:'56-14-2-8'},
    {name:'姥屋敷',north:39.8361301534062,west:140.996470335342,south:39.7528104096859,east:141.121463575155,note:'昭和44年改測・昭和47.2.28発行',list:'56-14-3-4'},
    {name:'小岩井農場',north:39.7528066077278,west:140.996474591467,south:39.6694868480093,east:141.121467826803,note:'昭和44年改測・昭和45.11.30発行',list:'56-14-4-5'},
    {name:'矢幅',north:39.6694868480093,west:141.121467826803,south:39.5861670674741,east:141.246461087665,note:'昭和43年改測・昭和45.1.30発行',list:'56-15-1-5'},
    {name:'日詰',north:39.586163266904,west:141.121472060755,south:39.5028434802853,east:141.246465317119,note:'昭和43年改測・昭和45.5.30発行',list:'56-15-2-4'},
    {name:'南昌山',north:39.6694830526472,west:140.99647882987,south:39.586163266904,east:141.121472060755,note:'昭和43年改測・昭和45.2.28発行',list:'56-15-3-4'},
    {name:'志和',north:39.5861594781462,west:140.996483050633,south:39.5028396863483,east:141.121476277094,note:'昭和43年改測・昭和45.4.30発行',list:'56-15-4-4'}
]});
dataset.age.push({
  folderName:'03', start:1983, end:1988, scale:'1/25000', mapList: [
    {name:'鷹高',north:39.8361339619521,west:141.12145930573,south:39.7528142234975,east:141.246452575671,note:'昭和58年二改・昭和60.11.30発行',list:'56-14-1-9'},
    {name:'盛岡',north:39.7528104096859,west:141.121463575155,south:39.6694906552043,east:141.246456840543,note:'昭和58年二改・昭和61.1.30発行',list:'56-14-2-11'},
    {name:'姥屋敷',north:39.8361301534062,west:140.996470335342,south:39.7528104096859,east:141.121463575155,note:'昭和58年二改・昭和60.12.28発行',list:'56-14-3-7'},
    {name:'小岩井農場',north:39.7528066077278,west:140.996474591467,south:39.6694868480093,east:141.121467826803,note:'昭和58年二改・昭和59.9.30発行',list:'56-14-4-8'},
    {name:'矢幅',north:39.6694868480093,west:141.121467826803,south:39.5861670674741,east:141.246461087665,note:'昭和63年修正・平成1.5.1発行',list:'56-15-1-8'},
    {name:'日詰',north:39.586163266904,west:141.121472060755,south:39.5028434802853,east:141.246465317119,note:'昭和63年修正・平成1.10.1発行',list:'56-15-2-7'},
    {name:'南昌山',north:39.6694830526472,west:140.99647882987,south:39.586163266904,east:141.121472060755,note:'昭和63年修正・平成1.6.1発行',list:'56-15-3-7'},
    {name:'志和',north:39.5861594781462,west:140.996483050633,south:39.5028396863483,east:141.121476277094,note:'昭和63年修正・平成1.6.1発行',list:'56-15-4-7'}
]});
dataset.age.push({
  folderName:'04', start:1999, end:2002, scale:'1/25000', mapList: [
    {name:'鷹高',north:39.8361339619521,west:141.12145930573,south:39.7528142234975,east:141.246452575671,note:'平成14年部修・平成14.12.1発行',list:'56-14-1-12'},
    {name:'盛岡',north:39.7528104096859,west:141.121463575155,south:39.6694906552043,east:141.246456840543,note:'平成14年部修・平成14.12.1発行',list:'56-14-2-15'},
    {name:'姥屋敷',north:39.8361301534062,west:140.996470335342,south:39.7528104096859,east:141.121463575155,note:'平成11年修正・平成12.7.1発行',list:'56-14-3-10B'},
    {name:'小岩井農場',north:39.7528066077278,west:140.996474591467,south:39.6694868480093,east:141.121467826803,note:'平成14年部修・平成14.12.1発行',list:'56-14-4-13'},
    {name:'矢幅',north:39.6694868480093,west:141.121467826803,south:39.5861670674741,east:141.246461087665,note:'平成13年修正・平成14.12.1発行',list:'56-15-1-11'},
    {name:'日詰',north:39.586163266904,west:141.121472060755,south:39.5028434802853,east:141.246465317119,note:'平成13年修正・平成15.2.1発行',list:'56-15-2-10'},
    {name:'南昌山',north:39.6694830526472,west:140.99647882987,south:39.586163266904,east:141.121472060755,note:'平成13年修正・平成14.11.1発行',list:'56-15-3-10'},
    {name:'志和',north:39.5861594781462,west:140.996483050633,south:39.5028396863483,east:141.121476277094,note:'平成13年修正・平成15.2.1発行',list:'56-15-4-9'}
]});
kjmapDataSet['sendai'] = new Object();
dataset = kjmapDataSet['sendai'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1928, end:1933, scale:'1/25000', mapList: [
    {name:'根白石',north:38.4196225316993,west:140.749450642869,south:38.3363024994089,east:140.874443753022,note:'昭和3年測図・昭和6.2.28発行',list:''},
    {name:'富谷',north:38.41962620431,west:140.874439799504,south:38.3363061768697,east:140.99943293848,note:'昭和3年測図・昭和6.1.30発行',list:''},
    {name:'松島',north:38.4196298884768,west:140.999428972552,south:38.3363098658482,east:141.124422140384,note:'昭和8年修正・昭和11.1.30発行',list:''},
    {name:'小野',north:38.4196335841822,west:141.124418162063,south:38.3363135663266,east:141.249411358783,note:'昭和8年修正・昭和10.12.28発行',list:''},
    {name:'仙台西北部',north:38.3362988334831,west:140.749454583957,south:38.2529787847904,east:140.87444769019,note:'昭和3年測図5年鉄補・昭和6.1.30発行',list:''},
    {name:'仙台東北部',north:38.3363024994089,west:140.874443753022,south:38.2529824555373,east:140.999436888008,note:'昭和3年測図5年鉄補・昭和6.1.30発行',list:''},
    {name:'塩竃',north:38.3363061768697,west:140.99943293848,south:38.2529861377808,east:141.124426102252,note:'昭和8年修正・昭和11.1.30発行',list:''},
    {name:'宮戸島',north:38.3363098658482,west:141.124422140384,south:38.2529898315033,east:141.249415332973,note:'昭和8年修正・昭和10.12.28発行',list:''},
    {name:'仙台西南部',north:38.2529751255575,west:140.749458508747,south:38.1696550604359,east:140.874451611082,note:'昭和3年測図・昭和5.10.30発行',list:''},
    {name:'仙台東南部',north:38.2529787847904,west:140.87444769019,south:38.1696587244609,east:140.999440821208,note:'昭和3年測図・昭和5.10.30発行',list:''},
    {name:'岩沼',north:38.1696514079038,west:140.749462417311,south:38.0863313263269,east:140.874455515769,note:'昭和3年測図・昭和6.2.28発行',list:''},
    {name:'三軒茶屋',north:38.1696550604359,west:140.874451611082,south:38.086334983622,east:140.999444738153,note:'昭和3年測図・昭和6.2.28発行',list:''}
]});
dataset.age.push({
  folderName:'01', start:1946, end:1946, scale:'1/25000', mapList: [
    {name:'仙台西北部',north:38.3362988334831,west:140.749454583957,south:38.2529787847904,east:140.87444769019,note:'昭和21年修正・昭和22.8.30発行',list:''},
    {name:'仙台東北部',north:38.3363024994089,west:140.874443753022,south:38.2529824555373,east:140.999436888008,note:'昭和21年修正・昭和22.9.30発行',list:''},
    {name:'塩竃',north:38.3363061768697,west:140.99943293848,south:38.2529861377808,east:141.124426102252,note:'昭和21年修正・昭和22.9.30発行',list:''},
    {name:'仙台西南部',north:38.2529751255575,west:140.749458508747,south:38.1696550604359,east:140.874451611082,note:'昭和21年修正・発行',list:''},
    {name:'仙台東南部',north:38.2529787847904,west:140.87444769019,south:38.1696587244609,east:140.999440821208,note:'昭和21年修正・昭和22.9.30発行',list:''},
    {name:'仙台東南部',north:38.2529824555373,west:140.999436888008,south:38.1696623999614,east:141.124430047742,note:'昭和21年修正・昭和22.9.30発行',list:''}
]});
dataset.age.push({
  folderName:'02', start:1963, end:1967, scale:'1/25000', mapList: [
    {name:'根白石',north:38.419622446958,west:140.746562004776,south:38.336302414555,east:140.871555114263,note:'昭和39年改測・昭和41.7.30発行',list:''},
    {name:'富谷',north:38.4196261193014,west:140.871551161033,south:38.3363060917494,east:140.996544299342,note:'昭和39年改測・昭和42.3.30発行',list:''},
    {name:'松島',north:38.4196298032013,west:140.9965403337,south:38.3363097804619,east:141.121533500865,note:'昭和39年改測・昭和41.7.30発行',list:''},
    {name:'小野',north:38.4196334986402,west:141.12152952283,south:38.3363134806748,east:141.246522718882,note:'昭和39年改測・昭和40.11.30発行',list:''},
    {name:'仙台西北部',north:38.336298748896,west:140.746565945577,south:38.2529787000914,east:140.871559051145,note:'昭和39年改測・昭和41.7.30発行',list:''},
    {name:'仙台東北部',north:38.336302414555,west:140.871555114263,south:38.2529823705724,east:140.996548248584,note:'昭和39年改測・昭和41.7.30発行',list:''},
    {name:'塩竃',north:38.3363060917494,west:140.996544299342,south:38.2529860525504,east:141.121537462448,note:'昭和42年修正・昭和43.9.30発行',list:''},
    {name:'宮戸島',north:38.3363097804619,west:141.121533500865,south:38.2529897460078,east:141.246526692788,note:'昭和39年改測・昭和41.7.30発行',list:''},
    {name:'仙台西南部',north:38.2529750411248,west:140.74656987008,south:38.169654975892,east:140.871562971752,note:'昭和39年改測・昭和41.7.30発行',list:''},
    {name:'仙台東南部',north:38.2529787000914,west:140.871559051145,south:38.1696586396516,east:140.9965521815,note:'昭和39年改測・昭和41.7.30発行',list:''},
    {name:'仙台東南部',north:38.2529823705724,west:140.996548248584,south:38.1696623148871,east:141.121541407654,note:'昭和39年改測・昭和41.7.30発行',list:''},
    {name:'岩沼',north:38.1696513236258,west:140.746573778359,south:38.0863312419383,east:140.871566876156,note:'昭和39年改測・昭和42.3.30発行',list:''},
    {name:'仙台空港',north:38.169654975892,west:140.871562971752,south:38.0863348989685,east:140.996556098162,note:'昭和38年改測・昭和40.11.30発行',list:''}
]});
dataset.age.push({
  folderName:'03', start:1977, end:1978, scale:'1/25000', mapList: [
    {name:'根白石',north:38.419622446958,west:140.746562004776,south:38.336302414555,east:140.871555114263,note:'昭和53年二改・昭和55.1.30発行',list:''},
    {name:'富谷',north:38.4196261193014,west:140.871551161033,south:38.3363060917494,east:140.996544299342,note:'昭和53年二改・昭和55.12.28発行',list:''},
    {name:'松島',north:38.4196298032013,west:140.9965403337,south:38.3363097804619,east:141.121533500865,note:'昭和53年二改・昭和54.12.28発行',list:''},
    {name:'小野',north:38.4196334986402,west:141.12152952283,south:38.3363134806748,east:141.246522718882,note:'昭和53年改測・昭和55.9.30発行',list:''},
    {name:'仙台西北部',north:38.336298748896,west:140.746565945577,south:38.2529787000914,east:140.871559051145,note:'昭和52年二改・昭和53.11.30発行',list:''},
    {name:'仙台東北部',north:38.336302414555,west:140.871555114263,south:38.2529823705724,east:140.996548248584,note:'昭和52年二改・昭和53.10.30発行',list:''},
    {name:'塩竃',north:38.3363060917494,west:140.996544299342,south:38.2529860525504,east:141.121537462448,note:'昭和52年二改・昭和54.2.28発行',list:''},
    {name:'宮戸島',north:38.3363097804619,west:141.121533500865,south:38.2529897460078,east:141.246526692788,note:'昭和52年二改・昭和53.10.30発行',list:''},
    {name:'仙台西南部',north:38.2529750411248,west:140.74656987008,south:38.169654975892,east:140.871562971752,note:'昭和52年二改・昭和53.12.28発行',list:''},
    {name:'仙台東南部',north:38.2529787000914,west:140.871559051145,south:38.1696586396516,east:140.9965521815,note:'昭和52年二改・昭和53.10.30発行',list:''},
    {name:'仙台東南部',north:38.2529823705724,west:140.996548248584,south:38.1696623148871,east:141.121541407654,note:'昭和52年二改・昭和53.10.30発行',list:''},
    {name:'岩沼',north:38.1696513236258,west:140.746573778359,south:38.0863312419383,east:140.871566876156,note:'昭和52年二改・昭和53.11.30発行',list:''},
    {name:'仙台空港',north:38.169654975892,west:140.871562971752,south:38.0863348989685,east:140.996556098162,note:'昭和52年二改・昭和54.2.28発行',list:''}
]});
dataset.age.push({
  folderName:'04', start:1995, end:2000, scale:'1/25000', mapList: [
    {name:'根白石',north:38.419622446958,west:140.746562004776,south:38.336302414555,east:140.871555114263,note:'平成10年部修・平成10.10.1発行',list:''},
    {name:'富谷',north:38.4196261193014,west:140.871551161033,south:38.3363060917494,east:140.996544299342,note:'平成10年部修・平成10.7.1発行',list:''},
    {name:'松島',north:38.4196298032013,west:140.9965403337,south:38.3363097804619,east:141.121533500865,note:'平成9年部修・平成9.3.27発行',list:''},
    {name:'小野',north:38.4196334986402,west:141.12152952283,south:38.3363134806748,east:141.246522718882,note:'平成9年部修・平成10.3.20発行',list:''},
    {name:'仙台西北部',north:38.336298748896,west:140.746565945577,south:38.2529787000914,east:140.871559051145,note:'平成10年部修・平成10.9.1発行',list:''},
    {name:'仙台東北部',north:38.336302414555,west:140.871555114263,south:38.2529823705724,east:140.996548248584,note:'平成12年部修・平成12.5.1発行',list:''},
    {name:'塩竃',north:38.3363060917494,west:140.996544299342,south:38.2529860525504,east:141.121537462448,note:'平成10年部修・平成10.11.1発行',list:''},
    {name:'宮戸島',north:38.3363097804619,west:141.121533500865,south:38.2529897460078,east:141.246526692788,note:'平成12年修正・平成13.9.1発行',list:''},
    {name:'仙台西南部',north:38.2529750411248,west:140.74656987008,south:38.169654975892,east:140.871562971752,note:'平成10年部修・平成10.10.1発行',list:''},
    {name:'仙台東南部',north:38.2529787000914,west:140.871559051145,south:38.1696586396516,east:140.9965521815,note:'平成10年部修・平成10.10.1発行',list:''},
    {name:'仙台東南部',north:38.2529823705724,west:140.996548248584,south:38.1696623148871,east:141.121541407654,note:'平成10年部修・平成10.10.1発行',list:''},
    {name:'岩沼',north:38.1696513236258,west:140.746573778359,south:38.0863312419383,east:140.871566876156,note:'平成7年修正・平成8.6.1発行',list:''},
    {name:'仙台空港',north:38.169654975892,west:140.871562971752,south:38.0863348989685,east:140.996556098162,note:'平成7年修正・平成8.6.1発行',list:''}
]});
kjmapDataSet['akita'] = new Object();
dataset = kjmapDataSet['akita'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1912, end:1912, scale:'1/25000', mapList: [
    {name:'大久保',north:39.9194236948889,west:139.999443647621,south:39.8361039135244,east:140.124436652169,note:'明治45年測図・大正3.12.28発行',list:'61-13-4-2'},
    {name:'目長﨑',north:39.7527804132341,west:140.12444081494,south:39.6694606159043,east:140.249433841507,note:'明治45年測図・大正3.12.28発行',list:'61-14-2-2'},
    {name:'土崎',north:39.8361002003403,west:139.99944781429,south:39.7527804132341,east:140.12444081494,note:'明治45年測図・大正3.12.28発行',list:'61-14-3-2'},
    {name:'秋田',north:39.7527767064728,west:139.999451963601,south:39.6694569035985,east:140.124444960377,note:'明治45年測図・大正3.12.28発行',list:'61-14-4-2'},
    {name:'和田',north:39.6694569035985,west:140.124444960377,south:39.5861370804454,east:140.24943798302,note:'明治45年測図・大正3.12.28発行',list:'61-15-1-2'},
    {name:'羽川',north:39.6694532032681,west:139.999456095634,south:39.5861333745994,east:140.124449088561,note:'明治45年測図・大正3.12.28発行',list:'61-15-3-2'}
]});
dataset.age.push({
  folderName:'01', start:1971, end:1972, scale:'1/25000', mapList: [
    {name:'大久保',north:39.919423609067,west:139.996555006097,south:39.8361038275726,east:140.121548009954,note:'昭和46年改測・昭和49.3.30発行',list:'61-13-4-5'},
    {name:'秋田東部',north:39.7527803274309,west:140.121552172414,south:39.6694605299734,east:140.246545198292,note:'昭和46年改測・昭和49.2.28発行',list:'61-14-2-6'},
    {name:'土崎',north:39.8361001146664,west:139.996559172454,south:39.7527803274309,east:140.121552172414,note:'昭和46年改測・昭和49.2.28発行',list:'61-14-3-5'},
    {name:'秋田西部',north:39.7527766209471,west:139.996563321453,south:39.6694568179442,east:140.121556317541,note:'昭和46年改測・昭和49.2.28発行',list:'61-14-4-6'},
    {name:'羽後和田',north:39.6694568179442,west:140.121556317541,south:39.586136994664,east:140.246549339497,note:'昭和47年改測・昭和49.2.28発行',list:'61-15-1-5C'},
    {name:'羽川',north:39.6694531178908,west:139.996567453176,south:39.5861332890941,east:140.121560445417,note:'昭和47年改測・昭和49.3.30発行',list:'61-15-3-5'}
]});
dataset.age.push({
  folderName:'02', start:1985, end:1990, scale:'1/25000', mapList: [
    {name:'大久保',north:39.919423609067,west:139.996555006097,south:39.8361038275726,east:140.121548009954,note:'平成2年修正・平成3.5.1発行',list:'61-13-4-7'},
    {name:'秋田東部',north:39.7527803274309,west:140.121552172414,south:39.6694605299734,east:140.246545198292,note:'昭和60年修正・昭和61.4.30発行',list:'61-14-2-9'},
    {name:'土崎',north:39.8361001146664,west:139.996559172454,south:39.7527803274309,east:140.121552172414,note:'昭和60年修正・昭和61.4.30発行',list:'61-14-3-8'},
    {name:'秋田西部',north:39.7527766209471,west:139.996563321453,south:39.6694568179442,east:140.121556317541,note:'昭和60年修正・昭和61.4.30発行',list:'61-14-4-9'},
    {name:'羽後和田',north:39.6694568179442,west:140.121556317541,south:39.586136994664,east:140.246549339497,note:'昭和60年修正・昭和61.6.30発行',list:'61-15-1-6'},
    {name:'羽川',north:39.6694531178908,west:139.996567453176,south:39.5861332890941,east:140.121560445417,note:'昭和60年修正・昭和61.6.30発行',list:'61-15-3-6'}
]});
dataset.age.push({
  folderName:'03', start:2006, end:2007, scale:'1/25000', mapList: [
    {name:'大久保',north:39.919423609067,west:139.996555006097,south:39.8361038275726,east:140.121548009954,note:'平成19年更新・平成19.8.1発行',list:'61-13-4-10'},
    {name:'秋田東部',north:39.7527803274309,west:140.121552172414,south:39.6694605299734,east:140.246545198292,note:'平成18年更新・平成18.12.1発行',list:'61-14-2-13'},
    {name:'土崎',north:39.8361001146664,west:139.996559172454,south:39.7527803274309,east:140.121552172414,note:'平成18年更新・平成18.12.1発行',list:'61-14-3-11'},
    {name:'秋田西部',north:39.7527766209471,west:139.996563321453,south:39.6694568179442,east:140.121556317541,note:'平成18年更新・平成18.12.1発行',list:'61-14-4-12'},
    {name:'羽後和田',north:39.6694568179442,west:140.121556317541,south:39.586136994664,east:140.246549339497,note:'平成18年更新・平成19.2.1発行',list:'61-15-1-11'},
    {name:'羽川',north:39.6694531178908,west:139.996567453176,south:39.5861332890941,east:140.121560445417,note:'平成18年更新・平成18.12.1発行',list:'61-15-3-8'}
]});
kjmapDataSet['yamagata'] = new Object();
dataset = kjmapDataSet['yamagata'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1901, end:1903, scale:'1/20000', mapList: [
    {name:'東根',north:38.4696052450556,west:140.399478750839,south:38.4029492135905,east:140.499473174332,note:'明治34年測図 ・明治37.6.30発行',list:'s643'},
    {name:'山口',north:38.4029463034502,west:140.399481884866,south:38.3362902615551,east:140.499476305971,note:'明治34年測図 ・明治37.6.30発行',list:'s644'},
    {name:'山寺',north:38.3362873556544,west:140.399485008519,south:38.2696313133148,east:140.499479427244,note:'明治34年測図 ・明治37.6.30発行',list:'s645'},
    {name:'楯岡',north:38.5362612593312,west:140.29948434338,south:38.4696052450556,east:140.399478750839,note:'明治34年測図 ・明治37.3.30発行',list:'s647'},
    {name:'谷地',north:38.4696023381259,west:140.299487479771,south:38.4029463034502,east:140.399481884866,note:'明治34年測図 ・明治37.6.30発行',list:'s648'},
    {name:'天童',north:38.4029434007453,west:140.299490605776,south:38.3362873556544,east:140.399485008519,note:'明治34年測図 ・明治37.6.30発行',list:'s649'},
    {name:'漆山',north:38.3362844571784,west:140.299493721433,south:38.2696284116578,east:140.399488121832,note:'明治34年測図 ・明治37.6.30発行',list:'s650'},
    {name:'山形',north:38.2696255174147,west:140.299496826777,south:38.202969451453,east:140.399491224844,note:'明治34年測図 ・明治37.3.30発行',list:'s652'},
    {name:'黑澤',north:38.2029665614468,west:140.299499921846,south:38.1363104850293,east:140.399494317592,note:'明治34年測図 ・明治36.12.28発行',list:'s654'},
    {name:'寒河江',north:38.4029405054847,west:140.199499337035,south:38.3362844571784,east:140.299493721433,note:'明治36年測図 ・明治38.3.30発行',list:'s657'},
    {name:'山邊',north:38.3362815661359,west:140.199502444686,south:38.2696255174147,east:140.299496826777,note:'明治36年測図 ・明治38.3.30発行',list:'s659'},
    {name:'門傅',north:38.2696226305942,west:140.199505542051,south:38.2029665614468,east:140.299499921846,note:'明治36年測図 ・明治37.12.28発行',list:'s661'},
    {name:'上山',north:38.2029636788523,west:140.199508629168,south:38.1363075992641,east:140.299503006677,note:'明治36年測図 ・明治37.12.28発行',list:'s662'}
]});
dataset.age.push({
  folderName:'00', start:1931, end:1931, scale:'1/25000', mapList: [
    {name:'楯岡',north:38.5029339805815,west:140.374479362188,south:38.4196139531308,east:140.499472389799,note:'昭和6年測図・昭和9.11.30発行',list:'63-10-1-1',war:true},
    {name:'天童温泉',north:38.4196103152931,west:140.37448328209,south:38.3362902615551,east:140.499476305971,note:'昭和6年測図・昭和9.12.28発行',list:'63-10-2-1'},
    {name:'谷地',north:38.5029303477769,west:140.24949028324,south:38.4196103152931,east:140.37448328209,note:'昭和6年測図・昭和9.11.30発行',list:'63-10-3-1'},
    {name:'天童',north:38.4196066890811,west:140.249494190586,south:38.336286630339,east:140.374487185776,note:'昭和6年測図・昭和9.10.30発行',list:'63-10-4-1'},
    {name:'山寺',north:38.336286630339,west:140.374487185776,south:38.2529665702848,east:140.499480205948,note:'昭和6年測図・昭和9.10.30発行',list:'63-11-1-1'},
    {name:'山形北部',north:38.3362830107274,west:140.249498081769,south:38.2529629456982,east:140.374491073319,note:'昭和6年測図・昭和9.11.30発行',list:'63-11-3-1',war:true},
    {name:'山形南部',north:38.2529593326949,west:140.249501956858,south:38.1696392513531,east:140.37449494479,note:'昭和6年測図・昭和9.12.28発行',list:'63-11-4-1',war:true},
    {name:'上ノ山',north:38.169635644966,west:140.249505815928,south:38.0863155372863,east:140.374498800262,note:'昭和6年測図・昭和9.11.30発行',list:'63-12-3-1'}
]});
dataset.age.push({
  folderName:'01', start:1970, end:1970, scale:'1/25000', mapList: [
    {name:'楯岡',north:38.5029338964915,west:140.371590714403,south:38.4196138689249,east:140.496583741349,note:'昭和45年改測・昭和47.2.28発行',list:'63-10-1-3'},
    {name:'天童',north:38.4196102313557,west:140.371594634016,south:38.3362901775025,east:140.496587657233,note:'昭和45年改測・昭和47.2.28発行',list:'63-10-2-3'},
    {name:'谷地',north:38.5029302639563,west:140.24660163583,south:38.4196102313557,east:140.371594634016,note:'昭和45年改測・昭和47.2.28発行',list:'63-10-3-3'},
    {name:'寒河江',north:38.4196066054126,west:140.246605542886,south:38.3362865465544,east:140.371598537413,note:'昭和45年改測・昭和60.12.28発行',list:'63-10-4-3'},
    {name:'山寺',north:38.3362865465544,west:140.371598537413,south:38.2529664863856,east:140.496591556923,note:'昭和45年改測・昭和48.3.30発行',list:'63-11-1-3'},
    {name:'山形北部',north:38.3362829272112,west:140.246609433779,south:38.2529628620665,east:140.371602424668,note:'昭和45年改測・昭和48.2.28発行',list:'63-11-3-3'},
    {name:'山形南部',north:38.2529592493311,west:140.246613308581,south:38.1696391678746,east:140.371606295853,note:'昭和45年改測・昭和48.3.30発行',list:'63-11-4-3'},
    {name:'上山',north:38.1696355617549,west:140.246617167364,south:38.0863154539611,east:140.37161015104,note:'昭和45年改測・昭和47.12.28発行',list:'63-12-3-3'}
]});
dataset.age.push({
  folderName:'02', start:1980, end:1989, scale:'1/25000', mapList: [
    {name:'楯岡',north:38.5029338964915,west:140.371590714403,south:38.4196138689249,east:140.496583741349,note:'平成1年修正・平成2.4.1発行',list:'63-10-1-6B'},
    {name:'天童',north:38.4196102313557,west:140.371594634016,south:38.3362901775025,east:140.496587657233,note:'平成1年修正・平成2.5.1発行',list:'63-10-2-6B'},
    {name:'谷地',north:38.5029302639563,west:140.24660163583,south:38.4196102313557,east:140.371594634016,note:'平成1年修正・平成2.4.1発行',list:'63-10-3-6B'},
    {name:'寒河江',north:38.4196066054126,west:140.246605542886,south:38.3362865465544,east:140.371598537413,note:'平成1年修正・平成2.7.1発行',list:'63-10-4-6'},
    {name:'山寺',north:38.3362865465544,west:140.371598537413,south:38.2529664863856,east:140.496591556923,note:'昭和59年修正・昭和61.9.30発行',list:'63-11-1-6'},
    {name:'山形北部',north:38.3362829272112,west:140.246609433779,south:38.2529628620665,east:140.371602424668,note:'昭和59年修正・昭和61.11.30発行',list:'63-11-3-6'},
    {name:'山形南部',north:38.2529592493311,west:140.246613308581,south:38.1696391678746,east:140.371606295853,note:'昭和59年修正・昭和62.1.30発行',list:'63-11-4-6'},
    {name:'上山',north:38.1696355617549,west:140.246617167364,south:38.0863154539611,east:140.37161015104,note:'昭和55年修正・昭和56.10.30発行',list:'63-12-3-4'}
]});
dataset.age.push({
  folderName:'03', start:1999, end:2001, scale:'1/25000', mapList: [
    {name:'楯岡',north:38.5029338964915,west:140.371590714403,south:38.4196138689249,east:140.496583741349,note:'平成11年部修・平成13.2.1発行',list:'63-10-1-7B'},
    {name:'天童',north:38.4196102313557,west:140.371594634016,south:38.3362901775025,east:140.496587657233,note:'平成11年部修・平成12.7.1発行',list:'63-10-2-7B'},
    {name:'谷地',north:38.5029302639563,west:140.24660163583,south:38.4196102313557,east:140.371594634016,note:'平成13年修正・平成14.4.1発行',list:'63-10-3-8'},
    {name:'寒河江',north:38.4196066054126,west:140.246605542886,south:38.3362865465544,east:140.371598537413,note:'平成11年修正・平成12.12.1発行',list:'63-10-4-9B'},
    {name:'山寺',north:38.3362865465544,west:140.371598537413,south:38.2529664863856,east:140.496591556923,note:'平成13年修正・平成14.9.1発行',list:'63-11-1-8'},
    {name:'山形北部',north:38.3362829272112,west:140.246609433779,south:38.2529628620665,east:140.371602424668,note:'平成11年修正・平成12.12.1発行',list:'63-11-3-9B'},
    {name:'山形南部',north:38.2529592493311,west:140.246613308581,south:38.1696391678746,east:140.371606295853,note:'平成11年修正・平成12.7.1発行',list:'63-11-4-8B'},
    {name:'上山',north:38.1696355617549,west:140.246617167364,south:38.0863154539611,east:140.37161015104,note:'平成13年修正・平成14.4.1発行',list:'63-12-3-6'}
]});
kjmapDataSet['syonai'] = new Object();
dataset = kjmapDataSet['syonai'];
dataset.age = new Array();
dataset.age.push({
   folderName:'00', start: 1913, end: 1913, scale:'1/50000', mapList: [
         {name:'鶴岡', north:38.8362103776208, west:139.749518539909, south:38.6695703894699, east:139.999504360985,note:'大正2年測図・大正5.5.30発行',list:'71-4-2'},
         {name:'酒田', north:39.0028575474702, west:139.749510647915, south:38.8362176134166, east:139.999496483046,note:'大正2年測図・大正5.3.30発行',list:'71-3-2'},
]});
dataset.age.push({
   folderName:'01', start: 1934, end: 1934, scale:'1/50000', mapList: [
         {name:'酒田', north:39.0028575474702, west:139.749510647915, south:38.8362176134166, east:139.999496483046,note:'昭和9年修正・昭和11.8.30発行',list:'71-3-4'},
         {name:'鶴岡', north:38.8362103776208, west:139.749518539909, south:38.6695703894699, east:139.999504360985,note:'昭和9年修正・昭和11.8.30発行',list:'71-4-4'},
]});
dataset.age.push({
   folderName:'02', start: 1974, end: 1974, scale:'1/25000', mapList: [
         {name:'藤島', north:38.8362139060076, west:139.871618858318, south:38.7528939224942, east:139.996611784408,note:'昭和49年測量・昭和50.11.30発行',list:'71-4-1-1'},
         {name:'羽黒山', north:38.7528903054656, west:139.871622792343, south:38.6695703058874, east:139.996615714906,note:'昭和49年測量・昭和50.11.30発行',list:'71-4-2-1'},
         {name:'湯野浜', north:38.8362102942828, west:139.746629895165, south:38.7528903054656, east:139.871622792343,note:'昭和49年測量・昭和50.11.30発行',list:'71-4-3-1'},
         {name:'鶴岡', north:38.7528867002167, west:139.746633816349, south:38.6695666953638, east:139.871626710071,note:'昭和49年測量・昭和50.11.30発行',list:'71-4-4-1'},
         {name:'羽後観音寺', north:39.0028610884869, west:139.871610941076, south:38.9195411370223, east:139.996603874284,note:'昭和49年測量・昭和50.11.30発行',list:'71-3-1-1'},
         {name:'余目', north:38.9195375070076, west:139.87161490792, south:38.8362175295332, east:139.996607837559,note:'昭和49年測量・昭和50.11.30発行',list:'71-3-2-1'},
         {name:'酒田北部', north:39.0028574638339, west:139.746622003768, south:38.9195375070076, east:139.87161490792,note:'昭和49年測量・昭和50.11.30発行',list:'71-3-3-1'},
         {name:'酒田南部', north:38.9195338888147, west:139.746625957663, south:38.8362139060076, east:139.871618858318,note:'昭和49年測量・昭和50.11.30発行',list:'71-3-4-1'},
]});
dataset.age.push({
   folderName:'03', start: 1987, end: 1987, scale:'1/25000', mapList: [
         {name:'羽黒山', north:38.7528903054656, west:139.871622792343, south:38.6695703058874, east:139.996615714906,note:'昭和62年修正・昭和63.4.30発行',list:'71-4-2-3C'},
         {name:'湯野浜', north:38.8362102942828, west:139.746629895165, south:38.7528903054656, east:139.871622792343,note:'昭和62年修正・昭和63.3.30発行',list:'71-4-3-3B'},
         {name:'鶴岡', north:38.7528867002167, west:139.746633816349, south:38.6695666953638, east:139.871626710071,note:'昭和62年修正・昭和63.4.30発行',list:'71-4-4-3D'},
         {name:'羽後観音寺', north:39.0028610884869, west:139.871610941076, south:38.9195411370223, east:139.996603874284,note:'昭和62年修正・昭和63.7.30発行',list:'71-3-1-3'},
         {name:'余目', north:38.9195375070076, west:139.87161490792, south:38.8362175295332, east:139.996607837559,note:'昭和62年修正・昭和63.6.30発行',list:'71-3-2-3C'},
         {name:'酒田北部', north:39.0028574638339, west:139.746622003768, south:38.9195375070076, east:139.87161490792,note:'昭和62年修正・昭和63.6.30発行',list:'71-3-3-3B'},
         {name:'酒田南部', north:38.9195338888147, west:139.746625957663, south:38.8362139060076, east:139.871618858318,note:'昭和62年修正・昭和63.6.30発行',list:'71-3-4-3C'},
         {name:'藤島', north:38.8362139060076, west:139.871618858318, south:38.7528939224942, east:139.996611784408,note:'昭和62年修正・昭和63.5.30発行',list:'71-4-1-3B'},
]});
dataset.age.push({
   folderName:'04', start: 1997, end: 2001, scale:'1/25000', mapList: [
         {name:'羽黒山', north:38.7528903054656, west:139.871622792343, south:38.6695703058874, east:139.996615714906,note:'平成11年部修・平成12.6.1発行',list:'71-4-2-5B'},
         {name:'湯野浜', north:38.8362092129048, west:139.709127509853, south:38.7528903054656, east:139.871622792343,note:'平成9年修正・平成10.5.1発行',list:'71-4-3-5'},
         {name:'鶴岡', north:38.7528867002167, west:139.746633816349, south:38.6695666953638, east:139.871626710071,note:'平成9年修正・平成10.5.1発行',list:'71-4-4-4C'},
         {name:'羽後観音寺', north:39.0028610884869, west:139.871610941076, south:38.9195411370223, east:139.996603874284,note:'平成13年部修・平成14.4.1発行',list:'71-3-1-5'},
         {name:'余目', north:38.9195375070076, west:139.87161490792, south:38.8362175295332, east:139.996607837559,note:'平成13年部修・平成14.12.1発行',list:'71-3-2-7'},
         {name:'酒田北部', north:39.0028574638339, west:139.746622003768, south:38.9195375070076, east:139.87161490792,note:'平成13年部修・平成14.8.1発行',list:'71-3-3-5'},
         {name:'酒田南部', north:38.9195338888147, west:139.746625957663, south:38.8362139060076, east:139.871618858318,note:'平成13年部修・平成14.7.1発行',list:'71-3-4-5'},
         {name:'藤島', north:38.8362139060076, west:139.871618858318, south:38.7528939224942, east:139.996611784408,note:'平成9年修正・平成10.12.1発行',list:'71-4-1-4B'},
]});

kjmapDataSet['fukushima'] = new Object();
dataset = kjmapDataSet['fukushima'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1908, end:1908, scale:'1/50000', mapList: [
    {name:'福嶋',north:37.8363407767176,west:140.249521093429,south:37.6697004384176,east:140.499507058332,note:'明治41年測図・明治44.11.30発行',list:'64-10-2'},
    {name:'二本松',north:37.6696932939325,west:140.24952863789,south:37.503052879589,east:140.499514588725,note:'明治41年測図・明治45.1.30発行',list:'64-11-2'},
    {name:'郡山',north:37.5030457618459,west:140.24953612023,south:37.3364052812498,east:140.499522057142,note:'明治41年測図・明治42.9.30発行',list:'64-12-1'},
    {name:'須賀川',north:37.3363981903107,west:140.249543540989,south:37.1697576532537,east:140.499529464123,note:'明治41年測図・明治42.9.30発行',list:'65-9-1'}
]});
dataset.age.push({
  folderName:'01', start:1931, end:1933, scale:'1/50000', mapList: [
    {name:'福嶋',north:37.8363407767176,west:140.249521093429,south:37.6697004384176,east:140.499507058332,note:'昭和6年要修・昭和8.7.30発行',list:'64-10-4'},
    {name:'二本松',north:37.6696932939325,west:140.24952863789,south:37.503052879589,east:140.499514588725,note:'昭和6年要修 ・昭和8.4.30発行',list:'64-11-4'},
    {name:'郡山',north:37.5030457618459,west:140.24953612023,south:37.3364052812498,east:140.499522057142,note:'昭和6年要修 ・昭和8.9.30発行',list:'64-12-4'},
    {name:'須賀川',north:37.3363981903107,west:140.249543540989,south:37.1697576532537,east:140.499529464123,note:'昭和8年要修 ・昭和11.5.30発行',list:'65-9-3'}
]});
dataset.age.push({
  folderName:'02', start:1972, end:1974, scale:'1/25000', mapList: [
    {name:'福島北部',north:37.8363442736974,west:140.371621621314,south:37.7530241150868,east:140.496614619001,note:'昭和47年測量・昭和49.2.28発行',list:'64-10-1-1B'},
    {name:'福島南部',north:37.7530205307072,west:140.371625413211,south:37.6697003555977,east:140.49661840733,note:'昭和47年測量・昭和49.2.28発行',list:'64-10-2-1B'},
    {name:'板谷',north:37.836340694119,west:140.246632443729,south:37.7530205307072,east:140.371625413211,note:'昭和48年測量・昭和49.8.30発行',list:'64-10-3-1'},
    {name:'土湯温泉',north:37.7530169577836,west:140.246636223478,south:37.669696777902,east:140.37162918946,note:'昭和48年測量・昭和49.9.30発行',list:'64-10-4-2B'},
    {name:'二本松',north:37.669696777902,west:140.37162918946,south:37.5863765762686,east:140.49662218003,note:'昭和47年測量・昭和48.12.28発行',list:'64-11-1-1'},
    {name:'岩代本宮',north:37.5863730052648,west:140.37163295013,south:37.5030527970792,east:140.496625937168,note:'昭和47年測量・昭和48.12.28発行',list:'64-11-2-1'},
    {name:'安達太良山',north:37.6696932116411,west:140.24663998763,south:37.5863730052648,east:140.37163295013,note:'昭和47年測量・昭和48.12.28発行',list:'64-11-3-1'},
    {name:'玉井',north:37.5863694456743,west:140.246643736252,south:37.5030492327749,east:140.371636695289,note:'昭和47年測量・昭和48.12.28発行',list:'64-11-4-1B'},
    {name:'三春',north:37.5030492327749,west:140.371636695289,south:37.4197290080122,east:140.496629678814,note:'昭和47年測量・昭和48.10.30発行',list:'64-12-1-1'},
    {name:'郡山',north:37.4197254504153,west:140.371640425004,south:37.3364051990507,east:140.496633405036,note:'昭和47年測量・昭和48.10.30発行',list:'64-12-2-1'},
    {name:'磐梯熱海',north:37.5030456798626,west:140.246647469413,south:37.4197254504153,east:140.371640425004,note:'昭和47年測量・昭和49.2.28発行',list:'64-12-3-1B'},
    {name:'郡山西部',north:37.4197219041888,west:140.24665118718,south:37.3364016481689,east:140.371644139344,note:'昭和47年測量・昭和48.10.30発行',list:'64-12-4-1'},
    {name:'須賀川東部',north:37.3364016481689,west:140.371644139344,south:37.2530813901742,east:140.496637115899,note:'昭和49年測量・昭和50.8.30発行',list:'65-9-1-1B'},
    {name:'母畑',north:37.2530778460153,west:140.371647838375,south:37.169757571366,east:140.496640811471,note:'昭和49年測量・昭和50.9.30発行',list:'65-9-2-1B'},
    {name:'須賀川西部',north:37.3363981086361,west:140.246654889621,south:37.2530778460153,east:140.371647838375,note:'昭和49年測量・昭和50.8.30発行',list:'65-9-3-1'},
    {name:'矢吹',north:37.2530743131839,west:140.246658576802,south:37.1697540339376,east:140.371651522163,note:'昭和49年測量・昭和50.9.30発行',list:'65-9-4-1'}
]});
dataset.age.push({
  folderName:'03', start:1983, end:1983, scale:'1/25000', mapList: [
    {name:'福島北部',north:37.8363442736974,west:140.371621621314,south:37.7530241150868,east:140.496614619001,note:'昭和58年修正・昭和59.12.28発行',list:'64-10-1-3'},
    {name:'福島南部',north:37.7530205307072,west:140.371625413211,south:37.6697003555977,east:140.49661840733,note:'昭和58年修正・昭和60.1.30発行',list:'64-10-2-3'},
    {name:'板谷',north:37.836340694119,west:140.246632443729,south:37.7530205307072,east:140.371625413211,note:'昭和58年修正・昭和59.11.30発行',list:'64-10-3-3'},
    {name:'土湯温泉',north:37.7530169577836,west:140.246636223478,south:37.669696777902,east:140.37162918946,note:'昭和58年修正・昭和59.11.30発行',list:'64-10-4-4'},
    {name:'二本松',north:37.669696777902,west:140.37162918946,south:37.5863765762686,east:140.49662218003,note:'昭和58年修正・昭和60.1.30発行',list:'64-11-1-3'},
    {name:'岩代本宮',north:37.5863730052648,west:140.37163295013,south:37.5030527970792,east:140.496625937168,note:'昭和58年修正・昭和60.3.30発行',list:'64-11-2-3'},
    {name:'安達太良山',north:37.6696932116411,west:140.24663998763,south:37.5863730052648,east:140.37163295013,note:'昭和58年修正・昭和59.12.28発行',list:'64-11-3-3'},
    {name:'玉井',north:37.5863694456743,west:140.246643736252,south:37.5030492327749,east:140.371636695289,note:'昭和58年修正・昭和59.11.30発行',list:'64-11-4-3'},
    {name:'三春',north:37.5030492327749,west:140.371636695289,south:37.4197290080122,east:140.496629678814,note:'昭和57年修正・昭和59.2.28発行',list:'64-12-1-3'},
    {name:'郡山',north:37.4197254504153,west:140.371640425004,south:37.3364051990507,east:140.496633405036,note:'昭和57年修正・昭和59.3.30発行',list:'64-12-2-3'},
    {name:'磐梯熱海',north:37.5030456798626,west:140.246647469413,south:37.4197254504153,east:140.371640425004,note:'昭和57年修正・昭和58.11.30発行',list:'64-12-3-3'},
    {name:'郡山西部',north:37.4197219041888,west:140.24665118718,south:37.3364016481689,east:140.371644139344,note:'昭和57年修正・昭和59.3.30発行',list:'64-12-4-3'},
    {name:'須賀川東部',north:37.3364016481689,west:140.371644139344,south:37.2530813901742,east:140.496637115899,note:'昭和57年修正・昭和59.1.30発行',list:'65-9-1-2'},
    {name:'母畑',north:37.2530778460153,west:140.371647838375,south:37.169757571366,east:140.496640811471,note:'昭和57年修正・昭和58.10.30発行',list:'65-9-2-2'},
    {name:'須賀川西部',north:37.3363981086361,west:140.246654889621,south:37.2530778460153,east:140.371647838375,note:'昭和57年修正・昭和59.3.30発行',list:'65-9-3-2'},
    {name:'矢吹',north:37.2530743131839,west:140.246658576802,south:37.1697540339376,east:140.371651522163,note:'昭和57年修正・昭和58.9.30発行',list:'65-9-4-2'}
]});
dataset.age.push({
  folderName:'04', start:1996, end:2000, scale:'1/25000', mapList: [
    {name:'福島北部',north:37.8363442736974,west:140.371621621314,south:37.7530241150868,east:140.496614619001,note:'平成10年部修・平成11.2.1発行',list:'64-10-1-7B'},
    {name:'福島南部',north:37.7530205307072,west:140.371625413211,south:37.6697003555977,east:140.49661840733,note:'平成10年部修・平成11.3.1発行',list:'64-10-2-7B'},
    {name:'板谷',north:37.836340694119,west:140.246632443729,south:37.7530205307072,east:140.371625413211,note:'平成8年修正・平成9.9.1発行',list:'64-10-3-6B'},
    {name:'土湯温泉',north:37.7530169577836,west:140.246636223478,south:37.669696777902,east:140.37162918946,note:'平成12年修正・平成14.2.1発行',list:'64-10-4-7'},
    {name:'二本松',north:37.669696777902,west:140.37162918946,south:37.5863765762686,east:140.49662218003,note:'平成8年修正・平成9.12.1発行',list:'64-11-1-6B'},
    {name:'岩代本宮',north:37.5863730052648,west:140.37163295013,south:37.5030527970792,east:140.496625937168,note:'平成11年部修・平成12.10.1発行',list:'64-11-2-6B'},
    {name:'安達太良山',north:37.6696932116411,west:140.24663998763,south:37.5863730052648,east:140.37163295013,note:'平成12年修正・平成13.12.1発行',list:'64-11-3-6'},
    {name:'玉井',north:37.5863694456743,west:140.246643736252,south:37.5030492327749,east:140.371636695289,note:'平成8年修正・平成9.8.1発行',list:'64-11-4-6B'},
    {name:'三春',north:37.5030492327749,west:140.371636695289,south:37.4197290080122,east:140.496629678814,note:'平成10年修正・平成11.8.1発行',list:'64-12-1-7B'},
    {name:'郡山',north:37.4197254504153,west:140.371640425004,south:37.3364051990507,east:140.496633405036,note:'平成10年修正・平成11.6.1発行',list:'64-12-2-6C'},
    {name:'磐梯熱海',north:37.5030456798626,west:140.246647469413,south:37.4197254504153,east:140.371640425004,note:'平成10年修正・平成11.12.1発行',list:'64-12-3-9B'},
    {name:'郡山西部',north:37.4197219041888,west:140.24665118718,south:37.3364016481689,east:140.371644139344,note:'平成10年修正・平成11.4.1発行',list:'64-12-4-6B'},
    {name:'須賀川東部',north:37.3364016481689,west:140.371644139344,south:37.2530813901742,east:140.496637115899,note:'平成10年修正・平成11.4.1発行',list:'65-9-1-4'},
    {name:'母畑',north:37.2530778460153,west:140.371647838375,south:37.169757571366,east:140.496640811471,note:'平成12年修正・平成14.3.1発行',list:'65-9-2-4'},
    {name:'須賀川西部',north:37.3363981086361,west:140.246654889621,south:37.2530778460153,east:140.371647838375,note:'平成10年修正・平成11.8.1発行',list:'65-9-3-4B'},
    {name:'矢吹',north:37.2530743131839,west:140.246658576802,south:37.1697540339376,east:140.371651522163,note:'平成12年修正・平成14.2.1発行',list:'65-9-4-5'}
]});
kjmapDataSet['aizu'] = new Object();
dataset = kjmapDataSet['aizu'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1908, end:1910, scale:'1/25000', mapList: [
    {name:'猪苗代',north:37.5863624424091,west:139.99955400616,south:37.5030422200785,east:140.124546909939,note:'明治41年測図・大正6.4.30発行',list:'64-15-4-1'},
    {name:'喜多方東部',north:37.6696826631314,west:139.874561127021,south:37.5863624424091,east:139.99955400616,note:'明治43年測図・大正6.4.30発行',list:'73-3-1-1'},
    {name:'廣田',north:37.5863589168948,west:139.874564839674,south:37.5030386897363,east:139.999557715551,note:'明治43年測図・大正6.5.30発行',list:'73-3-2-1'},
    {name:'喜多方西部',north:37.6696791425123,west:139.749571988469,south:37.5863589168948,east:139.874564839674,note:'明治43年測図・大正6.5.30発行',list:'73-3-3-1'},
    {name:'坂下',north:37.5863554028607,west:139.749575689004,south:37.5030351708361,east:139.874568537013,note:'明治43年測図・大正6.4.30発行',list:'73-3-4-1'},
    {name:'若松',north:37.5030351708361,west:139.874568537013,south:37.4197149272167,east:139.999561409645,note:'明治43年測量・大正6.4.30発行',list:'73-4-1-1'},
    {name:'髙田',north:37.5030316633948,west:139.749579374276,south:37.4197114149385,east:139.874572219107,note:'明治43年測量・大正6.3.30発行',list:'73-4-3-1'}
]});
dataset.age.push({
  folderName:'01', start:1931, end:1931, scale:'1/25000', mapList: [
    {name:'猪苗代',north:37.5863624424091,west:139.99955400616,south:37.5030422200785,east:140.124546909939,note:'昭和6年要修・昭和7.12.28発行',list:'64-15-4-2'},
    {name:'喜多方東部',north:37.6696826631314,west:139.874561127021,south:37.5863624424091,east:139.99955400616,note:'昭和6年修正・昭和10.4.30発行',list:'73-3-1-2'},
    {name:'廣田',north:37.5863589168948,west:139.874564839674,south:37.5030386897363,east:139.999557715551,note:'昭和6年修正・昭和9.12.28発行',list:'73-3-2-3'},
    {name:'喜多方西部',north:37.6696791425123,west:139.749571988469,south:37.5863589168948,east:139.874564839674,note:'昭和6年修正・昭和10.1.30発行',list:'73-3-3-2'},
    {name:'坂下',north:37.5863554028607,west:139.749575689004,south:37.5030351708361,east:139.874568537013,note:'昭和6年修正・昭和10.1.30発行',list:'73-3-4-3'},
    {name:'若松',north:37.5030351708361,west:139.874568537013,south:37.4197149272167,east:139.999561409645,note:'昭和6年修正・昭和9.8.30発行',list:'73-4-1-3'},
    {name:'髙田',north:37.5030316633948,west:139.749579374276,south:37.4197114149385,east:139.874572219107,note:'昭和6年修正・昭和9.10.30発行',list:'73-4-3-3'}
]});
dataset.age.push({
  folderName:'02', start:1972, end:1975, scale:'1/25000', mapList: [
    {name:'猪苗代',north:37.5863623608008,west:139.996665356357,south:37.503042138359,east:140.12165825949,note:'昭和47年改測・昭和49.3.30発行',list:'64-15-4-5B'},
    {name:'喜多方東部',north:37.6696825816358,west:139.871672477863,south:37.5863623608008,east:139.996665356357,note:'昭和50年改測・昭和51.12.28発行',list:'73-3-1-4'},
    {name:'会津広田',north:37.5863588355515,west:139.871676190236,south:37.503038608281,east:139.996669065469,note:'昭和50年改測・昭和51.12.28発行',list:'73-3-2-5'},
    {name:'喜多方西部',north:37.6696790612827,west:139.746683339677,south:37.5863588355515,east:139.871676190236,note:'昭和50年改測・昭和51.12.28発行',list:'73-3-3-4B'},
    {name:'坂下',north:37.586355321783,west:139.746687039932,south:37.5030350896455,east:139.871679887297,note:'昭和50年改測・昭和51.12.28発行',list:'73-3-4-5B'},
    {name:'若松',north:37.5030350896455,west:139.871679887297,south:37.4197148459147,east:139.996672759286,note:'昭和49年改測・昭和51.2.28発行',list:'73-4-1-5C'},
    {name:'会津高田',north:37.5030315824692,west:139.746690724924,south:37.4197113339007,east:139.871683569113,note:'昭和49年改測・昭和51.2.28発行',list:'73-4-3-5'}
]});
dataset.age.push({
  folderName:'03', start:1988, end:1991, scale:'1/25000', mapList: [
    {name:'猪苗代',north:37.5863623608008,west:139.996665356357,south:37.503042138359,east:140.12165825949,note:'平成2年修正・平成3.8.1発行',list:'64-15-4-6'},
    {name:'喜多方東部',north:37.6696825816358,west:139.871672477863,south:37.5863623608008,east:139.996665356357,note:'平成3年修正・平成4.9.1発行',list:'73-3-1-6'},
    {name:'会津広田',north:37.5863588355515,west:139.871676190236,south:37.503038608281,east:139.996669065469,note:'平成3年修正・平成4.9.1発行',list:'73-3-2-7'},
    {name:'喜多方西部',north:37.6696790612827,west:139.746683339677,south:37.5863588355515,east:139.871676190236,note:'平成3年修正・平成4.9.1発行',list:'73-3-3-6'},
    {name:'坂下',north:37.586355321783,west:139.746687039932,south:37.5030350896455,east:139.871679887297,note:'平成3年修正・平成4.10.1発行',list:'73-3-4-7'},
    {name:'若松',north:37.5030350896455,west:139.871679887297,south:37.4197148459147,east:139.996672759286,note:'昭和63年修正・平成2.2.1発行',list:'73-4-1-7'},
    {name:'会津高田',north:37.5030315824692,west:139.746690724924,south:37.4197113339007,east:139.871683569113,note:'昭和63年修正・平成2.2.1発行',list:'73-4-3-7B'}
]});
dataset.age.push({
  folderName:'04', start:1997, end:2000, scale:'1/25000', mapList: [
    {name:'猪苗代',north:37.5863623608008,west:139.996665356357,south:37.503042138359,east:140.12165825949,note:'平成12年修正・平成13.9.1発行',list:'64-15-4-10B'},
    {name:'喜多方東部',north:37.6696825816358,west:139.871672477863,south:37.5863623608008,east:139.996665356357,note:'平成9年部修・平成9.9.1発行',list:'73-3-1-7C'},
    {name:'会津広田',north:37.5863588355515,west:139.871676190236,south:37.503038608281,east:139.996669065469,note:'平成12年修正・平成14.1.1発行',list:'73-3-2-8'},
    {name:'喜多方西部',north:37.6696790612827,west:139.746683339677,south:37.5863588355515,east:139.871676190236,note:'平成9年部修・平成9.8.1発行',list:'73-3-3-7B'},
    {name:'坂下',north:37.586355321783,west:139.746687039932,south:37.5030350896455,east:139.871679887297,note:'平成12年修正・平成14.1.1発行',list:'73-3-4-9'},
    {name:'若松',north:37.5030350896455,west:139.871679887297,south:37.4197148459147,east:139.996672759286,note:'平成9年部修・平成10.4.1発行',list:'73-4-1-10B'},
    {name:'会津高田',north:37.5030315824692,west:139.746690724924,south:37.4197113339007,east:139.871683569113,note:'平成9年部修・平成10.1.1発行',list:'73-4-3-8B'}
]});
kjmapDataSet['niigata'] = new Object();
dataset = kjmapDataSet['niigata'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1910, end:1911, scale:'1/25000', mapList: [
    {name:'松ヶ崎濱',north:38.0029564133493,west:139.124611821251,south:37.9196362374598,east:139.249604544879,note:'明治44年測図・大正3.4.30発行',list:'73-13-1-2'},
    {name:'水原',north:37.9196327552143,west:139.124615521646,south:37.8363125531703,east:139.249608242352,note:'明治44年測図・大正3.4.30発行',list:'73-13-2-2'},
    {name:'新潟北部',north:38.0029529363451,west:138.999622826021,south:37.9196327552143,east:139.124615521646,note:'明治44年測図・大正3.1.30発行',list:'73-13-3-2'},
    {name:'新潟南部',north:37.9196292846352,west:138.999626513989,south:37.8363090773791,east:139.124619206762,note:'明治44年測図・大正3.4.30発行',list:'73-13-4-2'},
    {name:'新津',north:37.8363090773791,west:139.124619206762,south:37.7529888691522,east:139.249611924563,note:'明治44年測図・大正3.5.30発行',list:'73-14-1-2'},
    {name:'村松',north:37.7529853998229,west:139.124622876665,south:37.6696651753882,east:139.249615591578,note:'明治44年測図・大正3.6.30発行',list:'73-14-2-2'},
    {name:'小須戸',north:37.8363056132327,west:138.999630186729,south:37.7529853998229,east:139.124622876665,note:'明治44年測図・大正3.6.30発行',list:'73-14-3-2'},
    {name:'新發田',north:38.0029599020416,west:139.249600832075,south:37.9196397313552,east:139.374593583739,note:'明治44年測図・大正3.5.30発行',list:'73-9-3-2'},
    {name:'天王',north:37.9196362374598,west:139.249604544879,south:37.8363160405898,east:139.374597293554,note:'明治44年測図・大正3.5.30発行',list:'73-9-4-2'},
    {name:'加茂',north:37.66965826127,west:138.999637486794,south:37.5863380054782,east:139.124630171106,note:'明治44年測図・大正3.6.30発行',list:'73-15-3-2'},
    {name:'三條',north:37.6696548216295,west:138.874648457636,south:37.5863345606751,east:138.999641114253,note:'明治44年測図・大正3.7.30発行',list:'81-3-1-2'},
    {name:'見附',north:37.5863311274682,west:138.874652072854,south:37.5030108603114,east:138.999644726749,note:'明治44年測図・大正3.6.30発行',list:'81-3-2-2'},
    {name:'栃尾',north:37.5030074335456,west:138.874655673161,south:37.4196871501616,east:138.99964832435,note:'明治44年測図・大正3.10.30発行',list:'81-4-1-2'},
    {name:'長岡',north:37.5030040183705,west:138.749666634958,south:37.4196837298443,east:138.874659258622,note:'明治44年測図・大正3.6.30発行',list:'81-4-3-2'},
    {name:'片貝',north:37.4196803210959,west:138.749670208262,south:37.3363600063473,east:138.874662829302,note:'明治44年測図・大正3.9.30発行',list:'81-4-4-2'},
    {name:'小千谷',north:37.3363566040331,west:138.749673766836,south:37.2530362830339,east:138.874666385265,note:'明治44年測図・大正3.9.30発行',list:'82-1-3-2'},
      {name:'塚野山', north:37.4196769239327, west:138.624681173218, south:37.3363566040331, east:138.749673766836,note:'明治44年測図・明治45.4.30発行',list:'81-8-2-1'},
      {name:'蓬平', north:37.4196837298443, west:138.874659258622, south:37.3363634202086, east:138.999651907119,note:'明治44年測図・大正3.7.30発行',list:'81-4-2-2'},
      {name:'柿﨑', north:37.3363464665344, west:138.374706671022, south:37.2530261300562, east:138.499699207491,note:'明治44年測図・大正3.12.28発行',list:'82-9-1-1'},
      {name:'原野町', north:37.2530227688559, west:138.374710178659, south:37.1697024161905, east:138.499702712731,note:'明治43年測図・大正3.12.28発行',list:'82-9-2-1'},
      {name:'柏﨑', north:37.4196735383707, west:138.499692153438, south:37.3363532132821, east:138.624684719669,note:'明治44年測図・大正3.9.30発行',list:'81-8-4-2'},
      {name:'青海川', north:37.4196701644261, west:138.374703148869, south:37.3363498341105, east:138.499695687748,note:'明治43年測図・大正3.9.30発行',list:'81-12-2-1'},
      {name:'矢代田', north:37.7529819421167, west:138.999633844309, south:37.6696617125284, east:139.124626531424,note:'明治44年測図・大正3.4.30発行',list:'73-14-4-2'},
      {name:'潟町', north:37.2530194192451, west:138.249721164952, south:37.1696990613733, east:138.374713671841,note:'明治43年測図・大正3.12.28発行',list:'82-9-4-1'},
      {name:'高田東部', north:37.1696957181237, west:138.249724646061, south:37.0863753340697, east:138.374717150634,note:'明治44年測図・大正3.12.28発行',list:'82-10-3-1'},
      {name:'新井', north:37.0863719971885, west:138.249728112829, south:37.0030516069246, east:138.374720615096,note:'明治43年測図・大正3.12.28発行',list:'82-10-4-1'},
      {name:'直江津', north:37.2530160812397, west:138.124732166318, south:37.1696957181237, east:138.249724646061,note:'明治43年測図・大正3.10.30発行',list:'82-13-2-1'},
      {name:'高田西部', north:37.1696923864574, west:138.124735635337, south:37.0863719971885, east:138.249728112829,note:'明治43年測図・大正3.12.28発行',list:'82-14-1-1'},
      {name:'長森', north:37.0863686718686, west:138.124739090065, south:37.003048276419, east:138.249731565318,note:'明治43年測図・大正3.9.30発行',list:'82-14-2-1'},
      {name:'直海濱', north:37.3363431105698, west:138.249717669439, south:37.2530227688559, east:138.374710178659,note:'明治43年測量・大正3.7.30発行',list:'82-9-3-1'}
]});
dataset.age.push({
  folderName:'01', start:1930, end:1931, scale:'1/25000', mapList: [
    {name:'松ヶ崎濱',north:38.0029564133493,west:139.124611821251,south:37.9196362374598,east:139.249604544879,note:'昭和6年修正・昭和9.4.30発行',list:'73-13-1-3'},
    {name:'水原',north:37.9196327552143,west:139.124615521646,south:37.8363125531703,east:139.249608242352,note:'昭和6年修正・昭和9.5.30発行',list:'73-13-2-4'},
    {name:'新潟北部',north:38.0029529363451,west:138.999622826021,south:37.9196327552143,east:139.124615521646,note:'昭和6年修正・昭和10.1.30発行',list:'73-13-3-4'},
    {name:'新潟南部',north:37.9196292846352,west:138.999626513989,south:37.8363090773791,east:139.124619206762,note:'昭和6年修正・昭和10.5.30発行',list:'73-13-4-5'},
    {name:'新津',north:37.8363090773791,west:139.124619206762,south:37.7529888691522,east:139.249611924563,note:'昭和6年修正・昭和9.7.30発行',list:'73-14-1-4'},
    {name:'村松',north:37.7529853998229,west:139.124622876665,south:37.6696651753882,east:139.249615591578,note:'昭和6年修正・昭和9.4.30発行',list:'73-14-2-4'},
    {name:'小須戸',north:37.8363056132327,west:138.999630186729,south:37.7529853998229,east:139.124622876665,note:'昭和6年修正・昭和9.4.30発行',list:'73-14-3-3'},
    {name:'新發田',north:38.0029599020416,west:139.249600832075,south:37.9196397313552,east:139.374593583739,note:'昭和6年修正・昭和9.5.30発行',list:'73-9-3-5'},
    {name:'天王',north:37.9196362374598,west:139.249604544879,south:37.8363160405898,east:139.374597293554,note:'昭和6年修正・昭和8.10.30発行',list:'73-9-4-5'},
    {name:'加茂',north:37.66965826127,west:138.999637486794,south:37.5863380054782,east:139.124630171106,note:'昭和6年要修・昭和8.1.30発行',list:'73-15-3-3'},
    {name:'三條',north:37.6696548216295,west:138.874648457636,south:37.5863345606751,east:138.999641114253,note:'昭和6年修正・昭和9.10.30発行',list:'81-3-1-5'},
    {name:'見附',north:37.5863311274682,west:138.874652072854,south:37.5030108603114,east:138.999644726749,note:'昭和6年修正・昭和9.8.30発行',list:'81-3-2-4'},
    {name:'栃尾',north:37.5030074335456,west:138.874655673161,south:37.4196871501616,east:138.99964832435,note:'昭和6年修正・昭和9.8.30発行',list:'81-4-1-4'},
    {name:'長岡',north:37.5030040183705,west:138.749666634958,south:37.4196837298443,east:138.874659258622,note:'昭和6年修正・昭和9.7.30発行',list:'81-4-3-4'},
    {name:'片貝',north:37.4196803210959,west:138.749670208262,south:37.3363600063473,east:138.874662829302,note:'昭和6年修正・昭和9.8.30発行',list:'81-4-4-4'},
    {name:'小千谷',north:37.3363566040331,west:138.749673766836,south:37.2530362830339,east:138.874666385265,note:'昭和6年修正・昭和9.9.30発行',list:'82-1-3-5'},
      {name:'蓬平', north:37.4196837298443, west:138.874659258622, south:37.3363634202086, east:138.999651907119,note:'昭和6年修正・昭和10.5.30発行',list:'81-4-2-3'},
      {name:'青海川', north:37.4196701644261, west:138.374703148869, south:37.3363498341105, east:138.499695687748,note:'昭和5年修正・昭和7.11.30発行',list:'81-12-2-2'},
      {name:'柏﨑', north:37.4196735383707, west:138.499692153438, south:37.3363532132821, east:138.624684719669,note:'昭和6年修正・昭和9.8.30発行',list:'81-8-4-3',war:true},
      {name:'柿﨑', north:37.3363464665344, west:138.374706671022, south:37.2530261300562, east:138.499699207491,note:'昭和5年修正・昭和10.5.30発行',list:'82-9-1-2'},
      {name:'原之町', north:37.2530227688559, west:138.374710178659, south:37.1697024161905, east:138.499702712731,note:'昭和5年修正・昭和8.11.30発行',list:'82-9-2-2'},
      {name:'矢代田', north:37.7529819421167, west:138.999633844309, south:37.6696617125284, east:139.124626531424,note:'昭和6年修正・昭和8.11.30発行',list:'73-14-4-3'},
      {name:'塚野山', north:37.4196769239327, west:138.624681173218, south:37.3363566040331, east:138.749673766836,note:'昭和6年修正・昭和23.2.28発行',list:'81-8-2-2'},
      {name:'潟町', north:37.2530194192451, west:138.249721164952, south:37.1696990613733, east:138.374713671841,note:'昭和5年修正・昭和8.1.30発行',list:'82-9-4-3',war:true},
      {name:'高田東部', north:37.1696957181237, west:138.249724646061, south:37.0863753340697, east:138.374717150634,note:'昭和5年修正・昭和8.1.30発行',list:'82-10-3-2',war:true},
      {name:'新井', north:37.0863719971885, west:138.249728112829, south:37.0030516069246, east:138.374720615096,note:'昭和5年修正・昭和8.6.30発行',list:'82-10-4-2'},
      {name:'直江津', north:37.2530160812397, west:138.124732166318, south:37.1696957181237, east:138.249724646061,note:'昭和5年修正・昭和8.2.28発行',list:'82-13-2-2'},
      {name:'高田西部', north:37.1696923864574, west:138.124735635337, south:37.0863719971885, east:138.249728112829,note:'昭和5年修正・昭和9.2.28発行',list:'82-14-1-2',war:true},
      {name:'長森', north:37.0863686718686, west:138.124739090065, south:37.003048276419, east:138.249731565318,note:'昭和5年修正・昭和9.6.30発行',list:'82-14-2-2'},
      {name:'直海濱', north:37.3363431105698, west:138.249717669439, south:37.2530227688559, east:138.374710178659,note:'昭和5年修正・昭和7.12.28発行',list:'82-9-3-2'}
]});
dataset.age.push({
  folderName:'02', start:1966, end:1968, scale:'1/25000', mapList: [
    {name:'松浜',north:38.0029563328595,west:139.121723175409,south:37.9196361568494,east:139.246715898389,note:'昭和42年改測・昭和44.3.30発行',list:'73-13-1-6'},
    {name:'水原',north:37.9196326748733,west:139.121726875516,south:37.8363124727093,east:139.246719595577,note:'昭和42年改測・昭和43.12.28発行',list:'73-13-2-7'},
    {name:'新潟北部',north:38.0029528561256,west:138.996734180539,south:37.9196326748733,east:139.121726875516,note:'昭和43年改測・昭和44.8.30発行',list:'73-13-3-6'},
    {name:'新潟南部',north:37.919629204564,west:138.996737868219,south:37.836308997187,east:139.121730560346,note:'昭和43年改測・昭和45.3.30発行',list:'73-13-4-7'},
    {name:'新津',north:37.836308997187,west:139.121730560346,south:37.7529887888408,east:139.246723277503,note:'昭和43年改測・昭和45.3.30発行',list:'73-14-1-6'},
    {name:'村松',north:37.7529853197799,west:139.121734229965,south:37.6696650952265,east:139.246726944235,note:'昭和43年改測・昭和45.3.30発行',list:'73-14-2-6'},
    {name:'白根',north:37.8363055333099,west:138.996741540673,south:37.7529853197799,east:139.121734229965,note:'昭和43年改測・昭和44.9.30発行',list:'73-14-3-6'},
    {name:'新発田',north:38.0029598212819,west:139.246712185872,south:37.9196396504757,east:139.371704936888,note:'昭和43年改測・昭和46.2.28発行',list:'73-9-3-7'},
    {name:'天王',north:37.9196361568494,west:139.246715898389,south:37.8363159598602,east:139.371708646417,note:'昭和43年改測・昭和46.2.28発行',list:'73-9-4-8'},
    {name:'加茂',north:37.6696581816446,west:138.996748840169,south:37.5863379257339,east:139.12174152384,note:'昭和43年改測・昭和45.3.30発行',list:'73-15-3-5'},
    {name:'三条',north:37.6696547422728,west:138.871759811368,south:37.5863344811986,east:138.996752467345,note:'昭和43年改測・昭和45.3.30発行',list:'81-3-1-8'},
    {name:'見附',north:37.5863310482599,west:138.871763426303,south:37.503010780984,east:138.99675607956,note:'昭和43年改測・昭和45.3.30発行',list:'81-3-2-6'},
    {name:'栃尾',north:37.5030073544859,west:138.871767026328,south:37.4196870709835,east:138.99675967688,note:'昭和41年改測・昭和43.7.30発行',list:'81-4-1-6'},
    {name:'長岡',north:37.5030039395788,west:138.746777988479,south:37.4196836509334,east:138.871770611508,note:'昭和41年改測・昭和43.8.30発行',list:'81-4-3-7'},
    {name:'片貝',north:37.4196802424526,west:138.746781561503,south:37.3363599275853,east:138.871774181909,note:'昭和41年改測・昭和44.3.30発行',list:'81-4-4-7'},
    {name:'小千谷',north:37.3363565255382,west:138.746785119797,south:37.2530362044211,east:138.871777737593,note:'昭和41年改測・昭和44.3.30発行',list:'82-1-3-8'},
      {name:'塚野山', north:37.4196768455573, west:138.621792526812, south:37.3363565255382, east:138.746785119797,note:'昭和41年改測・昭和43.8.30発行',list:'81-8-2-3'},
      {name:'半蔵金', north:37.4196836509334, west:138.871770611508, south:37.3363633411799, east:138.99676325937,note:'昭和41年改測・昭和44.3.30発行',list:'81-4-2-5'},
      {name:'青海川', north:37.4196700865877, west:138.371814503166, south:37.3363497561509, east:138.496807041414,note:'昭和41年改測・昭和44.3.30発行',list:'81-12-2-4'},
      {name:'柏崎', north:37.4196734602636, west:138.496803507384, south:37.3363531350546, east:138.621796072982,note:'昭和41年改測・昭和44.3.30発行',list:'81-8-4-5'},
      {name:'柿崎', north:37.3363463888429, west:138.371818025038, south:37.2530260522441, east:138.496810560877,note:'昭和41年改測・昭和44.3.30発行',list:'82-9-1-4'},
      {name:'矢代田', north:37.7529818623426, west:138.996745197967, south:37.6696616326346, east:139.121737884441,note:'昭和43年改測・昭和45.3.30発行',list:'73-14-4-6'},
      {name:'内野', north:37.9196254658236, west:138.861607470313, south:37.8363055333099, east:138.996741540673,note:'昭和43年測量・昭和45.10.30発行',list:'81-1-2-1'},
      {name:'新井', north:37.0863719202058, west:138.246839466357, south:37.0030515298224, east:138.371831967999,note:'昭和41年改測・昭和44.3.30発行',list:'82-10-4-4'},
      {name:'高田東部', north:37.169695640994, west:138.246835999866, south:37.08637525682, east:138.371828503813,note:'昭和41年改測・昭和44.3.30発行',list:'82-10-3-4'},
      {name:'潟町', north:37.2530193419687, west:138.246832519036, south:37.1696989839762, east:138.371825025299,note:'昭和41年改測・昭和44.3.30発行',list:'82-9-4-5'},
      {name:'三ツ屋浜', north:37.3363430331468, west:138.246829023804, south:37.2530226913115, east:138.371821532395,note:'昭和41年改測・昭和44.3.30発行',list:'82-9-3-4'},
      {name:'原之町', north:37.2530226913115, west:138.371821532395, south:37.1697023385262, east:138.496814065838,note:'昭和41年改測・昭和44.3.30発行',list:'82-9-2-4'},
      {name:'重倉山', north:37.0863685951532, west:138.121850443939, south:37.0030481995834, east:138.246842918568,note:'昭和41年改測・昭和44.3.30発行',list:'82-14-2-4'},
      {name:'高田西部', north:37.1696923095956, west:138.12184698949, south:37.0863719202058, east:138.246839466357,note:'昭和41年改測・昭和44.3.30発行',list:'82-14-1-4'},
      {name:'直江津', north:37.2530160042317, west:138.12184352075, south:37.169695640994, east:138.246835999866,note:'昭和41年改測・昭和44.3.30発行',list:'82-13-2-5'}
]});
dataset.age.push({
  folderName:'03', start:1980, end:1988, scale:'1/25000', mapList: [
    {name:'松浜',north:38.0029563328595,west:139.121723175409,south:37.9196361568494,east:139.246715898389,note:'昭和58年修正・昭和60.9.30発行',list:'73-13-1-10'},
    {name:'水原',north:37.9196326748733,west:139.121726875516,south:37.8363124727093,east:139.246719595577,note:'昭和58年修正・昭和60.6.30発行',list:'73-13-2-11'},
    {name:'新潟北部',north:38.0029528561256,west:138.996734180539,south:37.9196326748733,east:139.121726875516,note:'昭和58年二改・昭和60.3.30発行',list:'73-13-3-10'},
    {name:'新潟南部',north:37.919629204564,west:138.996737868219,south:37.836308997187,east:139.121730560346,note:'昭和58年修正・昭和60.8.30発行',list:'73-13-4-11'},
    {name:'新津',north:37.836308997187,west:139.121730560346,south:37.7529887888408,east:139.246723277503,note:'昭和60年修正・昭和61.6.30発行',list:'73-14-1-10'},
    {name:'村松',north:37.7529853197799,west:139.121734229965,south:37.6696650952265,east:139.246726944235,note:'昭和60年修正・昭和61.3.30発行',list:'73-14-2-9'},
    {name:'白根',north:37.8363055333099,west:138.996741540673,south:37.7529853197799,east:139.121734229965,note:'昭和60年修正・昭和61.6.30発行',list:'73-14-3-9'},
    {name:'新発田',north:38.0029598212819,west:139.246712185872,south:37.9196396504757,east:139.371704936888,note:'昭和60年修正・昭和61.7.30発行',list:'73-9-3-10'},
    {name:'天王',north:37.9196361568494,west:139.246715898389,south:37.8363159598602,east:139.371708646417,note:'昭和60年修正・昭和61.8.30発行',list:'73-9-4-11'},
    {name:'加茂',north:37.6696581816446,west:138.996748840169,south:37.5863379257339,east:139.12174152384,note:'昭和63年修正・平成2.2.1発行',list:'73-15-3-8'},
    {name:'三条',north:37.6696547422728,west:138.871759811368,south:37.5863344811986,east:138.996752467345,note:'昭和62年修正・昭和63.4.30発行',list:'81-3-1-11B'},
    {name:'見附',north:37.5863310482599,west:138.871763426303,south:37.503010780984,east:138.99675607956,note:'昭和62年修正・昭和63.10.30発行',list:'81-3-2-9'},
    {name:'栃尾',north:37.5030073544859,west:138.871767026328,south:37.4196870709835,east:138.99675967688,note:'昭和62年修正・昭和63.2.28発行',list:'81-4-1-9B'},
    {name:'長岡',north:37.5030039395788,west:138.746777988479,south:37.4196836509334,east:138.871770611508,note:'昭和62年修正・昭和63.10.30発行',list:'81-4-3-11'},
    {name:'片貝',north:37.4196802424526,west:138.746781561503,south:37.3363599275853,east:138.871774181909,note:'昭和62年修正・昭和63.6.30発行',list:'81-4-4-11'},
    {name:'小千谷',north:37.3363565255382,west:138.746785119797,south:37.2530362044211,east:138.871777737593,note:'昭和56年修正・昭和57.11.30発行',list:'82-1-3-11'},
      {name:'柿崎', north:37.3363463888429, west:138.371818025038, south:37.2530260522441, east:138.496810560877,note:'昭和55年修正・昭和57.8.30発行',list:'82-9-1-6'},
      {name:'矢代田', north:37.7529818623426, west:138.996745197967, south:37.6696616326346, east:139.121737884441,note:'昭和60年修正・昭和61.3.30発行',list:'73-14-4-9'},
      {name:'内野', north:37.9196254922926, west:138.862565885834, south:37.8363055333099, east:138.996741540673,note:'昭和58年修正・昭和60.3.30発行',list:'81-1-2-4B'},
      {name:'塚野山', north:37.4196768455573, west:138.621792526812, south:37.3363565255382, east:138.746785119797,note:'昭和62年修正・昭和63.10.30発行',list:'81-8-2-6'},
      {name:'半蔵金', north:37.4196836509334, west:138.871770611508, south:37.3363633411799, east:138.99676325937,note:'昭和62年修正・昭和63.6.30発行',list:'81-4-2-8B'},
      {name:'青海川', north:37.4196700865877, west:138.371814503166, south:37.3363497561509, east:138.496807041414,note:'昭和55年修正・昭和57.6.30発行',list:'81-12-2-6'},
      {name:'柏崎', north:37.4196734602636, west:138.496803507384, south:37.3363531350546, east:138.621796072982,note:'昭和55年修正・昭和57.3.30発行',list:'81-8-4-7'},
      {name:'新井', north:37.0863719202058, west:138.246839466357, south:37.0030515298224, east:138.371831967999,note:'昭和55年修正・昭和57.2.28発行',list:'82-10-4-6'},
      {name:'直江津', north:37.2530160042317, west:138.12184352075, south:37.169695640994, east:138.246835999866,note:'昭和55年修正・昭和57.5.30発行',list:'82-13-2-7'},
      {name:'高田西部', north:37.1696923095956, west:138.12184698949, south:37.0863719202058, east:138.246839466357,note:'昭和55年修正・昭和56.12.28発行',list:'82-14-1-7'},
      {name:'重倉山', north:37.0863685951532, west:138.121850443939, south:37.0030481995834, east:138.246842918568,note:'昭和55年修正・昭和57.1.30発行',list:'82-14-2-6'},
      {name:'原之町', north:37.2530226913115, west:138.371821532395, south:37.1697023385262, east:138.496814065838,note:'昭和55年修正・昭和57.2.28発行',list:'82-9-2-6'},
      {name:'三ツ屋浜', north:37.3363430331468, west:138.246829023804, south:37.2530226913115, east:138.371821532395,note:'昭和55年修正・昭和56.12.28発行',list:'82-9-3-6'},
      {name:'潟町', north:37.2530193419687, west:138.246832519036, south:37.1696989839762, east:138.371825025299,note:'昭和55年修正・昭和57.1.30発行',list:'82-9-4-7'},
      {name:'高田東部', north:37.169695640994, west:138.246835999866, south:37.08637525682, east:138.371828503813,note:'昭和55年修正・昭和57.12.28発行',list:'82-10-3-7'}
]});
dataset.age.push({
  folderName:'04', start:1997, end:2001, scale:'1/25000', mapList: [
    {name:'松浜',north:38.0029563328595,west:139.121723175409,south:37.9196361568494,east:139.246715898389,note:'平成13年修正・平成14.5.26発行',list:'73-13-1-14'},
    {name:'水原',north:37.9196326748733,west:139.121726875516,south:37.8363124727093,east:139.246719595577,note:'平成13年修正・平成14.5.26発行',list:'73-13-2-15'},
    {name:'新潟北部',north:38.0029528561256,west:138.996734180539,south:37.9196326748733,east:139.121726875516,note:'平成13年修正・平成14.6.1発行',list:'73-13-3-14'},
    {name:'新潟南部',north:37.919629204564,west:138.996737868219,south:37.836308997187,east:139.121730560346,note:'平成13年修正・平成14.6.1発行',list:'73-13-4-16'},
    {name:'新津',north:37.836308997187,west:139.121730560346,south:37.7529887888408,east:139.246723277503,note:'平成13年修正・平成14.4.1発行',list:'73-14-1-14'},
    {name:'村松',north:37.7529853197799,west:139.121734229965,south:37.6696650952265,east:139.246726944235,note:'平成13年修正・平成14.4.1発行',list:'73-14-2-12'},
    {name:'白根',north:37.8363055333099,west:138.996741540673,south:37.7529853197799,east:139.121734229965,note:'平成13年修正・平成15.3.1発行',list:'73-14-3-13'},
    {name:'新発田',north:38.0029598212819,west:139.246712185872,south:37.9196396504757,east:139.371704936888,note:'平成13年修正・平成14.5.26発行',list:'73-9-3-13'},
    {name:'天王',north:37.9196361568494,west:139.246715898389,south:37.8363159598602,east:139.371708646417,note:'平成12年修正・平成14.1.1発行',list:'73-9-4-14'},
    {name:'加茂',north:37.6696581816446,west:138.996748840169,south:37.5863379257339,east:139.12174152384,note:'平成13年修正・平成14.12.1発行',list:'73-15-3-10'},
    {name:'三条',north:37.6696547422728,west:138.871759811368,south:37.5863344811986,east:138.996752467345,note:'平成13年修正・平成14.7.1発行',list:'81-3-1-14'},
    {name:'見附',north:37.5863310482599,west:138.871763426303,south:37.503010780984,east:138.99675607956,note:'平成13年修正・平成15.1.1発行',list:'81-3-2-12'},
    {name:'栃尾',north:37.5030073544859,west:138.871767026328,south:37.4196870709835,east:138.99675967688,note:'平成13年修正・平成14.8.1発行',list:'81-4-1-11'},
    {name:'長岡',north:37.5030039395788,west:138.746777988479,south:37.4196836509334,east:138.871770611508,note:'平成13年修正・平成15.3.1発行',list:'81-4-3-14'},
    {name:'片貝',north:37.4196802424526,west:138.746781561503,south:37.3363599275853,east:138.871774181909,note:'平成13年修正・平成14.11.1発行',list:'81-4-4-15'},
    {name:'小千谷',north:37.3363565255382,west:138.746785119797,south:37.2530362044211,east:138.871777737593,note:'平成13年修正・平成14.10.1発行',list:'82-1-3-15'},
      {name:'柏崎', north:37.4196725653829, west:138.46369161889, south:37.3363531350546, east:138.621796072982,note:'平成13年修正・平成15.1.1発行',list:'81-8-4-12'},
      {name:'柿崎', north:37.3439894712265, west:138.349375276537, south:37.2530260522441, east:138.496810560877,note:'平成13年修正・平成14.10.1発行',list:'82-9-1-9'},
      {name:'矢代田', north:37.7529818623426, west:138.996745197967, south:37.6696616326346, east:139.121737884441,note:'平成13年修正・平成15.4.1発行',list:'73-14-4-13'},
      {name:'内野', north:37.9196254977383, west:138.862763068453, south:37.8363055333099, east:138.996741540673,note:'平成13年修正・平成15.5.1発行',list:'81-1-2-9'},
      {name:'塚野山', north:37.4196768455573, west:138.621792526812, south:37.3363565255382, east:138.746785119797,note:'平成13年修正・平成15.3.1発行',list:'81-8-2-8'},
      {name:'半蔵金', north:37.4196836509334, west:138.871770611508, south:37.3363633411799, east:138.99676325937,note:'平成13年修正・平成15.1.1発行',list:'81-4-2-10'},
      {name:'高田東部', north:37.169695640994, west:138.246835999866, south:37.08637525682, east:138.371828503813,note:'平成9年部修・平成10.8.1発行',list:'82-10-3-11'},
      {name:'潟町', north:37.2530184324227, west:138.212815611763, south:37.1696989839762, east:138.371825025299,note:'平成13年修正・平成14.8.1発行',list:'82-9-4-11'},
      {name:'原之町', north:37.2530226913115, west:138.371821532395, south:37.1697023385262, east:138.496814065838,note:'平成13年修正・平成15.3.1発行',list:'82-9-2-9'},
      {name:'重倉山', north:37.0863685951532, west:138.121850443939, south:37.0030481995834, east:138.246842918568,note:'平成11年部修・平成11.10.30発行',list:'82-14-2-8B'},
      {name:'高田西部', north:37.1800270250449, west:138.121846560036, south:37.0863719202058, east:138.246839466357,note:'平成11年部修・平成11.10.30発行',list:'82-14-1-11C'},
      {name:'新井', north:37.0863719202058, west:138.246839466357, south:37.0030515298224, east:138.371831967999,note:'平成13年修正・平成15.8.1発行',list:'82-10-4-10'}
]});
kjmapDataSet['kanazawa'] = new Object();
dataset = kjmapDataSet['kanazawa'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1909, end:1910, scale:'1/20000', mapList: [
    {name:'津幡',north:36.7363722026937,west:136.699879057116,south:36.669715788281,east:136.799872786091,note:'明治42年測図・明治43.5.30発行',list:'s704'},
    {name:'竹橋',north:36.6697132597327,west:136.69988165493,south:36.6030568251021,east:136.799875382986,note:'明治42年測図・明治43.5.30発行',list:'s705'},
    {name:'二俣',north:36.6030543004778,west:136.699884244189,south:36.5363978556151,east:136.799877971329,note:'明治42年測図・明治43.5.30発行',list:'s706'},
    {name:'湯涌',north:36.5363953349185,west:136.69988682492,south:36.4697388898099,east:136.799880551149,note:'明治42年測図・明治43.5.30発行',list:'s707'},
    {name:'白尾',north:36.7363696776866,west:136.599887942783,south:36.6697132597327,east:136.69988165493,note:'明治42年測図・明治43.5.30発行',list:'s709'},
    {name:'大野',north:36.6697104589732,west:136.588780419935,south:36.6030543004778,east:136.699884244189,note:'明治42年測図・明治43.5.30発行',list:'s710'},
    {name:'金澤',north:36.6030517832923,west:136.599893114542,south:36.5363953349185,east:136.69988682492,note:'明治42年測図・明治43.5.30発行',list:'s712'},
    {name:'野々市',north:36.536392821649,west:136.599895687654,south:36.4697363730444,east:136.699889397154,note:'明治42年測図・明治43.5.30発行',list:'s714'},
    {name:'鶴來',north:36.4697338636945,west:136.599898252294,south:36.4030773948487,east:136.699891960919,note:'明治42年測図・明治43.5.30発行',list:'s716'},
    {name:'上金石',north:36.6030492735531,west:136.499901994018,south:36.536392821649,east:136.599895687654,note:'明治42年測図・明治43.5.30発行',list:'s718'},
    {name:'松任',north:36.5363903158143,west:136.499904559504,south:36.4697338636945,east:136.599898252294,note:'明治42年測図・明治43.5.30発行',list:'s719'},
    {name:'辰口',north:36.4697313617677,west:136.499907116542,south:36.4030748894218,east:136.59990080849,note:'明治42年測図・明治43.5.30発行',list:'s721'},
    {name:'美川',north:36.536387817422,west:136.399913440442,south:36.4697313617677,east:136.499907116542,note:'明治42年測図・明治43.5.30発行',list:'s723'},
    {name:'小松北部',north:36.4697288672717,west:136.39991598987,south:36.4030723914064,east:136.499909665161,note:'明治42年測図・明治43.5.30発行',list:'s724'},
    {name:'佐賀野',north:36.8030362296049,west:136.899858691542,south:36.7363798224548,east:136.99985245522,note:'明治42年測図・明治43.5.30発行',list:'s691'},
    {name:'福岡',north:36.7363772750855,west:136.899861313307,south:36.6697208676976,east:136.999855075995,note:'明治42年測図・明治43.5.30発行',list:'s692'},
    {name:'出町',north:36.6697183242719,west:136.899863926437,south:36.6030618966358,east:136.999857688139,note:'明治42年測図・明治43.5.30発行',list:'s693'},
    {name:'福野',north:36.6030593571573,west:136.89986653096,south:36.536402919259,east:136.999860291681,note:'明治42年測図・明治43.5.30発行',list:'s695'},
    {name:'城端',north:36.5364003837312,west:136.899869126906,south:36.4697439455568,east:136.999862886649,note:'明治42年測図・明治43.5.30発行',list:'s697'},
    {name:'石動',north:36.7363747351625,west:136.799870180615,south:36.6697183242719,east:136.899863926437,note:'明治42年測図・明治43.5.30発行',list:'s698'},
    {name:'礪波山',north:36.669715788281,west:136.799872786091,south:36.6030593571573,east:136.89986653096,note:'明治42年測図・明治43.5.30発行',list:'s700'},
    {name:'福光',north:36.6030568251021,west:136.799875382986,south:36.5364003837312,east:136.899869126906,note:'明治42年測図・明治43.5.30発行',list:'s702'},
    {name:'才川七',north:36.5363978556151,west:136.799877971329,south:36.4697414139833,east:136.899871714305,note:'明治42年測図・明治43.5.30発行',list:'s703'},
    {name:'魚津東部',north:36.8697080286079,west:137.399811786737,south:36.8030516490565,east:137.499805636355,note:'明治43年測図・明治44.6.30発行',list:'s728'},
    {name:'北山',north:36.8030490605748,west:137.399814455569,south:36.7363926707244,east:137.499808304027,note:'明治43年測図・明治44.6.30発行',list:'s729'},
    {name:'魚津西部',north:36.8697054435626,west:137.299820622977,south:36.8030490605748,east:137.399814455569,note:'明治43年測図・明治44.6.30発行',list:'s731'},
    {name:'滑川',north:36.8030464795118,west:137.299823284146,south:36.7363900862401,east:137.39981711561,note:'明治43年測図・明治44.6.30発行',list:'s732'},
    {name:'上市',north:36.7363875091631,west:137.299825936547,south:36.6697311155934,east:137.399819766887,note:'明治43年測図・明治44.6.30発行',list:'s733'},
    {name:'五百石',north:36.669728542506,west:137.299828580212,south:36.6030721286278,east:137.399822409434,note:'明治43年測図・明治44.6.30発行',list:'s734'},
    {name:'東岩瀬',north:36.8030439058755,west:137.199832122058,south:36.7363875091631,east:137.299825936547,note:'明治43年測図・明治44.6.30発行',list:'s736'},
    {name:'富山',north:36.7363849395014,west:137.199834766813,south:36.669728542506,east:137.299828580212,note:'明治43年測図・明治44.6.30発行',list:'s737'},
    {name:'下大久保',north:36.6697259768224,west:137.199837402855,south:36.6030695595337,east:137.299831215169,note:'明治43年測図・明治44.6.30発行',list:'s738'},
    {name:'四方',north:36.8030413396738,west:137.09984096928,south:36.7363849395014,east:137.199834766813,note:'明治43年測図・明治44.6.30発行',list:'s740'},
    {name:'呉羽村',north:36.7363823772627,west:137.099843606379,south:36.6697259768224,east:137.199837402855,note:'明治43年測図・明治44.6.30発行',list:'s741'},
    {name:'長澤',north:36.6697234185503,west:137.099846234792,south:36.6030669978317,east:137.199840030216,note:'明治43年測図・明治44.6.30発行',list:'s742'},
    {name:'髙岡',north:36.8030387809143,west:136.999849825783,south:36.7363823772627,east:137.099843606379,note:'明治43年測図・明治44.6.30発行',list:'s745'},
    {name:'小杉',north:36.7363798224548,west:136.99985245522,south:36.6697234185503,east:137.099846234792,note:'明治43年測図・明治44.6.30発行',list:'s746'},
    {name:'宮森新',north:36.6697208676976,west:136.999855075995,south:36.6030644435299,east:137.099848854549,note:'明治43年測図・明治44.6.30発行',list:'s747'}
]});
dataset.age.push({
  folderName:'00', start:1930, end:1930, scale:'1/25000', mapList: [
    {name:'津幡',north:36.7530350472628,west:136.624885071155,south:36.6697145230761,east:136.749877219364,note:'昭和5年測図・昭和9.6.30発行',list:'93-8-2-1'},
    {name:'美川',north:36.5093463027226,west:136.374916696536,south:36.4197371370891,east:136.499909028794,note:'昭和5年測図・昭和9.7.30発行',list:'94-10-1-1'},
    {name:'小松',north:36.4197340237853,west:136.374920114756,south:36.3364134147201,east:136.499912205391,note:'昭和5年測図・昭和9.5.30発行',list:'94-10-2-1',war:true},
    {name:'粟崎',north:36.6697113682103,west:136.624888312571,south:36.586390818072,east:136.749880459376,note:'昭和5年測量・昭和8.5.30発行',list:'94-5-1-1'},
    {name:'金澤',north:36.586387669327,west:136.624891540648,south:36.5030671132098,east:136.749883686056,note:'昭和5年測図・昭和8.5.30発行',list:'94-5-2-1'},
    {name:'金石',north:36.6697082249946,west:136.499899420056,south:36.586387669327,east:136.624891540648,note:'昭和5年測図・昭和9.1.30発行',list:'94-5-3-1'},
    {name:'松任',north:36.5863845322095,west:136.499902636183,south:36.5030639705925,east:136.624894755443,note:'昭和5年測図・昭和23.5.30発行',list:'94-5-4-2'},
    {name:'鶴來',north:36.5030639705925,west:136.624894755443,south:36.4197433984726,east:136.749886899461,note:'昭和5年測図・昭和9.6.30発行',list:'94-6-1-1',war:true},
    {name:'粟生',north:36.5030608395799,west:136.499905839077,south:36.4197402619898,east:136.624897957012,note:'昭和5年測図・昭和9.7.30発行',list:'94-6-3-1'},
    {name:'魚津',north:36.836377893919,west:137.374815329478,south:36.7530574183987,east:137.499807637934,note:'昭和5年修正・昭和9.9.30発行',list:'88-12-1-2'},
    {name:'滑川',north:36.8363746685838,west:137.249826374366,south:36.7530541877013,east:137.374818656257,note:'昭和5年修正・昭和10.3.30発行',list:'88-12-3-3',war:true},
    {name:'上市',north:36.7530509685853,west:137.24982968919,south:36.6697304716279,east:137.374821969343,note:'昭和5年修正・昭和8.11.30発行',list:'88-12-4-3'},
    {name:'東岩瀨',north:36.8363714548678,west:137.124837433827,south:36.7530509685853,east:137.24982968919,note:'昭和5年修正・昭和10.5.30発行',list:'88-16-1-3'},
    {name:'富山',north:36.7530477610663,west:137.12484073668,south:36.6697272587383,east:137.24983299037,note:'昭和5年修正・昭和9.11.30発行',list:'88-16-2-3',war:true},
    {name:'伏木',north:36.8363682527864,west:136.999848507808,south:36.7530477610663,east:137.12484073668,note:'昭和5年修正・昭和10.5.30発行',list:'88-16-3-3',war:true},
    {name:'髙岡',north:36.7530445651593,west:136.999851798674,south:36.6697240574231,east:137.124844025938,note:'昭和5年修正・昭和9.11.30発行',list:'88-16-4-2',war:true},
    {name:'下大久保',north:36.6697240574231,west:137.124844025938,south:36.5864035290257,east:137.249836277966,note:'昭和5年修正・昭和8.10.30発行',list:'89-13-1-4'},
    {name:'長澤',north:36.6697208676976,west:136.999855075995,south:36.5864003339214,east:137.124847301661,note:'昭和5年修正・昭和10.5.30発行',list:'89-13-3-2'},
    {name:'五百石',north:36.6697272587383,west:137.24983299037,south:36.586406735682,east:137.374825268796,note:'昭和5年修正',list:'89-9-3-3'},
    {name:'戸出',north:36.7530413808796,west:136.874862875119,south:36.6697208676976,east:136.999855075995,note:'昭和5年測図・昭和9.7.30発行',list:'93-4-2-1'},
    {name:'石動',north:36.7530382082424,west:136.749873965964,south:36.6697176895769,east:136.874866140488,note:'昭和5年測図・昭和9.6.30発行',list:'93-4-4-1'},
    {name:'出町',north:36.6697176895769,west:136.874866140488,south:36.5863971503843,east:136.99985833983,note:'昭和5年測図・昭和8.6.30発行',list:'94-1-1-3'},
    {name:'城端',north:36.5863939784295,west:136.874869392419,south:36.503073433199,east:136.999861590235,note:'昭和5年測図・昭和8.6.30発行',list:'94-1-2-1',war:true},
    {name:'倶利伽羅',north:36.6697145230761,west:136.749877219364,south:36.5863939784295,east:136.874869392419,note:'昭和5年修正・昭和8.10.30発行',list:'94-1-3-1'},
    {name:'福光',north:36.586390818072,west:136.749880459376,south:36.503070267417,east:136.874872630969,note:'昭和5年測図・昭和23.8.30発行',list:'94-1-4-2'}
]});
dataset.age.push({
  folderName:'01', start:1968, end:1969, scale:'1/25000', mapList: [
    {name:'津幡',north:36.7530349743467,west:136.621996427978,south:36.669714450032,east:136.74698857558,note:'昭和43年改測・昭和45.3.30発行',list:'93-8-2-3'},
    {name:'美川',north:36.5030576482316,west:136.372028293557,south:36.4197370650059,east:136.497020384844,note:'昭和44年改測・昭和47.3.30発行',list:'94-10-1-3'},
    {name:'小松',north:36.4197339519704,west:136.372031471133,south:36.336413342778,east:136.497023561168,note:'昭和44年改測・昭和46.6.30発行',list:'94-10-2-3'},
    {name:'粟崎',north:36.6697112954353,west:136.621999669117,south:36.5863907451696,east:136.746991815316,note:'昭和43年改測・昭和45.3.30発行',list:'94-5-1-4'},
    {name:'金沢',north:36.5863875966932,west:136.622002896918,south:36.5030670404493,east:136.746995041721,note:'昭和43年改測・昭和45.1.30発行',list:'94-5-2-4'},
    {name:'金石',north:36.6697081524889,west:136.497010776932,south:36.5863875966932,east:136.622002896918,note:'昭和43年改測・昭和45.3.30発行',list:'94-5-3-3'},
    {name:'松任',north:36.5863843200769,west:136.491434088469,south:36.5030638981,east:136.622006111438,note:'昭和43年改測・昭和45.3.30発行',list:'94-5-4-4'},
    {name:'鶴来',north:36.5030638981,west:136.622006111438,south:36.4197433258541,east:136.746998254854,note:'昭和44年改測・昭和47.3.30発行',list:'94-6-1-3'},
    {name:'粟生',north:36.5030607673558,west:136.497017195401,south:36.4197401896388,east:136.622009312733,note:'昭和44年改測・昭和47.3.30発行',list:'94-6-3-4'},
    {name:'魚津',north:36.8363778192466,west:137.371926684574,south:36.7530573436028,east:137.496918992415,note:'昭和43年改測・昭和44.11.30発行',list:'88-12-1-4'},
    {name:'滑川',north:36.8363745941797,west:137.246937729799,south:36.7530541131728,east:137.371930011077,note:'昭和43年改測・昭和45.3.30発行',list:'88-12-3-7'},
    {name:'上市',north:36.7530508943247,west:137.246941044347,south:36.6697303972436,east:137.371933323888,note:'昭和43年改測・昭和44.10.30発行',list:'88-12-4-7'},
    {name:'富山港',north:36.8363713807325,west:137.121948789596,south:36.7530508943247,east:137.246941044347,note:'昭和43年改測・昭和45.1.30発行',list:'88-16-1-5'},
    {name:'富山',north:36.7530476870739,west:137.121952092172,south:36.6697271846213,east:137.246944345251,note:'昭和43年改測・昭和45.3.30発行',list:'88-16-2-7'},
    {name:'伏木',north:36.8363681789201,west:136.996959863912,south:36.7530476870739,east:137.121952092172,note:'昭和43年改測・昭和45.3.30発行',list:'88-16-3-6'},
    {name:'高岡',north:36.7530444914354,west:136.996963154501,south:36.6697239835738,east:137.121955381155,note:'昭和43年改測・昭和45.1.30発行',list:'88-16-4-6'},
    {name:'速星',north:36.6697239835738,west:137.121955381155,south:36.5864034550525,east:137.246947632573,note:'昭和43年改測・昭和44.11.30発行',list:'89-13-1-8'},
    {name:'宮森新',north:36.6697207941163,west:136.996966431546,south:36.5864002602154,east:137.121958656603,note:'昭和43年改測・昭和45.3.30発行',list:'89-13-3-5'},
    {name:'五百石',north:36.6697271846213,west:137.246944345251,south:36.586406661442,east:137.371936623067,note:'昭和43年改測・昭和44.11.30発行',list:'89-9-3-6B'},
    {name:'戸出',north:36.7530413074247,west:136.87197423128,south:36.6697207941163,east:136.996966431546,note:'昭和43年改測・昭和45.3.30発行',list:'93-4-2-3'},
    {name:'石動',north:36.7530381350567,west:136.746985322457,south:36.669717616264,east:136.871977496372,note:'昭和43年改測・昭和45.3.30発行',list:'93-4-4-3'},
    {name:'砺波',north:36.669717616264,west:136.871977496372,south:36.5863970769458,east:136.996969695106,note:'昭和43年改測・昭和45.3.30発行',list:'94-1-1-2'},
    {name:'城端',north:36.5863939052588,west:136.871980748027,south:36.5030733599035,east:136.996972945237,note:'昭和43年改測・昭和45.3.30発行',list:'94-1-2-4'},
    {name:'倶利伽羅',north:36.669714450032,west:136.74698857558,south:36.5863939052588,east:136.871980748027,note:'昭和43年改測・昭和44.11.30発行',list:'94-1-3-4'},
    {name:'福光',north:36.5863907451696,west:136.746991815316,south:36.5030701943888,east:136.871983986303,note:'昭和43年改測・昭和45.3.30発行',list:'94-1-4-7'}
]});
dataset.age.push({
  folderName:'02', start:1981, end:1985, scale:'1/25000', mapList: [
    {name:'津幡',north:36.7530349743467,west:136.621996427978,south:36.669714450032,east:136.74698857558,note:'昭和59年修正・昭和61.10.30発行',list:'93-8-2-6'},
    {name:'美川',north:36.5030576482316,west:136.372028293557,south:36.4197370650059,east:136.497020384844,note:'昭和56年修正・昭和58.1.30発行',list:'94-10-1-6'},
    {name:'小松',north:36.4197339519704,west:136.372031471133,south:36.336413342778,east:136.497023561168,note:'昭和56年修正・昭和58.1.30発行',list:'94-10-2-6'},
    {name:'粟崎',north:36.6697112954353,west:136.621999669117,south:36.5863907451696,east:136.746991815316,note:'昭和58年修正・昭和60.4.30発行',list:'94-5-1-8'},
    {name:'金沢',north:36.5863875966932,west:136.622002896918,south:36.5030670404493,east:136.746995041721,note:'昭和58年二改・昭和60.1.30発行',list:'94-5-2-8'},
    {name:'金石',north:36.6697081524889,west:136.497010776932,south:36.5863875966932,east:136.622002896918,note:'昭和58年修正・昭和60.9.30発行',list:'94-5-3-7'},
    {name:'松任',north:36.5863843200769,west:136.491434088469,south:36.5030638981,east:136.622006111438,note:'昭和58年二改・昭和59.11.30発行',list:'94-5-4-8'},
    {name:'鶴来',north:36.5030638981,west:136.622006111438,south:36.4197433258541,east:136.746998254854,note:'昭和58年修正・昭和59.11.30発行',list:'94-6-1-5'},
    {name:'粟生',north:36.5030607673558,west:136.497017195401,south:36.4197401896388,east:136.622009312733,note:'昭和58年修正・昭和59.10.30発行',list:'94-6-3-6C'},
    {name:'魚津',north:36.8363778192466,west:137.371926684574,south:36.7530573436028,east:137.496918992415,note:'昭和60年修正・昭和62.3.30発行',list:'88-12-1-7'},
    {name:'滑川',north:36.8363745941797,west:137.246937729799,south:36.7530541131728,east:137.371930011077,note:'昭和60年修正・昭和62.1.30発行',list:'88-12-3-10'},
    {name:'上市',north:36.7530508943247,west:137.246941044347,south:36.6697303972436,east:137.371933323888,note:'昭和60年修正・昭和62.1.30発行',list:'88-12-4-10'},
    {name:'富山港',north:36.8363713807325,west:137.121948789596,south:36.7530508943247,east:137.246941044347,note:'昭和58年修正・昭和60.2.28発行',list:'88-16-1-9'},
    {name:'富山',north:36.7530476870739,west:137.121952092172,south:36.6697271846213,east:137.246944345251,note:'昭和58年二改・昭和60.2.28発行',list:'88-16-2-11'},
    {name:'伏木',north:36.8363681789201,west:136.996959863912,south:36.7530476870739,east:137.121952092172,note:'昭和58年修正・昭和60.9.30発行',list:'88-16-3-10'},
    {name:'高岡',north:36.7530444914354,west:136.996963154501,south:36.6697239835738,east:137.121955381155,note:'昭和58年修正・昭和60.6.30発行',list:'88-16-4-10'},
    {name:'速星',north:36.6697239835738,west:137.121955381155,south:36.5864034550525,east:137.246947632573,note:'昭和60年修正・昭和62.2.28発行',list:'89-13-1-11'},
    {name:'宮森新',north:36.6697207941163,west:136.996966431546,south:36.5864002602154,east:137.121958656603,note:'昭和60年修正・昭和62.2.28発行',list:'89-13-3-7'},
    {name:'五百石',north:36.6697271846213,west:137.246944345251,south:36.586406661442,east:137.371936623067,note:'昭和60年修正・昭和61.9.30発行',list:'89-9-3-8'},
    {name:'戸出',north:36.7530413074247,west:136.87197423128,south:36.6697207941163,east:136.996966431546,note:'昭和59年修正・昭和61.10.30発行',list:'93-4-2-6'},
    {name:'石動',north:36.7530381350567,west:136.746985322457,south:36.669717616264,east:136.871977496372,note:'昭和59年修正・昭和62.1.30発行',list:'93-4-4-6'},
    {name:'砺波',north:36.669717616264,west:136.871977496372,south:36.5863970769458,east:136.996969695106,note:'昭和59年修正・昭和60.12.28発行',list:'94-1-1-8'},
    {name:'城端',north:36.5863939052588,west:136.871980748027,south:36.5030733599035,east:136.996972945237,note:'昭和59年修正・昭和60.12.28発行',list:'94-1-2-7'},
    {name:'倶利伽羅',north:36.669714450032,west:136.74698857558,south:36.5863939052588,east:136.871980748027,note:'昭和59年修正・昭和61.3.30発行',list:'94-1-3-7'},
    {name:'福光',north:36.5863907451696,west:136.746991815316,south:36.5030701943888,east:136.871983986303,note:'昭和59年修正・昭和61.2.28発行',list:'94-1-4-10B'}
]});
dataset.age.push({
  folderName:'03', start:1994, end:2001, scale:'1/25000', mapList: [
    {name:'津幡',north:36.7530349743467,west:136.621996427978,south:36.669714450032,east:136.74698857558,note:'平成12年修正・平成13.7.1発行',list:'93-8-2-8B'},
    {name:'美川',north:36.5030576482316,west:136.372028293557,south:36.4197370650059,east:136.497020384844,note:'平成8年修正・平成9.7.1発行',list:'94-10-1-9B'},
    {name:'小松',north:36.4197339519704,west:136.372031471133,south:36.336413342778,east:136.497023561168,note:'平成12年部修・平成13.12.1発行',list:'94-10-2-9'},
    {name:'粟崎',north:36.6697112954353,west:136.621999669117,south:36.5863907451696,east:136.746991815316,note:'平成12年修正・平成13.7.1発行',list:'94-5-1-12B'},
    {name:'金沢',north:36.5863875966932,west:136.622002896918,south:36.5030670404493,east:136.746995041721,note:'平成12年修正・平成13.5.1発行',list:'94-5-2-13B'},
    {name:'金石',north:36.6697081524889,west:136.497010776932,south:36.5863875966932,east:136.622002896918,note:'平成12年修正・平成13.6.1発行',list:'94-5-3-10B'},
    {name:'松任',north:36.5863843200769,west:136.491434088469,south:36.5030638981,east:136.622006111438,note:'平成12年修正・平成13.6.1発行',list:'94-5-4-11B'},
    {name:'鶴来',north:36.5030638981,west:136.622006111438,south:36.4197433258541,east:136.746998254854,note:'平成11年部修・平成12.9.1発行',list:'94-6-1-7B'},
    {name:'粟生',north:36.5030607673558,west:136.497017195401,south:36.4197401896388,east:136.622009312733,note:'平成11年部修・平成12.4.1発行',list:'94-6-3-9B'},
    {name:'魚津',north:36.8363778192466,west:137.371926684574,south:36.7530573436028,east:137.496918992415,note:'平成12年部修・平成12.10.1発行',list:'88-12-1-10B'},
    {name:'滑川',north:36.8363745941797,west:137.246937729799,south:36.7530541131728,east:137.371930011077,note:'平成9年修正・平成10.11.1発行',list:'88-12-3-12B'},
    {name:'上市',north:36.7530508943247,west:137.246941044347,south:36.6697303972436,east:137.371933323888,note:'平成11年部修・平成12.12.1発行',list:'88-12-4-13B'},
    {name:'富山港',north:36.8363713807325,west:137.121948789596,south:36.7530508943247,east:137.246941044347,note:'平成13年修正・平成15.5.1発行',list:'88-16-1-12'},
    {name:'富山',north:36.7530476870739,west:137.121952092172,south:36.6697271846213,east:137.246944345251,note:'平成13年修正・平成14.6.1発行',list:'88-16-2-17'},
    {name:'伏木',north:36.8363681789201,west:136.996959863912,south:36.7530476870739,east:137.121952092172,note:'平成11年部修・平成12.5.1発行',list:'88-16-3-14B'},
    {name:'高岡',north:36.7530444914354,west:136.996963154501,south:36.6697239835738,east:137.121955381155,note:'平成6年修正・平成7.8.1発行',list:'88-16-4-13'},
    {name:'速星',north:36.6697239835738,west:137.121955381155,south:36.5864034550525,east:137.246947632573,note:'平成8年部修・平成8.10.1発行',list:'89-13-1-14C'},
    {name:'宮森新',north:36.6697207941163,west:136.996966431546,south:36.5864002602154,east:137.121958656603,note:'平成6年修正・平成7.5.1発行',list:'89-13-3-9B'},
    {name:'五百石',north:36.6697271846213,west:137.246944345251,south:36.586406661442,east:137.371936623067,note:'平成9年修正・平成10.8.1発行',list:'89-9-3-10B'},
    {name:'戸出',north:36.7530413074247,west:136.87197423128,south:36.6697207941163,east:136.996966431546,note:'平成12年部修・平成12.7.19発行',list:'93-4-2-10B'},
    {name:'石動',north:36.7530381350567,west:136.746985322457,south:36.669717616264,east:136.871977496372,note:'平成12年修正・平成13.7.1発行',list:'93-4-4-9C'},
    {name:'砺波',north:36.669717616264,west:136.871977496372,south:36.5863970769458,east:136.996969695106,note:'平成8年部修・平成8.3.28発行',list:'94-1-1-10B'},
    {name:'城端',north:36.5863939052588,west:136.871980748027,south:36.5030733599035,east:136.996972945237,note:'平成12年部修・平成12.9.30発行',list:'94-1-2-9B'},
    {name:'倶利伽羅',north:36.669714450032,west:136.74698857558,south:36.5863939052588,east:136.871980748027,note:'平成12年修正・平成13.6.1発行',list:'94-1-3-9B'},
    {name:'福光',north:36.5863907451696,west:136.746991815316,south:36.5030701943888,east:136.871983986303,note:'平成12年修正・平成13.7.1発行',list:'94-1-4-12B'}
]});
kjmapDataSet['fukui'] = new Object();
dataset = kjmapDataSet['fukui'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1909, end:1909, scale:'1/20000', mapList: [
    {name:'松岡',north:36.1364315140735,west:136.299937456345,south:36.069774993493,east:136.399931111167,note:'明治42年測図・明治43.6.30発行',list:'s749'},
    {name:'永平寺',north:36.0697725298166,west:136.299939948368,south:36.0031159889644,east:136.399933602433,note:'明治42年測図・明治43.6.30発行',list:'s751'},
    {name:'森田',north:36.1364290538791,west:136.199946310003,south:36.0697725298166,east:136.299939948368,note:'明治42年測図・明治43.6.30発行',list:'s756'},
    {name:'福井',north:36.0697700735161,west:136.19994879455,south:36.0031135291969,east:136.299942432191,note:'明治42年測図・明治43.6.30発行',list:'s758'},
    {name:'文珠山',north:36.0031110767936,west:136.199951270922,south:35.9364545222041,east:136.299944907842,note:'明治42年測図・明治43.7.30発行',list:'s760'},
    {name:'粟田部',north:35.9364520737015,west:136.199953739146,south:35.869795518828,east:136.299947375346,note:'明治42年測図・明治43.7.30発行',list:'s762'},
    {name:'高屋',north:36.13642660108,west:136.099955172622,south:36.0697700735161,east:136.19994879455,note:'明治42年測図・明治43.6.30発行',list:'s765'},
    {name:'大森',north:36.069767624599,west:136.099957649686,south:36.0031110767936,east:136.199951270922,note:'明治42年測図・明治43.6.30発行',list:'s766'},
    {name:'鯖江',north:36.003108631762,west:136.099960118599,south:35.9364520737015,east:136.199953739146,note:'明治42年測図・明治43.7.30発行',list:'s767'},
    {name:'武生',north:35.9364496325589,west:136.099962579389,south:35.8697930742295,east:136.199956199248,note:'明治42年測図・明治43.7.30発行',list:'s769'}
]});
dataset.age.push({
  folderName:'00', start:1930, end:1930, scale:'1/25000', mapList: [
    {name:'丸岡',north:36.1697597818225,west:136.24994063483,south:36.0864391192761,east:136.374932695989,note:'昭和5年測図・昭和7.10.30発行',list:'94-12-3-1'},
    {name:'永平寺',north:36.0864360419177,west:136.249943749036,south:36.0031153733325,east:136.37493580903,note:'昭和5年測図・昭和9.7.30発行',list:'94-12-4-1'},
    {name:'越前森田',north:36.1697567099287,west:136.124951713593,south:36.0864360419177,east:136.249943749036,note:'昭和5年測図・昭和7.8.30発行',list:'94-16-1-1'},
    {name:'福井',north:36.0864329760945,west:136.124954816096,south:36.0031123020742,east:136.249946850437,note:'昭和5年測量・昭和9.3.30発行',list:'94-16-2-1'},
    {name:'鯖江',north:36.0031092423284,west:136.124957905843,south:35.9197885522755,east:136.249949939087,note:'昭和5年修正・昭和8.9.30発行',list:'95-13-1-1'},
    {name:'武生',north:35.9197854986137,west:136.124960982887,south:35.836464782505,east:136.249953015041,note:'昭和5年測図・昭和9.11.30発行',list:'95-13-2-1'}
]});
dataset.age.push({
  folderName:'01', start:1969, end:1973, scale:'1/25000', mapList: [
    {name:'丸岡',north:36.1697597106968,west:136.247051990715,south:36.0864390480246,east:136.37204405128,note:'昭和44年改測・昭和46.2.28発行',list:'94-12-3-4'},
    {name:'永平寺',north:36.0864359709325,west:136.247055104651,south:36.0031153022222,east:136.372047164052,note:'昭和44年改測・昭和46.10.30発行',list:'94-12-4-4'},
    {name:'越前森田',north:36.1697566390703,west:136.122063069802,south:36.0864359709325,east:136.247055104651,note:'昭和44年改測・昭和46.6.30発行',list:'94-16-1-4'},
    {name:'福井',north:36.0864329053762,west:136.122066172035,south:36.0031122312298,east:136.247058205783,note:'昭和44年改測・昭和47.3.30発行',list:'94-16-2-5'},
    {name:'鯖江',north:36.0031091717502,west:136.122069261512,south:35.919788481572,east:136.247061294165,note:'昭和48年改測・昭和50.1.30発行',list:'95-13-1-5'},
    {name:'武生',north:35.9197854281759,west:136.122072338287,south:35.8364647119425,east:136.247064369851,note:'昭和48年改測・昭和50.1.30発行',list:'95-13-2-5'}
]});
dataset.age.push({
  folderName:'02', start:1988, end:1990, scale:'1/25000', mapList: [
    {name:'丸岡',north:36.1697597106968,west:136.247051990715,south:36.0864390480246,east:136.37204405128,note:'平成2年修正・平成3.7.1発行',list:'94-12-3-8'},
    {name:'永平寺',north:36.0864359709325,west:136.247055104651,south:36.0031153022222,east:136.372047164052,note:'平成2年修正・平成3.11.1発行',list:'94-12-4-8'},
    {name:'越前森田',north:36.1697566390703,west:136.122063069802,south:36.0864359709325,east:136.247055104651,note:'昭和63年修正・平成1.6.1発行',list:'94-16-1-8'},
    {name:'福井',north:36.0864329053762,west:136.122066172035,south:36.0031122312298,east:136.247058205783,note:'昭和63年修正・平成1.6.1発行',list:'94-16-2-9B'},
    {name:'鯖江',north:36.0031091717502,west:136.122069261512,south:35.919788481572,east:136.247061294165,note:'昭和63年修正・平成2.1.1発行',list:'95-13-1-7'},
    {name:'武生',north:35.9197854281759,west:136.122072338287,south:35.8364647119425,east:136.247064369851,note:'昭和63年修正・平成1.6.1発行',list:'95-13-2-7'}
]});
dataset.age.push({
  folderName:'03', start:1996, end:2000, scale:'1/25000', mapList: [
    {name:'丸岡',north:36.1697597106968,west:136.247051990715,south:36.0864390480246,east:136.37204405128,note:'平成8年修正・平成9.5.1発行',list:'94-12-3-9B'},
    {name:'永平寺',north:36.0864359709325,west:136.247055104651,south:36.0031153022222,east:136.372047164052,note:'平成11年部修・平成12.5.1発行',list:'94-12-4-10B'},
    {name:'越前森田',north:36.1697566390703,west:136.122063069802,south:36.0864359709325,east:136.247055104651,note:'平成12年部修・平成12.6.1発行',list:'94-16-1-10B'},
    {name:'福井',north:36.0864329053762,west:136.122066172035,south:36.0031122312298,east:136.247058205783,note:'平成11年部修・平成11.12.1発行',list:'94-16-2-11B'},
    {name:'鯖江',north:36.0031091717502,west:136.122069261512,south:35.919788481572,east:136.247061294165,note:'平成8年修正・平成9.3.1発行',list:'95-13-1-8B'},
    {name:'武生',north:35.9197854281759,west:136.122072338287,south:35.8364647119425,east:136.247064369851,note:'平成8年修正・平成9.11.1発行',list:'95-13-2-8B'}
]});
kjmapDataSet['nagano'] = new Object();
dataset = kjmapDataSet['nagano'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1912, end:1912, scale:'1/50000', mapList: [
    {name:'長野',north:36.6697467091554,west:137.99976708416,south:36.5031057242945,east:138.249751983807,note:'明治45年測図・大正2.9.30発行',list:'83-13-1'}
]});
dataset.age.push({
  folderName:'01', start:1937, end:1937, scale:'1/50000', mapList: [
    {name:'長野',north:36.6697467091554,west:137.99976708416,south:36.5031057242945,east:138.249751983807,note:'昭和12年二修・昭和12.8.30発行',list:'83-13-6'}
]});
dataset.age.push({
  folderName:'02', start:1960, end:1960, scale:'1/50000', mapList: [
    {name:'長野',north:36.6697466334398,west:137.996878437003,south:36.503105648345,east:138.24686333542,note:'昭和35年修正・昭和39.12.28発行',list:'83-13-12'}
]});
dataset.age.push({
  folderName:'03', start:1972, end:1973, scale:'1/25000', mapList: [
    {name:'長野',north:36.6697499151879,west:138.121867503979,south:36.586429428345,east:138.246859967597,note:'昭和47年測量・昭和48.12.28発行',list:'83-13-1-1B'},
    {name:'信濃松代',north:36.5864261415195,west:138.12187087397,south:36.503105648345,east:138.24686333542,note:'昭和47年測量・昭和48.12.28発行',list:'83-13-2-1'},
    {name:'信濃中条',north:36.6697466334398,west:137.996878437003,south:36.5864261415195,east:138.12187087397,note:'昭和48年測量・昭和50.2.28発行',list:'83-13-3-1'},
    {name:'稲荷山',north:36.5864228661383,west:137.996881795232,south:36.5031023679158,east:138.121874230095,note:'昭和48年測量・昭和50.2.28発行',list:'83-13-4-1'}
]});
dataset.age.push({
  folderName:'04', start:1985, end:1985, scale:'1/25000', mapList: [
    {name:'長野',north:36.6697499151879,west:138.121867503979,south:36.586429428345,east:138.246859967597,note:'昭和60年修正・昭和62.1.30発行',list:'83-13-1-4B'},
    {name:'信濃松代',north:36.5864261415195,west:138.12187087397,south:36.503105648345,east:138.24686333542,note:'昭和60年修正・昭和61.11.30発行',list:'83-13-2-4'},
    {name:'信濃中条',north:36.6697466334398,west:137.996878437003,south:36.5864261415195,east:138.12187087397,note:'昭和60年修正・昭和61.9.30発行',list:'83-13-3-4B'},
    {name:'稲荷山',north:36.5864228661383,west:137.996881795232,south:36.5031023679158,east:138.121874230095,note:'昭和60年修正・昭和61.11.30発行',list:'83-13-4-4'}
]});
dataset.age.push({
  folderName:'05', start:2001, end:2001, scale:'1/25000', mapList: [
    {name:'長野',north:36.6697499151879,west:138.121867503979,south:36.586429428345,east:138.246859967597,note:'平成13年修正・平成15.4.1発行',list:'83-13-1-8'},
    {name:'信濃松代',north:36.5864261415195,west:138.12187087397,south:36.503105648345,east:138.24686333542,note:'平成13年修正・平成15.5.1発行',list:'83-13-2-8'},
    {name:'信濃中条',north:36.6697466334398,west:137.996878437003,south:36.5864261415195,east:138.12187087397,note:'平成13年修正・平成14.6.1発行',list:'83-13-3-8'},
    {name:'稲荷山',north:36.5864228661383,west:137.996881795232,south:36.5031023679158,east:138.121874230095,note:'平成13年修正・平成14.6.1発行',list:'83-13-4-7'}
]});
kjmapDataSet['matsumoto'] = new Object();
dataset = kjmapDataSet['matsumoto'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1910, end:1910, scale:'1/25000', mapList: [
    {name:'諏訪',north:36.0864801679176,west:137.999790305514,south:36.0031595714781,east:138.124782728576,note:'明治43年測図・大正2.10.30発行',list:'83-16-4-1'},
    {name:'明科',north:36.4197721455341,west:137.874788030611,south:36.3364515997252,east:137.999780435485,note:'明治43年測図・大正2.11.30発行',list:'89-2-2-1'},
    {name:'有明村',north:36.4197689054901,west:137.749798957713,south:36.3364483546172,east:137.874791336198,note:'明治43年測図・大正2.11.30発行',list:'89-2-4-1'},
    {name:'豐科',north:36.3364483546172,west:137.874791336198,south:36.25312780246,east:137.999783739061,note:'明治43年測図・大正2.12.28発行',list:'89-3-1-1'},
    {name:'松本',north:36.2531245637256,west:137.874794628189,south:36.1698039951963,east:137.999787029052,note:'明治43年測図・大正2.12.28発行',list:'89-3-2-1'},
    {name:'小倉',north:36.3364451209173,west:137.749802251651,south:36.2531245637256,east:137.874794628189,note:'明治43年測図・大正2.10.30発行',list:'89-3-3-1'},
    {name:'波多',north:36.2531213363769,west:137.749805532042,south:36.1698007628426,east:137.874797906642,note:'明治43年測図・大正2.10.30発行',list:'89-3-4-1'},
    {name:'鹽尻',north:36.1698007628426,west:137.874797906642,south:36.0864801679176,east:137.999790305514,note:'明治43年測図・大正2.12.28発行',list:'89-4-1-1'},
    {name:'本山',north:36.0864769419516,west:137.874801171614,south:36.0031563406039,east:137.999793568504,note:'明治43年測図・大正2.11.30発行',list:'89-4-2-1'}
]});
dataset.age.push({
  folderName:'01', start:1931, end:1931, scale:'1/25000', mapList: [
    {name:'諏訪',north:36.0864801679176,west:137.999790305514,south:36.0031596855479,east:138.12918764682,note:'昭和6年修正・昭和10.4.30発行',list:'83-16-4-2'},
    {name:'明科',north:36.4197721455341,west:137.874788030611,south:36.3364515997252,east:137.999780435485,note:'昭和6年修正・昭和9.12.28発行',list:'89-2-2-4'},
    {name:'有明',north:36.4197689054901,west:137.749798957713,south:36.3364483546172,east:137.874791336198,note:'昭和6年修正・昭和9.12.28発行',list:'89-2-4-3'},
    {name:'豊科',north:36.3364483546172,west:137.874791336198,south:36.25312780246,east:137.999783739061,note:'昭和6年修正・昭和9.12.28発行',list:'89-3-1-4'},
    {name:'松本',north:36.2531245637256,west:137.874794628189,south:36.1698039951963,east:137.999787029052,note:'昭和6年修正・昭和22.8.30発行',list:'89-3-2-4'},
    {name:'小倉',north:36.3364451209173,west:137.749802251651,south:36.2531245637256,east:137.874794628189,note:'昭和6年修正・昭和9.9.30発行',list:'89-3-3-2'},
    {name:'波多',north:36.2531213363769,west:137.749805532042,south:36.1698007628426,east:137.874797906642,note:'昭和6年修正・昭和22.9.30発行',list:'89-3-4-4'},
    {name:'鹽尻',north:36.1698007628426,west:137.874797906642,south:36.0864801679176,east:137.999790305514,note:'昭和6年修正・昭和10.1.30発行',list:'89-4-1-2'},
    {name:'北小野',north:36.0864769419516,west:137.874801171614,south:36.0031563406039,east:137.999793568504,note:'昭和6年修正・昭和10.4.30発行',list:'89-4-2-2'}
]});
dataset.age.push({
  folderName:'02', start:1974, end:1975, scale:'1/25000', mapList: [
    {name:'諏訪',north:36.0864800932337,west:137.996901656476,south:36.0031594966812,east:138.121894078933,note:'昭和49年改測・昭和51.3.30発行',list:'83-16-4-5B'},
    {name:'明科',north:36.4197720705237,west:137.871899382983,south:36.3364515245982,east:137.996891787246,note:'昭和49年改測・昭和51.2.28発行',list:'89-2-2-6'},
    {name:'有明',north:36.4197688307441,west:137.746910310426,south:36.3364482797537,east:137.871902688301,note:'昭和49年改測・昭和51.2.28発行',list:'89-2-4-5'},
    {name:'豊科',north:36.3364482797537,west:137.871902688301,south:36.2531277274805,east:137.996895090555,note:'昭和49年改測・昭和50.11.30発行',list:'89-3-1-6'},
    {name:'松本',north:36.2531244890091,west:137.871905980024,south:36.1698039203646,east:137.996898380279,note:'昭和49年改測・昭和51.2.28発行',list:'89-3-2-6'},
    {name:'信濃小倉',north:36.3364450463177,west:137.746913604095,south:36.2531244890091,east:137.871905980024,note:'昭和49年改測・昭和51.2.28発行',list:'89-3-3-4'},
    {name:'波田',north:36.2531212619237,west:137.746916884216,south:36.1698006882733,east:137.871909258211,note:'昭和49年改測・昭和50.9.30発行',list:'89-3-4-6'},
    {name:'塩尻',north:36.1698006882733,west:137.871909258211,south:36.0864800932337,east:137.996901656476,note:'昭和50年改測・昭和51.10.30発行',list:'89-4-1-5B'},
    {name:'北小野',north:36.0864768675297,west:137.871912522917,south:36.0031562660681,east:137.996904919202,note:'昭和50年改測・昭和51.11.30発行',list:'89-4-2-4'}
]});
dataset.age.push({
  folderName:'03', start:1987, end:1992, scale:'1/25000', mapList: [
    {name:'諏訪',north:36.0864800932337,west:137.996901656476,south:36.0031594966812,east:138.121894078933,note:'昭和62年修正・昭和63.9.30発行',list:'83-16-4-7B'},
    {name:'明科',north:36.4197720705237,west:137.871899382983,south:36.3364515245982,east:137.996891787246,note:'平成2年修正・平成3.5.1発行',list:'89-2-2-8'},
    {name:'有明',north:36.4197688307441,west:137.746910310426,south:36.3364482797537,east:137.871902688301,note:'平成2年修正・平成3.4.1発行',list:'89-2-4-7'},
    {name:'豊科',north:36.3364482797537,west:137.871902688301,south:36.2531277274805,east:137.996895090555,note:'昭和63年部修・平成1.3.30発行',list:'89-3-1-9B'},
    {name:'松本',north:36.2531244890091,west:137.871905980024,south:36.1698039203646,east:137.996898380279,note:'昭和63年部修・平成1.3.30発行',list:'89-3-2-9'},
    {name:'信濃小倉',north:36.3364450463177,west:137.746913604095,south:36.2531244890091,east:137.871905980024,note:'平成4年修正・平成5.10.1発行',list:'89-3-3-7'},
    {name:'波田',north:36.2531212619237,west:137.746916884216,south:36.1698006882733,east:137.871909258211,note:'平成4年修正・平成5.10.1発行',list:'89-3-4-9'},
    {name:'塩尻',north:36.1698006882733,west:137.871909258211,south:36.0864800932337,east:137.996901656476,note:'昭和63年部修・平成1.3.30発行',list:'89-4-1-7'},
    {name:'北小野',north:36.0864768675297,west:137.871912522917,south:36.0031562660681,east:137.996904919202,note:'平成4年修正・平成5.10.1発行',list:'89-4-2-6B'}
]});
dataset.age.push({
  folderName:'04', start:1996, end:2001, scale:'1/25000', mapList: [
    {name:'諏訪',north:36.0864800932337,west:137.996901656476,south:36.0031594966812,east:138.121894078933,note:'平成8年修正・平成9.11.1発行',list:'83-16-4-8B'},
    {name:'明科',north:36.4197720705237,west:137.871899382983,south:36.3364515245982,east:137.996891787246,note:'平成13年修正・平成14.6.1発行',list:'89-2-2-12'},
    {name:'有明',north:36.4197688307441,west:137.746910310426,south:36.3364482797537,east:137.871902688301,note:'平成13年修正・平成14.7.1発行',list:'89-2-4-9'},
    {name:'豊科',north:36.3364482797537,west:137.871902688301,south:36.2531277274805,east:137.996895090555,note:'平成13年修正・平成14.6.1発行',list:'89-3-1-12'},
    {name:'松本',north:36.2531244890091,west:137.871905980024,south:36.1698039203646,east:137.996898380279,note:'平成13年修正・平成14.9.1発行',list:'89-3-2-12'},
    {name:'信濃小倉',north:36.3364450463177,west:137.746913604095,south:36.2531244890091,east:137.871905980024,note:'平成13年修正・平成14.8.1発行',list:'89-3-3-8'},
    {name:'波田',north:36.2531212619237,west:137.746916884216,south:36.1698006882733,east:137.871909258211,note:'平成13年修正・平成14.10.1発行',list:'89-3-4-10B'},
    {name:'塩尻',north:36.1698006882733,west:137.871909258211,south:36.0864800932337,east:137.996901656476,note:'平成13年修正・平成15.1.1発行',list:'89-4-1-9'}
]});
kjmapDataSet['hamamatsu'] = new Object();
dataset = kjmapDataSet['hamamatsu'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1889, end:1890, scale:'1/20000', mapList: [
    {name:'北庄内村',north:34.8032820893845,west:137.59987337023,south:34.7366253905636,east:137.699867218007,note:'明治23年測図・明治25.10.29発行',list:'s2487'},
    {name:'石巻山',north:34.8032771483032,west:137.39989056285,south:34.7366204436057,east:137.499884378484,note:'明治23年測図・明治26.01.28発行',list:'s2494'},
    {name:'二川',north:34.7366179807001,west:137.399892972461,south:34.6699612753148,east:137.499886787057,note:'明治23年測図・明治26.01.28発行',list:'s2496'},
    {name:'御油',north:34.8699338453086,west:137.29989676225,south:34.8032771483032,east:137.39989056285,note:'明治23年測図・明治26.02.28発行',list:'s2499'},
    {name:'日阪村',north:34.8699512419617,west:137.999836636337,south:34.8032945654285,east:138.099830549847,note:'明治22年測量・明治24.12.25発行',list:'s799'},
    {name:'掛川町',north:34.8032920561539,west:137.9998390954,south:34.736635368855,east:138.099833007688,note:'明治22年測量・明治24.12.25発行',list:'s800'},
    {name:'中村',north:34.7366328637541,west:137.999841546374,south:34.6699761756762,east:138.099835457444,note:'明治22年測量・明治24.12.25発行',list:'s801'},
    {name:'千濱村',north:34.6699736747526,west:137.999843989284,south:34.6033169658857,east:138.09983789914,note:'明治22年測量・明治24.10.28発行',list:'s802'},
    {name:'森町',north:34.8699487355538,west:137.899845198076,south:34.8032920561539,east:137.9998390954,note:'明治23年測図',list:'s823'},
    {name:'山名町',north:34.8032895539046,west:137.899847650241,south:34.7366328637541,east:137.999841546374,note:'明治23年測図・明治25.12.28発行',list:'s824'},
    {name:'大須賀村',north:34.7366303656669,west:137.899850094339,south:34.6699736747526,east:137.999843989284,note:'明治23年測図・明治25.11.29発行',list:'s825'},
    {name:'幸浦村',north:34.6699711808309,west:137.899852530396,south:34.6033144691429,east:137.999846424157,note:'明治23年測図',list:'s826'},
    {name:'二俣町',north:34.8699462361906,west:137.799853769084,south:34.8032895539046,east:137.899847650241,note:'明治23年測図',list:'s829'},
    {name:'向笠村',north:34.8032870586882,west:137.799856214344,south:34.7366303656669,east:137.899850094339,note:'明治23年測図・明治25.12.28発行',list:'s830'},
    {name:'見附',north:34.7366278746009,west:137.799858651559,south:34.6699711808309,east:137.899852530396,note:'明治23年測図・明治25.11.29発行',list:'s831'},
    {name:'袖浦村',north:34.6699686939188,west:137.799861080756,south:34.6033119793903,east:137.89985495844,note:'明治23年測図・明治25.12.28発行',list:'s832'},
    {name:'麁玉村',north:34.8699437438795,west:137.699862349336,south:34.8032870586882,east:137.799856214344,note:'明治23年測図・明治25.11.29発行',list:'s835'},
    {name:'三方原',north:34.8032845705123,west:137.699864787682,south:34.7366278746009,east:137.799858651559,note:'明治23年測図・明治25.11.29発行',list:'s836'},
    {name:'濱松',north:34.7366253905636,west:137.699867218007,south:34.6699686939188,east:137.799861080756,note:'明治23年測図・明治25.10.29発行',list:'s837'},
    {name:'五嶋村',north:34.6699662140237,west:137.699869640337,south:34.6033094966355,east:137.799863501962,note:'明治23年測図・明治25.11.29発行',list:'s839'},
    {name:'氣賀町',north:34.8699412586282,west:137.599870938804,south:34.8032845705123,east:137.699864787682,note:'明治23年測図・明治25.12.28発行',list:'s842'},
    {name:'舞阪',north:34.7366229135628,west:137.599875793658,south:34.6649461934479,east:137.699869822437,note:'明治23年測図・明治25.11.29発行',list:'s844'},
    {name:'冨岡',north:34.8699387804443,west:137.499879537463,south:34.8032820893845,east:137.59987337023,note:'明治23年測図・明治25.11.29発行',list:'s847'},
    {name:'猪鼻湖',north:34.8032796153123,west:137.499881961962,south:34.7366229135628,east:137.599875793658,note:'明治23年測図・明治25.11.29発行',list:'s848'},
    {name:'新居',north:34.7366204436057,west:137.499884378484,south:34.6699637411532,east:137.599878209113,note:'明治23年測図・明治25.12.28発行',list:'s849'},
    {name:'吉祥山',north:34.8699363093352,west:137.399888145287,south:34.8032796153123,east:137.499881961962,note:'明治23年測図・明治25.11.29発行',list:'s852'},
    {name:'豊橋',north:34.8032746883648,west:137.29989917287,south:34.7366179807001,east:137.399892972461,note:'明治23年測図・明治26.03.31発行',list:'s861'},
    {name:'老津村',north:34.7366155248534,west:137.299901575561,south:34.6699588165161,east:137.399895374144,note:'明治23年測図・明治26.01.28発行',list:'s863'},
    {name:'蒲郡',north:34.8699313883719,west:137.199905388324,south:34.8032746883648,east:137.29989917287,note:'明治23年測図・明治26.02.28発行',list:'s868'},
    {name:'佛嶋',north:34.8032722355046,west:137.199907791995,south:34.7366155248534,east:137.299901575561,note:'明治23年測図・明治26.02.28発行',list:'s869'},
    {name:'姫嶋',north:34.7366130760731,west:137.199910187759,south:34.6699563647646,east:137.299903970347,note:'明治23年測図・明治26.02.28発行',list:'s870'}
]});
dataset.age.push({
  folderName:'00', start:1916, end:1918, scale:'1/25000', mapList: [
    {name:'八高山',north:34.919945624497,west:137.999834786716,south:34.8366247851797,east:138.124827182092,note:'大正5年測図・大正8.4.30発行',list:'85-15-4-1'},
    {name:'掛川',north:34.8366216448818,west:137.999837866882,south:34.7533007987484,east:138.12483026034,note:'大正5年測図・大正8.9.30発行',list:'85-16-3-1'},
    {name:'平田村',north:34.7532976649723,west:137.999840934387,south:34.6699768020002,east:138.124833325935,note:'大正5年測図・大正8.11.30発行',list:'85-16-4-1'},
    {name:'千浜',north:34.6699736747526,west:137.999843989284,south:34.5866527849193,east:138.124836378929,note:'大正5年測図・大正8.4.30発行',list:'86-13-3-1'},
    {name:'新城',north:34.9199300558647,west:137.37488848157,south:34.8366091937001,east:137.499880750711,note:'大正7年測図・大正10.4.30発行',list:'91-11-2-1'},
    {name:'御油',north:34.9199269753282,west:137.249899263578,south:34.8366061084812,east:137.374891507581,note:'大正7年測図・大正10.4.30発行',list:'91-11-4-1'},
    {name:'豊橋',north:34.8366061084812,west:137.374891507581,south:34.7532852396489,east:137.4998837751,note:'大正6年測図・大正8.9.30発行',list:'91-12-1-1'},
    {name:'二川',north:34.7532821608373,west:137.374894521155,south:34.6699612753148,east:137.499886787057,note:'大正6年測図・大正8.9.30発行',list:'91-12-2-1'},
    {name:'小坂井',north:34.8366030343223,west:137.249902278714,south:34.7532821608373,east:137.374894521155,note:'大正7年測図・大正10.3.30発行',list:'91-12-3-1'},
    {name:'老津',north:34.7532790930628,west:137.249905281458,south:34.6699582029173,east:137.374897522341,note:'大正7年測図・大正10.1.30発行',list:'91-12-4-1'},
    {name:'蒲郡',north:34.836599971238,west:137.124913064059,south:34.7532790933347,east:137.249916380502,note:'大正7年測図・大正9.11.30発行',list:'91-16-1-1'},
    {name:'仁崎',north:34.7532760363398,west:137.124916055959,south:34.6699551415338,east:137.249908271859,note:'大正7年測図・大正9.7.30発行',list:'91-16-2-1'},
    {name:'森',north:34.9199424886932,west:137.874845496825,south:34.8366216448818,east:137.999837866882,note:'大正6年測図・大正9.3.30発行',list:'91-3-2-1'},
    {name:'二俣',north:34.9199393639133,west:137.749856221416,south:34.8366185155701,east:137.874848566189,note:'大正6年測図・大正9.2.28発行',list:'91-3-4-1'},
    {name:'山梨',north:34.8366185155701,west:137.874848566189,south:34.7532976649723,east:137.999840934387,note:'大正6年製版・大正9.4.30発行',list:'91-4-1-1'},
    {name:'袋井',north:34.7532945421594,west:137.874851622937,south:34.6699736747526,east:137.999843989284,note:'大正6年測図・大正9.2.28発行',list:'91-4-2-1'},
    {name:'笠井',north:34.8366153972593,west:137.749859279964,south:34.7532945421594,east:137.874851622937,note:'大正6年測図・大正8.10.30発行',list:'91-4-3-9'},
    {name:'見付',north:34.7532914303247,west:137.74986232594,south:34.6699705584455,east:137.87485466712,note:'大正6年測図・大正9.2.28発行',list:'91-4-4-1'},
    {name:'伊平',north:34.919936250172,west:137.624866960438,south:34.8366153972593,east:137.749859279964,note:'大正6年測図・大正9.4.30発行',list:'91-7-2-1'},
    {name:'富岡',north:34.9199331474842,west:137.49987771384,south:34.8366122899644,east:137.624870008155,note:'大正5年測図・大正9.4.30発行',list:'91-7-4-1'},
    {name:'気賀',north:34.8366122899644,west:137.624870008155,south:34.7532914303247,east:137.74986232594,note:'大正6年測図・大正8.5.30発行',list:'91-8-1-1'},
    {name:'浜松',north:34.753288329483,west:137.624873043345,south:34.6699674530936,east:137.749865359396,note:'大正6年測図・大正9.5.30発行',list:'91-8-2-1'},
    {name:'三ヶ日',north:34.8366091937001,west:137.499880750711,south:34.753288329483,east:137.624873043345,note:'大正6年測図・大正8.12.28発行',list:'91-8-3-1'},
    {name:'新居',north:34.7532852396489,west:137.4998837751,south:34.6699643587118,east:137.624876066058,note:'大正6年測図・大正8.5.30発行',list:'91-8-4-1'},
    {name:'掛塚',north:34.6699674530936,west:137.749865359396,south:34.5866465544125,east:137.87485769879,note:'大正6年測図・大正8.4.30発行',list:'92-1-3-1'},
    {name:'新崎',north:34.6699643587118,west:137.624876066058,south:34.5866434555503,east:137.749868380382,note:'大正6年測図・大正8.3.30発行',list:'92-5-1-1'},
    {name:'高塚',north:34.6699582029173,west:137.374897522341,south:34.586637290682,east:137.499889786633,note:'大正6年測図・大正8.7.30発行',list:'92-9-1-1'}
]});
dataset.age.push({
  folderName:'01', start:1938, end:1950, scale:'1/25000', mapList: [
    {name:'八高山',north:34.919945624497,west:137.999834786716,south:34.8366247851797,east:138.124827182092,note:'昭和15年二修・昭和22.4.30発行',list:'85-15-4-3'},
    {name:'掛川',north:34.8366216448818,west:137.999837866882,south:34.7533007987484,east:138.12483026034,note:'昭和14年二修・昭和22.6.30発行',list:'85-16-3-2'},
    {name:'下平川',north:34.7532976649723,west:137.999840934387,south:34.6699768020002,east:138.124833325935,note:'昭和14年二修・昭和22.8.30発行',list:'85-16-4-3'},
    {name:'千浜',north:34.6699736747526,west:137.999843989284,south:34.5866527849193,east:138.124836378929,note:'昭和14年二修・昭和22.6.30発行',list:'86-13-3-3'},
    {name:'二川',north:34.7532821608373,west:137.374894521155,south:34.6699612753148,east:137.499886787057,note:'昭和15年二修・昭和23.4.30発行',list:'91-12-2-4'},
    {name:'老津',north:34.7532790930628,west:137.249905281458,south:34.6699582029173,east:137.374897522341,note:'昭和15年二修・昭和23.7.30発行',list:'91-12-4-4'},
    {name:'仁崎',north:34.7532760363398,west:137.124916055959,south:34.6699551415338,east:137.249908271859,note:'昭和15年二修・昭和22.8.30発行',list:'91-16-2-2'},
    {name:'森',north:34.9199424886932,west:137.874845496825,south:34.8366216448818,east:137.999837866882,note:'昭和15年二修・昭和22.5.30発行',list:'91-3-2-2'},
    {name:'二俣',north:34.9199393639133,west:137.749856221416,south:34.8366185155701,east:137.874848566189,note:'昭和15年二修・昭和22.5.30発行',list:'91-3-4-4'},
    {name:'山梨',north:34.8366185155701,west:137.874848566189,south:34.7532976649723,east:137.999840934387,note:'昭和15年部修・昭和15.10.30発行',list:'91-4-1-2'},
    {name:'袋井',north:34.7532945421594,west:137.874851622937,south:34.6699736747526,east:137.999843989284,note:'昭和13年二修・昭和15.11.30発行',list:'91-4-2-2'},
    {name:'笠井',north:34.8366153972593,west:137.749859279964,south:34.7532945421594,east:137.874851622937,note:'昭和15年部修・昭和22.6.30発行',list:'91-4-3-3'},
    {name:'中泉',north:34.7532914303247,west:137.74986232594,south:34.6699705584455,east:137.87485466712,note:'昭和14年修正・昭和22.6.30発行',list:'91-4-4-4'},
    {name:'伊平',north:34.919936250172,west:137.624866960438,south:34.8366153972593,east:137.749859279964,note:'昭和15年二修・昭和22.5.30発行',list:'91-7-2-3'},
    {name:'三河富岡',north:34.9199331474842,west:137.49987771384,south:34.8366122899644,east:137.624870008155,note:'昭和15年二修・昭和22.5.30発行',list:'91-7-4-3'},
    {name:'気賀',north:34.8366122899644,west:137.624870008155,south:34.7532914303247,east:137.74986232594,note:'昭和15年部修・昭和22.6.30発行',list:'91-8-1-4'},
    {name:'浜松',north:34.753288329483,west:137.624873043345,south:34.6699674530936,east:137.749865359396,note:'昭和14年修正25年資修・昭和25.8.30発行',list:'91-8-2-5'},
    {name:'三ヶ日',north:34.8366091937001,west:137.499880750711,south:34.753288329483,east:137.624873043345,note:'昭和13年二修・昭和15.11.30発行',list:'91-8-3-2'},
    {name:'新居町',north:34.7532852396489,west:137.4998837751,south:34.6699643587118,east:137.624876066058,note:'昭和13年二修・昭和15.12.28発行',list:'91-8-4-2',war:true},
    {name:'太田川口',north:34.6699705584455,west:137.87485466712,south:34.5866496642071,east:137.999847031623,note:'昭和13年二修・昭和15.4.30発行',list:'92-1-1-1',war:true},
    {name:'掛塚',north:34.6699674530936,west:137.749865359396,south:34.5866465544125,east:137.87485769879,note:'昭和13年二修・昭和15.6.30発行',list:'92-1-3-2'},
    {name:'新崎',north:34.6699643587118,west:137.624876066058,south:34.5866434555503,east:137.749868380382,note:'昭和13年二修・昭和22.5.30発行',list:'92-5-1-2'},
    {name:'高塚',north:34.6699582029173,west:137.374897522341,south:34.586637290682,east:137.499889786633,note:'昭和15年二修・昭和22.8.30発行',list:'92-9-1-2'}
]});
dataset.age.push({
  folderName:'02', start:1956, end:1959, scale:'1/25000', mapList: [
    {name:'八高山',north:34.919945624497,west:137.999834786716,south:34.8366247851797,east:138.124827182092,note:'昭和31年三修・昭和33.11.30発行',list:'85-15-4-4'},
    {name:'掛川',north:34.8366216448818,west:137.999837866882,south:34.7533007987484,east:138.12483026034,note:'昭和31年三修・昭和33.4.10発行',list:'85-16-3-4'},
    {name:'下平川',north:34.7532976649723,west:137.999840934387,south:34.6699768020002,east:138.124833325935,note:'昭和31年三修・昭和33.2.28発行',list:'85-16-4-6'},
    {name:'千浜',north:34.6699736747526,west:137.999843989284,south:34.5866527849193,east:138.124836378929,note:'昭和31年二修・昭和32.10.30発行',list:'86-13-3-4'},
    {name:'新城',north:34.9199299845446,west:137.371999830594,south:34.8366091222723,east:137.496992099154,note:'昭和33年三修・昭和35.5.30発行',list:'91-11-2-5'},
    {name:'御油',north:34.9199269042644,west:137.247010612931,south:34.8366060373088,east:137.372002856354,note:'昭和33年三修34年資修・昭和35.6.30発行',list:'91-11-4-5'},
    {name:'豊橋',north:34.8366060373088,west:137.372002856354,south:34.7532851683694,east:137.496995123293,note:'昭和33年三修・昭和35.6.30発行',list:'91-12-1-7'},
    {name:'二川',north:34.7532820898127,west:137.372005869678,south:34.6699612041838,east:137.496998135001,note:'昭和33年三修・昭和35.6.30発行',list:'91-12-2-6'},
    {name:'小坂井',north:34.8366029634056,west:137.247013627817,south:34.7532820898127,east:137.372005869678,note:'昭和33年三修・昭和35.6.30発行',list:'91-12-3-9'},
    {name:'老津',north:34.7532790222934,west:137.24701663031,south:34.6699581320406,east:137.372008870615,note:'昭和33年三修・昭和35.6.30発行',list:'91-12-4-6'},
    {name:'蒲郡',north:34.8365999005775,west:137.122024413489,south:34.7532790222934,east:137.24701663031,note:'昭和33年修正・昭和35.6.30発行',list:'91-16-1-4'},
    {name:'仁崎',north:34.7532759658261,west:137.122027405138,south:34.6699550709119,east:137.247019620461,note:'昭和33年三修・昭和35.4.30発行',list:'91-16-2-3'},
    {name:'森',north:34.9199424886932,west:137.874845496825,south:34.8366216448818,east:137.999837866882,note:'昭和31年三修・昭和33.4.30発行',list:'91-3-2-3'},
    {name:'二俣',north:34.9199392918263,west:137.746967569445,south:34.8366185155701,east:137.874848566189,note:'昭和32年三修34年資修・昭和34.7.30発行',list:'91-3-4-6B'},
    {name:'山梨',north:34.8366185155701,west:137.874848566189,south:34.7532976649723,east:137.999840934387,note:'昭和31年三修・昭和33.12.28発行',list:'91-4-1-4'},
    {name:'袋井',north:34.7532945421594,west:137.874851622937,south:34.6699736747526,east:137.999843989284,note:'昭和31年三修・昭和33.12.28発行',list:'91-4-2-5'},
    {name:'笠井',north:34.8366153253216,west:137.746970627743,south:34.7532945421594,east:137.874851622937,note:'昭和32年三修・昭和34.4.30発行',list:'91-4-3-4'},
    {name:'磐田',north:34.7532913585364,west:137.74697367347,south:34.6699705584455,east:137.87485466712,note:'昭和32年三修・昭和34.8.30発行',list:'91-4-4-7'},
    {name:'伊平',north:34.9199361783403,west:137.6219783088,south:34.8366153253216,east:137.746970627743,note:'昭和32年三修・昭和34.7.30発行',list:'91-7-2-4B'},
    {name:'三河富岡',north:34.9199330759082,west:137.496989062534,south:34.8366122182814,east:137.621981356266,note:'昭和32年三修・昭和34.6.30発行',list:'91-7-4-5'},
    {name:'気賀',north:34.8366122182814,west:137.621981356266,south:34.7532913585364,east:137.74697367347,note:'昭和32年三修・昭和34.8.30発行',list:'91-8-1-6'},
    {name:'浜松',north:34.7532882579489,west:137.621984391207,south:34.6699673814548,east:137.746976706677,note:'昭和32年三修・昭和34.7.30発行',list:'91-8-2-7'},
    {name:'三ヶ日',north:34.8366091222723,west:137.496992099154,south:34.7532882579489,east:137.621984391207,note:'昭和32年三修・昭和34.6.30発行',list:'91-8-3-4'},
    {name:'新居町',north:34.7532851683694,west:137.496995123293,south:34.6699642873268,east:137.621987413672,note:'昭和32年三修・昭和34.4.30発行',list:'91-8-4-4'},
    {name:'太田川口',north:34.6699705584455,west:137.87485466712,south:34.5866496642071,east:137.999847031623,note:'昭和31年三修・昭和33.4.10発行',list:'92-1-1-3B'},
    {name:'掛塚',north:34.6699673814548,west:137.746976706677,south:34.5866465544125,east:137.87485769879,note:'昭和32年三修・昭和34.3.30発行',list:'92-1-3-6'},
    {name:'中田島',north:34.6699642873268,west:137.621987413672,south:34.5866433840613,east:137.746979727416,note:'昭和32年三修・昭和34.4.30発行',list:'92-5-1-3'},
    {name:'高塚',north:34.6699581320406,west:137.372008870615,south:34.5866372196996,east:137.497001134329,note:'昭和33年三修・昭和35.4.30発行',list:'92-9-1-3'}
]});
dataset.age.push({
  folderName:'03', start:1975, end:1988, scale:'1/25000', mapList: [
    {name:'八高山',north:34.9199455519005,west:137.996946134075,south:34.8366247124797,east:138.121938528866,note:'昭和50年修正・昭和51.10.30発行',list:'85-15-4-6'},
    {name:'八高山',north:34.9199455519005,west:137.996946134075,south:34.8366247124797,east:138.121938528866,note:'昭和63年修正・平成1.2.28発行',list:'85-15-4-8'},
    {name:'掛川',north:34.8366215724356,west:137.996949213992,south:34.7533007261995,east:138.121941606866,note:'昭和54年修正・昭和55.8.30発行',list:'85-16-3-7'},
    {name:'下平川',north:34.7532975926765,west:137.996952281249,south:34.6699767296024,east:138.121944672214,note:'昭和54年修正・昭和55.9.30発行',list:'85-16-4-8'},
    {name:'千浜',north:34.6699736026074,west:137.996955335898,south:34.5866527126727,east:138.121947724962,note:'昭和54年修正・昭和55.7.30発行',list:'86-13-3-7'},
    {name:'新城',north:34.9199299845446,west:137.371999830594,south:34.8366091222723,east:137.496992099154,note:'昭和53年修正・昭和54.11.30発行',list:'91-11-2-8'},
    {name:'御油',north:34.9199269042644,west:137.247010612931,south:34.8366060373088,east:137.372002856354,note:'昭和53年修正・昭和55.8.30発行',list:'91-11-4-8'},
    {name:'豊橋',north:34.8366060373088,west:137.372002856354,south:34.7532851683694,east:137.496995123293,note:'昭和53年修正・昭和55.4.30発行',list:'91-12-1-11'},
    {name:'二川',north:34.7532820898127,west:137.372005869678,south:34.6699612041838,east:137.496998135001,note:'昭和53年修正・昭和54.12.28発行',list:'91-12-2-10'},
    {name:'小坂井',north:34.8366029634056,west:137.247013627817,south:34.7532820898127,east:137.372005869678,note:'昭和53年修正・昭和54.12.28発行',list:'91-12-3-13'},
    {name:'老津',north:34.7532790222934,west:137.24701663031,south:34.6699581320406,east:137.372008870615,note:'昭和53年修正・昭和55.4.30発行',list:'91-12-4-10'},
    {name:'蒲郡',north:34.8365999005775,west:137.122024413489,south:34.7532790222934,east:137.24701663031,note:'昭和53年修正・昭和55.8.30発行',list:'91-16-1-8'},
    {name:'仁崎',north:34.7532759658261,west:137.122027405138,south:34.6699550709119,east:137.247019620461,note:'昭和53年修正・昭和55.8.30発行',list:'91-16-2-7'},
    {name:'森',north:34.9199424163513,west:137.87195684452,south:34.8366215724356,east:137.996949213992,note:'昭和50年修正・昭和51.12.28発行',list:'91-3-2-5'},
    {name:'二俣',north:34.9199392918263,west:137.746967569445,south:34.8366184433779,east:137.871959913634,note:'昭和50年修正・昭和51.5.30発行',list:'91-3-4-8'},
    {name:'山梨',north:34.8366184433779,west:137.871959913634,south:34.7532975926765,east:137.996952281249,note:'昭和54年修正・昭和56.1.30発行',list:'91-4-1-7'},
    {name:'袋井',north:34.7532944701172,west:137.871962970133,south:34.6699736026074,east:137.996955335898,note:'昭和54年修正・昭和55.10.30発行',list:'91-4-2-8'},
    {name:'笠井',north:34.8366153253216,west:137.746970627743,south:34.7532944701172,east:137.871962970133,note:'昭和54年修正・昭和56.9.30発行',list:'91-4-3-7'},
    {name:'磐田',north:34.7532913585364,west:137.74697367347,south:34.6699704865533,east:137.871966014069,note:'昭和54年修正・昭和56.2.28発行',list:'91-4-4-10'},
    {name:'伊平',north:34.9199361783403,west:137.6219783088,south:34.8366153253216,east:137.746970627743,note:'昭和50年修正・昭和52.3.30発行',list:'91-7-2-6'},
    {name:'三河富岡',north:34.9199330759082,west:137.496989062534,south:34.8366122182814,east:137.621981356266,note:'昭和50年修正・昭和52.5.30発行',list:'91-7-4-7'},
    {name:'気賀',north:34.8366122182814,west:137.621981356266,south:34.7532913585364,east:137.74697367347,note:'昭和54年修正・昭和56.2.28発行',list:'91-8-1-9'},
    {name:'浜松',north:34.7532882579489,west:137.621984391207,south:34.6699673814548,east:137.746976706677,note:'昭和54年修正・昭和55.10.30発行',list:'91-8-2-10'},
    {name:'三ヶ日',north:34.8366091222723,west:137.496992099154,south:34.7532882579489,east:137.621984391207,note:'昭和54年修正・昭和55.12.28発行',list:'91-8-3-7'},
    {name:'新居町',north:34.7532851683694,west:137.496995123293,south:34.6699642873268,east:137.621987413672,note:'昭和54年修正・昭和55.11.30発行',list:'91-8-4-7'},
    {name:'向岡',north:34.6699704865533,west:137.871966014069,south:34.5866495922127,east:137.99695837799,note:'昭和54年修正・昭和55.10.30発行',list:'92-1-1-6'},
    {name:'掛塚',north:34.6699673814548,west:137.746976706677,south:34.5866464826706,east:137.871969045492,note:'昭和54年修正・昭和55.8.30発行',list:'92-1-3-9'},
    {name:'中田島',north:34.6699642873268,west:137.621987413672,south:34.5866433840613,east:137.746979727416,note:'昭和54年修正・昭和55.10.30発行',list:'92-5-1-6'},
    {name:'高塚',north:34.6699581320406,west:137.372008870615,south:34.5866372196996,east:137.497001134329,note:'昭和53年修正・昭和55.1.30発行',list:'92-9-1-6'}
]});
dataset.age.push({
  folderName:'04', start:1988, end:1995, scale:'1/25000', mapList: [
    {name:'八高山',north:34.9199455519005,west:137.996946134075,south:34.8366247124797,east:138.121938528866,note:'昭和63年修正・平成1.2.28発行',list:''},
    {name:'掛川',north:34.8366215724356,west:137.996949213992,south:34.7533007261995,east:138.121941606866,note:'昭和63年修正・平成1.10.1発行',list:'85-16-3-9'},
    {name:'下平川',north:34.7532975926765,west:137.996952281249,south:34.6699767296024,east:138.121944672214,note:'昭和63年修正・平成1.10.1発行',list:'85-16-4-10'},
    {name:'千浜',north:34.6699736026074,west:137.996955335898,south:34.5866527126727,east:138.121947724962,note:'昭和63年修正・平成2.2.1発行',list:'86-13-3-9B'},
    {name:'新城',north:34.9199299845446,west:137.371999830594,south:34.8366091222723,east:137.496992099154,note:'平成7年修正・平成8.10.1発行',list:'91-11-2-10'},
    {name:'御油',north:34.9199269042644,west:137.247010612931,south:34.8366060373088,east:137.372002856354,note:'平成7年修正・平成8.5.1発行',list:'91-11-4-11'},
    {name:'豊橋',north:34.8366060373088,west:137.372002856354,south:34.7532851683694,east:137.496995123293,note:'平成5年修正・平成6.6.1発行',list:'91-12-1-14'},
    {name:'二川',north:34.7532820898127,west:137.372005869678,south:34.6570339783608,east:137.496998601139,note:'平成5年修正・平成6.8.1発行',list:'91-12-2-13'},
    {name:'小坂井',north:34.8366029634056,west:137.247013627817,south:34.7532820898127,east:137.372005869678,note:'平成5年修正・平成6.6.1発行',list:'91-12-3-16'},
    {name:'老津',north:34.7532783570808,west:137.219852306233,south:34.6699581320406,east:137.372008870615,note:'平成5年修正・平成6.8.1発行',list:'91-12-4-13B'},
    {name:'蒲郡',north:34.8365999005775,west:137.122024413489,south:34.7532790222934,east:137.24701663031,note:'平成5年修正・平成6.6.1発行',list:'91-16-1-11'},
    {name:'森',north:34.9199424163513,west:137.87195684452,south:34.8366215724356,east:137.996949213992,note:'平成1年修正・平成2.8.1発行',list:'91-3-2-7'},
    {name:'二俣',north:34.9199392918263,west:137.746967569445,south:34.8366184433779,east:137.871959913634,note:'平成1年修正・平成2.11.1発行',list:'91-3-4-9'},
    {name:'山梨',north:34.8366184433779,west:137.871959913634,south:34.7532975926765,east:137.996952281249,note:'平成2年修正・平成3.11.1発行',list:'91-4-1-9'},
    {name:'袋井',north:34.7532944701172,west:137.871962970133,south:34.6588294397052,east:137.996955743489,note:'平成2年修正・平成3.11.1発行',list:'91-4-2-10'},
    {name:'笠井',north:34.8366153253216,west:137.746970627743,south:34.7532944701172,east:137.871962970133,note:'平成2年修正・平成3.6.1発行',list:'91-4-3-10'},
    {name:'磐田',north:34.7532913585364,west:137.74697367347,south:34.6699704865533,east:137.871966014069,note:'平成2年修正・平成3.6.1発行',list:'91-4-4-12'},
    {name:'伊平',north:34.9199361783403,west:137.6219783088,south:34.8366153253216,east:137.746970627743,note:'平成1年修正・平成2.11.1発行',list:'91-7-2-7'},
    {name:'三河富岡',north:34.9199330759082,west:137.496989062534,south:34.8366122182814,east:137.621981356266,note:'平成1年修正・平成2.8.1発行',list:'91-7-4-8'},
    {name:'気賀',north:34.8366122182814,west:137.621981356266,south:34.7532913585364,east:137.74697367347,note:'平成2年修正・平成3.4.1発行',list:'91-8-1-11'},
    {name:'浜松',north:34.7532882579489,west:137.621984391207,south:34.6552913781407,east:137.746977239629,note:'平成2年修正・平成3.5.1発行',list:'91-8-2-12'},
    {name:'三ヶ日',north:34.8366091222723,west:137.496992099154,south:34.7532882579489,east:137.621984391207,note:'平成2年修正・平成3.4.1発行',list:'91-8-3-9'},
    {name:'新居町',north:34.7532851683694,west:137.496995123293,south:34.6699642873268,east:137.621987413672,note:'平成2年修正・平成3.4.1発行',list:'91-8-4-9'},
    {name:'掛塚',north:34.6699673814548,west:137.746976706677,south:34.5866464826706,east:137.871969045492,note:'平成2年修正・平成3.10.1発行',list:'92-1-3-11'}
]});
dataset.age.push({
  folderName:'05', start:1996, end:2010, scale:'1/25000', mapList: [
    {name:'八高山',north:34.9199455519005,west:137.996946134075,south:34.8366247124797,east:138.121938528866,note:'平成11年部修・平成12.4.1発行',list:'85-15-4-10'},
    {name:'掛川',north:34.8366215724356,west:137.996949213992,south:34.7533007261995,east:138.121941606866,note:'平成8年修正・平成9.11.1発行',list:'85-16-3-10C'},
    {name:'下平川',north:34.7532975926765,west:137.996952281249,south:34.6699767296024,east:138.121944672214,note:'平成8年修正・平成9.12.1発行',list:'85-16-4-11B'},
    {name:'千浜',north:34.6699736026074,west:137.996955335898,south:34.5866527126727,east:138.121947724962,note:'平成18年更新・平成18.8.1発行',list:'86-13-3-12'},
    {name:'新城',north:34.9199299845446,west:137.371999830594,south:34.8366091222723,east:137.496992099154,note:'平成13年修正・平成14.4.1発行',list:'91-11-2-11'},
    {name:'御油',north:34.9199269042644,west:137.247010612931,south:34.8366060373088,east:137.372002856354,note:'平成13年修正・平成15.3.1発行',list:'91-11-4-12'},
    {name:'豊橋',north:34.8366060373088,west:137.372002856354,south:34.7532851683694,east:137.496995123293,note:'平成19年更新・平成21.4.1発行',list:'91-12-1-17'},
    {name:'二川',north:34.7532820898127,west:137.372005869678,south:34.6614230619722,east:137.496998442908,note:'平成19年更新・平成20.11.1発行',list:'91-12-2-16'},
    {name:'小坂井',north:34.8366029634056,west:137.247013627817,south:34.7532820898127,east:137.372005869678,note:'平成19年更新・平成21.10.1発行',list:'91-12-3-20'},
    {name:'老津',north:34.7532790222934,west:137.24701663031,south:34.6699581320406,east:137.372008870615,note:'平成22年更新・平成23.1.1発行',list:'91-12-4-16'},
    {name:'蒲郡',north:34.8365999005775,west:137.122024413489,south:34.7532790222934,east:137.24701663031,note:'平成19年更新・平成21.7.1発行',list:'91-16-1-14'},
    {name:'仁崎',north:34.7532759658261,west:137.122027405138,south:34.6699550709119,east:137.247019620461,note:'平成19年更新・平成20.11.1発行',list:'91-16-2-10'},
    {name:'森',north:34.9199424163513,west:137.87195684452,south:34.8366215724356,east:137.996949213992,note:'平成19年更新・平成19.4.1発行',list:'91-3-2-10'},
    {name:'二俣',north:34.9199392918263,west:137.746967569445,south:34.8366184433779,east:137.871959913634,note:'平成19年更新・平成19.4.1発行',list:'91-3-4-11'},
    {name:'山梨',north:34.8366184433779,west:137.871959913634,south:34.7532975926765,east:137.996952281249,note:'平成19年更新・平成20.6.1発行',list:'91-4-1-13'},
    {name:'袋井',north:34.7532944701172,west:137.871962970133,south:34.6599610039927,east:137.996955702113,note:'平成19年更新・平成20.2.1発行',list:'91-4-2-14'},
    {name:'笠井',north:34.8366153253216,west:137.746970627743,south:34.7532944701172,east:137.871962970133,note:'平成19年更新・平成19.4.1発行',list:'91-4-3-12'},
    {name:'磐田',north:34.7532913585364,west:137.74697367347,south:34.6699704865533,east:137.871966014069,note:'平成19年更新・平成19.4.1発行',list:'91-4-4-15B'},
    {name:'伊平',north:34.9199361783403,west:137.6219783088,south:34.8366153253216,east:137.746970627743,note:'平成19年更新・平成19.4.1発行',list:'91-7-2-10'},
    {name:'三河富岡',north:34.9199330759082,west:137.496989062534,south:34.8366122182814,east:137.621981356266,note:'平成19年更新・平成19.4.1発行',list:'91-7-4-10'},
    {name:'気賀',north:34.8366122182814,west:137.621981356266,south:34.7501709902232,east:137.746973787284,note:'平成19年更新・平成19.4.1発行',list:'91-8-1-14'},
    {name:'浜松',north:34.7500307340441,west:137.621984509603,south:34.655599986853,east:137.746977228426,note:'平成19年更新・平成19.4.1発行',list:'91-8-2-15B'},
    {name:'三ヶ日',north:34.8366091222723,west:137.496992099154,south:34.7532882579489,east:137.621984391207,note:'平成19年更新・平成19.4.1発行',list:'91-8-3-12'},
    {name:'新居町',north:34.7532851683694,west:137.496995123293,south:34.6699642873268,east:137.621987413672,note:'平成19年更新・平成19.4.1発行',list:'91-8-4-13'},
    {name:'掛塚',north:34.6699673814548,west:137.746976706677,south:34.5866464826706,east:137.871969045492,note:'平成19年更新・平成19.4.1発行',list:'92-1-3-12'}
]});
kjmapDataSet['tsu'] = new Object();
dataset = kjmapDataSet['tsu'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1892, end:1898, scale:'1/20000', mapList: [
    {name:'大淀村',north:34.6032802521339,west:136.599966735414,south:34.5366234914292,east:136.699960420849,note:'明治25年測図・明治29.9.1発行',list:'jk2582'},
    {name:'矢野村',north:34.66993700534,west:136.499973065018,south:34.6032802521339,east:136.599966735414,note:'明治25年測図・明治27.3.28発行',list:'jk2584'},
    {name:'上野村',north:34.8032552642958,west:136.499968378596,south:34.7365985322012,east:136.599962050523,note:'明治31年修正・明治31.7.30発行',list:'jk2590'},
    {name:'津',north:34.7365961330931,west:136.499970725668,south:34.6699394004476,east:136.599964396828,note:'明治31年修正・明治31.9.30発行',list:'jk2591'},
    {name:'田丸町',north:34.5366210972502,west:136.599969066306,south:34.4699643359433,east:136.69996275095,note:'明治31年修正・明治31.12.25発行',list:'s1002'},
    {name:'松阪',north:34.6032778610301,west:136.499975396673,south:34.5366210972502,east:136.599969066306,note:'明治31年修正・明治31.12.25発行',list:'s1004'},
    {name:'龜山',north:34.8699119890082,west:136.399974721802,south:34.8032552642958,east:136.499968378596,note:'明治25年測図・明治27.10.29発行',list:'s1013'},
    {name:'高野尾村',north:34.8032528683278,west:136.399977069613,south:34.7365961330931,east:136.499970725668,note:'明治25年測図・明治27.7.28発行',list:'s1014'},
    {name:'久居町',north:34.7365937411103,west:136.3999794097,south:34.66993700534,east:136.499973065018,note:'明治31年修正・明治31.12.25発行',list:'s1016'},
    {name:'髙岡村',north:34.6699346173459,west:136.399981742088,south:34.6032778610301,east:136.499975396673,note:'明治25年測図・明治27.6.29発行',list:'s1018'},
    {name:'伊勢寺村',north:34.603275477028,west:136.399984066804,south:34.5366187101537,east:136.499977720656,note:'明治25年測図・明治29.3.30発行',list:'s1135'},
    {name:'有瀧',north:34.6032826503319,west:136.699958083055,south:34.5366258926833,east:136.79995178431,note:'明治25年測図・大正7.6.30発行',list:'s997'},
    {name:'山田',north:34.5366234914292,west:136.699960420849,south:34.4699667331631,east:136.799954121283,note:'明治25年測図・大正7.6.30発行',list:'s998'},
    {name:'朝熊山',north:34.4699643359433,west:136.69996275095,south:34.40330755705,east:136.799956450567,note:'明治25年測図・大正7.6.30発行',list:'s999'}
]});
dataset.age.push({
  folderName:'00', start:1920, end:1920, scale:'1/25000', mapList: [
    {name:'龜山',north:34.9199057231198,west:136.374975133073,south:34.8365848224445,east:136.499967202157,note:'大正9年測図・大正13.11.30発行',list:'96-11-2-1'},
    {name:'椋本',north:34.8365818261123,west:136.374978071691,south:34.7532609190071,east:136.499970139625,note:'大正9年測図・大正13.6.30発行',list:'96-12-1-1'},
    {name:'久居',north:34.7532579288976,west:136.37498099823,south:34.66993700534,east:136.499973065018,note:'大正9年測図・大正13.10.30発行',list:'96-12-2-1'},
    {name:'白子',north:34.8365848224445,west:136.499967202157,south:34.7532639202547,east:136.624959294908,note:'大正9年測図・大正11.9.30発行',list:'96-8-3-1'},
    {name:'津',north:34.7532609190071,west:136.499970139625,south:34.6699400003351,east:136.624962231171,note:'大正9年測図・大正11.5.30発行',list:'96-8-4-1'},
    {name:'明野ヶ原',north:34.5866160601634,west:136.624965155365,south:34.503295113245,east:136.749957269193,note:'大正9年測図・大正12.4.30発行',list:'97-5-2-1'},
    {name:'大口',north:34.66993700534,west:136.499973065018,south:34.5866160601634,east:136.624965155365,note:'大正9年測図・大正11.11.30発行',list:'97-5-3-1'},
    {name:'松阪',north:34.5866130714272,west:136.499975978387,south:34.5032921197202,east:136.624968067536,note:'大正9年測図・大正13.12.28発行',list:'97-5-4-1'},
    {name:'山田',north:34.5032921197202,west:136.624968067536,south:34.4199711562194,east:136.749960180115,note:'大正9年測図・大正13.10.30発行',list:'97-6-1-1'},
    {name:'大仰',north:34.6699340214597,west:136.37498391274,south:34.5866130714272,east:136.499975978387,note:'大正9年測図・大正13.11.30発行',list:'97-9-1-1'}
]});
dataset.age.push({
  folderName:'01', start:1937, end:1937, scale:'1/25000', mapList: [
    {name:'龜山',north:34.9199057231198,west:136.374975133073,south:34.8365848224445,east:136.499967202157,note:'昭和12年二修・昭和22.9.30発行',list:'96-11-2-2'},
    {name:'椋本',north:34.8365818261123,west:136.374978071691,south:34.7532609190071,east:136.499970139625,note:'昭和12年二修・昭和22.8.30発行',list:'96-12-1-2'},
    {name:'津西部',north:34.7532579288976,west:136.37498099823,south:34.66993700534,east:136.499973065018,note:'昭和12年二修',list:'96-12-2-5'},
    {name:'白子',north:34.8365848224445,west:136.499967202157,south:34.7532639202547,east:136.624959294908,note:'昭和12年二修・昭和13.2.28発行',list:'96-8-3-13'},
    {name:'津東部',north:34.7532609190071,west:136.499970139625,south:34.6699400003351,east:136.624962231171,note:'昭和12年二修・昭和22.9.28発行',list:'96-8-4-4'},
    {name:'明野',north:34.5866160601634,west:136.624965155365,south:34.503295113245,east:136.749957269193,note:'昭和12年二修・昭和14.8.30発行',list:'97-5-2-3',war:true},
    {name:'松阪港',north:34.66993700534,west:136.499973065018,south:34.5866160601634,east:136.624965155365,note:'昭和12年二修・昭和12.12.28発行',list:'97-5-3-14'},
    {name:'松阪',north:34.5866130714272,west:136.499975978387,south:34.5032921197202,east:136.624968067536,note:'昭和12年二修・昭和14.8.30発行',list:'97-5-4-4'},
    {name:'宇治山田',north:34.5032921197202,west:136.624968067536,south:34.4199711562194,east:136.749960180115,note:'昭和12年二修・昭和15.7.30発行',list:'97-6-1-5',war:true},
    {name:'大仰',north:34.6699340214597,west:136.37498391274,south:34.5866130714272,east:136.499975978387,note:'昭和12年二修・昭和22.9.28発行',list:'97-9-1-5'}
]});
dataset.age.push({
  folderName:'02', start:1959, end:1959, scale:'1/25000', mapList: [
    {name:'亀山',north:34.9199056538596,west:136.372086484699,south:34.8365847530697,east:136.497078553208,note:'昭和34年三修・昭和39.11.30発行',list:'96-11-2-4'},
    {name:'椋本',north:34.8365817569955,west:136.372089423063,south:34.7532608497763,east:136.497081490424,note:'昭和34年三修・昭和40.5.30発行',list:'96-12-1-4'},
    {name:'津西部',north:34.7532578599244,west:136.372092349349,south:34.6699369362534,east:136.497084415566,note:'昭和34年三修・昭和40.5.30発行',list:'96-12-2-8'},
    {name:'白子',north:34.8365847530697,west:136.497078553208,south:34.7532638507667,east:136.622070645385,note:'昭和34年三修・昭和40.5.30発行',list:'96-8-3-4'},
    {name:'津東部',north:34.7532608497763,west:136.497081490424,south:34.6699399309918,east:136.622073581397,note:'昭和34年三修・昭和37.9.30発行',list:'96-8-4-5'},
    {name:'明野',north:34.586615990965,west:136.622076505341,south:34.5032950439364,east:136.747068618599,note:'昭和34年三修・昭和40.5.30発行',list:'97-5-2-8'},
    {name:'松阪港',north:34.6699369362534,west:136.497084415566,south:34.586615990965,east:136.622076505341,note:'昭和34年三修・昭和40.5.30発行',list:'97-5-3-11'},
    {name:'松阪',north:34.586613002485,west:136.497087328684,south:34.5032920506669,east:136.622079417264,note:'昭和34年三修・昭和40.5.30発行',list:'97-5-4-7'},
    {name:'伊勢',north:34.5032920506669,west:136.622079417264,south:34.4199710870565,east:136.747071529272,note:'昭和34年三修・昭和40.5.30発行',list:'97-6-1-8'},
    {name:'大仰',north:34.6699339526302,west:136.372095263608,south:34.586613002485,east:136.497087328684,note:'昭和34年三修・昭和40.5.30発行',list:'97-9-1-7'}
]});
dataset.age.push({
  folderName:'03', start:1980, end:1982, scale:'1/25000', mapList: [
    {name:'亀山',north:34.9199056538596,west:136.372086484699,south:34.8365847530697,east:136.497078553208,note:'昭和55年修正・昭和57.4.30発行',list:'96-11-2-8B'},
    {name:'椋本',north:34.8365817569955,west:136.372089423063,south:34.7532608497763,east:136.497081490424,note:'昭和55年修正・昭和56.12.28発行',list:'96-12-1-8'},
    {name:'津西部',north:34.7532578599244,west:136.372092349349,south:34.6699369362534,east:136.497084415566,note:'昭和55年修正・昭和57.2.28発行',list:'96-12-2-12'},
    {name:'白子',north:34.8365847530697,west:136.497078553208,south:34.7532638507667,east:136.622070645385,note:'昭和55年修正・昭和56.12.28発行',list:'96-8-3-8'},
    {name:'津東部',north:34.7532608497763,west:136.497081490424,south:34.6699399309918,east:136.622073581397,note:'昭和55年修正・昭和57.4.30発行',list:'96-8-4-10'},
    {name:'明野',north:34.586615990965,west:136.622076505341,south:34.5032950439364,east:136.747068618599,note:'昭和55年修正・昭和57.4.30発行',list:'97-5-2-13'},
    {name:'松阪港',north:34.6699369362534,west:136.497084415566,south:34.586615990965,east:136.622076505341,note:'昭和55年修正・昭和57.11.30発行',list:'97-5-3-10'},
    {name:'松阪',north:34.586613002485,west:136.497087328684,south:34.5032920506669,east:136.622079417264,note:'昭和55年修正・昭和57.1.30発行',list:'97-5-4-11'},
    {name:'伊勢',north:34.5032920506669,west:136.622079417264,south:34.4199710870565,east:136.747071529272,note:'昭和57年修正・昭和59.1.30発行',list:'97-6-1-13C'},
    {name:'大仰',north:34.6699339526302,west:136.372095263608,south:34.586613002485,east:136.497087328684,note:'昭和55年修正・昭和57.1.30発行',list:'97-9-1-10'}
]});
dataset.age.push({
  folderName:'04', start:1991, end:1999, scale:'1/25000', mapList: [
    {name:'亀山',north:34.9199056538596,west:136.372086484699,south:34.8365847530697,east:136.497078553208,note:'平成11年修正・平成12.12.1発行',list:'96-11-2-11B'},
    {name:'椋本',north:34.8365817569955,west:136.372089423063,south:34.7532608497763,east:136.497081490424,note:'平成6年修正・平成7.12.1発行',list:'96-12-1-10C'},
    {name:'津西部',north:34.7532578599244,west:136.372092349349,south:34.6699369362534,east:136.497084415566,note:'平成6年修正・平成7.5.1発行',list:'96-12-2-15B'},
    {name:'白子',north:34.8365847530697,west:136.497078553208,south:34.7532638507667,east:136.622070645385,note:'平成11年修正・平成13.1.1発行',list:'96-8-3-12'},
    {name:'津東部',north:34.7532608497763,west:136.497081490424,south:34.6699399309918,east:136.622073581397,note:'平成11年修正・平成12.6.1発行',list:'96-8-4-13B'},
    {name:'明野',north:34.586615990965,west:136.622076505341,south:34.5032950439364,east:136.747068618599,note:'平成9年修正・平成10.10.1発行',list:'97-5-2-16B'},
    {name:'松阪港',north:34.6699369362534,west:136.497084415566,south:34.586615990965,east:136.651472961796,note:'平成3年修正・平成4.6.1発行',list:'97-5-3-13B'},
    {name:'松阪',north:34.586613002485,west:136.497087328684,south:34.5032920506669,east:136.622079417264,note:'平成11年部修・平成12.4.1発行',list:'97-5-4-15B'},
    {name:'伊勢',north:34.5032920506669,west:136.622079417264,south:34.4199710870565,east:136.747071529272,note:'平成9年修正・平成10.11.1発行',list:'97-6-1-16B'},
    {name:'大仰',north:34.6699339526302,west:136.372095263608,south:34.586613002485,east:136.497087328684,note:'平成10年修正・平成11.10.1発行',list:'97-9-1-14B'}
]});
kjmapDataSet['himeji'] = new Object();
dataset = kjmapDataSet['himeji'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1903, end:1910, scale:'1/20000', mapList: [
    {name:'北條',north:34.9365336101061,west:134.800112836959,south:34.8698768525733,east:134.900106242239,note:'明治36年修正・明治29.11.30発行',list:'s1275'},
    {name:'志方',north:34.8698745679885,west:134.800115079062,south:34.8032177901903,east:134.900108484087,note:'明治36年修正・明治29.7.30発行',list:'s1278'},
    {name:'二見村',north:34.7365564443189,west:134.800119541168,south:34.6698996559506,east:134.900112945682,note:'明治36年修正・明治29.7.30発行',list:'s1283'},
    {name:'溝口',north:34.9365313290164,west:134.700121689379,south:34.8698745679885,east:134.800115079062,note:'明治36年修正・明治39.11.30発行',list:'s1285'},
    {name:'御着',north:34.8698722906741,west:134.700123924333,south:34.8032155093961,east:134.800117313791,note:'明治36年修正・明治31.9.30発行',list:'s1287'},
    {name:'曾根',north:34.8032132358601,west:134.700126151935,south:34.7365564443189,east:134.800119541168,note:'明治36年修正・明治29.9.30発行',list:'s1289'},
    {name:'書冩',north:34.9365290552161,west:134.600130550227,south:34.8698722906741,east:134.700123924333,note:'明治36年修正・明治39.11.30発行',list:'s1292'},
    {name:'姫路',north:34.869870020637,west:134.600132778024,south:34.8032132358601,east:134.700126151935,note:'明治36年修正・明治40.2.28発行',list:'s1293'},
    {name:'飾磨',north:34.8032109695894,west:134.600134998493,south:34.7365541745646,east:134.700128372209,note:'明治36年修正・明治31.9.30発行',list:'s1295'},
    {name:'林田',north:34.9365267887121,west:134.500139419475,south:34.869870020637,east:134.600132778024,note:'明治36年修正・明治30.10.30発行',list:'s1299'},
    {name:'網干',north:34.8032087105909,west:134.500143853438,south:34.7365519120634,east:134.600137211658,note:'明治36年修正・明治30.12.25発行',list:'s1303'},
    {name:'大久保町',north:34.7365587213194,west:134.90011071856,south:34.6699019363814,east:135.000104138601,note:'明治36年修正・明治31.9.30発行',list:'s1641'},
    {name:'明石',north:34.6698996559506,west:134.900112945682,south:34.603242850696,east:135.000106365439,note:'明治36年修正・明治31.3.30発行',list:'s1642'},
    {name:'天神',north:34.8698791444215,west:135.00009741389,south:34.803222373526,east:135.100090850108,note:'明治43年測図・大正2.3.30発行',list:'s2015'},
    {name:'淡河町',north:34.803220078236,west:135.00009966285,south:34.7365632970315,east:135.100093098753,note:'明治43年測図・大正2.3.30発行',list:'s2016'},
    {name:'押部',north:34.7365610055593,west:135.000101904413,south:34.6699042240326,east:135.100095340001,note:'明治43年測図・大正2.2.28発行',list:'s2017'},
    {name:'社',north:34.9365358984782,west:134.900103992992,south:34.8698791444215,east:135.00009741389,note:'明治43年部修・明治45.5.30発行',list:'s2018'},
    {name:'小野',north:34.8698768525733,west:134.900106242239,south:34.803220078236,east:135.00009966285,note:'明治43年部修・明治45.3.30発行',list:'s2019'},
    {name:'三木',north:34.8032177901903,west:134.900108484087,south:34.7365610055593,east:135.000101904413,note:'明治43年部修・明治45.3.30発行',list:'s2020'},
    {name:'髙砂',north:34.8032155093961,west:134.800117313791,south:34.7365587213194,east:134.90011071856,note:'明治39年修正・明治40.1.30発行',list:'s2553'},
    {name:'龍野',north:34.8698677578841,west:134.500141640109,south:34.8032109695894,east:134.600134998493,note:'明治36年修正・明治40.2.28発行',list:'s2555'}
]});
dataset.age.push({
  folderName:'00', start:1923, end:1923, scale:'1/25000', mapList: [
    {name:'天神',north:34.9198734373064,west:135.000095722299,south:34.836552480025,east:135.125098619284,note:'大正12年測図・大正15.6.30発行',list:'100-15-4-1'},
    {name:'淡河',north:34.8365496071402,west:135.000098539296,south:34.7532286437557,east:135.125101435782,note:'大正12年測図・昭和2.1.30発行',list:'100-16-3-1'},
    {name:'社',north:34.9198705700699,west:134.875106765749,south:34.8365496073947,east:135.000109638317,note:'大正12年測図・大正15.11.30発行',list:'104-3-2-1'},
    {name:'笠原',north:34.9198677141993,west:134.750117822438,south:34.8365467460933,east:134.875120670628,note:'大正12年測図・大正15.8.30発行',list:'104-3-4-1'},
    {name:'三木',north:34.8365467458397,west:134.875109571608,south:34.7532257770912,east:135.000112443736,note:'大正12年測図・大正15.10.30発行',list:'104-4-1-1'},
    {name:'東二見',north:34.753222921479,west:134.875112365934,south:34.669901936635,east:135.000115237624,note:'大正12年測図・大正15.10.30発行',list:'104-4-2-1'},
    {name:'加古川',north:34.8365438958817,west:134.750120617146,south:34.7532229217321,east:134.875123464955,note:'大正12年測図・大正15.7.30発行',list:'104-4-3-1'},
    {name:'髙砂',north:34.7532200774397,west:134.750123400366,south:34.6698990872243,east:134.875126247796,note:'大正12年測図・昭和2.5.30発行',list:'104-4-4-1'},
    {name:'姫路北部',north:34.9198648697083,west:134.625128892312,south:34.8365438961342,east:134.750131716164,note:'大正12年測図・大正15.7.30発行',list:'104-7-2-1'},
    {name:'龍野',north:34.9198620366103,west:134.500139975319,south:34.8365410575311,east:134.625142774873,note:'大正12年測図・大正15.7.30発行',list:'104-7-4-1'},
    {name:'姫路南部',north:34.8365410572796,west:134.625131675855,south:34.7532200776918,east:134.750134499386,note:'大正12年測図・大正15.6.30発行',list:'104-8-1-1'},
    {name:'網干',north:34.8365382300469,west:134.500142747685,south:34.7532172449838,east:134.625145546975,note:'大正12年測図・大正15.6.30発行',list:'104-8-3-1'},
    {name:'明石',north:34.6698990869718,west:134.875115148774,south:34.5865780760099,east:135.000118020027,note:'大正12年測図・昭和2.5.30発行',list:'105-1-1-1'}
]});
dataset.age.push({
  folderName:'01', start:1967, end:1967, scale:'1/25000', mapList: [
    {name:'天神',north:34.9198733709129,west:134.997207077377,south:34.8365524132517,east:135.122198874775,note:'昭和42年改測・昭和44.7.30発行',list:'100-15-4-3'},
    {name:'淡河',north:34.8365495408841,west:134.997209894117,south:34.7532285771211,east:135.122201691016,note:'昭和42年改測・昭和44.8.30発行',list:'100-16-3-4'},
    {name:'社',north:34.9198705039389,west:134.872218121134,south:34.8365495408841,east:134.997209894117,note:'昭和42年改測・昭和44.8.30発行',list:'104-3-2-3'},
    {name:'笠原',north:34.9198676483312,west:134.747229178127,south:34.8365466798457,east:134.872220926735,note:'昭和42年改測・昭和44.8.30発行',list:'104-3-4-3'},
    {name:'三木',north:34.8365466798457,west:134.872220926735,south:34.7532257107188,east:134.997212699279,note:'昭和42年改測・昭和44.8.30発行',list:'104-4-1-4'},
    {name:'東二見',north:34.753222855622,west:134.872223720804,south:34.6699018704008,east:134.99721549291,note:'昭和42年改測・昭和44.8.30発行',list:'104-4-2-4'},
    {name:'加古川',north:34.8365438301499,west:134.747231972577,south:34.753222855622,east:134.872223720804,note:'昭和42年改測・昭和44.8.30発行',list:'104-4-3-4'},
    {name:'高砂',north:34.7532200118445,west:134.747234755541,south:34.669899021252,east:134.872226503389,note:'昭和42年改測・昭和44.8.30発行',list:'104-4-4-4'},
    {name:'姫路北部',north:34.9198648041033,west:134.622240248306,south:34.8365438301499,east:134.747231972577,note:'昭和42年改測・昭和44.8.30発行',list:'104-7-2-6'},
    {name:'龍野',north:34.9198619712688,west:134.497251331616,south:34.8365409918104,east:134.622243031591,note:'昭和42年改測・昭和44.8.30発行',list:'104-7-4-5'},
    {name:'姫路南部',north:34.8365409918104,west:134.622243031591,south:34.7532200118445,east:134.747234755541,note:'昭和42年改測・昭和44.8.30発行',list:'104-8-1-6'},
    {name:'網干',north:34.8365381648407,west:134.497254103723,south:34.7532171793996,east:134.622245803435,note:'昭和42年改測・昭和44.8.30発行',list:'104-8-3-4'},
    {name:'明石',north:34.669899021252,west:134.872226503389,south:34.5865780099141,east:134.997218275058,note:'昭和42年改測・昭和44.8.30発行',list:'105-1-1-6'}
]});
dataset.age.push({
  folderName:'02', start:1981, end:1985, scale:'1/25000', mapList: [
    {name:'天神',north:34.9198733709129,west:134.997207077377,south:34.8365524132517,east:135.122198874775,note:'昭和57年修正・昭和58.12.28発行',list:'100-15-4-6'},
    {name:'淡河',north:34.8365495408841,west:134.997209894117,south:34.7532285771211,east:135.122201691016,note:'昭和60年修正・昭和62.2.28発行',list:'100-16-3-10'},
    {name:'社',north:34.9198705039389,west:134.872218121134,south:34.8365495408841,east:134.997209894117,note:'昭和58年修正・昭和60.10.30発行',list:'104-3-2-6'},
    {name:'笠原',north:34.9198676483312,west:134.747229178127,south:34.8365466798457,east:134.872220926735,note:'昭和58年修正・昭和60.6.30発行',list:'104-3-4-7B'},
    {name:'三木',north:34.8365466798457,west:134.872220926735,south:34.7532257107188,east:134.997212699279,note:'昭和58年修正・昭和60.10.30発行',list:'104-4-1-8'},
    {name:'東二見',north:34.753222855622,west:134.872223720804,south:34.6699018704008,east:134.99721549291,note:'昭和58年修正・昭和60.5.30発行',list:'104-4-2-8'},
    {name:'加古川',north:34.8365438301499,west:134.747231972577,south:34.753222855622,east:134.872223720804,note:'昭和58年修正・昭和60.10.30発行',list:'104-4-3-9'},
    {name:'高砂',north:34.7532200118445,west:134.747234755541,south:34.669899021252,east:134.872226503389,note:'昭和58年修正・昭和60.6.30発行',list:'104-4-4-9'},
    {name:'姫路北部',north:34.9198648041033,west:134.622240248306,south:34.8365438301499,east:134.747231972577,note:'昭和56年二改・昭和57.11.30発行',list:'104-7-2-10'},
    {name:'龍野',north:34.9198619712688,west:134.497251331616,south:34.8365409918104,east:134.622243031591,note:'昭和56年二改・昭和57.12.28発行',list:'104-7-4-8'},
    {name:'姫路南部',north:34.8365409918104,west:134.622243031591,south:34.7532200118445,east:134.747234755541,note:'昭和56年二改・昭和57.10.30発行',list:'104-8-1-10'},
    {name:'網干',north:34.8365381648407,west:134.497254103723,south:34.7532171793996,east:134.622245803435,note:'昭和56年二改・昭和57.10.30発行',list:'104-8-3-8'},
    {name:'明石',north:34.669899021252,west:134.872226503389,south:34.5865780099141,east:134.997218275058,note:'昭和56年修正・昭和57.10.30発行',list:'105-1-1-9'}
]});
dataset.age.push({
  folderName:'03', start:1997, end:2001, scale:'1/25000', mapList: [
    {name:'天神',north:34.9198733709129,west:134.997207077377,south:34.8365524132517,east:135.122198874775,note:'平成11年修正・平成12.3.1発行',list:'100-15-4-9'},
    {name:'淡河',north:34.8365495408841,west:134.997209894117,south:34.7532285771211,east:135.122201691016,note:'平成13年修正・平成14.10.1発行',list:'100-16-3-17'},
    {name:'社',north:34.9198705039389,west:134.872218121134,south:34.8365495408841,east:134.997209894117,note:'平成11年修正・平成12.9.1発行',list:'104-3-2-10B'},
    {name:'笠原',north:34.9198676483312,west:134.747229178127,south:34.8365466798457,east:134.872220926735,note:'平成11年修正・平成12.4.1発行',list:'104-3-4-11B'},
    {name:'三木',north:34.8365466798457,west:134.872220926735,south:34.7532257107188,east:134.997212699279,note:'平成11年修正・平成12.4.1発行',list:'104-4-1-12B'},
    {name:'東二見',north:34.753222855622,west:134.872223720804,south:34.6699018704008,east:134.99721549291,note:'平成11年修正・平成12.7.1発行',list:'104-4-2-12B'},
    {name:'加古川',north:34.8365438301499,west:134.747231972577,south:34.753222855622,east:134.872223720804,note:'平成13年修正・平成14.11.1発行',list:'104-4-3-13'},
    {name:'高砂',north:34.7532200118445,west:134.747234755541,south:34.669899021252,east:134.872226503389,note:'平成13年修正・平成14.11.1発行',list:'104-4-4-13'},
    {name:'姫路北部',north:34.9198648041033,west:134.622240248306,south:34.8365438301499,east:134.747231972577,note:'平成11年修正・平成13.2.1発行',list:'104-7-2-15B'},
    {name:'龍野',north:34.9198619712688,west:134.497251331616,south:34.8365409918104,east:134.622243031591,note:'平成12年修正・平成13.9.1発行',list:'104-7-4-13B'},
    {name:'姫路南部',north:34.8365409918104,west:134.622243031591,south:34.7532200118445,east:134.747234755541,note:'平成13年修正・平成15.1.1発行',list:'104-8-1-15'},
    {name:'網干',north:34.8365381648407,west:134.497254103723,south:34.7532171793996,east:134.622245803435,note:'平成12年修正・平成13.9.1発行',list:'104-8-3-13B'},
    {name:'明石',north:34.669899021252,west:134.872226503389,south:34.5865780099141,east:134.997218275058,note:'平成9年修正・平成10.11.1発行',list:'105-1-1-11B'}
]});
kjmapDataSet['wakayama'] = new Object();
dataset = kjmapDataSet['wakayama'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1908, end:1912, scale:'1/20000', mapList: [
    {name:'粉河',north:34.3366155695719,west:135.400080196106,south:34.2699587389564,east:135.500073691487,note:'明治41年測図・大正2.4.30発行',list:'s1260'},
    {name:'龍門山',north:34.2699564457768,west:135.40008241419,south:34.2032995946969,east:135.500075909142,note:'明治44年測図・大正2.3.30発行',list:'s1261'},
    {name:'根来山',north:34.3366132796359,west:135.300088934256,south:34.2699564457768,east:135.40008241419,note:'明治43年測図・大正2.3.30発行',list:'s1264'},
    {name:'岩出',north:34.2699541597173,west:135.300091145439,south:34.203297305409,east:135.400084624974,note:'明治44年測図・大正2.3.30発行',list:'s1265'},
    {name:'山中',north:34.3366109968389,west:135.200097680933,south:34.2699541597173,east:135.300091145439,note:'明治43年測図・大正3.12.23発行',list:'s1269'},
    {name:'秋月',north:34.2699518807847,west:135.200099885209,south:34.2032950232292,east:135.300093349345,note:'明治43年測図・大正4.1.25発行',list:'s1271'},
    {name:'黒江',north:34.2032927481642,west:135.20010208223,south:34.1366358801617,east:135.300095545996,note:'明治43年測図・大正7.3.30発行',list:'s1273'},
    {name:'淡ノ輪',north:34.3408301629741,west:135.10010629671,south:34.2699518807847,east:135.200099885209,note:'明治43年測図・大正3.5.18発行',list:'s1346'},
    {name:'和歌山',north:34.269949608986,west:135.100108633472,south:34.2032927481642,east:135.20010208223,note:'明治43年測図・大正3.5.18発行',list:'s1347'},
    {name:'和歌浦',north:34.203290480221,west:135.100110823602,south:34.1328400073509,east:135.200104396424,note:'明治43年測図・大正4.1.18発行',list:'s1348'},
    {name:'加太',north:34.3366064526899,west:135.000115199762,south:34.269949608986,east:135.100108633472,note:'明治45年測図・大正3.4.9発行',list:'s1349'},
    {name:'田倉﨑',north:34.2699473443282,west:135.000117390202,south:34.203290480221,east:135.100110823602,note:'明治45年測図・大正3.4.9発行',list:'s1350'}
]});
dataset.age.push({
  folderName:'00', start:1934, end:1934, scale:'1/25000', mapList: [
    {name:'粉河',north:34.336614996419,west:135.375082379842,south:34.2532939510088,east:135.500074246587,note:'昭和9年二修・昭和22.8.30発行',list:'101-11-1-2'},
    {name:'龍門山',north:34.2532910868619,west:135.375085149151,south:34.1699700250974,east:135.500077015231,note:'昭和9年二修・昭和22.10.30発行',list:'101-11-2-2'},
    {name:'岩出',north:34.3366121373446,west:135.25009330653,south:34.2532910868619,east:135.375085149151,note:'昭和9年二修・昭和12.1.30発行',list:'101-11-3-3'},
    {name:'丸栖',north:34.253288233838,west:135.250096065057,south:34.1699671670309,east:135.375087907071,note:'昭和9年二修・昭和12.5.30発行',list:'101-11-4-2'},
    {name:'淡輪',north:34.339310663455,west:135.125104157249,south:34.253288233838,east:135.250096065057,note:'昭和9年二修・昭和11.7.25発行',list:'101-15-1-4'},
    {name:'和歌山',north:34.2532853919507,west:135.125106994252,south:34.1699643200638,east:135.250098812239,note:'昭和9年二修・昭和12.5.25発行',list:'101-15-2-5'},
    {name:'加太',north:34.3366063864282,west:134.997189756287,south:34.2532853919507,east:135.125106994252,note:'昭和9年二修・昭和11.8.25発行',list:'101-15-3-3'},
    {name:'海南',north:34.1699613263555,west:135.118137940096,south:34.0866403860064,east:135.250101548122,note:'昭和9年二修・昭和12.2.28発行',list:'101-16-1-4'}
]});
dataset.age.push({
  folderName:'01', start:1947, end:1947, scale:'1/25000', mapList: [
    {name:'和歌山',north:34.2532849620641,west:135.106157352389,south:34.1699643200638,east:135.250098812239,note:'昭和22年三修・昭和24.3.30発行',list:'101-15-2-7'}
]});
dataset.age.push({
  folderName:'02', start:1966, end:1967, scale:'1/25000', mapList: [
    {name:'粉河',north:34.3366149302165,west:135.372193732221,south:34.2532938846894,east:135.497185598407,note:'昭和42年改測・昭和44.3.30発行',list:'101-11-1-3'},
    {name:'龍門山',north:34.2532910207994,west:135.37219650128,south:34.1699699589189,east:135.497188366804,note:'昭和42年改測・昭和44.3.30発行',list:'101-11-2-4'},
    {name:'岩出',north:34.3366120713998,west:135.247204659217,south:34.2532910207994,east:135.37219650128,note:'昭和42年改測・昭和44.3.30発行',list:'101-11-3-6B'},
    {name:'丸栖',north:34.2532881680328,west:135.247207417494,south:34.1699671011087,east:135.372199258952,note:'昭和42年改測・昭和44.3.30発行',list:'101-11-4-5'},
    {name:'淡輪',north:34.3366092237437,west:135.122215599514,south:34.2532881680328,east:135.247207417494,note:'昭和42年改測・昭和44.3.30発行',list:'101-15-1-7'},
    {name:'和歌山',north:34.2532848840889,west:135.102718953289,south:34.1699642543983,east:135.247210164428,note:'昭和42年改測・昭和44.3.30発行',list:'101-15-2-9'},
    {name:'加太',north:34.3366063872616,west:134.997226553061,south:34.253285326403,east:135.122218346996,note:'昭和42年改測・昭和43.11.30発行',list:'101-15-3-6'},
    {name:'海南',north:34.1699614188012,west:135.122221083179,south:34.0866403204807,east:135.247212900064,note:'昭和41年改測・昭和44.1.30発行',list:'101-16-1-7'}
]});
dataset.age.push({
  folderName:'03', start:1984, end:1985, scale:'1/25000', mapList: [
    {name:'粉河',north:34.3366149302165,west:135.372193732221,south:34.2532938846894,east:135.497185598407,note:'昭和59年修正・昭和60.11.30発行',list:'101-11-1-5'},
    {name:'龍門山',north:34.2532910207994,west:135.37219650128,south:34.1699699589189,east:135.497188366804,note:'昭和59年修正・昭和61.2.28発行',list:'101-11-2-6'},
    {name:'岩出',north:34.3366120713998,west:135.247204659217,south:34.2532910207994,east:135.37219650128,note:'昭和59年修正・昭和61.1.30発行',list:'101-11-3-8'},
    {name:'丸栖',north:34.2532881680328,west:135.247207417494,south:34.1699671011087,east:135.372199258952,note:'昭和59年修正・昭和61.2.28発行',list:'101-11-4-7'},
    {name:'淡輪',north:34.3366092237437,west:135.122215599514,south:34.2532881680328,east:135.247207417494,note:'昭和59年修正・昭和60.12.28発行',list:'101-15-1-11'},
    {name:'和歌山',north:34.2532846975991,west:135.094493973112,south:34.1699642543983,east:135.247210164428,note:'昭和59年修正・昭和61.2.28発行',list:'101-15-2-16'},
    {name:'加太',north:34.3366063872616,west:134.997226553061,south:34.253285326403,east:135.122218346996,note:'昭和59年修正・昭和60.5.30発行',list:'101-15-3-10'},
    {name:'海南',north:34.1699614188012,west:135.122221083179,south:34.0866403204807,east:135.247212900064,note:'昭和60年修正・昭和61.12.28発行',list:'101-16-1-10'}
]});
dataset.age.push({
  folderName:'04', start:1998, end:2000, scale:'1/25000', mapList: [
    {name:'粉河',north:34.3366149302165,west:135.372193732221,south:34.2532938846894,east:135.497185598407,note:'平成12年修正・平成13.12.1発行',list:'101-11-1-9'},
    {name:'龍門山',north:34.2532910207994,west:135.37219650128,south:34.1699699589189,east:135.497188366804,note:'平成12年修正・平成13.10.1発行',list:'101-11-2-9'},
    {name:'岩出',north:34.3366120713998,west:135.247204659217,south:34.2532910207994,east:135.37219650128,note:'平成12年修正・平成13.12.1発行',list:'101-11-3-13'},
    {name:'丸栖',north:34.2532881680328,west:135.247207417494,south:34.1699671011087,east:135.372199258952,note:'平成12年修正・平成14.2.1発行',list:'101-11-4-10'},
    {name:'淡輪',north:34.3366092237437,west:135.122215599514,south:34.2532881680328,east:135.247207417494,note:'平成10年修正・平成11.11.1発行',list:'101-15-1-15C'},
    {name:'和歌山',north:34.2532846948313,west:135.094371883798,south:34.1699642543983,east:135.247210164428,note:'平成10年修正・平成11.12.1発行',list:'101-15-2-19B'},
    {name:'加太',north:34.3366063872616,west:134.997226553061,south:34.253285326403,east:135.122218346996,note:'平成10年修正・平成11.12.1発行',list:'101-15-3-13B'},
    {name:'海南',north:34.1699614188012,west:135.122221083179,south:34.0866403204807,east:135.247212900064,note:'平成12年修正・平成13.7.1発行',list:'101-16-1-14B'}
]});
kjmapDataSet['tottori'] = new Object();
dataset = kjmapDataSet['tottori'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1897, end:1897, scale:'1/20000', mapList: [
    {name:'細川',north:35.6031099463424,west:134.200143683199,south:35.5364532586393,east:134.300136995945,note:'明治30年測図・明治33.3.30発行',list:'s1371'},
    {name:'鳥取市',north:35.5364509807739,west:134.200145955961,south:35.4697942930161,east:134.300139268631,note:'明治30年測図・明治33.3.30発行',list:'s1373'},
    {name:'郡家',north:35.4697920188372,west:134.200148221247,south:35.4031353110147,east:134.300141533841,note:'明治30年測図・明治33.3.30発行',list:'s1377'},
    {name:'吉岡',north:35.5441456806274,west:134.100154663138,south:35.4697920188372,east:134.200148221247,note:'明治30年測図・明治33.3.30発行',list:'s1381'}
]});
dataset.age.push({
  folderName:'00', start:1932, end:1932, scale:'1/25000', mapList: [
    {name:'鳥取北部',north:35.586443497459,west:134.125150981765,south:35.5031226376854,east:134.250142610335,note:'昭和7年測図・昭和9.11.30発行',list:'103-15-2-1'},
    {name:'鳥取南部',north:35.5031197984583,west:134.125153812252,south:35.4197989229813,east:134.250145440735,note:'昭和7年測図・昭和10.7.30発行',list:'103-16-1-1'}
]});
dataset.age.push({
  folderName:'01', start:1973, end:1973, scale:'1/25000', mapList: [
    {name:'鳥取北部',north:35.5864434318458,west:134.122262341077,south:35.5031225719365,east:134.247253969077,note:'昭和48年測図・昭和51.3.30発行',list:'103-15-2-3'},
    {name:'鳥取南部',north:35.5031197329776,west:134.122265171296,south:35.4197988573656,east:134.24725679921,note:'昭和48年測図・昭和50.10.30発行',list:'103-16-1-3'}
]});
dataset.age.push({
  folderName:'02', start:1988, end:1988, scale:'1/25000', mapList: [
    {name:'鳥取北部',north:35.5864434318458,west:134.122262341077,south:35.5031225719365,east:134.247253969077,note:'昭和63年測図・平成1.10.1発行',list:'103-15-2-5'},
    {name:'鳥取南部',north:35.5031197329776,west:134.122265171296,south:35.4197988573656,east:134.24725679921,note:'昭和63年測図・平成1.9.1発行',list:'103-16-1-5'}
]});
dataset.age.push({
  folderName:'03', start:1999, end:2001, scale:'1/25000', mapList: [
    {name:'鳥取北部',north:35.5864434318458,west:134.122262341077,south:35.5031225719365,east:134.247253969077,note:'平成11年測図・平成12.6.1発行',list:'103-15-2-8B'},
    {name:'鳥取南部',north:35.5031197329776,west:134.122265171296,south:35.4197988573656,east:134.24725679921,note:'平成13年測図・平成14.7.1発行',list:'103-16-1-7'}
]});
kjmapDataSet['matsue'] = new Object();
dataset = kjmapDataSet['matsue'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1915, end:1915, scale:'1/25000', mapList: [
    {name:'美保関',north:35.5864239091926,west:133.250229838127,south:35.5031030074123,east:133.375221295194,note:'大正4年測図・大正6.7.30発行',list:'108-11-4-1'},
    {name:'米子',north:35.5031002497483,west:133.25023258709,south:35.4197793324724,east:133.375224044497,note:'大正4年測図・大正7.1.30発行',list:'108-12-3-1'},
    {name:'境',north:35.586421157677,west:133.125241154363,south:35.5031002497483,east:133.25023258709,note:'大正4年測図・大正7.3.30発行',list:'108-15-2-1'},
    {name:'揖屋',north:35.5030975037891,west:133.125243891626,south:35.4197765803945,east:133.250235324755,note:'大正4年測図・大正6.12.28発行',list:'108-16-1-1'},
    {name:'松江',north:35.5030947695477,west:133.000255208749,south:35.4197738399977,east:133.125246617641,note:'大正4年測図・大正7.1.30発行',list:'108-16-3-1'},
    {name:'秋鹿',north:35.5030920470372,west:132.875266538403,south:35.419771111295,east:133.000257923099,note:'大正4年測図・大正7.2.28発行',list:'113-4-1-1'},
    {name:'宍道',north:35.4197683942994,west:132.875269241076,south:35.3364474331283,east:133.000260626294,note:'大正4年測図・大正6.12.28発行',list:'113-4-2-1'},
    {name:'平田',north:35.5030893362705,west:132.750277880535,south:35.4197683942994,east:132.875269241076,note:'大正4年測図・大正6.12.28発行',list:'113-4-3-1'},
    {name:'今市',north:35.4197656890238,west:132.750280571518,south:35.3364447216535,east:132.875271932642,note:'大正4年測図・大正7.4.30発行',list:'113-4-4-1'},
    {name:'杵築',north:35.4197628806551,west:132.619951499296,south:35.3364420218749,east:132.750283251443,note:'大正4年測図・大正7.1.30発行',list:'113-8-2-1'}
]});
dataset.age.push({
  folderName:'01', start:1934, end:1934, scale:'1/25000', mapList: [
    {name:'美保関',north:35.5864239091926,west:133.250229838127,south:35.5031030074123,east:133.375221295194,note:'昭和9年修正・昭和22.10.30発行',list:'108-11-4-3'},
    {name:'米子',north:35.5031002497483,west:133.25023258709,south:35.4197793324724,east:133.375224044497,note:'昭和9年修正・昭和11.8.30発行',list:'108-12-3-4'},
    {name:'境',north:35.586421157677,west:133.125241154363,south:35.5031002497483,east:133.25023258709,note:'昭和9年修正・昭和22.10.30発行',list:'108-15-2-3'},
    {name:'揖屋',north:35.5030975037891,west:133.125243891626,south:35.4197765803945,east:133.250235324755,note:'昭和9年修正・昭和11.8.30発行',list:'108-16-1-3'},
    {name:'松江',north:35.5030947695477,west:133.000255208749,south:35.4197738399977,east:133.125246617641,note:'昭和9年修正・昭和11.9.30発行',list:'108-16-3-3'},
    {name:'秋鹿',north:35.5030920470372,west:132.875266538403,south:35.419771111295,east:133.000257923099,note:'昭和9年修正・昭和11.7.30発行',list:'113-4-1-3'},
    {name:'宍道',north:35.4197683942994,west:132.875269241076,south:35.3364474331283,east:133.000260626294,note:'昭和9年修正・昭和12.2.28発行',list:'113-4-2-3'},
    {name:'平田',north:35.5030893362705,west:132.750277880535,south:35.4197683942994,east:132.875269241076,note:'昭和9年修正・昭和11.8.30発行',list:'113-4-3-3'},
    {name:'出雲今市',north:35.4197656890238,west:132.750280571518,south:35.3364447216535,east:132.875271932642,note:'昭和9年修正・昭和11.8.30発行',list:'113-4-4-3'},
    {name:'大社',north:35.4197628929388,west:132.620522847415,south:35.3364420218749,east:132.750283251443,note:'昭和9年修正・昭和11.8.30発行',list:'113-8-2-3'}
]});
dataset.age.push({
  folderName:'02', start:1975, end:1975, scale:'1/25000', mapList: [
    {name:'美保関',north:35.5864238454693,west:133.247341199516,south:35.5031029435473,east:133.37233265602,note:'昭和50年改測・昭和52.2.28発行',list:'108-11-4-4C'},
    {name:'米子',north:35.5031001861537,west:133.247343948209,south:35.4197792687368,east:133.372335405054,note:'昭和50年改測・昭和52.2.28発行',list:'108-12-3-7'},
    {name:'境港',north:35.586421094225,west:133.122352516044,south:35.5031001861537,east:133.247343948209,note:'昭和50年改測・昭和52.1.30発行',list:'108-15-2-4'},
    {name:'揖屋',north:35.5030974404651,west:133.122355253037,south:35.4197765169288,east:133.247346685605,note:'昭和50年改測・昭和52.2.28発行',list:'108-16-1-6'},
    {name:'松江',north:35.5030947064948,west:132.997366570449,south:35.4197737768021,east:133.122357978782,note:'昭和50年改測・昭和52.2.28発行',list:'108-16-3-6'},
    {name:'秋鹿',north:35.5030919842555,west:132.872377900392,south:35.4197710483698,east:132.99736928453,note:'昭和50年改測・昭和52.3.30発行',list:'113-4-1-6'},
    {name:'宍道',north:35.4197683316449,west:132.872380602796,south:35.3364473703309,east:132.997371987456,note:'昭和50年改測・昭和52.3.30発行',list:'113-4-2-5'},
    {name:'平田',north:35.5030892737604,west:132.747389242812,south:35.4197683316449,east:132.872380602796,note:'昭和50年改測・昭和52.3.30発行',list:'113-4-3-6B'},
    {name:'出雲今市',north:35.4197656266403,west:132.747391933526,south:35.3364446591263,east:132.872383294093,note:'昭和50年改測・昭和52.3.30発行',list:'113-4-4-6'},
    {name:'大社',north:35.4197629031934,west:132.620999804106,south:35.3364419596182,east:132.747394613181,note:'昭和50年改測・昭和52.3.30発行',list:'113-8-2-6'}
]});
dataset.age.push({
  folderName:'03', start:1989, end:1990, scale:'1/25000', mapList: [
    {name:'美保関',north:35.5864238454693,west:133.247341199516,south:35.5031029435473,east:133.37233265602,note:'平成2年修正・平成3.5.1発行',list:'108-11-4-6'},
    {name:'米子',north:35.5031001861537,west:133.247343948209,south:35.4197792687368,east:133.372335405054,note:'平成1年修正・平成2.11.1発行',list:'108-12-3-9'},
    {name:'境港',north:35.586421094225,west:133.122352516044,south:35.5031001861537,east:133.247343948209,note:'平成2年修正・平成3.5.1発行',list:'108-15-2-6'},
    {name:'揖屋',north:35.5030974404651,west:133.122355253037,south:35.4197765169288,east:133.247346685605,note:'平成2年修正・平成3.5.1発行',list:'108-16-1-8'},
    {name:'松江',north:35.5030947064948,west:132.997366570449,south:35.4197737768021,east:133.122357978782,note:'平成2年修正・平成3.10.1発行',list:'108-16-3-8'},
    {name:'秋鹿',north:35.5030919842555,west:132.872377900392,south:35.4197710483698,east:132.99736928453,note:'平成2年修正・平成3.3.1発行',list:'113-4-1-8'},
    {name:'宍道',north:35.4197683316449,west:132.872380602796,south:35.3364473703309,east:132.997371987456,note:'平成2年修正・平成3.3.1発行',list:'113-4-2-7'},
    {name:'平田',north:35.5160017423422,west:132.747388824846,south:35.4197683316449,east:132.872380602796,note:'平成2年修正・平成3.4.1発行',list:'113-4-3-8'},
    {name:'出雲今市',north:35.4197656266403,west:132.747391933526,south:35.3364446591263,east:132.872383294093,note:'平成2年修正・平成3.5.1発行',list:'113-4-4-8B'},
    {name:'大社',north:35.4197629026237,west:132.620973306512,south:35.3364419596182,east:132.747394613181,note:'平成2年修正・平成3.5.1発行',list:'113-8-2-8'}
]});
dataset.age.push({
  folderName:'04', start:1997, end:2003, scale:'1/25000', mapList: [
    {name:'美保関',north:35.5864238454693,west:133.247341199516,south:35.5031029435473,east:133.37233265602,note:'平成12年部修・平成12.9.1発行',list:'108-11-4-7B'},
    {name:'米子',north:35.5031001861537,west:133.247343948209,south:35.4197792687368,east:133.372335405054,note:'平成9年修正・平成10.7.1発行',list:'108-12-3-11'},
    {name:'境港',north:35.586421094225,west:133.122352516044,south:35.5031001861537,east:133.247343948209,note:'平成13年修正・平成14.9.1発行',list:'108-15-2-9'},
    {name:'揖屋',north:35.5030974404651,west:133.122355253037,south:35.4197765169288,east:133.247346685605,note:'平成13年修正・平成14.1.1発行',list:'108-16-1-11'},
    {name:'松江',north:35.5030947064948,west:132.997366570449,south:35.4197737768021,east:133.122357978782,note:'平成15年部修・平成15.10.1発行',list:'108-16-3-12'},
    {name:'秋鹿',north:35.5030919842555,west:132.872377900392,south:35.4197710483698,east:132.99736928453,note:'平成11年部修・平成12.1.1発行',list:'113-4-1-11B'},
    {name:'宍道',north:35.4197683316449,west:132.872380602796,south:35.3364473703309,east:132.997371987456,note:'平成13年修正・平成13.12.1発行',list:'113-4-2-9'},
    {name:'平田',north:35.5160791433416,west:132.74738882234,south:35.4197683316449,east:132.872380602796,note:'平成12年修正・平成14.2.1発行',list:'113-4-3-10'},
    {name:'出雲今市',north:35.4197656266403,west:132.747391933526,south:35.3364446591263,east:132.872383294093,note:'平成13年修正・平成14.4.1発行',list:'113-4-4-10'},
    {name:'大社',north:35.4197629068201,west:132.621168488789,south:35.3364419596182,east:132.747394613181,note:'平成13年修正・平成14.4.1発行',list:'113-8-2-10'}
]});
kjmapDataSet['okayama'] = new Object();
dataset = kjmapDataSet['okayama'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1895, end:1898, scale:'1/20000', mapList: [
    {name:'藤井',north:34.7365384897568,west:134.000190423381,south:34.6698816732626,east:134.100183704409,note:'明治28年測図・明治31.5.30発行',list:'s1435'},
    {name:'西大寺',north:34.6698794581241,west:134.000192586606,south:34.6032226214507,east:134.100185867621,note:'明治28年測図・明治31.5.30発行',list:'s1436'},
    {name:'小串',north:34.6032204100153,west:134.000194742715,south:34.5365635631497,east:134.100188023716,note:'明治28年測図・明治31.2.28発行',list:'s1437'},
    {name:'御野村',north:34.7365362782193,west:133.900199320922,south:34.6698794581241,east:134.000192586606,note:'明治28年測図・明治31.3.30発行',list:'s1439'},
    {name:'岡山',north:34.6698772502744,west:133.900201477014,south:34.6032204100153,east:134.000194742715,note:'明治28年測図・明治31.3.30発行',list:'s1440'},
    {name:'八濱',north:34.6032182058564,west:133.900203626013,south:34.5365613554203,east:134.00019689173,note:'明治28年測図・明治31.3.30発行',list:'s1441'},
    {name:'田井村',north:34.5365591549553,west:133.900205767942,south:34.4699025119314,east:134.009631497442,note:'明治30年測図・明治32.12.25発行',list:'s1442'},
    {name:'日比',north:34.4699001075613,west:133.900207902823,south:34.4032432367357,east:134.00020116857,note:'明治30年測図・明治32.5.30発行',list:'s1443'},
    {name:'真金',north:34.7365340739894,west:133.800208226653,south:34.6698772502744,east:133.900201477014,note:'明治28年測図・明治31.3.30発行',list:'s1444'},
    {name:'庭瀬',north:34.6698750497201,west:133.800210375606,south:34.6032182058564,east:133.900203626013,note:'明治28年測図・明治32.2.28発行',list:'s1445'},
    {name:'天城',north:34.6032160089807,west:133.80021251749,south:34.5365591549553,east:133.900205767942,note:'明治30年測図・明治32.12.25発行',list:'s1446'},
    {name:'田口',north:34.5365569617614,west:133.800214652326,south:34.4699001075613,east:133.900207902823,note:'明治30年測図・明治32.9.30発行',list:'s1447'},
    {name:'味野村',north:34.4698979180522,west:133.800216780138,south:34.4032410436678,east:133.90021003068,note:'明治30年測図・明治32.5.30発行',list:'s1448'},
    {name:'総社',north:34.7365318770739,west:133.700217140548,south:34.6698750497201,east:133.800210375606,note:'明治30年測図・明治32.9.30発行',list:'s1449'},
    {name:'川邊村',north:34.6698728564679,west:133.700219282355,south:34.6032160089807,east:133.80021251749,note:'明治30年測図・明治32.9.30発行',list:'s1450'},
    {name:'倉敷',north:34.603213819395,west:133.700221417116,south:34.5365569617614,east:133.800214652326,note:'明治30年測図・明治32.9.30発行',list:'s1451'},
    {name:'呼松',north:34.5365547758452,west:133.700223544854,south:34.4698979180522,east:133.800216780138,note:'明治30年測図・明治32.6.30発行',list:'s1452'},
    {name:'下津井',north:34.4698957358085,west:133.70022566559,south:34.4032388578465,east:133.800218900948,note:'明治30年測図・明治32.2.28発行',list:'s1453'},
    {name:'箭田村',north:34.6698706705245,west:133.600228197234,south:34.603213819395,east:133.700221417116,note:'明治30年測図・明治32.6.30発行',list:'s1454'},
    {name:'玉嶋',north:34.6032116371059,west:133.600230324866,south:34.5365547758452,east:133.700223544854,note:'明治30年測図・明治32.12.25発行',list:'s1455'},
    {name:'勇崎',north:34.5365525972133,west:133.600232445498,south:34.4698957358085,east:133.70022566559,note:'明治30年測図・明治32.9.30発行',list:'s1456'},
    {name:'矢掛',north:34.6698684918967,west:133.500237120216,south:34.6032116371059,east:133.600230324866,note:'明治30年測図・明治32.12.25発行',list:'s1484'},
    {name:'鴨方',north:34.60320946212,west:133.500239240713,south:34.5365525972133,east:133.600232445498,note:'明治30年測図・明治32.12.25発行',list:'s1485'},
    {name:'笠岡',north:34.5365504258725,west:133.500241354233,south:34.469893560837,east:133.600234559152,note:'明治30年測図・明治32.12.25発行',list:'s1486'},
    {name:'井原町',north:34.6698663205909,west:133.400246051274,south:34.60320946212,east:133.500239240713,note:'明治30年測図・明治32.12.25発行',list:'s1488'},
    {name:'髙屋村',north:34.603207294444,west:133.400248164628,south:34.5365504258725,east:133.500241354233,note:'明治30年測図・明治32.12.25発行',list:'s1489'},
    {name:'西濱',north:34.5365482618293,west:133.40025027103,south:34.4698913931442,east:133.500243460798,note:'明治30年測図・明治32.9.30発行',list:'s1490'},
    {name:'神邊',north:34.6032051340844,west:133.300257096586,south:34.5365482618293,east:133.40025027103,note:'明治30年測図・明治32.12.25発行',list:'s1492'},
    {name:'福山町',north:34.5365461050902,west:133.300259195863,south:34.4698892327368,east:133.4002523705,note:'明治30年測図・明治33.3.30発行',list:'s1493'},
    {name:'水呑村',north:34.4698870796213,west:133.300261288232,south:34.4032301871601,east:133.400254463063,note:'明治30年測図・明治33.3.30発行',list:'s1494'},
    {name:'府中町',north:34.6032029810479,west:133.200266036558,south:34.5365461050902,east:133.300259195863,note:'明治30年測図・明治33.3.30発行',list:'s1496'},
    {name:'梶山田',north:34.536543955662,west:133.200268128704,south:34.4698870796213,east:133.300261288232,note:'明治30年測図・明治32.12.25発行',list:'s1497'},
    {name:'尾道町',north:34.4698849338044,west:133.200270213965,south:34.4032280376712,east:133.300263373716,note:'明治30年測図・明治33.3.30発行',list:'s1498'},
    {name:'向嶋',north:34.4032258954685,west:133.200272292365,south:34.3365689892299,east:133.300265452338,note:'明治30年測図・明治33.3.30発行',list:'s1499'},
    {name:'三成',north:34.4698827952924,west:133.100279147674,south:34.4032258954685,east:133.200272292365,note:'明治30年測図・大正8.5.30発行',list:'s1505'},
    {name:'松濱',north:34.4032237605585,west:133.100281218983,south:34.3365668506445,east:133.200274363926,note:'明治30年測図・大正14.9.30発行',list:'s1507'},
    {name:'三原',north:34.4032216329477,west:133.000290153542,south:34.3365647193394,east:133.100283283476,note:'明治31年測図・大正14.9.30発行',list:'s1568'}
]});
dataset.age.push({
  folderName:'00', start:1925, end:1925, scale:'1/25000', mapList: [
    {name:'香登',north:34.7532032516533,west:134.00018988146,south:34.6698822281853,east:134.125181485146,note:'大正14年修正・昭和3.2.28発行',list:'104-16-4-2'},
    {name:'西大寺',north:34.6698794581241,west:134.000192586606,south:34.5865584087475,east:134.125184190266,note:'大正14年修正・昭和3.2.28発行',list:'105-13-3-2'},
    {name:'岡山北部',north:34.7532004872217,west:133.8752010069,south:34.6698794581241,east:134.000192586606,note:'大正14年修正・昭和3.11.30発行',list:'109-4-2-3'},
    {name:'足守',north:34.7531977342156,west:133.750212145131,south:34.6698766994516,east:133.875203700896,note:'大正14年修正・昭和3.5.30発行',list:'109-4-4-2'},
    {name:'總社',north:34.7531949926481,west:133.625223296099,south:34.6698739521808,east:133.750214827963,note:'大正14年修正・昭和3.3.30発行',list:'109-8-2-2'},
    {name:'岡山南部',north:34.6698766994516,west:133.875203700896,south:34.5865556444752,east:134.000195280633,note:'大正14年修正・大正15.11.30発行',list:'110-1-1-2'},
    {name:'八濱',north:34.5865528915679,west:133.875206383817,south:34.5032318306872,east:134.000197963584,note:'大正14年修正・昭和3.5.30発行',list:'110-1-2-2'},
    {name:'倉敷',north:34.6698739521808,west:133.750214827963,south:34.5865528915679,east:133.875206383817,note:'大正14年修正・昭和3.1.30発行',list:'110-1-3-2'},
    {name:'茶屋町',north:34.5865501500384,west:133.750217499766,south:34.503229083551,east:133.875209055709,note:'大正14年修正・昭和3.3.30発行',list:'110-1-4-2'},
    {name:'宇野',north:34.503229083551,west:133.875209055709,south:34.419908006744,east:134.000200635505,note:'大正14年修正・昭和3.1.30発行',list:'110-2-1-2'},
    {name:'下津井',north:34.5032263477689,west:133.750220160586,south:34.419905265385,east:133.875211716616,note:'大正14年修正・昭和3.2.28発行',list:'110-2-3-2'},
    {name:'箭田',north:34.6698712163248,west:133.625225967754,south:34.5865501500384,east:133.750217499766,note:'大正14年修正・昭和3.8.30発行',list:'110-5-1-2'},
    {name:'玉島',north:34.5865474198999,west:133.625228628427,south:34.5004488851856,east:133.750220249091,note:'大正14年修正・昭和22.10.30発行',list:'110-5-2-3'},
    {name:'水呑',north:34.5032182086768,west:133.375253551198,south:34.4198971093411,east:133.500245036172,note:'大正14年修正・昭和3.4.30発行',list:'110-10-1-2'},
    {name:'福山',north:34.5032155184406,west:133.250264706553,south:34.4198944133805,east:133.375256167923,note:'大正14年修正・昭和3.3.30発行',list:'110-10-3-2'},
    {name:'府中',north:34.5865366135145,west:133.125273269124,south:34.5032155184406,east:133.250264706553,note:'大正14年修正・昭和3.6.30発行',list:'110-13-2-2'},
    {name:'三成',north:34.5032128396229,west:133.125275874394,south:34.4198917288018,east:133.2502673122,note:'大正14年測図・昭和5.1.30発行',list:'110-14-1-2'},
    {name:'尾道',north:34.4198890556177,west:133.125278468953,south:34.3365679190276,east:133.250269907135,note:'大正14年測図・昭和5.4.30発行',list:'110-14-2-2'},
    {name:'糸﨑',north:34.4198863938408,west:133.000289638126,south:34.3365652514828,east:133.125281052844,note:'大正14年測図・昭和3.3.30発行',list:'110-14-4-1'},
    {name:'矢掛',north:34.6698684918967,west:133.500237120216,south:34.5865474198999,east:133.625228628427,note:'大正14年修正・昭和4.1.30発行',list:'110-5-3-2'},
    {name:'笠岡',north:34.5865447011654,west:133.500239769746,south:34.5032236233538,east:133.625231278162,note:'大正14年修正・昭和3.6.30発行',list:'110-5-4-2'},
    {name:'寄島',north:34.5032209103188,west:133.500242408383,south:34.4198998166706,east:133.625233917003,note:'大正14年修正・昭和3.3.30発行',list:'110-6-3-2'},
    {name:'井原',north:34.6698657789093,west:133.375248285297,south:34.5865447011654,east:133.500239769746,note:'大正14年修正・昭和3.3.30発行',list:'110-9-1-2'},
    {name:'神邊',north:34.5865419938477,west:133.375250923671,south:34.5032209103188,east:133.500242408383,note:'大正14年修正・昭和3.2.28発行',list:'110-9-2-2'},
    {name:'新市',north:34.5865392979598,west:133.250262090148,south:34.5032182086768,east:133.375253551198,note:'大正14年修正・昭和3.5.30発行',list:'110-9-4-2'}
]});
dataset.age.push({
  folderName:'01', start:1965, end:1970, scale:'1/25000', mapList: [
    {name:'備前瀬戸',north:34.7532031876351,west:133.997301238437,south:34.6698821640374,east:134.122292841569,note:'昭和41年改測・昭和44.3.30発行',list:'104-16-4-6'},
    {name:'西大寺',north:34.6698793942393,west:133.997303943326,south:34.5865583447336,east:134.122295546432,note:'昭和45年改測・昭和46.7.30発行',list:'105-13-3-5'},
    {name:'岡山北部',north:34.7532004234674,west:133.872312364174,south:34.6698793942393,east:133.997303943326,note:'昭和41年改測・昭和42.10.30発行',list:'109-4-2-7'},
    {name:'総社東部',north:34.7531976707255,west:133.7473235027,south:34.6698766358301,east:133.872315057912,note:'昭和41年改測・昭和42.9.30発行',list:'109-4-4-5'},
    {name:'総社西部',north:34.7531949294225,west:133.622334653961,south:34.669873888823,east:133.747326185273,note:'昭和41年改測・昭和42.9.30発行',list:'109-8-2-6'},
    {name:'岡山南部',north:34.6698766358301,west:133.872315057912,south:34.5865555807239,east:133.997306637096,note:'昭和42年改測・昭和44.6.30発行',list:'110-1-1-7'},
    {name:'八浜',north:34.5865528280793,west:133.872317740576,south:34.5032317670695,east:133.997309319792,note:'昭和42年改測・昭和44.6.30発行',list:'110-1-2-5'},
    {name:'倉敷',north:34.669873888823,west:133.747326185273,south:34.5865528280793,east:133.872317740576,note:'昭和42年改測・昭和44.5.30発行',list:'110-1-3-6'},
    {name:'茶屋町',north:34.586550086813,west:133.74732885682,south:34.5032290201956,east:133.872320412213,note:'昭和42年改測・昭和45.3.30発行',list:'110-1-4-6'},
    {name:'宇野',north:34.5032290201956,west:133.872320412213,south:34.4199079432601,east:133.997311991459,note:'昭和45年改測・昭和48.2.28発行',list:'110-2-1-5'},
    {name:'下津井',north:34.503226284676,west:133.747331517383,south:34.4199052021628,east:133.872323072865,note:'昭和45年改測・昭和47.2.28発行',list:'110-2-3-5'},
    {name:'箭田',north:34.669871153231,west:133.622337325358,south:34.586550086813,east:133.74732885682,note:'昭和40年改測・昭和42.6.30発行',list:'110-5-1-6'},
    {name:'玉島',north:34.5865473569379,west:133.622339985774,south:34.503226284676,east:133.747331517383,note:'昭和40年改測・昭和42.6.30発行',list:'110-5-2-6'},
    {name:'水島港',north:34.5032235605238,west:133.622342635252,south:34.419902472396,east:133.747334167009,note:'昭和40年測量・昭和42.6.30発行',list:'110-6-1-1'},
    {name:'福山東部',north:34.5032181463734,west:133.37236490887,south:34.4198970469058,east:133.497356393299,note:'昭和40年改測・昭和42.11.30発行',list:'110-10-1-6'},
    {name:'福山西部',north:34.5032154564009,west:133.247376064514,south:34.4198943512082,east:133.372367525339,note:'昭和40年改測・昭和42.6.30発行',list:'110-10-3-6'},
    {name:'府中',north:34.5865365516091,west:133.122384627631,south:34.5032154564009,east:133.247376064514,note:'昭和40年改測・昭和42.5.30発行',list:'110-13-2-6'},
    {name:'三成',north:34.5032127778473,west:133.122387232643,south:34.4198916668926,east:133.247378669906,note:'昭和40年改測・昭和42.6.30発行',list:'110-14-1-4'},
    {name:'尾道',north:34.419888993972,west:133.122389826946,south:34.336567857249,east:133.247381264585,note:'昭和40年改測・昭和42.3.30発行',list:'110-14-2-5'},
    {name:'三原',north:34.419886332459,west:132.997400996406,south:34.3365651899672,east:133.122392410581,note:'昭和40年改測・昭和42.6.30発行',list:'110-14-4-5'},
    {name:'矢掛',north:34.6698684290671,west:133.497348478112,south:34.5865473569379,east:133.622339985774,note:'昭和40年改測・昭和42.6.30発行',list:'110-5-3-6'},
    {name:'笠岡',north:34.5865446384671,west:133.497351127385,south:34.5032235605238,east:133.622342635252,note:'昭和40年改測・昭和42.6.30発行',list:'110-5-4-6'},
    {name:'寄島',north:34.503220847752,west:133.497353765765,south:34.4198997539727,east:133.622345273838,note:'昭和40年改測・昭和42.6.30発行',list:'110-6-3-5'},
    {name:'井原',north:34.6698657163443,west:133.372359643484,south:34.5865446384671,east:133.497351127385,note:'昭和40年改測・昭和42.10.30発行',list:'110-9-1-5'},
    {name:'神辺',north:34.5865419314134,west:133.3723622816,south:34.503220847752,east:133.497353765765,note:'昭和40年改測・昭和42.6.30発行',list:'110-9-2-5'},
    {name:'新市',north:34.5865392357898,west:133.247373448366,south:34.5032181463734,east:133.37236490887,note:'昭和43年修正・昭和44.4.30発行',list:'110-9-4-6'}
]});
dataset.age.push({
  folderName:'02', start:1978, end:1988, scale:'1/25000', mapList: [
    {name:'備前瀬戸',north:34.7532031876351,west:133.997301238437,south:34.6698821640374,east:134.122292841569,note:'昭和58年二改・昭和59.11.30発行',list:'104-16-4-10'},
    {name:'西大寺',north:34.6698793942393,west:133.997303943326,south:34.5865583447336,east:134.122295546432,note:'昭和57年二改・昭和59.5.30発行',list:'105-13-3-7'},
    {name:'岡山北部',north:34.7532004234674,west:133.872312364174,south:34.6698793942393,east:133.997303943326,note:'昭和57年二改・昭和59.2.28発行',list:'109-4-2-11'},
    {name:'総社東部',north:34.7531976707255,west:133.7473235027,south:34.6698766358301,east:133.872315057912,note:'昭和57年二改・昭和59.2.28発行',list:'109-4-4-9'},
    {name:'総社西部',north:34.7531949294225,west:133.622334653961,south:34.669873888823,east:133.747326185273,note:'昭和58年修正・昭和60.7.30発行',list:'109-8-2-9'},
    {name:'岡山南部',north:34.6698766358301,west:133.872315057912,south:34.5865555807239,east:133.997306637096,note:'昭和56年二改・昭和57.12.28発行',list:'110-1-1-11'},
    {name:'八浜',north:34.5865528280793,west:133.872317740576,south:34.5032317670695,east:133.997309319792,note:'昭和56年二改・昭和58.2.28発行',list:'110-1-2-10'},
    {name:'倉敷',north:34.669873888823,west:133.747326185273,south:34.5865528280793,east:133.872317740576,note:'昭和56年二改・昭和58.2.28発行',list:'110-1-3-10'},
    {name:'茶屋町',north:34.586550086813,west:133.74732885682,south:34.5032290201956,east:133.872320412213,note:'昭和56年二改・昭和57.10.30発行',list:'110-1-4-11'},
    {name:'宇野',north:34.5032290201956,west:133.872320412213,south:34.4199079432601,east:133.997311991459,note:'昭和53年修正・昭和55.6.30発行',list:'110-2-1-7'},
    {name:'下津井',north:34.503226284676,west:133.747331517383,south:34.4199052021628,east:133.872323072865,note:'昭和59年修正・昭和61.7.30発行',list:'110-2-3-8'},
    {name:'箭田',north:34.669871153231,west:133.622337325358,south:34.586550086813,east:133.74732885682,note:'昭和56年二改・昭和57.10.30発行',list:'110-5-1-10B'},
    {name:'玉島',north:34.5865473569379,west:133.622339985774,south:34.503226284676,east:133.747331517383,note:'昭和56年二改・昭和57.12.28発行',list:'110-5-2-10'},
    {name:'水島港',north:34.5032235605238,west:133.622342635252,south:34.419902472396,east:133.747334167009,note:'昭和53年改測・昭和54.11.30発行',list:'110-6-1-4'},
    {name:'福山東部',north:34.5032181463734,west:133.37236490887,south:34.4198970469058,east:133.497356393299,note:'昭和58年二改・昭和60.1.30発行',list:'110-10-1-10'},
    {name:'福山西部',north:34.5032154564009,west:133.247376064514,south:34.4198943512082,east:133.372367525339,note:'昭和58年二改・昭和59.10.30発行',list:'110-10-3-10'},
    {name:'府中',north:34.5865365516091,west:133.122384627631,south:34.5032154564009,east:133.247376064514,note:'昭和63年修正・平成1.8.1発行',list:'110-13-2-10B'},
    {name:'三成',north:34.5032127778473,west:133.122387232643,south:34.4198916668926,east:133.247378669906,note:'昭和58年二改・昭和60.2.28発行',list:'110-14-1-8'},
    {name:'尾道',north:34.419888993972,west:133.122389826946,south:34.336567857249,east:133.247381264585,note:'昭和58年二改・昭和59.11.30発行',list:'110-14-2-9'},
    {name:'三原',north:34.419886332459,west:132.997400996406,south:34.3365651899672,east:133.122392410581,note:'昭和58年二改・昭和59.12.28発行',list:'110-14-4-9B'},
    {name:'矢掛',north:34.6698684290671,west:133.497348478112,south:34.5865473569379,east:133.622339985774,note:'昭和56年二改・昭和57.11.30発行',list:'110-5-3-10'},
    {name:'笠岡',north:34.5865446384671,west:133.497351127385,south:34.5032235605238,east:133.622342635252,note:'昭和56年二改・昭和57.11.30発行',list:'110-5-4-10'},
    {name:'寄島',north:34.503220847752,west:133.497353765765,south:34.4198997539727,east:133.622345273838,note:'昭和53年二改・昭和55.4.30発行',list:'110-6-3-8'},
    {name:'井原',north:34.6698657163443,west:133.372359643484,south:34.5865446384671,east:133.497351127385,note:'昭和58年二改・昭和60.1.30発行',list:'110-9-1-9'},
    {name:'神辺',north:34.5865419314134,west:133.3723622816,south:34.503220847752,east:133.497353765765,note:'昭和58年二改・昭和60.1.30発行',list:'110-9-2-9'},
    {name:'新市',north:34.5865392357898,west:133.247373448366,south:34.5032181463734,east:133.37236490887,note:'昭和58年二改・昭和59.11.30発行',list:'110-9-4-10'}
]});
dataset.age.push({
  folderName:'03', start:1990, end:2000, scale:'1/25000', mapList: [
    {name:'備前瀬戸',north:34.7532031876351,west:133.997301238437,south:34.6698821640374,east:134.122292841569,note:'平成7年修正・平成8.8.1発行',list:'104-16-4-13'},
    {name:'西大寺',north:34.6698793942393,west:133.997303943326,south:34.5865583447336,east:134.122295546432,note:'平成7年修正・平成8.10.1発行',list:'105-13-3-9'},
    {name:'岡山北部',north:34.7532004234674,west:133.872312364174,south:34.6698793942393,east:133.997303943326,note:'平成9年修正・平成10.10.1発行',list:'109-4-2-14'},
    {name:'総社東部',north:34.7531976707255,west:133.7473235027,south:34.6698766358301,east:133.872315057912,note:'平成9年修正・平成10.10.1発行',list:'109-4-4-14'},
    {name:'総社西部',north:34.7531949294225,west:133.622334653961,south:34.669873888823,east:133.747326185273,note:'平成8年部修・平成9.3.15発行',list:'109-8-2-11'},
    {name:'岡山南部',north:34.6698766358301,west:133.872315057912,south:34.5865555807239,east:133.997306637096,note:'平成9年修正・平成10.5.1発行',list:'110-1-1-14'},
    {name:'八浜',north:34.5865528280793,west:133.872317740576,south:34.5032317670695,east:133.997309319792,note:'平成5年修正・平成6.5.1発行',list:'110-1-2-12'},
    {name:'倉敷',north:34.669873888823,west:133.747326185273,south:34.5865528280793,east:133.872317740576,note:'平成9年修正・平成10.10.1発行',list:'110-1-3-14'},
    {name:'茶屋町',north:34.586550086813,west:133.74732885682,south:34.5032290201956,east:133.872320412213,note:'平成9年修正・平成10.7.1発行',list:'110-1-4-14'},
    {name:'宇野',north:34.5032290201956,west:133.872320412213,south:34.4199079432601,east:133.997311991459,note:'平成2年修正・平成3.1.1発行',list:'110-2-1-9B'},
    {name:'下津井',north:34.503226284676,west:133.747331517383,south:34.4199052021628,east:133.872323072865,note:'平成8年部修・平成8.5.1発行',list:'110-2-3-12'},
    {name:'箭田',north:34.669871153231,west:133.622337325358,south:34.586550086813,east:133.74732885682,note:'平成10年部修・平成11.1.11発行',list:'110-5-1-14'},
    {name:'玉島',north:34.5865473569379,west:133.622339985774,south:34.503226284676,east:133.747331517383,note:'平成10年部修・平成11.10.1発行',list:'110-5-2-14'},
    {name:'水島港',north:34.5032235605238,west:133.622342635252,south:34.419902472396,east:133.747334167009,note:'平成6年修正・平成7.6.1発行',list:'110-6-1-6'},
    {name:'福山東部',north:34.5032181463734,west:133.37236490887,south:34.4198970469058,east:133.497356393299,note:'平成12年修正・平成13.6.1発行',list:'110-10-1-13B'},
    {name:'福山西部',north:34.5032154564009,west:133.247376064514,south:34.4198943512082,east:133.372367525339,note:'平成12年修正・平成13.5.1発行',list:'110-10-3-15B'},
    {name:'府中',north:34.5865365516091,west:133.122384627631,south:34.5032154564009,east:133.247376064514,note:'平成9年修正・平成10.6.1発行',list:'110-13-2-11B'},
    {name:'三成',north:34.5032127778473,west:133.122387232643,south:34.4198916668926,east:133.247378669906,note:'平成12年修正・平成13.5.1発行',list:'110-14-1-14B'},
    {name:'尾道',north:34.419888993972,west:133.122389826946,south:34.336567857249,east:133.247381264585,note:'平成12年修正・平成13.6.1発行',list:'110-14-2-13B'},
    {name:'三原',north:34.419886332459,west:132.997400996406,south:34.3365651899672,east:133.122392410581,note:'平成12年修正・平成13.8.1発行',list:'110-14-4-12B'},
    {name:'矢掛',north:34.6698684290671,west:133.497348478112,south:34.5865473569379,east:133.622339985774,note:'平成10年部修・平成11.1.11発行',list:'110-5-3-13B'},
    {name:'笠岡',north:34.5865446384671,west:133.497351127385,south:34.5032235605238,east:133.622342635252,note:'平成6年修正・平成7.5.1発行',list:'110-5-4-12B'},
    {name:'寄島',north:34.503220847752,west:133.497353765765,south:34.4198997539727,east:133.622345273838,note:'平成6年修正・平成7.4.1発行',list:'110-6-3-10B'},
    {name:'井原',north:34.6698657163443,west:133.372359643484,south:34.5865446384671,east:133.497351127385,note:'平成12年修正・平成13.2.1発行',list:'110-9-1-13B'},
    {name:'神辺',north:34.5865419314134,west:133.3723622816,south:34.503220847752,east:133.497353765765,note:'平成12年修正・平成13.2.1発行',list:'110-9-2-14B'},
    {name:'新市',north:34.5865392357898,west:133.247373448366,south:34.5032181463734,east:133.37236490887,note:'平成12年修正・平成13.8.1発行',list:'110-9-4-14B'}
]});
kjmapDataSet['hiroshima'] = new Object();
dataset = kjmapDataSet['hiroshima'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1894, end:1899, scale:'1/20000', mapList: [
    {name:'白市',north:34.4698764236516,west:132.800305996375,south:34.4032195126426,east:132.900299096015,note:'明治31年測図・大正8.5.30発行',list:'s1460'},
    {name:'西野',north:34.4032173996496,west:132.800308046375,south:34.3365604785965,east:132.900301146355,note:'明治31年測図・大正8.2.28発行',list:'s1462'},
    {name:'西條町',north:34.4698743144246,west:132.70031496171,south:34.4032173996496,east:132.800308046375,note:'明治31年測図・明治33.12.25発行',list:'s1463'},
    {name:'小多田',north:34.4032152939753,west:132.700317004594,south:34.3365583691715,east:132.800310089628,note:'明治31年測図・明治33.10.30発行',list:'s1464'},
    {name:'一貫田',north:34.4698722125349,west:132.600323934884,south:34.4032152939753,east:132.700317004594,note:'明治31年測図・明治33.10.30発行',list:'s1465'},
    {name:'小田山',north:34.4032131956259,west:132.600325970646,south:34.3365562670527,east:132.700319040756,note:'明治31年測図・明治33.10.30発行',list:'s1467'},
    {name:'可部',north:34.5365291149127,west:132.500330880539,south:34.4698722125349,east:132.600323934884,note:'明治31年測図・明治33.12.25発行',list:'s1469'},
    {name:'呉娑々宇山',north:34.469870117989,west:132.500332915869,south:34.4032131956259,east:132.600325970646,note:'明治31年測図・明治33.12.25発行',list:'s1470'},
    {name:'海田市',north:34.4032111046079,west:132.500334944503,south:34.3365541722465,east:132.600327999709,note:'明治32年測図・明治34.3.30発行',list:'s1471'},
    {name:'上安',north:34.5365270242043,west:132.400339876465,south:34.469870117989,east:132.500332915869,note:'明治31年測図・明治33.12.25発行',list:'s1473'},
    {name:'祗園',north:34.4698680307932,west:132.400341904638,south:34.4032111046079,east:132.500334944503,note:'明治27年測図・明治29.12.25発行',list:'s1474'},
    {name:'廣嶋',north:34.4032090209276,west:132.400343926138,south:34.3365520847594,east:132.500336966461,note:'明治27年測図・明治29.12.25発行',list:'s1476'},
    {name:'阿戸',north:34.5365249408647,west:132.300348880155,south:34.4698680307932,east:132.400341904638,note:'明治31年測図・明治34.3.30発行',list:'s1479'},
    {name:'河内村',north:34.4698659509539,west:132.300350901164,south:34.4032090209276,east:132.400343926138,note:'明治27年測図・明治29.12.25発行',list:'s1480'},
    {name:'廿日市',north:34.4032069445915,west:132.300352915523,south:34.3365500045975,east:132.400345940985,note:'明治27年測図・明治33.3.30発行',list:'s1481'},
    {name:'本鄕村',north:34.4698785402095,west:132.900297038906,south:34.4032216329477,east:133.000290153542,note:'明治31年測図・大正14.9.30発行',list:'s1517'},
    {name:'新港',north:34.2032278382019,west:132.200367894719,south:34.1365708644363,east:132.300360906881,note:'明治27年測図・明治33.3.30発行',list:'s1518'},
    {name:'通津',north:34.1365688094424,west:132.200369875637,south:34.0699118356766,east:132.300362888307,note:'明治27年測図・明治29.3.30発行',list:'s1521'},
    {name:'岩國',north:34.2032257870251,west:132.100376878206,south:34.1365688094424,east:132.200369875637,note:'明治27年測図・明治33.3.30発行',list:'s1530'},
    {name:'柱野',north:34.1365667617555,west:132.100378852064,south:34.0699097841879,east:132.200371850033,note:'明治27年測図・明治29.7.30発行',list:'s1532'},
    {name:'内海町',north:34.3365562670527,west:132.700319040756,south:34.269899342207,east:132.800312126157,note:'明治31年測図',list:'s1545'},
    {name:'内海跡',north:34.2698972436468,west:132.700321070215,south:34.2032402987499,east:132.800314155983,note:'明治31年測図',list:'s1546'},
    {name:'中黒瀬村',north:34.3365541722465,west:132.600327999709,south:34.2698972436468,east:132.700321070215,note:'明治32年測図',list:'s1547'},
    {name:'廣村',north:34.2698951523868,west:132.600330022093,south:34.2032382037512,east:132.700323092996,note:'明治32年測図',list:'s1548'},
    {name:'焼山',north:34.3365520847594,west:132.500336966461,south:34.2698951523868,east:132.600330022093,note:'明治32年測図',list:'s1550'},
    {name:'呉',north:34.2698930684334,west:132.500338981764,south:34.2032361160402,east:132.600332037822,note:'明治32年測図',list:'s1552'},
    {name:'隠渡瀬戸',north:34.2032340356235,west:132.500340990435,south:34.1365770731969,east:132.600334046915,note:'明治32年測図',list:'s1554'},
    {name:'似嶋',north:34.3365500045975,west:132.400345940985,south:34.2698930684334,east:132.500338981764,note:'明治32年測図',list:'s1556'},
    {name:'江田嶋',north:34.269890991793,west:132.4003479492,south:34.2032340356235,east:132.500340990435,note:'明治32年測図',list:'s1558'},
    {name:'大君',north:34.2032319625074,west:132.400349950807,south:34.1365749963198,east:132.500342992493,note:'明治32年測図',list:'s1559'},
    {name:'嚴嶋',north:34.3365479317674,west:132.300354923253,south:34.269890991793,east:132.4003479492,note:'明治27年測図',list:'s1561'},
    {name:'岸根鼻',north:34.2698889224718,west:132.300356924375,south:34.2032319625074,east:132.400349950807,note:'明治32年測図',list:'s1562'},
    {name:'玖嶋村',north:34.4032048756057,west:132.20036191263,south:34.3365479317674,east:132.300354923253,note:'明治31年測図',list:'s1564'},
    {name:'大野村',north:34.3365458662753,west:132.200363913237,south:34.2698889224718,east:132.300356924375,note:'明治27年測図',list:'s1565'},
    {name:'大竹',north:34.2698868604762,west:132.20036590726,south:34.2032298966981,east:132.300358918911,note:'明治27年測図',list:'s1566'},
    {name:'竹原町',north:34.4032195126426,west:132.900299096015,south:34.3365625953213,east:133.000292210962,note:'明治31年測図・大正14.9.30発行',list:'s1576'},
    {name:'大久野嶋',north:34.3365604785965,west:132.900301146355,south:34.2699035612027,east:133.00029426161,note:'明治31年測図',list:'s1577'},
    {name:'三津町',north:34.3365583691715,west:132.800310089628,south:34.2699014480611,east:132.900303189946,note:'明治31年測図',list:'s1584'}
]});
dataset.age.push({
  folderName:'00', start:1925, end:1932, scale:'1/25000', mapList: [
    {name:'戸山',north:34.5031944086832,west:132.250354383335,south:34.4198732531742,east:132.375345657344,note:'大正14年測図・昭和22.10.30発行',list:''},
    {name:'祇園',north:34.503197007217,west:132.375343129577,south:34.4198758577257,east:132.500334426861,note:'大正14年測図・昭和3.6.30発行',list:'115-10-1-1'},
    {name:'深川',north:34.5031996172574,west:132.500331887932,south:34.4198784737473,east:132.625323208534,note:'大正14年測図・昭和3.6.25発行',list:''},
    {name:'中地',north:34.4198706601051,west:132.250356899927,south:34.3365494890352,east:132.375348174716,note:'大正14年測図15年鉄補・昭和5.2.28発行',list:'115-10-4-1'},
    {name:'広島',north:34.4198732531742,west:132.375345657344,south:34.3365520880921,east:132.500336955351,note:'大正14年測図・昭和3.9.25発行',list:'115-10-2-1'},
    {name:'海田市',north:34.4198758577257,west:132.500334426861,south:34.3365546985949,east:132.625325748128,note:'大正14年測図・昭和5.1.30発行',list:'115-6-4-1'},
    {name:'厳島',north:34.3365469014365,west:132.250359406172,south:34.2532257147827,east:132.375350681738,note:'大正14年修正昭和7年鉄補・昭和22.10.30発行',list:''},
    {name:'似島',north:34.3365494890352,west:132.375348174716,south:34.2532283083393,east:132.500339473443,note:'大正14年測図・昭和22.10.30発行',list:''},
    {name:'吉浦',north:34.3365520880921,west:132.500336955351,south:34.2532309133176,east:132.625328277279,note:'大正14年測図・昭和3.10.25発行',list:''},
    {name:'阿多田島',north:34.25322313266,west:132.25036190211,south:34.1699019303995,east:132.375353178448,note:'大正14年測図・昭和22.10.30発行',list:''},
    {name:'江田島',north:34.2532257147827,west:132.375350681738,south:34.1699045184502,east:132.500341981179,note:'大正14年測図・昭和22.11.30発行',list:''},
    {name:'玖波',north:34.3365443219756,west:132.125370660774,south:34.2532231326602,east:132.25036191322,note:'昭和2年測図・昭和22.10.30発行',list:'115-15-1-2'},
    {name:'大竹',north:34.2532205619838,west:132.125373145617,south:34.1698993570917,east:132.250364398894,note:'昭和2年測図・昭和5.4.30発行',list:'115-15-2-10'},
    {name:'岩國',north:34.1698967918727,west:132.125375620242,south:34.0865755613822,east:132.250366874344,note:'昭和2年測図・昭和5.5.30発行',list:'115-16-1-8'},
    {name:'河内',north:34.5032075162943,west:132.875298247325,south:34.4198863938408,east:133.000289638126,note:'大正14年測図・昭和3.6.30発行',list:'115-2-1-1'},
    {name:'竹原',north:34.419883743484,west:132.875300819668,south:34.3365625953213,east:133.000292210962,note:'大正14年測図・昭和3.6.30発行',list:'115-2-2-1'},
    {name:'白市',north:34.5032048718086,west:132.750309452308,south:34.419883743484,east:132.875300819668,note:'大正14年測図・昭和3.4.30発行',list:'115-2-3-1'},
    {name:'田万里市',north:34.4198811045597,west:132.750312013525,south:34.3365599505556,east:132.875303381435,note:'大正14年測図・昭和3.6.30発行',list:'115-2-4-1'},
    {name:'明神',north:34.3365599505556,west:132.875303381435,south:34.2532387966584,east:133.000294773216,note:'大正14年測図・昭和2.4.30発行',list:'115-3-1-1'},
    {name:'三津',north:34.3365573171984,west:132.750314564212,south:34.2532361574897,east:132.875305932668,note:'大正14年測図・昭和3.4.30発行',list:'115-3-3-1'},
    {name:'可部',north:34.5865233633717,west:132.500329349632,south:34.5032022387922,east:132.625320669565,note:'大正14年測図・昭和2.10.30発行',list:'115-5-4-1'},
    {name:'西條',north:34.5032022387922,west:132.625320669565,south:34.4198811045597,east:132.750312013525,note:'大正14年測図・昭和3.4.30発行',list:'115-6-1-1'},
    {name:'原村',north:34.4198784770805,west:132.625323219644,south:34.3365573171984,east:132.750314564212,note:'大正14年測図・昭和5.2.28発行',list:'115-6-2-1'},
    {name:'毛木',north:34.5865207478481,west:132.375340602485,south:34.5031996172576,east:132.500331899043,note:'大正14年測図・昭和3.4.30発行',list:'115-9-2-1'}
]});
dataset.age.push({
  folderName:'01', start:1950, end:1954, scale:'1/25000', mapList: [
    {name:'戸山',north:34.5031944086832,west:132.250354383335,south:34.4198732531742,east:132.375345657344,note:'昭和25年二修・昭和31.11.25発行',list:''},
    {name:'祇園',north:34.503197007217,west:132.375343129577,south:34.4198758577257,east:132.500334426861,note:'昭和25年二修・昭和27.8.30発行',list:'115-10-1-3'},
    {name:'深川',north:34.5031996172574,west:132.500331887932,south:34.4198784737473,east:132.625323208534,note:'昭和25年二修・昭和27.2.28発行',list:''},
    {name:'廿日市',north:34.4198706601051,west:132.250356899927,south:34.3365494890352,east:132.375348174716,note:'昭和25年二修・昭和27.7.25発行',list:'115-10-4-4'},
    {name:'広島',north:34.4198732531742,west:132.375345657344,south:34.3365520880921,east:132.500336955351,note:'昭和25年二修・昭和27.11.30発行',list:'115-10-2-5'},
    {name:'海田市',north:34.4198758577257,west:132.500334426861,south:34.3365546985949,east:132.625325748128,note:'昭和25年二修・昭和27.9.30発行',list:'115-6-4-4'},
    {name:'厳島',north:34.3365469014365,west:132.250359406172,south:34.2532257147827,east:132.375350681738,note:'昭和25年二修・昭和27.8.30発行',list:''},
    {name:'似島',north:34.3365494890352,west:132.375348174716,south:34.2532283083393,east:132.500339473443,note:'昭和25年二修・昭和27.6.30発行',list:''},
    {name:'吉浦',north:34.3365520880921,west:132.500336955351,south:34.2532309133176,east:132.625328277279,note:'昭和25年二修・昭和35.5.30発行',list:''},
    {name:'阿多田島',north:34.25322313266,west:132.25036190211,south:34.1699019303995,east:132.375353178448,note:'昭和25年二修・昭和27.2.28発行',list:''},
    {name:'江田島',north:34.2532257147827,west:132.375350681738,south:34.1699045184502,east:132.500341981179,note:'昭和25年二修・昭和27.9.30発行',list:''},
    {name:'呉',north:34.2532283083393,west:132.500339473443,south:34.1699071178983,east:132.625330796028,note:'昭和25年二修・昭和27.10.30発行',list:''},
    {name:'玖波',north:34.3365443219756,west:132.125370660774,south:34.2532231326602,east:132.25036191322,note:'昭和29年資修・昭和31.11.30発行',list:'115-15-1-3'},
    {name:'大竹',north:34.2532205619838,west:132.125373145617,south:34.1698993570917,east:132.250364398894,note:'昭和29年資修・昭和31.11.30発行',list:'115-15-2-3'},
    {name:'岩国',north:34.1698967918727,west:132.125375620242,south:34.0865755613822,east:132.250366874344,note:'昭和28年二修・昭和31.11.30発行',list:'115-16-1-3'},
    {name:'河内',north:34.5032075162943,west:132.875298247325,south:34.4198863938408,east:133.000289638126,note:'昭和25年二修・昭和27.8.30発行',list:'115-2-1-3'},
    {name:'竹原',north:34.419883743484,west:132.875300819668,south:34.3365625953213,east:133.000292210962,note:'昭和25年二修・昭和27.8.30発行',list:'115-2-2-4'},
    {name:'白市',north:34.5032048718086,west:132.750309452308,south:34.419883743484,east:132.875300819668,note:'昭和25年二修・昭和27.3.30発行',list:'115-2-3-3'},
    {name:'田万里市',north:34.4198811045597,west:132.750312013525,south:34.3365599505556,east:132.875303381435,note:'昭和25年二修・昭和31.11.30発行',list:'115-2-4-3'},
    {name:'明神',north:34.3365599505556,west:132.875303381435,south:34.2532387966584,east:133.000294773216,note:'昭和25年二修・昭和31.11.30発行',list:'115-3-1-5'},
    {name:'三津',north:34.3365573171984,west:132.750314564212,south:34.2532361574897,east:132.875305932668,note:'昭和25年二修・昭和31.11.30発行',list:'115-3-3-3'},
    {name:'可部',north:34.5865233633717,west:132.500329349632,south:34.5032022387922,east:132.625320669565,note:'昭和28年二修・昭和31.11.30発行',list:'115-5-4-4'},
    {name:'西条',north:34.5032022387922,west:132.625320669565,south:34.4198811045597,east:132.750312013525,note:'昭和25年二修・昭和35.11.30発行',list:'115-6-1-4'},
    {name:'原村',north:34.4198784770805,west:132.625323219644,south:34.3365573171984,east:132.750314564212,note:'昭和25年二修・昭和31.11.30発行',list:'115-6-2-3'},
    {name:'安芸内海',north:34.3365546952622,west:132.625325759238,south:34.2532335297054,east:132.75031710441,note:'昭和25年修正・昭和27.9.30発行',list:'115-7-1-3'},
    {name:'仁方',north:34.2532309133178,west:132.625328288389,south:34.1699097320646,east:132.75031963416,note:'昭和25年二修・昭和31.11.30発行',list:'115-7-2-3'}
]});
dataset.age.push({
  folderName:'02', start:1967, end:1969, scale:'1/25000', mapList: [
    {name:'川角',north:34.5031943487643,west:132.247465754676,south:34.4198731931158,east:132.372457028147,note:'昭和42年改測・昭和45.3.30発行',list:''},
    {name:'祗園',north:34.503196947032,west:132.372454500639,south:34.4198757974021,east:132.497445797384,note:'昭和44年修正・昭和45.6.30発行',list:''},
    {name:'中深川',north:34.5031995568066,west:132.497443258713,south:34.4198784131587,east:132.622434578776,note:'昭和42年改測・昭和44.9.30発行',list:''},
    {name:'廿日市',north:34.4198706003122,west:132.24746827101,south:34.3365494291035,east:132.372459545263,note:'昭和44年修正・昭和45.5.30発行',list:''},
    {name:'広島',north:34.4198731931158,west:132.372457028147,south:34.3365520278957,east:132.497448325617,note:'昭和44年修正・昭和45.7.30発行',list:''},
    {name:'海田市',north:34.4198757974021,west:132.497445797384,south:34.3365546381341,east:132.622437118113,note:'昭和44年修正・昭和45.7.30発行',list:''},
    {name:'厳島',north:34.3365468417697,west:132.247470776997,south:34.2532256549778,east:132.372462052028,note:'昭和44年改測・昭和45.9.30発行',list:''},
    {name:'似島',north:34.3365494291035,west:132.372459545263,south:34.2532282482703,east:132.497450843453,note:'昭和43年改測・昭和45.3.30発行',list:''},
    {name:'吉浦',north:34.3365520278957,west:132.497448325617,south:34.2532308529848,east:132.622439647009,note:'昭和43年改測・昭和45.1.30発行',list:''},
    {name:'阿多田島',north:34.2532230731195,west:132.247473272679,south:34.1699018707216,east:132.372464548484,note:'昭和44年改測・昭和45.9.30発行',list:''},
    {name:'江田島',north:34.2532256549778,west:132.372462052028,south:34.1699044585088,east:132.497453350935,note:'昭和43年改測・昭和45.2.28発行',list:''},
    {name:'呉',north:34.2532282482703,west:132.497450843453,south:34.1699070576936,east:132.622442165504,note:'昭和43年改測・昭和45.3.30発行',list:''},
    {name:'玖波',north:34.3365442625738,west:132.122482020766,south:34.2532230731195,east:132.247473272679,note:'昭和44年改測・昭和45.9.30発行',list:'115-15-1-4'},
    {name:'大竹',north:34.2532205027078,west:132.122484505353,south:34.1698992976774,east:132.247475758097,note:'昭和44年改測・昭和45.9.30発行',list:'115-15-2-4'},
    {name:'岩国',north:34.1698967327225,west:132.122486979722,south:34.0865755020944,east:132.247478233293,note:'昭和44年改測・昭和45.9.30発行',list:'115-16-1-4'},
    {name:'河内',north:34.5032074550477,west:132.872409606147,south:34.419886332459,east:132.997400996406,note:'昭和40年改測・昭和42.6.30発行',list:'115-2-1-4'},
    {name:'竹原',north:34.4198836823661,west:132.872412178233,south:34.3365625340689,east:132.997403568985,note:'昭和40年改測・昭和42.6.30発行',list:'115-2-2-5'},
    {name:'白市',north:34.503204810827,west:132.747420811414,south:34.4198836823661,east:132.872412178233,note:'昭和40年改測・昭和42.5.30発行',list:'115-2-3-4'},
    {name:'田万里市',north:34.4198810437062,west:132.747423372374,south:34.3365598895667,east:132.872414739744,note:'昭和40年改測・昭和42.6.30発行',list:'115-2-4-4'},
    {name:'白水',north:34.3365598895667,west:132.872414739744,south:34.2532387355356,east:132.997406130986,note:'昭和40年改測・昭和43.3.30発行',list:'115-3-1-6'},
    {name:'三津',north:34.3365572564733,west:132.747425922804,south:34.2532360966299,east:132.872417290721,note:'昭和40年改測・昭和42.10.30発行',list:'115-3-3-6'},
    {name:'可部',north:34.5865233027937,west:132.497440709562,south:34.5032021780758,east:132.622432028954,note:'昭和42年改測・昭和45.1.30発行',list:'115-5-4-5'},
    {name:'安芸西条',north:34.5032021780758,west:132.622432028954,south:34.4198810437062,east:132.747423372374,note:'昭和42年改測・昭和44.11.30発行',list:'115-6-1-5'},
    {name:'清水原',north:34.4198784164917,west:132.622434578775,south:34.3365572564733,east:132.747425922804,note:'昭和43年改測・昭和45.3.30発行',list:'115-6-2-4'},
    {name:'安芸内海',north:34.3365546348012,west:132.622437118113,south:34.2532334691088,east:132.747428462747,note:'昭和43年改測・昭和45.3.30発行',list:'115-7-1-4'},
    {name:'仁方',north:34.2532308529848,west:132.622439647009,south:34.1699096715967,east:132.747430992243,note:'昭和43年改測・昭和45.3.30発行',list:'115-7-2-4'},
    {name:'飯室',north:34.5865206875365,west:132.372451962696,south:34.5031995568066,east:132.497443258713,note:'昭和42年改測・昭和44.9.30発行',list:'115-9-2-5B'}
]});
dataset.age.push({
  folderName:'03', start:1984, end:1990, scale:'1/25000', mapList: [
    {name:'川角',north:34.5031943487643,west:132.247465754676,south:34.4198731931158,east:132.372457028147,note:'昭和62年修正・昭和63.10.30発行',list:''},
    {name:'祗園',north:34.503196947032,west:132.372454500639,south:34.4198757974021,east:132.497445797384,note:'昭和62年修正・平成1.1.30発行',list:''},
    {name:'中深川',north:34.5031995568066,west:132.497443258713,south:34.4198784131587,east:132.622434578776,note:'昭和62年修正・昭和63.8.30発行',list:''},
    {name:'廿日市',north:34.4198706003122,west:132.24746827101,south:34.3365494291035,east:132.372459545263,note:'昭和62年修正・昭和63.4.1発行',list:''},
    {name:'広島',north:34.4198731931158,west:132.372457028147,south:34.3365520278957,east:132.497448325617,note:'昭和62年修正・昭和63.4.30発行',list:''},
    {name:'海田市',north:34.4198757974021,west:132.497445797384,south:34.3365546381341,east:132.622437118113,note:'昭和62年修正・昭和63.3.30発行',list:''},
    {name:'厳島',north:34.3365468417697,west:132.247470776997,south:34.2532256549778,east:132.372462052028,note:'昭和62年修正・昭和63.4.1発行',list:''},
    {name:'似島',north:34.3365494291035,west:132.372459545263,south:34.2532282482703,east:132.497450843453,note:'昭和62年修正・昭和63.3.30発行',list:''},
    {name:'吉浦',north:34.3365520278957,west:132.497448325617,south:34.2532308529848,east:132.622439647009,note:'昭和62年修正・平成1.2.28発行',list:''},
    {name:'阿多田島',north:34.2532230731195,west:132.247473272679,south:34.1699018707216,east:132.372464548484,note:'昭和62年修正・昭和63.12.28発行',list:''},
    {name:'江田島',north:34.2532256549778,west:132.372462052028,south:34.1699044585088,east:132.497453350935,note:'昭和62年修正・平成1.2.28発行',list:''},
    {name:'呉',north:34.2532282482703,west:132.497450843453,south:34.1699070576936,east:132.622442165504,note:'昭和62年修正・平成1.2.28発行',list:''},
    {name:'玖波',north:34.3365442625738,west:132.122482020766,south:34.2532230731195,east:132.247473272679,note:'昭和59年修正・昭和61.11.30発行',list:'115-15-1-8'},
    {name:'大竹',north:34.2532205027078,west:132.122484505353,south:34.1698992976774,east:132.247475758097,note:'昭和59年修正・昭和61.10.30発行',list:'115-15-2-9'},
    {name:'岩国',north:34.1698967327225,west:132.122486979722,south:34.0865755020944,east:132.247478233293,note:'昭和59年修正・昭和61.11.30発行',list:'115-16-1-9'},
    {name:'河内',north:34.5032074550477,west:132.872409606147,south:34.419886332459,east:132.997400996406,note:'昭和63年修正・平成1.7.1発行',list:'115-2-1-7'},
    {name:'竹原',north:34.4198836823661,west:132.872412178233,south:34.3365625340689,east:132.997403568985,note:'昭和63年修正・平成2.4.1発行',list:'115-2-2-9'},
    {name:'白市',north:34.503204810827,west:132.747420811414,south:34.4198836823661,east:132.872412178233,note:'平成2年部修・平成3.4.1発行',list:'115-2-3-7B'},
    {name:'田万里市',north:34.4198810437062,west:132.747423372374,south:34.3365598895667,east:132.872414739744,note:'昭和63年修正・平成1.12.1発行',list:'115-2-4-7'},
    {name:'白水',north:34.3365598895667,west:132.872414739744,south:34.2532387355356,east:132.997406130986,note:'昭和62年修正・昭和63.10.30発行',list:'115-3-1-10B'},
    {name:'三津',north:34.3365572564733,west:132.747425922804,south:34.2532360966299,east:132.872417290721,note:'昭和62年修正・平成1.1.30発行',list:'115-3-3-9'},
    {name:'可部',north:34.5865233027937,west:132.497440709562,south:34.5032021780758,east:132.622432028954,note:'昭和59年修正・昭和60.12.28発行',list:'115-5-4-8B'},
    {name:'安芸西条',north:34.5032021780758,west:132.622432028954,south:34.4198810437062,east:132.747423372374,note:'昭和62年修正・昭和63.6.30発行',list:'115-6-1-9'},
    {name:'清水原',north:34.4198784164917,west:132.622434578775,south:34.3365572564733,east:132.747425922804,note:'昭和62年修正・昭和63.7.30発行',list:'115-6-2-8B'},
    {name:'安芸内海',north:34.3365546348012,west:132.622437118113,south:34.2532334691088,east:132.747428462747,note:'昭和62年修正・昭和63.8.30発行',list:'115-7-1-8'},
    {name:'仁方',north:34.2532308529848,west:132.622439647009,south:34.1699096715967,east:132.747430992243,note:'昭和62年修正・昭和63.8.30発行',list:'115-7-2-8'},
    {name:'飯室',north:34.5865206875365,west:132.372451962696,south:34.5031995568066,east:132.497443258713,note:'昭和59年修正・昭和61.1.30発行',list:'115-9-2-7B'}
]});
dataset.age.push({
  folderName:'04', start:1992, end:2001, scale:'1/25000', mapList: [
    {name:'川角',north:34.5031943487643,west:132.247465754676,south:34.4198731931158,east:132.372457028147,note:'平成4年修正・平成5.4.1発行',list:''},
    {name:'祗園',north:34.503196947032,west:132.372454500639,south:34.4198757974021,east:132.497445797384,note:'平成11年部修・平成11.11.1発行',list:''},
    {name:'中深川',north:34.5031995568066,west:132.497443258713,south:34.4198784131587,east:132.622434578776,note:'平成8年部修・平成9.6.1発行',list:''},
    {name:'廿日市',north:34.4198706003122,west:132.24746827101,south:34.3365494291035,east:132.372459545263,note:'平成11年部修・平成12.4.1発行',list:''},
    {name:'広島',north:34.4198731931158,west:132.372457028147,south:34.3365520278957,east:132.497448325617,note:'平成11年部修・平成11.9.1発行',list:''},
    {name:'海田市',north:34.4198757974021,west:132.497445797384,south:34.3365546381341,east:132.622437118113,note:'平成9年修正・平成10.11.1発行',list:''},
    {name:'厳島',north:34.3365468417697,west:132.247470776997,south:34.2532256549778,east:132.372462052028,note:'平成9年部修・平成10.3.1発行',list:''},
    {name:'似島',north:34.3365494291035,west:132.372459545263,south:34.2532282482703,east:132.497450843453,note:'平成10年部修・平成10.12.1発行',list:''},
    {name:'吉浦',north:34.3365520278957,west:132.497448325617,south:34.2532308529848,east:132.622439647009,note:'平成11年部修・平成11.8.1発行',list:''},
    {name:'阿多田島',north:34.2532230731195,west:132.247473272679,south:34.1699018707216,east:132.372464548484,note:'平成12年修正・平成13.6.1発行',list:''},
    {name:'江田島',north:34.2532256549778,west:132.372462052028,south:34.1699044585088,east:132.497453350935,note:'平成12年修正・平成13.5.1発行',list:''},
    {name:'呉',north:34.2532282482703,west:132.497450843453,south:34.1699070576936,east:132.622442165504,note:'平成11年部修・平成12.4.1発行',list:''},
    {name:'玖波',north:34.3365442625738,west:132.122482020766,south:34.2532230731195,east:132.247473272679,note:'平成12年修正・平成13.10.1発行',list:'115-15-1-10B'},
    {name:'大竹',north:34.2532205027078,west:132.122484505353,south:34.1698992976774,east:132.247475758097,note:'平成8年修正・平成9.9.1発行',list:'115-15-2-13B'},
    {name:'岩国',north:34.1698967327225,west:132.122486979722,south:34.0865755020944,east:132.247478233293,note:'平成13年修正・平成14.10.1発行',list:'115-16-1-13B'},
    {name:'河内',north:34.5032074550477,west:132.872409606147,south:34.419886332459,east:132.997400996406,note:'平成12年修正・平成14.3.1発行',list:'115-2-1-10'},
    {name:'竹原',north:34.4198836823661,west:132.872412178233,south:34.3365625340689,east:132.997403568985,note:'平成12年修正・平成14.2.1発行',list:'115-2-2-12'},
    {name:'白市',north:34.503204810827,west:132.747420811414,south:34.4198836823661,east:132.872412178233,note:'平成12年修正・平成13.9.1発行',list:'115-2-3-10B'},
    {name:'田万里市',north:34.4198810437062,west:132.747423372374,south:34.3365598895667,east:132.872414739744,note:'平成12年修正・平成13.11.1発行',list:'115-2-4-9'},
    {name:'白水',north:34.3365598895667,west:132.872414739744,south:34.2532387355356,east:132.997406130986,note:'平成11年修正・平成12.1.1発行',list:'115-3-1-11B'},
    {name:'三津',north:34.3365572564733,west:132.747425922804,south:34.2532360966299,east:132.872417290721,note:'平成11年修正・平成12.9.1発行',list:'115-3-3-10B'},
    {name:'可部',north:34.5865233027937,west:132.497440709562,south:34.5032021780758,east:132.622432028954,note:'平成12年修正・平成13.10.1発行',list:'115-5-4-11'},
    {name:'安芸西条',north:34.5032021780758,west:132.622432028954,south:34.4198810437062,east:132.747423372374,note:'平成12年修正・平成13.9.1発行',list:'115-6-1-13B'},
    {name:'清水原',north:34.4198784164917,west:132.622434578775,south:34.3365572564733,east:132.747425922804,note:'平成9年修正・平成10.12.1発行',list:'115-6-2-10B'},
    {name:'安芸内海',north:34.3365546348012,west:132.622437118113,south:34.2532334691088,east:132.747428462747,note:'平成12年修正・平成14.2.1発行',list:'115-7-1-11'},
    {name:'仁方',north:34.2532308529848,west:132.622439647009,south:34.1699096715967,east:132.747430992243,note:'平成12年修正・平成13.6.1発行',list:'115-7-2-11B'},
    {name:'飯室',north:34.5865206875365,west:132.372451962696,south:34.5031995568066,east:132.497443258713,note:'平成12年修正・平成13.7.1発行',list:'115-9-2-9B'}
]});
kjmapDataSet['yamaguchi'] = new Object();
dataset = kjmapDataSet['yamaguchi'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1897, end:1909, scale:'1/20000', mapList: [
    {name:'矢田',north:34.2032136340202,west:131.500430938813,south:34.1365566331426,east:131.600423848311,note:'明治32年測図 ・明治34.9.30発行',list:'s1403'},
    {name:'上右田',north:34.1365546294276,west:131.500432870191,south:34.0698976286571,east:131.600425780403,note:'明治32年測図 ・明治34.9.30発行',list:'s1404'},
    {name:'三田尻',north:34.0698956283598,west:131.500434795212,south:34.0032386076871,east:131.600427706134,note:'明治32年測図 ・明治34.12.28発行',list:'s1405'},
    {name:'山口',north:34.2032116342529,west:131.400439975273,south:34.1365546294276,east:131.500432870191,note:'明治32年測図 ・明治34.9.30発行',list:'s1408'},
    {name:'陶',north:34.1365526330627,west:131.400441899551,south:34.0698956283598,east:131.500434795212,note:'明治32年測図 ・明治34.9.30発行',list:'s1410'},
    {name:'臺道',north:34.0698936354,west:131.400443817494,south:34.0032366108103,east:131.500436713895,note:'明治32年測図 ・明治34.12.28発行',list:'s1412'},
    {name:'小郡',north:34.1365506440539,west:131.300450936362,south:34.0698936354,east:131.400443817494,note:'明治32年測図 ・明治34.9.30発行',list:'s1416'},
    {name:'阿知須',north:34.0698916497839,west:131.300452847222,south:34.0032346212586,east:131.400445729123,note:'明治32年測図 ・明治34.12.28発行',list:'s1418'},
    {name:'床波',north:34.0032326390379,west:131.300454751791,south:33.9365756006283,east:131.400447634457,note:'明治32年測図 ・明治34.12.28発行',list:'s1419'},
    {name:'厚狹市',north:34.0698877006068,west:131.100470928907,south:34.0032306641543,east:131.200463781873,note:'明治42年鉄補 ・大正8.5.30発行',list:'s1737'},
    {name:'小野田',north:34.0032286966139,west:131.100472819339,south:33.9291007779741,east:131.200465673128,note:'明治30年測図 ・大正8.5.30発行',list:'s1738'}
]});
dataset.age.push({
  folderName:'00', start:1922, end:1927, scale:'1/25000', mapList: [
    {name:'山口',north:34.2532053789776,west:131.375440789512,south:34.169884137532,east:131.500431905298,note:'昭和2年測図・昭和5.7.30発行',list:'119-11-2-1'},
    {name:'小郡',north:34.1698816410991,west:131.375443197597,south:34.0865603742347,east:131.500434314552,note:'昭和2年測図・昭和5.9.30発行',list:'119-12-1-1'},
    {name:'臺道',north:34.0865578831183,west:131.375445595778,south:34.0032366108103,east:131.500436713895,note:'昭和2年測図・昭和5.9.30発行',list:'119-12-2-1'},
    {name:'阿知須',north:34.0865554034836,west:131.250456888631,south:34.0032341250159,east:131.375447984094,note:'昭和2年測図・昭和5.4.30発行',list:'119-12-4-1'},
    {name:'舩木',north:34.0865529353424,west:131.125468193056,south:34.0032316506786,east:131.250459265907,note:'大正11年測図・大正15.5.30発行',list:'119-16-2-1'},
    {name:'仁保',north:34.2532078807216,west:131.500429486094,south:34.1698866454593,east:131.62542062469,note:'昭和2年測図・昭和5.6.30発行',list:'119-7-4-1'},
    {name:'矢田',north:34.169884137532,west:131.500431905298,south:34.0865628768211,east:131.625423045005,note:'昭和2年測図・昭和5.6.30発行',list:'119-8-3-1'},
    {name:'防府',north:34.0865603742347,west:131.500434314552,south:34.0032391080502,east:131.625425455364,note:'昭和2年測図・昭和5.6.30発行',list:'119-8-4-1'},
    {name:'宇部',north:34.0032291878103,west:131.125470559282,south:33.9199078877413,east:131.250461633403,note:'大正11年測図・大正14.4.30発行',list:'120-13-1-1'},
    {name:'宇部東部',north:34.0032316506786,west:131.250459265907,south:33.9199103567758,east:131.375450362583,note:'昭和2年測図・昭和5.2.28発行',list:'120-9-3-1'}
]});
dataset.age.push({
  folderName:'01', start:1936, end:1951, scale:'1/25000', mapList: [
    {name:'山口',north:34.2532053789776,west:131.375440789512,south:34.169884137532,east:131.500431905298,note:'昭和26年二修・昭和29.5.30発行',list:'119-11-2-3'},
    {name:'小郡',north:34.1698816410991,west:131.375443197597,south:34.0865603742347,east:131.500434314552,note:'昭和26年二修・昭和29.3.30発行',list:'119-12-1-5'},
    {name:'台道',north:34.0865578831183,west:131.375445595778,south:34.0032366108103,east:131.500436713895,note:'昭和26年修正・昭和29.7.30発行',list:'119-12-2-3'},
    {name:'阿知須',north:34.0865554034836,west:131.250456888631,south:34.0032341250159,east:131.375447984094,note:'昭和26年修正・昭和29.9.30発行',list:'119-12-4-3'},
    {name:'船木',north:34.0865529353424,west:131.125468193056,south:34.0032316506786,east:131.250459265907,note:'昭和11年二修・昭和12.5.30発行',list:'119-16-2-3'},
    {name:'仁保',north:34.2532078807216,west:131.500429486094,south:34.1698866454593,east:131.62542062469,note:'昭和26年修正・昭和31.11.30発行',list:'119-7-4-3'},
    {name:'矢田',north:34.169884137532,west:131.500431905298,south:34.0865628768211,east:131.625423045005,note:'昭和26年修正・昭和28.11.30発行',list:'119-8-3-3'},
    {name:'防府',north:34.0865603742347,west:131.500434314552,south:34.0032391080502,east:131.625425455364,note:'昭和26年修正・昭和29.5.30発行',list:'119-8-4-3'},
    {name:'宇部',north:34.0032291878103,west:131.125470559282,south:33.9199078877413,east:131.250461633403,note:'昭和11年二修・昭和12.6.30発行',list:'120-13-1-4'},
    {name:'宇部東部',north:34.0032316506786,west:131.250459265907,south:33.9199103567758,east:131.375450362583,note:'昭和26年修正・昭和28.11.30発行',list:'120-9-3-3'}
]});
dataset.age.push({
  folderName:'02', start:1969, end:1969, scale:'1/25000', mapList: [
    {name:'山口',north:34.2532053212956,west:131.372552150886,south:34.1698840797067,east:131.497543266145,note:'昭和44年改測・昭和47.2.28発行',list:'119-11-2-4'},
    {name:'小郡',north:34.1698815835395,west:131.372554558714,south:34.0865603165325,east:131.497545675143,note:'昭和44年改測・昭和46.2.28発行',list:'119-12-1-6'},
    {name:'台道',north:34.0865578256813,west:131.372556956639,south:34.0032365532314,east:131.497548074231,note:'昭和44年改測・昭和46.2.28発行',list:'119-12-2-4'},
    {name:'阿知須',north:34.0865553463121,west:131.247568249759,south:34.0032340677016,east:131.372559344699,note:'昭和44年改測・昭和46.2.28発行',list:'119-12-4-4'},
    {name:'厚狭',north:34.0865528784367,west:131.122579554451,south:34.0032315936292,east:131.24757062678,note:'昭和44年改測・昭和46.2.28発行',list:'119-16-2-6'},
    {name:'仁保',north:34.2532078227732,west:131.497540847198,south:34.1698865873685,east:131.622531985266,note:'昭和44年改測・昭和47.2.28発行',list:'119-7-4-4'},
    {name:'矢田',north:34.1698840797067,west:131.497543266145,south:34.0865628188539,east:131.622534405326,note:'昭和44年改測・昭和46.2.28発行',list:'119-8-3-4'},
    {name:'防府',north:34.0865603165325,west:131.497545675143,south:34.0032390502069,east:131.62253681543,note:'昭和44年改測・昭和46.2.28発行',list:'119-8-4-4'},
    {name:'宇部',north:34.0032291310261,west:131.122581920422,south:33.9199078308142,east:131.247572994022,note:'昭和44年改測・昭和46.2.28発行',list:'120-13-1-9'},
    {name:'宇部東部',north:34.0032315936292,west:131.24757062678,south:33.9199102995843,east:131.372561722934,note:'昭和44年改測・昭和46.2.28発行',list:'120-9-3-4'}
]});
dataset.age.push({
  folderName:'03', start:1983, end:1989, scale:'1/25000', mapList: [
    {name:'山口',north:34.2532053212956,west:131.372552150886,south:34.1698840797067,east:131.497543266145,note:'昭和63年修正・平成1.10.1発行',list:'119-11-2-8B'},
    {name:'小郡',north:34.1698815835395,west:131.372554558714,south:34.0865603165325,east:131.497545675143,note:'昭和60年修正・昭和61.11.30発行',list:'119-12-1-10'},
    {name:'台道',north:34.0865578256813,west:131.372556956639,south:34.0032365532314,east:131.497548074231,note:'昭和60年修正・昭和61.9.30発行',list:'119-12-2-8'},
    {name:'阿知須',north:34.0865553463121,west:131.247568249759,south:34.0032340677016,east:131.372559344699,note:'昭和60年修正・昭和62.9.30発行',list:'119-12-4-8B'},
    {name:'厚狭',north:34.0865528784367,west:131.122579554451,south:34.0032315936292,east:131.24757062678,note:'平成1年修正・平成2.9.1発行',list:'119-16-2-11'},
    {name:'仁保',north:34.2532078227732,west:131.497540847198,south:34.1698865873685,east:131.622531985266,note:'昭和58年修正・昭和61.2.28発行',list:'119-7-4-6'},
    {name:'矢田',north:34.1698840797067,west:131.497543266145,south:34.0865628188539,east:131.622534405326,note:'昭和60年修正・昭和61.2.28発行',list:'119-8-3-7'},
    {name:'防府',north:34.0865603165325,west:131.497545675143,south:34.0032390502069,east:131.62253681543,note:'昭和60年修正・昭和61.1.30発行',list:'119-8-4-9'},
    {name:'宇部',north:34.0032291310261,west:131.122581920422,south:33.9199078308142,east:131.247572994022,note:'昭和60年修正・昭和62.9.30発行',list:'120-13-1-13B'},
    {name:'宇部東部',north:34.0032315936292,west:131.24757062678,south:33.9199102995843,east:131.372561722934,note:'昭和60年修正・昭和61.12.28発行',list:'120-9-3-8'}
]});
dataset.age.push({
  folderName:'04', start:2000, end:2001, scale:'1/25000', mapList: [
    {name:'山口',north:34.2532053212956,west:131.372552150886,south:34.1698840797067,east:131.497543266145,note:'平成13年修正・平成15.2.1発行',list:'119-11-2-10'},
    {name:'小郡',north:34.1698815835395,west:131.372554558714,south:34.0865603165325,east:131.497545675143,note:'平成13年修正・平成14.9.1発行',list:'119-12-1-13'},
    {name:'台道',north:34.0865578256813,west:131.372556956639,south:34.0032365532314,east:131.497548074231,note:'平成13年修正・平成15.10.1発行',list:'119-12-2-11'},
    {name:'阿知須',north:34.0865553463121,west:131.247568249759,south:34.0032340677016,east:131.372559344699,note:'平成13年修正・平成15.4.1発行',list:'119-12-4-11'},
    {name:'厚狭',north:34.0865528784367,west:131.122579554451,south:34.0032315936292,east:131.24757062678,note:'平成12年修正・平成14.1.1発行',list:'119-16-2-13B'},
    {name:'仁保',north:34.2532078227732,west:131.497540847198,south:34.1698865873685,east:131.622531985266,note:'平成13年修正・平成15.5.1発行',list:'119-7-4-9'},
    {name:'矢田',north:34.1698840797067,west:131.497543266145,south:34.0865628188539,east:131.622534405326,note:'平成13年修正・平成14.6.1発行',list:'119-8-3-10'},
    {name:'防府',north:34.0865603165325,west:131.497545675143,south:34.0032390502069,east:131.62253681543,note:'平成13年修正・平成15.2.1発行',list:'119-8-4-13'},
    {name:'宇部',north:34.0032291310261,west:131.122581920422,south:33.9199078308142,east:131.247572994022,note:'平成12年修正・平成13.11.1発行',list:'120-13-1-17'},
    {name:'宇部東部',north:34.0032315936292,west:131.24757062678,south:33.9199102995843,east:131.372561722934,note:'平成12年修正・平成13.12.1発行',list:'120-9-3-11'}
]});
kjmapDataSet['tokushima'] = new Object();
dataset = kjmapDataSet['tokushima'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1896, end:1909, scale:'1/20000', mapList: [
    {name:'鳴門海峡',north:34.2699383572427,west:134.600152501259,south:34.203281479804,east:134.700145873425,note:'明治29年測図',list:'s1362'},
    {name:'撫養町',north:34.203279247573,west:134.600154656831,south:34.1366223597792,east:134.700148028803,note:'明治29年測図',list:'s1363'},
    {name:'堂浦',north:34.2699361283919,west:134.500161299923,south:34.203279247573,east:134.600154656831,note:'明治29年修正',list:'s1364'},
    {name:'板東',north:34.2032770225048,west:134.500163448564,south:34.1366201313461,east:134.600156805308,note:'明治29年測図',list:'s1365'},
    {name:'長原浦',north:34.1366201313461,west:134.600156805308,south:34.0699632431844,east:134.700150177086,note:'明治29年測図',list:'s2000'},
    {name:'徳嶋北部',north:34.1366179100637,west:134.500165590133,south:34.0699610185522,east:134.600158946711,note:'明治42年測図・明治43.10.30発行',list:'s2002'},
    {name:'大寺',north:34.2032748046064,west:134.400172248597,south:34.1366179100637,east:134.500165590133,note:'明治29年測図・明治32.4.30発行',list:'s2004'},
    {name:'高畑',north:34.1366156959387,west:134.400174383251,south:34.0699588010586,east:134.50016772465,note:'明治29年測図・明治32.4.30発行',list:'s2005'},
    {name:'石井',north:34.0699565907103,west:134.400176510876,south:34.0032996754833,east:134.500169852141,note:'明治29年修正・明治32.4.30発行',list:'s2006'}
]});
dataset.age.push({
  folderName:'00', start:1917, end:1917, scale:'1/25000', mapList: [
    {name:'大寺',north:34.1699447032085,west:134.37517551724,south:34.0866235739262,east:134.500167191681,note:'大正6年測図・大正9.5.30発行',list:'105-12-1-1'},
    {name:'石井',north:34.0866208109279,west:134.375178177906,south:34.0032996754833,east:134.500169852141,note:'大正6年測図・大正9.11.30発行',list:'105-12-2-1'},
    {name:'市場',north:34.1699419455198,west:134.250186527161,south:34.0866208109279,east:134.375178177906,note:'大正6年測図・大正9.5.30発行',list:'105-12-3-1'},
    {name:'川島',north:34.0866180591121,west:134.250189177031,south:34.0032969183879,east:134.375180827627,note:'大正6年測図・大正9.4.30発行',list:'105-12-4-1'},
    {name:'板東',north:34.1699474721035,west:134.500164520231,south:34.0866266157795,east:134.637190162585,note:'大正6年測図・大正9.10.25発行',list:'105-8-3-2'},
    {name:'德島',north:34.0866235739262,west:134.500167191681,south:34.0033024437242,east:134.625158889593,note:'大正6年測図・大正9.11.30発行',list:'105-8-4-1'},
    {name:'富岡',north:34.0033024437242,west:134.625158889593,south:33.9199813024838,east:134.750150610902,note:'大正6年測図・大正9.4.30発行',list:'106-5-1-1'},
    {name:'橘',north:33.9199785290674,west:134.62516154979,south:33.8366573615614,east:134.750153270779,note:'大正6年測図・大正9.4.30発行',list:'106-5-2-1'},
    {name:'立江',north:34.0032996754833,west:134.500169852141,south:33.9199785290674,east:134.62516154979,note:'大正6年測図・大正9.6.30発行',list:'106-5-3-1'}
]});
dataset.age.push({
  folderName:'01', start:1928, end:1934, scale:'1/25000', mapList: [
    {name:'大寺',north:34.1699447032085,west:134.37517551724,south:34.0866235739262,east:134.500167191681,note:'昭和9年二修・昭和12.4.30発行',list:'105-12-1-3'},
    {name:'石井',north:34.0866208109279,west:134.375178177906,south:34.0032996754833,east:134.500169852141,note:'昭和9年二修・昭和12.4.30発行',list:'105-12-2-2'},
    {name:'市場',north:34.1699419455198,west:134.250186527161,south:34.0866208109279,east:134.375178177906,note:'昭和9年修正・昭和11.12.28発行',list:'105-12-3-2'},
    {name:'川島',north:34.0866180591121,west:134.250189177031,south:34.0032969183879,east:134.375180827627,note:'昭和9年修正・昭和22.10.30発行',list:'105-12-4-3'},
    {name:'鳴門海峡',north:34.253274136037,west:134.625150842887,south:34.1699530434596,east:134.750142565156,note:'昭和3年測図・昭和7.4.25発行',list:'105-7-2-1'},
    {name:'板東',north:34.1699474721035,west:134.500164520231,south:34.0866266436172,east:134.638441352816,note:'昭和9年二修・昭和11.11.25発行',list:'105-8-3-4'},
    {name:'德島',north:34.0866235739262,west:134.500167191681,south:34.0033024437242,east:134.625158889593,note:'昭和9年二修・昭和12.2.28発行',list:'105-8-4-2'},
    {name:'阿波富岡',north:34.0033024437242,west:134.625158889593,south:33.9199813024838,east:134.750150610902,note:'昭和9年修正・昭和11.8.30発行',list:'106-5-1-2'},
    {name:'橘',north:33.9199785290674,west:134.62516154979,south:33.8366573615614,east:134.750153270779,note:'昭和9年修正・昭和11.8.30発行',list:'106-5-2-2'},
    {name:'立江',north:34.0032996754833,west:134.500169852141,south:33.9199785290674,east:134.62516154979,note:'昭和9年修正・昭和11.6.30発行',list:'106-5-3-2'}
]});
dataset.age.push({
  folderName:'02', start:1969, end:1970, scale:'1/25000', mapList: [
    {name:'大寺',north:34.1699446393484,west:134.372286871547,south:34.0866235099438,east:134.49727854544,note:'昭和44年改測・昭和46.2.28発行',list:'105-12-1-7'},
    {name:'石井',north:34.0866207472039,west:134.372289531964,south:34.0032996116377,east:134.497281205652,note:'昭和44年改測・昭和46.2.28発行',list:'105-12-2-5'},
    {name:'市場',north:34.1699418819189,west:134.247297881766,south:34.0866207472039,east:134.372289531964,note:'昭和44年改測・昭和46.2.28発行',list:'105-12-3-4'},
    {name:'川島',north:34.0866179956466,west:134.247300531386,south:34.0032968548,east:134.372292181437,note:'昭和44年改測・昭和46.2.28発行',list:'105-12-4-6'},
    {name:'鳴門海峡',north:34.2532740715226,west:134.622262196845,south:34.1699529788239,east:134.747253918562,note:'昭和45年改測・昭和46.11.30発行',list:'105-7-2-4'},
    {name:'撫養',north:34.2532712857791,west:134.497273192006,south:34.1699501878142,east:134.622264889893,note:'昭和44年改測・昭和46.9.30発行',list:'105-7-4-3'},
    {name:'板東',north:34.1699474079846,west:134.497275874239,south:34.0866266675047,east:134.639514958628,note:'昭和44年改測・昭和46.1.30発行',list:'105-8-3-7'},
    {name:'徳島',north:34.0866235099438,west:134.49727854544,south:34.0033023796211,east:134.622270242804,note:'昭和44年改測・昭和46.1.30発行',list:'105-8-4-5'},
    {name:'阿波富岡',north:34.0120851665793,west:134.622269961792,south:33.9199812382615,east:134.747261963566,note:'昭和44年改測・昭和46.2.28発行',list:'106-5-1-7'},
    {name:'橘',north:33.9199784651016,west:134.622272902754,south:33.8366572974771,east:134.747264623197,note:'昭和44年改測・昭和45.9.30発行',list:'106-5-2-5'},
    {name:'立江',north:34.0032996116377,west:134.497281205652,south:33.9199784651016,east:134.622272902754,note:'昭和44年改測・昭和46.2.28発行',list:'106-5-3-6'}
]});
dataset.age.push({
  folderName:'03', start:1981, end:1987, scale:'1/25000', mapList: [
    {name:'大寺',north:34.1699446393484,west:134.372286871547,south:34.0866235099438,east:134.49727854544,note:'昭和62年修正・昭和63.12.28発行',list:'105-12-1-10'},
    {name:'石井',north:34.0866207472039,west:134.372289531964,south:34.0032996116377,east:134.497281205652,note:'昭和62年修正・平成1.1.30発行',list:'105-12-2-8'},
    {name:'市場',north:34.1699418819189,west:134.247297881766,south:34.0866207472039,east:134.372289531964,note:'昭和62年修正・昭和63.8.30発行',list:'105-12-3-7'},
    {name:'川島',north:34.0866179956466,west:134.247300531386,south:34.0032968548,east:134.372292181437,note:'昭和62年修正・昭和63.8.30発行',list:'105-12-4-10'},
    {name:'鳴門海峡',north:34.2532740715226,west:134.622262196845,south:34.1699529788239,east:134.747253918562,note:'昭和60年部修・昭和62.1.30発行',list:'105-7-2-7'},
    {name:'撫養',north:34.2532712857791,west:134.497273192006,south:34.1699501878142,east:134.622264889893,note:'昭和56年修正・昭和58.2.28発行',list:'105-7-4-6B'},
    {name:'板東',north:34.1699474079846,west:134.497275874239,south:34.0866266794032,east:134.640049711714,note:'昭和62年修正・昭和63.11.30発行',list:'105-8-3-12'},
    {name:'徳島',north:34.0866235099438,west:134.49727854544,south:34.0033023796211,east:134.622270242804,note:'昭和62年修正・昭和63.11.30発行',list:'105-8-4-9'},
    {name:'阿波富岡',north:34.0123103711147,west:134.622269954584,south:33.9199812382615,east:134.747261963566,note:'昭和62年修正・昭和63.9.30発行',list:'106-5-1-13'},
    {name:'橘',north:33.9199784651016,west:134.622272902754,south:33.8366572974771,east:134.747264623197,note:'昭和62年修正・昭和63.12.28発行',list:'106-5-2-9'},
    {name:'立江',north:34.0032996116377,west:134.497281205652,south:33.9199784651016,east:134.622272902754,note:'昭和62年修正・昭和63.10.30発行',list:'106-5-3-9'}
]});
dataset.age.push({
  folderName:'04', start:1997, end:2000, scale:'1/25000', mapList: [
    {name:'大寺',north:34.1699446393484,west:134.372286871547,south:34.0866235099438,east:134.49727854544,note:'平成12年修正・平成13.3.29発行',list:'105-12-1-15B'},
    {name:'石井',north:34.0866207472039,west:134.372289531964,south:34.0032996116377,east:134.497281205652,note:'平成11年部修・平成11.10.1発行',list:'105-12-2-10B'},
    {name:'市場',north:34.1699418819189,west:134.247297881766,south:34.0866207472039,east:134.372289531964,note:'平成12年修正・平成14.2.1発行',list:'105-12-3-11'},
    {name:'川島',north:34.0866179956466,west:134.247300531386,south:34.0032968548,east:134.372292181437,note:'平成12年修正・平成13.12.1発行',list:'105-12-4-13'},
    {name:'鳴門海峡',north:34.2532740715226,west:134.622262196845,south:34.1699529788239,east:134.747253918562,note:'平成12年修正・平成13.12.1発行',list:'105-7-2-9'},
    {name:'撫養',north:34.2532712857791,west:134.497273192006,south:34.1699501878142,east:134.622264889893,note:'平成12年修正・平成14.2.1発行',list:'105-7-4-9'},
    {name:'板東',north:34.1699474079846,west:134.497275874239,south:34.0866265688386,east:134.635080247693,note:'平成9年修正・平成10.12.1発行',list:'105-8-3-15B'},
    {name:'徳島',north:34.0866235099438,west:134.49727854544,south:34.0033023796211,east:134.622270242804,note:'平成11年部修・平成12.2.1発行',list:'105-8-4-12B'},
    {name:'阿波富岡',north:34.0119608706339,west:134.622269965769,south:33.9199812382615,east:134.747261963566,note:'平成9年修正・平成10.11.1発行',list:'106-5-1-15'},
    {name:'橘',north:33.9199784651016,west:134.622272902754,south:33.8366572974771,east:134.747264623197,note:'平成9年修正・平成10.10.1発行',list:'106-5-2-11'},
    {name:'立江',north:34.0032996116377,west:134.497281205652,south:33.9199784651016,east:134.622272902754,note:'平成9年修正・平成10.11.1発行',list:'106-5-3-11'}
]});
kjmapDataSet['takamatsu'] = new Object();
dataset = kjmapDataSet['takamatsu'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1896, end:1910, scale:'1/20000', mapList: [
    {name:'香西',north:34.4032410436678,west:133.90021003068,south:34.3365841626297,east:134.00020329644,note:'明治35年測図・明治37.9.30発行',list:'s1617'},
    {name:'國分',north:34.3365819732649,west:133.900212151534,south:34.2699250920013,east:134.000205417307,note:'明治39年測図・明治41.2.28発行',list:'s1619'},
    {name:'瀧宮',north:34.2699229063428,west:133.900214265408,south:34.2032660048441,east:134.000207531194,note:'明治39年測図・明治41.4.30発行',list:'s1620'},
    {name:'雌山',north:34.4032388578465,west:133.800218900948,south:34.3365819732649,east:133.900212151534,note:'明治35年測図・明治37.6.30発行',list:'s1621'},
    {name:'坂出',north:34.3365797911346,west:133.80022101478,south:34.2699229063428,east:133.900214265408,note:'明治39年測図・明治41.3.30発行',list:'s1623'},
    {name:'栗熊東',north:34.2699207279064,west:133.800223121654,south:34.2032638228949,east:133.900216372325,note:'明治39年測図・明治41.4.30発行',list:'s1625'},
    {name:'琴平',north:34.2032616481555,west:133.800225221594,south:34.1366047329114,east:133.900218472306,note:'明治39年測図・明治40.11.30発行',list:'s1626'},
    {name:'丸龜及多度津',north:34.3365776162452,west:133.70022988615,south:34.2699207279064,east:133.800223121654,note:'明治39年測図・明治41.2.28発行',list:'s1627'},
    {name:'善通寺',north:34.2699185566987,west:133.700231986018,south:34.2032616481555,east:133.800225221594,note:'明治39年測図・明治41.3.30発行',list:'s1629'},
    {name:'麻村',north:34.2032594806326,west:133.700234078976,south:34.129233369854,east:133.800227545584,note:'明治39年測図・明治41.1.30発行',list:'s1631'},
    {name:'屋島',north:34.4032454370435,west:134.100192314644,south:34.3365885630355,east:134.200185610815,note:'明治43年修正・大正4.12.28発行',list:'s1996'},
    {name:'志度',north:34.3365863592221,west:134.100194449524,south:34.269929484958,east:134.200187745649,note:'明治29年測図・明治32.5.30発行',list:'s1997'},
    {name:'髙松市',north:34.4032432367357,west:134.00020116857,south:34.3365863592221,east:134.100194449524,note:'明治43年修正・大正5.4.30発行',list:'s1998'},
    {name:'百相',north:34.3365841626297,west:134.00020329644,south:34.2699272848752,east:134.100196577378,note:'明治29年測図 ',list:'s1999'}
]});
dataset.age.push({
  folderName:'00', start:1928, end:1928, scale:'1/25000', mapList: [
    {name:'八栗山',north:34.4199107594202,west:134.125189567186,south:34.3365898656016,east:134.2591321041,note:'昭和3年測図・昭和6.12.28発行',list:'105-14-2-1'},
    {name:'髙松北部',north:34.419908006744,west:134.000200635505,south:34.3365869094988,east:134.125192239077,note:'昭和3年測図・昭和6.12.28発行',list:'105-14-4-1'},
    {name:'志度',north:34.3365869094988,west:134.125192239077,south:34.2532658116931,east:134.250183866347,note:'昭和3年測図・昭和6.12.28発行',list:'105-15-1-1'},
    {name:'髙松南部',north:34.3365841626297,west:134.00020329644,south:34.2532630593808,east:134.12519489998,note:'昭和3年測図・昭和6.12.28発行',list:'105-15-3-1'},
    {name:'香西',north:34.419905265385,west:133.875211716616,south:34.3365841626297,east:134.00020329644,note:'昭和3年測図・昭和23.4.30発行',list:'110-2-2-1'},
    {name:'白峯山',north:34.3365814270539,west:133.875214366582,south:34.2532603183248,east:134.000205946432,note:'昭和3年測図・昭和6.12.28発行',list:'110-3-1-1'},
    {name:'瀧宮',north:34.2532575885382,west:133.875217005651,south:34.1699364638135,east:134.000208585527,note:'昭和3年測図・昭和6.12.28発行',list:'110-3-2-1'},
    {name:'丸龜',north:34.3406345946214,west:133.737094186379,south:34.2532575885382,east:133.875217005651,note:'昭和3年測図・昭和6.12.28発行',list:'110-3-3-1'},
    {name:'善通寺',north:34.2532548700339,west:133.750228077584,south:34.169933739822,east:133.875219633867,note:'昭和3年測図・昭和6.12.28発行',list:'110-3-4-1'}
]});
dataset.age.push({
  folderName:'01', start:1969, end:1969, scale:'1/25000', mapList: [
    {name:'五剣山',north:34.4199106956749,west:134.122300922843,south:34.336589914019,east:134.26132101081,note:'昭和44年改測・昭和46.6.30発行',list:'105-14-2-5'},
    {name:'高松北部',north:34.4199079432601,west:133.997311991459,south:34.3365868458879,east:134.122303594481,note:'昭和44年改測・昭和46.5.30発行',list:'105-14-4-6'},
    {name:'志度',north:34.3365868458879,west:134.122303594481,south:34.2532657479569,east:134.247295221202,note:'昭和44年改測・昭和46.9.30発行',list:'105-15-1-4'},
    {name:'高松南部',north:34.3365840992797,west:133.99731465214,south:34.2532629959046,east:134.122306255132,note:'昭和44年改測・昭和46.4.30発行',list:'105-15-3-6'},
    {name:'五色台',north:34.4199052021628,west:133.872323072865,south:34.3365840992797,east:133.99731465214,note:'昭和44年改測・昭和46.9.30発行',list:'110-2-2-3'},
    {name:'本島',north:34.419902472396,west:133.747334167009,south:34.336581363965,east:133.872325722577,note:'昭和44年測量・昭和46.11.30発行',list:'110-2-4-1'},
    {name:'白峰山',north:34.336581363965,west:133.872325722577,south:34.2532602551089,east:133.99731730188,note:'昭和44年改測・昭和46.8.30発行',list:'110-3-1-4'},
    {name:'滝宮',north:34.2532575255828,west:133.872328361393,south:34.1699364007318,east:133.997319940723,note:'昭和44年改測・昭和47.2.28発行',list:'110-3-2-3'},
    {name:'丸亀',north:34.336578639957,west:133.747336805739,south:34.2532575255828,east:133.872328361393,note:'昭和44年改測・昭和46.12.28発行',list:'110-3-3-5'},
    {name:'善通寺',north:34.2532548073395,west:133.747339433619,south:34.1699336770004,east:133.872330989357,note:'昭和44年改測・昭和46.6.30発行',list:'110-3-4-5'}
]});
dataset.age.push({
  folderName:'02', start:1983, end:1984, scale:'1/25000', mapList: [
    {name:'五剣山',north:34.4199106956749,west:134.122300922843,south:34.3365899127716,east:134.26126461579,note:'昭和58年修正・昭和59.12.28発行',list:'105-14-2-9'},
    {name:'高松北部',north:34.4199079432601,west:133.997311991459,south:34.3365868458879,east:134.122303594481,note:'昭和58年修正・昭和59.11.30発行',list:'105-14-4-10'},
    {name:'志度',north:34.3365868458879,west:134.122303594481,south:34.2532657479569,east:134.247295221202,note:'昭和58年修正・昭和60.1.30発行',list:'105-15-1-8'},
    {name:'高松南部',north:34.3365840992797,west:133.99731465214,south:34.2532629959046,east:134.122306255132,note:'昭和58年修正・昭和60.1.30発行',list:'105-15-3-10'},
    {name:'五色台',north:34.4199052021628,west:133.872323072865,south:34.3365840992797,east:133.99731465214,note:'昭和59年修正・昭和61.6.30発行',list:'110-2-2-7'},
    {name:'本島',north:34.419902472396,west:133.747334167009,south:34.336581363965,east:133.872325722577,note:'昭和59年修正・昭和61.7.30発行',list:'110-2-4-4'},
    {name:'白峰山',north:34.336581363965,west:133.872325722577,south:34.2532602551089,east:133.99731730188,note:'昭和59年修正・昭和60.11.30発行',list:'110-3-1-9'},
    {name:'滝宮',north:34.2532575255828,west:133.872328361393,south:34.1699364007318,east:133.997319940723,note:'昭和59年修正・昭和60.12.28発行',list:'110-3-2-7'},
    {name:'丸亀',north:34.336578639957,west:133.747336805739,south:34.2532575255828,east:133.872328361393,note:'昭和59年修正・昭和60.12.28発行',list:'110-3-3-9'},
    {name:'善通寺',north:34.2532548073395,west:133.747339433619,south:34.1699336770004,east:133.872330989357,note:'昭和59年修正・昭和60.12.28発行',list:'110-3-4-10B'}
]});
dataset.age.push({
  folderName:'03', start:1990, end:2000, scale:'1/25000', mapList: [
    {name:'五剣山',north:34.4199106956749,west:134.122300922843,south:34.3365899129352,east:134.261272015137,note:'平成6年修正・平成7.4.1発行',list:'105-14-2-11C'},
    {name:'高松北部',north:34.4199079432601,west:133.997311991459,south:34.3365868458879,east:134.122303594481,note:'平成12年修正・平成13.12.1発行',list:'105-14-4-14'},
    {name:'志度',north:34.3365868458879,west:134.122303594481,south:34.2532657479569,east:134.247295221202,note:'平成12年修正・平成13.3.29発行',list:'105-15-1-14B'},
    {name:'高松南部',north:34.3365840992797,west:133.99731465214,south:34.2532629959046,east:134.122306255132,note:'平成12年修正・平成13.3.29発行',list:'105-15-3-15B'},
    {name:'五色台',north:34.4199052021628,west:133.872323072865,south:34.3365840992797,east:133.99731465214,note:'平成12年修正・平成14.1.1発行',list:'110-2-2-9'},
    {name:'本島',north:34.419902472396,west:133.747334167009,south:34.336581363965,east:133.872325722577,note:'平成2年修正・平成3.1.1発行',list:'110-2-4-6B'},
    {name:'白峰山',north:34.336581363965,west:133.872325722577,south:34.2532602551089,east:133.99731730188,note:'平成11年部修・平成11.10.1発行',list:'110-3-1-13B'},
    {name:'滝宮',north:34.2532575255828,west:133.872328361393,south:34.1699364007318,east:133.997319940723,note:'平成8年修正・平成9.8.1発行',list:'110-3-2-10B'},
    {name:'丸亀',north:34.336578639957,west:133.747336805739,south:34.2532575255828,east:133.872328361393,note:'平成8年修正・平成9.11.1発行',list:'110-3-3-15B'},
    {name:'善通寺',north:34.2532548073395,west:133.747339433619,south:34.1699336770004,east:133.872330989357,note:'平成11年部修・平成13.2.1発行',list:'110-3-4-15B'}
]});
kjmapDataSet['matsuyama'] = new Object();
dataset = kjmapDataSet['matsuyama'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1903, end:1903, scale:'1/20000', mapList: [
    {name:'松瀬川',north:33.8699470881152,west:132.900315310996,south:33.8032900898963,east:133.000308428365,note:'明治36年測図・明治38.3.30発行',list:'s2021'},
    {name:'川上',north:33.8032880019202,west:132.900317307952,south:33.7366309935368,east:133.000310425617,note:'明治36年測図・明治38.3.30発行',list:'s2022'},
    {name:'久米',north:33.8699450037484,west:132.800324205315,south:33.8032880019202,east:132.900317307952,note:'明治36年測図・明治38.6.30発行',list:'s2025'},
    {name:'久谷',north:33.8032859211448,west:132.80032619537,south:33.7366289091675,east:132.900319298331,note:'明治36年測図・明治38.3.30発行',list:'s2026'},
    {name:'堀江',north:33.9366018842299,west:132.695283067726,south:33.8699450037484,east:132.800324205315,note:'明治36年測図・明治38.9.30発行',list:'s2029'},
    {name:'松山',north:33.8699429266009,west:132.700333107446,south:33.8032859211448,east:132.80032619537,note:'明治36年測図・明治38.12.28発行',list:'s2030'},
    {name:'郡中',north:33.8032838475764,west:132.700335090593,south:33.7366268319865,east:132.80032817887,note:'明治36年測図・明治38.3.30発行',list:'s2031'},
    {name:'今出',north:33.8699408566792,west:132.600342017359,south:33.8032838475764,east:132.700335090593,note:'明治36年測図・明治37.9.30発行',list:'s2033'},
    {name:'三嶋町',north:33.8032817812213,west:132.600343993592,south:33.736624762,east:132.700337067207,note:'明治36年測図・明治37.12.28発行',list:'s2034'}
]});
dataset.age.push({
  folderName:'00', start:1928, end:1955, scale:'1/25000', mapList: [
    {name:'松山北部',north:33.919938268086,west:132.750327161148,south:33.8366170195187,east:132.875318532281,note:'昭和3年測図・昭和6.7.30発行',list:'116-1-4-1'},
    {name:'伊予川内',north:33.8366170195187,west:132.875318532281,south:33.7532957707419,east:133.000309926922,note:'昭和3年測図・昭和6.6.30発行',list:'116-2-1-1'},
    {name:'松山南部',north:33.8366144196848,west:132.750329649526,south:33.7532931652763,east:132.875321021183,note:'昭和3年測図・昭和6.6.30発行',list:'116-2-3-1'},
    {name:'三津濱',north:33.9199356739504,west:132.625338301393,south:33.8366144196848,east:132.750329649526,note:'昭和3年測図30年資修・昭和30.1.30発行',list:'116-5-2-1'},
    {name:'郡中',north:33.8366118311264,west:132.625340778949,south:33.7532905710495,east:132.750332127663,note:'昭和3年測図・昭和6.6.30発行',list:'116-6-1-1'}
]});
dataset.age.push({
  folderName:'01', start:1966, end:1968, scale:'1/25000', mapList: [
    {name:'松山北部',north:33.9199382080048,west:132.747438518475,south:33.8366169593062,east:132.872429889076,note:'昭和43年改測・昭和46.2.28発行',list:'116-1-4-5'},
    {name:'伊予川内',north:33.8366169593062,west:132.872429889076,south:33.7532957103997,east:132.997421283185,note:'昭和43年改測・昭和46.2.28発行',list:'116-2-1-4'},
    {name:'松山南部',north:33.8366143597327,west:132.747441006603,south:33.7532931051936,east:132.872432377729,note:'昭和43年改測・昭和46.2.28発行',list:'116-2-3-5'},
    {name:'三津浜',north:33.9199356141306,west:132.622449659001,south:33.8366143597327,east:132.747441006603,note:'昭和41年改測・昭和44.3.30発行',list:'116-5-2-2'},
    {name:'郡中',north:33.8366117714351,west:132.622452136307,south:33.7532905112268,east:132.747443484491,note:'昭和43年改測・昭和46.2.28発行',list:'116-6-1-5'}
]});
dataset.age.push({
  folderName:'02', start:1985, end:1985, scale:'1/25000', mapList: [
    {name:'松山北部',north:33.9199382080048,west:132.747438518475,south:33.8366169593062,east:132.872429889076,note:'昭和60年修正・昭和62.7.30発行',list:'116-1-4-9C'},
    {name:'伊予川内',north:33.8366169593062,west:132.872429889076,south:33.7532957103997,east:132.997421283185,note:'昭和60年修正・昭和62.9.30発行',list:'116-2-1-8B'},
    {name:'松山南部',north:33.8366143597327,west:132.747441006603,south:33.7532931051936,east:132.872432377729,note:'昭和60年修正・昭和61.5.30発行',list:'116-2-3-9'},
    {name:'三津浜',north:33.9199356141306,west:132.622449659001,south:33.8366143597327,east:132.747441006603,note:'昭和60年修正・昭和61.12.28発行',list:'116-5-2-7'},
    {name:'郡中',north:33.8366117714351,west:132.622452136307,south:33.7532905112268,east:132.747443484491,note:'昭和60年修正・昭和61.11.30発行',list:'116-6-1-9'}
]});
dataset.age.push({
  folderName:'03', start:1998, end:1999, scale:'1/25000', mapList: [
    {name:'松山北部',north:33.9199382080048,west:132.747438518475,south:33.8366169593062,east:132.872429889076,note:'平成10年部修・平成11.3.1発行',list:'116-1-4-12B'},
    {name:'伊予川内',north:33.8366169593062,west:132.872429889076,south:33.7532957103997,east:132.997421283185,note:'平成10年部修・平成12.1.1発行',list:'116-2-1-12'},
    {name:'松山南部',north:33.8366143597327,west:132.747441006603,south:33.7532931051936,east:132.872432377729,note:'平成10年部修・平成11.1.1発行',list:'116-2-3-12B'},
    {name:'三津浜',north:33.9199356141306,west:132.622449659001,south:33.8366143597327,east:132.747441006603,note:'平成11年部修・平成12.5.1発行',list:'116-5-2-10B'},
    {name:'郡中',north:33.8366117714351,west:132.622452136307,south:33.7532905112268,east:132.747443484491,note:'平成11年部修・平成12.2.1発行',list:'116-6-1-12B'}
]});
kjmapDataSet['toyo'] = new Object();
dataset = kjmapDataSet['toyo'];
dataset.age = new Array();
dataset.age.push({
   folderName:'00', start: 1898, end: 1906, scale:'1/50000', mapList: [
         {name:'新居濱', north:34.003272608218, west:133.25028018059, south:33.8366301873874, east:133.500263130571,note:'明治39年測図・明治41.8.30発行',list:'111-9-1'},
         {name:'観音寺', north:34.1699256354497, west:133.500252854884, south:34.0032833005488, east:133.750235897304,note:'明治39年測図・明治43.4.30発行',list:'110-8-1'},
         {name:'三嶋', north:34.0032779318858, west:133.50025801391, south:33.8366355330271, east:133.75024105698,note:'明治39年測図・明治41.7.30発行',list:'111-5-1'},
         {name:'今治', north:34.1699149878362, west:133.000297324934, south:34.003272608218, east:133.25028018059,note:'明治31年測図・大正14.6.30発行',list:'110-16-2'},
         {name:'波止濱', north:34.1699097320646, west:132.75031963416, south:34.0032673296468, east:133.000302396924,note:'明治31年測図・大正14.3.30発行',list:'115-4-2'},
         {name:'西條町', north:34.0032673296468, west:133.000302396924, south:33.8366248865501, east:133.25028525414,note:'明治39年測図・明治41.4.30発行',list:'111-13-1'},
]});
dataset.age.push({
   folderName:'01', start: 1928, end: 1928, scale:'1/50000', mapList: [
         {name:'西條', north:34.0032673296468, west:133.000302396924, south:33.8366248865501, east:133.25028525414,note:'昭和3年修正・昭和7.2.28発行',list:'111-13-2'},
         {name:'新居濱', north:34.003272608218, west:133.25028018059, south:33.8366301873874, east:133.500263130571,note:'昭和3年修正・昭和7.1.30発行',list:'111-9-2'},
         {name:'観音寺', north:34.1699256354497, west:133.500252854884, south:34.0032833005488, east:133.750235897304,note:'昭和3年修正・昭和7.5.30発行',list:'110-8-3'},
         {name:'三島', north:34.0032779318858, west:133.50025801391, south:33.8366355330271, east:133.75024105698,note:'昭和3年修正・昭和7.1.30発行',list:'111-5-2'},
         {name:'今治東部', north:34.1699149878362, west:133.000297324934, south:34.003272608218, east:133.25028018059,note:'昭和3年修正・昭和6.6.30発行',list:'110-16-3'},
         {name:'今治西部', north:34.1699097320646, west:132.75031963416, south:34.0032673296468, east:133.000302396924,note:'昭和3年修正・昭和6.6.30発行',list:'115-4-3'},
]});
dataset.age.push({
   folderName:'02', start: 1966, end: 1969, scale:'1/25000', mapList: [
         {name:'川之江', north:34.086601721869, west:133.497366795828, south:34.003280548564, east:133.622358304895,note:'昭和44年測量・昭和45.12.28発行',list:'110-8-4-1'},
         {name:'東予土居', north:34.0032752029059, west:133.37238044717, south:33.9199540081184, east:133.49737193313,note:'昭和42年測量・昭和44.10.30発行',list:'111-9-1-1'},
         {name:'新居浜', north:34.0094195772354, west:133.247391349103, south:33.91995134663, east:133.372382999731,note:'昭和42年測量・昭和44.10.30発行',list:'111-9-3-1'},
         {name:'西条北部', north:34.003269902295, west:133.122402639304, south:33.9199486963794, east:133.247394078786,note:'昭和41年測量・昭和43.6.30発行',list:'111-13-1-1'},
         {name:'西条', north:33.919946057379, west:133.12240517024, south:33.836624825558, east:133.247396610082,note:'昭和42年測量・昭和44.10.30発行',list:'111-13-2-1'},
         {name:'壬生川', north:34.0032672689137, west:132.997413753936, south:33.919946057379, east:133.12240517024,note:'昭和41年測量・昭和43.6.30発行',list:'111-13-3-1'},
         {name:'伊予小松', north:33.9199434296415, west:132.997416274042, south:33.8366221922313, east:133.122407690762,note:'昭和42年測量・1969/10/30発行',list:'111-13-4-1'},
         {name:'波止浜', north:34.1699122935397, west:132.872419831208, south:34.0865910979757, east:132.997411223419,note:'昭和41年改測・昭和44.3.30発行',list:'115-4-1-3'},
         {name:'今治西部', north:34.0865884702802, west:132.872422361245, south:34.0032672689137, east:132.997413753936,note:'昭和44年修正・昭和45.9.30発行',list:'115-4-2-4'},
         {name:'菊間', north:34.086585853921, west:132.747433511336, south:34.003264646832, east:132.872424880874,note:'昭和41年改測・昭和44.3.30発行',list:'115-4-4-3'},
         {name:'観音寺', north:34.1699282633266, west:133.622353124674, south:34.0866071015056, east:133.747344657,note:'昭和44年改測・昭和46.3.30発行',list:'110-8-1-3'},
         {name:'讃岐豊浜', north:34.0866044060571, west:133.622355720123, south:34.003283238254, east:133.747347252587,note:'昭和44年測量・昭和45.12.28発行',list:'110-8-2-1'},
         {name:'幸新田', north:34.1699149268432, west:132.997408682449, south:34.0865937369949, east:133.122400097912,note:'昭和41年測量・昭和43.6.30発行',list:'110-16-3-1'},
         {name:'今治東部', north:34.0865910979757, west:132.997411223419, south:34.003269902295, east:133.122402639304,note:'昭和41年改測・昭和44.3.30発行',list:'110-16-4-3'},
         {name:'伊予三島', north:34.0032778701104, west:133.497369369774, south:33.9199566808317, east:133.622360879033,note:'昭和42年測量・昭和44.10.30発行',list:'111-5-3-1'},
]});
dataset.age.push({
   folderName:'03', start: 1984, end: 1989, scale:'1/25000', mapList: [
         {name:'伊予三島', north:34.0032778701104, west:133.497369369774, south:33.9199566808317, east:133.622360879033,note:'昭和61年部修・昭和62.8.30発行',list:'111-5-3-5'},
         {name:'今治東部', north:34.0865910979757, west:132.997411223419, south:34.003269902295, east:133.122402639304,note:'昭和60年修正・昭和62.3.30発行',list:'110-16-4-7'},
         {name:'幸新田', north:34.1699149268432, west:132.997408682449, south:34.0865937369949, east:133.122400097912,note:'昭和60年修正・昭和62.8.30発行',list:'110-16-3-5B'},
         {name:'讃岐豊浜', north:34.0866044060571, west:133.622355720123, south:34.003283238254, east:133.747347252587,note:'昭和59年修正・昭和61.8.30発行',list:'110-8-2-4'},
         {name:'観音寺', north:34.1699282633266, west:133.622353124674, south:34.0866071015056, east:133.747344657,note:'昭和59年修正・昭和61.7.30発行',list:'110-8-1-7'},
         {name:'菊間', north:34.086585853921, west:132.747433511336, south:34.003264646832, east:132.872424880874,note:'昭和60年修正・昭和61.11.30発行',list:'115-4-4-7'},
         {name:'今治西部', north:34.0865884702802, west:132.872422361245, south:34.0032672689137, east:132.997413753936,note:'昭和60年修正・昭和62.3.30発行',list:'115-4-2-7'},
         {name:'波止浜', north:34.1699122935397, west:132.872419831208, south:34.0865910979757, east:132.997411223419,note:'昭和60年修正・昭和62.4.30発行',list:'115-4-1-7B'},
         {name:'伊予小松', north:33.9199434296415, west:132.997416274042, south:33.8366221922313, east:133.122407690762,note:'平成1年修正・平成2.8.1発行',list:'111-13-4-5B'},
         {name:'壬生川', north:34.0032672689137, west:132.997413753936, south:33.919946057379, east:133.12240517024,note:'平成1年修正・平成2.9.1発行',list:'111-13-3-5'},
         {name:'西条', north:33.919946057379, west:133.12240517024, south:33.836624825558, east:133.247396610082,note:'平成1年修正・平成2.9.1発行',list:'111-13-2-5'},
         {name:'西条北部', north:34.003269902295, west:133.122402639304, south:33.9199486963794, east:133.247394078786,note:'平成1年修正・平成2.9.1発行',list:'111-13-1-5'},
         {name:'新居浜', north:34.0093903405636, west:133.247391349997, south:33.91995134663, east:133.372382999731,note:'平成1年修正・平成2.1.1発行',list:'111-9-3-5'},
         {name:'東予土居', north:34.0032752029059, west:133.37238044717, south:33.9199540081184, east:133.49737193313,note:'昭和61年部修・昭和62.8.30発行',list:'111-9-1-5B'},
         {name:'川之江', north:34.086601721869, west:133.497366795828, south:34.003280548564, east:133.622358304895,note:'昭和59年修正・昭和61.5.30発行',list:'110-8-4-5'},
]});
dataset.age.push({
   folderName:'04', start: 1994, end: 2001, scale:'1/25000', mapList: [
         {name:'伊予小松', north:33.9199434296415, west:132.997416274042, south:33.8366221922313, east:133.122407690762,note:'平成13年修正・平成14.10.1発行',list:'111-13-4-8'},
         {name:'波止浜', north:34.1699122935397, west:132.872419831208, south:34.0865910979757, east:132.997411223419,note:'平成13年修正・平成15.1.1発行',list:'115-4-1-10'},
         {name:'今治西部', north:34.0865884702802, west:132.872422361245, south:34.0032672689137, east:132.997413753936,note:'平成13年修正・平成15.2.1発行',list:'115-4-2-10'},
         {name:'菊間', north:34.086585853921, west:132.747433511336, south:34.003264646832, east:132.872424880874,note:'平成13年修正・平成15.2.1発行',list:'115-4-4-9'},
         {name:'観音寺', north:34.1699282633266, west:133.622353124674, south:34.0866071015056, east:133.747344657,note:'平成12年修正・平成13.9.1発行',list:'110-8-1-10B'},
         {name:'讃岐豊浜', north:34.0866044060571, west:133.622355720123, south:34.003283238254, east:133.747347252587,note:'平成12年修正・平成14.1.1発行',list:'110-8-2-8'},
         {name:'今治東部', north:34.0865910979757, west:132.997411223419, south:34.003269902295, east:133.122402639304,note:'平成13年修正・平成15.3.1発行',list:'110-16-4-9'},
         {name:'伊予三島', north:34.0032778701104, west:133.497369369774, south:33.9199566808317, east:133.622360879033,note:'平成13年修正・平成15.3.1発行',list:'111-5-3-10'},
         {name:'川之江', north:34.086601721869, west:133.497366795828, south:34.003280548564, east:133.622358304895,note:'平成6年修正・平成7.7.1発行',list:'110-8-4-7B'},
         {name:'東予土居', north:34.0032752029059, west:133.37238044717, south:33.9199540081184, east:133.49737193313,note:'平成13年修正・平成15.4.1発行',list:'111-9-1-9'},
         {name:'西条北部', north:34.003269902295, west:133.122402639304, south:33.9199486963794, east:133.247394078786,note:'平成13年修正・平成15.1.1発行',list:'111-13-1-7'},
         {name:'西条', north:33.919946057379, west:133.12240517024, south:33.836624825558, east:133.247396610082,note:'平成13年修正・平成14.10.1発行',list:'111-13-2-8'},
         {name:'壬生川', north:34.0032672689137, west:132.997413753936, south:33.919946057379, east:133.12240517024,note:'平成13年修正・平成15.2.1発行',list:'111-13-3-8'},
         {name:'幸新田', north:34.1699149268432, west:132.997408682449, south:34.0865937369949, east:133.122400097912,note:'平成13年修正・平成15.4.1発行',list:'110-16-3-9'},
         {name:'新居浜', north:34.0081633402397, west:133.247391387514, south:33.91995134663, east:133.372382999731,note:'平成13年修正・平成15.2.1発行',list:'111-9-3-8'},
]});

kjmapDataSet['kochi'] = new Object();
dataset = kjmapDataSet['kochi'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1906, end:1907, scale:'1/20000', mapList: [
    {name:'赤岡',north:33.6033275311672,west:133.700252608185,south:33.5366705199259,east:133.800245844421,note:'明治40年測図・明治42.5.30発行',list:'s1591'},
    {name:'夜須',north:33.5366683894169,west:133.700254633225,south:33.4700113778411,east:133.80024786952,note:'明治40年測図・明治41.10.30発行',list:'s1593'},
    {name:'山田',north:33.6699845354989,west:133.600259386823,south:33.6033275311672,east:133.700252608185,note:'明治40年測図・明治42.3.30発行',list:'s1595'},
    {name:'後免',north:33.6033254040554,west:133.600261411773,south:33.5366683894169,east:133.700254633225,note:'明治40年測図・明治42.4.30発行',list:'s1597'},
    {name:'前濱',north:33.5366662660077,west:133.600263430051,south:33.47000925105,east:133.70025665159,note:'明治40年測図・明治41.7.30発行',list:'s1599'},
    {name:'小倉',north:33.6699824118186,west:133.500268205204,south:33.6033254040554,east:133.600261411773,note:'明治40年測図・明治41.6.30発行',list:'s1600'},
    {name:'髙知',north:33.6033232840622,west:133.500270223364,south:33.5366662660077,east:133.600263430051,note:'明治40年測図・明治42.6.30発行',list:'s1601'},
    {name:'長濱',north:33.5366641497047,west:133.500272234872,south:33.4635469303049,east:133.600265636277,note:'明治39年測図・明治41.5.30発行',list:'s1603'},
    {name:'伊野',north:33.6033211711941,west:133.400279042929,south:33.5366641497047,east:133.500272234872,note:'明治39年測図・明治41.5.30発行',list:'s1604'},
    {name:'髙岡',north:33.5366620405143,west:133.400281047663,south:33.4700050187364,east:133.500274239751,note:'明治39年測図・明治41.1.30発行',list:'s1606'},
    {name:'宇佐',north:33.4700029132267,west:133.400283045789,south:33.3946818083949,east:133.500276497263,note:'明治39年測図・明治41.4.30発行',list:'s1607'}
]});
dataset.age.push({
  folderName:'00', start:1933, end:1933, scale:'1/25000', mapList: [
    {name:'伊野',north:33.5866558597697,west:133.375281750443,south:33.5033345850473,east:133.500273238139,note:'昭和8年測図・昭和11.4.30発行',list:'111-11-2-1'},
    {name:'土佐高岡',north:33.5033319519704,west:133.375284251145,south:33.420010661168,east:133.500275739072,note:'昭和8年測図・昭和11.3.30発行',list:'111-12-1-1'},
    {name:'手結',north:33.5866638096091,west:133.750248717132,south:33.5033425508504,east:133.875240274009,note:'昭和8年測図・昭和10.12.28発行',list:'111-3-4-1'},
    {name:'山田',north:33.6699850675335,west:133.625257183478,south:33.5866638096091,east:133.750248717132,note:'昭和8年測図・昭和11.1.30発行',list:'111-7-1-1'},
    {name:'後免',north:33.586661148543,west:133.625259715742,south:33.5033398844999,east:133.750251249519,note:'昭和8年測図・昭和10.12.28発行',list:'111-7-2-1'},
    {name:'髙知',north:33.5866584985923,west:133.500270726864,south:33.503337229228,east:133.62526223758,note:'昭和8年測図・昭和11.4.30発行',list:'111-7-4-1'},
    {name:'土佐長濱',north:33.5033345850473,west:133.500273238139,south:33.4200132995729,east:133.625264749031,note:'昭和8年測図・昭和10.8.30発行',list:'111-8-3-1'}
]});
dataset.age.push({
  folderName:'01', start:1965, end:1965, scale:'1/25000', mapList: [
    {name:'伊野',north:33.586655798915,west:133.372393105358,south:33.5033345240683,east:133.497384592523,note:'昭和40年測図・昭和42.11.30発行',list:'111-11-2-4'},
    {name:'土佐高岡',north:33.5033318912482,west:133.372395605815,south:33.4200106003223,east:133.497387093212,note:'昭和40年測図・昭和42.11.30発行',list:'111-12-1-4'},
    {name:'手結',north:33.5866637479833,west:133.747360071181,south:33.5002738350593,east:133.872351720966,note:'昭和40年測図・昭和42.6.30発行',list:'111-3-4-3'},
    {name:'山田',north:33.6699850060309,west:133.622368538062,south:33.5866637479833,east:133.747360071181,note:'昭和40年測図・昭和43.3.30発行',list:'111-7-1-4'},
    {name:'後免',north:33.5866610871739,west:133.622371070082,south:33.5033398230082,east:133.747362603325,note:'昭和40年測図・昭和42.12.28発行',list:'111-7-2-6'},
    {name:'高知',north:33.5866584374803,west:133.497382081491,south:33.5033371679925,east:133.622373591675,note:'昭和40年測図・昭和42.12.28発行',list:'111-7-4-4'},
    {name:'土佐長濱',north:33.5033345240683,west:133.497384592523,south:33.4200132384712,east:133.622376102883,note:'昭和40年測図・昭和42.12.28発行',list:'111-8-3-4'}
]});
dataset.age.push({
  folderName:'02', start:1982, end:1982, scale:'1/25000', mapList: [
    {name:'伊野',north:33.586655798915,west:133.372393105358,south:33.5033345240683,east:133.497384592523,note:'昭和57年測図・昭和58.11.30発行',list:'111-11-2-7'},
    {name:'土佐高岡',north:33.5033318912482,west:133.372395605815,south:33.4200106003223,east:133.497387093212,note:'昭和57年測図・昭和58.12.28発行',list:'111-12-1-7'},
    {name:'手結',north:33.5866637479833,west:133.747360071181,south:33.5007182849534,east:133.872351707433,note:'昭和57年測図・昭和58.10.30発行',list:'111-3-4-5'},
    {name:'土佐山田',north:33.6699850060309,west:133.622368538062,south:33.5866637479833,east:133.747360071181,note:'昭和57年測図・昭和58.12.28発行',list:'111-7-1-7'},
    {name:'後免',north:33.5866610871739,west:133.622371070082,south:33.5033398230082,east:133.747362603325,note:'昭和57年測図・昭和59.2.28発行',list:'111-7-2-10'},
    {name:'高知',north:33.5866584374803,west:133.497382081491,south:33.5033371679925,east:133.622373591675,note:'昭和57年測図・昭和59.1.30発行',list:'111-7-4-8'},
    {name:'土佐長浜',north:33.5033345240683,west:133.497384592523,south:33.4200132384712,east:133.622376102883,note:'昭和57年測図・昭和59.2.28発行',list:'111-8-3-7'}
]});
dataset.age.push({
  folderName:'03', start:1998, end:2003, scale:'1/25000', mapList: [
    {name:'伊野',north:33.586655798915,west:133.372393105358,south:33.5033345240683,east:133.497384592523,note:'平成13年測図・平成14.7.1発行',list:'111-11-2-11'},
    {name:'土佐高岡',north:33.5033318912482,west:133.372395605815,south:33.4200106003223,east:133.497387093212,note:'平成13年測図・平成14.7.1発行',list:'111-12-1-9'},
    {name:'手結',north:33.5866637479833,west:133.747360071181,south:33.5007147553513,east:133.872351707541,note:'平成10年測図・平成11.9.1発行',list:'111-3-4-6B'},
    {name:'土佐山田',north:33.6699850060309,west:133.622368538062,south:33.5866637479833,east:133.747360071181,note:'平成13年測図・平成15.2.1発行',list:'111-7-1-11'},
    {name:'後免',north:33.5866610871739,west:133.622371070082,south:33.5033398230082,east:133.747362603325,note:'平成13年測図・平成15.1.1発行',list:'111-7-2-13B'},
    {name:'高知',north:33.5866584374803,west:133.497382081491,south:33.5033371679925,east:133.622373591675,note:'平成15年測図・平成15.2.1発行',list:'111-7-4-14'},
    {name:'土佐長浜',north:33.5033345240683,west:133.497384592523,south:33.4200132384712,east:133.622376102883,note:'平成13年測図・平成14.11.1発行',list:'111-8-3-10'}
]});
kjmapDataSet['fukuoka'] = new Object();
dataset = kjmapDataSet['fukuoka'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1922, end:1926, scale:'1/25000', mapList: [
    {name:'岩屋',north:34.0032194512599,west:130.625515836206,south:33.919898122831,east:130.750506820534,note:'大正11年測図・大正13.8.25発行',list:'125-5-1-1'},
    {name:'六連島',north:34.0032218681358,west:130.750504497125,south:33.9199005460179,east:130.875495503837,note:'大正11年測図・大正14.5.25発行',list:'125-1-3-1'},
    {name:'下関',north:34.0032242965271,west:130.875493169389,south:33.9199029806842,east:131.000484198529,note:'大正11年測図・大正14.5.25発行',list:''},
    {name:'白野江',north:34.0032267364224,west:131.000481853054,south:33.9199054268181,east:131.125472904663,note:'大正11年測図・大正13.3.25発行',list:''},
    {name:'折尾',north:33.9198957111348,west:130.625518148566,south:33.8365743673982,east:130.750509134384,note:'大正11年測図・大正15.3.25発行',list:'125-5-2-1'},
    {name:'八幡市',north:33.919898122831,west:130.750506820534,south:33.8365767853755,east:130.875497828679,note:'大正11年測図・大正14.5.25発行',list:'125-1-4-1'},
    {name:'小倉市',north:33.9199005460179,west:130.875495503837,south:33.8365792148073,east:131.000486534353,note:'大正11年測図・大正14.8.25発行',list:'125-1-2-1'},
    {name:'喜多久',north:33.9199029806842,west:131.000484198529,south:33.8365816556823,east:131.125475251457,note:'大正11年測図・大正13.3.25発行',list:''},
    {name:'木屋瀬',north:33.836571960887,west:130.625520451412,south:33.7532506018203,east:130.75051143871,note:'大正11年測図・大正14.11.25発行',list:''},
    {name:'徳力',north:33.8365743673982,west:130.750509134384,south:33.7532530145826,east:130.875500143954,note:'大正11年測図・大正14.10.25発行',list:''},
    {name:'苅田',north:33.8365767853755,west:130.875497828679,south:33.7532554387748,east:131.000488860564,note:'大正11年測図・大正14.3.25発行',list:''},
    {name:'玄界島',north:33.7532387098573,west:130.125568081108,south:33.6699173101924,east:130.250558981449,note:'大正15年測図・昭和4.2.28発行',list:''},
    {name:'志賀島',north:33.753241065299,west:130.250556730326,south:33.6699196719998,east:130.37554765271,note:'大正15年測図・昭和4.2.28発行',list:''},
    {name:'古賀',north:33.7532434322275,west:130.375545390641,south:33.6699220452577,east:130.500536335112,note:'大正15年測図・昭和4.8.30発行',list:''},
    {name:'米多比',north:33.7532458106314,west:130.500534062108,south:33.6699244299551,east:130.625525028708,note:'大正11年測図・大正15.2.28発行',list:''},
    {name:'宮ノ浦',north:33.669914959847,west:130.125570321274,south:33.5865935449276,east:130.250561223304,note:'大正15年測図・昭和4.7.30発行',list:''},
    {name:'福岡西部',north:33.6699173101924,west:130.250558981449,south:33.5865959016086,east:130.375549905466,note:'大正15年測図・昭和4.10.30発行',list:'125-11-3-1'},
    {name:'福岡',north:33.6699196719998,west:130.37554765271,south:33.5865982697154,east:130.500538598758,note:'大正15年測図・昭和4.11.30発行',list:'125-11-1-1'},
    {name:'篠栗',north:33.6699220452577,west:130.500536335112,south:33.5866006492368,east:130.625527303233,note:'大正11年測図・大正15.2.28発行',list:''},
    {name:'前原',north:33.5865911996836,west:130.125572552218,south:33.5032697694875,east:130.250563455928,note:'大正15年測図・昭和4.8.30発行',list:''},
    {name:'福岡西南部',north:33.5865935449276,west:130.250561223304,south:33.503272121037,east:130.375552148946,note:'大正15年測図・昭和4.10.30発行',list:'125-11-4-1'},
    {name:'福岡南部',north:33.5865959016086,west:130.375549905466,south:33.5032744839875,east:130.500540853083,note:'大正15年測図・昭和4.11.30発行',list:'125-11-2-1'},
    {name:'太宰府',north:33.5865982697154,west:130.500538598758,south:33.5032768583277,east:130.625529568393,note:'大正11年測図・大正15.2.28発行',list:''},
    {name:'南畑村',north:33.503272121037,west:130.375552148946,south:33.4199506880571,east:130.500543098123,note:'大正15年測図・昭和4.5.30発行',list:''},
    {name:'二日市',north:33.5032744839875,west:130.500540853083,south:33.4199530572109,east:130.625531824223,note:'大正15年測図・昭和4.6.30発行',list:''},
    {name:'甘木',north:33.5032768583277,west:130.625529568393,south:33.4199554377182,east:130.750520561538,note:'大正15年測図・昭和4.4.30発行',list:''}
]});
dataset.age.push({
  folderName:'01', start:1936, end:1938, scale:'1/25000', mapList: [
    {name:'岩屋',north:34.0032194512599,west:130.625515836206,south:33.919898122831,east:130.750506820534,note:'昭和11年二修・昭和11.9.25発行',list:'125-5-1-2'},
    {name:'六連島',north:34.0032218681358,west:130.750504497125,south:33.9199005460179,east:130.875495503837,note:'昭和11年二修・昭和12.9.25発行',list:''},
    {name:'下関',north:34.0032242965271,west:130.875493169389,south:33.9199029806842,east:131.000484198529,note:'昭和11年二修・昭和12.9.25発行',list:''},
    {name:'白野江',north:34.0032267364224,west:131.000481853054,south:33.9199054268181,east:131.125472904663,note:'昭和11年二修・昭和23.4.30発行',list:''},
    {name:'折尾',north:33.9198957111348,west:130.625518148566,south:33.8365743673982,east:130.750509134384,note:'昭和11年二修・昭和12.12.25発行',list:'125-5-2-2'},
    {name:'八幡市',north:33.919898122831,west:130.750506820534,south:33.8365767853755,east:130.875497828679,note:'昭和11年二修・昭和12.10.25発行',list:'125-1-4-2'},
    {name:'小倉市',north:33.9199005460179,west:130.875495503837,south:33.8365792148073,east:131.000486534353,note:'昭和11年二修・昭和13.2.25発行',list:'125-1-2-2'},
    {name:'喜多久',north:33.9199029806842,west:131.000484198529,south:33.8365816556823,east:131.125475251457,note:'昭和11年二修・昭和22.12.30発行',list:''},
    {name:'木屋瀬',north:33.836571960887,west:130.625520451412,south:33.7532506018203,east:130.75051143871,note:'昭和13年測図・昭和15.5.25発行',list:''},
    {name:'苅田',north:33.8365767853755,west:130.875497828679,south:33.7532554387748,east:131.000488860564,note:'昭和11年二修・昭和15.4.25発行',list:''},
    {name:'苅田',north:33.8365792148073,west:131.000486534353,south:33.7532578743853,east:131.125477588594,note:'昭和11年二修・昭和15.4.25発行',list:''},
    {name:'玄界島',north:33.7532387098573,west:130.125568081108,south:33.6699173101924,east:130.250558981449,note:'昭和11年二修・昭和22.12.28発行',list:''},
    {name:'志賀島',north:33.753241065299,west:130.250556730326,south:33.6699196719998,east:130.37554765271,note:'昭和11年二修・昭和12.10.30発行',list:''},
    {name:'古賀',north:33.7532434322275,west:130.375545390641,south:33.6699220452577,east:130.500536335112,note:'昭和11年二修・昭和15.6.30発行',list:''},
    {name:'福丸',north:33.7532458106314,west:130.500534062108,south:33.6699244299551,east:130.625525028708,note:'昭和13年測図・昭和16.2.28発行',list:''},
    {name:'宮ノ浦',north:33.669914959847,west:130.125570321274,south:33.5865935449276,east:130.250561223304,note:'昭和13年測図・昭和15.6.30発行',list:'',war:true},
    {name:'福岡西部',north:33.6699173101924,west:130.250558981449,south:33.5865959016086,east:130.375549905466,note:'昭和11年二修・昭和14.2.28発行',list:'125-11-3-3'},
    {name:'福岡',north:33.6699196719998,west:130.37554765271,south:33.5865982697154,east:130.500538598758,note:'昭和11年二修・昭和15.4.30発行',list:'125-11-1-2',war:true},
    {name:'篠栗',north:33.6699220452577,west:130.500536335112,south:33.5866006492368,east:130.625527303233,note:'昭和11年二修・昭和15.4.30発行',list:'',war:true},
    {name:'前原',north:33.5865911996836,west:130.125572552218,south:33.5032697694875,east:130.250563455928,note:'昭和13年測図・昭和15.6.30発行',list:'',war:true},
    {name:'福岡西南部',north:33.5865935449276,west:130.250561223304,south:33.503272121037,east:130.375552148946,note:'昭和11年二修・昭和15.4.30発行',list:'125-11-4-2',war:true},
    {name:'福岡南部',north:33.5865959016086,west:130.375549905466,south:33.5032744839875,east:130.500540853083,note:'昭和11年二修・昭和15.6.30発行',list:'125-11-2-2',war:true},
    {name:'太宰府',north:33.5865982697154,west:130.500538598758,south:33.5032768583277,east:130.625529568393,note:'昭和11年二修・昭和15.6.30発行',list:'',war:true},
    {name:'南畑村',north:33.503272121037,west:130.375552148946,south:33.4199506880571,east:130.500543098123,note:'昭和13年測図・昭和15.6.30発行',list:'',war:true},
    {name:'二日市',north:33.5032744839875,west:130.500540853083,south:33.4199530572109,east:130.625531824223,note:'昭和13年測図・昭和15.12.28発行',list:''},
    {name:'甘木',north:33.5032768583277,west:130.625529568393,south:33.4199554377182,east:130.750520561538,note:'昭和13年測図・昭和15.12.28発行',list:''}
]});
dataset.age.push({
  folderName:'02', start:1948, end:1956, scale:'1/25000', mapList: [
    {name:'岩屋',north:34.0032194512599,west:130.625515836206,south:33.919898122831,east:130.750506820534,note:'昭和25年三修・昭和31.11.30発行',list:'125-5-1-4'},
    {name:'六連島',north:34.0032218681358,west:130.750504497125,south:33.9199005460179,east:130.875495503837,note:'昭和25年三修・昭和31.11.30発行',list:''},
    {name:'下関',north:34.0032242965271,west:130.875493169389,south:33.9199029806842,east:131.000484198529,note:'昭和25年三修・昭和27.9.30発行',list:''},
    {name:'白野江',north:34.0032267364224,west:131.000481853054,south:33.9199054268181,east:131.125472904663,note:'昭和26年三修・昭和28.10.30発行',list:''},
    {name:'折尾',north:33.9198957111348,west:130.625518148566,south:33.8365743673982,east:130.750509134384,note:'昭和25年三修・昭和27.9.30発行',list:'125-5-2-4'},
    {name:'八幡市',north:33.919898122831,west:130.750506820534,south:33.8365767853755,east:130.875497828679,note:'昭和25年三修・昭和27.8.30発行',list:'125-1-4-4'},
    {name:'小倉市',north:33.9199005460179,west:130.875495503837,south:33.8365792148073,east:131.000486534353,note:'昭和25年三修・昭和27.9.30発行',list:'125-1-2-4'},
    {name:'喜多久',north:33.9199029806842,west:131.000484198529,south:33.8365816556823,east:131.125475251457,note:'昭和26年三修・昭和31.11.30発行',list:''},
    {name:'木屋瀬',north:33.836571960887,west:130.625520451412,south:33.7532506018203,east:130.75051143871,note:'昭和25年三修30年資修・昭和30.7.30発行',list:''},
    {name:'徳力',north:33.8365743673982,west:130.750509134384,south:33.7532530145826,east:130.875500143954,note:'昭和11年二修23年資修・昭和23.4.30発行',list:''},
    {name:'苅田',north:33.8365767853755,west:130.875497828679,south:33.7532554387748,east:131.000488860564,note:'昭和11年二修30年資修・昭和30.8.30発行',list:''},
    {name:'苅田',north:33.8365792148073,west:131.000486534353,south:33.7532578743853,east:131.125477588594,note:'昭和11年二修30年資修・昭和30.8.30発行',list:''},
    {name:'志賀島',north:33.753241065299,west:130.250556730326,south:33.6699196719998,east:130.37554765271,note:'昭和25年三修・昭和31.11.30発行',list:''},
    {name:'古賀',north:33.7532434322275,west:130.375545390641,south:33.6699220452577,east:130.500536335112,note:'昭和25年三修・昭和27.12.28発行',list:''},
    {name:'福丸',north:33.7532458106314,west:130.500534062108,south:33.6699244299551,east:130.625525028708,note:'昭和25年三修27年資修・昭和27.12.28発行',list:''},
    {name:'宮ノ浦',north:33.669914959847,west:130.125570321274,south:33.5865935449276,east:130.250561223304,note:'昭和13年測図30年資修・昭和30.8.30発行',list:''},
    {name:'福岡西部',north:33.6699173101924,west:130.250558981449,south:33.5865959016086,east:130.375549905466,note:'昭和25年三修・昭和27.8.30発行',list:'125-11-3-6'},
    {name:'福岡',north:33.6699196719998,west:130.37554765271,south:33.5865982697154,east:130.500538598758,note:'昭和25年三修・昭和27.8.30発行',list:'125-11-1-4'},
    {name:'篠栗',north:33.6699220452577,west:130.500536335112,south:33.5866006492368,east:130.625527303233,note:'昭和11年測図30年資修・昭和30.9.30発行',list:''},
    {name:'前原',north:33.5865911996836,west:130.125572552218,south:33.5032697694875,east:130.250563455928,note:'昭和13年測図31年資修・昭和31.12.28発行',list:''},
    {name:'福岡西南部',north:33.5865935449276,west:130.250561223304,south:33.503272121037,east:130.375552148946,note:'昭和25年三修・昭和27.8.30発行',list:'125-11-4-4'},
    {name:'福岡南部',north:33.5865959016086,west:130.375549905466,south:33.5032744839875,east:130.500540853083,note:'昭和25年三修27年資修・昭和27.9.30発行',list:''},
    {name:'太宰府',north:33.5865982697154,west:130.500538598758,south:33.5032768583277,east:130.625529568393,note:'昭和11年二修31年資修・昭和31.10.30発行',list:''},
    {name:'不入道',north:33.503272121037,west:130.375552148946,south:33.4199506880571,east:130.500543098123,note:'昭和13年測図29年資修・昭和29.12.28発行',list:''},
    {name:'二日市',north:33.5032744839875,west:130.500540853083,south:33.4199530572109,east:130.625531824223,note:'昭和13年測図30年資修・昭和30.9.30発行',list:''},
    {name:'甘木',north:33.5032768583277,west:130.625529568393,south:33.4199554377182,east:130.750520561538,note:'昭和13年測図30年資修・昭和30.9.30発行',list:''}
]});
dataset.age.push({
  folderName:'03', start:1967, end:1972, scale:'1/25000', mapList: [
    {name:'岩屋',north:34.0032193955395,west:130.622627209509,south:33.9198980669642,east:130.747618193321,note:'昭和44年改測・昭和47.12.28発行',list:''},
    {name:'六連島',north:34.003221812149,west:130.747615870167,south:33.9199004898857,east:130.872606876362,note:'昭和44年改測・昭和48.2.28発行',list:''},
    {name:'下関',north:34.0032242402744,west:130.872604542169,south:33.9199029242868,east:130.997595570789,note:'昭和44年改測・昭和47.2.28発行',list:''},
    {name:'白野江',north:34.003226679904,west:130.997593225569,south:33.9199053701559,east:131.122584276658,note:'昭和44年改測・昭和46.10.30発行',list:''},
    {name:'神湊',north:33.9198908671919,west:130.372652211985,south:33.8365695106373,east:130.497643152763,note:'昭和44年測量・昭和46.11.30発行',list:''},
    {name:'吉本',north:33.9198932556059,west:130.497640861187,south:33.8365719054055,east:130.622631824205,note:'昭和44年測量・昭和46.11.30発行',list:''},
    {name:'折尾',north:33.9198956555338,west:130.622629521614,south:33.8365743116516,east:130.747620506916,note:'昭和44年改測・昭和47.7.30発行',list:''},
    {name:'八幡',north:33.9198980669642,west:130.747618193321,south:33.836576729364,east:130.87260920095,note:'昭和44年改測・昭和47.9.30発行',list:''},
    {name:'小倉',north:33.9199004898857,west:130.872606876362,south:33.8365791585312,east:130.997597906359,note:'昭和44年改測・昭和46.11.30発行',list:''},
    {name:'喜多久',north:33.9199029242868,west:130.997595570789,south:33.8365815991418,east:131.122586623199,note:'昭和44年改測・昭和47.7.30発行',list:''},
    {name:'津屋崎',north:33.8365647555799,west:130.247665843468,south:33.7532433773955,east:130.372656763699,note:'昭和45年測量・昭和46.11.30発行',list:''},
    {name:'津屋崎',north:33.8365671273584,west:130.372654492535,south:33.7532457555344,east:130.497645434908,note:'昭和45年測量・昭和46.11.30発行',list:''},
    {name:'筑前東郷',north:33.8365695106373,west:130.497643152763,south:33.7532481451376,east:130.62263411732,note:'昭和44年測量・昭和47.3.30発行',list:''},
    {name:'中間',north:33.8365719054055,west:130.622631824205,south:33.7532505461939,east:130.74762281099,note:'昭和45年改測・昭和47.2.28発行',list:''},
    {name:'徳力',north:33.8365743116516,west:130.747620506916,south:33.7532529586919,east:130.872611515971,note:'昭和45年改測・昭和47.2.28発行',list:''},
    {name:'苅田',north:33.836576729364,west:130.87260920095,south:33.7532553826201,east:130.997600232318,note:'昭和45年改測・昭和47.2.28発行',list:''},
    {name:'苅田',north:33.8365791585312,west:130.997597906359,south:33.7532578179669,east:131.122588960083,note:'昭和45年改測・昭和47.2.28発行',list:''},
    {name:'玄界島',north:33.7532386555564,west:130.122679454679,south:33.6699172557439,east:130.247670354511,note:'昭和44年改測・昭和47.1.30発行',list:''},
    {name:'志賀島',north:33.7532410107324,west:130.247668103641,south:33.6699196172865,east:130.372659025515,note:'昭和47年修正・昭和47.9.30発行',list:''},
    {name:'古賀',north:33.7532433773955,west:130.372656763699,south:33.6699219902799,east:130.497647707659,note:'昭和44年改測・昭和46.5.30発行',list:''},
    {name:'脇田',north:33.7532457555344,west:130.497645434908,south:33.669924374713,east:130.622636400996,note:'昭和44年改測・昭和47.10.30発行',list:''},
    {name:'直方',north:33.7532481451376,west:130.62263411732,south:33.6699267705744,east:130.747625105579,note:'昭和44年測量・昭和46.11.30発行',list:''},
    {name:'金田',north:33.7532505461939,west:130.74762281099,south:33.6699291778526,east:130.872613821463,note:'昭和44年測量・昭和46.11.30発行',list:''},
    {name:'行橋',north:33.7532529586919,west:130.872611515971,south:33.6699315965363,east:130.997602548702,note:'昭和44年測量・昭和46.11.30発行',list:''},
    {name:'蓑島',north:33.7532553826201,west:130.997600232318,south:33.669934026614,east:131.122591287348,note:'昭和44年測量・昭和46.11.30発行',list:''},
    {name:'宮浦',north:33.6699149056635,west:130.122681694592,south:33.5865934905972,east:130.247672596114,note:'昭和44年改測・昭和47.2.28発行',list:''},
    {name:'福岡西部',north:33.6699172557439,west:130.247670354511,south:33.5865958470141,east:130.37266127802,note:'昭和47年修正・昭和47.9.30発行',list:''},
    {name:'福岡',north:33.6699196172865,west:130.372659025515,south:33.5865982148569,east:130.497649971053,note:'昭和47年修正・昭和47.9.30発行',list:''},
    {name:'篠栗',north:33.6699219902799,west:130.497647707659,south:33.5866005941146,east:130.62263867527,note:'昭和44年改測・昭和46.7.30発行',list:''},
    {name:'飯塚',north:33.669924374713,west:130.622636400996,south:33.5866029847758,east:130.747627390722,note:'昭和44年測量・昭和46.11.30発行',list:''},
    {name:'田川',north:33.6699267705744,west:130.747625105579,south:33.5866053868291,east:130.872616117464,note:'昭和44年測量・昭和46.11.30発行',list:''},
    {name:'前原',north:33.5865911456177,west:130.122683925283,south:33.5032697152754,east:130.247674828487,note:'昭和44年改測・昭和47.2.28発行',list:''},
    {name:'福岡西南部',north:33.5865934905972,west:130.247672596114,south:33.5032720665614,east:130.372663521248,note:'昭和44年改測・昭和46.11.30発行',list:''},
    {name:'福岡南部',north:33.5865958470141,west:130.37266127802,south:33.5032744292485,east:130.497652225128,note:'昭和44年改測・昭和47.2.28発行',list:''},
    {name:'太宰府',north:33.5865982148569,west:130.497649971053,south:33.5032768033256,east:130.622640940179,note:'昭和44年改測・昭和46.9.30発行',list:''},
    {name:'大隈',north:33.5866005941146,west:130.62263867527,south:33.5032791887813,east:130.747629666455,note:'昭和44年測量・昭和46.11.30発行',list:''},
    {name:'筑前山田',north:33.5866029847758,west:130.747627390722,south:33.5032815856043,east:130.87261840401,note:'昭和44年測量・昭和46.11.30発行',list:''},
    {name:'不入道',north:33.5032720665614,west:130.372663521248,south:33.4199506334377,east:130.497654469919,note:'昭和42年修正・昭和44.3.30発行',list:''},
    {name:'二日市',north:33.5032744292485,west:130.497652225128,south:33.4199530023289,east:130.62264319576,note:'昭和44年修正・昭和45.6.30発行',list:''},
    {name:'甘木',north:33.5032768033256,west:130.622640940179,south:33.419955382574,east:130.747631932816,note:'昭和44年修正・昭和46.11.30発行',list:''}
]});
dataset.age.push({
  folderName:'04', start:1982, end:1986, scale:'1/25000', mapList: [
    {name:'岩屋',north:34.0032193955395,west:130.622627209509,south:33.9198980669642,east:130.747618193321,note:'昭和59年修正・昭和61.6.30発行',list:''},
    {name:'六連島',north:34.003221812149,west:130.747615870167,south:33.9199004898857,east:130.872606876362,note:'昭和59年修正・昭和62.1.30発行',list:''},
    {name:'下関',north:34.0032242402744,west:130.872604542169,south:33.9199029242868,east:130.997595570789,note:'昭和59年修正・昭和61.9.30発行',list:''},
    {name:'白野江',north:34.003226679904,west:130.997593225569,south:33.9199053701559,east:131.122584276658,note:'昭和60年修正・昭和62.2.28発行',list:''},
    {name:'神湊',north:33.9198908671919,west:130.372652211985,south:33.8365695106373,east:130.497643152763,note:'昭和59年修正・昭和62.1.30発行',list:''},
    {name:'吉本',north:33.9198932556059,west:130.497640861187,south:33.8365719054055,east:130.622631824205,note:'昭和59年修正・昭和61.8.30発行',list:''},
    {name:'折尾',north:33.9198956555338,west:130.622629521614,south:33.8365743116516,east:130.747620506916,note:'昭和59年修正・昭和61.6.30発行',list:''},
    {name:'八幡',north:33.9198980669642,west:130.747618193321,south:33.836576729364,east:130.87260920095,note:'昭和59年修正・昭和61.9.30発行',list:''},
    {name:'小倉',north:33.9199004898857,west:130.872606876362,south:33.8365791585312,east:130.997597906359,note:'昭和59年修正・昭和62.2.28発行',list:''},
    {name:'喜多久',north:33.9199029242868,west:130.997595570789,south:33.8365815991418,east:131.122586623199,note:'昭和60年修正・昭和61.9.30発行',list:''},
    {name:'津屋崎',north:33.8365647555799,west:130.247665843468,south:33.7532433773955,east:130.372656763699,note:'昭和59年修正・昭和61.5.30発行',list:''},
    {name:'津屋崎',north:33.8365671273584,west:130.372654492535,south:33.7532457555344,east:130.497645434908,note:'昭和59年修正・昭和61.5.30発行',list:''},
    {name:'筑前東郷',north:33.8365695106373,west:130.497643152763,south:33.7532481451376,east:130.62263411732,note:'昭和59年修正・昭和61.1.30発行',list:''},
    {name:'中間',north:33.8365719054055,west:130.622631824205,south:33.7532505461939,east:130.74762281099,note:'昭和59年修正・昭和60.11.30発行',list:''},
    {name:'徳力',north:33.8365743116516,west:130.747620506916,south:33.7532529586919,east:130.872611515971,note:'昭和59年修正・昭和62.3.30発行',list:''},
    {name:'苅田',north:33.836576729364,west:130.87260920095,south:33.7532553826201,east:130.997600232318,note:'昭和59年修正・昭和61.10.30発行',list:''},
    {name:'神ノ島',north:33.8365791585312,west:130.997597906359,south:33.7532578179669,east:131.122588960083,note:'昭和59年修正・昭和61.11.30発行',list:''},
    {name:'玄界島',north:33.7532386555564,west:130.122679454679,south:33.6699172557439,east:130.247670354511,note:'昭和60年修正・昭和61.10.30発行',list:''},
    {name:'志賀島',north:33.7532410107324,west:130.247668103641,south:33.6699196172865,east:130.372659025515,note:'昭和59年修正・昭和61.7.30発行',list:''},
    {name:'古賀',north:33.7532433773955,west:130.372656763699,south:33.6699219902799,east:130.497647707659,note:'昭和59年修正・昭和61.5.30発行',list:''},
    {name:'脇田',north:33.7532457555344,west:130.497645434908,south:33.669924374713,east:130.622636400996,note:'昭和59年修正・昭和61.3.30発行',list:''},
    {name:'直方',north:33.7532481451376,west:130.62263411732,south:33.6699267705744,east:130.747625105579,note:'昭和59年修正・昭和60.12.28発行',list:''},
    {name:'金田',north:33.7532505461939,west:130.74762281099,south:33.6699291778526,east:130.872613821463,note:'昭和59年修正・昭和61.9.30発行',list:''},
    {name:'行橋',north:33.7532529586919,west:130.872611515971,south:33.6699315965363,east:130.997602548702,note:'昭和59年修正・昭和61.9.30発行',list:''},
    {name:'蓑島',north:33.7532553826201,west:130.997600232318,south:33.669934026614,east:131.122591287348,note:'昭和61年修正・昭和63.1.30発行',list:''},
    {name:'宮浦',north:33.6699149056635,west:130.122681694592,south:33.5865934905972,east:130.247672596114,note:'昭和60年修正・昭和62.2.28発行',list:''},
    {name:'福岡西部',north:33.6699172557439,west:130.247670354511,south:33.5865958470141,east:130.37266127802,note:'昭和59年修正・昭和61.2.28発行',list:''},
    {name:'福岡',north:33.6699196172865,west:130.372659025515,south:33.5865982148569,east:130.497649971053,note:'昭和59年修正・昭和60.11.30発行',list:''},
    {name:'篠栗',north:33.6699219902799,west:130.497647707659,south:33.5866005941146,east:130.62263867527,note:'昭和61年修正・昭和62.8.30発行',list:''},
    {name:'飯塚',north:33.669924374713,west:130.622636400996,south:33.5866029847758,east:130.747627390722,note:'昭和61年修正・昭和62.3.30発行',list:''},
    {name:'田川',north:33.6699267705744,west:130.747625105579,south:33.5866053868291,east:130.872616117464,note:'昭和61年修正・昭和63.1.30発行',list:''},
    {name:'前原',north:33.5865911456177,west:130.122683925283,south:33.5032697152754,east:130.247674828487,note:'昭和60年修正・昭和62.2.28発行',list:''},
    {name:'福岡西南部',north:33.5865934905972,west:130.247672596114,south:33.5032720665614,east:130.372663521248,note:'昭和59年修正・昭和61.1.30発行',list:''},
    {name:'福岡南部',north:33.5865958470141,west:130.37266127802,south:33.5032744292485,east:130.497652225128,note:'昭和59年修正・昭和60.10.30発行',list:''},
    {name:'太宰府',north:33.5865982148569,west:130.497649971053,south:33.5032768033256,east:130.622640940179,note:'昭和61年修正・昭和62.8.30発行',list:''},
    {name:'大隈',north:33.5866005941146,west:130.62263867527,south:33.5032791887813,east:130.747629666455,note:'昭和61年修正・昭和63.2.28発行',list:''},
    {name:'筑前山田',north:33.5866029847758,west:130.747627390722,south:33.5032815856043,east:130.87261840401,note:'昭和61年修正・昭和63.2.28発行',list:''},
    {name:'不入道',north:33.5032720665614,west:130.372663521248,south:33.4199506334377,east:130.497654469919,note:'昭和57年二改・昭和59.1.30発行',list:''},
    {name:'二日市',north:33.5032744292485,west:130.497652225128,south:33.4199530023289,east:130.62264319576,note:'昭和61年修正・昭和62.9.30発行',list:''},
    {name:'甘木',north:33.5032768033256,west:130.622640940179,south:33.419955382574,east:130.747631932816,note:'昭和61年修正・昭和62.9.30発行',list:''}
]});
dataset.age.push({
  folderName:'05', start:1991, end:2000, scale:'1/25000', mapList: [
    {name:'岩屋',north:34.0032193955395,west:130.622627209509,south:33.9198980669642,east:130.747618193321,note:'平成7年修正・平成8.8.1発行',list:''},
    {name:'六連島',north:34.003221812149,west:130.747615870167,south:33.9199004898857,east:130.872606876362,note:'平成7年修正・平成8.3.1発行',list:''},
    {name:'下関',north:34.0032242402744,west:130.872604542169,south:33.9199029242868,east:130.997595570789,note:'平成11年部修・平成11.10.1発行',list:''},
    {name:'神湊',north:33.9198908671919,west:130.372652211985,south:33.8365695106373,east:130.497643152763,note:'平成7年修正・平成8.1.1発行',list:''},
    {name:'吉本',north:33.9198932556059,west:130.497640861187,south:33.8365719054055,east:130.622631824205,note:'平成11年部修・平成12.7.1発行',list:''},
    {name:'折尾',north:33.9198956555338,west:130.622629521614,south:33.8365743116516,east:130.747620506916,note:'平成10年部修・平成11.2.1発行',list:''},
    {name:'八幡',north:33.9198980669642,west:130.747618193321,south:33.836576729364,east:130.87260920095,note:'平成11年部修・平成12.9.1発行',list:''},
    {name:'小倉',north:33.9199004898857,west:130.872606876362,south:33.8365791585312,east:130.997597906359,note:'平成7年修正・平成8.3.1発行',list:''},
    {name:'小倉',north:33.9199029242868,west:130.997595570789,south:33.8365815991418,east:131.122586623199,note:'平成7年修正・平成8.3.1発行',list:''},
    {name:'津屋崎',north:33.8365647555799,west:130.247665843468,south:33.7532433773955,east:130.372656763699,note:'平成8年部修・平成10.9.1発行',list:''},
    {name:'津屋崎',north:33.8365671273584,west:130.372654492535,south:33.7532457555344,east:130.497645434908,note:'平成8年部修・平成10.9.1発行',list:''},
    {name:'筑前東郷',north:33.8365695106373,west:130.497643152763,south:33.7532481451376,east:130.62263411732,note:'平成8年修正・平成9.11.1発行',list:''},
    {name:'中間',north:33.8365719054055,west:130.622631824205,south:33.7532505461939,east:130.74762281099,note:'平成8年修正・平成9.9.1発行',list:''},
    {name:'徳力',north:33.8365743116516,west:130.747620506916,south:33.7532529586919,east:130.872611515971,note:'平成11年部修・平成11.11.1発行',list:''},
    {name:'苅田',north:33.836576729364,west:130.87260920095,south:33.7532553826201,east:130.997600232318,note:'平成11年部修・平成12.2.1発行',list:''},
    {name:'神ノ島',north:33.8365791585312,west:130.997597906359,south:33.7532578179669,east:131.122588960083,note:'平成7年修正・平成8.2.1発行',list:''},
    {name:'玄界島',north:33.7532386555564,west:130.122679454679,south:33.6699172557439,east:130.247670354511,note:'平成7年修正・平成8.10.1発行',list:''},
    {name:'志賀島',north:33.7532410107324,west:130.247668103641,south:33.6699196172865,east:130.372659025515,note:'平成3年修正・平成4.3.1発行',list:''},
    {name:'古賀',north:33.7532433773955,west:130.372656763699,south:33.6699219902799,east:130.497647707659,note:'平成8年修正・平成9.8.1発行',list:''},
    {name:'脇田',north:33.7532457555344,west:130.497645434908,south:33.669924374713,east:130.622636400996,note:'平成8年修正・平成9.8.1発行',list:''},
    {name:'直方',north:33.7532481451376,west:130.62263411732,south:33.6699267705744,east:130.747625105579,note:'平成8年修正・平成9.10.1発行',list:''},
    {name:'金田',north:33.7532505461939,west:130.74762281099,south:33.6699291778526,east:130.872613821463,note:'平成11年部修・平成11.10.1発行',list:''},
    {name:'行橋',north:33.7532529586919,west:130.872611515971,south:33.6699315965363,east:130.997602548702,note:'平成7年修正・平成8.2.1発行',list:''},
    {name:'蓑島',north:33.7532553826201,west:130.997600232318,south:33.669934026614,east:131.122591287348,note:'平成7年修正・平成8.7.1発行',list:''},
    {name:'宮浦',north:33.6699149056635,west:130.122681694592,south:33.5865934905972,east:130.247672596114,note:'平成7年修正・平成8.10.1発行',list:''},
    {name:'福岡西部',north:33.6699172557439,west:130.247670354511,south:33.5865958470141,east:130.37266127802,note:'平成6年修正・平成7.9.1発行',list:''},
    {name:'福岡',north:33.6699196172865,west:130.372659025515,south:33.5865982148569,east:130.497649971053,note:'平成10年部修・平成11.4.1発行',list:''},
    {name:'篠栗',north:33.6699219902799,west:130.497647707659,south:33.5866005941146,east:130.62263867527,note:'平成8年修正・平成9.5.1発行',list:''},
    {name:'飯塚',north:33.669924374713,west:130.622636400996,south:33.5866029847758,east:130.747627390722,note:'平成8年修正・平成9.7.1発行',list:''},
    {name:'田川',north:33.6699267705744,west:130.747625105579,south:33.5866053868291,east:130.872616117464,note:'平成11年部修・平成12.3.1発行',list:''},
    {name:'前原',north:33.5865911456177,west:130.122683925283,south:33.5032697152754,east:130.247674828487,note:'平成7年修正・平成8.10.1発行',list:''},
    {name:'福岡西南部',north:33.5865934905972,west:130.247672596114,south:33.5032720665614,east:130.372663521248,note:'平成12年部修・平成12.12.1発行',list:''},
    {name:'福岡南部',north:33.5865958470141,west:130.37266127802,south:33.5032744292485,east:130.497652225128,note:'平成10年部修・平成11.4.1発行',list:''},
    {name:'太宰府',north:33.5865982148569,west:130.497649971053,south:33.5032768033256,east:130.622640940179,note:'平成10年部修・平成10.12.1発行',list:''},
    {name:'大隈',north:33.5866005941146,west:130.62263867527,south:33.5032791887813,east:130.747629666455,note:'平成8年修正・平成9.5.1発行',list:''},
    {name:'筑前山田',north:33.5866029847758,west:130.747627390722,south:33.5032815856043,east:130.87261840401,note:'平成4年修正・平成5.8.1発行',list:''},
    {name:'不入道',north:33.5032720665614,west:130.372663521248,south:33.4199506334377,east:130.497654469919,note:'平成12年部修・平成12.12.1発行',list:''},
    {name:'二日市',north:33.5032744292485,west:130.497652225128,south:33.4199530023289,east:130.62264319576,note:'平成11年部修・平成12.5.1発行',list:''},
    {name:'甘木',north:33.5032768033256,west:130.622640940179,south:33.419955382574,east:130.747631932816,note:'平成11年部修・平成12.2.1発行',list:''}
]});
kjmapDataSet['saga'] = new Object();
dataset = kjmapDataSet['saga'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1900, end:1911, scale:'1/20000', mapList: [
    {name:'鳥栖',north:33.4032859276454,west:130.50054355713,south:33.3366287688376,east:130.600536333607,note:'明治33年測図・明治35.9.30発行',list:'s1692'},
    {name:'久留米',north:33.3366268785745,west:130.500545345025,south:33.2699697198904,east:130.600538122458,note:'明治33年測図・明治35.9.30発行',list:'s1693'},
    {name:'福嶋',north:33.2699678329513,west:130.500547127024,south:33.2033106543818,east:130.600539905409,note:'明治33年測図・明治35.9.30発行',list:'s1695'},
    {name:'舩小屋',north:33.2033087707693,west:130.500548903146,south:33.1366515823022,east:130.600541682479,note:'明治33年測図・明治35.9.30発行',list:'s1697'},
    {name:'中原',north:33.4032840413313,west:130.400552582566,south:33.3366268785745,east:130.500545345025,note:'明治33年測図・明治35.6.30発行',list:'s1699'},
    {name:'瀨下',north:33.336624995569,west:130.400554363581,south:33.2699678329513,east:130.500547127024,note:'明治33年測図・明治35.9.30発行',list:'s1700'},
    {name:'城嶋',north:33.2699640808131,west:130.400554363581,south:33.2033068943889,east:130.500547127024,note:'明治33年測図43年鉄補・明治45.6.30発行',list:'s1702'},
    {name:'柳河',north:33.2033068943889,west:130.400557908009,south:33.136649702019,east:130.500550673408,note:'明治33年測図・明治35.12.28発行',list:'s1703'},
    {name:'神埼先',north:33.3366231198267,west:130.300563389246,south:33.2699659532569,east:130.400556138722,note:'明治43年修正・明治45.6.30発行',list:'s1704'},
    {name:'佐賀',north:33.2699640808131,west:130.300565157524,south:33.2033068943889,east:130.400557908009,note:'明治44年部修・大正1.10.30発行',list:'s1705'},
    {name:'沖端',north:33.2033050252462,west:130.30056691997,south:33.1366478289551,east:130.400559671458,note:'明治33年測図・明治35.12.28発行',list:'s1706'},
    {name:'神野',north:33.2699622156255,west:130.200574183402,south:33.2033050252462,east:130.30056691997,note:'明治33年測図・明治35.9.30発行',list:'s1707'}
]});
dataset.age.push({
  folderName:'00', start:1914, end:1926, scale:'1/25000', mapList: [
    {name:'中原',north:33.4199483336013,west:130.375554394295,south:33.3366268785745,east:130.500545345025,note:'大正15年測図・昭和4.11.30発行',list:'125-12-2-1'},
    {name:'鳥栖',north:33.4199506913903,west:130.500543109233,south:33.3366292425367,east:130.62553408187,note:'大正15年測図・昭和4.11.30発行',list:'125-8-4-1'},
    {name:'栁河',north:33.1699768999417,west:130.375561041935,south:33.0866553986404,east:130.500551997271,note:'大正6年測図・大正9.7.30発行',list:'126-10-1-1'},
    {name:'七ツ家',north:33.1699745689694,west:130.250572305939,south:33.0866530615491,east:130.375563239574,note:'大正6年測図・大正9.6.30発行',list:'126-10-3-1'},
    {name:'小城',north:33.3366198547721,west:130.125579201184,south:33.2532983819466,east:130.250570109881,note:'大正3年測図・大正7.6.30発行',list:'126-13-1-2'},
    {name:'牛津',north:33.2532960571595,west:130.125581395597,south:33.1699745689694,east:130.250572305939,note:'大正3年測図・大正7.6.30発行',list:'126-13-2-2'},
    {name:'久留米',north:33.3366268785745,west:130.500545345025,south:33.2533054242868,east:130.625536319151,note:'大正15年測図・昭和4.11.30発行',list:'126-5-3-1'},
    {name:'筑後福島',north:33.2533030655214,west:130.500547571605,south:33.1699815957787,east:130.625538547212,note:'大正15年測図・昭和4.6.30発行',list:'126-5-4-1'},
    {name:'久留米西部',north:33.3366245259522,west:130.375556619332,south:33.2533030655214,east:130.500547571605,note:'大正6年測図・大正9.10.30発行',list:'126-9-1-1'},
    {name:'羽犬塚',north:33.2533007180709,west:130.375558835199,south:33.1699792422152,east:130.500549789008,note:'大正6年測図・大正9.11.30発行',list:'126-9-2-1'},
    {name:'佐賀北部',north:33.336622184681,west:130.250567904736,south:33.2533007180709,east:130.375558835199,note:'大正3年測図・大正4.6.30発行',list:'126-9-3-1'},
    {name:'佐賀南部',north:33.2532983819466,west:130.250570109881,south:33.1699768999417,east:130.375561041935,note:'大正3年測図・大正4.6.30発行',list:'126-9-4-1'}
]});
dataset.age.push({
  folderName:'01', start:1931, end:1940, scale:'1/25000', mapList: [
    {name:'中原',north:33.4199483336013,west:130.375554394295,south:33.3366268785745,east:130.500545345025,note:'昭和13年測図・昭和15.11.30発行',list:'125-12-2-2'},
    {name:'鳥栖',north:33.4199506913903,west:130.500543109233,south:33.3366292425367,east:130.62553408187,note:'昭和11年二修・昭和15.3.30発行',list:'125-8-4-2',war:true},
    {name:'栁河',north:33.1699768999417,west:130.375561041935,south:33.0866553986404,east:130.500551997271,note:'昭和15年修正・昭和23.4.30発行',list:'126-10-1-4'},
    {name:'七ツ家',north:33.1699745689694,west:130.250572305939,south:33.0866530615491,east:130.375563239574,note:'昭和15年修正・昭和23.4.30発行',list:'126-10-3-2'},
    {name:'小城',north:33.3366198547721,west:130.125579201184,south:33.2532983819466,east:130.250570109881,note:'昭和15年修正・昭和22.11.30発行',list:'126-13-1-3'},
    {name:'牛津',north:33.2532960571595,west:130.125581395597,south:33.1699745689694,east:130.250572305939,note:'昭和15年修正・昭和22.11.30発行',list:'126-13-2-4'},
    {name:'久留米',north:33.3366268785745,west:130.500545345025,south:33.2533054242868,east:130.625536319151,note:'昭和6年部修・昭和7.5.30発行',list:'126-5-3-2'},
    {name:'久留米西部',north:33.3366245259522,west:130.375556619332,south:33.2533030655214,east:130.500547571605,note:'大正15年部修昭和6年鉄補・昭和7.2.28発行',list:'126-9-1-3'},
    {name:'羽犬塚',north:33.2533007180709,west:130.375558835199,south:33.1699792422152,east:130.500549789008,note:'昭和15年二修・昭和22.11.30発行',list:'126-9-2-4'},
    {name:'佐賀北部',north:33.336622184681,west:130.250567904736,south:33.2533007180709,east:130.375558835199,note:'大正6年修正昭和6年鉄補・昭和7.11.30発行',list:'126-9-3-3'},
    {name:'佐賀南部',north:33.2532983819466,west:130.250570109881,south:33.1699768999417,east:130.375561041935,note:'昭和6年二部・昭和7.11.30発行',list:'126-9-4-4'}
]});
dataset.age.push({
  folderName:'02', start:1958, end:1964, scale:'1/25000', mapList: [
    {name:'中原',north:33.4199482792444,west:130.372665755238,south:33.3366268240746,east:130.497656705462,note:'昭和39年改測・昭和42.7.30発行',list:'125-12-2-6'},
    {name:'鳥栖',north:33.4199506367706,west:130.497654469919,south:33.3366291877748,east:130.622645442049,note:'昭和38年修正・昭和42.3.30発行',list:'125-8-4-6'},
    {name:'柳川',north:33.1699768459426,west:130.372672402135,south:33.0866553445002,east:130.497663356969,note:'昭和39年改測・昭和41.10.30発行',list:'126-10-1-5'},
    {name:'七ツ家',north:33.1699745152316,west:130.247683666394,south:33.0866530076693,east:130.372674599528,note:'昭和39年改測・昭和42.3.30発行',list:'126-10-3-4'},
    {name:'小城',north:33.3366198010595,west:130.122690562389,south:33.25329832809,east:130.247681470583,note:'昭和39年改測・昭和41.8.30発行',list:'126-13-1-5'},
    {name:'牛津',north:33.2532960035651,west:130.122692756553,south:33.1699745152316,east:130.247683666394,note:'昭和39年改測・昭和41.8.30発行',list:'126-13-2-5'},
    {name:'久留米',north:33.3366268240746,west:130.497656705462,south:33.2533054242868,east:130.625536319151,note:'昭和33年三修・昭和37.3.30発行',list:'126-5-3-6'},
    {name:'八女',north:33.2533030111412,west:130.497658931795,south:33.1699815957787,east:130.625538547212,note:'昭和33年三修・昭和36.5.30発行',list:'126-5-4-4'},
    {name:'久留米西部',north:33.3366244717145,west:130.372667980026,south:33.2533030111412,east:130.497658931795,note:'昭和33年修正・昭和36.6.30発行',list:'126-9-1-7'},
    {name:'羽犬塚',north:33.2533006639524,west:130.372670195646,south:33.169979187955,east:130.497661148951,note:'昭和39年改測・昭和41.8.30発行',list:'126-9-2-6'},
    {name:'佐賀北部',north:33.3366221307057,west:130.247679265686,south:33.2533006639524,east:130.372670195646,note:'昭和39年改測・昭和42.3.30発行',list:'126-9-3-8'},
    {name:'佐賀南部',north:33.25329832809,west:130.247681470583,south:33.1699768459426,east:130.372672402135,note:'昭和39年改測・昭和41.8.30発行',list:'126-9-4-7'}
]});
dataset.age.push({
  folderName:'03', start:1977, end:1982, scale:'1/25000', mapList: [
    {name:'中原',north:33.4199482792444,west:130.372665755238,south:33.3366268240746,east:130.497656705462,note:'昭和57年二改・昭和58.10.30発行',list:'125-12-2-9'},
    {name:'鳥栖',north:33.4199506367706,west:130.497654469919,south:33.3366291877748,east:130.622645442049,note:'昭和57年二改・昭和59.3.30発行',list:'125-8-4-11'},
    {name:'柳川',north:33.1699768459426,west:130.372672402135,south:33.0866553445002,east:130.497663356969,note:'昭和52年二改・昭和54.2.28発行',list:'126-10-1-7'},
    {name:'七ツ家',north:33.1699745152316,west:130.247683666394,south:33.0866530076693,east:130.372674599528,note:'昭和52年二改・昭和54.9.30発行',list:'126-10-3-6'},
    {name:'小城',north:33.3366198010595,west:130.122690562389,south:33.25329832809,east:130.247681470583,note:'昭和56年二改・昭和57.12.28発行',list:'126-13-1-8'},
    {name:'牛津',north:33.2532960035651,west:130.122692756553,south:33.1699745152316,east:130.247683666394,note:'昭和56年二改・昭和58.3.30発行',list:'126-13-2-8'},
    {name:'久留米',north:33.3366268240746,west:130.497656705462,south:33.2533053696452,east:130.622647679083,note:'昭和57年修正・昭和59.1.30発行',list:'126-5-3-9'},
    {name:'八女',north:33.2533030111412,west:130.497658931795,south:33.1699815412577,east:130.622649906897,note:'昭和57年修正・昭和58.12.28発行',list:'126-5-4-8'},
    {name:'久留米西部',north:33.3366244717145,west:130.372667980026,south:33.2533030111412,east:130.497658931795,note:'昭和57年修正・昭和59.1.30発行',list:'126-9-1-10B'},
    {name:'羽犬塚',north:33.2533006639524,west:130.372670195646,south:33.169979187955,east:130.497661148951,note:'昭和56年二改・昭和57.10.30発行',list:'126-9-2-10'},
    {name:'佐賀北部',north:33.3366221307057,west:130.247679265686,south:33.2533006639524,east:130.372670195646,note:'昭和56年二改・昭和57.11.30発行',list:'126-9-3-13'},
    {name:'佐賀南部',north:33.25329832809,west:130.247681470583,south:33.1699768459426,east:130.372672402135,note:'昭和56年二改・昭和57.12.28発行',list:'126-9-4-11'}
]});
dataset.age.push({
  folderName:'04', start:1998, end:2001, scale:'1/25000', mapList: [
    {name:'中原',north:33.4199482792444,west:130.372665755238,south:33.3366268240746,east:130.497656705462,note:'平成13年修正・平成15.2.1発行',list:'125-12-2-13'},
    {name:'鳥栖',north:33.4199506367706,west:130.497654469919,south:33.3366291877748,east:130.622645442049,note:'平成13年修正・平成14.6.1発行',list:'125-8-4-14'},
    {name:'柳川',north:33.1699768459426,west:130.372672402135,south:33.0866553445002,east:130.497663356969,note:'平成13年修正・平成14.9.1発行',list:'126-10-1-10'},
    {name:'佐賀空港',north:33.1699745152316,west:130.247683666394,south:33.0866530076693,east:130.372674599528,note:'平成10年部修・平成10.7.28発行',list:'126-10-3-9B'},
    {name:'小城',north:33.3366198010595,west:130.122690562389,south:33.25329832809,east:130.247681470583,note:'平成11年部修・平成12.3.1発行',list:'126-13-1-11B'},
    {name:'牛津',north:33.2532960035651,west:130.122692756553,south:33.1699745152316,east:130.247683666394,note:'平成11年部修・平成12.4.1発行',list:'126-13-2-11B'},
    {name:'久留米',north:33.3366268240746,west:130.497656705462,south:33.2533053696452,east:130.622647679083,note:'平成10年修正・平成11.6.1発行',list:'126-5-3-11B'},
    {name:'八女',north:33.2533030111412,west:130.497658931795,south:33.1699815412577,east:130.622649906897,note:'平成10年修正・平成11.11.1発行',list:'126-5-4-10B'},
    {name:'久留米西部',north:33.3366244717145,west:130.372667980026,south:33.2533030111412,east:130.497658931795,note:'平成10年修正・平成11.12.1発行',list:'126-9-1-12B'},
    {name:'羽犬塚',north:33.2533006639524,west:130.372670195646,south:33.169979187955,east:130.497661148951,note:'平成10年修正・平成11.5.1発行',list:'126-9-2-12B'},
    {name:'佐賀北部',north:33.3366221307057,west:130.247679265686,south:33.2533006639524,east:130.372670195646,note:'平成10年修正・平成10.7.28発行',list:'126-9-3-16B'},
    {name:'佐賀南部',north:33.25329832809,west:130.247681470583,south:33.1699768459426,east:130.372672402135,note:'平成10年修正・平成10.7.28発行',list:'126-9-4-14B'}
]});
kjmapDataSet['nagasaki'] = new Object();
dataset = kjmapDataSet['nagasaki'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1900, end:1901, scale:'1/20000', mapList: [
    {name:'矢上',north:32.8033432483131,west:129.900613328859,south:32.7366859770879,east:130.000606031515,note:'明治34年測図 ',list:'s1806'},
    {name:'茂木',north:32.7366841597738,west:129.900615024194,south:32.6700268886647,east:130.000607727931,note:'明治34年測図 ',list:'s1807'},
    {name:'時津',north:32.8700005136029,west:129.800620640952,south:32.8033432483131,east:129.900613328859,note:'明治34年測図 ',list:'s1809'},
    {name:'長﨑',north:32.80334143492,west:129.800622335173,south:32.7366841597738,east:129.900615024194,note:'明治34年測図 ',list:'s1810'},
    {name:'深堀',north:32.7366823496356,west:129.800624023798,south:32.670025074621,east:129.900616713928,note:'明治34年測図 ',list:'s1812'},
    {name:'諫早',north:32.8700041540956,west:130.000602621795,south:32.8033468966601,east:130.100595337049,note:'明治33年測図・明治35.12.28発行',list:'s1851'},
    {name:'松原',north:33.0033204643424,west:129.900608209075,south:32.9366632226994,east:130.000600908457,note:'明治33年測図・明治35.12.28発行',list:'s1853'},
    {name:'大村',north:32.9366613955895,west:129.900609921317,south:32.8700041540956,east:130.000602621795,note:'明治33年測図・明治35.12.28発行',list:'s1854'},
    {name:'喜々津村',north:32.8700023302484,west:129.900611627906,south:32.803345068895,east:130.000604329476,note:'明治33年測図・明治35.12.28発行',list:'s1855'}
]});
dataset.age.push({
  folderName:'00', start:1924, end:1926, scale:'1/25000', mapList: [
    {name:'諫早',north:32.919998461166,west:130.000601337323,south:32.8366768951996,east:130.125592232702,note:'大正15年測図・昭和4.6.30発行',list:'126-15-4-1'},
    {name:'武留路山',north:33.0033200078789,west:129.875610465069,south:32.919998461166,east:130.000601337323,note:'大正13年測図・昭和2.5.30発行',list:'132-3-1-1'},
    {name:'長與浦',north:32.9199939089527,west:129.750623878251,south:32.8366723306766,east:129.875614730857,note:'大正13年測図・昭和23.4.30発行',list:'132-3-4-2'},
    {name:'長崎東北部',north:32.8366723306766,west:129.875614730857,south:32.7533507531592,east:130.000605606533,note:'大正13年測図・昭和2.9.25発行',list:'132-4-1-1'},
    {name:'長崎東南部',north:32.7533484816167,west:129.875616850558,south:32.6700268886647,east:130.000607727931,note:'大正13年測図・昭和2.4.25発行',list:'132-4-2-1'},
    {name:'長崎西北部',north:32.8366700652767,west:129.750625996193,south:32.7533484816167,east:129.875616850558,note:'大正13年測図・昭和2.8.25発行',list:'132-4-3-1'},
    {name:'長崎西南部',north:32.7533462212936,west:129.750628105393,south:32.6700246222291,east:129.875618961509,note:'大正13年測図・昭和2.7.25発行',list:'132-4-4-1'}
]});
dataset.age.push({
  folderName:'01', start:1954, end:1954, scale:'1/25000', mapList: [
    {name:'諫早',north:32.919998461166,west:130.000601337323,south:32.8366768951996,east:130.125592232702,note:'昭和29年二修・昭和31.11.30発行',list:'126-15-4-3B'},
    {name:'武留路山',north:33.0033200078789,west:129.875610465069,south:32.919998461166,east:130.000601337323,note:'昭和29年修正・昭和31.11.30発行',list:'132-3-1-3'},
    {name:'大村',north:32.9199961794244,west:129.875612602371,south:32.8366746073212,east:130.000603476342,note:'昭和29年修正・昭和31.11.30発行',list:'132-3-2-3B'},
    {name:'長與浦',north:32.9199939089527,west:129.750623878251,south:32.8366723306766,east:129.875614730857,note:'昭和29年修正・昭和31.11.30発行',list:'132-3-4-3B'},
    {name:'長崎東北部',north:32.8366723306766,west:129.875614730857,south:32.7533507531592,east:130.000605606533,note:'昭和29年修正・昭和31.11.30発行',list:'132-4-1-3'},
    {name:'長崎東南部',north:32.7533484816167,west:129.875616850558,south:32.6700268886647,east:130.000607727931,note:'昭和29年修正・昭和31.6.30発行',list:'132-4-2-3'},
    {name:'長崎西北部',north:32.8366700652767,west:129.750625996193,south:32.7533484816167,east:129.875616850558,note:'昭和29年修正・昭和31.11.30発行',list:'132-4-3-3B'},
    {name:'長崎西南部',north:32.7533462212936,west:129.750628105393,south:32.6700246222291,east:129.875618961509,note:'昭和29年修正・昭和31.11.30発行',list:'132-4-4-4B'}
]});
dataset.age.push({
  folderName:'02', start:1970, end:1970, scale:'1/25000', mapList: [
    {name:'諫早',north:32.9199984083051,west:129.997712697549,south:32.8366768421972,east:130.122703592433,note:'昭和45年改測・昭和48.2.28発行',list:'126-15-4-4'},
    {name:'武留路山',north:33.0033199551609,west:129.872721825791,south:32.9199984083051,east:129.997712697549,note:'昭和45年改測・昭和47.7.30発行',list:'132-3-1-4'},
    {name:'大村',north:32.9199961268238,west:129.872723962848,south:32.8366745545784,east:129.997714836324,note:'昭和45年改測・昭和47.7.30発行',list:'132-3-2-4'},
    {name:'長浦',north:32.9199938566127,west:129.747735238978,south:32.8366722781936,east:129.87272609109,note:'昭和45年改測・昭和48.2.28発行',list:'132-3-4-4'},
    {name:'長崎東北部',north:32.8366722781936,west:129.87272609109,south:32.7533507005346,east:129.997716966274,note:'昭和45年改測・昭和46.7.30発行',list:'132-4-1-4'},
    {name:'長崎東南部',north:32.7533484292512,west:129.872728210549,south:32.6700268361583,east:129.99771908743,note:'昭和45年改測・昭和47.10.30発行',list:'132-4-2-4'},
    {name:'長崎西北部',north:32.8366700130536,west:129.747737356676,south:32.7533484292512,east:129.872728210549,note:'昭和45年改測・昭和48.2.28発行',list:'132-4-3-4'},
    {name:'長崎西南部',north:32.7533461691875,west:129.747739465634,south:32.6700245699814,east:129.872730321258,note:'昭和45年改測・昭和47.4.30発行',list:'132-4-4-5'}
]});
dataset.age.push({
  folderName:'03', start:1982, end:1983, scale:'1/25000', mapList: [
    {name:'諫早',north:32.9199984083051,west:129.997712697549,south:32.8366768421972,east:130.122703592433,note:'昭和58年修正・昭和60.1.30発行',list:'126-15-4-6'},
    {name:'武留路山',north:33.0033199551609,west:129.872721825791,south:32.9199984083051,east:129.997712697549,note:'昭和58年修正・昭和60.2.28発行',list:'132-3-1-6'},
    {name:'大村',north:32.9199961268238,west:129.872723962848,south:32.8366745545784,east:129.997714836324,note:'昭和58年修正・昭和59.12.28発行',list:'132-3-2-6B'},
    {name:'長浦',north:32.9199938566127,west:129.747735238978,south:32.8366722781936,east:129.87272609109,note:'昭和58年修正・昭和60.3.30発行',list:'132-3-4-6'},
    {name:'長崎東北部',north:32.8366722781936,west:129.87272609109,south:32.7533507005346,east:129.997716966274,note:'昭和57年修正・昭和57.11.30発行',list:'132-4-1-6B'},
    {name:'長崎東南部',north:32.7533484292512,west:129.872728210549,south:32.6700268361583,east:129.99771908743,note:'昭和57年修正・昭和58.3.30発行',list:'132-4-2-7'},
    {name:'長崎西北部',north:32.8366700130536,west:129.747737356676,south:32.7533484292512,east:129.872728210549,note:'昭和57年修正・昭和57.12.28発行',list:'132-4-3-6B'},
    {name:'長崎西南部',north:32.7533461691875,west:129.747739465634,south:32.6700245699814,east:129.872730321258,note:'昭和57年修正・昭和57.12.28発行',list:'132-4-4-7'}
]});
dataset.age.push({
  folderName:'04', start:1996, end:2000, scale:'1/25000', mapList: [
    {name:'諫早',north:32.9199984083051,west:129.997712697549,south:32.8366768421972,east:130.122703592433,note:'平成11年部修・平成13.1.1発行',list:'126-15-4-8'},
    {name:'武留路山',north:33.0033199551609,west:129.872721825791,south:32.9199984083051,east:129.997712697549,note:'平成12年修正・平成13.4.1発行',list:'132-3-1-8B'},
    {name:'大村',north:32.9199961268238,west:129.872723962848,south:32.8366745545784,east:129.997714836324,note:'平成12年修正・平成13.4.1発行',list:'132-3-2-8B'},
    {name:'長浦',north:32.9199938566127,west:129.747735238978,south:32.8366722781936,east:129.87272609109,note:'平成12年修正・平成13.4.1発行',list:'132-3-4-8B'},
    {name:'長崎東北部',north:32.8366722781936,west:129.87272609109,south:32.7533507005346,east:129.997716966274,note:'平成11年部修・平成12.3.1発行',list:'132-4-1-10B'},
    {name:'長崎東南部',north:32.7533484292512,west:129.872728210549,south:32.6700268361583,east:129.99771908743,note:'平成11年部修・平成12.9.1発行',list:'132-4-2-10B'},
    {name:'長崎西北部',north:32.8366700130536,west:129.747737356676,south:32.7533484292512,east:129.872728210549,note:'平成8年修正・平成9.11.1発行',list:'132-4-3-9B'},
    {name:'長崎西南部',north:32.7533461691875,west:129.747739465634,south:32.6700245699814,east:129.872730321258,note:'平成11年部修・平成12.7.1発行',list:'132-4-4-10B'}
]});
kjmapDataSet['sasebo'] = new Object();
dataset = kjmapDataSet['sasebo'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1900, end:1901, scale:'1/20000', mapList: [
    {name:'世知原',north:33.2699529987283,west:129.700619417981,south:33.2032957882967,east:129.800612085296,note:'明治34年測図 ',list:'s1828'},
    {name:'佐世保',north:33.203293962699,west:129.700621139273,south:33.136636742493,east:129.800613807759,note:'明治34年測図 ',list:'s1830'},
    {name:'針尾嶋',north:33.136634920122,west:129.700622854886,south:33.0699777001294,east:129.800615524538,note:'明治34年測図 ',list:'s1832'},
    {name:'佐佐',north:33.2699511771963,west:129.600628485741,south:33.203293962699,east:129.700621139273,note:'明治33年測図 ',list:'s1836'},
    {name:'相浦',north:33.2032921443783,west:129.600630200155,south:33.136634920122,east:129.700622854886,note:'明治34年測図 ',list:'s1838'},
    {name:'面高',north:33.1366330323267,west:129.596619272395,south:33.0699758809878,east:129.700624564838,note:'明治34年測図 ',list:'s1840'}
]});
dataset.age.push({
  folderName:'00', start:1924, end:1924, scale:'1/25000', mapList: [
    {name:'蔵宿',north:33.2532891509322,west:129.750615318408,south:33.1699676439701,east:129.875606163874,note:'大正13年測図・昭和2.4.25発行',list:'132-1-4-1'},
    {name:'佐世保',north:33.2532868716041,west:129.62562664772,south:33.1699653583128,east:129.750617471649,note:'大正13年測図・昭和2.10.25発行',list:'132-5-2-1'},
    {name:'佐世保南部',north:33.1699630840115,west:129.625628790231,south:33.0866415454551,east:129.750619616014,note:'大正13年測図・昭和2.3.25発行',list:'132-6-1-1'}
]});
dataset.age.push({
  folderName:'01', start:1971, end:1971, scale:'1/25000', mapList: [
    {name:'蔵宿',north:33.2532890981256,west:129.74772668012,south:33.1699675910177,east:129.872717525088,note:'昭和46年改測・昭和48.2.28発行',list:'132-1-4-4'},
    {name:'早岐',north:33.1699653056227,west:129.747728833113,south:33.0866437732204,east:129.872719679882,note:'昭和46年改測・昭和48.1.30発行',list:'132-2-3-4'},
    {name:'佐世保北部',north:33.2532868190608,west:129.622738009681,south:33.1699653056227,east:129.747728833113,note:'昭和46年改測・昭和48.3.30発行',list:'132-5-2-6'},
    {name:'佐世保軍港',north:33.169963031584,west:129.622740151945,south:33.0866414928817,east:129.747730977231,note:'昭和46年改測・昭和47.10.30発行',list:'132-6-1-4'}
]});
dataset.age.push({
  folderName:'02', start:1985, end:1987, scale:'1/25000', mapList: [
    {name:'蔵宿',north:33.2532890981256,west:129.74772668012,south:33.1699675910177,east:129.872717525088,note:'昭和62年修正・昭和63.7.30発行',list:'132-1-4-6'},
    {name:'早岐',north:33.1699653056227,west:129.747728833113,south:33.0866437732204,east:129.872719679882,note:'昭和60年修正・昭和61.10.30発行',list:'132-2-3-6'},
    {name:'佐世保北部',north:33.2532868190608,west:129.622738009681,south:33.1699653056227,east:129.747728833113,note:'昭和60年修正・昭和62.4.30発行',list:'132-5-2-8B'},
    {name:'佐世保南部',north:33.169963031584,west:129.622740151945,south:33.0866414928817,east:129.747730977231,note:'昭和60年修正・昭和61.8.30発行',list:'132-6-1-6B'}
]});
dataset.age.push({
  folderName:'03', start:1997, end:1998, scale:'1/25000', mapList: [
    {name:'蔵宿',north:33.2532890981256,west:129.74772668012,south:33.1699675910177,east:129.872717525088,note:'平成9年修正・平成10.7.1発行',list:'132-1-4-9B'},
    {name:'早岐',north:33.1699653056227,west:129.747728833113,south:33.0866437732204,east:129.872719679882,note:'平成9年修正・平成10.5.1発行',list:'132-2-3-8B'},
    {name:'佐世保北部',north:33.2532868190608,west:129.622738009681,south:33.1699653056227,east:129.747728833113,note:'平成10年部修・平成11.9.1発行',list:'132-5-2-10B'},
    {name:'佐世保南部',north:33.169963031584,west:129.622740151945,south:33.0866414928817,east:129.747730977231,note:'平成12年修正・平成13.3.1発行',list:'132-6-1-9'}
]});
kjmapDataSet['kumamoto'] = new Object();
dataset = kjmapDataSet['kumamoto'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'2man', start:1900, end:1901, scale:'1/20000', mapList: [
    {name:'大津',north:32.9366780986293,west:130.800529058717,south:32.8700542180917,east:130.900521882511,note:'明治34年測図・明治36.9.30発行',list:'s1784'},
    {name:'陣内',north:32.870019003461,west:130.80053082586,south:32.8033617767036,east:130.900523651384,note:'明治34年測図・明治36.9.30発行',list:'s1786'},
    {name:'木山',north:32.803359891675,west:130.800532587167,south:32.7366693286788,east:130.90052541441,note:'明治34年測図・明治36.12.28発行',list:'s1788'},
    {name:'七瀧',north:32.7367007732618,west:130.800534342657,south:32.6700768627017,east:130.900527168979,note:'明治34年測図・明治36.9.30発行',list:'s1789'},
    {name:'竹迫',north:32.9366762140053,west:130.700538015068,south:32.8700523296806,east:130.800530824978,note:'明治33年測図・明治36.3.30発行',list:'s1790'},
    {name:'熊本',north:32.8700171222025,west:130.700539775504,south:32.803359891675,east:130.800532587167,note:'明治34年測図・明治36.9.30発行',list:'s1792'},
    {name:'砂取',north:32.8033580137846,west:130.700541530127,south:32.7366674470355,east:130.800534343533,note:'明治34年測図・明治36.12.28発行',list:'s1794'},
    {name:'御舩',north:32.7366988987421,west:130.700543278954,south:32.6700749844412,east:130.800536091473,note:'明治34年測図・明治36.9.30発行',list:'s1796'},
    {name:'植木',north:32.9366743365507,west:130.600546978579,south:32.8700504484204,east:130.700539774625,note:'明治33年測図・明治36.3.30発行',list:'s1797'},
    {name:'金峰山',north:32.8700152481006,west:130.600548732302,south:32.8033580137846,east:130.700541530127,note:'明治34年測図・明治36.9.30発行',list:'s1799'},
    {name:'川尻',north:32.803356087026,west:130.597550748729,south:32.7366655725175,east:130.700543279827,note:'明治34年測図・明治36.12.28発行',list:'s1801'},
    {name:'宇土',north:32.7366970313533,west:130.600552222394,south:32.6700731132931,east:130.700545021133,note:'明治34年測図・明治36.9.30発行',list:'s1803'},
    {name:'髙瀬',north:32.9366724662713,west:130.500555949221,south:32.8700485743168,east:130.600548731427,note:'明治33年測図・明治35.9.30発行',list:'s1804'},
    {name:'小天',north:32.870013381161,west:130.500557696227,south:32.803356143038,east:130.600550480235,note:'明治34年測図・明治36.9.30発行',list:'s1805'}
]});
dataset.age.push({
  folderName:'00', start:1926, end:1926, scale:'1/25000', mapList: [
    {name:'大津',north:32.9200123876698,west:130.75053397749,south:32.8366908579761,east:130.875536101235,note:'大正15年測図・昭和3.12.28発行',list:'126-3-4-1'},
    {name:'木山',north:32.8366885027157,west:130.750536179496,south:32.7533669673961,east:130.875538304573,note:'大正15年測図・昭和4.2.28発行',list:'126-4-3-1'},
    {name:'御舩',north:32.7533646174138,west:130.750538372414,south:32.6700430664479,east:130.875540498815,note:'大正15年測図・昭和4.1.30発行',list:'126-4-4-1'},
    {name:'植木',north:32.9200100385392,west:130.625545176426,south:32.8366885029243,east:130.750547278503,note:'大正15年測図・昭和4.1.30発行',list:'126-7-2-1'},
    {name:'伊倉',north:32.9200077006125,west:130.500556386514,south:32.8366861590402,east:130.625558466966,note:'大正15年測図・昭和4.1.30発行',list:'126-7-4-1'},
    {name:'熊本',north:32.8366861588326,west:130.62554736796,south:32.753364617622,east:130.750549471422,note:'大正15年測図・昭和3.12.28発行',list:'126-8-1-1'},
    {name:'宇土',north:32.7533622787834,west:130.62554955045,south:32.6700407219567,east:130.750551655289,note:'大正15年測図・昭和4.1.30発行',list:'126-8-2-1'},
    {name:'舩津',north:32.8366838261284,west:130.500558567566,south:32.7533622789906,east:130.625560649457,note:'大正15年測図・昭和3.12.28発行',list:'126-8-3-1'},
    {name:'網津',north:32.7533599513069,west:130.500560739617,south:32.6700383885832,east:130.625562822938,note:'大正15年測図・昭和3.12.28発行',list:'126-8-4-1'}
]});
dataset.age.push({
  folderName:'01', start:1965, end:1971, scale:'1/25000', mapList: [
    {name:'肥後大津',north:32.9200123332522,west:130.747645336185,south:32.8366908032124,east:130.87263636042,note:'昭和46年改測・昭和47.8.30発行',list:'126-3-4-4'},
    {name:'健軍',north:32.8366884484196,west:130.747647537949,south:32.7533669127551,east:130.872638563516,note:'昭和40年改測・昭和42.5.30発行',list:'126-4-3-4'},
    {name:'御船',north:32.7533645632395,west:130.747649730626,south:32.6700430119298,east:130.872640757518,note:'昭和40年改測・昭和42.5.30発行',list:'126-4-4-5'},
    {name:'植木',north:32.9200099843804,west:130.622656535379,south:32.8366884484196,east:130.747647537949,note:'昭和46年改測・昭和48.3.30発行',list:'126-7-2-5'},
    {name:'伊倉',north:32.9200076467127,west:130.497667745724,south:32.8366861047948,east:130.622658726671,note:'昭和45年改測・昭和48.2.28発行',list:'126-7-4-3'},
    {name:'熊本',north:32.8366861047948,west:130.622658726671,south:32.7533645632395,east:130.747649730626,note:'昭和40年改測・昭和43.3.30発行',list:'126-8-1-7'},
    {name:'宇土',north:32.7533622248667,west:130.622660908919,south:32.6700406676964,east:130.747651914252,note:'昭和40年改測・昭和42.5.30発行',list:'126-8-2-4'},
    {name:'舩津',north:32.836683772349,west:130.497669926534,south:32.7533622248667,east:130.622660908919,note:'昭和40年改測・昭和42.7.30発行',list:'126-8-3-3'},
    {name:'網津',north:32.753359897648,west:130.497672098343,south:32.6700383345809,east:130.62266308216,note:'昭和40年改測・昭和42.6.30発行',list:'126-8-4-3'}
]});
dataset.age.push({
  folderName:'02', start:1983, end:1983, scale:'1/25000', mapList: [
    {name:'肥後大津',north:32.9200123332522,west:130.747645336185,south:32.8366908032124,east:130.87263636042,note:'昭和58年修正・昭和59.11.30発行',list:'126-3-4-6'},
    {name:'健軍',north:32.8366884484196,west:130.747647537949,south:32.7533669127551,east:130.872638563516,note:'昭和58年修正・昭和59.9.30発行',list:'126-4-3-9'},
    {name:'御船',north:32.7533645632395,west:130.747649730626,south:32.6700430119298,east:130.872640757518,note:'昭和58年修正・昭和59.12.28発行',list:'126-4-4-8'},
    {name:'植木',north:32.9200099843804,west:130.622656535379,south:32.8366884484196,east:130.747647537949,note:'昭和58年修正・昭和60.2.28発行',list:'126-7-2-7'},
    {name:'伊倉',north:32.9200076467127,west:130.497667745724,south:32.8366861047948,east:130.622658726671,note:'昭和58年修正・昭和59.9.30発行',list:'126-7-4-5'},
    {name:'熊本',north:32.8366861047948,west:130.622658726671,south:32.7533645632395,east:130.747649730626,note:'昭和58年修正・昭和60.3.30発行',list:'126-8-1-12'},
    {name:'宇土',north:32.7533622248667,west:130.622660908919,south:32.6700406676964,east:130.747651914252,note:'昭和58年修正・昭和59.12.28発行',list:'126-8-2-8'},
    {name:'肥後船津',north:32.836683772349,west:130.497669926534,south:32.7533622248667,east:130.622660908919,note:'昭和58年修正・昭和59.12.28発行',list:'126-8-3-6'},
    {name:'網津',north:32.753359897648,west:130.497672098343,south:32.6700383345809,east:130.62266308216,note:'昭和58年修正・昭和59.9.30発行',list:'126-8-4-6'}
]});
dataset.age.push({
  folderName:'03', start:1998, end:2000, scale:'1/25000', mapList: [
    {name:'肥後大津',north:32.9200123332522,west:130.747645336185,south:32.8366908032124,east:130.87263636042,note:'平成10年修正・平成11.7.1発行',list:'126-3-4-9B'},
    {name:'健軍',north:32.8366884484196,west:130.747647537949,south:32.7533669127551,east:130.872638563516,note:'平成10年修正・平成11.7.1発行',list:'126-4-3-12'},
    {name:'御船',north:32.7533645632395,west:130.747649730626,south:32.6700430119298,east:130.872640757518,note:'平成12年修正・平成13.4.1発行',list:'126-4-4-11B'},
    {name:'植木',north:32.9200099843804,west:130.622656535379,south:32.8366884484196,east:130.747647537949,note:'平成10年修正・平成11.7.1発行',list:'126-7-2-10B'},
    {name:'伊倉',north:32.9200076467127,west:130.497667745724,south:32.8366861047948,east:130.622658726671,note:'平成10年修正・平成11.12.1発行',list:'126-7-4-8'},
    {name:'熊本',north:32.8366861047948,west:130.622658726671,south:32.7533645632395,east:130.747649730626,note:'平成10年修正・平成11.7.1発行',list:'126-8-1-16B'},
    {name:'宇土',north:32.7533622248667,west:130.622660908919,south:32.6700406676964,east:130.747651914252,note:'平成12年修正・平成13.5.1発行',list:'126-8-2-13B'},
    {name:'肥後船津',north:32.836683772349,west:130.497669926534,south:32.7533622248667,east:130.622660908919,note:'平成11年部修・平成11.10.1発行',list:'126-8-3-10B'},
    {name:'網津',north:32.753359897648,west:130.497672098343,south:32.6700383345809,east:130.62266308216,note:'平成12年修正・平成13.5.1発行',list:'126-8-4-10B'}
]});
kjmapDataSet['oita'] = new Object();
dataset = kjmapDataSet['oita'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1914, end:1914, scale:'1/25000', mapList: [
    {name:'神﨑',north:33.2575067160151,west:131.750435440425,south:33.1700057498752,east:131.875426753156,note:'大正3年測図・大正6.9.3発行',list:'121-1-4-1'},
    {name:'家嶋',north:33.3366485611101,west:131.625444384505,south:33.2533271604804,east:131.750435557225,note:'大正3年測図・大正7.5.30発行',list:'121-5-1-2'},
    {name:'鶴﨑',north:33.2533247003916,west:131.625446707008,south:33.1700032840361,east:131.750437880716,note:'大正3年測図・大正7.7.30発行',list:'121-5-2-2'},
    {name:'別府',north:33.336646106838,west:131.500455556523,south:33.2533247003916,east:131.625446707008,note:'大正3年測図・大正7.5.30発行',list:'121-5-3-2'},
    {name:'大分',north:33.2533222515148,west:131.500457868412,south:33.1700008293726,east:131.625449019939,note:'大正3年測図・大正4.6.30発行',list:'121-5-4-1'}
]});
dataset.age.push({
  folderName:'01', start:1973, end:1973, scale:'1/25000', mapList: [
    {name:'坂ノ市',north:33.2577085561063,west:131.747546792349,south:33.1700056927606,east:131.872538110196,note:'昭和48年改測・昭和50.3.30発行',list:'121-1-4-4'},
    {name:'家島',north:33.336648504262,west:131.622555742573,south:33.2533271034983,east:131.747546914779,note:'昭和48年改測・昭和50.3.30発行',list:'121-5-1-5'},
    {name:'鶴崎',north:33.2533246436685,west:131.622558064831,south:33.1700032271796,east:131.747549238026,note:'昭和48年改測・昭和49.8.30発行',list:'121-5-2-5B'},
    {name:'別府東部',north:33.3366460502498,west:131.497566914859,south:33.2533246436685,east:131.622558064831,note:'昭和48年改測・昭和49.9.30発行',list:'121-5-3-5'},
    {name:'大分',north:33.2533221950509,west:131.497569226502,south:33.1700007727746,east:131.622560377517,note:'昭和48年改測・昭和49.9.30発行',list:'121-5-4-5B'}
]});
dataset.age.push({
  folderName:'02', start:1984, end:1986, scale:'1/25000', mapList: [
    {name:'坂ノ市',north:33.259899287399,west:131.747546731124,south:33.1700056927606,east:131.872538110196,note:'昭和59年修正・昭和62.2.28発行',list:'121-1-4-5'},
    {name:'家島',north:33.336648504262,west:131.622555742573,south:33.2533271034983,east:131.747546914779,note:'昭和61年修正・昭和62.9.30発行',list:'121-5-1-7B'},
    {name:'鶴崎',north:33.2533246436685,west:131.622558064831,south:33.1700032271796,east:131.747549238026,note:'昭和61年修正・昭和63.3.30発行',list:'121-5-2-7B'},
    {name:'別府東部',north:33.3366460502498,west:131.497566914859,south:33.2533246436685,east:131.622558064831,note:'昭和61年修正・昭和62.6.30発行',list:'121-5-3-7B'},
    {name:'大分',north:33.2533221950509,west:131.497569226502,south:33.1700007727746,east:131.622560377517,note:'昭和61年修正・昭和62.8.30発行',list:'121-5-4-7C'}
]});
dataset.age.push({
  folderName:'03', start:1997, end:2001, scale:'1/25000', mapList: [
    {name:'坂ノ市',north:33.2601031042599,west:131.747546725427,south:33.1700056927606,east:131.872538110196,note:'平成9年部修・平成10.5.1発行',list:'121-1-4-6'},
    {name:'家島',north:33.336648504262,west:131.622555742573,south:33.2533271034983,east:131.747546914779,note:'平成10年部修・平成11.5.1発行',list:'121-5-1-9B'},
    {name:'鶴崎',north:33.2533246436685,west:131.622558064831,south:33.1700032271796,east:131.747549238026,note:'平成13年部修・平成14.6.1発行',list:'121-5-2-12'},
    {name:'別府東部',north:33.3366460502498,west:131.497566914859,south:33.2533246436685,east:131.622558064831,note:'平成10年修正・平成11.10.1発行',list:'121-5-3-9B'},
    {name:'大分',north:33.2533221950509,west:131.497569226502,south:33.1700007727746,east:131.622560377517,note:'平成10年修正・平成12.1.1発行',list:'121-5-4-10C'}
]});
kjmapDataSet['miyazaki'] = new Object();
dataset = kjmapDataSet['miyazaki'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1902, end:1902, scale:'1/50000', mapList: [
    {name:'宮﨑',north:32.0034584249641,west:131.250513472514,south:31.8368150624345,east:131.500495742195,note:'明治35年測図・明治37.12.28発行',list:'123-9-1'}
]});
dataset.age.push({
  folderName:'01', start:1935, end:1935, scale:'1/50000', mapList: [
    {name:'宮﨑',north:32.0034584249641,west:131.250513472514,south:31.8368150624345,east:131.500495742195,note:'昭和10年測図・昭和12.3.30発行',list:'123-9-15',war:true}
]});
dataset.age.push({
  folderName:'02', start:1962, end:1962, scale:'1/25000', mapList: [
    {name:'宮崎北部',north:32.0034607162302,west:131.3726137972,south:31.9201390505488,east:131.497604941708,note:'昭和37年測図・昭和40.8.30発行',list:'123-9-1-1'},
    {name:'宮崎',north:31.9201366997943,west:131.372615950775,south:31.8368150081041,east:131.497607096265,note:'昭和37年測図・昭和40.8.30発行',list:'123-9-2-1'},
    {name:'日向本庄',north:32.003458370883,west:131.247624827567,south:31.9201366997943,east:131.372615950775,note:'昭和37年測図・昭和40.8.30発行',list:'123-9-3-1'},
    {name:'田野',north:31.9201343598761,west:131.247626971186,south:31.836812662809,east:131.372618095428,note:'昭和37年測図・昭和40.8.30発行',list:'123-9-4-1'}
]});
dataset.age.push({
  folderName:'03', start:1979, end:1979, scale:'1/25000', mapList: [
    {name:'宮崎北部',north:32.0034607162302,west:131.3726137972,south:31.9201390505488,east:131.497604941708,note:'昭和54年測図・昭和56.1.30発行',list:'123-9-1-5B'},
    {name:'宮崎',north:31.9201366997943,west:131.372615950775,south:31.8368150081041,east:131.497607096265,note:'昭和54年測図・昭和56.3.30発行',list:'123-9-2-5'},
    {name:'日向本庄',north:32.003458370883,west:131.247624827567,south:31.9201366997943,east:131.372615950775,note:'昭和54年測図・昭和55.12.28発行',list:'123-9-3-5B'},
    {name:'田野',north:31.9201343598761,west:131.247626971186,south:31.836812662809,east:131.372618095428,note:'昭和54年測図・昭和56.5.30発行',list:'123-9-4-5'}
]});
dataset.age.push({
  folderName:'04', start:1999, end:2001, scale:'1/25000', mapList: [
    {name:'宮崎北部',north:32.0034607162302,west:131.3726137972,south:31.9201390505488,east:131.497604941708,note:'平成12年測図・平成13.4.1発行',list:'123-9-1-10B'},
    {name:'宮崎',north:31.9201366997943,west:131.372615950775,south:31.8368150081041,east:131.497607096265,note:'平成13年測図・平成15.2.1発行',list:'123-9-2-9'},
    {name:'日向本庄',north:32.003458370883,west:131.247624827567,south:31.9201366997943,east:131.372615950775,note:'平成12年測図・平成13.4.1発行',list:'123-9-3-9B'},
    {name:'田野',north:31.9201343598761,west:131.247626971186,south:31.836812662809,east:131.372618095428,note:'平成11年測図・平成12.3.25発行',list:'123-9-4-8B'}
]});
kjmapDataSet['miyakonojyou'] = new Object();
dataset = kjmapDataSet['miyakonojyou'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1902, end:1902, scale:'1/50000', mapList: [
    {name:'都城',north:31.836805745164,west:131.0005398056,south:31.6701623071001,east:131.250521994758,note:'明治35年測図・明治37.6.30発行',list:'123-14-1'}
]});
dataset.age.push({
  folderName:'01', start:1932, end:1932, scale:'1/25000', mapList: [
    {name:'都城',north:31.753481723729,west:131.000541911945,south:31.6701599940223,east:131.125532996553,note:'昭和7年修正・昭和10.8.30発行',list:'123-14-4-4'},
    {name:'庄内',north:31.836805745164,west:131.0005398056,south:31.7534840314189,east:131.125530889089,note:'昭和7年修正・昭和10.10.30発行',list:'123-14-3-3'},
    {name:'高城',north:31.8368080582433,west:131.125528772851,south:31.7534863499165,east:131.250519877453,note:'昭和7年修正・昭和12.2.28発行',list:'123-14-1-3'},
    {name:'梶山',north:31.7534840314189,west:131.125530889089,south:31.6701623071001,east:131.250521994758,note:'昭和7年修正・昭和10.4.30発行',list:'123-14-2-3'}
]});
dataset.age.push({
  folderName:'02', start:1966, end:1966, scale:'1/25000', mapList: [
    {name:'都城',north:31.7534816705234,west:130.997653266829,south:31.6701599406917,east:131.12264435095,note:'昭和41年改測・昭和44.3.30発行',list:'123-14-4-6'},
    {name:'庄内',north:31.8368056918342,west:130.997651160712,south:31.7534839779634,east:131.122642243714,note:'昭和41年改測・昭和44.3.30発行',list:'123-14-3-5'},
    {name:'山王原',north:31.7534839779634,west:131.122642243714,south:31.6701622535205,east:131.247633348896,note:'昭和41年改測・昭和44.3.30発行',list:'123-14-2-5'},
    {name:'高城',north:31.8368080046629,west:131.122640127704,south:31.7534862962113,east:131.247631231818,note:'昭和41年改測・昭和44.3.30発行',list:'123-14-1-5'}
]});
dataset.age.push({
  folderName:'03', start:1979, end:1980, scale:'1/25000', mapList: [
    {name:'庄内',north:31.8368056918342,west:130.997651160712,south:31.7534839779634,east:131.122642243714,note:'昭和55年二改・昭和57.1.30発行',list:'123-14-3-8'},
    {name:'山王原',north:31.7534839779634,west:131.122642243714,south:31.6701622535205,east:131.247633348896,note:'昭和54年二改・昭和56.2.28発行',list:'123-14-2-8'},
    {name:'高城',north:31.8368080046629,west:131.122640127704,south:31.7534862962113,east:131.247631231818,note:'昭和54年二改・昭和55.11.30発行',list:'123-14-1-8'},
    {name:'都城',north:31.7534816705234,west:130.997653266829,south:31.6701599406917,east:131.12264435095,note:'昭和55年二改・昭和57.5.30発行',list:'123-14-4-9'}
]});
dataset.age.push({
  folderName:'04', start:1998, end:2001, scale:'1/25000', mapList: [
    {name:'庄内',north:31.8368056918342,west:130.997651160712,south:31.7534839779634,east:131.122642243714,note:'平成10年部修・平成10.10.1発行',list:'123-14-3-11B'},
    {name:'山王原',north:31.7534839779634,west:131.122642243714,south:31.6701622535205,east:131.247633348896,note:'平成13年修正・平成15.9.1発行',list:'123-14-2-11'},
    {name:'高城',north:31.8368080046629,west:131.122640127704,south:31.7534862962113,east:131.247631231818,note:'平成13年修正・平成15.8.1発行',list:'123-14-1-11'},
    {name:'都城',north:31.7534816705234,west:130.997653266829,south:31.6701599406917,east:131.12264435095,note:'平成13年修正・平成14.12.1発行',list:'123-14-4-12'}
]});
kjmapDataSet['kagoshima'] = new Object();
dataset = kjmapDataSet['kagoshima'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'5man', start:1902, end:1902, scale:'1/50000', mapList: [
    {name:'鹿兒嶋',north:31.6701485905878,west:130.500588172629,south:31.5035050352153,east:130.750570198921,note:'明治35年測図・明治42.7.20発行',list:'128-7-1'}
]});
dataset.age.push({
  folderName:'2man', start:1902, end:1902, scale:'1/20000', mapList: [
    {name:'帖佐',north:31.8034688177569,west:130.600576016136,south:31.736811422448,east:130.70056882774,note:'明治35年測図・明治42.7.10発行',list:'s1755'},
    {name:'加治木',north:31.7368096057397,west:130.600577673765,south:31.6701522102756,east:130.700570486192,note:'明治35年測図・明治42.7.10発行',list:'s1757'},
    {name:'大﨑鼻',north:31.6701503969668,west:130.600579325894,south:31.6034929813391,east:130.700572139139,note:'明治35年測図・明治42.7.10発行',list:'s1760'},
    {name:'櫻嶋',north:31.603491171432,west:130.600580972538,south:31.536833745629,east:130.700573786596,note:'明治35年測図・明治42.7.10発行',list:'s1763'},
    {name:'蒲生',north:31.8034670046079,west:130.500584875549,south:31.7368096057397,east:130.600577673765,note:'明治35年測図・明治42.7.10発行',list:'s1765'},
    {name:'三重嶽',north:31.7368077959745,west:130.500586526829,south:31.6701503969668,east:130.600579325894,note:'明治35年測図・明治42.7.10発行',list:'s1767'},
    {name:'伊敷村',north:31.6701485905878,west:130.500588172629,south:31.603491171432,east:130.600580972538,note:'明治35年測図・明治42.7.10発行',list:'s1769'},
    {name:'鹿兒嶋',north:31.6034893684419,west:130.500589812966,south:31.5368319391263,east:130.600582613714,note:'明治35年測図・明治42.7.10発行',list:'s1772'},
    {name:'郡山',north:31.7368059931577,west:130.400595386904,south:31.6701485905878,east:130.500588172629,note:'明治35年測図・明治42.7.10発行',list:'s1777'},
    {name:'小山田',north:31.6701467911444,west:130.400597026371,south:31.6034893684419,east:130.500589812966,note:'明治35年測図・明治42.7.10発行',list:'s1779'},
    {name:'春山',north:31.6034875723743,west:130.400598660395,south:31.5368301395276,east:130.500591447855,note:'明治35年測図・明治42.7.10発行',list:'s1781'},
    {name:'錫山',north:31.5368283468384,west:130.400600288993,south:31.4701709138357,east:130.500593077313,note:'明治35年測図・明治42.7.10発行',list:'s1783'}
]});
dataset.age.push({
  folderName:'00', start:1932, end:1932, scale:'1/25000', mapList: [
    {name:'薩摩郡山',north:31.7534703477775,west:130.375597192693,south:31.6701485905878,east:130.500588172629,note:'昭和7年修正・昭和22.12.28発行',list:'128-10-2-1'},
    {name:'伊集院',north:31.6701463423678,west:130.375599240898,south:31.5868245593485,east:130.500590222198,note:'昭和7年修正・昭和10.12.28発行',list:'128-11-1-1'},
    {name:'春山',north:31.5868223164012,west:130.375601280607,south:31.5035005275292,east:130.500592263262,note:'昭和7年修正・昭和10.9.30発行',list:'128-11-2-1'},
    {name:'永原',north:31.8367988710336,west:130.625572970704,south:31.7534771408162,east:130.750563991108,note:'昭和7年修正・昭和10.1.30発行',list:'128-6-1-1'},
    {name:'加治木',north:31.7534748656151,west:130.625575047311,south:31.6701531195271,east:130.750566068987,note:'昭和7年修正・昭和10.11.30発行',list:'128-6-2-1'},
    {name:'蒲生',north:31.8367966013956,west:130.500584047849,south:31.7534748656151,east:130.625575047311,note:'昭和7年修正・昭和10.9.30発行',list:'128-6-3-1'},
    {name:'重富',north:31.7534726012653,west:130.500586114523,south:31.6701508496445,east:130.625577115308,note:'昭和7年修正・昭和10.12.28発行',list:'128-6-4-1'},
    {name:'桜島北部',north:31.6701508496445,west:130.625577115308,south:31.5868290776662,east:130.750568138247,note:'昭和7年修正・昭和10.9.30発行',list:'128-7-1-2'},
    {name:'桜島南部',north:31.5868268131071,west:130.625579174727,south:31.5035050352153,east:130.750570198921,note:'昭和7年修正・昭和11.6.30発行',list:'128-7-2-2'},
    {name:'鹿児島北部',north:31.6701485905878,west:130.500588172629,south:31.5868268131071,east:130.625579174727,note:'昭和7年修正・昭和10.11.30発行',list:'128-7-3-2'},
    {name:'鹿児島南部',north:31.5868245593485,west:130.500590222198,south:31.5035027759847,east:130.625581225601,note:'昭和7年修正・昭和10.10.30発行',list:'128-7-4-2'}
]});
dataset.age.push({
  folderName:'01', start:1966, end:1966, scale:'1/25000', mapList: [
    {name:'薩摩郡山',north:31.7534702958252,west:130.372708548852,south:31.6701485385064,east:130.497699528306,note:'昭和41年改測・昭和44.3.30発行',list:'128-10-2-3'},
    {name:'伊集院',north:31.670146290537,west:130.372710596828,south:31.5868245073892,east:130.497701577648,note:'昭和41年改測・昭和44.3.30発行',list:'128-11-1-3'},
    {name:'春山',north:31.5868222646919,west:130.372712636309,south:31.5035004756922,east:130.497703618485,note:'昭和41年改測・昭和44.3.30発行',list:'128-11-2-3'},
    {name:'石原',north:31.8367988184567,west:130.622684326586,south:31.7534770881112,east:130.747675346506,note:'昭和41年測量・昭和43.10.30発行',list:'128-6-1-3'},
    {name:'加治木',north:31.7534748131607,west:130.622686402963,south:31.6701530669453,east:130.747677424156,note:'昭和41年測量・昭和43.2.28発行',list:'128-6-2-4'},
    {name:'蒲生',north:31.8367965490702,west:130.497695403985,south:31.7534748131607,east:130.622686402963,note:'昭和41年改測・昭和44.3.30発行',list:'128-6-3-3'},
    {name:'重富',north:31.7534725490618,west:130.49769747043,south:31.6701507973128,east:130.622688470732,note:'昭和41年改測・昭和43.2.28発行',list:'128-6-4-3'},
    {name:'桜島北部',north:31.6701507973128,west:130.622688470732,south:31.5868290252076,east:130.747679493189,note:'昭和41年改測・昭和44.3.30発行',list:'128-7-1-5'},
    {name:'桜島南部',north:31.586826760898,west:130.622690529924,south:31.5035049828803,east:130.747681553636,note:'昭和41年改測・昭和44.3.30発行',list:'128-7-2-3'},
    {name:'鹿児島北部',north:31.6701485385064,west:130.497699528306,south:31.586826760898,east:130.622690529924,note:'昭和41年改測・昭和44.1.30発行',list:'128-7-3-5'},
    {name:'鹿児島南部',north:31.5868245073892,west:130.497701577648,south:31.5035027238985,east:130.622692580571,note:'昭和41年改測・昭和44.3.30発行',list:'128-7-4-4'}
]});
dataset.age.push({
  folderName:'02', start:1982, end:1983, scale:'1/25000', mapList: [
    {name:'薩摩郡山',north:31.7534702958252,west:130.372708548852,south:31.6701485385064,east:130.497699528306,note:'昭和57年修正・昭和59.3.30発行',list:'128-10-2-6B'},
    {name:'伊集院',north:31.670146290537,west:130.372710596828,south:31.5868245073892,east:130.497701577648,note:'昭和58年修正・昭和60.4.30発行',list:'128-11-1-6B'},
    {name:'春山',north:31.5868222646919,west:130.372712636309,south:31.5035004756922,east:130.497703618485,note:'昭和58年修正・昭和60.6.30発行',list:'128-11-2-5'},
    {name:'石原',north:31.8367988184567,west:130.622684326586,south:31.7534770881112,east:130.747675346506,note:'昭和57年修正・昭和59.2.28発行',list:'128-6-1-6'},
    {name:'加治木',north:31.7534748131607,west:130.622686402963,south:31.6701530669453,east:130.747677424156,note:'昭和57年修正・昭和58.11.30発行',list:'128-6-2-7B'},
    {name:'蒲生',north:31.8367965490702,west:130.497695403985,south:31.7534748131607,east:130.622686402963,note:'昭和57年修正・昭和58.12.28発行',list:'128-6-3-6'},
    {name:'脇元',north:31.7534725490618,west:130.49769747043,south:31.6701507973128,east:130.622688470732,note:'昭和57年修正・昭和58.11.30発行',list:'128-6-4-6'},
    {name:'桜島北部',north:31.6701507973128,west:130.622688470732,south:31.5868290252076,east:130.747679493189,note:'昭和57年修正・昭和59.2.28発行',list:'128-7-1-7'},
    {name:'桜島南部',north:31.586826760898,west:130.622690529924,south:31.5035049828803,east:130.747681553636,note:'昭和57年修正・昭和59.2.28発行',list:'128-7-2-6'},
    {name:'鹿児島北部',north:31.6701485385064,west:130.497699528306,south:31.586826760898,east:130.622690529924,note:'昭和57年修正・昭和58.10.30発行',list:'128-7-3-8'},
    {name:'鹿児島南部',north:31.5868245073892,west:130.497701577648,south:31.5035027238985,east:130.622692580571,note:'昭和57年修正・昭和59.1.30発行',list:'128-7-4-7B'}
]});
dataset.age.push({
  folderName:'03', start:1996, end:2001, scale:'1/25000', mapList: [
    {name:'薩摩郡山',north:31.7534702958252,west:130.372708548852,south:31.6701485385064,east:130.497699528306,note:'平成13年修正・平成15.6.1発行',list:'128-10-2-8'},
    {name:'伊集院',north:31.670146290537,west:130.372710596828,south:31.5868245073892,east:130.497701577648,note:'平成13年修正・平成15.5.1発行',list:'128-11-1-8'},
    {name:'春山',north:31.5868222646919,west:130.372712636309,south:31.5035004756922,east:130.497703618485,note:'平成8年部修・平成9.6.1発行',list:'128-11-2-7'},
    {name:'石原',north:31.8367988184567,west:130.622684326586,south:31.7534770881112,east:130.747675346506,note:'平成10年部修・平成10.10.1発行',list:'128-6-1-8B'},
    {name:'加治木',north:31.7534748131607,west:130.622686402963,south:31.6701530669453,east:130.747677424156,note:'平成11年部修・平成12.4.1発行',list:'128-6-2-9'},
    {name:'蒲生',north:31.8367965490702,west:130.497695403985,south:31.7534748131607,east:130.622686402963,note:'平成11年部修・平成12.4.1発行',list:'128-6-3-8'},
    {name:'脇元',north:31.7534725490618,west:130.49769747043,south:31.6701507973128,east:130.622688470732,note:'平成11年部修・平成12.2.1発行',list:'128-6-4-8B'},
    {name:'桜島北部',north:31.6701507973128,west:130.622688470732,south:31.5868290252076,east:130.747679493189,note:'平成13年修正・平成15.5.1発行',list:'128-7-1-9'},
    {name:'桜島南部',north:31.586826760898,west:130.622690529924,south:31.5035049828803,east:130.747681553636,note:'平成10年部修・平成11.1.1発行',list:'128-7-2-8'},
    {name:'鹿児島北部',north:31.6701485385064,west:130.497699528306,south:31.586826760898,east:130.622690529924,note:'平成9年部修・平成10.8.1発行',list:'128-7-3-10B'},
    {name:'鹿児島南部',north:31.5868245073892,west:130.497701577648,south:31.5035027238985,east:130.622692580571,note:'平成8年部修・平成9.8.1発行',list:'128-7-4-9B'}
]});
kjmapDataSet['okinawas'] = new Object();
dataset = kjmapDataSet['okinawas'] ;
dataset.age = new Array();
dataset.age.push({
  folderName:'00', start:1919, end:1919, scale:'1/25000', mapList: [
    {name:'嘉手納',north:26.4206739316896,west:127.74804696251,south:26.3373510278663,east:127.873037641935,note:'大正8年測図・大正10.7.25発行',list:'161-10-4-8'},
    {name:'泡瀬',north:26.3373493212549,west:127.748048362863,south:26.2540264110426,east:127.873039043824,note:'大正8年測図・大正10.6.25発行',list:'161-11-3-9'},
    {name:'與那原',north:26.2540247094266,west:127.748049757092,south:26.1707017828095,east:127.873040439575,note:'大正8年測図・大正10.7.25発行',list:'161-11-4-8'},
    {name:'大城',north:26.1707000861925,west:127.748051145218,south:26.0873771331551,east:127.873041829208,note:'大正8年測図・大正10.5.25発行',list:'161-12-3-6'},
    {name:'座喜味',north:26.4206722294676,west:127.623057700424,south:26.3373493212549,east:127.748048362863,note:'大正8年測図・大正10.6.25発行',list:'161-14-2-7'},
    {name:'牧港',north:26.3373476239971,west:127.623059093077,south:26.2540247094266,east:127.748049757092,note:'大正8年測図・大正10.2.25発行',list:'161-15-1-10'},
    {name:'那覇',north:26.2540230171367,west:127.623060479641,south:26.1707000861925,east:127.748051145218,note:'大正8年測図・大正10.7.25発行',list:'161-15-2-11'},
    {name:'糸満',north:26.1706983988743,west:127.623061860135,south:26.0873754415409,east:127.748052527259,note:'大正8年測図・大正10.7.25発行',list:'161-16-1-6'},
    {name:'喜屋武岬',north:26.087373759198,west:127.623063234577,south:26.0040507954565,east:127.748053903234,note:'大正8年測図・大正9.12.25発行',list:'161-16-2-6'}
]});
dataset.age.push({
  folderName:'01', start:1973, end:1975, scale:'1/25000', mapList: [
    {name:'沖縄市北部',north:26.4206739316896,west:127.74804696251,south:26.3373510278663,east:127.873037641935,note:'昭和48年測量・昭和49.12.28発行',list:'161-10-4-1'},
    {name:'沖縄市南部',north:26.3373493212549,west:127.748048362863,south:26.2540264110426,east:127.873039043824,note:'昭和48年測量・昭和49.12.28発行',list:'161-11-3-1'},
    {name:'与那原',north:26.2540247094266,west:127.748049757092,south:26.1707017828095,east:127.873040439575,note:'昭和50年測量・昭和51.1.30発行',list:'161-11-4-1'},
    {name:'知念',north:26.1707000861925,west:127.748051145218,south:26.0873771331551,east:127.873041829208,note:'昭和50年測量・昭和51.1.30発行',list:'161-12-3-1'},
    {name:'高志保',north:26.4206722294676,west:127.623057700424,south:26.3373493212549,east:127.748048362863,note:'昭和48年測量・昭和49.12.28発行',list:'161-14-2-1'},
    {name:'大謝名',north:26.3373476239971,west:127.623059093077,south:26.2540247094266,east:127.748049757092,note:'昭和48年測量・昭和49.12.28発行',list:'161-15-1-1'},
    {name:'那覇',north:26.2540230171367,west:127.623060479641,south:26.1707000861925,east:127.748051145218,note:'昭和48年測量・昭和49.9.30発行',list:'161-15-2-1B'},
    {name:'糸満',north:26.1706983988743,west:127.623061860135,south:26.0873754415409,east:127.748052527259,note:'昭和50年測量・昭和51.2.28発行',list:'161-16-1-1'},
    {name:'喜屋武岬',north:26.087373759198,west:127.623063234577,south:26.0040507954565,east:127.748053903234,note:'昭和50年測量・昭和51.2.28発行',list:'161-16-2-1'}
]});
dataset.age.push({
  folderName:'02', start:1992, end:1994, scale:'1/25000', mapList: [
    {name:'沖縄市北部',north:26.4206739316896,west:127.74804696251,south:26.3373510278663,east:127.873037641935,note:'平成5年修正・平成6.12.1発行',list:'161-10-4-6'},
    {name:'沖縄市南部',north:26.3373493212549,west:127.748048362863,south:26.2540264110426,east:127.873039043824,note:'平成4年部修・平成5.4.1発行',list:'161-11-3-6'},
    {name:'与那原',north:26.2540247094266,west:127.748049757092,south:26.1707017828095,east:127.873040439575,note:'平成6年修正・平成7.11.1発行',list:'161-11-4-6'},
    {name:'知念',north:26.1707000861925,west:127.748051145218,south:26.0873771331551,east:127.873041829208,note:'平成4年修正・平成5.10.1発行',list:'161-12-3-4'},
    {name:'高志保',north:26.4206722294676,west:127.623057700424,south:26.3373493212549,east:127.748048362863,note:'平成4年修正・平成5.3.1発行',list:'161-14-2-5B'},
    {name:'大謝名',north:26.3373476239971,west:127.623059093077,south:26.2540247094266,east:127.748049757092,note:'平成6年修正・平成7.9.1発行',list:'161-15-1-7'},
    {name:'那覇',north:26.2540230171367,west:127.623060479641,south:26.1707000861925,east:127.748051145218,note:'平成6年修正・平成7.7.1発行',list:'161-15-2-7'},
    {name:'糸満',north:26.1706983988743,west:127.623061860135,south:26.0873754415409,east:127.748052527259,note:'平成4年修正・平成5.8.1発行',list:'161-16-1-4B'},
    {name:'喜屋武岬',north:26.087373759198,west:127.623063234577,south:26.0040507954565,east:127.748053903234,note:'平成4年修正・平成5.8.1発行',list:'161-16-2-4'}
]});
dataset.age.push({
  folderName:'03', start:2005, end:2008, scale:'1/25000', mapList: [
    {name:'沖縄市北部',north:26.41666667,west:127.75,south:26.33333333,east:127.866666666667,note:'平成17年更新・平成17.4.1発行',list:'161-10-4-9'},
    {name:'沖縄市南部',north:26.33333333,west:127.75,south:26.25,east:127.875,note:'平成17年更新・平成17.4.1発行',list:'161-11-3-10'},
    {name:'与那原',north:26.25,west:127.75,south:26.16666667,east:127.866666666667,note:'平成18年更新・平成18.3.1発行',list:'161-11-4-9'},
    {name:'知念',north:26.16666667,west:127.75,south:26.08333333,east:127.866666666667,note:'平成18年更新・平成18.3.1発行',list:'161-12-3-7'},
    {name:'高志保',north:26.41666667,west:127.633333333333,south:26.33333333,east:127.75,note:'平成20年更新・平成21.5.1発行',list:'161-14-2-8'},
    {name:'大謝名',north:26.33333333,west:127.633333333333,south:26.25,east:127.75,note:'平成17年更新・平成18.3.1発行',list:'161-15-1-11'},
    {name:'那覇',north:26.25,west:127.625,south:26.16666667,east:127.75,note:'平成20年更新・平成21.11.1発行',list:'161-15-2-14'},
    {name:'糸満',north:26.16666667,west:127.625,south:26.08333333,east:127.75,note:'平成18年更新・平成18.6.1発行',list:'161-16-1-7'},
    {name:'喜屋武岬',north:26.08333333,west:127.625,south:26,east:127.75,note:'平成17年更新・平成18.5.1発行',list:'161-16-2-7'}
]});
kjmapDataSet['omi'] = new Object();
dataset = kjmapDataSet['omi'];
dataset.age = new Array();
dataset.age.push({
   folderName:'2man', start: 1891, end: 1909, scale:'1/20000', mapList: [
         {name:'水口', north:35.0032230201929, west:136.099996192467, south:34.9365663068166, east:136.199989802973,note:'明治25年測図・明治27.6.29発行',list:'s1079'},
         {name:'葉枝見村', north:35.2698593283872, west:136.099986746409, south:35.203202656699, east:136.199980359543,note:'明治26年測図・明治27.10.29発行',list:'s1075'},
         {name:'角井村', north:35.1365435764672, west:136.19998273208, south:35.0698868972319, east:136.299976359861,note:'明治26年測図・明治28.11.30発行',list:'s1068'},
         {name:'髙宮', north:35.2698617304534, west:136.199977979176, south:35.2032050620694, east:136.299971608336,note:'明治26年測図・明治28.4.29発行',list:'s1066'},
         {name:'彦根', north:35.3365207877403, west:136.199975590954, south:35.2698641397618, east:136.299969220807,note:'明治26年測図・明治28.4.29発行',list:'s1065'},
         {name:'春照村', north:35.4031822657407, west:136.299964422086, south:35.3365256214732, east:136.399958068743,note:'明治26年測図・明治28.7.29発行',list:'s1054'},
         {name:'關原', north:35.4031846901735, west:136.399955658228, south:35.3365280492022, east:136.499949321013,note:'明治24年測図・明治27.1.27発行',list:'s978'},
         {name:'八幡', north:35.2031978676566, west:135.999997888502, south:35.1365411822567, east:136.099991484998,note:'明治26年測図・明治27.10.29発行',list:'s1088'},
         {name:'朝日野村', north:35.0698821094702, west:136.09999384261, south:35.0032254065342, east:136.19998745377,note:'明治26年測図・明治28.6.28発行',list:'s2544'},
         {name:'能登川', north:35.203200258559, west:136.099989119607, south:35.1365435764672, east:136.19998273208,note:'明治26年測図・明治28.2.28発行',list:'s2542'},
         {name:'日野', north:35.0698844997477, west:136.199985096814, south:35.0032278000702, east:136.299978723909,note:'明治26年測図・明治28.8.29発行',list:'s2539'},
         {name:'長濱', north:35.4031798485663, west:136.199973194851, south:35.3365232009834, east:136.299966825399,note:'明治26年測図・明治27.11.30発行',list:'s2536'},
         {name:'醒井村', north:35.3365232009834, west:136.299966825399, south:35.2698665563051, east:136.399960471329,note:'明治26年測図・明治28.4.29発行',list:'s2534'},
         {name:'大原', north:35.136534043009, west:135.800017796589, south:35.0698773505641, east:135.900011360624,note:'明治42年測図・大正1.11.30発行',list:'s1158'},
         {name:'堅田', north:35.1365364155204, west:135.90000901728, south:35.0698797264065, east:136.000002597222,note:'明治26年測図・明治28.4.29発行',list:'s1101'},
         {name:'石部', north:35.0698797264065, west:136.000002597222, south:35.0032230201929, east:136.099996192467,note:'明治25年測図・明治27.3.28発行',list:'s2547'},
         {name:'北里村', north:35.136538795272, west:136.000000246741, south:35.0698821094702, east:136.09999384261,note:'明治26年測図・明治28.2.28発行',list:'s2546'},
         {name:'速水村', north:35.4698389029414, west:136.19997079084, south:35.4031822657407, east:136.299964422086,note:'明治26年測図・明治28.5.29発行',list:'s2535'},
         {name:'七尾村', north:35.4698413240437, west:136.299962010842, south:35.4031846901735, east:136.399955658228,note:'明治26年測図・明治29.3.30発行',list:'s2424'},
         {name:'竹生嶋', north:35.4698364891167, west:136.099979579725, south:35.4031798485663, east:136.199973194851,note:'明治26年測図・明治27.12.28発行',list:'s1073'},
         {name:'愛知川', north:35.203202656699, west:136.199980359543, south:35.1365459778961, east:136.299973988012,note:'明治26年測図・明治28.8.29発行',list:'s2537'},
         {name:'八日市', north:35.1365411822567, west:136.099991484998, south:35.0698844997477, east:136.199985096814,note:'明治26年測図・明治28.7.29発行',list:'s2543'},
         {name:'葛川村', north:35.2698521657145, west:135.800013101032, south:35.2031954839991, east:135.900006666201,note:'明治26年測図・明治28.4.29発行',list:'s1156'},
         {name:'小松村', north:35.2698545460104, west:135.900004307364, south:35.2031978676566, east:135.999997888502,note:'明治26年測図・明治28.4.29発行',list:'s1099'},
         {name:'和邇村', north:35.2031954839991, west:135.900006666201, south:35.136538795272, east:136.000000246741,note:'明治26年測図・明治28.1.31発行',list:'s1100'},
         {name:'伊香立村', north:35.2031931075938, west:135.800015452678, south:35.1365364155204, east:135.90000901728,note:'明治26年測図・明治28.4.29発行',list:'s1157'},
         {name:'阿星山', north:35.0032206410536, west:136.000004939973, south:34.9365639244149, east:136.099998534594,note:'明治25年測図・明治27.3.31発行',list:'s2548'},
         {name:'草津', north:35.0698773505641, west:135.900011360624, south:35.0032206410536, east:136.000004939973,note:'明治25年測図・明治28.5.29発行',list:'s1102'},
]});
dataset.age.push({
   folderName:'00', start: 1920, end: 1922, scale:'1/25000', mapList: [
         {name:'關ヶ原', north:35.4198488518041, west:136.374957244936, south:35.3365280492022, east:136.499949321013,note:'大正9年測図・大正13.10.30発行',list:'95-12-2-1'},
         {name:'長濱', north:35.4198458234344, west:136.249968206193, south:35.3365250156717, east:136.374960257071,note:'大正9年測図・大正13.3.30発行',list:'95-12-4-1'},
         {name:'彦根東部', north:35.3365219934555, west:136.249971207066, south:35.2532011794356, east:136.374963256827,note:'大正9年測図・大正13.5.30発行',list:'96-9-3-1'},
         {name:'髙宮', north:35.2531981633796, west:136.249974195605, south:35.1698773330796, east:136.374966244255,note:'大正9年測図・大正13.4.30発行',list:'96-9-4-1'},
         {name:'彦根西部', north:35.336518982568, west:136.124982170944, south:35.2531981633796, east:136.249974195605,note:'大正9年測図・大正11.8.30発行',list:'96-13-1-1'},
         {name:'能登川', north:35.2531951586291, west:136.124985148253, south:35.1698743231902, east:136.249977171863,note:'大正9年測図・大正13.6.30発行',list:'96-13-2-1'},
         {name:'沖島', north:35.2531921651984, west:135.999996114717, south:35.1698713245833, east:136.124988113326,note:'大正9年測図・大正11.6.30発行',list:'96-13-4-1'},
         {name:'八日市', north:35.1698713245833, west:136.124988113326, south:35.0865504628713, east:136.249980135889,note:'大正9年測図・大正13.5.30発行',list:'96-14-1-1'},
         {name:'日野', north:35.0865474704146, west:136.124991066214, south:35.0032266024033, east:136.249983087733,note:'大正9年測図・大正13.3.30発行',list:'96-14-2-1'},
         {name:'八幡', north:35.1698683372731, west:135.999999068592, south:35.0865474704146, east:136.124991066214,note:'大正9年測図・大正13.6.30発行',list:'96-14-3-1'},
         {name:'野洲', north:35.0865444892314, west:136.000002010328, south:35.0032236161033, east:136.124994006965,note:'大正9年測図・大正13.4.30発行',list:'96-14-4-1'},
         {name:'水口', north:35.0032236161033, west:136.124994006965, south:34.9199027317701, east:136.249986027445,note:'大正9年測図・大正12.7.30発行',list:'96-15-1-1'},
         {name:'堅田', north:35.1698653612739, west:135.875010037609, south:35.0865444892314, east:136.000002010328,note:'大正11年測図・大正14.11.30発行',list:'100-2-1-1'},
         {name:'南濱', north:35.4198428064164, west:136.124979181348, south:35.3365219934555, east:136.249971207066,note:'大正9年測図・大正11.5.30発行',list:'95-16-2-1'},
         {name:'三雲', north:35.0032206410536, west:136.000004939973, south:34.9198997516333, east:136.124996935631,note:'大正9年測図・大正13.4.30発行',list:'96-15-3-1'},
         {name:'虎姫山', north:35.5031696333358, west:136.249965192937, south:35.4198488518041, east:136.374957244936,note:'大正9年測図・大正13.6.30発行',list:'95-12-3-1'},
         {name:'竹生島', north:35.503166610194, west:136.124976179415, south:35.4198458234344, east:136.249968206193,note:'大正9年測図・大正12.2.28発行',list:'95-16-1-1'},
         {name:'草津', north:35.0865415193359, west:135.875012968179, south:35.0032206410536, east:136.000004939973,note:'大正11年測図・大正14.7.30発行',list:'100-2-2-1'},
]});
dataset.age.push({
   folderName:'01', start: 1954, end: 1954, scale:'1/25000', mapList: [
         {name:'沖島', north:35.2531921651984, west:135.999996114717, south:35.1698713245833, east:136.124988113326,note:'昭和29年修正・昭和31.11.30発行',list:'96-13-4-3'},
         {name:'能登川', north:35.2531951586291, west:136.124985148253, south:35.1698743231902, east:136.249977171863,note:'昭和29年修正・昭和31.11.30発行',list:'96-13-2-5'},
         {name:'彦根西部', north:35.336518982568, west:136.124982170944, south:35.2531981633796, east:136.249974195605,note:'昭和29年修正・昭和31.11.30発行',list:'96-13-1-3'},
         {name:'高宮', north:35.2531981633796, west:136.249974195605, south:35.1698773330796, east:136.374966244255,note:'昭和29年修正・昭和31.11.30発行',list:'96-9-4-3'},
         {name:'彦根東部', north:35.3365219934555, west:136.249971207066, south:35.2532011794356, east:136.374963256827,note:'昭和29年修正・昭和31.11.30発行',list:'96-9-3-4'},
         {name:'長浜', north:35.4198458234344, west:136.249968206193, south:35.3365250156717, east:136.374960257071,note:'昭和29年修正・昭和31.11.30発行',list:'95-12-4-3'},
         {name:'関ヶ原', north:35.4198488518041, west:136.374957244936, south:35.3365280492022, east:136.499949321013,note:'昭和29年修正・昭和31.11.30発行',list:'95-12-2-4'},
         {name:'堅田', north:35.1698653612739, west:135.875010037609, south:35.0865444892314, east:136.000002010328,note:'昭和29年二修・昭和31.11.30発行',list:'100-2-1-4'},
         {name:'水口', north:35.0032236161033, west:136.124994006965, south:34.9199027317701, east:136.249986027445,note:'昭和29年三修・昭和31.11.30発行',list:'96-15-1-4'},
         {name:'野洲', north:35.0865444892314, west:136.000002010328, south:35.0032236161033, east:136.124994006965,note:'昭和29年修正・昭和31.11.30発行',list:'96-14-4-3'},
         {name:'近江八幡', north:35.1698683372731, west:135.999999068592, south:35.0865474704146, east:136.124991066214,note:'昭和29年修正・昭和31.11.30発行',list:'96-14-3-3'},
         {name:'日野', north:35.0865474704146, west:136.124991066214, south:35.0032266024033, east:136.249983087733,note:'昭和29年修正・昭和31.11.30発行',list:'96-14-2-3'},
         {name:'八日市', north:35.1698713245833, west:136.124988113326, south:35.0865504628713, east:136.249980135889,note:'昭和29年二修・昭和31.11.30発行',list:'96-14-1-5'},
         {name:'三雲', north:35.0032206410536, west:136.000004939973, south:34.9198997516333, east:136.124996935631,note:'昭和29年三修・昭和31.11.30発行',list:'96-15-3-4'},
         {name:'草津', north:35.0865415193359, west:135.875012968179, south:35.0032206410536, east:136.000004939973,note:'昭和29年修正・昭和31.11.30発行',list:'100-2-2-5'},
]});
dataset.age.push({
   folderName:'02', start: 1967, end: 1971, scale:'1/25000', mapList: [
         {name:'関ヶ原', north:35.4198487816868, west:136.372068598107, south:35.3365279789661, east:136.4970606736,note:'昭和46年改測・昭和48.3.30発行',list:'95-12-2-5'},
         {name:'高宮', north:35.2531980938085, west:136.247085548578, south:35.1698772633901, east:136.372077596648,note:'昭和43年改測・昭和45.11.30発行',list:'96-9-4-4'},
         {name:'彦根東部', north:35.3365219237424, west:136.247082560298, south:35.2532011096034, east:136.372074609478,note:'昭和43年改測・昭和45.9.30発行',list:'96-9-3-5'},
         {name:'堅田', north:35.1698652926288, west:135.872121391279, south:35.0865444204661, east:135.997113363422,note:'昭和42年改測・昭和46.2.28発行',list:'100-2-1-5'},
         {name:'水口', north:35.0032235472193, west:136.122105359485, south:34.9199026627689, east:136.247097379391,note:'昭和43年改測・昭和46.2.28発行',list:'96-15-1-5'},
         {name:'野洲', north:35.0865444204661, west:135.997113363422, south:35.0032235472193, east:136.122105359485,note:'昭和43年改測・昭和46.2.28発行',list:'96-14-4-4'},
         {name:'日野西部', north:35.0865474013886, west:136.12210241899, south:35.0032265332594, east:136.247094439934,note:'昭和43年改測・昭和46.2.28発行',list:'96-14-2-5'},
         {name:'八日市', north:35.1698712554154, west:136.12209946636, south:35.0865503935849, east:136.247091488346,note:'昭和43年改測・昭和46.2.28発行',list:'96-14-1-6'},
         {name:'沖島', north:35.2531920961506, west:135.997107468329, south:35.1698712554154, east:136.12209946636,note:'昭和43年改測・昭和46.2.28発行',list:'96-13-4-4'},
         {name:'近江八幡', north:35.1698682683665, west:135.997110421944, south:35.0865474013886, east:136.12210241899,note:'昭和43年改測・昭和46.1.30発行',list:'96-14-3-4'},
         {name:'彦根西部', north:35.3365189131168, west:136.122093524496, south:35.2531980938085, east:136.247085548578,note:'昭和43年改測・昭和46.2.28発行',list:'96-13-1-4'},
         {name:'長浜', north:35.4198457535793, west:136.247079559685, south:35.3365249456969, east:136.372071609982,note:'昭和46年改測・昭和47.8.30発行',list:'95-12-4-4'},
         {name:'能登川', north:35.2531950893195, west:136.122096501545, south:35.1698742537614, east:136.247088524577,note:'昭和43年改測・昭和46.2.28発行',list:'96-13-2-6'},
         {name:'三雲', north:35.0032205724298, west:135.99711629281, south:34.9198996828915, east:136.122108287895,note:'昭和43年改測・昭和46.2.28発行',list:'96-15-3-5'},
         {name:'比良山', north:35.2531891143161, west:135.872118448876, south:35.1698682683665, east:135.997110421944,note:'昭和46年測量・昭和47.11.30発行',list:'100-1-2-1'},
         {name:'虎御前山', north:35.5031695633389, west:136.247076546691, south:35.4198487816868, east:136.372068598107,note:'昭和46年改測・昭和48.3.30発行',list:'95-12-3-4'},
         {name:'南浜', north:35.4198427368238, west:136.122090535161, south:35.3365219237424, east:136.247082560298,note:'昭和46年改測・昭和47.8.30発行',list:'95-16-2-4'},
         {name:'竹生島', north:35.5031665404601, west:136.12208753349, south:35.4198457535793, east:136.247079559685,note:'昭和46年改測・昭和47.8.30発行',list:'95-16-1-4'},
         {name:'草津', north:35.0865414508317, west:135.87212432159, south:35.0032205724298, east:135.99711629281,note:'昭和42年改測・昭和46.1.30発行',list:'100-2-2-6'},
]});
dataset.age.push({
   folderName:'03', start: 1979, end: 1986, scale:'1/25000', mapList: [
         {name:'高宮', north:35.2531980938085, west:136.247085548578, south:35.1698772633901, east:136.372077596648,note:'昭和55年修正・昭和56.12.28発行',list:'96-9-4-6'},
         {name:'長浜', north:35.4198457535793, west:136.247079559685, south:35.3365249456969, east:136.372071609982,note:'昭和56年修正・昭和58.5.30発行',list:'95-12-4-6'},
         {name:'関ヶ原', north:35.4198487816868, west:136.372068598107, south:35.3365279789661, east:136.4970606736,note:'昭和56年修正・昭和57.9.30発行',list:'95-12-2-7'},
         {name:'水口', north:35.0032235472193, west:136.122105359485, south:34.9199026627689, east:136.247097379391,note:'昭和57年修正・昭和58.12.28発行',list:'96-15-1-8'},
         {name:'堅田', north:35.1698652926288, west:135.872121391279, south:35.0865444204661, east:135.997113363422,note:'昭和58年修正・昭和60.1.30発行',list:'100-2-1-9'},
         {name:'八日市', north:35.1698712554154, west:136.12209946636, south:35.0865503935849, east:136.247091488346,note:'昭和56年修正・昭和57.12.28発行',list:'96-14-1-9'},
         {name:'日野西部', north:35.0865474013886, west:136.12210241899, south:35.0032265332594, east:136.247094439934,note:'昭和56年修正・昭和57.12.28発行',list:'96-14-2-8'},
         {name:'近江八幡', north:35.1698682683665, west:135.997110421944, south:35.0865474013886, east:136.12210241899,note:'昭和56年修正・昭和58.2.28発行',list:'96-14-3-7B'},
         {name:'野洲', north:35.0865444204661, west:135.997113363422, south:35.0032235472193, east:136.122105359485,note:'昭和56年修正・昭和57.10.30発行',list:'96-14-4-7'},
         {name:'彦根東部', north:35.3365219237424, west:136.247082560298, south:35.2532011096034, east:136.372074609478,note:'昭和55年修正・昭和56.10.30発行',list:'96-9-3-7'},
         {name:'沖島', north:35.2531920961506, west:135.997107468329, south:35.1698712554154, east:136.12209946636,note:'昭和55年修正・昭和56.10.30発行',list:'96-13-4-7'},
         {name:'能登川', north:35.2531950893195, west:136.122096501545, south:35.1698742537614, east:136.247088524577,note:'昭和55年修正・昭和57.7.30発行',list:'96-13-2-9'},
         {name:'彦根西部', north:35.3365189131168, west:136.122093524496, south:35.2531980938085, east:136.247085548578,note:'昭和55年修正・昭和57.7.30発行',list:'96-13-1-7'},
         {name:'比良山', north:35.2531891143161, west:135.872118448876, south:35.1698682683665, east:135.997110421944,note:'昭和55年修正・昭和56.11.30発行',list:'100-1-2-3'},
         {name:'竹生島', north:35.5031665404601, west:136.12208753349, south:35.4198457535793, east:136.247079559685,note:'昭和61年修正・昭和63.1.30発行',list:'95-16-1-7B'},
         {name:'南浜', north:35.4198427368238, west:136.122090535161, south:35.3365219237424, east:136.247082560298,note:'昭和61年修正・昭和62.8.30発行',list:'95-16-2-7B'},
         {name:'虎御前山', north:35.5031695633389, west:136.247076546691, south:35.4198487816868, east:136.372068598107,note:'昭和56年修正・昭和58.6.30発行',list:'95-12-3-6'},
         {name:'三雲', north:35.0032205724298, west:135.99711629281, south:34.9198996828915, east:136.122108287895,note:'昭和57年修正・昭和58.12.28発行',list:'96-15-3-7B'},
         {name:'草津', north:35.0865414508317, west:135.87212432159, south:35.0032205724298, east:135.99711629281,note:'昭和54年二改・昭和56.7.30発行',list:'100-2-2-9'},
]});
dataset.age.push({
   folderName:'04', start: 1992, end: 1999, scale:'1/25000', mapList: [
         {name:'沖島', north:35.2531920961506, west:135.997107468329, south:35.1698712554154, east:136.12209946636,note:'平成11年部修・平成11.9.1発行',list:'96-13-4-10'},
         {name:'能登川', north:35.2531950893195, west:136.122096501545, south:35.1698742537614, east:136.247088524577,note:'平成10年部修・平成11.5.1発行',list:'96-13-2-13B'},
         {name:'彦根西部', north:35.3365189131168, west:136.122093524496, south:35.2531980938085, east:136.247085548578,note:'平成10年部修・平成10.10.1発行',list:'96-13-1-11'},
         {name:'高宮', north:35.2531980938085, west:136.247085548578, south:35.1698772633901, east:136.372077596648,note:'平成9年修正・平成10.8.1発行',list:'96-9-4-8B'},
         {name:'彦根東部', north:35.3365219237424, west:136.247082560298, south:35.2532011096034, east:136.372074609478,note:'平成9年修正・平成10.10.1発行',list:'96-9-3-9B'},
         {name:'長浜', north:35.4198457535793, west:136.247079559685, south:35.3365249456969, east:136.372071609982,note:'平成9年修正・平成10.11.1発行',list:'95-12-4-8B'},
         {name:'関ヶ原', north:35.4198487816868, west:136.372068598107, south:35.3365279789661, east:136.4970606736,note:'平成9年修正・平成10.12.1発行',list:'95-12-2-9B'},
         {name:'水口', north:35.0032235472193, west:136.122105359485, south:34.9199026627689, east:136.247097379391,note:'平成6年修正・平成7.12.1発行',list:'96-15-1-10C'},
         {name:'野洲', north:35.0865444204661, west:135.997113363422, south:35.0032235472193, east:136.122105359485,note:'平成10年部修・平成11.4.1発行',list:'96-14-4-11B'},
         {name:'近江八幡', north:35.1698682683665, west:135.997110421944, south:35.0865474013886, east:136.12210241899,note:'平成8年修正・平成9.9.1発行',list:'96-14-3-10B'},
         {name:'日野西部', north:35.0865474013886, west:136.12210241899, south:35.0032265332594, east:136.247094439934,note:'平成8年修正・平成9.12.1発行',list:'96-14-2-11B'},
         {name:'八日市', north:35.1698712554154, west:136.12209946636, south:35.0865503935849, east:136.247091488346,note:'平成10年部修・平成11.2.1発行',list:'96-14-1-13B'},
         {name:'堅田', north:35.1698652926288, west:135.872121391279, south:35.0865444204661, east:135.997113363422,note:'平成10年部修・平成10.8.1発行',list:'100-2-1-13'},
         {name:'南浜', north:35.4198427368238, west:136.122090535161, south:35.3365219237424, east:136.247082560298,note:'平成4年修正・平成5.8.1発行',list:'95-16-2-8'},
         {name:'虎御前山', north:35.5031695633389, west:136.247076546691, south:35.4198487816868, east:136.372068598107,note:'平成9年修正・平成10.8.1発行',list:'95-12-3-8B'},
         {name:'比良山', north:35.2531891143161, west:135.872118448876, south:35.1698682683665, east:135.997110421944,note:'平成8年修正・平成9.7.1発行',list:'100-1-2-6B'},
         {name:'三雲', north:35.0032205724298, west:135.99711629281, south:34.9198996828915, east:136.122108287895,note:'平成10年部修・平成11.6.1発行',list:'96-15-3-10B'},
         {name:'草津', north:35.0865414508317, west:135.87212432159, south:35.0032205724298, east:135.99711629281,note:'平成8年修正・平成9.9.1発行',list:'100-2-2-13'},
         {name:'竹生島', north:35.5031665404601, west:136.12208753349, south:35.4198457535793, east:136.247079559685,note:'平成10年部修・平成11.10.1発行',list:'95-16-1-9'},

]});

kjmapDataSet['muroran'] = new Object();
dataset = kjmapDataSet['muroran'];
dataset.age = new Array();
dataset.age.push({
   folderName:'00', start: 1896, end: 1896, scale:'1/50000', mapList: [
         {name:'ドカリショ岬', north:42.3321139347989, west:140.996838048981, south:42.1654753606267, east:141.24682485242,note:'明治29年製版',list:'50-3-6'},
         {name:'紋鼈', north:42.5007612299951, west:140.746851237184, south:42.3321139347989, east:140.996838048981,note:'明治29年製版',list:'50-2-8'},
         {name:'有珠', north:42.6674076897404, west:140.746841496493, south:42.5007692220331, east:140.996828213345,note:'明治29年製版',list:'50-1-8'},
         {name:'幌別', north:42.5007692220331, west:140.996828213345, south:42.3321237749305, east:141.303462978563,note:'明治29年製版',list:'47-14-9'},
         {name:'室蘭', north:42.33210596823, west:140.746861011209, south:42.1654673694669, east:140.996847684699,note:'明治29年製版',list:'50-3-7'},
   ]});
dataset.age.push({
   folderName:'01', start: 1917, end: 1917, scale:'1/50000', mapList: [
         {name:'西紋鼈', north:42.502470978941, west:140.74923591769, south:42.335832442044, east:140.999222614304,note:'大正6年測図・大正8.12.5発行',list:'50-2-1'},
         {name:'虻田', north:42.6691174485667, west:140.74922617556, south:42.5024789717158, east:140.999212893889,note:'大正6年測図・大正9.1.30発行',list:'50-1-1'},
         {name:'登別', north:42.5024789717158, west:140.999212893889, south:42.335841759571, east:141.289583829331,note:'大正6年測図・大正9.3.31発行',list:'47-14-1'},
         {name:'室蘭', north:42.3358244744352, west:140.749245577221, south:42.1691870152495, east:141.034607816976,note:'大正6年測図・大正7.10.21発行',list:'50-3-1'},
]});
dataset.age.push({
   folderName:'02', start: 1955, end: 1955, scale:'1/25000', mapList: [
         {name:'虻田', north:42.5857941208917, west:140.746342423817, south:42.5024748766928, east:140.87133576313,note:'昭和30年測量・昭和33.6.30発行',list:'50-1-4-1'},
         {name:'稀府', north:42.5024748766928, west:140.87133576313, south:42.4191556237562, east:140.996329129737,note:'昭和30年測量・昭和33.6.30発行',list:'50-2-1-1'},
         {name:'本輪西', north:42.4191516276778, west:140.871340618081, south:42.3358323496877, east:140.996333979256,note:'昭和30年測量・昭和33.6.30発行',list:'50-2-2-1'},
         {name:'伊達', north:42.5024708868733, west:140.746347284151, south:42.4191516276778, east:140.871340618081,note:'昭和30年測量・昭和33.6.30発行',list:'50-2-3-1'},
         {name:'室蘭', north:42.3358302333045, west:140.930082358572, south:42.252511073249, east:141.058833085706,note:'昭和30年測量・昭和33.6.30発行',list:'50-3-1-1'},
         {name:'登別温泉', north:42.5024828939794, west:141.121312773448, south:42.4160399422121, east:141.282032118543,note:'昭和30年測量・昭和33.6.30発行',list:'47-14-1-1'},
         {name:'鷲別岳', north:42.5024788790679, west:140.996324259544, south:42.4191596323514, east:141.121317658861,note:'昭和30年測量・昭和33.6.30発行',list:'47-14-3-1'},
         {name:'幌別', north:42.4191556237562, west:140.996329129737, south:42.335836351958, east:141.121322523535,note:'昭和30年測量・昭和33.6.30発行',list:'47-14-4-1'},
         {name:'壮瞥', north:42.5857981169794, west:140.871330887465, south:42.5024788790679, east:140.996324259544,note:'昭和30年測量・昭和33.6.30発行',list:'50-1-2-1'},
]});
dataset.age.push({
   folderName:'03', start: 1986, end: 1987, scale:'1/25000', mapList: [
         {name:'虻田', north:42.5857941208917, west:140.746342423817, south:42.5024748766928, east:140.87133576313,note:'昭和62年修正・昭和63.6.30発行',list:'50-1-4-6B'},
         {name:'壮瞥', north:42.5857981169794, west:140.871330887465, south:42.5024788790679, east:140.996324259544,note:'昭和62年修正・昭和63.6.30発行',list:'50-1-2-5B'},
         {name:'鷲別岳', north:42.5024788790679, west:140.996324259544, south:42.4191596323514, east:141.121317658861,note:'昭和61年修正・昭和62.11.30発行',list:'47-14-3-4B'},
         {name:'伊達', north:42.5024708868733, west:140.746347284151, south:42.4191516276778, east:140.871340618081,note:'昭和62年修正・昭和63.7.30発行',list:'50-2-3-6'},
         {name:'本輪西', north:42.4191516276778, west:140.871340618081, south:42.3358323496877, east:140.996333979256,note:'昭和62年修正・昭和63.7.30発行',list:'50-2-2-6'},
         {name:'稀府', north:42.5024748766928, west:140.87133576313, south:42.4191556237562, east:140.996329129737,note:'昭和62年修正・昭和63.7.30発行',list:'50-2-1-6'},
         {name:'室蘭', north:42.3358302165651, west:140.929557906716, south:42.252511073249, east:141.058833085706,note:'昭和61年修正・昭和63.2.28発行',list:'50-3-1-6B'},
         {name:'登別温泉', north:42.5024828939794, west:141.121312773448, south:42.4166549152301, east:141.284426663277,note:'昭和61年修正・昭和63.2.28発行',list:'47-14-1-6B'},
         {name:'室蘭東北部', north:42.4191556237562, west:140.996329129737, south:42.335836351958, east:141.121322523535,note:'昭和61年修正・昭和63.2.28発行',list:'47-14-4-6B'},
]});
dataset.age.push({
   folderName:'04', start: 1998, end: 2000, scale:'1/25000', mapList: [
         {name:'稀府', north:42.5024748766928, west:140.87133576313, south:42.4191556237562, east:140.996329129737,note:'平成12年修正・平成13.7.1発行',list:'50-2-1-9B'},
         {name:'本輪西', north:42.4191516276778, west:140.871340618081, south:42.3358323496877, east:140.996333979256,note:'平成10年修正・平成11.8.1発行',list:'50-2-2-8B'},
         {name:'伊達', north:42.5024708868733, west:140.746347284151, south:42.4191516276778, east:140.871340618081,note:'平成12年修正・平成13.8.1発行',list:'50-2-3-9'},
         {name:'鷲別岳', north:42.5024788790679, west:140.996324259544, south:42.4191596323514, east:141.121317658861,note:'平成12年修正・平成13.10.1発行',list:'47-14-3-7'},
         {name:'室蘭東北部', north:42.4191556237562, west:140.996329129737, south:42.335836351958, east:141.121322523535,note:'平成10年修正・平成11.7.1発行',list:'47-14-4-8B'},
         {name:'壮瞥', north:42.5857981169794, west:140.871330887465, south:42.5024788790679, east:140.996324259544,note:'平成12年修正・平成13.7.1発行',list:'50-1-2-7'},
         {name:'登別温泉', north:42.5024828939794, west:141.121312773448, south:42.4147214853781, east:141.284638357473,note:'平成12年修正・平成13.10.1発行',list:'47-14-1-8'},
         {name:'室蘭', north:42.3358302294555, west:140.929961769642, south:42.252511073249, east:141.058833085706,note:'平成10年修正・平成11.4.1発行',list:'50-3-1-8B'},
         {name:'虻田', north:42.585792660422, west:140.700563753516, south:42.5024748766928, east:140.87133576313,note:'平成12年修正・平成13.10.1発行',list:'50-1-4-11B'},
]});

kjmapDataSet['iwatekennan'] = new Object();
dataset = kjmapDataSet['iwatekennan'];
dataset.age = new Array();
dataset.age.push({
   folderName:'00', start: 1913, end: 1913, scale:'1/50000', mapList: [
      {name:'一関', north:39.0028943275682, west:140.999400756748, south:38.8362544965974, east:141.249387175631,note:'大正2年測図・大正5.8.30発行',list:'57-15-2'},
      {name:'花巻', north:39.5028359914798, west:140.999375899962, south:39.3361963549737, east:141.249362370849,note:'大正2年測図・大正5.5.30発行',list:'56-16-2'},
      {name:'黒澤尻', north:39.3361888048891, west:140.999384254621, south:39.1695491137784, east:141.249370707971,note:'大正2年測図・大正5.7.30発行',list:'57-13-2'},
      {name:'水澤', north:39.1695415903021, west:140.999392540005, south:39.0029018243706, east:141.249378976022,note:'大正2年測図・大正4.5.30発行',list:'57-14-1'},
]});
dataset.age.push({
   folderName:'01', start: 1951, end: 1951, scale:'1/50000', mapList: [
      {name:'花巻', north:39.5028359914798, west:140.999375899962, south:39.3361963549737, east:141.249362370849,note:'昭和26年応修・昭和27.6.30発行',list:'56-16-7'},
      {name:'黑澤尻', north:39.3361888048891, west:140.999384254621, south:39.1695491137784, east:141.249370707971,note:'昭和26年応修・昭和27.5.30発行',list:'57-13-7'},
      {name:'水澤', north:39.1695415903021, west:140.999392540005, south:39.0029018243706, east:141.249378976022,note:'昭和26年応修・昭和27.6.30発行',list:'57-14-4'},
      {name:'一關', north:39.0028943275682, west:140.999400756748, south:38.8362544965974, east:141.249387175631,note:'昭和26年応修・昭和27.8.30発行',list:'57-15-8'},
]});
dataset.age.push({
   folderName:'02', start: 1968, end: 1968, scale:'1/25000', mapList: [
      {name:'陸中江刺', north:39.2528688777952, west:141.121488821239, south:39.1695490265728, east:141.246482059872,note:'昭和43年測量・昭和45.6.30発行',list:'57-13-2-1'},
      {name:'口内', north:39.3361924868137, west:141.121484657256, south:39.2528726517833, east:141.246477900282,note:'昭和43年測量・昭和45.6.30発行',list:'57-13-1-1'},
      {name:'花巻', north:39.4195123207998, west:140.996491439563, south:39.3361924868137, east:141.121484657256,note:'昭和43年測量・昭和45.7.30発行',list:'56-16-4-1'},
      {name:'花巻温泉', north:39.5028359042031, west:140.996487253837, south:39.4195160963243, east:141.1214804759,note:'昭和43年測量・昭和45.7.30発行',list:'56-16-3-1'},
      {name:'土沢', north:39.4195160963243, west:141.1214804759, south:39.3361962674597, east:141.246473723347,note:'昭和43年測量・昭和45.7.30発行',list:'56-16-2-1'},
      {name:'石鳥谷', north:39.5028396863483, west:141.121476277094, south:39.4195198836198, east:141.246469528985,note:'昭和43年測量・昭和45.7.30発行',list:'56-16-1-1'},
      {name:'北上', north:39.3361887179182, west:140.996495607892, south:39.2528688777952, east:141.121488821239,note:'昭和43年測量・昭和45.6.30発行',list:'57-13-3-1'},
      {name:'供養塚', north:39.1695415036377, west:140.996503892677, south:39.0862216211624, east:141.12149709741,note:'昭和43年測量・昭和45.6.30発行',list:'57-14-3-1'},
      {name:'前沢', north:39.0862216211624, west:141.12149709741, south:39.0029017374742, east:141.246490327331,note:'昭和43年測量・昭和45.6.30発行',list:'57-14-2-1'},
      {name:'水沢', north:39.1695452592507, west:141.121492967931, south:39.0862253818102, east:141.246486202195,note:'昭和43年測量・昭和45.6.30発行',list:'57-14-1-1'},
      {name:'金ヶ崎', north:39.2528651155368, west:140.996499758904, south:39.1695452592507, east:141.121492967931,note:'昭和43年測量・昭和45.6.30発行',list:'57-13-4-1'},
      {name:'萩荘', north:38.9195706006443, west:140.996516191356, south:38.8362506694349, east:141.121509383352,note:'昭和43年測量・昭和45.6.30発行',list:'57-15-4-1'},
      {name:'平泉', north:39.0028942412111, west:140.996512108826, south:38.9195743362723, east:141.121505305042,note:'昭和43年測量・昭和45.6.30発行',list:'57-15-3-1'},
      {name:'有壁', north:38.9195743362723, west:141.121505305042, south:38.8362544100109, east:141.246498526353,note:'昭和43年測量・昭和45.6.30発行',list:'57-15-2-1'},
      {name:'一関', north:39.0028979835089, west:141.121501209754, south:38.919578083547, east:141.246494435357,note:'昭和43年測量・昭和45.6.30発行',list:'57-15-1-1'},
      {name:'古戸', north:39.0862178722029, west:140.996508009292, south:39.0028979835089, east:141.121501209754,note:'昭和43年測量・昭和45.6.30発行',list:'57-14-4-1'},
]});
dataset.age.push({
   folderName:'03', start: 1985, end: 1986, scale:'1/25000', mapList: [
      {name:'石鳥谷', north:39.5028396863483, west:141.121476277094, south:39.4195198836198, east:141.246469528985,note:'昭和60年修正・昭和61.1.30発行',list:'56-16-1-4'},
      {name:'土沢', north:39.4195160963243, west:141.1214804759, south:39.3361962674597, east:141.246473723347,note:'昭和60年修正・昭和61.3.30発行',list:'56-16-2-4'},
      {name:'花巻温泉', north:39.5028359042031, west:140.996487253837, south:39.4195160963243, east:141.1214804759,note:'昭和60年修正・昭和61.3.30発行',list:'56-16-3-4'},
      {name:'花巻', north:39.4195123207998, west:140.996491439563, south:39.3361924868137, east:141.121484657256,note:'昭和60年修正・昭和62.3.30発行',list:'56-16-4-4'},
      {name:'口内', north:39.3361924868137, west:141.121484657256, south:39.2528726517833, east:141.246477900282,note:'昭和61年修正・昭和62.9.30発行',list:'57-13-1-5B'},
      {name:'陸中江刺', north:39.2528688777952, west:141.121488821239, south:39.1695490265728, east:141.246482059872,note:'昭和61年修正・昭和62.7.30発行',list:'57-13-2-5B'},
      {name:'北上', north:39.3361887179182, west:140.996495607892, south:39.2528688777952, east:141.121488821239,note:'昭和61年修正・昭和62.10.30発行',list:'57-13-3-5B'},
      {name:'金ヶ崎', north:39.2528651155368, west:140.996499758904, south:39.1695452592507, east:141.121492967931,note:'昭和61年修正・昭和62.4.30発行',list:'57-13-4-5B'},
      {name:'前沢', north:39.0862216211624, west:141.12149709741, south:39.0029017374742, east:141.246490327331,note:'昭和61年修正・昭和62.9.30発行',list:'57-14-2-4B'},
      {name:'供養塚', north:39.1695415036377, west:140.996503892677, south:39.0862216211624, east:141.12149709741,note:'昭和61年修正・昭和62.9.30発行',list:'57-14-3-4C'},
      {name:'古戸', north:39.0862178722029, west:140.996508009292, south:39.0028979835089, east:141.121501209754,note:'昭和61年修正・昭和62.6.30発行',list:'57-14-4-4B'},
      {name:'一関', north:39.0028979835089, west:141.121501209754, south:38.919578083547, east:141.246494435357,note:'昭和61年修正・昭和62.4.30発行',list:'57-15-1-4B'},
      {name:'有壁', north:38.9195743362723, west:141.121505305042, south:38.8362544100109, east:141.246498526353,note:'昭和61年修正・昭和62.10.30発行',list:'57-15-2-4B'},
      {name:'平泉', north:39.0028942412111, west:140.996512108826, south:38.9195743362723, east:141.121505305042,note:'昭和61年修正・昭和62.8.30発行',list:'57-15-3-4B'},
      {name:'萩荘', north:38.9195706006443, west:140.996516191356, south:38.8362506694349, east:141.121509383352,note:'昭和61年修正・昭和62.4.30発行',list:'57-15-4-3B'},
      {name:'水沢', north:39.1695452592507, west:141.121492967931, south:39.0862253818102, east:141.246486202195,note:'昭和61年修正・昭和62.6.30発行',list:'57-14-1-4B'},
]});
dataset.age.push({
   folderName:'04', start: 1996, end: 2001, scale:'1/25000', mapList: [
      {name:'石鳥谷', north:39.5028396863483, west:141.121476277094, south:39.4195198836198, east:141.246469528985,note:'平成8年修正・平成9.9.1発行',list:'56-16-1-6B'},
      {name:'土沢', north:39.4195160963243, west:141.1214804759, south:39.3361962674597, east:141.246473723347,note:'平成8年修正・平成9.7.1発行',list:'56-16-2-6B'},
      {name:'花巻温泉', north:39.5028359042031, west:140.996487253837, south:39.4195160963243, east:141.1214804759,note:'平成8年修正・平成9.7.1発行',list:'56-16-3-6B'},
      {name:'花巻', north:39.4195123207998, west:140.996491439563, south:39.3361924868137, east:141.121484657256,note:'平成8年修正・平成9.7.1発行',list:'56-16-4-6B'},
      {name:'口内', north:39.3361924868137, west:141.121484657256, south:39.2528726517833, east:141.246477900282,note:'平成8年修正・平成9.9.1発行',list:'57-13-1-7B'},
      {name:'陸中江刺', north:39.2528688777952, west:141.121488821239, south:39.1695490265728, east:141.246482059872,note:'平成8年修正・平成9.12.1発行',list:'57-13-2-7B'},
      {name:'北上', north:39.3361887179182, west:140.996495607892, south:39.2528688777952, east:141.121488821239,note:'平成11年部修・平成11.9.1発行',list:'57-13-3-9B'},
      {name:'水沢', north:39.1695452592507, west:141.121492967931, south:39.0862253818102, east:141.246486202195,note:'平成13年修正・平成14.12.1発行',list:'57-14-1-7'},
      {name:'古戸', north:39.0862178722029, west:140.996508009292, south:39.0028979835089, east:141.121501209754,note:'平成13年修正・平成14.12.1発行',list:'57-14-4-6'},
      {name:'一関', north:39.0028979835089, west:141.121501209754, south:38.919578083547, east:141.246494435357,note:'平成13年修正・平成15.4.1発行',list:'57-15-1-6'},
      {name:'有壁', north:38.9195743362723, west:141.121505305042, south:38.8362544100109, east:141.246498526353,note:'平成13年修正・平成14.6.1発行',list:'57-15-2-7'},
      {name:'平泉', north:39.0028942412111, west:140.996512108826, south:38.9195743362723, east:141.121505305042,note:'平成13年修正・平成15.2.1発行',list:'57-15-3-6'},
      {name:'金ヶ崎', north:39.2528651155368, west:140.996499758904, south:39.1695452592507, east:141.121492967931,note:'平成8年修正・平成9.12.1発行',list:'57-13-4-7'},
]});
   
kjmapDataSet['omuta'] = new Object();
dataset = kjmapDataSet['omuta'];
dataset.age = new Array();
dataset.age.push({
   folderName:'00', start: 1900, end: 1900, scale:'1/50000', mapList: [
      {name:'嶋原', north:32.8366791943008, west:130.25058099999, south:32.6700360661326, east:130.500562902701,note:'明治33年測図・明治36.3.30発行',list:'126-12-1'},
      {name:'長洲', north:33.0033269022209, west:130.250576670931, south:32.8366838261284, east:130.500558567566,note:'明治33年測図・明治36.3.30発行',list:'126-11-1'},
      {name:'柳河', north:33.1699745689694, west:130.250572305939, south:33.003331554778, east:130.500554196428,note:'明治33年測図・明治36.3.30発行',list:'126-10-1'},
]});
dataset.age.push({
   folderName:'01', start: 1941, end: 1942, scale:'1/50000', mapList: [
      {name:'大牟田', north:33.1699745689694, west:130.250572305939, south:33.003331554778, east:130.500554196428,note:'昭和16年三修・昭和25.12.28発行',list:'126-10-7'},
      {name:'長洲', north:33.0033269022209, west:130.250576670931, south:32.8366838261284, east:130.500558567566,note:'昭和17年三修・昭和22.9.30発行',list:'126-11-6'},
      {name:'島原', north:32.8366791943008, west:130.25058099999, south:32.6700360661326, east:130.500562902701,note:'昭和17年二修・昭和22.9.30発行',list:'126-12-6'},
]});
dataset.age.push({
   folderName:'02', start: 1970, end: 1970, scale:'1/25000', mapList: [
      {name:'下沖洲', north:32.9200053202603, west:130.372678967168, south:32.836683772349, east:130.497669926534,note:'昭和45年測量・昭和48.5.30発行',list:'126-11-2-1'},
      {name:'荒尾', north:33.0033291691138, west:130.372676787861, south:32.9200076467127, east:130.497667745724,note:'昭和45年測量・昭和48.5.30発行',list:'126-11-1-1'},
      {name:'多比良', north:32.9200030050342, west:130.247690199655, south:32.8366814510935, east:130.372681137484,note:'昭和45年測量・昭和47.6.30発行',list:'126-11-4-1'},
      {name:'雲仙', north:32.7533552767171, west:130.247694510368, south:32.6700338302741, east:130.379653027192,note:'昭和45年測量・昭和47.6.30発行',list:'126-12-4-1'},
      {name:'大牟田', north:33.0866530076693, west:130.372674599528, south:33.003331500758, east:130.497665555881,note:'昭和45年測量・昭和48.5.30発行',list:'126-10-2-1'},
      {name:'島原', north:32.8366791410392, west:130.247692359468, south:32.7533579559036, east:130.392924284258,note:'昭和45年測量・昭和47.6.30発行',list:'126-12-3-1'},
]});
dataset.age.push({
   folderName:'03', start: 1983, end: 1987, scale:'1/25000', mapList: [
      {name:'雲仙', north:32.7533552767171, west:130.247694510368, south:32.6700338656662, east:130.381571355373,note:'昭和58年修正・昭和60.2.28発行',list:'126-12-4-3'},
      {name:'大牟田', north:33.0866530076693, west:130.372674599528, south:33.003331500758, east:130.497665555881,note:'昭和62年修正・昭和63.10.30発行',list:'126-10-2-3'},
      {name:'荒尾', north:33.0033291691138, west:130.372676787861, south:32.9200076467127, east:130.497667745724,note:'昭和58年修正・昭和60.1.30発行',list:'126-11-1-3'},
      {name:'下沖洲', north:32.9200053202603, west:130.372678967168, south:32.836683772349, east:130.497669926534,note:'昭和58年修正・昭和59.10.30発行',list:'126-11-2-3'},
      {name:'多比良', north:32.9200030050342, west:130.247690199655, south:32.8366814510935, east:130.372681137484,note:'昭和58年修正・昭和60.3.30発行',list:'126-11-4-3'},
      {name:'島原', north:32.8366791410392, west:130.247692359468, south:32.753357926559, east:130.391338026454,note:'昭和58年修正・昭和60.1.30発行',list:'126-12-3-3'},
]});
dataset.age.push({
   folderName:'04', start: 1993, end: 1994, scale:'1/25000', mapList: [
      {name:'島原', north:32.8366791410392, west:130.247692359468, south:32.7533579310852, east:130.39158270452,note:'平成6年修正・平成6.6.1発行',list:'126-12-3-4'},
      {name:'大牟田', north:33.0866530076693, west:130.372674599528, south:33.003331500758, east:130.497665555881,note:'平成5年修正・平成6.8.1発行',list:'126-10-2-5'},
      {name:'雲仙', north:32.7533552767171, west:130.247694510368, south:32.6700338678358, east:130.38168894484,note:'平成6年修正・平成6.6.1発行',list:'126-12-4-4'},
]});
dataset.age.push({
   folderName:'05', start: 1999, end: 2000, scale:'1/25000', mapList: [
      {name:'大牟田', north:33.0866530076693, west:130.372674599528, south:33.003331500758, east:130.497665555881,note:'平成12年修正・平成13.4.1発行',list:'126-10-2-6B'},
      {name:'荒尾', north:33.0033291691138, west:130.372676787861, south:32.9200076467127, east:130.497667745724,note:'平成11年部修・平成12.4.1発行',list:'126-11-1-5B'},
      {name:'下沖洲', north:32.9200053202603, west:130.372678967168, south:32.836683772349, east:130.497669926534,note:'平成11年部修・平成12.9.1発行',list:'126-11-2-5B'},
      {name:'多比良', north:32.9200030050342, west:130.247690199655, south:32.8366814510935, east:130.372681137484,note:'平成11年部修・平成12.9.1発行',list:'126-11-4-6B'},
      {name:'島原', north:32.8366791410392, west:130.247692359468, south:32.7533579201054, east:130.390989157728,note:'平成12年部修・平成12.12.1発行',list:'126-12-3-6B'},
      {name:'雲仙', north:32.7533552767171, west:130.247694510368, south:32.670033865253, east:130.381548957379,note:'平成12年修正・平成13.5.1発行',list:'126-12-4-6B'},
]});

kjmapDataSet['yatsushiro'] = new Object();
dataset = kjmapDataSet['yatsushiro'];
dataset.age = new Array();
dataset.age.push({
   folderName:'00', start: 1901, end: 1901, scale:'1/50000', mapList: [
      {name:'八代', north:32.6700360661326, west:130.500562902701, south:32.5033928892658, east:130.750544896995,note:'明治34年測図・明治35.9.30発行',list:'127-5-1'},
      {name:'日奈久', north:32.5033882546611, west:130.500567202109, south:32.336745015134, east:130.750549201912,note:'明治34年測図・明治36.3.30発行',list:'127-6-1'},
]});
dataset.age.push({
   folderName:'01', start: 1932, end: 1942, scale:'1/50000', mapList: [
      {name:'日奈久', north:32.5033882546611, west:130.500567202109, south:32.336745015134, east:130.750549201912,note:'昭和7年部修・昭和9.4.30発行',list:'127-6-4'},
      {name:'八代', north:32.6700360661326, west:130.500562902701, south:32.5033928892658, east:130.750544896995,note:'昭和17年二修・昭和22.9.30発行',list:'127-5-6'},
]});
dataset.age.push({
   folderName:'02', start: 1965, end: 1965, scale:'1/25000', mapList: [
      {name:'松合', north:32.6700360125944, west:130.497674261187, south:32.5867144239221, east:130.622665246427,note:'昭和40年測量・昭和42.6.30発行',list:'127-5-3-1'},
      {name:'鏡', north:32.5867144239221, west:130.622665246427, south:32.5033928354572, east:130.74765625449,note:'昭和40年測量・昭和42.6.30発行',list:'127-5-2-1'},
      {name:'松橋', north:32.6700383345809, west:130.62266308216, south:32.5867167517752, east:130.747654088862,note:'昭和40年測量・昭和42.6.30発行',list:'127-5-1-1'},
      {name:'八代', north:32.5867121071728, west:130.497676415101, south:32.5033905128715, east:130.622667401754,note:'昭和40年測量・昭和42.6.30発行',list:'127-5-4-1'},
      {name:'田浦', north:32.4200642851545, west:130.497680696271, south:32.3367426495343, east:130.622671685725,note:'昭和40年測量・昭和42.6.30発行',list:'127-6-4-1'},
      {name:'坂本', north:32.5033905128715, west:130.622667401754, south:32.4200689087271, east:130.747658411169,note:'昭和40年測量・昭和42.6.30発行',list:'127-6-1-1'},
      {name:'中津道', north:32.420066591414, west:130.622669548175, south:32.3367449615698, east:130.747660558934,note:'昭和40年測量・昭和42.6.30発行',list:'127-6-2-1'},
      {name:'日奈久', north:32.5033882013646, west:130.497678560117, south:32.420066591414, east:130.622669548175,note:'昭和40年測量・昭和42.6.30発行',list:'127-6-3-1'},
]});
dataset.age.push({
   folderName:'03', start: 1983, end: 1986, scale:'1/25000', mapList: [
      {name:'日奈久', north:32.5033882013646, west:130.497678560117, south:32.420066591414, east:130.622669548175,note:'昭和61年修正・昭和63.2.28発行',list:'127-6-3-4B'},
      {name:'田浦', north:32.4200642851545, west:130.497680696271, south:32.3367426495343, east:130.622671685725,note:'昭和61年修正・昭和62.8.30発行',list:'127-6-4-4B'},
      {name:'松橋', north:32.6700383345809, west:130.62266308216, south:32.5867167517752, east:130.747654088862,note:'昭和58年修正・昭和60.8.30発行',list:'127-5-1-5'},
      {name:'鏡', north:32.5867144239221, west:130.622665246427, south:32.5033928354572, east:130.74765625449,note:'昭和58年修正・昭和59.7.30発行',list:'127-5-2-4'},
      {name:'松合', north:32.6700360125944, west:130.497674261187, south:32.5867144239221, east:130.622665246427,note:'昭和58年修正・昭和60.3.30発行',list:'127-5-3-4'},
      {name:'八代', north:32.5867121071728, west:130.497676415101, south:32.5033905128715, east:130.622667401754,note:'昭和58年修正・昭和60.3.30発行',list:'127-5-4-5'},
      {name:'坂本', north:32.5033905128715, west:130.622667401754, south:32.4200689087271, east:130.747658411169,note:'昭和61年修正・昭和62.10.30発行',list:'127-6-1-3B'},
      {name:'中津道', north:32.420066591414, west:130.622669548175, south:32.3367449615698, east:130.747660558934,note:'昭和61年修正・昭和62.9.30発行',list:'127-6-2-3'},
]});
dataset.age.push({
   folderName:'04', start: 1997, end: 2000, scale:'1/25000', mapList: [
      {name:'中津道', north:32.420066591414, west:130.622669548175, south:32.3367449615698, east:130.747660558934,note:'平成9年修正・平成10.9.1発行',list:'127-6-2-5B'},
      {name:'日奈久', north:32.5033882013646, west:130.497678560117, south:32.420066591414, east:130.622669548175,note:'平成9年修正・平成10.10.1発行',list:'127-6-3-5'},
      {name:'田浦', north:32.4200642851545, west:130.497680696271, south:32.3367426495343, east:130.622671685725,note:'平成9年修正・平成10.12.1発行',list:'127-6-4-5'},
      {name:'松橋', north:32.6700383345809, west:130.62266308216, south:32.5867167517752, east:130.747654088862,note:'平成12年修正・平成13.4.1発行',list:'127-5-1-8B'},
      {name:'鏡', north:32.5867144239221, west:130.622665246427, south:32.5033928354572, east:130.74765625449,note:'平成12年修正・平成13.4.1発行',list:'127-5-2-7'},
      {name:'松合', north:32.6700360125944, west:130.497674261187, south:32.5867144239221, east:130.622665246427,note:'平成12年修正・平成13.5.1発行',list:'127-5-3-7'},
      {name:'八代', north:32.5867121071728, west:130.497676415101, south:32.5033905128715, east:130.622667401754,note:'平成12年修正・平成13.5.1発行',list:'127-5-4-8B'},
      {name:'坂本', north:32.5033905128715, west:130.622667401754, south:32.4200689087271, east:130.747658411169,note:'平成9年修正・平成10.9.1発行',list:'127-6-1-5'},
]});

kjmapDataSet['nobeoka'] = new Object();
dataset = kjmapDataSet['nobeoka'];
dataset.age = new Array();
dataset.age.push({
   folderName:'00', start: 1903, end: 1903, scale:'1/50000', mapList: [
      {name:'細嶋', north:32.5034070583417, west:131.500478251033, south:32.3367639091396, east:131.750460594868,note:'明治36年測図・明治40.1.30発行',list:'122-6-1'},
      {name:'延岡', north:32.6700549550627, west:131.500473786899, south:32.503411869488, east:131.750456126915,note:'明治36年測図・明治37.9.30発行',list:'122-5-1'},
]});
dataset.age.push({
   folderName:'01', start: 1932, end: 1932, scale:'1/50000', mapList: [
      {name:'富髙', north:32.5034070583417, west:131.500478251033, south:32.3367639091396, east:131.750460594868,note:'昭和7年要修・昭和10.1.30発行',list:'122-6-4'},
      {name:'延岡', north:32.6700549550627, west:131.500473786899, south:32.503411869488, east:131.750456126915,note:'昭和7年要修・昭和10.4.30発行',list:'122-5-3'},
]});
dataset.age.push({
   folderName:'02', start: 1964, end: 1964, scale:'1/25000', mapList: [
      {name:'上井野', north:32.503407003003, west:131.497589606959, south:32.4200854384876, east:131.622580767066,note:'昭和39年測量・昭和41.6.30発行',list:'122-6-3-1'},
      {name:'平岩', north:32.4200854384876, west:131.622580767066, south:32.3367638535467, east:131.747571949793,note:'昭和39年測量・昭和41.6.30発行',list:'122-6-2-1'},
      {name:'日向', north:32.5034094028277, west:131.622578538873, south:32.4200878438284, east:131.747569720677,note:'昭和39年測量・昭和41.6.30発行',list:'122-6-1-1'},
      {name:'川水流', north:32.586730951452, west:131.497587379748, south:32.5034094028277, east:131.622578538873,note:'昭和39年測量・昭和41.6.30発行',list:'122-5-4-1'},
      {name:'行縢山', north:32.6700548994731, west:131.497585143299, south:32.5867333567194, east:131.622576301435,note:'昭和39年測量・昭和41.6.30発行',list:'122-5-3-1'},
      {name:'延岡', north:32.5867333567194, west:131.622576301435, south:32.5034118136414, east:131.747567482309,note:'昭和39年測量・昭和41.6.30発行',list:'122-5-2-1'},
      {name:'延岡北部', north:32.6700573101778, west:131.622574054716, south:32.5867357730006, east:131.747565234654,note:'昭和39年測量・昭和41.6.30発行',list:'122-5-1-1'},
      {name:'山陰', north:32.4200830441108, west:131.497591824968, south:32.336761453684, east:131.62258298605,note:'昭和39年測量・昭和41.6.30発行',list:'122-6-4-1'},
]});
dataset.age.push({
   folderName:'03', start: 1978, end: 1978, scale:'1/25000', mapList: [
      {name:'上井野', north:32.503407003003, west:131.497589606959, south:32.4200854384876, east:131.622580767066,note:'昭和53年改測・昭和56.1.30発行',list:'122-6-3-2'},
      {name:'平岩', north:32.4200854384876, west:131.622580767066, south:32.3367638535467, east:131.747571949793,note:'昭和53年改測・昭和55.12.28発行',list:'122-6-2-4'},
      {name:'日向', north:32.5034094028277, west:131.622578538873, south:32.4200878438284, east:131.747569720677,note:'昭和53年改測・昭和55.7.30発行',list:'122-6-1-4'},
      {name:'川水流', north:32.586730951452, west:131.497587379748, south:32.5034094028277, east:131.622578538873,note:'昭和53年改測・昭和55.5.30発行',list:'122-5-4-4'},
      {name:'行縢山', north:32.6700548994731, west:131.497585143299, south:32.5867333567194, east:131.622576301435,note:'昭和53年改測・昭和55.5.30発行',list:'122-5-3-4'},
      {name:'延岡', north:32.5867333567194, west:131.622576301435, south:32.5034118136414, east:131.747567482309,note:'昭和53年改測・昭和55.4.30発行',list:'122-5-2-5'},
      {name:'延岡北部', north:32.6700573101778, west:131.622574054716, south:32.5867357730006, east:131.747565234654,note:'昭和53年改測・昭和55.5.30発行',list:'122-5-1-5'},
      {name:'山陰', north:32.4200830441108, west:131.497591824968, south:32.336761453684, east:131.62258298605,note:'昭和53年改測・昭和56.2.28発行',list:'122-6-4-3'},
]});
dataset.age.push({
   folderName:'04', start: 1999, end: 2000, scale:'1/25000', mapList: [
      {name:'延岡北部', north:32.6700573101778, west:131.622574054716, south:32.5867357730006, east:131.747565234654,note:'平成12年修正・平成13.9.1発行',list:'122-5-1-8B'},
      {name:'上井野', north:32.503407003003, west:131.497589606959, south:32.4200854384876, east:131.622580767066,note:'平成12年修正・平成12.11.1発行',list:'122-6-3-4B'},
      {name:'川水流', north:32.586730951452, west:131.497587379748, south:32.5034094028277, east:131.622578538873,note:'平成12年修正・平成13.6.1発行',list:'122-5-4-7B'},
      {name:'行縢山', north:32.6700548994731, west:131.497585143299, south:32.5867333567194, east:131.622576301435,note:'平成12年修正・平成14.2.1発行',list:'122-5-3-7'},
      {name:'延岡', north:32.5867333567194, west:131.622576301435, south:32.5034118136414, east:131.747567482309,note:'平成12年修正・平成13.6.1発行',list:'122-5-2-8B'},
      {name:'山陰', north:32.4200830441108, west:131.497591824968, south:32.3367619198366, east:131.646905637509,note:'平成11年部修・平成12.11.1発行',list:'122-6-4-5'},
      {name:'日向', north:32.5034094028277, west:131.622578538873, south:32.408064063654, east:131.747570042912,note:'平成11年部修・平成12.11.1発行',list:'122-6-1-6B'},
]});
kjmapDataSet['shunan'] = new Object();
dataset = kjmapDataSet['shunan'];
dataset.age = new Array();
dataset.age.push({
   folderName:'00', start: 1899, end: 1899, scale:'1/50000', mapList: [
      {name:'三田尻', north:34.169884137532, west:131.500431905298, south:34.0032416167235, east:131.750414208556,note:'明治32年測図・明治35.6.30発行',list:'119-8-18'},
      {name:'徳山', north:34.1698891648691, west:131.750409355826, south:34.0032466683229, east:132.000391750318,note:'明治32年測図・明治36.12.28発行',list:'119-4-1'},
      {name:'室積', north:34.0032416167235, west:131.750414208556, south:33.8365990578974, east:132.000396606878,note:'明治32年測図・明治35.12.28発行',list:'120-1-22'},
]});
dataset.age.push({
   folderName:'01', start: 1949, end: 1949, scale:'1/50000', mapList: [
      {name:'光', north:34.0032416167235, west:131.750414208556, south:33.8365990578974, east:132.000396606878,note:'昭和24年応修・昭和32.6.30発行',list:'120-1-6'},
      {name:'徳山', north:34.1698891648691, west:131.750409355826, south:34.0032466683229, east:132.000391750318,note:'昭和24年応修・昭和32.11.30発行',list:'119-4-13'},
      {name:'防府', north:34.169884137532, west:131.500431905298, south:34.0032416167235, east:131.750414208556,note:'昭和24年応修・昭和30.7.30発行',list:'119-8-7'},
]});
dataset.age.push({
   folderName:'02', start: 1968, end: 1969, scale:'1/25000', mapList: [
      {name:'光', north:34.0032440784471, west:131.872514333044, south:33.9149454239478, east:131.997505687621,note:'昭和43年改測・昭和45.6.30発行',list:'120-1-1-5'},
      {name:'笠戸島', north:34.0032415586161, west:131.74752556835, south:33.9199202888754, east:131.872516755141,note:'昭和43年測量・昭和45.12.28発行',list:'120-1-3-1'},
      {name:'菅野湖', north:34.1698916371281, west:131.872509458792, south:34.0865703945196, east:131.997500666482,note:'昭和43年測量・昭和45.12.28発行',list:'119-4-1-1'},
      {name:'呼坂', north:34.0865678578594, west:131.872511900942, south:34.0032466096881, east:131.997503109566,note:'昭和43年測量・昭和45.12.28発行',list:'119-4-2-1'},
      {name:'須々万本郷', north:34.1698891065129, west:131.74752071613, south:34.0865678578594, east:131.872511900942,note:'昭和43年測量・昭和45.12.28発行',list:'119-4-3-1'},
      {name:'徳山', north:34.0865653326335, west:131.747523147241, south:34.0032440784471, east:131.872514333044,note:'昭和43年測量・昭和45.12.28発行',list:'119-4-4-1'},
      {name:'島地', north:34.1698865873685, west:131.622531985266, south:34.0865653326335, east:131.747523147241,note:'昭和44年測量・昭和45.12.28発行',list:'119-8-1-1'},
      {name:'福川', north:34.0865628188539, west:131.622534405326, south:34.0032415586161, east:131.74752556835,note:'昭和44年測量・昭和45.12.28発行',list:'119-8-2-1'},
]});
dataset.age.push({
   folderName:'03', start: 1985, end: 1985, scale:'1/25000', mapList: [
      {name:'福川', north:34.0865628188539, west:131.622534405326, south:34.0032415586161, east:131.74752556835,note:'昭和60年修正・昭和61.7.30発行',list:'119-8-2-5'},
      {name:'島地', north:34.1698865873685, west:131.622531985266, south:34.0865653326335, east:131.747523147241,note:'昭和60年修正・昭和61.7.30発行',list:'119-8-1-4'},
      {name:'徳山', north:34.0865653326335, west:131.747523147241, south:34.0032440784471, east:131.872514333044,note:'昭和60年修正・昭和61.3.30発行',list:'119-4-4-5'},
      {name:'須々万本郷', north:34.1698891065129, west:131.74752071613, south:34.0865678578594, east:131.872511900942,note:'昭和60年修正・昭和61.11.30発行',list:'119-4-3-4'},
      {name:'呼坂', north:34.0865678578594, west:131.872511900942, south:34.0032466096881, east:131.997503109566,note:'昭和60年修正・昭和61.12.28発行',list:'119-4-2-5'},
      {name:'菅野湖', north:34.1698916371281, west:131.872509458792, south:34.0865703945196, east:131.997500666482,note:'昭和60年修正・昭和62.1.30発行',list:'119-4-1-4'},
      {name:'笠戸島', north:34.0032415586161, west:131.74752556835, south:33.9199202888754, east:131.872516755141,note:'昭和60年修正・昭和61.1.30発行',list:'120-1-3-4'},
      {name:'光', north:34.0032440784471, west:131.872514333044, south:33.9149343852103, east:131.997505687942,note:'昭和60年修正・昭和62.2.28発行',list:'120-1-1-10'},
]});
dataset.age.push({
   folderName:'04', start: 1994, end: 2001, scale:'1/25000', mapList: [
      {name:'光', north:34.0032440784471, west:131.872514333044, south:33.9150381133474, east:131.997505684921,note:'平成13年修正・平成14.11.1発行',list:'120-1-1-14'},
      {name:'笠戸島', north:34.0032415586161, west:131.74752556835, south:33.9199202888754, east:131.872516755141,note:'平成13年修正・平成14.9.1発行',list:'120-1-3-7'},
      {name:'菅野湖', north:34.1698916371281, west:131.872509458792, south:34.0865703945196, east:131.997500666482,note:'平成13年修正・平成14.6.1発行',list:'119-4-1-7'},
      {name:'呼坂', north:34.0865678578594, west:131.872511900942, south:34.0032466096881, east:131.997503109566,note:'平成13年修正・平成14.8.1発行',list:'119-4-2-10'},
      {name:'須々万本郷', north:34.1698891065129, west:131.74752071613, south:34.0865678578594, east:131.872511900942,note:'平成6年更新・平成7.3.1発行',list:'119-4-3-7B'},
      {name:'徳山', north:34.0865653326335, west:131.747523147241, south:34.0032440784471, east:131.872514333044,note:'平成13年修正・平成14.7.1発行',list:'119-4-4-9'},
      {name:'島地', north:34.1698865873685, west:131.622531985266, south:34.0865653326335, east:131.747523147241,note:'平成10年部修・平成12.4.1発行',list:'119-8-1-7B'},
      {name:'福川', north:34.0865628188539, west:131.622534405326, south:34.0032415586161, east:131.74752556835,note:'平成13年修正・平成15.2.1発行',list:'119-8-2-9'},
]});
