using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using IbgeBlazor.Core.Common.DataModels;
using Microsoft.AspNetCore.Diagnostics;

namespace IbgeBlazor.Api.Extensions;

public static class ExceptionHandlerExtensions
{
    public static void UseGlobalExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (exceptionHandlerFeature is not null)
                {
                    app.Logger.LogError($"an unexpected error occurred: {exceptionHandlerFeature.Error}");

                    var isBadRequest = exceptionHandlerFeature.Error.GetType().Equals(typeof(BadHttpRequestException));

                    // HACK: isso dá pra melhor, mas com o tempo de entrega chegando fiz simples
                    var statusCode = isBadRequest ? StatusCodes.Status422UnprocessableEntity : StatusCodes.Status500InternalServerError;
                    context.Response.StatusCode = statusCode;
                    context.Response.ContentType = "application/json";

                    var errorKey = isBadRequest ? nameof(HttpStatusCode.BadRequest) : nameof(HttpStatusCode.InternalServerError);
                    var errorMessage = isBadRequest ? "Erro ao processar a requisição" : "Erro Interno do Servidor";

                    ErrorModel error = new ErrorModel(errorKey, errorMessage);

                    var json = JsonSerializer.Serialize(new ModelResult("Falha da requisição", error), new JsonSerializerOptions
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        WriteIndented = false

                    });

                    await context.Response.WriteAsync(json);
                }
            });
        });
    }
}