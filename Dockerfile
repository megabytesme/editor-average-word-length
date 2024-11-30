FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY src/AverageWordLength/AverageWordLength.vbproj src/AverageWordLength/
WORKDIR /app/src/AverageWordLength
RUN dotnet restore

WORKDIR /app
COPY . ./
RUN dotnet publish src/AverageWordLength/AverageWordLength.vbproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "AverageWordLength.dll"]

EXPOSE 80
