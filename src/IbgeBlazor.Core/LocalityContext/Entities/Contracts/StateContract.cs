using Flunt.Validations;

namespace IbgeBlazor.Core.LocalityContext.Entities.Contracts;

internal class StateContract : Contract<State>
{
    public StateContract(State state)
    {
        Requires()
        .IsNotNull(state.Code, "State.Code", "State Code is required")
        .IsNotNullOrWhiteSpace(state.Name, "State.Description", "Description is required");

        //Code Rules Notifications
        AddNotifications(state.Code);

    }
}