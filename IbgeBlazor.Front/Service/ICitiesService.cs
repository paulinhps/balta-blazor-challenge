using IbgeBlazor.Front.Model;

namespace IbgeBlazor.Front.Service
{
    public interface ICitiesService
    {
        CityModel GetCity(string id);
        Task<List<CityModel>> GetCityList();
    }
}
