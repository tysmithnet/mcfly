#!/usr/bin/env bash

apt-get update && install -y apache2 curl git

curl -sL https://deb.nodesource.com/setup_10.x | sudo -E bash -
apt-get install -y nodejs
npm i -g yarn webpack webpack-cli webpack-dev-server jest @storybook/cli http-server

if ! [ -L /var/www ]; then
  rm -rf /var/www
  ln -fs /vagrant /var/www
fi
