#!/bin/bash

#Build Web
#---------
cd Web
rm -r release
dotnet restore -r linux-x64 /p:PublishReadyToRun=true
dotnet publish -c Release -o release/ -r linux-x64 --self-contained true --no-restore /p:PublishReadyToRun=true # /p:PublishTrimmed=true /p:PublishSingleFile=true

#Build API
#---------
cd ../API/Balance
rm -r release
dotnet restore -r linux-x64 /p:PublishReadyToRun=true
dotnet publish -c Release -o release/ -r linux-x64 --self-contained true --no-restore /p:PublishReadyToRun=true # /p:PublishTrimmed=true /p:PublishSingleFile=true