using IbgeBlazor.Application.LocalityContext.Localities.Create;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using IbgeBlazor.Core.Common.Commands.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Localities.Update;

public class UpdateLocalityCommand : CommandBase, IRequest<DataCommandResult<Entity>>
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
