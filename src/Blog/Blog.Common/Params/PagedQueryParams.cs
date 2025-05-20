namespace Blog.Common.Params;
public abstract class PagedQueryParams
{
    const int maxPageSize = 50;
    private int _pageSize = maxPageSize;
    private int _currentPage = 1;

    public string? Search { get; set; }
    public int CurrentPage
    {
        get => _currentPage;
        set => _currentPage = (value >= 1) ? value : _currentPage;
    }
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
    }

    public string? SearchLike => string.IsNullOrWhiteSpace(Search) ? null : $"%{Search}%";
}
