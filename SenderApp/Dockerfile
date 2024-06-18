FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SenderApp/SenderApp.csproj", "SenderApp/"]
COPY ["SenderReceiverLib/SenderReceiverLib.csproj", "SenderReceiverLib/"]
RUN dotnet restore "SenderApp/SenderApp.csproj"
COPY . .
WORKDIR "/src/SenderApp"
RUN dotnet build "SenderApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SenderApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SenderApp.dll"]
