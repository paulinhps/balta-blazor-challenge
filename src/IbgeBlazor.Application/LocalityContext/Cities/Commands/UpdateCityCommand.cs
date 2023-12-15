using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using IbgeBlazor.Core.LocalityContext.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.Commands;

public class UpdateCityCommand : CommandBase, IRequest<ICommandResult<City>>
{
    public int Id { get; set; } = 0;
    public int IbgeCode { get; set; } = 0;
    public string CityName { get; set; } = null;
    public int UfCode { get; set; } = 0;

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<UpdateCityCommand>(contract =>
        {
            contract.Requires()
                .IsGreaterThan(Id, 0, nameof(Id), $"{nameof(Id)} is Required")
                .IsGreaterThan(IbgeCode, 0, nameof(IbgeCode), $"{nameof(IbgeCode)} is Required")
                .IsNotNullOrWhiteSpace(CityName, nameof(CityName), $"{nameof(CityName)} is Required")
                .IsGreaterThan(UfCode, 0, nameof(UfCode), $"{nameof(UfCode)} is Required");
        }));
    }
}
