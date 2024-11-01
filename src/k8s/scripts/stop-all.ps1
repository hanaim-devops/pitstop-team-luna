kubectl delete svc --all -n pitstop
kubectl delete deploy --all -n pitstop
kubectl delete virtualservice --all -n pitstop
kubectl delete destinationrule --all -n pitstop

kubectl delete svc --all -n monitoring
kubectl delete deploy --all -n monitoring
kubectl delete virtualservice --all -n monitoring
kubectl delete destinationrule --all -n monitoring