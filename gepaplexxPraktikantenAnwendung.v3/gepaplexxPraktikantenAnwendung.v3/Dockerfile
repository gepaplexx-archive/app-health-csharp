#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["gepaplexxPraktikantenAnwendung.v3/gepaplexxPraktikantenAnwendung.v3.csproj", "gepaplexxPraktikantenAnwendung.v3/"]
RUN dotnet restore "gepaplexxPraktikantenAnwendung.v3/gepaplexxPraktikantenAnwendung.v3.csproj"
COPY . .
WORKDIR "/src/gepaplexxPraktikantenAnwendung.v3"
RUN dotnet build "gepaplexxPraktikantenAnwendung.v3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gepaplexxPraktikantenAnwendung.v3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gepaplexxPraktikantenAnwendung.v3.dll"]