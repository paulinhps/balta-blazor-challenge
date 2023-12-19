using IbgeBlazor.Api.Endpoints.Localities;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.Common.Services;
using IbgeBlazor.Core.LocalityContext.DataModels.Cities;

namespace IbgeBlazor.Core.LocalityContext.Services
{
    
    public interface ICitiesService : IHttpService
    {
        Task<ModelResult<CityModel>?> CreateCity(CreateCityModel updateCityModel);
        Task<ModelResult<IEnumerable<CityModel>>?> ListCities(PagingDataBase? updateCityModel = null);
        Task<ModelResult<CityModel>?> GetCityDetails(string ibgeCode);
        Task<ModelResult<CityModel>?> UpdateCity(string ibgeCode, UpdateCityModel updateCityModel);
        Task<ModelResultBase?> DeleteCity(string ibgeCode);
        
    }
}