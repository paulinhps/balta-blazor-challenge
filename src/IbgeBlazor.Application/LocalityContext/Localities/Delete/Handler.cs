using Flunt.Notifications;
using IbgeBlazor.Application.LocalityContext.Localities.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Localities.Delete;

public class Handler :
Notifiable<Notification>,
IRequestHandler<DeleteLocalityCommand, CommandResult>
{
    private readonly ILocalityRepository _repository;

    public Handler(ILocalityRepository repository)
    {
        _repository = repository;
    }

    public Task<CommandResult> Handle(DeleteLocalityCommand command, CancellationToken cancellationToken)
    {
        //1. Validar se o cammando está valido.
        //2. Verificar se o objeto existe.
        //4. Deletar localidade
        //5. Montar e retornar o resultado.
        throw new NotImplementedException();
    }



}
