#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/RabbitMQ.AspNetCore.Publisher/RabbitMQ.AspNetCore.Publisher.csproj", "src/RabbitMQ.AspNetCore.Publisher/"]
COPY ["src/RabbitMQ.AspNetCore/RabbitMQ.AspNetCore.csproj", "src/RabbitMQ.AspNetCore/"]
RUN dotnet restore "./src/RabbitMQ.AspNetCore.Publisher/./RabbitMQ.AspNetCore.Publisher.csproj"
COPY . .
WORKDIR "/src/src/RabbitMQ.AspNetCore.Publisher"
RUN dotnet build "./RabbitMQ.AspNetCore.Publisher.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RabbitMQ.AspNetCore.Publisher.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RabbitMQ.AspNetCore.Publisher.dll"]