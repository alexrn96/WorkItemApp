

using Module.WorkItemService.Shared.Enums;

namespace Module.WorkItemService.Shared.DataTransferObjects;
public class WorkItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public WorkItemPriorityEnum Priority { get; set; } = WorkItemPriorityEnum.Low;
    public WorkItemStatusEnum Status { get; set; } = WorkItemStatusEnum.Pending;

    public string? AssignedToUsername { get; set; }
}