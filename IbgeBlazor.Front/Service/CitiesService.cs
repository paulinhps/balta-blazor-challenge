using IbgeBlazor.Front.Model;
using Mono.TextTemplating;

namespace IbgeBlazor.Front.Service
{
    public class CitiesService
    {
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
        public List<CityModel> GetCityList()
        {
            return new List<CityModel>() {
                new CityModel() {
                    Id = "1",
                    City = "Curitiba",
                    Uf = "PR",
                    State = "Paraná",
                },
                new CityModel() {
                    Id = "2",
                    City = "São Paulo",
                    Uf = "SP",
                    State = "São Paulo",
                },
                new CityModel() {
                    Id = "3",
                    City = "Rio de Janeiro",
                    Uf = "RJ",
                    State = "Rio de Janeiro",
                },
            };
        }
    }
}
