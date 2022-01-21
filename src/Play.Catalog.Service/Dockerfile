FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["src/Play.Catalog.Service/Play.Catalog.Service.csproj", "src/Play.Catalog.Service/"]
RUN dotnet restore "src/Play.Catalog.Service/Play.Catalog.Service.csproj"
COPY . .
WORKDIR "/src/src/Play.Catalog.Service"
RUN dotnet build "Play.Catalog.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Play.Catalog.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Play.Catalog.Service.dll"]
