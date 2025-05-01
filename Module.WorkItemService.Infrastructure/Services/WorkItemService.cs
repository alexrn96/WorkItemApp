
using AutoMapper;
using Module.WorkItemService.Shared.DataTransferObjects;
using Module.WorkItemService.Shared.Enums;
using Module.WorkItemService.Shared.Interfaces;
using Module.WorkItemService.Shared.Models;

namespace Module.WorkItemService.Infrastructure.Services;
public class WorkItemService : IWorkItemService
{
    
    private readonly IWorkItemRepository _repository;
    private readonly IUserClient _userClient;
    private readonly IMapper _mapper;

    public WorkItemService(IWorkItemRepository repository, IUserClient userClient, IMapper mapper)
    {
        _repository = repository;
        _userClient = userClient;
        _mapper = mapper;
    }

    public async Task<List<WorkItemDto>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<WorkItemDto?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<WorkItemDto> CreateAsync(WorkItemDto item)
    {
        var users = await _userClient.GetActiveUsersAsync();
        var stats = await _repository.GetPendingStatsByUserAsync();

        IEnumerable<string> eligibleUsers = users;

        var isUrgent = item.DueDate <= DateTime.UtcNow.AddDays(3);
        var isHighPriority = item.Priority == WorkItemPriorityEnum.High;

        if (isUrgent)
        {
            // Urgent: Assigned to the user with the fewest items, without considering saturation or relevance.
            eligibleUsers = eligibleUsers
                .OrderBy(u => stats.TryGetValue(u, out var stat) ? stat.TotalPending : 0);
        }
        else if (isHighPriority)
        {
            // High relevance but not urgent
            // Ignore saturated users (3 or more items of high relevance)
            eligibleUsers = eligibleUsers
                .Where(u => stats.TryGetValue(u, out var s) ? s.HighRelevancePending < 3 : true)
                .OrderBy(u => stats.TryGetValue(u, out var s) ? s.TotalPending : 0);
        }
        else
        {
            // Low priority and non-urgent → only by total number of outstanding
            eligibleUsers = eligibleUsers
                .OrderBy(u => stats.TryGetValue(u, out var s) ? s.TotalPending : 0);
        }
        item.AssignedToUsername = eligibleUsers.FirstOrDefault();
        await _repository.AddAsync(item);

        return item;
    }

    public async Task MarkAsCompletedAsync(Guid id)
    {
        await _repository.MarkAsCompletedAsync(id);
    }

    public async Task<List<WorkItemDto>> GetByUserAsync(string username)
    {
        return await _repository.GetByUserAsync(username);
    }

    public async Task<Dictionary<string, UserWorkItemStats>> GetPendingStatsAsync()
    {
        return await _repository.GetPendingStatsByUserAsync();
    }

    
}