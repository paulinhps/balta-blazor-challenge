using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.Enumerators;

namespace IbgeBlazor.Api.Extensions;

public static class HttpResultsExtensions
{
    public static IResult CreateResult<TCommandResult, TResponse>(
        this TCommandResult commandResult,
        TResponse response = null!,
        string? status201CreatedPath = null)
        where TCommandResult : ICommandResult
        where TResponse : ModelResultBase
    {
        return commandResult.ResultCode switch
        {
            CommandResultType.Success => Results.Ok(response),
            CommandResultType.Created => Results.Created(status201CreatedPath ?? string.Empty, response),
            CommandResultType.InputedError => Results.BadRequest(response),
            CommandResultType.ProccessError => Results.BadRequest(response),

            _ => Results.StatusCode(500) // Internal Server Error
        };
    }
}
