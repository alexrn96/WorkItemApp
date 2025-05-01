using AutoMapper;
using Module.WorkItemService.Shared;
using Module.WorkItemService.Shared.DataTransferObjects;

namespace Module.WorkItemService.Infrastructure.Tools;
public class WorkItemMappingProfiles : Profile
{
    public WorkItemMappingProfiles()
    {
        ConfigureDtoToEntityMappings();
        ConfigureEntityToDtoMappings();
    }
    private void ConfigureDtoToEntityMappings()
    {
        CreateMap<WorkItemDto, EntityWorkItem>();
    }

    private void ConfigureEntityToDtoMappings()
    {
        CreateMap<EntityWorkItem, WorkItemDto>();
    }
}