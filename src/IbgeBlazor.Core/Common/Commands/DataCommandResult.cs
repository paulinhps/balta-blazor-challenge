

namespace IbgeBlazor.Core.Common.Commands;

public class DataCommandResult<TData> : CommandResult, ICommandResult<TData>
where TData : class
{
    public TData? Data { get; private set; } = null!;

    public override bool Success => base.Success && Data is not null;

    public DataCommandResult() : base() { }

    public ICommandResult<TData> WithData(TData? data)
    {
        Data = data;

        return this;
    }


}
