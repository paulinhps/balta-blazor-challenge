using Flunt.Validations;

namespace IbgeBlazor.Core.LocalityContext.ValueObjects.Contracts;

internal class StateCodeContract : Contract<StateCode>
{
    public StateCodeContract(StateCode stateCode)
    {
        Requires()
            .IsNotNullOrWhiteSpace(stateCode.CodeNumber, "StateCode", "Code is required")
            .IsTrue(stateCode?.CodeNumber?.Length == 2, "StateCode", "Code required 2 Digits");
    }
}