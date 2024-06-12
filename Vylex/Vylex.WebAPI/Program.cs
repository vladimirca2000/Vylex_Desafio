using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Vylex.CrossCutting.DependencyInjection;
using Vylex.Data.Context;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

///
/// Add services to the container.
/// 
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

var contextFactory = app.Services.GetRequiredService<IDesignTimeDbContextFactory<ContextBase>>();
using var context = contextFactory.CreateDbContext(args);


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
