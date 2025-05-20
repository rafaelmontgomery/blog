using Blog.API.Middleware;
using Blog.Common.Security;
using Blog.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDependencies();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


builder.Services.AddJwtAuthentication(builder.Configuration);

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
