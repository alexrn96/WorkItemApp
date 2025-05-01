using Microsoft.EntityFrameworkCore;
using Module.WorkItemService.Infrastructure.Clients;
using Module.WorkItemService.Infrastructure.Data.Seeders;
using Module.WorkItemService.Infrastructure.Persistence;
using Module.WorkItemService.Infrastructure.Repositories;
using Module.WorkItemService.Infrastructure.Services;
using Module.WorkItemService.Infrastructure.Tools;
using Module.WorkItemService.Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WorkItemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(config => config.AddProfile<WorkItemMappingProfiles>());

//services
builder.Services.AddHttpClient<IUserClient, UserClient>();
builder.Services.AddScoped<IWorkItemService, WorkItemService>();
builder.Services.AddScoped<IWorkItemRepository, WorkItemRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<WorkItemDbContext>();

        await WorkItemSeeder.SeedAsync(context);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
