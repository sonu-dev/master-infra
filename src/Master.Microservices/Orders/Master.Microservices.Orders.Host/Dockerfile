#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Master.Microservices/Orders/Master.Microservices.Orders.Host/Master.Microservices.Orders.Host.csproj", "Master.Microservices/Orders/Master.Microservices.Orders.Host/"]
COPY ["Master.Microservices/Orders/Master.Microservices.Orders/Master.Microservices.Orders.csproj", "Master.Microservices/Orders/Master.Microservices.Orders/"]
COPY ["Master.Microservices/Orders/Master.Microservices.Orders.DataAccess/Master.Microservices.Orders.DataAccess.csproj", "Master.Microservices/Orders/Master.Microservices.Orders.DataAccess/"]
COPY ["Master.Microservices/Common/Master.Microservices.Common/Master.Microservices.Common.csproj", "Master.Microservices/Common/Master.Microservices.Common/"]
RUN dotnet restore "Master.Microservices/Orders/Master.Microservices.Orders.Host/Master.Microservices.Orders.Host.csproj"
COPY . .
WORKDIR "/src/Master.Microservices/Orders/Master.Microservices.Orders.Host"
RUN dotnet build "Master.Microservices.Orders.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Master.Microservices.Orders.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Master.Microservices.Orders.Host.dll"]