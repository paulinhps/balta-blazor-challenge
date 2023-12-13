using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Localities.Commands;

public class DeleteLocalityCommand : CommandBase, IRequest<CommandResult>
{
    public string IbgeCode { get; set; } = null!;

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<DeleteLocalityCommand>(contract =>
        {

            contract.Requires()
                    .IsNotNullOrWhiteSpace(IbgeCode, nameof(IbgeCode), $"{nameof(IbgeCode)} is Required");

        }));
    }
}
