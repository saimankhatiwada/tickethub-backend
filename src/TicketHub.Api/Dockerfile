FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 7000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TicketHub.Api/TicketHub.Api.csproj", "src/TicketHub.Api/"]
COPY ["src/TicketHub.Application/TicketHub.Application.csproj", "src/TicketHub.Application/"]
COPY ["src/TicketHub.Domain/TicketHub.Domain.csproj", "src/TicketHub.Domain/"]
COPY ["src/TicketHub.Infrastructure/TicketHub.Infrastructure.csproj", "src/TicketHub.Infrastructure/"]
RUN dotnet restore "./src/TicketHub.Api/./TicketHub.Api.csproj"
COPY . .
WORKDIR "/src/src/TicketHub.Api"
RUN dotnet build "./TicketHub.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TicketHub.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketHub.Api.dll"]