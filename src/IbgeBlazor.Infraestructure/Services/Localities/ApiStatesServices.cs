using System.Net.Http.Json;
using IbgeBlazor.Api.Endpoints.Localities;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.Constants;
using IbgeBlazor.Core.LocalityContext.DataModels.States;
using IbgeBlazor.Core.LocalityContext.Services;

namespace IbgeBlazor.Infraestructure.Services.Localities
{
    public class ApiStatesServices : IStatesService
    {
        private HttpClient _client;

        public ApiStatesServices(HttpClient client)
        {
            _client = client;
        }
        public async Task<ModelResult<StateModel>?> CreateState(CreateStateModel createStateModel)
        {
            try
            {
                var response = await _client.PostAsJsonAsync(ApiEndpointsPaths.States, createStateModel);

                return await response.Content.ReadFromJsonAsync<ModelResult<StateModel>>();
            }
            catch (Exception ex)
            {
                IErrorModel error = new ErrorModel("CreateStateRequest", ex.Message);
                return new ModelResult<StateModel>("Erro ao tentar criar o estado!", error);
            }
        }

        public async Task<ModelResultBase?> DeleteState(int stateId)
        {
            try
            {
                var response = await _client.DeleteAsync($"{ApiEndpointsPaths.States}/{stateId}");

                return await response.Content.ReadFromJsonAsync<ModelResult>();
            }
            catch (Exception ex)
            {
                IErrorModel error = new ErrorModel("DeleteStateRequest", ex.Message);

                return new ModelResult("Erro ao tentar deletar o estado!", error);
            }
        }

        public async Task<ModelResult<StateModel>?> GetStateDetails(int stateId)
        {
            try
            {
                var response = await _client.GetAsync($"{ApiEndpointsPaths.States}/{stateId}");
                return await response.Content.ReadFromJsonAsync<ModelResult<StateModel>>();
            }
            catch (Exception ex)
            {
                IErrorModel error = new ErrorModel("StateDetailsRequest", ex.Message);
                return new ModelResult<StateModel>("Erro ao tentar recuperar detalhes do estado!", error);
            }
        }

        public async Task<ModelResult<IEnumerable<StateModel>>?> ListStates(PagingDataBase? paginationModel = null)
        {
            try
            {
                var response = await _client.GetAsync($"{ApiEndpointsPaths.States}{paginationModel?.GetQueryString()}");
                return await response.Content.ReadFromJsonAsync<ModelResult<IEnumerable<StateModel>>>();
            }
            catch (Exception ex)
            {
                IErrorModel error = new ErrorModel("StateListRequest", ex.Message);
                return new ModelResult<IEnumerable<StateModel>>("Erro ao tentar recuperar lista de estados", error);
            }
        }

        public async Task<ModelResult<StateModel>?> UpdateState(int statiId, UpdateStateModel updateStateModel)
        {
            try
            {
                var response = await _client.PutAsJsonAsync($"{ApiEndpointsPaths.Cities}/{statiId}", updateStateModel);

                return await response.Content.ReadFromJsonAsync<ModelResult<StateModel>>();
            }
            catch (Exception ex)
            {
                IErrorModel error = new ErrorModel("UpdateStateRequest", ex.Message);

                return new ModelResult<StateModel>("Erro ao tentar atualizar o estado", error);
            }
        }
    }
}