using IbgeBlazor.Application.LocalityContext.Cities.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.LocalityContext.DataModels;
using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Application.LocalityContext.Cities.Extensions;

public static class StatesDataModelsExtensions
{
    public static CreateCityCommand FromCommand(this CreateCityModel model)
        => new(model.IbgeCode, model.CityName, model.StateId);
    public static ModelResult<CityModel> FromModel(this ICommandResult<City> commandResult)
    {
        if (!commandResult.Success)
            return new("Não foi possível criar o cidade", commandResult.Errors.ToArray());

        CityModel model = new()
        {
            State = new StateModel
            {
                Id = commandResult.Data!.State.Id,
                Description = commandResult.Data!.State.Description,
                Uf = commandResult.Data!.State.Code
            },
            CityName = commandResult.Data.CityName,
            IbgeCode = commandResult.Data.Id
        };

        return new(model, "Cidade criado com sucesso");
    }
}