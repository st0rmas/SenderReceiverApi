FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ReceiverApp/ReceiverApp.csproj", "ReceiverApp/"]
COPY ["SenderReceiverLib/SenderReceiverLib.csproj", "SenderReceiverLib/"]
RUN dotnet restore "ReceiverApp/ReceiverApp.csproj"
COPY . .
WORKDIR "/src/ReceiverApp"
RUN dotnet build "ReceiverApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ReceiverApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReceiverApp.dll"]
