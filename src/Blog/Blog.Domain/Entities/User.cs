using Blog.Common.Security;
using Blog.Domain.Common;
using Blog.Domain.Enums;

namespace Blog.Domain.Entities;
public class User : BaseEntity, IUser
{
    public string Username { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string Phone { get; private set; } = string.Empty;

    public string Password { get; private set; } = string.Empty;

    public UserRole Role { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    string IUser.Id => Id.ToString();

    string IUser.Username => Username;
    string IUser.Role => Role.ToString();

    public static User Create(string username, string phone, string email, UserRole role)
    {
        var user = new User(username, phone, email, role);
        return user;
    }

    public void SetPassword(string password) => Password = password;
    public void SetUpdatedAt() => UpdatedAt = DateTime.UtcNow;

    private User() { }

    private User(string username, string phone, string email, UserRole role)
    {
        CreatedAt = DateTime.UtcNow;
        Username = username;
        Email = email;
        Phone = phone;
        Role = role;
    }
}
