

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module.WorkItemService.Infrastructure.Persistence;
using Module.WorkItemService.Shared;
using Module.WorkItemService.Shared.DataTransferObjects;
using Module.WorkItemService.Shared.Enums;
using Module.WorkItemService.Shared.Interfaces;
using Module.WorkItemService.Shared.Models;

namespace Module.WorkItemService.Infrastructure.Repositories;
public class WorkItemRepository:IWorkItemRepository
{

    private readonly WorkItemDbContext _context;
    private readonly IMapper _mapper;
    public WorkItemRepository(WorkItemDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WorkItemDto>> GetAllAsync()
    {
        List<EntityWorkItem> workItems= await _context.WorkItems.ToListAsync();
        return _mapper.Map<List<WorkItemDto>>(workItems);
    }

    public async Task<WorkItemDto?> GetByIdAsync(Guid id)
    {
        EntityWorkItem? workItems= await _context.WorkItems
            .FirstOrDefaultAsync(w => w.Id == id);
        return _mapper?.Map<WorkItemDto>(workItems);
    }

    public async Task AddAsync(WorkItemDto item)
    {
        EntityWorkItem workItem = _mapper.Map<EntityWorkItem>(item);
        await _context.WorkItems.AddAsync(workItem);
        await _context.SaveChangesAsync();
    }

    public async Task MarkAsCompletedAsync(Guid id)
    {
        var item = await _context.WorkItems.FindAsync(id);
        if (item != null)
        {
            item.Status = WorkItemStatusEnum.Completed;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<WorkItemDto>> GetByUserAsync(string username)
    {
        List<EntityWorkItem> workItems = await _context.WorkItems
            .Where(w => w.AssignedToUsername == username)
            .ToListAsync();
        return _mapper.Map<List<WorkItemDto>>(workItems);
    }

    public async Task<Dictionary<string, UserWorkItemStats>> GetPendingStatsByUserAsync()
    {
        

        var query = await _context.WorkItems
        .Where(w => w.Status == WorkItemStatusEnum.Pending && w.AssignedToUsername != null)
        .GroupBy(w => w.AssignedToUsername!)
        .ToDictionaryAsync(
            g => g.Key!,
            g => new UserWorkItemStats
            {
                TotalPending = g.Count(),
                HighRelevancePending = g.Count(x => x.Priority == WorkItemPriorityEnum.High)
            });

        return query;
    }
}
