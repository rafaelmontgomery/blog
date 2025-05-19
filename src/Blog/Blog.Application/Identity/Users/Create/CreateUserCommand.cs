using Blog.Domain.Enums;
using MediatR;

namespace Blog.Application.Identity.Users.Create;
public sealed record CreateUserCommand(string Username, string Password, string Phone, string Email, UserRole Role) : IRequest<CreateUserResult>;
