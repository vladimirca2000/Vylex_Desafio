using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Vylex.Data.Context;
using Vylex.Data.Repositories;
using Vylex.Domain.Interfaces.Repositories;
using Vylex.Domain.Interfaces.Services;
using Vylex.Service.Services;

namespace Vylex.CrossCutting.DependencyInjection;

public static class ConfigureServices
{
    public static void AddServices(this IServiceCollection services)
    {
        ///
        /// Serviço do contexto
        /// 
        services.AddSingleton<IDesignTimeDbContextFactory<ContextBase>, ContextFactory>();

        ///
        /// Serviços
        /// 
        services.AddTransient<ICourseService, CourseService>();

        ///
        /// Repositórios
        /// 
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICourseRepositoty, CourseRepository>();

    }
}
