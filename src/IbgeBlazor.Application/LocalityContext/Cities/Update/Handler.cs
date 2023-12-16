using Flunt.Notifications;
using IbgeBlazor.Application.LocalityContext.Cities.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.Update;

public class Handler : Notifiable<Notification>, IRequestHandler<UpdateCityCommand, ICommandResult<City>>
{
    private readonly ICitiesRepository _repository;

    public Handler(ICitiesRepository repository)
    {
        _repository = repository;
    }

    public Task<ICommandResult<City>> Handle(UpdateCityCommand command, CancellationToken cancellationToken)
    {
        //1. Validar se o cammando está valido.
        //2. Reidratar o estado da base. 
        //3. Atualizar dados
        //4. Validar o domínio.
        //5. Salvar o estado na base.
        //6. Montar e retornar o resultado.
        throw new NotImplementedException();
    }
}