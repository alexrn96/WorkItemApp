
using Module.WorkItemService.Shared.DataTransferObjects;
using Module.WorkItemService.Shared.Models;

namespace Module.WorkItemService.Shared.Interfaces;
public interface IWorkItemService
{
    Task<List<WorkItemDto>> GetAllAsync();
    Task<WorkItemDto?> GetByIdAsync(Guid id);
    Task<WorkItemDto> CreateAsync(WorkItemDto item);
    Task MarkAsCompletedAsync(Guid id);
    Task<List<WorkItemDto>> GetByUserAsync(string username);
    Task<Dictionary<string, UserWorkItemStats>> GetPendingStatsAsync();

}
