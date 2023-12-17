
using IbgeBlazor.Core.LocalityContext.DataModels.States;

namespace IbgeBlazor.Core.LocalityContext.DataModels.Cities;

public record CityModel
{
    public string? IbgeCode { get; set; }
    public string? Name { get; set; }
    public StateModel? State { get; set; }

}
