using Blog.Common.Security;
using Blog.Domain.Interfaces.Repositories;
using MediatR;

namespace Blog.Application.Identity.Auth;
public class AuthenticateUserComandHandler(
      IUserRepository userRepository,
      IPasswordHasher passwordHasher,
      IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResult>
{
    public async Task<AuthenticateUserResult> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user == null || !passwordHasher.VerifyPassword(request.Password, user.Password))
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticateUserResult
        {
            Id = user.Id,
            Token = token,
            Email = user.Email,
            Name = user.Username,
            Role = user.Role.ToString()
        };
    }
}
