FROM microsoft/aspnetcore:1.1
WORKDIR /app
COPY bin/Debug/netcoreapp1.1/publish /app
EXPOSE 8005

ENTRYPOINT /bin/bash -c "dotnet service.dll"