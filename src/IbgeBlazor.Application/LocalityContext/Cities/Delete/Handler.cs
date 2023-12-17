using Flunt.Notifications;
using IbgeBlazor.Application.LocalityContext.Cities.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IbgeBlazor.Application.LocalityContext.Cities.Delete;

public class Handler : Notifiable<Notification>, IRequestHandler<DeleteCityCommand, ICommandResult>
{
    private readonly ICitiesRepository _citiesRepository;
    private readonly ILogger<Handler> _logger;

    public Handler(ICitiesRepository citiesRepository, ILogger<Handler> logger)
    {
        _logger = logger;
        _citiesRepository = citiesRepository;
    }

    public async Task<ICommandResult> Handle(DeleteCityCommand command, CancellationToken cancellationToken)
    {
        var dataResult = new DataCommandResult<City>();

        if (!command.IsValid)
        {
            dataResult.AddNotifications(command);
            return dataResult;
        }

        //2. Checar se estado já exite.
        try
        {
            bool cityExists = await _citiesRepository.IsExistsCityWithIbgeCode(command.IbgeCode);

            if (!cityExists)
            {
                AddNotification("City.Founded", "A Cidade não está cadastrada");
            }
        }
        catch (Exception ex)
        {
            var errorMessage = "Houve um erro ao tentar verificar se a cidade já existe";
            _logger.LogCritical(ex, errorMessage);
            AddNotification("CheckCity", errorMessage);
        }

        //3. Deleta a cidade na base.

        if (IsValid)
        {
            try
            {
                var success = await _citiesRepository.DeleteCity(command.IbgeCode);


            }
            catch
            {
                AddNotification("DeleteCity", "Não foi possível remover a cidade");
            }
        }

        //4. Montar e retornar o resultado.
        dataResult.AddNotifications(this);

        //5. Montar e retornar o resultado.
        return dataResult;
    }
}