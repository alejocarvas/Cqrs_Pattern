#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["API_Query/API_Query.csproj", "API_Query/"]
RUN dotnet restore "API_Query/API_Query.csproj"
COPY . .
WORKDIR "/src/API_Query"
RUN dotnet build "API_Query.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_Query.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_Query.dll"]