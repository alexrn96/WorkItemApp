using Module.UserService.Infrastructure.Persistence;
using Module.UserService.Shared;

namespace Module.UserService.Infrastructure.Data.Seeds;
public static class UserSeeder
{
    public static async Task SeedAsync(UserDbContext context)
    {
        if (!context.Users.Any())
        {
            var users = new List<EntityUser>
            {
                new EntityUser { Id = Guid.NewGuid(), Username = "userA", FullName = "Usuario A", Email="usera@gmail.com", IsActive = true },
                new EntityUser { Id = Guid.NewGuid(), Username = "userB", FullName = "Usuario B", Email="userb@gmail.com", IsActive = true },
                new EntityUser { Id = Guid.NewGuid(),  Username = "userC", FullName = "Usuario C", Email="userc@gmail.com", IsActive = true }
            };

            context.Users.AddRange(users);
            await context.SaveChangesAsync();
        }
    }
}