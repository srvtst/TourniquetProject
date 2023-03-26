FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
EXPOSE 80

COPY ./Core/Tourniquet.Domain/*.csproj ./Core/Tourniquet.Domain/
COPY ./Core/Tourniquet.Application/.*csproj ./Core/Tourniquet.Application/
COPY ./Infrastructure/Tourniquet.Infrastructure/.*csproj ./Infrastructure/Tourniquet.Infrastructure/
COPY ./Infrastructure/Tourniquet.Persistence/*.csproj ./Infrastructure/Tourniquet.Persistence/
COPY ./Presentation/Tourniquet.API/*.csproj ./Presentation/Tourniquet.API/
COPY *.sln .
RUN dotnet Restore
COPY . .

RUN dotnet publish ./Presentation/Tourniquet.API/*.csproj -c Release -o /publish
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT [ "dotnet","Tourniquet.API.dll" ]