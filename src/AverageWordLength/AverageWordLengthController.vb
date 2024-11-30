Imports Microsoft.AspNetCore.Mvc

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

        Return Ok(New With {Key .average_word_length = averageLength.ToString("F2")})
    End Function
End Class
