kubectl delete svc --all -n pitstop
kubectl delete deploy --all -n pitstop

kubectl delete svc --all -n monitoring
kubectl delete deploy --all -n monitoring
kubectl delete configmap --all -n monitoring