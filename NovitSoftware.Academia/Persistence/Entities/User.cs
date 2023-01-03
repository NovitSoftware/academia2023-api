namespace NovitSoftware.Academia.Persistence.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public ICollection<Role> Roles { get; set; }

    public User()
    {
        this.Roles = new HashSet<Role>();
    }

    public void AddRole(Role role)
    { 
        Roles.Add(role);
    }
}
