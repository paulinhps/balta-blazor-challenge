using IbgeBlazor.Application.LocalityContext.States.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.LocalityContext.DataModels;
using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Application.LocalityContext.States.Extensions;

public static class StatesDataModelsExtensions
{
    public static CreateStateCommand FromCommand(this CreateStateModel model)
    => new()
    {
        Id = model.IbgeUfId,
        Code = model.Uf,
        Description = model.Description
    };
    public static ModelResult<StateModel> FromModel(this ICommandResult<State> commandResult)
    {
        if (!commandResult.Success)
            return new("Não foi possível criar o estado", commandResult.Errors.ToArray());

        StateModel model = new()
        {
            Id = commandResult.Data!.Id,
            Description = commandResult.Data.Description,
            Uf = commandResult.Data.Code
        };


        return new(model, "Estado criado com sucesso");
    }
}