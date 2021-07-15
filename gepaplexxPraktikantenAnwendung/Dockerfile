#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["gepaplexxPraktikantenAnwendung.csproj", "gepaplexxPraktikantenAnwendung/"]
RUN dotnet restore "gepaplexxPraktikantenAnwendung/gepaplexxPraktikantenAnwendung.csproj"
COPY . .
WORKDIR "/src/gepaplexxPraktikantenAnwendung"
RUN dotnet build "gepaplexxPraktikantenAnwendung.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gepaplexxPraktikantenAnwendung.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gepaplexxPraktikantenAnwendung.dll"]