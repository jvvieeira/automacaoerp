# Etapa 1: Construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY . .

# Restaurar as dependências e compilar o projeto
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Etapa 2: Configurar a imagem final
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "AutomacaoERP.API.dll"]
