Module TKY2JGD
    'Attribute VB_Name = "TKY2JGD"
    'このモジュールのプログラムは、国土地理院のTKY2JGDのソースコードの一部を使用しています。

    '「このプログラムは、国土地理院長の承認を得て、同院の技術資料H･1-No.2「測地成果2000のための座標変換ソフトウェアTKY2JGD」を利用し作成したものである。
    '（承認番号　国地企調第174号　平成18年８月22日）」


    Private Const PID As Double = 3.14159265358979
    Private Const TWO_PI As Double = 6.28318530717959
    Private Const HAF_PI As Double = 1.5707963267949
    Private Const rad2deg As Double = 57.2957795130823     'ラジアンを度にするため掛ける数
    Private Const deg2rad As Double = 0.0174532925199433 '度をラジアンにするため掛ける数
    Private Const ROBYO As Double = 206264.806247          '3600*180/PI
    Public Structure EllipPar '楕円体パラメータの構造体を定義
        Dim a As Double   'semimajor axix in meter
        Dim f1 As Double  'reciprocal flattening
        Dim f As Double   'flattening
        Dim E As Double   'squared eccentricity
        Dim namec As String 'ellipsoid name
    End Structure
    Dim EP(2) As EllipPar   'EP(1)はBessel楕円体，EP(2)はGRS-80楕円体
    Private Structure XY_Genten_Info
        Dim CenterB As Double
        Dim CenterL As Double
    End Structure
    Dim XY_Genten(19) As XY_Genten_Info

    Private Sub Set_EP_Parameter()
        EP(1).a = 6377397.155
        EP(1).f1 = 299.152813
        EP(1).namec = "Bessel"
        EP(1).f = 1.0# / EP(1).f1
        EP(1).E = (2.0# * EP(1).f1 - 1.0#) / EP(1).f1 / EP(1).f1  '=e*e (squared e)
        EP(2).a = 6378137.0#
        EP(2).f1 = 298.257222101
        EP(2).namec = "GRS-80"
        EP(2).f = 1.0# / EP(2).f1
        EP(2).E = (2.0# * EP(2).f1 - 1.0#) / EP(2).f1 / EP(2).f1  '=e*e (squared e)

        XY_Genten(1).CenterB = 33
        XY_Genten(1).CenterL = 129.5
        XY_Genten(2).CenterB = 33
        XY_Genten(2).CenterL = 131
        XY_Genten(3).CenterB = 36
        XY_Genten(3).CenterL = 132 + 10 / 60
        XY_Genten(4).CenterB = 33
        XY_Genten(4).CenterL = 133.5
        XY_Genten(5).CenterB = 36
        XY_Genten(5).CenterL = 134 + 20 / 60
        XY_Genten(6).CenterB = 36
        XY_Genten(6).CenterL = 136
        XY_Genten(7).CenterB = 36
        XY_Genten(7).CenterL = 137 + 10 / 60
        XY_Genten(8).CenterB = 36
        XY_Genten(8).CenterL = 138.5
        XY_Genten(9).CenterB = 36
        XY_Genten(9).CenterL = 139 + 50 / 60
        XY_Genten(10).CenterB = 40
        XY_Genten(10).CenterL = 140 + 50 / 60
        XY_Genten(11).CenterB = 44
        XY_Genten(11).CenterL = 140 + 15 / 60
        XY_Genten(12).CenterB = 44
        XY_Genten(12).CenterL = 142 + 15 / 60
        XY_Genten(13).CenterB = 44
        XY_Genten(13).CenterL = 144 + 15 / 60
        XY_Genten(14).CenterB = 26
        XY_Genten(14).CenterL = 142
        XY_Genten(15).CenterB = 26
        XY_Genten(15).CenterL = 127.5
        XY_Genten(16).CenterB = 26
        XY_Genten(16).CenterL = 124
        XY_Genten(17).CenterB = 26
        XY_Genten(17).CenterL = 131
        XY_Genten(18).CenterB = 20
        XY_Genten(18).CenterL = 136
        XY_Genten(19).CenterB = 26
        XY_Genten(19).CenterL = 154

    End Sub
    ''' <summary>
    ''' 日本測地系から世界測地系 Tokyo97系からITRF94系への座標変換を行う
    ''' </summary>
    ''' <param name="B1">入力緯度(度)</param>
    ''' <param name="L1">入力経度(度)</param>
    ''' <param name="B2">出力緯度(度)</param>
    ''' <param name="L2">出力経度(度)</param>
    ''' <remarks></remarks>
    Sub Tokyo97toITRF94(ByVal B1 As Double, ByVal L1 As Double, ByRef B2 As Double, ByRef L2 As Double)
        ' Ver.1.1  1999/1/28  (C) Mikio TOBITA 飛田幹男，国土地理院
        ' 「3ﾊﾟﾗﾒｰﾀによる」Tokyo97系からITRF94系への座標変換を行う。
        '  この変換では楕円体高Hはゼロとする。
        ' by 飛田幹男
        ' 入力　B1    : 緯度(度)
        ' 　　　L1    : 経度(度)
        ' 出力　B2    : 緯度(度)
        ' 　　　L2    : 経度(度)
        Dim Brad As Double, ALrad As Double '緯度，経度(radian)
        Dim H As Double                     '楕円体高(m)
        Dim X1 As Double, Y1 As Double, Z1 As Double, x2 As Double, y2 As Double, Z2 As Double '(m)

        Call Set_EP_Parameter()

        Brad = B1 * deg2rad
        ALrad = L1 * deg2rad

        '緯度，経度から三次元直交座標系(X,Y,Z)への換算
        Call BLHXYZcalc(Brad, ALrad, 0, X1, Y1, Z1, EP(1)) 'EP(1):Bessel楕円体
        '三次元直交座標系(X,Y,Z)から三次元直交座標系(X,Y,Z)への座標変換
        Call xyz2xyz(X1, Y1, Z1, x2, y2, Z2)
        '三次元直交座標系(X,Y,Z)から緯度，経度への換算
        Call XYZBLHcalc(x2, y2, Z2, Brad, ALrad, H, EP(2)) 'EP(2):GRS-80楕円体

        B2 = Brad * rad2deg
        L2 = ALrad * rad2deg
    End Sub
    ''' <summary>
    ''' 世界測地系から日本測地系／ITRF94系からTokyo97系への座標変換を行う
    ''' </summary>
    ''' <param name="B1">入力緯度(度)</param>
    ''' <param name="L1">入力経度(度)</param>
    ''' <param name="B2">出力緯度(度)</param>
    ''' <param name="L2">出力経度(度)</param>
    ''' <remarks></remarks>
    Sub ITRF94toTokyo97(ByVal B1 As Double, ByVal L1 As Double, ByRef B2 As Double, ByRef L2 As Double)
        ' Ver.1.1  1999/1/28  (C) Mikio TOBITA 飛田幹男，国土地理院
        ' 「3ﾊﾟﾗﾒｰﾀによる」ITRF94系からTokyo97系への座標変換を行う。
        '  この変換では楕円体高Hは，変換後の水平位置B2,L2を正確に元に戻すため，2ステップで変換する。
        '　(1)初期値はゼロとし一度変換したあと，(2)その時のH分だけ下駄を履かせ，もう一度変換する。
        ' by 飛田幹男
        ' 入力　B1    : 緯度(度)
        ' 　　　L1    : 経度(度)
        ' 出力　B2    : 緯度(度)
        ' 　　　L2    : 経度(度)
        Dim Brad1 As Double, ALrad1 As Double '緯度，経度(radian)
        Dim Brad2 As Double, ALrad2 As Double '緯度，経度(radian)
        Dim H As Double                       '楕円体高(m)
        Dim X1 As Double, Y1 As Double, Z1 As Double, x2 As Double, y2 As Double, Z2 As Double '(m)

        Call Set_EP_Parameter()

        Brad1 = B1 * deg2rad
        ALrad1 = L1 * deg2rad

        '(1)
        '緯度，経度から三次元直交座標系(X,Y,Z)への換算
        Call BLHXYZcalc(Brad1, ALrad1, 0.0#, X1, Y1, Z1, EP(2))  'EP(2):GRS-80楕円体
        '三次元直交座標系(X,Y,Z)から三次元直交座標系(X,Y,Z)への座標変換
        Call xyz2xyzR(X1, Y1, Z1, x2, y2, Z2)
        '三次元直交座標系(X,Y,Z)から緯度，経度への換算
        Call XYZBLHcalc(x2, y2, Z2, Brad2, ALrad2, H, EP(1)) 'EP(1):Bessel楕円体
        '(2)
        '緯度，経度から三次元直交座標系(X,Y,Z)への換算
        Call BLHXYZcalc(Brad1, ALrad1, -H, X1, Y1, Z1, EP(2))  'EP(2):GRS-80楕円体
        '三次元直交座標系(X,Y,Z)から三次元直交座標系(X,Y,Z)への座標変換
        Call xyz2xyzR(X1, Y1, Z1, x2, y2, Z2)
        '三次元直交座標系(X,Y,Z)から緯度，経度への換算
        Call XYZBLHcalc(x2, y2, Z2, Brad2, ALrad2, H, EP(1)) 'EP(1):Bessel楕円体

        B2 = Brad2 * rad2deg
        L2 = ALrad2 * rad2deg
    End Sub
    Sub BLHXYZcalc(ByVal Brad As Double, ByVal ALrad As Double, ByVal H As Double,
                   ByRef X As Double, ByRef Y As Double, ByRef z As Double, ByRef EP As EllipPar) '________________________
        ' Ver.1.2  1999/1/29 (C) Mikio TOBITA 飛田幹男，国土地理院
        '   Ver.1.2から，EllipPar Typeに対応
        ' B,L,HからX,Y,Zに変換する。 このとき楕円体を指定する必要あり。
        ' 入力　 Brad : 緯度(RADIAN)
        '     　ALrad : 経度(RADIAN)
        '        H    : 高さ(m)
        '        A    : 楕円体の長半径(m)
        '        FI   : 楕円体の偏平率の逆数
        '        E    : 楕円体の離心率の２乗
        ' 出力　 X    : ３次元直交座標系(m)
        '        Y    : ３次元直交座標系(m)
        '        Z    : ３次元直交座標系(m)
        Dim CB As Double, CL As Double, SB As Double, SL As Double, w As Double, an As Double
        Dim a As Double, fi As Double, E As Double
        a = EP.a
        fi = EP.f1
        E = EP.E
        CB = Math.Cos(Brad) : SB = Math.Sin(Brad)
        CL = Math.Cos(ALrad) : SL = Math.Sin(ALrad)
        w = Math.Sqrt(1.0# - E * SB * SB)
        an = a / w
        X = (an + H) * CB * CL
        Y = (an + H) * CB * SL
        z = (an * (1.0# - E) + H) * SB
    End Sub

    Private Sub xyz2xyzR(ByVal X1 As Double, ByVal Y1 As Double, ByVal Z1 As Double,
                         ByRef x2 As Double, ByRef y2 As Double, ByRef Z2 As Double)
        ' Ver.2.3  1999/5/30  (C) Mikio TOBITA 飛田幹男，国土地理院
        ' 座標変換をします。
        ' 逆方向変換 R:Reverse
        ' 変換ﾊﾟﾗﾒｰﾀは，ITRF94からTokyo97固定とします。TKY2JGD専用なので。
        ' 座標変換をします。
        '  |XS| |X| |T1| | D  -R3  R2||X|
        '  |YS|=|Y|+|T2|+| R3  D  -R1||Y|   cf. IERS ANNUAL REPORT FOR 1989
        '  |ZS| |Z| |T3| |-R2  R1  D ||Z|                             II-23
        '  入力　X1, Y1, Z1 : ３次元直交座標系での座標 (m)
        '  出力　X2, Y2, Z2 : ３次元直交座標系での座標 (m)
        '  座標変換パラメータ。パラメータファイル中のフォーマット。
        '         T1   : X shift(cm)
        '         T2   : Y shift(cm)
        '         T3   : Z shift(cm)
        '         D    : scale factor (e-8)
        '         R1   : rotation around X axis (marcsec)
        '         R2   : rotation around Y axis (marcsec)
        '         R3   : rotation around Z axis (marcsec)
        '  実際に計算するときのフォーマットでの座標変換パラメータ。
        '       T1real : X shift(m)
        '       T2real : Y shift(m)
        '       T3real : Z shift(m)
        '        Dreal : scale factor (e-0)
        '       R1real : rotation around X axis (radian)
        '       R2real : rotation around Y axis (radian)
        '       R3real : rotation around Z axis (radian)
        Dim T1 As Double, T2 As Double, T3 As Double, D As Double
        Dim r1 As Double, r2 As Double, R3 As Double
        Dim T1real As Double, T2real As Double, T3real As Double, Dreal As Double
        Dim R1real As Double, R2real As Double, R3real As Double

        'パラメータの代入　ITRF94からTokyo97へ
        ' -14641.40   50733.70   68050.70    0.00    0.00    0.00    0.00       Tokyo97        ITRF94
        T1 = 14641.4
        T2 = -50733.7
        T3 = -68050.7
        'D = 0#
        'R1 = 0#
        'R2 = 0#
        'R3 = 0#
        '実際に使う変換パラメータの計算
        T1real = T1 * 0.01                   '      cm to m
        T2real = T2 * 0.01                   '      cm to m
        T3real = T3 * 0.01                   '      cm to m
        'Dreal = D * 0.00000001               '     e-8 to e-0
        'R1real = R1 * 0.001 / 3600# * deg2rad ' marcsec to radian
        'R2real = R2 * 0.001 / 3600# * deg2rad
        'R3real = R3 * 0.001 / 3600# * deg2rad

        '一般的には７パラメータで次のように変換しますが，ここでは3パラメータなので不要な計算は省略します。
        'X2 = X1 + T1real + Dreal * X1 - R3real * Y1 + R2real * Z1
        'Y2 = Y1 + T2real + R3real * X1 + Dreal * Y1 - R1real * Z1
        'Z2 = Z1 + T3real - R2real * X1 + R1real * Y1 + Dreal * Z1
        x2 = X1 + T1real
        y2 = Y1 + T2real
        Z2 = Z1 + T3real

    End Sub
    Private Sub XYZBLHcalc(ByVal X As Double, ByVal Y As Double, ByVal z As Double,
                           ByRef Brad As Double, ByRef ALrad As Double, ByRef H As Double, ByRef EP As EllipPar) '________________________
        ' Ver.2.2  1999/1/29 (C) Mikio TOBITA 飛田幹男，国土地理院
        '   Ver.2.2から，EllipPar Typeに対応
        ' X,Y.ZからB,L,Hに変換する。 このとき楕円体を指定する必要あり。
        ' 入力　 X    : ３次元直交座標系(m)
        '        Y    : ３次元直交座標系(m)
        '        Z    : ３次元直交座標系(m)
        '        A    : 楕円体の長半径(m)
        '        FI   : 楕円体の偏平率の逆数
        '        E    : 楕円体の離心率の２乗
        ' 出力　 Brad : 緯度(RADIAN)
        '     　ALrad : 経度(RADIAN)
        '        H    : 高さ(m)
        Static P2 As Double, p As Double, r As Double
        Static myu As Double, myus3 As Double, myuc3 As Double
        Static tmp As Double
        Dim a As Double, fi As Double, E As Double
        a = EP.a
        fi = EP.f1
        E = EP.E

        P2 = X * X + Y * Y
        p = Math.Sqrt(P2)
        If p = 0 Then
            'frmMain!lblStatus.Backcolor = &HFF&
            'frmMain!lblStatus = "Warning: 座標値(X,Y,Z)を入力して下さい。"
            Exit Sub
        End If
        If X = 0 Then
            ALrad = HAF_PI
        Else
            ALrad = Math.Atan(Y / X) '経度
        End If
        If X < 0 Then ALrad = ALrad + PID
        If ALrad > PID Then ALrad = ALrad - TWO_PI

        r = Math.Sqrt(P2 + z * z)
        myu = Math.Atan((z / p) * (1.0# - (1.0# / fi) + E * a / r))
        myus3 = Math.Sin(myu)
        myus3 = myus3 * myus3 * myus3
        myuc3 = Math.Cos(myu)
        myuc3 = myuc3 * myuc3 * myuc3
        Brad = Math.Atan((z * (1.0# - 1.0# / fi) + E * a * myus3) / ((1.0# - 1.0# / fi) * (p - E * a * myuc3)))
        H = p * Math.Cos(Brad) + z * Math.Sin(Brad) - a * Math.Sqrt(1.0# - E * Math.Sin(Brad) * Math.Sin(Brad))    '楕円体高

    End Sub

    Private Sub xyz2xyz(ByVal X1 As Double, ByVal Y1 As Double, ByVal Z1 As Double,
                        ByRef x2 As Double, ByRef y2 As Double, ByRef Z2 As Double)
        ' Ver.2.2  1999/1/29 (C) Mikio TOBITA 飛田幹男，国土地理院
        ' 座標変換をします。
        ' 変換ﾊﾟﾗﾒｰﾀは，Tokyo97からITRF94固定とします。TKY2JGD専用なので。
        '  |XS| |X| |T1| | D  -R3  R2||X|
        '  |YS|=|Y|+|T2|+| R3  D  -R1||Y|   cf. IERS ANNUAL REPORT FOR 1989
        '  |ZS| |Z| |T3| |-R2  R1  D ||Z|                             II-23
        '  入力　X1, Y1, Z1 : ３次元直交座標系での座標 (m)
        '  出力　X2, Y2, Z2 : ３次元直交座標系での座標 (m)
        '  座標変換パラメータ。パラメータファイル中のフォーマット。
        '         T1   : X shift(cm)
        '         T2   : Y shift(cm)
        '         T3   : Z shift(cm)
        '         D    : scale factor (e-8)
        '         R1   : rotation around X axis (marcsec)
        '         R2   : rotation around Y axis (marcsec)
        '         R3   : rotation around Z axis (marcsec)
        '  実際に計算するときのフォーマットでの座標変換パラメータ。
        '       T1real : X shift(m)
        '       T2real : Y shift(m)
        '       T3real : Z shift(m)
        '        Dreal : scale factor (e-0)
        '       R1real : rotation around X axis (radian)
        '       R2real : rotation around Y axis (radian)
        '       R3real : rotation around Z axis (radian)
        Dim T1 As Double, T2 As Double, T3 As Double, D As Double
        Dim r1 As Double, r2 As Double, R3 As Double
        Dim T1real As Double, T2real As Double, T3real As Double, Dreal As Double
        Dim R1real As Double, R2real As Double, R3real As Double
        'パラメータの代入　Tokyo97からITRF94へ
        ' -14641.40   50733.70   68050.70    0.00    0.00    0.00    0.00       Tokyo97        ITRF94
        T1 = -14641.4
        T2 = 50733.7
        T3 = 68050.7
        'D = 0#
        'R1 = 0#
        'R2 = 0#
        'R3 = 0#
        '実際に使う変換パラメータの計算
        T1real = T1 * 0.01                   '      cm to m
        T2real = T2 * 0.01                   '      cm to m
        T3real = T3 * 0.01                   '      cm to m
        'Dreal = D * 0.00000001               '     e-8 to e-0
        'R1real = R1 * 0.001 / 3600# * deg2rad ' marcsec to radian
        'R2real = R2 * 0.001 / 3600# * deg2rad
        'R3real = R3 * 0.001 / 3600# * deg2rad

        '一般的には７パラメータで次のように変換しますが，ここでは3パラメータなので不要な計算は省略します。
        'X2 = X1 + T1real + Dreal * X1 - R3real * Y1 + R2real * Z1
        'Y2 = Y1 + T2real + R3real * X1 + Dreal * Y1 - R1real * Z1
        'Z2 = Z1 + T3real - R2real * X1 + R1real * Y1 + Dreal * Z1
        x2 = X1 + T1real
        y2 = Y1 + T2real
        Z2 = Z1 + T3real

    End Sub

    Public Sub doCalcXy2bl(ByVal Ellip12 As Integer, ByVal Kei As Integer, ByVal X As Double, ByVal Y As Double,
                           ByRef OutB As Double, ByRef OutL As Double)
        ' Ver.1.3  1999/10/19  (C) Mikio TOBITA 飛田幹男，国土地理院
        ' 平面直角座標X,Yを緯度,経度に換算します。
        ' 「精密測地網一次基準点測量計算式」を導入し多くの項を採用。
        ' NAD83 Datum Sheet Dataのアラスカの点で往復計算の経度差が0.00156秒あったのを0.00000秒にした。
        ' Ellip12=1: Bessel楕円体
        ' Ellip12=2: GRS80楕円体
        'この計算は変換の第1段階なので緯度経度入力値のﾁｪｯｸが必要
        Dim M0 As Double 'Kei As Integer   '系番号，基準子午線の縮尺係数
        '  Dim X As Double, Y As Double       '平面直角座標。入力値。meter
        Dim cB1 As Double, cL1 As Double   '原点の緯度，経度。c = combo box
        Dim B1 As Double, L1 As Double     '原点の緯度，経度。基本的にradian
        Dim b As Double, L As Double       '求める緯度，経度。基本的にradian
        Dim Bdeg As Double, Ldeg As Double '求める緯度，経度。基本的にdeg
        Dim Gamma As Double                '=γ 子午線収差角。radian
        Dim Gammadeg As Double             '真北方向角。deg
        Dim MMM As Double                  '縮尺係数
        Dim D As Integer, AM As Integer, s As Double, SN As Integer, SNS As String
        Dim AEE As Double, CEE As Double, Ep2 As Double
        Dim AJ As Double, BJ As Double, CJ As Double, DJ As Double, EJ As Double
        Dim FJ As Double, GJ As Double, HJ As Double, IJ As Double
        Dim S0 As Double                   '赤道から座標原点までの子午線弧長
        Dim M As Double
        Dim Eta2 As Double, M1 As Double, N1 As Double         'phi1の関数
        Dim Eta2phi As Double, Mphi As Double, Nphi As Double  'phi(=B)の関数
        Dim T As Double, T2 As Double, T4 As Double, T6 As Double
        Dim e2 As Double, e4 As Double, e6 As Double, e8 As Double, e10 As Double
        Dim e12 As Double, e14 As Double, e16 As Double
        Dim S1 As Double, phi1 As Double, oldphi1 As Double, icount As Integer
        Dim Bunsi As Double, Bunbo As Double
        Dim YM0 As Double, N1CosPhi1 As Double
        Dim EPs As EllipPar

        '基準子午線の縮尺係数
        M0 = 0.9999

        Call Set_EP_Parameter()

        '楕円体ﾊﾟﾗﾒｰﾀの代入
        EPs.a = EP(Ellip12).a
        EPs.f1 = EP(Ellip12).f1
        EPs.f = EP(Ellip12).f
        EPs.E = EP(Ellip12).E
        EPs.namec = EP(Ellip12).namec
        e2 = EPs.E : e4 = e2 * e2 : e6 = e4 * e2 : e8 = e4 * e4 : e10 = e8 * e2
        e12 = e8 * e4 : e14 = e8 * e6 : e16 = e8 * e8

        '定数項 the same as bl2xy
        AEE = EPs.a * (1.0# - EPs.E)      'a(1-e2)
        CEE = EPs.a / Math.Sqrt(1.0# - EPs.E)   'C=a*sqr(1+e'2)=a/sqr(1-e2)
        Ep2 = EPs.E / (1.0# - EPs.E)      'e'2 (e prime 2) Eta2を計算するため

        '「緯度を与えて赤道からの子午線弧長を求める計算」のための９つの係数を求める。
        '「精密測地網一次基準点測量計算式」P55,P56より。係数チェック済み1999/10/19。
        AJ = 4927697775.0# / 7516192768.0# * e16
        AJ = AJ + 19324305.0# / 29360128.0# * e14
        AJ = AJ + 693693.0# / 1048576.0# * e12
        AJ = AJ + 43659.0# / 65536.0# * e10
        AJ = AJ + 11025.0# / 16384.0# * e8
        AJ = AJ + 175.0# / 256.0# * e6
        AJ = AJ + 45.0# / 64.0# * e4
        AJ = AJ + 3.0# / 4.0# * e2
        AJ = AJ + 1.0#
        BJ = 547521975.0# / 469762048.0# * e16
        BJ = BJ + 135270135.0# / 117440512.0# * e14
        BJ = BJ + 297297.0# / 262144.0# * e12
        BJ = BJ + 72765.0# / 65536.0# * e10
        BJ = BJ + 2205.0# / 2048.0# * e8
        BJ = BJ + 525.0# / 512.0# * e6
        BJ = BJ + 15.0# / 16.0# * e4
        BJ = BJ + 3.0# / 4.0# * e2
        CJ = 766530765.0# / 939524096.0# * e16
        ' CJ = CJ + 45090045# / 5870256# * e14 精密測地網一次基準点測量作業規定の誤りによるバグ
        CJ = CJ + 45090045.0# / 58720256.0# * e14
        CJ = CJ + 1486485.0# / 2097152.0# * e12
        CJ = CJ + 10395.0# / 16384.0# * e10
        CJ = CJ + 2205.0# / 4096.0# * e8
        CJ = CJ + 105.0# / 256.0# * e6
        CJ = CJ + 15.0# / 64.0# * e4
        DJ = 209053845.0# / 469762048.0# * e16
        DJ = DJ + 45090045.0# / 117440512.0# * e14
        DJ = DJ + 165165.0# / 524288.0# * e12
        DJ = DJ + 31185.0# / 131072.0# * e10
        DJ = DJ + 315.0# / 2048.0# * e8
        DJ = DJ + 35.0# / 512.0# * e6
        EJ = 348423075.0# / 1879048192.0# * e16
        EJ = EJ + 4099095.0# / 29360128.0# * e14
        EJ = EJ + 99099.0# / 1048576.0# * e12
        EJ = EJ + 3465.0# / 65536.0# * e10
        EJ = EJ + 315.0# / 16384.0# * e8
        FJ = 26801775.0# / 469762048.0# * e16
        FJ = FJ + 4099095.0# / 117440512.0# * e14
        FJ = FJ + 9009.0# / 524288.0# * e12
        FJ = FJ + 693.0# / 131072.0# * e10
        GJ = 11486475.0# / 939524096.0# * e16
        GJ = GJ + 315315.0# / 58720256.0# * e14
        GJ = GJ + 3003.0# / 2097152.0# * e12
        HJ = 765765.0# / 469762048.0# * e16
        HJ = HJ + 45045.0# / 117440512.0# * e14
        IJ = 765765.0# / 7516192768.0# * e16

        '座標系番号，緯度，経度の読みとり
        '  Kei = Mid$(frmMain!cmbPara.Text, 1, 2)  '系番号
        '  cB1 = Mid$(frmMain!cmbPara.Text, 5, 7)  '原点緯度
        '  cL1 = Mid$(frmMain!cmbPara.Text, 14, 8) '原点経度
        '  Call dms2deg(cB1, B1, SN, D, AM, S)
        '  Call dms2deg(cL1, L1, SN, D, AM, S)
        B1 = XY_Genten(Kei).CenterB * deg2rad
        L1 = XY_Genten(Kei).CenterL * deg2rad

        On Error GoTo ErrorHandler          ' エラーが起きるとエラー処理ルーチンに飛びます。
        'X,Yの入力
        '  If Ellip12 = 1 Then
        '    X = CDbl(frmMain.txtTkyx)
        '    Y = CDbl(frmMain.txtTkyy)
        '  Else
        '    X = CDbl(frmMain.txtJgdx)
        '    Y = CDbl(frmMain.txtJgdy)
        '  End If

        '赤道からの子午線長の計算
        Call MeridS(B1, AEE, AJ, BJ, CJ, DJ, EJ, FJ, GJ, HJ, IJ, S0) '赤道から座標原点までの子午線弧長
        M = S0 + X / M0

        'Baileyの式による異性緯度（isometric latitude）phi1の計算。
        '「精密測地網一次基準点測量計算式」P57の11.(1)の式から。
        'この式と「現代測量学１ 測量の数学的基礎」P102の式とは，Cos(phi1)だけ異なる。
        'この式を導入したためベッセル楕円体以外で往復計算OKとなった。
        icount = 0
        phi1 = B1
        Do
            icount = icount + 1
            oldphi1 = phi1
            Call MeridS(phi1, AEE, AJ, BJ, CJ, DJ, EJ, FJ, GJ, HJ, IJ, S1) '赤道から点までの子午線弧長
            Bunsi = 2.0# * (S1 - M) * (1.0# - EPs.E * Math.Sin(phi1) * Math.Sin(phi1)) ^ 1.5
            Bunbo = 3.0# * EPs.E * (S1 - M) * Math.Sin(phi1) * Math.Cos(phi1) * Math.Sqrt(1.0# - EPs.E * Math.Sin(phi1) * Math.Sin(phi1)) - 2.0# * EPs.a * (1.0# - EPs.E)
            phi1 = phi1 + Bunsi / Bunbo
            If icount > 100 Then MsgBox("異性緯度を求めるのに収束しません。")
        Loop Until ((Math.Abs(phi1 - oldphi1) < 0.00000000000001) Or (icount > 100)) '本では1e-12で十分　iterationの回数は４回

        '何度も使う式を変数に代入
        YM0 = Y / M0
        T = Math.Tan(phi1)  '「精密測地網一次基準点測量計算式」P51のt1に等しい
        T2 = T * T : T4 = T2 * T2 : T6 = T4 * T2
        Eta2 = Ep2 * Math.Cos(phi1) * Math.Cos(phi1)     '=η1*η1
        M1 = CEE / Math.Sqrt((1.0# + Eta2) ^ 3.0#)
        N1 = CEE / Math.Sqrt(1.0# + Eta2)
        N1CosPhi1 = N1 * Math.Cos(phi1)

        '緯度Bの計算 「精密測地網一次基準点測量計算式」P51のphiを求める式より
        b = ((1385.0# + 3633.0# * T2 + 4095 * T4 + 1575.0# * T6) / (40320.0# * N1 ^ 8.0#)) * YM0 ^ 8.0#
        b = b - ((61.0# + 90.0# * T2 + 45 * T4 + 107.0# * Eta2 - 162.0# * T2 * Eta2 - 45.0# * T4 * Eta2) / (720.0# * N1 ^ 6.0#)) * YM0 ^ 6.0#
        b = b + ((5.0# + 3.0# * T2 + 6.0# * Eta2 - 6.0# * T2 * Eta2 - 3.0# * Eta2 ^ 2 - 9.0# * T2 * Eta2 ^ 2) / (24.0# * N1 ^ 4.0#)) * YM0 ^ 4.0#
        b = b - ((1.0# + Eta2) / (2.0# * N1 ^ 2.0#)) * YM0 ^ 2.0#
        b = b * T
        b = b + phi1

        '経度Lの計算 「精密測地網一次基準点測量計算式」P51のΔλを求める式より
        L = -((61.0# + 662.0# * T2 + 1320.0# * T4 + 720.0# * T6) / (5040.0# * N1 ^ 6.0# * N1CosPhi1)) * YM0 ^ 7.0#
        L = L + ((5.0# + 28.0# * T2 + 24.0# * T4 + 6.0# * Eta2 + 8.0# * T2 * Eta2) / (120.0# * N1 ^ 4.0# * N1CosPhi1)) * YM0 ^ 5.0#
        L = L - ((1.0# + 2.0# * T2 + Eta2) / (6.0# * N1 ^ 2.0# * N1CosPhi1)) * YM0 ^ 3.0#
        L = L + (1.0# / N1CosPhi1) * YM0
        L = L + L1

        '子午線収差角の計算 「精密測地網一次基準点測量計算式」P51のγを求める式より
        Gamma = ((1.0# + T2) * (2.0# + 3.0# * T2) / (15.0# * N1 ^ 5.0#)) * (Y / M0) ^ 5.0#
        Gamma = Gamma - ((1.0# + T2 - Eta2) / (3.0# * N1 ^ 3.0#)) * (Y / M0) ^ 3.0#
        Gamma = Gamma + (1.0# / N1) * Y / M0
        Gamma = Gamma * T

        '縮尺係数の計算 「精密測地網一次基準点測量計算式」P51のmを求める式より
        Eta2phi = Ep2 * Math.Cos(b) * Math.Cos(b)     '=η*η。Bはphiと同じ。
        Mphi = CEE / Math.Sqrt((1.0# + Eta2phi) ^ 3.0#)
        Nphi = CEE / Math.Sqrt(1.0# + Eta2phi)
        MMM = Y ^ 4.0# / (24.0# * Mphi * Mphi * Nphi * Nphi * M0 ^ 4.0#)
        MMM = MMM + Y * Y / (2.0# * Mphi * Nphi * M0 ^ 2.0#)
        MMM = MMM + 1.0#
        MMM = MMM * M0

        '出力
        Bdeg = b * rad2deg
        Ldeg = L * rad2deg

        OutB = Bdeg
        OutL = Ldeg
        '子午線収差角Gamma(rad)から，真北方向角Gammadeg(degree)へ
        '  Gammadeg = -Gamma * rad2deg
        '
        '  Call deg2dms(Bdeg, D, AM, S, SNS)
        '  If Ellip12 = 1 Then
        '    frmMain.txtTB = SNS & Format$(D, "###") & Format$(AM, "00") & Format$(S, "00.00000")
        '  Else
        '    frmMain.txtJB = SNS & Format$(D, "###") & Format$(AM, "00") & Format$(S, "00.00000")
        '  End If
        '
        '  Call deg2dms(Ldeg, D, AM, S, SNS)
        '  If Ellip12 = 1 Then
        '    frmMain.txtTL = SNS & Format$(D, "###") & Format$(AM, "00") & Format$(S, "00.00000")
        '  Else
        '    frmMain.txtJL = SNS & Format$(D, "###") & Format$(AM, "00") & Format$(S, "00.00000")
        '  End If
        '
        '  Call deg2dms3(Gammadeg, D, AM, S, SNS)
        '  If Ellip12 = 1 Then
        '    frmMain.lblTkyn = SNS & Format$(D, "###") & Format$(AM, "00") & Format$(S, "00.000")
        '  Else
        '    frmMain.lblJgdn = SNS & Format$(D, "###") & Format$(AM, "00") & Format$(S, "00.000")
        '  End If
        '
        '  If Ellip12 = 1 Then
        '    frmMain.lblTkys = Format(MMM, "#.00000000") '成果表は小数点以下６桁
        '  Else
        '    frmMain.lblJgds = Format(MMM, "#.00000000") '成果表は小数点以下６桁
        '  End If

        On Error GoTo 0                 ' エラーのトラップを無効にします。
        Exit Sub                                ' エラー処理ルーチンが実行されないように Sub を終了します。

ErrorHandler:  ' エラー処理ルーチン。
        Select Case Err.Number              ' エラー番号を評価します。
            Case 6                          ' "オーバーフローしました。" というエラーです。
                'frmMain.lblStatus.Backcolor = &HFF00&
                'frmMain.lblStatus = "入力されたX,Yの値に問題があります。計算は行いません。 in doCalcXy2bl"
                Exit Sub
            Case Else                       ' 他のエラー処理をここに記述します。
                MsgBox(Err.Description & "入力されたX,Yの値に問題があると思われます。計算は行いません。 in doCalcXy2bl")
                Exit Sub
        End Select
        Resume                              ' エラーが発生した行から処理を再開します。
    End Sub

    Private Sub MeridS(ByVal Phi As Double, ByVal AEE As Double, ByVal AJ As Double, ByVal BJ As Double, ByVal CJ As Double, ByVal DJ As Double, ByVal EJ As Double, ByVal FJ As Double, ByVal GJ As Double, ByVal HJ As Double, ByVal IJ As Double,
                       ByRef SS As Double)
        ' Ver.1.3  1999/10/19  (C) Mikio TOBITA 飛田幹男，国土地理院
        ' 赤道から緯度Phiまでの子午線弧長を計算します。
        '「精密測地網一次基準点測量計算式」P55より
        SS = IJ / 16.0# * Math.Sin(16.0# * Phi)
        SS = SS - HJ / 14.0# * Math.Sin(14.0# * Phi)
        SS = SS + GJ / 12.0# * Math.Sin(12.0# * Phi)
        SS = SS - FJ / 10.0# * Math.Sin(10.0# * Phi)
        SS = SS + EJ / 8.0# * Math.Sin(8.0# * Phi)
        SS = SS - DJ / 6.0# * Math.Sin(6.0# * Phi)
        SS = SS + CJ / 4.0# * Math.Sin(4.0# * Phi)
        SS = SS - BJ / 2.0# * Math.Sin(2.0# * Phi)
        SS = SS + AJ * Phi
        SS = AEE * SS
    End Sub


End Module
