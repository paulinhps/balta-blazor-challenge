using Flunt.Notifications;
using IbgeBlazor.Application.LocalityContext.Cities.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IbgeBlazor.Application.LocalityContext.Cities.Update;

public class Handler : Notifiable<Notification>, IRequestHandler<UpdateCityCommand, ICommandResult<City>>
{
    private readonly ICitiesRepository _repository;
    private readonly ILogger<Handler> _logger;

    public Handler(ICitiesRepository repository, ILogger<Handler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ICommandResult<City>> Handle(UpdateCityCommand command, CancellationToken cancellationToken)
    {
        //1. Validar se o cammando está valido.
        var dataResult = new DataCommandResult<City>();

        //1. Validar se o cammando está valido.
        if (!command.IsValid)
        {
            dataResult.AddNotifications(command);
            return dataResult;
        }
        //2. Checar se estado já exite.
        try
        {
            bool cityExists = await _repository.IsExistsCityWithIdOrUf(command.IbgeCode);

            if (!cityExists)
            {
                AddNotification("City.Founded", "A Cidade não está cadastrada");
            }
        }
        catch (Exception ex)
        {
            var errorMessage = "Houve um erro ao tentar verificar se a cidade já existe";
            _logger.LogCritical(ex, errorMessage);
            AddNotification("UpdateCity", errorMessage);
        }

        //3. Contruir os objetos.
        City city = new City(command.IbgeCode, command.CityName, command.StateId);

        //4. Validar o domínio.
        AddNotifications(city);

        //5. Salvar o estado na base.
        if (IsValid)
        {
            try
            {
                _ = _repository.UpdateCity(city);

                dataResult.Data = city;
            }
            catch
            {
                AddNotification("UpdateCity", "Não foi possível salvar a cidade");
            }
        }

        //adicionando notificações se existir
        dataResult.AddNotifications(this);

        //6. Montar e retornar o resultado.
        return dataResult;
    }
}