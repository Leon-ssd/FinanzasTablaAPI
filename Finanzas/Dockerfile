# ~/Documentos/Finanzas/Finanzas/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0

WORKDIR /src

# Copiar el archivo de proyecto y restaurar dependencias primero (optimiza la caché de capas)
COPY ["Finanzas.csproj", "./"]
RUN dotnet restore "Finanzas.csproj"

# Copiar el resto del código fuente y compilar en /app/build
COPY . .
RUN dotnet build "Finanzas.csproj" -c Release -o /app/build

# Mover el directorio de trabajo a los binarios compilados
WORKDIR /app/build

# Puerto por defecto (se sobreescribirá dinámicamente mediante la variable de entorno PORT)
EXPOSE 8080

# Ejecutar la API compilada
ENTRYPOINT ["dotnet", "Finanzas.dll"]