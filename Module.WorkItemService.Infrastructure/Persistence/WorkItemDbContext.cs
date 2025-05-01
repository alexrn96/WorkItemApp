

using Microsoft.EntityFrameworkCore;
using Module.WorkItemService.Shared;

namespace Module.WorkItemService.Infrastructure.Persistence;
public class WorkItemDbContext :DbContext
{
    public WorkItemDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<EntityWorkItem> WorkItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}