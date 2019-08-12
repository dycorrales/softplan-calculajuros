FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /
COPY *.sln ./
COPY ["src/calculajuros.domain/calculajuros.domain.csproj", "calculajuros.domain/"]
COPY ["src/calculajuros.infra.services/calculajuros.infra.services.csproj", "calculajuros.infra.services/"]
COPY ["src/calculajuros.webapi/calculajuros.webapi.csproj", "calculajuros.webapi/"]
COPY . .


WORKDIR /src/calculajuros.domain
RUN dotnet restore

WORKDIR /src/calculajuros.infra.services
RUN dotnet restore

WORKDIR /src/calculajuros.webapi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "calculajuros.webapi.dll"]