using AutoMapper;
using Vylex.CrossCutting.Mappings;

namespace Vylex.WebAPI.Configurations;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new EntityToDtoProfile());
        });

        IMapper mapper = config.CreateMapper();
        services.AddSingleton(mapper);
    }
}
