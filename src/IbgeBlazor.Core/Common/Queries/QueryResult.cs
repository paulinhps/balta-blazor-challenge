namespace IbgeBlazor.Core.Common.Queries;

public record QueryResult<TData>(TData? Results) : IQueryResult<TData>;
