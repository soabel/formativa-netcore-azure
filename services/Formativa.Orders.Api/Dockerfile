#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["services/Formativa.Users.Api/Formativa.Orders.Api/Formativa.Orders.Api.csproj", "services/Formativa.Users.Api/Formativa.Orders.Api/"]
RUN dotnet restore "services/Formativa.Users.Api/Formativa.Orders.Api/Formativa.Orders.Api.csproj"
COPY . .
WORKDIR "/src/services/Formativa.Users.Api/Formativa.Orders.Api"
RUN dotnet build "Formativa.Orders.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Formativa.Orders.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Formativa.Orders.Api.dll"]
