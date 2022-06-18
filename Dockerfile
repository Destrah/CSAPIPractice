FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CSAPIPractice.csproj", "./"]
RUN dotnet restore "CSAPIPractice.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CSAPIPractice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSAPIPractice.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSAPIPractice.dll"]
