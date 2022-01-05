FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pig-n-Go.PassengerClient/Pig-n-Go.PassengerClient.csproj", "Pig-n-Go.PassengerClient/"]
RUN dotnet restore "Pig-n-Go.PassengerClient/Pig-n-Go.PassengerClient.csproj"
COPY . .
WORKDIR "/src/Pig-n-Go.PassengerClient"
RUN dotnet build "Pig-n-Go.PassengerClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pig-n-Go.PassengerClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pig-n-Go.PassengerClient.dll"]
