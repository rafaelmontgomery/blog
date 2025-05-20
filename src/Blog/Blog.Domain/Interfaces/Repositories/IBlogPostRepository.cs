using Blog.Domain.Entities;
using Blog.Domain.Params;

namespace Blog.Domain.Interfaces.Repositories;
public interface IBlogPostRepository
{
    Task<BlogPost> CreateAsync(BlogPost blogPost, CancellationToken cancellationToken = default);
    Task<BlogPost?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<BlogPost> UpdateAsync(BlogPost blogPost, CancellationToken cancellationToken = default);
    Task<BlogPost> DeleteAsync(BlogPost blogPost, CancellationToken cancellationToken = default);
    Task<BlogPost?> GetByAuthorAndIdAsync(Guid id, Guid authorId, CancellationToken cancellationToken = default);
    IQueryable<BlogPost> GetQuery(BlogPostQueryParams queryParams);
}
