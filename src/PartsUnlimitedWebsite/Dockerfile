#FROM microsoft/aspnetcore:1.0.5
#WORKDIR /app
#EXPOSE 80
#COPY bin/Debug/netcoreapp1.0/publish /app
#ENTRYPOINT ["dotnet", "PartsUnlimitedWebsite.dll"]


FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
EXPOSE 80
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PartsUnlimitedWebsite.dll"]