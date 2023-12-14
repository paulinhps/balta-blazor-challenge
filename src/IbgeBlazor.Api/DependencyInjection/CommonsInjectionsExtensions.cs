
namespace IbgeBlazor.Api.DependencyInjection
{
        public static class CommonsInjectionsExtensions
        {
            public static WebApplication MapApiEndPoints(this WebApplication app)
            {
                app
                .MapLocalityEndpoints()
                .MapStatesEndpoints();

                return app;
            }
        }
}