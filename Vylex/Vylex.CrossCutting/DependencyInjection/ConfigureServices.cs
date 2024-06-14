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
        /// Serviços
        /// 
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IEvaluetionService, EvaluetionService>();

        ///
        /// Repositórios
        /// 
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICourseRepositoty, CourseRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IEvaluetionRepository, EvaluetionRepository>();

        services.AddScoped<ContextoBase>();

    }
}
