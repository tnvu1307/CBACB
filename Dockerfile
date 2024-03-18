FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 443

RUN apk update
RUN apk add curl
RUN apk add nano

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
RUN dotnet dev-certs https -ep /app/aspnetapp.pfx -p fss
RUN dotnet dev-certs https --trust

WORKDIR /src
COPY HOSTService/HOSTService.vbproj HOSTService/
RUN dotnet restore "HOSTService/HOSTService.vbproj"
COPY . .
WORKDIR "/src/HOSTService"
RUN dotnet build "HOSTService.vbproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HOSTService.vbproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .


ENTRYPOINT ["dotnet", "HOSTService.dll"]