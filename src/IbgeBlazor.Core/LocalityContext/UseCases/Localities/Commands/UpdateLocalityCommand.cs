using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;

namespace IbgeBlazor.Core.LocalityContext.UseCases.Localities.Commands;

public class UpdateLocalityCommand : CommandBase, ICommand
{
    public string IbgeCode { get; set; } = null!;
    public string City { get; set; } = null!;

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<UpdateLocalityCommand>(contract =>
        {

            contract.Requires()
            .IsNotNullOrWhiteSpace(IbgeCode, nameof(IbgeCode), $"{nameof(IbgeCode)} is Required")
            .IsNotNullOrWhiteSpace(City, nameof(City), $"{nameof(City)} is Required");

        }));
    }
}
