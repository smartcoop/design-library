
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Smart.Design.Console/Smart.Design.Console.csproj", "src/Smart.Design.Console/"]
COPY ["src/Smart.Design.RazorView/Smart.Design.RazorView.csproj", "src/Smart.Design.RazorView/"]
COPY ["src/Smart.Design.Razor/Smart.Design.Razor.csproj", "src/Smart.Design.Razor/"]
RUN dotnet restore "src/Smart.Design.Console/Smart.Design.Console.csproj"
COPY . .
WORKDIR "/src/src/Smart.Design.Console"
RUN dotnet build "Smart.Design.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Smart.Design.Console.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Smart.Design.Console.dll"]
