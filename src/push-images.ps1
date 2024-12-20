# Tag each image to go into the same repo but with a unique service-specific tag
docker tag pitstop/customermanagementapi:1.0 ghcr.io/hanaim-devops/pitstop-team-luna/customermanagementapi:1.0
docker tag pitstop/webapp:1.0 ghcr.io/hanaim-devops/pitstop-team-luna/webapp:1.0
docker tag pitstop/workshopmanagementeventhandler:1.0 ghcr.io/hanaim-devops/pitstop-team-luna/workshopmanagementeventhandler:1.0
docker tag pitstop/timeservice:1.0 ghcr.io/hanaim-devops/pitstop-team-luna/timeservice:1.0
docker tag pitstop/notificationservice:1.0 ghcr.io/hanaim-devops/pitstop-team-luna/notificationservice:1.0
docker tag pitstop/invoiceservice:1.0 ghcr.io/hanaim-devops/pitstop-team-luna/invoiceservice:1.0
docker tag pitstop/auditlogservice:1.0 ghcr.io/hanaim-devops/pitstop-team-luna/auditlogservice:1.0
docker tag pitstop/workshopmanagementapi:1.0 ghcr.io/hanaim-devops/pitstop-team-luna/workshopmanagementapi:1.0
docker tag pitstop/vehiclemanagementapi:1.0 ghcr.io/hanaim-devops/pitstop-team-luna/vehiclemanagementapi:1.0
docker tag pitstop/repairmanagementapi:1.0 ghcr.io/hanaim-devops/pitstop-team-luna/repairmanagementapi:1.0
docker tag pitstop/customersupportapi:1.0 ghcr.io/hanaim-devops/pitstop-team-luna/customersupportapi:1.0
docker tag pitstop/customersupportservice:1.0 ghcr.io/hanaim-devops/pitstop-team-luna/customersupportservice:1.0
docker tag cloudcustodian/c7n:latest ghcr.io/hanaim-devops/pitstop-team-luna/cloudcustodian:1.0

# Push all the tagged images to the same repo with different tags
docker push ghcr.io/hanaim-devops/pitstop-team-luna/customermanagementapi:1.0
docker push ghcr.io/hanaim-devops/pitstop-team-luna/webapp:1.0
docker push ghcr.io/hanaim-devops/pitstop-team-luna/workshopmanagementeventhandler:1.0
docker push ghcr.io/hanaim-devops/pitstop-team-luna/timeservice:1.0
docker push ghcr.io/hanaim-devops/pitstop-team-luna/notificationservice:1.0
docker push ghcr.io/hanaim-devops/pitstop-team-luna/invoiceservice:1.0
docker push ghcr.io/hanaim-devops/pitstop-team-luna/auditlogservice:1.0
docker push ghcr.io/hanaim-devops/pitstop-team-luna/workshopmanagementapi:1.0
docker push ghcr.io/hanaim-devops/pitstop-team-luna/vehiclemanagementapi:1.0
docker push ghcr.io/hanaim-devops/pitstop-team-luna/repairmanagementapi:1.0
docker push ghcr.io/hanaim-devops/pitstop-team-luna/customersupportapi:1.0
docker push ghcr.io/hanaim-devops/pitstop-team-luna/customersupportservice:1.0
docker push ghcr.io/hanaim-devops/pitstop-team-luna/cloudcustodian:1.0