FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Hermes.Identity.csproj", "src/"]
RUN dotnet restore "src\Hermes.Identity.csproj"
COPY . .
WORKDIR "/src/src"
RUN dotnet build "Hermes.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hermes.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hermes.Identity.dll"]
