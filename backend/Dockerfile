FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY . .

RUN dotnet restore Api/backend.sln --disable-parallel
RUN dotnet publish Api/backend.sln -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
RUN apt-get -y update
RUN apt-get install -y ffmpeg

EXPOSE 5077

ENTRYPOINT ["dotnet", "API.dll"]