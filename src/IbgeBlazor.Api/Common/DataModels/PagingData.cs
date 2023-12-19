using IbgeBlazor.Api.Endpoints.Localities;
using System.Reflection;

namespace IbgeBlazor.Api.Common.DataModels
{
    public record PagingData : PagingDataBase
    {

        public PagingData(int page = 1, int pageSize = 10) : base(page, pageSize)
        {
            
        }
        public static ValueTask<PagingData?> BindAsync(HttpContext context,
                                                   ParameterInfo parameter)
        {
            int page = int.TryParse(context.Request.Query["page"], out int pageParameter) ? pageParameter : 1;
            int pageSize = int.TryParse(context.Request.Query["pageSize"], out int pageSizeParameter) ? pageSizeParameter : 10;

            return ValueTask.FromResult<PagingData?>(new PagingData(page, pageSize));
        }
    }
}
