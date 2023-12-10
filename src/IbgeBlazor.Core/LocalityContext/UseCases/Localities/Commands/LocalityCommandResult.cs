using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Core.LocalityContext.UseCases.Localities.Commands;

public class LocalityCommandResult : DataContentResult<Locality>
{
    public LocalityCommandResult(Locality data, bool success, string message) : base(data, success, message)
    {
    }
}
