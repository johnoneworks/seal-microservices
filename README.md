# seal-microservices
Based on https://onelab.udemy.com/course/microservices-architecture-and-implementation-on-dotnet/
Also based on https://github.com/dotnet-architecture/eShopOnContainers

Hopefully, I try to use that and add some services that make more sense for SEAL along the way...
Not sure though, I have met many obstacle course when trying that. XD

## Prerequisites

### Local Development
- Docker Desktop (>2 CPU, >4GB Memory)
  - run as admin fixes some docker-compose issues
- Visual Studio 2022

## Notes

- Folder structure
  - ```./src```: refers to the VS Studio Solution bundle => this looks like a general common practice

- When creating projects, we add actual folders to the location within the repostory, not just using the Solution folder
  - e.g. When creating the Catalog.API project, we set the location of the project to be ./src/Services/Catalog (this part is manual)

# Service Overviews

## Catalog

### Quick Summary
- .NET Core Web API
- Demonstrates REST API, CRUD
- Uses MongoDB as data store
  - containerized MongoDB
  - Catalog DB => Products Collection
  - use mongoclient/mongoclient docker image for GUI mongo operations
- Repository pattern
- Use docker compose to containerize Catalog & MongoDb
- Auto generated swagger documents
- Traditional 3 tier architecture
  - Presentation Layer
  - Business Logic Layer
  - Data Access Layer
- Seeding of data is done, I think this should be a requirement moving forward


### Nuget Packages Used

- Swashbuckler.AspNetCore: comes preinstalled as default from MSFT, generates Swagger documents
- Mongo.Driver: used to connect to data store

### Container Commands

- docker pull mongo
- docker run -d -p 27017:27017 --name shopping-mongo mongo
  - if you have already run this container before
    - check with docker ps -a
    - docker start
- Use docker compose to containerize the project
  - docker-compose -f .\docker-compose.yml -f docker-compose.override.yml up -d
  - docker-compose -f .\docker-compose.yml -f docker-compose.override.yml down

### Notes

- paths are relative to ```src/Services/Catalog```
- DB settings are placed in ```app```

## Basket

### Quick Summary

- .NET Core Web API
- Redis data store
  - Distributed cache
    - `username` is the key for the data store
    - `basket(cart)` is the value for the data store
- REST API + CRUD
- Repository pattern
- Probably can map to a "running bet" service for SEAL

### Nuget Packages Used

- Swashbuckler.AspNetCore: comes preinstalled as default from MSFT, generates Swagger documents
- Microsoft.Extenstions.Caching.StackExchangeRedis: communication with Redis
- Newtonsoft.Json: parse JSON

## Portainer

### Quick Summary

- Docker managment tool
  - Can't get reset password to work XD
  - admin/admin123456

## Discount.API

### Quick Summary

- PostGre data store
  - pgAdmin for data store GUI
- Two services
  - API
  - GRPC

#### Notes

- Extension 的方式進行 PostgreSQL data seeding
  - https://stackoverflow.com/questions/72350908/ihost-extension-in-net6
- .net6 adding host extension is not clear to me...

## Discount.GRPC

### Quick Summary

- GRPC to communicate synchronously between microservices
- Basket service will use this to check if the product needs to apply discount
- GRPC comes with its own client/server
- Automapper
- Basket.API will consume Discount.GRPC

#### Notes

- I am still using the .net 5 format for program and startup, since I don't know how to do host extensions on .net 6 program

## Consuming Discount.GRPC in Basket.API

### Quick Summary

- Consume in `UpdateBasket`
- Adding connected service within the Basket.API project
  - it is a GRPC "client"
- Dapper ORM

## Order

- CQRS pattern
- DDD
  - Domain Layer
  - Application Layer
  - API Layer
  - Infrastructure Layer
- Entity Framework
- Clean Architecture