# =========================
# Build stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# Copiar solución
COPY EnterpriseSytem.sln ./

# Copiar csproj de la API
COPY src/Api/EnterpriseSytem.Api/EnterpriseSytem.Api.csproj src/Api/EnterpriseSytem.Api/

# Restaurar dependencias
RUN dotnet restore src/Api/EnterpriseSytem.Api/EnterpriseSytem.Api.csproj

# Copiar todo el código
COPY src/ src/

# Publicar SOLO la API
RUN dotnet publish src/Api/EnterpriseSytem.Api/EnterpriseSytem.Api.csproj -c Release -o /app/publish

# =========================
# Runtime stage
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "EnterpriseSytem.Api.dll"]