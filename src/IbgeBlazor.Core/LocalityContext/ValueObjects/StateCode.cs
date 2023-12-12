using IbgeBlazor.Core.Common.ValueObjects;
using IbgeBlazor.Core.LocalityContext.ValueObjects.Contracts;

namespace IbgeBlazor.Core.LocalityContext.ValueObjects;

public class StateCode : ValueObject
{
    public string CodeNumber { get; set; }

    public StateCode(string code)
    {
        CodeNumber = code;
        Validate();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CodeNumber;
    }

    protected override void Validate()
    {
        AddNotifications(new StateCodeContract(this));
    }

    public static implicit operator StateCode(string code) => new StateCode(code);
    public static implicit operator string(StateCode code) => code.CodeNumber;
}