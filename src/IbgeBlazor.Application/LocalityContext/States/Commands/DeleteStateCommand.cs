using IbgeBlazor.Application.LocalityContext.Localities.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.States.Commands;

public class DeleteStateCommand : CommandBase, IRequest<CommandResult>
{
    public int Id { get; set; } = 0;

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<CreateStateCommand>(contract =>
        {

            contract.Requires()
                    .IsGreaterThan(Id, 0, nameof(Id), $"{nameof(Id)} is Required");

        }));
    }
}