# Dev Instructions

Execute migrations from the terminal

dotnet ef migrations add "Initial" --project ./Module.WorkItemService.Infrastructure --startup-project ./Module.WorkItemService -o Persistence/Migrations/ --context WorkItemDbContext
dotnet ef database update "Initial" --project ./Module.WorkItemService.Infrastructure --startup-project ./Module.WorkItemService


Running migrations from the package management console

Add-Migration "Initial" -Project Module.WorkItemService.Infrastructure -StartupProject Module.WorkItemService -o Persistence/Migrations/ -context WorkItemDbContext
Update-Database -Project Module.WorkItemService.Infrastructure -StartupProject Module.WorkItemService
