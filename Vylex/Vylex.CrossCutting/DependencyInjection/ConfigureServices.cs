using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Vylex.Data.Context;
using Vylex.Data.Repositories;
using Vylex.Domain.Interfaces.Repositories;

namespace Vylex.CrossCutting.DependencyInjection;

public static class ConfigureServices
{
    public static void AddServices(this IServiceCollection services)
    {
        // Adicione suas dependências aqui
        // services.AddScoped<IMeuServico, MeuServico>();
        services.AddSingleton<IDesignTimeDbContextFactory<ContextBase>, ContextFactory>();

        ///
        /// Serviços
        /// 


        ///
        /// Repositórios
        /// 
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

    }
}
