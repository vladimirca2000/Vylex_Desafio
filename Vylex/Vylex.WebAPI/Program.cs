using Vylex.CrossCutting.DependencyInjection;
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

builder.Services.AddSwaggerGen();

var app = builder.Build();


///
/// A linha de configuração do ambiente de develomente não foi colocada propositalmente.
/// 
/// if (app.Environment.IsDevelopment()) 
/// 
/// deveria ser usado para configurar o Swagger apenas em ambiente de desenvolvimento
/// Para fins de apresentação, o Swagger foi configurado para todos os ambientes
///

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
