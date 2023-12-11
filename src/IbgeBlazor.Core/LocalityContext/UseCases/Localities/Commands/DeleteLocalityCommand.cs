using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using IbgeBlazor.Core.LocalityContext.UseCases.States.Commands;

namespace IbgeBlazor.Core.LocalityContext.UseCases.Localities.Commands;

public class DeleteLocalityCommand : CommandBase, ICommand
{
    public string IbgeCode { get; set; } = null!;

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<CreateStateCommand>(contract =>
        {

            contract.Requires()
                    .IsNotNullOrWhiteSpace(IbgeCode, nameof(IbgeCode), $"{nameof(IbgeCode)} is Required");

        }));
    }
}