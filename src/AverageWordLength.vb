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


        Console.WriteLine("Application configured.")
    End Sub
End Class
