Public Class XmlReader
    Inherits DataReader

    Public Overrides Function LoadData(filePath As String) As IEnumerable(Of TradeItem)
        CheckInputFile(filePath)

        Dim document = XDocument.Load(filePath)
        Dim rootNode = document.Root
        Return rootNode.Descendants("item").Select(Function(item) As TradeItem
            IncrementIdHolder()
            Dim b =
                    Function() _
                    New TradeItem _
                    With { .Id = IdHolder, 
                    .Name = item.Element("name").Value.ToString(),
                    .Price = Convert.ToDecimal(item.Element("price").Value),
                    .Amount = Convert.ToDecimal(item.Element("amount").Value) }
            Return b.Invoke()
        End Function)
    End Function
End Class