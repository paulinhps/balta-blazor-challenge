using System.Text.RegularExpressions;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Contracts;
using IbgeBlazor.Core.LocalityContext.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.States.Commands;

public class CreateStateCommand : CommandBase, IRequest<ICommandResult<State>>
{
    public int Id { get; set; } = 0;
    public string Code { get; set; } = null!;
    public string Description { get; set; } = null!;

    public CreateStateCommand(int id, string code, string description)
    {
        Id = id;
        Code = code;
        Description = description;

        Validate();
    }

    public override void Validate()
    {
        AddNotifications(CommandValidator.Validate<CreateStateCommand>(contract =>
        {

            contract.Requires()
            .IsGreaterThan(Id, 0, nameof(Id), $"{nameof(Id)} is Required")
            .IsTrue(Regex.IsMatch(Id.ToString(), @"^\d{2}$"), nameof(Code), $"{nameof(Code)} is required with two numerics digits!")
            .IsNotNullOrWhiteSpace(Code, nameof(Code), $"{nameof(Code)} is Required")
            .IsTrue(Regex.IsMatch(Code, @"^[A-Z]{2}$"), nameof(Code), $"{nameof(Code)} two upper case letters.")
            .IsNotNullOrWhiteSpace(Description, nameof(Description), $"{nameof(Description)} is Required");

        }));
    }
}

