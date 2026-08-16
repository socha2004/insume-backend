FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia só o csproj primeiro para aproveitar cache de camadas do Docker
COPY *.csproj ./
RUN dotnet restore

# Agora copia o restante do projeto (Api, Application, Domain, Infraestructure etc.)
COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "insume-backend.dll"]