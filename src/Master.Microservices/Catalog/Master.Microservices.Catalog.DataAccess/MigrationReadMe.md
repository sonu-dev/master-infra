
## EFCore Migration Commands

1)	Run nuget package console commands only against project Master.Microservices.Catalog.DataAccess

2) Check connection string into MasterDbContextBase

3) Add-Migration -name InitialCreate -outputDir Migrations --> It will add migration files under migration folder

4) update-database --> it will add actual database, tables and data.


| PMC Command                     | Usage                                             |
|---------------------------------|---------------------------------------------------|
| add-migration <migration name>  | Creates a migration by adding a migration snapshot|
| Remove-migration                | Removes the last migration snapshot.              |
| Update-database                 | Updates the database schema based on the last migration snapshot.|
| Script-migration                | Generates a SQL script using all the migration snapshots.|
                             
