Imports System.Runtime.CompilerServices
Imports System.Web.Mvc

Namespace HtmlHelpers
    Public Module PagingHelpers
        <Extension()>
        Public Function PageLinks(ByVal html As HtmlHelper, pagingInfo As PagingInfo, pageUrl As Func(Of Integer, string)) As MvcHtmlString
            Dim result As New StringBuilder()
            For i = 1 To pagingInfo.TotalPages
                Dim tag As New TagBuilder("a")
                tag.MergeAttribute("href", pageUrl(i))
                tag.InnerHtml = i.ToString()
                If (i = pagingInfo.CurrentPage)
                    tag.AddCssClass("selected")
                    tag.AddCssClass("btn-primary")
                End If
                tag.AddCssClass("btn btn-default")
                result.Append(tag.ToString())
            Next
            Return MvcHtmlString.Create(result.ToString())
        End Function
    End Module
End Namespace