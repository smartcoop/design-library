FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Smart.CFA.Pages/Smart.CFA.Pages.csproj", "src/Smart.CFA.Pages/"]
RUN dotnet restore "src/Smart.CFA.Pages/Smart.CFA.Pages.csproj"
COPY . .
WORKDIR "/src/src/Smart.CFA.Pages"
RUN dotnet build "Smart.CFA.Pages.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Smart.CFA.Pages.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Smart.CFA.Pages.dll"]
