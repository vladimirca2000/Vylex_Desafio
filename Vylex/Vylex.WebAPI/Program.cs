using Vylex.WebAPI.Configurations;
using Vylex.WebAPI.Service;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TokenService>();

builder.Services.AddControllers();

// Setting DBContexts
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors();

// JWT Settings
builder.Services.AddJwtConfiguration(builder.Configuration);
// AutoMapper Settings
builder.Services.AddAutoMapperConfiguration();
// Swagger Config
builder.Services.AddSwaggerConfiguration();


var app = builder.Build();

app.UseRouting();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseSwaggerSetup();

app.Run();
