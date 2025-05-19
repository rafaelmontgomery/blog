
namespace Blog.Application.Identity.Auth;
public class AuthenticateUserRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public AuthenticateUserCommand ToCommand() => new(Email, Password);

}
