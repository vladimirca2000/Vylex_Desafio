using Vylex.CrossCutting.DependencyInjection;

namespace Vylex.WebAPI.Configurations;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        ConfigureServices.AddServices(services);
    }
}
