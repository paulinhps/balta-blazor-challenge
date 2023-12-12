using Flunt.Notifications;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.Commands.Entities;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Localities.Update;

public class Handler :
Notifiable<Notification>,
IRequestHandler<UpdateLocalityCommand, DataCommandResult<Entity>>
{
    private readonly ILocalityRepository _repository;

    public Handler(ILocalityRepository repository)
    {
        _repository = repository;
    }

    public Task<DataCommandResult<Entity>> Handle(UpdateLocalityCommand command, CancellationToken cancellationToken)
    {
        //1. Validar se o cammando está valido.
        //2. Verificar se o objeto existe.
        //4. Deletar localidade
        //5. Montar e retornar o resultado.
        throw new NotImplementedException();
    }



}
