FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pig-n-Go/Pig-n-Go.csproj", "Pig-n-Go/"]
RUN dotnet restore "Pig-n-Go/Pig-n-Go.csproj"
COPY . .
WORKDIR "/src/Pig-n-Go"
RUN dotnet build "Pig-n-Go.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pig-n-Go.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pig-n-Go.dll"]
