using Flunt.Notifications;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Enumerators;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IbgeBlazor.Application.LocalityContext.States.Create;

public class Handler :
Notifiable<Notification>,
IRequestHandler<CreateStateCommand, ICommandResult<State>>
{
    private readonly IStatesRepository _repository;
    private readonly ILogger<Handler> _logger;

    public Handler(IStatesRepository repository, ILogger<Handler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ICommandResult<State>> Handle(CreateStateCommand command, CancellationToken cancellationToken)
    {
        ICommandResult<State> dataResult = new DataCommandResult<State>();

        //1. Validar se o cammando está valido.
        if (!command.IsValid)
        {
            dataResult.AddErrors(command)
            .WithStatus(CommandResultType.InputedError)
            .WithMessage("Dados para Criar Estado estão inválidos");
            return dataResult;
        }
        //2. Checar se estado já exite.
        try
        {

            bool stateExists = await _repository.IsExistsStateWithIdOrUf(command.Id, command.Code);

            if (stateExists)
            {
                AddNotification("State.Founded", "O Estado já está cadastrado");
            }
        }
        catch (Exception ex)
        {
            var errorMessage = "Houve um erro ao tentar verificar se o estado existe";
            _logger.LogCritical(ex, errorMessage);
            AddNotification("CheckState", errorMessage);
        }
        //3. Contruir os objetos.

        State state = new State(command.Id, command.Code, command.Description);

        //4. Validar o domínio.

        AddNotifications(state);

        //5. Salvar o estado na base.

        if (IsValid)
        {
            try
            {
                _ = await _repository.CreateState(state);

                dataResult.WithData(state)
                .WithStatus(CommandResultType.Created)
                .WithMessage("Estado cadastrado com sucesso");

            }
            catch
            {

                AddNotification("RemoveState", "Houve erro ao tentar criar o estado");
            }
        }
        //adicionando notificações se existir
        dataResult.AddErrors(this)
        .AddStateWhenInvalid(CommandResultType.ProccessError)
        .AddMessageWhenInvalid("Não foi possível criar um estado!");

        //6. Montar e retornar o resultado.
        return dataResult;
    }



}
