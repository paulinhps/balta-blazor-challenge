using Flunt.Notifications;
using IbgeBlazor.Application.LocalityContext.Cities.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Enumerators;
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
        ICommandResult<City> dataResult = CommandResult.CreateCommandResult<City>();

        //1. Validar se o cammando está valido.
        if (!command.IsValid)
        {
            dataResult.AddErrors(command)
            .WithStatus(CommandResultType.InputedError)
            .WithMessage("Entrada de dados inválida");
            return dataResult;
        }
        //2. Checar se cidade já exite.

        City city = null!;
        try
        {
            city = await _repository.GetCityByIbeCode(command.IbgeCode);


        }
        catch (Exception ex)
        {
            var errorMessage = "Houve um erro ao tentar verificar se a cidade já existe";
            _logger.LogCritical(ex, errorMessage);
            AddNotification("UpdateCity", errorMessage);
        }

        //3. Contruir os objetos.

        if (city is null)
        {
            AddNotification("City.Founded", "A Cidade não está cadastrada");
        }

        city?.ChangeCityName(command.CityName);

        //4. Validar o domínio.
        AddNotifications(city);

        //5. Salvar o estado na base.
        if (IsValid)
        {
            try
            {
                _ = _repository.UpdateCity(city!);

                dataResult.WithData(city)
                .WithStatus(CommandResultType.Success)
                .WithMessage("Cidae atulizada com sucesso!");
            }
            catch
            {
                AddNotification("UpdateCity", "Não foi possível salvar a cidade");
            }
        }



        //adicionando notificações se existir
        dataResult.AddErrors(this)
        .AddStateWhenInvalid(CommandResultType.ProccessError)
        .AddMessageWhenInvalid("Não foi possível atualizar a cidade!");

        //6. Montar e retornar o resultado.
        return dataResult;
    }
}