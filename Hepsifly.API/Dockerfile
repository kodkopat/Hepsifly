# See https://aka.ms/customizecontainer for information on customizing the container.
# This Dockerfile builds the production container, which Visual Studio also uses for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Hepsifly.API/Hepsifly.API.csproj", "Hepsifly.API/"]
COPY ["Hepsifly.Core/Hepsifly.Core.csproj", "Hepsifly.Core/"]
COPY ["Hepsifly.Domain.Models/Hepsifly.Domain.Models.csproj", "Hepsifly.Domain.Models/"]
COPY ["Hepsifly.Domain.ViewModels/Hepsifly.Domain.ViewModels.csproj", "Hepsifly.Domain.ViewModels/"]
COPY ["Hepsifly.Domain/Hepsifly.Domain.csproj", "Hepsifly.Domain/"]
COPY ["Hepsifly.Infrastructure/Hepsifly.Infrastructure.csproj", "Hepsifly.Infrastructure/"]
RUN dotnet restore "Hepsifly.API/Hepsifly.API.csproj"
COPY . .
WORKDIR "/src/Hepsifly.API"
RUN dotnet build "Hepsifly.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hepsifly.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hepsifly.API.dll"]