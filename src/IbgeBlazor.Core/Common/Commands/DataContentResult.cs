namespace IbgeBlazor.Core.Common.Commands;

public class DataContentResult<TData> : CommandResult
{
    public TData Data { get; set; }
    public DataContentResult(TData data, bool success, string message) : base(success, message)
    {
        Data = data;
    }
}
