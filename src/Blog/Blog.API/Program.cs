using Blog.API.Middleware;
using Blog.Common.Security;
using Blog.Infra.Contexts;
using Blog.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDependencies();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PgSqlContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddExceptionHandler<ApplicationExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();
app.UseMiddleware<ValidationExceptionMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
