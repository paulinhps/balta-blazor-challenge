using IbgeBlazor.Api.Extensions;
using IbgeBlazor.Application.LocalityContext.States.Commands;
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

            return result.CreateResult(response, status201CreatedPath: $"{ApiEndpointsPaths.States}/{result.Data?.Id}");


        })
        .WithName("CreateState")
        .WithTags(Tags)
        .Produces<ModelResult<StateModel>>(StatusCodes.Status201Created)
        .Produces<ModelResultBase>(StatusCodes.Status422UnprocessableEntity);

        app.MapPut($"{ApiEndpointsPaths.States}/{{id:int}}", async (int id, UpdateStateModel model, IMediator mediator) =>
        {

            var result = await mediator.Send(model.FromCommand(id));

            ModelResult<StateModel> response = result.FromModel();

            return result.CreateResult(response);

        })
        .WithName("UpdateState")
        .WithTags(Tags)
        .Produces<ModelResult<StateModel>>(StatusCodes.Status200OK)
        .Produces<ModelResultBase>(StatusCodes.Status422UnprocessableEntity);


        app.MapDelete($"{ApiEndpointsPaths.States}/{{id:int}}", async (int id, IMediator mediator) =>
        {

            var result = await mediator.Send(new DeleteStateCommand(id));

            ModelResultBase response = result.FromModel();

            return result.CreateResult(response);

        })
        .WithName("DeleteState")
        .WithTags(Tags)
        .Produces<ModelResultBase>(StatusCodes.Status200OK)
        .Produces<ModelResultBase>(StatusCodes.Status422UnprocessableEntity);

        return app;
    }
}
