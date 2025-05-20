using System.Reflection;
using Blog.Common.Security;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Contexts;
public class PgSqlContext(DbContextOptions<PgSqlContext> options, UserContextService userContextService) : DbContext(options)
{
    public required DbSet<User> Users { get; set; }
    public required DbSet<BlogPost> BlogPosts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseIdentityAlwaysColumns();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SoftDelete();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SoftDelete()
    {
        foreach (var entry in ChangeTracker.Entries<ISoftDeletable>().Where(entry => entry.State == EntityState.Deleted))
        {
            entry.State = EntityState.Modified;
            entry.Entity.SetDeletedBy(userContextService.GetUserId());
            entry.Entity.SetDeletedAt(DateTime.UtcNow);
        }
    }

}