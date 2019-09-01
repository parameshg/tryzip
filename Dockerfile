FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

# Copy Projects
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Zip.Domain/Zip.Domain.csproj", "Zip.Domain/"]
COPY ["Zip.Database/Zip.Database.csproj", "Zip.Database/"]
COPY ["Zip.Business/Zip.Business.csproj", "Zip.Business/"]
COPY ["Zip.Api/Zip.Api.csproj", "Zip.Api/"]

# Restore Projects
RUN dotnet restore "Zip.Domain/Zip.Domain.csproj"
RUN dotnet restore "Zip.Database/Zip.Database.csproj"
RUN dotnet restore "Zip.Business/Zip.Business.csproj"
RUN dotnet restore "Zip.Api/Zip.Api.csproj"
COPY . .

# Build Projects
WORKDIR "/src/Zip.Api"
RUN dotnet build "Zip.Api.csproj" -c Release -o /app

# Publish Binaries
FROM build AS publish
RUN dotnet publish "Zip.Api.csproj" -c Release -o /app

# Copy Binaries
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Zip.Api.dll"]
