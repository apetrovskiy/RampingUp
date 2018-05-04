Imports System.IO

Public Class CsvReader
    Inherits DataReader

    Public Overrides Function LoadData(filePath As String) As IEnumerable(Of TradeItem)
        CheckInputFile(filePath)

        Dim linesCollection As New List(Of String())
        Using reader As New StreamReader(filePath)
            While Not reader.EndOfStream
                linesCollection.Add(reader.ReadLine().Split(","))
            End While
        End Using

        Return ConvertStringArrayToTradeItemCollection(linesCollection)
            
    End Function
End Class