using System.Reflection;
using IssueTrackingSystem.Application;
using IssueTrackingSystem.Application.Common.Mappings;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IIssueDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();

//TODO: исправить настройки разрешений
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

using var scope = builder.Services.BuildServiceProvider().CreateScope();
try
{
    var context = scope.ServiceProvider.GetRequiredService<IssueDbContext>();
    DbInitializer.Initialize(context);
}
catch (Exception exception)
{
    //TODO: добавить исключение
}

var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();