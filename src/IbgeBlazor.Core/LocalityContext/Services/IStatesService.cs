using IbgeBlazor.Api.Endpoints.Localities;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.Common.Services;
using IbgeBlazor.Core.LocalityContext.DataModels.States;

namespace IbgeBlazor.Core.LocalityContext.Services
{
    public interface IStatesService : IHttpService {
        Task<ModelResult<StateModel>?> CreateState(CreateStateModel updateCityModel);
        Task<ModelResult<IEnumerable<StateModel>>?> ListStates(PagingDataBase?  paginationModel = null);
        Task<ModelResult<StateModel>?> GetStateDetails(int stateId);
        Task<ModelResult<StateModel>?> UpdateState(int statiId, UpdateStateModel updateCityModel);
        Task<ModelResultBase?> DeleteState(int stateId);
    }
}