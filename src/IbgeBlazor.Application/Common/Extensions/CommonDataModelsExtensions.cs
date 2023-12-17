using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.DataModels;

namespace IbgeBlazor.Application.Common.Extensions;

public static class CommonDataModelsExtensions
{
    public static ModelResultBase FromModel(this ICommandResult commandResult)
    => new ModelResult(commandResult.Message, commandResult.Errors.ToArray());
}
