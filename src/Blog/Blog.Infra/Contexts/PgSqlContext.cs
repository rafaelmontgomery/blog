using System.Reflection;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Contexts;
public class PgSqlContext(DbContextOptions<PgSqlContext> options) : DbContext(options)
{
    public required DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseIdentityAlwaysColumns();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
