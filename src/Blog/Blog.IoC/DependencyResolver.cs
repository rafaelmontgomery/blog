using System.Reflection;
using Blog.Application.Identity.Users.Create;
using Blog.Common.Validation;
using Blog.IoC.ModuleInitializers;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.IoC;
public static class DependencyResolver
{
    public static void RegisterDependencies(this WebApplicationBuilder builder)
    {
        AddMediator(builder);
        new InfraModuleInitializer().Initialize(builder);
        new ApplicationModuleInitializer().Initialize(builder);
    }

    public static void AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        builder.Services.AddTransient<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
        builder.Services.AddTransient<IRequestHandler<CreateUserCommand, CreateUserResult>, CreateUserCommandHandler>();
    }
}