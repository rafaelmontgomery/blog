using Blog.Domain.Entities;

namespace Blog.Domain.Interfaces.Repositories;
public interface IUserRepository
{
    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}