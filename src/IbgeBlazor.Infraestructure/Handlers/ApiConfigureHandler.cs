using IbgeBlazor.Core.Common.DataModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace IbgeBlazor.Infraestructure.Handlers;

public class ApiConfigureHandler : DelegatingHandler
{


    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<ApiConfigureHandler> _logger;

    public ApiConfigureHandler(IHttpContextAccessor httpContextAccessor, HttpMessageHandler innerHandler, ILogger<ApiConfigureHandler> logger) : base(innerHandler)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }
    public ApiConfigureHandler(IHttpContextAccessor httpContextAccessor, ILogger<ApiConfigureHandler> logger)
    {
        _httpContextAccessor = httpContextAccessor; 
        _logger = logger;
    }
    protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
    {

        if (_httpContextAccessor.HttpContext is HttpContext context)
        {
            var accessToken = await context.GetTokenAsync("access_token");

            if (accessToken is not null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }
       
        try
        {
            // TODO: Injetar o TOKEN JWT antes de enviar
            // Lembrete como poderá haver rotas anonimas, o token vai ser injetado só se o usuário estiver autenticado.
            // Nesse caso o serviço que vai entregar isso vai trazer o token vazio

            var response = await base.SendAsync(request, cancellationToken);

            _logger.LogTrace("response success is " + response.IsSuccessStatusCode);
            // caso precise verificar algo, pode fazer aqui!

            return response;
        }
        catch (Exception ex)
        {
            var modelResult = new ModelResult("Não foi possível efetura a operação", new ErrorModel("ApiRequest", ex.Message));

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(JsonSerializer.Serialize(modelResult))
            };

            return response;
        }


    }
}