# Basic
## Requirements
- Kubernetes
## Start development
```
kubectl apply -k .\kubernetes\environments\development\
```
## Clean up
```
kubectl delete ns kaewsai-sync
```

# Todo next
- Setup vault, might be Hashicorp vault
- Use secret from vault
- Setup MongoDb volume
# MongoDb
Can be access through
```
host: localhost:30000
username: kaewsai
password: Kaewsai123
```