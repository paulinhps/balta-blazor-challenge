using IbgeBlazor.Application;
using IbgeBlazor.Core.LocalityContext.Repositories;
using IbgeBlazor.Infraestructure.Data;
using IbgeBlazor.Infraestructure.Data.Repositories;
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
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppDbContext>());

        services.AddTransient<ILocalitiesRepository, LocalitiesRepository>();
        services.AddTransient<IStatesRepository, StatesRepository>();
        services.AddTransient<ICitiesRepository, CityRepository>();

        return services;

    }

    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {


        //services.AddHttpClient<ILocalityService, LocalityApiService>((IServiceProvider serviceProvider, client) =>
        //{
        // Aqui eu preciso pegar o Usuario corrente para pegar um claim que vai ter o JWT.
        // Essa Claim vai ser injetsado dentro do services.AddAutentication na configuração 
        // da Autenticação do Blazor. 
        // Isso porque o projeto de front ele usar cookies e a api usar Bearer Token
        // O mesmo token autenticado do front vai ser passado para a API
        //});


        return services;

    }


}
