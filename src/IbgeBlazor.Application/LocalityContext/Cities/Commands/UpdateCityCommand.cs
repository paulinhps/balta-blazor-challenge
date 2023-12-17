using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using IbgeBlazor.Core.LocalityContext.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.Commands;

public class UpdateCityCommand : CommandBase, IRequest<ICommandResult<City>>
{
    public string IbgeCode { get; set; } = null!;
    public string CityName { get; set; } = null!;

    public UpdateCityCommand(string ibgeCode, string cityName)
    {
        IbgeCode = ibgeCode;
        CityName = cityName;
        Validate();
    }

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<UpdateCityCommand>(contract =>
        {
            contract.Requires()
                .IsGreaterThan(IbgeCode, 0, nameof(IbgeCode), $"{nameof(IbgeCode)} is Required")
                .IsNotNullOrWhiteSpace(CityName, nameof(CityName), $"{nameof(CityName)} is Required");
        }));
    }
}
