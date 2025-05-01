using Microsoft.EntityFrameworkCore;
using Module.UserService.Infrastructure.Data.Seeds;
using Module.UserService.Infrastructure.Persistence;
using Module.UserService.Infrastructure.Services;
using Module.UserService.Infrastructure.Tools;
using Module.UserService.Shared;
using Module.UserService.Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//AutoMapper
builder.Services.AddAutoMapper(config => config.AddProfile<UserMappingProfiles>());

//services
builder.Services.AddScoped<IUserService, UserService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<UserDbContext>();

        await UserSeeder.SeedAsync(context);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
