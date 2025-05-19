using Blog.Domain.Enums;
using MediatR;

namespace Blog.Application.Identity.Users.Create;
//public sealed record CreateUserCommand(string Username, string Password, string Phone, string Email, UserRole Role) : IRequest<CreateUserResult>;

public class CreateUserCommand : IRequest<CreateUserResult>
{
    public CreateUserCommand(string userName, string password, string phone, string email, UserRole role)
    {
        Username = userName;
        Password = password;
        Phone = phone;
        Email = email;
        Role = role;
    }
    public string Username { get; set; }

    public string Password { get; set; } 

    public string Phone { get; set; }

    public string Email { get; set; } 

    public UserRole Role { get; set; }

 
}
