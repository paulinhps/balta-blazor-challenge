using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.Commands;

public class DeleteCityCommand : CommandBase, IRequest<CommandResult>
{
    public int Id { get; set; } = 0;

    public DeleteCityCommand(int id)
    {
        Id= id;
        Validate();
    }

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<CreateCityCommand>(contract =>
        {

            contract.Requires()
                    .IsGreaterThan(Id, 0, nameof(Id), $"{nameof(Id)} is Required");

        }));
    }
}
