FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

COPY . .
WORKDIR /app/modules/Investors/Kis.Investors.WebHost
RUN dotnet publish -o publish

FROM microsoft/dotnet:2.1-aspnetcore-runtime  AS runtime
WORKDIR /app
COPY --from=build /app/modules/Investors/Kis.Investors.WebHost/publish ./
ENTRYPOINT [ "dotnet", "Kis.Investors.WebHost.dll" ]