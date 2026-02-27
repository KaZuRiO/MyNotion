FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend.sln", "backend.sln"]
COPY ["backend.API/backend.API.csproj", "backend.API/backend.API.csproj"]
COPY ["backend.Applications/backend.Applications.csproj", "backend.Applications/backend.Applications.csproj"]
COPY ["backend.Domain/backend.Domain.csproj", "backend.Domain/backend.Domain.csproj"]
COPY ["backend.Infrastructure/backend.Infrastructure.csproj", "backend.Infrastructure/backend.Infrastructure.csproj"]
RUN dotnet restore "./backend.sln"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./backend.sln" -c $BUILD_CONFIGURATION -o /app/build


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dev
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
dotnet watch "backend.sln" --project "backend.API"

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./backend.sln" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend.API.dll"]
