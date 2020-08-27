#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Jaslah.JobCareerPk.UI/Jaslah.JobCareerPk.UI.csproj", "Jaslah.JobCareerPk.UI/"]
RUN dotnet restore "Jaslah.JobCareerPk.UI/Jaslah.JobCareerPk.UI.csproj"
COPY . .
WORKDIR "/src/Jaslah.JobCareerPk.UI"
RUN dotnet build "Jaslah.JobCareerPk.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jaslah.JobCareerPk.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jaslah.JobCareerPk.UI.dll"]