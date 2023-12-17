namespace IbgeBlazor.Core.Common.Queries;

public interface IQueryResult<TData>
{
    public TData? Results { get; }
}
