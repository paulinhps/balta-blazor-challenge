using IbgeBlazor.Api.Extensions;
using IbgeBlazor.Application.LocalityContext.Extensions;
using IbgeBlazor.Application.Common.Extensions;
using IbgeBlazor.Application.LocalityContext.States.Delete;
using IbgeBlazor.Application.LocalityContext.States.GetStateDetails;
using IbgeBlazor.Application.LocalityContext.States.GetStatesList;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.Constants;
using IbgeBlazor.Core.LocalityContext.DataModels.States;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using IbgeBlazor.Api.Common.DataModels;

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

        app.MapGet(ApiEndpointsPaths.States, async (PagingData queryModel, IMediator mediator ) =>
        {

            var query = new GetStateWithPaginationQuery()
            {
                PageNumber = queryModel.Page,
                PageSize = queryModel.PageSize
            };

            var result = await mediator.Send(query);

            var dataResult = result.Results?
            .Select(StatesDataModelsExtensions.FromStateModel)
            .ToArray();

            return new ModelResult<IEnumerable<StateModel>>(dataResult!);

        })
        .WithName("ListStates")
        .WithTags(Tags)
        .Produces<ModelResult<IEnumerable<StateModel>>>(StatusCodes.Status200OK)
        .Produces<ModelResultBase>(StatusCodes.Status500InternalServerError);

        app.MapGet($"{ApiEndpointsPaths.States}/{{stateId:int}}", async (int stateId, IMediator mediator) =>
        {

            var query = new GetStateDetailByIdQuery(stateId);

            var result = await mediator.Send(query);

            var response = new ModelResult<StateModel>(result.Results is not null ? new StateModel()
            {
                Description = result.Results!.Name,
                Id = result.Results!.Id,
                Uf = result.Results!.Code
            } : null, message: result.Results is null ? "Estado não encontrado" : null!);

            return response.Data is not null ? Results.Ok(response) : Results.NotFound(response);


        })
        .WithName("StateDetails")
        .WithTags(Tags)
        .Produces<ModelResult<StateModel>>(StatusCodes.Status200OK)
        .Produces<ModelResultBase>(StatusCodes.Status404NotFound)
        .Produces<ModelResultBase>(StatusCodes.Status500InternalServerError);

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

