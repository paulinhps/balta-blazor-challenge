using Flunt.Notifications;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Enumerators;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IbgeBlazor.Application.LocalityContext.States.Update;

public class Handler : Notifiable<Notification>, IRequestHandler<UpdateStateCommand, ICommandResult<State>>
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
        ICommandResult<State> dataResult = new DataCommandResult<State>();


        if (!command.IsValid)
        {
            dataResult.AddErrors(command)
            .WithStatus(CommandResultType.InputedError)
            .WithMessage("Entrada de dados inválida");

            return dataResult;
        }

        State? state = null!;

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

        if (state is null)
        {

            AddNotification("StateNotFound", "Estado não encontrado!");

        }

        state?.ChangeDescription(command.Description);

        AddNotifications(state);

        if (IsValid)
        {
            try
            {
                _ = await _repository.UpdateState(state!);

                dataResult
                .WithData(state)
                .WithStatus(CommandResultType.Success)
                .WithMessage("Estado atulizado com sucesso!");

            }
            catch
            {
                AddNotification("DataBaseUpdate", "Não foi possível salvar o estado");
            }
        }

        //adicionando errors caso exista
        dataResult.AddErrors(this)
        .AddStateWhenInvalid(CommandResultType.ProccessError)
        .AddMessageWhenInvalid("Não foi possível atualizar o estado!");

        //6. Montar e retornar o resultado.
        return dataResult;
    }

}
