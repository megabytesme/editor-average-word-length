Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Public Class Program
    Public Shared Sub Main(args As String())
        CreateHostBuilder(args).Build().Run()
    End Sub

    Public Shared Function CreateHostBuilder(args As String()) As IHostBuilder
        Return Host.CreateDefaultBuilder(args) _
            .ConfigureWebHostDefaults(Sub(webBuilder)
                                          webBuilder.ConfigureServices(Sub(services)
                                                                           services.AddControllers()
                                                                           services.AddCors(Function(options)
                                                                                               options.AddDefaultPolicy(Sub(builder)
                                                                                                                            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                                                                                                                        End Sub)
                                                                                           End Function)
                                                                       End Sub) _
                                                   .Configure(Sub(app)
                                                                  Dim env = app.ApplicationServices.GetService(Of IWebHostEnvironment)()
                                                                  If env.IsDevelopment() Then
                                                                      app.UseDeveloperExceptionPage()
                                                                  End If

                                                                  app.UseRouting()
                                                                  app.UseCors()
                                                                  app.UseEndpoints(Sub(endpoints)
                                                                                       endpoints.MapControllers()
                                                                                   End Sub)
                                                              End Sub)
                                      End Sub)
    End Function
End Class
