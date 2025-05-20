using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Blog.Common.Security;
public class UserContextService(IHttpContextAccessor httpContextAccessor)
{
    public Guid GetUserId()
    {
        var userIdClaim = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
        return userIdClaim is null ? Guid.Empty : Guid.Parse(userIdClaim.Value);
    }
}
