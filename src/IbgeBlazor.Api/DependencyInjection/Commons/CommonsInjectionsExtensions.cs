using IbgeBlazor.Application;

namespace IbgeBlazor.Api.DependencyInjection.Commons
{
    public static class CommonsInjectionsExtensions
    {
        public static void AddMediator(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationAssembly).Assembly);
                
            });
        }
    }
}