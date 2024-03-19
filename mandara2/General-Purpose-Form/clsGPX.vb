Imports System.IO
Imports System.Xml

Public Class clsGPX
    Private Enum ReadingElement
        ele = 1
        time = 2
        other = 3
    End Enum
    Public Structure GPX_Info
        Public Position As strLatLon
        Public Time As Date
        Public Elevation As Single
    End Structure

    Private ObjData As List(Of GPX_Info)
    Public Function Get_GPXFile(ByVal FileName As String, ByRef RetData As List(Of GPX_Info)) As Boolean
        ObjData = New List(Of GPX_Info)
        If readGPX(FileName) = False Then
            Return False
        End If
        If ObjData.Count = 0 Then
            Return False
        End If
        RetData = ObjData
        Return True
    End Function
    Private Function readGPX(ByVal FileName As String) As Boolean
        Dim st As New System.Xml.XmlReaderSettings
        Dim readingNodeText As ReadingElement

        Dim gData As GPX_Info

        '空白を無視する
        st.IgnoreWhitespace = True
        st.IgnoreComments = True
        Try
            Dim reader As XmlReader = XmlReader.Create(FileName, st)
            Dim pointN As Integer = 0
            Try
                While reader.Read()
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            Select Case reader.Name
                                Case "trkseg"
                                Case "trkpt"
                                    reader.MoveToAttribute("lat")
                                    gData.Position.Latitude = Val(reader.Value)
                                    reader.MoveToElement()
                                    reader.MoveToAttribute("lon")
                                    gData.Position.Longitude = Val(reader.Value)
                                    reader.MoveToElement()
                                Case "ele"
                                    readingNodeText = ReadingElement.ele
                                Case "time"
                                    readingNodeText = ReadingElement.time
                                Case Else
                                    readingNodeText = ReadingElement.other
                            End Select
                        Case XmlNodeType.Text
                            Select Case readingNodeText
                                Case ReadingElement.ele
                                    gData.Elevation = Val(reader.Value)
                                Case ReadingElement.time
                                    gData.Time = DateTime.Parse(reader.Value, System.Globalization.CultureInfo.CurrentCulture, Globalization.DateTimeStyles.AssumeUniversal)
                            End Select
                        Case XmlNodeType.EndElement
                            Select Case reader.Name
                                Case "trkpt"
                                    ObjData.Add(gData)
                            End Select
                    End Select
                End While
            Catch ex As XmlException
                MsgBox(ex.ToString())
                Return False
            Finally
                reader.Close()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function
End Class
