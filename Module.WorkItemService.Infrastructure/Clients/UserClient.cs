
using Module.WorkItemService.Shared.Interfaces;
using System.Net.Http.Json;

namespace Module.WorkItemService.Infrastructure.Clients;
public class UserClient:IUserClient
{
    private readonly HttpClient _httpClient;

    public UserClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<string>> GetActiveUsersAsync()
    {
        //TODO define uri in appsettings
        var users = await _httpClient.GetFromJsonAsync<List<string>>("https://localhost:7205/api/Users");
        return users ?? new List<string>();
    }
}