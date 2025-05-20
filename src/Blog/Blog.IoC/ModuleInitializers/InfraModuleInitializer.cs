using Blog.Domain.Interfaces.Repositories;
using Blog.Infra.Contexts;
using Blog.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.IoC.ModuleInitializers;
public class InfraModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<PgSqlContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<PgSqlContext>());
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
    }
}
