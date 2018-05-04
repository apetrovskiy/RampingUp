Imports System.IO
Imports Newtonsoft.Json

Public Class JsonReader
    Inherits DataReader

    Public Overrides Function LoadData(filePath As String) As IEnumerable(Of TradeItem)
        CheckInputFile(filePath)

        Dim resultCollection = JsonConvert.DeserializeObject (Of IEnumerable(Of TradeItem))(File.ReadAllText(filePath))
        resultCollection.ToList().ForEach(Sub(item As TradeItem)
            IncrementIdHolder()
            item.Id = IdHolder
        End Sub)
        Return resultCollection
    End Function
End Class