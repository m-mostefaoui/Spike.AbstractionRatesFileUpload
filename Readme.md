# Spike Abstraction for rates files upload


### Create Persistent Disk in Google Compute Engine

```
gcloud compute disks create --size=10GB --zone=europe-west2-a gce-nfs-disk
```

### Create NFS Server in GKE

```
kubectl apply -f 001-nfs-server.yaml
```

### Create NFS Service

```
kubectl apply -f 002-nfs-server-service.yaml
```

### Create Persistent Volume and Persistent Volume Claims

```
kubect apply -f 003-pv-pvc.yaml
```