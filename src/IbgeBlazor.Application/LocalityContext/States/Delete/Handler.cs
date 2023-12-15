using Flunt.Notifications;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Enumerators;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IbgeBlazor.Application.LocalityContext.States.Delete;

public class Handler :
Notifiable<Notification>,
IRequestHandler<DeleteStateCommand, ICommandResult>
{
    private readonly IStatesRepository _repository;
    private readonly ILogger _logger;

    public Handler(IStatesRepository repository, ILogger<Handler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ICommandResult> Handle(DeleteStateCommand command, CancellationToken cancellationToken)
    {
        ICommandResult result = new CommandResult();
        //1. Validar se o cammando está valido.

        if (!command.IsValid)
        {
            result.AddErrors(command)
            .WithStatus(CommandResultType.InputedError)
            .WithMessage("Dados para deletar estado estão inválidos!");
            return result;
        }
        //2. Verificar se o objeto existe.
        State? state = null!;

        try
        {
            state = await _repository.GetStateById(command.Id);
        }
        catch (Exception ex)
        {
            var errorMessage = "Houve um erro ao tentar recuperar o estado";
            _logger.LogCritical(ex, errorMessage);
            AddNotification("StateNotFound", errorMessage);
        }

        if (state is null)
        {
            AddNotification("StateNotFound", "Estado não foi encontrado");

        }

        // //3. Verificar se o estado não tem relacionamento.
        // if(state?.Localities?.Count > 0)
        //  {
        //     AddNotification("StateWithLocaties", "Estado possui relação com Cidades");
        //     return result;
        //  }

        //4. Deletar estado
        if (IsValid)
        {
            try
            {
                var success = await _repository.RemoveState(state!);

                if (success)
                {
                    result.WithStatus(CommandResultType.Success)
                    .WithMessage("Estado excluido com sucesso!");
                }

            }
            catch
            {
                AddNotification("RemoveState", "Houve erro ao tentar remover o estado");
            }
        }

        result.AddErrors(this)
        .AddStateWhenInvalid(CommandResultType.ProccessError)
        .AddMessageWhenInvalid("Não foi possível excluir o estado!");
        //5. Montar e retornar o resultado.
        return result;
    }



}
