#!/usr/bin/env bash

cleanup() {
  docker stop app || true

  docker network rm dockernet

  echo "....Cleaning up done"
}

error() {
  echo ">>>>>> Test Failures Found, exiting test run <<<<<<<<<"

  echo
  echo ===========================================================
  echo Printing logs from APP container
  echo ===========================================================
  echo

  docker logs app

  echo
  echo ===========================================================
  echo End of logs from APP container
  echo ===========================================================
  echo

  docker rm app || true

  exit 1
}

trap cleanup EXIT

docker network create -d bridge dockernet

trap error ERR
trap cleanup EXIT

ifne () {
        read line || return 1
        (echo "$line"; cat) | eval "$@"
}

echo
echo ===========================================================
echo building app
echo ===========================================================
echo

docker build -t sc_app ./tests/example-server

echo
echo ===========================================================
echo Building test
echo ===========================================================
echo


docker build -t http-stub-test ./tests/

echo
echo ===========================================================
echo Running app
echo ===========================================================
echo

docker run --rm -d \
             --name app \
             --net=dockernet \
             sc_app

echo
echo ===========================================================
echo Running tests container
echo ===========================================================
echo

docker run --rm --net=dockernet --name test \
             -e "SERVICE_UNDER_TEST_HOSTNAME=http://app:8000" \
             http-stub-test /bin/sh -c ./node_modules/.bin/cucumber-js ./features/**/*.feature