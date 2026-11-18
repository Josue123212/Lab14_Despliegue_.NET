# Etapa 1: Build y Publish
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Lab10_JosueChoquepuma.sln", "./"]
COPY ["Lab10.Domain/Lab10.Domain.csproj", "Lab10.Domain/"]
COPY ["Lab10.Application/Lab10.Application.csproj", "Lab10.Application/"]
COPY ["Lab10.Infrastructure/Lab10.Infrastructure.csproj", "Lab10.Infrastructure/"]
COPY ["Lab10.Api/Lab10.Api.csproj", "Lab10.Api/"]

RUN dotnet restore "Lab10.Api/Lab10.Api.csproj"

COPY . .
RUN dotnet publish "Lab10.Api/Lab10.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Lab10.Api.dll"]
