namespace IbgeBlazor.Api.Endpoints.Localities;

public abstract record PagingDataBase(int Page = 1, int PageSize = 10) {
    public string GetQueryString() => $"?page={Page}&pageSize={PageSize}";
}