FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY Escola.sln ./
COPY Escola.API/Escola.API.csproj Escola.API/
COPY Escola.Application/Escola.Application.csproj Escola.Application/
COPY Escola.Domain/Escola.Domain.csproj Escola.Domain/
COPY Escola.Infra.Data/Escola.Infra.Data.csproj Escola.Infra.Data/
COPY Escola.Infra.Ioc/Escola.Infra.Ioc.csproj Escola.Infra.Ioc/

RUN dotnet restore Escola.sln

COPY . .
RUN dotnet publish Escola.API/Escola.API.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Escola.API.dll"]