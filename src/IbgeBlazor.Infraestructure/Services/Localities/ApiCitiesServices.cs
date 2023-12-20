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

        public async Task<ModelResult<CityModel>?> CreateCity(CreateCityModel createCityModel)
        {
            try
            {
                var response = await _client.PostAsJsonAsync(ApiEndpointsPaths.Cities, createCityModel);

                return await response.Content.ReadFromJsonAsync<ModelResult<CityModel>>();
            }
            catch (Exception ex)
            {
                ErrorModel error = new ErrorModel("CreateCityRequest", ex.Message);

                return new ModelResult<CityModel>("Erro ao tentar criar a cidade", error);
            }

        }

        public async Task<ModelResultBase?> DeleteCity(string ibgeCode)
        {
            try
            {
                var response = await _client.DeleteAsync($"{ApiEndpointsPaths.Cities}/{ibgeCode}");

                return await response.Content.ReadFromJsonAsync<ModelResult>();
            }
            catch (Exception ex)
            {
                ErrorModel error = new ErrorModel("DeleteCityRequest", ex.Message);

                return new ModelResult("Erro ao tentar deletar a cidade", error);
            }
        }

        public async Task<ModelResult<CityModel>?> GetCityDetails(string ibgeCode)
        {
            try
            {
                var response = await _client.GetAsync($"{ApiEndpointsPaths.Cities}/{ibgeCode}");

                return await response.Content.ReadFromJsonAsync<ModelResult<CityModel>>();
            }
            catch (Exception ex)
            {
                ErrorModel error = new ErrorModel("CityDetailsRequest", ex.Message);

                return new ModelResult<CityModel>("Erro ao tentar recuperar detalhes da cidade", error);
            }
        }

        public async Task<ModelResult<IEnumerable<CityModel>>?> ListCities(PagingDataBase? paginationModel = null)
        {
            try
            {
                var response = await _client.GetAsync($"{ApiEndpointsPaths.Cities}{paginationModel?.GetQueryString()}");

                return await response.Content.ReadFromJsonAsync<ModelResult<IEnumerable<CityModel>>>();
            }
            catch (Exception ex)
            {
                ErrorModel error = new ErrorModel("CityListRequest", ex.Message);

                return new ModelResult<IEnumerable<CityModel>>("Erro ao tentar recuperar lista de cidades", error);
            }
        }

        public async Task<ModelResult<CityModel>?> UpdateCity(string ibgeCode, UpdateCityModel updateCityModel)
        {
            try
            {
                var response = await _client.PutAsJsonAsync($"{ApiEndpointsPaths.Cities}/{ibgeCode}", updateCityModel);

                return await response.Content.ReadFromJsonAsync<ModelResult<CityModel>>();
            }
            catch (Exception ex)
            {
                ErrorModel error = new ErrorModel("UpdateCityRequest", ex.Message);

                return new ModelResult<CityModel>("Erro ao tentar atualisar a cidade", error);
            }
        }
    }
}