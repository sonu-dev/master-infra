
## EFCore Migration Commands

1)	Run nuget package console commands only against project Master.Microservices.Orders.DataAccess

2) Check connection string into MasterDbContextBase

3) Add-Migration -name InitialCreate -outputDir Migrations --> It will add migration files under migration folder

4) update-database --> it will add actual database, tables and data.


