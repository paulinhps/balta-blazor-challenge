using IbgeBlazor.Application.LocalityContext.Cities.Commands;
using IbgeBlazor.Application.LocalityContext.States.Update;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.LocalityContext.DataModels.Cities;
using IbgeBlazor.Core.LocalityContext.DataModels.States;
using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Application.LocalityContext.Extensions;
public static class CitiesDataModelsExtensions
{
    public static CreateCityCommand FromCommand(this CreateCityModel model)
    => new(model.IbgeCode, model.CityName, model.StateId ?? 0);

    public static UpdateCityCommand FromCommand(this UpdateCityModel model, string ibgeCode)
    => new(ibgeCode, model.CityName);
    public static DeleteCityCommand FromCommand(this string ibgeCode)
    => new(ibgeCode);

    public static ModelResult<CityModel> FromModel(this ICommandResult<City> commandResult)
    {


        CityModel? model = commandResult.Data?.FromCityModel();


        return new(model, commandResult.Message, commandResult.Errors.ToArray());
    }



    public static UpdateStateCommand FromCommand(this UpdateStateModel model, int stateId)
    => new(stateId, model.Description);

    public static CityModel? FromCityModel(this City? city)
    {
        if (city == null) return null;

        return new CityModel
        {
            Name = city.Name,
            IbgeCode = city.Id,
            State = city.State.FromStateModel()
        };
    }

}