using IbgeBlazor.Core.Common.ValueObjects;
using IbgeBlazor.Core.LocalityContext.ValueObjects.Contracts;

namespace IbgeBlazor.Core.LocalityContext.ValueObjects;

public class IbgeCode : ValueObject
{
    public string Code { get; }

    public IbgeCode(string code)
    {
        Code = code;

        Validate();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }

    protected override void Validate()
    {
        AddNotifications(new IbgeCodeContract(this));
    }

    internal IbgeCode AssertContaisStateId(int stateCode)
    {
        var stateIdAsString = stateCode.ToString("00");

        if(Code?.StartsWith(stateIdAsString) is false) 
            AddNotification("IbgeCode.State", "Code require starts with state id");

            return this;
    }

    public static implicit operator IbgeCode(string code) => new IbgeCode(code);
    public static implicit operator string(IbgeCode ibgeCode) => ibgeCode.Code;
}
