#!/bin/bash

#clean up
#--------
docker rmi web
docker rmi api

#Build Web
#---------
docker build --build-arg CACHE_DATE="$(date)" -t web Web/

#Build API
#---------
docker build --build-arg CACHE_DATE="$(date)" -t api API/Balance
