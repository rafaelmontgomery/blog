using Blog.Domain.Common;
using Blog.Domain.Enums;
using Blog.Domain.Interfaces;

namespace Blog.Domain.Entities;
public class User : BaseEntity, IUser
{
    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    string IUser.Id => Id.ToString();

    string IUser.Username => Username;

    string IUser.Role => Role.ToString();

    public User()
    {
        CreatedAt = DateTime.UtcNow;
    }
}
