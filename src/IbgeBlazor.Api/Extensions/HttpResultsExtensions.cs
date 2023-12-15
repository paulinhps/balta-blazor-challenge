using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.DataModels;

namespace IbgeBlazor.Api.Extensions;

public static class HttpResultsExtensions
{
    public static IResult CreateResult<TCommandResult, TResponse>(
        this TCommandResult commandResult, 
        TResponse response = null!, 
        string? status201CreatedPath = null)
        where TCommandResult: ICommandResult
        where TResponse : ModelResultBase
    {
        return commandResult.ResultCode switch {
            StatusCodes.Status200OK => Results.Ok(response),
            StatusCodes.Status201Created => Results.Created(status201CreatedPath ?? string.Empty, response),
            StatusCodes.Status400BadRequest => Results.BadRequest(response),
            StatusCodes.Status401Unauthorized => Results.Unauthorized(),
            StatusCodes.Status403Forbidden => Results.Forbid(),
            StatusCodes.Status422UnprocessableEntity => Results.BadRequest(response),
            
            _ => Results.StatusCode(commandResult.ResultCode)
        };
    }
}