# PizzaParadise
PizzaParadise is a project used for experimenting with web technologies.

# Technologies Used
* .NET Core 6.0
* Blazor Server
* Entity Framework Core
* Docker
* MS-SQL
* Seq

# Database Migrations
To add a new migration run the command
`dotnet ef migrations add {MIGRATION_NAME} --project "PizzaParadise.Entities" --startup-project "PizzaParadise.Web"`

To update the localdatabase run the command
`dotnet ef database update --project "PizzaParadise.Entities" --startup-project "PizzaParadise.Web`

Migrations are applied automatically when the application is started up.