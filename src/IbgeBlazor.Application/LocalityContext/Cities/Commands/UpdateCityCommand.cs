using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using IbgeBlazor.Core.LocalityContext.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.Commands;

public class UpdateCityCommand : CommandBase, IRequest<ICommandResult<City>>
{
    public int Id { get; set; } = 0;
    public string IbgeCode { get; set; } = null;
    public string CityName { get; set; } = null;
    public int StateId { get; set; }

    public UpdateCityCommand(string ibgeCode, string cityName, int stateId)
    {
        IbgeCode = ibgeCode;
        CityName = cityName;
        StateId = stateId;
        Validate();
    }

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<UpdateCityCommand>(contract =>
        {
            contract.Requires()
                .IsGreaterThan(IbgeCode, 0, nameof(IbgeCode), $"{nameof(IbgeCode)} is Required")
                .IsNotNullOrWhiteSpace(CityName, nameof(CityName), $"{nameof(CityName)} is Required")
                .IsGreaterThan(StateId, 0, nameof(StateId), $"{nameof(StateId)} is Required");
        }));
    }
}
