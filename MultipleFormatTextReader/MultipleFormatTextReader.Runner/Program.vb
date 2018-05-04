Imports System.IO

Module Program
    Sub Main(args As String())

        Dim resultCollection As New List(Of TradeItem)

        Dim jsonReader As New JsonReader()
        Try
            resultCollection.AddRange(jsonReader.LoadData(Path.Combine(Environment.CurrentDirectory, "Resources", "data001.json")))
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Dim xmlReader As New XmlReader()
        Try
            resultCollection.AddRange(xmlReader.LoadData(Path.Combine(Environment.CurrentDirectory, "Resources", "data002.xml")))
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Dim csvReader As New CsvReader()
        resultCollection.AddRange(csvReader.LoadData(Path.Combine(Environment.CurrentDirectory, "Resources", "data003.csv")))

        Dim tsvReader As New TsvReader()
        Try
            resultCollection.AddRange(tsvReader.LoadData(Path.Combine(Environment.CurrentDirectory, "Resources", "data004.tsv")))
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        resultCollection.ToList().ForEach(Sub(a As TradeItem) Console.WriteLine($"{a.Id} {a.Name} {a.Price} {a.Amount}"))

        Console.ReadKey()
    End Sub
End Module
