
using IbgeBlazor.Api.Endpoints.Localities;

namespace IbgeBlazor.Api.DependencyInjection
{
    public static class CommonsInjectionsExtensions
    {
        public static WebApplication MapApiEndPoints(this WebApplication app)
        {
            app
            .MapCitiesEndpoints()
            .MapStatesEndpoints();

            return app;
        }
    }
}