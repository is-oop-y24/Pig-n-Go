FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DriverClient/DriverClient.csproj", "DriverClient/"]
RUN dotnet restore "DriverClient/DriverClient.csproj"
COPY . .
WORKDIR "/src/DriverClient"
RUN dotnet build "DriverClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DriverClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DriverClient.dll"]
