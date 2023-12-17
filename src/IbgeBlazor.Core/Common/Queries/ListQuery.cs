namespace IbgeBlazor.Core.Common.Queries;

public abstract class ListQuery
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

}