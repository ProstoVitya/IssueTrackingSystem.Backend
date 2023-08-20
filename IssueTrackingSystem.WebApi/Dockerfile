FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IssueTrackingSystem.WebApi/IssueTrackingSystem.WebApi.csproj", "IssueTrackingSystem.WebApi/"]
RUN dotnet restore "IssueTrackingSystem.WebApi/IssueTrackingSystem.WebApi.csproj"
COPY . .
WORKDIR "/src/IssueTrackingSystem.WebApi"
RUN dotnet build "IssueTrackingSystem.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IssueTrackingSystem.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IssueTrackingSystem.WebApi.dll"]
