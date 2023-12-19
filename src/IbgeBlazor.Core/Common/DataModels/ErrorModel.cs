
using System.Text.Json.Serialization;

namespace IbgeBlazor.Core.Common.DataModels;

public record ErrorModel : IErrorModel
{
    public string? Key { get ; set ; }
    public string? Message { get; set; }

    [JsonConstructor]
    public ErrorModel() 
    {
        
    }

    public ErrorModel(string key, string message)
    {
        Key = key;
        Message = message;
    }
};
