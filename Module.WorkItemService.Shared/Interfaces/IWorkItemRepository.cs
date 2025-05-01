

using Module.WorkItemService.Shared.Models;
using Module.WorkItemService.Shared.DataTransferObjects;

namespace Module.WorkItemService.Shared.Interfaces;
public interface IWorkItemRepository
{
    Task<List<WorkItemDto>> GetAllAsync();
    Task<WorkItemDto?> GetByIdAsync(Guid id);
    Task AddAsync(WorkItemDto item);
    Task MarkAsCompletedAsync(Guid id);
    Task<List<WorkItemDto>> GetByUserAsync(string username);
    Task<Dictionary<string, UserWorkItemStats>> GetPendingStatsByUserAsync();

    
}