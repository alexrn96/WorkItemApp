
using Microsoft.EntityFrameworkCore;
using Module.UserService.Infrastructure.Persistence;
using Module.UserService.Shared.Interfaces;

namespace Module.UserService.Infrastructure.Services;
public class UserService:IUserService
{
    private readonly UserDbContext _context;

    public UserService(UserDbContext context)
    {
        _context = context;
    }

    public async Task<List<string>> GetActiveUsernamesAsync()
    {
        return await _context.Users
            .Where(u => u.IsActive)
            .Select(u => u.Username)
            .ToListAsync();
    }
}