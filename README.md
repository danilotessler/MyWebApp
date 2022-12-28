# MyWebApp
Test a .Net core Website and Restfull API running in docker and kubernetes.

1 - build_projects.sh -> Build and prepare the binaries for release (Web and Balance API)
2 - build_images.sh -> Using the binaries created by build_projects.sh create a docker image for the website (web) and one for the Balance API (api)
3 - deploy_env.sh -> Assuming you have a K8s cluster or a local K8s deployment (minikube) deploye the necessary infraestructure and expose the website at port 30000 

