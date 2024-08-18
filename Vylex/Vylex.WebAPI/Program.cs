using Vylex.Data.Context;
using Vylex.WebAPI.Configurations;


var builder = WebApplication.CreateBuilder(args);

//builder.Configuration
//    .SetBasePath(builder.Environment.ContentRootPath)
//    .AddJsonFile("appsettings.json", true, true)
//    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
//    .AddEnvironmentVariables();

//builder.Services.AddServices();


///
/// Add services to the container.
/// 
builder.Services.AddControllers();


// Setting DBContexts
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// .NET Native DI Abstraction
builder.Services.AddDependencyInjectionConfiguration();

builder.Services.AddEndpointsApiExplorer();


// AutoMapper Settings
builder.Services.AddAutoMapperConfiguration();

// Swagger Config
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    using var context = scope.ServiceProvider.GetRequiredService<ContextoBase>();
//    context.Database.EnsureCreated();
//}

app.UseRouting();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerSetup();

app.Run();
