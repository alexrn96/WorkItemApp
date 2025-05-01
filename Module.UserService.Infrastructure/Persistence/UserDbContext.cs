
using Microsoft.EntityFrameworkCore;
using Module.UserService.Shared;

namespace Module.UserService.Infrastructure.Persistence;
public class UserDbContext: DbContext
{
    public UserDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<EntityUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}