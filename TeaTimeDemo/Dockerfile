#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TeaTimeDemo/TeaTimeDemo.csproj", "TeaTimeDemo/"]
COPY ["TeaTimeDemo.DataAccess/TeaTimeDemo.DataAccess.csproj", "TeaTimeDemo.DataAccess/"]
COPY ["TeaTimeDemo.Models/TeaTimeDemo.Models.csproj", "TeaTimeDemo.Models/"]
COPY ["TeaTimeDemo.Utility/TeaTimeDemo.Utility.csproj", "TeaTimeDemo.Utility/"]
RUN dotnet restore "./TeaTimeDemo/TeaTimeDemo.csproj"
COPY . .
WORKDIR "/src/TeaTimeDemo"
RUN dotnet build "./TeaTimeDemo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TeaTimeDemo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeaTimeDemo.dll"]






FROM mcr.microsoft.com/mssql/server:2022-latest

USER root

RUN chown -R mssql:mssql /opt/mssql

USER mssql

ENV ACCEPT_EULA=Y

ENV SA_PASSWORD=P@ssw0rd

ENV MSSQL_PID=Developer

EXPOSE 1433
