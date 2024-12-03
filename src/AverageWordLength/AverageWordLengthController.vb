Imports Microsoft.AspNetCore.Mvc
Imports System.Text.Json

<ApiController>
<Route("average-word-length")>
Public Class AverageWordLengthController
    Inherits ControllerBase

    <HttpGet>
    Public Function GetAverageWordLength(<FromQuery> text As String) As IActionResult
        If String.IsNullOrEmpty(text) Then
            Return BadRequest(New With {Key .error = "text query parameter is required"})
        End If

        Dim words = text.Split(" "c, StringSplitOptions.RemoveEmptyEntries)
        Dim totalLength = words.Sum(Function(word) word.Length)
        Dim averageLength = totalLength / words.Length

        Dim result = New With {Key .average_word_length = averageLength.ToString("F2")}
        Dim jsonResponse = JsonSerializer.Serialize(result)

        Response.ContentType = "application/json"
        Response.ContentLength = jsonResponse.Length

        Return Content(jsonResponse)
    End Function
End Class
