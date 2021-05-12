#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["gateway/Formativa.Gateway.Api/Formativa.Gateway.Api.csproj", "gateway/Formativa.Gateway.Api/"]
RUN dotnet restore "gateway/Formativa.Gateway.Api/Formativa.Gateway.Api.csproj"
COPY . .
WORKDIR "/src/gateway/Formativa.Gateway.Api"
RUN dotnet build "Formativa.Gateway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Formativa.Gateway.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Formativa.Gateway.Api.dll"]
