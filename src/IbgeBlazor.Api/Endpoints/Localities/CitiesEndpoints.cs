using IbgeBlazor.Api.Extensions;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.Constants;
using IbgeBlazor.Core.LocalityContext.DataModels.Cities;
using IbgeBlazor.Application.Common.Extensions;
using IbgeBlazor.Application.LocalityContext.Extensions;
using MediatR;
using IbgeBlazor.Application.LocalityContext.Cities.GetCityList;
using IbgeBlazor.Application.LocalityContext.Cities.GetCityDetails;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace IbgeBlazor.Api.Endpoints.Localities;

public static class CitiesEndpoints
{
    private static string[] Tags = ["Cities"];

    public static WebApplication MapCitiesEndpoints(this WebApplication app)
    {

        app.MapPost(ApiEndpointsPaths.Cities, async (CreateCityModel model, IMediator mediator) =>
            {

                var result = await mediator.Send(model.FromCommand());

                ModelResult<CityModel> response = result.FromModel();

                return result.CreateResult(response, status201CreatedPath: $"{ApiEndpointsPaths.States}/{result.Data?.Id}");


            })
            .WithName("CreateCity")
            .WithTags(Tags)
            .Produces<ModelResult<CityModel>>(StatusCodes.Status201Created)
            .Produces<ModelResultBase>(StatusCodes.Status400BadRequest)
            .Produces<ModelResultBase>(StatusCodes.Status404NotFound)
            .Produces<ModelResultBase>(StatusCodes.Status422UnprocessableEntity);

        app.MapGet(ApiEndpointsPaths.Cities, async (PagingData queryModel, IMediator mediator) =>
        {
            var query = new GetCitiesWithPaginationQuery()
            {
                PageNumber = queryModel.Page,
                PageSize = queryModel.PageSize
            };

            var result = await mediator.Send(query);

            var dataResult = result.Results?
            .Select(CitiesDataModelsExtensions.FromCityModel)
            .ToArray();

            return new ModelResult<IEnumerable<CityModel>>(dataResult!);

        })
            .WithName("ListCities")
            .WithTags(Tags)
            .Produces<ModelResult<IEnumerable<CityModel>>>(StatusCodes.Status200OK)
            .Produces<ModelResultBase>(StatusCodes.Status500InternalServerError);

        app.MapGet($"{ApiEndpointsPaths.Cities}/{{ibgeCode}}", async (string ibgeCode, IMediator mediator) =>
        {

            var query = new GetCityDetailByIbgeCodeQuery(ibgeCode);

            var result = await mediator.Send(query);

            var response = result.Results?.FromCityModel();

            return result.Results is not null ? Results.Ok(response) : Results.NotFound(response);


        })
            .WithName("CityDetails")
            .WithTags(Tags)
            .Produces<ModelResult<CityModel>>(StatusCodes.Status200OK)
            .Produces<ModelResultBase>(StatusCodes.Status404NotFound)
            .Produces<ModelResultBase>(StatusCodes.Status500InternalServerError);

        app.MapPut($"{ApiEndpointsPaths.Cities}/{{ibgeCode}}", async (string ibgeCode, UpdateCityModel model, IMediator mediator) =>
           {
               var result = await mediator.Send(model.FromCommand(ibgeCode));

               ModelResult<CityModel> response = result.FromModel();

               return result.CreateResult(response);
           })
           .WithName("UpdateCity")
           .WithTags(Tags)
           .Produces<ModelResult<CityModel>>(StatusCodes.Status200OK)
           .Produces<ModelResultBase>(StatusCodes.Status422UnprocessableEntity);

        app.MapDelete($"{ApiEndpointsPaths.Cities}/{{ibgeCode}}", async (string ibgeCode, IMediator mediator) =>
            {
                var result = await mediator.Send(ibgeCode.FromCommand());

                ModelResultBase response = result.FromModel();

                return result.CreateResult(response);

            })
            .WithName("DeleteCity")
            .WithTags(Tags)
            .Produces<ModelResultBase>(StatusCodes.Status200OK)
            .Produces<ModelResultBase>(StatusCodes.Status422UnprocessableEntity);

        return app;
    }
}

public record PagingData([FromQuery] int Page = 1, [FromQuery] int PageSize = 10)
{

    public static ValueTask<PagingData?> BindAsync(HttpContext context,
                                                   ParameterInfo parameter)
    {
        int page = int.TryParse(context.Request.Query["page"], out int pageParameter) ? pageParameter : 1;
        int pageSize = int.TryParse(context.Request.Query["page"], out int pageSizeParameter) ? pageSizeParameter : 10;

        return ValueTask.FromResult<PagingData?>(new(page, pageSize));
    }
}