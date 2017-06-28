#!/usr/bin/env bash

error() {
  echo ">>>>>> Failed to compile <<<<<<<<<"
  echo ""

  exit 1
}

trap error ERR

cd src
cd lib

dotnet restore 
dotnet build 
dotnet pack 