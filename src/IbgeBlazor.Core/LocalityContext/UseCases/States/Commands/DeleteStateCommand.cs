using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;

namespace IbgeBlazor.Core.LocalityContext.UseCases.States.Commands;

public class DeleteStateCommand : CommandBase, ICommand
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