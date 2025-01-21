# Use the official .NET 8.0 runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the .NET 8.0 SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /

# Copy solution file and restore dependencies
COPY ["TennisPlayers.sln", "./"]
COPY ["TennisPlayers.Application/TennisPlayers.Application.csproj", "TennisPlayers.Application/"]
COPY ["TennisPlayers.Infrastructure/TennisPlayers.Infrastructure.csproj", "TennisPlayers.Infrastructure/"]
COPY ["TennisPlayers.Domain/TennisPlayers.Domain.csproj", "TennisPlayers.Domain/"]
COPY ["TennisPlayers.UnitTests/TennisPlayers.UnitTests.csproj", "TennisPlayers.UnitTests/"]
RUN dotnet restore

# Copy the rest of the app and build it
COPY . .
WORKDIR "/TennisPlayers"
RUN dotnet build -c Release -o /app/build

# Publish the app to a runtime image
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TennisPlayers.dll"]
