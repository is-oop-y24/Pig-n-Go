FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pig-n-Go.DriverClient/Pig-n-Go.DriverClient.csproj", "Pig-n-Go.DriverClient/"]
RUN dotnet restore "Pig-n-Go.DriverClient/Pig-n-Go.DriverClient.csproj"
COPY . .
WORKDIR "/src/Pig-n-Go.DriverClient"
RUN dotnet build "Pig-n-Go.DriverClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pig-n-Go.DriverClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pig-n-Go.DriverClient.dll"]
