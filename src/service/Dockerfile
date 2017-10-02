FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY bin/Debug/netcoreapp2.0/publish /app
EXPOSE 8081

ENTRYPOINT /bin/bash -c "dotnet service.dll"
