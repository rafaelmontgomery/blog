using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repositories;
using Blog.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Repositories;
public class BlogPostRepository(PgSqlContext context) : IBlogPostRepository
{
    public async Task<BlogPost> CreateAsync(BlogPost blogPost, CancellationToken cancellationToken = default)
    {
        await context.BlogPosts.AddAsync(blogPost, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return blogPost;
    }

    public async Task<BlogPost> DeleteAsync(BlogPost blogPost, CancellationToken cancellationToken = default)
    {
        context.BlogPosts.Remove(blogPost);
        await context.SaveChangesAsync(cancellationToken);
        return blogPost;
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await context.BlogPosts.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

    public async Task<BlogPost> UpdateAsync(BlogPost blogPost, CancellationToken cancellationToken = default)
    {
        context.BlogPosts.Update(blogPost);
        await context.SaveChangesAsync(cancellationToken);
        return blogPost;
    }
}
