using IbgeBlazor.Application.LocalityContext.States.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.LocalityContext.DataModels;
using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Application.LocalityContext.States.Extensions;

public static class StatesDataModelsExtensions
{
    public static CreateStateCommand FromCommand(this CreateStateModel model)
    => new(model.IbgeUfId, model.Uf, model.Description)
    {
        Id = model.IbgeUfId,
        Code = model.Uf,
        Description = model.Description
    };

    public static ModelResult<StateModel> FromModel(this ICommandResult<State> commandResult)
    {


        StateModel? model = commandResult.Data is not null ? new()
        {
            Id = commandResult.Data!.Id,
            Description = commandResult.Data.Description,
            Uf = commandResult.Data.Code
        } : null;


        return new(model, commandResult.Message, commandResult.Errors.ToArray());
    }
    public static ModelResultBase FromModel(this ICommandResult commandResult)
    {

        return new ModelResult(commandResult.Message, commandResult.Errors.ToArray());

    }
    public static UpdateStateCommand FromCommand(this UpdateStateModel model, int stateId)
    => new(stateId, model.Description);

}