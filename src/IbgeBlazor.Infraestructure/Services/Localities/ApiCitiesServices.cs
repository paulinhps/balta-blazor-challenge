using IbgeBlazor.Api.Endpoints.Localities;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.LocalityContext.DataModels.Cities;
using IbgeBlazor.Core.LocalityContext.Services;
using IbgeBlazor.Application.LocalityContext.Extensions;
using IbgeBlazor.Application.Common.Extensions;
using MediatR;
using IbgeBlazor.Application.LocalityContext.Cities.GetCityList;
using IbgeBlazor.Application.LocalityContext.Cities.GetCityDetails;

namespace IbgeBlazor.Infraestructure.Services.Localities
{
    public class ApiCitiesServices : ICitiesService
    {
        private readonly IMediator _mediator;

        public ApiCitiesServices(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ModelResult<CityModel>?> CreateCity(CreateCityModel model)
        {
            var result = await _mediator.Send(model.FromCommand());

            ModelResult<CityModel> response = result.FromModel();

            return response;

        }

        public async Task<ModelResultBase?> DeleteCity(string ibgeCode)
        {
            var result = await _mediator.Send(ibgeCode.FromCommand());

            return result.FromModel();
        }

        public async Task<ModelResult<CityModel>?> GetCityDetails(string ibgeCode)
        {
            var query = new GetCityDetailByIbgeCodeQuery(ibgeCode);

            var result = await _mediator.Send(query);

            var response = result.Results?.FromCityModel();

            return new ModelResult<CityModel>(response);

        }

        public async Task<ModelResult<IEnumerable<CityModel>>?> ListCities(PagingDataBase? paginationModel = null)
        {
            var query = new GetCitiesWithPaginationQuery()
            {
                PageNumber = paginationModel?.Page ?? 1,
                PageSize = paginationModel?.PageSize ?? 10
            };

            var result = await _mediator.Send(query);

            var dataResult = result.Results?
            .Select(CitiesDataModelsExtensions.FromCityModel)
            .ToArray();

            return new ModelResult<IEnumerable<CityModel>>(dataResult!);
        }

        public async Task<ModelResult<CityModel>?> UpdateCity(string ibgeCode, UpdateCityModel updateCityModel)
        {
            var result = await _mediator.Send(updateCityModel.FromCommand(ibgeCode));

            return result.FromModel();
        }
    }
}