FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /app
COPY bin/Debug/netcoreapp3.1 /app
EXPOSE 8000

ENTRYPOINT /bin/bash -c "dotnet service.dll"