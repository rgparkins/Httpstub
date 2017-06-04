FROM node:latest

RUN npm install -g cucumber@1.3.3

RUN mkdir -p /usr/src/app
COPY . /usr/src/tests
WORKDIR /usr/src/tests

RUN npm install

CMD [ "cucumber-js", "--tags", "~@ignore" ]