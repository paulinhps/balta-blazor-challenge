using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.Commands;

public class DeleteCityCommand : CommandBase, IRequest<ICommandResult>
{
    public string IbgeCode { get; set; } = null!;

    public DeleteCityCommand(string ibgeCode)
    {
        IbgeCode = ibgeCode;
        Validate();
    }

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<CreateCityCommand>(contract =>
        {

            contract.Requires()
                    .IsNotNullOrWhiteSpace(IbgeCode, nameof(IbgeCode), $"{nameof(IbgeCode)} is Required");

        }));
    }
}
