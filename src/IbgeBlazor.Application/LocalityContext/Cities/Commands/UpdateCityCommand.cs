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
    public string UfCode { get; set; } = null;

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<UpdateCityCommand>(contract =>
        {
            contract.Requires()
                .IsGreaterThan(Id, 0, nameof(Id), $"{nameof(Id)} is Required")
                .IsNotNullOrWhiteSpace(IbgeCode, nameof(IbgeCode), $"{nameof(IbgeCode)} is Required")
                .IsNotNullOrWhiteSpace(CityName, nameof(CityName), $"{nameof(CityName)} is Required")
                .IsNotNullOrWhiteSpace(UfCode, nameof(UfCode), $"{nameof(UfCode)} is Required");
        }));
    }
}
