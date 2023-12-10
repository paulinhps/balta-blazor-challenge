using System.Text.RegularExpressions;
using Flunt.Validations;

namespace IbgeBlazor.Core.LocalityContext.ValueObjects.Contracts;

internal class IbgeCodeContract : Contract<IbgeCode>
{
    public IbgeCodeContract(IbgeCode code)
    {

        Requires()
        .IsNotNullOrWhiteSpace(code?.Code, "IbgeCode.Code", "Code is required")
        .IsTrue(Regex.IsMatch(code?.Code ?? string.Empty, @"^\d{7}$"), "IbgeCode.Code", "Required 7 digits");
    }
}