# =========================
# Build
# =========================
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# Copiar solución (si existe)
COPY *.sln ./

# Copiar csproj (ajusta la ruta si es distinta)
COPY src/Api/*.csproj src/Api/

# Restaurar dependencias
RUN dotnet restore src/Api/Api.csproj

# Copiar el resto del código
COPY src/ src/

# Publicar SOLO la API
RUN dotnet publish src/Api/Api.csproj -c Release -o /app/publish

# =========================
# Runtime
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app

# Railway usa PORT dinámico
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Api.dll"]
