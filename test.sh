#!/usr/bin/env bash

error() {

  echo ">>>>>> Failed to build <<<<<<<<<"
  echo ""

  exit 1
}

cleanup() {

  docker-compose --project-name httpstub stop
  docker-compose --project-name httpstub rm -f

  docker run -v /var/run/docker.sock:/var/run/docker.sock -v /var/lib/docker:/var/lib/docker --rm martin/docker-cleanup-volumes
}

trap error ERR
trap cleanup EXIT

if [ -z "$GO_PIPELINE_COUNTER" ]; then
    export GO_PIPELINE_COUNTER=0
fi

if [ -z "$GO_STAGE_COUNTER" ]; then
    export GO_STAGE_COUNTER=0
fi

echo
echo =============================================================================
echo Testing Http stub 
echo =============================================================================
echo

echo Starting Stub server ...
echo

docker-compose build
docker-compose up -d stub

sleep 10

CURDIR=`pwd`

chmod -R 777 *.sh

DIR_NAME=`basename $PWD`
lower_dir_name=`echo ${DIR_NAME} | tr '[:upper:]' '[:lower:]' | tr -d '[:punct:]'`

NET_NAME=${lower_dir_name}_stubtest

echo Name is $NET_NAME

docker run --rm \
           -v "$CURDIR/:/build" \
           --net ${NET_NAME} \
           --workdir /build \
           -e  SERVICE_UNDER_TEST_HOSTNAME='http://stub' \
           node:boron bash -c ./_test.sh
