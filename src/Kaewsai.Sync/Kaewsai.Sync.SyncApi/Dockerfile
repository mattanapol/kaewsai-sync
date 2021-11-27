FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=https://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["src/Kaewsai.Sync/Kaewsai.Sync.SyncApi/Kaewsai.Sync.SyncApi.csproj", "src/Kaewsai.Sync/Kaewsai.Sync.SyncApi/"]
COPY ["src/Kaewsai.Sync/Kaewsai.Sync.SyncApi.Domain/Kaewsai.Sync.SyncApi.Domain.csproj", "src/Kaewsai.Sync/Kaewsai.Sync.SyncApi.Domain/"]
RUN dotnet restore "src/Kaewsai.Sync/Kaewsai.Sync.SyncApi/Kaewsai.Sync.SyncApi.csproj"
COPY . .
WORKDIR "/src/src/Kaewsai.Sync/Kaewsai.Sync.SyncApi"
RUN dotnet build "Kaewsai.Sync.SyncApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kaewsai.Sync.SyncApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kaewsai.Sync.SyncApi.dll"]
