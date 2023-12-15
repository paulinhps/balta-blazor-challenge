using Flunt.Notifications;
using IbgeBlazor.Application.LocalityContext.States.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IbgeBlazor.Application.LocalityContext.States.Update;

public class Handler :
Notifiable<Notification>,
IRequestHandler<UpdateStateCommand, ICommandResult<State>>
{
    private readonly IStatesRepository _repository;
    private readonly ILogger<Handler> _logger;

    public Handler(IStatesRepository repository, ILogger<Handler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ICommandResult<State>> Handle(UpdateStateCommand command, CancellationToken cancellationToken)
    {
        var dataResult = new DataCommandResult<State>();

        if (!command.IsValid)
        {
            dataResult.AddNotifications(command);

            return dataResult;
        }

        State state = null!;

        try
        {

            state = await _repository.GetStateById(command.Id);
            
        }
        catch (Exception ex)
        {
            var errorMessage = "Houve um erro ao tentar recuperar o estado";
            _logger.LogCritical(ex, errorMessage);
            AddNotification("CheckState", errorMessage);
        }
        
        if(state is null) {
            AddNotification("StateNotFound", "Estado não encontrado!");

            return dataResult;
        }

        state.ChangeDescription(command.Description);

        AddNotifications(state);

        if (IsValid)
        {
            try
            {
                _ = _repository.UpdateState(state);

                dataResult.Data = state;

            }
            catch
            {

                AddNotification("UpdateState", "Não foi possível salvar o estado");
            }
        }
        //adicionando notificações se existir
        dataResult.AddNotifications(this);

        //6. Montar e retornar o resultado.
        return dataResult;
    }



}
