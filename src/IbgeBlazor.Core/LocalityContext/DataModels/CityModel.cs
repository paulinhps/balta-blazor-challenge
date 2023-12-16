
namespace IbgeBlazor.Core.LocalityContext.DataModels
{
    public record CityModel
    {
            public string? IbgeCode { get; set; }
            public string? CityName { get; set; }
            public StateModel? State { get; set; }
        
    }
}
