
using IbgeBlazor.Core.Constants;
using MediatR;

public static class LocalityEndpoints
{
    private static string[] Tags = ["Localities"];
    public static WebApplication MapLocalityEndpoints(this WebApplication app) {

        app.MapPost(ApiEndpointsPaths.Localities, async(CreateLocality model,  IMediator mediator) => {

            LocalityContext.Commands.CreateLocalityCommand command = new() {
                IbgeCode = model.IbgeCode,
                City = model.City,
                StateId = model.StateId
            };


           var result = await mediator.Send(command);

            if(result.Success)
                return Results.Created($"{ApiEndpointsPaths.Localities}/{result.Data!.Id}", result);
            
            else 
                return Results.UnprocessableEntity(result.Data);
                
        })
        .WithTags(Tags)
        .WithName("CrateLocality")
        .WithOpenApi();
        return app;
    }
}

public record CreateLocality
{
    public string IbgeCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public int StateId { get; set; }
}
