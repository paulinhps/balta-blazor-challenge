using IbgeBlazor.Application.LocalityContext.Localities.Create;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using IbgeBlazor.Core.LocalityContext.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.States.Commands;

public class UpdateStateCommand : CommandBase, IRequest<DataCommandResult<State>>
{
    public int Id { get; set; } = 0;
    public string Description { get; set; } = null!;

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<CreateStateCommand>(contract =>
        {

            contract.Requires()
            .IsGreaterThan(Id, 0, nameof(Id), $"{nameof(Id)} is Required")
            .IsNotNullOrWhiteSpace(Description, nameof(Description), $"{nameof(Description)} is Required");

        }));
    }
}
