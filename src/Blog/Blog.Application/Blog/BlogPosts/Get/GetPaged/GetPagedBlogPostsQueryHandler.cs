using Blog.Application.Common;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repositories;
using MediatR;

namespace Blog.Application.Blog.BlogPosts.Get.GetPaged;
public class GetPagedBlogPostsQueryHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<GetPagedBlogPostsQuery, PaginatedList<BlogPost>>
{
    public async Task<PaginatedList<BlogPost>> Handle(GetPagedBlogPostsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<BlogPost> query = blogPostRepository.GetQuery(request.QueryParams);
        var list = await PaginatedList<BlogPost>.CreateAsync(query, request.QueryParams.CurrentPage, request.QueryParams.PageSize);
        return list;
    }
}
