
using System.Net.Http.Json;
using System.Text.Json;
using IbgeBlazor.Core.Constants;

public class LocalityApiService : ILocalityService
{
    private readonly HttpClient _client;

    public LocalityApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<LocalityResponse?> PostCreateLocality(CreateLocalityRequest? request)
    {
        var responseMessage = await _client.PostAsJsonAsync(ApiEndpointsPaths.Localities, request);

      var content = await responseMessage.Content.ReadAsStringAsync();

      return JsonSerializer.Deserialize<LocalityResponse>(content);
    }
}

public class LocalityDto : Response
{
}

public class CreateLocalityDto : Request
{
}