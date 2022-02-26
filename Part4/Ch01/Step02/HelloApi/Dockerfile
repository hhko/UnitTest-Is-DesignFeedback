FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["HelloApi/HelloApi.csproj", "HelloApi/"]
RUN dotnet restore "HelloApi/HelloApi.csproj"
COPY . .
WORKDIR "/src/HelloApi"
RUN dotnet build "HelloApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelloApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloApi.dll"]
