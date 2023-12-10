using IbgeBlazor.Core.Common.ValueObjects;
using IbgeBlazor.Core.LocalityContext.ValueObjects.Contracts;

namespace IbgeBlazor.Core.LocalityContext.ValueObjects;

public class StateCode : ValueObject
{
    public StateCode(string code)
    {
        Code = code;
        Validate();
    }

    public string Code { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
       yield return Code;
    }

    protected override void Validate()
    {
        AddNotifications(new StateCodeContract(this));
    }

    public static implicit operator StateCode(string code) => new StateCode(code);
    public static implicit operator string(StateCode code) => code.Code;
}