using IbgeBlazor.Api.Endpoints.Localities;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.LocalityContext.DataModels.States;
using IbgeBlazor.Core.LocalityContext.Services;
using MediatR;
using IbgeBlazor.Application.Common.Extensions;
using IbgeBlazor.Application.LocalityContext.Extensions;
using IbgeBlazor.Application.LocalityContext.States.Delete;
using IbgeBlazor.Application.LocalityContext.States.GetStateDetails;
using IbgeBlazor.Application.LocalityContext.States.GetStatesList;

namespace IbgeBlazor.Infraestructure.Services.Localities
{
    public class ApiStatesServices : IStatesService
    {
        private IMediator _mediator;

        public ApiStatesServices(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ModelResult<StateModel>?> CreateState(CreateStateModel createStateModel)
        {
            var result = await _mediator.Send(createStateModel.FromCommand());

            return result.FromModel();
        }

        public async Task<ModelResultBase?> DeleteState(int stateId)
        {
            var result = await _mediator.Send(new DeleteStateCommand(stateId));

            return result.FromModel();
        }

        public async Task<ModelResult<StateModel>?> GetStateDetails(int stateId)
        {
            try
            {
                var query = new GetStateDetailByIdQuery(stateId);

                var result = await _mediator.Send(query);

                return new ModelResult<StateModel>(result.Results is not null ? new StateModel()
                {
                    Description = result.Results!.Name,
                    Id = result.Results!.Id,
                    Uf = result.Results!.Code
                } : null, message: result.Results is null ? "Estado não encontrado" : null!);
            }
            catch (Exception ex)
            {
                ErrorModel error = new ErrorModel("StateDetailsRequest", ex.Message);
                return new ModelResult<StateModel>("Erro ao tentar recuperar detalhes do estado!", error);
            }
        }

        public async Task<ModelResult<IEnumerable<StateModel>>?> ListStates(PagingDataBase? paginationModel = null)
        {
            try
            {
                var query = new GetStateWithPaginationQuery()
                {
                    PageNumber = paginationModel?.Page ?? 1,
                    PageSize = paginationModel?.PageSize ?? 10
                };

                var result = await _mediator.Send(query);

                var dataResult = result.Results?
                .Select(StatesDataModelsExtensions.FromStateModel)
                .ToArray();
                return new ModelResult<IEnumerable<StateModel>>(dataResult!);
            }
            catch (Exception ex)
            {
                ErrorModel error = new ErrorModel("StateListRequest", ex.Message);
                return new ModelResult<IEnumerable<StateModel>>("Erro ao tentar recuperar lista de estados", error);
            }
        }

        public async Task<ModelResult<StateModel>?> UpdateState(int statiId, UpdateStateModel updateStateModel)
        {
            try
            {
                var result = await _mediator.Send(updateStateModel.FromCommand(statiId));

                return result.FromModel();
            }
            catch (Exception ex)
            {
                ErrorModel error = new ErrorModel("UpdateStateRequest", ex.Message);

                return new ModelResult<StateModel>("Erro ao tentar atualizar o estado", error);
            }
        }
    }
}