using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using IbgeBlazor.Core.LocalityContext.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Localities.Commands
{
    public class CreateLocalityCommand : CommandBase, IRequest<DataCommandResult<Locality>>
    {
        public string IbgeCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public int StateId { get; set; } = 0;

        public override void Validate()
        {
            AddNotifications(CommandValidator.Validate<CreateLocalityCommand>(contract =>
            {

                contract.Requires()
                .IsNotNullOrWhiteSpace(IbgeCode, nameof(IbgeCode), $"{nameof(IbgeCode)} is Required")
                .IsNotNullOrWhiteSpace(City, nameof(City), $"{nameof(City)} is Required")
                .IsGreaterThan(StateId, 0, nameof(StateId), $"{nameof(StateId)} is Required");

            }));
        }
    }
}