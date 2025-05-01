

namespace Module.WorkItemService.Shared.Interfaces;
public interface IUserClient
{
    Task<List<string>> GetActiveUsersAsync();
}