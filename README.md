# Microservice Architecture 
An Illustration for proof of concepts of Microservice architecture and best practices. 

## Features and Technologies
- CQRS and event driven architecture, Asynchronous communication using MassTransit and RabbitMQ
- ApiGateway (Ocelot)
- HealthCheck (Microsoft.AspNetCore.Diagnostics.HealthChecks)
- Repository Pattern and Unit of Work
- PostgreSql
## Deployement
- Docker
- Kubernates

## Microservices
### Master.Microservices.Orders
- Repository Pattern
- MS SQL Server
- EF Core
- Rabbit MQ 
### Master.Microservices.Payments
- CQRS (Mediator)
- PostgreSql
- Dapper
- Rabbit MQ
### Master.Microservices.ApiGateway
### Master.Microservices.HealthCheck
### SPA 
- Angular App


