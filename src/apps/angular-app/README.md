# AngularApp

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 9.1.15.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).

# Deployment with Docker and NGINX

## `Dockerfile` 

### Stage 1: Build an Angular Docker Image
FROM node as build

WORKDIR /app

COPY package*.json /app/

RUN npm install

COPY . /app

ARG configuration=production

RUN npm run build -- --outputPath=./dist/out --configuration $configuration

### Stage 2, use the compiled app, ready for production with Nginx

FROM nginx

COPY --from=build /app/dist/out/ /usr/share/nginx/html

RUN rm /etc/nginx/conf.d/default.conf

COPY nginx/nginx.conf /etc/nginx/conf.d

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]

## `docker-compose.yml` 

version: '3.7'

services:

  angular-frontend:
  
    container_name: master-app
    
    build:
    
      context: .
      
      dockerfile: Dockerfile
      
    ports:
    
      - '80:80'
      
    environment:
    
      - NODE_ENV=production
     
     
 ## `.dockerignore`
   
   node_modules
   
 ## `nginx\nginx.conf`
 
 server {

  listen 80;

  location / {
  
    root   /usr/share/nginx/html;
    
    index  index.html index.htm;
    
    try_files $uri $uri/ /index.html;
    
  }

  error_page   500 502 503 504  /50x.html;

  location = /50x.html {
  
    root   /usr/share/nginx/html;
    
  }
  
}

run `docker-compose up --build` from the root of the app.

![image](https://user-images.githubusercontent.com/9446209/133135658-055c7c00-b7f0-48da-bbf8-a0c37630bdd3.png)
