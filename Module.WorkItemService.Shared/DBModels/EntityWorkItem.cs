
using Module.WorkItemService.Shared.Enums;

namespace Module.WorkItemService.Shared;
public class EntityWorkItem
{
    public Guid Id { get; set; } = Guid.NewGuid(); // PK
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public WorkItemPriorityEnum Priority { get; set; } = WorkItemPriorityEnum.Low;
    public WorkItemStatusEnum Status { get; set; } = WorkItemStatusEnum.Pending;

    // Reference to username of user
    public string? AssignedToUsername { get; set; }
}