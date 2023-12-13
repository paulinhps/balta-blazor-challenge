using Flunt.Notifications;
using IbgeBlazor.Application.LocalityContext.Localities.Commands;
using IbgeBlazor.Application.LocalityContext.Localities.Create;
using IbgeBlazor.Application.LocalityContext.States.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.States.Create;

public class Handler :
Notifiable<Notification>,
IRequestHandler<CreateStateCommand, DataCommandResult<State>>
{
    private readonly ILocalityRepository _repository;

    public Handler(ILocalityRepository repository)
    {
        _repository = repository;
    }

    public Task<DataCommandResult<State>> Handle(CreateStateCommand command, CancellationToken cancellationToken)
    {
        
        //1. Validar se o cammando está valido.
        //2. Checar se estado já exite.
        //3. Contruir os objetos.
        //4. Validar o domínio.
        //5. Salvar o estado na base.
        //6. Montar e retornar o resultado.
        throw new NotFiniteNumberException(nameof(Handle));
    }



}
