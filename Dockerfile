FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

#COPY PROJECT FILES
COPY *.csproj ./
RUN dotnet restore

#COPY EVERYTHING ELSE
COPY . ./
RUN dotnet publish -c Release -o out

#Build image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "ProyectoCFP.dll" ]

ENV APP_NET_CORE ProyectoCFP.dll 

CMD ASPNETCORE_URLS=http://*:$PORT dotnet $APP_NET_CORE