using System.Linq.Expressions;
using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Core.LocalityContext.Queries.States
{
    public static class StateQueries
    {
        public static Expression<Func<State, bool>> GetStateInfo(string stateCode)
        {
            return x => x.Code!.CodeNumber.Equals(stateCode);
        }
        // more queries implementations
    }
}