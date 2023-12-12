using Flunt.Notifications;
using IbgeBlazor.Application.LocalityContext.States.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.States.Delete;

public class Handler :
Notifiable<Notification>,
IRequestHandler<DeleteStateCommand, CommandResult>
{
    private readonly ILocalityRepository _repository;

    public Handler(ILocalityRepository repository)
    {
        _repository = repository;
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
