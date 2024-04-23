#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Smart.Design.Library.Showcase.WebApp/Smart.Design.Library.Showcase.csproj", "src/Smart.Design.Library.Showcase.WebApp/"]
COPY ["src/Smart.Design.Library/Smart.Design.Library.csproj", "src/Smart.Design.Library/"]
RUN dotnet restore "src/Smart.Design.Library.Showcase.WebApp/Smart.Design.Library.Showcase.csproj" -s https://api.nuget.org/v3/index.json -s https://sam2.ubik.be/nugetserver/nuget
COPY . .
WORKDIR "/src/src/Smart.Design.Library.Showcase.WebApp"
RUN dotnet build "Smart.Design.Library.Showcase.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Smart.Design.Library.Showcase.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Smart.Design.Library.Showcase.dll"]
