using Microsoft.Extensions.DependencyInjection;
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
        services.AddTransient<ICourseService, CourseService>();
        services.AddTransient<IStudantService, StudentService>();
        services.AddTransient<IEvaluetionService, EvaluetionService>();

        ///
        /// Repositórios
        /// 
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICourseRepositoty, CourseRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IEvaluetionRepository, EvaluetionRepository>();

    }
}
