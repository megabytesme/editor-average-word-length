Imports System.Net
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Mvc.Testing
Imports Newtonsoft.Json.Linq
Imports NUnit.Framework

<TestFixture>
Public Class StartupTests
    Private _factory As WebApplicationFactory(Of AverageWordLength.Startup)

    <SetUp>
    Public Sub SetUp()
        _factory = New WebApplicationFactory(Of AverageWordLength.Startup)()
    End Sub

    <TearDown>
    Public Sub TearDown()
        _factory.Dispose()
    End Sub

    <Test>
    <TestCase("?text=Hello world", 5)>
    Public Async Function Get_AverageWordLength_ReturnsSuccess_AndResult(query As String, expected As Double) As Task
        ' Arrange
        Dim client = _factory.CreateClient()

        ' Act
        Dim response = Await client.GetAsync("/" & query)
        Dim content = Await response.Content.ReadAsStringAsync()
        Dim jsonResponse = JObject.Parse(content)
        Dim averageWordLength = jsonResponse("average_word_length").Value(Of Double)()

        ' Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode)
        Assert.AreEqual("application/json", response.Content.Headers.ContentType.ToString())
        Assert.AreEqual(expected, averageWordLength)
    End Function

    <Test>
    <TestCase("")>
    Public Async Function Get_AverageWordLength_MissingTextParameter_ReturnsBadRequest(query As String) As Task
        ' Arrange
        Dim client = _factory.CreateClient()

        ' Act
        Dim response = Await client.GetAsync("/" & query)

        ' Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode)
    End Function
End Class
