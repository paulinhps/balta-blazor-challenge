
using MediatR;

public static class LocalityEndPoints
{
    public static WebApplication MapLocalityEndpoints(this WebApplication app) {

        app.MapPost("/api/v1/localities", async(CreateLocality model,  IMediator mediator) => {

            LocalityContext.Commands.CreateLocalityCommand command = new() {
                IbgeCode = model.IbgeCode,
                City = model.City,
                StateId = model.StateId
            };

           var result = await mediator.Send(command);

            if(result.Success)
                return Results.Created($"/api/v1/localities/{result.Data.Id}", result);
            
            else 
                return Results.UnprocessableEntity(result.Data);
                
        })
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

public record Locality {
    public string IbgeCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public State State { get; set; } = null!;
}
public record State {
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public string Description { get; set; } = null!;
}