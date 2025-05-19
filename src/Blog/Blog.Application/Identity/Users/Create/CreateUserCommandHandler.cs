using Blog.Common.Security;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repositories;
using MediatR;

namespace Blog.Application.Identity.Users.Create;

public class CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher) : IRequestHandler<CreateUserCommand, CreateUserResult>
{
    public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await userRepository.GetByEmailAsync(command.Email, cancellationToken);
        if (existingUser != null)
            throw new InvalidOperationException($"User with email {command.Email} already exists");

        var user = User.Create(command.Username, command.Phone, command.Email, command.Role);
        var password = passwordHasher.HashPassword(command.Password);
        user.SetPassword(password);

        var createdUser = await userRepository.CreateAsync(user, cancellationToken);
        var result = new CreateUserResult(createdUser.Id);
        return result;
    }
}