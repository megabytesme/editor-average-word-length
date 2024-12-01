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

        Dim words = text.Split(" "c)
        Dim totalLength = words.Sum(Function(word) word.Length)
        Dim averageLength = totalLength / words.Length

        Dim result = New With {Key .average_word_length = averageLength.ToString("F2")}
        Dim jsonResult = JsonSerializer.Serialize(result)
        Response.ContentLength = jsonResult.Length

        Return Ok(jsonResult)
    End Function
End Class
