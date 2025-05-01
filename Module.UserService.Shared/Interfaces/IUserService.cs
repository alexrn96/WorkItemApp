

namespace Module.UserService.Shared.Interfaces;
public interface IUserService
{
    Task<List<string>> GetActiveUsernamesAsync();
}