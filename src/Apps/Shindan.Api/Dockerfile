#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apps/Shindan.Api/Shindan.Api.csproj", "src/Apps/Shindan.Api/"]
COPY ["src/Common/Shindan.Infrastructure/Shindan.Infrastructure.csproj", "src/Common/Shindan.Api.Infrastructure/"]
COPY ["src/Common/Shindan.Application/Shindan.Application.csproj", "src/Common/Shindan.Api.Application/"]
COPY ["src/Common/Shindan.Domain/Shindan.Domain.csproj", "src/Common/Shindan.Api.Domain/"]
RUN dotnet restore "src/Apps/Shindan.Api/Shindan.Api.csproj"
COPY . .
WORKDIR "/src/src/Apps/Shindan.Api"
RUN dotnet build "Shindan.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shindan.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shindan.Api.dll"]