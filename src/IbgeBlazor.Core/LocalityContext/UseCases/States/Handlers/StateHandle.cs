using Flunt.Notifications;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Repositories;
using IbgeBlazor.Core.LocalityContext.UseCases.States.Commands;

namespace IbgeBlazor.Core.LocalityContext.UseCases.States.Handlers;

public class StateHandler : 
Notifiable<Notification>, 
ICreateStateHandler,
IUpdateStateHandler,
IDeleteStateHandler
{
    private readonly IStateRepository _repository;

    public StateHandler(IStateRepository repository)
    {
        _repository = repository;
    }

    public Task<StateCommandResult> Handle(CreateStateCommand command, CancellationToken cancellationToken)
    {
        //1. Validar se o cammando está valido.
        //2. Checar se estado já exite.
        //3. Contruir os objetos.
        //4. Validar o domínio.
        //5. Salvar o estado na base.
        //6. Montar e retornar o resultado.
        throw new NotFiniteNumberException(nameof(Handle));
    }

    public Task<StateCommandResult> Handle(UpdateStateCommand command, CancellationToken cancellationToken)
    {
        //1. Validar se o cammando está valido.
        //2. Reidratar o estado da base. 
        //3. Atualizar dados
        //4. Validar o domínio.
        //5. Salvar o estado na base.
        //6. Montar e retornar o resultado.
        throw new NotImplementedException();
    }

    public Task<CommandResult> Handle(DeleteStateCommand command, CancellationToken cancellationToken)
    {
        //1. Validar se o cammando está valido.
        //2. Verificar se o objeto existe.
        //3. Verificar se o estado não tem relacionamento.
        //4. Deletar estado
        //5. Montar e retornar o resultado.
        throw new NotImplementedException();
    }
}