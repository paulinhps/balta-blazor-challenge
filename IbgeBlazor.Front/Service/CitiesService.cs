using IbgeBlazor.Front.Model;
using Mono.TextTemplating;
using System.Net.Http;

namespace IbgeBlazor.Front.Service
{
    public class CitiesService:ICitiesService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string apiEndpoint = "/cities";
        public CitiesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public CityModel GetCity(string id)
        {
            return new CityModel()
            {
                Id = id,
                City = "Curitiba",
                Uf = "PR",
                State = "Paraná",
            };

        }
        public async Task<List<CityModel>> GetCityList(string? UF = null)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("IbgeApi");
                var result = await httpClient.GetFromJsonAsync<List<CityModel>>(apiEndpoint + (string.IsNullOrEmpty(UF) ? "" : $"?uf={UF}"));
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
