Imports System.IO

Public MustInherit Class DataReader
    Public Shared Property IdHolder() As Integer
    Public MustOverride Function LoadData(filePath As String) As IEnumerable(Of TradeItem)

    Protected Sub IncrementIdHolder()
        IdHolder += 1
    End Sub

    Public Function ConvertStringArrayToTradeItemCollection(linesCollection As IEnumerable(Of String())) _
        As IEnumerable(Of TradeItem)
        Return linesCollection.Skip(1).ToList().Select(Function(s) As TradeItem
            IncrementIdHolder()
            Dim b =
                    Function() _
                    New TradeItem _
                    With { .Id = IdHolder, .Name = s(1), .Price = Convert.ToDecimal(s(2)),
                    .Amount = Convert.ToDecimal(s(3)) }
            Return b.Invoke()
        End Function)
    End Function

    Protected Sub CheckInputFile(filePath As String)
        If String.IsNullOrEmpty(filePath) Then Throw New FileNotFoundException("Path to file is empty")
        If Not File.Exists(filePath) Then Throw New FileNotFoundException($"Path '{filePath}' does not exist")
    End Sub
End Class