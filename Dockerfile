# Step 1: Build stage using .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution and project files into the container
COPY ["TennisPlayers.sln", "./"]
COPY ["TennisPlayers/TennisPlayers.csproj", "TennisPlayers/"]
COPY ["TennisPlayers.Application/TennisPlayers.Application.csproj", "TennisPlayers.Application/"]
COPY ["TennisPlayers.Domain/TennisPlayers.Domain.csproj", "TennisPlayers.Domain/"]
COPY ["TennisPlayers.Infrastructure/TennisPlayers.Infrastructure.csproj", "TennisPlayers.Infrastructure/"]
COPY ["TennisPlayers.UnitTests/TennisPlayers.UnitTests.csproj", "TennisPlayers.UnitTests/"]
COPY ["TennisPlayers.Infrastructure/headtohead.json", "TennisPlayers.Infrastructure/"]

# Restore all dependencies for the solution
RUN dotnet restore "TennisPlayers.sln"

# Copy the entire source code into the container
COPY . .

# Step 2: Publish the application (main project)
RUN dotnet publish "TennisPlayers/TennisPlayers.csproj" -c Release -o /app/publish

# Step 3: Final image for running the app using the .NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Set the entry point for running the application
ENTRYPOINT ["dotnet", "TennisPlayers.dll"]
