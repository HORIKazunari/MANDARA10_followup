Public Class clsALZS
    'データ圧縮解凍DLL [ALZS]
    'Copyright (c) 1998-2002 ごぉき/Assemblage Laboratory.
    'E -Mail: gok@ net.email.ne.jp
    'Homepage : http://www.asahi-net.or.jp/~uk8t-ktu/

    Public Declare Function ALZS_GetVersion Lib "alzs.dll" (ByRef c_info As Byte) As Integer

    ''' <summary>
    ''' ALZS圧縮
    ''' </summary>
    ''' <param name="Data">元バイト配列の1バイト目</param>
    ''' <param name="data_size">データのバイト数</param>
    ''' <param name="encode">圧縮バイト配列の1バイト目、配列は十分にとる</param>
    ''' <param name="encode_size">圧縮するバイト数。データのバイト数と同じでよい。</param>
    ''' <param name="encode_result">圧縮後のバイト数</param>
    ''' <param name="callback"></param>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Declare Function ALZS_Compress Lib "alzs.dll" (ByRef Data As Byte, ByVal data_size As Integer, ByRef encode As Byte,
                   ByVal encode_size As Integer, ByRef encode_result As Integer, ByVal callback As Integer, ByVal param As Integer) As Integer

    ''' <summary>
    ''' ALZS展開
    ''' </summary>
    ''' <param name="Data">圧縮データの1バイト目</param>
    ''' <param name="data_size">圧縮データのサイズ</param>
    ''' <param name="output">復元データを入れるバイト配列の1バイト目</param>
    ''' <param name="callback"></param>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Declare Function ALZS_Expand Lib "alzs.dll" (ByRef Data As Byte, ByVal data_size As Integer,
                     ByRef output As Byte, ByVal callback As Integer, ByVal param As Integer) As Integer

End Class
