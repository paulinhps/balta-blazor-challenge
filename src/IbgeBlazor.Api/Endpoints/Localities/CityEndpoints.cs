using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.Constants;
using IbgeBlazor.Core.LocalityContext.DataModels;
using MediatR;

namespace IbgeBlazor.Api.Endpoints.Localities
{
    public static class CityEndpoints
    {
        private static string[] Tags = ["City"];

        public static WebApplication MapStatesEndpoints(this WebApplication app)
        {

            app.MapPost(ApiEndpointsPaths.Cities, async (CreateCityModel model, IMediator mediator) =>
                {

                    var result = await mediator.Send(model.FromCommand());

                    ModelResult<CityModel> response = result.FromModel();
                    if (response.Success)
                        return Results.Created($"{ApiEndpointsPaths.Cities}/{result.Data!.Id}", response);

                    else
                        return Results.UnprocessableEntity(response);

                })
                .WithName("CreateCity")
                .WithTags(Tags)
                .Produces<ModelResult<CityModel>>(StatusCodes.Status201Created)
                .Produces<ModelResultBase>(StatusCodes.Status422UnprocessableEntity);

            return app;
        }
    }
}
