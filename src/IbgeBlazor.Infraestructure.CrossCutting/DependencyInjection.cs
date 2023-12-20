using IbgeBlazor.Application;
using IbgeBlazor.Application.Data;
using IbgeBlazor.Core.LocalityContext.Repositories;
using IbgeBlazor.Core.LocalityContext.Services;
using IbgeBlazor.Infraestructure.Data;
using IbgeBlazor.Infraestructure.Data.Repositories;
using IbgeBlazor.Infraestructure.Handlers;
using IbgeBlazor.Infraestructure.Services.Localities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IbgeBlazor.Infraestructure.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
            .AddIdentityCookies();

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<AppDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        return services;
    }
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

        services.AddSecurityServices();

        services.AddTransient<IStatesRepository, StatesRepository>();
        services.AddTransient<ICitiesRepository, CityRepository>();

        return services;

    }

    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var apiUrl = "https://localhost:7033";
        services.AddSingleton<ApiConfigureHandler>();

        services.AddScoped<ICitiesService, ApiCitiesServices>();
        
        services.AddScoped<IStatesService, ApiStatesServices>();


        return services;

    }


}
