using IbgeBlazor.Api.Endpoints.Localities;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.Constants;
using IbgeBlazor.Core.LocalityContext.DataModels.Cities;
using IbgeBlazor.Core.LocalityContext.Services;
using System.Net.Http.Json;

namespace IbgeBlazor.Infraestructure.Services.Localities
{
    public class ApiCitiesServices : ICitiesService
    {
        private readonly HttpClient _client;

        public ApiCitiesServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<ModelResult<CityModel>?> CreateCity(CreateCityModel updateCityModel)
        {
            try
            {
                var response = await _client.PostAsJsonAsync(ApiEndpointsPaths.Cities, updateCityModel);

                return await response.Content.ReadFromJsonAsync<ModelResult<CityModel>>();
            }
            catch
            {
                return null;
            }

        }

        public Task<ModelResultBase?> DeleteCity(string ibgeCode)
        {
            throw new NotImplementedException();
        }

        public Task<ModelResult<CityModel>?> GetCityDetails(string ibgeCode)
        {
            throw new NotImplementedException();
        }

        public async Task<ModelResult<IEnumerable<CityModel>>?> ListCities(PagingDataBase updateCityModel)
        {

            try
            {
                var response = await _client.GetAsync(ApiEndpointsPaths.Cities);

                return await response.Content.ReadFromJsonAsync<ModelResult<IEnumerable<CityModel>>>();
            }
            catch
            {
                return null;
            }
        }

        public Task<ModelResult<CityModel>?> UpdateCity(string ibgeCode, UpdateCityModel updateCityModel)
        {
            throw new NotImplementedException();
        }
    }
}