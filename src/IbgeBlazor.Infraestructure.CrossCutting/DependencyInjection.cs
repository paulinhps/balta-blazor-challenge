using IbgeBlazor.Application;
using IbgeBlazor.Core.LocalityContext.Repositories;
using IbgeBlazor.Core.LocalityContext.Services;
using IbgeBlazor.Infraestructure.Data;
using IbgeBlazor.Infraestructure.Data.Repositories;
using IbgeBlazor.Infraestructure.Handlers;
using IbgeBlazor.Infraestructure.Services.Localities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IbgeBlazor.Infraestructure.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(ApplicationAssembly.Assembly);

            });

        return services;
    }

    public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppDbContext>());

        services.AddTransient<IStatesRepository, StatesRepository>();
        services.AddTransient<ICitiesRepository, CityRepository>();

        return services;

    }

    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var apiUrl = "https://localhost:7033";
        services.AddSingleton<ApiConfigureHandler>();

        services.AddHttpClient<ICitiesService, ApiCitiesServices>((IServiceProvider serviceProvider, HttpClient client) =>
        {
            client.BaseAddress = new Uri(apiUrl);
        });
       // .AddHttpMessageHandler(provider => provider.GetService<ApiConfigureHandler>()!);
        
        services.AddHttpClient<IStatesService, ApiStatesServices>((IServiceProvider serviceProvider, HttpClient client) =>
        {
            client.BaseAddress = new Uri(apiUrl);
        });
       // .AddHttpMessageHandler(provider => provider.GetService<ApiConfigureHandler>()!);


        return services;

    }


}
