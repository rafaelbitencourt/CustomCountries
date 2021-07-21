# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY CustomCountries.API/*.csproj CustomCountries.API/
#COPY libfoo/*.csproj libfoo/
#COPY libbar/*.csproj libbar/
RUN dotnet restore CustomCountries.API/CustomCountries.API.csproj

# copy and build app and libraries
COPY CustomCountries.API/ CustomCountries.API/
#COPY libfoo/ libfoo/
#COPY libbar/ libbar/
WORKDIR /source/CustomCountries.API
RUN dotnet build -c release --no-restore

# test stage -- exposes optional entrypoint
# target entrypoint with: docker build --target test
FROM build AS test
WORKDIR /source/tests
COPY CustomCountries.Test/ .
ENTRYPOINT ["dotnet", "test", "--logger:trx"]

FROM build AS publish
RUN dotnet publish -c release --no-build -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CustomCountries.API.dll"]
