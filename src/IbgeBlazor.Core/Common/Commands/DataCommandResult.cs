
namespace IbgeBlazor.Core.Common.Commands;

public class DataCommandResult<TData> : CommandResult, ICommandResult<TData>
where TData : class
{
    public TData? Data { get; set; } = null!;

    public override bool Success => base.Success && Data is not null; 
    
    public DataCommandResult(TData data, string message) : this(message)
    {
        Data = data;
    }
    public DataCommandResult(string message) : base(message) {

    }

    public DataCommandResult() : base()
    {
        
    }
    
}
