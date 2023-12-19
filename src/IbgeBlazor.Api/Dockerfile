#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/IbgeBlazor.Api/IbgeBlazor.Api.csproj", "src/IbgeBlazor.Api/"]
COPY ["src/IbgeBlazor.Core/IbgeBlazor.Core.csproj", "src/IbgeBlazor.Core/"]
COPY ["src/IbgeBlazor.Application/IbgeBlazor.Application.csproj", "src/IbgeBlazor.Application/"]
COPY ["src/IbgeBlazor.Infraestructure.CrossCutting/IbgeBlazor.Infraestructure.CrossCutting.csproj", "src/IbgeBlazor.Infraestructure.CrossCutting/"]
COPY ["src/IbgeBlazor.Infraestructure/IbgeBlazor.Infraestructure.csproj", "src/IbgeBlazor.Infraestructure/"]
RUN dotnet restore "./src/IbgeBlazor.Api/./IbgeBlazor.Api.csproj"
COPY . .
WORKDIR "/src/src/IbgeBlazor.Api"
RUN dotnet build "./IbgeBlazor.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IbgeBlazor.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IbgeBlazor.Api.dll"]