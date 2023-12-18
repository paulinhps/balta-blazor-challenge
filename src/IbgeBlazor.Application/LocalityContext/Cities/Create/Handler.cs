using Flunt.Notifications;
using IbgeBlazor.Application.LocalityContext.Cities.Commands;
using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Enumerators;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IbgeBlazor.Application.LocalityContext.Cities.Create;

public class Handler : Notifiable<Notification>, IRequestHandler<CreateCityCommand, ICommandResult<City>>
{
    private readonly ICitiesRepository _citiesRepository;
    private readonly IStatesRepository _stateRepository;
    private readonly ILogger<Handler> _logger;

    public Handler(
        ICitiesRepository citiesRepository, 
        IStatesRepository stateRepository, 
        ILogger<Handler> logger)
    {
        _citiesRepository = citiesRepository;
        _logger = logger;
        _stateRepository = stateRepository;
    }

    public async Task<ICommandResult<City>> Handle(CreateCityCommand command, CancellationToken cancellationToken)
    {
        var dataResult = CommandResult.CreateCommandResult<City>();

        //1. Validar se o cammando está valido.
        if (!command.IsValid)
        {
            dataResult.AddErrors(command)
            .WithStatus(CommandResultType.InputedError)
            .WithMessage("Dados para Criar Estado estão inválidos");
            return dataResult;
        }
        //2. Checar se estado já exite.
         try
        {

            if (!await _stateRepository.IsExistsStateById(command.StateId))
            {
                AddNotification("State.NotFound", "O estado relacionado a cadastro não existe");
            }
        }
        catch (Exception ex)
        {
            var errorMessage = "Houve um erro ao tentar verificar se a cidade já existe";
            _logger.LogCritical(ex, errorMessage);
            AddNotification("CheckCity", errorMessage);
        }

        //3. Checar se a cidade já existe.
        try
        {
            bool cityExists = await _citiesRepository.IsExistsCityWithIbgeCode(command.IbgeCode);

            if (cityExists)
            {
                AddNotification("City.Founded", "A Cidade já está cadastrada");
            }
        }
        catch (Exception ex)
        {
            var errorMessage = "Houve um erro ao tentar verificar se a cidade já existe";
            _logger.LogCritical(ex, errorMessage);
            AddNotification("CheckCity", errorMessage);
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
                _ = await _citiesRepository.CreateCity(city);

                dataResult.WithData(city)
                .WithStatus(CommandResultType.Created)
                .WithMessage("Estado cadastrado com sucesso");
            }
            catch
            {
                AddNotification("CreateCity", "Não foi possível salvar a cidade");
            }
        }
        //adicionando notificações se existir
        dataResult.AddErrors(this)
        .AddStateWhenInvalid(CommandResultType.ProccessError)
        .AddMessageWhenInvalid("Não foi possível criar a cidade!");
        //6. Montar e retornar o resultado.
        return dataResult;
    }
}