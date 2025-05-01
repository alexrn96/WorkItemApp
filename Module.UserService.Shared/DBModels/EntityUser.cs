namespace Module.UserService.Shared;
public class EntityUser
{
    public Guid Id { get; set; } = Guid.NewGuid();  // PK
    public string Username { get; set; } 
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; } = true;
}
