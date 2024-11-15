namespace TicketHub.Domain.Users;

public sealed class Role
{
    public static readonly Role None = new(0, string.Empty);
    public static readonly Role Registered = new(1, "Registered");
    public static readonly Role Merchant = new(2, "Merchant");
    public static readonly Role Support = new(3, "Support");
    public static readonly Role Admin = new(4, "Admin");
    public static readonly Role SuperAdmin = new(5, "SuperAdmin");

    public Role(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; init; }

    public string Name { get; init; }
    public ICollection<User> Users { get; init; } = [];
    public ICollection<Permission> Permissions { get; init; } = [];
    public static Role FormRole(string name) => All.FirstOrDefault(r => r.Name == name) ?? 
        throw new ApplicationException("The role is invalid.");
    public static Role CheckRole(string name) => All.FirstOrDefault(r => r.Name == name) ?? None;
    public static readonly IReadOnlyCollection<Role> All =
    [
        Registered,
        Merchant,
        Support,
        Admin,
        SuperAdmin
    ];
}
