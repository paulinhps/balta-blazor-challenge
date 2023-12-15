using IbgeBlazor.Application.LocalityContext.States.Extensions;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.Constants;
using IbgeBlazor.Core.LocalityContext.DataModels;
using MediatR;

public static class StateEndpoints
{
    private static string[] Tags = ["States"];

    public static WebApplication MapStatesEndpoints(this WebApplication app)
    {

        app.MapPost(ApiEndpointsPaths.States, async (CreateStateModel model, IMediator mediator) =>
        {

            var result = await mediator.Send(model.FromCommand());

            ModelResult<StateModel> response = result.FromModel();
            if (response.Success)
                return Results.Created($"{ApiEndpointsPaths.States}/{result.Data!.Id}", response);

            else
                return Results.UnprocessableEntity(response);

        })
        .WithName("CreateState")
        .WithTags(Tags)
        .Produces<ModelResult<StateModel>>(StatusCodes.Status201Created)
        .Produces<ModelResultBase>(StatusCodes.Status422UnprocessableEntity);

        return app;
    }
}
