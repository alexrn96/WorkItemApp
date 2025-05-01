using Module.WorkItemService.Infrastructure.Persistence;
using Module.WorkItemService.Shared;
using Module.WorkItemService.Shared.Enums;

namespace Module.WorkItemService.Infrastructure.Data.Seeders;
public static class WorkItemSeeder
{
    public static async Task SeedAsync(WorkItemDbContext context)
    {
        if (!context.WorkItems.Any())
        {
            var workItems = new List<EntityWorkItem>
            {
                new EntityWorkItem
                {
                    Id = Guid.NewGuid(),
                    Title = "Informe A",
                    Description = "Primer informe de usuario A",
                    Priority = WorkItemPriorityEnum.High,
                    DueDate = DateTime.UtcNow.AddDays(5),
                    AssignedToUsername = "userA",
                    Status = WorkItemStatusEnum.Pending
                },
                new EntityWorkItem
                {
                    Id = Guid.NewGuid(),
                    Title = "Tarea crítica A2",
                    Description = "Alta prioridad",
                    Priority = WorkItemPriorityEnum.High,
                    DueDate = DateTime.UtcNow.AddDays(1),
                    AssignedToUsername = "userA",
                    Status = WorkItemStatusEnum.Pending
                },
                new EntityWorkItem
                {
                    Id = Guid.NewGuid(),
                    Title = "Soporte B",
                    Description = "Soporte técnico para cliente",
                    Priority = WorkItemPriorityEnum.Low,
                    DueDate = DateTime.UtcNow.AddDays(4),
                    AssignedToUsername = "userB",
                    Status = WorkItemStatusEnum.Pending
                }
            };

            context.WorkItems.AddRange(workItems);
            await context.SaveChangesAsync();
        }
    }
}

