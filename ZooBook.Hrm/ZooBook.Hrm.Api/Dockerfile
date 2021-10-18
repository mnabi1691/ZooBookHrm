#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ZooBook.Hrm.Api/ZooBook.Hrm.Api.csproj", "ZooBook.Hrm.Api/"]
COPY ["ZooBook.Hrm.Persistence/ZooBook.Hrm.Persistence.csproj", "ZooBook.Hrm.Persistence/"]
COPY ["ZooBook.Hrm.Configuration/ZooBook.Hrm.Configuration.csproj", "ZooBook.Hrm.Configuration/"]
COPY ["ZooBook.Hrm.Application/ZooBook.Hrm.Application.csproj", "ZooBook.Hrm.Application/"]
COPY ["ZooBook.Hrm.Domain/ZooBook.Hrm.Domain.csproj", "ZooBook.Hrm.Domain/"]
RUN dotnet restore "ZooBook.Hrm.Api/ZooBook.Hrm.Api.csproj"
COPY . .
WORKDIR "/src/ZooBook.Hrm.Api"
RUN dotnet build "ZooBook.Hrm.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZooBook.Hrm.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZooBook.Hrm.Api.dll"]