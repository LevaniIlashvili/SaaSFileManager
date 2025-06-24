FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build	
WORKDIR /src

COPY *.sln .
COPY SaaSFileManager.Api/*.csproj ./SaaSFileManager.Api/
COPY SaaSFileManager.Application/*.csproj ./SaaSFileManager.Application/
COPY SaaSFileManager.Domain/*.csproj ./SaaSFileManager.Domain/
COPY SaaSFileManager.Infrastructure/*.csproj ./SaaSFileManager.Infrastructure/
COPY SaaSFileManager.Persistence/*.csproj ./SaaSFileManager.Persistence/

RUN dotnet restore

COPY . .

WORKDIR /src/SaaSFileManager.Api
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "SaaSFileManager.Api.dll"]