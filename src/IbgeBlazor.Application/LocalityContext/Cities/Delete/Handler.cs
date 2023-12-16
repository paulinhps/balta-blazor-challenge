using Flunt.Notifications;
using IbgeBlazor.Application.LocalityContext.Cities.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.Delete;

public class Handler :
Notifiable<Notification>,
IRequestHandler<DeleteCityCommand, CommandResult>
{
    private readonly ICitiesRepository _repository;

    public Handler(ICitiesRepository repository)
    {
        _repository = repository;
    }

    public Task<CommandResult> Handle(DeleteCityCommand command, CancellationToken cancellationToken)
    {
        //1. Validar se o cammando está valido.
        //2. Verificar se o objeto existe.
        //3. Verificar se o estado não tem relacionamento.
        //4. Deletar estado
        //5. Montar e retornar o resultado.
        throw new NotImplementedException();
    }
}