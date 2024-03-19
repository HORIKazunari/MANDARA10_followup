# MANDARA10_followup

このリポジトリは、
谷　謙二氏が継続して開発された Windows GIS ソフトウェア MANDARA10を
支障なく動作し広く活用され続けるように、可能な作業を行い公開するものです。

[ 新しいファイルの利用法 ]

まずは、Windows上に ktgis.net 提供の MANDARA10.0.1.6 システムが
正常にイントールできている状態であると仮定します。

このリポジトリで提供している新しい MANDARA10.exe を zip圧縮した MANDARA10.zipを
このリポジトリにファイルアップロードしています。
MANDARA10.zip をお手元のWindowsの適当なフォルダにダウンロードし、解凍してください。

解凍により出てきた MANDARA10.exe を、 
C:\Program Files (x86) \MANDARA10 にある MANDARA10.exe と置き換えてください。
念のため、元のファイルは MANDARA10org.exe などにファイル名変更されることをお勧めします。
一連の作業時に、セキュリティ上の理由から管理者権限の確認を求められたり、
ファイルのプロパティでセキュリティの項目の「許可する」チェックを入れる必要があったりします。

差し替えたMANDARAのバージョンは 10.0.1.6 のまま、変更なしとしています。

[ 展開したソースコードの公開 ]

下記に説明するエラー修正・再ビルド作業をしたソースコードを公開します。
このプロジェクトのソースコードは、ktgis.net で谷謙二氏が提供された
MANDARA10SourceCode10016.zip
を展開し、（多数の警告は残っていますが）コンパイルエラーが無くなり、
とりあえず MANDARA10.exe ファイルができるようになるよう
最小限の変更にとどめる修正を行ったものです。

（このソースコードの注意点）
このソースコードは、谷謙二氏が書かれているように　
「Microsoft Visual Basic 2013、.NET Framework 4.5で動作します」
との記述に基づいて開発されています。
Microsoft社は、 .NET Framework 4.5 のサポートを2022年4月26日に終了しています。
サポート終了後は、セキュリティ対応やバグ修正がありません。
本ソースコードの再ビルドに当たっては、.NET Framework 4.8 へ変更しています。

また、本ソースコードの画面デザインは、Microsoft.VisualBasic.PowerPacks.Vs に依存しています。
2024年3月時点において、Microsoft社はこのパッケージの利用を推奨しておらず、公式の配布は停止されています。
Visual Studio 2022 には、Microsoft.VisualBasic.PowerPacks.Vs はインストールすることができず、
そのため、このソースコードの画面デザインは Visual Studio 2022 では編集・変更することができません。

[直近の作業背景]

2023年6月の国土地理院が提供する地理地院地図システム変更により、
Windows上のMANDARA10で、地理院地図を背景に使えなくなる状況が発生しました。
谷謙二氏が Visual Basic で記述されたプログラムソース情報を残しておいてくださったので、
プロジェクト管理者（堀一成）が緊急で Visaul Studio 2022 を用い、
エラー修正・再ビルド作業をしてみました。
再ビルド後のファイルにより、白地図などの背景画像に再び地理院地図が利用できることを確認しました。

[ このプロジェクトで提供するファイルのライセンスについて ]

このプロジェクトのもとになっている MANDARA10.0.1.6のソースコードに添付されているライセンス記述を転記します。

「本ソースコードのライセンスは、CC BY-SA です。
作品名（MANDARA10）、作者（谷謙二）を表示し、
改変した場合には元の作品と同じCCライセンス（このライセンス）で公開することを主な条件に、
営利目的での二次利用も許可されるCCライセンスです。」

このプロジェクトで提供するファイルも、
同じくクリエイティブ コモンズ 表示 - 継承 4.0 国際ライセンス （CC BY-SA 4.0） で公開します。
表示を必要とする作品名は  「MANDARA10」、作者名は 「谷 謙二」です。


本プロジェクト提供ファイルの利用によって生じる一切の損害等について
プロジェクト管理者（堀一成）は何らの責任を負いません。
