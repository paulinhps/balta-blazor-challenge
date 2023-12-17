using IbgeBlazor.Application.LocalityContext.States.Create;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.LocalityContext.DataModels.States;
using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Application.LocalityContext.Extensions;

public static class StatesDataModelsExtensions
{
    public static CreateStateCommand FromCommand(this CreateStateModel model)
    => new(model.IbgeUfId, model.Uf, model.Description);
    public static ModelResult<StateModel> FromModel(this ICommandResult<State> commandResult)
    {
        if (!commandResult.Success)
            return new("Não foi possível criar o estado", commandResult.Errors.ToArray());
        StateModel? model = commandResult.Data?.FromStateModel();

        return new(model, "Estado criado com sucesso");
    }

    public static StateModel? FromStateModel(this State? state)
    {
        if (state == null) return null;

        return new()
        {
            Id = state.Id,
            Description = state.Name,
            Uf = state.Code
        };
    }
}