### Build Docker Image
This builds an image called `openpdc` from the local [`Dockerfile`](./Dockerfile) script:
```sh
docker build -t openpdc .
```

### Deploy and Run Docker Image to a Container
This deploys and runs docker image `openpdc` to a container called `opendc-test` and exposes container ports to local machine:
```sh
docker run -d --name openpdc-test -p 8280:8280 -p 7165:7165 -p 6175:6175 -p 8900:8900 openpdc
```

### Tag Docker Image
This tags the `openpdc` docker image as `gridprotectionalliance/openpdc:v2.9.148`, creating a copy of the image that can be pushed to [dockerhub](https://hub.docker.com/repository/docker/gridprotectionalliance/openpdc/general):
```sh
docker tag openpdc gridprotectionalliance/openpdc:v2.9.148
```

### Push Tagged Docker Image to dockerhub
This pushes the tagged image `gridprotectionalliance/openpdc:v2.9.148` to dockerhub:
```sh
docker push gridprotectionalliance/openpdc:v2.9.148
```

### Open Shell Session Into Running Container
This connects a shell session, like SSH, to to the running container called `openpdc-test`:
```sh
docker exec -it openpdc-test /bin/bash
```

### Run openPDC Console from Container Shell Session
This runs the openPDC Console application from the container shell session, credentials will need to be provided (see below):
```sh
mono openPDCConsole.exe
```

### Open Web Interface
The following URL will open the openPDC web management interface for a container listening on 8280, credentials will need to be provided (see below):

http://localhost:8280/


### Default Credentials
* username: `.\admin`
* password: `admin`

