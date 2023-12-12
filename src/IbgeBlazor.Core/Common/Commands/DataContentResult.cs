namespace IbgeBlazor.Core.Common.Commands;

public class DataCommandResult<TData> : CommandResult
{
    public TData Data { get; set; }
    public DataCommandResult(TData data, bool success, string message) : base(success, message)
    {
        Data = data;
    }
}
