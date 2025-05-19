using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repositories;
using Blog.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Repositories;

public class UserRepository(PgSqlContext context) : IUserRepository
{
    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) 
        => await context.Users.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default) 
        => await context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
}
