using AutoMapper;
using Module.UserService.Shared;
using Module.UserService.Shared.DataTransferObjects;

namespace Module.UserService.Infrastructure.Tools;
public class UserMappingProfiles : Profile
{
    public UserMappingProfiles()
    {
        ConfigureDtoToEntityMappings();
        ConfigureEntityToDtoMappings();
    }
    private void ConfigureDtoToEntityMappings()
    {
        CreateMap<UserDto, EntityUser>();
    }

    private void ConfigureEntityToDtoMappings()
    {
        CreateMap<EntityUser, UserDto>();
    }
}
