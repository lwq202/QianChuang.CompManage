#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["QianChuang.CompManage/QianChuang.CompManage.csproj", "QianChuang.CompManage/"]
COPY ["QianChuang.CompManage.DataAccess/QianChuang.CompManage.DataAccess.csproj", "QianChuang.CompManage.DataAccess/"]
COPY ["QianChuang.CompManage.Model/QianChuang.CompManage.Model.csproj", "QianChuang.CompManage.Model/"]
COPY ["QianChuang.CompManage.ViewModel/QianChuang.CompManage.ViewModel.csproj", "QianChuang.CompManage.ViewModel/"]
COPY ["QianChuang.CompManage.Helper/QianChuang.CompManage.Helper.csproj", "QianChuang.CompManage.Helper/"]
RUN dotnet restore "QianChuang.CompManage/QianChuang.CompManage.csproj"
COPY . .
WORKDIR "/src/QianChuang.CompManage"
RUN dotnet build "QianChuang.CompManage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QianChuang.CompManage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QianChuang.CompManage.dll"]