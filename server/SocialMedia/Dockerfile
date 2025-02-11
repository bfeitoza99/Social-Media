FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY *.sln ./
COPY SocialMedia.API/*.csproj SocialMedia.API/
COPY SocialMedia.Application/*.csproj SocialMedia.Application/
COPY SocialMedia.CrossCutting/*.csproj SocialMedia.CrossCutting/
COPY SocialMedia.Domain/*.csproj SocialMedia.Domain/
COPY SocialMedia.Infrastructure/*.csproj SocialMedia.Infrastructure/
COPY SocialMedia.Tests/*.csproj SocialMedia.Tests/

RUN dotnet restore

COPY . .
WORKDIR /source/SocialMedia.API
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "SocialMedia.API.dll"]
