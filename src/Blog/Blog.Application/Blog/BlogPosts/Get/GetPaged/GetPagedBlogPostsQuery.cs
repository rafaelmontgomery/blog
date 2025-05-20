using Blog.Application.Common;
using Blog.Domain.Entities;
using Blog.Domain.Params;
using MediatR;

namespace Blog.Application.Blog.BlogPosts.Get.GetPaged;
public sealed record GetPagedBlogPostsQuery(BlogPostQueryParams QueryParams) : IRequest<PaginatedList<BlogPost>>;
