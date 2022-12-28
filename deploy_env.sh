#!/bin/bash

#clean old deployment
kubectl delete -f K8s/web.yaml
kubectl delete -f K8s/api_balance.yaml

# Point local deocker repo to minikube docker repo
eval $(minikube -p minikube docker-env)

#build images
./build_images.sh

#create deployment
kubectl apply -f K8s/web.yaml
kubectl apply -f K8s/api_balance.yaml
