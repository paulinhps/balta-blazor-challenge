using Flunt.Notifications;
using IbgeBlazor.Application.LocalityContext.Localities.Commands;
using IbgeBlazor.Application.LocalityContext.States.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Localities.Create;

public class Handler :
Notifiable<Notification>,
IRequestHandler<CreateLocalityCommand, DataCommandResult<Locality>>
{
    private readonly ILocalityRepository _repository;

    public Handler(ILocalityRepository repository)
    {
        _repository = repository;
    }

    public async Task<DataCommandResult<Locality>> Handle(CreateLocalityCommand command, CancellationToken cancellationToken)
    {
        //1. Validar se o cammando está valido.
        command.Validate();

        if(!command.IsValid)
            //Montar o retorno invalido
        
        //2. Checar se estado já exite.
            if(await _repository.StateIsExists(command.StateId)) {

            }
        //3. Checar se localidade já existe.
            if(await _repository.IbgeCodIsExists(command.IbgeCode)) {

            }
            // retorna erro
        //3. Contruir os objetos.

        Locality locality = new(command.IbgeCode, command.City,  command.StateId);
        //4. Validar o domínio.
            if(!locality.IsValid)
            {
                // Montar o retorno de erros
            }

        //5. Salvar a localidade na base.

        _ = await _repository.Create(locality);
        //6. Montar e retornar o resultado.
       return new(locality, true, "locality created");
    }


    
}
