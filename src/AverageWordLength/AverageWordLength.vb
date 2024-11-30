Imports Microsoft.Extensions.DependencyInjection
Imports System.Net
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.AspNetCore.Http
Imports Microsoft.Extensions.Hosting

Public Class Startup
    Public Sub ConfigureServices(services As IServiceCollection)
    End Sub

    Public Sub Configure(app As IApplicationBuilder, env As IWebHostEnvironment)
        Console.WriteLine("Configuring application...")

        If env.IsDevelopment() Then
            Console.WriteLine("Development environment detected.")
            app.UseDeveloperExceptionPage()
        End If

        app.Run(Async Function(context)
                    Dim text = context.Request.Query("text").ToString()

                    If String.IsNullOrEmpty(text) Then
                        Console.WriteLine("Missing 'text' query parameter.")
                        context.Response.StatusCode = 400
                        Await context.Response.WriteAsync("{""error"": ""text query parameter is required""}")
                        Exit Function
                    End If

                    Console.WriteLine($"Received text: {text}")
                    Dim words = text.Split(" "c)
                    Dim totalLength = words.Sum(Function(word) word.Length)
                    Dim averageLength = totalLength / words.Length

                    Console.WriteLine($"Calculated average word length: {averageLength:F2}")
                    context.Response.ContentType = "application/json"
                    Await context.Response.WriteAsync("{""average_word_length"": " & averageLength.ToString("F2") & "}")
                End Function)

        Console.WriteLine("Application configured.")
    End Sub
End Class
