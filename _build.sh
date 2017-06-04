#!/usr/bin/env bash

error() {
  echo ">>>>>> Failed to compile <<<<<<<<<"
  echo ""

  exit 1
}

trap error ERR

dotnet restore
dotnet build
dotnet publish 