using IbgeBlazor.Application.LocalityContext.Cities.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.LocalityContext.DataModels;
using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Application.LocalityContext.Cities.Extensions;

public static class StatesDataModelsExtensions
{
    public static CreateCityCommand FromCommand(this CreateCityModel model) => new()
    {
        Id = model.IbgeCode,
        UfCode = model.UfCode,
        CityName = model.CityName,
        IbgeCode = model.IbgeCode
    };
    public static ModelResult<CityModel> FromModel(this ICommandResult<City> commandResult)
    {
        if (!commandResult.Success)
            return new("Não foi possível criar o cidade", commandResult.Errors.ToArray());

        CityModel model = new()
        {
            UfCode = commandResult.Data!.UfCode,
            CityName = commandResult.Data.CityName,
            IbgeCode = commandResult.Data.IbgeCode
        };

        return new(model, "Cidade criado com sucesso");
    }
}