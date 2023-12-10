using Flunt.Notifications;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Repositories;
using IbgeBlazor.Core.LocalityContext.UseCases.Localities.Commands;

namespace IbgeBlazor.Core.LocalityContext.UseCases.Localities.Handlers;

//TODO: Move this implementation to Application Layer
public class LocalityHandler :
Notifiable<Notification>,
ICreateLocalityHandler,
IUpdateLocalityHandler,
IDeleteLocalityHandler
{
    private readonly ILocalityRepository _repository;

    public LocalityHandler(ILocalityRepository repository)
    {
        _repository = repository;
    }

    public Task<LocalityCommandResult> Handle(CreateLocalityCommand command, CancellationToken cancellationToken)
    {
        //1. Validar se o cammando está valido.
        //2. Checar se estado já exite.
        //3. Checar se localidade já existe.
        //3. Contruir os objetos.
        //4. Validar o domínio.
        //5. Salvar a localidade na base.
        //6. Montar e retornar o resultado.
        throw new NotFiniteNumberException(nameof(Handle));
    }

    public Task<LocalityCommandResult> Handle(UpdateLocalityCommand command, CancellationToken cancellationToken)
    {
        //1. Validar se o cammando está valido.
        //2. Reidratar o estado da base. 
        //3. Atualizar dados
        //4. Validar o domínio.
        //5. Salvar o estado na base.
        //6. Montar e retornar o resultado.
        throw new NotImplementedException();
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