namespace IbgeBlazor.Api.Endpoints.Localities;

public record PagingDataModel(int page = 1, int pageSize = 10) : PagingDataBase(page, pageSize);