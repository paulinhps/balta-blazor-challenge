using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using IbgeBlazor.Core.LocalityContext.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.Commands;

public class CreateCityCommand : CommandBase, IRequest<ICommandResult<City>>
{
    public string IbgeCode { get; set; } = null!;
    public string CityName { get; set; } = null!;
    public int StateId { get; set; }

    public CreateCityCommand(string ibgeCode, string cityName, int stateId)
    {
         IbgeCode = ibgeCode;
         CityName= cityName;
         StateId= stateId;
         Validate();
    }

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<CreateCityCommand>(contract =>
        {
            contract.Requires()
                .IsGreaterThan(IbgeCode, 0, nameof(IbgeCode), $"{nameof(IbgeCode)} is Required")
                .IsNotNullOrWhiteSpace(CityName, nameof(CityName), $"{nameof(CityName)} is Required")
                .IsGreaterThan(StateId, 0, nameof(StateId), $"{nameof(StateId)} is Required");

            //TODO: Incluir demais validaçoes referte a class City.
            //HACK: Esta assim para voltar e refatorar.
        }));
    }


}