using Microsoft.AspNetCore.Builder;

namespace Blog.IoC;
internal interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
