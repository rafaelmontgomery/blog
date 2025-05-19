using MediatR;

namespace Blog.Application.Identity.Auth;
public sealed record AuthenticateUserCommand(string Email, string Password) : IRequest<AuthenticateUserResult>;