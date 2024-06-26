FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln ./
COPY src/fcamara-test-dotnet.Api/*.csproj ./src/fcamara-test-dotnet.Api/
COPY src/fcamara-test-dotnet.Application/*.csproj ./src/fcamara-test-dotnet.Application/
COPY src/fcamara-test-dotnet.Contracts/*.csproj ./src/fcamara-test-dotnet.Contracts/
COPY src/fcamara-test-dotnet.Domain/*.csproj ./src/fcamara-test-dotnet.Domain/
COPY src/fcamara-test-dotnet.Infrastructure/*.csproj ./src/fcamara-test-dotnet.Infrastructure/
COPY src/fcamara-test-dotnet.Seeder/*.csproj ./src/fcamara-test-dotnet.Seeder/
COPY tests/fcamara-test-dotnet.Domain.Tests/*.csproj ./tests/fcamara-test-dotnet.Domain.Tests/
COPY tests/fcamara-test-dotnet.Application.Tests/*.csproj ./tests/fcamara-test-dotnet.Application.Tests/

RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "fcamara-test-dotnet.Api.dll"]